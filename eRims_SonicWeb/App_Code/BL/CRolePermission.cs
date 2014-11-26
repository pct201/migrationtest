#region Includes
using System;
using System.Collections.Generic;
using System.Text;
#endregion

namespace RIMS_Base.Biz
{

    [Serializable]
    public class CRolePermission : RIMS_Base.CRolePermission
    {
        #region Private Declarations
        RIMS_Base.CRolePermission mObjRoleAdvPermission;
        #endregion

        #region Constructor
        public CRolePermission()
        {
            mObjRoleAdvPermission = new RIMS_Base.Dal.CRolePermission();
        }
        #endregion

        #region Public Methods
        public override int InsertUpdateRoleAdvPermission(RIMS_Base.CRolePermission ObjRoleAdvPermission)
        {
            return mObjRoleAdvPermission.InsertUpdateRoleAdvPermission(ObjRoleAdvPermission);
        }


        public override List<RIMS_Base.CRolePermission> GetRoleAdvPermissionByID(System.Int32 lRoleAdvPermissionId)
        {
            return mObjRoleAdvPermission.GetRoleAdvPermissionByID(lRoleAdvPermissionId);
        }

        public override List<RIMS_Base.CRolePermission> GetAll()
        {
            return mObjRoleAdvPermission.GetAll();
        }
        public override List<RIMS_Base.CRolePermission> GetRoles()
        {
            return mObjRoleAdvPermission.GetRoles();
        }
        public override List<RIMS_Base.CRolePermission> GetRights(int ScreenId,int RoleId)
        {
            return mObjRoleAdvPermission.GetRights(ScreenId,RoleId);
        }
        #endregion

    }

}