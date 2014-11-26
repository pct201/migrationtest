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


    public class CPropEnvPermits : RIMS_Base.CPropEnvPermits
    {

        public override int PropEnvPermits_InsertUpdate(RIMS_Base.CPropEnvPermits Objr_Environmental_Permits)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            int nRetVal = 0;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("PropEnvPermits_InsertUpdate");
                dbHelper.AddParameter(cmd, "@PK_Other_Environmental_Permits", DbType.Decimal, ParameterDirection.InputOutput, "PK_Other_Environmental_Permits", DataRowVersion.Current, Objr_Environmental_Permits.PK_Other_Environmental_Permits);
                dbHelper.AddInParameter(cmd, "@FK_Property_Environmental", DbType.Decimal, Objr_Environmental_Permits.FK_Property_Environmental);
                dbHelper.AddInParameter(cmd, "@Type", DbType.String, Objr_Environmental_Permits.Type);
                dbHelper.AddInParameter(cmd, "@Permit_Required", DbType.String, Objr_Environmental_Permits.Permit_Required);
                dbHelper.AddInParameter(cmd, "@Regulation_Number", DbType.String, Objr_Environmental_Permits.Regulation_Number);
                dbHelper.AddInParameter(cmd, "@Certificate_Number", DbType.String, Objr_Environmental_Permits.Certificate_Number);
                dbHelper.AddInParameter(cmd, "@Filing", DbType.DateTime, Objr_Environmental_Permits.Filing);
                dbHelper.AddInParameter(cmd, "@Permit_Begin", DbType.DateTime, Objr_Environmental_Permits.Permit_Begin);
                dbHelper.AddInParameter(cmd, "@Permit_End", DbType.DateTime, Objr_Environmental_Permits.Permit_End);
                dbHelper.AddInParameter(cmd, "@Last_Inspection", DbType.DateTime, Objr_Environmental_Permits.Last_Inspection);
                dbHelper.AddInParameter(cmd, "@Next_Inspection", DbType.DateTime, Objr_Environmental_Permits.Next_Inspection);
                dbHelper.AddInParameter(cmd, "@Next_Report", DbType.DateTime, Objr_Environmental_Permits.Next_Report);
                dbHelper.AddInParameter(cmd, "@Notes", DbType.String, Objr_Environmental_Permits.Notes);
                dbHelper.AddInParameter(cmd, "@Updated_By", DbType.Decimal, Objr_Environmental_Permits.Updated_By);
                dbHelper.AddInParameter(cmd, "@Update_Date", DbType.DateTime, Objr_Environmental_Permits.Update_Date);
                dbHelper.ExecuteNonQuery(cmd);
                nRetVal = int.Parse(dbHelper.GetParameterValue(cmd, "@PK_Other_Environmental_Permits").ToString());
                
                return nRetVal;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            { dbHelper = null; cmd.Dispose(); cmd = null; }
        }
        public override int PropEnvPermits_Delete(System.String lPK_Other_Environmental_Permits)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            int nRetVal = -1;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("PropEnvPermits_Delete");
                dbHelper.AddInParameter(cmd, "@PK_Other_Environmental_Permits", DbType.String, lPK_Other_Environmental_Permits);
                nRetVal = dbHelper.ExecuteNonQuery(cmd);
                dbHelper = null; cmd.Dispose(); cmd = null;
                return nRetVal;
            }
            catch (Exception)
            {
                throw;
            }
        }
        
        public override DataSet GetAll()
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            DataSet dsCommon = new DataSet();
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("PropEnvPermits_GetAll");
                dsCommon = dbHelper.ExecuteDataSet(cmd);
                cmd = null;
                dbHelper = null;
                return dsCommon;
            }
            catch (Exception)
            {
                throw;
            }
        }


        public override DataSet PropEnvPermits_GetByID(System.Decimal pK_Other_Environmental_Permits)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            DataSet dsCommon = new DataSet();
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("PropEnvPermits_GetAll");
                dbHelper.AddInParameter(cmd, "@PK_Other_Environmental_Permits", DbType.Decimal, pK_Other_Environmental_Permits);
                dsCommon = dbHelper.ExecuteDataSet(cmd);
                cmd = null;
                dbHelper = null;
                return dsCommon;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public override DataSet GetOEType()
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            DataSet dsCommon = new DataSet();
            int nRetVal = -1;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("PropEnvPermits_GetOEType");
                dsCommon = dbHelper.ExecuteDataSet(cmd);
                dbHelper = null; cmd.Dispose(); cmd = null;
                return dsCommon;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public override DataSet PropEnvPermits_GetByEnvID(decimal EnvID)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            DataSet dsCommon = new DataSet();
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("PropEnvPermits_GetByEnvID");
                dbHelper.AddInParameter(cmd, "@EnvID", DbType.Decimal, EnvID);
                dsCommon = dbHelper.ExecuteDataSet(cmd);

                cmd = null;
                dbHelper = null;

                return dsCommon;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }


}

