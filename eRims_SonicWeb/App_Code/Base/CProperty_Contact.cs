using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
namespace RIMS_Base
{
    public abstract class CProperty_Contact
    {
        
        #region Constructor
        public CProperty_Contact()
        {
            //this._pK_Property_Contacts = 0;
            //this._fK_Property_COPE = 0;
            this._facility_Name = string.Empty;
            this._facility_Telephone_Number = string.Empty;
            this._facility_Facsimile_Number = string.Empty;
            this._facility_Call_Phone_Number = string.Empty;
            this._aH_Name = string.Empty;
            this._aH_Telephone_Number = string.Empty;
            this._aH_Facsimile_Number = string.Empty;
            this._aH_Call_Phone_Number = string.Empty;
            //this._updated_By = 0;
            this._update_Date = DateTime.Now;
        }
        #endregion

        #region Private Variables
        private System.Int32 _pK_Property_Contacts;
        private System.Decimal _fK_Property_COPE;
        private System.String _facility_Name;
        private System.String _facility_Telephone_Number;
        private System.String _facility_Facsimile_Number;
        private System.String _facility_Call_Phone_Number;
        private System.String _aH_Name;
        private System.String _aH_Telephone_Number;
        private System.String _aH_Facsimile_Number;
        private System.String _aH_Call_Phone_Number;
        private System.Decimal _updated_By;
        private System.DateTime _update_Date;
        #endregion

        #region Public Properties
        public System.Int32 PK_Property_Contacts
        {
            get { return _pK_Property_Contacts; }
            set { _pK_Property_Contacts = value; }
        }

        public System.Decimal FK_Property_COPE
        {
            get { return _fK_Property_COPE; }
            set { _fK_Property_COPE = value; }
        }

        public System.String Facility_Name
        {
            get { return _facility_Name; }
            set { _facility_Name = value; }
        }

        public System.String Facility_Telephone_Number
        {
            get { return _facility_Telephone_Number; }
            set { _facility_Telephone_Number = value; }
        }

        public System.String Facility_Facsimile_Number
        {
            get { return _facility_Facsimile_Number; }
            set { _facility_Facsimile_Number = value; }
        }

        public System.String Facility_Call_Phone_Number
        {
            get { return _facility_Call_Phone_Number; }
            set { _facility_Call_Phone_Number = value; }
        }

        public System.String AH_Name
        {
            get { return _aH_Name; }
            set { _aH_Name = value; }
        }

        public System.String AH_Telephone_Number
        {
            get { return _aH_Telephone_Number; }
            set { _aH_Telephone_Number = value; }
        }

        public System.String AH_Facsimile_Number
        {
            get { return _aH_Facsimile_Number; }
            set { _aH_Facsimile_Number = value; }
        }

        public System.String AH_Call_Phone_Number
        {
            get { return _aH_Call_Phone_Number; }
            set { _aH_Call_Phone_Number = value; }
        }

        public System.Decimal Updated_By
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
        public abstract DataSet GetAll();
        public abstract DataSet GetP_ContactsByID(System.Decimal lPK_Property_Contacts);
        public abstract int InsertUpdateP_Contacts(RIMS_Base.CProperty_Contact obj);
        public abstract int DeleteP_Contacts(System.Decimal lPK_Property_Contacts);
        #endregion
    }
}
