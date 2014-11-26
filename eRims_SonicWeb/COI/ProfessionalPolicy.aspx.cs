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
public partial class Admin_ProfessionalPolicy : clsBasePage
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
    // FK to indicate Professional Policy is for which COI
    public int FK_COI
    {
        get
        {
            return clsGeneral.GetInt(ViewState["COI"]);
        }
        set { ViewState["COI"] = value; }

    }

    // PK for Professional Policy
    public int PK_COI_Professional_Policies
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
                            PK_COI_Professional_Policies = (int)clsGeneral.GetQueryStringID(Convert.ToString(Request.QueryString["id"]));
                        }

                        _strOperation = Request.QueryString["op"].ToString();

                        if (Request.QueryString["op"] == "view")
                        {
                            dvView.Style["Display"] = "block";
                            BindDetailsForView();                           
                            BindInsuredGrid();
                            // set Attachment details control in read/write mode.
                            AttachDetails.InitializeAttachmentDetails(clsGeneral.Tables.Professional_Liability_Policies, PK_COI_Professional_Policies, false, 3);

                        }
                        else
                        {
                            if (App_Access == AccessType.Administrative_Access)
                            {
                                // set Attachment details control in read/write mode.
                                AttachDetails.InitializeAttachmentDetails(clsGeneral.Tables.Professional_Liability_Policies, PK_COI_Professional_Policies, true, 3);
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
        DataTable dtAI = COI_AI.SelectByFK_COI_Locations(PK_COI_Professional_Policies, "Professional_Policy").Tables[0];
        gvAI.DataSource = dtAI;
        gvAI.DataBind();
        gvAI.Columns[2].Visible = (Request.QueryString["op"] == "view") ? false : true;
    }
    private void SaveRecord()
    {
        // create a new object for Professional Policy.
        COI_Professional_Policies objProfessionalPolicy = new COI_Professional_Policies();

        //set values.
        objProfessionalPolicy.PK_COI_Professional_Policies = PK_COI_Professional_Policies;
        objProfessionalPolicy.FK_COIs = FK_COI;
        objProfessionalPolicy.Insurance_Company = drpCompany.SelectedValue;
        objProfessionalPolicy.Policy_Number = txtPolicyNumber.Text.Trim();
        objProfessionalPolicy.Issue_Date = txtIssueDate.DateValue;
        objProfessionalPolicy.Effective_Date = txtEffectiveDate.DateValue;
        objProfessionalPolicy.Expiration_Date = txtExpirationDate.DateValue;
        objProfessionalPolicy.Cancellation_Date = txtCancellationDate.DateValue;
        objProfessionalPolicy.Occurrence = clsGeneral.GetDecimalValue(txtOccurrenceCoverage);
        objProfessionalPolicy.Aggregate = clsGeneral.GetDecimalValue(txtAggregate);
        objProfessionalPolicy.Notes = txtNotes.Text.Trim();
        objProfessionalPolicy.Update_Date = DateTime.Today;
        objProfessionalPolicy.Updated_By = clsSession.UserName;

        // check if insert or update the Professional Policy.
        if (PK_COI_Professional_Policies > 0)
            objProfessionalPolicy.Update();
        else
            PK_COI_Professional_Policies = objProfessionalPolicy.Insert();

        // add attachment if any
        Attachment.Add(clsGeneral.Tables.Professional_Liability_Policies, PK_COI_Professional_Policies);

    }

    #endregion

    #region "Bind Details for Edit or View"

    /// <summary>
    /// Displays the page in edit mode
    /// </summary>
    private void BindDetailsForEdit()
    {
        dvView.Style["Display"] = "None";
        // create object for curernt Professional Policy
        COI_Professional_Policies objProfessionalPolicy = new COI_Professional_Policies(PK_COI_Professional_Policies);

        // set values
        drpCompany.SelectedValue = objProfessionalPolicy.Insurance_Company;
        txtPolicyNumber.Text = objProfessionalPolicy.Policy_Number;
        txtIssueDate.DateValue = objProfessionalPolicy.Issue_Date;
        txtEffectiveDate.DateValue = objProfessionalPolicy.Effective_Date;
        txtExpirationDate.DateValue = objProfessionalPolicy.Expiration_Date;
        txtExpirationDate.DateValue = objProfessionalPolicy.Expiration_Date;
        txtCancellationDate.DateValue = objProfessionalPolicy.Cancellation_Date;


        txtOccurrenceCoverage.Text = clsGeneral.GetStringValue(objProfessionalPolicy.Occurrence);
        txtAggregate.Text = clsGeneral.GetStringValue(objProfessionalPolicy.Aggregate);


        txtNotes.Text = objProfessionalPolicy.Notes;
    }

    /// <summary>
    /// Displays the page in view mode
    /// </summary>
    private void BindDetailsForView()
    {
        dvEdit.Style["Display"] = "None";
        // create object for curernt Professional Policy
        COI_Professional_Policies objProfessionalPolicy = new COI_Professional_Policies(PK_COI_Professional_Policies);

        // set values
        lblCompany.Text = objProfessionalPolicy.Insurance_Company;
        lblPolicyNumber.Text = objProfessionalPolicy.Policy_Number;
        lblIssueDate.Text = objProfessionalPolicy.Issue_Date.ToString(AppConfig.DisplayDateFormat);
        lblEffectiveDate.Text = objProfessionalPolicy.Effective_Date.ToString(AppConfig.DisplayDateFormat);
        lblExpirationDate.Text = objProfessionalPolicy.Expiration_Date.ToString(AppConfig.DisplayDateFormat);
        lblCancellationDate.Text = clsGeneral.FormatDate(objProfessionalPolicy.Cancellation_Date);

        lblOccurrenceCoverage.Text = clsGeneral.GetStringValue(objProfessionalPolicy.Occurrence);
        lblAggregate.Text = clsGeneral.GetStringValue(objProfessionalPolicy.Aggregate);

        lblNotes.Text = objProfessionalPolicy.Notes;       
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
       
    // add or update Professional Policy record
    protected void btnSave_Click(object sender, EventArgs e)
    {
        // check page is valid or not.        
        if (Page.IsValid)
        {
            SaveRecord();
            // redirect to coi page with changes done to Professional Policy band
            btnBack_Click(sender, e);

        }
    }
    protected void Attachment_btnHandler(object sender)
    {
        // check if Professional Policy reocord is saved or not.
        // if not don't save any attachment
        if (PK_COI_Professional_Policies > 0)
        {
            Attachment.Add(clsGeneral.Tables.Professional_Liability_Policies, PK_COI_Professional_Policies);

            // after saving attachment bind attachment details again.
            BindAttachmentDetails();
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "ShowPanel", "javascript:ShowPanel(3);", true);
        }
        else
            ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript: alert('Please save Professional Liability Policies First');ShowPanel(1);", true);
    }

    protected void btnReturn_Click(object sender, EventArgs e)
    {
        // redirect to coi page without changes done to Professional Policy band
        //clsGeneral.RedirectToCOIPage(Page, "Professional", FK_COI);
        btnBack_Click(sender, e);
    }
    protected void btnDummyForSave_Click(object sender, EventArgs e)
    {
        SaveRecord();
        string strPath = string.Empty;

        if (!string.IsNullOrEmpty(hdnPageName.Value))
        {
            if (hdnPageName.Value.IndexOf("?") > 0)
                strPath = hdnPageName.Value + "&Page=PL&prop=" + Encryption.Encrypt(PK_COI_Professional_Policies.ToString()) + "&coi=" + Encryption.Encrypt(FK_COI.ToString()) + "&op=" + Request.QueryString["op"];
            else
                strPath = hdnPageName.Value + "?Page=PL&prop=" + Encryption.Encrypt(PK_COI_Professional_Policies.ToString()) + "&coi=" + Encryption.Encrypt(FK_COI.ToString());
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

        #region "Professional Liability Policies"
        DataTable dtFields = clsScreen_Validators.SelectByScreen(107).Tables[0];
        dtFields.DefaultView.RowFilter = "IsRequired = '1'";
        dtFields = dtFields.DefaultView.ToTable();
        MenuAsterisk1.Style["display"] = (dtFields.Select("LeftMenuIndex = 12").Length > 0) ? "inline-block" : "none";
        foreach (DataRow drField in dtFields.Rows)
        {
            #region " set validation control IDs and messages "
            switch (Convert.ToString(drField["Field_Name"]))
            {
                case "Insurance Company":
                    strCtrlsIDs += drpCompany.ClientID + ",";
                    strMessages += "Please select [Professional Liability Policies]/Insurance Company" + ",";
                    Span1.Style["display"] = "inline-block";
                    break;
                case "Policy Number":
                    strCtrlsIDs += txtPolicyNumber.ClientID + ",";
                    strMessages += "Please enter [Professional Liability Policies]/Policy Number" + ",";
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
                    strMessages += "Please enter [Professional Liability Policies]/Each Occurrence" + ",";
                    Span7.Style["display"] = "inline-block";
                    break;
                case "Aggregate":
                    strCtrlsIDs += txtAggregate.ClientID + ",";
                    strMessages += "Please enter [Professional Liability Policies]/Aggregate" + ",";
                    Span8.Style["display"] = "inline-block";
                    break;
                case "Notes":
                    strCtrlsIDs += txtNotes.ClientID + ",";
                    strMessages += "Please enter [Professional Liability Policies]/Notes" + ",";
                    Span9.Style["display"] = "inline-block";
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
