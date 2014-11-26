using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERIMS.DAL;
using System.Data;

public partial class SONIC_Pollution_PM_EPA_Inspection : clsBasePage
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
    public decimal PK_PM_EPA_Inspection
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_PM_EPA_Inspection"]);
        }
        set { ViewState["PK_PM_EPA_Inspection"] = value; }
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
            PK_PM_EPA_Inspection = clsGeneral.GetQueryStringID(Request.QueryString["id"]);
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
            if (PK_PM_EPA_Inspection > 0)
            {
                StrOperation = Convert.ToString(Request.QueryString["op"]);
                //PK_Executive_Risk_Contacts = Convert.ToInt32(Request.QueryString["id"]);
                if (StrOperation == "view")
                {
                    // Bind Controls
                    BindDetailsForView();
                    btnEdit.Visible = (App_Access == AccessType.Administrative_Access);
                    // set attachment details control in readonly mode.
                    AttachDetailsView.InitializeAttachmentDetails(clsGeneral.Pollution_Tables.PM_EPA_Inspection_Attachments, Convert.ToInt32(PK_PM_EPA_Inspection), "FK_PM_EPA_Inspection", "PK_PM_EPA_Inspection_Attachments", false, 2);
                }
                else
                {
                    if (App_Access == AccessType.View_Only)
                        Response.Redirect(AppConfig.SiteURL + "Error.aspx?msg=errAcc");
                    SetValidations();
                    BindDropDowns();
                    // Bind Controls
                    BindDetailsForEdit();
                    // set attachment details control in read/write mode. so user can add or remove attachment as well.
                    AttachDetails.InitializeAttachmentDetails(clsGeneral.Pollution_Tables.PM_EPA_Inspection_Attachments, Convert.ToInt32(PK_PM_EPA_Inspection), "FK_PM_EPA_Inspection", "PK_PM_EPA_Inspection_Attachments", true, 2);
                }
                // bind attachment details to show attachment for current risk profile.
                BindAttachmentDetails();
            }
            else
            {
                if (App_Access == AccessType.View_Only)
                    Response.Redirect(AppConfig.SiteURL + "Error.aspx?msg=errAcc");

                // disable Add Attachment button                
                btnEdit.Visible = false;
                SetValidations();
                BindDropDowns();
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

    private void BindDropDowns()
    {
        ComboHelper.FillEPAAssesor(new DropDownList[] { drpEPAAssesor }, true);
    }

    /// <summary>
    /// Bind Page Controls for edit mode
    /// </summary>
    private void BindDetailsForEdit()
    {
        dvView.Visible = false;
        dvEdit.Visible = true;
        btnEdit.Visible = false;
        
        PM_EPA_Inspection objPM_EPA_Inspection = new PM_EPA_Inspection(PK_PM_EPA_Inspection);
        clsGeneral.SetDropdownValue(drpEPAAssesor, objPM_EPA_Inspection.FK_LU_EPA_Assessor, true);
        //txtAssessor.Text = objPM_EPA_Inspection.Assessor;
        txtInspection_Type.Text = objPM_EPA_Inspection.Inspection_Type;
        txtContact_Name.Text = objPM_EPA_Inspection.Contact_Name;
        txtContact_Telephone.Text = objPM_EPA_Inspection.Contact_Telephone;
        txtReport_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objPM_EPA_Inspection.Report_Date);
        txtCost.Text = clsGeneral.GetStringValue(objPM_EPA_Inspection.Cost);
        txtNext_Review_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objPM_EPA_Inspection.Next_Review_Date);
        txtNext_Report_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objPM_EPA_Inspection.Next_Report_Date);
        txtRecommendations.Text = objPM_EPA_Inspection.Recommendations;
        if (objPM_EPA_Inspection.FK_PM_Site_Information != null) FK_PM_Site_Information = Convert.ToDecimal(objPM_EPA_Inspection.FK_PM_Site_Information);
        if (FK_PM_Site_Information > 0)
            btnBack.Visible = true;
        else
            btnBack.Visible = false;
        if (objPM_EPA_Inspection.Apply_To_Location != null) rdoApply_To_Location.SelectedValue = objPM_EPA_Inspection.Apply_To_Location;
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
        PM_EPA_Inspection objPM_EPA_Inspection = new PM_EPA_Inspection(PK_PM_EPA_Inspection);
        if (objPM_EPA_Inspection.FK_LU_EPA_Assessor != null)
        {
            LU_EPA_Assessor objLU_EPA_Assessor = new LU_EPA_Assessor(Convert.ToDecimal(objPM_EPA_Inspection.FK_LU_EPA_Assessor));
            lblAssessor.Text = objLU_EPA_Assessor.Fld_Desc;
        }
        lblInspection_Type.Text = objPM_EPA_Inspection.Inspection_Type;
        lblContact_Name.Text = objPM_EPA_Inspection.Contact_Name;
        lblContact_Telephone.Text = objPM_EPA_Inspection.Contact_Telephone;
        lblReport_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objPM_EPA_Inspection.Report_Date);
        lblCost.Text = string.Format("{0:C2}", objPM_EPA_Inspection.Cost);
        lblNext_Review_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objPM_EPA_Inspection.Next_Review_Date);
        lblNext_Report_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objPM_EPA_Inspection.Next_Report_Date);
        lblRecommendations.Text = objPM_EPA_Inspection.Recommendations;
        if (objPM_EPA_Inspection.FK_PM_Site_Information != null) FK_PM_Site_Information = Convert.ToDecimal(objPM_EPA_Inspection.FK_PM_Site_Information);
        if (FK_PM_Site_Information > 0)
            btnBack.Visible = true;
        else
            btnBack.Visible = false;
        if (objPM_EPA_Inspection.Apply_To_Location != null) lblApply_To_Location.Text = objPM_EPA_Inspection.Apply_To_Location == "Y" ? "Yes" : "No";
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
        PM_EPA_Inspection objPM_EPA_Inspection = new PM_EPA_Inspection();
        objPM_EPA_Inspection.PK_PM_EPA_Inspection = PK_PM_EPA_Inspection;
        if (drpEPAAssesor.SelectedIndex > 0)
            objPM_EPA_Inspection.FK_LU_EPA_Assessor = Convert.ToDecimal(drpEPAAssesor.SelectedValue);
        objPM_EPA_Inspection.Inspection_Type = txtInspection_Type.Text.Trim();
        objPM_EPA_Inspection.Contact_Name = txtContact_Name.Text.Trim();
        objPM_EPA_Inspection.Contact_Telephone = txtContact_Telephone.Text.Trim();
        objPM_EPA_Inspection.Report_Date = clsGeneral.FormatNullDateToStore(txtReport_Date.Text);
        if (txtCost.Text != "") objPM_EPA_Inspection.Cost = clsGeneral.GetDecimalValue(txtCost);
        objPM_EPA_Inspection.Next_Review_Date = clsGeneral.FormatNullDateToStore(txtNext_Review_Date.Text);
        objPM_EPA_Inspection.Next_Report_Date = clsGeneral.FormatNullDateToStore(txtNext_Report_Date.Text);
        objPM_EPA_Inspection.Recommendations = txtRecommendations.Text.Trim();
        objPM_EPA_Inspection.FK_PM_Site_Information = FK_PM_Site_Information;
        objPM_EPA_Inspection.Update_Date = DateTime.Now;
        objPM_EPA_Inspection.Updated_By = clsSession.UserID;
        objPM_EPA_Inspection.Apply_To_Location = rdoApply_To_Location.SelectedValue;

        decimal _retVal;
        if (PK_PM_EPA_Inspection > 0)
            _retVal = objPM_EPA_Inspection.Update();
        else
            _retVal = objPM_EPA_Inspection.Insert();

        if (_retVal == -2)
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:alert('The EPA Inspections that you are trying to add already exists.');ShowPanel(1);", true);
            return;
        }
        // add the attachment 
        Attachment.FK_Field_Value = Convert.ToInt32(PK_PM_EPA_Inspection);
        Attachment.FK_Field_Name = "FK_PM_EPA_Inspection";
        Attachment.Add(clsGeneral.Pollution_Tables.PM_EPA_Inspection_Attachments);
        Response.Redirect("PM_EPA_Inspection.aspx?id=" + Encryption.Encrypt(_retVal.ToString()) + "&fid=" + Encryption.Encrypt(FK_PM_Site_Information.ToString()) + "&loc=" + Request.QueryString["loc"] + "&op=view");
    }
    /// <summary>
    /// Handles Edit button click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnEdit_Click(object sender, EventArgs e)
    {
        Response.Redirect("PM_EPA_Inspection.aspx?id=" + Encryption.Encrypt(PK_PM_EPA_Inspection.ToString()) + "&fid=" + Encryption.Encrypt(FK_PM_Site_Information.ToString()) + "&loc=" + Request.QueryString["loc"] + "&op=edit");
    }
    /// <summary>
    /// Handles Back button click Event
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
        if (PK_PM_EPA_Inspection > 0)
        {
            // add the attachment 
            Attachment.FK_Field_Value = Convert.ToInt32(PK_PM_EPA_Inspection);
            Attachment.FK_Field_Name = "FK_PM_EPA_Inspection";
            Attachment.Add(clsGeneral.Pollution_Tables.PM_EPA_Inspection_Attachments);

            // bind the details to view added attachment
            BindAttachmentDetails();

            // show the attachment panel as the page is loaded again
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(2);", true);
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:alert('Please save EPA Inspections details first');ShowPanel(2);", true);
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

        DataTable dtFields = clsScreen_Validators.SelectByScreen(170).Tables[0];
        dtFields.DefaultView.RowFilter = "IsRequired = '1'";
        dtFields = dtFields.DefaultView.ToTable();

        MenuAsterisk1.Style["display"] = (dtFields.Rows.Count > 0) ? "inline-block" : "none";

        foreach (DataRow drField in dtFields.Rows)
        {
            #region " set validation control IDs and messages "
            switch (Convert.ToString(drField["Field_Name"]))
            {
                case "Inspection Agency":
                    strCtrlsIDs += drpEPAAssesor.ClientID + ",";
                    strMessages += "Please enter [Regulatory Inspections]/Inspection Agency" + ",";
                    Span1.Style["display"] = "inline-block";
                    break;
                case "Inspection Type":
                    strCtrlsIDs += txtInspection_Type.ClientID + ",";
                    strMessages += "Please enter [Regulatory Inspections]/Inspection Type" + ",";
                    Span2.Style["display"] = "inline-block";
                    break;
                case "Contact Name":
                    strCtrlsIDs += txtContact_Name.ClientID + ",";
                    strMessages += "Please enter [Regulatory Inspections]/Contact Name" + ",";
                    Span3.Style["display"] = "inline-block";
                    break;
                case "Contact Telephone":
                    strCtrlsIDs += txtContact_Telephone.ClientID + ",";
                    strMessages += "Please enter [Regulatory Inspections]/Contact Telephone" + ",";
                    Span4.Style["display"] = "inline-block";
                    break;
                case "Report Date":
                    strCtrlsIDs += txtReport_Date.ClientID + ",";
                    strMessages += "Please enter [Regulatory Inspections]/Report Date" + ",";
                    Span5.Style["display"] = "inline-block";
                    break;
                case "Cost":
                    strCtrlsIDs += txtCost.ClientID + ",";
                    strMessages += "Please enter [Regulatory Inspections]/Cost" + ",";
                    Span6.Style["display"] = "inline-block";
                    break;
                case "Next Review Date":
                    strCtrlsIDs += txtNext_Review_Date.ClientID + ",";
                    strMessages += "Please enter [Regulatory Inspections]/Next Review Date" + ",";
                    Span7.Style["display"] = "inline-block";
                    break;
                case "Next Report Date":
                    strCtrlsIDs += txtNext_Report_Date.ClientID + ",";
                    strMessages += "Please enter [Regulatory Inspections]/Next Report Date" + ",";
                    Span8.Style["display"] = "inline-block";
                    break;
                case "Recommendations":
                    strCtrlsIDs += txtRecommendations.ClientID + ",";
                    strMessages += "Please enter [Regulatory Inspections]/Recommendations" + ",";
                    Span9.Style["display"] = "inline-block";
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