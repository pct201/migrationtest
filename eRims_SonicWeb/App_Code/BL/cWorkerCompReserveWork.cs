#region Includes
using System;
using System.Collections.Generic;
using System.Text;
#endregion

namespace RIMS_Base.Biz
{

    [Serializable]
    public class cWorkerCompReserveWork : RIMS_Base.cWorkerCompReserveWork
    {
        #region Private Declarations
        RIMS_Base.cWorkerCompReserveWork obj_WCompRW;
        #endregion

        #region Constructor
        public cWorkerCompReserveWork()
        {
            obj_WCompRW = new RIMS_Base.Dal.cWorkerCompReserveWork();
        }
        #endregion

        #region Public Methods
        public override int InsertUpdate_RWComp(RIMS_Base.cWorkerCompReserveWork obj_WorkCompRW)
        {
            return obj_WCompRW.InsertUpdate_RWComp(obj_WorkCompRW);
        }

        public override int Delete_RWComp(System.String lPK_Workers_Comp_RW_ID)
        {
            return obj_WCompRW.Delete_RWComp(lPK_Workers_Comp_RW_ID);
        }

        public override string ActivateInactivate_RWComp(string strIDs, int intModifiedBy, bool bIsActive)
        {
            return obj_WCompRW.ActivateInactivate_RWComp(strIDs, intModifiedBy, bIsActive);
        }

        public override List<RIMS_Base.cWorkerCompReserveWork> Geters_Comp_RWByID(System.Decimal lPK_Workers_Comp_RW_ID)
        {
            return obj_WCompRW.Geters_Comp_RWByID(lPK_Workers_Comp_RW_ID);
        }


        public override List<RIMS_Base.cWorkerCompReserveWork> GetAll(Boolean blnIsActive)
        {
            return obj_WCompRW.GetAll(blnIsActive);
        }

        public override List<RIMS_Base.cWorkerCompReserveWork> Workers_Comp_RWRecords(System.Decimal Worker_Comp_ID)
        {
            return obj_WCompRW.Workers_Comp_RWRecords(Worker_Comp_ID);
        }
        public override List<RIMS_Base.cWorkerCompReserveWork> Workers_Comp_RWRecords_OutStand(decimal Worker_Comp_ID)
        {
            return obj_WCompRW.Workers_Comp_RWRecords_OutStand(Worker_Comp_ID);
        }
        // For Payment Details
        public override System.Data.DataSet GetPaymentRecords(System.Decimal Worker_Comp_ID)
        {
            return obj_WCompRW.GetPaymentRecords(Worker_Comp_ID);
        }


        //For Claim info
        public override List<RIMS_Base.cWorkerCompReserveWork> GetClaimInfoByClaimNo(string m_strClaimNo)
        {
            return obj_WCompRW.GetClaimInfoByClaimNo(m_strClaimNo);
        }
        public override System.Data.DataSet GetWCReserveHistoryLabel()
        {
            return obj_WCompRW.GetWCReserveHistoryLabel();
        }

        public override List<RIMS_Base.cWorkerCompReserveWork> GetWCClaimInfoByClaimNo(string m_strClaimNo)
        {
            return obj_WCompRW.GetWCClaimInfoByClaimNo(m_strClaimNo);
        }
        #endregion

    }

}