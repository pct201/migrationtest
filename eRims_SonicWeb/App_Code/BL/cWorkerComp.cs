#region Includes
using System;
using System.Collections.Generic;
using System.Text;
#endregion

namespace RIMS_Base.Biz
{

    [Serializable]
    public class cWorkerComp : RIMS_Base.cWorkerComp
    {
        #region Private Declarations
        RIMS_Base.cWorkerComp mObjWorkComp;
        #endregion

        #region Constructor
        public cWorkerComp()
        {
            mObjWorkComp = new RIMS_Base.Dal.cWorkerComp();
        }
        #endregion

        #region Public Methods
        public override int InsertUpdate_WorkerComp(RIMS_Base.cWorkerComp Objers_Comp)
        {
            return mObjWorkComp.InsertUpdate_WorkerComp(Objers_Comp);
        }

        public override int Delete_WorkerComp(System.Decimal lPK_Workers_Comp)
        {
            return mObjWorkComp.Delete_WorkerComp(lPK_Workers_Comp);
        }

        public override string ActivateInactivate_WorkerComp(string strIDs, int intModifiedBy, bool bIsActive)
        {
            return mObjWorkComp.ActivateInactivate_WorkerComp(strIDs, intModifiedBy, bIsActive);
        }

        public override List<RIMS_Base.cWorkerComp> GetWorkerCompByID(System.Int32 PK_Workers_Comp)
        {
            return mObjWorkComp.GetWorkerCompByID(PK_Workers_Comp);
        }


        public override List<RIMS_Base.cWorkerComp> GetEmpDataByID(System.Int32 pK_Workers_Comp, System.Int32 pK_Employee_ID, System.Int32 Criatearea)
        {
            return mObjWorkComp.GetEmpDataByID(pK_Workers_Comp, pK_Employee_ID, Criatearea);
        }

        public override List<RIMS_Base.cWorkerComp> GetAll(Boolean blnIsActive)
        {
            return mObjWorkComp.GetAll(blnIsActive);
        }

        public override List<RIMS_Base.cWorkerComp> GetCostCenterByID(System.Int32 pK_Workers_Comp, System.String cost_Center)
        {
            return mObjWorkComp.GetCostCenterByID(pK_Workers_Comp, cost_Center);
        }


      
        #endregion



    }

}