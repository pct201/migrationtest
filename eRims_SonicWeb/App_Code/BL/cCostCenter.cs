#region Includes
using System;
using System.Collections.Generic;
using System.Text;
#endregion

namespace RIMS_Base.Biz
{

    [Serializable]
    public class  cCostCenter : RIMS_Base. cCostCenter
    {
        #region Private Declarations
        RIMS_Base. cCostCenter mObj_Center;
        #endregion

        #region Constructor
        public  cCostCenter()
        {
            mObj_Center = new RIMS_Base.Dal. cCostCenter();
        }
        #endregion

        #region Public Methods
        public override int InsertUpdate_Center(RIMS_Base. cCostCenter Obj_Center)
        {
            return mObj_Center.InsertUpdate_Center(Obj_Center);
        }

        public override int Delete_Center(System.Int32 lPK_ID)
        {
            return mObj_Center.Delete_Center(lPK_ID);
        }

        public override string ActivateInactivate_Center(string strIDs, int intModifiedBy, bool bIsActive)
        {
            return mObj_Center.ActivateInactivate_Center(strIDs, intModifiedBy, bIsActive);
        }

        public override List<RIMS_Base.cCostCenter> Get_Search_Data(System.String m_strColumn, System.String m_strCriteria)
        {
            return mObj_Center.Get_Search_Data(m_strColumn, m_strCriteria);
        }

        public override List<RIMS_Base.cCostCenter> GetAll()
        {
            return mObj_Center.GetAll();
        }
        #endregion

    }

}