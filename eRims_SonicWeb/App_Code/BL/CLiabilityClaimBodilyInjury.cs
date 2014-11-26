#region Includes
	using System;
	using System.Collections.Generic;
	using System.Text;
#endregion

namespace RIMS_Base.Biz
{

[Serializable]
public class CLiabilityClaimBodilyInjury : RIMS_Base.CLiabilityClaimBodilyInjury
{
	#region Private Declarations
	RIMS_Base.CLiabilityClaimBodilyInjury mObjIlity_Claim_BodilyInjury;
	#endregion

	#region Constructor
	public CLiabilityClaimBodilyInjury()
	{
		mObjIlity_Claim_BodilyInjury = new RIMS_Base.Dal.CLiabilityClaimBodilyInjury();
	}
	#endregion

	#region Public Methods
	public override int InsertUpdateility_Claim_BodilyInjury(RIMS_Base.CLiabilityClaimBodilyInjury Objility_Claim_BodilyInjury)
	{
		return mObjIlity_Claim_BodilyInjury.InsertUpdateility_Claim_BodilyInjury(Objility_Claim_BodilyInjury);
	}

	public override int Deleteility_Claim_BodilyInjury(System.Decimal lFK_Liability_Claim)
	{
		return mObjIlity_Claim_BodilyInjury.Deleteility_Claim_BodilyInjury(lFK_Liability_Claim);
	} 

	public override string ActivateInactivateility_Claim_BodilyInjury(string strIDs, int intModifiedBy, bool bIsActive)
	{
		return mObjIlity_Claim_BodilyInjury.ActivateInactivateility_Claim_BodilyInjury(strIDs, intModifiedBy, bIsActive);
	} 

	public override List<RIMS_Base.CLiabilityClaimBodilyInjury> GetGL_Claim_BodilyInjuryByID(System.Decimal lFK_Liability_Claim)
	{
		return mObjIlity_Claim_BodilyInjury.GetGL_Claim_BodilyInjuryByID(lFK_Liability_Claim);
	}

	public override List<RIMS_Base.CLiabilityClaimBodilyInjury> GetAll(Boolean blnIsActive)
	{
		return mObjIlity_Claim_BodilyInjury.GetAll(blnIsActive);
	}
	#endregion

}

}