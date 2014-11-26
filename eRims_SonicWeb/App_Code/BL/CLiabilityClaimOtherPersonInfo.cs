#region Includes
	using System;
	using System.Collections.Generic;
	using System.Text;
#endregion

namespace RIMS_Base.Biz
{

[Serializable]
public class CLiabilityClaimOtherPersonInfo : RIMS_Base.CLiabilityClaimOtherPersonInfo
{
	#region Private Declarations
	RIMS_Base.CLiabilityClaimOtherPersonInfo mObjIlity_Claim_OtherPersonInfo;
	#endregion

	#region Constructor
	public CLiabilityClaimOtherPersonInfo()
	{
		mObjIlity_Claim_OtherPersonInfo = new RIMS_Base.Dal.CLiabilityClaimOtherPersonInfo();
	}
	#endregion

	#region Public Methods
	public override int InsertUpdateility_Claim_OtherPersonInfo(RIMS_Base.CLiabilityClaimOtherPersonInfo Objility_Claim_OtherPersonInfo)
	{
		return mObjIlity_Claim_OtherPersonInfo.InsertUpdateility_Claim_OtherPersonInfo(Objility_Claim_OtherPersonInfo);
	}

    public override int Delete_Claim_OtherPersonInfo(System.Int32 pk_Injured_Person)
	{
        return mObjIlity_Claim_OtherPersonInfo.Delete_Claim_OtherPersonInfo(pk_Injured_Person);
	} 

	public override string ActivateInactivateility_Claim_OtherPersonInfo(string strIDs, int intModifiedBy, bool bIsActive)
	{
		return mObjIlity_Claim_OtherPersonInfo.ActivateInactivateility_Claim_OtherPersonInfo(strIDs, intModifiedBy, bIsActive);
	}

    public override List<RIMS_Base.CLiabilityClaimOtherPersonInfo> GetAL_Claim_OtherPersonInfoByID(System.Decimal lFK_Liability_Claim)
	{
		return mObjIlity_Claim_OtherPersonInfo.GetAL_Claim_OtherPersonInfoByID(lFK_Liability_Claim);
	}

    public override List<RIMS_Base.CLiabilityClaimOtherPersonInfo> Get_Claim_OtherPersonInfoByID(System.Int32 pk_Injured_Person)
    {
        return mObjIlity_Claim_OtherPersonInfo.Get_Claim_OtherPersonInfoByID(pk_Injured_Person);
    }

	public override List<RIMS_Base.CLiabilityClaimOtherPersonInfo> GetAll()
	{
		return mObjIlity_Claim_OtherPersonInfo.GetAll();
	}
	#endregion

}

}