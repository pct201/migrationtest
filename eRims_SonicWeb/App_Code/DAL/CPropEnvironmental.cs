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


    public class CPropEnvironmental : RIMS_Base.CPropEnvironmental
    {

        public override int PropEnvironmental_InsertUpdate(RIMS_Base.CPropEnvironmental Objerty_Environmental)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            int nRetVal = 0;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("PropEnvironmental_InsertUpdate");
                dbHelper.AddParameter(cmd, "@PK_Property_Environmental", DbType.Decimal, ParameterDirection.InputOutput, "PK_Property_Environmental", DataRowVersion.Current, Objerty_Environmental.PK_Property_Environmental);
                dbHelper.AddInParameter(cmd, "@FK_Property_COPE", DbType.Decimal, Objerty_Environmental.FK_Property_COPE);
                dbHelper.AddInParameter(cmd, "@Air", DbType.String, Objerty_Environmental.Air);
                dbHelper.AddInParameter(cmd, "@Water", DbType.String, Objerty_Environmental.Water);
                dbHelper.AddInParameter(cmd, "@Waste", DbType.String, Objerty_Environmental.Waste);
                dbHelper.AddInParameter(cmd, "@FINDS", DbType.String, Objerty_Environmental.FINDS);
                dbHelper.AddInParameter(cmd, "@Updated_By", DbType.Decimal, Objerty_Environmental.Updated_By);
                dbHelper.AddInParameter(cmd, "@Update_Date", DbType.DateTime, Objerty_Environmental.Update_Date);
                dbHelper.ExecuteNonQuery(cmd);
                nRetVal = int.Parse(dbHelper.GetParameterValue(cmd, "@PK_Property_Environmental").ToString());
                
                return nRetVal;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            { dbHelper = null; cmd.Dispose(); cmd = null; }
        }
       
        public override DataSet GetAll( )
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            DataSet dsCommon = new DataSet();
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("PropEnvironmental_GetAll");
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


        public override DataSet PropEnvironmental_GetByID(System.Decimal pK_Property_Environmental)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            DataSet dsCommon = new DataSet();
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("PropEnvironmental_GetAll");
                dbHelper.AddInParameter(cmd, "@PK_Property_Environmental", DbType.Decimal, pK_Property_Environmental);
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

