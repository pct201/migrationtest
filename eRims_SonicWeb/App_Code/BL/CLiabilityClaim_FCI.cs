using System;
using System.Collections.Generic;
using System.Text;

namespace RIMS_Base.Biz
{
    [Serializable]
    public class CLiabilityClaim_FCI : RIMS_Base.CLiabilityClaim_FCI
    {
        #region Private Declarations
        RIMS_Base.CLiabilityClaim_FCI mObjIlity_Claim;
        #endregion

        #region Constructor
        public CLiabilityClaim_FCI()
        {
            mObjIlity_Claim = new RIMS_Base.Dal.CLiabilityClaim_FCI();
        }
        #endregion

        #region Public Methods

        public override int InsertUpdateility_Claim(RIMS_Base.CLiabilityClaim_FCI Objility_Claim)
        {
            return mObjIlity_Claim.InsertUpdateility_Claim(Objility_Claim);
        }
        public override int InsertUpdate_PropertyClaim(RIMS_Base.CLiabilityClaim_FCI Objility_Claim)
        {
            return mObjIlity_Claim.InsertUpdate_PropertyClaim(Objility_Claim);
        }
        public override int Deleteility_Claim(System.Int32 lPK_Liability_Claim)
        {
            return mObjIlity_Claim.Deleteility_Claim(lPK_Liability_Claim);
        }
        public override string ActivateInactivateility_Claim(string strIDs, int intModifiedBy, bool bIsActive)
        {
            return mObjIlity_Claim.ActivateInactivateility_Claim(strIDs, intModifiedBy, bIsActive);
        }

        public override List<RIMS_Base.CLiabilityClaim_FCI> GetAll(Boolean blnIsActive)
        {
            return mObjIlity_Claim.GetAll(blnIsActive);
        }
        public override List<RIMS_Base.CLiabilityClaim_FCI> GetAL_ClaimByID(System.Int32 lPK_Liability_Claim)
        {
            return mObjIlity_Claim.GetAL_ClaimByID(lPK_Liability_Claim);
        }
        public override List<RIMS_Base.CLiabilityClaim_FCI> GetAL_ClaimByClaimNo(String strClaimNo)
        {
            return mObjIlity_Claim.GetAL_ClaimByClaimNo(strClaimNo);
        }

        public override List<RIMS_Base.CLiabilityClaim_FCI> GetEmployee_ByID(System.Int32 pK_Liability_Claim, System.Decimal pK_Employee_Id)
        {
            return mObjIlity_Claim.GetEmployee_ByID(pK_Liability_Claim, pK_Employee_Id);
        }
        public override List<RIMS_Base.CLiabilityClaim_FCI> GetCliamant_ByID(System.Int32 pK_Liability_Claim, System.Decimal pK_Claimant_Id)
        {
            return mObjIlity_Claim.GetCliamant_ByID(pK_Liability_Claim, pK_Claimant_Id);
        }
        public override List<RIMS_Base.CLiabilityClaim_FCI> GetDriver_ByID(System.Int32 pK_Liability_Claim, System.Decimal pK_Property_Drivers)
        {
            return mObjIlity_Claim.GetDriver_ByID(pK_Liability_Claim, pK_Property_Drivers);
        }
        public override List<RIMS_Base.CLiabilityClaim_FCI> GetCarrier_ByID(System.Int32 pK_Liability_Claim, System.Decimal pK_Policy_Id)
        {
            return mObjIlity_Claim.GetCarrier_ByID(pK_Liability_Claim, pK_Policy_Id);
        }



        #endregion
    }
}