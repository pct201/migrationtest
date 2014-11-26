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
public partial class AdditionalInsured : clsBasePage
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
    public int FK_COI
    {
        get
        {
            return clsGeneral.GetInt(ViewState["COI"]);
        }
        set { ViewState["COI"] = value; }

    }
    public int FK_COI_PROP
    {
        get
        {
            return clsGeneral.GetInt(ViewState["COI_PROP"]);
        }
        set { ViewState["COI_PROP"] = value; }

    }
    // FK to indicate AI is for which Location
    public int FK_Table_Name
    {
        get
        {
            return clsGeneral.GetInt(ViewState["COI_Location"]);
        }
        set { ViewState["COI_Location"] = value; }

    }

    // PK for AI
    private int PK_COI_AI
    {
        get
        {
            return clsGeneral.GetInt(ViewState["InsuredID"]);
        }
        set { ViewState["InsuredID"] = value; }
    }

    #endregion

    #region "Page Events"
    /// <summary>
    /// Page Load Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {

        // if page is loaded first time.
        if (!IsPostBack)
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "ShowPanel", "javascript:ShowPanel(1);", true);

            if (App_Access == AccessType.NotAssigned)
                Response.Redirect(AppConfig.SiteURL + "Message.aspx?msg=You are not authorized to access this page");
            else
            {
                // if COI's FK is not passed redirect to default page.
                if (!clsGeneral.IsNull(Request.QueryString["prop"]))
                {
                    // set FK Coi.
                    FK_Table_Name = Convert.ToInt32(clsGeneral.GetQueryStringID(Request.QueryString["prop"]));
                    //if (Request.QueryString["op"] == "view")
                    FK_COI = Convert.ToInt32(clsGeneral.GetQueryStringID(Request.QueryString["coi"]));
                    FK_COI_PROP = Convert.ToInt32(clsGeneral.GetQueryStringID(Request.QueryString["prop"]));

                    // Load COI Control
                    ucCtrlCOIInfo.PK_COIs = FK_COI;
                    ucCtrlCOIInfo.BindrCOIInfo();
                    //bind states
                    BindDropdowns();

                    // if operations(view or edit) is passed in query string.
                    if (!clsGeneral.IsNull(Request.QueryString["op"]))
                    {
                        // if id is passed set primary key.
                        if (!clsGeneral.IsNull(Request.QueryString["id"]))
                        {
                            PK_COI_AI = (int)clsGeneral.GetQueryStringID(Convert.ToString(Request.QueryString["id"]));
                        }
                        _strOperation = Request.QueryString["op"].ToString();
                        if (Request.QueryString["op"] == "view")
                        {
                            dvView.Style["Display"] = "block";
                            BindDetailsForView();
                            // set Attachment details control in read/write mode.
                            AttachDetails.InitializeAttachmentDetails(clsGeneral.Tables.Additional_Insured, PK_COI_AI, false, 2);
                        }
                        else
                        {
                            if (App_Access == AccessType.Administrative_Access)
                            {
                                // set Attachment details control in read/write mode.
                                AttachDetails.InitializeAttachmentDetails(clsGeneral.Tables.Additional_Insured, PK_COI_AI, true, 2);
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
    }

    #endregion

    # region " Private Methods "

    /// <summary>
    /// Binds Dropdown for State and Interest
    /// </summary>
    private void BindDropdowns()
    {
        //State
        DataTable dtStates = COI_State.SelectAll().Tables[0];
        drpState.DataSource = dtStates;
        drpState.DataTextField = "FLD_state";
        drpState.DataValueField = "PK_Id";
        drpState.DataBind();
        drpState.Items.Insert(0, "--Select--");

        //Interest
        DataTable dtInterest = COI_Interest.SelectAll().Tables[0];
        drpInterest.DataSource = dtInterest;
        drpInterest.DataTextField = "Fld_Desc";
        drpInterest.DataValueField = "PK_COI_Interest";
        drpInterest.DataBind();
        drpInterest.Items.Insert(0, "--Select--");
    }

    /// <summary>
    /// show attachment details div and bind the details.
    /// </summary>
    private void BindAttachmentDetails()
    {
        dvAttachment.Style["Display"] = "block";
        AttachDetails.Bind();
    }

    #endregion

    #region "Bind Details for Edit or View"

    /// <summary>
    /// Displays the page in edit mode
    /// </summary>
    private void BindDetailsForEdit()
    {
        dvView.Style["Display"] = "None";
        btnBack.Style["display"] = "none";
        _strOperation = "edit";
        // create object for curernt AI
        COI_AI objAI = new COI_AI(PK_COI_AI);

        // set values
        txtAddress1.Text = objAI.Address_1;
        txtAddress2.Text = objAI.Address_2;
        txtCity.Text = objAI.City;
        drpState.SelectedValue = Convert.ToString(objAI.FK_State);
        txtZipCode.Text = objAI.Zip_Code;
        txtContactLastName.Text = objAI.Last_Name;
        txtContactFirstName.Text = objAI.First_Name;
        txtContactPhone.Text = objAI.Phone;
        txtContactFax.Text = objAI.Fax;
        txtContactEmail.Text = objAI.EMail;
        drpInterest.SelectedValue = Convert.ToString(objAI.FK_COI_Interest);
        txtNotes.Text = objAI.Notes;
        rdoShownOnCOI.SelectedValue = objAI.Shown_On_COI;
    }
    /// <summary>
    /// Displays the page in View mode
    /// </summary>
    private void BindDetailsForView()
    {
        dvEdit.Style["Display"] = "None";
        btnBack.Style["display"] = "block";
        _strOperation = "view";
        // create object for curernt AI
        COI_AI objAI = new COI_AI(PK_COI_AI);

        // set values        
        lblAddress1.Text = objAI.Address_1;
        lblAddress2.Text = objAI.Address_2;
        lblCity.Text = objAI.City;
        if(objAI.FK_State !=null)
        lblState.Text = new COI_State(objAI.FK_State).FLD_state;
        lblZipCode.Text = objAI.Zip_Code;
        lblContactLastName.Text = objAI.Last_Name;
        lblContactFirstName.Text = objAI.First_Name;
        lblContactPhone.Text = objAI.Phone;
        lblContactFax.Text = objAI.Fax;
        lblContactEmail.Text = objAI.EMail;
        if(objAI.FK_COI_Interest !=null)
        lblInterest.Text = new COI_Interest(objAI.FK_COI_Interest).Fld_Desc;
        lblNotes.Text = objAI.Notes;
        lblShownOnCOI.Text = objAI.Shown_On_COI == "Y" ? "YES" : "NO";
    }
    #endregion

    #region "Control Events"

    /// <summary>
    /// Handle Save Button Click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSave_Click(object sender, EventArgs e)
    {
        // check page is valid or not.        
        if (Page.IsValid)
        {
            // create a new object for AI.
            COI_AI objAI = new COI_AI();

            //set values.
            objAI.PK_COI_AI = PK_COI_AI;
            objAI.FK_Table_Name = FK_Table_Name;
            if (!clsGeneral.IsNull(Request.QueryString["Page"]))
            {
                if (Request.QueryString["Page"] == "GL")
                {
                    objAI.Table_Name = "General_Policy";
                }
                else if (Request.QueryString["Page"] == "AL")
                {
                    objAI.Table_Name = "Automobile_Policy";
                }
                else if (Request.QueryString["Page"] == "EP")
                {
                    objAI.Table_Name = "Excess_Policy";
                }
                else if (Request.QueryString["Page"] == "WC")
                {
                    objAI.Table_Name = "Workers_Comp";
                }
                else if (Request.QueryString["Page"] == "PL")
                {
                    objAI.Table_Name = "Professional_Policy";
                }
                else if (Request.QueryString["Page"] == "LP")
                {
                    objAI.Table_Name = "Liqour_Policy";
                }
                else if (Request.QueryString["Page"] == "PP")
                {
                    objAI.Table_Name = "Property_Policy";
                }
            }
            objAI.Address_1 = txtAddress1.Text.Trim();
            objAI.Address_2 = txtAddress2.Text.Trim();
            objAI.City = txtCity.Text.Trim();
            objAI.FK_State = Convert.ToDecimal(drpState.SelectedValue);
            objAI.Zip_Code = txtZipCode.Text.Trim();
            objAI.Last_Name = txtContactLastName.Text.Trim();
            objAI.First_Name = txtContactFirstName.Text.Trim();
            objAI.Phone = txtContactPhone.Text.Trim();
            objAI.Fax = txtContactFax.Text.Trim();
            objAI.EMail = txtContactEmail.Text.Trim();
            objAI.FK_COI_Interest = Convert.ToInt32(drpInterest.SelectedValue);
            objAI.Notes = txtNotes.Text.Trim();
            objAI.Update_Date = DateTime.Today;
            objAI.Updated_By = clsSession.UserName;
            objAI.Shown_On_COI = rdoShownOnCOI.SelectedValue;

            // check if insert or update the AI.
            if (PK_COI_AI > 0)
                objAI.Update();
            else
                PK_COI_AI = objAI.Insert();

            // add attachment if any
            Attachment.Add(clsGeneral.Tables.Additional_Insured, PK_COI_AI);

            // redirect to coi page with changes done to AI band
            btnReturn_Click(null, null);

        }
    }
    /// <summary>
    /// Attachment Control Add Attachment Button event 
    /// </summary>
    /// <param name="sender"></param>
    protected void Attachment_btnHandler(object sender)
    {
        // check if AI reocord is saved or not.
        // if not don't save any attachment
        if (PK_COI_AI > 0)
        {
            Attachment.Add(clsGeneral.Tables.Additional_Insured, PK_COI_AI);
            // after saving attachment bind attachment details again.
            BindAttachmentDetails();
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "ShowPanel", "javascript:ShowPanel(2);", true);
        }
        else
            ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript: alert('Please save Additional Insured First');ShowPanel(1);", true);
    }
    /// <summary>
    /// On Revert and Return button Click Redirect to Parent page
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnReturn_Click(object sender, EventArgs e)
    {
        if (!clsGeneral.IsNull(Request.QueryString["Page"]))
        {
            if (!clsGeneral.IsNull(Request.QueryString["op"]))
            {
                if (Request.QueryString["Page"] == "GL")
                {
                    Response.Redirect("GeneralPolicyAddEdit.aspx?op=" + Request.QueryString["op"] + "&coi=" + Request.QueryString["coi"] + "&id=" + Encryption.Encrypt(FK_Table_Name.ToString()) + "&pnl=2");
                }
                else if (Request.QueryString["Page"] == "AL")
                {
                    Response.Redirect("AutomobilePolicyAddEdit.aspx?op=" + Request.QueryString["op"] + "&coi=" + Request.QueryString["coi"] + "&id=" + Encryption.Encrypt(FK_Table_Name.ToString()) + "&pnl=2");
                }
                else if (Request.QueryString["Page"] == "EP")
                {
                    Response.Redirect("ExcessPolicyAddEdit.aspx?op=" + Request.QueryString["op"] + "&coi=" + Request.QueryString["coi"] + "&id=" + Encryption.Encrypt(FK_Table_Name.ToString()) + "&pnl=2");
                }
                else if (Request.QueryString["Page"] == "WC")
                {
                    Response.Redirect("WCPolicyAddEdit.aspx?op=" + Request.QueryString["op"] + "&coi=" + Request.QueryString["coi"] + "&id=" + Encryption.Encrypt(FK_Table_Name.ToString()) + "&pnl=2");
                }
                else if (Request.QueryString["Page"] == "PL")
                {
                    Response.Redirect("ProfessionalPolicy.aspx?op=" + Request.QueryString["op"] + "&coi=" + Request.QueryString["coi"] + "&id=" + Encryption.Encrypt(FK_Table_Name.ToString()) + "&pnl=2");
                }
                else if (Request.QueryString["Page"] == "LP")
                {
                    Response.Redirect("LiquorPolicyAddEdit.aspx?op=" + Request.QueryString["op"] + "&coi=" + Request.QueryString["coi"] + "&id=" + Encryption.Encrypt(FK_Table_Name.ToString()) + "&pnl=2");
                }
                else if (Request.QueryString["Page"] == "PP")
                {
                    Response.Redirect("PropertyPolicyAddEdit.aspx?op=" + Request.QueryString["op"] + "&coi=" + Request.QueryString["coi"] + "&id=" + Encryption.Encrypt(FK_Table_Name.ToString()) + "&pnl=2");
                }
            }
            else
            {
                if (Request.QueryString["Page"] == "GL")
                {
                    Response.Redirect("GeneralPolicyAddEdit.aspx?op=edit" + "&coi=" + Request.QueryString["coi"] + "&id=" + Encryption.Encrypt(FK_Table_Name.ToString()) + "&pnl=2");
                }
                else if (Request.QueryString["Page"] == "AL")
                {
                    Response.Redirect("AutomobilePolicyAddEdit.aspx?op=edit" + "&coi=" + Request.QueryString["coi"] + "&id=" + Encryption.Encrypt(FK_Table_Name.ToString()) + "&pnl=2");
                }
                else if (Request.QueryString["Page"] == "EP")
                {
                    Response.Redirect("ExcessPolicyAddEdit.aspx?op=edit" + "&coi=" + Request.QueryString["coi"] + "&id=" + Encryption.Encrypt(FK_Table_Name.ToString()) + "&pnl=2");
                }
                else if (Request.QueryString["Page"] == "WC")
                {
                    Response.Redirect("WCPolicyAddEdit.aspx?op=edit" + "&coi=" + Request.QueryString["coi"] + "&id=" + Encryption.Encrypt(FK_Table_Name.ToString()) + "&pnl=2");
                }
                else if (Request.QueryString["Page"] == "PL")
                {
                    Response.Redirect("ProfessionalPolicy.aspx?op=edit" + "&coi=" + Request.QueryString["coi"] + "&id=" + Encryption.Encrypt(FK_Table_Name.ToString()) + "&pnl=2");
                }
                else if (Request.QueryString["Page"] == "LP")
                {
                    Response.Redirect("LiquorPolicyAddEdit.aspx?op=edit" + "&coi=" + Request.QueryString["coi"] + "&id=" + Encryption.Encrypt(FK_Table_Name.ToString()) + "&pnl=2");
                }
                else if (Request.QueryString["Page"] == "PP")
                {
                    Response.Redirect("PropertyPolicyAddEdit.aspx?op=edit" + "&coi=" + Request.QueryString["coi"] + "&id=" + Encryption.Encrypt(FK_Table_Name.ToString()) + "&pnl=2");
                }
            }
        }
    }

    /// <summary>
    /// On Back button Click Redirect to Parent page
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnBack_Click(object sender, EventArgs e)
    {
        btnReturn_Click(sender, e);
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

        #region "Additional Insureds"
        DataTable dtFields = clsScreen_Validators.SelectByScreen(109).Tables[0];
        dtFields.DefaultView.RowFilter = "IsRequired = '1'";
        dtFields = dtFields.DefaultView.ToTable();
        MenuAsterisk1.Style["display"] = (dtFields.Select("LeftMenuIndex = 14").Length > 0) ? "inline-block" : "none";
        foreach (DataRow drField in dtFields.Rows)
        {
            #region " set validation control IDs and messages "
            switch (Convert.ToString(drField["Field_Name"]))
            {
                case "Last Name":
                    strCtrlsIDs += txtContactLastName.ClientID + ",";
                    strMessages += "Please enter [Additional Insured]/Last Name" + ",";
                    Span1.Style["display"] = "inline-block";
                    break;
                case "First Name":
                    strCtrlsIDs += txtContactFirstName.ClientID + ",";
                    strMessages += "Please enter [Additional Insured]/First Name" + ",";
                    Span2.Style["display"] = "inline-block";
                    break;
                case "Address 1":
                    strCtrlsIDs += txtAddress1.ClientID + ",";
                    strMessages += "Please enter [Additional Insured]/Address 1" + ",";
                    Span3.Style["display"] = "inline-block";
                    break;
                case "Address 2":
                    strCtrlsIDs += txtAddress2.ClientID + ",";
                    strMessages += "Please enter [Additional Insured]/Address 2" + ",";
                    Span4.Style["display"] = "inline-block";
                    break;
                case "City":
                    strCtrlsIDs += txtCity.ClientID + ",";
                    strMessages += "Please enter [Additional Insured]/City" + ",";
                    Span5.Style["display"] = "inline-block";
                    break;
                case "Phone":
                    strCtrlsIDs += txtContactPhone.ClientID + ",";
                    strMessages += "Please enter [Additional Insured]/Phone" + ",";
                    Span6.Style["display"] = "inline-block";
                    break;
                case "State":
                    strCtrlsIDs += drpState.ClientID + ",";
                    strMessages += "Please select [Additional Insured]/State" + ",";
                    Span7.Style["display"] = "inline-block";
                    break;
                case "Fax":
                    strCtrlsIDs += txtContactFax.ClientID + ",";
                    strMessages += "Please enter [Additional Insured]/Fax" + ",";
                    Span8.Style["display"] = "inline-block";
                    break;
                case "Zip Code":
                    strCtrlsIDs += txtZipCode.ClientID + ",";
                    strMessages += "Please enter [Additional Insured]/Zip Code" + ",";
                    Span9.Style["display"] = "inline-block";
                    break;
                case "E-Mail":
                    strCtrlsIDs += txtContactEmail.ClientID + ",";
                    strMessages += "Please enter [Additional Insured]/E-Mail" + ",";
                    Span10.Style["display"] = "inline-block";
                    break;
                case "Interest":
                    strCtrlsIDs += drpInterest.ClientID + ",";
                    strMessages += "Please select [Additional Insured]/Interest" + ",";
                    Span11.Style["display"] = "inline-block";
                    break;
                case "Notes":
                    strCtrlsIDs += txtNotes.ClientID + ",";
                    strMessages += "Please enter [Additional Insured]/Notes" + ",";
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
