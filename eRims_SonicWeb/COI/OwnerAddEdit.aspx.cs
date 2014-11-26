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
public partial class Admin_OwnerAddEdit : clsBasePage
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
    // FK to indicate Owner is for which COI
    public int FK_COI
    {
        get
        {
            return clsGeneral.GetInt(ViewState["COI"]);
        }
        set { ViewState["COI"] = value; }

    }

    // PK for Owner
    private int PK_COI_Owners
    {
        get
        {
            return clsGeneral.GetInt(ViewState["OwnerID"]);
        }
        set { ViewState["OwnerID"] = value; }
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

                    // Load COI Control
                    ucCtrlCOIInfo.PK_COIs = FK_COI;
                    ucCtrlCOIInfo.BindrCOIInfo();

                    //bind dropdowns
                    BindDropdowns();

                    // if operations(view or edit) is passed in query string.
                    if (!clsGeneral.IsNull(Request.QueryString["op"]))
                    {
                        // if id is passed set primary key.
                        if (!clsGeneral.IsNull(Request.QueryString["id"]))
                        {
                            PK_COI_Owners = (int)clsGeneral.GetQueryStringID(Convert.ToString(Request.QueryString["id"]));
                        }
                        _strOperation = Request.QueryString["op"].ToString();

                        if (Request.QueryString["op"] == "view")
                        {
                            dvView.Style["Display"] = "block";
                            BindDetailsForView();
                            // set Attachment details control in read/write mode.
                            AttachDetails.InitializeAttachmentDetails(clsGeneral.Tables.Owners, PK_COI_Owners, false, 2);

                        }
                        else
                        {
                            if (App_Access == AccessType.Administrative_Access)
                            {
                                // set Attachment details control in read/write mode.
                                AttachDetails.InitializeAttachmentDetails(clsGeneral.Tables.Owners, PK_COI_Owners, true, 2);
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
                        { } //btnAddAttachment.Visible = false;
                        else
                            Response.Redirect(AppConfig.SiteURL + "Message.aspx?msg=You are not authorized to access this page");
                    }
                }
                else
                {
                    Response.Redirect("Default.aspx");
                }
                SetValidations();
            }
            txtContactLastName.Focus();
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
        // create object for curernt Owner
        COI_Owners objOwner = new COI_Owners(PK_COI_Owners);

        // set values
        txtAddress1.Text = objOwner.Address_1;
        txtAddress2.Text = objOwner.Address_2;
        txtCity.Text = objOwner.City;
        drpState.SelectedValue = objOwner.FK_State.ToString();
        txtZipCode.Text = objOwner.Zip_Code;
        txtContactLastName.Text = objOwner.Last_Name;
        txtContactFirstName.Text = objOwner.First_Name;
        txtContactPhone.Text = objOwner.Phone;
        txtContactFax.Text = objOwner.Fax;
        txtContactEmail.Text = objOwner.EMail;
        txtNotes.Text = objOwner.Notes;

    }
    
    /// <summary>
    ///Dispalys the page in view mode 
    /// </summary>
    private void BindDetailsForView()
    {
        dvEdit.Style["Display"] = "None";
        // create object for curernt Owner
        COI_Owners objOwner = new COI_Owners(PK_COI_Owners);

        // set values        
        lblAddress1.Text = objOwner.Address_1;
        lblAddress2.Text = objOwner.Address_2;
        lblCity.Text = objOwner.City;
        lblState.Text = new COI_State(objOwner.FK_State).FLD_state;
        lblZipCode.Text = objOwner.Zip_Code;
        lblContactLastName.Text = objOwner.Last_Name;
        lblContactFirstName.Text = objOwner.First_Name;
        lblContactPhone.Text = objOwner.Phone;
        lblContactFax.Text = objOwner.Fax;
        lblContactEmail.Text = objOwner.EMail;
        lblNotes.Text = objOwner.Notes;
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
            // create a new object for Owner.
            COI_Owners objOwner = new COI_Owners();

            //set values.
            objOwner.PK_COI_Owners = PK_COI_Owners;
            objOwner.FK_COIs = FK_COI;
            objOwner.Address_1 = txtAddress1.Text.Trim();
            objOwner.Address_2 = txtAddress2.Text.Trim();
            objOwner.City = txtCity.Text.Trim();
            objOwner.FK_State = Convert.ToDecimal(drpState.SelectedValue);
            objOwner.Zip_Code = txtZipCode.Text.Trim();
            objOwner.Last_Name = txtContactLastName.Text.Trim();
            objOwner.First_Name = txtContactFirstName.Text.Trim();
            objOwner.Phone = txtContactPhone.Text.Trim();
            objOwner.Fax = txtContactFax.Text.Trim();
            objOwner.EMail = txtContactEmail.Text.Trim();
            objOwner.Notes = txtNotes.Text.Trim();
            objOwner.Update_Date = DateTime.Today;
            objOwner.Updated_By = clsSession.UserName;

            // check if insert or update the Owner.
            if (PK_COI_Owners > 0)
                objOwner.Update();
            else
                PK_COI_Owners = objOwner.Insert();

            // add attachment if any
            Attachment.Add(clsGeneral.Tables.Owners, PK_COI_Owners);

            // redirect to coi page with changes done to Owner band
            // clsGeneral.RedirectToCOIPage(Page, "Owner", FK_COI);
            btnReturn_Click(sender, e);
        }
    }
    /// <summary>
    /// Attachment Control Add Attachment Button Click Event
    /// </summary>
    /// <param name="sender"></param>
    protected void Attachment_btnHandler(object sender)
    {
        // check if Owner reocord is saved or not.
        // if not don't save any attachment
        if (PK_COI_Owners > 0)
        {
            Attachment.Add(clsGeneral.Tables.Owners, PK_COI_Owners);
            // after saving attachment bind attachment details again.
            BindAttachmentDetails();
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "ShowPanel", "javascript:ShowPanel(2);", true);
        }
        else
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript: alert('Please Save Owners Record First.'); ShowPanel(1);", true);
    }
    /// <summary>
    /// Handle Return Button Click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnReturn_Click(object sender, EventArgs e)
    {
        // redirect to coi page without changes done to Owner band
        //clsGeneral.RedirectToCOIPage(Page, "Owner", FK_COI);
        if (!clsGeneral.IsNull(Request.QueryString["op"]))
            Response.Redirect("COIAddEdit.aspx?op=" + Request.QueryString["op"] + "&coi=" + Request.QueryString["coi"] + "&id=" + Encryption.Encrypt(FK_COI.ToString()) + "&pnl=8");
        else
            Response.Redirect("COIAddEdit.aspx?op=edit" + "&coi=" + Request.QueryString["coi"] + "&id=" + Encryption.Encrypt(FK_COI.ToString()) + "&pnl=8");
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

        #region "Owners"
        DataTable dtFields = clsScreen_Validators.SelectByScreen(110).Tables[0];
        dtFields.DefaultView.RowFilter = "IsRequired = '1'";
        dtFields = dtFields.DefaultView.ToTable();
        MenuAsterisk1.Style["display"] = (dtFields.Select("LeftMenuIndex = 15").Length > 0) ? "inline-block" : "none";
        foreach (DataRow drField in dtFields.Rows)
        {
            #region " set validation control IDs and messages "
            switch (Convert.ToString(drField["Field_Name"]))
            {
                case "Last Name":
                    strCtrlsIDs += txtContactLastName.ClientID + ",";
                    strMessages += "Please enter [Owners]/Last Name" + ",";
                    Span1.Style["display"] = "inline-block";
                    break;
                case "First Name":
                    strCtrlsIDs += txtContactFirstName.ClientID + ",";
                    strMessages += "Please enter [Owners]/First Name" + ",";
                    Span2.Style["display"] = "inline-block";
                    break;
                case "Address 1":
                    strCtrlsIDs += txtAddress1.ClientID + ",";
                    strMessages += "Please enter [Owners]/Address 1" + ",";
                    Span3.Style["display"] = "inline-block";
                    break;
                case "Address 2":
                    strCtrlsIDs += txtAddress2.ClientID + ",";
                    strMessages += "Please enter [Owners]/Address 2" + ",";
                    Span4.Style["display"] = "inline-block";
                    break;
                case "City":
                    strCtrlsIDs += txtCity.ClientID + ",";
                    strMessages += "Please enter [Owners]/City" + ",";
                    Span5.Style["display"] = "inline-block";
                    break;
                case "Phone":
                    strCtrlsIDs += txtContactPhone.ClientID + ",";
                    strMessages += "Please enter [Owners]/Phone" + ",";
                    Span6.Style["display"] = "inline-block";
                    break;
                case "State":
                    strCtrlsIDs += drpState.ClientID + ",";
                    strMessages += "Please select [Owners]/State" + ",";
                    Span7.Style["display"] = "inline-block";
                    break;
                case "Fax":
                    strCtrlsIDs += txtContactFax.ClientID + ",";
                    strMessages += "Please enter [Owners]/Fax" + ",";
                    Span8.Style["display"] = "inline-block";
                    break;
                case "Zip Code":
                    strCtrlsIDs += txtZipCode.ClientID + ",";
                    strMessages += "Please enter [Owners]/Zip Code" + ",";
                    Span9.Style["display"] = "inline-block";
                    break;
                case "E-Mail":
                    strCtrlsIDs += txtContactEmail.ClientID + ",";
                    strMessages += "Please enter [Owners]/E-Mail" + ",";
                    Span10.Style["display"] = "inline-block";
                    break;
                case "Notes":
                    strCtrlsIDs += txtNotes.ClientID + ",";
                    strMessages += "Please enter [Owners]/Notes" + ",";
                    Span11.Style["display"] = "inline-block";
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
