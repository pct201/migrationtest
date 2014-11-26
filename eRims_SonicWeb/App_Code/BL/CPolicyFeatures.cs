#region Includes
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
#endregion

namespace RIMS_Base.Biz
{

    [Serializable]
    public class CPolicy_Features : RIMS_Base.CPolicy_Features
    {
        #region Private Declarations
        RIMS_Base.CPolicy_Features mObjcy_Features;
        #endregion

        #region Constructor
        public CPolicy_Features()
        {
            mObjcy_Features = new RIMS_Base.Dal.CPolicy_Features();
        }
        #endregion

        #region Public Methods
        public override int PolicyFeatures_InsertUpdate(RIMS_Base.CPolicy_Features Objcy_Features)
        {
            return mObjcy_Features.PolicyFeatures_InsertUpdate(Objcy_Features);
        }

        public override int PolicyFeatures_Delete(System.Decimal lPK_Policy_Features)
        {
            return mObjcy_Features.PolicyFeatures_Delete(lPK_Policy_Features);
        }


        public override DataSet PolicyFeatures_GetByID(System.Decimal lPK_Policy_Features, System.Decimal m_dPolicyID)
        {
            return mObjcy_Features.PolicyFeatures_GetByID(lPK_Policy_Features,m_dPolicyID);
        }

        public override DataSet GetAll( )
        {
            return mObjcy_Features.GetAll();
        }
        public override DataSet PolicyFeatures_ByPolicyID(System.Decimal m_dPolicyID)
        {
            return mObjcy_Features.PolicyFeatures_ByPolicyID(m_dPolicyID);
        }
        #endregion

    }

}