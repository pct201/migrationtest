#region Includes
	using System;
	using System.Collections.Generic;
	using System.Text;
#endregion

namespace RIMS_Base
{

[Serializable]
public abstract class CLiabilityClaimOtherPropertyDamage
{

	#region Constructor
    public CLiabilityClaimOtherPropertyDamage()
	{
		this._fK_Liability_Claim = -1;
		this._damage_To_Property = string.Empty;
		this._damage_Desc = string.Empty;
		//this._cost_To_Repair = 0;
	}
	#endregion

	#region Private Variables 
    private System.Int32 _fK_Liability_Claim;
	private System.String _damage_To_Property;
	private System.String _damage_Desc;
	private System.Decimal ? _cost_To_Repair;
	#endregion

	#region Public Properties
    public System.Int32 FK_Liability_Claim
	{
		get { return  _fK_Liability_Claim; }
		set { _fK_Liability_Claim = value; }
	}

	public System.String Damage_To_Property
	{
		get { return  _damage_To_Property; }
		set { _damage_To_Property = value; }
	}

	public System.String Damage_Desc
	{
		get { return  _damage_Desc; }
		set { _damage_Desc = value; }
	}

	public System.Decimal ? Cost_To_Repair
	{
		get { return  _cost_To_Repair; }
		set { _cost_To_Repair = value; }
	}

	#endregion

	#region Abstract Methods
	public abstract List<CLiabilityClaimOtherPropertyDamage> GetAll(Boolean blnIsActive);
    public abstract List<CLiabilityClaimOtherPropertyDamage> GetAL_Claim_OtherPropertyDamageByID(System.Decimal lFK_Liability_Claim);
	public abstract int InsertUpdateility_Claim_OtherPropertyDamage(RIMS_Base.CLiabilityClaimOtherPropertyDamage obj);
	public abstract int Deleteility_Claim_OtherPropertyDamage(System.Decimal lFK_Liability_Claim);
	public abstract string ActivateInactivateility_Claim_OtherPropertyDamage(string strIDs, int intModifiedBy, bool bIsActive);
	#endregion

}

}
