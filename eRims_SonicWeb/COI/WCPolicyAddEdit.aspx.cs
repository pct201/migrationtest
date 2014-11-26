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
public partial class Admin_WCPolicyAddEdit : clsBasePage
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
    // FK to indicate WC Policy is for which COI
    public int FK_COI
    {
        get
        {
            return clsGeneral.GetInt(ViewState["COI"]);
        }
        set { ViewState["COI"] = value; }

    }

    // PK for WC Policy
    public int PK_COI_WC_Policies
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

                    // if operations(view or edit) is passed in query string.
                    if (!clsGeneral.IsNull(Request.QueryString["op"]))
                    {
                        // if id is passed set primary key.
                        if (!clsGeneral.IsNull(Request.QueryString["id"]))
                        {
                            PK_COI_WC_Policies = (int)clsGeneral.GetQueryStringID(Convert.ToString(Request.QueryString["id"]));
                        }

                        _strOperation = Request.QueryString["op"].ToString();

                        if (Request.QueryString["op"] == "view")
                        {
                            dvView.Style["Display"] = "block";
                            BindDetailsForView();                           
                            BindInsuredGrid();
                            // set Attachment details control in read/write mode.
                            AttachDetails.InitializeAttachmentDetails(clsGeneral.Tables.WC_Policies, PK_COI_WC_Policies, false, 3);

                        }
                        else
                        {
                            if (App_Access == AccessType.Administrative_Access)
                            {
                                // set Attachment details control in read/write mode.
                                AttachDetails.InitializeAttachmentDetails(clsGeneral.Tables.WC_Policies, PK_COI_WC_Policies, true, 3);
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
        DataTable dtAI = COI_AI.SelectByFK_COI_Locations(PK_COI_WC_Policies, "Workers_Comp").Tables[0];
        gvAI.DataSource = dtAI;
        gvAI.DataBind();
        gvAI.Columns[2].Visible = (Request.QueryString["op"] == "view") ? false : true;
    }

    private void SaveRecord()
    {
        // create a new object for Excess Policy.
        COI_WC_Policies objWCPolicy = new COI_WC_Policies();

        //set values.
        objWCPolicy.PK_COI_WC_Policies = PK_COI_WC_Policies;
        objWCPolicy.FK_COIs = FK_COI;
        objWCPolicy.Insurance_Company = drpCompany.SelectedValue;
        objWCPolicy.Policy_Number = txtPolicyNumber.Text.Trim();
        objWCPolicy.Issue_Date = txtIssueDate.DateValue;
        objWCPolicy.Effective_Date = txtEffectiveDate.DateValue;
        objWCPolicy.Expiration_Date = txtExpirationDate.DateValue;
        objWCPolicy.Cancellation_Date = txtCancellationDate.DateValue;

        objWCPolicy.State_Limits = rdoStateLimits.SelectedValue;
        objWCPolicy.Management = rdoManagement.SelectedValue;
        objWCPolicy.Leased_Employees = rdoLeasedEmployees.SelectedValue;
        objWCPolicy.State_Funded = rdoStateFunded.SelectedValue;
        objWCPolicy.Other = rdoOther.SelectedValue;
        objWCPolicy.Accident = clsGeneral.GetDecimalValue(txtAccident);
        objWCPolicy.Disease_Each = clsGeneral.GetDecimalValue(txtDiseaseEach);
        objWCPolicy.Disease_Limit = clsGeneral.GetDecimalValue(txtDiseaseLimit);

        objWCPolicy.Notes = txtNotes.Text.Trim();
        objWCPolicy.Update_Date = DateTime.Today;
        objWCPolicy.Updated_By = clsSession.UserName;

        // check if insert or update the Excess Policy.
        if (PK_COI_WC_Policies > 0)
            objWCPolicy.Update();
        else
            PK_COI_WC_Policies = objWCPolicy.Insert();

        // add attachment if any
        Attachment.Add(clsGeneral.Tables.WC_Policies, PK_COI_WC_Policies);
    }
    #endregion

    #region "Bind Details for Edit or View"

    /// <summary>
    /// Displays the page in edit mode
    /// </summary>
    private void BindDetailsForEdit()
    {
        dvView.Style["Display"] = "None";
        // create object for curernt WC Policy
        COI_WC_Policies objWCPolicy = new COI_WC_Policies(PK_COI_WC_Policies);

        // set values
        drpCompany.SelectedValue = objWCPolicy.Insurance_Company;
        txtPolicyNumber.Text = objWCPolicy.Policy_Number;
        txtIssueDate.DateValue = objWCPolicy.Issue_Date;
        txtEffectiveDate.DateValue = objWCPolicy.Effective_Date;
        txtExpirationDate.DateValue = objWCPolicy.Expiration_Date;
        txtExpirationDate.DateValue = objWCPolicy.Expiration_Date;
        txtCancellationDate.DateValue = objWCPolicy.Cancellation_Date;

        rdoStateLimits.SelectedValue = objWCPolicy.State_Limits;
        rdoManagement.SelectedValue = objWCPolicy.Management;
        rdoLeasedEmployees.SelectedValue = objWCPolicy.Leased_Employees;
        rdoStateFunded.SelectedValue = objWCPolicy.State_Funded;
        rdoOther.SelectedValue = objWCPolicy.Other;
        txtAccident.Text = clsGeneral.GetStringValue(objWCPolicy.Accident);
        txtDiseaseEach.Text = clsGeneral.GetStringValue(objWCPolicy.Disease_Each);
        txtDiseaseLimit.Text = clsGeneral.GetStringValue(objWCPolicy.Disease_Limit);

        txtNotes.Text = objWCPolicy.Notes;
    }

    /// <summary>
    /// Displays the page in view mode
    /// </summary>
    private void BindDetailsForView()
    {
        dvEdit.Style["Display"] = "None";
        // create object for curernt WC Policy
        COI_WC_Policies objWCPolicy = new COI_WC_Policies(PK_COI_WC_Policies);

        // set values
        lblCompany.Text = objWCPolicy.Insurance_Company;
        lblPolicyNumber.Text = objWCPolicy.Policy_Number;
        lblIssueDate.Text = objWCPolicy.Issue_Date.ToString(AppConfig.DisplayDateFormat);
        lblEffectiveDate.Text = objWCPolicy.Effective_Date.ToString(AppConfig.DisplayDateFormat);
        lblExpirationDate.Text = objWCPolicy.Expiration_Date.ToString(AppConfig.DisplayDateFormat);
        lblCancellationDate.Text = clsGeneral.FormatDate(objWCPolicy.Cancellation_Date);

        lblStateLimits.Text = objWCPolicy.State_Limits == "Y" ? "YES" : "NO";
        lblManagement.Text = objWCPolicy.Management == "Y" ? "YES" : "NO"; ;
        lblLeasedEmployees.Text = objWCPolicy.Leased_Employees == "Y" ? "YES" : "NO"; ;
        lblStateFunded.Text = objWCPolicy.State_Funded == "Y" ? "YES" : "NO"; ;
        lblOther.Text = objWCPolicy.Other == "Y" ? "YES" : "NO"; ;

        lblAccident.Text = clsGeneral.GetStringValue(objWCPolicy.Accident);
        lblDiseaseEach.Text = clsGeneral.GetStringValue(objWCPolicy.Disease_Each);
        lblDiseaseLimit.Text = clsGeneral.GetStringValue(objWCPolicy.Disease_Limit);

        lblNotes.Text = objWCPolicy.Notes;       
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
    // add or update Excess Policy record
    protected void btnSave_Click(object sender, EventArgs e)
    {
        // check page is valid or not.        
        if (Page.IsValid)
        {
            SaveRecord();

            // redirect to coi page with changes done to Excess Policy band
            btnBack_Click(sender, e);
        }
    }

    protected void Attachment_btnHandler(object sender)
    {
        // check if Excess Policy reocord is saved or not.
        // if not don't save any attachment
        if (PK_COI_WC_Policies > 0)
        {
            Attachment.Add(clsGeneral.Tables.WC_Policies, PK_COI_WC_Policies);

            // after saving attachment bind attachment details again.
            BindAttachmentDetails();
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "ShowPanel", "javascript:ShowPanel(3);", true);
        }
        else
            ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript: alert('Please save Worker’s Compensation/Employer’s Liability Policies First');ShowPanel(1);", true);
    }

    protected void btnReturn_Click(object sender, EventArgs e)
    {
        // redirect to coi page without changes done to Excess Policy band
        //clsGeneral.RedirectToCOIPage(Page, "WC", FK_COI);
        btnBack_Click(sender, e);
    }
    protected void btnDummyForSave_Click(object sender, EventArgs e)
    {
        SaveRecord();
        string strPath = string.Empty;

        if (!string.IsNullOrEmpty(hdnPageName.Value))
        {
            if (hdnPageName.Value.IndexOf("?") > 0)
                strPath = hdnPageName.Value + "&Page=WC&prop=" + Encryption.Encrypt(PK_COI_WC_Policies.ToString()) + "&coi=" + Encryption.Encrypt(FK_COI.ToString()) + "&op=" + Request.QueryString["op"];
            else
                strPath = hdnPageName.Value + "?Page=WC&prop=" + Encryption.Encrypt(PK_COI_WC_Policies.ToString()) + "&coi=" + Encryption.Encrypt(FK_COI.ToString());
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
    
    #region "Dynamic Validations"
    /// <summary>
    /// Set all Validations
    /// </summary>
    private void SetValidations()
    {
        string strCtrlsIDs = "";
        string strMessages = "";

        #region "Worker’s Compensation/Employer Liability Policies"
        DataTable dtFields = clsScreen_Validators.SelectByScreen(105).Tables[0];
        dtFields.DefaultView.RowFilter = "IsRequired = '1'";
        dtFields = dtFields.DefaultView.ToTable();
        MenuAsterisk1.Style["display"] = (dtFields.Select("LeftMenuIndex = 10").Length > 0) ? "inline-block" : "none";
        foreach (DataRow drField in dtFields.Rows)
        {
            #region " set validation control IDs and messages "
            switch (Convert.ToString(drField["Field_Name"]))
            {
                case "Insurance Company":
                    strCtrlsIDs += drpCompany.ClientID + ",";
                    strMessages += "Please select [Worker’s Compensation Policies]/Insurance Company" + ",";
                    Span1.Style["display"] = "inline-block";
                    break;
                case "Policy Number":
                    strCtrlsIDs += txtPolicyNumber.ClientID + ",";
                    strMessages += "Please enter [Worker’s Compensation Policies]/Policy Number" + ",";
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
                case "Each Accident":
                    strCtrlsIDs += txtAccident.ClientID + ",";
                    strMessages += "Please enter [Worker’s Compensation Policies]/Each Accident" + ",";
                    Span7.Style["display"] = "inline-block";
                    break;
                case "Disease - Each Employee":
                    strCtrlsIDs += txtDiseaseEach.ClientID + ",";
                    strMessages += "Please enter [Worker’s Compensation Policies]/Disease - Each Employee" + ",";
                    Span8.Style["display"] = "inline-block";
                    break;
                case "Disease – Policy Limit":
                    strCtrlsIDs += txtDiseaseLimit.ClientID + ",";
                    strMessages += "Please enter [Worker’s Compensation Policies]/Disease – Policy Limit" + ",";
                    Span9.Style["display"] = "inline-block";
                    break;
                case "Notes":
                    strCtrlsIDs += txtNotes.ClientID + ",";
                    strMessages += "Please enter [Worker’s Compensation Policies]/Notes" + ",";
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
