#region Includes
	using System;
	using System.Collections.Generic;
	using System.Text;
#endregion

namespace RIMS_Base.Biz
{

[Serializable]
public class CLiabilityClaimLossLocation : RIMS_Base.CLiabilityClaimLossLocation
{
	#region Private Declarations
	RIMS_Base.CLiabilityClaimLossLocation mObjIlity_Claim_LossLocation;
	#endregion

	#region Constructor
	public CLiabilityClaimLossLocation()
	{
		mObjIlity_Claim_LossLocation = new RIMS_Base.Dal.CLiabilityClaimLossLocation();
	}
	#endregion

	#region Public Methods
	public override int InsertUpdateility_Claim_LossLocation(RIMS_Base.CLiabilityClaimLossLocation Objility_Claim_LossLocation)
	{
		return mObjIlity_Claim_LossLocation.InsertUpdateility_Claim_LossLocation(Objility_Claim_LossLocation);
	}

	public override int Deleteility_Claim_LossLocation(System.Decimal lFK_Liability_Claim)
	{
		return mObjIlity_Claim_LossLocation.Deleteility_Claim_LossLocation(lFK_Liability_Claim);
	} 

	public override string ActivateInactivateility_Claim_LossLocation(string strIDs, int intModifiedBy, bool bIsActive)
	{
		return mObjIlity_Claim_LossLocation.ActivateInactivateility_Claim_LossLocation(strIDs, intModifiedBy, bIsActive);
	}

    public override List<RIMS_Base.CLiabilityClaimLossLocation> GetAL_Claim_LossLocationByID(System.Decimal lFK_Liability_Claim)
	{
		return mObjIlity_Claim_LossLocation.GetAL_Claim_LossLocationByID(lFK_Liability_Claim);
	}

	public override List<RIMS_Base.CLiabilityClaimLossLocation> GetAll(Boolean blnIsActive)
	{
		return mObjIlity_Claim_LossLocation.GetAll(blnIsActive);
	}
	#endregion

}

}