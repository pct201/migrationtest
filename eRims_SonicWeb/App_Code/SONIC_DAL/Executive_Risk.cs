using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
    /// <summary>
    /// Data access class for Executive_Risk table.
    /// </summary>
    public sealed class Executive_Risk
    {
        #region Fields


        private decimal _PK_Executive_Risk;
        private string _Claim_Type_Other;
        private decimal _FK_Type_Of_ER_Allegation;
        private string _Legal_File_Number;
        private string _Claim_Number;
        private decimal _FK_Entity;
        private decimal _FK_Type_Of_ER_Claim;
        private string _Complainant_Plaintiff;
        private string _Defendant;
        private string _Claim_Description;
        private DateTime _Claim_Open_Date;
        private DateTime _Claim_Close_Date;
        private DateTime _Claim_Reopen_Date;
        private string _Bordereau_Report;
        private string _Claim_Status_Comments;
        private string _EEOC;
        private string _State_Employment_Commission;
        private string _Representation_Letter_Received;
        private DateTime _Date_Representation_Letter_Received;
        private string _Security_Litigation;
        private string _Other_Litigation;
        private string _Jurisdiction;
        private DateTime _Date_Complaint_Suit_Filed;
        private DateTime _Date_Suite_Served;
        private string _Case_Number;
        private string _Primary_Insurance_Claim_Number;
        private string _Primary_Insurance_Policy_Number;
        private DateTime _Primary_Policy_Effective_Date;
        private DateTime _Primary_Policy_Expiration_Date;
        private decimal _Total_Program_Limit;
        private decimal _Primary_Deductable;
        private decimal _Allocation;
        private DateTime _Date_Alleged_Wrongful_Act;
        private DateTime _Date_Complaint_Received;
        private DateTime _Date_Legal_Received_Complaint;
        private DateTime _Date_Risk_Management_Received_Complaint;
        private DateTime _Date_Broker_Received_Complaint;
        private DateTime _Date_Carrier_Notified;
        private DateTime _Date_Acknowledgement_Primary_Carrier;
        private string _Internal_Counsel;
        private string _Legal_Telephone;
        private string _Panel_Counsel_Required;
        private string _Primary_Defense_File_Number;
        private string _Secondary_Defense_File_Number;
        private string _Court;
        private string _Judge_Arbitrator;
        private string _Legal_Status;
        private decimal _Estimated_Demand_Exposure;
        private DateTime _Demand_Exposure_Date;
        private decimal _Estimated_Defense_Expense;
        private DateTime _Estimated_Defense_Expense_Date;
        private decimal _Actual_Settlement;
        private DateTime _Actual_Settlement_Date;
        private decimal _Actual_Defense_Expense;
        private DateTime _Actual_Defense_Expense_Date;
        private string _Comments;
        private string _Updated_By;
        private DateTime _Update_Date;
        private string _Legal_Complaint_Recipient;
        private DateTime _Date_HR_Received_Compliant;
        private string _HR_Complaint_Recipient;
        #endregion


        #region Properties


        /// <summary> 
        /// Gets or sets the PK_Executive_Risk value.
        /// </summary>
        public decimal PK_Executive_Risk
        {
            get { return _PK_Executive_Risk; }
            set { _PK_Executive_Risk = value; }
        }

        /// <summary> 
        /// Gets or sets the Claim_Type_Other value.
        /// </summary>
        public string Claim_Type_Other
        {
            get { return _Claim_Type_Other; }
            set { _Claim_Type_Other = value; }
        }

        /// <summary> 
        /// Gets or sets the FK_Type_Of_ER_Allegation value.
        /// </summary>
        public decimal FK_Type_Of_ER_Allegation
        {
            get { return _FK_Type_Of_ER_Allegation; }
            set { _FK_Type_Of_ER_Allegation = value; }
        }

        /// <summary> 
        /// Gets or sets the Legal_File_Number value.
        /// </summary>
        public string Legal_File_Number
        {
            get { return _Legal_File_Number; }
            set { _Legal_File_Number = value; }
        }

        /// <summary> 
        /// Gets or sets the Claim_Number value.
        /// </summary>
        public string Claim_Number
        {
            get { return _Claim_Number; }
            set { _Claim_Number = value; }
        }


        /// <summary> 
        /// Gets or sets the FK_Entity value.
        /// </summary>
        public decimal FK_Entity
        {
            get { return _FK_Entity; }
            set { _FK_Entity = value; }
        }


        /// <summary> 
        /// Gets or sets the FK_Type_Of_ER_Claim value.
        /// </summary>
        public decimal FK_Type_Of_ER_Claim
        {
            get { return _FK_Type_Of_ER_Claim; }
            set { _FK_Type_Of_ER_Claim = value; }
        }


        /// <summary> 
        /// Gets or sets the Complainant_Plaintiff value.
        /// </summary>
        public string Complainant_Plaintiff
        {
            get { return _Complainant_Plaintiff; }
            set { _Complainant_Plaintiff = value; }
        }


        /// <summary> 
        /// Gets or sets the Defendant value.
        /// </summary>
        public string Defendant
        {
            get { return _Defendant; }
            set { _Defendant = value; }
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
        /// Gets or sets the Claim_Open_Date value.
        /// </summary>
        public DateTime Claim_Open_Date
        {
            get { return _Claim_Open_Date; }
            set { _Claim_Open_Date = value; }
        }


        /// <summary> 
        /// Gets or sets the Claim_Close_Date value.
        /// </summary>
        public DateTime Claim_Close_Date
        {
            get { return _Claim_Close_Date; }
            set { _Claim_Close_Date = value; }
        }


        /// <summary> 
        /// Gets or sets the Claim_Reopen_Date value.
        /// </summary>
        public DateTime Claim_Reopen_Date
        {
            get { return _Claim_Reopen_Date; }
            set { _Claim_Reopen_Date = value; }
        }


        /// <summary> 
        /// Gets or sets the Bordereau_Report value.
        /// </summary>
        public string Bordereau_Report
        {
            get { return _Bordereau_Report; }
            set { _Bordereau_Report = value; }
        }


        /// <summary> 
        /// Gets or sets the Claim_Status_Comments value.
        /// </summary>
        public string Claim_Status_Comments
        {
            get { return _Claim_Status_Comments; }
            set { _Claim_Status_Comments = value; }
        }


        /// <summary> 
        /// Gets or sets the EEOC value.
        /// </summary>
        public string EEOC
        {
            get { return _EEOC; }
            set { _EEOC = value; }
        }


        /// <summary> 
        /// Gets or sets the State_Employment_Commission value.
        /// </summary>
        public string State_Employment_Commission
        {
            get { return _State_Employment_Commission; }
            set { _State_Employment_Commission = value; }
        }


        /// <summary> 
        /// Gets or sets the Representation_Letter_Received value.
        /// </summary>
        public string Representation_Letter_Received
        {
            get { return _Representation_Letter_Received; }
            set { _Representation_Letter_Received = value; }
        }


        /// <summary> 
        /// Gets or sets the Date_Representation_Letter_Received value.
        /// </summary>
        public DateTime Date_Representation_Letter_Received
        {
            get { return _Date_Representation_Letter_Received; }
            set { _Date_Representation_Letter_Received = value; }
        }
        /// <summary> 
        /// Gets or sets the Security_Litigation value.
        /// </summary>
        public string Security_Litigation
        {
            get { return _Security_Litigation; }
            set { _Security_Litigation = value; }
        }


        /// <summary> 
        /// Gets or sets the Other_Litigation value.
        /// </summary>
        public string Other_Litigation
        {
            get { return _Other_Litigation; }
            set { _Other_Litigation = value; }
        }


        /// <summary> 
        /// Gets or sets the Jurisdiction value.
        /// </summary>
        public string Jurisdiction
        {
            get { return _Jurisdiction; }
            set { _Jurisdiction = value; }
        }


        /// <summary> 
        /// Gets or sets the Date_Complaint_Suit_Filed value.
        /// </summary>
        public DateTime Date_Complaint_Suit_Filed
        {
            get { return _Date_Complaint_Suit_Filed; }
            set { _Date_Complaint_Suit_Filed = value; }
        }


        /// <summary> 
        /// Gets or sets the Date_Suite_Served value.
        /// </summary>
        public DateTime Date_Suite_Served
        {
            get { return _Date_Suite_Served; }
            set { _Date_Suite_Served = value; }
        }


        /// <summary> 
        /// Gets or sets the Case_Number value.
        /// </summary>
        public string Case_Number
        {
            get { return _Case_Number; }
            set { _Case_Number = value; }
        }


        /// <summary> 
        /// Gets or sets the Primary_Insurance_Claim_Number value.
        /// </summary>
        public string Primary_Insurance_Claim_Number
        {
            get { return _Primary_Insurance_Claim_Number; }
            set { _Primary_Insurance_Claim_Number = value; }
        }


        /// <summary> 
        /// Gets or sets the Primary_Insurance_Policy_Number value.
        /// </summary>
        public string Primary_Insurance_Policy_Number
        {
            get { return _Primary_Insurance_Policy_Number; }
            set { _Primary_Insurance_Policy_Number = value; }
        }


        /// <summary> 
        /// Gets or sets the Primary_Policy_Effective_Date value.
        /// </summary>
        public DateTime Primary_Policy_Effective_Date
        {
            get { return _Primary_Policy_Effective_Date; }
            set { _Primary_Policy_Effective_Date = value; }
        }


        /// <summary> 
        /// Gets or sets the Primary_Policy_Expiration_Date value.
        /// </summary>
        public DateTime Primary_Policy_Expiration_Date
        {
            get { return _Primary_Policy_Expiration_Date; }
            set { _Primary_Policy_Expiration_Date = value; }
        }


        /// <summary> 
        /// Gets or sets the Total_Program_Limit value.
        /// </summary>
        public decimal Total_Program_Limit
        {
            get { return _Total_Program_Limit; }
            set { _Total_Program_Limit = value; }
        }


        /// <summary> 
        /// Gets or sets the Primary_Deductable value.
        /// </summary>
        public decimal Primary_Deductable
        {
            get { return _Primary_Deductable; }
            set { _Primary_Deductable = value; }
        }


        /// <summary> 
        /// Gets or sets the Allocation value.
        /// </summary>
        public decimal Allocation
        {
            get { return _Allocation; }
            set { _Allocation = value; }
        }


        /// <summary> 
        /// Gets or sets the Date_Alleged_Wrongful_Act value.
        /// </summary>
        public DateTime Date_Alleged_Wrongful_Act
        {
            get { return _Date_Alleged_Wrongful_Act; }
            set { _Date_Alleged_Wrongful_Act = value; }
        }


        /// <summary> 
        /// Gets or sets the Date_Complaint_Received value.
        /// </summary>
        public DateTime Date_Complaint_Received
        {
            get { return _Date_Complaint_Received; }
            set { _Date_Complaint_Received = value; }
        }


        /// <summary> 
        /// Gets or sets the Date_Legal_Received_Complaint value.
        /// </summary>
        public DateTime Date_Legal_Received_Complaint
        {
            get { return _Date_Legal_Received_Complaint; }
            set { _Date_Legal_Received_Complaint = value; }
        }


        /// <summary> 
        /// Gets or sets the Date_Risk_Management_Received_Complaint value.
        /// </summary>
        public DateTime Date_Risk_Management_Received_Complaint
        {
            get { return _Date_Risk_Management_Received_Complaint; }
            set { _Date_Risk_Management_Received_Complaint = value; }
        }
        /// <summary> 
        /// Gets or sets the Date_Broker_Received_Complaint value.
        /// </summary>
        public DateTime Date_Broker_Received_Complaint
        {
            get { return _Date_Broker_Received_Complaint; }
            set { _Date_Broker_Received_Complaint = value; }
        }


        /// <summary> 
        /// Gets or sets the Date_Carrier_Notified value.
        /// </summary>
        public DateTime Date_Carrier_Notified
        {
            get { return _Date_Carrier_Notified; }
            set { _Date_Carrier_Notified = value; }
        }


        /// <summary> 
        /// Gets or sets the Date_Acknowledgement_Primary_Carrier value.
        /// </summary>
        public DateTime Date_Acknowledgement_Primary_Carrier
        {
            get { return _Date_Acknowledgement_Primary_Carrier; }
            set { _Date_Acknowledgement_Primary_Carrier = value; }
        }
        /// <summary> 
        /// Gets or sets the Internal_Counsel value.
        /// </summary>
        public string Internal_Counsel
        {
            get { return _Internal_Counsel; }
            set { _Internal_Counsel = value; }
        }


        /// <summary> 
        /// Gets or sets the Legal_Telephone value.
        /// </summary>
        public string Legal_Telephone
        {
            get { return _Legal_Telephone; }
            set { _Legal_Telephone = value; }
        }


        /// <summary> 
        /// Gets or sets the Panel_Counsel_Required value.
        /// </summary>
        public string Panel_Counsel_Required
        {
            get { return _Panel_Counsel_Required; }
            set { _Panel_Counsel_Required = value; }
        }


        /// <summary> 
        /// Gets or sets the Primary_Defense_File_Number value.
        /// </summary>
        public string Primary_Defense_File_Number
        {
            get { return _Primary_Defense_File_Number; }
            set { _Primary_Defense_File_Number = value; }
        }


        /// <summary> 
        /// Gets or sets the Secondary_Defense_File_Number value.
        /// </summary>
        public string Secondary_Defense_File_Number
        {
            get { return _Secondary_Defense_File_Number; }
            set { _Secondary_Defense_File_Number = value; }
        }


        /// <summary> 
        /// Gets or sets the Court value.
        /// </summary>
        public string Court
        {
            get { return _Court; }
            set { _Court = value; }
        }


        /// <summary> 
        /// Gets or sets the Judge_Arbitrator value.
        /// </summary>
        public string Judge_Arbitrator
        {
            get { return _Judge_Arbitrator; }
            set { _Judge_Arbitrator = value; }
        }


        /// <summary> 
        /// Gets or sets the Legal_Status value.
        /// </summary>
        public string Legal_Status
        {
            get { return _Legal_Status; }
            set { _Legal_Status = value; }
        }


        /// <summary> 
        /// Gets or sets the Estimated_Demand_Exposure value.
        /// </summary>
        public decimal Estimated_Demand_Exposure
        {
            get { return _Estimated_Demand_Exposure; }
            set { _Estimated_Demand_Exposure = value; }
        }


        /// <summary> 
        /// Gets or sets the Demand_Exposure_Date value.
        /// </summary>
        public DateTime Demand_Exposure_Date
        {
            get { return _Demand_Exposure_Date; }
            set { _Demand_Exposure_Date = value; }
        }


        /// <summary> 
        /// Gets or sets the Estimated_Defense_Expense value.
        /// </summary>
        public decimal Estimated_Defense_Expense
        {
            get { return _Estimated_Defense_Expense; }
            set { _Estimated_Defense_Expense = value; }
        }


        /// <summary> 
        /// Gets or sets the Estimated_Defense_Expense_Date value.
        /// </summary>
        public DateTime Estimated_Defense_Expense_Date
        {
            get { return _Estimated_Defense_Expense_Date; }
            set { _Estimated_Defense_Expense_Date = value; }
        }


        /// <summary> 
        /// Gets or sets the Actual_Settlement value.
        /// </summary>
        public decimal Actual_Settlement
        {
            get { return _Actual_Settlement; }
            set { _Actual_Settlement = value; }
        }


        /// <summary> 
        /// Gets or sets the Actual_Settlement_Date value.
        /// </summary>
        public DateTime Actual_Settlement_Date
        {
            get { return _Actual_Settlement_Date; }
            set { _Actual_Settlement_Date = value; }
        }


        /// <summary> 
        /// Gets or sets the Actual_Defense_Expense value.
        /// </summary>
        public decimal Actual_Defense_Expense
        {
            get { return _Actual_Defense_Expense; }
            set { _Actual_Defense_Expense = value; }
        }


        /// <summary> 
        /// Gets or sets the Actual_Defense_Expense_Date value.
        /// </summary>
        public DateTime Actual_Defense_Expense_Date
        {
            get { return _Actual_Defense_Expense_Date; }
            set { _Actual_Defense_Expense_Date = value; }
        }


        /// <summary> 
        /// Gets or sets the Comments value.
        /// </summary>
        public string Comments
        {
            get { return _Comments; }
            set { _Comments = value; }
        }


        /// <summary> 
        /// Gets or sets the Updated_By value.
        /// </summary>
        public string Updated_By
        {
            get { return _Updated_By; }
            set { _Updated_By = value; }
        }


        /// <summary> 
        /// Gets or sets the Update_Date value.
        /// </summary>
        public DateTime Update_Date
        {
            get { return _Update_Date; }
            set { _Update_Date = value; }
        }

        public string Legal_Complaint_Recipient
        {
            get { return _Legal_Complaint_Recipient; }
            set { _Legal_Complaint_Recipient = value; }
        }

        public DateTime Date_HR_Received_Compliant
        {
            get { return _Date_HR_Received_Compliant; }
            set { _Date_HR_Received_Compliant = value; }
        }

        public string HR_Complaint_Recipient
        {
            get { return _HR_Complaint_Recipient; }
            set { _HR_Complaint_Recipient = value; }
        }

        #endregion


        #region Constructors

        /// <summary> 
        /// Initializes a new instance of the Executive_Risk class. with the default value.
        /// </summary>
        public Executive_Risk()
        {
            this._Actual_Defense_Expense = -1;
            this._Actual_Defense_Expense_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            this._Actual_Settlement = -1;
            this._Actual_Settlement_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            this._Allocation = -1;
            this._Bordereau_Report = "";
            this._Case_Number = "";
            this._Claim_Close_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            this._Claim_Description = "";
            this._Claim_Number = "";
            this._Claim_Open_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            this._Claim_Reopen_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            this._Claim_Status_Comments = "";
            this._Claim_Type_Other = "";
            this._Comments = "";
            this._Complainant_Plaintiff = "";
            this._Court = "";
            this._Date_Acknowledgement_Primary_Carrier = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            this._Date_Alleged_Wrongful_Act = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            this._Date_Broker_Received_Complaint = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            this._Date_Carrier_Notified = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            this._Date_Complaint_Received = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            this._Date_Complaint_Suit_Filed = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            this._Date_Legal_Received_Complaint = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            this._Date_Representation_Letter_Received = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            this._Date_Risk_Management_Received_Complaint = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            this._Date_Suite_Served = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            this._Defendant = "";
            this._Demand_Exposure_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            this._EEOC = "";
            this._Estimated_Defense_Expense = -1;
            this._Estimated_Defense_Expense_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            this._Estimated_Demand_Exposure = -1;
            this._FK_Entity = -1;
            this._FK_Type_Of_ER_Allegation = -1;
            this._FK_Type_Of_ER_Claim = -1;
            this._Internal_Counsel = "";
            this._Judge_Arbitrator = "";
            this._Jurisdiction = "";
            this._Legal_File_Number = "";
            this._Legal_Status = "";
            this._Legal_Telephone = "";
            this._Other_Litigation = "";
            this._Panel_Counsel_Required = "";
            this._PK_Executive_Risk = -1;
            this._Primary_Deductable = -1;
            this._Primary_Defense_File_Number = "";
            this._Primary_Insurance_Claim_Number = "";
            this._Primary_Insurance_Policy_Number = "";
            this._Primary_Policy_Effective_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            this._Primary_Policy_Expiration_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            this._Representation_Letter_Received = "";
            this._Secondary_Defense_File_Number = "";
            this._Security_Litigation = "";
            this._State_Employment_Commission = "";
            this._Total_Program_Limit = -1;
            this._Update_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            this._Updated_By = "";
            this._Legal_Complaint_Recipient = "";
            this._Date_HR_Received_Compliant = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            this._HR_Complaint_Recipient = "";
        }



        /// <summary> 
        /// Initializes a new instance of the Executive_Risk class for passed PrimaryKey with the values set from Database.
        /// </summary>
        public Executive_Risk(decimal PK)
        {

            DataTable dtExecutive_Risk = SelectByPK(PK).Tables[0];

            if (dtExecutive_Risk.Rows.Count > 0)
            {

                DataRow drExecutive_Risk = dtExecutive_Risk.Rows[0];

                this._Actual_Defense_Expense = drExecutive_Risk["Actual_Defense_Expense"] != DBNull.Value ? Convert.ToDecimal(drExecutive_Risk["Actual_Defense_Expense"]) : 0;
                this._Actual_Defense_Expense_Date = drExecutive_Risk["Actual_Defense_Expense_Date"] != DBNull.Value ? Convert.ToDateTime(drExecutive_Risk["Actual_Defense_Expense_Date"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Actual_Settlement = drExecutive_Risk["Actual_Settlement"] != DBNull.Value ? Convert.ToDecimal(drExecutive_Risk["Actual_Settlement"]) : 0;
                this._Actual_Settlement_Date = drExecutive_Risk["Actual_Settlement_Date"] != DBNull.Value ? Convert.ToDateTime(drExecutive_Risk["Actual_Settlement_Date"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Allocation = drExecutive_Risk["Allocation"] != DBNull.Value ? Convert.ToDecimal(drExecutive_Risk["Allocation"]) : 0;
                this._Bordereau_Report = Convert.ToString(drExecutive_Risk["Bordereau_Report"]);
                this._Case_Number = Convert.ToString(drExecutive_Risk["Case_Number"]);
                this._Claim_Close_Date = drExecutive_Risk["Claim_Close_Date"] != DBNull.Value ? Convert.ToDateTime(drExecutive_Risk["Claim_Close_Date"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Claim_Description = Convert.ToString(drExecutive_Risk["Claim_Description"]);
                this._Claim_Number = Convert.ToString(drExecutive_Risk["Claim_Number"]);
                this._Claim_Open_Date = drExecutive_Risk["Claim_Open_Date"] != DBNull.Value ? Convert.ToDateTime(drExecutive_Risk["Claim_Open_Date"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Claim_Reopen_Date = drExecutive_Risk["Claim_Reopen_Date"] != DBNull.Value ? Convert.ToDateTime(drExecutive_Risk["Claim_Reopen_Date"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Claim_Status_Comments = Convert.ToString(drExecutive_Risk["Claim_Status_Comments"]);
                this._Claim_Type_Other = Convert.ToString(drExecutive_Risk["Claim_Type_Other"]);
                this._Comments = Convert.ToString(drExecutive_Risk["Comments"]);
                this._Complainant_Plaintiff = Convert.ToString(drExecutive_Risk["Complainant_Plaintiff"]);
                this._Court = Convert.ToString(drExecutive_Risk["Court"]);
                this._Date_Acknowledgement_Primary_Carrier = drExecutive_Risk["Date_Acknowledgement_Primary_Carrier"] != DBNull.Value ? Convert.ToDateTime(drExecutive_Risk["Date_Acknowledgement_Primary_Carrier"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Date_Alleged_Wrongful_Act = drExecutive_Risk["Date_Alleged_Wrongful_Act"] != DBNull.Value ? Convert.ToDateTime(drExecutive_Risk["Date_Alleged_Wrongful_Act"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Date_Broker_Received_Complaint = drExecutive_Risk["Date_Broker_Received_Complaint"] != DBNull.Value ? Convert.ToDateTime(drExecutive_Risk["Date_Broker_Received_Complaint"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Date_Carrier_Notified = drExecutive_Risk["Date_Carrier_Notified"] != DBNull.Value ? Convert.ToDateTime(drExecutive_Risk["Date_Carrier_Notified"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Date_Complaint_Received = drExecutive_Risk["Date_Complaint_Received"] != DBNull.Value ? Convert.ToDateTime(drExecutive_Risk["Date_Complaint_Received"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Date_Complaint_Suit_Filed = drExecutive_Risk["Date_Complaint_Suit_Filed"] != DBNull.Value ? Convert.ToDateTime(drExecutive_Risk["Date_Complaint_Suit_Filed"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Date_Legal_Received_Complaint = drExecutive_Risk["Date_Legal_Received_Complaint"] != DBNull.Value ? Convert.ToDateTime(drExecutive_Risk["Date_Legal_Received_Complaint"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Date_Representation_Letter_Received = drExecutive_Risk["Date_Representation_Letter_Received"] != DBNull.Value ? Convert.ToDateTime(drExecutive_Risk["Date_Representation_Letter_Received"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Date_Risk_Management_Received_Complaint = drExecutive_Risk["Date_Risk_Management_Received_Complaint"] != DBNull.Value ? Convert.ToDateTime(drExecutive_Risk["Date_Risk_Management_Received_Complaint"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Date_Suite_Served = drExecutive_Risk["Date_Suite_Served"] != DBNull.Value ? Convert.ToDateTime(drExecutive_Risk["Date_Suite_Served"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Defendant = Convert.ToString(drExecutive_Risk["Defendant"]);
                this._Demand_Exposure_Date = drExecutive_Risk["Demand_Exposure_Date"] != DBNull.Value ? Convert.ToDateTime(drExecutive_Risk["Demand_Exposure_Date"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._EEOC = Convert.ToString(drExecutive_Risk["EEOC"]);
                this._Estimated_Defense_Expense = drExecutive_Risk["Estimated_Defense_Expense"] != DBNull.Value ? Convert.ToDecimal(drExecutive_Risk["Estimated_Defense_Expense"]) : 0;
                this._Estimated_Defense_Expense_Date = drExecutive_Risk["Estimated_Defense_Expense_Date"] != DBNull.Value ? Convert.ToDateTime(drExecutive_Risk["Estimated_Defense_Expense_Date"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Estimated_Demand_Exposure = drExecutive_Risk["Estimated_Demand_Exposure"] != DBNull.Value ? Convert.ToDecimal(drExecutive_Risk["Estimated_Demand_Exposure"]) : 0;
                this._FK_Entity = drExecutive_Risk["FK_Entity"] != DBNull.Value ? Convert.ToDecimal(drExecutive_Risk["FK_Entity"]) : 0;
                this._FK_Type_Of_ER_Allegation = drExecutive_Risk["FK_Type_Of_ER_Allegation"] != DBNull.Value ? Convert.ToDecimal(drExecutive_Risk["FK_Type_Of_ER_Allegation"]) : 0;
                this._FK_Type_Of_ER_Claim = drExecutive_Risk["FK_Type_Of_ER_Claim"] != DBNull.Value ? Convert.ToDecimal(drExecutive_Risk["FK_Type_Of_ER_Claim"]) : 0;
                this._Internal_Counsel = Convert.ToString(drExecutive_Risk["Internal_Counsel"]);
                this._Judge_Arbitrator = Convert.ToString(drExecutive_Risk["Judge_Arbitrator"]);
                this._Jurisdiction = Convert.ToString(drExecutive_Risk["Jurisdiction"]);
                this._Legal_File_Number = Convert.ToString(drExecutive_Risk["Legal_File_Number"]);
                this._Legal_Status = Convert.ToString(drExecutive_Risk["Legal_Status"]);
                this._Legal_Telephone = Convert.ToString(drExecutive_Risk["Legal_Telephone"]);
                this._Other_Litigation = Convert.ToString(drExecutive_Risk["Other_Litigation"]);
                this._Panel_Counsel_Required = Convert.ToString(drExecutive_Risk["Panel_Counsel_Required"]);
                this._PK_Executive_Risk = drExecutive_Risk["PK_Executive_Risk"] != DBNull.Value ? Convert.ToDecimal(drExecutive_Risk["PK_Executive_Risk"]) : 0;
                this._Primary_Deductable = drExecutive_Risk["Primary_Deductable"] != DBNull.Value ? Convert.ToDecimal(drExecutive_Risk["Primary_Deductable"]) : 0;
                this._Primary_Defense_File_Number = Convert.ToString(drExecutive_Risk["Primary_Defense_File_Number"]);
                this._Primary_Insurance_Claim_Number = Convert.ToString(drExecutive_Risk["Primary_Insurance_Claim_Number"]);
                this._Primary_Insurance_Policy_Number = Convert.ToString(drExecutive_Risk["Primary_Insurance_Policy_Number"]);
                this._Primary_Policy_Effective_Date = drExecutive_Risk["Primary_Policy_Effective_Date"] != DBNull.Value ? Convert.ToDateTime(drExecutive_Risk["Primary_Policy_Effective_Date"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Primary_Policy_Expiration_Date = drExecutive_Risk["Primary_Policy_Expiration_Date"] != DBNull.Value ? Convert.ToDateTime(drExecutive_Risk["Primary_Policy_Expiration_Date"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Representation_Letter_Received = Convert.ToString(drExecutive_Risk["Representation_Letter_Received"]);
                this._Secondary_Defense_File_Number = Convert.ToString(drExecutive_Risk["Secondary_Defense_File_Number"]);
                this._Security_Litigation = Convert.ToString(drExecutive_Risk["Security_Litigation"]);
                this._State_Employment_Commission = Convert.ToString(drExecutive_Risk["State_Employment_Commission"]);
                this._Total_Program_Limit = drExecutive_Risk["Total_Program_Limit"] != DBNull.Value ? Convert.ToDecimal(drExecutive_Risk["Total_Program_Limit"]) : 0;
                this._Update_Date = drExecutive_Risk["Update_Date"] != DBNull.Value ? Convert.ToDateTime(drExecutive_Risk["Update_Date"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Updated_By = Convert.ToString(drExecutive_Risk["Updated_By"]);
                this._Legal_Complaint_Recipient = Convert.ToString(drExecutive_Risk["Legal_Complaint_Recipient"]);
                this._Date_HR_Received_Compliant = drExecutive_Risk["Date_HR_Received_Compliant"] != DBNull.Value ? Convert.ToDateTime(drExecutive_Risk["Date_HR_Received_Compliant"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._HR_Complaint_Recipient = Convert.ToString(drExecutive_Risk["HR_Complaint_Recipient"]);
            }

            else
            {

                this._Actual_Defense_Expense = -1;
                this._Actual_Defense_Expense_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Actual_Settlement = -1;
                this._Actual_Settlement_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Allocation = -1;
                this._Bordereau_Report = "";
                this._Case_Number = "";
                this._Claim_Close_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Claim_Description = "";
                this._Claim_Number = "";
                this._Claim_Open_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Claim_Reopen_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Claim_Status_Comments = "";
                this._Claim_Type_Other = "";
                this._Comments = "";
                this._Complainant_Plaintiff = "";
                this._Court = "";
                this._Date_Acknowledgement_Primary_Carrier = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Date_Alleged_Wrongful_Act = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Date_Broker_Received_Complaint = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Date_Carrier_Notified = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Date_Complaint_Received = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Date_Complaint_Suit_Filed = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Date_Legal_Received_Complaint = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Date_Representation_Letter_Received = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Date_Risk_Management_Received_Complaint = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Date_Suite_Served = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Defendant = "";
                this._Demand_Exposure_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._EEOC = "";
                this._Estimated_Defense_Expense = -1;
                this._Estimated_Defense_Expense_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Estimated_Demand_Exposure = -1;
                this._FK_Entity = -1;
                this._FK_Type_Of_ER_Allegation = -1;
                this._FK_Type_Of_ER_Claim = -1;
                this._Internal_Counsel = "";
                this._Judge_Arbitrator = "";
                this._Jurisdiction = "";
                this._Legal_File_Number = "";
                this._Legal_Status = "";
                this._Legal_Telephone = "";
                this._Other_Litigation = "";
                this._Panel_Counsel_Required = "";
                this._PK_Executive_Risk = -1;
                this._Primary_Deductable = -1;
                this._Primary_Defense_File_Number = "";
                this._Primary_Insurance_Claim_Number = "";
                this._Primary_Insurance_Policy_Number = "";
                this._Primary_Policy_Effective_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Primary_Policy_Expiration_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Representation_Letter_Received = "";
                this._Secondary_Defense_File_Number = "";
                this._Security_Litigation = "";
                this._State_Employment_Commission = "";
                this._Total_Program_Limit = -1;
                this._Update_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Updated_By = "";
                this._Legal_Complaint_Recipient = "";
                this._Date_HR_Received_Compliant = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._HR_Complaint_Recipient = "";
            }

        }

        #endregion



        #region "Methods"
        /// <summary>
        /// Inserts a record into the Executive_Risk table.
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Executive_RiskInsert");

            db.AddInParameter(dbCommand, "Actual_Defense_Expense", DbType.Decimal, this._Actual_Defense_Expense);
            db.AddInParameter(dbCommand, "Actual_Defense_Expense_Date", DbType.DateTime, this._Actual_Defense_Expense_Date);
            db.AddInParameter(dbCommand, "Actual_Settlement", DbType.Decimal, this._Actual_Settlement);
            db.AddInParameter(dbCommand, "Actual_Settlement_Date", DbType.DateTime, this._Actual_Settlement_Date);
            db.AddInParameter(dbCommand, "Allocation", DbType.Decimal, this._Allocation);
            db.AddInParameter(dbCommand, "Bordereau_Report", DbType.String, this._Bordereau_Report);
            db.AddInParameter(dbCommand, "Case_Number", DbType.String, this._Case_Number);
            if (this._Claim_Close_Date != System.Data.SqlTypes.SqlDateTime.MinValue)
                db.AddInParameter(dbCommand, "Claim_Close_Date", DbType.DateTime, this._Claim_Close_Date);
            else
                db.AddInParameter(dbCommand, "Claim_Close_Date", DbType.DateTime, DBNull.Value);
            db.AddInParameter(dbCommand, "Claim_Description", DbType.String, this._Claim_Description);
            db.AddInParameter(dbCommand, "Claim_Number", DbType.String, this._Claim_Number);
            if (this._Claim_Open_Date != System.Data.SqlTypes.SqlDateTime.MinValue)
                db.AddInParameter(dbCommand, "Claim_Open_Date", DbType.DateTime, this._Claim_Open_Date);
            else
                db.AddInParameter(dbCommand, "Claim_Open_Date", DbType.DateTime, DBNull.Value);
            if (this._Claim_Reopen_Date != System.Data.SqlTypes.SqlDateTime.MinValue)
                db.AddInParameter(dbCommand, "Claim_Reopen_Date", DbType.DateTime, this._Claim_Reopen_Date);
            else
                db.AddInParameter(dbCommand, "Claim_Reopen_Date", DbType.DateTime, DBNull.Value);
            db.AddInParameter(dbCommand, "Claim_Status_Comments", DbType.String, this._Claim_Status_Comments);
            db.AddInParameter(dbCommand, "Claim_Type_Other", DbType.String, this._Claim_Type_Other);
            db.AddInParameter(dbCommand, "Comments", DbType.String, this._Comments);
            db.AddInParameter(dbCommand, "Complainant_Plaintiff", DbType.String, this._Complainant_Plaintiff);
            db.AddInParameter(dbCommand, "Court", DbType.String, this._Court);
            db.AddInParameter(dbCommand, "Date_Acknowledgement_Primary_Carrier", DbType.DateTime, this._Date_Acknowledgement_Primary_Carrier);
            db.AddInParameter(dbCommand, "Date_Alleged_Wrongful_Act", DbType.DateTime, this._Date_Alleged_Wrongful_Act);
            db.AddInParameter(dbCommand, "Date_Broker_Received_Complaint", DbType.DateTime, this._Date_Broker_Received_Complaint);
            db.AddInParameter(dbCommand, "Date_Carrier_Notified", DbType.DateTime, this._Date_Carrier_Notified);
            db.AddInParameter(dbCommand, "Date_Complaint_Received", DbType.DateTime, this._Date_Complaint_Received);
            db.AddInParameter(dbCommand, "Date_Complaint_Suit_Filed", DbType.DateTime, this._Date_Complaint_Suit_Filed);
            db.AddInParameter(dbCommand, "Date_Legal_Received_Complaint", DbType.DateTime, this._Date_Legal_Received_Complaint);
            db.AddInParameter(dbCommand, "Date_Representation_Letter_Received", DbType.DateTime, this._Date_Representation_Letter_Received);
            db.AddInParameter(dbCommand, "Date_Risk_Management_Received_Complaint", DbType.DateTime, this._Date_Risk_Management_Received_Complaint);
            db.AddInParameter(dbCommand, "Date_Suite_Served", DbType.DateTime, this._Date_Suite_Served);
            db.AddInParameter(dbCommand, "Defendant", DbType.String, this._Defendant);
            db.AddInParameter(dbCommand, "Demand_Exposure_Date", DbType.DateTime, this._Demand_Exposure_Date);
            db.AddInParameter(dbCommand, "EEOC", DbType.String, this._EEOC);
            db.AddInParameter(dbCommand, "Estimated_Defense_Expense", DbType.Decimal, this._Estimated_Defense_Expense);
            db.AddInParameter(dbCommand, "Estimated_Defense_Expense_Date", DbType.DateTime, this._Estimated_Defense_Expense_Date);
            db.AddInParameter(dbCommand, "Estimated_Demand_Exposure", DbType.Decimal, this._Estimated_Demand_Exposure);
            db.AddInParameter(dbCommand, "FK_Entity", DbType.Decimal, this._FK_Entity);
            db.AddInParameter(dbCommand, "FK_Type_Of_ER_Allegation", DbType.Decimal, this._FK_Type_Of_ER_Allegation);
            if (this._FK_Type_Of_ER_Claim == 0)
                db.AddInParameter(dbCommand, "FK_Type_Of_ER_Claim", DbType.Decimal, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "FK_Type_Of_ER_Claim", DbType.Decimal, this._FK_Type_Of_ER_Claim);
            db.AddInParameter(dbCommand, "Internal_Counsel", DbType.String, this._Internal_Counsel);
            db.AddInParameter(dbCommand, "Judge_Arbitrator", DbType.String, this._Judge_Arbitrator);
            db.AddInParameter(dbCommand, "Jurisdiction", DbType.String, this._Jurisdiction);
            db.AddInParameter(dbCommand, "Legal_File_Number", DbType.String, this._Legal_File_Number);
            db.AddInParameter(dbCommand, "Legal_Status", DbType.String, this._Legal_Status);
            db.AddInParameter(dbCommand, "Legal_Telephone", DbType.String, this._Legal_Telephone);
            db.AddInParameter(dbCommand, "Other_Litigation", DbType.String, this._Other_Litigation);
            db.AddInParameter(dbCommand, "Panel_Counsel_Required", DbType.String, this._Panel_Counsel_Required);
            db.AddInParameter(dbCommand, "Primary_Deductable", DbType.Decimal, this._Primary_Deductable);
            db.AddInParameter(dbCommand, "Primary_Defense_File_Number", DbType.String, this._Primary_Defense_File_Number);
            db.AddInParameter(dbCommand, "Primary_Insurance_Claim_Number", DbType.String, this._Primary_Insurance_Claim_Number);
            db.AddInParameter(dbCommand, "Primary_Insurance_Policy_Number", DbType.String, this._Primary_Insurance_Policy_Number);
            db.AddInParameter(dbCommand, "Primary_Policy_Effective_Date", DbType.DateTime, this._Primary_Policy_Effective_Date);
            db.AddInParameter(dbCommand, "Primary_Policy_Expiration_Date", DbType.DateTime, this._Primary_Policy_Expiration_Date);
            db.AddInParameter(dbCommand, "Representation_Letter_Received", DbType.String, this._Representation_Letter_Received);
            db.AddInParameter(dbCommand, "Secondary_Defense_File_Number", DbType.String, this._Secondary_Defense_File_Number);
            db.AddInParameter(dbCommand, "Security_Litigation", DbType.String, this._Security_Litigation);
            db.AddInParameter(dbCommand, "State_Employment_Commission", DbType.String, this._State_Employment_Commission);
            db.AddInParameter(dbCommand, "Total_Program_Limit", DbType.Decimal, this._Total_Program_Limit);
            db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);
            db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);
            db.AddInParameter(dbCommand, "Legal_Complaint_Recipient", DbType.String, this._Legal_Complaint_Recipient);
            db.AddInParameter(dbCommand, "Date_HR_Received_Compliant", DbType.DateTime, this._Date_HR_Received_Compliant);
            db.AddInParameter(dbCommand, "HR_Complaint_Recipient", DbType.String, this._HR_Complaint_Recipient);

            // Execute the query and return the new identity value
            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
        }

        /// <summary>
        /// Selects a single record from the Executive_Risk table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectByPK(decimal pK_Executive_Risk)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Executive_RiskSelectByPK");

            db.AddInParameter(dbCommand, "PK_Executive_Risk", DbType.Decimal, pK_Executive_Risk);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects records from the Executive_Risk table by a foreign key.
        /// </summary>
        /// <param name="fK_Type_Of_ER_Claim"></param>
        /// <returns>DataSet</returns>
        public static DataSet SelectByFK_Type_Of_ER_Claim(decimal fK_Type_Of_ER_Claim)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Executive_RiskSelectByFK_Type_Of_ER_Claim");

            db.AddInParameter(dbCommand, "FK_Type_Of_ER_Claim", DbType.Decimal, fK_Type_Of_ER_Claim);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the Executive_Risk table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Executive_RiskSelectAll");

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Updates a record in the Executive_Risk table.
        /// </summary>
        public void Update()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Executive_RiskUpdate");

            db.AddInParameter(dbCommand, "Actual_Defense_Expense", DbType.Decimal, this._Actual_Defense_Expense);
            db.AddInParameter(dbCommand, "Actual_Defense_Expense_Date", DbType.DateTime, this._Actual_Defense_Expense_Date);
            db.AddInParameter(dbCommand, "Actual_Settlement", DbType.Decimal, this._Actual_Settlement);
            db.AddInParameter(dbCommand, "Actual_Settlement_Date", DbType.DateTime, this._Actual_Settlement_Date);
            db.AddInParameter(dbCommand, "Allocation", DbType.Decimal, this._Allocation);
            db.AddInParameter(dbCommand, "Bordereau_Report", DbType.String, this._Bordereau_Report);
            db.AddInParameter(dbCommand, "Case_Number", DbType.String, this._Case_Number);
            if (this._Claim_Close_Date != System.Data.SqlTypes.SqlDateTime.MinValue)
                db.AddInParameter(dbCommand, "Claim_Close_Date", DbType.DateTime, this._Claim_Close_Date);
            else
                db.AddInParameter(dbCommand, "Claim_Close_Date", DbType.DateTime, DBNull.Value);
            db.AddInParameter(dbCommand, "Claim_Description", DbType.String, this._Claim_Description);
            db.AddInParameter(dbCommand, "Claim_Number", DbType.String, this._Claim_Number);
            if (this._Claim_Open_Date != System.Data.SqlTypes.SqlDateTime.MinValue)
                db.AddInParameter(dbCommand, "Claim_Open_Date", DbType.DateTime, this._Claim_Open_Date);
            else
                db.AddInParameter(dbCommand, "Claim_Open_Date", DbType.DateTime, DBNull.Value);
            if (this._Claim_Reopen_Date != System.Data.SqlTypes.SqlDateTime.MinValue)
                db.AddInParameter(dbCommand, "Claim_Reopen_Date", DbType.DateTime, this._Claim_Reopen_Date);
            else
                db.AddInParameter(dbCommand, "Claim_Reopen_Date", DbType.DateTime, DBNull.Value);
            db.AddInParameter(dbCommand, "Claim_Status_Comments", DbType.String, this._Claim_Status_Comments);
            db.AddInParameter(dbCommand, "Claim_Type_Other", DbType.String, this._Claim_Type_Other);
            db.AddInParameter(dbCommand, "Comments", DbType.String, this._Comments);
            db.AddInParameter(dbCommand, "Complainant_Plaintiff", DbType.String, this._Complainant_Plaintiff);
            db.AddInParameter(dbCommand, "Court", DbType.String, this._Court);
            db.AddInParameter(dbCommand, "Date_Acknowledgement_Primary_Carrier", DbType.DateTime, this._Date_Acknowledgement_Primary_Carrier);
            db.AddInParameter(dbCommand, "Date_Alleged_Wrongful_Act", DbType.DateTime, this._Date_Alleged_Wrongful_Act);
            db.AddInParameter(dbCommand, "Date_Broker_Received_Complaint", DbType.DateTime, this._Date_Broker_Received_Complaint);
            db.AddInParameter(dbCommand, "Date_Carrier_Notified", DbType.DateTime, this._Date_Carrier_Notified);
            db.AddInParameter(dbCommand, "Date_Complaint_Received", DbType.DateTime, this._Date_Complaint_Received);
            db.AddInParameter(dbCommand, "Date_Complaint_Suit_Filed", DbType.DateTime, this._Date_Complaint_Suit_Filed);
            db.AddInParameter(dbCommand, "Date_Legal_Received_Complaint", DbType.DateTime, this._Date_Legal_Received_Complaint);
            db.AddInParameter(dbCommand, "Date_Representation_Letter_Received", DbType.DateTime, this._Date_Representation_Letter_Received);
            db.AddInParameter(dbCommand, "Date_Risk_Management_Received_Complaint", DbType.DateTime, this._Date_Risk_Management_Received_Complaint);
            db.AddInParameter(dbCommand, "Date_Suite_Served", DbType.DateTime, this._Date_Suite_Served);
            db.AddInParameter(dbCommand, "Defendant", DbType.String, this._Defendant);
            db.AddInParameter(dbCommand, "Demand_Exposure_Date", DbType.DateTime, this._Demand_Exposure_Date);
            db.AddInParameter(dbCommand, "EEOC", DbType.String, this._EEOC);
            db.AddInParameter(dbCommand, "Estimated_Defense_Expense", DbType.Decimal, this._Estimated_Defense_Expense);
            db.AddInParameter(dbCommand, "Estimated_Defense_Expense_Date", DbType.DateTime, this._Estimated_Defense_Expense_Date);
            db.AddInParameter(dbCommand, "Estimated_Demand_Exposure", DbType.Decimal, this._Estimated_Demand_Exposure);
            db.AddInParameter(dbCommand, "FK_Entity", DbType.Decimal, this._FK_Entity);
            db.AddInParameter(dbCommand, "FK_Type_Of_ER_Allegation", DbType.Decimal, this._FK_Type_Of_ER_Allegation);
            if (this._FK_Type_Of_ER_Claim == 0)
                db.AddInParameter(dbCommand, "FK_Type_Of_ER_Claim", DbType.Decimal, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "FK_Type_Of_ER_Claim", DbType.Decimal, this._FK_Type_Of_ER_Claim);
            db.AddInParameter(dbCommand, "Internal_Counsel", DbType.String, this._Internal_Counsel);
            db.AddInParameter(dbCommand, "Judge_Arbitrator", DbType.String, this._Judge_Arbitrator);
            db.AddInParameter(dbCommand, "Jurisdiction", DbType.String, this._Jurisdiction);
            db.AddInParameter(dbCommand, "Legal_File_Number", DbType.String, this._Legal_File_Number);
            db.AddInParameter(dbCommand, "Legal_Status", DbType.String, this._Legal_Status);
            db.AddInParameter(dbCommand, "Legal_Telephone", DbType.String, this._Legal_Telephone);
            db.AddInParameter(dbCommand, "Other_Litigation", DbType.String, this._Other_Litigation);
            db.AddInParameter(dbCommand, "Panel_Counsel_Required", DbType.String, this._Panel_Counsel_Required);
            db.AddInParameter(dbCommand, "PK_Executive_Risk", DbType.Decimal, this._PK_Executive_Risk);
            db.AddInParameter(dbCommand, "Primary_Deductable", DbType.Decimal, this._Primary_Deductable);
            db.AddInParameter(dbCommand, "Primary_Defense_File_Number", DbType.String, this._Primary_Defense_File_Number);
            db.AddInParameter(dbCommand, "Primary_Insurance_Claim_Number", DbType.String, this._Primary_Insurance_Claim_Number);
            db.AddInParameter(dbCommand, "Primary_Insurance_Policy_Number", DbType.String, this._Primary_Insurance_Policy_Number);
            db.AddInParameter(dbCommand, "Primary_Policy_Effective_Date", DbType.DateTime, this._Primary_Policy_Effective_Date);
            db.AddInParameter(dbCommand, "Primary_Policy_Expiration_Date", DbType.DateTime, this._Primary_Policy_Expiration_Date);
            db.AddInParameter(dbCommand, "Representation_Letter_Received", DbType.String, this._Representation_Letter_Received);
            db.AddInParameter(dbCommand, "Secondary_Defense_File_Number", DbType.String, this._Secondary_Defense_File_Number);
            db.AddInParameter(dbCommand, "Security_Litigation", DbType.String, this._Security_Litigation);
            db.AddInParameter(dbCommand, "State_Employment_Commission", DbType.String, this._State_Employment_Commission);
            db.AddInParameter(dbCommand, "Total_Program_Limit", DbType.Decimal, this._Total_Program_Limit);
            db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);
            db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);
            db.AddInParameter(dbCommand, "Legal_Complaint_Recipient", DbType.String, this._Legal_Complaint_Recipient);
            db.AddInParameter(dbCommand, "Date_HR_Received_Compliant", DbType.DateTime, this._Date_HR_Received_Compliant);
            db.AddInParameter(dbCommand, "HR_Complaint_Recipient", DbType.String, this._HR_Complaint_Recipient);
            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Deletes a record from the Executive_Risk table by a composite primary key.
        /// </summary>
        public static void DeleteByPK(decimal pK_Executive_Risk)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Executive_RiskDeleteByPK");

            db.AddInParameter(dbCommand, "PK_Executive_Risk", DbType.Decimal, pK_Executive_Risk);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Deletes a record from the Executive_Risk table by a foreign key.
        /// </summary>
        public static void DeleteByFK_Type_Of_ER_Claim(decimal fK_Type_Of_ER_Claim)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Executive_RiskDeleteByFK_Type_Of_ER_Claim");

            db.AddInParameter(dbCommand, "FK_Type_Of_ER_Claim", DbType.Decimal, fK_Type_Of_ER_Claim);

            db.ExecuteNonQuery(dbCommand);
        }

        public static string GetNextClaimNumber(bool bAddTo, string strOldClaimNumber)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("GetNextClaimNumber");

            db.AddInParameter(dbCommand, "AddTo", DbType.Boolean, bAddTo);
            db.AddInParameter(dbCommand, "OldClaimNumber", DbType.String, strOldClaimNumber);
            db.AddOutParameter(dbCommand, "NewClaimNumber", DbType.String, 11);

            db.ExecuteNonQuery(dbCommand);
            return Convert.ToString(dbCommand.Parameters["@NewClaimNumber"].Value);
        }

        public static int SelectPKBy_ClaimID(int PK_Liability_Claim)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Executive_Risk_SelectPKBy_ClaimID");

            db.AddInParameter(dbCommand, "PK_Liability_Claim", DbType.Decimal, PK_Liability_Claim);
            db.AddOutParameter(dbCommand, "PK_Executive_Risk", DbType.Decimal, 13);

            db.ExecuteNonQuery(dbCommand);
            return Convert.ToInt32(dbCommand.Parameters["@PK_Executive_Risk"].Value);
        }

        public static DataSet ExecutiveRiskData(string ExecutiveRisk, string Claim_Number, string DateOfLossFrom, string DateOfLossTo, int? ClaimStatus, decimal? FK_Entity, decimal? FK_Risk_Type)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("ExecutiveRiskData");

            db.AddInParameter(dbCommand, "@ExecutiveRisk", DbType.String, ExecutiveRisk);
            db.AddInParameter(dbCommand, "@Claim_Number", DbType.String, Claim_Number);
            if (DateOfLossFrom != "")
                db.AddInParameter(dbCommand, "@DateOfLossFrom", DbType.String, DateOfLossFrom);
            if (DateOfLossTo != "")
                db.AddInParameter(dbCommand, "@DateOfLossTo", DbType.String, DateOfLossTo);
            db.AddInParameter(dbCommand, "@ClaimStatus", DbType.Int32, ClaimStatus);
            db.AddInParameter(dbCommand, "@FK_Entity", DbType.Decimal, FK_Entity);
            db.AddInParameter(dbCommand, "@FK_Risk_Type", DbType.Decimal, FK_Risk_Type);

            return db.ExecuteDataSet(dbCommand);
        }

        #endregion
    }
}
