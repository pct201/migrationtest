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
using System.IO;
public partial class Admin_ProducersAddEdit : clsBasePage
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
    private int PK_COI_Producers
    {
        get
        {
            return clsGeneral.GetInt(ViewState["ProducersID"]);
        }
        set { ViewState["ProducersID"] = value; }
    }

    #endregion

    #region "Page Events"

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
                // if COI's FK is not passed redirect to default page.
                if (!clsGeneral.IsNull(Request.QueryString["coi"]))
                {
                    // set FK Coi.
                    FK_COI = Convert.ToInt32(clsGeneral.GetQueryStringID(Request.QueryString["coi"]));
                    //To Load COI Control
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
                            PK_COI_Producers = (int)clsGeneral.GetQueryStringID(Convert.ToString(Request.QueryString["id"]));
                        }
                        _strOperation = Request.QueryString["op"].ToString();
                        if (Request.QueryString["op"] == "view")
                        {
                            dvView.Style["Display"] = "block";
                            BindDetailsForView();
                            // set Attachment details control in read/write mode.
                            AttachDetails.InitializeAttachmentDetails(clsGeneral.Tables.Producers, PK_COI_Producers, false, 2);

                        }
                        else
                        {
                            if (App_Access == AccessType.Administrative_Access)
                            {
                                // set Attachment details control in read/write mode.
                                AttachDetails.InitializeAttachmentDetails(clsGeneral.Tables.Producers, PK_COI_Producers, true, 2);
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
                        { } //btnAddAttachment.Style["Display"] = "block";
                        else
                            Response.Redirect(AppConfig.SiteURL + "Message.aspx?msg=You are not authorized to access this page");
                    }
                }
                else
                {
                    Response.Redirect("Default.aspx");
                }
            }
            SetValidations();
            txtCompany.Focus();
        }
    }

    #endregion

    # region " Private Methods "

    /// <summary>
    /// Binds Dropdown for State
    /// </summary>
    private void BindDropdowns()
    {
        DataTable dtStates = COI_State.SelectAll().Tables[0];
        drpState.DataSource = dtStates;
        drpState.DataTextField = "FLD_state";
        drpState.DataValueField = "PK_Id";
        drpState.DataBind();
        drpState.Items.Insert(0, "--Select--");
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
        // create object for curernt Producer
        COI_Producers objProducers = new COI_Producers(PK_COI_Producers);

        // set values
        txtCompany.Text = objProducers.Company;
        txtAddress1.Text = objProducers.Address_1;
        txtAddress2.Text = objProducers.Address_2;
        txtCity.Text = objProducers.City;
        drpState.SelectedValue = objProducers.FK_State.ToString();
        txtZipCode.Text = objProducers.Zip_Code;
        txtContactLastName.Text = objProducers.Contact_Last_Name;
        txtContactFirstName.Text = objProducers.Contact_First_Name;
        txtContactTitle.Text = objProducers.Contact_Title;
        txtContactPhone.Text = objProducers.Contact_Phone;
        txtContactFax.Text = objProducers.Contact_Fax;
        txtContactEmail.Text = objProducers.Contact_EMail;
        txtNotes.Text = objProducers.Notes;

    }

    /// <summary>
    /// Displays the page in view mode
    /// </summary>
    private void BindDetailsForView()
    {
        dvEdit.Style["Display"] = "None";
        // create object for curernt Producer
        COI_Producers objProducers = new COI_Producers(PK_COI_Producers);

        // set values
        lblCompany.Text = objProducers.Company;
        lblAddress1.Text = objProducers.Address_1;
        lblAddress2.Text = objProducers.Address_2;
        lblCity.Text = objProducers.City;
        lblState.Text = new COI_State(objProducers.FK_State).FLD_state;
        lblZipCode.Text = objProducers.Zip_Code;
        lblContactLastName.Text = objProducers.Contact_Last_Name;
        lblContactFirstName.Text = objProducers.Contact_First_Name;
        lblContactTitle.Text = objProducers.Contact_Title;
        lblContactPhone.Text = objProducers.Contact_Phone;
        lblContactFax.Text = objProducers.Contact_Fax;
        lblContactEmail.Text = objProducers.Contact_EMail;
        lblNotes.Text = objProducers.Notes;

    }

    #endregion

    #region " Control Events "
    // add or update producer record
    protected void btnSave_Click(object sender, EventArgs e)
    {
        // check page is valid or not.        
        if (Page.IsValid)
        {
            // create a new object for producer.
            COI_Producers objProducers = new COI_Producers();

            //set values.
            objProducers.PK_COI_Producers = PK_COI_Producers;
            objProducers.FK_COIs = FK_COI;
            objProducers.Company = txtCompany.Text.Trim();
            objProducers.Address_1 = txtAddress1.Text.Trim();
            objProducers.Address_2 = txtAddress2.Text.Trim();
            objProducers.City = txtCity.Text.Trim();
            objProducers.FK_State = Convert.ToDecimal(drpState.SelectedValue);
            objProducers.Zip_Code = txtZipCode.Text.Trim();
            objProducers.Contact_Last_Name = txtContactLastName.Text.Trim();
            objProducers.Contact_First_Name = txtContactFirstName.Text.Trim();
            objProducers.Contact_Title = txtContactTitle.Text.Trim();
            objProducers.Contact_Phone = txtContactPhone.Text.Trim();
            objProducers.Contact_Fax = txtContactFax.Text.Trim();
            objProducers.Contact_EMail = txtContactEmail.Text.Trim();
            objProducers.Notes = txtNotes.Text.Trim();
            objProducers.Update_Date = DateTime.Today;
            objProducers.Updated_By = clsSession.UserName;

            // check if insert or update the producer.
            if (PK_COI_Producers > 0)
                objProducers.Update();
            else
                PK_COI_Producers = objProducers.Insert();

            // add attachment if any
            Attachment.Add(clsGeneral.Tables.Producers, PK_COI_Producers);
            btnBack_Click(sender, e);
            //clsGeneral.RedirectToCOIPage(Page, "Producer", FK_COI);
        }
    }

    protected void Attachment_btnHandler(object sender)
    {
        // check if producer reocord is saved or not.
        // if not don't save any attachment
        if (PK_COI_Producers > 0)
        {
            Attachment.Add(clsGeneral.Tables.Producers, PK_COI_Producers);

            // after saving attachment bind attachment details again.
            BindAttachmentDetails();
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "ShowPanel", "javascript:ShowPanel(2);", true);
        }
        else
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript: alert('Please Save Producers Record First.'); ShowPanel(1);", true);
    }

    protected void btnReturn_Click(object sender, EventArgs e)
    {
        //clsGeneral.RedirectToCOIPage(Page, "Producer", FK_COI);
        btnBack_Click(sender, e);
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        if (!clsGeneral.IsNull(Request.QueryString["op"]))
            Response.Redirect("COIAddEdit.aspx?op=" + Request.QueryString["op"] + "&coi=" + Request.QueryString["coi"] + "&id=" + Encryption.Encrypt(FK_COI.ToString()) + "&pnl=5");
        else
            Response.Redirect("COIAddEdit.aspx?op=edit" + "&coi=" + Request.QueryString["coi"] + "&id=" + Encryption.Encrypt(FK_COI.ToString()) + "&pnl=5");
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

        #region "Producers"
        DataTable dtFields = clsScreen_Validators.SelectByScreen(100).Tables[0];
        dtFields.DefaultView.RowFilter = "IsRequired = '1'";
        dtFields = dtFields.DefaultView.ToTable();
        MenuAsterisk1.Style["display"] = (dtFields.Select("LeftMenuIndex = 5").Length > 0) ? "inline-block" : "none";
        foreach (DataRow drField in dtFields.Rows)
        {
            #region " set validation control IDs and messages "
            switch (Convert.ToString(drField["Field_Name"]))
            {
                case "Company":
                    strCtrlsIDs += txtCompany.ClientID + ",";
                    strMessages += "Please enter [Producer]/Company" + ",";
                    Span1.Style["display"] = "inline-block";
                    break;
                case "Contact Last Name":
                    strCtrlsIDs += txtContactLastName.ClientID + ",";
                    strMessages += "Please enter [Producer]/Contact Last Name" + ",";
                    Span2.Style["display"] = "inline-block";
                    break;
                case "Address 1":
                    strCtrlsIDs += txtAddress1.ClientID + ",";
                    strMessages += "Please enter [Producer]/Address 1" + ",";
                    Span3.Style["display"] = "inline-block";
                    break;
                case "Contact First Name":
                    strCtrlsIDs += txtContactFirstName.ClientID + ",";
                    strMessages += "Please enter [Producer]/Contact First Name" + ",";
                    Span4.Style["display"] = "inline-block";
                    break;
                case "Address 2":
                    strCtrlsIDs += txtAddress2.ClientID + ",";
                    strMessages += "Please enter [Producer]/Address 2" + ",";
                    Span5.Style["display"] = "inline-block";
                    break;
                case "Contact Title":
                    strCtrlsIDs += txtContactTitle.ClientID + ",";
                    strMessages += "Please enter [Producer]/Contact Title" + ",";
                    Span6.Style["display"] = "inline-block";
                    break;
                case "City":
                    strCtrlsIDs += txtCity.ClientID + ",";
                    strMessages += "Please enter [Producer]/City" + ",";
                    Span7.Style["display"] = "inline-block";
                    break;
                case "Contact Phone":
                    strCtrlsIDs += txtContactPhone.ClientID + ",";
                    strMessages += "Please enter [Producer]/Contact Phone" + ",";
                    Span8.Style["display"] = "inline-block";
                    break;
                case "State":
                    strCtrlsIDs += drpState.ClientID + ",";
                    strMessages += "Please select [Producer]/State" + ",";
                    Span9.Style["display"] = "inline-block";
                    break;
                case "Contact Fax":
                    strCtrlsIDs += txtContactFax.ClientID + ",";
                    strMessages += "Please enter [Producer]/Contact Fax" + ",";
                    Span10.Style["display"] = "inline-block";
                    break;
                case "Zip Code":
                    strCtrlsIDs += txtZipCode.ClientID + ",";
                    strMessages += "Please enter [Producer]/Zip Code" + ",";
                    Span11.Style["display"] = "inline-block";
                    break;
                case "Contact E-Mail":
                    strCtrlsIDs += txtContactEmail.ClientID + ",";
                    strMessages += "Please enter [Producer]/Contact E-Mail" + ",";
                    Span12.Style["display"] = "inline-block";
                    break;
                case "Notes":
                    strCtrlsIDs += txtNotes.ClientID + ",";
                    strMessages += "Please enter [Producer]/Notes" + ",";
                    Span13.Style["display"] = "inline-block";
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
