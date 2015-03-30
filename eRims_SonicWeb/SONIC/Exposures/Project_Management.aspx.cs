using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERIMS.DAL;
using System.Data;
using Winnovative.WnvHtmlConvert;
using System.Web.UI.HtmlControls;

public partial class SONIC_Exposures_Project_Management : clsBasePage
{
    #region " Properties "
    /// <summary>
    /// Denote Location ID for Environmental Project Management Data
    /// </summary>
    public int LocationID
    {
        get { return Convert.ToInt32(ViewState["loc"]); }
        set { ViewState["loc"] = value; }
    }

    /// <summary>
    /// denotes Primary Key of EPM_Identification table
    /// </summary>
    public decimal PK_EPM_Identification
    {
        get { return Convert.ToDecimal(ViewState["PK_EPM_Identification"]); }
        set { ViewState["PK_EPM_Identification"] = value; }
    }

    /// <summary>
    /// denotes Primary Key of EPM_Identification_Building table
    /// </summary>
    public decimal PK_EPM_Identification_Building
    {
        get { return Convert.ToDecimal(ViewState["PK_EPM_Identification_Building"]); }
        set { ViewState["PK_EPM_Identification_Building"] = value; }
    }

    /// <summary>
    /// denotes Primary Key of EPM_Identification_Equipmen table
    /// </summary>
    public decimal PK_EPM_Identification_Equipment
    {
        get { return Convert.ToDecimal(ViewState["PK_EPM_Identification_Equipment"]); }
        set { ViewState["PK_EPM_Identification_Equipment"] = value; }
    }

    /// <summary>
    /// denotes Primary Key of EPM_Identification_TargetArea table
    /// </summary>
    public decimal PK_EPM_Identification_TargetArea
    {
        get { return Convert.ToDecimal(ViewState["PK_EPM_Identification_TargetArea"]); }
        set { ViewState["PK_EPM_Identification_TargetArea"] = value; }
    }

    /// <summary>
    /// denotes Primary Key of EPM_Identification_PurposeOfProject table
    /// </summary>
    public decimal PK_EPM_Identification_PurposeOfProject
    {
        get { return Convert.ToDecimal(ViewState["PK_EPM_Identification_PurposeOfProject"]); }
        set { ViewState["PK_EPM_Identification_PurposeOfProject"] = value; }
    }

    /// <summary>
    /// denotes Primary Key of EPM_Identification_ExistingDocuments table
    /// </summary>
    public decimal PK_EPM_Identification_ExistingDocuments
    {
        get { return Convert.ToDecimal(ViewState["PK_EPM_Identification_ExistingDocuments"]); }
        set { ViewState["PK_EPM_Identification_ExistingDocuments"] = value; }
    }

    /// <summary>
    /// denotes Primary Key of EPM_Consultant table
    /// </summary>
    public decimal PK_EPM_Consultant
    {
        get { return Convert.ToDecimal(ViewState["PK_EPM_Consultant"]); }
        set { ViewState["PK_EPM_Consultant"] = value; }
    }

    /// <summary>
    /// denotes Primary Key of EPM_Consultant table
    /// </summary>
    public decimal PK_EPM_Action_Notes
    {
        get { return Convert.ToDecimal(ViewState["PK_EPM_Action_Notes"]); }
        set { ViewState["PK_EPM_Action_Notes"] = value; }
    }

    /// <summary>
    /// denotes Primary Key of EPM_Schedule table
    /// </summary>
    public decimal PK_EPM_Schedule
    {
        get { return Convert.ToDecimal(ViewState["PK_EPM_Schedule"]); }
        set { ViewState["PK_EPM_Schedule"] = value; }
    }

    /// <summary>
    /// Denotes the operation whether edit or view
    /// </summary>
    public string StrOperation
    {
        get { return Convert.ToString(ViewState["strOperation"]); }
        set { ViewState["strOperation"] = value; }
    }

    public int CurrentPage
    {
        get { return Convert.ToInt32(ViewState["CurrentPage"]); }
        set { ViewState["CurrentPage"] = value; }
    }
    public int PageSize
    {
        get { return Convert.ToInt32(ViewState["PageSize"]); }
        set { ViewState["PageSize"] = value; }
    }
    #endregion

    #region " Page Load "
    /// <summary>
    /// page load event
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
            PK_EPM_Identification = Convert.ToDecimal(Encryption.Decrypt(Request.QueryString["id"].ToString()));            

            clsEPM_Action_Notes ObjEPM_Action_Notes = new clsEPM_Action_Notes(Convert.ToInt32(PK_EPM_Identification));
            if (ObjEPM_Action_Notes.PK_EPM_Action_Notes != null)
                PK_EPM_Action_Notes = ObjEPM_Action_Notes.PK_EPM_Action_Notes.Value;
                       
            StrOperation = Request.QueryString["op"].ToString();
            hdnPanel.Value = clsGeneral.GetPanelId(Request.QueryString["pnl"]).ToString();
            CheckValidRequest();
            BindBuildings();
            BindEquipment();
            BindDropDowns();
            bindProjectCostGrid();            
            BindEPMActionNotes();
            bindProjectMilestoneGrid();
            BindHeaderInfo();
            BindInvoiceGrid();
            BindConsultantNotes();

            if (StrOperation.ToLower() == "edit")
            {

                BindDetatisForEdit();
                btnAuditTrail.Style["display"] = "";
                EnableDisableControls();

            }
            else if (StrOperation.ToLower() == "view")
            {
                BindDetailForView();                
                btnAuditTrail.Style["display"] = "";
            }
            else
            {
                txtRequired_Activity_Description.Enabled = false;
            }

            ctrlAttachment.FK_EPM_Identification = PK_EPM_Identification;
            ctrlAttachment.StrOperation = StrOperation;

            SetValidations();

            // store the location id in session
            Session["ExposureLocation"] = LocationID;
            ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(" + hdnPanel.Value + ");", true);
        }
        else
        {
            string eventTarget = (this.Request["__EVENTTARGET"] == null) ? string.Empty : this.Request["__EVENTTARGET"];
            string eventArgument = (this.Request["__EVENTARGUMENT"] == null) ? string.Empty : this.Request["__EVENTARGUMENT"];
            if (eventTarget == "ctl00_ContentPlaceHolder1_btnSave")
            {
                SaveData();
                if (PK_EPM_Identification > 0)
                    BindDetatisForEdit();
                
                ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(" + this.Request["__EVENTARGUMENT"] + ");", true);
            }
            else
            {
                ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(" + hdnPanel.Value + ");", true);
            }
        }       
    }
    #endregion

    #region " private Methods "
    /// <summary>
    /// Check For User Access and valid parameter Location ID
    /// </summary>
    private void CheckValidRequest()
    {
        int Location_Id;
        // Check if User has right To Add Equipment or View Equipment
        if (App_Access == AccessType.View_Only)
        {
            Response.Redirect(AppConfig.SiteURL + "Error.aspx?msg=errAcc", true);
        }

        // Check whether Paramenter Location ID is valid int
        // if not provided then redirect to search page.
        if (!int.TryParse(Encryption.Decrypt(Request.QueryString["loc"]), out Location_Id))
        {
            Response.Redirect("~/SONIC/Exposures/ExposureSearch.aspx", true);
            return;
        }
        else
        {
            LocationID = Location_Id;
        }

        // Check if Location ID is exists or Not
        // if not then redirect to ExposureSearch Page.
        if (LU_Location.SelectByPK(Location_Id).Tables[0].Rows.Count == 0)
        {
            Response.Redirect("~/SONIC/Exposures/ExposureSearch.aspx", true);
            return;
        }

        Session["ExposureLocation"] = LocationID;
    }

    /// <summary>
    /// Bind Dropdowns
    /// </summary>
    private void BindDropDowns()
    {
        ComboHelper.FillEPM_Project_Type(new DropDownList[] { drpProject_Type }, true);
        ComboHelper.FillEPM_Requesting_Agency(new DropDownList[] { drpRequesting_Entity }, true);
        ComboHelper.FillEPM_TargetArea(new ListBox[] { lstTargetArea, lstTargetAreaView }, true);
        ComboHelper.FillState(new DropDownList[] { drpConsultant_State }, 0, true);
        ComboHelper.FillLU_EPM_Required_Activity(new DropDownList[] { drpRequired_Activity }, true);
        ComboHelper.FillLU_EPM_Outcome(new DropDownList[] { drpOutcome }, true);
        ComboHelper.FillCompanionToProject(new DropDownList[] { drpCompanion_to_Project }, true, LocationID, PK_EPM_Identification);
        ComboHelper.FillEPM_PurposeOfProject(new ListBox[] { lstPurpose_Of_Project, lstPurpose_Of_ProjectView }, true);
        ComboHelper.FillEPM_ExistingDocuments(new ListBox[] { lstExistingDocuments, lstExistingDocumentsView }, true);
    }

    /// <summary>
    /// bind Building data in radio button list
    /// </summary>
    private void BindBuildings()
    {
        chkBuilding.ClearSelection();
        chkBuildingView.ClearSelection();
        DataTable dtBuilding = Building.BuildingByFKLocation(LocationID).Tables[0];
        if (StrOperation.ToLower() != "view")
        {
            chkBuilding.DataSource = dtBuilding;
            chkBuilding.DataTextField = "Building_Occupacy";
            chkBuilding.DataValueField = "PK_Building_ID";
            chkBuilding.DataBind();
        }
        else
        {
            chkBuildingView.DataSource = dtBuilding;
            chkBuildingView.DataTextField = "Building_Occupacy";
            chkBuildingView.DataValueField = "PK_Building_ID";
            chkBuildingView.DataBind();
        }
    }

    /// <summary>
    /// bind Equipment data in Listbox
    /// </summary>
    private void BindEquipment()
    {
        lstEquipment.ClearSelection();
        lstEquipmentView.ClearSelection();

        string strBuildingIDs = "";

        DataTable dt = clsEPM_Identification_Building.SelectByFK(PK_EPM_Identification).Tables[0];
        if (dt != null && dt.Rows.Count > 0)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                strBuildingIDs += dt.Rows[i]["FK_Building"].ToString() + ",";
            }
        }

        strBuildingIDs = strBuildingIDs.TrimEnd(',');
        ctrlAttachment.Building_IDs = strBuildingIDs;
        if (strBuildingIDs != "")
        {
            DataTable dtEquipment = clsEPM_Identification_Building.GetDistinctEquipments(strBuildingIDs).Tables[0];
            if (dtEquipment != null && dtEquipment.Rows.Count > 0)
            {
                if (StrOperation.ToLower() != "view")
                {
                    lstEquipment.DataSource = dtEquipment;
                    lstEquipment.DataTextField = "Fld_Desc";
                    lstEquipment.DataValueField = "PK_LU_Equipment_Type_Pollution";
                    lstEquipment.DataBind();
                }
                else
                {
                    lstEquipmentView.DataSource = dtEquipment;
                    lstEquipmentView.DataTextField = "Fld_Desc";
                    lstEquipmentView.DataValueField = "PK_LU_Equipment_Type_Pollution";
                    lstEquipmentView.DataBind();
                }
            }
        }
    }

    /// <summary>
    /// Saves Data
    /// </summary>
    private void SaveData()
    {
        #region  " Identification "
        if (hdnPanel.Value.ToString() == "1")
        {
            clsEPM_Identification objclsEPM_Identification = new clsEPM_Identification();
            objclsEPM_Identification.PK_EPM_Identification = PK_EPM_Identification;
            objclsEPM_Identification.FK_LU_Location_Id = LocationID;
            if (drpCompanion_to_Project.SelectedIndex > 0) objclsEPM_Identification.FK_EPM_Identification = Convert.ToDecimal(drpCompanion_to_Project.SelectedValue);
            if (txtProject_Number.Text != "") objclsEPM_Identification.Project_Number = txtProject_Number.Text.Trim();
            if (drpProject_Type.SelectedIndex > 0) objclsEPM_Identification.FK_LU_EPM_Project_Type = Convert.ToDecimal(drpProject_Type.SelectedValue);
            if (txtProject_Description.Text != "") objclsEPM_Identification.Project_Description = txtProject_Description.Text.Trim();
            if (drpRequesting_Entity.SelectedIndex > 0) objclsEPM_Identification.FK_LU_EPM_Requesting_Entity = Convert.ToDecimal(drpRequesting_Entity.SelectedValue);
            if (txtOther_Requesting_Entity_Desc.Text != "") objclsEPM_Identification.Other_Requesting_Entity = txtOther_Requesting_Entity_Desc.Text.Trim();
            else
                objclsEPM_Identification.Other_Requesting_Entity = null;

            if (txtOther_Target_Area_Desc.Text != "") objclsEPM_Identification.Other_Target_Area = txtOther_Target_Area_Desc.Text.Trim();
            else
                objclsEPM_Identification.Other_Target_Area = null;

            if (txtPurpose_of_Project_Other_Description.Text != "") objclsEPM_Identification.Other_PurposeOfProject = txtPurpose_of_Project_Other_Description.Text.Trim();
            else
                objclsEPM_Identification.Other_PurposeOfProject = null;

            if (txtPerson_Requesting_Work.Text != "") objclsEPM_Identification.Person_Requesting_Work = txtPerson_Requesting_Work.Text.Trim();
            if (txtTitle_of_Person_RequestingWork.Text != "") objclsEPM_Identification.Title_of_Person_Requesting_Work = txtTitle_of_Person_RequestingWork.Text.Trim();

            objclsEPM_Identification.Updated_By = clsSession.UserName;
            objclsEPM_Identification.Update_Date = clsGeneral.FormatDateToStore(DateTime.Now);
            hdnchkBuilding.Value = "";

            if (txtName.Text != "") objclsEPM_Identification.Site_Contact_Name = txtName.Text.Trim();
            if (txtEmail.Text != "") objclsEPM_Identification.Site_Contact_Email = txtEmail.Text.Trim();
            if (txtTelephone.Text != "") objclsEPM_Identification.Site_Contact_Telephone = txtTelephone.Text.Trim();


            if (PK_EPM_Identification > 0)
                PK_EPM_Identification = objclsEPM_Identification.Update();
            else
                PK_EPM_Identification = objclsEPM_Identification.Insert();

            clsEPM_Identification_Building.DeleteByFK(PK_EPM_Identification);
            for (int i = 0; i < chkBuilding.Items.Count; i++)
            {
                if (chkBuilding.Items[i].Selected == true)
                {
                    clsEPM_Identification_Building objclsEPM_Identification_Building = new clsEPM_Identification_Building();
                    objclsEPM_Identification_Building.FK_EPM_Identification = PK_EPM_Identification;
                    objclsEPM_Identification_Building.FK_Building = Convert.ToDecimal(chkBuilding.Items[i].Value);
                    objclsEPM_Identification_Building.Updated_By = clsSession.UserName;
                    objclsEPM_Identification_Building.Update_Date = clsGeneral.FormatDateToStore(DateTime.Now);

                    PK_EPM_Identification_Building = objclsEPM_Identification_Building.Insert();
                    PK_EPM_Identification_Building = 0;
                }
            }

            clsEPM_Identification_Equipment.DeleteByFK(PK_EPM_Identification);
            for (int i = 0; i < lstEquipment.Items.Count; i++)
            {
                if (lstEquipment.Items[i].Selected == true)
                {
                    clsEPM_Identification_Equipment objclsEPM_Identification_Equipment = new clsEPM_Identification_Equipment();
                    objclsEPM_Identification_Equipment.FK_EPM_Identification = PK_EPM_Identification;
                    objclsEPM_Identification_Equipment.FK_LU_Eqipment_Type_Pollution = Convert.ToDecimal(lstEquipment.Items[i].Value);
                    objclsEPM_Identification_Equipment.Updated_By = clsSession.UserName;
                    objclsEPM_Identification_Equipment.Update_Date = clsGeneral.FormatDateToStore(DateTime.Now);

                    PK_EPM_Identification_Equipment = objclsEPM_Identification_Equipment.Insert();
                    PK_EPM_Identification_Equipment = 0;
                }
            }

            clsEPM_Identification_TargetArea.DeleteByFK(PK_EPM_Identification);
            for (int i = 0; i < lstTargetArea.Items.Count; i++)
            {
                if (lstTargetArea.Items[i].Selected == true)
                {
                    clsEPM_Identification_TargetArea objEPM_Identification_TargetArea = new clsEPM_Identification_TargetArea();
                    objEPM_Identification_TargetArea.FK_EPM_Identification = PK_EPM_Identification;
                    objEPM_Identification_TargetArea.FK_LU_EPM_TargetArea = Convert.ToDecimal(lstTargetArea.Items[i].Value);
                    objEPM_Identification_TargetArea.Updated_By = clsSession.UserName;
                    objEPM_Identification_TargetArea.Update_Date = clsGeneral.FormatDateToStore(DateTime.Now);

                    PK_EPM_Identification_TargetArea = objEPM_Identification_TargetArea.Insert();
                    PK_EPM_Identification_TargetArea = 0;
                }
            }
            clsEPM_Identification_PurposeOfProject.DeleteByFK(PK_EPM_Identification);
            for (int i = 0; i < lstPurpose_Of_Project.Items.Count; i++)
            {
                if (lstPurpose_Of_Project.Items[i].Selected == true)
                {
                    clsEPM_Identification_PurposeOfProject objEPM_Identification_PurposeOfProject = new clsEPM_Identification_PurposeOfProject();
                    objEPM_Identification_PurposeOfProject.FK_EPM_Identification = PK_EPM_Identification;
                    objEPM_Identification_PurposeOfProject.FK_LU_EPM_PurposeOfProject = Convert.ToDecimal(lstPurpose_Of_Project.Items[i].Value);
                    objEPM_Identification_PurposeOfProject.Updated_By = clsSession.UserName;
                    objEPM_Identification_PurposeOfProject.Update_Date = clsGeneral.FormatDateToStore(DateTime.Now);

                    PK_EPM_Identification_PurposeOfProject = objEPM_Identification_PurposeOfProject.Insert();
                    PK_EPM_Identification_PurposeOfProject = 0;
                }
            }

            clsEPM_Identification_ExistingDocuments.DeleteByFK(PK_EPM_Identification);
            for (int i = 0; i < lstExistingDocuments.Items.Count; i++)
            {
                if (lstExistingDocuments.Items[i].Selected == true)
                {
                    clsEPM_Identification_ExistingDocuments objEPM_Identification_PurposeOfProject = new clsEPM_Identification_ExistingDocuments();
                    objEPM_Identification_PurposeOfProject.FK_EPM_Identification = PK_EPM_Identification;
                    objEPM_Identification_PurposeOfProject.FK_LU_EPM_ExistingDocuments = Convert.ToDecimal(lstExistingDocuments.Items[i].Value);
                    objEPM_Identification_PurposeOfProject.Updated_By = clsSession.UserName;
                    objEPM_Identification_PurposeOfProject.Update_Date = clsGeneral.FormatDateToStore(DateTime.Now);

                    PK_EPM_Identification_ExistingDocuments = objEPM_Identification_PurposeOfProject.Insert();
                    PK_EPM_Identification_ExistingDocuments = 0;
                }
            }
        }
        #endregion

        #region " Consultant And Schedule "
        if (hdnPanel.Value.ToString() == "2")
        {
            if (PK_EPM_Identification > 0)
            {
                clsEPM_Consultant ObjEPM_Consultant = new clsEPM_Consultant(Convert.ToInt32(PK_EPM_Identification));
                ObjEPM_Consultant.FK_EPM_Identification = PK_EPM_Identification;
                if (rdoHartNHickMan.Checked) { ObjEPM_Consultant.HH_Or_Other = true; } else { ObjEPM_Consultant.HH_Or_Other = false; }
                if (txtConsultant_Company.Text != "") ObjEPM_Consultant.Consultant_Company = txtConsultant_Company.Text.Trim();
                else ObjEPM_Consultant.Consultant_Company = null;
                if (txtConsultant_Address1.Text != "") ObjEPM_Consultant.Consultant_Address_1 = txtConsultant_Address1.Text.Trim();
                else ObjEPM_Consultant.Consultant_Address_1 = null;
                if (txtConsultant_Address2.Text != "") ObjEPM_Consultant.Consultant_Address_2 = txtConsultant_Address2.Text.Trim();
                else ObjEPM_Consultant.Consultant_Address_2 = null;
                if (txtConsultant_City.Text != "") ObjEPM_Consultant.Consultant_City = txtConsultant_City.Text.Trim();
                else ObjEPM_Consultant.Consultant_City = null;
                if (drpConsultant_State.SelectedIndex > 0) ObjEPM_Consultant.FK_State = Convert.ToDecimal(drpConsultant_State.SelectedValue);
                else ObjEPM_Consultant.FK_State = null;
                if (txtConsultant_Zip_Code.Text != "") ObjEPM_Consultant.Consultant_Zip_Code = txtConsultant_Zip_Code.Text.Trim();
                else ObjEPM_Consultant.Consultant_Zip_Code = null;
                if (txtConsultant_Contact_Name.Text != "") ObjEPM_Consultant.Consultant_Contact_Name = txtConsultant_Contact_Name.Text.Trim();
                else ObjEPM_Consultant.Consultant_Contact_Name = null;
                if (txtConsultant_Contact_Telephone.Text != "") ObjEPM_Consultant.Consutlant_Telephone = txtConsultant_Contact_Telephone.Text.Trim();
                else ObjEPM_Consultant.Consutlant_Telephone = null;
                if (txtConsultant_Contact_EMail.Text != "") ObjEPM_Consultant.Constulant_Email = txtConsultant_Contact_EMail.Text.Trim();
                else ObjEPM_Consultant.Constulant_Email = null;
                ObjEPM_Consultant.Updated_By = clsSession.UserName;
                ObjEPM_Consultant.Update_Date = clsGeneral.FormatDateToStore(DateTime.Now);

                if (ObjEPM_Consultant.PK_EPM_Consultant > 0)
                    PK_EPM_Consultant = ObjEPM_Consultant.Update();
                else
                    PK_EPM_Consultant = ObjEPM_Consultant.Insert();

                clsEPM_Schedule objEPM_Schedule = new clsEPM_Schedule(Convert.ToInt32(PK_EPM_Identification));
                objEPM_Schedule.FK_EPM_Identification = PK_EPM_Identification;
                if (txtDate_to_Consultant.Text != "") objEPM_Schedule.Date_To_Consultant = clsGeneral.FormatNullDateToStore(txtDate_to_Consultant.Text);
                else objEPM_Schedule.Date_To_Consultant = null;
                if (txtRM_Notification_Date.Text != "") objEPM_Schedule.RM_Notification_Date = clsGeneral.FormatNullDateToStore(txtRM_Notification_Date.Text);
                else objEPM_Schedule.RM_Notification_Date = null;
                if (txtEstimated_Project_StartDate.Text != "") objEPM_Schedule.Estimated_Project_Start_Date = clsGeneral.FormatNullDateToStore(txtEstimated_Project_StartDate.Text);
                else objEPM_Schedule.Estimated_Project_Start_Date = null;
                if (txtActual_Project_StartDate.Text != "") objEPM_Schedule.Actual_Project_Start_Date = clsGeneral.FormatNullDateToStore(txtActual_Project_StartDate.Text);
                else objEPM_Schedule.Actual_Project_Start_Date = null;
                if (txtEstimated_Project_CompletionDate.Text != "") objEPM_Schedule.Estimated_Project_Completion_Date = clsGeneral.FormatNullDateToStore(txtEstimated_Project_CompletionDate.Text);
                else objEPM_Schedule.Estimated_Project_Completion_Date = null;
                if (txtActual_Project_CompletionDate.Text != "") objEPM_Schedule.Actual_Project_Completion_Date = clsGeneral.FormatNullDateToStore(txtActual_Project_CompletionDate.Text);
                else objEPM_Schedule.Actual_Project_Completion_Date = null;

                objEPM_Schedule.Updated_By = clsSession.UserName;
                objEPM_Schedule.Update_Date = clsGeneral.FormatDateToStore(DateTime.Now);

                if (objEPM_Schedule.PK_EPM_Schedule > 0)
                    PK_EPM_Schedule = objEPM_Schedule.Update();
                else
                    PK_EPM_Schedule = objEPM_Schedule.Insert();

                DataTable dtDateDiff = clsEPM_Schedule.GetDateDiffByPK(Convert.ToDecimal(objEPM_Schedule.PK_EPM_Schedule)).Tables[0];
                if (dtDateDiff != null && dtDateDiff.Rows.Count > 0)
                {
                    DataTable dtRecipients = clsEPM_Schedule.GetRecipientsListForMail().Tables[0];
                    if (dtRecipients != null && dtRecipients.Rows.Count > 0)
                    {
                        for (int i = 0; i < dtRecipients.Rows.Count; i++)
                        {
                            string EmailBody = "";
                            clsEPM_Identification objEPM_Identification = new clsEPM_Identification(PK_EPM_Identification);
                            string EmailTo = dtRecipients.Rows[i]["Email"].ToString();
                            string EmailSubject = "eRIMS2 Project Management Schedule Alert - Environmental Project Number " + objEPM_Identification.Project_Number + "";
                            if (dtDateDiff.Rows[0]["Start_Date_Diff"].ToString() != "" && Convert.ToInt32(dtDateDiff.Rows[0]["Start_Date_Diff"].ToString()) > 30)
                            {
                                EmailBody = "This e-mail is to provide an alert that the subject referenced project number's start date has exceeded the original estimate by more than 30 days.";
                                clsGeneral.SendMailMessage(AppConfig.MailFrom, EmailTo, string.Empty, "", EmailSubject, EmailBody.Trim().Replace("\r\n", "<br/>"), true, new string[] { });
                            }
                            if (dtDateDiff.Rows[0]["Completion_Date_Diff"].ToString() != "" && Convert.ToInt32(dtDateDiff.Rows[0]["Completion_Date_Diff"].ToString()) > 30)
                            {
                                EmailBody = "This e-mail is to provide an alert that the subject referenced project number's completion date has exceeded the original estimate by more than 30 days.";
                                clsGeneral.SendMailMessage(AppConfig.MailFrom, EmailTo, string.Empty, "", EmailSubject, EmailBody.Trim().Replace("\r\n", "<br/>"), true, new string[] { });
                            }
                        }
                    }
                }
                //Issue #3168
                btnNotesAdd.Visible = PK_EPM_Consultant > 0;

            }
            else
            {
                ClientScript.RegisterClientScriptBlock(Page.GetType(), DateTime.Now.ToString(), "javascript:alert('Please Enter Identification Details First');", true);
                ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(1);", true);
            }
        }
        #endregion

        #region " Action And Notes "
        if (hdnPanel.Value.ToString() == "5")
        {
            if (PK_EPM_Identification > 0)
            {
                clsEPM_Action_Notes ObjEPM_Action_Notes = new clsEPM_Action_Notes(Convert.ToInt32(PK_EPM_Identification));
                ObjEPM_Action_Notes.FK_EMP_Identification = PK_EPM_Identification;
                if (drpRequired_Activity.SelectedIndex > 0) ObjEPM_Action_Notes.FK_LU_EPM_Required_Activity = Convert.ToDecimal(drpRequired_Activity.SelectedValue);
                if (txtRequired_Activity_Description.Text != "") ObjEPM_Action_Notes.Requied_Activity_Description = txtRequired_Activity_Description.Text.Trim();
                else ObjEPM_Action_Notes.Requied_Activity_Description = null;
                if (ObjEPM_Action_Notes.Requied_Activity_Description != null)
                {
                    ObjEPM_Action_Notes.Date_Required_Activity_Initially_Entered = clsGeneral.FormatDateToStore(DateTime.Today);
                    ObjEPM_Action_Notes.Date_Required_Activity_Last_Edited = clsGeneral.FormatDateToStore(DateTime.Today);
                }
                if (txtAction.Text != "") ObjEPM_Action_Notes.Action = txtAction.Text.Trim();
                else ObjEPM_Action_Notes.Action = null;
                if (ObjEPM_Action_Notes.Action != null)
                {
                    ObjEPM_Action_Notes.Date_Action_Initially_Entered = clsGeneral.FormatDateToStore(DateTime.Today);
                    ObjEPM_Action_Notes.Date_Action_Last_Edited = clsGeneral.FormatDateToStore(DateTime.Today);
                }
                if (txtStatus.Text != "") ObjEPM_Action_Notes.Status = txtStatus.Text.Trim();
                else ObjEPM_Action_Notes.Status = null;
                if (ObjEPM_Action_Notes.Status != null)
                {
                    ObjEPM_Action_Notes.Date_Status_Initially_Entered = clsGeneral.FormatDateToStore(DateTime.Today);
                    ObjEPM_Action_Notes.Date_Status_Last_Edited = clsGeneral.FormatDateToStore(DateTime.Today);
                }
                if (txtIssues.Text != "") ObjEPM_Action_Notes.Issues = txtIssues.Text.Trim();
                else ObjEPM_Action_Notes.Issues = null;
                if (ObjEPM_Action_Notes.Issues != null)
                {
                    ObjEPM_Action_Notes.Date_Issues_Initially_Entered = clsGeneral.FormatDateToStore(DateTime.Today);
                    ObjEPM_Action_Notes.Date_Issues_Last_Edited = clsGeneral.FormatDateToStore(DateTime.Today);
                }
                if (drpOutcome.SelectedIndex > 0) ObjEPM_Action_Notes.Outcome = Convert.ToDecimal(drpOutcome.SelectedValue);
                if (txtComments.Text != "") ObjEPM_Action_Notes.Comments = txtComments.Text.Trim();
                else ObjEPM_Action_Notes.Comments = null;
                if (ObjEPM_Action_Notes.Comments != null)
                {
                    ObjEPM_Action_Notes.Date_Comments_Initially_Entered = clsGeneral.FormatDateToStore(DateTime.Today);
                    ObjEPM_Action_Notes.Date_Comments_Last_Edited = clsGeneral.FormatDateToStore(DateTime.Today);
                }
                ObjEPM_Action_Notes.Updated_By = clsSession.UserName;
                ObjEPM_Action_Notes.Update_Date = clsGeneral.FormatDateToStore(DateTime.Now);

                if (ObjEPM_Action_Notes.PK_EPM_Action_Notes > 0)
                {
                    PK_EPM_Action_Notes = ObjEPM_Action_Notes.Update();
                }
                else
                    PK_EPM_Action_Notes = ObjEPM_Action_Notes.Insert();

                //Issue #3168
                lnkActionNotes.Visible = PK_EPM_Action_Notes > 0;                
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(Page.GetType(), DateTime.Now.ToString(), "javascript:alert('Please Enter Identification Details First');", true);
                ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(1);", true);
            }
        }
        #endregion
    }

    /// <summary>
    /// bind project Cost Grid
    /// </summary>
    private void bindProjectCostGrid()
    {
        DataTable dtProjectCost = clsEPM_Project_Cost.SelectByFK(PK_EPM_Identification).Tables[0];
        if (StrOperation.ToLower() != "view")
        {
            if (chkIncludeCompProject.Checked == true)
            {
                gvProjectCost.Columns[0].Visible = true;
                gvProjectCost.Columns[1].Visible = true;
            }
            else
            {
                gvProjectCost.Columns[0].Visible = false;
                gvProjectCost.Columns[1].Visible = false;
            }

            gvProjectCost.DataSource = dtProjectCost;
            gvProjectCost.DataBind();
        }
        else
        {
            if (chkIncludeCompProjectView.Checked == true)
            {
                gvProjectCostView.Columns[0].Visible = true;
                gvProjectCostView.Columns[1].Visible = true;
            }
            else
            {
                gvProjectCostView.Columns[0].Visible = false;
                gvProjectCostView.Columns[1].Visible = false;
            }

            gvProjectCostView.DataSource = dtProjectCost;
            gvProjectCostView.DataBind();
        }
    }

    /// <summary>
    /// bind Project Mileston Grid
    /// </summary>
    private void bindProjectMilestoneGrid()
    {
        DataTable dtProjectMilestone = clsEPM_Milestone.SelectByFK(PK_EPM_Identification).Tables[0];
        if (StrOperation.ToLower() != "view")
        {
            gvProjectMilestone.DataSource = dtProjectMilestone;
            gvProjectMilestone.DataBind();
        }
        else
        {
            gvProjectMilestoneView.DataSource = dtProjectMilestone;
            gvProjectMilestoneView.DataBind();
        }
    }

    /// <summary>
    /// Bind details when strOperation is edit
    /// </summary>
    private void BindDetatisForEdit()
    {
        btnReturnto_View_Mode.Visible = true;

        #region " Identification "
        clsEPM_Identification objEPM_Identification = new clsEPM_Identification(PK_EPM_Identification);
        objEPM_Identification.PK_EPM_Identification = PK_EPM_Identification;
        objEPM_Identification.FK_LU_Location_Id = LocationID;
        if (objEPM_Identification.FK_EPM_Identification != null) drpCompanion_to_Project.SelectedValue = objEPM_Identification.FK_EPM_Identification.ToString();
        if (objEPM_Identification.Project_Number != null) txtProject_Number.Text = objEPM_Identification.Project_Number;
        if (objEPM_Identification.FK_LU_EPM_Project_Type != null) drpProject_Type.SelectedValue = objEPM_Identification.FK_LU_EPM_Project_Type.ToString();
        if (objEPM_Identification.Project_Description != null) txtProject_Description.Text = objEPM_Identification.Project_Description;
        if (objEPM_Identification.FK_LU_EPM_Requesting_Entity != null) drpRequesting_Entity.SelectedValue = objEPM_Identification.FK_LU_EPM_Requesting_Entity.ToString();
        if (objEPM_Identification.Other_Requesting_Entity != null) txtOther_Requesting_Entity_Desc.Text = objEPM_Identification.Other_Requesting_Entity;
        else txtOther_Requesting_Entity_Desc.Text = "";
        if (objEPM_Identification.Other_Target_Area != null) txtOther_Target_Area_Desc.Text = objEPM_Identification.Other_Target_Area;
        else txtOther_Target_Area_Desc.Text = "";
        if (objEPM_Identification.Other_PurposeOfProject != null) txtPurpose_of_Project_Other_Description.Text = objEPM_Identification.Other_PurposeOfProject;
        else txtPurpose_of_Project_Other_Description.Text = "";
        if (objEPM_Identification.Person_Requesting_Work != null) txtPerson_Requesting_Work.Text = objEPM_Identification.Person_Requesting_Work;
        if (objEPM_Identification.Title_of_Person_Requesting_Work != null) txtTitle_of_Person_RequestingWork.Text = objEPM_Identification.Title_of_Person_Requesting_Work;

        if (objEPM_Identification.Site_Contact_Name != null) txtName.Text = objEPM_Identification.Site_Contact_Name;
        if (objEPM_Identification.Site_Contact_Telephone != null) txtTelephone.Text = objEPM_Identification.Site_Contact_Telephone;
        if (objEPM_Identification.Site_Contact_Email != null) txtEmail.Text = objEPM_Identification.Site_Contact_Email;

        lblHeaderProject_Number.Text = objEPM_Identification.Project_Number;
        if (objEPM_Identification.FK_LU_EPM_Project_Type != null)
            lblHeaderProject_Type.Text = new LU_EPM_Project_Type((decimal)objEPM_Identification.FK_LU_EPM_Project_Type).Fld_Desc;
        tdProjectNum.Style["display"] = "block"; tdHeaderPro_Num.Style["display"] = "block"; tdHeaderProType.Style["display"] = "block"; tdProjectType.Style["display"] = "block";

        DataTable dtEPM_building = clsEPM_Identification_Building.SelectByFK(PK_EPM_Identification).Tables[0];
        if (dtEPM_building != null && dtEPM_building.Rows.Count > 0)
        {
            for (int i = 0; i < dtEPM_building.Rows.Count; i++)
            {
                ListItem lst;
                lst = chkBuilding.Items.FindByValue(dtEPM_building.Rows[i]["FK_Building"].ToString());
                if (lst != null)
                    lst.Selected = true;
            }
        }

        DataTable dtEPM_Equipment = clsEPM_Identification_Equipment.SelectByFK(PK_EPM_Identification).Tables[0];
        if (dtEPM_Equipment != null && dtEPM_Equipment.Rows.Count > 0)
        {
            for (int i = 0; i < dtEPM_Equipment.Rows.Count; i++)
            {
                ListItem lst;
                lst = lstEquipment.Items.FindByValue(dtEPM_Equipment.Rows[i]["FK_LU_Eqipment_Type_Pollution"].ToString());
                if (lst != null)
                    lst.Selected = true;
            }

        }

        DataTable dtEPM_TargetArea = clsEPM_Identification_TargetArea.SelectByFK(PK_EPM_Identification).Tables[0];
        if (dtEPM_TargetArea != null && dtEPM_TargetArea.Rows.Count > 0)
        {
            for (int i = 0; i < dtEPM_TargetArea.Rows.Count; i++)
            {
                ListItem lst;
                lst = lstTargetArea.Items.FindByValue(dtEPM_TargetArea.Rows[i]["FK_LU_EPM_TargetArea"].ToString());
                if (lst != null)
                    lst.Selected = true;
            }
        }

        DataTable dtPurpoe_Of_project = clsEPM_Identification_PurposeOfProject.SelectByFK(PK_EPM_Identification).Tables[0];
        if (dtPurpoe_Of_project != null && dtPurpoe_Of_project.Rows.Count > 0)
        {
            for (int i = 0; i < dtPurpoe_Of_project.Rows.Count; i++)
            {
                ListItem lst;
                lst = lstPurpose_Of_Project.Items.FindByValue(dtPurpoe_Of_project.Rows[i]["FK_LU_EPM_PurposeOfProject"].ToString());
                if (lst != null)
                    lst.Selected = true;
            }
        }

        DataTable dtExistingDocs = clsEPM_Identification_ExistingDocuments.SelectByFK(PK_EPM_Identification).Tables[0];
        if (dtExistingDocs != null && dtExistingDocs.Rows.Count > 0)
        {
            for (int i = 0; i < dtExistingDocs.Rows.Count; i++)
            {
                ListItem lst;
                lst = lstExistingDocuments.Items.FindByValue(dtExistingDocs.Rows[i]["FK_LU_EPM_ExistingDocuments"].ToString());
                if (lst != null)
                    lst.Selected = true;
            }
        }

        #endregion

        #region " Consultant "
        clsEPM_Consultant ObjEPM_Consultant = new clsEPM_Consultant(Convert.ToInt32(PK_EPM_Identification));
        if (ObjEPM_Consultant.PK_EPM_Consultant != null)
            PK_EPM_Consultant = ObjEPM_Consultant.PK_EPM_Consultant.Value;
        ObjEPM_Consultant.FK_EPM_Identification = PK_EPM_Identification;
        if (ObjEPM_Consultant.HH_Or_Other != null && ObjEPM_Consultant.HH_Or_Other == true)
        { rdoHartNHickMan.Checked = true; }
        else { rdoOther.Checked = true; }
        if (ObjEPM_Consultant.Consultant_Company != null) txtConsultant_Company.Text = ObjEPM_Consultant.Consultant_Company;
        if (ObjEPM_Consultant.Consultant_Address_1 != null) txtConsultant_Address1.Text = ObjEPM_Consultant.Consultant_Address_1;
        if (ObjEPM_Consultant.Consultant_Address_2 != null) txtConsultant_Address2.Text = ObjEPM_Consultant.Consultant_Address_2;
        if (ObjEPM_Consultant.Consultant_City != null) txtConsultant_City.Text = ObjEPM_Consultant.Consultant_City;
        if (ObjEPM_Consultant.FK_State != null) drpConsultant_State.SelectedValue = ObjEPM_Consultant.FK_State.ToString();
        if (ObjEPM_Consultant.Consultant_Zip_Code != null) txtConsultant_Zip_Code.Text = ObjEPM_Consultant.Consultant_Zip_Code;
        if (ObjEPM_Consultant.Consultant_Contact_Name != null) txtConsultant_Contact_Name.Text = ObjEPM_Consultant.Consultant_Contact_Name;
        if (ObjEPM_Consultant.Consutlant_Telephone != null) txtConsultant_Contact_Telephone.Text = ObjEPM_Consultant.Consutlant_Telephone;
        if (ObjEPM_Consultant.Constulant_Email != null) txtConsultant_Contact_EMail.Text = ObjEPM_Consultant.Constulant_Email;
        if (rdoHartNHickMan.Checked)
        {
            txtConsultant_Company.Enabled = false;
            txtConsultant_Address1.Enabled = false;
            txtConsultant_City.Enabled = false;
            txtConsultant_Zip_Code.Enabled = false;
            drpConsultant_State.Enabled = false;
        }
        if (rdoOther.Checked)
        {
            txtConsultant_Company.Enabled = true;
            txtConsultant_Address1.Enabled = true;
            txtConsultant_City.Enabled = true;
            txtConsultant_Zip_Code.Enabled = true;
            drpConsultant_State.Enabled = true;
        }

        #endregion

        #region " Schedule Information "
        clsEPM_Schedule objEPM_Schedule = new clsEPM_Schedule(Convert.ToInt32(PK_EPM_Identification));
        if (objEPM_Schedule.PK_EPM_Schedule != null)
            PK_EPM_Schedule = objEPM_Schedule.PK_EPM_Schedule.Value;
        if (objEPM_Schedule.Date_To_Consultant != null) txtDate_to_Consultant.Text = objEPM_Schedule.Date_To_Consultant.ToString();
        if (objEPM_Schedule.RM_Notification_Date != null) txtRM_Notification_Date.Text = objEPM_Schedule.RM_Notification_Date.ToString();
        if (objEPM_Schedule.Estimated_Project_Start_Date != null) txtEstimated_Project_StartDate.Text = objEPM_Schedule.Estimated_Project_Start_Date.ToString();
        if (objEPM_Schedule.Actual_Project_Start_Date != null) txtActual_Project_StartDate.Text = objEPM_Schedule.Actual_Project_Start_Date.ToString();
        if (objEPM_Schedule.Estimated_Project_Completion_Date != null) txtEstimated_Project_CompletionDate.Text = objEPM_Schedule.Estimated_Project_Completion_Date.ToString();
        if (objEPM_Schedule.Actual_Project_Completion_Date != null) txtActual_Project_CompletionDate.Text = objEPM_Schedule.Actual_Project_Completion_Date.ToString();
        #endregion

        #region " Action And Notes "
        clsEPM_Action_Notes ObjEPM_Action_Notes = new clsEPM_Action_Notes(Convert.ToInt32(PK_EPM_Identification));
        if (ObjEPM_Action_Notes.PK_EPM_Action_Notes != null)
            PK_EPM_Action_Notes = ObjEPM_Action_Notes.PK_EPM_Action_Notes.Value;
        if (ObjEPM_Action_Notes.FK_LU_EPM_Required_Activity != null) drpRequired_Activity.SelectedValue = ObjEPM_Action_Notes.FK_LU_EPM_Required_Activity.ToString();
        if (ObjEPM_Action_Notes.Requied_Activity_Description != null) txtRequired_Activity_Description.Text = ObjEPM_Action_Notes.Requied_Activity_Description;

        if (ObjEPM_Action_Notes.Requied_Activity_Description != null)
        {
            if (ObjEPM_Action_Notes.Date_Required_Activity_Initially_Entered != null) txtDate_Required_Activity_InitiallyEntered.Text = clsGeneral.FormatDBNullDateToDisplay(ObjEPM_Action_Notes.Date_Required_Activity_Initially_Entered.ToString());
            if (ObjEPM_Action_Notes.Date_Required_Activity_Last_Edited != null) txtDateRequired_Activity_LastEdited.Text = clsGeneral.FormatDBNullDateToDisplay(ObjEPM_Action_Notes.Date_Required_Activity_Last_Edited.ToString());
        }
        if (ObjEPM_Action_Notes.Action != null) txtAction.Text = ObjEPM_Action_Notes.Action;
        if (ObjEPM_Action_Notes.Action != null)
        {
            if (ObjEPM_Action_Notes.Date_Action_Initially_Entered != null) txtDate_Action_InitiallyEntered.Text = clsGeneral.FormatDBNullDateToDisplay(ObjEPM_Action_Notes.Date_Action_Initially_Entered.ToString());
            if (ObjEPM_Action_Notes.Date_Action_Last_Edited != null) txtDate_Action_LastEdited.Text = clsGeneral.FormatDBNullDateToDisplay(ObjEPM_Action_Notes.Date_Action_Last_Edited.ToString());
        }
        if (ObjEPM_Action_Notes.Status != null) txtStatus.Text = ObjEPM_Action_Notes.Status;
        if (ObjEPM_Action_Notes.Status != null)
        {
            if (ObjEPM_Action_Notes.Date_Status_Initially_Entered != null) txtDate_Status_InitiallyEntered.Text = clsGeneral.FormatDBNullDateToDisplay(ObjEPM_Action_Notes.Date_Status_Initially_Entered.ToString());
            if (ObjEPM_Action_Notes.Date_Status_Last_Edited != null) txtDate_Status_LastEdited.Text = clsGeneral.FormatDBNullDateToDisplay(ObjEPM_Action_Notes.Date_Status_Last_Edited.ToString());
        }
        if (ObjEPM_Action_Notes.Issues != null) txtIssues.Text = ObjEPM_Action_Notes.Issues;
        if (ObjEPM_Action_Notes.Issues != null)
        {
            if (ObjEPM_Action_Notes.Date_Issues_Initially_Entered != null) txtDate_Issues_InitiallyEntered.Text = clsGeneral.FormatDBNullDateToDisplay(ObjEPM_Action_Notes.Date_Issues_Initially_Entered.ToString());
            if (ObjEPM_Action_Notes.Date_Issues_Last_Edited != null) txtDate_Issues_LastEdited.Text = clsGeneral.FormatDBNullDateToDisplay(ObjEPM_Action_Notes.Date_Issues_Last_Edited.ToString());
        }
        if (ObjEPM_Action_Notes.Outcome != null) drpOutcome.SelectedValue = ObjEPM_Action_Notes.Outcome.ToString();
        if (ObjEPM_Action_Notes.Comments != null) txtComments.Text = ObjEPM_Action_Notes.Comments;
        if (ObjEPM_Action_Notes.Comments != null)
        {
            if (ObjEPM_Action_Notes.Date_Comments_Initially_Entered != null) txtDate_Comments_InitiallyEntered.Text = clsGeneral.FormatDBNullDateToDisplay(ObjEPM_Action_Notes.Date_Comments_Initially_Entered.ToString());
            if (ObjEPM_Action_Notes.Date_Comments_Last_Edited != null) txtDate_Comments_LastEdited.Text = clsGeneral.FormatDBNullDateToDisplay(ObjEPM_Action_Notes.Date_Comments_Last_Edited.ToString());
        }

        //3168


        #endregion
    }

    /// <summary>
    /// Bind details when strOperation is view
    /// </summary>
    private void BindDetailForView()
    {
        btnEdit.Visible = true;
        btnSave.Visible = false;


        #region " Identification "
        clsEPM_Identification objEPM_Identification = new clsEPM_Identification(PK_EPM_Identification);
        objEPM_Identification.PK_EPM_Identification = PK_EPM_Identification;
        objEPM_Identification.FK_LU_Location_Id = LocationID;
        if (objEPM_Identification.FK_EPM_Identification != null)
        {
            DataTable dtCompanion_to_Project = clsEPM_Identification.SelectByFK(Convert.ToDecimal(objEPM_Identification.FK_EPM_Identification)).Tables[0];
            if (dtCompanion_to_Project != null && dtCompanion_to_Project.Rows.Count > 0)
            {
                lblCompanion_to_Project.Text = dtCompanion_to_Project.Rows[0]["Comp_Project"].ToString();
            }
        }
        if (objEPM_Identification.Project_Number != null) lblProject_Number.Text = objEPM_Identification.Project_Number;
        if (objEPM_Identification.FK_LU_EPM_Project_Type != null) lblProject_Type.Text = new LU_EPM_Project_Type((decimal)objEPM_Identification.FK_LU_EPM_Project_Type).Fld_Desc;
        if (objEPM_Identification.Project_Description != null) lblProject_Description.Text = objEPM_Identification.Project_Description;
        if (objEPM_Identification.FK_LU_EPM_Requesting_Entity != null) lblRequesting_Entity.Text = new LU_EPM_Requesting_Agency((decimal)objEPM_Identification.FK_LU_EPM_Requesting_Entity).Fld_Desc;
        if (objEPM_Identification.Other_Requesting_Entity != null) lblOther_Requesting_Entity_Desc.Text = objEPM_Identification.Other_Requesting_Entity;
        if (objEPM_Identification.Other_Target_Area != null) lblOther_Target_Area_Desc.Text = objEPM_Identification.Other_Target_Area;
        if (objEPM_Identification.Other_PurposeOfProject != null) lblPurpose_of_Project_Other_Description.Text = objEPM_Identification.Other_PurposeOfProject;
        if (objEPM_Identification.Person_Requesting_Work != null) lblPerson_Requesting_Work.Text = objEPM_Identification.Person_Requesting_Work;
        if (objEPM_Identification.Title_of_Person_Requesting_Work != null) lblTitle_of_Person_RequestingWork.Text = objEPM_Identification.Title_of_Person_Requesting_Work;

        if (objEPM_Identification.Site_Contact_Telephone != null) lblTelephone.Text = objEPM_Identification.Site_Contact_Telephone;
        if (objEPM_Identification.Site_Contact_Name != null) lblName.Text = objEPM_Identification.Site_Contact_Name;
        if (objEPM_Identification.Site_Contact_Email != null) lblEmail.Text = objEPM_Identification.Site_Contact_Email;

        lblHeaderProject_Number.Text = objEPM_Identification.Project_Number;
        if (objEPM_Identification.FK_LU_EPM_Project_Type != null)  lblHeaderProject_Type.Text = new LU_EPM_Project_Type((decimal)objEPM_Identification.FK_LU_EPM_Project_Type).Fld_Desc;
        tdProjectNum.Style["display"] = "block"; tdHeaderPro_Num.Style["display"] = "block"; tdHeaderProType.Style["display"] = "block"; tdProjectType.Style["display"] = "block";

        DataTable dtEPM_buildingView = clsEPM_Identification_Building.SelectByFK(PK_EPM_Identification).Tables[0];
        if (dtEPM_buildingView != null && dtEPM_buildingView.Rows.Count > 0)
        {
            for (int i = 0; i < dtEPM_buildingView.Rows.Count; i++)
            {
                ListItem lst;
                lst = chkBuildingView.Items.FindByValue(dtEPM_buildingView.Rows[i]["FK_Building"].ToString());
                if (lst != null)
                    lst.Selected = true;
            }
        }

        DataTable dtEPM_EquipmentView = clsEPM_Identification_Equipment.SelectByFK(PK_EPM_Identification).Tables[0];
        if (dtEPM_EquipmentView != null && dtEPM_EquipmentView.Rows.Count > 0)
        {
            for (int i = 0; i < dtEPM_EquipmentView.Rows.Count; i++)
            {
                ListItem lst;
                lst = lstEquipmentView.Items.FindByValue(dtEPM_EquipmentView.Rows[i]["FK_LU_Eqipment_Type_Pollution"].ToString());
                if (lst != null)
                    lst.Selected = true;
            }
        }

        DataTable dtEPM_TargetAreaView = clsEPM_Identification_TargetArea.SelectByFK(PK_EPM_Identification).Tables[0];
        if (dtEPM_TargetAreaView != null && dtEPM_TargetAreaView.Rows.Count > 0)
        {
            for (int i = 0; i < dtEPM_TargetAreaView.Rows.Count; i++)
            {
                ListItem lst;
                lst = lstTargetAreaView.Items.FindByValue(dtEPM_TargetAreaView.Rows[i]["FK_LU_EPM_TargetArea"].ToString());
                if (lst != null)
                    lst.Selected = true;
            }
        }

        DataTable dtPurpoe_Of_projectView = clsEPM_Identification_PurposeOfProject.SelectByFK(PK_EPM_Identification).Tables[0];
        if (dtPurpoe_Of_projectView != null && dtPurpoe_Of_projectView.Rows.Count > 0)
        {
            for (int i = 0; i < dtPurpoe_Of_projectView.Rows.Count; i++)
            {
                ListItem lst;
                lst = lstPurpose_Of_ProjectView.Items.FindByValue(dtPurpoe_Of_projectView.Rows[i]["FK_LU_EPM_PurposeOfProject"].ToString());
                if (lst != null)
                    lst.Selected = true;
            }
        }

        DataTable dtExistingDocsView = clsEPM_Identification_ExistingDocuments.SelectByFK(PK_EPM_Identification).Tables[0];
        if (dtExistingDocsView != null && dtExistingDocsView.Rows.Count > 0)
        {
            for (int i = 0; i < dtExistingDocsView.Rows.Count; i++)
            {
                ListItem lst;
                lst = lstExistingDocumentsView.Items.FindByValue(dtExistingDocsView.Rows[i]["FK_LU_EPM_ExistingDocuments"].ToString());
                if (lst != null)
                    lst.Selected = true;
            }
        }
        #endregion

        #region " Consultant "
        clsEPM_Consultant ObjEPM_Consultant = new clsEPM_Consultant(Convert.ToInt32(PK_EPM_Identification));
        if (ObjEPM_Consultant.PK_EPM_Consultant != null)
            PK_EPM_Consultant = ObjEPM_Consultant.PK_EPM_Consultant.Value;
        if (ObjEPM_Consultant.HH_Or_Other != null) lblHart_N_Hickman.Text = ObjEPM_Consultant.HH_Or_Other == true ? "Yes" : "No";
        if (ObjEPM_Consultant.HH_Or_Other != null && ObjEPM_Consultant.HH_Or_Other == true)
        {
            lblHart_N_Hickman.Text = "Yes";
            lblOther_Consultant.Text = "No";
        }
        else
        {
            lblHart_N_Hickman.Text = "No";
            lblOther_Consultant.Text = "Yes";
        }

        if (ObjEPM_Consultant.Consultant_Company != null) lblConsultant_Company.Text = ObjEPM_Consultant.Consultant_Company;
        if (ObjEPM_Consultant.Consultant_Address_1 != null) lblConsultant_Address1.Text = ObjEPM_Consultant.Consultant_Address_1;
        if (ObjEPM_Consultant.Consultant_Address_2 != null) lblConsultant_Address2.Text = ObjEPM_Consultant.Consultant_Address_2;
        if (ObjEPM_Consultant.Consultant_City != null) lblConsultant_City.Text = ObjEPM_Consultant.Consultant_City;
        if (ObjEPM_Consultant.FK_State != null) lblConsultant_State.Text = new State((decimal)ObjEPM_Consultant.FK_State).FLD_state;
        if (ObjEPM_Consultant.Consultant_Zip_Code != null) lblConsultant_Zip_Code.Text = ObjEPM_Consultant.Consultant_Zip_Code;
        if (ObjEPM_Consultant.Consultant_Contact_Name != null) lblConsultant_Contact_Name.Text = ObjEPM_Consultant.Consultant_Contact_Name;
        if (ObjEPM_Consultant.Consutlant_Telephone != null) lblConsultant_Contact_Telephone.Text = ObjEPM_Consultant.Consutlant_Telephone;
        if (ObjEPM_Consultant.Constulant_Email != null) lblConsultant_Contact_EMail.Text = ObjEPM_Consultant.Constulant_Email;

        #endregion

        #region " Schedule Information "
        clsEPM_Schedule objEPM_Schedule = new clsEPM_Schedule(Convert.ToInt32(PK_EPM_Identification));
        if (objEPM_Schedule.PK_EPM_Schedule != null)
            PK_EPM_Schedule = objEPM_Schedule.PK_EPM_Schedule.Value;
        if (objEPM_Schedule.Date_To_Consultant != null) lblDate_to_Consultant.Text = clsGeneral.FormatDBNullDateToDisplay(objEPM_Schedule.Date_To_Consultant.ToString());
        if (objEPM_Schedule.RM_Notification_Date != null) lblRM_Notification_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objEPM_Schedule.RM_Notification_Date.ToString());
        if (objEPM_Schedule.Estimated_Project_Start_Date != null) lblEstimated_Project_StartDate.Text = clsGeneral.FormatDBNullDateToDisplay(objEPM_Schedule.Estimated_Project_Start_Date.ToString());
        if (objEPM_Schedule.Actual_Project_Start_Date != null) lblActual_Project_StartDate.Text = clsGeneral.FormatDBNullDateToDisplay(objEPM_Schedule.Actual_Project_Start_Date.ToString());
        if (objEPM_Schedule.Estimated_Project_Completion_Date != null) lblEstimated_Project_CompletionDate.Text = clsGeneral.FormatDBNullDateToDisplay(objEPM_Schedule.Estimated_Project_Completion_Date.ToString());
        if (objEPM_Schedule.Actual_Project_Completion_Date != null) lblActual_Project_CompletionDate.Text = clsGeneral.FormatDBNullDateToDisplay(objEPM_Schedule.Actual_Project_Completion_Date.ToString());
        #endregion

        #region " Action And Notes "
        clsEPM_Action_Notes ObjEPM_Action_Notes = new clsEPM_Action_Notes(Convert.ToInt32(PK_EPM_Identification));
        if (ObjEPM_Action_Notes.PK_EPM_Action_Notes != null)
            PK_EPM_Action_Notes = ObjEPM_Action_Notes.PK_EPM_Action_Notes.Value;
        if (ObjEPM_Action_Notes.FK_LU_EPM_Required_Activity != null) lblRequired_Activity.Text = new LU_EPM_Required_Activity((decimal)ObjEPM_Action_Notes.FK_LU_EPM_Required_Activity).Fld_Desc;
        if (ObjEPM_Action_Notes.Requied_Activity_Description != null) lblRequired_Activity_Description.Text = ObjEPM_Action_Notes.Requied_Activity_Description;
        if (ObjEPM_Action_Notes.Requied_Activity_Description != null)
        {
            if (ObjEPM_Action_Notes.Date_Required_Activity_Initially_Entered != null) lblDate_Required_Activity_InitiallyEntered.Text = clsGeneral.FormatDBNullDateToDisplay(ObjEPM_Action_Notes.Date_Required_Activity_Initially_Entered.ToString());
            if (ObjEPM_Action_Notes.Date_Required_Activity_Last_Edited != null) lblDateRequired_Activity_LastEdited.Text = clsGeneral.FormatDBNullDateToDisplay(ObjEPM_Action_Notes.Date_Required_Activity_Last_Edited.ToString());
        }
        if (ObjEPM_Action_Notes.Action != null) lblAction.Text = ObjEPM_Action_Notes.Action;
        if (ObjEPM_Action_Notes.Action != null)
        {
            if (ObjEPM_Action_Notes.Date_Action_Initially_Entered != null) lblDate_Action_InitiallyEntered.Text = clsGeneral.FormatDBNullDateToDisplay(ObjEPM_Action_Notes.Date_Action_Initially_Entered.ToString());
            if (ObjEPM_Action_Notes.Date_Action_Last_Edited != null) lblDate_Action_LastEdited.Text = clsGeneral.FormatDBNullDateToDisplay(ObjEPM_Action_Notes.Date_Action_Last_Edited.ToString());
        }
        if (ObjEPM_Action_Notes.Status != null) lblStatus.Text = ObjEPM_Action_Notes.Status;
        if (ObjEPM_Action_Notes.Status != null)
        {
            if (ObjEPM_Action_Notes.Date_Status_Initially_Entered != null) lblDate_Status_InitiallyEntered.Text = clsGeneral.FormatDBNullDateToDisplay(ObjEPM_Action_Notes.Date_Status_Initially_Entered.ToString());
            if (ObjEPM_Action_Notes.Date_Status_Last_Edited != null) lblDate_Status_LastEdited.Text = clsGeneral.FormatDBNullDateToDisplay(ObjEPM_Action_Notes.Date_Status_Last_Edited.ToString());
        }
        if (ObjEPM_Action_Notes.Issues != null) lblIssues.Text = ObjEPM_Action_Notes.Issues;
        if (ObjEPM_Action_Notes.Issues != null)
        {
            if (ObjEPM_Action_Notes.Date_Issues_Initially_Entered != null) lblDate_Issues_InitiallyEntered.Text = clsGeneral.FormatDBNullDateToDisplay(ObjEPM_Action_Notes.Date_Issues_Initially_Entered.ToString());
            if (ObjEPM_Action_Notes.Date_Issues_Last_Edited != null) lblDate_Issues_LastEdited.Text = clsGeneral.FormatDBNullDateToDisplay(ObjEPM_Action_Notes.Date_Issues_Last_Edited.ToString());
        }
        if (ObjEPM_Action_Notes.Outcome != null) lblOutcome.Text = new LU_EPM_Outcome((decimal)ObjEPM_Action_Notes.Outcome).Fld_Desc;
        if (ObjEPM_Action_Notes.Comments != null) lblComments.Text = ObjEPM_Action_Notes.Comments;
        if (ObjEPM_Action_Notes.Comments != null)
        {
            if (ObjEPM_Action_Notes.Date_Comments_Initially_Entered != null) lblDate_Comments_InitiallyEntered.Text = clsGeneral.FormatDBNullDateToDisplay(ObjEPM_Action_Notes.Date_Comments_Initially_Entered.ToString());
            if (ObjEPM_Action_Notes.Date_Comments_Last_Edited != null) lblDate_Comments_LastEdited.Text = clsGeneral.FormatDBNullDateToDisplay(ObjEPM_Action_Notes.Date_Comments_Last_Edited.ToString());
        }
        #endregion
    }

    /// <summary>
    /// Binds Header Info
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
    }

    /// <summary>
    /// Enable Disable control as per condition
    /// </summary>
    private void EnableDisableControls()
    {
        if (drpRequesting_Entity.SelectedItem.Text == "Other - Describe")
        {
            txtOther_Requesting_Entity_Desc.Enabled = true;
        }
        else
        {
            txtOther_Requesting_Entity_Desc.Enabled = false;
        }
        for (int i = 0; i < lstTargetArea.Items.Count; i++)
        {
            ListItem lst;
            lst = lstTargetArea.Items.FindByText("Other – Describe");
            if (lst != null && lst.Selected)
                txtOther_Target_Area_Desc.Enabled = true;
            else
                txtOther_Target_Area_Desc.Enabled = false;
        }
        for (int i = 0; i < lstPurpose_Of_Project.Items.Count; i++)
        {
            ListItem lst;
            lst = lstPurpose_Of_Project.Items.FindByText("Other");
            if (lst != null && lst.Selected)
                txtPurpose_of_Project_Other_Description.Enabled = true;
            else
                txtPurpose_of_Project_Other_Description.Enabled = false;
        }
        if (drpRequired_Activity.SelectedItem.Text == "Remediation - Describe")
        {
            txtRequired_Activity_Description.Enabled = true;
        }
        else
        {
            txtRequired_Activity_Description.Enabled = false;
        }
    }

    //Added due TO Issue #3168

    private void BindInvoiceGrid()
    {
        if (PK_EPM_Identification > 0)
        {
            clsEPM_Project_Cost_Invoice objEPM_Project_Cost_Invoice = new clsEPM_Project_Cost_Invoice();
            DataSet dsInvoice = objEPM_Project_Cost_Invoice.SelectByFK(PK_EPM_Identification);
            DataTable dtInvoice = dsInvoice.Tables[0];
            if (dtInvoice.Rows.Count == 0)
            {
                gvInvoice.DataBind();
            }

            gvInvoice.Columns[4].Visible = (StrOperation == "view") ? false : true;
            lnkAddInvoice.Visible = (StrOperation == "view") ? false : true;
            gvInvoice.DataSource = dtInvoice;
            gvInvoice.DataBind();
        }
        else
        {
            gvInvoice.DataBind();
            lnkAddInvoice.Visible = false;
        }

    }
    private void BindConsultantNotes()
    {
        clsEPM_Consultant ObjEPM_Consultant = new clsEPM_Consultant(Convert.ToInt32(PK_EPM_Identification));
        PK_EPM_Consultant = Convert.ToDecimal(ObjEPM_Consultant.PK_EPM_Consultant);

        if (PK_EPM_Consultant == 0)
        {
            btnNotesAdd.Visible = false;
            btnView.Visible = false;
            btnPrint.Visible = false;
        }
        else
        {
            btnNotesAdd.Visible = (StrOperation == "view") ? false : true;
        }
        CurrentPage = ctrlPageSonicNotes.CurrentPage;
        PageSize = ctrlPageSonicNotes.PageSize;
        DataSet dsNotes = clsEPM_Consultant_Notes.SelectByFK_Table(PK_EPM_Consultant, CurrentPage, PageSize);
        DataTable dtNotes = dsNotes.Tables[0];
        if (dtNotes.Rows.Count == 0)
        {
            gvNotes.DataBind();
            btnView.Visible = false;
            btnPrint.Visible = false;
        }
        ctrlPageSonicNotes.TotalRecords = (dsNotes.Tables.Count >= 2) ? Convert.ToInt32(dsNotes.Tables[1].Rows[0][0]) : 0;
        ctrlPageSonicNotes.CurrentPage = (dsNotes.Tables.Count >= 2) ? Convert.ToInt32(dsNotes.Tables[1].Rows[0][2]) : 0;
        ctrlPageSonicNotes.RecordsToBeDisplayed = dsNotes.Tables[0].Rows.Count;
        ctrlPageSonicNotes.SetPageNumbers();

        gvNotes.Columns[3].Visible = (StrOperation == "view") ? false : true;
        gvNotes.DataSource = dtNotes;
        gvNotes.DataBind();
        btnView.Visible = dtNotes.Rows.Count > 0;
        btnPrint.Visible = dtNotes.Rows.Count > 0;
    }
    private void BindEPMActionNotes()
    {
        clsEPM_Action_Notes ObjEPM_Action_Notes = new clsEPM_Action_Notes(Convert.ToInt32(PK_EPM_Identification));
        PK_EPM_Action_Notes = Convert.ToDecimal(ObjEPM_Action_Notes.PK_EPM_Action_Notes);

        CurrentPage = ctrlActionNotes.CurrentPage;
        PageSize = ctrlActionNotes.PageSize;

        DataSet dsNotes = clsEPM_Action_Notes_RM.SelectByFK_Table(PK_EPM_Action_Notes, CurrentPage, PageSize);
        DataTable dtNotes = dsNotes.Tables[0];
        if (dtNotes.Rows.Count == 0)
        {
            gvActionNotes.DataBind();
            btnActionNotesPrint.Visible = false;
            btnActionNotesView.Visible = false;
        }
        ctrlActionNotes.TotalRecords = (dsNotes.Tables.Count >= 2) ? Convert.ToInt32(dsNotes.Tables[1].Rows[0][0]) : 0;
        ctrlActionNotes.CurrentPage = (dsNotes.Tables.Count >= 2) ? Convert.ToInt32(dsNotes.Tables[1].Rows[0][2]) : 0;
        ctrlActionNotes.RecordsToBeDisplayed = dsNotes.Tables[0].Rows.Count;
        ctrlActionNotes.SetPageNumbers();

        gvActionNotes.Columns[4].Visible = (StrOperation == "view") ? false : true;
        gvActionNotes.DataSource = dtNotes;
        gvActionNotes.DataBind();

        if (PK_EPM_Action_Notes == 0)
        {
            lnkActionNotes.Visible = false;
            btnActionNotesView.Visible = false;
            btnActionNotesPrint.Visible = false;
        }
        else
        {
            lnkActionNotes.Visible = (StrOperation == "view") ? false : true;
        }

        btnActionNotesPrint.Visible = dtNotes.Rows.Count > 0;
        btnActionNotesView.Visible = dtNotes.Rows.Count > 0;
    }

    // End of Issue #3168
    #endregion

    #region " Control Events "
    /// <summary>
    /// Handles Click Event for Add a new Project cost And redirects to Project Cost page
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkAddProjectCost_Click(object sender, EventArgs e)
    {
        decimal PK_EPM_Project_Cost = 0;
        if (PK_EPM_Identification > 0)
        {
            Response.Redirect("EPM_Project_Cost.aspx?loc=" + Encryption.Encrypt(LocationID.ToString()) + "&Cid=" + Encryption.Encrypt(PK_EPM_Identification.ToString()) + "&id=" + Encryption.Encrypt("0") + "&PCI=" + Encryption.Encrypt(PK_EPM_Project_Cost.ToString()) + "&pnl=" + hdnPanel.Value + "&op=add", true);
        }
        else
        {
            ClientScript.RegisterClientScriptBlock(Page.GetType(), DateTime.Now.ToString(), "javascript:alert('Please Enter Identification Details First');", true);
            ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(1);", true);
        }
    }

    /// <summary>
    /// Handles click event for add a new project Milestone And redirects to Project Milestone page
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkProject_Milestone_Click(object sender, EventArgs e)
    {
        decimal PK_EPM_Milestone = 0;
        if (PK_EPM_Identification > 0)
        {
            Response.Redirect("EPM_Project_Milestone.aspx?loc=" + Encryption.Encrypt(LocationID.ToString()) + "&id=" + Encryption.Encrypt(PK_EPM_Identification.ToString()) + "&PMI=" + (Encryption.Encrypt(PK_EPM_Milestone.ToString())) + "&pnl=" + hdnPanel.Value + "&op=add", true);
        }
        else
        {
            ClientScript.RegisterClientScriptBlock(Page.GetType(), DateTime.Now.ToString(), "javascript:alert('Please Enter Identification Details First');", true);
            ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(1);", true);
        }
    }

    /// <summary>
    /// Handles Selected index Change of Building Checkbox List And Binds Equipment Data Accordingly
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void chkBuilding_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        hdnchkBuilding.Value = "1";
        string strBuildingIDs = "";
        for (int i = 0; i < chkBuilding.Items.Count; i++)
        {
            if (chkBuilding.Items[i].Selected == true)
            {
                strBuildingIDs = strBuildingIDs + chkBuilding.Items[i].Value + ",";
            }
        }
        strBuildingIDs = strBuildingIDs.TrimEnd(',');
        if (strBuildingIDs != "")
        {
            DataTable dtEquipment = clsEPM_Identification_Building.GetDistinctEquipments(strBuildingIDs).Tables[0];
            if (dtEquipment != null && dtEquipment.Rows.Count > 0)
            {
                lstEquipment.DataSource = dtEquipment;
                lstEquipment.DataTextField = "Fld_Desc";
                lstEquipment.DataValueField = "PK_LU_Equipment_Type_Pollution";
                lstEquipment.DataBind();
            }
        }
        else
        {
            lstEquipment.Items.Clear();
        }
        EnableDisableControls();
        ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(1);OnChangeFunction();", true);
    }

    /// <summary>
    /// Handles CheckedChanged event of Hart & Hickman radio Button and sets Data as per condition
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void rdoHartNHickMan_OnCheckedChanged(object sender, EventArgs e)
    {
        if (rdoHartNHickMan.Checked)
        {
            txtConsultant_Company.Text = "Hart & Hickman";
            txtConsultant_Address1.Text = "2933 South Tryon Street";
            txtConsultant_City.Text = "Charlotte";
            drpConsultant_State.SelectedValue = "34";
            txtConsultant_Zip_Code.Text = "28203";

            txtConsultant_Company.Enabled = false;
            txtConsultant_Address1.Enabled = false;
            txtConsultant_City.Enabled = false;
            txtConsultant_Zip_Code.Enabled = false;
            drpConsultant_State.Enabled = false;
        }
        ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(2);", true);
    }

    /// <summary>
    /// Handles CheckedChanged event of Other radio Button and sets Data as per condition
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void rdoOther_OnCheckedChanged(object sender, EventArgs e)
    {
        if (rdoOther.Checked)
        {
            txtConsultant_Company.Text = "";
            txtConsultant_Address1.Text = "";
            txtConsultant_City.Text = "";
            drpConsultant_State.SelectedIndex = 0;
            txtConsultant_Zip_Code.Text = "";


            txtConsultant_Company.Enabled = true;
            txtConsultant_Address1.Enabled = true;
            txtConsultant_City.Enabled = true;
            txtConsultant_Zip_Code.Enabled = true;
            drpConsultant_State.Enabled = true;
        }
        ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(2);", true);
    }

    /// <summary>
    /// handles Save button's click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSave_OnClick(object sender, EventArgs e)
    {
        SaveData();
        if ((StrOperation.ToLower() == "add" || StrOperation.ToLower() == "") && PK_EPM_Identification > 0)
        {
            Response.Redirect("Project_Management.aspx?loc=" + Encryption.Encrypt(LocationID.ToString()) + "&id=" + Encryption.Encrypt(PK_EPM_Identification.ToString()) + "&pnl=" + hdnPanel.Value + "&op=edit", true);
        }
        if (PK_EPM_Identification > 0)
        {
            BindDetatisForEdit();
            EnableDisableControls();
            ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(" + hdnPanel.Value + ");", true);
        }
    }

    /// <summary>
    /// handles edit button's click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnEdit_OnClick(object sender, EventArgs e)
    {
        Response.Redirect("Project_Management.aspx?loc=" + Encryption.Encrypt(LocationID.ToString()) + "&id=" + Encryption.Encrypt(PK_EPM_Identification.ToString()) + "&pnl=" + hdnPanel.Value + "&op=edit", true);
    }

    /// <summary>
    /// handles Return To View Mode button's Click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnReturnto_View_Mode_OnClick(object sender, EventArgs e)
    {
        Response.Redirect("Project_Management.aspx?loc=" + Encryption.Encrypt(LocationID.ToString()) + "&id=" + Encryption.Encrypt(PK_EPM_Identification.ToString()) + "&pnl=" + hdnPanel.Value + "&op=view", true);
    }

    /// <summary>
    /// Handles Checked Change of Include Companion Project checkbox as per strOperation
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void chkIncludeCompProject_OnCheckedChanged(object sender, EventArgs e)
    {
        if (StrOperation.ToLower() != "view")
        {
            if (chkIncludeCompProject.Checked == true)
            {
                DataTable dtGetCompanionProjectCost = clsEPM_Project_Cost.GetCompanionProjectCost(PK_EPM_Identification, LocationID).Tables[0];
                if (dtGetCompanionProjectCost != null && dtGetCompanionProjectCost.Rows.Count > 0)
                {
                    gvProjectCost.DataSource = dtGetCompanionProjectCost;
                    gvProjectCost.DataBind();
                }
                {
                    gvProjectCostView.DataBind();
                }
                gvProjectCost.Columns[0].Visible = true;
                gvProjectCost.Columns[1].Visible = true;
            }
            else
            {
                DataTable dtProjectCost = clsEPM_Project_Cost.SelectByFK(PK_EPM_Identification).Tables[0];
                if (dtProjectCost != null && dtProjectCost.Rows.Count > 0)
                {
                    gvProjectCost.DataSource = dtProjectCost;
                    gvProjectCost.DataBind();
                }
                else
                {
                    gvProjectCost.DataBind();
                }
                gvProjectCost.Columns[0].Visible = false;
                gvProjectCost.Columns[1].Visible = false;
            }
        }
        else
        {
            if (chkIncludeCompProjectView.Checked == true)
            {
                DataTable dtGetCompanionProjectCost = clsEPM_Project_Cost.GetCompanionProjectCost(PK_EPM_Identification, LocationID).Tables[0];
                if (dtGetCompanionProjectCost != null && dtGetCompanionProjectCost.Rows.Count > 0)
                {
                    gvProjectCostView.DataSource = dtGetCompanionProjectCost;
                    gvProjectCostView.DataBind();
                }
                else
                {
                    gvProjectCostView.DataBind();
                }
                gvProjectCostView.Columns[0].Visible = true;
                gvProjectCostView.Columns[1].Visible = true;
            }
            else
            {
                DataTable dtProjectCost = clsEPM_Project_Cost.SelectByFK(PK_EPM_Identification).Tables[0];
                if (dtProjectCost != null && dtProjectCost.Rows.Count > 0)
                {
                    gvProjectCostView.DataSource = dtProjectCost;
                    gvProjectCostView.DataBind();
                }
                else
                {
                    gvProjectCostView.DataBind();
                }
                gvProjectCostView.Columns[0].Visible = false;
                gvProjectCostView.Columns[1].Visible = false;
            }
        }
        ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(3);", true);
    }

    /// <summary>
    /// Handles Email Form Button's click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnEmail_From_OnClick(object sender, EventArgs e)
    {
        SaveData();
        Page.ClientScript.RegisterStartupScript(typeof(string), DateTime.Now.ToString(), "javascript:ShowEnvironmentalRequestMailPage('" + Encryption.Encrypt(PK_EPM_Identification.ToString()) + "','" + Encryption.Encrypt(LocationID.ToString()) + "');", true);
        ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(2);", true);
    }

    /// <summary>
    /// Handles View Schedule Button's click Event and Open scheduler in Edit Mode
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkViewSchedule_OnClick(object sender, EventArgs e)
    {
        if (StrOperation.ToLower() != "view")
            Response.Redirect("EPM_Scheduler.aspx?loc=" + Encryption.Encrypt(LocationID.ToString()) + "&id=" + Encryption.Encrypt(PK_EPM_Identification.ToString()) + "&pnl=" + hdnPanel.Value + "&op=edit");
        else
            Response.Redirect("EPM_Scheduler.aspx?loc=" + Encryption.Encrypt(LocationID.ToString()) + "&id=" + Encryption.Encrypt(PK_EPM_Identification.ToString()) + "&pnl=" + hdnPanel.Value + "&op=view");
    }


    //Added due to Issue #3168
    protected void btnView_Click(object sender, EventArgs e)
    {
        string strPK = "";
        foreach (GridViewRow gRow in gvNotes.Rows)
        {
            if (((CheckBox)gRow.FindControl("chkSelectSonicNotes")).Checked)
                strPK = strPK + ((HtmlInputHidden)gRow.FindControl("hdnPK")).Value + ",";
        }
        strPK = strPK.TrimEnd(',');

        Response.Redirect("..\\ClaimInfo\\ClaimNotesEPM.aspx?viewIDs=" + Encryption.Encrypt(strPK) + "&FK_Claim=" + Encryption.Encrypt(PK_EPM_Identification.ToString()) + "&tbl=" + "EPM_Identification" + "&loc=" + LocationID + "&op=" + Request.QueryString["op"].ToString());
    }
    protected void btnPrint_Click(object sender, EventArgs e)
    {
        string strPK = "";
        foreach (GridViewRow gRow in gvNotes.Rows)
        {
            if (((CheckBox)gRow.FindControl("chkSelectSonicNotes")).Checked)
                strPK = strPK + ((HtmlInputHidden)gRow.FindControl("hdnPK")).Value + ",";
        }
        strPK = strPK.TrimEnd(',');

        clsPrintClaimNotesEPM.PrintSelectedSonicNotes(strPK, (long)PK_EPM_Identification);
    }

    protected void btnActionNotesPrint_Click(object sender, EventArgs e)
    {
        string strPK = "";
        foreach (GridViewRow gRow in gvActionNotes.Rows)
        {
            if (((CheckBox)gRow.FindControl("chkSelectSonicNotes")).Checked)
                strPK = strPK + ((HtmlInputHidden)gRow.FindControl("hdnPK")).Value + ",";
        }
        strPK = strPK.TrimEnd(',');

        clsPrintClaimNotesEPMActionNotes.PrintSelectedSonicNotes(strPK, (long)PK_EPM_Identification);
    }
    protected void btnActionNotesView_Click(object sender, EventArgs e)
    {
        string strPK = "";
        foreach (GridViewRow gRow in gvActionNotes.Rows)
        {
            if (((CheckBox)gRow.FindControl("chkSelectSonicNotes")).Checked)
                strPK = strPK + ((HtmlInputHidden)gRow.FindControl("hdnPK")).Value + ",";
        }
        strPK = strPK.TrimEnd(',');

        Response.Redirect("..\\ClaimInfo\\ClaimNotesEPMActionNotesRM.aspx?viewIDs=" + Encryption.Encrypt(strPK) + "&FK_Claim=" + Encryption.Encrypt(PK_EPM_Identification.ToString()) + "&tbl=" + "EPM_Identification" + "&loc=" + LocationID + "&op=" + Request.QueryString["op"].ToString());
    }

    protected void lnkActionNotes_Click(object sender, EventArgs e)
    {
        Response.Redirect("..\\ClaimInfo\\ClaimNotesEPMActionNotesRM.aspx?loc=" + LocationID + "&FK_Claim=" + Encryption.Encrypt(PK_EPM_Identification.ToString()) + "&tbl=" + "EPM_Action_Notes_RM" + "&op=" + Request.QueryString["op"].ToString());
    }
    protected void lnkAddInvoice_Click(object sender, EventArgs e)
    {
        if (PK_EPM_Identification > 0)
        {
            Response.Redirect("..\\Exposures\\EPM_Project_Cost_Invoice.aspx?loc=" + LocationID.ToString() + "&Cid=" + Encryption.Encrypt(PK_EPM_Identification.ToString()) + "&id=" + Encryption.Encrypt("0") + "&pnl=" + hdnPanel.Value + "&op=add", true);
        }
        else
        {
            ClientScript.RegisterClientScriptBlock(Page.GetType(), DateTime.Now.ToString(), "javascript:alert('Please Enter Project Identification Details First');", true);
            ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(1);", true);
        }
    }
    protected void btnNotesAdd_Click(object sender, EventArgs e)
    {
        Response.Redirect("..\\ClaimInfo\\ClaimNotesEPM.aspx?loc=" + LocationID + "&FK_Claim=" + Encryption.Encrypt(PK_EPM_Identification.ToString()) + "&tbl=" + "EPM_Identification" + "&op=" + Request.QueryString["op"].ToString());
    }
    //End of Issue #3168
    #endregion

    #region " Grid Events "
    /// <summary>
    ///  handles Row Commant Event foe Project Cost Grid as per strOperation
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvProjectCost_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "EditProjectCost")
        {
            string[] arg = new string[2];
            arg = e.CommandArgument.ToString().Split(';');
            decimal decPK_EPM_Project_Cost, decFK_EPM_Identification = 0;
            decPK_EPM_Project_Cost = Convert.ToDecimal(arg[0]);
            decFK_EPM_Identification = Convert.ToDecimal(arg[1]);
            if (StrOperation.ToLower() != "view")
            {
                Response.Redirect("EPM_Project_Cost.aspx?loc=" + Encryption.Encrypt(LocationID.ToString()) + "&Cid=" + Encryption.Encrypt(PK_EPM_Identification.ToString()) + "&id=" + Encryption.Encrypt(decFK_EPM_Identification.ToString()) + "&PCI=" + Encryption.Encrypt(decPK_EPM_Project_Cost.ToString()) + "&pnl=" + hdnPanel.Value + "&op=edit", true);
            }
            else
                Response.Redirect("EPM_Project_Cost.aspx?loc=" + Encryption.Encrypt(LocationID.ToString()) + "&Cid=" + Encryption.Encrypt(PK_EPM_Identification.ToString()) + "&id=" + Encryption.Encrypt(decFK_EPM_Identification.ToString()) + "&PCI=" + Encryption.Encrypt(decPK_EPM_Project_Cost.ToString()) + "&pnl=" + hdnPanel.Value + "&op=view", true);
        }
        if (e.CommandName == "RemoveProjectCost")
        {
            clsEPM_Project_Cost.DeleteByPK(Convert.ToDecimal(e.CommandArgument));
            bindProjectCostGrid();
            chkIncludeCompProject.Checked = false;
            ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(3);", true);
        }
    }

    decimal decBudget = 0, decEstimatedCost = 0, decActualCost = 0;
    /// <summary>
    ///  handles Row Data Bound Event foe Project Cost Grid When strOperation is edit
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvProjectCost_OnRowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (StrOperation.ToLower() != "view")
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton lnkRemove = (LinkButton)e.Row.FindControl("lnkRemove");
                decimal Pk_EPM_Project_Cost = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "FK_EPM_Identification"));
                if (Pk_EPM_Project_Cost == PK_EPM_Identification)
                {
                    lnkRemove.Visible = true;
                }
                else
                {
                    lnkRemove.Visible = false;
                }
                decBudget += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Budget"));
                decEstimatedCost += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Estimated_Cost"));
                decActualCost += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Actual_Cost"));
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                Label BudgetAmt = (Label)e.Row.FindControl("lblBudgetSum");
                Label EstimatedCostAmt = (Label)e.Row.FindControl("lblEstimatedCostSum");
                Label ActualCostAmt = (Label)e.Row.FindControl("lblActualCostSum");

                BudgetAmt.Text = decBudget.ToString("C");
                EstimatedCostAmt.Text = decEstimatedCost.ToString("C");
                ActualCostAmt.Text = decActualCost.ToString("C");
            }
        }
        else
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                decBudget += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Budget"));
                decEstimatedCost += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Estimated_Cost"));
                decActualCost += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Actual_Cost"));
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                Label BudgetAmtView = (Label)e.Row.FindControl("lblBudgetSum");
                Label EstimatedCostAmtView = (Label)e.Row.FindControl("lblEstimatedCostSum");
                Label ActualCostAmtView = (Label)e.Row.FindControl("lblActualCostSum");

                BudgetAmtView.Text = decBudget.ToString("C");
                EstimatedCostAmtView.Text = decEstimatedCost.ToString("C");
                ActualCostAmtView.Text = decActualCost.ToString("C");
            }
        }
    }

    /// <summary>
    /// handles Row Command of Project Milestone Grid as per strOperation
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvProjectMilestone_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "EditProjectMilestone")
        {
            if (StrOperation.ToLower() != "view")
                Response.Redirect("EPM_Project_Milestone.aspx?loc=" + Encryption.Encrypt(LocationID.ToString()) + "&id=" + Encryption.Encrypt(PK_EPM_Identification.ToString()) + "&PMI=" + (Encryption.Encrypt(e.CommandArgument.ToString())) + "&pnl=" + hdnPanel.Value + "&op=edit", true);
            else
                Response.Redirect("EPM_Project_Milestone.aspx?loc=" + Encryption.Encrypt(LocationID.ToString()) + "&id=" + Encryption.Encrypt(PK_EPM_Identification.ToString()) + "&PMI=" + (Encryption.Encrypt(e.CommandArgument.ToString())) + "&pnl=" + hdnPanel.Value + "&op=view", true);
        }
        else if (e.CommandName == "RemoveProjectMilestone")
        {
            clsEPM_Milestone.DeleteByPK(Convert.ToDecimal(e.CommandArgument));
            bindProjectMilestoneGrid();
            ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(4);", true);
        }
    }

    //Added due to #Issue : 3168
    protected void gvNotes_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        //check Command Name
        if (e.CommandName == "EditRecord")
        {
            Response.Redirect("..\\ClaimInfo\\ClaimNotesEPM.aspx?id=" + Encryption.Encrypt(e.CommandArgument.ToString()) + "&loc=" + LocationID + "&FK_Claim=" + Encryption.Encrypt(PK_EPM_Identification.ToString()) + "&tbl=" + "EPM_Identification" + "&op=" + Request.QueryString["op"].ToString());
        }
        else if (e.CommandName == "Remove")
        {
            // Delete record
            clsEPM_Consultant_Notes.DeleteByPK(Convert.ToDecimal(e.CommandArgument));
            BindConsultantNotes();
            ScriptManager.RegisterStartupScript(this, this.GetType(), System.DateTime.Now.ToString(), "javascrip:ShowPanel(2);", true);
        }
    }
    protected void gvInvoice_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        //check Command Name
        if (e.CommandName == "EditRecord")
        {
            Response.Redirect("..\\Exposures\\EPM_Project_Cost_Invoice.aspx?loc=" + LocationID.ToString() + "&Cid=" + Encryption.Encrypt(PK_EPM_Identification.ToString()) + "&id=" + Encryption.Encrypt("0") + "&PCInvoice=" + Encryption.Encrypt(e.CommandArgument.ToString()) + "&pnl=" + hdnPanel.Value + "&op=" + StrOperation, true);
        }
        else if (e.CommandName == "Remove")
        {
            // Delete record
            clsEPM_Project_Cost_Invoice.DeleteByPK(Convert.ToDecimal(e.CommandArgument));
            BindInvoiceGrid();
            ScriptManager.RegisterStartupScript(this, this.GetType(), System.DateTime.Now.ToString(), "javascrip:ShowPanel(3);", true);
        }
    }
    protected void gvActionNotes_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        //check Command Name
        if (e.CommandName == "EditRecord")
        {
            Response.Redirect("..\\ClaimInfo\\ClaimNotesEPMActionNotesRM.aspx?id=" + Encryption.Encrypt(e.CommandArgument.ToString()) + "&loc=" + LocationID + "&FK_Claim=" + Encryption.Encrypt(PK_EPM_Identification.ToString()) + "&tbl=" + "EPM_Action_Notes_RM" + "&op=" + Request.QueryString["op"].ToString());
        }
        else if (e.CommandName == "Remove")
        {
            // Delete record
            clsEPM_Action_Notes_RM.DeleteByPK(Convert.ToDecimal(e.CommandArgument));
            BindEPMActionNotes();
            ScriptManager.RegisterStartupScript(this, this.GetType(), System.DateTime.Now.ToString(), "javascrip:ShowPanel(5);", true);
        }
    }
    //End of Issue
    #endregion

    #region " Dynamic validations "
    /// <summary>
    /// Set Validation
    /// </summary>
    private void SetValidations()
    {
        #region " Identification"
        string strCtrlsIDsIdentification = "";
        string strMessagesIdentification = "";
        DataTable dtFieldsIdentification = clsScreen_Validators.SelectByScreen(193).Tables[0];
        dtFieldsIdentification.DefaultView.RowFilter = "IsRequired = '1'";
        dtFieldsIdentification = dtFieldsIdentification.DefaultView.ToTable();
        MenuAsterisk1.Style["display"] = (dtFieldsIdentification.Select("LeftMenuIndex = 1").Length > 0) ? "inline-block" : "none";

        foreach (DataRow drFieldIdentification in dtFieldsIdentification.Rows)
        {
            #region " set validation control IDs and messages "
            switch (Convert.ToString(drFieldIdentification["Field_Name"]))
            {
                case "Companion to Project": strCtrlsIDsIdentification += drpCompanion_to_Project.ClientID + ","; strMessagesIdentification += "Please enter [Identification]/Companion to Project" + ","; Span1.Style["display"] = "inline-block"; break;
                case "Building(s)": strCtrlsIDsIdentification += chkBuilding.ClientID + ","; strMessagesIdentification += "" + ","; Span3.Style["display"] = "inline-block"; break;
                case "Equipment": strCtrlsIDsIdentification += lstEquipment.ClientID + ","; strMessagesIdentification += "Please select [Identification]/Equipment" + ","; Span4.Style["display"] = "inline-block"; break;
                case "Project Type ": strCtrlsIDsIdentification += drpProject_Type.ClientID + ","; strMessagesIdentification += "Please select [Identification]/Project Type " + ","; Span5.Style["display"] = "inline-block"; break;
                case "Project Description": strCtrlsIDsIdentification += txtProject_Description.ClientID + ","; strMessagesIdentification += "Please enter [Identification]/Project Description" + ","; Span6.Style["display"] = "inline-block"; break;
                case "Requesting Entity": strCtrlsIDsIdentification += drpRequesting_Entity.ClientID + ","; strMessagesIdentification += "Please select [Identification]/Requesting Entity" + ","; Span7.Style["display"] = "inline-block"; break;
                case "Person Requesting Work": strCtrlsIDsIdentification += txtPerson_Requesting_Work.ClientID + ","; strMessagesIdentification += "Please enter [Identification]/Person Requesting Work" + ","; Span45.Style["display"] = "inline-block"; break;
                case "Title of Person Requesting Work": strCtrlsIDsIdentification += txtTitle_of_Person_RequestingWork.ClientID + ","; strMessagesIdentification += "Please enter [Identification]/Title of Person Requesting Work" + ","; Span46.Style["display"] = "inline-block"; break;
                case "Target Area": strCtrlsIDsIdentification += lstTargetArea.ClientID + ","; strMessagesIdentification += "Please select [Identification]/Target Area" + ","; Span8.Style["display"] = "inline-block"; break;
                case "Purpose of Project": strCtrlsIDsIdentification += lstPurpose_Of_Project.ClientID + ","; strMessagesIdentification += "Please select [Identification]/Purpose of Project" + ","; Span43.Style["display"] = "inline-block"; break;
                case "Existing Documents": strCtrlsIDsIdentification += lstExistingDocuments.ClientID + ","; strMessagesIdentification += "Please select [Identification]/Existing Documents" + ","; Span44.Style["display"] = "inline-block"; break;
                case "Name": strCtrlsIDsIdentification += txtName.ClientID + ","; strMessagesIdentification += "Please enter [Identification]/Name" + ","; spnName.Style["display"] = "inline-block"; break;
                case "Telephone": strCtrlsIDsIdentification += txtTelephone.ClientID + ","; strMessagesIdentification += "Please enter [Identification]/Telephone" + ","; spnTelephone.Style["display"] = "inline-block"; break;
                case "E-Mail": strCtrlsIDsIdentification += txtEmail.ClientID + ","; strMessagesIdentification += "Please enter [Identification]/Email" + ","; spnEmail.Style["display"] = "inline-block"; break;
            }
            #endregion
        }
        strCtrlsIDsIdentification = strCtrlsIDsIdentification.TrimEnd(',');
        strMessagesIdentification = strMessagesIdentification.TrimEnd(',');

        hdnControlIDsIdentification.Value = strCtrlsIDsIdentification;
        hdnErrorMsgsIdentification.Value = strMessagesIdentification;

        #endregion

        #region " Consultant and Schedule "
        string strCtrlsIDsConsultant = "";
        string strMessagesConsultant = "";
        DataTable dtFieldsConsultant = clsScreen_Validators.SelectByScreen(194).Tables[0];
        dtFieldsConsultant.DefaultView.RowFilter = "IsRequired = '1'";
        dtFieldsConsultant = dtFieldsConsultant.DefaultView.ToTable();
        MenuAsterisk2.Style["display"] = (dtFieldsConsultant.Select("LeftMenuIndex = 2").Length > 0) ? "inline-block" : "none";
        foreach (DataRow drFieldsConsultant in dtFieldsConsultant.Rows)
        {
            #region " set validation control IDs and messages "
            switch (Convert.ToString(drFieldsConsultant["Field_Name"]))
            {
                case "Consultant Company": strCtrlsIDsConsultant += txtConsultant_Company.ClientID + ","; strMessagesConsultant += "Please enter [Consultant and Schedule]/Consultant Company" + ","; Span11.Style["display"] = "inline-block"; break;
                case "Consultant Address 1": strCtrlsIDsConsultant += txtConsultant_Address1.ClientID + ","; strMessagesConsultant += "Please enter [Consultant and Schedule]/Consultant Address 1" + ","; Span12.Style["display"] = "inline-block"; break;
                case "Consultant Address 2": strCtrlsIDsConsultant += txtConsultant_Address2.ClientID + ","; strMessagesConsultant += "Please enter [Consultant and Schedule]/Consultant Address 2" + ","; Span13.Style["display"] = "inline-block"; break;
                case "Consultant City": strCtrlsIDsConsultant += txtConsultant_City.ClientID + ","; strMessagesConsultant += "Please enter [Consultant and Schedule]/Consultant City" + ","; Span14.Style["display"] = "inline-block"; break;
                case "Consultant State": strCtrlsIDsConsultant += drpConsultant_State.ClientID + ","; strMessagesConsultant += "Please select [Consultant and Schedule]/Consultant State" + ","; Span15.Style["display"] = "inline-block"; break;
                case "Consultant Zip Code": strCtrlsIDsConsultant += txtConsultant_Zip_Code.ClientID + ","; strMessagesConsultant += "Please enter [Consultant and Schedule]/Consultant Zip Code" + ","; Span16.Style["display"] = "inline-block"; break;
                case "Consultant Contact Name": strCtrlsIDsConsultant += txtConsultant_Contact_Name.ClientID + ","; strMessagesConsultant += "Please enter [Consultant and Schedule]/Consultant Contact Name" + ","; Span17.Style["display"] = "inline-block"; break;
                case "Consultant Contact Telephone Number": strCtrlsIDsConsultant += txtConsultant_Contact_Telephone.ClientID + ","; strMessagesConsultant += "Please enter [Consultant and Schedule]/Consultant Contact Telephone Number" + ","; Span18.Style["display"] = "inline-block"; break;
                case "Consultant Contact E-Mail": strCtrlsIDsConsultant += txtConsultant_Contact_EMail.ClientID + ","; strMessagesConsultant += "Please enter [Consultant and Schedule]/Consultant Contact E-Mail" + ","; Span19.Style["display"] = "inline-block"; break;

                case "Date to Consultant": strCtrlsIDsConsultant += txtDate_to_Consultant.ClientID + ","; strMessagesConsultant += "Please enter [Consultant and Schedule]/Date to Consultant" + ","; Span20.Style["display"] = "inline-block"; break;
                case "RM Notification Date": strCtrlsIDsConsultant += txtRM_Notification_Date.ClientID + ","; strMessagesConsultant += "Please enter [Consultant and Schedule]/RM Notification Date" + ","; Span21.Style["display"] = "inline-block"; break;
                case "Estimated Project Start Date ": strCtrlsIDsConsultant += txtEstimated_Project_StartDate.ClientID + ","; strMessagesConsultant += "Please enter [Consultant and Schedule]/Estimated Project Start Date " + ","; Span22.Style["display"] = "inline-block"; break;
                case "Actual Project Start Date": strCtrlsIDsConsultant += txtActual_Project_StartDate.ClientID + ","; strMessagesConsultant += "Please enter [Consultant and Schedule]/Actual Project Start Date" + ","; Span23.Style["display"] = "inline-block"; break;
                case "Project Due Date": strCtrlsIDsConsultant += txtEstimated_Project_CompletionDate.ClientID + ","; strMessagesConsultant += "Please enter [Consultant and Schedule]/Project Due Date" + ","; Span24.Style["display"] = "inline-block"; break;
                case "Actual Project Completion Date": strCtrlsIDsConsultant += txtActual_Project_CompletionDate.ClientID + ","; strMessagesConsultant += "Please enter [Consultant and Schedule]/Actual Project Completion Date" + ","; Span25.Style["display"] = "inline-block"; break;
            }
            #endregion
        }
        strCtrlsIDsConsultant = strCtrlsIDsConsultant.TrimEnd(',');
        strMessagesConsultant = strMessagesConsultant.TrimEnd(',');

        hdnCtrlsIDsConsultant.Value = strCtrlsIDsConsultant;
        hdnMessagesConsultant.Value = strMessagesConsultant;

        #endregion

        #region " Action And Notes "
        string strCtrlsIDsAction_Notes = "";
        string strMessagesAction_Notes = "";
        DataTable dtFieldsAction_Notes = clsScreen_Validators.SelectByScreen(198).Tables[0];
        dtFieldsAction_Notes.DefaultView.RowFilter = "IsRequired = '1'";
        dtFieldsAction_Notes = dtFieldsAction_Notes.DefaultView.ToTable();
        MenuAsterisk5.Style["display"] = (dtFieldsAction_Notes.Select("LeftMenuIndex = 6").Length > 0) ? "inline-block" : "none";
        foreach (DataRow drFieldsAction_Notes in dtFieldsAction_Notes.Rows)
        {
            #region " set validation control IDs and messages "
            switch (Convert.ToString(drFieldsAction_Notes["Field_Name"]))
            {
                case "Required Activity": strCtrlsIDsAction_Notes += drpRequired_Activity.ClientID + ","; strMessagesAction_Notes += "Please select [Action and Notes]/Required Activity" + ","; Span26.Style["display"] = "inline-block"; break;
                case "Required Activity Description": strCtrlsIDsAction_Notes += txtRequired_Activity_Description.ClientID + ","; strMessagesAction_Notes += "Please enter [Action and Notes]/Required Activity Description" + ","; Span27.Style["display"] = "inline-block"; break;
                case "Action": strCtrlsIDsAction_Notes += txtAction.ClientID + ","; strMessagesAction_Notes += "Please enter [Action and Notes]/Action" + ","; Span30.Style["display"] = "inline-block"; break;
                case "Status": strCtrlsIDsAction_Notes += txtStatus.ClientID + ","; strMessagesAction_Notes += "Please enter [Action and Notes]/Status" + ","; Span33.Style["display"] = "inline-block"; break;
                case "Issues": strCtrlsIDsAction_Notes += txtIssues.ClientID + ","; strMessagesAction_Notes += "Please enter [Action and Notes]/Issues" + ","; Span36.Style["display"] = "inline-block"; break;
                case "Outcome": strCtrlsIDsAction_Notes += drpOutcome.ClientID + ","; strMessagesAction_Notes += "Please select [Action and Notes]/Outcome" + ","; Span39.Style["display"] = "inline-block"; break;
                case "Comments": strCtrlsIDsAction_Notes += txtComments.ClientID + ","; strMessagesAction_Notes += "Please enter [Action and Notes]/Comments" + ","; Span40.Style["display"] = "inline-block"; break;
            }
            #endregion
        }
        strCtrlsIDsAction_Notes = strCtrlsIDsAction_Notes.TrimEnd(',');
        strMessagesAction_Notes = strMessagesAction_Notes.TrimEnd(',');

        hdnCtrlsIDsAction_Notes.Value = strCtrlsIDsAction_Notes;
        hdnMessagesAction_Notes.Value = strMessagesAction_Notes;

        #endregion
    }
    #endregion    
    
    #region "Set Page size of Notes"
    protected void ctrlPageSonicNotes_GetPage()
    {
        BindConsultantNotes();
        Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(" + 2 + ");", true);

    }
    protected void ctrlPageActionNotes_GetPage()
    {
        BindEPMActionNotes();
        Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(" + 5 + ");", true);

    }       
    #endregion
 
    
}