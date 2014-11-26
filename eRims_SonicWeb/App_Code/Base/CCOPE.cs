#region Includes
	using System;
	using System.Collections.Generic;
	using System.Text;
using System.Data;
#endregion

namespace RIMS_Base
{

[Serializable]
public abstract class CCOPE
{

	#region Constructor
	public CCOPE()
	{
		this._pK_Property_COPE = 0;
        //this._fK_Entity = -1;
        //this._fK_Property_Location_Code = -1;
        //this._description = string.Empty;
        //this._fK_Property_Type = -1;
        //this._year_Aquisition = -1;
        //this._address_1 = string.Empty;
        //this._address_2 = string.Empty;
        //this._city = string.Empty;
        //this._fK_State = -1;
        //this._zip_Code = string.Empty;
        //this._fK_County = -1;
        //this._ownership = string.Empty;
        //this._property_Owner_Manager = string.Empty;
        //this._leased_To_Third_Party = string.Empty;
        //this._third_Party_Lesee = string.Empty;
        //this._third_Party_Use = string.Empty;
        //this._yeat_Built = -1;
        //this._number_Of_Floors = -1;
        //this._square_Feet = -1;
        //this._type_Of_Exterior_Walls = string.Empty;
        //this._type_Of_Roof = string.Empty;
        //this._generator = string.Empty;
        //this._generator_Description = string.Empty;
        //this._number_Of_Employees = -1;
        //this._workgroup_Business_Wholesale = string.Empty;
        //this._workgroup_Finance_Accounting = string.Empty;
        //this._workgroup_HR = string.Empty;
        //this._workgroup_ISPE = string.Empty;
        //this._workgroup_IT_IS = string.Empty;
        //this._workgroup_Legal = string.Empty;
        //this._workgroup_Marketing = string.Empty;
        //this._workgroup_NOC = string.Empty;
        //this._workgroup_OSPE = string.Empty;
        //this._workgroup_Regultory = string.Empty;
        //this._workgroup_Residental_Small_Business = string.Empty;
        //this._workgroup_Supply_Chain = string.Empty;
        //this._workgroup_Support_Services = string.Empty;
        //this._fK_Fire_Protection = -1;
        //this._fire_Protection_Description = string.Empty;
        //this._fire_Alarm = string.Empty;
        //this._smoke_Detector = string.Empty;
        //this._sub_Floor_Monitoring = string.Empty;
        //this._sub_Floor_Monitoring_Description = string.Empty;
        //this._security = string.Empty;
        //this._guards = string.Empty;
        //this._electronic_Access = string.Empty;
        //this._cipher_Lock = string.Empty;
        //this._video = string.Empty;
        //this._panic_Alarm = string.Empty;
        //this._protection_Comments = string.Empty;
        //this._tier_1_County = string.Empty;
        //this._fK_Flood_Zone = -1;
        //this._earthquake = string.Empty;
        //this._asbestos = string.Empty;
        //this._asbestos_Materials_Description = string.Empty;
        //this._fK_Batteries = -1;
        //this._number_Of_Batteries = -1;
        //this._size_Of_Batteris = string.Empty;
        //this._tower = string.Empty;
        //this._fK_Tower_Type = -1;
        //this._tower_Height = string.Empty;
        //this._total_Height_From_Ground = string.Empty;
        //this._tower_Use_Description = string.Empty;
        //this._anti_Climbing_Device = string.Empty;
        //this._fence = string.Empty;
        //this._tower_Third_Party_Lessee = string.Empty;
        //this._tower_Third_Party_Lessee_Name = string.Empty;
        //this._tower_Third_Party_Lessee_Use = string.Empty;
		//this._updated_By = -1;
		this._update_Date = DateTime.Now;
	}
	#endregion

	#region Private Variables 
	private System.Decimal? _pK_Property_COPE;
	private System.Decimal? _fK_Entity;
	private System.Decimal? _fK_Property_Location_Code;
	private System.String _description;
	private System.Decimal? _fK_Property_Type;
	private System.Int32 _year_Aquisition;
	private System.String _address_1;
	private System.String _address_2;
	private System.String _city;
	private System.Decimal? _fK_State;
	private System.String _zip_Code;
	private System.Decimal? _fK_County;
	private System.String _ownership;
	private System.String _property_Owner_Manager;
	private System.String _leased_To_Third_Party;
	private System.String _third_Party_Lesee;
	private System.String _third_Party_Use;
	private System.Int32 _yeat_Built;
	private System.Int32 _number_Of_Floors;
	private System.Decimal? _square_Feet;
	private System.String _type_Of_Exterior_Walls;
	private System.String _type_Of_Roof;
	private System.String _generator;
	private System.String _generator_Description;
	private System.Decimal? _number_Of_Employees;
	private System.String _workgroup_Business_Wholesale;
	private System.String _workgroup_Finance_Accounting;
	private System.String _workgroup_HR;
	private System.String _workgroup_ISPE;
	private System.String _workgroup_IT_IS;
	private System.String _workgroup_Legal;
	private System.String _workgroup_Marketing;
	private System.String _workgroup_NOC;
	private System.String _workgroup_OSPE;
	private System.String _workgroup_Regultory;
	private System.String _workgroup_Residental_Small_Business;
	private System.String _workgroup_Supply_Chain;
	private System.String _workgroup_Support_Services;
	private System.Decimal? _fK_Fire_Protection;
	private System.String _fire_Protection_Description;
	private System.String _fire_Alarm;
	private System.String _smoke_Detector;
	private System.String _sub_Floor_Monitoring;
	private System.String _sub_Floor_Monitoring_Description;
	private System.String _security;
	private System.String _guards;
	private System.String _electronic_Access;
	private System.String _cipher_Lock;
	private System.String _video;
	private System.String _panic_Alarm;
	private System.String _protection_Comments;
	private System.String _tier_1_County;
	private System.Decimal? _fK_Flood_Zone;
	private System.String _earthquake;
	private System.String _asbestos;
	private System.String _asbestos_Materials_Description;
	private System.Decimal? _fK_Batteries;
	private System.Decimal? _number_Of_Batteries;
	private System.String _size_Of_Batteris;
	private System.String _tower;
	private System.Decimal? _fK_Tower_Type;
	private System.String _tower_Height;
	private System.String _total_Height_From_Ground;
	private System.String _tower_Use_Description;
	private System.String _anti_Climbing_Device;
	private System.String _fence;
	private System.String _tower_Third_Party_Lessee;
	private System.String _tower_Third_Party_Lessee_Name;
	private System.String _tower_Third_Party_Lessee_Use;
	private System.Decimal? _updated_By;
	private System.DateTime _update_Date;
	#endregion

	#region Public Properties
	public System.Decimal? PK_Property_COPE
	{
		get { return  _pK_Property_COPE; }
		set { _pK_Property_COPE = value; }
	}

	public System.Decimal? FK_Entity
	{
		get { return  _fK_Entity; }
		set { _fK_Entity = value; }
	}

	public System.Decimal? FK_Property_Location_Code
	{
		get { return  _fK_Property_Location_Code; }
		set { _fK_Property_Location_Code = value; }
	}

	public System.String Description
	{
		get { return  _description; }
		set { _description = value; }
	}

	public System.Decimal? FK_Property_Type
	{
		get { return  _fK_Property_Type; }
		set { _fK_Property_Type = value; }
	}

	public System.Int32 Year_Aquisition
	{
		get { return  _year_Aquisition; }
		set { _year_Aquisition = value; }
	}

	public System.String Address_1
	{
		get { return  _address_1; }
		set { _address_1 = value; }
	}

	public System.String Address_2
	{
		get { return  _address_2; }
		set { _address_2 = value; }
	}

	public System.String City
	{
		get { return  _city; }
		set { _city = value; }
	}

	public System.Decimal? FK_State
	{
		get { return  _fK_State; }
		set { _fK_State = value; }
	}

	public System.String Zip_Code
	{
		get { return  _zip_Code; }
		set { _zip_Code = value; }
	}

	public System.Decimal? FK_County
	{
		get { return  _fK_County; }
		set { _fK_County = value; }
	}

	public System.String Ownership
	{
		get { return  _ownership; }
		set { _ownership = value; }
	}

	public System.String Property_Owner_Manager
	{
		get { return  _property_Owner_Manager; }
		set { _property_Owner_Manager = value; }
	}

	public System.String Leased_To_Third_Party
	{
		get { return  _leased_To_Third_Party; }
		set { _leased_To_Third_Party = value; }
	}

	public System.String Third_Party_Lesee
	{
		get { return  _third_Party_Lesee; }
		set { _third_Party_Lesee = value; }
	}

	public System.String Third_Party_Use
	{
		get { return  _third_Party_Use; }
		set { _third_Party_Use = value; }
	}

	public System.Int32 Yeat_Built
	{
		get { return  _yeat_Built; }
		set { _yeat_Built = value; }
	}

	public System.Int32 Number_Of_Floors
	{
		get { return  _number_Of_Floors; }
		set { _number_Of_Floors = value; }
	}

	public System.Decimal? Square_Feet
	{
		get { return  _square_Feet; }
		set { _square_Feet = value; }
	}

	public System.String Type_Of_Exterior_Walls
	{
		get { return  _type_Of_Exterior_Walls; }
		set { _type_Of_Exterior_Walls = value; }
	}

	public System.String Type_Of_Roof
	{
		get { return  _type_Of_Roof; }
		set { _type_Of_Roof = value; }
	}

	public System.String Generator
	{
		get { return  _generator; }
		set { _generator = value; }
	}

	public System.String Generator_Description
	{
		get { return  _generator_Description; }
		set { _generator_Description = value; }
	}

	public System.Decimal? Number_Of_Employees
	{
		get { return  _number_Of_Employees; }
		set { _number_Of_Employees = value; }
	}

	public System.String Workgroup_Business_Wholesale
	{
		get { return  _workgroup_Business_Wholesale; }
		set { _workgroup_Business_Wholesale = value; }
	}

	public System.String Workgroup_Finance_Accounting
	{
		get { return  _workgroup_Finance_Accounting; }
		set { _workgroup_Finance_Accounting = value; }
	}

	public System.String Workgroup_HR
	{
		get { return  _workgroup_HR; }
		set { _workgroup_HR = value; }
	}

	public System.String Workgroup_ISPE
	{
		get { return  _workgroup_ISPE; }
		set { _workgroup_ISPE = value; }
	}

	public System.String Workgroup_IT_IS
	{
		get { return  _workgroup_IT_IS; }
		set { _workgroup_IT_IS = value; }
	}

	public System.String Workgroup_Legal
	{
		get { return  _workgroup_Legal; }
		set { _workgroup_Legal = value; }
	}

	public System.String Workgroup_Marketing
	{
		get { return  _workgroup_Marketing; }
		set { _workgroup_Marketing = value; }
	}

	public System.String Workgroup_NOC
	{
		get { return  _workgroup_NOC; }
		set { _workgroup_NOC = value; }
	}

	public System.String Workgroup_OSPE
	{
		get { return  _workgroup_OSPE; }
		set { _workgroup_OSPE = value; }
	}

	public System.String Workgroup_Regultory
	{
		get { return  _workgroup_Regultory; }
		set { _workgroup_Regultory = value; }
	}

	public System.String Workgroup_Residental_Small_Business
	{
		get { return  _workgroup_Residental_Small_Business; }
		set { _workgroup_Residental_Small_Business = value; }
	}

	public System.String Workgroup_Supply_Chain
	{
		get { return  _workgroup_Supply_Chain; }
		set { _workgroup_Supply_Chain = value; }
	}

	public System.String Workgroup_Support_Services
	{
		get { return  _workgroup_Support_Services; }
		set { _workgroup_Support_Services = value; }
	}

	public System.Decimal? FK_Fire_Protection
	{
		get { return  _fK_Fire_Protection; }
		set { _fK_Fire_Protection = value; }
	}

	public System.String Fire_Protection_Description
	{
		get { return  _fire_Protection_Description; }
		set { _fire_Protection_Description = value; }
	}

	public System.String Fire_Alarm
	{
		get { return  _fire_Alarm; }
		set { _fire_Alarm = value; }
	}

	public System.String Smoke_Detector
	{
		get { return  _smoke_Detector; }
		set { _smoke_Detector = value; }
	}

	public System.String Sub_Floor_Monitoring
	{
		get { return  _sub_Floor_Monitoring; }
		set { _sub_Floor_Monitoring = value; }
	}

	public System.String Sub_Floor_Monitoring_Description
	{
		get { return  _sub_Floor_Monitoring_Description; }
		set { _sub_Floor_Monitoring_Description = value; }
	}

	public System.String Security
	{
		get { return  _security; }
		set { _security = value; }
	}

	public System.String Guards
	{
		get { return  _guards; }
		set { _guards = value; }
	}

	public System.String Electronic_Access
	{
		get { return  _electronic_Access; }
		set { _electronic_Access = value; }
	}

	public System.String Cipher_Lock
	{
		get { return  _cipher_Lock; }
		set { _cipher_Lock = value; }
	}

	public System.String Video
	{
		get { return  _video; }
		set { _video = value; }
	}

	public System.String Panic_Alarm
	{
		get { return  _panic_Alarm; }
		set { _panic_Alarm = value; }
	}

	public System.String Protection_Comments
	{
		get { return  _protection_Comments; }
		set { _protection_Comments = value; }
	}

	public System.String Tier_1_County
	{
		get { return  _tier_1_County; }
		set { _tier_1_County = value; }
	}

	public System.Decimal? FK_Flood_Zone
	{
		get { return  _fK_Flood_Zone; }
		set { _fK_Flood_Zone = value; }
	}

	public System.String Earthquake
	{
		get { return  _earthquake; }
		set { _earthquake = value; }
	}

	public System.String Asbestos
	{
		get { return  _asbestos; }
		set { _asbestos = value; }
	}

	public System.String Asbestos_Materials_Description
	{
		get { return  _asbestos_Materials_Description; }
		set { _asbestos_Materials_Description = value; }
	}

	public System.Decimal? FK_Batteries
	{
		get { return  _fK_Batteries; }
		set { _fK_Batteries = value; }
	}

	public System.Decimal? Number_Of_Batteries
	{
		get { return  _number_Of_Batteries; }
		set { _number_Of_Batteries = value; }
	}

	public System.String Size_Of_Batteris
	{
		get { return  _size_Of_Batteris; }
		set { _size_Of_Batteris = value; }
	}

	public System.String Tower
	{
		get { return  _tower; }
		set { _tower = value; }
	}

	public System.Decimal? FK_Tower_Type
	{
		get { return  _fK_Tower_Type; }
		set { _fK_Tower_Type = value; }
	}

	public System.String Tower_Height
	{
		get { return  _tower_Height; }
		set { _tower_Height = value; }
	}

	public System.String Total_Height_From_Ground
	{
		get { return  _total_Height_From_Ground; }
		set { _total_Height_From_Ground = value; }
	}

	public System.String Tower_Use_Description
	{
		get { return  _tower_Use_Description; }
		set { _tower_Use_Description = value; }
	}

	public System.String Anti_Climbing_Device
	{
		get { return  _anti_Climbing_Device; }
		set { _anti_Climbing_Device = value; }
	}

	public System.String Fence
	{
		get { return  _fence; }
		set { _fence = value; }
	}

	public System.String Tower_Third_Party_Lessee
	{
		get { return  _tower_Third_Party_Lessee; }
		set { _tower_Third_Party_Lessee = value; }
	}

	public System.String Tower_Third_Party_Lessee_Name
	{
		get { return  _tower_Third_Party_Lessee_Name; }
		set { _tower_Third_Party_Lessee_Name = value; }
	}

	public System.String Tower_Third_Party_Lessee_Use
	{
		get { return  _tower_Third_Party_Lessee_Use; }
		set { _tower_Third_Party_Lessee_Use = value; }
	}

	public System.Decimal? Updated_By
	{
		get { return  _updated_By; }
		set { _updated_By = value; }
	}

	public System.DateTime Update_Date
	{
		get { return  _update_Date; }
		set { _update_Date = value; }
	}

	#endregion

	#region Abstract Methods
	public abstract List<RIMS_Base.CCOPE> GetAll( );
    public abstract DataSet Get_COPEByID(System.Decimal lPK_Property_COPE);
	public abstract int InsertUpdate_COPE(RIMS_Base.CCOPE obj);
	public abstract int Delete_COPE(System.Decimal lPK_Property_COPE);
	#endregion

}

}
