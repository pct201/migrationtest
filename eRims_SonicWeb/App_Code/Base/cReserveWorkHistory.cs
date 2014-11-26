#region Includes
using System;
using System.Collections.Generic;
using System.Text;
#endregion

namespace RIMS_Base
{

    [Serializable]
    public abstract class cReserveWorkHistory
    {

        #region Constructor
        public cReserveWorkHistory()
        {
            this._pK_RW_History_ID = -1;
            this._table_Name = string.Empty;
            this._fK_Table_Name = -1;
            this._transaction_Date = DateTime.Now;
            this._indemnity = -1;
            this._medical = -1;
            this._expenses = -1;
            this._total = -1;
            this._updated_By = string.Empty;
            this._update_Date = DateTime.Now;
            this._fK_Workers_Comp_RW_ID = -1;
        }
        #endregion

        #region Private Variables
        private System.Decimal _pK_RW_History_ID;
        private System.String _table_Name;
        private System.Decimal _fK_Table_Name;
        private System.DateTime _transaction_Date;
        private System.Decimal _indemnity;
        private System.Decimal _medical;
        private System.Decimal _expenses;
        private System.Decimal _total;
        private System.String _updated_By;
        private System.DateTime _update_Date;
        private System.Decimal _fK_Workers_Comp_RW_ID;
        #endregion

        #region Public Properties
        public System.Decimal PK_RW_History_ID
        {
            get { return _pK_RW_History_ID; }
            set { _pK_RW_History_ID = value; }
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

        public System.DateTime Transaction_Date
        {
            get { return _transaction_Date; }
            set { _transaction_Date = value; }
        }

        public System.Decimal Indemnity
        {
            get { return _indemnity; }
            set { _indemnity = value; }
        }

        public System.Decimal Medical
        {
            get { return _medical; }
            set { _medical = value; }
        }

        public System.Decimal Expenses
        {
            get { return _expenses; }
            set { _expenses = value; }
        }

        public System.Decimal Total
        {
            get { return _total; }
            set { _total = value; }
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

        public System.Decimal FK_Workers_Comp_RW_ID
        {
            get { return _fK_Workers_Comp_RW_ID; }
            set { _fK_Workers_Comp_RW_ID = value; }
        }

        #endregion

        #region Abstract Methods
        public abstract List<cReserveWorkHistory> GetAll(Boolean blnIsActive);
        public abstract cReserveWorkHistory GetistoryByID(System.Decimal lPK_RW_History_ID);
        public abstract int InsertUpdate_History(RIMS_Base.cReserveWorkHistory obj);
        public abstract int Delete_History(System.Decimal lPK_RW_History_ID);
        public abstract string ActivateInactivate_History(string strIDs, int intModifiedBy, bool bIsActive);
        #endregion

    }

}
