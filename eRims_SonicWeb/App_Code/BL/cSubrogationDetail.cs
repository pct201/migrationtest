#region Includes
using System;
using System.Collections.Generic;
using System.Text;
#endregion

namespace RIMS_Base.Biz
{

    [Serializable]
    public class cSubrogationDetail : RIMS_Base.cSubrogationDetail
    {
        #region Private Declarations
        RIMS_Base.cSubrogationDetail mObjSubrogationDetail;
        #endregion

        #region Constructor
        public cSubrogationDetail()
        {
            mObjSubrogationDetail = new RIMS_Base.Dal.cSubrogationDetail();
        }
        #endregion

        #region Public Methods
        public override int InsertUpdateSubrogationDetail(RIMS_Base.cSubrogationDetail ObjSubrogationDetail)
        {
            return mObjSubrogationDetail.InsertUpdateSubrogationDetail(ObjSubrogationDetail);
        }

        public override int DeleteSubrogationDetail(System.Int32 lPK_Subrogation_detail)
        {
            return mObjSubrogationDetail.DeleteSubrogationDetail(lPK_Subrogation_detail);
        }

        public override string ActivateInactivateSubrogationDetail(string strIDs, int intModifiedBy, bool bIsActive)
        {
            return mObjSubrogationDetail.ActivateInactivateSubrogationDetail(strIDs, intModifiedBy, bIsActive);
        }

        public override List<RIMS_Base.cSubrogationDetail> GetSubrogationDetailByID(System.Decimal Fk_Table_Name, System.String Table_Name)
        {
            return mObjSubrogationDetail.GetSubrogationDetailByID(Fk_Table_Name, Table_Name);
        }

        public override List<RIMS_Base.cSubrogationDetail> GetAll(Boolean blnIsActive)
        {
            return mObjSubrogationDetail.GetAll(blnIsActive);
        }
        public override System.Data.DataSet GetSubrogationDetailLabel()
        {
            return mObjSubrogationDetail.GetSubrogationDetailLabel();
        }
        #endregion

    }

}