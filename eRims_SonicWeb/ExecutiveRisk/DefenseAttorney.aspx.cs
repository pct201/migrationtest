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
/// <summary>
/// Date : 29 MAY 2008
/// 
/// By : Hetal Prajapati
/// Modified By: Dhruti Desai on 12Nov2010
/// Purpose: 
/// To add, edit and view the Defense Attorney record
/// 
/// Functionality:
/// Checks for the querystring value for operation 
/// and sets the page controls in view or edit or add mode accordingly
/// Also performs attachments adding, listing and removing
/// </summary>
public partial class PropertyLiability_DefenseAttorney : clsBasePage
{
    #region Property

    /// <summary>
    /// Denotes primary key for defense attorney record
    /// </summary>
    public int PK_Defense_Attorney
    {
        get { return Convert.ToInt32(ViewState["PK_Defense_Attorney"]); }
        set { ViewState["PK_Defense_Attorney"] = value; }
    }

    /// <summary>
    /// Get executive risk id which foreign key for defense attorney record
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
        ExecutiveRiskInfo.SetSelectedTab(CtrlExecutiveRiskInfo.Tab.Executive_Risk);
        Attachment.btnHandler += new Controls_Attachments_Attachment.OnButtonClick(Upload_File);
        // if page is loaded first time 
        if (!Page.IsPostBack)
        {
            // show first panel
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(1);", true);

            // check for the foreign key is available otherwise redirect to expense page
            if (FK_Executive_Risk > 0)
            {
                // if querystring for operation to be performed is passed(view or edit);
                if (strOperation != string.Empty)
                {
                    // set PK_Defense_Attorney
                    PK_Defense_Attorney = Convert.ToInt32(Request.QueryString["id"]);

                    if (strOperation == "view")
                    {
                        // Bind Controls
                        BindDetailsForView();
                        // set attachment details control in readonly mode.
                        AttachDetails.InitializeAttachmentDetails(clsGeneral.Tables.Defense_Attorney, PK_Defense_Attorney, false, 2);
                    }
                    else
                    {
                        if (UserAccessType == AccessType.Executive_Risk_View)
                        {
                            Response.Redirect(Request.Url.ToString().Replace("edit", "view"));
                        }
                        else
                        {
                            // bind state dropdown
                            BindDropDownState();
                            // Bind Controls
                            BindDetailsForEdit();
                            // set attachment details control in read/write mode. so user can add or remove attachment as well.                        
                            AttachDetails.InitializeAttachmentDetails(clsGeneral.Tables.Defense_Attorney, PK_Defense_Attorney, true, 2);
                            //bind state drop down list                 
                        }
                    }
                    // bind attachment details to show attachment for current attorney record
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
                        // hide the add attachment button
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
    /// Handles Save and View button click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSaveAndView_Click(object sender, EventArgs e)
    {
        // check for page valid
        if (Page.IsValid)
        {
            // create object
            Defense_Attorney objAttorney = new Defense_Attorney();

            // set key values
            objAttorney.PK_Defense_Attorney = PK_Defense_Attorney;
            objAttorney.FK_Executive_Risk = FK_Executive_Risk;

            // set values from page controls
            objAttorney.Firm = txtFirm.Text.Trim();
            objAttorney.Name = txtName.Text.Trim();
            objAttorney.Address_1 = txtAddress1.Text.Trim();
            objAttorney.Address_2 = txtAddress2.Text.Trim();
            objAttorney.City = txtCity.Text.Trim();
            objAttorney.FK_State = drpState.SelectedIndex > 0 ? Convert.ToDecimal(drpState.SelectedValue) : -1;
            objAttorney.Zip_Code = txtZipcode.Text.Trim();
            objAttorney.Telephone = txtTelephone.Text.Trim();
            objAttorney.E_Mail = txtEmail.Text.Trim();
            objAttorney.Panel = rdoPanel.SelectedValue;
            objAttorney.Notes = txtNotes.Text.Trim();

            objAttorney.Update_Date = DateTime.Now;
            objAttorney.Updated_By = clsSession.UserID;

            // insert or update the record depending on Primary key
            if (PK_Defense_Attorney > 0)
                objAttorney.Update();
            else
                PK_Defense_Attorney = objAttorney.Insert();
            Upload_File(string.Empty);

            //redirect page in view mode
            String strQueryString = Request.QueryString.ToString();
            if (!String.IsNullOrEmpty(strOperation) && strOperation == "edit")
                strQueryString = strQueryString.Replace("edit", "view");
            else
                strQueryString = strQueryString + "&op=view&id=" + PK_Defense_Attorney;

            Response.Redirect("DefenseAttorney.aspx?" + strQueryString);

        }
    }

    /// <summary>
    /// Handles Back button click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnBack_Click(object sender, EventArgs e)
    {
        // redirect to executive risk page 
        Response.Redirect("ExecutiveRisk.aspx?id=" + FK_Executive_Risk + "&pnl=8");
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
        // create object
        Defense_Attorney objAttorney = new Defense_Attorney(PK_Defense_Attorney);

        // set values from page controls
        lblFirm.Text = objAttorney.Firm;
        lblName.Text = objAttorney.Name;
        lblAddress1.Text = objAttorney.Address_1;
        lblAddress2.Text = objAttorney.Address_2;
        lblCity.Text = objAttorney.City;
        if (objAttorney.FK_State > 0)
            lblState.Text = new State(objAttorney.FK_State).FLD_state;

        lblZipcode.Text = objAttorney.Zip_Code;
        lblTelephone.Text = objAttorney.Telephone;
        lblEmail.Text = objAttorney.E_Mail;
        lblPanel.Text = objAttorney.Panel == "Y" ? "YES" : "NO";
        lblNotes.Text = objAttorney.Notes;


    }

    /// <summary>
    /// Sets the page in edit mode
    /// </summary>
    private void BindDetailsForEdit()
    {
        // create object
        Defense_Attorney objAttorney = new Defense_Attorney(PK_Defense_Attorney);

        btnViewAudit.Visible = true;
        btnAuditView.Visible = false;

        // set values in page controls
        txtFirm.Text = objAttorney.Firm;
        txtName.Text = objAttorney.Name;
        txtAddress1.Text = objAttorney.Address_1;
        txtAddress2.Text = objAttorney.Address_2;
        txtCity.Text = objAttorney.City;
        if (objAttorney.FK_State > 0)
            drpState.SelectedValue = objAttorney.FK_State.ToString();

        txtZipcode.Text = objAttorney.Zip_Code;
        txtTelephone.Text = objAttorney.Telephone;
        txtEmail.Text = objAttorney.E_Mail;
        rdoPanel.SelectedValue = objAttorney.Panel;
        txtNotes.Text = objAttorney.Notes;

    }

    #endregion

    #region "Other Methods"

    /// <summary>
    /// Binds the state drop down
    /// </summary>
    private void BindDropDownState()
    {
        // Get the state data and bind the dropdown
        DataTable dtState = State.SelectAll().Tables[0];
        drpState.DataSource = dtState;
        drpState.DataTextField = "FLD_state";
        drpState.DataValueField = "PK_ID";
        drpState.DataBind();
        drpState.Items.Insert(0, new ListItem( "--Select State--","0"));
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
    /// Handles Add Attachment button click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    void Upload_File(string strValue)
    {
        if (PK_Defense_Attorney > 0)
        {
            // add attachment if any.
            Attachment.Add(clsGeneral.Tables.Defense_Attorney, PK_Defense_Attorney);
            // bind attachment detail to show the added attachment
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

        #region "Legal - Defense Attorney"
        DataTable dtFields = clsScreen_Validators.SelectByScreen(84).Tables[0];
        dtFields.DefaultView.RowFilter = "IsRequired = '1'";
        dtFields = dtFields.DefaultView.ToTable();

        MenuAsterisk1.Style["display"] = (dtFields.Select("LeftMenuIndex = 8").Length > 0) ? "inline-block" : "none";

        foreach (DataRow drField in dtFields.Rows)
        {
            #region " set validation control IDs and messages "
            switch (Convert.ToString(drField["Field_Name"]))
            {
                case "Defense Attorney - Firm":
                    strCtrlsIDs += txtFirm.ClientID + ",";
                    strMessages += "Please enter [Defense Attorney]/Firm" + ",";
                    Span1.Style["display"] = "inline-block";
                    break;
                case "Defense Attorney - Name":
                    strCtrlsIDs += txtName.ClientID + ",";
                    strMessages += "Please enter [Defense Attorney]/Name" + ",";
                    Span2.Style["display"] = "inline-block";
                    break;
                case "Defense Attorney - Address 1":
                    strCtrlsIDs += txtAddress1.ClientID + ",";
                    strMessages += "Please enter [Defense Attorney]/Address 1" + ",";
                    Span3.Style["display"] = "inline-block";
                    break;
                case "Defense Attorney - Address 2":
                    strCtrlsIDs += txtAddress2.ClientID + ",";
                    strMessages += "Please enter [Defense Attorney]/Address 2" + ",";
                    Span4.Style["display"] = "inline-block";
                    break;
                case "Defense Attorney - City":
                    strCtrlsIDs += txtCity.ClientID + ",";
                    strMessages += "Please enter [Defense Attorney]/City" + ",";
                    Span5.Style["display"] = "inline-block";
                    break;
                case "Defense Attorney - State":
                    strCtrlsIDs += drpState.ClientID + ",";
                    strMessages += "Please select [Defense Attorney]/State" + ",";
                    Span6.Style["display"] = "inline-block";
                    break;
                case "Defense Attorney - Zip Code":
                    strCtrlsIDs += txtZipcode.ClientID + ",";
                    strMessages += "Please enter [Defense Attorney]/Zip Code" + ",";
                    Span7.Style["display"] = "inline-block";
                    break;
                case "Defense Attorney - Telephone":
                    strCtrlsIDs += txtTelephone.ClientID + ",";
                    strMessages += "Please enter [Defense Attorney]/Telephone" + ",";
                    Span8.Style["display"] = "inline-block";
                    break;
                case "Defense Attorney - E-Mail":
                    strCtrlsIDs += txtEmail.ClientID + ",";
                    strMessages += "Please enter [Defense Attorney]/E-Mail" + ",";
                    Span9.Style["display"] = "inline-block";
                    break;
                case "Defense Attorney - Notes":
                    strCtrlsIDs += txtNotes.ClientID + ",";
                    strMessages += "Please enter [Defense Attorney]/Notes" + ",";
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
