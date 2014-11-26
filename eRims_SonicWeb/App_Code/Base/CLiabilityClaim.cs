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
    public abstract class CLiabilityClaim
    {

        #region Constructor
        public CLiabilityClaim()
        {
            this._pK_Liability_Claim = -1;

            this._last_Name = string.Empty;
            this._first_Name = string.Empty;
            this._middle_Name = string.Empty;

            //this._claim_Number = string.Empty;
            //this._employee = string.Empty;
            //this._fK_Employee_Claimant = -1;
            //this._owner = string.Empty;
            //this._owner_Address_1 = string.Empty;
            //this._owner_Address_2 = string.Empty;
            //this._owner_City = string.Empty;
            //this._fK_State_Owner = -1;
            //this._owner_Zip = string.Empty;
            //this._owner_Home_Phone = string.Empty;
            //this._owner_Work_Phone = string.Empty;
            //this._claim_Description = string.Empty;
            //this._nature = -1;
            //this._estimate = -1;
            //this._actual = -1;
            //this._fK_Road_Type = -1;
            //this._fK_Road_Surface = -1;
            //this._fK_Claim_Cause = -1;
            //this._fK_Body_Parts = -1;
            //this._fK_Injury = -1;
            //this._fK_NCCI_Code = -1;
            //this._vocation_Rehab = string.Empty;
            //this._fK_Liability_Major_Claim_Type = -1;
            //this._fK_Liability_Minor_Claim_Type = -1;
            //this._convertible = string.Empty;
            //this._incident_Date = DateTime.Now;
            //this._fK_Fraud_Claim = -1;
            //this._date_Reported = DateTime.Now;
            //this._claim_Open_Date = DateTime.Now;
            //this._claim_Close_Date = DateTime.Now;
            //this._claim_Reopen_Date = DateTime.Now;
            //this._surgery_Required = string.Empty;
            //this._indemnity_Weeks = -1;
            //this._fK_State_Jurisdiction = -1;
            //this._fK_Employee = -1;
            //this._reported_To_Police = string.Empty;
            //this._police_Date = DateTime.Now;
            //this._police_Case = string.Empty;
            //this._police_Officer = string.Empty;
            //this._police_Address_1 = string.Empty;
            //this._police_Address_2 = string.Empty;
            //this._police_City = string.Empty;
            //this._fK_State_Police = -1;
            //this._police_Zip_Code = string.Empty;
            //this._police_Phone = string.Empty;
            //this._police_Comments = string.Empty;
            //this._fK_Weather = string.Empty;
            //this._mobile_Restrictions = string.Empty;
            //this._mobile_Impact_Point = string.Empty;
            //this._mobile_Parts_Damaged = string.Empty;
            //this._vehicle_Make = string.Empty;
            //this._vehicle_Model = string.Empty;
            //this._vehicle_Year = -1;
            //this._vehicle_Color = string.Empty;
            //this._vehicle_Identification_Number = string.Empty;
            //this._vehicle_Value = -1;
            //this._mobile_Towed = string.Empty;
            //this._mobile_Storage_Location = string.Empty;
            //this._driver_Age = -1;
            //this._permission = string.Empty;
            //this._second_Driver_Name = string.Empty;
            //this._second_Driver_Address_1 = string.Empty;
            //this._second_Driver_Address_2 = string.Empty;
            //this._second_Driver_City = string.Empty;
            //this._fK_State_Second_Driver = -1;
            //this._second_Driver_Zip_Code = string.Empty;
            //this._second_Driver_Phone = string.Empty;
            //this._second_Driver_Ins_Company = string.Empty;
            //this._second_Driver_Ins_Number = string.Empty;
            //this._eMS_Contacted = string.Empty;
            //this._loss_Payee_Automobiles = string.Empty;
            //this._suit_Date = DateTime.Now;
            //this._attorney_Disclosure_Date = DateTime.Now;
            //this._client_Attorney_Name = string.Empty;
            //this._client_Attorney_Address_1 = string.Empty;
            //this._client_Attorney_Address_2 = string.Empty;
            //this._client_Attorney_City = string.Empty;
            //this._fK_State_Client_Attorney = -1;
            //this._client_Attorney_Zip_Code = string.Empty;
            //this._client_Attorney_Phone = string.Empty;
            //this._client_Attorney_Fax = string.Empty;
            //this._defense_Attorney_Name = string.Empty;
            //this._defense_Attorney_Address_1 = string.Empty;
            //this._defense_Attorney_Address_2 = string.Empty;
            //this._defense_Attorney_City = string.Empty;
            //this._fK_State_Defense_Attorney = -1;
            //this._defense_Attorney_Zip_Code = string.Empty;
            //this._defense_Attorney_Phone = string.Empty;
            //this._defense_Attorney_Fax = string.Empty;
            //this._updated_By = string.Empty;
            //this._update_Date = DateTime.Now;
            //this._criminal_Violation = string.Empty;
            //this._fK_Property = -1;
            //this._fK_Weather_Incident = -1;
            //this._loss_Description = string.Empty;
            //this._fK_Policy_Number = -1;
            //this._percent_Flood = -1;
            //this._percent_Wind = -1;
            //this._percent_Fire = -1;
            //this._percent_Other = -1;
            //this._date_Bus_Closed = DateTime.Now;
            //this._date_Bus_Reopened = DateTime.Now;
            //this._fK_Cost_Center = string.Empty;
            //this._building_Percent_Flood = -1;
            //this._building_Percent_Wind = -1;
            //this._building_Percent_Fire = -1;
            //this._building_Percent_Other = -1;
            //this._contents_Percent_Flood = -1;
            //this._contents_Percent_Wind = -1;
            //this._contents_Percent_Fire = -1;
            //this._contents_Percent_Other = -1;
            //this._computers_Percent_Flood = -1;
            //this._computers_Percent_Wind = -1;
            //this._computers_Percent_Fire = -1;
            //this._computers_Percent_Other = -1;
            //this._aTMs_Percent_Flood = -1;
            //this._aTMs_Percent_Wind = -1;
            //this._aTMs_Percent_Fire = -1;
            //this._aTMs_Percent_Other = -1;
            //this._leasehold_Improvements_Percent_Flood = -1;
            //this._leasehold_Improvements_Percent_Wind = -1;
            //this._leasehold_Improvements_Percent_Fire = -1;
            //this._leasehold_Improvements_Percent_Other = -1;
            //this._signs_Percent_Flood = -1;
            //this._signs_Percent_Wind = -1;
            //this._signs_Percent_Fire = -1;
            //this._signs_Percent_Other = -1;
            //this._fine_Arts_Percent_Flood = -1;
            //this._fine_Arts_Percent_Wind = -1;
            //this._fine_Arts_Percent_Fire = -1;
            //this._fine_Arts_Percent_Other = -1;
            //this._fK_NCCI_Nature = -1;
            //this._liability_Product_Name_new = string.Empty;
            //this._fK_Hazard_Code = -1;
            //this._location_Description = string.Empty;
            //this._fK_Comprehensive_Deductible = -1;
            //this._fK_Collision_Deductible = -1;
            //this._fK_Original_Cost = -1;
        }
        #endregion

        #region Private Variables

        private System.String Cliamant_last_Name;
        private System.String Cliamant_first_Name;
        private System.String Cliamant_middle_Name;




        private System.String _last_Name;
        private System.String _first_Name;
        private System.String _middle_Name;

        private System.Decimal _pK_ID;
        private System.String _cost_Center;
        private System.String _division_Name;

        private System.Int32 _pK_Liability_Claim;
        private System.String _claim_Number;
        private System.String _employee;
        private System.Decimal? _fK_Employee_Claimant;
        private System.String _owner;
        private System.String _owner_Address_1;
        private System.String _owner_Address_2;
        private System.String _owner_City;
        private System.Decimal? _fK_State_Owner;
        private System.String _owner_Zip;
        private System.String _owner_Home_Phone;
        private System.String _owner_Work_Phone;
        private System.String _claim_Description;
        private System.Decimal? _nature;
        private System.Decimal? _estimate;
        private System.Decimal? _actual;
        private System.Decimal? _fK_Road_Type;
        private System.Decimal? _fK_Road_Surface;
        private System.Decimal? _fK_Claim_Cause;
        private System.Decimal? _fK_Body_Parts;
        private System.Decimal? _fK_Injury;
        private System.Decimal? _fK_NCCI_Code;
        private System.String _vocation_Rehab;
        private System.Decimal? _fK_Liability_Major_Claim_Type;
        private System.Decimal? _fK_Liability_Minor_Claim_Type;
        private System.String _convertible;
        private System.DateTime? _incident_Date;
        private System.Decimal? _fK_Fraud_Claim;
        private System.DateTime? _date_Reported;
        private System.DateTime? _claim_Open_Date;
        private System.DateTime? _claim_Close_Date;
        private System.DateTime? _claim_Reopen_Date;
        private System.String _surgery_Required;
        private System.Decimal? _indemnity_Weeks;
        private System.Decimal? _fK_State_Jurisdiction;
        private System.Decimal? _fK_Employee;
        private System.String _reported_To_Police;
        private System.DateTime? _police_Date;
        private System.String _police_Case;
        private System.String _police_Officer;
        private System.String _police_Address_1;
        private System.String _police_Address_2;
        private System.String _police_City;
        private System.Decimal? _fK_State_Police;
        private System.String _police_Zip_Code;
        private System.String _police_Phone;
        private System.String _police_Comments;
        private System.String _fK_Weather;
        private System.String _mobile_Restrictions;
        private System.String _mobile_Impact_Point;
        private System.String _mobile_Parts_Damaged;
        private System.String _vehicle_Make;
        private System.String _vehicle_Model;
        private System.Decimal? _vehicle_Year;
        private System.String _vehicle_Color;
        private System.String _vehicle_Identification_Number;
        private System.Decimal? _vehicle_Value;
        private System.String _mobile_Towed;
        private System.String _mobile_Storage_Location;
        private System.Decimal? _driver_Age;
        private System.String _permission;
        private System.String _second_Driver_Name;
        private System.String _second_Driver_Address_1;
        private System.String _second_Driver_Address_2;
        private System.String _second_Driver_City;
        private System.Decimal? _fK_State_Second_Driver;
        private System.String _second_Driver_Zip_Code;
        private System.String _second_Driver_Phone;
        private System.String _second_Driver_Ins_Company;
        private System.String _second_Driver_Ins_Number;
        private System.String _eMS_Contacted;
        private System.String _loss_Payee_Automobiles;
        private System.DateTime? _suit_Date;
        private System.DateTime? _attorney_Disclosure_Date;
        private System.String _client_Attorney_Name;
        private System.String _client_Attorney_Address_1;
        private System.String _client_Attorney_Address_2;
        private System.String _client_Attorney_City;
        private System.Decimal? _fK_State_Client_Attorney;
        private System.String _client_Attorney_Zip_Code;
        private System.String _client_Attorney_Phone;
        private System.String _client_Attorney_Fax;
        private System.String _defense_Attorney_Name;
        private System.String _defense_Attorney_Address_1;
        private System.String _defense_Attorney_Address_2;
        private System.String _defense_Attorney_City;
        private System.Decimal? _fK_State_Defense_Attorney;
        private System.String _defense_Attorney_Zip_Code;
        private System.String _defense_Attorney_Phone;
        private System.String _defense_Attorney_Fax;
        private System.String _updated_By;
        private System.DateTime? _update_Date;
        private System.String _criminal_Violation;
        private System.Decimal? _fK_Property;
        private System.Decimal? _fK_Weather_Incident;
        private System.String _loss_Description;
        private System.Decimal? _fK_Policy_Number;
        private System.Decimal? _percent_Flood;
        private System.Decimal? _percent_Wind;
        private System.Decimal? _percent_Fire;
        private System.Decimal? _percent_Other;
        private System.DateTime? _date_Bus_Closed;
        private System.DateTime? _date_Bus_Reopened;
        private System.String _fK_Cost_Center;
        private System.Decimal? _building_Percent_Flood;
        private System.Decimal? _building_Percent_Wind;
        private System.Decimal? _building_Percent_Fire;
        private System.Decimal? _building_Percent_Other;
        private System.Decimal? _contents_Percent_Flood;
        private System.Decimal? _contents_Percent_Wind;
        private System.Decimal? _contents_Percent_Fire;
        private System.Decimal? _contents_Percent_Other;
        private System.Decimal? _computers_Percent_Flood;
        private System.Decimal? _computers_Percent_Wind;
        private System.Decimal? _computers_Percent_Fire;
        private System.Decimal? _computers_Percent_Other;
        private System.Decimal? _aTMs_Percent_Flood;
        private System.Decimal? _aTMs_Percent_Wind;
        private System.Decimal? _aTMs_Percent_Fire;
        private System.Decimal? _aTMs_Percent_Other;
        private System.Decimal? _leasehold_Improvements_Percent_Flood;
        private System.Decimal? _leasehold_Improvements_Percent_Wind;
        private System.Decimal? _leasehold_Improvements_Percent_Fire;
        private System.Decimal? _leasehold_Improvements_Percent_Other;
        private System.Decimal? _signs_Percent_Flood;
        private System.Decimal? _signs_Percent_Wind;
        private System.Decimal? _signs_Percent_Fire;
        private System.Decimal? _signs_Percent_Other;
        private System.Decimal? _fine_Arts_Percent_Flood;
        private System.Decimal? _fine_Arts_Percent_Wind;
        private System.Decimal? _fine_Arts_Percent_Fire;
        private System.Decimal? _fine_Arts_Percent_Other;
        private System.Decimal? _fK_NCCI_Nature;
        private System.String _liability_Product_Name_new;
        private System.Decimal? _fK_Hazard_Code;
        private System.String _location_Description;
        private System.Decimal? _fK_Comprehensive_Deductible;
        private System.Decimal? _fK_Collision_Deductible;
        private System.Decimal? _fK_Original_Cost;

        // Property
        private System.Int32 _pK_Property_ID;
        // private System.String _cost_Center;
        private System.String _facility;
        private System.String _property_Description;
        private System.Decimal _value;
        private System.DateTime _valuation_Date;
        private System.Decimal _premium;
        private System.Decimal _coverage;
        private System.String _mobile_Type;
        private System.String _mobile_VIN;
        private System.String _mobile_Make;
        private System.String _mobile_Model;
        private System.Decimal _mobile_Year;
        private System.String _mobile_Title;
        private System.String _stationary_Type;
        private System.Decimal _stationary_Year;
        private System.String _stationary_Address_1;
        private System.String _stationary_Address_2;
        private System.String _stationary_City;
        private System.String _stationary_State;
        private System.String _stationary_Zip;
        private System.String _stationary_Category;
        private System.String _stationary_Title;
        private System.String _stationary_Deed;
        private System.String _stationary_Safety;
        private System.String _stationary_Security;
        private System.String _stationary_Flood_Zone;
        private System.String _stationary_Foreclosure;
        private System.String _foreclosed;
        private System.String _contact_Name;
        private System.String _contact_Phone;
        private System.String _contact_Facsimile;
        private System.String _emergency_Police;
        private System.String _emergency_Fire;
        private System.String _emergency_Sheriff;
        private System.String _emergency_State_Police;
        private System.String _emergency_Ambulance;
        private System.String _emergency_FBI;
        private System.String _emergency_Secret_Service;
        private System.String _phone_Company_Contact;
        private System.String _phone_Company_Telephone;
        private System.String _power_Company_Contact;
        private System.String _power_Company_Telephone;
        private System.String _water_Utility_Contact;
        private System.String _water_Utility_Telephone;
        private System.String _gas_Utility_Contact;
        private System.String _gas_Utility_Telephone;
        private System.String _cleaning_Company_Contact;
        private System.String _cleaning_Company_Telephone;
        private System.String _cleaning_Company_Contract;
        private System.DateTime _cleaning_Company_Date;
        private System.String _courier_Company_Contact;
        private System.String _courier_Company_Telephone;
        private System.String _courier_Company_Contract;
        private System.DateTime _courier_Company_Date;
        private System.String _after_Hours_Contact;
        private System.String _after_Hours_Phone;
        private System.String _after_Hours_Cell;
        private System.String _after_Hours_Pager;
        private System.String _contact_For_1;
        private System.String _special_Contact_1;
        private System.String _special_Phone_1;
        private System.String _special_Cell_1;
        private System.String _special_Pager_1;
        private System.String _contact_For_2;
        private System.String _special_Contact_2;
        private System.String _special_Phone_2;
        private System.String _special_Cell_2;
        private System.String _special_Pager_2;
        private System.String _contact_For_3;
        private System.String _special_Contact_3;
        private System.String _special_Phone_3;
        private System.String _special_Cell_3;
        private System.String _special_Pager_3;
        private System.String _open_Time;
        private System.String _close_Time;
        private System.Decimal _number_Of_Employees;
        private System.String _aTM;
        private System.String _aTM_Location;
        //private System.String _updated_By;
        //private System.DateTime _update_Date;
        private System.Decimal? _fK_Entity;
        private System.String _property_Name;
        private System.String _fK_County_property;
        private System.String _county_Tier_1;
        private System.String _county_Tri_County;
        private System.Decimal? _fK_Land_Status;
        private System.Decimal _acreage;
        private System.Decimal _road_Frontage;
        private System.String _road_Frontage_Units;
        private System.String _occupancy;
        private System.String _flood_Zone;
        private System.Decimal _number_Of_Employees1;
        private System.Decimal _building;
        private System.Decimal _signs;
        private System.Decimal _contents;
        private System.Decimal _computers;
        private System.Decimal _aTMs;
        private System.Decimal _lease_Improvements;
        private System.Decimal _total;
        private System.Decimal _gross_Sq_Feet;
        private System.Decimal _public_Acc_Sq_Feet;
        private System.Decimal _stories_Up;
        private System.Decimal _stories_Down;
        private System.Decimal _construction_Cost;
        private System.String _construction_Type;
        private System.Decimal _year_Built;
        private System.DateTime _purchase_Date;
        private System.Decimal _purchase_Price;
        private System.Decimal _sprinkler;
        private System.Decimal _fire_Alarms;
        private System.String _security_Alarm;
        private System.Decimal _security_Console;
        private System.String _ownership;
        private System.Decimal _number_Vaults;
        private System.Decimal _number_DU_Windows;
        private System.Decimal _number_SD_Boxes;
        private System.Decimal _number_WU_ATMs;
        private System.Decimal _number_DU_ATMs;
        private System.Decimal _regions_Lessor;
        private System.Decimal _net_Leasable_Sq_Ft;
        private System.Decimal _current_Monthly_Rent;
        private System.String _ocupancy_Rent;
        private System.Decimal _fine_Arts;
        private System.Decimal _rental_Income;
        private System.String _aTM_Vendor_Contact;
        private System.String _aTM_Telephone;
        private System.String _aTM_Contract;
        private System.DateTime _aTM_Date;
        private System.String _monday_Open;
        private System.String _monday_Close;
        private System.String _tuesday_Open;
        private System.String _tuesday_Close;
        private System.String _wednesday_Open;
        private System.String _wednesday_Close;
        private System.String _thursday_Open;
        private System.String _thursday_Close;
        private System.String _friday_Open;
        private System.String _friday_Close;
        private System.String _saturday_Open;
        private System.String _saturday_Close;
        private System.String _sunday_Open;
        private System.String _sunday_Close;
        private System.Decimal _cash_Chests;
        private System.String _tenant_Type;
        private System.Decimal _lessee;
        private System.Decimal _lessee_Rent_Sq_Ft;
        private System.String _sA_SECURITY_CONSOLE;



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
        public System.String Division_Name
        {
            get { return _division_Name; }
            set { _division_Name = value; }
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

        public System.String Employee
        {
            get { return _employee; }
            set { _employee = value; }
        }

        public System.Decimal? FK_Employee_Claimant
        {
            get { return _fK_Employee_Claimant; }
            set { _fK_Employee_Claimant = value; }
        }

        public System.String Owner
        {
            get { return _owner; }
            set { _owner = value; }
        }

        public System.String Owner_Address_1
        {
            get { return _owner_Address_1; }
            set { _owner_Address_1 = value; }
        }

        public System.String Owner_Address_2
        {
            get { return _owner_Address_2; }
            set { _owner_Address_2 = value; }
        }

        public System.String Owner_City
        {
            get { return _owner_City; }
            set { _owner_City = value; }
        }

        public System.Decimal? FK_State_Owner
        {
            get { return _fK_State_Owner; }
            set { _fK_State_Owner = value; }
        }

        public System.String Owner_Zip
        {
            get { return _owner_Zip; }
            set { _owner_Zip = value; }
        }

        public System.String Owner_Home_Phone
        {
            get { return _owner_Home_Phone; }
            set { _owner_Home_Phone = value; }
        }

        public System.String Owner_Work_Phone
        {
            get { return _owner_Work_Phone; }
            set { _owner_Work_Phone = value; }
        }

        public System.String Claim_Description
        {
            get { return _claim_Description; }
            set { _claim_Description = value; }
        }

        public System.Decimal? Nature
        {
            get { return _nature; }
            set { _nature = value; }
        }

        public System.Decimal? Estimate
        {
            get { return _estimate; }
            set { _estimate = value; }
        }

        public System.Decimal? Actual
        {
            get { return _actual; }
            set { _actual = value; }
        }

        public System.Decimal? FK_Road_Type
        {
            get { return _fK_Road_Type; }
            set { _fK_Road_Type = value; }
        }

        public System.Decimal? FK_Road_Surface
        {
            get { return _fK_Road_Surface; }
            set { _fK_Road_Surface = value; }
        }

        public System.Decimal? FK_Claim_Cause
        {
            get { return _fK_Claim_Cause; }
            set { _fK_Claim_Cause = value; }
        }

        public System.Decimal? FK_Body_Parts
        {
            get { return _fK_Body_Parts; }
            set { _fK_Body_Parts = value; }
        }

        public System.Decimal? FK_Injury
        {
            get { return _fK_Injury; }
            set { _fK_Injury = value; }
        }

        public System.Decimal? FK_NCCI_Code
        {
            get { return _fK_NCCI_Code; }
            set { _fK_NCCI_Code = value; }
        }

        public System.String Vocation_Rehab
        {
            get { return _vocation_Rehab; }
            set { _vocation_Rehab = value; }
        }

        public System.Decimal? FK_Liability_Major_Claim_Type
        {
            get { return _fK_Liability_Major_Claim_Type; }
            set { _fK_Liability_Major_Claim_Type = value; }
        }

        public System.Decimal? FK_Liability_Minor_Claim_Type
        {
            get { return _fK_Liability_Minor_Claim_Type; }
            set { _fK_Liability_Minor_Claim_Type = value; }
        }

        public System.String Convertible
        {
            get { return _convertible; }
            set { _convertible = value; }
        }

        public System.DateTime? Incident_Date
        {
            get { return _incident_Date; }
            set { _incident_Date = value; }
        }

        public System.Decimal? FK_Fraud_Claim
        {
            get { return _fK_Fraud_Claim; }
            set { _fK_Fraud_Claim = value; }
        }

        public System.DateTime? Date_Reported
        {
            get { return _date_Reported; }
            set { _date_Reported = value; }
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

        public System.String Surgery_Required
        {
            get { return _surgery_Required; }
            set { _surgery_Required = value; }
        }

        public System.Decimal? Indemnity_Weeks
        {
            get { return _indemnity_Weeks; }
            set { _indemnity_Weeks = value; }
        }

        public System.Decimal? FK_State_Jurisdiction
        {
            get { return _fK_State_Jurisdiction; }
            set { _fK_State_Jurisdiction = value; }
        }

        public System.Decimal? FK_Employee
        {
            get { return _fK_Employee; }
            set { _fK_Employee = value; }
        }

        public System.String Reported_To_Police
        {
            get { return _reported_To_Police; }
            set { _reported_To_Police = value; }
        }

        public System.DateTime? Police_Date
        {
            get { return _police_Date; }
            set { _police_Date = value; }
        }

        public System.String Police_Case
        {
            get { return _police_Case; }
            set { _police_Case = value; }
        }

        public System.String Police_Officer
        {
            get { return _police_Officer; }
            set { _police_Officer = value; }
        }

        public System.String Police_Address_1
        {
            get { return _police_Address_1; }
            set { _police_Address_1 = value; }
        }

        public System.String Police_Address_2
        {
            get { return _police_Address_2; }
            set { _police_Address_2 = value; }
        }

        public System.String Police_City
        {
            get { return _police_City; }
            set { _police_City = value; }
        }

        public System.Decimal? FK_State_Police
        {
            get { return _fK_State_Police; }
            set { _fK_State_Police = value; }
        }

        public System.String Police_Zip_Code
        {
            get { return _police_Zip_Code; }
            set { _police_Zip_Code = value; }
        }

        public System.String Police_Phone
        {
            get { return _police_Phone; }
            set { _police_Phone = value; }
        }

        public System.String Police_Comments
        {
            get { return _police_Comments; }
            set { _police_Comments = value; }
        }

        public System.String FK_Weather
        {
            get { return _fK_Weather; }
            set { _fK_Weather = value; }
        }

        public System.String Mobile_Restrictions
        {
            get { return _mobile_Restrictions; }
            set { _mobile_Restrictions = value; }
        }

        public System.String Mobile_Impact_Point
        {
            get { return _mobile_Impact_Point; }
            set { _mobile_Impact_Point = value; }
        }

        public System.String Mobile_Parts_Damaged
        {
            get { return _mobile_Parts_Damaged; }
            set { _mobile_Parts_Damaged = value; }
        }

        public System.String Vehicle_Make
        {
            get { return _vehicle_Make; }
            set { _vehicle_Make = value; }
        }

        public System.String Vehicle_Model
        {
            get { return _vehicle_Model; }
            set { _vehicle_Model = value; }
        }

        public System.Decimal? Vehicle_Year
        {
            get { return _vehicle_Year; }
            set { _vehicle_Year = value; }
        }

        public System.String Vehicle_Color
        {
            get { return _vehicle_Color; }
            set { _vehicle_Color = value; }
        }

        public System.String Vehicle_Identification_Number
        {
            get { return _vehicle_Identification_Number; }
            set { _vehicle_Identification_Number = value; }
        }

        public System.Decimal? Vehicle_Value
        {
            get { return _vehicle_Value; }
            set { _vehicle_Value = value; }
        }

        public System.String Mobile_Towed
        {
            get { return _mobile_Towed; }
            set { _mobile_Towed = value; }
        }

        public System.String Mobile_Storage_Location
        {
            get { return _mobile_Storage_Location; }
            set { _mobile_Storage_Location = value; }
        }

        public System.Decimal? Driver_Age
        {
            get { return _driver_Age; }
            set { _driver_Age = value; }
        }

        public System.String Permission
        {
            get { return _permission; }
            set { _permission = value; }
        }

        public System.String Second_Driver_Name
        {
            get { return _second_Driver_Name; }
            set { _second_Driver_Name = value; }
        }

        public System.String Second_Driver_Address_1
        {
            get { return _second_Driver_Address_1; }
            set { _second_Driver_Address_1 = value; }
        }

        public System.String Second_Driver_Address_2
        {
            get { return _second_Driver_Address_2; }
            set { _second_Driver_Address_2 = value; }
        }

        public System.String Second_Driver_City
        {
            get { return _second_Driver_City; }
            set { _second_Driver_City = value; }
        }

        public System.Decimal? FK_State_Second_Driver
        {
            get { return _fK_State_Second_Driver; }
            set { _fK_State_Second_Driver = value; }
        }

        public System.String Second_Driver_Zip_Code
        {
            get { return _second_Driver_Zip_Code; }
            set { _second_Driver_Zip_Code = value; }
        }

        public System.String Second_Driver_Phone
        {
            get { return _second_Driver_Phone; }
            set { _second_Driver_Phone = value; }
        }

        public System.String Second_Driver_Ins_Company
        {
            get { return _second_Driver_Ins_Company; }
            set { _second_Driver_Ins_Company = value; }
        }

        public System.String Second_Driver_Ins_Number
        {
            get { return _second_Driver_Ins_Number; }
            set { _second_Driver_Ins_Number = value; }
        }

        public System.String EMS_Contacted
        {
            get { return _eMS_Contacted; }
            set { _eMS_Contacted = value; }
        }

        public System.String Loss_Payee_Automobiles
        {
            get { return _loss_Payee_Automobiles; }
            set { _loss_Payee_Automobiles = value; }
        }

        public System.DateTime? Suit_Date
        {
            get { return _suit_Date; }
            set { _suit_Date = value; }
        }

        public System.DateTime? Attorney_Disclosure_Date
        {
            get { return _attorney_Disclosure_Date; }
            set { _attorney_Disclosure_Date = value; }
        }

        public System.String Client_Attorney_Name
        {
            get { return _client_Attorney_Name; }
            set { _client_Attorney_Name = value; }
        }

        public System.String Client_Attorney_Address_1
        {
            get { return _client_Attorney_Address_1; }
            set { _client_Attorney_Address_1 = value; }
        }

        public System.String Client_Attorney_Address_2
        {
            get { return _client_Attorney_Address_2; }
            set { _client_Attorney_Address_2 = value; }
        }

        public System.String Client_Attorney_City
        {
            get { return _client_Attorney_City; }
            set { _client_Attorney_City = value; }
        }

        public System.Decimal? FK_State_Client_Attorney
        {
            get { return _fK_State_Client_Attorney; }
            set { _fK_State_Client_Attorney = value; }
        }

        public System.String Client_Attorney_Zip_Code
        {
            get { return _client_Attorney_Zip_Code; }
            set { _client_Attorney_Zip_Code = value; }
        }

        public System.String Client_Attorney_Phone
        {
            get { return _client_Attorney_Phone; }
            set { _client_Attorney_Phone = value; }
        }

        public System.String Client_Attorney_Fax
        {
            get { return _client_Attorney_Fax; }
            set { _client_Attorney_Fax = value; }
        }

        public System.String Defense_Attorney_Name
        {
            get { return _defense_Attorney_Name; }
            set { _defense_Attorney_Name = value; }
        }

        public System.String Defense_Attorney_Address_1
        {
            get { return _defense_Attorney_Address_1; }
            set { _defense_Attorney_Address_1 = value; }
        }

        public System.String Defense_Attorney_Address_2
        {
            get { return _defense_Attorney_Address_2; }
            set { _defense_Attorney_Address_2 = value; }
        }

        public System.String Defense_Attorney_City
        {
            get { return _defense_Attorney_City; }
            set { _defense_Attorney_City = value; }
        }

        public System.Decimal? FK_State_Defense_Attorney
        {
            get { return _fK_State_Defense_Attorney; }
            set { _fK_State_Defense_Attorney = value; }
        }

        public System.String Defense_Attorney_Zip_Code
        {
            get { return _defense_Attorney_Zip_Code; }
            set { _defense_Attorney_Zip_Code = value; }
        }

        public System.String Defense_Attorney_Phone
        {
            get { return _defense_Attorney_Phone; }
            set { _defense_Attorney_Phone = value; }
        }

        public System.String Defense_Attorney_Fax
        {
            get { return _defense_Attorney_Fax; }
            set { _defense_Attorney_Fax = value; }
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

        public System.String Criminal_Violation
        {
            get { return _criminal_Violation; }
            set { _criminal_Violation = value; }
        }

        public System.Decimal? FK_Property
        {
            get { return _fK_Property; }
            set { _fK_Property = value; }
        }

        public System.Decimal? FK_Weather_Incident
        {
            get { return _fK_Weather_Incident; }
            set { _fK_Weather_Incident = value; }
        }

        public System.String Loss_Description
        {
            get { return _loss_Description; }
            set { _loss_Description = value; }
        }

        public System.Decimal? FK_Policy_Number
        {
            get { return _fK_Policy_Number; }
            set { _fK_Policy_Number = value; }
        }

        public System.Decimal? Percent_Flood
        {
            get { return _percent_Flood; }
            set { _percent_Flood = value; }
        }

        public System.Decimal? Percent_Wind
        {
            get { return _percent_Wind; }
            set { _percent_Wind = value; }
        }

        public System.Decimal? Percent_Fire
        {
            get { return _percent_Fire; }
            set { _percent_Fire = value; }
        }

        public System.Decimal? Percent_Other
        {
            get { return _percent_Other; }
            set { _percent_Other = value; }
        }

        public System.DateTime? Date_Bus_Closed
        {
            get { return _date_Bus_Closed; }
            set { _date_Bus_Closed = value; }
        }

        public System.DateTime? Date_Bus_Reopened
        {
            get { return _date_Bus_Reopened; }
            set { _date_Bus_Reopened = value; }
        }

        public System.String FK_Cost_Center
        {
            get { return _fK_Cost_Center; }
            set { _fK_Cost_Center = value; }
        }

        public System.Decimal? Building_Percent_Flood
        {
            get { return _building_Percent_Flood; }
            set { _building_Percent_Flood = value; }
        }

        public System.Decimal? Building_Percent_Wind
        {
            get { return _building_Percent_Wind; }
            set { _building_Percent_Wind = value; }
        }

        public System.Decimal? Building_Percent_Fire
        {
            get { return _building_Percent_Fire; }
            set { _building_Percent_Fire = value; }
        }

        public System.Decimal? Building_Percent_Other
        {
            get { return _building_Percent_Other; }
            set { _building_Percent_Other = value; }
        }

        public System.Decimal? Contents_Percent_Flood
        {
            get { return _contents_Percent_Flood; }
            set { _contents_Percent_Flood = value; }
        }

        public System.Decimal? Contents_Percent_Wind
        {
            get { return _contents_Percent_Wind; }
            set { _contents_Percent_Wind = value; }
        }

        public System.Decimal? Contents_Percent_Fire
        {
            get { return _contents_Percent_Fire; }
            set { _contents_Percent_Fire = value; }
        }

        public System.Decimal? Contents_Percent_Other
        {
            get { return _contents_Percent_Other; }
            set { _contents_Percent_Other = value; }
        }

        public System.Decimal? Computers_Percent_Flood
        {
            get { return _computers_Percent_Flood; }
            set { _computers_Percent_Flood = value; }
        }

        public System.Decimal? Computers_Percent_Wind
        {
            get { return _computers_Percent_Wind; }
            set { _computers_Percent_Wind = value; }
        }

        public System.Decimal? Computers_Percent_Fire
        {
            get { return _computers_Percent_Fire; }
            set { _computers_Percent_Fire = value; }
        }

        public System.Decimal? Computers_Percent_Other
        {
            get { return _computers_Percent_Other; }
            set { _computers_Percent_Other = value; }
        }

        public System.Decimal? ATMs_Percent_Flood
        {
            get { return _aTMs_Percent_Flood; }
            set { _aTMs_Percent_Flood = value; }
        }

        public System.Decimal? ATMs_Percent_Wind
        {
            get { return _aTMs_Percent_Wind; }
            set { _aTMs_Percent_Wind = value; }
        }

        public System.Decimal? ATMs_Percent_Fire
        {
            get { return _aTMs_Percent_Fire; }
            set { _aTMs_Percent_Fire = value; }
        }

        public System.Decimal? ATMs_Percent_Other
        {
            get { return _aTMs_Percent_Other; }
            set { _aTMs_Percent_Other = value; }
        }

        public System.Decimal? Leasehold_Improvements_Percent_Flood
        {
            get { return _leasehold_Improvements_Percent_Flood; }
            set { _leasehold_Improvements_Percent_Flood = value; }
        }

        public System.Decimal? Leasehold_Improvements_Percent_Wind
        {
            get { return _leasehold_Improvements_Percent_Wind; }
            set { _leasehold_Improvements_Percent_Wind = value; }
        }

        public System.Decimal? Leasehold_Improvements_Percent_Fire
        {
            get { return _leasehold_Improvements_Percent_Fire; }
            set { _leasehold_Improvements_Percent_Fire = value; }
        }

        public System.Decimal? Leasehold_Improvements_Percent_Other
        {
            get { return _leasehold_Improvements_Percent_Other; }
            set { _leasehold_Improvements_Percent_Other = value; }
        }

        public System.Decimal? Signs_Percent_Flood
        {
            get { return _signs_Percent_Flood; }
            set { _signs_Percent_Flood = value; }
        }

        public System.Decimal? Signs_Percent_Wind
        {
            get { return _signs_Percent_Wind; }
            set { _signs_Percent_Wind = value; }
        }

        public System.Decimal? Signs_Percent_Fire
        {
            get { return _signs_Percent_Fire; }
            set { _signs_Percent_Fire = value; }
        }

        public System.Decimal? Signs_Percent_Other
        {
            get { return _signs_Percent_Other; }
            set { _signs_Percent_Other = value; }
        }

        public System.Decimal? Fine_Arts_Percent_Flood
        {
            get { return _fine_Arts_Percent_Flood; }
            set { _fine_Arts_Percent_Flood = value; }
        }

        public System.Decimal? Fine_Arts_Percent_Wind
        {
            get { return _fine_Arts_Percent_Wind; }
            set { _fine_Arts_Percent_Wind = value; }
        }

        public System.Decimal? Fine_Arts_Percent_Fire
        {
            get { return _fine_Arts_Percent_Fire; }
            set { _fine_Arts_Percent_Fire = value; }
        }

        public System.Decimal? Fine_Arts_Percent_Other
        {
            get { return _fine_Arts_Percent_Other; }
            set { _fine_Arts_Percent_Other = value; }
        }

        public System.Decimal? FK_NCCI_Nature
        {
            get { return _fK_NCCI_Nature; }
            set { _fK_NCCI_Nature = value; }
        }

        public System.String Liability_Product_Name_new
        {
            get { return _liability_Product_Name_new; }
            set { _liability_Product_Name_new = value; }
        }

        public System.Decimal? FK_Hazard_Code
        {
            get { return _fK_Hazard_Code; }
            set { _fK_Hazard_Code = value; }
        }

        public System.String Location_Description
        {
            get { return _location_Description; }
            set { _location_Description = value; }
        }

        public System.Decimal? FK_Comprehensive_Deductible
        {
            get { return _fK_Comprehensive_Deductible; }
            set { _fK_Comprehensive_Deductible = value; }
        }

        public System.Decimal? FK_Collision_Deductible
        {
            get { return _fK_Collision_Deductible; }
            set { _fK_Collision_Deductible = value; }
        }

        public System.Decimal? FK_Original_Cost
        {
            get { return _fK_Original_Cost; }
            set { _fK_Original_Cost = value; }
        }




        //...............................Prpoerty......................................


        public System.Int32 PK_Property_ID
        {
            get { return _pK_Property_ID; }
            set { _pK_Property_ID = value; }
        }

        //public System.String Cost_Center
        //{
        //    get { return _cost_Center; }
        //    set { _cost_Center = value; }
        //}

        public System.String Facility
        {
            get { return _facility; }
            set { _facility = value; }
        }

        public System.String Property_Description
        {
            get { return _property_Description; }
            set { _property_Description = value; }
        }

        public System.Decimal Value
        {
            get { return _value; }
            set { _value = value; }
        }

        public System.DateTime Valuation_Date
        {
            get { return _valuation_Date; }
            set { _valuation_Date = value; }
        }

        public System.Decimal Premium
        {
            get { return _premium; }
            set { _premium = value; }
        }

        public System.Decimal Coverage
        {
            get { return _coverage; }
            set { _coverage = value; }
        }

        public System.String Mobile_Type
        {
            get { return _mobile_Type; }
            set { _mobile_Type = value; }
        }

        public System.String Mobile_VIN
        {
            get { return _mobile_VIN; }
            set { _mobile_VIN = value; }
        }

        public System.String Mobile_Make
        {
            get { return _mobile_Make; }
            set { _mobile_Make = value; }
        }

        public System.String Mobile_Model
        {
            get { return _mobile_Model; }
            set { _mobile_Model = value; }
        }

        public System.Decimal Mobile_Year
        {
            get { return _mobile_Year; }
            set { _mobile_Year = value; }
        }

        public System.String Mobile_Title
        {
            get { return _mobile_Title; }
            set { _mobile_Title = value; }
        }

        public System.String Stationary_Type
        {
            get { return _stationary_Type; }
            set { _stationary_Type = value; }
        }

        public System.Decimal Stationary_Year
        {
            get { return _stationary_Year; }
            set { _stationary_Year = value; }
        }

        public System.String Stationary_Address_1
        {
            get { return _stationary_Address_1; }
            set { _stationary_Address_1 = value; }
        }

        public System.String Stationary_Address_2
        {
            get { return _stationary_Address_2; }
            set { _stationary_Address_2 = value; }
        }

        public System.String Stationary_City
        {
            get { return _stationary_City; }
            set { _stationary_City = value; }
        }

        public System.String Stationary_State
        {
            get { return _stationary_State; }
            set { _stationary_State = value; }
        }

        public System.String Stationary_Zip
        {
            get { return _stationary_Zip; }
            set { _stationary_Zip = value; }
        }

        public System.String Stationary_Category
        {
            get { return _stationary_Category; }
            set { _stationary_Category = value; }
        }

        public System.String Stationary_Title
        {
            get { return _stationary_Title; }
            set { _stationary_Title = value; }
        }

        public System.String Stationary_Deed
        {
            get { return _stationary_Deed; }
            set { _stationary_Deed = value; }
        }

        public System.String Stationary_Safety
        {
            get { return _stationary_Safety; }
            set { _stationary_Safety = value; }
        }

        public System.String Stationary_Security
        {
            get { return _stationary_Security; }
            set { _stationary_Security = value; }
        }

        public System.String Stationary_Flood_Zone
        {
            get { return _stationary_Flood_Zone; }
            set { _stationary_Flood_Zone = value; }
        }

        public System.String Stationary_Foreclosure
        {
            get { return _stationary_Foreclosure; }
            set { _stationary_Foreclosure = value; }
        }

        public System.String Foreclosed
        {
            get { return _foreclosed; }
            set { _foreclosed = value; }
        }

        public System.String Contact_Name
        {
            get { return _contact_Name; }
            set { _contact_Name = value; }
        }

        public System.String Contact_Phone
        {
            get { return _contact_Phone; }
            set { _contact_Phone = value; }
        }

        public System.String Contact_Facsimile
        {
            get { return _contact_Facsimile; }
            set { _contact_Facsimile = value; }
        }

        public System.String Emergency_Police
        {
            get { return _emergency_Police; }
            set { _emergency_Police = value; }
        }

        public System.String Emergency_Fire
        {
            get { return _emergency_Fire; }
            set { _emergency_Fire = value; }
        }

        public System.String Emergency_Sheriff
        {
            get { return _emergency_Sheriff; }
            set { _emergency_Sheriff = value; }
        }

        public System.String Emergency_State_Police
        {
            get { return _emergency_State_Police; }
            set { _emergency_State_Police = value; }
        }

        public System.String Emergency_Ambulance
        {
            get { return _emergency_Ambulance; }
            set { _emergency_Ambulance = value; }
        }

        public System.String Emergency_FBI
        {
            get { return _emergency_FBI; }
            set { _emergency_FBI = value; }
        }

        public System.String Emergency_Secret_Service
        {
            get { return _emergency_Secret_Service; }
            set { _emergency_Secret_Service = value; }
        }

        public System.String Phone_Company_Contact
        {
            get { return _phone_Company_Contact; }
            set { _phone_Company_Contact = value; }
        }

        public System.String Phone_Company_Telephone
        {
            get { return _phone_Company_Telephone; }
            set { _phone_Company_Telephone = value; }
        }

        public System.String Power_Company_Contact
        {
            get { return _power_Company_Contact; }
            set { _power_Company_Contact = value; }
        }

        public System.String Power_Company_Telephone
        {
            get { return _power_Company_Telephone; }
            set { _power_Company_Telephone = value; }
        }

        public System.String Water_Utility_Contact
        {
            get { return _water_Utility_Contact; }
            set { _water_Utility_Contact = value; }
        }

        public System.String Water_Utility_Telephone
        {
            get { return _water_Utility_Telephone; }
            set { _water_Utility_Telephone = value; }
        }

        public System.String Gas_Utility_Contact
        {
            get { return _gas_Utility_Contact; }
            set { _gas_Utility_Contact = value; }
        }

        public System.String Gas_Utility_Telephone
        {
            get { return _gas_Utility_Telephone; }
            set { _gas_Utility_Telephone = value; }
        }

        public System.String Cleaning_Company_Contact
        {
            get { return _cleaning_Company_Contact; }
            set { _cleaning_Company_Contact = value; }
        }

        public System.String Cleaning_Company_Telephone
        {
            get { return _cleaning_Company_Telephone; }
            set { _cleaning_Company_Telephone = value; }
        }

        public System.String Cleaning_Company_Contract
        {
            get { return _cleaning_Company_Contract; }
            set { _cleaning_Company_Contract = value; }
        }

        public System.DateTime Cleaning_Company_Date
        {
            get { return _cleaning_Company_Date; }
            set { _cleaning_Company_Date = value; }
        }

        public System.String Courier_Company_Contact
        {
            get { return _courier_Company_Contact; }
            set { _courier_Company_Contact = value; }
        }

        public System.String Courier_Company_Telephone
        {
            get { return _courier_Company_Telephone; }
            set { _courier_Company_Telephone = value; }
        }

        public System.String Courier_Company_Contract
        {
            get { return _courier_Company_Contract; }
            set { _courier_Company_Contract = value; }
        }

        public System.DateTime Courier_Company_Date
        {
            get { return _courier_Company_Date; }
            set { _courier_Company_Date = value; }
        }

        public System.String After_Hours_Contact
        {
            get { return _after_Hours_Contact; }
            set { _after_Hours_Contact = value; }
        }

        public System.String After_Hours_Phone
        {
            get { return _after_Hours_Phone; }
            set { _after_Hours_Phone = value; }
        }

        public System.String After_Hours_Cell
        {
            get { return _after_Hours_Cell; }
            set { _after_Hours_Cell = value; }
        }

        public System.String After_Hours_Pager
        {
            get { return _after_Hours_Pager; }
            set { _after_Hours_Pager = value; }
        }

        public System.String Contact_For_1
        {
            get { return _contact_For_1; }
            set { _contact_For_1 = value; }
        }

        public System.String Special_Contact_1
        {
            get { return _special_Contact_1; }
            set { _special_Contact_1 = value; }
        }

        public System.String Special_Phone_1
        {
            get { return _special_Phone_1; }
            set { _special_Phone_1 = value; }
        }

        public System.String Special_Cell_1
        {
            get { return _special_Cell_1; }
            set { _special_Cell_1 = value; }
        }

        public System.String Special_Pager_1
        {
            get { return _special_Pager_1; }
            set { _special_Pager_1 = value; }
        }

        public System.String Contact_For_2
        {
            get { return _contact_For_2; }
            set { _contact_For_2 = value; }
        }

        public System.String Special_Contact_2
        {
            get { return _special_Contact_2; }
            set { _special_Contact_2 = value; }
        }

        public System.String Special_Phone_2
        {
            get { return _special_Phone_2; }
            set { _special_Phone_2 = value; }
        }

        public System.String Special_Cell_2
        {
            get { return _special_Cell_2; }
            set { _special_Cell_2 = value; }
        }

        public System.String Special_Pager_2
        {
            get { return _special_Pager_2; }
            set { _special_Pager_2 = value; }
        }

        public System.String Contact_For_3
        {
            get { return _contact_For_3; }
            set { _contact_For_3 = value; }
        }

        public System.String Special_Contact_3
        {
            get { return _special_Contact_3; }
            set { _special_Contact_3 = value; }
        }

        public System.String Special_Phone_3
        {
            get { return _special_Phone_3; }
            set { _special_Phone_3 = value; }
        }

        public System.String Special_Cell_3
        {
            get { return _special_Cell_3; }
            set { _special_Cell_3 = value; }
        }

        public System.String Special_Pager_3
        {
            get { return _special_Pager_3; }
            set { _special_Pager_3 = value; }
        }

        public System.String Open_Time
        {
            get { return _open_Time; }
            set { _open_Time = value; }
        }

        public System.String Close_Time
        {
            get { return _close_Time; }
            set { _close_Time = value; }
        }

        public System.Decimal Number_Of_Employees
        {
            get { return _number_Of_Employees; }
            set { _number_Of_Employees = value; }
        }

        public System.String ATM
        {
            get { return _aTM; }
            set { _aTM = value; }
        }

        public System.String ATM_Location
        {
            get { return _aTM_Location; }
            set { _aTM_Location = value; }
        }



        public System.Decimal? FK_Entity
        {
            get { return _fK_Entity; }
            set { _fK_Entity = value; }
        }

        public System.String Property_Name
        {
            get { return _property_Name; }
            set { _property_Name = value; }
        }

        public System.String FK_County_property
        {
            get { return _fK_County_property; }
            set { _fK_County_property = value; }
        }

        public System.String County_Tier_1
        {
            get { return _county_Tier_1; }
            set { _county_Tier_1 = value; }
        }

        public System.String County_Tri_County
        {
            get { return _county_Tri_County; }
            set { _county_Tri_County = value; }
        }

        public System.Decimal? FK_Land_Status
        {
            get { return _fK_Land_Status; }
            set { _fK_Land_Status = value; }
        }

        public System.Decimal Acreage
        {
            get { return _acreage; }
            set { _acreage = value; }
        }

        public System.Decimal Road_Frontage
        {
            get { return _road_Frontage; }
            set { _road_Frontage = value; }
        }

        public System.String Road_Frontage_Units
        {
            get { return _road_Frontage_Units; }
            set { _road_Frontage_Units = value; }
        }

        public System.String Occupancy
        {
            get { return _occupancy; }
            set { _occupancy = value; }
        }

        public System.String Flood_Zone
        {
            get { return _flood_Zone; }
            set { _flood_Zone = value; }
        }

        public System.Decimal Number_Of_Employees1
        {
            get { return _number_Of_Employees1; }
            set { _number_Of_Employees1 = value; }
        }

        public System.Decimal Building
        {
            get { return _building; }
            set { _building = value; }
        }

        public System.Decimal Signs
        {
            get { return _signs; }
            set { _signs = value; }
        }

        public System.Decimal Contents
        {
            get { return _contents; }
            set { _contents = value; }
        }

        public System.Decimal Computers
        {
            get { return _computers; }
            set { _computers = value; }
        }

        public System.Decimal ATMs
        {
            get { return _aTMs; }
            set { _aTMs = value; }
        }

        public System.Decimal Lease_Improvements
        {
            get { return _lease_Improvements; }
            set { _lease_Improvements = value; }
        }

        public System.Decimal Total
        {
            get { return _total; }
            set { _total = value; }
        }

        public System.Decimal Gross_Sq_Feet
        {
            get { return _gross_Sq_Feet; }
            set { _gross_Sq_Feet = value; }
        }

        public System.Decimal Public_Acc_Sq_Feet
        {
            get { return _public_Acc_Sq_Feet; }
            set { _public_Acc_Sq_Feet = value; }
        }

        public System.Decimal Stories_Up
        {
            get { return _stories_Up; }
            set { _stories_Up = value; }
        }

        public System.Decimal Stories_Down
        {
            get { return _stories_Down; }
            set { _stories_Down = value; }
        }

        public System.Decimal Construction_Cost
        {
            get { return _construction_Cost; }
            set { _construction_Cost = value; }
        }

        public System.String Construction_Type
        {
            get { return _construction_Type; }
            set { _construction_Type = value; }
        }

        public System.Decimal Year_Built
        {
            get { return _year_Built; }
            set { _year_Built = value; }
        }

        public System.DateTime Purchase_Date
        {
            get { return _purchase_Date; }
            set { _purchase_Date = value; }
        }

        public System.Decimal Purchase_Price
        {
            get { return _purchase_Price; }
            set { _purchase_Price = value; }
        }

        public System.Decimal Sprinkler
        {
            get { return _sprinkler; }
            set { _sprinkler = value; }
        }

        public System.Decimal Fire_Alarms
        {
            get { return _fire_Alarms; }
            set { _fire_Alarms = value; }
        }

        public System.String Security_Alarm
        {
            get { return _security_Alarm; }
            set { _security_Alarm = value; }
        }

        public System.Decimal Security_Console
        {
            get { return _security_Console; }
            set { _security_Console = value; }
        }

        public System.String Ownership
        {
            get { return _ownership; }
            set { _ownership = value; }
        }

        public System.Decimal Number_Vaults
        {
            get { return _number_Vaults; }
            set { _number_Vaults = value; }
        }

        public System.Decimal Number_DU_Windows
        {
            get { return _number_DU_Windows; }
            set { _number_DU_Windows = value; }
        }

        public System.Decimal Number_SD_Boxes
        {
            get { return _number_SD_Boxes; }
            set { _number_SD_Boxes = value; }
        }

        public System.Decimal Number_WU_ATMs
        {
            get { return _number_WU_ATMs; }
            set { _number_WU_ATMs = value; }
        }

        public System.Decimal Number_DU_ATMs
        {
            get { return _number_DU_ATMs; }
            set { _number_DU_ATMs = value; }
        }

        public System.Decimal Regions_Lessor
        {
            get { return _regions_Lessor; }
            set { _regions_Lessor = value; }
        }

        public System.Decimal Net_Leasable_Sq_Ft
        {
            get { return _net_Leasable_Sq_Ft; }
            set { _net_Leasable_Sq_Ft = value; }
        }

        public System.Decimal Current_Monthly_Rent
        {
            get { return _current_Monthly_Rent; }
            set { _current_Monthly_Rent = value; }
        }

        public System.String Ocupancy_Rent
        {
            get { return _ocupancy_Rent; }
            set { _ocupancy_Rent = value; }
        }

        public System.Decimal Fine_Arts
        {
            get { return _fine_Arts; }
            set { _fine_Arts = value; }
        }

        public System.Decimal Rental_Income
        {
            get { return _rental_Income; }
            set { _rental_Income = value; }
        }

        public System.String ATM_Vendor_Contact
        {
            get { return _aTM_Vendor_Contact; }
            set { _aTM_Vendor_Contact = value; }
        }

        public System.String ATM_Telephone
        {
            get { return _aTM_Telephone; }
            set { _aTM_Telephone = value; }
        }

        public System.String ATM_Contract
        {
            get { return _aTM_Contract; }
            set { _aTM_Contract = value; }
        }

        public System.DateTime ATM_Date
        {
            get { return _aTM_Date; }
            set { _aTM_Date = value; }
        }

        public System.String Monday_Open
        {
            get { return _monday_Open; }
            set { _monday_Open = value; }
        }

        public System.String Monday_Close
        {
            get { return _monday_Close; }
            set { _monday_Close = value; }
        }

        public System.String Tuesday_Open
        {
            get { return _tuesday_Open; }
            set { _tuesday_Open = value; }
        }

        public System.String Tuesday_Close
        {
            get { return _tuesday_Close; }
            set { _tuesday_Close = value; }
        }

        public System.String Wednesday_Open
        {
            get { return _wednesday_Open; }
            set { _wednesday_Open = value; }
        }

        public System.String Wednesday_Close
        {
            get { return _wednesday_Close; }
            set { _wednesday_Close = value; }
        }

        public System.String Thursday_Open
        {
            get { return _thursday_Open; }
            set { _thursday_Open = value; }
        }

        public System.String Thursday_Close
        {
            get { return _thursday_Close; }
            set { _thursday_Close = value; }
        }

        public System.String Friday_Open
        {
            get { return _friday_Open; }
            set { _friday_Open = value; }
        }

        public System.String Friday_Close
        {
            get { return _friday_Close; }
            set { _friday_Close = value; }
        }

        public System.String Saturday_Open
        {
            get { return _saturday_Open; }
            set { _saturday_Open = value; }
        }

        public System.String Saturday_Close
        {
            get { return _saturday_Close; }
            set { _saturday_Close = value; }
        }

        public System.String Sunday_Open
        {
            get { return _sunday_Open; }
            set { _sunday_Open = value; }
        }

        public System.String Sunday_Close
        {
            get { return _sunday_Close; }
            set { _sunday_Close = value; }
        }

        public System.Decimal Cash_Chests
        {
            get { return _cash_Chests; }
            set { _cash_Chests = value; }
        }

        public System.String Tenant_Type
        {
            get { return _tenant_Type; }
            set { _tenant_Type = value; }
        }

        public System.Decimal Lessee
        {
            get { return _lessee; }
            set { _lessee = value; }
        }

        public System.Decimal Lessee_Rent_Sq_Ft
        {
            get { return _lessee_Rent_Sq_Ft; }
            set { _lessee_Rent_Sq_Ft = value; }
        }

        public System.String SA_SECURITY_CONSOLE
        {
            get { return _sA_SECURITY_CONSOLE; }
            set { _sA_SECURITY_CONSOLE = value; }
        }





        #endregion

        #region Abstract Methods
        public abstract List<CLiabilityClaim> GetAll(Boolean blnIsActive);
        public abstract List<CLiabilityClaim> Getility_ClaimByID(System.Int32 lPK_Liability_Claim);
        public abstract int InsertUpdate_Claim(RIMS_Base.CLiabilityClaim obj);
        public abstract int Delete_Claim(System.Int32 lPK_Liability_Claim);
        public abstract string ActivateInactivate_Claim(string strIDs, int intModifiedBy, bool bIsActive);
        public abstract List<CLiabilityClaim> Get_Property_ByID(System.Int32 fK_Liability_Claim, System.Decimal pK_Property_ID);
        public abstract List<CLiabilityClaim> GetLiabilityEmp_Data_ByID(System.Int32 pK_Liability_Claim, System.Int32 pK_Employee_ID, System.Int32 Criatearea);
        public abstract List<CLiabilityClaim> GetLiability_CostCenterByID(System.Int32 pK_Liability_Claim, System.String cost_Center);
        public abstract List<CLiabilityClaim> GetLiability_CliamantByID(System.Int32 pK_Liability_Claim, System.Decimal pK_Claimant_Id);
        public abstract DataSet GetLiabilityLabel();
        #endregion

    }

}
