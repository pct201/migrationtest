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
    public abstract class cSubrogationDetail
    {

        #region Constructor
        public cSubrogationDetail()
        {
            this._pK_Subrogation_detail = -1;
            //this._table_Name = string.Empty;
            //this._fK_Table_Name = -1;
            //this._policy_Company = string.Empty;
            //this._policy = string.Empty;
            //this._claim_Adjuster = string.Empty;
            //this._tP_Name = string.Empty;
            //this._tP_Address_1 = string.Empty;
            //this._tP_Address_2 = string.Empty;
            //this._tP_City = string.Empty;
            //this._fK_State_TP = -1;
            //this._tP_Zip_Code = string.Empty;
            //this._tP_Telephone = string.Empty;
            //this._tP_Insurance_Company = string.Empty;
            //this._tP_Insurance_Number = string.Empty;
            //this._notice_Date = DateTime.Now;
            //this._tPA = string.Empty;
            //this._tPA_Contact = string.Empty;
            //this._tPA_Address_1 = string.Empty;
            //this._tPA_Address_2 = string.Empty;
            //this._tPA_City = string.Empty;
            //this._fK_State_TPA = -1;
            //this._tPA_Zip_Code = string.Empty;
            //this._tPA_Telephone = string.Empty;
            //this._recovery = -1;
            //this._received = -1;
            //this._updated_By = string.Empty;
            //this._update_Date = DateTime.Now;
        }
        #endregion

        #region Private Variables
        private System.Int32 _pK_Subrogation_detail;
        private System.String _table_Name;
        private System.Decimal _fK_Table_Name;
        private System.String _policy_Company;
        private System.String _policy;
        private System.String _claim_Adjuster;
        private System.String _tP_Name;
        private System.String _tP_Address_1;
        private System.String _tP_Address_2;
        private System.String _tP_City;
        private System.Decimal? _fK_State_TP;
        private System.String _tP_Zip_Code;
        private System.String _tP_Telephone;
        private System.String _tP_Insurance_Company;
        private System.String _tP_Insurance_Number;
        private System.DateTime? _notice_Date;
        private System.String _tPA;
        private System.String _tPA_Contact;
        private System.String _tPA_Address_1;
        private System.String _tPA_Address_2;
        private System.String _tPA_City;
        private System.Decimal? _fK_State_TPA;
        private System.String _tPA_Zip_Code;
        private System.String _tPA_Telephone;
        private System.Decimal? _recovery;
        private System.Decimal? _received;
        private System.String _updated_By;
        private System.DateTime? _update_Date;
        #endregion

        #region Public Properties
        public System.Int32 PK_Subrogation_detail
        {
            get { return _pK_Subrogation_detail; }
            set { _pK_Subrogation_detail = value; }
        }

        public System.String Table_Name
        {
            get { return _table_Name; }
            set { _table_Name = value; }
        }

        public System.Decimal FK_Table_Name
        {
            get { return _fK_Table_Name; }
            set { _fK_Table_Name = value; }
        }

        public System.String Policy_Company
        {
            get { return _policy_Company; }
            set { _policy_Company = value; }
        }

        public System.String Policy
        {
            get { return _policy; }
            set { _policy = value; }
        }

        public System.String Claim_Adjuster
        {
            get { return _claim_Adjuster; }
            set { _claim_Adjuster = value; }
        }

        public System.String TP_Name
        {
            get { return _tP_Name; }
            set { _tP_Name = value; }
        }

        public System.String TP_Address_1
        {
            get { return _tP_Address_1; }
            set { _tP_Address_1 = value; }
        }

        public System.String TP_Address_2
        {
            get { return _tP_Address_2; }
            set { _tP_Address_2 = value; }
        }

        public System.String TP_City
        {
            get { return _tP_City; }
            set { _tP_City = value; }
        }

        public System.Decimal? FK_State_TP
        {
            get { return _fK_State_TP; }
            set { _fK_State_TP = value; }
        }

        public System.String TP_Zip_Code
        {
            get { return _tP_Zip_Code; }
            set { _tP_Zip_Code = value; }
        }

        public System.String TP_Telephone
        {
            get { return _tP_Telephone; }
            set { _tP_Telephone = value; }
        }

        public System.String TP_Insurance_Company
        {
            get { return _tP_Insurance_Company; }
            set { _tP_Insurance_Company = value; }
        }

        public System.String TP_Insurance_Number
        {
            get { return _tP_Insurance_Number; }
            set { _tP_Insurance_Number = value; }
        }

        public System.DateTime? Notice_Date
        {
            get { return _notice_Date; }
            set { _notice_Date = value; }
        }

        public System.String TPA
        {
            get { return _tPA; }
            set { _tPA = value; }
        }

        public System.String TPA_Contact
        {
            get { return _tPA_Contact; }
            set { _tPA_Contact = value; }
        }

        public System.String TPA_Address_1
        {
            get { return _tPA_Address_1; }
            set { _tPA_Address_1 = value; }
        }

        public System.String TPA_Address_2
        {
            get { return _tPA_Address_2; }
            set { _tPA_Address_2 = value; }
        }

        public System.String TPA_City
        {
            get { return _tPA_City; }
            set { _tPA_City = value; }
        }

        public System.Decimal? FK_State_TPA
        {
            get { return _fK_State_TPA; }
            set { _fK_State_TPA = value; }
        }

        public System.String TPA_Zip_Code
        {
            get { return _tPA_Zip_Code; }
            set { _tPA_Zip_Code = value; }
        }

        public System.String TPA_Telephone
        {
            get { return _tPA_Telephone; }
            set { _tPA_Telephone = value; }
        }

        public System.Decimal? Recovery
        {
            get { return _recovery; }
            set { _recovery = value; }
        }

        public System.Decimal? Received
        {
            get { return _received; }
            set { _received = value; }
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

        #endregion

        #region Abstract Methods
        public abstract List<cSubrogationDetail> GetAll(Boolean blnIsActive);
        public abstract List<cSubrogationDetail> GetSubrogationDetailByID(System.Decimal Fk_Table_Name, System.String Table_Name);
        public abstract int InsertUpdateSubrogationDetail(RIMS_Base.cSubrogationDetail obj);
        public abstract int DeleteSubrogationDetail(System.Int32 lPK_Subrogation_detail);
        public abstract string ActivateInactivateSubrogationDetail(string strIDs, int intModifiedBy, bool bIsActive);
        public abstract DataSet GetSubrogationDetailLabel();
        #endregion

    }

}
