using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
    /// <summary>
    /// Data access class for AP_Fraud_Events table.
    /// </summary>
    public sealed class clsAP_Fraud_Events
    {

        #region Private variables used to hold the property values

        private decimal? _PK_AP_Fraud_Events;
        private decimal? _FK_LU_Location;
        private string _Fraud_Number;
        private DateTime? _Exposure_Period_Begin_Date;
        private DateTime? _Exposure_Period_End_Date;
        private string _Reported_To;
        private DateTime? _Reported_Date;
        private string _Description_of_Event;
        private string _Customer_Relations_Hotline;
        private string _Discovered_Fraud_through_Audits;
        private string _Internal_Audit_Control_Breakdown_leading_to_Fraud_Event;
        private string _Retail_Lending;
        private string _Sonic_Associates_1800_Hotline;
        private string _Store_Red_Flags;
        private string _Notification_Other;
        private string _Other_Notification_Description;
        private string _Internal_Review_Purification_Notes;
        private DateTime? _Fraud_Date;
        private string _HR_Assignment;
        private string _HR_Associate_Contacted;
        private DateTime? _Date_HR_Assigned;
        private string _Internal_Audit_Assignment;
        private string _Internal_Audit_Associate_Contacted;
        private DateTime? _Date_Internal_Audit_Assigned;
        private string _Store_Controller_Assignment;
        private string _Store_Controller_Associate_Contacted;
        private DateTime? _Date_Store_Controller_Assigned;
        private string _Regional_Controller_Assignment;
        private string _Regional_Controller_Associate_Contacted;
        private DateTime? _Date_Regional_Controller_Assigned;
        private string _Legal_Department_Assignment;
        private string _Legal_Department_Associate_Contacted;
        private DateTime? _Date_Legal_Department_Assigned;
        private string _Outside_Legal_Assignment;
        private string _Outside_Legal_Associate_Contacted;
        private DateTime? _Date_Outside_Legal_Assigned;
        private string _Operations_Assignment;
        private string _Operations_Associate_Contacted;
        private DateTime? _Date_Operations_Assigned;
        private string _Retail_Lending_Assignment;
        private string _Retail_Lending_Associate_Contacted;
        private DateTime? _Date_Retail_Lending_Assigned;
        private string _OnSite_Findings;
        private string _TLO_Findings;
        private string _Statements_Obtained;
        private string _Fact_Finding_andor_Due_Diligence;
        private string _Law_Enforcement_Involvement;
        private string _Civil_Actrion;
        private string _Crimimal_Action;
        private string _Further_Investigation;
        private string _ACC_Suspension;
        private string _ACC_Termination;
        private string _ACC_Written;
        private string _ACC_Verbal;
        private string _Communication_Strategy;
        private string _Disposition_Game_Plan_Other;
        private string _Detailed_Deisposition_Game_Plan_Description;
        private string _Accounting_Gaps_and_Controls;
        private string _Aging_MFR_Incentives;
        private string _Aging_Warranties;
        private string _Account_Payable_Schemes;
        private string _Associate_Collusion;
        private string _Billing_Schemes;
        private string _External_Scam;
        private string _Improper_Disclosure_to_Customer_F_and_I_Product_Purchase;
        private string _Improper_Disclosure_to_Customer_Vehicle_Purchase;
        private string _Inventory_Schemes;
        private string _Operations_No_Adherence_to_Sonic_Policy_And_Playbook;
        private string _Vendor_Collusion;
        private string _Vendor_Schemes;
        private string _Root_Cause_Other;
        private string _Detail_Description_of_Root_Cause;
        private string _Change_a_Control;
        private string _Current_Systen_Enhancement;
        private string _Implementation_Policy;
        private string _New_System_Change;
        private string _Results_of_Disposition_Plan;
        private string _ReTraining;
        private string _Training;
        private string _CA_Other;
        private string _Detail_Description_of_Corrective_Action_andor_Recommendation;
        private string _Close_File;
        private DateTime? _Close_Date;
        private string _Reopen_File;
        private DateTime? _Reopen_Date;
        private string _Comments;
        private string _Updated_By;
        private DateTime? _Update_Date;
        private string _BT_Security_Assignment;
        private string _BT_Security_Associate_Contacted;
        private DateTime? _Date_BT_Security_Assigned;
        private string _Other_Assignment;
        private string _Other_Associate_Contacted;
        private DateTime? _Date_Other_Assigned;

        #endregion

        #region Public Property

        /// <summary>
        /// Gets or sets the PK_AP_Fraud_Events value.
        /// </summary>
        public decimal? PK_AP_Fraud_Events
        {
            get { return _PK_AP_Fraud_Events; }
            set { _PK_AP_Fraud_Events = value; }
        }

        /// <summary>
        /// Gets or sets the FK_LU_Location value.
        /// </summary>
        public decimal? FK_LU_Location
        {
            get { return _FK_LU_Location; }
            set { _FK_LU_Location = value; }
        }

        /// <summary>
        /// Gets or sets the Fraud_Number value.
        /// </summary>
        public string Fraud_Number
        {
            get { return _Fraud_Number; }
            set { _Fraud_Number = value; }
        }

        /// <summary>
        /// Gets or sets the Exposure_Period_Begin_Date value.
        /// </summary>
        public DateTime? Exposure_Period_Begin_Date
        {
            get { return _Exposure_Period_Begin_Date; }
            set { _Exposure_Period_Begin_Date = value; }
        }

        /// <summary>
        /// Gets or sets the Exposure_Period_End_Date value.
        /// </summary>
        public DateTime? Exposure_Period_End_Date
        {
            get { return _Exposure_Period_End_Date; }
            set { _Exposure_Period_End_Date = value; }
        }

        /// <summary>
        /// Gets or sets the Reported_To value.
        /// </summary>
        public string Reported_To
        {
            get { return _Reported_To; }
            set { _Reported_To = value; }
        }

        /// <summary>
        /// Gets or sets the Reported_Date value.
        /// </summary>
        public DateTime? Reported_Date
        {
            get { return _Reported_Date; }
            set { _Reported_Date = value; }
        }

        /// <summary>
        /// Gets or sets the Description_of_Event value.
        /// </summary>
        public string Description_of_Event
        {
            get { return _Description_of_Event; }
            set { _Description_of_Event = value; }
        }

        /// <summary>
        /// Gets or sets the Customer_Relations_Hotline value.
        /// </summary>
        public string Customer_Relations_Hotline
        {
            get { return _Customer_Relations_Hotline; }
            set { _Customer_Relations_Hotline = value; }
        }

        /// <summary>
        /// Gets or sets the Discovered_Fraud_through_Audits value.
        /// </summary>
        public string Discovered_Fraud_through_Audits
        {
            get { return _Discovered_Fraud_through_Audits; }
            set { _Discovered_Fraud_through_Audits = value; }
        }

        /// <summary>
        /// Gets or sets the Internal_Audit_Control_Breakdown_leading_to_Fraud_Event value.
        /// </summary>
        public string Internal_Audit_Control_Breakdown_leading_to_Fraud_Event
        {
            get { return _Internal_Audit_Control_Breakdown_leading_to_Fraud_Event; }
            set { _Internal_Audit_Control_Breakdown_leading_to_Fraud_Event = value; }
        }

        /// <summary>
        /// Gets or sets the Retail_Lending value.
        /// </summary>
        public string Retail_Lending
        {
            get { return _Retail_Lending; }
            set { _Retail_Lending = value; }
        }

        /// <summary>
        /// Gets or sets the Sonic_Associates_1800_Hotline value.
        /// </summary>
        public string Sonic_Associates_1800_Hotline
        {
            get { return _Sonic_Associates_1800_Hotline; }
            set { _Sonic_Associates_1800_Hotline = value; }
        }

        /// <summary>
        /// Gets or sets the Store_Red_Flags value.
        /// </summary>
        public string Store_Red_Flags
        {
            get { return _Store_Red_Flags; }
            set { _Store_Red_Flags = value; }
        }

        /// <summary>
        /// Gets or sets the Notification_Other value.
        /// </summary>
        public string Notification_Other
        {
            get { return _Notification_Other; }
            set { _Notification_Other = value; }
        }

        /// <summary>
        /// Gets or sets the Other_Notification_Description value.
        /// </summary>
        public string Other_Notification_Description
        {
            get { return _Other_Notification_Description; }
            set { _Other_Notification_Description = value; }
        }

        /// <summary>
        /// Gets or sets the Internal_Review_Purification_Notes value.
        /// </summary>
        public string Internal_Review_Purification_Notes
        {
            get { return _Internal_Review_Purification_Notes; }
            set { _Internal_Review_Purification_Notes = value; }
        }

        /// <summary>
        /// Gets or sets the Fraud_Date value.
        /// </summary>
        public DateTime? Fraud_Date
        {
            get { return _Fraud_Date; }
            set { _Fraud_Date = value; }
        }

        /// <summary>
        /// Gets or sets the HR_Assignment value.
        /// </summary>
        public string HR_Assignment
        {
            get { return _HR_Assignment; }
            set { _HR_Assignment = value; }
        }

        /// <summary>
        /// Gets or sets the HR_Associate_Contacted value.
        /// </summary>
        public string HR_Associate_Contacted
        {
            get { return _HR_Associate_Contacted; }
            set { _HR_Associate_Contacted = value; }
        }

        /// <summary>
        /// Gets or sets the Date_HR_Assigned value.
        /// </summary>
        public DateTime? Date_HR_Assigned
        {
            get { return _Date_HR_Assigned; }
            set { _Date_HR_Assigned = value; }
        }

        /// <summary>
        /// Gets or sets the Internal_Audit_Assignment value.
        /// </summary>
        public string Internal_Audit_Assignment
        {
            get { return _Internal_Audit_Assignment; }
            set { _Internal_Audit_Assignment = value; }
        }

        /// <summary>
        /// Gets or sets the Internal_Audit_Associate_Contacted value.
        /// </summary>
        public string Internal_Audit_Associate_Contacted
        {
            get { return _Internal_Audit_Associate_Contacted; }
            set { _Internal_Audit_Associate_Contacted = value; }
        }

        /// <summary>
        /// Gets or sets the Date_Internal_Audit_Assigned value.
        /// </summary>
        public DateTime? Date_Internal_Audit_Assigned
        {
            get { return _Date_Internal_Audit_Assigned; }
            set { _Date_Internal_Audit_Assigned = value; }
        }

        /// <summary>
        /// Gets or sets the Store_Controller_Assignment value.
        /// </summary>
        public string Store_Controller_Assignment
        {
            get { return _Store_Controller_Assignment; }
            set { _Store_Controller_Assignment = value; }
        }

        /// <summary>
        /// Gets or sets the Store_Controller_Associate_Contacted value.
        /// </summary>
        public string Store_Controller_Associate_Contacted
        {
            get { return _Store_Controller_Associate_Contacted; }
            set { _Store_Controller_Associate_Contacted = value; }
        }

        /// <summary>
        /// Gets or sets the Date_Store_Controller_Assigned value.
        /// </summary>
        public DateTime? Date_Store_Controller_Assigned
        {
            get { return _Date_Store_Controller_Assigned; }
            set { _Date_Store_Controller_Assigned = value; }
        }

        /// <summary>
        /// Gets or sets the Regional_Controller_Assignment value.
        /// </summary>
        public string Regional_Controller_Assignment
        {
            get { return _Regional_Controller_Assignment; }
            set { _Regional_Controller_Assignment = value; }
        }

        /// <summary>
        /// Gets or sets the Regional_Controller_Associate_Contacted value.
        /// </summary>
        public string Regional_Controller_Associate_Contacted
        {
            get { return _Regional_Controller_Associate_Contacted; }
            set { _Regional_Controller_Associate_Contacted = value; }
        }

        /// <summary>
        /// Gets or sets the Date_Regional_Controller_Assigned value.
        /// </summary>
        public DateTime? Date_Regional_Controller_Assigned
        {
            get { return _Date_Regional_Controller_Assigned; }
            set { _Date_Regional_Controller_Assigned = value; }
        }

        /// <summary>
        /// Gets or sets the Legal_Department_Assignment value.
        /// </summary>
        public string Legal_Department_Assignment
        {
            get { return _Legal_Department_Assignment; }
            set { _Legal_Department_Assignment = value; }
        }

        /// <summary>
        /// Gets or sets the Legal_Department_Associate_Contacted value.
        /// </summary>
        public string Legal_Department_Associate_Contacted
        {
            get { return _Legal_Department_Associate_Contacted; }
            set { _Legal_Department_Associate_Contacted = value; }
        }

        /// <summary>
        /// Gets or sets the Date_Legal_Department_Assigned value.
        /// </summary>
        public DateTime? Date_Legal_Department_Assigned
        {
            get { return _Date_Legal_Department_Assigned; }
            set { _Date_Legal_Department_Assigned = value; }
        }

        /// <summary>
        /// Gets or sets the Outside_Legal_Assignment value.
        /// </summary>
        public string Outside_Legal_Assignment
        {
            get { return _Outside_Legal_Assignment; }
            set { _Outside_Legal_Assignment = value; }
        }

        /// <summary>
        /// Gets or sets the Outside_Legal_Associate_Contacted value.
        /// </summary>
        public string Outside_Legal_Associate_Contacted
        {
            get { return _Outside_Legal_Associate_Contacted; }
            set { _Outside_Legal_Associate_Contacted = value; }
        }

        /// <summary>
        /// Gets or sets the Date_Outside_Legal_Assigned value.
        /// </summary>
        public DateTime? Date_Outside_Legal_Assigned
        {
            get { return _Date_Outside_Legal_Assigned; }
            set { _Date_Outside_Legal_Assigned = value; }
        }

        /// <summary>
        /// Gets or sets the Operations_Assignment value.
        /// </summary>
        public string Operations_Assignment
        {
            get { return _Operations_Assignment; }
            set { _Operations_Assignment = value; }
        }

        /// <summary>
        /// Gets or sets the Operations_Associate_Contacted value.
        /// </summary>
        public string Operations_Associate_Contacted
        {
            get { return _Operations_Associate_Contacted; }
            set { _Operations_Associate_Contacted = value; }
        }

        /// <summary>
        /// Gets or sets the Date_Operations_Assigned value.
        /// </summary>
        public DateTime? Date_Operations_Assigned
        {
            get { return _Date_Operations_Assigned; }
            set { _Date_Operations_Assigned = value; }
        }

        /// <summary>
        /// Gets or sets the Retail_Lending_Assignment value.
        /// </summary>
        public string Retail_Lending_Assignment
        {
            get { return _Retail_Lending_Assignment; }
            set { _Retail_Lending_Assignment = value; }
        }

        /// <summary>
        /// Gets or sets the Retail_Lending_Associate_Contacted value.
        /// </summary>
        public string Retail_Lending_Associate_Contacted
        {
            get { return _Retail_Lending_Associate_Contacted; }
            set { _Retail_Lending_Associate_Contacted = value; }
        }

        /// <summary>
        /// Gets or sets the Date_Retail_Lending_Assigned value.
        /// </summary>
        public DateTime? Date_Retail_Lending_Assigned
        {
            get { return _Date_Retail_Lending_Assigned; }
            set { _Date_Retail_Lending_Assigned = value; }
        }

        /// <summary>
        /// Gets or sets the OnSite_Findings value.
        /// </summary>
        public string OnSite_Findings
        {
            get { return _OnSite_Findings; }
            set { _OnSite_Findings = value; }
        }

        /// <summary>
        /// Gets or sets the TLO_Findings value.
        /// </summary>
        public string TLO_Findings
        {
            get { return _TLO_Findings; }
            set { _TLO_Findings = value; }
        }

        /// <summary>
        /// Gets or sets the Statements_Obtained value.
        /// </summary>
        public string Statements_Obtained
        {
            get { return _Statements_Obtained; }
            set { _Statements_Obtained = value; }
        }

        /// <summary>
        /// Gets or sets the Fact_Finding_andor_Due_Diligence value.
        /// </summary>
        public string Fact_Finding_andor_Due_Diligence
        {
            get { return _Fact_Finding_andor_Due_Diligence; }
            set { _Fact_Finding_andor_Due_Diligence = value; }
        }

        /// <summary>
        /// Gets or sets the Law_Enforcement_Involvement value.
        /// </summary>
        public string Law_Enforcement_Involvement
        {
            get { return _Law_Enforcement_Involvement; }
            set { _Law_Enforcement_Involvement = value; }
        }

        /// <summary>
        /// Gets or sets the Civil_Actrion value.
        /// </summary>
        public string Civil_Actrion
        {
            get { return _Civil_Actrion; }
            set { _Civil_Actrion = value; }
        }

        /// <summary>
        /// Gets or sets the Crimimal_Action value.
        /// </summary>
        public string Crimimal_Action
        {
            get { return _Crimimal_Action; }
            set { _Crimimal_Action = value; }
        }

        /// <summary>
        /// Gets or sets the Further_Investigation value.
        /// </summary>
        public string Further_Investigation
        {
            get { return _Further_Investigation; }
            set { _Further_Investigation = value; }
        }

        /// <summary>
        /// Gets or sets the ACC_Suspension value.
        /// </summary>
        public string ACC_Suspension
        {
            get { return _ACC_Suspension; }
            set { _ACC_Suspension = value; }
        }

        /// <summary>
        /// Gets or sets the ACC_Termination value.
        /// </summary>
        public string ACC_Termination
        {
            get { return _ACC_Termination; }
            set { _ACC_Termination = value; }
        }

        /// <summary>
        /// Gets or sets the ACC_Written value.
        /// </summary>
        public string ACC_Written
        {
            get { return _ACC_Written; }
            set { _ACC_Written = value; }
        }

        /// <summary>
        /// Gets or sets the ACC_Verbal value.
        /// </summary>
        public string ACC_Verbal
        {
            get { return _ACC_Verbal; }
            set { _ACC_Verbal = value; }
        }

        /// <summary>
        /// Gets or sets the Communication_Strategy value.
        /// </summary>
        public string Communication_Strategy
        {
            get { return _Communication_Strategy; }
            set { _Communication_Strategy = value; }
        }

        /// <summary>
        /// Gets or sets the Disposition_Game_Plan_Other value.
        /// </summary>
        public string Disposition_Game_Plan_Other
        {
            get { return _Disposition_Game_Plan_Other; }
            set { _Disposition_Game_Plan_Other = value; }
        }

        /// <summary>
        /// Gets or sets the Detailed_Deisposition_Game_Plan_Description value.
        /// </summary>
        public string Detailed_Deisposition_Game_Plan_Description
        {
            get { return _Detailed_Deisposition_Game_Plan_Description; }
            set { _Detailed_Deisposition_Game_Plan_Description = value; }
        }

        /// <summary>
        /// Gets or sets the Accounting_Gaps_and_Controls value.
        /// </summary>
        public string Accounting_Gaps_and_Controls
        {
            get { return _Accounting_Gaps_and_Controls; }
            set { _Accounting_Gaps_and_Controls = value; }
        }

        /// <summary>
        /// Gets or sets the Aging_MFR_Incentives value.
        /// </summary>
        public string Aging_MFR_Incentives
        {
            get { return _Aging_MFR_Incentives; }
            set { _Aging_MFR_Incentives = value; }
        }

        /// <summary>
        /// Gets or sets the Aging_Warranties value.
        /// </summary>
        public string Aging_Warranties
        {
            get { return _Aging_Warranties; }
            set { _Aging_Warranties = value; }
        }

        /// <summary>
        /// Gets or sets the Account_Payable_Schemes value.
        /// </summary>
        public string Account_Payable_Schemes
        {
            get { return _Account_Payable_Schemes; }
            set { _Account_Payable_Schemes = value; }
        }

        /// <summary>
        /// Gets or sets the Associate_Collusion value.
        /// </summary>
        public string Associate_Collusion
        {
            get { return _Associate_Collusion; }
            set { _Associate_Collusion = value; }
        }

        /// <summary>
        /// Gets or sets the Billing_Schemes value.
        /// </summary>
        public string Billing_Schemes
        {
            get { return _Billing_Schemes; }
            set { _Billing_Schemes = value; }
        }

        /// <summary>
        /// Gets or sets the External_Scam value.
        /// </summary>
        public string External_Scam
        {
            get { return _External_Scam; }
            set { _External_Scam = value; }
        }

        /// <summary>
        /// Gets or sets the Improper_Disclosure_to_Customer_F_and_I_Product_Purchase value.
        /// </summary>
        public string Improper_Disclosure_to_Customer_F_and_I_Product_Purchase
        {
            get { return _Improper_Disclosure_to_Customer_F_and_I_Product_Purchase; }
            set { _Improper_Disclosure_to_Customer_F_and_I_Product_Purchase = value; }
        }

        /// <summary>
        /// Gets or sets the Improper_Disclosure_to_Customer_Vehicle_Purchase value.
        /// </summary>
        public string Improper_Disclosure_to_Customer_Vehicle_Purchase
        {
            get { return _Improper_Disclosure_to_Customer_Vehicle_Purchase; }
            set { _Improper_Disclosure_to_Customer_Vehicle_Purchase = value; }
        }

        /// <summary>
        /// Gets or sets the Inventory_Schemes value.
        /// </summary>
        public string Inventory_Schemes
        {
            get { return _Inventory_Schemes; }
            set { _Inventory_Schemes = value; }
        }

        /// <summary>
        /// Gets or sets the Operations_No_Adherence_to_Sonic_Policy_And_Playbook value.
        /// </summary>
        public string Operations_No_Adherence_to_Sonic_Policy_And_Playbook
        {
            get { return _Operations_No_Adherence_to_Sonic_Policy_And_Playbook; }
            set { _Operations_No_Adherence_to_Sonic_Policy_And_Playbook = value; }
        }

        /// <summary>
        /// Gets or sets the Vendor_Collusion value.
        /// </summary>
        public string Vendor_Collusion
        {
            get { return _Vendor_Collusion; }
            set { _Vendor_Collusion = value; }
        }

        /// <summary>
        /// Gets or sets the Vendor_Schemes value.
        /// </summary>
        public string Vendor_Schemes
        {
            get { return _Vendor_Schemes; }
            set { _Vendor_Schemes = value; }
        }

        /// <summary>
        /// Gets or sets the Root_Cause_Other value.
        /// </summary>
        public string Root_Cause_Other
        {
            get { return _Root_Cause_Other; }
            set { _Root_Cause_Other = value; }
        }

        /// <summary>
        /// Gets or sets the Detail_Description_of_Root_Cause value.
        /// </summary>
        public string Detail_Description_of_Root_Cause
        {
            get { return _Detail_Description_of_Root_Cause; }
            set { _Detail_Description_of_Root_Cause = value; }
        }

        /// <summary>
        /// Gets or sets the Change_a_Control value.
        /// </summary>
        public string Change_a_Control
        {
            get { return _Change_a_Control; }
            set { _Change_a_Control = value; }
        }

        /// <summary>
        /// Gets or sets the Current_Systen_Enhancement value.
        /// </summary>
        public string Current_Systen_Enhancement
        {
            get { return _Current_Systen_Enhancement; }
            set { _Current_Systen_Enhancement = value; }
        }

        /// <summary>
        /// Gets or sets the Implementation_Policy value.
        /// </summary>
        public string Implementation_Policy
        {
            get { return _Implementation_Policy; }
            set { _Implementation_Policy = value; }
        }

        /// <summary>
        /// Gets or sets the New_System_Change value.
        /// </summary>
        public string New_System_Change
        {
            get { return _New_System_Change; }
            set { _New_System_Change = value; }
        }

        /// <summary>
        /// Gets or sets the Results_of_Disposition_Plan value.
        /// </summary>
        public string Results_of_Disposition_Plan
        {
            get { return _Results_of_Disposition_Plan; }
            set { _Results_of_Disposition_Plan = value; }
        }

        /// <summary>
        /// Gets or sets the ReTraining value.
        /// </summary>
        public string ReTraining
        {
            get { return _ReTraining; }
            set { _ReTraining = value; }
        }

        /// <summary>
        /// Gets or sets the Training value.
        /// </summary>
        public string Training
        {
            get { return _Training; }
            set { _Training = value; }
        }

        /// <summary>
        /// Gets or sets the CA_Other value.
        /// </summary>
        public string CA_Other
        {
            get { return _CA_Other; }
            set { _CA_Other = value; }
        }

        /// <summary>
        /// Gets or sets the Detail_Description_of_Corrective_Action_andor_Recommendation value.
        /// </summary>
        public string Detail_Description_of_Corrective_Action_andor_Recommendation
        {
            get { return _Detail_Description_of_Corrective_Action_andor_Recommendation; }
            set { _Detail_Description_of_Corrective_Action_andor_Recommendation = value; }
        }

        /// <summary>
        /// Gets or sets the Close_File value.
        /// </summary>
        public string Close_File
        {
            get { return _Close_File; }
            set { _Close_File = value; }
        }

        /// <summary>
        /// Gets or sets the Close_Date value.
        /// </summary>
        public DateTime? Close_Date
        {
            get { return _Close_Date; }
            set { _Close_Date = value; }
        }

        /// <summary>
        /// Gets or sets the Reopen_File value.
        /// </summary>
        public string Reopen_File
        {
            get { return _Reopen_File; }
            set { _Reopen_File = value; }
        }

        /// <summary>
        /// Gets or sets the Reopen_Date value.
        /// </summary>
        public DateTime? Reopen_Date
        {
            get { return _Reopen_Date; }
            set { _Reopen_Date = value; }
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
        public DateTime? Update_Date
        {
            get { return _Update_Date; }
            set { _Update_Date = value; }
        }

        /// <summary>
        /// Gets or sets the BT_Security_Assignment value.
        /// </summary>
        public string BT_Security_Assignment
        {
            get { return _BT_Security_Assignment; }
            set { _BT_Security_Assignment = value; }
        }

        /// <summary>
        /// Gets or sets the BT_Security_Associate_Contacted value.
        /// </summary>
        public string BT_Security_Associate_Contacted
        {
            get { return _BT_Security_Associate_Contacted; }
            set { _BT_Security_Associate_Contacted = value; }
        }

        /// <summary>
        /// Gets or sets the Date_BT_Security_Assigned value.
        /// </summary>
        public DateTime? Date_BT_Security_Assigned
        {
            get { return _Date_BT_Security_Assigned; }
            set { _Date_BT_Security_Assigned = value; }
        }

        /// <summary>
        /// Gets or sets the Other_Assignment value.
        /// </summary>
        public string Other_Assignment
        {
            get { return _Other_Assignment; }
            set { _Other_Assignment = value; }
        }

        /// <summary>
        /// Gets or sets the Other_Associate_Contacted value.
        /// </summary>
        public string Other_Associate_Contacted
        {
            get { return _Other_Associate_Contacted; }
            set { _Other_Associate_Contacted = value; }
        }

        /// <summary>
        /// Gets or sets the Date_Other_Assigned value.
        /// </summary>
        public DateTime? Date_Other_Assigned
        {
            get { return _Date_Other_Assigned; }
            set { _Date_Other_Assigned = value; }
        }

        #endregion

        #region Default Constructors

        /// <summary>
        /// Initializes a new instance of the clsAP_Fraud_Events class with default value.
        /// </summary>
        public clsAP_Fraud_Events()
        {


        }

        #endregion

        #region Primary Constructors

        /// <summary>
        /// Initializes a new instance of the clsAP_Fraud_Events class based on Primary Key.
        /// </summary>
        public clsAP_Fraud_Events(decimal pK_AP_Fraud_Events)
        {
            DataTable dtAP_Fraud_Events = SelectByPK(pK_AP_Fraud_Events).Tables[0];

            if (dtAP_Fraud_Events.Rows.Count == 1)
            {
                SetValue(dtAP_Fraud_Events.Rows[0]);

            }

        }


        /// <summary>
        /// Initializes a new instance of the clsAP_Fraud_Events class based on Datarow passed.
        /// </summary>
        private void SetValue(DataRow drAP_Fraud_Events)
        {
            if (drAP_Fraud_Events["PK_AP_Fraud_Events"] == DBNull.Value)
                this._PK_AP_Fraud_Events = null;
            else
                this._PK_AP_Fraud_Events = (decimal?)drAP_Fraud_Events["PK_AP_Fraud_Events"];

            if (drAP_Fraud_Events["FK_LU_Location"] == DBNull.Value)
                this._FK_LU_Location = null;
            else
                this._FK_LU_Location = (decimal?)drAP_Fraud_Events["FK_LU_Location"];

            if (drAP_Fraud_Events["Fraud_Number"] == DBNull.Value)
                this._Fraud_Number = null;
            else
                this._Fraud_Number = (string)drAP_Fraud_Events["Fraud_Number"];

            if (drAP_Fraud_Events["Exposure_Period_Begin_Date"] == DBNull.Value)
                this._Exposure_Period_Begin_Date = null;
            else
                this._Exposure_Period_Begin_Date = (DateTime?)drAP_Fraud_Events["Exposure_Period_Begin_Date"];

            if (drAP_Fraud_Events["Exposure_Period_End_Date"] == DBNull.Value)
                this._Exposure_Period_End_Date = null;
            else
                this._Exposure_Period_End_Date = (DateTime?)drAP_Fraud_Events["Exposure_Period_End_Date"];

            if (drAP_Fraud_Events["Reported_To"] == DBNull.Value)
                this._Reported_To = null;
            else
                this._Reported_To = (string)drAP_Fraud_Events["Reported_To"];

            if (drAP_Fraud_Events["Reported_Date"] == DBNull.Value)
                this._Reported_Date = null;
            else
                this._Reported_Date = (DateTime?)drAP_Fraud_Events["Reported_Date"];

            if (drAP_Fraud_Events["Description_of_Event"] == DBNull.Value)
                this._Description_of_Event = null;
            else
                this._Description_of_Event = (string)drAP_Fraud_Events["Description_of_Event"];

            if (drAP_Fraud_Events["Customer_Relations_Hotline"] == DBNull.Value)
                this._Customer_Relations_Hotline = null;
            else
                this._Customer_Relations_Hotline = (string)drAP_Fraud_Events["Customer_Relations_Hotline"];

            if (drAP_Fraud_Events["Discovered_Fraud_through_Audits"] == DBNull.Value)
                this._Discovered_Fraud_through_Audits = null;
            else
                this._Discovered_Fraud_through_Audits = (string)drAP_Fraud_Events["Discovered_Fraud_through_Audits"];

            if (drAP_Fraud_Events["Internal_Audit_Control_Breakdown_leading_to_Fraud_Event"] == DBNull.Value)
                this._Internal_Audit_Control_Breakdown_leading_to_Fraud_Event = null;
            else
                this._Internal_Audit_Control_Breakdown_leading_to_Fraud_Event = (string)drAP_Fraud_Events["Internal_Audit_Control_Breakdown_leading_to_Fraud_Event"];

            if (drAP_Fraud_Events["Retail_Lending"] == DBNull.Value)
                this._Retail_Lending = null;
            else
                this._Retail_Lending = (string)drAP_Fraud_Events["Retail_Lending"];

            if (drAP_Fraud_Events["Sonic_Associates_1800_Hotline"] == DBNull.Value)
                this._Sonic_Associates_1800_Hotline = null;
            else
                this._Sonic_Associates_1800_Hotline = (string)drAP_Fraud_Events["Sonic_Associates_1800_Hotline"];

            if (drAP_Fraud_Events["Store_Red_Flags"] == DBNull.Value)
                this._Store_Red_Flags = null;
            else
                this._Store_Red_Flags = (string)drAP_Fraud_Events["Store_Red_Flags"];

            if (drAP_Fraud_Events["Notification_Other"] == DBNull.Value)
                this._Notification_Other = null;
            else
                this._Notification_Other = (string)drAP_Fraud_Events["Notification_Other"];

            if (drAP_Fraud_Events["Other_Notification_Description"] == DBNull.Value)
                this._Other_Notification_Description = null;
            else
                this._Other_Notification_Description = (string)drAP_Fraud_Events["Other_Notification_Description"];

            if (drAP_Fraud_Events["Internal_Review_Purification_Notes"] == DBNull.Value)
                this._Internal_Review_Purification_Notes = null;
            else
                this._Internal_Review_Purification_Notes = (string)drAP_Fraud_Events["Internal_Review_Purification_Notes"];

            if (drAP_Fraud_Events["Fraud_Date"] == DBNull.Value)
                this._Fraud_Date = null;
            else
                this._Fraud_Date = (DateTime?)drAP_Fraud_Events["Fraud_Date"];

            if (drAP_Fraud_Events["HR_Assignment"] == DBNull.Value)
                this._HR_Assignment = null;
            else
                this._HR_Assignment = (string)drAP_Fraud_Events["HR_Assignment"];

            if (drAP_Fraud_Events["HR_Associate_Contacted"] == DBNull.Value)
                this._HR_Associate_Contacted = null;
            else
                this._HR_Associate_Contacted = (string)drAP_Fraud_Events["HR_Associate_Contacted"];

            if (drAP_Fraud_Events["Date_HR_Assigned"] == DBNull.Value)
                this._Date_HR_Assigned = null;
            else
                this._Date_HR_Assigned = (DateTime?)drAP_Fraud_Events["Date_HR_Assigned"];

            if (drAP_Fraud_Events["Internal_Audit_Assignment"] == DBNull.Value)
                this._Internal_Audit_Assignment = null;
            else
                this._Internal_Audit_Assignment = (string)drAP_Fraud_Events["Internal_Audit_Assignment"];

            if (drAP_Fraud_Events["Internal_Audit_Associate_Contacted"] == DBNull.Value)
                this._Internal_Audit_Associate_Contacted = null;
            else
                this._Internal_Audit_Associate_Contacted = (string)drAP_Fraud_Events["Internal_Audit_Associate_Contacted"];

            if (drAP_Fraud_Events["Date_Internal_Audit_Assigned"] == DBNull.Value)
                this._Date_Internal_Audit_Assigned = null;
            else
                this._Date_Internal_Audit_Assigned = (DateTime?)drAP_Fraud_Events["Date_Internal_Audit_Assigned"];

            if (drAP_Fraud_Events["Store_Controller_Assignment"] == DBNull.Value)
                this._Store_Controller_Assignment = null;
            else
                this._Store_Controller_Assignment = (string)drAP_Fraud_Events["Store_Controller_Assignment"];

            if (drAP_Fraud_Events["Store_Controller_Associate_Contacted"] == DBNull.Value)
                this._Store_Controller_Associate_Contacted = null;
            else
                this._Store_Controller_Associate_Contacted = (string)drAP_Fraud_Events["Store_Controller_Associate_Contacted"];

            if (drAP_Fraud_Events["Date_Store_Controller_Assigned"] == DBNull.Value)
                this._Date_Store_Controller_Assigned = null;
            else
                this._Date_Store_Controller_Assigned = (DateTime?)drAP_Fraud_Events["Date_Store_Controller_Assigned"];

            if (drAP_Fraud_Events["Regional_Controller_Assignment"] == DBNull.Value)
                this._Regional_Controller_Assignment = null;
            else
                this._Regional_Controller_Assignment = (string)drAP_Fraud_Events["Regional_Controller_Assignment"];

            if (drAP_Fraud_Events["Regional_Controller_Associate_Contacted"] == DBNull.Value)
                this._Regional_Controller_Associate_Contacted = null;
            else
                this._Regional_Controller_Associate_Contacted = (string)drAP_Fraud_Events["Regional_Controller_Associate_Contacted"];

            if (drAP_Fraud_Events["Date_Regional_Controller_Assigned"] == DBNull.Value)
                this._Date_Regional_Controller_Assigned = null;
            else
                this._Date_Regional_Controller_Assigned = (DateTime?)drAP_Fraud_Events["Date_Regional_Controller_Assigned"];

            if (drAP_Fraud_Events["Legal_Department_Assignment"] == DBNull.Value)
                this._Legal_Department_Assignment = null;
            else
                this._Legal_Department_Assignment = (string)drAP_Fraud_Events["Legal_Department_Assignment"];

            if (drAP_Fraud_Events["Legal_Department_Associate_Contacted"] == DBNull.Value)
                this._Legal_Department_Associate_Contacted = null;
            else
                this._Legal_Department_Associate_Contacted = (string)drAP_Fraud_Events["Legal_Department_Associate_Contacted"];

            if (drAP_Fraud_Events["Date_Legal_Department_Assigned"] == DBNull.Value)
                this._Date_Legal_Department_Assigned = null;
            else
                this._Date_Legal_Department_Assigned = (DateTime?)drAP_Fraud_Events["Date_Legal_Department_Assigned"];

            if (drAP_Fraud_Events["Outside_Legal_Assignment"] == DBNull.Value)
                this._Outside_Legal_Assignment = null;
            else
                this._Outside_Legal_Assignment = (string)drAP_Fraud_Events["Outside_Legal_Assignment"];

            if (drAP_Fraud_Events["Outside_Legal_Associate_Contacted"] == DBNull.Value)
                this._Outside_Legal_Associate_Contacted = null;
            else
                this._Outside_Legal_Associate_Contacted = (string)drAP_Fraud_Events["Outside_Legal_Associate_Contacted"];

            if (drAP_Fraud_Events["Date_Outside_Legal_Assigned"] == DBNull.Value)
                this._Date_Outside_Legal_Assigned = null;
            else
                this._Date_Outside_Legal_Assigned = (DateTime?)drAP_Fraud_Events["Date_Outside_Legal_Assigned"];

            if (drAP_Fraud_Events["Operations_Assignment"] == DBNull.Value)
                this._Operations_Assignment = null;
            else
                this._Operations_Assignment = (string)drAP_Fraud_Events["Operations_Assignment"];

            if (drAP_Fraud_Events["Operations_Associate_Contacted"] == DBNull.Value)
                this._Operations_Associate_Contacted = null;
            else
                this._Operations_Associate_Contacted = (string)drAP_Fraud_Events["Operations_Associate_Contacted"];

            if (drAP_Fraud_Events["Date_Operations_Assigned"] == DBNull.Value)
                this._Date_Operations_Assigned = null;
            else
                this._Date_Operations_Assigned = (DateTime?)drAP_Fraud_Events["Date_Operations_Assigned"];

            if (drAP_Fraud_Events["Retail_Lending_Assignment"] == DBNull.Value)
                this._Retail_Lending_Assignment = null;
            else
                this._Retail_Lending_Assignment = (string)drAP_Fraud_Events["Retail_Lending_Assignment"];

            if (drAP_Fraud_Events["Retail_Lending_Associate_Contacted"] == DBNull.Value)
                this._Retail_Lending_Associate_Contacted = null;
            else
                this._Retail_Lending_Associate_Contacted = (string)drAP_Fraud_Events["Retail_Lending_Associate_Contacted"];

            if (drAP_Fraud_Events["Date_Retail_Lending_Assigned"] == DBNull.Value)
                this._Date_Retail_Lending_Assigned = null;
            else
                this._Date_Retail_Lending_Assigned = (DateTime?)drAP_Fraud_Events["Date_Retail_Lending_Assigned"];

            if (drAP_Fraud_Events["OnSite_Findings"] == DBNull.Value)
                this._OnSite_Findings = null;
            else
                this._OnSite_Findings = (string)drAP_Fraud_Events["OnSite_Findings"];

            if (drAP_Fraud_Events["TLO_Findings"] == DBNull.Value)
                this._TLO_Findings = null;
            else
                this._TLO_Findings = (string)drAP_Fraud_Events["TLO_Findings"];

            if (drAP_Fraud_Events["Statements_Obtained"] == DBNull.Value)
                this._Statements_Obtained = null;
            else
                this._Statements_Obtained = (string)drAP_Fraud_Events["Statements_Obtained"];

            if (drAP_Fraud_Events["Fact_Finding_andor_Due_Diligence"] == DBNull.Value)
                this._Fact_Finding_andor_Due_Diligence = null;
            else
                this._Fact_Finding_andor_Due_Diligence = (string)drAP_Fraud_Events["Fact_Finding_andor_Due_Diligence"];

            if (drAP_Fraud_Events["Law_Enforcement_Involvement"] == DBNull.Value)
                this._Law_Enforcement_Involvement = null;
            else
                this._Law_Enforcement_Involvement = (string)drAP_Fraud_Events["Law_Enforcement_Involvement"];

            if (drAP_Fraud_Events["Civil_Actrion"] == DBNull.Value)
                this._Civil_Actrion = null;
            else
                this._Civil_Actrion = (string)drAP_Fraud_Events["Civil_Actrion"];

            if (drAP_Fraud_Events["Crimimal_Action"] == DBNull.Value)
                this._Crimimal_Action = null;
            else
                this._Crimimal_Action = (string)drAP_Fraud_Events["Crimimal_Action"];

            if (drAP_Fraud_Events["Further_Investigation"] == DBNull.Value)
                this._Further_Investigation = null;
            else
                this._Further_Investigation = (string)drAP_Fraud_Events["Further_Investigation"];

            if (drAP_Fraud_Events["ACC_Suspension"] == DBNull.Value)
                this._ACC_Suspension = null;
            else
                this._ACC_Suspension = (string)drAP_Fraud_Events["ACC_Suspension"];

            if (drAP_Fraud_Events["ACC_Termination"] == DBNull.Value)
                this._ACC_Termination = null;
            else
                this._ACC_Termination = (string)drAP_Fraud_Events["ACC_Termination"];

            if (drAP_Fraud_Events["ACC_Written"] == DBNull.Value)
                this._ACC_Written = null;
            else
                this._ACC_Written = (string)drAP_Fraud_Events["ACC_Written"];

            if (drAP_Fraud_Events["ACC_Verbal"] == DBNull.Value)
                this._ACC_Verbal = null;
            else
                this._ACC_Verbal = (string)drAP_Fraud_Events["ACC_Verbal"];

            if (drAP_Fraud_Events["Communication_Strategy"] == DBNull.Value)
                this._Communication_Strategy = null;
            else
                this._Communication_Strategy = (string)drAP_Fraud_Events["Communication_Strategy"];

            if (drAP_Fraud_Events["Disposition_Game_Plan_Other"] == DBNull.Value)
                this._Disposition_Game_Plan_Other = null;
            else
                this._Disposition_Game_Plan_Other = (string)drAP_Fraud_Events["Disposition_Game_Plan_Other"];

            if (drAP_Fraud_Events["Detailed_Deisposition_Game_Plan_Description"] == DBNull.Value)
                this._Detailed_Deisposition_Game_Plan_Description = null;
            else
                this._Detailed_Deisposition_Game_Plan_Description = (string)drAP_Fraud_Events["Detailed_Deisposition_Game_Plan_Description"];

            if (drAP_Fraud_Events["Accounting_Gaps_and_Controls"] == DBNull.Value)
                this._Accounting_Gaps_and_Controls = null;
            else
                this._Accounting_Gaps_and_Controls = (string)drAP_Fraud_Events["Accounting_Gaps_and_Controls"];

            if (drAP_Fraud_Events["Aging_MFR_Incentives"] == DBNull.Value)
                this._Aging_MFR_Incentives = null;
            else
                this._Aging_MFR_Incentives = (string)drAP_Fraud_Events["Aging_MFR_Incentives"];

            if (drAP_Fraud_Events["Aging_Warranties"] == DBNull.Value)
                this._Aging_Warranties = null;
            else
                this._Aging_Warranties = (string)drAP_Fraud_Events["Aging_Warranties"];

            if (drAP_Fraud_Events["Account_Payable_Schemes"] == DBNull.Value)
                this._Account_Payable_Schemes = null;
            else
                this._Account_Payable_Schemes = (string)drAP_Fraud_Events["Account_Payable_Schemes"];

            if (drAP_Fraud_Events["Associate_Collusion"] == DBNull.Value)
                this._Associate_Collusion = null;
            else
                this._Associate_Collusion = (string)drAP_Fraud_Events["Associate_Collusion"];

            if (drAP_Fraud_Events["Billing_Schemes"] == DBNull.Value)
                this._Billing_Schemes = null;
            else
                this._Billing_Schemes = (string)drAP_Fraud_Events["Billing_Schemes"];

            if (drAP_Fraud_Events["External_Scam"] == DBNull.Value)
                this._External_Scam = null;
            else
                this._External_Scam = (string)drAP_Fraud_Events["External_Scam"];

            if (drAP_Fraud_Events["Improper_Disclosure_to_Customer_F_and_I_Product_Purchase"] == DBNull.Value)
                this._Improper_Disclosure_to_Customer_F_and_I_Product_Purchase = null;
            else
                this._Improper_Disclosure_to_Customer_F_and_I_Product_Purchase = (string)drAP_Fraud_Events["Improper_Disclosure_to_Customer_F_and_I_Product_Purchase"];

            if (drAP_Fraud_Events["Improper_Disclosure_to_Customer_Vehicle_Purchase"] == DBNull.Value)
                this._Improper_Disclosure_to_Customer_Vehicle_Purchase = null;
            else
                this._Improper_Disclosure_to_Customer_Vehicle_Purchase = (string)drAP_Fraud_Events["Improper_Disclosure_to_Customer_Vehicle_Purchase"];

            if (drAP_Fraud_Events["Inventory_Schemes"] == DBNull.Value)
                this._Inventory_Schemes = null;
            else
                this._Inventory_Schemes = (string)drAP_Fraud_Events["Inventory_Schemes"];

            if (drAP_Fraud_Events["Operations_No_Adherence_to_Sonic_Policy_And_Playbook"] == DBNull.Value)
                this._Operations_No_Adherence_to_Sonic_Policy_And_Playbook = null;
            else
                this._Operations_No_Adherence_to_Sonic_Policy_And_Playbook = (string)drAP_Fraud_Events["Operations_No_Adherence_to_Sonic_Policy_And_Playbook"];

            if (drAP_Fraud_Events["Vendor_Collusion"] == DBNull.Value)
                this._Vendor_Collusion = null;
            else
                this._Vendor_Collusion = (string)drAP_Fraud_Events["Vendor_Collusion"];

            if (drAP_Fraud_Events["Vendor_Schemes"] == DBNull.Value)
                this._Vendor_Schemes = null;
            else
                this._Vendor_Schemes = (string)drAP_Fraud_Events["Vendor_Schemes"];

            if (drAP_Fraud_Events["Root_Cause_Other"] == DBNull.Value)
                this._Root_Cause_Other = null;
            else
                this._Root_Cause_Other = (string)drAP_Fraud_Events["Root_Cause_Other"];

            if (drAP_Fraud_Events["Detail_Description_of_Root_Cause"] == DBNull.Value)
                this._Detail_Description_of_Root_Cause = null;
            else
                this._Detail_Description_of_Root_Cause = (string)drAP_Fraud_Events["Detail_Description_of_Root_Cause"];

            if (drAP_Fraud_Events["Change_a_Control"] == DBNull.Value)
                this._Change_a_Control = null;
            else
                this._Change_a_Control = (string)drAP_Fraud_Events["Change_a_Control"];

            if (drAP_Fraud_Events["Current_Systen_Enhancement"] == DBNull.Value)
                this._Current_Systen_Enhancement = null;
            else
                this._Current_Systen_Enhancement = (string)drAP_Fraud_Events["Current_Systen_Enhancement"];

            if (drAP_Fraud_Events["Implementation_Policy"] == DBNull.Value)
                this._Implementation_Policy = null;
            else
                this._Implementation_Policy = (string)drAP_Fraud_Events["Implementation_Policy"];

            if (drAP_Fraud_Events["New_System_Change"] == DBNull.Value)
                this._New_System_Change = null;
            else
                this._New_System_Change = (string)drAP_Fraud_Events["New_System_Change"];

            if (drAP_Fraud_Events["Results_of_Disposition_Plan"] == DBNull.Value)
                this._Results_of_Disposition_Plan = null;
            else
                this._Results_of_Disposition_Plan = (string)drAP_Fraud_Events["Results_of_Disposition_Plan"];

            if (drAP_Fraud_Events["ReTraining"] == DBNull.Value)
                this._ReTraining = null;
            else
                this._ReTraining = (string)drAP_Fraud_Events["ReTraining"];

            if (drAP_Fraud_Events["Training"] == DBNull.Value)
                this._Training = null;
            else
                this._Training = (string)drAP_Fraud_Events["Training"];

            if (drAP_Fraud_Events["CA_Other"] == DBNull.Value)
                this._CA_Other = null;
            else
                this._CA_Other = (string)drAP_Fraud_Events["CA_Other"];

            if (drAP_Fraud_Events["Detail_Description_of_Corrective_Action_andor_Recommendation"] == DBNull.Value)
                this._Detail_Description_of_Corrective_Action_andor_Recommendation = null;
            else
                this._Detail_Description_of_Corrective_Action_andor_Recommendation = (string)drAP_Fraud_Events["Detail_Description_of_Corrective_Action_andor_Recommendation"];

            if (drAP_Fraud_Events["Close_File"] == DBNull.Value)
                this._Close_File = null;
            else
                this._Close_File = (string)drAP_Fraud_Events["Close_File"];

            if (drAP_Fraud_Events["Close_Date"] == DBNull.Value)
                this._Close_Date = null;
            else
                this._Close_Date = (DateTime?)drAP_Fraud_Events["Close_Date"];

            if (drAP_Fraud_Events["Reopen_File"] == DBNull.Value)
                this._Reopen_File = null;
            else
                this._Reopen_File = (string)drAP_Fraud_Events["Reopen_File"];

            if (drAP_Fraud_Events["Reopen_Date"] == DBNull.Value)
                this._Reopen_Date = null;
            else
                this._Reopen_Date = (DateTime?)drAP_Fraud_Events["Reopen_Date"];

            if (drAP_Fraud_Events["Comments"] == DBNull.Value)
                this._Comments = null;
            else
                this._Comments = (string)drAP_Fraud_Events["Comments"];

            if (drAP_Fraud_Events["Updated_By"] == DBNull.Value)
                this._Updated_By = null;
            else
                this._Updated_By = (string)drAP_Fraud_Events["Updated_By"];

            if (drAP_Fraud_Events["Update_Date"] == DBNull.Value)
                this._Update_Date = null;
            else
                this._Update_Date = (DateTime?)drAP_Fraud_Events["Update_Date"];
            
            if (drAP_Fraud_Events["BT_Security_Assignment"] == DBNull.Value)
                this._BT_Security_Assignment = null;
            else
                this._BT_Security_Assignment = (string)drAP_Fraud_Events["BT_Security_Assignment"];
            
            if (drAP_Fraud_Events["BT_Security_Associate_Contacted"] == DBNull.Value)
                this._BT_Security_Associate_Contacted = null;
            else
                this._BT_Security_Associate_Contacted = (string)drAP_Fraud_Events["BT_Security_Associate_Contacted"];

            if (drAP_Fraud_Events["Date_BT_Security_Assigned"] == DBNull.Value)
                this._Date_BT_Security_Assigned = null;
            else
                this._Date_BT_Security_Assigned = (DateTime?)drAP_Fraud_Events["Date_BT_Security_Assigned"];

            if (drAP_Fraud_Events["Other_Assignment"] == DBNull.Value)
                this._Other_Assignment = null;
            else
                this._Other_Assignment = (string)drAP_Fraud_Events["Other_Assignment"];

            if (drAP_Fraud_Events["Other_Associate_Contacted"] == DBNull.Value)
                this._Other_Associate_Contacted = null;
            else
                this._Other_Associate_Contacted = (string)drAP_Fraud_Events["Other_Associate_Contacted"];

            if (drAP_Fraud_Events["Date_Other_Assigned"] == DBNull.Value)
                this._Date_Other_Assigned = null;
            else
                this._Date_Other_Assigned = (DateTime?)drAP_Fraud_Events["Date_Other_Assigned"];
            

        }

        #endregion

        /// <summary>
        /// Inserts a record into the AP_Fraud_Events table.
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("AP_Fraud_EventsInsert");


            db.AddInParameter(dbCommand, "FK_LU_Location", DbType.Decimal, this._FK_LU_Location);

            if (string.IsNullOrEmpty(this._Fraud_Number))
                db.AddInParameter(dbCommand, "Fraud_Number", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Fraud_Number", DbType.String, this._Fraud_Number);

            db.AddInParameter(dbCommand, "Exposure_Period_Begin_Date", DbType.DateTime, this._Exposure_Period_Begin_Date);

            db.AddInParameter(dbCommand, "Exposure_Period_End_Date", DbType.DateTime, this._Exposure_Period_End_Date);

            if (string.IsNullOrEmpty(this._Reported_To))
                db.AddInParameter(dbCommand, "Reported_To", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Reported_To", DbType.String, this._Reported_To);

            db.AddInParameter(dbCommand, "Reported_Date", DbType.DateTime, this._Reported_Date);

            if (string.IsNullOrEmpty(this._Description_of_Event))
                db.AddInParameter(dbCommand, "Description_of_Event", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Description_of_Event", DbType.String, this._Description_of_Event);

            if (string.IsNullOrEmpty(this._Customer_Relations_Hotline))
                db.AddInParameter(dbCommand, "Customer_Relations_Hotline", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Customer_Relations_Hotline", DbType.String, this._Customer_Relations_Hotline);

            if (string.IsNullOrEmpty(this._Discovered_Fraud_through_Audits))
                db.AddInParameter(dbCommand, "Discovered_Fraud_through_Audits", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Discovered_Fraud_through_Audits", DbType.String, this._Discovered_Fraud_through_Audits);

            if (string.IsNullOrEmpty(this._Internal_Audit_Control_Breakdown_leading_to_Fraud_Event))
                db.AddInParameter(dbCommand, "Internal_Audit_Control_Breakdown_leading_to_Fraud_Event", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Internal_Audit_Control_Breakdown_leading_to_Fraud_Event", DbType.String, this._Internal_Audit_Control_Breakdown_leading_to_Fraud_Event);

            if (string.IsNullOrEmpty(this._Retail_Lending))
                db.AddInParameter(dbCommand, "Retail_Lending", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Retail_Lending", DbType.String, this._Retail_Lending);

            if (string.IsNullOrEmpty(this._Sonic_Associates_1800_Hotline))
                db.AddInParameter(dbCommand, "Sonic_Associates_1800_Hotline", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Sonic_Associates_1800_Hotline", DbType.String, this._Sonic_Associates_1800_Hotline);

            if (string.IsNullOrEmpty(this._Store_Red_Flags))
                db.AddInParameter(dbCommand, "Store_Red_Flags", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Store_Red_Flags", DbType.String, this._Store_Red_Flags);

            if (string.IsNullOrEmpty(this._Notification_Other))
                db.AddInParameter(dbCommand, "Notification_Other", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Notification_Other", DbType.String, this._Notification_Other);

            if (string.IsNullOrEmpty(this._Other_Notification_Description))
                db.AddInParameter(dbCommand, "Other_Notification_Description", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Other_Notification_Description", DbType.String, this._Other_Notification_Description);

            if (string.IsNullOrEmpty(this._Internal_Review_Purification_Notes))
                db.AddInParameter(dbCommand, "Internal_Review_Purification_Notes", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Internal_Review_Purification_Notes", DbType.String, this._Internal_Review_Purification_Notes);

            db.AddInParameter(dbCommand, "Fraud_Date", DbType.DateTime, this._Fraud_Date);

            if (string.IsNullOrEmpty(this._HR_Assignment))
                db.AddInParameter(dbCommand, "HR_Assignment", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "HR_Assignment", DbType.String, this._HR_Assignment);

            if (string.IsNullOrEmpty(this._HR_Associate_Contacted))
                db.AddInParameter(dbCommand, "HR_Associate_Contacted", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "HR_Associate_Contacted", DbType.String, this._HR_Associate_Contacted);

            db.AddInParameter(dbCommand, "Date_HR_Assigned", DbType.DateTime, this._Date_HR_Assigned);

            if (string.IsNullOrEmpty(this._Internal_Audit_Assignment))
                db.AddInParameter(dbCommand, "Internal_Audit_Assignment", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Internal_Audit_Assignment", DbType.String, this._Internal_Audit_Assignment);

            if (string.IsNullOrEmpty(this._Internal_Audit_Associate_Contacted))
                db.AddInParameter(dbCommand, "Internal_Audit_Associate_Contacted", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Internal_Audit_Associate_Contacted", DbType.String, this._Internal_Audit_Associate_Contacted);

            db.AddInParameter(dbCommand, "Date_Internal_Audit_Assigned", DbType.DateTime, this._Date_Internal_Audit_Assigned);

            if (string.IsNullOrEmpty(this._Store_Controller_Assignment))
                db.AddInParameter(dbCommand, "Store_Controller_Assignment", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Store_Controller_Assignment", DbType.String, this._Store_Controller_Assignment);

            if (string.IsNullOrEmpty(this._Store_Controller_Associate_Contacted))
                db.AddInParameter(dbCommand, "Store_Controller_Associate_Contacted", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Store_Controller_Associate_Contacted", DbType.String, this._Store_Controller_Associate_Contacted);

            db.AddInParameter(dbCommand, "Date_Store_Controller_Assigned", DbType.DateTime, this._Date_Store_Controller_Assigned);

            if (string.IsNullOrEmpty(this._Regional_Controller_Assignment))
                db.AddInParameter(dbCommand, "Regional_Controller_Assignment", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Regional_Controller_Assignment", DbType.String, this._Regional_Controller_Assignment);

            if (string.IsNullOrEmpty(this._Regional_Controller_Associate_Contacted))
                db.AddInParameter(dbCommand, "Regional_Controller_Associate_Contacted", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Regional_Controller_Associate_Contacted", DbType.String, this._Regional_Controller_Associate_Contacted);

            db.AddInParameter(dbCommand, "Date_Regional_Controller_Assigned", DbType.DateTime, this._Date_Regional_Controller_Assigned);

            if (string.IsNullOrEmpty(this._Legal_Department_Assignment))
                db.AddInParameter(dbCommand, "Legal_Department_Assignment", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Legal_Department_Assignment", DbType.String, this._Legal_Department_Assignment);

            if (string.IsNullOrEmpty(this._Legal_Department_Associate_Contacted))
                db.AddInParameter(dbCommand, "Legal_Department_Associate_Contacted", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Legal_Department_Associate_Contacted", DbType.String, this._Legal_Department_Associate_Contacted);

            db.AddInParameter(dbCommand, "Date_Legal_Department_Assigned", DbType.DateTime, this._Date_Legal_Department_Assigned);

            if (string.IsNullOrEmpty(this._Outside_Legal_Assignment))
                db.AddInParameter(dbCommand, "Outside_Legal_Assignment", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Outside_Legal_Assignment", DbType.String, this._Outside_Legal_Assignment);

            if (string.IsNullOrEmpty(this._Outside_Legal_Associate_Contacted))
                db.AddInParameter(dbCommand, "Outside_Legal_Associate_Contacted", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Outside_Legal_Associate_Contacted", DbType.String, this._Outside_Legal_Associate_Contacted);

            db.AddInParameter(dbCommand, "Date_Outside_Legal_Assigned", DbType.DateTime, this._Date_Outside_Legal_Assigned);

            if (string.IsNullOrEmpty(this._Operations_Assignment))
                db.AddInParameter(dbCommand, "Operations_Assignment", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Operations_Assignment", DbType.String, this._Operations_Assignment);

            if (string.IsNullOrEmpty(this._Operations_Associate_Contacted))
                db.AddInParameter(dbCommand, "Operations_Associate_Contacted", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Operations_Associate_Contacted", DbType.String, this._Operations_Associate_Contacted);

            db.AddInParameter(dbCommand, "Date_Operations_Assigned", DbType.DateTime, this._Date_Operations_Assigned);

            if (string.IsNullOrEmpty(this._Retail_Lending_Assignment))
                db.AddInParameter(dbCommand, "Retail_Lending_Assignment", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Retail_Lending_Assignment", DbType.String, this._Retail_Lending_Assignment);

            if (string.IsNullOrEmpty(this._Retail_Lending_Associate_Contacted))
                db.AddInParameter(dbCommand, "Retail_Lending_Associate_Contacted", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Retail_Lending_Associate_Contacted", DbType.String, this._Retail_Lending_Associate_Contacted);

            db.AddInParameter(dbCommand, "Date_Retail_Lending_Assigned", DbType.DateTime, this._Date_Retail_Lending_Assigned);

            if (string.IsNullOrEmpty(this._OnSite_Findings))
                db.AddInParameter(dbCommand, "OnSite_Findings", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "OnSite_Findings", DbType.String, this._OnSite_Findings);

            if (string.IsNullOrEmpty(this._TLO_Findings))
                db.AddInParameter(dbCommand, "TLO_Findings", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "TLO_Findings", DbType.String, this._TLO_Findings);

            if (string.IsNullOrEmpty(this._Statements_Obtained))
                db.AddInParameter(dbCommand, "Statements_Obtained", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Statements_Obtained", DbType.String, this._Statements_Obtained);

            if (string.IsNullOrEmpty(this._Fact_Finding_andor_Due_Diligence))
                db.AddInParameter(dbCommand, "Fact_Finding_andor_Due_Diligence", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Fact_Finding_andor_Due_Diligence", DbType.String, this._Fact_Finding_andor_Due_Diligence);

            if (string.IsNullOrEmpty(this._Law_Enforcement_Involvement))
                db.AddInParameter(dbCommand, "Law_Enforcement_Involvement", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Law_Enforcement_Involvement", DbType.String, this._Law_Enforcement_Involvement);

            if (string.IsNullOrEmpty(this._Civil_Actrion))
                db.AddInParameter(dbCommand, "Civil_Actrion", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Civil_Actrion", DbType.String, this._Civil_Actrion);

            if (string.IsNullOrEmpty(this._Crimimal_Action))
                db.AddInParameter(dbCommand, "Crimimal_Action", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Crimimal_Action", DbType.String, this._Crimimal_Action);

            if (string.IsNullOrEmpty(this._Further_Investigation))
                db.AddInParameter(dbCommand, "Further_Investigation", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Further_Investigation", DbType.String, this._Further_Investigation);

            if (string.IsNullOrEmpty(this._ACC_Suspension))
                db.AddInParameter(dbCommand, "ACC_Suspension", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "ACC_Suspension", DbType.String, this._ACC_Suspension);

            if (string.IsNullOrEmpty(this._ACC_Termination))
                db.AddInParameter(dbCommand, "ACC_Termination", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "ACC_Termination", DbType.String, this._ACC_Termination);

            if (string.IsNullOrEmpty(this._ACC_Written))
                db.AddInParameter(dbCommand, "ACC_Written", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "ACC_Written", DbType.String, this._ACC_Written);

            if (string.IsNullOrEmpty(this._ACC_Verbal))
                db.AddInParameter(dbCommand, "ACC_Verbal", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "ACC_Verbal", DbType.String, this._ACC_Verbal);

            if (string.IsNullOrEmpty(this._Communication_Strategy))
                db.AddInParameter(dbCommand, "Communication_Strategy", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Communication_Strategy", DbType.String, this._Communication_Strategy);

            if (string.IsNullOrEmpty(this._Disposition_Game_Plan_Other))
                db.AddInParameter(dbCommand, "Disposition_Game_Plan_Other", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Disposition_Game_Plan_Other", DbType.String, this._Disposition_Game_Plan_Other);

            if (string.IsNullOrEmpty(this._Detailed_Deisposition_Game_Plan_Description))
                db.AddInParameter(dbCommand, "Detailed_Deisposition_Game_Plan_Description", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Detailed_Deisposition_Game_Plan_Description", DbType.String, this._Detailed_Deisposition_Game_Plan_Description);

            if (string.IsNullOrEmpty(this._Accounting_Gaps_and_Controls))
                db.AddInParameter(dbCommand, "Accounting_Gaps_and_Controls", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Accounting_Gaps_and_Controls", DbType.String, this._Accounting_Gaps_and_Controls);

            if (string.IsNullOrEmpty(this._Aging_MFR_Incentives))
                db.AddInParameter(dbCommand, "Aging_MFR_Incentives", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Aging_MFR_Incentives", DbType.String, this._Aging_MFR_Incentives);

            if (string.IsNullOrEmpty(this._Aging_Warranties))
                db.AddInParameter(dbCommand, "Aging_Warranties", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Aging_Warranties", DbType.String, this._Aging_Warranties);

            if (string.IsNullOrEmpty(this._Account_Payable_Schemes))
                db.AddInParameter(dbCommand, "Account_Payable_Schemes", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Account_Payable_Schemes", DbType.String, this._Account_Payable_Schemes);

            if (string.IsNullOrEmpty(this._Associate_Collusion))
                db.AddInParameter(dbCommand, "Associate_Collusion", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Associate_Collusion", DbType.String, this._Associate_Collusion);

            if (string.IsNullOrEmpty(this._Billing_Schemes))
                db.AddInParameter(dbCommand, "Billing_Schemes", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Billing_Schemes", DbType.String, this._Billing_Schemes);

            if (string.IsNullOrEmpty(this._External_Scam))
                db.AddInParameter(dbCommand, "External_Scam", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "External_Scam", DbType.String, this._External_Scam);

            if (string.IsNullOrEmpty(this._Improper_Disclosure_to_Customer_F_and_I_Product_Purchase))
                db.AddInParameter(dbCommand, "Improper_Disclosure_to_Customer_F_and_I_Product_Purchase", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Improper_Disclosure_to_Customer_F_and_I_Product_Purchase", DbType.String, this._Improper_Disclosure_to_Customer_F_and_I_Product_Purchase);

            if (string.IsNullOrEmpty(this._Improper_Disclosure_to_Customer_Vehicle_Purchase))
                db.AddInParameter(dbCommand, "Improper_Disclosure_to_Customer_Vehicle_Purchase", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Improper_Disclosure_to_Customer_Vehicle_Purchase", DbType.String, this._Improper_Disclosure_to_Customer_Vehicle_Purchase);

            if (string.IsNullOrEmpty(this._Inventory_Schemes))
                db.AddInParameter(dbCommand, "Inventory_Schemes", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Inventory_Schemes", DbType.String, this._Inventory_Schemes);

            if (string.IsNullOrEmpty(this._Operations_No_Adherence_to_Sonic_Policy_And_Playbook))
                db.AddInParameter(dbCommand, "Operations_No_Adherence_to_Sonic_Policy_And_Playbook", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Operations_No_Adherence_to_Sonic_Policy_And_Playbook", DbType.String, this._Operations_No_Adherence_to_Sonic_Policy_And_Playbook);

            if (string.IsNullOrEmpty(this._Vendor_Collusion))
                db.AddInParameter(dbCommand, "Vendor_Collusion", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Vendor_Collusion", DbType.String, this._Vendor_Collusion);

            if (string.IsNullOrEmpty(this._Vendor_Schemes))
                db.AddInParameter(dbCommand, "Vendor_Schemes", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Vendor_Schemes", DbType.String, this._Vendor_Schemes);

            if (string.IsNullOrEmpty(this._Root_Cause_Other))
                db.AddInParameter(dbCommand, "Root_Cause_Other", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Root_Cause_Other", DbType.String, this._Root_Cause_Other);

            if (string.IsNullOrEmpty(this._Detail_Description_of_Root_Cause))
                db.AddInParameter(dbCommand, "Detail_Description_of_Root_Cause", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Detail_Description_of_Root_Cause", DbType.String, this._Detail_Description_of_Root_Cause);

            if (string.IsNullOrEmpty(this._Change_a_Control))
                db.AddInParameter(dbCommand, "Change_a_Control", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Change_a_Control", DbType.String, this._Change_a_Control);

            if (string.IsNullOrEmpty(this._Current_Systen_Enhancement))
                db.AddInParameter(dbCommand, "Current_Systen_Enhancement", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Current_Systen_Enhancement", DbType.String, this._Current_Systen_Enhancement);

            if (string.IsNullOrEmpty(this._Implementation_Policy))
                db.AddInParameter(dbCommand, "Implementation_Policy", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Implementation_Policy", DbType.String, this._Implementation_Policy);

            if (string.IsNullOrEmpty(this._New_System_Change))
                db.AddInParameter(dbCommand, "New_System_Change", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "New_System_Change", DbType.String, this._New_System_Change);

            if (string.IsNullOrEmpty(this._Results_of_Disposition_Plan))
                db.AddInParameter(dbCommand, "Results_of_Disposition_Plan", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Results_of_Disposition_Plan", DbType.String, this._Results_of_Disposition_Plan);

            if (string.IsNullOrEmpty(this._ReTraining))
                db.AddInParameter(dbCommand, "ReTraining", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "ReTraining", DbType.String, this._ReTraining);

            if (string.IsNullOrEmpty(this._Training))
                db.AddInParameter(dbCommand, "Training", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Training", DbType.String, this._Training);

            if (string.IsNullOrEmpty(this._CA_Other))
                db.AddInParameter(dbCommand, "CA_Other", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "CA_Other", DbType.String, this._CA_Other);

            if (string.IsNullOrEmpty(this._Detail_Description_of_Corrective_Action_andor_Recommendation))
                db.AddInParameter(dbCommand, "Detail_Description_of_Corrective_Action_andor_Recommendation", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Detail_Description_of_Corrective_Action_andor_Recommendation", DbType.String, this._Detail_Description_of_Corrective_Action_andor_Recommendation);

            if (string.IsNullOrEmpty(this._Close_File))
                db.AddInParameter(dbCommand, "Close_File", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Close_File", DbType.String, this._Close_File);

            db.AddInParameter(dbCommand, "Close_Date", DbType.DateTime, this._Close_Date);

            if (string.IsNullOrEmpty(this._Reopen_File))
                db.AddInParameter(dbCommand, "Reopen_File", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Reopen_File", DbType.String, this._Reopen_File);

            db.AddInParameter(dbCommand, "Reopen_Date", DbType.DateTime, this._Reopen_Date);

            if (string.IsNullOrEmpty(this._Comments))
                db.AddInParameter(dbCommand, "Comments", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Comments", DbType.String, this._Comments);

            if (string.IsNullOrEmpty(this._Updated_By))
                db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);

            db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);

            if (string.IsNullOrEmpty(this._BT_Security_Assignment))
                db.AddInParameter(dbCommand, "BT_Security_Assignment", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "BT_Security_Assignment", DbType.String, this._BT_Security_Assignment);

            if (string.IsNullOrEmpty(this._BT_Security_Associate_Contacted))
                db.AddInParameter(dbCommand, "BT_Security_Associate_Contacted", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "BT_Security_Associate_Contacted", DbType.String, this._BT_Security_Associate_Contacted);

            db.AddInParameter(dbCommand, "Date_BT_Security_Assigned", DbType.DateTime, this._Date_BT_Security_Assigned);

            if (string.IsNullOrEmpty(this._Other_Assignment))
                db.AddInParameter(dbCommand, "Other_Assignment", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Other_Assignment", DbType.String, this._Other_Assignment);

            if (string.IsNullOrEmpty(this._Other_Associate_Contacted))
                db.AddInParameter(dbCommand, "Other_Associate_Contacted", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Other_Associate_Contacted", DbType.String, this._Other_Associate_Contacted);

            db.AddInParameter(dbCommand, "Date_Other_Assigned", DbType.DateTime, this._Date_Other_Assigned);

            // Execute the query and return the new identity value
            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
        }

        /// <summary>
        /// Selects a single record from the AP_Fraud_Events table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        private DataSet SelectByPK(decimal pK_AP_Fraud_Events)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("AP_Fraud_EventsSelectByPK");

            db.AddInParameter(dbCommand, "PK_AP_Fraud_Events", DbType.Decimal, pK_AP_Fraud_Events);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Get PK_AP_FraudEvent Id From Fk_Location_Id
        /// </summary>
        /// <param name="fK_LU_Location"></param>
        /// <returns></returns>
        public static decimal SelectPKByFKLoc(decimal fK_LU_Location)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("AP_FraudEventSelectPKByFKLoc");
            db.AddInParameter(dbCommand, "FK_LU_Location_ID", DbType.Int32, fK_LU_Location);
            db.AddOutParameter(dbCommand, "PK_AP_Fraud_Events", DbType.Int32, 1);
            db.ExecuteNonQuery(dbCommand);

            return Convert.ToInt32(dbCommand.Parameters["@PK_AP_Fraud_Events"].Value);
        }

        /// <summary>
        /// Selects all records from the AP_Fraud_Events table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("AP_Fraud_EventsSelectAll");

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Updates a record in the AP_Fraud_Events table.
        /// </summary>
        public void Update()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("AP_Fraud_EventsUpdate");


            db.AddInParameter(dbCommand, "PK_AP_Fraud_Events", DbType.Decimal, this._PK_AP_Fraud_Events);

            db.AddInParameter(dbCommand, "FK_LU_Location", DbType.Decimal, this._FK_LU_Location);

            if (string.IsNullOrEmpty(this._Fraud_Number))
                db.AddInParameter(dbCommand, "Fraud_Number", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Fraud_Number", DbType.String, this._Fraud_Number);

            db.AddInParameter(dbCommand, "Exposure_Period_Begin_Date", DbType.DateTime, this._Exposure_Period_Begin_Date);

            db.AddInParameter(dbCommand, "Exposure_Period_End_Date", DbType.DateTime, this._Exposure_Period_End_Date);

            if (string.IsNullOrEmpty(this._Reported_To))
                db.AddInParameter(dbCommand, "Reported_To", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Reported_To", DbType.String, this._Reported_To);

            db.AddInParameter(dbCommand, "Reported_Date", DbType.DateTime, this._Reported_Date);

            if (string.IsNullOrEmpty(this._Description_of_Event))
                db.AddInParameter(dbCommand, "Description_of_Event", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Description_of_Event", DbType.String, this._Description_of_Event);

            if (string.IsNullOrEmpty(this._Customer_Relations_Hotline))
                db.AddInParameter(dbCommand, "Customer_Relations_Hotline", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Customer_Relations_Hotline", DbType.String, this._Customer_Relations_Hotline);

            if (string.IsNullOrEmpty(this._Discovered_Fraud_through_Audits))
                db.AddInParameter(dbCommand, "Discovered_Fraud_through_Audits", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Discovered_Fraud_through_Audits", DbType.String, this._Discovered_Fraud_through_Audits);

            if (string.IsNullOrEmpty(this._Internal_Audit_Control_Breakdown_leading_to_Fraud_Event))
                db.AddInParameter(dbCommand, "Internal_Audit_Control_Breakdown_leading_to_Fraud_Event", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Internal_Audit_Control_Breakdown_leading_to_Fraud_Event", DbType.String, this._Internal_Audit_Control_Breakdown_leading_to_Fraud_Event);

            if (string.IsNullOrEmpty(this._Retail_Lending))
                db.AddInParameter(dbCommand, "Retail_Lending", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Retail_Lending", DbType.String, this._Retail_Lending);

            if (string.IsNullOrEmpty(this._Sonic_Associates_1800_Hotline))
                db.AddInParameter(dbCommand, "Sonic_Associates_1800_Hotline", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Sonic_Associates_1800_Hotline", DbType.String, this._Sonic_Associates_1800_Hotline);

            if (string.IsNullOrEmpty(this._Store_Red_Flags))
                db.AddInParameter(dbCommand, "Store_Red_Flags", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Store_Red_Flags", DbType.String, this._Store_Red_Flags);

            if (string.IsNullOrEmpty(this._Notification_Other))
                db.AddInParameter(dbCommand, "Notification_Other", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Notification_Other", DbType.String, this._Notification_Other);

            if (string.IsNullOrEmpty(this._Other_Notification_Description))
                db.AddInParameter(dbCommand, "Other_Notification_Description", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Other_Notification_Description", DbType.String, this._Other_Notification_Description);

            if (string.IsNullOrEmpty(this._Internal_Review_Purification_Notes))
                db.AddInParameter(dbCommand, "Internal_Review_Purification_Notes", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Internal_Review_Purification_Notes", DbType.String, this._Internal_Review_Purification_Notes);

            db.AddInParameter(dbCommand, "Fraud_Date", DbType.DateTime, this._Fraud_Date);

            if (string.IsNullOrEmpty(this._HR_Assignment))
                db.AddInParameter(dbCommand, "HR_Assignment", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "HR_Assignment", DbType.String, this._HR_Assignment);

            if (string.IsNullOrEmpty(this._HR_Associate_Contacted))
                db.AddInParameter(dbCommand, "HR_Associate_Contacted", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "HR_Associate_Contacted", DbType.String, this._HR_Associate_Contacted);

            db.AddInParameter(dbCommand, "Date_HR_Assigned", DbType.DateTime, this._Date_HR_Assigned);

            if (string.IsNullOrEmpty(this._Internal_Audit_Assignment))
                db.AddInParameter(dbCommand, "Internal_Audit_Assignment", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Internal_Audit_Assignment", DbType.String, this._Internal_Audit_Assignment);

            if (string.IsNullOrEmpty(this._Internal_Audit_Associate_Contacted))
                db.AddInParameter(dbCommand, "Internal_Audit_Associate_Contacted", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Internal_Audit_Associate_Contacted", DbType.String, this._Internal_Audit_Associate_Contacted);

            db.AddInParameter(dbCommand, "Date_Internal_Audit_Assigned", DbType.DateTime, this._Date_Internal_Audit_Assigned);

            if (string.IsNullOrEmpty(this._Store_Controller_Assignment))
                db.AddInParameter(dbCommand, "Store_Controller_Assignment", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Store_Controller_Assignment", DbType.String, this._Store_Controller_Assignment);

            if (string.IsNullOrEmpty(this._Store_Controller_Associate_Contacted))
                db.AddInParameter(dbCommand, "Store_Controller_Associate_Contacted", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Store_Controller_Associate_Contacted", DbType.String, this._Store_Controller_Associate_Contacted);

            db.AddInParameter(dbCommand, "Date_Store_Controller_Assigned", DbType.DateTime, this._Date_Store_Controller_Assigned);

            if (string.IsNullOrEmpty(this._Regional_Controller_Assignment))
                db.AddInParameter(dbCommand, "Regional_Controller_Assignment", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Regional_Controller_Assignment", DbType.String, this._Regional_Controller_Assignment);

            if (string.IsNullOrEmpty(this._Regional_Controller_Associate_Contacted))
                db.AddInParameter(dbCommand, "Regional_Controller_Associate_Contacted", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Regional_Controller_Associate_Contacted", DbType.String, this._Regional_Controller_Associate_Contacted);

            db.AddInParameter(dbCommand, "Date_Regional_Controller_Assigned", DbType.DateTime, this._Date_Regional_Controller_Assigned);

            if (string.IsNullOrEmpty(this._Legal_Department_Assignment))
                db.AddInParameter(dbCommand, "Legal_Department_Assignment", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Legal_Department_Assignment", DbType.String, this._Legal_Department_Assignment);

            if (string.IsNullOrEmpty(this._Legal_Department_Associate_Contacted))
                db.AddInParameter(dbCommand, "Legal_Department_Associate_Contacted", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Legal_Department_Associate_Contacted", DbType.String, this._Legal_Department_Associate_Contacted);

            db.AddInParameter(dbCommand, "Date_Legal_Department_Assigned", DbType.DateTime, this._Date_Legal_Department_Assigned);

            if (string.IsNullOrEmpty(this._Outside_Legal_Assignment))
                db.AddInParameter(dbCommand, "Outside_Legal_Assignment", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Outside_Legal_Assignment", DbType.String, this._Outside_Legal_Assignment);

            if (string.IsNullOrEmpty(this._Outside_Legal_Associate_Contacted))
                db.AddInParameter(dbCommand, "Outside_Legal_Associate_Contacted", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Outside_Legal_Associate_Contacted", DbType.String, this._Outside_Legal_Associate_Contacted);

            db.AddInParameter(dbCommand, "Date_Outside_Legal_Assigned", DbType.DateTime, this._Date_Outside_Legal_Assigned);

            if (string.IsNullOrEmpty(this._Operations_Assignment))
                db.AddInParameter(dbCommand, "Operations_Assignment", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Operations_Assignment", DbType.String, this._Operations_Assignment);

            if (string.IsNullOrEmpty(this._Operations_Associate_Contacted))
                db.AddInParameter(dbCommand, "Operations_Associate_Contacted", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Operations_Associate_Contacted", DbType.String, this._Operations_Associate_Contacted);

            db.AddInParameter(dbCommand, "Date_Operations_Assigned", DbType.DateTime, this._Date_Operations_Assigned);

            if (string.IsNullOrEmpty(this._Retail_Lending_Assignment))
                db.AddInParameter(dbCommand, "Retail_Lending_Assignment", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Retail_Lending_Assignment", DbType.String, this._Retail_Lending_Assignment);

            if (string.IsNullOrEmpty(this._Retail_Lending_Associate_Contacted))
                db.AddInParameter(dbCommand, "Retail_Lending_Associate_Contacted", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Retail_Lending_Associate_Contacted", DbType.String, this._Retail_Lending_Associate_Contacted);

            db.AddInParameter(dbCommand, "Date_Retail_Lending_Assigned", DbType.DateTime, this._Date_Retail_Lending_Assigned);

            if (string.IsNullOrEmpty(this._OnSite_Findings))
                db.AddInParameter(dbCommand, "OnSite_Findings", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "OnSite_Findings", DbType.String, this._OnSite_Findings);

            if (string.IsNullOrEmpty(this._TLO_Findings))
                db.AddInParameter(dbCommand, "TLO_Findings", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "TLO_Findings", DbType.String, this._TLO_Findings);

            if (string.IsNullOrEmpty(this._Statements_Obtained))
                db.AddInParameter(dbCommand, "Statements_Obtained", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Statements_Obtained", DbType.String, this._Statements_Obtained);

            if (string.IsNullOrEmpty(this._Fact_Finding_andor_Due_Diligence))
                db.AddInParameter(dbCommand, "Fact_Finding_andor_Due_Diligence", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Fact_Finding_andor_Due_Diligence", DbType.String, this._Fact_Finding_andor_Due_Diligence);

            if (string.IsNullOrEmpty(this._Law_Enforcement_Involvement))
                db.AddInParameter(dbCommand, "Law_Enforcement_Involvement", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Law_Enforcement_Involvement", DbType.String, this._Law_Enforcement_Involvement);

            if (string.IsNullOrEmpty(this._Civil_Actrion))
                db.AddInParameter(dbCommand, "Civil_Actrion", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Civil_Actrion", DbType.String, this._Civil_Actrion);

            if (string.IsNullOrEmpty(this._Crimimal_Action))
                db.AddInParameter(dbCommand, "Crimimal_Action", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Crimimal_Action", DbType.String, this._Crimimal_Action);

            if (string.IsNullOrEmpty(this._Further_Investigation))
                db.AddInParameter(dbCommand, "Further_Investigation", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Further_Investigation", DbType.String, this._Further_Investigation);

            if (string.IsNullOrEmpty(this._ACC_Suspension))
                db.AddInParameter(dbCommand, "ACC_Suspension", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "ACC_Suspension", DbType.String, this._ACC_Suspension);

            if (string.IsNullOrEmpty(this._ACC_Termination))
                db.AddInParameter(dbCommand, "ACC_Termination", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "ACC_Termination", DbType.String, this._ACC_Termination);

            if (string.IsNullOrEmpty(this._ACC_Written))
                db.AddInParameter(dbCommand, "ACC_Written", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "ACC_Written", DbType.String, this._ACC_Written);

            if (string.IsNullOrEmpty(this._ACC_Verbal))
                db.AddInParameter(dbCommand, "ACC_Verbal", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "ACC_Verbal", DbType.String, this._ACC_Verbal);

            if (string.IsNullOrEmpty(this._Communication_Strategy))
                db.AddInParameter(dbCommand, "Communication_Strategy", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Communication_Strategy", DbType.String, this._Communication_Strategy);

            if (string.IsNullOrEmpty(this._Disposition_Game_Plan_Other))
                db.AddInParameter(dbCommand, "Disposition_Game_Plan_Other", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Disposition_Game_Plan_Other", DbType.String, this._Disposition_Game_Plan_Other);

            if (string.IsNullOrEmpty(this._Detailed_Deisposition_Game_Plan_Description))
                db.AddInParameter(dbCommand, "Detailed_Deisposition_Game_Plan_Description", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Detailed_Deisposition_Game_Plan_Description", DbType.String, this._Detailed_Deisposition_Game_Plan_Description);

            if (string.IsNullOrEmpty(this._Accounting_Gaps_and_Controls))
                db.AddInParameter(dbCommand, "Accounting_Gaps_and_Controls", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Accounting_Gaps_and_Controls", DbType.String, this._Accounting_Gaps_and_Controls);

            if (string.IsNullOrEmpty(this._Aging_MFR_Incentives))
                db.AddInParameter(dbCommand, "Aging_MFR_Incentives", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Aging_MFR_Incentives", DbType.String, this._Aging_MFR_Incentives);

            if (string.IsNullOrEmpty(this._Aging_Warranties))
                db.AddInParameter(dbCommand, "Aging_Warranties", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Aging_Warranties", DbType.String, this._Aging_Warranties);

            if (string.IsNullOrEmpty(this._Account_Payable_Schemes))
                db.AddInParameter(dbCommand, "Account_Payable_Schemes", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Account_Payable_Schemes", DbType.String, this._Account_Payable_Schemes);

            if (string.IsNullOrEmpty(this._Associate_Collusion))
                db.AddInParameter(dbCommand, "Associate_Collusion", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Associate_Collusion", DbType.String, this._Associate_Collusion);

            if (string.IsNullOrEmpty(this._Billing_Schemes))
                db.AddInParameter(dbCommand, "Billing_Schemes", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Billing_Schemes", DbType.String, this._Billing_Schemes);

            if (string.IsNullOrEmpty(this._External_Scam))
                db.AddInParameter(dbCommand, "External_Scam", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "External_Scam", DbType.String, this._External_Scam);

            if (string.IsNullOrEmpty(this._Improper_Disclosure_to_Customer_F_and_I_Product_Purchase))
                db.AddInParameter(dbCommand, "Improper_Disclosure_to_Customer_F_and_I_Product_Purchase", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Improper_Disclosure_to_Customer_F_and_I_Product_Purchase", DbType.String, this._Improper_Disclosure_to_Customer_F_and_I_Product_Purchase);

            if (string.IsNullOrEmpty(this._Improper_Disclosure_to_Customer_Vehicle_Purchase))
                db.AddInParameter(dbCommand, "Improper_Disclosure_to_Customer_Vehicle_Purchase", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Improper_Disclosure_to_Customer_Vehicle_Purchase", DbType.String, this._Improper_Disclosure_to_Customer_Vehicle_Purchase);

            if (string.IsNullOrEmpty(this._Inventory_Schemes))
                db.AddInParameter(dbCommand, "Inventory_Schemes", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Inventory_Schemes", DbType.String, this._Inventory_Schemes);

            if (string.IsNullOrEmpty(this._Operations_No_Adherence_to_Sonic_Policy_And_Playbook))
                db.AddInParameter(dbCommand, "Operations_No_Adherence_to_Sonic_Policy_And_Playbook", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Operations_No_Adherence_to_Sonic_Policy_And_Playbook", DbType.String, this._Operations_No_Adherence_to_Sonic_Policy_And_Playbook);

            if (string.IsNullOrEmpty(this._Vendor_Collusion))
                db.AddInParameter(dbCommand, "Vendor_Collusion", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Vendor_Collusion", DbType.String, this._Vendor_Collusion);

            if (string.IsNullOrEmpty(this._Vendor_Schemes))
                db.AddInParameter(dbCommand, "Vendor_Schemes", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Vendor_Schemes", DbType.String, this._Vendor_Schemes);

            if (string.IsNullOrEmpty(this._Root_Cause_Other))
                db.AddInParameter(dbCommand, "Root_Cause_Other", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Root_Cause_Other", DbType.String, this._Root_Cause_Other);

            if (string.IsNullOrEmpty(this._Detail_Description_of_Root_Cause))
                db.AddInParameter(dbCommand, "Detail_Description_of_Root_Cause", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Detail_Description_of_Root_Cause", DbType.String, this._Detail_Description_of_Root_Cause);

            if (string.IsNullOrEmpty(this._Change_a_Control))
                db.AddInParameter(dbCommand, "Change_a_Control", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Change_a_Control", DbType.String, this._Change_a_Control);

            if (string.IsNullOrEmpty(this._Current_Systen_Enhancement))
                db.AddInParameter(dbCommand, "Current_Systen_Enhancement", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Current_Systen_Enhancement", DbType.String, this._Current_Systen_Enhancement);

            if (string.IsNullOrEmpty(this._Implementation_Policy))
                db.AddInParameter(dbCommand, "Implementation_Policy", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Implementation_Policy", DbType.String, this._Implementation_Policy);

            if (string.IsNullOrEmpty(this._New_System_Change))
                db.AddInParameter(dbCommand, "New_System_Change", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "New_System_Change", DbType.String, this._New_System_Change);

            if (string.IsNullOrEmpty(this._Results_of_Disposition_Plan))
                db.AddInParameter(dbCommand, "Results_of_Disposition_Plan", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Results_of_Disposition_Plan", DbType.String, this._Results_of_Disposition_Plan);

            if (string.IsNullOrEmpty(this._ReTraining))
                db.AddInParameter(dbCommand, "ReTraining", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "ReTraining", DbType.String, this._ReTraining);

            if (string.IsNullOrEmpty(this._Training))
                db.AddInParameter(dbCommand, "Training", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Training", DbType.String, this._Training);

            if (string.IsNullOrEmpty(this._CA_Other))
                db.AddInParameter(dbCommand, "CA_Other", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "CA_Other", DbType.String, this._CA_Other);

            if (string.IsNullOrEmpty(this._Detail_Description_of_Corrective_Action_andor_Recommendation))
                db.AddInParameter(dbCommand, "Detail_Description_of_Corrective_Action_andor_Recommendation", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Detail_Description_of_Corrective_Action_andor_Recommendation", DbType.String, this._Detail_Description_of_Corrective_Action_andor_Recommendation);

            if (string.IsNullOrEmpty(this._Close_File))
                db.AddInParameter(dbCommand, "Close_File", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Close_File", DbType.String, this._Close_File);

            db.AddInParameter(dbCommand, "Close_Date", DbType.DateTime, this._Close_Date);

            if (string.IsNullOrEmpty(this._Reopen_File))
                db.AddInParameter(dbCommand, "Reopen_File", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Reopen_File", DbType.String, this._Reopen_File);

            db.AddInParameter(dbCommand, "Reopen_Date", DbType.DateTime, this._Reopen_Date);

            if (string.IsNullOrEmpty(this._Comments))
                db.AddInParameter(dbCommand, "Comments", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Comments", DbType.String, this._Comments);

            if (string.IsNullOrEmpty(this._Updated_By))
                db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);

            db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);

            if (string.IsNullOrEmpty(this._BT_Security_Assignment))
                db.AddInParameter(dbCommand, "BT_Security_Assignment", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "BT_Security_Assignment", DbType.String, this._BT_Security_Assignment);

            if (string.IsNullOrEmpty(this._BT_Security_Associate_Contacted))
                db.AddInParameter(dbCommand, "BT_Security_Associate_Contacted", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "BT_Security_Associate_Contacted", DbType.String, this._BT_Security_Associate_Contacted);

            db.AddInParameter(dbCommand, "Date_BT_Security_Assigned", DbType.DateTime, this._Date_BT_Security_Assigned);

            if (string.IsNullOrEmpty(this._Other_Assignment))
                db.AddInParameter(dbCommand, "Other_Assignment", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Other_Assignment", DbType.String, this._Other_Assignment);

            if (string.IsNullOrEmpty(this._Other_Associate_Contacted))
                db.AddInParameter(dbCommand, "Other_Associate_Contacted", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Other_Associate_Contacted", DbType.String, this._Other_Associate_Contacted);

            db.AddInParameter(dbCommand, "Date_Other_Assigned", DbType.DateTime, this._Date_Other_Assigned);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Deletes a record from the AP_Fraud_Events table by a composite primary key.
        /// </summary>
        public static void DeleteByPK(decimal pK_AP_Fraud_Events)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("AP_Fraud_EventsDeleteByPK");

            db.AddInParameter(dbCommand, "PK_AP_Fraud_Events", DbType.Decimal, pK_AP_Fraud_Events);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Bind Fraud Event Grid by FK_Location
        /// </summary>
        public static DataSet SelectFraudEventByFkLocation(string FROIsToInclude, decimal fK_Location, string strOrderBy, string strOrder, int intPageNo, int intPageSize)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("SelectFraudEventByFkLocation");
            db.AddInParameter(dbCommand, "FROIsToInclude", DbType.String, FROIsToInclude);
            db.AddInParameter(dbCommand, "FK_Lu_Location", DbType.Decimal, fK_Location);
            db.AddInParameter(dbCommand, "strOrderBy", DbType.String, strOrderBy);
            db.AddInParameter(dbCommand, "strOrder", DbType.String, strOrder);
            db.AddInParameter(dbCommand, "intPageNo", DbType.Int32, intPageNo);
            db.AddInParameter(dbCommand, "intPageSize", DbType.Int32, intPageSize);


            return db.ExecuteDataSet(dbCommand);
        }
    }
}
