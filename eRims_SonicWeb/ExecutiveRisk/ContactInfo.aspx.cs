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

public partial class ExecutiveRisk_ContactInfo : clsBasePage
{
    #region Property

    /// <summary>
    /// Denotes primary key for Executive_Risk_Contacts record
    /// </summary>
    public int PK_Executive_Risk_Contacts
    {
        get { return Convert.ToInt32(ViewState["PK_Executive_Risk_Contacts"]); }
        set { ViewState["PK_Executive_Risk_Contacts"] = value; }
    }

    /// <summary>
    /// Get executive risk id which foreign key for Executive_Risk_Contacts record
    /// </summary>
    public int FK_Executive_Risk
    {
        get
        {
            if (!String.IsNullOrEmpty(Request.QueryString["eid"]))
            {
                return Convert.ToInt32(Convert.ToString(Request.QueryString["eid"]));
            }
            else
            {
                return -1;
            }
        }
    }

    /// <summary>
    /// Gets operation either edit or view if passed in querystring else it returns empty string
    /// </summary>
    public String strOperation
    {
        get
        {
            if (!String.IsNullOrEmpty(Request.QueryString["op"]))
            {
                return Convert.ToString(Request.QueryString["op"]);
            }
            else
            {
                return String.Empty;
            }
        }
    }

    #endregion

    #region Page Events

    protected void Page_Load(object sender, EventArgs e)
    {
        Attachment.btnHandler += new Controls_Attachments_Attachment.OnButtonClick(Upload_File);
        ExecutiveRiskInfo.SetSelectedTab(CtrlExecutiveRiskInfo.Tab.Executive_Risk);
        if (!Page.IsPostBack)
        {
            // shows the first panel
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(1);", true);
            
            // check the foreign key is available otherwise redirect to executive risk page
            if (FK_Executive_Risk > 0)
            {
                // if querystring for operation to be performed is passed(view or edit)
                if (strOperation != string.Empty)
                {
                    // set PK_Executive_Risk_Contacts
                    PK_Executive_Risk_Contacts = Convert.ToInt32(Request.QueryString["id"]);

                    if (strOperation == "view")
                    {
                        // Bind Controls
                        BindDetailsForView();
                        // set attachment details control in readonly mode.
                        AttachDetails.InitializeAttachmentDetails(clsGeneral.Tables.Executive_Risk_Contacts, PK_Executive_Risk_Contacts, false, 2);
                    }
                    else
                    {
                        // bind the state dropdown
                        BindDropDownState();

                        // Bind Controls
                        BindDetailsForEdit();
                        // set attachment details control in read/write mode. so user can add or remove attachment as well.                        
                        AttachDetails.InitializeAttachmentDetails(clsGeneral.Tables.Executive_Risk_Contacts, PK_Executive_Risk_Contacts, true, 2);
                        //bind state drop down list                 
                    }
                    // bind attachment details to show attachment for current risk profile.
                    BindAttachmentDetails();
                }
                else
                {
                    // check for the access 
                    if (UserAccessType == AccessType.Executive_Risk_View)
                    {
                        Response.Redirect(AppConfig.SiteURL + "Error.aspx?msg=errAcc");
                    }
                    else
                    {
                        // hide Add Attachment button
                        Attachment.ShowAttachmentButton = false;
                        btnViewAudit.Visible = false;
                        btnAuditView.Visible = false;
                        // bind the state dropdown
                        BindDropDownState();
                        // don't show div for view mode
                        dvView.Style["Display"] = "None";
                        BindAttachmentDetails();
                    }
                }
                if (strOperation != "view")
                    SetValidations();
            }
            else
            {
                Response.Redirect("ExecutiveRisk.aspx");
            }            
        }
    }

    #endregion

    #region Controls Event
    /// <summary>
    /// Handles Save And View Button click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSaveAndView_Click(object sender, EventArgs e)
    {
        // check for page valid
        if (Page.IsValid)
        {
            // create object for Executive_Risk_Contacts class
            Executive_Risk_Contacts objContact = new Executive_Risk_Contacts();

            // set key values
            objContact.PK_Executive_Risk_Contacts = PK_Executive_Risk_Contacts;
            objContact.FK_Executive_Risk = FK_Executive_Risk;

            // set values from page controls
            objContact.Contact_Name = txtContactName.Text.Trim();
            objContact.Contact_Type = drpContactType.SelectedValue;
            objContact.Addtess1 = txtAddress1.Text.Trim();
            objContact.Address2 = txtAddress2.Text.Trim();
            objContact.City = txtCity.Text.Trim();
            objContact.FK_State = drpState.SelectedIndex > 0 ? Convert.ToDecimal(drpState.SelectedValue) : -1;
            objContact.Zip_Code = txtZipcode.Text.Trim();
            objContact.Tel_Number = txtTelNum.Text.Trim();
            objContact.Email = txtEmail.Text.Trim();
            objContact.Cell_Phone = txtCellPhone.Text.Trim();

            
            // insert or update the record depending on Primary key
            if (PK_Executive_Risk_Contacts > 0)
                objContact.Update();
            else
                PK_Executive_Risk_Contacts = objContact.Insert();

            // add attachment if any.
            Attachment.Add(clsGeneral.Tables.Executive_Risk_Contacts, PK_Executive_Risk_Contacts);
            //redirect page in view mode
            String strQueryString = Request.QueryString.ToString();
            if (!String.IsNullOrEmpty(strOperation) && strOperation == "edit")
                strQueryString = strQueryString.Replace("edit", "view");
            else
                strQueryString = strQueryString + "&op=view&id=" + PK_Executive_Risk_Contacts;

            Response.Redirect("ContactInfo.aspx?" + strQueryString);

        }
    }

    /// <summary>
    /// Handles back button click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnBack_Click(object sender, EventArgs e)
    {
        // redirect to executive risk page
        Response.Redirect("ExecutiveRisk.aspx?id=" + FK_Executive_Risk + "&pnl=6");
    }

    #endregion

    #region Methods

    /// <summary>
    /// Sets the page in view mode
    /// </summary>
    private void BindDetailsForView()
    {

        // show view div
        dvView.Style["Display"] = "block";

        // don't show div edit in viewmode.
        dvEdit.Style["Display"] = "None";
        btnBack.Visible = true;
        btnViewAudit.Visible = false;
        btnAuditView.Visible = true;
        // create object for Executive_Risk_Contacts class
        Executive_Risk_Contacts objContact = new Executive_Risk_Contacts(PK_Executive_Risk_Contacts);

        // set values from page controls
        lblContactType.Text = objContact.Contact_Type;
        lblContactName.Text = objContact.Contact_Name;
        lblAddress1.Text = objContact.Addtess1;
        lblAddress2.Text = objContact.Address2;
        lblCity.Text = objContact.City;
        if (objContact.FK_State > 0)
        { lblState.Text = new State(objContact.FK_State).FLD_state; }
        lblZipcode.Text = objContact.Zip_Code;
        lblTelNum.Text = objContact.Tel_Number;
        lblEmail.Text = objContact.Email;
        lblCellPhone.Text = objContact.Cell_Phone;

    }

    /// <summary>
    /// Sets the page in edit mode
    /// </summary>
    private void BindDetailsForEdit()
    {
        // create object for Executive_Risk_Contacts class
        Executive_Risk_Contacts objContact = new Executive_Risk_Contacts(PK_Executive_Risk_Contacts);

        btnViewAudit.Visible = true;
        btnAuditView.Visible = false;

        // set values in page controls
        drpContactType.SelectedValue = objContact.Contact_Type;
        txtContactName.Text = objContact.Contact_Name;
        txtAddress1.Text = objContact.Addtess1;
        txtAddress2.Text = objContact.Address2;
        txtCity.Text = objContact.City;
        if (objContact.FK_State > 0)
        { drpState.SelectedValue = objContact.FK_State.ToString(); }
        txtZipcode.Text = objContact.Zip_Code;
        txtTelNum.Text = objContact.Tel_Number;
        txtEmail.Text = objContact.Email;
        txtCellPhone.Text = objContact.Cell_Phone;
    }


    #endregion

    #region "Bind DropDowns"

    // Binds the state drop down
    private void BindDropDownState()
    {
        DataTable dtState = State.SelectAll().Tables[0];
        drpState.DataSource = dtState;
        drpState.DataTextField = "FLD_state";
        drpState.DataValueField = "PK_ID";
        drpState.DataBind();
        drpState.Items.Insert(0, "--Select State--");
    }

    #endregion

    #region "Attachments Management"

    /// <summary>
    /// Binds the attachment details
    /// </summary>
    private void BindAttachmentDetails()
    {
        dvAttachment.Style["Display"] = "block";
        AttachDetails.Bind();
    }

    /// <summary>
    /// handles Add Attachment button click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    void Upload_File(string strValue)
    {
        if (PK_Executive_Risk_Contacts > 0)
        {
            // add attachment if any.
            Attachment.Add(clsGeneral.Tables.Executive_Risk_Contacts, PK_Executive_Risk_Contacts);
            // Bind the attachment detail to view the added attachment
            BindAttachmentDetails();
            // show attachment panel as the page is loaded again
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(2);", true);
        }
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

        #region "Contact Information"
        DataTable dtFields = clsScreen_Validators.SelectByScreen(82).Tables[0];
        dtFields.DefaultView.RowFilter = "IsRequired = '1'";
        dtFields = dtFields.DefaultView.ToTable();

        MenuAsterisk1.Style["display"] = (dtFields.Select("LeftMenuIndex = 1").Length > 0) ? "inline-block" : "none";

        foreach (DataRow drField in dtFields.Rows)
        {
            #region " set validation control IDs and messages "
            switch (Convert.ToString(drField["Field_Name"]))
            {
                case "Contact Type":
                    strCtrlsIDs += drpContactType.ClientID + ",";
                    strMessages += "Please select [Contact Information]/Contact Type" + ",";
                    Span1.Style["display"] = "inline-block";
                    break;
                case "Contact Name":
                    strCtrlsIDs += txtContactName.ClientID + ",";
                    strMessages += "Please enter [Contact Information]/Contact Name" + ",";
                    Span2.Style["display"] = "inline-block";
                    break;
                case "Contact Telephone Number":
                    strCtrlsIDs += txtTelNum.ClientID + ",";
                    strMessages += "Please enter [Contact Information]/Contact Telephone Number" + ",";
                    Span3.Style["display"] = "inline-block";
                    break;
                case "Contact Address 1":
                    strCtrlsIDs += txtAddress1.ClientID + ",";
                    strMessages += "Please enter [Contact Information]/Contact Address 1" + ",";
                    Span4.Style["display"] = "inline-block";
                    break;
                case "Contact Address 2":
                    strCtrlsIDs += txtAddress2.ClientID + ",";
                    strMessages += "Please enter [Contact Information]/Contact Address 2" + ",";
                    Span5.Style["display"] = "inline-block";
                    break;
                case "Contact City":
                    strCtrlsIDs += txtCity.ClientID + ",";
                    strMessages += "Please enter [Contact Information]/Contact City" + ",";
                    Span6.Style["display"] = "inline-block";
                    break;
                case "Contact State":
                    strCtrlsIDs += drpState.ClientID + ",";
                    strMessages += "Please select [Contact Information]/Contact State" + ",";
                    Span7.Style["display"] = "inline-block";
                    break;
                case "Contact Zip Code":
                    strCtrlsIDs += txtZipcode.ClientID + ",";
                    strMessages += "Please enter [Contact Information]/Contact Zip Code" + ",";
                    Span8.Style["display"] = "inline-block";
                    break;
                case "Contact E-Mail":
                    strCtrlsIDs += txtEmail.ClientID + ",";
                    strMessages += "Please enter [Contact Information]/Contact E-Mail" + ",";
                    Span9.Style["display"] = "inline-block";
                    break;
                case "Contact Cell Phone":
                    strCtrlsIDs += txtCellPhone.ClientID + ",";
                    strMessages += "Please enter [Contact Information]/Contact Cell Phone" + ",";
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
