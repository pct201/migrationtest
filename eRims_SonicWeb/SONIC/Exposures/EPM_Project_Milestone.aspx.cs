using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERIMS.DAL;
using System.Data;

public partial class SONIC_Exposures_EPM_Project_Milestone : clsBasePage
{
    #region " Properties "
    /// <summary>
    /// denotes Primary Key of EPM_Milestone table
    /// </summary>
    public decimal PK_EPM_Milestone
    {
        get { return Convert.ToDecimal(ViewState["PK_EPM_Milestone"]); }
        set { ViewState["PK_EPM_Milestone"] = value; }
    }

    /// <summary>
    /// denotes Primary Key of EPM_Milestone_EMail_List table
    /// </summary>
    public decimal PK_EPM_Milestone_EMail_List
    {
        get { return Convert.ToDecimal(ViewState["PK_EPM_Milestone_EMail_List"]); }
        set { ViewState["PK_EPM_Milestone_EMail_List"] = value; }
    }

    /// <summary>
    /// denotes Foreign Key of EPM_Identification table
    /// </summary>
    public decimal FK_EPM_Identification
    {
        get { return Convert.ToDecimal(ViewState["FK_EPM_Identification"]); }
        set { ViewState["FK_EPM_Identification"] = value; }
    }

    /// <summary>
    /// Denote Location ID for Environmental Project Management Data
    /// </summary>
    public int LocationID
    {
        get { return Convert.ToInt32(ViewState["LocationID"]); }
        set { ViewState["LocationID"] = value; }
    }

    /// <summary>
    /// Denotes the operation whether edit or view
    /// </summary>
    public string StrOperation
    {
        get { return Convert.ToString(ViewState["strOperation"]); }
        set { ViewState["strOperation"] = value; }
    }

    /// <summary>
    /// denotes Foreign Key of EPM_Identification table
    /// </summary>
    public DateTime Milestone_Date
    {
        get { return Convert.ToDateTime(ViewState["Milestone_Date"]); }
        set { ViewState["Milestone_Date"] = value; }
    }

    /// <summary>
    /// Denote PanelNum 
    /// </summary>
    public string PanelNum
    {
        get { return Convert.ToString(ViewState["PanelNum"]); }
        set { ViewState["PanelNum"] = value; }
    }

    /// <summary>
    /// Denote MailrecipientsIDs
    /// </summary>
    public string MailrecipientsIDs
    {
        get { return Convert.ToString(ViewState["MailrecipientsIDs"]); }
        set { ViewState["MailrecipientsIDs"] = value; }
    }
    #endregion

    #region " page Event "
    /// <summary>
    /// Handles Page load Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        // Set Tab selection
        Tab.SetSelectedTab(Controls_ExposuresTab_ExposuresTab.Tab.ProjectManagement);

        if (!IsPostBack)
        {
            LocationID = Convert.ToInt32(Encryption.Decrypt(Request.QueryString["loc"].ToString()));
            FK_EPM_Identification = Convert.ToDecimal(Encryption.Decrypt(Request.QueryString["id"].ToString()));
            PK_EPM_Milestone = Convert.ToDecimal(Encryption.Decrypt(Request.QueryString["PMI"].ToString()));
            StrOperation = Request.QueryString["op"].ToString();
            PanelNum = clsGeneral.GetPanelId(Request.QueryString["pnl"]).ToString();

            ComboHelper.FillLU_EPM_Milestone(new DropDownList[] { drpMilestone }, true);
            ComboHelper.FillEPM_Milestone_Email_List(new ListBox[] { lstMail_Milestone, lstMail_MilestoneView }, true);

            clsEPM_Milestone ObjEPM_Milestone = new clsEPM_Milestone(PK_EPM_Milestone);
            ComboHelper.FillMailList_Milestone(new DropDownList[] { drpMail_List_from_Milestone }, true, Convert.ToDecimal(ObjEPM_Milestone.FK_LU_EPM_Milestone), LocationID, FK_EPM_Identification);
            BindHeaderInfo();
            GetOldMailRecipientsIDs();

            if (StrOperation.ToLower() == "edit")
            {
                BindMilestoneDetailsForEdit();
                btnViewAuditMilestone.Visible = true;
            }
            else if (StrOperation.ToLower() == "view")
            {
                BindMilestoneDetailsForView();
                btnViewAuditMilestone.Visible = true;
            }
            SetValidations();
            // store the location id in session
            Session["ExposureLocation"] = LocationID;
        }
        txtDateToday.Text = DateTime.Today.ToString("MM/dd/yyyy");
    }
    #endregion

    #region " Control Events "
    /// <summary>
    ///  Handles save Click Of Project Milestone
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSaveMilestone_OnClick(object sender, EventArgs e)
    {
        clsEPM_Milestone ObjEPM_Milestone = new clsEPM_Milestone();
        ObjEPM_Milestone.PK_EPM_Milestone = PK_EPM_Milestone;
        ObjEPM_Milestone.FK_EPM_Identification = FK_EPM_Identification;
        if (drpMilestone.SelectedIndex > 0) ObjEPM_Milestone.FK_LU_EPM_Milestone = Convert.ToDecimal(drpMilestone.SelectedValue);
        if (txtMilestone_Description.Text != "") ObjEPM_Milestone.Description = txtMilestone_Description.Text.Trim();
        if (txtMilestone_Date.Text != "") ObjEPM_Milestone.Milestone_Date = clsGeneral.FormatDateToStore(txtMilestone_Date.Text);
        if (rdoMailReminder.SelectedValue != "") ObjEPM_Milestone.Email_Reminder = rdoMailReminder.SelectedValue == "Y" ? true : false;
        if (drpMail_List_from_Milestone.SelectedIndex > 0) ObjEPM_Milestone.FK_EPM_Milestone = Convert.ToDecimal(drpMail_List_from_Milestone.SelectedValue);
        if (txtAdditional_Recipients.Text != "") ObjEPM_Milestone.Additional_Recipients = txtAdditional_Recipients.Text;
        ObjEPM_Milestone.Updated_By = clsSession.UserName;
        ObjEPM_Milestone.Update_Date = clsGeneral.FormatDateToStore(DateTime.Now);
        if (PK_EPM_Milestone > 0)
            ObjEPM_Milestone.Update();
        else
            PK_EPM_Milestone = ObjEPM_Milestone.Insert();


        clsEPM_Milestone_EMail_List.DeleteByFK(PK_EPM_Milestone);
        for (int i = 0; i < lstMail_Milestone.Items.Count; i++)
        {
            if (lstMail_Milestone.Items[i].Selected == true)
            {
                clsEPM_Milestone_EMail_List objEPM_Milestone_EMail_List = new clsEPM_Milestone_EMail_List();
                objEPM_Milestone_EMail_List.FK_EPM_Milestone = PK_EPM_Milestone;
                objEPM_Milestone_EMail_List.FK_Security_Id = Convert.ToDecimal(lstMail_Milestone.Items[i].Value);
                objEPM_Milestone_EMail_List.Updated_By = clsSession.UserName;
                objEPM_Milestone_EMail_List.Update_Date = clsGeneral.FormatDateToStore(DateTime.Now);

                PK_EPM_Milestone_EMail_List = objEPM_Milestone_EMail_List.Insert();
                PK_EPM_Milestone_EMail_List = 0;
            }
        }

        string strEPM_MilestoneRecipientsId = "";
        DataTable dtMail_Milestone = clsEPM_Milestone_EMail_List.SelectByFK(PK_EPM_Milestone, FK_EPM_Identification).Tables[0];
        if (dtMail_Milestone != null && dtMail_Milestone.Rows.Count > 0)
        {
            for (int i = 0; i < dtMail_Milestone.Rows.Count; i++)
            {
                strEPM_MilestoneRecipientsId += dtMail_Milestone.Rows[i]["FK_Security_Id"].ToString() + ",";
            }
            strEPM_MilestoneRecipientsId = strEPM_MilestoneRecipientsId.TrimEnd(',');
        }

        if (Milestone_Date == ObjEPM_Milestone.Milestone_Date && strEPM_MilestoneRecipientsId != MailrecipientsIDs)
        {
            if (strEPM_MilestoneRecipientsId != "")
            {
                DataTable dtMilestone = clsEPM_MilestoneRecipients.GetMilestoneRecipientsEmailId(MailrecipientsIDs, PK_EPM_Milestone).Tables[0];
                for (int i = 0; i < dtMilestone.Rows.Count; i++)
                {
                    string EmailTo = dtMilestone.Rows[i]["Email"].ToString();

                    string EmailSubject = "eRIMS2 Environmental Project Milestone – " + new LU_EPM_Milestone((decimal)ObjEPM_Milestone.FK_LU_EPM_Milestone).Fld_Desc + " – Project Number: " + lblHeaderProject_Number.Text + "";

                    //string EmailBody = "This e-mail is being sent to alert you that an Environmental Project Milestone for the " + new LU_EPM_Milestone((decimal)ObjEPM_Milestone.FK_LU_EPM_Milestone).Fld_Desc +
                    //    " for Project Number: " + lblHeaderProject_Number.Text + " has been scheduled for " + clsGeneral.FormatDBNullDateToDisplay(ObjEPM_Milestone.Milestone_Date) + ".";

                    string EmailBody = "<FONT FACE='Calibri'>This e-mail is being generated to inform you that the project due date for " + lblLocationdba.Text + " / " + lblHeaderProject_Number.Text + " will be due on " + clsGeneral.FormatDBNullDateToDisplay(ObjEPM_Milestone.Milestone_Date) + "." +
                        "<br><br>Project Type : " + lblHeaderProject_Type.Text + "<br><br>Project Description : " + hdnProjectDescription.Value.ToString() + "</FONT>";

                    SendMailandReminder(AppConfig.MailFrom, EmailTo, EmailSubject, EmailBody.Trim().Replace("\r\n", "<br/>"), Convert.ToDateTime(clsGeneral.FormatDBNullDateToDisplay(ObjEPM_Milestone.Milestone_Date)));
                    //clsGeneral.SendMailMessage(AppConfig.MailFrom, EmailTo, string.Empty, "", EmailSubject, EmailBody.Trim().Replace("\r\n", "<br/>"), true, new string[] { });
                }
            }
        }

        if (Milestone_Date != ObjEPM_Milestone.Milestone_Date)
        {
            if (strEPM_MilestoneRecipientsId != "")
            {
                DataTable dtMilestone = clsEPM_MilestoneRecipients.GetMilestoneRecipients_ForMileston_Date(strEPM_MilestoneRecipientsId).Tables[0];
                for (int i = 0; i < dtMilestone.Rows.Count; i++)
                {
                    string EmailTo = dtMilestone.Rows[i]["Email"].ToString();

                    string EmailSubject = "eRIMS2 Environmental Project Milestone – " + new LU_EPM_Milestone((decimal)ObjEPM_Milestone.FK_LU_EPM_Milestone).Fld_Desc + " – Project Number: " + lblHeaderProject_Number.Text + "";

                    //string EmailBody = "This e-mail is being sent to alert you that an Environmental Project Milestone for the " + new LU_EPM_Milestone((decimal)ObjEPM_Milestone.FK_LU_EPM_Milestone).Fld_Desc +
                    //    " for Project Number: " + lblHeaderProject_Number.Text + " has been scheduled for " + clsGeneral.FormatDBNullDateToDisplay(ObjEPM_Milestone.Milestone_Date) + ".";

                    string EmailBody = "<FONT FACE='Calibri'>This e-mail is being generated to inform you that the project due date for " + lblLocationdba.Text + " / " + lblHeaderProject_Number.Text + " will be due on " + clsGeneral.FormatDBNullDateToDisplay(ObjEPM_Milestone.Milestone_Date) + "." +
                        "<br><br>Project Type : " + lblHeaderProject_Type.Text + "<br><br>Project Description : " + hdnProjectDescription.Value.ToString() + "</FONT>";

                     SendMailandReminder(AppConfig.MailFrom, EmailTo, EmailSubject, EmailBody.Trim().Replace("\r\n", "<br/>"), Convert.ToDateTime(clsGeneral.FormatDBNullDateToDisplay(ObjEPM_Milestone.Milestone_Date)));
                    //clsGeneral.SendMailMessage(AppConfig.MailFrom, EmailTo, string.Empty, "", EmailSubject, EmailBody.Trim().Replace("\r\n", "<br/>"), true, new string[] { });
                
                }
            }
        }

        Response.Redirect("EPM_Project_Milestone.aspx?loc=" + Encryption.Encrypt(LocationID.ToString()) + "&id=" + Encryption.Encrypt(FK_EPM_Identification.ToString()) + "&PMI=" + Encryption.Encrypt(PK_EPM_Milestone.ToString()) + "&pnl=" + PanelNum + "&op=edit", true);
    }

    /// <summary>
    /// Handels Cancel Click of Cancel button and Redirect page to Project_Management's Page
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnCancelMilestone_OnClick(object sender, EventArgs e)
    {
        if (StrOperation.ToLower() == "add")
            StrOperation = "edit";
        Response.Redirect("Project_Management.aspx?loc=" + Encryption.Encrypt(LocationID.ToString()) + "&id=" + Encryption.Encrypt(FK_EPM_Identification.ToString()) + "&pnl=" + PanelNum + "&op=" + StrOperation, true);
    }

    /// <summary>
    /// Handles Selected Index Change of Dropdown Mileston
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void drpMilestone_SelectedIndexChanged(object sender, EventArgs e)
    {
        lstMail_Milestone.ClearSelection();
        if (drpMilestone.SelectedIndex > 0)
        {
            ComboHelper.FillMailList_Milestone(new DropDownList[] { drpMail_List_from_Milestone }, true, Convert.ToDecimal(drpMilestone.SelectedValue), LocationID, FK_EPM_Identification);
        }
    }

    /// <summary>
    /// Handles Selected Index changed of Dropdown Use E-Mail List from Milestone
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void drpMail_List_from_Milestone_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        if (drpMail_List_from_Milestone.SelectedIndex > 0)
        {
            lstMail_Milestone.ClearSelection();
            DataTable dtMail_Milestone = clsEPM_Milestone_EMail_List.SetEmailRecipients(FK_EPM_Identification, Convert.ToDecimal(drpMail_List_from_Milestone.SelectedValue)).Tables[0];
            if (dtMail_Milestone != null && dtMail_Milestone.Rows.Count > 0)
            {
                for (int i = 0; i < dtMail_Milestone.Rows.Count; i++)
                {
                    ListItem lst = null;
                    lst = lstMail_Milestone.Items.FindByValue(dtMail_Milestone.Rows[i]["FK_Security_Id"].ToString());
                    if (lst != null)
                        lst.Selected = true;
                }
            }
        }
        else
        {
            lstMail_Milestone.ClearSelection();
        }
    }

    /// <summary>
    /// Handles Selected Index Change of Mail Milestone list
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lstMail_Milestone_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        drpMail_List_from_Milestone.SelectedIndex = 0;
    }

    /// <summary>
    /// Hidden click to bind Milestone List
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnhdnBindMailList_OnClick(object sender, EventArgs e)
    {
        ComboHelper.FillEPM_Milestone_Email_List(new ListBox[] { lstMail_Milestone }, true);
        DataTable dtMail_Milestone = clsEPM_Milestone_EMail_List.SelectByFK(PK_EPM_Milestone, FK_EPM_Identification).Tables[0];
        if (dtMail_Milestone != null && dtMail_Milestone.Rows.Count > 0)
        {
            for (int i = 0; i < dtMail_Milestone.Rows.Count; i++)
            {
                ListItem lst = null;
                lst = lstMail_Milestone.Items.FindByValue(dtMail_Milestone.Rows[i]["FK_Security_Id"].ToString());
                if (lst != null)
                    lst.Selected = true;
            }
        }
    }
    #endregion

    #region " Private Method "
    /// <summary>
    /// bind Project Milestone detail for Edit mode
    /// </summary>
    private void BindMilestoneDetailsForEdit()
    {
        btnViewAuditMilestone.Visible = true;
        btnCancelMilestone.Text = btnCancelMilestone.Text.Replace("Cancel", "Back");

        clsEPM_Milestone ObjEPM_Milestone = new clsEPM_Milestone(PK_EPM_Milestone);
        if (ObjEPM_Milestone.FK_LU_EPM_Milestone != null) drpMilestone.SelectedValue = ObjEPM_Milestone.FK_LU_EPM_Milestone.ToString();
        if (ObjEPM_Milestone.Description != null) txtMilestone_Description.Text = ObjEPM_Milestone.Description;
        if (ObjEPM_Milestone.Milestone_Date != null) txtMilestone_Date.Text = clsGeneral.FormatDBNullDateToDisplay(ObjEPM_Milestone.Milestone_Date);
        if (ObjEPM_Milestone.Email_Reminder != null) rdoMailReminder.SelectedValue = ObjEPM_Milestone.Email_Reminder == true ? "Y" : "N";
        if (ObjEPM_Milestone.FK_EPM_Milestone != null) drpMail_List_from_Milestone.SelectedValue = ObjEPM_Milestone.FK_EPM_Milestone.ToString();
        if (ObjEPM_Milestone.Additional_Recipients != null) txtAdditional_Recipients.Text = ObjEPM_Milestone.Additional_Recipients;
        Milestone_Date = Convert.ToDateTime(ObjEPM_Milestone.Milestone_Date);
        DataTable dtMail_Milestone = clsEPM_Milestone_EMail_List.SelectByFK(PK_EPM_Milestone, FK_EPM_Identification).Tables[0];
        if (dtMail_Milestone != null && dtMail_Milestone.Rows.Count > 0)
        {
            for (int i = 0; i < dtMail_Milestone.Rows.Count; i++)
            {
                ListItem lst = null;
                lst = lstMail_Milestone.Items.FindByValue(dtMail_Milestone.Rows[i]["FK_Security_Id"].ToString());
                if (lst != null)
                    lst.Selected = true;
            }
        }
    }

    /// <summary>
    /// bind Project Milestone detail for view mode
    /// </summary>
    private void BindMilestoneDetailsForView()
    {
        btnViewAuditMilestone.Visible = true;
        btnSaveMilestone.Visible = false;
        dvEdit.Style["display"] = "none";
        divView.Style["display"] = "";
        btnCancelMilestone.Text = btnCancelMilestone.Text.Replace("Cancel", "Back");

        clsEPM_Milestone ObjEPM_Milestone = new clsEPM_Milestone(PK_EPM_Milestone);
        if (ObjEPM_Milestone.FK_LU_EPM_Milestone != null) lblMilestone.Text = new LU_EPM_Milestone((decimal)ObjEPM_Milestone.FK_LU_EPM_Milestone).Fld_Desc;
        if (ObjEPM_Milestone.Description != null) lblMilestone_Description.Text = ObjEPM_Milestone.Description;
        if (ObjEPM_Milestone.Milestone_Date != null) lblMilestone_Date.Text = clsGeneral.FormatDBNullDateToDisplay(ObjEPM_Milestone.Milestone_Date);
        if (ObjEPM_Milestone.Email_Reminder != null) lblMailReminder.Text = ObjEPM_Milestone.Email_Reminder == true ? "Yes" : "No";
        if (ObjEPM_Milestone.FK_EPM_Milestone != null) lblMail_List_from_Milestone.Text = ObjEPM_Milestone.FK_EPM_Milestone.ToString();
        if (ObjEPM_Milestone.Additional_Recipients != null) lblAdditional_Recipients.Text = ObjEPM_Milestone.Additional_Recipients;

        DataTable dtMail_MilestoneView = clsEPM_Milestone_EMail_List.SelectByFK(PK_EPM_Milestone, FK_EPM_Identification).Tables[0];
        if (dtMail_MilestoneView != null && dtMail_MilestoneView.Rows.Count > 0)
        {
            for (int i = 0; i < dtMail_MilestoneView.Rows.Count; i++)
            {
                ListItem lst = null;
                lst = lstMail_MilestoneView.Items.FindByValue(dtMail_MilestoneView.Rows[i]["FK_Security_Id"].ToString());
                if (lst != null)
                    lst.Selected = true;
            }
        }
    }

    /// <summary>
    /// Bind Header Info
    /// </summary>
    private void BindHeaderInfo()
    {
        DataTable dtLocationInfo = LU_Location.SelectByPK(LocationID).Tables[0];
        if (dtLocationInfo != null && dtLocationInfo.Rows.Count > 0)
        {
            lblLocation_Number.Text = (dtLocationInfo.Rows[0]["Sonic_Location_Code"].ToString() != "") ? dtLocationInfo.Rows[0]["Sonic_Location_Code"].ToString() : "";
            lblLocationdba.Text = (dtLocationInfo.Rows[0]["dba"].ToString() != "") ? dtLocationInfo.Rows[0]["dba"].ToString() : "";
            lblAddress.Text = (dtLocationInfo.Rows[0]["Address"].ToString() != "") ? dtLocationInfo.Rows[0]["Address"].ToString() : "";
            lblCity.Text = (dtLocationInfo.Rows[0]["City"].ToString() != "") ? dtLocationInfo.Rows[0]["City"].ToString() : "";
            lblState.Text = (dtLocationInfo.Rows[0]["StateName"].ToString() != "") ? dtLocationInfo.Rows[0]["StateName"].ToString() : "";
            lblZip.Text = (dtLocationInfo.Rows[0]["Zip_Code"].ToString() != "") ? dtLocationInfo.Rows[0]["Zip_Code"].ToString() : "";
        }

        DataTable dtProjectNumber = clsEPM_Identification.GetProjectNumber(LocationID, FK_EPM_Identification).Tables[0];
        if (dtProjectNumber != null && dtProjectNumber.Rows.Count > 0)
        {
            lblHeaderProject_Number.Text = (dtProjectNumber.Rows[0]["Project_Number"].ToString() != "") ? dtProjectNumber.Rows[0]["Project_Number"].ToString() : "";
            lblHeaderProject_Type.Text = (dtProjectNumber.Rows[0]["Project_Type"].ToString() != "") ? dtProjectNumber.Rows[0]["Project_Type"].ToString() : "";
            hdnProjectDescription.Value = (dtProjectNumber.Rows[0]["Project_Description"].ToString() != "") ? dtProjectNumber.Rows[0]["Project_Description"].ToString() : "";
            tdProjectNum.Style["display"] = "block"; tdHeaderPro_Num.Style["display"] = "block"; tdHeaderProType.Style["display"] = "block"; tdProjectType.Style["display"] = "block";
        }
    }

    /// <summary>
    /// Bind selected Mail Recipient's IDs
    /// </summary>
    private void GetOldMailRecipientsIDs()
    {
        DataTable dtMail_Milestone = clsEPM_Milestone_EMail_List.SelectByFK(PK_EPM_Milestone, FK_EPM_Identification).Tables[0];
        if (dtMail_Milestone != null && dtMail_Milestone.Rows.Count > 0)
        {
            for (int i = 0; i < dtMail_Milestone.Rows.Count; i++)
            {
                MailrecipientsIDs += dtMail_Milestone.Rows[i]["FK_Security_Id"].ToString() + ",";
            }
            MailrecipientsIDs = MailrecipientsIDs.TrimEnd(',');
        }
    }

    private void SendMailandReminder(string MailFrom, string EmailTo, string EmailSubject, string EmailBody,  DateTime Milestone_Date)
    {
        try
        {
            string organizerName = ""; //Organizer Name
            string organizerEmail = AppConfig.MailFrom;

            string description = "";
            //string location = Meeting_Place;
            string subject = EmailSubject;
            string UID = Guid.NewGuid().ToString();
            DateTime start = Convert.ToDateTime(clsGeneral.FormatDBNullDateToDisplay(Milestone_Date) + " 09:00 AM");

            DateTime end = start.AddHours(2);

            string strStart = string.Format("{0:yyyyMMddTHHmm00}Z", start.ToUniversalTime());
            string strEnd = string.Format("{0:yyyyMMddTHHmm00}Z", end.ToUniversalTime());

            System.Text.StringBuilder sw = new System.Text.StringBuilder();
            sw.AppendLine("BEGIN:VCALENDAR");
            sw.AppendLine("VERSION:2.0");
            sw.AppendLine("METHOD:REQUEST");
            sw.AppendLine("BEGIN:VEVENT");
            sw.AppendLine(EmailTo);
            sw.AppendLine("CLASS:PUBLIC");
            //sw.AppendLine("DESCRIPTION:" + EmailBody);
            sw.AppendLine("CREATED:" + start.ToString() + Environment.NewLine);
            sw.AppendLine("DTSTAMP:" + strStart + Environment.NewLine);
            sw.AppendLine("DTSTART:" + strStart + Environment.NewLine);
            sw.AppendLine("DTEND:" + strEnd + Environment.NewLine);
            sw.AppendLine("ORGANIZER;CN=\"" + organizerName + "\":mailto:" + organizerEmail);
            sw.AppendLine("SEQUENCE:0");
            sw.AppendLine("UID:" + UID);
            sw.AppendLine("LOCATION:");
            sw.AppendLine("SUMMARY;LANGUAGE=en-us:" + EmailSubject);
            sw.AppendLine("X-ALT-DESC;FMTTYPE=text/html:" + EmailBody);
            sw.AppendLine("BEGIN:VALARM");
            sw.AppendLine("TRIGGER:-PT720M");
            sw.AppendLine("ACTION:DISPLAY");
            sw.AppendLine("DESCRIPTION:Reminder");
            sw.AppendLine("END:VALARM");
            sw.AppendLine("END:VEVENT");
            sw.AppendLine("END:VCALENDAR");

            System.Net.Mime.ContentType mimeType = new System.Net.Mime.ContentType("text/calendar; method=REQUEST");
            System.Net.Mail.AlternateView ICSview = System.Net.Mail.AlternateView.CreateAlternateViewFromString(sw.ToString(), mimeType);
            System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage();
            message.To.Add(EmailTo);
            message.From = new System.Net.Mail.MailAddress(AppConfig.MailFrom);
            message.AlternateViews.Add(ICSview);


            System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient();
            client.Host = AppConfig.SMTPServer;
            client.Credentials = new System.Net.NetworkCredential(AppConfig.MailFrom, AppConfig.SMTPpwd);
            client.Send(message);
        }
        catch (Exception ex)
        {

        }

    }
    #endregion

    #region " Dynamic validations "
    /// <summary>
    /// set dynamic validation
    /// </summary>
    private void SetValidations()
    {
        #region " Project Milestone "
        string strCtrlsIDsProjectMilestone = "";
        string strMessagesProjectMilestone = "";
        DataTable dtFieldsProjectMilestone = clsScreen_Validators.SelectByScreen(197).Tables[0];
        dtFieldsProjectMilestone.DefaultView.RowFilter = "IsRequired = '1'";
        dtFieldsProjectMilestone = dtFieldsProjectMilestone.DefaultView.ToTable();
        MenuAsterisk1.Style["display"] = (dtFieldsProjectMilestone.Select("LeftMenuIndex = 1").Length > 0) ? "inline-block" : "none";
        foreach (DataRow drFieldsProjectMilestone in dtFieldsProjectMilestone.Rows)
        {
            #region " set validation control IDs and messages "
            switch (Convert.ToString(drFieldsProjectMilestone["Field_Name"]))
            {
                case "Milestone": strCtrlsIDsProjectMilestone += drpMilestone.ClientID + ","; strMessagesProjectMilestone += "Please select [Project Milestone]/Milestone" + ","; Span1.Style["display"] = "inline-block"; break;
                case "Milestone Description": strCtrlsIDsProjectMilestone += txtMilestone_Description.ClientID + ","; strMessagesProjectMilestone += "Please enter [Project Milestone]/Milestone Description" + ","; Span2.Style["display"] = "inline-block"; break;
                case "Milestone Date ": strCtrlsIDsProjectMilestone += txtMilestone_Date.ClientID + ","; strMessagesProjectMilestone += "Please enter [Project Milestone]/Milestone Date " + ","; Span3.Style["display"] = "inline-block"; break;
                case "Use E-Mail List from Milestone ": strCtrlsIDsProjectMilestone += drpMail_List_from_Milestone.ClientID + ","; strMessagesProjectMilestone += "Please select [Project Milestone]/Use E-Mail List from Milestone " + ","; Span5.Style["display"] = "inline-block"; break;
                case "E-Mail Recipients": strCtrlsIDsProjectMilestone += lstMail_Milestone.ClientID + ","; strMessagesProjectMilestone += "Please enter [Project Milestone]/E-Mail Recipients" + ","; Span6.Style["display"] = "inline-block"; break;
                case "Additional Recipients": strCtrlsIDsProjectMilestone += txtAdditional_Recipients.ClientID + ","; strMessagesProjectMilestone += "Please enter [Project Milestone]/Additional Recipients" + ","; Span7.Style["display"] = "inline-block"; break;
            }
            #endregion
        }
        strCtrlsIDsProjectMilestone = strCtrlsIDsProjectMilestone.TrimEnd(',');
        strMessagesProjectMilestone = strMessagesProjectMilestone.TrimEnd(',');

        hdnControlIDsProjectMilestone.Value = strCtrlsIDsProjectMilestone;
        hdnErrorMsgsProjectMilestone.Value = strMessagesProjectMilestone;

        #endregion
    }
    #endregion
}