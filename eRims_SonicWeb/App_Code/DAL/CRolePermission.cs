#region Includes
using System;
using System.Data;
using System.Collections.Generic;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using Microsoft.Practices.EnterpriseLibrary.Common;
using System.Configuration;
using System.Globalization;
using System.Data.Common;
#endregion

namespace RIMS_Base.Dal
{
    [Serializable]


    public class CRolePermission : RIMS_Base.CRolePermission
    {

        public override int InsertUpdateRoleAdvPermission(RIMS_Base.CRolePermission ObjRoleAdvPermission)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            int nRetVal = 0;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("InsertUpdate_RolePermission");
                dbHelper.AddInParameter(cmd, "@RoleAdvPermissionId", DbType.Int32, ObjRoleAdvPermission.RoleAdvPermissionId);
                dbHelper.AddInParameter(cmd, "@RoleId", DbType.Int32, ObjRoleAdvPermission.RoleId);
                dbHelper.AddInParameter(cmd, "@ScreenId", DbType.Int32, ObjRoleAdvPermission.ScreenId);
                dbHelper.AddInParameter(cmd, "@pAdd", DbType.Boolean, ObjRoleAdvPermission.PAdd);
                dbHelper.AddInParameter(cmd, "@pEdit", DbType.Boolean, ObjRoleAdvPermission.PEdit);
                dbHelper.AddInParameter(cmd, "@pView", DbType.Boolean, ObjRoleAdvPermission.PView);
                dbHelper.AddInParameter(cmd, "@pDelete", DbType.Boolean, ObjRoleAdvPermission.PDelete);
                dbHelper.AddInParameter(cmd, "@pAct", DbType.Boolean, true);
                dbHelper.AddInParameter(cmd, "@pUserPer", DbType.Boolean, true);
                dbHelper.AddInParameter(cmd, "@pPass", DbType.Boolean, true);
                dbHelper.AddInParameter(cmd, "@pApprove", DbType.Boolean, true);
                dbHelper.AddInParameter(cmd, "@pReject", DbType.Boolean, true);
                dbHelper.AddInParameter(cmd, "@pClientAssign", DbType.Boolean, true);
                dbHelper.AddInParameter(cmd, "@pProjectAssign", DbType.Boolean, true);
                dbHelper.AddInParameter(cmd, "@IsActive", DbType.Boolean, true);
                dbHelper.AddInParameter(cmd, "@IsDeleted", DbType.Boolean, true);
                dbHelper.AddInParameter(cmd, "@CreatedBy", DbType.Int32, ObjRoleAdvPermission.CreatedBy);
                dbHelper.AddInParameter(cmd, "@ModifiedBy", DbType.Int32, ObjRoleAdvPermission.ModifiedBy);
                dbHelper.ExecuteNonQuery(cmd);
                nRetVal = int.Parse(dbHelper.GetParameterValue(cmd, "@RoleAdvPermissionId").ToString());

                return nRetVal;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                dbHelper = null; cmd.Dispose(); cmd = null;
            }
        }
        public override List<RIMS_Base.CRolePermission> GetAll()
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Select_RolePermission");
                IDataReader reader = dbHelper.ExecuteReader(cmd);
                List<RIMS_Base.CRolePermission> results = new List<RIMS_Base.CRolePermission>();
                while (reader.Read())
                {
                    CRolePermission objRoleAdvPermission = new CRolePermission();
                    objRoleAdvPermission = MapFrom(reader);
                    results.Add(objRoleAdvPermission);
                }
                reader.Close();
                cmd = null;
                dbHelper = null;
                return results;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public override List<RIMS_Base.CRolePermission> GetRoleAdvPermissionByID(System.Int32 roleAdvPermissionId)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Select_RolePermission");
                dbHelper.AddInParameter(cmd, "@RoleAdvPermissionId", DbType.Int32, roleAdvPermissionId);
                List<RIMS_Base.CRolePermission> results = new List<RIMS_Base.CRolePermission>();
                IDataReader reader = dbHelper.ExecuteReader(cmd);
                CRolePermission objRoleAdvPermission = new CRolePermission();
                while (reader.Read())
                {
                    objRoleAdvPermission = MapFrom(reader);
                    results.Add(objRoleAdvPermission);
                }
                reader.Close();
                cmd = null;
                dbHelper = null;

                return results;
            }
            catch (Exception)
            {
                throw;
            }
        }
        protected RIMS_Base.Dal.CRolePermission MapFrom(IDataReader reader)
        {
            RIMS_Base.Dal.CRolePermission objRoleAdvPermission = new RIMS_Base.Dal.CRolePermission();
            if (!Convert.IsDBNull(reader["RoleAdvPermissionId"])) { objRoleAdvPermission.RoleAdvPermissionId = Convert.ToInt32(reader["RoleAdvPermissionId"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["RoleId"])) { objRoleAdvPermission.RoleId = Convert.ToInt32(reader["RoleId"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["ScreenId"])) { objRoleAdvPermission.ScreenId = Convert.ToInt32(reader["ScreenId"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["pAdd"])) { objRoleAdvPermission.PAdd = Convert.ToBoolean(reader["pAdd"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["pEdit"])) { objRoleAdvPermission.PEdit = Convert.ToBoolean(reader["pEdit"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["pView"])) { objRoleAdvPermission.PView = Convert.ToBoolean(reader["pView"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["pDelete"])) { objRoleAdvPermission.PDelete = Convert.ToBoolean(reader["pDelete"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["pAct"])) { objRoleAdvPermission.PAct = Convert.ToBoolean(reader["pAct"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["pUserPer"])) { objRoleAdvPermission.PUserPer = Convert.ToBoolean(reader["pUserPer"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["pPass"])) { objRoleAdvPermission.PPass = Convert.ToBoolean(reader["pPass"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["pApprove"])) { objRoleAdvPermission.PApprove = Convert.ToBoolean(reader["pApprove"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["pReject"])) { objRoleAdvPermission.PReject = Convert.ToBoolean(reader["pReject"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["pClientAssign"])) { objRoleAdvPermission.PClientAssign = Convert.ToBoolean(reader["pClientAssign"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["pProjectAssign"])) { objRoleAdvPermission.PProjectAssign = Convert.ToBoolean(reader["pProjectAssign"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["IsActive"])) { objRoleAdvPermission.IsActive = Convert.ToBoolean(reader["IsActive"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["IsDeleted"])) { objRoleAdvPermission.IsDeleted = Convert.ToBoolean(reader["IsDeleted"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["CreatedBy"])) { objRoleAdvPermission.CreatedBy = Convert.ToInt32(reader["CreatedBy"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["ModifiedBy"])) { objRoleAdvPermission.ModifiedBy = Convert.ToInt32(reader["ModifiedBy"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["CreatedDate"])) { objRoleAdvPermission.CreatedDate = Convert.ToDateTime(reader["CreatedDate"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["ModifiedDate"])) { objRoleAdvPermission.ModifiedDate = Convert.ToDateTime(reader["ModifiedDate"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["ScreenName"])) { objRoleAdvPermission.ScreenName = Convert.ToString(reader["ScreenName"], CultureInfo.InvariantCulture); }
            return objRoleAdvPermission;
        }
        public override List<RIMS_Base.CRolePermission> GetRoles()
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Select_Roles");
                IDataReader reader = dbHelper.ExecuteReader(cmd);
                List<RIMS_Base.CRolePermission> results = new List<RIMS_Base.CRolePermission>();
                while (reader.Read())
                {
                    CRolePermission objRoleAdvPermission = new CRolePermission();
                    objRoleAdvPermission = MapFromRoles(reader);
                    results.Add(objRoleAdvPermission);
                }
                reader.Close();
                cmd = null;
                dbHelper = null;
                return results;
            }
            catch (Exception)
            {
                throw;
            }
        }
        protected RIMS_Base.Dal.CRolePermission MapFromRoles(IDataReader reader)
        {
            RIMS_Base.Dal.CRolePermission objRoleAdvPermission = new RIMS_Base.Dal.CRolePermission();
            if (!Convert.IsDBNull(reader["fld_Desc"])) { objRoleAdvPermission.RoleName = Convert.ToString(reader["fld_desc"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["pk_id"])) { objRoleAdvPermission.RoleId = Convert.ToInt32(reader["pk_id"], CultureInfo.InvariantCulture); }
            return objRoleAdvPermission;
        }
        public override List<RIMS_Base.CRolePermission> GetRights(int ScreenId,int RoleId)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("GetRights");
                dbHelper.AddInParameter(cmd, "@ScreenId", DbType.Int32, ScreenId);
                dbHelper.AddInParameter(cmd, "@RoleId", DbType.Int32, RoleId);
                IDataReader reader = dbHelper.ExecuteReader(cmd);
                List<RIMS_Base.CRolePermission> results = new List<RIMS_Base.CRolePermission>();
                while (reader.Read())
                {
                    CRolePermission objRoleAdvPermission = new CRolePermission();
                    objRoleAdvPermission = MapFromRights(reader);
                    results.Add(objRoleAdvPermission);
                }
                reader.Close();
                cmd = null;
                dbHelper = null;
                return results;
            }
            catch (Exception)
            {
                throw;
            }
        }
        protected RIMS_Base.Dal.CRolePermission MapFromRights(IDataReader reader)
        {
            RIMS_Base.Dal.CRolePermission objRoleAdvPermission = new RIMS_Base.Dal.CRolePermission();
            if (!Convert.IsDBNull(reader["RoleId"])) { objRoleAdvPermission.RoleId = Convert.ToInt32(reader["RoleId"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["ScreenId"])) { objRoleAdvPermission.ScreenId = Convert.ToInt32(reader["ScreenId"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["pAdd"])) { objRoleAdvPermission.PAdd = Convert.ToBoolean(reader["pAdd"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["pEdit"])) { objRoleAdvPermission.PEdit = Convert.ToBoolean(reader["pEdit"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["pView"])) { objRoleAdvPermission.PView = Convert.ToBoolean(reader["pView"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["pDelete"])) { objRoleAdvPermission.PDelete = Convert.ToBoolean(reader["pDelete"], CultureInfo.InvariantCulture); }
            return objRoleAdvPermission;
         }
    }


}

