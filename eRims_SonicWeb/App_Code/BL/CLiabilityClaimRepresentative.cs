#region Includes
	using System;
	using System.Collections.Generic;
	using System.Text;
#endregion

namespace RIMS_Base.Biz
{

[Serializable]
public class CLiabilityClaimRepresentative : RIMS_Base.CLiabilityClaimRepresentative
{
	#region Private Declarations
	RIMS_Base.CLiabilityClaimRepresentative mObjIlity_Claim_Representative;
	#endregion

	#region Constructor
	public CLiabilityClaimRepresentative()
	{
		mObjIlity_Claim_Representative = new RIMS_Base.Dal.CLiabilityClaimRepresentative();
	}
	#endregion

	#region Public Methods
	public override int InsertUpdateility_Claim_Representative(RIMS_Base.CLiabilityClaimRepresentative Objility_Claim_Representative)
	{
		return mObjIlity_Claim_Representative.InsertUpdateility_Claim_Representative(Objility_Claim_Representative);
	}

	public override int Deleteility_Claim_Representative(System.Decimal lFK_Liability_Claim)
	{
		return mObjIlity_Claim_Representative.Deleteility_Claim_Representative(lFK_Liability_Claim);
	} 

	public override string ActivateInactivateility_Claim_Representative(string strIDs, int intModifiedBy, bool bIsActive)
	{
		return mObjIlity_Claim_Representative.ActivateInactivateility_Claim_Representative(strIDs, intModifiedBy, bIsActive);
	}

    public override List<RIMS_Base.CLiabilityClaimRepresentative> GetAL_Claim_RepresentativeByID(System.Decimal lFK_Liability_Claim)
	{
		return mObjIlity_Claim_Representative.GetAL_Claim_RepresentativeByID(lFK_Liability_Claim);
	}

	public override List<RIMS_Base.CLiabilityClaimRepresentative> GetAll(Boolean blnIsActive)
	{
		return mObjIlity_Claim_Representative.GetAll(blnIsActive);
	}
	#endregion

}

}