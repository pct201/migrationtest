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
public partial class Admin_PropertyPolicyAddEdit : clsBasePage
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
    public int PK_COI_Property_Policies
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
            {

                Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(" + Request.QueryString["pnl"] + ");", true);
                _strOperation = Request.QueryString["op"].ToString();
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(1);", true);
            }
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
                            PK_COI_Property_Policies = (int)clsGeneral.GetQueryStringID(Convert.ToString(Request.QueryString["id"]));



                            BindInsuredGrid();
                            //dvGrid.Style["Display"] = "block";
                        }

                        _strOperation = Request.QueryString["op"].ToString();

                        if (Request.QueryString["op"] == "view")
                        {
                            dvView.Style["Display"] = "block";
                            BindDetailsForView();
                            // set Attachment details control in read/write mode.
                            AttachDetails.InitializeAttachmentDetails(clsGeneral.Tables.Property_Policies, PK_COI_Property_Policies, false, 3);
                        }
                        else
                        {
                            if (App_Access == AccessType.Administrative_Access)
                            {
                                // set Attachment details control in read/write mode.
                                AttachDetails.InitializeAttachmentDetails(clsGeneral.Tables.Property_Policies, PK_COI_Property_Policies, true, 3);
                                BindDetailsForEdit();
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
        clsGeneral.SetDropDownToolTip(new DropDownList[] { drpCompany });
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
        DataTable dtAI = COI_AI.SelectByFK_COI_Locations(PK_COI_Property_Policies, "Property_Policy").Tables[0];
        gvAI.DataSource = dtAI;
        gvAI.DataBind();
        gvAI.Columns[2].Visible = (Request.QueryString["op"] == "view") ? false : true;
    }
    private void SaveRecord()
    {
        // create a new object for Property Policy.
        COI_Property_Policies objPropertyPolicy = new COI_Property_Policies();

        //set values.
        objPropertyPolicy.PK_COI_Property_Policies = PK_COI_Property_Policies;
        objPropertyPolicy.FK_COIs = FK_COI;
        objPropertyPolicy.Insurance_Company = drpCompany.SelectedIndex > 0 ? drpCompany.SelectedValue : string.Empty;
        objPropertyPolicy.Policy_Number = txtPolicyNumber.Text.Trim();
        objPropertyPolicy.Issue_Date = clsGeneral.FormatNullDateToStore(txtIssueDate.Text);
        objPropertyPolicy.Effective_Date = clsGeneral.FormatNullDateToStore(txtEffectiveDate.Text);
        objPropertyPolicy.Expiration_Date = clsGeneral.FormatNullDateToStore(txtExpirationDate.Text);
        objPropertyPolicy.Cancellation_Date = clsGeneral.FormatNullDateToStore(txtCancellationDate.Text);
        objPropertyPolicy.Notes = txtNotes.Text.Trim();
        objPropertyPolicy.Update_Date = DateTime.Today;
        objPropertyPolicy.Updated_By = clsSession.UserName;
        objPropertyPolicy.COI_Property_Policies_Deductible = clsGeneral.GetDecimalValue(txtDeductible);
        objPropertyPolicy.COI_Property_Policies_Building_Occurrence = clsGeneral.GetDecimalValue(txtBuildingValue);
        objPropertyPolicy.Is_Boiler_And_Machinery_Required = rdIsBoilerandMachineryRequired.SelectedValue;
        objPropertyPolicy.Is_Earthquake_Required = rdIsEarthquakeRequired.SelectedValue;
        objPropertyPolicy.Is_Flood_Required = rdIsFloodRequired.SelectedValue;
        objPropertyPolicy.If_No_Boiler_And_Machinery_Required = rdNoBoilerandMachineryRequired.SelectedValue;
        objPropertyPolicy.If_No_Earthquake_Required = rdNoEarthquakeRequired.SelectedValue;
        objPropertyPolicy.If_No_Flood_Required = rdNoFloodRequired.SelectedValue;

        // check if insert or update the Property Policy.
        if (PK_COI_Property_Policies > 0)
            objPropertyPolicy.Update();
        else
        {
            PK_COI_Property_Policies = objPropertyPolicy.Insert();
            //dvGrid.Style["Display"] = "block";
        }

        // add attachment if any
        Attachment.Add(clsGeneral.Tables.Property_Policies, PK_COI_Property_Policies);
    }
    #endregion

    #region "Bind Details for Edit or View"

    /// <summary>
    /// Displays the page in edit mode
    /// </summary>
    private void BindDetailsForEdit()
    {
        dvView.Style["Display"] = "None";
        //dvSave.Style["Display"] = "block";
        // create object for curernt Property Policy
        COI_Property_Policies objPropertyPolicy = new COI_Property_Policies(PK_COI_Property_Policies);

        // set values
        drpCompany.SelectedValue = objPropertyPolicy.Insurance_Company;
        txtPolicyNumber.Text = objPropertyPolicy.Policy_Number;
        txtIssueDate.Text = clsGeneral.FormatDBNullDateToDisplay(objPropertyPolicy.Issue_Date);
        txtEffectiveDate.Text = clsGeneral.FormatDBNullDateToDisplay(objPropertyPolicy.Effective_Date);
        txtExpirationDate.Text = clsGeneral.FormatDBNullDateToDisplay(objPropertyPolicy.Expiration_Date);
        txtExpirationDate.Text = clsGeneral.FormatDBNullDateToDisplay(objPropertyPolicy.Expiration_Date);
        txtCancellationDate.Text = clsGeneral.FormatDBNullDateToDisplay(objPropertyPolicy.Cancellation_Date);
        txtNotes.Text = objPropertyPolicy.Notes;
        txtDeductible.Text = clsGeneral.GetStringValue(objPropertyPolicy.COI_Property_Policies_Deductible);
        txtBuildingValue.Text = clsGeneral.GetStringValue(objPropertyPolicy.COI_Property_Policies_Building_Occurrence);
        rdIsBoilerandMachineryRequired.SelectedValue = objPropertyPolicy.Is_Boiler_And_Machinery_Required;
        rdIsEarthquakeRequired.SelectedValue = objPropertyPolicy.Is_Earthquake_Required;
        rdIsFloodRequired.SelectedValue = objPropertyPolicy.Is_Flood_Required;
        rdNoBoilerandMachineryRequired.SelectedValue = objPropertyPolicy.If_No_Boiler_And_Machinery_Required;
        rdNoEarthquakeRequired.SelectedValue = objPropertyPolicy.If_No_Earthquake_Required;
        rdNoFloodRequired.SelectedValue = objPropertyPolicy.If_No_Flood_Required;
    }

    /// <summary>
    /// Displays the page in view mode
    /// </summary>
    private void BindDetailsForView()
    {
        dvEdit.Style["Display"] = "None";
        //dvBack.Style["Display"] = "block";       
        lnkGeneralAdd.Style["Display"] = "None";
        // create object for curernt Property Policy
        COI_Property_Policies objPropertyPolicy = new COI_Property_Policies(PK_COI_Property_Policies);

        // set values
        lblCompany.Text = objPropertyPolicy.Insurance_Company;
        lblPolicyNumber.Text = objPropertyPolicy.Policy_Number;
        lblIssueDate.Text = clsGeneral.FormatDBNullDateToDisplay(objPropertyPolicy.Issue_Date);
        lblEffectiveDate.Text = clsGeneral.FormatDBNullDateToDisplay(objPropertyPolicy.Effective_Date);
        lblExpirationDate.Text = clsGeneral.FormatDBNullDateToDisplay(objPropertyPolicy.Expiration_Date);
        lblCancellationDate.Text = clsGeneral.FormatDBNullDateToDisplay(objPropertyPolicy.Cancellation_Date);
        lblNotes.Text = objPropertyPolicy.Notes;
        lblDeductible.Text = clsGeneral.GetStringValue(objPropertyPolicy.COI_Property_Policies_Deductible);
        lblBuildingValue.Text = clsGeneral.GetStringValue(objPropertyPolicy.COI_Property_Policies_Building_Occurrence);
        lblIsBoilerandMachineryRequired.Text = (objPropertyPolicy.Is_Boiler_And_Machinery_Required == "Y") ? "Yes" : "No";
        lblIsEarthquakeRequired.Text = (objPropertyPolicy.Is_Earthquake_Required == "Y") ? "Yes" : "No";
        lblIsFloodRequired.Text = (objPropertyPolicy.Is_Flood_Required == "Y") ? "Yes" : "No";
        lblNoBoilerandMachineryRequired.Text = (objPropertyPolicy.If_No_Boiler_And_Machinery_Required == "Y") ? "Yes" : "No";
        lblNoEarthquakeRequired.Text = (objPropertyPolicy.If_No_Earthquake_Required == "Y") ? "Yes" : "No";
        lblNoFloodRequired.Text = (objPropertyPolicy.If_No_Flood_Required == "Y") ? "Yes" : "No";

    }

    #endregion

    #region " Control Events "

    protected void btnSaveReturn_Click(object sender, EventArgs e)
    {
        btnSave_Click(null, null);
        // redirect to coi page with changes done to Property Policy band
        //clsGeneral.RedirectToCOIPage(Page, "Property", FK_COI);
        btnBack_Click(sender, e);
    }

    // add or update Property Policy record
    protected void btnSave_Click(object sender, EventArgs e)
    {
        // check page is valid or not.        
        if (Page.IsValid)
        {
            SaveRecord();
            // set Attachment details control in read/write mode.
            AttachDetails.InitializeAttachmentDetails(clsGeneral.Tables.Property_Policies, PK_COI_Property_Policies, true, 0);
            BindAttachmentDetails();
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(1);", true);
        }
    }

    protected void Attachment_btnHandler(object sender)
    {
        // check if Property Policy reocord is saved or not.
        // if not don't save any attachment
        if (PK_COI_Property_Policies > 0)
        {
            Attachment.Add(clsGeneral.Tables.Property_Policies, PK_COI_Property_Policies);

            // after saving attachment bind attachment details again.
            BindAttachmentDetails();
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(3);", true);
        }
        else
            ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript: alert('Please save Property Policies First');ShowPanel(1);", true);
    }

    protected void btnBackToCOI_Click(object sender, EventArgs e)
    {
        // redirect to coi page with changes done to Property Policy band
        //clsGeneral.RedirectToCOIPage(Page, "Property", FK_COI);
        btnBack_Click(sender, e);
    }

    protected void gvAI_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "RemoveInsured")
        {
            COI_AI.Delete(Convert.ToDecimal(e.CommandArgument));
            BindInsuredGrid();
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "ShowPanel", "javascript:ShowPanel(2);", true);
        }
    }
    protected void btnDummyForSave_Click(object sender, EventArgs e)
    {
        SaveRecord();
        string strPath = string.Empty;

        if (!string.IsNullOrEmpty(hdnPageName.Value))
        {
            if (hdnPageName.Value.IndexOf("?") > 0)
                strPath = hdnPageName.Value + "&Page=PP&prop=" + Encryption.Encrypt(PK_COI_Property_Policies.ToString()) + "&coi=" + Encryption.Encrypt(FK_COI.ToString()) + "&op=" + Request.QueryString["op"];
            else
                strPath = hdnPageName.Value + "?Page=PP&prop=" + Encryption.Encrypt(PK_COI_Property_Policies.ToString()) + "&coi=" + Encryption.Encrypt(FK_COI.ToString());
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

        #region "Property Policies"
        DataTable dtFields = clsScreen_Validators.SelectByScreen(106).Tables[0];
        dtFields.DefaultView.RowFilter = "IsRequired = '1'";
        dtFields = dtFields.DefaultView.ToTable();
        MenuAsterisk1.Style["display"] = (dtFields.Select("LeftMenuIndex = 11").Length > 0) ? "inline-block" : "none";
        foreach (DataRow drField in dtFields.Rows)
        {
            #region " set validation control IDs and messages "
            switch (Convert.ToString(drField["Field_Name"]))
            {
                case "Insurance Company":
                    strCtrlsIDs += drpCompany.ClientID + ",";
                    strMessages += "Please select [Property Policies]/Insurance Company" + ",";
                    Span1.Style["display"] = "inline-block";
                    break;
                case "Policy Number":
                    strCtrlsIDs += txtPolicyNumber.ClientID + ",";
                    strMessages += "Please enter [Property Policies]/Policy Number" + ",";
                    Span2.Style["display"] = "inline-block";
                    break;
                case "Issue Date":
                    strCtrlsIDs += txtIssueDate.ClientID + ",";
                    strMessages += "Please enter [Property Policies]/Issue Date" + ",";
                    Span3.Style["display"] = "inline-block";
                    break;
                case "Effective Date":
                    strCtrlsIDs += txtEffectiveDate.ClientID + ",";
                    strMessages += "Please enter [Property Policies]/Effective Date" + ",";
                    Span4.Style["display"] = "inline-block";
                    break;
                case "Expiration Date":
                    strCtrlsIDs += txtExpirationDate.ClientID + ",";
                    strMessages += "Please enter [Property Policies]/Expiration Date" + ",";
                    Span5.Style["display"] = "inline-block";
                    break;
                case "Cancellation Date":
                    strCtrlsIDs += txtCancellationDate.ClientID + ",";
                    strMessages += "Please enter [Property Policies]/Cancellation Date" + ",";
                    Span6.Style["display"] = "inline-block";
                    break;
                case "Deductible":
                    strCtrlsIDs += txtDeductible.ClientID + ",";
                    strMessages += "Please enter [Property Policies]/Deductible" + ",";
                    Span7.Style["display"] = "inline-block";
                    break;
                case "Building Value":
                    strCtrlsIDs += txtBuildingValue.ClientID + ",";
                    strMessages += "Please enter [Property Policies]/Building Value" + ",";
                    Span8.Style["display"] = "inline-block";
                    break;
                case "Notes":
                    strCtrlsIDs += txtNotes.ClientID + ",";
                    strMessages += "Please enter [Property Policies]/Notes" + ",";
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
