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


/// </summary>
public partial class SONIC_DPDClaimInfo : clsBasePage
{
    #region Private Variable and Property

    /// <summary>
    /// Denotes the PK DPD Claim ID
    /// </summary>
    public int PK_DPD_Claims_ID
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_DPD_Claims_ID"]);
        }
        set { ViewState["PK_DPD_Claims_ID"] = value; }
    }

    /// <summary>
    /// Denotes first report number
    /// </summary>
    public decimal First_Report_Number
    {
        get
        {
            return clsGeneral.IsNull(ViewState["First_Report_Number"]) ? 0 : Convert.ToDecimal(ViewState["First_Report_Number"]);
        }
        set
        {
            ViewState["First_Report_Number"] = value;
        }
    }

    #endregion

    #region Page Events

    /// <summary>
    /// Handles event when page is loaded
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        //Set Tab selection
        ClaimTab.SetSelectedTab(Controls_ClaimTab_ClaimTab.Tab.DPD);
        //CtrlAttachment_Cliam.btnHandler += new Controls_ClaimAttachment_Attachment.OnButtonClick(Upload_File);
        //used to check Page Post Back Event
        if (!IsPostBack)
        {
            #region General
            // check claim id is passed in querystring or not.
            if (Request.QueryString["id"] != null && Request.QueryString["id"] != string.Empty)
            {
                try
                {
                    //Get claim id from query string and store in viewstate.   
                    PK_DPD_Claims_ID = (int)clsGeneral.GetQueryStringID(Convert.ToString(Request.QueryString["id"]));
                    clsSession.ClaimID_Diary = Request.QueryString["id"].ToString();
                    FillControls();
                }
                catch
                {
                    Response.Redirect("DPDClaimInfo.aspx");
                }
            }
            else
            {
                //Response.Redirect("DPDClaimInfo.aspx");
            }

            #endregion

            gvAddress.DataSource = DPD_ClaimInfo.SelectViewClaimAddresses(PK_DPD_Claims_ID);
            gvAddress.DataBind();

            gvDPDIncidentsGrid.DataSource = DPD_ClaimInfo.SelectViewClaimIncidentsByPK(PK_DPD_Claims_ID);
            gvDPDIncidentsGrid.DataBind();

            DataSet dsDPDClaims = DPD_ClaimInfo.SelectByPK(PK_DPD_Claims_ID);
            DataTable dtDPDClaims = dsDPDClaims.Tables[0];

            if (dtDPDClaims.Rows.Count > 0)
            {
                DataRow drDPD_Claims = dtDPDClaims.Rows[0];
                lblDateofLoss.Text = drDPD_Claims["Date_Of_Loss"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drDPD_Claims["Date_Of_Loss"].ToString()));

                ucAdjusterNotes.ClaimID = PK_DPD_Claims_ID;
                ucAdjusterNotes.ClaimNumber = Convert.ToString(drDPD_Claims["Origin_Claim_Number"]);
                ucAdjusterNotes.BindGridNotes(ucAdjusterNotes.ClaimNumber);

                //Set the first panel active
                int intPanle = 1;
                if (int.TryParse(Convert.ToString(Request.QueryString["pnl"]), out intPanle))
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(" + intPanle.ToString() + ");", true);
                else
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(1);", true);
            }
        }
    }
    #endregion

    #region Controls Events
    /// <summary>
    /// Handles click event for Associated First report link in header
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkAssociatedFirstReport_Click(object sender, EventArgs e)
    {
        //Get the details of Associated first report from the report number.
        DataSet dsDPDFirstReport = DPD_FR.SelectByDPD_FR_Number(First_Report_Number);   

        //Check First report found or not
        if (dsDPDFirstReport.Tables[0].Rows.Count > 0)
        {
            //set the wizard id in session
            clsSession.First_Report_Wizard_ID = Convert.ToInt32(dsDPDFirstReport.Tables[0].Rows[0]["FK_First_Report_Wizard_ID"]);

            //redirect to the DPD first report page
            Response.Redirect("../FirstReport/DPDFirstReport.aspx?id=" + Encryption.Encrypt(dsDPDFirstReport.Tables[0].Rows[0]["PK_DPD_FR_ID"].ToString()));
        }
        else
            Response.Redirect("ClaimInformationSearch.aspx");
    }

    
    /// <summary>
    /// Used to upload file
    /// </summary>
    /// <param name="strValue"></param>
    protected void Upload_File(string strValue)
    {
        //Insert values into AL_FR_Attachment table
        //CtrlAttachment_Cliam.Add(clsGeneral.Tables.DPDClaim, PK_DPD_Claims_ID);
        // Used to Bind Grid with Attached Data
        //CtlAttachDetail_Cliam.Bind();
        Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(5);", true);
    }

    /// <summary>
    /// Handles Add link click event for notes grid
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnNotesAdd_Click(object sender, EventArgs e)
    {
        // redirect to claim notes page
        Response.Redirect("ClaimNotes.aspx?FK_Claim=" + Encryption.Encrypt(PK_DPD_Claims_ID.ToString()) + "&tbl=" + clsGeneral.Claim_Tables.DPDClaim.ToString());
    }

    protected void btnBackToGrid_Click(object sender, EventArgs e)
    {
        string str = "<script>javascript:ShowPanel('2');</script>";
        Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", str, false);
        pnlAddressesGrid.Visible = true;
        pnlAddressesView.Visible = false;
    }    

   
    #endregion



    #region Private Methods

    /// <summary>
    /// Function to Bind the DPD Claim Information
    /// </summary>
    protected void FillControls()
    {
        // get data for DPD claim 
        DataSet dsDPD_Claims = DPD_ClaimInfo.SelectViewClaim(PK_DPD_Claims_ID);

        // get data
        DataTable dtDPD_Claims = dsDPD_Claims.Tables[0];
        // if data is available
        if (dtDPD_Claims.Rows.Count > 0)
        {

            DataRow drDPD_Claims = dtDPD_Claims.Rows[0];

            lblClaimNumber.Text = Convert.ToString(drDPD_Claims["Origin_Claim_Number"]);
            lblLocationdba.Text = Convert.ToString(drDPD_Claims["dba1"]);
            lblDateLoss.Text = drDPD_Claims["Date_Of_Loss"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drDPD_Claims["Date_Of_Loss"].ToString()));
            lnkAssociatedFirstReport.Text = Convert.ToString(drDPD_Claims["DPD_FR_Number"]);
            if (!string.IsNullOrEmpty(lnkAssociatedFirstReport.Text.Trim()))
                lnkAssociatedFirstReport.Text = "DPD-" + lnkAssociatedFirstReport.Text;
            decimal _FR_Number;
            if (decimal.TryParse(Convert.ToString(drDPD_Claims["DPD_FR_Number"]), out _FR_Number))
                First_Report_Number = _FR_Number;
            lblDateofLoss.Text = drDPD_Claims["Date_Of_Loss"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drDPD_Claims["Date_Of_Loss"].ToString()));
            lblTimeofLoss.Text = Convert.ToString(clsGeneral.FormatTimeToDisplay(drDPD_Claims["Time_Of_Loss"]));
            lblDescriptionofLoss.Text = Convert.ToString(drDPD_Claims["Description_Of_Loss"]);
            lblLineType.Text = Convert.ToString(drDPD_Claims["Line_Type"]);
            lblClaimType.Text = Convert.ToString(drDPD_Claims["Claim_Type"]);
            lblClaimSubType.Text = Convert.ToString(drDPD_Claims["Claim_SubType"]);
            lblClaimStatus.Text = Convert.ToString(drDPD_Claims["Claim_Status"]);
            lblClaimSubStatus.Text = Convert.ToString(drDPD_Claims["Claim_SubStatus"]);
            lblDateReportedtoSonic.Text = drDPD_Claims["Date_Reported_To_Sonic"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drDPD_Claims["Date_Reported_To_Sonic"].ToString()));
            lblDateOpened.Text = drDPD_Claims["Date_Opened"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drDPD_Claims["Date_Opened"].ToString()));
            lblDateClosed.Text = drDPD_Claims["Date_Closed"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drDPD_Claims["Date_Closed"].ToString()));
            lblDateReOpened.Text = drDPD_Claims["Date_Reopened"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drDPD_Claims["Date_Reopened"].ToString()));
            lblState.Text = Convert.ToString(drDPD_Claims["State"]);
            lblLossLocationAddress.Text = Convert.ToString(drDPD_Claims["Loss_Location_Address"]);
            lblCity.Text = Convert.ToString(drDPD_Claims["Loss_Location_City"]);
            lblZip.Text = Convert.ToString(drDPD_Claims["Loss_Location_Zip_Code"]);
            lblVIN.Text = Convert.ToString(drDPD_Claims["VIN"]);
            lblVehicleMake.Text = Convert.ToString(drDPD_Claims["Vehicle_Make"]);
            lblVehicleModel.Text = Convert.ToString(drDPD_Claims["Vehicle_Model"]);
            lblVehicleYear.Text = Convert.ToString(drDPD_Claims["Vehicle_Year"]);
            lblDriverName.Text = Convert.ToString(drDPD_Claims["Driver_Name"]);
            lblClaimantTelephoneNumber.Text = Convert.ToString(drDPD_Claims["Claimant_Telephone_Number"]);
            lblClaimantFirstName.Text = Convert.ToString(drDPD_Claims["Claimant_First_Name"]);
            lblClaimantLastName.Text = Convert.ToString(drDPD_Claims["Claimant_Last_Name"]);
            lblEmployeeName.Text = Convert.ToString(drDPD_Claims["Employee_Name"]);
            lblEmployeeAddress.Text = Convert.ToString(drDPD_Claims["Employee_Street"]);
            lblEmployeeCity.Text = Convert.ToString(drDPD_Claims["Employee_City"]);
            lblEmployeeState.Text = Convert.ToString(drDPD_Claims["Employee_State"]);
            lblEmployeeZip.Text = Convert.ToString(drDPD_Claims["Employee_Zip"]);
            lblEmployeeGender.Text = Convert.ToString(drDPD_Claims["Employee_Gender"]);
            lblEmployeeSSN.Text = Convert.ToString(drDPD_Claims["Employee_SSN"]);
            lblEmployeeMaritalStatus.Text = Convert.ToString(drDPD_Claims["Marital_Status"]);
            lblEmployeeDOB.Text = drDPD_Claims["Employee_Date_Of_Birth"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drDPD_Claims["Employee_Date_Of_Birth"].ToString()));
            lblStateofAccident.Text = Convert.ToString(drDPD_Claims["State_of_Accident"]);
            lblStateofJurisdiction.Text = Convert.ToString(drDPD_Claims["State_of_Jurisdiction"]);
            lblDateReportedtoInsurer.Text = drDPD_Claims["Date_Reported_To_Insurer"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drDPD_Claims["Date_Reported_To_Insurer"].ToString()));
            lblDateEntered.Text = drDPD_Claims["Date_Entered"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drDPD_Claims["Date_Entered"].ToString()));
            lblCoverageCode.Text = Convert.ToString(drDPD_Claims["CoverageCode"]);
            lblLineofCoverage.Text = Convert.ToString(drDPD_Claims["Line_of_Coverage"]);
            lblDateSuitFiled.Text = drDPD_Claims["Date_Suit_Filed"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drDPD_Claims["Date_Suit_Filed"].ToString()));
            lblLitigationYN.Text = Convert.ToString(drDPD_Claims["LitigationYN"]);
            lblSRSPolicyNumber.Text = Convert.ToString(drDPD_Claims["SRS_Policy_Number"]);
            lblPolicyEffectiveDate.Text = drDPD_Claims["Policy_Effective_Date"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drDPD_Claims["Policy_Effective_Date"].ToString()));
            lblPolicyExpirationDate.Text = drDPD_Claims["Policy_Expiration_Date"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drDPD_Claims["Policy_Expiration_Date"].ToString()));
            lblLossGrossPaid.Text = drDPD_Claims["Loss_Gross_Paid"] == DBNull.Value ? "" : String.Format("$ {0:N2}", Convert.ToDecimal(drDPD_Claims["Loss_Gross_Paid"]));
            //lblLossGrossPaid.Text = Convert.ToString(Convert.ToDecimal(drDPD_Claims["Loss_Gross_Paid"]));
            lblLossNetRecovered.Text = drDPD_Claims["Loss_Net_Recovered"] == DBNull.Value ? "" : String.Format("$ {0:N2}", Convert.ToDecimal(drDPD_Claims["Loss_Net_Recovered"]));
            lblLossIncurred.Text = drDPD_Claims["Loss_Incurred"] == DBNull.Value ? "" : String.Format("$ {0:N2}", Convert.ToDecimal(drDPD_Claims["Loss_Incurred"]));
            lblLossOutstanding.Text = drDPD_Claims["Loss_Outstanding"] == DBNull.Value ? "" : String.Format("$ {0:N2}", Convert.ToDecimal(drDPD_Claims["Loss_Outstanding"]));
            lblExpenseGrossPaid.Text = drDPD_Claims["Expense_Gross_Paid"] == DBNull.Value ? "" : String.Format("$ {0:N2}", Convert.ToDecimal(drDPD_Claims["Expense_Gross_Paid"]));
            lblExpenseNetRecovered.Text = drDPD_Claims["Expense_Net_Recovered"] == DBNull.Value ? "" : String.Format("$ {0:N2}", Convert.ToDecimal(drDPD_Claims["Expense_Net_Recovered"]));
            lblExpenseIncurred.Text = drDPD_Claims["Expense_incurred"] == DBNull.Value ? "" : String.Format("$ {0:N2}", Convert.ToDecimal(drDPD_Claims["Expense_incurred"]));
            lblExpenseOutstanding.Text = drDPD_Claims["Expense_Outstanding"] == DBNull.Value ? "" : String.Format("$ {0:N2}", Convert.ToDecimal(drDPD_Claims["Expense_Outstanding"]));
            lblMedicalGrossPaid.Text = drDPD_Claims["Medical_Gross_Paid"] == DBNull.Value ? "" : String.Format("$ {0:N2}", Convert.ToDecimal(drDPD_Claims["Medical_Gross_Paid"])); Convert.ToString(drDPD_Claims["Medical_Gross_Paid"]);
            lblAccidentCityTown.Text = Convert.ToString(drDPD_Claims["Accident_City_Town"]);
            lblClaimsMadeIndicator.Text = Convert.ToString(drDPD_Claims["claims_made_indicator"]);
            lblClaimsMadeDate.Text = drDPD_Claims["claims_made_date"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drDPD_Claims["claims_made_date"].ToString()));
            lblRetroactiveDate.Text = drDPD_Claims["retroactive_date"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drDPD_Claims["retroactive_date"].ToString()));
            lblCauseofInjuryCode.Text = Convert.ToString(drDPD_Claims["cause_Of_Injury_code"]);
            lblDriverAge.Text = Convert.ToString(drDPD_Claims["driver_age"]);
            lblDriverGender.Text = Convert.ToString(drDPD_Claims["driver_Gender"]);
            lblAdjustorCode.Text = Convert.ToString(drDPD_Claims["Adjustor_Code"]);
            lblDateUpdated.Text = drDPD_Claims["Date_Updated"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drDPD_Claims["Date_Updated"].ToString()));

        }

        DataSet dsDPD_ClaimsDetails = DPD_ClaimInfo.SelectViewClaimDetailsByPK(PK_DPD_Claims_ID);

        // get data
        DataTable dtDPD_ClaimsDetails = dsDPD_ClaimsDetails.Tables[0];
        // if data is available
        if (dtDPD_ClaimsDetails.Rows.Count > 0)
        {
            DataRow drDPD_ClaimsDetails = dtDPD_ClaimsDetails.Rows[0];

            lblContactName.Text = Convert.ToString(drDPD_ClaimsDetails["Contact_Home_Phone"]);
            lblContactHomePhone.Text = Convert.ToString(drDPD_ClaimsDetails["Contact_Home_Phone"]);
            lblReportNumber.Text = Convert.ToString(drDPD_ClaimsDetails["Report_Number"]);
            lblLossDamageEstimate.Text = Convert.ToString(drDPD_ClaimsDetails["Loss_Damage_Estimate"]);
            lblOwnerManufacturerName.Text = Convert.ToString(drDPD_ClaimsDetails["Owner_Manufacturer_Name"]);
            lblOwnerManufacturerAddress.Text = Convert.ToString(drDPD_ClaimsDetails["Owner_Manufacturer_Address"]);
            lblOwnerManufacturerCity.Text = Convert.ToString(drDPD_ClaimsDetails["Owner_Manufacturer_City"]);
            lblOwnerManufacturerState.Text = Convert.ToString(drDPD_ClaimsDetails["Owner_Manufacturer_State"]);
            lblOwnerManufacturerZipCode.Text =  Convert.ToString(drDPD_ClaimsDetails["Owner_Manufacturer_Zip_Code"]);
            lblVehicleDamageDescription.Text =  Convert.ToString(drDPD_ClaimsDetails["Vehicle_Damage_Description"]);
            lblOtherVehicleDamageEstimate.Text = Convert.ToString(drDPD_ClaimsDetails["Other_Vehicle_Damage_Estimate"]);
            lblOtherVehicleOwnerName.Text =      Convert.ToString(drDPD_ClaimsDetails["Other_Vehicle_Owner_Name"]);
            lblOtherVehicleOwnerAddress.Text =  Convert.ToString(drDPD_ClaimsDetails["Other_Vehicle_Owner_Address"]);
            lblOtherVehicleDriverAddress.Text = Convert.ToString(drDPD_ClaimsDetails["Other_Vehicle_Driver_Address"]);
            lblOtherVehicleDriverPhoneNumber.Text = Convert.ToString(drDPD_ClaimsDetails["Other_Vehicle_Driver_Phone_Number"]);
            lblOtherVehicleDriverAddress2.Text = Convert.ToString(drDPD_ClaimsDetails["Vehicle_Driver_Address_2"]);
            lblOtherVehicleDriverWorkPhone.Text = Convert.ToString(drDPD_ClaimsDetails["Vehicle_Driver_Work_Phone"]);
            lblOtherVehicleDriverLicenseNumber.Text = Convert.ToString(drDPD_ClaimsDetails["Vehicle_Driver_Drivers_License_Number"]);
            lblOwnerManufacturerAddress2.Text = Convert.ToString(drDPD_ClaimsDetails["Owner_Manufacturer_Address_2"]);
            lblOwnerManufacturerHomePhone.Text = Convert.ToString(drDPD_ClaimsDetails["Owner_Manufacturer_Home_Phone"]);
            lblFirstPartyVehicleType.Text = Convert.ToString(drDPD_ClaimsDetails["First_Party_Vehicle_Type"]);
            lblFirstPartyVehicleDrivable.Text = Convert.ToString(drDPD_ClaimsDetails["First_Party_Vehicle_Drivable"]);
            lblFirstPartyVehicleAddress.Text = Convert.ToString(drDPD_ClaimsDetails["First_Party_Vehicle_Address_1"]);
            lblFirstPartyVehicleAddress2.Text =  Convert.ToString(drDPD_ClaimsDetails["First_Party_Vehicle_Address_2"]);
            lblFirstPartyVehicleCity.Text = Convert.ToString(drDPD_ClaimsDetails["First_Party_Vehicle_City"]);
            lblFirstPartyVehicleState.Text = Convert.ToString(drDPD_ClaimsDetails["First_Party_Vehicle_State"]);
            lblFristPartyVehicleZipCode.Text = Convert.ToString(drDPD_ClaimsDetails["First_Party_Vehicle_Zip_Code"]);
            lblFirstPartyCitationsIssued.Text = Convert.ToString(drDPD_ClaimsDetails["First_Party_Driver_Citations_Issued"]);
            lblFirstPartyCitationsIssuedBy.Text = Convert.ToString(drDPD_ClaimsDetails["First_Party_Driver_Citation_Issued_By"]);
            lblFirstPartyCitationNumber.Text = Convert.ToString(drDPD_ClaimsDetails["First_Party_Driver_Citation_Number"]);
            lblDescriptionofPropertyDamage.Text = Convert.ToString(drDPD_ClaimsDetails["Description_of_the_Property_Damage"]);
            lblAnyVehiclesTowed.Text = Convert.ToString(drDPD_ClaimsDetails["Any_vehicles_towed"]);
            lblWhentoContact.Text = Convert.ToString(drDPD_ClaimsDetails["When_to_Contact"]);
            lblReportedBy.Text = Convert.ToString(drDPD_ClaimsDetails["Reported_By"]);
            lblInsuredVehicleLocation.Text = Convert.ToString(drDPD_ClaimsDetails["Insured_Vehicle_Location"]);
            lblThirdPartyInsuranceCompany.Text = Convert.ToString(drDPD_ClaimsDetails["Third_Party_Insurance_Company"]);
            lblThirdPartyInsurancePolicyNumber.Text =  Convert.ToString(drDPD_ClaimsDetails["Third_Party_Insurance_Policy_Number"]);
            lblThirdPartyClaimNumber.Text = Convert.ToString(drDPD_ClaimsDetails["Third_Party_Vehicle_Claim_Number"]);
            lblThirdPartyDriverName.Text = Convert.ToString(drDPD_ClaimsDetails["Third_Party_Drivers_Name"]);
            lblThirdPartyDriverAddress.Text = Convert.ToString(drDPD_ClaimsDetails["Third_Party_Drivers_Address_1"]);
            lblThirdPartyDriverAddress2.Text = Convert.ToString(drDPD_ClaimsDetails["Third_Party_Drivers_Address_2"]);
            lblThirdPartyDriverCity.Text = Convert.ToString(drDPD_ClaimsDetails["Third_Party_Drivers_City"]);
            lblThirdPartyDriverState.Text = Convert.ToString(drDPD_ClaimsDetails["Third_Party_Drivers_State"]);
            lblThirdPartyPostalCode.Text = Convert.ToString(drDPD_ClaimsDetails["Third_Party_Drivers_Postal_Code"]);
            lblThirdPartyDriverHomePhone.Text = Convert.ToString(drDPD_ClaimsDetails["Third_Party_Drivers_Home_Phone"]);
            lblThirdPartyDriverWorkPhone.Text =  Convert.ToString(drDPD_ClaimsDetails["Third_Party_Drivers_Work_Phone"]);
            lblThirdPartyVehicleYear.Text = Convert.ToString(drDPD_ClaimsDetails["Third_Party_Vehicle_Year"]);
            lblThirdPartyVehicleMake.Text = Convert.ToString(drDPD_ClaimsDetails["Third_Party_Vehicle_Make"]);
            lblThirdPartyVehicleModel.Text =  Convert.ToString(drDPD_ClaimsDetails["Third_Party_Vehicle_Model"]);
            lblThirdPartyVehicleLicensePlateNumber.Text = Convert.ToString(drDPD_ClaimsDetails["Third_Party_Vehicle_Plate_Number"]);
            lblThirdPartyVehicleVIN.Text =  Convert.ToString(drDPD_ClaimsDetails["Third_Party_Vehicle_VIN"]);
            lblThirdPartyVehicleDamageDescription.Text = Convert.ToString(drDPD_ClaimsDetails["Third_Party_Vehicle_Damage_Description"]);
            lblThirdPartyVehicleLicensePlateNumber.Text = Convert.ToString(drDPD_ClaimsDetails["Third_Party_Vehicle_Drivers_License_Number"]);
            lblThirdPartyVehicleCitationIssued.Text = Convert.ToString(drDPD_ClaimsDetails["Third_Party_Vehicle_Citation_Issued"]);
            lblThirdPartyVehicleCitationNumber.Text = Convert.ToString(drDPD_ClaimsDetails["Third_Party_Vehicle_Driver_Citation_Number"]);
            lblThirdPartyVehicleDriverWearingSeatbelt.Text = Convert.ToString(drDPD_ClaimsDetails["Third_Party_Vehicle_Driver_Wearing_Seatbelt"]);
            lblThirdPartyDriverInjuryDescription.Text = Convert.ToString(drDPD_ClaimsDetails["Third_Party_Vehicle_Driver_Injury_Description"]);
            lblThirdPartyVehicleDriverOwnsVehicle.Text =  Convert.ToString(drDPD_ClaimsDetails["Third_Party_Vehicle_Driver_Owns_Vehicle"]);
            lblThirdPartyVehicleDidPassengerSeekMedicalAttention.Text = Convert.ToString(drDPD_ClaimsDetails["Third_Party_Vehicle_Did_Passenger_Seek_Medical_Attention"]);
            lblAuthorityContacted.Text = Convert.ToString(drDPD_ClaimsDetails["Authority_Contacted"]);

        }
    }

    private void FillAddressDetails(decimal addresspk)
    {
        
        DataSet dsDPD_ClaimsAddressesByPK = DPD_ClaimInfo.SelectViewClaimAddressesByPK(Convert.ToInt64(addresspk));
        // get data
        DataTable dtDPD_ClaimsAddressesByPK = dsDPD_ClaimsAddressesByPK.Tables[0];
        // if data is available
        if (dtDPD_ClaimsAddressesByPK.Rows.Count > 0)
        {
            DataRow drDPD_ClaimsAddresses = dtDPD_ClaimsAddressesByPK.Rows[0];

            lblAddressNumber.Text = Convert.ToString(drDPD_ClaimsAddresses["Address_Number"]);
            lblAddressFirstName.Text = Convert.ToString(drDPD_ClaimsAddresses["First_Name"]);
            lblAddressLastName.Text = Convert.ToString(drDPD_ClaimsAddresses["Last_Name"]);
            lblAddressPhoneNumber.Text = Convert.ToString(drDPD_ClaimsAddresses["Phone_Number"]);
            lblAddress1.Text = Convert.ToString(drDPD_ClaimsAddresses["Address_1"]);
            lblAddress2.Text = Convert.ToString(drDPD_ClaimsAddresses["Address_2"]);
            lblAddressCity.Text = Convert.ToString(drDPD_ClaimsAddresses["City"]);
            lblFaxNumber.Text = Convert.ToString(drDPD_ClaimsAddresses["Fax_Number"]);
            lblEmailAddress.Text = Convert.ToString(drDPD_ClaimsAddresses["Email_Address"]);
           
        }
    }

    #endregion


    protected void gvAddress_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "EditRecord")
        {
            if (!string.IsNullOrEmpty(Convert.ToString(e.CommandArgument)))
            {
                decimal _pk_Address_ID = clsGeneral.GetDecimal(Convert.ToString(e.CommandArgument));
                if (_pk_Address_ID > 0)
                {
                    FillAddressDetails(_pk_Address_ID);
                    string str = "<script>javascript:ShowPanel('2');</script>";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", str, false);
                    pnlAddressesGrid.Visible = false;
                    pnlAddressesView.Visible = true;                  
                    
                }
            }
        }
    }
    protected void gvAddress_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{
        //    if (!string.IsNullOrEmpty(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Address_1"))) && !string.IsNullOrEmpty(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Address_2"))))
        //    {
        //        ((Label)e.Row.FindControl("lblAddress")).Text = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Address_1")) + "<br />"
        //        ((Label)e.Row.FindControl("lblAddress2")).Text = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Address_2")) + "<br />";
        //        ((Label)e.Row.FindControl("lblCity")).Text = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "City"));
        //    }
        //}

    }



}

