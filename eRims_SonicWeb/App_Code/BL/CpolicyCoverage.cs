using System;
using System.Collections.Generic;
using System.Text;

namespace RIMS_Base.Biz
{

    [Serializable]
    public class CPolicyCoverage : RIMS_Base.CPolicyCoverage 
    {
        #region Private Declarations
        RIMS_Base.CPolicyCoverage mObjcy_Coverage;
        #endregion

        #region Constructor
        public CPolicyCoverage()
        {
            mObjcy_Coverage = new RIMS_Base.Dal.CPolicyCoverage();
        }
        #endregion

        #region Public Methods
        public override int InsertUpdatePolicy_Coverage(RIMS_Base.CPolicyCoverage Objcy_Coverage)
        {
            return mObjcy_Coverage.InsertUpdatePolicy_Coverage(Objcy_Coverage);
        }

        public override int DeletePolicy_Coverage(System.Decimal lPK_Policy_Coverage_Id)
        {
            return mObjcy_Coverage.DeletePolicy_Coverage(lPK_Policy_Coverage_Id);
        }

        public override List<RIMS_Base.CPolicyCoverage> GetPolicy_CoverageByID(System.Decimal lPK_Policy_Coverage_Id)
        {
            return mObjcy_Coverage.GetPolicy_CoverageByID(lPK_Policy_Coverage_Id);
        }

        public override List<RIMS_Base.CPolicyCoverage> GetAll()
        {
            return mObjcy_Coverage.GetAll();
        }
        public override List<RIMS_Base.CPolicyCoverage> Get_Search_Data(System.String m_strColumn, System.String m_strCriteria)
        {
            return mObjcy_Coverage.Get_Search_Data(m_strColumn, m_strCriteria);
        }
        public override List<RIMS_Base.CPolicyCoverage> GetPolicyFeatures()
        {
            return mObjcy_Coverage.GetPolicyFeatures();
        }
        #endregion

    }

}