using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ERIMS.DAL;

public partial class SONIC_Pollution_Audit_Inspections_Frequency : clsBasePage
{
    #region Properties
    /// <summary>
    /// Denotes the Primary Key
    /// </summary>
    public decimal PK_PM_Frequency
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_PM_Frequency"]);
        }
        set { ViewState["PK_PM_Frequency"] = value; }
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
            PK_PM_Frequency = clsGeneral.GetQueryStringID(Request.QueryString["id"]);
            FK_PM_Compliance_Reporting = clsGeneral.GetQueryStringID(Request.QueryString["cid"]);
            FK_PM_Site_Information = clsGeneral.GetQueryStringID(Request.QueryString["fid"]);
            FK_LU_Location_ID = clsGeneral.GetQueryStringID(Request.QueryString["loc"]);

            if (FK_LU_Location_ID > 0)
            {
                Session["ExposureLocation"] = FK_LU_Location_ID;
                ucCtrlExposureInfo.PK_LU_Location = FK_LU_Location_ID;
                ucCtrlExposureInfo.BindExposureInfo();
            }
            else
                Response.Redirect("../Exposures/ExposureSearch.aspx");
            if (PK_PM_Frequency > 0)
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
                    AttachDetailsView.InitializeAttachmentDetails(clsGeneral.Pollution_Tables.PM_Frequency_Attachments, Convert.ToInt32(PK_PM_Frequency), "FK_PM_Frequency", "PK_PM_Frequency_Attachments", false, 2);
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
                    AttachDetails.InitializeAttachmentDetails(clsGeneral.Pollution_Tables.PM_Frequency_Attachments, Convert.ToInt32(PK_PM_Frequency), "FK_PM_Frequency", "PK_PM_Frequency_Attachments", true, 2);
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
                dvView.Style["display"] = "none";
                dvEdit.Style["display"] = "inline";
                btnEdit.Visible = false;
                btnAuditTrail.Visible = false;
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
        PM_Frequency objPM_Frequency = new PM_Frequency(PK_PM_Frequency);
        txtLast_Inspection_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objPM_Frequency.Last_Inspection_Date);
        txtNext_Inspection_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objPM_Frequency.Next_Inspection_Date);
        txtCost.Text = clsGeneral.GetStringValue(objPM_Frequency.Cost);
        txtNext_Report_Due.Text = objPM_Frequency.Next_Report_Due;
        txtNext_Report_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objPM_Frequency.Next_Report_Date);
        txtNotes.Text = objPM_Frequency.Notes;
        txtRecommendations.Text = objPM_Frequency.Recommendations;
        FK_PM_Site_Information = Convert.ToDecimal(objPM_Frequency.FK_PM_Site_Information);
        rdoApply_To_Location.SelectedValue = objPM_Frequency.Apply_To_Location;
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
        PM_Frequency objPM_Frequency = new PM_Frequency(PK_PM_Frequency);
        lblLast_Inspection_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objPM_Frequency.Last_Inspection_Date);
        lblNext_Inspection_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objPM_Frequency.Next_Inspection_Date);
        lblCost.Text = string.Format("{0:C2}", objPM_Frequency.Cost);
        lblNext_Report_Due.Text = objPM_Frequency.Next_Report_Due;
        lblNext_Report_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objPM_Frequency.Next_Report_Date);
        lblNotes.Text = objPM_Frequency.Notes;
        lblRecommendations.Text = objPM_Frequency.Recommendations;
        FK_PM_Site_Information = Convert.ToDecimal(new PM_Site_Information((decimal)objPM_Frequency.FK_PM_Site_Information, false).PK_PM_Site_Information);
        if (objPM_Frequency.Apply_To_Location != null) lblApply_To_Location.Text = objPM_Frequency.Apply_To_Location == "Y" ? "Yes" : "No"; 
    }
    /// <summary>
    /// Performs inesrt/update
    /// </summary>
    /// <param name="IsFromAdd"></param>
    private void SavePaintInventory(bool IsFromAdd)
    {
        PM_Frequency objPM_Frequency = new PM_Frequency();
        objPM_Frequency.PK_PM_Frequency = PK_PM_Frequency;
        objPM_Frequency.Last_Inspection_Date = clsGeneral.FormatNullDateToStore(txtLast_Inspection_Date.Text);
        objPM_Frequency.Next_Inspection_Date = clsGeneral.FormatNullDateToStore(txtNext_Inspection_Date.Text);
        if (txtCost.Text != "") objPM_Frequency.Cost = clsGeneral.GetDecimalValue(txtCost);
        objPM_Frequency.Next_Report_Due = txtNext_Report_Due.Text.Trim();
        objPM_Frequency.Next_Report_Date = clsGeneral.FormatNullDateToStore(txtNext_Report_Date.Text);
        objPM_Frequency.Notes = txtNotes.Text.Trim();
        objPM_Frequency.Recommendations = txtRecommendations.Text.Trim();
        objPM_Frequency.FK_PM_Site_Information = FK_PM_Site_Information;
        objPM_Frequency.Updated_By = clsSession.UserID;
        objPM_Frequency.Update_Date = DateTime.Now;
        objPM_Frequency.Apply_To_Location = rdoApply_To_Location.SelectedValue;
        decimal _retVal;
        if (PK_PM_Frequency > 0)
        {
            _retVal = 0;
            objPM_Frequency.Update();
            // add the attachment 
            Attachment.FK_Field_Value = Convert.ToInt32(PK_PM_Frequency);
            Attachment.FK_Field_Name = "FK_PM_Frequency";
            Attachment.Add(clsGeneral.Pollution_Tables.PM_Frequency_Attachments);
            Response.Redirect("Audit_Inspections_Frequency.aspx?op=view&id=" + Encryption.Encrypt(Convert.ToString(PK_PM_Frequency)) + "&fid=" + Encryption.Encrypt(Convert.ToString(FK_PM_Site_Information)) + "&loc=" + Encryption.Encrypt(Convert.ToString(FK_LU_Location_ID)));
        }
        else
        {
            _retVal = objPM_Frequency.Insert();
            PK_PM_Frequency = _retVal;
            // add the attachment 
            Attachment.FK_Field_Value = Convert.ToInt32(PK_PM_Frequency);
            Attachment.FK_Field_Name = "FK_PM_Frequency";
            Attachment.Add(clsGeneral.Pollution_Tables.PM_Frequency_Attachments);
            if (!IsFromAdd)
                Response.Redirect("Audit_Inspections_Frequency.aspx?op=view&id=" + Encryption.Encrypt(Convert.ToString(PK_PM_Frequency)) + "&fid=" + Encryption.Encrypt(Convert.ToString(FK_PM_Site_Information)) + "&loc=" + Encryption.Encrypt(Convert.ToString(FK_LU_Location_ID)));
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
        if (PK_PM_Frequency > 0)
            Response.Redirect("Audit_Inspections_Frequency.aspx?op=edit&id=" + Encryption.Encrypt(Convert.ToString(PK_PM_Frequency)) + "&fid=" + Encryption.Encrypt(Convert.ToString(FK_PM_Site_Information)) + "&loc=" + Encryption.Encrypt(Convert.ToString(FK_LU_Location_ID)));
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
            Response.Redirect("Pollution.aspx?op=view&id=" + Encryption.Encrypt(Convert.ToString(FK_PM_Site_Information)) + "&loc=" + Encryption.Encrypt(Convert.ToString(FK_LU_Location_ID)) + "&pnl=" + Encryption.Encrypt("6"));
        else
            Response.Redirect("Pollution.aspx?op=edit&id=" + Encryption.Encrypt(Convert.ToString(FK_PM_Site_Information)) + "&loc=" + Encryption.Encrypt(Convert.ToString(FK_LU_Location_ID)) + "&pnl=" + Encryption.Encrypt("6"));
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
        if (PK_PM_Frequency > 0)
        {
            // add the attachment 
            Attachment.FK_Field_Value = Convert.ToInt32(PK_PM_Frequency);
            Attachment.FK_Field_Name = "FK_PM_Frequency";
            Attachment.Add(clsGeneral.Pollution_Tables.PM_Frequency_Attachments);

            // bind the details to view added attachment
            BindAttachmentDetails();

            // show the attachment panel as the page is loaded again
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(2);", true);
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:alert('Please save Audit/Inspection - Frequency details first');ShowPanel(2);", true);
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

        #region " Site Information "

        DataTable dtFields = clsScreen_Validators.SelectByScreen(168).Tables[0];
        dtFields.DefaultView.RowFilter = "IsRequired = '1'";
        dtFields = dtFields.DefaultView.ToTable();

        MenuAsterisk1.Style["display"] = (dtFields.Rows.Count > 0) ? "inline-block" : "none";

        foreach (DataRow drField in dtFields.Rows)
        {
            #region " set validation control IDs and messages "
            switch (Convert.ToString(drField["Field_Name"]))
            {
                case "Last Inspection Date":
                    strCtrlsIDs += txtLast_Inspection_Date.ClientID + ",";
                    strMessages += "Please enter [Inspection]/Last Inspection Date" + ",";
                    Span1.Style["display"] = "inline-block";
                    break;
                case "Next Inspection Date":
                    strCtrlsIDs += txtNext_Inspection_Date.ClientID + ",";
                    strMessages += "Please enter [Inspection]/Next Inspection Date" + ",";
                    Span2.Style["display"] = "inline-block";
                    break;
                case "Cost":
                    strCtrlsIDs += txtCost.ClientID + ",";
                    strMessages += "Please enter [Inspection]/Cost" + ",";
                    Span3.Style["display"] = "inline-block";
                    break;
                case "Next Report Due":
                    strCtrlsIDs += txtNext_Report_Due.ClientID + ",";
                    strMessages += "Please enter [Inspection]/Next Report Due" + ",";
                    Span4.Style["display"] = "inline-block";
                    break;
                case "Next Report Date":
                    strCtrlsIDs += txtNext_Report_Date.ClientID + ",";
                    strMessages += "Please enter [Inspection]/Next Report Date" + ",";
                    Span5.Style["display"] = "inline-block";
                    break;
                case "Notes":
                    strCtrlsIDs += txtNotes.ClientID + ",";
                    strMessages += "Please enter [Inspection]/Notes" + ",";
                    Span6.Style["display"] = "inline-block";
                    break;
                case "Recommendations":
                    strCtrlsIDs += txtRecommendations.ClientID + ",";
                    strMessages += "Please enter [Inspection]/Recommendations" + ",";
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