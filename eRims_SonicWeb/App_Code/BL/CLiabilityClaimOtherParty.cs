#region Includes
	using System;
	using System.Collections.Generic;
	using System.Text;
#endregion

namespace RIMS_Base.Biz
{

[Serializable]
public class CLiabilityClaimOtherParty : RIMS_Base.CLiabilityClaimOtherParty
{
	#region Private Declarations
	RIMS_Base.CLiabilityClaimOtherParty mObjIlity_Claim_OtherParty;
	#endregion

	#region Constructor
	public CLiabilityClaimOtherParty()
	{
		mObjIlity_Claim_OtherParty = new RIMS_Base.Dal.CLiabilityClaimOtherParty();
	}
	#endregion

	#region Public Methods
	public override int InsertUpdateility_Claim_OtherParty(RIMS_Base.CLiabilityClaimOtherParty Objility_Claim_OtherParty)
	{
		return mObjIlity_Claim_OtherParty.InsertUpdateility_Claim_OtherParty(Objility_Claim_OtherParty);
	}

	public override int Deleteility_Claim_OtherParty(System.Decimal lFK_Liability_Claim)
	{
		return mObjIlity_Claim_OtherParty.Deleteility_Claim_OtherParty(lFK_Liability_Claim);
	} 

	public override string ActivateInactivateility_Claim_OtherParty(string strIDs, int intModifiedBy, bool bIsActive)
	{
		return mObjIlity_Claim_OtherParty.ActivateInactivateility_Claim_OtherParty(strIDs, intModifiedBy, bIsActive);
	}

    public override List<RIMS_Base.CLiabilityClaimOtherParty> GetAL_Claim_OtherPartyByID(System.Decimal lFK_Liability_Claim)
	{
		return mObjIlity_Claim_OtherParty.GetAL_Claim_OtherPartyByID(lFK_Liability_Claim);
	}

	public override List<RIMS_Base.CLiabilityClaimOtherParty> GetAll(Boolean blnIsActive)
	{
		return mObjIlity_Claim_OtherParty.GetAll(blnIsActive);
	}
	#endregion

}

}