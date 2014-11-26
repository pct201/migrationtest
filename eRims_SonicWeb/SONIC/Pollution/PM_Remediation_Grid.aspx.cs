using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERIMS.DAL;
using System.Data;

public partial class SONIC_Pollution_PM_Remediation_Grid : clsBasePage
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
    /// Denotes foriegn key for Remediation
    /// </summary>
    public decimal FK_PM_Remediation
    {
        get
        {
            return clsGeneral.GetInt(ViewState["FK_PM_Remediation"]);
        }
        set { ViewState["FK_PM_Remediation"] = value; }
    }
    /// <summary>
    /// Denotes the Primary Key
    /// </summary>
    public decimal PK_PM_Remediation_Grid
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_PM_Remediation_Grid"]);
        }
        set { ViewState["PK_PM_Remediation_Grid"] = value; }
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
            PK_PM_Remediation_Grid = clsGeneral.GetQueryStringID(Request.QueryString["id"]);
            FK_PM_Remediation = clsGeneral.GetQueryStringID(Request.QueryString["rid"]);
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
            if (PK_PM_Remediation_Grid > 0)
            {
                StrOperation = Convert.ToString(Request.QueryString["op"]);
                //PK_Executive_Risk_Contacts = Convert.ToInt32(Request.QueryString["id"]);
                if (StrOperation == "view")
                {
                    // Bind Controls
                    BindDetailsForView();
                    btnEdit.Visible = (App_Access == AccessType.Administrative_Access);
                    // set attachment details control in readonly mode.
                    AttachDetailsView.InitializeAttachmentDetails(clsGeneral.Pollution_Tables.PM_Remediation_Grid_Attachments, Convert.ToInt32(PK_PM_Remediation_Grid), "FK_PM_Remediation_Grid", "PK_PM_Remediation_Grid_Attachments", false, 2);
                }
                else
                {
                    if (App_Access == AccessType.View_Only)
                        Response.Redirect(AppConfig.SiteURL + "Error.aspx?msg=errAcc");
                    // Bind Controls
                    BindDropdowns();
                    SetValidations();
                    BindDetailsForEdit();
                    // set attachment details control in read/write mode. so user can add or remove attachment as well.
                    AttachDetails.InitializeAttachmentDetails(clsGeneral.Pollution_Tables.PM_Remediation_Grid_Attachments, Convert.ToInt32(PK_PM_Remediation_Grid), "FK_PM_Remediation_Grid", "PK_PM_Remediation_Grid_Attachments", true, 2);
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
                BindDropdowns();
                SetValidations();
                BindAttachmentDetails();
                btnAuditTrail.Visible = false;
                // don't show div for view mode
                dvView.Style["display"] = "none";
                if (FK_PM_Remediation > 0)
                    btnBack.Visible = true;
                else
                    btnBack.Visible = false;
            }
        }
    }
    #endregion

    #region Methods

    private void BindDropdowns()
    {
        ComboHelper.FillRemediationType(new DropDownList[] { drpFK_LU_PM_Remediation_Type }, true);
        ComboHelper.FillResultOf(new DropDownList[] { drpResult_Of }, true);
        ComboHelper.FillViolation(new DropDownList[] { drpFK_PM_Violation }, true, FK_PM_Site_Information);
    }

    /// <summary>
    /// Bind Page Controls for edit mode
    /// </summary>
    private void BindDetailsForEdit()
    {
        dvView.Visible = false;
        dvEdit.Visible = true;
        btnEdit.Visible = false;
        PM_Remediation_Grid objPM_Remediation_Grid = new PM_Remediation_Grid(PK_PM_Remediation_Grid);
        clsGeneral.SetDropdownValue(drpFK_LU_PM_Remediation_Type, objPM_Remediation_Grid.FK_LU_PM_Remediation_Type, true);
        clsGeneral.SetDropdownValue(drpFK_PM_Violation, objPM_Remediation_Grid.FK_PM_Violation, true);
        txtDescription.Text = objPM_Remediation_Grid.Description;
        txtAssessor.Text = objPM_Remediation_Grid.Assessor;
        txtContact_Name.Text = objPM_Remediation_Grid.Contact_Name;
        txtContact_Telephone.Text = objPM_Remediation_Grid.Contact_Telephone;
        txtReport_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objPM_Remediation_Grid.Report_Date);
        txtCost.Text = clsGeneral.GetStringValue(objPM_Remediation_Grid.Cost);
        txtNext_Review_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objPM_Remediation_Grid.Next_Review_Date);
        txtNext_Report_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objPM_Remediation_Grid.Next_Report_Date);
        txtRecommendations.Text = objPM_Remediation_Grid.Recommendations;
        clsGeneral.SetDropdownValue(drpResult_Of, objPM_Remediation_Grid.FK_LU_Result_Of, true);
        txtDescribe.Text = objPM_Remediation_Grid.Describe;
        //txtResult_Of.Text = objPM_Remediation_Grid.Result_Of;
        if ((objPM_Remediation_Grid.Analytical_Tests != null) && (!string.IsNullOrEmpty(objPM_Remediation_Grid.Analytical_Tests)))
            rdAnalytical_Tests.SelectedValue = objPM_Remediation_Grid.Analytical_Tests;
        txtAnalytical_Desciption.Text = objPM_Remediation_Grid.Analytical_Desciption;
        if ((objPM_Remediation_Grid.Letter_Obtained != null) && (!string.IsNullOrEmpty(objPM_Remediation_Grid.Letter_Obtained)))
            rdLetter_Obtained.SelectedValue = objPM_Remediation_Grid.Letter_Obtained;
        txtPost_Remediation_Other.Text = objPM_Remediation_Grid.Post_Remediation_Other;
        if (objPM_Remediation_Grid.FK_PM_Remediation != null) FK_PM_Remediation = Convert.ToDecimal(objPM_Remediation_Grid.FK_PM_Remediation);
        if (objPM_Remediation_Grid.Apply_To_Location != null) rdoApply_To_Location.SelectedValue = objPM_Remediation_Grid.Apply_To_Location;
        if (FK_PM_Remediation > 0)
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
        PM_Remediation_Grid objPM_Remediation_Grid = new PM_Remediation_Grid(PK_PM_Remediation_Grid);
        if ((!string.IsNullOrEmpty(Convert.ToString(objPM_Remediation_Grid.FK_LU_PM_Remediation_Type))) || (objPM_Remediation_Grid.FK_LU_PM_Remediation_Type != 0))
        {
            LU_PM_Remediation_Type objLU_PM_Remediation_Type = new LU_PM_Remediation_Type(Convert.ToDecimal(objPM_Remediation_Grid.FK_LU_PM_Remediation_Type));
            lblFK_LU_PM_Remediation_Type.Text = objLU_PM_Remediation_Type.Fld_Desc;
        }
        if ((!string.IsNullOrEmpty(Convert.ToString(objPM_Remediation_Grid.FK_PM_Violation))) || (objPM_Remediation_Grid.FK_PM_Violation != 0))
        {
            PM_Violation objPM_Violation = new PM_Violation(Convert.ToDecimal(objPM_Remediation_Grid.FK_PM_Violation));
            string strAgency ="";
            if(objPM_Violation.FK_LU_Regulatory_Notifying_Agency!=null)
                strAgency = new LU_Regulatory_Notifying_Agency(Convert.ToDecimal(objPM_Violation.FK_LU_Regulatory_Notifying_Agency)).Fld_Desc;
            lblFK_PM_Violation.Text = clsGeneral.FormatDBNullDateToDisplay(objPM_Violation.Date_Of_Violation) + " " + strAgency;
            if (lblFK_PM_Violation.Text.Length > 50)
                lblFK_PM_Violation.Text = lblFK_PM_Violation.Text.Substring(0,50);
        }
        lblDescription.Text = objPM_Remediation_Grid.Description;
        lblAssessor.Text = objPM_Remediation_Grid.Assessor;
        lblContact_Name.Text = objPM_Remediation_Grid.Contact_Name;
        lblContact_Telephone.Text = objPM_Remediation_Grid.Contact_Telephone;
        lblReport_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objPM_Remediation_Grid.Report_Date);
        lblCost.Text = string.Format("{0:C2}", objPM_Remediation_Grid.Cost);
        lblNext_Review_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objPM_Remediation_Grid.Next_Review_Date);
        lblNext_Report_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objPM_Remediation_Grid.Next_Report_Date);
        lblRecommendations.Text = objPM_Remediation_Grid.Recommendations;
        if (objPM_Remediation_Grid.FK_LU_Result_Of != null)
        {
            LU_Result_Of objLU_Result_Of = new LU_Result_Of(Convert.ToDecimal(objPM_Remediation_Grid.FK_LU_Result_Of));
            lblResult_Of.Text = objLU_Result_Of.Fld_Desc;
        }
        lblDescribe.Text = objPM_Remediation_Grid.Describe;
        if (objPM_Remediation_Grid.Analytical_Tests == "Y")
            lblAnalytical_Tests.Text = "Yes";
        else
            lblAnalytical_Tests.Text = "No";
        lblAnalytical_Desciption.Text = objPM_Remediation_Grid.Analytical_Desciption;
        if (objPM_Remediation_Grid.Letter_Obtained == "Y")
            lblLetter_Obtained.Text = "Yes";
        else
            lblLetter_Obtained.Text = "No";
        lblPost_Remediation_Other.Text = objPM_Remediation_Grid.Post_Remediation_Other;
        if (objPM_Remediation_Grid.FK_PM_Remediation != null) FK_PM_Remediation = Convert.ToDecimal(objPM_Remediation_Grid.FK_PM_Remediation);
        if (FK_PM_Remediation > 0)
            btnBack.Visible = true;
        else
            btnBack.Visible = false;
        lblApply_To_Location.Text = objPM_Remediation_Grid.Apply_To_Location == "Y" ? "Yes" : "No";
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
        PM_Remediation_Grid objPM_Remediation_Grid = new PM_Remediation_Grid();
        if (drpFK_LU_PM_Remediation_Type.SelectedIndex > 0)
            objPM_Remediation_Grid.FK_LU_PM_Remediation_Type = Convert.ToDecimal(drpFK_LU_PM_Remediation_Type.SelectedValue);
        objPM_Remediation_Grid.PK_PM_Remediation_Grid = PK_PM_Remediation_Grid;
        objPM_Remediation_Grid.Description = txtDescription.Text.Trim();
        objPM_Remediation_Grid.Assessor = txtAssessor.Text.Trim();
        objPM_Remediation_Grid.Contact_Name = txtContact_Name.Text.Trim();
        objPM_Remediation_Grid.Contact_Telephone = txtContact_Telephone.Text.Trim();
        objPM_Remediation_Grid.Report_Date = clsGeneral.FormatNullDateToStore(txtReport_Date.Text);
        if (txtCost.Text != "") objPM_Remediation_Grid.Cost = clsGeneral.GetDecimalValue(txtCost);
        objPM_Remediation_Grid.Next_Review_Date = clsGeneral.FormatNullDateToStore(txtNext_Review_Date.Text);
        objPM_Remediation_Grid.Next_Report_Date = clsGeneral.FormatNullDateToStore(txtNext_Report_Date.Text);
        objPM_Remediation_Grid.Recommendations = txtRecommendations.Text.Trim();
        objPM_Remediation_Grid.FK_PM_Remediation = FK_PM_Remediation;
        if (drpFK_PM_Violation.SelectedIndex > 0)
            objPM_Remediation_Grid.FK_PM_Violation = Convert.ToDecimal(drpFK_PM_Violation.SelectedValue);
        if (drpResult_Of.SelectedIndex > 0)
            objPM_Remediation_Grid.FK_LU_Result_Of = Convert.ToDecimal(drpResult_Of.SelectedValue);
        objPM_Remediation_Grid.Describe = txtDescribe.Text.Trim();
        if (rdAnalytical_Tests.SelectedValue != null)
            objPM_Remediation_Grid.Analytical_Tests = rdAnalytical_Tests.SelectedValue;
        objPM_Remediation_Grid.Analytical_Desciption = txtAnalytical_Desciption.Text.Trim();
        if (rdLetter_Obtained.SelectedValue != null)
            objPM_Remediation_Grid.Letter_Obtained = rdLetter_Obtained.SelectedValue;
        objPM_Remediation_Grid.Post_Remediation_Other = txtPost_Remediation_Other.Text.Trim();
        objPM_Remediation_Grid.Update_Date = DateTime.Now;
        objPM_Remediation_Grid.Updated_By = clsSession.UserID;
        objPM_Remediation_Grid.Apply_To_Location = rdoApply_To_Location.SelectedValue;

        decimal _retVal;
        if (PK_PM_Remediation_Grid > 0)
            _retVal = objPM_Remediation_Grid.Update();
        else
            _retVal = objPM_Remediation_Grid.Insert();

        if (_retVal == -2)
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:alert('The Remediation that you are trying to add already exists.');ShowPanel(1);", true);
            return;
        }
        // add the attachment 
        Attachment.FK_Field_Value = Convert.ToInt32(_retVal.ToString());
        Attachment.FK_Field_Name = "FK_PM_Remediation_Grid";
        Attachment.Add(clsGeneral.Pollution_Tables.PM_Remediation_Grid_Attachments);
        Response.Redirect("PM_Remediation_Grid.aspx?id=" + Encryption.Encrypt(_retVal.ToString()) + "&fid=" + Encryption.Encrypt(FK_PM_Site_Information.ToString()) + "&rid=" + Encryption.Encrypt(FK_PM_Remediation.ToString()) + "&loc=" + Request.QueryString["loc"] + "&op=view");
    }
    /// <summary>
    /// Handles Edit button click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnEdit_Click(object sender, EventArgs e)
    {
        Response.Redirect("PM_Remediation_Grid.aspx?id=" + Encryption.Encrypt(PK_PM_Remediation_Grid.ToString()) + "&fid=" + Encryption.Encrypt(FK_PM_Site_Information.ToString()) + "&rid=" + Encryption.Encrypt(FK_PM_Remediation.ToString()) + "&loc=" + Request.QueryString["loc"] + "&op=edit");
    }
    /// <summary>
    /// Handles Back button click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnBack_Click(object sender, EventArgs e)
    {
        if (StrOperation == "view")
            Response.Redirect("Pollution.aspx?op=view&id=" + Encryption.Encrypt(Convert.ToString(FK_PM_Site_Information)) + "&loc=" + Encryption.Encrypt(Convert.ToString(FK_LU_Location_ID)) + "&pnl=" + Encryption.Encrypt("8"));
        else
            Response.Redirect("Pollution.aspx?op=edit&id=" + Encryption.Encrypt(Convert.ToString(FK_PM_Site_Information)) + "&loc=" + Encryption.Encrypt(Convert.ToString(FK_LU_Location_ID)) + "&pnl=" + Encryption.Encrypt("8"));
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
        if (PK_PM_Remediation_Grid > 0)
        {
            // add the attachment 
            Attachment.FK_Field_Value = Convert.ToInt32(PK_PM_Remediation_Grid);
            Attachment.FK_Field_Name = "FK_PM_Remediation_Grid";
            Attachment.Add(clsGeneral.Pollution_Tables.PM_Remediation_Grid_Attachments);

            // bind the details to view added attachment
            BindAttachmentDetails();

            // show the attachment panel as the page is loaded again
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(2);", true);
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:alert('Please save Remediation details first.');ShowPanel(2);", true);
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

        DataTable dtFields = clsScreen_Validators.SelectByScreen(171).Tables[0];
        dtFields.DefaultView.RowFilter = "IsRequired = '1'";
        dtFields = dtFields.DefaultView.ToTable();

        MenuAsterisk1.Style["display"] = (dtFields.Rows.Count > 0) ? "inline-block" : "none";

        foreach (DataRow drField in dtFields.Rows)
        {
            #region " set validation control IDs and messages "
            switch (Convert.ToString(drField["Field_Name"]))
            {
                case "Remediation Type":
                    strCtrlsIDs += drpFK_LU_PM_Remediation_Type.ClientID + ",";
                    strMessages += "Please select [Remediations Grid]/Remediation Type" + ",";
                    Span1.Style["display"] = "inline-block";
                    break;
                case "Link to Violation":
                    strCtrlsIDs += drpFK_PM_Violation.ClientID + ",";
                    strMessages += "Please select [Remediations Grid]/Link to Violation" + ",";
                    Span16.Style["display"] = "inline-block";
                    break;
                case "Remediation Description":
                    strCtrlsIDs += txtDescription.ClientID + ",";
                    strMessages += "Please enter [Remediations Grid]/Remediation Description" + ",";
                    Span2.Style["display"] = "inline-block";
                    break;
                case "Assessor":
                    strCtrlsIDs += txtAssessor.ClientID + ",";
                    strMessages += "Please enter [Remediations Grid]/Assessor" + ",";
                    Span3.Style["display"] = "inline-block";
                    break;
                case "Contact Name":
                    strCtrlsIDs += txtContact_Name.ClientID + ",";
                    strMessages += "Please enter [Remediations Grid]/Contact Name" + ",";
                    Span4.Style["display"] = "inline-block";
                    break;
                case "Contact Telephone":
                    strCtrlsIDs += txtContact_Telephone.ClientID + ",";
                    strMessages += "Please enter [Remediations Grid]/Contact Telephone" + ",";
                    Span5.Style["display"] = "inline-block";
                    break;
                case "What Prompted Remediation?":
                    strCtrlsIDs += drpResult_Of.ClientID + ",";
                    strMessages += "Please select [Remediations Grid]/What Prompted Remediation?" + ",";
                    Span6.Style["display"] = "inline-block";
                    break;
                case "Describe":
                    strCtrlsIDs += txtDescribe.ClientID + ",";
                    strMessages += "Please enter [Remediations Grid]/Describe" + ",";
                    Span7.Style["display"] = "inline-block";
                    break;
                case "Describe - Analytical Tests":
                    strCtrlsIDs += txtAnalytical_Desciption.ClientID + ",";
                    strMessages += "Please enter [Remediations Grid]/Describe - Analytical Tests" + ",";
                    Span8.Style["display"] = "inline-block";
                    break;
                case "Post Remediation, Other – Describe":
                    strCtrlsIDs += txtPost_Remediation_Other.ClientID + ",";
                    strMessages += "Please enter [Remediations Grid]/Post Remediation; Other – Describe" + ",";
                    Span9.Style["display"] = "inline-block";
                    break;
                case "Report Date":
                    strCtrlsIDs += txtReport_Date.ClientID + ",";
                    strMessages += "Please enter [Remediations Grid]/Report Date" + ",";
                    Span10.Style["display"] = "inline-block";
                    break;
                case "Cost":
                    strCtrlsIDs += txtCost.ClientID + ",";
                    strMessages += "Please enter [Remediations Grid]/Cost" + ",";
                    Span11.Style["display"] = "inline-block";
                    break;
                case "Next Review Date":
                    strCtrlsIDs += txtNext_Review_Date.ClientID + ",";
                    strMessages += "Please enter [Remediations Grid]/Next Review Date" + ",";
                    Span12.Style["display"] = "inline-block";
                    break;
                case "Next Report Date":
                    strCtrlsIDs += txtNext_Report_Date.ClientID + ",";
                    strMessages += "Please enter [Remediations Grid]/Next Report Date" + ",";
                    Span13.Style["display"] = "inline-block";
                    break;
                case "Phase II Recommendations":
                    strCtrlsIDs += txtRecommendations.ClientID + ",";
                    strMessages += "Please enter [Remediations Grid]/Phase II Recommendations";
                    Span14.Style["display"] = "inline-block";
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