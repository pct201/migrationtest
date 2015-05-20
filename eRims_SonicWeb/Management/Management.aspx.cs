using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERIMS.DAL;


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
            }
            if (PK_Management > 0)
            {

                if (StrOperation.ToLower() == "view" || App_Access == AccessType.View_Only)
                {
                    BindDetailsForView();
                    ucAttachmentView.FK_Table = PK_Management;
                }
                else if (StrOperation.ToLower() == "edit")
                {
                    BindDropDown();
                    BindDetailsForEdit();
                    ucAttachment.FK_Table = PK_Management;
                    ucAttachment.ReadOnly = false;
                }
                BindStoreGrid();
                BindACIGrid();
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
        
        //ComboHelper.FillLU_Region(new DropDownList[] { drpRegion }, true);
        //ComboHelper.FillState(new DropDownList[] { drpState }, true);
        //ComboHelper.FillLU_Camera_Type(new DropDownList[] { drpCameraType }, true);
    }

    /// <summary>
    /// Save Record into Management Table
    /// </summary>
    private void SaveRecord()
    {
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

        if (!string.IsNullOrEmpty(Convert.ToString(rblTask_Complete.SelectedValue)))
            objRecord.Task_Complete = Convert.ToBoolean(Convert.ToInt32(rblTask_Complete.SelectedValue));
        else
            objRecord.Task_Complete = null;


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

        objRecord.Work_To_Complete_Other = txtWork_To_Complete_Other.Text;

        if (!string.IsNullOrEmpty(Convert.ToString(rdoWork_Completed_By.SelectedValue)))
            objRecord.Work_Completed_By = Convert.ToBoolean(Convert.ToInt32(rdoWork_Completed_By.SelectedValue));
        else
            objRecord.Work_Completed_By = null;

        objRecord.Service_Repair_Cost = clsGeneral.GetDecimalNullableValue(txtService_Repair_Cost);
        objRecord.Record_Type_Other = txtRecord_Type_Other.Text;
        objRecord.Job = txtJob.Text;
        objRecord.Order = txtOrder.Text;
        objRecord.Order_Date = clsGeneral.FormatNullDateToStore(txtOrderDate.Text);
        objRecord.Requested_By = txtRequestedBy.Text;
        objRecord.Created_By = txtCreatedBy.Text;

        objRecord.Previous_Contract_Amount = clsGeneral.GetDecimalNullableValue(txtPreviousContractAmount);
        objRecord.Revised_Contract_Amount = clsGeneral.GetDecimalNullableValue(txtRevisedContractAmount);

        if (drpFK_Work_Completed.SelectedIndex > 0)
            objRecord.FK_LU_Work_Completed = Convert.ToDecimal(drpFK_Work_Completed.SelectedValue);
        else
            objRecord.FK_LU_Work_Completed = null;

        //**************Approval Screen Fields starts********************//
        objRecord.GM_Email_To = txtGM_Email_To.Text;
        objRecord.GM_Last_Email_Date = clsGeneral.FormatDateToStore(txtGM_Last_Email_Date);
        objRecord.GM_Response_Date = clsGeneral.FormatDateToStore(txtGM_Response_Date);
        if (rdoGM_Decision.SelectedValue == "1")
            objRecord.GM_Decision = true;
        else if (rdoGM_Decision.SelectedValue == "0")
            objRecord.GM_Decision = false;
        else
            objRecord.GM_Decision = null;
        
        objRecord.RLCM_Email_To = txtRLCM_Email_To.Text;
        objRecord.RLCM_Last_Email_Date = clsGeneral.FormatDateToStore(txtRLCM_Last_Email_Date);
        objRecord.RLCM_Response_Date = clsGeneral.FormatDateToStore(txtRLCM_Response_Date);
        if (rdoRLCM_Decision.SelectedValue == "1")
            objRecord.RLCM_Decision = true;
        else if (rdoRLCM_Decision.SelectedValue == "0")
            objRecord.RLCM_Decision = false;
        else
            objRecord.RLCM_Decision = null;

        objRecord.NAPM_Email_To = txtNAPM_Email_To.Text;
        objRecord.NAPM_Last_Email_Date = clsGeneral.FormatDateToStore(txtNAPM_Last_Email_Date);
        objRecord.NAPM_Response_Date = clsGeneral.FormatDateToStore(txtNAPM_Response_Date);
        if (rdoNAPM_Decision.SelectedValue == "1")
            objRecord.NAPM_Decision = true;
        else if (rdoNAPM_Decision.SelectedValue == "0")
            objRecord.NAPM_Decision = false;
        else
            objRecord.NAPM_Decision = null;

        objRecord.DRM_Email_To = txtDRM_Email_To.Text;
        objRecord.DRM_Last_Email_Date = clsGeneral.FormatDateToStore(txtDRM_Last_Email_Date);
        objRecord.DRM_Response_Date = clsGeneral.FormatDateToStore(txtDRM_Response_Date);
        if (rdoDRM_Decision.SelectedValue == "1")
            objRecord.DRM_Decision = true;
        else if (rdoDRM_Decision.SelectedValue == "0")
            objRecord.DRM_Decision = false;
        else
            objRecord.DRM_Decision = null;

        objRecord.Comment = txtComments.Text;
        //**************Approval Screen Fields Ends********************//

        objRecord.Update_Date = DateTime.Now;
        objRecord.Updated_By = clsSession.UserID;

        if (PK_Management > 0)
            objRecord.Update();
        else
            PK_Management = objRecord.Insert();
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

            //txtCompany.Text = objRecord.Company != null ? objRecord.Company : "";
            //txtCompany_Phone.Text = objRecord.Company_Phone != null ? objRecord.Company_Phone : "";
            //txtCity.Text = objRecord.City != null ? objRecord.City : "";
            //txtCounty.Text = objRecord.County != null ? objRecord.County : "";
            //txtCameraNumber.Text = objRecord.Camera_Number != null ? objRecord.Camera_Number : "";
            //txtCost.Text = objRecord.Cost != null ? Convert.ToString(objRecord.Cost) : "";
            //ctrlCameraConcern.Text = objRecord.Camera_Concern != null ? Convert.ToString(objRecord.Camera_Concern) : "";
            ctrlRecommendation.Text = objRecord.Recommendation != null ? Convert.ToString(objRecord.Recommendation) : "";


            if (!string.IsNullOrEmpty(Convert.ToString(objRecord.Task_Complete)))
                rblTask_Complete.SelectedValue = Convert.ToString(Convert.ToDecimal(objRecord.Task_Complete));
            else
                rblTask_Complete.ClearSelection();

            //if (objRecord.FK_LU_Location != null) drpLocation.SelectedValue = Convert.ToString(objRecord.FK_LU_Location);
            clsGeneral.SetDropdownValue(drpLocation, objRecord.FK_LU_Location, true);
            //if (objRecord.FK_LU_State != null) drpState.SelectedValue = Convert.ToString(objRecord.FK_LU_State);
            //if (objRecord.FK_LU_Region != null) drpRegion.SelectedValue = Convert.ToString(objRecord.FK_LU_Region);
            //if (objRecord.FK_LU_Camera_Type != null) drpCameraType.SelectedValue = Convert.ToString(objRecord.FK_LU_Camera_Type);
            //if (objRecord.FK_LU_Client_Issue != null) drpClientIssue.SelectedValue = Convert.ToString(objRecord.FK_LU_Client_Issue);
            //if (objRecord.FK_LU_Facilities_Issue != null) drpFacilitiesIssue.SelectedValue = Convert.ToString(objRecord.FK_LU_Facilities_Issue);

            clsGeneral.SetDropdownValue(drpFK_Record_Type, objRecord.FK_LU_Record_Type, true);

            txtWork_To_Complete_Other.Text = objRecord.Work_To_Complete_Other;

            if (!string.IsNullOrEmpty(Convert.ToString(objRecord.Work_Completed_By)))
                rdoWork_Completed_By.SelectedValue = Convert.ToString(Convert.ToDecimal(objRecord.Work_Completed_By));
            else
                rdoWork_Completed_By.ClearSelection();

            txtService_Repair_Cost.Text = clsGeneral.GetStringValue(objRecord.Service_Repair_Cost);
            txtRecord_Type_Other.Text = objRecord.Record_Type_Other;
            txtJob.Text = objRecord.Job;
            txtOrder.Text = objRecord.Order;
            txtOrderDate.Text = clsGeneral.FormatDBNullDateToDisplay(objRecord.Order_Date);
            txtRequestedBy.Text = objRecord.Requested_By;
            txtCreatedBy.Text = objRecord.Created_By;

            txtPreviousContractAmount.Text = clsGeneral.GetStringValue(objRecord.Previous_Contract_Amount );
            txtRevisedContractAmount.Text =  clsGeneral.GetStringValue(objRecord.Revised_Contract_Amount);
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
            txtDRM_Response_Date .Text = clsGeneral.FormatDBNullDateToDisplay(objRecord.DRM_Response_Date);
            if (!string.IsNullOrEmpty(Convert.ToString(objRecord.DRM_Decision)))
                rdoDRM_Decision.SelectedValue = Convert.ToString(Convert.ToDecimal(objRecord.DRM_Decision));
            else
                rdoDRM_Decision.ClearSelection();

            txtComments.Text = Convert.ToString(objRecord.Comment);
            //********************* Approval screen end**********************//

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

            //if (objRecord.FK_LU_State != null)
            //    lblState.Text = new LU_State((decimal)objRecord.FK_LU_State).Fld_Desc;
            //else
            //    lblState.Text = "";

            //if (objRecord.FK_LU_Region != null)
            //    lblRegion.Text = new LU_Region((decimal)objRecord.FK_LU_Region).Fld_Desc;
            //else
            //    lblRegion.Text = "";

            switch (objRecord.Task_Complete)
            {
                case true:
                    lblTask_Complete.Text = "Yes";
                    break;
                case false:
                    lblTask_Complete.Text = "No";
                    break;
                default:
                    lblTask_Complete.Text = "";
                    break;
            }

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

            if (objRecord.Work_To_Complete_Other != null)
                lblWork_To_Complete_Other.Text = objRecord.Work_To_Complete_Other;
            else
                lblWork_To_Complete_Other.Text = string.Empty;

            switch (objRecord.Work_Completed_By)
            {
                case true:
                    lblrdoWork_Completed_By.Text = "ACI";
                    break;
                case false:
                    lblrdoWork_Completed_By.Text = "Sonic";
                    break;
                default:
                    lblrdoWork_Completed_By.Text = "";
                    break;
            }

            lblService_Repair_Cost.Text = clsGeneral.GetStringValue(objRecord.Service_Repair_Cost);
            lblRecord_Type_Other.Text = objRecord.Record_Type_Other;
            lblJob.Text = objRecord.Job;
            lblOrder.Text = objRecord.Order;
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
            //********************* Approval screen end**********************//
        }

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

    #endregion

    #region "Other Event"

    /// <summary>
    /// Click Save Button
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSave_Click(object sender, EventArgs e)
    {
        SaveRecord();

        if (StrOperation.ToLower() == "add" || StrOperation.ToLower() == "addto" || StrOperation.ToLower() == "")
        {
            Response.Redirect("Management.aspx?id=" + Encryption.Encrypt(PK_Management.ToString()) + "&pnl=" + hdnPanel.Value +"&mode=edit"  , true);
        }
        else
        {
            Response.Redirect("Management.aspx?id=" + Encryption.Encrypt(PK_Management.ToString()) + "&pnl=" + hdnPanel.Value + "&mode=view" , true);

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
        if (!string.IsNullOrEmpty(drpLocation.SelectedValue))
        {
            LU_Location lu = new LU_Location(Convert.ToDecimal(drpLocation.SelectedValue));
            txtLocation_Code.Text = Convert.ToString(lu.Sonic_Location_Code);
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
        ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(3);", true);
    }

    protected void lnkAddInvoice_Click(object sender, EventArgs e)
    {
        if (PK_Management > 0)
        {
            Response.Redirect("ACI_Management_ProjectCost_Invoice.aspx?id=" + Encryption.Encrypt(Convert.ToString(PK_Management)) + "&pnl=" + hdnPanel.Value + "&op=add", true);
        }
        else
        {
            ClientScript.RegisterClientScriptBlock(Page.GetType(), DateTime.Now.ToString(), "javascript:alert('Please Enter Management Details First');ShowPanel(" + hdnPanel.Value + ");", true);
            //ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel("+hdnPanel.Value+");", true);
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
            trstoreContact.Style.Add("display", "block");
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
            trACIContact.Style.Add("display", "block");
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
             Response.Redirect("ACI_Management_Project_Cost.aspx?id=" + Encryption.Encrypt(decFK_Management.ToString()) + "&PCI=" + Encryption.Encrypt(decPK_ACIManagement_ProjectCost.ToString()) + "&pnl=" + hdnPanel.Value + "&op="+StrOperation, true);
        }
        if (e.CommandName == "RemoveProjectCost")
        {
            clsACIManagement_ProjectCost.DeleteByPK(Convert.ToDecimal(e.CommandArgument));
            BindProjectCostGrid();
            //chkIncludeCompProject.Checked = false;
            ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel("+ hdnPanel.Value +");", true);
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
        else
        {
            ClientScript.RegisterClientScriptBlock(Page.GetType(), DateTime.Now.ToString(), "javascript:alert('Please Enter Management Details First');ShowPanel("+hdnPanel.Value+");", true);
            //ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(1);", true);
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
            ScriptManager.RegisterStartupScript(this, this.GetType(), System.DateTime.Now.ToString(), "javascrip:ShowPanel("+hdnPanel.Value+");", true);
        }
    }

    #endregion
    
}