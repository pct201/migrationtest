#region Includes
	using System;
	using System.Collections.Generic;
	using System.Text;
#endregion

namespace RIMS_Base.Biz
{

[Serializable]
public class CLiabilityClaimCmpVehicleInfo : RIMS_Base.CLiabilityClaimCmpVehicleInfo
{
	#region Private Declarations
	RIMS_Base.CLiabilityClaimCmpVehicleInfo mObjIlity_Claim_CmpVehicleInfo;
	#endregion

	#region Constructor
	public CLiabilityClaimCmpVehicleInfo()
	{
		mObjIlity_Claim_CmpVehicleInfo = new RIMS_Base.Dal.CLiabilityClaimCmpVehicleInfo();
	}
	#endregion

	#region Public Methods
	public override int InsertUpdateility_Claim_CmpVehicleInfo(RIMS_Base.CLiabilityClaimCmpVehicleInfo Objility_Claim_CmpVehicleInfo)
	{
		return mObjIlity_Claim_CmpVehicleInfo.InsertUpdateility_Claim_CmpVehicleInfo(Objility_Claim_CmpVehicleInfo);
	}

	public override int Deleteility_Claim_CmpVehicleInfo(System.Decimal lFK_Liability_Claim)
	{
		return mObjIlity_Claim_CmpVehicleInfo.Deleteility_Claim_CmpVehicleInfo(lFK_Liability_Claim);
	} 

	public override string ActivateInactivateility_Claim_CmpVehicleInfo(string strIDs, int intModifiedBy, bool bIsActive)
	{
		return mObjIlity_Claim_CmpVehicleInfo.ActivateInactivateility_Claim_CmpVehicleInfo(strIDs, intModifiedBy, bIsActive);
	}

    public override List<RIMS_Base.CLiabilityClaimCmpVehicleInfo> GetAL_Claim_CmpVehicleInfoByID(System.Decimal lFK_Liability_Claim)
	{
		return mObjIlity_Claim_CmpVehicleInfo.GetAL_Claim_CmpVehicleInfoByID(lFK_Liability_Claim);
	}

	public override List<RIMS_Base.CLiabilityClaimCmpVehicleInfo> GetAll(Boolean blnIsActive)
	{
		return mObjIlity_Claim_CmpVehicleInfo.GetAll(blnIsActive);
	}
	#endregion

}

}