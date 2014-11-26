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
#endregion

namespace RIMS_Base.Dal
{
    [Serializable]


    public class CPropValues : RIMS_Base.CPropValues
    {

        public override int PropValues_InsertUpdate(RIMS_Base.CPropValues Objerty_Values)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            int nRetVal = 0;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("PropValues_InsertUpdate");
                dbHelper.AddParameter(cmd, "@PK_Property_Values", DbType.Decimal, ParameterDirection.InputOutput, "PK_Property_Values", DataRowVersion.Current, Objerty_Values.PK_Property_Values);
                dbHelper.AddInParameter(cmd, "@FK_Property_COPE", DbType.Decimal, Objerty_Values.FK_Property_COPE);
                dbHelper.AddInParameter(cmd, "@Property_Valuation", DbType.DateTime, Objerty_Values.Property_Valuation);
                dbHelper.AddInParameter(cmd, "@Building", DbType.Decimal, Objerty_Values.Building);
                dbHelper.AddInParameter(cmd, "@Mobile_Equipment", DbType.Decimal, Objerty_Values.Mobile_Equipment);
                dbHelper.AddInParameter(cmd, "@Contents", DbType.Decimal, Objerty_Values.Contents);
                dbHelper.AddInParameter(cmd, "@Inventory", DbType.Decimal, Objerty_Values.Inventory);
                dbHelper.AddInParameter(cmd, "@System_Equipment", DbType.Decimal, Objerty_Values.System_Equipment);
                dbHelper.AddInParameter(cmd, "@Transmission_Above_Ground", DbType.Decimal, Objerty_Values.Transmission_Above_Ground);
                dbHelper.AddInParameter(cmd, "@Transmission_Below_Ground", DbType.Decimal, Objerty_Values.Transmission_Below_Ground);
                dbHelper.AddInParameter(cmd, "@Transmission_Other", DbType.Decimal, Objerty_Values.Transmission_Other);
                dbHelper.AddInParameter(cmd, "@Towers", DbType.Decimal, Objerty_Values.Towers);
                dbHelper.AddInParameter(cmd, "@Other_Structures", DbType.Decimal, Objerty_Values.Other_Structures);
                dbHelper.AddInParameter(cmd, "@Other_Structures_Description", DbType.String, Objerty_Values.Other_Structures_Description);
                dbHelper.AddInParameter(cmd, "@Total", DbType.Decimal, Objerty_Values.Total);
                dbHelper.AddInParameter(cmd, "@Updated_By", DbType.Decimal, Objerty_Values.Updated_By);
                dbHelper.AddInParameter(cmd, "@Update_Date", DbType.DateTime, Objerty_Values.Update_Date);
                dbHelper.ExecuteNonQuery(cmd);
                nRetVal = int.Parse(dbHelper.GetParameterValue(cmd, "@PK_Property_Values").ToString());
                
                return nRetVal;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            { dbHelper = null; cmd.Dispose(); cmd = null; }
        }
        
        public override DataSet GetAll()
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            DataSet dsCommon = new DataSet();
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("PropValues_GetAll");
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


        public override DataSet PropValues_GetById(System.Decimal pK_Property_Values)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            DataSet dsCommon = new DataSet();
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("PropValues_GetAll");
                dbHelper.AddInParameter(cmd, "@PK_Property_Cope", DbType.Decimal, pK_Property_Values);
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

