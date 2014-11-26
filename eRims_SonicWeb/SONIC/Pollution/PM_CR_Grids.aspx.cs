using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERIMS.DAL;
using System.Data;

public partial class SONIC_Pollution_PM_CR_Grids : clsBasePage
{
    #region Properties
    /// <summary>
    /// Denotes the Primary Key
    /// </summary>
    public decimal PK_PM_CR_Grids
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_PM_CR_Grids"]);
        }
        set { ViewState["PK_PM_CR_Grids"] = value; }
    }
    /// <summary>
    /// Denotes foriegn key for Compliance Reporting
    /// </summary>
    public decimal FK_PM_Compliance_Reporting
    {
        get
        {
            return clsGeneral.GetInt(ViewState["FK_PM_Compliance_Reporting"]);
        }
        set { ViewState["FK_PM_Compliance_Reporting"] = value; }
    }

    /// <summary>
    /// Denotes foriegn key for Site Information
    /// </summary>
    public decimal FK_PM_Site_Information
    {
        get { return clsGeneral.GetInt(ViewState["FK_PM_Site_Information"]); }
        set { ViewState["FK_PM_Site_Information"] = value; }
    }

    /// <summary>
    /// Denotes foriegn key for Location record
    /// </summary>
    public decimal FK_LU_Location_ID
    {
        get { return Convert.ToDecimal(ViewState["FK_LU_Location_ID"]); }
        set { ViewState["FK_LU_Location_ID"] = value; }
    }

    /// <summary>
    /// Denotes the GridType
    /// </summary>
    public string GridType
    {
        get { return Convert.ToString(ViewState["GridType"]); }
        set { ViewState["GridType"] = value; }
    }

    /// <summary>
    /// Denotes the operation whether edit or view
    /// </summary>
    public string StrOperation
    {
        get { return Convert.ToString(ViewState["strOperation"]); }
        set { ViewState["strOperation"] = value; }
    }
    #endregion

    #region Page Events
    protected void Page_Load(object sender, EventArgs e)
    {
        Tab.SetSelectedTab(Controls_ExposuresTab_ExposuresTab.Tab.Pollution);
        Attachment.btnHandler += new Attachment_Pollution.OnButtonClick(Upload_File);
        if (!Page.IsPostBack)
        {
            // shows the first panel
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(1);", true);
            PK_PM_CR_Grids = clsGeneral.GetQueryStringID(Request.QueryString["id"]);
            FK_PM_Compliance_Reporting = clsGeneral.GetQueryStringID(Request.QueryString["cid"]);
            FK_PM_Site_Information = clsGeneral.GetQueryStringID(Request.QueryString["fid"]);
            FK_LU_Location_ID = clsGeneral.GetQueryStringID(Request.QueryString["loc"]);
            if (Request.QueryString["gtype"] != null)
            {
                GridType = Convert.ToString(Encryption.Decrypt(Request.QueryString["gtype"]));
            }
            lblPageHeader.Text = GridType;
            lblLeftMenu.Text = GridType;
            lblScreenHeader.Text = GridType;
            lblScreenHeaderView.Text = GridType;
            lblData.Text = GridType;
            lblDataName.Text = GridType;

            if (FK_LU_Location_ID > 0)
            {
                Session["ExposureLocation"] = FK_LU_Location_ID;
                ucCtrlExposureInfo.PK_LU_Location = FK_LU_Location_ID;
                ucCtrlExposureInfo.BindExposureInfo();
            }
            else
                Response.Redirect("../Exposures/ExposureSearch.aspx");
            if (PK_PM_CR_Grids > 0)
            {
                if (Request.QueryString["op"] != null)
                {
                    StrOperation = Request.QueryString["op"];
                }
                else
                    StrOperation = "edit";

                if (StrOperation == "view")
                {
                    // Bind Controls
                    BindDetailsForView();
                    dvView.Style["display"] = "inline";
                    dvEdit.Style["display"] = "none";
                    btnSave.Visible = false;
                    btnEdit.Visible = (App_Access == AccessType.Administrative_Access);
                    // set attachment details control in readonly mode.
                    AttachDetailsView.InitializeAttachmentDetails(clsGeneral.Pollution_Tables.PM_CR_Grids_Attachments, Convert.ToInt32(PK_PM_CR_Grids), "FK_PM_CR_Grids", "PK_PM_CR_Grids_Attachments", false, 2);
                }
                else
                {
                    if (App_Access == AccessType.View_Only)
                        Response.Redirect(AppConfig.SiteURL + "Error.aspx?msg=errAcc");
                    SetValidations();
                    // Bind Controls
                    BindDetailsForEdit();
                    dvView.Style["display"] = "none";
                    dvEdit.Style["display"] = "inline";
                    btnSave.Visible = true;
                    btnEdit.Visible = false;
                    // set attachment details control in read/write mode. so user can add or remove attachment as well.
                    AttachDetails.InitializeAttachmentDetails(clsGeneral.Pollution_Tables.PM_CR_Grids_Attachments, Convert.ToInt32(PK_PM_CR_Grids), "FK_PM_CR_Grids", "PK_PM_CR_Grids_Attachments", true, 2);
                }
                // bind attachment details to show attachment for current risk profile.
                BindAttachmentDetails();
            }
            else
            {
                if (App_Access == AccessType.View_Only)
                    Response.Redirect(AppConfig.SiteURL + "Error.aspx?msg=errAcc");
                SetValidations();                
                BindAttachmentDetails();
                // don't show div for view mode
                btnAuditTrail.Visible = false;
                dvView.Style["display"] = "none";
                dvEdit.Style["display"] = "inline";                
                btnEdit.Visible = false;
            }
        }
    }
    #endregion

    #region Methods
    /// <summary>
    /// Bind Page Controls for edit mode
    /// </summary>
    private void BindDetailsForEdit()
    {
        dvView.Visible = false;
        dvEdit.Visible = true;
        btnEdit.Visible = false;
        
        PM_CR_Grids objPM_CR_Grids = new PM_CR_Grids(PK_PM_CR_Grids);
        GridType = objPM_CR_Grids.Grid_Type;
        txtReport_Due_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objPM_CR_Grids.Report_Due_Date);
        txtReport_Submission_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objPM_CR_Grids.Report_Submission_Date);
        txtRejection_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objPM_CR_Grids.Rejection_Date);
        txtResubmission_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objPM_CR_Grids.Resubmission_Date);
        rdoInitial_Notification.SelectedValue = objPM_CR_Grids.Initial_Notification;
        rdoCompliance_Verification.SelectedValue = objPM_CR_Grids.Compliance_Verification;
        rdoReport_Changes.SelectedValue = objPM_CR_Grids.Report_Changes;
        txtAssociated_Fees.Text = clsGeneral.GetStringValue(objPM_CR_Grids.Associated_Fees);
        txtNotes.Text = objPM_CR_Grids.Notes;
        txtRegulatoryContact.Text = Convert.ToString(objPM_CR_Grids.Regualtory_Contact);
        txtRegulatoryContactPhone.Text = Convert.ToString(objPM_CR_Grids.Regualtory_Telephone);
        txtRegulatoryEmail.Text = Convert.ToString(objPM_CR_Grids.Regualtory_Email);
        rdoApply_To_Location.SelectedValue = objPM_CR_Grids.Apply_To_Location;

    }


    /// <summary>
    /// Binds Page Controls for view mode
    /// </summary>
    private void BindDetailsForView()
    {
        dvView.Visible = true;
        dvEdit.Visible = false;
        dvSave.Visible = true;
        btnSave.Visible = false;
        btnEdit.Visible = true;
        PM_CR_Grids objPM_CR_Grids = new PM_CR_Grids(PK_PM_CR_Grids);
        GridType = objPM_CR_Grids.Grid_Type;
        lblReport_Due_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objPM_CR_Grids.Report_Due_Date);
        lblReport_Submission_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objPM_CR_Grids.Report_Submission_Date);
        lblRejection_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objPM_CR_Grids.Rejection_Date);
        lblResubmission_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objPM_CR_Grids.Resubmission_Date);
        lblInitial_Notification.Text = objPM_CR_Grids.Initial_Notification == "N" ? "No" : objPM_CR_Grids.Initial_Notification == "R" ? "Not Required" : "Yes";
        lblCompliance_Verification.Text = objPM_CR_Grids.Compliance_Verification == "N" ? "No" : objPM_CR_Grids.Compliance_Verification == "R" ? "Not Required" : "Yes";
        lblReport_Changes.Text = objPM_CR_Grids.Report_Changes == "N" ? "No" : objPM_CR_Grids.Report_Changes == "R" ? "Not Required" : "Yes";
        lblAssociated_Fees.Text = string.Format("{0:C2}", objPM_CR_Grids.Associated_Fees);
        lblNotes.Text = objPM_CR_Grids.Notes;
        lblRegulatoryContact.Text = Convert.ToString(objPM_CR_Grids.Regualtory_Contact);
        lblRegulatoryContactPhone.Text = Convert.ToString(objPM_CR_Grids.Regualtory_Telephone);
        lblRegulatoryEmail.Text = Convert.ToString(objPM_CR_Grids.Regualtory_Email);
        lblApply_To_Location.Text = objPM_CR_Grids.Apply_To_Location == "Y" ? "Yes" : "No";
    }
    /// <summary>
    /// Performs the insert/update
    /// </summary>
    /// <param name="IsFromAdd"></param>
    private void SavePaintInventory(bool IsFromAdd)
    {
        PM_CR_Grids objPM_CR_Grids = new PM_CR_Grids();
        objPM_CR_Grids.PK_PM_CR_Grids = PK_PM_CR_Grids;
        objPM_CR_Grids.Grid_Type = GridType;
        objPM_CR_Grids.FK_PM_Compliance_Reporting = FK_PM_Compliance_Reporting;
        objPM_CR_Grids.Report_Due_Date = clsGeneral.FormatNullDateToStore(txtReport_Due_Date.Text);
        objPM_CR_Grids.Report_Submission_Date = clsGeneral.FormatNullDateToStore(txtReport_Submission_Date.Text);
        objPM_CR_Grids.Rejection_Date = clsGeneral.FormatNullDateToStore(txtRejection_Date.Text);
        objPM_CR_Grids.Resubmission_Date = clsGeneral.FormatNullDateToStore(txtResubmission_Date.Text);
        objPM_CR_Grids.Initial_Notification = rdoInitial_Notification.SelectedValue;
        objPM_CR_Grids.Compliance_Verification = rdoCompliance_Verification.SelectedValue;
        objPM_CR_Grids.Report_Changes = rdoReport_Changes.SelectedValue;
        if (txtAssociated_Fees.Text != "") objPM_CR_Grids.Associated_Fees = clsGeneral.GetDecimalValue(txtAssociated_Fees);
        objPM_CR_Grids.Notes = txtNotes.Text.Trim();
        objPM_CR_Grids.Updated_By = clsSession.UserID;
        objPM_CR_Grids.Update_Date = DateTime.Now;
        objPM_CR_Grids.Regualtory_Contact = Convert.ToString(txtRegulatoryContact.Text);
        objPM_CR_Grids.Regualtory_Telephone=Convert.ToString(txtRegulatoryContactPhone.Text);
        objPM_CR_Grids.Regualtory_Email = Convert.ToString(txtRegulatoryEmail.Text);
        objPM_CR_Grids.Apply_To_Location = rdoApply_To_Location.SelectedValue;

        decimal _retVal;
        if (PK_PM_CR_Grids > 0)
        {
            objPM_CR_Grids.Update();

            if (!IsFromAdd)
            {
                // add the attachment 
                Attachment.FK_Field_Value = Convert.ToInt32(PK_PM_CR_Grids);
                Attachment.FK_Field_Name = "FK_PM_CR_Grids";
                Attachment.Add(clsGeneral.Pollution_Tables.PM_CR_Grids_Attachments);
                Response.Redirect("PM_CR_Grids.aspx?op=view&id=" + Encryption.Encrypt(Convert.ToString(PK_PM_CR_Grids)) + "&fid=" + Encryption.Encrypt(Convert.ToString(FK_PM_Site_Information)) + "&loc=" + Encryption.Encrypt(Convert.ToString(FK_LU_Location_ID)) + "&gtype=" +  Encryption.Encrypt(GridType) + "&cid=" + Encryption.Encrypt(Convert.ToString(FK_PM_Compliance_Reporting)));
            }
        }
        else
        {
            _retVal = objPM_CR_Grids.Insert();
            PK_PM_CR_Grids = _retVal;

            if (!IsFromAdd)
            {
                // add the attachment 
                Attachment.FK_Field_Value = Convert.ToInt32(PK_PM_CR_Grids);
                Attachment.FK_Field_Name = "FK_PM_CR_Grids";
                Attachment.Add(clsGeneral.Pollution_Tables.PM_CR_Grids_Attachments);
                Response.Redirect("PM_CR_Grids.aspx?op=view&id=" + Encryption.Encrypt(Convert.ToString(PK_PM_CR_Grids)) + "&fid=" + Encryption.Encrypt(Convert.ToString(FK_PM_Site_Information)) + "&loc=" + Encryption.Encrypt(Convert.ToString(FK_LU_Location_ID)) + "&gtype=" + Encryption.Encrypt(GridType) + "&cid=" + Encryption.Encrypt(Convert.ToString(FK_PM_Compliance_Reporting)));
            }
        }
    }

    #endregion

    #region Control Events

    /// <summary>
    /// Redirects from the view to edit state
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnEdit_Click(object sender, EventArgs e)
    {
        if (PK_PM_CR_Grids > 0)
            Response.Redirect("PM_CR_Grids.aspx?op=edit&id=" + Encryption.Encrypt(Convert.ToString(PK_PM_CR_Grids)) + "&fid=" + Encryption.Encrypt(Convert.ToString(FK_PM_Site_Information)) + "&loc=" + Encryption.Encrypt(Convert.ToString(FK_LU_Location_ID)) + "&gtype=" + Encryption.Encrypt(GridType) + "&cid=" + Encryption.Encrypt(Convert.ToString(FK_PM_Compliance_Reporting)));
    }

    /// <summary>
    /// Handles Save Button click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSave_Click(object sender, EventArgs e)
    {
        SavePaintInventory(false);
    }
    /// <summary>
    /// Directs back to the parent page
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnBack_Click(object sender, EventArgs e)
    {
        if (StrOperation == "view")
            Response.Redirect("Pollution.aspx?op=view&id=" + Encryption.Encrypt(Convert.ToString(FK_PM_Site_Information)) + "&loc=" + Encryption.Encrypt(Convert.ToString(FK_LU_Location_ID)) + "&pnl=" + Encryption.Encrypt("3"));
        else
            Response.Redirect("Pollution.aspx?op=edit&id=" + Encryption.Encrypt(Convert.ToString(FK_PM_Site_Information)) + "&loc=" + Encryption.Encrypt(Convert.ToString(FK_LU_Location_ID)) + "&pnl=" + Encryption.Encrypt("3"));
    }
    #endregion

    #region Attachments Management
    /// <summary>
    /// Binds the attachment details
    /// </summary>
    private void BindAttachmentDetails()
    {
        dvAttachment.Style["display"] = "block";
        if (StrOperation == "view")
        {
            AttachDetailsView.Bind();
        }
        else
        {
            AttachDetails.Bind();
        }
    }

    /// <summary>
    /// Upload File
    /// </summary>
    /// <param name="strValue"></param>
    void Upload_File(string strValue)
    {
        if (PK_PM_CR_Grids > 0)
        {
            SavePaintInventory(true);
            // add the attachment 
            Attachment.FK_Field_Value = Convert.ToInt32(PK_PM_CR_Grids);
            Attachment.FK_Field_Name = "FK_PM_CR_Grids";
            Attachment.Add(clsGeneral.Pollution_Tables.PM_CR_Grids_Attachments);

            // bind the details to view added attachment
            BindAttachmentDetails();

            // show the attachment panel as the page is loaded again
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(2);", true);
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:alert('Please save " + GridType + " details first');ShowPanel(2);", true);
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
        int intScreenID = 0;
        if (GridType == "Tier II")
            intScreenID = 174;
        else if (GridType == "Air Permit")
            intScreenID = 175;
        else if (GridType == "6H")
            intScreenID = 176;

        DataTable dtFields = clsScreen_Validators.SelectByScreen(intScreenID).Tables[0];
        dtFields.DefaultView.RowFilter = "IsRequired = '1'";
        dtFields = dtFields.DefaultView.ToTable();

        MenuAsterisk1.Style["display"] = (dtFields.Rows.Count > 0) ? "inline-block" : "none";

        foreach (DataRow drField in dtFields.Rows)
        {
            #region " set validation control IDs and messages "
            switch (Convert.ToString(drField["Field_Name"]))
            {
                case "Report Due Date": strCtrlsIDs += txtReport_Due_Date.ClientID + ","; strMessages += "Please enter [" + GridType + "]/Report Due Date" + ","; Span1.Style["display"] = "inline-block"; break;
                case "Report Submission Date": strCtrlsIDs += txtReport_Submission_Date.ClientID + ","; strMessages += "Please enter [" + GridType + "]/Report Submission Date" + ","; Span2.Style["display"] = "inline-block"; break;
                case "Rejection Date": strCtrlsIDs += txtRejection_Date.ClientID + ","; strMessages += "Please enter [" + GridType + "]/Rejection Date" + ","; Span3.Style["display"] = "inline-block"; break;
                case "Resubmission Date": strCtrlsIDs += txtResubmission_Date.ClientID + ","; strMessages += "Please enter [" + GridType + "]/Resubmission Date" + ","; Span4.Style["display"] = "inline-block"; break;
                case "Initial Notification Submitted": strCtrlsIDs += rdoInitial_Notification.ClientID + ","; strMessages += "Please select [" + GridType + "]/Initial Notification Submitted" + ","; Span5.Style["display"] = "inline-block"; break;
                case "Compliance Verification Submitted": strCtrlsIDs += rdoCompliance_Verification.ClientID + ","; strMessages += "Please select [" + GridType + "]/Compliance Verification Submitted" + ","; Span6.Style["display"] = "inline-block"; break;
                case "Notification of Report Changes Submitted": strCtrlsIDs += rdoReport_Changes.ClientID + ","; strMessages += "Please select [" + GridType + "]/Notification of Report Changes Submitted" + ","; Span7.Style["display"] = "inline-block"; break;
                case "Associated Fees": strCtrlsIDs += txtAssociated_Fees.ClientID + ","; strMessages += "Please enter [" + GridType + "]/Associated Fees" + ","; Span8.Style["display"] = "inline-block"; break;
                case "Notes": strCtrlsIDs += txtNotes.ClientID + ","; strMessages += "Please enter [" + GridType + "]/Notes" + ","; Span9.Style["display"] = "inline-block"; break;
                case "Regulatory Contact": strCtrlsIDs += txtRegulatoryContact.ClientID + ","; strMessages += "Please enter [" + GridType + "]/Regulatory Contact" + ","; Span10.Style["display"] = "inline-block"; break;
                case "Regulatory Contact Telephone": strCtrlsIDs += txtRegulatoryContactPhone.ClientID + ","; strMessages += "Please enter [" + GridType + "]/Regulatory Contact Telephone" + ","; Span11.Style["display"] = "inline-block"; break;
                case "Regulatory E-Mail Address": strCtrlsIDs += txtRegulatoryEmail.ClientID + ","; strMessages += "Please enter [" + GridType + "]/Regulatory E-Mail Address" + ","; Span12.Style["display"] = "inline-block"; break;
            }
            #endregion
        }

        strCtrlsIDs = strCtrlsIDs.TrimEnd(',');
        strMessages = strMessages.TrimEnd(',');

        hdnControlIDs.Value = strCtrlsIDs;
        hdnErrorMsgs.Value = strMessages;
    }
    #endregion

}