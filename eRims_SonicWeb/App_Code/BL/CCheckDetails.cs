#region Includes
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Sql;
using System.Data;
#endregion

namespace RIMS_Base.Biz
{

    [Serializable]
    public class CCheckDetails : RIMS_Base.CCheckDetails
    {
        #region Private Declarations
        RIMS_Base.CCheckDetails mObjk_details;
        #endregion

        #region Constructor
        public CCheckDetails()
        {
            mObjk_details = new RIMS_Base.Dal.CCheckDetails();
        }
        #endregion

        #region Public Methods
        public override int InsertUpdate_CheckDetails(RIMS_Base.CCheckDetails Objk_details)
        {
            return mObjk_details.InsertUpdate_CheckDetails(Objk_details);
        }

        public override int Delete_CheckDetails(System.String lpk_check_no)
        {
            return mObjk_details.Delete_CheckDetails(lpk_check_no);
        }

        public override string ActivateInactivate_CheckDetails(string strIDs, int intModifiedBy, bool bIsActive)
        {
            return mObjk_details.ActivateInactivate_CheckDetails(strIDs, intModifiedBy, bIsActive);
        }

        public override RIMS_Base.CCheckDetails GetCheckDetailsByID(System.Decimal lpk_check_no)
        {
            return mObjk_details.GetCheckDetailsByID(lpk_check_no);
        }

        public override List<RIMS_Base.CCheckDetails> GetAll()
        {
            return mObjk_details.GetAll();
        }
        //Get Data After Enter Payment.
        public override List<RIMS_Base.CCheckDetails> GetCDAEP(System.Decimal pk_check_no)
        {
            return mObjk_details.GetCDAEP(pk_check_no);
        }
        //Get Data when Edit Delete
        public override List<RIMS_Base.CCheckDetails> GetChkDetailEditDel(System.Int64 chkNo)
        {
            return mObjk_details.GetChkDetailEditDel(chkNo);
        }
        //Get Check For Make them print
        public override List<RIMS_Base.CCheckDetails> GetChecksForPrint()
        {
            return mObjk_details.GetChecksForPrint();
        }
        //Make Check Status to Printed Means 1
        public override int Chek_MakePrinted(System.String lpk_check_no, System.String m_strUserName)
        {
            return mObjk_details.Chek_MakePrinted(lpk_check_no, m_strUserName);
        }
        //Make Check Status to Re-Printed Means 2
        public override int Chek_MakeRePrinted(System.String lpk_check_no, System.String m_strUserName)
        {
            return mObjk_details.Chek_MakeRePrinted(lpk_check_no, m_strUserName);
        }
        //Make Check Status to Stop Means 3
        public override int Chek_MakeStop(System.String lpk_check_no, System.String m_strUserName)
        {
            return mObjk_details.Chek_MakeStop(lpk_check_no, m_strUserName);
        }
        //Make Check Status to  Void Means 4
        public override int Chek_MakeVoid(System.String lpk_check_no, System.String m_strUserName)
        {
            return mObjk_details.Chek_MakeVoid(lpk_check_no, m_strUserName);
        }
        //Get check which are printed
        public override List<RIMS_Base.CCheckDetails> GetPostCheckRegister(System.Int64 m_intType)
        {
            return mObjk_details.GetPostCheckRegister(m_intType);
        }
        //Here if m_intType is 2 means Post Check with Given Date Range.
        public override List<RIMS_Base.CCheckDetails> GetPostCheckRegisterForDateLimit(System.Int64 m_intType, System.DateTime m_DtStart, System.DateTime m_DtEnd)
        {
            return mObjk_details.GetPostCheckRegisterForDateLimit(m_intType, m_DtStart, m_DtEnd);
        }
        //Get Stop Voided Check for Display
        public override List<RIMS_Base.CCheckDetails> GetStoppedVoidedCheck(System.Int64 m_intType)
        {
            return mObjk_details.GetStoppedVoidedCheck(m_intType);
        }
        //Get Non-Stop Non-Voiud Check to Makle then Stop/Void
        public override List<RIMS_Base.CCheckDetails> GetStoppedVoidedCheckForDateLimit(System.Int64 m_intType, System.DateTime m_DtStart, System.DateTime m_DtEnd)
        {
            return mObjk_details.GetStoppedVoidedCheckForDateLimit(m_intType, m_DtStart, m_DtEnd);
        }
        //Get Search Check Result.
        public override DataSet GetCheckDetailsForSearch(System.String m_strClaimType1, System.String m_strClaimType2, System.String m_strClaimType3, System.String m_strClaimType4, System.String m_strClaimType5, System.String m_strClaimNo, System.String m_strOpenFrom, System.String m_strOpenTo, System.String m_strCloseFrom, System.String m_strCloseTo, System.String m_strCheckNo)
        {
            return mObjk_details.GetCheckDetailsForSearch(m_strClaimType1, m_strClaimType2, m_strClaimType3, m_strClaimType4, m_strClaimType5, m_strClaimNo, m_strOpenFrom, m_strOpenTo, m_strCloseFrom, m_strCloseTo, m_strCheckNo);
        }
        public override DataSet GetCheckDetailsForSearch1(System.String m_strClaimType1, System.String m_strClaimType2, System.String m_strClaimType3, System.String m_strClaimType4, System.String m_strClaimType5, System.String m_strClaimNo, System.String m_strOpenFrom, System.String m_strOpenTo, System.String m_strCloseFrom, System.String m_strCloseTo, System.String m_strCheckNo)
        {
            return mObjk_details.GetCheckDetailsForSearch1(m_strClaimType1, m_strClaimType2, m_strClaimType3, m_strClaimType4, m_strClaimType5, m_strClaimNo, m_strOpenFrom, m_strOpenTo, m_strCloseFrom, m_strCloseTo, m_strCheckNo);
        }
        public override DataSet GetCheckDetailsForSearch2(System.String m_strClaimType1, System.String m_strClaimType2, System.String m_strClaimType3, System.String m_strClaimType4, System.String m_strClaimType5, System.String m_strClaimNo, System.String m_strOpenFrom, System.String m_strOpenTo, System.String m_strCloseFrom, System.String m_strCloseTo, System.String m_strCheckNo)
        {
            return mObjk_details.GetCheckDetailsForSearch2(m_strClaimType1, m_strClaimType2, m_strClaimType3, m_strClaimType4, m_strClaimType5, m_strClaimNo, m_strOpenFrom, m_strOpenTo, m_strCloseFrom, m_strCloseTo, m_strCheckNo);
        }
        public override DataSet GetCheckDetailsForSearch3(System.String m_strClaimType1, System.String m_strClaimType2, System.String m_strClaimType3, System.String m_strClaimType4, System.String m_strClaimType5, System.String m_strClaimNo, System.String m_strOpenFrom, System.String m_strOpenTo, System.String m_strCloseFrom, System.String m_strCloseTo, System.String m_strCheckNo)
        {
            return mObjk_details.GetCheckDetailsForSearch3(m_strClaimType1, m_strClaimType2, m_strClaimType3, m_strClaimType4, m_strClaimType5, m_strClaimNo, m_strOpenFrom, m_strOpenTo, m_strCloseFrom, m_strCloseTo, m_strCheckNo);
        }
        public override DataSet GetCheckDetailsForSearchByChk(string m_strCheckNo)
        {
            return mObjk_details.GetCheckDetailsForSearchByChk(m_strCheckNo);
        }
        //Generate PDF
        public override DataSet GetDataForPDF(System.String m_strChkNo)
        {
            return mObjk_details.GetDataForPDF(m_strChkNo);
        }
        #endregion

    }

}