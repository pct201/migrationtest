using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERIMS.DAL;
using System.Data;
using System.IO;

public partial class Event_Event_New : clsBasePage
{
    #region Properties


    /// <summary>
    /// Denotes the Primary Key
    /// </summary>
    public decimal _PK_Event_Camera
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_Event_Camera"]);
        }
        set { ViewState["PK_Event_Camera"] = value; }
    }

    /// <summary>
    /// Denotes the Primary Key
    /// </summary>
    public decimal _PK_ACI_Notes
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_ACI_Notes"]);
        }
        set { ViewState["PK_ACI_Notes"] = value; }
    }

    /// <summary>
    /// Denotes the Primary Key
    /// </summary>
    public decimal _PK_Sonic_Notes
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_Sonic_Notes"]);
        }
        set { ViewState["PK_Sonic_Notes"] = value; }
    }

    /// <summary>
    /// Denotes the Primary Key
    /// </summary>
    public decimal _PK_Event_Camera_Sonic
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_Event_Camera_Sonic"]);
        }
        set { ViewState["PK_Event_Camera_Sonic"] = value; }
    }

    /// <summary>
    /// Denotes the Primary Key
    /// </summary>
    public decimal PK_Event
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_Event"]);
        }
        set { ViewState["PK_Event"] = value; }
    }

    /// <summary>
    /// Denotes the Foreign Key
    /// </summary>
    public decimal FK_Incident
    {
        get
        {
            return clsGeneral.GetInt(ViewState["FK_Incident"]);
        }
        set { ViewState["FK_Incident"] = value; }
    }

    /// <summary>
    /// Denotes Sonic Event
    /// </summary>
    public bool Is_Sonic_Event
    {
        get
        {
            return Convert.ToBoolean(ViewState["Is_Sonic_Event"]);
        }
        set { ViewState["Is_Sonic_Event"] = value; }
    }

    /// <summary>
    /// Denotes the operation whether edit or view
    /// </summary>
    public string StrOperation
    {
        get { return ViewState["StrOperation"] != null ? Convert.ToString(ViewState["StrOperation"]) : "view"; }
        set { ViewState["StrOperation"] = value; }
    }

    #endregion

    #region Page Event

    /// <summary>
    /// Page Load Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        txtCurrentDate.Text = DateTime.Now.ToShortDateString().ToString();
        if (!IsPostBack)
        {
            PK_Event = clsGeneral.GetQueryStringID(Request.QueryString["eid"]);
            FK_Incident = clsGeneral.GetQueryStringID(Request.QueryString["iid"]);
            StrOperation = Convert.ToString(Request.QueryString["mode"]);
            hdnPanel.Value = clsGeneral.GetPanelId(Request.QueryString["pnl"]).ToString();
            if (StrOperation == "add") Session.Remove("Eventcriteria");
            ucAttachment.FK_Table = PK_Event;
            Is_Sonic_Event = true;
            if (PK_Event > 0)
            {
                if (StrOperation.ToLower() == "view")
                {
                    BindDetailForView();
                }
                else
                {
                    //if (App_Access == AccessType.View) Response.Redirect(AppConfig.SiteURL + "Error.aspx?msg=errAcc");

                    BindDropDownList();
                    BindDetailsForEdit();

                    if (StrOperation.ToLower() != "addto") StrOperation = "edit";
                    else btnViewAudit.Visible = false;
                }
                //ucIncidentInfo.Visible = true;
                //ucIncidentInfo.CurrentTab = Convert.ToString(Controls_IncidentTab_IncidentTab.Tab.Event);
                //ucIncidentInfo.FillIncidentInformation(FK_Incident, PK_Event, 0);
                ucEventInfo.Visible = true;
                ucEventInfo.FillEventInformation(PK_Event);
            }
            else
            {
                //if (App_Access == AccessType.View)
                //    Response.Redirect(AppConfig.SiteURL + "Error.aspx?msg=errAcc");
                //else if (FK_Incident < 1)
                //    Response.Redirect(AppConfig.SiteURL + "Error.aspx?msg=errAcc"); //Redirect To the Incident Selection page
                //ucIncidentInfo.Visible = false;
                //ucIncidentInfo.FillIncidentInformation(FK_Incident, 0, 0);
                SetEditViewRights();
                ucEventInfo.Visible = false;
                ucEventInfo.FillEventInformation(PK_Event);

                PK_Event = 0;
                StrOperation = "add"; btnViewAudit.Visible = false;
                btnBack.Visible = false;
                BindDropDownList();
                ucAttachment.ReadOnly = false;
            }
        }
        else
        {
        }
        Page.ClientScript.RegisterStartupScript(typeof(string), DateTime.Now.ToString(), "javascript:ShowPanel(" + hdnPanel.Value + ");", true);
        ucIncident.SetSelectedTab(Controls_IncidentTab_IncidentTab.Tab.Event);
    }

    /// <summary>
    /// Save Button Click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSave_Click(object sender, EventArgs e)
    {
        SaveRecord();
        ClearControl();

        if (StrOperation.ToLower() == "add" || StrOperation.ToLower() == "addto" || StrOperation.ToLower() == "")
        {
            Response.Redirect("Event_New.aspx?eid=" + Encryption.Encrypt(PK_Event.ToString()) + "&iid=" + Encryption.Encrypt(FK_Incident.ToString()) + "&mode=edit&pnl=" + hdnPanel.Value, true);
        }
        else
        {
            StrOperation = "edit";
            BindDetailsForEdit();
            // set user control values
            //ucIncidentInfo.FillIncidentInformation(FK_Incident, PK_Event, 0);
            ucEventInfo.FillEventInformation(PK_Event);
        }
        Page.ClientScript.RegisterStartupScript(typeof(string), DateTime.Now.ToString(), "javascript:ShowPanel(" + hdnPanel.Value + ");", true);
    }

    /// <summary>
    /// Add Event Camera Click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkAddEvent_CameraNew_Click(object sender, EventArgs e)
    {
        _PK_Event_Camera = 0;
        trEvent_CameraGrid.Style.Add("display", "none");
        trEvent_Camera.Style.Add("display", "");
        btnEvent_CameraCancel.Style.Add("display", "inline");
        txtCamera_Name.Text = string.Empty;
        txtCamera_Number.Text = string.Empty;
        txtEvent_Time_From.Text = string.Empty;
        txtEvent_Time_To.Text = string.Empty;
    }

    /// <summary>
    /// Save ACI Notes
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnEvent_CameraAdd_Click(object sender, EventArgs e)
    {
        SaveRecord();

        clsEvent_Camera objEvent_Camera = new clsEvent_Camera();
        objEvent_Camera.PK_Event_Camera = _PK_Event_Camera;
        objEvent_Camera.FK_Event = PK_Event;
        objEvent_Camera.Camera_Name = txtCamera_Name.Text.Trim();
        objEvent_Camera.Camera_Number = txtCamera_Number.Text.Trim();
        objEvent_Camera.Event_Time_From = txtEvent_Time_From.Text.Trim();
        objEvent_Camera.Event_Time_To = txtEvent_Time_To.Text.Trim();

        if (_PK_Event_Camera > 0)
        {
            objEvent_Camera.Update();
        }
        else
        {
            objEvent_Camera.Insert();
        }

        //clear Control
        ClearEvent_CameraControls();
        //Bind Grid Function
        BindEvent_CameraGrid();
        //Cancel CLick
        btnEvent_CameraCancel_Click(null, null);
    }

    /// <summary>
    /// Cancel Event Camera link
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnEvent_CameraCancel_Click(object sender, EventArgs e)
    {
        trEvent_CameraGrid.Style.Add("display", "");
        trEvent_Camera.Style.Add("display", "none");
        btnEvent_CameraCancel.Style.Add("display", "none");
        txtCamera_Name.Text = string.Empty;
        txtCamera_Number.Text = string.Empty;
        txtEvent_Time_From.Text = string.Empty;
        txtEvent_Time_To.Text = string.Empty;
    }

    /// <summary>
    /// Add ACI Notes Click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkAddACINotesNew_Click(object sender, EventArgs e)
    {
        _PK_ACI_Notes = 0;
        trACINotesGrid.Style.Add("display", "none");
        trACINotes.Style.Add("display", "");
        btnACINotesCancel.Style.Add("display", "inline");
        //txtACI_Notes_Date.Text = string.Empty;
        txtACI_Notes.Text = string.Empty;
        //((ScriptManager)this.Master.FindControl("scMain")).SetFocus(txtACI_Notes_Date);
    }

    /// <summary>
    /// Save ACI Notes
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnACINotesAdd_Click(object sender, EventArgs e)
    {
        SaveRecord();

        clsACI_Event_Notes objACI_Notes = new clsACI_Event_Notes();

        objACI_Notes.PK_ACI_Event_Notes = _PK_ACI_Notes;
        //objACI_Notes.Note_Date = clsGeneral.FormatNullDateToStore(txtACI_Notes_Date.Text);
        objACI_Notes.Note = txtACI_Notes.Text.Trim();
        objACI_Notes.FK_Event = PK_Event;

        if (_PK_ACI_Notes > 0)
        {
            objACI_Notes.Update();
        }
        else
        {
            objACI_Notes.Insert();
        }

        //clear Control
        ClearACINoteControls();
        //Bind Grid Function
        BindACINoteGrid();
        //Cancel CLick
        btnACINotesCancel_Click(null, null);
    }

    /// <summary>
    /// Cancel ACI Notes link
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnACINotesCancel_Click(object sender, EventArgs e)
    {
        trACINotesGrid.Style.Add("display", "");
        trACINotes.Style.Add("display", "none");
        btnACINotesCancel.Style.Add("display", "none");
        //txtACI_Notes_Date.Text = string.Empty;
        txtACI_Notes.Text = string.Empty;
    }

    /// <summary>
    /// Add Event Camera Click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkAddEvent_CameraNew_Sonic_Click(object sender, EventArgs e)
    {
        _PK_Event_Camera_Sonic = 0;
        trEvent_CameraGrid_Sonic.Style.Add("display", "none");
        trEvent_Camera_Sonic.Style.Add("display", "");
        btnEvent_CameraSonicCancel.Style.Add("display", "inline");
        txtCamera_Name_Sonic.Text = string.Empty;
        txtCamera_Number_Sonic.Text = string.Empty;
        txtEvent_Time_From_Sonic.Text = string.Empty;
        txtEvent_Time_To_Sonic.Text = string.Empty;
    }

    /// <summary>
    /// Save ACI Notes
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnEvent_CameraAdd_Sonic_Click(object sender, EventArgs e)
    {
        SaveRecord();

        clsEvent_Camera objEvent_Camera = new clsEvent_Camera();
        objEvent_Camera.PK_Event_Camera = _PK_Event_Camera_Sonic;
        objEvent_Camera.FK_Event = PK_Event;
        objEvent_Camera.Camera_Name = txtCamera_Name_Sonic.Text.Trim();
        objEvent_Camera.Camera_Number = txtCamera_Number_Sonic.Text.Trim();
        objEvent_Camera.Event_Time_From = txtEvent_Time_From_Sonic.Text.Trim();
        objEvent_Camera.Event_Time_To = txtEvent_Time_To_Sonic.Text.Trim();

        if (_PK_Event_Camera_Sonic > 0)
        {
            objEvent_Camera.Update();
        }
        else
        {
            objEvent_Camera.Insert();
        }

        //clear Control
        ClearEvent_Camera_SonicControls();
        //Bind Grid Function
        BindEvent_Camera_SonicGrid();
        //Cancel CLick
        btnEvent_CameraSonicCancel_Click(null, null);
    }

    /// <summary>
    /// Cancel Event Camera link
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnEvent_CameraSonicCancel_Click(object sender, EventArgs e)
    {
        trEvent_CameraGrid_Sonic.Style.Add("display", "");
        trEvent_Camera_Sonic.Style.Add("display", "none");
        btnEvent_CameraSonicCancel.Style.Add("display", "none");
        txtCamera_Name_Sonic.Text = string.Empty;
        txtCamera_Number_Sonic.Text = string.Empty;
        txtEvent_Time_From_Sonic.Text = string.Empty;
        txtEvent_Time_To_Sonic.Text = string.Empty;
    }

    /// <summary>
    /// Add Sonic Notes Click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkAddSonicNotesNew_Click(object sender, EventArgs e)
    {
        _PK_Sonic_Notes = 0;
        trSonicNotesGrid.Style.Add("display", "none");
        trSonicNotes.Style.Add("display", "");
        btnSonicNotesCancel.Style.Add("display", "inline");
        //txtACI_Notes_Date.Text = string.Empty;
        txtSonic_Notes.Text = string.Empty;
        //((ScriptManager)this.Master.FindControl("scMain")).SetFocus(txtACI_Notes_Date);
    }

    /// <summary>
    /// Save Sonic Notes
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSonicNotesAdd_Click(object sender, EventArgs e)
    {
        SaveRecord();

        clsSonic_Event_Notes objSonic_Notes = new clsSonic_Event_Notes();

        objSonic_Notes.PK_Sonic_Event_Notes = _PK_Sonic_Notes;
        //objACI_Notes.Note_Date = clsGeneral.FormatNullDateToStore(txtACI_Notes_Date.Text);
        objSonic_Notes.Note = txtSonic_Notes.Text.Trim();
        objSonic_Notes.FK_Event = PK_Event;
        objSonic_Notes.Updated_by = Convert.ToDecimal(clsSession.UserID);

        if (_PK_Sonic_Notes > 0)
        {
            objSonic_Notes.Update();
        }
        else
        {
            objSonic_Notes.Insert();
        }

        //clear Control
        ClearSonicNoteControls();
        //Bind Grid Function
        BindSonicNoteGrid();
        //Cancel CLick
        btnSonicNotesCancel_Click(null, null);
    }

    /// <summary>
    /// Cancel Sonic Notes link
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSonicNotesCancel_Click(object sender, EventArgs e)
    {
        trSonicNotesGrid.Style.Add("display", "");
        trSonicNotes.Style.Add("display", "none");
        btnSonicNotesCancel.Style.Add("display", "none");
        //txtACI_Notes_Date.Text = string.Empty;
        txtSonic_Notes.Text = string.Empty;
    }

    /// <summary>
    /// Edit Button Click Event On View Mode
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("Event.aspx?iid=" + Encryption.Encrypt(FK_Incident.ToString()) + "&eid=" + Encryption.Encrypt(PK_Event.ToString()) + "&mode=edit&pnl=" + hdnPanel.Value);
    }

    /// <summary>
    /// Event Call when user press Next Step Button
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnNextStep_Click(object sender, EventArgs e)
    {
        if (StrOperation.ToLower() == "view")
        {
            Response.Redirect("../Alarm/Alarm_Initial.aspx?iid=" + Encryption.Encrypt(FK_Incident.ToString()) + "&eid=" + Encryption.Encrypt(PK_Event.ToString()) + "&mode=" + StrOperation);
        }
        else
        {
            SaveRecord();
            if (StrOperation.ToLower() == "add") StrOperation = "edit";
            Response.Redirect("../Alarm/Alarm_Initial.aspx?iid=" + Encryption.Encrypt(FK_Incident.ToString()) + "&eid=" + Encryption.Encrypt(PK_Event.ToString()) + "&mode=" + StrOperation);
        }
    }

    /// <summary>
    /// Event Called When User change Tab
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSaveHidden_Click(object sender, EventArgs e)
    {
        //SaveRecord();
        //if (PK_Event > 0)
        //{
        //    ucIncident.MoveToTab(FK_Incident, PK_Event, 0);
        //}
        //else
        //{

        //}
    }

    /// <summary>
    /// Event Called When User change Tab
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnPreviousStep_Click(object sender, EventArgs e)
    {
        Response.Redirect("Event_Initial.aspx?iid=" + Encryption.Encrypt(FK_Incident.ToString()) + "&mode=" + StrOperation, true);
    }

    #endregion

    #region Page Methods

    /// Used to Clear the controls
    /// </summary>
    private void ClearEvent_CameraControls()
    {
        //clear control
        _PK_Event_Camera = 0;
        txtCamera_Name.Text = string.Empty;
        txtCamera_Number.Text = string.Empty;
        txtEvent_Time_From.Text = string.Empty;
        txtEvent_Time_To.Text = string.Empty;
    }

    /// Used to Clear the controls
    /// </summary>
    private void ClearACINoteControls()
    {
        //clear control
        _PK_ACI_Notes = 0;
        txtACI_Notes.Text = string.Empty;
        //txtACI_Notes_Date.Text = string.Empty;
    }

    /// Used to Clear the controls
    /// </summary>
    private void ClearSonicNoteControls()
    {
        //clear control
        _PK_Sonic_Notes = 0;
        txtSonic_Notes.Text = string.Empty;
        //txtACI_Notes_Date.Text = string.Empty;
    }


    /// Used to Clear the controls
    /// </summary>
    private void ClearEvent_Camera_SonicControls()
    {
        //clear control
        _PK_Event_Camera_Sonic = 0;
        txtCamera_Name_Sonic.Text = string.Empty;
        txtCamera_Number_Sonic.Text = string.Empty;
        txtEvent_Time_From_Sonic.Text = string.Empty;
        txtEvent_Time_To_Sonic.Text = string.Empty;
    }

    /// <summary>
    /// Event Called When Page is open on Edit Mode
    /// </summary>
    private void BindDetailsForEdit()
    {
        dvEdit.Visible = true;

        btnSave.Visible = true;
        btnBack.Visible = false;
        ucAttachment.ReadOnly = false;
        SetEditViewRights();

        clsEvent objEvent = new clsEvent(PK_Event);

        Is_Sonic_Event = objEvent.Sonic_Event == "Y" ? true : false;

        clsGeneral.SetDropdownValue(ddlLocation, objEvent.FK_LU_Location, true);
        txtACI_EventID.Text = objEvent.ACI_EventID;
        txtEvent_Start_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objEvent.Event_Start_Date);
        txtInvestigator_Name.Text = objEvent.Investigator_Name;
        txtInvestigator_Email.Text = objEvent.Investigator_Email;
        txtInvestigator_Phone.Text = objEvent.Investigator_Phone;
        if (objEvent.Police_Called != null)
            rdoPolice_Called.SelectedValue = Convert.ToString(objEvent.Police_Called);
        txtAgency_name.Text = objEvent.Agency_name;
        txtOfficer_Name.Text = objEvent.Officer_Name;
        txtOfficer_Phone.Text = objEvent.Officer_Phone;
        txtPolice_Report_Number.Text = objEvent.Police_Report_Number;
        if (objEvent.Status != null)
            rdoStatus.SelectedValue = Convert.ToString(objEvent.Status);
        txtDate_Closed.Text = clsGeneral.FormatDBNullDateToDisplay(objEvent.Date_Closed);

        txtEvent_Start_Date_Sonic.Text = clsGeneral.FormatDBNullDateToDisplay(objEvent.Event_Start_Date);
        txtEvent_Number_Sonic.Text = objEvent.Event_Number;
        if (objEvent.Monitoring_Hours != null)
            rdoMonitoring_Hours_Sonic.SelectedValue = Convert.ToString(objEvent.Monitoring_Hours);
        txtSource_Of_Information.Text = objEvent.Source_Of_Information;

        if (objEvent.Police_Called != null)
            rdoPolice_Called_Sonic.SelectedValue = Convert.ToString(objEvent.Police_Called);
        txtAgency_name_Sonic.Text = objEvent.Agency_name;
        txtOfficer_Name_Sonic.Text = objEvent.Officer_Name;
        txtOfficer_Phone_Sonic.Text = objEvent.Officer_Phone;
        txtPolice_Report_Number_Sonic.Text = objEvent.Police_Report_Number;
        txtBadge_Number_Sonic.Text = objEvent.Badge_Number;

        txtSonic_Contact_Name.Text = objEvent.Sonic_Contact_Name;
        txtSonic_Contact_Phone.Text = objEvent.Sonic_Contact_Phone;
        txtSonic_Contact_Email.Text = objEvent.Sonic_Contact_Email;

        DataSet dsFR = clsEvent.GetFR_NumberByEvent(PK_Event);

        if (dsFR.Tables.Count > 0 && dsFR.Tables[0].Rows.Count > 0)
        {
            txtFK_AL_FR.Text = dsFR.Tables[0].Rows[0]["AL_FR_Number"].ToString();
            txtFK_DPD_FR.Text = dsFR.Tables[0].Rows[0]["DPD_FR_Number"].ToString();
            txtFK_PL_FR.Text = dsFR.Tables[0].Rows[0]["PL_FR_Number"].ToString();
            txtFK_Property_FR.Text = dsFR.Tables[0].Rows[0]["Prop_FR_Number"].ToString();
        }

        hdnFK_AL_FR.Value = Convert.ToString(objEvent.FK_AL_FR);
        hdnFK_DPD_FR.Value = Convert.ToString(objEvent.FK_DPD_FR);
        hdnFK_PL_FR.Value = Convert.ToString(objEvent.FK_PL_FR);
        hdnFK_Property_FR.Value = Convert.ToString(objEvent.FK_Property_FR);

        txtEvent_Root_Cause.Text = objEvent.Event_Root_Cause;
        txtHow_Event_Prevented.Text = objEvent.How_Event_Prevented;
        if (objEvent.Financial_Loss != null)
            txtFinancial_Loss.Text = clsGeneral.GetStringValue(objEvent.Financial_Loss);


        if (PK_Event > 0)
        {
            clsGeneral.SetDropdownValue(ddlLocation, objEvent.FK_LU_Location, true);

            DataSet dsEventType = clsEvent_Link_LU_Event_Type.SelectByFK_Event(PK_Event);

            if (dsEventType.Tables.Count > 0 && dsEventType.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow drEvent_Type in dsEventType.Tables[0].Rows)
                {
                    foreach (RepeaterItem rptEvent in rptEventType.Items)
                    {
                        Label lblType = (Label)rptEvent.FindControl("lblPK_LU_Event_Type");
                        if (!string.IsNullOrEmpty(lblType.Text) && lblType.Text == drEvent_Type["FK_LU_Event_Type"].ToString())
                        {
                            CheckBox chkEvent = (CheckBox)rptEvent.FindControl("chkEventType");
                            chkEvent.Checked = true;

                            TextBox txtDesc = (TextBox)rptEvent.FindControl("txtEventDesciption");
                            txtDesc.Text = drEvent_Type["Description"].ToString();
                        }
                    }
                }
            }

            BindEvent_CameraGrid();
            BindACINoteGrid();
            BindReapterInvest_Images();

            if (dsEventType.Tables.Count > 0 && dsEventType.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow drEvent_Type in dsEventType.Tables[0].Rows)
                {
                    foreach (RepeaterItem rptEvent in rptEventTypeSonic.Items)
                    {
                        Label lblType = (Label)rptEvent.FindControl("lblPK_LU_Event_TypeSonic");
                        if (!string.IsNullOrEmpty(lblType.Text) && lblType.Text == drEvent_Type["FK_LU_Event_Type"].ToString())
                        {
                            CheckBox chkEvent = (CheckBox)rptEvent.FindControl("chkEventTypeSonic");
                            chkEvent.Checked = true;

                            TextBox txtDesc = (TextBox)rptEvent.FindControl("txtEventDesciptionSonic");
                            txtDesc.Text = drEvent_Type["Description"].ToString();
                        }
                    }
                }
            }

            BindEvent_Camera_SonicGrid();
            BindSonicNoteGrid();

            lblLastModifiedDateTime.Text = objEvent.Update_Date == null ? "" : "Last Modified Date/Time : " + objEvent.Update_Date.Value.ToString("MM/dd/yyyy hh:mm:ss tt") + " ";
        }
    }

    /// <summary>
    /// Event Called When Page is open in View Mode
    /// </summary>
    private void BindDetailForView()
    {
        dvEdit.Visible = false;
        btnSave.Visible = false;
    }

    /// <summary>
    /// Bind Drop Down Items
    /// </summary>
    private void BindDropDownList()
    {
        ComboHelper.FillLocation(new DropDownList[] { ddlLocation }, true);
        BindReapterEventType();
        BindReapterEventTypeSonic();
        BindReapterInvest_Images();
    }

    /// <summary>
    /// Save Event Information In database
    /// </summary>
    private void SaveRecord()
    {
        clsEvent objEvent = new clsEvent();
        objEvent.PK_Event = PK_Event;
        if (ddlLocation.SelectedIndex > 0)
            objEvent.FK_LU_Location = Convert.ToDecimal(ddlLocation.SelectedValue);
        objEvent.ACI_EventID = Convert.ToString(txtACI_EventID.Text);

        objEvent.Sonic_Event = Is_Sonic_Event == true ? "Y" : "N";

        if (!Is_Sonic_Event)
        {
            objEvent.Event_Start_Date = clsGeneral.FormatNullDateToStore(txtEvent_Start_Date.Text);
            objEvent.Police_Called = rdoPolice_Called.SelectedValue;
            objEvent.Agency_name = Convert.ToString(txtAgency_name.Text);
            objEvent.Officer_Name = Convert.ToString(txtOfficer_Name.Text);
            objEvent.Officer_Phone = Convert.ToString(txtOfficer_Phone.Text);
            objEvent.Police_Report_Number = Convert.ToString(txtPolice_Report_Number.Text);
        }
        objEvent.Status = rdoStatus.SelectedValue;
        objEvent.Date_Closed = clsGeneral.FormatNullDateToStore(txtDate_Closed.Text);
        objEvent.Investigator_Name = Convert.ToString(txtInvestigator_Name.Text);
        objEvent.Investigator_Email = Convert.ToString(txtInvestigator_Email.Text);
        objEvent.Investigator_Phone = Convert.ToString(txtInvestigator_Phone.Text);

        if (Is_Sonic_Event)
        {
            objEvent.Event_Start_Date = clsGeneral.FormatNullDateToStore(txtEvent_Start_Date_Sonic.Text);
            objEvent.Police_Called = rdoPolice_Called_Sonic.SelectedValue;
            objEvent.Agency_name = Convert.ToString(txtAgency_name_Sonic.Text);
            objEvent.Officer_Name = Convert.ToString(txtOfficer_Name_Sonic.Text);
            objEvent.Officer_Phone = Convert.ToString(txtOfficer_Phone_Sonic.Text);
            objEvent.Police_Report_Number = Convert.ToString(txtPolice_Report_Number_Sonic.Text);
        }

        objEvent.Monitoring_Hours = rdoMonitoring_Hours_Sonic.SelectedValue;
        objEvent.Source_Of_Information = txtSource_Of_Information.Text;
        objEvent.Sonic_Contact_Name = txtSonic_Contact_Name.Text;
        objEvent.Sonic_Contact_Phone = txtSonic_Contact_Phone.Text;
        objEvent.Sonic_Contact_Email = txtSonic_Contact_Email.Text;
        objEvent.Badge_Number = Convert.ToString(txtBadge_Number_Sonic.Text);

        if (!string.IsNullOrEmpty(hdnFK_AL_FR.Value))
            objEvent.FK_AL_FR = Convert.ToDecimal(hdnFK_AL_FR.Value);
        if (!string.IsNullOrEmpty(hdnFK_DPD_FR.Value))
            objEvent.FK_DPD_FR = Convert.ToDecimal(hdnFK_DPD_FR.Value);
        if (!string.IsNullOrEmpty(hdnFK_PL_FR.Value))
            objEvent.FK_PL_FR = Convert.ToDecimal(hdnFK_PL_FR.Value);
        if (!string.IsNullOrEmpty(hdnFK_Property_FR.Value))
            objEvent.FK_Property_FR = Convert.ToDecimal(hdnFK_Property_FR.Value);

        objEvent.Event_Root_Cause = txtEvent_Root_Cause.Text;
        objEvent.How_Event_Prevented = txtHow_Event_Prevented.Text;
        if (txtFinancial_Loss.Text != string.Empty)
            objEvent.Financial_Loss = Convert.ToDecimal(txtFinancial_Loss.Text);

        objEvent.Update_Date = DateTime.Now;
        objEvent.Updated_By = clsSession.UserID;
        if (PK_Event > 0)
            objEvent.Update();
        else
            PK_Event = objEvent.Insert();

        #region "ACI Reported Event"


        if (!Is_Sonic_Event)
        {
            clsEvent_Link_LU_Event_Type.DeleteByFK_Event(PK_Event);

            foreach (RepeaterItem rpt in rptEventType.Items)
            {
                CheckBox chkEvent = (CheckBox)rpt.FindControl("chkEventType");
                if (chkEvent.Checked)
                {
                    clsEvent_Link_LU_Event_Type objEvent_Link_Event_Type = new clsEvent_Link_LU_Event_Type();
                    objEvent_Link_Event_Type.FK_Event = PK_Event;
                    Label lblType = (Label)rpt.FindControl("lblPK_LU_Event_Type");
                    if (!string.IsNullOrEmpty(lblType.Text))
                        objEvent_Link_Event_Type.FK_LU_Event_Type = Convert.ToDecimal(lblType.Text);

                    TextBox txtDesc = (TextBox)rpt.FindControl("txtEventDesciption");
                    if (!string.IsNullOrEmpty(txtDesc.Text))
                        objEvent_Link_Event_Type.Description = txtDesc.Text;

                    objEvent_Link_Event_Type.Insert();
                }
            }
        }

        #endregion

        #region "Sonic Reported Event"

        if (Is_Sonic_Event)
        {
            clsEvent_Link_LU_Event_Type.DeleteByFK_Event(PK_Event);
            foreach (RepeaterItem rpt in rptEventTypeSonic.Items)
            {
                CheckBox chkEvent = (CheckBox)rpt.FindControl("chkEventTypeSonic");
                if (chkEvent.Checked)
                {
                    clsEvent_Link_LU_Event_Type objEvent_Link_Event_Type = new clsEvent_Link_LU_Event_Type();
                    objEvent_Link_Event_Type.FK_Event = PK_Event;
                    Label lblType = (Label)rpt.FindControl("lblPK_LU_Event_TypeSonic");
                    if (!string.IsNullOrEmpty(lblType.Text))
                        objEvent_Link_Event_Type.FK_LU_Event_Type = Convert.ToDecimal(lblType.Text);

                    TextBox txtDesc = (TextBox)rpt.FindControl("txtEventDesciptionSonic");
                    if (!string.IsNullOrEmpty(txtDesc.Text))
                        objEvent_Link_Event_Type.Description = txtDesc.Text;

                    objEvent_Link_Event_Type.Insert();
                }
            }
        }

        #endregion
    }

    /// <summary>
    /// Update Company Contact Contact Detail
    /// </summary>
    /// <param name="strRole"></param>
    /// <param name="FK_CompanyContact"></param>
    private void UpdateContactDetails_CompanyContact(string strRole, string FK_CompanyContact)
    {
        // Update contact details by CliamId,pk_Contact,Role and use name // PK_Incident_shipment
        //Contact_Link.InsertUpdate_ClaimContactLink(PK_Event, "Event", Convert.ToDecimal(FK_CompanyContact), strRole, clsSession.UserName);
    }


    /// <summary>
    /// Bind Event Camera Grid
    /// </summary>
    private void BindEvent_CameraGrid()
    {
        DataSet dsEvent_Camera = clsEvent_Camera.SelectByFK_Event(PK_Event);

        if (dsEvent_Camera != null && dsEvent_Camera.Tables.Count > 0)
        {
            gvEvent_Camera.DataSource = dsEvent_Camera;
            gvEvent_Camera.DataBind();
        }
        else
        {
            gvEvent_Camera.DataSource = null;
            gvEvent_Camera.DataBind();
        }

    }

    /// <summary>
    /// Bind ACI Notes Grid
    /// </summary>
    private void BindACINoteGrid()
    {
        DataSet dsACI_Note = clsACI_Event_Notes.SelectByFK_Event(PK_Event);

        if (dsACI_Note != null && dsACI_Note.Tables.Count > 0)
        {
            gvACI_Notes.DataSource = dsACI_Note;
            gvACI_Notes.DataBind();
        }
        else
        {
            gvACI_Notes.DataSource = null;
            gvACI_Notes.DataBind();
        }
    }

    /// <summary>
    /// Bind Sonic Notes Grid
    /// </summary>
    private void BindSonicNoteGrid()
    {
        DataSet dsSonic_Note = clsSonic_Event_Notes.SelectByFK_Event(PK_Event);

        if (dsSonic_Note != null && dsSonic_Note.Tables.Count > 0)
        {
            gvSonic_Notes.DataSource = dsSonic_Note;
            gvSonic_Notes.DataBind();
        }
        else
        {
            gvSonic_Notes.DataSource = null;
            gvSonic_Notes.DataBind();
        }
    }

    /// <summary>
    /// Bind Event Camera Grid Sonic
    /// </summary>
    private void BindEvent_Camera_SonicGrid()
    {
        DataSet dsEvent_Camera = clsEvent_Camera.SelectByFK_Event(PK_Event);

        if (dsEvent_Camera != null && dsEvent_Camera.Tables.Count > 0)
        {
            gvEvent_Camera_Sonic.DataSource = dsEvent_Camera;
            gvEvent_Camera_Sonic.DataBind();
        }
        else
        {
            gvEvent_Camera_Sonic.DataSource = null;
            gvEvent_Camera_Sonic.DataBind();
        }

    }

    private void BindReapterEventType()
    {
        DataSet dsData = clsLU_Event_Type.SelectAll();
        dsData.Tables[0].DefaultView.RowFilter = "Active = 'Y'";

        rptEventType.DataSource = dsData.Tables[0].DefaultView.ToTable();
        rptEventType.DataBind();

    }

    private void BindReapterEventTypeSonic()
    {
        DataSet dsData = clsLU_Event_Type.SelectAll();
        dsData.Tables[0].DefaultView.RowFilter = "Active = 'Y'";

        rptEventTypeSonic.DataSource = dsData.Tables[0].DefaultView.ToTable();
        rptEventTypeSonic.DataBind();

    }

    private void BindReapterInvest_Images()
    {
        DataSet dsData = clsEvent.GetInvestigation_Images(PK_Event, "Event");

        rptInvest_Images.DataSource = dsData.Tables[0].DefaultView.ToTable();
        rptInvest_Images.DataBind();
    }

    private void ClearControl()
    {
        foreach (RepeaterItem rptEvent in rptEventType.Items)
        {
            CheckBox chkEvent = (CheckBox)rptEvent.FindControl("chkEventType");
            chkEvent.Checked = false;

            TextBox txtDesc = (TextBox)rptEvent.FindControl("txtEventDesciption");
            txtDesc.Text = string.Empty;
        }


        foreach (RepeaterItem rptEvent in rptEventTypeSonic.Items)
        {
            CheckBox chkEvent = (CheckBox)rptEvent.FindControl("chkEventTypeSonic");
            chkEvent.Checked = false;

            TextBox txtDesc = (TextBox)rptEvent.FindControl("txtEventDesciptionSonic");
            txtDesc.Text = string.Empty;
        }
    }

    protected void rptEventType_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            //DropDownList drpNoteType = (DropDownList)e.Item.FindControl("drpNoteType");
            //ComboHelper.FillAdjNoteType(new DropDownList[] { drpNoteType }, true);
        }
    }

    protected void rptInvestImages_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Image ImagesCol1 = e.Item.FindControl("imgInvest_Images1") as Image;

            if (!string.IsNullOrEmpty(ImagesCol1.ImageUrl) && File.Exists(AppConfig.DocumentsPath + "Attach\\" + ImagesCol1.ImageUrl))
            {
                ImagesCol1.ImageUrl = AppConfig.SiteURL + "Documents/Attach/" + ImagesCol1.ImageUrl;
            }
            else
            {
                ImagesCol1.Visible = false;
            }

            Image ImagesCol2 = e.Item.FindControl("imgInvest_Images2") as Image;

            if (!string.IsNullOrEmpty(ImagesCol2.ImageUrl) && File.Exists(AppConfig.DocumentsPath + "Attach\\" + ImagesCol2.ImageUrl))
            {
                ImagesCol2.ImageUrl = AppConfig.SiteURL + "Documents/Attach/" + ImagesCol2.ImageUrl;
            }
            else
            {
                ImagesCol2.Visible = false;
            }
        }
    }

    protected void rptEventTypeSonic_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            //DropDownList drpNoteType = (DropDownList)e.Item.FindControl("drpNoteType");
            //ComboHelper.FillAdjNoteType(new DropDownList[] { drpNoteType }, true);
        }
    }

    private void SetEditViewRights()
    {
        bool Is_Enable = false;

        ddlLocation.Enabled = Is_Enable;
        txtACI_EventID.Enabled = Is_Enable;
        foreach (RepeaterItem rpt in rptEventType.Items)
        {
            CheckBox chkEvent = (CheckBox)rpt.FindControl("chkEventType");
            chkEvent.Enabled = Is_Enable;

            TextBox txtDesc = (TextBox)rpt.FindControl("txtEventDesciption");
            txtDesc.Enabled = Is_Enable;
        }
        txtEvent_Start_Date.Enabled = Is_Enable;
        imgEvent_Start_Date.Visible = Is_Enable;
        lnkAddEvent_CameraNew.Visible = Is_Enable;
        txtInvestigator_Name.Enabled = Is_Enable;
        txtInvestigator_Email.Enabled = Is_Enable;
        txtInvestigator_Phone.Enabled = Is_Enable;
        

        rdoPolice_Called.Enabled = Is_Enable;
        txtAgency_name.Enabled = Is_Enable;
        txtOfficer_Name.Enabled = Is_Enable;
        txtOfficer_Phone.Enabled = Is_Enable;
        txtPolice_Report_Number.Enabled = Is_Enable;
        lnkAddACINotesNew.Visible = Is_Enable;
        //rdoStatus.Enabled = Is_Enable;
        //txtDate_Closed.Enabled = Is_Enable;
        //trStatus.Style["display"] = "none";
        //imgDate_Closed.Visible = Is_Enable;
        //imgEvent_Start_Date_Sonic.Visible = Is_Enable;

        //txtEvent_Start_Date_Sonic.Enabled = Is_Enable;
        //rdoMonitoring_Hours_Sonic.Enabled = Is_Enable;
        //txtSource_Of_Information.Enabled = Is_Enable;
        //foreach (RepeaterItem rpt in rptEventTypeSonic.Items)
        //{
        //    CheckBox chkEvent = (CheckBox)rpt.FindControl("chkEventTypeSonic");
        //    chkEvent.Enabled = Is_Enable;

        //    TextBox txtDesc = (TextBox)rpt.FindControl("txtEventDesciptionSonic");
        //    txtDesc.Enabled = Is_Enable;
        //}

        //rdoPolice_Called_Sonic.Enabled = Is_Enable;
        //txtAgency_name_Sonic.Enabled = Is_Enable;
        //txtOfficer_Name_Sonic.Enabled = Is_Enable;
        //txtPolice_Report_Number_Sonic.Enabled = Is_Enable;
        //txtOfficer_Phone_Sonic.Enabled = Is_Enable;
        //txtBadge_Number_Sonic.Enabled = Is_Enable;
        //txtSonic_Contact_Name.Enabled = Is_Enable;
        //txtSonic_Contact_Phone.Enabled = Is_Enable;
        //txtSonic_Contact_Email.Enabled = Is_Enable;
        //lnkAddEvent_CameraNew_Sonic.Visible = Is_Enable;
        //lnkAddSonicNotesNew.Visible = Is_Enable;


    }


    #endregion

    #region "Grid Events"

    /// <summary>
    /// gvEvent_Camera on Edit Or Delete
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvEvent_Camera_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "RemoveEventCamera")
        {
            #region
            clsEvent_Camera.DeleteByPK(Convert.ToDecimal(e.CommandArgument));

            BindEvent_CameraGrid();
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(1);", true);
            #endregion
        }
        else if (e.CommandName == "ViewEventCamera")
        {
            //Response.Redirect("Event_Note.aspx?nid=" + Encryption.Encrypt(e.CommandArgument.ToString()) + "&id=" + Encryption.Encrypt(PK_Event.ToString()) + "&iid=" + Encryption.Encrypt(FK_Incident.ToString()) + "&mode=" + StrOperation + "&type=ACI");

            Page.ClientScript.RegisterStartupScript(typeof(string), DateTime.Now.ToString(), "javascript:AciNotePopup('" + Encryption.Encrypt(e.CommandArgument.ToString()) + "','" + Encryption.Encrypt(PK_Event.ToString()) + "','" + Encryption.Encrypt(FK_Incident.ToString()) + "','" + StrOperation + "','ACI');", true);
        }
        else if (e.CommandName == "EditRecord")
        {
            _PK_Event_Camera = Convert.ToDecimal(e.CommandArgument);
            // show and hide Add-edit row
            trEvent_CameraGrid.Style.Add("display", "none");
            trEvent_Camera.Style.Add("display", "");
            btnEvent_CameraCancel.Style.Add("display", "inline");
            btnEvent_CameraAdd.Text = "Update";
            // get record from database

            clsEvent_Camera objEvent_Camera = new clsEvent_Camera(_PK_Event_Camera);
            txtCamera_Name.Text = objEvent_Camera.Camera_Name;
            txtCamera_Number.Text = objEvent_Camera.Camera_Number;
            txtEvent_Time_From.Text = objEvent_Camera.Event_Time_From;
            txtEvent_Time_To.Text = objEvent_Camera.Event_Time_To;
            ((ScriptManager)this.Master.FindControl("scMain")).SetFocus(txtCamera_Name);
        }
    }

    /// <summary>
    /// Paging event of gvEvent_Camera
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvEvent_Camera_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvEvent_Camera.PageIndex = e.NewPageIndex; //Page new index call
        BindEvent_CameraGrid();
        Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(1);", true);
    }

    /// <summary>
    /// gvEvent_Camera_sonic on Edit Or Delete
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvEvent_Camera_Sonic_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "RemoveEventCamera")
        {
            #region
            clsEvent_Camera.DeleteByPK(Convert.ToDecimal(e.CommandArgument));

            BindEvent_Camera_SonicGrid();
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(3);", true);
            #endregion
        }
        else if (e.CommandName == "ViewEventCamera")
        {
            //Response.Redirect("Event_Note.aspx?nid=" + Encryption.Encrypt(e.CommandArgument.ToString()) + "&id=" + Encryption.Encrypt(PK_Event.ToString()) + "&iid=" + Encryption.Encrypt(FK_Incident.ToString()) + "&mode=" + StrOperation + "&type=ACI");

            Page.ClientScript.RegisterStartupScript(typeof(string), DateTime.Now.ToString(), "javascript:AciNotePopup('" + Encryption.Encrypt(e.CommandArgument.ToString()) + "','" + Encryption.Encrypt(PK_Event.ToString()) + "','" + Encryption.Encrypt(FK_Incident.ToString()) + "','" + StrOperation + "','ACI');", true);
        }
        else if (e.CommandName == "EditRecord")
        {
            _PK_Event_Camera_Sonic = Convert.ToDecimal(e.CommandArgument);
            // show and hide Add-edit row
            trEvent_Camera_Sonic.Style.Add("display", "none");
            trEvent_Camera_Sonic.Style.Add("display", "");
            btnEvent_CameraSonicCancel.Style.Add("display", "inline");
            btnEvent_CameraAdd_Sonic.Text = "Update";
            // get record from database

            clsEvent_Camera objEvent_Camera = new clsEvent_Camera(_PK_Event_Camera_Sonic);
            txtCamera_Name_Sonic.Text = objEvent_Camera.Camera_Name;
            txtCamera_Number_Sonic.Text = objEvent_Camera.Camera_Number;
            txtEvent_Time_From_Sonic.Text = objEvent_Camera.Event_Time_From;
            txtEvent_Time_To_Sonic.Text = objEvent_Camera.Event_Time_To;
        }
    }

    /// <summary>
    /// Paging event of gvEvent_Camera
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvEvent_Camera_Sonic_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvEvent_Camera_Sonic.PageIndex = e.NewPageIndex; //Page new index call
        BindEvent_Camera_SonicGrid();
        Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(3);", true);
    }

    /// <summary>
    /// gvACI_Notes on Edit Or Delete
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvACI_Notes_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "RemoveACINote")
        {
            #region
            clsACI_Event_Notes.DeleteByPK(Convert.ToDecimal(e.CommandArgument));

            BindACINoteGrid();
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(1);", true);
            #endregion
        }
        else if (e.CommandName == "ViewNote")
        {
            //Response.Redirect("Event_Note.aspx?nid=" + Encryption.Encrypt(e.CommandArgument.ToString()) + "&id=" + Encryption.Encrypt(PK_Event.ToString()) + "&iid=" + Encryption.Encrypt(FK_Incident.ToString()) + "&mode=" + StrOperation + "&type=ACI");

            Page.ClientScript.RegisterStartupScript(typeof(string), DateTime.Now.ToString(), "javascript:AciNotePopup('" + Encryption.Encrypt(e.CommandArgument.ToString()) + "','" + Encryption.Encrypt(PK_Event.ToString()) + "','" + Encryption.Encrypt(FK_Incident.ToString()) + "','" + StrOperation + "','ACI');", true);
        }
        else if (e.CommandName == "EditRecord")
        {
            _PK_ACI_Notes = Convert.ToDecimal(e.CommandArgument);
            // show and hide Add-edit row
            trACINotesGrid.Style.Add("display", "none");
            trACINotes.Style.Add("display", "");
            btnACINotesCancel.Style.Add("display", "inline");
            btnACINotesAdd.Text = "Update";
            // get record from database

            clsACI_Event_Notes objACI_Event_Notes = new clsACI_Event_Notes(_PK_ACI_Notes);

            //txtACI_Notes_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objACI_Event_Notes.Note_Date);
            txtACI_Notes.Text = Convert.ToString(objACI_Event_Notes.Note);
            //((ScriptManager)this.Master.FindControl("scMain")).SetFocus(//txtACI_Notes_Date);
        }
    }

    /// <summary>
    /// Paging event of gvACI_Notes
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvACI_Notes_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvACI_Notes.PageIndex = e.NewPageIndex; //Page new index call
        BindACINoteGrid();
        Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(2);", true);
    }

    /// <summary>
    /// gvSonic_Notes on Edit Or Delete
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvSonic_Notes_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "RemoveACINote")
        {
            #region
            clsSonic_Event_Notes.DeleteByPK(Convert.ToDecimal(e.CommandArgument));

            BindSonicNoteGrid();
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(3);", true);
            #endregion
        }
        else if (e.CommandName == "ViewNote")
        {
            //Response.Redirect("Event_Note.aspx?nid=" + Encryption.Encrypt(e.CommandArgument.ToString()) + "&id=" + Encryption.Encrypt(PK_Event.ToString()) + "&iid=" + Encryption.Encrypt(FK_Incident.ToString()) + "&mode=" + StrOperation + "&type=ACI");

            Page.ClientScript.RegisterStartupScript(typeof(string), DateTime.Now.ToString(), "javascript:AciNotePopup('" + Encryption.Encrypt(e.CommandArgument.ToString()) + "','" + Encryption.Encrypt(PK_Event.ToString()) + "','" + Encryption.Encrypt(FK_Incident.ToString()) + "','" + StrOperation + "','SONIC');", true);
        }
        else if (e.CommandName == "EditRecord")
        {
            _PK_Sonic_Notes = Convert.ToDecimal(e.CommandArgument);
            // show and hide Add-edit row
            trSonicNotesGrid.Style.Add("display", "none");
            trSonicNotes.Style.Add("display", "");
            btnSonicNotesCancel.Style.Add("display", "inline");
            btnSonicNotesAdd.Text = "Update";
            // get record from database

            clsSonic_Event_Notes objSonic_Event_Notes = new clsSonic_Event_Notes(_PK_Sonic_Notes);

            //txtACI_Notes_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objACI_Event_Notes.Note_Date);
            txtSonic_Notes.Text = Convert.ToString(objSonic_Event_Notes.Note);
            //((ScriptManager)this.Master.FindControl("scMain")).SetFocus(txtSonic_Notes);
        }
    }

    /// <summary>
    /// Paging event of gvACI_Notes
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvSonic_Notes_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvSonic_Notes.PageIndex = e.NewPageIndex; //Page new index call
        BindSonicNoteGrid();
        Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(3);", true);
    }

    #endregion

}