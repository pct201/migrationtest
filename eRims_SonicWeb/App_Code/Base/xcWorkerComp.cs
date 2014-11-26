#region Includes
using System;
using System.Collections.Generic;
using System.Text;
#endregion

namespace RIMS_Base
{

    [Serializable]
    public abstract class xcWorkerComp
    {

        #region Constructor
        public xcWorkerComp()
        {
             this._pK_Workers_Comp = -1;

             this._last_Name = string.Empty;
             this._first_Name = string.Empty;
             this._middle_Name = string.Empty;

            // this._claim_Number = string.Empty;
            //this._employee = string.Empty;
            //this._fK_Employee_Claimant = -1;
            //this._fK_State_Coverage = -1;
            //this._fK_State_Accident = -1;
            //this._incident_Date = DateTime.Now;
            //this._eE_RTW = string.Empty;
            //this._eE_RTW_Date = DateTime.Now;
            //this._rTW_Wage = string.Empty;
            //this._restricted_Duty = string.Empty;
            //this._restrict_Description = string.Empty;
            //this._restriction_Begin_Date = DateTime.Now;
            //this._restriction_End_Date = DateTime.Now;
            //this._est_Disability_Length_Weeks = -1;
            //this._est_Disability_Length_Days = -1;
            //this._act_Disability_Length_Weeks = -1;
            //this._act_Disability_Length_Days = -1;
            //this._mMI_Date = DateTime.Now;
            //this._pPD_Rating = string.Empty;
            //this._aWW_Dollars = -1;
            //this._aWW_Method = string.Empty;
            //this._tTD_Dollars = -1;
            //this._settlement_Method = string.Empty;
            //this._claim_Description = string.Empty;
            //this._nature = -1;
            //this._estimate = -1;
            //this._actual = -1;
            //this._fK_Claim_Cause = -1;
            //this._fK_Body_Parts = -1;
            //this._fK_Injury = -1;
            //this._fK_NCCI_Code = -1;
            //this._vocation_Rehab = string.Empty;
            //this._fK_WC_Major_Claim_Type = -1;
            //this._fK_WC_Minor_Claim_Type = -1;
            //this._convertible = string.Empty;
            //this._fK_Fraud_Claim = -1;
            //this._claim_Open_Date = DateTime.Now;
            //this._claim_Close_Date = DateTime.Now;
            //this._claim_Reopen_Date = DateTime.Now;
            //this._surgery_Required = string.Empty;
            //this._indemnity_Weeks = -1;
            //this._fK_State_Jurisdiction = -1;
            //this._fK_Employee = -1;
            //this._fK_Method_Pre_Injury_Wage = -1;
            //this._fK_Method_Of_Settlement = -1;
            //this._pre_Injury_Weekly_Wage = -1;
            //this._post_Injury_Weekly_Wage = -1;
            //this._present_Valuation_Future_Indemnity = -1;
            //this._fK_Injury_1 = -1;
            //this._benefits_Paid_To_Date_1 = -1;
            //this._weekly_Benefit_1 = -1;
            //this._fK_Injury_2 = -1;
            //this._benefits_Paid_To_Date_2 = -1;
            //this._weekly_Benefit_2 = -1;
            //this._fK_Injury_3 = -1;
            //this._benefits_Paid_To_Date_3 = -1;
            //this._weekly_Benefit_3 = -1;
            //this._fK_Injury_4 = -1;
            //this._benefits_Paid_To_Date_4 = -1;
            //this._weekly_Benefit_4 = -1;
            //this._fK_Injury_5 = -1;
            //this._benefits_Paid_To_Date_5 = -1;
            //this._weekly_Benefit_5 = -1;
            //this._fK_Beneficiary_Code_1 = -1;
            //this._beneficiary_DOB_1 = DateTime.Now;
            //this._fK_Beneficiary_Code_2 = -1;
            //this._beneficiary_DOB_2 = DateTime.Now;
            //this._fK_Beneficiary_Code_3 = -1;
            //this._beneficiary_DOB_3 = DateTime.Now;
            //this._fK_Beneficiary_Code_4 = -1;
            //this._beneficiary_DOB_4 = DateTime.Now;
            //this._fK_Beneficiary_Code_5 = -1;
            //this._beneficiary_DOB_5 = DateTime.Now;
            //this._suit_Date = DateTime.Now;
            //this._attorney_Disclosure_Date = DateTime.Now;
            //this._client_Attorney_Name = string.Empty;
            //this._client_Attorney_Address_1 = string.Empty;
            //this._client_Attorney_Address_2 = string.Empty;
            //this._client_Attorney_City = string.Empty;
            //this._fK_State_Client_Attorney = -1;
            //this._client_Attorney_Zip_Code = string.Empty;
            //this._client_Attorney_Phone = string.Empty;
            //this._client_Attorney_Fax = string.Empty;
            //this._defense_Attorney_Name = string.Empty;
            //this._defense_Attorney_Address_1 = string.Empty;
            //this._defense_Attorney_Address_2 = string.Empty;
            //this._defense_Attorney_City = string.Empty;
            //this._fK_State_Defense_Attorney = -1;
            //this._defense_Attorney_Zip_Code = string.Empty;
            //this._defense_Attorney_Phone = string.Empty;
            //this._defense_Attorney_Fax = string.Empty;
            //this._medical_Provider = string.Empty;
            //this._medical_Provider_Phone = string.Empty;
            //this._hospital = string.Empty;
            //this._mCO_Type = string.Empty;
            //this._death_Date = DateTime.Now;
            //this._delete_Reason = string.Empty;
            //this._date_Max_Med_Imp = DateTime.Now;
            //this._fK_Managed_Care_Org_Type = -1;
            //this._percentage_Impairment = -1;
            //this._percentage_Disability = -1;
            //this._fK_Employee_Reported = -1;
            //this._incident_Time = string.Empty;
            //this._within_24_Hours = string.Empty;
            //this._date_Reported = DateTime.Now;
            //this._date_Reported_Employer = DateTime.Now;
            //this._time_Reported = string.Empty;
            //this._location = string.Empty;
            //this._location_Address_1 = string.Empty;
            //this._location_Address_2 = string.Empty;
            //this._location_City = string.Empty;
            //this._fK_State_Location = -1;
            //this._location_Zip = string.Empty;
            //this._location_County = string.Empty;
            //this._location_Country = string.Empty;
            //this._location_Phone = string.Empty;
            //this._location_Fax = string.Empty;
            //this._date_Return = DateTime.Now;
            //this._employer_Contact = string.Empty;
            //this._employer_Contact_Date = DateTime.Now;
            //this._claimant_Contact = string.Empty;
            //this._claimant_Contact_Date = DateTime.Now;
            //this._statement_Claimant = string.Empty;
            //this._statement_Claimant_Date = DateTime.Now;
            //this._witness_1 = string.Empty;
            //this._statement_Witness_1 = string.Empty;
            //this._statement_Witness_1_Date = DateTime.Now;
            //this._witness_2 = string.Empty;
            //this._statement_Witness_2 = string.Empty;
            //this._statement_Witness_2_Date = DateTime.Now;
            //this._witness_3 = string.Empty;
            //this._statement_Witness_3 = string.Empty;
            //this._statement_Witness_3_Date = DateTime.Now;
            //this._updated_By = string.Empty;
            //this._update_Date = DateTime.Now;
            //this._claim_Report_Date = DateTime.Now;
            //this._auto_Liability_Recovery = -1;
            //this._loss_Adj_Expense_PTD = -1;
            //this._anuity_Purchased = -1;
            //this._legal_Expense_PTD = -1;
            //this._medical_Eval_PTD = -1;
            //this._fK_Cost_Center = string.Empty;
            //this._cREATED_DATE = DateTime.Now;
            //this._jurisdiction_Claim_Number = string.Empty;
            //this._healthTech_Incident_Number = string.Empty;
            //this._fk_initial_treatment = -1;
            //this._fK_NCCI_Classification_Code = string.Empty;
            //this._fK_NCCI_Cause = -1;
            //this._fK_NCCI_Nature = -1;
            //this._fK_County = string.Empty;
            //this._fK_Hazard_Code = -1;
            //this._claim_to_be_sent_to_FROI = string.Empty;
            //this._dt_FROI = DateTime.Now;
            //this._tTD_Benefits_Paid_to_Date = DateTime.Now;
            //this._settlement_yes_no = string.Empty;
            //this._annuity_Purchased = string.Empty;
            //this._diagnosis = string.Empty;
            //this._last_Office_Visit_Date = DateTime.Now;
            //this._next_scheduled_visit_date = DateTime.Now;
            //this._referral = string.Empty;
            //this._physical_Therapy = string.Empty;
            //this._physicians_Panel_Requested = string.Empty;
            //this._new_Treating_Physician = string.Empty;
            //this._date_incident_reported_to_CMS = DateTime.Now;
        }
        #endregion

        #region Private Variables

        private System.String _last_Name;
        private System.String _first_Name;
        private System.String _middle_Name;


        private System.Decimal _pK_ID;
        private System.String _cost_Center;
        private System.String _division_Name;

        private System.Int32 _pK_Workers_Comp;
        private System.String _claim_Number;
        private System.String _employee;
        private System.Decimal? _fK_Employee_Claimant;
        private System.Decimal? _fK_State_Coverage;
        private System.Decimal? _fK_State_Accident;
        private System.DateTime?_incident_Date;
        private System.String _eE_RTW;
        private System.DateTime? _eE_RTW_Date;
        private System.String _rTW_Wage;
        private System.String _restricted_Duty;
        private System.String _restrict_Description;
        private System.DateTime? _restriction_Begin_Date;
        private System.DateTime? _restriction_End_Date;
        private System.Decimal? _est_Disability_Length_Weeks;
        private System.Decimal? _est_Disability_Length_Days;
        private System.Decimal? _act_Disability_Length_Weeks;
        private System.Decimal? _act_Disability_Length_Days;
        private System.DateTime? _mMI_Date;
        private System.String _pPD_Rating;
        private System.Decimal? _aWW_Dollars;
        private System.String _aWW_Method;
        private System.Decimal? _tTD_Dollars;
        private System.String _settlement_Method;
        private System.String _claim_Description;
        private System.Decimal? _nature;
        private System.Decimal? _estimate;
        private System.Decimal? _actual;
        private System.Decimal? _fK_Claim_Cause;
        private System.Decimal? _fK_Body_Parts;
        private System.Decimal? _fK_Injury;
        private System.Decimal? _fK_NCCI_Code;
        private System.String _vocation_Rehab;
        private System.Decimal? _fK_WC_Major_Claim_Type;
        private System.Decimal? _fK_WC_Minor_Claim_Type;
        private System.String _convertible;
        private System.Decimal? _fK_Fraud_Claim;
        private System.DateTime? _claim_Open_Date;
        private System.DateTime? _claim_Close_Date;
        private System.DateTime? _claim_Reopen_Date;
        private System.String _surgery_Required;
        private System.Decimal? _indemnity_Weeks;
        private System.Decimal? _fK_State_Jurisdiction;
        private System.Decimal? _fK_Employee;
        private System.Decimal? _fK_Method_Pre_Injury_Wage;
        private System.Decimal? _fK_Method_Of_Settlement;
        private System.Decimal? _pre_Injury_Weekly_Wage;
        private System.Decimal? _post_Injury_Weekly_Wage;
        private System.Decimal? _present_Valuation_Future_Indemnity;
        private System.Decimal? _fK_Injury_1;
        private System.Decimal? _benefits_Paid_To_Date_1;
        private System.Decimal? _weekly_Benefit_1;
        private System.Decimal? _fK_Injury_2;
        private System.Decimal? _benefits_Paid_To_Date_2;
        private System.Decimal? _weekly_Benefit_2;
        private System.Decimal? _fK_Injury_3;
        private System.Decimal? _benefits_Paid_To_Date_3;
        private System.Decimal? _weekly_Benefit_3;
        private System.Decimal? _fK_Injury_4;
        private System.Decimal? _benefits_Paid_To_Date_4;
        private System.Decimal? _weekly_Benefit_4;
        private System.Decimal? _fK_Injury_5;
        private System.Decimal? _benefits_Paid_To_Date_5;
        private System.Decimal? _weekly_Benefit_5;
        private System.Decimal? _fK_Beneficiary_Code_1;
        private System.DateTime? _beneficiary_DOB_1;
        private System.Decimal? _fK_Beneficiary_Code_2;
        private System.DateTime? _beneficiary_DOB_2;
        private System.Decimal? _fK_Beneficiary_Code_3;
        private System.DateTime? _beneficiary_DOB_3;
        private System.Decimal? _fK_Beneficiary_Code_4;
        private System.DateTime? _beneficiary_DOB_4;
        private System.Decimal? _fK_Beneficiary_Code_5;
        private System.DateTime? _beneficiary_DOB_5;
        private System.DateTime? _suit_Date;
        private System.DateTime? _attorney_Disclosure_Date;
        private System.String _client_Attorney_Name;
        private System.String _client_Attorney_Address_1;
        private System.String _client_Attorney_Address_2;
        private System.String _client_Attorney_City;
        private System.Decimal? _fK_State_Client_Attorney;
        private System.String _client_Attorney_Zip_Code;
        private System.String _client_Attorney_Phone;
        private System.String _client_Attorney_Fax;
        private System.String _defense_Attorney_Name;
        private System.String _defense_Attorney_Address_1;
        private System.String _defense_Attorney_Address_2;
        private System.String _defense_Attorney_City;
        private System.Decimal? _fK_State_Defense_Attorney;
        private System.String _defense_Attorney_Zip_Code;
        private System.String _defense_Attorney_Phone;
        private System.String _defense_Attorney_Fax;
        private System.String _medical_Provider;
        private System.String _medical_Provider_Phone;
        private System.String _hospital;
        private System.String _mCO_Type;
        private System.DateTime? _death_Date;
        private System.String _delete_Reason;
        private System.DateTime? _date_Max_Med_Imp;
        private System.Decimal? _fK_Managed_Care_Org_Type;
        private System.Decimal? _percentage_Impairment;
        private System.Decimal? _percentage_Disability;
        private System.Decimal? _fK_Employee_Reported;
        private System.String _incident_Time;
        private System.String _within_24_Hours;
        private System.DateTime? _date_Reported;
        private System.DateTime? _date_Reported_Employer;
        private System.String _time_Reported;
        private System.String _location;
        private System.String _location_Address_1;
        private System.String _location_Address_2;
        private System.String _location_City;
        private System.Decimal? _fK_State_Location;
        private System.String _location_Zip;
        private System.String _location_County;
        private System.String _location_Country;
        private System.String _location_Phone;
        private System.String _location_Fax;
        private System.DateTime? _date_Return;
        private System.String _employer_Contact;
        private System.DateTime? _employer_Contact_Date;
        private System.String _claimant_Contact;
        private System.DateTime? _claimant_Contact_Date;
        private System.String _statement_Claimant;
        private System.DateTime? _statement_Claimant_Date;
        private System.String _witness_1;
        private System.String _statement_Witness_1;
        private System.DateTime? _statement_Witness_1_Date;
        private System.String _witness_2;
        private System.String _statement_Witness_2;
        private System.DateTime? _statement_Witness_2_Date;
        private System.String _witness_3;
        private System.String _statement_Witness_3;
        private System.DateTime? _statement_Witness_3_Date;
        private System.String _updated_By;
        private System.DateTime? _update_Date;
        private System.DateTime? _claim_Report_Date;
        private System.Decimal? _auto_Liability_Recovery;
        private System.Decimal? _loss_Adj_Expense_PTD;
        private System.Decimal? _anuity_Purchased;
        private System.Decimal? _legal_Expense_PTD;
        private System.Decimal? _medical_Eval_PTD;
        private System.String _fK_Cost_Center;
        private System.DateTime? _cREATED_DATE;
        private System.String _jurisdiction_Claim_Number;
        private System.String _healthTech_Incident_Number;
        private System.Decimal? _fk_initial_treatment;
        private System.String _fK_NCCI_Classification_Code;
        private System.Decimal? _fK_NCCI_Cause;
        private System.Decimal? _fK_NCCI_Nature;
        private System.String _fK_County;
        private System.Decimal? _fK_Hazard_Code;
        private System.String _claim_to_be_sent_to_FROI;
        private System.DateTime? _dt_FROI;
        private System.DateTime? _tTD_Benefits_Paid_to_Date;
        private System.String _settlement_yes_no;
        private System.String _annuity_Purchased;
        private System.String _diagnosis;
        private System.DateTime? _last_Office_Visit_Date;
        private System.DateTime? _next_scheduled_visit_date;
        private System.String _referral;
        private System.String _physical_Therapy;
        private System.String _physicians_Panel_Requested;
        private System.String _new_Treating_Physician;
        private System.DateTime? _date_incident_reported_to_CMS;

      

        #endregion

        #region Public Properties

        public System.Decimal PK_ID
        {
            get { return _pK_ID; }
            set { _pK_ID = value; }
        }

        public System.String Cost_Center
        {
            get { return _cost_Center; }
            set { _cost_Center = value; }
        }
        public System.String Division_Name
        {
            get { return _division_Name; }
            set { _division_Name = value; }
        }


        public System.String Last_Name
        {
            get { return _last_Name; }
            set { _last_Name = value; }
        }

        public System.String First_Name
        {
            get { return _first_Name; }
            set { _first_Name = value; }
        }

        public System.String Middle_Name
        {
            get { return _middle_Name; }
            set { _middle_Name = value; }
        }






        public System.Int32 PK_Workers_Comp
        {
            get { return _pK_Workers_Comp; }
            set { _pK_Workers_Comp = value; }
        }

        public System.String Claim_Number
        {
            get { return _claim_Number; }
            set { _claim_Number = value; }
        }

        public System.String Employee
        {
            get { return _employee; }
            set { _employee = value; }
        }

        public System.Decimal? FK_Employee_Claimant
        {
            get { return _fK_Employee_Claimant; }
            set { _fK_Employee_Claimant = value; }
        }

        public System.Decimal? FK_State_Coverage
        {
            get { return _fK_State_Coverage; }
            set { _fK_State_Coverage = value; }
        }

        public System.Decimal? FK_State_Accident
        {
            get { return _fK_State_Accident; }
            set { _fK_State_Accident = value; }
        }

        public System.DateTime? Incident_Date
        {
            get { return _incident_Date; }
            set { _incident_Date = value; }
        }

        public System.String EE_RTW
        {
            get { return _eE_RTW; }
            set { _eE_RTW = value; }
        }

        public System.DateTime? EE_RTW_Date
        {
            get { return _eE_RTW_Date; }
            set { _eE_RTW_Date = value; }
        }

        public System.String RTW_Wage
        {
            get { return _rTW_Wage; }
            set { _rTW_Wage = value; }
        }

        public System.String Restricted_Duty
        {
            get { return _restricted_Duty; }
            set { _restricted_Duty = value; }
        }

        public System.String Restrict_Description
        {
            get { return _restrict_Description; }
            set { _restrict_Description = value; }
        }

        public System.DateTime? Restriction_Begin_Date
        {
            get { return _restriction_Begin_Date; }
            set { _restriction_Begin_Date = value; }
        }

        public System.DateTime? Restriction_End_Date
        {
            get { return _restriction_End_Date; }
            set { _restriction_End_Date = value; }
        }

        public System.Decimal? Est_Disability_Length_Weeks
        {
            get { return _est_Disability_Length_Weeks; }
            set { _est_Disability_Length_Weeks = value; }
        }

        public System.Decimal? Est_Disability_Length_Days
        {
            get { return _est_Disability_Length_Days; }
            set { _est_Disability_Length_Days = value; }
        }

        public System.Decimal? Act_Disability_Length_Weeks
        {
            get { return _act_Disability_Length_Weeks; }
            set { _act_Disability_Length_Weeks = value; }
        }

        public System.Decimal? Act_Disability_Length_Days
        {
            get { return _act_Disability_Length_Days; }
            set { _act_Disability_Length_Days = value; }
        }

        public System.DateTime? MMI_Date
        {
            get { return _mMI_Date; }
            set { _mMI_Date = value; }
        }

        public System.String PPD_Rating
        {
            get { return _pPD_Rating; }
            set { _pPD_Rating = value; }
        }

        public System.Decimal? AWW_Dollars
        {
            get { return _aWW_Dollars; }
            set { _aWW_Dollars = value; }
        }

        public System.String AWW_Method
        {
            get { return _aWW_Method; }
            set { _aWW_Method = value; }
        }

        public System.Decimal? TTD_Dollars
        {
            get { return _tTD_Dollars; }
            set { _tTD_Dollars = value; }
        }

        public System.String Settlement_Method
        {
            get { return _settlement_Method; }
            set { _settlement_Method = value; }
        }

        public System.String Claim_Description
        {
            get { return _claim_Description; }
            set { _claim_Description = value; }
        }

        public System.Decimal? Nature
        {
            get { return _nature; }
            set { _nature = value; }
        }

        public System.Decimal? Estimate
        {
            get { return _estimate; }
            set { _estimate = value; }
        }

        public System.Decimal? Actual
        {
            get { return _actual; }
            set { _actual = value; }
        }

        public System.Decimal? FK_Claim_Cause
        {
            get { return _fK_Claim_Cause; }
            set { _fK_Claim_Cause = value; }
        }

        public System.Decimal? FK_Body_Parts
        {
            get { return _fK_Body_Parts; }
            set { _fK_Body_Parts = value; }
        }

        public System.Decimal? FK_Injury
        {
            get { return _fK_Injury; }
            set { _fK_Injury = value; }
        }

        public System.Decimal? FK_NCCI_Code
        {
            get { return _fK_NCCI_Code; }
            set { _fK_NCCI_Code = value; }
        }

        public System.String Vocation_Rehab
        {
            get { return _vocation_Rehab; }
            set { _vocation_Rehab = value; }
        }

        public System.Decimal? FK_WC_Major_Claim_Type
        {
            get { return _fK_WC_Major_Claim_Type; }
            set { _fK_WC_Major_Claim_Type = value; }
        }

        public System.Decimal? FK_WC_Minor_Claim_Type
        {
            get { return _fK_WC_Minor_Claim_Type; }
            set { _fK_WC_Minor_Claim_Type = value; }
        }

        public System.String Convertible
        {
            get { return _convertible; }
            set { _convertible = value; }
        }

        public System.Decimal? FK_Fraud_Claim
        {
            get { return _fK_Fraud_Claim; }
            set { _fK_Fraud_Claim = value; }
        }

        public System.DateTime? Claim_Open_Date
        {
            get { return _claim_Open_Date; }
            set { _claim_Open_Date = value; }
        }

        public System.DateTime? Claim_Close_Date
        {
            get { return _claim_Close_Date; }
            set { _claim_Close_Date = value; }
        }

        public System.DateTime? Claim_Reopen_Date
        {
            get { return _claim_Reopen_Date; }
            set { _claim_Reopen_Date = value; }
        }

        public System.String Surgery_Required
        {
            get { return _surgery_Required; }
            set { _surgery_Required = value; }
        }

        public System.Decimal? Indemnity_Weeks
        {
            get { return _indemnity_Weeks; }
            set { _indemnity_Weeks = value; }
        }

        public System.Decimal? FK_State_Jurisdiction
        {
            get { return _fK_State_Jurisdiction; }
            set { _fK_State_Jurisdiction = value; }
        }

        public System.Decimal? FK_Employee
        {
            get { return _fK_Employee; }
            set { _fK_Employee = value; }
        }

        public System.Decimal? FK_Method_Pre_Injury_Wage
        {
            get { return _fK_Method_Pre_Injury_Wage; }
            set { _fK_Method_Pre_Injury_Wage = value; }
        }

        public System.Decimal? FK_Method_Of_Settlement
        {
            get { return _fK_Method_Of_Settlement; }
            set { _fK_Method_Of_Settlement = value; }
        }

        public System.Decimal? Pre_Injury_Weekly_Wage
        {
            get { return _pre_Injury_Weekly_Wage; }
            set { _pre_Injury_Weekly_Wage = value; }
        }

        public System.Decimal? Post_Injury_Weekly_Wage
        {
            get { return _post_Injury_Weekly_Wage; }
            set { _post_Injury_Weekly_Wage = value; }
        }

        public System.Decimal? Present_Valuation_Future_Indemnity
        {
            get { return _present_Valuation_Future_Indemnity; }
            set { _present_Valuation_Future_Indemnity = value; }
        }

        public System.Decimal? FK_Injury_1
        {
            get { return _fK_Injury_1; }
            set { _fK_Injury_1 = value; }
        }

        public System.Decimal? Benefits_Paid_To_Date_1
        {
            get { return _benefits_Paid_To_Date_1; }
            set { _benefits_Paid_To_Date_1 = value; }
        }

        public System.Decimal? Weekly_Benefit_1
        {
            get { return _weekly_Benefit_1; }
            set { _weekly_Benefit_1 = value; }
        }

        public System.Decimal? FK_Injury_2
        {
            get { return _fK_Injury_2; }
            set { _fK_Injury_2 = value; }
        }

        public System.Decimal? Benefits_Paid_To_Date_2
        {
            get { return _benefits_Paid_To_Date_2; }
            set { _benefits_Paid_To_Date_2 = value; }
        }

        public System.Decimal? Weekly_Benefit_2
        {
            get { return _weekly_Benefit_2; }
            set { _weekly_Benefit_2 = value; }
        }

        public System.Decimal? FK_Injury_3
        {
            get { return _fK_Injury_3; }
            set { _fK_Injury_3 = value; }
        }

        public System.Decimal? Benefits_Paid_To_Date_3
        {
            get { return _benefits_Paid_To_Date_3; }
            set { _benefits_Paid_To_Date_3 = value; }
        }

        public System.Decimal? Weekly_Benefit_3
        {
            get { return _weekly_Benefit_3; }
            set { _weekly_Benefit_3 = value; }
        }

        public System.Decimal? FK_Injury_4
        {
            get { return _fK_Injury_4; }
            set { _fK_Injury_4 = value; }
        }

        public System.Decimal? Benefits_Paid_To_Date_4
        {
            get { return _benefits_Paid_To_Date_4; }
            set { _benefits_Paid_To_Date_4 = value; }
        }

        public System.Decimal? Weekly_Benefit_4
        {
            get { return _weekly_Benefit_4; }
            set { _weekly_Benefit_4 = value; }
        }

        public System.Decimal? FK_Injury_5
        {
            get { return _fK_Injury_5; }
            set { _fK_Injury_5 = value; }
        }

        public System.Decimal? Benefits_Paid_To_Date_5
        {
            get { return _benefits_Paid_To_Date_5; }
            set { _benefits_Paid_To_Date_5 = value; }
        }

        public System.Decimal? Weekly_Benefit_5
        {
            get { return _weekly_Benefit_5; }
            set { _weekly_Benefit_5 = value; }
        }

        public System.Decimal? FK_Beneficiary_Code_1
        {
            get { return _fK_Beneficiary_Code_1; }
            set { _fK_Beneficiary_Code_1 = value; }
        }

        public System.DateTime? Beneficiary_DOB_1
        {
            get { return _beneficiary_DOB_1; }
            set { _beneficiary_DOB_1 = value; }
        }

        public System.Decimal? FK_Beneficiary_Code_2
        {
            get { return _fK_Beneficiary_Code_2; }
            set { _fK_Beneficiary_Code_2 = value; }
        }

        public System.DateTime? Beneficiary_DOB_2
        {
            get { return _beneficiary_DOB_2; }
            set { _beneficiary_DOB_2 = value; }
        }

        public System.Decimal? FK_Beneficiary_Code_3
        {
            get { return _fK_Beneficiary_Code_3; }
            set { _fK_Beneficiary_Code_3 = value; }
        }

        public System.DateTime? Beneficiary_DOB_3
        {
            get { return _beneficiary_DOB_3; }
            set { _beneficiary_DOB_3 = value; }
        }

        public System.Decimal? FK_Beneficiary_Code_4
        {
            get { return _fK_Beneficiary_Code_4; }
            set { _fK_Beneficiary_Code_4 = value; }
        }

        public System.DateTime? Beneficiary_DOB_4
        {
            get { return _beneficiary_DOB_4; }
            set { _beneficiary_DOB_4 = value; }
        }

        public System.Decimal? FK_Beneficiary_Code_5
        {
            get { return _fK_Beneficiary_Code_5; }
            set { _fK_Beneficiary_Code_5 = value; }
        }

        public System.DateTime? Beneficiary_DOB_5
        {
            get { return _beneficiary_DOB_5; }
            set { _beneficiary_DOB_5 = value; }
        }

        public System.DateTime? Suit_Date
        {
            get { return _suit_Date; }
            set { _suit_Date = value; }
        }

        public System.DateTime? Attorney_Disclosure_Date
        {
            get { return _attorney_Disclosure_Date; }
            set { _attorney_Disclosure_Date = value; }
        }

        public System.String Client_Attorney_Name
        {
            get { return _client_Attorney_Name; }
            set { _client_Attorney_Name = value; }
        }

        public System.String Client_Attorney_Address_1
        {
            get { return _client_Attorney_Address_1; }
            set { _client_Attorney_Address_1 = value; }
        }

        public System.String Client_Attorney_Address_2
        {
            get { return _client_Attorney_Address_2; }
            set { _client_Attorney_Address_2 = value; }
        }

        public System.String Client_Attorney_City
        {
            get { return _client_Attorney_City; }
            set { _client_Attorney_City = value; }
        }

        public System.Decimal? FK_State_Client_Attorney
        {
            get { return _fK_State_Client_Attorney; }
            set { _fK_State_Client_Attorney = value; }
        }

        public System.String Client_Attorney_Zip_Code
        {
            get { return _client_Attorney_Zip_Code; }
            set { _client_Attorney_Zip_Code = value; }
        }

        public System.String Client_Attorney_Phone
        {
            get { return _client_Attorney_Phone; }
            set { _client_Attorney_Phone = value; }
        }

        public System.String Client_Attorney_Fax
        {
            get { return _client_Attorney_Fax; }
            set { _client_Attorney_Fax = value; }
        }

        public System.String Defense_Attorney_Name
        {
            get { return _defense_Attorney_Name; }
            set { _defense_Attorney_Name = value; }
        }

        public System.String Defense_Attorney_Address_1
        {
            get { return _defense_Attorney_Address_1; }
            set { _defense_Attorney_Address_1 = value; }
        }

        public System.String Defense_Attorney_Address_2
        {
            get { return _defense_Attorney_Address_2; }
            set { _defense_Attorney_Address_2 = value; }
        }

        public System.String Defense_Attorney_City
        {
            get { return _defense_Attorney_City; }
            set { _defense_Attorney_City = value; }
        }

        public System.Decimal? FK_State_Defense_Attorney
        {
            get { return _fK_State_Defense_Attorney; }
            set { _fK_State_Defense_Attorney = value; }
        }

        public System.String Defense_Attorney_Zip_Code
        {
            get { return _defense_Attorney_Zip_Code; }
            set { _defense_Attorney_Zip_Code = value; }
        }

        public System.String Defense_Attorney_Phone
        {
            get { return _defense_Attorney_Phone; }
            set { _defense_Attorney_Phone = value; }
        }

        public System.String Defense_Attorney_Fax
        {
            get { return _defense_Attorney_Fax; }
            set { _defense_Attorney_Fax = value; }
        }

        public System.String Medical_Provider
        {
            get { return _medical_Provider; }
            set { _medical_Provider = value; }
        }

        public System.String Medical_Provider_Phone
        {
            get { return _medical_Provider_Phone; }
            set { _medical_Provider_Phone = value; }
        }

        public System.String Hospital
        {
            get { return _hospital; }
            set { _hospital = value; }
        }

        public System.String MCO_Type
        {
            get { return _mCO_Type; }
            set { _mCO_Type = value; }
        }

        public System.DateTime? Death_Date
        {
            get { return _death_Date; }
            set { _death_Date = value; }
        }

        public System.String Delete_Reason
        {
            get { return _delete_Reason; }
            set { _delete_Reason = value; }
        }

        public System.DateTime? Date_Max_Med_Imp
        {
            get { return _date_Max_Med_Imp; }
            set { _date_Max_Med_Imp = value; }
        }

        public System.Decimal? FK_Managed_Care_Org_Type
        {
            get { return _fK_Managed_Care_Org_Type; }
            set { _fK_Managed_Care_Org_Type = value; }
        }

        public System.Decimal? Percentage_Impairment
        {
            get { return _percentage_Impairment; }
            set { _percentage_Impairment = value; }
        }

        public System.Decimal? Percentage_Disability
        {
            get { return _percentage_Disability; }
            set { _percentage_Disability = value; }
        }

        public System.Decimal? FK_Employee_Reported
        {
            get { return _fK_Employee_Reported; }
            set { _fK_Employee_Reported = value; }
        }

        public System.String Incident_Time
        {
            get { return _incident_Time; }
            set { _incident_Time = value; }
        }

        public System.String Within_24_Hours
        {
            get { return _within_24_Hours; }
            set { _within_24_Hours = value; }
        }

        public System.DateTime? Date_Reported
        {
            get { return _date_Reported; }
            set { _date_Reported = value; }
        }

        public System.DateTime? Date_Reported_Employer
        {
            get { return _date_Reported_Employer; }
            set { _date_Reported_Employer = value; }
        }

        public System.String Time_Reported
        {
            get { return _time_Reported; }
            set { _time_Reported = value; }
        }

        public System.String Location
        {
            get { return _location; }
            set { _location = value; }
        }

        public System.String Location_Address_1
        {
            get { return _location_Address_1; }
            set { _location_Address_1 = value; }
        }

        public System.String Location_Address_2
        {
            get { return _location_Address_2; }
            set { _location_Address_2 = value; }
        }

        public System.String Location_City
        {
            get { return _location_City; }
            set { _location_City = value; }
        }

        public System.Decimal? FK_State_Location
        {
            get { return _fK_State_Location; }
            set { _fK_State_Location = value; }
        }

        public System.String Location_Zip
        {
            get { return _location_Zip; }
            set { _location_Zip = value; }
        }

        public System.String Location_County
        {
            get { return _location_County; }
            set { _location_County = value; }
        }

        public System.String Location_Country
        {
            get { return _location_Country; }
            set { _location_Country = value; }
        }

        public System.String Location_Phone
        {
            get { return _location_Phone; }
            set { _location_Phone = value; }
        }

        public System.String Location_Fax
        {
            get { return _location_Fax; }
            set { _location_Fax = value; }
        }

        public System.DateTime? Date_Return
        {
            get { return _date_Return; }
            set { _date_Return = value; }
        }

        public System.String Employer_Contact
        {
            get { return _employer_Contact; }
            set { _employer_Contact = value; }
        }

        public System.DateTime? Employer_Contact_Date
        {
            get { return _employer_Contact_Date; }
            set { _employer_Contact_Date = value; }
        }

        public System.String Claimant_Contact
        {
            get { return _claimant_Contact; }
            set { _claimant_Contact = value; }
        }

        public System.DateTime? Claimant_Contact_Date
        {
            get { return _claimant_Contact_Date; }
            set { _claimant_Contact_Date = value; }
        }

        public System.String Statement_Claimant
        {
            get { return _statement_Claimant; }
            set { _statement_Claimant = value; }
        }

        public System.DateTime? Statement_Claimant_Date
        {
            get { return _statement_Claimant_Date; }
            set { _statement_Claimant_Date = value; }
        }

        public System.String Witness_1
        {
            get { return _witness_1; }
            set { _witness_1 = value; }
        }

        public System.String Statement_Witness_1
        {
            get { return _statement_Witness_1; }
            set { _statement_Witness_1 = value; }
        }

        public System.DateTime? Statement_Witness_1_Date
        {
            get { return _statement_Witness_1_Date; }
            set { _statement_Witness_1_Date = value; }
        }

        public System.String Witness_2
        {
            get { return _witness_2; }
            set { _witness_2 = value; }
        }

        public System.String Statement_Witness_2
        {
            get { return _statement_Witness_2; }
            set { _statement_Witness_2 = value; }
        }

        public System.DateTime? Statement_Witness_2_Date
        {
            get { return _statement_Witness_2_Date; }
            set { _statement_Witness_2_Date = value; }
        }

        public System.String Witness_3
        {
            get { return _witness_3; }
            set { _witness_3 = value; }
        }

        public System.String Statement_Witness_3
        {
            get { return _statement_Witness_3; }
            set { _statement_Witness_3 = value; }
        }

        public System.DateTime? Statement_Witness_3_Date
        {
            get { return _statement_Witness_3_Date; }
            set { _statement_Witness_3_Date = value; }
        }

        public System.String Updated_By
        {
            get { return _updated_By; }
            set { _updated_By = value; }
        }

        public System.DateTime? Update_Date
        {
            get { return _update_Date; }
            set { _update_Date = value; }
        }

        public System.DateTime? Claim_Report_Date
        {
            get { return _claim_Report_Date; }
            set { _claim_Report_Date = value; }
        }

        public System.Decimal? Auto_Liability_Recovery
        {
            get { return _auto_Liability_Recovery; }
            set { _auto_Liability_Recovery = value; }
        }

        public System.Decimal? Loss_Adj_Expense_PTD
        {
            get { return _loss_Adj_Expense_PTD; }
            set { _loss_Adj_Expense_PTD = value; }
        }

        public System.Decimal? Anuity_Purchased
        {
            get { return _anuity_Purchased; }
            set { _anuity_Purchased = value; }
        }

        public System.Decimal? Legal_Expense_PTD
        {
            get { return _legal_Expense_PTD; }
            set { _legal_Expense_PTD = value; }
        }

        public System.Decimal? Medical_Eval_PTD
        {
            get { return _medical_Eval_PTD; }
            set { _medical_Eval_PTD = value; }
        }

        public System.String FK_Cost_Center
        {
            get { return _fK_Cost_Center; }
            set { _fK_Cost_Center = value; }
        }

        public System.DateTime? CREATED_DATE
        {
            get { return _cREATED_DATE; }
            set { _cREATED_DATE = value; }
        }

        public System.String Jurisdiction_Claim_Number
        {
            get { return _jurisdiction_Claim_Number; }
            set { _jurisdiction_Claim_Number = value; }
        }

        public System.String HealthTech_Incident_Number
        {
            get { return _healthTech_Incident_Number; }
            set { _healthTech_Incident_Number = value; }
        }

        public System.Decimal? Fk_initial_treatment
        {
            get { return _fk_initial_treatment; }
            set { _fk_initial_treatment = value; }
        }

        public System.String FK_NCCI_Classification_Code
        {
            get { return _fK_NCCI_Classification_Code; }
            set { _fK_NCCI_Classification_Code = value; }
        }

        public System.Decimal? FK_NCCI_Cause
        {
            get { return _fK_NCCI_Cause; }
            set { _fK_NCCI_Cause = value; }
        }

        public System.Decimal? FK_NCCI_Nature
        {
            get { return _fK_NCCI_Nature; }
            set { _fK_NCCI_Nature = value; }
        }

        public System.String FK_County
        {
            get { return _fK_County; }
            set { _fK_County = value; }
        }

        public System.Decimal? FK_Hazard_Code
        {
            get { return _fK_Hazard_Code; }
            set { _fK_Hazard_Code = value; }
        }

        public System.String Claim_to_be_sent_to_FROI
        {
            get { return _claim_to_be_sent_to_FROI; }
            set { _claim_to_be_sent_to_FROI = value; }
        }

        public System.DateTime? Dt_FROI
        {
            get { return _dt_FROI; }
            set { _dt_FROI = value; }
        }

        public System.DateTime? TTD_Benefits_Paid_to_Date
        {
            get { return _tTD_Benefits_Paid_to_Date; }
            set { _tTD_Benefits_Paid_to_Date = value; }
        }

        public System.String Settlement_yes_no
        {
            get { return _settlement_yes_no; }
            set { _settlement_yes_no = value; }
        }

        public System.String Annuity_Purchased
        {
            get { return _annuity_Purchased; }
            set { _annuity_Purchased = value; }
        }

        public System.String Diagnosis
        {
            get { return _diagnosis; }
            set { _diagnosis = value; }
        }

        public System.DateTime? Last_Office_Visit_Date
        {
            get { return _last_Office_Visit_Date; }
            set { _last_Office_Visit_Date = value; }
        }

        public System.DateTime? Next_scheduled_visit_date
        {
            get { return _next_scheduled_visit_date; }
            set { _next_scheduled_visit_date = value; }
        }

        public System.String Referral
        {
            get { return _referral; }
            set { _referral = value; }
        }

        public System.String Physical_Therapy
        {
            get { return _physical_Therapy; }
            set { _physical_Therapy = value; }
        }

        public System.String Physicians_Panel_Requested
        {
            get { return _physicians_Panel_Requested; }
            set { _physicians_Panel_Requested = value; }
        }

        public System.String New_Treating_Physician
        {
            get { return _new_Treating_Physician; }
            set { _new_Treating_Physician = value; }
        }

        public System.DateTime? Date_incident_reported_to_CMS
        {
            get { return _date_incident_reported_to_CMS; }
            set { _date_incident_reported_to_CMS = value; }
        }

    



        #endregion

        #region Abstract Methods
        public abstract List<cWorkerComp> GetAll(Boolean blnIsActive);
        public abstract List<cWorkerComp> GetWorkerCompByID(System.Int32 PK_Workers_Comp);
        public abstract List<cWorkerComp> GetEmpDataByID(System.Int32 pK_Workers_Comp, System.Int32 pK_Employee_ID, System.Int32 Criatearea);
        public abstract int InsertUpdate_WorkerComp(RIMS_Base.cWorkerComp obj);
        public abstract int Delete_WorkerComp(System.Decimal lPK_Workers_Comp);
        public abstract string ActivateInactivate_WorkerComp(string strIDs, int intModifiedBy, bool bIsActive);
        public abstract List<cWorkerComp> GetCostCenterByID(System.Int32 pK_Workers_Comp, System.String cost_Center);
      
        #endregion

    }

}
