#region Includes
	using System;
	using System.Collections.Generic;
	using System.Text;
#endregion

namespace RIMS_Base.Biz
{

[Serializable]
public class CLiabilityClaimOtherPropertyDamage : RIMS_Base.CLiabilityClaimOtherPropertyDamage
{
	#region Private Declarations
	RIMS_Base.CLiabilityClaimOtherPropertyDamage mObjIlity_Claim_OtherPropertyDamage;
	#endregion

	#region Constructor
	public CLiabilityClaimOtherPropertyDamage()
	{
		mObjIlity_Claim_OtherPropertyDamage = new RIMS_Base.Dal.CLiabilityClaimOtherPropertyDamage();
	}
	#endregion

	#region Public Methods
	public override int InsertUpdateility_Claim_OtherPropertyDamage(RIMS_Base.CLiabilityClaimOtherPropertyDamage Objility_Claim_OtherPropertyDamage)
	{
		return mObjIlity_Claim_OtherPropertyDamage.InsertUpdateility_Claim_OtherPropertyDamage(Objility_Claim_OtherPropertyDamage);
	}

	public override int Deleteility_Claim_OtherPropertyDamage(System.Decimal lFK_Liability_Claim)
	{
		return mObjIlity_Claim_OtherPropertyDamage.Deleteility_Claim_OtherPropertyDamage(lFK_Liability_Claim);
	} 

	public override string ActivateInactivateility_Claim_OtherPropertyDamage(string strIDs, int intModifiedBy, bool bIsActive)
	{
		return mObjIlity_Claim_OtherPropertyDamage.ActivateInactivateility_Claim_OtherPropertyDamage(strIDs, intModifiedBy, bIsActive);
	}

    public override List<RIMS_Base.CLiabilityClaimOtherPropertyDamage> GetAL_Claim_OtherPropertyDamageByID(System.Decimal lFK_Liability_Claim)
	{
		return mObjIlity_Claim_OtherPropertyDamage.GetAL_Claim_OtherPropertyDamageByID(lFK_Liability_Claim);
	}

	public override List<RIMS_Base.CLiabilityClaimOtherPropertyDamage> GetAll(Boolean blnIsActive)
	{
		return mObjIlity_Claim_OtherPropertyDamage.GetAll(blnIsActive);
	}
	#endregion

}

}