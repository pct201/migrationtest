using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ERIMS.DAL;

public partial class SONIC_Pollution_Respiratory_Protection : clsBasePage
{
    #region Properties
    /// <summary>
    /// Denotes the Primary Key
    /// </summary>
    public decimal PK_PM_Respiratory_Protection
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_PM_Respiratory_Protection"]);
        }
        set { ViewState["PK_PM_Respiratory_Protection"] = value; }
    }
  
    /// <summary>
    /// Denotes foriegn key for Site Information
    /// </summary>
    public decimal FK_PM_Site_Information
    {
        get { return clsGeneral.GetInt(ViewState["FK_PM_Site_Information"]); }
        set { ViewState["FK_PM_Site_Information"] = value; }
    }

    /// <summary>
    /// Denotes foriegn key for Location record
    /// </summary>
    public decimal FK_LU_Location_ID
    {
        get { return Convert.ToDecimal(ViewState["FK_LU_Location_ID"]); }
        set { ViewState["FK_LU_Location_ID"] = value; }
    }

    /// <summary>
    /// Denotes the operation whether edit or view
    /// </summary>
    public string StrOperation
    {
        get { return Convert.ToString(ViewState["strOperation"]); }
        set { ViewState["strOperation"] = value; }
    }
    #endregion

    #region Page Events
    protected void Page_Load(object sender, EventArgs e)
    {
        Tab.SetSelectedTab(Controls_ExposuresTab_ExposuresTab.Tab.Pollution);
        //drpFK_LU_Waste_Type.Attributes.Add("onChange", "return SetDischargeView();");
        //Attachment.btnHandler += new Attachment_Pollution.OnButtonClick(Upload_File);
        if (!Page.IsPostBack)
        {
            // shows the first panel
            //Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(1);", true);
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:SetMenuStyle(1);", true);
            PK_PM_Respiratory_Protection = clsGeneral.GetQueryStringID(Request.QueryString["id"]);
            //FK_PM_Compliance_Reporting = clsGeneral.GetQueryStringID(Request.QueryString["cid"]);
            FK_PM_Site_Information = clsGeneral.GetQueryStringID(Request.QueryString["fid"]);
            FK_LU_Location_ID = clsGeneral.GetQueryStringID(Request.QueryString["loc"]);

            if (FK_LU_Location_ID > 0)
            {
                Session["ExposureLocation"] = FK_LU_Location_ID;
                ucCtrlExposureInfo.PK_LU_Location = FK_LU_Location_ID;
                ucCtrlExposureInfo.BindExposureInfo();
            }
            else
                Response.Redirect("../Exposures/ExposureSearch.aspx");

            if (PK_PM_Respiratory_Protection > 0)
            {
                if (Request.QueryString["op"] != null)
                {
                    StrOperation = Request.QueryString["op"];
                }
                else
                    StrOperation = "edit";

                if (StrOperation == "view")
                {
                    // Bind Controls
                    BindDetailsForView();
                    dvView.Style["display"] = "inline";
                    dvEdit.Style["display"] = "none";
                    btnSave.Visible = false;
                    btnEdit.Visible = (App_Access == AccessType.Administrative_Access);
                    // set attachment details control in readonly mode.
                    //AttachDetailsView.InitializeAttachmentDetails(clsGeneral.Pollution_Tables.PM_Respiratory_Protection_Attachments, Convert.ToInt32(PK_PM_Respiratory_Protection), "FK_PM_Respiratory_Protection", "PK_PM_Respiratory_Protection_Attachments", false, 2);
                    AttachmentsView.StrOperation = StrOperation;
                    AttachmentsView.PK_ID = PK_PM_Respiratory_Protection;
                }
                else
                {
                    if (App_Access == AccessType.View_Only)
                        Response.Redirect(AppConfig.SiteURL + "Error.aspx?msg=errAcc");
                    SetValidations();
                    // Bind Controls
                    BindDetailsForEdit();
                    dvView.Style["display"] = "none";
                    dvEdit.Style["display"] = "inline";
                    btnSave.Visible = true;
                    btnEdit.Visible = false;
                    // set attachment details control in read/write mode. so user can add or remove attachment as well.
                    //AttachDetails.InitializeAttachmentDetails(clsGeneral.Pollution_Tables.PM_Respiratory_Protection_Attachments, Convert.ToInt32(PK_PM_Respiratory_Protection), "FK_PM_Respiratory_Protection", "PK_PM_Respiratory_Protection_Attachments", true, 2);
                    Attachments.PK_ID = PK_PM_Respiratory_Protection;
                }
                
                // bind attachment details to show attachment for current risk profile.
                //BindAttachmentDetails();
            }
            else
            {
                if (App_Access == AccessType.View_Only)
                    Response.Redirect(AppConfig.SiteURL + "Error.aspx?msg=errAcc");

                BindDropdown();
                // disable Add Attachment button
                SetValidations();
                //BindAttachmentDetails();
                // don't show div for view mode
                dvView.Style["display"] = "none";
                dvEdit.Style["display"] = "inline";
                btnEdit.Visible = false;
                btnAuditTrail.Visible = false;
            }
        }
    }
    #endregion

    #region Methods

    private void BindDropdown()
    {
        drpFK_Employee.Items.Clear();
        DataSet dsEmployeeBY_Loc_Training = Employee.SelectActiveEmployessByLocation(Convert.ToInt32(FK_LU_Location_ID));
        if (dsEmployeeBY_Loc_Training.Tables.Count > 0)
        {
            drpFK_Employee.DataSource = dsEmployeeBY_Loc_Training.Tables[0];
            drpFK_Employee.DataTextField = "EmployeeName";
            drpFK_Employee.DataValueField = "PK_Employee_ID";
            drpFK_Employee.DataBind();
        }
        drpFK_Employee.Items.Insert(0, new ListItem("Entire Department", "0"));
        drpFK_Employee.Items.Insert(0, new ListItem("--Select--", "-1"));

        DataSet dsVendorLookUP = clsPM_Respiratory_Protection.SelectVendorLookUpByPK(PK_PM_Respiratory_Protection);
        drpVendorLookup.Items.Clear();
        if (dsVendorLookUP.Tables.Count > 0)
        {
            drpVendorLookup.DataSource = dsVendorLookUP.Tables[0];
            drpVendorLookup.DataTextField = "VendorDetail";
            drpVendorLookup.DataValueField = "VendorDetail_DataValue";
            drpVendorLookup.DataBind();
        }
        //drpVendorLookup.Items.Insert(0, new ListItem("Examinetics,Steave,10561 Barkley Place, Ste 40066212913-748-2000", "0"));//here Steave may be change
        drpVendorLookup.Items.Insert(0, new ListItem("--Select--", "-1"));

        ComboHelper.FillRespiratorype(new DropDownList[] { drpFK_LU_Respirator_Type }, true);
        ComboHelper.FillState(new DropDownList[] { drpFK_LU_Vendor_State }, 0, true);
       
    }

    /// <summary>
    /// Bind Page Controls for edit mode
    /// </summary>
    private void BindDetailsForEdit()
    {
        dvView.Visible = false;
        dvEdit.Visible = true;
        btnEdit.Visible = false;
        BindDropdown();
        clsPM_Respiratory_Protection objPM_Respiratory_Protection = new clsPM_Respiratory_Protection(PK_PM_Respiratory_Protection);
        txtDate.Text = clsGeneral.FormatDBNullDateToDisplay(objPM_Respiratory_Protection.Date);
        if (objPM_Respiratory_Protection.FK_Employee != null) drpFK_Employee.SelectedValue = objPM_Respiratory_Protection.FK_Employee.ToString();
        if (objPM_Respiratory_Protection.Event_Type != null) drpEvent_Type.SelectedValue = objPM_Respiratory_Protection.Event_Type.ToString();
        if (objPM_Respiratory_Protection.Medical_Evaluation != null) rdoMedical_Evaluation.SelectedValue = objPM_Respiratory_Protection.Medical_Evaluation;
        if (objPM_Respiratory_Protection.Restrictions_Applied != null) rdoRestrictions_Applied.SelectedValue = objPM_Respiratory_Protection.Restrictions_Applied;
        txtRestrictionsNotes.Text = objPM_Respiratory_Protection.Restrictions;
        if (objPM_Respiratory_Protection.Reevaluation_Required != null) rdoReevaluation_Required.SelectedValue = objPM_Respiratory_Protection.Reevaluation_Required;
        txtReevaluation_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objPM_Respiratory_Protection.Reevaluation_Date);
        if (objPM_Respiratory_Protection.Training_Completed != null) rdoTraining_Completed.SelectedValue = objPM_Respiratory_Protection.Training_Completed;
        txtTraining_Completed_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objPM_Respiratory_Protection.Training_Completion_Date);
        if (objPM_Respiratory_Protection.Fit_Test != null) rdoFit_Test.SelectedValue = objPM_Respiratory_Protection.Fit_Test;
        txtFit_Test_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objPM_Respiratory_Protection.Fit_Test_Date);
        if (objPM_Respiratory_Protection.Pass_Fail != null) rdoPass_Fail.SelectedValue = objPM_Respiratory_Protection.Pass_Fail;
        if (objPM_Respiratory_Protection.FK_LU_Respirator_Type != null) drpFK_LU_Respirator_Type.SelectedValue = objPM_Respiratory_Protection.FK_LU_Respirator_Type.ToString();
        //vendor lookup
        txtVendor.Text = objPM_Respiratory_Protection.Vendor;
        txtVendor_Representative.Text = objPM_Respiratory_Protection.Vendor_Representative;
        txtVendor_Address.Text = objPM_Respiratory_Protection.Vendor_Address;
        txtVendor_City.Text = objPM_Respiratory_Protection.Vendor_City;
        if (objPM_Respiratory_Protection.FK_Vendor_State != null) drpFK_LU_Vendor_State.SelectedValue = objPM_Respiratory_Protection.FK_Vendor_State.ToString();
        txtVendor_Zip_Code.Text = objPM_Respiratory_Protection.Vendor_Zip_Code;
        txtVendor_Telephone.Text = objPM_Respiratory_Protection.Vendor_Telephone;
        txtVendor_EMail.Text = objPM_Respiratory_Protection.Vendor_EMail;
        txtNotesComments.Text = objPM_Respiratory_Protection.Notes_Comments;
    }


    /// <summary>
    /// Binds Page Controls for view mode
    /// </summary>
    private void BindDetailsForView()
    {
        dvView.Visible = true;
        dvEdit.Visible = false;
        dvSave.Visible = true;
        btnSave.Visible = false;
        btnEdit.Visible = true;
        DataTable dtRespiratory = clsPM_Respiratory_Protection.SelectViewByPK(PK_PM_Respiratory_Protection).Tables[0];// objPM_Respiratory_Protection = new clsPM_Respiratory_Protection(PK_PM_Respiratory_Protection);
        lblDate.Text = clsGeneral.FormatDBNullDateToDisplay(dtRespiratory.Rows[0]["Date"]);
        lblFK_Employee.Text = Convert.ToString(dtRespiratory.Rows[0]["EmployeeName"]);
        lblEvent_Type.Text = Convert.ToString(dtRespiratory.Rows[0]["EventType"]);
        lblMedical_Evaluation.Text = Convert.ToString(dtRespiratory.Rows[0]["MedicalEvaluation"]);
        trViewMedical_Evaluation.Visible = (lblMedical_Evaluation.Text == "Yes") ? true : false;
        lblRestrictions_Applied.Text = Convert.ToString(dtRespiratory.Rows[0]["RestrictionsApplied"]);
        trViewWereRestrictions1.Visible = trViewWereRestrictions2.Visible = (lblRestrictions_Applied.Text == "Yes") ? true : false;
        lblRestrictionsNotes.Text = Convert.ToString(dtRespiratory.Rows[0]["Restrictions"]);
        lblReevaluation_Required.Text = Convert.ToString(dtRespiratory.Rows[0]["ReevaluationRequired"]);
        lblReevaluation_Date.Text = clsGeneral.FormatDBNullDateToDisplay(dtRespiratory.Rows[0]["Reevaluation_Date"]);
        lblTraining_Completed.Text = Convert.ToString(dtRespiratory.Rows[0]["TrainingCompleted"]);
        trViewTraining.Visible = (lblTraining_Completed.Text == "Yes") ? true : false;
        lblTraining_Completed_Date.Text = clsGeneral.FormatDBNullDateToDisplay(dtRespiratory.Rows[0]["Training_Completion_Date"]);
        lblFit_Test.Text = Convert.ToString(dtRespiratory.Rows[0]["FitTest"]);
        trViewFitTest1.Visible = trViewFitTest2.Visible = (lblFit_Test.Text == "Yes") ? true : false;
        lblFit_Test_Date.Text = clsGeneral.FormatDBNullDateToDisplay(dtRespiratory.Rows[0]["Fit_Test_Date"]);
        lblPass_Fail.Text = Convert.ToString(dtRespiratory.Rows[0]["PassFail"]);
        lblFK_LU_Respirator_Type.Text = Convert.ToString(dtRespiratory.Rows[0]["Respirator_Type_Desc"]);
        //vendor lookup
        lblVendor.Text = Convert.ToString(dtRespiratory.Rows[0]["Vendor"]);
        lblVendor_Representative.Text = Convert.ToString(dtRespiratory.Rows[0]["Vendor_Representative"]);
        lblVendor_Address.Text = Convert.ToString(dtRespiratory.Rows[0]["Vendor_Address"]);
        lblVendor_City.Text = Convert.ToString(dtRespiratory.Rows[0]["Vendor_City"]);
        lblFK_LU_Vendor_State.Text = Convert.ToString(dtRespiratory.Rows[0]["Vendor_State"]);
        lblVendor_Zip_Code.Text = Convert.ToString(dtRespiratory.Rows[0]["Vendor_Zip_Code"]);
        lblVendor_Telephone.Text = Convert.ToString(dtRespiratory.Rows[0]["Vendor_Telephone"]);
        lblVendor_EMail.Text = Convert.ToString(dtRespiratory.Rows[0]["Vendor_EMail"]);
        lblNotesComments.Text = Convert.ToString(dtRespiratory.Rows[0]["Notes_Comments"]);
        
    }

    private void SaveRespiratoryProtection(bool IsFromAdd)
    {
        clsPM_Respiratory_Protection objPM_Respiratory_Protection = new clsPM_Respiratory_Protection();
        objPM_Respiratory_Protection.PK_PM_Respiratory_Protection = PK_PM_Respiratory_Protection;
        objPM_Respiratory_Protection.FK_PM_Site_Information = FK_PM_Site_Information;
        objPM_Respiratory_Protection.FK_LU_Location = FK_LU_Location_ID;
        objPM_Respiratory_Protection.Date = clsGeneral.FormatNullDateToStore(txtDate.Text);
        if (drpFK_Employee.SelectedIndex > 0) objPM_Respiratory_Protection.FK_Employee = clsGeneral.GetDecimal(drpFK_Employee.SelectedValue);
        if (drpEvent_Type.SelectedIndex > 0) objPM_Respiratory_Protection.Event_Type = drpEvent_Type.SelectedValue;
        objPM_Respiratory_Protection.Medical_Evaluation = rdoMedical_Evaluation.SelectedValue;
        objPM_Respiratory_Protection.Restrictions_Applied = rdoRestrictions_Applied.SelectedValue;
        objPM_Respiratory_Protection.Restrictions = Convert.ToString(txtRestrictionsNotes.Text);
        objPM_Respiratory_Protection.Reevaluation_Required = rdoReevaluation_Required.SelectedValue;
        objPM_Respiratory_Protection.Reevaluation_Date = clsGeneral.FormatNullDateToStore(txtReevaluation_Date.Text);
        objPM_Respiratory_Protection.Training_Completed = rdoTraining_Completed.SelectedValue;
        objPM_Respiratory_Protection.Training_Completion_Date = clsGeneral.FormatNullDateToStore(txtTraining_Completed_Date.Text);
        objPM_Respiratory_Protection.Fit_Test = rdoFit_Test.SelectedValue;
        objPM_Respiratory_Protection.Fit_Test_Date= clsGeneral.FormatNullDateToStore(txtFit_Test_Date.Text);
        objPM_Respiratory_Protection.Pass_Fail = rdoPass_Fail.SelectedValue;
        if (drpFK_LU_Respirator_Type.SelectedIndex > 0) objPM_Respiratory_Protection.FK_LU_Respirator_Type = clsGeneral.GetDecimal(drpFK_LU_Respirator_Type.SelectedValue);
        //vendor lookup
        objPM_Respiratory_Protection.Vendor = txtVendor.Text.Trim();
        objPM_Respiratory_Protection.Vendor_Representative = txtVendor_Representative.Text.Trim();
        objPM_Respiratory_Protection.Vendor_Address = txtVendor_Address.Text.Trim();
        objPM_Respiratory_Protection.Vendor_City = txtVendor_City.Text.Trim();
        if (drpFK_LU_Vendor_State.SelectedIndex > 0) objPM_Respiratory_Protection.FK_Vendor_State = clsGeneral.GetDecimal( drpFK_LU_Vendor_State.SelectedValue);
        objPM_Respiratory_Protection.Vendor_Zip_Code = txtVendor_Zip_Code.Text.Trim();
        objPM_Respiratory_Protection.Vendor_Telephone = txtVendor_Telephone.Text.Trim();
        objPM_Respiratory_Protection.Vendor_EMail = txtVendor_EMail.Text.Trim();
        objPM_Respiratory_Protection.Notes_Comments = Convert.ToString(txtNotesComments.Text);

        objPM_Respiratory_Protection.Updated_By = clsSession.UserID;
        objPM_Respiratory_Protection.Update_Date = DateTime.Now;

        decimal _retVal;
        if (PK_PM_Respiratory_Protection > 0)
        {
            _retVal = 0;
            objPM_Respiratory_Protection.Update();
            // add the attachment 
            //Attachment.FK_Field_Value = Convert.ToInt32(PK_PM_Respiratory_Protection);
            //Attachment.FK_Field_Name = "FK_PM_Respiratory_Protection";
            //Attachment.Add(clsGeneral.Pollution_Tables.PM_Respiratory_Protection_Attachments);
            Response.Redirect("PM_Respiratory_Protection.aspx?op=view&id=" + Encryption.Encrypt(Convert.ToString(PK_PM_Respiratory_Protection)) + "&fid=" + Encryption.Encrypt(Convert.ToString(FK_PM_Site_Information)) + "&loc=" + Encryption.Encrypt(Convert.ToString(FK_LU_Location_ID)));
        }
        else
        {
            _retVal = objPM_Respiratory_Protection.Insert();
            PK_PM_Respiratory_Protection = _retVal;
            // add the attachment 
            //Attachment.FK_Field_Value = Convert.ToInt32(PK_PM_Respiratory_Protection);
            //Attachment.FK_Field_Name = "FK_PM_Respiratory_Protection";
            //Attachment.Add(clsGeneral.Pollution_Tables.PM_Respiratory_Protection_Attachments);
            if (!IsFromAdd)
                Response.Redirect("PM_Respiratory_Protection.aspx?op=view&id=" + Encryption.Encrypt(Convert.ToString(PK_PM_Respiratory_Protection)) + "&fid=" + Encryption.Encrypt(Convert.ToString(FK_PM_Site_Information)) + "&loc=" + Encryption.Encrypt(Convert.ToString(FK_LU_Location_ID)));
        }
    }

    /// <summary>
    /// return Comma saperated list of all selected item in listbox
    /// </summary>
    /// <param name="lstBox"></param>
    /// <returns></returns>
    public string GetSelectedItemString(ListBox lstBox, bool isStringValue)
    {
        string strValues = "";
        foreach (ListItem lstBoxItem in lstBox.Items)
        {
            if (lstBoxItem.Selected)
            {
                if (isStringValue)
                    strValues = strValues + "'" + lstBoxItem.Value.Replace("'", "''") + "',";
                else
                    strValues = strValues + lstBoxItem.Value.Replace("'", "''") + ",";
            }

        }
        return strValues.TrimEnd(',');
    }
    #endregion

    #region Control Events


    /// <summary>
    /// Redirects from the view to edit state
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnEdit_Click(object sender, EventArgs e)
    {
        if (PK_PM_Respiratory_Protection > 0)
            Response.Redirect("PM_Respiratory_Protection.aspx?op=edit&id=" + Encryption.Encrypt(Convert.ToString(PK_PM_Respiratory_Protection)) + "&fid=" + Encryption.Encrypt(Convert.ToString(FK_PM_Site_Information)) + "&loc=" + Encryption.Encrypt(Convert.ToString(FK_LU_Location_ID)));
    }

    /// <summary>
    /// Handles Save Button click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSave_Click(object sender, EventArgs e)
    {
        SaveRespiratoryProtection(false);
    }
    /// <summary>
    /// Directs back to the parent page
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnBack_Click(object sender, EventArgs e)
    {
        if (StrOperation == "view")
            Response.Redirect("Pollution.aspx?op=view&id=" + Encryption.Encrypt(Convert.ToString(FK_PM_Site_Information)) + "&loc=" + Encryption.Encrypt(Convert.ToString(FK_LU_Location_ID)) + "&pnl=" + Encryption.Encrypt("7"));
        else
            Response.Redirect("Pollution.aspx?op=edit&id=" + Encryption.Encrypt(Convert.ToString(FK_PM_Site_Information)) + "&loc=" + Encryption.Encrypt(Convert.ToString(FK_LU_Location_ID)) + "&pnl=" + Encryption.Encrypt("7"));
    }
    #endregion

    #region Attachments Management
    /// <summary>
    /// Binds the attachment details
    /// </summary>
    private void BindAttachmentDetails()
    {
        dvAttachment.Style["display"] = "block";
        if (StrOperation == "view")
        {
            //AttachDetailsView.Bind();
        }
        else
        {
            //AttachDetails.Bind();
        }
    }

    /// <summary>
    /// Upload File
    /// </summary>
    /// <param name="strValue"></param>
    void Upload_File(string strValue)
    {
        if (PK_PM_Respiratory_Protection > 0)
        {
            // add the attachment 
            //Attachment.FK_Field_Value = Convert.ToInt32(PK_PM_Respiratory_Protection);
            //Attachment.FK_Field_Name = "FK_PM_Respiratory_Protection";
            //Attachment.Add(clsGeneral.Pollution_Tables.PM_Respiratory_Protection_Attachments);

            // bind the details to view added attachment
            BindAttachmentDetails();

            // show the attachment panel as the page is loaded again
            //Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(2);", true);
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:alert('Please save Respiratory Protection first.');", true);//ShowPanel(2);
        }
    }
    #endregion

    #region Dynamic Validations
    /// <summary>
    /// Set all Validations
    /// </summary>
    private void SetValidations()
    {
        string strCtrlsIDs = "";
        string strMessages = "";

        #region " Site Information "

        DataTable dtFields = clsScreen_Validators.SelectByScreenName("Respiratory Protection").Tables[0];
        dtFields.DefaultView.RowFilter = "IsRequired = '1'";
        dtFields = dtFields.DefaultView.ToTable();

        MenuAsterisk1.Style["display"] = (dtFields.Rows.Count > 0) ? "inline-block" : "none";

        foreach (DataRow drField in dtFields.Rows)
        {
            #region " set validation control IDs and messages "
            switch (Convert.ToString(drField["Field_Name"]))
            {
                case "Event Type":
                    strCtrlsIDs += drpEvent_Type.ClientID + ",";
                    strMessages += "Please select [Respiratory Protection]/Event Type" + ",";
                    Span1.Style["display"] = "inline-block";
                    break;
                case "Associate":
                    strCtrlsIDs += drpFK_Employee.ClientID + ",";
                    strMessages += "Please select [Respiratory Protection]/Associate" + ",";
                    Span13.Style["display"] = "inline-block";
                    break;
                case "Medical Evaluation":
                    strCtrlsIDs += rdoMedical_Evaluation.ClientID + ",";
                    strMessages += "Please select [Respiratory Protection]/On-Line Medical Evaluation.." + ",";
                    Span6.Style["display"] = "inline-block";
                    break;
                case "Were Restrictions Applied?":
                    strCtrlsIDs += rdoRestrictions_Applied.ClientID + ",";
                    strMessages += "Please select [Respiratory Protection]/Were Restrictions Applied?" + ",";
                    Span7.Style["display"] = "inline-block";
                    break;
                case "Restrictions":
                    strCtrlsIDs += txtRestrictionsNotes.ClientID + ",";
                    strMessages += "Please enter [Respiratory Protection]/Restrictions" + ",";
                    Span19.Style["display"] = "inline-block";
                    break;
                case "Reevaluation_Required":
                    strCtrlsIDs += rdoRestrictions_Applied.ClientID + ",";
                    strMessages += "Please select [Respiratory Protection]/Re-evaluation Required?" + ",";
                    Span9.Style["display"] = "inline-block";
                    break;
                case "Training_Completed":
                    strCtrlsIDs += rdoRestrictions_Applied.ClientID + ",";
                    strMessages += "Please select [Respiratory Protection]/Training Completed?" + ",";
                    Span10.Style["display"] = "inline-block";
                    break;
                case "Date":
                    strCtrlsIDs += txtDate.ClientID + ",";
                    strMessages += "Please enter [Respiratory Protection]/Date" + ",";
                    Span5.Style["display"] = "inline-block";
                    break;
                case "Training_Completed_Date":
                    strCtrlsIDs += txtTraining_Completed_Date.ClientID + ",";
                    strMessages += "Please enter [Respiratory Protection]/Training Completion Date" + ",";
                    Span15.Style["display"] = "inline-block";
                    break;
                case "Fit_Test":
                    strCtrlsIDs += rdoFit_Test.ClientID + ",";
                    strMessages += "Please select [Respiratory Protection]/Fit Test Completed?" + ",";
                    Span11.Style["display"] = "inline-block";
                    break;
                case "Fit_Test_Date":
                    strCtrlsIDs += txtFit_Test_Date.ClientID + ",";
                    strMessages += "Please enter [Respiratory Protection]/Date Fit Test Completed" + ",";
                    Span16.Style["display"] = "inline-block";
                    break;
                case "Pass_Fail":
                    strCtrlsIDs += rdoPass_Fail.ClientID + ",";
                    strMessages += "Please select [Respiratory Protection]/Pass/Fail?" + ",";
                    Span24.Style["display"] = "inline-block";
                    break;
                case "FK_LU_Respirator_Type":
                    strCtrlsIDs += drpFK_LU_Respirator_Type.ClientID + ",";
                    strMessages += "Please select [Respiratory Protection]/Type of Respirator Used" + ",";
                    Span2.Style["display"] = "inline-block";
                    break;
            }
            #endregion
        }
        #endregion


        strCtrlsIDs = strCtrlsIDs.TrimEnd(',');
        strMessages = strMessages.TrimEnd(',');

        hdnControlIDs.Value = strCtrlsIDs;
        hdnErrorMsgs.Value = strMessages;
    }
    #endregion

}