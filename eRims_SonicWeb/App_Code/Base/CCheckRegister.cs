#region Includes
using System;
using System.Collections.Generic;
using System.Text;
#endregion

namespace RIMS_Base
{

    [Serializable]
    public abstract class CCheckRegister
    {

        #region Constructor
        public CCheckRegister()
        {
            this._pK_Check_Register = -1;
            //this._table_Name = string.Empty;
            //this._fK_Table_Name = -1;
            //this._last_Reserve_Change = DateTime.Now;
            //this._indemnity_Incurred = -1;
            //this._indemnity_Paid = -1;
            //this._indemnity_Outstanding = -1;
            //this._indemnity_Current_Month = -1;
            //this._medical_Incurred = -1;
            //this._medical_Paid = -1;
            //this._medical_Outstanding = -1;
            //this._medical_Current_Month = -1;
            //this._expense_Incurred = -1;
            //this._expense_Paid = -1;
            //this._expense_Outstanding = -1;
            //this._expense_Current_Month = -1;
        }
        #endregion

        #region Private Variables
        private System.Decimal _pK_Check_Register;
        private System.String _table_Name;
        private System.Decimal _fK_Table_Name;
        private System.DateTime? _last_Reserve_Change;
        private System.Decimal? _indemnity_Incurred;
        private System.Decimal? _indemnity_Paid;
        private System.Decimal? _indemnity_Outstanding;
        private System.Decimal? _indemnity_Current_Month;
        private System.Decimal? _medical_Incurred;
        private System.Decimal? _medical_Paid;
        private System.Decimal? _medical_Outstanding;
        private System.Decimal? _medical_Current_Month;
        private System.Decimal? _expense_Incurred;
        private System.Decimal? _expense_Paid;
        private System.Decimal? _expense_Outstanding;
        private System.Decimal? _expense_Current_Month;
        #endregion

        #region Public Properties
        public System.Decimal PK_Check_Register
        {
            get { return _pK_Check_Register; }
            set { _pK_Check_Register = value; }
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

        public System.DateTime? Last_Reserve_Change
        {
            get { return _last_Reserve_Change; }
            set { _last_Reserve_Change = value; }
        }

        public System.Decimal? Indemnity_Incurred
        {
            get { return _indemnity_Incurred; }
            set { _indemnity_Incurred = value; }
        }

        public System.Decimal? Indemnity_Paid
        {
            get { return _indemnity_Paid; }
            set { _indemnity_Paid = value; }
        }

        public System.Decimal? Indemnity_Outstanding
        {
            get { return _indemnity_Outstanding; }
            set { _indemnity_Outstanding = value; }
        }

        public System.Decimal? Indemnity_Current_Month
        {
            get { return _indemnity_Current_Month; }
            set { _indemnity_Current_Month = value; }
        }

        public System.Decimal? Medical_Incurred
        {
            get { return _medical_Incurred; }
            set { _medical_Incurred = value; }
        }

        public System.Decimal? Medical_Paid
        {
            get { return _medical_Paid; }
            set { _medical_Paid = value; }
        }

        public System.Decimal? Medical_Outstanding
        {
            get { return _medical_Outstanding; }
            set { _medical_Outstanding = value; }
        }

        public System.Decimal? Medical_Current_Month
        {
            get { return _medical_Current_Month; }
            set { _medical_Current_Month = value; }
        }

        public System.Decimal? Expense_Incurred
        {
            get { return _expense_Incurred; }
            set { _expense_Incurred = value; }
        }

        public System.Decimal? Expense_Paid
        {
            get { return _expense_Paid; }
            set { _expense_Paid = value; }
        }

        public System.Decimal? Expense_Outstanding
        {
            get { return _expense_Outstanding; }
            set { _expense_Outstanding = value; }
        }

        public System.Decimal? Expense_Current_Month
        {
            get { return _expense_Current_Month; }
            set { _expense_Current_Month = value; }
        }

        #endregion

        #region Abstract Methods
        public abstract List<CCheckRegister> GetAll();
        public abstract List<CCheckRegister> GetCheckRegisterByID(System.Decimal Fk_Table_Name, System.String Table_Name);
        public abstract int InsertUpdateCheckRegister(RIMS_Base.CCheckRegister obj);
        public abstract int DeleteCheckRegister(System.Decimal lPK_Check_Register);
        public abstract string ActivateInactivCheckRegister(string strIDs, int intModifiedBy, bool bIsActive);
        #endregion

    }

}
