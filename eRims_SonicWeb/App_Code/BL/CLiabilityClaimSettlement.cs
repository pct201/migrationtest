#region Includes
	using System;
	using System.Collections.Generic;
	using System.Text;
#endregion

namespace RIMS_Base.Biz
{

[Serializable]
public class CLiabilityClaimSettlement : RIMS_Base.CLiabilityClaimSettlement
{
	#region Private Declarations
	RIMS_Base.CLiabilityClaimSettlement mObjIlity_Claim_Settlement;
	#endregion

	#region Constructor
	public CLiabilityClaimSettlement()
	{
		mObjIlity_Claim_Settlement = new RIMS_Base.Dal.CLiabilityClaimSettlement();
	}
	#endregion

	#region Public Methods
	public override int InsertUpdateility_Claim_Settlement(RIMS_Base.CLiabilityClaimSettlement Objility_Claim_Settlement)
	{
		return mObjIlity_Claim_Settlement.InsertUpdateility_Claim_Settlement(Objility_Claim_Settlement);
	}

	public override int Deleteility_Claim_Settlement(System.Decimal lFK_Liability_Claim)
	{
		return mObjIlity_Claim_Settlement.Deleteility_Claim_Settlement(lFK_Liability_Claim);
	} 

	public override string ActivateInactivateility_Claim_Settlement(string strIDs, int intModifiedBy, bool bIsActive)
	{
		return mObjIlity_Claim_Settlement.ActivateInactivateility_Claim_Settlement(strIDs, intModifiedBy, bIsActive);
	} 

	public override List<RIMS_Base.CLiabilityClaimSettlement> GetGL_Claim_SettlementByID(System.Decimal lFK_Liability_Claim)
	{
		return mObjIlity_Claim_Settlement.GetGL_Claim_SettlementByID(lFK_Liability_Claim);
	}

	public override List<RIMS_Base.CLiabilityClaimSettlement> GetAll(Boolean blnIsActive)
	{
		return mObjIlity_Claim_Settlement.GetAll(blnIsActive);
	}
	#endregion

}

}