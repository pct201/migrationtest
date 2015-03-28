using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERIMS.DAL;
using System.Data;
using System.IO;

public partial class Event_Event : clsBasePage
{
    #region Properties

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
    /// Denotes the operation whether edit or view
    /// </summary>
    public string StrOperation
    {
        get { return ViewState["StrOperation"] != null ? Convert.ToString(ViewState["StrOperation"]) : "view"; }
        set { ViewState["StrOperation"] = value; }
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
    public decimal _PK_SONIC_Notes
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_SONIC_Notes"]);
        }
        set { ViewState["PK_SONIC_Notes"] = value; }
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

            if (StrOperation.ToLower() == "add")
            {
                Session.Remove("Eventcriteria");
                ImgEvent_Image.Style["display"] = "none";
                BindACINoteGrid(); BindSonicNoteGrid();
                
            }
            if (PK_Event > 0)
            {
                if (StrOperation.ToLower() == "view")
                {
                    BindDetailForView();
                }
                else
                {
                    if (App_Access == AccessType.View_Only) Response.Redirect(AppConfig.SiteURL + "Error.aspx?msg=errAcc");

                    BindDropDownList();
                    BindDetailsForEdit();

                    if (StrOperation.ToLower() != "addto") StrOperation = "edit";
                    else btnViewAudit.Visible = false;
                }
                //ucIncidentInfo.Visible = true;
                //ucIncidentInfo.CurrentTab = Convert.ToString(Controls_IncidentTab_IncidentTab.Tab.Event);
                //ucIncidentInfo.FillIncidentInformation(FK_Incident, PK_Event, 0);
            }
            else
            {
                if (App_Access == AccessType.View_Only)
                    Response.Redirect(AppConfig.SiteURL + "Error.aspx?msg=errAcc");
                //else if (FK_Incident < 1)
                //    Response.Redirect(AppConfig.SiteURL + "Error.aspx?msg=errAcc"); //Redirect To the Incident Selection page
                //ucIncidentInfo.Visible = true;
                //ucIncidentInfo.FillIncidentInformation(FK_Incident, 0, 0);

                PK_Event = 0;
                StrOperation = "add"; dvView.Visible = false; btnViewAudit.Visible = false;
                btnBack.Visible = false;
                BindDropDownList();
                if (!string.IsNullOrEmpty(Convert.ToString(Request.QueryString["loc"])))//Any events added from Exposure link will set Event.[Sonic_Event] =’Yes’ Issue Mail Sub: ACI - Sonic bugs
                {
                    ddlFK_LU_Sonic_Event.SelectedValue = "Y";
                    ddlFK_LU_Sonic_Event.Enabled = false;
                    clsGeneral.SetDropdownValue(ddlLocation, Encryption.Decrypt(Convert.ToString(Request.QueryString["loc"])), true);
                }
                //clsGeneral.SetDropdownValue(ddlLocation, Encryption.Decrypt(Convert.ToString(Request.QueryString["loc"])),true);
            }
            ddlFK_LU_Sonic_Event_SelectedIndexChanged(null, null);
            ddlLocation_SelectedIndexChanged(null, null);
        }
        else
        {
        }
        Page.ClientScript.RegisterStartupScript(typeof(string), DateTime.Now.ToString(), "javascript:ShowPanel(" + hdnPanel.Value + ");", true);
        ucIncident.SetSelectedTab(Controls_IncidentTab_IncidentTab.Tab.Event);
        ContactNameVisibility();
    }

    /// <summary>
    /// Save Button Click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSave_Click(object sender, EventArgs e)
    {
        SaveRecord();
        if (StrOperation.ToLower() == "add" || StrOperation.ToLower() == "addto" || StrOperation.ToLower() == "")
        {
            Response.Redirect("Event.aspx?eid=" + Encryption.Encrypt(PK_Event.ToString()) + "&iid=" + Encryption.Encrypt(FK_Incident.ToString()) + "&mode=edit&pnl=" + hdnPanel.Value, true);
        }
        else
        {
            StrOperation = "edit";
            BindDetailsForEdit();
            // set user control values
            //ucIncidentInfo.FillIncidentInformation(FK_Incident, PK_Event, 0);
        }
        Page.ClientScript.RegisterStartupScript(typeof(string), DateTime.Now.ToString(), "javascript:ShowPanel(" + hdnPanel.Value + ");", true);
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
        if (PK_Event > 0)
        {
            //ucIncident.MoveToTab(FK_Incident, PK_Event, 0);
        }
        else
        {

        }
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

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("EventSearch.aspx?criteria=1", true);
    }

    /// <summary>
    /// Add ACI Notes Click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkAddACINotesNew_Click(object sender, EventArgs e)
    {
        btnACINotesAdd.Text = "Add";
        _PK_ACI_Notes = 0;
        trACINotesGrid.Style.Add("display", "none");
        trACINotes.Style.Add("display", "");
        btnACINotesCancel.Style.Add("display", "inline");
        txtACI_Notes_Date.Text = string.Empty;
        txtACI_Notes.Text = string.Empty;
        ((ScriptManager)this.Master.FindControl("scMain")).SetFocus(txtACI_Notes_Date);
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
        txtACI_Notes_Date.Text = string.Empty;
        txtACI_Notes.Text = string.Empty;
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
        objACI_Notes.Note_Date = clsGeneral.FormatNullDateToStore(txtACI_Notes_Date.Text);
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
        BindSonicNoteGrid();
        //Cancel CLick
        btnACINotesCancel_Click(null, null);
    }

    /// Used to Clear the controls
    /// </summary>
    private void ClearACINoteControls()
    {
        //clear control
        _PK_ACI_Notes = 0;
        txtACI_Notes.Text = string.Empty;
        txtACI_Notes_Date.Text = string.Empty;
    }

    /// <summary>
    /// Add Sonic Notes CLick
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkAddSONICNotesNew_Click(object sender, EventArgs e)
    {
        btnSONICNotesAdd.Text = "Add";
        _PK_SONIC_Notes = 0;
        trSONICNotesGrid.Style.Add("display", "none");
        trSONICNotes.Style.Add("display", "");
        btnSONICNotesCancel.Style.Add("display", "inline");
        //txtSONIC_Notes_Date.Text = string.Empty;
        txtSonic_Notes.Text = string.Empty;
        //((ScriptManager)this.Master.FindControl("scMain")).SetFocus(txtSONIC_Notes_Date);
    }

    /// <summary>
    /// Cancel Sonic Notes
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSONICNotesCancel_Click(object sender, EventArgs e)
    {
        trSONICNotesGrid.Style.Add("display", "");
        trSONICNotes.Style.Add("display", "none");
        btnSONICNotesCancel.Style.Add("display", "none");
        //txtSONIC_Notes_Date.Text = string.Empty;
        txtSonic_Notes.Text = string.Empty;
    }

    /// <summary>
    /// Sonic NOtes save
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSONICNotesAdd_Click(object sender, EventArgs e)
    {
        SaveRecord();

        clsSonic_Event_Notes objSOIC_Notes = new clsSonic_Event_Notes();

        objSOIC_Notes.PK_Sonic_Event_Notes = _PK_SONIC_Notes;
        //objSOIC_Notes.Note_Date = clsGeneral.FormatNullDateToStore(txtSONIC_Notes_Date.Text);
        objSOIC_Notes.Note = txtSonic_Notes.Text.Trim();
        objSOIC_Notes.FK_Event = PK_Event;

        if (_PK_SONIC_Notes > 0)
        {
            objSOIC_Notes.Update();
        }
        else
        {
            objSOIC_Notes.Insert();
        }

        //clear Control
        ClearSONICNoteControls();
        //Bind Grid Function
        BindACINoteGrid();
        BindSonicNoteGrid();
        //Cancel CLick
        btnSONICNotesCancel_Click(null, null);
    }

    protected void ddlFK_LU_Sonic_Event_SelectedIndexChanged(object sender, EventArgs e)
    {

        if (ddlFK_LU_Sonic_Event.SelectedValue == "Y")
        {
            EnableDisableAllControl(true);
        }
        else
        {
            EnableDisableAllControl(false);
        }
    }

    private void EnableDisableAllControl(bool IsEnableDisable)
    {
        ddlLocation.Enabled = IsEnableDisable;
        txtEventNumber.Enabled = IsEnableDisable;
        txtCameraName.Enabled = IsEnableDisable;
        txtCameraNumber.Enabled = IsEnableDisable;
        txtCurrentDate.Enabled = IsEnableDisable;
        txtDate_Sent.Enabled = IsEnableDisable;
        txtEvent_End_Time.Enabled = IsEnableDisable;
        txtEvent_Start_Time.Enabled = IsEnableDisable;
        txtEventOccuranceDate.Enabled = IsEnableDisable;
        txtEventReportDate.Enabled = IsEnableDisable;
        txtOther_Event_Desc.Enabled = IsEnableDisable;
        txtOther_Event_Type.Enabled = IsEnableDisable;
        txtInvestigationReportDate.Enabled = IsEnableDisable;
        lstEventType.Enabled = IsEnableDisable;
        lstEventDescription.Enabled = IsEnableDisable;
    }

    /// Used to Clear the controls
    /// </summary>
    private void ClearSONICNoteControls()
    {
        //clear control
        _PK_SONIC_Notes = 0;
        txtSonic_Notes.Text = string.Empty;
        //txtSonic_Notes_Date.Text = string.Empty;
    }
    #endregion

    #region Page Methods

    /// <summary>
    /// Event Called When Page is open on Edit Mode
    /// </summary>
    private void BindDetailsForEdit()
    {
        dvView.Visible = false;
        dvEdit.Visible = true;

        btnSave.Visible = true;
        btnBack.Visible = false;
        clsEvent objEvent = new clsEvent(PK_Event);
        if (PK_Event > 0)
        {
            if (objEvent.FK_Incident != null)
                FK_Incident = Convert.ToDecimal(objEvent.FK_Incident);

            txtEventNumber.Text = Convert.ToString(objEvent.Event_Number);

            if (objEvent.FK_LU_Location != null)
            {
                clsGeneral.SetDropdownValue(ddlLocation, objEvent.FK_LU_Location, true);
            }

            //if (objEvent.FK_LU_Event_Type != null) ddlEventType.SelectedValue = Convert.ToString(objEvent.FK_LU_Event_Type);

            DataSet dsEvent_Type = clsAssoc_Event_Type.SelectByFK_Event(PK_Event);
            if (dsEvent_Type.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow drEvent_Type in dsEvent_Type.Tables[0].Rows)
                {
                    foreach (ListItem lstEventName in lstEventType.Items)
                    {
                        if (lstEventName.Value == drEvent_Type["FK_LU_Event_Type"].ToString())
                        {
                            lstEventName.Selected = true;
                        }
                    }
                }
            }

            DataSet dsEvent_Description = clsAssoc_Event_Description.SelectByFK_Event(PK_Event);
            if (dsEvent_Description.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow drEvent_Description in dsEvent_Description.Tables[0].Rows)
                {
                    foreach (ListItem lstEventDesc in lstEventDescription.Items)
                    {
                        if (lstEventDesc.Value == drEvent_Description["FK_LU_Event_Description"].ToString())
                        {
                            lstEventDesc.Selected = true;
                        }
                    }
                }
            }

            txtOther_Event_Type.Text = objEvent.Other_Event_Type;
            txtOther_Event_Desc.Text = objEvent.Other_Event_Desc;
            txtCameraName.Text = objEvent.Camera_Name != null ? objEvent.Camera_Name : "";
            txtCameraNumber.Text = objEvent.Camera_Number != null ? objEvent.Camera_Number : "";
            clsGeneral.SetDropdownValue(ddlFK_LU_Sonic_Event, objEvent.Sonic_Event, true);
            txtDate_Sent.Text = clsGeneral.FormatDBNullDateToDisplay(objEvent.Date_Sent);
            txtInvestigationReportDate.Text = clsGeneral.FormatDBNullDateToDisplay(objEvent.Investigation_Report_Date);
            txtEventReportDate.Text = clsGeneral.FormatDBNullDateToDisplay(objEvent.Event_Report_Date);
            txtEventOccuranceDate.Text = clsGeneral.FormatDBNullDateToDisplay(objEvent.Event_Occurence_Date);
            txtEvent_Start_Time.Text = objEvent.Event_Start_Time;
            txtEvent_End_Time.Text = objEvent.Event_End_Time;

            BindACINoteGrid();
            BindSonicNoteGrid();

            #region Event Image
            string _strSiteURL;
            _strSiteURL = String.Concat(HttpContext.Current.Request.Url.Scheme + "://", HttpContext.Current.Request.Url.Authority, HttpContext.Current.Request.ApplicationPath);
            if (!_strSiteURL.EndsWith("/")) _strSiteURL = String.Concat(_strSiteURL, "/");


            //_strSiteURL = _strSiteURL.Replace("localhost", "192.168.0.118");
            string AttachmentDocPath = "Documents/EventImage";
            string DocPath = string.Concat(_strSiteURL, AttachmentDocPath) + "/";

            if (objEvent.Event_Image != null)
                hdnImageName.Value = objEvent.Event_Image;
            else
                hdnImageName.Value = "";

            #endregion

            if (!string.IsNullOrEmpty(objEvent.Event_Image) && File.Exists(Server.MapPath("..\\") + AttachmentDocPath + "/" + objEvent.Event_Image))
            {
                ImgEvent_Image.Style["display"] = "";
                ImgEvent_Image.ImageUrl = Convert.ToString(AppConfig.SiteURL + AttachmentDocPath + "/" + objEvent.Event_Image);
                //ImgEvent_Image.ImageUrl = Convert.ToString(AppConfig.ImageURL + objEvent.Event_Image);
            }
            else
                ImgEvent_Image.Style["display"] = "none";


            //txtDateSentToClient.Text = clsGeneral.FormatDBNullDateToDisplay(objEvent.Date_Sent);
            //txtEvent_Desc.Text = objEvent.Event_Desc != null ? objEvent.Event_Desc : "";
            //if (objEvent.FK_LU_Event_Description != null)
            //{
            //    clsGeneral.SetDropdownValue(ddlFK_LU_Event_Description, objEvent.FK_LU_Event_Description, true);
            //}




            //if (objEvent.Sonic_Event != null)
            //{
            //    ddlSonicEvent.SelectedValue = objEvent.Sonic_Event;
            //}

            //txtDate_Opened.Text = clsGeneral.FormatDBNullDateToDisplay(objEvent.Date_Opened);

            ////Event Company Information
            //txtCompany.Text = objEvent.Company != null ? objEvent.Company : "";
            //if (objEvent.FK_LU_Location != null) ddlCompanyLocation.SelectedValue = Convert.ToString(objEvent.FK_LU_Location);
            ////txtCompanyLocation.Text = objEvent.Company_Location != null ? objEvent.Company_Location : "";
            //txtCompanyAddress1.Text = objEvent.Company_Address_1 != null ? objEvent.Company_Address_1 : "";
            //txtCompanyAddress2.Text = objEvent.Company_Address_2 != null ? objEvent.Company_Address_2 : "";
            //txtCompanyCity.Text = objEvent.Company_City != null ? objEvent.Company_City : "";
            //if (objEvent.FK_LU_State != null) ddlCompanyState.SelectedValue = Convert.ToString(objEvent.FK_LU_State);

            //txtCompanyZipcode.Text = objEvent.Company_ZIP != null ? objEvent.Company_ZIP : "";
            //if (objEvent.Company_County != null) ddlCompanyCountry.SelectedIndex = ddlCompanyCountry.Items.IndexOf(ddlCompanyCountry.Items.FindByText(objEvent.Company_County));

            txtFirstNameContact.Text = objEvent.Company_Contact_First_Name != null ? objEvent.Company_Contact_First_Name : "";
            txtMiddleNameContact.Text = objEvent.Company_Contact_Middle_name != null ? objEvent.Company_Contact_Middle_name : "";
            txtLastNameContact.Text = objEvent.Company_Contact_Last_Name != null ? objEvent.Company_Contact_Last_Name : "";

            txtTelephoneNumber1.Text = objEvent.Company_Contact_Phone != null ? objEvent.Company_Contact_Phone : "";
            txtEmailAddress.Text = objEvent.Company_Contact_Email != null ? objEvent.Company_Contact_Email : "";
            txtTelephoneNumber2.Text = objEvent.Company_Contact_Fax != null ? objEvent.Company_Contact_Fax : "";

            ////Event Vehicle Information
            //txtVehicleNo.Text = objEvent.Vehicle_Number != null ? objEvent.Vehicle_Number : "";
            //txtVIN.Text = objEvent.VIN != null ? objEvent.VIN : "";
            //txtMake.Text = objEvent.Make != null ? objEvent.Make : "";
            //txtModel.Text = objEvent.Model != null ? objEvent.Model : "";
            //txtYear.Text = objEvent.Year != null ? objEvent.Year : "";
            txtTitle.Text = objEvent.Company_Titled != null ? objEvent.Company_Titled : "";
            //txtLicenseTag.Text = objEvent.License_Tag != null ? objEvent.License_Tag : "";
            //if (objEvent.FK_LU_State_Registered != null) ddlStateRegistered.SelectedValue = Convert.ToString(objEvent.FK_LU_State_Registered);

            ////Event Police Information
            //txtPoliceDeptName.Text = objEvent.Police_Dept_Name != null ? objEvent.Police_Dept_Name : "";
            //txtPolicePhone.Text = objEvent.Police_Phone != null ? objEvent.Police_Phone : "";
            //txtOfficeFirstName.Text = objEvent.Police_Contact_First_Name != null ? objEvent.Police_Contact_First_Name : "";
            //txtOfficerMiddleName.Text = objEvent.Police_Contact_Middle_name != null ? objEvent.Police_Contact_Middle_name : "";
            //txtOfficerLastName.Text = objEvent.Police_Contact_Last_Name != null ? objEvent.Police_Contact_Last_Name : "";
            //txtBadgeNo.Text = objEvent.Badge_Number != null ? objEvent.Badge_Number : "";
            //txtPoliceFax.Text = objEvent.Facsimile != null ? objEvent.Facsimile : "";
            //txtPoliceCellNo.Text = objEvent.Police_Contact_Cell_Phone != null ? objEvent.Police_Contact_Cell_Phone : "";
            //txtPoliceCity.Text = objEvent.Police_Contact_City != null ? objEvent.Police_Contact_City : "";
            //txtPoliceAddress1.Text = objEvent.Address_1 != null ? objEvent.Address_1 : "";
            //if (objEvent.FK_LU_Police_Dept_State != null) ddlPoliceState.SelectedValue = Convert.ToString(objEvent.FK_LU_Police_Dept_State);

            //txtPoliceAddress2.Text = objEvent.Address_2 != null ? objEvent.Address_2 : "";
            //txtPoliceZip.Text = objEvent.ZIP != null ? objEvent.ZIP : "";
            //txtJurisdiction.Text = objEvent.Jurisdiction != null ? objEvent.Jurisdiction : "";
            //txtPoliceReportNo.Text = objEvent.Police_Report_Number != null ? objEvent.Police_Report_Number : "";
            //txtCaseNo.Text = objEvent.Case_Number != null ? objEvent.Case_Number : "";
            //txtPoliceReportOrderDate.Text = clsGeneral.FormatDBNullDateToDisplay(objEvent.Report_Ordered_Date);
            //txtPoliceReportReceivedDate.Text = clsGeneral.FormatDBNullDateToDisplay(objEvent.Report_Recieved_Date);
            lblLastModifiedDateTime.Text = objEvent.Update_Date == null ? "" : "Last Modified Date/Time : " + objEvent.Update_Date.Value.ToString("MM/dd/yyyy hh:mm:ss tt") + " ";
        }
    }

    /// <summary>
    /// Event Called When Page is open in View Mode
    /// </summary>
    private void BindDetailForView()
    {
        dvView.Visible = true;
        dvEdit.Visible = false;
        btnSave.Visible = false;

        ComboHelper.FillEventType(new ListBox[] { lbllstEventType }, false);
        ComboHelper.FillEventDescription(new ListBox[] { lbllstEventDescription });

        clsEvent objEvent = new clsEvent(PK_Event);
        if (PK_Event > 0)
        {
            //Event
            if (objEvent.FK_Incident != null)
                FK_Incident = Convert.ToDecimal(objEvent.FK_Incident);

            lblEventNumber.Text = Convert.ToString(objEvent.Event_Number);
            if (objEvent.FK_LU_Location != null)
                lblLocation.Text = new clsAci_Lu_Location((decimal)objEvent.FK_LU_Location).Fld_Desc;
            else
                lblLocation.Text = "";

            //if (objEvent.FK_LU_Event_Type != null)
            //    lblEventType.Text = new clsLU_Event_Type((decimal)objEvent.FK_LU_Event_Type).Fld_Desc;
            //else
            //    lblEventType.Text = "";

            DataSet dsEvent_Type = clsAssoc_Event_Type.SelectEventTypeByFK_Event(PK_Event);
            if (dsEvent_Type.Tables[0].Rows.Count > 0)
            {
                lblEventType.Text = Convert.ToString(dsEvent_Type.Tables[0].Rows[0]["Event_Type"]);
            }
            else
                lblEventType.Text = string.Empty;


            DataSet dsEvent_Description = clsAssoc_Event_Description.SelectEventDescriptionByFK_Event(PK_Event);
            if (dsEvent_Description.Tables[0].Rows.Count > 0)
            {
                lblEvent_Desc.Text = Convert.ToString(dsEvent_Description.Tables[0].Rows[0]["Event_Description"]);
            }
            else
                lblEvent_Desc.Text = string.Empty;

            lblOther_Event_Type.Text = objEvent.Other_Event_Type;
            lblOther_Event_Desc.Text = objEvent.Other_Event_Desc;
            lblCameraName.Text = objEvent.Camera_Name != null ? objEvent.Camera_Name : "";
            lblCameraNumber.Text = objEvent.Camera_Number != null ? objEvent.Camera_Number : "";
            lblFK_LU_Sonic_Event.Text = objEvent.Sonic_Event == "Y" ? "Yes" : "No";
            lblDate_Sent.Text = clsGeneral.FormatDBNullDateToDisplay(objEvent.Date_Sent);
            lblInvestigationDate.Text = clsGeneral.FormatDBNullDateToDisplay(objEvent.Investigation_Report_Date);
            lblEventReportDate.Text = clsGeneral.FormatDBNullDateToDisplay(objEvent.Event_Report_Date);
            lblEventOccuranceDate.Text = clsGeneral.FormatDBNullDateToDisplay(objEvent.Event_Occurence_Date);
            lblEvent_Start_Time.Text = objEvent.Event_Start_Time;
            lblEvent_End_Time.Text = objEvent.Event_End_Time;

            BindACINoteGrid();
            BindSonicNoteGrid();

            #region Event Image
            string _strSiteURL;
            _strSiteURL = String.Concat(HttpContext.Current.Request.Url.Scheme + "://", HttpContext.Current.Request.Url.Authority, HttpContext.Current.Request.ApplicationPath);
            if (!_strSiteURL.EndsWith("/")) _strSiteURL = String.Concat(_strSiteURL, "/");


            //_strSiteURL = _strSiteURL.Replace("localhost", "192.168.0.118");
            string AttachmentDocPath = "Documents/EventImage";
            string DocPath = string.Concat(_strSiteURL, AttachmentDocPath) + "/";

            if (objEvent.Event_Image != null)
                hdnImageName.Value = objEvent.Event_Image;
            else
                hdnImageName.Value = "";

            #endregion

            if (!string.IsNullOrEmpty(objEvent.Event_Image) && File.Exists(Server.MapPath("..\\") + AttachmentDocPath + "/" + objEvent.Event_Image))
            {
                lblImgEvent_Image.Style["display"] = "";
                lblImgEvent_Image.ImageUrl = Convert.ToString(AppConfig.SiteURL + AttachmentDocPath + "/" + objEvent.Event_Image);
            }
            else
                lblImgEvent_Image.Style["display"] = "none";


            //lblDateSendToClient.Text = clsGeneral.FormatDBNullDateToDisplay(objEvent.Date_Sent);
            //lblEvent_Desc.Text = objEvent.Event_Desc != null ? objEvent.Event_Desc : "";
            //if (objEvent.FK_LU_Event_Description != null)
            //    lblFK_LU_Event_Description.Text = new clsLU_Event_Description((decimal)objEvent.FK_LU_Event_Description).Fld_Desc;
            //else
            //    lblFK_LU_Event_Description.Text = "";
            //lblSonicEvent.Text = objEvent.Sonic_Event != null ? objEvent.Sonic_Event : "";
            //lblDate_Opened.Text = clsGeneral.FormatDBNullDateToDisplay(objEvent.Date_Opened);

            ////Event Company Information
            //lblCompanyName.Text = objEvent.Company != null ? objEvent.Company : "";
            //if (objEvent.FK_LU_Location != null)
            //    lblCompanyLocation.Text = new clsAlarm_Location((decimal)objEvent.FK_LU_Location).Name;
            //else
            //    lblCompanyLocation.Text = "";
            //lblCompanyAddress1.Text = objEvent.Company_Address_1 != null ? objEvent.Company_Address_1 : "";
            //lblCompanyAddress2.Text = objEvent.Company_Address_2 != null ? objEvent.Company_Address_2 : "";
            //lblCompanyCity.Text = objEvent.Company_City != null ? objEvent.Company_City : "";
            //if (objEvent.FK_LU_State != null)
            //    lblCompanyState.Text = new LU_State((decimal)objEvent.FK_LU_State).Fld_Desc;
            //else
            //    lblCompanyState.Text = "";

            //lblCompanyZipCode.Text = objEvent.Company_ZIP != null ? objEvent.Company_ZIP : "";
            //lblCompanyCountry.Text = objEvent.Company_County != null ? objEvent.Company_County : "";
            lblFirstName.Text = objEvent.Company_Contact_First_Name != null ? objEvent.Company_Contact_First_Name : "";
            lblMiddleName.Text = objEvent.Company_Contact_Middle_name != null ? objEvent.Company_Contact_Middle_name : "";
            lblLastName.Text = objEvent.Company_Contact_Last_Name != null ? objEvent.Company_Contact_Last_Name : "";

            lblTelephone1.Text = objEvent.Company_Contact_Phone != null ? objEvent.Company_Contact_Phone : "";
            lblEmail.Text = objEvent.Company_Contact_Email != null ? objEvent.Company_Contact_Email : "";
            lblTelephone2.Text = objEvent.Company_Contact_Fax != null ? objEvent.Company_Contact_Fax : "";

            ////Event Vehicle Information
            //lblVehicleNo.Text = objEvent.Vehicle_Number != null ? objEvent.Vehicle_Number : "";
            //lblVIN.Text = objEvent.VIN != null ? objEvent.VIN : "";
            //lblVehicleMake.Text = objEvent.Make != null ? objEvent.Make : "";
            //lblVehicleModel.Text = objEvent.Model != null ? objEvent.Model : "";
            //lblVehicleYear.Text = objEvent.Year != null ? objEvent.Year : "";
            lblTitle.Text = objEvent.Company_Titled != null ? objEvent.Company_Titled : "";
            //lblLicenseTag.Text = objEvent.License_Tag != null ? objEvent.License_Tag : "";

            //if (objEvent.FK_LU_State_Registered != null)
            //    lblVehicleStateRegistered.Text = new LU_State((decimal)objEvent.FK_LU_State_Registered).Fld_Desc;
            //else
            //    lblVehicleStateRegistered.Text = "";

            ////Event Police Information
            //lblPoliceDeptName.Text = objEvent.Police_Dept_Name != null ? objEvent.Police_Dept_Name : "";
            //lblPolicePhone.Text = objEvent.Police_Phone != null ? objEvent.Police_Phone : "";
            //lblOfficeFirstName.Text = objEvent.Police_Contact_First_Name != null ? objEvent.Police_Contact_First_Name : "";
            //lblOfficerMiddleName.Text = objEvent.Police_Contact_Middle_name != null ? objEvent.Police_Contact_Middle_name : "";
            //lblOfficerLastName.Text = objEvent.Police_Contact_Last_Name != null ? objEvent.Police_Contact_Last_Name : "";
            //lblBadgeNo.Text = objEvent.Badge_Number != null ? objEvent.Badge_Number : "";
            //lblPoliceFax.Text = objEvent.Facsimile != null ? objEvent.Facsimile : "";
            //lblPoliceCellPhone.Text = objEvent.Police_Contact_Cell_Phone != null ? objEvent.Police_Contact_Cell_Phone : "";
            //lblPoliceCity.Text = objEvent.Police_Contact_City != null ? objEvent.Police_Contact_City : "";
            //lblPoliceAddress1.Text = objEvent.Address_1 != null ? objEvent.Address_1 : "";

            //if (objEvent.FK_LU_Police_Dept_State != null)
            //    lblPoliceState.Text = new LU_State((decimal)objEvent.FK_LU_Police_Dept_State).Fld_Desc;
            //else
            //    lblPoliceState.Text = "";

            //lblPoliceAddress2.Text = objEvent.Address_2 != null ? objEvent.Address_2 : "";
            //lblPoliceZip.Text = objEvent.ZIP != null ? objEvent.ZIP : "";
            //lblJurisdiction.Text = objEvent.Jurisdiction != null ? objEvent.Jurisdiction : "";
            //lblPoliceReportNumber.Text = objEvent.Police_Report_Number != null ? objEvent.Police_Report_Number : "";
            //lblPoliceCardNo.Text = objEvent.Case_Number != null ? objEvent.Case_Number : "";
            //lblPoliceReportOrderedDate.Text = clsGeneral.FormatDBNullDateToDisplay(objEvent.Report_Ordered_Date);
            //lblPoliceReportReceivedDate.Text = clsGeneral.FormatDBNullDateToDisplay(objEvent.Report_Recieved_Date);
            lblLastModifiedDateTime.Text = objEvent.Update_Date == null ? "" : "Last Modified Date/Time : " + objEvent.Update_Date.Value.ToString("MM/dd/yyyy hh:mm:ss tt") + " ";


        }
    }

    /// <summary>
    /// Bind Drop Down Items
    /// </summary>
    private void BindDropDownList()
    {
        //ComboHelper.FillEventType(new DropDownList[] { ddlEventType }, true);
        //ComboHelper.FillState(new DropDownList[] { ddlCompanyState, ddlPoliceState, ddlStateRegistered }, true);
        //ComboHelper.FillAlarmLocation(new DropDownList[] { ddlCompanyLocation }, true);
        //ComboHelper.FillCountry(new DropDownList[] { ddlCompanyCountry }, true);
        //ComboHelper.FillEventDescription(new DropDownList[] { ddlFK_LU_Event_Description }, true);
        //ComboHelper.FillLocationWithCode(new DropDownList[] { ddlLocation }, true);
        ComboHelper.FillLocationByACIUser((new DropDownList[] { ddlLocation }), Convert.ToDecimal(clsSession.UserID), true);
        ComboHelper.FillEventType(new ListBox[] { lstEventType }, false);
        ComboHelper.FillEventDescription(new ListBox[] { lstEventDescription });


    }

    /// <summary>
    /// Save Event Information In database
    /// </summary>
    private void SaveRecord()
    {
        clsEvent objEvent = new clsEvent();
        objEvent.PK_Event = PK_Event;

        #region Event Information
        objEvent.FK_Incident = FK_Incident;
        //if (ddlEventType.SelectedIndex > 0) objEvent.FK_LU_Event_Type = Convert.ToDecimal(ddlEventType.SelectedValue);
        //else objEvent.FK_LU_Event_Type = null;

        if (ddlLocation.SelectedIndex > 0) 
            objEvent.FK_LU_Location = Convert.ToDecimal(ddlLocation.SelectedValue);
        else objEvent.FK_LU_Location = null;


        objEvent.Other_Event_Type = txtOther_Event_Type.Text;
        objEvent.Other_Event_Desc = txtOther_Event_Desc.Text;
        objEvent.Camera_Number = txtCameraNumber.Text.Trim();
        objEvent.Camera_Name = txtCameraName.Text.Trim();
        if (ddlFK_LU_Sonic_Event.SelectedIndex > 0)
            objEvent.Sonic_Event = ddlFK_LU_Sonic_Event.SelectedValue;
        objEvent.Date_Sent = clsGeneral.FormatNullDateToStore(txtDate_Sent.Text.Trim());
        objEvent.Investigation_Report_Date = clsGeneral.FormatNullDateToStore(txtInvestigationReportDate.Text.Trim());
        objEvent.Event_Report_Date = clsGeneral.FormatNullDateToStore(txtEventReportDate.Text.Trim());
        objEvent.Event_Occurence_Date = clsGeneral.FormatNullDateToStore(txtEventOccuranceDate.Text.Trim());
        //objEvent.Event_Start_Date = clsGeneral.FormatNullDateToStore(txtEvent_Start_Time.Text.Trim());
        //objEvent.Event_End_Date = clsGeneral.FormatNullDateToStore(txtEvent_End_Time.Text.Trim());

        //objEvent.Date_Sent = clsGeneral.FormatNullDateToStore(txtDateSentToClient.Text.Trim());
        //objEvent.Event_Desc = txtEvent_Desc.Text.Trim();
        //if (ddlFK_LU_Event_Description.SelectedIndex > 0) objEvent.FK_LU_Event_Description = Convert.ToDecimal(ddlFK_LU_Event_Description.SelectedValue);
        //else objEvent.FK_LU_Event_Description = null;

        //if (ddlSonicEvent.SelectedIndex > 0) objEvent.Sonic_Event = ddlSonicEvent.SelectedValue;
        //else objEvent.Sonic_Event = null;

        #region Event Image

        if (fpFile1.HasFile)
        {
            string strFileExtention = Path.GetExtension(fpFile1.FileName);
            if (strFileExtention.ToLower() == ".png" || strFileExtention.ToLower() == ".jpg" || strFileExtention.ToLower() == ".jpeg" || strFileExtention.ToLower() == ".bmp")
            {
                // set SiteURL and SitePath
                string _strSiteURL;
                string _strSitePath;
                _strSiteURL = String.Concat(HttpContext.Current.Request.Url.Scheme + "://", HttpContext.Current.Request.Url.Authority, HttpContext.Current.Request.ApplicationPath);
                if (!_strSiteURL.EndsWith("/")) _strSiteURL = String.Concat(_strSiteURL, "/");
                _strSitePath = String.Concat(HttpContext.Current.Server.MapPath(HttpContext.Current.Request.ApplicationPath), @"\");

                //_strSiteURL = _strSiteURL.Replace("localhost", "192.168.0.118");
                string AttachmentDocPath = "Documents\\EventImage";
                string DocPath = string.Concat(_strSitePath, AttachmentDocPath) + "\\";

                #region Delete Old Images (Edit mode only if user have changed Images)
                if (StrOperation.ToLower() == "edit")
                {
                    try
                    {
                        string strPhotoPath = hdnImageName.Value;
                        if (fpFile1.FileName.Length > 0 && strPhotoPath != "")
                        {
                            File.Delete(DocPath + strPhotoPath);
                        }
                    }
                    catch
                    { }
                }
                #endregion

                #region Save Image

                // upload and set the filename.
                objEvent.Event_Image = clsGeneral.UploadFile(fpFile1, DocPath, false, false);
                #endregion
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "Select Valid Image", "javascript:alert('Select Valid Image');", true);
            }
        }
        else
        {
            objEvent.Event_Image = hdnImageName.Value;
        }

        #endregion

        #endregion

        #region Event Contact

        //Event Contact
        //objEvent.Company = txtCompany.Text.Trim();
        //if (ddlCompanyLocation.SelectedIndex > 0) objEvent.FK_LU_Location = Convert.ToDecimal(ddlCompanyLocation.SelectedValue);
        //else objEvent.FK_LU_Location = null;

        //objEvent.Company_Address_1 = txtCompanyAddress1.Text.Trim();
        //objEvent.Company_Address_2 = txtCompanyAddress2.Text.Trim();
        //objEvent.Company_City = txtCompanyCity.Text.Trim();
        //if (ddlCompanyState.SelectedIndex > 0) objEvent.FK_LU_State = Convert.ToDecimal(ddlCompanyState.SelectedValue);
        //else objEvent.FK_LU_State = null;
        //if (ddlCompanyCountry.SelectedIndex > 0) objEvent.Company_County = ddlCompanyCountry.SelectedItem.Text.Trim();

        if (StrOperation.ToLower() == "add")
        {
            Employee objEmployee = new Employee(Convert.ToDecimal(ddlName.SelectedValue));
            objEvent.Company_Contact_First_Name = objEmployee.First_Name;
            objEvent.Company_Contact_Middle_name = objEmployee.Middle_Name;
            objEvent.Company_Contact_Last_Name = objEmployee.Last_Name;
        }
        else
        {
            objEvent.Company_Contact_First_Name = txtFirstNameContact.Text.Trim();
            objEvent.Company_Contact_Middle_name = txtMiddleNameContact.Text.Trim();
            objEvent.Company_Contact_Last_Name = txtLastNameContact.Text.Trim();
        }



        //objEvent.Company_ZIP = txtCompanyZipcode.Text.Trim();
        objEvent.Company_Contact_Phone = txtTelephoneNumber1.Text.Trim();
        objEvent.Company_Contact_Email = txtEmailAddress.Text.Trim();
        objEvent.Company_Contact_Fax = txtTelephoneNumber2.Text.Trim();
        objEvent.Company_Titled = txtTitle.Text.Trim();

        #endregion

        #region Event Vehicle

        ////Event Vehicle
        //objEvent.Vehicle_Number = txtVehicleNo.Text.Trim();
        //objEvent.VIN = txtVIN.Text.Trim();
        //objEvent.Make = txtMake.Text.Trim();
        //objEvent.Model = txtModel.Text.Trim();
        //objEvent.Year = txtYear.Text.Trim();
        //objEvent.Company_Titled = txtVehicleCompanyTiled.Text.Trim();
        //objEvent.License_Tag = txtLicenseTag.Text.Trim();
        //if (ddlStateRegistered.SelectedIndex > 0) objEvent.FK_LU_State_Registered = Convert.ToDecimal(ddlStateRegistered.SelectedValue);
        //else objEvent.FK_LU_State_Registered = null;
        #endregion

        #region Event Police

        ////Event Police
        //objEvent.Police_Dept_Name = txtPoliceDeptName.Text.Trim();
        //objEvent.Police_Phone = txtPolicePhone.Text.Trim();
        //objEvent.Police_Contact_First_Name = txtOfficeFirstName.Text.Trim();
        //objEvent.Police_Contact_Middle_name = txtOfficerMiddleName.Text.Trim();
        //objEvent.Police_Contact_Last_Name = txtOfficerLastName.Text.Trim();
        //objEvent.Badge_Number = txtBadgeNo.Text.Trim();
        //objEvent.Facsimile = txtPoliceFax.Text.Trim();
        //objEvent.Police_Contact_Cell_Phone = txtPoliceCellNo.Text.Trim();
        //objEvent.Police_Contact_City = txtPoliceCity.Text.Trim();
        //objEvent.Address_1 = txtPoliceAddress1.Text.Trim();
        //if (ddlPoliceState.SelectedIndex > 0) objEvent.FK_LU_Police_Dept_State = Convert.ToDecimal(ddlPoliceState.SelectedValue);
        //else objEvent.FK_LU_Police_Dept_State = null;
        //objEvent.Address_2 = txtPoliceAddress2.Text.Trim();
        //objEvent.ZIP = txtPoliceZip.Text.Trim();
        //objEvent.Jurisdiction = txtJurisdiction.Text.Trim();
        //objEvent.Police_Report_Number = txtPoliceReportNo.Text.Trim();
        //objEvent.Case_Number = txtCaseNo.Text.Trim();
        //objEvent.Report_Ordered_Date = clsGeneral.FormatNullDateToStore(txtPoliceReportOrderDate.Text.Trim());
        //objEvent.Report_Recieved_Date = clsGeneral.FormatNullDateToStore(txtPoliceReportReceivedDate.Text.Trim());

        #endregion

        objEvent.Update_Date = DateTime.Now;
        objEvent.Updated_By = clsSession.UserID;
        if (PK_Event > 0)
            objEvent.Update();
        else
            PK_Event = objEvent.Insert();

        clsAssoc_Event_Type.DeleteByFK_Event(PK_Event);
        foreach (ListItem objLstEventType in lstEventType.Items)
        {
            if (objLstEventType.Selected == true)
            {
                clsAssoc_Event_Type objAssoc_Event_Type = new clsAssoc_Event_Type();
                objAssoc_Event_Type.FK_Event = PK_Event;
                objAssoc_Event_Type.FK_LU_Event_Type = Convert.ToDecimal(objLstEventType.Value);
                objAssoc_Event_Type.Insert();
            }
        }

        clsAssoc_Event_Description.DeleteByFK_Event(PK_Event);
        foreach (ListItem objLstEventDescription in lstEventDescription.Items)
        {
            if (objLstEventDescription.Selected == true)
            {
                clsAssoc_Event_Description objAssoc_Event_Description = new clsAssoc_Event_Description();
                objAssoc_Event_Description.FK_Event = PK_Event;
                objAssoc_Event_Description.FK_LU_Event_Description = Convert.ToDecimal(objLstEventDescription.Value);
                objAssoc_Event_Description.Insert();
            }
        }
        //if (PK_Event > 0) if (hdnCompanyContact.Value != "") UpdateContactDetails_CompanyContact("Employee", hdnCompanyContact.Value);

    }

    /// <summary>
    /// Update Company Contact Contact Detail
    /// </summary>
    /// <param name="strRole"></param>
    /// <param name="FK_CompanyContact"></param>
    //private void UpdateContactDetails_CompanyContact(string strRole, string FK_CompanyContact)
    //{
    //    // Update contact details by CliamId,pk_Contact,Role and use name // PK_Incident_shipment
    //    Contact_Link.InsertUpdate_ClaimContactLink(PK_Event, "Event", Convert.ToDecimal(FK_CompanyContact), strRole, clsSession.UserName);
    //}

    /// <summary>
    /// Bind ACI Notes Grid
    /// </summary>
    private void BindACINoteGrid()
    {
        DataSet dsACI_Note = clsACI_Event_Notes.SelectByFK_Event(PK_Event, 1, 100, "Note_Date", "asc");

        if (StrOperation.ToLower() == "view")
        {
            if (dsACI_Note != null && dsACI_Note.Tables.Count > 0)
            {
                gvACI_NotesView.DataSource = dsACI_Note;
                gvACI_NotesView.DataBind();
            }
            else
            {
                gvACI_NotesView.DataSource = null;
                gvACI_NotesView.DataBind();
            }
        }
        else
        {
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
    }

    /// <summary>
    /// Bind Sonic Note Grid
    /// </summary>
    private void BindSonicNoteGrid()
    {
        DataSet dsSonic_Note = clsSonic_Event_Notes.SelectByFK_Event(PK_Event);

        if (StrOperation.ToLower() == "view")
        {
            if (dsSonic_Note != null && dsSonic_Note.Tables.Count > 0)
            {
                gvSonic_NotesView.DataSource = dsSonic_Note;
                gvSonic_NotesView.DataBind();
            }
            else
            {
                gvSonic_NotesView.DataSource = null;
                gvSonic_NotesView.DataBind();
            }
        }
        else
        {
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
    }

    //Used to Fill Employee Information as Employee Selected
    private void UpdateEmployeeInformation()
    {
        Employee objEmployee = new Employee(Convert.ToDecimal(ddlName.SelectedValue));

        if (objEmployee.Job_Title != null)
            txtTitle.Text = Convert.ToString(objEmployee.Job_Title).Trim();
        else
            txtTitle.Text = "";

        if (objEmployee.Employee_Home_Phone != null)
            txtTelephoneNumber1.Text = Convert.ToString(objEmployee.Employee_Home_Phone).Trim();
        else
            txtTelephoneNumber1.Text = "";

        if (objEmployee.Employee_Cell_Phone != null)
            txtTelephoneNumber2.Text = Convert.ToString(objEmployee.Employee_Cell_Phone).Trim();
        else
            txtTelephoneNumber2.Text = "";

        if (objEmployee.Email != null)
            txtEmailAddress.Text = Convert.ToString(objEmployee.Email).Trim();
        else
            txtEmailAddress.Text = "";

    }

    //check visibility of contact Name
    private void ContactNameVisibility()
    {
        if (StrOperation.ToLower() == "add")
        {
            trContactNamedrp.Visible = true;
            trContactNametxt.Visible = false;
        }
        else
        {
            trContactNamedrp.Visible = false;
            trContactNametxt.Visible = true;
        }
    }

    #endregion

    #region "Grid Events"

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

            txtACI_Notes_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objACI_Event_Notes.Note_Date);
            txtACI_Notes.Text = Convert.ToString(objACI_Event_Notes.Note);


            ((ScriptManager)this.Master.FindControl("scMain")).SetFocus(txtACI_Notes_Date);
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
        Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(1);", true);
    }

    /// <summary>
    /// gvSonic_Notes on Edit Or Delete
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvSonic_Notes_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "RemoveSonicNote")
        {
            #region
            clsSonic_Event_Notes.DeleteByPK(Convert.ToDecimal(e.CommandArgument));

            BindSonicNoteGrid();
            #endregion
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(1);", true);
        }
        else if (e.CommandName == "ViewSonicNote")
        {
            //Response.Redirect("Event_Note.aspx?nid=" + Encryption.Encrypt(e.CommandArgument.ToString()) + "&id=" + Encryption.Encrypt(PK_Event.ToString()) + "&iid=" + Encryption.Encrypt(FK_Incident.ToString()) + "&mode=" + StrOperation + "&type=SONIC");

            Page.ClientScript.RegisterStartupScript(typeof(string), DateTime.Now.ToString(), "javascript:AciNotePopup(" + Encryption.Encrypt(e.CommandArgument.ToString()) + "," + Encryption.Encrypt(PK_Event.ToString()) + "," + Encryption.Encrypt(FK_Incident.ToString()) + "," + StrOperation + ",SONIC);", true);
            //AciNotePopup
        }
        else if (e.CommandName == "EditRecord")
        {
            _PK_SONIC_Notes = Convert.ToDecimal(e.CommandArgument);
            // show and hide Add-edit row
            trSONICNotesGrid.Style.Add("display", "none");
            trSONICNotes.Style.Add("display", "");
            btnSONICNotesCancel.Style.Add("display", "inline");
            btnSONICNotesAdd.Text = "Update";
            // get record from database

            clsSonic_Event_Notes objSONIC_Event_Notes = new clsSonic_Event_Notes(_PK_SONIC_Notes);

            //txtSonic_Notes_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objSONIC_Event_Notes.Note_Date);
            txtSonic_Notes.Text = Convert.ToString(objSONIC_Event_Notes.Note);


            // ((ScriptManager)this.Master.FindControl("scMain")).SetFocus(txtSONIC_Notes_Date);
        }

    }

    /// <summary>
    /// Paging event of gvSonic
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvSonic_Notes_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvSonic_Notes.PageIndex = e.NewPageIndex; //Page new index call
        BindSonicNoteGrid();
        Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(1);", true);
    }

    #endregion

    #region "Selected index change"

    protected void ddlLocation_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlLocation.SelectedIndex > 0)
        {
            if (!string.IsNullOrEmpty(ddlLocation.SelectedValue.ToString()))
            {
                clsAci_Lu_Location lu = new clsAci_Lu_Location(Convert.ToDecimal(ddlLocation.SelectedValue));
                int Sonic_Location_Code = Convert.ToInt32(lu.Fld_Code);
                ComboHelper.FillAssociateByContact(new DropDownList[] { ddlName }, true, (ddlLocation.SelectedIndex > 0) ? Sonic_Location_Code : 0);
                if (StrOperation.ToLower() == "add")
                    ddlName_SelectedIndexChanged(null, null);
            }
            
           
        }
        else if (StrOperation.ToLower() == "add")
        {
            ddlName.Items.Clear();
            txtTitle.Text = "";
            txtTelephoneNumber1.Text = "";
            txtTelephoneNumber2.Text = "";
            txtEmailAddress.Text = "";
        }
    }

    protected void ddlName_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlName.SelectedIndex > 0)
        {
            // Fill Controls From Employee Table
            UpdateEmployeeInformation();
            //used to get default situation of step 3
            //Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ChangeVehicleValue();", true);
        }
        else if (StrOperation.ToLower() == "add")
        {
            txtTitle.Text = "";
            txtTelephoneNumber1.Text = "";
            txtTelephoneNumber2.Text = "";
            txtEmailAddress.Text = "";
        }
    }
    #endregion

}