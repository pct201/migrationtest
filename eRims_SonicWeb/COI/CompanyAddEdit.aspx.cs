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
public partial class Admin_CompanyAddEdit : clsBasePage
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
    // FK to indicate Company is for which COI
    public int FK_COI
    {
        get
        {
            return clsGeneral.GetInt(ViewState["COI"]);
        }
        set { ViewState["COI"] = value; }

    }

    // PK for Comapny
    private int PK_COI_Insurance_Companies
    {
        get
        {
            return clsGeneral.GetInt(ViewState["CompanyID"]);
        }
        set { ViewState["CompanyID"] = value; }
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
        if (App_Access == AccessType.NotAssigned)
            Response.Redirect(AppConfig.SiteURL + "Message.aspx?msg=You are not authorized to access this page");
        else
        {
            // if page is loaded first time.
            if (!IsPostBack)
            {
                ((Button)Attachment.FindControl("btnAddAttachment")).OnClientClick = "javascript:return IfSave();";
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "ShowPanel", "javascript:ShowPanel(1);", true);

                // if COI's FK is not passed redirect to default page.
                if (!clsGeneral.IsNull(Request.QueryString["coi"]))
                {
                    // set FK Coi.
                    FK_COI = Convert.ToInt32(clsGeneral.GetQueryStringID(Request.QueryString["coi"]));

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
                            PK_COI_Insurance_Companies = (int)clsGeneral.GetQueryStringID(Convert.ToString(Request.QueryString["id"]));
                        }
                        _strOperation = Request.QueryString["op"].ToString();
                        if (Request.QueryString["op"] == "view")
                        {
                            dvView.Style["Display"] = "block";
                            BindDetailsForView();
                            // set Attachment details control in read/write mode.
                            AttachDetails.InitializeAttachmentDetails(clsGeneral.Tables.Insurance_Companies, PK_COI_Insurance_Companies, false, 2);
                        }
                        else
                        {
                            if (App_Access == AccessType.Administrative_Access)
                            {
                                // set Attachment details control in read/write mode.
                                AttachDetails.InitializeAttachmentDetails(clsGeneral.Tables.Insurance_Companies, PK_COI_Insurance_Companies, true, 2);
                                BindDetailsForEdit();
                            }
                            else
                                Response.Redirect(Request.Url.ToString().Replace("edit", "view"));
                        }
                        BindAttachmentDetails();
                    }
                    else
                    {
                        if (App_Access == AccessType.Administrative_Access)
                        { } 
                        else
                            Response.Redirect(AppConfig.SiteURL + "Message.aspx?msg=You are not authorized to access this page");
                    }
                }
                else
                {
                    Response.Redirect("Default.aspx");
                }
                SetValidations();
                txtCompany.Focus();
            }
        }
    }

    #endregion

    # region " Private Methods "

    /// <summary>
    /// Binds Dropdown for State and NAICS
    /// </summary>
    private void BindDropdowns()
    {
        DataTable dtStates = COI_State.SelectAll().Tables[0];
        drpState.DataSource = dtStates;
        drpState.DataTextField = "FLD_state";
        drpState.DataValueField = "PK_Id";
        drpState.DataBind();
        drpState.Items.Insert(0, new ListItem("--Select--", "0"));

        DataTable dtNAICS = COI_NAICS.SelectAll().Tables[0];
        drpNAICS.DataSource = dtNAICS;
        drpNAICS.DataTextField = "Fld_Desc";
        drpNAICS.DataValueField = "PK_NAICS";
        drpNAICS.DataBind();
        drpNAICS.Items.Insert(0, new ListItem("--Select--", "0"));       
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
        //btnAddAttachment.Style["Display"] = "block";
        // create object for curernt Company
        COI_Insurance_Companies objCompany = new COI_Insurance_Companies(PK_COI_Insurance_Companies);

        // set values
        txtCompany.Text = objCompany.Company;
        txtAddress1.Text = objCompany.Address_1;
        txtAddress2.Text = objCompany.Address_2;
        txtCity.Text = objCompany.City;
        drpState.SelectedValue = Convert.ToString(objCompany.FK_State);
        txtZipCode.Text = objCompany.Zip_Code;
        txtContactLastName.Text = objCompany.Contact_Last_Name;
        txtContactFirstName.Text = objCompany.Contact_First_Name;
        txtContactTitle.Text = objCompany.Contact_Title;
        txtContactPhone.Text = objCompany.Contact_Phone;
        txtContactFax.Text = objCompany.Contact_Fax;
        txtContactEmail.Text = objCompany.Contact_EMail;
        txtAMBestNumber.Text = objCompany.AM_Number;
        txtAMBestRating.Text = objCompany.AM_Best;
        drpNAICS.SelectedValue = Convert.ToString(objCompany.FK_NAICS);
        txtNotes.Text = objCompany.Notes;

    }

    /// <summary>
    /// Displays the page in view mode
    /// </summary>
    private void BindDetailsForView()
    {
        dvEdit.Style["Display"] = "None";
        // create object for curernt Company
        COI_Insurance_Companies objCompany = new COI_Insurance_Companies(PK_COI_Insurance_Companies);

        // set values
        lblCompany.Text = objCompany.Company;
        lblAddress1.Text = objCompany.Address_1;
        lblAddress2.Text = objCompany.Address_2;
        lblCity.Text = objCompany.City;
        lblState.Text = new COI_State(objCompany.FK_State).FLD_state;
        lblZipCode.Text = objCompany.Zip_Code;
        lblContactLastName.Text = objCompany.Contact_Last_Name;
        lblContactFirstName.Text = objCompany.Contact_First_Name;
        lblContactTitle.Text = objCompany.Contact_Title;
        lblContactPhone.Text = objCompany.Contact_Phone;
        lblContactFax.Text = objCompany.Contact_Fax;
        lblContactEmail.Text = objCompany.Contact_EMail;
        lblAMBestNumber.Text = objCompany.AM_Number;
        lblAMBestRating.Text = objCompany.AM_Best;
        lblNAICS.Text = new COI_NAICS(objCompany.FK_NAICS).Fld_Desc;
        lblNotes.Text = objCompany.Notes;

    }

    #endregion

    #region " Control Events "


    // add or update Company record
    protected void btnSave_Click(object sender, EventArgs e)
    {
        // check page is valid or not.        
        if (Page.IsValid)
        {
            // create a new object for company.
            COI_Insurance_Companies objCompany = new COI_Insurance_Companies();

            //set values.
            objCompany.PK_COI_Insurance_Companies = PK_COI_Insurance_Companies;
            objCompany.FK_COIs = FK_COI;
            objCompany.Company = txtCompany.Text.Trim();
            objCompany.Address_1 = txtAddress1.Text.Trim();
            objCompany.Address_2 = txtAddress2.Text.Trim();
            objCompany.City = txtCity.Text.Trim();
            objCompany.FK_State = Convert.ToDecimal(drpState.SelectedValue);
            objCompany.Zip_Code = txtZipCode.Text.Trim();
            objCompany.Contact_Last_Name = txtContactLastName.Text.Trim();
            objCompany.Contact_First_Name = txtContactFirstName.Text.Trim();
            objCompany.Contact_Title = txtContactTitle.Text.Trim();
            objCompany.Contact_Phone = txtContactPhone.Text.Trim();
            objCompany.Contact_Fax = txtContactFax.Text.Trim();
            objCompany.Contact_EMail = txtContactEmail.Text.Trim();
            objCompany.AM_Number = txtAMBestNumber.Text;
            objCompany.AM_Best = txtAMBestRating.Text;
            objCompany.FK_NAICS = (drpNAICS.SelectedIndex == 0) ? 0 : Convert.ToInt32(drpNAICS.SelectedValue);
            objCompany.Notes = txtNotes.Text.Trim();
            objCompany.Update_Date = DateTime.Today;
            objCompany.Updated_By = clsSession.UserName;

            // check if insert or update the company.
            if (PK_COI_Insurance_Companies > 0)
                objCompany.Update();
            else
                PK_COI_Insurance_Companies = objCompany.Insert();

            // add attachment if any
            Attachment.Add(clsGeneral.Tables.Insurance_Companies, PK_COI_Insurance_Companies);

            //clsGeneral.RedirectToCOIPage(Page, "Company", FK_COI);
            btnBack_Click(sender, e);

        }
    }

    protected void Attachment_btnHandler(object sender)
    {
        // check if Company reocord is saved or not.
        // if not don't save any attachment
        if (PK_COI_Insurance_Companies > 0)
        {
            Attachment.Add(clsGeneral.Tables.Insurance_Companies, PK_COI_Insurance_Companies);

            // after saving attachment bind attachment details again.
            BindAttachmentDetails();
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "ShowPanel", "javascript:ShowPanel(2);", true);

        }
        else
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript: alert('Please Save Insurance Companies Record First.'); ShowPanel(1);", true);
    }

    protected void btnReturn_Click(object sender, EventArgs e)
    {
        //clsGeneral.RedirectToCOIPage(Page, "Company", FK_COI);
        btnBack_Click(sender, e);
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        if (!clsGeneral.IsNull(Request.QueryString["op"]))
            Response.Redirect("COIAddEdit.aspx?op=" + Request.QueryString["op"] + "&coi=" + Request.QueryString["coi"] + "&id=" + Encryption.Encrypt(FK_COI.ToString()) + "&pnl=6");
        else
            Response.Redirect("COIAddEdit.aspx?op=edit" + "&coi=" + Request.QueryString["coi"] + "&id=" + Encryption.Encrypt(FK_COI.ToString()) + "&pnl=6");
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

        #region "Insurance Companies"
        DataTable dtFields = clsScreen_Validators.SelectByScreen(101).Tables[0];
        dtFields.DefaultView.RowFilter = "IsRequired = '1'";
        dtFields = dtFields.DefaultView.ToTable();
        MenuAsterisk1.Style["display"] = (dtFields.Select("LeftMenuIndex = 6").Length > 0) ? "inline-block" : "none";
        foreach (DataRow drField in dtFields.Rows)
        {
            #region " set validation control IDs and messages "
            switch (Convert.ToString(drField["Field_Name"]))
            {
                case "Company":
                    strCtrlsIDs += txtCompany.ClientID + ",";
                    strMessages += "Please enter [Insurance Companies]/Company" + ",";
                    Span1.Style["display"] = "inline-block";
                    break;
                case "Contact Last Name":
                    strCtrlsIDs += txtContactLastName.ClientID + ",";
                    strMessages += "Please enter [Insurance Companies]/Contact Last Name" + ",";
                    Span2.Style["display"] = "inline-block";
                    break;
                case "Address 1":
                    strCtrlsIDs += txtAddress1.ClientID + ",";
                    strMessages += "Please enter [Insurance Companies]/Address 1" + ",";
                    Span3.Style["display"] = "inline-block";
                    break;
                case "Contact First Name":
                    strCtrlsIDs += txtContactFirstName.ClientID + ",";
                    strMessages += "Please enter [Insurance Companies]/Contact First Name" + ",";
                    Span4.Style["display"] = "inline-block";
                    break;
                case "Address 2":
                    strCtrlsIDs += txtAddress2.ClientID + ",";
                    strMessages += "Please enter [Insurance Companies]/Address 2" + ",";
                    Span5.Style["display"] = "inline-block";
                    break;
                case "Contact Title":
                    strCtrlsIDs += txtContactTitle.ClientID + ",";
                    strMessages += "Please enter [Insurance Companies]/Contact Title" + ",";
                    Span6.Style["display"] = "inline-block";
                    break;
                case "City":
                    strCtrlsIDs += txtCity.ClientID + ",";
                    strMessages += "Please enter [Insurance Companies]/City" + ",";
                    Span7.Style["display"] = "inline-block";
                    break;
                case "Contact Phone":
                    strCtrlsIDs += txtContactPhone.ClientID + ",";
                    strMessages += "Please enter [Insurance Companies]/Contact Phone" + ",";
                    Span8.Style["display"] = "inline-block";
                    break;
                case "State":
                    strCtrlsIDs += drpState.ClientID + ",";
                    strMessages += "Please select [Insurance Companies]/State" + ",";
                    Span9.Style["display"] = "inline-block";
                    break;
                case "Contact Fax":
                    strCtrlsIDs += txtContactFax.ClientID + ",";
                    strMessages += "Please enter [Insurance Companies]/Contact Fax" + ",";
                    Span10.Style["display"] = "inline-block";
                    break;
                case "Zip Code":
                    strCtrlsIDs += txtZipCode.ClientID + ",";
                    strMessages += "Please enter [Insurance Companies]/Zip Code" + ",";
                    Span11.Style["display"] = "inline-block";
                    break;
                case "Contact E-Mail":
                    strCtrlsIDs += txtContactEmail.ClientID + ",";
                    strMessages += "Please enter [Insurance Companies]/Contact E-Mail" + ",";
                    Span12.Style["display"] = "inline-block";
                    break;
                case "AM Best Number":
                    strCtrlsIDs += txtAMBestNumber.ClientID + ",";
                    strMessages += "Please enter [Insurance Companies]/AM Best Number" + ",";
                    Span13.Style["display"] = "inline-block";
                    break;
                case "AM Best Rating":
                    strCtrlsIDs += txtAMBestRating.ClientID + ",";
                    strMessages += "Please enter [Insurance Companies]/AM Best Rating" + ",";
                    Span14.Style["display"] = "inline-block";
                    break;
                case "NAICS":
                    strCtrlsIDs += drpNAICS.ClientID + ",";
                    strMessages += "Please select [Insurance Companies]/NAICS" + ",";
                    Span15.Style["display"] = "inline-block";
                    break;
                case "Notes":
                    strCtrlsIDs += txtNotes.ClientID + ",";
                    strMessages += "Please enter [Insurance Companies]/Notes" + ",";
                    Span16.Style["display"] = "inline-block";
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
