using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
    /// <summary>
    /// Summary description for WC_ClaimInfo
    /// </summary>
    public sealed class WC_ClaimInfo
    {
        #region Fields

        private Int64 _PK_Workers_Comp_Claims_ID;
        private string _Data_Origin;
        private decimal _Other_Voca_Rehab_Expenses_PTD;
        private decimal _Voca_Rehab_Expense_Incurred;
        private decimal _Non_Scheduled_Indemnity_Incurred;
        private string _Non_Scheduled_Impairment_Percent;
        private decimal _Funeral_Expense_PTD;
        private decimal _Lump_Sum_Settlement_Amount;
        private decimal _Employers_Liability_PTD;
        private Nullable<DateTime> _Date_Disability_Began;
        private decimal _Temporary_Indemnity_Incurred;
        private Nullable<DateTime> _Date_Return_To_Work;
        private decimal _Scheduled_Indemnity;
        private string _Employer_Federal_Tax_Number;
        private Nullable<DateTime> _Date_of_Max_Medical_Improvement;
        private string _Surgery_Indicator;
        private string _Attorney_Authorized_Rep;
        private string _Controverted_Case_Indicator;
        private decimal _Employee_Legal_Expense_PTD;
        private Nullable<DateTime> _Date_Application_Filed;
        private Nullable<DateTime> _Date_of_Attorney_Disclosure;
        private string _Year_Last_Exposed;
        private string _FK_NCCI_Occupation_Class_Code;
        private string _Compensation_Coverage_Code;
        private string _Beneficiary_Relationship;
        private string _Beneficiary_Dependency_Indicator;
        private Nullable<DateTime> _Beneficiary1_DOB;
        private Nullable<DateTime> _Beneficiary2_DOB;
        private Nullable<DateTime> _Beneficiary3_DOB;
        private Nullable<DateTime> _Beneficiary4_DOB;
        private string _Occupation_Description;
        private string _Claim_Status_Description;
        private string _FK_Cause_of_Injury_Code;
        private string _FK_Nature_of_Injury_Code;
        private string _FK_Part_of_Body_Code;
        private string _Cause_Injury_Body_Part_Description;
        private string _Carrier_Name;
        private string _LT_Med_Only_Flag;
        private Nullable<DateTime> _Date_of_Hire;
        private string _State_of_Employment;
        private string _Nature_of_Benefit_Code;
        private string _Number_of_Dependents;
        private string _Percentage_Impairment;
        private Nullable<DateTime> _Date_of_Death;
        private string _Zip_of_Accident_Site;
        private Nullable<DateTime> _Date_Reported_to_Employer;
        private Nullable<DateTime> _Date_of_First_Indemnity_Payment;
        private string _Accident_City_Town;
        private string _Employment_Status;
        private string _FK_NCCI_Cause_of_Injury_Code;
        private string _FK_NCCI_Body_Part_Code;
        private string _NCCI_Nature_Of_Injury_Code;
        private string _Previous_TPA_Claim_Num_Takeover;
        private decimal _Previous_TPA_Indemnity_Paid;
        private decimal _Previous_TPA_Medical_Paid;
        private decimal _Previous_TPA_Expense_Paid;
        private string _Adjustor_Code;
        private Int32 _Associated_First_Report;
        private Nullable<DateTime> _Date_of_Update;
        private string _Origin_Claim_Number;
        private string _Origin_Key_Claim_Number;
        private string _Claimant_Sequence_Number;
        private string _Employee_Name;
        private string _Claimant_First_Name;
        private string _Claimant_Last_Name;
        private string _Employee_Street;
        private string _Employee_City;
        private string _Employee_State;
        private string _Employee_Zip;
        private string _Employee_Gender;
        private string _Employee_SSN;
        private string _Marital_Status;
        private Nullable<DateTime> _Employee_Date_of_Birth;
        private string _State_of_Accident;
        private string _State_of_Jurisdiction;
        private Nullable<DateTime> _Date_Reported_to_Insurer;
        private Nullable<DateTime> _Date_of_Accident;
        private string _Time_of_Loss;
        private Nullable<DateTime> _Date_Entered;
        private Nullable<DateTime> _Date_Closed;
        private string _FK_Claim_Status;
        private string _FK_Insured_Location_Code;
        private string _FK_Coverage_Code;
        private Nullable<DateTime> _Date_Suit_Filed;
        private string _LitigationYN;
        private string _Suit_Result_Code;
        private string _Suit_Type_Code;
        private string _SRS_Policy_Number;
        private Nullable<DateTime> _Policy_Effective_Date;
        private Nullable<DateTime> _Policy_Expiration_Date;
        private string _Other_Carrier_Policy_Number;
        private Nullable<DateTime> _Carrier_Effective_Date;
        private Nullable<DateTime> _Carrier_Expiration_Date;
        private string _Plaintiff_Attorney_Code;
        private decimal _Indemnity_Gross_Paid;
        private decimal _Net_Indemnity_Paid;
        private decimal _Indemnity_Net_Recovered;
        private decimal _Indemnity_Incurred;
        private decimal _Indemnity_Outstanding;
        private decimal _Expense_Gross_Paid;
        private decimal _Net_Expense_Paid;
        private decimal _Expense_Net_Recovered;
        private decimal _Expense_Incurred;
        private decimal _Expense_Outstanding;
        private decimal _Medical_Gross_Paid;
        private decimal _Net_Medical_Paid;
        private decimal _Medical_Net_Recovered;
        private decimal _Medical_Incurred;
        private decimal _Medical_Outstanding;
        private decimal _Indemnity_Gross_Subrogation;
        private decimal _Indemnity_Subrogation_Expense;
        private decimal _Indemnity_Gross_Salvage;
        private decimal _Indemnity_Salvage_Expense;
        private decimal _Indemnity_Gross_Refund;
        private decimal _Ale_Gross_Subrogation;
        private decimal _Ale_Gross_Salvage;
        private decimal _Ale_Gross_Refund;
        private decimal _Ale_Refund_Expense;
        private decimal _Legal_Expense_Incurred;
        private decimal _Legal_Expense_Paid_to_Date;
        private decimal _Recovered_Indemnity_Deductible_Amount;
        private decimal _Recovered_Expense_Deductible_Amount;
        private decimal _Recovered_Medical_Deductible_Amount;
        private decimal _Medical_Gross_Subrogation;
        private decimal _Medical_Gross_Refund;
        private decimal _Claim_Subrogation_Paid_to_Date;
        private decimal _Total_Payment_To_Physicians;
        private decimal _Hospital_Expenses_Paid_To_Date;
        private decimal _Other_Medical_Paid_to_Date;
        private decimal _Voca_Rehab_Expense_PTD;
        private decimal _Voca_Rehab_Maintenance_PTD;
        private decimal _Voca_Rehab_Evaluation_PTD;
        private decimal _Voca_Rehab_Education_PTD;
        private string _TX_NS_Companion_Table;
        private string _TX_NS_Companion_Claim_Number;
        private Nullable<DateTime> _RTW_Effective_Date;
        private string _RTW_Work_Status_Type;
        private string _RTW_Authorized_Off_Work;
        private Nullable<DateTime> _RTW_Date_Last_Worked;
        private string _RTW_DLW_Full_Day;
        private Nullable<DateTime> _RTW_Anticipated_RTW_Ex_Full_Duty;
        private Nullable<DateTime> _RTW_Anticipated_RTW_Ex_Restricted;
        private Nullable<DateTime> _RTW_Anticipated_RTW_CM_Full_Duty;
        private Nullable<DateTime> _RTW_Anticipated_RTW_CM_Restricted;
        private Nullable<DateTime> _RTW_Anticipated_RTW_Ph_Full_Duty;
        private Nullable<DateTime> _RTW_Anticipated_RTW_Ph_Restricted;
        private string _RTW_Moderate_Duty_Available;
        private string _RTW_Modified_Duty_Offered;
        private string _RTW_Modified_Duty_Accepted;
        private string _RTW_Modified_Duty_Occupation;
        private string _RTW_Modified_Duty_Demand;
        private string _RTW_Full_Days_Modified_Duty;
        private decimal _RTW_Hours_Modified_Duty;
        private string _RTW_Occupation;
        private string _RTW_Demand;
        private string _RTW_Schedule;
        private Nullable<DateTime> _RTW_Date_Modified_Duty_Available;
        private Nullable<DateTime> _RTW_Date_Modified_Duty_Offered;
        private Nullable<DateTime> _RTW_Date_Modified_Duty_Accepted;
        private Nullable<DateTime> _RTW_Date_Notified;
        private Nullable<DateTime> _RTW_Date_Disability_Began;
        private decimal _RTW_Number_Lost_Time_Days;
        private decimal _RTW_Number_Restricted_Work_Days;
        private string _RTW_Reason_For_Termination;
        private decimal _FK_Claim_Sub_Status;
        private decimal _FK_SLT_Claims_Management;
        #endregion

        #region Properties
        /// <summary> 
        /// Gets or sets the PK_Workers_Comp_Claims_ID value.
        /// </summary> 
        public Int64 PK_Workers_Comp_Claims_ID
        {
            get { return _PK_Workers_Comp_Claims_ID; }
            set { _PK_Workers_Comp_Claims_ID = value; }
        }


        /// <summary> 
        /// Gets or sets the Data_Origin value.
        /// </summary> 
        public string Data_Origin
        {
            get { return _Data_Origin; }
            set { _Data_Origin = value; }
        }


        /// <summary> 
        /// Gets or sets the Other_Voca_Rehab_Expenses_PTD value.
        /// </summary> 
        public decimal Other_Voca_Rehab_Expenses_PTD
        {
            get { return _Other_Voca_Rehab_Expenses_PTD; }
            set { _Other_Voca_Rehab_Expenses_PTD = value; }
        }


        /// <summary> 
        /// Gets or sets the Voca_Rehab_Expense_Incurred value.
        /// </summary> 
        public decimal Voca_Rehab_Expense_Incurred
        {
            get { return _Voca_Rehab_Expense_Incurred; }
            set { _Voca_Rehab_Expense_Incurred = value; }
        }


        /// <summary> 
        /// Gets or sets the Non_Scheduled_Indemnity_Incurred value.
        /// </summary> 
        public decimal Non_Scheduled_Indemnity_Incurred
        {
            get { return _Non_Scheduled_Indemnity_Incurred; }
            set { _Non_Scheduled_Indemnity_Incurred = value; }
        }


        /// <summary> 
        /// Gets or sets the Non_Scheduled_Impairment_Percent value.
        /// </summary> 
        public string Non_Scheduled_Impairment_Percent
        {
            get { return _Non_Scheduled_Impairment_Percent; }
            set { _Non_Scheduled_Impairment_Percent = value; }
        }


        /// <summary> 
        /// Gets or sets the Funeral_Expense_PTD value.
        /// </summary> 
        public decimal Funeral_Expense_PTD
        {
            get { return _Funeral_Expense_PTD; }
            set { _Funeral_Expense_PTD = value; }
        }


        /// <summary> 
        /// Gets or sets the Lump_Sum_Settlement_Amount value.
        /// </summary> 
        public decimal Lump_Sum_Settlement_Amount
        {
            get { return _Lump_Sum_Settlement_Amount; }
            set { _Lump_Sum_Settlement_Amount = value; }
        }


        /// <summary> 
        /// Gets or sets the Employers_Liability_PTD value.
        /// </summary> 
        public decimal Employers_Liability_PTD
        {
            get { return _Employers_Liability_PTD; }
            set { _Employers_Liability_PTD = value; }
        }


        /// <summary> 
        /// Gets or sets the Date_Disability_Began value.
        /// </summary> 
        public Nullable<DateTime> Date_Disability_Began
        {
            get { return _Date_Disability_Began; }
            set { _Date_Disability_Began = value; }
        }


        /// <summary> 
        /// Gets or sets the Temporary_Indemnity_Incurred value.
        /// </summary> 
        public decimal Temporary_Indemnity_Incurred
        {
            get { return _Temporary_Indemnity_Incurred; }
            set { _Temporary_Indemnity_Incurred = value; }
        }


        /// <summary> 
        /// Gets or sets the Date_Return_To_Work value.
        /// </summary> 
        public Nullable<DateTime> Date_Return_To_Work
        {
            get { return _Date_Return_To_Work; }
            set { _Date_Return_To_Work = value; }
        }


        /// <summary> 
        /// Gets or sets the Scheduled_Indemnity value.
        /// </summary> 
        public decimal Scheduled_Indemnity
        {
            get { return _Scheduled_Indemnity; }
            set { _Scheduled_Indemnity = value; }
        }


        /// <summary> 
        /// Gets or sets the Employer_Federal_Tax_Number value.
        /// </summary> 
        public string Employer_Federal_Tax_Number
        {
            get { return _Employer_Federal_Tax_Number; }
            set { _Employer_Federal_Tax_Number = value; }
        }


        /// <summary> 
        /// Gets or sets the Date_of_Max_Medical_Improvement value.
        /// </summary> 
        public Nullable<DateTime> Date_of_Max_Medical_Improvement
        {
            get { return _Date_of_Max_Medical_Improvement; }
            set { _Date_of_Max_Medical_Improvement = value; }
        }


        /// <summary> 
        /// Gets or sets the Surgery_Indicator value.
        /// </summary> 
        public string Surgery_Indicator
        {
            get { return _Surgery_Indicator; }
            set { _Surgery_Indicator = value; }
        }


        /// <summary> 
        /// Gets or sets the Attorney_Authorized_Rep value.
        /// </summary> 
        public string Attorney_Authorized_Rep
        {
            get { return _Attorney_Authorized_Rep; }
            set { _Attorney_Authorized_Rep = value; }
        }


        /// <summary> 
        /// Gets or sets the Controverted_Case_Indicator value.
        /// </summary> 
        public string Controverted_Case_Indicator
        {
            get { return _Controverted_Case_Indicator; }
            set { _Controverted_Case_Indicator = value; }
        }


        /// <summary> 
        /// Gets or sets the Employee_Legal_Expense_PTD value.
        /// </summary> 
        public decimal Employee_Legal_Expense_PTD
        {
            get { return _Employee_Legal_Expense_PTD; }
            set { _Employee_Legal_Expense_PTD = value; }
        }


        /// <summary> 
        /// Gets or sets the Date_Application_Filed value.
        /// </summary> 
        public Nullable<DateTime> Date_Application_Filed
        {
            get { return _Date_Application_Filed; }
            set { _Date_Application_Filed = value; }
        }


        /// <summary> 
        /// Gets or sets the Date_of_Attorney_Disclosure value.
        /// </summary> 
        public Nullable<DateTime> Date_of_Attorney_Disclosure
        {
            get { return _Date_of_Attorney_Disclosure; }
            set { _Date_of_Attorney_Disclosure = value; }
        }


        /// <summary> 
        /// Gets or sets the Year_Last_Exposed value.
        /// </summary> 
        public string Year_Last_Exposed
        {
            get { return _Year_Last_Exposed; }
            set { _Year_Last_Exposed = value; }
        }


        /// <summary> 
        /// Gets or sets the FK_NCCI_Occupation_Class_Code value.
        /// </summary> 
        public string FK_NCCI_Occupation_Class_Code
        {
            get { return _FK_NCCI_Occupation_Class_Code; }
            set { _FK_NCCI_Occupation_Class_Code = value; }
        }


        /// <summary> 
        /// Gets or sets the Compensation_Coverage_Code value.
        /// </summary> 
        public string Compensation_Coverage_Code
        {
            get { return _Compensation_Coverage_Code; }
            set { _Compensation_Coverage_Code = value; }
        }


        /// <summary> 
        /// Gets or sets the Beneficiary_Relationship value.
        /// </summary> 
        public string Beneficiary_Relationship
        {
            get { return _Beneficiary_Relationship; }
            set { _Beneficiary_Relationship = value; }
        }


        /// <summary> 
        /// Gets or sets the Beneficiary_Dependency_Indicator value.
        /// </summary> 
        public string Beneficiary_Dependency_Indicator
        {
            get { return _Beneficiary_Dependency_Indicator; }
            set { _Beneficiary_Dependency_Indicator = value; }
        }


        /// <summary> 
        /// Gets or sets the Beneficiary1_DOB value.
        /// </summary> 
        public Nullable<DateTime> Beneficiary1_DOB
        {
            get { return _Beneficiary1_DOB; }
            set { _Beneficiary1_DOB = value; }
        }


        /// <summary> 
        /// Gets or sets the Beneficiary2_DOB value.
        /// </summary> 
        public Nullable<DateTime> Beneficiary2_DOB
        {
            get { return _Beneficiary2_DOB; }
            set { _Beneficiary2_DOB = value; }
        }


        /// <summary> 
        /// Gets or sets the Beneficiary3_DOB value.
        /// </summary> 
        public Nullable<DateTime> Beneficiary3_DOB
        {
            get { return _Beneficiary3_DOB; }
            set { _Beneficiary3_DOB = value; }
        }


        /// <summary> 
        /// Gets or sets the Beneficiary4_DOB value.
        /// </summary> 
        public Nullable<DateTime> Beneficiary4_DOB
        {
            get { return _Beneficiary4_DOB; }
            set { _Beneficiary4_DOB = value; }
        }


        /// <summary> 
        /// Gets or sets the Occupation_Description value.
        /// </summary> 
        public string Occupation_Description
        {
            get { return _Occupation_Description; }
            set { _Occupation_Description = value; }
        }


        /// <summary> 
        /// Gets or sets the Claim_Status_Description value.
        /// </summary> 
        public string Claim_Status_Description
        {
            get { return _Claim_Status_Description; }
            set { _Claim_Status_Description = value; }
        }


        /// <summary> 
        /// Gets or sets the FK_Cause_of_Injury_Code value.
        /// </summary> 
        public string FK_Cause_of_Injury_Code
        {
            get { return _FK_Cause_of_Injury_Code; }
            set { _FK_Cause_of_Injury_Code = value; }
        }


        /// <summary> 
        /// Gets or sets the FK_Nature_of_Injury_Code value.
        /// </summary> 
        public string FK_Nature_of_Injury_Code
        {
            get { return _FK_Nature_of_Injury_Code; }
            set { _FK_Nature_of_Injury_Code = value; }
        }


        /// <summary> 
        /// Gets or sets the FK_Part_of_Body_Code value.
        /// </summary> 
        public string FK_Part_of_Body_Code
        {
            get { return _FK_Part_of_Body_Code; }
            set { _FK_Part_of_Body_Code = value; }
        }


        /// <summary> 
        /// Gets or sets the Cause_Injury_Body_Part_Description value.
        /// </summary> 
        public string Cause_Injury_Body_Part_Description
        {
            get { return _Cause_Injury_Body_Part_Description; }
            set { _Cause_Injury_Body_Part_Description = value; }
        }


        /// <summary> 
        /// Gets or sets the Carrier_Name value.
        /// </summary> 
        public string Carrier_Name
        {
            get { return _Carrier_Name; }
            set { _Carrier_Name = value; }
        }


        /// <summary> 
        /// Gets or sets the LT_Med_Only_Flag value.
        /// </summary> 
        public string LT_Med_Only_Flag
        {
            get { return _LT_Med_Only_Flag; }
            set { _LT_Med_Only_Flag = value; }
        }


        /// <summary> 
        /// Gets or sets the Date_of_Hire value.
        /// </summary> 
        public Nullable<DateTime> Date_of_Hire
        {
            get { return _Date_of_Hire; }
            set { _Date_of_Hire = value; }
        }


        /// <summary> 
        /// Gets or sets the State_of_Employment value.
        /// </summary> 
        public string State_of_Employment
        {
            get { return _State_of_Employment; }
            set { _State_of_Employment = value; }
        }


        /// <summary> 
        /// Gets or sets the Nature_of_Benefit_Code value.
        /// </summary> 
        public string Nature_of_Benefit_Code
        {
            get { return _Nature_of_Benefit_Code; }
            set { _Nature_of_Benefit_Code = value; }
        }


        /// <summary> 
        /// Gets or sets the Number_of_Dependents value.
        /// </summary> 
        public string Number_of_Dependents
        {
            get { return _Number_of_Dependents; }
            set { _Number_of_Dependents = value; }
        }


        /// <summary> 
        /// Gets or sets the Percentage_Impairment value.
        /// </summary> 
        public string Percentage_Impairment
        {
            get { return _Percentage_Impairment; }
            set { _Percentage_Impairment = value; }
        }


        /// <summary> 
        /// Gets or sets the Date_of_Death value.
        /// </summary> 
        public Nullable<DateTime> Date_of_Death
        {
            get { return _Date_of_Death; }
            set { _Date_of_Death = value; }
        }


        /// <summary> 
        /// Gets or sets the Zip_of_Accident_Site value.
        /// </summary> 
        public string Zip_of_Accident_Site
        {
            get { return _Zip_of_Accident_Site; }
            set { _Zip_of_Accident_Site = value; }
        }


        /// <summary> 
        /// Gets or sets the Date_Reported_to_Employer value.
        /// </summary> 
        public Nullable<DateTime> Date_Reported_to_Employer
        {
            get { return _Date_Reported_to_Employer; }
            set { _Date_Reported_to_Employer = value; }
        }


        /// <summary> 
        /// Gets or sets the Date_of_First_Indemnity_Payment value.
        /// </summary> 
        public Nullable<DateTime> Date_of_First_Indemnity_Payment
        {
            get { return _Date_of_First_Indemnity_Payment; }
            set { _Date_of_First_Indemnity_Payment = value; }
        }


        /// <summary> 
        /// Gets or sets the Accident_City_Town value.
        /// </summary> 
        public string Accident_City_Town
        {
            get { return _Accident_City_Town; }
            set { _Accident_City_Town = value; }
        }


        /// <summary> 
        /// Gets or sets the Employment_Status value.
        /// </summary> 
        public string Employment_Status
        {
            get { return _Employment_Status; }
            set { _Employment_Status = value; }
        }


        /// <summary> 
        /// Gets or sets the FK_NCCI_Cause_of_Injury_Code value.
        /// </summary> 
        public string FK_NCCI_Cause_of_Injury_Code
        {
            get { return _FK_NCCI_Cause_of_Injury_Code; }
            set { _FK_NCCI_Cause_of_Injury_Code = value; }
        }


        /// <summary> 
        /// Gets or sets the FK_NCCI_Body_Part_Code value.
        /// </summary> 
        public string FK_NCCI_Body_Part_Code
        {
            get { return _FK_NCCI_Body_Part_Code; }
            set { _FK_NCCI_Body_Part_Code = value; }
        }


        /// <summary> 
        /// Gets or sets the NCCI_Nature_Of_Injury_Code value.
        /// </summary> 
        public string NCCI_Nature_Of_Injury_Code
        {
            get { return _NCCI_Nature_Of_Injury_Code; }
            set { _NCCI_Nature_Of_Injury_Code = value; }
        }


        /// <summary> 
        /// Gets or sets the Previous_TPA_Claim_Num_Takeover value.
        /// </summary> 
        public string Previous_TPA_Claim_Num_Takeover
        {
            get { return _Previous_TPA_Claim_Num_Takeover; }
            set { _Previous_TPA_Claim_Num_Takeover = value; }
        }


        /// <summary> 
        /// Gets or sets the Previous_TPA_Indemnity_Paid value.
        /// </summary> 
        public decimal Previous_TPA_Indemnity_Paid
        {
            get { return _Previous_TPA_Indemnity_Paid; }
            set { _Previous_TPA_Indemnity_Paid = value; }
        }


        /// <summary> 
        /// Gets or sets the Previous_TPA_Medical_Paid value.
        /// </summary> 
        public decimal Previous_TPA_Medical_Paid
        {
            get { return _Previous_TPA_Medical_Paid; }
            set { _Previous_TPA_Medical_Paid = value; }
        }


        /// <summary> 
        /// Gets or sets the Previous_TPA_Expense_Paid value.
        /// </summary> 
        public decimal Previous_TPA_Expense_Paid
        {
            get { return _Previous_TPA_Expense_Paid; }
            set { _Previous_TPA_Expense_Paid = value; }
        }


        /// <summary> 
        /// Gets or sets the Adjustor_Code value.
        /// </summary> 
        public string Adjustor_Code
        {
            get { return _Adjustor_Code; }
            set { _Adjustor_Code = value; }
        }


        /// <summary> 
        /// Gets or sets the Associated_First_Report value.
        /// </summary> 
        public Int32 Associated_First_Report
        {
            get { return _Associated_First_Report; }
            set { _Associated_First_Report = value; }
        }


        /// <summary> 
        /// Gets or sets the Date_of_Update value.
        /// </summary> 
        public Nullable<DateTime> Date_of_Update
        {
            get { return _Date_of_Update; }
            set { _Date_of_Update = value; }
        }


        /// <summary> 
        /// Gets or sets the Origin_Claim_Number value.
        /// </summary> 
        public string Origin_Claim_Number
        {
            get { return _Origin_Claim_Number; }
            set { _Origin_Claim_Number = value; }
        }

        /// <summary> 
        /// Gets or sets the TX_NS_Companion_Table.
        /// </summary> 
        public string TX_NS_Companion_Table
        {
            get { return _TX_NS_Companion_Table; }
            set { _TX_NS_Companion_Table = value; }
        }



        /// <summary> 
        /// Gets or sets the Texas Claim No.
        /// </summary> 
        public string TX_NS_Companion_Claim_Number
        {
            get { return _TX_NS_Companion_Claim_Number; }
            set { _TX_NS_Companion_Claim_Number = value; }
        }

        /// <summary> 
        /// Gets or sets the Origin_Key_Claim_Number value.
        /// </summary> 
        public string Origin_Key_Claim_Number
        {
            get { return _Origin_Key_Claim_Number; }
            set { _Origin_Key_Claim_Number = value; }
        }


        /// <summary> 
        /// Gets or sets the Claimant_Sequence_Number value.
        /// </summary> 
        public string Claimant_Sequence_Number
        {
            get { return _Claimant_Sequence_Number; }
            set { _Claimant_Sequence_Number = value; }
        }


        /// <summary> 
        /// Gets or sets the Employee_Name value.
        /// </summary> 
        public string Employee_Name
        {
            get { return _Employee_Name; }
            set { _Employee_Name = value; }
        }


        /// <summary> 
        /// Gets or sets the Claimant_First_Name value.
        /// </summary> 
        public string Claimant_First_Name
        {
            get { return _Claimant_First_Name; }
            set { _Claimant_First_Name = value; }
        }


        /// <summary> 
        /// Gets or sets the Claimant_Last_Name value.
        /// </summary> 
        public string Claimant_Last_Name
        {
            get { return _Claimant_Last_Name; }
            set { _Claimant_Last_Name = value; }
        }


        /// <summary> 
        /// Gets or sets the Employee_Street value.
        /// </summary> 
        public string Employee_Street
        {
            get { return _Employee_Street; }
            set { _Employee_Street = value; }
        }


        /// <summary> 
        /// Gets or sets the Employee_City value.
        /// </summary> 
        public string Employee_City
        {
            get { return _Employee_City; }
            set { _Employee_City = value; }
        }


        /// <summary> 
        /// Gets or sets the Employee_State value.
        /// </summary> 
        public string Employee_State
        {
            get { return _Employee_State; }
            set { _Employee_State = value; }
        }


        /// <summary> 
        /// Gets or sets the Employee_Zip value.
        /// </summary> 
        public string Employee_Zip
        {
            get { return _Employee_Zip; }
            set { _Employee_Zip = value; }
        }


        /// <summary> 
        /// Gets or sets the Employee_Gender value.
        /// </summary> 
        public string Employee_Gender
        {
            get { return _Employee_Gender; }
            set { _Employee_Gender = value; }
        }


        /// <summary> 
        /// Gets or sets the Employee_SSN value.
        /// </summary> 
        public string Employee_SSN
        {
            get { return _Employee_SSN; }
            set { _Employee_SSN = value; }
        }


        /// <summary> 
        /// Gets or sets the Marital_Status value.
        /// </summary> 
        public string Marital_Status
        {
            get { return _Marital_Status; }
            set { _Marital_Status = value; }
        }


        /// <summary> 
        /// Gets or sets the Employee_Date_of_Birth value.
        /// </summary> 
        public Nullable<DateTime> Employee_Date_of_Birth
        {
            get { return _Employee_Date_of_Birth; }
            set { _Employee_Date_of_Birth = value; }
        }


        /// <summary> 
        /// Gets or sets the State_of_Accident value.
        /// </summary> 
        public string State_of_Accident
        {
            get { return _State_of_Accident; }
            set { _State_of_Accident = value; }
        }


        /// <summary> 
        /// Gets or sets the State_of_Jurisdiction value.
        /// </summary> 
        public string State_of_Jurisdiction
        {
            get { return _State_of_Jurisdiction; }
            set { _State_of_Jurisdiction = value; }
        }


        /// <summary> 
        /// Gets or sets the Date_Reported_to_Insurer value.
        /// </summary> 
        public Nullable<DateTime> Date_Reported_to_Insurer
        {
            get { return _Date_Reported_to_Insurer; }
            set { _Date_Reported_to_Insurer = value; }
        }


        /// <summary> 
        /// Gets or sets the Date_of_Accident value.
        /// </summary> 
        public Nullable<DateTime> Date_of_Accident
        {
            get { return _Date_of_Accident; }
            set { _Date_of_Accident = value; }
        }


        /// <summary> 
        /// Gets or sets the Time_of_Loss value.
        /// </summary> 
        public string Time_of_Loss
        {
            get { return _Time_of_Loss; }
            set { _Time_of_Loss = value; }
        }


        /// <summary> 
        /// Gets or sets the Date_Entered value.
        /// </summary> 
        public Nullable<DateTime> Date_Entered
        {
            get { return _Date_Entered; }
            set { _Date_Entered = value; }
        }


        /// <summary> 
        /// Gets or sets the Date_Closed value.
        /// </summary> 
        public Nullable<DateTime> Date_Closed
        {
            get { return _Date_Closed; }
            set { _Date_Closed = value; }
        }


        /// <summary> 
        /// Gets or sets the FK_Claim_Status value.
        /// </summary> 
        public string FK_Claim_Status
        {
            get { return _FK_Claim_Status; }
            set { _FK_Claim_Status = value; }
        }


        /// <summary> 
        /// Gets or sets the FK_Insured_Location_Code value.
        /// </summary> 
        public string FK_Insured_Location_Code
        {
            get { return _FK_Insured_Location_Code; }
            set { _FK_Insured_Location_Code = value; }
        }


        /// <summary> 
        /// Gets or sets the FK_Coverage_Code value.
        /// </summary> 
        public string FK_Coverage_Code
        {
            get { return _FK_Coverage_Code; }
            set { _FK_Coverage_Code = value; }
        }


        /// <summary> 
        /// Gets or sets the Date_Suit_Filed value.
        /// </summary> 
        public Nullable<DateTime> Date_Suit_Filed
        {
            get { return _Date_Suit_Filed; }
            set { _Date_Suit_Filed = value; }
        }


        /// <summary> 
        /// Gets or sets the LitigationYN value.
        /// </summary> 
        public string LitigationYN
        {
            get { return _LitigationYN; }
            set { _LitigationYN = value; }
        }


        /// <summary> 
        /// Gets or sets the Suit_Result_Code value.
        /// </summary> 
        public string Suit_Result_Code
        {
            get { return _Suit_Result_Code; }
            set { _Suit_Result_Code = value; }
        }


        /// <summary> 
        /// Gets or sets the Suit_Type_Code value.
        /// </summary> 
        public string Suit_Type_Code
        {
            get { return _Suit_Type_Code; }
            set { _Suit_Type_Code = value; }
        }


        /// <summary> 
        /// Gets or sets the SRS_Policy_Number value.
        /// </summary> 
        public string SRS_Policy_Number
        {
            get { return _SRS_Policy_Number; }
            set { _SRS_Policy_Number = value; }
        }


        /// <summary> 
        /// Gets or sets the Policy_Effective_Date value.
        /// </summary> 
        public Nullable<DateTime> Policy_Effective_Date
        {
            get { return _Policy_Effective_Date; }
            set { _Policy_Effective_Date = value; }
        }


        /// <summary> 
        /// Gets or sets the Policy_Expiration_Date value.
        /// </summary> 
        public Nullable<DateTime> Policy_Expiration_Date
        {
            get { return _Policy_Expiration_Date; }
            set { _Policy_Expiration_Date = value; }
        }


        /// <summary> 
        /// Gets or sets the Other_Carrier_Policy_Number value.
        /// </summary> 
        public string Other_Carrier_Policy_Number
        {
            get { return _Other_Carrier_Policy_Number; }
            set { _Other_Carrier_Policy_Number = value; }
        }


        /// <summary> 
        /// Gets or sets the Carrier_Effective_Date value.
        /// </summary> 
        public Nullable<DateTime> Carrier_Effective_Date
        {
            get { return _Carrier_Effective_Date; }
            set { _Carrier_Effective_Date = value; }
        }


        /// <summary> 
        /// Gets or sets the Carrier_Expiration_Date value.
        /// </summary> 
        public Nullable<DateTime> Carrier_Expiration_Date
        {
            get { return _Carrier_Expiration_Date; }
            set { _Carrier_Expiration_Date = value; }
        }


        /// <summary> 
        /// Gets or sets the Plaintiff_Attorney_Code value.
        /// </summary> 
        public string Plaintiff_Attorney_Code
        {
            get { return _Plaintiff_Attorney_Code; }
            set { _Plaintiff_Attorney_Code = value; }
        }


        /// <summary> 
        /// Gets or sets the Indemnity_Gross_Paid value.
        /// </summary> 
        public decimal Indemnity_Gross_Paid
        {
            get { return _Indemnity_Gross_Paid; }
            set { _Indemnity_Gross_Paid = value; }
        }


        /// <summary> 
        /// Gets or sets the Net_Indemnity_Paid value.
        /// </summary> 
        public decimal Net_Indemnity_Paid
        {
            get { return _Net_Indemnity_Paid; }
            set { _Net_Indemnity_Paid = value; }
        }


        /// <summary> 
        /// Gets or sets the Indemnity_Net_Recovered value.
        /// </summary> 
        public decimal Indemnity_Net_Recovered
        {
            get { return _Indemnity_Net_Recovered; }
            set { _Indemnity_Net_Recovered = value; }
        }


        /// <summary> 
        /// Gets or sets the Indemnity_Incurred value.
        /// </summary> 
        public decimal Indemnity_Incurred
        {
            get { return _Indemnity_Incurred; }
            set { _Indemnity_Incurred = value; }
        }


        /// <summary> 
        /// Gets or sets the Indemnity_Outstanding value.
        /// </summary> 
        public decimal Indemnity_Outstanding
        {
            get { return _Indemnity_Outstanding; }
            set { _Indemnity_Outstanding = value; }
        }


        /// <summary> 
        /// Gets or sets the Expense_Gross_Paid value.
        /// </summary> 
        public decimal Expense_Gross_Paid
        {
            get { return _Expense_Gross_Paid; }
            set { _Expense_Gross_Paid = value; }
        }


        /// <summary> 
        /// Gets or sets the Net_Expense_Paid value.
        /// </summary> 
        public decimal Net_Expense_Paid
        {
            get { return _Net_Expense_Paid; }
            set { _Net_Expense_Paid = value; }
        }


        /// <summary> 
        /// Gets or sets the Expense_Net_Recovered value.
        /// </summary> 
        public decimal Expense_Net_Recovered
        {
            get { return _Expense_Net_Recovered; }
            set { _Expense_Net_Recovered = value; }
        }


        /// <summary> 
        /// Gets or sets the Expense_Incurred value.
        /// </summary> 
        public decimal Expense_Incurred
        {
            get { return _Expense_Incurred; }
            set { _Expense_Incurred = value; }
        }


        /// <summary> 
        /// Gets or sets the Expense_Outstanding value.
        /// </summary> 
        public decimal Expense_Outstanding
        {
            get { return _Expense_Outstanding; }
            set { _Expense_Outstanding = value; }
        }


        /// <summary> 
        /// Gets or sets the Medical_Gross_Paid value.
        /// </summary> 
        public decimal Medical_Gross_Paid
        {
            get { return _Medical_Gross_Paid; }
            set { _Medical_Gross_Paid = value; }
        }


        /// <summary> 
        /// Gets or sets the Net_Medical_Paid value.
        /// </summary> 
        public decimal Net_Medical_Paid
        {
            get { return _Net_Medical_Paid; }
            set { _Net_Medical_Paid = value; }
        }


        /// <summary> 
        /// Gets or sets the Medical_Net_Recovered value.
        /// </summary> 
        public decimal Medical_Net_Recovered
        {
            get { return _Medical_Net_Recovered; }
            set { _Medical_Net_Recovered = value; }
        }


        /// <summary> 
        /// Gets or sets the Medical_Incurred value.
        /// </summary> 
        public decimal Medical_Incurred
        {
            get { return _Medical_Incurred; }
            set { _Medical_Incurred = value; }
        }


        /// <summary> 
        /// Gets or sets the Medical_Outstanding value.
        /// </summary> 
        public decimal Medical_Outstanding
        {
            get { return _Medical_Outstanding; }
            set { _Medical_Outstanding = value; }
        }


        /// <summary> 
        /// Gets or sets the Indemnity_Gross_Subrogation value.
        /// </summary> 
        public decimal Indemnity_Gross_Subrogation
        {
            get { return _Indemnity_Gross_Subrogation; }
            set { _Indemnity_Gross_Subrogation = value; }
        }


        /// <summary> 
        /// Gets or sets the Indemnity_Subrogation_Expense value.
        /// </summary> 
        public decimal Indemnity_Subrogation_Expense
        {
            get { return _Indemnity_Subrogation_Expense; }
            set { _Indemnity_Subrogation_Expense = value; }
        }


        /// <summary> 
        /// Gets or sets the Indemnity_Gross_Salvage value.
        /// </summary> 
        public decimal Indemnity_Gross_Salvage
        {
            get { return _Indemnity_Gross_Salvage; }
            set { _Indemnity_Gross_Salvage = value; }
        }


        /// <summary> 
        /// Gets or sets the Indemnity_Salvage_Expense value.
        /// </summary> 
        public decimal Indemnity_Salvage_Expense
        {
            get { return _Indemnity_Salvage_Expense; }
            set { _Indemnity_Salvage_Expense = value; }
        }


        /// <summary> 
        /// Gets or sets the Indemnity_Gross_Refund value.
        /// </summary> 
        public decimal Indemnity_Gross_Refund
        {
            get { return _Indemnity_Gross_Refund; }
            set { _Indemnity_Gross_Refund = value; }
        }


        /// <summary> 
        /// Gets or sets the Ale_Gross_Subrogation value.
        /// </summary> 
        public decimal Ale_Gross_Subrogation
        {
            get { return _Ale_Gross_Subrogation; }
            set { _Ale_Gross_Subrogation = value; }
        }


        /// <summary> 
        /// Gets or sets the Ale_Gross_Salvage value.
        /// </summary> 
        public decimal Ale_Gross_Salvage
        {
            get { return _Ale_Gross_Salvage; }
            set { _Ale_Gross_Salvage = value; }
        }


        /// <summary> 
        /// Gets or sets the Ale_Gross_Refund value.
        /// </summary> 
        public decimal Ale_Gross_Refund
        {
            get { return _Ale_Gross_Refund; }
            set { _Ale_Gross_Refund = value; }
        }


        /// <summary> 
        /// Gets or sets the Ale_Refund_Expense value.
        /// </summary> 
        public decimal Ale_Refund_Expense
        {
            get { return _Ale_Refund_Expense; }
            set { _Ale_Refund_Expense = value; }
        }


        /// <summary> 
        /// Gets or sets the Legal_Expense_Incurred value.
        /// </summary> 
        public decimal Legal_Expense_Incurred
        {
            get { return _Legal_Expense_Incurred; }
            set { _Legal_Expense_Incurred = value; }
        }


        /// <summary> 
        /// Gets or sets the Legal_Expense_Paid_to_Date value.
        /// </summary> 
        public decimal Legal_Expense_Paid_to_Date
        {
            get { return _Legal_Expense_Paid_to_Date; }
            set { _Legal_Expense_Paid_to_Date = value; }
        }


        /// <summary> 
        /// Gets or sets the Recovered_Indemnity_Deductible_Amount value.
        /// </summary> 
        public decimal Recovered_Indemnity_Deductible_Amount
        {
            get { return _Recovered_Indemnity_Deductible_Amount; }
            set { _Recovered_Indemnity_Deductible_Amount = value; }
        }


        /// <summary> 
        /// Gets or sets the Recovered_Expense_Deductible_Amount value.
        /// </summary> 
        public decimal Recovered_Expense_Deductible_Amount
        {
            get { return _Recovered_Expense_Deductible_Amount; }
            set { _Recovered_Expense_Deductible_Amount = value; }
        }


        /// <summary> 
        /// Gets or sets the Recovered_Medical_Deductible_Amount value.
        /// </summary> 
        public decimal Recovered_Medical_Deductible_Amount
        {
            get { return _Recovered_Medical_Deductible_Amount; }
            set { _Recovered_Medical_Deductible_Amount = value; }
        }


        /// <summary> 
        /// Gets or sets the Medical_Gross_Subrogation value.
        /// </summary> 
        public decimal Medical_Gross_Subrogation
        {
            get { return _Medical_Gross_Subrogation; }
            set { _Medical_Gross_Subrogation = value; }
        }


        /// <summary> 
        /// Gets or sets the Medical_Gross_Refund value.
        /// </summary> 
        public decimal Medical_Gross_Refund
        {
            get { return _Medical_Gross_Refund; }
            set { _Medical_Gross_Refund = value; }
        }


        /// <summary> 
        /// Gets or sets the Claim_Subrogation_Paid_to_Date value.
        /// </summary> 
        public decimal Claim_Subrogation_Paid_to_Date
        {
            get { return _Claim_Subrogation_Paid_to_Date; }
            set { _Claim_Subrogation_Paid_to_Date = value; }
        }


        /// <summary> 
        /// Gets or sets the Total_Payment_To_Physicians value.
        /// </summary> 
        public decimal Total_Payment_To_Physicians
        {
            get { return _Total_Payment_To_Physicians; }
            set { _Total_Payment_To_Physicians = value; }
        }


        /// <summary> 
        /// Gets or sets the Hospital_Expenses_Paid_To_Date value.
        /// </summary> 
        public decimal Hospital_Expenses_Paid_To_Date
        {
            get { return _Hospital_Expenses_Paid_To_Date; }
            set { _Hospital_Expenses_Paid_To_Date = value; }
        }


        /// <summary> 
        /// Gets or sets the Other_Medical_Paid_to_Date value.
        /// </summary> 
        public decimal Other_Medical_Paid_to_Date
        {
            get { return _Other_Medical_Paid_to_Date; }
            set { _Other_Medical_Paid_to_Date = value; }
        }


        /// <summary> 
        /// Gets or sets the Voca_Rehab_Expense_PTD value.
        /// </summary> 
        public decimal Voca_Rehab_Expense_PTD
        {
            get { return _Voca_Rehab_Expense_PTD; }
            set { _Voca_Rehab_Expense_PTD = value; }
        }


        /// <summary> 
        /// Gets or sets the Voca_Rehab_Maintenance_PTD value.
        /// </summary> 
        public decimal Voca_Rehab_Maintenance_PTD
        {
            get { return _Voca_Rehab_Maintenance_PTD; }
            set { _Voca_Rehab_Maintenance_PTD = value; }
        }


        /// <summary> 
        /// Gets or sets the Voca_Rehab_Evaluation_PTD value.
        /// </summary> 
        public decimal Voca_Rehab_Evaluation_PTD
        {
            get { return _Voca_Rehab_Evaluation_PTD; }
            set { _Voca_Rehab_Evaluation_PTD = value; }
        }


        /// <summary> 
        /// Gets or sets the Voca_Rehab_Education_PTD value.
        /// </summary> 
        public decimal Voca_Rehab_Education_PTD
        {
            get { return _Voca_Rehab_Education_PTD; }
            set { _Voca_Rehab_Education_PTD = value; }
        }

        public Nullable<DateTime> RTW_Effective_Date
        {
            get { return _RTW_Effective_Date; }
            set { _RTW_Effective_Date = value; }
        }
        public string RTW_Work_Status_Type
        {
            get { return _RTW_Work_Status_Type; }
            set { _RTW_Work_Status_Type = value; }
        }
        public string RTW_Authorized_Off_Work
        {
            get { return _RTW_Authorized_Off_Work; }
            set { _RTW_Authorized_Off_Work = value; }
        }
        public Nullable<DateTime> RTW_Date_Last_Worked
        {
            get { return _RTW_Date_Last_Worked; }
            set { _RTW_Date_Last_Worked = value; }
        }
        public string RTW_DLW_Full_Day
        {
            get { return _RTW_DLW_Full_Day; }
            set { _RTW_DLW_Full_Day = value; }
        }

        public Nullable<DateTime> RTW_Anticipated_RTW_Ex_Full_Duty
        {
            get { return _RTW_Anticipated_RTW_Ex_Full_Duty; }
            set { _RTW_Anticipated_RTW_Ex_Full_Duty = value; }
        }
        public Nullable<DateTime> RTW_Anticipated_RTW_Ex_Restricted
        {
            get { return _RTW_Anticipated_RTW_Ex_Restricted; }
            set { _RTW_Anticipated_RTW_Ex_Restricted = value; }
        }
        public Nullable<DateTime> RTW_Anticipated_RTW_CM_Full_Duty
        {
            get { return _RTW_Anticipated_RTW_CM_Full_Duty; }
            set { _RTW_Anticipated_RTW_CM_Full_Duty = value; }
        }
        public Nullable<DateTime> RTW_Anticipated_RTW_CM_Restricted
        {
            get { return _RTW_Anticipated_RTW_CM_Restricted; }
            set { _RTW_Anticipated_RTW_CM_Restricted = value; }
        }
        public Nullable<DateTime> RTW_Anticipated_RTW_Ph_Full_Duty
        {
            get { return _RTW_Anticipated_RTW_Ph_Full_Duty; }
            set { _RTW_Anticipated_RTW_Ph_Full_Duty = value; }
        }
        public Nullable<DateTime> RTW_Anticipated_RTW_Ph_Restricted
        {
            get { return _RTW_Anticipated_RTW_Ph_Restricted; }
            set { _RTW_Anticipated_RTW_Ph_Restricted = value; }
        }


        public string RTW_Moderate_Duty_Available
        {
            get { return _RTW_Moderate_Duty_Available; }
            set { _RTW_Moderate_Duty_Available = value; }
        }
        public string RTW_Modified_Duty_Offered
        {
            get { return _RTW_Modified_Duty_Offered; }
            set { _RTW_Modified_Duty_Offered = value; }
        }
        public string RTW_Modified_Duty_Accepted
        {
            get { return _RTW_Modified_Duty_Accepted; }
            set { _RTW_Modified_Duty_Accepted = value; }
        }
        public string RTW_Modified_Duty_Occupation
        {
            get { return _RTW_Modified_Duty_Occupation; }
            set { _RTW_Modified_Duty_Occupation = value; }
        }
        public string RTW_Modified_Duty_Demand
        {
            get { return _RTW_Modified_Duty_Demand; }
            set { _RTW_Modified_Duty_Demand = value; }
        }
        public string RTW_Full_Days_Modified_Duty
        {
            get { return _RTW_Full_Days_Modified_Duty; }
            set { _RTW_Full_Days_Modified_Duty = value; }
        }
        public decimal RTW_Hours_Modified_Duty //shweta
        {
            get { return _RTW_Hours_Modified_Duty; }
            set { _RTW_Hours_Modified_Duty = value; }
        }
        public string RTW_Occupation
        {
            get { return _RTW_Occupation; }
            set { _RTW_Occupation = value; }
        }
        public string RTW_Demand
        {
            get { return _RTW_Demand; }
            set { _RTW_Demand = value; }
        }
        public string RTW_Schedule
        {
            get { return _RTW_Schedule; }
            set { _RTW_Schedule = value; }
        }


        public Nullable<DateTime> RTW_Date_Modified_Duty_Available
        {
            get { return _RTW_Date_Modified_Duty_Available; }
            set { _RTW_Date_Modified_Duty_Available = value; }
        }
        public Nullable<DateTime> RTW_Date_Modified_Duty_Offered
        {
            get { return _RTW_Date_Modified_Duty_Offered; }
            set { _RTW_Date_Modified_Duty_Offered = value; }
        }
        public Nullable<DateTime> RTW_Date_Modified_Duty_Accepted
        {
            get { return _RTW_Date_Modified_Duty_Accepted; }
            set { _RTW_Date_Modified_Duty_Accepted = value; }
        }
        public Nullable<DateTime> RTW_Date_Notified
        {
            get { return _RTW_Date_Notified; }
            set { _RTW_Date_Notified = value; }
        }
        public Nullable<DateTime> RTW_Date_Disability_Began
        {
            get { return _RTW_Date_Disability_Began; }
            set { _RTW_Date_Disability_Began = value; }
        }


        public decimal RTW_Number_Lost_Time_Days
        {
            get { return _RTW_Number_Lost_Time_Days; }
            set { _RTW_Number_Lost_Time_Days = value; }
        }
        public decimal RTW_Number_Restricted_Work_Days
        {
            get { return _RTW_Number_Restricted_Work_Days; }
            set { _RTW_Number_Restricted_Work_Days = value; }
        }

        public string RTW_Reason_For_Termination
        {
            get { return _RTW_Reason_For_Termination; }
            set { _RTW_Reason_For_Termination = value; }
        }

        public decimal FK_Claim_Sub_Status
        {
            get { return _FK_Claim_Sub_Status; }
            set { _FK_Claim_Sub_Status = value; }
        }
        public decimal FK_SLT_Claims_Management
        {
            get { return _FK_SLT_Claims_Management; }
            set { _FK_SLT_Claims_Management = value; }
        }
        #endregion

        #region Constructors

        /// <summary> 
        /// Initializes a new instance of the Workers_Comp_Claims class. with the default value.
        /// </summary>
        public WC_ClaimInfo()
        {

            this._PK_Workers_Comp_Claims_ID = 0;
            this._Data_Origin = "";
            this._Other_Voca_Rehab_Expenses_PTD = -1;
            this._Voca_Rehab_Expense_Incurred = -1;
            this._Non_Scheduled_Indemnity_Incurred = -1;
            this._Non_Scheduled_Impairment_Percent = "";
            this._Funeral_Expense_PTD = -1;
            this._Lump_Sum_Settlement_Amount = -1;
            this._Employers_Liability_PTD = -1;
            this._Date_Disability_Began = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            this._Temporary_Indemnity_Incurred = -1;
            this._Date_Return_To_Work = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            this._Scheduled_Indemnity = -1;
            this._Employer_Federal_Tax_Number = "";
            this._Date_of_Max_Medical_Improvement = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            this._Surgery_Indicator = "";
            this._Attorney_Authorized_Rep = "";
            this._Controverted_Case_Indicator = "";
            this._Employee_Legal_Expense_PTD = -1;
            this._Date_Application_Filed = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            this._Date_of_Attorney_Disclosure = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            this._Year_Last_Exposed = "";
            this._FK_NCCI_Occupation_Class_Code = "";
            this._Compensation_Coverage_Code = "";
            this._Beneficiary_Relationship = "";
            this._Beneficiary_Dependency_Indicator = "";
            this._TX_NS_Companion_Table = "";
            this._TX_NS_Companion_Claim_Number = "";
            this._Beneficiary1_DOB = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            this._Beneficiary2_DOB = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            this._Beneficiary3_DOB = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            this._Beneficiary4_DOB = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            this._Occupation_Description = "";
            this._Claim_Status_Description = "";
            this._FK_Cause_of_Injury_Code = "";
            this._FK_Nature_of_Injury_Code = "";
            this._FK_Part_of_Body_Code = "";
            this._Cause_Injury_Body_Part_Description = "";
            this._Carrier_Name = "";
            this._LT_Med_Only_Flag = "";
            this._Date_of_Hire = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            this._State_of_Employment = "";
            this._Nature_of_Benefit_Code = "";
            this._Number_of_Dependents = "";
            this._Percentage_Impairment = "";
            this._Date_of_Death = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            this._Zip_of_Accident_Site = "";
            this._Date_Reported_to_Employer = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            this._Date_of_First_Indemnity_Payment = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            this._Accident_City_Town = "";
            this._Employment_Status = "";
            this._FK_NCCI_Cause_of_Injury_Code = "";
            this._FK_NCCI_Body_Part_Code = "";
            this._NCCI_Nature_Of_Injury_Code = "";
            this._Previous_TPA_Claim_Num_Takeover = "";
            this._Previous_TPA_Indemnity_Paid = -1;
            this._Previous_TPA_Medical_Paid = -1;
            this._Previous_TPA_Expense_Paid = -1;
            this._Adjustor_Code = "";
            this._Associated_First_Report = 0;
            this._Date_of_Update = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            this._Origin_Claim_Number = "";
            this._Origin_Key_Claim_Number = "";
            this._Claimant_Sequence_Number = "";
            this._Employee_Name = "";
            this._Claimant_First_Name = "";
            this._Claimant_Last_Name = "";
            this._Employee_Street = "";
            this._Employee_City = "";
            this._Employee_State = "";
            this._Employee_Zip = "";
            this._Employee_Gender = "";
            this._Employee_SSN = "";
            this._Marital_Status = "";
            this._Employee_Date_of_Birth = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            this._State_of_Accident = "";
            this._State_of_Jurisdiction = "";
            this._Date_Reported_to_Insurer = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            this._Date_of_Accident = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            this._Time_of_Loss = "";
            this._Date_Entered = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            this._Date_Closed = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            this._FK_Claim_Status = "";
            this._FK_Insured_Location_Code = "";
            this._FK_Coverage_Code = "";
            this._Date_Suit_Filed = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            this._LitigationYN = "";
            this._Suit_Result_Code = "";
            this._Suit_Type_Code = "";
            this._SRS_Policy_Number = "";
            this._Policy_Effective_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            this._Policy_Expiration_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            this._Other_Carrier_Policy_Number = "";
            this._Carrier_Effective_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            this._Carrier_Expiration_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            this._Plaintiff_Attorney_Code = "";
            this._Indemnity_Gross_Paid = -1;
            this._Net_Indemnity_Paid = -1;
            this._Indemnity_Net_Recovered = -1;
            this._Indemnity_Incurred = -1;
            this._Indemnity_Outstanding = -1;
            this._Expense_Gross_Paid = -1;
            this._Net_Expense_Paid = -1;
            this._Expense_Net_Recovered = -1;
            this._Expense_Incurred = -1;
            this._Expense_Outstanding = -1;
            this._Medical_Gross_Paid = -1;
            this._Net_Medical_Paid = -1;
            this._Medical_Net_Recovered = -1;
            this._Medical_Incurred = -1;
            this._Medical_Outstanding = -1;
            this._Indemnity_Gross_Subrogation = -1;
            this._Indemnity_Subrogation_Expense = -1;
            this._Indemnity_Gross_Salvage = -1;
            this._Indemnity_Salvage_Expense = -1;
            this._Indemnity_Gross_Refund = -1;
            this._Ale_Gross_Subrogation = -1;
            this._Ale_Gross_Salvage = -1;
            this._Ale_Gross_Refund = -1;
            this._Ale_Refund_Expense = -1;
            this._Legal_Expense_Incurred = -1;
            this._Legal_Expense_Paid_to_Date = -1;
            this._Recovered_Indemnity_Deductible_Amount = -1;
            this._Recovered_Expense_Deductible_Amount = -1;
            this._Recovered_Medical_Deductible_Amount = -1;
            this._Medical_Gross_Subrogation = -1;
            this._Medical_Gross_Refund = -1;
            this._Claim_Subrogation_Paid_to_Date = -1;
            this._Total_Payment_To_Physicians = -1;
            this._Hospital_Expenses_Paid_To_Date = -1;
            this._Other_Medical_Paid_to_Date = -1;
            this._Voca_Rehab_Expense_PTD = -1;
            this._Voca_Rehab_Maintenance_PTD = -1;
            this._Voca_Rehab_Evaluation_PTD = -1;
            this._Voca_Rehab_Education_PTD = -1;
            this._FK_Claim_Sub_Status = -1;
            this._FK_SLT_Claims_Management = -1;

        }


        /// <summary> 
        /// Initializes a new instance of the Workers_Comp_Claims class for passed PrimaryKey with the values set from Database.
        /// </summary> 
        public WC_ClaimInfo(Int64 PK)
        {
            DataTable dtWorkers_Comp_Claims = SelectByPK(PK).Tables[0];
            if (dtWorkers_Comp_Claims.Rows.Count > 0)
            {
                DataRow drWorkers_Comp_Claims = dtWorkers_Comp_Claims.Rows[0];
                this._PK_Workers_Comp_Claims_ID = drWorkers_Comp_Claims["PK_Workers_Comp_Claims_ID"] != DBNull.Value ? Convert.ToInt64(drWorkers_Comp_Claims["PK_Workers_Comp_Claims_ID"]) : 0;
                this._Data_Origin = Convert.ToString(drWorkers_Comp_Claims["TX_NS_Companion_Table"]);
                this._TX_NS_Companion_Table = Convert.ToString(drWorkers_Comp_Claims["TX_NS_Companion_Claim_Number"]);
                this._TX_NS_Companion_Claim_Number = Convert.ToString(drWorkers_Comp_Claims["Data_Origin"]);
                this._Other_Voca_Rehab_Expenses_PTD = drWorkers_Comp_Claims["Other_Voca_Rehab_Expenses_PTD"] != DBNull.Value ? Convert.ToDecimal(drWorkers_Comp_Claims["Other_Voca_Rehab_Expenses_PTD"]) : 0;
                this._Voca_Rehab_Expense_Incurred = drWorkers_Comp_Claims["Voca_Rehab_Expense_Incurred"] != DBNull.Value ? Convert.ToDecimal(drWorkers_Comp_Claims["Voca_Rehab_Expense_Incurred"]) : 0;
                this._Non_Scheduled_Indemnity_Incurred = drWorkers_Comp_Claims["Non_Scheduled_Indemnity_Incurred"] != DBNull.Value ? Convert.ToDecimal(drWorkers_Comp_Claims["Non_Scheduled_Indemnity_Incurred"]) : 0;
                this._Non_Scheduled_Impairment_Percent = Convert.ToString(drWorkers_Comp_Claims["Non_Scheduled_Impairment_Percent"]);
                this._Funeral_Expense_PTD = drWorkers_Comp_Claims["Funeral_Expense_PTD"] != DBNull.Value ? Convert.ToDecimal(drWorkers_Comp_Claims["Funeral_Expense_PTD"]) : 0;
                this._Lump_Sum_Settlement_Amount = drWorkers_Comp_Claims["Lump_Sum_Settlement_Amount"] != DBNull.Value ? Convert.ToDecimal(drWorkers_Comp_Claims["Lump_Sum_Settlement_Amount"]) : 0;
                this._Employers_Liability_PTD = drWorkers_Comp_Claims["Employers_Liability_PTD"] != DBNull.Value ? Convert.ToDecimal(drWorkers_Comp_Claims["Employers_Liability_PTD"]) : 0;
                this._Date_Disability_Began = drWorkers_Comp_Claims["Date_Disability_Began"] != DBNull.Value ? Convert.ToDateTime(drWorkers_Comp_Claims["Date_Disability_Began"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Temporary_Indemnity_Incurred = drWorkers_Comp_Claims["Temporary_Indemnity_Incurred"] != DBNull.Value ? Convert.ToDecimal(drWorkers_Comp_Claims["Temporary_Indemnity_Incurred"]) : 0;
                this._Date_Return_To_Work = drWorkers_Comp_Claims["Date_Return_To_Work"] != DBNull.Value ? Convert.ToDateTime(drWorkers_Comp_Claims["Date_Return_To_Work"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Scheduled_Indemnity = drWorkers_Comp_Claims["Scheduled_Indemnity"] != DBNull.Value ? Convert.ToDecimal(drWorkers_Comp_Claims["Scheduled_Indemnity"]) : 0;
                this._Employer_Federal_Tax_Number = Convert.ToString(drWorkers_Comp_Claims["Employer_Federal_Tax_Number"]);
                this._Date_of_Max_Medical_Improvement = drWorkers_Comp_Claims["Date_of_Max_Medical_Improvement"] != DBNull.Value ? Convert.ToDateTime(drWorkers_Comp_Claims["Date_of_Max_Medical_Improvement"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Surgery_Indicator = Convert.ToString(drWorkers_Comp_Claims["Surgery_Indicator"]);
                this._Attorney_Authorized_Rep = Convert.ToString(drWorkers_Comp_Claims["Attorney_Authorized_Rep"]);
                this._Controverted_Case_Indicator = Convert.ToString(drWorkers_Comp_Claims["Controverted_Case_Indicator"]);
                this._Employee_Legal_Expense_PTD = drWorkers_Comp_Claims["Employee_Legal_Expense_PTD"] != DBNull.Value ? Convert.ToDecimal(drWorkers_Comp_Claims["Employee_Legal_Expense_PTD"]) : 0;
                this._Date_Application_Filed = drWorkers_Comp_Claims["Date_Application_Filed"] != DBNull.Value ? Convert.ToDateTime(drWorkers_Comp_Claims["Date_Application_Filed"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Date_of_Attorney_Disclosure = drWorkers_Comp_Claims["Date_of_Attorney_Disclosure"] != DBNull.Value ? Convert.ToDateTime(drWorkers_Comp_Claims["Date_of_Attorney_Disclosure"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Year_Last_Exposed = Convert.ToString(drWorkers_Comp_Claims["Year_Last_Exposed"]);
                this._FK_NCCI_Occupation_Class_Code = Convert.ToString(drWorkers_Comp_Claims["FK_NCCI_Occupation_Class_Code"]);
                this._Compensation_Coverage_Code = Convert.ToString(drWorkers_Comp_Claims["Compensation_Coverage_Code"]);
                this._Beneficiary_Relationship = Convert.ToString(drWorkers_Comp_Claims["Beneficiary_Relationship"]);
                this._Beneficiary_Dependency_Indicator = Convert.ToString(drWorkers_Comp_Claims["Beneficiary_Dependency_Indicator"]);
                this._Beneficiary1_DOB = drWorkers_Comp_Claims["Beneficiary1_DOB"] != DBNull.Value ? Convert.ToDateTime(drWorkers_Comp_Claims["Beneficiary1_DOB"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Beneficiary2_DOB = drWorkers_Comp_Claims["Beneficiary2_DOB"] != DBNull.Value ? Convert.ToDateTime(drWorkers_Comp_Claims["Beneficiary2_DOB"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Beneficiary3_DOB = drWorkers_Comp_Claims["Beneficiary3_DOB"] != DBNull.Value ? Convert.ToDateTime(drWorkers_Comp_Claims["Beneficiary3_DOB"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Beneficiary4_DOB = drWorkers_Comp_Claims["Beneficiary4_DOB"] != DBNull.Value ? Convert.ToDateTime(drWorkers_Comp_Claims["Beneficiary4_DOB"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Occupation_Description = Convert.ToString(drWorkers_Comp_Claims["Occupation_Description"]);
                this._Claim_Status_Description = Convert.ToString(drWorkers_Comp_Claims["Claim_Status_Description"]);
                this._FK_Cause_of_Injury_Code = Convert.ToString(drWorkers_Comp_Claims["FK_Cause_of_Injury_Code"]);
                this._FK_Nature_of_Injury_Code = Convert.ToString(drWorkers_Comp_Claims["FK_Nature_of_Injury_Code"]);
                this._FK_Part_of_Body_Code = Convert.ToString(drWorkers_Comp_Claims["FK_Part_of_Body_Code"]);
                this._Cause_Injury_Body_Part_Description = Convert.ToString(drWorkers_Comp_Claims["Cause_Injury_Body_Part_Description"]);
                this._Carrier_Name = Convert.ToString(drWorkers_Comp_Claims["Carrier_Name"]);
                this._LT_Med_Only_Flag = Convert.ToString(drWorkers_Comp_Claims["LT_Med_Only_Flag"]);
                this._Date_of_Hire = drWorkers_Comp_Claims["Date_of_Hire"] != DBNull.Value ? Convert.ToDateTime(drWorkers_Comp_Claims["Date_of_Hire"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._State_of_Employment = Convert.ToString(drWorkers_Comp_Claims["State_of_Employment"]);
                this._Nature_of_Benefit_Code = Convert.ToString(drWorkers_Comp_Claims["Nature_of_Benefit_Code"]);
                this._Number_of_Dependents = Convert.ToString(drWorkers_Comp_Claims["Number_of_Dependents"]);
                this._Percentage_Impairment = Convert.ToString(drWorkers_Comp_Claims["Percentage_Impairment"]);
                this._Date_of_Death = drWorkers_Comp_Claims["Date_of_Death"] != DBNull.Value ? Convert.ToDateTime(drWorkers_Comp_Claims["Date_of_Death"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Zip_of_Accident_Site = Convert.ToString(drWorkers_Comp_Claims["Zip_of_Accident_Site"]);
                this._Date_Reported_to_Employer = drWorkers_Comp_Claims["Date_Reported_to_Employer"] != DBNull.Value ? Convert.ToDateTime(drWorkers_Comp_Claims["Date_Reported_to_Employer"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Date_of_First_Indemnity_Payment = drWorkers_Comp_Claims["Date_of_First_Indemnity_Payment"] != DBNull.Value ? Convert.ToDateTime(drWorkers_Comp_Claims["Date_of_First_Indemnity_Payment"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Accident_City_Town = Convert.ToString(drWorkers_Comp_Claims["Accident_City_Town"]);
                this._Employment_Status = Convert.ToString(drWorkers_Comp_Claims["Employment_Status"]);
                this._FK_NCCI_Cause_of_Injury_Code = Convert.ToString(drWorkers_Comp_Claims["FK_NCCI_Cause_of_Injury_Code"]);
                this._FK_NCCI_Body_Part_Code = Convert.ToString(drWorkers_Comp_Claims["FK_NCCI_Body_Part_Code"]);
                this._NCCI_Nature_Of_Injury_Code = Convert.ToString(drWorkers_Comp_Claims["NCCI_Nature_Of_Injury_Code"]);
                this._Previous_TPA_Claim_Num_Takeover = Convert.ToString(drWorkers_Comp_Claims["Previous_TPA_Claim_Num_Takeover"]);
                this._Previous_TPA_Indemnity_Paid = drWorkers_Comp_Claims["Previous_TPA_Indemnity_Paid"] != DBNull.Value ? Convert.ToDecimal(drWorkers_Comp_Claims["Previous_TPA_Indemnity_Paid"]) : 0;
                this._Previous_TPA_Medical_Paid = drWorkers_Comp_Claims["Previous_TPA_Medical_Paid"] != DBNull.Value ? Convert.ToDecimal(drWorkers_Comp_Claims["Previous_TPA_Medical_Paid"]) : 0;
                this._Previous_TPA_Expense_Paid = drWorkers_Comp_Claims["Previous_TPA_Expense_Paid"] != DBNull.Value ? Convert.ToDecimal(drWorkers_Comp_Claims["Previous_TPA_Expense_Paid"]) : 0;
                this._Adjustor_Code = Convert.ToString(drWorkers_Comp_Claims["Adjustor_Code"]);
                this._Associated_First_Report = drWorkers_Comp_Claims["Associated_First_Report"] != DBNull.Value ? Convert.ToInt32(drWorkers_Comp_Claims["Associated_First_Report"]) : 0;
                this._Date_of_Update = drWorkers_Comp_Claims["Date_of_Update"] != DBNull.Value ? Convert.ToDateTime(drWorkers_Comp_Claims["Date_of_Update"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Origin_Claim_Number = Convert.ToString(drWorkers_Comp_Claims["Origin_Claim_Number"]);
                this._Origin_Key_Claim_Number = Convert.ToString(drWorkers_Comp_Claims["Origin_Key_Claim_Number"]);
                this._Claimant_Sequence_Number = Convert.ToString(drWorkers_Comp_Claims["Claimant_Sequence_Number"]);
                this._Employee_Name = Convert.ToString(drWorkers_Comp_Claims["Employee_Name"]);
                this._Claimant_First_Name = Convert.ToString(drWorkers_Comp_Claims["Claimant_First_Name"]);
                this._Claimant_Last_Name = Convert.ToString(drWorkers_Comp_Claims["Claimant_Last_Name"]);
                this._Employee_Street = Convert.ToString(drWorkers_Comp_Claims["Employee_Street"]);
                this._Employee_City = Convert.ToString(drWorkers_Comp_Claims["Employee_City"]);
                this._Employee_State = Convert.ToString(drWorkers_Comp_Claims["Employee_State"]);
                this._Employee_Zip = Convert.ToString(drWorkers_Comp_Claims["Employee_Zip"]);
                this._Employee_Gender = Convert.ToString(drWorkers_Comp_Claims["Employee_Gender"]);
                this._Employee_SSN = Convert.ToString(drWorkers_Comp_Claims["Employee_SSN"]);
                this._Marital_Status = Convert.ToString(drWorkers_Comp_Claims["Marital_Status"]);
                this._Employee_Date_of_Birth = drWorkers_Comp_Claims["Employee_Date_of_Birth"] != DBNull.Value ? Convert.ToDateTime(drWorkers_Comp_Claims["Employee_Date_of_Birth"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._State_of_Accident = Convert.ToString(drWorkers_Comp_Claims["State_of_Accident"]);
                this._State_of_Jurisdiction = Convert.ToString(drWorkers_Comp_Claims["State_of_Jurisdiction"]);
                this._Date_Reported_to_Insurer = drWorkers_Comp_Claims["Date_Reported_to_Insurer"] != DBNull.Value ? Convert.ToDateTime(drWorkers_Comp_Claims["Date_Reported_to_Insurer"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Date_of_Accident = drWorkers_Comp_Claims["Date_of_Accident"] != DBNull.Value ? Convert.ToDateTime(drWorkers_Comp_Claims["Date_of_Accident"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Time_of_Loss = Convert.ToString(drWorkers_Comp_Claims["Time_of_Loss"]);
                this._Date_Entered = drWorkers_Comp_Claims["Date_Entered"] != DBNull.Value ? Convert.ToDateTime(drWorkers_Comp_Claims["Date_Entered"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Date_Closed = drWorkers_Comp_Claims["Date_Closed"] != DBNull.Value ? Convert.ToDateTime(drWorkers_Comp_Claims["Date_Closed"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._FK_Claim_Status = Convert.ToString(drWorkers_Comp_Claims["FK_Claim_Status"]);
                this._FK_Insured_Location_Code = Convert.ToString(drWorkers_Comp_Claims["FK_Insured_Location_Code"]);
                this._FK_Coverage_Code = Convert.ToString(drWorkers_Comp_Claims["FK_Coverage_Code"]);
                this._Date_Suit_Filed = drWorkers_Comp_Claims["Date_Suit_Filed"] != DBNull.Value ? Convert.ToDateTime(drWorkers_Comp_Claims["Date_Suit_Filed"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._LitigationYN = Convert.ToString(drWorkers_Comp_Claims["LitigationYN"]);
                this._Suit_Result_Code = Convert.ToString(drWorkers_Comp_Claims["Suit_Result_Code"]);
                this._Suit_Type_Code = Convert.ToString(drWorkers_Comp_Claims["Suit_Type_Code"]);
                this._SRS_Policy_Number = Convert.ToString(drWorkers_Comp_Claims["SRS_Policy_Number"]);
                this._Policy_Effective_Date = drWorkers_Comp_Claims["Policy_Effective_Date"] != DBNull.Value ? Convert.ToDateTime(drWorkers_Comp_Claims["Policy_Effective_Date"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Policy_Expiration_Date = drWorkers_Comp_Claims["Policy_Expiration_Date"] != DBNull.Value ? Convert.ToDateTime(drWorkers_Comp_Claims["Policy_Expiration_Date"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Other_Carrier_Policy_Number = Convert.ToString(drWorkers_Comp_Claims["Other_Carrier_Policy_Number"]);
                this._Carrier_Effective_Date = drWorkers_Comp_Claims["Carrier_Effective_Date"] != DBNull.Value ? Convert.ToDateTime(drWorkers_Comp_Claims["Carrier_Effective_Date"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Carrier_Expiration_Date = drWorkers_Comp_Claims["Carrier_Expiration_Date"] != DBNull.Value ? Convert.ToDateTime(drWorkers_Comp_Claims["Carrier_Expiration_Date"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Plaintiff_Attorney_Code = Convert.ToString(drWorkers_Comp_Claims["Plaintiff_Attorney_Code"]);
                this._Indemnity_Gross_Paid = drWorkers_Comp_Claims["Indemnity_Gross_Paid"] != DBNull.Value ? Convert.ToDecimal(drWorkers_Comp_Claims["Indemnity_Gross_Paid"]) : 0;
                this._Net_Indemnity_Paid = drWorkers_Comp_Claims["Net_Indemnity_Paid"] != DBNull.Value ? Convert.ToDecimal(drWorkers_Comp_Claims["Net_Indemnity_Paid"]) : 0;
                this._Indemnity_Net_Recovered = drWorkers_Comp_Claims["Indemnity_Net_Recovered"] != DBNull.Value ? Convert.ToDecimal(drWorkers_Comp_Claims["Indemnity_Net_Recovered"]) : 0;
                this._Indemnity_Incurred = drWorkers_Comp_Claims["Indemnity_Incurred"] != DBNull.Value ? Convert.ToDecimal(drWorkers_Comp_Claims["Indemnity_Incurred"]) : 0;
                this._Indemnity_Outstanding = drWorkers_Comp_Claims["Indemnity_Outstanding"] != DBNull.Value ? Convert.ToDecimal(drWorkers_Comp_Claims["Indemnity_Outstanding"]) : 0;
                this._Expense_Gross_Paid = drWorkers_Comp_Claims["Expense_Gross_Paid"] != DBNull.Value ? Convert.ToDecimal(drWorkers_Comp_Claims["Expense_Gross_Paid"]) : 0;
                this._Net_Expense_Paid = drWorkers_Comp_Claims["Net_Expense_Paid"] != DBNull.Value ? Convert.ToDecimal(drWorkers_Comp_Claims["Net_Expense_Paid"]) : 0;
                this._Expense_Net_Recovered = drWorkers_Comp_Claims["Expense_Net_Recovered"] != DBNull.Value ? Convert.ToDecimal(drWorkers_Comp_Claims["Expense_Net_Recovered"]) : 0;
                this._Expense_Incurred = drWorkers_Comp_Claims["Expense_Incurred"] != DBNull.Value ? Convert.ToDecimal(drWorkers_Comp_Claims["Expense_Incurred"]) : 0;
                this._Expense_Outstanding = drWorkers_Comp_Claims["Expense_Outstanding"] != DBNull.Value ? Convert.ToDecimal(drWorkers_Comp_Claims["Expense_Outstanding"]) : 0;
                this._Medical_Gross_Paid = drWorkers_Comp_Claims["Medical_Gross_Paid"] != DBNull.Value ? Convert.ToDecimal(drWorkers_Comp_Claims["Medical_Gross_Paid"]) : 0;
                this._Net_Medical_Paid = drWorkers_Comp_Claims["Net_Medical_Paid"] != DBNull.Value ? Convert.ToDecimal(drWorkers_Comp_Claims["Net_Medical_Paid"]) : 0;
                this._Medical_Net_Recovered = drWorkers_Comp_Claims["Medical_Net_Recovered"] != DBNull.Value ? Convert.ToDecimal(drWorkers_Comp_Claims["Medical_Net_Recovered"]) : 0;
                this._Medical_Incurred = drWorkers_Comp_Claims["Medical_Incurred"] != DBNull.Value ? Convert.ToDecimal(drWorkers_Comp_Claims["Medical_Incurred"]) : 0;
                this._Medical_Outstanding = drWorkers_Comp_Claims["Medical_Outstanding"] != DBNull.Value ? Convert.ToDecimal(drWorkers_Comp_Claims["Medical_Outstanding"]) : 0;
                this._Indemnity_Gross_Subrogation = drWorkers_Comp_Claims["Indemnity_Gross_Subrogation"] != DBNull.Value ? Convert.ToDecimal(drWorkers_Comp_Claims["Indemnity_Gross_Subrogation"]) : 0;
                this._Indemnity_Subrogation_Expense = drWorkers_Comp_Claims["Indemnity_Subrogation_Expense"] != DBNull.Value ? Convert.ToDecimal(drWorkers_Comp_Claims["Indemnity_Subrogation_Expense"]) : 0;
                this._Indemnity_Gross_Salvage = drWorkers_Comp_Claims["Indemnity_Gross_Salvage"] != DBNull.Value ? Convert.ToDecimal(drWorkers_Comp_Claims["Indemnity_Gross_Salvage"]) : 0;
                this._Indemnity_Salvage_Expense = drWorkers_Comp_Claims["Indemnity_Salvage_Expense"] != DBNull.Value ? Convert.ToDecimal(drWorkers_Comp_Claims["Indemnity_Salvage_Expense"]) : 0;
                this._Indemnity_Gross_Refund = drWorkers_Comp_Claims["Indemnity_Gross_Refund"] != DBNull.Value ? Convert.ToDecimal(drWorkers_Comp_Claims["Indemnity_Gross_Refund"]) : 0;
                this._Ale_Gross_Subrogation = drWorkers_Comp_Claims["Ale_Gross_Subrogation"] != DBNull.Value ? Convert.ToDecimal(drWorkers_Comp_Claims["Ale_Gross_Subrogation"]) : 0;
                this._Ale_Gross_Salvage = drWorkers_Comp_Claims["Ale_Gross_Salvage"] != DBNull.Value ? Convert.ToDecimal(drWorkers_Comp_Claims["Ale_Gross_Salvage"]) : 0;
                this._Ale_Gross_Refund = drWorkers_Comp_Claims["Ale_Gross_Refund"] != DBNull.Value ? Convert.ToDecimal(drWorkers_Comp_Claims["Ale_Gross_Refund"]) : 0;
                this._Ale_Refund_Expense = drWorkers_Comp_Claims["Ale_Refund_Expense"] != DBNull.Value ? Convert.ToDecimal(drWorkers_Comp_Claims["Ale_Refund_Expense"]) : 0;
                this._Legal_Expense_Incurred = drWorkers_Comp_Claims["Legal_Expense_Incurred"] != DBNull.Value ? Convert.ToDecimal(drWorkers_Comp_Claims["Legal_Expense_Incurred"]) : 0;
                this._Legal_Expense_Paid_to_Date = drWorkers_Comp_Claims["Legal_Expense_Paid_to_Date"] != DBNull.Value ? Convert.ToDecimal(drWorkers_Comp_Claims["Legal_Expense_Paid_to_Date"]) : 0;
                this._Recovered_Indemnity_Deductible_Amount = drWorkers_Comp_Claims["Recovered_Indemnity_Deductible_Amount"] != DBNull.Value ? Convert.ToDecimal(drWorkers_Comp_Claims["Recovered_Indemnity_Deductible_Amount"]) : 0;
                this._Recovered_Expense_Deductible_Amount = drWorkers_Comp_Claims["Recovered_Expense_Deductible_Amount"] != DBNull.Value ? Convert.ToDecimal(drWorkers_Comp_Claims["Recovered_Expense_Deductible_Amount"]) : 0;
                this._Recovered_Medical_Deductible_Amount = drWorkers_Comp_Claims["Recovered_Medical_Deductible_Amount"] != DBNull.Value ? Convert.ToDecimal(drWorkers_Comp_Claims["Recovered_Medical_Deductible_Amount"]) : 0;
                this._Medical_Gross_Subrogation = drWorkers_Comp_Claims["Medical_Gross_Subrogation"] != DBNull.Value ? Convert.ToDecimal(drWorkers_Comp_Claims["Medical_Gross_Subrogation"]) : 0;
                this._Medical_Gross_Refund = drWorkers_Comp_Claims["Medical_Gross_Refund"] != DBNull.Value ? Convert.ToDecimal(drWorkers_Comp_Claims["Medical_Gross_Refund"]) : 0;
                this._Claim_Subrogation_Paid_to_Date = drWorkers_Comp_Claims["Claim_Subrogation_Paid_to_Date"] != DBNull.Value ? Convert.ToDecimal(drWorkers_Comp_Claims["Claim_Subrogation_Paid_to_Date"]) : 0;
                this._Total_Payment_To_Physicians = drWorkers_Comp_Claims["Total_Payment_To_Physicians"] != DBNull.Value ? Convert.ToDecimal(drWorkers_Comp_Claims["Total_Payment_To_Physicians"]) : 0;
                this._Hospital_Expenses_Paid_To_Date = drWorkers_Comp_Claims["Hospital_Expenses_Paid_To_Date"] != DBNull.Value ? Convert.ToDecimal(drWorkers_Comp_Claims["Hospital_Expenses_Paid_To_Date"]) : 0;
                this._Other_Medical_Paid_to_Date = drWorkers_Comp_Claims["Other_Medical_Paid_to_Date"] != DBNull.Value ? Convert.ToDecimal(drWorkers_Comp_Claims["Other_Medical_Paid_to_Date"]) : 0;
                this._Voca_Rehab_Expense_PTD = drWorkers_Comp_Claims["Voca_Rehab_Expense_PTD"] != DBNull.Value ? Convert.ToDecimal(drWorkers_Comp_Claims["Voca_Rehab_Expense_PTD"]) : 0;
                this._Voca_Rehab_Maintenance_PTD = drWorkers_Comp_Claims["Voca_Rehab_Maintenance_PTD"] != DBNull.Value ? Convert.ToDecimal(drWorkers_Comp_Claims["Voca_Rehab_Maintenance_PTD"]) : 0;
                this._Voca_Rehab_Evaluation_PTD = drWorkers_Comp_Claims["Voca_Rehab_Evaluation_PTD"] != DBNull.Value ? Convert.ToDecimal(drWorkers_Comp_Claims["Voca_Rehab_Evaluation_PTD"]) : 0;
                this._Voca_Rehab_Education_PTD = drWorkers_Comp_Claims["Voca_Rehab_Education_PTD"] != DBNull.Value ? Convert.ToDecimal(drWorkers_Comp_Claims["Voca_Rehab_Education_PTD"]) : 0;
                this._FK_Claim_Sub_Status = drWorkers_Comp_Claims["FK_Claim_Sub_Status"] != DBNull.Value ? Convert.ToDecimal(drWorkers_Comp_Claims["FK_Claim_Sub_Status"]) : 0;
                this._FK_SLT_Claims_Management = drWorkers_Comp_Claims["FK_SLT_Claims_Management"] != DBNull.Value ? Convert.ToDecimal(drWorkers_Comp_Claims["FK_SLT_Claims_Management"]) : 0;
            }
            else
            {
                this._PK_Workers_Comp_Claims_ID = 0;
                this._Data_Origin = "";
                this._TX_NS_Companion_Table = "";
                this._TX_NS_Companion_Claim_Number = "";
                this._Other_Voca_Rehab_Expenses_PTD = -1;
                this._Voca_Rehab_Expense_Incurred = -1;
                this._Non_Scheduled_Indemnity_Incurred = -1;
                this._Non_Scheduled_Impairment_Percent = "";
                this._Funeral_Expense_PTD = -1;
                this._Lump_Sum_Settlement_Amount = -1;
                this._Employers_Liability_PTD = -1;
                this._Date_Disability_Began = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Temporary_Indemnity_Incurred = -1;
                this._Date_Return_To_Work = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Scheduled_Indemnity = -1;
                this._Employer_Federal_Tax_Number = "";
                this._Date_of_Max_Medical_Improvement = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Surgery_Indicator = "";
                this._Attorney_Authorized_Rep = "";
                this._Controverted_Case_Indicator = "";
                this._Employee_Legal_Expense_PTD = -1;
                this._Date_Application_Filed = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Date_of_Attorney_Disclosure = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Year_Last_Exposed = "";
                this._FK_NCCI_Occupation_Class_Code = "";
                this._Compensation_Coverage_Code = "";
                this._Beneficiary_Relationship = "";
                this._Beneficiary_Dependency_Indicator = "";
                this._Beneficiary1_DOB = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Beneficiary2_DOB = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Beneficiary3_DOB = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Beneficiary4_DOB = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Occupation_Description = "";
                this._Claim_Status_Description = "";
                this._FK_Cause_of_Injury_Code = "";
                this._FK_Nature_of_Injury_Code = "";
                this._FK_Part_of_Body_Code = "";
                this._Cause_Injury_Body_Part_Description = "";
                this._Carrier_Name = "";
                this._LT_Med_Only_Flag = "";
                this._Date_of_Hire = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._State_of_Employment = "";
                this._Nature_of_Benefit_Code = "";
                this._Number_of_Dependents = "";
                this._Percentage_Impairment = "";
                this._Date_of_Death = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Zip_of_Accident_Site = "";
                this._Date_Reported_to_Employer = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Date_of_First_Indemnity_Payment = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Accident_City_Town = "";
                this._Employment_Status = "";
                this._FK_NCCI_Cause_of_Injury_Code = "";
                this._FK_NCCI_Body_Part_Code = "";
                this._NCCI_Nature_Of_Injury_Code = "";
                this._Previous_TPA_Claim_Num_Takeover = "";
                this._Previous_TPA_Indemnity_Paid = -1;
                this._Previous_TPA_Medical_Paid = -1;
                this._Previous_TPA_Expense_Paid = -1;
                this._Adjustor_Code = "";
                this._Associated_First_Report = 0;
                this._Date_of_Update = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Origin_Claim_Number = "";
                this._Origin_Key_Claim_Number = "";
                this._Claimant_Sequence_Number = "";
                this._Employee_Name = "";
                this._Claimant_First_Name = "";
                this._Claimant_Last_Name = "";
                this._Employee_Street = "";
                this._Employee_City = "";
                this._Employee_State = "";
                this._Employee_Zip = "";
                this._Employee_Gender = "";
                this._Employee_SSN = "";
                this._Marital_Status = "";
                this._Employee_Date_of_Birth = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._State_of_Accident = "";
                this._State_of_Jurisdiction = "";
                this._Date_Reported_to_Insurer = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Date_of_Accident = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Time_of_Loss = "";
                this._Date_Entered = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Date_Closed = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._FK_Claim_Status = "";
                this._FK_Insured_Location_Code = "";
                this._FK_Coverage_Code = "";
                this._Date_Suit_Filed = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._LitigationYN = "";
                this._Suit_Result_Code = "";
                this._Suit_Type_Code = "";
                this._SRS_Policy_Number = "";
                this._Policy_Effective_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Policy_Expiration_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Other_Carrier_Policy_Number = "";
                this._Carrier_Effective_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Carrier_Expiration_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Plaintiff_Attorney_Code = "";
                this._Indemnity_Gross_Paid = -1;
                this._Net_Indemnity_Paid = -1;
                this._Indemnity_Net_Recovered = -1;
                this._Indemnity_Incurred = -1;
                this._Indemnity_Outstanding = -1;
                this._Expense_Gross_Paid = -1;
                this._Net_Expense_Paid = -1;
                this._Expense_Net_Recovered = -1;
                this._Expense_Incurred = -1;
                this._Expense_Outstanding = -1;
                this._Medical_Gross_Paid = -1;
                this._Net_Medical_Paid = -1;
                this._Medical_Net_Recovered = -1;
                this._Medical_Incurred = -1;
                this._Medical_Outstanding = -1;
                this._Indemnity_Gross_Subrogation = -1;
                this._Indemnity_Subrogation_Expense = -1;
                this._Indemnity_Gross_Salvage = -1;
                this._Indemnity_Salvage_Expense = -1;
                this._Indemnity_Gross_Refund = -1;
                this._Ale_Gross_Subrogation = -1;
                this._Ale_Gross_Salvage = -1;
                this._Ale_Gross_Refund = -1;
                this._Ale_Refund_Expense = -1;
                this._Legal_Expense_Incurred = -1;
                this._Legal_Expense_Paid_to_Date = -1;
                this._Recovered_Indemnity_Deductible_Amount = -1;
                this._Recovered_Expense_Deductible_Amount = -1;
                this._Recovered_Medical_Deductible_Amount = -1;
                this._Medical_Gross_Subrogation = -1;
                this._Medical_Gross_Refund = -1;
                this._Claim_Subrogation_Paid_to_Date = -1;
                this._Total_Payment_To_Physicians = -1;
                this._Hospital_Expenses_Paid_To_Date = -1;
                this._Other_Medical_Paid_to_Date = -1;
                this._Voca_Rehab_Expense_PTD = -1;
                this._Voca_Rehab_Maintenance_PTD = -1;
                this._Voca_Rehab_Evaluation_PTD = -1;
                this._Voca_Rehab_Education_PTD = -1;
                this._FK_Claim_Sub_Status = -1;
                this._FK_SLT_Claims_Management = -1;
            }
        }

        #endregion

        #region Method

        /// <summary>
        /// Selects a single record from the Workers_Comp_Claims table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectByPK(Int64 pK_Workers_Comp_Claims_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Workers_Comp_ClaimsSelectByPK");

            db.AddInParameter(dbCommand, "PK_Workers_Comp_Claims_ID", DbType.Int64, pK_Workers_Comp_Claims_ID);

            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet SelectEmployee_Name()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Workers_Comp_ClaimsSelectEmployee_Name");

            return db.ExecuteDataSet(dbCommand);
        }
        public static DataSet SelectTPA_Claim_Number()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Workers_Comp_ClaimsSelectTPA_Claim_Number");

            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet SelectTPA_Claim_NumberByLocationdba(decimal pk_Location_Id, string strClaimNumber )
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Workers_Comp_ClaimsSelectTPA_Claim_NumberByLocationDBA");

            db.AddInParameter(dbCommand, "PK_LU_Location", DbType.Decimal , pk_Location_Id);
            db.AddInParameter(dbCommand, "ClaimNumbar", DbType.String, strClaimNumber);

            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet SelectClaimantName(string strFirstName, string strLastName)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("SelectClaimantName");

            db.AddInParameter(dbCommand, "ClaimantFirstName", DbType.String, strFirstName);
            db.AddInParameter(dbCommand, "ClaimantLastName", DbType.String, strLastName);

            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet SelectAssociateName(string strAssociateName)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("SelectAssociateName");

            db.AddInParameter(dbCommand, "AssociateName", DbType.String, strAssociateName);

            return db.ExecuteDataSet(dbCommand);            
        }

        public static DataTable Select_Claim_Number(int Associated_First_Report,string ClaimType)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("FirstReport_Fetch_Claim_Number");
            db.AddInParameter(dbCommand, "Associated_First_Report", DbType.Int32, Associated_First_Report);
            db.AddInParameter(dbCommand, "ClaimType", DbType.String, ClaimType);

            return db.ExecuteDataSet(dbCommand).Tables[0];
        }


        public static DataSet WC_Allocation_Location_Report(decimal Year, decimal Month, decimal PK_LU_Location_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("WCAllocationLocationReport");

            db.AddInParameter(dbCommand, "Year", DbType.Decimal, Year);
            db.AddInParameter(dbCommand, "Month", DbType.Decimal, Month);
            db.AddInParameter(dbCommand, "PK_LU_Location_ID", DbType.Decimal, PK_LU_Location_ID);

            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet WC_Allocation_Location_Summary_Report(decimal Year)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("WCAllocationLocationSummaryReport");

            db.AddInParameter(dbCommand, "Year", DbType.Decimal, Year);

            return db.ExecuteDataSet(dbCommand);
        }

        public static void UpdateRestrictedDates(Int64 pK_Workers_Comp_Claims_ID, DateTime? DateRestrictedWorkBegan, DateTime? DateRestrictedWorkEnd)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Workers_Comp_ClaimsUpdateRestrictedDate");

            db.AddInParameter(dbCommand, "PK_Workers_Comp_Claims_ID", DbType.Int64, pK_Workers_Comp_Claims_ID);
            db.AddInParameter(dbCommand, "Date_Restricted_Work_Began", DbType.DateTime, DateRestrictedWorkBegan);
            db.AddInParameter(dbCommand, "Date_Restricted_Work_Ended ", DbType.String, DateRestrictedWorkEnd);

            db.ExecuteNonQuery(dbCommand);
        }

        public static DataSet GetSonicCauseCodeReclassification_Report(string strRegion, string strDBA, DateTime? DateofInjury_From, DateTime? DateofInjury_To, decimal? FirstReportNumber, decimal? IncidentInvestigationNumber,string strCliamNumber)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("rptWCSonicCauseCodeReclassificationReport");


            if (!string.IsNullOrEmpty(strRegion))
                db.AddInParameter(dbCommand, "Region", DbType.String, strRegion);

            if (!string.IsNullOrEmpty(strDBA))
                db.AddInParameter(dbCommand, "Location", DbType.String, strDBA);

            if (DateofInjury_From != null)
                db.AddInParameter(dbCommand, "DateofInjury_From", DbType.DateTime, DateofInjury_From);

            if (DateofInjury_To != null)
                db.AddInParameter(dbCommand, "DateofInjury_To", DbType.DateTime, DateofInjury_To);

            db.AddInParameter(dbCommand, "FirstReportNumber", DbType.Decimal, FirstReportNumber);
            db.AddInParameter(dbCommand, "IncidentInvestigationNumber", DbType.Decimal, IncidentInvestigationNumber);

            if (!string.IsNullOrEmpty(strCliamNumber))
                db.AddInParameter(dbCommand, "ClaimNumber", DbType.String, strCliamNumber);

            return db.ExecuteDataSet(dbCommand);
        }
        
        #endregion
    }
}