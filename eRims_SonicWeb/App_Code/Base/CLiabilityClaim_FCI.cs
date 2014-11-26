#region Includes
using System;
using System.Collections.Generic;
using System.Text;
#endregion

namespace RIMS_Base
{

    [Serializable]
    public abstract class CLiabilityClaim_FCI
    {

        #region Constructor
        public CLiabilityClaim_FCI()
        {
            this._pK_Liability_Claim = -1;
            //this._claim_Number = string.Empty;
            //this._fK_Claim_Type = -1;
            //this._fK_Claimant_id = -1;
            //this._fK_Entity = -1;
            //this._date_Of_Loss = DateTime.Now;
            //this._time_Of_Loss = string.Empty;
            //this._legal = string.Empty;
            //this._report_To_Carrier = string.Empty;
            //this._date_To_Fairpoint = DateTime.Now;
            //this._claim_Open_Date = DateTime.Now;
            //this._claim_Close_Date = DateTime.Now;
            //this._claim_Reopen_Date = DateTime.Now;
            //this._date_To_Carrier = DateTime.Now;
            //this._fK_Carrier = -1;
            //this._tPA_Name = string.Empty;
            //this._policy_Number_Claim = string.Empty;
            //this._effective_Policy_Date = DateTime.Now;
            //this._expiration_Policy_Date = DateTime.Now;


            this._last_Name = string.Empty;
            this._first_Name = string.Empty;
            this._middle_Name = string.Empty;
            this._cliamantanEmp = string.Empty;
            #region


            #endregion
        }
        #endregion

        #region Private Variables
        private System.Int32 _pK_Liability_Claim;
        private System.String _claim_Number;
        private System.Decimal? _fK_Claim_Type;
        private System.Decimal? _fK_Claimant_id;
        private System.Decimal? _fK_Entity;
        private System.Decimal? _Fk_ECD_Id;
        private System.DateTime? _date_Of_Loss;
        private System.String _time_Of_Loss;
        private System.String _legal;
        private System.String _report_To_Carrier;
        private System.DateTime? _date_To_Fairpoint;
        private System.DateTime? _claim_Open_Date;
        private System.DateTime? _claim_Close_Date;
        private System.DateTime? _claim_Reopen_Date;
        private System.DateTime? _date_To_Carrier;
        private System.String _Carrier;
        private System.Decimal? _fK_Carrier;
        private String _Carrier_Claim_Number;
        private System.String _tPA_Name;
        private System.String _policy_Number_Claim;
        private System.DateTime? _effective_Policy_Date;
        private System.DateTime? _expiration_Policy_Date;
        private System.Decimal? _FK_Liability_Major_Claim_Type;
        private System.Decimal? _FK_Liability_Coverage;

        private System.String _last_Name;
        private System.String _first_Name;
        private System.String _middle_Name;

        private System.String Cliamant_last_Name;
        private System.String Cliamant_first_Name;
        private System.String Cliamant_middle_Name;

        private System.String Driver_last_Name;
        private System.String Driver_first_Name;
        private System.String Driver_middle_Name;

        private System.String _cliamantanEmp;
        private System.String _AddTo;

        #region

        #endregion

        #endregion

        #region Public Properties


        public System.String Driver_Last_Name
        {
            get { return Driver_last_Name; }
            set { Driver_last_Name = value; }
        }

        public System.String Driver_First_Name
        {
            get { return Driver_first_Name; }
            set { Driver_first_Name = value; }
        }

        public System.String ADDTO
        {
            get { return _AddTo; }
            set { _AddTo = value; }
        }


        public System.String Driver_Middle_Name
        {
            get { return Driver_middle_Name; }
            set { Driver_middle_Name = value; }
        }


        public System.String Cliamant_An_Employee
        {
            get { return _cliamantanEmp; }
            set { _cliamantanEmp = value; }
        }


        public System.String Cliamant_Last_Name
        {
            get { return Cliamant_last_Name; }
            set { Cliamant_last_Name = value; }
        }

        public System.String Cliamant_First_Name
        {
            get { return Cliamant_first_Name; }
            set { Cliamant_first_Name = value; }
        }

        public System.String Cliamant_Middle_Name
        {
            get { return Cliamant_middle_Name; }
            set { Cliamant_middle_Name = value; }
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







        public System.Int32 PK_Liability_Claim
        {
            get { return _pK_Liability_Claim; }
            set { _pK_Liability_Claim = value; }
        }

        public System.String Claim_Number
        {
            get { return _claim_Number; }
            set { _claim_Number = value; }
        }

        public System.Decimal? FK_Claim_Type
        {
            get { return _fK_Claim_Type; }
            set { _fK_Claim_Type = value; }
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

        public System.Decimal? FK_Liability_Major_Claim_Type
        {
            get { return _FK_Liability_Major_Claim_Type; }
            set { _FK_Liability_Major_Claim_Type = value; }
        }

        public System.Decimal? FK_Liability_Coverage
        {
            get { return _FK_Liability_Coverage; }
            set { _FK_Liability_Coverage = value; }
        }
        public System.Decimal? FK_Entity
        {
            get { return _fK_Entity; }
            set { _fK_Entity = value; }
        }

        public System.DateTime? Date_Of_Loss
        {
            get { return _date_Of_Loss; }
            set { _date_Of_Loss = value; }
        }

        public System.String Time_Of_Loss
        {
            get { return _time_Of_Loss; }
            set { _time_Of_Loss = value; }
        }

        public System.String Legal
        {
            get { return _legal; }
            set { _legal = value; }
        }

        public System.String Report_To_Carrier
        {
            get { return _report_To_Carrier; }
            set { _report_To_Carrier = value; }
        }

        public System.DateTime? Date_To_Fairpoint
        {
            get { return _date_To_Fairpoint; }
            set { _date_To_Fairpoint = value; }
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

        public System.DateTime? Date_To_Carrier
        {
            get { return _date_To_Carrier; }
            set { _date_To_Carrier = value; }
        }

        public System.String Carrier
        {
            get { return _Carrier; }
            set { _Carrier = value; }
        }

        public System.Decimal? FK_Carrier
        {
            get { return _fK_Carrier; }
            set { _fK_Carrier = value; }
        }

        public String Carrier_Claim_Number
        {
            get { return _Carrier_Claim_Number; }
            set { _Carrier_Claim_Number = value; }
        }

        public System.String TPA_Name
        {
            get { return _tPA_Name; }
            set { _tPA_Name = value; }
        }

        public System.String Policy_Number_Claim
        {
            get { return _policy_Number_Claim; }
            set { _policy_Number_Claim = value; }
        }

        public System.DateTime? Effective_Policy_Date
        {
            get { return _effective_Policy_Date; }
            set { _effective_Policy_Date = value; }
        }

        public System.DateTime? Expiration_Policy_Date
        {
            get { return _expiration_Policy_Date; }
            set { _expiration_Policy_Date = value; }
        }


        #region
        #endregion
        #endregion

        #region Abstract Methods
        public abstract List<CLiabilityClaim_FCI> GetAll(Boolean blnIsActive);
        public abstract List<CLiabilityClaim_FCI> GetAL_ClaimByID(System.Int32 lPK_Liability_Claim);
        public abstract List<CLiabilityClaim_FCI> GetAL_ClaimByClaimNo(String strClaimNo);
        public abstract int InsertUpdateility_Claim(RIMS_Base.CLiabilityClaim_FCI obj);
        public abstract int InsertUpdate_PropertyClaim(RIMS_Base.CLiabilityClaim_FCI obj);
        public abstract int Deleteility_Claim(System.Int32 lPK_Liability_Claim);
        public abstract string ActivateInactivateility_Claim(string strIDs, int intModifiedBy, bool bIsActive);

        public abstract List<CLiabilityClaim_FCI> GetEmployee_ByID(System.Int32 pK_Liability_Claim, System.Decimal pK_Employee_Id);
        public abstract List<CLiabilityClaim_FCI> GetCliamant_ByID(System.Int32 pK_Liability_Claim, System.Decimal pK_Claimant_Id);
        public abstract List<CLiabilityClaim_FCI> GetDriver_ByID(System.Int32 pK_Liability_Claim, System.Decimal pK_Property_Drivers);
        public abstract List<CLiabilityClaim_FCI> GetCarrier_ByID(System.Int32 pK_Liability_Claim, System.Decimal pK_Policy_Id);

        #endregion

    }

}
