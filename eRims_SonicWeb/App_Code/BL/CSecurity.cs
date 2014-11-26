#region Includes
using System;
using System.Collections.Generic;
using System.Text;
#endregion

namespace RIMS_Base.Biz
{

    [Serializable]
    public class CSecurity : RIMS_Base.CSecurity
    {
        #region Private Declarations
        RIMS_Base.CSecurity mObjRity;
        #endregion

        #region Constructor
        public CSecurity()
        {
            mObjRity = new RIMS_Base.Dal.CSecurity();
        }
        #endregion

        #region Public Methods
        public override int InsertUpdateSecurity(RIMS_Base.CSecurity Objrity)
        {
            return mObjRity.InsertUpdateSecurity(Objrity);
        }

        public override int DeleteSecurity(System.String lPK_Security_ID)
        {
            return mObjRity.DeleteSecurity(lPK_Security_ID);
        }

        public override string ActivateInactivaterity(string strIDs, int intModifiedBy, bool bIsActive)
        {
            return mObjRity.ActivateInactivaterity(strIDs, intModifiedBy, bIsActive);
        }

        public override List<RIMS_Base.CSecurity> GetSecurityByID(System.Int32 lPK_Security_ID)
        {
            return mObjRity.GetSecurityByID(lPK_Security_ID);
        }

        public override List<RIMS_Base.CSecurity> GetAll()
        {
            return mObjRity.GetAll();
        }
        public override System.Data.DataSet GetUserRole()
        {
            return mObjRity.GetUserRole();
        }
        public override System.Data.DataSet Check_Login(System.String m_strUserName, System.String m_strPwd)
        {
            return mObjRity.Check_Login(m_strUserName,m_strPwd);
        }
        public override System.Data.DataSet GetCostCenter()
        {
            return mObjRity.GetCostCenter();
        }
        public override List<RIMS_Base.CSecurity> GetAllSecurity(string SearchText)
        {
            return mObjRity.GetAllSecurity(SearchText);
        }
        public override int UpdatePassword(int PK_Security_ID, string UserName, string NewPwd, string UpdateBy)
        {
            return mObjRity.UpdatePassword(PK_Security_ID, UserName, NewPwd, UpdateBy);
        }
        public override int GetPWDType()
        {
            return mObjRity.GetPWDType();
        }

        public override List<RIMS_Base.CSecurity> GetAdminByID(System.Int32 USER_ROLE)
        {
            return mObjRity.GetAdminByID(USER_ROLE);
        }
        #endregion

    }

}