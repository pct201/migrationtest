using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERIMS.DAL;
using System.Text;
using System.IO;
using System.Web.UI.HtmlControls;
using System.Net.Mail;



public partial class Management_Management : clsBasePage
{

    #region Property

    /// <summary>
    /// Denotes the Primary Key
    /// </summary>
    public decimal PK_Management
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_Management"]);
        }
        set { ViewState["PK_Management"] = value; }
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
    public decimal _PK_ID_Store
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_ID_Store"]);
        }
        set { ViewState["PK_ID_Store"] = value; }
    }

    /// <summary>
    /// Denotes the Primary Key
    /// </summary>
    public decimal _PK_ID_ACI
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_ID_ACI"]);
        }
        set { ViewState["PK_ID_ACI"] = value; }
    }

    /// <summary>
    /// Denotes the Primary Key
    /// </summary>
    public decimal _PK_Management_Notes
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_Management_Notes"]);
        }
        set { ViewState["PK_Management_Notes"] = value; }
    }

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
    #endregion

    #region "Page Events"
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtCurrentDate.Text = clsGeneral.FormatDateToDisplay(DateTime.Now);
            PK_Management = clsGeneral.GetQueryStringID(Request.QueryString["id"]);
            StrOperation = Convert.ToString(Request.QueryString["mode"]);
            hdnPanel.Value = clsGeneral.GetPanelId(Request.QueryString["pnl"]).ToString();
            if (StrOperation == "add")
            {
                Session.Remove("Managementcriteria");
                //drpFacilitiesIssue.SelectedValue = "Y";
                //drpFacilitiesIssue.Enabled = false;
                dvView.Visible = false;
                btnManagementNoteView.Visible = btnManagementPrint.Visible = btnManagementSpecificNote.Visible = false;
                trApprovals.Style.Add("display", "none");
            }
            if (PK_Management > 0)
            {

                if (StrOperation.ToLower() == "view" || App_Access == AccessType.View_Only)
                {
                    BindDetailsForView();
                    ucAttachmentView.FK_Table = PK_Management;
                    btnResendManagementAbstract.Text = "Send Management Abstract";
                }
                else if (StrOperation.ToLower() == "edit")
                {
                    BindDropDown();
                    BindDetailsForEdit();
                    SetValidationsManagement();
                    ucAttachment.FK_Table = PK_Management;
                    ucAttachment.ReadOnly = false;
                    btnResendManagementAbstract.Text = "Save and Send Management Abstract";
                }
                BindStoreGrid();
                BindACIGrid();

                btnResendManagementAbstract.Visible = true;
            }
            else
            {
                // Check User Rights
                if (App_Access == AccessType.View_Only)
                    Response.Redirect(AppConfig.SiteURL + "Error.aspx?msg=errAcc");

                BindDropDown();
                //drpClientIssue.ClearSelection();
                //drpClientIssue.SelectedValue = "Y";
                BindStoreGrid();
                BindACIGrid();

                gvManagement_Notes.DataSource = null;
                gvManagement_Notes.DataBind();
                btnManagementNoteView.Visible = btnManagementPrint.Visible = btnManagementSpecificNote.Visible = ctrlPageSonicNotes.Visible = false;

                btnResendManagementAbstract.Visible = false;
                txtDate_Entered.Text = DateTime.Now.ToString("MM/dd/yyyy");
                txtRequestedBy.Text = clsSession.FirstName.Trim() + " " + clsSession.LastName.Trim();
                txtCreatedBy.Text = clsSession.FirstName.Trim() + " " + clsSession.LastName.Trim();
                SetValidationsManagement();
            }

            BindProjectCostGrid();
            BindInvoiceGrid();
        }

        ctrlMgmtTab.SetSelectedTab(Controls_ManagementTab_ManagementTab.Tab.Management);
        Page.ClientScript.RegisterStartupScript(typeof(string), DateTime.Now.ToString(), "javascript:ShowPanel(" + hdnPanel.Value + ");", true);
    }
    #endregion

    #region "Methods"

    /// <summary>
    /// Bind DropDown
    /// </summary>
    private void BindDropDown()
    {
        //ComboHelper.FillLocation(new DropDownList[] { drpLocation }, true);
        ComboHelper.FillLocationByACIUser_New((new DropDownList[] { drpLocation }), Convert.ToDecimal(clsSession.UserID), true);
        ComboHelper.FillWork_Completed((new DropDownList[] { drpFK_Work_Completed }), true);
        ComboHelper.FillRecord_Type((new DropDownList[] { drpFK_Record_Type }), true);
        ComboHelper.FillApproval_Submission((new DropDownList[] { drpFK_LU_Approval_Submission }), true);
        ComboHelper.FillMaintenanceStatus((new DropDownList[] { drpMaintenanceStatus }), true);
        //ComboHelper.FillLU_Region(new DropDownList[] { drpRegion }, true);
        //ComboHelper.FillState(new DropDownList[] { drpState }, true);
        //ComboHelper.FillLU_Camera_Type(new DropDownList[] { drpCameraType }, true);
        ComboHelper.FillWork_To_Be_Completed((new DropDownList[] { drpFK_Work_To_Be_Completed_By }), true);
        ComboHelper.FillManagement_Task_Process((new DropDownList[] { drpFK_LU_Management_Task_Process }), true);

    }

    /// <summary>
    /// Save Record into Management Table
    /// </summary>
    private void SaveRecord()
    {
        bool AllApproved = false;

        clsManagement objRecord = new clsManagement();
        objRecord.PK_Management_ID = PK_Management;

        //objRecord.Company = txtCompany.Text;
        //objRecord.Company_Phone = txtCompany_Phone.Text;
        //objRecord.City = txtCity.Text;
        //objRecord.County = txtCounty.Text;
        //objRecord.Camera_Number = txtCameraNumber.Text;
        //objRecord.Cost = !string.IsNullOrEmpty(txtCost.Text) ? Convert.ToDecimal(txtCost.Text) : 0;
        //objRecord.Camera_Concern = ctrlCameraConcern.Text;
        objRecord.Reason_for_Request = ctrlReason_Request.Text;
        objRecord.Recommendation = ctrlRecommendation.Text;
        if (drpLocation.SelectedIndex > 0)
            objRecord.FK_LU_Location = Convert.ToDecimal(drpLocation.SelectedValue);
        else
            objRecord.FK_LU_Location = null;
        //if (drpState.SelectedIndex > 0)
        //    objRecord.FK_LU_State = Convert.ToDecimal(drpState.SelectedValue);
        //else
        //    objRecord.FK_LU_State = null;
        //if (drpRegion.SelectedIndex > 0)
        //    objRecord.FK_LU_Region = Convert.ToDecimal(drpRegion.SelectedValue);
        //else
        //    objRecord.FK_LU_Region = null;

        objRecord.FK_LU_State = null;
        objRecord.FK_LU_Region = null;
        //if (drpCameraType.SelectedIndex > 0)
        //    objRecord.FK_LU_Camera_Type = Convert.ToDecimal(drpCameraType.SelectedValue);
        //else
        //    objRecord.FK_LU_Camera_Type = null;

        //if (!string.IsNullOrEmpty(Convert.ToString(rblTask_Complete.SelectedValue)))
        //    objRecord.Task_Complete = Convert.ToBoolean(Convert.ToInt32(rblTask_Complete.SelectedValue));
        //else
        //    objRecord.Task_Complete = null;


        //set value of Client Issue
        //if (drpClientIssue.SelectedIndex > 0)
        //    objRecord.FK_LU_Client_Issue = Convert.ToString(drpClientIssue.SelectedValue);
        //else
        //    objRecord.FK_LU_Client_Issue = null;


        //set value of Facilities Issue 
        //if (drpFacilitiesIssue.SelectedIndex > 0)
        //    objRecord.FK_LU_Facilities_Issue = Convert.ToString(drpFacilitiesIssue.SelectedValue);
        //else
        //    objRecord.FK_LU_Facilities_Issue = null;
        objRecord.Date_Scheduled = clsGeneral.FormatNullDateToStore(txtdate_Scheduled.Text);
        objRecord.Date_Complete = clsGeneral.FormatNullDateToStore(txtDate_Completed.Text);
        objRecord.CR_Approved = clsGeneral.FormatNullDateToStore(txtCR_Approved.Text);
        if (txtLocation_Code.Text != "")
            objRecord.Location_Code = Convert.ToDecimal(txtLocation_Code.Text);
        //objRecord.Store_Contact_First_Name = txtStore_Contact_First_Name.Text;
        //objRecord.Store_Contact_Last_Name = txtStore_Contact_Last_Name.Text;
        //objRecord.Store_Contact_Phone = txtStore_Contact_Phone.Text;
        //objRecord.Store_Contact_Email = txtStore_Contact_Email.Text;
        //objRecord.Aci_Contact_First_Name = txtAci_Contact_First_Name.Text;
        //objRecord.Aci_Contact_Last_Name = txtAci_Contact_Last_Name.Text;
        //objRecord.Aci_Contact_Phone = txtAci_Contact_Phone.Text;
        //objRecord.Aci_Contact_Email = txtAci_Contact_Email.Text;

        if (drpFK_Record_Type.SelectedIndex > 0)
            objRecord.FK_LU_Record_Type = Convert.ToDecimal(drpFK_Record_Type.SelectedValue);
        else
            objRecord.FK_LU_Record_Type = null;

        //objRecord.No_Approval_Needed = chkNoApprovalNeeded.Checked;

        // if (clsGeneral.GetDecimalValue(txtService_Repair_Cost) > 1000)
        // {
        // objRecord.Approval_Needed = chkApprovalNeeded.Checked;
        objRecord.No_Approval_Needed = chkNoApprovalNeeded.Checked;
        // }
        // else if (clsGeneral.GetDecimalValue(txtService_Repair_Cost) < 1000)
        // {
        objRecord.Approval_Needed = chkApprovalNeeded.Checked;
        //     objRecord.No_Approval_Needed = chkNoApprovalNeeded.Checked;
        // }

        decimal? temp_FK_LU_Approval_Submission = null;
        if(PK_Management > 0)
            temp_FK_LU_Approval_Submission = (new clsManagement(PK_Management)).FK_LU_Approval_Submission;

        if (chkNoApprovalNeeded.Checked)
            objRecord.FK_LU_Approval_Submission = Convert.ToDecimal(drpFK_LU_Approval_Submission.Items.FindByText("Yes").Value);
        else
            objRecord.FK_LU_Approval_Submission = Convert.ToDecimal(hdnApprovalSubmission.Value);

        if (!string.IsNullOrEmpty(Convert.ToString(rdbRPMApproval.SelectedValue)))
            objRecord.RPM_Approval = Convert.ToBoolean(Convert.ToInt32(rdbRPMApproval.SelectedValue));
        else
            objRecord.RPM_Approval = null;

        objRecord.Work_To_Complete_Other = txtWork_To_Complete_Other.Text;

        //if (!string.IsNullOrEmpty(Convert.ToString(rdoWork_Completed_By.SelectedValue)))
        //    objRecord.Work_Completed_By = Convert.ToBoolean(Convert.ToInt32(rdoWork_Completed_By.SelectedValue));
        //else
        //    objRecord.Work_Completed_By = null;

        objRecord.Service_Repair_Cost = clsGeneral.GetDecimalNullableValue(txtService_Repair_Cost);
        //objRecord.Record_Type_Other = txtRecord_Type_Other.Text;
        objRecord.Job = txtJob.Text;
        //objRecord.Order = txtOrder.Text;
        objRecord.Order_Date = clsGeneral.FormatNullDateToStore(txtOrderDate.Text);
        objRecord.Requested_By = txtRequestedBy.Text;
        objRecord.Created_By = txtCreatedBy.Text;

        objRecord.Previous_Contract_Amount = clsGeneral.GetDecimalNullableValue(txtPreviousContractAmount);
        objRecord.Revised_Contract_Amount = clsGeneral.GetDecimalNullableValue(txtRevisedContractAmount);

        if (drpFK_Work_Completed.SelectedIndex > 0)
            objRecord.FK_LU_Work_Completed = Convert.ToDecimal(drpFK_Work_Completed.SelectedValue);
        else
            objRecord.FK_LU_Work_Completed = null;

        if (drpFK_Work_To_Be_Completed_By.SelectedIndex > 0)
            objRecord.FK_LU_Work_To_Be_Completed_By = Convert.ToDecimal(drpFK_Work_To_Be_Completed_By.SelectedValue);
        else
            objRecord.FK_LU_Work_To_Be_Completed_By = null;

        //**************Approval Screen Fields starts********************//
        objRecord.GM_Email_To = txtGM_Email_To.Text;
        objRecord.GM_Last_Email_Date = clsGeneral.FormatNullDateToStore(txtGM_Last_Email_Date.Text);
        objRecord.GM_Response_Date = clsGeneral.FormatNullDateToStore(txtGM_Response_Date.Text);
        if (rdoGM_Decision.SelectedValue == "1")
            objRecord.GM_Decision = true;
        else if (rdoGM_Decision.SelectedValue == "0")
            objRecord.GM_Decision = false;
        else
            objRecord.GM_Decision = null;

        objRecord.RLCM_Email_To = txtRLCM_Email_To.Text;
        objRecord.RLCM_Last_Email_Date = clsGeneral.FormatNullDateToStore(txtRLCM_Last_Email_Date.Text);
        objRecord.RLCM_Response_Date = clsGeneral.FormatNullDateToStore(txtRLCM_Response_Date.Text);
        if (rdoRLCM_Decision.SelectedValue == "1")
            objRecord.RLCM_Decision = true;
        else if (rdoRLCM_Decision.SelectedValue == "0")
            objRecord.RLCM_Decision = false;
        else
            objRecord.RLCM_Decision = null;

        objRecord.NAPM_Email_To = txtNAPM_Email_To.Text;
        objRecord.NAPM_Last_Email_Date = clsGeneral.FormatNullDateToStore(txtNAPM_Last_Email_Date.Text);
        objRecord.NAPM_Response_Date = clsGeneral.FormatNullDateToStore(txtNAPM_Response_Date.Text);
        if (rdoNAPM_Decision.SelectedValue == "1")
            objRecord.NAPM_Decision = true;
        else if (rdoNAPM_Decision.SelectedValue == "0")
            objRecord.NAPM_Decision = false;
        else
            objRecord.NAPM_Decision = null;

        objRecord.DRM_Email_To = txtDRM_Email_To.Text;
        objRecord.DRM_Last_Email_Date = clsGeneral.FormatNullDateToStore(txtDRM_Last_Email_Date.Text);
        objRecord.DRM_Response_Date = clsGeneral.FormatNullDateToStore(txtDRM_Response_Date.Text);
        if (rdoDRM_Decision.SelectedValue == "1")
            objRecord.DRM_Decision = true;
        else if (rdoDRM_Decision.SelectedValue == "0")
            objRecord.DRM_Decision = false;
        else
            objRecord.DRM_Decision = null;

        objRecord.FK_LU_Maintenance_Status = Convert.ToDecimal(drpMaintenanceStatus.SelectedValue.ToString());

        objRecord.Comment = txtComments.Text;
        objRecord.Service_Repair_Cost = (!string.IsNullOrEmpty(Convert.ToString(objRecord.Previous_Contract_Amount)) ? objRecord.Previous_Contract_Amount : 0) + (!string.IsNullOrEmpty(Convert.ToString(objRecord.Revised_Contract_Amount)) ? objRecord.Revised_Contract_Amount : 0);
        //**************Approval Screen Fields Ends********************//

        objRecord.Update_Date = DateTime.Now;
        objRecord.Updated_By = clsSession.UserID;

        if (PK_Management > 0)
        {
            objRecord.Update();
            //ViewState.Remove("EmailAbsratact");
        }
        else
        {
            PK_Management = objRecord.Insert();
            //ViewState["EmailAbsratact"] = PK_Management;
        }

        if (!temp_FK_LU_Approval_Submission.HasValue && objRecord.FK_LU_Approval_Submission.Value != 0 && (new clsLU_Approval_Submission(objRecord.FK_LU_Approval_Submission.Value)).Fld_Desc.ToLower() == "yes")
            SendAbstractViaEmailWhileInsert();
    }

    /// <summary>
    /// Bind Details
    /// </summary>
    private void BindDetailsForEdit()
    {
        dvView.Visible = false;
        dvEdit.Visible = true;
        btnViewAudit.Visible = true;
        pnl1View.Attributes.CssStyle.Add("display", "none");
        pnl1.Attributes.CssStyle.Add("display", "block");
        clsManagement objRecord = new clsManagement(PK_Management);
        if (PK_Management > 0)
        {
            if (objRecord.PK_Management_ID != null)
                PK_Management = Convert.ToDecimal(objRecord.PK_Management_ID);

            txtReferenceNumber.Text = Convert.ToString(objRecord.Reference_Number);
            txtDate_Entered.Text = clsGeneral.FormatDBNullDateToDisplay(objRecord.Date_Entered);

            //txtCompany.Text = objRecord.Company != null ? objRecord.Company : "";
            //txtCompany_Phone.Text = objRecord.Company_Phone != null ? objRecord.Company_Phone : "";
            //txtCity.Text = objRecord.City != null ? objRecord.City : "";
            //txtCounty.Text = objRecord.County != null ? objRecord.County : "";
            //txtCameraNumber.Text = objRecord.Camera_Number != null ? objRecord.Camera_Number : "";
            //txtCost.Text = objRecord.Cost != null ? Convert.ToString(objRecord.Cost) : "";
            //ctrlCameraConcern.Text = objRecord.Camera_Concern != null ? Convert.ToString(objRecord.Camera_Concern) : "";
            ctrlRecommendation.Text = objRecord.Recommendation != null ? Convert.ToString(objRecord.Recommendation) : "";


            //if (!string.IsNullOrEmpty(Convert.ToString(objRecord.Task_Complete)))
            //    rblTask_Complete.SelectedValue = Convert.ToString(Convert.ToDecimal(objRecord.Task_Complete));
            //else
            //    rblTask_Complete.ClearSelection();

            //if (objRecord.FK_LU_Location != null) drpLocation.SelectedValue = Convert.ToString(objRecord.FK_LU_Location);
            clsGeneral.SetDropdownValue(drpLocation, objRecord.FK_LU_Location, true);
            //if (objRecord.FK_LU_State != null) drpState.SelectedValue = Convert.ToString(objRecord.FK_LU_State);
            //if (objRecord.FK_LU_Region != null) drpRegion.SelectedValue = Convert.ToString(objRecord.FK_LU_Region);
            //if (objRecord.FK_LU_Camera_Type != null) drpCameraType.SelectedValue = Convert.ToString(objRecord.FK_LU_Camera_Type);
            //if (objRecord.FK_LU_Client_Issue != null) drpClientIssue.SelectedValue = Convert.ToString(objRecord.FK_LU_Client_Issue);
            //if (objRecord.FK_LU_Facilities_Issue != null) drpFacilitiesIssue.SelectedValue = Convert.ToString(objRecord.FK_LU_Facilities_Issue);

            clsGeneral.SetDropdownValue(drpFK_Record_Type, objRecord.FK_LU_Record_Type, true);
            clsGeneral.SetDropdownValue(drpFK_LU_Approval_Submission, objRecord.FK_LU_Approval_Submission, true);
            clsGeneral.SetDropdownValue(drpMaintenanceStatus, objRecord.FK_LU_Maintenance_Status, true);
            clsGeneral.SetDropdownValue(drpFK_Work_To_Be_Completed_By, objRecord.FK_LU_Work_To_Be_Completed_By, true);

            txtWork_To_Complete_Other.Text = objRecord.Work_To_Complete_Other;

            //if (!string.IsNullOrEmpty(Convert.ToString(objRecord.Work_Completed_By)))
            //    rdoWork_Completed_By.SelectedValue = Convert.ToString(Convert.ToDecimal(objRecord.Work_Completed_By));
            //else
            //    rdoWork_Completed_By.ClearSelection();

            txtService_Repair_Cost.Text = clsGeneral.GetStringValue(objRecord.Service_Repair_Cost);
            //txtRecord_Type_Other.Text = objRecord.Record_Type_Other;
            txtJob.Text = objRecord.Job;
            //txtOrder.Text = objRecord.Order;
            txtOrderDate.Text = clsGeneral.FormatDBNullDateToDisplay(objRecord.Order_Date);
            txtRequestedBy.Text = objRecord.Requested_By;
            txtCreatedBy.Text = objRecord.Created_By;

            if (objRecord.No_Approval_Needed.HasValue && objRecord.No_Approval_Needed.Value)
            {
                trApprovals.Style.Add("display", "none");
                chkNoApprovalNeeded.Checked = true;
                showHideOriginalService(true);
                if (objRecord.Approval_Needed.HasValue && objRecord.Approval_Needed.Value)
                    trApprovals.Style.Add("display", "block");
            }
            else
            {
                trApprovals.Style.Add("display", "block");
                chkNoApprovalNeeded.Checked = false;
                showHideOriginalService(false);
                if (objRecord.Approval_Needed.HasValue && objRecord.Approval_Needed.Value)
                    trApprovals.Style.Add("display", "block");
                else
                    trApprovals.Style.Add("display", "none");
            }

            if (objRecord.Approval_Needed.HasValue && objRecord.Approval_Needed.Value)
            {
                chkApprovalNeeded.Checked = true;
                chkNoApprovalNeeded.Enabled = false;
                showHideRepairEstimate(true);
            }
            else
            {
                chkApprovalNeeded.Checked = false;
                showHideRepairEstimate(false);
            }

            //if (clsGeneral.GetDecimalValue(txtService_Repair_Cost) < 1000)
            //{
            //    chkNoApprovalNeeded.Checked = true;
            //    chkApprovalNeeded.Checked = false;
            //    chkApprovalNeeded.Enabled = false;
            //}
            //else if (clsGeneral.GetDecimalValue(txtService_Repair_Cost) > 1000)
            //{
            //    chkApprovalNeeded.Checked = true;
            //    chkNoApprovalNeeded.Checked = false;
            //    chkNoApprovalNeeded.Enabled = false;
            //}

            // Logic for setting RPM row and radio button visible and set to its value
            if (objRecord.RPM_Approval.HasValue)
            {
                rdbRPMApproval.Items.FindByValue("1").Selected = true;
            }

            ListItem lst = drpFK_Work_Completed.Items.FindByValue(objRecord.FK_LU_Work_Completed.ToString());
            if (lst != null && lst.Text.ToLower().Contains("add new"))
                trRPMApproval.Style.Add("display", "block");
            else
                trRPMApproval.Style.Add("display", "none");

            txtPreviousContractAmount.Text = clsGeneral.GetStringValue(objRecord.Previous_Contract_Amount);
            txtRevisedContractAmount.Text = clsGeneral.GetStringValue(objRecord.Revised_Contract_Amount);
            ctrlReason_Request.Text = objRecord.Reason_for_Request != null ? Convert.ToString(objRecord.Reason_for_Request) : "";

            clsGeneral.SetDropdownValue(drpFK_Work_Completed, objRecord.FK_LU_Work_Completed, true);

            txtdate_Scheduled.Text = clsGeneral.FormatDBNullDateToDisplay(objRecord.Date_Scheduled);
            txtDate_Completed.Text = clsGeneral.FormatDBNullDateToDisplay(objRecord.Date_Complete);
            txtCR_Approved.Text = clsGeneral.FormatDBNullDateToDisplay(objRecord.CR_Approved);

            if (objRecord.Location_Code != null)
                txtLocation_Code.Text = Convert.ToString(objRecord.Location_Code);

            //********************* Approval screen starts**********************//
            txtGM_Email_To.Text = Convert.ToString(objRecord.GM_Email_To);
            txtGM_Last_Email_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objRecord.GM_Last_Email_Date);
            txtGM_Response_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objRecord.GM_Response_Date);
            if (!string.IsNullOrEmpty(Convert.ToString(objRecord.GM_Decision)))
                rdoGM_Decision.SelectedValue = Convert.ToString(Convert.ToDecimal(objRecord.GM_Decision));
            else
                rdoGM_Decision.ClearSelection();

            txtRLCM_Email_To.Text = Convert.ToString(objRecord.RLCM_Email_To);
            txtRLCM_Last_Email_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objRecord.RLCM_Last_Email_Date);
            txtRLCM_Response_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objRecord.RLCM_Response_Date);
            if (!string.IsNullOrEmpty(Convert.ToString(objRecord.RLCM_Decision)))
                rdoRLCM_Decision.SelectedValue = Convert.ToString(Convert.ToDecimal(objRecord.RLCM_Decision));
            else
                rdoRLCM_Decision.ClearSelection();

            txtNAPM_Email_To.Text = Convert.ToString(objRecord.NAPM_Email_To);
            txtNAPM_Last_Email_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objRecord.NAPM_Last_Email_Date);
            txtNAPM_Response_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objRecord.NAPM_Response_Date);
            if (!string.IsNullOrEmpty(Convert.ToString(objRecord.NAPM_Decision)))
                rdoNAPM_Decision.SelectedValue = Convert.ToString(Convert.ToDecimal(objRecord.NAPM_Decision));
            else
                rdoNAPM_Decision.ClearSelection();

            txtDRM_Email_To.Text = Convert.ToString(objRecord.DRM_Email_To);
            txtDRM_Last_Email_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objRecord.DRM_Last_Email_Date);
            txtDRM_Response_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objRecord.DRM_Response_Date);
            if (!string.IsNullOrEmpty(Convert.ToString(objRecord.DRM_Decision)))
                rdoDRM_Decision.SelectedValue = Convert.ToString(Convert.ToDecimal(objRecord.DRM_Decision));
            else
                rdoDRM_Decision.ClearSelection();

            txtComments.Text = Convert.ToString(objRecord.Comment);

            //if (chkApprovalNeeded.Checked || !chkNoApprovalNeeded.Checked)
            //{
            //    trApprovals.Style.Add("display", "block");
            //}
            //else
            //{
            //    trApprovals.Style.Add("display", "none");
            //}

            //********************* Approval screen end**********************//
            BindManagementNoteGrid(ctrlPageSonicNotes.CurrentPage, ctrlPageSonicNotes.PageSize);
        }
    }

    /// <summary>
    /// bind project Cost Grid
    /// </summary>
    private void BindProjectCostGrid()
    {
        DataTable dtProjectCost = clsACIManagement_ProjectCost.SelectByFK(PK_Management).Tables[0];
        if (StrOperation.ToLower() != "view")
        {
            //if (chkIncludeCompProject.Checked == true)
            //{
            //    gvProjectCost.Columns[0].Visible = true;
            //    gvProjectCost.Columns[1].Visible = true;
            //}
            //else
            //{
            //    gvProjectCost.Columns[0].Visible = false;
            //    gvProjectCost.Columns[1].Visible = false;
            //}

            gvProjectCost.DataSource = dtProjectCost;
            gvProjectCost.DataBind();
        }
        else
        {
            //if (chkIncludeCompProjectView.Checked == true)
            //{
            //    gvProjectCostView.Columns[0].Visible = true;
            //    gvProjectCostView.Columns[1].Visible = true;
            //}
            //else
            //{
            //    gvProjectCostView.Columns[0].Visible = false;
            //    gvProjectCostView.Columns[1].Visible = false;
            //}

            gvProjectCostView.DataSource = dtProjectCost;
            gvProjectCostView.DataBind();
        }
    }

    /// <summary>
    /// Bind Details
    /// </summary>
    private void BindDetailsForView()
    {
        dvView.Visible = true;
        dvEdit.Visible = false;
        pnl1View.Attributes.CssStyle.Add("display", "block");
        pnl1.Attributes.CssStyle.Add("display", "none");
        btnEdit.Visible = true;
        btnSave.Visible = false;
        btnViewAudit.Visible = true;
        btnEdit.Visible = (App_Access != AccessType.View_Only);

        clsManagement objRecord = new clsManagement(PK_Management);
        if (PK_Management > 0)
        {
            lblReference_Number.Text = Convert.ToString(objRecord.Reference_Number);
            lblDate_Entered.Text = clsGeneral.FormatDBNullDateToDisplay(objRecord.Date_Entered);
            //lblCompany.Text = objRecord.Company != null ? objRecord.Company : "";
            //lblCompany_Phone.Text = objRecord.Company_Phone != null ? objRecord.Company_Phone : "";
            //lblCity.Text = objRecord.City != null ? objRecord.City : "";
            //lblCounty.Text = objRecord.County != null ? objRecord.County : "";
            //lblCameraNumber.Text = objRecord.Camera_Number != null ? objRecord.Camera_Number : "";
            //lblCost.Text = objRecord.Cost != null ? Convert.ToString(objRecord.Cost) : "";
            //lblCameraConcern.Text = objRecord.Camera_Concern != null ? objRecord.Camera_Concern : "";
            lblRecommendation.Text = objRecord.Recommendation != null ? objRecord.Recommendation : "";

            lblDateScheduled.Text = clsGeneral.FormatDBNullDateToDisplay(objRecord.Date_Scheduled);
            lblDateComleted.Text = clsGeneral.FormatDBNullDateToDisplay(objRecord.Date_Complete);
            lblCRApproved.Text = clsGeneral.FormatDBNullDateToDisplay(objRecord.CR_Approved);

            //if (objRecord.FK_LU_Location != null)
            //    lblLocation.Text = new clsAci_Lu_Location((decimal)objRecord.FK_LU_Location).Fld_Desc;
            //else
            //    lblLocation.Text = "";
            if (objRecord.FK_LU_Location != null)
                lblLocation.Text = new LU_Location((decimal)objRecord.FK_LU_Location).dba;
            else
                lblLocation.Text = "";

            lblFK_LU_Maintenance_Status.Text = objRecord.FK_LU_Maintenance_Status.HasValue ? new LU_Maintenance_Status(objRecord.FK_LU_Maintenance_Status.Value).Fld_Desc : "";
            if (objRecord.No_Approval_Needed != null) chkNoAppovalNeededView.Checked = objRecord.No_Approval_Needed.Value;
            if (objRecord.Approval_Needed != null) chkApprovalNeededView.Checked = objRecord.Approval_Needed.Value;


            if (objRecord.No_Approval_Needed.HasValue && objRecord.No_Approval_Needed.Value)
            {
                trApprovals.Style.Add("display", "none");
                if (objRecord.Approval_Needed.HasValue && objRecord.Approval_Needed.Value)
                    trApprovals.Style.Add("display", "block");
            }
            else
            {
                trApprovals.Style.Add("display", "block");                
                if (objRecord.Approval_Needed.HasValue && objRecord.Approval_Needed.Value)
                    trApprovals.Style.Add("display", "block");
                else
                    trApprovals.Style.Add("display", "none");
            }
            //if (objRecord.FK_LU_State != null)
            //    lblState.Text = new LU_State((decimal)objRecord.FK_LU_State).Fld_Desc;
            //else
            //    lblState.Text = "";

            //if (objRecord.FK_LU_Region != null)
            //    lblRegion.Text = new LU_Region((decimal)objRecord.FK_LU_Region).Fld_Desc;
            //else
            //    lblRegion.Text = "";

            //switch (objRecord.Task_Complete)
            //{
            //    case true:
            //        lblTask_Complete.Text = "Yes";
            //        break;
            //    case false:
            //        lblTask_Complete.Text = "No";
            //        break;
            //    default:
            //        lblTask_Complete.Text = "";
            //        break;
            //}

            //if (objRecord.FK_LU_Camera_Type != null)
            //    lblCameraType.Text = new LU_Camera_Type((decimal)objRecord.FK_LU_Camera_Type).Fld_Desc;
            //else
            //    lblCameraType.Text = "";

            //if (objRecord.FK_LU_Client_Issue != null)
            //{
            //    if (objRecord.FK_LU_Client_Issue == "Y")
            //        lblClientIssue.Text = "Yes";
            //    else if (objRecord.FK_LU_Client_Issue == "N")
            //        lblClientIssue.Text = "No";
            //}
            //else
            //{
            //    lblClientIssue.Text = "";
            //}

            //if (objRecord.FK_LU_Facilities_Issue != null)
            //{
            //    if (objRecord.FK_LU_Facilities_Issue == "Y")
            //        lblFacilitiesIssue.Text = "Yes";
            //    else if (objRecord.FK_LU_Facilities_Issue == "N")
            //        lblFacilitiesIssue.Text = "No";
            //}
            //else
            //{
            //    lblFacilitiesIssue.Text = "";
            //}

            if (objRecord.FK_LU_Record_Type != null)
                lblFK_LU_Record_Type.Text = new clsLU_Record_Type((decimal)objRecord.FK_LU_Record_Type).Fld_Desc;
            else
                lblFK_LU_Record_Type.Text = string.Empty;

            if (objRecord.FK_LU_Approval_Submission != null)
                lblFK_LU_Approval_Submission.Text = new clsLU_Approval_Submission((decimal)objRecord.FK_LU_Approval_Submission).Fld_Desc;
            else
                lblFK_LU_Approval_Submission.Text = string.Empty;

            if (objRecord.Work_To_Complete_Other != null)
                lblWork_To_Complete_Other.Text = objRecord.Work_To_Complete_Other;
            else
                lblWork_To_Complete_Other.Text = string.Empty;

            //switch (objRecord.Work_Completed_By)
            //{
            //    case true:
            //        lblrdoWork_Completed_By.Text = "ACI";
            //        break;
            //    case false:
            //        lblrdoWork_Completed_By.Text = "Sonic";
            //        break;
            //    default:
            //        lblrdoWork_Completed_By.Text = "";
            //        break;
            //}

            if (objRecord.FK_LU_Work_To_Be_Completed_By != null)
                lblWork_To_Be_Completed_By.Text = new LU_Work_To_Be_Completed_By((decimal)objRecord.FK_LU_Work_To_Be_Completed_By).Fld_Desc;
            else
                lblWork_To_Be_Completed_By.Text = string.Empty;

            lblService_Repair_Cost.Text = clsGeneral.GetStringValue(objRecord.Service_Repair_Cost);
            //lblRecord_Type_Other.Text = objRecord.Record_Type_Other;
            lblJob.Text = objRecord.Job;
            //lblOrder.Text = objRecord.Order;
            lblOrderDate.Text = clsGeneral.FormatDBNullDateToDisplay(objRecord.Order_Date);
            lblRequestedBy.Text = objRecord.Requested_By;
            lblCreatedBy.Text = objRecord.Created_By;

            lblPreviousContractAmount.Text = clsGeneral.GetStringValue(objRecord.Previous_Contract_Amount);
            lblRevisedContractAmount.Text = clsGeneral.GetStringValue(objRecord.Revised_Contract_Amount);
            lblReason_Request.Text = objRecord.Reason_for_Request != null ? Convert.ToString(objRecord.Reason_for_Request) : "";

            if (objRecord.FK_LU_Work_Completed != null)
                lblFK_Work_Completed.Text = new clsLU_Work_Completed((decimal)objRecord.FK_LU_Work_Completed).Fld_Desc;
            else
                lblFK_Work_Completed.Text = string.Empty;

            if (objRecord.Location_Code != null)
                lblLocation_Code.Text = Convert.ToString(objRecord.Location_Code);
            //lblStore_Contact_First_Name.Text = objRecord.Store_Contact_First_Name;
            //lblStore_Contact_Last_Name.Text = objRecord.Store_Contact_Last_Name;
            //lblStore_Contact_Phone.Text = objRecord.Store_Contact_Phone;
            //lblStore_Contact_Email.Text = objRecord.Store_Contact_Email;
            //lblAci_Contact_First_Name.Text = objRecord.Aci_Contact_First_Name;
            //lblAci_Contact_Last_Name.Text = objRecord.Aci_Contact_Last_Name;
            //lblAci_Contact_Phone.Text = objRecord.Aci_Contact_Phone;
            //lblAci_Contact_Email.Text = objRecord.Aci_Contact_Email;

            //********************* Approval screen starts**********************//
            lblGM_Email_To.Text = Convert.ToString(objRecord.GM_Email_To);
            lblGM_Last_Email_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objRecord.GM_Last_Email_Date);
            lblGM_Response_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objRecord.GM_Response_Date);
            switch (objRecord.GM_Decision)
            {
                case true:
                    lblGM_Decisionview.Text = "Approved";
                    break;
                case false:
                    lblGM_Decisionview.Text = "NotApproved";
                    break;
                default:
                    lblGM_Decisionview.Text = "";
                    break;
            }


            lblRLCM_Email_To.Text = Convert.ToString(objRecord.RLCM_Email_To);
            lblRLCM_Last_Email_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objRecord.RLCM_Last_Email_Date);
            lblRLCM_Response_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objRecord.RLCM_Response_Date);
            switch (objRecord.RLCM_Decision)
            {
                case true:
                    lblRLCM_Decisionview.Text = "Approved";
                    break;
                case false:
                    lblRLCM_Decisionview.Text = "NotApproved";
                    break;
                default:
                    lblRLCM_Decisionview.Text = "";
                    break;
            }


            lblNAPM_Email_To.Text = Convert.ToString(objRecord.NAPM_Email_To);
            lblNAPM_Last_Email_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objRecord.NAPM_Last_Email_Date);
            lblNAPM_Response_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objRecord.NAPM_Response_Date);
            switch (objRecord.NAPM_Decision)
            {
                case true:
                    lblNAPM_DecisionView.Text = "Approved";
                    break;
                case false:
                    lblNAPM_DecisionView.Text = "NotApproved";
                    break;
                default:
                    lblNAPM_DecisionView.Text = "";
                    break;
            }

            lblDRM_Email_To.Text = Convert.ToString(objRecord.DRM_Email_To);
            lblDRM_Last_Email_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objRecord.DRM_Last_Email_Date);
            lblDRM_Response_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objRecord.DRM_Response_Date);
            switch (objRecord.DRM_Decision)
            {
                case true:
                    lblDRM_Decisionview.Text = "Approved";
                    break;
                case false:
                    lblDRM_Decisionview.Text = "NotApproved";
                    break;
                default:
                    lblDRM_Decisionview.Text = "";
                    break;
            }

            lblComments.Text = Convert.ToString(objRecord.Comment);

            //if (chkApprovalNeededView.Checked || !chkNoAppovalNeededView.Checked)
            //{
            //    trApprovals.Style.Add("display", "block");
            //}
            //else
            //{
            //    trApprovals.Style.Add("display", "none");
            //}

            //********************* Approval screen end**********************//

            BindManagementNoteGridView(ctrlPageSonicNotes.CurrentPage, ctrlPageSonicNotes.PageSize);
        }

    }

    protected void btnClear_Click(object sender, EventArgs e)
    {
        Button btnClear = (Button)sender;
        switch (btnClear.CommandArgument.ToString().ToUpper())
        {
            case "GM":
                rdoGM_Decision.ClearSelection();
                txtGM_Response_Date.Text = string.Empty;
                break;
            case "RLCM":
                rdoRLCM_Decision.ClearSelection();
                txtRLCM_Response_Date.Text = string.Empty;
                break;
            case "NAPM":
                rdoNAPM_Decision.ClearSelection();
                txtNAPM_Response_Date.Text = string.Empty;
                break;
            case "DRM":
                rdoDRM_Decision.ClearSelection();
                txtDRM_Response_Date.Text = string.Empty;
                break;
            default:
                break;

        }
        SaveRecord();
    }

    /// <summary>
    /// Bind Store Grid
    /// </summary>
    private void BindStoreGrid()
    {

        if (StrOperation.ToLower() == "view")
        {
            gvStoreContactView.DataSource = clsManagement_Sonic_Contact.SelectByFK_Management(PK_Management);
            gvStoreContactView.DataBind();
        }
        else if (StrOperation.ToLower() == "edit" || StrOperation.ToLower() == "add")
        {
            gvStoreContact.DataSource = clsManagement_Sonic_Contact.SelectByFK_Management(PK_Management);
            gvStoreContact.DataBind();
        }
        else
        {
            gvStoreContact.DataSource = null;
            gvStoreContact.DataBind();
        }

    }

    /// <summary>
    /// Bind ACI Grid
    /// </summary>
    private void BindACIGrid()
    {

        if (StrOperation.ToLower() == "view")
        {
            gvACIContactView.DataSource = clsManagement_ACI_Contact.SelectByFK_Management(PK_Management);
            gvACIContactView.DataBind();
        }
        else if (StrOperation.ToLower() == "edit" || StrOperation.ToLower() == "add")
        {
            gvACIContact.DataSource = clsManagement_ACI_Contact.SelectByFK_Management(PK_Management);
            gvACIContact.DataBind();
        }
        else
        {
            gvACIContact.DataSource = null;
            gvACIContact.DataBind();
        }

    }

    /// Used to Clear the controls
    /// </summary>
    private void ClearStoreControls()
    {
        //clear control
        _PK_ID_Store = 0;
        txtStore_Contact_First_Name.Text = string.Empty;
        txtStore_Contact_Last_Name.Text = string.Empty;
        txtStore_Contact_Email.Text = string.Empty;
        txtStore_Contact_Phone.Text = string.Empty;
    }

    /// Used to Clear the controls
    /// </summary>
    private void ClearACIControls()
    {
        //clear control
        _PK_ID_ACI = 0;
        txtAci_Contact_First_Name.Text = string.Empty;
        txtAci_Contact_Last_Name.Text = string.Empty;
        txtAci_Contact_Email.Text = string.Empty;
        txtAci_Contact_Phone.Text = string.Empty;
    }

    private void BindInvoiceGrid()
    {
        if (PK_Management > 0)
        {
            clsACIManagement_ProjectCost_Invoice objACIManagement_ProjectCost_Invoice = new clsACIManagement_ProjectCost_Invoice();
            DataSet dsInvoice = objACIManagement_ProjectCost_Invoice.SelectByFK(PK_Management);
            DataTable dtInvoice = dsInvoice.Tables[0];

            if (StrOperation == "view")
            {
                gvInvoiceView.DataSource = dtInvoice;
                gvInvoiceView.DataBind();
            }
            else
            {
                gvInvoice.DataSource = dtInvoice;
                gvInvoice.DataBind();
            }

        }
        else
        {
            gvInvoice.DataBind();
            //lnkAddInvoice.Visible = false;
        }

    }

    private void SendAbstractViaEmailWhileInsert()
    {
        if (PK_Management > 0)
        {
            clsManagement objManagement = new clsManagement(PK_Management);
            DataTable dtEmailList = Security.GetEmailsByLocation(objManagement.FK_LU_Location).Tables[0];
            //string[] strEmailIds = new string[1];

            string strAbstractReportData = Convert.ToString(Management_AbstractReport(PK_Management));

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

            if (EmailTo.Length > 0)
            {
                EmailHelper objEmail = new EmailHelper(AppConfig.SMTPServer, AppConfig.MailFrom, AppConfig.SMTPpwd, Convert.ToInt32(AppConfig.Port));
                objEmail.SendMailMessage(AppConfig.ManagementEmailID, " ", EmailTo, "ACI Management Abstract", strAbstractReportData, true, null, AppConfig.MailCC);
            }

            //for (int i = 0; i < dtEmailList.Rows.Count; i++)
            //{
            //    strEmailIds[0] = Convert.ToString(dtEmailList.Rows[i]["Email"]);
            //    EmailHelper objEmail = new EmailHelper(AppConfig.SMTPServer, AppConfig.MailFrom, AppConfig.SMTPpwd, Convert.ToInt32(AppConfig.Port));
            //    objEmail.SendMailMessage(AppConfig.ManagementEmailID, " ", strEmailIds, "ACI Management Abstract.", strAbstractReportData, true, null, AppConfig.MailCC);
            //    strEmailIds[0] = string.Empty;
            //}
        }
    }

    /// Used to Clear the controls
    /// </summary>
    private void ClearManagementNoteControls()
    {
        //clear control
        _PK_Management_Notes = 0;
        txtManagement_Notes.Text = string.Empty;
        //txtACI_Notes_Date.Text = string.Empty;
    }

    /// <summary>
    /// 
    /// Bind Sonic Notes Grid
    /// </summary>
    private void BindManagementNoteGrid(int PageNumber, int PageSize)
    {
        DataSet dsManagement_Note = clsSonic_Management_Notes.SelectByFK_Management_WithPaging(PK_Management, PageNumber, PageSize, SortBy, SortOrder);

        DataTable dtNotes = dsManagement_Note.Tables[0];
        ctrlPageSonicNotes.TotalRecords = (dsManagement_Note.Tables.Count >= 2) ? Convert.ToInt32(dsManagement_Note.Tables[1].Rows[0][0]) : 0;
        ctrlPageSonicNotes.CurrentPage = (dsManagement_Note.Tables.Count >= 2) ? Convert.ToInt32(dsManagement_Note.Tables[1].Rows[0][2]) : 0;
        ctrlPageSonicNotes.RecordsToBeDisplayed = dsManagement_Note.Tables[0].Rows.Count;
        ctrlPageSonicNotes.SetPageNumbers();
        if (dsManagement_Note != null && dsManagement_Note.Tables.Count > 0 && dsManagement_Note.Tables[0].Rows.Count > 0)
        {
            gvManagement_Notes.DataSource = dsManagement_Note;
            gvManagement_Notes.DataBind();
            btnManagementNoteView.Visible = btnManagementPrint.Visible = btnManagementSpecificNote.Visible = ctrlPageSonicNotes.Visible = true;
            dvManagementNotes.Style["Height"] = "200px";
        }
        else
        {
            gvManagement_Notes.DataSource = null;
            gvManagement_Notes.DataBind();
            btnManagementNoteView.Visible = btnManagementPrint.Visible = btnManagementSpecificNote.Visible = ctrlPageSonicNotes.Visible = false;
            dvManagementNotes.Style["Height"] = "31px";
        }
    }

    /// <summary>
    /// 
    /// Bind Sonic Notes Grid
    /// </summary>
    private void BindManagementNoteGridView(int PageNumber, int PageSize)
    {
        DataSet dsManagement_Note = clsSonic_Management_Notes.SelectByFK_Management_WithPaging(PK_Management, PageNumber, PageSize, SortBy, SortOrder);

        DataTable dtNotes = dsManagement_Note.Tables[0];
        ctrlPageSonicNotesView.TotalRecords = (dsManagement_Note.Tables.Count >= 2) ? Convert.ToInt32(dsManagement_Note.Tables[1].Rows[0][0]) : 0;
        ctrlPageSonicNotesView.CurrentPage = (dsManagement_Note.Tables.Count >= 2) ? Convert.ToInt32(dsManagement_Note.Tables[1].Rows[0][2]) : 0;
        ctrlPageSonicNotesView.RecordsToBeDisplayed = dsManagement_Note.Tables[0].Rows.Count;
        ctrlPageSonicNotesView.SetPageNumbers();
        if (dsManagement_Note != null && dsManagement_Note.Tables.Count > 0 && dsManagement_Note.Tables[0].Rows.Count > 0)
        {
            gvManagement_NotesView.DataSource = dsManagement_Note;
            gvManagement_NotesView.DataBind();
            btnManagementNoteView_View.Visible = btnManagementPrintView.Visible = btnManagementSpecificNote_View.Visible = ctrlPageSonicNotesView.Visible = true;
            dvManagementNotesView.Style["Height"] = "200px";
        }
        else
        {
            gvManagement_NotesView.DataSource = null;
            gvManagement_NotesView.DataBind();
            btnManagementNoteView_View.Visible = btnManagementPrintView.Visible = btnManagementSpecificNote_View.Visible = ctrlPageSonicNotesView.Visible = false;
            dvManagementNotesView.Style["Height"] = "31px";
        }
    }

    /// <summary>
    /// Implement event for Paging control when clicking on Go button
    /// </summary>
    protected void GetManagementPage()
    {
        BindManagementNoteGrid(ctrlPageSonicNotes.CurrentPage, ctrlPageSonicNotes.PageSize);
    }

    /// <summary>
    /// Implement event for Paging control when clicking on Go button
    /// </summary>
    protected void GetManagementPageView()
    {
        BindManagementNoteGridView(ctrlPageSonicNotesView.CurrentPage, ctrlPageSonicNotesView.PageSize);
    }

    public StringBuilder Management_AbstractReport(decimal _PK_Management)
    {
        DataSet dsAbstractManagement = clsManagement.GetManagementAbstractLetterData(_PK_Management);

        StringBuilder strBody = new StringBuilder("");

        if (dsAbstractManagement.Tables.Count > 0 && dsAbstractManagement.Tables[0].Rows.Count > 0)
        {
            DataTable dtManagementDetail = dsAbstractManagement.Tables[0];
            DataTable dtStoreContactDetails = dsAbstractManagement.Tables[1];
            DataTable dtACIContactDetails = dsAbstractManagement.Tables[2];
            DataTable dtProjectCostDetails = dsAbstractManagement.Tables[3];
            DataTable dtInvoiceDetails = dsAbstractManagement.Tables[4];
            DataTable dtManagementNotes = dsAbstractManagement.Tables[5];

            FileStream fsMail = null;

            fsMail = new FileStream(AppConfig.DocumentsPath + @"\AbstractLetterTemplate\Management_AbstractReport.html", FileMode.Open, FileAccess.Read);

            StreamReader rd = new StreamReader(fsMail);
            //StringBuilder strBody = new StringBuilder(rd.ReadToEnd().ToString());
            rd = new StreamReader(fsMail);
            strBody = new StringBuilder(rd.ReadToEnd().ToString());


            rd.Close();
            fsMail.Close();

            #region "Management Details"

            strBody = strBody.Replace("[DBA]", Convert.ToString(dtManagementDetail.Rows[0]["DBA"]));
            strBody = strBody.Replace("[Reference_Number]", Convert.ToString(dtManagementDetail.Rows[0]["Reference_Number"]));
            strBody = strBody.Replace("[Date_Entered]", clsGeneral.FormatDBNullDateToDisplay(dtManagementDetail.Rows[0]["Date_Entered"]));
            strBody = strBody.Replace("[LocationCode]", Convert.ToString(dtManagementDetail.Rows[0]["Location_Code"]));
            strBody = strBody.Replace("[DateScheduled]", clsGeneral.FormatDBNullDateToDisplay(dtManagementDetail.Rows[0]["Date_Scheduled"]));
            strBody = strBody.Replace("[DateCompleted]", clsGeneral.FormatDBNullDateToDisplay(dtManagementDetail.Rows[0]["Date_Complete"]));
            strBody = strBody.Replace("[WorkToBeCompleted]", Convert.ToString(dtManagementDetail.Rows[0]["WorkToBeCompleted"]));
            strBody = strBody.Replace("[WorkToBeCompletedOther]", Convert.ToString(dtManagementDetail.Rows[0]["Work_To_Complete_Other"]));
            strBody = strBody.Replace("[WorkToBeCompletedBy]", Convert.ToString(dtManagementDetail.Rows[0]["WorkToBeCompletedBy"]));

            //if (!DBNull.Value.Equals(dtManagementDetail.Rows[0]["Work_Completed_By"]))
            //{
            //    switch (Convert.ToBoolean(dtManagementDetail.Rows[0]["Work_Completed_By"]))
            //    {
            //        case false:
            //            strBody = strBody.Replace("[WorkToBeCompletedBy]", "Sonic");
            //            break;
            //        case true:
            //            strBody = strBody.Replace("[WorkToBeCompletedBy]", "ACI");
            //            break;
            //        default:
            //            strBody = strBody.Replace("[WorkToBeCompletedBy]", string.Empty);
            //            break;
            //    }
            //}
            //else
            //{
            //    strBody = strBody.Replace("[WorkToBeCompletedBy]", string.Empty);
            //}

            //if (!DBNull.Value.Equals(dtManagementDetail.Rows[0]["Task_Complete"]))
            //{
            //    switch (Convert.ToBoolean(dtManagementDetail.Rows[0]["Task_Complete"]))
            //    {
            //        case false:
            //            strBody = strBody.Replace("[TaskComplete]", "NO");
            //            break;
            //        case true:
            //            strBody = strBody.Replace("[TaskComplete]", "YES");
            //            break;
            //        default:
            //            strBody = strBody.Replace("[TaskComplete]", string.Empty);
            //            break;
            //    }
            //}
            //else
            //{
            //    strBody = strBody.Replace("[TaskComplete]", string.Empty);
            //}
            strBody = strBody.Replace("[Status]", Convert.ToString(dtManagementDetail.Rows[0]["Maintenance_Status"]));
            if (dtManagementDetail.Rows[0]["No_Approval_Needed"] != DBNull.Value && Convert.ToBoolean(dtManagementDetail.Rows[0]["No_Approval_Needed"]))
            {
                strBody = strBody.Replace("<label id=\"lblOriginalService\" style=\"display:none\">", "<label id=\"lblOriginalService\">");
                strBody = strBody.Replace("<label id=\"lblOriginalServiceCol\" style=\"display:none\">", "<label id=\"lblOriginalServiceCol\">");
                strBody = strBody.Replace("<label id=\"lblOriginalServiceValue\" style=\"display:none\">[PreviousContractAmount]</label>", "<label id=\"lblOriginalServiceValue\">" + string.Format("{0:C2}", dtManagementDetail.Rows[0]["Previous_Contract_Amount"]) + "</label>");
                strBody = strBody.Replace("<tr class=\"trapproval\">", "<tr style=\"display:none\">");
            }

            if (dtManagementDetail.Rows[0]["Approval_Needed"] != DBNull.Value && Convert.ToBoolean(dtManagementDetail.Rows[0]["Approval_Needed"]))
            {
                strBody = strBody.Replace("<label id=\"lblRepairEstimate\" style=\"display:none\">", "<label id=\"lblRepairEstimate\">");
                strBody = strBody.Replace("<label id=\"lblRepairEstimateCol\" style=\"display:none\">", "<label id=\"lblRepairEstimateCol\">");
                strBody = strBody.Replace("<label id=\"lblRepairEstimateValue\" style=\"display:none\">[RevisedContractAmount]</label>", "<label id=\"lblRepairEstimateValue\">" + string.Format("{0:C2}", dtManagementDetail.Rows[0]["Revised_Contract_Amount"]) + "</label>");
            }

            strBody = strBody.Replace("[Service/RepairCost]", string.Format("{0:C2}", dtManagementDetail.Rows[0]["Service_Repair_Cost"]));
            strBody = strBody.Replace("[CRApproved]", clsGeneral.FormatDBNullDateToDisplay(dtManagementDetail.Rows[0]["CR_Approved"]));
            strBody = strBody.Replace("[RecordType]", Convert.ToString(dtManagementDetail.Rows[0]["RecordType"]));
            strBody = strBody.Replace("[Approval_Submission]", Convert.ToString(dtManagementDetail.Rows[0]["Approval_Submission"]));

            //strBody = strBody.Replace("[RecordTypeOther]", Convert.ToString(dtManagementDetail.Rows[0]["Record_Type_Other"]));
            strBody = strBody.Replace("[Job#]", Convert.ToString(dtManagementDetail.Rows[0]["Job"]));
            //strBody = strBody.Replace("[Order#]", Convert.ToString(dtManagementDetail.Rows[0]["Order"]));
            strBody = strBody.Replace("[OrderDate]", clsGeneral.FormatDBNullDateToDisplay(dtManagementDetail.Rows[0]["Order_Date"]));
            strBody = strBody.Replace("[RequestedBy]", Convert.ToString(dtManagementDetail.Rows[0]["Requested_By"]));
            strBody = strBody.Replace("[CreatedBy]", Convert.ToString(dtManagementDetail.Rows[0]["Created_By"]));
            strBody = strBody.Replace("[PreviousContractAmount]", string.Format("{0:C2}", dtManagementDetail.Rows[0]["Previous_Contract_Amount"]));
            strBody = strBody.Replace("[RevisedContractAmount]", string.Format("{0:C2}", dtManagementDetail.Rows[0]["Revised_Contract_Amount"]));
            strBody = strBody.Replace("[ReasonForRequest]", Convert.ToString(dtManagementDetail.Rows[0]["Reason_for_Request"]));
            strBody = strBody.Replace("[Recommendation]", Convert.ToString(dtManagementDetail.Rows[0]["Recommendation"]));
            strBody = strBody.Replace("[GM_EMailTo]", Convert.ToString(dtManagementDetail.Rows[0]["GM_Email_To"]));
            strBody = strBody.Replace("[GM_LastEMailDate]", clsGeneral.FormatDBNullDateToDisplay(dtManagementDetail.Rows[0]["GM_Last_Email_Date"]));

            if (!DBNull.Value.Equals(dtManagementDetail.Rows[0]["GM_Decision"]))
            {
                switch (Convert.ToBoolean(dtManagementDetail.Rows[0]["GM_Decision"]))
                {
                    case false:
                        strBody = strBody.Replace("[GM_Decision]", "Not Approved");
                        break;
                    case true:
                        strBody = strBody.Replace("[GM_Decision]", "Approved");
                        break;
                    default:
                        strBody = strBody.Replace("[GM_Decision]", string.Empty);
                        break;
                }
            }
            else
            {
                strBody = strBody.Replace("[GM_Decision]", string.Empty);
            }

            strBody = strBody.Replace("[GM_ResponseDate]", clsGeneral.FormatDBNullDateToDisplay(dtManagementDetail.Rows[0]["GM_Response_Date"]));

            strBody = strBody.Replace("[RLCM_EMailTo]", Convert.ToString(dtManagementDetail.Rows[0]["RLCM_Email_To"]));
            strBody = strBody.Replace("[RLCM_LastEMailDate]", clsGeneral.FormatDBNullDateToDisplay(dtManagementDetail.Rows[0]["RLCM_Last_Email_Date"]));

            if (!DBNull.Value.Equals(dtManagementDetail.Rows[0]["RLCM_Decision"]))
            {
                switch (Convert.ToBoolean(dtManagementDetail.Rows[0]["RLCM_Decision"]))
                {
                    case false:
                        strBody = strBody.Replace("[RLCM_Decision]", "Not Approved");
                        break;
                    case true:
                        strBody = strBody.Replace("[RLCM_Decision]", "Approved");
                        break;
                    default:
                        strBody = strBody.Replace("[RLCM_Decision]", string.Empty);
                        break;
                }
            }
            else
            {
                strBody = strBody.Replace("[RLCM_Decision]", string.Empty);
            }

            strBody = strBody.Replace("[RLCM_ResponseDate]", clsGeneral.FormatDBNullDateToDisplay(dtManagementDetail.Rows[0]["RLCM_Response_Date"]));

            strBody = strBody.Replace("[NAPM_EMailTo]", Convert.ToString(dtManagementDetail.Rows[0]["NAPM_Email_To"]));
            strBody = strBody.Replace("[NAPM_LastEMailDate]", clsGeneral.FormatDBNullDateToDisplay(dtManagementDetail.Rows[0]["NAPM_Last_Email_Date"]));

            if (!DBNull.Value.Equals(dtManagementDetail.Rows[0]["NAPM_Decision"]))
            {
                switch (Convert.ToBoolean(dtManagementDetail.Rows[0]["NAPM_Decision"]))
                {
                    case false:
                        strBody = strBody.Replace("[NAPM_Decision]", "Not Approved");
                        break;
                    case true:
                        strBody = strBody.Replace("[NAPM_Decision]", "Approved");
                        break;
                    default:
                        strBody = strBody.Replace("[NAPM_Decision]", string.Empty);
                        break;
                }
            }
            else
            {
                strBody = strBody.Replace("[NAPM_Decision]", string.Empty);
            }

            strBody = strBody.Replace("[NAPM_ResponseDate]", clsGeneral.FormatDBNullDateToDisplay(dtManagementDetail.Rows[0]["NAPM_Response_Date"]));

            strBody = strBody.Replace("[DRM_EMailTo]", Convert.ToString(dtManagementDetail.Rows[0]["DRM_Email_To"]));
            strBody = strBody.Replace("[DRM_LastEMailDate]", clsGeneral.FormatDBNullDateToDisplay(dtManagementDetail.Rows[0]["DRM_Last_Email_Date"]));

            if (!DBNull.Value.Equals(dtManagementDetail.Rows[0]["DRM_Decision"]))
            {
                switch (Convert.ToBoolean(dtManagementDetail.Rows[0]["DRM_Decision"]))
                {
                    case false:
                        strBody = strBody.Replace("[DRM_Decision]", "Not Approved");
                        break;
                    case true:
                        strBody = strBody.Replace("[DRM_Decision]", "Approved");
                        break;
                    default:
                        strBody = strBody.Replace("[DRM_Decision]", string.Empty);
                        break;
                }
            }
            else
            {
                strBody = strBody.Replace("[DRM_Decision]", string.Empty);
            }

            if (dtManagementDetail.Rows[0]["No_Approval_Needed"] != DBNull.Value)
            {
                switch (Convert.ToBoolean(dtManagementDetail.Rows[0]["No_Approval_Needed"]))
                {
                    case true:
                        strBody = strBody.Replace("[NoApprovalNeeded]", "&#9745;");
                        break;
                    case false:
                        strBody = strBody.Replace("[NoApprovalNeeded]", "&#9744;");
                        break;
                    default:
                        strBody = strBody.Replace("[NoApprovalNeeded]", "&#9744;");
                        break;
                }
            }
            else
            {
                strBody = strBody.Replace("[NoApprovalNeeded]", "&#9744;");
            }

            if (dtManagementDetail.Rows[0]["Approval_Needed"] != DBNull.Value)
            {
                switch (Convert.ToBoolean(dtManagementDetail.Rows[0]["Approval_Needed"]))
                {
                    case true:
                        strBody = strBody.Replace("[ApprovalNeeded]", "&#9745;");
                        break;
                    case false:
                        strBody = strBody.Replace("[ApprovalNeeded]", "&#9744;");
                        break;
                    default:
                        strBody = strBody.Replace("[ApprovalNeeded]", "&#9744;");
                        break;
                }
            }
            else
            {
                strBody = strBody.Replace("[ApprovalNeeded]", "&#9744;");
            }

            strBody = strBody.Replace("[DRM_ResponseDate]", clsGeneral.FormatDBNullDateToDisplay(dtManagementDetail.Rows[0]["DRM_Response_Date"]));
            strBody = strBody.Replace("[Comments]", Convert.ToString(dtManagementDetail.Rows[0]["Comment"]));

            strBody = strBody.Replace("[Management_Notes_Grid]", GetManagementNotesDetails(dtManagementNotes));

            #endregion

            #region "Store and ACI Contact Details"

            strBody = strBody.Replace("[StoreContactGrid]", GetStoreContactDetails(dtStoreContactDetails));
            strBody = strBody.Replace("[ACIContactGrid]", GetACIContactDetails(dtACIContactDetails));

            #endregion

            #region Project Cost Details

            strBody = strBody.Replace("[ProjectCostGrid]", GetProjectCostDetails(dtProjectCostDetails));
            strBody = strBody.Replace("[InvoiceGrid]", GetInvoiceDetails(dtInvoiceDetails));

            #endregion
        }

        return strBody;

    }

    public string GetStoreContactDetails(DataTable dtStoreContactDetails)
    {
        StringBuilder sbGrid = new StringBuilder(string.Empty);
        sbGrid = new StringBuilder(string.Empty);
        if (dtStoreContactDetails.Rows.Count > 0)
        {
            sbGrid.Append("<table width='100%'>");
            sbGrid.Append("<tr style='background-color: #7f7f7f; font-family: Arial; color: white; font-size: 12px; font-weight: bold' valign=top>");
            sbGrid.Append("<td  style='font-family: Arial; font-size: 12px;' align='left' width='25%'> First Name </td>");
            sbGrid.Append("<td  style='font-family: Arial; font-size: 12px;' align='left' width='25%'> Last Name </td>");
            sbGrid.Append("<td  style='font-family: Arial; font-size: 12px;' align='left' width='25%'> Phone </td>");
            sbGrid.Append("<td  style='font-family: Arial; font-size: 12px;' align='left' width='25%'> Email </td>");
            sbGrid.Append("</tr>");

            foreach (DataRow dr in dtStoreContactDetails.Rows)
            {
                sbGrid.Append("<tr valign=top>");
                sbGrid.AppendFormat("<td  style='font-family: Arial; font-size: 12px;' align='left' width='25%'>  {0} </td>", Convert.ToString(dr["First_Name"]));
                sbGrid.AppendFormat("<td  style='font-family: Arial; font-size: 12px;' align='left' width='25%'>  {0} </td>", Convert.ToString(dr["Last_name"]));
                sbGrid.AppendFormat("<td  style='font-family: Arial; font-size: 12px;' align='left' width='25%'>  {0} </td>", Convert.ToString(dr["Phone"]));
                sbGrid.AppendFormat("<td  style='font-family: Arial; font-size: 12px;' align='left' width='25%'>  {0} </td>", Convert.ToString(dr["Email"]));
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

    public string GetACIContactDetails(DataTable dtACIContactDetails)
    {
        StringBuilder sbGrid = new StringBuilder(string.Empty);
        sbGrid = new StringBuilder(string.Empty);
        if (dtACIContactDetails.Rows.Count > 0)
        {
            sbGrid.Append("<table width='100%'>");
            sbGrid.Append("<tr style='background-color: #7f7f7f; font-family: Arial; color: white; font-size: 12px; font-weight: bold' valign=top>");
            sbGrid.Append("<td  style='font-family: Arial; font-size: 12px;' align='left' width='25%'> First Name </td>");
            sbGrid.Append("<td  style='font-family: Arial; font-size: 12px;' align='left' width='25%'> Last Name </td>");
            sbGrid.Append("<td  style='font-family: Arial; font-size: 12px;' align='left' width='25%'> Phone </td>");
            sbGrid.Append("<td  style='font-family: Arial; font-size: 12px;' align='left' width='25%'> Email </td>");
            sbGrid.Append("</tr>");

            foreach (DataRow dr in dtACIContactDetails.Rows)
            {
                sbGrid.Append("<tr valign=top>");
                sbGrid.AppendFormat("<td  style='font-family: Arial; font-size: 12px;' align='left' width='25%'>  {0} </td>", Convert.ToString(dr["First_Name"]));
                sbGrid.AppendFormat("<td  style='font-family: Arial; font-size: 12px;' align='left' width='25%'>  {0} </td>", Convert.ToString(dr["Last_name"]));
                sbGrid.AppendFormat("<td  style='font-family: Arial; font-size: 12px;' align='left' width='25%'>  {0} </td>", Convert.ToString(dr["Phone"]));
                sbGrid.AppendFormat("<td  style='font-family: Arial; font-size: 12px;' align='left' width='25%'>  {0} </td>", Convert.ToString(dr["Email"]));
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

    public string GetProjectCostDetails(DataTable dtProjectCostDetails)
    {
        StringBuilder sbGrid = new StringBuilder(string.Empty);
        sbGrid = new StringBuilder(string.Empty);
        if (dtProjectCostDetails.Rows.Count > 0)
        {
            sbGrid.Append("<table width='100%'>");
            sbGrid.Append("<tr style='background-color: #7f7f7f; font-family: Arial; color: white; font-size: 12px; font-weight: bold' valign=top>");
            sbGrid.Append("<td  style='font-family: Arial; font-size: 12px; width:25%;' align='left'> Project Phase </td>");
            sbGrid.Append("<td  style='font-family: Arial; font-size: 12px; width:25%;' align='left'> Budget($) </td>");
            sbGrid.Append("<td  style='font-family: Arial; font-size: 12px; width:25%;' align='left'> Estimated Cost($) </td>");
            sbGrid.Append("<td  style='font-family: Arial; font-size: 12px; width:25%;' align='left'> Actual Cost($) </td>");
            sbGrid.Append("</tr>");

            foreach (DataRow dr in dtProjectCostDetails.Rows)
            {
                sbGrid.Append("<tr valign=top>");

                if (!DBNull.Value.Equals(dr["FK_LU_EPM_Project_Phase"]))
                {
                    switch (dr["FK_LU_EPM_Project_Phase"].ToString())
                    {
                        case "1":
                            sbGrid.AppendFormat("<td  style='font-family: Arial; font-size: 12px; width:25%;' align='left'>  Completed </td>");
                            break;
                        case "2":
                            sbGrid.AppendFormat("<td  style='font-family: Arial; font-size: 12px; width:25%;' align='left'>  Delayed </td>");
                            break;
                        case "3":
                            sbGrid.AppendFormat("<td  style='font-family: Arial; font-size: 12px; width:25%;' align='left'>  In Progress </td>");
                            break;
                        case "4":
                            sbGrid.AppendFormat("<td  style='font-family: Arial; font-size: 12px; width:25%;' align='left'>  Proposal </td>");
                            break;
                        default:
                            sbGrid.AppendFormat("<td  style='font-family: Arial; font-size: 12px; width:25%;' align='left'></td>");
                            break;
                    }
                }
                else
                {
                    sbGrid.AppendFormat("<td  style='font-family: Arial; font-size: 12px; width:25%;' align='left'></td>");
                }

                sbGrid.AppendFormat("<td  style='font-family: Arial; font-size: 12px; width:25%;' align='left'>  {0} </td>", string.Format("{0:C2}", dr["Budget"]));
                sbGrid.AppendFormat("<td  style='font-family: Arial; font-size: 12px; width:25%;' align='left'>  {0} </td>", string.Format("{0:C2}", dr["Estimated_Cost"]));
                sbGrid.AppendFormat("<td  style='font-family: Arial; font-size: 12px; width:25%;' align='left'>  {0} </td>", string.Format("{0:C2}", dr["Actual_Cost"]));
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

    public string GetInvoiceDetails(DataTable dtInvoiceDetails)
    {
        StringBuilder sbGrid = new StringBuilder(string.Empty);
        sbGrid = new StringBuilder(string.Empty);
        if (dtInvoiceDetails.Rows.Count > 0)
        {
            sbGrid.Append("<table width='100%'>");
            sbGrid.Append("<tr style='background-color: #7f7f7f; font-family: Arial; color: white; font-size: 12px; font-weight: bold' valign=top>");
            sbGrid.Append("<td  style='font-family: Arial; font-size: 12px; width:25%;' align='left'> Invoice Number </td>");
            sbGrid.Append("<td  style='font-family: Arial; font-size: 12px; width:25%;' align='left'> Invoice Date </td>");
            sbGrid.Append("<td  style='font-family: Arial; font-size: 12px; width:25%;' align='left'> Invoice Amount($) </td>");
            sbGrid.Append("<td  style='font-family: Arial; font-size: 12px; width:25%;' align='left'> Vendor </td>");
            sbGrid.Append("</tr>");

            foreach (DataRow dr in dtInvoiceDetails.Rows)
            {
                sbGrid.Append("<tr valign=top>");

                sbGrid.AppendFormat("<td  style='font-family: Arial; font-size: 12px; width:25%;' align='left'>  {0} </td>", Convert.ToString(dr["Invoice_Number"]));
                sbGrid.AppendFormat("<td  style='font-family: Arial; font-size: 12px; width:25%;' align='left'>  {0} </td>", clsGeneral.FormatDBNullDateToDisplay(dr["Invoice_Date"]));
                sbGrid.AppendFormat("<td  style='font-family: Arial; font-size: 12px; width:25%;' align='left'>  {0} </td>", string.Format("{0:C2}", dr["Invoice_Amount"]));
                sbGrid.AppendFormat("<td  style='font-family: Arial; font-size: 12px; width:25%;' align='left'>  {0} </td>", Convert.ToString(dr["Vendor"]));
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

    public static string GetManagementNotesDetails(DataTable dtManagementNote)
    {
        StringBuilder sbGrid = new StringBuilder(string.Empty);
        sbGrid = new StringBuilder(string.Empty);
        if (dtManagementNote.Rows.Count > 0)
        {
            sbGrid.Append("<table width='100%'>");
            sbGrid.Append("<tr style='background-color: #7f7f7f; font-family: Arial; color: white; font-size: 12px; font-weight: bold' valign=top>");
            sbGrid.Append("<td  style='font-family: Arial; font-size: 12px;' align='left'> Note Date </td>");
            sbGrid.Append("<td  style='font-family: Arial; font-size: 12px;' align='left'> User </td>");
            sbGrid.Append("<td  style='font-family: Arial; font-size: 12px;' align='left'> Notes </td>");
            sbGrid.Append("</tr>");

            foreach (DataRow dr in dtManagementNote.Rows)
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

    #endregion

    #region "Other Event"

    /// <summary>
    /// Click Save Button
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSave_Click(object sender, EventArgs e)
    {
        //ViewState.Remove("EmailAbsratact");

        SaveRecord();

        if (StrOperation.ToLower() == "add")
            SendAbstractViaEmailWhileInsert();

        //if (ViewState["EmailAbsratact"] != null)
        //{
        //    SendAbstractViaEmailWhileInsert();
        //}

        if (StrOperation.ToLower() == "add" || StrOperation.ToLower() == "addto" || StrOperation.ToLower() == "")
        {
            Response.Redirect("Management.aspx?id=" + Encryption.Encrypt(PK_Management.ToString()) + "&pnl=" + hdnPanel.Value + "&mode=edit", true);
        }
        else
        {
            Response.Redirect("Management.aspx?id=" + Encryption.Encrypt(PK_Management.ToString()) + "&pnl=" + hdnPanel.Value + "&mode=view", true);

        }
    }

    /// <summary>
    /// Edit 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnEdit_Click(object sender, EventArgs e)
    {
        Response.Redirect("Management.aspx?id=" + Encryption.Encrypt(PK_Management.ToString()) + "&pnl=" + hdnPanel.Value + "&mode=edit", true);
    }

    /// <summary>
    /// Click on Cancel Button
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("ManagementSearch.aspx?criteria=1", true);
    }

    /// <summary>
    /// Add new button link event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkAddStoreNew_Click(object sender, EventArgs e)
    {
        btnStoreAdd.Text = "Add";
        _PK_ID_Store = 0;
        trstoreGrid.Style.Add("display", "none");
        trstoreContact.Style.Add("display", "");
        lnkStoreCancel.Style.Add("display", "inline");
        txtStore_Contact_First_Name.Text = string.Empty;
        txtStore_Contact_Last_Name.Text = string.Empty;
        txtStore_Contact_Phone.Text = string.Empty;
        txtStore_Contact_Email.Text = string.Empty; ;
        ((ScriptManager)this.Master.FindControl("scMain")).SetFocus(txtStore_Contact_First_Name);
    }

    /// <summary>
    /// Cancel button click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkStoreCancel_Click(object sender, EventArgs e)
    {
        trstoreGrid.Style.Add("display", "");
        trstoreContact.Style.Add("display", "none");
        lnkStoreCancel.Style.Add("display", "none");
        txtStore_Contact_First_Name.Text = string.Empty;
        txtStore_Contact_Last_Name.Text = string.Empty;
        txtStore_Contact_Phone.Text = string.Empty;
        txtStore_Contact_Email.Text = string.Empty;
    }

    /// <summary>
    /// Add new button to save data
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnStoreAdd_Click(object sender, EventArgs e)
    {
        SaveRecord();

        clsManagement_Sonic_Contact objSonic_Contact = new clsManagement_Sonic_Contact();

        objSonic_Contact.PK_Management_Sonic_Contact = _PK_ID_Store;
        objSonic_Contact.FK_Management = PK_Management;
        objSonic_Contact.First_Name = txtStore_Contact_First_Name.Text.Trim();
        objSonic_Contact.Last_name = txtStore_Contact_Last_Name.Text.Trim();
        objSonic_Contact.Phone = txtStore_Contact_Phone.Text.Trim();
        objSonic_Contact.Email = txtStore_Contact_Email.Text.Trim();

        if (_PK_ID_Store > 0)
        {
            objSonic_Contact.Update();
        }
        else
        {
            objSonic_Contact.Insert();
        }

        //clear Control
        ClearStoreControls();
        //Bind Grid Function
        BindStoreGrid();
        BindACIGrid();
        //Cancel CLick
        lnkStoreCancel_Click(null, null);
    }


    /// <summary>
    /// Add new button link event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkAddACINew_Click(object sender, EventArgs e)
    {
        btnACIAdd.Text = "Add";
        _PK_ID_ACI = 0;
        trACIGrid.Style.Add("display", "none");
        trACIContact.Style.Add("display", "");
        lnkACICancel.Style.Add("display", "inline");
        txtAci_Contact_First_Name.Text = string.Empty;
        txtAci_Contact_Last_Name.Text = string.Empty;
        txtAci_Contact_Phone.Text = string.Empty;
        txtAci_Contact_Email.Text = string.Empty; ;
        ((ScriptManager)this.Master.FindControl("scMain")).SetFocus(txtAci_Contact_First_Name);
    }

    /// <summary>
    /// Cancel button click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkACICancel_Click(object sender, EventArgs e)
    {
        trACIGrid.Style.Add("display", "");
        trACIContact.Style.Add("display", "none");
        lnkACICancel.Style.Add("display", "none");
        txtAci_Contact_First_Name.Text = string.Empty;
        txtAci_Contact_Last_Name.Text = string.Empty;
        txtAci_Contact_Phone.Text = string.Empty;
        txtAci_Contact_Email.Text = string.Empty;
    }

    /// <summary>
    /// Add new button to save data
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnACIAdd_Click(object sender, EventArgs e)
    {
        SaveRecord();

        clsManagement_ACI_Contact objACI_Contact = new clsManagement_ACI_Contact();

        objACI_Contact.PK_Management_ACI_Contact = _PK_ID_ACI;
        objACI_Contact.FK_Management = PK_Management;
        objACI_Contact.First_Name = txtAci_Contact_First_Name.Text.Trim();
        objACI_Contact.Last_name = txtAci_Contact_Last_Name.Text.Trim();
        objACI_Contact.Phone = txtAci_Contact_Phone.Text.Trim();
        objACI_Contact.Email = txtAci_Contact_Email.Text.Trim();

        if (_PK_ID_ACI > 0)
        {
            objACI_Contact.Update();
        }
        else
        {
            objACI_Contact.Insert();
        }

        //clear Control
        ClearACIControls();
        //Bind Grid Function
        BindACIGrid();
        //Cancel CLick
        lnkACICancel_Click(null, null);
    }

    /// <summary>
    /// selected index change event of drpLocation
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    //protected void drpLocation_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    if (!string.IsNullOrEmpty(drpLocation.SelectedValue))
    //    {
    //        clsAci_Lu_Location lu = new clsAci_Lu_Location(Convert.ToDecimal(drpLocation.SelectedValue));
    //        txtLocation_Code.Text = Convert.ToString(lu.Fld_Code);
    //    }
    //}
    protected void drpLocation_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(drpLocation.SelectedValue) && drpLocation.SelectedIndex > 0)
        {
            LU_Location location = new LU_Location(Convert.ToDecimal(drpLocation.SelectedValue));

            if (location.Sonic_Location_Code != null)
            {
                txtLocation_Code.Text = Convert.ToString(location.Sonic_Location_Code);
            }
            else
            {
                txtLocation_Code.Text = string.Empty;
            }
        }
        else
        {
            txtLocation_Code.Text = string.Empty;
        }
    }

    /// <summary>
    /// Handles Checked Change of Include Companion Project checkbox as per strOperation
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void chkIncludeCompProject_OnCheckedChanged(object sender, EventArgs e)
    {
        //if (StrOperation.ToLower() != "view")
        //{
        //    if (chkIncludeCompProject.Checked == true)
        //    {
        //        DataTable dtGetCompanionProjectCost = clsEPM_Project_Cost.GetCompanionProjectCost(PK_EPM_Identification, LocationID).Tables[0];
        //        if (dtGetCompanionProjectCost != null && dtGetCompanionProjectCost.Rows.Count > 0)
        //        {
        //            gvProjectCost.DataSource = dtGetCompanionProjectCost;
        //            gvProjectCost.DataBind();
        //        }
        //        {
        //            gvProjectCostView.DataBind();
        //        }
        //        gvProjectCost.Columns[0].Visible = true;
        //        gvProjectCost.Columns[1].Visible = true;
        //    }
        //    else
        //    {
        //        DataTable dtProjectCost = clsEPM_Project_Cost.SelectByFK(PK_EPM_Identification).Tables[0];
        //        if (dtProjectCost != null && dtProjectCost.Rows.Count > 0)
        //        {
        //            gvProjectCost.DataSource = dtProjectCost;
        //            gvProjectCost.DataBind();
        //        }
        //        else
        //        {
        //            gvProjectCost.DataBind();
        //        }
        //        gvProjectCost.Columns[0].Visible = false;
        //        gvProjectCost.Columns[1].Visible = false;
        //    }
        //}
        //else
        //{
        //    if (chkIncludeCompProjectView.Checked == true)
        //    {
        //        DataTable dtGetCompanionProjectCost = clsEPM_Project_Cost.GetCompanionProjectCost(PK_EPM_Identification, LocationID).Tables[0];
        //        if (dtGetCompanionProjectCost != null && dtGetCompanionProjectCost.Rows.Count > 0)
        //        {
        //            gvProjectCostView.DataSource = dtGetCompanionProjectCost;
        //            gvProjectCostView.DataBind();
        //        }
        //        else
        //        {
        //            gvProjectCostView.DataBind();
        //        }
        //        gvProjectCostView.Columns[0].Visible = true;
        //        gvProjectCostView.Columns[1].Visible = true;
        //    }
        //    else
        //    {
        //        DataTable dtProjectCost = clsEPM_Project_Cost.SelectByFK(PK_EPM_Identification).Tables[0];
        //        if (dtProjectCost != null && dtProjectCost.Rows.Count > 0)
        //        {
        //            gvProjectCostView.DataSource = dtProjectCost;
        //            gvProjectCostView.DataBind();
        //        }
        //        else
        //        {
        //            gvProjectCostView.DataBind();
        //        }
        //        gvProjectCostView.Columns[0].Visible = false;
        //        gvProjectCostView.Columns[1].Visible = false;
        //    }
        //}
        ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(4);", true);
    }

    protected void lnkAddInvoice_Click(object sender, EventArgs e)
    {
        if (PK_Management > 0)
        {
            Response.Redirect("ACI_Management_ProjectCost_Invoice.aspx?id=" + Encryption.Encrypt(Convert.ToString(PK_Management)) + "&pnl=" + hdnPanel.Value + "&op=add", true);
        }
    }

    /// <summary>
    /// Add Management Notes Click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkAddManagementNotesNew_Click(object sender, EventArgs e)
    {

        _PK_Management_Notes = 0;
        trManagementNotesGrid.Style.Add("display", "none");
        trManagementNotes.Style.Add("display", "");
        btnManagementNotesCancel.Style.Add("display", "inline");
        btnManagementNotesAdd.Text = "Add";
        //txtACI_Notes_Date.Text = string.Empty;
        txtManagement_Notes.Text = string.Empty;
        drpFK_LU_Management_Task_Process.SelectedIndex = -1;

        string strCtrlsIDsManagement = "";
        string strMessagesManagement = "";

        //((ScriptManager)this.Master.FindControl("scMain")).SetFocus(txtACI_Notes_Date);
    }

    /// <summary>
    /// Save Management Notes
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnManagementNotesAdd_Click(object sender, EventArgs e)
    {
        SaveRecord();

        clsSonic_Management_Notes objManagement_Notes = new clsSonic_Management_Notes();

        objManagement_Notes.PK_Sonic_Management_Notes = _PK_Management_Notes;
        //objACI_Notes.Note_Date = clsGeneral.FormatNullDateToStore(txtACI_Notes_Date.Text);
        objManagement_Notes.Note = txtManagement_Notes.Text.Trim();
        objManagement_Notes.FK_Management = PK_Management;
        objManagement_Notes.Updated_by = Convert.ToDecimal(clsSession.UserID);
        if (drpFK_LU_Management_Task_Process.SelectedIndex > 0)
            objManagement_Notes.FK_LU_Management_Task_Process = Convert.ToDecimal(drpFK_LU_Management_Task_Process.SelectedValue);

        if (_PK_Management_Notes > 0)
        {
            objManagement_Notes.Update();
        }
        else
        {
            objManagement_Notes.Insert();
        }

        //clear Control
        ClearManagementNoteControls();
        //Bind Grid Function
        BindManagementNoteGrid(ctrlPageSonicNotes.CurrentPage, ctrlPageSonicNotes.PageSize);
        //Cancel CLick
        btnManagementNotesCancel_Click(null, null);
    }

    /// <summary>
    /// Cancel Sonic Notes link
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnManagementNotesCancel_Click(object sender, EventArgs e)
    {
        trManagementNotesGrid.Style.Add("display", "");
        trManagementNotes.Style.Add("display", "none");
        btnManagementNotesCancel.Style.Add("display", "none");
        //txtACI_Notes_Date.Text = string.Empty;
        txtManagement_Notes.Text = string.Empty;
    }

    /// <summary>
    /// Print ACI Notes
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnManagementPrint_Click(object sender, EventArgs e)
    {
        string strSelected = "";
        foreach (GridViewRow gRow in gvManagement_Notes.Rows)
        {
            if (((CheckBox)gRow.FindControl("chkSelectSonicACINotes")).Checked)
                strSelected = strSelected + ((HtmlInputHidden)gRow.FindControl("hdnPK_Sonic_Management_Notes")).Value + ",";
        }
        strSelected = strSelected.TrimEnd(',');
        clsPrintManagementNotes.PrintSelectedNotes(strSelected, PK_Management, "Management");
    }

    /// <summary>
    /// Print ACI Notes
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnManagementPrintView_Click(object sender, EventArgs e)
    {
        string strSelected = "";
        foreach (GridViewRow gRow in gvManagement_NotesView.Rows)
        {
            if (((CheckBox)gRow.FindControl("chkSelectSonicACINotesView")).Checked)
                strSelected = strSelected + ((HtmlInputHidden)gRow.FindControl("hdnPK_Sonic_Management_NotesView")).Value + ",";
        }
        strSelected = strSelected.TrimEnd(',');
        clsPrintManagementNotes.PrintSelectedNotes(strSelected, PK_Management, "Management");
    }

    /// <summary>
    /// Resend Management Abstract Click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnResendManagementAbstract_Click(object sender, EventArgs e)
    {
        if (StrOperation.ToLower() == "edit")
        {
            SaveRecord();
            SendAbstractViaEmailWhileInsert();
            Response.Redirect("Management.aspx?id=" + Encryption.Encrypt(PK_Management.ToString()) + "&pnl=" + hdnPanel.Value + "&mode=edit", true);
        }
        else
        {
            SendAbstractViaEmailWhileInsert();
        }
    }
    #endregion

    #region "Grid Event"

    /// <summary>
    /// Event for paging
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvStoreContact_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvStoreContact.PageIndex = e.NewPageIndex; //Page new index call
        BindStoreGrid();
    }

    /// <summary>
    /// Row command event for Edit and update
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvStoreContact_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "EditRecord")
        {
            _PK_ID_Store = Convert.ToDecimal(e.CommandArgument);
            // show and hide Add-edit row
            trstoreGrid.Style.Add("display", "none");
            trstoreContact.Style.Add("display", "");
            lnkStoreCancel.Style.Add("display", "inline");
            btnStoreAdd.Text = "Update";
            // get record from database

            clsManagement_Sonic_Contact objSonic_Contact = new clsManagement_Sonic_Contact(_PK_ID_Store);

            txtStore_Contact_First_Name.Text = Convert.ToString(objSonic_Contact.First_Name);
            txtStore_Contact_Last_Name.Text = Convert.ToString(objSonic_Contact.Last_name);
            txtStore_Contact_Phone.Text = Convert.ToString(objSonic_Contact.Phone);
            txtStore_Contact_Email.Text = Convert.ToString(objSonic_Contact.Email);

            ((ScriptManager)this.Master.FindControl("scMain")).SetFocus(txtStore_Contact_First_Name);
        }
        else if (e.CommandName == "DeleteRecord")
        {
            _PK_ID_Store = Convert.ToDecimal(e.CommandArgument);

            clsManagement_Sonic_Contact.DeleteByPK(_PK_ID_Store);
            BindStoreGrid();
        }
    }

    /// <summary>
    /// Handle Row Data Bound of Store Contact grid 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvStoreContact_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (StrOperation.ToLower() == "edit")
            {
                ((LinkButton)e.Row.Cells[0].FindControl("lnkEdit")).Visible = (App_Access == AccessType.Administrative_Access);//App_Access == AccessType.Edit ||
                ((LinkButton)e.Row.Cells[0].FindControl("lnkDelete")).Visible = (App_Access == AccessType.Delete || App_Access == AccessType.Administrative_Access);
            }
        }
    }

    /// <summary>
    /// Event for paging
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvACIContact_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvACIContact.PageIndex = e.NewPageIndex; //Page new index call
        BindACIGrid();
    }

    /// <summary>
    /// Paging event of gvManagement_Notes
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvManagement_Notes_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvManagement_Notes.PageIndex = e.NewPageIndex; //Page new index call
        BindManagementNoteGrid(ctrlPageSonicNotes.CurrentPage, ctrlPageSonicNotes.PageSize);
        Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(2);", true);
    }

    /// <summary>
    /// Row command event for Edit and update
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvACIContact_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "EditRecord")
        {
            _PK_ID_ACI = Convert.ToDecimal(e.CommandArgument);
            // show and hide Add-edit row
            trACIGrid.Style.Add("display", "none");
            trACIContact.Style.Add("display", "");
            lnkACICancel.Style.Add("display", "inline");
            btnACIAdd.Text = "Update";
            // get record from database

            clsManagement_ACI_Contact objACI_Contact = new clsManagement_ACI_Contact(_PK_ID_ACI);

            txtAci_Contact_First_Name.Text = Convert.ToString(objACI_Contact.First_Name);
            txtAci_Contact_Last_Name.Text = Convert.ToString(objACI_Contact.Last_name);
            txtAci_Contact_Phone.Text = Convert.ToString(objACI_Contact.Phone);
            txtAci_Contact_Email.Text = Convert.ToString(objACI_Contact.Email);

            ((ScriptManager)this.Master.FindControl("scMain")).SetFocus(txtAci_Contact_First_Name);
        }
        else if (e.CommandName == "DeleteRecord")
        {
            _PK_ID_ACI = Convert.ToDecimal(e.CommandArgument);

            clsManagement_ACI_Contact.DeleteByPK(_PK_ID_ACI);
            BindACIGrid();
        }
    }

    /// <summary>
    /// Handle Row Data Bound of Store Contact grid 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvACIContact_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (StrOperation.ToLower() == "edit")
            {
                ((LinkButton)e.Row.Cells[0].FindControl("lnkEdit")).Visible = (App_Access == AccessType.Administrative_Access);//App_Access == AccessType.Edit ||
                ((LinkButton)e.Row.Cells[0].FindControl("lnkDelete")).Visible = (App_Access == AccessType.Delete || App_Access == AccessType.Administrative_Access);
            }
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
                decimal Pk_EPM_Project_Cost = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "FK_Management"));
                if (Pk_EPM_Project_Cost == PK_Management)
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
    ///  handles Row Command Event foe Project Cost Grid as per strOperation
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvProjectCost_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "EditProjectCost")
        {
            string[] arg = new string[2];
            arg = e.CommandArgument.ToString().Split(';');
            decimal decPK_ACIManagement_ProjectCost, decFK_Management = 0;
            decPK_ACIManagement_ProjectCost = Convert.ToDecimal(arg[0]);
            decFK_Management = Convert.ToDecimal(arg[1]);
            //if (StrOperation.ToLower() != "view")
            //{
            //    Response.Redirect("ACI_Management_Project_Cost.aspx?id=" + Encryption.Encrypt(decFK_Management.ToString()) + "&PCI=" + Encryption.Encrypt(decPK_ACIManagement_ProjectCost.ToString()) + "&pnl=" + hdnPanel.Value + "&op=edit", true);
            //}
            //else
            Response.Redirect("ACI_Management_Project_Cost.aspx?id=" + Encryption.Encrypt(decFK_Management.ToString()) + "&PCI=" + Encryption.Encrypt(decPK_ACIManagement_ProjectCost.ToString()) + "&pnl=" + hdnPanel.Value + "&op=" + StrOperation, true);
        }
        if (e.CommandName == "RemoveProjectCost")
        {
            clsACIManagement_ProjectCost.DeleteByPK(Convert.ToDecimal(e.CommandArgument));
            BindProjectCostGrid();
            //chkIncludeCompProject.Checked = false;
            ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(" + hdnPanel.Value + ");", true);
        }
    }
    /// <summary>
    /// Handles Click Event for Add a new Project cost And redirects to Project Cost page
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkAddProjectCost_Click(object sender, EventArgs e)
    {
        decimal PK_ACIManagement_ProjectCost = 0;
        if (PK_Management > 0)
        {
            Response.Redirect("ACI_Management_Project_Cost.aspx?id=" + Encryption.Encrypt(PK_Management.ToString()) + "&PCI=" + Encryption.Encrypt(PK_ACIManagement_ProjectCost.ToString()) + "&pnl=" + hdnPanel.Value + "&op=add", true);
        }

    }

    protected void gvInvoice_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "EditRecord")
        {
            Response.Redirect("ACI_Management_ProjectCost_Invoice.aspx?id=" + Encryption.Encrypt(PK_Management.ToString()) + "&PCInvoice=" + Encryption.Encrypt(e.CommandArgument.ToString()) + "&pnl=" + hdnPanel.Value + "&op=" + StrOperation, true);
        }
        else if (e.CommandName == "Remove")
        {
            clsACIManagement_ProjectCost_Invoice.DeleteByPK(Convert.ToDecimal(e.CommandArgument));
            BindInvoiceGrid();
            ScriptManager.RegisterStartupScript(this, this.GetType(), System.DateTime.Now.ToString(), "javascrip:ShowPanel(" + hdnPanel.Value + ");", true);
        }
    }

    /// <summary>
    /// GridView Sorting Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvManagement_Notes_Sorting(object sender, GridViewSortEventArgs e)
    {
        // update sort field and sort order and bind the grid
        SortOrder = (SortBy == e.SortExpression) ? (SortOrder == "asc" ? "desc" : "asc") : "asc";
        SortBy = e.SortExpression;
        BindManagementNoteGrid(ctrlPageSonicNotes.CurrentPage, ctrlPageSonicNotes.PageSize);
    }

    protected void gvManagement_Notes_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (StrOperation == "view")
            {
                ((LinkButton)e.Row.Cells[0].FindControl("lnkRemove")).Visible = false;
                ((LinkButton)e.Row.Cells[0].FindControl("lnkEdit")).Visible = false;
            }
            else
            {
                ((LinkButton)e.Row.Cells[0].FindControl("lnkRemove")).Visible = true;
                ((LinkButton)e.Row.Cells[0].FindControl("lnkEdit")).Visible = true;
            }
        }
    }


    /// <summary>
    /// gvMaangement_Notes on Edit Or Delete
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvManagement_Notes_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "RemoveManagementNote")
        {
            #region
            clsSonic_Management_Notes.DeleteByPK(Convert.ToDecimal(e.CommandArgument));

            BindManagementNoteGrid(ctrlPageSonicNotes.CurrentPage, ctrlPageSonicNotes.PageSize);
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(2);", true);
            #endregion
        }
        else if (e.CommandName == "ViewNote")
        {
            Page.ClientScript.RegisterStartupScript(typeof(string), DateTime.Now.ToString(), "javascript:AciNotePopup('" + Encryption.Encrypt(e.CommandArgument.ToString()) + "','" + Encryption.Encrypt(PK_Management.ToString()) + "','0','" + StrOperation + "','Management');", true);
        }
        else if (e.CommandName == "EditRecord")
        {
            _PK_Management_Notes = Convert.ToDecimal(e.CommandArgument);
            // show and hide Add-edit row
            trManagementNotesGrid.Style.Add("display", "none");
            trManagementNotes.Style.Add("display", "");
            btnManagementNotesCancel.Style.Add("display", "inline");
            btnManagementNotesAdd.Text = "Update";
            // get record from database

            clsSonic_Management_Notes objACI_Management_Notes = new clsSonic_Management_Notes(_PK_Management_Notes);

            //txtACI_Notes_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objACI_Event_Notes.Note_Date);
            txtManagement_Notes.Text = Convert.ToString(objACI_Management_Notes.Note);
            clsGeneral.SetDropdownValue(drpFK_LU_Management_Task_Process, objACI_Management_Notes.FK_LU_Management_Task_Process, true);
            //((ScriptManager)this.Master.FindControl("scMain")).SetFocus(txtSonic_Notes);
        }
    }

    /// <summary>
    /// gvMaangement_Notes on Edit Or Delete
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvManagement_NotesView_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "ViewNote")
        {
            Page.ClientScript.RegisterStartupScript(typeof(string), DateTime.Now.ToString(), "javascript:AciNotePopup('" + Encryption.Encrypt(e.CommandArgument.ToString()) + "','" + Encryption.Encrypt(PK_Management.ToString()) + "','0','" + StrOperation + "','Management');", true);
        }
    }

    /// <summary>
    /// GridView Sorting Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvManagement_NotesView_Sorting(object sender, GridViewSortEventArgs e)
    {
        // update sort field and sort order and bind the grid
        SortOrder = (SortBy == e.SortExpression) ? (SortOrder == "asc" ? "desc" : "asc") : "asc";
        SortBy = e.SortExpression;
        BindManagementNoteGridView(ctrlPageSonicNotes.CurrentPage, ctrlPageSonicNotes.PageSize);
    }

    /// <summary>
    /// Paging event of gvManagement_Notes
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvManagement_NotesView_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvManagement_NotesView.PageIndex = e.NewPageIndex; //Page new index call
        BindManagementNoteGridView(ctrlPageSonicNotes.CurrentPage, ctrlPageSonicNotes.PageSize);
        Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(2);", true);
    }
    #endregion

    #region Dynamic Validations 
    /// <summary>
    /// Set all Validations-Claim Information
    /// </summary>
    private void SetValidationsManagement()
    {
        string strCtrlsIDsManagement = "";
        string strMessagesManagement = "";

        string strCtrlsIDsStoreContact = "";
        string strMessagesStoreContact = "";

        string strCtrlsIDsACIContact = "";
        string strMessagesACIContact = "";

        #region " Fetch Management Required fields and set its validation messages "
        DataTable dtFields = clsScreen_Validators.SelectByScreen(clsScreen.ScreenSelectByName("Management")).Tables[0];
        dtFields.DefaultView.RowFilter = "IsRequired = '1'";
        dtFields = dtFields.DefaultView.ToTable();

        MenuAsterisk1.Style["display"] = (dtFields.Select("LeftMenuIndex = 1").Length > 0) ? "inline-block" : "none";

        foreach (DataRow drField in dtFields.Rows)
        {
            #region " set validation control IDs and messages "
            switch (Convert.ToString(drField["Field_Name"]))
            {
                case "DBA": strCtrlsIDsManagement += drpLocation.ClientID + ","; strMessagesManagement += "Please select [Management]/DBA" + ","; Span1.Style["display"] = "inline-block"; break;
                case "Date Scheduled": strCtrlsIDsManagement += txtdate_Scheduled.ClientID + ","; strMessagesManagement += "Please enter [Management]/Date Scheduled" + ","; Span2.Style["display"] = "inline-block"; break;
                case "Date Completed": strCtrlsIDsManagement += txtdate_Scheduled.ClientID + ","; strMessagesManagement += "Please enter [Management]/Date Completed" + ","; Span3.Style["display"] = "inline-block"; break;
                case "Work To Be Completed": strCtrlsIDsManagement += drpFK_Work_Completed.ClientID + ","; strMessagesManagement += "Please select [Management]/Work To Be Completed" + ","; Span4.Style["display"] = "inline-block"; break;
                case "Other": strCtrlsIDsManagement += txtWork_To_Complete_Other.ClientID + ","; strMessagesManagement += "Please enter [Management]/Other" + ","; Span5.Style["display"] = "inline-block"; break;
                case "Work To Be Completed By": strCtrlsIDsManagement += drpFK_Work_To_Be_Completed_By.ClientID + ","; strMessagesManagement += "Please select [Management]/Work To Be Completed By" + ","; Span6.Style["display"] = "inline-block"; break;
                case "Status": strCtrlsIDsManagement += drpMaintenanceStatus.ClientID + ","; strMessagesManagement += "Please select [Management]/Status" + ","; Span7.Style["display"] = "inline-block"; break;
                case "Record Type": strCtrlsIDsManagement += drpFK_Record_Type.ClientID + ","; strMessagesManagement += "Please select [Management]/Record Type" + ","; Span10.Style["display"] = "inline-block"; break;
                case "CR Approved": strCtrlsIDsManagement += txtCR_Approved.ClientID + ","; strMessagesManagement += "Please enter [Management]/CR Approved" + ","; Span11.Style["display"] = "inline-block"; break;
                case "Job": strCtrlsIDsManagement += txtJob.ClientID + ","; strMessagesManagement += "Please enter [Management]/Job" + ","; Span12.Style["display"] = "inline-block"; break;
                case "Order Date": strCtrlsIDsManagement += txtOrderDate.ClientID + ","; strMessagesManagement += "Please enter [Management]/Order Date" + ","; Span13.Style["display"] = "inline-block"; break;
                case "Requested By": strCtrlsIDsManagement += txtRequestedBy.ClientID + ","; strMessagesManagement += "Please enter [Management]/Requested By" + ","; Span14.Style["display"] = "inline-block"; break;
                case "Created By": strCtrlsIDsManagement += txtCreatedBy.ClientID + ","; strMessagesManagement += "Please enter [Management]/Created By" + ","; Span15.Style["display"] = "inline-block"; break;
                case "Reason for Request": strCtrlsIDsManagement += ctrlReason_Request.ClientID + ","; strMessagesManagement += "Please enter [Management]/Reason for Request" + ","; Span16.Style["display"] = "inline-block"; break;
                case "Recommendation": strCtrlsIDsManagement += ctrlRecommendation.ClientID + ","; strMessagesManagement += "Please enter [Management]/Recommendation" + ","; Span17.Style["display"] = "inline-block"; break;

                case "Store Contact First Name": strCtrlsIDsStoreContact += txtStore_Contact_First_Name.ClientID + ","; strMessagesStoreContact += "Please enter [Management]/Store Contact First Name" + ","; Span18.Style["display"] = "inline-block"; break;
                case "Store Contact Last Name": strCtrlsIDsStoreContact += txtStore_Contact_Last_Name.ClientID + ","; strMessagesStoreContact += "Please enter [Management]/Store Contact Last Name" + ","; Span19.Style["display"] = "inline-block"; break;
                case "Store Contact Phone": strCtrlsIDsStoreContact += txtStore_Contact_Phone.ClientID + ","; strMessagesStoreContact += "Please enter [Management]/Store Contact Phone" + ","; Span20.Style["display"] = "inline-block"; break;
                case "Store Contact Email": strCtrlsIDsStoreContact += txtStore_Contact_Email.ClientID + ","; strMessagesStoreContact += "Please enter [Management]/Store Contact Email" + ","; Span21.Style["display"] = "inline-block"; break;

                case "ACI Contact First Name": strCtrlsIDsACIContact += txtAci_Contact_First_Name.ClientID + ","; strMessagesACIContact += "Please enter [Management]/ACI Contact First Name" + ","; Span22.Style["display"] = "inline-block"; break;
                case "ACI Contact Last Name": strCtrlsIDsACIContact += txtAci_Contact_Last_Name.ClientID + ","; strMessagesACIContact += "Please enter [Management]/ACI Contact Last Name" + ","; Span23.Style["display"] = "inline-block"; break;
                case "ACI Contact Phone": strCtrlsIDsACIContact += txtAci_Contact_Phone.ClientID + ","; strMessagesACIContact += "Please enter [Management]/ACI Contact Phone" + ","; Span24.Style["display"] = "inline-block"; break;
                case "ACI Contact Email": strCtrlsIDsACIContact += txtAci_Contact_Email.ClientID + ","; strMessagesACIContact += "Please enter [Management]/ACI Contact Email" + ","; Span25.Style["display"] = "inline-block"; break;
                default: break;
            }
            #endregion
        }

        #endregion

        strCtrlsIDsManagement = strCtrlsIDsManagement.TrimEnd(',');
        strMessagesManagement = strMessagesManagement.TrimEnd(',');

        strCtrlsIDsStoreContact = strCtrlsIDsStoreContact.TrimEnd(',');
        strMessagesStoreContact = strMessagesStoreContact.TrimEnd(',');

        strCtrlsIDsACIContact = strCtrlsIDsACIContact.TrimEnd(',');
        strMessagesACIContact = strMessagesACIContact.TrimEnd(',');

        hdnControlIDsManagement.Value = strCtrlsIDsManagement;
        hdnErrorMsgsManagement.Value = strMessagesManagement;

        hdnControlIDsACIContact.Value = strCtrlsIDsACIContact;
        hdnErrorMsgsACIContact.Value = strMessagesACIContact;

        hdnControlIDsStoreContact.Value = strCtrlsIDsStoreContact;
        hdnErrorMsgsStoreContact.Value = strMessagesStoreContact;
    }

    #endregion

    protected void chkNoApprovalNeeded_CheckedChanged(object sender, EventArgs e)
    {
        showHideOriginalService(chkNoApprovalNeeded.Checked);
        if (chkApprovalNeeded.Checked)
            trApprovals.Style.Add("display", "block");
        else
            trApprovals.Style.Add("display", "none");
    }



    protected void chkApprovalNeeded_CheckedChanged(object sender, EventArgs e)
    {
        showHideRepairEstimate(chkApprovalNeeded.Checked);
        hdnApprovalSubmission.Value = "0";
        drpFK_LU_Approval_Submission.SelectedValue = "0";

        if (chkApprovalNeeded.Checked)
        {
            trApprovals.Style.Add("display", "block");
        }
        else
        {
            trApprovals.Style.Add("display", "none");
        }

        //if (chkApprovalNeeded.Checked && !chkNoApprovalNeeded.Checked)
        //    trApprovals.Style.Add("display", "none");
    }

    protected void drpFK_Work_Completed_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (drpFK_Work_Completed.SelectedIndex > 0 && drpFK_Work_Completed.SelectedItem.Text.IndexOf("Add New Equipment") > -1)
        {
            chkApprovalNeeded.Checked = true;
            chkApprovalNeeded_CheckedChanged(null, null);
            trRPMApproval.Style.Add("display", "");
            clsGeneral.SetDropdownValue(drpFK_LU_Approval_Submission, "Yes", false);
        }
        else
        {
            trRPMApproval.Style.Add("display", "none");
            clsGeneral.SetDropdownValue(drpFK_LU_Approval_Submission, "No", false);
        }
    }

    private void showHideRepairEstimate(bool isVisible)
    {
        if (isVisible)
        {
            chkNoApprovalNeeded.Enabled = false;
            //chkNoApprovalNeeded.Checked = false;
            txtRevisedContractAmount.Visible = true;
            rfvRevisedContractAmount.Enabled = true;
            spRepairEstimate.Style.Add("display", "inline-block");
            lblRepairEstimate.Style.Add("display", "inline-block");
            lblRepairEstimateCol.Style.Add("display", "inline-block");
            lblRepairEstimateDollar.Style.Add("display", "inline-block");
            //showHideOriginalService(false);
        }
        else
        {
            chkNoApprovalNeeded.Enabled = true;
            txtRevisedContractAmount.Visible = false;
            rfvRevisedContractAmount.Enabled = false;
            txtRevisedContractAmount.Text = string.Empty;
            spRepairEstimate.Style.Add("display", "none");
            lblRepairEstimate.Style.Add("display", "none");
            lblRepairEstimateCol.Style.Add("display", "none");
            lblRepairEstimateDollar.Style.Add("display", "none");
        }
    }

    private void showHideOriginalService(bool isVisible)
    {
        if (isVisible)
        {
            trApprovals.Style.Add("display", "none");
            txtPreviousContractAmount.Visible = true;
            rfvPreviousContractAmount.Enabled = true;
            lblOriginalService.Style.Add("display", "inline-block");
            lblOriginalServiceCol.Style.Add("display", "inline-block");
            lblOriginalServiceDollar.Style.Add("display", "inline-block");
            spOriginalService.Style.Add("display", "inline-block");
        }
        else
        {
            trApprovals.Style.Add("display", "block");
            txtPreviousContractAmount.Visible = false;
            rfvPreviousContractAmount.Enabled = false;
            txtPreviousContractAmount.Text = string.Empty;
            spOriginalService.Style.Add("display", "none");
            lblOriginalService.Style.Add("display", "none");
            lblOriginalServiceCol.Style.Add("display", "none");
            lblOriginalServiceDollar.Style.Add("display", "none");
        }
    }

}