#region Includes
using System;
using System.Collections.Generic;
using System.Text;
#endregion

namespace RIMS_Base.Biz
{

    [Serializable]
    public class CPolicy : RIMS_Base.CPolicy
    {
        #region Private Declarations
        RIMS_Base.CPolicy mObjcy;
        #endregion

        #region Constructor
        public CPolicy()
        {
            mObjcy = new RIMS_Base.Dal.CPolicy();
        }
        #endregion

        #region Public Methods
        public override int InsertUpdate_Policy(RIMS_Base.CPolicy Objcy)
        {
            return mObjcy.InsertUpdate_Policy(Objcy);
        }

        public override int Delete_Policy(System.String Policy_Ids)
        {
            return mObjcy.Delete_Policy(Policy_Ids);
        }

        public override string ActivateInactivate_Policy(string strIDs, int intModifiedBy, bool bIsActive)
        {
            return mObjcy.ActivateInactivate_Policy(strIDs, intModifiedBy, bIsActive);
        }

        public override List<RIMS_Base.CPolicy> GetPolicyByID(System.Decimal lPK_Policy_Id)
        {
            return mObjcy.GetPolicyByID(lPK_Policy_Id);
        }

        public override List<RIMS_Base.CPolicy> GetAll()
        {
            return mObjcy.GetAll();
        }

        public override List<RIMS_Base.CPolicy> Get_Search_Data(System.String m_strColumn, System.String m_strCriteria)
        {
            return mObjcy.Get_Search_Data(m_strColumn, m_strCriteria);
        }
        public override List<RIMS_Base.CPolicy> GetAllPolicyType()  
        {
         return mObjcy.GetAllPolicyType();
        }
        public override List<RIMS_Base.CPolicy> GetAllPolicyStatus()  
        {
            return mObjcy.GetAllPolicyStatus();
        }
        public override List<RIMS_Base.CPolicy> GetCovCodeByPolType(System.Decimal pK_PolicyType_Id)
        {
            return mObjcy.GetCovCodeByPolType(pK_PolicyType_Id);
        }
        #endregion

    }

}