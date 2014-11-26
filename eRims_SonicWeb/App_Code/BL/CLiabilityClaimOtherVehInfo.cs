#region Includes
	using System;
	using System.Collections.Generic;
	using System.Text;
#endregion

namespace RIMS_Base.Biz
{

[Serializable]
public class CLiabilityClaimOtherVehInfo : RIMS_Base.CLiabilityClaimOtherVehInfo
{
	#region Private Declarations
	RIMS_Base.CLiabilityClaimOtherVehInfo mObjIlity_Claim_OtherVehInfo;
	#endregion

	#region Constructor
	public CLiabilityClaimOtherVehInfo()
	{
		mObjIlity_Claim_OtherVehInfo = new RIMS_Base.Dal.CLiabilityClaimOtherVehInfo();
	}
	#endregion

	#region Public Methods
	public override int InsertUpdateility_Claim_OtherVehInfo(RIMS_Base.CLiabilityClaimOtherVehInfo Objility_Claim_OtherVehInfo)
	{
		return mObjIlity_Claim_OtherVehInfo.InsertUpdateility_Claim_OtherVehInfo(Objility_Claim_OtherVehInfo);
	}

    public override int Delete_Claim_OtherVehInfo(System.Int32 pk_OtherVehicle)
	{
        return mObjIlity_Claim_OtherVehInfo.Delete_Claim_OtherVehInfo(pk_OtherVehicle);
	} 

	public override string ActivateInactivateility_Claim_OtherVehInfo(string strIDs, int intModifiedBy, bool bIsActive)
	{
		return mObjIlity_Claim_OtherVehInfo.ActivateInactivateility_Claim_OtherVehInfo(strIDs, intModifiedBy, bIsActive);
	}

    public override List<RIMS_Base.CLiabilityClaimOtherVehInfo> GetAL_Claim_OtherVehInfoByID(System.Decimal lFK_Liability_Claim)
	{
		return mObjIlity_Claim_OtherVehInfo.GetAL_Claim_OtherVehInfoByID(lFK_Liability_Claim);
	}


    public override List<RIMS_Base.CLiabilityClaimOtherVehInfo>  Get_Claim_OtherVehInfoByID(System.Int32 pk_OtherVehicle)
    {
        return mObjIlity_Claim_OtherVehInfo.Get_Claim_OtherVehInfoByID(pk_OtherVehicle);
    }
	public override List<RIMS_Base.CLiabilityClaimOtherVehInfo> GetAll()
	{
		return mObjIlity_Claim_OtherVehInfo.GetAll();
	}
	#endregion

}

}