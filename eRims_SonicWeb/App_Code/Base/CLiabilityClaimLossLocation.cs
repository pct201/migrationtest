#region Includes
	using System;
	using System.Collections.Generic;
	using System.Text;
#endregion

namespace RIMS_Base
{

[Serializable]
public abstract class CLiabilityClaimLossLocation
{

	#region Constructor
    public CLiabilityClaimLossLocation()
	{
		this._fK_Liability_Claim = -1;
		this._address1 = string.Empty;
		this._address2 = string.Empty;
		this._city = string.Empty;
		//this._fK_State = -1;
		this._zip = string.Empty;
		this._county = string.Empty;
		this._accident_In_Company = string.Empty;
		this._updated_By = string.Empty;
		this._updated_Date = DateTime.Now;
	}
	#endregion

	#region Private Variables 
    private System.Int32 _fK_Liability_Claim;
	private System.String _address1;
	private System.String _address2;
	private System.String _city;
	private System.Decimal ? _fK_State;
	private System.String _zip;
	private System.String  _county;
	private System.String _accident_In_Company;
	private System.String _updated_By;
	private System.DateTime _updated_Date;
	#endregion

	#region Public Properties
    public System.Int32 FK_Liability_Claim
	{
		get { return  _fK_Liability_Claim; }
		set { _fK_Liability_Claim = value; }
	}

	public System.String Address1
	{
		get { return  _address1; }
		set { _address1 = value; }
	}

	public System.String Address2
	{
		get { return  _address2; }
		set { _address2 = value; }
	}

	public System.String City
	{
		get { return  _city; }
		set { _city = value; }
	}

	public System.Decimal ? FK_State
	{
		get { return  _fK_State; }
		set { _fK_State = value; }
	}

	public System.String Zip
	{
		get { return  _zip; }
		set { _zip = value; }
	}

	public System.String County
	{
		get { return  _county; }
		set { _county = value; }
	}

	public System.String Accident_In_Company
	{
		get { return  _accident_In_Company; }
		set { _accident_In_Company = value; }
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
    public abstract List<CLiabilityClaimLossLocation> GetAll(Boolean blnIsActive);
    public abstract List<CLiabilityClaimLossLocation> GetAL_Claim_LossLocationByID(System.Decimal lFK_Liability_Claim);
    public abstract int InsertUpdateility_Claim_LossLocation(RIMS_Base.CLiabilityClaimLossLocation obj);
	public abstract int Deleteility_Claim_LossLocation(System.Decimal lFK_Liability_Claim);
	public abstract string ActivateInactivateility_Claim_LossLocation(string strIDs, int intModifiedBy, bool bIsActive);
	#endregion

}

}
