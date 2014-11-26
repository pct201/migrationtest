using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERIMS.DAL;
using System.Data;

public partial class SONIC_Pollution_PM_Permits : clsBasePage
{
    #region Properties
    /// <summary>
    /// Denotes foriegn key for site information
    /// </summary>
    public decimal FK_PM_Site_Information
    {
        get
        {
            return clsGeneral.GetInt(ViewState["FK_PM_Site_Information"]);
        }
        set { ViewState["FK_PM_Site_Information"] = value; }
    }
    /// <summary>
    /// Denotes the Primary Key
    /// </summary>
    public decimal PK_PM_Permits
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_PM_Permits"]);
        }
        set { ViewState["PK_PM_Permits"] = value; }
    }
    /// <summary>
    /// Denotes the operation whether edit or view
    /// </summary>
    public string StrOperation
    {
        get { return Convert.ToString(ViewState["strOperation"]); }
        set { ViewState["strOperation"] = value; }
    }
    /// <summary>
    /// Denotes foriegn key for Location record
    /// </summary>
    public decimal FK_LU_Location_ID
    {
        get { return Convert.ToDecimal(ViewState["FK_LU_Location_ID"]); }
        set { ViewState["FK_LU_Location_ID"] = value; }
    }
    #endregion

    #region Page Events
    /// <summary>
    /// Handles Page Load event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        Tab.SetSelectedTab(Controls_ExposuresTab_ExposuresTab.Tab.Pollution);
        Attachment.btnHandler += new Attachment_Pollution.OnButtonClick(Upload_File);
        if (!Page.IsPostBack)
        {
            PK_PM_Permits = clsGeneral.GetQueryStringID(Request.QueryString["id"]);
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
            // shows the first panel
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(1);", true);
            if (PK_PM_Permits > 0)
            {
                StrOperation = Convert.ToString(Request.QueryString["op"]);
                //PK_Executive_Risk_Contacts = Convert.ToInt32(Request.QueryString["id"]);
                if (StrOperation == "view")
                {
                    // Bind Controls
                    BindDropdowns();
                    BindDetailsForView();
                    btnEdit.Visible = (App_Access == AccessType.Administrative_Access);
                    // set attachment details control in readonly mode.
                    AttachDetailsView.InitializeAttachmentDetails(clsGeneral.Pollution_Tables.PM_Permits_Attachments, Convert.ToInt32(PK_PM_Permits), "FK_PM_Permits", "PK_PM_Permits_Attachments", false, 2);
                }
                else
                {
                    if (App_Access == AccessType.View_Only)
                        Response.Redirect(AppConfig.SiteURL + "Error.aspx?msg=errAcc");
                    SetValidations();
                    // Bind Controls
                    BindDropdowns();
                    BindDetailsForEdit();
                    // set attachment details control in read/write mode. so user can add or remove attachment as well.
                    AttachDetails.InitializeAttachmentDetails(clsGeneral.Pollution_Tables.PM_Permits_Attachments, Convert.ToInt32(PK_PM_Permits), "FK_PM_Permits", "PK_PM_Permits_Attachments", true, 2);
                }
                // bind attachment details to show attachment for current risk profile.
                BindAttachmentDetails();
            }
            else
            {
                if (App_Access == AccessType.View_Only)
                    Response.Redirect(AppConfig.SiteURL + "Error.aspx?msg=errAcc");
                SetValidations();
                // disable Add Attachment button                
                btnEdit.Visible = false;
                BindDropdowns();
                BindAttachmentDetails();
                // don't show div for view mode
                dvView.Style["display"] = "none";
                btnAuditTrail.Visible = false;
                if (FK_PM_Site_Information > 0)
                    btnBack.Visible = true;
                else
                    btnBack.Visible = false;
            }
        }
    }
    #endregion

    #region Methods
    /// <summary>
    /// Binds all dropdowns
    /// </summary>
    private void BindDropdowns()
    {
        ComboHelper.FillPermitType(new DropDownList[] { drpFK_Permit_Type }, true);
    }
    /// <summary>
    /// Bind Page Controls for edit mode
    /// </summary>
    private void BindDetailsForEdit()
    {
        dvView.Visible = false;
        dvEdit.Visible = true;
        btnEdit.Visible = false;
        PM_Permits objPM_Permits = new PM_Permits(PK_PM_Permits);
        if (objPM_Permits.FK_Permit_Type != null)
        {
            ListItem lst = drpFK_Permit_Type.Items.FindByValue(objPM_Permits.FK_Permit_Type.ToString());
            if (lst != null)
                lst.Selected = true;
            //drpFK_Permit_Type.SelectedValue = objPM_Permits.FK_Permit_Type.ToString();
        }
        rdoPermit_Required.SelectedValue = objPM_Permits.Permit_Required;
        txtCertification_Number.Text = objPM_Permits.Certification_Number;
        txtApplication_Regulation_Number.Text = objPM_Permits.Application_Regulation_Number;
        txtPermit_Start_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objPM_Permits.Permit_Start_Date);
        txtPermit_End_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objPM_Permits.Permit_End_Date);
        txtLast_Inspection_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objPM_Permits.Last_Inspection_Date);
        txtNext_Inspection_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objPM_Permits.Next_Inspection_Date);
        txtNext_Report_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objPM_Permits.Next_Report_Date);
        txtNotes.Text = objPM_Permits.Notes;
        txtRecommendations.Text = objPM_Permits.Recommendations;
        if (objPM_Permits.FK_PM_Site_Information != null) FK_PM_Site_Information = Convert.ToDecimal(objPM_Permits.FK_PM_Site_Information);
        rdoApply_To_Location.SelectedValue = objPM_Permits.Application_Regulation_Number;
        if (FK_PM_Site_Information > 0)
            btnBack.Visible = true;
        else
            btnBack.Visible = false;
    }
    /// <summary>
    /// Binds Page Controls for view mode
    /// </summary>
    private void BindDetailsForView()
    {
        dvView.Visible = true;
        dvEdit.Visible = false;
        btnEdit.Visible = true;
        btnSave.Visible = false;
        PM_Permits objPM_Permits = new PM_Permits(PK_PM_Permits);
        if (objPM_Permits.FK_Permit_Type != null)
            lblFK_Permit_Type.Text = new clsLU_Permit_Type((decimal)objPM_Permits.FK_Permit_Type).Fld_Desc;
        lblPermit_Required.Text = objPM_Permits.Permit_Required == "Y" ? "Yes" : "No";
        lblCertification_Number.Text = objPM_Permits.Certification_Number;
        lblApplication_Regulation_Number.Text = objPM_Permits.Application_Regulation_Number;
        lblPermit_Start_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objPM_Permits.Permit_Start_Date);
        lblPermit_End_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objPM_Permits.Permit_End_Date);
        lblLast_Inspection_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objPM_Permits.Last_Inspection_Date);
        lblNext_Inspection_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objPM_Permits.Next_Inspection_Date);
        lblNext_Report_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objPM_Permits.Next_Report_Date);
        lblNotes.Text = objPM_Permits.Notes;
        lblRecommendations.Text = objPM_Permits.Recommendations;
        if (objPM_Permits.FK_PM_Site_Information != null) FK_PM_Site_Information = Convert.ToDecimal(objPM_Permits.FK_PM_Site_Information);
        if (FK_PM_Site_Information > 0)
            btnBack.Visible = true;
        else
            btnBack.Visible = false;
        lblApply_To_Location.Text = objPM_Permits.Apply_To_Location == "Y" ? "Yes" : "No";
    }
    #endregion

    #region Control Events
    /// <summary>
    /// Handles Save Button click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSave_Click(object sender, EventArgs e)
    {
        PM_Permits objPM_Permits = new PM_Permits();
        objPM_Permits.PK_PM_Permits = PK_PM_Permits;
        if (drpFK_Permit_Type.SelectedIndex > 0) objPM_Permits.FK_Permit_Type = Convert.ToDecimal(drpFK_Permit_Type.SelectedValue);
        objPM_Permits.Permit_Required = rdoPermit_Required.SelectedValue;
        objPM_Permits.Certification_Number = txtCertification_Number.Text.Trim();
        objPM_Permits.Application_Regulation_Number = txtApplication_Regulation_Number.Text.Trim();
        objPM_Permits.Permit_Start_Date = clsGeneral.FormatNullDateToStore(txtPermit_Start_Date.Text);
        objPM_Permits.Permit_End_Date = clsGeneral.FormatNullDateToStore(txtPermit_End_Date.Text);
        objPM_Permits.Last_Inspection_Date = clsGeneral.FormatNullDateToStore(txtLast_Inspection_Date.Text);
        objPM_Permits.Next_Inspection_Date = clsGeneral.FormatNullDateToStore(txtNext_Inspection_Date.Text);
        objPM_Permits.Next_Report_Date = clsGeneral.FormatNullDateToStore(txtNext_Report_Date.Text);
        objPM_Permits.Notes = txtNotes.Text.Trim();
        objPM_Permits.Recommendations = txtRecommendations.Text.Trim();
        objPM_Permits.FK_PM_Site_Information = FK_PM_Site_Information;
        objPM_Permits.Update_Date = DateTime.Now;
        objPM_Permits.Updated_By = clsSession.UserID;
        objPM_Permits.Apply_To_Location = rdoApply_To_Location.SelectedValue;

        decimal _retVal;
        if (PK_PM_Permits > 0)
            _retVal = objPM_Permits.Update();
        else
            _retVal = objPM_Permits.Insert();

        if (_retVal == -2)
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:alert('The Permits that you are trying to add already exists.');ShowPanel(1);", true);
            return;
        }
        // add the attachment 
        Attachment.FK_Field_Value = Convert.ToInt32(_retVal.ToString());
        Attachment.FK_Field_Name = "FK_PM_Permits";
        Attachment.Add(clsGeneral.Pollution_Tables.PM_Permits_Attachments);
        Response.Redirect("PM_Permits.aspx?id=" + Encryption.Encrypt(_retVal.ToString()) + "&op=view" + "&loc=" + Encryption.Encrypt(Convert.ToString(FK_LU_Location_ID)) + "&fid=" + Encryption.Encrypt(Convert.ToString(FK_PM_Site_Information)));
    }

    /// <summary>
    /// Handles Edit button click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnEdit_Click(object sender, EventArgs e)
    {
        Response.Redirect("PM_Permits.aspx?id=" + Encryption.Encrypt(PK_PM_Permits.ToString()) + "&op=edit" + "&loc=" + Encryption.Encrypt(Convert.ToString(FK_LU_Location_ID)) + "&fid=" + Encryption.Encrypt(Convert.ToString(FK_PM_Site_Information)));
    }
    /// <summary>
    /// Handles Back button click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnBack_Click(object sender, EventArgs e)
    {
        if (StrOperation == "view")
            Response.Redirect("Pollution.aspx?op=view&id=" + Encryption.Encrypt(Convert.ToString(FK_PM_Site_Information)) + "&loc=" + Encryption.Encrypt(Convert.ToString(FK_LU_Location_ID)) + "&pnl=" + Encryption.Encrypt("2"));
        else
            Response.Redirect("Pollution.aspx?op=edit&id=" + Encryption.Encrypt(Convert.ToString(FK_PM_Site_Information)) + "&loc=" + Encryption.Encrypt(Convert.ToString(FK_LU_Location_ID)) + "&pnl=" + Encryption.Encrypt("2"));
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
        if (PK_PM_Permits > 0)
        {
            // add the attachment 
            Attachment.FK_Field_Value = Convert.ToInt32(PK_PM_Permits);
            Attachment.FK_Field_Name = "FK_PM_Permits";
            Attachment.Add(clsGeneral.Pollution_Tables.PM_Permits_Attachments);

            // bind the details to view added attachment
            BindAttachmentDetails();

            // show the attachment panel as the page is loaded again
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(2);", true);
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:alert('Please save Permit details first');ShowPanel(2);", true);
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


        DataTable dtFields = clsScreen_Validators.SelectByScreen(156).Tables[0];
        dtFields.DefaultView.RowFilter = "IsRequired = '1'";
        dtFields = dtFields.DefaultView.ToTable();

        MenuAsterisk1.Style["display"] = (dtFields.Rows.Count > 0) ? "inline-block" : "none";

        foreach (DataRow drField in dtFields.Rows)
        {
            #region " set validation control IDs and messages "
            switch (Convert.ToString(drField["Field_Name"]))
            {
                case "Permit Type": strCtrlsIDs += drpFK_Permit_Type.ClientID + ","; strMessages += "Please select [Permits]/Permit Type" + ","; Span1.Style["display"] = "inline-block"; break;
                case "Certification Number": strCtrlsIDs += txtCertification_Number.ClientID + ","; strMessages += "Please enter [Permits]/Certification Number" + ","; Span2.Style["display"] = "inline-block"; break;
                case "Application Regulation Number": strCtrlsIDs += txtApplication_Regulation_Number.ClientID + ","; strMessages += "Please enter [Permits]/Application Regulation Number" + ","; Span3.Style["display"] = "inline-block"; break;
                case "Permit Start Date": strCtrlsIDs += txtPermit_Start_Date.ClientID + ","; strMessages += "Please enter [Permits]/Permit Start Date" + ","; Span4.Style["display"] = "inline-block"; break;
                case "Permit End Date": strCtrlsIDs += txtPermit_End_Date.ClientID + ","; strMessages += "Please enter [Permits]/Permit End Date" + ","; Span5.Style["display"] = "inline-block"; break;
                case "Last Inspection Date": strCtrlsIDs += txtLast_Inspection_Date.ClientID + ","; strMessages += "Please enter [Permits]/Last Inspection Date" + ","; Span6.Style["display"] = "inline-block"; break;
                case "Next Inspection Date": strCtrlsIDs += txtNext_Inspection_Date.ClientID + ","; strMessages += "Please enter [Permits]/Next Inspection Date" + ","; Span7.Style["display"] = "inline-block"; break;
                case "Next Report Date": strCtrlsIDs += txtNext_Report_Date.ClientID + ","; strMessages += "Please enter [Permits]/Next Report Date" + ","; Span8.Style["display"] = "inline-block"; break;
                case "Notes": strCtrlsIDs += txtNotes.ClientID + ","; strMessages += "Please enter [Permits]/Notes" + ","; Span9.Style["display"] = "inline-block"; break;
                case "Recommendations": strCtrlsIDs += txtRecommendations.ClientID + ","; strMessages += "Please enter [Permits]/Recommendations" + ","; Span10.Style["display"] = "inline-block"; break;
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