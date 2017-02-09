using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERIMS.DAL;
using System.Data;
using System.IO;
using System.Web.UI.HtmlControls;
using System.Text;
using Aspose.Words;

public partial class Event_Event_New : clsBasePage
{
    public string _strAttachmentName = string.Empty;
    public string _strEvent_Number= string.Empty;

    #region Properties

    /// <summary>
    /// Denotes Sort Field to sort all records by
    /// </summary>
    private string SortBy
    {
        get { return (!clsGeneral.IsNull(ViewState["SortBy"]) ? ViewState["SortBy"].ToString() : string.Empty); }
        set { ViewState["SortBy"] = value; }
    }

    /// <summary>
    /// Denotes ascending or descending order
    /// </summary>
    private string SortOrder
    {
        get { return (!clsGeneral.IsNull(ViewState["SortOrder"]) ? ViewState["SortOrder"].ToString() : string.Empty); }
        set { ViewState["SortOrder"] = value; }
    }

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
    public decimal _PK_Vehicle_Information
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_Vehicle_Information"]);
        }
        set { ViewState["PK_Vehicle_Information"] = value; }
    }

    /// <summary>
    /// Denotes the Primary Key
    /// </summary>
    public decimal _PK_Suspect_Information
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_Suspect_Information"]);
        }
        set { ViewState["PK_Suspect_Information"] = value; }
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
    /// Denotes Closed Event
    /// </summary>
    public bool Is_Closed_Event
    {
        get
        {
            return Convert.ToBoolean(ViewState["Is_Closed_Event"]);
        }
        set { ViewState["Is_Closed_Event"] = value; }
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
                if (StrOperation.ToLower() == "viewonly")
                {
                    BindDropDownList();
                    BindDetailsForEdit();
                    //BindDetailForView();
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

                if (Is_Sonic_Event)
                {
                    if (Request.QueryString["Notes"] == null)
                        hdnPanel.Value = "3";

                    lblMenu2.Text = lblMenu2Header.Text = "Sonic Notes";
                    revtxtOfficer_Phone.ErrorMessage = "[Sonic Notes] / Please Enter Agency Phone # in XXX-XXX-XXXX format";
                    revtxtDate_Closed.ErrorMessage = "[Sonic Notes] /Date Closed is not a valid date";
                    cmptxtDate_Closed.ErrorMessage = "[Sonic Notes] /Date Closed should not be greater than current date";
                }
                else
                {
                    lblMenu2.Text = lblMenu2Header.Text = "Acadian Investigations";
                }

                ucAbstractLetter.FK_Event = PK_Event;
            }
            else
            {
                //if (App_Access == AccessType.View)
                //    Response.Redirect(AppConfig.SiteURL + "Error.aspx?msg=errAcc");
                //else if (FK_Incident < 1)
                //    Response.Redirect(AppConfig.SiteURL + "Error.aspx?msg=errAcc"); //Redirect To the Incident Selection page
                //ucIncidentInfo.Visible = false;
                //ucIncidentInfo.FillIncidentInformation(FK_Incident, 0, 0);
                SetEditViewRights(false);
                ucEventInfo.Visible = false;
                ucEventInfo.FillEventInformation(PK_Event);

                PK_Event = 0;
                StrOperation = "add"; btnViewAudit.Visible = false;
                btnBack.Visible = false;
                BindDropDownList();
                ucAttachment.ReadOnly = false;
                BindGridBuilding();

                if (Is_Sonic_Event)
                {
                    if (Request.QueryString["Notes"] == null)
                        hdnPanel.Value = "3";

                    lblMenu2.Text = lblMenu2Header.Text = "Sonic Notes";
                    revtxtOfficer_Phone.ErrorMessage = "[Sonic Notes] / Please Enter Agency Phone # in XXX-XXX-XXXX format";
                    revtxtDate_Closed.ErrorMessage = "[Sonic Notes] /Date Closed is not a valid date";
                    cmptxtDate_Closed.ErrorMessage = "[Sonic Notes] /Date Closed should not be greater than current date";
                }

                BindACINoteGrid(ctrlPageAcadianNotes.CurrentPage, ctrlPageAcadianNotes.PageSize);
                BindSonicNoteGrid(ctrlPageSonicNotes.CurrentPage, ctrlPageSonicNotes.PageSize);
            }
        }
        else
        {
            string eventTarget = (this.Request["__EVENTTARGET"] == null) ? string.Empty : this.Request["__EVENTTARGET"];
            string eventArgument = (this.Request["__EVENTARGUMENT"] == null) ? string.Empty : this.Request["__EVENTARGUMENT"];

            // if postback by Confirmation dialog then save record
            if (eventTarget == "UserConfirmationPostBack")
            {
                if (eventArgument == "true")
                    SaveRecord();
            }
        }
        if (StrOperation == "add") hdnPanel.Value = "3"; //for Add new click set tab style
        Page.ClientScript.RegisterStartupScript(typeof(string), DateTime.Now.ToString(), "javascript:ShowPanel(" + hdnPanel.Value + ");", true);
        ucIncident.SetSelectedTab(Controls_IncidentTab_IncidentTab.Tab.Event);
    }
    #endregion

    #region Events

    /// <summary>
    /// Save Button Click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSave_Click(object sender, EventArgs e)
    {
        ViewState.Remove("EmailAbsratact");

        SaveRecord();

        //if (ViewState["EmailAbsratact"] != null)
        //{
        //    SendAbstractViaEmailWhileInsert();
        //}

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
    /// Send Notification
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSend_Notification_Click(object sender, EventArgs e)
    {
        SaveRecord();
        SendAbstractViaEmailWhileInsert();

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
    //protected void lnkAddEvent_CameraNew_Click(object sender, EventArgs e)
    //{
    //    _PK_Event_Camera = 0;
    //    trEvent_CameraGrid.Style.Add("display", "none");
    //    trEvent_Camera.Style.Add("display", "");
    //    btnEvent_CameraCancel.Style.Add("display", "inline");
    //    btnEvent_CameraAdd.Text = "Add";
    //    txtCamera_Name.Text = string.Empty;
    //    txtCamera_Number.Text = string.Empty;
    //    txtEvent_Time_From.Text = string.Empty;
    //    txtEvent_Time_To.Text = string.Empty;
    //}

    /// <summary>
    /// Save ACI Notes
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    //protected void btnEvent_CameraAdd_Click(object sender, EventArgs e)
    //{
    //    SaveRecord();

    //    clsEvent_Camera objEvent_Camera = new clsEvent_Camera();
    //    objEvent_Camera.PK_Event_Camera = _PK_Event_Camera;
    //    objEvent_Camera.FK_Event = PK_Event;
    //    objEvent_Camera.Camera_Name = txtCamera_Name.Text.Trim();
    //    objEvent_Camera.Camera_Number = txtCamera_Number.Text.Trim();
    //    objEvent_Camera.Event_Time_From = txtEvent_Time_From.Text.Trim();
    //    objEvent_Camera.Event_Time_To = txtEvent_Time_To.Text.Trim();

    //    if (_PK_Event_Camera > 0)
    //    {
    //        objEvent_Camera.Update();
    //    }
    //    else
    //    {
    //        objEvent_Camera.Insert();
    //    }

    //    //clear Control
    //    ClearEvent_CameraControls();
    //    //Bind Grid Function
    //    BindEvent_CameraGrid();
    //    //Cancel CLick
    //    btnEvent_CameraCancel_Click(null, null);
    //}

    /// <summary>
    /// Cancel Event Camera link
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    //protected void btnEvent_CameraCancel_Click(object sender, EventArgs e)
    //{
    //    trEvent_CameraGrid.Style.Add("display", "");
    //    trEvent_Camera.Style.Add("display", "none");
    //    btnEvent_CameraCancel.Style.Add("display", "none");
    //    txtCamera_Name.Text = string.Empty;
    //    txtCamera_Number.Text = string.Empty;
    //    txtEvent_Time_From.Text = string.Empty;
    //    txtEvent_Time_To.Text = string.Empty;
    //}

    /// <summary>
    /// Add Vehicle Click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkAddVehicleInfo_Click(object sender, EventArgs e)
    {
        _PK_Vehicle_Information = 0;
        ComboHelper.FillState(new DropDownList[] { ddlVehicle_InfoState }, 0, true);
        trACIVehicle_InformationGrid.Style.Add("display", "none");
        trACIVehicle_Information.Style.Add("display", "");
        btnVehicle_Info.Style.Add("display", "inline");
        btnVehicle_InfoAdd.Text = "Add";
        txtMake.Text = txtModel.Text = txtLicense.Text = txtColor.Text = string.Empty;
        ddlVehicle_InfoState.SelectedIndex = 0;
        rdoSuspect_Vehicle.SelectedValue = "N";
    }

    /// <summary>
    /// Add Suspect Click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkAddSuspectInfo_Click(object sender, EventArgs e)
    {
        _PK_Suspect_Information = 0;
        trACISuspect_InformationGrid.Style.Add("display", "none");
        trACISuspect_Information.Style.Add("display", "");
        btnSuspect_InfoCancel.Style.Add("display", "inline");
        btnSuspect_InfoAdd.Text = "Add";
        txtSuspect_Information_Note.Text = string.Empty;
        rdoSex.SelectedValue = "F";
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
        btnACINotesAdd.Text = "Add";
        //((ScriptManager)this.Master.FindControl("scMain")).SetFocus(txtACI_Notes_Date);
    }

    /// <summary>
    /// Save Vehicle Information
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnVehicle_InfoAdd_Click(object sender, EventArgs e)
    {
        SaveRecord();

        clsVehicle_Information objVehicleInformation = new clsVehicle_Information();
        objVehicleInformation.PK_Vehicle_Information = _PK_Vehicle_Information;
        objVehicleInformation.FK_Event = PK_Event;
        objVehicleInformation.Make = txtMake.Text.Trim();
        objVehicleInformation.Model = txtModel.Text.Trim();
        objVehicleInformation.License = txtLicense.Text.Trim();
        objVehicleInformation.Color = txtColor.Text.Trim();
        if (ddlVehicle_InfoState.SelectedIndex > 0)
            objVehicleInformation.FK_LU_State = Convert.ToDecimal(ddlVehicle_InfoState.SelectedValue);
        objVehicleInformation.Suspect_Vehicle = rdoSuspect_Vehicle.SelectedValue;

        if (_PK_Vehicle_Information > 0)
        {
            objVehicleInformation.Update();
        }
        else
        {
            objVehicleInformation.Insert();
        }

        BindVehicle_InformationGrid();
        btnVehicle_InfoCancel_Click(null, null);
    }

    /// <summary>
    /// Cancel Vehicle Information link
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnVehicle_InfoCancel_Click(object sender, EventArgs e)
    {
        trACIVehicle_InformationGrid.Style.Add("display", "");
        trACIVehicle_Information.Style.Add("display", "none");
        btnVehicle_Info.Style.Add("display", "none");
        txtMake.Text = txtColor.Text = txtModel.Text = txtLicense.Text = string.Empty;
        ddlVehicle_InfoState.SelectedIndex = 0;
        rdoSuspect_Vehicle.SelectedValue = "N";

    }

    /// <summary>
    /// Save Vehicle Information
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSuspect_InfoAdd_Click(object sender, EventArgs e)
    {
        SaveRecord();

        clsSuspect_Information objSuspectInformation = new clsSuspect_Information();
        objSuspectInformation.PK_Suspect_Information = _PK_Suspect_Information;
        objSuspectInformation.FK_Event = PK_Event;
        objSuspectInformation.Description = txtSuspect_Information_Note.Text.Trim();
        objSuspectInformation.Sex = rdoSex.SelectedValue;

        if (_PK_Suspect_Information > 0)
        {
            objSuspectInformation.Update();
        }
        else
        {
            objSuspectInformation.Insert();
        }

        BindSuspect_InformationGrid();
        btnSuspect_InfoCancel_Click(null, null);
    }

    /// <summary>
    /// Cancel Suspect Information link
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSuspect_InfoCancel_Click(object sender, EventArgs e)
    {
        trACISuspect_InformationGrid.Style.Add("display", "");
        trACISuspect_Information.Style.Add("display", "none");
        btnSuspect_InfoCancel.Style.Add("display", "none");
        txtSuspect_Information_Note.Text = string.Empty;
        rdoSex.SelectedValue = "F";

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
        BindACINoteGrid(ctrlPageAcadianNotes.CurrentPage, ctrlPageAcadianNotes.PageSize);
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
        btnEvent_CameraAdd_Sonic.Text = "Add";
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
        btnSonicNotesAdd.Text = "Add";
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
        BindSonicNoteGrid(1, 1000);
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

    protected void btnhdnReload_Click(object sender, EventArgs e)
    {
        BindGridBuilding();
        Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(" + hdnPanel.Value + ");", true);
    }

    /// <summary>
    /// Print ACI Notes
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnPrint_Click(object sender, EventArgs e)
    {
        string strSelected = "";
        foreach (GridViewRow gRow in gvACI_Notes.Rows)
        {
            if (((CheckBox)gRow.FindControl("chkSelectSonicNotes")).Checked)
                strSelected = strSelected + ((HtmlInputHidden)gRow.FindControl("hdnPK_ACI_Event_Notes")).Value + ",";
        }
        strSelected = strSelected.TrimEnd(',');
        clsPrintEventNotes.PrintSelectedNotes(strSelected, PK_Event, "ACI");
    }

    /// <summary>
    /// Print ACI Notes
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSonicPrint_Click(object sender, EventArgs e)
    {
        string strSelected = "";
        foreach (GridViewRow gRow in gvSonic_Notes.Rows)
        {
            if (((CheckBox)gRow.FindControl("chkSelectSonicACINotes")).Checked)
                strSelected = strSelected + ((HtmlInputHidden)gRow.FindControl("hdnPK_Sonic_Event_Notes")).Value + ",";
        }
        strSelected = strSelected.TrimEnd(',');
        clsPrintEventNotes.PrintSelectedNotes(strSelected, PK_Event, "Sonic");
    }


    protected void btnhdnNonactionable_Click(object sender, EventArgs e)
    {
        clsEvent.MakeNonActionable(PK_Event, Convert.ToDecimal(clsSession.UserID));

        Response.Redirect("EventSearch_New.aspx", true);
    }
    #endregion

    #region Page Methods



    /// Used to Clear the controls
    /// </summary>
    //private void ClearEvent_CameraControls()
    //{
    //    //clear control
    //    _PK_Event_Camera = 0;
    //    txtCamera_Name.Text = string.Empty;
    //    txtCamera_Number.Text = string.Empty;
    //    txtEvent_Time_From.Text = string.Empty;
    //    txtEvent_Time_To.Text = string.Empty;
    //}

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

        clsEvent objEvent = new clsEvent(PK_Event);

        Is_Sonic_Event = objEvent.Sonic_Event == "Y" ? true : false;

        clsGeneral.SetDropdownValue(ddlLocation, objEvent.FK_LU_Location, true);
        txtACI_EventID.Text = objEvent.ACI_EventID;
        txtEvent_Start_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objEvent.Event_Start_Date);
        txtEvent_Start_Time.Text = objEvent.Event_Start_Time;
        txtEvent_End_Time.Text = objEvent.Event_End_Time;
        //txtInvestigator_Name.Text = objEvent.Investigator_Name;
        //txtInvestigator_Email.Text = objEvent.Investigator_Email;
        //txtInvestigator_Phone.Text = objEvent.Investigator_Phone;

        #region Event Image
        string _strSiteURL;
        _strSiteURL = String.Concat(HttpContext.Current.Request.Url.Scheme + "://", HttpContext.Current.Request.Url.Authority, HttpContext.Current.Request.ApplicationPath);
        if (!_strSiteURL.EndsWith("/")) _strSiteURL = String.Concat(_strSiteURL, "/");


        //_strSiteURL = _strSiteURL.Replace("localhost", "192.168.0.118");
        string AttachmentDocPath = "Documents/EventImage";
        string DocPath = string.Concat(_strSiteURL, AttachmentDocPath) + "/";

        if (!string.IsNullOrEmpty(objEvent.Event_Image) && File.Exists(Server.MapPath("..\\") + AttachmentDocPath + "/" + objEvent.Event_Image))
        {
            ImgEvent_Image.Style["display"] = "";
            ImgEvent_Image.ImageUrl = Convert.ToString(AppConfig.SiteURL + AttachmentDocPath + "/" + objEvent.Event_Image);
            //ImgEvent_Image.ImageUrl = Convert.ToString(AppConfig.ImageURL + objEvent.Event_Image);
        }
        else
            ImgEvent_Image.Style["display"] = "none";

        #endregion



        if (objEvent.Police_Called != null)
            rdoPolice_Called.SelectedValue = Convert.ToString(objEvent.Police_Called);
        if (objEvent.Video_Requested_By_Sonic != null)
            rblVideoRequestedBySonic.SelectedValue = Convert.ToString(objEvent.Video_Requested_By_Sonic);
        txtAgency_name.Text = objEvent.Agency_name;
        txtOfficer_Name.Text = objEvent.Officer_Name;
        txtOfficer_Phone.Text = objEvent.Officer_Phone;
        txtPolice_Report_Number.Text = objEvent.Police_Report_Number;
        txtIncident_Report.Text = objEvent.Incident_Report_Desc;
        if (objEvent.Status != null)
            rdoStatus.SelectedValue = Convert.ToString(objEvent.Status);
        txtDate_Closed.Text = clsGeneral.FormatDBNullDateToDisplay(objEvent.Date_Closed);
        clsGeneral.SetDropdownValue(ddlFK_LU_Cause_Investigation, objEvent.FK_LU_Cause_Investigation, true);
        
        clsGeneral.SetDropdownValue(ddlLocation_Sonic, objEvent.FK_LU_Location, true);
        txtEvent_Start_Date_Sonic.Text = clsGeneral.FormatDBNullDateToDisplay(objEvent.Event_Start_Date);
        txtEvent_Start_Time_Sonic.Text = objEvent.Event_Start_Time;
        txtEvent_End_Time_Sonic.Text = objEvent.Event_End_Time;
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
            txtFK_AL_FR.Text = "";
            txtFK_DPD_FR.Text = "";
            txtFK_PL_FR.Text = "";
            txtFK_Property_FR.Text = "";

            if (!string.IsNullOrEmpty(dsFR.Tables[0].Rows[0]["AL_FR_Number"].ToString()))
                txtFK_AL_FR.Text = "AL-" + dsFR.Tables[0].Rows[0]["AL_FR_Number"].ToString();

            if (!string.IsNullOrEmpty(dsFR.Tables[0].Rows[0]["DPD_FR_Number"].ToString()))
                txtFK_DPD_FR.Text = "DPD-" + dsFR.Tables[0].Rows[0]["DPD_FR_Number"].ToString();

            if (!string.IsNullOrEmpty(dsFR.Tables[0].Rows[0]["PL_FR_Number"].ToString()))
                txtFK_PL_FR.Text = "PL-" + dsFR.Tables[0].Rows[0]["PL_FR_Number"].ToString();

            if (!string.IsNullOrEmpty(dsFR.Tables[0].Rows[0]["Prop_FR_Number"].ToString()))
                txtFK_Property_FR.Text = "Prop-" + dsFR.Tables[0].Rows[0]["Prop_FR_Number"].ToString();
        }

        hdnFK_AL_FR.Value = Convert.ToString(objEvent.FK_AL_FR);
        hdnFK_DPD_FR.Value = Convert.ToString(objEvent.FK_DPD_FR);
        hdnFK_PL_FR.Value = Convert.ToString(objEvent.FK_PL_FR);
        hdnFK_Property_FR.Value = Convert.ToString(objEvent.FK_Property_FR);

        txtEvent_Root_Cause.Text = objEvent.Event_Root_Cause;
        txtHow_Event_Prevented.Text = objEvent.How_Event_Prevented;
        if (objEvent.Financial_Loss != null)
            txtFinancial_Loss.Text = clsGeneral.GetStringValue(objEvent.Financial_Loss);


        
        if (StrOperation.ToLower() == "viewonly")
        {
            Is_Closed_Event = true;
            SetEditViewRights(true);
            btnSend_Notification.Visible = false;
            chkNonActionable.Enabled = false;
        }
        else if (objEvent.Status != null && Convert.ToString(objEvent.Status) == "C")
        {
            Is_Closed_Event = true;
            SetEditViewRights(true);
        }
        else
        {
            Is_Closed_Event = false;
            //SetEditViewRights(false);
        }

        if (PK_Event > 0)
        {
            DataSet dsEventType = clsEvent_Link_LU_Event_Type.SelectByFK_Event(PK_Event);

            decimal eventLevelCodeOld = 0;
            decimal eventLevelCodeNew = 0;
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
                            eventLevelCodeNew = Convert.ToDecimal(drEvent_Type["EventLevel_Fld_Code"]);

                            if (eventLevelCodeNew > eventLevelCodeOld)
                            {
                                eventLevelCodeOld = eventLevelCodeNew;
                            }
                            //TextBox txtDesc = (TextBox)rptEvent.FindControl("txtEventDesciption");
                            //txtDesc.Text = drEvent_Type["Description"].ToString();
                        }
                    }
                }
            }

            clsGeneral.SetDropdownValue(ddlEvent_Level, eventLevelCodeOld, true);
            clsGeneral.SetDropdownValue(ddlEvent_Level_Sonic, eventLevelCodeOld, true);

            //BindEvent_CameraGrid();
            BindVehicle_InformationGrid();
            BindSuspect_InformationGrid();
            BindACINoteGrid(ctrlPageAcadianNotes.CurrentPage, ctrlPageAcadianNotes.PageSize);
            BindReapterInvest_Images();
            //BindBuilding_ACI();

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

                            //TextBox txtDesc = (TextBox)rptEvent.FindControl("txtEventDesciptionSonic");
                            //txtDesc.Text = drEvent_Type["Description"].ToString();
                        }
                    }
                }
            }

            txtEventDesciptionSonic.Text = txtEventDesciption.Text = objEvent.Event_Desc;
            txtBuilding_Description.Text = objEvent.Building_Description;
            if (objEvent.Restricted != null)
                chkRestricted.Checked = objEvent.Restricted == "Y" ? true : false;
            if (objEvent.Exterior_Interior != null)
                rdoExterior_Interior.SelectedValue = Convert.ToString(objEvent.Exterior_Interior);

            BindEvent_Camera_SonicGrid();
            BindSonicNoteGrid(ctrlPageSonicNotes.CurrentPage, ctrlPageSonicNotes.PageSize);
            BindGridBuilding();

            //ctrlEventNotes.PK_Event = PK_Event;
            //ctrlEventNotes.CurrentEventNoteType = clsGeneral.Event_Note_Tyep.Acadian_Note.ToString();
            //ctrlEventNotes.BindGridSonicNotes(PK_Event, clsGeneral.Event_Note_Tyep.Acadian_Note.ToString());
            //ctrlEventNotes.StrOperation = "Edit";
            //ctrlEventNotes.FK_Incident = FK_Incident;

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
        //ComboHelper.FillLocationDBA_All(new DropDownList[] { ddlLocation, ddlLocation_Sonic }, 0, true);
        ComboHelper.FillLocationByACIUser_New((new DropDownList[] { ddlLocation, ddlLocation_Sonic }), Convert.ToDecimal(clsSession.UserID), true);
        ComboHelper.FillEventLevel(new DropDownList[] { ddlEvent_Level, ddlEvent_Level_Sonic }, true);
        ComboHelper.FillCause_Investigation(new DropDownList[] { ddlFK_LU_Cause_Investigation }, true);
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

        objEvent.ACI_EventID = Convert.ToString(txtACI_EventID.Text);

        objEvent.Sonic_Event = Is_Sonic_Event == true ? "Y" : "N";

        if (!Is_Sonic_Event)
        {
            objEvent.Event_Start_Date = clsGeneral.FormatNullDateToStore(txtEvent_Start_Date.Text);
            objEvent.Event_Start_Time = Convert.ToString(txtEvent_Start_Time.Text);
            objEvent.Event_End_Time = Convert.ToString(txtEvent_End_Time.Text);
            objEvent.Police_Called = rdoPolice_Called.SelectedValue;
            objEvent.Agency_name = Convert.ToString(txtAgency_name.Text);
            objEvent.Officer_Name = Convert.ToString(txtOfficer_Name.Text);
            objEvent.Officer_Phone = Convert.ToString(txtOfficer_Phone.Text);
            objEvent.Police_Report_Number = Convert.ToString(txtPolice_Report_Number.Text);
            if (ddlLocation.SelectedIndex > 0)
                objEvent.FK_LU_Location = Convert.ToDecimal(ddlLocation.SelectedValue);

            objEvent.Event_Desc = txtEventDesciption.Text.Trim();
            objEvent.Building_Description = txtBuilding_Description.Text.Trim();
            objEvent.Restricted = chkRestricted.Checked ? "Y" : "N";
            objEvent.Exterior_Interior = rdoExterior_Interior.SelectedIndex > -1 ? rdoExterior_Interior.SelectedValue : null;
        }
        objEvent.Status = rdoStatus.SelectedValue;
        objEvent.Date_Closed = clsGeneral.FormatNullDateToStore(txtDate_Closed.Text);
        //objEvent.Investigator_Name = Convert.ToString(txtInvestigator_Name.Text);
        //objEvent.Investigator_Email = Convert.ToString(txtInvestigator_Email.Text);
        //objEvent.Investigator_Phone = Convert.ToString(txtInvestigator_Phone.Text);
        objEvent.Incident_Report_Desc = Convert.ToString(txtIncident_Report.Text);
        if (ddlFK_LU_Cause_Investigation.SelectedIndex > 0)
            objEvent.FK_LU_Cause_Investigation = Convert.ToDecimal(ddlFK_LU_Cause_Investigation.SelectedValue);

        if (Is_Sonic_Event)
        {
            objEvent.Event_Start_Date = clsGeneral.FormatNullDateToStore(txtEvent_Start_Date_Sonic.Text);
            objEvent.Event_Start_Time = Convert.ToString(txtEvent_Start_Time_Sonic.Text);
            objEvent.Event_End_Time = Convert.ToString(txtEvent_End_Time_Sonic.Text);
            objEvent.Police_Called = rdoPolice_Called_Sonic.SelectedValue;
            objEvent.Agency_name = Convert.ToString(txtAgency_name_Sonic.Text);
            objEvent.Officer_Name = Convert.ToString(txtOfficer_Name_Sonic.Text);
            objEvent.Officer_Phone = Convert.ToString(txtOfficer_Phone_Sonic.Text);
            objEvent.Police_Report_Number = Convert.ToString(txtPolice_Report_Number_Sonic.Text);
            if (ddlLocation_Sonic.SelectedIndex > 0)
                objEvent.FK_LU_Location = Convert.ToDecimal(ddlLocation_Sonic.SelectedValue);

            objEvent.Event_Desc = txtEventDesciptionSonic.Text.Trim();
        }

        objEvent.Video_Requested_By_Sonic = rblVideoRequestedBySonic.SelectedValue;
        objEvent.Monitoring_Hours = rdoMonitoring_Hours_Sonic.SelectedValue;
        objEvent.Source_Of_Information = txtSource_Of_Information.Text.Trim();
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
        {
            objEvent.Update();
            ViewState.Remove("EmailAbsratact");
        }
        else
        {
            PK_Event = objEvent.Insert();
            ViewState["EmailAbsratact"] = PK_Event;
        }

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

                    //TextBox txtDesc = (TextBox)rpt.FindControl("txtEventDesciption");
                    //if (!string.IsNullOrEmpty(txtDesc.Text))
                    //    objEvent_Link_Event_Type.Description = txtDesc.Text;

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

                    //TextBox txtDesc = (TextBox)rpt.FindControl("txtEventDesciptionSonic");
                    //if (!string.IsNullOrEmpty(txtDesc.Text))
                    //    objEvent_Link_Event_Type.Description = txtDesc.Text;

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
    /// Implement event for Paging control when clicking on Go button
    /// </summary>
    protected void GetPage()
    {
        BindACINoteGrid(ctrlPageAcadianNotes.CurrentPage, ctrlPageAcadianNotes.PageSize);
    }

    /// <summary>
    /// Implement event for Paging control when clicking on Go button
    /// </summary>
    protected void GetSonicPage()
    {
        BindSonicNoteGrid(ctrlPageSonicNotes.CurrentPage, ctrlPageSonicNotes.PageSize);
    }

    /// <summary>
    /// Bind Event Camera Grid
    /// </summary>
    //private void BindEvent_CameraGrid()
    //{
    //    DataSet dsEvent_Camera = clsEvent_Camera.SelectByFK_Event(PK_Event);

    //    if (dsEvent_Camera != null && dsEvent_Camera.Tables.Count > 0)
    //    {
    //        gvEvent_Camera.DataSource = dsEvent_Camera;
    //        gvEvent_Camera.DataBind();
    //    }
    //    else
    //    {
    //        gvEvent_Camera.DataSource = null;
    //        gvEvent_Camera.DataBind();
    //    }

    //}

    /// <summary>
    /// Bind Building Grid
    /// </summary>
    //private void BindBuilding_ACI()
    //{
    //    DataTable dtBuilding = Building.SelectByFKEvent(PK_Event).Tables[0];

    //    if (dtBuilding != null)
    //    {
    //        gvBuildingEditACI.DataSource = dtBuilding;
    //        gvBuildingEditACI.DataBind();
    //    }
    //    else
    //    {
    //        gvBuildingEditACI.DataSource = null;
    //        gvBuildingEditACI.DataBind();
    //    }

    //}

    /// <summary>
    /// Bind ACI Notes Grid
    /// </summary>
    private void BindACINoteGrid(int PageNumber, int PageSize)
    {
        DataSet dsNotes = clsACI_Event_Notes.SelectByFK_Event(PK_Event, PageNumber, PageSize, SortBy, SortOrder);
        //DataSet dsNotes = Claim_Notes.SelectByFK_Table(PK_Event, CurrentEventNoteType, CurrentPage, PageSize);
        DataTable dtNotes = dsNotes.Tables[0];
        ctrlPageAcadianNotes.TotalRecords = (dsNotes.Tables.Count >= 2) ? Convert.ToInt32(dsNotes.Tables[1].Rows[0][0]) : 0;
        ctrlPageAcadianNotes.CurrentPage = (dsNotes.Tables.Count >= 2) ? Convert.ToInt32(dsNotes.Tables[1].Rows[0][2]) : 0;
        ctrlPageAcadianNotes.RecordsToBeDisplayed = dsNotes.Tables[0].Rows.Count;
        ctrlPageAcadianNotes.SetPageNumbers();
        if (dsNotes != null && dsNotes.Tables.Count > 0 && dsNotes.Tables[0].Rows.Count > 0)
        {
            gvACI_Notes.DataSource = dsNotes;
            gvACI_Notes.DataBind();
            btnACINoteView.Visible = btnPrint.Visible = btnSpecificNote.Visible = ctrlPageAcadianNotes.Visible = true;
            dvACINOtes.Style["Height"] = "200px";
        }
        else
        {
            gvACI_Notes.DataSource = null;
            gvACI_Notes.DataBind();
            btnACINoteView.Visible = btnPrint.Visible = btnSpecificNote.Visible = ctrlPageAcadianNotes.Visible = false;
            dvACINOtes.Style["Height"] = "31px";
        }
    }

    /// <summary>
    /// Bind Sonic Notes Grid
    /// </summary>
    private void BindSonicNoteGrid(int PageNumber, int PageSize)
    {
        DataSet dsSonic_Note = clsSonic_Event_Notes.SelectByFK_Event_WithPaging(PK_Event, PageNumber, PageSize, SortBy, SortOrder);
        DataTable dtNotes = dsSonic_Note.Tables[0];
        ctrlPageSonicNotes.TotalRecords = (dsSonic_Note.Tables.Count >= 2) ? Convert.ToInt32(dsSonic_Note.Tables[1].Rows[0][0]) : 0;
        ctrlPageSonicNotes.CurrentPage = (dsSonic_Note.Tables.Count >= 2) ? Convert.ToInt32(dsSonic_Note.Tables[1].Rows[0][2]) : 0;
        ctrlPageSonicNotes.RecordsToBeDisplayed = dsSonic_Note.Tables[0].Rows.Count;
        ctrlPageSonicNotes.SetPageNumbers();
        if (dsSonic_Note != null && dsSonic_Note.Tables.Count > 0 && dsSonic_Note.Tables[0].Rows.Count > 0)
        {
            gvSonic_Notes.DataSource = dsSonic_Note;
            gvSonic_Notes.DataBind();
            btnSonicNoteView.Visible = btnSonicPrint.Visible = btnSonicSpecificNote.Visible = ctrlPageSonicNotes.Visible = true;
            dvSonicNOtes.Style["Height"] = "200px";
        }
        else
        {
            gvSonic_Notes.DataSource = null;
            gvSonic_Notes.DataBind();
            btnSonicNoteView.Visible = btnSonicPrint.Visible = btnSonicSpecificNote.Visible = ctrlPageSonicNotes.Visible = false;
            dvSonicNOtes.Style["Height"] = "31px";
        }
    }

    /// <summary>
    /// Bind Suspect Information Grid
    /// </summary>
    private void BindSuspect_InformationGrid()
    {
        DataSet dsSuspect_Information = clsSuspect_Information.SelectByFK_Event(PK_Event);

        if (dsSuspect_Information != null && dsSuspect_Information.Tables.Count > 0)
        {
            gvSuspect_Information.DataSource = dsSuspect_Information;
            gvSuspect_Information.DataBind();
        }
        else
        {
            gvSuspect_Information.DataSource = null;
            gvSuspect_Information.DataBind();
        }

    }

    /// <summary>
    /// Bind Vehicle Information Grid
    /// </summary>
    private void BindVehicle_InformationGrid()
    {
        //DataSet dsEvent_Camera = clsEvent_Camera.SelectByFK_Event(PK_Event);
        DataSet dsVehicle_Information = clsVehicle_Information.SelectByFK_Event(PK_Event);

        if (dsVehicle_Information != null && dsVehicle_Information.Tables.Count > 0)
        {
            gvVehicle_Information.DataSource = dsVehicle_Information;
            gvVehicle_Information.DataBind();
        }
        else
        {
            gvVehicle_Information.DataSource = null;
            gvVehicle_Information.DataBind();
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

    /// <summary>
    ///  Binds Building grid in building information panel
    /// </summary>
    private void BindGridBuilding()
    {
        DataTable dtBuilding = Building.SelectByFKEvent(PK_Event).Tables[0];

        if (dtBuilding != null)
        {
            gvBuildingEdit.DataSource = dtBuilding;
            gvBuildingEdit.DataBind();
        }
        else
        {
            gvBuildingEdit.DataSource = null;
            gvBuildingEdit.DataBind();
        }

    }

    private void BindReapterEventType()
    {
        DataSet dsData = clsLU_Event_Type.SelectAll();
        dsData.Tables[0].DefaultView.RowFilter = "Active = 'Y' AND Is_Actionable = 'Y' AND Fld_Desc <> 'FROI Event/Other'"; //#Issue 3422

        rptEventType.DataSource = dsData.Tables[0].DefaultView.ToTable();
        rptEventType.DataBind();

    }

    private void BindReapterEventTypeSonic()
    {
        DataSet dsData = clsLU_Event_Type.SelectAll();
        dsData.Tables[0].DefaultView.RowFilter = "Active = 'Y' AND Is_Actionable = 'Y' AND Fld_Desc <> 'Voice Down' ";//#Issue 3190

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

            //TextBox txtDesc = (TextBox)rptEvent.FindControl("txtEventDesciption");
            //txtDesc.Text = string.Empty;
        }


        foreach (RepeaterItem rptEvent in rptEventTypeSonic.Items)
        {
            CheckBox chkEvent = (CheckBox)rptEvent.FindControl("chkEventTypeSonic");
            chkEvent.Checked = false;

            //TextBox txtDesc = (TextBox)rptEvent.FindControl("txtEventDesciptionSonic");
            //txtDesc.Text = string.Empty;
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
                System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(AppConfig.SitePath + "Documents\\Attach\\" + ImagesCol1.ImageUrl);

                ImagesCol1.ImageUrl = AppConfig.SiteURL + "Documents/Attach/" + clsGeneral.Encode_Url(ImagesCol1.ImageUrl);

                //ImagesCol1.Height = (int)(bmp.Height * 0.8);
                //ImagesCol1.Width = (int)(bmp.Width * 0.8);
                //if (ImagesCol1.Width.Value >= 750)
                //{
                //    ImagesCol1.Height = (int)(bmp.Height * 0.5);
                //    ImagesCol1.Width = (int)(bmp.Width * 0.5);
                //}

                int originalWidth = bmp.Width;
                int originalHeight = bmp.Height;

                float ratioX = (float)700 / (float)originalWidth;
                float ratioY = (float)300 / (float)originalHeight;
                float ratio = Math.Min(ratioX, ratioY);

                // New width and height based on aspect ratio
                int newWidth = (int)(originalWidth * ratio);
                int newHeight = (int)(originalHeight * ratio);

                ImagesCol1.Height = newHeight;
                ImagesCol1.Width = newWidth;

                bmp.Dispose();
                ImagesCol1.Dispose();
            }
            else
            {
                ImagesCol1.Visible = false;
            }

            Image ImagesCol2 = e.Item.FindControl("imgInvest_Images2") as Image;

            if (!string.IsNullOrEmpty(ImagesCol2.ImageUrl) && File.Exists(AppConfig.DocumentsPath + "Attach\\" + ImagesCol2.ImageUrl))
            {
                System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(AppConfig.SitePath + "Documents/Attach/" + ImagesCol2.ImageUrl);

                ImagesCol2.ImageUrl = AppConfig.SiteURL + "Documents/Attach/" + clsGeneral.Encode_Url(ImagesCol2.ImageUrl);

                int originalWidth = bmp.Width;
                int originalHeight = bmp.Height;

                float ratioX = (float)700 / (float)originalWidth;
                float ratioY = (float)300 / (float)originalHeight;
                float ratio = Math.Min(ratioX, ratioY);

                // New width and height based on aspect ratio
                int newWidth = (int)(originalWidth * ratio);
                int newHeight = (int)(originalHeight * ratio);

                ImagesCol2.Height = newHeight;
                ImagesCol2.Width = newWidth;

                bmp.Dispose();
                ImagesCol2.Dispose();
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

    private void SetEditViewRights(bool Is_Closed)
    {
        bool Is_Enable = false;

        ddlLocation.Enabled = Is_Enable;
        txtACI_EventID.Enabled = Is_Enable;
        ddlEvent_Level.Enabled = Is_Enable;
        foreach (RepeaterItem rpt in rptEventType.Items)
        {
            CheckBox chkEvent = (CheckBox)rpt.FindControl("chkEventType");
            chkEvent.Enabled = Is_Enable;

            //TextBox txtDesc = (TextBox)rpt.FindControl("txtEventDesciption");
            //txtDesc.Enabled = Is_Enable;
        }
        txtEventDesciption.Enable = Is_Enable;
        ddlFK_LU_Cause_Investigation.Enabled = Is_Enable;
        txtBuilding_Description.Enabled = Is_Enable;
        chkRestricted.Enabled = Is_Enable;
        rdoExterior_Interior.Enabled = Is_Enable;
        txtEvent_Start_Date.Enabled = Is_Enable;
        txtEvent_Start_Time.Enabled = Is_Enable;
        txtEvent_End_Time.Enabled = Is_Enable;
        imgEvent_Start_Date.Visible = Is_Enable;
        //lnkAddEvent_CameraNew.Visible = Is_Enable;
        //txtInvestigator_Name.Enabled = Is_Enable;
        //txtInvestigator_Email.Enabled = Is_Enable;
        //txtInvestigator_Phone.Enabled = Is_Enable;


        //rdoPolice_Called.Enabled = Is_Enable;
        //txtAgency_name.Enabled = Is_Enable;
        //txtOfficer_Name.Enabled = Is_Enable;
        //txtOfficer_Phone.Enabled = Is_Enable;
        //txtPolice_Report_Number.Enabled = Is_Enable;
        //lnkAddACINotesNew.Visible = Is_Enable;
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

        if (Is_Closed)
        {
            rdoPolice_Called.Enabled = false;
            rblVideoRequestedBySonic.Enabled = false;
            txtAgency_name.Enabled = false;
            txtOfficer_Name.Enabled = false;
            txtOfficer_Phone.Enabled = false;
            txtPolice_Report_Number.Enabled = false;
            txtIncident_Report.Enable = false;
            ddlFK_LU_Cause_Investigation.Enabled = false;
            lnkAddACINotesNew.Visible = false;
            lnkAddSuspectInfo.Visible = false;
            lnkAddVehicleInfo.Visible = false;
            rdoStatus.Enabled = false;
            txtDate_Closed.Enabled = false;
            imgDate_Closed.Visible = false;
            ddlLocation_Sonic.Enabled = false;
            txtEvent_Start_Date_Sonic.Enabled = false;
            txtEvent_Start_Time_Sonic.Enabled = false;
            txtEvent_End_Time_Sonic.Enabled = false;
            imgEvent_Start_Date_Sonic.Visible = false;
            txtEvent_Number_Sonic.Enabled = false;
            rdoMonitoring_Hours_Sonic.Enabled = false;
            txtSonic_Notes.Attributes.Add("class", "readOnlyTextBox");
            txtSource_Of_Information.Enabled = false;
            ddlEvent_Level_Sonic.Enabled = false;
            lnkAddEvent_CameraNew_Sonic.Visible = false;
            foreach (RepeaterItem rpt in rptEventTypeSonic.Items)
            {
                CheckBox chkEvent = (CheckBox)rpt.FindControl("chkEventTypeSonic");
                chkEvent.Enabled = false;

                //TextBox txtDesc = (TextBox)rpt.FindControl("txtEventDesciptionSonic");
                //txtDesc.Enabled = false;
            }
            //txtEventDesciptionSonic.Attributes.Add("class", "readOnlyTextBox");
            txtEventDesciptionSonic.Enable = false;
            txtBuilding_Description.Enabled = false;
            chkRestricted.Enabled = false;
            rdoExterior_Interior.Enabled = false;
            rdoPolice_Called_Sonic.Enabled = false;
            txtAgency_name_Sonic.Enabled = false;
            txtOfficer_Phone_Sonic.Enabled = false;
            txtOfficer_Name_Sonic.Enabled = false;
            txtPolice_Report_Number_Sonic.Enabled = false;
            txtBadge_Number_Sonic.Enabled = false;
            txtSonic_Contact_Name.Enabled = false;
            txtSonic_Contact_Phone.Enabled = false;
            txtSonic_Contact_Email.Enabled = false;
            lnkAddSonicNotesNew.Visible = false;
            lnkAddFK_AL_FR.Visible = false;
            lnkAddFK_DPD_FR.Visible = false;
            lnkAddFK_PL_FR.Visible = false;
            lnkAddFK_Property_FR.Visible = false;
            txtFinancial_Loss.Enabled = false;
            ucAttachment.ReadOnly = true;
            btnSave.Visible = false;
            trBuilding_Addlink.Visible = false;
        }


    }

    private void SendAbstractViaEmailWhileInsert()
    {
        if (PK_Event > 0)
        {
            clsEvent objEvent = new clsEvent(PK_Event);
            DataTable dtEmailList = Security.GetEmailsByLocationForEvent(objEvent.FK_LU_Location).Tables[0];
            //string[] strEmailIds = new string[1];

            DataSet ds_Event = clsEvent.GetEventAbstractLetterData(PK_Event);

            string strAbstractReportData = Convert.ToString(Event_AbstactReportDOC(ds_Event, PK_Event, false, clsGeneral.Major_Coverage.Event));

            //string[] attchment = null;
            //if (ViewState["Attchments"] != null)
            //{
            //    attchment = new string[1];
            //    attchment[0] = AppConfig.SitePath + "Documents/EventImage" + "/" + Convert.ToString(ViewState["Attchments"]);
            //}

            string strPath = AppConfig.DocumentsPath + "Attach\\" + @"Event.doc";

            #region " Generate WORD Doc "
            string strLisenceFile = HttpContext.Current.Server.MapPath(HttpContext.Current.Request.ApplicationPath) + "\\" + ("Bin") + "\\Aspose.Words.lic";

            if (File.Exists(strLisenceFile))
            {
                Aspose.Words.License license = new Aspose.Words.License();
                license.SetLicense(strLisenceFile);
            }

            Aspose.Words.Document doc = new Aspose.Words.Document();

            Aspose.Words.DocumentBuilder builder = new Aspose.Words.DocumentBuilder(doc);
            builder.PageSetup.BottomMargin = 20;
            builder.PageSetup.TopMargin = 20;
            builder.PageSetup.LeftMargin = 20;
            builder.PageSetup.RightMargin = 20;
            builder.Font.Size = 10;
            builder.PageSetup.PaperSize = PaperSize.A4;
            //builder.Font.Bold = false;
            //builder.Font.Color = System.Drawing.Color.Black;
            builder.Font.Name = "Arial";
            builder.InsertParagraph();
            builder.InsertHtml(strAbstractReportData);

            //imageFileName = AppConfig.ImageURL + "letter-footer.JPG";
            //builder.InsertImage(imageFileName, Aspose.Words.Drawing.RelativeHorizontalPosition.Page, 25, Aspose.Words.Drawing.RelativeVerticalPosition.Page, 710, 550, 42, Aspose.Words.Drawing.WrapType.Through);

            //Don't need merge fields in the document anymore.
            doc.MailMerge.DeleteFields();
            //builder.MoveToSection(0);
            //builder.MoveToHeaderFooter(HeaderFooterType.FooterPrimary);
            //builder.PageSetup.PageNumberStyle = NumberStyle.Number;
            //builder.ParagraphFormat.Alignment = ParagraphAlignment.Center;
            //builder.Write("Page ");
            //builder.InsertField("PAGE", "");
            //builder.Write(" of ");
            //builder.InsertField("NUMPAGES", "");
            //Section section = doc.Sections[0];
            //section.PageSetup.PageStartingNumber = 1;
            //section.PageSetup.RestartPageNumbering = true;
            //section.PageSetup.PageNumberStyle = NumberStyle.Arabic;

            doc.Save(strPath, Aspose.Words.SaveFormat.Doc);

            #endregion

            System.Collections.Generic.List<string> lstMail = new System.Collections.Generic.List<string>();

            int intToMailCount = 0;
            if (dtEmailList.Rows.Count > 0)
            {
                foreach (DataRow drRecipient in dtEmailList.Rows)
                {
                    lstMail.Insert(intToMailCount, drRecipient["Email"].ToString());
                    intToMailCount++;
                }
            }

            string[] EmailTo = lstMail.ToArray();

            System.Collections.Generic.List<string> lstImages = new System.Collections.Generic.List<string>();
            int intImagescount = 0;

            if (!string.IsNullOrEmpty(strPath) && File.Exists(strPath))
            {
                lstImages.Insert(intImagescount, strPath);
                intImagescount++;
            }

            //DataTable dtInvestigationImages = ds_Event.Tables[6];

            //if (!string.IsNullOrEmpty(_strAttachmentName) && File.Exists(AppConfig.DocumentsPath + "EventImage\\" + _strAttachmentName))
            //{
            //    lstImages.Insert(intImagescount, AppConfig.DocumentsPath + "EventImage\\" + _strAttachmentName);
            //    intImagescount++;
            //}

            //foreach (DataRow drEvent_Images in dtInvestigationImages.Rows)
            //{
            //    if (!string.IsNullOrEmpty(Convert.ToString(drEvent_Images["Attachment_Name"])) && File.Exists(AppConfig.SitePath + "Documents\\Attach\\" + drEvent_Images["Attachment_Name"]))
            //    {
            //        lstImages.Insert(intImagescount, AppConfig.SitePath + "Documents\\Attach\\" + drEvent_Images["Attachment_Name"]);
            //        intImagescount++;
            //    }
            //}

            string[] strTemp = lstImages.ToArray();

            string Emailbody = "ACI Actionable Event Abstract for Event Number: " + _strEvent_Number + ".<br/>Thank You";

            if (EmailTo.Length > 0)
            {
                EmailHelper objEmail = new EmailHelper(AppConfig.SMTPServer, AppConfig.MailFrom, AppConfig.SMTPpwd, Convert.ToInt32(AppConfig.Port));
                objEmail.SendEventMailMessageDOC(AppConfig.ManagementEmailID, " ", EmailTo, "ACI Actionable Event Abstract", Emailbody, true, strTemp, AppConfig.MailCC);
            }

            //for (int i = 0; i < dtEmailList.Rows.Count; i++)
            //{
            //    strEmailIds[0] = Convert.ToString(dtEmailList.Rows[i]["Email"]);
            //    EmailHelper objEmail = new EmailHelper(AppConfig.SMTPServer, AppConfig.MailFrom, AppConfig.SMTPpwd, Convert.ToInt32(AppConfig.Port));
            //    objEmail.SendMailMessage(AppConfig.ManagementEmailID, " ", strEmailIds, "ACI Actionable Event Abstract.", strAbstractReportData, true, attchment, AppConfig.MailCC);
            //    strEmailIds[0] = string.Empty;
            //}

            //ViewState.Remove("Attchments");
        }
    }

    public StringBuilder Event_AbstactReport(DataSet dsEvent, decimal _PK_Event, bool ShowAttachments, clsGeneral.Major_Coverage MajorCoverageType)
    {
        //DataSet dsEvent = clsEvent.GetEventAbstractLetterData(_PK_Event);

        StringBuilder strBody = new StringBuilder("");

        if (dsEvent != null && dsEvent.Tables.Count > 0 && dsEvent.Tables[0].Rows.Count > 0)
        {
            DataTable dtEvent = dsEvent.Tables[0];
            DataTable dtActionable_Event = dsEvent.Tables[1];
            DataTable dtBuilding = dsEvent.Tables[2];
            DataTable dtCamera = dsEvent.Tables[3];
            DataTable dtACINotes = dsEvent.Tables[4];
            DataTable dtSonicNotes = dsEvent.Tables[5];
            DataTable dtEventImages = dsEvent.Tables[6];
            DataTable dtVehicleInformation = dsEvent.Tables[7];
            DataTable dtSuspectInformation = dsEvent.Tables[8];

            FileStream fsMail = null;

            bool Is_Sonic_Event = Convert.ToBoolean(dtEvent.Rows[0]["Sonic_Event"]);

            if (Is_Sonic_Event)
                fsMail = new FileStream(AppConfig.DocumentsPath + @"\AbstractLetterTemplate\Event_AbstractReport_Sonic.htm", FileMode.Open, FileAccess.Read);
            else fsMail = new FileStream(AppConfig.DocumentsPath + @"\AbstractLetterTemplate\Event_AbstractReport.htm", FileMode.Open, FileAccess.Read);
            StreamReader rd = new StreamReader(fsMail);
            //StringBuilder strBody = new StringBuilder(rd.ReadToEnd().ToString());
            rd = new StreamReader(fsMail);
            strBody = new StringBuilder(rd.ReadToEnd().ToString());


            rd.Close();
            fsMail.Close();

            #region "ACI Reported Event"

            strBody = strBody.Replace("[Location]", Convert.ToString(dtEvent.Rows[0]["Location"]));
            strBody = strBody.Replace("[ACI_Event_ID]", Convert.ToString(dtEvent.Rows[0]["ACI_EventID"]));

            string strActionableEvent = string.Empty;

            if (!Is_Sonic_Event)
                dtActionable_Event.DefaultView.RowFilter = "Actionable_Event_Desc <> 'FROI Event/Other'"; //#Issue 3422

            DataTable dtFiltered_Event = dtActionable_Event.DefaultView.ToTable();

            if (dtFiltered_Event.Rows.Count > 0)
            {
                strActionableEvent = "<table cellpadding='4' cellspacing='0' width='100%'>";
                foreach (DataRow drEvent_Type in dtFiltered_Event.Rows)
                {
                    if (Convert.ToBoolean(drEvent_Type["Is_Checked"]))
                    {
                        strActionableEvent += "<tr style='page-break-inside: avoid'><td width='50%' align='left' valign='top' style='font-family: Arial; font-size: 12px;'>" + drEvent_Type["Actionable_Event_Desc"] + "</td><td width='50%' align='left' valign='top' style='font-family: Arial; font-size: 12px;'> Yes </td></tr>";
                    }
                    else
                    {
                        strActionableEvent += "<tr style='page-break-inside: avoid'><td width='50%' align='left' valign='top' style='font-family: Arial; font-size: 12px;'>" + drEvent_Type["Actionable_Event_Desc"] + "</td><td width='50%' align='left' valign='top' style='font-family: Arial; font-size: 12px;'> No </td></tr>";
                    }
                }
                strActionableEvent += "</table>";
            }
            strBody = strBody.Replace("[Actionable_Event_Type]", strActionableEvent);
            strBody = strBody.Replace("[Description_of_Event]", Convert.ToString(dtEvent.Rows[0]["Event_Desc"]));
            if (!string.IsNullOrEmpty(Convert.ToString(dtEvent.Rows[0]["Event_Start_Date"])))
                strBody = strBody.Replace("[Date_of_Event]", clsGeneral.FormatDBNullDateToDisplay(dtEvent.Rows[0]["Event_Start_Date"]));
            else
                strBody = strBody.Replace("[Date_of_Event]", string.Empty);

            strBody = strBody.Replace("[Event_Start_Time]", Convert.ToString(dtEvent.Rows[0]["Event_Start_Time"]));
            strBody = strBody.Replace("[Event_End_Time]", Convert.ToString(dtEvent.Rows[0]["Event_End_Time"]));


            strBody = strBody.Replace("[BuildingInformation]", GetBuildingDetails(dtBuilding));

            strBody = strBody.Replace("[Camera_Grid]", GetCameraDetails(dtCamera));

            strBody = strBody.Replace("[Acadian_Investigator_Name]", Convert.ToString(dtEvent.Rows[0]["Investigator_Name"]));
            strBody = strBody.Replace("[Acadian_Investigator_Email_Address]", Convert.ToString(dtEvent.Rows[0]["Investigator_Email"]));
            strBody = strBody.Replace("[Acadian_Investigator_Phone]", Convert.ToString(dtEvent.Rows[0]["Investigator_Phone"]));

            int ImageCounter = 0;

            ////string AttachmentDocPath = "Documents/EventImage";
            //if (!string.IsNullOrEmpty(Convert.ToString(dtEvent.Rows[0]["Event_Image"])) && File.Exists(AppConfig.DocumentsPath + "EventImage\\" + dtEvent.Rows[0]["Event_Image"]))
            //{
            //    ViewState["Attchments"] = dtEvent.Rows[0]["Event_Image"];
            //    //strBody = strBody.Replace("[Event_Image]", "<img  alt='' src='" + AppConfig.SiteURL + AttachmentDocPath + "/" + dtEvent.Rows[0]["Event_Image"] + "' Height='200' Width='200' />");
            //}
            //else
            //{
            //    // ViewState["Attchments"] = dtEvent.Rows[0]["Event_Image"];
            //    ViewState.Remove("Attchments");
            //    //strBody = strBody.Replace("[Event_Image]", string.Empty);
            //}

            string AttachmentDocPath = "Documents/EventImage";
            if (!DBNull.Value.Equals(dtEvent.Rows[0]["Event_Image"]) && File.Exists(Server.MapPath("..\\") + AttachmentDocPath + "/" + dtEvent.Rows[0]["Event_Image"]) && !Is_Sonic_Event)
            {
                //strBody = strBody.Replace("[Event_Image]", "<img  alt='' src='" + AppConfig.SiteURL + AttachmentDocPath + "/" + dtEvent.Rows[0]["Event_Image"] + "' Height='200' Width='200' />");
                _strAttachmentName = Convert.ToString(dtEvent.Rows[0]["Event_Image"]);
                strBody = strBody.Replace("[Event_Image]", "<img src=\"cid:Event_Images_" + ImageCounter + "\" Height=\"288\" Width=\"352\" />");
                ImageCounter++;
            }
            else
            {
                strBody = strBody.Replace("[Event_Image]", string.Empty);
                _strAttachmentName = string.Empty;
            }

            strBody = strBody.Replace("[AL_FR_Number]", Convert.ToString(dtEvent.Rows[0]["AL_FR_Number"]));
            strBody = strBody.Replace("[DPD_FR_Number]", Convert.ToString(dtEvent.Rows[0]["DPD_FR_Number"]));
            strBody = strBody.Replace("[PL_FR_Number]", Convert.ToString(dtEvent.Rows[0]["PL_FR_Number"]));
            strBody = strBody.Replace("[Prop_FR_Number]", Convert.ToString(dtEvent.Rows[0]["Prop_FR_Number"]));
            strBody = strBody.Replace("[Event_Root_Cause]", Convert.ToString(dtEvent.Rows[0]["Event_Root_Cause"]));
            strBody = strBody.Replace("[How_Event_Prevented]", Convert.ToString(dtEvent.Rows[0]["How_Event_Prevented"]));
            strBody = strBody.Replace("[Financial_Loss]", string.Format("{0:C2}", dtEvent.Rows[0]["Financial_Loss"]));

            #endregion

            #region "Sonic Reported Event"

            strBody = strBody.Replace("[SRE#]", Convert.ToString(dtEvent.Rows[0]["Event_Number"]));
            strBody = strBody.Replace("[Monitoring_Hours]", Convert.ToString(dtEvent.Rows[0]["Monitoring_Hours"]));
            strBody = strBody.Replace("[Source_of_Information]", Convert.ToString(dtEvent.Rows[0]["Source_Of_Information"]));
            strBody = strBody.Replace("[Event_Level]", Convert.ToString(dtEvent.Rows[0]["Event_Level"]));
            strBody = strBody.Replace("[Budge#]", Convert.ToString(dtEvent.Rows[0]["Badge_Number"]));
            strBody = strBody.Replace("[Sonic_Contact_Name]", Convert.ToString(dtEvent.Rows[0]["Sonic_Contact_Name"]));
            strBody = strBody.Replace("[Sonic_Contact_Phone_#]", Convert.ToString(dtEvent.Rows[0]["Sonic_Contact_Phone"]));
            strBody = strBody.Replace("[Sonic_Contact_Email_Address]", Convert.ToString(dtEvent.Rows[0]["Sonic_Contact_Email"]));

            #endregion

            #region "Acadian Investigation"

            strBody = strBody.Replace("[Police_Called]", Convert.ToString(dtEvent.Rows[0]["Police_Called"]));
            strBody = strBody.Replace("[Video_Requested_By_Sonic]", Convert.ToString(dtEvent.Rows[0]["Video_Requested_By_Sonic"]));
            strBody = strBody.Replace("[Agency_Name]", Convert.ToString(dtEvent.Rows[0]["Agency_Name"]));
            strBody = strBody.Replace("[Officer_Name]", Convert.ToString(dtEvent.Rows[0]["Officer_Name"]));
            strBody = strBody.Replace("[Phone_#]", Convert.ToString(dtEvent.Rows[0]["Officer_Phone"]));
            strBody = strBody.Replace("[Police_Report_#]", Convert.ToString(dtEvent.Rows[0]["Police_Report_Number"]));
            strBody = strBody.Replace("[Incident_Report_Desc]", Convert.ToString(dtEvent.Rows[0]["Incident_Report_Desc"]));

            strBody = strBody.Replace("[Vehicle_Information_Grid]", GetVehicleDetails(dtVehicleInformation));
            strBody = strBody.Replace("[Suspect_Information_Grid]", GetSuspectDetails(dtSuspectInformation));
            strBody = strBody.Replace("[Acadian_Notes_Grid]", GetACINotesDetails(dtACINotes));

            strBody = strBody.Replace("[Status]", Convert.ToString(dtEvent.Rows[0]["Status"]));
            if (!string.IsNullOrEmpty(Convert.ToString(dtEvent.Rows[0]["Date_Closed"])))
                strBody = strBody.Replace("[Date_Closed]", clsGeneral.FormatDBNullDateToDisplay(dtEvent.Rows[0]["Date_Closed"]));
            else
                strBody = strBody.Replace("[Date_Closed]", string.Empty);

            strBody = strBody.Replace("[Sonic_Notes_Grid]", GetSonicNotesDetails(dtSonicNotes));
            //if (Is_Sonic_Event)
            //{
            //    strBody = strBody.Replace("[Sonic_Notes_Grid]", GetSonicNotesDetails(dtSonicNotes));
            //}

            #endregion

            #region "Images of Event"

            string strEventImages = string.Empty;
            if (dtEventImages.Rows.Count > 0)
            {
                strEventImages = "<table cellpadding='1' cellspacing='1' width='95%'>";

                foreach (DataRow drEvent_Images in dtEventImages.Rows)
                {
                    if (!string.IsNullOrEmpty(Convert.ToString(drEvent_Images["Attachment_Name"])) && File.Exists(AppConfig.DocumentsPath + "Attach\\" + drEvent_Images["Attachment_Name"]))
                    {
                        System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(AppConfig.SitePath + "Documents\\Attach\\" + drEvent_Images["Attachment_Name"]);

                        int originalWidth = bmp.Width;
                        int originalHeight = bmp.Height;

                        float ratioX = (float)600 / (float)originalWidth;
                        float ratioY = (float)200 / (float)originalHeight;
                        float ratio = Math.Min(ratioX, ratioY);

                        // New width and height based on aspect ratio
                        int newWidth = (int)(originalWidth * ratio);
                        int newHeight = (int)(originalHeight * ratio);

                        bmp.Dispose();

                        strEventImages += "<tr style='page-break-inside: avoid'><td valign='top' align='center' border='3px solid'><img src=\"cid:Event_Images_" + ImageCounter + "\" BorderWidth='1px' BorderStyle='Solid' BorderColor='Black' Height='" + newHeight + "' Width='" + newWidth + "' /></td></tr>";
                        ImageCounter++;
                    }
                }
                strEventImages += "</table>";
            }

            strBody = strBody.Replace("[Images_of_Event]", strEventImages);

            #endregion
        }

        return strBody;

    }

    public string GetBuildingDetails(DataTable dtBuilding)
    {
        StringBuilder sbGrid = new StringBuilder(string.Empty);
        sbGrid = new StringBuilder(string.Empty);
        //sbGrid.Append("<tr><td style='font-size: 12px; font-family: Arial; font-weight: bold;page-break-inside : avoid' class='HeaderRow' colspan='6'>Attachments</td></tr>");
        //sbGrid.Append("<tr><td style='font-size: 12px; font-family: Arial; '  colspan='6'>");
        sbGrid.Append("<tr style='page-break-inside: avoid'><td colspan='6'> <table border='0' cellspacing='1' cellpadding='1' width='100%'>");
        sbGrid.Append("<tr style='page-break-inside: avoid'>");
        sbGrid.Append("<td style='font-size: 12px; font-family: Arial; font-weight: bold;page-break-inside : avoid' class='HeaderRow' colspan='6'>Buildings</td></tr>");
        sbGrid.Append("<tr style='page-break-inside: avoid'><td style='font-size: 12px; font-family: Arial;'  colspan='6'>");
        if (dtBuilding.Rows.Count > 0)
        {
            sbGrid.Append("<table width='100%'>");
            sbGrid.Append("<tr style='background-color: #7f7f7f; font-family: Arial; color: white; font-size: 12px; font-weight: bold' valign=top>");
            sbGrid.Append("<td  style='font-family: Arial; font-size: 12px;' align='left'> Building Number </td>");
            sbGrid.Append("<td  style='font-family: Arial; font-size: 12px;' align='left'> Address </td>");
            sbGrid.Append("<td  style='font-family: Arial; font-size: 12px;' align='left'> Occupancy </td>");
            sbGrid.Append("</tr>");

            foreach (DataRow dr in dtBuilding.Rows)
            {
                sbGrid.Append("<tr valign=top>");
                sbGrid.AppendFormat("<td  style='font-family: Arial; font-size: 12px;' align='left'>  {0} </td>", dr["Building_Number"]);
                sbGrid.AppendFormat("<td  style='font-family: Arial; font-size: 12px;' align='left'>  {0} </td>", dr["Address"]);
                sbGrid.AppendFormat("<td  style='font-family: Arial; font-size: 12px;' align='left'>  {0} </td>", dr["Occupancy"]);
                sbGrid.Append("</tr>");
            }
            sbGrid.Append("</table>");
            sbGrid.Append("</td>");
            sbGrid.Append("</tr>");
            sbGrid.Append("</table>");
        }
        else
        {
            sbGrid.Append("<table width='100%'>");
            sbGrid.Append("<tr valign='top' style='font-family: Arial; font-size: 12px; padding-left:20px;' align='center'><td align='left'>No Building Records Found.</td></tr>");
            sbGrid.Append("</table>");
            sbGrid.Append("</td>");
            sbGrid.Append("</tr>");
            sbGrid.Append("</table>");
        }
        sbGrid.Append("</td></tr>");
        sbGrid.Append("<tr><td>&nbsp;</td></tr>");
        return sbGrid.ToString();
    }

    public string GetCameraDetails(DataTable dtCamera)
    {
        StringBuilder sbGrid = new StringBuilder(string.Empty);
        sbGrid = new StringBuilder(string.Empty);
        if (dtCamera.Rows.Count > 0)
        {
            sbGrid.Append("<table width='100%'>");
            sbGrid.Append("<tr style='background-color: #7f7f7f; font-family: Arial; color: white; font-size: 12px; font-weight: bold' valign=top>");
            sbGrid.Append("<td  style='font-family: Arial; font-size: 12px;' align='left'> Camera Name </td>");
            sbGrid.Append("<td  style='font-family: Arial; font-size: 12px;' align='left'> Camera Number </td>");
            sbGrid.Append("<td  style='font-family: Arial; font-size: 12px;' align='left'> Event Time From </td>");
            sbGrid.Append("<td  style='font-family: Arial; font-size: 12px;' align='left'> Event Time To </td>");
            sbGrid.Append("</tr>");

            foreach (DataRow dr in dtCamera.Rows)
            {
                sbGrid.Append("<tr valign=top>");
                sbGrid.AppendFormat("<td  style='font-family: Arial; font-size: 12px;' align='left'>  {0} </td>", dr["Camera_Name"]);
                sbGrid.AppendFormat("<td  style='font-family: Arial; font-size: 12px;' align='left'>  {0} </td>", dr["Camera_Number"]);
                sbGrid.AppendFormat("<td  style='font-family: Arial; font-size: 12px;' align='left'>  {0} </td>", dr["Event_Time_From"]);
                sbGrid.AppendFormat("<td  style='font-family: Arial; font-size: 12px;' align='left'>  {0} </td>", dr["Event_Time_To"]);
                sbGrid.Append("</tr>");
            }
            sbGrid.Append("</table>");
        }
        else
        {
            sbGrid.Append("No Records found.");
        }

        return sbGrid.ToString();
    }

    public static string GetVehicleDetails(DataTable dtVehicle)
    {
        StringBuilder sbGrid = new StringBuilder(string.Empty);
        sbGrid = new StringBuilder(string.Empty);
        if (dtVehicle.Rows.Count > 0)
        {
            sbGrid.Append("<table width='100%'>");
            sbGrid.Append("<tr style='background-color: #7f7f7f; font-family: Arial; color: white; font-size: 12px; font-weight: bold' valign=top>");
            sbGrid.Append("<td  style='font-family: Arial; font-size: 12px;' align='left'> Make </td>");
            sbGrid.Append("<td  style='font-family: Arial; font-size: 12px;' align='left'> Model </td>");
            sbGrid.Append("<td  style='font-family: Arial; font-size: 12px;' align='left'> Color </td>");
            sbGrid.Append("<td  style='font-family: Arial; font-size: 12px;' align='left'> License </td>");
            sbGrid.Append("<td  style='font-family: Arial; font-size: 12px;' align='left'> State </td>");
            sbGrid.Append("<td  style='font-family: Arial; font-size: 12px;' align='left'> Suspect Vehicle </td>");
            sbGrid.Append("</tr>");

            foreach (DataRow dr in dtVehicle.Rows)
            {
                sbGrid.Append("<tr valign=top>");
                sbGrid.AppendFormat("<td  style='font-family: Arial; font-size: 12px;' align='left'>  {0} </td>", dr["Make"]);
                sbGrid.AppendFormat("<td  style='font-family: Arial; font-size: 12px;' align='left'>  {0} </td>", dr["Model"]);
                sbGrid.AppendFormat("<td  style='font-family: Arial; font-size: 12px;' align='left'>  {0} </td>", dr["Color"]);
                sbGrid.AppendFormat("<td  style='font-family: Arial; font-size: 12px;' align='left'>  {0} </td>", dr["License"]);
                sbGrid.AppendFormat("<td  style='font-family: Arial; font-size: 12px;' align='left'>  {0} </td>", dr["STATE"]);
                sbGrid.AppendFormat("<td  style='font-family: Arial; font-size: 12px;' align='left'>  {0} </td>", dr["Suspect_Vehicle"]);
                sbGrid.Append("</tr>");
            }
            sbGrid.Append("</table>");
        }
        else
        {
            sbGrid.Append("No Records found.");
        }

        return sbGrid.ToString();
    }

    public static string GetSuspectDetails(DataTable dtSuspect)
    {
        StringBuilder sbGrid = new StringBuilder(string.Empty);
        sbGrid = new StringBuilder(string.Empty);
        if (dtSuspect.Rows.Count > 0)
        {
            sbGrid.Append("<table width='100%'>");
            sbGrid.Append("<tr style='background-color: #7f7f7f; font-family: Arial; color: white; font-size: 12px; font-weight: bold' valign=top>");
            sbGrid.Append("<td  style='font-family: Arial; font-size: 12px;' align='left'> Sex </td>");
            sbGrid.Append("<td  style='font-family: Arial; font-size: 12px;' align='left'> Notes </td>");
            sbGrid.Append("</tr>");

            foreach (DataRow dr in dtSuspect.Rows)
            {
                sbGrid.Append("<tr valign=top>");
                sbGrid.AppendFormat("<td  style='font-family: Arial; font-size: 12px;' align='left'>  {0} </td>", dr["Sex"]);
                sbGrid.AppendFormat("<td  style='font-family: Arial; font-size: 12px;' align='left'>  {0} </td>", dr["Description"]);
                sbGrid.Append("</tr>");
            }
            sbGrid.Append("</table>");
        }
        else
        {
            sbGrid.Append("No Records found.");
        }

        return sbGrid.ToString();
    }

    public string GetACINotesDetails(DataTable dtACINote)
    {
        StringBuilder sbGrid = new StringBuilder(string.Empty);
        sbGrid = new StringBuilder(string.Empty);
        if (dtACINote.Rows.Count > 0)
        {
            sbGrid.Append("<table width='100%'>");
            sbGrid.Append("<tr style='background-color: #7f7f7f; font-family: Arial; color: white; font-size: 12px; font-weight: bold' valign=top>");
            sbGrid.Append("<td  style='font-family: Arial; font-size: 12px;' align='left'> Note Date </td>");
            sbGrid.Append("<td  style='font-family: Arial; font-size: 12px;' align='left'> Notes </td>");
            sbGrid.Append("</tr>");

            foreach (DataRow dr in dtACINote.Rows)
            {
                sbGrid.Append("<tr valign=top>");
                sbGrid.AppendFormat("<td  style='font-family: Arial; font-size: 12px;' align='left'>  {0} </td>", clsGeneral.FormatDBNullDateToDisplay(dr["Note_Date"]));
                sbGrid.AppendFormat("<td  style='font-family: Arial; font-size: 12px;' align='left'>  {0} </td>", dr["Note"]);
                sbGrid.Append("</tr>");
            }
            sbGrid.Append("</table>");
        }
        else
        {
            sbGrid.Append("No Records found.");
        }

        return sbGrid.ToString();
    }

    public string GetSonicNotesDetails(DataTable dtSonicNote)
    {
        StringBuilder sbGrid = new StringBuilder(string.Empty);
        sbGrid = new StringBuilder(string.Empty);
        if (dtSonicNote.Rows.Count > 0)
        {
            sbGrid.Append("<table width='100%'>");
            sbGrid.Append("<tr style='background-color: #7f7f7f; font-family: Arial; color: white; font-size: 12px; font-weight: bold' valign=top>");
            sbGrid.Append("<td  style='font-family: Arial; font-size: 12px;' align='left'> Note Date </td>");
            sbGrid.Append("<td  style='font-family: Arial; font-size: 12px;' align='left'> User </td>");
            sbGrid.Append("<td  style='font-family: Arial; font-size: 12px;' align='left'> Notes </td>");
            sbGrid.Append("</tr>");

            foreach (DataRow dr in dtSonicNote.Rows)
            {
                sbGrid.Append("<tr valign=top>");
                sbGrid.AppendFormat("<td  style='font-family: Arial; font-size: 12px;' align='left'>  {0} </td>", clsGeneral.FormatDBNullDateToDisplay(dr["Note_Date"]));
                sbGrid.AppendFormat("<td  style='font-family: Arial; font-size: 12px;' align='left'>  {0} </td>", dr["Updated_by_Name"]);
                sbGrid.AppendFormat("<td  style='font-family: Arial; font-size: 12px;' align='left'>  {0} </td>", dr["Note"]);
                sbGrid.Append("</tr>");
            }
            sbGrid.Append("</table>");
        }
        else
        {
            sbGrid.Append("No Records found.");
        }

        return sbGrid.ToString();
    }

    public StringBuilder Event_AbstactReportDOC(DataSet dsEvent, decimal _PK_Event, bool ShowAttachments, clsGeneral.Major_Coverage MajorCoverageType)
    {
        //DataSet dsEvent = clsEvent.GetEventAbstractLetterData(_PK_Event);

        StringBuilder strBody = new StringBuilder("");

        if (dsEvent != null && dsEvent.Tables.Count > 0 && dsEvent.Tables[0].Rows.Count > 0)
        {
            DataTable dtEvent = dsEvent.Tables[0];
            DataTable dtActionable_Event = dsEvent.Tables[1];
            DataTable dtBuilding = dsEvent.Tables[2];
            DataTable dtCamera = dsEvent.Tables[3];
            DataTable dtACINotes = dsEvent.Tables[4];
            DataTable dtSonicNotes = dsEvent.Tables[5];
            DataTable dtEventImages = dsEvent.Tables[6];
            DataTable dtVehicleInformation = dsEvent.Tables[7];
            DataTable dtSuspectInformation = dsEvent.Tables[8];

            FileStream fsMail = null;

            bool Is_Sonic_Event = Convert.ToBoolean(dtEvent.Rows[0]["Sonic_Event"]);

            if (Is_Sonic_Event)
                fsMail = new FileStream(AppConfig.DocumentsPath + @"\AbstractLetterTemplate\Event_AbstractReport_Sonic.htm", FileMode.Open, FileAccess.Read);
            else fsMail = new FileStream(AppConfig.DocumentsPath + @"\AbstractLetterTemplate\Event_AbstractReport.htm", FileMode.Open, FileAccess.Read);
            StreamReader rd = new StreamReader(fsMail);
            //StringBuilder strBody = new StringBuilder(rd.ReadToEnd().ToString());
            rd = new StreamReader(fsMail);
            strBody = new StringBuilder(rd.ReadToEnd().ToString());


            rd.Close();
            fsMail.Close();

            #region "ACI Reported Event"

            strBody = strBody.Replace("[Location]", Convert.ToString(dtEvent.Rows[0]["Location"]));
            strBody = strBody.Replace("[ACI_Event_ID]", Convert.ToString(dtEvent.Rows[0]["ACI_EventID"]));

            string strActionableEvent = string.Empty;

            if (!Is_Sonic_Event)
                dtActionable_Event.DefaultView.RowFilter = "Actionable_Event_Desc <> 'FROI Event/Other'"; //#Issue 3422

            DataTable dtFiltered_Event = dtActionable_Event.DefaultView.ToTable();

            if (dtFiltered_Event.Rows.Count > 0)
            {
                strActionableEvent = "<table cellpadding='4' cellspacing='0' width='100%'>";
                foreach (DataRow drEvent_Type in dtFiltered_Event.Rows)
                {
                    if (Convert.ToBoolean(drEvent_Type["Is_Checked"]))
                    {
                        strActionableEvent += "<tr style='page-break-inside: avoid'><td width='50%' align='left' valign='top' style='font-family: Arial; font-size: 12px;'>" + drEvent_Type["Actionable_Event_Desc"] + "</td><td width='50%' align='left' valign='top' style='font-family: Arial; font-size: 12px;'> Yes </td></tr>";
                    }
                    else
                    {
                        strActionableEvent += "<tr style='page-break-inside: avoid'><td width='50%' align='left' valign='top' style='font-family: Arial; font-size: 12px;'>" + drEvent_Type["Actionable_Event_Desc"] + "</td><td width='50%' align='left' valign='top' style='font-family: Arial; font-size: 12px;'> No </td></tr>";
                    }
                }
                strActionableEvent += "</table>";
            }
            strBody = strBody.Replace("[Actionable_Event_Type]", strActionableEvent);
            strBody = strBody.Replace("[Description_of_Event]", Convert.ToString(dtEvent.Rows[0]["Event_Desc"]));
            if (!string.IsNullOrEmpty(Convert.ToString(dtEvent.Rows[0]["Event_Start_Date"])))
                strBody = strBody.Replace("[Date_of_Event]", clsGeneral.FormatDBNullDateToDisplay(dtEvent.Rows[0]["Event_Start_Date"]));
            else
                strBody = strBody.Replace("[Date_of_Event]", string.Empty);

            strBody = strBody.Replace("[Event_Start_Time]", Convert.ToString(dtEvent.Rows[0]["Event_Start_Time"]));
            strBody = strBody.Replace("[Event_End_Time]", Convert.ToString(dtEvent.Rows[0]["Event_End_Time"]));


            strBody = strBody.Replace("[BuildingInformation]", GetBuildingDetailsDOC(dtBuilding));

            strBody = strBody.Replace("[Camera_Grid]", GetCameraDetailsDOC(dtCamera));

            strBody = strBody.Replace("[Acadian_Investigator_Name]", Convert.ToString(dtEvent.Rows[0]["Investigator_Name"]));
            strBody = strBody.Replace("[Acadian_Investigator_Email_Address]", Convert.ToString(dtEvent.Rows[0]["Investigator_Email"]));
            strBody = strBody.Replace("[Acadian_Investigator_Phone]", Convert.ToString(dtEvent.Rows[0]["Investigator_Phone"]));

            int ImageCounter = 0;

            ////string AttachmentDocPath = "Documents/EventImage";
            //if (!string.IsNullOrEmpty(Convert.ToString(dtEvent.Rows[0]["Event_Image"])) && File.Exists(AppConfig.DocumentsPath + "EventImage\\" + dtEvent.Rows[0]["Event_Image"]))
            //{
            //    ViewState["Attchments"] = dtEvent.Rows[0]["Event_Image"];
            //    //strBody = strBody.Replace("[Event_Image]", "<img  alt='' src='" + AppConfig.SiteURL + AttachmentDocPath + "/" + dtEvent.Rows[0]["Event_Image"] + "' Height='200' Width='200' />");
            //}
            //else
            //{
            //    // ViewState["Attchments"] = dtEvent.Rows[0]["Event_Image"];
            //    ViewState.Remove("Attchments");
            //    //strBody = strBody.Replace("[Event_Image]", string.Empty);
            //}

            string AttachmentDocPath = "Documents/EventImage";
            if (!DBNull.Value.Equals(dtEvent.Rows[0]["Event_Image"]) && File.Exists(Server.MapPath("..\\") + AttachmentDocPath + "/" + dtEvent.Rows[0]["Event_Image"]) && !Is_Sonic_Event)
            {
                //strBody = strBody.Replace("[Event_Image]", "<img  alt='' src='" + AppConfig.SiteURL + AttachmentDocPath + "/" + dtEvent.Rows[0]["Event_Image"] + "' Height='200' Width='200' />");
                _strAttachmentName = Convert.ToString(dtEvent.Rows[0]["Event_Image"]);
                //strBody = strBody.Replace("[Event_Image]", "<img src=\"cid:Event_Images_" + ImageCounter + "\" Height=\"288\" Width=\"352\" />");
                strBody = strBody.Replace("[Event_Image]", "<img  alt='' src='" + Server.MapPath("..\\") + AttachmentDocPath + "/" + dtEvent.Rows[0]["Event_Image"] + "' Height='288' Width='352' />");
                ImageCounter++;
            }
            else
            {
                strBody = strBody.Replace("[Event_Image]", string.Empty);
                _strAttachmentName = string.Empty;
            }

            strBody = strBody.Replace("[AL_FR_Number]", Convert.ToString(dtEvent.Rows[0]["AL_FR_Number"]));
            strBody = strBody.Replace("[DPD_FR_Number]", Convert.ToString(dtEvent.Rows[0]["DPD_FR_Number"]));
            strBody = strBody.Replace("[PL_FR_Number]", Convert.ToString(dtEvent.Rows[0]["PL_FR_Number"]));
            strBody = strBody.Replace("[Prop_FR_Number]", Convert.ToString(dtEvent.Rows[0]["Prop_FR_Number"]));
            strBody = strBody.Replace("[Event_Root_Cause]", Convert.ToString(dtEvent.Rows[0]["Event_Root_Cause"]));
            strBody = strBody.Replace("[How_Event_Prevented]", Convert.ToString(dtEvent.Rows[0]["How_Event_Prevented"]));
            strBody = strBody.Replace("[Financial_Loss]", string.Format("{0:C2}", dtEvent.Rows[0]["Financial_Loss"]));

            #endregion

            #region "Sonic Reported Event"

            strBody = strBody.Replace("[SRE#]", Convert.ToString(dtEvent.Rows[0]["Event_Number"]));
            _strEvent_Number = Convert.ToString(dtEvent.Rows[0]["Event_Number"]);
            strBody = strBody.Replace("[Monitoring_Hours]", Convert.ToString(dtEvent.Rows[0]["Monitoring_Hours"]));
            strBody = strBody.Replace("[Source_of_Information]", Convert.ToString(dtEvent.Rows[0]["Source_Of_Information"]));
            strBody = strBody.Replace("[Event_Level]", Convert.ToString(dtEvent.Rows[0]["Event_Level"]));
            strBody = strBody.Replace("[Budge#]", Convert.ToString(dtEvent.Rows[0]["Badge_Number"]));
            strBody = strBody.Replace("[Sonic_Contact_Name]", Convert.ToString(dtEvent.Rows[0]["Sonic_Contact_Name"]));
            strBody = strBody.Replace("[Sonic_Contact_Phone_#]", Convert.ToString(dtEvent.Rows[0]["Sonic_Contact_Phone"]));
            strBody = strBody.Replace("[Sonic_Contact_Email_Address]", Convert.ToString(dtEvent.Rows[0]["Sonic_Contact_Email"]));

            #endregion

            #region "Acadian Investigation"

            strBody = strBody.Replace("[Police_Called]", Convert.ToString(dtEvent.Rows[0]["Police_Called"]));
            strBody = strBody.Replace("[Video_Requested_By_Sonic]", Convert.ToString(dtEvent.Rows[0]["Video_Requested_By_Sonic"]));
            strBody = strBody.Replace("[Agency_Name]", Convert.ToString(dtEvent.Rows[0]["Agency_Name"]));
            strBody = strBody.Replace("[Officer_Name]", Convert.ToString(dtEvent.Rows[0]["Officer_Name"]));
            strBody = strBody.Replace("[Phone_#]", Convert.ToString(dtEvent.Rows[0]["Officer_Phone"]));
            strBody = strBody.Replace("[Police_Report_#]", Convert.ToString(dtEvent.Rows[0]["Police_Report_Number"]));
            strBody = strBody.Replace("[Incident_Report_Desc]", Convert.ToString(dtEvent.Rows[0]["Incident_Report_Desc"]));

            strBody = strBody.Replace("[Vehicle_Information_Grid]", GetVehicleDetailsDOC(dtVehicleInformation));
            strBody = strBody.Replace("[Suspect_Information_Grid]", GetSuspectDetailsDOC(dtSuspectInformation));
            strBody = strBody.Replace("[Acadian_Notes_Grid]", GetACINotesDetailsDOC(dtACINotes));

            strBody = strBody.Replace("[Status]", Convert.ToString(dtEvent.Rows[0]["Status"]));
            if (!string.IsNullOrEmpty(Convert.ToString(dtEvent.Rows[0]["Date_Closed"])))
                strBody = strBody.Replace("[Date_Closed]", clsGeneral.FormatDBNullDateToDisplay(dtEvent.Rows[0]["Date_Closed"]));
            else
                strBody = strBody.Replace("[Date_Closed]", string.Empty);

            strBody = strBody.Replace("[Sonic_Notes_Grid]", GetSonicNotesDetailsDOC(dtSonicNotes));
            //if (Is_Sonic_Event)
            //{
            //    strBody = strBody.Replace("[Sonic_Notes_Grid]", GetSonicNotesDetails(dtSonicNotes));
            //}

            #endregion

            #region "Images of Event"

            string strEventImages = string.Empty;
            if (dtEventImages.Rows.Count > 0)
            {
                strEventImages = "<table cellpadding='1' cellspacing='1' width='95%'>";

                foreach (DataRow drEvent_Images in dtEventImages.Rows)
                {
                    if (!string.IsNullOrEmpty(Convert.ToString(drEvent_Images["Attachment_Name"])) && File.Exists(AppConfig.DocumentsPath + "Attach\\" + drEvent_Images["Attachment_Name"]))
                    {
                        System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(AppConfig.SitePath + "Documents\\Attach\\" + drEvent_Images["Attachment_Name"]);

                        int originalWidth = bmp.Width;
                        int originalHeight = bmp.Height;

                        float ratioX = (float)700 / (float)originalWidth;
                        float ratioY = (float)300 / (float)originalHeight;
                        float ratio = Math.Min(ratioX, ratioY);

                        // New width and height based on aspect ratio
                        int newWidth = (int)(originalWidth * ratio);
                        int newHeight = (int)(originalHeight * ratio);

                        bmp.Dispose();

                        //strEventImages += "<tr style='page-break-inside: avoid'><td valign='top' align='center' border='3px solid'><img src=\"cid:Event_Images_" + ImageCounter + "\" BorderWidth='1px' BorderStyle='Solid' BorderColor='Black' Height='" + newHeight + "' Width='" + newWidth + "' /></td></tr>";
                        strEventImages += "<tr style='page-break-inside: avoid'><td valign='top' align='center' border='3px solid'><img src='" + AppConfig.SitePath + "Documents\\Attach\\" + drEvent_Images["Attachment_Name"] + "' BorderWidth='1px' BorderStyle='Solid' BorderColor='Black' Height='" + newHeight + "' Width='" + newWidth + "' /></td></tr>";
                        ImageCounter++;
                    }
                }
                strEventImages += "</table>";
            }

            strBody = strBody.Replace("[Images_of_Event]", strEventImages);

            #endregion
        }

        return strBody;

    }

    public string GetBuildingDetailsDOC(DataTable dtBuilding)
    {
        StringBuilder sbGrid = new StringBuilder(string.Empty);
        sbGrid = new StringBuilder(string.Empty);
        //sbGrid.Append("<tr><td style='font-size: 12px; font-family: Arial; font-weight: bold;page-break-inside : avoid' class='HeaderRow' colspan='6'>Attachments</td></tr>");
        //sbGrid.Append("<tr><td style='font-size: 12px; font-family: Arial; '  colspan='6'>");
        sbGrid.Append("<tr style='page-break-inside: avoid'><td colspan='6'> <table border='0' width='100%'>");
        sbGrid.Append("<tr style='page-break-inside: avoid'>");
        sbGrid.Append("<td style='font-size: 12px; font-family: Arial; font-weight: bold;page-break-inside : avoid' class='HeaderRow' colspan='6'>Buildings</td></tr>");
        sbGrid.Append("<tr style='page-break-inside: avoid'><td style='font-size: 12px; font-family: Arial;'  colspan='6'>");
        if (dtBuilding.Rows.Count > 0)
        {
            sbGrid.Append("<table width='100%' cellspacing='0' cellpadding='3' style='padding-bottom:5px;table-layout: fixed;white-space:nowrap;overflow: hidden;'>");
            sbGrid.Append("<tr valign='top' align='center'>");
            sbGrid.Append("<td style='background-color: #95B3D7;border-collapse: collapse;border-style: solid; border-color: Black; border-width: 1px;width:20%; align:left;' ><span style='font-size: 12px; font-family: Arial;'><b>Building Number</b></span></td>");
            sbGrid.Append("<td style='background-color: #95B3D7;border-collapse: collapse;border-style: solid; border-color: Black; border-width: 1px;width:40%; align:left;' ><span style='font-size: 12px; font-family: Arial;'><b>Address</b></span></td>");
            sbGrid.Append("<td style='background-color: #95B3D7;border-collapse: collapse;border-style: solid; border-color: Black; border-width: 1px;width:40%; align:left;' ><span style='font-size: 12px; font-family: Arial;'><b>Occupancy</b></span></td>");
            sbGrid.Append("</tr>");

            foreach (DataRow dr in dtBuilding.Rows)
            {
                sbGrid.Append("<tr valign=top>");
                sbGrid.AppendFormat("<td style='border-collapse: collapse;border-style: solid; border-color: Black; border-width: 1px;width:20%; align:left;' ><span style='font-size: 12px; font-family: Arial;'>  {0} </span> </td>", dr["Building_Number"]);
                sbGrid.AppendFormat("<td style='border-collapse: collapse;border-style: solid; border-color: Black; border-width: 1px;width:40%; align:left;' ><span style='font-size: 12px; font-family: Arial;'>  {0} </span> </td>", dr["Address"]);
                sbGrid.AppendFormat("<td style='border-collapse: collapse;border-style: solid; border-color: Black; border-width: 1px;width:40%; align:left;' ><span style='font-size: 12px; font-family: Arial;'>  {0} </span> </td>", dr["Occupancy"]);
                sbGrid.Append("</tr>");
            }
            sbGrid.Append("</table>");
            sbGrid.Append("</td>");
            sbGrid.Append("</tr>");
            sbGrid.Append("</table>");
        }
        else
        {
            sbGrid.Append("<table width='100%'>");
            sbGrid.Append("<tr valign='top' style='font-family: Arial; font-size: 12px; padding-left:20px;' align='center'><td align='left'>No Building Records Found.</td></tr>");
            sbGrid.Append("</table>");
            sbGrid.Append("</td>");
            sbGrid.Append("</tr>");
            sbGrid.Append("</table>");
        }
        sbGrid.Append("</td></tr>");
        sbGrid.Append("<tr><td>&nbsp;</td></tr>");
        return sbGrid.ToString();
    }

    public string GetCameraDetailsDOC(DataTable dtCamera)
    {
        StringBuilder sbGrid = new StringBuilder(string.Empty);
        sbGrid = new StringBuilder(string.Empty);
        if (dtCamera.Rows.Count > 0)
        {
            sbGrid.Append("<table width='100%' cellspacing='0' cellpadding='3' style='padding-bottom:5px;table-layout: fixed;white-space:nowrap;overflow: hidden;'>");
            sbGrid.Append("<tr valign='top' align='center'>");
            sbGrid.Append("<td style='background-color: #95B3D7;border-collapse: collapse;border-style: solid; border-color: Black; border-width: 1px;width:25%; align:left;' ><span style='font-size: 12px; font-family: Arial;'><b>Camera Name</b></span></td>");
            sbGrid.Append("<td style='background-color: #95B3D7;border-collapse: collapse;border-style: solid; border-color: Black; border-width: 1px;width:25%; align:left;' ><span style='font-size: 12px; font-family: Arial;'><b>Camera Number</b></span></td>");
            sbGrid.Append("<td style='background-color: #95B3D7;border-collapse: collapse;border-style: solid; border-color: Black; border-width: 1px;width:25%; align:left;' ><span style='font-size: 12px; font-family: Arial;'><b>Event Time From</b></span></td>");
            sbGrid.Append("<td style='background-color: #95B3D7;border-collapse: collapse;border-style: solid; border-color: Black; border-width: 1px;width:25%; align:left;' ><span style='font-size: 12px; font-family: Arial;'><b>Event Time To</b></span></td>");
            sbGrid.Append("</tr>");

            foreach (DataRow dr in dtCamera.Rows)
            {
                sbGrid.Append("<tr valign=top>");
                sbGrid.AppendFormat("<td style='border-collapse: collapse;border-style: solid; border-color: Black; border-width: 1px;width:20%; align:left;' ><span style='font-size: 12px; font-family: Arial;'>  {0} </span> </td>", dr["Camera_Name"]);
                sbGrid.AppendFormat("<td style='border-collapse: collapse;border-style: solid; border-color: Black; border-width: 1px;width:20%; align:left;' ><span style='font-size: 12px; font-family: Arial;'>  {0} </span> </td>", dr["Camera_Number"]);
                sbGrid.AppendFormat("<td style='border-collapse: collapse;border-style: solid; border-color: Black; border-width: 1px;width:20%; align:left;' ><span style='font-size: 12px; font-family: Arial;'>  {0} </span> </td>", dr["Event_Time_From"]);
                sbGrid.AppendFormat("<td style='border-collapse: collapse;border-style: solid; border-color: Black; border-width: 1px;width:20%; align:left;' ><span style='font-size: 12px; font-family: Arial;'>  {0} </span> </td>", dr["Event_Time_To"]);
                sbGrid.Append("</tr>");
            }
            sbGrid.Append("</table>");
        }
        else
        {
            sbGrid.Append("No Records found.");
        }

        return sbGrid.ToString();
    }

    public static string GetVehicleDetailsDOC(DataTable dtVehicle)
    {
        StringBuilder sbGrid = new StringBuilder(string.Empty);
        sbGrid = new StringBuilder(string.Empty);
        if (dtVehicle.Rows.Count > 0)
        {
            sbGrid.Append("<table width='100%' cellspacing='0' cellpadding='3' style='padding-bottom:5px;table-layout: fixed;white-space:nowrap;overflow: hidden;'>");
            sbGrid.Append("<tr valign='top' align='center' style='page-break-inside: avoid'>");
            sbGrid.Append("<td style='background-color: #95B3D7;border-collapse: collapse;border-style: solid; border-color: Black; border-width: 1px;width:20%; align:left;' ><span style='font-size: 12px; font-family: Arial;'><b>Make</b></span></td>");
            sbGrid.Append("<td style='background-color: #95B3D7;border-collapse: collapse;border-style: solid; border-color: Black; border-width: 1px;width:15%; align:left;' ><span style='font-size: 12px; font-family: Arial;'><b>Model </b></span></td>");
            sbGrid.Append("<td style='background-color: #95B3D7;border-collapse: collapse;border-style: solid; border-color: Black; border-width: 1px;width:15%; align:left;' ><span style='font-size: 12px; font-family: Arial;'><b>Color </b></span></td>");
            sbGrid.Append("<td style='background-color: #95B3D7;border-collapse: collapse;border-style: solid; border-color: Black; border-width: 1px;width:15%; align:left;' ><span style='font-size: 12px; font-family: Arial;'><b>License</b></span></td>");
            sbGrid.Append("<td style='background-color: #95B3D7;border-collapse: collapse;border-style: solid; border-color: Black; border-width: 1px;width:15%; align:left;' ><span style='font-size: 12px; font-family: Arial;'><b>State</b></span></td>");
            sbGrid.Append("<td style='background-color: #95B3D7;border-collapse: collapse;border-style: solid; border-color: Black; border-width: 1px;width:20%; align:left;' ><span style='font-size: 12px; font-family: Arial;'><b>Suspect Vehicle</b></span></td>");
            sbGrid.Append("</tr>");

            foreach (DataRow dr in dtVehicle.Rows)
            {
                sbGrid.Append("<tr valign=top style='page-break-inside: avoid'>");
                sbGrid.AppendFormat("<td style='border-collapse: collapse;border-style: solid; border-color: Black; border-width: 1px;width:20%; align:left;' ><span style='font-size: 12px; font-family: Arial;'>  {0} </span> </td>", dr["Make"]);
                sbGrid.AppendFormat("<td style='border-collapse: collapse;border-style: solid; border-color: Black; border-width: 1px;width:15%; align:left;' ><span style='font-size: 12px; font-family: Arial;'>  {0} </span> </td>", dr["Model"]);
                sbGrid.AppendFormat("<td style='border-collapse: collapse;border-style: solid; border-color: Black; border-width: 1px;width:15%; align:left;' ><span style='font-size: 12px; font-family: Arial;'>  {0} </span> </td>", dr["Color"]);
                sbGrid.AppendFormat("<td style='border-collapse: collapse;border-style: solid; border-color: Black; border-width: 1px;width:15%; align:left;' ><span style='font-size: 12px; font-family: Arial;'>  {0} </span> </td>", dr["License"]);
                sbGrid.AppendFormat("<td style='border-collapse: collapse;border-style: solid; border-color: Black; border-width: 1px;width:15%; align:left;' ><span style='font-size: 12px; font-family: Arial;'>  {0} </span> </td>", dr["STATE"]);
                sbGrid.AppendFormat("<td style='border-collapse: collapse;border-style: solid; border-color: Black; border-width: 1px;width:20%; align:left;' ><span style='font-size: 12px; font-family: Arial;'>  {0} </span> </td>", dr["Suspect_Vehicle"]);
                sbGrid.Append("</tr>");
            }
            sbGrid.Append("</table>");
        }
        else
        {
            sbGrid.Append("No Records found.");
        }

        return sbGrid.ToString();
    }

    public static string GetSuspectDetailsDOC(DataTable dtSuspect)
    {
        StringBuilder sbGrid = new StringBuilder(string.Empty);
        sbGrid = new StringBuilder(string.Empty);
        if (dtSuspect.Rows.Count > 0)
        {
            sbGrid.Append("<table width='100%' cellspacing='0' cellpadding='3' style='padding-bottom:5px;table-layout: fixed;white-space:nowrap;overflow: hidden;'>");
            sbGrid.Append("<tr valign='top' align='center'>");
            sbGrid.Append("<td style='background-color: #95B3D7;border-collapse: collapse;border-style: solid; border-color: Black; border-width: 1px;width:20%; align:left;' ><span style='font-size: 12px; font-family: Arial;'><b>Sex</b></span></td>");
            sbGrid.Append("<td style='background-color: #95B3D7;border-collapse: collapse;border-style: solid; border-color: Black; border-width: 1px;width:80%; align:left;' ><span style='font-size: 12px; font-family: Arial;'><b>Notes</b></span></td>");
            sbGrid.Append("</tr>");

            foreach (DataRow dr in dtSuspect.Rows)
            {
                sbGrid.Append("<tr valign=top>");
                sbGrid.AppendFormat("<td style='border-collapse: collapse;border-style: solid; border-color: Black; border-width: 1px;width:20%; align:left;' ><span style='font-size: 12px; font-family: Arial;'>  {0} </span> </td>", dr["Sex"]);
                sbGrid.AppendFormat("<td style='border-collapse: collapse;border-style: solid; border-color: Black; border-width: 1px;width:80%; align:left;' ><span style='font-size: 12px; font-family: Arial;'>  {0} </span> </td>", dr["Description"]);
                sbGrid.Append("</tr>");
            }
            sbGrid.Append("</table>");
        }
        else
        {
            sbGrid.Append("No Records found.");
        }

        return sbGrid.ToString();
    }

    public string GetACINotesDetailsDOC(DataTable dtACINote)
    {
        StringBuilder sbGrid = new StringBuilder(string.Empty);
        sbGrid = new StringBuilder(string.Empty);
        if (dtACINote.Rows.Count > 0)
        {
            sbGrid.Append("<table width='100%' cellspacing='0' cellpadding='3' style='padding-bottom:5px;table-layout: fixed;white-space:nowrap;overflow: hidden;'>");
            sbGrid.Append("<tr valign='top' align='center'>");
            sbGrid.Append("<td style='background-color: #95B3D7;border-collapse: collapse;border-style: solid; border-color: Black; border-width: 1px;width:20%; align:left;' ><span style='font-size: 12px; font-family: Arial;'><b>Note Date</b></span></td>");
            sbGrid.Append("<td style='background-color: #95B3D7;border-collapse: collapse;border-style: solid; border-color: Black; border-width: 1px;width:80%; align:left;' ><span style='font-size: 12px; font-family: Arial;'><b>Notes</b></span></td>");
            sbGrid.Append("</tr>");

            foreach (DataRow dr in dtACINote.Rows)
            {
                sbGrid.Append("<tr valign=top>");
                sbGrid.AppendFormat("<td style='border-collapse: collapse;border-style: solid; border-color: Black; border-width: 1px;width:20%; align:left;' ><span style='font-size: 12px; font-family: Arial;'>  {0} </span> </td>", clsGeneral.FormatDBNullDateToDisplay(dr["Note_Date"]));
                sbGrid.AppendFormat("<td style='border-collapse: collapse;border-style: solid; border-color: Black; border-width: 1px;width:80%; align:left;' ><span style='font-size: 12px; font-family: Arial;'>  {0} </span> </td>", dr["Note"]);
                sbGrid.Append("</tr>");
            }
            sbGrid.Append("</table>");
        }
        else
        {
            sbGrid.Append("No Records found.");
        }

        return sbGrid.ToString();
    }

    public string GetSonicNotesDetailsDOC(DataTable dtSonicNote)
    {
        StringBuilder sbGrid = new StringBuilder(string.Empty);
        sbGrid = new StringBuilder(string.Empty);
        if (dtSonicNote.Rows.Count > 0)
        {
            sbGrid.Append("<table width='100%' cellspacing='0' cellpadding='3' style='padding-bottom:5px;table-layout: fixed;white-space:nowrap;overflow: hidden;'>");
            sbGrid.Append("<tr valign='top' align='center'>");
            sbGrid.Append("<td style='background-color: #95B3D7;border-collapse: collapse;border-style: solid; border-color: Black; border-width: 1px;width:15%; align:left;' ><span style='font-size: 12px; font-family: Arial;'><b>Note Date</b></span></td>");
            sbGrid.Append("<td style='background-color: #95B3D7;border-collapse: collapse;border-style: solid; border-color: Black; border-width: 1px;width:15%; align:left;' ><span style='font-size: 12px; font-family: Arial;'><b>User</b></span></td>");
            sbGrid.Append("<td style='background-color: #95B3D7;border-collapse: collapse;border-style: solid; border-color: Black; border-width: 1px;width:70%; align:left;' ><span style='font-size: 12px; font-family: Arial;'><b>Notes</b></span></td>");
            sbGrid.Append("</tr>");

            foreach (DataRow dr in dtSonicNote.Rows)
            {
                sbGrid.Append("<tr valign=top>");
                sbGrid.AppendFormat("<td style='border-collapse: collapse;border-style: solid; border-color: Black; border-width: 1px;width:15%; align:left;' ><span style='font-size: 12px; font-family: Arial;'>  {0} </span> </td>", clsGeneral.FormatDBNullDateToDisplay(dr["Note_Date"]));
                sbGrid.AppendFormat("<td style='border-collapse: collapse;border-style: solid; border-color: Black; border-width: 1px;width:15%; align:left;' ><span style='font-size: 12px; font-family: Arial;'>  {0} </span> </td>", dr["Updated_by_Name"]);
                sbGrid.AppendFormat("<td style='border-collapse: collapse;border-style: solid; border-color: Black; border-width: 1px;width:70%; align:left;' ><span style='font-size: 12px; font-family: Arial;'>  {0} </span> </td>", dr["Note"]);
                sbGrid.Append("</tr>");
            }
            sbGrid.Append("</table>");
        }
        else
        {
            sbGrid.Append("No Records found.");
        }

        return sbGrid.ToString();
    }
    #endregion

    #region "Grid Events"

    /// <summary>
    /// gvEvent_Camera on Edit Or Delete
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    //protected void gvEvent_Camera_RowCommand(object sender, GridViewCommandEventArgs e)
    //{
    //    if (e.CommandName == "RemoveEventCamera")
    //    {
    //        #region
    //        clsEvent_Camera.DeleteByPK(Convert.ToDecimal(e.CommandArgument));

    //        BindEvent_CameraGrid();
    //        Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(1);", true);
    //        #endregion
    //    }
    //    else if (e.CommandName == "ViewEventCamera")
    //    {
    //        //Response.Redirect("Event_Note.aspx?nid=" + Encryption.Encrypt(e.CommandArgument.ToString()) + "&id=" + Encryption.Encrypt(PK_Event.ToString()) + "&iid=" + Encryption.Encrypt(FK_Incident.ToString()) + "&mode=" + StrOperation + "&type=ACI");

    //        Page.ClientScript.RegisterStartupScript(typeof(string), DateTime.Now.ToString(), "javascript:AciNotePopup('" + Encryption.Encrypt(e.CommandArgument.ToString()) + "','" + Encryption.Encrypt(PK_Event.ToString()) + "','" + Encryption.Encrypt(FK_Incident.ToString()) + "','" + StrOperation + "','ACI');", true);
    //    }
    //    else if (e.CommandName == "EditRecord")
    //    {
    //        _PK_Event_Camera = Convert.ToDecimal(e.CommandArgument);
    //        // show and hide Add-edit row
    //        trEvent_CameraGrid.Style.Add("display", "none");
    //        trEvent_Camera.Style.Add("display", "");
    //        btnEvent_CameraCancel.Style.Add("display", "inline");
    //        btnEvent_CameraAdd.Text = "Update";
    //        // get record from database

    //        clsEvent_Camera objEvent_Camera = new clsEvent_Camera(_PK_Event_Camera);
    //        txtCamera_Name.Text = objEvent_Camera.Camera_Name;
    //        txtCamera_Number.Text = objEvent_Camera.Camera_Number;
    //        txtEvent_Time_From.Text = objEvent_Camera.Event_Time_From;
    //        txtEvent_Time_To.Text = objEvent_Camera.Event_Time_To;
    //        ((ScriptManager)this.Master.FindControl("scMain")).SetFocus(txtCamera_Name);
    //    }
    //}

    /// <summary>
    /// Paging event of gvEvent_Camera
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    //protected void gvEvent_Camera_PageIndexChanging(object sender, GridViewPageEventArgs e)
    //{
    //    gvEvent_Camera.PageIndex = e.NewPageIndex; //Page new index call
    //    BindEvent_CameraGrid();
    //    Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(1);", true);
    //}

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
    /// gvSuspect_Information on Edit Or Delete
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvSuspect_Information_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "RemoveSuspectInformation")
        {
            #region
            clsSuspect_Information.DeleteByPK(Convert.ToDecimal(e.CommandArgument));

            BindSuspect_InformationGrid();
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(2);", true);
            #endregion
        }
        else if (e.CommandName == "ViewEventCamera")
        {
            Page.ClientScript.RegisterStartupScript(typeof(string), DateTime.Now.ToString(), "javascript:AciNotePopup('" + Encryption.Encrypt(e.CommandArgument.ToString()) + "','" + Encryption.Encrypt(PK_Event.ToString()) + "','" + Encryption.Encrypt(FK_Incident.ToString()) + "','" + StrOperation + "','ACI');", true);
        }
        else if (e.CommandName == "EditRecord")
        {
            _PK_Suspect_Information = Convert.ToDecimal(e.CommandArgument);
            // show and hide Add-edit row
            trACISuspect_InformationGrid.Style.Add("display", "none");
            trACISuspect_Information.Style.Add("display", "");
            btnSuspect_InfoCancel.Style.Add("display", "inline");
            btnSuspect_InfoAdd.Text = "Update";

            clsSuspect_Information objSuspect_Information = new clsSuspect_Information(_PK_Suspect_Information);
            txtSuspect_Information_Note.Text = objSuspect_Information.Description;

            if (objSuspect_Information.Sex != null)
                rdoSex.SelectedValue = Convert.ToString(objSuspect_Information.Sex);
            ((ScriptManager)this.Master.FindControl("scMain")).SetFocus(txtSuspect_Information_Note);
        }
    }

    /// <summary>
    /// gvVehicle_Information on Edit Or Delete
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvVehicle_Information_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "RemoveVehicleInformation")
        {
            #region
            clsVehicle_Information.DeleteByPK(Convert.ToDecimal(e.CommandArgument));

            BindVehicle_InformationGrid();
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(2);", true);
            #endregion
        }
        else if (e.CommandName == "ViewEventCamera")
        {
            Page.ClientScript.RegisterStartupScript(typeof(string), DateTime.Now.ToString(), "javascript:AciNotePopup('" + Encryption.Encrypt(e.CommandArgument.ToString()) + "','" + Encryption.Encrypt(PK_Event.ToString()) + "','" + Encryption.Encrypt(FK_Incident.ToString()) + "','" + StrOperation + "','ACI');", true);
        }
        else if (e.CommandName == "EditRecord")
        {
            ComboHelper.FillState(new DropDownList[] { ddlVehicle_InfoState }, 0, true);
            _PK_Vehicle_Information = Convert.ToDecimal(e.CommandArgument);
            // show and hide Add-edit row
            trACIVehicle_InformationGrid.Style.Add("display", "none");
            trACIVehicle_Information.Style.Add("display", "");
            btnVehicle_Info.Style.Add("display", "inline");
            btnVehicle_InfoAdd.Text = "Update";

            clsVehicle_Information objVehicle_Information = new clsVehicle_Information(_PK_Vehicle_Information);
            txtMake.Text = objVehicle_Information.Make;
            txtModel.Text = objVehicle_Information.Model;
            txtLicense.Text = objVehicle_Information.License;
            txtColor.Text = objVehicle_Information.Color;
            if (objVehicle_Information.FK_LU_State != null)
                ddlVehicle_InfoState.SelectedValue = Convert.ToString(objVehicle_Information.FK_LU_State);
            if (objVehicle_Information.Suspect_Vehicle != null)
                rdoSuspect_Vehicle.SelectedValue = Convert.ToString(objVehicle_Information.Suspect_Vehicle);
            ((ScriptManager)this.Master.FindControl("scMain")).SetFocus(txtMake);
        }
    }

    /// <summary>
    /// Paging event of gvSuspect_Information
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvSuspect_Information_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvSuspect_Information.PageIndex = e.NewPageIndex;
        BindVehicle_InformationGrid();
        Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(2);", true);
    }

    /// <summary>
    /// Paging event of gvVehicle_Information
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvVehicle_Information_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvVehicle_Information.PageIndex = e.NewPageIndex;
        BindVehicle_InformationGrid();
        Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(2);", true);
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

            BindACINoteGrid(ctrlPageAcadianNotes.CurrentPage, ctrlPageAcadianNotes.PageSize);
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
        BindACINoteGrid(ctrlPageAcadianNotes.CurrentPage, ctrlPageAcadianNotes.PageSize);
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

            BindSonicNoteGrid(ctrlPageSonicNotes.CurrentPage, ctrlPageSonicNotes.PageSize);
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(2);", true);
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
        BindSonicNoteGrid(ctrlPageSonicNotes.CurrentPage, ctrlPageSonicNotes.PageSize);
        Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(2);", true);
    }

    /// <summary>
    /// Handles Building grid row data bound event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvBuildingEdit_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        // if row type is data row
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            // get occupancies values bound to the grid
            Label lblOccupancy = (Label)e.Row.FindControl("lblOccupancy");
            bool bOccupancy_Sales_New = Convert.ToBoolean(DataBinder.Eval(e.Row.DataItem, "Occupancy_Sales_New"));
            bool bOccupancy_Body_Shop = Convert.ToBoolean(DataBinder.Eval(e.Row.DataItem, "Occupancy_Body_Shop"));
            bool bOccupancy_Parking_Lot = Convert.ToBoolean(DataBinder.Eval(e.Row.DataItem, "Occupancy_Parking_Lot"));
            bool bOccupancy_Sales_Used = Convert.ToBoolean(DataBinder.Eval(e.Row.DataItem, "Occupancy_Sales_Used"));
            bool bOccupancy_Parts = Convert.ToBoolean(DataBinder.Eval(e.Row.DataItem, "Occupancy_Parts"));
            bool bOccupancy_Raw_Land = Convert.ToBoolean(DataBinder.Eval(e.Row.DataItem, "Occupancy_Raw_Land"));
            bool bOccupancy_Service = Convert.ToBoolean(DataBinder.Eval(e.Row.DataItem, "Occupancy_Service"));
            bool bOccupancy_Ofifce = Convert.ToBoolean(DataBinder.Eval(e.Row.DataItem, "Occupancy_Ofifce"));
            bool bOccupancy_Main = Convert.ToBoolean(DataBinder.Eval(e.Row.DataItem, "Occupancy_Main"));


            string strOccupancy = ""; // used to set the comma seperated occupancies

            // append occupancy text with comma seperation depending on the values
            if (bOccupancy_Main) strOccupancy = "Main";
            if (bOccupancy_Sales_New) strOccupancy = strOccupancy != "" ? strOccupancy + ", " + "Sales - New" : "Sales - New";
            if (bOccupancy_Body_Shop) strOccupancy = strOccupancy != "" ? strOccupancy + ", " + "Body Shop" : "Body Shop";
            if (bOccupancy_Parking_Lot) strOccupancy = strOccupancy != "" ? strOccupancy + ", " + "Parking Lot" : "Parking Lot";
            if (bOccupancy_Sales_Used) strOccupancy = strOccupancy != "" ? strOccupancy + ", " + "Sales - Used" : "Sales - Used";
            if (bOccupancy_Parts) strOccupancy = strOccupancy != "" ? strOccupancy + ", " + "Parts" : "Parts";
            if (bOccupancy_Raw_Land) strOccupancy = strOccupancy != "" ? strOccupancy + ", " + "Raw Land" : "Raw Land";
            if (bOccupancy_Service) strOccupancy = strOccupancy != "" ? strOccupancy + ", " + "Service" : "Service";
            if (bOccupancy_Ofifce) strOccupancy = strOccupancy != "" ? strOccupancy + ", " + "Office" : "Office";

            // set text in occupancy column
            lblOccupancy.Text = strOccupancy;
        }
    }

    /// <summary>
    /// Handles Building grid row data bound event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvBuildingEditACI_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        // if row type is data row
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            // get occupancies values bound to the grid
            Label lblOccupancy = (Label)e.Row.FindControl("lblOccupancy");
            bool bOccupancy_Sales_New = Convert.ToBoolean(DataBinder.Eval(e.Row.DataItem, "Occupancy_Sales_New"));
            bool bOccupancy_Body_Shop = Convert.ToBoolean(DataBinder.Eval(e.Row.DataItem, "Occupancy_Body_Shop"));
            bool bOccupancy_Parking_Lot = Convert.ToBoolean(DataBinder.Eval(e.Row.DataItem, "Occupancy_Parking_Lot"));
            bool bOccupancy_Sales_Used = Convert.ToBoolean(DataBinder.Eval(e.Row.DataItem, "Occupancy_Sales_Used"));
            bool bOccupancy_Parts = Convert.ToBoolean(DataBinder.Eval(e.Row.DataItem, "Occupancy_Parts"));
            bool bOccupancy_Raw_Land = Convert.ToBoolean(DataBinder.Eval(e.Row.DataItem, "Occupancy_Raw_Land"));
            bool bOccupancy_Service = Convert.ToBoolean(DataBinder.Eval(e.Row.DataItem, "Occupancy_Service"));
            bool bOccupancy_Ofifce = Convert.ToBoolean(DataBinder.Eval(e.Row.DataItem, "Occupancy_Ofifce"));
            bool bOccupancy_Main = Convert.ToBoolean(DataBinder.Eval(e.Row.DataItem, "Occupancy_Main"));


            string strOccupancy = ""; // used to set the comma seperated occupancies

            // append occupancy text with comma seperation depending on the values
            if (bOccupancy_Main) strOccupancy = "Main";
            if (bOccupancy_Sales_New) strOccupancy = strOccupancy != "" ? strOccupancy + ", " + "Sales - New" : "Sales - New";
            if (bOccupancy_Body_Shop) strOccupancy = strOccupancy != "" ? strOccupancy + ", " + "Body Shop" : "Body Shop";
            if (bOccupancy_Parking_Lot) strOccupancy = strOccupancy != "" ? strOccupancy + ", " + "Parking Lot" : "Parking Lot";
            if (bOccupancy_Sales_Used) strOccupancy = strOccupancy != "" ? strOccupancy + ", " + "Sales - Used" : "Sales - Used";
            if (bOccupancy_Parts) strOccupancy = strOccupancy != "" ? strOccupancy + ", " + "Parts" : "Parts";
            if (bOccupancy_Raw_Land) strOccupancy = strOccupancy != "" ? strOccupancy + ", " + "Raw Land" : "Raw Land";
            if (bOccupancy_Service) strOccupancy = strOccupancy != "" ? strOccupancy + ", " + "Service" : "Service";
            if (bOccupancy_Ofifce) strOccupancy = strOccupancy != "" ? strOccupancy + ", " + "Office" : "Office";

            // set text in occupancy column
            lblOccupancy.Text = strOccupancy;
        }
    }
    /// <summary>
    /// Handles Building grid rowcommand event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvBuildingEdit_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "ViewBuildingDetail")// if passed command is for viewing building details
        {
            // navigate to property page
            Response.Redirect(AppConfig.SiteURL + "SONIC/Exposures/PropertyView.aspx?loc=" + Encryption.Encrypt(Convert.ToString(e.CommandArgument)) + "&pnl=2", true);

        }
        else if (e.CommandName == "RemoveEventBuilding") // if passed command is for removing building details
        {
            // delete from Event_Link_Building table
            clsEvent_Link_Building.DeleteByPK(Convert.ToInt32(e.CommandArgument));
            BindGridBuilding();
        }
    }

    /// <summary>
    /// Handles Building ACI screen grid rowcommand event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    //protected void gvBuildingEditACI_RowCommand(object sender, GridViewCommandEventArgs e)
    //{
    //    if (e.CommandName == "ViewBuildingDetail")// if passed command is for viewing building details
    //    {
    //        // navigate to property page
    //        Response.Redirect(AppConfig.SiteURL + "SONIC/Exposures/PropertyView.aspx?loc=" + Encryption.Encrypt(Convert.ToString(e.CommandArgument)) + "&pnl=2", true);

    //    }
    //    else if (e.CommandName == "RemoveEventBuilding") // if passed command is for removing building details
    //    {
    //        // delete from Event_Link_Building table
    //        clsEvent_Link_Building.DeleteByPK(Convert.ToInt32(e.CommandArgument));
    //        BindBuilding_ACI();
    //    }
    //}

    /// <summary>
    /// GridView Sorting Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvACI_Notes_Sorting(object sender, GridViewSortEventArgs e)
    {
        // update sort field and sort order and bind the grid
        SortOrder = (SortBy == e.SortExpression) ? (SortOrder == "asc" ? "desc" : "asc") : "asc";
        SortBy = e.SortExpression;
        BindACINoteGrid(ctrlPageAcadianNotes.CurrentPage, ctrlPageAcadianNotes.PageSize);
    }

    /// <summary>
    /// GridView Sorting Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvSonic_Notes_Sorting(object sender, GridViewSortEventArgs e)
    {
        // update sort field and sort order and bind the grid
        SortOrder = (SortBy == e.SortExpression) ? (SortOrder == "asc" ? "desc" : "asc") : "asc";
        SortBy = e.SortExpression;
        BindSonicNoteGrid(ctrlPageSonicNotes.CurrentPage, ctrlPageSonicNotes.PageSize);
    }
    #endregion

}