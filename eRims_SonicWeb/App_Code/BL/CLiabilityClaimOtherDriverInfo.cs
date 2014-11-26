#region Includes
	using System;
	using System.Collections.Generic;
	using System.Text;
#endregion

namespace RIMS_Base.Biz
{

[Serializable]
public class CLiabilityClaimOtherDriverInfo : RIMS_Base.CLiabilityClaimOtherDriverInfo
{
	#region Private Declarations
	RIMS_Base.CLiabilityClaimOtherDriverInfo mObjIlity_Claim_OtherDriverInfo;
	#endregion

	#region Constructor
	public CLiabilityClaimOtherDriverInfo()
	{
		mObjIlity_Claim_OtherDriverInfo = new RIMS_Base.Dal.CLiabilityClaimOtherDriverInfo();
	}
	#endregion

	#region Public Methods
	public override int InsertUpdateility_Claim_OtherDriverInfo(RIMS_Base.CLiabilityClaimOtherDriverInfo Objility_Claim_OtherDriverInfo)
	{
		return mObjIlity_Claim_OtherDriverInfo.InsertUpdateility_Claim_OtherDriverInfo(Objility_Claim_OtherDriverInfo);
	}

    public override int Deleteility_Claim_OtherDriverInfo(System.Int32 pk_Otherdriver)
	{
        return mObjIlity_Claim_OtherDriverInfo.Deleteility_Claim_OtherDriverInfo(pk_Otherdriver);
	} 

	public override string ActivateInactivateility_Claim_OtherDriverInfo(string strIDs, int intModifiedBy, bool bIsActive)
	{
		return mObjIlity_Claim_OtherDriverInfo.ActivateInactivateility_Claim_OtherDriverInfo(strIDs, intModifiedBy, bIsActive);
	}

    public override List<RIMS_Base.CLiabilityClaimOtherDriverInfo> GetAL_Claim_OtherDriverInfoByID(System.Decimal lFK_Liability_Claim)
	{
		return mObjIlity_Claim_OtherDriverInfo.GetAL_Claim_OtherDriverInfoByID(lFK_Liability_Claim);
	}

    public override List<RIMS_Base.CLiabilityClaimOtherDriverInfo> Get_Claim_OtherDriverInfoByID(System.Int32 pk_Otherdriver)
	{
        return mObjIlity_Claim_OtherDriverInfo.Get_Claim_OtherDriverInfoByID(pk_Otherdriver);
	}


    
	public override List<RIMS_Base.CLiabilityClaimOtherDriverInfo> GetAll()
	{
		return mObjIlity_Claim_OtherDriverInfo.GetAll();
	}
	#endregion

}

}