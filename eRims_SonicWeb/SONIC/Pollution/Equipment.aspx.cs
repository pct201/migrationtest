using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ERIMS.DAL;
public partial class SONIC_Pollution_Equipment : clsBasePage
{
    #region Properties
    /// <summary>
    /// Denotes the Primary Key
    /// </summary>
    public decimal PK_PM_Equipment_Tank
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_PM_Equipment_Tank"]);
        }
        set { ViewState["PK_PM_Equipment_Tank"] = value; }
    }
    public decimal PM_Equipment
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PM_Equipment"]);
        }
        set { ViewState["PM_Equipment"] = value; }
    }
    public decimal FK_PM_Site_Information
    {
        get
        {
            return clsGeneral.GetInt(ViewState["FK_PM_Site_Information"]);
        }
        set { ViewState["FK_PM_Site_Information"] = value; }
    }
    /// <summary>
    /// Denotes foriegn key for Location record
    /// </summary>
    public decimal FK_LU_Location_ID
    {
        get { return Convert.ToInt32(ViewState["FK_LU_Location_ID"]); }
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
    /// <summary>
    /// Denotes the Primary Key Equipment_Spray_Booth Table
    /// </summary>
    public decimal PK_PM_Equipment_Spray_Booth
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_PM_Equipment_Spray_Booth"]);
        }
        set { ViewState["PK_PM_Equipment_Spray_Booth"] = value; }
    }
    /// <summary>
    /// Denotes the Primary Key Equipment_Spray_Booth Table
    /// </summary>
    public decimal PK_PM_Equipment_Prep_Station
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_PM_Equipment_Prep_Station"]);
        }
        set { ViewState["PK_PM_Equipment_Prep_Station"] = value; }
    }
    /// <summary>
    /// Denotes the Primary Key
    /// </summary>
    public decimal PK_PM_Equipment_Hydraulic_Lift
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_PM_Equipment_Hydraulic_Lift"]);
        }
        set { ViewState["PK_PM_Equipment_Hydraulic_Lift"] = value; }
    }
    /// <summary>
    /// Denotes the Primary Key
    /// </summary>
    public decimal PK_PM_Equipment_Hydraulic_Lift_Grid
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_PM_Equipment_Hydraulic_Lift_Grid"]);
        }
        set { ViewState["PK_PM_Equipment_Hydraulic_Lift_Grid"] = value; }
    }
    /// <summary>
    /// Denotes the Primary Key
    /// </summary>
    public decimal PK_PM_Equipment_PGCC
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_PM_Equipment_PGCC"]);
        }
        set { ViewState["PK_PM_Equipment_PGCC"] = value; }
    }
    /// <summary>
    /// Denotes the Primary Key
    /// </summary>
    public decimal PK_PM_Equipment_OWS
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_PM_Equipment_OWS"]);
        }
        set { ViewState["PK_PM_Equipment_OWS"] = value; }
    }
    /// <summary>
    /// Denotes the Primary Key
    /// </summary>
    public decimal PK_PM_Equipment_OWS_SR
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_PM_Equipment_OWS_SR"]);
        }
        set { ViewState["PK_PM_Equipment_OWS_SR"] = value; }
    }
    /// <summary>
    /// Audit Trail 
    /// </summary>
    public string AuditTrailText
    {
        get
        {
            return Convert.ToString(ViewState["AuditTrailText"]);
        }
        set { ViewState["AuditTrailText"] = value; }
    }

    private string SortOrder
    {
        get { return (!clsGeneral.IsNull(ViewState["SortOrder"]) ? ViewState["SortOrder"].ToString() : string.Empty); }
        set { ViewState["SortOrder"] = value; }
    }

    /// <summary>
    /// Denotes Sort Field to sort all records by
    /// </summary>
    private string SortBy
    {
        get { return (!clsGeneral.IsNull(ViewState["SortBy"]) ? ViewState["SortBy"].ToString() : string.Empty); }
        set { ViewState["SortBy"] = value; }
    }
    #endregion

    #region Page Events
    /// <summary>
    /// Handle Page Load Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {        
        Tab.SetSelectedTab(Controls_ExposuresTab_ExposuresTab.Tab.Pollution);
        Attachment.btnHandler += new Attachment_Pollution.OnButtonClick(Upload_File);
        if (!Page.IsPostBack)
        {
            //hydraulic lift grid sort fields
            SortBy = "Lift_Number_Replacement_Indicator";
            SortOrder = "asc";

            BindDropDown();
            drpEquipmentType.Focus();
            StrOperation = Convert.ToString(Request.QueryString["op"]);
            PM_Equipment = clsGeneral.GetQueryStringID(Request.QueryString["id"]);
            FK_PM_Site_Information = clsGeneral.GetQueryStringID(Request.QueryString["fid"]);
            FK_LU_Location_ID = clsGeneral.GetQueryStringID(Request.QueryString["loc"]);
            //// check if location id is passed in querystring or not          
            if (FK_LU_Location_ID > 0)
            {
                Session["ExposureLocation"] = FK_LU_Location_ID;
                ucCtrlExposureInfo.PK_LU_Location = FK_LU_Location_ID;
                ucCtrlExposureInfo.BindExposureInfo();
            }
            else
                Response.Redirect("../Exposures/ExposureSearch.aspx");
            if (PM_Equipment > 0)
            {
                //PK_Executive_Risk_Contacts = Convert.ToInt32(Request.QueryString["id"]);
                if (StrOperation == "view")
                {
                    // Bind Controls
                    BindDetailsForView();
                    btnEdit.Visible = (App_Access == AccessType.Administrative_Access);
                }
                else
                {
                    if (App_Access == AccessType.View_Only)
                        Response.Redirect(AppConfig.SiteURL + "Error.aspx?msg=errAcc");
                    // Bind Controls
                    BindDetailsForEdit();
                }
            }
            else
            {
                if (App_Access == AccessType.View_Only)
                    Response.Redirect(AppConfig.SiteURL + "Error.aspx?msg=errAcc");
                // don't show div for view mode
                dvView.Style["display"] = "none";
                btnAuditTrail.Visible = false;
                btnEdit.Visible = false;
            }
            // shows the first panel
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(1);", true);
        }
    }       
    #endregion

    #region Methods
    /// <summary>
    /// Bind DropDownList 
    /// </summary>
    private void BindDropDown()
    {
        ComboHelper.FillPollutionEquiptmentType(new DropDownList[] { drpEquipmentType }, true);
        ComboHelper.FillTankConstruction(new DropDownList[] { drpFK_Tank_Construction }, true);
        ComboHelper.FillTankContents(new DropDownList[] { drpFK_Tank_Contents }, true);
        ComboHelper.FillTankMaterial(new DropDownList[] { drpFK_Tank_Material }, true);
        ComboHelper.FillSecondaryContainmentType(new DropDownList[] { drpFK_LU_Secondary_Containment_Type }, true);
    }
    /// <summary>
    /// Bind Page Control in Edit Mode
    /// </summary>
    private void BindDetailsForEdit()
    {
        hdnControlIDsTank.Value = ""; hdnErrorMsgsTank.Value = "";
        hdnControlIDsSprayBooth.Value = ""; hdnErrorMsgsSprayBooth.Value = "";
        hdnControlIDsPrepStation.Value = ""; hdnErrorMsgsPrepStation.Value = "";
        hdnControlIDsOWS.Value = ""; hdnErrorMsgsOWS.Value = "";
        hdnControlIDsOWSInnerGrid.Value = ""; hdnErrorMsgsOWSInnerGrid.Value = "";
        hdnControlIDsHydraulicLiftGrid.Value = ""; hdnErrorMsgsHydraulicLiftGrid.Value = "";
        hdnControlIDsPGCC.Value = ""; hdnErrorMsgsPGCC.Value = "";

        btnEdit.Visible = false;
        btnSaveView.Visible = true;
        btnAuditTrail.Visible = true;

        clsPM_Equipment objPM_Equipment = new clsPM_Equipment(PM_Equipment);
        if (objPM_Equipment.FK_LU_Equipment_Type != null)
            drpEquipmentType.SelectedValue = Convert.ToString(objPM_Equipment.FK_LU_Equipment_Type);
        else
            drpEquipmentType.SelectedIndex = 0;
        AuditTrailText = drpEquipmentType.SelectedItem.Text.ToString();
        if (PM_Equipment > 0)
        {
            //Equiptment type 'Tank' is selected then Pass Table Name 'PM_Equipment_Tank' and return PK_ID from PM_Equipment_Tank Table
            if (drpEquipmentType.SelectedItem.ToString().ToLower().Trim() == "tank")
            {
                SetValidationsTank();
                PK_PM_Equipment_Tank = (decimal)objPM_Equipment.FK_Table_Name;
                BindDetailsFor_Equipment_Tank_Edit();
            }
            //Equiptment type 'Paint Booth' is selected then Pass Table Name 'PK_PM_Equipment_Spray_Booth' and return PK_ID from PM_Equipment_Spray_Booth Table
            else if (drpEquipmentType.SelectedItem.ToString().ToLower().Trim() == "paint booth")
            {
                SetValidationsPaintBooth();
                PK_PM_Equipment_Spray_Booth = (decimal)objPM_Equipment.FK_Table_Name;
                BindDetailsFor_Equipment_Spray_Booth_Edit();
            }
            //Equiptment type 'Prep Station' is selected then Pass Table Name 'PK_PM_Equipment_Prep_Station' and return PK_ID from PM_Equipment_Spray_Booth Table
            else if (drpEquipmentType.SelectedItem.ToString().ToLower().Trim() == "prep station")
            {
                SetValidationsPrepStation();
                PK_PM_Equipment_Prep_Station = (decimal)objPM_Equipment.FK_Table_Name;
                BindDetailsFor_Equipment_Prep_Station_Edit();
            }
            //Equiptment type 'Oil and Water Separator' is selected then Pass Table Name 'PM_Equipment_Tank' and return PK_ID from PM_Equipment_OWS Table
            else if (drpEquipmentType.SelectedItem.ToString().ToLower().Trim() == "oil and water separator")
            {
                SetValidationsOWS();
                PK_PM_Equipment_OWS = (decimal)objPM_Equipment.FK_Table_Name;
                BindDetailsFor_Equipment_OWS_Edit();
            }
            //Equiptment type 'Hydraulic Lift' is selected then Pass Table Name 'PK_PM_Equipment_Hydraulic_Lift' and return PK_ID from PM_Equipment_Hydraulic_Lift Table
            //Equiptment type 'Alignment Rack' is selected then Pass Table Name 'PK_PM_Equipment_Hydraulic_Lift' and return PK_ID from PM_Equipment_Hydraulic_Lift Table // Ticket # 3142
            else if (drpEquipmentType.SelectedItem.ToString().ToLower().Trim() == "hydraulic lift" || drpEquipmentType.SelectedItem.ToString().ToLower().Trim() == "alignment rack")
            {
                SetValidationsHydraulic();
                PK_PM_Equipment_Hydraulic_Lift = (decimal)objPM_Equipment.FK_Table_Name;
                BindDetailsFor_Equipment_Hydraulic_Lift_Edit();
            }
            //Equiptment type 'Paint Gun Cleaning Cabinet' is selected then Pass Table Name 'PM_Equipment_PGCC' and return PK_ID from PM_Equipment_PGCC Table
            else if (drpEquipmentType.SelectedItem.ToString().ToLower().Trim() == "paint gun cleaning cabinet")
            {
                SetValidationsPGCC();
                PK_PM_Equipment_PGCC = (decimal)objPM_Equipment.FK_Table_Name;
                BindDetailsFor_Equipment_PGCC_Edit();
            }
        }
    }
    /// <summary>
    /// Bind Page Control in View Mode
    /// </summary>
    private void BindDetailsForView()
    {
        btnEdit.Visible = true;
        btnSaveView.Visible = false;
        btnAuditTrail.Visible = true;

        clsPM_Equipment objPM_Equipment = new clsPM_Equipment(PM_Equipment);
        PM_Equipment = (decimal)objPM_Equipment.PK_PM_Equipment;
        string strEquiptmentType = objPM_Equipment.Table_Name;
        if (strEquiptmentType.ToString() == "PM_Equipment_Tank")
        {
            PK_PM_Equipment_Tank = Convert.ToDecimal(objPM_Equipment.FK_Table_Name);
            BindDetailsFor_Equipment_Tank_View();
        }
        else if (strEquiptmentType.ToString() == "PM_Equipment_Spray_Booth")
        {
            PK_PM_Equipment_Spray_Booth = Convert.ToDecimal(objPM_Equipment.FK_Table_Name);
            BindDetailsFor_Equipment_Spray_Booth_View();
        }
        else if (strEquiptmentType.ToString() == "PM_Equipment_Prep_Station")
        {
            PK_PM_Equipment_Prep_Station = Convert.ToDecimal(objPM_Equipment.FK_Table_Name);
            BindDetailsFor_Equipment_Prep_Station_View();
        }
        else if (strEquiptmentType.ToString() == "PM_Equipment_OWS")
        {
            PK_PM_Equipment_OWS = Convert.ToDecimal(objPM_Equipment.FK_Table_Name);
            BindDetailsFor_Equipment_OWS_View();
        }
        else if (strEquiptmentType.ToString() == "PM_Equipment_Hydraulic_Lift")
        {
            PK_PM_Equipment_Hydraulic_Lift = Convert.ToDecimal(objPM_Equipment.FK_Table_Name);
            BindDetailsFor_Equipment_Hydraulic_Lift_View();
        }
        else if (strEquiptmentType.ToString() == "PM_Equipment_PGCC")
        {
            PK_PM_Equipment_PGCC = Convert.ToDecimal(objPM_Equipment.FK_Table_Name);
            BindDetailsFor_Equipment_PGCC_View();
        }
        AuditTrailText = strEquiptmentType;
    }
    /// <summary>
    /// Bind Tank Page Controls for edit mode
    /// </summary>
    private void BindDetailsFor_Equipment_Tank_Edit()
    {
        dvView.Visible = false;
        dvEdit.Visible = true;
        pnl1.Style["display"] = "block";

        pnlTank.Visible = true;
        pnlSprayBooth.Visible = false;
        pnlOWS.Visible = false;
        pnlHydraulicLiftType.Visible = false;
        pnlPGCC.Visible = false;

        clsPM_Equipment_Tank objPM_Equipment_Tank = new clsPM_Equipment_Tank(PK_PM_Equipment_Tank);
        if (objPM_Equipment_Tank.PK_PM_Equipment != null)
            PM_Equipment = (decimal)objPM_Equipment_Tank.PK_PM_Equipment;
        //lblEquiptmentType.Text = drpEquipmentType.SelectedItem.Text.ToString();
        txtTankManufacture.Text = Convert.ToString(objPM_Equipment_Tank.Manufacturer);
        txtDescription.Text = objPM_Equipment_Tank.Description;
        if (objPM_Equipment_Tank.Ground_Location != null)
            rdoGround_Location.SelectedValue = objPM_Equipment_Tank.Ground_Location;
        //else
        //rdoGround_Location.SelectedValue = "S";
        txtIdentification.Text = objPM_Equipment_Tank.Identification;
        if (objPM_Equipment_Tank.FK_Tank_Contents != null) drpFK_Tank_Contents.SelectedValue = objPM_Equipment_Tank.FK_Tank_Contents.ToString();
        txtContents_Other.Text = objPM_Equipment_Tank.Contents_Other;
        if (objPM_Equipment_Tank.FK_Tank_Material != null) drpFK_Tank_Material.SelectedValue = objPM_Equipment_Tank.FK_Tank_Material.ToString();
        txtMaterial_Other.Text = objPM_Equipment_Tank.Material_Other;
        if (objPM_Equipment_Tank.FK_Tank_Construction != null) drpFK_Tank_Construction.SelectedValue = objPM_Equipment_Tank.FK_Tank_Construction.ToString();
        txtConstruction_Other.Text = objPM_Equipment_Tank.Construction_Other;
        txtCapcity.Text = clsGeneral.GetStringValue(objPM_Equipment_Tank.Capcity);
        txtCertificate_Number.Text = objPM_Equipment_Tank.Certificate_Number;
        txtInstallation_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objPM_Equipment_Tank.Installation_Date);
        txtInstallation_Firm.Text = objPM_Equipment_Tank.Installation_Firm;
        txtLast_Maintenance_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objPM_Equipment_Tank.Last_Maintenance_Date);
        txtLast_Revision_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objPM_Equipment_Tank.Last_Revision_Date);
        if (objPM_Equipment_Tank.Tank_In_Use != null)
            rdoTank_In_Use.SelectedValue = objPM_Equipment_Tank.Tank_In_Use;
        else
            rdoTank_In_Use.SelectedValue = "Y";

        if (objPM_Equipment_Tank.UL_Certified != null)
            rdbULCertified.SelectedValue = objPM_Equipment_Tank.UL_Certified;
        else
            rdbULCertified.SelectedValue = "Y";

        if (objPM_Equipment_Tank.Secure_Non_Business != null)
            rdbSecureNonBusiness.SelectedValue = objPM_Equipment_Tank.Secure_Non_Business;
        else
            rdbSecureNonBusiness.SelectedValue = "Y";

        txtLast_Inspection_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objPM_Equipment_Tank.Last_Inspection_Date);
        txtClosure_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objPM_Equipment_Tank.Closure_Date);
        txtRemoval_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objPM_Equipment_Tank.Removal_Date);
        txtRevised_Removal_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objPM_Equipment_Tank.Revised_Removal_Date);
        txtPermit_Begin_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objPM_Equipment_Tank.Permit_Begin_Date);
        txtPermit_End_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objPM_Equipment_Tank.Permit_End_Date);
        if (objPM_Equipment_Tank.Registration_Required != null)
            rdoRegistration_Required.SelectedValue = objPM_Equipment_Tank.Registration_Required;
        else
            rdoRegistration_Required.SelectedValue = "Y";
        txtRegistration_Number.Text = objPM_Equipment_Tank.Registration_Number;
        if (objPM_Equipment_Tank.Leak_Detection_Required != null)
            rdoLeak_Detection_Required.SelectedValue = objPM_Equipment_Tank.Leak_Detection_Required;
        else
            rdoLeak_Detection_Required.SelectedValue = "Y";
        txtLeak_Detection_Type.Text = objPM_Equipment_Tank.Leak_Detection_Type;
        if (objPM_Equipment_Tank.Overfill_Protection != null)
            rdoOverfill_Protection.SelectedValue = objPM_Equipment_Tank.Overfill_Protection;
        else
            rdoOverfill_Protection.SelectedValue = "Y";
        if (objPM_Equipment_Tank.Secondary_Containment_Adequate != null)
            rdoSecondary_Containment_Adequate.SelectedValue = objPM_Equipment_Tank.Secondary_Containment_Adequate;
        else
            rdoSecondary_Containment_Adequate.SelectedValue = "Y";
        if (objPM_Equipment_Tank.FK_LU_Secondary_Containment_Type != null) drpFK_LU_Secondary_Containment_Type.SelectedValue = objPM_Equipment_Tank.FK_LU_Secondary_Containment_Type.ToString();
        txtDescription_Other_Reporting_Requirements.Text = objPM_Equipment_Tank.Description_Other_Reporting_Requirements;
        txtPlan_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objPM_Equipment_Tank.Plan_Date);
        txtPlan_Identification.Text = objPM_Equipment_Tank.Plan_Identification;
        txtRecommendations.Text = objPM_Equipment_Tank.Recommendations;
        txtEffective_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objPM_Equipment_Tank.Effective_Date);
        txtExpiration_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objPM_Equipment_Tank.Expiration_Date);
        txtRecordkeeping_Requirements.Text = objPM_Equipment_Tank.Recordkeeping_Requirements;
        //txtRelease_Control_Countermeasures_Plan.Text = objPM_Equipment_Tank.Release_Control_Countermeasures_Plan;            //* :3187 *//
        if (objPM_Equipment_Tank.SPCC_Required != null)
            rdoSPCC_Required.SelectedValue = objPM_Equipment_Tank.SPCC_Required;
        else
            rdoSPCC_Required.SelectedValue = "Y";
        txtSPCCDate_Developed.Text = clsGeneral.FormatDBNullDateToDisplay(objPM_Equipment_Tank.SPCCDate_Developed);
        txtSPCCExpiration_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objPM_Equipment_Tank.SPCCExpiration_Date);
        txtMaintenance_Vendor.Text = objPM_Equipment_Tank.Maintenance_Vendor;
        txtVendor_Contact_Name.Text = objPM_Equipment_Tank.Vendor_Contact_Name;
        txtVendor_Contact_Telephone.Text = objPM_Equipment_Tank.Vendor_Contact_Telephone;
        txtInsurer.Text = objPM_Equipment_Tank.Insurer;
        txtCoverage_Start_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objPM_Equipment_Tank.Coverage_Start_Date);
        txtCoverage_End_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objPM_Equipment_Tank.Coverage_End_Date);
        txtMultiple_Event_Total_Coverage.Text = clsGeneral.GetStringValue(objPM_Equipment_Tank.Multiple_Event_Total_Coverage);
        txtSingle_Event_Coverage.Text = clsGeneral.GetStringValue(objPM_Equipment_Tank.Single_Event_Coverage);
        txtInspection_Company.Text = objPM_Equipment_Tank.Inspection_Company;
        txtInspection_Company_Contact_Name.Text = objPM_Equipment_Tank.Inspection_Company_Contact_Name;
        txtInspection_Company_Contact_Telephone.Text = objPM_Equipment_Tank.Inspection_Company_Contact_Telephone;
        txtNotes.Text = objPM_Equipment_Tank.Notes;
        // set attachment details control in read/write mode. so user can add or remove attachment as well.
        // AttachDetailsTank.InitializeAttachmentDetails(clsGeneral.Pollution_Tables.PM_Equipment_Attachments, Convert.ToInt32(PK_PM_Equipment_Tank), "FK_Table_Name", "PK_PM_Equipment_Attachments", true, 2);
        // BindTankAttachmentDetaills();
        if (objPM_Equipment_Tank.Status != null)
            rdoEquipmentStatus.SelectedValue = objPM_Equipment_Tank.Status;
        else
            rdoEquipmentStatus.SelectedValue = "N";
        AttachDetails.Equipment_Table_Name = "PM_Equipment_Tank";
        AttachDetails.InitializeAttachmentDetails(clsGeneral.Pollution_Tables.PM_Equipment_Attachments, Convert.ToInt32(PK_PM_Equipment_Tank), "FK_Table_Name", "PK_PM_Equipment_Attachments", true, 2);
        BindTankAttachmentDetaills();
    }
    /// <summary>
    /// Bind Tank Page Controls for view mode
    /// </summary>
    private void BindDetailsFor_Equipment_Tank_View()
    {
        dvView.Visible = true;
        dvEdit.Visible = false;
        pnlTankview.Style["display"] = "block";
        pnlSprayBoothTypeview.Style["display"] = "none";
        pnlOWSTypeview.Style["display"] = "none";
        pnlHydraulicLiftTypeview.Style["display"] = "none";
        pnlPGCCview.Style["display"] = "none";
        clsPM_Equipment_Tank objPM_Equipment_Tank = new clsPM_Equipment_Tank(PK_PM_Equipment_Tank);
        lblEquiptmentTank.Text = "Tank";
        lblTankManufacturer.Text = Convert.ToString(objPM_Equipment_Tank.Manufacturer);
        lblDescription.Text = objPM_Equipment_Tank.Description;
        lblGround_Location.Text = objPM_Equipment_Tank.Ground_Location == "S" ? "On Surface" : objPM_Equipment_Tank.Ground_Location == "U" ? "Underground" : "";
        lblIdentification.Text = objPM_Equipment_Tank.Identification;
        if (objPM_Equipment_Tank.FK_Tank_Contents != null)
            lblFK_Tank_Contents.Text = new LU_Tank_Contents((decimal)objPM_Equipment_Tank.FK_Tank_Contents).Fld_Desc;
        lblContents_Other.Text = objPM_Equipment_Tank.Contents_Other;
        if (objPM_Equipment_Tank.FK_Tank_Material != null)
            lblFK_Tank_Material.Text = new LU_Tank_Material((decimal)objPM_Equipment_Tank.FK_Tank_Material).Fld_Desc;
        lblMaterial_Other.Text = objPM_Equipment_Tank.Material_Other;
        if (objPM_Equipment_Tank.FK_Tank_Construction != null)
            lblFK_Tank_Construction.Text = new LU_Tank_Construction((decimal)objPM_Equipment_Tank.FK_Tank_Construction).Fld_Desc;
        lblConstruction_Other.Text = objPM_Equipment_Tank.Construction_Other;
        lblCapcity.Text = clsGeneral.GetStringValue(objPM_Equipment_Tank.Capcity);
        lblCertificate_Number.Text = objPM_Equipment_Tank.Certificate_Number;
        lblInstallation_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objPM_Equipment_Tank.Installation_Date);
        lblInstallation_Firm.Text = objPM_Equipment_Tank.Installation_Firm;
        lblLast_Maintenance_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objPM_Equipment_Tank.Last_Maintenance_Date);
        lblLast_Revision_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objPM_Equipment_Tank.Last_Revision_Date);
        lblTank_In_Use.Text = objPM_Equipment_Tank.Tank_In_Use == "Y" ? "Yes" : "No";
        lblULCertified.Text = objPM_Equipment_Tank.UL_Certified == "Y" ? "Yes" : "No";
        lblSecureNonBusiness.Text = objPM_Equipment_Tank.Secure_Non_Business == "Y" ? "Yes" : "No";
        lblLast_Inspection_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objPM_Equipment_Tank.Last_Inspection_Date);
        lblClosure_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objPM_Equipment_Tank.Closure_Date);
        lblRemoval_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objPM_Equipment_Tank.Removal_Date);
        lblRevised_Removal_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objPM_Equipment_Tank.Revised_Removal_Date);
        lblPermit_Begin_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objPM_Equipment_Tank.Permit_Begin_Date);
        lblPermit_End_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objPM_Equipment_Tank.Permit_End_Date);
        lblRegistration_Required.Text = objPM_Equipment_Tank.Registration_Required == "Y" ? "Yes" : "No";
        lblRegistration_Number.Text = objPM_Equipment_Tank.Registration_Number;
        lblLeak_Detection_Required.Text = objPM_Equipment_Tank.Leak_Detection_Required == "Y" ? "Yes" : "No";
        lblLeak_Detection_Type.Text = objPM_Equipment_Tank.Leak_Detection_Type;
        lblOverfill_Protection.Text = objPM_Equipment_Tank.Overfill_Protection == "Y" ? "Yes" : "No";
        lblSecondary_Containment_Adequate.Text = objPM_Equipment_Tank.Secondary_Containment_Adequate == "Y" ? "Yes" : "No";
        if (objPM_Equipment_Tank.FK_LU_Secondary_Containment_Type != null)
            lblFK_LU_Secondary_Containment_Type.Text = new LU_Secondary_Containment_Type((decimal)objPM_Equipment_Tank.FK_LU_Secondary_Containment_Type).Fld_Desc;
        lblDescription_Other_Reporting_Requirements.Text = objPM_Equipment_Tank.Description_Other_Reporting_Requirements;
        lblPlan_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objPM_Equipment_Tank.Plan_Date);
        lblPlan_Identification.Text = objPM_Equipment_Tank.Plan_Identification;
        lblRecommendations.Text = objPM_Equipment_Tank.Recommendations;
        lblEffective_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objPM_Equipment_Tank.Effective_Date);
        lblExpiration_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objPM_Equipment_Tank.Expiration_Date);
        lblRecordkeeping_Requirements.Text = objPM_Equipment_Tank.Recordkeeping_Requirements;
        //lblRelease_Control_Countermeasures_Plan.Text = objPM_Equipment_Tank.Release_Control_Countermeasures_Plan;    //*  :3187  *//
        lblSPCC_Required.Text = objPM_Equipment_Tank.SPCC_Required == "Y" ? "Yes" : "No";
        lblSPCCDate_Developed.Text = clsGeneral.FormatDBNullDateToDisplay(objPM_Equipment_Tank.SPCCDate_Developed);
        lblSPCCExpiration_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objPM_Equipment_Tank.SPCCExpiration_Date);        
        lblMaintenance_Vendor.Text = objPM_Equipment_Tank.Maintenance_Vendor;
        lblVendor_Contact_Name.Text = objPM_Equipment_Tank.Vendor_Contact_Name;
        lblVendor_Contact_Telephone.Text = objPM_Equipment_Tank.Vendor_Contact_Telephone;
        lblInsurer.Text = objPM_Equipment_Tank.Insurer;
        lblCoverage_Start_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objPM_Equipment_Tank.Coverage_Start_Date);
        lblCoverage_End_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objPM_Equipment_Tank.Coverage_End_Date);
        lblMultiple_Event_Total_Coverage.Text = clsGeneral.GetStringValue(objPM_Equipment_Tank.Multiple_Event_Total_Coverage);
        lblSingle_Event_Coverage.Text = clsGeneral.GetStringValue(objPM_Equipment_Tank.Single_Event_Coverage);
        lblInspection_Company.Text = objPM_Equipment_Tank.Inspection_Company;
        lblInspection_Company_Contact_Name.Text = objPM_Equipment_Tank.Inspection_Company_Contact_Name;
        lblInspection_Company_Contact_Telephone.Text = objPM_Equipment_Tank.Inspection_Company_Contact_Telephone;
        lblNotes.Text = objPM_Equipment_Tank.Notes;
        lblEquipmentStatus.Text = lblStatus.Text = Convert.ToString(objPM_Equipment_Tank.Status) == "A" ? "Active" : (Convert.ToString(objPM_Equipment_Tank.Status) == "N" ? "Non-Active" : (Convert.ToString(objPM_Equipment_Tank.Status) == "R" ? "Removed" : string.Empty)); 
        // set attachment details control in readonly mode.
        //TankAttachDetailsView.InitializeAttachmentDetails(clsGeneral.Pollution_Tables.PM_Equipment_Attachments, Convert.ToInt32(PK_PM_Equipment_Tank), "FK_Table_Name", "PK_PM_Equipment_Attachments", false, 2);
        //BindTankAttachmentDetaills();
        AttachDetailsView.Equipment_Table_Name = "PM_Equipment_Tank";
        AttachDetailsView.InitializeAttachmentDetails(clsGeneral.Pollution_Tables.PM_Equipment_Attachments, Convert.ToInt32(PK_PM_Equipment_Tank), "FK_Table_Name", "PK_PM_Equipment_Attachments", false, 2);
        BindTankAttachmentDetaills();
    }
    /// <summary>
    /// Bind Paint Booth Page Controls for edit mode
    /// </summary>
    private void BindDetailsFor_Equipment_Spray_Booth_Edit()
    {
        dvView.Visible = false;
        dvEdit.Visible = true;
        pnl1.Style["display"] = "block";


        pnlTank.Visible = false;
        pnlSprayBooth.Visible = true;
        pnlOWS.Visible = false;
        pnlHydraulicLiftType.Visible = false;
        pnlPGCC.Visible = false;

        clsPM_Equipment_Spray_Booth objPM_Equipment_Spray_Booth = new clsPM_Equipment_Spray_Booth(PK_PM_Equipment_Spray_Booth);
        if (objPM_Equipment_Spray_Booth.PK_PM_Equipment != null)
            PM_Equipment = (decimal)objPM_Equipment_Spray_Booth.PK_PM_Equipment;
        //lblEquiptmentSprayBooth.Text = "Paint Booth";
        txtSprayBoothDesc.Text = objPM_Equipment_Spray_Booth.Description;
        txtManufacturer_Name.Text = objPM_Equipment_Spray_Booth.Manufacturer_Name;
        txtInstallationDate.Text = clsGeneral.FormatDBNullDateToDisplay(objPM_Equipment_Spray_Booth.Installation_Date);
        if (objPM_Equipment_Spray_Booth.Configured_For_Water_Borne_Application != null)
            rdoConfigured_For_Water_Borne_Application.SelectedValue = objPM_Equipment_Spray_Booth.Configured_For_Water_Borne_Application;
        else
            rdoConfigured_For_Water_Borne_Application.SelectedValue = "Y";
        if (objPM_Equipment_Spray_Booth.Direct_Indirect_Burners != null)
            rdoDirect_Indirect_Burners.SelectedValue = objPM_Equipment_Spray_Booth.Direct_Indirect_Burners;
        else
            rdoDirect_Indirect_Burners.SelectedValue = "D";
        txtBTU_Rating.Text = clsGeneral.GetStringValue(objPM_Equipment_Spray_Booth.BTU_Rating);
        txtHeight_In_Feet.Text = clsGeneral.GetStringValue(objPM_Equipment_Spray_Booth.Height_In_Feet);
        txtWidth_In_Feet.Text = clsGeneral.GetStringValue(objPM_Equipment_Spray_Booth.Width_In_Feet);
        txtDepth_In_Feet.Text = clsGeneral.GetStringValue(objPM_Equipment_Spray_Booth.Depth_In_Feet);
        txtFilter_System.Text = objPM_Equipment_Spray_Booth.Filter_System;
        txtCapture_Efficiency.Text = clsGeneral.GetStringValue(objPM_Equipment_Spray_Booth.Capture_Efficiency);
        txtControl_Efficiency.Text = clsGeneral.GetStringValue(objPM_Equipment_Spray_Booth.Control_Efficiency);
        txtStack_Height_In_Feet.Text = clsGeneral.GetStringValue(objPM_Equipment_Spray_Booth.Stack_Height_In_Feet);
        txtExit_Flow_Rate_CFM.Text = clsGeneral.GetStringValue(objPM_Equipment_Spray_Booth.Exit_Flow_Rate_CFM);
        txtExit_Temperature_Low.Text = clsGeneral.GetStringValue(objPM_Equipment_Spray_Booth.Exit_Temperature_Low);
        txtExit_Temperature_High.Text = clsGeneral.GetStringValue(objPM_Equipment_Spray_Booth.Exit_Temperature_High);
        txtSprayBoothNotes.Text = objPM_Equipment_Spray_Booth.Notes;
        if (objPM_Equipment_Spray_Booth.Manual_6H_Binder != null)
            rdbManual6HBinder.SelectedValue = objPM_Equipment_Spray_Booth.Manual_6H_Binder;
        else
            rdbManual6HBinder.SelectedValue = "Y";
        txtCaptureEfficiencyDate.Text = clsGeneral.FormatDBNullDateToDisplay(objPM_Equipment_Spray_Booth.Capture_Efficieicny_Date);
        txtControlEfficiencyDate.Text = clsGeneral.FormatDBNullDateToDisplay(objPM_Equipment_Spray_Booth.Control_Efficiency_Date);

        //AttachDetailsSprayBooth.InitializeAttachmentDetails(clsGeneral.Pollution_Tables.PM_Equipment_Attachments, Convert.ToInt32(PK_PM_Equipment_Spray_Booth), "FK_Table_Name", "PK_PM_Equipment_Attachments", true, 2);
        //BindSprayBoothAttachmentDetaills();
        AttachDetails.Equipment_Table_Name = "PM_Equipment_Spray_Booth";
        AttachDetails.InitializeAttachmentDetails(clsGeneral.Pollution_Tables.PM_Equipment_Attachments, Convert.ToInt32(PK_PM_Equipment_Spray_Booth), "FK_Table_Name", "PK_PM_Equipment_Attachments", true, 2);
        BindSprayBoothAttachmentDetaills();
    }
    /// <summary>
    /// Bind Paint Booth Page Controls for view mode
    /// </summary>
    private void BindDetailsFor_Equipment_Spray_Booth_View()
    {
        dvView.Visible = true;
        dvEdit.Visible = false;
        pnlTankview.Style["display"] = "none";
        pnlSprayBoothTypeview.Style["display"] = "block";
        pnlOWSTypeview.Style["display"] = "none";
        pnlHydraulicLiftTypeview.Style["display"] = "none";
        pnlPGCCview.Style["display"] = "none";
        clsPM_Equipment_Spray_Booth objPM_Equipment_Spray_Booth = new clsPM_Equipment_Spray_Booth(PK_PM_Equipment_Spray_Booth);
        lblSprayBoothType.Text = "Paint Booth";
        lblSprayBoothDescription.Text = objPM_Equipment_Spray_Booth.Description;
        lblManufacturer_Name.Text = objPM_Equipment_Spray_Booth.Manufacturer_Name;
        lblInstallationDate.Text = clsGeneral.FormatDBNullDateToDisplay(objPM_Equipment_Spray_Booth.Installation_Date);
        lblConfigured_For_Water_Borne_Application.Text = objPM_Equipment_Spray_Booth.Configured_For_Water_Borne_Application == "Y" ? "Yes" : "No";
        lblDirect_Indirect_Burners.Text = objPM_Equipment_Spray_Booth.Direct_Indirect_Burners == "D" ? "Direct" : "Indirect";
        lblBTU_Rating.Text = clsGeneral.GetStringValue(objPM_Equipment_Spray_Booth.BTU_Rating);
        lblHeight_In_Feet.Text = clsGeneral.GetStringValue(objPM_Equipment_Spray_Booth.Height_In_Feet);
        lblWidth_In_Feet.Text = clsGeneral.GetStringValue(objPM_Equipment_Spray_Booth.Width_In_Feet);
        lblDepth_In_Feet.Text = clsGeneral.GetStringValue(objPM_Equipment_Spray_Booth.Depth_In_Feet);
        lblFilter_System.Text = objPM_Equipment_Spray_Booth.Filter_System;
        lblCapture_Efficiency.Text = clsGeneral.GetStringValue(objPM_Equipment_Spray_Booth.Capture_Efficiency);
        lblControl_Efficiency.Text = clsGeneral.GetStringValue(objPM_Equipment_Spray_Booth.Control_Efficiency);
        lblStack_Height_In_Feet.Text = clsGeneral.GetStringValue(objPM_Equipment_Spray_Booth.Stack_Height_In_Feet);
        lblExit_Flow_Rate_CFM.Text = clsGeneral.GetStringValue(objPM_Equipment_Spray_Booth.Exit_Flow_Rate_CFM);
        lblExit_Temperature_Low.Text = clsGeneral.GetStringValue(objPM_Equipment_Spray_Booth.Exit_Temperature_Low);
        lblExit_Temperature_High.Text = clsGeneral.GetStringValue(objPM_Equipment_Spray_Booth.Exit_Temperature_High);
        lblSprayBoothNotes.Text = objPM_Equipment_Spray_Booth.Notes;
        lblManual6HBinder.Text = objPM_Equipment_Spray_Booth.Manual_6H_Binder == "N" ? "No" : "Yes";
        lblCapture_EfficiencyDate.Text = clsGeneral.FormatDBNullDateToDisplay(objPM_Equipment_Spray_Booth.Capture_Efficieicny_Date);
        lblControl_EfficiencyDate.Text = clsGeneral.FormatDBNullDateToDisplay(objPM_Equipment_Spray_Booth.Control_Efficiency_Date);

        //SprayBoothAttachDetailsView.InitializeAttachmentDetails(clsGeneral.Pollution_Tables.PM_Equipment_Attachments, Convert.ToInt32(PK_PM_Equipment_Spray_Booth), "FK_Table_Name", "PK_PM_Equipment_Attachments", false, 2);
        //BindSprayBoothAttachmentDetaills();
        AttachDetailsView.Equipment_Table_Name = "PM_Equipment_Spray_Booth";
        AttachDetailsView.InitializeAttachmentDetails(clsGeneral.Pollution_Tables.PM_Equipment_Attachments, Convert.ToInt32(PK_PM_Equipment_Spray_Booth), "FK_Table_Name", "PK_PM_Equipment_Attachments", false, 2);
        BindSprayBoothAttachmentDetaills();
    }
    /// <summary>
    /// Bind Prep Station Page Controls for edit mode
    /// </summary>
    private void BindDetailsFor_Equipment_Prep_Station_Edit()
    {
        dvView.Visible = false;
        dvEdit.Visible = true;
        pnl1.Style["display"] = "block";


        pnlTank.Visible = false;
        pnlPrepStation.Visible = true;
        pnlOWS.Visible = false;
        pnlHydraulicLiftType.Visible = false;
        pnlPGCC.Visible = false;

        clsPM_Equipment_Prep_Station objPM_Equipment_Prep_Station = new clsPM_Equipment_Prep_Station(PK_PM_Equipment_Prep_Station);
        if (objPM_Equipment_Prep_Station.PK_PM_Equipment != null)
            PM_Equipment = (decimal)objPM_Equipment_Prep_Station.PK_PM_Equipment;
        //lblEquiptmentSprayBooth.Text = "Paint Booth";
        txtPrepStationDesc.Text = objPM_Equipment_Prep_Station.Description;
        txtManufacturer_Name_PrepStation.Text = objPM_Equipment_Prep_Station.Manufacturer_Name;
        txtInstallationDate_PrepStation.Text = clsGeneral.FormatDBNullDateToDisplay(objPM_Equipment_Prep_Station.Installation_Date);
        if (objPM_Equipment_Prep_Station.Configured_For_Water_Borne_Application != null)
            rdoConfigured_For_Water_Borne_Application_PrepStation.SelectedValue = objPM_Equipment_Prep_Station.Configured_For_Water_Borne_Application;
        else
            rdoConfigured_For_Water_Borne_Application_PrepStation.SelectedValue = "Y";
        if (objPM_Equipment_Prep_Station.Direct_Indirect_Burners != null)
            rdoDirect_Indirect_Burners_PrepStation.SelectedValue = objPM_Equipment_Prep_Station.Direct_Indirect_Burners;
        else
            rdoDirect_Indirect_Burners_PrepStation.SelectedValue = "D";
        txtBTU_Rating_PrepStation.Text = clsGeneral.GetStringValue(objPM_Equipment_Prep_Station.BTU_Rating);
        txtHeight_In_Feet_PrepStation.Text = clsGeneral.GetStringValue(objPM_Equipment_Prep_Station.Height_In_Feet);
        txtWidth_In_Feet_PrepStation.Text = clsGeneral.GetStringValue(objPM_Equipment_Prep_Station.Width_In_Feet);
        txtDepth_In_Feet_PrepStation.Text = clsGeneral.GetStringValue(objPM_Equipment_Prep_Station.Depth_In_Feet);
        txtFilter_System_PrepStation.Text = objPM_Equipment_Prep_Station.Filter_System;
        txtCapture_Efficiency_PrepStation.Text = clsGeneral.GetStringValue(objPM_Equipment_Prep_Station.Capture_Efficiency);
        txtControl_Efficiency_PrepStation.Text = clsGeneral.GetStringValue(objPM_Equipment_Prep_Station.Control_Efficiency);
        txtStack_Height_In_Feet_PrepStation.Text = clsGeneral.GetStringValue(objPM_Equipment_Prep_Station.Stack_Height_In_Feet);
        txtExit_Flow_Rate_CFM_PrepStation.Text = clsGeneral.GetStringValue(objPM_Equipment_Prep_Station.Exit_Flow_Rate_CFM);
        txtExit_Temperature_Low_PrepStation.Text = clsGeneral.GetStringValue(objPM_Equipment_Prep_Station.Exit_Temperature_Low);
        txtExit_Temperature_High_PrepStation.Text = clsGeneral.GetStringValue(objPM_Equipment_Prep_Station.Exit_Temperature_High);
        txtPrepStationNotes.Text = objPM_Equipment_Prep_Station.Notes;
        if (objPM_Equipment_Prep_Station.Manual_6H_Binder != null)
            rdbManual6HBinder_PrepStation.SelectedValue = objPM_Equipment_Prep_Station.Manual_6H_Binder;
        else
            rdbManual6HBinder_PrepStation.SelectedValue = "Y";
        txtCaptureEfficiencyDate_PrepStation.Text = clsGeneral.FormatDBNullDateToDisplay(objPM_Equipment_Prep_Station.Capture_Efficieicny_Date);
        txtControlEfficiencyDate_PrepStation.Text = clsGeneral.FormatDBNullDateToDisplay(objPM_Equipment_Prep_Station.Control_Efficiency_Date);

        //AttachDetailsPrepStation.InitializeAttachmentDetails(clsGeneral.Pollution_Tables.PM_Equipment_Attachments, Convert.ToInt32(PK_PM_Equipment_Prep_Station), "FK_Table_Name", "PK_PM_Equipment_Attachments", true, 2);
        //BindSprayBoothAttachmentDetaills();
        AttachDetails.Equipment_Table_Name = "PM_Equipment_Prep_Station";
        AttachDetails.InitializeAttachmentDetails(clsGeneral.Pollution_Tables.PM_Equipment_Attachments, Convert.ToInt32(PK_PM_Equipment_Prep_Station), "FK_Table_Name", "PK_PM_Equipment_Attachments", true, 2);
        BindPrepStationAttachmentDetaills();
    }
    /// <summary>
    /// Bind Prep Station Page Controls for view mode
    /// </summary>
    private void BindDetailsFor_Equipment_Prep_Station_View()
    {
        dvView.Visible = true;
        dvEdit.Visible = false;
        pnlTankview.Style["display"] = "none";
        pnlPrepStationTypeview.Style["display"] = "block";
        pnlOWSTypeview.Style["display"] = "none";
        pnlHydraulicLiftTypeview.Style["display"] = "none";
        pnlPGCCview.Style["display"] = "none";
        clsPM_Equipment_Prep_Station objPM_Equipment_Prep_Station = new clsPM_Equipment_Prep_Station(PK_PM_Equipment_Prep_Station);
        lblPrepStationType.Text = "Paint Booth";
        lblPrepStationDescription.Text = objPM_Equipment_Prep_Station.Description;
        lblManufacturer_Name_PrepStation.Text = objPM_Equipment_Prep_Station.Manufacturer_Name;
        lblInstallationDate_PrepStation.Text = clsGeneral.FormatDBNullDateToDisplay(objPM_Equipment_Prep_Station.Installation_Date);
        lblConfigured_For_Water_Borne_Application_PrepStation.Text = objPM_Equipment_Prep_Station.Configured_For_Water_Borne_Application == "Y" ? "Yes" : "No";
        lblDirect_Indirect_Burners_PrepStation.Text = objPM_Equipment_Prep_Station.Direct_Indirect_Burners == "D" ? "Direct" : "Indirect";
        lblBTU_Rating_PrepStation.Text = clsGeneral.GetStringValue(objPM_Equipment_Prep_Station.BTU_Rating);
        lblHeight_In_Feet_PrepStation.Text = clsGeneral.GetStringValue(objPM_Equipment_Prep_Station.Height_In_Feet);
        lblWidth_In_Feet_PrepStation.Text = clsGeneral.GetStringValue(objPM_Equipment_Prep_Station.Width_In_Feet);
        lblDepth_In_Feet_PrepStation.Text = clsGeneral.GetStringValue(objPM_Equipment_Prep_Station.Depth_In_Feet);
        lblFilter_System_PrepStation.Text = objPM_Equipment_Prep_Station.Filter_System;
        lblCapture_Efficiency_PrepStation.Text = clsGeneral.GetStringValue(objPM_Equipment_Prep_Station.Capture_Efficiency);
        lblControl_Efficiency_PrepStation.Text = clsGeneral.GetStringValue(objPM_Equipment_Prep_Station.Control_Efficiency);
        lblStack_Height_In_Feet_PrepStation.Text = clsGeneral.GetStringValue(objPM_Equipment_Prep_Station.Stack_Height_In_Feet);
        lblExit_Flow_Rate_CFM_PrepStation.Text = clsGeneral.GetStringValue(objPM_Equipment_Prep_Station.Exit_Flow_Rate_CFM);
        lblExit_Temperature_Low_PrepStation.Text = clsGeneral.GetStringValue(objPM_Equipment_Prep_Station.Exit_Temperature_Low);
        lblExit_Temperature_High_PrepStation.Text = clsGeneral.GetStringValue(objPM_Equipment_Prep_Station.Exit_Temperature_High);
        lblPrepStationNotes.Text = objPM_Equipment_Prep_Station.Notes;
        lblManual6HBinder_PrepStation.Text = objPM_Equipment_Prep_Station.Manual_6H_Binder == "N" ? "No" : "Yes";
        lblCapture_EfficiencyDate_PrepStation.Text = clsGeneral.FormatDBNullDateToDisplay(objPM_Equipment_Prep_Station.Capture_Efficieicny_Date);
        lblControl_EfficiencyDate_PrepStation.Text = clsGeneral.FormatDBNullDateToDisplay(objPM_Equipment_Prep_Station.Control_Efficiency_Date);

        //SprayBoothAttachDetailsView.InitializeAttachmentDetails(clsGeneral.Pollution_Tables.PM_Equipment_Attachments, Convert.ToInt32(PK_PM_Equipment_Prep_Station), "FK_Table_Name", "PK_PM_Equipment_Attachments", false, 2);
        //BindSprayBoothAttachmentDetaills();
        AttachDetailsView.Equipment_Table_Name = "PM_Equipment_Prep_Station";
        AttachDetailsView.InitializeAttachmentDetails(clsGeneral.Pollution_Tables.PM_Equipment_Attachments, Convert.ToInt32(PK_PM_Equipment_Prep_Station), "FK_Table_Name", "PK_PM_Equipment_Attachments", false, 2);
        BindPrepStationAttachmentDetaills();
    }
    /// <summary>
    /// Bind Hydraulic_Lift Page Controls for edit mode
    /// </summary>
    private void BindDetailsFor_Equipment_Hydraulic_Lift_Edit()
    {
        RackLiftAsPerEventType();
        dvView.Visible = false;
        dvEdit.Visible = true;
        pnl1.Style["display"] = "block";

        pnlTank.Visible = false;
        pnlSprayBooth.Visible = false;
        pnlOWS.Visible = false;
        pnlHydraulicLiftType.Visible = true;
        pnlPGCC.Visible = false;

        clsPM_Equipment_Hydraulic_Lift objPM_Equipment_Hydraulic_Lift = new clsPM_Equipment_Hydraulic_Lift(PK_PM_Equipment_Hydraulic_Lift);
        if (objPM_Equipment_Hydraulic_Lift.PK_PM_Equipment != null)
            PM_Equipment = (decimal)objPM_Equipment_Hydraulic_Lift.PK_PM_Equipment;
        //lblHydraulicLiftType.Text = "Hydraulic Lift";
        //txtHydraulicLiftDescription.Text = objPM_Equipment_Hydraulic_Lift.Description;
        //txtOil_Type.Text = objPM_Equipment_Hydraulic_Lift.Oil_Type;
        //if (objPM_Equipment_Hydraulic_Lift.Above_Ground != null)
        //    rdoAbove_Ground.SelectedValue = objPM_Equipment_Hydraulic_Lift.Above_Ground;
        //else
        //    rdoAbove_Ground.SelectedValue = "Y";
        //txtHydraulicLiftManufacture.Text = objPM_Equipment_Hydraulic_Lift.Manufacturer_Name;
        ////txtIs_Number_Of_Lifts_At_Location.Text = Convert.ToString(objPM_Equipment_Hydraulic_Lift.Is_Number_Of_Lifts_At_Location);
        //txtNumber_Of_Lifts_At_Location.Text = Convert.ToString(objPM_Equipment_Hydraulic_Lift.Number_Of_Lifts_At_Location);
        //txtAs_Of_Date_Number.Text = clsGeneral.FormatDBNullDateToDisplay(objPM_Equipment_Hydraulic_Lift.As_Of_Date_Number);
        //txtHydraulicLift_Installation_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objPM_Equipment_Hydraulic_Lift.Installation_Date);
        //txtHydraulicLift_Last_Inspection_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objPM_Equipment_Hydraulic_Lift.Last_Inspection_Date);
        //if (objPM_Equipment_Hydraulic_Lift.Any_Inground_Lifts_Been_Removed != null)
        //    rdoAny_Inground_Lifts_Been_Removed.SelectedValue = objPM_Equipment_Hydraulic_Lift.Any_Inground_Lifts_Been_Removed;
        //else
        //    rdoAny_Inground_Lifts_Been_Removed.SelectedValue = "Y";
        if (objPM_Equipment_Hydraulic_Lift.Use_Same_Dates != null)
            rdbUseSameDates.SelectedValue = objPM_Equipment_Hydraulic_Lift.Use_Same_Dates;
        else
            rdbUseSameDates.SelectedValue = "N";
        //if (objPM_Equipment_Hydraulic_Lift.Documentation_Related_To_Removed_Lifts != null)
        //    rdoDocumentation_Related_To_Removed_Lifts.SelectedValue = objPM_Equipment_Hydraulic_Lift.Documentation_Related_To_Removed_Lifts;
        //else
        //    rdoDocumentation_Related_To_Removed_Lifts.SelectedValue = "Y";
        BindHydraulicLiftGrid(PK_PM_Equipment_Hydraulic_Lift);
        //txtHydraulicLiftNotes.Text = objPM_Equipment_Hydraulic_Lift.Notes;
        // set attachment details control in read/write mode. so user can add or remove attachment as well.
        AttachDetails.Equipment_Table_Name = "PM_Equipment_Hydraulic_Lift";
        AttachDetails.InitializeAttachmentDetails(clsGeneral.Pollution_Tables.PM_Equipment_Attachments, Convert.ToInt32(PK_PM_Equipment_Hydraulic_Lift), "FK_Table_Name", "PK_PM_Equipment_Attachments", true, 2);
        BindHydraulicLiftAttachmentDetaills();
    }
    /// <summary>
    /// Bind Hydraulic_Lift Page Controls for view mode
    /// </summary>
    private void BindDetailsFor_Equipment_Hydraulic_Lift_View()
    {
        RackLiftAsPerEventType();
        dvView.Visible = true;
        dvEdit.Visible = false;
        pnlTankview.Style["display"] = "none";
        pnlSprayBoothTypeview.Style["display"] = "none";
        pnlOWSTypeview.Style["display"] = "none";
        pnlHydraulicLiftTypeview.Style["display"] = "block";
        pnlPGCCview.Style["display"] = "none";
        clsPM_Equipment_Hydraulic_Lift objPM_Equipment_Hydraulic_Lift = new clsPM_Equipment_Hydraulic_Lift(PK_PM_Equipment_Hydraulic_Lift);
        lblUse_Same_Dates.Text = objPM_Equipment_Hydraulic_Lift.Use_Same_Dates == "Y" ? "Yes" : "No";
        //lblAny_Inground_Lifts_Been_Removed.Text = objPM_Equipment_Hydraulic_Lift.Any_Inground_Lifts_Been_Removed == "Y" ? "Yes" : "No";
        //lblDocumentation_Related_To_Removed_Lifts.Text = objPM_Equipment_Hydraulic_Lift.Documentation_Related_To_Removed_Lifts == "Y" ? "Yes" : "No";
        BindHydraulicLiftGridView(PK_PM_Equipment_Hydraulic_Lift);
        AttachDetailsView.Equipment_Table_Name = "PM_Equipment_Hydraulic_Lift";
        AttachDetailsView.InitializeAttachmentDetails(clsGeneral.Pollution_Tables.PM_Equipment_Attachments, Convert.ToInt32(PK_PM_Equipment_Hydraulic_Lift), "FK_Table_Name", "PK_PM_Equipment_Attachments", false, 2);
        BindHydraulicLiftAttachmentDetaills();
    }
    /// <summary>
    /// Bind PGCC Page Controls for edit mode
    /// </summary>
    private void BindDetailsFor_Equipment_PGCC_Edit()
    {
        dvView.Visible = false;
        dvEdit.Visible = true;
        pnl1.Style["display"] = "block";


        pnlTank.Visible = false;
        pnlSprayBooth.Visible = false;
        pnlOWS.Visible = false;
        pnlHydraulicLiftType.Visible = false;
        pnlPGCC.Visible = true;

        clsPM_Equipment_PGCC objPM_Equipment_PGCC = new clsPM_Equipment_PGCC(PK_PM_Equipment_PGCC);
        if (objPM_Equipment_PGCC.PK_PM_Equipment != null)
            PM_Equipment = (decimal)objPM_Equipment_PGCC.PK_PM_Equipment;
        //lblPGCCType.Text = "Paint Gun Cleaning Cabinet";
        txtPGCCDescription.Text = objPM_Equipment_PGCC.Description;
        txtPGCCManufacturer.Text = objPM_Equipment_PGCC.Manufacturer_Name;
        txtPGCCInstallation_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objPM_Equipment_PGCC.Installation_Date);
        if (objPM_Equipment_PGCC.Water_Borne != null)
            rdoWater_Borne.SelectedValue = objPM_Equipment_PGCC.Water_Borne;
        else
            rdoWater_Borne.SelectedValue = "Y";
        if (objPM_Equipment_PGCC.Solvent_Based != null)
            rdoSolvent_Based.SelectedValue = objPM_Equipment_PGCC.Solvent_Based;
        else
            rdoSolvent_Based.SelectedValue = "Y";
        if (objPM_Equipment_PGCC.Combination_Water_Solvent != null)
            rdoCombination_Water_Solvent.SelectedValue = objPM_Equipment_PGCC.Combination_Water_Solvent;
        else
            rdoCombination_Water_Solvent.SelectedValue = "Y";
        txtPGCCNotes.Text = objPM_Equipment_PGCC.Notes;

        if (objPM_Equipment_PGCC.SixH_Compliant != null)
            rdbIsCabinet6HComplaint.SelectedValue = objPM_Equipment_PGCC.SixH_Compliant;
        else
            rdbIsCabinet6HComplaint.SelectedValue = "Y";

        if (objPM_Equipment_PGCC.Manual_6H_Binder != null)
            rdbManualPaintGunCleaningCabinet6H.SelectedValue = objPM_Equipment_PGCC.Manual_6H_Binder;
        else
            rdbManualPaintGunCleaningCabinet6H.SelectedValue = "Y";

        // set attachment details control in read/write mode. so user can add or remove attachment as well.
        AttachDetails.Equipment_Table_Name = "PM_Equipment_PGCC";
        AttachDetails.InitializeAttachmentDetails(clsGeneral.Pollution_Tables.PM_Equipment_Attachments, Convert.ToInt32(PK_PM_Equipment_PGCC), "FK_Table_Name", "PK_PM_Equipment_Attachments", true, 2);
        BindPGCCAttachmentDetaills();
    }
    /// <summary>
    /// Bind PGCC Page Controls for view mode
    /// </summary>
    private void BindDetailsFor_Equipment_PGCC_View()
    {
        dvView.Visible = true;
        dvEdit.Visible = false;
        pnlTankview.Style["display"] = "none";
        pnlSprayBoothTypeview.Style["display"] = "none";
        pnlOWSTypeview.Style["display"] = "none";
        pnlHydraulicLiftTypeview.Style["display"] = "none";
        pnlPGCCview.Style["display"] = "block";
        clsPM_Equipment_PGCC objPM_Equipment_PGCC = new clsPM_Equipment_PGCC(PK_PM_Equipment_PGCC);
        lblPGCCTypeView.Text = "Paint Gun Cleaning Cabinet";
        lblPGCCTypeDescription.Text = objPM_Equipment_PGCC.Description;
        lblPGCCTypeManufacturer.Text = objPM_Equipment_PGCC.Manufacturer_Name;
        lblPGCCTypeInstallationDate.Text = clsGeneral.FormatDBNullDateToDisplay(objPM_Equipment_PGCC.Installation_Date);
        lblWater_Borne.Text = objPM_Equipment_PGCC.Water_Borne == "Y" ? "Yes" : "No";
        lblSolvent_Based.Text = objPM_Equipment_PGCC.Solvent_Based == "Y" ? "Yes" : "No";
        lblCombination_Water_Solvent.Text = objPM_Equipment_PGCC.Combination_Water_Solvent == "Y" ? "Yes" : "No";
        lblPGCCTypeNotes.Text = objPM_Equipment_PGCC.Notes;

        lblIsCabinet6HComplaint.Text = objPM_Equipment_PGCC.SixH_Compliant == "N" ? "No" : "Yes";
        lblManualPaintGunCleaningCabinet6H.Text = objPM_Equipment_PGCC.Manual_6H_Binder == "N" ? "No" : "Yes";

        //PGCCAttachDetailsView.InitializeAttachmentDetails(clsGeneral.Pollution_Tables.PM_Equipment_Attachments, Convert.ToInt32(PK_PM_Equipment_PGCC), "FK_Table_Name", "PK_PM_Equipment_Attachments", false, 2);
        //BindPGCCAttachmentDetaills();
        AttachDetailsView.Equipment_Table_Name = "PM_Equipment_PGCC";
        AttachDetailsView.InitializeAttachmentDetails(clsGeneral.Pollution_Tables.PM_Equipment_Attachments, Convert.ToInt32(PK_PM_Equipment_PGCC), "FK_Table_Name", "PK_PM_Equipment_Attachments", false, 2);
        BindPGCCAttachmentDetaills();
    }
    /// <summary>
    /// Bind OWS Page Controls for Edit Mode
    /// </summary>
    private void BindDetailsFor_Equipment_OWS_Edit()
    {
        dvView.Visible = false;
        dvEdit.Visible = true;
        pnl1.Style["display"] = "block";


        pnlTank.Visible = false;
        pnlSprayBooth.Visible = false;
        pnlOWS.Visible = true;
        pnlHydraulicLiftType.Visible = false;
        pnlPGCC.Visible = false;

        clsPM_Equipment_OWS objPM_Equipment_OWS = new clsPM_Equipment_OWS(PK_PM_Equipment_OWS);
        if (objPM_Equipment_OWS.PK_PM_Equipment != null)
            PM_Equipment = (decimal)objPM_Equipment_OWS.PK_PM_Equipment;
        //lblOWS.Text = "Oil and Water Separator";
        txtOWSDescription.Text = objPM_Equipment_OWS.Description;
        txtOWS_Installation_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objPM_Equipment_OWS.Installation_Date);
        txtOWSManufacturer_Name.Text = objPM_Equipment_OWS.Manufacturer_Name;
        txtOWSInspectionCompany.Text = objPM_Equipment_OWS.Inspection_Company;
        txtInspectionCompanyContactName.Text = objPM_Equipment_OWS.Inspection_Company_Contact_Name;
        txtOWSTelephone.Text = objPM_Equipment_OWS.Inspection_Company_Contact_Telephone;
        txtOWSNotes.Text = objPM_Equipment_OWS.Notes;
        if (objPM_Equipment_OWS.Connected_to_Public_Water_Application != null)
            rdOWSConnectedtoPublicWater.SelectedValue = objPM_Equipment_OWS.Connected_to_Public_Water_Application;
        else
            rdOWSConnectedtoPublicWater.SelectedValue = "Y";
        BindSludgeGrid(PK_PM_Equipment_OWS);
        //AttachDetailsOWS.InitializeAttachmentDetails(clsGeneral.Pollution_Tables.PM_Equipment_Attachments, Convert.ToInt32(PK_PM_Equipment_OWS), "FK_Table_Name", "PK_PM_Equipment_Attachments", true, 2);
        //BindOWSAttachmentDetaills();
        AttachDetails.Equipment_Table_Name = "PM_Equipment_OWS";
        AttachDetails.InitializeAttachmentDetails(clsGeneral.Pollution_Tables.PM_Equipment_Attachments, Convert.ToInt32(PK_PM_Equipment_OWS), "FK_Table_Name", "PK_PM_Equipment_Attachments", true, 2);
        BindOWSAttachmentDetaills();
    }
    /// <summary>
    /// Bind OWS Page Controls for view Mode
    /// </summary>
    private void BindDetailsFor_Equipment_OWS_View()
    {
        dvView.Visible = true;
        dvEdit.Visible = false;
        pnlTankview.Style["display"] = "none";
        pnlSprayBoothTypeview.Style["display"] = "none";
        pnlOWSTypeview.Style["display"] = "block";
        pnlHydraulicLiftTypeview.Style["display"] = "none";
        pnlPGCCview.Style["display"] = "none";

        clsPM_Equipment_OWS objPM_Equipment_OWS = new clsPM_Equipment_OWS(PK_PM_Equipment_OWS);
        lblOWSType.Text = "Oil and Water Separator";
        lblOWSDescription.Text = objPM_Equipment_OWS.Description;
        lblOWS_Installation_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objPM_Equipment_OWS.Installation_Date);
        lblOWSManufacturer.Text = objPM_Equipment_OWS.Manufacturer_Name;
        lblOWSInspection.Text = objPM_Equipment_OWS.Inspection_Company;
        lblOWSInspectionCompanyContactName.Text = objPM_Equipment_OWS.Inspection_Company_Contact_Name;
        lblOWSContactTelephone.Text = objPM_Equipment_OWS.Inspection_Company_Contact_Telephone;
        lblOWSNotes.Text = objPM_Equipment_OWS.Notes;
        lblConnectedtoPublicWater.Text = objPM_Equipment_OWS.Connected_to_Public_Water_Application == "Y" ? "Yes" : "No";
        BindSludgeGridView(PK_PM_Equipment_OWS);
        //OWSAttachDetailsView.InitializeAttachmentDetails(clsGeneral.Pollution_Tables.PM_Equipment_Attachments, Convert.ToInt32(PK_PM_Equipment_OWS), "FK_Table_Name", "PK_PM_Equipment_Attachments", false, 2);
        //BindOWSAttachmentDetaills();
        AttachDetailsView.Equipment_Table_Name = "PM_Equipment_OWS";
        AttachDetailsView.InitializeAttachmentDetails(clsGeneral.Pollution_Tables.PM_Equipment_Attachments, Convert.ToInt32(PK_PM_Equipment_OWS), "FK_Table_Name", "PK_PM_Equipment_Attachments", false, 2);
        BindOWSAttachmentDetaills();
    }
    /// <summary>
    /// Save OWS Data
    /// </summary>
    private void SaveOWSData()
    {
        clsPM_Equipment objPM_Equipment = new clsPM_Equipment();
        objPM_Equipment.PK_PM_Equipment = PM_Equipment;
        objPM_Equipment.FK_PM_Site_Information = FK_PM_Site_Information;
        if (drpEquipmentType.SelectedIndex > 0) objPM_Equipment.FK_LU_Equipment_Type = Convert.ToDecimal(drpEquipmentType.SelectedValue);
        objPM_Equipment.FK_Table_Name = 0;
        objPM_Equipment.Table_Name = "PM_Equipment_OWS";
        PK_PM_Equipment_OWS = objPM_Equipment.InsertUpdate();

        clsPM_Equipment_OWS objPM_Equipment_OWS = new clsPM_Equipment_OWS(PK_PM_Equipment_OWS);
        if (objPM_Equipment_OWS.PK_PM_Equipment != null)
            PM_Equipment = (decimal)objPM_Equipment_OWS.PK_PM_Equipment;
        objPM_Equipment_OWS.PK_PM_Equipment_OWS = PK_PM_Equipment_OWS;
        objPM_Equipment_OWS.Connected_to_Public_Water_Application = rdOWSConnectedtoPublicWater.SelectedValue;
        objPM_Equipment_OWS.Description = txtOWSDescription.Text.Trim();
        objPM_Equipment_OWS.Installation_Date = clsGeneral.FormatNullDateToStore(txtOWS_Installation_Date.Text);
        objPM_Equipment_OWS.Manufacturer_Name = txtOWSManufacturer_Name.Text.Trim();
        objPM_Equipment_OWS.Inspection_Company = txtOWSInspectionCompany.Text.Trim();
        objPM_Equipment_OWS.Inspection_Company_Contact_Name = txtInspectionCompanyContactName.Text.Trim();
        objPM_Equipment_OWS.Inspection_Company_Contact_Telephone = txtOWSTelephone.Text.Trim();
        objPM_Equipment_OWS.Notes = txtOWSNotes.Text.Trim();
        objPM_Equipment_OWS.Update_Date = DateTime.Now;
        objPM_Equipment_OWS.Updated_By = clsSession.UserID;
        if (PK_PM_Equipment_OWS > 0)
            objPM_Equipment_OWS.Update();
    }
    /// <summary>
    /// Save OWS Data
    /// </summary>
    private void SaveHydraulicLiftData()
    {
        clsPM_Equipment objPM_Equipment = new clsPM_Equipment();
        objPM_Equipment.PK_PM_Equipment = PM_Equipment;
        objPM_Equipment.FK_PM_Site_Information = FK_PM_Site_Information;
        if (drpEquipmentType.SelectedIndex > 0) objPM_Equipment.FK_LU_Equipment_Type = Convert.ToDecimal(drpEquipmentType.SelectedValue);
        objPM_Equipment.FK_Table_Name = 0;
        objPM_Equipment.Table_Name = "PM_Equipment_Hydraulic_Lift";
        PK_PM_Equipment_Hydraulic_Lift = objPM_Equipment.InsertUpdate();

        clsPM_Equipment_Hydraulic_Lift objPM_Equipment_Hydraulic_Lift = new clsPM_Equipment_Hydraulic_Lift(PK_PM_Equipment_Hydraulic_Lift);
        if (objPM_Equipment_Hydraulic_Lift.PK_PM_Equipment != null)
            PM_Equipment = (decimal)objPM_Equipment_Hydraulic_Lift.PK_PM_Equipment;

        objPM_Equipment_Hydraulic_Lift.PK_PM_Equipment_Hydraulic_Lift = PK_PM_Equipment_Hydraulic_Lift;
        //objPM_Equipment_Hydraulic_Lift.Any_Inground_Lifts_Been_Removed = rdoAny_Inground_Lifts_Been_Removed.SelectedValue;
        //objPM_Equipment_Hydraulic_Lift.Documentation_Related_To_Removed_Lifts = rdoDocumentation_Related_To_Removed_Lifts.SelectedValue;
        objPM_Equipment_Hydraulic_Lift.Update_Date = DateTime.Now;
        objPM_Equipment_Hydraulic_Lift.Updated_By = clsSession.UserID;
        objPM_Equipment_Hydraulic_Lift.Use_Same_Dates = Convert.ToString(rdbUseSameDates.SelectedValue);
        if (PK_PM_Equipment_Hydraulic_Lift > 0)
            objPM_Equipment_Hydraulic_Lift.Update();
    }

    private void GetUse_Same_Dates()
    {
        if (rdbUseSameDates.SelectedValue == "Y")
        {
            bool type = false;
            if (StrOperation.ToLower() == "edit")
                type = true;
            DataSet dsUseSameDates = clsPM_Equipment_Hydraulic_Lift_Grid.Select_UseSameDates_ByFK(PK_PM_Equipment_Hydraulic_Lift, type);
            if (dsUseSameDates != null && dsUseSameDates.Tables.Count > 0 && dsUseSameDates.Tables[0].Rows.Count > 0)
            {                
                txtHydraulicLift_Installation_Date.Text = clsGeneral.FormatDBNullDateToDisplay(dsUseSameDates.Tables[0].Rows[0]["Installation_Date"]);
                txtHydraulicLift_Last_Inspection_Date.Text = clsGeneral.FormatDBNullDateToDisplay(dsUseSameDates.Tables[0].Rows[0]["Last_Inspection_Date"]);
            }
        }
    }

    //Select Lift as Label name where Equpment Type is Hydraulick Lift
    private void Lift()
    {
        spnDocumentation.InnerText = spnInGroundLifts.InnerText = "Lifts";
        spnInstalledLift.InnerText = spLiftNumber.InnerText = spLiftNumberAsOfDate.InnerText = "Lifts";
        spnInstalledLift2.InnerText = "Lifts";
        spnReplacementLiftInformation.InnerText = spnReplacementLiftRack.InnerText = "Lift";
        spnLiftGrid.InnerText = "Hydraulic Lift";
        spnEquipmentTypeScreen.InnerText = "Hydraulic Lift - Hydraulic Lift";

        spnvwDocumentation.InnerText = spnvwInGround.InnerText = "Lifts";
        spnvwFirstInstalled.InnerText = spvwLiftNumber.InnerText = spvwLiftNumberAsOfDate.InnerText = "Lifts";
        spnvwFirstInstalled2.InnerText = "Lifts";
        spnvwEquipmentTypeScreen.InnerText = "Hydraulic Lift - Hydraulic Lift";
        spnvwHydraulicLiftGrid.InnerText = "Hydraulic Lift";
        spnvwReplacementLift.InnerText = spnvwReplacementLiftInformation.InnerText = "Lift";

        lblEquipmentHydraulicLift.Text = "Hydraulic Lift";
    }

    //Select Rack as Label name where Equpment Type is Alignment Rack
    private void Rack()
    {
        spnDocumentation.InnerText = spnInGroundLifts.InnerText = "Racks";
        spnInstalledLift.InnerText = spLiftNumber.InnerText = spLiftNumberAsOfDate.InnerText = "Racks";
        spnInstalledLift2.InnerText = "Racks";
        spnReplacementLiftInformation.InnerText = spnReplacementLiftRack.InnerText = "Rack";
        spnLiftGrid.InnerText = "Alignment Rack";
        spnEquipmentTypeScreen.InnerText = "Alignment Rack - Alignment Rack";

        spnvwDocumentation.InnerText = spnvwInGround.InnerText = "Racks";
        spnvwFirstInstalled.InnerText = spvwLiftNumber.InnerText = spvwLiftNumberAsOfDate.InnerText = "Racks";
        spnvwFirstInstalled2.InnerText = "Racks";
        spnvwEquipmentTypeScreen.InnerText = "Aligment Rack - Aligment Rack";
        spnvwHydraulicLiftGrid.InnerText = "Alignment Rack";
        spnvwReplacementLift.InnerText = spnvwReplacementLiftInformation.InnerText = "Rack";

        lblEquipmentHydraulicLift.Text = "Aligment Rack";
    }

    //Set Header name of Grid as Lift  where Equpment Type is Hydraulick Lift
    private void LiftGrid()
    {
        gvHydraulicLiftView.Columns[0].HeaderText = "Lift";
        gvHydraulicLift.Columns[0].HeaderText = "Lift";
        BindHydraulicLiftGridView(PK_PM_Equipment_Hydraulic_Lift);
        BindHydraulicLiftGrid(PK_PM_Equipment_Hydraulic_Lift);
    }

    //Set Header name of Grid as Rack  where Equpment Type is Hydraulick Lift
    private void RackGrid()
    {
        gvHydraulicLiftView.Columns[0].HeaderText = "Rack";
        gvHydraulicLift.Columns[0].HeaderText = "Rack";
        BindHydraulicLiftGridView(PK_PM_Equipment_Hydraulic_Lift);
        BindHydraulicLiftGrid(PK_PM_Equipment_Hydraulic_Lift);
    }

    //Call Methods Related to Label Change as where DropDown Selection
    private void RackLiftAsPerEventType()
    {
        int FK_LU_Equipment_Type = clsPM_Equipment_Hydraulic_Lift.RackLiftSelectByPk(PK_PM_Equipment_Hydraulic_Lift);
        if (FK_LU_Equipment_Type == 10)
        {
            Rack();
            RackGrid();
        }
        else
        {
            Lift();
            LiftGrid();
        }
    }

    //Set Replacement Lift Information as per Radio button Selection
    private void ShowHideReplacementLiftInformation()
    {
        if (rdoInGroundLifts.SelectedValue == "Y")
        {
            txtReplacementLiftDescription.Enabled = true;
            txtReplacementOilType.Enabled = true;
            txtManufacturer.Enabled = true;
            txtReplacementInstallationDate.Enabled = true;
            txtReplacementLastAnnualInspectionDate.Enabled = true;
            txtReplacementNotes.Enabled = true;
            rdoAboveGround.Enabled = true;
            txtHydraulicLift_Removal_Date.Enabled = true;
            //txtHydraulicLiftNotes.Enabled = true;
            imgInstallationDate1.Visible = true;
            imgLastAnnualInspectionDate1.Visible = true;
            imgHydraulicLift_Removal_Date.Visible = true;
        }
        else
        {
            txtReplacementLiftDescription.Enabled = false;
            txtReplacementOilType.Enabled = false;
            txtManufacturer.Enabled = false;
            txtReplacementInstallationDate.Enabled = false;
            txtReplacementLastAnnualInspectionDate.Enabled = false;
            txtReplacementNotes.Enabled = false;
            rdoAboveGround.Enabled = false;
            txtHydraulicLift_Removal_Date.Enabled = false;
            //txtHydraulicLiftNotes.Enabled = false;
            imgInstallationDate1.Visible = false;
            imgLastAnnualInspectionDate1.Visible = false;
            imgHydraulicLift_Removal_Date.Visible = false;
        }
    }

    #endregion

    #region Control Events
    /// <summary>
    /// Handle Region Dropdown Selected index Change events
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void drpEquipmentType_SelectedIndexChanged(object sender, EventArgs e)
    {
        hdnControlIDsTank.Value = ""; hdnErrorMsgsTank.Value = "";
        hdnControlIDsSprayBooth.Value = ""; hdnErrorMsgsSprayBooth.Value = "";
        hdnControlIDsOWS.Value = ""; hdnErrorMsgsOWS.Value = "";
        hdnControlIDsOWSInnerGrid.Value = ""; hdnErrorMsgsOWSInnerGrid.Value = "";
        hdnControlIDsHydraulicLiftGrid.Value = ""; hdnErrorMsgsHydraulicLiftGrid.Value = "";
        hdnControlIDsPGCC.Value = ""; hdnErrorMsgsPGCC.Value = "";

        //Equiptment type 'Tank' is selected then show and hide Panel
        if (drpEquipmentType.SelectedItem.ToString().ToLower().Trim() == "tank")
        {
            SetValidationsTank();
            dvView.Visible = false;
            dvEdit.Visible = true;
            pnl1.Style["display"] = "block";
            pnlTank.Visible = true;
            pnlPrepStation.Visible = false;
            pnlSprayBooth.Visible = false;
            pnlOWS.Visible = false;
            pnlHydraulicLiftType.Visible = false;
            pnlPGCC.Visible = false;
            //lblEquiptmentType.Text = drpEquipmentType.SelectedItem.Text.ToString();
            txtTankManufacture.Focus();
            //If Edit Mode then Attachement Detail Bind in PK_PM_Equipment_Tank ID wise otherwise other ID is selected then no data display
            if (PK_PM_Equipment_Tank > 0)
            {
                AttachDetails.Equipment_Table_Name = "PM_Equipment_Tank";
                AttachDetails.InitializeAttachmentDetails(clsGeneral.Pollution_Tables.PM_Equipment_Attachments, Convert.ToInt32(PK_PM_Equipment_Tank), "FK_Table_Name", "PK_PM_Equipment_Attachments", true, 2);
                BindTankAttachmentDetaills();
            }
            else
            {
                AttachDetails.FindControl("gvAttachment").DataBind();
                AttachDetails.FindControl("btnMail").Visible = false;
                AttachDetails.FindControl("btnRemoveAttachment").Visible = false;
            }
        }
        //Equiptment type 'Paint Booth' is selected then show and hide Panel
        else if (drpEquipmentType.SelectedItem.ToString().ToLower().Trim() == "paint booth")
        {
            SetValidationsPaintBooth();
            dvView.Visible = false;
            dvEdit.Visible = true;
            pnl1.Style["display"] = "block";
            pnlTank.Visible = false;
            pnlSprayBooth.Visible = true;
            pnlPrepStation.Visible = false;
            pnlOWS.Visible = false;
            pnlHydraulicLiftType.Visible = false;
            pnlPGCC.Visible = false;
            // lblEquiptmentSprayBooth.Text = drpEquipmentType.SelectedItem.Text.ToString();
            txtSprayBoothDesc.Focus();
            if (PK_PM_Equipment_Spray_Booth > 0)
            {
                AttachDetails.Equipment_Table_Name = "PM_Equipment_Spray_Booth";
                AttachDetails.InitializeAttachmentDetails(clsGeneral.Pollution_Tables.PM_Equipment_Attachments, Convert.ToInt32(PK_PM_Equipment_Spray_Booth), "FK_Table_Name", "PK_PM_Equipment_Attachments", true, 2);
                BindSprayBoothAttachmentDetaills();
            }
            else
            {
                AttachDetails.FindControl("gvAttachment").DataBind();
                AttachDetails.FindControl("btnMail").Visible = false;
                AttachDetails.FindControl("btnRemoveAttachment").Visible = false;
            }
        }
        //Equiptment type 'Prep Station' is selected then show and hide Panel
        else if (drpEquipmentType.SelectedItem.ToString().ToLower().Trim() == "prep station")
        {
            SetValidationsPrepStation();
            dvView.Visible = false;
            dvEdit.Visible = true;
            pnl1.Style["display"] = "block";
            pnlTank.Visible = false;
            pnlSprayBooth.Visible = false;
            pnlPrepStation.Visible = true;
            pnlOWS.Visible = false;
            pnlHydraulicLiftType.Visible = false;
            pnlPGCC.Visible = false;
            // lblEquiptmentSprayBooth.Text = drpEquipmentType.SelectedItem.Text.ToString();
            txtPrepStationDesc.Focus();
            if (PK_PM_Equipment_Prep_Station > 0)
            {
                AttachDetails.Equipment_Table_Name = "PM_Equipment_Prep_Station";
                AttachDetails.InitializeAttachmentDetails(clsGeneral.Pollution_Tables.PM_Equipment_Attachments, Convert.ToInt32(PK_PM_Equipment_Prep_Station), "FK_Table_Name", "PK_PM_Equipment_Attachments", true, 2);
                BindPrepStationAttachmentDetaills();
            }
            else
            {
                AttachDetails.FindControl("gvAttachment").DataBind();
                AttachDetails.FindControl("btnMail").Visible = false;
                AttachDetails.FindControl("btnRemoveAttachment").Visible = false;
            }
        }
        //Equiptment type 'Oil and Water Separator' is selected then show and hide Panel
        else if (drpEquipmentType.SelectedItem.ToString().ToLower().Trim() == "oil and water separator")
        {
            SetValidationsOWS();
            dvView.Visible = false;
            dvEdit.Visible = true;
            pnl1.Style["display"] = "block";
            pnlTank.Visible = false;
            pnlSprayBooth.Visible = false;
            pnlPrepStation.Visible = false;
            pnlOWS.Visible = true;
            pnlHydraulicLiftType.Visible = false;
            pnlPGCC.Visible = false;
            //lblOWS.Text = drpEquipmentType.SelectedItem.Text.ToString();
            txtOWSDescription.Focus();
            if (PK_PM_Equipment_OWS > 0)
            {
                AttachDetails.Equipment_Table_Name = "PM_Equipment_OWS";
                AttachDetails.InitializeAttachmentDetails(clsGeneral.Pollution_Tables.PM_Equipment_Attachments, Convert.ToInt32(PK_PM_Equipment_OWS), "FK_Table_Name", "PK_PM_Equipment_Attachments", true, 2);
                BindOWSAttachmentDetaills();
            }
            else
            {
                AttachDetails.FindControl("gvAttachment").DataBind();
                AttachDetails.FindControl("btnMail").Visible = false;
                AttachDetails.FindControl("btnRemoveAttachment").Visible = false;
                BindSludgeGrid(PK_PM_Equipment_OWS);
            }
        }
        //Equiptment type 'Hydraulic Lift' is selected then show and hide Panel
        //Equiptment type 'Alignment Rack' is selected then show and hide Panel ticket #3142
        else if (drpEquipmentType.SelectedItem.ToString().ToLower().Trim() == "hydraulic lift" || drpEquipmentType.SelectedItem.ToString().ToLower().Trim() == "alignment rack")
        {
            if (drpEquipmentType.SelectedItem.ToString().ToLower().Trim() == "hydraulic lift")
            {
                Lift();
                LiftGrid();
            }
            else
            {
                Rack();
                RackGrid();
            }
            //RackLift();            
            SetValidationsHydraulic();
            dvView.Visible = false;
            dvEdit.Visible = true;
            pnl1.Style["display"] = "block";
            pnlTank.Visible = false;
            pnlSprayBooth.Visible = false;
            pnlPrepStation.Visible = false;
            pnlOWS.Visible = false;
            pnlHydraulicLiftType.Visible = true;
            pnlPGCC.Visible = false;
            //lblHydraulicLiftType.Text = drpEquipmentType.SelectedItem.Text.ToString();
            txtHydraulicLiftDescription.Focus();
            if (PK_PM_Equipment_Hydraulic_Lift > 0)
            {
                AttachDetails.Equipment_Table_Name = "PM_Equipment_Hydraulic_Lift";
                AttachDetails.InitializeAttachmentDetails(clsGeneral.Pollution_Tables.PM_Equipment_Attachments, Convert.ToInt32(PK_PM_Equipment_Hydraulic_Lift), "FK_Table_Name", "PK_PM_Equipment_Attachments", true, 2);
                BindHydraulicLiftAttachmentDetaills();
            }
            else
            {
                AttachDetails.FindControl("gvAttachment").DataBind();
                AttachDetails.FindControl("btnMail").Visible = false;
                AttachDetails.FindControl("btnRemoveAttachment").Visible = false;
            }
        }
        //Equiptment type 'Paint Gun Cleaning Cabinet' is selected then show and hide Panel
        else if (drpEquipmentType.SelectedItem.ToString().ToLower().Trim() == "paint gun cleaning cabinet")
        {
            SetValidationsPGCC();
            dvView.Visible = false;
            dvEdit.Visible = true;
            pnl1.Style["display"] = "block";
            pnlTank.Visible = false;
            pnlSprayBooth.Visible = false;
            pnlPrepStation.Visible = false;
            pnlOWS.Visible = false;
            pnlHydraulicLiftType.Visible = false;
            pnlPGCC.Visible = true;
            //lblPGCCType.Text = drpEquipmentType.SelectedItem.Text.ToString();
            txtPGCCDescription.Focus();
            if (PK_PM_Equipment_PGCC > 0)
            {
                AttachDetails.Equipment_Table_Name = "PM_Equipment_PGCC";
                AttachDetails.InitializeAttachmentDetails(clsGeneral.Pollution_Tables.PM_Equipment_Attachments, Convert.ToInt32(PK_PM_Equipment_PGCC), "FK_Table_Name", "PK_PM_Equipment_Attachments", true, 2);
                BindPGCCAttachmentDetaills();
            }
            else
            {
                AttachDetails.FindControl("gvAttachment").DataBind();
                AttachDetails.FindControl("btnMail").Visible = false;
                AttachDetails.FindControl("btnRemoveAttachment").Visible = false;
            }
        }
        //Equiptment type '--Select--' is selected then show and hide Panel
        else
        {
            dvView.Visible = false;
            dvEdit.Visible = true;
            pnl1.Style["display"] = "block";
            pnlTank.Visible = false;
            pnlSprayBooth.Visible = false;
            pnlPrepStation.Visible = false;
            pnlOWS.Visible = false;
            pnlHydraulicLiftType.Visible = false;
            pnlPGCC.Visible = false;
        }
        AuditTrailText = drpEquipmentType.SelectedItem.Text.ToString();
        Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(1);", true);
    }

    /// <summary>
    /// Handle Back Button Click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnBack_Click(object sender, EventArgs e)
    {
        if (StrOperation == "view")
            StrOperation = "view";
        else
            StrOperation = "edit";
        Response.Redirect("Pollution.aspx?op=" + StrOperation + "&id=" + Encryption.Encrypt(Convert.ToString(FK_PM_Site_Information)) + "&loc=" + Request.QueryString["loc"] + "&pnl=" + Encryption.Encrypt("4"));
    }

    /// <summary>
    /// Handles Add New Hazards Identification Button click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkAddSludgeRemovalDate_Click(object sender, EventArgs e)
    {
        SaveOWSData();
        PK_PM_Equipment_OWS_SR = 0;
        txtSludgeRemovalDate.Text = "";
        txtTCLPConductedDate.Text = "";
        rdbTCLPonFile.SelectedValue = "N";
        rdbTCLPPerformed.SelectedValue = "N";
        txtSludgeRemovedBy.Text = "";
        txtSludgeNotes.Text = "";
        pnlOWSDetail.Visible = false;
        pnlAddSludge.Visible = true;
        btnAuditSludge.Visible = false;
        tblEquipment.Style["display"] = "none";
        Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(1);displaySludge('none');", true);
    }
    /// <summary>
    /// Handles Add New Hazards Identification Button click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkAddHydraulicLift_Click(object sender, EventArgs e)
    {
        SetValidationsHydraulic();
        SaveHydraulicLiftData();
        BindHydraulicLiftGrid(PK_PM_Equipment_Hydraulic_Lift);
        PK_PM_Equipment_Hydraulic_Lift_Grid = 0;
        txtNumber_Of_Lifts_At_Location.Text = "";
        txtAs_Of_Date_Number.Text = "";
        txtHydraulicLiftDescription.Text = "";
        txtOil_Type.Text = "";
        txtHydraulicLiftManufacture.Text = "";
        txtHydraulicLift_Installation_Date.Text = "";
        txtHydraulicLift_Last_Inspection_Date.Text = "";
        txtHydraulicLift_Removal_Date.Text = "";
        txtHydraulicLiftNotes.Text = "";
        rdoAbove_Ground.SelectedValue = "N";

        rdoStatus.SelectedValue = "N";        
        rdoReplacementLift.SelectedIndex = -1;
        txtHydraulicLift_Last_Inspection_Date.Text = string.Empty;
        rdoInGroundLifts.SelectedValue = "N";
        rdoDocumentRelatedtoLifts.SelectedValue = "N";
        

        txtReplacementLiftDescription.Text = "";
        txtReplacementOilType.Text = "";
        txtManufacturer.Text = "";
        txtReplacementInstallationDate.Text = "";
        txtReplacementLastAnnualInspectionDate.Text = "";
        txtReplacementNotes.Text = "";
        rdoAboveGround.SelectedValue = "N";

        txtHydraulicLift_Removal_Date.Text = "";
        
        ShowHideReplacementLiftInformation();

        //rdoEquipmentStatus.SelectedValue = "N";

        pnlHydraulicLiftType.Visible = false;
        pnlAdd_Hydraulic_Lift.Visible = true;
        btnAudit_Hydraulic_Lift.Visible = false;
        tblEquipment.Style["display"] = "none";
        GetUse_Same_Dates();

        Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(1);displayHydraulicLift('none');", true);
    }
    /// <summary>
    ///  Handles Cancel Hazards Identification Button click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnCancelSludge_Click(object sender, EventArgs e)
    {
        pnlOWSDetail.Visible = true;
        pnlAddSludge.Visible = false;
        tblEquipment.Style["display"] = "block";
        Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(1);displaySludge('inline');", true);
    }
    /// <summary>
    ///  Handles Cancel Hazards Identification Button click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnCancelHydraulicLift_Click(object sender, EventArgs e)
    {
        pnlHydraulicLiftType.Visible = true;
        pnlAdd_Hydraulic_Lift.Visible = false;
        tblEquipment.Style["display"] = "block";
        Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(1);displayHydraulicLift('inline');", true);
    }
    /// <summary>
    ///  Handles Save Hazards Identification Button click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSaveSludge_Click(object sender, EventArgs e)
    {
        clsPM_Equipment_OWS_SR objPM_Equipment_OWS_SR = new clsPM_Equipment_OWS_SR();
        objPM_Equipment_OWS_SR.PK_PM_Equipment_OWS_SR = PK_PM_Equipment_OWS_SR;
        objPM_Equipment_OWS_SR.FK_PM_Equipment_OWS = PK_PM_Equipment_OWS;
        objPM_Equipment_OWS_SR.Sludge_Removal_Date = clsGeneral.FormatNullDateToStore(txtSludgeRemovalDate.Text);
        objPM_Equipment_OWS_SR.Sludge_Removed_By = Convert.ToString(txtSludgeRemovedBy.Text);
        objPM_Equipment_OWS_SR.Notes = txtSludgeNotes.Text;
        objPM_Equipment_OWS_SR.TCLP_Conducted = clsGeneral.FormatNullDateToStore(txtTCLPConductedDate.Text);
        objPM_Equipment_OWS_SR.TCLP = Convert.ToString(rdbTCLPPerformed.SelectedValue);
        objPM_Equipment_OWS_SR.TCLP_On_File = Convert.ToString(rdbTCLPonFile.SelectedValue);
        objPM_Equipment_OWS_SR.Update_Date = DateTime.Now;
        objPM_Equipment_OWS_SR.Updated_By = clsSession.UserID;
        if (PK_PM_Equipment_OWS_SR > 0)
            objPM_Equipment_OWS_SR.Update();
        else
            PK_PM_Equipment_OWS_SR = objPM_Equipment_OWS_SR.Insert();
        //Bind Grid Function
        BindSludgeGrid(PK_PM_Equipment_OWS);
        pnlOWSDetail.Visible = true;
        pnlAddSludge.Visible = false;
        tblEquipment.Style["display"] = "block";
        Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(1);displaySludge('inline');", true);
    }
    /// <summary>
    ///  Handles Save Hazards Identification Button click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSaveHydraulicLift_Click(object sender, EventArgs e)
    {
        clsPM_Equipment_Hydraulic_Lift_Grid objPM_Equipment_Hydraulic_Lift_Grid = new clsPM_Equipment_Hydraulic_Lift_Grid();
        objPM_Equipment_Hydraulic_Lift_Grid.PK_PM_Equipment_Hydraulic_Lift_Grid = PK_PM_Equipment_Hydraulic_Lift_Grid;
        objPM_Equipment_Hydraulic_Lift_Grid.FK_PM_Equipment_Hydraulic_Lift = PK_PM_Equipment_Hydraulic_Lift;
        objPM_Equipment_Hydraulic_Lift_Grid.Is_Number_Of_Lifts_At_Location = txtNumber_Of_Lifts_At_Location.Text.Trim();
        objPM_Equipment_Hydraulic_Lift_Grid.As_Of_Date_Number = clsGeneral.FormatNullDateToStore(txtAs_Of_Date_Number.Text);
        objPM_Equipment_Hydraulic_Lift_Grid.Description = txtHydraulicLiftDescription.Text.Trim();
        objPM_Equipment_Hydraulic_Lift_Grid.Oil_Type = txtOil_Type.Text.Trim();
        objPM_Equipment_Hydraulic_Lift_Grid.Above_Ground = Convert.ToString(rdoAbove_Ground.SelectedValue);
        objPM_Equipment_Hydraulic_Lift_Grid.Manufacturer_Name = txtHydraulicLiftManufacture.Text.Trim();
        objPM_Equipment_Hydraulic_Lift_Grid.Installation_Date = clsGeneral.FormatNullDateToStore(txtHydraulicLift_Installation_Date.Text);
        objPM_Equipment_Hydraulic_Lift_Grid.Last_Inspection_Date = clsGeneral.FormatNullDateToStore(txtHydraulicLift_Last_Inspection_Date.Text);
        objPM_Equipment_Hydraulic_Lift_Grid.Removal_Date = clsGeneral.FormatNullDateToStore(txtHydraulicLift_Removal_Date.Text);
        objPM_Equipment_Hydraulic_Lift_Grid.Notes = txtHydraulicLiftNotes.Text;
        objPM_Equipment_Hydraulic_Lift_Grid.Update_Date = DateTime.Now;
        objPM_Equipment_Hydraulic_Lift_Grid.Updated_By = clsSession.UserID;
        
        //3187
        objPM_Equipment_Hydraulic_Lift_Grid.Status = Convert.ToString(rdoStatus.SelectedValue);
        objPM_Equipment_Hydraulic_Lift_Grid.Any_Inground_Lifts_Been_Removed = Convert.ToString(rdoInGroundLifts.SelectedValue);
        objPM_Equipment_Hydraulic_Lift_Grid.Documentation_Related_To_Removed_Lifts = Convert.ToString(rdoDocumentRelatedtoLifts.SelectedValue);        
        objPM_Equipment_Hydraulic_Lift_Grid.Replacement_Description = txtReplacementLiftDescription.Text;
        objPM_Equipment_Hydraulic_Lift_Grid.Replacement_Oil_Type = txtReplacementOilType.Text;
        objPM_Equipment_Hydraulic_Lift_Grid.Replacement_Above_Ground = rdoAboveGround.SelectedValue;
        objPM_Equipment_Hydraulic_Lift_Grid.Replacement_Manufacturer = txtManufacturer.Text;
        objPM_Equipment_Hydraulic_Lift_Grid.Replacement_Installation_Date = clsGeneral.FormatNullDateToStore(txtReplacementInstallationDate.Text);
        objPM_Equipment_Hydraulic_Lift_Grid.Replacement_Last_Annual_Inspection = clsGeneral.FormatNullDateToStore(txtReplacementLastAnnualInspectionDate.Text);
        objPM_Equipment_Hydraulic_Lift_Grid.Replacement_Notes = txtReplacementNotes.Text;
        if (!string.IsNullOrEmpty(rdoReplacementLift.SelectedValue))
        objPM_Equipment_Hydraulic_Lift_Grid.Lift_Number_Replacement_Indicator = Convert.ToString(rdoReplacementLift.SelectedValue);    

        


        if (PK_PM_Equipment_Hydraulic_Lift_Grid > 0)
            objPM_Equipment_Hydraulic_Lift_Grid.Update();
        else
            PK_PM_Equipment_Hydraulic_Lift_Grid = objPM_Equipment_Hydraulic_Lift_Grid.Insert();
        //Bind Grid Function
        BindHydraulicLiftGrid(PK_PM_Equipment_Hydraulic_Lift);
        pnlHydraulicLiftType.Visible = true;
        pnlAdd_Hydraulic_Lift.Visible = false;
        tblEquipment.Style["display"] = "block";
        Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(1);displayHydraulicLift('inline');", true);
    }
    /// <summary>
    /// Get Record into Hazard Grid - Edit mode
    /// </summary>
    /// <param name="PK_ID">Primary key value for Role table</param>
    private void BindSludgeGrid(decimal PK_ID)
    {
        gvSludge.DataSource = clsPM_Equipment_OWS_SR.SelectAllByFK(PK_ID);
        gvSludge.DataBind();
    }
    /// <summary>
    /// Get Record into Hazard Grid - Edit mode
    /// </summary>
    /// <param name="PK_ID">Primary key value for Role table</param>
    private void BindHydraulicLiftGrid(decimal PK_ID)
    {
        gvHydraulicLift.DataSource = clsPM_Equipment_Hydraulic_Lift_Grid.SelectByFK(PK_ID);
        gvHydraulicLift.DataBind();
    }
    /// <summary>
    /// Get Record into Hazard Grid - View mode
    /// </summary>
    /// <param name="PK_ID">Primary key value for Role table</param>
    private void BindSludgeGridView(decimal PK_ID)
    {
        gvSludgeView.DataSource = clsPM_Equipment_OWS_SR.SelectAllByFK(PK_ID);
        gvSludgeView.DataBind();
    }
    /// <summary>
    /// Get Record into Hazard Grid - View mode
    /// </summary>
    /// <param name="PK_ID">Primary key value for Role table</param>
    private void BindHydraulicLiftGridView(decimal PK_ID)
    {
        gvHydraulicLiftView.DataSource = clsPM_Equipment_Hydraulic_Lift_Grid.SelectByFK(PK_ID);
        gvHydraulicLiftView.DataBind();
    }
    /// <summary>
    /// handles Hazard grid Row Command event
    /// </summary>    
    protected void gvSludge_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DeleteRecord")
        {
            decimal decPK = Convert.ToDecimal(e.CommandArgument);
            clsPM_Equipment_OWS_SR.DeleteByPK(decPK);
            BindSludgeGrid(PK_PM_Equipment_OWS);
            pnlOWSDetail.Visible = true;
            pnlAddSludge.Visible = false;
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(1);displaySludge('inline');", true);
        }
        else if (e.CommandName == "EditSludge")
        {
            decimal decPK = Convert.ToDecimal(e.CommandArgument);
            clsPM_Equipment_OWS_SR objPM_Equipment_OWS_SR = new clsPM_Equipment_OWS_SR(decPK);
            PK_PM_Equipment_OWS_SR = Convert.ToDecimal(objPM_Equipment_OWS_SR.PK_PM_Equipment_OWS_SR);
            txtSludgeRemovalDate.Text = clsGeneral.FormatDBNullDateToDisplay(objPM_Equipment_OWS_SR.Sludge_Removal_Date);
            txtTCLPConductedDate.Text = clsGeneral.FormatDBNullDateToDisplay(objPM_Equipment_OWS_SR.TCLP_Conducted);
            txtSludgeRemovedBy.Text = Convert.ToString(objPM_Equipment_OWS_SR.Sludge_Removed_By);
            txtSludgeNotes.Text = Convert.ToString(objPM_Equipment_OWS_SR.Notes);
            rdbTCLPonFile.SelectedValue = Convert.ToString(objPM_Equipment_OWS_SR.TCLP_On_File);
            rdbTCLPPerformed.SelectedValue = Convert.ToString(objPM_Equipment_OWS_SR.TCLP);
            pnlOWSDetail.Visible = false;
            pnlAddSludge.Visible = true;
            btnAuditSludge.Visible = true;
            tblEquipment.Style["display"] = "none";
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(1);displaySludge('none');", true);
        }
    }
    /// <summary>
    /// handles Hazard grid Row Command event
    /// </summary>    
    protected void gvHydraulicLift_RowCommand(object sender, GridViewCommandEventArgs e)    
    {        
        if (e.CommandName == "DeleteRecord")
        {
            decimal decPK = Convert.ToDecimal(e.CommandArgument);
            clsPM_Equipment_Hydraulic_Lift_Grid.DeleteByPK(decPK);
            BindHydraulicLiftGrid(PK_PM_Equipment_Hydraulic_Lift);
            pnlHydraulicLiftType.Visible = true;
            pnlAdd_Hydraulic_Lift.Visible = false;
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(1);displayHydraulicLift('inline');", true);
        }
        else if (e.CommandName == "EditHydraulicLift")
        {
            decimal decPK = Convert.ToDecimal(e.CommandArgument);
            clsPM_Equipment_Hydraulic_Lift_Grid objPM_Equipment_Hydraulic_Lift_Grid = new clsPM_Equipment_Hydraulic_Lift_Grid(decPK);
            PK_PM_Equipment_Hydraulic_Lift_Grid = Convert.ToDecimal(objPM_Equipment_Hydraulic_Lift_Grid.PK_PM_Equipment_Hydraulic_Lift_Grid);
            txtNumber_Of_Lifts_At_Location.Text = Convert.ToString(objPM_Equipment_Hydraulic_Lift_Grid.Is_Number_Of_Lifts_At_Location);
            txtAs_Of_Date_Number.Text = clsGeneral.FormatDBNullDateToDisplay(objPM_Equipment_Hydraulic_Lift_Grid.As_Of_Date_Number);
            txtHydraulicLiftDescription.Text = Convert.ToString(objPM_Equipment_Hydraulic_Lift_Grid.Description);
            txtOil_Type.Text = Convert.ToString(objPM_Equipment_Hydraulic_Lift_Grid.Oil_Type);
            rdoAbove_Ground.SelectedValue = Convert.ToString(objPM_Equipment_Hydraulic_Lift_Grid.Above_Ground);
            txtHydraulicLiftManufacture.Text = Convert.ToString(objPM_Equipment_Hydraulic_Lift_Grid.Manufacturer_Name);
            txtHydraulicLift_Installation_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objPM_Equipment_Hydraulic_Lift_Grid.Installation_Date);
            txtHydraulicLift_Last_Inspection_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objPM_Equipment_Hydraulic_Lift_Grid.Last_Inspection_Date);
            // txtRemoval_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objPM_Equipment_Hydraulic_Lift_Grid.Removal_Date); 
            txtHydraulicLift_Removal_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objPM_Equipment_Hydraulic_Lift_Grid.Removal_Date);
            txtHydraulicLiftNotes.Text = Convert.ToString(objPM_Equipment_Hydraulic_Lift_Grid.Notes);            


            //3187
            if (objPM_Equipment_Hydraulic_Lift_Grid.Status != null)
                rdoStatus.SelectedValue = objPM_Equipment_Hydraulic_Lift_Grid.Status;
            else
                rdoStatus.SelectedIndex = -1;

            if (objPM_Equipment_Hydraulic_Lift_Grid.Any_Inground_Lifts_Been_Removed != null)
                rdoInGroundLifts.SelectedValue = objPM_Equipment_Hydraulic_Lift_Grid.Any_Inground_Lifts_Been_Removed;
            else
                rdoInGroundLifts.SelectedValue = "N";

            if (objPM_Equipment_Hydraulic_Lift_Grid.Documentation_Related_To_Removed_Lifts != null)
                rdoDocumentRelatedtoLifts.SelectedValue = objPM_Equipment_Hydraulic_Lift_Grid.Documentation_Related_To_Removed_Lifts;
            else
                rdoDocumentRelatedtoLifts.SelectedValue = "N";

            txtReplacementLiftDescription.Text = Convert.ToString(objPM_Equipment_Hydraulic_Lift_Grid.Replacement_Description);
            txtReplacementOilType.Text = objPM_Equipment_Hydraulic_Lift_Grid.Replacement_Oil_Type;

            if (objPM_Equipment_Hydraulic_Lift_Grid.Replacement_Above_Ground != null)
                rdoAboveGround.SelectedValue = objPM_Equipment_Hydraulic_Lift_Grid.Replacement_Above_Ground;
            else
                rdoAboveGround.SelectedValue = "N";

            ShowHideReplacementLiftInformation();

            if (!string.IsNullOrEmpty(objPM_Equipment_Hydraulic_Lift_Grid.Lift_Number_Replacement_Indicator))
                rdoReplacementLift.SelectedValue = objPM_Equipment_Hydraulic_Lift_Grid.Lift_Number_Replacement_Indicator;            

            txtManufacturer.Text = objPM_Equipment_Hydraulic_Lift_Grid.Replacement_Manufacturer;
            txtReplacementInstallationDate.Text = clsGeneral.FormatDBNullDateToDisplay(objPM_Equipment_Hydraulic_Lift_Grid.Replacement_Installation_Date);
            txtReplacementLastAnnualInspectionDate.Text = clsGeneral.FormatDBNullDateToDisplay(objPM_Equipment_Hydraulic_Lift_Grid.Replacement_Last_Annual_Inspection);
            txtReplacementNotes.Text = Convert.ToString(objPM_Equipment_Hydraulic_Lift_Grid.Replacement_Notes);

            pnlHydraulicLiftType.Visible = false;
            pnlAdd_Hydraulic_Lift.Visible = true;
            btnAudit_Hydraulic_Lift.Visible = true;
            tblEquipment.Style["display"] = "none";
            GetUse_Same_Dates();
            SetValidationsHydraulic();            
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(1);displayHydraulicLift('none');", true);
        }
    }

    /// <summary>
    /// Gridview Sludge View Row Command
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvSludgeView_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "ViewSludge")
        {
            decimal decPK = Convert.ToDecimal(e.CommandArgument);
            clsPM_Equipment_OWS_SR objPM_Equipment_OWS_SR = new clsPM_Equipment_OWS_SR(decPK);
            PK_PM_Equipment_OWS_SR = Convert.ToDecimal(objPM_Equipment_OWS_SR.PK_PM_Equipment_OWS_SR);
            lblSludgeRemovalDate.Text = clsGeneral.FormatDBNullDateToDisplay(objPM_Equipment_OWS_SR.Sludge_Removal_Date);
            lblSludgeRemovedBy.Text = Convert.ToString(objPM_Equipment_OWS_SR.Sludge_Removed_By);
            lblSludgeNotes.Text = Convert.ToString(objPM_Equipment_OWS_SR.Notes);
            lblTCLPConductedDate.Text = clsGeneral.FormatDBNullDateToDisplay(objPM_Equipment_OWS_SR.TCLP_Conducted);
            lblTCLPPerformed.Text = Convert.ToString(objPM_Equipment_OWS_SR.TCLP) == "Y" ? "Yes" : "No";
            lblTCLPOnFile.Text = Convert.ToString(objPM_Equipment_OWS_SR.TCLP_On_File) == "Y" ? "Yes" : "No";
            pnlOWSTypeDetailview.Visible = false;
            pnlOWSTypeViewData.Visible = true;
            btnAuditSludgeView.Visible = true;
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(1);viewSludge('none');", true);
        }
    }

    /// <summary>
    /// Gridview sludge  paging
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvSludge_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvSludge.PageIndex = e.NewPageIndex; //Page new index call

        BindSludgeGrid(PK_PM_Equipment_OWS);
        Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(1);displaySludge('inline');", true);
    }
    /// <summary>
    /// Gridview HydraulicLift  paging
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvHydraulicLift_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvHydraulicLift.PageIndex = e.NewPageIndex; //Page new index call

        BindHydraulicLiftGrid(PK_PM_Equipment_Hydraulic_Lift);
        Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(1);", true);
    }

    /// <summary>
    /// Gridview sludge view  paging
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvSludgeView_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvSludgeView.PageIndex = e.NewPageIndex; //Page new index call

        BindSludgeGridView(PK_PM_Equipment_OWS);
        Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(1);viewSludge('none');", true);
    }

    protected void gvHydraulicLiftView_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvHydraulicLiftView.PageIndex = e.NewPageIndex; //Page new index call

        BindHydraulicLiftGridView(PK_PM_Equipment_Hydraulic_Lift);
        Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(1);", true);
    }
    /// <summary>
    /// Gridview HydraulicLift View Row Command
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvHydraulicLiftView_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "ViewHydraulicLift")
        {
            decimal decPK = Convert.ToDecimal(e.CommandArgument);
            clsPM_Equipment_Hydraulic_Lift_Grid objPM_Equipment_Hydraulic_Lift_Grid = new clsPM_Equipment_Hydraulic_Lift_Grid(decPK);
            PK_PM_Equipment_Hydraulic_Lift_Grid = Convert.ToDecimal(objPM_Equipment_Hydraulic_Lift_Grid.PK_PM_Equipment_Hydraulic_Lift_Grid);
            lblNumber_Of_Lifts_At_Location.Text = Convert.ToString(objPM_Equipment_Hydraulic_Lift_Grid.Is_Number_Of_Lifts_At_Location);
            lblAs_Of_Date_Number.Text = clsGeneral.FormatDBNullDateToDisplay(objPM_Equipment_Hydraulic_Lift_Grid.As_Of_Date_Number);
            lblHydraulicLiftDescription.Text = Convert.ToString(objPM_Equipment_Hydraulic_Lift_Grid.Description);
            lblOil_Type.Text = Convert.ToString(objPM_Equipment_Hydraulic_Lift_Grid.Oil_Type);
            lblAbove_Ground.Text = Convert.ToString(objPM_Equipment_Hydraulic_Lift_Grid.Above_Ground) == "" ? "No" : (Convert.ToString(objPM_Equipment_Hydraulic_Lift_Grid.Above_Ground) == "Y" ? "Yes" : "No");
            lblHydraulicLiftManufacture.Text = Convert.ToString(objPM_Equipment_Hydraulic_Lift_Grid.Manufacturer_Name);
            lblInstallationDateHydraulicLift.Text = clsGeneral.FormatDBNullDateToDisplay(objPM_Equipment_Hydraulic_Lift_Grid.Installation_Date);
            lblLast_Inspection_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objPM_Equipment_Hydraulic_Lift_Grid.Last_Inspection_Date);
            lblHydraulicLift_Removal_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objPM_Equipment_Hydraulic_Lift_Grid.Removal_Date);
            lblHydraulicLiftNote.Text = Convert.ToString(objPM_Equipment_Hydraulic_Lift_Grid.Notes);
            lblHydraulicLift_Last_Inspection_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objPM_Equipment_Hydraulic_Lift_Grid.Last_Inspection_Date);


            //3187            
            lblStatus.Text = Convert.ToString(objPM_Equipment_Hydraulic_Lift_Grid.Status) == "A" ? "Active" : (Convert.ToString(objPM_Equipment_Hydraulic_Lift_Grid.Status) == "N" ? "Non-Active" : (Convert.ToString(objPM_Equipment_Hydraulic_Lift_Grid.Status) == "R" ? "Removed" : string.Empty)); 

            lblInGroundLifts.Text = Convert.ToString(objPM_Equipment_Hydraulic_Lift_Grid.Any_Inground_Lifts_Been_Removed) == "" ? "N" : (Convert.ToString(objPM_Equipment_Hydraulic_Lift_Grid.Any_Inground_Lifts_Been_Removed) == "Y" ? "Yes" : "No");
            lblDocumentRelatedLifts.Text = Convert.ToString(objPM_Equipment_Hydraulic_Lift_Grid.Documentation_Related_To_Removed_Lifts) == "" ? "N" : (Convert.ToString(objPM_Equipment_Hydraulic_Lift_Grid.Documentation_Related_To_Removed_Lifts) == "Y" ? "Yes" : "No"); ;


            lblReplacementDescription.Text = Convert.ToString(objPM_Equipment_Hydraulic_Lift_Grid.Replacement_Description);
            lblReplacementOilType.Text = objPM_Equipment_Hydraulic_Lift_Grid.Replacement_Oil_Type;

            lblAboveGround.Text = Convert.ToString(objPM_Equipment_Hydraulic_Lift_Grid.Replacement_Above_Ground) == "" ? "N" : (Convert.ToString(objPM_Equipment_Hydraulic_Lift_Grid.Replacement_Above_Ground) == "Y" ? "Yes" : "No"); ;

            lblManufacturer.Text = objPM_Equipment_Hydraulic_Lift_Grid.Replacement_Manufacturer;
            lblReplacementInstallationDate.Text = clsGeneral.FormatDBNullDateToDisplay(objPM_Equipment_Hydraulic_Lift_Grid.Replacement_Installation_Date);
            lblLastAnnualInspectionDate.Text = clsGeneral.FormatDBNullDateToDisplay(objPM_Equipment_Hydraulic_Lift_Grid.Replacement_Last_Annual_Inspection);
            lblReplacementNotes.Text = Convert.ToString(objPM_Equipment_Hydraulic_Lift_Grid.Replacement_Notes);

            lblReplacementLift.Text = Convert.ToString(objPM_Equipment_Hydraulic_Lift_Grid.Lift_Number_Replacement_Indicator) == null ? "" : (Convert.ToString(objPM_Equipment_Hydraulic_Lift_Grid.Lift_Number_Replacement_Indicator) == "Y" ? "Yes" : "No");


            pnlHydraulicLiftTypeview.Visible = false;
            pnlHydraulicLifGridViewData.Visible = true;
            btnAuditHydraulicLiftView.Visible = true;
            Session["LiftRack"] = spLiftNumber.InnerText;            
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(1);viewHydraulicLift('none');", true);
        }
    }

    /// <summary>
    ///  Handles Cancel Hazards Identification Button click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnCancelSludgeView_Click(object sender, EventArgs e)
    {
        pnlOWSTypeDetailview.Visible = true;
        pnlOWSTypeViewData.Visible = false;
        Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(1);viewSludge('inline');", true);
    }

    /// <summary>
    ///  Handles Cancel Hazards Identification Button click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnCancelHydraulicLiftView_Click(object sender, EventArgs e)
    {
        pnlHydraulicLiftTypeview.Visible = true;
        pnlHydraulicLifGridViewData.Visible = false;
        Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(1);viewHydraulicLift('inline');", true);
    }

    /// <summary>
    /// Handle Save View Data
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSaveView_Click(object sender, EventArgs e)
    {
        //Equiptment type 'Tank' is selected then Save Data in PM_Equipment_Tank table
        if (drpEquipmentType.SelectedItem.ToString().ToLower().Trim() == "tank")
        {
            clsPM_Equipment objPM_Equipment = new clsPM_Equipment();
            objPM_Equipment.PK_PM_Equipment = PM_Equipment;
            objPM_Equipment.FK_PM_Site_Information = FK_PM_Site_Information;
            if (drpEquipmentType.SelectedIndex > 0) objPM_Equipment.FK_LU_Equipment_Type = Convert.ToDecimal(drpEquipmentType.SelectedValue);
            objPM_Equipment.FK_Table_Name = 0;
            objPM_Equipment.Table_Name = "PM_Equipment_Tank";
            PK_PM_Equipment_Tank = objPM_Equipment.InsertUpdate();

            clsPM_Equipment_Tank objPM_Equipment_Tank = new clsPM_Equipment_Tank(PK_PM_Equipment_Tank);
            if (objPM_Equipment_Tank.PK_PM_Equipment != null)
                PM_Equipment = (decimal)objPM_Equipment_Tank.PK_PM_Equipment;
            objPM_Equipment_Tank.PK_PM_Equipment_Tank = PK_PM_Equipment_Tank;
            objPM_Equipment_Tank.Description = txtDescription.Text.Trim();
            objPM_Equipment_Tank.Manufacturer = txtTankManufacture.Text.Trim();
            objPM_Equipment_Tank.Ground_Location = rdoGround_Location.SelectedValue;
            objPM_Equipment_Tank.Identification = txtIdentification.Text.Trim();
            if (drpFK_Tank_Contents.SelectedIndex > 0) objPM_Equipment_Tank.FK_Tank_Contents = Convert.ToDecimal(drpFK_Tank_Contents.SelectedValue);
            objPM_Equipment_Tank.Contents_Other = txtContents_Other.Text.Trim();
            if (drpFK_Tank_Material.SelectedIndex > 0) objPM_Equipment_Tank.FK_Tank_Material = Convert.ToDecimal(drpFK_Tank_Material.SelectedValue);
            objPM_Equipment_Tank.Material_Other = txtMaterial_Other.Text.Trim();
            if (drpFK_Tank_Construction.SelectedIndex > 0) objPM_Equipment_Tank.FK_Tank_Construction = Convert.ToDecimal(drpFK_Tank_Construction.SelectedValue);
            objPM_Equipment_Tank.Construction_Other = txtConstruction_Other.Text.Trim();
            if (txtCapcity.Text != "") objPM_Equipment_Tank.Capcity = clsGeneral.GetDecimalValue(txtCapcity);
            objPM_Equipment_Tank.Certificate_Number = txtCertificate_Number.Text.Trim();
            objPM_Equipment_Tank.Installation_Date = clsGeneral.FormatNullDateToStore(txtInstallation_Date.Text);
            objPM_Equipment_Tank.Installation_Firm = txtInstallation_Firm.Text.Trim();
            objPM_Equipment_Tank.Last_Maintenance_Date = clsGeneral.FormatNullDateToStore(txtLast_Maintenance_Date.Text);
            objPM_Equipment_Tank.Last_Revision_Date = clsGeneral.FormatNullDateToStore(txtLast_Revision_Date.Text);
            objPM_Equipment_Tank.Tank_In_Use = rdoTank_In_Use.SelectedValue;
            objPM_Equipment_Tank.UL_Certified = rdbULCertified.SelectedValue;
            objPM_Equipment_Tank.Secure_Non_Business = rdbSecureNonBusiness.SelectedValue;
            objPM_Equipment_Tank.Last_Inspection_Date = clsGeneral.FormatNullDateToStore(txtLast_Inspection_Date.Text);
            objPM_Equipment_Tank.Closure_Date = clsGeneral.FormatNullDateToStore(txtClosure_Date.Text);
            objPM_Equipment_Tank.Removal_Date = clsGeneral.FormatNullDateToStore(txtRemoval_Date.Text);
            objPM_Equipment_Tank.Revised_Removal_Date = clsGeneral.FormatNullDateToStore(txtRevised_Removal_Date.Text);
            objPM_Equipment_Tank.Permit_Begin_Date = clsGeneral.FormatNullDateToStore(txtPermit_Begin_Date.Text);
            objPM_Equipment_Tank.Permit_End_Date = clsGeneral.FormatNullDateToStore(txtPermit_End_Date.Text);
            objPM_Equipment_Tank.Registration_Required = rdoRegistration_Required.SelectedValue;
            objPM_Equipment_Tank.Registration_Number = txtRegistration_Number.Text.Trim();
            objPM_Equipment_Tank.Leak_Detection_Required = rdoLeak_Detection_Required.SelectedValue;
            objPM_Equipment_Tank.Leak_Detection_Type = txtLeak_Detection_Type.Text.Trim();
            objPM_Equipment_Tank.Overfill_Protection = rdoOverfill_Protection.SelectedValue;
            objPM_Equipment_Tank.Secondary_Containment_Adequate = rdoSecondary_Containment_Adequate.SelectedValue;
            if (drpFK_LU_Secondary_Containment_Type.SelectedIndex > 0) objPM_Equipment_Tank.FK_LU_Secondary_Containment_Type = Convert.ToDecimal(drpFK_LU_Secondary_Containment_Type.SelectedValue);
            objPM_Equipment_Tank.Description_Other_Reporting_Requirements = txtDescription_Other_Reporting_Requirements.Text.Trim();
            objPM_Equipment_Tank.Plan_Date = clsGeneral.FormatNullDateToStore(txtPlan_Date.Text);
            objPM_Equipment_Tank.Plan_Identification = txtPlan_Identification.Text.Trim();
            objPM_Equipment_Tank.Recommendations = txtRecommendations.Text.Trim();
            objPM_Equipment_Tank.Effective_Date = clsGeneral.FormatNullDateToStore(txtEffective_Date.Text);
            objPM_Equipment_Tank.Expiration_Date = clsGeneral.FormatNullDateToStore(txtExpiration_Date.Text);
            objPM_Equipment_Tank.Recordkeeping_Requirements = txtRecordkeeping_Requirements.Text.Trim();
            //objPM_Equipment_Tank.Release_Control_Countermeasures_Plan = txtRelease_Control_Countermeasures_Plan.Text.Trim();      //* :3187 *//
            objPM_Equipment_Tank.SPCC_Required = rdoSPCC_Required.SelectedValue;
            objPM_Equipment_Tank.SPCCDate_Developed = clsGeneral.FormatNullDateToStore(txtSPCCDate_Developed.Text);
            objPM_Equipment_Tank.Status = rdoEquipmentStatus.SelectedValue;
            
            DateTime? dtCurrent = clsGeneral.FormatNullDateToStore(txtSPCCDate_Developed.Text);
            DateTime? dtNew = new DateTime();
            if (dtCurrent != null && string.IsNullOrEmpty(txtSPCCExpiration_Date.Text))
            {
                dtNew = new DateTime(dtCurrent.Value.Year + 5, dtCurrent.Value.Month, dtCurrent.Value.Day, dtCurrent.Value.Hour, dtCurrent.Value.Minute, dtCurrent.Value.Second);
            }
            else if (!string.IsNullOrEmpty(txtSPCCExpiration_Date.Text))
            {
                dtNew = clsGeneral.FormatDBNullDateToDate(txtSPCCExpiration_Date.Text);
            }
            else
            {
                dtNew = null;
            }

            objPM_Equipment_Tank.SPCCExpiration_Date = dtNew;
            objPM_Equipment_Tank.Maintenance_Vendor = txtMaintenance_Vendor.Text.Trim();
            objPM_Equipment_Tank.Vendor_Contact_Name = txtVendor_Contact_Name.Text.Trim();
            objPM_Equipment_Tank.Vendor_Contact_Telephone = txtVendor_Contact_Telephone.Text.Trim();
            objPM_Equipment_Tank.Insurer = txtInsurer.Text.Trim();
            objPM_Equipment_Tank.Coverage_Start_Date = clsGeneral.FormatNullDateToStore(txtCoverage_Start_Date.Text);
            objPM_Equipment_Tank.Coverage_End_Date = clsGeneral.FormatNullDateToStore(txtCoverage_End_Date.Text);
            if (txtMultiple_Event_Total_Coverage.Text != "") objPM_Equipment_Tank.Multiple_Event_Total_Coverage = clsGeneral.GetDecimalValue(txtMultiple_Event_Total_Coverage);
            if (txtSingle_Event_Coverage.Text != "") objPM_Equipment_Tank.Single_Event_Coverage = clsGeneral.GetDecimalValue(txtSingle_Event_Coverage);
            objPM_Equipment_Tank.Inspection_Company = txtInspection_Company.Text.Trim();
            objPM_Equipment_Tank.Inspection_Company_Contact_Name = txtInspection_Company_Contact_Name.Text.Trim();
            objPM_Equipment_Tank.Inspection_Company_Contact_Telephone = txtInspection_Company_Contact_Telephone.Text.Trim();
            objPM_Equipment_Tank.Notes = txtNotes.Text.Trim();
            objPM_Equipment_Tank.Update_Date = DateTime.Now;
            objPM_Equipment_Tank.Updated_By = clsSession.UserID;
            if (PK_PM_Equipment_Tank > 0)
                objPM_Equipment_Tank.Update();
            Upload_File("");
            StrOperation = "view";
            //BindDetailsForView();
            //Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(1);", true);

            Response.Redirect("Equipment.aspx?op=view&id=" + Encryption.Encrypt(Convert.ToString(PM_Equipment)) + "&fid=" + Encryption.Encrypt(Convert.ToString(FK_PM_Site_Information)) + "&loc=" + Request.QueryString["loc"]);

        }
        //Equiptment type 'Paint Booth' is selected then Save Data in PM_Equipment_Spray_Booth table
        else if (drpEquipmentType.SelectedItem.ToString().ToLower().Trim() == "paint booth")
        {
            clsPM_Equipment objPM_Equipment = new clsPM_Equipment();
            objPM_Equipment.PK_PM_Equipment = PM_Equipment;
            objPM_Equipment.FK_PM_Site_Information = FK_PM_Site_Information;
            if (drpEquipmentType.SelectedIndex > 0) objPM_Equipment.FK_LU_Equipment_Type = Convert.ToDecimal(drpEquipmentType.SelectedValue);
            objPM_Equipment.FK_Table_Name = 0;
            objPM_Equipment.Table_Name = "PM_Equipment_Spray_Booth";
            PK_PM_Equipment_Spray_Booth = objPM_Equipment.InsertUpdate();

            clsPM_Equipment_Spray_Booth objPM_Equipment_Spray_Booth = new clsPM_Equipment_Spray_Booth(PK_PM_Equipment_Spray_Booth);
            if (objPM_Equipment_Spray_Booth.PK_PM_Equipment != null)
                PM_Equipment = (decimal)objPM_Equipment_Spray_Booth.PK_PM_Equipment;
            objPM_Equipment_Spray_Booth.PK_PM_Equipment_Spray_Booth = PK_PM_Equipment_Spray_Booth;
            objPM_Equipment_Spray_Booth.Description = txtSprayBoothDesc.Text.Trim();
            objPM_Equipment_Spray_Booth.Manufacturer_Name = txtManufacturer_Name.Text.Trim();
            objPM_Equipment_Spray_Booth.Installation_Date = clsGeneral.FormatNullDateToStore(txtInstallationDate.Text);
            objPM_Equipment_Spray_Booth.Configured_For_Water_Borne_Application = rdoConfigured_For_Water_Borne_Application.SelectedValue;
            objPM_Equipment_Spray_Booth.Direct_Indirect_Burners = rdoDirect_Indirect_Burners.SelectedValue;
            if (txtBTU_Rating.Text != "") objPM_Equipment_Spray_Booth.BTU_Rating = clsGeneral.GetDecimalValue(txtBTU_Rating);
            if (txtHeight_In_Feet.Text != "") objPM_Equipment_Spray_Booth.Height_In_Feet = clsGeneral.GetDecimalValue(txtHeight_In_Feet);
            if (txtWidth_In_Feet.Text != "") objPM_Equipment_Spray_Booth.Width_In_Feet = clsGeneral.GetDecimalValue(txtWidth_In_Feet);
            if (txtDepth_In_Feet.Text != "") objPM_Equipment_Spray_Booth.Depth_In_Feet = clsGeneral.GetDecimalValue(txtDepth_In_Feet);
            objPM_Equipment_Spray_Booth.Filter_System = txtFilter_System.Text.Trim();
            if (txtCapture_Efficiency.Text != "") objPM_Equipment_Spray_Booth.Capture_Efficiency = clsGeneral.GetDecimalValue(txtCapture_Efficiency);
            if (txtControl_Efficiency.Text != "") objPM_Equipment_Spray_Booth.Control_Efficiency = clsGeneral.GetDecimalValue(txtControl_Efficiency);
            if (txtStack_Height_In_Feet.Text != "") objPM_Equipment_Spray_Booth.Stack_Height_In_Feet = clsGeneral.GetDecimalValue(txtStack_Height_In_Feet);
            if (txtExit_Flow_Rate_CFM.Text != "") objPM_Equipment_Spray_Booth.Exit_Flow_Rate_CFM = clsGeneral.GetDecimalValue(txtExit_Flow_Rate_CFM);
            if (txtExit_Temperature_Low.Text != "") objPM_Equipment_Spray_Booth.Exit_Temperature_Low = clsGeneral.GetDecimalValue(txtExit_Temperature_Low);
            if (txtExit_Temperature_High.Text != "") objPM_Equipment_Spray_Booth.Exit_Temperature_High = clsGeneral.GetDecimalValue(txtExit_Temperature_High);
            objPM_Equipment_Spray_Booth.Notes = txtSprayBoothNotes.Text.Trim();
            objPM_Equipment_Spray_Booth.Update_Date = DateTime.Now;
            objPM_Equipment_Spray_Booth.Updated_By = clsSession.UserID;
            objPM_Equipment_Spray_Booth.Manual_6H_Binder = rdbManual6HBinder.SelectedValue;
            objPM_Equipment_Spray_Booth.Capture_Efficieicny_Date = clsGeneral.FormatNullDateToStore(txtCaptureEfficiencyDate.Text);
            objPM_Equipment_Spray_Booth.Control_Efficiency_Date = clsGeneral.FormatNullDateToStore(txtControlEfficiencyDate.Text);

            if (PK_PM_Equipment_Spray_Booth > 0)
                objPM_Equipment_Spray_Booth.Update();
            Upload_File("");
            StrOperation = "view";
            // BindDetailsForView();
            //Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(1);", true);
            Response.Redirect("Equipment.aspx?op=view&id=" + Encryption.Encrypt(Convert.ToString(PM_Equipment)) + "&fid=" + Encryption.Encrypt(Convert.ToString(FK_PM_Site_Information)) + "&loc=" + Request.QueryString["loc"]);

        }
        //Equiptment type 'Paint Booth' is selected then Save Data in PM_Equipment_Prep_Station table
        else if (drpEquipmentType.SelectedItem.ToString().ToLower().Trim() == "prep station")
        {
            clsPM_Equipment objPM_Equipment = new clsPM_Equipment();
            objPM_Equipment.PK_PM_Equipment = PM_Equipment;
            objPM_Equipment.FK_PM_Site_Information = FK_PM_Site_Information;
            if (drpEquipmentType.SelectedIndex > 0) objPM_Equipment.FK_LU_Equipment_Type = Convert.ToDecimal(drpEquipmentType.SelectedValue);
            objPM_Equipment.FK_Table_Name = 0;
            objPM_Equipment.Table_Name = "PM_Equipment_Prep_Station";
            PK_PM_Equipment_Prep_Station = objPM_Equipment.InsertUpdate();

            clsPM_Equipment_Prep_Station objPM_Equipment_Prep_Station = new clsPM_Equipment_Prep_Station(PK_PM_Equipment_Prep_Station);
            if (objPM_Equipment_Prep_Station.PK_PM_Equipment != null)
                PM_Equipment = (decimal)objPM_Equipment_Prep_Station.PK_PM_Equipment;
            objPM_Equipment_Prep_Station.PK_PM_Equipment_Prep_Station = PK_PM_Equipment_Prep_Station;
            objPM_Equipment_Prep_Station.Description = txtPrepStationDesc.Text.Trim();
            objPM_Equipment_Prep_Station.Manufacturer_Name = txtManufacturer_Name_PrepStation.Text.Trim();
            objPM_Equipment_Prep_Station.Installation_Date = clsGeneral.FormatNullDateToStore(txtInstallationDate_PrepStation.Text);
            objPM_Equipment_Prep_Station.Configured_For_Water_Borne_Application = rdoConfigured_For_Water_Borne_Application_PrepStation.SelectedValue;
            objPM_Equipment_Prep_Station.Direct_Indirect_Burners = rdoDirect_Indirect_Burners_PrepStation.SelectedValue;
            if (txtBTU_Rating_PrepStation.Text != "") objPM_Equipment_Prep_Station.BTU_Rating = clsGeneral.GetDecimalValue(txtBTU_Rating_PrepStation);
            if (txtHeight_In_Feet_PrepStation.Text != "") objPM_Equipment_Prep_Station.Height_In_Feet = clsGeneral.GetDecimalValue(txtHeight_In_Feet_PrepStation);
            if (txtWidth_In_Feet_PrepStation.Text != "") objPM_Equipment_Prep_Station.Width_In_Feet = clsGeneral.GetDecimalValue(txtWidth_In_Feet_PrepStation);
            if (txtDepth_In_Feet_PrepStation.Text != "") objPM_Equipment_Prep_Station.Depth_In_Feet = clsGeneral.GetDecimalValue(txtDepth_In_Feet_PrepStation);
            objPM_Equipment_Prep_Station.Filter_System = txtFilter_System_PrepStation.Text.Trim();
            if (txtCapture_Efficiency_PrepStation.Text != "") objPM_Equipment_Prep_Station.Capture_Efficiency = clsGeneral.GetDecimalValue(txtCapture_Efficiency_PrepStation);
            if (txtControl_Efficiency_PrepStation.Text != "") objPM_Equipment_Prep_Station.Control_Efficiency = clsGeneral.GetDecimalValue(txtControl_Efficiency_PrepStation);
            if (txtStack_Height_In_Feet_PrepStation.Text != "") objPM_Equipment_Prep_Station.Stack_Height_In_Feet = clsGeneral.GetDecimalValue(txtStack_Height_In_Feet_PrepStation);
            if (txtExit_Flow_Rate_CFM_PrepStation.Text != "") objPM_Equipment_Prep_Station.Exit_Flow_Rate_CFM = clsGeneral.GetDecimalValue(txtExit_Flow_Rate_CFM_PrepStation);
            if (txtExit_Temperature_Low_PrepStation.Text != "") objPM_Equipment_Prep_Station.Exit_Temperature_Low = clsGeneral.GetDecimalValue(txtExit_Temperature_Low_PrepStation);
            if (txtExit_Temperature_High_PrepStation.Text != "") objPM_Equipment_Prep_Station.Exit_Temperature_High = clsGeneral.GetDecimalValue(txtExit_Temperature_High_PrepStation);
            objPM_Equipment_Prep_Station.Notes = txtPrepStationNotes.Text.Trim();
            objPM_Equipment_Prep_Station.Update_Date = DateTime.Now;
            objPM_Equipment_Prep_Station.Updated_By = clsSession.UserID;
            objPM_Equipment_Prep_Station.Manual_6H_Binder = rdbManual6HBinder_PrepStation.SelectedValue;
            objPM_Equipment_Prep_Station.Capture_Efficieicny_Date = clsGeneral.FormatNullDateToStore(txtCaptureEfficiencyDate_PrepStation.Text);
            objPM_Equipment_Prep_Station.Control_Efficiency_Date = clsGeneral.FormatNullDateToStore(txtControlEfficiencyDate_PrepStation.Text);

            if (PK_PM_Equipment_Prep_Station > 0)
                objPM_Equipment_Prep_Station.Update();
            Upload_File("");
            StrOperation = "view";
            // BindDetailsForView();
            //Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(1);", true);
            Response.Redirect("Equipment.aspx?op=view&id=" + Encryption.Encrypt(Convert.ToString(PM_Equipment)) + "&fid=" + Encryption.Encrypt(Convert.ToString(FK_PM_Site_Information)) + "&loc=" + Request.QueryString["loc"]);

        }
        //Equiptment type 'Oil and Water Separator' is selected then Save Data in PM_Equipment_OWS table
        else if (drpEquipmentType.SelectedItem.ToString().ToLower().Trim() == "oil and water separator")
        {
            SaveOWSData();
            StrOperation = "view";
            Upload_File("");
            // BindDetailsForView();
            // Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(1);", true);
            Response.Redirect("Equipment.aspx?op=view&id=" + Encryption.Encrypt(Convert.ToString(PM_Equipment)) + "&fid=" + Encryption.Encrypt(Convert.ToString(FK_PM_Site_Information)) + "&loc=" + Request.QueryString["loc"]);

        }
        //Equiptment type 'Hydraulic Lift' is selected then Save Data in PM_Equipment_Hydraulic_Lift table
        //Equiptment type 'Alignment Rack' is selected then Save Data in PM_Equipment_Hydraulic_Lift table ticket #3142
        else if (drpEquipmentType.SelectedItem.ToString().ToLower().Trim() == "hydraulic lift" || drpEquipmentType.SelectedItem.ToString().ToLower().Trim() == "alignment rack")
        {
            RackLiftAsPerEventType();                
            clsPM_Equipment objPM_Equipment = new clsPM_Equipment();
            objPM_Equipment.PK_PM_Equipment = PM_Equipment;
            objPM_Equipment.FK_PM_Site_Information = FK_PM_Site_Information;
            if (drpEquipmentType.SelectedIndex > 0) objPM_Equipment.FK_LU_Equipment_Type = Convert.ToDecimal(drpEquipmentType.SelectedValue);
            objPM_Equipment.FK_Table_Name = 0;
            objPM_Equipment.Table_Name = "PM_Equipment_Hydraulic_Lift";
            PK_PM_Equipment_Hydraulic_Lift = objPM_Equipment.InsertUpdate();

            clsPM_Equipment_Hydraulic_Lift objPM_Equipment_Hydraulic_Lift = new clsPM_Equipment_Hydraulic_Lift(PK_PM_Equipment_Hydraulic_Lift);
            if (objPM_Equipment_Hydraulic_Lift.PK_PM_Equipment != null)
                PM_Equipment = (decimal)objPM_Equipment_Hydraulic_Lift.PK_PM_Equipment;

            objPM_Equipment_Hydraulic_Lift.PK_PM_Equipment_Hydraulic_Lift = PK_PM_Equipment_Hydraulic_Lift;
            //objPM_Equipment_Hydraulic_Lift.Description = txtHydraulicLiftDescription.Text.Trim();
            //objPM_Equipment_Hydraulic_Lift.Oil_Type = txtOil_Type.Text.Trim();
            //objPM_Equipment_Hydraulic_Lift.Above_Ground = rdoAbove_Ground.SelectedValue;
            //objPM_Equipment_Hydraulic_Lift.Manufacturer_Name = txtHydraulicLiftManufacture.Text.Trim();
            ////objPM_Equipment_Hydraulic_Lift.Is_Number_Of_Lifts_At_Location = Convert.ToString(txtIs_Number_Of_Lifts_At_Location.Text.Trim());
            //if (txtNumber_Of_Lifts_At_Location.Text != "") objPM_Equipment_Hydraulic_Lift.Number_Of_Lifts_At_Location = Convert.ToInt32(txtNumber_Of_Lifts_At_Location.Text.Trim());
            //objPM_Equipment_Hydraulic_Lift.As_Of_Date_Number = clsGeneral.FormatNullDateToStore(txtAs_Of_Date_Number.Text);
            //objPM_Equipment_Hydraulic_Lift.Installation_Date = clsGeneral.FormatNullDateToStore(txtHydraulicLift_Installation_Date.Text);
            //objPM_Equipment_Hydraulic_Lift.Last_Inspection_Date = clsGeneral.FormatNullDateToStore(txtHydraulicLift_Last_Inspection_Date.Text);
            //objPM_Equipment_Hydraulic_Lift.Any_Inground_Lifts_Been_Removed = rdoAny_Inground_Lifts_Been_Removed.SelectedValue;
            //objPM_Equipment_Hydraulic_Lift.Documentation_Related_To_Removed_Lifts = rdoDocumentation_Related_To_Removed_Lifts.SelectedValue;
            objPM_Equipment_Hydraulic_Lift.Use_Same_Dates = Convert.ToString(rdbUseSameDates.SelectedValue);

            //objPM_Equipment_Hydraulic_Lift.Notes = txtHydraulicLiftNotes.Text.Trim();
            objPM_Equipment_Hydraulic_Lift.Update_Date = DateTime.Now;
            objPM_Equipment_Hydraulic_Lift.Updated_By = clsSession.UserID;
            if (PK_PM_Equipment_Hydraulic_Lift > 0)
                objPM_Equipment_Hydraulic_Lift.Update();
            if (rdbUseSameDates.SelectedValue == "Y")
            {
                clsPM_Equipment_Hydraulic_Lift_Grid.UpdateBYFK(PK_PM_Equipment_Hydraulic_Lift,clsSession.UserID, DateTime.Now);
            }
            Upload_File("");
            StrOperation = "view";
            // BindDetailsForView();
            // Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(1);", true);
            Response.Redirect("Equipment.aspx?op=view&id=" + Encryption.Encrypt(Convert.ToString(PM_Equipment)) + "&fid=" + Encryption.Encrypt(Convert.ToString(FK_PM_Site_Information)) + "&loc=" + Request.QueryString["loc"]);

        }
        //Equiptment type 'Paint Gun Cleaning Cabinet' is selected then Save Data in PM_Equipment_PGCC table
        else if (drpEquipmentType.SelectedItem.ToString().ToLower().Trim() == "paint gun cleaning cabinet")
        {
            clsPM_Equipment objPM_Equipment = new clsPM_Equipment();
            objPM_Equipment.PK_PM_Equipment = PM_Equipment;
            objPM_Equipment.FK_PM_Site_Information = FK_PM_Site_Information;
            if (drpEquipmentType.SelectedIndex > 0) objPM_Equipment.FK_LU_Equipment_Type = Convert.ToDecimal(drpEquipmentType.SelectedValue);
            objPM_Equipment.FK_Table_Name = 0;
            objPM_Equipment.Table_Name = "PM_Equipment_PGCC";
            PK_PM_Equipment_PGCC = objPM_Equipment.InsertUpdate();

            clsPM_Equipment_PGCC objPM_Equipment_PGCC = new clsPM_Equipment_PGCC(PK_PM_Equipment_PGCC);
            if (objPM_Equipment_PGCC.PK_PM_Equipment != null)
                PM_Equipment = (decimal)objPM_Equipment_PGCC.PK_PM_Equipment;

            objPM_Equipment_PGCC.PK_PM_Equipment_PGCC = PK_PM_Equipment_PGCC;
            objPM_Equipment_PGCC.Description = txtPGCCDescription.Text.Trim();
            objPM_Equipment_PGCC.Manufacturer_Name = txtPGCCManufacturer.Text.Trim();
            objPM_Equipment_PGCC.Installation_Date = clsGeneral.FormatNullDateToStore(txtPGCCInstallation_Date.Text);
            objPM_Equipment_PGCC.Water_Borne = rdoWater_Borne.SelectedValue;
            objPM_Equipment_PGCC.Solvent_Based = rdoSolvent_Based.SelectedValue;
            objPM_Equipment_PGCC.Combination_Water_Solvent = rdoCombination_Water_Solvent.SelectedValue;
            objPM_Equipment_PGCC.Notes = txtPGCCNotes.Text.Trim();
            objPM_Equipment_PGCC.Update_Date = DateTime.Now;
            objPM_Equipment_PGCC.Updated_By = clsSession.UserID;
            objPM_Equipment_PGCC.SixH_Compliant = rdbIsCabinet6HComplaint.SelectedValue;
            objPM_Equipment_PGCC.Manual_6H_Binder = rdbManualPaintGunCleaningCabinet6H.SelectedValue;

            if (PK_PM_Equipment_PGCC > 0)
                objPM_Equipment_PGCC.Update();
            Upload_File("");
            StrOperation = "view";
            // BindDetailsForView();
            //Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(1);", true);
            Response.Redirect("Equipment.aspx?op=view&id=" + Encryption.Encrypt(Convert.ToString(PM_Equipment)) + "&fid=" + Encryption.Encrypt(Convert.ToString(FK_PM_Site_Information)) + "&loc=" + Request.QueryString["loc"]);

        }
    }
    /// <summary>
    /// Handle Edit Button Click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnEdit_Click(object sender, EventArgs e)
    {
        StrOperation = "edit";
        Response.Redirect("Equipment.aspx?op=edit&id=" + Encryption.Encrypt(Convert.ToString(PM_Equipment)) + "&fid=" + Encryption.Encrypt(Convert.ToString(FK_PM_Site_Information)) + "&loc=" + Request.QueryString["loc"]);
    }

    protected void rdoInGroundLifts_SelectedIndexChanged(object sender, EventArgs e)
    {
        ShowHideReplacementLiftInformation();
        pnlHydraulicLiftType.Visible = false;
        pnlAdd_Hydraulic_Lift.Visible = true;
        btnAudit_Hydraulic_Lift.Visible = true;
        tblEquipment.Style["display"] = "none";
        GetUse_Same_Dates();
        SetValidationsHydraulic();
        Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(1);displayHydraulicLift('none');", true);
    }
    #endregion

    #region Attachments Management
    /// <summary>
    /// Binds the attachment details
    /// </summary>   
    private void BindTankAttachmentDetaills()
    {
        if (PK_PM_Equipment_Tank > 0)
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
    }
    private void BindSprayBoothAttachmentDetaills()
    {

        if (PK_PM_Equipment_Spray_Booth > 0)
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
    }
    private void BindPrepStationAttachmentDetaills()
    {

        if (PK_PM_Equipment_Prep_Station > 0)
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
    }
    private void BindOWSAttachmentDetaills()
    {
        if (PK_PM_Equipment_OWS > 0)
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
    }
    private void BindHydraulicLiftAttachmentDetaills()
    {
        if (PK_PM_Equipment_Hydraulic_Lift > 0)
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
    }
    private void BindPGCCAttachmentDetaills()
    {
        if (PK_PM_Equipment_PGCC > 0)
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
    }

    /// <summary>
    /// Attachment Control Fill Equiptment Type Selected in DropDownList Wise Bind Attachment Data
    /// </summary>
    /// <param name="strValue"></param>
    void Upload_File(string strValue)
    {
        if (drpEquipmentType.SelectedItem.ToString().ToLower().Trim() == "tank")
        {
            if (PK_PM_Equipment_Tank > 0)
            {
                // add the attachment 
                Attachment.FK_Field_Value = Convert.ToInt32(PK_PM_Equipment_Tank);
                Attachment.FK_Field_Name = "FK_Table_Name";
                Attachment.Table_Name = "PM_Equipment_Tank";
                Attachment.Add(clsGeneral.Pollution_Tables.PM_Equipment_Attachments);
                // bind the details to view added attachment
                BindTankAttachmentDetaills();
                // show the attachment panel as the page is loaded again
                Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(2);", true);
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(1);alert('Please save Equipment details first');", true);
            }
        }
        //Equiptment type 'Paint Booth' is selected then Pass Table Name 'PK_PM_Equipment_Spray_Booth' and return PK_ID from PM_Equipment_Spray_Booth Table
        else if (drpEquipmentType.SelectedItem.ToString().ToLower().Trim() == "paint booth")
        {
            if (PK_PM_Equipment_Spray_Booth > 0)
            {
                // add the attachment 
                Attachment.FK_Field_Value = Convert.ToInt32(PK_PM_Equipment_Spray_Booth);
                Attachment.FK_Field_Name = "FK_Table_Name";
                Attachment.Table_Name = "PM_Equipment_Spray_Booth";
                Attachment.Add(clsGeneral.Pollution_Tables.PM_Equipment_Attachments);
                // bind the details to view added attachment
                BindSprayBoothAttachmentDetaills();
                // show the attachment panel as the page is loaded again
                Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(2);", true);
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(1);alert('Please save Equipment details first');", true);
            }
        }
        //Equiptment type 'Prep Station' is selected then Pass Table Name 'PK_PM_Equipment_Prep_Station' and return PK_ID from PM_Equipment_Prep_Station Table
        else if (drpEquipmentType.SelectedItem.ToString().ToLower().Trim() == "prep station")
        {
            if (PK_PM_Equipment_Prep_Station > 0)
            {
                // add the attachment 
                Attachment.FK_Field_Value = Convert.ToInt32(PK_PM_Equipment_Prep_Station);
                Attachment.FK_Field_Name = "FK_Table_Name";
                Attachment.Table_Name = "PM_Equipment_Prep_Station";
                Attachment.Add(clsGeneral.Pollution_Tables.PM_Equipment_Attachments);
                // bind the details to view added attachment
                BindPrepStationAttachmentDetaills();
                // show the attachment panel as the page is loaded again
                Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(2);", true);
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(1);alert('Please save Equipment details first');", true);
            }
        }
        //Equiptment type 'Oil and Water Separator' is selected then Pass Table Name 'PM_Equipment_Tank' and return PK_ID from PM_Equipment_OWS Table
        else if (drpEquipmentType.SelectedItem.ToString().ToLower().Trim() == "oil and water separator")
        {
            if (PK_PM_Equipment_OWS > 0)
            {
                // add the attachment 
                Attachment.FK_Field_Value = Convert.ToInt32(PK_PM_Equipment_OWS);
                Attachment.FK_Field_Name = "FK_Table_Name";
                Attachment.Table_Name = "PM_Equipment_OWS";

                Attachment.Add(clsGeneral.Pollution_Tables.PM_Equipment_Attachments);
                // bind the details to view added attachment
                BindOWSAttachmentDetaills();
                // show the attachment panel as the page is loaded again
                Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(2);", true);
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(1);alert('Please save Equipment details first');", true);
            }
        }
        //Equiptment type 'Hydraulic Lift' is selected then Pass Table Name 'PK_PM_Equipment_Hydraulic_Lift' and return PK_ID from PM_Equipment_Hydraulic_Lift Table
        //Equiptment type 'Alignment Rack' is selected then Pass Table Name 'PK_PM_Equipment_Hydraulic_Lift' and return PK_ID from PM_Equipment_Hydraulic_Lift Table
        else if (drpEquipmentType.SelectedItem.ToString().ToLower().Trim() == "hydraulic lift" || drpEquipmentType.SelectedItem.ToString().ToLower().Trim() == "alignment rack")
        {
            if (PK_PM_Equipment_Hydraulic_Lift > 0)
            {
                // add the attachment 
                Attachment.FK_Field_Value = Convert.ToInt32(PK_PM_Equipment_Hydraulic_Lift);
                Attachment.FK_Field_Name = "FK_Table_Name";
                Attachment.Table_Name = "PM_Equipment_Hydraulic_Lift";
                Attachment.Add(clsGeneral.Pollution_Tables.PM_Equipment_Attachments);
                // bind the details to view added attachment
                BindHydraulicLiftAttachmentDetaills();
                // show the attachment panel as the page is loaded again
                Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(2);", true);
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(1);alert('Please save Equipment details first');", true);
            }
        }
        //Equiptment type 'Paint Gun Cleaning Cabinet' is selected then Pass Table Name 'PM_Equipment_PGCC' and return PK_ID from PM_Equipment_PGCC Table
        else if (drpEquipmentType.SelectedItem.ToString().ToLower().Trim() == "paint gun cleaning cabinet")
        {
            if (PK_PM_Equipment_PGCC > 0)
            {
                // add the attachment 
                Attachment.FK_Field_Value = Convert.ToInt32(PK_PM_Equipment_PGCC);
                Attachment.FK_Field_Name = "FK_Table_Name";
                Attachment.Table_Name = "PM_Equipment_PGCC";
                Attachment.Add(clsGeneral.Pollution_Tables.PM_Equipment_Attachments);
                // bind the details to view added attachment
                BindPGCCAttachmentDetaills();
                // show the attachment panel as the page is loaded again
                Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(2);", true);
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(1);alert('Please save Equipment details first');", true);
            }
        }
        else if (drpEquipmentType.SelectedIndex == 0)
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(1);alert('Please select Equipment Type');", true);
        }
    }

    #endregion

    #region Dynamic Validations
    /// <summary>
    /// Set all Validations
    /// </summary>
    private void SetValidationsTank()
    {
        string strCtrlsIDs = "";
        string strMessages = "";
        DataTable dtFields = clsScreen_Validators.SelectByScreen(160).Tables[0];
        dtFields.DefaultView.RowFilter = "IsRequired = '1'";
        dtFields = dtFields.DefaultView.ToTable();

        foreach (DataRow drField in dtFields.Rows)
        {
            #region " set validation control IDs and messages "
            switch (Convert.ToString(drField["Field_Name"]))
            {
                case "Manufacturer": strCtrlsIDs += txtManufacturer_Name.ClientID + ","; strMessages += "Please enter [Equipment]/Manufacturer" + ","; Span1.Style["display"] = "inline-block"; break;
                case "Description": strCtrlsIDs += txtDescription.ClientID + ","; strMessages += "Please enter [Equipment]/Description" + ","; Span2.Style["display"] = "inline-block"; break;
                case "Identification": strCtrlsIDs += txtIdentification.ClientID + ","; strMessages += "Please enter [Equipment]/Identification" + ","; Span3.Style["display"] = "inline-block"; break;
                case "Tank Contents": strCtrlsIDs += drpFK_Tank_Contents.ClientID + ","; strMessages += "Please select [Equipment]/Tank Contents" + ","; Span4.Style["display"] = "inline-block"; break;
                case "Other Contents": strCtrlsIDs += txtContents_Other.ClientID + ","; strMessages += "Please enter [Equipment]/Other Contents" + ","; Span5.Style["display"] = "inline-block"; break;
                case "Tank Material": strCtrlsIDs += drpFK_Tank_Material.ClientID + ","; strMessages += "Please select [Equipment]/Tank Material" + ","; Span6.Style["display"] = "inline-block"; break;
                case "Other Material": strCtrlsIDs += txtMaterial_Other.ClientID + ","; strMessages += "Please enter [Equipment]/Other Material" + ","; Span7.Style["display"] = "inline-block"; break;
                case "Tank Construction": strCtrlsIDs += drpFK_Tank_Construction.ClientID + ","; strMessages += "Please select [Equipment]/Tank Construction" + ","; Span8.Style["display"] = "inline-block"; break;
                case "Other Construction": strCtrlsIDs += txtConstruction_Other.ClientID + ","; strMessages += "Please enter [Equipment]/Other Construction" + ","; Span9.Style["display"] = "inline-block"; break;
                case "Tank Capacity in Gallons": strCtrlsIDs += txtCapcity.ClientID + ","; strMessages += "Please enter [Equipment]/Tank Capacity in Gallons" + ","; Span10.Style["display"] = "inline-block"; break;
                case "Certificate Number": strCtrlsIDs += txtCertificate_Number.ClientID + ","; strMessages += "Please enter [Equipment]/Certificate Number" + ","; Span11.Style["display"] = "inline-block"; break;
                case "Installation Date": strCtrlsIDs += txtInstallation_Date.ClientID + ","; strMessages += "Please enter [Equipment]/Installation Date" + ","; Span12.Style["display"] = "inline-block"; break;
                case "Installation Firm": strCtrlsIDs += txtInstallation_Firm.ClientID + ","; strMessages += "Please enter [Equipment]/Installation Firm" + ","; Span13.Style["display"] = "inline-block"; break;
                case "Last Maintenance Date": strCtrlsIDs += txtLast_Maintenance_Date.ClientID + ","; strMessages += "Please enter [Equipment]/Last Maintenance Date" + ","; Span14.Style["display"] = "inline-block"; break;
                case "Last Revision Date": strCtrlsIDs += txtLast_Revision_Date.ClientID + ","; strMessages += "Please enter [Equipment]/Last Revision Date" + ","; Span15.Style["display"] = "inline-block"; break;
                case "Last Inspection Date": strCtrlsIDs += txtLast_Inspection_Date.ClientID + ","; strMessages += "Please enter [Equipment]/Last Inspection Date" + ","; Span16.Style["display"] = "inline-block"; break;
                case "Closure Date": strCtrlsIDs += txtClosure_Date.ClientID + ","; strMessages += "Please enter [Equipment]/Closure Date" + ","; Span17.Style["display"] = "inline-block"; break;
                case "Removal Date": strCtrlsIDs += txtRemoval_Date.ClientID + ","; strMessages += "Please enter [Equipment]/Removal Date" + ","; Span18.Style["display"] = "inline-block"; break;
                case "Revised Removal Date": strCtrlsIDs += txtRevised_Removal_Date.ClientID + ","; strMessages += "Please enter [Equipment]/Revised Removal Date" + ","; Span19.Style["display"] = "inline-block"; break;
                case "Permit Begin Date": strCtrlsIDs += txtPermit_Begin_Date.ClientID + ","; strMessages += "Please enter [Equipment]/Permit Begin Date" + ","; Span20.Style["display"] = "inline-block"; break;
                case "Permit End Date": strCtrlsIDs += txtPermit_End_Date.ClientID + ","; strMessages += "Please enter [Equipment]/Permit End Date" + ","; Span21.Style["display"] = "inline-block"; break;
                case "Registration Number": strCtrlsIDs += txtRegistration_Number.ClientID + ","; strMessages += "Please enter [Equipment]/Registration Number" + ","; Span22.Style["display"] = "inline-block"; break;
                case "Leak Detection Type": strCtrlsIDs += txtLeak_Detection_Type.ClientID + ","; strMessages += "Please enter [Equipment]/Leak Detection Type" + ","; Span23.Style["display"] = "inline-block"; break;
                case "Secondary Containment Type": strCtrlsIDs += drpFK_LU_Secondary_Containment_Type.ClientID + ","; strMessages += "Please select [Equipment]/Secondary Containment Type" + ","; Span24.Style["display"] = "inline-block"; break;
                case "Description of Other Reporting Requirements": strCtrlsIDs += txtDescription_Other_Reporting_Requirements.ClientID + ","; strMessages += "Please enter [Equipment]/Description of Other Reporting Requirements" + ","; Span25.Style["display"] = "inline-block"; break;
                case "Plan Date": strCtrlsIDs += txtPlan_Date.ClientID + ","; strMessages += "Please enter [Equipment]/Plan Date" + ","; Span26.Style["display"] = "inline-block"; break;
                case "Plan Identification": strCtrlsIDs += txtPlan_Identification.ClientID + ","; strMessages += "Please enter [Equipment]/Plan Identification" + ","; Span27.Style["display"] = "inline-block"; break;
                case "Recommendations": strCtrlsIDs += txtRecommendations.ClientID + ","; strMessages += "Please enter [Equipment]/Recommendations" + ","; Span28.Style["display"] = "inline-block"; break;
                case "Effective Date": strCtrlsIDs += txtEffective_Date.ClientID + ","; strMessages += "Please enter [Equipment]/Effective Date" + ","; Span29.Style["display"] = "inline-block"; break;
                case "Expiration Date": strCtrlsIDs += txtExpiration_Date.ClientID + ","; strMessages += "Please enter [Equipment]/Expiration Date" + ","; Span30.Style["display"] = "inline-block"; break;
                case "Record Keeping Requirements": strCtrlsIDs += txtRecordkeeping_Requirements.ClientID + ","; strMessages += "Please enter [Equipment]/Record Keeping Requirements" + ","; Span31.Style["display"] = "inline-block"; break;
                //case "Inadvertent Release Control and Countermeasures Plan": strCtrlsIDs += txtRelease_Control_Countermeasures_Plan.ClientID + ","; strMessages += "Please enter [Equipment]/Inadvertent Release Control and Countermeasures Plan" + ","; Span32.Style["display"] = "inline-block"; break;    //* :3187 *// 
                case "Maintenance Vendor": strCtrlsIDs += txtMaintenance_Vendor.ClientID + ","; strMessages += "Please enter [Equipment]/Maintenance Vendor" + ","; Span33.Style["display"] = "inline-block"; break;
                case "Vendor Contact Name": strCtrlsIDs += txtVendor_Contact_Name.ClientID + ","; strMessages += "Please enter [Equipment]/Vendor Contact Name" + ","; Span34.Style["display"] = "inline-block"; break;
                case "Vendor Contact Telephone": strCtrlsIDs += txtVendor_Contact_Telephone.ClientID + ","; strMessages += "Please enter [Equipment]/Vendor Contact Telephone" + ","; Span35.Style["display"] = "inline-block"; break;
                case "Insurer": strCtrlsIDs += txtInsurer.ClientID + ","; strMessages += "Please enter [Equipment]/Insurer" + ","; Span36.Style["display"] = "inline-block"; break;
                case "Coverage Start Date": strCtrlsIDs += txtCoverage_Start_Date.ClientID + ","; strMessages += "Please enter [Equipment]/Coverage Start Date" + ","; Span37.Style["display"] = "inline-block"; break;
                case "Coverage End Date": strCtrlsIDs += txtCoverage_End_Date.ClientID + ","; strMessages += "Please enter [Equipment]/Coverage End Date" + ","; Span38.Style["display"] = "inline-block"; break;
                case "Multiple Event/Total Coverage": strCtrlsIDs += txtMultiple_Event_Total_Coverage.ClientID + ","; strMessages += "Please enter [Equipment]/Multiple Event/Total Coverage" + ","; Span39.Style["display"] = "inline-block"; break;
                case "Single Event Coverage": strCtrlsIDs += txtSingle_Event_Coverage.ClientID + ","; strMessages += "Please enter [Equipment]/Single Event Coverage" + ","; Span40.Style["display"] = "inline-block"; break;
                case "Inspection Company": strCtrlsIDs += txtInspection_Company.ClientID + ","; strMessages += "Please enter [Equipment]/Inspection Company" + ","; Span41.Style["display"] = "inline-block"; break;
                case "Inspection Company Contact Name": strCtrlsIDs += txtInspection_Company_Contact_Name.ClientID + ","; strMessages += "Please enter [Equipment]/Inspection Company Contact Name" + ","; Span42.Style["display"] = "inline-block"; break;
                case "Inspection Company Contact Telephone": strCtrlsIDs += txtInspection_Company_Contact_Telephone.ClientID + ","; strMessages += "Please enter [Equipment]/Inspection Company Contact Telephone" + ","; Span43.Style["display"] = "inline-block"; break;
                case "Notes": strCtrlsIDs += txtNotes.ClientID + ","; strMessages += "Please enter [Equipment]/Notes" + ","; Span44.Style["display"] = "inline-block"; break;
                case "SPCC Date Developed": strCtrlsIDs += txtSPCCDate_Developed.ClientID + ","; strMessages += "Please enter [Equipment]/SPCC Date Developed" + ","; Span32.Style["display"] = "inline-block"; break;
                case "SPCC Expiration Date": strCtrlsIDs += txtSPCCExpiration_Date.ClientID + ","; strMessages += "Please enter [Equipment]/SPCC Expiration Date" + ","; Span72.Style["display"] = "inline-block"; break;
            }
            #endregion
        }

        strCtrlsIDs = strCtrlsIDs.TrimEnd(',');
        strMessages = strMessages.TrimEnd(',');

        hdnControlIDsTank.Value = strCtrlsIDs;
        hdnErrorMsgsTank.Value = strMessages;
    }

    private void SetValidationsPaintBooth()
    {
        string strCtrlsIDs = "";
        string strMessages = "";


        DataTable dtFields = clsScreen_Validators.SelectByScreen(161).Tables[0];
        dtFields.DefaultView.RowFilter = "IsRequired = '1'";
        dtFields = dtFields.DefaultView.ToTable();


        foreach (DataRow drField in dtFields.Rows)
        {
            #region " set validation control IDs and messages "
            switch (Convert.ToString(drField["Field_Name"]))
            {
                case "Description": strCtrlsIDs += txtSprayBoothDesc.ClientID + ","; strMessages += "Please enter [Equipment]/Description" + ","; Span45.Style["display"] = "inline-block"; break;
                case "Manufacturer Name": strCtrlsIDs += txtManufacturer_Name.ClientID + ","; strMessages += "Please enter [Equipment]/Manufacturer Name" + ","; Span46.Style["display"] = "inline-block"; break;
                case "Installation Date": strCtrlsIDs += txtInstallationDate.ClientID + ","; strMessages += "Please enter [Equipment]/Installation Date" + ","; Span47.Style["display"] = "inline-block"; break;
                case "BTU Rating": strCtrlsIDs += txtBTU_Rating.ClientID + ","; strMessages += "Please enter [Equipment]/BTU Rating" + ","; Span48.Style["display"] = "inline-block"; break;
                case "Height In Feet": strCtrlsIDs += txtHeight_In_Feet.ClientID + ","; strMessages += "Please enter [Equipment]/Height In Feet" + ","; Span49.Style["display"] = "inline-block"; break;
                case "Width in Feet": strCtrlsIDs += txtWidth_In_Feet.ClientID + ","; strMessages += "Please enter [Equipment]/Width in Feet" + ","; Span50.Style["display"] = "inline-block"; break;
                case "Depth in Feet": strCtrlsIDs += txtDepth_In_Feet.ClientID + ","; strMessages += "Please enter [Equipment]/Depth in Feet" + ","; Span51.Style["display"] = "inline-block"; break;
                case "Filter Technology": strCtrlsIDs += txtFilter_System.ClientID + ","; strMessages += "Please enter [Equipment]/Filter Technology" + ","; Span52.Style["display"] = "inline-block"; break;
                case "Filter Capture Efficiency": strCtrlsIDs += txtCapture_Efficiency.ClientID + ","; strMessages += "Please enter [Equipment]/Filter Capture Efficiency" + ","; Span53.Style["display"] = "inline-block"; break;
                case "Control Efficiency": strCtrlsIDs += txtControl_Efficiency.ClientID + ","; strMessages += "Please enter [Equipment]/Control Efficiency" + ","; Span54.Style["display"] = "inline-block"; break;
                case "Capture Efficiency as of Date": strCtrlsIDs += txtCapture_Efficiency.ClientID + ","; strMessages += "Please enter [Equipment]/Capture Efficiency as of Date" + ","; Span55.Style["display"] = "inline-block"; break;
                case "Control Efficiency as of Date": strCtrlsIDs += txtControlEfficiencyDate.ClientID + ","; strMessages += "Please enter [Equipment]/Control Efficiency as of Date" + ","; Span56.Style["display"] = "inline-block"; break;
                case "Stack Height Above Grade in Feet": strCtrlsIDs += txtStack_Height_In_Feet.ClientID + ","; strMessages += "Please enter [Equipment]/Stack Height Above Grade in Feet" + ","; Span57.Style["display"] = "inline-block"; break;
                case "Exit Flow Rate in Cubic Feet Per Minute": strCtrlsIDs += txtExit_Flow_Rate_CFM.ClientID + ","; strMessages += "Please enter [Equipment]/Exit Flow Rate in Cubic Feet Per Minute" + ","; Span58.Style["display"] = "inline-block"; break;
                case "Exit Temperature (Low) Degrees Farenheight": strCtrlsIDs += txtExit_Temperature_Low.ClientID + ","; strMessages += "Please enter [Equipment]/Exit Temperature (Low) Degrees Farenheight" + ","; Span59.Style["display"] = "inline-block"; break;
                case "Exit Temperature (High) Degrees Farenheight": strCtrlsIDs += txtExit_Temperature_High.ClientID + ","; strMessages += "Please enter [Equipment]/Exit Temperature (High) Degrees Farenheight" + ","; Span60.Style["display"] = "inline-block"; break;
                case "Notes": strCtrlsIDs += txtSprayBoothNotes.ClientID + ","; strMessages += "Please enter [Equipment]/Notes" + ","; Span61.Style["display"] = "inline-block"; break;
            }
            #endregion
        }

        strCtrlsIDs = strCtrlsIDs.TrimEnd(',');
        strMessages = strMessages.TrimEnd(',');

        hdnControlIDsSprayBooth.Value = strCtrlsIDs;
        hdnErrorMsgsSprayBooth.Value = strMessages;
    }

    private void SetValidationsPrepStation()
    {
        string strCtrlsIDs = "";
        string strMessages = "";


        DataTable dtFields = clsScreen_Validators.SelectByScreen(173).Tables[0];
        dtFields.DefaultView.RowFilter = "IsRequired = '1'";
        dtFields = dtFields.DefaultView.ToTable();


        foreach (DataRow drField in dtFields.Rows)
        {
            #region " set validation control IDs and messages "
            switch (Convert.ToString(drField["Field_Name"]))
            {
                case "Description": strCtrlsIDs += txtPrepStationDesc.ClientID + ","; strMessages += "Please enter [Equipment]/Description" + ","; Span86.Style["display"] = "inline-block"; break;
                case "Manufacturer Name": strCtrlsIDs += txtManufacturer_Name_PrepStation.ClientID + ","; strMessages += "Please enter [Equipment]/Manufacturer Name" + ","; Span87.Style["display"] = "inline-block"; break;
                case "Installation Date": strCtrlsIDs += txtInstallationDate_PrepStation.ClientID + ","; strMessages += "Please enter [Equipment]/Installation Date" + ","; Span88.Style["display"] = "inline-block"; break;
                case "BTU Rating": strCtrlsIDs += txtBTU_Rating_PrepStation.ClientID + ","; strMessages += "Please enter [Equipment]/BTU Rating" + ","; Span89.Style["display"] = "inline-block"; break;
                case "Height In Feet": strCtrlsIDs += txtHeight_In_Feet_PrepStation.ClientID + ","; strMessages += "Please enter [Equipment]/Height In Feet" + ","; Span90.Style["display"] = "inline-block"; break;
                case "Width in Feet": strCtrlsIDs += txtWidth_In_Feet_PrepStation.ClientID + ","; strMessages += "Please enter [Equipment]/Width in Feet" + ","; Span91.Style["display"] = "inline-block"; break;
                case "Depth in Feet": strCtrlsIDs += txtDepth_In_Feet_PrepStation.ClientID + ","; strMessages += "Please enter [Equipment]/Depth in Feet" + ","; Span92.Style["display"] = "inline-block"; break;
                case "Filter Technology": strCtrlsIDs += txtFilter_System_PrepStation.ClientID + ","; strMessages += "Please enter [Equipment]/Filter Technology" + ","; Span93.Style["display"] = "inline-block"; break;
                case "Filter Capture Efficiency": strCtrlsIDs += txtCapture_Efficiency_PrepStation.ClientID + ","; strMessages += "Please enter [Equipment]/Filter Capture Efficiency" + ","; Span94.Style["display"] = "inline-block"; break;
                case "Control Efficiency": strCtrlsIDs += txtControl_Efficiency_PrepStation.ClientID + ","; strMessages += "Please enter [Equipment]/Control Efficiency" + ","; Span95.Style["display"] = "inline-block"; break;
                case "Capture Efficiency as of Date": strCtrlsIDs += txtCapture_Efficiency_PrepStation.ClientID + ","; strMessages += "Please enter [Equipment]/Capture Efficiency as of Date" + ","; Span96.Style["display"] = "inline-block"; break;
                case "Control Efficiency as of Date": strCtrlsIDs += txtControlEfficiencyDate_PrepStation.ClientID + ","; strMessages += "Please enter [Equipment]/Control Efficiency as of Date" + ","; Span97.Style["display"] = "inline-block"; break;
                case "Stack Height Above Grade in Feet": strCtrlsIDs += txtStack_Height_In_Feet_PrepStation.ClientID + ","; strMessages += "Please enter [Equipment]/Stack Height Above Grade in Feet" + ","; Span98.Style["display"] = "inline-block"; break;
                case "Exit Flow Rate in Cubic Feet Per Minute": strCtrlsIDs += txtExit_Flow_Rate_CFM_PrepStation.ClientID + ","; strMessages += "Please enter [Equipment]/Exit Flow Rate in Cubic Feet Per Minute" + ","; Span99.Style["display"] = "inline-block"; break;
                case "Exit Temperature (Low) Degrees Farenheight": strCtrlsIDs += txtExit_Temperature_Low_PrepStation.ClientID + ","; strMessages += "Please enter [Equipment]/Exit Temperature (Low) Degrees Farenheight" + ","; Span100.Style["display"] = "inline-block"; break;
                case "Exit Temperature (High) Degrees Farenheight": strCtrlsIDs += txtExit_Temperature_High_PrepStation.ClientID + ","; strMessages += "Please enter [Equipment]/Exit Temperature (High) Degrees Farenheight" + ","; Span101.Style["display"] = "inline-block"; break;
                case "Notes": strCtrlsIDs += txtPrepStationNotes.ClientID + ","; strMessages += "Please enter [Equipment]/Notes" + ","; Span102.Style["display"] = "inline-block"; break;
            }
            #endregion
        }

        strCtrlsIDs = strCtrlsIDs.TrimEnd(',');
        strMessages = strMessages.TrimEnd(',');

        hdnControlIDsPrepStation.Value = strCtrlsIDs;
        hdnErrorMsgsPrepStation.Value = strMessages;
    }

    private void SetValidationsOWS()
    {
        string strCtrlsIDs = "";
        string strMessages = "";

        string strCtrlsIDs2 = "";
        string strMessages2 = "";

        DataTable dtFields = clsScreen_Validators.SelectByScreen(162).Tables[0];
        dtFields.DefaultView.RowFilter = "IsRequired = '1'";
        dtFields = dtFields.DefaultView.ToTable();

        foreach (DataRow drField in dtFields.Rows)
        {
            #region " set validation control IDs and messages "
            switch (Convert.ToString(drField["Field_Name"]))
            {
                case "Description": strCtrlsIDs += txtOWSDescription.ClientID + ","; strMessages += "Please enter [Equipment]/Description" + ","; Span62.Style["display"] = "inline-block"; break;
                case "Installation Date": strCtrlsIDs += txtOWS_Installation_Date.ClientID + ","; strMessages += "Please enter [Equipment]/Installation Date" + ","; Span63.Style["display"] = "inline-block"; break;
                case "Manufacturer": strCtrlsIDs += txtOWSManufacturer_Name.ClientID + ","; strMessages += "Please enter [Equipment]/Manufacturer" + ","; Span64.Style["display"] = "inline-block"; break;
                case "Service Provider": strCtrlsIDs += txtOWSInspectionCompany.ClientID + ","; strMessages += "Please enter [Equipment]/Service Provider" + ","; Span65.Style["display"] = "inline-block"; break;
                case "Service Provider Contact Person": strCtrlsIDs += txtInspectionCompanyContactName.ClientID + ","; strMessages += "Please enter [Equipment]/Service Provider Contact Person" + ","; Span66.Style["display"] = "inline-block"; break;
                case "Service Provider Telephone Number": strCtrlsIDs += txtOWSTelephone.ClientID + ","; strMessages += "Please enter [Equipment]/Service Provider Contact Telephone" + ","; Span67.Style["display"] = "inline-block"; break;
                case "Notes": strCtrlsIDs += txtOWSNotes.ClientID + ","; strMessages += "Please enter [Equipment]/Notes" + ","; Span68.Style["display"] = "inline-block"; break;

                case "Sludge Removal Date Grid - Sludge Removal Date": strCtrlsIDs2 += txtSludgeRemovalDate.ClientID + ","; strMessages2 += "Please enter [Equipment]/Sludge Removal Date" + ","; Span69.Style["display"] = "inline-block"; break;
                case "Sludge Removal Date Grid - TCLP Conducted Date": strCtrlsIDs2 += txtTCLPConductedDate.ClientID + ","; strMessages2 += "Please enter [Equipment]/TCLP Conducted Date" + ","; Span85.Style["display"] = "inline-block"; break;
                case "Sludge Removal Date Grid - Sludge Removed By": strCtrlsIDs2 += txtSludgeRemovedBy.ClientID + ","; strMessages2 += "Please enter [Equipment]/Sludge Removed By" + ","; Span70.Style["display"] = "inline-block"; break;
                case "Sludge Removal Date Grid - Notes": strCtrlsIDs2 += txtSludgeNotes.ClientID + ","; strMessages2 += "Please enter [Equipment]/Notes" + ","; Span71.Style["display"] = "inline-block"; break;
            }
            #endregion
        }

        strCtrlsIDs = strCtrlsIDs.TrimEnd(',');
        strMessages = strMessages.TrimEnd(',');
        strCtrlsIDs2 = strCtrlsIDs2.TrimEnd(',');
        strMessages2 = strMessages2.TrimEnd(',');

        hdnControlIDsOWS.Value = strCtrlsIDs;
        hdnErrorMsgsOWS.Value = strMessages;
        hdnControlIDsOWSInnerGrid.Value = strCtrlsIDs2;
        hdnErrorMsgsOWSInnerGrid.Value = strMessages2;
    }

    private void SetValidationsHydraulic()
    {
        string strCtrlsIDs = "";
        string strMessages = "";
        string strLiftRack = string.Empty;         
        if(spLiftNumber.InnerText != null)
            strLiftRack = spLiftNumber.InnerText;
        Session["LiftRack"] = strLiftRack;

        revAs_Of_Date_Number.ErrorMessage = "[Equipment]/" + strLiftRack +" Number As of Date is not a valid date";

        DataTable dtFields = clsScreen_Validators.SelectByScreen(163).Tables[0];
        dtFields.DefaultView.RowFilter = "IsRequired = '1'";
        dtFields = dtFields.DefaultView.ToTable();


        foreach (DataRow drField in dtFields.Rows)
        {            
            #region " set validation control IDs and messages "
            switch (Convert.ToString(drField["Field_Name"]))
            {
                case "Lift Number": strCtrlsIDs += txtNumber_Of_Lifts_At_Location.ClientID + ","; strMessages += "Please enter [Equipment]/" + strLiftRack + " Number" + ","; Span103.Style["display"] = "inline-block"; break;
                case "As of Date (Number)": strCtrlsIDs += txtAs_Of_Date_Number.ClientID + ","; strMessages += "Please enter [Equipment]/" + strLiftRack + " Number As of Date" + ","; Span104.Style["display"] = "inline-block"; break;
                case "Description": strCtrlsIDs += txtHydraulicLiftDescription.ClientID + ","; strMessages += "Please enter [Equipment]/Description" + ","; Span105.Style["display"] = "inline-block"; break;
                case "Oil Type": strCtrlsIDs += txtOil_Type.ClientID + ","; strMessages += "Please enter [Equipment]/Oil Type" + ","; Span106.Style["display"] = "inline-block"; break;
                case "Manufacturer": strCtrlsIDs += txtHydraulicLiftManufacture.ClientID + ","; strMessages += "Please enter [Equipment]/Manufacturer" + ","; Span107.Style["display"] = "inline-block"; break;
                //case "Number of Lifts at the Location?": strCtrlsIDs += txtIs_Number_Of_Lifts_At_Location.ClientID + ","; strMessages += "Please enter [Equipment]/Number of Lifts at the Location?" + ","; Span75.Style["display"] = "inline-block"; break;
                case "Installation Date": strCtrlsIDs += txtHydraulicLift_Installation_Date.ClientID + ","; strMessages += "Please enter [Equipment]/Installation Date" + ","; Span108.Style["display"] = "inline-block"; break;
                case "Last Annual Inspection Date": strCtrlsIDs += txtHydraulicLift_Last_Inspection_Date.ClientID + ","; strMessages += "Please enter [Equipment]/Last Annual Inspection Date" + ","; Span109.Style["display"] = "inline-block"; break;
                case "Removal Date": strCtrlsIDs += txtHydraulicLift_Removal_Date.ClientID + ","; strMessages += "Please enter [Equipment]/Removal Date" + ","; Span110.Style["display"] = "inline-block"; break;
                case "Notes": strCtrlsIDs += txtHydraulicLiftNotes.ClientID + ","; strMessages += "Please enter [Equipment]/Notes" + ","; Span111.Style["display"] = "inline-block"; break;

                //3187
                case "Replacement Description": strCtrlsIDs += txtReplacementLiftDescription.ClientID + ","; strMessages += "Please enter [Equipment]/Replacement Description" + ","; spnReplacementLiftDescription.Style["display"] = "inline-block"; break;
                case "Replacement Oil Type": strCtrlsIDs += txtReplacementOilType.ClientID + ","; strMessages += "Please enter [Equipment]/Replacement Oil Type" + ","; spnOilType.Style["display"] = "inline-block"; break;
                case "Replacement Manufacturer": strCtrlsIDs += txtManufacturer.ClientID + ","; strMessages += "Please enter [Equipment]/Replacement Manufacturer" + ","; spnManufacturer.Style["display"] = "inline-block"; break;
                case "Replacement Installation Date": strCtrlsIDs += txtReplacementInstallationDate.ClientID + ","; strMessages += "Please enter [Equipment]/Replacement Installation Date" + ","; spnReplacementInstallationDate.Style["display"] = "inline-block"; break;
                case "Replacement Last Annual Inspection Date": strCtrlsIDs += txtReplacementLastAnnualInspectionDate.ClientID + ","; strMessages += "Please enter [Equipment]/Replacement Last Annual Inspection Date" + ","; spnReplacementLastAnnualInspectionDate.Style["display"] = "inline-block"; break;
                case "Replacement Notes": strCtrlsIDs += txtReplacementNotes.ClientID + ","; strMessages += "Please enter [Equipment]/Replacement Notes" + ","; spnReplacementNotes.Style["display"] = "inline-block"; break;                
                
            }
            #endregion
        }

        strCtrlsIDs = strCtrlsIDs.TrimEnd(',');
        strMessages = strMessages.TrimEnd(',');

        hdnControlIDsHydraulicLiftGrid.Value = strCtrlsIDs;
        hdnErrorMsgsHydraulicLiftGrid.Value = strMessages;
    }

    private void SetValidationsPGCC()
    {
        string strCtrlsIDs = "";
        string strMessages = "";


        DataTable dtFields = clsScreen_Validators.SelectByScreen(164).Tables[0];
        dtFields.DefaultView.RowFilter = "IsRequired = '1'";
        dtFields = dtFields.DefaultView.ToTable();

        foreach (DataRow drField in dtFields.Rows)
        {
            #region " set validation control IDs and messages "
            switch (Convert.ToString(drField["Field_Name"]))
            {
                case "Description": strCtrlsIDs += txtPGCCDescription.ClientID + ","; strMessages += "Please enter [Equipment]/Description" + ","; Span81.Style["display"] = "inline-block"; break;
                case "Manufacturer": strCtrlsIDs += txtPGCCManufacturer.ClientID + ","; strMessages += "Please enter [Equipment]/Manufacturer" + ","; Span82.Style["display"] = "inline-block"; break;
                case "Installation Date": strCtrlsIDs += txtPGCCInstallation_Date.ClientID + ","; strMessages += "Please enter [Equipment]/Installation Date" + ","; Span83.Style["display"] = "inline-block"; break;
                case "Notes": strCtrlsIDs += txtPGCCNotes.ClientID + ","; strMessages += "Please enter [Equipment]/Notes" + ","; Span84.Style["display"] = "inline-block"; break;
            }
            #endregion
        }

        strCtrlsIDs = strCtrlsIDs.TrimEnd(',');
        strMessages = strMessages.TrimEnd(',');

        hdnControlIDsPGCC.Value = strCtrlsIDs;
        hdnErrorMsgsPGCC.Value = strMessages;
    }
    #endregion       

    
}
