#region Includes
using System;
using System.Collections.Generic;
using System.Text;
#endregion

namespace RIMS_Base
{

    [Serializable]
    public abstract class CBankDetails
    {

        #region Constructor
        public CBankDetails()
        {
            this._pK_Bank_Details_ID = -1;
            this._fld_Bank_Name = string.Empty;
            this._fld_Address_1 = string.Empty;
            this._fld_Address_2 = string.Empty;
            this._fld_City = string.Empty;
            this._fld_State = string.Empty;
            this._fld_Zip = string.Empty;
            this._fld_AccountNo = string.Empty;
            this._fld_RoutingNo = string.Empty;
            this._fld_Bank_State = string.Empty;
            this._fld_Bank_No1 = string.Empty;
            this._fld_Bank_No2 = string.Empty;
            this._updated_By = string.Empty;
            this._update_Date = DateTime.Now;
        }
        #endregion

        #region Private Variables
        private System.Decimal _pK_Bank_Details_ID;
        private System.String _fld_Bank_Name;
        private System.String _fld_Address_1;
        private System.String _fld_Address_2;
        private System.String _fld_City;
        private System.String _fld_State;
        private System.String _fld_Zip;
        private System.String _fld_AccountNo;
        private System.String _fld_RoutingNo;
        private System.String _fld_Bank_State;
        private System.String _fld_Bank_No1;
        private System.String _fld_Bank_No2;
        private System.String _updated_By;
        private System.DateTime _update_Date;
        #endregion

        #region Public Properties
        public System.Decimal PK_Bank_Details_ID
        {
            get { return _pK_Bank_Details_ID; }
            set { _pK_Bank_Details_ID = value; }
        }

        public System.String Fld_Bank_Name
        {
            get { return _fld_Bank_Name; }
            set { _fld_Bank_Name = value; }
        }

        public System.String Fld_Address_1
        {
            get { return _fld_Address_1; }
            set { _fld_Address_1 = value; }
        }

        public System.String Fld_Address_2
        {
            get { return _fld_Address_2; }
            set { _fld_Address_2 = value; }
        }

        public System.String Fld_City
        {
            get { return _fld_City; }
            set { _fld_City = value; }
        }

        public System.String Fld_State
        {
            get { return _fld_State; }
            set { _fld_State = value; }
        }

        public System.String Fld_Zip
        {
            get { return _fld_Zip; }
            set { _fld_Zip = value; }
        }

        public System.String Fld_AccountNo
        {
            get { return _fld_AccountNo; }
            set { _fld_AccountNo = value; }
        }

        public System.String Fld_RoutingNo
        {
            get { return _fld_RoutingNo; }
            set { _fld_RoutingNo = value; }
        }

        public System.String Fld_Bank_State
        {
            get { return _fld_Bank_State; }
            set { _fld_Bank_State = value; }
        }

        public System.String Fld_Bank_No1
        {
            get { return _fld_Bank_No1; }
            set { _fld_Bank_No1 = value; }
        }

        public System.String Fld_Bank_No2
        {
            get { return _fld_Bank_No2; }
            set { _fld_Bank_No2 = value; }
        }

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

        #endregion

        #region Abstract Methods
        public abstract List<CBankDetails> GetAll();
        public abstract List<CBankDetails> Get_DetailsByID(System.Decimal lPK_Bank_Details_ID);
        public abstract int InsertUpdate_Details(RIMS_Base.CBankDetails obj);
        public abstract int Delete_Details(System.String lPK_Bank_Details_ID);
        public abstract string ActivateInactivate_Details(string strIDs, int intModifiedBy, bool bIsActive);
        public abstract List<CBankDetails> Get_Search_Data(System.String m_strColumn, System.String m_strCriteria);
        #endregion

    }

}
