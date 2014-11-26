using System;
using System.Collections.Generic;
using System.Text;

namespace RIMS_Base
{
    public abstract class CPropertySearch
    {
        public CPropertySearch()
        {

        }
        #region Private Variables

        private System.Decimal _pK_Property_ID;
        private System.Decimal? _location_Code;
        private System.Decimal? _entity;
        private System.Decimal? _Property_Type;
        private System.String _Address1;
        private System.String _Address2;
        private System.String _City;
        private System.Decimal? _State;
        private System.String _zipCode;

        private System.String _str_Location_Code;
        private System.String _str_Entity;
        private System.String _str_Property_Type;
        private System.String _str_State;
       
        #endregion

        #region Property
        public System.Decimal PK_Property_ID
        {
            get { return _pK_Property_ID; }
            set { _pK_Property_ID = value; }
        }
        public System.Decimal? Location_Code
        {
            get { return _location_Code; }
            set { _location_Code = value; }
        }
        public System.Decimal? Entity
        {
            get { return _entity; }
            set { _entity = value; }
        }
        public System.Decimal? Property_Type
        {
            get { return _Property_Type; }
            set { _Property_Type = value; }
        }
        public System.String Address1
        {
            get { return _Address1; }
            set { _Address1 = value; }
        }

        public System.String Address2
        {
            get { return _Address2; }
            set { _Address2 = value; }
        }
        public System.String City
        {
            get { return _City; }
            set { _City = value; }
        }

        public System.Decimal? State
        {
            get { return _State; }
            set { _State = value; }
        }
        public System.String ZipCode
        {
            get { return _zipCode; }
            set { _zipCode = value; }
        }

        public System.String Str_Location_Code
        {
            get { return _str_Location_Code; }
            set { _str_Location_Code = value; }
        }
        public System.String Str_Entity
        {
            get { return _str_Entity; }
            set { _str_Entity = value; }
        }

        public System.String Str_Property_Type
        {
            get { return _str_Property_Type; }
            set { _str_Property_Type = value; }
        }
        public System.String Str_State
        {
            get { return _str_State; }
            set { _str_State = value; }
        }
        #endregion

        #region Abstract Methods
        public abstract List<CPropertySearch> GetAll(CPropertySearch objPropertySearch);
        public abstract int DeleteProperty(System.Decimal PK_PropertyID);
        #endregion
    }
}
