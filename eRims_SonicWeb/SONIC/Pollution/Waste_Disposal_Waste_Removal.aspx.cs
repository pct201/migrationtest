using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ERIMS.DAL;

public partial class SONIC_Pollution_Waste_Disposal_Waste_Removal : clsBasePage
{
    #region Properties
    /// <summary>
    /// Denotes the Primary Key
    /// </summary>
    public decimal PK_PM_Waste_Removal
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_PM_Waste_Removal"]);
        }
        set { ViewState["PK_PM_Waste_Removal"] = value; }
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
        drpFK_LU_Waste_Type.Attributes.Add("onChange", "return SetDischargeView();");
        Attachment.btnHandler += new Attachment_Pollution.OnButtonClick(Upload_File);
        if (!Page.IsPostBack)
        {
            // shows the first panel
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(1);", true);
            PK_PM_Waste_Removal = clsGeneral.GetQueryStringID(Request.QueryString["id"]);
            //FK_PM_Compliance_Reporting = clsGeneral.GetQueryStringID(Request.QueryString["cid"]);
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

            if (PK_PM_Waste_Removal > 0)
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
                    AttachDetailsView.InitializeAttachmentDetails(clsGeneral.Pollution_Tables.PM_Waste_Removal_Attachments, Convert.ToInt32(PK_PM_Waste_Removal), "FK_PM_Waste_Removal", "PK_PM_Waste_Removal_Attachments", false, 2);
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
                    AttachDetails.InitializeAttachmentDetails(clsGeneral.Pollution_Tables.PM_Waste_Removal_Attachments, Convert.ToInt32(PK_PM_Waste_Removal), "FK_PM_Waste_Removal", "PK_PM_Waste_Removal_Attachments", true, 2);
                }
                // bind attachment details to show attachment for current risk profile.
                BindAttachmentDetails();
            }
            else
            {
                if (App_Access == AccessType.View_Only)
                    Response.Redirect(AppConfig.SiteURL + "Error.aspx?msg=errAcc");

                BindDropdown();
                // disable Add Attachment button
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

    private void BindDropdown()
    {
        ComboHelper.FillWastetype(new DropDownList[] { drpFK_LU_Waste_Type }, true);

        DataSet dsWaste_Hauler = PM_Waste_Hauler.SelectByFK_SiteInfo(FK_PM_Site_Information);
        drpFK_PM_Waste_Hauler.DataSource = dsWaste_Hauler.Tables[0];
        drpFK_PM_Waste_Hauler.DataTextField = "Waste_Hauler_Name";
        drpFK_PM_Waste_Hauler.DataValueField = "PK_PM_Waste_Hauler";
        drpFK_PM_Waste_Hauler.DataBind();
        drpFK_PM_Waste_Hauler.Items.Insert(0, new ListItem("-- Select --", "0"));

        DataSet dsReceivingTSDF = PM_Receiving_TSDF.SelectByFK_SiteInfo(FK_PM_Site_Information);
        drpFK_Receiving_TSDF.DataSource = dsReceivingTSDF.Tables[0];
        drpFK_Receiving_TSDF.DataTextField = "Receiving_TSDF_Name";
        drpFK_Receiving_TSDF.DataValueField = "PK_PM_Receiving_TSDF";
        drpFK_Receiving_TSDF.DataBind();
        drpFK_Receiving_TSDF.Items.Insert(0, new ListItem("-- Select --", "0"));

        ComboHelper.FillFacilityGeneratorStatus(new DropDownList[] { drpFK_LU_Facility_Generator_Status }, true);

        DataSet dsHWCodes = LU_PM_Hazardous_Waste_Codes.SelectAll();
        dsHWCodes.Tables[0].DefaultView.RowFilter = "Active='Y'";

        drpHWCodes.DataSource = dsHWCodes.Tables[0].DefaultView;
        drpHWCodes.DataTextField = "Fld_Code";
        drpHWCodes.DataValueField = "PK_LU_PM_Hazardous_Waste_Codes";
        drpHWCodes.DataBind();
        drpHWCodes.Items.Insert(0, new ListItem("-- Select --", "0"));
    }

    /// <summary>
    /// Bind Page Controls for edit mode
    /// </summary>
    private void BindDetailsForEdit()
    {
        dvView.Visible = false;
        dvEdit.Visible = true;
        btnEdit.Visible = false;
        BindDropdown();
        PM_Waste_Removal objPM_Waste_Removal = new PM_Waste_Removal(PK_PM_Waste_Removal);
        if (objPM_Waste_Removal.FK_LU_Waste_Type != null) drpFK_LU_Waste_Type.SelectedValue = objPM_Waste_Removal.FK_LU_Waste_Type.ToString();
        if (drpFK_LU_Waste_Type.SelectedItem != null)
        {
            if ((drpFK_LU_Waste_Type.SelectedItem.Text == "Antifreeze"))
                pnlDischarge.Style["display"] = "inline";
            else
                pnlDischarge.Style["display"] = "none";
        }
        else
            pnlDischarge.Style["display"] = "none";
        if (objPM_Waste_Removal.FK_PM_Waste_Hauler != null) drpFK_PM_Waste_Hauler.SelectedValue = objPM_Waste_Removal.FK_PM_Waste_Hauler.ToString();
        if (objPM_Waste_Removal.FK_Receiving_TSDF != null) drpFK_Receiving_TSDF.SelectedValue = objPM_Waste_Removal.FK_Receiving_TSDF.ToString();
        txtAmount_HW_Generated_Per_Month.Text = clsGeneral.GetStringValue(objPM_Waste_Removal.Amount_HW_Generated_Per_Month);
        //txtUnits.Text = objPM_Waste_Removal.Units;
        txtDate.Text = clsGeneral.FormatDBNullDateToDisplay(objPM_Waste_Removal.Date);
        drpHWCodes.SelectedValue = Convert.ToString(objPM_Waste_Removal.FK_LU_PM_Hazardous_Waste_Codes);
        txtHWStartDate.Text = clsGeneral.FormatDBNullDateToDisplay(objPM_Waste_Removal.HW_Accumulation_Start);
        txtHWlastDate.Text = clsGeneral.FormatDBNullDateToDisplay(objPM_Waste_Removal.Last_HW_Removal);
        if (objPM_Waste_Removal.HW_Profile_Complete_And_Maintained != null)
            rdoHW_Profile_Complete_And_Maintained.SelectedValue = objPM_Waste_Removal.HW_Profile_Complete_And_Maintained;
        if (objPM_Waste_Removal.FK_LU_Facility_Generator_Status != null) drpFK_LU_Facility_Generator_Status.SelectedValue = objPM_Waste_Removal.FK_LU_Facility_Generator_Status.ToString();
        txtDischarge_Limits.Text = objPM_Waste_Removal.Discharge_Limits;
        txtCalifornia_Business_Plan.Text = objPM_Waste_Removal.California_Business_Plan;
        if (objPM_Waste_Removal.FK_PM_Site_Information != null) FK_PM_Site_Information = Convert.ToDecimal(objPM_Waste_Removal.FK_PM_Site_Information);
        if (objPM_Waste_Removal.Amount_HW_Generated_Per_Month != null) rdoApply_To_Location.SelectedValue = objPM_Waste_Removal.Apply_To_Location;

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
        PM_Waste_Removal objPM_Waste_Removal = new PM_Waste_Removal(PK_PM_Waste_Removal);
        if (objPM_Waste_Removal.FK_LU_Waste_Type != null)
            lblFK_LU_Waste_Type.Text = new LU_Waste_Type((decimal)objPM_Waste_Removal.FK_LU_Waste_Type).Fld_Desc;
        if (lblFK_LU_Waste_Type.Text == "Antifreeze")
            dvDischargeView.Style["display"] = "inline";
        else
            dvDischargeView.Style["display"] = "none";
        if (objPM_Waste_Removal.FK_PM_Waste_Hauler != null)
            lblFK_PM_Waste_Hauler.Text = new PM_Waste_Hauler((decimal)objPM_Waste_Removal.FK_PM_Waste_Hauler).Waste_Hauler_Name;
        if (objPM_Waste_Removal.FK_Receiving_TSDF != null)
            lblFK_Receiving_TSDF.Text = new PM_Receiving_TSDF((decimal)objPM_Waste_Removal.FK_Receiving_TSDF).Receiving_TSDF_Name;
        lblAmount_HW_Generated_Per_Month.Text = string.Format("{0:N2}", objPM_Waste_Removal.Amount_HW_Generated_Per_Month);
        //lblUnits.Text = objPM_Waste_Removal.Units;
        lblDate.Text = clsGeneral.FormatDBNullDateToDisplay(objPM_Waste_Removal.Date);
        //lblConstituents_Of_Concern.Text = objPM_Waste_Removal.Constituents_Of_Concern;
        //lblRemoval_Limits.Text = objPM_Waste_Removal.Removal_Limits;
        if (objPM_Waste_Removal.FK_LU_PM_Hazardous_Waste_Codes != null)
            lblHWCodes.Text = Convert.ToString(new LU_PM_Hazardous_Waste_Codes(Convert.ToDecimal(objPM_Waste_Removal.FK_LU_PM_Hazardous_Waste_Codes)).Fld_Code);
          lblHWStartDate.Text = clsGeneral.FormatDBNullDateToDisplay(objPM_Waste_Removal.HW_Accumulation_Start);
          lblHWLastDate.Text = clsGeneral.FormatDBNullDateToDisplay(objPM_Waste_Removal.Last_HW_Removal);
        if (objPM_Waste_Removal.HW_Profile_Complete_And_Maintained != null)
            lblHW_Profile_Complete_And_Maintained.Text = objPM_Waste_Removal.HW_Profile_Complete_And_Maintained == "Y" ? "Yes" : "No";
        if (objPM_Waste_Removal.FK_LU_Facility_Generator_Status != null)
            lblFK_LU_Facility_Generator_Status.Text = new LU_Facility_Generator_Status((decimal)objPM_Waste_Removal.FK_LU_Facility_Generator_Status).Fld_Desc;
        lblDischarge_Limits.Text = objPM_Waste_Removal.Discharge_Limits;
        lblCalifornia_Business_Plan.Text = objPM_Waste_Removal.California_Business_Plan;
        if (objPM_Waste_Removal.FK_PM_Site_Information != null)
            FK_PM_Site_Information = Convert.ToDecimal(new PM_Site_Information((decimal)objPM_Waste_Removal.FK_PM_Site_Information, false).PK_PM_Site_Information);
        if (objPM_Waste_Removal.Apply_To_Location != null) lblApply_To_Location.Text = objPM_Waste_Removal.Apply_To_Location == "Y" ? "Yes" : "No"; ;
    }

    private void SavePaintInventory(bool IsFromAdd)
    {
        PM_Waste_Removal objPM_Waste_Removal = new PM_Waste_Removal();
        objPM_Waste_Removal.PK_PM_Waste_Removal = PK_PM_Waste_Removal;
        if (drpFK_LU_Waste_Type.SelectedIndex > 0) objPM_Waste_Removal.FK_LU_Waste_Type = Convert.ToDecimal(drpFK_LU_Waste_Type.SelectedValue);
        if (drpFK_PM_Waste_Hauler.SelectedIndex > 0) objPM_Waste_Removal.FK_PM_Waste_Hauler = Convert.ToDecimal(drpFK_PM_Waste_Hauler.SelectedValue);
        if (drpFK_Receiving_TSDF.SelectedIndex > 0) objPM_Waste_Removal.FK_Receiving_TSDF = Convert.ToDecimal(drpFK_Receiving_TSDF.SelectedValue);
        if (txtAmount_HW_Generated_Per_Month.Text != "") objPM_Waste_Removal.Amount_HW_Generated_Per_Month = clsGeneral.GetDecimalValue(txtAmount_HW_Generated_Per_Month);
        objPM_Waste_Removal.Units = "";//txtUnits.Text.Trim();
        objPM_Waste_Removal.Date = clsGeneral.FormatNullDateToStore(txtDate.Text);
        //objPM_Waste_Removal.Constituents_Of_Concern = txtConstituents_Of_Concern.Text.Trim();
        //objPM_Waste_Removal.Removal_Limits = txtRemoval_Limits.Text.Trim();
        objPM_Waste_Removal.FK_LU_PM_Hazardous_Waste_Codes = Convert.ToDecimal(drpHWCodes.SelectedValue);
        objPM_Waste_Removal.HW_Accumulation_Start = clsGeneral.FormatNullDateToStore(txtHWStartDate.Text);
        objPM_Waste_Removal.Last_HW_Removal = clsGeneral.FormatNullDateToStore(txtHWlastDate.Text);

        objPM_Waste_Removal.HW_Profile_Complete_And_Maintained = rdoHW_Profile_Complete_And_Maintained.SelectedValue;
        if (drpFK_LU_Facility_Generator_Status.SelectedIndex > 0) objPM_Waste_Removal.FK_LU_Facility_Generator_Status = Convert.ToDecimal(drpFK_LU_Facility_Generator_Status.SelectedValue);
        if ((drpFK_LU_Waste_Type.SelectedItem.Text == "Antifreeze"))
        {
            objPM_Waste_Removal.Discharge_Limits = txtDischarge_Limits.Text.Trim();
            objPM_Waste_Removal.California_Business_Plan = txtCalifornia_Business_Plan.Text.Trim();
        }
        objPM_Waste_Removal.FK_PM_Site_Information = FK_PM_Site_Information;
        objPM_Waste_Removal.Updated_By = clsSession.UserID;
        objPM_Waste_Removal.Update_Date = DateTime.Now;
        objPM_Waste_Removal.Apply_To_Location = rdoApply_To_Location.SelectedValue;
        decimal _retVal;
        if (PK_PM_Waste_Removal > 0)
        {
            _retVal = 0;
            objPM_Waste_Removal.Update();
            // add the attachment 
            Attachment.FK_Field_Value = Convert.ToInt32(PK_PM_Waste_Removal);
            Attachment.FK_Field_Name = "FK_PM_Waste_Removal";
            Attachment.Add(clsGeneral.Pollution_Tables.PM_Waste_Removal_Attachments);
            Response.Redirect("Waste_Disposal_Waste_Removal.aspx?op=view&id=" + Encryption.Encrypt(Convert.ToString(PK_PM_Waste_Removal)) + "&fid=" + Encryption.Encrypt(Convert.ToString(FK_PM_Site_Information)) + "&loc=" + Encryption.Encrypt(Convert.ToString(FK_LU_Location_ID)));
        }
        else
        {
            _retVal = objPM_Waste_Removal.Insert();
            PK_PM_Waste_Removal = _retVal;
            // add the attachment 
            Attachment.FK_Field_Value = Convert.ToInt32(PK_PM_Waste_Removal);
            Attachment.FK_Field_Name = "FK_PM_Waste_Removal";
            Attachment.Add(clsGeneral.Pollution_Tables.PM_Waste_Removal_Attachments);
            if (!IsFromAdd)
                Response.Redirect("Waste_Disposal_Waste_Removal.aspx?op=view&id=" + Encryption.Encrypt(Convert.ToString(PK_PM_Waste_Removal)) + "&fid=" + Encryption.Encrypt(Convert.ToString(FK_PM_Site_Information)) + "&loc=" + Encryption.Encrypt(Convert.ToString(FK_LU_Location_ID)));
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
        if (PK_PM_Waste_Removal > 0)
            Response.Redirect("Waste_Disposal_Waste_Removal.aspx?op=edit&id=" + Encryption.Encrypt(Convert.ToString(PK_PM_Waste_Removal)) + "&fid=" + Encryption.Encrypt(Convert.ToString(FK_PM_Site_Information)) + "&loc=" + Encryption.Encrypt(Convert.ToString(FK_LU_Location_ID)));
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
            Response.Redirect("Pollution.aspx?op=view&id=" + Encryption.Encrypt(Convert.ToString(FK_PM_Site_Information)) + "&loc=" + Encryption.Encrypt(Convert.ToString(FK_LU_Location_ID)) + "&pnl=" + Encryption.Encrypt("5"));
        else
            Response.Redirect("Pollution.aspx?op=edit&id=" + Encryption.Encrypt(Convert.ToString(FK_PM_Site_Information)) + "&loc=" + Encryption.Encrypt(Convert.ToString(FK_LU_Location_ID)) + "&pnl=" + Encryption.Encrypt("5"));
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
        if (PK_PM_Waste_Removal > 0)
        {
            // add the attachment 
            Attachment.FK_Field_Value = Convert.ToInt32(PK_PM_Waste_Removal);
            Attachment.FK_Field_Name = "FK_PM_Waste_Removal";
            Attachment.Add(clsGeneral.Pollution_Tables.PM_Waste_Removal_Attachments);

            // bind the details to view added attachment
            BindAttachmentDetails();

            // show the attachment panel as the page is loaded again
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(2);", true);
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:alert('Please save Waste Removal details first.');ShowPanel(2);", true);
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

        DataTable dtFields = clsScreen_Validators.SelectByScreen(167).Tables[0];
        dtFields.DefaultView.RowFilter = "IsRequired = '1'";
        dtFields = dtFields.DefaultView.ToTable();

        MenuAsterisk1.Style["display"] = (dtFields.Rows.Count > 0) ? "inline-block" : "none";

        foreach (DataRow drField in dtFields.Rows)
        {
            #region " set validation control IDs and messages "
            switch (Convert.ToString(drField["Field_Name"]))
            {
                case "Waste Type":
                    strCtrlsIDs += drpFK_LU_Waste_Type.ClientID + ",";
                    strMessages += "Please select [Hazardous Waste Generator]/Waste Type" + ",";
                    Span1.Style["display"] = "inline-block";
                    break;
                case "Waste Hauler":
                    strCtrlsIDs += drpFK_PM_Waste_Hauler.ClientID + ",";
                    strMessages += "Please select [Hazardous Waste Generator]/Waste Hauler" + ",";
                    Span2.Style["display"] = "inline-block";
                    break;
                case "Receiving TSDF":
                    strCtrlsIDs += drpFK_Receiving_TSDF.ClientID + ",";
                    strMessages += "Please select [Hazardous Waste Generator]/Receiving TSDF" + ",";
                    Span3.Style["display"] = "inline-block";
                    break;
                case "Amount of Hazardous Waste Generated Per Month – in Pounds":
                    strCtrlsIDs += txtAmount_HW_Generated_Per_Month.ClientID + ",";
                    strMessages += "Please enter [Hazardous Waste Generator]/Amount of Hazardous Waste Generated Per Month – in Pounds" + ",";
                    Span4.Style["display"] = "inline-block";
                    break;
                case "Date":
                    strCtrlsIDs += txtDate.ClientID + ",";
                    strMessages += "Please enter [Hazardous Waste Generator]/Date" + ",";
                    Span5.Style["display"] = "inline-block";
                    break;
                //case "Constituents of Concern":
                //    strCtrlsIDs += txtConstituents_Of_Concern.ClientID + ",";
                //    strMessages += "Please enter [Hazardous Waste Generator]/Constituents of Concern" + ",";
                //    Span6.Style["display"] = "inline-block";
                //    break;
                //case "Removal Limits":
                //    strCtrlsIDs += txtRemoval_Limits.ClientID + ",";
                //    strMessages += "Please enter [Hazardous Waste Generator]/Removal Limits" + ",";
                //    Span7.Style["display"] = "inline-block";
                //    break;
                case "Hazardous Waste Codes":
                    strCtrlsIDs += drpHWCodes.ClientID + ",";
                    strMessages += "Please select [Hazardous Waste Generator]/Hazardous Waste Codes" + ",";
                    Span6.Style["display"] = "inline-block";
                    break;
                case "Start Date of Hazardous Waste Accumulation":
                    strCtrlsIDs += txtHWStartDate.ClientID + ",";
                    strMessages += "Please enter [Hazardous Waste Generator]/Start Date of Hazardous Waste Accumulation" + ",";
                    Span7.Style["display"] = "inline-block";
                    break;
                case "Date of Last Hazardous Waste Removal":
                    strCtrlsIDs += txtHWlastDate.ClientID + ",";
                    strMessages += "Please enter [Hazardous Waste Generator]/Date of Last Hazardous Waste Removal" + ",";
                    Span11.Style["display"] = "inline-block";
                    break;
                case "Facility Generator Status":
                    strCtrlsIDs += drpFK_LU_Facility_Generator_Status.ClientID + ",";
                    strMessages += "Please select [Hazardous Waste Generator]/Facility Generator Status" + ",";
                    Span8.Style["display"] = "inline-block";
                    break;
                case "Discharge Limits":
                    strCtrlsIDs += txtDischarge_Limits.ClientID + ",";
                    strMessages += "Please enter [Hazardous Waste Generator]/Discharge Limits" + ",";
                    Span9.Style["display"] = "inline-block";
                    break;
                case "California Business Plan":
                    strCtrlsIDs += txtCalifornia_Business_Plan.ClientID + ",";
                    strMessages += "Please enter [Hazardous Waste Generator]/California Business Plan" + ",";
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