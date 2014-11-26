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
public partial class Admin_CopiesAddEdit : clsBasePage
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
    private int PK_COI_Copies
    {
        get
        {
            return clsGeneral.GetInt(ViewState["CopiesID"]);
        }
        set { ViewState["CopiesID"] = value; }
    }

    #endregion

    #region "Page Events"

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
                            PK_COI_Copies = (int)clsGeneral.GetQueryStringID(Convert.ToString(Request.QueryString["id"]));
                        }
                        _strOperation = Request.QueryString["op"].ToString();
                        if (Request.QueryString["op"] == "view")
                        {
                            dvView.Style["Display"] = "block";
                            BindDetailsForView();
                            // set Attachment details control in read/write mode.
                            AttachDetails.InitializeAttachmentDetails(clsGeneral.Tables.Copies, PK_COI_Copies, false, 2);
                        }
                        else
                        {
                            if (App_Access == AccessType.Administrative_Access)
                            {
                                // set Attachment details control in read/write mode.
                                AttachDetails.InitializeAttachmentDetails(clsGeneral.Tables.Copies, PK_COI_Copies, true, 2);
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
                txtCompany.Focus();
            }
            SetValidations();
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
        _strOperation = "edit";
        // create object for curernt Producer
        COI_Copies objCopies = new COI_Copies(PK_COI_Copies);

        // set values
        txtCompany.Text = objCopies.Name;
        txtAddress1.Text = objCopies.Address_1;
        txtAddress2.Text = objCopies.Address_2;
        txtCity.Text = objCopies.City;
        drpState.SelectedValue = Convert.ToString(objCopies.FK_State);
        txtZipCode.Text = objCopies.Zip_Code;
        txtContactLastName.Text = objCopies.Contact_Last_Name;
        txtContactFirstName.Text = objCopies.Contact_First_Name;
        txtContactTitle.Text = objCopies.Contact_Title;
        txtContactPhone.Text = objCopies.Contact_Phone;
        txtContactFax.Text = objCopies.Contact_Fax;
        txtContactEmail.Text = objCopies.Contact_EMail;
        txtNotes.Text = objCopies.Notes;
        rdoGenerateEnvelope.SelectedValue = objCopies.Envelope;

    }

    /// <summary>
    /// Displays the page in view mode
    /// </summary>
    private void BindDetailsForView()
    {
        dvEdit.Style["Display"] = "None";
        // create object for curernt Producer
        COI_Copies objCopies = new COI_Copies(PK_COI_Copies);
        _strOperation = "view";
        // set values
        lblCompany.Text = objCopies.Name;
        lblAddress1.Text = objCopies.Address_1;
        lblAddress2.Text = objCopies.Address_2;
        lblCity.Text = objCopies.City;
        if(objCopies.FK_State !=null)
        lblState.Text = new COI_State(objCopies.FK_State).FLD_state;
        lblZipCode.Text = objCopies.Zip_Code;
        lblContactLastName.Text = objCopies.Contact_Last_Name;
        lblContactFirstName.Text = objCopies.Contact_First_Name;
        lblContactTitle.Text = objCopies.Contact_Title;
        lblContactPhone.Text = objCopies.Contact_Phone;
        lblContactFax.Text = objCopies.Contact_Fax;
        lblContactEmail.Text = objCopies.Contact_EMail;
        lblNotes.Text = objCopies.Notes;
        lblGenerateEnvelope.Text = objCopies.Envelope == "Y" ? "YES" : "NO";
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
            COI_Copies objCopies = new COI_Copies();

            //set values.
            objCopies.PK_COI_Copies = PK_COI_Copies;
            objCopies.FK_COIs = FK_COI;
            objCopies.Name = txtCompany.Text.Trim();
            objCopies.Address_1 = txtAddress1.Text.Trim();
            objCopies.Address_2 = txtAddress2.Text.Trim();
            objCopies.City = txtCity.Text.Trim();
            objCopies.FK_State = Convert.ToDecimal(drpState.SelectedValue);
            objCopies.Zip_Code = txtZipCode.Text.Trim();
            objCopies.Contact_Last_Name = txtContactLastName.Text.Trim();
            objCopies.Contact_First_Name = txtContactFirstName.Text.Trim();
            objCopies.Contact_Title = txtContactTitle.Text.Trim();
            objCopies.Contact_Phone = txtContactPhone.Text.Trim();
            objCopies.Contact_Fax = txtContactFax.Text.Trim();
            objCopies.Contact_EMail = txtContactEmail.Text.Trim();
            objCopies.Notes = txtNotes.Text.Trim();
            objCopies.Update_Date = DateTime.Today;
            objCopies.Updated_By = clsSession.UserName;
            objCopies.Envelope = rdoGenerateEnvelope.SelectedValue;

            // check if insert or update the producer.
            if (PK_COI_Copies > 0)
                objCopies.Update();
            else
                PK_COI_Copies = objCopies.Insert();

            // add attachment if any
            Attachment.Add(clsGeneral.Tables.Copies, PK_COI_Copies);

            // redirect to coi page with changes done to copies band          
            btnBack_Click(sender, e);
        }
    }
    /// <summary>
    /// Handle Add Attachment Button click Event
    /// </summary>
    /// <param name="sender"></param>
    protected void Attachment_btnHandler(object sender)
    {
        // check if producer reocord is saved or not.
        // if not don't save any attachment
        if (PK_COI_Copies > 0)
        {
            Attachment.Add(clsGeneral.Tables.Copies, PK_COI_Copies);

            // after saving attachment bind attachment details again.
            BindAttachmentDetails();
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "ShowPanel", "javascript:ShowPanel(2);", true);
        }
        else
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript: alert('Please Save Copies Record First.'); ShowPanel(1);", true);
    }

    /// <summary>
    /// Handle Return Button click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnReturn_Click(object sender, EventArgs e)
    {
        // redirect to coi page without changes done to copies band
        clsGeneral.RedirectToCOIPage(Page, "Copies", FK_COI);
    }
    /// <summary>
    /// Handle Back Button click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnBack_Click(object sender, EventArgs e)
    {
        if (!clsGeneral.IsNull(Request.QueryString["op"]))
            Response.Redirect("COIAddEdit.aspx?op=" + Request.QueryString["op"] + "&coi=" + Request.QueryString["coi"] + "&id=" + Encryption.Encrypt(FK_COI.ToString()) + "&pnl=9");
        else
            Response.Redirect("COIAddEdit.aspx?op=edit" + "&coi=" + Request.QueryString["coi"] + "&id=" + Encryption.Encrypt(FK_COI.ToString()) + "&pnl=9");
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

        #region "Copies"
        DataTable dtFields = clsScreen_Validators.SelectByScreen(111).Tables[0];
        dtFields.DefaultView.RowFilter = "IsRequired = '1'";
        dtFields = dtFields.DefaultView.ToTable();
        MenuAsterisk1.Style["display"] = (dtFields.Select("LeftMenuIndex = 16").Length > 0) ? "inline-block" : "none";
        foreach (DataRow drField in dtFields.Rows)
        {
            #region " set validation control IDs and messages "
            switch (Convert.ToString(drField["Field_Name"]))
            {
                case "Company":
                    strCtrlsIDs += txtCompany.ClientID + ",";
                    strMessages += "Please enter [Copies]/Company" + ",";
                    Span1.Style["display"] = "inline-block";
                    break;
                case "Contact Last Name":
                    strCtrlsIDs += txtContactLastName.ClientID + ",";
                    strMessages += "Please enter [Copies]/Contact Last Name" + ",";
                    Span2.Style["display"] = "inline-block";
                    break;
                case "Address 1":
                    strCtrlsIDs += txtAddress1.ClientID + ",";
                    strMessages += "Please enter [Copies]/Address 1" + ",";
                    Span3.Style["display"] = "inline-block";
                    break;
                case "Contact First Name":
                    strCtrlsIDs += txtContactFirstName.ClientID + ",";
                    strMessages += "Please enter [Copies]/Contact First Name" + ",";
                    Span4.Style["display"] = "inline-block";
                    break;
                case "Address 2":
                    strCtrlsIDs += txtAddress2.ClientID + ",";
                    strMessages += "Please enter [Copies]/Address 2" + ",";
                    Span5.Style["display"] = "inline-block";
                    break;
                case "Contact Title":
                    strCtrlsIDs += txtContactTitle.ClientID + ",";
                    strMessages += "Please enter [Copies]/Contact Title" + ",";
                    Span6.Style["display"] = "inline-block";
                    break;
                case "City":
                    strCtrlsIDs += txtCity.ClientID + ",";
                    strMessages += "Please enter [Copies]/City" + ",";
                    Span7.Style["display"] = "inline-block";
                    break;
                case "Contact Phone":
                    strCtrlsIDs += txtContactPhone.ClientID + ",";
                    strMessages += "Please enter [Copies]/Contact Phone" + ",";
                    Span8.Style["display"] = "inline-block";
                    break;
                case "State":
                    strCtrlsIDs += drpState.ClientID + ",";
                    strMessages += "Please select [Copies]/State" + ",";
                    Span9.Style["display"] = "inline-block";
                    break;
                case "Contact Fax":
                    strCtrlsIDs += txtContactFax.ClientID + ",";
                    strMessages += "Please enter [Copies]/Contact Fax" + ",";
                    Span10.Style["display"] = "inline-block";
                    break;
                case "Zip Code":
                    strCtrlsIDs += txtZipCode.ClientID + ",";
                    strMessages += "Please enter [Copies]/Zip Code" + ",";
                    Span11.Style["display"] = "inline-block";
                    break;
                case "Contact E-Mail":
                    strCtrlsIDs += txtContactEmail.ClientID + ",";
                    strMessages += "Please enter [Copies]/Contact E-Mail" + ",";
                    Span12.Style["display"] = "inline-block";
                    break;
                case "Notes":
                    strCtrlsIDs += txtNotes.ClientID + ",";
                    strMessages += "Please enter [Copies]/Notes" + ",";
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
