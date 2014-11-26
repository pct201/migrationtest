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
using System.IO;
using ERIMS.DAL;
using DAL;

/// <summary>
/// Date : 9 OCT 2008
/// 
/// By : Hetal Prajapati
/// 
/// Purpose: 
/// To Add, update and remove the Property records
/// 
/// Functionality:
/// Lists the Property records having the location selected
/// 
/// By selecting the record the page controls display information about that either in
/// edit or view mode depending on the operation passed in querystring
/// 
/// Save & View button click shows the record in view mode
/// 
/// Back button click opens the page in edit mode
/// </summary>
public partial class Exposures_Property : clsBasePage
{
    #region "Properties"
    /// <summary>
    /// Denotes Location ID to be used as FK
    /// </summary>
    private int FK_LU_Location_ID
    {
        get { return Convert.ToInt32(ViewState["FK_LU_Location_ID"]); }
        set { ViewState["FK_LU_Location_ID"] = value; }
    }

    /// <summary>
    /// Denotes PK for Property_Cope table
    /// </summary>
    public int PK_Property_Cope_ID
    {
        get { return Convert.ToInt32(ViewState["PK_Property_Cope_ID"]); }
        set { ViewState["PK_Property_Cope_ID"] = value; }
    }

    /// <summary>
    /// Denotes PK for Building table
    /// </summary>
    public int PK_Building_ID
    {
        get { return Convert.ToInt32(ViewState["PK_Building_ID"]); }
        set
        {
            ViewState["PK_Building_ID"] = value; hdnBuildingID.Value = value.ToString();
        }
    }

    /// <summary>
    /// Denotes PK for Building_ownership table
    /// </summary>
    private int PK_Building_Ownership
    {
        get { return Convert.ToInt32(ViewState["PK_Building_Ownership"]); }
        set
        {
            ViewState["PK_Building_Ownership"] = value; hdnBuildingOwnershipID.Value = value.ToString();
        }
    }

    /// <summary>
    /// Denotes PK for Building_Additional_Insureds table
    /// </summary>
    private int PK_Building_Additional_Insureds
    {
        get { return Convert.ToInt32(ViewState["PK_Building_Additional_Insureds"]); }
        set { ViewState["PK_Building_Additional_Insureds"] = value; hdnAdditionalInsured.Value = value.ToString(); }
    }

    /// <summary>
    /// Denotes PK for Building_Payee table
    /// </summary>
    private int PK_Building_Payee
    {
        get { return Convert.ToInt32(ViewState["PK_Building_Payee"]); }
        set { ViewState["PK_Building_Payee"] = value; hdnLossPayeeID.Value = value.ToString(); }
    }

    /// <summary>
    /// Denotes PK for Building_OwnershipSubLease table
    /// </summary>
    private int PK_Building_OwnershipSubLease
    {
        get { return Convert.ToInt32(ViewState["PK_Building_Ownership_Sublease"]); }
        set { ViewState["PK_Building_Ownership_Sublease"] = value; hdnSubLeaseID.Value = value.ToString(); }
    }

    /// <summary>
    /// Denotes PK for Property_Assessment table
    /// </summary>
    private int PK_Property_Assessment_ID
    {
        get { return Convert.ToInt32(ViewState["PK_Property_Assessment_ID"]); }
        set { ViewState["PK_Property_Assessment_ID"] = value; hdnAssessmentID.Value = value.ToString(); }
    }

    /// <summary>
    /// Denotes PK for Property_Assessment_Concern table
    /// </summary>
    private int PK_Property_Assessment_Concern_ID
    {
        get { return Convert.ToInt32(ViewState["PK_Property_Assessment_Concern_ID"]); }
        set { ViewState["PK_Property_Assessment_Concern_ID"] = value; hdnAssessmentConcernID.Value = value.ToString(); }
    }

    /// <summary>
    /// Denotes PK for Property_Contact table
    /// </summary>
    private int PK_Property_Contact_ID
    {
        get { return Convert.ToInt32(ViewState["PK_Property_Contact_ID"]); }
        set { ViewState["PK_Property_Contact_ID"] = value; hdnContacts.Value = value.ToString(); }
    }

    /// <summary>
    /// Denotes operation for page in either in view or edit mode
    /// </summary>
    public string strOperation
    {
        get { return ViewState["strOperation"].ToString(); }
        set { ViewState["strOperation"] = value; }
    }

    /// <summary>
    /// Denotes PK for Property_Cope_Saba_Training table
    /// </summary>
    public int PK_Property_Cope_Saba_Training
    {
        get { return Convert.ToInt32(ViewState["PK_Property_Cope_Saba_Training"]); }
        set { ViewState["PK_Property_Cope_Saba_Training"] = value; }
    }

    #endregion

    #region "Page Events"
    /// <summary>
    /// Handles event when page is loaded
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        SetDynamicInsuranceControl();
        // Set Tab selection
        Tab.SetSelectedTab(Controls_ExposuresTab_ExposuresTab.Tab.Property);
        //used to check Page Post Back Event
        if (!IsPostBack)
        {   
            // Check if User has right To Add or Edit 
            if (App_Access == AccessType.View_Only)
            {
                Response.Redirect(AppConfig.SiteURL + "Error.aspx?msg=errAcc", true);
            }

            // bind dropdowns required for adding values
            BindDropDowns();
            
            // check for the location id is passed in querystring
            if (Request.QueryString["loc"] != null)
            {
                int loc;
                if (int.TryParse(Encryption.Decrypt(Request.QueryString["loc"]), out loc))
                {
                    FK_LU_Location_ID = loc;
                }
                else
                    Response.Redirect("ExposureSearch.aspx");
                                
                // set opertation for page
                strOperation = (Request.QueryString["op"] != null) ? "edit" : "";

                // store the location value in session
                Session["ExposureLocation"] = FK_LU_Location_ID;

                ucCtrlExposureInfo.PK_LU_Location = FK_LU_Location_ID;
                ucCtrlExposureInfo.BindExposureInfo();
                PK_Property_Cope_ID = Property_COPE.SelectPKByLocation(FK_LU_Location_ID);

                // check for PK is available or not
                if (PK_Property_Cope_ID > 0)
                    BindDetailsForEdit();

                // bind location information
                BindLocationInformation();

                // Bind all grids referring to the location
                BindGridBuilding();
                BindGridBusinessInterruption();
                BindGridAssessment();
                BindEmergencyContactGrid();
                BindUtilityContactGrid();
                BindOtherContactGrid();
                BindBuildingImprovementGrid();
                BindBuildingFinancialLimitGrid();
                BindBuildingGGKLGrid();
                BindSubLeaseGrid();


                SetValidationsPropertyCope();
                SetValidationsBuildingInfo();
                SetValidationsOwnershipDetails();
                SetValidationspropertyConditionAssess();
                SetValidationsContact();
                SetValidationsSabaTraining();
                SetValidationsAdditionalInsureds();
                SetValidationsLossPayee();
                SetValidationBuildingOwnershipSubLease();

                if (Request.QueryString["build"] != null)
                {
                    int decID;
                    if (int.TryParse(Encryption.Decrypt(Request.QueryString["build"]), out decID)) PK_Building_ID = decID;
                    {
                        BindBuildingDetails();
                        
                        BindInuranceDetailForEdit(PK_Building_ID);
                    }
                    ScriptManager.RegisterStartupScript(Page, GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(2);", true);
                }
                else
                    ScriptManager.RegisterStartupScript(Page, GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(1);", true);
            }
            else
                Response.Redirect("ExposureSearch.aspx");
        }
    }

    #region "Control Events"

    #region "SAVE BUTTON CLICKS"

    /// <summary>
    /// Handles Save & Next button click in Property Cope panel
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnPropertyCopeSave_Click(object sender, EventArgs e)
    {

        SavePropertyCope();

        // display next panel
        ScriptManager.RegisterClientScriptBlock(Page, GetType(), DateTime.Now.ToString(), "ShowPanel(2);", true);
    }

    /// <summary>
    /// Handles Save button click in Saba Training Panel
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSaveSabaTraining_Click(object sender, EventArgs e)
    {
        Property_COPE_Saba_Training objSabaTraining = new Property_COPE_Saba_Training();
        objSabaTraining.PK_Property_COPE_Saba_Training = 0;
        objSabaTraining.FK_Property_COPE = PK_Property_Cope_ID;
        objSabaTraining.Date = clsGeneral.FormatNullDateToStore(txtSaba_Training_Date.Text);

        if (txtSaba_Training_Date.Text == "")
        {
            objSabaTraining.Year = Convert.ToInt32(drpSabaTrainingYear.SelectedValue);
            objSabaTraining.Quarter = Convert.ToInt32(drpQuarter.SelectedValue);
        }

        if (!string.IsNullOrEmpty(hdnPKPropertySabaTraning.Value))
            objSabaTraining.PK_Property_COPE_Saba_Training = Convert.ToDecimal(hdnPKPropertySabaTraning.Value);
        if (!string.IsNullOrEmpty(txtNumber_of_Employees.Text))
            objSabaTraining.Number_of_Employees = clsGeneral.GetDecimalValue(txtNumber_of_Employees);
        if (!string.IsNullOrEmpty(txtNumber_of_Employees_To_Date.Text))
            objSabaTraining.Number_Trained = clsGeneral.GetDecimalValue(txtNumber_of_Employees_To_Date);
        if (!string.IsNullOrEmpty(txtPercent_Employee_to_Date.Text))
            objSabaTraining.Percent_Trained = Convert.ToDecimal(Request.Form[txtPercent_Employee_to_Date.UniqueID]);
        objSabaTraining.Update_Date = DateTime.Now;
        objSabaTraining.Updated_By = clsSession.UserID;

        int retValue = 0;
        if (objSabaTraining.PK_Property_COPE_Saba_Training > 0)
            retValue = objSabaTraining.Update();
        else
            retValue = objSabaTraining.Insert();

        if (retValue > 0)
        {
            gvSabaTraining.DataSource = Property_COPE_Saba_Training.SelectByProperty_Cope(PK_Property_Cope_ID);
            gvSabaTraining.DataBind();
            ScriptManager.RegisterStartupScript(Page, GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(1);", true);
        }
        else
        {
            if (retValue == -1)
            {
                trSabaTrainingQuarter.Style["display"] = trSabaTrainingYear.Style["display"] = "none";
                ScriptManager.RegisterStartupScript(Page, GetType(), DateTime.Now.ToString(), "javascript:alert('Saba Training for selected Date already exists in current Property Cope');", true);
            }
            else if (retValue == -2)
                ScriptManager.RegisterStartupScript(Page, GetType(), DateTime.Now.ToString(), "javascript:alert('Saba Training for selected Year and Quarter already exists in current Property Cope');", true);
        }
    }

    /// <summary>
    /// Handles Save & Next button click in Building panel
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnBuildingInformationSave_Click(object sender, EventArgs e)
    {
        // create object for Building class
        Building objBuilding = new Building();
        objBuilding.PK_Building_ID = PK_Building_ID;
        objBuilding.FK_LU_Location_ID = FK_LU_Location_ID;


        #region " GET BUILDING INFO FROM PAGE CONTROLS"

        #region "Guard system "
        objBuilding.Guard_System = clsGeneral.FormatYesNoToStore(rdoGuard_System);
        if (objBuilding.Guard_System == true)
        {
            objBuilding.Guard_System_Name = txtGuard_System.Text.Trim();
            objBuilding.Guard_Contact_Name = txtGuard_Contact_Name.Text.Trim();
            objBuilding.Guard_Vendor_Name = txtGuard_Vendor_Name.Text.Trim();
            objBuilding.Guard_Contact_Expiration_Date = clsGeneral.FormatDateToStore(txtGuard_Contact_Expiration_Date);
            objBuilding.Guard_Address_1 = txtGuard_Address_1.Text.Trim();
            objBuilding.Guard_Address_2 = txtGuard_Address_2.Text.Trim();
            objBuilding.Guard_City = txtGuard_City.Text.Trim();
            objBuilding.Guard_State = ddlGuard_State.SelectedValue;
            objBuilding.Guard_Zip = txtGuard_Zip.Text.Trim();
            objBuilding.Guard_Telephone_Number = txtGuard_Telephone_Number.Text.Trim();
            objBuilding.Guard_Alternate_Number = txtGuard_Alternate_Number.Text.Trim();
            objBuilding.Guard_Email = txtGuard_Email.Text.Trim();
            objBuilding.Guard_Comments = txtGuard_Comments.Text.Trim();
            trGuardSystem.Style["display"] = "";
        }
        else
        {
            txtGuard_Contact_Name.Text = "";
            txtGuard_Vendor_Name.Text = "";
            txtGuard_Contact_Expiration_Date.Text = "";
            txtGuard_Address_1.Text = "";
            txtGuard_Address_2.Text = "";
            txtGuard_City.Text = "";
            ddlGuard_State.SelectedValue = "";
            txtGuard_Zip.Text = "";
            txtGuard_Telephone_Number.Text = "";
            txtGuard_Alternate_Number.Text = "";
            txtGuard_Email.Text = "";
            txtGuard_Comments.Text = "";
            trGuardSystem.Style["display"] = "none";
        }
        #endregion

        #region "Intru System"
        objBuilding.Intru_System = clsGeneral.FormatYesNoToStore(rdoIntru_System);

        if (objBuilding.Intru_System == true)
        {
            objBuilding.Intru_System_Name = txtIntru_System.Text.Trim();
            objBuilding.Intru_Contact_Name = txtIntru_Contact_Name.Text.Trim();
            objBuilding.Intru_Vendor_Name = txtIntru_Vendor_Name.Text.Trim();
            objBuilding.Intru_Contact_Expiration_Date = clsGeneral.FormatDateToStore(txtIntru_Contact_Expiration_Date);
            objBuilding.Intru_Address_1 = txtIntru_Address_1.Text.Trim();
            objBuilding.Intru_Address_2 = txtIntru_Address_2.Text.Trim();
            objBuilding.Intru_City = txtIntru_City.Text.Trim();
            objBuilding.Intru_State = ddlIntru_State.SelectedValue;
            objBuilding.Intru_Zip = txtIntru_Zip.Text.Trim();
            objBuilding.Intru_Telephone_Number = txtIntru_Telephone_Number.Text.Trim();
            objBuilding.Intru_Alternate_Number = txtIntru_Alternate_Number.Text.Trim();
            objBuilding.Intru_Email = txtIntru_Email.Text.Trim();
            objBuilding.Intru_Comments = txtIntru_Comments.Text.Trim();
            objBuilding.Intru_Contact_Alarm_Type = ddlIntru_Contact_Alarm_Type.SelectedValue;
            trIntrusionAlarms.Style["display"] = "";
        }
        else
        {
            txtIntru_System.Text = "";
            txtIntru_Contact_Name.Text = "";
            txtIntru_Vendor_Name.Text = "";
            txtIntru_Contact_Expiration_Date.Text = "";
            txtIntru_Address_1.Text = "";
            txtIntru_Address_2.Text = "";
            txtIntru_City.Text = "";
            ddlIntru_State.SelectedValue = "";
            txtIntru_Zip.Text = "";
            txtIntru_Telephone_Number.Text = "";
            txtIntru_Alternate_Number.Text = "";
            txtIntru_Email.Text = "";
            txtIntru_Comments.Text = "";
            ddlIntru_Contact_Alarm_Type.SelectedValue = "";
            trIntrusionAlarms.Style["display"] = "none";
        }
        #endregion

        #region "Fence"
        objBuilding.Fence = clsGeneral.FormatYesNoToStore(rdoFence);
        if (objBuilding.Fence == true)
        {
            objBuilding.Fence_Razor_Wire = chkRazor_Wire.Checked;
            objBuilding.Fence_Electrified = chkFence_Electrified.Checked;
            trFence.Style["display"] = "";
        }
        else
        {
            chkRazor_Wire.Checked = false;
            chkFence_Electrified.Checked = false;
            trFence.Style["display"] = "none";
        }
        #endregion

        #region "Generator"
        objBuilding.Generator = clsGeneral.FormatYesNoToStore(rdoGenerator);
        if (objBuilding.Generator == true)
        {
            objBuilding.Generator_Make = txtGenerator_Make.Text.Trim();
            objBuilding.Generator_Model = txtGenerator_Model.Text.Trim();
            objBuilding.Generator_Size = txtGenerator_Size.Text.Trim();
            trGenerator.Style["display"] = "";
        }
        else
        {
            txtGenerator_Make.Text = "";
            txtGenerator_Model.Text = "";
            txtGenerator_Size.Text = "";
            trGenerator.Style["display"] = "none";
        }
        #endregion
        objBuilding.Location_Status = drpLocationStatus.SelectedValue;
        objBuilding.Fire_Department_Type = ddlFireDeptType.SelectedValue;
        objBuilding.Fire_Department_Distance = ddlDistance.SelectedValue;
        objBuilding.Tier_1_County = clsGeneral.FormatYesNoToStore(rdoTier_1_County);
        objBuilding.Earthquake_Zone_Fault_Line = clsGeneral.FormatYesNoToStore(rdoEarthquake_Zone_Fault_Line);
        if (txtNumber_Of_Parking_Spaces.Text != "") objBuilding.Number_Of_Parking_Spaces = Convert.ToInt32(txtNumber_Of_Parking_Spaces.Text.Trim().Replace(",", ""));
        else objBuilding.Number_Of_Parking_Spaces = null;
        objBuilding.Acreage = clsGeneral.GetDecimalValue(txtAcreage);
        objBuilding.Neighboring_Buildings_within_100_ft = clsGeneral.FormatYesNoToStore(rdoNeighboring_Buildings_within_100_ft);
        if (objBuilding.Neighboring_Buildings_within_100_ft == true)
        {
            objBuilding.Neighbor_Occupancy = txtNeighbor_Occupancy.Text.Trim();
            tblNeighboringOccupancy.Style["display"] = "";
        }
        else
        {
            txtNeighbor_Occupancy.Text = "";
            tblNeighboringOccupancy.Style["display"] = "none";
        }

        objBuilding.Distance_from_body_of_water = ddlDistance_from_body_of_water.SelectedValue;
        objBuilding.Prior_Flood_History = clsGeneral.FormatYesNoToStore(rdoPrior_Flood_History);

        #region "Prior Flood History"
        if (objBuilding.Prior_Flood_History == true)
        {
            objBuilding.Flood_History_Descr = txtFlood_History_Descr.Text.Trim();
            trFloodHistory.Style["display"] = "";
        }
        else
        {
            txtFlood_History_Descr.Text = "";
            trFloodHistory.Style["display"] = "none";
        }
        #endregion
        objBuilding.Lowest_finish_floor_elevation = txtLowest_finish_floor_elevation.Text.Trim() != "" ? Convert.ToInt32(txtLowest_finish_floor_elevation.Text.Trim().Replace(",", "")) : 0;
        objBuilding.Property_Damage_Losses_in_the_Past_5_years = clsGeneral.FormatYesNoToStore(rdoProperty_Damage_Losses_in_the_Past_5_years);
        if (objBuilding.Property_Damage_Losses_in_the_Past_5_years == true)
        {
            objBuilding.Property_Loss_Descr = txtProperty_Loss_Descr.Text.Trim();
            trPropertyDamageLoss.Style["display"] = "";
        }
        else
        {
            txtProperty_Loss_Descr.Text = "";
            trPropertyDamageLoss.Style["display"] = "none";
        }
        objBuilding.Flood_Zone = txtFloodZone.Text;

        #region "National Flood policy"
        objBuilding.National_Flood_Policy = clsGeneral.FormatYesNoToStore(rdoNational_Flood_Policy);
        if (objBuilding.National_Flood_Policy == true)
        {
            objBuilding.Flood_Carrier = txtFlood_Carrier.Text.Trim();
            objBuilding.Flood_Policy_Number = txtFlood_Policy_Number.Text.Trim();
            objBuilding.Flood_Premium = clsGeneral.GetDecimalNullableValue(txtFlood_Premium);
            objBuilding.Flood_Polciy_Limits_Contents = clsGeneral.GetDecimalNullableValue(txtFlood_Polciy_Limits_Contents);
            objBuilding.Flood_Policy_Inception_Date = clsGeneral.FormatDateToStore(txtFlood_Policy_Inception_Date);
            objBuilding.Flood_Policy_Expiration_Date = clsGeneral.FormatDateToStore(txtFlood_Policy_Expiration_Date);
            objBuilding.Flood_Deductible = clsGeneral.GetDecimalNullableValue(txtFlood_Deductible);
            objBuilding.Flood_Policy_Limits_Building = clsGeneral.GetDecimalNullableValue(txtFlood_Policy_Limits_Building);
            trNational_Flood_Policy.Style["display"] = "";
        }
        else
        {
            txtFlood_Carrier.Text = "";
            txtFlood_Policy_Number.Text = "";
            txtFlood_Premium.Text = "";
            txtFlood_Polciy_Limits_Contents.Text = "";
            txtFlood_Policy_Inception_Date.Text = "";
            txtFlood_Policy_Expiration_Date.Text = "";
            txtFlood_Deductible.Text = "";
            txtFlood_Policy_Limits_Building.Text = "";
            trNational_Flood_Policy.Style["display"] = "none";
        }
        #endregion
        objBuilding.Comments = txtComments.Text.Trim();
        objBuilding.Ownership = rdoOwnership.SelectedValue;

        if (rdoOwnership.SelectedValue == "ThirdParty" || rdoOwnership.SelectedValue == "ThirdPartySublease")
        {
            objBuilding.Liability = rdoLiability.SelectedValue;
        }

        /**************** Occupancy **********/
        objBuilding.Occupancy_Sales_New = chkLstOccupancy.Items[0].Selected;
        objBuilding.Occupancy_Body_Shop = chkLstOccupancy.Items[1].Selected;
        objBuilding.Occupancy_Parking_Lot = chkLstOccupancy.Items[2].Selected;
        objBuilding.Occupancy_Sales_Used = chkLstOccupancy.Items[3].Selected;
        objBuilding.Occupancy_Parts = chkLstOccupancy.Items[4].Selected;
        objBuilding.Occupancy_Raw_Land = chkLstOccupancy.Items[5].Selected;
        objBuilding.Occupancy_Service = chkLstOccupancy.Items[6].Selected;
        objBuilding.Occupancy_Ofifce = chkLstOccupancy.Items[7].Selected;

        objBuilding.Address_1 = txtBuildingAddress_1.Text.Trim();
        objBuilding.Address_2 = txtBuildingAddress_2.Text.Trim();
        objBuilding.City = txtBuilding_City.Text.Trim();
        objBuilding.State = ddlBuidingState.SelectedValue;
        objBuilding.Zip = txtBuilding_Zip.Text.Trim();
        //objBuilding.Building_Limit = clsGeneral.GetDecimalNullableValue(txtFinancial_Building_Limit);
        // objBuilding.Leasehold_Interests_Limit_Betterment = clsGeneral.GetDecimalNullableValue(txtFinancial_Leasehold_Interests_Limit_Betterment);
        //objBuilding.Betterment_Date_Complete = clsGeneral.FormatDateToStore(txtFinancial_Betterment_Date_Complate);
        // objBuilding.Leasehold_Interests_Limit_Expansion = clsGeneral.GetDecimalNullableValue(txtFinancial_Leasehold_Interests_Limit_Expansion);
        //objBuilding.Expansion_Date_Complete = clsGeneral.FormatDateToStore(txtFinancial_Expansion_Date_Complate);
        //objBuilding.Associate_Tools_Limit = clsGeneral.GetDecimalNullableValue(txtFinancial_Associate_Tools_Limit);
        //objBuilding.Contents_Limit = clsGeneral.GetDecimalNullableValue(txtFinancial_Contents_Limit);
        //objBuilding.Parts_Limit = clsGeneral.GetDecimalNullableValue(txtFinancial_Parts_Limit);
        //objBuilding.Inventory_Levels = clsGeneral.GetDecimalNullableValue(txtFinancial_Inventory_Levels);
        //objBuilding.RS_Means_Building_Value = clsGeneral.GetDecimalNullableValue(txtRS_Means_Building_Value);
        objBuilding.Year_Built = txtYear_Built.Text.Trim();
        objBuilding.Square_Footage = txtSquare_Footage.Text.Trim();
        objBuilding.Number_of_Stories = txtNumber_of_Stories.Text != "" ? Convert.ToDouble(clsGeneral.GetDecimalValue(txtNumber_of_Stories)) : 0;
        objBuilding.Roof_Reinforced_Concrete = chkRoof_Reinforced_Concrete.Checked;
        objBuilding.Roof_Concrete_Panels = chkRoof_Concrete_Panels.Checked;
        objBuilding.Roof_Steel_Deck_with_Fasteners = chkRoof_Steel_Deck_With_Fasteners.Checked;
        objBuilding.Roof_Poured_Concrete = chkRoof_Poured_Concrete.Checked;
        objBuilding.Roof_Steel_Deck = chkRoof_Steel_Deck.Checked;
        objBuilding.Roof_Wood_Joists = chkRoof_Wood_Joists.Checked;
        objBuilding.Floors_Reinforced_Concrete = chkFloors_Reinforced_Concrete.Checked;
        objBuilding.Floors_Poured_Concrete = chkFloors_Poured_Concrete.Checked;
        objBuilding.Floors_Wood_Timber = chkFloors_Wood_Timber.Checked;
        objBuilding.Ext_Walls_Reinforced_Concrete = chkExt_Walls_Reinforced_Concrete.Checked;
        objBuilding.Ext_Walls_Masonry = chkExt_Walls_Masonry.Checked;
        objBuilding.Ext_Walls_Corrugated_Metal_Panels = chkExt_Walls_Corrugated_Metal_Panels.Checked;
        objBuilding.Ext_Walls_Tilt_up_Concrete = chkExt_Walls_Tilt_up_Concrete.Checked;
        objBuilding.Ext_Walls_Glass_and_Steel_Curtain = chkExt_Walls_Glass_and_Steel_Curtain.Checked;
        objBuilding.Ext_Walls_Wood_Frame = chkExt_Walls_Wood_Frame.Checked;
        objBuilding.Int_Walls_Masonry_With_Fire_Doors = chkInt_Walls_Masonry_With_Fire_Doors.Checked;
        objBuilding.Int_Walls_Masonry_with_Openings = chkInt_Walls_Masonry_with_Openings.Checked;
        objBuilding.Int_Walls_No_Interior_Walls = chkInt_Walls_No_Interior_Walls.Checked;
        objBuilding.Int_Walls_Masonry = chkInt_Walls_Masonry.Checked;
        objBuilding.Int_Walls_Gypsum_Board = chkInt_Walls_Gypsum_Board.Checked;
        objBuilding.Int_wall_extend_above_roof = clsGeneral.FormatYesNoToStore(rdoInt_wall_extend_above_roof);
        objBuilding.Number_of_Paint_Booths = txtNumber_of_Paint_Booths.Text.Trim() != "" ? Convert.ToInt32(txtNumber_of_Paint_Booths.Text.Trim().Replace(",", "")) : 0;
        objBuilding.Number_of_Lifts = txtNumber_of_Lifts.Text.Trim() != "" ? Convert.ToInt32(txtNumber_of_Lifts.Text.Trim().Replace(",", "")) : 0;
        objBuilding.Sales_New_Sprinklered = Convert.ToDouble(clsGeneral.GetDecimalNullableValue(txtSales_New_Sprinklered));
        objBuilding.Sales_Used_Sprinklered = Convert.ToDouble(clsGeneral.GetDecimalNullableValue(txtSales_Used_Sprinklered));
        objBuilding.Service_Sprinklered = Convert.ToDouble(clsGeneral.GetDecimalNullableValue(txtService_Sprinklered));
        objBuilding.Body_Shop_Sprinklered = Convert.ToDouble(clsGeneral.GetDecimalNullableValue(txtBody_Shop_Sprinklered));
        objBuilding.Parts_Sprinklered = Convert.ToDouble(clsGeneral.GetDecimalNullableValue(txtParts_Sprinklered));
        objBuilding.Office_Sprinklered = Convert.ToDouble(clsGeneral.GetDecimalNullableValue(txtOffice_Sprinklered));
        objBuilding.Water_Public = chkWater_Public.Checked;
        objBuilding.Water_Private = chkWater_Private.Checked;
        objBuilding.Water_Boosted = chkWater_Boosted.Checked;
        objBuilding.Design_Densities_for_each_area = txtDesign_Densities_for_each_area.Text.Trim();
        objBuilding.Hydrants_within_500_ft = clsGeneral.FormatYesNoToStore(rdoHydrants_within_500_ft);
        objBuilding.Alarm_UL_Central_Station = chkAlarm_UL_Central_Station.Checked;
        objBuilding.Alarm_Constant_Attended = chkAlarm_Constant_Attended.Checked;
        objBuilding.Alarm_Sprinkler_Valve_Tamper = chkAlarm_Sprinkler_Valve_Tamper.Checked;
        objBuilding.Alarm_Non_UL_Central_Station = chkAlarm_Non_UL_Central_Station.Checked;
        objBuilding.Alarm_Local = chkAlarm_Local.Checked;
        objBuilding.Alarm_Smoke_Detectors = chkAlarm_Smoke_Detectors.Checked;
        objBuilding.Alarm_Proprietary = chkAlarm_Proprietary.Checked;
        objBuilding.Alarm_Sprinkler_Waterflow = chkAlarm_Sprinkler_Waterflow.Checked;
        objBuilding.Alarm_Dry_Pipe_Air = chkAlarm_Dry_Pipe_Air.Checked;
        objBuilding.Alarm_Remote = chkAlarm_Remote.Checked;
        objBuilding.Alarm_Fire_Pump_Alarms = chkAlarm_Fire_Pump_Alarms.Checked;
        objBuilding.Alarm_Auto_Fire_Alarms = clsGeneral.FormatYesNoToStore(rdoAlarm_Auto_Fire_Alarms);
        objBuilding.Alarm_Security_Cameras = clsGeneral.FormatYesNoToStore(rdoAlarm_Security_Cameras);

        #region "Security cameras"
        if (objBuilding.Alarm_Security_Cameras == true)
        {
            objBuilding.SecuCam_System = txtsecuCam_System.Text.Trim();
            objBuilding.SecuCam_Contact_Name = txtSecuCam_Contact_Name.Text.Trim();
            objBuilding.SecuCam_Vendor_Name = txtSecuCam_Vendor_Name.Text.Trim();
            objBuilding.SecuCam_Contact_Expiration_Date = clsGeneral.FormatDateToStore(txtSecuCam_Contact_Expiration_Date);
            objBuilding.SecuCam_Address_1 = txtSecuCam_Address_1.Text.Trim();
            objBuilding.SecuCam_Address_2 = txtSecuCam_Address_2.Text.Trim();
            objBuilding.SecuCam_City = txtSecuCam_City.Text.Trim();
            objBuilding.SecuCam_State = ddlSecuCam_State.SelectedValue;
            objBuilding.SecuCam_Zip = txtSecuCam_Zip.Text.Trim();
            objBuilding.SecuCam_Telephone_Number = txtSecuCam_Telephone_Number.Text.Trim();
            objBuilding.SecuCam_Alternate_Number = txtSecuCam_Alternate_Number.Text.Trim();
            objBuilding.SecuCam_Email = txtSecuCam_Email.Text.Trim();
            objBuilding.SecuCam_Comments = txtSecuCam_Comments.Text.Trim();
            trSecurityCameras.Style["display"] = "";
        }
        else
        {
            txtsecuCam_System.Text = "";
            txtSecuCam_Contact_Name.Text = "";
            txtSecuCam_Vendor_Name.Text = "";
            txtSecuCam_Contact_Expiration_Date.Text = "";
            txtSecuCam_Address_1.Text = "";
            txtSecuCam_Address_2.Text = "";
            txtSecuCam_City.Text = "";
            txtSecuCam_Zip.Text = "";
            txtSecuCam_Telephone_Number.Text = "";
            txtSecuCam_Alternate_Number.Text = "";
            txtSecuCam_Email.Text = "";
            txtSecuCam_Comments.Text = "";
            trSecurityCameras.Style["display"] = "none";
        }
        #endregion

        if (txtNumberOfBays.Text != "") objBuilding.Number_of_Bays = Convert.ToInt32(txtNumberOfBays.Text.Replace(",", ""));
        if (txtNumberOfLifts.Text != "") objBuilding.Number_of_Lifts_SC = Convert.ToInt32(txtNumberOfLifts.Text.Replace(",", ""));
        if (txtNumberOfPrepAreas.Text != "") objBuilding.Number_of_Prep_Areas = Convert.ToInt32(txtNumberOfPrepAreas.Text.Replace(",", ""));
        if (txtNumberOfCarWashStations.Text != "") objBuilding.Number_of_Car_Wash_Stations = Convert.ToInt32(txtNumberOfCarWashStations.Text.Replace(",", ""));

        #region "Fire Inspections"

        objBuilding.Fire_Contact_Name = txtFireContactName.Text.Trim();
        objBuilding.Fire_Vendor_Name = txtFireVendorName.Text.Trim();
        objBuilding.Fire_Contact_Expiration_Date = clsGeneral.FormatDateToStore(txtFireContactExpirationDate);
        objBuilding.Fire_Address_1 = txtFireAddress1.Text.Trim();
        objBuilding.Fire_Address_2 = txtFireAddress2.Text.Trim();
        objBuilding.Fire_City = txtFireCity.Text.Trim();
        objBuilding.Fire_State = drpFireState.SelectedValue;
        objBuilding.Fire_Zip = txtFireZipCode.Text.Trim();
        objBuilding.Fire_Telephone_Number = txtFireTelephone.Text.Trim();
        objBuilding.Fire_Alternate_Number = txtFireAlternateNumber.Text.Trim();
        objBuilding.Fire_Email = txtFireEmail.Text.Trim();
        objBuilding.Fire_Comments = txtFireComments.Text.Trim();

        #endregion

        #endregion

        objBuilding.Updated_By = Convert.ToDecimal(clsSession.UserID);
        objBuilding.Updated_Date = DateTime.Now;
        // insert or update the information as per the primary key avaialble
        if (PK_Building_ID > 0)
            objBuilding.Update();
        else
            PK_Building_ID = objBuilding.Insert();
        
        //Insert and update Insurance cope
        InsertUpdateInsuranceCope(PK_Building_ID);

        // bind the building grid
        BindGridBuilding();

        // bind ownership details for the builiding record
        BindOwnershipDetails();

        // set attachment FK for the building attachment and lease attachment
        BuildingAttachment.FK_Building_ID = PK_Building_ID;
        LeaseAttachment.FK_Building_ID = PK_Building_ID;
        ucCtrlExposureInfo.SetRMLocationCode(PK_Building_ID);
        if (objBuilding.Ownership == "ThirdParty" || objBuilding.Ownership == "ThirdPartySublease")
        {
            trgvSubLease.Style["Display"] = "";
            gridSubLease.Style["Display"] = "";
            trAddNewLease.Style["Display"] = "";
        }
        else
        {
            trgvSubLease.Style["Display"] = "none";
            gridSubLease.Style["Display"] = "none";
            trAddNewLease.Style["Display"] = "none";
        }
        // show next panel
        ScriptManager.RegisterClientScriptBlock(Page, GetType(), DateTime.Now.ToString(), "javascript:window.scrollTo(0, 0);ShowPanel(" + (rdoOwnership.SelectedIndex == -1 ? "4" : "3") + ");", true); //seLocationBuildingNumber('" + strLocationCode + "');
    }

    /// <summary>
    /// Handles Save & Next button click in Ownership panel
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnOwnershipSave_Click(object sender, EventArgs e)
    {
        // check if building ID is available 
        // otherwise give message to select building information
        if (PK_Building_ID > 0)
        {
            // create object for building
            Building objBuilding = new Building(PK_Building_ID);
            if (objBuilding.Ownership != "")
            {
                // create object for ownership
                Building_Ownership objOwnership = new Building_Ownership();
                objOwnership.PK_Building_Ownership_ID = PK_Building_Ownership;
                objOwnership.FK_Building_ID = PK_Building_ID;

                objOwnership.Lease_Sublease = (objBuilding.Ownership == "ThirdParty" || objBuilding.Ownership == "ThirdPartySublease") ? "SUBLEASE" : "LEASE";
                objOwnership.Landlord_Name = txtLandlord_Name.Text.Trim();
                objOwnership.Landlord_Address_1 = txtLandlord_Address_1.Text.Trim();
                objOwnership.Landlord_Address_2 = txtLandlord_Address_2.Text.Trim();
                objOwnership.Landlord_City = txtLandlord_City.Text.Trim();
                objOwnership.Landlord_State = ddlLandlord_State.SelectedValue;
                objOwnership.Landlord_Zip = txtLandlord_Zip.Text.Trim();
                objOwnership.Lease_ID = txtLease_ID.Text.Trim();
                objOwnership.Commencement_Date = clsGeneral.FormatDateToStore(txtCommencement_Date);
                objOwnership.Expiration_Date = clsGeneral.FormatDateToStore(txtExpiration_Date);
                objOwnership.Landlord_Legal_Entity = txtLandlordLegalEntity.Text.Trim();

                if (objBuilding.Ownership == "ThirdParty" || objBuilding.Ownership == "ThirdPartySublease")
                {
                    objOwnership.Sublease_Name = txtSubLease_Name.Text.Trim();
                    objOwnership.SubLandlord = txtSubLandlord.Text.Trim();
                    objOwnership.Sublease_Address_1 = txtSublease_Address_1.Text.Trim();
                    objOwnership.Sublease_Address_2 = txtSublease_Address_2.Text.Trim();
                    objOwnership.Sublease_City = txtSublease_City.Text.Trim();
                    if (ddlSublease_State.SelectedIndex > 0) objOwnership.Sublease_State = ddlSublease_State.SelectedValue;
                    objOwnership.Sublease_Zip = txtSublease_Zip.Text.Trim();
                    objOwnership.Sublease_FirstName = txtSubleaseFirstName.Text.Trim();
                    objOwnership.Sublease_LastName = txtSubleaseLastName.Text.Trim();
                    objOwnership.Sublease_Title = txtSubleaseTitle.Text.Trim();
                    objOwnership.Sublease_Phone = txtSubleasePhone.Text.Trim();
                    objOwnership.Sublease_Fax = txtSubleaseFax.Text.Trim();
                    objOwnership.Sublease_Email = txtSubleaseEmail.Text.Trim();
                }


                if (objBuilding.Ownership == "ThirdPartyLease" || objBuilding.Ownership == "ThirdPartySublease" || objBuilding.Ownership == "Internal")
                {

                    objOwnership.COI_Wording = txtCOI_Wording.Text.Trim();
                    RE_Information objRE = new RE_Information(FK_LU_Location_ID, true);

                    objOwnership.REQ_WC = chkREQWC.Checked;
                    objOwnership.REQ_EL = chkREQEL.Checked;
                    objOwnership.REQ_GL = chkREQGL.Checked;
                    objOwnership.REQ_Pollution = chkREQPollution.Checked;
                    objOwnership.REQ_Property = chkREQProperty.Checked;
                    objOwnership.REQ_Flood = chkREQFlood.Checked;
                    objOwnership.REQ_EQ = chkREQEQ.Checked;
                    objOwnership.REQ_WaiverofSubrogation = chkREQWaiver.Checked;

                    objOwnership.SubResponsible_WC = chkWCTenant.Checked;
                    objOwnership.SubResponsible_EL = chkELTenant.Checked;
                    objOwnership.SubResponsible_GL = chkGLTenant.Checked;
                    objOwnership.SubResponsible_Pollution = chkPollutionTenant.Checked;
                    objOwnership.SubResponsible_Property = chkPropertyTenant.Checked;
                    objOwnership.SubResponsible_Flood = chkFloodTenant.Checked;
                    objOwnership.EQ = chkEQTenant.Checked;
                    objOwnership.WaiverofSubrogation = chkWaiverTenant.Checked;

                    // check for the PK > 0 and values available for the COI DOCs to upload
                    // if available then delete the files
                    if (PK_Building_Ownership > 0)
                    {
                        if (!chkWCTenant.Checked) RemoveCOIDoc(hdnCOI_WC_URL.Value);
                        if (!chkELTenant.Checked) RemoveCOIDoc(hdnCOI_EL_URL.Value);
                        if (!chkGLTenant.Checked) RemoveCOIDoc(hdnCOI_GL_URL.Value);
                        if (!chkPollutionTenant.Checked) RemoveCOIDoc(hdnCOI_Pollution_URL.Value);
                        if (!chkPropertyTenant.Checked) RemoveCOIDoc(hdnCOI_Property_URL.Value);
                        if (!chkFloodTenant.Checked) RemoveCOIDoc(hdnCOI_Flood_URL.Value);
                        if (!chkEQTenant.Checked) RemoveCOIDoc(hdnCOI_EQ_URL.Value);
                        if (!chkWaiverTenant.Checked) RemoveCOIDoc(hdnCOI_Waiver_URL.Value);
                    }

                    // if link texts  is not add then set the doc from hidden URL controls
                    if (lnkCOI_WC.Text != "Add" && chkWCTenant.Checked) objOwnership.COI_WC = hdnCOI_WC_URL.Value.Substring(hdnCOI_WC_URL.Value.LastIndexOf("/") + 1);
                    if (lnkCOI_EL.Text != "Add" && chkELTenant.Checked) objOwnership.COI_EL = hdnCOI_EL_URL.Value.Substring(hdnCOI_EL_URL.Value.LastIndexOf("/") + 1);
                    if (lnkCOI_GL.Text != "Add" && chkGLTenant.Checked) objOwnership.COI_GL = hdnCOI_GL_URL.Value.Substring(hdnCOI_GL_URL.Value.LastIndexOf("/") + 1);
                    if (lnkCOI_Pollution.Text != "Add" && chkPollutionTenant.Checked) objOwnership.COI_Pollution = hdnCOI_Pollution_URL.Value.Substring(hdnCOI_Pollution_URL.Value.LastIndexOf("/") + 1);
                    if (lnkCOI_Property.Text != "Add" && chkPropertyTenant.Checked) objOwnership.COI_Property = hdnCOI_Property_URL.Value.Substring(hdnCOI_Property_URL.Value.LastIndexOf("/") + 1);
                    if (lnkCOI_Flood.Text != "Add" && chkFloodTenant.Checked) objOwnership.COI_Flood = hdnCOI_Flood_URL.Value.Substring(hdnCOI_Flood_URL.Value.LastIndexOf("/") + 1);
                    if (lnkCOI_EQ.Text != "Add" && chkEQTenant.Checked) objOwnership.COI_EQ = hdnCOI_EQ_URL.Value.Substring(hdnCOI_EQ_URL.Value.LastIndexOf("/") + 1);
                    if (lnkCOI_Waiver.Text != "Add" && chkWaiverTenant.Checked) objOwnership.COI_WaiverofSubrogation = hdnCOI_Waiver_URL.Value.Substring(hdnCOI_Waiver_URL.Value.LastIndexOf("/") + 1);

                    #region "Upload COI Documents"

                    if (hdnCOI_WC.Value != "" && chkWCTenant.Checked)
                    {
                        lnkCOI_WC.Text = FormatCOIFileName(hdnCOI_WC.Value);
                        string strUploadedFileWC = hdnCOI_WC.Value;
                        if (strUploadedFileWC != "" && strUploadedFileWC != lnkCOI_WC.Text)
                        {
                            objOwnership.COI_WC = strUploadedFileWC;
                            hdnCOI_WC_URL.Value = AppConfig.PropertyCOIDocURL + objOwnership.COI_WC;
                        }
                    }
                    if (hdnCOI_EL.Value != "" && chkELTenant.Checked)
                    {
                        lnkCOI_EL.Text = FormatCOIFileName(hdnCOI_EL.Value);
                        string strUploadedFileEL = hdnCOI_EL.Value;
                        if (strUploadedFileEL != "" && strUploadedFileEL != lnkCOI_EL.Text)
                        {
                            objOwnership.COI_EL = strUploadedFileEL;
                            hdnCOI_EL_URL.Value = AppConfig.PropertyCOIDocURL + objOwnership.COI_EL;
                        }
                    }
                    if (hdnCOI_GL.Value != "" && chkGLTenant.Checked)
                    {
                        lnkCOI_GL.Text = FormatCOIFileName(hdnCOI_GL.Value);
                        string strUploadedFileGL = hdnCOI_GL.Value;
                        if (strUploadedFileGL != "" && strUploadedFileGL != lnkCOI_GL.Text)
                        {
                            objOwnership.COI_GL = strUploadedFileGL;
                            hdnCOI_GL_URL.Value = AppConfig.PropertyCOIDocURL + objOwnership.COI_GL;
                        }
                    }
                    if (hdnCOI_Pollution.Value != "" && chkPollutionTenant.Checked)
                    {
                        lnkCOI_Pollution.Text = FormatCOIFileName(hdnCOI_Pollution.Value);
                        string strUploadedFilePollution = hdnCOI_Pollution.Value;
                        if (strUploadedFilePollution != "" && strUploadedFilePollution != lnkCOI_Pollution.Text)
                        {
                            objOwnership.COI_Pollution = strUploadedFilePollution;
                            hdnCOI_Pollution_URL.Value = AppConfig.PropertyCOIDocURL + objOwnership.COI_Pollution;
                        }
                    }
                    if (hdnCOI_Property.Value != "" && chkPropertyTenant.Checked)
                    {
                        lnkCOI_Property.Text = FormatCOIFileName(hdnCOI_Property.Value);
                        string strUploadedFileProperty = hdnCOI_Property.Value;
                        if (strUploadedFileProperty != "" && strUploadedFileProperty != lnkCOI_Property.Text)
                        {
                            objOwnership.COI_Property = strUploadedFileProperty;
                            hdnCOI_Property_URL.Value = AppConfig.PropertyCOIDocURL + objOwnership.COI_Property;
                        }
                    }
                    if (hdnCOI_Flood.Value != "" && chkFloodTenant.Checked)
                    {
                        lnkCOI_Flood.Text = FormatCOIFileName(hdnCOI_Flood.Value);
                        string strUploadedFileFlood = hdnCOI_Flood.Value;
                        if (strUploadedFileFlood != "" && strUploadedFileFlood != lnkCOI_Flood.Text)
                        {
                            objOwnership.COI_Flood = strUploadedFileFlood;
                            hdnCOI_Flood_URL.Value = AppConfig.PropertyCOIDocURL + objOwnership.COI_Flood;
                        }
                    }
                    if (hdnCOI_EQ.Value != "" && chkEQTenant.Checked)
                    {
                        lnkCOI_EQ.Text = FormatCOIFileName(hdnCOI_EQ.Value);
                        string strUploadedFileEQ = hdnCOI_EQ.Value;
                        if (strUploadedFileEQ != "" && strUploadedFileEQ != lnkCOI_EQ.Text)
                        {
                            objOwnership.COI_EQ = strUploadedFileEQ;
                            hdnCOI_EQ_URL.Value = AppConfig.PropertyCOIDocURL + objOwnership.COI_EQ;
                        }
                    }
                    if (hdnCOI_Waiver.Value != "" && chkWaiverTenant.Checked)
                    {
                        lnkCOI_Waiver.Text = FormatCOIFileName(hdnCOI_Waiver.Value);
                        string strUploadedFileWaiver = hdnCOI_Waiver.Value;
                        if (strUploadedFileWaiver != "" && strUploadedFileWaiver != lnkCOI_Waiver.Text)
                        {
                            objOwnership.COI_WaiverofSubrogation = strUploadedFileWaiver;
                            hdnCOI_Waiver_URL.Value = AppConfig.PropertyCOIDocURL + objOwnership.COI_WaiverofSubrogation;
                        }
                    }
                    #endregion

                    objOwnership.COI_WC_Date = clsGeneral.FormatDateToStore(hdnCOI_WC_Date.Value);
                    objOwnership.COI_EL_Date = clsGeneral.FormatDateToStore(hdnCOI_EL_Date.Value);
                    objOwnership.COI_GL_Date = clsGeneral.FormatDateToStore(hdnCOI_GL_Date.Value);
                    objOwnership.COI_Pollution_Date = clsGeneral.FormatDateToStore(hdnCOI_Pollution_Date.Value);
                    objOwnership.COI_Property_Date = clsGeneral.FormatDateToStore(hdnCOI_Property_Date.Value);
                    objOwnership.COI_Flood_Date = clsGeneral.FormatDateToStore(hdnCOI_Flood_Date.Value);
                    objOwnership.COI_EQ_Date = clsGeneral.FormatDateToStore(hdnCOI_EQ_Date.Value);
                    objOwnership.COI_WaiverofSubrogation_Date = clsGeneral.FormatDateToStore(hdnCOI_Waiver_Date.Value);

                    if (chkREQWC.Checked) objOwnership.ReqLim_WC = clsGeneral.GetDecimalNullableValue(txtReqLim_WC);
                    if (chkREQEL.Checked) objOwnership.ReqLim_EL = clsGeneral.GetDecimalNullableValue(txtReqLim_EL);
                    if (chkREQGL.Checked) objOwnership.ReqLim_GL = clsGeneral.GetDecimalNullableValue(txtReqLim_GL);
                    if (chkREQPollution.Checked) objOwnership.ReqLim_Pollution = clsGeneral.GetDecimalNullableValue(txtReqLim_Pollution);
                    if (chkREQProperty.Checked) objOwnership.ReqLim_Property = clsGeneral.GetDecimalNullableValue(txtReqLim_Property);
                    if (chkREQFlood.Checked) objOwnership.ReqLim_Flood = clsGeneral.GetDecimalNullableValue(txtReqLim_Flood);
                    if (chkREQEQ.Checked) objOwnership.ReqLim_EQ = clsGeneral.GetDecimalNullableValue(txtReqLim_EQ);
                    if (chkREQWaiver.Checked) objOwnership.ReqLim_WaiverofSubrogation = clsGeneral.GetDecimalNullableValue(txtReqLim_Waiver);

                    lblCOI_WC_Date.Text = hdnCOI_WC_Date.Value;
                    lblCOI_EL_Date.Text = hdnCOI_EL_Date.Value;
                    lblCOI_GL_Date.Text = hdnCOI_GL_Date.Value;
                    lblCOI_Pollution_Date.Text = hdnCOI_Pollution_Date.Value;
                    lblCOI_Property_Date.Text = hdnCOI_Property_Date.Value;
                    lblCOI_Flood_Date.Text = hdnCOI_Flood_Date.Value;
                    lblCOI_EQ_Date.Text = hdnCOI_EQ_Date.Value;
                    lblCOI_Waiver_Date.Text = hdnCOI_Waiver_Date.Value;

                    if (!chkWCTenant.Checked) lnkCOI_WC.Text = "Add";
                    if (!chkELTenant.Checked) lnkCOI_EL.Text = "Add";
                    if (!chkGLTenant.Checked) lnkCOI_GL.Text = "Add";
                    if (!chkPollutionTenant.Checked) lnkCOI_Pollution.Text = "Add";
                    if (!chkPropertyTenant.Checked) lnkCOI_Property.Text = "Add";
                    if (!chkFloodTenant.Checked) lnkCOI_Flood.Text = "Add";
                    if (!chkEQTenant.Checked) lnkCOI_EQ.Text = "Add";
                    if (!chkWaiverTenant.Checked) lnkCOI_Waiver.Text = "Add";

                    tblWCLimit.Style["display"] = chkREQWC.Checked ? "" : "none";
                    tblELLimit.Style["display"] = chkREQEL.Checked ? "" : "none";
                    tblGLLimit.Style["display"] = chkREQGL.Checked ? "" : "none";
                    tblPollutionLimit.Style["display"] = chkREQPollution.Checked ? "" : "none";
                    tblPropertyLimit.Style["display"] = chkREQProperty.Checked ? "" : "none";
                    tblFloodLimit.Style["display"] = chkREQFlood.Checked ? "" : "none";
                    tblEQLimit.Style["display"] = chkREQEQ.Checked ? "" : "none";
                    tblWaiverLimit.Style["display"] = chkREQWaiver.Checked ? "" : "none";
                }

                objOwnership.Updated_By = Convert.ToDecimal(clsSession.UserID);
                objOwnership.Updated_Date = DateTime.Now;
                // insert or update the ownership record depending on the primary key
                if (PK_Building_Ownership > 0)
                    objOwnership.Update();
                else
                    objOwnership.Insert();

            }

            // show next panel
            ScriptManager.RegisterClientScriptBlock(Page, GetType(), DateTime.Now.ToString(), "ShowPanel(4);", true);
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(Page, GetType(), DateTime.Now.ToString(), "ShowPanel(3);alert('Please Select/Enter Building Information First');", true);
        }

    }

    /// <summary>
    /// Handles save buton click for additional Insured section
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnAdditionalIsuredSave_Click(object sender, EventArgs e)
    {
        // check if building id is available or not
        // otherwise give message to select building information
        if (PK_Building_ID > 0)
        {
            // create object for payee
            Building_Additional_Insureds_Payees objInsuredPayee = new Building_Additional_Insureds_Payees();

            // get values from page controls
            objInsuredPayee.PK_Building_Additional_Insureds_Payees_ID = PK_Building_Additional_Insureds;
            objInsuredPayee.FK_Building_ID = PK_Building_ID;
            objInsuredPayee.Insured_Payee = "Insured";
            objInsuredPayee.Named = txtAdditional_Insureds_Named.Text.Trim();
            objInsuredPayee.Address_1 = txtAdditional_Insureds_Address_1.Text.Trim();
            objInsuredPayee.Address_2 = txtAdditional_Insureds_Address_2.Text.Trim();
            objInsuredPayee.City = txtAdditional_Insureds_City.Text.Trim();
            objInsuredPayee.State = ddlAdditional_Insureds_State.SelectedValue;
            objInsuredPayee.Zip = txtAdditional_Insureds_Zip.Text.Trim();
            objInsuredPayee.Updated_By = Convert.ToDecimal(clsSession.UserID);
            objInsuredPayee.Updated_Date = DateTime.Now;
            // insert or update additional insured depending on the primary key
            if (PK_Building_Additional_Insureds > 0)
                objInsuredPayee.Update();
            else
                objInsuredPayee.Insert();

            // clear controls so that new data can be inserted on add new link click
            txtAdditional_Insureds_Named.Text = "";
            txtAdditional_Insureds_Address_1.Text = "";
            txtAdditional_Insureds_Address_2.Text = "";
            txtAdditional_Insureds_City.Text = "";
            ddlAdditional_Insureds_State.SelectedValue = "";
            txtAdditional_Insureds_Zip.Text = "";

            // set PK = -1 and bind the additional insured grid and hide the details
            trAdditionalInsured.Style["display"] = "none";
            PK_Building_Additional_Insureds = -1;
            BindGridAdditionalInsureds();
            ScriptManager.RegisterClientScriptBlock(Page, GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(3);", true);
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(Page, GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(3);alert('Please Select/Enter Building Information First');", true);
        }

    }

    /// <summary>
    /// Handles Save button click in Named Loss Payee 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnPayeeSave_Click(object sender, EventArgs e)
    {
        if (PK_Building_ID > 0)
        {
            // create object for Additional_Insured_Payee record
            Building_Additional_Insureds_Payees objInsuredPayee = new Building_Additional_Insureds_Payees();

            // get values from page controls
            objInsuredPayee.PK_Building_Additional_Insureds_Payees_ID = PK_Building_Payee;
            objInsuredPayee.FK_Building_ID = PK_Building_ID;
            objInsuredPayee.Insured_Payee = "Payee";
            objInsuredPayee.Named = txtLoss_Payees_Named.Text.Trim();
            objInsuredPayee.Address_1 = txtLoss_Payees_Address_1.Text.Trim();
            objInsuredPayee.Address_2 = txtLoss_Payees_Address_2.Text.Trim();
            objInsuredPayee.City = txtLoss_Payees_City.Text.Trim();
            objInsuredPayee.State = ddlLoss_Payees_State.SelectedValue;
            objInsuredPayee.Zip = txtLoss_Payees_Zip.Text.Trim();
            objInsuredPayee.Type = ddlLoss_Payees_Type.SelectedValue;
            objInsuredPayee.Updated_By = Convert.ToDecimal(clsSession.UserID);
            objInsuredPayee.Updated_Date = DateTime.Now;
            // insert or update the record depending on the primary key
            if (PK_Building_Payee > 0)
                objInsuredPayee.Update();
            else
                objInsuredPayee.Insert();

            // clear controls so that new data can be inserted on add new link click
            txtLoss_Payees_Named.Text = "";
            txtLoss_Payees_Address_1.Text = "";
            txtLoss_Payees_Address_2.Text = "";
            txtLoss_Payees_City.Text = "";
            ddlLoss_Payees_State.SelectedValue = "";
            txtLoss_Payees_Zip.Text = "";
            trNamedLossPayees.Style["display"] = "none";

            PK_Building_Payee = 0;
            BindGridPayees();

            ScriptManager.RegisterClientScriptBlock(Page, GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(3);", true);
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(Page, GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(3);alert('Please Select/Enter Building Information First');", true);
        }
    }

    /// <summary>
    /// Handles Save button click in Property Condition Assessment panel
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnAssessmentSave_Click(object sender, EventArgs e)
    {
        // create object for Property_Assessment 
        Property_Assessment objAssessment = new Property_Assessment();

        // set PK and FK
        objAssessment.PK_Property_Assessment_ID = PK_Property_Assessment_ID;
        objAssessment.FK_LU_Location_ID = FK_LU_Location_ID;

        // get values from page controls        
        objAssessment.Date = clsGeneral.FormatDateToStore(txtAssessment_History_Date);
        objAssessment.Assessor = txtAssessment_History_Assessor.Text.Trim();
        objAssessment.Contact_Name = txtAssessment_History_Contact_Name.Text.Trim();
        objAssessment.Address_1 = txtAssessment_History_Address_1.Text.Trim();
        objAssessment.Address_2 = txtAssessment_History_Address_2.Text.Trim();
        objAssessment.City = txtAssessment_History_City.Text.Trim();
        objAssessment.State = ddlAssessment_History_State.SelectedValue;
        objAssessment.Zip = txtAssessment_History_Zip.Text.Trim();
        objAssessment.Telephone = txtAssessment_History_Telephone.Text.Trim();
        objAssessment.Updated_By = Convert.ToDecimal(clsSession.UserID);
        objAssessment.Updated_Date = DateTime.Now;
        // insert or update the record as per the primary key available
        if (PK_Property_Assessment_ID > 0)
            objAssessment.Update();
        else
            objAssessment.Insert();

        // bind assessment grid
        BindGridAssessment();

        // clear assessment controls and set PK to zero 
        PK_Property_Assessment_ID = 0;
        ClearAssessmentControls();

        ScriptManager.RegisterClientScriptBlock(Page, GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(5);", true);
    }

    /// <summary>
    /// Handles Save button click for concerns noted section in Assessment panel
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSaveAssessmentConcern_Click(object sender, EventArgs e)
    {
        // create object for Assessment_Concern
        Property_Assessment_Concern objConcern = new Property_Assessment_Concern();

        // set PK and FK
        objConcern.PK_Property_Assessment_Concern_ID = PK_Property_Assessment_Concern_ID;
        objConcern.FK_Property_Assessment_ID = PK_Property_Assessment_ID;

        // get values from page controls
        objConcern.Item_Description = txtItem_Description.Text.Trim();
        objConcern.Budgeted_Cost = clsGeneral.GetDecimalNullableValue(txtBudgeted_Cost);
        objConcern.Actual_Cost = clsGeneral.GetDecimalNullableValue(txtActual_Cost);
        objConcern.Date_Complete = clsGeneral.FormatDateToStore(txtDate_Complete);
        objConcern.Comments = txtConcerns_Comments.Text.Trim();
        objConcern.Updated_By = Convert.ToDecimal(clsSession.UserID);
        objConcern.Updated_Date = DateTime.Now;
        // insert or update the Assessment record depending on PK
        if (PK_Property_Assessment_Concern_ID > 0)
            objConcern.Update();
        else
            objConcern.Insert();

        // set PK to zero and bind the assessment grid
        PK_Property_Assessment_Concern_ID = 0;
        BindGridAssessmentConcern();

        // clear the assessment concern controls
        ClearAssessmentConcernControls();

        ScriptManager.RegisterClientScriptBlock(Page, GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(4);", true);
    }

    /// <summary>
    /// Handles Save and View button click in Contacts panel
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSaveAndView_Click(object sender, EventArgs e)
    {
        if (txtName.Text.Trim() != "" || txtPhone.Text.Trim() != "" || txtCell_Phone.Text.Trim() != "" ||
            txtAfter_Hours_Contact_Name.Text.Trim() != "" || txtAfter_Hours_Contact_Phone.Text.Trim() != "" || txtAfter_Hours_Contact_Cell_Phone.Text.Trim() != "")
        {
            // check if building ID is available 
            if (PK_Building_ID > 0)
            {
                // create object for contact
                Property_Contact objContact = new Property_Contact();

                // set PK and FK
                objContact.PK_Property_Contact_ID = PK_Property_Contact_ID;
                objContact.FK_Building_ID = PK_Building_ID;

                // get values from page controls
                objContact.Type = "Facility Contact";
                objContact.Name = txtName.Text.Trim();
                objContact.Phone = txtPhone.Text.Trim();
                objContact.Cell_Phone = txtCell_Phone.Text.Trim();
                objContact.After_Hours_Contact_Name = txtAfter_Hours_Contact_Name.Text.Trim();
                objContact.After_Hours_Contact_Phone = txtAfter_Hours_Contact_Phone.Text.Trim();
                objContact.After_Hours_Contact_Cell_Phone = txtAfter_Hours_Contact_Cell_Phone.Text.Trim();
                objContact.Updated_By = Convert.ToDecimal(clsSession.UserID);
                objContact.Updated_Date = DateTime.Now;
                // insert or update the contact record depending on primary key
                if (PK_Property_Contact_ID > 0)
                    objContact.Update();
                else
                    objContact.Insert();

                // redirect to PropertyView page to display all information in view mode
                Response.Redirect("PropertyView.aspx?loc=" + Request.QueryString["loc"]);
            }
            else
            {
                string strURL = "PropertyView.aspx?loc=" + Request.QueryString["loc"];
                ScriptManager.RegisterStartupScript(Page, GetType(), DateTime.Now.ToString(), "javascript:ConfirmProceed('" + strURL + "');", true);
                //// redirect to PropertyView page to display all information in view mode without saving the building information
                //Response.Redirect("PropertyView.aspx?loc=" + Request.QueryString["loc"]);
            }
        }
        else
            Response.Redirect("PropertyView.aspx?loc=" + Request.QueryString["loc"]);
    }

    /// <summary>
    /// Handles hidden button click in contacts panel to re-bind the grids after adding or updating the contact record
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnUpdateContactGrids_Click(object sender, EventArgs e)
    {
        // bind all contacts grid
        BindEmergencyContactGrid();
        BindUtilityContactGrid();
        BindOtherContactGrid();
    }

    /// <summary>
    /// Handles event when back button of Saba training clicked
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnBackProperty_Click(object sender, EventArgs e)
    {
        hdnPKPropertySabaTraning.Value = "";
        ScriptManager.RegisterStartupScript(Page, GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(1);", true);
    }

    protected void btngvLeaseSave_OnClick(object sender, EventArgs e)
    {
        if (PK_Building_ID > 0 && PK_Building_Ownership > 0)
        {
            clsBuilding_Ownership_Sublease ObjBuilding_Ownership_Sublease = new clsBuilding_Ownership_Sublease();
            ObjBuilding_Ownership_Sublease.PK_Building_Ownership_Sublease = PK_Building_OwnershipSubLease;
            ObjBuilding_Ownership_Sublease.FK_Building_Ownership = PK_Building_Ownership;
            ObjBuilding_Ownership_Sublease.Sublease_Name = txtSubLease_Name.Text.Trim();
            ObjBuilding_Ownership_Sublease.SubLease_Landlord = txtSubLandlord.Text.Trim();
            ObjBuilding_Ownership_Sublease.Sublease_Address_1 = txtSublease_Address_1.Text.Trim();
            ObjBuilding_Ownership_Sublease.Sublease_Address_2 = txtSublease_Address_2.Text.Trim();
            ObjBuilding_Ownership_Sublease.Sublease_City = txtSublease_City.Text.Trim();
            if (ddlSublease_State.SelectedIndex > 0) ObjBuilding_Ownership_Sublease.Sublease_State = ddlSublease_State.SelectedValue;
            ObjBuilding_Ownership_Sublease.Sublease_Zip = txtSublease_Zip.Text.Trim();
            ObjBuilding_Ownership_Sublease.Sublease_FirstName = txtSubleaseFirstName.Text.Trim();
            ObjBuilding_Ownership_Sublease.Sublease_LastName = txtSubleaseLastName.Text.Trim();
            ObjBuilding_Ownership_Sublease.Sublease_Title = txtSubleaseTitle.Text.Trim();
            ObjBuilding_Ownership_Sublease.Sublease_Phone = txtSubleasePhone.Text.Trim();
            ObjBuilding_Ownership_Sublease.Sublease_Fax = txtSubleaseFax.Text.Trim();
            ObjBuilding_Ownership_Sublease.Sublease_Email = txtSubleaseEmail.Text.Trim();
            ObjBuilding_Ownership_Sublease.Updated_By = Convert.ToDecimal(clsSession.UserID);
            ObjBuilding_Ownership_Sublease.Updated_Date = DateTime.Now;

            if (PK_Building_OwnershipSubLease > 0)
                ObjBuilding_Ownership_Sublease.Update();
            else
                ObjBuilding_Ownership_Sublease.Insert();

            txtSubLease_Name.Text = "";
            txtSubLandlord.Text = "";
            txtSublease_Address_1.Text = "";
            txtSublease_Address_2.Text = "";
            txtSublease_City.Text = "";
            ddlSublease_State.SelectedValue = "";
            txtSublease_Zip.Text = "";
            txtSubleaseFirstName.Text = "";
            txtSubleaseLastName.Text = "";
            txtSubleaseTitle.Text = "";
            txtSubleasePhone.Text = "";
            txtSubleaseFax.Text = "";
            txtSubleaseEmail.Text = "";
            trSubLease.Style["display"] = "none";
            trbtngvLeaseSave.Style["display"] = "none";
            BindSubLeaseGrid();
        }
    }
    #endregion

    #region "ADD NEW LINKS CLICKS"

    /// <summary>
    /// Handles Add New link click in Building information section
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkAddNewBuilding_Click(object sender, EventArgs e)
    {
        btnViewAuditBuilding.Visible = false;
        btnViewAuditOwnership.Visible = false;
        btnViewAuditContacts.Visible = false;
        btnViewAuditAdditionalInsured.Style["display"] = "none";
        // re-initialize the Building PK and Ownership PK
        PK_Building_ID = -1;
        PK_Building_Ownership = -1;
        PK_Property_Contact_ID = -1;

        // clear building, ownership and contact details controls
        ClearBuildingControls();
        ClearOwnershipControls();
        ClearContactDetailsControls();

        rdoOwnership.Items[0].Selected = true;
        dvBuilding.Style["display"] = "";
        ucCtrlExposureInfo.SetRMLocationCode(PK_Building_ID);
        //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "", "javascript:seLocationBuildingNumber('" + strLocationCode + "');", true);
    }

    /// <summary>
    /// Handles Add new link click in Assessment panel
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkAddNewAssessment_Click(object sender, EventArgs e)
    {
        btnViewAuditPropertyAssessment.Visible = false;
        // re-initialize PK to -1
        PK_Property_Assessment_ID = -1;

        // clear assessment controls to add new values
        ClearAssessmentControls();
        trAssessmentHistory.Style["display"] = "";
    }

    protected void lnkAddAssessmentConcern_Click(object sender, EventArgs e)
    {
        btnViewAuditAssessmentConcern.Visible = false;
        PK_Property_Assessment_Concern_ID = -1;

        ClearAssessmentConcernControls();
        trConcernNote.Style["display"] = "";
    }

    /// <summary>
    /// Handles Add New link click in Contacts panel
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkAddNewContact_Click(object sender, EventArgs e)
    {
        btnViewAuditContacts.Visible = false;
        // check if building ID is available
        if (PK_Building_ID > 0)
            ScriptManager.RegisterClientScriptBlock(Page, GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(5);OpenPropertyDetailPopup(0," + PK_Building_ID + ",'')", true);
        else
            ScriptManager.RegisterClientScriptBlock(Page, GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(5);alert('Please Select/Enter Building Information First');", true);
    }

    protected void lnkAddBuildingImprove_Click(object sender, EventArgs e)
    {
        // check if building ID is available
        if (PK_Building_ID > 0)
            Response.Redirect("BuildingImprovements.aspx?build=" + Encryption.Encrypt(PK_Building_ID.ToString()));
        else
            ScriptManager.RegisterClientScriptBlock(Page, GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(2);alert('Please Select/Enter Building Information First');", true);
    }

    protected void lnkFinancialLimitGrid_Click(object sender, EventArgs e)
    {
        // check if building ID is available
        if (PK_Building_ID > 0)
            Response.Redirect("BuildingFinancilaLimit.aspx?build=" + Encryption.Encrypt(PK_Building_ID.ToString()));
        else
            ScriptManager.RegisterClientScriptBlock(Page, GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(2);alert('Please Select/Enter Building Information First');", true);
    }

    /// <summary>
    /// Handles Event when Saba Traning add is clicked
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lbAddSabaTraining_Click(object sender, EventArgs e)
    {
        SavePropertyCope();
        CLearsabaTrainingControls();
        hdrPropertyCope.Style["display"] = tblPropertyCope.Style["display"] = "none";
        pnlSabaTraining.Style["display"] = "";
    }

    protected void lnkAddNewGGKL_Click(object sender, EventArgs e)
    {
        // check if building ID is available
        if (PK_Building_ID > 0)
            Response.Redirect("Building_GGKL.aspx?build=" + Encryption.Encrypt(PK_Building_ID.ToString()));
        else
            ScriptManager.RegisterClientScriptBlock(Page, GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(2);alert('Please Select/Enter Building Information First');", true);
    }

    #endregion

    #region "GRIDVIEW EVENTS"

    /// <summary>
    /// Handles Building grid rowcommand event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvBuildingEdit_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        // if passed command is for viewing building details
        if (e.CommandName == "ViewBuildingDetail")
        {
            // set PK as ID passed in command argument
            PK_Building_ID = Convert.ToInt32(e.CommandArgument);

            // bind building details

            BindBuildingDetails();
            SetDynamicInsuranceControl();
            BindInuranceDetailForEdit(PK_Building_ID);
        }
        else if (e.CommandName == "RemoveBuilding") // if passed command is for removing building details
        {
            // delete building detail record using ID passed in command argument
            Building.DeleteByPK(Convert.ToInt32(e.CommandArgument));

            // bind the building grid
            BindGridBuilding();

            // if current building PK is same as passed ID 
            if (PK_Building_ID == Convert.ToInt32(e.CommandArgument))
            {
                // re-initialize PKs to default values
                PK_Building_ID = -1;
                PK_Building_Ownership = -1;

                // clear building, ownership and contact controls
                ClearBuildingControls();
                ClearOwnershipControls();
                ClearContactDetailsControls();
                rdoOwnership.Items[0].Selected = true;
                dvBuilding.Style["display"] = "none";
            }
        }
    }

    /// <summary>
    /// Handles Building grid row data bound event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvBuildingEdit_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        // if row type is data row
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            // get occupancies values bound to the grid
            Label lblOccupancy = (Label)e.Row.FindControl("lblOccupancy");
            bool bOccupancy_Sales_New = Convert.ToBoolean(DataBinder.Eval(e.Row.DataItem, "Occupancy_Sales_New"));
            bool bOccupancy_Body_Shop = Convert.ToBoolean(DataBinder.Eval(e.Row.DataItem, "Occupancy_Body_Shop"));
            bool bOccupancy_Parking_Lot = Convert.ToBoolean(DataBinder.Eval(e.Row.DataItem, "Occupancy_Parking_Lot"));
            bool bOccupancy_Sales_Used = Convert.ToBoolean(DataBinder.Eval(e.Row.DataItem, "Occupancy_Sales_Used"));
            bool bOccupancy_Parts = Convert.ToBoolean(DataBinder.Eval(e.Row.DataItem, "Occupancy_Parts"));
            bool bOccupancy_Raw_Land = Convert.ToBoolean(DataBinder.Eval(e.Row.DataItem, "Occupancy_Raw_Land"));
            bool bOccupancy_Service = Convert.ToBoolean(DataBinder.Eval(e.Row.DataItem, "Occupancy_Service"));
            bool bOccupancy_Ofifce = Convert.ToBoolean(DataBinder.Eval(e.Row.DataItem, "Occupancy_Ofifce"));


            string strOccupancy = ""; // used to set the comma seperated occupancies

            // append occupancy text with comma seperation depending on the values
            if (bOccupancy_Sales_New) strOccupancy = "Sales - New";
            if (bOccupancy_Body_Shop) strOccupancy = strOccupancy != "" ? strOccupancy + "," + "Body Shop" : "Body Shop";
            if (bOccupancy_Parking_Lot) strOccupancy = strOccupancy != "" ? strOccupancy + "," + "Parking Lot" : "Parking Lot";
            if (bOccupancy_Sales_Used) strOccupancy = strOccupancy != "" ? strOccupancy + "," + "Sales - Used" : "Sales - Used";
            if (bOccupancy_Parts) strOccupancy = strOccupancy != "" ? strOccupancy + "," + "Parts" : "Parts";
            if (bOccupancy_Raw_Land) strOccupancy = strOccupancy != "" ? strOccupancy + "," + "Raw Land" : "Raw Land";
            if (bOccupancy_Service) strOccupancy = strOccupancy != "" ? strOccupancy + "," + "Service" : "Service";
            if (bOccupancy_Ofifce) strOccupancy = strOccupancy != "" ? strOccupancy + "," + "Office" : "Office";

            // set text in occupancy column
            lblOccupancy.Text = strOccupancy;
        }
    }

    /// <summary>
    /// Handles Additional Insured grid row command event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvAdditionalInsureds_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        // check if passed command is for viewing details
        if (e.CommandName == "ViewDetails")
        {
            // set PK as ID passed in command argument
            PK_Building_Additional_Insureds = Convert.ToInt32(e.CommandArgument);

            // bind details for Insured
            BindAdditionalInsuredDetails();

        }
        else if (e.CommandName == "RemoveInsured") // if passed command is for removing Insured information
        {
            // delete the Additional_Isured_Payee record by ID passed in command argument
            Building_Additional_Insureds_Payees.DeleteByPK(Convert.ToInt32(e.CommandArgument));

            // bind additional Insured grid
            BindGridAdditionalInsureds();

            // if PK for Isured is same as Passed ID
            if (PK_Building_Additional_Insureds == Convert.ToInt32(e.CommandArgument))
            {
                // re-initialize PK to default value
                PK_Building_Additional_Insureds = -1;

                // clear Additonal Insured controls
                ClearAdditionalInsuredControls();
            }
        }
    }

    /// <summary>
    /// Handles Named Loss Payee grid rowcommand event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvPayee_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        // if passed command is for viewing details
        if (e.CommandName == "ViewDetails")
        {
            // set PK for Payee as ID passed in command argument
            PK_Building_Payee = Convert.ToInt32(e.CommandArgument);

            // bind details for payee 
            BindPayeeDetails();
        }
        else if (e.CommandName == "RemovePayee") // if passed command is for removing payee
        {
            // delete the payee record by ID passed in command argument
            Building_Additional_Insureds_Payees.DeleteByPK(Convert.ToInt32(e.CommandArgument));

            // bind grid payee
            BindGridPayees();

            // if PK for payee is same as the ID passed in command argument
            if (PK_Building_Payee == Convert.ToInt32(e.CommandArgument))
            {
                // re-initialize the PK to default value
                PK_Building_Payee = -1;

                // clear payee details controls
                ClearPayeeDetailsControls();
            }
        }
    }

    /// <summary>
    /// Handles Assessment grid rowcommand event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvAssessment_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        // if passed command is for viewing details
        if (e.CommandName == "ViewDetails")
        {
            // set PK as ID passed in command argument
            PK_Property_Assessment_ID = Convert.ToInt32(e.CommandArgument);

            // Bind assessment details 
            BindAssessmentDetails();
        }
        else if (e.CommandName == "RemoveAssessment") // if passed command is for removing assessment record
        {
            // delete assessment record by ID passed in command argument
            Property_Assessment.DeleteByPK(Convert.ToInt32(e.CommandArgument));

            // bind assessment grid
            BindGridAssessment();

            // if PK for assessment is same as ID passed in commad argument
            if (PK_Property_Assessment_ID == Convert.ToInt32(e.CommandArgument))
            {
                // re-initialize PK with default value and clear assessment controls
                PK_Property_Assessment_ID = -1;
                ClearAssessmentControls();
            }
        }
    }

    /// <summary>
    /// Handles Concern Notes rowcommand event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvConcernNotes_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        // if passed command is for viewing details
        if (e.CommandName == "ViewDetails")
        {
            // get PK from command argument
            PK_Property_Assessment_Concern_ID = Convert.ToInt32(e.CommandArgument);

            // bind concern details controls
            BindAssessmentConcernDetails();
        }
        else if (e.CommandName == "RemoveConcern") // if passed command is for removing concern record
        {
            // delete concern record by ID passed in command argument
            Property_Assessment_Concern.DeleteByPK(Convert.ToInt32(e.CommandArgument));

            // bind assessment concern grid
            BindGridAssessmentConcern();

            // if PK for assessment concern is same as ID passed in command argument
            if (PK_Property_Assessment_Concern_ID == Convert.ToInt32(e.CommandArgument))
            {
                // re-initialize PK to default value and clear assessment controls
                PK_Property_Assessment_Concern_ID = -1;
                ClearAssessmentConcernControls();
            }
        }
    }

    /// <summary>
    /// Handles Emergency Contact grid rowcommand event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvEmergencyContact_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        // if passed command is for viewing details
        if (e.CommandName == "ViewDetails")
        {
            // open pop up with the details filled in controls
            ScriptManager.RegisterClientScriptBlock(Page, GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(5);OpenPropertyDetailPopup(" + e.CommandArgument + "," + PK_Building_ID + ",'edit')", true);
        }
        else if (e.CommandName == "RemoveContact") // if passed command is for removing contact
        {
            // delete property_contact record by ID passed in command argument
            Property_Contact.DeleteByPK(Convert.ToInt32(e.CommandArgument));

            // bind emergency contact grid
            BindEmergencyContactGrid();
        }
    }

    /// <summary>
    /// Handles Utility contacts grid rowcommand event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvUtilityContacts_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        // if passed command is for viewing details
        if (e.CommandName == "ViewDetails")
        {
            // open pop up with the details filled in controls
            ScriptManager.RegisterClientScriptBlock(Page, GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(5);OpenPropertyDetailPopup(" + e.CommandArgument + "," + PK_Building_ID + ",'edit')", true);
        }
        else if (e.CommandName == "RemoveContact")
        {
            // delete property_contact record by ID passed in command argument
            Property_Contact.DeleteByPK(Convert.ToInt32(e.CommandArgument));

            // bind utility contact grid
            BindUtilityContactGrid();
        }
    }

    /// <summary>
    /// Handles Other contacts grid rowcommand event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvOtherContacts_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        // if passed command is for viewing details
        if (e.CommandName == "ViewDetails")
        {
            // open pop up with the details filled in controls
            ScriptManager.RegisterClientScriptBlock(Page, GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(5);OpenPropertyDetailPopup(" + e.CommandArgument + "," + PK_Building_ID + ",'edit')", true);
        }
        else if (e.CommandName == "RemoveContact")
        {
            // delete property_contact record by ID passed in command argument
            Property_Contact.DeleteByPK(Convert.ToInt32(e.CommandArgument));

            // bind other contact grid
            BindOtherContactGrid();
        }
    }

    protected void gvBuildingImprovements_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "ShowDetails")
        {
            Response.Redirect("BuildingImprovements.aspx?build=" + Encryption.Encrypt(PK_Building_ID.ToString()) + "&id=" + Encryption.Encrypt(e.CommandArgument.ToString()) + "&op=edit");
        }
        else if (e.CommandName == "RemoveDetails")
        {
            Building_Improvements.DeleteByPK(Convert.ToDecimal(e.CommandArgument));
            BindBuildingImprovementGrid();
        }
    }

    protected void gvFinancialLimit_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "ShowDetails")
        {
            Response.Redirect("BuildingFinancilaLimit.aspx?build=" + Encryption.Encrypt(PK_Building_ID.ToString()) + "&id=" + Encryption.Encrypt(e.CommandArgument.ToString()) + "&op=edit");
        }
        else if (e.CommandName == "RemoveDetails")
        {
            Building_Financial_Limits.DeleteByPK(Convert.ToDecimal(e.CommandArgument));
            BindBuildingFinancialLimitGrid();
        }
    }

    protected void gvGGKL_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "ShowDetails")
        {
            Response.Redirect("Building_GGKL.aspx?build=" + Encryption.Encrypt(PK_Building_ID.ToString()) + "&id=" + Encryption.Encrypt(e.CommandArgument.ToString()) + "&op=edit");
        }
        else if (e.CommandName == "RemoveDetails")
        {
            Building_GGKL.DeleteByPK(Convert.ToDecimal(e.CommandArgument));
            BindBuildingGGKLGrid();
        }
    }

    /// <summary>
    /// Handles gvSabaTraining grid row command event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvSabaTraining_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index;
        if (e.CommandName == "gvEdit")
        {
            hdnPKPropertySabaTraning.Value = e.CommandArgument.ToString();
            hdrPropertyCope.Style["display"] = tblPropertyCope.Style["display"] = "none";
            pnlSabaTraining.Style["display"] = "";
            BindSabaDetailForEdit();

            this.btnViewAuditSabaTraining.Attributes.Add("onclick", "javascript:return ShowAuditPopUp('AuditPopup_SabaTraining.aspx?id=" + hdnPKPropertySabaTraning.Value.ToString() + "');");
        }
        else if (e.CommandName == "Remove")
        {
            index = Convert.ToInt32(e.CommandArgument);
            DeleteSabaTraining(index);

            gvSabaTraining.DataSource = Property_COPE_Saba_Training.SelectByProperty_Cope(PK_Property_Cope_ID);
            gvSabaTraining.DataBind();
            ScriptManager.RegisterStartupScript(Page, GetType(), DateTime.Now.ToString(), "ShowPanel(1);", true);
        }
    }

    protected void gvSubLease_OnRowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "ViewSubLeaseDetails")
        {
            PK_Building_OwnershipSubLease = Convert.ToInt32(e.CommandArgument);
            BinSubLeaseDetails();
        }
        int gvLeaseIndex;
        if (e.CommandName == "RemoveLease")
        {
            gvLeaseIndex = Convert.ToInt32(e.CommandArgument);
            clsBuilding_Ownership_Sublease.DeleteByPK(gvLeaseIndex);
            BindSubLeaseGrid();
            ClearSubLeaseControl();
            trSubLease.Style["display"] = "none";
            trbtngvLeaseSave.Style["display"] = "none";
        }
    }

    private void ClearSubLeaseControl()
    {
        txtSubLease_Name.Text = "";
        txtSublease_Address_1.Text = "";
        txtSublease_Address_2.Text = "";
        txtSublease_City.Text = "";
        ddlSublease_State.SelectedIndex = 0;
        txtSublease_Zip.Text = "";
        txtSubLandlord.Text = "";
        txtSubleaseFirstName.Text = "";
        txtSubleaseLastName.Text = "";
        txtSubleaseTitle.Text = "";
        txtSubleasePhone.Text = "";
        txtSubleaseFax.Text = "";
        txtSubleaseEmail.Text = "";
    }


    private void BindSabaDetailForEdit()
    {
        decimal index;
        if (decimal.TryParse(hdnPKPropertySabaTraning.Value, out index))
        {
            Property_COPE_Saba_Training objSabaTraining = new Property_COPE_Saba_Training(index);
            txtSaba_Training_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objSabaTraining.Date);

            if (txtSaba_Training_Date.Text == "")
            {
                if (objSabaTraining.Year > 0)
                {
                    drpSabaTrainingYear.ClearSelection();
                    ListItem lst = drpSabaTrainingYear.Items.FindByValue(objSabaTraining.Year.ToString());
                    lst.Selected = true;
                }

                if (objSabaTraining.Quarter > 0)
                {
                    drpQuarter.ClearSelection();
                    ListItem lst = drpQuarter.Items.FindByValue(objSabaTraining.Quarter.ToString());
                    lst.Selected = true;
                }
            }

            trSabaTrainingQuarter.Style["display"] = txtSaba_Training_Date.Text == "" ? "" : "none";
            trSabaTrainingYear.Style["display"] = txtSaba_Training_Date.Text == "" ? "" : "none";

            txtNumber_of_Employees.Text = clsGeneral.GetStringValue(objSabaTraining.Number_of_Employees).Replace(".00", "");
            txtNumber_of_Employees_To_Date.Text = clsGeneral.GetStringValue(objSabaTraining.Number_Trained).Replace(".00", "");
            if (objSabaTraining.Percent_Trained.HasValue)
                txtPercent_Employee_to_Date.Text = objSabaTraining.Percent_Trained.ToString();
        }
    }

    private void DeleteSabaTraining(int index)
    {
        Property_COPE_Saba_Training.DeleteByPK(index);
    }

    #region "Attachment Grids"
    /// <summary>
    /// Handles building Attachment grid rowcommand event 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvBuildingAttachmentDetails_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        // if passed command is for removing attachment then
        // delete the attachment record by PK passed in command argument and
        // bind the grid
        if (e.CommandName == "RemoveAttachment")
        {
            string[] strArgs = e.CommandArgument.ToString().Split(':');
            int intPK = Convert.ToInt32(strArgs[0]);
            string strFileName = strArgs[1];
            Building_Attachments.DeleteByPK(intPK);
            BindGridBuildingAttachments();

            // delete file
            string strPath = clsGeneral.GetAttachmentDocPath(clsGeneral.ExposureTableNames[(int)clsGeneral.Exposure_Tables.Property_Building]) + strFileName;
            if (File.Exists(strPath))
                File.Delete(strPath);
        }
    }

    /// <summary>
    /// Handles Building grid row data bound event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvBuildingAttachmentDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        // check for the datarow
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            // get the filename link control
            HtmlAnchor lnkBuildingAttachFile = (HtmlAnchor)e.Row.FindControl("lnkBuildingAttachFile");

            // get the file name value from binder
            string strFileName = DataBinder.Eval(e.Row.DataItem, "FileName").ToString();
            strFileName = AppConfig.BuildingAttachDocPath + strFileName.Replace("#", "%23");
            // set click attribute to open file on clicking the link
            string strFilePath = Encryption.Encrypt(strFileName).Replace("'", "\\'");
            lnkBuildingAttachFile.Attributes.Add("onclick", "javascript:window.open('" + AppConfig.SiteURL + "/Download.aspx?attachfile=" + strFilePath + "')");
            
        }
    }

    /// <summary>
    /// Handles the Lease Attachment grid rowcommad event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvLeaseAttachmentDetails_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        // if passed command is for removing attachment then
        // delete the attachment record by PK passed in command argument and
        // bind the grid
        if (e.CommandName == "RemoveAttachment")
        {
            string[] strArgs = e.CommandArgument.ToString().Split(':');
            int intPK = Convert.ToInt32(strArgs[0]);
            string strFileName = strArgs[1];
            Lease_SubLease_Attachments.DeleteByPK(intPK);
            BindGridLeaseAttachments();

            // delete file
            string strPath = clsGeneral.GetAttachmentDocPath(clsGeneral.ExposureTableNames[(int)clsGeneral.Exposure_Tables.Property_Ownership_SubLease]) + strFileName;
            if (File.Exists(strPath))
                File.Delete(strPath);
        }
    }

    /// <summary>
    /// Handles Lease Sublease attachment grid row data bound
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvLeaseAttachmentDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        // check for the datarow
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            // get the filename link control and set attribute to open the file when clicking
            HtmlAnchor lnkLeaseAttachFile = (HtmlAnchor)e.Row.FindControl("lnkLeaseAttachFile");
            string strFileName = DataBinder.Eval(e.Row.DataItem, "FileName").ToString();
            strFileName = AppConfig.LeaseSubleaseDocPath + strFileName;
            // set click attribute to open file on clicking the link
            string strFilePath = Encryption.Encrypt(strFileName).Replace("'", "\\'");
            lnkLeaseAttachFile.Attributes.Add("onclick", "javascript:window.open('" + AppConfig.SiteURL + "/Download.aspx?attachfile=" + strFilePath + "')");
            
        }
    }

    /// <summary>
    /// Handles assessment attachment grid rowcommand event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvAssessmentAttachment_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        // if passed command is for removing attachment then
        // delete the attachment record by PK passed in command argument and
        // bind the grid
        if (e.CommandName == "RemoveAttachment")
        {
            string[] strArgs = e.CommandArgument.ToString().Split(':');
            int intPK = Convert.ToInt32(strArgs[0]);
            string strFileName = strArgs[1];
            Assessment_Attachments.DeleteByPK(intPK);
            BindGridAssessmentAttachment();

            // delete file
            string strPath = clsGeneral.GetAttachmentDocPath(clsGeneral.ExposureTableNames[(int)clsGeneral.Exposure_Tables.Property_Assessment]) + strFileName;
            if (File.Exists(strPath))
                File.Delete(strPath);
        }
    }

    /// <summary>
    /// Handles assessment attachment row data bound event 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvAssessmentAttachment_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        // check for data row
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            // get the filename link control and set attribute to open the file when clicking
            HtmlAnchor lnkFileName = (HtmlAnchor)e.Row.FindControl("lnkFileName");
            string strFileName = DataBinder.Eval(e.Row.DataItem, "FileName").ToString();
            strFileName = AppConfig.PropertyAssessmentDocPath + strFileName;
         
            // set click attribute to open file on clicking the link
            string strFilePath = Encryption.Encrypt(strFileName).Replace("'", "\\'");
            lnkFileName.Attributes.Add("onclick", "javascript:window.open('" + AppConfig.SiteURL + "/Download.aspx?attachfile=" + strFilePath + "')");
        }
    }

    #endregion

    #endregion

    #endregion

    #region "Methods"

    /// <summary>
    /// Save Property Cope Data
    /// </summary>
    private void SavePropertyCope()
    {
        #region " Property COPE "

        // create object for Property cope
        Property_COPE objProperty = new Property_COPE(PK_Property_Cope_ID);

        // get values from page controls
        objProperty.PK_Property_Cope_ID = PK_Property_Cope_ID;
        objProperty.FK_LU_Location_ID = FK_LU_Location_ID;
        objProperty.Status = ddlStatus.SelectedValue;
        objProperty.Status_As_Of_Date = clsGeneral.FormatDateToStore(txtStatus_As_Of_Date);
        objProperty.Disposal_Type = objProperty.Status == "Disposed" ? txtDisposal_Type.Text.Trim() : string.Empty;
        objProperty.Union_shop = clsGeneral.FormatYesNoToStore(rdoUnion_Shop);
        objProperty.Property_Boundary_Dimemsions = txtProperty_Boundry_Dimension.Text.Trim();
        objProperty.Address_1 = txtAddress_1.Text.Trim();
        objProperty.Address_2 = txtAddress_2.Text.Trim();
        objProperty.City = txtCity.Text.Trim();
        objProperty.State = ddlState.SelectedValue;
        objProperty.Zip = txtZip.Text.Trim();
        objProperty.Telephone = txtTelephone.Text.Trim();
        objProperty.Web_site = txtWeb_Site.Text.Trim();
        objProperty.Valuation_Date = clsGeneral.FormatDateToStore(txtValuation_Date);
        objProperty.Updated_By = Convert.ToDecimal(clsSession.UserID);
        objProperty.Updated_Date = DateTime.Now;
        // save the record depending on the primary key
        if (PK_Property_Cope_ID > 0)
            objProperty.Update();
        else
            PK_Property_Cope_ID = objProperty.Insert();
        #endregion
    }

    #region "BIND OR CLEAR PAGE CONTROLS"

    /// <summary>
    /// Binds details for Page in edit mode
    /// </summary>
    private void BindDetailsForEdit()
    {
        btnViewAuditPropertyCOPE.Visible = true;
        #region " Property COPE info "

        // declare object for Proeprty cope
        Property_COPE objProperty = new Property_COPE(Convert.ToDecimal(PK_Property_Cope_ID));

        // set values in page controls
        ddlStatus.SelectedValue = objProperty.Status;

        txtStatus_As_Of_Date.Text = clsGeneral.FormatDateToDisplay(objProperty.Status_As_Of_Date);
        txtDisposal_Type.Text = objProperty.Disposal_Type;
        if (objProperty.Status == "Disposed") tdDisposal.Style["display"] = "";
        clsGeneral.FormatYesNoToDisplayForEdit(rdoUnion_Shop, objProperty.Union_shop);
        txtProperty_Boundry_Dimension.Text = objProperty.Property_Boundary_Dimemsions;
        txtAddress_1.Text = objProperty.Address_1;
        txtAddress_2.Text = objProperty.Address_2;
        txtCity.Text = objProperty.City;
        ddlState.SelectedValue = objProperty.State;
        txtZip.Text = objProperty.Zip;
        txtTelephone.Text = objProperty.Telephone;
        txtWeb_Site.Text = objProperty.Web_site;
        txtValuation_Date.Text = clsGeneral.FormatDateToDisplay(objProperty.Valuation_Date);

        LU_Location objLocation = new LU_Location(Convert.ToDecimal(FK_LU_Location_ID));

        //lblAddress_1.Text = objLocation.Address_1;
        //lblAddress_2.Text = objLocation.Address_2;
        //lblCity.Text = objLocation.City;
        //lblState.Text = objLocation.State != "" ? Convert.ToString(new State(Convert.ToDecimal(objLocation.State)).FLD_state) : "";
        //lblZip.Text = objLocation.Zip_Code;        

        if (objLocation.Active == "N")
        {
            lnkAddNewBuilding.Visible = false;
            lnkAddNewAssessment.Visible = false;
            lnkAddNewAssessment.Visible = false;
        }

        

        #endregion

        #region " Financial Limits "

        // get data for financial limits summary from all building records for the location
        DataTable dtLimits = Building.SelectFinancialLimitsByLocation(FK_LU_Location_ID).Tables[0];

        // if data is avaliable
        if (dtLimits.Rows.Count > 0)
        {
            // get values from datarow
            DataRow drLimits = dtLimits.Rows[0];
            decimal decBuilding_Limit = Convert.ToDecimal(drLimits["Building_Limit_Total"]);
            decimal decLeasehold_Interests_Limit_Betterment = Convert.ToDecimal(drLimits["Leasehold_Interests_Limit_Betterment_Total"]);
            decimal decLeasehold_Interests_Limit_Expansion = Convert.ToDecimal(drLimits["Leasehold_Interests_Limit_Expansion_Total"]);
            decimal decAssociate_Tools_Limit = Convert.ToDecimal(drLimits["Associate_Tools_Limit_Total"]);
            decimal decContents_Limit = Convert.ToDecimal(drLimits["Contents_Limit_Total"]);
            decimal decParts_Limit = Convert.ToDecimal(drLimits["Parts_Limit_Total"]);
            decimal decInventory_Levels = Convert.ToDecimal(drLimits["Inventory_Levels"]);
            decimal decRS_Means_Building_Value_Total = Convert.ToDecimal(drLimits["RS_Means_Building_Value_Total"]);

            // set values in finalcial limit section controls
            lblBuilding_Limit.Text = clsGeneral.GetStringValue(decBuilding_Limit);
            lblLeasehold_Interests_Limit_Betterment.Text = clsGeneral.GetStringValue(decLeasehold_Interests_Limit_Betterment);
            lblLeasehold_Interests_Limit_Expansion.Text = clsGeneral.GetStringValue(decLeasehold_Interests_Limit_Expansion);
            lblAssociate_Tools_Limit.Text = clsGeneral.GetStringValue(decAssociate_Tools_Limit);
            lblContents_Limit.Text = clsGeneral.GetStringValue(decContents_Limit);
            lblParts_Limit.Text = clsGeneral.GetStringValue(decParts_Limit);
            lblBetterment_Date_Complate.Text = clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drLimits["Betterment_Date_Complete"]));
            lblExpansion_Date_Complate.Text = clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drLimits["Expansion_Date_Complete"]));
            lblInventory_Levels.Text = clsGeneral.GetStringValue(decInventory_Levels);
            lblRS_Means_Building_Value_Total.Text = clsGeneral.GetStringValue(decRS_Means_Building_Value_Total);
            // count and set the total
            decimal decTotal = decBuilding_Limit + decLeasehold_Interests_Limit_Betterment + decLeasehold_Interests_Limit_Expansion + decAssociate_Tools_Limit + decContents_Limit + decParts_Limit + decInventory_Levels + decRS_Means_Building_Value_Total;
            lblCalculated.Text = clsGeneral.GetStringValue(decTotal);
        }
        #endregion

        #region " Bind SABA Training Grid"

        gvSabaTraining.DataSource = Property_COPE_Saba_Training.SelectByProperty_Cope(PK_Property_Cope_ID);
        gvSabaTraining.DataBind();

        #endregion
    }

    /// <summary>
    /// Binds the location information
    /// </summary>
    private void BindLocationInformation()
    {
        // create object for Location
        LU_Location objLocation = new LU_Location(Convert.ToDecimal(FK_LU_Location_ID));

        // set location values
        lblLocationdba.Text = objLocation.dba;
        lblLegalEntity.Text = objLocation.legal_entity;
        DataTable dtFKA = LU_Location_FKA.SelectByLocationID(Convert.ToDecimal(FK_LU_Location_ID)).Tables[0];
        if (dtFKA.Rows.Count > 0)
        {
            DataRow drFKA = dtFKA.Rows[0];
            lblLocationfka.Text = Convert.ToString(drFKA["fka"]);
        }
        lblLocationRMNumber.Text = objLocation.Sonic_Location_Code.ToString();
    }

    /// <summary>
    /// Binds building details
    /// </summary>
    private void BindBuildingDetails()
    {
        btnViewAuditBuilding.Visible = true;
        // clear all previously displayed control
        ClearBuildingControls();


        // create object for building
        Building objBuilding = new Building(PK_Building_ID);
        if (objBuilding.Ownership == "ThirdParty" || objBuilding.Ownership == "ThirdPartySublease")
        {
            gridSubLease.Style["display"] = "";
            trgvSubLease.Style["display"] = "";
        }
        else
        {
            gridSubLease.Style["display"] = "none";
            trgvSubLease.Style["display"] = "none";
        }

        #region " Get Building values in page controls "
        ddlSecuCam_State.SelectedValue = objBuilding.SecuCam_State;
        drpLocationStatus.SelectedValue = Convert.ToString(objBuilding.Location_Status);
        clsGeneral.FormatYesNoToDisplayForEdit(rdoGuard_System, objBuilding.Guard_System);
        if (objBuilding.Guard_System == true)
        {
            txtGuard_System.Text = objBuilding.Guard_System_Name;
            txtGuard_Contact_Name.Text = objBuilding.Guard_Contact_Name;
            txtGuard_Vendor_Name.Text = objBuilding.Guard_Vendor_Name;
            txtGuard_Contact_Expiration_Date.Text = clsGeneral.FormatDateToDisplay(objBuilding.Guard_Contact_Expiration_Date);
            txtGuard_Address_1.Text = objBuilding.Guard_Address_1;
            txtGuard_Address_2.Text = objBuilding.Guard_Address_2;
            txtGuard_City.Text = objBuilding.Guard_City;
            ddlGuard_State.SelectedValue = objBuilding.Guard_State;
            txtGuard_Zip.Text = objBuilding.Guard_Zip;
            txtGuard_Telephone_Number.Text = objBuilding.Guard_Telephone_Number;
            txtGuard_Alternate_Number.Text = objBuilding.Guard_Alternate_Number;
            txtGuard_Email.Text = objBuilding.Guard_Email;
            txtGuard_Comments.Text = objBuilding.Guard_Comments;
            trGuardSystem.Style["display"] = "";
        }


        clsGeneral.FormatYesNoToDisplayForEdit(rdoIntru_System, objBuilding.Intru_System);
        if (objBuilding.Intru_System == true)
        {
            txtIntru_System.Text = objBuilding.Intru_System_Name;
            txtIntru_Contact_Name.Text = objBuilding.Intru_Contact_Name;
            txtIntru_Vendor_Name.Text = objBuilding.Intru_Vendor_Name;
            txtIntru_Contact_Expiration_Date.Text = clsGeneral.FormatDateToDisplay(objBuilding.Intru_Contact_Expiration_Date);
            txtIntru_Address_1.Text = objBuilding.Intru_Address_1;
            txtIntru_Address_2.Text = objBuilding.Intru_Address_2;
            txtIntru_City.Text = objBuilding.Intru_City;
            ddlIntru_State.SelectedValue = objBuilding.Intru_State;
            txtIntru_Zip.Text = objBuilding.Intru_Zip;
            txtIntru_Telephone_Number.Text = objBuilding.Intru_Telephone_Number;
            txtIntru_Alternate_Number.Text = objBuilding.Intru_Alternate_Number;
            txtIntru_Email.Text = objBuilding.Intru_Email;
            txtIntru_Comments.Text = objBuilding.Intru_Comments;
            ddlIntru_Contact_Alarm_Type.SelectedValue = objBuilding.Intru_Contact_Alarm_Type;
            trIntrusionAlarms.Style["display"] = "";
        }

        clsGeneral.FormatYesNoToDisplayForEdit(rdoFence, objBuilding.Fence);
        if (objBuilding.Fence == true)
        {
            chkRazor_Wire.Checked = objBuilding.Fence_Razor_Wire;
            chkFence_Electrified.Checked = objBuilding.Fence_Electrified;
            trFence.Style["display"] = "";
        }


        clsGeneral.FormatYesNoToDisplayForEdit(rdoGenerator, objBuilding.Generator);
        if (objBuilding.Generator == true)
        {
            txtGenerator_Make.Text = objBuilding.Generator_Make;
            txtGenerator_Model.Text = objBuilding.Generator_Model;
            txtGenerator_Size.Text = objBuilding.Generator_Size;
            trGenerator.Style["display"] = "";
        }


        ddlFireDeptType.SelectedValue = objBuilding.Fire_Department_Type;
        ddlDistance.SelectedValue = objBuilding.Fire_Department_Distance;
        clsGeneral.FormatYesNoToDisplayForEdit(rdoTier_1_County, objBuilding.Tier_1_County);
        clsGeneral.FormatYesNoToDisplayForEdit(rdoEarthquake_Zone_Fault_Line, objBuilding.Earthquake_Zone_Fault_Line);
        clsGeneral.FormatYesNoToDisplayForEdit(rdoNeighboring_Buildings_within_100_ft, objBuilding.Neighboring_Buildings_within_100_ft);
        if (objBuilding.Neighboring_Buildings_within_100_ft == true)
        {
            txtNeighbor_Occupancy.Text = objBuilding.Neighbor_Occupancy;
            tblNeighboringOccupancy.Style["display"] = "";
        }

        ddlDistance_from_body_of_water.SelectedValue = objBuilding.Distance_from_body_of_water;
        clsGeneral.FormatYesNoToDisplayForEdit(rdoPrior_Flood_History, objBuilding.Prior_Flood_History);
        if (objBuilding.Prior_Flood_History == true)
        {
            txtFlood_History_Descr.Text = objBuilding.Flood_History_Descr;
            trFloodHistory.Style["display"] = "";
        }
        txtLowest_finish_floor_elevation.Text = clsGeneral.GetStringValue(objBuilding.Lowest_finish_floor_elevation).Replace(".00", "");
        clsGeneral.FormatYesNoToDisplayForEdit(rdoProperty_Damage_Losses_in_the_Past_5_years, objBuilding.Property_Damage_Losses_in_the_Past_5_years);
        if (objBuilding.Property_Damage_Losses_in_the_Past_5_years == true)
        {
            txtProperty_Loss_Descr.Text = objBuilding.Property_Loss_Descr;
            trPropertyDamageLoss.Style["display"] = "";
        }
        txtFloodZone.Text = objBuilding.Flood_Zone;
        clsGeneral.FormatYesNoToDisplayForEdit(rdoNational_Flood_Policy, objBuilding.National_Flood_Policy);
        if (objBuilding.National_Flood_Policy == true)
        {
            txtFlood_Carrier.Text = objBuilding.Flood_Carrier;
            txtFlood_Policy_Number.Text = objBuilding.Flood_Policy_Number;
            txtFlood_Premium.Text = clsGeneral.GetStringValue(objBuilding.Flood_Premium);
            txtFlood_Polciy_Limits_Contents.Text = clsGeneral.GetStringValue(objBuilding.Flood_Polciy_Limits_Contents);
            txtFlood_Policy_Inception_Date.Text = clsGeneral.FormatDateToDisplay(objBuilding.Flood_Policy_Inception_Date);
            txtFlood_Policy_Expiration_Date.Text = clsGeneral.FormatDateToDisplay(objBuilding.Flood_Policy_Expiration_Date);
            txtFlood_Deductible.Text = clsGeneral.GetStringValue(objBuilding.Flood_Deductible);
            txtFlood_Policy_Limits_Building.Text = clsGeneral.GetStringValue(objBuilding.Flood_Policy_Limits_Building);

            trNational_Flood_Policy.Style["display"] = "";
        }

        txtComments.Text = objBuilding.Comments;
        rdoOwnership.SelectedValue = objBuilding.Ownership;

        if (rdoOwnership.SelectedValue == "ThirdParty" || rdoOwnership.SelectedValue == "ThirdPartySublease")
        {
            rdoLiability.SelectedValue = objBuilding.Liability;
            trLiability.Style["display"] = "";
        }
        else
            trLiability.Style["display"] = "none";

        chkLstOccupancy.Items[0].Selected = objBuilding.Occupancy_Sales_New;
        chkLstOccupancy.Items[1].Selected = objBuilding.Occupancy_Body_Shop;
        chkLstOccupancy.Items[2].Selected = objBuilding.Occupancy_Parking_Lot;
        chkLstOccupancy.Items[3].Selected = objBuilding.Occupancy_Sales_Used;
        chkLstOccupancy.Items[4].Selected = objBuilding.Occupancy_Parts;
        chkLstOccupancy.Items[5].Selected = objBuilding.Occupancy_Raw_Land;
        chkLstOccupancy.Items[6].Selected = objBuilding.Occupancy_Service;
        chkLstOccupancy.Items[7].Selected = objBuilding.Occupancy_Ofifce;

        txtBuildingAddress_1.Text = objBuilding.Address_1;
        txtBuildingAddress_2.Text = objBuilding.Address_2;
        txtBuilding_City.Text = objBuilding.City;
        ddlBuidingState.SelectedValue = objBuilding.State;
        txtBuilding_Zip.Text = objBuilding.Zip;

        //txtFinancial_Building_Limit.Text = clsGeneral.GetStringValue(objBuilding.Building_Limit);
        //txtFinancial_Leasehold_Interests_Limit_Betterment.Text = clsGeneral.GetStringValue(objBuilding.Leasehold_Interests_Limit_Betterment);
        //txtFinancial_Betterment_Date_Complate.Text = clsGeneral.FormatDateToDisplay(objBuilding.Betterment_Date_Complete);
        //txtFinancial_Leasehold_Interests_Limit_Expansion.Text = clsGeneral.GetStringValue(objBuilding.Leasehold_Interests_Limit_Expansion);
        //txtFinancial_Expansion_Date_Complate.Text = clsGeneral.FormatDateToDisplay(objBuilding.Expansion_Date_Complete);
        //txtFinancial_Associate_Tools_Limit.Text = clsGeneral.GetStringValue(objBuilding.Associate_Tools_Limit);
        //txtFinancial_Contents_Limit.Text = clsGeneral.GetStringValue(objBuilding.Contents_Limit);
        //txtFinancial_Parts_Limit.Text = clsGeneral.GetStringValue(objBuilding.Parts_Limit);
        //txtFinancial_Inventory_Levels.Text = clsGeneral.GetStringValue(objBuilding.Inventory_Levels);
        //txtRS_Means_Building_Value.Text = clsGeneral.GetStringValue(objBuilding.RS_Means_Building_Value);

        //decimal decBuildLimit = objBuilding.Building_Limit > 0 ? (decimal)objBuilding.Building_Limit : 0;
        //decimal decBetterment = objBuilding.Leasehold_Interests_Limit_Betterment > 0 ? (decimal)objBuilding.Leasehold_Interests_Limit_Betterment : 0;
        //decimal decExpansion = objBuilding.Leasehold_Interests_Limit_Expansion > 0 ? (decimal)objBuilding.Leasehold_Interests_Limit_Expansion : 0;
        //decimal decToolsLimit = objBuilding.Associate_Tools_Limit > 0 ? (decimal)objBuilding.Associate_Tools_Limit : 0;
        //decimal decContents = objBuilding.Contents_Limit > 0 ? (decimal)objBuilding.Contents_Limit : 0;
        //decimal decPartsLimit = objBuilding.Parts_Limit > 0 ? (decimal)objBuilding.Parts_Limit : 0;
        //decimal decInventory = objBuilding.Inventory_Levels > 0 ? (decimal)objBuilding.Inventory_Levels : 0;
        //decimal decRS_Means_Building_Value = objBuilding.RS_Means_Building_Value > 0 ? (decimal)objBuilding.RS_Means_Building_Value : 0;

        //decimal decTotal = decBuildLimit + decBetterment + decExpansion + decToolsLimit + decContents + decPartsLimit + decInventory + decRS_Means_Building_Value;

        //txtFinancial_Total.Text = clsGeneral.GetStringValue(decTotal);

        txtYear_Built.Text = objBuilding.Year_Built;
        txtSquare_Footage.Text = objBuilding.Square_Footage;
        txtNumber_of_Stories.Text = clsGeneral.GetStringValue(objBuilding.Number_of_Stories);
        chkRoof_Reinforced_Concrete.Checked = objBuilding.Roof_Reinforced_Concrete;
        chkRoof_Concrete_Panels.Checked = objBuilding.Roof_Concrete_Panels;
        chkRoof_Steel_Deck_With_Fasteners.Checked = objBuilding.Roof_Steel_Deck_with_Fasteners;
        chkRoof_Poured_Concrete.Checked = objBuilding.Roof_Poured_Concrete;
        chkRoof_Steel_Deck.Checked = objBuilding.Roof_Steel_Deck;
        chkRoof_Wood_Joists.Checked = objBuilding.Roof_Wood_Joists;
        chkFloors_Reinforced_Concrete.Checked = objBuilding.Floors_Reinforced_Concrete;
        chkFloors_Poured_Concrete.Checked = objBuilding.Floors_Poured_Concrete;
        chkFloors_Wood_Timber.Checked = objBuilding.Floors_Wood_Timber;
        chkExt_Walls_Reinforced_Concrete.Checked = objBuilding.Ext_Walls_Reinforced_Concrete;
        chkExt_Walls_Masonry.Checked = objBuilding.Ext_Walls_Masonry;
        chkExt_Walls_Corrugated_Metal_Panels.Checked = objBuilding.Ext_Walls_Corrugated_Metal_Panels;
        chkExt_Walls_Tilt_up_Concrete.Checked = objBuilding.Ext_Walls_Tilt_up_Concrete;
        chkExt_Walls_Glass_and_Steel_Curtain.Checked = objBuilding.Ext_Walls_Glass_and_Steel_Curtain;
        chkExt_Walls_Wood_Frame.Checked = objBuilding.Ext_Walls_Wood_Frame;
        chkInt_Walls_Masonry_With_Fire_Doors.Checked = objBuilding.Int_Walls_Masonry_With_Fire_Doors;
        chkInt_Walls_Masonry_with_Openings.Checked = objBuilding.Int_Walls_Masonry_with_Openings;
        chkInt_Walls_No_Interior_Walls.Checked = objBuilding.Int_Walls_No_Interior_Walls;
        chkInt_Walls_Masonry.Checked = objBuilding.Int_Walls_Masonry;
        chkInt_Walls_Gypsum_Board.Checked = objBuilding.Int_Walls_Gypsum_Board;
        clsGeneral.FormatYesNoToDisplayForEdit(rdoInt_wall_extend_above_roof, objBuilding.Int_wall_extend_above_roof);
        txtNumber_of_Paint_Booths.Text = clsGeneral.GetStringValue(objBuilding.Number_of_Paint_Booths).Replace(".00", "");
        txtNumber_of_Lifts.Text = clsGeneral.GetStringValue(objBuilding.Number_of_Lifts).Replace(".00", "");
        txtSales_New_Sprinklered.Text = clsGeneral.GetStringValue(objBuilding.Sales_New_Sprinklered);
        txtSales_Used_Sprinklered.Text = clsGeneral.GetStringValue(objBuilding.Sales_Used_Sprinklered);
        txtService_Sprinklered.Text = clsGeneral.GetStringValue(objBuilding.Service_Sprinklered);
        txtBody_Shop_Sprinklered.Text = clsGeneral.GetStringValue(objBuilding.Body_Shop_Sprinklered);
        txtParts_Sprinklered.Text = clsGeneral.GetStringValue(objBuilding.Parts_Sprinklered);
        txtOffice_Sprinklered.Text = clsGeneral.GetStringValue(objBuilding.Office_Sprinklered);
        chkWater_Public.Checked = objBuilding.Water_Public;
        chkWater_Private.Checked = objBuilding.Water_Private;
        chkWater_Boosted.Checked = objBuilding.Water_Boosted;
        txtDesign_Densities_for_each_area.Text = objBuilding.Design_Densities_for_each_area;
        clsGeneral.FormatYesNoToDisplayForEdit(rdoHydrants_within_500_ft, objBuilding.Hydrants_within_500_ft);
        chkAlarm_UL_Central_Station.Checked = objBuilding.Alarm_UL_Central_Station;
        chkAlarm_Constant_Attended.Checked = objBuilding.Alarm_Constant_Attended;
        chkAlarm_Sprinkler_Valve_Tamper.Checked = objBuilding.Alarm_Sprinkler_Valve_Tamper;
        chkAlarm_Non_UL_Central_Station.Checked = objBuilding.Alarm_Non_UL_Central_Station;
        chkAlarm_Local.Checked = objBuilding.Alarm_Local;
        chkAlarm_Smoke_Detectors.Checked = objBuilding.Alarm_Smoke_Detectors;
        chkAlarm_Proprietary.Checked = objBuilding.Alarm_Proprietary;
        chkAlarm_Sprinkler_Waterflow.Checked = objBuilding.Alarm_Sprinkler_Waterflow;
        chkAlarm_Dry_Pipe_Air.Checked = objBuilding.Alarm_Dry_Pipe_Air;
        chkAlarm_Remote.Checked = objBuilding.Alarm_Remote;
        chkAlarm_Fire_Pump_Alarms.Checked = objBuilding.Alarm_Fire_Pump_Alarms;
        clsGeneral.FormatYesNoToDisplayForEdit(rdoAlarm_Auto_Fire_Alarms, objBuilding.Alarm_Auto_Fire_Alarms);
        clsGeneral.FormatYesNoToDisplayForEdit(rdoAlarm_Security_Cameras, objBuilding.Alarm_Security_Cameras);

        if (objBuilding.Alarm_Security_Cameras == true)
        {
            txtsecuCam_System.Text = objBuilding.SecuCam_System;
            txtSecuCam_Contact_Name.Text = objBuilding.SecuCam_Contact_Name;
            txtSecuCam_Vendor_Name.Text = objBuilding.SecuCam_Vendor_Name;
            txtSecuCam_Contact_Expiration_Date.Text = clsGeneral.FormatDateToDisplay(objBuilding.SecuCam_Contact_Expiration_Date);
            txtSecuCam_Address_1.Text = objBuilding.SecuCam_Address_1;
            txtSecuCam_Address_2.Text = objBuilding.SecuCam_Address_2;
            txtSecuCam_City.Text = objBuilding.SecuCam_City;
            txtSecuCam_Zip.Text = objBuilding.SecuCam_Zip;
            txtSecuCam_Telephone_Number.Text = objBuilding.SecuCam_Telephone_Number;
            txtSecuCam_Alternate_Number.Text = objBuilding.SecuCam_Alternate_Number;
            txtSecuCam_Email.Text = objBuilding.SecuCam_Email;
            txtSecuCam_Comments.Text = objBuilding.SecuCam_Comments;
            trSecurityCameras.Style["display"] = "";
        }

        txtNumberOfBays.Text = clsGeneral.GetStringValue(objBuilding.Number_of_Bays).Replace(".00", "");
        txtNumberOfLifts.Text = clsGeneral.GetStringValue(objBuilding.Number_of_Lifts_SC).Replace(".00", "");
        txtNumberOfPrepAreas.Text = clsGeneral.GetStringValue(objBuilding.Number_of_Prep_Areas).Replace(".00", "");
        txtNumberOfCarWashStations.Text = clsGeneral.GetStringValue(objBuilding.Number_of_Car_Wash_Stations).Replace(".00", "");

        txtFireContactName.Text = objBuilding.Fire_Contact_Name;
        txtFireVendorName.Text = objBuilding.Fire_Vendor_Name;
        txtFireContactExpirationDate.Text = clsGeneral.FormatDBNullDateToDisplay_Claim(objBuilding.Fire_Contact_Expiration_Date);
        txtFireAddress1.Text = objBuilding.Fire_Address_1;
        txtFireAddress2.Text = objBuilding.Fire_Address_2;
        txtFireCity.Text = objBuilding.Fire_City;
        drpFireState.SelectedValue = objBuilding.Fire_State;
        txtFireZipCode.Text = objBuilding.Fire_Zip;
        txtFireTelephone.Text = objBuilding.Fire_Telephone_Number;
        txtFireAlternateNumber.Text = objBuilding.Fire_Alternate_Number;
        txtFireEmail.Text = objBuilding.Fire_Email;
        txtFireComments.Text = objBuilding.Fire_Comments;
        if (objBuilding.Number_Of_Parking_Spaces != null) txtNumber_Of_Parking_Spaces.Text = string.Format("{0:N0}", objBuilding.Number_Of_Parking_Spaces);
        if (objBuilding.Acreage != null) txtAcreage.Text = Convert.ToDecimal(objBuilding.Acreage).ToString("N3").Replace("$", "");
        BindBuildingFinancialLimitGrid();
        BindBuildingImprovementGrid();
        BindBuildingGGKLGrid();
        #endregion

        string strLocationCode = ucCtrlExposureInfo.Int_Location_Code.ToString() + ", Building Number " + objBuilding.Building_Number;

        // set Building FK for building and lease attachment
        BuildingAttachment.FK_Building_ID = PK_Building_ID;
        LeaseAttachment.FK_Building_ID = PK_Building_ID;

        // bind building attahcment grid
        BindGridBuildingAttachments();
        dvBuilding.Style["display"] = "";

        // show ownership details and contacts details
        BindOwnershipDetails();
        clsBuilding_Ownership_Sublease ObjclsBuilding_Ownership_Sublease = new clsBuilding_Ownership_Sublease();
        ObjclsBuilding_Ownership_Sublease.FK_Building_Ownership = PK_Building_Ownership;
        BindSubLeaseGrid();
        PK_Property_Contact_ID = Property_Contact.SelectPKByBuilding_ID(PK_Building_ID);
        BindContactsDetails();
        ucCtrlExposureInfo.SetRMLocationCode(PK_Building_ID);
        //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "", "javascript:seLocationBuildingNumber('" + strLocationCode + "');", true);
    }

    /// <summary>
    /// Binds Ownership details
    /// </summary>
    private void BindOwnershipDetails()
    {
        btnViewAuditOwnership.Visible = true;
        // hide Owned and Leased sections
        //trOwned.Style["display"] = "none";
        //trLeased.Style["display"] = "none";
        trSubLease.Style["display"] = "none";
        // check if Building ID is available
        if (PK_Building_ID > 0)
        {
            // create object for building
            Building objBuilding = new Building(PK_Building_ID);

            // set PK building ownership
            PK_Building_Ownership = Building_Ownership.SelectPKByBuildingID(PK_Building_ID);
            Building_Ownership objOwnership = new Building_Ownership(PK_Building_Ownership);

            txtLandlord_Name.Text = objOwnership.Landlord_Name;
            txtLandlord_Address_1.Text = objOwnership.Landlord_Address_1;
            txtLandlord_Address_2.Text = objOwnership.Landlord_Address_2;
            txtLandlord_City.Text = objOwnership.Landlord_City;
            ddlLandlord_State.SelectedValue = objOwnership.Landlord_State;
            txtLandlord_Zip.Text = objOwnership.Landlord_Zip;
            txtLease_ID.Text = objOwnership.Lease_ID;
            txtLandlordLegalEntity.Text = objOwnership.Landlord_Legal_Entity;
            txtCommencement_Date.Text = clsGeneral.FormatDateToDisplay(objOwnership.Commencement_Date);
            txtExpiration_Date.Text = clsGeneral.FormatDateToDisplay(objOwnership.Expiration_Date);

            if (objBuilding.Ownership == "ThirdParty" || objBuilding.Ownership == "ThirdPartySublease")
            {
                txtSubLease_Name.Text = objOwnership.Sublease_Name;
                txtSubLandlord.Text = objOwnership.SubLandlord;
                txtSublease_Address_1.Text = objOwnership.Sublease_Address_1;
                txtSublease_Address_2.Text = objOwnership.Sublease_Address_2;
                txtSublease_City.Text = objOwnership.Sublease_City;
                if (objOwnership.Sublease_State != null) ddlSublease_State.SelectedValue = objOwnership.Sublease_State;
                txtSublease_Zip.Text = objOwnership.Sublease_Zip;
                trSubLease.Style["display"] = "none";

                txtSubleaseFirstName.Text = objOwnership.Sublease_FirstName;
                txtSubleaseLastName.Text = objOwnership.Sublease_LastName;
                txtSubleaseTitle.Text = objOwnership.Sublease_Title;
                txtSubleasePhone.Text = objOwnership.Sublease_Phone;
                txtSubleaseFax.Text = objOwnership.Sublease_Fax;
                txtSubleaseEmail.Text = objOwnership.Sublease_Email;

                revSubleasePhone.Enabled = true;
                revSubleaseFax.Enabled = true;
                revSubleaseEmail.Enabled = true;
            }


            if (objBuilding.Ownership == "ThirdPartyLease" || objBuilding.Ownership == "ThirdPartySublease" || objBuilding.Ownership == "Internal")
            {
                txtCOI_Wording.Text = objOwnership.COI_Wording;

                chkREQWC.Checked = objOwnership.REQ_WC;
                chkREQEL.Checked = objOwnership.REQ_EL;
                chkREQGL.Checked = objOwnership.REQ_GL;
                chkREQPollution.Checked = objOwnership.REQ_Pollution;
                chkREQProperty.Checked = objOwnership.REQ_Property;
                chkREQFlood.Checked = objOwnership.REQ_Flood;
                chkREQEQ.Checked = objOwnership.REQ_EQ;
                chkREQWaiver.Checked = objOwnership.REQ_WaiverofSubrogation;

                chkWCTenant.Checked = objOwnership.SubResponsible_WC;
                chkELTenant.Checked = objOwnership.SubResponsible_EL;
                chkGLTenant.Checked = objOwnership.SubResponsible_GL;
                chkPollutionTenant.Checked = objOwnership.SubResponsible_Pollution;
                chkPropertyTenant.Checked = objOwnership.SubResponsible_Property;
                chkFloodTenant.Checked = objOwnership.SubResponsible_Flood;
                chkEQTenant.Checked = objOwnership.EQ;
                chkWaiverTenant.Checked = objOwnership.WaiverofSubrogation;

                // set the COI link 
                lnkCOI_WC.Text = objOwnership.COI_WC == "" ? "Add" : FormatCOIFileName(objOwnership.COI_WC);
                lnkCOI_EL.Text = objOwnership.COI_EL == "" ? "Add" : FormatCOIFileName(objOwnership.COI_EL);
                lnkCOI_GL.Text = objOwnership.COI_GL == "" ? "Add" : FormatCOIFileName(objOwnership.COI_GL);
                lnkCOI_Pollution.Text = objOwnership.COI_Pollution == "" ? "Add" : FormatCOIFileName(objOwnership.COI_Pollution);
                lnkCOI_Property.Text = objOwnership.COI_Property == "" ? "Add" : FormatCOIFileName(objOwnership.COI_Property);
                lnkCOI_Flood.Text = objOwnership.COI_Flood == "" ? "Add" : FormatCOIFileName(objOwnership.COI_Flood);
                lnkCOI_EQ.Text = objOwnership.COI_EQ == "" ? "Add" : FormatCOIFileName(objOwnership.COI_EQ);
                lnkCOI_Waiver.Text = objOwnership.COI_WaiverofSubrogation == "" ? "Add" : FormatCOIFileName(objOwnership.COI_WaiverofSubrogation);

                // set the URL in hidden controls to be used for opening file when clicking on COI file link
                if (objOwnership.COI_WC != "") hdnCOI_WC_URL.Value = AppConfig.PropertyCOIDocURL + objOwnership.COI_WC;
                if (objOwnership.COI_EL != "") hdnCOI_EL_URL.Value = AppConfig.PropertyCOIDocURL + objOwnership.COI_EL;
                if (objOwnership.COI_GL != "") hdnCOI_GL_URL.Value = AppConfig.PropertyCOIDocURL + objOwnership.COI_GL;
                if (objOwnership.COI_Pollution != "") hdnCOI_Pollution_URL.Value = AppConfig.PropertyCOIDocURL + objOwnership.COI_Pollution;
                if (objOwnership.COI_Property != "") hdnCOI_Property_URL.Value = AppConfig.PropertyCOIDocURL + objOwnership.COI_Property;
                if (objOwnership.COI_Flood != "") hdnCOI_Flood_URL.Value = AppConfig.PropertyCOIDocURL + objOwnership.COI_Flood;
                if (objOwnership.COI_EQ != "") hdnCOI_EQ_URL.Value = AppConfig.PropertyCOIDocURL + objOwnership.COI_EQ;
                if (objOwnership.COI_WaiverofSubrogation != "") hdnCOI_Waiver_URL.Value = AppConfig.PropertyCOIDocURL + objOwnership.COI_WaiverofSubrogation;

                // set COI dates
                lblCOI_WC_Date.Text = clsGeneral.FormatDateToDisplay(objOwnership.COI_WC_Date);
                lblCOI_EL_Date.Text = clsGeneral.FormatDateToDisplay(objOwnership.COI_EL_Date);
                lblCOI_GL_Date.Text = clsGeneral.FormatDateToDisplay(objOwnership.COI_GL_Date);
                lblCOI_Pollution_Date.Text = clsGeneral.FormatDateToDisplay(objOwnership.COI_Pollution_Date);
                lblCOI_Property_Date.Text = clsGeneral.FormatDateToDisplay(objOwnership.COI_Property_Date);
                lblCOI_Flood_Date.Text = clsGeneral.FormatDateToDisplay(objOwnership.COI_Flood_Date);
                lblCOI_EQ_Date.Text = clsGeneral.FormatDateToDisplay(objOwnership.COI_EQ_Date);
                lblCOI_Waiver_Date.Text = clsGeneral.FormatDateToDisplay(objOwnership.COI_WaiverofSubrogation_Date);

                // set dates in hidden controls to be used when saving the record
                hdnCOI_WC_Date.Value = lblCOI_WC_Date.Text;
                hdnCOI_EL_Date.Value = lblCOI_EL_Date.Text;
                hdnCOI_GL_Date.Value = lblCOI_GL_Date.Text;
                hdnCOI_Pollution_Date.Value = lblCOI_Pollution_Date.Text;
                hdnCOI_Property_Date.Value = lblCOI_Property_Date.Text;
                hdnCOI_Flood_Date.Value = lblCOI_Flood_Date.Text;
                hdnCOI_EQ_Date.Value = lblCOI_EQ_Date.Text;
                hdnCOI_Waiver_Date.Value = lblCOI_Waiver_Date.Text;

                // set limits
                txtReqLim_WC.Text = clsGeneral.GetStringValue(objOwnership.ReqLim_WC);
                txtReqLim_EL.Text = clsGeneral.GetStringValue(objOwnership.ReqLim_EL);
                txtReqLim_GL.Text = clsGeneral.GetStringValue(objOwnership.ReqLim_GL);
                txtReqLim_Pollution.Text = clsGeneral.GetStringValue(objOwnership.ReqLim_Pollution);
                txtReqLim_Property.Text = clsGeneral.GetStringValue(objOwnership.ReqLim_Property);
                txtReqLim_Flood.Text = clsGeneral.GetStringValue(objOwnership.ReqLim_Flood);
                txtReqLim_EQ.Text = clsGeneral.GetStringValue(objOwnership.ReqLim_EQ);
                txtReqLim_Waiver.Text = clsGeneral.GetStringValue(objOwnership.ReqLim_WaiverofSubrogation);

                // show or hide the limits if Insurance requirements are checked
                tblWCLimit.Style["display"] = chkREQWC.Checked ? "" : "none";
                tblELLimit.Style["display"] = chkREQEL.Checked ? "" : "none";
                tblGLLimit.Style["display"] = chkREQGL.Checked ? "" : "none";
                tblPollutionLimit.Style["display"] = chkREQPollution.Checked ? "" : "none";
                tblPropertyLimit.Style["display"] = chkREQProperty.Checked ? "" : "none";
                tblFloodLimit.Style["display"] = chkREQFlood.Checked ? "" : "none";
                tblEQLimit.Style["display"] = chkREQEQ.Checked ? "" : "none";
                tblWaiverLimit.Style["display"] = chkREQWaiver.Checked ? "" : "none";

                //trOwned.Style["display"] = "none";
                //trLeased.Style["display"] = "block";
            }

        }

        // bind additional insured, named loss payee and attachment grid
        BindGridAdditionalInsureds();
        BindGridPayees();
        BindGridLeaseAttachments();
    }

    /// <summary>
    /// Binds additional insured details
    /// </summary>
    private void BindAdditionalInsuredDetails()
    {
        btnViewAuditAdditionalInsured.Style["display"] = "";
        // create object for Additional_Insured_payee
        Building_Additional_Insureds_Payees objInsuredPayee = new Building_Additional_Insureds_Payees(PK_Building_Additional_Insureds);

        // set values in page controls
        txtAdditional_Insureds_Named.Text = objInsuredPayee.Named;
        txtAdditional_Insureds_Address_1.Text = objInsuredPayee.Address_1;
        txtAdditional_Insureds_Address_2.Text = objInsuredPayee.Address_2;
        txtAdditional_Insureds_City.Text = objInsuredPayee.City;
        ddlAdditional_Insureds_State.SelectedValue = objInsuredPayee.State;
        txtAdditional_Insureds_Zip.Text = objInsuredPayee.Zip;

        // bind additional insured grid
        BindGridAdditionalInsureds();
        trAdditionalInsured.Style["display"] = "";
    }

    /// <summary>
    /// Binds Payee details
    /// </summary>
    private void BindPayeeDetails()
    {
        btnViewAuditLossPayee.Style["Display"] = "";
        // create object for Insured payee
        Building_Additional_Insureds_Payees objInsuredPayee = new Building_Additional_Insureds_Payees(PK_Building_Payee);

        // set values in page controls
        txtLoss_Payees_Named.Text = objInsuredPayee.Named;
        txtLoss_Payees_Address_1.Text = objInsuredPayee.Address_1;
        txtLoss_Payees_Address_2.Text = objInsuredPayee.Address_2;
        txtLoss_Payees_City.Text = objInsuredPayee.City;
        ddlLoss_Payees_State.SelectedValue = objInsuredPayee.State;
        txtLoss_Payees_Zip.Text = objInsuredPayee.Zip;
        ddlLoss_Payees_Type.SelectedValue = objInsuredPayee.Type;

        // bind payee grid
        BindGridPayees();
        trNamedLossPayees.Style["display"] = "";
    }

    private void BinSubLeaseDetails()
    {
        clsBuilding_Ownership_Sublease ObjclsBuilding_Ownership_Sublease = new clsBuilding_Ownership_Sublease(PK_Building_OwnershipSubLease);
        txtSubLease_Name.Text = ObjclsBuilding_Ownership_Sublease.Sublease_Name;
        txtSubLandlord.Text = ObjclsBuilding_Ownership_Sublease.SubLease_Landlord;
        txtSublease_Address_1.Text = ObjclsBuilding_Ownership_Sublease.Sublease_Address_1;
        txtSublease_Address_2.Text = ObjclsBuilding_Ownership_Sublease.Sublease_Address_2;
        txtSublease_City.Text = ObjclsBuilding_Ownership_Sublease.Sublease_City;
        ddlSublease_State.SelectedValue = ObjclsBuilding_Ownership_Sublease.Sublease_State;
        txtSublease_Zip.Text = ObjclsBuilding_Ownership_Sublease.Sublease_Zip;
        txtSubleaseFirstName.Text = ObjclsBuilding_Ownership_Sublease.Sublease_FirstName;
        txtSubleaseLastName.Text = ObjclsBuilding_Ownership_Sublease.Sublease_LastName;
        txtSubleaseTitle.Text = ObjclsBuilding_Ownership_Sublease.Sublease_Title;
        txtSubleasePhone.Text = ObjclsBuilding_Ownership_Sublease.Sublease_Phone;
        txtSubleaseFax.Text = ObjclsBuilding_Ownership_Sublease.Sublease_Fax;
        txtSubleaseEmail.Text = ObjclsBuilding_Ownership_Sublease.Sublease_Email;
        BindSubLeaseGrid();
        trSubLease.Style["display"] = "";
        trbtngvLeaseSave.Style["display"] = "";
        btnLeaseAuditTrail.Style["dispaly"] = "";
    }

    /// <summary>
    /// Binds Assessment details controls
    /// </summary>
    private void BindAssessmentDetails()
    {
        btnViewAuditPropertyAssessment.Visible = true;
        // create object for assessment
        Property_Assessment objAssessment = new Property_Assessment(PK_Property_Assessment_ID);

        // set values in page controls
        txtAssessment_History_Date.Text = clsGeneral.FormatDateToDisplay(objAssessment.Date);
        txtAssessment_History_Assessor.Text = objAssessment.Assessor;
        txtAssessment_History_Contact_Name.Text = objAssessment.Contact_Name;
        txtAssessment_History_Address_1.Text = objAssessment.Address_1;
        txtAssessment_History_Address_2.Text = objAssessment.Address_2;
        txtAssessment_History_City.Text = objAssessment.City;
        ddlAssessment_History_State.SelectedValue = objAssessment.State;
        txtAssessment_History_Zip.Text = objAssessment.Zip;
        txtAssessment_History_Telephone.Text = objAssessment.Telephone;
        trAssessmentHistory.Style["display"] = "";

        // bind assessment concern and assessment attachment grid
        BindGridAssessmentConcern();
        BindGridAssessmentAttachment();

        ClearAssessmentConcernControls();
        trConcernNote.Style["display"] = "none";
        trAssessmentAttachment.Style["display"] = "none";
    }

    /// <summary>
    /// Binds assessment concerns details
    /// </summary>
    private void BindAssessmentConcernDetails()
    {
        btnViewAuditAssessmentConcern.Visible = true;
        // create object for assessment concern
        Property_Assessment_Concern objConcern = new Property_Assessment_Concern(PK_Property_Assessment_Concern_ID);

        // set values in assessment controls
        txtItem_Description.Text = objConcern.Item_Description;
        txtBudgeted_Cost.Text = clsGeneral.GetStringValue(objConcern.Budgeted_Cost);
        txtActual_Cost.Text = clsGeneral.GetStringValue(objConcern.Actual_Cost);
        txtDate_Complete.Text = clsGeneral.FormatDateToDisplay(objConcern.Date_Complete);
        txtConcerns_Comments.Text = objConcern.Comments;
        trConcernNote.Style["display"] = "";
    }

    /// <summary>
    /// Binds Contacts details
    /// </summary>
    private void BindContactsDetails()
    {
        btnViewAuditContacts.Visible = true;
        // create object for contact
        Property_Contact objContact = new Property_Contact(PK_Property_Contact_ID);

        // set values in page controls
        txtName.Text = objContact.Name;
        txtPhone.Text = objContact.Phone;
        txtCell_Phone.Text = objContact.Cell_Phone;
        txtAfter_Hours_Contact_Name.Text = objContact.After_Hours_Contact_Name;
        txtAfter_Hours_Contact_Phone.Text = objContact.After_Hours_Contact_Phone;
        txtAfter_Hours_Contact_Cell_Phone.Text = objContact.After_Hours_Contact_Cell_Phone;

        // bind emergency, utility and other contact grid
        BindEmergencyContactGrid();
        BindUtilityContactGrid();
        BindOtherContactGrid();
    }

    /// <summary>
    /// Binds dropdown controls in page
    /// </summary>
    private void BindDropDowns()
    {
        //// binds State dropdown in Property COPE panel
        DataTable dtState = State.SelectAll().Tables[0];
        ddlState.DataSource = dtState;
        ddlState.DataValueField = "FLD_state";
        ddlState.DataTextField = "FLD_state";
        ddlState.DataBind();
        ddlState.Items.Insert(0, new ListItem("--SELECT--", ""));

        // binds State dropdown in Building information panel
        ddlBuidingState.DataSource = dtState;
        ddlBuidingState.DataTextField = "FLD_state";
        ddlBuidingState.DataValueField = "FLD_state";
        ddlBuidingState.DataBind();
        ddlBuidingState.Items.Insert(0, new ListItem("--SELECT--", ""));

        // binds State dropdown in Security Cameras section of Building information panel
        ddlSecuCam_State.DataSource = dtState;
        ddlSecuCam_State.DataTextField = "FLD_state";
        ddlSecuCam_State.DataValueField = "FLD_state";
        ddlSecuCam_State.DataBind();
        ddlSecuCam_State.Items.Insert(0, new ListItem("--SELECT--", ""));

        // binds State dropdown in Security Cameras section of Building information panel
        drpFireState.DataSource = dtState;
        drpFireState.DataTextField = "FLD_state";
        drpFireState.DataValueField = "FLD_state";
        drpFireState.DataBind();
        drpFireState.Items.Insert(0, new ListItem("--SELECT--", ""));

        // binds State dropdown in Security Guard Services section of Building information panel
        ddlGuard_State.DataSource = dtState;
        ddlGuard_State.DataTextField = "FLD_state";
        ddlGuard_State.DataValueField = "FLD_state";
        ddlGuard_State.DataBind();
        ddlGuard_State.Items.Insert(0, new ListItem("--SELECT--", ""));

        // binds State dropdown in Intrusion Alarms section of Building information panel
        ddlIntru_State.DataSource = dtState;
        ddlIntru_State.DataTextField = "FLD_state";
        ddlIntru_State.DataValueField = "FLD_state";
        ddlIntru_State.DataBind();
        ddlIntru_State.Items.Insert(0, new ListItem("--SELECT--", ""));

        // binds Flood Zone dropdown in Building Information panel
        //DataTable dtFloodZone = Flood_Zone.SelectAll().Tables[0];
        //ddlFlood_Zone.DataSource = dtFloodZone;
        //ddlFlood_Zone.DataTextField = "Fld_Desc";
        //ddlFlood_Zone.DataValueField = "Fld_Desc";
        //ddlFlood_Zone.DataBind();
        //ddlFlood_Zone.Items.Insert(0, new ListItem("--SELECT--", ""));

        // binds state dropdown in ownership panel
        //ddlOwner_State.DataSource = dtState;
        //ddlOwner_State.DataTextField = "FLD_state";
        //ddlOwner_State.DataValueField = "FLD_state";
        //ddlOwner_State.DataBind();
        //ddlOwner_State.Items.Insert(0, new ListItem("--SELECT--", ""));

        // binds state dropdown in ownership panel
        ddlLandlord_State.DataSource = dtState;
        ddlLandlord_State.DataTextField = "FLD_state";
        ddlLandlord_State.DataValueField = "FLD_state";
        ddlLandlord_State.DataBind();
        ddlLandlord_State.Items.Insert(0, new ListItem("--SELECT--", ""));

        // binds state dropdown in ownership panel
        ddlSublease_State.DataSource = dtState;
        ddlSublease_State.DataTextField = "FLD_state";
        ddlSublease_State.DataValueField = "FLD_state";
        ddlSublease_State.DataBind();
        ddlSublease_State.Items.Insert(0, new ListItem("--SELECT--", ""));

        // binds Additional Insured state dropdown
        ddlAdditional_Insureds_State.DataSource = dtState;
        ddlAdditional_Insureds_State.DataTextField = "FLD_state";
        ddlAdditional_Insureds_State.DataValueField = "FLD_state";
        ddlAdditional_Insureds_State.DataBind();
        ddlAdditional_Insureds_State.Items.Insert(0, new ListItem("--SELECT--", ""));

        //binds Named Loss payee state dropdown
        ddlLoss_Payees_State.DataSource = dtState;
        ddlLoss_Payees_State.DataTextField = "FLD_state";
        ddlLoss_Payees_State.DataValueField = "FLD_state";
        ddlLoss_Payees_State.DataBind();
        ddlLoss_Payees_State.Items.Insert(0, new ListItem("--SELECT--", ""));

        // Binds assessment history state dropdown in Assessment panel
        ddlAssessment_History_State.DataSource = dtState;
        ddlAssessment_History_State.DataTextField = "FLD_state";
        ddlAssessment_History_State.DataValueField = "FLD_state";
        ddlAssessment_History_State.DataBind();
        ddlAssessment_History_State.Items.Insert(0, new ListItem("--SELECT--", ""));

        //binds saba training year dropdown
        int _Year;

        // Fill Year Starting with 2007 to current Year
        for (_Year = System.DateTime.Now.Year; _Year >= 2011; _Year--)
            drpSabaTrainingYear.Items.Add(new ListItem(_Year.ToString(), _Year.ToString()));

        drpSabaTrainingYear.SelectedValue = System.DateTime.Now.Year.ToString();
    }

    /// <summary>
    /// Clears building information panel controls
    /// </summary>
    private void ClearBuildingControls()
    {
        drpLocationStatus.SelectedIndex = 0;
        ddlSecuCam_State.SelectedValue = "";
        rdoGuard_System.SelectedIndex = -1;
        txtGuard_Contact_Name.Text = "";
        txtGuard_Vendor_Name.Text = "";
        txtGuard_Contact_Expiration_Date.Text = "";
        txtGuard_Address_1.Text = "";
        txtGuard_Address_2.Text = "";
        txtGuard_City.Text = "";
        ddlGuard_State.SelectedValue = "";
        txtGuard_Zip.Text = "";
        txtGuard_Telephone_Number.Text = "";
        txtGuard_Alternate_Number.Text = "";
        txtGuard_Email.Text = "";
        txtGuard_Comments.Text = "";
        trGuardSystem.Style["display"] = "none";
        rdoIntru_System.SelectedIndex = -1;
        txtIntru_System.Text = "";
        txtIntru_Contact_Name.Text = "";
        txtIntru_Vendor_Name.Text = "";
        txtIntru_Contact_Expiration_Date.Text = "";
        txtIntru_Address_1.Text = "";
        txtIntru_Address_2.Text = "";
        txtIntru_City.Text = "";
        ddlIntru_State.SelectedValue = "";
        txtIntru_Zip.Text = "";
        txtIntru_Telephone_Number.Text = "";
        txtIntru_Alternate_Number.Text = "";
        txtIntru_Email.Text = "";
        txtIntru_Comments.Text = "";
        ddlIntru_Contact_Alarm_Type.SelectedValue = "";
        trIntrusionAlarms.Style["display"] = "none";
        rdoFence.SelectedIndex = -1;
        chkRazor_Wire.Checked = false;
        chkFence_Electrified.Checked = false;
        trFence.Style["display"] = "none";
        rdoGenerator.SelectedIndex = -1;
        txtGenerator_Make.Text = "";
        txtGenerator_Model.Text = "";
        txtGenerator_Size.Text = "";
        trGenerator.Style["display"] = "none";
        ddlFireDeptType.SelectedValue = "";
        ddlDistance.SelectedValue = "";
        rdoTier_1_County.SelectedIndex = -1;
        rdoEarthquake_Zone_Fault_Line.SelectedIndex = -1;
        rdoNeighboring_Buildings_within_100_ft.SelectedIndex = -1;
        tblNeighboringOccupancy.Style["display"] = "none";
        txtNeighbor_Occupancy.Text = "";
        ddlDistance_from_body_of_water.SelectedValue = "";
        rdoPrior_Flood_History.SelectedIndex = -1;
        txtFlood_History_Descr.Text = "";
        txtLowest_finish_floor_elevation.Text = "";
        rdoProperty_Damage_Losses_in_the_Past_5_years.SelectedIndex = -1;
        txtProperty_Loss_Descr.Text = "";
        trPropertyDamageLoss.Style["display"] = "none";
        txtFloodZone.Text = "";
        rdoNational_Flood_Policy.SelectedIndex = -1;
        txtFlood_Carrier.Text = "";
        txtFlood_Policy_Number.Text = "";
        txtFlood_Premium.Text = "";
        txtFlood_Polciy_Limits_Contents.Text = "";
        txtFlood_Policy_Inception_Date.Text = "";
        txtFlood_Policy_Expiration_Date.Text = "";
        txtFlood_Deductible.Text = "";
        txtFlood_Policy_Limits_Building.Text = "";
        trNational_Flood_Policy.Style["display"] = "none";
        txtComments.Text = "";
        rdoOwnership.SelectedIndex = -1;
        chkLstOccupancy.Items[0].Selected = false;
        chkLstOccupancy.Items[1].Selected = false;
        chkLstOccupancy.Items[2].Selected = false;
        chkLstOccupancy.Items[3].Selected = false;
        chkLstOccupancy.Items[4].Selected = false;
        chkLstOccupancy.Items[5].Selected = false;
        chkLstOccupancy.Items[6].Selected = false;
        chkLstOccupancy.Items[7].Selected = false;
        txtBuildingAddress_1.Text = "";
        txtBuildingAddress_2.Text = "";
        txtBuilding_City.Text = "";
        ddlBuidingState.SelectedValue = "";
        txtBuilding_Zip.Text = "";
        //txtFinancial_Building_Limit.Text = "";
        //txtFinancial_Leasehold_Interests_Limit_Betterment.Text = "";
        //txtFinancial_Betterment_Date_Complate.Text = "";
        //txtFinancial_Leasehold_Interests_Limit_Expansion.Text = "";
        //txtFinancial_Expansion_Date_Complate.Text = "";
        //txtFinancial_Associate_Tools_Limit.Text = "";
        //txtFinancial_Contents_Limit.Text = "";
        //txtFinancial_Parts_Limit.Text = "";
        //txtFinancial_Inventory_Levels.Text = "";
        //txtFinancial_Total.Text = "";
        //txtRS_Means_Building_Value.Text = "";
        txtYear_Built.Text = "";
        txtSquare_Footage.Text = "";
        txtNumber_of_Stories.Text = "";
        chkRoof_Reinforced_Concrete.Checked = false;
        chkRoof_Concrete_Panels.Checked = false;
        chkRoof_Steel_Deck_With_Fasteners.Checked = false;
        chkRoof_Poured_Concrete.Checked = false;
        chkRoof_Steel_Deck.Checked = false;
        chkRoof_Wood_Joists.Checked = false;
        chkFloors_Reinforced_Concrete.Checked = false;
        chkFloors_Poured_Concrete.Checked = false;
        chkFloors_Wood_Timber.Checked = false;
        chkExt_Walls_Reinforced_Concrete.Checked = false;
        chkExt_Walls_Masonry.Checked = false;
        chkExt_Walls_Corrugated_Metal_Panels.Checked = false;
        chkExt_Walls_Tilt_up_Concrete.Checked = false;
        chkExt_Walls_Glass_and_Steel_Curtain.Checked = false;
        chkExt_Walls_Wood_Frame.Checked = false;
        chkInt_Walls_Masonry_With_Fire_Doors.Checked = false;
        chkInt_Walls_Masonry_with_Openings.Checked = false;
        chkInt_Walls_No_Interior_Walls.Checked = false;
        chkInt_Walls_Masonry.Checked = false;
        chkInt_Walls_Gypsum_Board.Checked = false;
        rdoInt_wall_extend_above_roof.SelectedIndex = -1;
        txtNumber_of_Paint_Booths.Text = "";
        txtNumber_of_Lifts.Text = "";
        txtSales_New_Sprinklered.Text = "";
        txtSales_Used_Sprinklered.Text = "";
        txtService_Sprinklered.Text = "";
        txtBody_Shop_Sprinklered.Text = "";
        txtParts_Sprinklered.Text = "";
        txtOffice_Sprinklered.Text = "";
        chkWater_Public.Checked = false;
        chkWater_Private.Checked = false;
        chkWater_Boosted.Checked = false;
        txtDesign_Densities_for_each_area.Text = "";
        rdoHydrants_within_500_ft.SelectedIndex = -1;
        chkAlarm_UL_Central_Station.Checked = false;
        chkAlarm_Constant_Attended.Checked = false;
        chkAlarm_Sprinkler_Valve_Tamper.Checked = false;
        chkAlarm_Non_UL_Central_Station.Checked = false;
        chkAlarm_Local.Checked = false;
        chkAlarm_Smoke_Detectors.Checked = false;
        chkAlarm_Proprietary.Checked = false;
        chkAlarm_Sprinkler_Waterflow.Checked = false;
        chkAlarm_Dry_Pipe_Air.Checked = false;
        chkAlarm_Remote.Checked = false;
        chkAlarm_Fire_Pump_Alarms.Checked = false;
        rdoAlarm_Auto_Fire_Alarms.SelectedIndex = -1;
        rdoAlarm_Security_Cameras.SelectedIndex = -1;
        txtsecuCam_System.Text = "";
        txtSecuCam_Contact_Name.Text = "";
        txtSecuCam_Vendor_Name.Text = "";
        txtSecuCam_Contact_Expiration_Date.Text = "";
        txtSecuCam_Address_1.Text = "";
        txtSecuCam_Address_2.Text = "";
        txtSecuCam_City.Text = "";
        txtSecuCam_Zip.Text = "";
        txtSecuCam_Telephone_Number.Text = "";
        txtSecuCam_Alternate_Number.Text = "";
        txtSecuCam_Email.Text = "";
        txtSecuCam_Comments.Text = "";
        trSecurityCameras.Style["display"] = "none";
        trBuildingAttachment.Style["display"] = "none";
        txtNumberOfBays.Text = "";
        txtNumberOfLifts.Text = "";
        txtNumberOfPrepAreas.Text = "";
        txtNumberOfCarWashStations.Text = "";
        txtFireAddress1.Text = "";
        txtFireAddress2.Text = "";
        txtFireAlternateNumber.Text = "";
        txtFireCity.Text = "";
        txtFireComments.Text = "";
        txtFireContactExpirationDate.Text = "";
        txtFireContactName.Text = "";
        txtFireEmail.Text = "";
        txtFireTelephone.Text = "";
        txtFireVendorName.Text = "";
        txtFireZipCode.Text = "";
        drpFireState.SelectedIndex = 0;

        BindBuildingFinancialLimitGrid();
        BindGridBuildingAttachments();
        BindBuildingImprovementGrid();
        BindBuildingGGKLGrid();

        if (tblInsurance.Visible == true)
        {
            for (int i = 0; i < 25; i++)
            {
                TextBox txt = tblInsurance.FindControl("Item_" + (i + 1)) as TextBox;
                if (txt != null)
                    txt.Text = string.Empty;
            }
        }
    }

    /// <summary>
    /// Clears Ownership Detail panel controls
    /// </summary>
    private void ClearOwnershipControls()
    {
        //trOwned.Style["display"] = "none";
        //trLeased.Style["display"] = "none";

        //txtOwner_Name.Text = "";
        //txtOwner_Address_1.Text = "";
        //txtOwner_Address_2.Text = "";
        //txtOwner_City.Text = "";
        //ddlOwner_State.SelectedValue = "";
        //txtOwner_Zip.Text = "";
        txtLandlord_Name.Text = "";
        txtLandlord_Address_1.Text = "";
        txtLandlord_Address_2.Text = "";
        txtLandlord_City.Text = "";
        ddlLandlord_State.SelectedValue = "";
        txtLandlord_Zip.Text = "";
        txtLease_ID.Text = "";
        txtSubLease_Name.Text = "";
        txtSubLandlord.Text = "";
        txtSublease_Address_1.Text = "";
        txtSublease_Address_2.Text = "";
        txtSublease_City.Text = "";
        ddlSublease_State.SelectedIndex = 0;
        txtSublease_Zip.Text = "";
        trSubLease.Style["display"] = "none";
        //rfvSubLease_Name.Enabled = false;
        //rfvSubLandlord.Enabled = false;
        //rfvSublease_Address_1.Enabled = false;
        //rfvSublease_City.Enabled = false;
        //rfvSublease_State.Enabled = false;
        //rfvSublease_Zip.Enabled = false;

        txtSubleaseFirstName.Text = "";
        txtSubleaseLastName.Text = "";
        txtSubleaseTitle.Text = "";
        txtSubleasePhone.Text = "";
        txtSubleaseFax.Text = "";
        txtSubleaseEmail.Text = "";

        //rfvSubleaseFirstName.Enabled = false;

        //rfvSubleaseTitle.Enabled = false;
        //rfvSubleasePhone.Enabled = false;
        //rfvSubleaseFax.Enabled = false;
        //rfvSubleaseEmail.Enabled = false;
        //rfvSubleaseLastName.Enabled = false;
        revSubleasePhone.Enabled = false;
        revSubleaseFax.Enabled = false;
        revSubleaseEmail.Enabled = false;

        //txtSub_Leased_Sublease.Text = "";
        //txtSub_Leased_SubLandlord.Text = "";
        //tblSubLease.Style["display"] = "none";
        txtCommencement_Date.Text = "";
        txtExpiration_Date.Text = "";
        txtCOI_Wording.Text = "";
        chkREQWC.Checked = false;
        chkREQEL.Checked = false;
        chkREQGL.Checked = false;
        chkREQPollution.Checked = false;
        chkREQProperty.Checked = false;
        chkREQFlood.Checked = false;
        chkREQEQ.Checked = false;
        chkREQWaiver.Checked = false;
        chkWCTenant.Checked = false;
        chkELTenant.Checked = false;
        chkGLTenant.Checked = false;
        chkPollutionTenant.Checked = false;
        chkPropertyTenant.Checked = false;
        chkFloodTenant.Checked = false;
        chkEQTenant.Checked = false;
        chkWaiverTenant.Checked = false;

        lnkCOI_WC.Text = "Add";
        lnkCOI_EL.Text = "Add";
        lnkCOI_GL.Text = "Add";
        lnkCOI_Pollution.Text = "Add";
        lnkCOI_Property.Text = "Add";
        lnkCOI_Flood.Text = "Add";
        lnkCOI_EQ.Text = "Add";
        lnkCOI_Waiver.Text = "Add";

        hdnCOI_WC_URL.Value = ""; hdnCOI_WC.Value = "";
        hdnCOI_EL_URL.Value = ""; hdnCOI_EL.Value = "";
        hdnCOI_GL_URL.Value = ""; hdnCOI_GL.Value = "";
        hdnCOI_Pollution_URL.Value = ""; hdnCOI_Pollution.Value = "";
        hdnCOI_Property_URL.Value = ""; hdnCOI_Property.Value = "";
        hdnCOI_Flood_URL.Value = ""; hdnCOI_Flood.Value = "";
        hdnCOI_EQ_URL.Value = ""; hdnCOI_EQ.Value = "";
        hdnCOI_Waiver_URL.Value = ""; hdnCOI_Waiver.Value = "";

        lblCOI_WC_Date.Text = "";
        lblCOI_EL_Date.Text = "";
        lblCOI_GL_Date.Text = "";
        lblCOI_Pollution_Date.Text = "";
        lblCOI_Property_Date.Text = "";
        lblCOI_Flood_Date.Text = "";
        lblCOI_EQ_Date.Text = "";
        lblCOI_Waiver_Date.Text = "";

        hdnCOI_WC_Date.Value = "";
        hdnCOI_EL_Date.Value = "";
        hdnCOI_GL_Date.Value = "";
        hdnCOI_Pollution_Date.Value = "";
        hdnCOI_Property_Date.Value = "";
        hdnCOI_Flood_Date.Value = "";
        hdnCOI_EQ_Date.Value = "";
        hdnCOI_Waiver_Date.Value = "";

        txtReqLim_WC.Text = "";
        txtReqLim_EL.Text = "";
        txtReqLim_GL.Text = "";
        txtReqLim_Pollution.Text = "";
        txtReqLim_Property.Text = "";
        txtReqLim_Flood.Text = "";
        txtReqLim_EQ.Text = "";
        txtReqLim_Waiver.Text = "";

        tblWCLimit.Style["display"] = "none";
        tblELLimit.Style["display"] = "none";
        tblGLLimit.Style["display"] = "none";
        tblPollutionLimit.Style["display"] = "none";
        tblPropertyLimit.Style["display"] = "none";
        tblFloodLimit.Style["display"] = "none";
        tblEQLimit.Style["display"] = "none";
        tblWaiverLimit.Style["display"] = "none";

        ClearAdditionalInsuredControls();
        ClearPayeeDetailsControls();
        BindGridAdditionalInsureds();
        BindGridPayees();
        BindGridLeaseAttachments();
    }

    /// <summary>
    /// Clears Additional Insured section controls in Ownership detail panel
    /// </summary>
    private void ClearAdditionalInsuredControls()
    {
        PK_Building_Additional_Insureds = -1;
        txtAdditional_Insureds_Named.Text = "";
        txtAdditional_Insureds_Address_1.Text = "";
        txtAdditional_Insureds_Address_2.Text = "";
        txtAdditional_Insureds_City.Text = "";
        ddlAdditional_Insureds_State.SelectedValue = "";
        txtAdditional_Insureds_Zip.Text = "";
        trAdditionalInsured.Style["display"] = "none";
    }

    /// <summary>
    /// Clears Named Loss Payee section controls in Ownership detail panel
    /// </summary>
    private void ClearPayeeDetailsControls()
    {
        PK_Building_Payee = -1;
        txtLoss_Payees_Named.Text = "";
        txtLoss_Payees_Address_1.Text = "";
        txtLoss_Payees_Address_2.Text = "";
        txtLoss_Payees_City.Text = "";
        ddlLoss_Payees_State.SelectedValue = "";
        txtLoss_Payees_Zip.Text = "";
        ddlLoss_Payees_Type.SelectedValue = "";
        trNamedLossPayees.Style["display"] = "none";
    }

    /// <summary>
    /// Clears Assessment panel controls
    /// </summary>
    private void ClearAssessmentControls()
    {
        txtAssessment_History_Date.Text = "";
        txtAssessment_History_Assessor.Text = "";
        txtAssessment_History_Contact_Name.Text = "";
        txtAssessment_History_Address_1.Text = "";
        txtAssessment_History_Address_2.Text = "";
        txtAssessment_History_City.Text = "";
        ddlAssessment_History_State.SelectedValue = "";
        txtAssessment_History_Zip.Text = "";
        txtAssessment_History_Telephone.Text = "";

        trAssessmentHistory.Style["display"] = "none";
        trConcernNote.Style["display"] = "none";
        trAssessmentAttachment.Style["display"] = "none";
        BindGridAssessmentConcern();
        BindGridAssessmentAttachment();
    }

    /// <summary>
    /// Clears Concern noted section control in Assessment panel
    /// </summary>
    private void ClearAssessmentConcernControls()
    {
        txtItem_Description.Text = "";
        txtBudgeted_Cost.Text = "";
        txtActual_Cost.Text = "";
        txtDate_Complete.Text = "";
        txtConcerns_Comments.Text = "";

        trConcernNote.Style["display"] = "none";
    }

    // Clears contacts panel controls
    private void ClearContactDetailsControls()
    {
        PK_Property_Contact_ID = 0;
        txtName.Text = "";
        txtPhone.Text = "";
        txtCell_Phone.Text = "";
        txtAfter_Hours_Contact_Name.Text = "";
        txtAfter_Hours_Contact_Phone.Text = "";
        txtAfter_Hours_Contact_Cell_Phone.Text = "";

        BindEmergencyContactGrid();
        BindUtilityContactGrid();
        BindOtherContactGrid();
    }

    /// <summary>
    /// Clear Saba training controls
    /// </summary>
    private void CLearsabaTrainingControls()
    {
        drpSabaTrainingYear.SelectedValue = DateTime.Now.Year.ToString();
        drpQuarter.SelectedIndex = 0;
        hdnPKPropertySabaTraning.Value = "";
        txtNumber_of_Employees.Text = "";
        txtNumber_of_Employees_To_Date.Text = "";
        txtPercent_Employee_to_Date.Text = "";
        txtSaba_Training_Date.Text = "";
        trSabaTrainingYear.Style["display"] = "";
        trSabaTrainingQuarter.Style["display"] = "";
    }
    #endregion

    #region "GRIDS BINDING"

    /// <summary>
    /// Binds grid business interruption grid in Property cope panel
    /// </summary>
    private void BindGridBusinessInterruption()
    {
        DataTable dtBusinessInterruption = Property_COI.SelectByLocation(FK_LU_Location_ID).Tables[0];
        gvBusinessInterruption.DataSource = dtBusinessInterruption;
        gvBusinessInterruption.DataBind();
    }

    /// <summary>
    /// Binds Building grid in building information panel
    /// </summary>
    private void BindGridBuilding()
    {
        DataTable dtBuilding = Building.SelectByFKLocation(FK_LU_Location_ID).Tables[0];
        gvBuildingEdit.DataSource = dtBuilding;
        gvBuildingEdit.DataBind();
    }

    /// <summary>
    /// Binds building attachment grids in building information panel
    /// </summary>
    private void BindGridBuildingAttachments()
    {
        DataTable dtBuildingAttach = Building_Attachments.SelectByFK(PK_Building_ID).Tables[0];
        gvBuildingAttachmentDetails.DataSource = dtBuildingAttach;
        gvBuildingAttachmentDetails.DataBind();
    }

    /// <summary>
    /// Binds grid sub-lease attachments in Ownership detail panel
    /// </summary>
    private void BindGridLeaseAttachments()
    {
        DataTable dtAttachments = Lease_SubLease_Attachments.SelectByFK(PK_Building_ID).Tables[0];
        gvLeaseAttachmentDetails.DataSource = dtAttachments;
        gvLeaseAttachmentDetails.DataBind();
    }

    /// <summary>
    /// Binds Additional Insured grid in Ownership detail panel
    /// </summary>
    private void BindGridAdditionalInsureds()
    {
        DataTable dtIsureds = Building_Additional_Insureds_Payees.SelectInsureds(PK_Building_ID).Tables[0];
        gvAdditionalInsureds.DataSource = dtIsureds;
        gvAdditionalInsureds.DataBind();
    }

    /// <summary>
    /// Binds Named Loss payee grid in ownership detail panel
    /// </summary>
    private void BindGridPayees()
    {
        DataTable dtPayee = Building_Additional_Insureds_Payees.SelectPayees(PK_Building_ID).Tables[0];
        gvPayee.DataSource = dtPayee;
        gvPayee.DataBind();
    }

    /// <summary>
    /// Binds Assessment grid in Assessment panel
    /// </summary>
    private void BindGridAssessment()
    {
        DataTable dtAssessment = Property_Assessment.SelectByFK(FK_LU_Location_ID).Tables[0];
        gvAssessment.DataSource = dtAssessment;
        gvAssessment.DataBind();
    }

    /// <summary>
    /// Binds Concern noted grid in Assessment panel
    /// </summary>
    private void BindGridAssessmentConcern()
    {
        DataTable dtConcern = Property_Assessment_Concern.SelectByFK(PK_Property_Assessment_ID).Tables[0];
        gvConcernNotes.DataSource = dtConcern;
        gvConcernNotes.DataBind();
    }

    /// <summary>
    /// Binds Assessment attachments grid in assessment panel
    /// </summary>
    private void BindGridAssessmentAttachment()
    {
        DataTable dtAttachments = Assessment_Attachments.SelectByFK(PK_Property_Assessment_ID).Tables[0];
        gvAssessmentAttachment.DataSource = dtAttachments;
        gvAssessmentAttachment.DataBind();
    }

    /// <summary>
    /// Binds Emergency contact grid
    /// </summary>
    private void BindEmergencyContactGrid()
    {
        DataTable dtContact = Property_Contact.SelectEmergencyContact(PK_Building_ID).Tables[0];
        gvEmergencyContact.DataSource = dtContact;
        gvEmergencyContact.DataBind();
    }

    /// <summary>
    /// Binds Utility Contacts grid
    /// </summary>
    private void BindUtilityContactGrid()
    {
        DataTable dtContact = Property_Contact.SelectUtilityContact(PK_Building_ID).Tables[0];
        gvUtilityContacts.DataSource = dtContact;
        gvUtilityContacts.DataBind();
    }

    /// <summary>
    /// Binds Other contacts grid
    /// </summary>
    private void BindOtherContactGrid()
    {
        DataTable dtContact = Property_Contact.SelectOtherContact(PK_Building_ID).Tables[0];
        gvOtherContacts.DataSource = dtContact;
        gvOtherContacts.DataBind();
    }

    private void BindBuildingImprovementGrid()
    {
        DataTable dtImprovements = Building_Improvements.SelectByFK(PK_Building_ID).Tables[0];
        gvBuildingImprovements.DataSource = dtImprovements;
        gvBuildingImprovements.DataBind();
    }

    private void BindBuildingFinancialLimitGrid()
    {
        DataTable dtFinancialLimits = Building_Financial_Limits.SelectByFK(PK_Building_ID).Tables[0];
        gvFinancialLimit.DataSource = dtFinancialLimits;
        gvFinancialLimit.DataBind();
    }

    private void BindBuildingGGKLGrid()
    {
        DataTable dtGGKL = Building_GGKL.SelectByFK(PK_Building_ID).Tables[0];
        gvGGKL.DataSource = dtGGKL;
        gvGGKL.DataBind();
    }

    private void BindSubLeaseGrid()
    {
        DataTable dtSubLeaseGrid = clsBuilding_Ownership_Sublease.SelectByFK(PK_Building_Ownership).Tables[0];
        gvSubLease.DataSource = dtSubLeaseGrid;
        gvSubLease.DataBind();
    }

    #endregion

    #region "Attahcment uploading methods"

    /// <summary>
    /// Uploads Building attachments
    /// </summary>
    protected void Upload_Building_Attachment()
    {

        // add attachment
        BuildingAttachment.Add(clsGeneral.Exposure_Tables.Property_Building);
        trBuildingAttachment.Style["display"] = "none";

        // bind Building attachment grid to list newly added attachment
        BindGridBuildingAttachments();
        ScriptManager.RegisterStartupScript(Page, GetType(), DateTime.Now.ToString(), "ShowPanel(2);", true);
    }

    /// <summary>
    /// Uploads sub-lease attachments
    /// </summary>
    protected void Upload_Lease_Attachment()
    {
        // add attachment
        LeaseAttachment.Add(clsGeneral.Exposure_Tables.Property_Ownership_SubLease);
        trLeaseAttachment.Style["display"] = "none";

        // bind lease attahcment grid to list newly added attachment
        BindGridLeaseAttachments();

        tblWCLimit.Style["display"] = chkREQWC.Checked ? "" : "none";
        tblELLimit.Style["display"] = chkREQEL.Checked ? "" : "none";
        tblGLLimit.Style["display"] = chkREQGL.Checked ? "" : "none";
        tblPropertyLimit.Style["display"] = chkREQProperty.Checked ? "" : "none";
        tblFloodLimit.Style["display"] = chkREQFlood.Checked ? "" : "none";
        tblEQLimit.Style["display"] = chkREQEQ.Checked ? "" : "none";
        tblWaiverLimit.Style["display"] = chkREQWaiver.Checked ? "" : "none";


        if (hdnCOI_WC.Value != "") lnkCOI_WC.Text = FormatCOIFileName(hdnCOI_WC.Value);
        if (hdnCOI_EL.Value != "") lnkCOI_EL.Text = FormatCOIFileName(hdnCOI_EL.Value);
        if (hdnCOI_GL.Value != "") lnkCOI_GL.Text = FormatCOIFileName(hdnCOI_GL.Value);
        if (hdnCOI_Property.Value != "") lnkCOI_Property.Text = FormatCOIFileName(hdnCOI_Property.Value);
        if (hdnCOI_Flood.Value != "") lnkCOI_Flood.Text = FormatCOIFileName(hdnCOI_Flood.Value);
        if (hdnCOI_EQ.Value != "") lnkCOI_EQ.Text = FormatCOIFileName(hdnCOI_EQ.Value);
        if (hdnCOI_Waiver.Value != "") lnkCOI_Waiver.Text = FormatCOIFileName(hdnCOI_Waiver.Value);

        if (!chkWCTenant.Checked) lnkCOI_WC.Text = "Add";
        if (!chkELTenant.Checked) lnkCOI_EL.Text = "Add";
        if (!chkGLTenant.Checked) lnkCOI_GL.Text = "Add";
        if (!chkPropertyTenant.Checked) lnkCOI_Property.Text = "Add";
        if (!chkFloodTenant.Checked) lnkCOI_Flood.Text = "Add";
        if (!chkEQTenant.Checked) lnkCOI_EQ.Text = "Add";
        if (!chkWaiverTenant.Checked) lnkCOI_Waiver.Text = "Add";

        lblCOI_WC_Date.Text = hdnCOI_WC_Date.Value;
        lblCOI_EL_Date.Text = hdnCOI_EL_Date.Value;
        lblCOI_GL_Date.Text = hdnCOI_GL_Date.Value;
        lblCOI_Property_Date.Text = hdnCOI_Property_Date.Value;
        lblCOI_Flood_Date.Text = hdnCOI_Flood_Date.Value;
        lblCOI_EQ_Date.Text = hdnCOI_EQ_Date.Value;
        lblCOI_Waiver_Date.Text = hdnCOI_Waiver_Date.Value;

        ScriptManager.RegisterStartupScript(Page, GetType(), DateTime.Now.ToString(), "ShowPanel(3);", true);
    }

    /// <summary>
    /// Uploads property COI documents
    /// </summary>
    /// <param name="strFileName">Filename with path</param>
    /// <returns>Uploaded filename</returns>
    private string Upload_PropertyCOI_Docs(string strFileName)
    {
        try
        {
            // create directory for COI docs
            string strDestDir = AppConfig.PropertyCOIDocPath;
            clsGeneral.CreateDirectory(strDestDir);

            // get file name
            string strDestFileName = strFileName.Substring(strFileName.LastIndexOf("\\") + 1);

            // append time
            strDestFileName = System.DateTime.Now.ToString("MMddyyhhmmss") + strDestFileName;

            // copy the file to the property COI folder along with the modified file name
            File.Copy(strFileName, AppConfig.PropertyCOIDocPath + strDestFileName, false);

            // return the modified (uploaded) filename
            return strDestFileName;
        }
        catch
        {
            return "";
        }
    }

    /// <summary>
    /// Removes the time from COI FileName prefix
    /// </summary>
    /// <param name="strFileName">Name of the File stored in DB</param>
    /// <returns>Modified Filename</returns>
    private string FormatCOIFileName(string strFileName)
    {
        if (strFileName != "")
        {
            return strFileName.Substring(12, (strFileName.Length - 1) - 11);
        }
        else
            return strFileName;
    }

    /// <summary>
    /// Removes the COI document from Property COI documents folder
    /// </summary>
    /// <param name="strFileName">FileName to be removed</param>
    private void RemoveCOIDoc(string strFileName)
    {
        if (strFileName != "")
        {
            // get the filepath from passed filename
            string strDestFileName = AppConfig.PropertyCOIDocPath + strFileName.Substring(strFileName.LastIndexOf("/") + 1);

            // if file exists then delete
            if (File.Exists(strDestFileName))
                File.Delete(strDestFileName);
        }
    }

    /// <summary>
    /// Uploads Assessment attachment 
    /// </summary>
    protected void Upload_Assessment_Attachment()
    {
        // set FK for the attachment 
        AssessmentAttachment.FK_Building_ID = PK_Property_Assessment_ID;

        // add attachment
        AssessmentAttachment.Add(clsGeneral.Exposure_Tables.Property_Assessment);

        // bind grid attachment to list newly added attachment
        BindGridAssessmentAttachment();
        ScriptManager.RegisterStartupScript(Page, GetType(), DateTime.Now.ToString(), "ShowPanel(4);", true);
    }
    #endregion

    #region "Insurance Cope"

    private void SetDynamicInsuranceControl()
    {
        ERIMS.DAL.Building_Insurance_COPE_Descriptors objInsuranceCope = new Building_Insurance_COPE_Descriptors();
        DataSet objDs = ERIMS.DAL.Building_Insurance_COPE_Descriptors.GetActiveBuildingInsuranceCOPEDescriptors();

        tblInsurance.Controls.Clear();

        if (objDs != null && objDs.Tables.Count > 0 && objDs.Tables[0].Rows.Count > 0)
        {            
            HtmlTableRow tr=new HtmlTableRow();
            HtmlTableCell tc;
            bool blnAddBlanktd = false;

            if (objDs.Tables[0].Rows.Count == 1)
                blnAddBlanktd = true;

            int intCnt=1;
            for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
            {
                                
                if (intCnt==1)
                    tr = new HtmlTableRow();

                if (i % 2 == 1)
                {
                    tc = new HtmlTableCell();
                    tc.NoWrap = false;
                    tc.Width = "18%";
                    tc.Align = "left";
                    tc.VAlign = "top";
                     tc.Style.Add("padding-left", "9px");
                    Label lbl = new Label();
                    lbl.ID = "Lbl_Item_" + Convert.ToString(objDs.Tables[0].Rows[i]["Item_Number"]);
                    //lbl.Width = Unit.Pixel(132);
                    lbl.Text = Convert.ToString(objDs.Tables[0].Rows[i]["Item_Descriptor"]);
                    tc.Controls.Add(lbl);
                }
                else
                {
                    tc = new HtmlTableCell();
                    tc.NoWrap = false;
                    tc.Width = "19%";
                    tc.Align = "left";
                    tc.VAlign = "top";
                    Label lbl = new Label();
                    lbl.ID = "Lbl_Item_" + Convert.ToString(objDs.Tables[0].Rows[i]["Item_Number"]);
                    //lbl.Width = Unit.Pixel(146);
                    lbl.Text = Convert.ToString(objDs.Tables[0].Rows[i]["Item_Descriptor"]);
                    tc.Controls.Add(lbl);
                }
                
                //tc.InnerHtml = objDs.Tables[0].Rows[i]["Item_Descriptor"].ToString();

                if (Convert.ToString(objDs.Tables[0].Rows[i]["Mandatory"]) == "Y" )
                {
                    //tc.InnerHtml = " <span id='span'" + Convert.ToString(objDs.Tables[0].Rows[i]["Item_Number"]) + "' style='color: Red;'>*</span>";
                    Label lbl = new Label();
                    lbl.Text += " <span id='span'" + Convert.ToString(objDs.Tables[0].Rows[i]["Item_Number"]) + "' style='color: Red;'>*</span>";

                    tc.Controls.Add(lbl);
                }
                
                tr.Controls.Add(tc);

                tc = new HtmlTableCell();
                tc.Width = "4%";
                tc.Style.Add("padding-left", "2px");
                tc.Align = "center";
                Label lbl_colon = new Label();
                lbl_colon.ID = "Lbl_colon_" + Convert.ToString(objDs.Tables[0].Rows[i]["Item_Number"]);
                lbl_colon.Width = Unit.Pixel(31);
                lbl_colon.Text = ":";
                tc.Controls.Add(lbl_colon);
                tc.VAlign = "top";
                tr.Controls.Add(tc);

                tc = new HtmlTableCell();
                
                if (i % 2 == 1)
                {
                    tc.Width = "28%";
                    tc.Style.Add("padding-left", "6px");
                }
                else
                {
                    tc.Width = "27%";
                    tc.Style.Add("padding-left", "3px");
                }
                tc.Align = "left";
                tc.VAlign = "top";
               
                TextBox txt = new TextBox();
                txt.ID = "Item_" + Convert.ToString(objDs.Tables[0].Rows[i]["Item_Number"]);
                txt.MaxLength = 100;
                txt.Width = Unit.Pixel(170);
                tc.Controls.Add(txt);
                
                if (objDs.Tables[0].Rows[i]["Mandatory"].ToString() == "Y")
                {
                    RequiredFieldValidator rfv = new RequiredFieldValidator();
                    rfv.ControlToValidate = "Item_" + Convert.ToString(objDs.Tables[0].Rows[i]["Item_Number"]);
                    rfv.Display = ValidatorDisplay.None;
                    rfv.ValidationGroup = "vsErrorBuilding";
                    rfv.ErrorMessage = "Please Enter [Building Information]/" + objDs.Tables[0].Rows[i]["Item_Descriptor"].ToString();
                    rfv.SetFocusOnError = true;
                    rfv.ID = "rfv_" + Convert.ToString(objDs.Tables[0].Rows[i]["Item_Number"]);
                    tc.Controls.Add(rfv);
                }
                tr.Controls.Add(tc);

                if (intCnt > 1)
                {
                    tblInsurance.Controls.Add(tr);
                    intCnt = 1;
                    HtmlTableRow blanktr = new HtmlTableRow();
                    HtmlTableCell blankcell = new HtmlTableCell();
                    blankcell.ColSpan = 6;
                    blankcell.InnerHtml = "&nbsp;";
                    blanktr.Cells.Add(blankcell);
                    tblInsurance.Controls.Add(blanktr);
                }
                else
                {
                    if (i == objDs.Tables[0].Rows.Count - 1)
                    {
                        if (blnAddBlanktd)
                        {
                            HtmlTableCell blankcell = new HtmlTableCell();
                            blankcell.InnerHtml = "&nbsp;";
                            blankcell.NoWrap = false;
                            blankcell.Width = "18%";
                            blankcell.Align = "left";
                            blankcell.VAlign = "top";
                            tr.Cells.Add(blankcell);

                            blankcell = new HtmlTableCell();
                            blankcell.InnerHtml = "&nbsp;";
                            blankcell.NoWrap = false;
                            blankcell.Width = "4%";
                            blankcell.Align = "center";
                            blankcell.VAlign = "top";
                            tr.Cells.Add(blankcell);

                            blankcell = new HtmlTableCell();
                            blankcell.Width = "28%";
                            blankcell.Align = "left";
                            blankcell.VAlign = "top";
                            tr.Cells.Add(blankcell);
                            tblInsurance.Controls.Add(tr);
                        }
                        else
                            tblInsurance.Controls.Add(tr);
                    }
                    intCnt += 1;
                }
            }
            //pnlInsuranceCope.Visible = true;
            tblInsurance.Visible = true;
        }
        else
        {
            tblInsurance.Visible = false;
            //pnlInsuranceCope.Visible = false;
        }
        string strHtml = string.Empty;
    }

    private void InsertUpdateInsuranceCope(int FK_Building)
    {
        string strXml = string.Empty;
        strXml = "<Insurances>";
        for (int i = 0; i < 25; i++)
        {

            TextBox txtField = tblInsurance.FindControl("Item_" + (i + 1)) as TextBox;

            if (txtField != null)
            {
                strXml += "<Record>";
                strXml += "<ItemNo>Item_" + (i+1) + "</ItemNo>";
                strXml += "<ItemDesc>" + txtField.Text + "</ItemDesc>";             
                strXml += "</Record>";
            }
        }
        strXml += "</Insurances>";
        Building.BuildingInsuranceCOPEInsertUpdate(strXml, FK_Building, clsSession.UserID);
    }

    private void BindInuranceDetailForEdit(int Fk_Building)
    {
        DataSet objDs = Building.BuildingInsuranceCOPESelect(Fk_Building);
        if (objDs != null && objDs.Tables.Count > 0 && objDs.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < 25; i++)
            {
                TextBox txtField = tblInsurance.FindControl("Item_" + (i + 1)) as TextBox;
                 if (txtField != null)
                 {
                     txtField.Text = Convert.ToString(objDs.Tables[0].Rows[0]["Item_" + (i + 1)]);
                 }
            }
        }
    }

    #endregion

    #endregion

    #region Dynamic Validations
    /// <summary>
    /// Set all Validations
    /// </summary>
    private void SetValidationsPropertyCope()
    {
        string strCtrlsIDs = "";
        string strMessages = "";

        #region ""
        DataTable dtFields = clsScreen_Validators.SelectByScreen(54).Tables[0];
        dtFields.DefaultView.RowFilter = "IsRequired = '1'";
        dtFields = dtFields.DefaultView.ToTable();

        MenuAsterisk1.Style["display"] = (dtFields.Select("LeftMenuIndex = 1").Length > 0) ? "inline-block" : "none";

        foreach (DataRow drField in dtFields.Rows)
        {
            #region " set validation control IDs and messages "
            switch (Convert.ToString(drField["Field_Name"]))
            {
                //Property Cope
                case "Status": strCtrlsIDs += ddlStatus.ClientID + ","; strMessages += "Please select [Property Cope]/Status" + ","; Span1.Style["display"] = "inline-block"; break;
                case "Status as of Date": strCtrlsIDs += txtStatus_As_Of_Date.ClientID + ","; strMessages += "Please enter [Property Cope]/Status as of Date" + ","; Span2.Style["display"] = "inline-block"; break;
                case "Disposal Type": strCtrlsIDs += txtDisposal_Type.ClientID + ","; strMessages += "Please enter [Property Cope]/Disposal Type" + ","; Span3.Style["display"] = "inline-block"; break;
                case "Property Boundary Dimension": strCtrlsIDs += txtProperty_Boundry_Dimension.ClientID + ","; strMessages += "Please enter [Property Cope]/Property Boundary Dimension" + ","; Span4.Style["display"] = "inline-block"; break;
                case "Address 1": strCtrlsIDs += txtAddress_1.ClientID + ","; strMessages += "Please enter [Property Cope]/Address 1" + ","; Span5.Style["display"] = "inline-block"; break;
                case "Address 2": strCtrlsIDs += txtAddress_2.ClientID + ","; strMessages += "Please enter [Property Cope]/Address 2" + ","; Span7.Style["display"] = "inline-block"; break;
                case "City": strCtrlsIDs += txtCity.ClientID + ","; strMessages += "Please enter [Property Cope]/City" + ","; Span9.Style["display"] = "inline-block"; break;
                case "State": strCtrlsIDs += ddlState.ClientID + ","; strMessages += "Please select [Property Cope]/State" + ","; Span10.Style["display"] = "inline-block"; break;
                case "Zip": strCtrlsIDs += txtZip.ClientID + ","; strMessages += "Please enter [Property Cope]/Zip" + ","; Span11.Style["display"] = "inline-block"; break;
                case "Telephone": strCtrlsIDs += txtTelephone.ClientID + ","; strMessages += "Please enter [Property Cope]/Telephone" + ","; Span6.Style["display"] = "inline-block"; break;
                case "Web Site": strCtrlsIDs += txtWeb_Site.ClientID + ","; strMessages += "Please enter [Property Cope]/Web Site" + ","; Span8.Style["display"] = "inline-block"; break;
                case "Valuation Date": strCtrlsIDs += txtValuation_Date.ClientID + ","; strMessages += "Please enter [Property Cope]/Valuation Date" + ","; Span12.Style["display"] = "inline-block"; break;
            }

            #endregion
        }
        #endregion

        strCtrlsIDs = strCtrlsIDs.TrimEnd(',');
        strMessages = strMessages.TrimEnd(',');

        hdnControlIDs.Value = strCtrlsIDs;
        hdnErrorMsgs.Value = strMessages;
    }

    /// <summary>
    /// Set all Validations
    /// </summary>
    private void SetValidationsBuildingInfo()
    {
        string strCtrlsIDsBuild = "";
        string strMessagesBuild = "";

        #region ""
        DataTable dtFields = clsScreen_Validators.SelectByScreen(55).Tables[0];
        dtFields.DefaultView.RowFilter = "IsRequired = '1'";
        dtFields = dtFields.DefaultView.ToTable();

        MenuAsterisk2.Style["display"] = (dtFields.Select("LeftMenuIndex = 2").Length > 0) ? "inline-block" : "none";

        foreach (DataRow drField in dtFields.Rows)
        {
            #region " set validation control IDs and messages "
            switch (Convert.ToString(drField["Field_Name"]))
            {
                //Building Information
                case "Building Status": strCtrlsIDsBuild += drpLocationStatus.ClientID + ","; strMessagesBuild += "Please enter [Building Information]/Status" + ","; Span13.Style["display"] = "inline-block"; break;
                case "Building Address 1": strCtrlsIDsBuild += txtBuildingAddress_1.ClientID + ","; strMessagesBuild += "Please enter [Building Information]/Address 1" + ","; Span14.Style["display"] = "inline-block"; break;
                case "Building Address 2": strCtrlsIDsBuild += txtBuildingAddress_2.ClientID + ","; strMessagesBuild += "Please enter [Building Information]/Address 2" + ","; Span15.Style["display"] = "inline-block"; break;
                case "Building City": strCtrlsIDsBuild += txtBuilding_City.ClientID + ","; strMessagesBuild += "Please enter [Building Information]/City" + ","; Span16.Style["display"] = "inline-block"; break;
                case "Building State": strCtrlsIDsBuild += ddlBuidingState.ClientID + ","; strMessagesBuild += "Please enter [Building Information]/State" + ","; Span17.Style["display"] = "inline-block"; break;
                case "Building Zip": strCtrlsIDsBuild += txtBuilding_Zip.ClientID + ","; strMessagesBuild += "Please enter [Building Information]/Zip" + ","; Span18.Style["display"] = "inline-block"; break;
                case "Construction-Year Built": strCtrlsIDsBuild += txtYear_Built.ClientID + ","; strMessagesBuild += "Please enter [Building Information]/Construction  - Year Built" + ","; Span19.Style["display"] = "inline-block"; break;
                case "Construction-Square Footage": strCtrlsIDsBuild += txtSquare_Footage.ClientID + ","; strMessagesBuild += "Please enter [Building Information]/Construction  - Square Footage" + ","; Span20.Style["display"] = "inline-block"; break;
                case "Construction-Number of Stories": strCtrlsIDsBuild += txtNumber_of_Stories.ClientID + ","; strMessagesBuild += "Please enter [Building Information]/Construction  - Number of Stories" + ","; Span21.Style["display"] = "inline-block"; break;
                case "Number of Paint Booths": strCtrlsIDsBuild += txtNumber_of_Paint_Booths.ClientID + ","; strMessagesBuild += "Please enter [Building Information]/Number of Paint Booths" + ","; Span22.Style["display"] = "inline-block"; break;
                //case "Number of Lifts": strCtrlsIDsBuild += txtNumber_of_Lifts.ClientID + ","; strMessagesBuild += "Please enter [Building Information]/Number of Lifts" + ","; Span23.Style["display"] = "inline-block"; break;
                case "Automatic Sprinklers-Sales-New % Sprinklered": strCtrlsIDsBuild += txtSales_New_Sprinklered.ClientID + ","; strMessagesBuild += "Please enter [Building Information]/Automatic Sprinklers  - Sales - New % Sprinklered" + ","; Span24.Style["display"] = "inline-block"; break;
                case "Automatic Sprinklers-Sales-Used % Sprinklered": strCtrlsIDsBuild += txtSales_Used_Sprinklered.ClientID + ","; strMessagesBuild += "Please enter [Building Information]/Automatic Sprinklers  - Sales - Used % Sprinklered" + ","; Span25.Style["display"] = "inline-block"; break;
                case "Automatic Sprinklers-Service % Sprinklered": strCtrlsIDsBuild += txtService_Sprinklered.ClientID + ","; strMessagesBuild += "Please enter [Building Information]/Automatic Sprinklers  - Service % Sprinklered" + ","; Span26.Style["display"] = "inline-block"; break;
                case "Automatic Sprinklers-Body Shop % Sprinklered": strCtrlsIDsBuild += txtBody_Shop_Sprinklered.ClientID + ","; strMessagesBuild += "Please enter [Building Information]/Automatic Sprinklers  - Body Shop % Sprinklered" + ","; Span27.Style["display"] = "inline-block"; break;
                case "Automatic Sprinklers-Parts % Sprinklered": strCtrlsIDsBuild += txtParts_Sprinklered.ClientID + ","; strMessagesBuild += "Please enter [Building Information]/Automatic Sprinklers  - Parts % Sprinklered" + ","; Span28.Style["display"] = "inline-block"; break;
                case "Automatic Sprinklers-Office % Sprinklered": strCtrlsIDsBuild += txtOffice_Sprinklered.ClientID + ","; strMessagesBuild += "Please enter [Building Information]/Automatic Sprinklers  - Office % Sprinklered" + ","; Span29.Style["display"] = "inline-block"; break;
                case "Design Densities for each area?": strCtrlsIDsBuild += txtDesign_Densities_for_each_area.ClientID + ","; strMessagesBuild += "Please enter [Building Information]/Design Densities for each area?" + ","; Span30.Style["display"] = "inline-block"; break;
                case "Fire Inspection Company-Contact Name": strCtrlsIDsBuild += txtFireContactName.ClientID + ","; strMessagesBuild += "Please enter [Building Information]/Fire Inspection Company  - Contact Name" + ","; Span31.Style["display"] = "inline-block"; break;
                case "Fire Inspection Company-Vendor Name": strCtrlsIDsBuild += txtFireVendorName.ClientID + ","; strMessagesBuild += "Please enter [Building Information]/Fire Inspection Company  - Vendor Name" + ","; Span32.Style["display"] = "inline-block"; break;
                case "Fire Inspection Company-Contract Expiration Date": strCtrlsIDsBuild += txtFireContactExpirationDate.ClientID + ","; strMessagesBuild += "Please enter [Building Information]/Fire Inspection Company  - Contract Expiration Date" + ","; Span33.Style["display"] = "inline-block"; break;
                case "Fire Inspection Company-Telephone Number": strCtrlsIDsBuild += txtFireTelephone.ClientID + ","; strMessagesBuild += "Please enter [Building Information]/Fire Inspection Company  - Telephone Number" + ","; Span34.Style["display"] = "inline-block"; break;
                case "Fire Inspection Company-Address 1": strCtrlsIDsBuild += txtFireAddress1.ClientID + ","; strMessagesBuild += "Please enter [Building Information]/Fire Inspection Company  - Address 1" + ","; Span35.Style["display"] = "inline-block"; break;
                case "Fire Inspection Company-Address 2": strCtrlsIDsBuild += txtFireAddress2.ClientID + ","; strMessagesBuild += "Please enter [Building Information]/Fire Inspection Company - Address 2" + ","; Span36.Style["display"] = "inline-block"; break;
                case "Fire Inspection Company-Alternate Number": strCtrlsIDsBuild += txtFireAlternateNumber.ClientID + ","; strMessagesBuild += "Please enter [Building Information]/Fire Inspection Company - Alternate Number" + ","; Span37.Style["display"] = "inline-block"; break;
                case "Fire Inspection Company-City": strCtrlsIDsBuild += txtFireCity.ClientID + ","; strMessagesBuild += "Please enter [Building Information]/Fire Inspection Company - City" + ","; Span38.Style["display"] = "inline-block"; break;
                case "Fire Inspection Company-State": strCtrlsIDsBuild += drpFireState.ClientID + ","; strMessagesBuild += "Please enter [Building Information]/Fire Inspection Company - State" + ","; Span39.Style["display"] = "inline-block"; break;
                case "Fire Inspection Company-Email": strCtrlsIDsBuild += txtFireEmail.ClientID + ","; strMessagesBuild += "Please enter [Building Information]/Fire Inspection Company - Email" + ","; Span40.Style["display"] = "inline-block"; break;
                case "Fire Inspection Company-Zip": strCtrlsIDsBuild += txtFireZipCode.ClientID + ","; strMessagesBuild += "Please enter [Building Information]/Fire Inspection Company - Zip" + ","; Span41.Style["display"] = "inline-block"; break;
                case "Fire Inspection Company-Comments": strCtrlsIDsBuild += txtFireComments.ClientID + ","; strMessagesBuild += "Please enter [Building Information]/Fire Inspection Company - Comments" + ","; Span42.Style["display"] = "inline-block"; break;
                case "Public Fire Department-Type": strCtrlsIDsBuild += ddlFireDeptType.ClientID + ","; strMessagesBuild += "Please select [Building Information]/Public Fire Department - Type" + ","; Span84.Style["display"] = "inline-block"; break;
                case "Public Fire Department-Distance": strCtrlsIDsBuild += ddlDistance.ClientID + ","; strMessagesBuild += "Please select [Building Information]/Public Fire Department - Distance" + ","; Span85.Style["display"] = "inline-block"; break;
                case "Service Capacity-Number of Bays": strCtrlsIDsBuild += txtNumberOfBays.ClientID + ","; strMessagesBuild += "Please enter [Building Information]/Service Capacity - Number of Bays" + ","; Span86.Style["display"] = "inline-block"; break;
                case "Service Capacity-Number of Lifts": strCtrlsIDsBuild += txtNumberOfLifts.ClientID + ","; strMessagesBuild += "Please enter [Building Information]/Service Capacity - Number of Lifts" + ","; Span87.Style["display"] = "inline-block"; break;
                case "Service Capacity-Number of Prep Areas": strCtrlsIDsBuild += txtNumberOfPrepAreas.ClientID + ","; strMessagesBuild += "Please enter [Building Information]/Service Capacity - Number of Prep Areas" + ","; Span88.Style["display"] = "inline-block"; break;
                case "Service Capacity-Number of Car Wash Stations": strCtrlsIDsBuild += txtNumberOfCarWashStations.ClientID + ","; strMessagesBuild += "Please enter [Building Information]/Service Capacity - Number of Car Wash Stations" + ","; Span89.Style["display"] = "inline-block"; break;
                case "Exposure-Distance from body of water (creek, river, ocean)": strCtrlsIDsBuild += ddlDistance_from_body_of_water.ClientID + ","; strMessagesBuild += "Please select [Building Information]/Exposure - Distance from body of water" + ","; Span91.Style["display"] = "inline-block"; break;
                case "Exposure-Lowest finish floor elevation (above sea level)": strCtrlsIDsBuild += txtLowest_finish_floor_elevation.ClientID + ","; strMessagesBuild += "Please enter [Building Information]/Exposure - Lowest finish floor elevation" + ","; Span93.Style["display"] = "inline-block"; break;
                case "Exposure-Flood Zone": strCtrlsIDsBuild += txtFloodZone.ClientID + ","; strMessagesBuild += "Please enter [Building Information]/Exposure - Flood Zone" + ","; Span95.Style["display"] = "inline-block"; break;
                case "Other Building Comments": strCtrlsIDsBuild += txtComments.ClientID + ","; strMessagesBuild += "Please enter [Building Information]/Other Building Comments" + ","; Span104.Style["display"] = "inline-block"; break;
                case "Exposure-Occupancy": strCtrlsIDsBuild += txtNeighbor_Occupancy.ClientID + ","; strMessagesBuild += "Please enter [Building Information]/Exposure - Occupancy" + ","; Span90.Style["display"] = "inline-block"; break;
                case "Prior Flood History Describe": strCtrlsIDsBuild += txtFlood_History_Descr.ClientID + ","; strMessagesBuild += "Please enter [Building Information]/Prior Flood History Describe" + ","; Span92.Style["display"] = "inline-block"; break;
                case "Property Damage Losses Describe": strCtrlsIDsBuild += txtProperty_Loss_Descr.ClientID + ","; strMessagesBuild += "Please enter [Building Information]/Property Damage Losses Describe" + ","; Span94.Style["display"] = "inline-block"; break;
                case "Security Camera System": strCtrlsIDsBuild += txtsecuCam_System.ClientID + ","; strMessagesBuild += "Please enter [Building Information]/Security Camera System" + ","; Span43.Style["display"] = "inline-block"; break;
                case "Security Camera Contact Name ": strCtrlsIDsBuild += txtSecuCam_Contact_Name.ClientID + ","; strMessagesBuild += "Please enter [Building Information]/Security Camera Contact Name " + ","; Span44.Style["display"] = "inline-block"; break;
                case "Security Camera Vendor Name": strCtrlsIDsBuild += txtSecuCam_Vendor_Name.ClientID + ","; strMessagesBuild += "Please enter [Building Information]/Security Camera Vendor Name" + ","; Span45.Style["display"] = "inline-block"; break;
                case "Security Camera Contract Expiration Date": strCtrlsIDsBuild += txtSecuCam_Contact_Expiration_Date.ClientID + ","; strMessagesBuild += "Please enter [Building Information]/Security Camera Contract Expiration Date" + ","; Span46.Style["display"] = "inline-block"; break;
                case "Security Camera Address 1": strCtrlsIDsBuild += txtSecuCam_Address_1.ClientID + ","; strMessagesBuild += "Please enter [Building Information]/Security Camera Address 1" + ","; Span47.Style["display"] = "inline-block"; break;
                case "Security Camera Telephone Number ": strCtrlsIDsBuild += txtSecuCam_Telephone_Number.ClientID + ","; strMessagesBuild += "Please enter [Building Information]/Security Camera Telephone Number " + ","; Span48.Style["display"] = "inline-block"; break;
                case "Security Camera Address 2": strCtrlsIDsBuild += txtSecuCam_Address_2.ClientID + ","; strMessagesBuild += "Please enter [Building Information]/Security Camera Address 2" + ","; Span49.Style["display"] = "inline-block"; break;
                case "Security Camera Alternate Number": strCtrlsIDsBuild += txtSecuCam_Alternate_Number.ClientID + ","; strMessagesBuild += "Please enter [Building Information]/Security Camera Alternate Number" + ","; Span50.Style["display"] = "inline-block"; break;
                case "Security Camera City": strCtrlsIDsBuild += txtSecuCam_City.ClientID + ","; strMessagesBuild += "Please enter [Building Information]/Security Camera City" + ","; Span51.Style["display"] = "inline-block"; break;
                case "Security Camera Email": strCtrlsIDsBuild += txtSecuCam_Email.ClientID + ","; strMessagesBuild += "Please enter [Building Information]/Security Camera Email" + ","; Span52.Style["display"] = "inline-block"; break;
                case "Security Camera State": strCtrlsIDsBuild += ddlSecuCam_State.ClientID + ","; strMessagesBuild += "Please select [Building Information]/Security Camera State" + ","; Span53.Style["display"] = "inline-block"; break;
                case "Security Camera Comments": strCtrlsIDsBuild += txtSecuCam_Comments.ClientID + ","; strMessagesBuild += "Please enter [Building Information]/Security Camera Comments" + ","; Span54.Style["display"] = "inline-block"; break;
                case "Security Camera Zip": strCtrlsIDsBuild += txtSecuCam_Zip.ClientID + ","; strMessagesBuild += "Please enter [Building Information]/Security Camera Zip" + ","; Span55.Style["display"] = "inline-block"; break;
                case "Security Guard Services System": strCtrlsIDsBuild += txtGuard_System.ClientID + ","; strMessagesBuild += "Please enter [Building Information]/Security Guard Services System" + ","; Span56.Style["display"] = "inline-block"; break;
                case "Security Guard Services Contact Name ": strCtrlsIDsBuild += txtGuard_Contact_Name.ClientID + ","; strMessagesBuild += "Please enter [Building Information]/Security Guard Services Contact Name " + ","; Span57.Style["display"] = "inline-block"; break;
                case "Security Guard Services Vendor Name": strCtrlsIDsBuild += txtGuard_Vendor_Name.ClientID + ","; strMessagesBuild += "Please enter [Building Information]/Security Guard Services Vendor Name" + ","; Span58.Style["display"] = "inline-block"; break;
                case "Security Guard Services Contract Expiration Date": strCtrlsIDsBuild += txtGuard_Contact_Expiration_Date.ClientID + ","; strMessagesBuild += "Please enter [Building Information]/Security Guard Services Contract Expiration Date" + ","; Span106.Style["display"] = "inline-block"; break;
                case "Security Guard Services Address 1": strCtrlsIDsBuild += txtGuard_Address_1.ClientID + ","; strMessagesBuild += "Please enter [Building Information]/Security Guard Services Address 1" + ","; Span59.Style["display"] = "inline-block"; break;
                case "Security Guard Services Telephone Number ": strCtrlsIDsBuild += txtGuard_Telephone_Number.ClientID + ","; strMessagesBuild += "Please enter [Building Information]/Security Guard Services Telephone Number " + ","; Span60.Style["display"] = "inline-block"; break;
                case "Security Guard Services Address 2": strCtrlsIDsBuild += txtGuard_Address_2.ClientID + ","; strMessagesBuild += "Please enter [Building Information]/Security Guard Services Address 2" + ","; Span61.Style["display"] = "inline-block"; break;
                case "Security Guard Services Alternate Number": strCtrlsIDsBuild += txtGuard_Alternate_Number.ClientID + ","; strMessagesBuild += "Please enter [Building Information]/Security Guard Services Alternate Number" + ","; Span105.Style["display"] = "inline-block"; break;
                case "Security Guard Services City": strCtrlsIDsBuild += txtGuard_City.ClientID + ","; strMessagesBuild += "Please enter [Building Information]/Security Guard Services City" + ","; Span62.Style["display"] = "inline-block"; break;
                case "Security Guard Services Email": strCtrlsIDsBuild += txtGuard_Email.ClientID + ","; strMessagesBuild += "Please enter [Building Information]/Security Guard Services Email" + ","; Span63.Style["display"] = "inline-block"; break;
                case "Security Guard Services State": strCtrlsIDsBuild += ddlGuard_State.ClientID + ","; strMessagesBuild += "Please select [Building Information]/Security Guard Services State" + ","; Span64.Style["display"] = "inline-block"; break;
                case "Security Guard Services Comments": strCtrlsIDsBuild += txtGuard_Comments.ClientID + ","; strMessagesBuild += "Please enter [Building Information]/Security Guard Services Comments" + ","; Span65.Style["display"] = "inline-block"; break;
                case "Security Guard Services Zip": strCtrlsIDsBuild += txtGuard_Zip.ClientID + ","; strMessagesBuild += "Please enter [Building Information]/Security Guard Services Zip" + ","; Span66.Style["display"] = "inline-block"; break;
                case "Intrusion Alarms System": strCtrlsIDsBuild += txtIntru_System.ClientID + ","; strMessagesBuild += "Please enter [Building Information]/Intrusion Alarms System" + ","; Span67.Style["display"] = "inline-block"; break;
                case "Intrusion Alarms Contact Name ": strCtrlsIDsBuild += txtIntru_Contact_Name.ClientID + ","; strMessagesBuild += "Please enter [Building Information]/Intrusion Alarms Contact Name " + ","; Span68.Style["display"] = "inline-block"; break;
                case "Intrusion Alarms Vendor Name": strCtrlsIDsBuild += txtIntru_Vendor_Name.ClientID + ","; strMessagesBuild += "Please enter [Building Information]/Intrusion Alarms Vendor Name" + ","; Span69.Style["display"] = "inline-block"; break;
                case "Intrusion Alarms Alarm type": strCtrlsIDsBuild += ddlIntru_Contact_Alarm_Type.ClientID + ","; strMessagesBuild += "Please select [Building Information]/Intrusion Alarms Alarm type" + ","; Span70.Style["display"] = "inline-block"; break;
                case "Intrusion Alarms Contract Expiration Date": strCtrlsIDsBuild += txtIntru_Contact_Expiration_Date.ClientID + ","; strMessagesBuild += "Please enter [Building Information]/Intrusion Alarms Contract Expiration Date" + ","; Span72.Style["display"] = "inline-block"; break;
                case "Intrusion Alarms Address 1": strCtrlsIDsBuild += txtIntru_Address_1.ClientID + ","; strMessagesBuild += "Please enter [Building Information]/Intrusion Alarms Address 1" + ","; Span71.Style["display"] = "inline-block"; break;
                case "Intrusion Alarms Telephone Number ": strCtrlsIDsBuild += txtIntru_Telephone_Number.ClientID + ","; strMessagesBuild += "Please enter [Building Information]/Intrusion Alarms Telephone Number " + ","; Span74.Style["display"] = "inline-block"; break;
                case "Intrusion Alarms Address 2": strCtrlsIDsBuild += txtIntru_Address_2.ClientID + ","; strMessagesBuild += "Please enter [Building Information]/Intrusion Alarms Address 2" + ","; Span73.Style["display"] = "inline-block"; break;
                case "Intrusion Alarms Alternate Number": strCtrlsIDsBuild += txtIntru_Alternate_Number.ClientID + ","; strMessagesBuild += "Please enter [Building Information]/Intrusion Alarms Alternate Number" + ","; Span76.Style["display"] = "inline-block"; break;
                case "Intrusion Alarms City": strCtrlsIDsBuild += txtIntru_City.ClientID + ","; strMessagesBuild += "Please enter [Building Information]/Intrusion Alarms City" + ","; Span75.Style["display"] = "inline-block"; break;
                case "Intrusion Alarms Email": strCtrlsIDsBuild += txtIntru_Email.ClientID + ","; strMessagesBuild += "Please enter [Building Information]/Intrusion Alarms Email" + ","; Span78.Style["display"] = "inline-block"; break;
                case "Intrusion Alarms State": strCtrlsIDsBuild += ddlIntru_State.ClientID + ","; strMessagesBuild += "Please select [Building Information]/Intrusion Alarms State" + ","; Span77.Style["display"] = "inline-block"; break;
                case "Intrusion Alarms Comments": strCtrlsIDsBuild += txtIntru_Comments.ClientID + ","; strMessagesBuild += "Please enter [Building Information]/Intrusion Alarms Comments" + ","; Span80.Style["display"] = "inline-block"; break;
                case "Intrusion Alarms Zip": strCtrlsIDsBuild += txtIntru_Zip.ClientID + ","; strMessagesBuild += "Please enter [Building Information]/Intrusion Alarms Zip" + ","; Span79.Style["display"] = "inline-block"; break;
                case "Generator Make": strCtrlsIDsBuild += txtGenerator_Make.ClientID + ","; strMessagesBuild += "Please enter [Building Information]/Generator Make" + ","; Span81.Style["display"] = "inline-block"; break;
                case "Generator Model": strCtrlsIDsBuild += txtGenerator_Model.ClientID + ","; strMessagesBuild += "Please enter [Building Information]/Generator Model" + ","; Span82.Style["display"] = "inline-block"; break;
                case "Generator Size": strCtrlsIDsBuild += txtGenerator_Size.ClientID + ","; strMessagesBuild += "Please enter [Building Information]/Generator Size" + ","; Span83.Style["display"] = "inline-block"; break;
                case "National Flood Policy Carrier ": strCtrlsIDsBuild += txtFlood_Carrier.ClientID + ","; strMessagesBuild += "Please enter [Building Information]/National Flood Policy Carrier " + ","; Span96.Style["display"] = "inline-block"; break;
                case "National Flood Policy Policy Inception Date": strCtrlsIDsBuild += txtFlood_Policy_Inception_Date.ClientID + ","; strMessagesBuild += "Please enter [Building Information]/National Flood Policy Policy Inception Date" + ","; Span97.Style["display"] = "inline-block"; break;
                case "National Flood Policy Policy Number": strCtrlsIDsBuild += txtFlood_Policy_Number.ClientID + ","; strMessagesBuild += "Please enter [Building Information]/National Flood Policy Policy Number" + ","; Span98.Style["display"] = "inline-block"; break;
                case "National Flood Policy Policy Expiration Date": strCtrlsIDsBuild += txtFlood_Policy_Expiration_Date.ClientID + ","; strMessagesBuild += "Please enter [Building Information]/National Flood Policy Policy Expiration Date" + ","; Span99.Style["display"] = "inline-block"; break;
                case "National Flood Policy Premium": strCtrlsIDsBuild += txtFlood_Premium.ClientID + ","; strMessagesBuild += "Please enter [Building Information]/National Flood Policy Premium" + ","; Span100.Style["display"] = "inline-block"; break;
                case "National Flood Policy Deductible": strCtrlsIDsBuild += txtFlood_Deductible.ClientID + ","; strMessagesBuild += "Please enter [Building Information]/National Flood Policy Deductible" + ","; Span101.Style["display"] = "inline-block"; break;
                case "National Flood Policy Policy Limits-Contents": strCtrlsIDsBuild += txtFlood_Polciy_Limits_Contents.ClientID + ","; strMessagesBuild += "Please enter [Building Information]/National Flood Policy Policy Limits-Contents" + ","; Span102.Style["display"] = "inline-block"; break;
                case "National Flood Policy Policy Limits-Building": strCtrlsIDsBuild += txtFlood_Policy_Limits_Building.ClientID + ","; strMessagesBuild += "Please enter [Building Information]/National Flood Policy Policy Limits-Building" + ","; Span103.Style["display"] = "inline-block"; break;
                case "Number of Parking Spaces": strCtrlsIDsBuild += txtNumber_Of_Parking_Spaces.ClientID + ","; strMessagesBuild += "Please enter [Building Information]/Number of Parking Spaces" + ","; Span155.Style["display"] = "inline-block"; break;
                case "Acreage": strCtrlsIDsBuild += txtAcreage.ClientID + ","; strMessagesBuild += "Please enter [Building Information]/Acreage" + ","; Span156.Style["display"] = "inline-block"; break;

            }

            #endregion
        }
        #endregion

        strCtrlsIDsBuild = strCtrlsIDsBuild.TrimEnd(',');
        strMessagesBuild = strMessagesBuild.TrimEnd(',');

        hdnControlIDsBuild.Value = strCtrlsIDsBuild;
        hdnErrorMsgsBuild.Value = strMessagesBuild;
    }

    /// <summary>
    /// Set all Validations-Ownership Details
    /// </summary>
    private void SetValidationsOwnershipDetails()
    {
        string strCtrlsIDsOwner = "";
        string strMessagesOwner = "";

        #region ""
        DataTable dtFields = clsScreen_Validators.SelectByScreen(137).Tables[0];
        dtFields.DefaultView.RowFilter = "IsRequired = '1'";
        dtFields = dtFields.DefaultView.ToTable();

        MenuAsterisk2.Style["display"] = (dtFields.Select("LeftMenuIndex = 2").Length > 0) ? "inline-block" : "none";

        foreach (DataRow drField in dtFields.Rows)
        {
            #region " set validation control IDs and messages "
            switch (Convert.ToString(drField["Field_Name"]))
            {
                case "Landlord Name": strCtrlsIDsOwner += txtLandlord_Name.ClientID + ","; strMessagesOwner += "Please enter [Ownership Details]/Landlord Name" + ","; Span117.Style["display"] = "inline-block"; break;
                case "Landlord Legal Entity": strCtrlsIDsOwner += txtLandlordLegalEntity.ClientID + ","; strMessagesOwner += "Please enter [Ownership Details]/Landlord Legal Entity" + ","; Span111.Style["display"] = "inline-block"; break;
                case "Address 1": strCtrlsIDsOwner += txtLandlord_Address_1.ClientID + ","; strMessagesOwner += "Please enter [Ownership Details]/Address 1" + ","; Span116.Style["display"] = "inline-block"; break;
                case "Lease ID": strCtrlsIDsOwner += txtLease_ID.ClientID + ","; strMessagesOwner += "Please enter [Ownership Details]/Lease ID" + ","; Span110.Style["display"] = "inline-block"; break;
                case "Address 2": strCtrlsIDsOwner += txtLandlord_Address_2.ClientID + ","; strMessagesOwner += "Please enter [Ownership Details]/Address 2" + ","; Span115.Style["display"] = "inline-block"; break;
                case "Commencement Date": strCtrlsIDsOwner += txtCommencement_Date.ClientID + ","; strMessagesOwner += "Please enter [Ownership Details]/Commencement Date" + ","; Span109.Style["display"] = "inline-block"; break;
                case "City": strCtrlsIDsOwner += txtLandlord_City.ClientID + ","; strMessagesOwner += "Please enter [Ownership Details]/City" + ","; Span114.Style["display"] = "inline-block"; break;
                case "Expiration Date": strCtrlsIDsOwner += txtExpiration_Date.ClientID + ","; strMessagesOwner += "Please enter [Ownership Details]/Expiration Date" + ","; Span108.Style["display"] = "inline-block"; break;
                case "State": strCtrlsIDsOwner += ddlLandlord_State.ClientID + ","; strMessagesOwner += "Please enter [Ownership Details]/State" + ","; Span113.Style["display"] = "inline-block"; break;
                case "Zip": strCtrlsIDsOwner += txtLandlord_Zip.ClientID + ","; strMessagesOwner += "Please enter [Ownership Details]/Zip" + ","; Span112.Style["display"] = "inline-block"; break;
                case "Special Wording for the Certificate of Insurance ": strCtrlsIDsOwner += txtCOI_Wording.ClientID + ","; strMessagesOwner += "Please enter [Ownership Details]/Special Wording for the Certificate of Insurance " + ","; Span107.Style["display"] = "inline-block"; break;
            }

            #endregion
        }
        #endregion

        strCtrlsIDsOwner = strCtrlsIDsOwner.TrimEnd(',');
        strMessagesOwner = strMessagesOwner.TrimEnd(',');

        hdnControlIDsOwnership.Value = strCtrlsIDsOwner;
        hdnErrorMsgsOwnership.Value = strMessagesOwner;
    }

    /// <summary>
    /// Set all Validations-Additional Insured Details
    /// </summary>
    private void SetValidationsAdditionalInsureds()
    {
        string strCtrlsIDs = "";
        string strMessages = "";

        #region ""
        DataTable dtFields = clsScreen_Validators.SelectByScreen(137).Tables[0];
        dtFields.DefaultView.RowFilter = "IsRequired = '1'";
        dtFields = dtFields.DefaultView.ToTable();

        MenuAsterisk2.Style["display"] = (dtFields.Select("LeftMenuIndex = 2").Length > 0) ? "inline-block" : "none";

        foreach (DataRow drField in dtFields.Rows)
        {
            #region " set validation control IDs and messages "
            switch (Convert.ToString(drField["Field_Name"]))
            {
                case "Named Additional Insured - Named Insured":
                    strCtrlsIDs += txtAdditional_Insureds_Named.ClientID + ",";
                    strMessages += "Please enter Additional Insured Named Insured" + ",";
                    Span142.Style["display"] = "inline-block";
                    break;
                case "Named Additional Insured - Address 1":
                    strCtrlsIDs += txtAdditional_Insureds_Address_1.ClientID + ",";
                    strMessages += "Please enter Additional Insured Address 1" + ",";
                    Span143.Style["display"] = "inline-block";
                    break;
                case "Named Additional Insured - Address 2":
                    strCtrlsIDs += txtAdditional_Insureds_Address_2.ClientID + ",";
                    strMessages += "Please enter Additional Insured Address 2" + ",";
                    Span144.Style["display"] = "inline-block";
                    break;
                case "Named Additional Insured - City":
                    strCtrlsIDs += txtAdditional_Insureds_City.ClientID + ",";
                    strMessages += "Please enter Additional Insured City" + ",";
                    Span145.Style["display"] = "inline-block";
                    break;
                case "Named Additional Insured - State":
                    strCtrlsIDs += ddlAdditional_Insureds_State.ClientID + ",";
                    strMessages += "Please select Additional Insured State" + ",";
                    Span146.Style["display"] = "inline-block";
                    break;
                case "Named Additional Insured - Zip":
                    strCtrlsIDs += txtAdditional_Insureds_Zip.ClientID + ",";
                    strMessages += "Please enter Additional Insured Zip" + ",";
                    Span147.Style["display"] = "inline-block";
                    break;
            }

            #endregion
        }
        #endregion

        strCtrlsIDs = strCtrlsIDs.TrimEnd(',');
        strMessages = strMessages.TrimEnd(',');

        hdnControlIDsAI.Value = strCtrlsIDs;
        hdnErrorMsgsAI.Value = strMessages;
    }

    /// <summary>
    /// Set all Validations-Loss Payee Details
    /// </summary>
    private void SetValidationsLossPayee()
    {
        string strCtrlsIDs = "";
        string strMessages = "";

        #region ""
        DataTable dtFields = clsScreen_Validators.SelectByScreen(137).Tables[0];
        dtFields.DefaultView.RowFilter = "IsRequired = '1'";
        dtFields = dtFields.DefaultView.ToTable();

        MenuAsterisk2.Style["display"] = (dtFields.Select("LeftMenuIndex = 2").Length > 0) ? "inline-block" : "none";

        foreach (DataRow drField in dtFields.Rows)
        {
            #region " set validation control IDs and messages "
            switch (Convert.ToString(drField["Field_Name"]))
            {
                case "Named Loss Payees - Named Insured":
                    strCtrlsIDs += txtLoss_Payees_Named.ClientID + ",";
                    strMessages += "Please enter Loss Payee Named Insured" + ",";
                    Span148.Style["display"] = "inline-block";
                    break;
                case "Named Loss Payees - Address 1":
                    strCtrlsIDs += txtLoss_Payees_Address_1.ClientID + ",";
                    strMessages += "Please enter Loss Payee Address 1" + ",";
                    Span150.Style["display"] = "inline-block";
                    break;
                case "Named Loss Payees - Address 2":
                    strCtrlsIDs += txtLoss_Payees_Address_2.ClientID + ",";
                    strMessages += "Please enter Loss Payee Address 2" + ",";
                    Span151.Style["display"] = "inline-block";
                    break;
                case "Named Loss Payees - City":
                    strCtrlsIDs += txtLoss_Payees_City.ClientID + ",";
                    strMessages += "Please enter Loss Payee City" + ",";
                    Span152.Style["display"] = "inline-block";
                    break;
                case "Named Loss Payees - State":
                    strCtrlsIDs += ddlLoss_Payees_State.ClientID + ",";
                    strMessages += "Please select Loss Payee State" + ",";
                    Span153.Style["display"] = "inline-block";
                    break;
                case "Named Loss Payees - Zip":
                    strCtrlsIDs += txtLoss_Payees_Zip.ClientID + ",";
                    strMessages += "Please enter Loss Payee Zip" + ",";
                    Span154.Style["display"] = "inline-block";
                    break;
                case "Named Loss Payees - Type":
                    strCtrlsIDs += ddlLoss_Payees_Type.ClientID + ",";
                    strMessages += "Please select Loss Payee Type" + ",";
                    Span149.Style["display"] = "inline-block";
                    break;
            }

            #endregion
        }
        #endregion

        strCtrlsIDs = strCtrlsIDs.TrimEnd(',');
        strMessages = strMessages.TrimEnd(',');

        hdnControlIDsLossPayee.Value = strCtrlsIDs;
        hdnErrorMsgsLossPayee.Value = strMessages;
    }

    /// <summary>
    /// set all validation for Building-Ownership-SubLease
    /// </summary>
    private void SetValidationBuildingOwnershipSubLease()
    {
        string strCtrlsIDs = "";
        string strMessages = "";

        #region ""
        DataTable dtFields = clsScreen_Validators.SelectByScreen(137).Tables[0];
        dtFields.DefaultView.RowFilter = "IsRequired = '1'";
        dtFields = dtFields.DefaultView.ToTable();

        MenuAsterisk2.Style["display"] = (dtFields.Select("LeftMenuIndex = 2").Length > 0) ? "inline-block" : "none";

        foreach (DataRow drField in dtFields.Rows)
        {
            #region " set validation control IDs and messages "
            switch (Convert.ToString(drField["Field_Name"]))
            {
                case "Sub-Lease Name":
                    strCtrlsIDs += txtSubLease_Name.ClientID + ",";
                    strMessages += "Please enter Sub-Lease Name" + ",";
                    Span164.Style["display"] = "inline-block";
                    break;
                case "Sub-Lease Address 1":
                    strCtrlsIDs += txtSublease_Address_1.ClientID + ",";
                    strMessages += "Please enter Sub-Lease Address 1" + ",";
                    Span165.Style["display"] = "inline-block";
                    break;
                case "Sub-Lease Adderss 2":
                    strCtrlsIDs += txtSublease_Address_2.ClientID + ",";
                    strMessages += "Please enter Sub-Lease Adderss 2" + ",";
                    Span166.Style["display"] = "inline-block";
                    break;
                case "Sub-Lease City":
                    strCtrlsIDs += txtSublease_City.ClientID + ",";
                    strMessages += "Please enter Sub-Lease City" + ",";
                    Span167.Style["display"] = "inline-block";
                    break;
                case "Sub-Lease State":
                    strCtrlsIDs += ddlSublease_State.ClientID + ",";
                    strMessages += "Please select Sub-Lease State" + ",";
                    Span168.Style["display"] = "inline-block";
                    break;
                case "Sub-Lease Zip":
                    strCtrlsIDs += txtSublease_Zip.ClientID + ",";
                    strMessages += "Please enter Sub-Lease Zip" + ",";
                    Span169.Style["display"] = "inline-block";
                    break;
                case "Sub-Lease Landlord":
                    strCtrlsIDs += txtSubLandlord.ClientID + ",";
                    strMessages += "Please enter Sub-Lease Landlord" + ",";
                    Span157.Style["display"] = "inline-block";
                    break;
                case "Sub-Lease First Name":
                    strCtrlsIDs += txtSubleaseFirstName.ClientID + ",";
                    strMessages += "Please enter Sub-Lease First Name" + ",";
                    Span158.Style["display"] = "inline-block";
                    break;
                case "Sub-Lease Last Name":
                    strCtrlsIDs += txtSubleaseLastName.ClientID + ",";
                    strMessages += "Please enter Sub-Lease Last Name" + ",";
                    Span159.Style["display"] = "inline-block";
                    break;
                case "Sub-Lease Title":
                    strCtrlsIDs += txtSubleaseTitle.ClientID + ",";
                    strMessages += "Please enter Sub-Lease Title" + ",";
                    Span160.Style["display"] = "inline-block";
                    break;
                case "Sub-Lease Phone":
                    strCtrlsIDs += txtSubleasePhone.ClientID + ",";
                    strMessages += "Please enter Sub-Lease Phone" + ",";
                    Span161.Style["display"] = "inline-block";
                    break;
                case "Sub-Lease Fax":
                    strCtrlsIDs += txtSubleaseFax.ClientID + ",";
                    strMessages += "Please enter Sub-Lease Fax" + ",";
                    Span162.Style["display"] = "inline-block";
                    break;
                case "Sub-Lease Email":
                    strCtrlsIDs += txtSubleaseEmail.ClientID + ",";
                    strMessages += "Please enter Sub-Lease Email" + ",";
                    Span163.Style["display"] = "inline-block";
                    break;
            }
            #endregion
        }
        #endregion

        strCtrlsIDs = strCtrlsIDs.TrimEnd(',');
        strMessages = strMessages.TrimEnd(',');

        hdnControlIDsBuildingOwnerShipSubLease.Value = strCtrlsIDs;
        hdnErrorMsgsBuildingOwnerShipSubLease.Value = strMessages;
    }

    /// <summary>
    /// Set all Validations-SetValidations property Condition Assessment
    /// </summary>
    private void SetValidationspropertyConditionAssess()
    {
        string strCtrlsIDs = "";
        string strMessages = "";

        string strCtrlsIDsConcern = "";
        string strMessagesConcern = "";

        #region ""
        DataTable dtFields = clsScreen_Validators.SelectByScreen(56).Tables[0];
        dtFields.DefaultView.RowFilter = "IsRequired = '1'";
        dtFields = dtFields.DefaultView.ToTable();

        MenuAsterisk3.Style["display"] = (dtFields.Select("LeftMenuIndex = 3").Length > 0) ? "inline-block" : "none";

        foreach (DataRow drField in dtFields.Rows)
        {
            #region " set validation control IDs and messages "
            switch (Convert.ToString(drField["Field_Name"]))
            {
                case "Consultant Performing Assessment": strCtrlsIDs += txtAssessment_History_Assessor.ClientID + ","; strMessages += "Please enter [Property Condition Assessment]/Consultant Performing Assessment" + ","; Span118.Style["display"] = "inline-block"; break;
                case "Contact Name": strCtrlsIDs += txtAssessment_History_Contact_Name.ClientID + ","; strMessages += "Please enter [Property Condition Assessment]/Contact Name" + ","; Span119.Style["display"] = "inline-block"; break;
                case "Address 1": strCtrlsIDs += txtAssessment_History_Address_1.ClientID + ","; strMessages += "Please enter [Property Condition Assessment]/Address 1" + ","; Span120.Style["display"] = "inline-block"; break;
                case "Address 2": strCtrlsIDs += txtAssessment_History_Address_2.ClientID + ","; strMessages += "Please enter [Property Condition Assessment]/Address 2" + ","; Span122.Style["display"] = "inline-block"; break;
                case "City": strCtrlsIDs += txtAssessment_History_City.ClientID + ","; strMessages += "Please enter [Property Condition Assessment]/City" + ","; Span124.Style["display"] = "inline-block"; break;
                case "State": strCtrlsIDs += ddlAssessment_History_State.ClientID + ","; strMessages += "Please enter [Property Condition Assessment]/State" + ","; Span125.Style["display"] = "inline-block"; break;
                case "Zip": strCtrlsIDs += txtAssessment_History_Zip.ClientID + ","; strMessages += "Please enter [Property Condition Assessment]/Zip" + ","; Span126.Style["display"] = "inline-block"; break;
                case "Telephone": strCtrlsIDs += txtAssessment_History_Telephone.ClientID + ","; strMessages += "Please enter [Property Condition Assessment]/Telephone" + ","; Span121.Style["display"] = "inline-block"; break;
                case "Date": strCtrlsIDs += txtAssessment_History_Date.ClientID + ","; strMessages += "Please enter [Property Condition Assessment]/Date" + ","; Span123.Style["display"] = "inline-block"; break;

                case "Item Description ": strCtrlsIDsConcern += txtItem_Description.ClientID + ","; strMessagesConcern += "Please enter [Concerns Noted]/Item Description " + ","; Span127.Style["display"] = "inline-block"; break;
                case "Budgeted Cost ": strCtrlsIDsConcern += txtBudgeted_Cost.ClientID + ","; strMessagesConcern += "Please enter [Concerns Noted]/Budgeted Cost " + ","; Span128.Style["display"] = "inline-block"; break;
                case "Actual Cost ": strCtrlsIDsConcern += txtActual_Cost.ClientID + ","; strMessagesConcern += "Please enter [Concerns Noted]/Actual Cost " + ","; Span131.Style["display"] = "inline-block"; break;
                case "Date Complete ": strCtrlsIDsConcern += txtDate_Complete.ClientID + ","; strMessagesConcern += "Please enter [Concerns Noted]/Date Complete " + ","; Span129.Style["display"] = "inline-block"; break;
                case "Comments": strCtrlsIDsConcern += txtConcerns_Comments.ClientID + ","; strMessagesConcern += "Please enter [Concerns Noted]/Comments" + ","; Span130.Style["display"] = "inline-block"; break;
            }

            #endregion
        }
        #endregion

        strCtrlsIDs = strCtrlsIDs.TrimEnd(',');
        strMessages = strMessages.TrimEnd(',');

        hdnControlIDsPCA.Value = strCtrlsIDs;
        hdnErrorMsgsPCA.Value = strMessages;

        strCtrlsIDsConcern = strCtrlsIDsConcern.TrimEnd(',');
        strMessagesConcern = strMessagesConcern.TrimEnd(',');

        hdnControlIDsConcernNote.Value = strCtrlsIDsConcern;
        hdnErrorMsgsConcernNote.Value = strMessagesConcern;
    }

    /// <summary>
    /// Set all Validations-Ownership Details
    /// </summary>
    private void SetValidationsContact()
    {
        string strCtrlsIDsContact = "";
        string strMessagesContact = "";

        #region ""
        DataTable dtFields = clsScreen_Validators.SelectByScreen(57).Tables[0];
        dtFields.DefaultView.RowFilter = "IsRequired = '1'";
        dtFields = dtFields.DefaultView.ToTable();

        MenuAsterisk4.Style["display"] = (dtFields.Select("LeftMenuIndex = 4").Length > 0) ? "inline-block" : "none";

        foreach (DataRow drField in dtFields.Rows)
        {
            #region " set validation control IDs and messages "
            switch (Convert.ToString(drField["Field_Name"]))
            {
                case "Facility Contact - Name": strCtrlsIDsContact += txtName.ClientID + ","; strMessagesContact += "Please enter [Contacts]/Facility Contact - Name" + ","; Span132.Style["display"] = "inline-block"; break;
                case "Facility Contact - Cell Phone": strCtrlsIDsContact += txtCell_Phone.ClientID + ","; strMessagesContact += "Please enter [Contacts]/Facility Contact - Cell Phone" + ","; Span133.Style["display"] = "inline-block"; break;
                case "Facility Contact - Facility Telephone": strCtrlsIDsContact += txtPhone.ClientID + ","; strMessagesContact += "Please enter [Contacts]/Facility Contact - Facility Telephone" + ","; Span134.Style["display"] = "inline-block"; break;
                case "After Hours Contact - Name": strCtrlsIDsContact += txtAfter_Hours_Contact_Name.ClientID + ","; strMessagesContact += "Please enter [Contacts]/After Hours Contact - Name" + ","; Span135.Style["display"] = "inline-block"; break;
                case "After Hours Contact - Cell Phone": strCtrlsIDsContact += txtAfter_Hours_Contact_Cell_Phone.ClientID + ","; strMessagesContact += "Please enter [Contacts]/After Hours Contact - Cell Phone" + ","; Span136.Style["display"] = "inline-block"; break;
                case "After Hours Contact - Facility Telephone": strCtrlsIDsContact += txtAfter_Hours_Contact_Phone.ClientID + ","; strMessagesContact += "Please enter [Contacts]/After Hours Contact - Facility Telephone" + ","; Span137.Style["display"] = "inline-block"; break;
            }

            #endregion
        }
        #endregion

        strCtrlsIDsContact = strCtrlsIDsContact.TrimEnd(',');
        strMessagesContact = strMessagesContact.TrimEnd(',');

        hdnControlIDsContact.Value = strCtrlsIDsContact;
        hdnErrorMsgsContact.Value = strMessagesContact;
    }

    /// <summary>
    /// Set all Validations-Ownership Details
    /// </summary>
    private void SetValidationsSabaTraining()
    {
        string strCtrlsIDsST = "";
        string strMessagesST = "";

        #region ""
        DataTable dtFields = clsScreen_Validators.SelectByScreen(54).Tables[0];
        dtFields.DefaultView.RowFilter = "IsRequired = '1'";
        dtFields = dtFields.DefaultView.ToTable();

        MenuAsterisk2.Style["display"] = (dtFields.Select("LeftMenuIndex = 2").Length > 0) ? "inline-block" : "none";

        foreach (DataRow drField in dtFields.Rows)
        {
            #region " set validation control IDs and messages "
            switch (Convert.ToString(drField["Field_Name"]))
            {
                // Saba Training             
                //case "Saba Training-Date": strCtrlsIDsST += txtSaba_Training_Date.ClientID + ","; strMessagesST += "Please enter [Property Cope]/Saba Training-Date" + ","; Span138.Style["display"] = "inline-block"; break;
                case "Saba Training-Number of Associates To Train": strCtrlsIDsST += txtNumber_of_Employees.ClientID + ","; strMessagesST += "Please enter [Property Cope]/Number of Associates To Train" + ","; Span139.Style["display"] = "inline-block"; break;
                case "Saba Training-Number of Associates Trained": strCtrlsIDsST += txtNumber_of_Employees_To_Date.ClientID + ","; strMessagesST += "Please enter [Property Cope]/Number of Associates Trained" + ","; Span140.Style["display"] = "inline-block"; break;
                case "Saba Training-Percent of Associates Trained": strCtrlsIDsST += txtPercent_Employee_to_Date.ClientID + ","; strMessagesST += "Please enter [Property Cope]/Percent of Associates Trained" + ","; Span141.Style["display"] = "inline-block"; break;
            }

            #endregion
        }
        #endregion

        strCtrlsIDsST = strCtrlsIDsST.TrimEnd(',');
        strMessagesST = strMessagesST.TrimEnd(',');

        hdnControlIDsST.Value = strCtrlsIDsST;
        hdnErrorMsgsST.Value = strMessagesST;
    }


    #endregion

    #endregion
}

