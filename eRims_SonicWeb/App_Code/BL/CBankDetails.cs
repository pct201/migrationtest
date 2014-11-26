#region Includes
using System;
using System.Collections.Generic;
using System.Text;
#endregion

namespace RIMS_Base.Biz
{

    [Serializable]
    public class CBankDetails : RIMS_Base.CBankDetails
    {
        #region Private Declarations
        RIMS_Base.CBankDetails mObj_Details;
        #endregion

        #region Constructor
        public CBankDetails()
        {
            mObj_Details = new RIMS_Base.Dal.CBankDetails();
        }
        #endregion

        #region Public Methods
        public override int InsertUpdate_Details(RIMS_Base.CBankDetails Obj_Details)
        {
            return mObj_Details.InsertUpdate_Details(Obj_Details);
        }

        public override int Delete_Details(System.String lPK_Bank_Details_ID)
        {
            return mObj_Details.Delete_Details(lPK_Bank_Details_ID);
        }

        public override string ActivateInactivate_Details(string strIDs, int intModifiedBy, bool bIsActive)
        {
            return mObj_Details.ActivateInactivate_Details(strIDs, intModifiedBy, bIsActive);
        }

        public override List<RIMS_Base.CBankDetails> Get_DetailsByID(System.Decimal lPK_Bank_Details_ID)
        {
            return mObj_Details.Get_DetailsByID(lPK_Bank_Details_ID);
        }

        public override List<RIMS_Base.CBankDetails> GetAll()
        {
            return mObj_Details.GetAll();
        }
        public override List<RIMS_Base.CBankDetails> Get_Search_Data(System.String m_strColumn, System.String m_strCriteria)
        {
            return mObj_Details.Get_Search_Data(m_strColumn, m_strCriteria);
        }
        #endregion

    }

}