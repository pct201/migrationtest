#region Includes
	using System;
	using System.Collections.Generic;
	using System.Text;
#endregion

namespace RIMS_Base
{

[Serializable]
public abstract class CLiabilityClaimOtherVehInfo
{

	#region Constructor
    public CLiabilityClaimOtherVehInfo()
	{
        this._pk_OtherVehicle = -1;
		this._fK_Liability_Claim = -1;
		this._owner_Name = string.Empty;
		this._owner_Address1 = string.Empty;
		this._owner_Address2 = string.Empty;
		this._owner_City = string.Empty;
		//this._fK_Owner_State = -1;
		this._owner_Zipcode = string.Empty;
		this._owner_Telephone = string.Empty;
		this._insurance_Carrier = string.Empty;
		this._insurance_Telephone = string.Empty;
		this._insurance_Agent_Name = string.Empty;
		this._insurance_Agent_Telephone = string.Empty;
		this._policy_Number = string.Empty;
		this._vehicle_Year = string.Empty;
		this._vehicle_Make = string.Empty;
		this._vehicle_Model = string.Empty;
		this._vehicle_VIN = string.Empty;
		this._vehicle_Plate_Number = string.Empty;
		//this._fK_Vehicle_State = -1;
		this._vehicle_Color = string.Empty;
		this._desc_Damage = string.Empty;
		this._updated_By = string.Empty;
		this._updated_Date = DateTime.Now;

        this._fld_State = string.Empty;
	}
	#endregion

	#region Private Variables 
    private System.Int32 _pk_OtherVehicle;
    private System.Int32 _fK_Liability_Claim;
	private System.String _owner_Name;
	private System.String _owner_Address1;
	private System.String _owner_Address2;
	private System.String _owner_City;
	private System.Decimal ? _fK_Owner_State;
	private System.String _owner_Zipcode;
	private System.String _owner_Telephone;
	private System.String _insurance_Carrier;
	private System.String _insurance_Telephone;
	private System.String _insurance_Agent_Name;
	private System.String _insurance_Agent_Telephone;
	private System.String _policy_Number;
	private System.String _vehicle_Year;
	private System.String _vehicle_Make;
	private System.String _vehicle_Model;
	private System.String _vehicle_VIN;
	private System.String _vehicle_Plate_Number;
	private System.Decimal ? _fK_Vehicle_State;
	private System.String _vehicle_Color;
	private System.String _desc_Damage;
	private System.String _updated_By;
	private System.DateTime _updated_Date;
    private System.String _fld_State;
	#endregion

	#region Public Properties

    public System.Int32 Pk_OtherVehicle
    {
        get { return _pk_OtherVehicle; }
        set { _pk_OtherVehicle = value; }
    }

    public System.String FLD_State
    {
        get { return _fld_State; }
        set { _fld_State = value; }
    }

    public System.Int32 FK_Liability_Claim
	{
		get { return  _fK_Liability_Claim; }
		set { _fK_Liability_Claim = value; }
	}

	public System.String Owner_Name
	{
		get { return  _owner_Name; }
		set { _owner_Name = value; }
	}

	public System.String Owner_Address1
	{
		get { return  _owner_Address1; }
		set { _owner_Address1 = value; }
	}

	public System.String Owner_Address2
	{
		get { return  _owner_Address2; }
		set { _owner_Address2 = value; }
	}

	public System.String Owner_City
	{
		get { return  _owner_City; }
		set { _owner_City = value; }
	}

	public System.Decimal ? FK_Owner_State
	{
		get { return  _fK_Owner_State; }
		set { _fK_Owner_State = value; }
	}

	public System.String Owner_Zipcode
	{
		get { return  _owner_Zipcode; }
		set { _owner_Zipcode = value; }
	}

	public System.String Owner_Telephone
	{
		get { return  _owner_Telephone; }
		set { _owner_Telephone = value; }
	}

	public System.String Insurance_Carrier
	{
		get { return  _insurance_Carrier; }
		set { _insurance_Carrier = value; }
	}

	public System.String Insurance_Telephone
	{
		get { return  _insurance_Telephone; }
		set { _insurance_Telephone = value; }
	}

	public System.String Insurance_Agent_Name
	{
		get { return  _insurance_Agent_Name; }
		set { _insurance_Agent_Name = value; }
	}

	public System.String Insurance_Agent_Telephone
	{
		get { return  _insurance_Agent_Telephone; }
		set { _insurance_Agent_Telephone = value; }
	}

	public System.String Policy_Number
	{
		get { return  _policy_Number; }
		set { _policy_Number = value; }
	}

	public System.String Vehicle_Year
	{
		get { return  _vehicle_Year; }
		set { _vehicle_Year = value; }
	}

	public System.String Vehicle_Make
	{
		get { return  _vehicle_Make; }
		set { _vehicle_Make = value; }
	}

	public System.String Vehicle_Model
	{
		get { return  _vehicle_Model; }
		set { _vehicle_Model = value; }
	}

	public System.String Vehicle_VIN
	{
		get { return  _vehicle_VIN; }
		set { _vehicle_VIN = value; }
	}

	public System.String Vehicle_Plate_Number
	{
		get { return  _vehicle_Plate_Number; }
		set { _vehicle_Plate_Number = value; }
	}

	public System.Decimal ? FK_Vehicle_State
	{
		get { return  _fK_Vehicle_State; }
		set { _fK_Vehicle_State = value; }
	}

	public System.String Vehicle_Color
	{
		get { return  _vehicle_Color; }
		set { _vehicle_Color = value; }
	}

	public System.String Desc_Damage
	{
		get { return  _desc_Damage; }
		set { _desc_Damage = value; }
	}

	public System.String Updated_By
	{
		get { return  _updated_By; }
		set { _updated_By = value; }
	}

	public System.DateTime Updated_Date
	{
		get { return  _updated_Date; }
		set { _updated_Date = value; }
	}

	#endregion

	#region Abstract Methods
	public abstract List<CLiabilityClaimOtherVehInfo> GetAll();
    public abstract List<CLiabilityClaimOtherVehInfo> GetAL_Claim_OtherVehInfoByID(System.Decimal lFK_Liability_Claim);
    public abstract int InsertUpdateility_Claim_OtherVehInfo(RIMS_Base.CLiabilityClaimOtherVehInfo obj);
    public abstract int Delete_Claim_OtherVehInfo(System.Int32 pk_OtherVehicle);
	public abstract string ActivateInactivateility_Claim_OtherVehInfo(string strIDs, int intModifiedBy, bool bIsActive);
    public abstract List<CLiabilityClaimOtherVehInfo> Get_Claim_OtherVehInfoByID(System.Int32 pk_OtherVehicle);
	#endregion

}

}
