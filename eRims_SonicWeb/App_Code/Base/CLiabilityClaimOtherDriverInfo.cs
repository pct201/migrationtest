#region Includes
	using System;
	using System.Collections.Generic;
	using System.Text;
#endregion

namespace RIMS_Base
{

[Serializable]
public abstract class CLiabilityClaimOtherDriverInfo
{

	#region Constructor
    public CLiabilityClaimOtherDriverInfo()
	{

        this._pk_Otherdriver = -1;
		this._fK_Liability_Claim = -1;
		this._driver_Name = string.Empty;
		this._driver_Address1 = string.Empty;
		this._driver_Address2 = string.Empty;
		this._driver_City = string.Empty;
		//this._fK_Driver_State = -1;
		this._driver_Zipcode = string.Empty;
		this._driver_Telephone = string.Empty;
		this._driver_License_Number = string.Empty;
		//this._fK_Driver_License_State = -1;
		this._insurance_Carrier = string.Empty;
		this._insurance_Telephone = string.Empty;
		this._insurance_Agent_Name = string.Empty;
		this._insurance_Agent_Telephone = string.Empty;
		this._policy_number = string.Empty;
		this._updated_By = string.Empty;
		this._updated_Date = DateTime.Now;
        this._fld_State = string.Empty;
	}
	#endregion

	#region Private Variables 
    private System.Int32 _pk_Otherdriver;
    private System.Int32 _fK_Liability_Claim;
	private System.String _driver_Name;
	private System.String _driver_Address1;
	private System.String _driver_Address2;
	private System.String _driver_City;
	private System.Decimal ? _fK_Driver_State;
	private System.String _driver_Zipcode;
	private System.String _driver_Telephone;
	private System.String _driver_License_Number;
	private System.Decimal ? _fK_Driver_License_State;
	private System.String _insurance_Carrier;
	private System.String _insurance_Telephone;
	private System.String _insurance_Agent_Name;
	private System.String _insurance_Agent_Telephone;
	private System.String _policy_number;
	private System.String _updated_By;
	private System.DateTime _updated_Date;
    private System.String _fld_State;
	#endregion

	#region Public Properties

    public System.String FLD_State
    {
        get { return _fld_State; }
        set { _fld_State = value; }
    }

    public System.Int32 PK_Otherdriver
	{
        get { return _pk_Otherdriver; }
        set { _pk_Otherdriver = value; }
	}

    public System.Int32 FK_Liability_Claim
	{
		get { return  _fK_Liability_Claim; }
		set { _fK_Liability_Claim = value; }
	}

	public System.String Driver_Name
	{
		get { return  _driver_Name; }
		set { _driver_Name = value; }
	}

	public System.String Driver_Address1
	{
		get { return  _driver_Address1; }
		set { _driver_Address1 = value; }
	}

	public System.String Driver_Address2
	{
		get { return  _driver_Address2; }
		set { _driver_Address2 = value; }
	}

	public System.String Driver_City
	{
		get { return  _driver_City; }
		set { _driver_City = value; }
	}

	public System.Decimal ? FK_Driver_State
	{
		get { return  _fK_Driver_State; }
		set { _fK_Driver_State = value; }
	}

	public System.String Driver_Zipcode
	{
		get { return  _driver_Zipcode; }
		set { _driver_Zipcode = value; }
	}

	public System.String Driver_Telephone
	{
		get { return  _driver_Telephone; }
		set { _driver_Telephone = value; }
	}

	public System.String Driver_License_Number
	{
		get { return  _driver_License_Number; }
		set { _driver_License_Number = value; }
	}

	public System.Decimal ? FK_Driver_License_State
	{
		get { return  _fK_Driver_License_State; }
		set { _fK_Driver_License_State = value; }
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

	public System.String Policy_number
	{
		get { return  _policy_number; }
		set { _policy_number = value; }
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
	public abstract List<CLiabilityClaimOtherDriverInfo> GetAll();
    public abstract List<CLiabilityClaimOtherDriverInfo> GetAL_Claim_OtherDriverInfoByID(System.Decimal lFK_Liability_Claim);
	public abstract int InsertUpdateility_Claim_OtherDriverInfo(RIMS_Base.CLiabilityClaimOtherDriverInfo obj);
    public abstract int Deleteility_Claim_OtherDriverInfo(System.Int32 pk_Otherdriver);
	public abstract string ActivateInactivateility_Claim_OtherDriverInfo(string strIDs, int intModifiedBy, bool bIsActive);
    public abstract List<CLiabilityClaimOtherDriverInfo> Get_Claim_OtherDriverInfoByID(System.Int32 pk_Otherdriver);
	#endregion

}

}
