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


    public class CPropMonitoring : RIMS_Base.CPropMonitoring
    {
        public override int PropMonitoring_InsertUpdate(RIMS_Base.CPropMonitoring Objerty_Monitoring)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            int nRetVal = 0;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("PropMonitoring_InsertUpdate");
                dbHelper.AddParameter(cmd, "@PK_Property_Monitoring", DbType.Int32, ParameterDirection.InputOutput, "PK_Property_Monitoring", DataRowVersion.Current, Objerty_Monitoring.PK_Property_Monitoring);
                dbHelper.AddInParameter(cmd, "@FK_Property_COPE", DbType.Decimal, Objerty_Monitoring.FK_Property_COPE);
                dbHelper.AddInParameter(cmd, "@System", DbType.String, Objerty_Monitoring.System);
                dbHelper.AddInParameter(cmd, "@Vendor_Name", DbType.String, Objerty_Monitoring.Vendor_Name);
                dbHelper.AddInParameter(cmd, "@Contact_Name", DbType.String, Objerty_Monitoring.Contact_Name);
                dbHelper.AddInParameter(cmd, "@Contract_Epiration_Date", DbType.DateTime, Objerty_Monitoring.Contract_Epiration_Date);
                dbHelper.AddInParameter(cmd, "@Address_1", DbType.String, Objerty_Monitoring.Address_1);
                dbHelper.AddInParameter(cmd, "@Address_2", DbType.String, Objerty_Monitoring.Address_2);
                dbHelper.AddInParameter(cmd, "@City", DbType.String, Objerty_Monitoring.City);
                dbHelper.AddInParameter(cmd, "@FK_State", DbType.Decimal, Objerty_Monitoring.FK_State);
                dbHelper.AddInParameter(cmd, "@Zip_Code", DbType.String, Objerty_Monitoring.Zip_Code);
                dbHelper.AddInParameter(cmd, "@Telephone_Number", DbType.String, Objerty_Monitoring.Telephone_Number);
                dbHelper.AddInParameter(cmd, "@E_Mail", DbType.String, Objerty_Monitoring.E_Mail);
                dbHelper.AddInParameter(cmd, "@Alternate_Telephone_Number", DbType.String, Objerty_Monitoring.Alternate_Telephone_Number);
                dbHelper.AddInParameter(cmd, "@Comments", DbType.String, Objerty_Monitoring.Comments);
                dbHelper.AddInParameter(cmd, "@Updated_By", DbType.Decimal, Objerty_Monitoring.Updated_By);
                dbHelper.AddInParameter(cmd, "@Update_Date", DbType.DateTime, Objerty_Monitoring.Update_Date);
                dbHelper.ExecuteNonQuery(cmd);
                nRetVal = int.Parse(dbHelper.GetParameterValue(cmd, "@PK_Property_Monitoring").ToString());
                return nRetVal;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            { dbHelper = null; cmd.Dispose(); cmd = null; }
        }
        public override int PropMonitoring_Delete(System.String lPK_Property_Monitoring)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            int nRetVal = -1;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("PropMonitoring_Delete");
                dbHelper.AddInParameter(cmd, "@PK_Property_Monitoring", DbType.Decimal, lPK_Property_Monitoring);
                nRetVal = dbHelper.ExecuteNonQuery(cmd);
                dbHelper = null; cmd.Dispose(); cmd = null;
                return nRetVal;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public override DataSet GetAll( )
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            DataSet dsCommon = new DataSet();
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("PropMonitoring_GetAll");
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


        public override DataSet PropMonitoring_GetByID(System.Decimal pK_Property_Monitoring)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            DataSet dsCommon = new DataSet();
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("PropMonitoring_GetAll");
                dbHelper.AddInParameter(cmd, "@PK_Property_Monitoring", DbType.Decimal, pK_Property_Monitoring);

                dsCommon = dbHelper.ExecuteDataSet(cmd);
                cmd = null;
                dbHelper = null;

                return dsCommon; ;
            }
            catch (Exception)
            {
                throw;
            }
        }


    }


}

