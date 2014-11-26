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
public partial class ExcessPolicyAddEdit : clsBasePage
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
    // FK to indicate Excess Policy is for which COI
    public int FK_COI
    {
        get
        {
            return clsGeneral.GetInt(ViewState["COI"]);
        }
        set { ViewState["COI"] = value; }

    }

    // PK for Excess Policy
    public int PK_COI_Excess_Policies
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
                            PK_COI_Excess_Policies = (int)clsGeneral.GetQueryStringID(Convert.ToString(Request.QueryString["id"]));
                        }
                        _strOperation = Request.QueryString["op"].ToString();
                        if (Request.QueryString["op"] == "view")
                        {
                            dvView.Style["Display"] = "block";
                            BindDetailsForView();
                            BindInsuredGrid();
                            // set Attachment details control in read/write mode.
                            AttachDetails.InitializeAttachmentDetails(clsGeneral.Tables.Excess_Liability_Policies, PK_COI_Excess_Policies, false, 3);
                        }
                        else
                        {
                            if (App_Access == AccessType.Administrative_Access)
                            {
                                // set Attachment details control in read/write mode.
                                AttachDetails.InitializeAttachmentDetails(clsGeneral.Tables.Excess_Liability_Policies, PK_COI_Excess_Policies, true, 3);
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
            }
        }
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
        DataTable dtAI = COI_AI.SelectByFK_COI_Locations(PK_COI_Excess_Policies, "Excess_Policy").Tables[0];
        gvAI.DataSource = dtAI;
        gvAI.DataBind();
        gvAI.Columns[2].Visible = (Request.QueryString["op"] == "view") ? false : true;
    }
    /// <summary>
    /// Page Controls Save Record
    /// </summary>
    private void SaveRecord()
    {
        // create a new object for Excess Policy.
        COI_Excess_Policies objExcessPolicy = new COI_Excess_Policies();

        //set values.
        objExcessPolicy.PK_COI_Excess_Policies = PK_COI_Excess_Policies;
        objExcessPolicy.FK_COIs = FK_COI;
        objExcessPolicy.Insurance_Company = drpCompany.SelectedValue;
        objExcessPolicy.Policy_Number = txtPolicyNumber.Text.Trim();
        objExcessPolicy.Issue_Date = txtIssueDate.DateValue;
        objExcessPolicy.Effective_Date = txtEffectiveDate.DateValue;
        objExcessPolicy.Expiration_Date = txtExpirationDate.DateValue;
        objExcessPolicy.Cancellation_Date = txtCancellationDate.DateValue;
        objExcessPolicy.Occurrence_Form = rdoOccurrenceForm.SelectedValue;
        objExcessPolicy.Umbrealla_Form = rdoUmbrellaForm.SelectedValue;
        objExcessPolicy.Retention = rdoRetention.SelectedValue;
        objExcessPolicy.Accept_Limits = rdoAcceptLimits.SelectedValue;
        objExcessPolicy.Special_Umbrella = rdoSpecialUmbrella.SelectedValue;
        objExcessPolicy.Occurrence_Coverage = clsGeneral.GetDecimalValue(txtOccurrenceCoverage);
        objExcessPolicy.Aggregate_Coverage = clsGeneral.GetDecimalValue(txtAggregate);
        objExcessPolicy.Retention_Amount = clsGeneral.GetDecimalValue(txtRetention);
        objExcessPolicy.Accept_Limits_Coverage = clsGeneral.GetDecimalValue(txtAcceptLimits);
        objExcessPolicy.Special_Umbrella_Coverage = clsGeneral.GetDecimalValue(txtSpecialUmbrella);
        objExcessPolicy.Notes = txtNotes.Text.Trim();
        objExcessPolicy.Update_Date = DateTime.Today;
        objExcessPolicy.Updated_By = clsSession.UserName;

        // check if insert or update the Excess Policy.
        if (PK_COI_Excess_Policies > 0)
            objExcessPolicy.Update();
        else
            PK_COI_Excess_Policies = objExcessPolicy.Insert();

        // add attachment if any
        Attachment.Add(clsGeneral.Tables.Excess_Liability_Policies, PK_COI_Excess_Policies);
    }
    #endregion

    #region "Bind Details for Edit or View"

    /// <summary>
    /// Displays the page in edit mode
    /// </summary>
    private void BindDetailsForEdit()
    {
        dvView.Style["Display"] = "None";
        // create object for curernt Excess Policy
        COI_Excess_Policies objExcessPolicy = new COI_Excess_Policies(PK_COI_Excess_Policies);

        // set values
        drpCompany.SelectedValue = objExcessPolicy.Insurance_Company;
        txtPolicyNumber.Text = objExcessPolicy.Policy_Number;
        txtIssueDate.DateValue = objExcessPolicy.Issue_Date;
        txtEffectiveDate.DateValue = objExcessPolicy.Effective_Date;
        txtExpirationDate.DateValue = objExcessPolicy.Expiration_Date;
        txtExpirationDate.DateValue = objExcessPolicy.Expiration_Date;
        txtCancellationDate.DateValue = objExcessPolicy.Cancellation_Date;

        rdoOccurrenceForm.SelectedValue = objExcessPolicy.Occurrence_Form;
        rdoUmbrellaForm.SelectedValue = objExcessPolicy.Umbrealla_Form;
        rdoRetention.SelectedValue = objExcessPolicy.Retention;
        rdoAcceptLimits.SelectedValue = objExcessPolicy.Accept_Limits;
        rdoSpecialUmbrella.SelectedValue = objExcessPolicy.Special_Umbrella;
        txtOccurrenceCoverage.Text = clsGeneral.GetStringValue(objExcessPolicy.Occurrence_Coverage);
        txtAggregate.Text = clsGeneral.GetStringValue(objExcessPolicy.Aggregate_Coverage);
        txtRetention.Text = clsGeneral.GetStringValue(objExcessPolicy.Retention_Amount);
        txtAcceptLimits.Text = clsGeneral.GetStringValue(objExcessPolicy.Accept_Limits_Coverage);
        txtSpecialUmbrella.Text = clsGeneral.GetStringValue(objExcessPolicy.Special_Umbrella_Coverage);

        txtNotes.Text = objExcessPolicy.Notes;
    }

    /// <summary>
    /// Displays the page in view mode
    /// </summary>
    private void BindDetailsForView()
    {
        dvEdit.Style["Display"] = "None";
        // create object for curernt Excess Policy
        COI_Excess_Policies objExcessPolicy = new COI_Excess_Policies(PK_COI_Excess_Policies);

        // set values
        lblCompany.Text = objExcessPolicy.Insurance_Company;
        lblPolicyNumber.Text = objExcessPolicy.Policy_Number;
        lblIssueDate.Text = objExcessPolicy.Issue_Date.ToString(AppConfig.DisplayDateFormat);
        lblEffectiveDate.Text = objExcessPolicy.Effective_Date.ToString(AppConfig.DisplayDateFormat);
        lblExpirationDate.Text = objExcessPolicy.Expiration_Date.ToString(AppConfig.DisplayDateFormat);
        lblCancellationDate.Text = clsGeneral.FormatDate(objExcessPolicy.Cancellation_Date);

        lblOccurrenceForm.Text = (objExcessPolicy.Occurrence_Form == "Y") ? "YES" : "NO";
        lblUmbrellaForm.Text = (objExcessPolicy.Umbrealla_Form == "Y") ? "YES" : "NO";
        lblRetention.Text = (objExcessPolicy.Retention == "Y") ? "YES" : "NO";
        lblAcceptLimits.Text = (objExcessPolicy.Accept_Limits == "Y") ? "YES" : "NO";
        lblSpecialUmbrella.Text = (objExcessPolicy.Special_Umbrella == "Y") ? "YES" : "NO";

        lblOccurrenceCoverage.Text = clsGeneral.GetStringValue(objExcessPolicy.Occurrence_Coverage);
        lblAggregate.Text = clsGeneral.GetStringValue(objExcessPolicy.Aggregate_Coverage);
        lblRetentionAmount.Text = clsGeneral.GetStringValue(objExcessPolicy.Retention_Amount);
        lblAcceptLimitsCoverage.Text = clsGeneral.GetStringValue(objExcessPolicy.Accept_Limits_Coverage);
        lblSpecialUmbrellaCoverage.Text = clsGeneral.GetStringValue(objExcessPolicy.Special_Umbrella_Coverage);

        lblNotes.Text = objExcessPolicy.Notes;

        lnkGeneralAdd.Style["Display"] = "None";
        lblNote.Style["Display"] = "None";
    }

    #endregion

    #region " Control Events "
    /// <summary>
    /// Grid Row Command Event 
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

    // add or update Excess Policy record
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
    /// Attachment Control Add button click event
    /// </summary>
    /// <param name="sender"></param>
    protected void Attachment_btnHandler(object sender)
    {
        // check if Excess Policy reocord is saved or not.
        // if not don't save any attachment
        if (PK_COI_Excess_Policies > 0)
        {
            Attachment.Add(clsGeneral.Tables.Excess_Liability_Policies, PK_COI_Excess_Policies);

            // after saving attachment bind attachment details again.
            BindAttachmentDetails();
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "ShowPanel", "javascript:ShowPanel(3);", true);
        }
        else
            ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript: alert('Please save Excess Liability Policies First');ShowPanel(1);", true);
    }
    /// <summary>
    /// Handle Back Button click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnReturn_Click(object sender, EventArgs e)
    {
        // redirect to coi page without changes done to Excess Policy band
        //clsGeneral.RedirectToCOIPage(Page, "Excess", FK_COI);
        btnBack_Click(sender, e);
    }
    /// <summary>
    /// Handle DummyForSave button click event
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
                strPath = hdnPageName.Value + "&Page=EP&prop=" + Encryption.Encrypt(PK_COI_Excess_Policies.ToString()) + "&coi=" + Encryption.Encrypt(FK_COI.ToString()) + "&op=" + Request.QueryString["op"];
            else
                strPath = hdnPageName.Value + "?Page=EP&prop=" + Encryption.Encrypt(PK_COI_Excess_Policies.ToString()) + "&coi=" + Encryption.Encrypt(FK_COI.ToString());
            Response.Redirect(strPath);
        }
    }
    /// <summary>
    /// Back Button Click Event
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

    #region "Dynamic Validations"
    /// <summary>
    /// Set all Validations
    /// </summary>
    private void SetValidations()
    {
        string strCtrlsIDs = "";
        string strMessages = "";

        #region "Excess Liability Policies"
        DataTable dtFields = clsScreen_Validators.SelectByScreen(104).Tables[0];
        dtFields.DefaultView.RowFilter = "IsRequired = '1'";
        dtFields = dtFields.DefaultView.ToTable();
        MenuAsterisk1.Style["display"] = (dtFields.Select("LeftMenuIndex = 9").Length > 0) ? "inline-block" : "none";
        foreach (DataRow drField in dtFields.Rows)
        {
            #region " set validation control IDs and messages "
            switch (Convert.ToString(drField["Field_Name"]))
            {
                case "Insurance Company":
                    strCtrlsIDs += drpCompany.ClientID + ",";
                    strMessages += "Please select [Excess Liability Policies]/Insurance Company" + ",";
                    Span1.Style["display"] = "inline-block";
                    break;
                case "Policy Number":
                    strCtrlsIDs += txtPolicyNumber.ClientID + ",";
                    strMessages += "Please enter [Excess Liability Policies]/Policy Number" + ",";
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
                case "Each Occurrence":
                    strCtrlsIDs += txtOccurrenceCoverage.ClientID + ",";
                    strMessages += "Please enter [Excess Liability Policies]/Each Occurrence" + ",";
                    Span7.Style["display"] = "inline-block";
                    break;
                case "Aggregate":
                    strCtrlsIDs += txtAggregate.ClientID + ",";
                    strMessages += "Please enter [Excess Liability Policies]/Aggregate" + ",";
                    Span8.Style["display"] = "inline-block";
                    break;
                case "Retention":
                    strCtrlsIDs += txtRetention.ClientID + ",";
                    strMessages += "Please enter [Excess Liability Policies]/Retention" + ",";
                    Span9.Style["display"] = "inline-block";
                    break;
                case "Accept Limits":
                    strCtrlsIDs += txtAcceptLimits.ClientID + ",";
                    strMessages += "Please enter [Excess Liability Policies]/Accept Limits" + ",";
                    Span10.Style["display"] = "inline-block";
                    break;
                case "Special Umbrella Limits":
                    strCtrlsIDs += txtSpecialUmbrella.ClientID + ",";
                    strMessages += "Please enter [Excess Liability Policies]/Special Umbrella Limits" + ",";
                    Span11.Style["display"] = "inline-block";
                    break;
                case "Notes":
                    strCtrlsIDs += txtNotes.ClientID + ",";
                    strMessages += "Please enter [Excess Liability Policies]/Notes" + ",";
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
