#region Includes
using System;
using System.Collections.Generic;
using System.Text;
#endregion

namespace RIMS_Base.Biz
{

    [Serializable]
    public class CProvider : RIMS_Base.CProvider
    {
        #region Private Declarations
        RIMS_Base.CProvider mObjider;
        #endregion

        #region Constructor
        public CProvider()
        {
            mObjider = new RIMS_Base.Dal.CProvider();
        }
        #endregion

        #region Public Methods
        public override int Provider_InsertUpdate(RIMS_Base.CProvider Objider)
        {
            return mObjider.Provider_InsertUpdate(Objider);
        }

        public override int Provider_Delete(System.String lPK_Provider_ID)
        {
            return mObjider.Provider_Delete(lPK_Provider_ID);
        }

        public override string ActivateInactivateider(string strIDs, int intModifiedBy, bool bIsActive)
        {
            return mObjider.ActivateInactivateider(strIDs, intModifiedBy, bIsActive);
        }

        public override List<RIMS_Base.CProvider> Provider_GetByID(System.Decimal lPK_Provider_ID)
        {
            return mObjider.Provider_GetByID(lPK_Provider_ID);
        }
        public override List<RIMS_Base.CProvider> Get_Search_Data(string m_strColumn, string m_strCriteria)
        {
            return mObjider.Get_Search_Data(m_strColumn, m_strCriteria);
        }
        public override List<RIMS_Base.CProvider> GetAll()
        {
            return mObjider.GetAll();
        }
        #endregion

    }

}