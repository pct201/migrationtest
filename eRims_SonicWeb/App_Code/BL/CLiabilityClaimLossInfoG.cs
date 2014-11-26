#region Includes
	using System;
	using System.Collections.Generic;
	using System.Text;
#endregion

namespace RIMS_Base.Biz
{

[Serializable]
public class CLiabilityClaimLossInfoG : RIMS_Base.CLiabilityClaimLossInfoG
{
	#region Private Declarations
	RIMS_Base.CLiabilityClaimLossInfoG mObjIlity_Claim_LossInfo_G;
	#endregion

	#region Constructor
	public CLiabilityClaimLossInfoG()
	{
		mObjIlity_Claim_LossInfo_G = new RIMS_Base.Dal.CLiabilityClaimLossInfoG();
	}
	#endregion

	#region Public Methods
	public override int InsertUpdateility_Claim_LossInfo_G(RIMS_Base.CLiabilityClaimLossInfoG Objility_Claim_LossInfo_G)
	{
		return mObjIlity_Claim_LossInfo_G.InsertUpdateility_Claim_LossInfo_G(Objility_Claim_LossInfo_G);
	}

	public override int Deleteility_Claim_LossInfo_G(System.Decimal lFK_Liability_Claim)
	{
		return mObjIlity_Claim_LossInfo_G.Deleteility_Claim_LossInfo_G(lFK_Liability_Claim);
	} 

	public override string ActivateInactivateility_Claim_LossInfo_G(string strIDs, int intModifiedBy, bool bIsActive)
	{
		return mObjIlity_Claim_LossInfo_G.ActivateInactivateility_Claim_LossInfo_G(strIDs, intModifiedBy, bIsActive);
	} 

	public override List<RIMS_Base.CLiabilityClaimLossInfoG> GetGL_Claim_LossInfo_GByID(System.Decimal lFK_Liability_Claim)
	{
		return mObjIlity_Claim_LossInfo_G.GetGL_Claim_LossInfo_GByID(lFK_Liability_Claim);
	}

	public override List<RIMS_Base.CLiabilityClaimLossInfoG> GetAll(Boolean blnIsActive)
	{
		return mObjIlity_Claim_LossInfo_G.GetAll(blnIsActive);
	}
	#endregion

}

}