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
using Winnovative.WnvHtmlConvert;

public partial class Event_ACI_Video_Request : clsBasePage
{
    public string _strAttachmentName = string.Empty;
    public string _strEvent_Number = string.Empty;

    #region Properties


    /// <summary>
    /// Denotes the Primary Key
    /// </summary>
    public decimal PK_Event_Video_Tracking_Request
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_Event_Video_Tracking_Request"]);
        }
        set { ViewState["PK_Event_Video_Tracking_Request"] = value; }
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
    /// Denotes the operation whether edit or view
    /// </summary>
    public string StrReqType
    {
        get { return ViewState["StrReqType"] != null ? Convert.ToString(ViewState["StrReqType"]) : ""; }
        set { ViewState["StrReqType"] = value; }
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
        txtCurrentDate_Video.Text = DateTime.Now.ToShortDateString().ToString();
        if (!IsPostBack)
        {
            PK_Event_Video_Tracking_Request = clsGeneral.GetQueryStringID(Request.QueryString["tid"]);
            StrOperation = Convert.ToString(Request.QueryString["mode"]);
            hdnPanel.Value = clsGeneral.GetPanelId(Request.QueryString["pnl"]).ToString();
            StrReqType = Convert.ToString(Request.QueryString["rtype"]);

            if (StrOperation == "add")
            {
                Session.Remove("EventVideocriteria");
                BindEmployeeDetails();
                ShowHideUrgentneed(false);
            }
          
            ucAttachment_Video.FK_Table = PK_Event_Video_Tracking_Request;
            if (PK_Event_Video_Tracking_Request > 0)
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

                    if (StrOperation.ToLower() != "addto") 
                        StrOperation = "edit";
                }
                
                //ucAttachment_Video.Visible = true;
                //ucAttachment_Video.FillEventInformation(PK_Event);
            }
            else
            {
                /*SetEditViewRights(false);*/
         
                PK_Event_Video_Tracking_Request = 0;
                StrOperation = "add"; 
                BindDropDownList();
                ucAttachment_Video.ReadOnly = true;
                BindGridTracking();
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
        ucAttachment_Video.ReadOnly = true;
        if (StrOperation == "add") hdnPanel.Value = "1"; //for Add new click set tab style
        Page.ClientScript.RegisterStartupScript(typeof(string), DateTime.Now.ToString(), "javascript:ShowPanel(" + hdnPanel.Value + ");", true);
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

        if (StrOperation.ToLower() == "add" || StrOperation.ToLower() == "addto" || StrOperation.ToLower() == "")
        {
            Response.Redirect("ACI_Video_Request.aspx?tid=" + Encryption.Encrypt(PK_Event_Video_Tracking_Request.ToString()) + "&mode=edit&pnl=" + hdnPanel.Value, true);
        }
        else
        {
            StrOperation = "edit";
            BindDetailsForEdit();
        }
        Page.ClientScript.RegisterStartupScript(typeof(string), DateTime.Now.ToString(), "javascript:ShowPanel(" + hdnPanel.Value + ");", true);
    }

    /// <summary>
    /// Send Notification
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSend_Notification_Video_Click(object sender, EventArgs e)
    {
        SaveRecord();
        SendAbstractViaEmailWhileInsert();

        if (StrOperation.ToLower() == "add" || StrOperation.ToLower() == "addto" || StrOperation.ToLower() == "")
        {
            Response.Redirect("ACI_Video_Request.aspx?tid=" + Encryption.Encrypt(PK_Event_Video_Tracking_Request.ToString()) + "&mode=edit&pnl=" + hdnPanel.Value, true);
        }
        else
        {
            StrOperation = "edit";
            BindDetailsForEdit();
        }
        Page.ClientScript.RegisterStartupScript(typeof(string), DateTime.Now.ToString(), "javascript:ShowPanel(" + hdnPanel.Value + ");", true);

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


    protected void btnhdnReload_Click(object sender, EventArgs e)
    {
        BindGridTracking();
        Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(" + hdnPanel.Value + ");", true);
    }

    /// <summary>
    /// Edit Button Click Event On View Mode
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("Event_VideoRequestSearch.aspx");
    }


    #endregion

    #region Page Methods

    /// <summary>
    /// Event Called When Page is open on Edit Mode
    /// </summary>
    private void BindDetailsForEdit()
    {
        dvEdit.Visible = true;

        btnSend_Notification_Video.Visible = true;
        ucAttachment_Video.ReadOnly = false;

        clsEvent_Video_Tracking_Request objVideo = new clsEvent_Video_Tracking_Request(PK_Event_Video_Tracking_Request);

        clsGeneral.SetDropdownValue(ddlLocation_Video, objVideo.FK_LU_Location, true);
        clsGeneral.SetDropdownValue(ddlFK_LU_Type_of_Activity_Video, objVideo.FK_LU_Type_of_Activity, true);
        txtDate_Of_Event_Video.Text = clsGeneral.FormatDBNullDateToDisplay(objVideo.Date_Of_Event);
        txtDate_Of_Request_Video.Text = clsGeneral.FormatDBNullDateToDisplay(objVideo.Date_Of_Request);
        txtFull_Name_Video.Text = objVideo.Full_Name;
        txtWork_Phone_Video.Text = objVideo.Work_Phone;
        txtLocation_Video.Text = objVideo.Location;
        txtAlternate_Phone_Video.Text = objVideo.Alternate_Phone;
        txtReason_Request_Video.Text = objVideo.Reason_Request;

        BindGridTracking();

        txtCamera_Name_Video.Text = objVideo.Camera_Name;
        txtEvent_Start_Time_Video.Text = objVideo.Event_Start_Time;
        txtEvent_End_Time_Video.Text = objVideo.Event_End_Time;
        txtVideo_Link_Email_Video.Text = objVideo.Video_Link_Email;
        txtStill_Shots_Email_Video.Text = objVideo.Still_Shots_Email;
        txtNo_DVD_Copy_Video.Text = objVideo.No_DVD_Copy != null ? Convert.ToString(objVideo.No_DVD_Copy) : string.Empty;

        if (!string.IsNullOrEmpty(objVideo.Urgent_Need)) 
            rdoUrgent_Need_Video.SelectedValue = Convert.ToString(objVideo.Urgent_Need) == "Y" ? "Y" : "N";

        txtMailing_Address_Video.Text = objVideo.Mailing_Address;
        if (!string.IsNullOrEmpty(objVideo.Shipping_Method))
            rdoShipping_Method_Video.SelectedValue = Convert.ToString(objVideo.Urgent_Need);

        if (rdoUrgent_Need_Video.SelectedValue == "Y")
        {
            ShowHideUrgentneed(true);
        }
        else
        {
            ShowHideUrgentneed(false);
        }

        if (StrOperation.ToLower() == "viewonly")
        {
            /*SetEditViewRights(true);*/
            btnSend_Notification_Video.Visible = false;
        }
        lblLastModifiedDateTime.Text = objVideo.Update_Date == null ? "" : "Last Modified Date/Time : " + objVideo.Update_Date.Value.ToString("MM/dd/yyyy hh:mm:ss tt") + " ";
    }

    /// <summary>
    /// Event Called When Page is open in View Mode
    /// </summary>
    private void BindDetailForView()
    {
        dvEdit.Visible = false;
        //btnSave.Visible = false;
    }

    /// <summary>
    /// Bind Drop Down Items
    /// </summary>
    private void BindDropDownList()
    {
        ComboHelper.FillLocationByACIUser_New((new DropDownList[] { ddlLocation_Video }), Convert.ToDecimal(clsSession.UserID), true);
        ComboHelper.FillEventType(new DropDownList[] { ddlFK_LU_Type_of_Activity_Video }, true);
    }

    /// <summary>
    /// Save Event Information In database
    /// </summary>
    private void SaveRecord()
    {
        clsEvent_Video_Tracking_Request objVideo = new clsEvent_Video_Tracking_Request();
        objVideo.PK_Event_Video_Tracking_Request = PK_Event_Video_Tracking_Request;
        if (ddlLocation_Video.SelectedIndex > 0)
            objVideo.FK_LU_Location = Convert.ToDecimal(ddlLocation_Video.SelectedValue);
        if (ddlFK_LU_Type_of_Activity_Video.SelectedIndex > 0)
            objVideo.FK_LU_Type_of_Activity = Convert.ToDecimal(ddlFK_LU_Type_of_Activity_Video.SelectedValue);
        objVideo.Date_Of_Event = clsGeneral.FormatNullDateToStore(txtDate_Of_Event_Video.Text);
        objVideo.Date_Of_Request = clsGeneral.FormatNullDateToStore(txtDate_Of_Request_Video.Text);
        objVideo.Full_Name = Convert.ToString(txtFull_Name_Video.Text);
        objVideo.Work_Phone = Convert.ToString(txtWork_Phone_Video.Text);
        objVideo.Location = Convert.ToString(txtLocation_Video.Text);
        objVideo.Alternate_Phone = Convert.ToString(txtAlternate_Phone_Video.Text);
        objVideo.Reason_Request = txtReason_Request_Video.Text;
        objVideo.Camera_Name = txtCamera_Name_Video.Text;
        objVideo.Event_Start_Time = Convert.ToString(txtEvent_Start_Time_Video.Text);
        objVideo.Event_End_Time = Convert.ToString(txtEvent_End_Time_Video.Text);
        objVideo.Video_Link_Email = Convert.ToString(txtVideo_Link_Email_Video.Text);
        objVideo.Still_Shots_Email = Convert.ToString(txtStill_Shots_Email_Video.Text);
        if (txtNo_DVD_Copy_Video.Text != string.Empty)
            objVideo.No_DVD_Copy = Convert.ToInt32(txtNo_DVD_Copy_Video.Text);
        if (rdoUrgent_Need_Video.SelectedIndex > -1)
            objVideo.Urgent_Need = rdoUrgent_Need_Video.SelectedValue;
        objVideo.Mailing_Address = Convert.ToString(txtMailing_Address_Video.Text);
        if (rdoShipping_Method_Video.SelectedIndex > -1)
            objVideo.Shipping_Method = rdoShipping_Method_Video.SelectedValue;
        objVideo.Create_Date = DateTime.Now;
        objVideo.Created_By = clsSession.UserID;
        objVideo.Update_Date = DateTime.Now;
        objVideo.Updated_By = clsSession.UserID;
        objVideo.FK_Security = Convert.ToDecimal(clsSession.UserID);

        DataSet ds = clsLU_Video_Tracking_Status.GetVideoStatusbydesc("Pending");

        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            objVideo.Request_Type = StrReqType == "3rd" ? "3rd Party Request" : "SRE Video Request";
            objVideo.Status = Convert.ToDecimal(ds.Tables[0].Rows[0]["PK_LU_Video_Tracking_Status"]);
        }

        if (PK_Event_Video_Tracking_Request > 0)
        {
            objVideo.Update();
            ViewState.Remove("EmailAbsratact");
        }
        else
        {
            PK_Event_Video_Tracking_Request = objVideo.Insert();
            ViewState["EmailAbsratact"] = PK_Event_Video_Tracking_Request;
        }

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
    ///  Binds Building grid in building information panel
    /// </summary>
    private void BindGridTracking()
    {
        DataTable dtTracking = clsEvent_Video_Tracking_Request.GetVideoTrackingDataByFK_Event(0,PK_Event_Video_Tracking_Request).Tables[0];

        if (dtTracking != null)
        {
            gvTracking.DataSource = dtTracking;
            gvTracking.DataBind();
        }
        else
        {
            gvTracking.DataSource = null;
            gvTracking.DataBind();
        }

    }

    private void BindEmployeeDetails()
    {
        DataSet dsemployee = clsEvent_Video_Tracking_Request.GetUserDetailForVideoRequest();

        if (dsemployee != null && dsemployee.Tables.Count > 0 && dsemployee.Tables[0].Rows.Count > 0)
        {
            DataTable dt = dsemployee.Tables[0];

            txtFull_Name_Video.Text = Convert.ToString(dt.Rows[0]["Full_Name"]);
            txtWork_Phone_Video.Text = Convert.ToString(dt.Rows[0]["Work_Phone"]);
            txtLocation_Video.Text = Convert.ToString(dt.Rows[0]["Location"]);
            txtAlternate_Phone_Video.Text = Convert.ToString(dt.Rows[0]["Employee_Home_Phone"]);
        }
    }

    /*private void SetEditViewRights(bool Is_Closed)
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
        //ddlFK_LU_Cause_Investigation.Enabled = Is_Enable;
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


    }*/

    private void SendAbstractViaEmailWhileInsert()
    {
        if (PK_Event_Video_Tracking_Request > 0)
        {
            DataTable dtEmailList = clsEvent_Video_Tracking_Request.GetVideoRequestUser().Tables[0];

            string strUploadPath = AppConfig.DocumentsPath + "Attach\\";
            string strAbstractReportData = Convert.ToString(AbstractLetters.Event_VideoRequestReport(PK_Event_Video_Tracking_Request, false, clsGeneral.Major_Coverage.Event));

            clsEvent_Video_Tracking_Request objRefNumber = new clsEvent_Video_Tracking_Request(PK_Event_Video_Tracking_Request);

            string fileName = SaveFilePDF(strAbstractReportData, strUploadPath, "Video_Request_Form_"+ Convert.ToString(objRefNumber.Request_Number) +".pdf");

            if (fileName.Length > 0)
            {
                clsAttachment_Event objAttachment = new clsAttachment_Event();

                DataSet ds = clsEvent_Video_Tracking_Request.GetAttachmentfolderforVideoRequest("Video Request Form");

                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0 && ds.Tables[0].Rows[0]["PK_Virtual_Folder"] != null)
                {
                    objAttachment.FK_Virtual_Folder = Convert.ToDecimal(ds.Tables[0].Rows[0]["PK_Virtual_Folder"]);
                    objAttachment.Attachment_Table = "Event_Video_Tracking_Request";
                    objAttachment.Attachment_Name = fileName;
                    objAttachment.Attachment_Description = "Video_Request_Form_"+Convert.ToString(objRefNumber.Request_Number)+".pdf";
                    objAttachment.FK_Table = PK_Event_Video_Tracking_Request;
                    objAttachment.FK_Attachment_Type = 0;
                    objAttachment.Updated_By = clsSession.UserID;
                    objAttachment.Update_Date = DateTime.Now;
                    objAttachment.Attach_Date = DateTime.Now;
                    objAttachment.Insert();
                }

            }

            //string[] attchment = null;
            //if (ViewState["Attchments"] != null)
            //{
            //    attchment = new string[1];
            //    attchment[0] = AppConfig.SitePath + "Documents/EventImage" + "/" + Convert.ToString(ViewState["Attchments"]);
            //}

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

            System.Collections.Generic.List<string> lstAttachment = new System.Collections.Generic.List<string>();
            int intAttachmentcount = 0;


            if (!string.IsNullOrEmpty(fileName) && File.Exists(strUploadPath + "\\" + fileName))
            {
                lstAttachment.Insert(intAttachmentcount, strUploadPath + "\\" + fileName);
                intAttachmentcount++;
            }

            string[] strTemp = lstAttachment.ToArray();

            string strMailHeader = "ACI Video Request has been Created for " + (ddlLocation_Video.SelectedIndex > 0 ? ddlLocation_Video.SelectedItem.Text : "") + " by " + txtFull_Name_Video.Text;

            string strMailBody = "ERIMS has requested ACI Video Approval. Please click APPROVE or DENY for video Request.";
            strMailBody = strMailBody + "<br/>";
            strMailBody = strMailBody + "<br/>";
            strMailBody = strMailBody + "<A href=/eRIMS_SonicWeb/Event/EventSearch_New.aspx>APPROVE</A>";
            strMailBody = strMailBody ;
            strMailBody = strMailBody + "<A href=/eRIMS_SonicWeb/Event/EventSearch_New.aspx>DENY</A>";
            if (EmailTo.Length > 0)
            {
                EmailHelper objEmail = new EmailHelper(AppConfig.SMTPServer, AppConfig.MailFrom, AppConfig.SMTPpwd, Convert.ToInt32(AppConfig.Port));
                objEmail.SendEventMailMessage(AppConfig.ManagementEmailID, " ", EmailTo, strMailHeader, strMailBody, true, strTemp, AppConfig.MailCC);
            }

            ucAttachment_Video.ReadOnly = true;
            ucAttachment_Video.BindGridFolders();
        }
    }

    private void ShowHideUrgentneed(bool IsEnable)
    {
        if (IsEnable)
        {
            spancameraname.Style.Add("display", "");
            spanstarttime.Style.Add("display", "");
            spanendtime.Style.Add("display", "");
            revtxtCamera_Name_Video.Enabled = true;
            revtxtEvent_Start_Time_Video.Enabled = true;
            revtxtEvent_End_Time_Video.Enabled = true;
        }
        else
        {
            spancameraname.Style.Add("display", "none");
            spanstarttime.Style.Add("display", "none");
            spanendtime.Style.Add("display", "none");
            revtxtCamera_Name_Video.Enabled = false;
            revtxtEvent_Start_Time_Video.Enabled = false;
            revtxtEvent_End_Time_Video.Enabled = false;
        }
    }

    public byte[] GetBytypesFromString()
    {
        string strFileName = string.Empty;
        PdfConverter objPdf = new PdfConverter();
        StringBuilder sbHtml = new StringBuilder();
        Byte[] pdfByte = null;
        objPdf.LicenseKey = AppConfig._strHtmltoPDFConverterKey;
        objPdf.PdfDocumentOptions.TopMargin = 20;
        objPdf.PdfDocumentOptions.LeftMargin = 20;
        objPdf.PdfDocumentOptions.RightMargin = 20;
        objPdf.PdfDocumentOptions.BottomMargin = 20;
        objPdf.PdfDocumentOptions.ShowHeader = false;
        objPdf.PdfDocumentOptions.ShowFooter = false;
        objPdf.PdfDocumentOptions.EmbedFonts = false;

        objPdf.PdfDocumentOptions.LiveUrlsEnabled = false;
        objPdf.RightToLeftEnabled = false;
        objPdf.PdfSecurityOptions.CanPrint = true;
        objPdf.PdfSecurityOptions.CanEditContent = true;
        objPdf.PdfSecurityOptions.UserPassword = "";
        objPdf.PdfDocumentOptions.PdfPageOrientation = PDFPageOrientation.Landscape;
        objPdf.PdfDocumentOptions.PdfPageSize = PdfPageSize.Letter;
        objPdf.PdfDocumentInfo.AuthorName = "eRIMS2";

        sbHtml = AbstractLetters.Event_VideoRequestReport(PK_Event_Video_Tracking_Request, false, clsGeneral.Major_Coverage.Event);

        pdfByte = objPdf.GetPdfBytesFromHtmlString(sbHtml.ToString());

        return pdfByte;
    }

    public static string SaveFilePDF(string strFileText, string strPath, string strFileName)
    {
        string strRetVal = "";
        // set path.
        if (!strPath.EndsWith("\\"))
        {
            strPath = string.Concat(strPath, "\\");
        }
        if (strPath.Contains("/"))
            strPath = strPath.Replace('/', '\\');

        // create dir if doesnt' exists
        clsGeneral.CreateDirectory(strPath);

        // now check for file name exists or not. and option for overwrite
        string strFulleName = string.Concat(strPath, strFileName);

        // if overwrite is not allowed then get filename to save.
        strFulleName = clsGeneral.GetFileNameToSave(strFulleName);

        PdfConverter objPdf = new PdfConverter();
        objPdf.LicenseKey = AppConfig._strHtmltoPDFConverterKey;
        objPdf.PdfDocumentOptions.TopMargin = 20;
        objPdf.PdfDocumentOptions.LeftMargin = 20;
        objPdf.PdfDocumentOptions.RightMargin = 20;
        objPdf.PdfDocumentOptions.BottomMargin = 20;
        objPdf.PdfDocumentOptions.ShowHeader = false;
        objPdf.PdfDocumentOptions.ShowFooter = false;
        objPdf.PdfDocumentOptions.EmbedFonts = false;

        objPdf.PdfDocumentOptions.LiveUrlsEnabled = false;
        objPdf.RightToLeftEnabled = false;
        objPdf.PdfSecurityOptions.CanPrint = true;
        objPdf.PdfSecurityOptions.CanEditContent = true;
        objPdf.PdfSecurityOptions.UserPassword = "";
        objPdf.PdfDocumentOptions.PdfPageOrientation = PDFPageOrientation.Landscape;
        objPdf.PdfDocumentOptions.PdfPageSize = PdfPageSize.Letter;
        objPdf.PdfDocumentInfo.AuthorName = "eRIMS2";

        //objPdf.PdfDocumentOptions.PdfPageSize = PdfPageSize.Custom;
        //objPdf.PdfDocumentOptions.CustomPdfPageSize = new System.Drawing.SizeF(10f, 10f);

        StringBuilder sbHtml = new StringBuilder();
        sbHtml.Append(strFileText);

        objPdf.PdfDocumentInfo.AuthorName = "eRIMS2";
        //Byte[] pdfByte = null;
        //pdfByte = objPdf.GetPdfBytesFromHtmlString(sbHtml.ToString());

        objPdf.SavePdfFromHtmlStringToFile(strFileText, strFulleName);

        // set return value = only filename.
        strRetVal = clsGeneral.GetFileName(strFulleName);

        return strRetVal;
    }

    #endregion

    #region "Grid Events"

    #endregion

    protected void rdoUrgent_Need_Video_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rdoUrgent_Need_Video.SelectedValue == "Y")
        {
            ShowHideUrgentneed(true);
        }
        else
        {
            ShowHideUrgentneed(false);
        }
    }
}