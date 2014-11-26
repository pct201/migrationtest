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
using System.Data;
using System.Data.SqlClient; 
#endregion

namespace RIMS_Base.Dal
{
    [Serializable]


    public class CSecurity : RIMS_Base.CSecurity
    {

        public override int InsertUpdateSecurity(RIMS_Base.CSecurity Objrity)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            int nRetVal = -1;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Security_InsertUpdate");
                dbHelper.AddParameter(cmd, "@PK_Security_ID", DbType.Int32, ParameterDirection.InputOutput, "PK_Security_ID", DataRowVersion.Current, Objrity.PK_Security_ID);
                dbHelper.AddInParameter(cmd, "@FIRST_NAME", DbType.String, Objrity.FIRST_NAME);
                dbHelper.AddInParameter(cmd, "@LAST_NAME", DbType.String, Objrity.LAST_NAME);
                dbHelper.AddInParameter(cmd, "@USER_NAME", DbType.String, Objrity.USER_NAME);
                dbHelper.AddInParameter(cmd, "@PASSWORD", DbType.String, Objrity.PASSWORD);
                dbHelper.AddInParameter(cmd, "@USER_ROLE", DbType.Decimal, Objrity.FKUserRole);
                dbHelper.AddInParameter(cmd, "@UPDATED_BY", DbType.String, Objrity.UPDATED_BY);
                dbHelper.AddInParameter(cmd, "@UPDATE_DATE", DbType.DateTime, Objrity.UPDATE_DATE);
                dbHelper.AddInParameter(cmd, "@Cost_Center", DbType.String, Objrity.Cost_Center);
                dbHelper.AddInParameter(cmd, "@Email", DbType.String, Objrity.Email);
                dbHelper.ExecuteNonQuery(cmd);
                nRetVal = int.Parse(dbHelper.GetParameterValue(cmd, "@PK_Security_ID").ToString());
                
                return nRetVal;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            { dbHelper = null; cmd.Dispose(); cmd = null; }
        }
        public override int DeleteSecurity(System.String PK_Security_ID)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            int nRetVal = -1;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Security_Delete");
                dbHelper.AddInParameter(cmd, "@PK_Security_ID", DbType.String, PK_Security_ID);
                nRetVal = dbHelper.ExecuteNonQuery(cmd);
                dbHelper = null; cmd.Dispose(); cmd = null;
                return nRetVal;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public override string ActivateInactivaterity(string strIDs, int intModifiedBy, bool bIsActive)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            int nRetVal = -1;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Sec_ActivateInactivateritys");
                dbHelper.AddParameter(cmd, "@PK_Security_IDs", DbType.String, ParameterDirection.InputOutput, "PK_Security_IDs", DataRowVersion.Current, strIDs);
                dbHelper.AddInParameter(cmd, "@ModifiedBy", DbType.Int32, intModifiedBy);
                dbHelper.AddInParameter(cmd, "@IsActive", DbType.Boolean, bIsActive);
                nRetVal = dbHelper.ExecuteNonQuery(cmd);
                dbHelper = null; cmd.Dispose(); cmd = null;
                return "";
            }
            catch (Exception)
            {
                throw;
            }
        }
        public override List<RIMS_Base.CSecurity> GetAll()
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Get_SecrityUser");
                IDataReader reader = dbHelper.ExecuteReader(cmd);
                List<RIMS_Base.CSecurity> results = new List<RIMS_Base.CSecurity>();
                while (reader.Read())
                {
                    CSecurity objrity = new CSecurity();
                    objrity = MapFrom(reader);
                    results.Add(objrity);
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
        public override DataSet Check_Login(System.String m_strUserName, System.String m_strPwd)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            DataSet m_dsSecurity = new DataSet();
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Security_S_Login");
                dbHelper.AddInParameter(cmd, "@UserName", DbType.String, m_strUserName);
                dbHelper.AddInParameter(cmd, "@Password", DbType.String, m_strPwd);
                m_dsSecurity=dbHelper.ExecuteDataSet(cmd);
                //IDataReader reader = dbHelper.ExecuteReader(cmd);
                //List<RIMS_Base.CSecurity> results = new List<RIMS_Base.CSecurity>();
                //while (reader.Read())
                //{
                //    CSecurity objrity = new CSecurity();
                //    objrity = MapFrom(reader);
                //    results.Add(objrity);
                //}
                //reader.Close();
                cmd = null;
                dbHelper = null;
                return m_dsSecurity;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public override List<RIMS_Base.CSecurity> GetSecurityByID(System.Int32 pK_Security_ID)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Get_SecrityUser");
                dbHelper.AddInParameter(cmd, "@PK_Security_ID", DbType.Int32, pK_Security_ID);

                IDataReader reader = dbHelper.ExecuteReader(cmd);
                List<RIMS_Base.CSecurity> result = new List<RIMS_Base.CSecurity>();
                CSecurity objrity = new CSecurity();
                if (reader.Read())
                {
                    objrity = MapFrom(reader);
                    result.Add(objrity);
                }
                reader.Close();
                cmd = null;
                dbHelper = null;

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public override DataSet GetUserRole()
        {
            DbCommand cmd=null;
            DataSet dstDataset = null;
            Database dbHelper = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("GetUserRole");
                dstDataset = dbHelper.ExecuteDataSet(cmd);
                cmd = null;
                dbHelper = null;
                return dstDataset;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public override DataSet GetCostCenter()
        {
            DbCommand cmd = null;
            DataSet dstDataset = null;
            Database dbHelper = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("GetCostCenter");
                dstDataset = dbHelper.ExecuteDataSet(cmd);
                cmd = null;
                dbHelper = null;
                return dstDataset;
            }
            catch (Exception ex)
            {
                throw ex;
            }           
        }
        public override List<RIMS_Base.CSecurity> GetAllSecurity(System.String SearchText)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Get_SecrityUser");
                dbHelper.AddInParameter(cmd, "@SearchUserName", DbType.String, SearchText);

                IDataReader reader = dbHelper.ExecuteReader(cmd);
                List<RIMS_Base.CSecurity> results = new List<RIMS_Base.CSecurity>();
                while (reader.Read())
                {
                    CSecurity objrity = new CSecurity();
                    objrity = MapFrom(reader);
                    results.Add(objrity);
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
        public override int UpdatePassword(int SecurityID, string UserName, string NewPassword, string UpdateBy)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            int nRetVal = -1;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Security_UpdatePassword");
                dbHelper.AddParameter(cmd, "@PK_Security_ID", DbType.Int32, ParameterDirection.InputOutput, "PK_Security_ID", DataRowVersion.Current, SecurityID);

                dbHelper.AddInParameter(cmd, "@USER_NAME", DbType.String, UserName);
                dbHelper.AddInParameter(cmd, "@PASSWORD", DbType.String, NewPassword);
                dbHelper.AddInParameter(cmd, "@UPDATED_BY", DbType.String, UpdateBy);
                dbHelper.ExecuteNonQuery(cmd);
                nRetVal = int.Parse(dbHelper.GetParameterValue(cmd, "@PK_Security_ID").ToString());

                return nRetVal;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            { dbHelper = null; cmd.Dispose(); cmd = null; }
        }
        public override int GetPWDType()
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            int nRetVal = -1;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Get_PasswordType");
                //dbHelper.AddOutParameter(cmd, "@PWD_Type", DbType.Int32,8);
                dbHelper.AddParameter(cmd, "@PWD_Type", DbType.String, ParameterDirection.InputOutput, "PWD_Type", DataRowVersion.Current, "2");
                
                dbHelper.ExecuteNonQuery(cmd);
                nRetVal = int.Parse(dbHelper.GetParameterValue(cmd, "@PWD_Type").ToString());
                return nRetVal;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            { dbHelper = null; cmd.Dispose(); cmd = null; }
        }

        public override List<RIMS_Base.CSecurity> GetAdminByID(System.Int32 USER_ROLE)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Get_AdminByID");
                dbHelper.AddInParameter(cmd, "@USER_ROLE", DbType.Int32, USER_ROLE);

                IDataReader reader = dbHelper.ExecuteReader(cmd);
                List<RIMS_Base.CSecurity> result = new List<RIMS_Base.CSecurity>();
               // CSecurity objAdmin = new CSecurity();
                while (reader.Read())
                {
                    CSecurity objAdmin = new CSecurity();
                    objAdmin = MapFromAdmin(reader);
                    result.Add(objAdmin);
                }
                reader.Close();
                cmd = null;
                dbHelper = null;

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }


      



        protected RIMS_Base.Dal.CSecurity MapFrom(IDataReader reader)
        {
            RIMS_Base.Dal.CSecurity objrity = new RIMS_Base.Dal.CSecurity();
            if (!Convert.IsDBNull(reader["PK_Security_ID"])) { objrity.PK_Security_ID = Convert.ToInt32(reader["PK_Security_ID"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FIRST_NAME"])) { objrity.FIRST_NAME = Convert.ToString(reader["FIRST_NAME"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["LAST_NAME"])) { objrity.LAST_NAME = Convert.ToString(reader["LAST_NAME"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["USER_NAME"])) { objrity.USER_NAME = Convert.ToString(reader["USER_NAME"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["PASSWORD"])) { objrity.PASSWORD = Convert.ToString(reader["PASSWORD"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["USER_ROLE"])) { objrity.FKUserRole = Convert.ToDecimal(reader["USER_ROLE"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["UPDATED_BY"])) { objrity.UPDATED_BY = Convert.ToString(reader["UPDATED_BY"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["UPDATE_DATE"])) { objrity.UPDATE_DATE = Convert.ToDateTime(reader["UPDATE_DATE"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Cost_Center"])) { objrity.Cost_Center = Convert.ToString(reader["Cost_Center"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Email"])) { objrity.Email = Convert.ToString(reader["Email"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["fld_desc"])) { objrity.USER_ROLE = Convert.ToString(reader["fld_desc"], CultureInfo.InvariantCulture); }
            return objrity;
        }


        protected RIMS_Base.Dal.CSecurity MapFromAdmin(IDataReader reader)
        {
            RIMS_Base.Dal.CSecurity objAdmin= new RIMS_Base.Dal.CSecurity();
            if (!Convert.IsDBNull(reader["PK_Security_ID"])) { objAdmin.PK_Security_ID = Convert.ToInt32(reader["PK_Security_ID"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FIRST_NAME"])) { objAdmin.FIRST_NAME = Convert.ToString(reader["FIRST_NAME"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["LAST_NAME"])) { objAdmin.LAST_NAME = Convert.ToString(reader["LAST_NAME"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["USER_NAME"])) { objAdmin.USER_NAME = Convert.ToString(reader["USER_NAME"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["PASSWORD"])) { objAdmin.PASSWORD = Convert.ToString(reader["PASSWORD"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["USER_ROLE"])) { objAdmin.FKUserRole = Convert.ToDecimal(reader["USER_ROLE"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["UPDATED_BY"])) { objAdmin.UPDATED_BY = Convert.ToString(reader["UPDATED_BY"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["UPDATE_DATE"])) { objAdmin.UPDATE_DATE = Convert.ToDateTime(reader["UPDATE_DATE"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Cost_Center"])) { objAdmin.Cost_Center = Convert.ToString(reader["Cost_Center"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Email"])) { objAdmin.Email = Convert.ToString(reader["Email"], CultureInfo.InvariantCulture); }
            //if (!Convert.IsDBNull(reader["fld_desc"])) { objAdmin.USER_ROLE = Convert.ToString(reader["fld_desc"], CultureInfo.InvariantCulture); }
            return objAdmin;
        }      


    }


}

