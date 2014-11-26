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
/// Modified By:Dhruti Desai on 12Nov2010
/// Purpose: 
/// To add, edit and view the Executive Risk Expense record
/// 
/// Functionality:
/// Checks for the querystring value for operation 
/// and sets the page controls in view or edit or add mode accordingly
/// Also performs attachments adding, listing and removing
/// </summary>
public partial class PropertyLiability_ExecutiveRiskExpenses : clsBasePage
{
    #region Property

    /// <summary>
    /// Denotes primary key for Executive Risk Expense record
    /// </summary>
    public int PK_Executive_Risk_Expenses
    {
        get { return Convert.ToInt32(ViewState["PK_Executive_Risk_Expenses"]); }
        set { ViewState["PK_Executive_Risk_Expenses"] = value; }
    }

    /// <summary>
    /// Get executive risk id which foreign key for Executive Risk Expense record
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
    /// Gets operation either edit or view else it return empty string 
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
            // shows the first panel
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(1);", true);

            // check for the foreign key is available otherwise redirect to executive risk page
            if (FK_Executive_Risk > 0)
            {
                if (strOperation != string.Empty)
                {
                    // set PK_Executive_Risk_Expenses
                    PK_Executive_Risk_Expenses = Convert.ToInt32(Request.QueryString["id"]);

                    if (strOperation == "view")
                    {
                        // Bind Controls
                        BindDetailsForView();
                        // set attachment details control in readonly mode.
                        AttachDetails.InitializeAttachmentDetails(clsGeneral.Tables.Executive_Risk_Expenses, PK_Executive_Risk_Expenses, false, 2);
                    }
                    else
                    {
                        if (UserAccessType == AccessType.Executive_Risk_View)
                        {
                            Response.Redirect(Request.Url.ToString().Replace("edit", "view"));
                        }
                        else
                        {
                            // Bind Controls
                            BindDetailsForEdit();
                            // set attachment details control in read/write mode. so user can add or remove attachment as well.                        
                            AttachDetails.InitializeAttachmentDetails(clsGeneral.Tables.Executive_Risk_Expenses, PK_Executive_Risk_Expenses, true, 2);
                        }
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
                        // hide the add attachment button
                        Attachment.ShowAttachmentButton = false;
                        btnAuditView.Visible = false;
                        btnViewAudit.Visible = false;
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
            // create object
            Executive_Risk_Expenses objExpenses = new Executive_Risk_Expenses();

            // set key values
            objExpenses.PK_Executive_Risk_Expenses = PK_Executive_Risk_Expenses;
            objExpenses.FK_Executive_Risk = FK_Executive_Risk;

            // set values from page controls
            objExpenses.Company = txtCompany.Text.Trim();
            objExpenses.Invoice = txtInvoice.Text.Trim();
            objExpenses.Amount = clsGeneral.GetDecimalValue(txtAmount);
            objExpenses.Date = clsGeneral.FormatDateToStore(txtDate);
            objExpenses.Notes = txtNotes.Text.Trim();

            objExpenses.Update_Date = DateTime.Now;
            objExpenses.Updated_By = clsSession.UserID.ToString();

            // insert or update the record depending on Primary key
            if (PK_Executive_Risk_Expenses > 0)
                objExpenses.Update();
            else
                PK_Executive_Risk_Expenses = objExpenses.Insert();
            Upload_File("");
            //redirect page in view mode
            String strQueryString = Request.QueryString.ToString();
            if (!String.IsNullOrEmpty(strOperation) && strOperation == "edit")
                strQueryString = strQueryString.Replace("edit", "view");
            else
                strQueryString = strQueryString + "&op=view&id=" + PK_Executive_Risk_Expenses;

            Response.Redirect("ExecutiveRiskExpenses.aspx?" + strQueryString);

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
        Response.Redirect("ExecutiveRisk.aspx?id=" + FK_Executive_Risk + "&pnl=10");
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
        Executive_Risk_Expenses objExpenses = new Executive_Risk_Expenses(PK_Executive_Risk_Expenses);

        // set values in page controls
        lblCompany.Text = objExpenses.Company;
        lblInvoice.Text = objExpenses.Invoice;
        lblAmount.Text = clsGeneral.GetStringValue(objExpenses.Amount);
        lblDate.Text = clsGeneral.FormatDateToDisplay(objExpenses.Date);
        lblNotes.Text = objExpenses.Notes;
    }

    /// <summary>
    /// Sets the page in edit mode
    /// </summary>
    private void BindDetailsForEdit()
    {
        // create object
        Executive_Risk_Expenses objExpenses = new Executive_Risk_Expenses(PK_Executive_Risk_Expenses);

        btnAuditView.Visible = false;
        btnViewAudit.Visible = true;

        // set values in page controls
        txtCompany.Text = objExpenses.Company;
        txtInvoice.Text = objExpenses.Invoice;
        txtAmount.Text = clsGeneral.GetStringValue(objExpenses.Amount);
        txtDate.Text = clsGeneral.FormatDateToDisplay(objExpenses.Date);
        txtNotes.Text = objExpenses.Notes;

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
    /// Handles the Add Attachment button click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    void Upload_File(string strValue)
    {
        if (PK_Executive_Risk_Expenses > 0)
        {
            // add attachment if any.
            Attachment.Add(clsGeneral.Tables.Executive_Risk_Expenses, PK_Executive_Risk_Expenses);

            // bind the attachment details to show the added attachment
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

        #region "Expense Grid"
        DataTable dtFields = clsScreen_Validators.SelectByScreen(86).Tables[0];
        dtFields.DefaultView.RowFilter = "IsRequired = '1'";
        dtFields = dtFields.DefaultView.ToTable();

        MenuAsterisk1.Style["display"] = (dtFields.Select("LeftMenuIndex = 1").Length > 0) ? "inline-block" : "none";

        foreach (DataRow drField in dtFields.Rows)
        {
            #region " set validation control IDs and messages "
            switch (Convert.ToString(drField["Field_Name"]))
            {
                case "Company": strCtrlsIDs += txtCompany.ClientID + ","; strMessages += "Please enter [Executive Risk Expenses]/Company" + ","; Span1.Style["display"] = "inline-block"; break;
                case "Invoice": strCtrlsIDs += txtInvoice.ClientID + ","; strMessages += "Please enter [Executive Risk Expenses]/Invoice" + ","; Span2.Style["display"] = "inline-block"; break;
                case "Amount": strCtrlsIDs += txtAmount.ClientID + ","; strMessages += "Please enter [Executive Risk Expenses]/Amount" + ","; Span3.Style["display"] = "inline-block"; break;
                case "Date": strCtrlsIDs += txtDate.ClientID + ","; strMessages += "Please enter [Executive Risk Expenses]/Date" + ","; Span4.Style["display"] = "inline-block"; break;
                case "Notes": strCtrlsIDs += txtNotes.ClientID + ","; strMessages += "Please enter [Executive Risk Expenses]/Notes" + ","; Span5.Style["display"] = "inline-block"; break;
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
