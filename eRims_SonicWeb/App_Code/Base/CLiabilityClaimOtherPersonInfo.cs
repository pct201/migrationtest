#region Includes
	using System;
	using System.Collections.Generic;
	using System.Text;
#endregion

namespace RIMS_Base
{

[Serializable]
public abstract class CLiabilityClaimOtherPersonInfo
{

	#region Constructor
    public CLiabilityClaimOtherPersonInfo()
	{
        this._pk_Injured_Person = -1;
		this._fK_Liability_Claim = -1;
		this._injured_Person_name = string.Empty;
		this._injured_Person_Address1 = string.Empty;
		this._injured_Person_Address2 = string.Empty;
		this._injured_Person_City = string.Empty;
		//this._fK_Person_State = -1;
		this._injured_Person_Zipcode = string.Empty;
		this._injured_Person_Telephone = string.Empty;
		//this._fK_InjuredType_Was = -1;
		this._desc_Injuries = string.Empty;
		this._updated_By = string.Empty;
		this._updated_Date = DateTime.Now;
        this._fld_State = string.Empty;
	}
	#endregion

	#region Private Variables 
    private System.Int32 _pk_Injured_Person;
    private System.Int32 _fK_Liability_Claim;
	private System.String _injured_Person_name;
	private System.String _injured_Person_Address1;
	private System.String _injured_Person_Address2;
	private System.String _injured_Person_City;
	private System.Decimal ? _fK_Person_State;
	private System.String _injured_Person_Zipcode;
	private System.String _injured_Person_Telephone;
	private System.Decimal ? _fK_InjuredType_Was;
	private System.String _desc_Injuries;
	private System.String _updated_By;
	private System.DateTime _updated_Date;
    private System.String _fld_State;
	#endregion

	#region Public Properties

    public System.Int32 PK_Injured_Person
    {
        get { return _pk_Injured_Person; }
        set { _pk_Injured_Person = value; }
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

	public System.String Injured_Person_name
	{
		get { return  _injured_Person_name; }
		set { _injured_Person_name = value; }
	}

	public System.String Injured_Person_Address1
	{
		get { return  _injured_Person_Address1; }
		set { _injured_Person_Address1 = value; }
	}

	public System.String Injured_Person_Address2
	{
		get { return  _injured_Person_Address2; }
		set { _injured_Person_Address2 = value; }
	}

	public System.String Injured_Person_City
	{
		get { return  _injured_Person_City; }
		set { _injured_Person_City = value; }
	}

	public System.Decimal ? FK_Person_State
	{
		get { return  _fK_Person_State; }
		set { _fK_Person_State = value; }
	}

	public System.String Injured_Person_Zipcode
	{
		get { return  _injured_Person_Zipcode; }
		set { _injured_Person_Zipcode = value; }
	}

	public System.String Injured_Person_Telephone
	{
		get { return  _injured_Person_Telephone; }
		set { _injured_Person_Telephone = value; }
	}

	public System.Decimal ? FK_InjuredType_Was
	{
		get { return  _fK_InjuredType_Was; }
		set { _fK_InjuredType_Was = value; }
	}

	public System.String Desc_Injuries
	{
		get { return  _desc_Injuries; }
		set { _desc_Injuries = value; }
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
    public abstract List<CLiabilityClaimOtherPersonInfo> GetAll();
    public abstract List<CLiabilityClaimOtherPersonInfo> GetAL_Claim_OtherPersonInfoByID(System.Decimal lFK_Liability_Claim);
    public abstract int InsertUpdateility_Claim_OtherPersonInfo(RIMS_Base.CLiabilityClaimOtherPersonInfo obj);
    public abstract int Delete_Claim_OtherPersonInfo(System.Int32 pk_Injured_Person);
	public abstract string ActivateInactivateility_Claim_OtherPersonInfo(string strIDs, int intModifiedBy, bool bIsActive);
    public abstract List<CLiabilityClaimOtherPersonInfo> Get_Claim_OtherPersonInfoByID(System.Int32 pk_Injured_Person);
    
	#endregion

}

}
