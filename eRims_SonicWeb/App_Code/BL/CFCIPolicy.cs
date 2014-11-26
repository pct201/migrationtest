#region Includes
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
#endregion

namespace RIMS_Base.Biz
{

    [Serializable]
    public class CFCIPolicy : RIMS_Base.CFCIPolicy
    {
        #region Private Declarations
        RIMS_Base.CFCIPolicy mObjcy;
        #endregion

        #region Constructor
        public CFCIPolicy()
        {
            mObjcy = new RIMS_Base.Dal.CFCIPolicy();
        }
        #endregion

        #region Public Methods
        public override int Policy_InsertUpdate(RIMS_Base.CFCIPolicy Objcy)
        {
            return mObjcy.Policy_InsertUpdate(Objcy);
        }

        public override int Policy_Delete(System.Decimal lPK_Policy_Id)
        {
            return mObjcy.Policy_Delete(lPK_Policy_Id);
        }

        public override DataSet Policy_GetByID(System.Decimal lPK_Policy_Id)
        {
            return mObjcy.Policy_GetByID(lPK_Policy_Id);
        }

        public override DataSet GetAll()
        {
            return mObjcy.GetAll();
        }
        public override int DeletePolicy(decimal PK_Policy_ID)
        {
            return mObjcy.DeletePolicy(PK_Policy_ID);
        }
        public override DataSet GetPolicySearch(decimal FK_Policy_Type, string Carrier, int Policy_Year, Decimal pK_Security_Id, Decimal ProgramID, Decimal LocationID)
        {
            return mObjcy.GetPolicySearch(FK_Policy_Type, Carrier, Policy_Year, pK_Security_Id,ProgramID,LocationID);
        }
        public override DataSet GetPolicyLayer()
        {
            return mObjcy.GetPolicyLayer();
        }

        public override DataSet GetPolicy_Popup_Search(System.String m_strColumn, System.String m_strCriteria)
        {
            return mObjcy.GetPolicy_Popup_Search(m_strColumn, m_strCriteria);
        }

        public override int PolicyDuplicateCheck(RIMS_Base.CFCIPolicy Objcy)
        {
            return mObjcy.PolicyDuplicateCheck(Objcy);
        }

        public override int CheckSharedPercentagePolicy(RIMS_Base.CFCIPolicy Objcy)
        {
            return mObjcy.CheckSharedPercentagePolicy(Objcy);
        }
        #endregion

    }

}