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
public partial class COI_LiquorLiability : clsBasePage
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
    // FK to indicate Property Policy is for which COI
    public int FK_COI
    {
        get
        {
            return clsGeneral.GetInt(ViewState["COI"]);
        }
        set { ViewState["COI"] = value; }

    }

    // PK for Property Policy
    public int PK_COI_Liquor_Policies
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PolicyID"]);
        }
        set { ViewState["PolicyID"] = value; }
    }

    #endregion

    #region "Page Events"

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
                    BindOtherPolicyTypes();

                    // if operations(view or edit) is passed in query string.
                    if (!clsGeneral.IsNull(Request.QueryString["op"]))
                    {
                        // if id is passed set primary key.
                        if (!clsGeneral.IsNull(Request.QueryString["id"]))
                        {
                            PK_COI_Liquor_Policies = (int)clsGeneral.GetQueryStringID(Convert.ToString(Request.QueryString["id"]));
                        }

                        _strOperation = Request.QueryString["op"].ToString();
                        if (Request.QueryString["op"] == "view")
                        {
                            dvView.Style["Display"] = "block";
                            BindDetailsForView();                           
                            BindInsuredGrid();

                            // set Attachment details control in read/write mode.
                            AttachDetails.InitializeAttachmentDetails(clsGeneral.Tables.COI_Liquor_Policies, PK_COI_Liquor_Policies, false, 3);

                        }
                        else
                        {
                            if (App_Access == AccessType.Administrative_Access)
                            {
                                // set Attachment details control in read/write mode.
                                AttachDetails.InitializeAttachmentDetails(clsGeneral.Tables.COI_Liquor_Policies, PK_COI_Liquor_Policies, true, 3);
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
        DataTable dtAI = COI_AI.SelectByFK_COI_Locations(PK_COI_Liquor_Policies, "Liqour_Policy").Tables[0];
        gvAI.DataSource = dtAI;
        gvAI.DataBind();
        gvAI.Columns[2].Visible = (Request.QueryString["op"] == "view") ? false : true;
    }

    private void SaveRecord()
    {
        // create a new object for Property Policy.
        COI_Liquor_Policies objLiquorPolicy = new COI_Liquor_Policies();

        //set values.
        objLiquorPolicy.PK_COI_Liquor_Policies = PK_COI_Liquor_Policies;
        objLiquorPolicy.FK_COIs = FK_COI;
        objLiquorPolicy.Insurance_Company = drpCompany.SelectedIndex > 0 ? drpCompany.SelectedValue : string.Empty;
        objLiquorPolicy.FK_Other_Policy_Types = drpOtherLiabilityPolicies.SelectedIndex > 0 ? Convert.ToDecimal(drpOtherLiabilityPolicies.SelectedValue) : -1;
        objLiquorPolicy.Policy_Number = txtPolicyNumber.Text.Trim();
        objLiquorPolicy.Issue_Date = txtIssueDate.DateValue;
        objLiquorPolicy.Effective_Date = txtEffectiveDate.DateValue;
        objLiquorPolicy.Expiration_Date = txtExpirationDate.DateValue;
        objLiquorPolicy.Cancellation_Date = txtCancellationDate.DateValue;
        objLiquorPolicy.Notes = txtNotes.Text.Trim();
        objLiquorPolicy.Occurrence = clsGeneral.GetDecimalValue(txtEachOccur);
        objLiquorPolicy.Aggregate = clsGeneral.GetDecimalValue(txtAggregate);
        objLiquorPolicy.Update_Date = DateTime.Today;
        objLiquorPolicy.Updated_By = clsSession.UserName;

        // check if insert or update the Property Policy.
        if (PK_COI_Liquor_Policies > 0)
            objLiquorPolicy.Update();
        else
        {
            PK_COI_Liquor_Policies = objLiquorPolicy.Insert();
        }

        // add attachment if any
        Attachment.Add(clsGeneral.Tables.COI_Liquor_Policies, PK_COI_Liquor_Policies);
    }

    protected void BindOtherPolicyTypes()
    {
        DataSet ds = COI_Other_Policy_LiabilityType.SelectAll();
        drpOtherLiabilityPolicies.DataSource = ds;
        drpOtherLiabilityPolicies.DataTextField = "Fld_Desc";
        drpOtherLiabilityPolicies.DataValueField = "PK_Other_Policy_Types";
        drpOtherLiabilityPolicies.DataBind();
        drpOtherLiabilityPolicies.Items.Insert(0, "--Select--");
    }
    #endregion

    #region "Bind Details for Edit or View"

    /// <summary>
    /// Displays the page in edit mode
    /// </summary>
    private void BindDetailsForEdit()
    {
        dvView.Style["Display"] = "None";
        dvSave.Style["Display"] = "block";
        // create object for curernt Property Policy
        COI_Liquor_Policies objLiquorPolicy = new COI_Liquor_Policies(PK_COI_Liquor_Policies);

        // set values
        drpOtherLiabilityPolicies.SelectedValue = objLiquorPolicy.FK_Other_Policy_Types != 0 ? Convert.ToString(objLiquorPolicy.FK_Other_Policy_Types) : "--Select--";
        drpCompany.SelectedValue = objLiquorPolicy.Insurance_Company;
        txtPolicyNumber.Text = objLiquorPolicy.Policy_Number;
        txtIssueDate.DateValue = objLiquorPolicy.Issue_Date;
        txtEffectiveDate.DateValue = objLiquorPolicy.Effective_Date;
        txtExpirationDate.DateValue = objLiquorPolicy.Expiration_Date;
        txtExpirationDate.DateValue = objLiquorPolicy.Expiration_Date;
        txtCancellationDate.DateValue = objLiquorPolicy.Cancellation_Date;
        txtEachOccur.Text = clsGeneral.GetStringValue(objLiquorPolicy.Occurrence);
        txtAggregate.Text = clsGeneral.GetStringValue(objLiquorPolicy.Aggregate);
        txtNotes.Text = objLiquorPolicy.Notes;
    }

    /// <summary>
    /// Displays the page in view mode
    /// </summary>
    private void BindDetailsForView()
    {
        dvEdit.Style["Display"] = "None";
        dvBack.Style["Display"] = "block";

        // create object for curernt Property Policy
        COI_Liquor_Policies objLiquorPolicy = new COI_Liquor_Policies(PK_COI_Liquor_Policies);

        // set values
        lblCompany.Text = objLiquorPolicy.Insurance_Company;
        lblPolicyNumber.Text = objLiquorPolicy.Policy_Number;
        lblIssueDate.Text = objLiquorPolicy.Issue_Date.ToString(AppConfig.DisplayDateFormat);
        lblEffectiveDate.Text = objLiquorPolicy.Effective_Date.ToString(AppConfig.DisplayDateFormat);
        lblExpirationDate.Text = objLiquorPolicy.Expiration_Date.ToString(AppConfig.DisplayDateFormat);
        lblCancellationDate.Text = clsGeneral.FormatDate(objLiquorPolicy.Cancellation_Date);
        lblEachOccur.Text = clsGeneral.GetStringValue(objLiquorPolicy.Occurrence);
        lblAggregate.Text = clsGeneral.GetStringValue(objLiquorPolicy.Aggregate);
        lblNotes.Text = objLiquorPolicy.Notes;       
        lnkGeneralAdd.Style["Display"] = "None";
        lblNote.Style["Display"] = "None";
    }

    #endregion

    #region " Control Events "
    protected void gvAI_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "RemoveInsured")
        {
            COI_AI.Delete(Convert.ToDecimal(e.CommandArgument));
            BindInsuredGrid();
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "ShowPanel", "javascript:ShowPanel(2);", true);
        }
    }   
    protected void btnSaveReturn_Click(object sender, EventArgs e)
    {
        btnSave_Click(null, null);
        // redirect to coi page with changes done to Property Policy band
        //clsGeneral.RedirectToCOIPage(Page, "Liquor", FK_COI);
        btnBack_Click(sender, e);
    }

    // add or update Property Policy record
    protected void btnSave_Click(object sender, EventArgs e)
    {
        // check page is valid or not.        
        if (Page.IsValid)
        {
            SaveRecord();
            // redirect to coi page with changes done to automobile band
            btnBack_Click(sender, e);

        }
    }

    protected void Attachment_btnHandler(object sender)
    {
        // check if Property Policy reocord is saved or not.
        // if not don't save any attachment
        if (PK_COI_Liquor_Policies > 0)
        {
            Attachment.Add(clsGeneral.Tables.COI_Liquor_Policies, PK_COI_Liquor_Policies);

            // after saving attachment bind attachment details again.
            BindAttachmentDetails();
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "ShowPanel", "javascript:ShowPanel(3);", true);
        }
        else
            ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript: alert('Please save Other Liability Policies First');ShowPanel(1);", true);
    }

    protected void btnBackToCOI_Click(object sender, EventArgs e)
    {
        // redirect to coi page with changes done to Property Policy band
        //clsGeneral.RedirectToCOIPage(Page, "Liquor", FK_COI);
        btnBack_Click(sender, e);
    }

    protected void btnDummyForSave_Click(object sender, EventArgs e)
    {
        SaveRecord();
        string strPath = string.Empty;

        if (!string.IsNullOrEmpty(hdnPageName.Value))
        {
            if (hdnPageName.Value.IndexOf("?") > 0)
                strPath = hdnPageName.Value + "&Page=LP&prop=" + Encryption.Encrypt(PK_COI_Liquor_Policies.ToString()) + "&coi=" + Encryption.Encrypt(FK_COI.ToString()) + "&op=" + Request.QueryString["op"];
            else
                strPath = hdnPageName.Value + "?Page=LP&prop=" + Encryption.Encrypt(PK_COI_Liquor_Policies.ToString()) + "&coi=" + Encryption.Encrypt(FK_COI.ToString());
            Response.Redirect(strPath);
        }
    }

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

        #region "Other Liability Policies"
        DataTable dtFields = clsScreen_Validators.SelectByScreen(108).Tables[0];
        dtFields.DefaultView.RowFilter = "IsRequired = '1'";
        dtFields = dtFields.DefaultView.ToTable();

        MenuAsterisk1.Style["display"] = (dtFields.Select("LeftMenuIndex = 13").Length > 0) ? "inline-block" : "none";

        foreach (DataRow drField in dtFields.Rows)
        {
            #region " set validation control IDs and messages "
            switch (Convert.ToString(drField["Field_Name"]))
            {
                case "Other Liability Policies":
                    strCtrlsIDs += drpOtherLiabilityPolicies.ClientID + ",";
                    strMessages += "Please select [Other Liability Policies]/Other Liability Policies" + ",";
                    Span1.Style["display"] = "inline-block";
                    break;
                case "Insurance Company":
                    strCtrlsIDs += drpCompany.ClientID + ",";
                    strMessages += "Please select [Other Liability Policies]/Insurance Company" + ",";
                    Span2.Style["display"] = "inline-block";
                    break;
                case "Policy Number":
                    strCtrlsIDs += txtPolicyNumber.ClientID + ",";
                    strMessages += "Please enter [Other Liability Policies]/Policy Number" + ",";
                    Span3.Style["display"] = "inline-block";
                    break;
                case "Issue Date":
                    txtIssueDate.IsRequiredField = true;
                    Span4.Style["display"] = "inline-block";
                    break;
                case "Effective Date":
                    txtEffectiveDate.IsRequiredField = true;
                    Span5.Style["display"] = "inline-block";
                    break;
                case "Expiration Date":
                    txtExpirationDate.IsRequiredField = true;
                    Span6.Style["display"] = "inline-block";
                    break;
                case "Cancellation Date":
                    txtCancellationDate.IsRequiredField = true;
                    Span7.Style["display"] = "inline-block";
                    break;
                case "Each Occurrence":
                    strCtrlsIDs += txtEachOccur.ClientID + ",";
                    strMessages += "Please enter [Other Liability Policies]/Each Occurrence" + ",";
                    Span8.Style["display"] = "inline-block";
                    break;
                case "Aggregate":
                    strCtrlsIDs += txtAggregate.ClientID + ",";
                    strMessages += "Please enter [Other Liability Policies]/Aggregate" + ",";
                    Span9.Style["display"] = "inline-block";
                    break;
                case "Notes":
                    strCtrlsIDs += txtNotes.ClientID + ",";
                    strMessages += "Please enter [Other Liability Policies]/Notes" + ",";
                    Span10.Style["display"] = "inline-block";
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
