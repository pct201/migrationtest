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
using ERIMS.DAL;
public partial class Admin_GeneralPolicyAddEdit : clsBasePage
{
    #region "Properties"
    string _strOperation = "";
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
    // FK to indicate Producer is for which COI
    public int FK_COI
    {
        get
        {
            return clsGeneral.GetInt(ViewState["COI"]);
        }
        set { ViewState["COI"] = value; }

    }

    // PK for Producer
    public int PK_COI_General_Policies
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PolicyID"]);
        }
        set { ViewState["PolicyID"] = value; }
    }

    #endregion

    #region "Page Events"
    /// <summary>
    /// Handle Page Load Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        // if page is loaded first time.
        if (!IsPostBack)
        {
            if (!clsGeneral.IsNull(Request.QueryString["pnl"]))
                Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(" + Request.QueryString["pnl"] + ");", true);
            else
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "ShowPanel", "javascript:ShowPanel(1);", true);
            if (App_Access == AccessType.NotAssigned)
                Response.Redirect(AppConfig.SiteURL + "Message.aspx?msg=You are not authorized to access this page");
            else
            {
                // if COI's FK is not passed redirect to default page.
                if (!clsGeneral.IsNull(Request.QueryString["coi"]))
                {
                    // set FK Coi.
                    FK_COI = Convert.ToInt32(clsGeneral.GetQueryStringID(Request.QueryString["coi"]));
                    // Load COI Control
                    ucCtrlCOIInfo.PK_COIs = FK_COI;
                    ucCtrlCOIInfo.BindrCOIInfo();

                    //Bind Insurance company drop down
                    clsGeneral.FillIsuranceCompanyDropDown(drpCompany, FK_COI);

                    // if operations(view or edit) is passed in query string.
                    if (!clsGeneral.IsNull(Request.QueryString["op"]))
                    {
                        // if id is passed set primary key.
                        if (!clsGeneral.IsNull(Request.QueryString["id"]))
                        {
                            PK_COI_General_Policies = (int)clsGeneral.GetQueryStringID(Convert.ToString(Request.QueryString["id"]));
                        }

                        _strOperation = Request.QueryString["op"];
                        if (Request.QueryString["op"] == "view")
                        {
                            dvView.Style["Display"] = "block";
                            BindDetailsForView();
                            BindInsuredGrid();
                            // set Attachment details control in read/write mode.
                            AttachDetails.InitializeAttachmentDetails(clsGeneral.Tables.General_Liability_Policies, PK_COI_General_Policies, false, 3);

                        }
                        else
                        {
                            if (App_Access == AccessType.Administrative_Access)
                            {
                                // set Attachment details control in read/write mode.
                                AttachDetails.InitializeAttachmentDetails(clsGeneral.Tables.General_Liability_Policies, PK_COI_General_Policies, true, 3);
                                BindDetailsForEdit();
                                BindInsuredGrid();
                            }
                            else
                                Response.Redirect(Request.Url.ToString().Replace("edit", "view"));
                        }
                        BindAttachmentDetails();
                    }
                    else
                    {
                        if (App_Access != AccessType.Administrative_Access)
                            Response.Redirect(AppConfig.SiteURL + "Message.aspx?msg=You are not authorized to access this page");
                    }
                }
                else
                {
                    Response.Redirect("Default.aspx");
                }
                SetValidations();
                drpCompany.Focus();
            }
        }
        Button btnAttachment = ((Button)Attachment.FindControl("btnAddAttachment"));
        if (btnAttachment != null)
            btnAttachment.Attributes.Add("onClick", "javascript:return CheckForValidation();");
    }

    #endregion

    # region " Private Methods "
    /// <summary>
    /// Bind Attachment Detail
    /// </summary>
    private void BindAttachmentDetails()
    {
        dvAttachment.Style["Display"] = "block";
        AttachDetails.Bind();
    }

    /// <summary>
    /// Bind Insured Grid
    /// </summary>
    private void BindInsuredGrid()
    {
        DataTable dtAI = COI_AI.SelectByFK_COI_Locations(PK_COI_General_Policies, "General_Policy").Tables[0];
        gvAI.DataSource = dtAI;
        gvAI.DataBind();
        gvAI.Columns[2].Visible = (Request.QueryString["op"] == "view") ? false : true;
    }
    /// <summary>
    /// Add a new and update record
    /// </summary>
    private void SaveRecord()
    {
        // create a new object for producer.
        COI_General_Policies objGeneralPolicy = new COI_General_Policies();

        //set values.
        objGeneralPolicy.PK_COI_General_Policies = PK_COI_General_Policies;
        objGeneralPolicy.FK_COIs = FK_COI;
        objGeneralPolicy.Insurance_Company = drpCompany.SelectedValue;
        objGeneralPolicy.Policy_Number = txtPolicyNumber.Text.Trim();
        objGeneralPolicy.Issue_Date = txtIssueDate.DateValue;
        objGeneralPolicy.Effective_Date = txtEffectiveDate.DateValue;
        objGeneralPolicy.Expiration_Date = txtExpirationDate.DateValue;
        objGeneralPolicy.Cancellation_Date = txtCancellationDate.DateValue;
        objGeneralPolicy.Commercial_Liability = rdoCommercialLiability.SelectedValue;
        objGeneralPolicy.Product_Liability = rdoProductLiability.SelectedValue;
        objGeneralPolicy.Occurrence_Liability = rdoOccurrenceLiability.SelectedValue;
        objGeneralPolicy.Stop_Gap_Endorsement = rdoStopGapEndorsement.SelectedValue;
        objGeneralPolicy.Auto_Liability = rdoAutoLiability.SelectedValue;
        objGeneralPolicy.Occurrence_Covereage = clsGeneral.GetDecimalValue(txtOccuranceCoverage);
        objGeneralPolicy.Fire_Damage = clsGeneral.GetDecimalValue(txtFireDamage);
        objGeneralPolicy.Medical_Expense = clsGeneral.GetDecimalValue(txtMedicalExpense);
        objGeneralPolicy.Personal_Advertising_Injury = clsGeneral.GetDecimalValue(txtPersonalInjury);
        objGeneralPolicy.General_Aggregate = clsGeneral.GetDecimalValue(txtGeneralAggregate);
        objGeneralPolicy.Products_Operations = clsGeneral.GetDecimalValue(txtProductOperations);
        objGeneralPolicy.Other_Liability1 = txtOtherLiability1.Text.Trim();
        objGeneralPolicy.Other_Liability_Coverage1 = clsGeneral.GetDecimalValue(txtOtherLiabilityCoverage1);
        objGeneralPolicy.Other_Liability2 = txtOtherLiability2.Text.Trim();
        objGeneralPolicy.Other_Liability_Coverage2 = clsGeneral.GetDecimalValue(txtOtherLiabilityCoverage2);
        objGeneralPolicy.Stop_Gap_Coverage = clsGeneral.GetDecimalValue(txtStopGapCoverage);
        objGeneralPolicy.Auto_Coverage = clsGeneral.GetDecimalValue(txtAutoCoverage);
        objGeneralPolicy.Notes = txtNotes.Text.Trim();
        objGeneralPolicy.Update_Date = DateTime.Today;
        objGeneralPolicy.Updated_By = clsSession.UserName;
        objGeneralPolicy.GALimitAppliesTo = Convert.ToInt32(rdoGAappliesTo.SelectedValue);

        // check if insert or update the producer.
        if (PK_COI_General_Policies > 0)
            objGeneralPolicy.Update();
        else
            PK_COI_General_Policies = objGeneralPolicy.Insert();

        // add attachment if any
        Attachment.Add(clsGeneral.Tables.General_Liability_Policies, PK_COI_General_Policies);
    }
    #endregion

    #region "Bind Details for Edit or View"

    /// <summary>
    /// Displays the page in edit mode
    /// </summary>
    private void BindDetailsForEdit()
    {
        dvView.Style["Display"] = "None";
        // create object for curernt Producer
        COI_General_Policies objGeneralPolicy = new COI_General_Policies(PK_COI_General_Policies);

        // set values
        rdoGAappliesTo.SelectedValue = Convert.ToString(objGeneralPolicy.GALimitAppliesTo);
        drpCompany.SelectedValue = objGeneralPolicy.Insurance_Company;
        txtPolicyNumber.Text = objGeneralPolicy.Policy_Number;
        txtIssueDate.DateValue = objGeneralPolicy.Issue_Date;
        txtEffectiveDate.DateValue = objGeneralPolicy.Effective_Date;
        txtExpirationDate.DateValue = objGeneralPolicy.Expiration_Date;
        txtCancellationDate.DateValue = objGeneralPolicy.Cancellation_Date;
        rdoCommercialLiability.SelectedValue = objGeneralPolicy.Commercial_Liability;
        rdoProductLiability.SelectedValue = objGeneralPolicy.Product_Liability;
        rdoOccurrenceLiability.SelectedValue = objGeneralPolicy.Occurrence_Liability;
        rdoStopGapEndorsement.SelectedValue = objGeneralPolicy.Stop_Gap_Endorsement;
        rdoAutoLiability.SelectedValue = objGeneralPolicy.Auto_Liability;
        txtOccuranceCoverage.Text = clsGeneral.GetStringValue(objGeneralPolicy.Occurrence_Covereage);
        txtFireDamage.Text = clsGeneral.GetStringValue(objGeneralPolicy.Fire_Damage);
        txtMedicalExpense.Text = clsGeneral.GetStringValue(objGeneralPolicy.Medical_Expense);
        txtPersonalInjury.Text = clsGeneral.GetStringValue(objGeneralPolicy.Personal_Advertising_Injury);
        txtGeneralAggregate.Text = clsGeneral.GetStringValue(objGeneralPolicy.General_Aggregate);
        txtProductOperations.Text = clsGeneral.GetStringValue(objGeneralPolicy.Products_Operations);
        txtOtherLiability1.Text = objGeneralPolicy.Other_Liability1;
        txtOtherLiabilityCoverage1.Text = clsGeneral.GetStringValue(objGeneralPolicy.Other_Liability_Coverage1);
        txtOtherLiability2.Text = objGeneralPolicy.Other_Liability2;
        txtOtherLiabilityCoverage2.Text = clsGeneral.GetStringValue(objGeneralPolicy.Other_Liability_Coverage2);
        txtStopGapCoverage.Text = clsGeneral.GetStringValue(objGeneralPolicy.Stop_Gap_Coverage);
        txtAutoCoverage.Text = clsGeneral.GetStringValue(objGeneralPolicy.Auto_Coverage);
        txtNotes.Text = objGeneralPolicy.Notes;
    }

    /// <summary>
    /// Displays the page in view mode
    /// </summary>
    private void BindDetailsForView()
    {
        dvEdit.Style["Display"] = "None";
        // create object for curernt Producer
        COI_General_Policies objGeneralPolicy = new COI_General_Policies(PK_COI_General_Policies);

        // set values
        lblCompany.Text = objGeneralPolicy.Insurance_Company;
        lblPolicyNumber.Text = objGeneralPolicy.Policy_Number;
        lblIssueDate.Text = objGeneralPolicy.Issue_Date.ToString(AppConfig.DisplayDateFormat);
        lblEffectiveDate.Text = objGeneralPolicy.Effective_Date.ToString(AppConfig.DisplayDateFormat);
        lblExpirationDate.Text = objGeneralPolicy.Expiration_Date.ToString(AppConfig.DisplayDateFormat);
        lblCancellationDate.Text = clsGeneral.FormatDate(objGeneralPolicy.Cancellation_Date);
        lblCommercialLiability.Text = (objGeneralPolicy.Commercial_Liability == "Y") ? "YES" : "NO";
        lblProductLiability.Text = (objGeneralPolicy.Product_Liability == "Y") ? "YES" : "NO";
        lblOccurrenceLiability.Text = (objGeneralPolicy.Occurrence_Liability == "Y") ? "YES" : "NO";
        lblStopGapEndorsement.Text = (objGeneralPolicy.Stop_Gap_Endorsement == "Y") ? "YES" : "NO";
        lblAutoLiability.Text = (objGeneralPolicy.Auto_Liability == "Y") ? "YES" : "NO";
        lblOccuranceCoverage.Text = clsGeneral.GetStringValue(objGeneralPolicy.Occurrence_Covereage);
        lblFireDamage.Text = clsGeneral.GetStringValue(objGeneralPolicy.Fire_Damage);
        lblMedicalExpense.Text = clsGeneral.GetStringValue(objGeneralPolicy.Medical_Expense);
        lblPersonalInjury.Text = clsGeneral.GetStringValue(objGeneralPolicy.Personal_Advertising_Injury);
        lblGeneralAggregate.Text = clsGeneral.GetStringValue(objGeneralPolicy.General_Aggregate);
        lblProductOperations.Text = clsGeneral.GetStringValue(objGeneralPolicy.Products_Operations);
        lblOtherLiability1.Text = objGeneralPolicy.Other_Liability1;
        lblOtherLiabilityCoverage1.Text = clsGeneral.GetStringValue(objGeneralPolicy.Other_Liability_Coverage1);
        lblOtherLiability2.Text = objGeneralPolicy.Other_Liability2;
        lblOtherLiabilityCoverage2.Text = clsGeneral.GetStringValue(objGeneralPolicy.Other_Liability_Coverage2);
        lblStopGapCoverage.Text = clsGeneral.GetStringValue(objGeneralPolicy.Stop_Gap_Coverage);
        lblAutoCoverage.Text = clsGeneral.GetStringValue(objGeneralPolicy.Auto_Coverage);
        lblNotes.Text = objGeneralPolicy.Notes;
        if (objGeneralPolicy.GALimitAppliesTo == 1)
            lblGaAppliesTo.Text = "Policy";
        else if (objGeneralPolicy.GALimitAppliesTo == 2)
            lblGaAppliesTo.Text = "Project";
        else if (objGeneralPolicy.GALimitAppliesTo == 3)
            lblGaAppliesTo.Text = "Location";
        else if (objGeneralPolicy.GALimitAppliesTo == 0)
            lblGaAppliesTo.Text = "N/A";

        lnkGeneralAdd.Style["Display"] = "None";
    }

    #endregion

    #region " Control Events "

    /// <summary>
    /// Handle GridView Row Command Event in Remove data 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvAI_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "RemoveInsured")
        {
            COI_AI.Delete(Convert.ToDecimal(e.CommandArgument));
            BindInsuredGrid();
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "ShowPanel", "javascript:ShowPanel(2);", true);
        }
    }

    // add or update producer record
    protected void btnSave_Click(object sender, EventArgs e)
    {
        // check page is valid or not.        
        if (Page.IsValid)
        {
            SaveRecord();
            btnBack_Click(sender, e);
        }
    }
    /// <summary>
    /// Attachment control add attachment button click event
    /// </summary>
    /// <param name="sender"></param>
    protected void Attachment_btnHandler(object sender)
    {
        // check if producer reocord is saved or not.
        // if not don't save any attachment
        if (PK_COI_General_Policies > 0)
        {
            Attachment.Add(clsGeneral.Tables.General_Liability_Policies, PK_COI_General_Policies);

            // after saving attachment bind attachment details again.
            BindAttachmentDetails();
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "ShowPanel", "javascript:ShowPanel(3);", true);
        }
        else
            ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript: alert('Please save General Liability Policies First');ShowPanel(1);", true);
    }
    /// <summary>
    /// DummyForSave Button Click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnDummyForSave_Click(object sender, EventArgs e)
    {
        SaveRecord();
        string strPath = string.Empty;

        if (!string.IsNullOrEmpty(hdnPageName.Value))
        {
            if (hdnPageName.Value.IndexOf("?") > 0)
                strPath = hdnPageName.Value + "&Page=GL&prop=" + Encryption.Encrypt(PK_COI_General_Policies.ToString()) + "&coi=" + Encryption.Encrypt(FK_COI.ToString()) + "&op=" + Request.QueryString["op"];
            else
                strPath = hdnPageName.Value + "?Page=GL&prop=" + Encryption.Encrypt(PK_COI_General_Policies.ToString()) + "&coi=" + Encryption.Encrypt(FK_COI.ToString());
            Response.Redirect(strPath);
        }
    }
    /// <summary>
    /// Handle Return button click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnReturn_Click(object sender, EventArgs e)
    {
        // redirect to COI page without changes done to producer band      
        btnBack_Click(sender, e);
    }
    /// <summary>
    /// Handle Back button Click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnBack_Click(object sender, EventArgs e)
    {
        if (!clsGeneral.IsNull(Request.QueryString["op"]))
            Response.Redirect("COIAddEdit.aspx?op=" + Request.QueryString["op"] + "&coi=" + Request.QueryString["coi"] + "&id=" + Encryption.Encrypt(FK_COI.ToString()) + "&pnl=7");
        else
            Response.Redirect("COIAddEdit.aspx?op=edit" + "&coi=" + Request.QueryString["coi"] + "&id=" + Encryption.Encrypt(FK_COI.ToString()) + "&pnl=7");
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
       
        #region "General Liability Policies"

        DataTable dtFields = clsScreen_Validators.SelectByScreen(102).Tables[0];
        dtFields.DefaultView.RowFilter = "IsRequired = '1'";
        dtFields = dtFields.DefaultView.ToTable();
        MenuAsterisk1.Style["display"] = (dtFields.Select("LeftMenuIndex = 7").Length > 0) ? "inline-block" : "none";
        foreach (DataRow drField in dtFields.Rows)
        {
            #region " set validation control IDs and messages "
            switch (Convert.ToString(drField["Field_Name"]))
            {
                case "Insurance Company":
                    strCtrlsIDs += drpCompany.ClientID + ",";
                    strMessages += "Please select [General Liability Policies]/Insurance Company" + ",";
                    Span1.Style["display"] = "inline-block";
                    break;
                case "Policy Number":
                    strCtrlsIDs += txtPolicyNumber.ClientID + ",";
                    strMessages += "Please enter [General Liability Policies]/Policy Number" + ",";
                    Span2.Style["display"] = "inline-block";
                    break;
                case "Issue Date":                    
                    txtIssueDate.IsRequiredField = true;
                    Span3.Style["display"] = "inline-block";
                    break;
                case "Effective Date":                    
                    txtEffectiveDate.IsRequiredField = true;                    
                    Span4.Style["display"] = "inline-block";
                    break;
                case "Expiration Date":                    
                    txtExpirationDate.IsRequiredField = true;                    
                    Span5.Style["display"] = "inline-block";
                    break;
                case "Cancellation Date":                    
                    txtCancellationDate.IsRequiredField = true;                    
                    Span6.Style["display"] = "inline-block";
                    break;
                //case "Commercial General Liability":
                //    strCtrlsIDs += rdoCommercialLiability.ClientID + ",";
                //    strMessages += "Please enter Commercial General Liability" + ",";
                //    Span7.Style["display"] = "inline-block";
                //    break;
                case "Each Occurrence":
                    strCtrlsIDs += txtOccuranceCoverage.ClientID + ",";
                    strMessages += "Please enter [General Liability Policies]/Each Occurrence" + ",";
                    Span8.Style["display"] = "inline-block";
                    break;
                //case "Product Liability":
                //    strCtrlsIDs += rdoProductLiability.ClientID + ",";
                //    strMessages += "Please enter Product Liability" + ",";
                //    Span9.Style["display"] = "inline-block";
                //    break;
                case "Fire Damage":
                    strCtrlsIDs += txtFireDamage.ClientID + ",";
                    strMessages += "Please enter [General Liability Policies]/Fire Damage" + ",";
                    Span10.Style["display"] = "inline-block";
                    break;
                //case "Occurrence":
                //    strCtrlsIDs += rdoOccurrenceLiability.ClientID + ",";
                //    strMessages += "Please enter Occurrence" + ",";
                //    Span11.Style["display"] = "inline-block";
                //    break;
                case "Medical Expense":
                    strCtrlsIDs += txtMedicalExpense.ClientID + ",";
                    strMessages += "Please enter [General Liability Policies]/Medical Expense" + ",";
                    Span12.Style["display"] = "inline-block";
                    break;
                case "Personal & Advertising Injury":
                    strCtrlsIDs += txtPersonalInjury.ClientID + ",";
                    strMessages += "Please enter [General Liability Policies]/Personal & Advertising Injury" + ",";
                    Span13.Style["display"] = "inline-block";
                    break;
                case "General Aggregate":
                    strCtrlsIDs += txtGeneralAggregate.ClientID + ",";
                    strMessages += "Please enter [General Liability Policies]/General Aggregate" + ",";
                    Span14.Style["display"] = "inline-block";
                    break;
                case "Products-Completed Operations":
                    strCtrlsIDs += txtProductOperations.ClientID + ",";
                    strMessages += "Please enter [General Liability Policies]/Products-Completed Operations" + ",";
                    Span15.Style["display"] = "inline-block";
                    break;
                //case "General Aggregate Limit Applies to":
                //    strCtrlsIDs += rdoGAappliesTo.ClientID + ",";
                //    strMessages += "Please enter General Aggregate Limit Applies to" + ",";
                //    Span16.Style["display"] = "inline-block";
                //    break;
                case "Other Liability1":
                    strCtrlsIDs += txtOtherLiability1.ClientID + ",";
                    strMessages += "Please enter [General Liability Policies]/Other Liability1" + ",";
                    Span17.Style["display"] = "inline-block";
                    break;
                case "Other Liability Coverage1":
                    strCtrlsIDs += txtOtherLiabilityCoverage1.ClientID + ",";
                    strMessages += "Please enter [General Liability Policies]/Other Liability Coverage1" + ",";
                    Span18.Style["display"] = "inline-block";
                    break;
                case "Other Liability2":
                    strCtrlsIDs += txtOtherLiability2.ClientID + ",";
                    strMessages += "Please enter [General Liability Policies]/Other Liability2" + ",";
                    Span19.Style["display"] = "inline-block";
                    break;
                case "Other Liability Coverage2":
                    strCtrlsIDs += txtOtherLiabilityCoverage2.ClientID + ",";
                    strMessages += "Please enter [General Liability Policies]/Other Liability Coverage2" + ",";
                    Span20.Style["display"] = "inline-block";
                    break;
                //case "Stop Gap Endorsement":
                //    strCtrlsIDs += rdoStopGapEndorsement.ClientID + ",";
                //    strMessages += "Please enter Stop Gap Endorsement" + ",";
                //    Span21.Style["display"] = "inline-block";
                //    break;
                case "Stop Gap Endorsement Coverage":
                    strCtrlsIDs += txtStopGapCoverage.ClientID + ",";
                    strMessages += "Please enter [General Liability Policies]/Stop Gap Endorsement" + ",";
                    Span22.Style["display"] = "inline-block";
                    break;
                //case "Auto (If no owned vehicles included in BOP)":
                //    strCtrlsIDs += rdoAutoLiability.ClientID + ",";
                //    strMessages += "Please enter Auto (If no owned vehicles included in BOP)" + ",";
                //    Span23.Style["display"] = "inline-block";
                //    break;
                case "Auto (If no owned vehicles included in BOP)":
                    strCtrlsIDs += txtAutoCoverage.ClientID + ",";
                    strMessages += "Please enter [General Liability Policies]/Auto (If no owned vehicles included in BOP)" + ",";
                    Span24.Style["display"] = "inline-block";
                    break;
                case "Notes":
                    strCtrlsIDs += txtNotes.ClientID + ",";
                    strMessages += "Please enter [General Liability Policies]/Notes" + ",";
                    Span25.Style["display"] = "inline-block";
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
