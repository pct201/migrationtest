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
/// Date : 21 OCT 2008
/// 
/// By : Hetal Prajapati
/// 
/// Purpose: 
/// To view the Property information after the Property record is saved
/// 
/// Functionality:
/// Gets the Location ID from querystring and provides the information 
/// for that in view mode
/// 
/// </summary>
public partial class SONIC_Exposures_PropertyView : clsBasePage
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
    /// Denotes PK for Building_Ownership SubLease table
    /// </summary>
    private int PK_Building_OwnershipSubLease
    {
        get { return Convert.ToInt32(ViewState["PK_Building_OwnershipSubLease"]); }
        set { ViewState["PK_Building_OwnershipSubLease"] = value; hdnSubLeaseID.Value = value.ToString(); }
    }

    /// <summary>
    /// Denotes PK for Building_Payee table
    /// </summary>
    private int PK_Building_Payee
    {
        get { return Convert.ToInt32(ViewState["PK_Building_Payee"]); }
        set { ViewState["PK_Building_Payee"] = value; hdnLossPayeeID.Value = value.ToString(); }
    }

    ///// <summary>
    ///// Denotes PK for Property_Assessment table
    ///// </summary>
    //private int PK_Property_Assessment_ID
    //{
    //    get { return Convert.ToInt32(ViewState["PK_Property_Assessment_ID"]); }
    //    set { ViewState["PK_Property_Assessment_ID"] = value; hdnAssessmentID.Value = value.ToString(); }
    //}

    ///// <summary>
    ///// Denotes PK for Property_Assessment_Concern table
    ///// </summary>
    //private int PK_Property_Assessment_Concern_ID
    //{
    //    get { return Convert.ToInt32(ViewState["PK_Property_Assessment_Concern_ID"]); }
    //    set { ViewState["PK_Property_Assessment_Concern_ID"] = value; hdnAssessmentConcernID.Value = value.ToString(); }
    //}

    /// <summary>
    /// Denotes PK for Property_Contact table
    /// </summary>
    private int PK_Property_Contact_ID
    {
        get { return Convert.ToInt32(ViewState["PK_Property_Contact_ID"]); }
        set { ViewState["PK_Property_Contact_ID"] = value; }
    }

    /// <summary>
    /// Denotes operation view for the page 
    /// </summary>
    public string strOperation
    {
        get { return "view"; }
        //get { return ViewState["strOperation"].ToString(); }
        //set { ViewState["strOperation"] = value; }
    }

    #endregion

    #region "Page Events"
    protected void Page_Load(object sender, EventArgs e)
    {
        SetDynamicInsuranceControl();

        // Set Tab selection
        Tab.SetSelectedTab(Controls_ExposuresTab_ExposuresTab.Tab.Property);
        //used to check Page Post Back Event
        if (!IsPostBack)
        {
            // check location is passed in querystring or not
            if (Request.QueryString["loc"] != null)
            {
                int loc;
                if (int.TryParse(Encryption.Decrypt(Request.QueryString["loc"]), out loc))
                {
                    FK_LU_Location_ID = loc;
                }
                else
                    Response.Redirect("ExposureSearch.aspx");

                // store location in session
                Session["ExposureLocation"] = FK_LU_Location_ID;

                // bind basic information on top panel
                ucCtrlExposureInfo.PK_LU_Location = FK_LU_Location_ID;
                ucCtrlExposureInfo.BindExposureInfo();

                // get PK property COPE for the location
                PK_Property_Cope_ID = Property_COPE.SelectPKByLocation(FK_LU_Location_ID);

                // binddetails for view
                BindDetailsForView();

                string strActive = new LU_Location(Convert.ToDecimal(FK_LU_Location_ID)).Active;
                if (PK_Property_Cope_ID <= 0 && strActive == "N")
                    btnBack.Enabled = false;

                // bind location information, business interruption and assessment grid
                BindLocationInformation();

                //Commented below line for ticket #3132
                //BindGridBusinessInterruption();

                //Commented below line for ticket #3132
                //BindGridAssessment();

                BindSubLeaseGrid();
                if (Request.QueryString["build"] != null)
                {
                    int decID;
                    if (int.TryParse(Encryption.Decrypt(Request.QueryString["build"]), out decID)) PK_Building_ID = decID;
                    {
                        BindBuildingDetails();
                        BindInuranceDetailForView(PK_Building_ID);
                    }
                    
                    ScriptManager.RegisterStartupScript(Page, GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(2);", true);
                }
                else if (Request.QueryString["pnl"] != null)//used for Event_New.aspx page
                    ScriptManager.RegisterStartupScript(Page, GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(2);", true);
                else
                    ScriptManager.RegisterStartupScript(Page, GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(1);", true);

               
            }
            else
                Response.Redirect("ExposureSearch.aspx");


        }
        // Check if User has right To Add or Edit 
        if (App_Access == AccessType.View_Only)
        {
            btnBack.Visible = false;
        }
    }
    #endregion

    #region "Control Events"

    /// <summary>
    /// Handles Back button click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnBack_Click(object sender, EventArgs e)
    {
        // redirect to Proeprty page for edit 
        Response.Redirect("Property.aspx?loc=" + Request.QueryString["loc"]);
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

    #region "GRIDVIEW EVENTS"

    /// <summary>
    /// Handles Building grid rowcommand event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvBuildingEdit_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        // if passed command is for viewing detail then get PK from passed argument and bind building details
        if (e.CommandName == "ViewBuildingDetail")
        {
            PK_Building_ID = Convert.ToInt32(e.CommandArgument);
            BindBuildingDetails();
            BindGridBuilding();

            //bind Insurance detail for view
            BindInuranceDetailForView(PK_Building_ID);
        }
    }

    /// <summary>
    /// Handles gvSabaTraining grid row command event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvSabaTraining_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "gvEdit")
        {
            hdnPKPropertySabaTraning.Value = Convert.ToString(e.CommandArgument);
            hdrPropertyCope.Style["display"] = tblPropertyCope.Style["display"] = "none";
            pnlSabaTraining.Style["display"] = "";
            BindSabaDetailForView();
            this.btnViewAuditSabaTraining.Attributes.Add("onclick", "javascript:return ShowAuditPopUp('AuditPopup_SabaTraining.aspx?id=" + hdnPKPropertySabaTraning.Value.ToString() + "');");
        }
    }


    private void BindSabaDetailForView()
    {
        decimal index;
        if (decimal.TryParse(hdnPKPropertySabaTraning.Value, out index))
        {
            Property_COPE_Saba_Training objSabaTraining = new Property_COPE_Saba_Training(index);
            txtSaba_Training_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objSabaTraining.Date);
            if (objSabaTraining.Year > 0) txtSaba_Training_Year.Text = Convert.ToString(objSabaTraining.Year);
            if (objSabaTraining.Quarter > 0) lblQuarter.Text = Convert.ToString(objSabaTraining.Quarter);
            txtNumber_of_Employees.Text = clsGeneral.GetStringValue(objSabaTraining.Number_of_Employees).Replace(".00", "");
            txtNumber_of_Employees_To_Date.Text = clsGeneral.GetStringValue(objSabaTraining.Number_Trained).Replace(".00", "");
            if (objSabaTraining.Percent_Trained.HasValue)
                txtPercent_Employee_to_Date.Text = Convert.ToString(objSabaTraining.Percent_Trained);
        }
    }

    /// <summary>
    /// Handles building grid row data bound event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvBuildingEdit_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        // check for datarow
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
            BindGridAdditionalInsureds();
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

            // bind details for payee and grid
            BindPayeeDetails();
            BindGridPayees();
        }

    }

    protected void gvSubLease_OnRowCommand(object sender, GridViewCommandEventArgs e)
    {
        // if passed command is for viewing details
        if (e.CommandName == "ViewSubLeaseDetails")
        {
            PK_Building_OwnershipSubLease = Convert.ToInt32(e.CommandArgument);

            BindSubLeaseDetail();
            BindSubLeaseGrid();
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
            ScriptManager.RegisterClientScriptBlock(Page, GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(5);OpenPropertyDetailPopup(" + e.CommandArgument + "," + PK_Building_ID + ")", true);
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
            ScriptManager.RegisterClientScriptBlock(Page, GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(5);OpenPropertyDetailPopup(" + e.CommandArgument + "," + PK_Building_ID + ")", true);
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
            ScriptManager.RegisterClientScriptBlock(Page, GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(5);OpenPropertyDetailPopup(" + e.CommandArgument + "," + PK_Building_ID + ")", true);
        }
    }

    protected void gvBuildingImprovements_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "ShowDetails")
        {
            Response.Redirect("BuildingImprovements.aspx?build=" + Encryption.Encrypt(Convert.ToString(PK_Building_ID)) + "&id=" + Encryption.Encrypt(Convert.ToString(e.CommandArgument)) + "&op=view");
        }
    }

    protected void gvFinancialLimit_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "ShowDetails")
        {
            Response.Redirect("BuildingFinancilaLimit.aspx?build=" + Encryption.Encrypt(Convert.ToString(PK_Building_ID)) + "&id=" + Encryption.Encrypt(Convert.ToString(e.CommandArgument)) + "&op=view");
        }
    }

    protected void gvGGKL_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "ShowDetails")
        {
            Response.Redirect("Building_GGKL.aspx?build=" + Encryption.Encrypt(Convert.ToString(PK_Building_ID)) + "&id=" + Encryption.Encrypt(Convert.ToString(e.CommandArgument)) + "&op=view");
        }
    }

    #region "Attachment Grids"

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
            strFileName = AppConfig.BuildingAttachDocPath + strFileName;
            // set click attribute to open file on clicking the link
            string strFilePath = Encryption.Encrypt(strFileName).Replace("'", "\\'");
            lnkBuildingAttachFile.Attributes.Add("onclick", "javascript:window.open('" + AppConfig.SiteURL + "/Download.aspx?attachfile=" + strFilePath + "')");
            
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
            strFileName = AppConfig.LeaseSubleaseDocURL + strFileName;           
            string strFilePath = Encryption.Encrypt(strFileName).Replace("'", "\\'");
            lnkLeaseAttachFile.Attributes.Add("onclick", "javascript:window.open('" + AppConfig.SiteURL + "/Download.aspx?attachfile=" + strFilePath + "')");
        }
    }

    /// <summary>
    /// Handles assessment attachment grid rowcommand event
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
            
            string strFilePath = Encryption.Encrypt(strFileName).Replace("'", "\\'");
            lnkFileName.Attributes.Add("onclick", "javascript:window.open('" + AppConfig.SiteURL + "/Download.aspx?attachfile=" + strFilePath + "')");
        }
    }


    #endregion

    #endregion

    #endregion

    #region "Methods"

    #region "BIND OR CLEAR PAGE CONTROLS"
    /// <summary>
    /// Binds details for Page in view mode
    /// </summary>
    private void BindDetailsForView()
    {
        #region " Property COPE info "

        BindLocationInformation();

        // declare object for Proeprty cope
        Property_COPE objProperty = new Property_COPE(Convert.ToDecimal(PK_Property_Cope_ID));
        // set values in page controls
        lblStatus.Text = objProperty.Status;
        lblStatus_As_Of_Date.Text = clsGeneral.FormatDateToDisplay(objProperty.Status_As_Of_Date);
        lblDisposal_Type.Text = objProperty.Disposal_Type;
        if (objProperty.Status == "Disposed") tdDisposal.Style["display"] = "";
        lblUnion_Shop.Text = clsGeneral.FormatYesNoToDisplayForView(objProperty.Union_shop);
        lblProperty_Boundry_Dimension.Text = objProperty.Property_Boundary_Dimemsions;
        lblAddress_1.Text = objProperty.Address_1;
        lblAddress_2.Text = objProperty.Address_2;
        lblCity.Text = objProperty.City;
        lblState.Text = objProperty.State;
        lblZip.Text = objProperty.Zip;
        lblTelephone.Text = objProperty.Telephone;
        lblWeb_Site.Text = objProperty.Web_site;
        //lblValuation_Date.Text = clsGeneral.FormatDateToDisplay(objProperty.Valuation_Date);

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
            decimal decRS_Means_Building_Value = Convert.ToDecimal(drLimits["RS_Means_Building_Value_Total"]);

            //Commented below Section for ticket #3132 
            // set values in finalcial limit section controls
            //lblBuilding_Limit.Text = clsGeneral.GetStringValue(decBuilding_Limit);
            //lblLeasehold_Interests_Limit_Betterment.Text = clsGeneral.GetStringValue(decLeasehold_Interests_Limit_Betterment);
            //lblLeasehold_Interests_Limit_Expansion.Text = clsGeneral.GetStringValue(decLeasehold_Interests_Limit_Expansion);
            //lblAssociate_Tools_Limit.Text = clsGeneral.GetStringValue(decAssociate_Tools_Limit);
            //lblContents_Limit.Text = clsGeneral.GetStringValue(decContents_Limit);
            //lblParts_Limit.Text = clsGeneral.GetStringValue(decParts_Limit);
            //lblBetterment_Date_Complate.Text = clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drLimits["Betterment_Date_Complete"]));
            //lblExpansion_Date_Complate.Text = clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drLimits["Expansion_Date_Complete"]));
            //lblInventory_Levels.Text = clsGeneral.GetStringValue(decInventory_Levels);
            //lblRS_Means_Building_Value_Total.Text = clsGeneral.GetStringValue(decRS_Means_Building_Value);

            //// count and set the total
            //decimal decTotal = decBuilding_Limit + decLeasehold_Interests_Limit_Betterment + decLeasehold_Interests_Limit_Expansion + decAssociate_Tools_Limit + decContents_Limit + decParts_Limit + decInventory_Levels + decRS_Means_Building_Value;
            //lblCalculated.Text = clsGeneral.GetStringValue(decTotal);
            //Commented above Section for ticket #3132
        }

        #endregion

        BindGridBuilding();

        BindBuildingImprovementGrid();

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
        lblLocationRMNumber.Text = Convert.ToString(objLocation.Sonic_Location_Code);
    }

    /// <summary>
    /// Binds building details
    /// </summary>
    private void BindBuildingDetails()
    {
        btnViewAuditBuilding.Visible = true;
        // create object for building
        Building objBuilding = new Building(PK_Building_ID);
        trGuardSystem.Style["display"] = "none";
        trIntrusionAlarms.Style["display"] = "none";
        trFence.Style["display"] = "none";
        trGenerator.Style["display"] = "none";
        trFloodHistory.Style["display"] = "none";
        trPropertyDamageLoss.Style["display"] = "none";
        trNational_Flood_Policy.Style["display"] = "none";
        trSecurityCameras.Style["display"] = "none";
        tblNeighboringOccupancy.Style["display"] = "none";

        #region " Get Building values in page controls "
        lblSecuCam_State.Text = objBuilding.SecuCam_State;
        lblLocationStatus.Text = objBuilding.Location_Status;
        lblGuard_System.Text = clsGeneral.FormatYesNoToDisplayForView(objBuilding.Guard_System);
        if (objBuilding.Guard_System == true)
        {
            lblGuard_System_Name.Text = objBuilding.Guard_System_Name;
            lblGuard_Contact_Name.Text = objBuilding.Guard_Contact_Name;
            lblGuard_Vendor_Name.Text = objBuilding.Guard_Vendor_Name;
            lblGuard_Contact_Expiration_Date.Text = clsGeneral.FormatDateToDisplay(objBuilding.Guard_Contact_Expiration_Date);
            lblGuard_Address_1.Text = objBuilding.Guard_Address_1;
            lblGuard_Address_2.Text = objBuilding.Guard_Address_2;
            lblGuard_City.Text = objBuilding.Guard_City;
            lblGuard_State.Text = objBuilding.Guard_State;
            lblGuard_Zip.Text = objBuilding.Guard_Zip;
            lblGuard_Telephone_Number.Text = objBuilding.Guard_Telephone_Number;
            lblGuard_Alternate_Number.Text = objBuilding.Guard_Alternate_Number;
            lblGuard_Email.Text = objBuilding.Guard_Email;
            lblGuard_Comments.Text = objBuilding.Guard_Comments;
            trGuardSystem.Style["display"] = "";
        }


        lblIntru_System.Text = clsGeneral.FormatYesNoToDisplayForView(objBuilding.Intru_System);
        if (objBuilding.Intru_System == true)
        {
            lblIntru_System_Name.Text = objBuilding.Intru_System_Name;
            lblIntru_Contact_Name.Text = objBuilding.Intru_Contact_Name;
            lblIntru_Vendor_Name.Text = objBuilding.Intru_Vendor_Name;
            lblIntru_Contact_Expiration_Date.Text = clsGeneral.FormatDateToDisplay(objBuilding.Intru_Contact_Expiration_Date);
            lblIntru_Address_1.Text = objBuilding.Intru_Address_1;
            lblIntru_Address_2.Text = objBuilding.Intru_Address_2;
            lblIntru_City.Text = objBuilding.Intru_City;
            lblIntru_State.Text = objBuilding.Intru_State;
            lblIntru_Zip.Text = objBuilding.Intru_Zip;
            lblIntru_Telephone_Number.Text = objBuilding.Intru_Telephone_Number;
            lblIntru_Alternate_Number.Text = objBuilding.Intru_Alternate_Number;
            lblIntru_Email.Text = objBuilding.Intru_Email;
            lblIntru_Comments.Text = objBuilding.Intru_Comments;
            lblIntru_Contact_Alarm_Type.Text = objBuilding.Intru_Contact_Alarm_Type;
            trIntrusionAlarms.Style["display"] = "";
        }

        lblFence.Text = clsGeneral.FormatYesNoToDisplayForView(objBuilding.Fence);
        if (objBuilding.Fence == true)
        {
            lblRazor_Wire.Text = objBuilding.Fence_Razor_Wire ? "Yes" : "";
            lblFence_Electrified.Text = objBuilding.Fence_Electrified ? "Yes" : "";
            trFence.Style["display"] = "";
        }


        lblGenerator.Text = clsGeneral.FormatYesNoToDisplayForView(objBuilding.Generator);
        if (objBuilding.Generator == true)
        {
            lblGenerator_Make.Text = objBuilding.Generator_Make;
            lblGenerator_Model.Text = objBuilding.Generator_Model;
            lblGenerator_Size.Text = objBuilding.Generator_Size;
            trGenerator.Style["display"] = "";
        }


        lblFireDeptType.Text = objBuilding.Fire_Department_Type;
        lblDistance.Text = objBuilding.Fire_Department_Distance;
        lblTier_1_County.Text = clsGeneral.FormatYesNoToDisplayForView(objBuilding.Tier_1_County);
        lblEarthquake_Zone_Fault_Line.Text = clsGeneral.FormatYesNoToDisplayForView(objBuilding.Earthquake_Zone_Fault_Line);
        lblNeighboring_Buildings_within_100_ft.Text = clsGeneral.FormatYesNoToDisplayForView(objBuilding.Neighboring_Buildings_within_100_ft);

        if (objBuilding.Neighboring_Buildings_within_100_ft == true)
        {
            lblNeighbor_Occupancy.Text = objBuilding.Neighbor_Occupancy;
            tblNeighboringOccupancy.Style["display"] = "";
        }

        lblDistance_from_body_of_water.Text = objBuilding.Distance_from_body_of_water;
        lblPrior_Flood_History.Text = clsGeneral.FormatYesNoToDisplayForView(objBuilding.Prior_Flood_History);
        if (objBuilding.Prior_Flood_History == true)
        {
            lblFlood_History_Descr.Text = objBuilding.Flood_History_Descr;
            trFloodHistory.Style["display"] = "";
        }
        lblLowest_finish_floor_elevation.Text = clsGeneral.GetStringValue(objBuilding.Lowest_finish_floor_elevation).Replace(".00", "");
        lblProperty_Damage_Losses_in_the_Past_5_years.Text = clsGeneral.FormatYesNoToDisplayForView(objBuilding.Property_Damage_Losses_in_the_Past_5_years);
        if (objBuilding.Property_Damage_Losses_in_the_Past_5_years == true)
        {
            lblProperty_Loss_Descr.Text = objBuilding.Property_Loss_Descr;
            trPropertyDamageLoss.Style["display"] = "";
        }
        lblFlood_Zone.Text = objBuilding.Flood_Zone;
        lblNational_Flood_Policy.Text = clsGeneral.FormatYesNoToDisplayForView(objBuilding.National_Flood_Policy);
        if (objBuilding.National_Flood_Policy == true)
        {
            lblFlood_Carrier.Text = objBuilding.Flood_Carrier;
            lblFlood_Policy_Number.Text = objBuilding.Flood_Policy_Number;
            lblFlood_Premium.Text = clsGeneral.GetStringValue(objBuilding.Flood_Premium);
            lblFlood_Polciy_Limits_Contents.Text = clsGeneral.GetStringValue(objBuilding.Flood_Polciy_Limits_Contents);
            lblFlood_Policy_Inception_Date.Text = clsGeneral.FormatDateToDisplay(objBuilding.Flood_Policy_Inception_Date);
            lblFlood_Policy_Expiration_Date.Text = clsGeneral.FormatDateToDisplay(objBuilding.Flood_Policy_Expiration_Date);
            lblFlood_Deductible.Text = clsGeneral.GetStringValue(objBuilding.Flood_Deductible);
            lblFlood_Policy_Limits_Building.Text = clsGeneral.GetStringValue(objBuilding.Flood_Policy_Limits_Building);
            trNational_Flood_Policy.Style["display"] = "";
        }

        lblComments.Text = objBuilding.Comments;

        if (!string.IsNullOrEmpty(objBuilding.Ownership))
        {
            switch (objBuilding.Ownership)
            {
                case "Internal": lblOwnership.Text = "Sonic Owned with Internal Lease"; break;
                case "ThirdParty": lblOwnership.Text = "Sonic Owned with Third Party Lease"; break;
                case "Owned": lblOwnership.Text = "Sonic Owned"; break;
                case "ThirdPartyLease": lblOwnership.Text = "Third Party Owned and Sonic Leased"; break;
                case "ThirdPartySublease": lblOwnership.Text = "Third Party Owned and Sonic Leased and Subleased to Third Party"; break;
            }
        }

        if (objBuilding.Ownership == "ThirdParty" || objBuilding.Ownership == "ThirdPartySublease")
        {
            lblLiability.Text = objBuilding.Liability;
            trLiability.Style["display"] = "";
            gridSubLease.Style["display"] = "";
            trgvSubLease.Style["display"] = ""; 
        }
        else
        {
            trLiability.Style["display"] = "none";
            gridSubLease.Style["display"] = "none";
            trgvSubLease.Style["display"] = "none";
        }           

        lblOccupancySalesNew.Text = objBuilding.Occupancy_Sales_New ? "Yes" : "";
        lblOccupancyBodyShop.Text = objBuilding.Occupancy_Body_Shop ? "Yes" : "";
        lblOccupancyParkingLot.Text = objBuilding.Occupancy_Parking_Lot ? "Yes" : "";
        lblOccupancySalesUsed.Text = objBuilding.Occupancy_Sales_Used ? "Yes" : "";
        lblOccupancyParts.Text = objBuilding.Occupancy_Parts ? "Yes" : "";
        lblOccupancyRawLand.Text = objBuilding.Occupancy_Raw_Land ? "Yes" : "";
        lblOccupancyService.Text = objBuilding.Occupancy_Service ? "Yes" : "";
        lblOccupancyOffice.Text = objBuilding.Occupancy_Ofifce ? "Yes" : "";
        lblOccupancyCarWash.Text = objBuilding.Occupancy_Car_Wash ? "Yes" : "";
        lblOccupancyPhotoBooth.Text = objBuilding.Occupancy_Photo_Booth ? "Yes" : "";

        lblBuildingAddress_1.Text = objBuilding.Address_1;
        lblBuildingAddress_2.Text = objBuilding.Address_2;
        lblBuilding_City.Text = objBuilding.City;
        lblBuidingState.Text = objBuilding.State;
        lblBuilding_Zip.Text = objBuilding.Zip;

        //lblFinancial_Building_Limit.Text = clsGeneral.GetStringValue(objBuilding.Building_Limit);
        // lblFinancial_Leasehold_Interests_Limit_Betterment.Text = clsGeneral.GetStringValue(objBuilding.Leasehold_Interests_Limit_Betterment);
        //lblFinancial_Betterment_Date_Complate.Text = clsGeneral.FormatDateToDisplay(objBuilding.Betterment_Date_Complete);
        //lblFinancial_Leasehold_Interests_Limit_Expansion.Text = clsGeneral.GetStringValue(objBuilding.Leasehold_Interests_Limit_Expansion);
        // lblFinancial_Expansion_Date_Complate.Text = clsGeneral.FormatDateToDisplay(objBuilding.Expansion_Date_Complete);
        //lblFinancial_Associate_Tools_Limit.Text = clsGeneral.GetStringValue(objBuilding.Associate_Tools_Limit);
        //lblFinancial_Contents_Limit.Text = clsGeneral.GetStringValue(objBuilding.Contents_Limit);
        //lblFinancial_Parts_Limit.Text = clsGeneral.GetStringValue(objBuilding.Parts_Limit);
        //lblFinancial_Inventory_Levels.Text = clsGeneral.GetStringValue(objBuilding.Inventory_Levels);
        //lblRS_Means_Building_Value.Text = clsGeneral.GetStringValue(objBuilding.RS_Means_Building_Value);

        //decimal decBuildLimit = objBuilding.Building_Limit > 0 ? (decimal)objBuilding.Building_Limit : 0;
        //decimal decBetterment = objBuilding.Leasehold_Interests_Limit_Betterment > 0 ? (decimal)objBuilding.Leasehold_Interests_Limit_Betterment : 0;
        //decimal decExpansion = objBuilding.Leasehold_Interests_Limit_Expansion > 0 ? (decimal)objBuilding.Leasehold_Interests_Limit_Expansion : 0;
        //decimal decToolsLimit = objBuilding.Associate_Tools_Limit > 0 ? (decimal)objBuilding.Associate_Tools_Limit : 0;
        //decimal decContents = objBuilding.Contents_Limit > 0 ? (decimal)objBuilding.Contents_Limit : 0;
        //decimal decPartsLimit = objBuilding.Parts_Limit > 0 ? (decimal)objBuilding.Parts_Limit : 0;
        //decimal decInventory = objBuilding.Inventory_Levels > 0 ? (decimal)objBuilding.Inventory_Levels : 0;
        //decimal decRS_Means_Building_Value = objBuilding.RS_Means_Building_Value > 0 ? (decimal)objBuilding.RS_Means_Building_Value : 0;

        //decimal decTotal = decBuildLimit + decBetterment + decExpansion + decToolsLimit + decContents + decPartsLimit + decInventory + decRS_Means_Building_Value;

        //lblFinancial_Total.Text = clsGeneral.GetStringValue(decTotal);

        lblYear_Built.Text = objBuilding.Year_Built;
        lblSquare_Footage.Text = objBuilding.Square_Footage;
        lblNumber_of_Stories.Text = clsGeneral.GetStringValue(objBuilding.Number_of_Stories);
        lblRoof_Reinforced_Concrete.Text = objBuilding.Roof_Reinforced_Concrete ? "Yes" : "";
        lblRoof_Concrete_Panels.Text = objBuilding.Roof_Concrete_Panels ? "Yes" : "";
        lblRoof_Steel_Deck_With_Fasteners.Text = objBuilding.Roof_Steel_Deck_with_Fasteners ? "Yes" : "";
        lblRoof_Poured_Concrete.Text = objBuilding.Roof_Poured_Concrete ? "Yes" : "";
        lblRoof_Steel_Deck.Text = objBuilding.Roof_Steel_Deck ? "Yes" : "";
        lblRoof_Wood_Joists.Text = objBuilding.Roof_Wood_Joists ? "Yes" : "";
        lblFloors_Reinforced_Concrete.Text = objBuilding.Floors_Reinforced_Concrete ? "Yes" : "";
        lblFloors_Poured_Concrete.Text = objBuilding.Floors_Poured_Concrete ? "Yes" : "";
        lblFloors_Wood_Timber.Text = objBuilding.Floors_Wood_Timber ? "Yes" : "";
        lblExt_Walls_Reinforced_Concrete.Text = objBuilding.Ext_Walls_Reinforced_Concrete ? "Yes" : "";
        lblExt_Walls_Masonry.Text = objBuilding.Ext_Walls_Masonry ? "Yes" : "";
        lblExt_Walls_Corrugated_Metal_Panels.Text = objBuilding.Ext_Walls_Corrugated_Metal_Panels ? "Yes" : "";
        lblExt_Walls_Tilt_up_Concrete.Text = objBuilding.Ext_Walls_Tilt_up_Concrete ? "Yes" : "";
        lblExt_Walls_Glass_and_Steel_Curtain.Text = objBuilding.Ext_Walls_Glass_and_Steel_Curtain ? "Yes" : "";
        lblExt_Walls_Wood_Frame.Text = objBuilding.Ext_Walls_Wood_Frame ? "Yes" : "";
        lblInt_Walls_Masonry_With_Fire_Doors.Text = objBuilding.Int_Walls_Masonry_With_Fire_Doors ? "Yes" : "";
        lblInt_Walls_Masonry_with_Openings.Text = objBuilding.Int_Walls_Masonry_with_Openings ? "Yes" : "";
        lblInt_Walls_No_Interior_Walls.Text = objBuilding.Int_Walls_No_Interior_Walls ? "Yes" : "";
        lblInt_Walls_Masonry.Text = objBuilding.Int_Walls_Masonry ? "Yes" : "";
        lblInt_Walls_Gypsum_Board.Text = objBuilding.Int_Walls_Gypsum_Board ? "Yes" : "";
        lblInt_wall_extend_above_roof.Text = clsGeneral.FormatYesNoToDisplayForView(objBuilding.Int_wall_extend_above_roof);
        lblNumber_of_Paint_Booths.Text = clsGeneral.GetStringValue(objBuilding.Number_of_Paint_Booths).Replace(".00", "");
        lblNumber_of_Lifts.Text = clsGeneral.GetStringValue(objBuilding.Number_of_Lifts).Replace(".00", "");
        lblSales_New_Sprinklered.Text = clsGeneral.GetStringValue(objBuilding.Sales_New_Sprinklered);
        lblSales_Used_Sprinklered.Text = clsGeneral.GetStringValue(objBuilding.Sales_Used_Sprinklered);
        lblService_Sprinklered.Text = clsGeneral.GetStringValue(objBuilding.Service_Sprinklered);
        lblBody_Shop_Sprinklered.Text = clsGeneral.GetStringValue(objBuilding.Body_Shop_Sprinklered);
        lblParts_Sprinklered.Text = clsGeneral.GetStringValue(objBuilding.Parts_Sprinklered);
        lblOffice_Sprinklered.Text = clsGeneral.GetStringValue(objBuilding.Office_Sprinklered);
        lblWater_Public.Text = objBuilding.Water_Public ? "Yes" : "";
        lblWater_Private.Text = objBuilding.Water_Private ? "Yes" : "";
        lblWater_Boosted.Text = objBuilding.Water_Boosted ? "Yes" : "";
        lblDesign_Densities_for_each_area.Text = objBuilding.Design_Densities_for_each_area;
        lblHydrants_within_500_ft.Text = clsGeneral.FormatYesNoToDisplayForView(objBuilding.Hydrants_within_500_ft);
        lblAlarm_UL_Central_Station.Text = objBuilding.Alarm_UL_Central_Station ? "Yes" : "";
        lblAlarm_Constant_Attended.Text = objBuilding.Alarm_Constant_Attended ? "Yes" : "";
        lblAlarm_Sprinkler_Valve_Tamper.Text = objBuilding.Alarm_Sprinkler_Valve_Tamper ? "Yes" : "";
        lblAlarm_Non_UL_Central_Station.Text = objBuilding.Alarm_Non_UL_Central_Station ? "Yes" : "";
        lblAlarm_Local.Text = objBuilding.Alarm_Local ? "Yes" : "";
        lblAlarm_Smoke_Detectors.Text = objBuilding.Alarm_Smoke_Detectors ? "Yes" : "";
        lblAlarm_Proprietary.Text = objBuilding.Alarm_Proprietary ? "Yes" : "";
        lblAlarm_Sprinkler_Waterflow.Text = objBuilding.Alarm_Sprinkler_Waterflow ? "Yes" : "";
        lblAlarm_Dry_Pipe_Air.Text = objBuilding.Alarm_Dry_Pipe_Air ? "Yes" : "";
        lblAlarm_Remote.Text = objBuilding.Alarm_Remote ? "Yes" : "";
        lblAlarm_Fire_Pump_Alarms.Text = objBuilding.Alarm_Fire_Pump_Alarms ? "Yes" : "";
        lblAlarm_Auto_Fire_Alarms.Text = clsGeneral.FormatYesNoToDisplayForView(objBuilding.Alarm_Auto_Fire_Alarms);
        lblAlarm_Security_Cameras.Text = clsGeneral.FormatYesNoToDisplayForView(objBuilding.Alarm_Security_Cameras);

        if (objBuilding.Alarm_Security_Cameras == true)
        {
            lblsecuCam_System.Text = objBuilding.SecuCam_System;
            lblSecuCam_Contact_Name.Text = objBuilding.SecuCam_Contact_Name;
            lblSecuCam_Vendor_Name.Text = objBuilding.SecuCam_Vendor_Name;
            lblSecuCam_Contact_Expiration_Date.Text = clsGeneral.FormatDateToDisplay(objBuilding.SecuCam_Contact_Expiration_Date);
            lblSecuCam_Address_1.Text = objBuilding.SecuCam_Address_1;
            lblSecuCam_Address_2.Text = objBuilding.SecuCam_Address_2;
            lblSecuCam_City.Text = objBuilding.SecuCam_City;
            lblSecuCam_Zip.Text = objBuilding.SecuCam_Zip;
            lblSecuCam_Telephone_Number.Text = objBuilding.SecuCam_Telephone_Number;
            lblSecuCam_Alternate_Number.Text = objBuilding.SecuCam_Alternate_Number;
            lblSecuCam_Email.Text = objBuilding.SecuCam_Email;
            lblSecuCam_Comments.Text = objBuilding.SecuCam_Comments;
            trSecurityCameras.Style["display"] = "";
        }

        lblNumberOfBays.Text = clsGeneral.GetStringValue(objBuilding.Number_of_Bays).Replace(".00", "");
        lblNumberOfLifts.Text = clsGeneral.GetStringValue(objBuilding.Number_of_Lifts_SC).Replace(".00", "");
        lblNumberOfPrepAreas.Text = clsGeneral.GetStringValue(objBuilding.Number_of_Prep_Areas).Replace(".00", "");
        lblNumberOfCarWashStations.Text = clsGeneral.GetStringValue(objBuilding.Number_of_Car_Wash_Stations).Replace(".00", "");

        lblFireContactName.Text = objBuilding.Fire_Contact_Name;
        lblFireVendorName.Text = objBuilding.Fire_Vendor_Name;
        lblFireContactExpiration.Text = clsGeneral.FormatDBNullDateToDisplay_Claim(objBuilding.Fire_Contact_Expiration_Date);
        lblFireAddress1.Text = objBuilding.Fire_Address_1;
        lblFireAddress2.Text = objBuilding.Fire_Address_2;
        lblFireCity.Text = objBuilding.Fire_City;
        lblFireZipCode.Text = objBuilding.Fire_Zip;
        lblFireState.Text = objBuilding.Fire_State;
        lblFireTelephone.Text = objBuilding.Fire_Telephone_Number;
        lblFireAlternateNumber.Text = objBuilding.Fire_Alternate_Number;
        lblFireEmail.Text = objBuilding.Fire_Email;
        lblFireComments.Text = objBuilding.Fire_Comments;

        DataTable dt = Building.SelectByPKLookUp(PK_Building_ID).Tables[0];
        DataRow drFKA = dt.Rows[0];
        lblVoltageSecurity.Text = Convert.ToString(drFKA["FK_LU_Voltage_Security"]);
        lblPowerService.Text = Convert.ToString(drFKA["FK_LU_Power_Service"]);
        lblPhasePower.Text = Convert.ToString(drFKA["FK_LU_Phase_Power"]);
        lblRequiredCableLength.Text = Convert.ToString(drFKA["FK_LU_Cable_Length"]);

        

        lblVoltageSecurityOther.Text = objBuilding.Voltage_Security_Other;
        lblPowerServiceOther.Text = objBuilding.Power_Service_Other;
        lblRequiredCableLengthOther.Text = objBuilding.Cable_Length_Other;
        lblTotalAmperageRequired.Text = objBuilding.Total_Amperage_Required;

        BindBuildingFinancilaLimitGrid();
        
        //BindBuildingGGKLGrid();
        #endregion

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
        trSubLease.Style["display"] = "none";
        trAuditTrail.Style["display"] = "none";
        btnViewAuditOwnership.Visible = true;
        // hide Owned and Leased sections


        // check if Building ID is available
        if (PK_Building_ID > 0)
        {
            // create object for building
            Building objBuilding = new Building(PK_Building_ID);

            // set PK building ownership
            PK_Building_Ownership = Building_Ownership.SelectPKByBuildingID(PK_Building_ID);
            Building_Ownership objOwnership = new Building_Ownership(PK_Building_Ownership);
            lblLandlord_Name.Text = objOwnership.Landlord_Name;
            lblLandlord_Address_1.Text = objOwnership.Landlord_Address_1;
            lblLandlord_Address_2.Text = objOwnership.Landlord_Address_2;
            lblLandlord_City.Text = objOwnership.Landlord_City;
            lblLandlord_State.Text = objOwnership.Landlord_State;
            lblLandlord_Zip.Text = objOwnership.Landlord_Zip;
            lblLease_ID.Text = objOwnership.Lease_ID;
            lblLandlordLegalEntity.Text = objOwnership.Landlord_Legal_Entity;
            if (objBuilding.Number_Of_Parking_Spaces != null) lblNumber_Of_Parking_Spaces.Text = string.Format("{0:N0}", objBuilding.Number_Of_Parking_Spaces);
            if (objBuilding.Acreage != null) lblAcreage.Text = Convert.ToDecimal(objBuilding.Acreage).ToString("N3").Replace("$", "");

            lblCommencement_Date.Text = clsGeneral.FormatDateToDisplay(objOwnership.Commencement_Date);
            lblExpiration_Date.Text = clsGeneral.FormatDateToDisplay(objOwnership.Expiration_Date);

            //if (objBuilding.Ownership == "ThirdParty" || objBuilding.Ownership == "ThirdPartySublease")
            //{
            //    lblSubLease_Name.Text = objOwnership.Sublease_Name;
            //    lblSublandlord.Text = objOwnership.SubLandlord;
            //    lblSublease_Address_1.Text = objOwnership.Sublease_Address_1;
            //    lblSublease_Address_2.Text = objOwnership.Sublease_Address_2;
            //    lblSublease_City.Text = objOwnership.Sublease_City;
            //    if (objOwnership.Sublease_State != null) lblSublease_State.Text = objOwnership.Sublease_State;
            //    lblSublease_Zip.Text = objOwnership.Sublease_Zip;
            //    trSubLease.Style["display"] = "";
            //    lblSubLeaseFirstName.Text = objOwnership.Sublease_FirstName;
            //    lblSubLeaseLastName.Text = objOwnership.Sublease_LastName;
            //    lblSubLeaseTitle.Text = objOwnership.Sublease_Title;
            //    lblSubLeasePhone.Text = objOwnership.Sublease_Phone;
            //    lblSubLeaseFax.Text = objOwnership.Sublease_Fax;
            //    lblSubLeaseEmail.Text = objOwnership.Sublease_Email;
            //}

            if (objBuilding.Ownership == "ThirdPartyLease" || objBuilding.Ownership == "ThirdPartySublease" || objBuilding.Ownership == "Internal")
            {
                lblCOI_Wording.Text = objOwnership.COI_Wording;
                lblREQWC.Text = objOwnership.REQ_WC ? "Yes" : "";
                lblREQEL.Text = objOwnership.REQ_EL ? "Yes" : "";
                lblREQGL.Text = objOwnership.REQ_GL ? "Yes" : "";
                lblREQPollution.Text = objOwnership.REQ_Pollution ? "Yes" : "";
                lblREQProperty.Text = objOwnership.REQ_Property ? "Yes" : "";
                lblREQFlood.Text = objOwnership.REQ_Flood ? "Yes" : "";
                lblREQEQ.Text = objOwnership.REQ_EQ ? "Yes" : "";
                lblREQWaiver.Text = objOwnership.REQ_WaiverofSubrogation ? "Yes" : "";
                lblWCTenant.Text = objOwnership.SubResponsible_WC ? "Yes" : "";
                lblELTenant.Text = objOwnership.SubResponsible_EL ? "Yes" : "";
                lblGLTenant.Text = objOwnership.SubResponsible_GL ? "Yes" : "";
                lblPollutionTenant.Text = objOwnership.SubResponsible_Pollution ? "Yes" : "";
                lblPropertyTenant.Text = objOwnership.SubResponsible_Property ? "Yes" : "";
                lblFloodTenant.Text = objOwnership.SubResponsible_Flood ? "Yes" : "";
                lblEQTenant.Text = objOwnership.EQ ? "Yes" : "";
                lblWaiverTenant.Text = objOwnership.WaiverofSubrogation ? "Yes" : "";


                // set the COI link 
                lnkCOI_WC.Text = objOwnership.COI_WC == "" ? "" : FormatCOIFileName(objOwnership.COI_WC);
                lnkCOI_EL.Text = objOwnership.COI_EL == "" ? "" : FormatCOIFileName(objOwnership.COI_EL);
                lnkCOI_GL.Text = objOwnership.COI_GL == "" ? "" : FormatCOIFileName(objOwnership.COI_GL);
                lnkCOI_Pollution.Text = objOwnership.COI_Pollution == "" ? "" : FormatCOIFileName(objOwnership.COI_Pollution);
                lnkCOI_Property.Text = objOwnership.COI_Property == "" ? "" : FormatCOIFileName(objOwnership.COI_Property);
                lnkCOI_Flood.Text = objOwnership.COI_Flood == "" ? "" : FormatCOIFileName(objOwnership.COI_Flood);
                lnkCOI_EQ.Text = objOwnership.COI_EQ == "" ? "" : FormatCOIFileName(objOwnership.COI_EQ);
                lnkCOI_Waiver.Text = objOwnership.COI_WaiverofSubrogation == "" ? "" : FormatCOIFileName(objOwnership.COI_WaiverofSubrogation);

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

                // show or hide the limits if Insurance requirements are checked
                tblWCLimit.Style["display"] = objOwnership.REQ_WC ? "" : "none";
                tblELLimit.Style["display"] = objOwnership.REQ_EL ? "" : "none";
                tblGLLimit.Style["display"] = objOwnership.REQ_GL ? "" : "none";
                tblPollutionLimit.Style["display"] = objOwnership.REQ_Pollution ? "" : "none";
                tblPropertyLimit.Style["display"] = objOwnership.REQ_Property ? "" : "none";
                tblFloodLimit.Style["display"] = objOwnership.REQ_Flood ? "" : "none";
                tblEQLimit.Style["display"] = objOwnership.REQ_EQ ? "" : "none";
                tblWaiverLimit.Style["display"] = objOwnership.REQ_WaiverofSubrogation ? "" : "none";

                // set limits
                lblReqLim_WC.Text = clsGeneral.GetStringValue(objOwnership.ReqLim_WC) + "&nbsp;";
                lblReqLim_EL.Text = clsGeneral.GetStringValue(objOwnership.ReqLim_EL) + "&nbsp;";
                lblReqLim_GL.Text = clsGeneral.GetStringValue(objOwnership.ReqLim_GL) + "&nbsp;";
                lblReqLim_Pollution.Text = clsGeneral.GetStringValue(objOwnership.ReqLim_Pollution) + "&nbsp;";
                lblReqLim_Property.Text = clsGeneral.GetStringValue(objOwnership.ReqLim_Property) + "&nbsp;";
                lblReqLim_Flood.Text = clsGeneral.GetStringValue(objOwnership.ReqLim_Flood) + "&nbsp;";
                lblReqLim_EQ.Text = clsGeneral.GetStringValue(objOwnership.ReqLim_EQ) + "&nbsp;";
                lblReqLim_Waiver.Text = clsGeneral.GetStringValue(objOwnership.ReqLim_WaiverofSubrogation) + "&nbsp;";
            }
            btnViewOwnerShip.Visible = true;
        }
        else
        {
            btnViewOwnerShip.Visible = false;
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
        lblAdditional_Insureds_Named.Text = objInsuredPayee.Named;
        lblAdditional_Insureds_Address_1.Text = objInsuredPayee.Address_1;
        lblAdditional_Insureds_Address_2.Text = objInsuredPayee.Address_2;
        lblAdditional_Insureds_City.Text = objInsuredPayee.City;
        lblAdditional_Insureds_State.Text = objInsuredPayee.State;
        lblAdditional_Insureds_Zip.Text = objInsuredPayee.Zip;

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
        lblLoss_Payees_Named.Text = objInsuredPayee.Named;
        lblLoss_Payees_Address_1.Text = objInsuredPayee.Address_1;
        lblLoss_Payees_Address_2.Text = objInsuredPayee.Address_2;
        lblLoss_Payees_City.Text = objInsuredPayee.City;
        lblLoss_Payees_State.Text = objInsuredPayee.State;
        lblLoss_Payees_Zip.Text = objInsuredPayee.Zip;
        lblLoss_Payees_Type.Text = objInsuredPayee.Type;

        // bind payee grid
        BindGridPayees();
        trNamedLossPayees.Style["display"] = "";
    }


    /// <summary>
    /// Binds Building Owner SubLeaseDetail details
    /// </summary>
    private void BindSubLeaseDetail()
    {
        //btnViewAuditLossPayee.Style["Display"] = "";
        // create object for Insured payee
        Building ObjBuilding = new Building(PK_Building_ID);
        clsBuilding_Ownership_Sublease objclsBuilding_Ownership_Sublease = new clsBuilding_Ownership_Sublease(PK_Building_OwnershipSubLease);
        if (ObjBuilding.Ownership == "ThirdParty" || ObjBuilding.Ownership == "ThirdPartySublease")
        {
            // set values in page controls
            lblSubLease_Name.Text = objclsBuilding_Ownership_Sublease.Sublease_Name;
            lblSublease_Address_1.Text = objclsBuilding_Ownership_Sublease.Sublease_Address_1;
            lblSublease_Address_2.Text = objclsBuilding_Ownership_Sublease.Sublease_Address_2;
            lblSublease_City.Text = objclsBuilding_Ownership_Sublease.Sublease_City;
            lblSublease_State.Text = objclsBuilding_Ownership_Sublease.Sublease_State;
            lblSublease_Zip.Text = objclsBuilding_Ownership_Sublease.Sublease_Zip;
            lblSublandlord.Text = objclsBuilding_Ownership_Sublease.SubLease_Landlord;
            lblSubLeaseFirstName.Text = objclsBuilding_Ownership_Sublease.Sublease_FirstName;
            lblSubLeaseLastName.Text = objclsBuilding_Ownership_Sublease.Sublease_LastName;
            lblSubLeaseTitle.Text = objclsBuilding_Ownership_Sublease.Sublease_Title;
            lblSubLeasePhone.Text = objclsBuilding_Ownership_Sublease.Sublease_Phone;
            lblSubLeaseFax.Text = objclsBuilding_Ownership_Sublease.Sublease_Fax;
            lblSubLeaseEmail.Text = objclsBuilding_Ownership_Sublease.Sublease_Email;

            // bind Sub Lease Grid
            BindSubLeaseGrid();
            trSubLease.Style["display"] = "";
            trAuditTrail.Style["display"] = "";
        }
    }

    /// <summary>
    /// Binds Contacts details
    /// </summary>
    private void BindContactsDetails()
    {
        btnViewAuditContacts.Visible = true;
        // create object for contact
        Property_Contact objContact = new Property_Contact(PK_Property_Contact_ID);

        DataTable dtState = State.SelectByPK(objContact.FK_Fire_Alarm_Monitoring_State).Tables[0];
        if (dtState.Rows.Count > 0)
        {
            DataRow drFKA = dtState.Rows[0];
            lblContactState.Text = Convert.ToString(drFKA["Fld_State"]);
        }
        else
        {
            lblContactState.Text = string.Empty;
        }

        // set values in page controls
        lblName.Text = objContact.Name;
        lblPhone.Text = objContact.Phone;
        lblCell_Phone.Text = objContact.Cell_Phone;
        lblAfter_Hours_Contact_Name.Text = objContact.After_Hours_Contact_Name;
        lblAfter_Hours_Contact_Phone.Text = objContact.After_Hours_Contact_Phone;
        lblAfter_Hours_Contact_Cell_Phone.Text = objContact.After_Hours_Contact_Cell_Phone;

        lblCompanyName.Text = objContact.Fire_Alarm_Monitoring_Company_Name; ;
        lblContactName.Text = objContact.Fire_Alarm_Monitoring_Contact_Name;
        lblAddress.Text = objContact.Fire_Alarm_Monitoring_Address;
        lblCity1.Text = objContact.Fire_Alarm_Monitoring_City;
        lblZipCode.Text = objContact.Fire_Alarm_Monitoring_Zip_Code;
        lblTelephone1.Text = objContact.Fire_Alarm_Monitoring_Telephone;
        lblAccountNumber.Text = objContact.Fire_Alarm_Monitoring_Account_Number;
        lblMonthlyMonitoringAmount.Text = clsGeneral.FormatCommaSeperatorCurrency(objContact.Fire_Alarm_Monitoring_Monthly_Amount);
        lblControlPanel.Text = objContact.Fire_Alarm_Monitoring_Control_Panel;

        // bind emergency, utility and other contact grid
        BindEmergencyContactGrid();
        BindUtilityContactGrid();
        BindOtherContactGrid();
    }

    #endregion

    #region "GRIDS BINDING"

    /// <summary>
    /// Binds grid business interruption grid in Property cope panel
    /// </summary>
    private void BindGridBusinessInterruption()
    {
        //Commented above Section for ticket #3132
        //DataTable dtBusinessInterruption = Property_COI.SelectByLocation(FK_LU_Location_ID).Tables[0];
        //gvBusinessInterruption.DataSource = dtBusinessInterruption;
        //gvBusinessInterruption.DataBind();
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
        DataTable dtImprovements = Building_Improvements.SelectByFK_Property_Cope(PK_Property_Cope_ID).Tables[0];
        gvBuildingImprovements.DataSource = dtImprovements;
        gvBuildingImprovements.DataBind();
    }

    private void BindBuildingFinancilaLimitGrid()
    {
        DataTable dtFinancialLimit = Building_Financial_Limits.SelectByFK(PK_Building_ID).Tables[0];
        gvFinancialLimit.DataSource = dtFinancialLimit;
        gvFinancialLimit.DataBind();
    }

    //private void BindBuildingGGKLGrid()
    //{
    //    DataTable dtGGKL = Building_GGKL.SelectByFK(PK_Building_ID).Tables[0];
    //    gvGGKL.DataSource = dtGGKL;
    //    gvGGKL.DataBind();
    //}

    /// <summary>
    /// Binds Grid For Building Owner Sublease
    /// </summary>
    private void BindSubLeaseGrid()
    {
        DataTable dtSubLeaseGrid = clsBuilding_Ownership_Sublease.SelectByFK(PK_Building_Ownership).Tables[0];
        gvSubLease.DataSource = dtSubLeaseGrid;
        gvSubLease.DataBind();
    }
    #endregion

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

    #region "Insurance Cope"

    private void SetDynamicInsuranceControl()
    {
        ERIMS.DAL.Building_Insurance_COPE_Descriptors objInsuranceCope = new Building_Insurance_COPE_Descriptors();
        DataSet objDs = ERIMS.DAL.Building_Insurance_COPE_Descriptors.GetActiveBuildingInsuranceCOPEDescriptors();
        if (objDs != null && objDs.Tables.Count > 0 && objDs.Tables[0].Rows.Count > 0)
        {
            HtmlTableRow tr = new HtmlTableRow();
            HtmlTableCell tc;

            bool blnAddBlanktd = false;

            if (objDs.Tables[0].Rows.Count == 1)
                blnAddBlanktd = true;

            int intCnt = 1;
            for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
            {
                if (intCnt == 1)
                    tr = new HtmlTableRow();

                if (i % 2 == 1 )
                {
                    tc = new HtmlTableCell();
                    tc.NoWrap = false;
                    tc.Width = "18%";
                    tc.Align = "left";
                    tc.VAlign = "top";
                    tc.Style.Add("padding-left", "9px");

                    Label lbl = new Label();
                    lbl.ID = "Lbl_Item_" + Convert.ToString(objDs.Tables[0].Rows[i]["Item_Number"]);
                    lbl.Width = Unit.Pixel(130);
                    lbl.Text = Convert.ToString(objDs.Tables[0].Rows[i]["Item_Descriptor"]);
                    tc.Controls.Add(lbl);
                }
                else
                {
                    tc = new HtmlTableCell();
                    tc.NoWrap = false;
                    tc.Width = "18%";
                    tc.Align = "left";
                    tc.VAlign = "top";

                    Label lbl = new Label();
                    lbl.ID = "Lbl_Item_" + Convert.ToString(objDs.Tables[0].Rows[i]["Item_Number"]);
                    lbl.Width = Unit.Pixel(146);
                    lbl.Text = Convert.ToString(objDs.Tables[0].Rows[i]["Item_Descriptor"]);
                    tc.Controls.Add(lbl);
                }
                

                //tc.InnerHtml = objDs.Tables[0].Rows[i]["Item_Descriptor"].ToString();

                //if (objDs.Tables[0].Rows[i]["Mandatory"].ToString() == "Y")
                //{
                //    //tc.InnerHtml = " <span id='span'" + Convert.ToString(objDs.Tables[0].Rows[i]["Item_Number"]) + "' style='color: Red;'>*</span>";
                //    lbl.Text += " <span id='span'" + Convert.ToString(objDs.Tables[0].Rows[i]["Item_Number"]) + "' style='color: Red;'>*</span>";
                //}
                tr.Controls.Add(tc);

                tc = new HtmlTableCell();
                tc.Width = "4%";
                tc.Align = "center";
                Label lbl_colon = new Label();
                lbl_colon.ID = "Lbl_colon_" + Convert.ToString(objDs.Tables[0].Rows[i]["Item_Number"]);
                lbl_colon.Width = Unit.Pixel(31);
                lbl_colon.Text = ":";
                tc.Controls.Add(lbl_colon);
                tc.VAlign = "top";
                tr.Controls.Add(tc);
                                

                tc = new HtmlTableCell();
                tc.Width = "28%";
                tc.Align = "left";
                tc.VAlign = "top";
                Label lblValue = new Label();
                lblValue.ID = "Item_" + Convert.ToString(objDs.Tables[0].Rows[i]["Item_Number"]);
                lblValue.Width = Unit.Pixel(170);
                tc.NoWrap = false;
                tc.Controls.Add(lblValue);

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

    private void BindInuranceDetailForView(int Fk_Building)
    {
        DataSet objDs = Building.BuildingInsuranceCOPESelect(Fk_Building);
        if (objDs != null && objDs.Tables.Count > 0 && objDs.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < 25; i++)
            {
                //Label lblField = pnlInsuranceCope.FindControl("Item_" + (i + 1)) as Label;
                Label lblField = tblInsurance.FindControl("Item_" + (i + 1)) as Label;                
                if (lblField != null)
                {
                    lblField.Text = Convert.ToString(objDs.Tables[0].Rows[0]["Item_" + (i + 1)]);
                }
            }
        }
    }

    #endregion

    #endregion

    
}
