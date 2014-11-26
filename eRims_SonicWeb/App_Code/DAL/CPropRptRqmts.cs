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


    public class CPropRptRqmts : RIMS_Base.CPropRptRqmts
    {

        public override int PropRptRqmts_InsertUpdate(RIMS_Base.CPropRptRqmts Objs_Other_Reporting_Rqmts)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            int nRetVal = 0;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("PropRptRqmts_InsertUpdate");
                dbHelper.AddParameter(cmd, "@PK_Tanks_Other_Reporting_Rqmts", DbType.Decimal, ParameterDirection.InputOutput, "PK_Tanks_Other_Reporting_Rqmts", DataRowVersion.Current, Objs_Other_Reporting_Rqmts.PK_Tanks_Other_Reporting_Rqmts);
                dbHelper.AddInParameter(cmd, "@FK_Environmental_Tanks", DbType.Decimal, Objs_Other_Reporting_Rqmts.FK_Environmental_Tanks);
                dbHelper.AddInParameter(cmd, "@Type", DbType.String, Objs_Other_Reporting_Rqmts.Type);
                dbHelper.AddInParameter(cmd, "@Due", DbType.DateTime, Objs_Other_Reporting_Rqmts.Due);
                dbHelper.AddInParameter(cmd, "@Filing", DbType.DateTime, Objs_Other_Reporting_Rqmts.Filing);
                dbHelper.AddInParameter(cmd, "@Expiration", DbType.DateTime, Objs_Other_Reporting_Rqmts.Expiration);
                dbHelper.AddInParameter(cmd, "@Notes", DbType.String, Objs_Other_Reporting_Rqmts.Notes);
                dbHelper.AddInParameter(cmd, "@Updated_By", DbType.Decimal, Objs_Other_Reporting_Rqmts.Updated_By);
                dbHelper.AddInParameter(cmd, "@Update_Date", DbType.DateTime, Objs_Other_Reporting_Rqmts.Update_Date);
                dbHelper.ExecuteNonQuery(cmd);
                nRetVal = int.Parse(dbHelper.GetParameterValue(cmd, "@PK_Tanks_Other_Reporting_Rqmts").ToString());
                
                return nRetVal;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            { dbHelper = null; cmd.Dispose(); cmd = null; }
        }
        public override int PropRptRqmts_Delete(System.String lPK_Tanks_Other_Reporting_Rqmts)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            int nRetVal = -1;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("PropRptRqmts_Delete");
                dbHelper.AddInParameter(cmd, "@PK_Tanks_Other_Reporting_Rqmts", DbType.String, lPK_Tanks_Other_Reporting_Rqmts);
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
                cmd = dbHelper.GetStoredProcCommand("PropRptRqmts_GetAll");
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
        public override DataSet PropRptRqmts_GetByID(System.Decimal pK_Tanks_Other_Reporting_Rqmts)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            DataSet dsCommon = new DataSet();
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("PropRptRqmts_GetAll");
                dbHelper.AddInParameter(cmd, "@PK_Tanks_Other_Reporting_Rqmts", DbType.Decimal, pK_Tanks_Other_Reporting_Rqmts);
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

