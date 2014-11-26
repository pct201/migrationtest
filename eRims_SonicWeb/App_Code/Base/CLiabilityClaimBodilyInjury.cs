#region Includes
	using System;
	using System.Collections.Generic;
	using System.Text;
#endregion

namespace RIMS_Base
{

[Serializable]
public abstract class CLiabilityClaimBodilyInjury
{

	#region Constructor
    public CLiabilityClaimBodilyInjury()
	{
		this._fK_Liability_Claim = -1;
		this._desc_Injury = string.Empty;
		this._name_Of_Facility = string.Empty;
		this._address_1 = string.Empty;
		this._address_2 = string.Empty;
		this._city = string.Empty;
		//this._fK_State = -1;
		this._zipCode = string.Empty;
		this._telePhone = string.Empty;
		this._facsimile = string.Empty;
		//this._cost_Of_Treatment = -1;
		this._medical_Bill_Received = string.Empty;
		this._updated_By = string.Empty;
		this._updated_Date = DateTime.Now;
	}
	#endregion

	#region Private Variables 
	private System.Int32 _fK_Liability_Claim;
	private System.String _desc_Injury;
	private System.String _name_Of_Facility;
	private System.String _address_1;
	private System.String _address_2;
	private System.String _city;
	private System.Decimal _fK_State;
	private System.String _zipCode;
	private System.String _telePhone;
	private System.String _facsimile;
	private System.Decimal _cost_Of_Treatment;
	private System.String _medical_Bill_Received;
	private System.String _updated_By;
	private System.DateTime _updated_Date;
	#endregion

	#region Public Properties
    public System.Int32 FK_Liability_Claim
	{
		get { return  _fK_Liability_Claim; }
		set { _fK_Liability_Claim = value; }
	}

	public System.String Desc_Injury
	{
		get { return  _desc_Injury; }
		set { _desc_Injury = value; }
	}

	public System.String Name_Of_Facility
	{
		get { return  _name_Of_Facility; }
		set { _name_Of_Facility = value; }
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

	public System.Decimal FK_State
	{
		get { return  _fK_State; }
		set { _fK_State = value; }
	}

	public System.String ZipCode
	{
		get { return  _zipCode; }
		set { _zipCode = value; }
	}

	public System.String TelePhone
	{
		get { return  _telePhone; }
		set { _telePhone = value; }
	}

	public System.String Facsimile
	{
		get { return  _facsimile; }
		set { _facsimile = value; }
	}

	public System.Decimal Cost_Of_Treatment
	{
		get { return  _cost_Of_Treatment; }
		set { _cost_Of_Treatment = value; }
	}

	public System.String Medical_Bill_Received
	{
		get { return  _medical_Bill_Received; }
		set { _medical_Bill_Received = value; }
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
    public abstract List<CLiabilityClaimBodilyInjury> GetAll(Boolean blnIsActive);
    public abstract List<CLiabilityClaimBodilyInjury> GetGL_Claim_BodilyInjuryByID(System.Decimal lFK_Liability_Claim);
    public abstract int InsertUpdateility_Claim_BodilyInjury(RIMS_Base.CLiabilityClaimBodilyInjury obj);
	public abstract int Deleteility_Claim_BodilyInjury(System.Decimal lFK_Liability_Claim);
	public abstract string ActivateInactivateility_Claim_BodilyInjury(string strIDs, int intModifiedBy, bool bIsActive);
	#endregion

}

}
