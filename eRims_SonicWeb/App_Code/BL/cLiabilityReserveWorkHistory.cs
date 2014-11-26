#region Includes
using System;
using System.Collections.Generic;
using System.Text;
#endregion

namespace RIMS_Base.Biz
{

    [Serializable]
    public class cLiabilityReserveWorkHistory : RIMS_Base.cLiabilityReserveWorkHistory
    {
        #region Private Declarations
        RIMS_Base.cLiabilityReserveWorkHistory obj_WCompRW;
        #endregion

        #region Constructor
        public cLiabilityReserveWorkHistory()
        {
            obj_WCompRW = new RIMS_Base.Dal.cLiabilityReserveWorkHistory();
        }
        #endregion

        #region Public Methods
        public override int InsertUpdate_RWComp(RIMS_Base.cLiabilityReserveWorkHistory obj_WorkCompRW)
        {
            return obj_WCompRW.InsertUpdate_RWComp(obj_WorkCompRW);
        }

        public override int Delete_RWComp(System.String lPK_Liability_Claim_RW_ID)
        {
            return obj_WCompRW.Delete_RWComp(lPK_Liability_Claim_RW_ID);
        }

        public override string ActivateInactivate_RWComp(string strIDs, int intModifiedBy, bool bIsActive)
        {
            return obj_WCompRW.ActivateInactivate_RWComp(strIDs, intModifiedBy, bIsActive);
        }

        public override List<RIMS_Base.cLiabilityReserveWorkHistory> Geters_Comp_RWByID(System.Decimal lPK_Liability_Claim_RW_ID)
        {
            return obj_WCompRW.Geters_Comp_RWByID(lPK_Liability_Claim_RW_ID);
        }


        public override List<RIMS_Base.cLiabilityReserveWorkHistory> GetAll(Boolean blnIsActive)
        {
            return obj_WCompRW.GetAll(blnIsActive);
        }

        public override List<RIMS_Base.cLiabilityReserveWorkHistory> Workers_Comp_RWRecords(System.Decimal Liability_Claim_RW_ID)
        {
            return obj_WCompRW.Workers_Comp_RWRecords(Liability_Claim_RW_ID);
        }
        public override List<RIMS_Base.cLiabilityReserveWorkHistory> Workers_Comp_RWRecords_OutStand(decimal Liability_Claim_RW_ID)
        {
            return obj_WCompRW.Workers_Comp_RWRecords_OutStand(Liability_Claim_RW_ID);
        }

        // For Payment Details
        public override System.Data.DataSet GetPaymentRecords(System.Decimal Liability_Claim_RW_ID)
        {
            return obj_WCompRW.GetPaymentRecords(Liability_Claim_RW_ID);
        }


        //For Claim info
        public override List<RIMS_Base.cLiabilityReserveWorkHistory> GetClaimInfoByClaimNo(string m_strClaimNo)
        {
            return obj_WCompRW.GetClaimInfoByClaimNo(m_strClaimNo);
        }
        public override System.Data.DataSet GetLiabilityReserveLabel()
        {
            return obj_WCompRW.GetLiabilityReserveLabel();
        }

        #endregion

    }

}