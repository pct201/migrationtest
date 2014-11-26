#region Includes
	using System;
	using System.Collections.Generic;
	using System.Text;
#endregion

namespace RIMS_Base
{

[Serializable]
public abstract class CLiabilityClaimPropertyDamage
{

	#region Constructor
    public CLiabilityClaimPropertyDamage()
	{
		this._fK_Liability_Claim = -1;
		this._property_Owner = string.Empty;
		this._name = string.Empty;
		this._address1 = string.Empty;
		this._address2 = string.Empty;
		this._city = string.Empty;
		//this._fK_State = -1;
        this._zipcode = string.Empty;
		this._home_TeleNo = string.Empty;
		this._work_TeleNo = string.Empty;
		this._cell_TeleNo = string.Empty;
		this._email = string.Empty;
		this._desc_Of_Damage = string.Empty;
		//this._cost_Of_Damage = -1;
		this._copy_Estimated_Received = string.Empty;
		this._updated_By = string.Empty;
		this._updated_Date = DateTime.Now;
	}
	#endregion

	#region Private Variables 
    private System.Int32 _fK_Liability_Claim;
	private System.String _property_Owner;
	private System.String _name;
	private System.String _address1;
	private System.String _address2;
	private System.String _city;
	private System.Decimal _fK_State;
    private System.String _zipcode;
	private System.String _home_TeleNo;
	private System.String _work_TeleNo;
	private System.String _cell_TeleNo;
	private System.String _email;
	private System.String _desc_Of_Damage;
	private System.Decimal _cost_Of_Damage;
	private System.String _copy_Estimated_Received;
	private System.String _updated_By;
	private System.DateTime _updated_Date;
	#endregion

	#region Public Properties
    public System.Int32 FK_Liability_Claim
	{
		get { return  _fK_Liability_Claim; }
		set { _fK_Liability_Claim = value; }
	}

	public System.String Property_Owner
	{
		get { return  _property_Owner; }
		set { _property_Owner = value; }
	}

	public System.String Name
	{
		get { return  _name; }
		set { _name = value; }
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

	public System.Decimal FK_State
	{
		get { return  _fK_State; }
		set { _fK_State = value; }
	}
    public System.String Zipcode
    {
        get { return _zipcode; }
        set { _zipcode = value; }
    }

	public System.String Home_TeleNo
	{
		get { return  _home_TeleNo; }
		set { _home_TeleNo = value; }
	}

	public System.String Work_TeleNo
	{
		get { return  _work_TeleNo; }
		set { _work_TeleNo = value; }
	}

	public System.String Cell_TeleNo
	{
		get { return  _cell_TeleNo; }
		set { _cell_TeleNo = value; }
	}

	public System.String Email
	{
		get { return  _email; }
		set { _email = value; }
	}

	public System.String Desc_Of_Damage
	{
		get { return  _desc_Of_Damage; }
		set { _desc_Of_Damage = value; }
	}

	public System.Decimal Cost_Of_Damage
	{
		get { return  _cost_Of_Damage; }
		set { _cost_Of_Damage = value; }
	}

	public System.String Copy_Estimated_Received
	{
		get { return  _copy_Estimated_Received; }
		set { _copy_Estimated_Received = value; }
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
    public abstract List<CLiabilityClaimPropertyDamage> GetAll(Boolean blnIsActive);
    public abstract List<CLiabilityClaimPropertyDamage> GetGL_Claim_PropertyDamageByID(System.Decimal lFK_Liability_Claim);
    public abstract int InsertUpdateility_Claim_PropertyDamage(RIMS_Base.CLiabilityClaimPropertyDamage obj);
	public abstract int Deleteility_Claim_PropertyDamage(System.Decimal lFK_Liability_Claim);
	public abstract string ActivateInactivateility_Claim_PropertyDamage(string strIDs, int intModifiedBy, bool bIsActive);
	#endregion

}

}
