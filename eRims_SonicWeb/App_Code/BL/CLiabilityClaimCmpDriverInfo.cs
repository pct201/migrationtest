#region Includes
	using System;
	using System.Collections.Generic;
	using System.Text;
#endregion

namespace RIMS_Base.Biz
{

[Serializable]
public class CLiabilityClaimCmpDriverInfo : RIMS_Base.CLiabilityClaimCmpDriverInfo
{
	#region Private Declarations
	RIMS_Base.CLiabilityClaimCmpDriverInfo mObjLility_Claim_CmpDriverInfo;
	#endregion

	#region Constructor
	public CLiabilityClaimCmpDriverInfo()
	{
		mObjLility_Claim_CmpDriverInfo = new RIMS_Base.Dal.CLiabilityClaimCmpDriverInfo();
	}
	#endregion

	#region Public Methods
	public override int InsertUpdatelility_Claim_CmpDriverInfo(RIMS_Base.CLiabilityClaimCmpDriverInfo Objlility_Claim_CmpDriverInfo)
	{
		return mObjLility_Claim_CmpDriverInfo.InsertUpdatelility_Claim_CmpDriverInfo(Objlility_Claim_CmpDriverInfo);
	}

	public override int Deletelility_Claim_CmpDriverInfo(System.Decimal lFK_Liability_Claim)
	{
		return mObjLility_Claim_CmpDriverInfo.Deletelility_Claim_CmpDriverInfo(lFK_Liability_Claim);
	} 

	public override string ActivateInactivatelility_Claim_CmpDriverInfo(string strIDs, int intModifiedBy, bool bIsActive)
	{
		return mObjLility_Claim_CmpDriverInfo.ActivateInactivatelility_Claim_CmpDriverInfo(strIDs, intModifiedBy, bIsActive);
	}

    public override List<RIMS_Base.CLiabilityClaimCmpDriverInfo> GetAL_Claim_CmpDriverInfoByID(System.Decimal lFK_Liability_Claim)
	{
		return mObjLility_Claim_CmpDriverInfo.GetAL_Claim_CmpDriverInfoByID(lFK_Liability_Claim);
	}

	public override List<RIMS_Base.CLiabilityClaimCmpDriverInfo> GetAll(Boolean blnIsActive)
	{
		return mObjLility_Claim_CmpDriverInfo.GetAll(blnIsActive);
	}
	#endregion

}

}