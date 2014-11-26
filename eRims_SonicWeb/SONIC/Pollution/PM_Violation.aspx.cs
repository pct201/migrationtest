using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERIMS.DAL;
using System.Data;

public partial class SONIC_Pollution_PM_Violation : clsBasePage
{
    #region Properties
    /// <summary>
    /// Denotes foriegn key for site information
    /// </summary>
    public decimal FK_PM_Site_Information
    {
        get
        {
            return clsGeneral.GetInt(ViewState["FK_PM_Remediation"]);
        }
        set { ViewState["FK_PM_Remediation"] = value; }
    }
    /// <summary>
    /// Denotes the Primary Key
    /// </summary>
    public decimal PK_PM_Violation
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_PM_Violation"]);
        }
        set { ViewState["PK_PM_Violation"] = value; }
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
    /// Denotes foriegn key for Location record
    /// </summary>
    public decimal FK_LU_Location_ID
    {
        get { return Convert.ToDecimal(ViewState["FK_LU_Location_ID"]); }
        set { ViewState["FK_LU_Location_ID"] = value; }
    }
    #endregion

    #region Page Events
    /// <summary>
    /// Handles Page Load event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        Tab.SetSelectedTab(Controls_ExposuresTab_ExposuresTab.Tab.Pollution);
        Attachment.btnHandler += new Attachment_Pollution.OnButtonClick(Upload_File);
        if (!Page.IsPostBack)
        {
            PK_PM_Violation = clsGeneral.GetQueryStringID(Request.QueryString["id"]);
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

            // shows the first panel
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(1);", true);
            if (PK_PM_Violation > 0)
            {
                StrOperation = Convert.ToString(Request.QueryString["op"]);
                //PK_Executive_Risk_Contacts = Convert.ToInt32(Request.QueryString["id"]);
                if (StrOperation == "view")
                {
                    // Bind Controls
                    BindDetailsForView();
                    btnEdit.Visible = (App_Access == AccessType.Administrative_Access);
                    // set attachment details control in readonly mode.
                    AttachDetailsView.InitializeAttachmentDetails(clsGeneral.Pollution_Tables.PM_Violation_Attachments, Convert.ToInt32(PK_PM_Violation), "FK_PM_Violation", "PK_PM_Violation_Attachments", false, 2);
                }
                else
                {
                    BindDropdown();
                    if (App_Access == AccessType.View_Only)
                        Response.Redirect(AppConfig.SiteURL + "Error.aspx?msg=errAcc");
                    SetValidations();
                    // Bind Controls
                    BindDetailsForEdit();
                    // set attachment details control in read/write mode. so user can add or remove attachment as well.
                    AttachDetails.InitializeAttachmentDetails(clsGeneral.Pollution_Tables.PM_Violation_Attachments, Convert.ToInt32(PK_PM_Violation), "FK_PM_Violation", "PK_PM_Violation_Attachments", true, 2);
                }
                // bind attachment details to show attachment for current risk profile.
                BindAttachmentDetails();
            }
            else
            {
                if (App_Access == AccessType.View_Only)
                    Response.Redirect(AppConfig.SiteURL + "Error.aspx?msg=errAcc");
                // disable Add Attachment button
                BindDropdown();
                btnEdit.Visible = false;
                BindAttachmentDetails();
                btnAuditTrail.Visible = false;
                SetValidations();
                // don't show div for view mode
                dvView.Style["display"] = "none";
                if (FK_PM_Site_Information > 0)
                    btnBack.Visible = true;
                else
                    btnBack.Visible = false;
            }
        }
    }
    #endregion

    #region Methods

    private void BindDropdown()
    {
        DataSet dsRA = LU_Regulatory_Notifying_Agency.SelectAll();
        dsRA.Tables[0].DefaultView.RowFilter = "Active='Y'";

        drpRegulatory_Notifying_Agency.DataSource = dsRA.Tables[0].DefaultView;
        drpRegulatory_Notifying_Agency.DataTextField = "Fld_Desc";
        drpRegulatory_Notifying_Agency.DataValueField = "PK_LU_Regulatory_Notifying_Agency";
        drpRegulatory_Notifying_Agency.DataBind();
        drpRegulatory_Notifying_Agency.Items.Insert(0, new ListItem("-- Select --", "0"));
    }


    /// <summary>
    /// Bind Page Controls for edit mode
    /// </summary>
    private void BindDetailsForEdit()
    {
        dvView.Visible = false;
        dvEdit.Visible = true;
        btnEdit.Visible = false;
        PM_Violation objPM_Violation = new PM_Violation(PK_PM_Violation);
        txtDate_Of_Violation.Text = clsGeneral.FormatDBNullDateToDisplay(objPM_Violation.Date_Of_Violation);
        txtOtherAgency.Text =Convert.ToString( objPM_Violation.Other_Agency);
        txtContact_Name.Text = objPM_Violation.Contact_Name;
        txtContact_Telephone.Text = objPM_Violation.Contact_Telephone;
        txtCost.Text = clsGeneral.GetStringValue(objPM_Violation.Cost);
        txtDescription_Of_Violations.Text = objPM_Violation.Description_Of_Violations;
        txtAdditional_Costs.Text = clsGeneral.GetStringValue(objPM_Violation.Additional_Costs);
        txtAdditional_Costs_Description.Text = objPM_Violation.Additional_Costs_Description;
        txtRemediationCost.Text = clsGeneral.GetStringValue(objPM_Violation.Remediation_Cost);
        txtPurchaseNewEquipment.Text = clsGeneral.GetStringValue(objPM_Violation.New_Equipment);
        txtConsultingFee.Text = clsGeneral.GetStringValue(objPM_Violation.Consulting_Fees);
        txtAttorneyFee.Text = clsGeneral.GetStringValue(objPM_Violation.Attorney_Fees);       
        rdbRepeatViolation.SelectedValue = Convert.ToString(objPM_Violation.Repeat_Violation);
        drpRegulatory_Notifying_Agency.SelectedValue = Convert.ToString(objPM_Violation.FK_LU_Regulatory_Notifying_Agency);
        
        if (objPM_Violation.FK_PM_Site_Information != null) FK_PM_Site_Information = Convert.ToDecimal(objPM_Violation.FK_PM_Site_Information);
        if (FK_PM_Site_Information > 0)
            btnBack.Visible = true;
        else
            btnBack.Visible = false;
        if (objPM_Violation.Apply_To_Location != null) rdoApply_To_Location.SelectedValue = objPM_Violation.Apply_To_Location;
    }
    /// <summary>
    /// Binds Page Controls for view mode
    /// </summary>
    private void BindDetailsForView()
    {
        dvView.Visible = true;
        dvEdit.Visible = false;
        btnEdit.Visible = true;
        btnSave.Visible = false;
        PM_Violation objPM_Violation = new PM_Violation(PK_PM_Violation);
        lblDate_Of_Violation.Text = clsGeneral.FormatDBNullDateToDisplay(objPM_Violation.Date_Of_Violation);
        lblOtherAgency.Text =Convert.ToString( objPM_Violation.Other_Agency);
        lblContact_Name.Text = objPM_Violation.Contact_Name;
        lblContact_Telephone.Text = objPM_Violation.Contact_Telephone;
        lblCost.Text = string.Format("{0:C2}", objPM_Violation.Cost);
        lblDescription_Of_Violations.Text = objPM_Violation.Description_Of_Violations;
        lblAdditional_Costs.Text = string.Format("{0:C2}", objPM_Violation.Additional_Costs);
        lblAdditional_Costs_Description.Text = objPM_Violation.Additional_Costs_Description;
        lblRemediationCost.Text = string.Format("{0:C2}", objPM_Violation.Remediation_Cost);
        lblPurchaseofNewEquipment.Text = string.Format("{0:C2}", objPM_Violation.New_Equipment);
        lblConsultingFees.Text = string.Format("{0:C2}", objPM_Violation.Consulting_Fees);
        lblAttrneyFees.Text = string.Format("{0:C2}", objPM_Violation.Attorney_Fees);
      
        lblRepeatViolation.Text=Convert.ToString(objPM_Violation.Repeat_Violation)=="Y"?"Yes":"No";
        if (objPM_Violation.FK_LU_Regulatory_Notifying_Agency != null)
            lblRegulatory_Notifying_Agency.Text = Convert.ToString(new LU_Regulatory_Notifying_Agency(Convert.ToDecimal(objPM_Violation.FK_LU_Regulatory_Notifying_Agency)).Fld_Desc);

        if (objPM_Violation.FK_PM_Site_Information != null) FK_PM_Site_Information = Convert.ToDecimal(objPM_Violation.FK_PM_Site_Information);
        if (FK_PM_Site_Information > 0)
            btnBack.Visible = true;
        else
            btnBack.Visible = false;
        if (objPM_Violation.Apply_To_Location != null) lblApply_To_Location.Text = objPM_Violation.Apply_To_Location == "Y" ? "Yes" : "No";

    }
    #endregion

    #region Control Events
    /// <summary>
    /// Handles Save Button click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSave_Click(object sender, EventArgs e)
    {
        PM_Violation objPM_Violation = new PM_Violation();
        objPM_Violation.PK_PM_Violation = PK_PM_Violation;
        objPM_Violation.Date_Of_Violation = clsGeneral.FormatNullDateToStore(txtDate_Of_Violation.Text);
        objPM_Violation.Other_Agency = txtOtherAgency.Text.Trim();
        objPM_Violation.Contact_Name = txtContact_Name.Text.Trim();
        objPM_Violation.Contact_Telephone = txtContact_Telephone.Text.Trim();
        if (txtCost.Text != "") objPM_Violation.Cost = clsGeneral.GetDecimalValue(txtCost);
        objPM_Violation.Description_Of_Violations = txtDescription_Of_Violations.Text.Trim();
        if (txtAdditional_Costs.Text != "") objPM_Violation.Additional_Costs = clsGeneral.GetDecimalValue(txtAdditional_Costs);
        objPM_Violation.Additional_Costs_Description = txtAdditional_Costs_Description.Text.Trim();
        objPM_Violation.FK_PM_Site_Information = FK_PM_Site_Information;
        objPM_Violation.Update_Date = DateTime.Now;
        objPM_Violation.Updated_By = clsSession.UserID;
        objPM_Violation.FK_LU_Regulatory_Notifying_Agency = Convert.ToDecimal(drpRegulatory_Notifying_Agency.SelectedValue);
        objPM_Violation.Repeat_Violation = Convert.ToString(rdbRepeatViolation.SelectedValue);      
        if (txtRemediationCost.Text != "") objPM_Violation.Remediation_Cost = clsGeneral.GetDecimalValue(txtRemediationCost);
        if (txtPurchaseNewEquipment.Text != "") objPM_Violation.New_Equipment = clsGeneral.GetDecimalValue(txtPurchaseNewEquipment);
        if (txtConsultingFee.Text != "") objPM_Violation.Consulting_Fees = clsGeneral.GetDecimalValue(txtConsultingFee);
        if (txtAttorneyFee.Text != "") objPM_Violation.Attorney_Fees = clsGeneral.GetDecimalValue(txtAttorneyFee);
        objPM_Violation.Apply_To_Location = rdoApply_To_Location.SelectedValue;
        decimal _retVal;
        if (PK_PM_Violation > 0)
            _retVal = objPM_Violation.Update();
        else
            _retVal = objPM_Violation.Insert();

        if (_retVal == -2)
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:alert('The Violation that you are trying to add already exists.');ShowPanel(1);", true);
            return;
        }
        // add the attachment 
        Attachment.FK_Field_Value = Convert.ToInt32(_retVal.ToString());
        Attachment.FK_Field_Name = "FK_PM_Violation";
        Attachment.Add(clsGeneral.Pollution_Tables.PM_Violation_Attachments);
        Response.Redirect("PM_Violation.aspx?id=" + Encryption.Encrypt(_retVal.ToString()) + "&fid=" + Encryption.Encrypt(FK_PM_Site_Information.ToString()) + "&loc=" + Request.QueryString["loc"] + "&op=view");
    }
    /// <summary>
    /// Handles Edit button click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnEdit_Click(object sender, EventArgs e)
    {
        Response.Redirect("PM_Violation.aspx?id=" + Encryption.Encrypt(PK_PM_Violation.ToString()) + "&fid=" + Encryption.Encrypt(FK_PM_Site_Information.ToString()) + "&loc=" + Request.QueryString["loc"] + "&op=edit");
    }
    /// <summary>
    /// Handles Back button click Event
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
            AttachDetailsView.Bind();
        }
        else
        {
            AttachDetails.Bind();
        }
    }
    /// <summary>
    /// Upload File
    /// </summary>
    /// <param name="strValue"></param>
    void Upload_File(string strValue)
    {
        if (PK_PM_Violation > 0)
        {
            // add the attachment 
            Attachment.FK_Field_Value = Convert.ToInt32(PK_PM_Violation);
            Attachment.FK_Field_Name = "FK_PM_Violation";
            Attachment.Add(clsGeneral.Pollution_Tables.PM_Violation_Attachments);

            // bind the details to view added attachment
            BindAttachmentDetails();

            // show the attachment panel as the page is loaded again
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(2);", true);
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:alert('Please save Violation details first.');ShowPanel(2);", true);
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

        DataTable dtFields = clsScreen_Validators.SelectByScreen(172).Tables[0];
        dtFields.DefaultView.RowFilter = "IsRequired = '1'";
        dtFields = dtFields.DefaultView.ToTable();

        MenuAsterisk1.Style["display"] = (dtFields.Rows.Count > 0) ? "inline-block" : "none";

        foreach (DataRow drField in dtFields.Rows)
        {
            #region " set validation control IDs and messages "
            switch (Convert.ToString(drField["Field_Name"]))
            {
                case "Date Of Violation":
                    strCtrlsIDs += txtDate_Of_Violation.ClientID + ",";
                    strMessages += "Please enter [Violations Grid]/Date Of Violation" + ",";
                    Span1.Style["display"] = "inline-block";
                    break;
                case "Regulatory/Notifying Agency":
                    strCtrlsIDs += drpRegulatory_Notifying_Agency.ClientID + ",";
                    strMessages += "Please select [Violations Grid]/Regulatory/Notifying Agency" + ",";
                    Span2.Style["display"] = "inline-block";
                    break;
                case "Contact Name":
                    strCtrlsIDs += txtContact_Name.ClientID + ",";
                    strMessages += "Please enter [Violations Grid]/Contact Name" + ",";
                    Span3.Style["display"] = "inline-block";
                    break;
                case "Contact Telephone":
                    strCtrlsIDs += txtContact_Telephone.ClientID + ",";
                    strMessages += "Please enter [Violations Grid]/Contact Telephone" + ",";
                    Span4.Style["display"] = "inline-block";
                    break;
                case "Fine":
                    strCtrlsIDs += txtCost.ClientID + ",";
                    strMessages += "Please enter [Violations Grid]/Fine" + ",";
                    Span5.Style["display"] = "inline-block";
                    break;
                case "Remediation Cost":
                    strCtrlsIDs += txtRemediationCost.ClientID + ",";
                    strMessages += "Please enter [Violations Grid]/Remediation Cost" + ",";
                    Span6.Style["display"] = "inline-block";
                    break;
                case "Purchase of New Equipment":
                    strCtrlsIDs += txtPurchaseNewEquipment.ClientID + ",";
                    strMessages += "Please enter [Violations Grid]/Purchase of New Equipment" + ",";
                    Span7.Style["display"] = "inline-block";
                    break;
                case "Consulting Fees":
                    strCtrlsIDs += txtConsultingFee.ClientID + ",";
                    strMessages += "Please enter [Violations Grid]/Consulting Fees" + ",";
                    Span8.Style["display"] = "inline-block";
                    break;
                case "Attorney Fees":
                    strCtrlsIDs += txtAttorneyFee.ClientID + ",";
                    strMessages += "Please enter [Violations Grid]/Attorney Fees" + ",";
                    Span9.Style["display"] = "inline-block";
                    break;
                case "Additional Costs":
                    strCtrlsIDs += txtAdditional_Costs.ClientID + ",";
                    strMessages += "Please enter [Violations Grid]/Additional Costs" + ",";
                    Span10.Style["display"] = "inline-block";
                    break;
                case "Describe What Additional Costs relate to":
                    strCtrlsIDs += txtAdditional_Costs_Description.ClientID + ",";
                    strMessages += "Please enter [Violations Grid]/Describe What Additional Costs relate to" + ",";
                    Span11.Style["display"] = "inline-block";
                    break;
                case "Description of Violation(s)":
                    strCtrlsIDs += txtDescription_Of_Violations.ClientID + ",";
                    strMessages += "Please enter [Violations Grid]/Description of Violation(s)" + ",";
                    Span12.Style["display"] = "inline-block";
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