#region Includes
	using System;
	using System.Collections.Generic;
	using System.Text;
#endregion

namespace RIMS_Base.Biz
{

[Serializable]
public class CLiabilityClaimLossInfo : RIMS_Base.CLiabilityClaimLossInfo
{
	#region Private Declarations
	RIMS_Base.CLiabilityClaimLossInfo mObjIlity_Claim_LossInfo;
	#endregion

	#region Constructor
	public CLiabilityClaimLossInfo()
	{
		mObjIlity_Claim_LossInfo = new RIMS_Base.Dal.CLiabilityClaimLossInfo();
	}
	#endregion

	#region Public Methods
	public override int InsertUpdateility_Claim_LossInfo(RIMS_Base.CLiabilityClaimLossInfo Objility_Claim_LossInfo)
	{
		return mObjIlity_Claim_LossInfo.InsertUpdateility_Claim_LossInfo(Objility_Claim_LossInfo);
	}

	public override int Deleteility_Claim_LossInfo(System.Decimal lFK_Liability_Claim)
	{
		return mObjIlity_Claim_LossInfo.Deleteility_Claim_LossInfo(lFK_Liability_Claim);
	} 

	public override string ActivateInactivateility_Claim_LossInfo(string strIDs, int intModifiedBy, bool bIsActive)
	{
		return mObjIlity_Claim_LossInfo.ActivateInactivateility_Claim_LossInfo(strIDs, intModifiedBy, bIsActive);
	}

    public override List<RIMS_Base.CLiabilityClaimLossInfo> GetAL_Claim_LossInfoByID(System.Decimal lFK_Liability_Claim)
	{
		return mObjIlity_Claim_LossInfo.GetAL_Claim_LossInfoByID(lFK_Liability_Claim);
	}

	public override List<RIMS_Base.CLiabilityClaimLossInfo> GetAll(Boolean blnIsActive)
	{
		return mObjIlity_Claim_LossInfo.GetAll(blnIsActive);
	}
	#endregion

}

}