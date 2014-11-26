#region Includes
	using System;
	using System.Collections.Generic;
	using System.Text;
#endregion

namespace RIMS_Base.Biz
{

[Serializable]
public class CLiabilityClaimWitness : RIMS_Base.CLiabilityClaimWitness
{
	#region Private Declarations
	RIMS_Base.CLiabilityClaimWitness mObjIlity_Claim_Witness;
	#endregion

	#region Constructor
	public CLiabilityClaimWitness()
	{
		mObjIlity_Claim_Witness = new RIMS_Base.Dal.CLiabilityClaimWitness();
	}
	#endregion

	#region Public Methods
	public override int InsertUpdateility_Claim_Witness(RIMS_Base.CLiabilityClaimWitness Objility_Claim_Witness)
	{
		return mObjIlity_Claim_Witness.InsertUpdateility_Claim_Witness(Objility_Claim_Witness);
	}

    public override int Delete_Claim_Witness(System.Int32 pk_Witness)
	{
        return mObjIlity_Claim_Witness.Delete_Claim_Witness(pk_Witness);
	} 

	public override string ActivateInactivateility_Claim_Witness(string strIDs, int intModifiedBy, bool bIsActive)
	{
		return mObjIlity_Claim_Witness.ActivateInactivateility_Claim_Witness(strIDs, intModifiedBy, bIsActive);
	}

    public override List<RIMS_Base.CLiabilityClaimWitness> GetAL_Claim_WitnessByID(System.Decimal lFK_Liability_Claim)
	{
		return mObjIlity_Claim_Witness.GetAL_Claim_WitnessByID(lFK_Liability_Claim);
	}

    public override List<RIMS_Base.CLiabilityClaimWitness> Get_Witness_ByID(System.Int32 pk_Witness)
	{
        return mObjIlity_Claim_Witness.Get_Witness_ByID(pk_Witness);
	}
     
	public override List<RIMS_Base.CLiabilityClaimWitness> GetAll()
	{
		return mObjIlity_Claim_Witness.GetAll();
	}
	#endregion

}

}