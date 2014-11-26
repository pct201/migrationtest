using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
    /// <summary>
    /// Summary description for AL_ClaimInfo
    /// </summary>
    public class AL_ClaimInfo
    {
        #region Fields

        private Int64 _PK_Auto_Loss_Claims_ID;
        private string _Data_Origin;
        private string _Driver_Relationship_Code;
        private string _Driver_Gender;
        private string _Driver_License_Number;
        private string _Previous_TPA_Claim_Num_Takeover;
        private decimal _Previous_TPA_Indemnity_Paid;
        private decimal _Previous_TPA_Medical_Paid;
        private decimal _Previous_TPA_Expense_Paid;
        private string _Adjustor_Code;
        private string _Claim_Description;
        private string _Accident_City_Town;
        private Int32 _Associated_First_Report;
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
        private string _Line_of_Business;
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
        private decimal _Loss_Gross_Paid;
        private decimal _Net_Loss_Paid;
        private decimal _Loss_Net_Recovered;
        private decimal _Loss_Incurred;
        private decimal _Loss_Outstanding;
        private decimal _Expense_Gross_Paid;
        private decimal _Net_Expense_Paid;
        private decimal _Expense_Net_Recovered;
        private decimal _Expense_Incurred;
        private decimal _Expense_Outstanding;
        private decimal _Loss_Gross_Subrogation;
        private decimal _Loss_Subrogation_Expense;
        private decimal _Loss_Gross_Salvage;
        private decimal _Loss_Salvage_Expense;
        private decimal _Loss_Gross_Refund;
        private decimal _Ale_Gross_Subrogation;
        private decimal _Ale_Gross_Salvage;
        private decimal _Ale_Gross_Refund;
        private decimal _Ale_Refund_Expense;
        private decimal _Legal_Expense_Incurred;
        private decimal _Legal_Expense_Paid_to_Date;
        private decimal _Recovered_Loss_Deductible_Amount;
        private decimal _Recovered_Expense_Deductible_Amount;
        private string _Claims_Made_Indicator;
        private Nullable<DateTime> _Claims_Made_Date;
        private Nullable<DateTime> _Retroactive_Date;
        private string _Catastrophe_Code;
        private string _Vehicle_Model;
        private string _VIN;
        private string _Vehicle_Year;
        private string _Vehicle_Make;
        private string _Accident_Description;
        private string _Claim_Status;
        private string _Cause_of_Injury_Code;
        private string _Driver_age;
        private string _Driver_Name;
        private Nullable<DateTime> _Driver_Date_of_Birth;
        private string _Driver_Marital_Status;
        private decimal _FK_Claim_Sub_Status;
        #endregion

        #region Properties
        /// <summary> 
        /// Gets or sets the PK_Auto_Loss_Claims_ID value.
        /// </summary> 
        public Int64 PK_Auto_Loss_Claims_ID
        {
            get { return _PK_Auto_Loss_Claims_ID; }
            set { _PK_Auto_Loss_Claims_ID = value; }
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
        /// Gets or sets the Driver_Relationship_Code value.
        /// </summary> 
        public string Driver_Relationship_Code
        {
            get { return _Driver_Relationship_Code; }
            set { _Driver_Relationship_Code = value; }
        }


        /// <summary> 
        /// Gets or sets the Driver_Gender value.
        /// </summary> 
        public string Driver_Gender
        {
            get { return _Driver_Gender; }
            set { _Driver_Gender = value; }
        }


        /// <summary> 
        /// Gets or sets the Driver_License_Number value.
        /// </summary> 
        public string Driver_License_Number
        {
            get { return _Driver_License_Number; }
            set { _Driver_License_Number = value; }
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
        /// Gets or sets the Claim_Description value.
        /// </summary> 
        public string Claim_Description
        {
            get { return _Claim_Description; }
            set { _Claim_Description = value; }
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
        /// Gets or sets the Associated_First_Report value.
        /// </summary> 
        public Int32 Associated_First_Report
        {
            get { return _Associated_First_Report; }
            set { _Associated_First_Report = value; }
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
        /// Gets or sets the Line_of_Business value.
        /// </summary> 
        public string Line_of_Business
        {
            get { return _Line_of_Business; }
            set { _Line_of_Business = value; }
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
        /// Gets or sets the Loss_Gross_Paid value.
        /// </summary> 
        public decimal Loss_Gross_Paid
        {
            get { return _Loss_Gross_Paid; }
            set { _Loss_Gross_Paid = value; }
        }


        /// <summary> 
        /// Gets or sets the Net_Loss_Paid value.
        /// </summary> 
        public decimal Net_Loss_Paid
        {
            get { return _Net_Loss_Paid; }
            set { _Net_Loss_Paid = value; }
        }


        /// <summary> 
        /// Gets or sets the Loss_Net_Recovered value.
        /// </summary> 
        public decimal Loss_Net_Recovered
        {
            get { return _Loss_Net_Recovered; }
            set { _Loss_Net_Recovered = value; }
        }


        /// <summary> 
        /// Gets or sets the Loss_Incurred value.
        /// </summary> 
        public decimal Loss_Incurred
        {
            get { return _Loss_Incurred; }
            set { _Loss_Incurred = value; }
        }


        /// <summary> 
        /// Gets or sets the Loss_Outstanding value.
        /// </summary> 
        public decimal Loss_Outstanding
        {
            get { return _Loss_Outstanding; }
            set { _Loss_Outstanding = value; }
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
        /// Gets or sets the Loss_Gross_Subrogation value.
        /// </summary> 
        public decimal Loss_Gross_Subrogation
        {
            get { return _Loss_Gross_Subrogation; }
            set { _Loss_Gross_Subrogation = value; }
        }


        /// <summary> 
        /// Gets or sets the Loss_Subrogation_Expense value.
        /// </summary> 
        public decimal Loss_Subrogation_Expense
        {
            get { return _Loss_Subrogation_Expense; }
            set { _Loss_Subrogation_Expense = value; }
        }


        /// <summary> 
        /// Gets or sets the Loss_Gross_Salvage value.
        /// </summary> 
        public decimal Loss_Gross_Salvage
        {
            get { return _Loss_Gross_Salvage; }
            set { _Loss_Gross_Salvage = value; }
        }


        /// <summary> 
        /// Gets or sets the Loss_Salvage_Expense value.
        /// </summary> 
        public decimal Loss_Salvage_Expense
        {
            get { return _Loss_Salvage_Expense; }
            set { _Loss_Salvage_Expense = value; }
        }


        /// <summary> 
        /// Gets or sets the Loss_Gross_Refund value.
        /// </summary> 
        public decimal Loss_Gross_Refund
        {
            get { return _Loss_Gross_Refund; }
            set { _Loss_Gross_Refund = value; }
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
        /// Gets or sets the Recovered_Loss_Deductible_Amount value.
        /// </summary> 
        public decimal Recovered_Loss_Deductible_Amount
        {
            get { return _Recovered_Loss_Deductible_Amount; }
            set { _Recovered_Loss_Deductible_Amount = value; }
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
        /// Gets or sets the Claims_Made_Indicator value.
        /// </summary> 
        public string Claims_Made_Indicator
        {
            get { return _Claims_Made_Indicator; }
            set { _Claims_Made_Indicator = value; }
        }


        /// <summary> 
        /// Gets or sets the Claims_Made_Date value.
        /// </summary> 
        public Nullable<DateTime> Claims_Made_Date
        {
            get { return _Claims_Made_Date; }
            set { _Claims_Made_Date = value; }
        }


        /// <summary> 
        /// Gets or sets the Retroactive_Date value.
        /// </summary> 
        public Nullable<DateTime> Retroactive_Date
        {
            get { return _Retroactive_Date; }
            set { _Retroactive_Date = value; }
        }


        /// <summary> 
        /// Gets or sets the Catastrophe_Code value.
        /// </summary> 
        public string Catastrophe_Code
        {
            get { return _Catastrophe_Code; }
            set { _Catastrophe_Code = value; }
        }


        /// <summary> 
        /// Gets or sets the Vehicle_Model value.
        /// </summary> 
        public string Vehicle_Model
        {
            get { return _Vehicle_Model; }
            set { _Vehicle_Model = value; }
        }


        /// <summary> 
        /// Gets or sets the VIN value.
        /// </summary> 
        public string VIN
        {
            get { return _VIN; }
            set { _VIN = value; }
        }


        /// <summary> 
        /// Gets or sets the Vehicle_Year value.
        /// </summary> 
        public string Vehicle_Year
        {
            get { return _Vehicle_Year; }
            set { _Vehicle_Year = value; }
        }


        /// <summary> 
        /// Gets or sets the Vehicle_Make value.
        /// </summary> 
        public string Vehicle_Make
        {
            get { return _Vehicle_Make; }
            set { _Vehicle_Make = value; }
        }


        /// <summary> 
        /// Gets or sets the Accident_Description value.
        /// </summary> 
        public string Accident_Description
        {
            get { return _Accident_Description; }
            set { _Accident_Description = value; }
        }


        /// <summary> 
        /// Gets or sets the Claim_Status value.
        /// </summary> 
        public string Claim_Status
        {
            get { return _Claim_Status; }
            set { _Claim_Status = value; }
        }


        /// <summary> 
        /// Gets or sets the Cause_of_Injury_Code value.
        /// </summary> 
        public string Cause_of_Injury_Code
        {
            get { return _Cause_of_Injury_Code; }
            set { _Cause_of_Injury_Code = value; }
        }


        /// <summary> 
        /// Gets or sets the Driver_age value.
        /// </summary> 
        public string Driver_age
        {
            get { return _Driver_age; }
            set { _Driver_age = value; }
        }


        /// <summary> 
        /// Gets or sets the Driver_Name value.
        /// </summary> 
        public string Driver_Name
        {
            get { return _Driver_Name; }
            set { _Driver_Name = value; }
        }


        /// <summary> 
        /// Gets or sets the Driver_Date_of_Birth value.
        /// </summary> 
        public Nullable<DateTime> Driver_Date_of_Birth
        {
            get { return _Driver_Date_of_Birth; }
            set { _Driver_Date_of_Birth = value; }
        }


        /// <summary> 
        /// Gets or sets the Driver_Marital_Status value.
        /// </summary> 
        public string Driver_Marital_Status
        {
            get { return _Driver_Marital_Status; }
            set { _Driver_Marital_Status = value; }
        }

        ///<summary>
        ///gets or sets FK_Claim_Sub_Status value
        /// </summary>
        public decimal FK_Claim_Sub_Status
        {
            get { return _FK_Claim_Sub_Status; }
            set { _FK_Claim_Sub_Status = value; }
        }
        #endregion

        #region Constructors

        /// <summary> 

        /// Initializes a new instance of the Auto_Loss_Claims class. with the default value.

        /// </summary>
        public AL_ClaimInfo()
        {
            this._PK_Auto_Loss_Claims_ID = 0;
            this._Data_Origin = "";
            this._Driver_Relationship_Code = "";
            this._Driver_Gender = "";
            this._Driver_License_Number = "";
            this._Previous_TPA_Claim_Num_Takeover = "";
            this._Previous_TPA_Indemnity_Paid = -1;
            this._Previous_TPA_Medical_Paid = -1;
            this._Previous_TPA_Expense_Paid = -1;
            this._Adjustor_Code = "";
            this._Claim_Description = "";
            this._Accident_City_Town = "";
            this._Associated_First_Report = 0;
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
            this._Line_of_Business = "";
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
            this._Loss_Gross_Paid = -1;
            this._Net_Loss_Paid = -1;
            this._Loss_Net_Recovered = -1;
            this._Loss_Incurred = -1;
            this._Loss_Outstanding = -1;
            this._Expense_Gross_Paid = -1;
            this._Net_Expense_Paid = -1;
            this._Expense_Net_Recovered = -1;
            this._Expense_Incurred = -1;
            this._Expense_Outstanding = -1;
            this._Loss_Gross_Subrogation = -1;
            this._Loss_Subrogation_Expense = -1;
            this._Loss_Gross_Salvage = -1;
            this._Loss_Salvage_Expense = -1;
            this._Loss_Gross_Refund = -1;
            this._Ale_Gross_Subrogation = -1;
            this._Ale_Gross_Salvage = -1;
            this._Ale_Gross_Refund = -1;
            this._Ale_Refund_Expense = -1;
            this._Legal_Expense_Incurred = -1;
            this._Legal_Expense_Paid_to_Date = -1;
            this._Recovered_Loss_Deductible_Amount = -1;
            this._Recovered_Expense_Deductible_Amount = -1;
            this._Claims_Made_Indicator = "";
            this._Claims_Made_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            this._Retroactive_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            this._Catastrophe_Code = "";
            this._Vehicle_Model = "";
            this._VIN = "";
            this._Vehicle_Year = "";
            this._Vehicle_Make = "";
            this._Accident_Description = "";
            this._Claim_Status = "";
            this._Cause_of_Injury_Code = "";
            this._Driver_age = "";
            this._Driver_Name = "";
            this._Driver_Date_of_Birth = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            this._Driver_Marital_Status = "";
            this._FK_Claim_Sub_Status = -1;
        }

        /// <summary> 
        /// Initializes a new instance of the Auto_Loss_Claims class for passed PrimaryKey with the values set from Database.
        /// </summary> 
        public AL_ClaimInfo(Int64 PK)
        {
            DataTable dtAuto_Loss_Claims = SelectByPK(PK).Tables[0];

            if (dtAuto_Loss_Claims.Rows.Count > 0)
            {
                DataRow drAuto_Loss_Claims = dtAuto_Loss_Claims.Rows[0];
                this._PK_Auto_Loss_Claims_ID = drAuto_Loss_Claims["PK_Auto_Loss_Claims_ID"] != DBNull.Value ? Convert.ToInt64(drAuto_Loss_Claims["PK_Auto_Loss_Claims_ID"]) : 0;
                this._Data_Origin = Convert.ToString(drAuto_Loss_Claims["Data_Origin"]);
                this._Driver_Relationship_Code = Convert.ToString(drAuto_Loss_Claims["Driver_Relationship_Code"]);
                this._Driver_Gender = Convert.ToString(drAuto_Loss_Claims["Driver_Gender"]);
                this._Driver_License_Number = Convert.ToString(drAuto_Loss_Claims["Driver_License_Number"]);
                this._Previous_TPA_Claim_Num_Takeover = Convert.ToString(drAuto_Loss_Claims["Previous_TPA_Claim_Num_Takeover"]);
                this._Previous_TPA_Indemnity_Paid = drAuto_Loss_Claims["Previous_TPA_Indemnity_Paid"] != DBNull.Value ? Convert.ToDecimal(drAuto_Loss_Claims["Previous_TPA_Indemnity_Paid"]) : 0;
                this._Previous_TPA_Medical_Paid = drAuto_Loss_Claims["Previous_TPA_Medical_Paid"] != DBNull.Value ? Convert.ToDecimal(drAuto_Loss_Claims["Previous_TPA_Medical_Paid"]) : 0;
                this._Previous_TPA_Expense_Paid = drAuto_Loss_Claims["Previous_TPA_Expense_Paid"] != DBNull.Value ? Convert.ToDecimal(drAuto_Loss_Claims["Previous_TPA_Expense_Paid"]) : 0;
                this._Adjustor_Code = Convert.ToString(drAuto_Loss_Claims["Adjustor_Code"]);
                this._Claim_Description = Convert.ToString(drAuto_Loss_Claims["Claim_Description"]);
                this._Accident_City_Town = Convert.ToString(drAuto_Loss_Claims["Accident_City_Town"]);
                this._Associated_First_Report = drAuto_Loss_Claims["Associated_First_Report"] != DBNull.Value ? Convert.ToInt32(drAuto_Loss_Claims["Associated_First_Report"]) : 0;
                this._Origin_Claim_Number = Convert.ToString(drAuto_Loss_Claims["Origin_Claim_Number"]);
                this._Origin_Key_Claim_Number = Convert.ToString(drAuto_Loss_Claims["Origin_Key_Claim_Number"]);
                this._Claimant_Sequence_Number = Convert.ToString(drAuto_Loss_Claims["Claimant_Sequence_Number"]);
                this._Employee_Name = Convert.ToString(drAuto_Loss_Claims["Employee_Name"]);
                this._Claimant_First_Name = Convert.ToString(drAuto_Loss_Claims["Claimant_First_Name"]);
                this._Claimant_Last_Name = Convert.ToString(drAuto_Loss_Claims["Claimant_Last_Name"]);
                this._Employee_Street = Convert.ToString(drAuto_Loss_Claims["Employee_Street"]);
                this._Employee_City = Convert.ToString(drAuto_Loss_Claims["Employee_City"]);
                this._Employee_State = Convert.ToString(drAuto_Loss_Claims["Employee_State"]);
                this._Employee_Zip = Convert.ToString(drAuto_Loss_Claims["Employee_Zip"]);
                this._Employee_Gender = Convert.ToString(drAuto_Loss_Claims["Employee_Gender"]);
                this._Employee_SSN = Convert.ToString(drAuto_Loss_Claims["Employee_SSN"]);
                this._Marital_Status = Convert.ToString(drAuto_Loss_Claims["Marital_Status"]);
                this._Employee_Date_of_Birth = drAuto_Loss_Claims["Employee_Date_of_Birth"] != DBNull.Value ? Convert.ToDateTime(drAuto_Loss_Claims["Employee_Date_of_Birth"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._State_of_Accident = Convert.ToString(drAuto_Loss_Claims["State_of_Accident"]);
                this._State_of_Jurisdiction = Convert.ToString(drAuto_Loss_Claims["State_of_Jurisdiction"]);
                this._Date_Reported_to_Insurer = drAuto_Loss_Claims["Date_Reported_to_Insurer"] != DBNull.Value ? Convert.ToDateTime(drAuto_Loss_Claims["Date_Reported_to_Insurer"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Date_of_Accident = drAuto_Loss_Claims["Date_of_Accident"] != DBNull.Value ? Convert.ToDateTime(drAuto_Loss_Claims["Date_of_Accident"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Time_of_Loss = Convert.ToString(drAuto_Loss_Claims["Time_of_Loss"]);
                this._Date_Entered = drAuto_Loss_Claims["Date_Entered"] != DBNull.Value ? Convert.ToDateTime(drAuto_Loss_Claims["Date_Entered"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Date_Closed = drAuto_Loss_Claims["Date_Closed"] != DBNull.Value ? Convert.ToDateTime(drAuto_Loss_Claims["Date_Closed"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._FK_Claim_Status = Convert.ToString(drAuto_Loss_Claims["FK_Claim_Status"]);
                this._Line_of_Business = Convert.ToString(drAuto_Loss_Claims["Line_of_Business"]);
                this._FK_Insured_Location_Code = Convert.ToString(drAuto_Loss_Claims["FK_Insured_Location_Code"]);
                this._FK_Coverage_Code = Convert.ToString(drAuto_Loss_Claims["FK_Coverage_Code"]);
                this._Date_Suit_Filed = drAuto_Loss_Claims["Date_Suit_Filed"] != DBNull.Value ? Convert.ToDateTime(drAuto_Loss_Claims["Date_Suit_Filed"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._LitigationYN = Convert.ToString(drAuto_Loss_Claims["LitigationYN"]);
                this._Suit_Result_Code = Convert.ToString(drAuto_Loss_Claims["Suit_Result_Code"]);
                this._Suit_Type_Code = Convert.ToString(drAuto_Loss_Claims["Suit_Type_Code"]);
                this._SRS_Policy_Number = Convert.ToString(drAuto_Loss_Claims["SRS_Policy_Number"]);
                this._Policy_Effective_Date = drAuto_Loss_Claims["Policy_Effective_Date"] != DBNull.Value ? Convert.ToDateTime(drAuto_Loss_Claims["Policy_Effective_Date"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Policy_Expiration_Date = drAuto_Loss_Claims["Policy_Expiration_Date"] != DBNull.Value ? Convert.ToDateTime(drAuto_Loss_Claims["Policy_Expiration_Date"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Other_Carrier_Policy_Number = Convert.ToString(drAuto_Loss_Claims["Other_Carrier_Policy_Number"]);
                this._Carrier_Effective_Date = drAuto_Loss_Claims["Carrier_Effective_Date"] != DBNull.Value ? Convert.ToDateTime(drAuto_Loss_Claims["Carrier_Effective_Date"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Carrier_Expiration_Date = drAuto_Loss_Claims["Carrier_Expiration_Date"] != DBNull.Value ? Convert.ToDateTime(drAuto_Loss_Claims["Carrier_Expiration_Date"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Plaintiff_Attorney_Code = Convert.ToString(drAuto_Loss_Claims["Plaintiff_Attorney_Code"]);
                this._Loss_Gross_Paid = drAuto_Loss_Claims["Loss_Gross_Paid"] != DBNull.Value ? Convert.ToDecimal(drAuto_Loss_Claims["Loss_Gross_Paid"]) : 0;
                this._Net_Loss_Paid = drAuto_Loss_Claims["Net_Loss_Paid"] != DBNull.Value ? Convert.ToDecimal(drAuto_Loss_Claims["Net_Loss_Paid"]) : 0;
                this._Loss_Net_Recovered = drAuto_Loss_Claims["Loss_Net_Recovered"] != DBNull.Value ? Convert.ToDecimal(drAuto_Loss_Claims["Loss_Net_Recovered"]) : 0;
                this._Loss_Incurred = drAuto_Loss_Claims["Loss_Incurred"] != DBNull.Value ? Convert.ToDecimal(drAuto_Loss_Claims["Loss_Incurred"]) : 0;
                this._Loss_Outstanding = drAuto_Loss_Claims["Loss_Outstanding"] != DBNull.Value ? Convert.ToDecimal(drAuto_Loss_Claims["Loss_Outstanding"]) : 0;
                this._Expense_Gross_Paid = drAuto_Loss_Claims["Expense_Gross_Paid"] != DBNull.Value ? Convert.ToDecimal(drAuto_Loss_Claims["Expense_Gross_Paid"]) : 0;
                this._Net_Expense_Paid = drAuto_Loss_Claims["Net_Expense_Paid"] != DBNull.Value ? Convert.ToDecimal(drAuto_Loss_Claims["Net_Expense_Paid"]) : 0;
                this._Expense_Net_Recovered = drAuto_Loss_Claims["Expense_Net_Recovered"] != DBNull.Value ? Convert.ToDecimal(drAuto_Loss_Claims["Expense_Net_Recovered"]) : 0;
                this._Expense_Incurred = drAuto_Loss_Claims["Expense_Incurred"] != DBNull.Value ? Convert.ToDecimal(drAuto_Loss_Claims["Expense_Incurred"]) : 0;
                this._Expense_Outstanding = drAuto_Loss_Claims["Expense_Outstanding"] != DBNull.Value ? Convert.ToDecimal(drAuto_Loss_Claims["Expense_Outstanding"]) : 0;
                this._Loss_Gross_Subrogation = drAuto_Loss_Claims["Loss_Gross_Subrogation"] != DBNull.Value ? Convert.ToDecimal(drAuto_Loss_Claims["Loss_Gross_Subrogation"]) : 0;
                this._Loss_Subrogation_Expense = drAuto_Loss_Claims["Loss_Subrogation_Expense"] != DBNull.Value ? Convert.ToDecimal(drAuto_Loss_Claims["Loss_Subrogation_Expense"]) : 0;
                this._Loss_Gross_Salvage = drAuto_Loss_Claims["Loss_Gross_Salvage"] != DBNull.Value ? Convert.ToDecimal(drAuto_Loss_Claims["Loss_Gross_Salvage"]) : 0;
                this._Loss_Salvage_Expense = drAuto_Loss_Claims["Loss_Salvage_Expense"] != DBNull.Value ? Convert.ToDecimal(drAuto_Loss_Claims["Loss_Salvage_Expense"]) : 0;
                this._Loss_Gross_Refund = drAuto_Loss_Claims["Loss_Gross_Refund"] != DBNull.Value ? Convert.ToDecimal(drAuto_Loss_Claims["Loss_Gross_Refund"]) : 0;
                this._Ale_Gross_Subrogation = drAuto_Loss_Claims["Ale_Gross_Subrogation"] != DBNull.Value ? Convert.ToDecimal(drAuto_Loss_Claims["Ale_Gross_Subrogation"]) : 0;
                this._Ale_Gross_Salvage = drAuto_Loss_Claims["Ale_Gross_Salvage"] != DBNull.Value ? Convert.ToDecimal(drAuto_Loss_Claims["Ale_Gross_Salvage"]) : 0;
                this._Ale_Gross_Refund = drAuto_Loss_Claims["Ale_Gross_Refund"] != DBNull.Value ? Convert.ToDecimal(drAuto_Loss_Claims["Ale_Gross_Refund"]) : 0;
                this._Ale_Refund_Expense = drAuto_Loss_Claims["Ale_Refund_Expense"] != DBNull.Value ? Convert.ToDecimal(drAuto_Loss_Claims["Ale_Refund_Expense"]) : 0;
                this._Legal_Expense_Incurred = drAuto_Loss_Claims["Legal_Expense_Incurred"] != DBNull.Value ? Convert.ToDecimal(drAuto_Loss_Claims["Legal_Expense_Incurred"]) : 0;
                this._Legal_Expense_Paid_to_Date = drAuto_Loss_Claims["Legal_Expense_Paid_to_Date"] != DBNull.Value ? Convert.ToDecimal(drAuto_Loss_Claims["Legal_Expense_Paid_to_Date"]) : 0;
                this._Recovered_Loss_Deductible_Amount = drAuto_Loss_Claims["Recovered_Loss_Deductible_Amount"] != DBNull.Value ? Convert.ToDecimal(drAuto_Loss_Claims["Recovered_Loss_Deductible_Amount"]) : 0;
                this._Recovered_Expense_Deductible_Amount = drAuto_Loss_Claims["Recovered_Expense_Deductible_Amount"] != DBNull.Value ? Convert.ToDecimal(drAuto_Loss_Claims["Recovered_Expense_Deductible_Amount"]) : 0;
                this._Claims_Made_Indicator = Convert.ToString(drAuto_Loss_Claims["Claims_Made_Indicator"]);
                this._Claims_Made_Date = drAuto_Loss_Claims["Claims_Made_Date"] != DBNull.Value ? Convert.ToDateTime(drAuto_Loss_Claims["Claims_Made_Date"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Retroactive_Date = drAuto_Loss_Claims["Retroactive_Date"] != DBNull.Value ? Convert.ToDateTime(drAuto_Loss_Claims["Retroactive_Date"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Catastrophe_Code = Convert.ToString(drAuto_Loss_Claims["Catastrophe_Code"]);
                this._Vehicle_Model = Convert.ToString(drAuto_Loss_Claims["Vehicle_Model"]);
                this._VIN = Convert.ToString(drAuto_Loss_Claims["VIN"]);
                this._Vehicle_Year = Convert.ToString(drAuto_Loss_Claims["Vehicle_Year"]);
                this._Vehicle_Make = Convert.ToString(drAuto_Loss_Claims["Vehicle_Make"]);
                this._Accident_Description = Convert.ToString(drAuto_Loss_Claims["Accident_Description"]);
                this._Claim_Status = Convert.ToString(drAuto_Loss_Claims["Claim_Status"]);
                this._Cause_of_Injury_Code = Convert.ToString(drAuto_Loss_Claims["Cause_of_Injury_Code"]);
                this._Driver_age = Convert.ToString(drAuto_Loss_Claims["Driver_age"]);
                this._Driver_Name = Convert.ToString(drAuto_Loss_Claims["Driver_Name"]);
                this._Driver_Date_of_Birth = drAuto_Loss_Claims["Driver_Date_of_Birth"] != DBNull.Value ? Convert.ToDateTime(drAuto_Loss_Claims["Driver_Date_of_Birth"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Driver_Marital_Status = Convert.ToString(drAuto_Loss_Claims["Driver_Marital_Status"]);
                this._FK_Claim_Sub_Status = drAuto_Loss_Claims["FK_Claim_Sub_Status"] != DBNull.Value ? Convert.ToDecimal(drAuto_Loss_Claims["FK_Claim_Sub_Status"]) : 0;
            }
            else
            {
                this._PK_Auto_Loss_Claims_ID = 0;
                this._Data_Origin = "";
                this._Driver_Relationship_Code = "";
                this._Driver_Gender = "";
                this._Driver_License_Number = "";
                this._Previous_TPA_Claim_Num_Takeover = "";
                this._Previous_TPA_Indemnity_Paid = -1;
                this._Previous_TPA_Medical_Paid = -1;
                this._Previous_TPA_Expense_Paid = -1;
                this._Adjustor_Code = "";
                this._Claim_Description = "";
                this._Accident_City_Town = "";
                this._Associated_First_Report = 0;
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
                this._Line_of_Business = "";
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
                this._Loss_Gross_Paid = -1;
                this._Net_Loss_Paid = -1;
                this._Loss_Net_Recovered = -1;
                this._Loss_Incurred = -1;
                this._Loss_Outstanding = -1;
                this._Expense_Gross_Paid = -1;
                this._Net_Expense_Paid = -1;
                this._Expense_Net_Recovered = -1;
                this._Expense_Incurred = -1;
                this._Expense_Outstanding = -1;
                this._Loss_Gross_Subrogation = -1;
                this._Loss_Subrogation_Expense = -1;
                this._Loss_Gross_Salvage = -1;
                this._Loss_Salvage_Expense = -1;
                this._Loss_Gross_Refund = -1;
                this._Ale_Gross_Subrogation = -1;
                this._Ale_Gross_Salvage = -1;
                this._Ale_Gross_Refund = -1;
                this._Ale_Refund_Expense = -1;
                this._Legal_Expense_Incurred = -1;
                this._Legal_Expense_Paid_to_Date = -1;
                this._Recovered_Loss_Deductible_Amount = -1;
                this._Recovered_Expense_Deductible_Amount = -1;
                this._Claims_Made_Indicator = "";
                this._Claims_Made_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Retroactive_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Catastrophe_Code = "";
                this._Vehicle_Model = "";
                this._VIN = "";
                this._Vehicle_Year = "";
                this._Vehicle_Make = "";
                this._Accident_Description = "";
                this._Claim_Status = "";
                this._Cause_of_Injury_Code = "";
                this._Driver_age = "";
                this._Driver_Name = "";
                this._Driver_Date_of_Birth = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Driver_Marital_Status = "";
                this._FK_Claim_Sub_Status = -1;
            }

        }

        #endregion

        #region Method

        /// <summary>
        /// Selects a single record from the Workers_Comp_Claims table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectByPK(Int64 pK_Auto_Loss_Claims_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Auto_Loss_ClaimsSelectByPK");

            db.AddInParameter(dbCommand, "PK_Auto_Loss_Claims_ID", DbType.Int64, pK_Auto_Loss_Claims_ID);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects a ALL claiment name from auto_loss_claims and premises_loss_claims
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet GetClaimant()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Claim_SelectClaimant");

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Filter Employee and claiment name by location
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet FilterEmployeeClientNamebyLocationNumber(Decimal pK_location)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("FilterEmployeeClientNamebyLocationNumber");
            db.AddInParameter(dbCommand, "LocationNumber", DbType.Decimal, pK_location);

            return db.ExecuteDataSet(dbCommand);
        }
        #endregion
    }
}