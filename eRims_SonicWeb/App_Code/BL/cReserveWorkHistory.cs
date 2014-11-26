#region Includes
using System;
using System.Collections.Generic;
using System.Text;
#endregion

namespace RIMS_Base.Biz
{

    [Serializable]
    public class cReserveWorkHistory : RIMS_Base.cReserveWorkHistory
    {
        #region Private Declarations
        RIMS_Base.cReserveWorkHistory mObjRWHistory;
        #endregion

        #region Constructor
        public cReserveWorkHistory()
        {
            mObjRWHistory = new RIMS_Base.Dal.cReserveWorkHistory();
        }
        #endregion

        #region Public Methods
        public override int InsertUpdate_History(RIMS_Base.cReserveWorkHistory Objistory)
        {
            return mObjRWHistory.InsertUpdate_History(Objistory);
        }

        public override int Delete_History(System.Decimal lPK_RW_History_ID)
        {
            return mObjRWHistory.Delete_History(lPK_RW_History_ID);
        }

        public override string ActivateInactivate_History(string strIDs, int intModifiedBy, bool bIsActive)
        {
            return mObjRWHistory.ActivateInactivate_History(strIDs, intModifiedBy, bIsActive);
        }

        public override RIMS_Base.cReserveWorkHistory GetistoryByID(System.Decimal lPK_RW_History_ID)
        {
            return mObjRWHistory.GetistoryByID(lPK_RW_History_ID);
        }

        public override List<RIMS_Base.cReserveWorkHistory> GetAll(Boolean blnIsActive)
        {
            return mObjRWHistory.GetAll(blnIsActive);
        }
        #endregion

    }

}