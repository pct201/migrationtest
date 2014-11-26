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


    public class CPropEnvWaste : RIMS_Base.CPropEnvWaste
    {

        public override int PropEnvWaste_InsertUpdate(RIMS_Base.CPropEnvWaste Objronmental_Waste)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            int nRetVal = 0;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("PropEnvWaste_InsertUpdate");
                dbHelper.AddParameter(cmd, "@PK_Environmental_Waste", DbType.Decimal, ParameterDirection.InputOutput, "PK_Environmental_Waste", DataRowVersion.Current, Objronmental_Waste.PK_Environmental_Waste);
                dbHelper.AddInParameter(cmd, "@FK_Property_Environmental", DbType.Decimal, Objronmental_Waste.FK_Property_Environmental);
                dbHelper.AddInParameter(cmd, "@Type", DbType.String, Objronmental_Waste.Type);
                dbHelper.AddInParameter(cmd, "@Permit_Required", DbType.String, Objronmental_Waste.Permit_Required);
                dbHelper.AddInParameter(cmd, "@Regulation_Number", DbType.String, Objronmental_Waste.Regulation_Number);
                dbHelper.AddInParameter(cmd, "@Certificate_Number", DbType.String, Objronmental_Waste.Certificate_Number);
                dbHelper.AddInParameter(cmd, "@Filing", DbType.DateTime, Objronmental_Waste.Filing);
                dbHelper.AddInParameter(cmd, "@Permit_Begin", DbType.DateTime, Objronmental_Waste.Permit_Begin);
                dbHelper.AddInParameter(cmd, "@Permit_End", DbType.DateTime, Objronmental_Waste.Permit_End);
                dbHelper.AddInParameter(cmd, "@Last_Inspection", DbType.DateTime, Objronmental_Waste.Last_Inspection);
                dbHelper.AddInParameter(cmd, "@Next_Inspection", DbType.DateTime, Objronmental_Waste.Next_Inspection);
                dbHelper.AddInParameter(cmd, "@Next_Report", DbType.DateTime, Objronmental_Waste.Next_Report);
                dbHelper.AddInParameter(cmd, "@Notes", DbType.String, Objronmental_Waste.Notes);
                dbHelper.AddInParameter(cmd, "@Updated_By", DbType.Decimal, Objronmental_Waste.Updated_By);
                dbHelper.AddInParameter(cmd, "@Update_Date", DbType.DateTime, Objronmental_Waste.Update_Date);
                dbHelper.ExecuteNonQuery(cmd);
                nRetVal = int.Parse(dbHelper.GetParameterValue(cmd, "@PK_Environmental_Waste").ToString());
                return nRetVal;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            { dbHelper = null; cmd.Dispose(); cmd = null; }
        }
        public override int PropEnvWaste_Delete(System.String lPK_Environmental_Waste)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            int nRetVal = -1;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("PropEnvWaste_Delete");
                dbHelper.AddInParameter(cmd, "@PK_Environmental_Waste", DbType.Decimal, lPK_Environmental_Waste);
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
                cmd = dbHelper.GetStoredProcCommand("PropEnvWaste_GetAll");
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


        public override DataSet GetPropEnvWasteByID(System.Decimal pK_Environmental_Waste)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            DataSet dsCommon = new DataSet();
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("PropEnvWaste_GetAll");
                dbHelper.AddInParameter(cmd, "@PK_Environmental_Waste", DbType.Decimal, pK_Environmental_Waste);
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

        public override DataSet PropEnvWaste_GetByEnvID(decimal EnvID)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            DataSet dsCommon = new DataSet();
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("PropEnvWaste_GetByEnvID");
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

