#region Includes
	using System;
	using System.Collections.Generic;
	using System.Text;
    using System.Data.Sql;
    using System.Data.SqlClient;
    using System.Data;
#endregion

namespace RIMS_Base
{

[Serializable]
public abstract class CProperty
{

	#region Constructor
    public CProperty()
	{
		this._pK_Property_ID = -1;
		this._cost_Center = string.Empty;
		//this._facility = string.Empty;
		this._property_Description = string.Empty;
		this._value = -1;
		this._valuation_Date = DateTime.Now;
		this._premium = -1;
		this._coverage = -1;
		this._mobile_Type = string.Empty;
		this._mobile_VIN = string.Empty;
		this._mobile_Make = string.Empty;
		this._mobile_Model = string.Empty;
		this._mobile_Year = -1;
		this._mobile_Title = string.Empty;
		this._stationary_Type = string.Empty;
		this._stationary_Year = -1;
		this._stationary_Address_1 = string.Empty;
		this._stationary_Address_2 = string.Empty;
		this._stationary_City = string.Empty;
		this._stationary_State = string.Empty;
		this._stationary_Zip = string.Empty;
		this._stationary_Category = string.Empty;
		this._stationary_Title = string.Empty;
		this._stationary_Deed = string.Empty;
		this._stationary_Safety = string.Empty;
		this._stationary_Security = string.Empty;
		this._stationary_Flood_Zone = string.Empty;
		this._stationary_Foreclosure = string.Empty;
		this._foreclosed = string.Empty;
		this._contact_Name = string.Empty;
		this._contact_Phone = string.Empty;
		this._contact_Facsimile = string.Empty;
		this._emergency_Police = string.Empty;
		this._emergency_Fire = string.Empty;
		this._emergency_Sheriff = string.Empty;
		this._emergency_State_Police = string.Empty;
		this._emergency_Ambulance = string.Empty;
		this._emergency_FBI = string.Empty;
		this._emergency_Secret_Service = string.Empty;
		this._phone_Company_Contact = string.Empty;
		this._phone_Company_Telephone = string.Empty;
		this._power_Company_Contact = string.Empty;
		this._power_Company_Telephone = string.Empty;
		this._water_Utility_Contact = string.Empty;
		this._water_Utility_Telephone = string.Empty;
		this._gas_Utility_Contact = string.Empty;
		this._gas_Utility_Telephone = string.Empty;
		this._cleaning_Company_Contact = string.Empty;
		this._cleaning_Company_Telephone = string.Empty;
		this._cleaning_Company_Contract = string.Empty;
		this._cleaning_Company_Date = DateTime.Now;
		this._courier_Company_Contact = string.Empty;
		this._courier_Company_Telephone = string.Empty;
		this._courier_Company_Contract = string.Empty;
		this._courier_Company_Date = DateTime.Now;
		this._after_Hours_Contact = string.Empty;
		this._after_Hours_Phone = string.Empty;
		this._after_Hours_Cell = string.Empty;
		this._after_Hours_Pager = string.Empty;
		this._contact_For_1 = string.Empty;
		this._special_Contact_1 = string.Empty;
		this._special_Phone_1 = string.Empty;
		this._special_Cell_1 = string.Empty;
		this._special_Pager_1 = string.Empty;
		this._contact_For_2 = string.Empty;
		this._special_Contact_2 = string.Empty;
		this._special_Phone_2 = string.Empty;
		this._special_Cell_2 = string.Empty;
		this._special_Pager_2 = string.Empty;
		this._contact_For_3 = string.Empty;
		this._special_Contact_3 = string.Empty;
		this._special_Phone_3 = string.Empty;
		this._special_Cell_3 = string.Empty;
		this._special_Pager_3 = string.Empty;
		this._open_Time = string.Empty;
		this._close_Time = string.Empty;
		this._number_Of_Employees = -1;
		this._aTM = string.Empty;
		this._aTM_Location = string.Empty;
		this._updated_By = string.Empty;
		this._update_Date = DateTime.Now;
		//this._fK_Entity = -1;
		this._property_Name = string.Empty;
		this._fK_County = string.Empty;
		this._county_Tier_1 = string.Empty;
		this._county_Tri_County = string.Empty;
		//this._fK_Land_Status = -1;
		this._acreage = -1;
		this._road_Frontage = -1;
		this._road_Frontage_Units = string.Empty;
		this._occupancy = string.Empty;
		this._flood_Zone = string.Empty;
		this._number_Of_Employees1 = -1;
		this._building = -1;
		this._signs = -1;
		this._contents = -1;
		this._computers = -1;
		this._aTMs = -1;
		this._lease_Improvements = -1;
		this._total = -1;
		this._gross_Sq_Feet = -1;
		this._public_Acc_Sq_Feet = -1;
		this._stories_Up = -1;
		this._stories_Down = -1;
		this._construction_Cost = -1;
		this._construction_Type = string.Empty;
		this._year_Built = -1;
		this._purchase_Date = DateTime.Now;
		this._purchase_Price = -1;
		this._sprinkler = -1;
		this._fire_Alarms = -1;
		this._security_Alarm = string.Empty;
		this._security_Console = -1;
		this._ownership = string.Empty;
		this._number_Vaults = -1;
		this._number_DU_Windows = -1;
		this._number_SD_Boxes = -1;
		this._number_WU_ATMs = -1;
		this._number_DU_ATMs = -1;
		this._regions_Lessor = -1;
		this._net_Leasable_Sq_Ft = -1;
		this._current_Monthly_Rent = -1;
		this._ocupancy_Rent = string.Empty;
		this._fine_Arts = -1;
		this._rental_Income = -1;
		this._aTM_Vendor_Contact = string.Empty;
		this._aTM_Telephone = string.Empty;
		this._aTM_Contract = string.Empty;
		this._aTM_Date = DateTime.Now;
		this._monday_Open = string.Empty;
		this._monday_Close = string.Empty;
		this._tuesday_Open = string.Empty;
		this._tuesday_Close = string.Empty;
		this._wednesday_Open = string.Empty;
		this._wednesday_Close = string.Empty;
		this._thursday_Open = string.Empty;
		this._thursday_Close = string.Empty;
		this._friday_Open = string.Empty;
		this._friday_Close = string.Empty;
		this._saturday_Open = string.Empty;
		this._saturday_Close = string.Empty;
		this._sunday_Open = string.Empty;
		this._sunday_Close = string.Empty;
		this._cash_Chests = -1;
		this._tenant_Type = string.Empty;
		this._lessee = -1;
		this._lessee_Rent_Sq_Ft = -1;
		this._sA_SECURITY_CONSOLE = string.Empty;
	}
	#endregion

	#region Private Variables 
	private System.Int32 _pK_Property_ID;
	private System.String _cost_Center;
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
	private System.String _updated_By;
	private System.DateTime _update_Date;
	private System.Decimal? _fK_Entity;
	private System.String _property_Name;
	private System.String _fK_County;
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
    public System.Int32 PK_Property_ID
	{
		get { return  _pK_Property_ID; }
		set { _pK_Property_ID = value; }
	}

	public System.String Cost_Center
	{
		get { return  _cost_Center; }
		set { _cost_Center = value; }
	}

	public System.String Facility
	{
		get { return  _facility; }
		set { _facility = value; }
	}

	public System.String Property_Description
	{
		get { return  _property_Description; }
		set { _property_Description = value; }
	}

	public System.Decimal Value
	{
		get { return  _value; }
		set { _value = value; }
	}

	public System.DateTime Valuation_Date
	{
		get { return  _valuation_Date; }
		set { _valuation_Date = value; }
	}

	public System.Decimal Premium
	{
		get { return  _premium; }
		set { _premium = value; }
	}

	public System.Decimal Coverage
	{
		get { return  _coverage; }
		set { _coverage = value; }
	}

	public System.String Mobile_Type
	{
		get { return  _mobile_Type; }
		set { _mobile_Type = value; }
	}

	public System.String Mobile_VIN
	{
		get { return  _mobile_VIN; }
		set { _mobile_VIN = value; }
	}

	public System.String Mobile_Make
	{
		get { return  _mobile_Make; }
		set { _mobile_Make = value; }
	}

	public System.String Mobile_Model
	{
		get { return  _mobile_Model; }
		set { _mobile_Model = value; }
	}

	public System.Decimal Mobile_Year
	{
		get { return  _mobile_Year; }
		set { _mobile_Year = value; }
	}

	public System.String Mobile_Title
	{
		get { return  _mobile_Title; }
		set { _mobile_Title = value; }
	}

	public System.String Stationary_Type
	{
		get { return  _stationary_Type; }
		set { _stationary_Type = value; }
	}

	public System.Decimal Stationary_Year
	{
		get { return  _stationary_Year; }
		set { _stationary_Year = value; }
	}

	public System.String Stationary_Address_1
	{
		get { return  _stationary_Address_1; }
		set { _stationary_Address_1 = value; }
	}

	public System.String Stationary_Address_2
	{
		get { return  _stationary_Address_2; }
		set { _stationary_Address_2 = value; }
	}

	public System.String Stationary_City
	{
		get { return  _stationary_City; }
		set { _stationary_City = value; }
	}

	public System.String Stationary_State
	{
		get { return  _stationary_State; }
		set { _stationary_State = value; }
	}

	public System.String Stationary_Zip
	{
		get { return  _stationary_Zip; }
		set { _stationary_Zip = value; }
	}

	public System.String Stationary_Category
	{
		get { return  _stationary_Category; }
		set { _stationary_Category = value; }
	}

	public System.String Stationary_Title
	{
		get { return  _stationary_Title; }
		set { _stationary_Title = value; }
	}

	public System.String Stationary_Deed
	{
		get { return  _stationary_Deed; }
		set { _stationary_Deed = value; }
	}

	public System.String Stationary_Safety
	{
		get { return  _stationary_Safety; }
		set { _stationary_Safety = value; }
	}

	public System.String Stationary_Security
	{
		get { return  _stationary_Security; }
		set { _stationary_Security = value; }
	}

	public System.String Stationary_Flood_Zone
	{
		get { return  _stationary_Flood_Zone; }
		set { _stationary_Flood_Zone = value; }
	}

	public System.String Stationary_Foreclosure
	{
		get { return  _stationary_Foreclosure; }
		set { _stationary_Foreclosure = value; }
	}

	public System.String Foreclosed
	{
		get { return  _foreclosed; }
		set { _foreclosed = value; }
	}

	public System.String Contact_Name
	{
		get { return  _contact_Name; }
		set { _contact_Name = value; }
	}

	public System.String Contact_Phone
	{
		get { return  _contact_Phone; }
		set { _contact_Phone = value; }
	}

	public System.String Contact_Facsimile
	{
		get { return  _contact_Facsimile; }
		set { _contact_Facsimile = value; }
	}

	public System.String Emergency_Police
	{
		get { return  _emergency_Police; }
		set { _emergency_Police = value; }
	}

	public System.String Emergency_Fire
	{
		get { return  _emergency_Fire; }
		set { _emergency_Fire = value; }
	}

	public System.String Emergency_Sheriff
	{
		get { return  _emergency_Sheriff; }
		set { _emergency_Sheriff = value; }
	}

	public System.String Emergency_State_Police
	{
		get { return  _emergency_State_Police; }
		set { _emergency_State_Police = value; }
	}

	public System.String Emergency_Ambulance
	{
		get { return  _emergency_Ambulance; }
		set { _emergency_Ambulance = value; }
	}

	public System.String Emergency_FBI
	{
		get { return  _emergency_FBI; }
		set { _emergency_FBI = value; }
	}

	public System.String Emergency_Secret_Service
	{
		get { return  _emergency_Secret_Service; }
		set { _emergency_Secret_Service = value; }
	}

	public System.String Phone_Company_Contact
	{
		get { return  _phone_Company_Contact; }
		set { _phone_Company_Contact = value; }
	}

	public System.String Phone_Company_Telephone
	{
		get { return  _phone_Company_Telephone; }
		set { _phone_Company_Telephone = value; }
	}

	public System.String Power_Company_Contact
	{
		get { return  _power_Company_Contact; }
		set { _power_Company_Contact = value; }
	}

	public System.String Power_Company_Telephone
	{
		get { return  _power_Company_Telephone; }
		set { _power_Company_Telephone = value; }
	}

	public System.String Water_Utility_Contact
	{
		get { return  _water_Utility_Contact; }
		set { _water_Utility_Contact = value; }
	}

	public System.String Water_Utility_Telephone
	{
		get { return  _water_Utility_Telephone; }
		set { _water_Utility_Telephone = value; }
	}

	public System.String Gas_Utility_Contact
	{
		get { return  _gas_Utility_Contact; }
		set { _gas_Utility_Contact = value; }
	}

	public System.String Gas_Utility_Telephone
	{
		get { return  _gas_Utility_Telephone; }
		set { _gas_Utility_Telephone = value; }
	}

	public System.String Cleaning_Company_Contact
	{
		get { return  _cleaning_Company_Contact; }
		set { _cleaning_Company_Contact = value; }
	}

	public System.String Cleaning_Company_Telephone
	{
		get { return  _cleaning_Company_Telephone; }
		set { _cleaning_Company_Telephone = value; }
	}

	public System.String Cleaning_Company_Contract
	{
		get { return  _cleaning_Company_Contract; }
		set { _cleaning_Company_Contract = value; }
	}

	public System.DateTime Cleaning_Company_Date
	{
		get { return  _cleaning_Company_Date; }
		set { _cleaning_Company_Date = value; }
	}

	public System.String Courier_Company_Contact
	{
		get { return  _courier_Company_Contact; }
		set { _courier_Company_Contact = value; }
	}

	public System.String Courier_Company_Telephone
	{
		get { return  _courier_Company_Telephone; }
		set { _courier_Company_Telephone = value; }
	}

	public System.String Courier_Company_Contract
	{
		get { return  _courier_Company_Contract; }
		set { _courier_Company_Contract = value; }
	}

	public System.DateTime Courier_Company_Date
	{
		get { return  _courier_Company_Date; }
		set { _courier_Company_Date = value; }
	}

	public System.String After_Hours_Contact
	{
		get { return  _after_Hours_Contact; }
		set { _after_Hours_Contact = value; }
	}

	public System.String After_Hours_Phone
	{
		get { return  _after_Hours_Phone; }
		set { _after_Hours_Phone = value; }
	}

	public System.String After_Hours_Cell
	{
		get { return  _after_Hours_Cell; }
		set { _after_Hours_Cell = value; }
	}

	public System.String After_Hours_Pager
	{
		get { return  _after_Hours_Pager; }
		set { _after_Hours_Pager = value; }
	}

	public System.String Contact_For_1
	{
		get { return  _contact_For_1; }
		set { _contact_For_1 = value; }
	}

	public System.String Special_Contact_1
	{
		get { return  _special_Contact_1; }
		set { _special_Contact_1 = value; }
	}

	public System.String Special_Phone_1
	{
		get { return  _special_Phone_1; }
		set { _special_Phone_1 = value; }
	}

	public System.String Special_Cell_1
	{
		get { return  _special_Cell_1; }
		set { _special_Cell_1 = value; }
	}

	public System.String Special_Pager_1
	{
		get { return  _special_Pager_1; }
		set { _special_Pager_1 = value; }
	}

	public System.String Contact_For_2
	{
		get { return  _contact_For_2; }
		set { _contact_For_2 = value; }
	}

	public System.String Special_Contact_2
	{
		get { return  _special_Contact_2; }
		set { _special_Contact_2 = value; }
	}

	public System.String Special_Phone_2
	{
		get { return  _special_Phone_2; }
		set { _special_Phone_2 = value; }
	}

	public System.String Special_Cell_2
	{
		get { return  _special_Cell_2; }
		set { _special_Cell_2 = value; }
	}

	public System.String Special_Pager_2
	{
		get { return  _special_Pager_2; }
		set { _special_Pager_2 = value; }
	}

	public System.String Contact_For_3
	{
		get { return  _contact_For_3; }
		set { _contact_For_3 = value; }
	}

	public System.String Special_Contact_3
	{
		get { return  _special_Contact_3; }
		set { _special_Contact_3 = value; }
	}

	public System.String Special_Phone_3
	{
		get { return  _special_Phone_3; }
		set { _special_Phone_3 = value; }
	}

	public System.String Special_Cell_3
	{
		get { return  _special_Cell_3; }
		set { _special_Cell_3 = value; }
	}

	public System.String Special_Pager_3
	{
		get { return  _special_Pager_3; }
		set { _special_Pager_3 = value; }
	}

	public System.String Open_Time
	{
		get { return  _open_Time; }
		set { _open_Time = value; }
	}

	public System.String Close_Time
	{
		get { return  _close_Time; }
		set { _close_Time = value; }
	}

	public System.Decimal Number_Of_Employees
	{
		get { return  _number_Of_Employees; }
		set { _number_Of_Employees = value; }
	}

	public System.String ATM
	{
		get { return  _aTM; }
		set { _aTM = value; }
	}

	public System.String ATM_Location
	{
		get { return  _aTM_Location; }
		set { _aTM_Location = value; }
	}

	public System.String Updated_By
	{
		get { return  _updated_By; }
		set { _updated_By = value; }
	}

	public System.DateTime Update_Date
	{
		get { return  _update_Date; }
		set { _update_Date = value; }
	}

	public System.Decimal? FK_Entity
	{
		get { return  _fK_Entity; }
		set { _fK_Entity = value; }
	}

	public System.String Property_Name
	{
		get { return  _property_Name; }
		set { _property_Name = value; }
	}

	public System.String FK_County
	{
		get { return  _fK_County; }
		set { _fK_County = value; }
	}

	public System.String County_Tier_1
	{
		get { return  _county_Tier_1; }
		set { _county_Tier_1 = value; }
	}

	public System.String County_Tri_County
	{
		get { return  _county_Tri_County; }
		set { _county_Tri_County = value; }
	}

	public System.Decimal? FK_Land_Status
	{
		get { return  _fK_Land_Status; }
		set { _fK_Land_Status = value; }
	}

	public System.Decimal Acreage
	{
		get { return  _acreage; }
		set { _acreage = value; }
	}

	public System.Decimal Road_Frontage
	{
		get { return  _road_Frontage; }
		set { _road_Frontage = value; }
	}

	public System.String Road_Frontage_Units
	{
		get { return  _road_Frontage_Units; }
		set { _road_Frontage_Units = value; }
	}

	public System.String Occupancy
	{
		get { return  _occupancy; }
		set { _occupancy = value; }
	}

	public System.String Flood_Zone
	{
		get { return  _flood_Zone; }
		set { _flood_Zone = value; }
	}

	public System.Decimal Number_Of_Employees1
	{
		get { return  _number_Of_Employees1; }
		set { _number_Of_Employees1 = value; }
	}

	public System.Decimal Building
	{
		get { return  _building; }
		set { _building = value; }
	}

	public System.Decimal Signs
	{
		get { return  _signs; }
		set { _signs = value; }
	}

	public System.Decimal Contents
	{
		get { return  _contents; }
		set { _contents = value; }
	}

	public System.Decimal Computers
	{
		get { return  _computers; }
		set { _computers = value; }
	}

	public System.Decimal ATMs
	{
		get { return  _aTMs; }
		set { _aTMs = value; }
	}

	public System.Decimal Lease_Improvements
	{
		get { return  _lease_Improvements; }
		set { _lease_Improvements = value; }
	}

	public System.Decimal Total
	{
		get { return  _total; }
		set { _total = value; }
	}

	public System.Decimal Gross_Sq_Feet
	{
		get { return  _gross_Sq_Feet; }
		set { _gross_Sq_Feet = value; }
	}

	public System.Decimal Public_Acc_Sq_Feet
	{
		get { return  _public_Acc_Sq_Feet; }
		set { _public_Acc_Sq_Feet = value; }
	}

	public System.Decimal Stories_Up
	{
		get { return  _stories_Up; }
		set { _stories_Up = value; }
	}

	public System.Decimal Stories_Down
	{
		get { return  _stories_Down; }
		set { _stories_Down = value; }
	}

	public System.Decimal Construction_Cost
	{
		get { return  _construction_Cost; }
		set { _construction_Cost = value; }
	}

	public System.String Construction_Type
	{
		get { return  _construction_Type; }
		set { _construction_Type = value; }
	}

	public System.Decimal Year_Built
	{
		get { return  _year_Built; }
		set { _year_Built = value; }
	}

	public System.DateTime Purchase_Date
	{
		get { return  _purchase_Date; }
		set { _purchase_Date = value; }
	}

	public System.Decimal Purchase_Price
	{
		get { return  _purchase_Price; }
		set { _purchase_Price = value; }
	}

	public System.Decimal Sprinkler
	{
		get { return  _sprinkler; }
		set { _sprinkler = value; }
	}

	public System.Decimal Fire_Alarms
	{
		get { return  _fire_Alarms; }
		set { _fire_Alarms = value; }
	}

	public System.String Security_Alarm
	{
		get { return  _security_Alarm; }
		set { _security_Alarm = value; }
	}

	public System.Decimal Security_Console
	{
		get { return  _security_Console; }
		set { _security_Console = value; }
	}

	public System.String Ownership
	{
		get { return  _ownership; }
		set { _ownership = value; }
	}

	public System.Decimal Number_Vaults
	{
		get { return  _number_Vaults; }
		set { _number_Vaults = value; }
	}

	public System.Decimal Number_DU_Windows
	{
		get { return  _number_DU_Windows; }
		set { _number_DU_Windows = value; }
	}

	public System.Decimal Number_SD_Boxes
	{
		get { return  _number_SD_Boxes; }
		set { _number_SD_Boxes = value; }
	}

	public System.Decimal Number_WU_ATMs
	{
		get { return  _number_WU_ATMs; }
		set { _number_WU_ATMs = value; }
	}

	public System.Decimal Number_DU_ATMs
	{
		get { return  _number_DU_ATMs; }
		set { _number_DU_ATMs = value; }
	}

	public System.Decimal Regions_Lessor
	{
		get { return  _regions_Lessor; }
		set { _regions_Lessor = value; }
	}

	public System.Decimal Net_Leasable_Sq_Ft
	{
		get { return  _net_Leasable_Sq_Ft; }
		set { _net_Leasable_Sq_Ft = value; }
	}

	public System.Decimal Current_Monthly_Rent
	{
		get { return  _current_Monthly_Rent; }
		set { _current_Monthly_Rent = value; }
	}

	public System.String Ocupancy_Rent
	{
		get { return  _ocupancy_Rent; }
		set { _ocupancy_Rent = value; }
	}

	public System.Decimal Fine_Arts
	{
		get { return  _fine_Arts; }
		set { _fine_Arts = value; }
	}

	public System.Decimal Rental_Income
	{
		get { return  _rental_Income; }
		set { _rental_Income = value; }
	}

	public System.String ATM_Vendor_Contact
	{
		get { return  _aTM_Vendor_Contact; }
		set { _aTM_Vendor_Contact = value; }
	}

	public System.String ATM_Telephone
	{
		get { return  _aTM_Telephone; }
		set { _aTM_Telephone = value; }
	}

	public System.String ATM_Contract
	{
		get { return  _aTM_Contract; }
		set { _aTM_Contract = value; }
	}

	public System.DateTime ATM_Date
	{
		get { return  _aTM_Date; }
		set { _aTM_Date = value; }
	}

	public System.String Monday_Open
	{
		get { return  _monday_Open; }
		set { _monday_Open = value; }
	}

	public System.String Monday_Close
	{
		get { return  _monday_Close; }
		set { _monday_Close = value; }
	}

	public System.String Tuesday_Open
	{
		get { return  _tuesday_Open; }
		set { _tuesday_Open = value; }
	}

	public System.String Tuesday_Close
	{
		get { return  _tuesday_Close; }
		set { _tuesday_Close = value; }
	}

	public System.String Wednesday_Open
	{
		get { return  _wednesday_Open; }
		set { _wednesday_Open = value; }
	}

	public System.String Wednesday_Close
	{
		get { return  _wednesday_Close; }
		set { _wednesday_Close = value; }
	}

	public System.String Thursday_Open
	{
		get { return  _thursday_Open; }
		set { _thursday_Open = value; }
	}

	public System.String Thursday_Close
	{
		get { return  _thursday_Close; }
		set { _thursday_Close = value; }
	}

	public System.String Friday_Open
	{
		get { return  _friday_Open; }
		set { _friday_Open = value; }
	}

	public System.String Friday_Close
	{
		get { return  _friday_Close; }
		set { _friday_Close = value; }
	}

	public System.String Saturday_Open
	{
		get { return  _saturday_Open; }
		set { _saturday_Open = value; }
	}

	public System.String Saturday_Close
	{
		get { return  _saturday_Close; }
		set { _saturday_Close = value; }
	}

	public System.String Sunday_Open
	{
		get { return  _sunday_Open; }
		set { _sunday_Open = value; }
	}

	public System.String Sunday_Close
	{
		get { return  _sunday_Close; }
		set { _sunday_Close = value; }
	}

	public System.Decimal Cash_Chests
	{
		get { return  _cash_Chests; }
		set { _cash_Chests = value; }
	}

	public System.String Tenant_Type
	{
		get { return  _tenant_Type; }
		set { _tenant_Type = value; }
	}

	public System.Decimal Lessee
	{
		get { return  _lessee; }
		set { _lessee = value; }
	}

	public System.Decimal Lessee_Rent_Sq_Ft
	{
		get { return  _lessee_Rent_Sq_Ft; }
		set { _lessee_Rent_Sq_Ft = value; }
	}

	public System.String SA_SECURITY_CONSOLE
	{
		get { return  _sA_SECURITY_CONSOLE; }
		set { _sA_SECURITY_CONSOLE = value; }
	}

	#endregion

	#region Abstract Methods
    public abstract List<CProperty> GetAll();
    public abstract DataSet GetPropertyByID(System.Decimal lPK_Property_ID);
    public abstract int InsertUpdateProperty(RIMS_Base.CProperty obj);
	public abstract int DeleteProperty(System.String lPK_Property_ID);
	public abstract string ActivateInactivateProperty(string strIDs, int intModifiedBy, bool bIsActive);

    public abstract List<CProperty> GetPropertyGridData();
    public abstract List<CProperty> Get_Search_Data(System.String m_strColumn, System.String m_strCriteria);

    #endregion

}

}
