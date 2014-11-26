#region Includes
using System;
using System.Collections.Generic;
using System.Text;
#endregion

namespace RIMS_Base
{

    [Serializable]
    public abstract class CRolePermission
    {

        #region Constructor
        public CRolePermission()
        {
            this._roleAdvPermissionId = -1;
            this._roleId = -1;
            this._screenId = -1;
            this._pAdd = true;
            this._pEdit = true;
            this._pView = true;
            this._pDelete = true;
            this._pAct = true;
            this._pUserPer = true;
            this._pPass = true;
            this._pApprove = true;
            this._pReject = true;
            this._pClientAssign = true;
            this._pProjectAssign = true;
            this._isActive = true;
            this._isDeleted = true;
            this._createdBy = -1;
            this._modifiedBy = -1;
            this._createdDate = DateTime.Now;
            this._modifiedDate = DateTime.Now;
        }
        #endregion

        #region Private Variables
        private System.Int32 _roleAdvPermissionId;
        private System.Int32 _roleId;
        private System.Int32 _screenId;
        private System.Boolean _pAdd;
        private System.Boolean _pEdit;
        private System.Boolean _pView;
        private System.Boolean _pDelete;
        private System.Boolean _pAct;
        private System.Boolean _pUserPer;
        private System.Boolean _pPass;
        private System.Boolean _pApprove;
        private System.Boolean _pReject;
        private System.Boolean _pClientAssign;
        private System.Boolean _pProjectAssign;
        private System.Boolean _isActive;
        private System.Boolean _isDeleted;
        private System.Int32 _createdBy;
        private System.Int32 _modifiedBy;
        private System.DateTime _createdDate;
        private System.DateTime _modifiedDate;
        private System.String _screenname;
        private System.String _rolename;
        #endregion

        #region Public Properties
        public System.Int32 RoleAdvPermissionId
        {
            get { return _roleAdvPermissionId; }
            set { _roleAdvPermissionId = value; }
        }

        public System.Int32 RoleId
        {
            get { return _roleId; }
            set { _roleId = value; }
        }

        public System.Int32 ScreenId
        {
            get { return _screenId; }
            set { _screenId = value; }
        }

        public System.Boolean PAdd
        {
            get { return _pAdd; }
            set { _pAdd = value; }
        }

        public System.Boolean PEdit
        {
            get { return _pEdit; }
            set { _pEdit = value; }
        }

        public System.Boolean PView
        {
            get { return _pView; }
            set { _pView = value; }
        }

        public System.Boolean PDelete
        {
            get { return _pDelete; }
            set { _pDelete = value; }
        }

        public System.Boolean PAct
        {
            get { return _pAct; }
            set { _pAct = value; }
        }

        public System.Boolean PUserPer
        {
            get { return _pUserPer; }
            set { _pUserPer = value; }
        }

        public System.Boolean PPass
        {
            get { return _pPass; }
            set { _pPass = value; }
        }

        public System.Boolean PApprove
        {
            get { return _pApprove; }
            set { _pApprove = value; }
        }

        public System.Boolean PReject
        {
            get { return _pReject; }
            set { _pReject = value; }
        }

        public System.Boolean PClientAssign
        {
            get { return _pClientAssign; }
            set { _pClientAssign = value; }
        }

        public System.Boolean PProjectAssign
        {
            get { return _pProjectAssign; }
            set { _pProjectAssign = value; }
        }

        public System.Boolean IsActive
        {
            get { return _isActive; }
            set { _isActive = value; }
        }

        public System.Boolean IsDeleted
        {
            get { return _isDeleted; }
            set { _isDeleted = value; }
        }

        public System.Int32 CreatedBy
        {
            get { return _createdBy; }
            set { _createdBy = value; }
        }

        public System.Int32 ModifiedBy
        {
            get { return _modifiedBy; }
            set { _modifiedBy = value; }
        }

        public System.DateTime CreatedDate
        {
            get { return _createdDate; }
            set { _createdDate = value; }
        }

        public System.DateTime ModifiedDate
        {
            get { return _modifiedDate; }
            set { _modifiedDate = value; }
        }
        public System.String ScreenName
        {
            get { return _screenname; }
            set { _screenname = value; }
        }
        public System.String RoleName
        {
            get { return _rolename; }
            set { _rolename = value; }
        }
        #endregion

        #region Abstract Methods
        public abstract List<CRolePermission> GetAll();
        public abstract List<CRolePermission> GetRoleAdvPermissionByID(System.Int32 lRoleAdvPermissionId);
        public abstract int InsertUpdateRoleAdvPermission(RIMS_Base.CRolePermission obj);
        //public abstract int DeleteRoleAdvPermission(System.Int32 lRoleAdvPermissionId);
        //public abstract string ActivateInactivateRoleAdvPermission(string strIDs, int intModifiedBy, bool bIsActive);
        public abstract List<CRolePermission> GetRoles();
        public abstract List<CRolePermission> GetRights(int ScreenId,int RoleId);
        #endregion

    }

}
