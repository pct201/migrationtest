using System;
using System.Collections.Generic;
using System.Text;

namespace RIMS_Base
{
    [Serializable]
    public abstract class CPropertyDriver
    {
        #region Constructor
        public CPropertyDriver()
        {
            this._PK_Property_Drivers = -1;
           // this._PK_Driver_Status = -1;
           // this._PK_Entity = -1;
            this._Last_Name = string.Empty;
            this._First_Name = string.Empty;
            this._Middle_Name = string.Empty;
            this._Work_Telephone = string.Empty;
            this._Management = string.Empty;
            this._Interstate = string.Empty;
            this._GVW = string.Empty;
            this._Address_1 = string.Empty;
            this._Address_2 = string.Empty;
            this._City = string.Empty;
            this._Zip_Code = string.Empty;
            this._Home_Telephone = string.Empty;
            this._Cell_Phone = string.Empty;
            this._Pager = string.Empty;
            this._Email = string.Empty;
            this._Social_Security_Number = string.Empty;
            this._Drivers_License_Number = string.Empty;
            this._Drivers_License_Class = string.Empty;
            this._Restrictions = string.Empty;
            this._Endorsements = string.Empty;
            this._Supervisor_First = string.Empty;
            this._Supervisor_Last = string.Empty;
            this._Supervisor_Phone = string.Empty;
            this._Supervisor_Title = string.Empty;
            this._Notes = string.Empty;
            this._Updated_By = string.Empty;
            this._Update_Date = DateTime.Now;
        }
        #endregion

        #region Private Variables
        private System.Int32 _PK_Property_Drivers;
        private System.Decimal _PK_Driver_Status;
        private System.DateTime ? _Status_As_Of;
        private System.Decimal  _PK_Entity;
        private System.String   _Last_Name;
        private System.String   _First_Name;
        private System.String   _Middle_Name;
        private System.String   _Work_Telephone;
        private System.String   _Management;
        private System.String   _Interstate;
        private System.String   _GVW;
        private System.DateTime ? _Last_MVR;
        private System.String   _Address_1;
        private System.String   _Address_2;
        private System.String   _City;
        private System.Decimal  _State;
        private System.String _StateName;
        private System.String   _Zip_Code;
        private System.String   _Home_Telephone;
        private System.String   _Cell_Phone;
        private System.String   _Pager;
        private System.String   _Email;
        private System.String   _Social_Security_Number;
        private System.Decimal  _FK_Gender;
        private System.DateTime ? _Date_Of_Birth;
        private System.Decimal  _FK_DL_State;
        private System.String   _Drivers_License_Number;
        private System.Decimal  _FK_Drivers_License_Class;
        private System.String   _Drivers_License_Class;
        private System.String   _Restrictions;
        private System.String   _Endorsements;
        private System.DateTime ? _DL_Begin_Date;
        private System.DateTime ? _DL_End_Date;
        private System.String   _Supervisor_Last;
        private System.String   _Supervisor_First;
        private System.String   _Supervisor_Title;
        private System.String   _Supervisor_Phone;
        private System.String   _Notes;
        private System.String   _Updated_By;
        private System.DateTime ? _Update_Date;

        private System.String _DriverClass;
        private System.String _License_Type;
        private System.String _DriverLicence;
        private System.String _DLStatus;
        private System.String _EntityDesc;
        private System.String _Gender;
      


        #endregion

        #region Public Properties


        public System.String DriverClass
        {
            get { return _DriverClass; }
            set { _DriverClass = value; }
        }


        public System.String License_Type
        {
            get { return _License_Type; }
            set { _License_Type = value; }
        }

        public System.String DriverLicence
        {
            get { return _DriverLicence; }
            set { _DriverLicence = value; }
        }

        public System.String DLStatus
        {
            get { return _DLStatus; }
            set { _DLStatus = value; }
        }

        public System.String EntityDesc
        {
            get { return _EntityDesc; }
            set { _EntityDesc = value; }
        }

        public System.String Gender
        {
            get { return _Gender; }
            set { _Gender = value; }
        }


        public System.String StateName
        {
            get { return _StateName; }
            set { _StateName = value; }
        }
        public System.Int32 PK_Property_Drivers
        {
            get { return _PK_Property_Drivers; }
            set { _PK_Property_Drivers = value; }
        }

        public System.Decimal PK_Driver_Status
        {
            get { return _PK_Driver_Status; }
            set { _PK_Driver_Status = value; }
        }
        public System.DateTime ? Status_As_Of
        {
            get { return _Status_As_Of; }
            set { _Status_As_Of = value; }
        }
        public System.Decimal PK_Entity
        {
            get { return _PK_Entity; }
            set { _PK_Entity = value; }
        }
        public System.String Last_Name
        {
            get { return _Last_Name; }
            set { _Last_Name = value; }
        }
        public System.String First_Name
        {
            get { return _First_Name; }
            set { _First_Name = value; }
        }
        public System.String Middle_Name
        {
            get { return _Middle_Name; }
            set { _Middle_Name = value; }
        }

        public System.String Work_Telephone
        {
            get { return _Work_Telephone; }
            set { _Work_Telephone = value; }
        }
        public System.String Management
        {
            get { return _Management; }
            set { _Management = value; }
        }
        public System.String Interstate
        {
            get { return _Interstate; }
            set { _Interstate = value; }
        }
        public System.String GVW
        {
            get { return _GVW; }
            set { _GVW = value; }
        }
        public System.DateTime ? Last_MVR
        {
            get { return _Last_MVR; }
            set { _Last_MVR = value; }
        }
        public System.String Address_1
        {
            get { return _Address_1; }
            set { _Address_1 = value; }
        }
        public System.String Address_2
        {
            get { return _Address_2; }
            set { _Address_2 = value; }
        }
        public System.String City
        {
            get { return _City; }
            set { _City = value; }
        }
        public System.Decimal State
        {
            get { return _State; }
            set { _State = value; }
        }

        public System.String Zip_Code
        {
            get { return _Zip_Code; }
            set { _Zip_Code = value; }
        }
        public System.String Home_Telephone
        {
            get { return _Home_Telephone; }
            set { _Home_Telephone = value; }
        }
        public System.String Cell_Phone
        {
            get { return _Cell_Phone; }
            set { _Cell_Phone = value; }
        }
        public System.String Pager
        {
            get { return _Pager; }
            set { _Pager = value; }
        }
        public System.String Email
        {
            get { return _Email; }
            set { _Email = value; }
        }
        public System.String Social_Security_Number
        {
            get { return _Social_Security_Number; }
            set { _Social_Security_Number = value; }
        }
        public System.Decimal FK_Gender
        {
            get { return _FK_Gender; }
            set { _FK_Gender = value; }
        }
        public System.DateTime ? Date_Of_Birth
        {
            get { return _Date_Of_Birth; }
            set { _Date_Of_Birth = value; }
        }
        public System.Decimal FK_DL_State
        {
            get { return _FK_DL_State; }
            set { _FK_DL_State = value; }
        }
        public System.String Drivers_License_Number
        {
            get { return _Drivers_License_Number; }
            set { _Drivers_License_Number = value; }
        }
        public System.Decimal FK_Drivers_License_Class
        {
            get { return _FK_Drivers_License_Class; }
            set { _FK_Drivers_License_Class = value; }
        }

        public System.String Drivers_License_Class
        {
            get { return _Drivers_License_Class; }
            set { _Drivers_License_Class = value; }
        }
        public System.String Restrictions
        {
            get { return _Restrictions; }
            set { _Restrictions = value; }
        }
        public System.String Endorsements
        {
            get { return _Endorsements; }
            set { _Endorsements = value; }
        }
        public System.DateTime ? DL_Begin_Date
        {
            get { return _DL_Begin_Date; }
            set { _DL_Begin_Date = value; }
        }
        public System.DateTime ? DL_End_Date
        {
            get { return _DL_End_Date; }
            set { _DL_End_Date = value; }
        }
        public System.String Supervisor_Last
        {
            get { return _Supervisor_Last; }
            set { _Supervisor_Last = value; }
        }
        public System.String Supervisor_First
        {
            get { return _Supervisor_First; }
            set { _Supervisor_First = value; }
        }
        public System.String Supervisor_Title
        {
            get { return _Supervisor_Title; }
            set { _Supervisor_Title = value; }
        }
        public System.String Supervisor_Phone
        {
            get { return _Supervisor_Phone; }
            set { _Supervisor_Phone = value; }
        }
        public System.String Notes
        {
            get { return _Notes; }
            set { _Notes = value; }
        }
        public System.String Updated_By
        {
            get { return _Updated_By; }
            set { _Updated_By = value; }
        }
        public System.DateTime ? Update_Date
        {
            get { return _Update_Date; }
            set { _Update_Date = value; }
        }

        #endregion


        #region Abstract Methods
        public abstract List<CPropertyDriver> GetAll();
        public abstract List<CPropertyDriver> GetPropertyDriverByID(System.Decimal lPK_PropertyDriver_ID);        
        public abstract List<CPropertyDriver> Get_Search_Data(System.String m_strColumn, System.String m_strCriteria);
        public abstract List<CPropertyDriver> Get_AdvanceSearch_Data(System.String LastName, System.String FirstName, System.String Address, System.String City, System.String State, System.String Zipcode);
        public abstract int PropertyDriver_InsertUpdate(RIMS_Base.CPropertyDriver Objerty_Drivers);
        public abstract int PropertyDriver_Delete(System.String lPK_PropertyDriver_ID);
        #endregion

    }
}
