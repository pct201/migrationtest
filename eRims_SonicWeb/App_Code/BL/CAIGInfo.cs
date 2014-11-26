#region Includes
using System;
using System.Collections.Generic;
using System.Text;
#endregion

namespace RIMS_Base.Biz
{

    [Serializable]
    public class CAIGInfo : RIMS_Base.CAIGInfo
    {
        #region Private Declarations
        RIMS_Base.CAIGInfo mObjInfo;
        #endregion

        #region Constructor
        public CAIGInfo()
        {
            mObjInfo = new RIMS_Base.Dal.CAIGInfo();
        }
        #endregion

        #region Public Methods
        public override int AIGInfo_InsertUpdate(RIMS_Base.CAIGInfo ObjInfo)
        {
            return mObjInfo.AIGInfo_InsertUpdate(ObjInfo);
        }

        public override int AIG_Info_Delete(System.String lPK_AIG_Info_ID)
        {
            return mObjInfo.AIG_Info_Delete(lPK_AIG_Info_ID);
        }

        public override string ActivateInactivateInfo(string strIDs, int intModifiedBy, bool bIsActive)
        {
            return mObjInfo.ActivateInactivateInfo(strIDs, intModifiedBy, bIsActive);
        }

        public override List<RIMS_Base.CAIGInfo> AIGInfo_GetByID(System.Decimal lPK_AIG_Info_ID)
        {
            return mObjInfo.AIGInfo_GetByID(lPK_AIG_Info_ID);
        }

        public override List<RIMS_Base.CAIGInfo> GetAll()
        {
            return mObjInfo.GetAll();
        }
        public override List<RIMS_Base.CAIGInfo> Get_Search_Data(System.String m_strColumn, System.String m_strCriteria)
        {
            return mObjInfo.Get_Search_Data(m_strColumn,m_strCriteria);
        }

        #endregion

    }

}