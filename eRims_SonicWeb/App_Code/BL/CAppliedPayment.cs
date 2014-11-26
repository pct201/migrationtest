#region Includes
using System;
using System.Collections.Generic;
using System.Text;
#endregion

namespace RIMS_Base.Biz
{

    [Serializable]
    public class CAppliedPayment : RIMS_Base.CAppliedPayment
    {
        #region Private Declarations
        RIMS_Base.CAppliedPayment mObjIED_PAYMENTS;
        #endregion

        #region Constructor
        public CAppliedPayment()
        {
            mObjIED_PAYMENTS = new RIMS_Base.Dal.CAppliedPayment();
        }
        #endregion

        #region Public Methods
        public override int InsertUpdateApp_Payment(RIMS_Base.CAppliedPayment ObjIED_PAYMENTS)
        {
            return mObjIED_PAYMENTS.InsertUpdateApp_Payment(ObjIED_PAYMENTS);
        }

        public override int DeleteApp_Payment(System.Decimal lpk_applied_id)
        {
            return mObjIED_PAYMENTS.DeleteApp_Payment(lpk_applied_id);
        }

        public override string ActivateInactivateApp_Payment(string strIDs, int intModifiedBy, bool bIsActive)
        {
            return mObjIED_PAYMENTS.ActivateInactivateApp_Payment(strIDs, intModifiedBy, bIsActive);
        }

        public override RIMS_Base.CAppliedPayment GetApp_PaymentByID(System.Decimal lpk_applied_id)
        {
            return mObjIED_PAYMENTS.GetApp_PaymentByID(lpk_applied_id);
        }

        public override List<RIMS_Base.CAppliedPayment> GetAll()
        {
            return mObjIED_PAYMENTS.GetAll();
        }
        #endregion

    }

}