#region Includes
	using System;
	using System.Collections.Generic;
	using System.Text;
#endregion

namespace RIMS_Base
{

[Serializable]
public abstract class CLiabilityClaimCmpVehicleInfo
{

	#region Constructor
    public CLiabilityClaimCmpVehicleInfo()
	{
		this._fK_Liability_Claim = -1;
        //this._year = string.Empty;
        //this._model = string.Empty;
        //this._license_Plate_Number = string.Empty;
        //this._vehicle_Color = string.Empty;
        //this._make = string.Empty;
        //this._vIN = string.Empty;
        //this._fK_License_Plate_State = -1;
        //this._cmpVeh_Only_Veh = string.Empty;
        //this._damage_To_CmpVeh = string.Empty;
        //this._updated_By = string.Empty;
        //this._updated_Date = DateTime.Now;
	}
	#endregion

	#region Private Variables 
    private System.Int32 _fK_Liability_Claim;
	private System.String _year;
	private System.String _model;
	private System.String _license_Plate_Number;
	private System.String _vehicle_Color;
	private System.String _make;
	private System.String _vIN;
	private System.Decimal? _fK_License_Plate_State;
	private System.String _cmpVeh_Only_Veh;
	private System.String _damage_To_CmpVeh;
	private System.String _updated_By;
	private System.DateTime? _updated_Date;
	#endregion

	#region Public Properties
    public System.Int32 FK_Liability_Claim
	{
		get { return  _fK_Liability_Claim; }
		set { _fK_Liability_Claim = value; }
	}

	public System.String Year
	{
		get { return  _year; }
		set { _year = value; }
	}

	public System.String Model
	{
		get { return  _model; }
		set { _model = value; }
	}

	public System.String License_Plate_Number
	{
		get { return  _license_Plate_Number; }
		set { _license_Plate_Number = value; }
	}

	public System.String Vehicle_Color
	{
		get { return  _vehicle_Color; }
		set { _vehicle_Color = value; }
	}

	public System.String Make
	{
		get { return  _make; }
		set { _make = value; }
	}

	public System.String VIN
	{
		get { return  _vIN; }
		set { _vIN = value; }
	}

	public System.Decimal ? FK_License_Plate_State
	{
		get { return  _fK_License_Plate_State; }
		set { _fK_License_Plate_State = value; }
	}

	public System.String CmpVeh_Only_Veh
	{
		get { return  _cmpVeh_Only_Veh; }
		set { _cmpVeh_Only_Veh = value; }
	}

	public System.String Damage_To_CmpVeh
	{
		get { return  _damage_To_CmpVeh; }
		set { _damage_To_CmpVeh = value; }
	}

	public System.String Updated_By
	{
		get { return  _updated_By; }
		set { _updated_By = value; }
	}

	public System.DateTime ? Updated_Date
	{
		get { return  _updated_Date; }
		set { _updated_Date = value; }
	}

	#endregion

	#region Abstract Methods
    public abstract List<CLiabilityClaimCmpVehicleInfo> GetAll(Boolean blnIsActive);
    public abstract List<CLiabilityClaimCmpVehicleInfo> GetAL_Claim_CmpVehicleInfoByID(System.Decimal lFK_Liability_Claim);
    public abstract int InsertUpdateility_Claim_CmpVehicleInfo(RIMS_Base.CLiabilityClaimCmpVehicleInfo obj);
	public abstract int Deleteility_Claim_CmpVehicleInfo(System.Decimal lFK_Liability_Claim);
	public abstract string ActivateInactivateility_Claim_CmpVehicleInfo(string strIDs, int intModifiedBy, bool bIsActive);
	#endregion

}

}
