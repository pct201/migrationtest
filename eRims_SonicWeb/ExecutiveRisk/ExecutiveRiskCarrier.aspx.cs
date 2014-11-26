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
/// By : Hetal Prajapati
/// Modified By : Dhruti Desai - 12Nov2010
/// Purpose: 
/// To add, edit and view the Executive Risk Carrier record
/// 
/// Functionality:
/// Checks for the Session value for operation
/// and sets the page controls in view or edit or add mode
/// Also performs attachments adding, listing and removing
/// </summary>
public partial class PropertyLiability_ExecutiveRiskCarrier : clsBasePage
{
    #region Property

    /// <summary>
    /// sets and gets primary key
    /// </summary>
    public int PK_Executive_Risk_Carrier
    {
        get { return Convert.ToInt32(ViewState["PK_Executive_Risk_Carrier"]); }
        set { ViewState["PK_Executive_Risk_Carrier"] = value; }
    }

    /// <summary>
    /// get executive risk id
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

    /// <summary>
    /// Page Load Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        ExecutiveRiskInfo.SetSelectedTab(CtrlExecutiveRiskInfo.Tab.Executive_Risk);
        Attachment.btnHandler += new Controls_Attachments_Attachment.OnButtonClick(Upload_File);
        if (!Page.IsPostBack)
        {
            // show first panel 
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(1);", true);

            // check for the foreign key otherwise redirect to executive risk page
            if (FK_Executive_Risk > 0)
            {
                // if querystring for operation to be performed is passed(view or edit);
                if (strOperation != string.Empty)
                {
                    // set PK_Executive_Risk_Carrier
                    PK_Executive_Risk_Carrier = Convert.ToInt32(Request.QueryString["id"]);

                    if (strOperation == "view")
                    {
                        // Bind Controls
                        BindDetailsForView();
                        // set attachment details control in readonly mode.
                        AttachDetails.InitializeAttachmentDetails(clsGeneral.Tables.Executive_Risk_Carrier, PK_Executive_Risk_Carrier, false, 2);
                    }
                    else
                    {
                        if (UserAccessType == AccessType.Executive_Risk_View)
                        {
                            Response.Redirect(Request.Url.ToString().Replace("edit", "view"));
                        }
                        else
                        {
                            // bind the layer dropdown
                            BindDropDownLayer();

                            // Bind Controls
                            BindDetailsForEdit();
                            // set attachment details control in read/write mode. so user can add or remove attachment as well.                        
                            AttachDetails.InitializeAttachmentDetails(clsGeneral.Tables.Executive_Risk_Carrier, PK_Executive_Risk_Carrier, true, 2);
                        }
                    }
                    // bind attachment details to show attachment for current carrier record
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
                        Attachment.ShowAttachmentButton = false;
                        btnViewAudit.Visible = false;
                        btnAuditView.Visible = false;
                        // bind the layer dropdown
                        BindDropDownLayer();
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
    /// Handles save and view button click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSaveAndView_Click(object sender, EventArgs e)
    {
        // check for page valid
        if (Page.IsValid)
        {
            // create object
            Executive_Risk_Carrier objRiskCarrier = new Executive_Risk_Carrier();

            // set key values
            objRiskCarrier.PK_Executive_Risk_Carrier = PK_Executive_Risk_Carrier;
            objRiskCarrier.FK_Executive_Risk = FK_Executive_Risk;

            // set values from page controls
            objRiskCarrier.Carrier = txtCarrier.Text.Trim();
            objRiskCarrier.FK_Layer = drpLayer.SelectedIndex > 0 ? Convert.ToDecimal(drpLayer.SelectedValue) : -1;
            objRiskCarrier.Limit = clsGeneral.GetDecimalValue(txtLimit);
            objRiskCarrier.Contact_Name = txtContactName.Text.Trim();
            objRiskCarrier.Contact_Number = txtContactNumber.Text.Trim();
            objRiskCarrier.Claim_Number = txtClaimNumber.Text.Trim();
            objRiskCarrier.Notes = txtNotes.Text.Trim();
            objRiskCarrier.Update_Date = DateTime.Now;
            objRiskCarrier.Updated_By = clsSession.UserID;

            // insert or update the record depending on Primary key
            if (PK_Executive_Risk_Carrier > 0)
                objRiskCarrier.Update();
            else
                PK_Executive_Risk_Carrier = objRiskCarrier.Insert();

            Upload_File(string.Empty);
            //redirect page in view mode
            String strQueryString = Request.QueryString.ToString();
            if (!String.IsNullOrEmpty(strOperation) && strOperation == "edit")
                strQueryString = strQueryString.Replace("edit", "view");
            else
                strQueryString = strQueryString + "&op=view&id=" + PK_Executive_Risk_Carrier;

            Response.Redirect("ExecutiveRiskCarrier.aspx?" + strQueryString);

        }
    }

    /// <summary>
    /// Handles back button click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnBack_Click(object sender, EventArgs e)
    {
        // redirec to Executive risk page
        Response.Redirect("ExecutiveRisk.aspx?id=" + FK_Executive_Risk + "&pnl=4");
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
        Executive_Risk_Carrier objRiskCarrier = new Executive_Risk_Carrier(PK_Executive_Risk_Carrier);
        // set values in page controls
        lblCarrier.Text = objRiskCarrier.Carrier;
        if (objRiskCarrier.FK_Layer > 0)
            lblLayer.Text = new Layer(objRiskCarrier.FK_Layer).Fld_Desc;
        lblLimit.Text = clsGeneral.GetStringValue(objRiskCarrier.Limit).Replace(".00", "");
        lblContactName.Text = objRiskCarrier.Contact_Name;
        lblContactNumber.Text = objRiskCarrier.Contact_Number;
        lblClaimNumber.Text = objRiskCarrier.Claim_Number;
        lblNotes.Text = objRiskCarrier.Notes;
    }

    /// <summary>
    /// Sets the page in edit mode
    /// </summary>
    private void BindDetailsForEdit()
    {
        // create object
        Executive_Risk_Carrier objRiskCarrier = new Executive_Risk_Carrier(PK_Executive_Risk_Carrier);
        btnViewAudit.Visible = true;
        btnAuditView.Visible = false;
        // set values in page controls
        txtCarrier.Text = objRiskCarrier.Carrier;
        if (objRiskCarrier.FK_Layer > 0)
            drpLayer.SelectedValue = objRiskCarrier.FK_Layer.ToString();
        txtLimit.Text = clsGeneral.GetStringValue(objRiskCarrier.Limit).Replace(".00", "");
        txtContactName.Text = objRiskCarrier.Contact_Name;
        txtContactNumber.Text = objRiskCarrier.Contact_Number;
        txtClaimNumber.Text = objRiskCarrier.Claim_Number;
        txtNotes.Text = objRiskCarrier.Notes;
    }

    #endregion

    #region "Bind DropDowns"

    /// <summary>
    /// Binds the layer dropdown
    /// </summary>
    private void BindDropDownLayer()
    {
        DataTable dtLayer = Layer.SelectAll().Tables[0];
        drpLayer.DataSource = dtLayer;
        drpLayer.DataTextField = "Fld_Desc";
        drpLayer.DataValueField = "PK_Layer";
        drpLayer.DataBind();
        drpLayer.Items.Insert(0, "--Select Layer--");
    }

    #endregion

    #region "Attachments Management"

    /// <summary>
    /// Binds attachment details
    /// </summary>
    private void BindAttachmentDetails()
    {
        dvAttachment.Style["Display"] = "block";
        AttachDetails.Bind();
    }

    /// <summary>
    /// Upload File
    /// </summary>
    /// <param name="strValue"></param>
    void Upload_File(string strValue)
    {
        if (PK_Executive_Risk_Carrier > 0)
        {
            // add attachment if any.
            Attachment.Add(clsGeneral.Tables.Executive_Risk_Carrier, PK_Executive_Risk_Carrier);
            BindAttachmentDetails();
            // show first panel 
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

        #region "Insurance Profile - Carrier Grid"
        DataTable dtFields = clsScreen_Validators.SelectByScreen(80).Tables[0];
        dtFields.DefaultView.RowFilter = "IsRequired = '1'";
        dtFields = dtFields.DefaultView.ToTable();

        MenuAsterisk1.Style["display"] = (dtFields.Select("LeftMenuIndex = 1").Length > 0) ? "inline-block" : "none";

        foreach (DataRow drField in dtFields.Rows)
        {
            #region " set validation control IDs and messages "
            switch (Convert.ToString(drField["Field_Name"]))
            {
                case "Carrier Grid - Carrier":
                    strCtrlsIDs += txtCarrier.ClientID + ",";
                    strMessages += "Please enter [Executive Risk Carrier]/Carrier" + ",";
                    Span1.Style["display"] = "inline-block";
                    break;
                case "Carrier Grid - Layer":
                    strCtrlsIDs += drpLayer.ClientID + ",";
                    strMessages += "Please select [Executive Risk Carrier]/Layer" + ",";
                    Span2.Style["display"] = "inline-block";
                    break;
                case "Carrier Grid - Limit":
                    strCtrlsIDs += txtLimit.ClientID + ",";
                    strMessages += "Please enter [Executive Risk Carrier]/Limit" + ",";
                    Span3.Style["display"] = "inline-block";
                    break;
                case "Carrier Grid - Contact Name":
                    strCtrlsIDs += txtContactName.ClientID + ",";
                    strMessages += "Please enter [Executive Risk Carrier]/Contact Name" + ",";
                    Span4.Style["display"] = "inline-block";
                    break;
                case "Carrier Grid - Contact Number":
                    strCtrlsIDs += txtContactNumber.ClientID + ",";
                    strMessages += "Please enter [Executive Risk Carrier]/Contact Number" + ",";
                    Span5.Style["display"] = "inline-block";
                    break;
                case "Carrier Grid - Claim Number":
                    strCtrlsIDs += txtClaimNumber.ClientID + ",";
                    strMessages += "Please enter [Executive Risk Carrier]/Claim Number" + ",";
                    Span6.Style["display"] = "inline-block";
                    break;
                case "Carrier Grid - Notes":
                    strCtrlsIDs += txtNotes.ClientID + ",";
                    strMessages += "Please enter [Executive Risk Carrier]/Notes" + ",";
                    Span7.Style["display"] = "inline-block";
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
