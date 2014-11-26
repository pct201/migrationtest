#region Includes
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
#endregion

namespace RIMS_Base
{

    [Serializable]
    public abstract class cSubrogation
    {

        #region Constructor
        public cSubrogation()
        {
            this._pK_Subrogation = -1;
            //this._table_Name = string.Empty;
            //this._fK_Table_Name = -1;
            //this._check_Amount = -1;
            //this._fK_Provider = -1;
            //this._check_Number = -1;
            //this._subrogation = string.Empty;
            //this._auto_Salvage = string.Empty;
            //this._other = string.Empty;
            //this._other_Description = string.Empty;
            //this._full_Refund = string.Empty;
            //this._partial_Refund = string.Empty;
            //this._updated_By = string.Empty;
            //this._update_Date = DateTime.Now;
            //this._payment_Id = string.Empty;
            //this._paycode = string.Empty;
            //this._recovery_Description = string.Empty;
        }
        #endregion

        #region Private Variables
        private System.Int32 _pK_Subrogation;
        private System.String _table_Name;
        private System.Decimal _fK_Table_Name;
        private System.Decimal? _check_Amount;
        private System.Decimal? _fK_Provider;
        private System.Decimal? _check_Number;
        private System.String _subrogation;
        private System.String _auto_Salvage;
        private System.String _other;
        private System.String _other_Description;
        private System.String _full_Refund;
        private System.String _partial_Refund;
        private System.String _updated_By;
        private System.DateTime? _update_Date;
        private System.String _payment_Id;
        private System.String _paycode;
        private System.String _FLD_Paycode;
        private System.String _recovery_Description;

        //----- Provider
        private System.Decimal _pK_Provider_ID;
        private System.String _name;
        private System.String _tax_Id;
        private System.String _address_1;
        private System.String _address_2;
        private System.String _city;
        private System.String _state;
        private System.String _zip_Code;
        private System.String _phone;
        private System.String _facsimile;
        private System.String _provider_updated_By;
        private System.DateTime _provider_update_Date;


        #endregion

        #region Public Properties
        public System.String FLD_Paycode
        {
            get { return _FLD_Paycode; }
            set { _FLD_Paycode = value; }
        }

        public System.Int32 PK_Subrogation
        {
            get { return _pK_Subrogation; }
            set { _pK_Subrogation = value; }
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

        public System.Decimal? Check_Amount
        {
            get { return _check_Amount; }
            set { _check_Amount = value; }
        }

        public System.Decimal? FK_Provider
        {
            get { return _fK_Provider; }
            set { _fK_Provider = value; }
        }

        public System.Decimal? Check_Number
        {
            get { return _check_Number; }
            set { _check_Number = value; }
        }

        public System.String Subrogation
        {
            get { return _subrogation; }
            set { _subrogation = value; }
        }

        public System.String Auto_Salvage
        {
            get { return _auto_Salvage; }
            set { _auto_Salvage = value; }
        }

        public System.String Other
        {
            get { return _other; }
            set { _other = value; }
        }

        public System.String Other_Description
        {
            get { return _other_Description; }
            set { _other_Description = value; }
        }

        public System.String Full_Refund
        {
            get { return _full_Refund; }
            set { _full_Refund = value; }
        }

        public System.String Partial_Refund
        {
            get { return _partial_Refund; }
            set { _partial_Refund = value; }
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

        public System.String Payment_Id
        {
            get { return _payment_Id; }
            set { _payment_Id = value; }
        }

        public System.String Paycode
        {
            get { return _paycode; }
            set { _paycode = value; }
        }

        public System.String Recovery_Description
        {
            get { return _recovery_Description; }
            set { _recovery_Description = value; }
        }

        public System.Decimal PK_Provider_ID
        {
            get { return _pK_Provider_ID; }
            set { _pK_Provider_ID = value; }
        }

        public System.String Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public System.String Tax_Id
        {
            get { return _tax_Id; }
            set { _tax_Id = value; }
        }

        public System.String Address_1
        {
            get { return _address_1; }
            set { _address_1 = value; }
        }

        public System.String Address_2
        {
            get { return _address_2; }
            set { _address_2 = value; }
        }

        public System.String City
        {
            get { return _city; }
            set { _city = value; }
        }

        public System.String State
        {
            get { return _state; }
            set { _state = value; }
        }

        public System.String Zip_Code
        {
            get { return _zip_Code; }
            set { _zip_Code = value; }
        }

        public System.String Phone
        {
            get { return _phone; }
            set { _phone = value; }
        }

        public System.String Facsimile
        {
            get { return _facsimile; }
            set { _facsimile = value; }
        }

        public System.String Provider_Updated_By
        {
            get { return _provider_updated_By; }
            set { _provider_updated_By = value; }
        }

        public System.DateTime Provider_Update_Date
        {
            get { return _provider_update_Date; }
            set { _provider_update_Date = value; }
        }

        #endregion

        #region Abstract Methods
        public abstract List<cSubrogation> GetAll(Decimal Fk_Table_Name, string Table_Name);
        public abstract List<cSubrogation> GetSubrogationByID(System.Int32 lPK_Subrogation);
        public abstract int InsertUpdateSubrogation(RIMS_Base.cSubrogation obj);
        public abstract int DeleteSubrogation(System.String lPK_Subrogation);
        public abstract string ActivateInactivateSubrogation(string strIDs, int intModifiedBy, bool bIsActive);
        public abstract List<cSubrogation> SearchSubrogationData(string FieldName, string FieldVal, Decimal Fk_Table_Name, string Table_Name);
        public abstract List<cSubrogation> GetProvider(System.Decimal Pk_ProviderID);
        public abstract DataSet GetSubrogationLabel();
        #endregion

    }

}
