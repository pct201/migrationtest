#region Includes
using System;
using System.Collections.Generic;
using System.Text;
#endregion;

namespace RIMS_Base
{
    [Serializable]

    public abstract class CEmployeeSearch
    {
        public CEmployeeSearch()
        {

        }

        #region Private Variables

        private System.Decimal _pK_Employee_ID;
        private System.String _last_Name;
        private System.String _first_Name;
        private System.String _middle_Name;
        private System.String _social_Security_Number;

        private System.String _claim_Number;
        private System.String _incident_Date;
        private System.DateTime? _claim_Close_Date;

        // -- Search Criteria
        private System.String _TableName;
        private System.String _WorkerComp;
        private System.String _AutoLib;
        private System.String _GeneralLib;
        private System.String _PropertyLoss;
        private System.String _ExecutiveRisk;
        private System.String _FinPro;
        private System.String _OpenClaimFrom;
        private System.String _OpenClaimTo;
        private System.String _CloseClaimFrom;
        private System.String _CloseClaimTo;

        //-- New Added

        private System.Int32? _ClaimStatus;
        private System.Int32? _FK_Entity;
        private System.Int32? _FK_Risk_Type;
        private System.String _DateOfLossFrom;
        private System.String _DateOfLossTo;
        private System.String _Entity_Description;
        private System.Int32?  _Location_Code;
        private System.String _Location_Dba;
        private System.DateTime? _DateOfLoss;
        private System.Int32? _FK_Major_Claim_Type;
        private System.String _Complainant_Plaintiff;
        #endregion

        #region Public Properties

        public System.Int32? FK_Major_Claim_Type
        {
            get { return _FK_Major_Claim_Type; }
            set { _FK_Major_Claim_Type = value; }
        }
        public System.DateTime? DateOfLoss
        {
            get { return _DateOfLoss; }
            set { _DateOfLoss = value; }
        }
        public System.String Entity_Description
        {
            get { return _Entity_Description; }
            set { _Entity_Description = value; }
        }

        public System.Int32? Location_Code
        {
            get { return _Location_Code; }
            set { _Location_Code = value; }
        }

        public System.String Location_Dba
        {
            get { return _Location_Dba; }
            set { _Location_Dba = value; }
        }

        public System.Int32? ClaimStatus
        {
            get { return _ClaimStatus; }
            set { _ClaimStatus = value; }
        }
        public System.Int32? FK_Entity
        {
            get { return _FK_Entity; }
            set { _FK_Entity = value; }
        }
        public System.Int32? FK_Risk_Type
        {
            get { return _FK_Risk_Type; }
            set { _FK_Risk_Type = value; }
        }
        public System.String DateOfLossFrom
        {
            get { return _DateOfLossFrom; }
            set { _DateOfLossFrom = value; }
        }
        public System.String DateOfLossTo
        {
            get { return _DateOfLossTo; }
            set { _DateOfLossTo = value; }
        }
        public System.String Claim_Number
        {
            get { return _claim_Number; }
            set { _claim_Number = value; }
        }
        public System.String Incident_Date
        {
            get { return _incident_Date; }
            set { _incident_Date = value; }
        }
        public System.DateTime? Claim_Close_Date
        {
            get { return _claim_Close_Date; }
            set { _claim_Close_Date = value; }
        }

        public System.String TableName
        {
            get { return _TableName; }
            set { _TableName = value; }
        }

        public System.String WorkerComp
        {
            get { return _WorkerComp; }
            set { _WorkerComp = value; }
        }

        public System.String AutoLib
        {
            get { return _AutoLib; }
            set { _AutoLib = value; }
        }

        public System.String GeneralLib
        {
            get { return _GeneralLib; }
            set { _GeneralLib = value; }
        }

        public System.String FinPro
        {
            get { return _FinPro; }
            set { _FinPro = value; }
        }
        public System.String PropertyLoss
        {
            get { return _PropertyLoss; }
            set { _PropertyLoss = value; }
        }

        public System.String ExecutiveRisk
        {
            get { return _ExecutiveRisk; }
            set { _ExecutiveRisk = value; }
        }
        public System.String OpenClaimFrom
        {
            get { return _OpenClaimFrom; }
            set { _OpenClaimFrom = value; }
        }
        public System.String OpenClaimTo
        {
            get { return _OpenClaimTo; }
            set { _OpenClaimTo = value; }
        }
        public System.String CloseClaimFrom
        {
            get { return _CloseClaimFrom; }
            set { _CloseClaimFrom = value; }
        }
        public System.String CloseClaimTo
        {
            get { return _CloseClaimTo; }
            set { _CloseClaimTo = value; }
        }

        public System.Decimal PK_Employee_ID
        {
            get { return _pK_Employee_ID; }
            set { _pK_Employee_ID = value; }
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


        public System.String Social_Security_Number
        {
            get { return _social_Security_Number; }
            set { _social_Security_Number = value; }
        }

        public System.String Complainant_Plaintiff
        {
            get { return _Complainant_Plaintiff; }
            set { _Complainant_Plaintiff = value; }
        }

        #endregion

        #region Abstract Methods
        public abstract List<CEmployeeSearch> GetAll(CEmployeeSearch objEmpSearch, Decimal pK_Security_Id);
        public abstract int DeleteClaim(System.String ClaimType, System.Decimal PK_ClaimID);
        #endregion

    }
}
