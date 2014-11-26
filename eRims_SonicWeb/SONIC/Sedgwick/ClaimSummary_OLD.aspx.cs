using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERIMS.DAL;
using BAL;
using System.Data;

public partial class SONIC_Sedgwick_ClaimSummary : clsBasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["PK_WCC_ID"] != null)
                BindControls(Convert.ToDecimal(Request.QueryString["PK_WCC_ID"]));

            //Set the first panel active
            int intPanle = 1;
            if (int.TryParse(Convert.ToString(Request.QueryString["pnl"]), out intPanle))
                Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(" + intPanle.ToString() + ");", true);
            else
                Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(1);", true);

            if (Request.QueryString["IsSave"] != null)
            {
                hdnIsSave.Value = Request.QueryString["IsSave"].ToString();
                //if (!(Convert.ToBoolean(Request.QueryString["IsSave"])))
                //{
                //    hdnIsSave.Value = Request.QueryString["IsSave"].ToString();
                //    //Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(" + intPanle.ToString() + ");", true);
                //}
            }
            if (App_Access == AccessType.View_Only)
                SetControlEnableFalse(false);
            else
                btnReturn.Attributes.Add("onclick", "return CheckIsSaveRecord();");

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

        txtName.Text = drData["Last_Name"] + ", " + drData["First_Name"] + " " + (string.IsNullOrEmpty(drData["Middle_Name"].ToString()) ? "" : drData["Middle_Name"].ToString()).Trim();

        txtAssociateName.Text = drData["First_Name"] + " " + (string.IsNullOrEmpty(drData["Middle_Name"].ToString()));  //For Review Screen

        txtDtOfBirth.Text = clsGeneral.FormatDBNullDateToDisplay(drData["Date_Of_Birth"].ToString());
        if (!(string.IsNullOrEmpty(drData["Date_Of_Birth"].ToString())))
        {
            if (Convert.ToDateTime(drData["Date_Of_Birth"]) != (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue)
                txtAge.Text = GetAge(Convert.ToDateTime(drData["Date_Of_Birth"]));
        }
        txtDateOfHire.Text = clsGeneral.FormatDBNullDateToDisplay(drData["Hire_Date"]);
        txtJobTitle.Text = (drData["Job_Title"] != null) ? Convert.ToString(drData["Job_Title"]) : "";
        txtEmployementStatus.Text = Convert.ToString(drData["Active_Inactive_Leave"]);
        txtDateOfIncident.Text = drData["Date_Of_Incident"].ToString();

        txtDateOfInjury.Text = drData["Date_Of_Incident"].ToString(); //For Review Screen
        txtJobTitle_Review.Text = (drData["Job_Title"] != null) ? Convert.ToString(drData["Job_Title"]) : ""; //For Review Screen


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
        //lblFullDaysModifiedDuty.Text = drWorkers_Comp_Claims["RTW_Full_Days_Modified_Duty"] == DBNull.Value ? "" : GetYesNo(Convert.ToString(drWorkers_Comp_Claims["RTW_Full_Days_Modified_Duty"]));
        txtHoursWorkedonModifiedDuty.Text = drData["RTW_Hours_Modified_Duty"] != DBNull.Value ? String.Format("{0:N2}", Convert.ToDecimal(drData["RTW_Hours_Modified_Duty"])) : "";
        txtReturnToWorkOccup.Text = Convert.ToString(drData["RTW_Occupation"]);
        txtReturnToWorkDemand.Text = Convert.ToString(drData["RTW_Demand"]);
        txtReturnToWorkSchedule.Text = Convert.ToString(drData["RTW_Schedule"]);
        //lblDateModifiedDutyAval.Text = drWorkers_Comp_Claims["RTW_Date_Modified_Duty_Available"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drWorkers_Comp_Claims["RTW_Date_Modified_Duty_Available"]));
        //lblDateModifiedDutyOffered.Text = drWorkers_Comp_Claims["RTW_Date_Modified_Duty_Offered"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drWorkers_Comp_Claims["RTW_Date_Modified_Duty_Offered"]));
        //lblDateModifiedDutyAccepted.Text = drWorkers_Comp_Claims["RTW_Date_Modified_Duty_Accepted"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drWorkers_Comp_Claims["RTW_Date_Modified_Duty_Accepted"]));
        //lblDateNotified.Text = drWorkers_Comp_Claims["RTW_Date_Notified"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drWorkers_Comp_Claims["RTW_Date_Notified"]));
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
            lblYear.Text = objSCG.Year.ToString();
            lblQuarter.Text = objSCG.Quarter.ToString();
            txtSedgwickFieldOffice.Text = objLSFO.Fld_Desc.ToString(); // For Claim Review

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
                lblTotalScoringClassifcatn.Text = drData["Year_SCoreClassification"].ToString();
            }
        }

        if (Session["dtClaimReviewGroupSearch"] != null)
        {
            DataTable dtSearch = (DataTable)Session["dtClaimReviewGroupSearch"];
            if (dtSearch.Rows.Count > 0)
            {
                DataRow drSearch = dtSearch.Rows[0];
                decimal FK_LU_Sedgwick_Field_Office = Convert.ToDecimal(drSearch["FK_LU_Sedgwick_Field_Office"]);

                LU_Sedgwick_Field_Office objLSFO = new LU_Sedgwick_Field_Office(FK_LU_Sedgwick_Field_Office);
                if (!string.IsNullOrEmpty(objLSFO.Date_Of_Last_Review.ToString()))
                {
                    txtDateOfLastReview.Text = clsGeneral.FormatDateToDisplay(objLSFO.Date_Of_Last_Review.Value);
                }
            }
        }

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
        DataSet dsClaimReviewList = LU_Sedgwick_Evaluation.SelectAllDistinctMgtSection();
        DataTable dtWCTransList = dsClaimReviewList.Tables[0];
        gvMgtSection.DataSource = dtWCTransList;
        gvMgtSection.DataBind();
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
                else if (lblMgtSection.Value == "Litigation")
                    ddlRLCM_Medical_Score.SelectedValue = objSCR.Litigation_Score.ToString();
                else if (lblMgtSection.Value == "Subrogation")
                    ddlRLCM_Medical_Score.SelectedValue = objSCR.Subrogation_Score.ToString();
                else if (lblMgtSection.Value == "Settlement/Claim Closure")
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
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            HiddenField hdn = (HiddenField)e.Row.FindControl("hdnRLCM");
            DropDownList ddl = (DropDownList)e.Row.FindControl("ddlRLCM_Sedgwick");
            ddl.SelectedValue = hdn.Value;
            Image imgPlus = (Image)e.Row.FindControl("imgPlus");
            //TextBox txtActionItem = (TextBox)e.Row.FindControl("txtActionItem");
            ASP.controls_notes_notes_ascx txtActionItem = (ASP.controls_notes_notes_ascx)e.Row.FindControl("txtActionItem");
            HiddenField hdnPK_Sedgwick_Claim_Action_Plan = (HiddenField)e.Row.FindControl("hdnPK_Sedgwick_Claim_Action_Plan");
           // imgPlus.Attributes.Add("onclick", "OpenActionItemPopup('" + txtActionItem.ClientID.ToString() + "')");
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
            //Label lblMgtSection = (Label)e.Row.FindControl("lblMgtSection");  
            //string txtempid = lblMgtSection.Text;
            GridViewRow gvr1 = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
            string PK_ID = e.CommandArgument.ToString();

            int rowIndex = 0;
            DataSet dsNestedClaimReviewList = Sedgwick_Claim_Action_Plan.SelectBy_MgtSection(PK_ID, Convert.ToDecimal(Request.QueryString["PK_SCR"]));
            DataTable dtNestedTransList = dsNestedClaimReviewList.Tables[0];

            DataTable dt = GetTableWithNoData(); // get select column header only records not required
            DataRow dr;
            GridView gv_NestedChild = (GridView)gvMgtSection.Rows[gvr1.RowIndex].FindControl("gv_NestedChild");
            foreach (GridViewRow gvr in gv_NestedChild.Rows)
            {
                dr = dt.NewRow();

                DropDownList ddlRLCM_Sedgwick = gvr.FindControl("ddlRLCM_Sedgwick") as DropDownList;
                HiddenField hdnPK_Sedgwick_Claim_Action_Plan = gvr.FindControl("hdnPK_Sedgwick_Claim_Action_Plan") as HiddenField;
                TextBox txtTargetDate = gvr.FindControl("txtTargetDate") as TextBox;
                TextBox txtActualDate = gvr.FindControl("txtActualDate") as TextBox;
               // TextBox txtActionItem = gvr.FindControl("txtActionItem") as TextBox;
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
            //AddNewRow(PK_ID, (GridView)gvMgtSection.Rows[gvr.RowIndex].FindControl("gv_NestedChild"));
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
        gvMgtSection.Enabled = IsEnable;
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
            objSCR.Date_Of_File_Review = clsGeneral.FormatDateToStore(txtDateOfFileReview.Text);
            objSCR.Date_Of_Last_Review = clsGeneral.FormatDateToStore(txtDateOfLastReview.Text);
            objSCR.Sedgwick_Team_Leader = txtSedgwickTeamLeader.Text.ToString();
            objSCR.Adjuster = txtAdjuster.Text.ToString();
            objSCR.Update_Date = DateTime.Now.Date;
            objSCR.Updated_By = clsSession.UserID;
            PK_SCR = objSCR.Insert();
        }

        foreach (GridViewRow row in gvMgtSection.Rows)
        {
            GridView gv_Child = (GridView)row.FindControl("gv_Child");
            HiddenField lblMgtSection = (HiddenField)row.FindControl("hdnMgtSection");

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

            GridView gv_NestedChild = (GridView)row.FindControl("gv_NestedChild");

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


            objSCR.PK_Sedgwick_Claim_Review = Convert.ToDecimal(PK_SCR);
            objSCR.FK_Workers_Comp_Claims = Convert.ToDecimal(Request.QueryString["PK_WCC_ID"]);
            DropDownList ddlRLCM_Medical_Score = (DropDownList)row.FindControl("ddlRLCM_Medical_Score");
            if (lblMgtSection.Value == "Medical")
                objSCR.Medical_Score = Convert.ToInt32(ddlRLCM_Medical_Score.SelectedValue.ToString());
            else if (lblMgtSection.Value == "Disability")
                objSCR.Diability_Score = Convert.ToInt32(ddlRLCM_Medical_Score.SelectedValue.ToString());
            else if (lblMgtSection.Value == "Leadership")
                objSCR.Leadership_Score = Convert.ToInt32(ddlRLCM_Medical_Score.SelectedValue.ToString());
            else if (lblMgtSection.Value == "Litigation")
                objSCR.Litigation_Score = Convert.ToInt32(ddlRLCM_Medical_Score.SelectedValue.ToString());
            else if (lblMgtSection.Value == "Subrogation")
                objSCR.Subrogation_Score = Convert.ToInt32(ddlRLCM_Medical_Score.SelectedValue.ToString());
            else if (lblMgtSection.Value == "Settlement/Claim Closure")
                objSCR.Settlemente_Closure_Score = Convert.ToInt32(ddlRLCM_Medical_Score.SelectedValue.ToString());
            else if (lblMgtSection.Value == "Reserves")
                objSCR.Reserves_Score = Convert.ToInt32(ddlRLCM_Medical_Score.SelectedValue.ToString());

            if (rblDisposition.SelectedValue == "")
                objSCR.Claim_Review_Complete = "N";
            else
                objSCR.Claim_Review_Complete = rblDisposition.SelectedValue.ToString();

            objSCR.Overall_Comments = txtOverallComments.Text;
            objSCR.Date_Of_File_Review = clsGeneral.FormatDateToStore(txtDateOfFileReview.Text);
            objSCR.Date_Of_Last_Review = clsGeneral.FormatDateToStore(txtDateOfLastReview.Text);
            objSCR.Sedgwick_Team_Leader = txtSedgwickTeamLeader.Text.ToString();
            objSCR.Adjuster = txtAdjuster.Text.ToString();
            objSCR.Update_Date = DateTime.Now.Date;
            objSCR.Updated_By = clsSession.UserID;
        }
        objSCR.Update();
        if (sender != null && e != null)
        {
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

                    DataSet dsClaimInfo = Sedgwick_Claim_Group.ClaimReviewWorkSheetGroup_Search_New(FK_LU_Sedgwick_Field_Office, Year, Quarter, "Origin_Claim_Number", "asc", 1, 10,0);                    
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
                //check datatable have atleast one row
                if (dtSearch.Rows.Count > 0)
                {
                    DataRow drSearch = dtSearch.Rows[0];

                    //get the values from each column of row
                    decimal FK_LU_Sedgwick_Field_Office = Convert.ToDecimal(drSearch["FK_LU_Sedgwick_Field_Office"]);
                    LU_Sedgwick_Field_Office objLSFO = new LU_Sedgwick_Field_Office(FK_LU_Sedgwick_Field_Office);
                    int Year = Convert.ToInt32(drSearch["Year"].ToString());
                    int Quarter = Convert.ToInt32(drSearch["Quarter"].ToString());

                    DataSet dsClaimInfo = Sedgwick_Claim_Group.ClaimReviewWorkSheetGroup_Search_New(FK_LU_Sedgwick_Field_Office, Year, Quarter, "Origin_Claim_Number", "asc", 1, 10,0);
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
}