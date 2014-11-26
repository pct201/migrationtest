using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BAL;
using ERIMS.DAL;

public partial class SONIC_Sedgwick_ClaimSummary : clsBasePage
{
    #region "Properties"
    /// <summary>
    /// PK_Sedgwick_Claim_Review for SLT Safety
    /// </summary>
    public decimal PK_Sedgwick_Claim_Review
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_Sedgwick_Claim_Review"]);
        }
        set { ViewState["PK_Sedgwick_Claim_Review"] = value; }
    }

    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            PK_Sedgwick_Claim_Review = Convert.ToDecimal(Request.QueryString["PK_SCR"]);

            if (Request.QueryString["PK_WCC_ID"] != null)
                BindControls(Convert.ToDecimal(Request.QueryString["PK_WCC_ID"]));

            //Set the first panel active
            int intPanle = 1;
            if (int.TryParse(Convert.ToString(Request.QueryString["pnl"]), out intPanle))
                Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(" + intPanle.ToString() + ");", true);
            else
                Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(1);", true);




            if (Request.QueryString["IsReturn"] != null)
            {
                hdnIsSave.Value = Request.QueryString["IsReturn"].ToString();
            }
            if (Request.QueryString["IsSave"] != null)
            {
                btnSave.Visible = Convert.ToBoolean(Request.QueryString["IsSave"]);
                hdnIsSave.Value = (!Convert.ToBoolean(Request.QueryString["IsSave"])).ToString();
            }

            if (App_Access == AccessType.View_Only)
                SetControlEnableFalse(false);
            else
            {
                if (Request.QueryString["IsReviewAvailable"] != null)
                {
                    if (Convert.ToString(Request.QueryString["IsReviewAvailable"]) != "true")
                        btnReturn.Attributes.Add("onclick", "return CheckIsSaveRecord();");
                }
                else
                    btnReturn.Attributes.Add("onclick", "return CheckIsSaveRecord();");
            }
            SetValidations();

            if (App_Access == AccessType.View_Only)
            {
                Attachments.isViewOnly = true;
                AttachDetails.isViewOnly = true;
            }
        }
    }

    public void BindControls(decimal PK_Workers_Comp_Claims_ID)
    {
        clsSession.First_Report_Wizard_ID = 0;
        DataTable dtData = Sedgwick_Claim_Group.ClaimSummary_SelectByPK(PK_Workers_Comp_Claims_ID).Tables[0];
        DataRow drData = dtData.Rows[0];

        //Display Location NUmber
        if (drData["sonic_location_code"] != null)
            txtLocationNumber.Text = drData["sonic_location_code"].ToString();
        else
            txtLocationNumber.Text = "";
        //Display dba Value
        if (drData["dba"] != null)
        {
            txtLocationDBA.Text = drData["dba"].ToString();
            txtLocationDBA_Review.Text = drData["dba"].ToString(); //For Review Screen
        }
        else
        {
            txtLocationDBA.Text = "";
            txtLocationDBA_Review.Text = ""; //For Review Screen
        }
        // lblClaimNumber.Text = drData["Origin_Claim_Number"].ToString();
        ahrefClaimnumber.InnerText = drData["Origin_Claim_Number"].ToString();
        ahrefClaimnumber.HRef = "~/SONIC/ClaimInfo/WCClaimInfo.aspx?id=" + Encryption.Encrypt(drData["PK_Workers_Comp_Claims_ID"].ToString()) + "&ClaimReview=1";

        lblCalimNUmber_Review.Text = drData["Origin_Claim_Number"].ToString(); //For Review Screen
        lblClaimNumber_Investigation.Text = drData["Origin_Claim_Number"].ToString(); //For Investigation Tab
        lblClaimNumber_Subrogation.Text = drData["Origin_Claim_Number"].ToString(); //For Subrogation Tab
        lblClaimNumber_Medical.Text = drData["Origin_Claim_Number"].ToString(); //For Medical Tab
        lblClaimNumber_ClosurePlans.Text = drData["Origin_Claim_Number"].ToString(); //For ClosurePlans Tab
        lblClaimNumber_Disability.Text = drData["Origin_Claim_Number"].ToString(); //For Disability Tab
        lblClaimNumber_Leadership.Text = drData["Origin_Claim_Number"].ToString(); //For Leadership Tab
        lblClaimNumber_Reserves.Text = drData["Origin_Claim_Number"].ToString(); //For Reserves Tab

        if (!string.IsNullOrEmpty(drData["PK_WC_FR_ID"].ToString()))
        {
            DataTable dtWCState = WC_FR.SelectByState(Convert.ToDecimal(drData["PK_WC_FR_ID"]));
            lblFROINumber.InnerText = dtWCState.Rows[0][0].ToString();
        }
        else
            lblFROINumber.InnerText = "";
        //lblFROINumber.InnerText = drData["Associated_First_Report"] != DBNull.Value ? drData["Associated_First_Report"].ToString() : "";

        if (drData["Associated_First_Report"] != DBNull.Value)
        {
            lblFROINumber.HRef = "~/SONIC/FirstReport/WCFirstReport.aspx?id=" + Encryption.Encrypt(drData["PK_WC_FR_ID"].ToString()) + "&ClaimReview=1";

            if (drData["FK_First_Report_Wizard_ID"] != DBNull.Value)
                clsSession.First_Report_Wizard_ID = Convert.ToInt32(drData["FK_First_Report_Wizard_ID"]);
        }
        else
        {
            lblFROINumber.HRef = "#";
        }

        //lblAssociateName_Reserves.Text = drData["First_Name"];
        txtName.Text = drData["First_Name"] + " " + drData["Last_Name"];
        txtAssociateName.Text = drData["First_Name"] + " " + drData["Last_Name"];  //For Review Screen        
        lblAssociateName_Investigation.Text = drData["First_Name"] + " " + drData["Last_Name"]; //For Investigation Tab
        lblAssociateName_Subrogation.Text = drData["First_Name"] + " " + drData["Last_Name"]; //For Subrogation Tab
        lblAssociateName_ClosurePlans.Text = drData["First_Name"] + " " + drData["Last_Name"]; //For ClosurePlans Tab
        lblAssociateName_Disability.Text = drData["First_Name"] + " " + drData["Last_Name"]; //For Disability Tab
        lblAssociateName_Leadership.Text = drData["First_Name"] + " " + drData["Last_Name"]; //For Leadership Tab
        lblAssociateName_Medical.Text = drData["First_Name"] + " " + drData["Last_Name"]; //For Medical Tab
        lblAssociateName_Reserves.Text = drData["First_Name"] + " " + drData["Last_Name"]; //For Reserves Tab

        txtDtOfBirth.Text = clsGeneral.FormatDBNullDateToDisplay(drData["Date_Of_Birth"].ToString());
        if (!(string.IsNullOrEmpty(drData["Date_Of_Birth"].ToString())))
        {
            if (Convert.ToDateTime(drData["Date_Of_Birth"]) != (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue)
                txtAge.Text = GetAge(Convert.ToDateTime(drData["Date_Of_Birth"]));
        }
        txtDateOfHire.Text = clsGeneral.FormatDBNullDateToDisplay(drData["Hire_Date"]);
        txtJobTitle.Text = (drData["Job_Title"] != null) ? Convert.ToString(drData["Job_Title"]) : "";

        lblJobTitle_Investigation.Text = (drData["Job_Title"] != null) ? Convert.ToString(drData["Job_Title"]) : ""; //For Investigation Tab
        lblJobTitle_ClosurePlans.Text = (drData["Job_Title"] != null) ? Convert.ToString(drData["Job_Title"]) : ""; //For ClosurePlans Tab
        lblJobTitle_Disability.Text = (drData["Job_Title"] != null) ? Convert.ToString(drData["Job_Title"]) : ""; //For Disability Tab
        lblJobTitle_Leadership.Text = (drData["Job_Title"] != null) ? Convert.ToString(drData["Job_Title"]) : ""; //For Leadership Tab
        lblJobTitle_Medical.Text = (drData["Job_Title"] != null) ? Convert.ToString(drData["Job_Title"]) : ""; //For Medical Tab
        lblJobTitle_Reserves.Text = (drData["Job_Title"] != null) ? Convert.ToString(drData["Job_Title"]) : ""; //For Reserves Tab
        lblJobTitle_Subrogation.Text = (drData["Job_Title"] != null) ? Convert.ToString(drData["Job_Title"]) : ""; //For Subrogation Tab

        txtEmployementStatus.Text = Convert.ToString(drData["Active_Inactive_Leave"]);
        txtDateOfIncident.Text = drData["Date_Of_Incident"].ToString();

        txtDateOfInjury.Text = drData["Date_Of_Incident"].ToString(); //For Review Screen
        txtJobTitle_Review.Text = (drData["Job_Title"] != null) ? Convert.ToString(drData["Job_Title"]) : ""; //For Review Screen

        lblInjuryDate_Investigation.Text = drData["Date_Of_Incident"].ToString(); //For Investigation Tab
        lblInjuryDate_ClosurePlans.Text = drData["Date_Of_Incident"].ToString(); //For ClosurePlans Tab
        lblInjuryDate_Disability.Text = drData["Date_Of_Incident"].ToString(); //For Disability Tab
        lblInjuryDate_Leadership.Text = drData["Date_Of_Incident"].ToString(); //For Leadership Tab
        lblInjuryDate_Medical.Text = drData["Date_Of_Incident"].ToString(); //For Medical Tab
        lblInjuryDate_Reserves.Text = drData["Date_Of_Incident"].ToString(); //For Reserves Tab
        lblInjuryDate_Subrogation.Text = drData["Date_Of_Incident"].ToString(); //For Subrogation Tab

        txtTimeOfIncident.Text = drData["Time_Of_Incident"].ToString();
        txtFillingState.Text = new State(string.IsNullOrEmpty(drData["Filing_State"].ToString()) ? 0 : Convert.ToDecimal(drData["Filing_State"])).FLD_state;
        txtDescOfIncident.Text = drData["Description_Of_Incident"].ToString();
        txtNatureOfInjury.Text = new LU_Nature_of_Injury((!(string.IsNullOrEmpty(drData["FK_Nature_Of_Injury"].ToString()))) ? Convert.ToDecimal(drData["FK_Nature_Of_Injury"]) : 0).Description;
        txtDeptWhereInjuryOccured.Text = new LU_Department(!(string.IsNullOrEmpty(drData["FK_Department_Where_Occurred"].ToString())) ? Convert.ToDecimal(drData["FK_Department_Where_Occurred"]) : 0).Description;
        txtBodyPartAffected.Text = new LU_Part_Of_Body(string.IsNullOrEmpty(drData["FK_Body_Parts_Affected"].ToString()) ? 0 : Convert.ToDecimal(drData["FK_Body_Parts_Affected"])).Description;
        //check object value if it null than display "unknown"
        if (!string.IsNullOrEmpty(drData["Claim_Questionable"].ToString()))
        {
            if (Convert.ToBoolean(drData["Claim_Questionable"]))
                rdbClaimQuestionable.SelectedValue = "Y";
            else
                rdbClaimQuestionable.SelectedValue = "N";
        }
        else
            rdbClaimQuestionable.SelectedValue = "-1";

        txtIfYesWhy.Text = drData["Claim_Questionable_Description"].ToString();
        txtDateReportedToSonic.Text = (!string.IsNullOrEmpty(drData["Date_Reported_To_Sonic"].ToString()) ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drData["Date_Reported_To_Sonic"])) : "");
        rdbTelConsultnUsed.SelectedValue = drData["Telephone_Nurse_Consultation"].ToString();
        txtDescTretment.Text = drData["Initial_Medical_Treatment"].ToString();
        txtDescTretment.Text = drData["Initial_Medical_Treatment"].ToString();
        //Set Initial Claim Classification
        string strInitialClaim = string.Empty;
        string[] strSelectedClaim = drData["Initial_Claim_Classification"].ToString().Split(',');
        ListItem[] liClaim = WC_FR.InitialClaimClassificationList();

        if (strSelectedClaim.Length > 0)
        {
            for (int i = 0; i < strSelectedClaim.Length; i++)
            {
                foreach (ListItem li in liClaim)
                {

                    if (li.Value == strSelectedClaim[i])
                    {
                        if (i == strSelectedClaim.Length - 0)
                            strInitialClaim += li.Text;
                        else
                            strInitialClaim += li.Text + "<br/>";
                    }

                }
            }
        }

        strInitialClaim = strInitialClaim.TrimEnd(',');
        txtInitialClaimClassifictn.Text = strInitialClaim;
        lblComments.Text = drData["Comments"].ToString();

        lblnvestigationID.InnerText = drData["PK_Investigation_ID"].ToString();
        if (drData["Associated_First_Report"] != DBNull.Value)
            lblnvestigationID.HRef = "~/SONIC/FirstReport/Investigation.aspx?id=" + Encryption.Encrypt(drData["PK_Investigation_ID"].ToString()) + "&op=view&search=1&ClaimReview=1";
        else
            lblnvestigationID.HRef = "#";

        lblSonicCauseCode.Text = drData["Sonic_Cause_Code"].ToString();

        txtEffectiveDate.Text = drData["RTW_Effective_Date"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drData["RTW_Effective_Date"]));
        txtWorkStatusType.Text = Convert.ToString(drData["RTW_Work_Status_Type"]);
        //lblAuthorizedOffWork.Text = drWorkers_Comp_Claims["RTW_Authorized_Off_Work"] == DBNull.Value ? "" : GetYesNo(Convert.ToString(drWorkers_Comp_Claims["RTW_Authorized_Off_Work"]));
        txtDateLastWorked.Text = drData["RTW_Date_Last_Worked"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drData["RTW_Date_Last_Worked"]));
        txtDateLastWorkedAsFullDay.Text = drData["RTW_DLW_Full_Day"] == DBNull.Value ? "" : GetYesNo(Convert.ToString(drData["RTW_DLW_Full_Day"]));
        txtDateExaminerReturnToWorkResDuty.Text = drData["RTW_Anticipated_RTW_Ex_Full_Duty"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drData["RTW_Anticipated_RTW_Ex_Full_Duty"]));
        txtDateExaminerReturnToWorkFullDay.Text = drData["RTW_Anticipated_RTW_Ex_Restricted"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drData["RTW_Anticipated_RTW_Ex_Restricted"]));
        txtDateCaseMgrToResDuty.Text = drData["RTW_Anticipated_RTW_CM_Full_Duty"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drData["RTW_Anticipated_RTW_CM_Full_Duty"]));
        txtDateCaseMngrToFullDay.Text = drData["RTW_Anticipated_RTW_CM_Restricted"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drData["RTW_Anticipated_RTW_CM_Restricted"]));
        txtDatePhysicianAnticipateToFullDay.Text = drData["RTW_Anticipated_RTW_Ph_Full_Duty"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drData["RTW_Anticipated_RTW_Ph_Full_Duty"]));
        txtDatePhysicianAnticipateToResDuty.Text = drData["RTW_Anticipated_RTW_Ph_Restricted"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drData["RTW_Anticipated_RTW_Ph_Restricted"]));
        txtDateModifiedDutyAvail.Text = drData["RTW_Moderate_Duty_Available"] == DBNull.Value ? "" : GetYesNo(Convert.ToString(drData["RTW_Moderate_Duty_Available"]));
        txtDateModerateDutyOffered.Text = drData["RTW_Modified_Duty_Offered"] == DBNull.Value ? "" : GetYesNo(Convert.ToString(drData["RTW_Modified_Duty_Offered"]));
        txtModerateDutyAccepted.Text = drData["RTW_Modified_Duty_Accepted"] == DBNull.Value ? "" : GetYesNo(Convert.ToString(drData["RTW_Modified_Duty_Accepted"]));
        txtModifiedDutyOccupation.Text = Convert.ToString(drData["RTW_Modified_Duty_Occupation"]);
        txtModifiedDutyDemand.Text = Convert.ToString(drData["RTW_Modified_Duty_Demand"]);
        txtHoursWorkedonModifiedDuty.Text = drData["RTW_Hours_Modified_Duty"] != DBNull.Value ? String.Format("{0:N2}", Convert.ToDecimal(drData["RTW_Hours_Modified_Duty"])) : "";
        txtReturnToWorkOccup.Text = Convert.ToString(drData["RTW_Occupation"]);
        txtReturnToWorkDemand.Text = Convert.ToString(drData["RTW_Demand"]);
        txtReturnToWorkSchedule.Text = Convert.ToString(drData["RTW_Schedule"]);
        txtDateDisabilityBegan.Text = drData["RTW_Date_Disability_Began"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drData["RTW_Date_Disability_Began"]));
        txtNumberOfLostTimeDays.Text = drData["RTW_Number_Lost_Time_Days"] != DBNull.Value ? String.Format("{0:N0}", Convert.ToDecimal(drData["RTW_Number_Lost_Time_Days"])) : "";
        txtNoOfRestWorkDays.Text = drData["RTW_Number_Restricted_Work_Days"] != DBNull.Value ? String.Format("{0:N0}", Convert.ToDecimal(drData["RTW_Number_Restricted_Work_Days"])) : "";

        txtReasonForTermination.Text = Convert.ToString(drData["RTW_Reason_For_Termination"]);
        decimal TotalReserve = 0;
        decimal TotalPaid = 0;
        decimal TotalOutstanding = 0;

        txtResIndemnity.Text = drData["Indemnity_Incurred"] != DBNull.Value ? String.Format("$ {0:N2}", Convert.ToDecimal(drData["Indemnity_Incurred"])) : "";
        txtResIndemnity_Review.Text = drData["Indemnity_Incurred"] != DBNull.Value ? String.Format("$ {0:N2}", Convert.ToDecimal(drData["Indemnity_Incurred"])) : "";
        TotalReserve = TotalReserve + (string.IsNullOrEmpty(Convert.ToString(drData["Indemnity_Incurred"])) ? 0 : Convert.ToDecimal(drData["Indemnity_Incurred"]));
        txtResMedical.Text = drData["Medical_Incurred"] != DBNull.Value ? String.Format("$ {0:N2}", Convert.ToDecimal(drData["Medical_Incurred"])) : "";
        txtResMedical_Review.Text = drData["Medical_Incurred"] != DBNull.Value ? String.Format("$ {0:N2}", Convert.ToDecimal(drData["Medical_Incurred"])) : "";
        TotalReserve = TotalReserve + (string.IsNullOrEmpty(Convert.ToString(drData["Medical_Incurred"])) ? 0 : Convert.ToDecimal(drData["Medical_Incurred"]));
        txtResExpense.Text = drData["Expense_Incurred"] != DBNull.Value ? String.Format("$ {0:N2}", Convert.ToDecimal(drData["Expense_Incurred"])) : "";
        txtResExpense_Review.Text = drData["Expense_Incurred"] != DBNull.Value ? String.Format("$ {0:N2}", Convert.ToDecimal(drData["Expense_Incurred"])) : "";
        TotalReserve = TotalReserve + (string.IsNullOrEmpty(Convert.ToString(drData["Expense_Incurred"])) ? 0 : Convert.ToDecimal(drData["Expense_Incurred"]));
        txtResTotal.Text = String.Format("$ {0:N2}", Convert.ToDecimal(TotalReserve));
        txtResTotal_Review.Text = String.Format("$ {0:N2}", Convert.ToDecimal(TotalReserve));

        txtPaidIndemnity.Text = drData["Indemnity_Gross_Paid"] != DBNull.Value ? String.Format("$ {0:N2}", Convert.ToDecimal(drData["Indemnity_Gross_Paid"])) : "";
        txtPaidIndemnity_Review.Text = drData["Indemnity_Gross_Paid"] != DBNull.Value ? String.Format("$ {0:N2}", Convert.ToDecimal(drData["Indemnity_Gross_Paid"])) : "";
        TotalPaid = TotalPaid + (string.IsNullOrEmpty(Convert.ToString(drData["Indemnity_Gross_Paid"])) ? 0 : Convert.ToDecimal(drData["Indemnity_Gross_Paid"]));
        txtPaidMedical.Text = drData["Medical_Gross_Paid"] != DBNull.Value ? String.Format("$ {0:N2}", Convert.ToDecimal(drData["Medical_Gross_Paid"])) : "";
        txtPaidMedical_Review.Text = drData["Medical_Gross_Paid"] != DBNull.Value ? String.Format("$ {0:N2}", Convert.ToDecimal(drData["Medical_Gross_Paid"])) : "";
        TotalPaid = TotalPaid + (string.IsNullOrEmpty(Convert.ToString(drData["Medical_Gross_Paid"])) ? 0 : Convert.ToDecimal(drData["Medical_Gross_Paid"]));
        txtPaidExpense.Text = drData["Expense_Gross_Paid"] != DBNull.Value ? String.Format("$ {0:N2}", Convert.ToDecimal(drData["Expense_Gross_Paid"])) : "";
        txtPaidExpense_Review.Text = drData["Expense_Gross_Paid"] != DBNull.Value ? String.Format("$ {0:N2}", Convert.ToDecimal(drData["Expense_Gross_Paid"])) : "";
        TotalPaid = TotalPaid + (string.IsNullOrEmpty(Convert.ToString(drData["Expense_Gross_Paid"])) ? 0 : Convert.ToDecimal(drData["Expense_Gross_Paid"]));
        txtPaidTotal.Text = String.Format("$ {0:N2}", Convert.ToDecimal(TotalPaid));
        txtPaidTotal_Review.Text = String.Format("$ {0:N2}", Convert.ToDecimal(TotalPaid));

        txtOSIndemnity.Text = drData["Indemnity_Outstanding"] != DBNull.Value ? String.Format("$ {0:N2}", Convert.ToDecimal(drData["Indemnity_Outstanding"])) : "";
        txtOSIndemnity_Review.Text = drData["Indemnity_Outstanding"] != DBNull.Value ? String.Format("$ {0:N2}", Convert.ToDecimal(drData["Indemnity_Outstanding"])) : "";
        TotalOutstanding = TotalOutstanding + (string.IsNullOrEmpty(Convert.ToString(drData["Indemnity_Outstanding"])) ? 0 : Convert.ToDecimal(drData["Indemnity_Outstanding"]));
        txtOSMedical.Text = drData["Medical_Outstanding"] != DBNull.Value ? String.Format("$ {0:N2}", Convert.ToDecimal(drData["Medical_Outstanding"])) : "";
        txtOSMedical_Review.Text = drData["Medical_Outstanding"] != DBNull.Value ? String.Format("$ {0:N2}", Convert.ToDecimal(drData["Medical_Outstanding"])) : "";
        TotalOutstanding = TotalOutstanding + (string.IsNullOrEmpty(Convert.ToString(drData["Medical_Outstanding"])) ? 0 : Convert.ToDecimal(drData["Medical_Outstanding"]));
        txtOSExpense.Text = drData["Expense_Outstanding"] != DBNull.Value ? String.Format("$ {0:N2}", Convert.ToDecimal(drData["Expense_Outstanding"])) : "";
        txtOSExpense_Review.Text = drData["Expense_Outstanding"] != DBNull.Value ? String.Format("$ {0:N2}", Convert.ToDecimal(drData["Expense_Outstanding"])) : "";
        TotalOutstanding = TotalOutstanding + (string.IsNullOrEmpty(Convert.ToString(drData["Expense_Outstanding"])) ? 0 : Convert.ToDecimal(drData["Expense_Outstanding"]));
        txtOSTotal.Text = String.Format("$ {0:N2}", Convert.ToDecimal(TotalOutstanding));
        txtOSTotal_Review.Text = String.Format("$ {0:N2}", Convert.ToDecimal(TotalOutstanding));
        lblLawSuitYN.Text = GetYesNo(Convert.ToString(drData["LitigationYN"]));
        lblClaimantAttorneyRepresentativeYN.Text = GetYesNo(Convert.ToString(drData["Attorney_Authorized_Rep"]));
        lblDisabilityBegan.Text = drData["Date_Disability_Began"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drData["Date_Disability_Began"]));
        lblDate_Return_To_Work.Text = drData["Date_Return_To_Work"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drData["Date_Return_To_Work"]));
        lblDate_of_Max_Medical_Improvement.Text = drData["Date_of_Max_Medical_Improvement"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drData["Date_of_Max_Medical_Improvement"]));
        lblCauseofInjuryCode.Text = Convert.ToString(drData["Cause_of_Injury_Code"]);
        lblNatureofInjuryCode.Text = Convert.ToString(drData["Nature_of_Injury_Code"]);
        lblPartofBodyCode.Text = Convert.ToString(drData["Part_of_Body_Code"]);
        lblEmploymentStatus.Text = Convert.ToString(drData["Employment_Status"]);
        lblAdjustorCode.Text = Convert.ToString(drData["Adjustor_Code"]);
        lblProcessingOffice.Text = Convert.ToString(drData["Processing_Office"]);
        lblStatusChangeDate.Text = drData["Status_Date_Change"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drData["Status_Date_Change"]));
        lblStatus.Text = Convert.ToString(drData["status"]);
        lblSubStatus.Text = Convert.ToString(drData["Sub_Status"]);
        lblReason1.Text = Convert.ToString(drData["Fld_Desc1"]);
        lblReason2.Text = Convert.ToString(drData["Fld_Desc2"]);
        lblReason3.Text = Convert.ToString(drData["Fld_Desc3"]);
        lblReason4.Text = Convert.ToString(drData["Fld_Desc4"]);
        lblReason5.Text = Convert.ToString(drData["Fld_Desc5"]);
        BindClaimReviewList();

        BindScoreCard();
    }

    /// <summary>
    /// Implement event for Paging control when clicking on Go button
    /// </summary>
    protected void GetPage()
    {
        BindClaimReviewList();
    }

    public void BindScoreCard()
    {
        if (Convert.ToDecimal(Request.QueryString["PK_SCR"]) > 0)
        {
            Sedgwick_Claim_Review objSCR = new Sedgwick_Claim_Review(Convert.ToDecimal(Request.QueryString["PK_SCR"]));
            Sedgwick_Claim_Group objSCG = new Sedgwick_Claim_Group(objSCR.FK_Sedgwick_Claim_Group.Value);
            LU_Sedgwick_Field_Office objLSFO = new LU_Sedgwick_Field_Office(Convert.ToDecimal(objSCG.FK_LU_Sedgwick_Field_Office));

            lblSedgwickOffice.Text = objLSFO.Fld_Desc.ToString();

            lblSedgWickOffice_Investigation.Text = objLSFO.Fld_Desc.ToString(); // For Investigation Tab
            lblSedgWickOffice_ClosurePlans.Text = objLSFO.Fld_Desc.ToString(); // For ClosurePlans Tab
            lblSedgWickOffice_Disability.Text = objLSFO.Fld_Desc.ToString(); // For Disability Tab
            lblSedgWickOffice_Leadership.Text = objLSFO.Fld_Desc.ToString(); // For Leadership Tab
            lblSedgWickOffice_Medical.Text = objLSFO.Fld_Desc.ToString(); // For Medical Tab
            lblSedgWickOffice_Reserves.Text = objLSFO.Fld_Desc.ToString(); // For Reserves Tab
            lblSedgWickOffice_Subrogation.Text = objLSFO.Fld_Desc.ToString(); // For Subrogation Tab

            lblYear.Text = objSCG.Year.ToString();
            lblQuarter.Text = objSCG.Quarter.ToString();
            txtSedgwickFieldOffice.Text = objLSFO.Fld_Desc.ToString(); // For Claim Review

            //if (GetQuarter(DateTime.Now) == objSCG.Quarter.Value && DateTime.Now.Year == objSCG.Year.Value)
            if (AllowRCLMScoreToEnter(objSCG.Year.Value, objSCG.Quarter.Value))
            {
                ddlRLCM_Medical_Score_Investigation.Enabled = true;
                ddlRLCM_Medical_Score_Subrogation.Enabled = true;
                ddlRLCM_Medical_Score_Medical.Enabled = true;
                ddlRLCM_Disability_Score_Disability.Enabled = true;
                ddlRLCM_ClosurePlans_Score_ClosurePlans.Enabled = true;
                ddlRLCM_Reserves_Score_Reserves.Enabled = true;
                ddlRLCM_Leadership_Score_Leadership.Enabled = true;
            }
            else
            {
                ddlRLCM_Medical_Score_Investigation.Enabled = false;
                ddlRLCM_Medical_Score_Subrogation.Enabled = false;
                ddlRLCM_Medical_Score_Medical.Enabled = false;
                ddlRLCM_Disability_Score_Disability.Enabled = false;
                ddlRLCM_ClosurePlans_Score_ClosurePlans.Enabled = false;
                ddlRLCM_Reserves_Score_Reserves.Enabled = false;
                ddlRLCM_Leadership_Score_Leadership.Enabled = false;
            }

            DataTable dtData = LU_Sedgwick_Scoring.GetReviewScoreCard(objSCR.FK_Sedgwick_Claim_Group.Value, objSCG.FK_LU_Sedgwick_Field_Office.Value, objSCG.Year.Value, objSCG.Quarter.Value, Convert.ToDecimal(Request.QueryString["PK_SCR"])).Tables[0];
            if (dtData.Rows.Count > 0)
            {
                DataRow drData = dtData.Rows[0];
                lblScoreClaimNumber.Text = drData["Origin_Claim_Number"].ToString();
                lblNumericScore.Text = drData["Numeric_Score"].ToString();
                lblavgNumericScore.Text = drData["avgNumericScore"].ToString();
                lblSCR_SCoreClassification.Text = drData["SCR_SCoreClassification"].ToString();
                lblTotalAvgScore.Text = drData["Total_of_Average_Numeric_Scores"].ToString();
                txtOverallComments.Text = drData["Overall_Comments"].ToString();
                txtBrokerClaimComments.Text = drData["Broker_Claim_Comments"].ToString();
                lblTotalScoringClassifcatn.Text = drData["Year_SCoreClassification"].ToString();


            }

            AttachDetails.InitializeAttachmentDetails(Convert.ToInt32(Request.QueryString["PK_SCR"]), "FK_Sedgwick_Claim_Review", "PK_Sedgwick_Attachments", true, 11);
            AttachDetails.Bind();
            AttachDetails.FindControl("gvAttachment").DataBind();
        }

        // Ticket # 2899
        //if (Session["dtClaimReviewGroupSearch"] != null)
        //{
        //    DataTable dtSearch = (DataTable)Session["dtClaimReviewGroupSearch"];
        //    if (dtSearch.Rows.Count > 0)
        //    {
        //        DataRow drSearch = dtSearch.Rows[0];
        //        decimal FK_LU_Sedgwick_Field_Office = Convert.ToDecimal(drSearch["FK_LU_Sedgwick_Field_Office"]);

        //        LU_Sedgwick_Field_Office objLSFO = new LU_Sedgwick_Field_Office(FK_LU_Sedgwick_Field_Office);
        //        if (!string.IsNullOrEmpty(objLSFO.Date_Of_Last_Review.ToString()))
        //        {
        //            txtDateOfLastReview.Text = clsGeneral.FormatDateToDisplay(objLSFO.Date_Of_Last_Review.Value);
        //        }
        //    }
        //}

    }

    public void BindClaimReviewList()
    {
        if ((Convert.ToDecimal(Request.QueryString["PK_SCR"])) > 0)
        {
            Sedgwick_Claim_Review objSCR = new Sedgwick_Claim_Review(Convert.ToDecimal(Request.QueryString["PK_SCR"]));
            if (!string.IsNullOrEmpty(objSCR.Adjuster))
                txtAdjuster.Text = objSCR.Adjuster.ToString();
            if (!string.IsNullOrEmpty(objSCR.Date_Of_Last_Review.ToString()))
                txtDateOfLastReview.Text = clsGeneral.FormatDBNullDateToDisplay(objSCR.Date_Of_Last_Review);
            if (!string.IsNullOrEmpty(objSCR.Date_Of_File_Review.ToString()))
                txtDateOfFileReview.Text = clsGeneral.FormatDBNullDateToDisplay(objSCR.Date_Of_File_Review);
            if (!string.IsNullOrEmpty(objSCR.Sedgwick_Team_Leader))
                txtSedgwickTeamLeader.Text = objSCR.Sedgwick_Team_Leader.ToString();
        }
        BindMgtSectionGrid("Investigation", gv_Child_Investigation, gv_NestedChild_Investigation, gv_MedicalScoring_Investigation, ddlRLCM_Medical_Score_Investigation);
        BindMgtSectionGrid("Subrogation", gv_Child_Subrogation, gv_NestedChild_Subrogation, gv_MedicalScoring_Subrogation, ddlRLCM_Medical_Score_Subrogation);
        BindMgtSectionGrid("Medical", gv_Child_Medical, gv_NestedChild_Medical, gv_MedicalScoring_Medical, ddlRLCM_Medical_Score_Medical);
        BindMgtSectionGrid("Disability", gv_Child_Disability, gv_NestedChild_Disability, gv_DisabilityScoring_Disability, ddlRLCM_Disability_Score_Disability);
        BindMgtSectionGrid("Closure Plan", gv_Child_ClosurePlans, gv_NestedChild_ClosurePlans, gv_ClosurePlansScoring_ClosurePlans, ddlRLCM_ClosurePlans_Score_ClosurePlans);
        BindMgtSectionGrid("Reserves", gv_Child_Reserves, gv_NestedChild_Reserves, gv_ReservesScoring_Reserves, ddlRLCM_Reserves_Score_Reserves);
        BindMgtSectionGrid("Leadership", gv_Child_Leadership, gv_NestedChild_Leadership, gv_LeadershipScoring_Leadership, ddlRLCM_Leadership_Score_Leadership);
        //DataSet dsClaimReviewList = LU_Sedgwick_Evaluation.SelectAllDistinctMgtSection();
        //DataTable dtWCTransList = dsClaimReviewList.Tables[0];
        //gvMgtSection.DataSource = dtWCTransList;
        //gvMgtSection.DataBind();
    }
    public void BindMgtSectionGrid(string MgtSection, GridView gv_Child, GridView gv_NestedChild, GridView gv_MedicalScoring, DropDownList ddlRLCM_Medical_Score)
    {
        Sedgwick_Claim_Review objSCR = new Sedgwick_Claim_Review(Convert.ToDecimal(Request.QueryString["PK_SCR"]));

        //  HiddenField lblMgtSection = (HiddenField)e.Row.FindControl("hdnMgtSection");
        //   GridView gv_Child = (GridView)e.Row.FindControl("gv_Child");
        //DropDownList ddlRLCM_Medical_Score = (DropDownList)e.Row.FindControl("ddlRLCM_Medical_Score");

        // string txtempid = lblMgtSection.Value;
        if (Convert.ToDecimal(Request.QueryString["PK_SCR"]) > 0)
        {
            if (MgtSection == "Medical")
                ddlRLCM_Medical_Score.SelectedValue = objSCR.Medical_Score.ToString();
            else if (MgtSection == "Disability")
                ddlRLCM_Medical_Score.SelectedValue = objSCR.Diability_Score.ToString();
            else if (MgtSection == "Leadership")
                ddlRLCM_Medical_Score.SelectedValue = objSCR.Leadership_Score.ToString();
            else if (MgtSection == "Investigation")
                ddlRLCM_Medical_Score.SelectedValue = objSCR.Litigation_Score.ToString();
            else if (MgtSection == "Subrogation")
                ddlRLCM_Medical_Score.SelectedValue = objSCR.Subrogation_Score.ToString();
            else if (MgtSection == "Closure Plan")
                ddlRLCM_Medical_Score.SelectedValue = objSCR.Settlemente_Closure_Score.ToString();
            else if (MgtSection == "Reserves")
                ddlRLCM_Medical_Score.SelectedValue = objSCR.Reserves_Score.ToString();
            if (!string.IsNullOrEmpty(objSCR.Claim_Review_Complete))
                rblDisposition.SelectedValue = objSCR.Claim_Review_Complete.ToString();
        }

        if (Convert.ToDecimal(Request.QueryString["PK_SCR"]) > 0)
        {
            if (Session["dtClaimReviewGroupSearch"] != null)
            {
                DataTable dtSearch = (DataTable)Session["dtClaimReviewGroupSearch"];
                if (dtSearch.Rows.Count > 0)
                {
                    DataRow drSearch = dtSearch.Rows[0];

                    if (GetQuarter(DateTime.Now) == Convert.ToInt32(drSearch["Quarter"].ToString()) && DateTime.Now.Year == Convert.ToInt32(drSearch["Year"].ToString()))
                    {

                    }
                    else
                    {
                        ddlRLCM_Medical_Score.Enabled = false;
                    }
                }
            }
        }
        DataSet dsClaimReviewList = LU_Sedgwick_Evaluation.SelectBy_MgtSection(MgtSection, Convert.ToDecimal(Request.QueryString["PK_SCR"]));
        DataTable dtWCTransList = dsClaimReviewList.Tables[0];
        gv_Child.DataSource = dtWCTransList;
        gv_Child.DataBind();

        // GridView gv_NestedChild = (GridView)e.Row.FindControl("gv_NestedChild");
        DataSet dsNestedClaimReviewList = Sedgwick_Claim_Action_Plan.SelectBy_MgtSection(MgtSection, Convert.ToDecimal(Request.QueryString["PK_SCR"]));
        DataTable dtNestedTransList = dsNestedClaimReviewList.Tables[0];
        gv_NestedChild.DataSource = dtNestedTransList;
        gv_NestedChild.DataBind();
        AddNewRow(MgtSection, gv_NestedChild);

        // GridView gv_MedicalScoring = (GridView)e.Row.FindControl("gv_MedicalScoring");
        DataSet dsMedicalScoringList = LU_Sedgwick_Scoring.SelectBy_MgtSection(MgtSection);
        DataTable dtMedicalScoringList = dsMedicalScoringList.Tables[0];
        gv_MedicalScoring.DataSource = dtMedicalScoringList;
        gv_MedicalScoring.DataBind();
    }
    protected void gvMgtSection_OnRowDataBound(object sender, GridViewRowEventArgs e)
    {
        Sedgwick_Claim_Review objSCR = new Sedgwick_Claim_Review(Convert.ToDecimal(Request.QueryString["PK_SCR"]));

        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            HiddenField lblMgtSection = (HiddenField)e.Row.FindControl("hdnMgtSection");
            GridView gv_Child = (GridView)e.Row.FindControl("gv_Child");
            DropDownList ddlRLCM_Medical_Score = (DropDownList)e.Row.FindControl("ddlRLCM_Medical_Score");

            string txtempid = lblMgtSection.Value;
            if (Convert.ToDecimal(Request.QueryString["PK_SCR"]) > 0)
            {
                if (lblMgtSection.Value == "Medical")
                    ddlRLCM_Medical_Score.SelectedValue = objSCR.Medical_Score.ToString();
                else if (lblMgtSection.Value == "Disability")
                    ddlRLCM_Medical_Score.SelectedValue = objSCR.Diability_Score.ToString();
                else if (lblMgtSection.Value == "Leadership")
                    ddlRLCM_Medical_Score.SelectedValue = objSCR.Leadership_Score.ToString();
                else if (lblMgtSection.Value == "Investigation")
                    ddlRLCM_Medical_Score.SelectedValue = objSCR.Litigation_Score.ToString();
                else if (lblMgtSection.Value == "Subrogation")
                    ddlRLCM_Medical_Score.SelectedValue = objSCR.Subrogation_Score.ToString();
                else if (lblMgtSection.Value == "Closure Plan")
                    ddlRLCM_Medical_Score.SelectedValue = objSCR.Settlemente_Closure_Score.ToString();
                else if (lblMgtSection.Value == "Reserves")
                    ddlRLCM_Medical_Score.SelectedValue = objSCR.Reserves_Score.ToString();
                if (!string.IsNullOrEmpty(objSCR.Claim_Review_Complete))
                    rblDisposition.SelectedValue = objSCR.Claim_Review_Complete.ToString();
            }

            if (Convert.ToDecimal(Request.QueryString["PK_SCR"]) > 0)
            {
                if (Session["dtClaimReviewGroupSearch"] != null)
                {
                    DataTable dtSearch = (DataTable)Session["dtClaimReviewGroupSearch"];
                    if (dtSearch.Rows.Count > 0)
                    {
                        DataRow drSearch = dtSearch.Rows[0];

                        if (GetQuarter(DateTime.Now) == Convert.ToInt32(drSearch["Quarter"].ToString()) && DateTime.Now.Year == Convert.ToInt32(drSearch["Year"].ToString()))
                        {

                        }
                        else
                        {
                            ddlRLCM_Medical_Score.Enabled = false;
                        }
                    }
                }
            }
            DataSet dsClaimReviewList = LU_Sedgwick_Evaluation.SelectBy_MgtSection(txtempid, Convert.ToDecimal(Request.QueryString["PK_SCR"]));
            DataTable dtWCTransList = dsClaimReviewList.Tables[0];
            gv_Child.DataSource = dtWCTransList;
            gv_Child.DataBind();

            GridView gv_NestedChild = (GridView)e.Row.FindControl("gv_NestedChild");
            DataSet dsNestedClaimReviewList = Sedgwick_Claim_Action_Plan.SelectBy_MgtSection(txtempid, Convert.ToDecimal(Request.QueryString["PK_SCR"]));
            DataTable dtNestedTransList = dsNestedClaimReviewList.Tables[0];
            gv_NestedChild.DataSource = dtNestedTransList;
            gv_NestedChild.DataBind();
            AddNewRow(lblMgtSection.Value, gv_NestedChild);

            GridView gv_MedicalScoring = (GridView)e.Row.FindControl("gv_MedicalScoring");
            DataSet dsMedicalScoringList = LU_Sedgwick_Scoring.SelectBy_MgtSection(txtempid);
            DataTable dtMedicalScoringList = dsMedicalScoringList.Tables[0];
            gv_MedicalScoring.DataSource = dtMedicalScoringList;
            gv_MedicalScoring.DataBind();

        }
    }
    protected void gv_NestedChild_OnRowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            if (App_Access == AccessType.View_Only)
            {
                for (int colIndex = 1; colIndex < e.Row.Cells.Count; colIndex++)
                {
                    string cellText = HttpUtility.HtmlDecode(e.Row.Cells[colIndex].Text).Trim();

                    if (cellText == "Remove")
                    {
                        e.Row.Cells[colIndex].Text = string.Empty;
                    }
                }
            }
        }

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            HiddenField hdn = (HiddenField)e.Row.FindControl("hdnRLCM");
            DropDownList ddl = (DropDownList)e.Row.FindControl("ddlRLCM_Sedgwick");
            ddl.SelectedValue = hdn.Value;
            Image imgPlus = (Image)e.Row.FindControl("imgPlus");
            ASP.controls_notes_notes_ascx txtActionItem = (ASP.controls_notes_notes_ascx)e.Row.FindControl("txtActionItem");
            HiddenField hdnPK_Sedgwick_Claim_Action_Plan = (HiddenField)e.Row.FindControl("hdnPK_Sedgwick_Claim_Action_Plan");

            if (App_Access == AccessType.View_Only)
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Image imgRemove = ((Image)e.Row.FindControl("imgRemove"));

                    if (imgRemove != null)
                    {
                        imgRemove.Visible = false;
                    }
                }
            }
        }
    }
    /// <summary>
    /// Grid View List Row Command Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvMgtSection_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        //check Command Name
        if (e.CommandName == "AddNewRow")
        {
            GridViewRow gvr1 = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
            string PK_ID = e.CommandArgument.ToString();

            int rowIndex = 0;
            DataSet dsNestedClaimReviewList = Sedgwick_Claim_Action_Plan.SelectBy_MgtSection(PK_ID, Convert.ToDecimal(Request.QueryString["PK_SCR"]));
            DataTable dtNestedTransList = dsNestedClaimReviewList.Tables[0];

            DataTable dt = GetTableWithNoData(); // get select column header only records not required
            DataRow dr;
            //GridView gv_NestedChild = (GridView)gvMgtSection.Rows[gvr1.RowIndex].FindControl("gv_NestedChild");
            GridView gv_NestedChild = gv_NestedChild_Investigation;
            foreach (GridViewRow gvr in gv_NestedChild.Rows)
            {
                dr = dt.NewRow();

                DropDownList ddlRLCM_Sedgwick = gvr.FindControl("ddlRLCM_Sedgwick") as DropDownList;
                HiddenField hdnPK_Sedgwick_Claim_Action_Plan = gvr.FindControl("hdnPK_Sedgwick_Claim_Action_Plan") as HiddenField;
                TextBox txtTargetDate = gvr.FindControl("txtTargetDate") as TextBox;
                TextBox txtActualDate = gvr.FindControl("txtActualDate") as TextBox;
                ASP.controls_notes_notes_ascx txtActionItem = (ASP.controls_notes_notes_ascx)gvr.FindControl("txtActionItem");

                dr[0] = ddlRLCM_Sedgwick.SelectedValue;
                dr[1] = hdnPK_Sedgwick_Claim_Action_Plan.Value;
                dr[2] = txtActionItem.Text;
                if (txtTargetDate.Text != "")
                    dr[3] = txtTargetDate.Text;
                if (txtActualDate.Text != "")
                    dr[4] = txtActualDate.Text;

                dt.Rows.Add(dr); // add grid values in to row and add row to the blank table
            }
            if (dt.Rows.Count < 6)
            {
                DataRow drCurrentRow = dt.NewRow();
                dt.Rows.Add(drCurrentRow);
            }
            gv_NestedChild.DataSource = dt;
            gv_NestedChild.DataBind();
        }
    }

    /// <summary>
    /// Grid View List Row Command Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gv_NestedChild_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        //check Command Name
        if (e.CommandName == "Remove")
        {

            string strGridId = ((Control)sender).ID;

            if (strGridId == "gv_NestedChild_Investigation")
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(3);", true);
            }
            else if (strGridId == "gv_NestedChild_Subrogation")
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(4);", true);
            }
            else if (strGridId == "gv_NestedChild_Medical")
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(5);", true);
            }
            else if (strGridId == "gv_NestedChild_Disability")
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(6);", true);
            }
            else if (strGridId == "gv_NestedChild_ClosurePlans")
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(7);", true);
            }
            else if (strGridId == "gv_NestedChild_Reserves")
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(8);", true);
            }
            else if (strGridId == "gv_NestedChild_Leadership")
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(9);", true);
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(1);", true);
            }

            GridViewRow gvr = (GridViewRow)(((ImageButton)e.CommandSource).NamingContainer);
            GridView gv_NestedChild = (GridView)gvr.NamingContainer;

            string PK_ID = e.CommandArgument.ToString();
            //GridView gv_NestedChild = (GridView)gvr.Parent.FindControl("gv_NestedChild");
            //if (PK_ID == "")
            //{
            DataTable dt = GetTableWithNoData(); // get select column header only records not required
            DataRow dr;
            foreach (GridViewRow Gridrow in gv_NestedChild.Rows)
            {
                dr = dt.NewRow();

                DropDownList ddlRLCM_Sedgwick = Gridrow.FindControl("ddlRLCM_Sedgwick") as DropDownList;
                HiddenField hdnPK_Sedgwick_Claim_Action_Plan = Gridrow.FindControl("hdnPK_Sedgwick_Claim_Action_Plan") as HiddenField;
                TextBox txtTargetDate = Gridrow.FindControl("txtTargetDate") as TextBox;
                TextBox txtActualDate = Gridrow.FindControl("txtActualDate") as TextBox;
                //TextBox txtActionItem = Gridrow.FindControl("txtActionItem") as TextBox;
                ASP.controls_notes_notes_ascx txtActionItem = (ASP.controls_notes_notes_ascx)Gridrow.FindControl("txtActionItem");

                dr[0] = ddlRLCM_Sedgwick.SelectedValue;
                dr[1] = hdnPK_Sedgwick_Claim_Action_Plan.Value;
                dr[2] = txtActionItem.Text; //gvr.Cells[2].Text;
                if (txtTargetDate.Text != "")
                    dr[3] = txtTargetDate.Text;
                if (txtActualDate.Text != "")
                    dr[4] = txtActualDate.Text;

                dt.Rows.Add(dr); // add grid values in to row and add row to the blank table
            }

            dt.Rows.RemoveAt(gvr.RowIndex);
            DataRow drCurrentRow = dt.NewRow();
            dt.Rows.Add(drCurrentRow);
            gv_NestedChild.DataSource = dt;
            gv_NestedChild.DataBind();
            //}
            if (PK_ID != "")
            {
                Sedgwick_Claim_Action_Plan.Delete(Convert.ToDecimal(PK_ID));
            }
        }
    }

    private void AddNewRow(string MgtSection, GridView gv_NestedChild)
    {
        int rowIndex = 0;
        DataSet dsNestedClaimReviewList = Sedgwick_Claim_Action_Plan.SelectBy_MgtSection(MgtSection, Convert.ToDecimal(Request.QueryString["PK_SCR"]));
        DataTable dtNestedTransList = dsNestedClaimReviewList.Tables[0];

        DataTable dt = GetTableWithNoData(); // get select column header only records not required
        DataRow dr;
        foreach (GridViewRow gvr in gv_NestedChild.Rows)
        {
            dr = dt.NewRow();

            DropDownList ddlRLCM_Sedgwick = gvr.FindControl("ddlRLCM_Sedgwick") as DropDownList;
            HiddenField hdnPK_Sedgwick_Claim_Action_Plan = gvr.FindControl("hdnPK_Sedgwick_Claim_Action_Plan") as HiddenField;
            TextBox txtTargetDate = gvr.FindControl("txtTargetDate") as TextBox;
            TextBox txtActualDate = gvr.FindControl("txtActualDate") as TextBox;
            //TextBox txtActionItem = gvr.FindControl("txtActionItem") as TextBox;
            ASP.controls_notes_notes_ascx txtActionItem = (ASP.controls_notes_notes_ascx)gvr.FindControl("txtActionItem");

            dr[0] = ddlRLCM_Sedgwick.SelectedValue;
            dr[1] = hdnPK_Sedgwick_Claim_Action_Plan.Value;
            dr[2] = txtActionItem.Text; //gvr.Cells[2].Text;
            if (txtTargetDate.Text != "")
                dr[3] = txtTargetDate.Text;
            if (txtActualDate.Text != "")
                dr[4] = txtActualDate.Text;

            dt.Rows.Add(dr); // add grid values in to row and add row to the blank table
        }
        if (gv_NestedChild.Rows.Count < 6)
        {
            for (int i = 1; i <= 6 - gv_NestedChild.Rows.Count; i++)
            {
                DataRow drCurrentRow = dt.NewRow();
                dt.Rows.Add(drCurrentRow);
                //dtNestedTransList.Rows.Add(drCurrentRow);
            }
        }

        gv_NestedChild.DataSource = dt;
        gv_NestedChild.DataBind();

    }

    public DataTable GetTableWithNoData() // this might be your sp for select
    {
        DataTable table = new DataTable();
        table.Columns.Add("RLCM_Sedgwick", typeof(string));
        table.Columns.Add("PK_Sedgwick_Claim_Action_Plan", typeof(string));
        table.Columns.Add("Action_Item", typeof(string));
        table.Columns.Add("Target_Date", typeof(DateTime)).AllowDBNull = true;
        table.Columns.Add("Actual_Date", typeof(DateTime)).AllowDBNull = true;

        return table;
    }

    #region General Methods
    /// <summary>
    /// Used to count the Age as per passed date.
    /// </summary>
    /// <param name="dt"></param>
    /// <returns></returns>
    public string GetAge(DateTime dt)
    {
        if (dt != null)
        {
            DateTime dtToday = DateTime.Now;
            int intCurday = dtToday.Day;
            int intCurMon = dtToday.Month;
            int intCurYear = dtToday.Year;
            int intBday = dt.Day;
            int intBMon = dt.Month;
            int intBYear = dt.Year;
            int Age;
            //used to check Current date with birthdate.
            if ((intCurMon > intBMon) || (intCurMon == intBMon && intCurday >= intBday))
            {
                Age = intBYear;
            }
            else
            {
                Age = intBYear + 1;
            }
            return Convert.ToString(intCurYear - Age);
        }
        else
        {
            return String.Empty;
        }
    }

    private string GetYesNo(string strYesNo)
    {
        if (strYesNo.ToLower() == "y")
            return "Yes";
        else if (strYesNo.ToLower() == "n")
            return "No";
        else if (strYesNo.ToLower() == "yes")
            return "Yes";
        else if (strYesNo.ToLower() == "no")
            return "No";
        else
            return strYesNo;
    }

    public static int GetQuarter(DateTime date)
    {
        return (date.Month - 1) / 3 + 1;

    }

    public static bool AllowRCLMScoreToEnter(int Year, int Quarter)
    {
        if (GetQuarter(DateTime.Now) == Quarter && DateTime.Now.Year == Year)
            return true;
        else if (DateTime.Now.Year == Year && (GetQuarter(DateTime.Now) == Quarter || GetQuarter(DateTime.Now) == Quarter + 1))
            return true;
        else if (DateTime.Now.Year == Year + 1 && GetQuarter(DateTime.Now) == 1 && Quarter == 4)
            return true;
        return false;
    }

    private void SetControlEnableFalse(bool IsEnable)
    {
        txtDescOfIncident.ControlType = Controls_LongDescription_LongDescription.CtrlType.Label;
        txtIfYesWhy.ControlType = Controls_LongDescription_LongDescription.CtrlType.Label;
        txtDescTretment.ControlType = Controls_LongDescription_LongDescription.CtrlType.Label;
        lblComments.ControlType = Controls_LongDescription_LongDescription.CtrlType.Label;
        txtDateOfLastReview.Enabled = IsEnable;
        txtAdjuster.Enabled = IsEnable;
        txtSedgwickTeamLeader.Enabled = IsEnable;
        txtDateOfFileReview.Enabled = IsEnable;
        // gvMgtSection.Enabled = IsEnable;
        //txtOverallComments.ControlType = Controls_LongDescription_LongDescription.CtrlType.Label;
        btnSave.Visible = IsEnable;
        rblDisposition.Enabled = IsEnable;

    }

    #endregion

    protected void btnSave_Click(object sender, EventArgs e)
    {
        decimal PK_SCR;
        decimal PK_SCG = 0;
        Sedgwick_Claim_Review objSCR = new Sedgwick_Claim_Review();
        if (Convert.ToDecimal(Request.QueryString["PK_SCR"]) > 0)
            PK_SCR = Convert.ToDecimal(Request.QueryString["PK_SCR"]);
        else
        {
            Sedgwick_Claim_Group objSCG = new Sedgwick_Claim_Group();
            if (Session["dtClaimReviewGroupSearch"] != null)
            {
                DataTable dtSearch = (DataTable)Session["dtClaimReviewGroupSearch"];
                if (dtSearch.Rows.Count > 0)
                {
                    DataRow drSearch = dtSearch.Rows[0];
                    decimal FK_LU_Sedgwick_Field_Office = Convert.ToDecimal(drSearch["FK_LU_Sedgwick_Field_Office"]);

                    objSCG.FK_LU_Sedgwick_Field_Office = FK_LU_Sedgwick_Field_Office;
                    objSCG.Year = Convert.ToInt32(drSearch["Year"].ToString());
                    objSCG.Quarter = Convert.ToInt32(drSearch["Quarter"].ToString());
                    objSCG.Review_Complete = rblDisposition.SelectedValue.ToString();
                    objSCG.Update_Date = DateTime.Now.Date;
                    objSCG.Updated_By = clsSession.UserID;
                    PK_SCG = objSCG.Insert();
                }
            }
            objSCR.PK_Sedgwick_Claim_Review = Convert.ToDecimal(Request.QueryString["PK_SCR"]);
            objSCR.FK_Sedgwick_Claim_Group = Convert.ToDecimal(PK_SCG);
            objSCR.FK_Workers_Comp_Claims = Convert.ToDecimal(Request.QueryString["PK_WCC_ID"]);
            if (rblDisposition.SelectedValue == "")
                objSCR.Claim_Review_Complete = "N";
            else
                objSCR.Claim_Review_Complete = rblDisposition.SelectedValue.ToString();

            objSCR.Overall_Comments = txtOverallComments.Text;
            objSCR.Broker_Claim_Comments = txtBrokerClaimComments.Text;
            objSCR.Date_Of_File_Review = clsGeneral.FormatDateToStore(txtDateOfFileReview.Text);
            objSCR.Date_Of_Last_Review = clsGeneral.FormatDateToStore(txtDateOfLastReview.Text);
            objSCR.Sedgwick_Team_Leader = txtSedgwickTeamLeader.Text.ToString();
            objSCR.Adjuster = txtAdjuster.Text.ToString();
            objSCR.Update_Date = DateTime.Now.Date;
            objSCR.Updated_By = clsSession.UserID;
            objSCR.FK_Employee_Id = clsSession.CurrentLoginEmployeeId;
            PK_SCR = objSCR.Insert();
        }

        objSCR.PK_Sedgwick_Claim_Review = Convert.ToDecimal(PK_SCR);
        objSCR.FK_Workers_Comp_Claims = Convert.ToDecimal(Request.QueryString["PK_WCC_ID"]);

        SaveMgtSectionComment(gv_Child_Investigation, hdnMgtSection_Investigation, gv_NestedChild_Investigation, ddlRLCM_Medical_Score_Investigation, PK_SCR, objSCR);
        SaveMgtSectionComment(gv_Child_Subrogation, hdnMgtSection_Subrogation, gv_NestedChild_Subrogation, ddlRLCM_Medical_Score_Subrogation, PK_SCR, objSCR);
        SaveMgtSectionComment(gv_Child_Medical, hdnMgtSection_Medical, gv_NestedChild_Medical, ddlRLCM_Medical_Score_Medical, PK_SCR, objSCR);
        SaveMgtSectionComment(gv_Child_Disability, hdnMgtSection_Disability, gv_NestedChild_Disability, ddlRLCM_Disability_Score_Disability, PK_SCR, objSCR);
        SaveMgtSectionComment(gv_Child_ClosurePlans, hdnMgtSection_ClosurePlans, gv_NestedChild_ClosurePlans, ddlRLCM_ClosurePlans_Score_ClosurePlans, PK_SCR, objSCR);
        SaveMgtSectionComment(gv_Child_Reserves, hdnMgtSection_Reserves, gv_NestedChild_Reserves, ddlRLCM_Reserves_Score_Reserves, PK_SCR, objSCR);
        SaveMgtSectionComment(gv_Child_Leadership, hdnMgtSection_Leadership, gv_NestedChild_Leadership, ddlRLCM_Leadership_Score_Leadership, PK_SCR, objSCR);

        if (rblDisposition.SelectedValue == "")
            objSCR.Claim_Review_Complete = "N";
        else
            objSCR.Claim_Review_Complete = rblDisposition.SelectedValue.ToString();

        objSCR.Overall_Comments = txtOverallComments.Text;
        objSCR.Broker_Claim_Comments = txtBrokerClaimComments.Text;
        objSCR.Date_Of_File_Review = clsGeneral.FormatDateToStore(txtDateOfFileReview.Text);
        objSCR.Date_Of_Last_Review = clsGeneral.FormatDateToStore(txtDateOfLastReview.Text);
        objSCR.Sedgwick_Team_Leader = txtSedgwickTeamLeader.Text.ToString();
        objSCR.Adjuster = txtAdjuster.Text.ToString();
        objSCR.Update_Date = DateTime.Now.Date;
        objSCR.Updated_By = clsSession.UserID;
        //}
        objSCR.Update();

        if (sender != null && e != null)
        {
            if (Request.QueryString["IsReviewAvailable"] != null)
                Response.Redirect("ClaimSummary.aspx?PK_WCC_ID=" + Request.QueryString["PK_WCC_ID"].ToString() + "&PK_SCR=" + PK_SCR.ToString() + "&IsSave=true&pnl=" + hdnPanel.Value + "&IsReviewAvailable=" + Request.QueryString["IsReviewAvailable"]);
            else
                Response.Redirect("ClaimSummary.aspx?PK_WCC_ID=" + Request.QueryString["PK_WCC_ID"].ToString() + "&PK_SCR=" + PK_SCR.ToString() + "&IsSave=true&pnl=" + hdnPanel.Value);
        }
        else
        {
            if (Session["dtClaimReviewGroupSearch"] != null)
            {
                //get the data table from session
                DataTable dtSearch = (DataTable)Session["dtClaimReviewGroupSearch"];
                //check datatable have atleast one row
                if (dtSearch.Rows.Count > 0)
                {
                    DataRow drSearch = dtSearch.Rows[0];

                    //get the values from each column of row
                    decimal FK_LU_Sedgwick_Field_Office = Convert.ToDecimal(drSearch["FK_LU_Sedgwick_Field_Office"]);
                    LU_Sedgwick_Field_Office objLSFO = new LU_Sedgwick_Field_Office(FK_LU_Sedgwick_Field_Office);
                    int Year = Convert.ToInt32(drSearch["Year"].ToString());
                    int Quarter = Convert.ToInt32(drSearch["Quarter"].ToString());

                    DataSet dsClaimInfo = Sedgwick_Claim_Group.ClaimReviewWorkSheetGroup_Search_New(FK_LU_Sedgwick_Field_Office, Year, Quarter, "Origin_Claim_Number", "asc", 1, 10, clsSession.CurrentLoginEmployeeId);

                    if (Request.QueryString["IsReviewAvailable"] != null)
                    {
                        if (Convert.ToString(Request.QueryString["IsReviewAvailable"]) == "true")
                            Response.Redirect("~/SONIC/ClaimInfo/WCClaimInfo.aspx?id=" + Encryption.Encrypt(Convert.ToString(Request.QueryString["PK_WCC_ID"])));
                    }

                    if (dsClaimInfo.Tables[0].Rows.Count > 0)
                    {
                        Response.Redirect("ClaimSearchGrid.aspx?Id=" + Encryption.Encrypt(Convert.ToString(FK_LU_Sedgwick_Field_Office)) + "&Year=" + Encryption.Encrypt(Convert.ToString(Year)) + "&Quarter=" + Encryption.Encrypt(Convert.ToString(Quarter)), true);
                    }
                    else
                    {
                        Response.Redirect("ClaimReviewWorkSheetGroupSearch.aspx", true);
                    }
                }
            }
        }

    }
    public void SaveMgtSectionComment(GridView gv_Child, HiddenField lblMgtSection, GridView gv_NestedChild, DropDownList ddlRLCM_Medical_Score, decimal PK_SCR, Sedgwick_Claim_Review objSCR)
    {

        //foreach (GridViewRow row in gvMgtSection.Rows)
        //{
        // GridView gv_Child = (GridView)row.FindControl("gv_Child");
        //HiddenField lblMgtSection = (HiddenField)row.FindControl("hdnMgtSection");

        foreach (GridViewRow Childrow in gv_Child.Rows)
        {
            int rowindex = Childrow.RowIndex;
            decimal PK_LU_Sedgwick_Evaluation = Convert.ToDecimal(gv_Child.DataKeys[rowindex].Value.ToString());
            ASP.controls_notes_notes_ascx txtRLCM_Comments = (ASP.controls_notes_notes_ascx)Childrow.FindControl("txtRLCM_Comments");
            HiddenField hdnPK_Sedgwick_Claim_RLCM_Comments = (HiddenField)Childrow.FindControl("hdnPK_Sedgwick_Claim_RLCM_Comments");
            Sedgwick_Claim_RLCM_Comments objSCRC = new Sedgwick_Claim_RLCM_Comments();
            objSCRC.Comments = txtRLCM_Comments.Text.ToString();

            decimal PK_Sedgwick_Claim_RLCM_Comments; // = Convert.ToDecimal(hdnPK_Sedgwick_Claim_RLCM_Comments.Value);

            if (hdnPK_Sedgwick_Claim_RLCM_Comments.Value != "")
                PK_Sedgwick_Claim_RLCM_Comments = Convert.ToDecimal(hdnPK_Sedgwick_Claim_RLCM_Comments.Value);
            else
                PK_Sedgwick_Claim_RLCM_Comments = 0;

            if (PK_Sedgwick_Claim_RLCM_Comments > 0)
                objSCRC.PK_Sedgwick_Claim_RLCM_Comments = PK_Sedgwick_Claim_RLCM_Comments;

            if (PK_SCR > 0)
                objSCRC.FK_Sedgwick_Claim_Review = Convert.ToDecimal(PK_SCR);

            objSCRC.FK_LU_Sedgwick_Evaluation = PK_LU_Sedgwick_Evaluation;
            objSCRC.Management_Section = lblMgtSection.Value.ToString();
            objSCRC.Update_Date = DateTime.Now.Date;
            objSCRC.Updated_By = clsSession.UserID;
            if (PK_Sedgwick_Claim_RLCM_Comments == 0)
                objSCRC.Insert();
            else
                objSCRC.Update();
        }

        // GridView gv_NestedChild = (GridView)row.FindControl("gv_NestedChild");

        foreach (GridViewRow ActionPlanrow in gv_NestedChild.Rows)
        {
            DropDownList ddlRLCM_Sedgwick = (DropDownList)ActionPlanrow.FindControl("ddlRLCM_Sedgwick");
            TextBox txtTargetDate = (TextBox)ActionPlanrow.FindControl("txtTargetDate");
            // TextBox txtActionItem = (TextBox)ActionPlanrow.FindControl("txtActionItem");
            ASP.controls_notes_notes_ascx txtActionItem = (ASP.controls_notes_notes_ascx)ActionPlanrow.FindControl("txtActionItem");
            TextBox txtActualDate = (TextBox)ActionPlanrow.FindControl("txtActualDate");
            HiddenField hdnPK_Sedgwick_Claim_Action_Plan = (HiddenField)ActionPlanrow.FindControl("hdnPK_Sedgwick_Claim_Action_Plan");

            Sedgwick_Claim_Action_Plan objCAP = new Sedgwick_Claim_Action_Plan();

            objCAP.Actual_Date = clsGeneral.FormatNullDateToStore(txtActualDate.Text);
            objCAP.Target_Date = clsGeneral.FormatNullDateToStore(txtTargetDate.Text);
            objCAP.RLCM_Sedgwick = ddlRLCM_Sedgwick.SelectedValue.ToString();
            objCAP.Action_Item = txtActionItem.Text.ToString();
            objCAP.Management_Section = lblMgtSection.Value.ToString();
            objCAP.FK_Sedgwick_Claim_Review = Convert.ToDecimal(PK_SCR);
            objCAP.Update_Date = DateTime.Now.Date;
            objCAP.Updated_By = clsSession.UserID;
            decimal PK_Sedgwick_Claim_Action_Plan;
            if (hdnPK_Sedgwick_Claim_Action_Plan.Value != "")
                PK_Sedgwick_Claim_Action_Plan = Convert.ToDecimal(hdnPK_Sedgwick_Claim_Action_Plan.Value);
            else
                PK_Sedgwick_Claim_Action_Plan = 0;

            if (PK_Sedgwick_Claim_Action_Plan > 0)
                objCAP.PK_Sedgwick_Claim_Action_Plan = PK_Sedgwick_Claim_Action_Plan;

            objCAP.Update_Date = DateTime.Now.Date;
            objCAP.Updated_By = clsSession.UserID;

            if (PK_Sedgwick_Claim_Action_Plan == 0)
                objCAP.Insert();
            else
                objCAP.Update();
        }

        // DropDownList ddlRLCM_Medical_Score = (DropDownList)row.FindControl("ddlRLCM_Medical_Score");
        if (lblMgtSection.Value == "Medical")
        {
            if (ddlRLCM_Medical_Score.SelectedIndex > 0)
                objSCR.Medical_Score = Convert.ToInt32(ddlRLCM_Medical_Score.SelectedValue.ToString());
        }
        else if (lblMgtSection.Value == "Disability")
        {
            if (ddlRLCM_Medical_Score.SelectedIndex > 0)
                objSCR.Diability_Score = Convert.ToInt32(ddlRLCM_Medical_Score.SelectedValue.ToString());
        }
        else if (lblMgtSection.Value == "Leadership")
        {
            if (ddlRLCM_Medical_Score.SelectedIndex > 0)
                objSCR.Leadership_Score = Convert.ToInt32(ddlRLCM_Medical_Score.SelectedValue.ToString());
        }
        else if (lblMgtSection.Value == "Investigation")
        {
            if (ddlRLCM_Medical_Score.SelectedIndex > 0)
                objSCR.Litigation_Score = Convert.ToInt32(ddlRLCM_Medical_Score.SelectedValue.ToString());
        }
        else if (lblMgtSection.Value == "Subrogation")
        {
            if (ddlRLCM_Medical_Score.SelectedIndex > 0)
                objSCR.Subrogation_Score = Convert.ToInt32(ddlRLCM_Medical_Score.SelectedValue.ToString());
        }
        else if (lblMgtSection.Value == "Closure Plan")
        {
            if (ddlRLCM_Medical_Score.SelectedIndex > 0)
                objSCR.Settlemente_Closure_Score = Convert.ToInt32(ddlRLCM_Medical_Score.SelectedValue.ToString());
        }
        else if (lblMgtSection.Value == "Reserves")
        {
            if (ddlRLCM_Medical_Score.SelectedIndex > 0)
                objSCR.Reserves_Score = Convert.ToInt32(ddlRLCM_Medical_Score.SelectedValue.ToString());
        }

    }
    protected void btnReturn_Click(object sender, EventArgs e)
    {
        if (hdnIsSave.Value == "true")
        {
            btnSave_Click(null, null);
        }
        else
        {
            if (Session["dtClaimReviewGroupSearch"] != null)
            {
                //get the data table from session
                DataTable dtSearch = (DataTable)Session["dtClaimReviewGroupSearch"];
                //check datatable have at least one row
                if (dtSearch.Rows.Count > 0)
                {
                    DataRow drSearch = dtSearch.Rows[0];

                    //get the values from each column of row
                    decimal FK_LU_Sedgwick_Field_Office = Convert.ToDecimal(drSearch["FK_LU_Sedgwick_Field_Office"]);
                    LU_Sedgwick_Field_Office objLSFO = new LU_Sedgwick_Field_Office(FK_LU_Sedgwick_Field_Office);
                    int Year = Convert.ToInt32(drSearch["Year"].ToString());
                    int Quarter = Convert.ToInt32(drSearch["Quarter"].ToString());

                    DataSet dsClaimInfo = Sedgwick_Claim_Group.ClaimReviewWorkSheetGroup_Search_New(FK_LU_Sedgwick_Field_Office, Year, Quarter, "Origin_Claim_Number", "asc", 1, 10, clsSession.CurrentLoginEmployeeId);

                    if (Request.QueryString["IsReviewAvailable"] != null)
                    {
                        if (Convert.ToString(Request.QueryString["IsReviewAvailable"]) == "true")
                            Response.Redirect("~/SONIC/ClaimInfo/WCClaimInfo.aspx?id=" + Encryption.Encrypt(Convert.ToString(Request.QueryString["PK_WCC_ID"])));
                    }

                    if (dsClaimInfo.Tables[0].Rows.Count > 0)
                    {
                        Response.Redirect("ClaimSearchGrid.aspx?Id=" + Encryption.Encrypt(Convert.ToString(FK_LU_Sedgwick_Field_Office)) + "&Year=" + Encryption.Encrypt(Convert.ToString(Year)) + "&Quarter=" + Encryption.Encrypt(Convert.ToString(Quarter)), true);
                    }
                    else
                    {
                        Response.Redirect("ClaimReviewWorkSheetGroupSearch.aspx", true);
                    }
                }
            }
            else
            {
                if (Request.QueryString["IsReviewAvailable"] != null)
                {
                    if (Convert.ToString(Request.QueryString["IsReviewAvailable"]) == "true")
                        Response.Redirect("~/SONIC/ClaimInfo/WCClaimInfo.aspx?id=" + Encryption.Encrypt(Convert.ToString(Request.QueryString["PK_WCC_ID"])));
                }
                else
                {
                    Response.Redirect("ClaimReviewWorkSheetGroupSearch.aspx", true);
                }
            }
        }
    }

    /// <summary>
    /// handles Add Attachment button click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnAddAttachment_Click(string sender)
    {
        if (Convert.ToDecimal(Request.QueryString["PK_SCR"]) > 0)
        {
            // add attachment if any.
            Attachments.FK_Sedgwick_Claim_Review = Convert.ToDecimal(Request.QueryString["PK_SCR"]);
            Attachments.Add();
            // Bind the attachment detail to view the added attachment
            BindAttachmentDetails();
            // show attachment panel as the page is loaded again
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(11);", true);
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "", "javascript:alert('Please save the Property Security Information first');", true);
        }
    }

    #region "Attachment"

    /// <summary>
    /// Binds the attachment details
    /// </summary>
    private void BindAttachmentDetails()
    {
        dvAttachment.Style["display"] = "block";
        AttachDetails.Bind();
    }

    #endregion

    private void SetValidations()
    {
        #region "ClaimReview"

        string strCtrlsIDsClaimReview = "";
        string strMessagesClaimReview = "";
        DataTable dtFieldsClaimReview = clsScreen_Validators.SelectByScreen(204).Tables[0];
        dtFieldsClaimReview.DefaultView.RowFilter = "IsRequired = '1'";
        dtFieldsClaimReview = dtFieldsClaimReview.DefaultView.ToTable();
        //MenuAsterisk1.Style["display"] = (dtFieldsClaimReview.Select("LeftMenuIndex = 2").Length > 0) ? "inline-block" : "none";
        if (dtFieldsClaimReview.Rows.Count > 0)
            Span70.Style["display"] = "inline-block";

        foreach (DataRow drFieldIdentification in dtFieldsClaimReview.Rows)
        {
            #region " set validation control IDs and messages "
            switch (Convert.ToString(drFieldIdentification["Field_Name"]))
            {
                case "Adjuster": strCtrlsIDsClaimReview += txtAdjuster.ClientID + ","; strMessagesClaimReview += "Please enter [Claim Review]/Adjuster" + ","; Span65.Style["display"] = "inline-block"; break;
                case "Sedgwick Team Leader": strCtrlsIDsClaimReview += txtSedgwickTeamLeader.ClientID + ","; strMessagesClaimReview += "Please enter [Claim Review]/Sedgwick Team Leader" + ","; Span66.Style["display"] = "inline-block"; break;
                case "Date of Last Review": strCtrlsIDsClaimReview += txtDateOfLastReview.ClientID + ","; strMessagesClaimReview += "Please enter [Claim Review]/Date of Last Review" + ","; Span69.Style["display"] = "inline-block"; break;
                case "Claim Review Complete?": strCtrlsIDsClaimReview += rblDisposition.ClientID + ","; strMessagesClaimReview += "Please select [Claim Review]/Claim Review Complete?" + ","; Span2.Style["display"] = "inline-block"; break;
                case "Date of File Review": strCtrlsIDsClaimReview += txtDateOfFileReview.ClientID + ","; strMessagesClaimReview += "Please enter [Claim Review]/Date of File Review" + ","; Span67.Style["display"] = "inline-block"; break;
            }
            #endregion
        }

        #endregion


        #region "Investigation"

        dtFieldsClaimReview = new DataTable();
        dtFieldsClaimReview = clsScreen_Validators.SelectByScreen(205).Tables[0];
        dtFieldsClaimReview.DefaultView.RowFilter = "IsRequired = '1'";
        dtFieldsClaimReview = dtFieldsClaimReview.DefaultView.ToTable();
        if (dtFieldsClaimReview.Rows.Count > 0)
            Span71.Style["display"] = "inline-block";
        foreach (DataRow drFieldIdentification in dtFieldsClaimReview.Rows)
        {
            #region " set validation control IDs and messages "
            switch (Convert.ToString(drFieldIdentification["Field_Name"]))
            {
                case "RLCM Investigation Score": strCtrlsIDsClaimReview += ddlRLCM_Medical_Score_Investigation.ClientID + ","; strMessagesClaimReview += "Please enter [Investigation]/RLCM Investigation Score" + ","; Span3.Style["display"] = "inline-block"; break;
            }
            #endregion
        }
        #endregion


        #region "Subrogation"


        dtFieldsClaimReview = new DataTable();
        dtFieldsClaimReview = clsScreen_Validators.SelectByScreen(206).Tables[0];
        dtFieldsClaimReview.DefaultView.RowFilter = "IsRequired = '1'";
        dtFieldsClaimReview = dtFieldsClaimReview.DefaultView.ToTable();
        if (dtFieldsClaimReview.Rows.Count > 0)
            Span72.Style["display"] = "inline-block";

        foreach (DataRow drFieldIdentification in dtFieldsClaimReview.Rows)
        {
            #region " set validation control IDs and messages "
            switch (Convert.ToString(drFieldIdentification["Field_Name"]))
            {
                case "RLCM Subrogation Score": strCtrlsIDsClaimReview += ddlRLCM_Medical_Score_Subrogation.ClientID + ","; strMessagesClaimReview += "Please enter [Subrogation]/RLCM Subrogation Score" + ","; Span4.Style["display"] = "inline-block"; break;
            }
            #endregion
        }

        #endregion


        #region "Medical"

        dtFieldsClaimReview = new DataTable();
        dtFieldsClaimReview = clsScreen_Validators.SelectByScreen(207).Tables[0];
        dtFieldsClaimReview.DefaultView.RowFilter = "IsRequired = '1'";
        dtFieldsClaimReview = dtFieldsClaimReview.DefaultView.ToTable();
        if (dtFieldsClaimReview.Rows.Count > 0)
            Span73.Style["display"] = "inline-block";

        foreach (DataRow drFieldIdentification in dtFieldsClaimReview.Rows)
        {
            #region " set validation control IDs and messages "
            switch (Convert.ToString(drFieldIdentification["Field_Name"]))
            {
                case "RLCM Medical Score": strCtrlsIDsClaimReview += ddlRLCM_Medical_Score_Medical.ClientID + ","; strMessagesClaimReview += "Please enter [Medical]/RLCM Medical Score" + ","; Span5.Style["display"] = "inline-block"; break;
            }
            #endregion
        }

        #endregion


        #region "Disability"

        dtFieldsClaimReview = new DataTable();
        dtFieldsClaimReview = clsScreen_Validators.SelectByScreen(208).Tables[0];
        dtFieldsClaimReview.DefaultView.RowFilter = "IsRequired = '1'";
        dtFieldsClaimReview = dtFieldsClaimReview.DefaultView.ToTable();
        if (dtFieldsClaimReview.Rows.Count > 0)
            Span74.Style["display"] = "inline-block";


        foreach (DataRow drFieldIdentification in dtFieldsClaimReview.Rows)
        {
            #region " set validation control IDs and messages "
            switch (Convert.ToString(drFieldIdentification["Field_Name"]))
            {
                case "RLCM Disability Score": strCtrlsIDsClaimReview += ddlRLCM_Disability_Score_Disability.ClientID + ","; strMessagesClaimReview += "Please enter [Disability]/RLCM Disability Score" + ","; Span6.Style["display"] = "inline-block"; break;
            }
            #endregion
        }

        #endregion


        #region "Closure Plan"

        dtFieldsClaimReview = new DataTable();
        dtFieldsClaimReview = clsScreen_Validators.SelectByScreen(209).Tables[0];
        dtFieldsClaimReview.DefaultView.RowFilter = "IsRequired = '1'";
        dtFieldsClaimReview = dtFieldsClaimReview.DefaultView.ToTable();

        if (dtFieldsClaimReview.Rows.Count > 0)
            Span75.Style["display"] = "inline-block";

        foreach (DataRow drFieldIdentification in dtFieldsClaimReview.Rows)
        {
            #region " set validation control IDs and messages "
            switch (Convert.ToString(drFieldIdentification["Field_Name"]))
            {
                case "RLCM Closure Plan Score": strCtrlsIDsClaimReview += ddlRLCM_ClosurePlans_Score_ClosurePlans.ClientID + ","; strMessagesClaimReview += "Please enter [Closure Plan]/RLCM Closure Plan Score" + ","; Span7.Style["display"] = "inline-block"; break;
            }
            #endregion
        }

        #endregion


        #region "Reserves"

        dtFieldsClaimReview = new DataTable();
        dtFieldsClaimReview = clsScreen_Validators.SelectByScreen(210).Tables[0];
        dtFieldsClaimReview.DefaultView.RowFilter = "IsRequired = '1'";
        dtFieldsClaimReview = dtFieldsClaimReview.DefaultView.ToTable();

        if (dtFieldsClaimReview.Rows.Count > 0)
            Span76.Style["display"] = "inline-block";

        foreach (DataRow drFieldIdentification in dtFieldsClaimReview.Rows)
        {
            #region " set validation control IDs and messages "
            switch (Convert.ToString(drFieldIdentification["Field_Name"]))
            {
                case "RLCM Reserves Score": strCtrlsIDsClaimReview += ddlRLCM_Reserves_Score_Reserves.ClientID + ","; strMessagesClaimReview += "Please enter [Reserves]/RLCM Reserves Score" + ","; Span8.Style["display"] = "inline-block"; break;
            }
            #endregion
        }


        #endregion


        #region "Leadership "

        dtFieldsClaimReview = new DataTable();
        dtFieldsClaimReview = clsScreen_Validators.SelectByScreen(211).Tables[0];
        dtFieldsClaimReview.DefaultView.RowFilter = "IsRequired = '1'";
        dtFieldsClaimReview = dtFieldsClaimReview.DefaultView.ToTable();

        if (dtFieldsClaimReview.Rows.Count > 0)
            Span77.Style["display"] = "inline-block";

        foreach (DataRow drFieldIdentification in dtFieldsClaimReview.Rows)
        {
            #region " set validation control IDs and messages "
            switch (Convert.ToString(drFieldIdentification["Field_Name"]))
            {
                case "RLCM Leadership Score": strCtrlsIDsClaimReview += ddlRLCM_Leadership_Score_Leadership.ClientID + ","; strMessagesClaimReview += "Please enter [Leadership]/RLCM Leadership Score" + ","; Span68.Style["display"] = "inline-block"; break;
            }
            #endregion
        }

        #endregion


        #region "Review Scorecard"

        dtFieldsClaimReview = new DataTable();
        dtFieldsClaimReview = clsScreen_Validators.SelectByScreen(212).Tables[0];
        dtFieldsClaimReview.DefaultView.RowFilter = "IsRequired = '1'";
        dtFieldsClaimReview = dtFieldsClaimReview.DefaultView.ToTable();

        if (dtFieldsClaimReview.Rows.Count > 0)
            Span78.Style["display"] = "inline-block";

        foreach (DataRow drFieldIdentification in dtFieldsClaimReview.Rows)
        {
            #region " set validation control IDs and messages "
            switch (Convert.ToString(drFieldIdentification["Field_Name"]))
            {
                case "Claim Review Complete?": strCtrlsIDsClaimReview += rblDisposition.ClientID + ","; strMessagesClaimReview += "Please enter [Review Scorecard]/Claim Review Complete?" + ","; Span2.Style["display"] = "inline-block"; break;
                case "RLCM Comments": strCtrlsIDsClaimReview += txtOverallComments.ClientID + ","; strMessagesClaimReview += "Please enter [Review Scorecard]/RLCM Comments" + ","; Span1.Style["display"] = "inline-block"; break;
            }
            #endregion
        }


        #endregion

        strCtrlsIDsClaimReview = strCtrlsIDsClaimReview.TrimEnd(',');
        strMessagesClaimReview = strMessagesClaimReview.TrimEnd(',');

        hdnControlIDsClaimReview.Value = strCtrlsIDsClaimReview;
        hdnErrorMsgsClaimReview.Value = strMessagesClaimReview;
    }
}