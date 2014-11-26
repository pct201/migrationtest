using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using ERIMS.DAL;

public partial class Admin_RiskProfileAddEdit : clsBasePage
{
    #region "Properties"
    string _strOperation = "";
    /// <summary>
    /// Denotes Primary key
    /// </summary>
    private int PK_COI_Risk_Profile
    {
        get
        {
            return clsGeneral.GetInt(ViewState["ProfileID"]);
        }
        set { ViewState["ProfileID"] = value; }
    }
    /// <summary>
    /// Denotes operation either view or edit
    /// </summary>
    public string StrOperation
    {
        get
        {
            return _strOperation;
        }
    }
    #endregion

    #region "Page Events"
    /// <summary>
    /// Handles Page Load Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        // if page is loaded first time.
        if (!IsPostBack)
        {
            ((Button)Attachment.FindControl("btnAddAttachment")).OnClientClick = "javascript:return IfSave();";
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "ShowPanel", "javascript:ShowPanel(1);", true);
            if (App_Access == AccessType.NotAssigned)
                Response.Redirect(AppConfig.SiteURL + "Message.aspx?msg=You are not authorized to access this page");
            else
            {
                // if querystring for operation to be performed is passed(view or edit);
                if (!clsGeneral.IsNull(Request.QueryString["op"]))
                {
                    // if id is passed in querystring.
                    if (!clsGeneral.IsNull(Request.QueryString["id"]))
                    {
                        // set riskprofile id.
                        PK_COI_Risk_Profile = (int)clsGeneral.GetQueryStringID(Request.QueryString["id"]);
                        //PK_COI_Risk_Profile = Convert.ToInt32(Request.QueryString["id"]);
                        _strOperation = Request.QueryString["op"].ToString();
                        if (Request.QueryString["op"] == "view")
                        {
                            // if view mode,set values in label as per profile id.
                            BindDetailsForView();
                            if (App_Access == AccessType.View_Only)
                            {
                                btnEdit.Visible = false;
                            }
                            // set attachment details control in readonly mode.
                            AttachDetails.InitializeAttachmentDetails(clsGeneral.Tables.Risk_Profile, PK_COI_Risk_Profile, false, 9);
                        }
                        else
                        {
                            if (App_Access == AccessType.Administrative_Access)
                            {
                                // set attachment details control in read/write mode. so user can add or remove attachment as well.
                                AttachDetails.InitializeAttachmentDetails(clsGeneral.Tables.Risk_Profile, PK_COI_Risk_Profile, true, 9);
                                // set values in textbox and all other controls.
                                BindDetailsForEdit();
                            }
                            else
                                Response.Redirect(Request.Url.ToString().Replace("edit", "view"));
                        }
                    }
                    else
                    {
                        if (App_Access != AccessType.Administrative_Access)
                            Response.Redirect(AppConfig.SiteURL + "Message.aspx?msg=You are not authorized to access this page");
                        //btnAddAttachment.Style ["Display"] = "None";                     
                        btnBack.Style["Display"] = "none";
                        dvSave.Style["Display"] = "block";
                    }
                    // bind attachment details to show attachment for current risk profile.
                    BindAttachmentDetails();
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(1);", true);
                }
                else
                {
                    if (App_Access == AccessType.Administrative_Access)
                    { dvSave.Style["Display"] = "block"; }  //btnAddAttachment.Style["Display"]="none";
                    else
                        Response.Redirect(AppConfig.SiteURL + "Message.aspx?msg=You are not authorized to access this page");
                }
                SetValidations();
            }
        }
    }
    #endregion

    #region "Bind Details for Edit or View"
    /// <summary>
    /// Displays the page in edit mode
    /// </summary>
    private void BindDetailsForEdit()
    {
        // don't show div for view mode
        dvView.Style["Display"] = "None";
        dvEdit.Style["Display"] = "block";
        btnBack.Style["Display"] = "None";
        btnSave.Style["Display"] = "block";
        dvSave.Style["Display"] = "block";        
        _strOperation = "edit";

        // get current risk profile record and set value.
        COI_Risk_Profiles objRiskProfile = new COI_Risk_Profiles(PK_COI_Risk_Profile);
        txtName.Text = objRiskProfile.Name;
        txtDateofProfile.Text = clsGeneral.FormatDate(objRiskProfile.DateOfProfile);
        txtAggregateMin.Text = clsGeneral.GetStringValue(objRiskProfile.Aggregate_Minimum);
        txtUmbrellaMin.Text = clsGeneral.GetStringValue(objRiskProfile.Umbrella_Minimum);
        txtGeneralOccur.Text = clsGeneral.GetStringValue(objRiskProfile.General_Occurence_Coverage);
        txtFireDamage.Text = clsGeneral.GetStringValue(objRiskProfile.General_Fire_Damage);
        txtMedicalExpense.Text = clsGeneral.GetStringValue(objRiskProfile.General_Medical_Expense);
        txtPersonalInjury.Text = clsGeneral.GetStringValue(objRiskProfile.General_Personal_Advertising_Inju);
        txtGeneralAggregate.Text = clsGeneral.GetStringValue(objRiskProfile.General_General_Aggregate);
        txtOperations.Text = clsGeneral.GetStringValue(objRiskProfile.General_Products_Operations_Produ);
        txtStopGap.Text = clsGeneral.GetStringValue(objRiskProfile.General_Stop_Gap_Coverage);
        txtAutoCoverage.Text = clsGeneral.GetStringValue(objRiskProfile.General_Auto_Coverage);
        txtCombinedLimit.Text = clsGeneral.GetStringValue(objRiskProfile.Auto_Combined_Single_Limit);
        txtBodilyInjuryPerson.Text = clsGeneral.GetStringValue(objRiskProfile.Auto_Bodily_Injury_Person);
        txtBodilyInjuryAccident.Text = clsGeneral.GetStringValue(objRiskProfile.Auto_Bodily_Injury_Accident);
        txtPropertyDamage.Text = clsGeneral.GetStringValue(objRiskProfile.Auto_Property_Damage);
        txtExcessOccur.Text = clsGeneral.GetStringValue(objRiskProfile.Excess_Occurrence_Coverage);
        txtExcessAggregate.Text = clsGeneral.GetStringValue(objRiskProfile.Excess_Aggregate_Coverage);
        txtRetention.Text = clsGeneral.GetStringValue(objRiskProfile.Excess_Retention_Amount);
        txtAcceptLimit.Text = clsGeneral.GetStringValue(objRiskProfile.Excess_Accept_Limits_Coverage);
        txtUmbrellaLimit.Text = clsGeneral.GetStringValue(objRiskProfile.Excess_Special_Umbrella_Coverage);
        txtWCEachAccident.Text = clsGeneral.GetStringValue(objRiskProfile.WC_Accident);
        txtDiseaseEmployee.Text = clsGeneral.GetStringValue(objRiskProfile.WC_Disease_Each);
        txtDiseacePolicyLimit.Text = clsGeneral.GetStringValue(objRiskProfile.WC_Disease_Limit);
        txtDeductible.Text = clsGeneral.GetStringValue(objRiskProfile.Property_Deductible);
        txtBuildingValue.Text = clsGeneral.GetStringValue(objRiskProfile.Property_Building_Occurrence);
        rdBoilerandMachineryRequired.SelectedValue = objRiskProfile.Boiler_And_Machinery_Required;
        rdEarthquakeRequired.SelectedValue = Convert.ToString(objRiskProfile.Earthquake_Required);
        rdFloodRequired.SelectedValue = Convert.ToString(objRiskProfile.Flood_Required);                
        txtProfOccur.Text = clsGeneral.GetStringValue(objRiskProfile.Professional_Occurence);
        txtProfAggregate.Text = clsGeneral.GetStringValue(objRiskProfile.Professional_Aggregate);
        txtLiquorOccur.Text = clsGeneral.GetStringValue(objRiskProfile.Liquor_Occurence);
        txtLiquorAggregate.Text = clsGeneral.GetStringValue(objRiskProfile.Liquor_Aggregate);
    }

    /// <summary>
    /// Displays the page in view mode
    /// </summary>
    private void BindDetailsForView()
    {
        // show view div
        dvView.Style["Display"] = "block";
        dvBack.Style["Display"] = "block";
        // don't show div edit in viewmode.
        dvEdit.Style["Display"] = "None";       
        btnBack.Style["Display"] = "block";
        btnSave.Style["Display"] = "none";
        dvSave.Style["Display"] = "none";
        _strOperation = "view";
        btnEdit.Visible = true;

        // get record for current risk profile.
        COI_Risk_Profiles objRiskProfile = new COI_Risk_Profiles(PK_COI_Risk_Profile);
        // set values.
        lblName.Text = Convert.ToString(objRiskProfile.Name);
        lblDateofProfile.Text = objRiskProfile.DateOfProfile.ToString(AppConfig.DisplayDateFormat);
        lblAggregateMin.Text = clsGeneral.GetStringValue(objRiskProfile.Aggregate_Minimum);
        lblUmbrellaMin.Text = clsGeneral.GetStringValue(objRiskProfile.Umbrella_Minimum);
        lblGeneralOccur.Text = clsGeneral.GetStringValue(objRiskProfile.General_Occurence_Coverage);
        lblFireDamage.Text = clsGeneral.GetStringValue(objRiskProfile.General_Fire_Damage);
        lblMedicalExpense.Text = clsGeneral.GetStringValue(objRiskProfile.General_Medical_Expense);
        lblPersonalInjury.Text = clsGeneral.GetStringValue(objRiskProfile.General_Personal_Advertising_Inju);
        lblGeneralAggregate.Text = clsGeneral.GetStringValue(objRiskProfile.General_General_Aggregate);
        lblOperations.Text = clsGeneral.GetStringValue(objRiskProfile.General_Products_Operations_Produ);
        lblStopGap.Text = clsGeneral.GetStringValue(objRiskProfile.General_Stop_Gap_Coverage);
        lblAutoCoverage.Text = clsGeneral.GetStringValue(objRiskProfile.General_Auto_Coverage);
        lblCombinedLimit.Text = clsGeneral.GetStringValue(objRiskProfile.Auto_Combined_Single_Limit);
        lblBodilyInjuryPerson.Text = clsGeneral.GetStringValue(objRiskProfile.Auto_Bodily_Injury_Person);
        lblBodilyInjuryAccident.Text = clsGeneral.GetStringValue(objRiskProfile.Auto_Bodily_Injury_Accident);
        lblPropertyDamage.Text = clsGeneral.GetStringValue(objRiskProfile.Auto_Property_Damage);
        lblExcessOccur.Text = clsGeneral.GetStringValue(objRiskProfile.Excess_Occurrence_Coverage);
        lblExcessAggregate.Text = clsGeneral.GetStringValue(objRiskProfile.Excess_Aggregate_Coverage);
        lblRetention.Text = clsGeneral.GetStringValue(objRiskProfile.Excess_Retention_Amount);
        lblAcceptLimit.Text = clsGeneral.GetStringValue(objRiskProfile.Excess_Accept_Limits_Coverage);
        lblUmbrellaLimit.Text = clsGeneral.GetStringValue(objRiskProfile.Excess_Special_Umbrella_Coverage);
        lblWCEachAccident.Text = clsGeneral.GetStringValue(objRiskProfile.WC_Accident);
        lblDiseaseEmployee.Text = clsGeneral.GetStringValue(objRiskProfile.WC_Disease_Each);
        lblDiseacePolicyLimit.Text = clsGeneral.GetStringValue(objRiskProfile.WC_Disease_Limit);
        lblDeductible.Text = clsGeneral.GetStringValue(objRiskProfile.Property_Deductible);
        lblBuildingValue.Text = clsGeneral.GetStringValue(objRiskProfile.Property_Building_Occurrence);
        lblBoilerandMachineryRequired.Text = (objRiskProfile.Boiler_And_Machinery_Required == "Y") ? "Yes" : "No";
        lblFloodRequired.Text = (objRiskProfile.Flood_Required == "Y") ? "Yes" : "No";
        lblEarthquakeRequired.Text = (objRiskProfile.Earthquake_Required == "Y") ? "Yes" : "No";
              
        lblProfOccur.Text = clsGeneral.GetStringValue(objRiskProfile.Professional_Occurence);
        lblProfAggregate.Text = clsGeneral.GetStringValue(objRiskProfile.Professional_Aggregate);
        lblLiquorOccur.Text = clsGeneral.GetStringValue(objRiskProfile.Liquor_Occurence);
        lblLiquorAggregate.Text = clsGeneral.GetStringValue(objRiskProfile.Liquor_Aggregate);
        Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanelView(1);", true);
    }
    #endregion

    #region "Save"
    // add or update risk profile.
    protected void btnSave_Click(object sender, EventArgs e)
    {
        // check page is valid or not.

        if (Page.IsValid)
        {
            // create a new risk profile object.
            COI_Risk_Profiles objRiskProfile = new COI_Risk_Profiles();
            // set primary key. if will be 0 if new risk prfile is to be added.
            objRiskProfile.PK_COI_Risk_Profile = PK_COI_Risk_Profile;
            // set all other values for this object.
            objRiskProfile.Name = txtName.Text;
            if (txtDateofProfile.Text != String.Empty)
                objRiskProfile.DateOfProfile = Convert.ToDateTime(txtDateofProfile.Text);
            objRiskProfile.Aggregate_Minimum = txtAggregateMin.Text.Trim() != string.Empty ? clsGeneral.GetDecimalValue(txtAggregateMin) : 0;
            objRiskProfile.Umbrella_Minimum = txtUmbrellaMin.Text.Trim() != string.Empty ? clsGeneral.GetDecimalValue(txtUmbrellaMin) : 0;
            objRiskProfile.General_Occurence_Coverage = clsGeneral.GetDecimalValue(txtGeneralOccur);
            objRiskProfile.General_Fire_Damage = clsGeneral.GetDecimalValue(txtFireDamage);
            objRiskProfile.General_Medical_Expense = clsGeneral.GetDecimalValue(txtMedicalExpense);
            objRiskProfile.General_Personal_Advertising_Inju = clsGeneral.GetDecimalValue(txtPersonalInjury);
            objRiskProfile.General_General_Aggregate = clsGeneral.GetDecimalValue(txtGeneralAggregate);
            objRiskProfile.General_Products_Operations_Produ = clsGeneral.GetDecimalValue(txtOperations);
            objRiskProfile.General_Stop_Gap_Coverage = clsGeneral.GetDecimalValue(txtStopGap);
            objRiskProfile.General_Auto_Coverage = clsGeneral.GetDecimalValue(txtAutoCoverage);
            objRiskProfile.Auto_Combined_Single_Limit = clsGeneral.GetDecimalValue(txtCombinedLimit);
            objRiskProfile.Auto_Bodily_Injury_Person = clsGeneral.GetDecimalValue(txtBodilyInjuryPerson);
            objRiskProfile.Auto_Bodily_Injury_Accident = clsGeneral.GetDecimalValue(txtBodilyInjuryAccident);
            objRiskProfile.Auto_Property_Damage = clsGeneral.GetDecimalValue(txtPropertyDamage);
            objRiskProfile.Excess_Occurrence_Coverage = clsGeneral.GetDecimalValue(txtExcessOccur);
            objRiskProfile.Excess_Aggregate_Coverage = clsGeneral.GetDecimalValue(txtExcessAggregate);
            objRiskProfile.Excess_Retention_Amount = clsGeneral.GetDecimalValue(txtRetention);
            objRiskProfile.Excess_Accept_Limits_Coverage = clsGeneral.GetDecimalValue(txtAcceptLimit);
            objRiskProfile.Excess_Special_Umbrella_Coverage = clsGeneral.GetDecimalValue(txtUmbrellaLimit);
            objRiskProfile.WC_Accident = clsGeneral.GetDecimalValue(txtWCEachAccident);
            objRiskProfile.WC_Disease_Each = clsGeneral.GetDecimalValue(txtDiseaseEmployee);
            objRiskProfile.WC_Disease_Limit = clsGeneral.GetDecimalValue(txtDiseacePolicyLimit);
            objRiskProfile.Property_Deductible = clsGeneral.GetDecimalValue(txtDeductible);
            objRiskProfile.Property_Building_Occurrence = clsGeneral.GetDecimalValue(txtBuildingValue);
            objRiskProfile.Boiler_And_Machinery_Required = Convert.ToString(rdBoilerandMachineryRequired.SelectedValue);
            objRiskProfile.Earthquake_Required = Convert.ToString(rdEarthquakeRequired.SelectedValue);
            objRiskProfile.Flood_Required = Convert.ToString(rdFloodRequired.SelectedValue);
                     
            objRiskProfile.Professional_Occurence = clsGeneral.GetDecimalValue(txtProfOccur);
            objRiskProfile.Professional_Aggregate = clsGeneral.GetDecimalValue(txtProfAggregate);
            objRiskProfile.Liquor_Occurence = clsGeneral.GetDecimalValue(txtLiquorOccur);
            objRiskProfile.Liquor_Aggregate = clsGeneral.GetDecimalValue(txtLiquorAggregate);
            objRiskProfile.Update_Date = DateTime.Today;
            objRiskProfile.Updated_By = clsSession.UserName;

            // if risk profile is in update mode
            if (PK_COI_Risk_Profile > 0)
                objRiskProfile.Update();
            else
                // if new risk profile is added.
                PK_COI_Risk_Profile = objRiskProfile.Insert();
            // add attachment if any.
            Attachment.Add(clsGeneral.Tables.Risk_Profile, PK_COI_Risk_Profile);
            // set attachment details control in readonly mode.
            AttachDetails.InitializeAttachmentDetails(clsGeneral.Tables.Risk_Profile, PK_COI_Risk_Profile, false, 9);
            BindAttachmentDetails();
            BindDetailsForView();
            dvAttachment.Style["Display"] = "none";
            btnPrev.Visible = false;
            btnNext.Visible = false;
        }
    }
    #endregion

    #region "Attachments Management"
    /// <summary>
    /// Bind Attachment Control Details
    /// </summary> 
    private void BindAttachmentDetails()
    {
        dvAttachment.Style["Display"] = "block";
        AttachDetails.Bind();
    }
    /// <summary>
    /// Handles Attachment control in Add Attachment button click event 
    /// </summary>
    /// <param name="sender"></param>   
    protected void Attachment_btnHandler(object sender)
    {
        if (PK_COI_Risk_Profile > 0)
        {
            // add attachment if any.
            Attachment.Add(clsGeneral.Tables.Risk_Profile, PK_COI_Risk_Profile);
            // Bind the attachment detail to view the added attachment
            BindAttachmentDetails();
            // show attachment panel as the page is loaded again
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(9);", true);
        }
        else
            ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript: alert('Please save Risk Profile First');ShowPanel(1);", true);
    }
    #endregion

    #region "Other cotrols events"
    /// <summary>
    /// Handle Back Button Click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("RiskProfileList.aspx");
    }
    /// <summary>
    /// Handle Edit Button Click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnEdit_Click(object sender, EventArgs e)
    {
        Response.Redirect("RiskProfileAddEdit.aspx?op=edit&id=" + Encryption.Encrypt(PK_COI_Risk_Profile.ToString()));
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

        #region "Identification"
        DataTable dtFields = clsScreen_Validators.SelectByScreen(112).Tables[0];
        dtFields.DefaultView.RowFilter = "IsRequired = '1'";
        dtFields = dtFields.DefaultView.ToTable();
        MenuAsterisk1.Style["display"] = (dtFields.Select("LeftMenuIndex = 1").Length > 0) ? "inline-block" : "none";
        foreach (DataRow drField in dtFields.Rows)
        {
            #region " set validation control IDs and messages "
            switch (Convert.ToString(drField["Field_Name"]))
            {
                case "Name":
                    strCtrlsIDs += txtName.ClientID + ",";
                    strMessages += "Please enter [Identification]/Name" + ",";
                    Span1.Style["display"] = "inline-block";
                    break;
                case "Date of Profile ":
                    strCtrlsIDs += txtDateofProfile.ClientID + ",";
                    strMessages += "Please enter [Identification]/Date of Profile " + ",";
                    Span2.Style["display"] = "inline-block";
                    break;
                case "Aggregate Minimum":
                    strCtrlsIDs += txtAggregateMin.ClientID + ",";
                    strMessages += "Please enter [Identification]/Aggregate Minimum" + ",";
                    Span3.Style["display"] = "inline-block";
                    break;
                case "Umbrella Minimum":
                    strCtrlsIDs += txtUmbrellaMin.ClientID + ",";
                    strMessages += "Please enter [Identification]/Umbrella Minimum" + ",";
                    Span4.Style["display"] = "inline-block";
                    break;
            }
            #endregion
        }
        #endregion

        #region "General - Minimum Limits"
        dtFields = clsScreen_Validators.SelectByScreen(113).Tables[0];
        dtFields.DefaultView.RowFilter = "IsRequired = '1'";
        dtFields = dtFields.DefaultView.ToTable();
        MenuAsterisk2.Style["display"] = (dtFields.Select("LeftMenuIndex = 2").Length > 0) ? "inline-block" : "none";
        foreach (DataRow drField in dtFields.Rows)
        {
            switch (Convert.ToString(drField["Field_Name"]))
            {
                case "General - Each Occurrence":
                    strCtrlsIDs += txtGeneralOccur.ClientID + ",";
                    strMessages += "Please enter [General – Minimum Limits]/Each Occurrence" + ",";
                    Span5.Style["display"] = "inline-block";
                    break;
                case "Fire Damage":
                    strCtrlsIDs += txtFireDamage.ClientID + ",";
                    strMessages += "Please enter [General – Minimum Limits]/Fire Damage" + ",";
                    Span6.Style["display"] = "inline-block";
                    break;
                case "Medical Expense":
                    strCtrlsIDs += txtMedicalExpense.ClientID + ",";
                    strMessages += "Please enter [General – Minimum Limits]/Medical Expense" + ",";
                    Span7.Style["display"] = "inline-block";
                    break;
                case "Personal & Advertising Injury":
                    strCtrlsIDs += txtPersonalInjury.ClientID + ",";
                    strMessages += "Please enter [General – Minimum Limits]/Personal & Advertising Injury" + ",";
                    Span8.Style["display"] = "inline-block";
                    break;
                case "General Aggregate":
                    strCtrlsIDs += txtGeneralAggregate.ClientID + ",";
                    strMessages += "Please enter [General – Minimum Limits]/General Aggregate" + ",";
                    Span9.Style["display"] = "inline-block";
                    break;
                case "Completed Operations":
                    strCtrlsIDs += txtOperations.ClientID + ",";
                    strMessages += "Please enter [General – Minimum Limits]/Completed Operations" + ",";
                    Span10.Style["display"] = "inline-block";
                    break;
                case "Stop Gap Endorsement":
                    strCtrlsIDs += txtStopGap.ClientID + ",";
                    strMessages += "Please enter [General – Minimum Limits]/Stop Gap Endorsement" + ",";
                    Span11.Style["display"] = "inline-block";
                    break;
                case "Auto (If no owned vehicles in BOP)":
                    strCtrlsIDs += txtAutoCoverage.ClientID + ",";
                    strMessages += "Please enter [General – Minimum Limits]/Auto (If no owned vehicles in BOP)" + ",";
                    Span12.Style["display"] = "inline-block";
                    break;
            }
        }
        #endregion

        #region "Auto - Minimum Limits"
        dtFields = clsScreen_Validators.SelectByScreen(114).Tables[0];
        dtFields.DefaultView.RowFilter = "IsRequired = '1'";
        dtFields = dtFields.DefaultView.ToTable();
        MenuAsterisk3.Style["display"] = (dtFields.Select("LeftMenuIndex = 3").Length > 0) ? "inline-block" : "none";
        foreach (DataRow drField in dtFields.Rows)
        {
            switch (Convert.ToString(drField["Field_Name"]))
            {
                case "Combined Single Limit":
                    strCtrlsIDs += txtCombinedLimit.ClientID + ",";
                    strMessages += "Please enter [Auto – Minimum Limits]/Combined Single Limit" + ",";
                    Span13.Style["display"] = "inline-block";
                    break;
                case "Bodily Injury (Per Person)":
                    strCtrlsIDs += txtBodilyInjuryPerson.ClientID + ",";
                    strMessages += "Please enter [Auto – Minimum Limits]/Bodily Injury (Per Person)" + ",";
                    Span14.Style["display"] = "inline-block";
                    break;
                case "Bodily Injury (Per Accident)":
                    strCtrlsIDs += txtBodilyInjuryAccident.ClientID + ",";
                    strMessages += "Please enter [Auto – Minimum Limits]/Bodily Injury (Per Accident)" + ",";
                    Span15.Style["display"] = "inline-block";
                    break;
                case "Property Damage":
                    strCtrlsIDs += txtPropertyDamage.ClientID + ",";
                    strMessages += "Please enter [Auto – Minimum Limits]/Property Damage" + ",";
                    Span16.Style["display"] = "inline-block";
                    break;
            }
        }
        #endregion

        #region "Excess - Minimum Limits"
        dtFields = clsScreen_Validators.SelectByScreen(115).Tables[0];
        dtFields.DefaultView.RowFilter = "IsRequired = '1'";
        dtFields = dtFields.DefaultView.ToTable();
        MenuAsterisk4.Style["display"] = (dtFields.Select("LeftMenuIndex = 4").Length > 0) ? "inline-block" : "none";
        foreach (DataRow drField in dtFields.Rows)
        {
            switch (Convert.ToString(drField["Field_Name"]))
            {
                case "Excess - Each Occurrence":
                    strCtrlsIDs += txtExcessOccur.ClientID + ",";
                    strMessages += "Please enter [Excess – Minimum Limits]/Each Occurrence" + ",";
                    Span17.Style["display"] = "inline-block";
                    break;
                case "Excess - Aggregate":
                    strCtrlsIDs += txtExcessAggregate.ClientID + ",";
                    strMessages += "Please enter [Excess – Minimum Limits]/Aggregate" + ",";
                    Span18.Style["display"] = "inline-block";
                    break;
                case "Retention":
                    strCtrlsIDs += txtRetention.ClientID + ",";
                    strMessages += "Please enter [Excess – Minimum Limits]/Retention" + ",";
                    Span19.Style["display"] = "inline-block";
                    break;
                case "Accept Limits":
                    strCtrlsIDs += txtAcceptLimit.ClientID + ",";
                    strMessages += "Please enter [Excess – Minimum Limits]/Accept Limits" + ",";
                    Span20.Style["display"] = "inline-block";
                    break;
                case "Special Umbrella Limits":
                    strCtrlsIDs += txtUmbrellaLimit.ClientID + ",";
                    strMessages += "Please enter [Excess – Minimum Limits]/Special Umbrella Limits" + ",";
                    Span21.Style["display"] = "inline-block";
                    break;
            }
        }
        #endregion

        #region "Worker’s Compensation - Minimum Limits"
        dtFields = clsScreen_Validators.SelectByScreen(116).Tables[0];
        dtFields.DefaultView.RowFilter = "IsRequired = '1'";
        dtFields = dtFields.DefaultView.ToTable();
        MenuAsterisk5.Style["display"] = (dtFields.Select("LeftMenuIndex = 5").Length > 0) ? "inline-block" : "none";
        foreach (DataRow drField in dtFields.Rows)
        {
            switch (Convert.ToString(drField["Field_Name"]))
            {
                case "Each Accident":
                    strCtrlsIDs += txtWCEachAccident.ClientID + ",";
                    strMessages += "Please enter [Worker’s Compensation – Minimum Limits]/Each Accident" + ",";
                    Span22.Style["display"] = "inline-block";
                    break;
                case "Disease – Each Employee":
                    strCtrlsIDs += txtDiseaseEmployee.ClientID + ",";
                    strMessages += "Please enter [Worker’s Compensation – Minimum Limits]/Disease – Each Employee" + ",";
                    Span23.Style["display"] = "inline-block";
                    break;
                case "Disease – Policy Limit":
                    strCtrlsIDs += txtDiseacePolicyLimit.ClientID + ",";
                    strMessages += "Please enter [Worker’s Compensation – Minimum Limits]/Disease – Policy Limit" + ",";
                    Span24.Style["display"] = "inline-block";
                    break;                
            }
        }
        #endregion

        #region "Property - Minimum Limits"
        dtFields = clsScreen_Validators.SelectByScreen(117).Tables[0];
        dtFields.DefaultView.RowFilter = "IsRequired = '1'";
        dtFields = dtFields.DefaultView.ToTable();
        MenuAsterisk6.Style["display"] = (dtFields.Select("LeftMenuIndex = 6").Length > 0) ? "inline-block" : "none";
        foreach (DataRow drField in dtFields.Rows)
        {
            switch (Convert.ToString(drField["Field_Name"]))
            {
                case "Deductible":
                    strCtrlsIDs += txtDeductible.ClientID + ",";
                    strMessages += "Please enter [Property – Minimum Limits]/Deductible" + ",";
                    Span25.Style["display"] = "inline-block";
                    break;
                case "Building Value":
                    strCtrlsIDs += txtBuildingValue.ClientID + ",";
                    strMessages += "Please enter [Property – Minimum Limits]/Building Value" + ",";
                    Span26.Style["display"] = "inline-block";
                    break;
            }
        }
        #endregion

        #region "Professional Liability - Minimum Limits"
        dtFields = clsScreen_Validators.SelectByScreen(118).Tables[0];
        dtFields.DefaultView.RowFilter = "IsRequired = '1'";
        dtFields = dtFields.DefaultView.ToTable();
        MenuAsterisk7.Style["display"] = (dtFields.Select("LeftMenuIndex = 7").Length > 0) ? "inline-block" : "none";
        foreach (DataRow drField in dtFields.Rows)
        {
            switch (Convert.ToString(drField["Field_Name"]))
            {                
                case "Professional - Each Occurrence":
                    strCtrlsIDs += txtProfOccur.ClientID + ",";
                    strMessages += "Please enter [Professional Liability – Minimum Limits]/Each Occurrence" + ",";
                    Span30.Style["display"] = "inline-block";
                    break;
                case "Professional - Aggregate":
                    strCtrlsIDs += txtProfAggregate.ClientID + ",";
                    strMessages += "Please enter [Professional Liability – Minimum Limits]/Aggregate" + ",";
                    Span31.Style["display"] = "inline-block";
                    break;               
            }
        }
        #endregion

        #region "Other Liability - Minimum Limits"
        dtFields = clsScreen_Validators.SelectByScreen(119).Tables[0];
        dtFields.DefaultView.RowFilter = "IsRequired = '1'";
        dtFields = dtFields.DefaultView.ToTable();
        MenuAsterisk8.Style["display"] = (dtFields.Select("LeftMenuIndex = 8").Length > 0) ? "inline-block" : "none";
        foreach (DataRow drField in dtFields.Rows)
        {
            switch (Convert.ToString(drField["Field_Name"]))
            {
                case "Other - Each Occurrence":
                    strCtrlsIDs += txtLiquorOccur.ClientID + ",";
                    strMessages += "Please enter [Other Liability – Minimum Limits]/Each Occurrence" + ",";
                    Span32.Style["display"] = "inline-block";
                    break;
                case "Other - Aggregate":
                    strCtrlsIDs += txtLiquorAggregate.ClientID + ",";
                    strMessages += "Please enter [Other Liability – Minimum Limits]/Aggregate" + ",";
                    Span33.Style["display"] = "inline-block";
                    break;                
            }
        }
        #endregion

        strCtrlsIDs = strCtrlsIDs.TrimEnd(',');
        strMessages = strMessages.TrimEnd(',');

        hdnControlIDs.Value = strCtrlsIDs;
        hdnErrorMsgs.Value = strMessages;

    }

    #endregion
}
