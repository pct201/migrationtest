#region Includes
using System;
using System.Collections.Generic;
using System.Text;
#endregion

namespace RIMS_Base.Biz
{

    [Serializable]
    public class CLiabilityClaim : RIMS_Base.CLiabilityClaim
    {
        #region Private Declarations
        RIMS_Base.CLiabilityClaim ObjLiability_Claim;
        #endregion

        #region Constructor
        public CLiabilityClaim()
        {
            ObjLiability_Claim = new RIMS_Base.Dal.CLiabilityClaim();
        }
        #endregion

        #region Public Methods
        public override int InsertUpdate_Claim(RIMS_Base.CLiabilityClaim ObjLia_Claim)
        {
            return ObjLiability_Claim.InsertUpdate_Claim(ObjLia_Claim);
        }

        public override int Delete_Claim(System.Int32 lPK_Liability_Claim)
        {
            return ObjLiability_Claim.Delete_Claim(lPK_Liability_Claim);
        }

        public override string ActivateInactivate_Claim(string strIDs, int intModifiedBy, bool bIsActive)
        {
            return ObjLiability_Claim.ActivateInactivate_Claim(strIDs, intModifiedBy, bIsActive);
        }

        public override List<RIMS_Base.CLiabilityClaim> Getility_ClaimByID(System.Int32 lPK_Liability_Claim)
        {
            return ObjLiability_Claim.Getility_ClaimByID(lPK_Liability_Claim);
        }

        public override List<RIMS_Base.CLiabilityClaim> GetAll(Boolean blnIsActive)
        {
            return ObjLiability_Claim.GetAll(blnIsActive);
        }


        public override List<RIMS_Base.CLiabilityClaim> Get_Property_ByID(System.Int32 fK_Liability_Claim, System.Decimal pK_Property_ID)
        {
            return ObjLiability_Claim.Get_Property_ByID(fK_Liability_Claim, pK_Property_ID);
        }


        public override List<RIMS_Base.CLiabilityClaim> GetLiabilityEmp_Data_ByID(System.Int32 pK_Liability_Claim, System.Int32 pK_Employee_ID, System.Int32 Criatearea)
        {
            return ObjLiability_Claim.GetLiabilityEmp_Data_ByID(pK_Liability_Claim, pK_Employee_ID, Criatearea);
        }

        public override List<RIMS_Base.CLiabilityClaim> GetLiability_CostCenterByID(System.Int32 pK_Liability_Claim, System.String cost_Center)
        {
            return ObjLiability_Claim.GetLiability_CostCenterByID(pK_Liability_Claim, cost_Center);
        }


        public override List<RIMS_Base.CLiabilityClaim> GetLiability_CliamantByID(System.Int32 pK_Liability_Claim, System.Decimal pK_Claimant_Id)
        {
            return ObjLiability_Claim.GetLiability_CliamantByID(pK_Liability_Claim, pK_Claimant_Id);
        }

        public override System.Data.DataSet GetLiabilityLabel()
        {
            return ObjLiability_Claim.GetLiabilityLabel();
        }
        #endregion

    }

}