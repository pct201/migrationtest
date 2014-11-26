#region Includes
	using System;
	using System.Collections.Generic;
	using System.Text;
#endregion

namespace RIMS_Base.Biz
{

[Serializable]
public class CLiabilityClaimPropertyDamage : RIMS_Base.CLiabilityClaimPropertyDamage
{
	#region Private Declarations
	RIMS_Base.CLiabilityClaimPropertyDamage mObjIlity_Claim_PropertyDamage;
	#endregion

	#region Constructor
	public CLiabilityClaimPropertyDamage()
	{
		mObjIlity_Claim_PropertyDamage = new RIMS_Base.Dal.CLiabilityClaimPropertyDamage();
	}
	#endregion

	#region Public Methods
	public override int InsertUpdateility_Claim_PropertyDamage(RIMS_Base.CLiabilityClaimPropertyDamage Objility_Claim_PropertyDamage)
	{
		return mObjIlity_Claim_PropertyDamage.InsertUpdateility_Claim_PropertyDamage(Objility_Claim_PropertyDamage);
	}

	public override int Deleteility_Claim_PropertyDamage(System.Decimal lFK_Liability_Claim)
	{
		return mObjIlity_Claim_PropertyDamage.Deleteility_Claim_PropertyDamage(lFK_Liability_Claim);
	} 

	public override string ActivateInactivateility_Claim_PropertyDamage(string strIDs, int intModifiedBy, bool bIsActive)
	{
		return mObjIlity_Claim_PropertyDamage.ActivateInactivateility_Claim_PropertyDamage(strIDs, intModifiedBy, bIsActive);
	} 

	public override List<RIMS_Base.CLiabilityClaimPropertyDamage> GetGL_Claim_PropertyDamageByID(System.Decimal lFK_Liability_Claim)
	{
		return mObjIlity_Claim_PropertyDamage.GetGL_Claim_PropertyDamageByID(lFK_Liability_Claim);
	}

	public override List<RIMS_Base.CLiabilityClaimPropertyDamage> GetAll(Boolean blnIsActive)
	{
		return mObjIlity_Claim_PropertyDamage.GetAll(blnIsActive);
	}
	#endregion

}

}