#region Includes
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
#endregion
namespace RIMS_Base
{
    [Serializable]
    public abstract class cLiabilityReserveWorkHistory
    {

        #region Constructor
        public cLiabilityReserveWorkHistory()
        {
            this._pk_Liability_Claim_RW_ID = -1;
            this._fk_Liability_Claim = -1;
            this._transaction_Date = DateTime.Now;
            //this._hospital = -1;
            //this._physician = -1;
            //this._radiology = -1;
            //this._pharmacy = -1;
            //this._iME = -1;
            //this._anesthesiologist = -1;
            //this._nursing_Care = -1;
            //this._transportation = -1;
            //this._medical_Report = -1;
            this._medical_Total = -1;
            //this._tTD_Payment = -1;
            //this._tTD_Weeks = -1;
            //this._tTD_Total = -1;
            //this._tPD_Payment = -1;
            //this._tPD_Weeks = -1;
            //this._tPD_Total = -1;
            //this._estimated_Award = -1;
            //this._death_Benefit = -1;
            //this._vocational_Rehab = -1;
            //this._funeral_Expense = -1;
            //this._disability_Total = -1;
            //this._defense_Cost = -1;
            //this._medical_Case_Management = -1;
            //this._surveillance = -1;
            //this._court_Costs = -1;
            //this._depositions = -1;
            //this._expense_Other_1_Description = string.Empty;
            //this._expense_Other_1 = -1;
            //this._expense_Other_2_Description = string.Empty;
            //this._expense_Other_2 = -1;
            //this._expense_Other_3_Description = string.Empty;
            //this._expense_Other_3 = -1;
            this._expenses_Total = -1;
            this._indemnity_Total = -1;
            //this._bill_Review = -1;
            this._updated_By = string.Empty;
            this._update_Date = DateTime.Now;
            //For Claim Info
            this._tblName = string.Empty;
            this._tblFk = 0;
            this._claim_Number = string.Empty;
            this._employee = string.Empty;
            this._last_Name = string.Empty;
            this._first_Name = string.Empty;
            this._middle_Name = string.Empty;
            this._incident_Date = string.Empty;
            this._fk_Employee_Claimant = 0;
            this._Employee_SSN = string.Empty;
            this._outstanding_INDEMNITY = 0;
            this._outstanding_Medical = 0;
            this._outstanding_Expense = 0;
            // Total Variables
            this.Indemnity_Total = -1;
            this.Total = -1;
            this._LTotal = -1;
        }
        #endregion

        #region Private Variables
        private System.Int32 _pk_Liability_Claim_RW_ID;
        private System.Decimal _fk_Liability_Claim;
        private System.DateTime _transaction_Date;
        private System.Decimal _indemnity_Total;
      
        private System.Decimal _medical_Total;
     
        private System.Decimal _expenses_Total;
        //private System.Decimal _bill_Review;
        private System.String _updated_By;
        private System.DateTime _update_Date;
        //For Claim Info
        private System.String _tblName;
        private System.Int32 _tblFk;
        private System.String _claim_Number;
        private System.String _employee;
        private System.String _last_Name;
        private System.String _first_Name;
        private System.String _middle_Name;
        private System.String _incident_Date;
        private System.Int32 _fk_Employee_Claimant;
        private System.String _Employee_SSN;
        private System.Decimal _outstanding_INDEMNITY;
        private System.Decimal _outstanding_Medical;
        private System.Decimal _outstanding_Expense;
        // Fot Totals in grid
        private System.Decimal _Indemnity_Total;
        private System.Decimal _Total;
        private System.Decimal _LTotal;

        private System.Decimal? _fK_Claimant_id;
      
        private System.Decimal? _Fk_ECD_Id;
        private System.DateTime? _date_Of_Loss;
        #endregion

        #region Public Properties
        public System.Decimal LTotal
        {
            get { return _LTotal; }
            set { _LTotal = value; }
        }

        public System.Int32 PK_Liability_Claim_RW_ID
        {
            get { return _pk_Liability_Claim_RW_ID; }
            set { _pk_Liability_Claim_RW_ID = value; }
        }

        public System.Decimal FK_Liability_Claim
        {
            get { return _fk_Liability_Claim; }
            set { _fk_Liability_Claim = value; }
        }

        public System.DateTime Transaction_Date
        {
            get { return _transaction_Date; }
            set { _transaction_Date = value; }
        }

        public System.Decimal Indemnity_Total
        {
            get { return _indemnity_Total; }
            set { _indemnity_Total = value; }
        }

        //public System.Decimal Hospital
        //{
        //    get { return _hospital; }
        //    set { _hospital = value; }
        //}

        //public System.Decimal Physician
        //{
        //    get { return _physician; }
        //    set { _physician = value; }
        //}

        //public System.Decimal Radiology
        //{
        //    get { return _radiology; }
        //    set { _radiology = value; }
        //}

        //public System.Decimal Pharmacy
        //{
        //    get { return _pharmacy; }
        //    set { _pharmacy = value; }
        //}

        //public System.Decimal IME
        //{
        //    get { return _iME; }
        //    set { _iME = value; }
        //}

        //public System.Decimal Anesthesiologist
        //{
        //    get { return _anesthesiologist; }
        //    set { _anesthesiologist = value; }
        //}

        //public System.Decimal Nursing_Care
        //{
        //    get { return _nursing_Care; }
        //    set { _nursing_Care = value; }
        //}

        //public System.Decimal Transportation
        //{
        //    get { return _transportation; }
        //    set { _transportation = value; }
        //}

        //public System.Decimal Medical_Report
        //{
        //    get { return _medical_Report; }
        //    set { _medical_Report = value; }
        //}

        public System.Decimal Medical_Total
        {
            get { return _medical_Total; }
            set { _medical_Total = value; }
        }

      

      

        public System.Decimal Expenses_Total
        {
            get { return _expenses_Total; }
            set { _expenses_Total = value; }
        }

        //public System.Decimal Bill_Review
        //{
        //    get { return _bill_Review; }
        //    set { _bill_Review = value; }
        //}

        public System.String Updated_By
        {
            get { return _updated_By; }
            set { _updated_By = value; }
        }

        public System.DateTime Update_Date
        {
            get { return _update_Date; }
            set { _update_Date = value; }
        }

        //Claim Info
        public System.String TableName
        {
            get { return _tblName; }
            set { _tblName = value; }
        }
        public System.Int32 TableFK
        {
            get { return _tblFk; }
            set { _tblFk = value; }
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
        public System.String LastName
        {
            get { return _last_Name; }
            set { _last_Name = value; }
        }
        public System.String FirstName
        {
            get { return _first_Name; }
            set { _first_Name = value; }
        }
        public System.String MiddleName
        {
            get { return _middle_Name; }
            set { _middle_Name = value; }
        }
        public System.String IncidentDate
        {
            get { return _incident_Date; }
            set { _incident_Date = value; }
        }
        public System.Int32 Employee_Claimant
        {
            get { return _fk_Employee_Claimant; }
            set { _fk_Employee_Claimant = value; }
        }
        public System.String EmployeeSSN
        {
            get { return _Employee_SSN; }
            set { _Employee_SSN = value; }
        }
        //public System.Decimal Indemnity_Total
        //{
        //    get { return _Indemnity_Total; }
        //    set { _Indemnity_Total = value; }
        //}
        public System.Decimal Outstanding_INDEMNITY
        {
            get { return _outstanding_INDEMNITY; }
            set { _outstanding_INDEMNITY = value; }
        }
        public System.Decimal Outstanding_Medical
        {
            get { return _outstanding_Medical; }
            set { _outstanding_Medical = value; }
        }
        public System.Decimal Outstanding_Expense
        {
            get { return _outstanding_Expense; }
            set { _outstanding_Expense = value; }
        }
        public System.Decimal Total
        {
            get { return _Total; }
            set { _Total = value; }
        }

        public System.Decimal? FK_Claimant_id
        {
            get { return _fK_Claimant_id; }
            set { _fK_Claimant_id = value; }
        }

        public System.Decimal? Fk_ECD_Id
        {
            get { return _Fk_ECD_Id; }
            set { _Fk_ECD_Id = value; }
        }

        public System.DateTime? Date_Of_Loss
        {
            get { return _date_Of_Loss; }
            set { _date_Of_Loss = value; }
        }
        #endregion

        #region Abstract Methods
        public abstract List<cLiabilityReserveWorkHistory> GetAll(Boolean blnIsActive);
        public abstract List<cLiabilityReserveWorkHistory> Geters_Comp_RWByID(System.Decimal PK_Liability_Claim_RW_ID);
        //public abstract cWorkerCompReserveWork Geters_Comp_RWByID(System.Decimal lPK_Workers_Comp_RW_ID);
        public abstract int InsertUpdate_RWComp(RIMS_Base.cLiabilityReserveWorkHistory obj);
        public abstract int Delete_RWComp(System.String PK_Liability_Claim_RW_ID);
        public abstract string ActivateInactivate_RWComp(string strIDs, int intModifiedBy, bool bIsActive);
        public abstract List<cLiabilityReserveWorkHistory> Workers_Comp_RWRecords(System.Decimal Liability_Claim_RW_ID);
        public abstract List<cLiabilityReserveWorkHistory> Workers_Comp_RWRecords_OutStand(System.Decimal Liability_Claim_RW_ID);
        //For Claim info
        public abstract List<cLiabilityReserveWorkHistory> GetClaimInfoByClaimNo(string m_strClaimNo);
        public abstract System.Data.DataSet GetPaymentRecords(System.Decimal Liability_Claim_RW_ID);
        public abstract DataSet GetLiabilityReserveLabel();
        #endregion
    }
}
