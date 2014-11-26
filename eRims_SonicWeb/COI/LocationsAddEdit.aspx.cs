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
public partial class Admin_LocationsAddEdit : clsBasePage
{

    #region "Properties"
    string _strOperation = "";
    /// <summary>
    /// Denotes operation either view or edit
    /// </summary>
    public string StrOperation
    {
        get
        {
            return _strOperation;
        }
    }
    // FK for property policy
    public int FK_Table_Name
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PolicyID"]);
        }
        set { ViewState["PolicyID"] = value; }
    }

    // PK for location
    public int PK_COI_Locations
    {
        get
        {
            return clsGeneral.GetInt(ViewState["LocationID"]);
        }
        set { ViewState["LocationID"] = value; }
    }

    #endregion

    #region "Page Events"
    /// <summary>
    /// Handle Page Load Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {

        // if page is loaded first time.

        if (!IsPostBack)
        {
            #region "Hide and show Div"

            #endregion

            #region "Set active panel"
            if (!clsGeneral.IsNull(Request.QueryString["pnl"]))
            {

                Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(" + Request.QueryString["pnl"] + ");", true);
                _strOperation = Request.QueryString["op"].ToString();
            }
            else
                Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(1);", true);

            #endregion

            if (App_Access == AccessType.NotAssigned)
                Response.Redirect(AppConfig.SiteURL + "Message.aspx?msg=You are not authorized to access this page");
            else
            {
                // if COI's FK and Property's PK is not passed redirect to default page.
                if (!clsGeneral.IsNull(Request.QueryString["coi"]) && !clsGeneral.IsNull(Request.QueryString["prop"]))
                {
                    FK_Table_Name = Convert.ToInt32(clsGeneral.GetQueryStringID(Request.QueryString["prop"]));
                }
                else
                {
                    FK_Table_Name = 0;
                    lnkFind.Style["display"] = "none";
                    btnBackToProperty.Style["display"] = "none";
                    btnSaveReturn.Style["display"] = "none";
                    //BindInsuredGrid();
                    dvSave.Style["Display"] = "block";
                    BindDropDowns();
                }
                // if operations(view or edit) is passed in query string.
                if (!clsGeneral.IsNull(Request.QueryString["op"]))
                {
                    // if id is passed set primary key.
                    if (!clsGeneral.IsNull(Request.QueryString["id"]))
                    {
                        PK_COI_Locations = (int)clsGeneral.GetQueryStringID(Convert.ToString(Request.QueryString["id"]));
                    }
                    _strOperation = Request.QueryString["op"].ToString();

                    if (Request.QueryString["op"] == "view")
                    {
                        dvView.Style["Display"] = "block";
                        BindDetailsForView();
                        // set Attachment details control in read/write mode.
                        AttachDetails.InitializeAttachmentDetails(clsGeneral.Tables.Location, PK_COI_Locations, false, 2);

                        if (!clsGeneral.IsNull(Request.QueryString["Page"]))
                        {
                            if (Request.QueryString["Page"] == "GL" || Request.QueryString["Page"] == "AL" || Request.QueryString["Page"] == "EP" || Request.QueryString["Page"] == "WC" || Request.QueryString["Page"] == "PL" || Request.QueryString["Page"] == "LP")
                            {
                                dvPPView.Style["Display"] = "none";
                            }
                        }
                    }
                    else
                    {
                        if (App_Access == AccessType.Administrative_Access)
                        {
                            BindDropDowns();
                            // set Attachment details control in read/write mode.
                            AttachDetails.InitializeAttachmentDetails(clsGeneral.Tables.Location, PK_COI_Locations, true, 2);
                            BindDetailsForEdit();

                            if (!clsGeneral.IsNull(Request.QueryString["Page"]))
                            {
                                if (Request.QueryString["Page"] == "GL" || Request.QueryString["Page"] == "AL" || Request.QueryString["Page"] == "EP" || Request.QueryString["Page"] == "WC" || Request.QueryString["Page"] == "PL" || Request.QueryString["Page"] == "LP")
                                {
                                    //dvPPEdit.Style["Display"] = "none";
                                }
                            }
                        }
                        else
                            Response.Redirect(Request.Url.ToString().Replace("edit", "view"));
                    }
                    BindAttachmentDetails();
                }
                else
                {
                    if (App_Access == AccessType.Administrative_Access)
                    {
                        //BindInsuredGrid();
                        dvSave.Style["Display"] = "block";
                        BindDropDowns();
                        if (!clsGeneral.IsNull(Request.QueryString["Page"]))
                        {
                            if (Request.QueryString["Page"] == "GL" || Request.QueryString["Page"] == "AL" || Request.QueryString["Page"] == "EP" || Request.QueryString["Page"] == "WC" || Request.QueryString["Page"] == "PL" || Request.QueryString["Page"] == "LP")
                            {
                                //dvPPEdit.Style["Display"] = "none";
                            }
                        }
                    }
                    else
                        Response.Redirect(AppConfig.SiteURL + "Message.aspx?msg=You are not authorized to access this page");
                }
            }
        }
    }

    #endregion

    # region " Private Methods "
    /// <summary>
    /// show attachment details div and bind the details.
    /// </summary>
    private void BindAttachmentDetails()
    {
        dvAttachment.Style["Display"] = "block";
        AttachDetails.Bind();
    }
    /// <summary>
    /// Bind all dropdowns necessary for the record
    /// </summary>
    private void BindDropDowns()
    {
        DataTable dtState = COI_State.SelectAll().Tables[0];
        drpState.DataSource = dtState;
        drpState.DataTextField = "FLD_state";
        drpState.DataValueField = "PK_Id";
        drpState.DataBind();
        drpState.Items.Insert(0, "--Select--");


        DataTable dtRegion = COI_Region.SelectAll().Tables[0];
        drpRegion.DataSource = dtRegion;
        drpRegion.DataTextField = "Fld_Desc";
        drpRegion.DataValueField = "PK_COI_Region";
        drpRegion.DataBind();
        drpRegion.Items.Insert(0, "--Select--");

        DataTable dtDistrict = COI_District.SelectAll().Tables[0];
        drpDistrict.DataSource = dtDistrict;
        drpDistrict.DataTextField = "Fld_Desc";
        drpDistrict.DataValueField = "PK_COI_District";
        drpDistrict.DataBind();
        drpDistrict.Items.Insert(0, "--Select--");

        DataTable dtDivision = COI_Division.SelectAll().Tables[0];
        drpDivision.DataSource = dtDivision;
        drpDivision.DataTextField = "Fld_Desc";
        drpDivision.DataValueField = "PK_COI_Division";
        drpDivision.DataBind();
        drpDivision.Items.Insert(0, "--Select--");

        DataTable dtTier = COI_Tier.SelectAll().Tables[0];
        drpTier.DataSource = dtTier;
        drpTier.DataTextField = "Fld_Desc";
        drpTier.DataValueField = "PK_COI_Tier";
        drpTier.DataBind();
        drpTier.Items.Insert(0, "--Select--");
    }

    #endregion

    #region "Bind Details for Edit or View"

    /// <summary>
    /// Displays the page in edit mode
    /// </summary>
    private void BindDetailsForEdit()
    {
        dvView.Style["Display"] = "None";
        dvSave.Style["Display"] = "block";
        // create object for curernt WC Policy
        COI_Locations objLocation = new COI_Locations(PK_COI_Locations);

        // set values
        txtName.Text = objLocation.Name;
        txtAddress1.Text = objLocation.Address_1;
        txtAddress2.Text = objLocation.Address_2;
        txtCity.Text = objLocation.City;
        if (objLocation.FK_State != 0) { drpState.SelectedValue = Convert.ToString(objLocation.FK_State); }
        BindCountyDropdown(drpState.SelectedItem.Text);
        txtZipCode.Text = objLocation.Zip_Code;
        txtContactLastName.Text = objLocation.Contact_Last_Name;
        txtContactFirstName.Text = objLocation.Contact_First_Name;
        txtContactTitle.Text = objLocation.Contact_Title;
        txtContactPhone.Text = objLocation.Contact_Phone;
        txtContactFax.Text = objLocation.Contact_Fax;
        txtContactEmail.Text = objLocation.Contact_EMail;
        if (objLocation.FK_County != 0) { drpCounty.SelectedValue = Convert.ToString(objLocation.FK_County); }
        txtLocationNumber.Text = objLocation.Location_Number;
        txtSquareFootage.Text = clsGeneral.GetStringValue(objLocation.Square_Feet).Replace(".00", "");
        txtOpenDate.DateValue = objLocation.Open_Date;
        txtCloseDate.DateValue = objLocation.Close_Date;
        txtAssignDate.DateValue = objLocation.Assign_Date;
        txtServiceManager.Text = objLocation.Service_Manager;
        txtBuildingType.Text = objLocation.Building_Type;
        if (objLocation.FK_COI_Region != 0) { drpRegion.SelectedValue = Convert.ToString(objLocation.FK_COI_Region); }
        if (objLocation.FK_COI_District != 0) { drpDistrict.SelectedValue = Convert.ToString(objLocation.FK_COI_District); }
        if (objLocation.FK_COI_Division != 0) { drpDivision.SelectedValue = Convert.ToString(objLocation.FK_COI_Division); }
        if (objLocation.FK_COI_Tier != 0) { drpTier.SelectedValue = Convert.ToString(objLocation.FK_COI_Tier); }
        //rdoBlanketCoverage.SelectedValue = objLocation.Blanket_Coverage.ToString();
        txtBuildingValue.Text = clsGeneral.GetStringValue(objLocation.Building_Value);
        txtEquipmentValue.Text = clsGeneral.GetStringValue(objLocation.Equipment_Value);
        txtSignageValue.Text = clsGeneral.GetStringValue(objLocation.Signage_Value);
        rdoGlassACV.SelectedValue = Convert.ToString(objLocation.Glass_ACV);
        txtGlassValue.Text = clsGeneral.GetStringValue(objLocation.Glass_Value);
        txtDeductible.Text = clsGeneral.GetStringValue(objLocation.Deductible);
        rdoLossOfIncomeALS.SelectedValue = Convert.ToString(objLocation.Loss_Of_Income_ALS);
        txtLossOfIncomeMonths.Text = Convert.ToString(objLocation.Loss_Of_Income_Months);
        txtPercentage.Text = clsGeneral.GetStringValue(objLocation.Percentage);
        txtFlood.Text = clsGeneral.GetStringValue(objLocation.Flood_Coverage);
        txtWindHail.Text = clsGeneral.GetStringValue(objLocation.Wind_Hail_Coverage);
        txtEachMovement.Text = clsGeneral.GetStringValue(objLocation.Earth_Movement_Coverage);
        txtBIOccurrence.Text = clsGeneral.GetStringValue(objLocation.BI_Occurrence);
        txtBIAggregate.Text = clsGeneral.GetStringValue(objLocation.BI_Aggregate);
        txtBuildingOccur.Text = clsGeneral.GetStringValue(objLocation.Building_Occurrence);
        txtBuildingAggregate.Text = clsGeneral.GetStringValue(objLocation.Building_Aggregate);
        txtBuildingDeductible.Text = clsGeneral.GetStringValue(objLocation.Building_Deductible);
        txtEuipOccur.Text = clsGeneral.GetStringValue(objLocation.Equipment_Occurrence);
        txtEquipAggregate.Text = clsGeneral.GetStringValue(objLocation.Equipment_Aggregate);
        txtEquipmentDeductible.Text = clsGeneral.GetStringValue(objLocation.Equipment_Deductible);
        txtSignOccur.Text = clsGeneral.GetStringValue(objLocation.Sign_Occurrence);
        txtSignAggregate.Text = clsGeneral.GetStringValue(objLocation.SIgn_Aggregate);
        txtGlassOccur.Text = clsGeneral.GetStringValue(objLocation.Glass_Occurrence);
        txtGlassAggregate.Text = clsGeneral.GetStringValue(objLocation.Glass_Aggregate);
        rdoOrdinanceLaw.SelectedValue = Convert.ToString(objLocation.Ordinance_Law);
        rdoSubrogationWaiver.SelectedValue = Convert.ToString(objLocation.Subrogation_Waiver);
        rdoPerilsInsuredForm.SelectedValue = Convert.ToString(objLocation.Perils_Insured_Form);
        rdoPropertyOnAcord.SelectedValue = Convert.ToString(objLocation.Property_On_Acord);
        rdoCertificateReceived.SelectedValue = Convert.ToString(objLocation.Certificate_Received);
        rdoReplacementCosts.SelectedValue = Convert.ToString(objLocation.Replacement_Costs);
        rdoEarthquakeZone.SelectedValue = Convert.ToString(objLocation.Earthquake_Zone);
        rdoSprinkler.SelectedValue = Convert.ToString(objLocation.Sprinkler);
        rdoAlarm.SelectedValue = Convert.ToString(objLocation.Alarm);
        txtLeaseExpirationTenant.DateValue = objLocation.Lease_Expiration_Tenant;
        txtLeaseExpirationSubTenant.DateValue = objLocation.Lease_Expiration_SubTenant;
        rdoBIIncludedInVerification.SelectedValue = objLocation.B_I_Included_In_Verification;
        rdoPropertyLimitAccepted.SelectedValue = objLocation.Leased_Building_Limit_Accepted;
        txtDatePurchased.DateValue = objLocation.Date_Purchased;
        txtDateLeased.DateValue = objLocation.Date_Leased;
        rdoLeasedProperty.SelectedValue = objLocation.Leased_Property;
        txtNotes.Text = objLocation.Notes;


    }

    /// <summary>
    /// Displays the page in view mode
    /// </summary>
    private void BindDetailsForView()
    {
        dvEdit.Style["Display"] = "None";
        dvBack.Style["Display"] = "block";
        //lnkGeneralAdd.Style["Display"] = "None";
        // create object for curernt WC Policy
        COI_Locations objLocation = new COI_Locations(PK_COI_Locations);

        // set values
        lblName.Text = objLocation.Name;
        lblAddress1.Text = objLocation.Address_1;
        lblAddress2.Text = objLocation.Address_2;
        lblCity.Text = objLocation.City;
        lblState.Text = new COI_State(objLocation.FK_State).FLD_state;
        lblZipCode.Text = objLocation.Zip_Code;
        lblContactLastName.Text = objLocation.Contact_Last_Name;
        lblContactFirstName.Text = objLocation.Contact_First_Name;
        lblContactTitle.Text = objLocation.Contact_Title;
        lblContactPhone.Text = objLocation.Contact_Phone;
        lblContactFax.Text = objLocation.Contact_Fax;
        lblContactEmail.Text = objLocation.Contact_EMail;
        lblCountry.Text = new COI_County(objLocation.FK_County).FLD_county;
        lblLocationNumber.Text = objLocation.Location_Number;
        lblSquareFootage.Text = clsGeneral.GetStringValue(objLocation.Square_Feet).Replace(".00", "");
        lblOpenDate.Text = clsGeneral.FormatDate(objLocation.Open_Date);
        lblCloseDate.Text = clsGeneral.FormatDate(objLocation.Close_Date);
        lblAssignDate.Text = clsGeneral.FormatDate(objLocation.Assign_Date);
        lblServiceManager.Text = objLocation.Service_Manager;
        lblBuildingType.Text = objLocation.Building_Type;
        lblRegion.Text = new COI_Region(objLocation.FK_COI_Region).Fld_Desc;
        lblDistrict.Text = new COI_District(objLocation.FK_COI_District).Fld_Desc;
        lblDivision.Text = new COI_Division(objLocation.FK_COI_Division).Fld_Desc;
        lblTier.Text = new COI_Tier(objLocation.FK_COI_Tier).Fld_Desc;
        //lblBlanketCoverage.Text = objLocation.Blanket_Coverage == "Y" ? "YES" : "NO";
        lblBuildingValue.Text = clsGeneral.GetStringValue(objLocation.Building_Value);
        lblEquipmentValue.Text = clsGeneral.GetStringValue(objLocation.Equipment_Value);
        lblSignageValue.Text = clsGeneral.GetStringValue(objLocation.Signage_Value);
        lblGlassACV.Text = objLocation.Glass_ACV == "Y" ? "YES" : "NO";
        lblGlassValue.Text = clsGeneral.GetStringValue(objLocation.Glass_Value);
        lblDeductible.Text = clsGeneral.GetStringValue(objLocation.Deductible);
        lblLossOfIncomeALS.Text = objLocation.Loss_Of_Income_ALS == "Y" ? "YES" : "NO";
        lblLossOfIncomeMonths.Text = clsGeneral.GetStringValue(objLocation.Loss_Of_Income_Months);
        lblPercentage.Text = clsGeneral.GetStringValue(objLocation.Percentage);
        lblFlood.Text = clsGeneral.GetStringValue(objLocation.Flood_Coverage);
        lblWindHail.Text = clsGeneral.GetStringValue(objLocation.Wind_Hail_Coverage);
        lblEachMovement.Text = clsGeneral.GetStringValue(objLocation.Earth_Movement_Coverage);
        lblBIOccurrence.Text = clsGeneral.GetStringValue(objLocation.BI_Occurrence);
        lblBIAggregate.Text = clsGeneral.GetStringValue(objLocation.BI_Aggregate);
        lblBuildingOccur.Text = clsGeneral.GetStringValue(objLocation.Building_Occurrence);
        lblBuildingAggregate.Text = clsGeneral.GetStringValue(objLocation.Building_Aggregate);
        lblBuildingDeductible.Text = clsGeneral.GetStringValue(objLocation.Building_Deductible);
        lblEuipOccur.Text = clsGeneral.GetStringValue(objLocation.Equipment_Occurrence);
        lblEquipAggregate.Text = clsGeneral.GetStringValue(objLocation.Equipment_Aggregate);
        lblEquipmentDeductible.Text = clsGeneral.GetStringValue(objLocation.Equipment_Deductible);
        lblSignOccur.Text = clsGeneral.GetStringValue(objLocation.Sign_Occurrence);
        lblSignAggregate.Text = clsGeneral.GetStringValue(objLocation.SIgn_Aggregate);
        lblGlassOccur.Text = clsGeneral.GetStringValue(objLocation.Glass_Occurrence);
        lblGlassAggregate.Text = clsGeneral.GetStringValue(objLocation.Glass_Aggregate);
        lblOrdinanceLaw.Text = objLocation.Ordinance_Law == "Y" ? "YES" : "NO";
        lblSubrogationWaiver.Text = objLocation.Subrogation_Waiver == "Y" ? "YES" : "NO";
        lblPerilsInsuredForm.Text = objLocation.Perils_Insured_Form == "Y" ? "YES" : "NO";
        lblPropertyOnAcord.Text = objLocation.Property_On_Acord == "Y" ? "YES" : "NO";
        lblCertificateReceived.Text = objLocation.Certificate_Received == "Y" ? "YES" : "NO";
        lblReplacementCosts.Text = objLocation.Replacement_Costs == "Y" ? "YES" : "NO";
        lblEarthquakeZone.Text = objLocation.Earthquake_Zone == "Y" ? "YES" : "NO";
        lblSprinkler.Text = objLocation.Sprinkler == "Y" ? "YES" : "NO";
        lblAlarm.Text = objLocation.Alarm == "Y" ? "YES" : "NO";
        lblLeaseExpirationTenant.Text = clsGeneral.FormatDate(objLocation.Lease_Expiration_Tenant);
        lblLeaseExpirationSubTenant.Text = clsGeneral.FormatDate(objLocation.Lease_Expiration_SubTenant);
        lblDatePurchased.Text = clsGeneral.FormatDate(objLocation.Date_Purchased);
        lblBIIncludedInVerification.Text = objLocation.B_I_Included_In_Verification == "Y" ? "YES" : "NO";
        lblPropertyLimitAccepted.Text = objLocation.Leased_Building_Limit_Accepted == "Y" ? "YES" : "NO";
        lblDateLeased.Text = clsGeneral.FormatDate(objLocation.Date_Leased);
        lblLeasedProperty.Text = objLocation.Leased_Property == "Y" ? "YES" : "NO";
        lblNotes.Text = objLocation.Notes;
    }

    #endregion

    #region " Control Events "

    /// <summary>
    /// Handle SaveReturn button Click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSaveReturn_Click(object sender, EventArgs e)
    {
        btnSave_Click(null, null);

        btnBackToProperty_Click(null, null);
    }

    // add or update location record
    protected void btnSave_Click(object sender, EventArgs e)
    {
        // check page is valid or not.        
        if (Page.IsValid)
        {

            // create a new object for location.
            COI_Locations objLocation = new COI_Locations();

            //set values.
            objLocation.PK_COI_Locations = PK_COI_Locations;
            objLocation.FK_Table_Name = FK_Table_Name;

            if (!clsGeneral.IsNull(Request.QueryString["Page"]))
            {
                if (Request.QueryString["Page"] == "GL")
                {
                    objLocation.Table_Name = "General_Policy";
                }
                else if (Request.QueryString["Page"] == "AL")
                {
                    objLocation.Table_Name = "Automobile_Policy";
                }
                else if (Request.QueryString["Page"] == "EP")
                {
                    objLocation.Table_Name = "Excess_Policy";
                }
                else if (Request.QueryString["Page"] == "WC")
                {
                    objLocation.Table_Name = "Workers_Comp";
                }
                else if (Request.QueryString["Page"] == "PL")
                {
                    objLocation.Table_Name = "Professional_Policy";
                }
                else if (Request.QueryString["Page"] == "LP")
                {
                    objLocation.Table_Name = "Liqour_Policy";
                }
                else if (Request.QueryString["Page"] == "PP")
                {
                    objLocation.Table_Name = "Property_Policy";
                }
            }

            objLocation.Name = txtName.Text.Trim();
            objLocation.Address_1 = txtAddress1.Text.Trim();
            objLocation.Address_2 = txtAddress2.Text.Trim();
            objLocation.City = txtCity.Text.Trim();
            objLocation.FK_State = drpState.SelectedIndex != 0 ? Convert.ToInt32(drpState.SelectedValue) : 0;
            objLocation.Zip_Code = txtZipCode.Text.Trim();
            objLocation.Contact_Last_Name = txtContactLastName.Text.Trim();
            objLocation.Contact_First_Name = txtContactFirstName.Text.Trim();
            objLocation.Contact_Title = txtContactTitle.Text.Trim();
            objLocation.Contact_Phone = txtContactPhone.Text.Trim();
            objLocation.Contact_Fax = txtContactFax.Text.Trim();
            objLocation.Contact_EMail = txtContactEmail.Text.Trim();
            objLocation.FK_County = (drpCounty.SelectedIndex != -1 && drpCounty.SelectedIndex != 0) ? Convert.ToInt32(drpCounty.SelectedValue) : 0;
            objLocation.Location_Number = txtLocationNumber.Text.Trim();
            objLocation.Square_Feet = clsGeneral.GetDecimalValue(txtSquareFootage);
            objLocation.Open_Date = txtOpenDate.DateValue;
            objLocation.Close_Date = txtCloseDate.DateValue;
            objLocation.Assign_Date = txtAssignDate.DateValue;
            objLocation.Service_Manager = txtServiceManager.Text.Trim();
            objLocation.Building_Type = txtBuildingType.Text.Trim();
            objLocation.FK_COI_Region = drpRegion.SelectedIndex != 0 ? Convert.ToInt32(drpRegion.SelectedValue) : 0;
            objLocation.FK_COI_District = drpDistrict.SelectedIndex != 0 ? Convert.ToInt32(drpDistrict.SelectedValue) : 0;
            objLocation.FK_COI_Division = drpDivision.SelectedIndex != 0 ? Convert.ToInt32(drpDivision.SelectedValue) : 0;
            objLocation.FK_COI_Tier = drpTier.SelectedIndex != 0 ? Convert.ToInt32(drpTier.SelectedValue) : 0;
            //objLocation.Blanket_Coverage = rdoBlanketCoverage.SelectedValue;
            objLocation.Building_Value = clsGeneral.GetDecimalValue(txtBuildingValue);
            objLocation.Equipment_Value = clsGeneral.GetDecimalValue(txtEquipmentValue);
            objLocation.Signage_Value = clsGeneral.GetDecimalValue(txtSignageValue);

            objLocation.Glass_ACV = rdoGlassACV.SelectedValue;
            objLocation.Glass_Value = clsGeneral.GetDecimalValue(txtGlassValue);
            objLocation.Deductible = clsGeneral.GetDecimalValue(txtDeductible);
            objLocation.Loss_Of_Income_ALS = rdoLossOfIncomeALS.SelectedValue;
            objLocation.Loss_Of_Income_Months = clsGeneral.GetDecimalValue(txtLossOfIncomeMonths);
            objLocation.Percentage = clsGeneral.GetDecimalValue(txtPercentage);
            objLocation.Flood_Coverage = clsGeneral.GetDecimalValue(txtFlood);
            objLocation.Wind_Hail_Coverage = clsGeneral.GetDecimalValue(txtWindHail);
            objLocation.Earth_Movement_Coverage = clsGeneral.GetDecimalValue(txtEachMovement);
            objLocation.BI_Occurrence = clsGeneral.GetDecimalValue(txtBIOccurrence);
            objLocation.BI_Aggregate = clsGeneral.GetDecimalValue(txtBIAggregate);
            objLocation.Building_Occurrence = clsGeneral.GetDecimalValue(txtBuildingOccur);
            objLocation.Building_Aggregate = clsGeneral.GetDecimalValue(txtBuildingAggregate);
            objLocation.Building_Deductible = clsGeneral.GetDecimalValue(txtBuildingDeductible);
            objLocation.Equipment_Occurrence = clsGeneral.GetDecimalValue(txtEuipOccur);
            objLocation.Equipment_Aggregate = clsGeneral.GetDecimalValue(txtEquipAggregate);
            objLocation.Equipment_Deductible = clsGeneral.GetDecimalValue(txtEquipmentDeductible);
            objLocation.Sign_Occurrence = clsGeneral.GetDecimalValue(txtSignOccur);
            objLocation.SIgn_Aggregate = clsGeneral.GetDecimalValue(txtSignAggregate);
            objLocation.Glass_Occurrence = clsGeneral.GetDecimalValue(txtGlassOccur);
            objLocation.Glass_Aggregate = clsGeneral.GetDecimalValue(txtGlassAggregate);
            objLocation.Ordinance_Law = rdoOrdinanceLaw.SelectedValue;
            objLocation.Subrogation_Waiver = rdoSubrogationWaiver.SelectedValue;
            objLocation.Perils_Insured_Form = rdoPerilsInsuredForm.SelectedValue;
            objLocation.Property_On_Acord = rdoPropertyOnAcord.SelectedValue;
            objLocation.Certificate_Received = rdoCertificateReceived.SelectedValue;
            objLocation.Replacement_Costs = rdoReplacementCosts.SelectedValue;
            objLocation.Earthquake_Zone = rdoEarthquakeZone.SelectedValue;
            objLocation.Sprinkler = rdoSprinkler.SelectedValue;
            objLocation.Alarm = rdoAlarm.SelectedValue;
            objLocation.Lease_Expiration_Tenant = txtLeaseExpirationTenant.DateValue;
            objLocation.Lease_Expiration_SubTenant = txtLeaseExpirationSubTenant.DateValue;
            objLocation.Date_Purchased = txtDatePurchased.DateValue;
            objLocation.Date_Leased = txtDateLeased.DateValue;
            objLocation.Leased_Property = rdoLeasedProperty.SelectedValue;
            objLocation.B_I_Included_In_Verification = rdoBIIncludedInVerification.SelectedValue;
            objLocation.Leased_Building_Limit_Accepted = rdoPropertyLimitAccepted.SelectedValue;
            objLocation.Notes = txtNotes.Text.Trim();
            objLocation.Update_Date = DateTime.Today;
            objLocation.Updated_By = clsSession.UserName;

            // check if insert or update the Property Policy.
            if (PK_COI_Locations > 0)
                objLocation.Update();
            else
            {
                PK_COI_Locations = objLocation.Insert();
                //dvGrid.Style["Display"] = "block";
            }

            // add attachment if any
            Attachment.Add(clsGeneral.Tables.Location, PK_COI_Locations);

            // check if arguments are passed or not for redirecting to Additional Insured page
            string passedArgument = Request.Params.Get("__EVENTARGUMENT");
            if (passedArgument != "")
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "RedirectToPage", "javascript:RedirectToPage('" + passedArgument + "');", true);
            else
            {

                // set Attachment details control in read/write mode.
                AttachDetails.InitializeAttachmentDetails(clsGeneral.Tables.Location, PK_COI_Locations, true, 2);

                BindAttachmentDetails();
                Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(1);", true);
            }
            //HideAll();
        }
    }

    /// <summary>
    /// Hanlde Add Attachment Click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Attachment_btnHandler(object sender)
    {
        // check if Property Policy reocord is saved or not.
        // if not don't save any attachment
        if (PK_COI_Locations > 0)
        {
            Attachment.Add(clsGeneral.Tables.Location, PK_COI_Locations);

            // after saving attachment bind attachment details again.
            BindAttachmentDetails();
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(2);", true);
        }
        else
            ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript: alert('Please save Location First');ShowPanel(1);", true);
    }

    /// <summary>
    /// Handle btnBackToProperty Click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnBackToProperty_Click(object sender, EventArgs e)
    {
        if (!clsGeneral.IsNull(Request.QueryString["Page"]))
        {
            if (!clsGeneral.IsNull(Request.QueryString["op"]))
            {
                if (Request.QueryString["Page"] == "GL")
                {
                    Response.Redirect("GeneralPolicyAddEdit.aspx?op=" + Request.QueryString["op"] + "&coi=" + Request.QueryString["coi"] + "&id=" + Encryption.Encrypt(FK_Table_Name.ToString()) + "&pnl=2");
                }
                else if (Request.QueryString["Page"] == "AL")
                {
                    Response.Redirect("AutomobilePolicyAddEdit.aspx?op=" + Request.QueryString["op"] + "&coi=" + Request.QueryString["coi"] + "&id=" + Encryption.Encrypt(FK_Table_Name.ToString()) + "&pnl=2");
                }
                else if (Request.QueryString["Page"] == "EP")
                {
                    Response.Redirect("ExcessPolicyAddEdit.aspx?op=" + Request.QueryString["op"] + "&coi=" + Request.QueryString["coi"] + "&id=" + Encryption.Encrypt(FK_Table_Name.ToString()) + "&pnl=2");
                }
                else if (Request.QueryString["Page"] == "WC")
                {
                    Response.Redirect("WCPolicyAddEdit.aspx?op=" + Request.QueryString["op"] + "&coi=" + Request.QueryString["coi"] + "&id=" + Encryption.Encrypt(FK_Table_Name.ToString()) + "&pnl=2");
                }
                else if (Request.QueryString["Page"] == "PL")
                {
                    Response.Redirect("ProfessionalPolicy.aspx?op=" + Request.QueryString["op"] + "&coi=" + Request.QueryString["coi"] + "&id=" + Encryption.Encrypt(FK_Table_Name.ToString()) + "&pnl=2");
                }
                else if (Request.QueryString["Page"] == "LP")
                {
                    Response.Redirect("LiquorPolicyAddEdit.aspx?op=" + Request.QueryString["op"] + "&coi=" + Request.QueryString["coi"] + "&id=" + Encryption.Encrypt(FK_Table_Name.ToString()) + "&pnl=2");
                }
                else if (Request.QueryString["Page"] == "PP")
                {
                    Response.Redirect("PropertyPolicyAddEdit.aspx?op=" + Request.QueryString["op"] + "&coi=" + Request.QueryString["coi"] + "&id=" + Encryption.Encrypt(FK_Table_Name.ToString()) + "&pnl=2");
                }
            }
            else
            {
                if (Request.QueryString["Page"] == "GL")
                {
                    Response.Redirect("GeneralPolicyAddEdit.aspx?op=edit" + "&coi=" + Request.QueryString["coi"] + "&id=" + Encryption.Encrypt(FK_Table_Name.ToString()) + "&pnl=2");
                }
                else if (Request.QueryString["Page"] == "AL")
                {
                    Response.Redirect("AutomobilePolicyAddEdit.aspx?op=edit" + "&coi=" + Request.QueryString["coi"] + "&id=" + Encryption.Encrypt(FK_Table_Name.ToString()) + "&pnl=2");
                }
                else if (Request.QueryString["Page"] == "EP")
                {
                    Response.Redirect("ExcessPolicyAddEdit.aspx?op=edit" + "&coi=" + Request.QueryString["coi"] + "&id=" + Encryption.Encrypt(FK_Table_Name.ToString()) + "&pnl=2");
                }
                else if (Request.QueryString["Page"] == "WC")
                {
                    Response.Redirect("WCPolicyAddEdit.aspx?op=edit" + "&coi=" + Request.QueryString["coi"] + "&id=" + Encryption.Encrypt(FK_Table_Name.ToString()) + "&pnl=2");
                }
                else if (Request.QueryString["Page"] == "PL")
                {
                    Response.Redirect("ProfessionalPolicy.aspx?op=edit" + "&coi=" + Request.QueryString["coi"] + "&id=" + Encryption.Encrypt(FK_Table_Name.ToString()) + "&pnl=2");
                }
                else if (Request.QueryString["Page"] == "LP")
                {
                    Response.Redirect("LiquorPolicyAddEdit.aspx?op=edit" + "&coi=" + Request.QueryString["coi"] + "&id=" + Encryption.Encrypt(FK_Table_Name.ToString()) + "&pnl=2");
                }
                else if (Request.QueryString["Page"] == "PP")
                {
                    Response.Redirect("PropertyPolicyAddEdit.aspx?op=edit" + "&coi=" + Request.QueryString["coi"] + "&id=" + Encryption.Encrypt(FK_Table_Name.ToString()) + "&pnl=2");
                }
            }
        }
    }

    /// <summary>
    /// handle drpState SelectedIndexChanged event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void drpState_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (drpState.SelectedIndex != 0)
        {
            BindCountyDropdown(drpState.SelectedItem.Text);
        }
    }

    /// <summary>
    /// Bind County Drop Down
    /// </summary>
    /// <param name="strState"></param>
    private void BindCountyDropdown(string strState)
    {
        DataTable dtCounty = COI_County.SelectByState(strState).Tables[0];
        drpCounty.DataSource = dtCounty;
        drpCounty.DataTextField = "FLD_county";
        drpCounty.DataValueField = "PK_Id";
        drpCounty.DataBind();
        drpCounty.Items.Insert(0, "--Select--");
    }

    /// <summary>
    /// Hide all control
    /// </summary>
    private void HideAll()
    {
        Panel1.Style["Display"] = "block";
        Panel2.Style["Display"] = "none";
        //Panel3.Style["Display"] = "none";
        dvAttachment.Style["Display"] = "none";
        //dvGrid.Style["Display"] = "none";
    }
    #endregion
}
