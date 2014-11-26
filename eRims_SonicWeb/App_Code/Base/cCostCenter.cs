#region Includes
using System;
using System.Collections.Generic;
using System.Text;
#endregion

namespace RIMS_Base
{

    [Serializable]
    public abstract class cCostCenter
    {

        #region Constructor
        public  cCostCenter()
        {
            this._pK_ID = -1;
            this._cost_Center = string.Empty;
            this._subsidiary = string.Empty;
            this._bCBS_Group_Number = string.Empty;
            this._division_Name = string.Empty;
            this._address = string.Empty;
            this._city = string.Empty;
            this._state = string.Empty;
            this._zip = string.Empty;
            this._occupancy = string.Empty;
            this._number_of_Employees = -1;
            this._shifts = -1;
            this._employees_Per_Shift = -1;
            this._fEIN = string.Empty;
        }
        #endregion

        #region Private Variables
        private System.Decimal _pK_ID;
        private System.String _cost_Center;
        private System.String _subsidiary;
        private System.String _bCBS_Group_Number;
        private System.String _division_Name;
        private System.String _address;
        private System.String _city;
        private System.String _state;
        private System.String _zip;
        private System.String _occupancy;
        private System.Decimal _number_of_Employees;
        private System.Decimal _shifts;
        private System.Decimal _employees_Per_Shift;
        private System.String _fEIN;
        #endregion

        #region Public Properties
        public System.Decimal PK_ID
        {
            get { return _pK_ID; }
            set { _pK_ID = value; }
        }

        public System.String Cost_Center
        {
            get { return _cost_Center; }
            set { _cost_Center = value; }
        }

        public System.String Subsidiary
        {
            get { return _subsidiary; }
            set { _subsidiary = value; }
        }

        public System.String BCBS_Group_Number
        {
            get { return _bCBS_Group_Number; }
            set { _bCBS_Group_Number = value; }
        }

        public System.String Division_Name
        {
            get { return _division_Name; }
            set { _division_Name = value; }
        }

        public System.String Address
        {
            get { return _address; }
            set { _address = value; }
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

        public System.String Zip
        {
            get { return _zip; }
            set { _zip = value; }
        }

        public System.String Occupancy
        {
            get { return _occupancy; }
            set { _occupancy = value; }
        }

        public System.Decimal Number_of_Employees
        {
            get { return _number_of_Employees; }
            set { _number_of_Employees = value; }
        }

        public System.Decimal Shifts
        {
            get { return _shifts; }
            set { _shifts = value; }
        }

        public System.Decimal Employees_Per_Shift
        {
            get { return _employees_Per_Shift; }
            set { _employees_Per_Shift = value; }
        }

        public System.String FEIN
        {
            get { return _fEIN; }
            set { _fEIN = value; }
        }

        #endregion

        #region Abstract Methods
        public abstract List<cCostCenter> GetAll();
        public abstract List<cCostCenter> Get_Search_Data(System.String m_strColumn, System.String m_strCriteria);
        public abstract int InsertUpdate_Center(RIMS_Base. cCostCenter obj);
        public abstract int Delete_Center(System.Int32 lPK_ID);
        public abstract string ActivateInactivate_Center(string strIDs, int intModifiedBy, bool bIsActive);
        #endregion

    }

}
