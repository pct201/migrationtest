#region Includes
using System;
using System.Collections.Generic;
using System.Text;
#endregion

namespace RIMS_Base.Biz
{

    [Serializable]
    public class CCheckWriting : RIMS_Base.CCheckWriting
    {
        #region Private Declarations
        RIMS_Base.CCheckWriting mObjk_Writing;
        #endregion

        #region Constructor
        public CCheckWriting()
        {
            mObjk_Writing = new RIMS_Base.Dal.CCheckWriting();
        }
        #endregion

        #region Public Methods
        public override string GetClaimType(string ClaimNumber)
        {
            return mObjk_Writing.GetClaimType(ClaimNumber);
        }
        public override int InsertUpdate_CheckWriting(RIMS_Base.CCheckWriting Objk_Writing)
        {
            return mObjk_Writing.InsertUpdate_CheckWriting(Objk_Writing);
        }

        public override int Delete_CheckWriting(System.Decimal lpk_check_no)
        {
            return mObjk_Writing.Delete_CheckWriting(lpk_check_no);
        }

        public override string ActivateInactivate_CheckWriting(string strIDs, int intModifiedBy, bool bIsActive)
        {
            return mObjk_Writing.ActivateInactivate_CheckWriting(strIDs, intModifiedBy, bIsActive);
        }

        public override RIMS_Base.CCheckWriting GetCheckWritingByID(System.Decimal lpk_check_no)
        {
            return mObjk_Writing.GetCheckWritingByID(lpk_check_no);
        }

        public override List<RIMS_Base.CCheckWriting> GetAll(Boolean blnIsActive)
        {
            return mObjk_Writing.GetAll(blnIsActive);
        }
        //For Claim info
        public override List<RIMS_Base.CCheckWriting> GetClaimInfoByClaimNo(string m_strClaimNo)
        {
            return mObjk_Writing.GetClaimInfoByClaimNo(m_strClaimNo);
        }
        //For Reserves
        public override List<RIMS_Base.CCheckWriting> GetReserves(string m_strTblName, int m_intTblFk)
        {
            return mObjk_Writing.GetReserves(m_strTblName, m_intTblFk);
        }
        //For Payment Type
        public override List<RIMS_Base.CCheckWriting> GetAllPaymentType()
        {
            return mObjk_Writing.GetAllPaymentType();
        }
        //FOr check Edit Delete Functionality.
        public override int Update_CEDCheckEditDel(RIMS_Base.CCheckWriting Objk_Writing)
        {
            return mObjk_Writing.Update_CEDCheckEditDel(Objk_Writing);
        }

        public override List<RIMS_Base.CCheckWriting> GetWorkerCompClaimInfoByClaimNo(string m_strClaimNo)
        {
            return mObjk_Writing.GetWorkerCompClaimInfoByClaimNo(m_strClaimNo);
        }
        #endregion

    }

}