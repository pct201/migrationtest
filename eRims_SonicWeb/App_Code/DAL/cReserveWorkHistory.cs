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


    public class cReserveWorkHistory : RIMS_Base.cReserveWorkHistory
    {

        public override int InsertUpdate_History(RIMS_Base.cReserveWorkHistory objHistory)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            int nRetVal = -1;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("RW__InsertUpdateistory");
                dbHelper.AddParameter(cmd, "@PK_RW_History_ID", DbType.Decimal, ParameterDirection.InputOutput, "PK_RW_History_ID", DataRowVersion.Current, objHistory.PK_RW_History_ID);
                dbHelper.AddInParameter(cmd, "@Table_Name", DbType.String, objHistory.Table_Name);
                dbHelper.AddInParameter(cmd, "@FK_Table_Name", DbType.Decimal, objHistory.FK_Table_Name);
                dbHelper.AddInParameter(cmd, "@Transaction_Date", DbType.DateTime, objHistory.Transaction_Date);
                dbHelper.AddInParameter(cmd, "@Indemnity", DbType.Decimal, objHistory.Indemnity);
                dbHelper.AddInParameter(cmd, "@Medical", DbType.Decimal, objHistory.Medical);
                dbHelper.AddInParameter(cmd, "@Expenses", DbType.Decimal, objHistory.Expenses);
                dbHelper.AddInParameter(cmd, "@Total", DbType.Decimal, objHistory.Total);
                dbHelper.AddInParameter(cmd, "@Updated_By", DbType.String, objHistory.Updated_By);
                dbHelper.AddInParameter(cmd, "@Update_Date", DbType.DateTime, objHistory.Update_Date);
                dbHelper.AddInParameter(cmd, "@FK_Workers_Comp_RW_ID", DbType.Decimal, objHistory.FK_Workers_Comp_RW_ID);
                dbHelper.ExecuteNonQuery(cmd);
                nRetVal = int.Parse(dbHelper.GetParameterValue(cmd, "@PK_RW_History_ID").ToString());
                dbHelper = null; cmd.Dispose(); cmd = null;
                return nRetVal;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            { dbHelper = null; cmd.Dispose(); cmd = null; }
        }
        public override int Delete_History(System.Decimal lPK_RW_History_ID)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            int nRetVal = -1;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("RW__Deleteistory");
                dbHelper.AddInParameter(cmd, "@PK_RW_History_ID", DbType.Decimal, lPK_RW_History_ID);
                nRetVal = dbHelper.ExecuteNonQuery(cmd);
                dbHelper = null; cmd.Dispose(); cmd = null;
                return nRetVal;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public override string ActivateInactivate_History(string strIDs, int intModifiedBy, bool bIsActive)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            int nRetVal = -1;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("RW__ActivateInactivateistorys");
                dbHelper.AddParameter(cmd, "@PK_RW_History_IDs", DbType.String, ParameterDirection.InputOutput, "PK_RW_History_IDs", DataRowVersion.Current, strIDs);
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
        public override List<RIMS_Base.cReserveWorkHistory> GetAll(Boolean blnIsActive)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("RW__Selectistory");
                dbHelper.AddInParameter(cmd, "@IsActive", DbType.Boolean, blnIsActive);
                IDataReader reader = dbHelper.ExecuteReader(cmd);
                List<RIMS_Base.cReserveWorkHistory> results = new List<RIMS_Base.cReserveWorkHistory>();
                while (reader.Read())
                {
                    cReserveWorkHistory objHistory = new cReserveWorkHistory();
                    objHistory = MapFrom(reader);
                    results.Add(objHistory);
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


        public override RIMS_Base.cReserveWorkHistory GetistoryByID(System.Decimal pK_RW_History_ID)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("RW__Selectistory");
                dbHelper.AddInParameter(cmd, "@PK_RW_History_ID", DbType.Decimal, pK_RW_History_ID);

                IDataReader reader = dbHelper.ExecuteReader(cmd);
                cReserveWorkHistory objHistory = new cReserveWorkHistory();
                if (reader.Read())
                {
                    objHistory = MapFrom(reader);
                }
                reader.Close();
                cmd = null;
                dbHelper = null;

                return objHistory;
            }
            catch (Exception)
            {
                throw;
            }
        }


        protected RIMS_Base.Dal.cReserveWorkHistory MapFrom(IDataReader reader)
        {
            RIMS_Base.Dal.cReserveWorkHistory objHistory = new RIMS_Base.Dal.cReserveWorkHistory();
            if (!Convert.IsDBNull(reader["PK_RW_History_ID"])) { objHistory.PK_RW_History_ID = Convert.ToDecimal(reader["PK_RW_History_ID"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Table_Name"])) { objHistory.Table_Name = Convert.ToString(reader["Table_Name"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FK_Table_Name"])) { objHistory.FK_Table_Name = Convert.ToDecimal(reader["FK_Table_Name"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Transaction_Date"])) { objHistory.Transaction_Date = Convert.ToDateTime(reader["Transaction_Date"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Indemnity"])) { objHistory.Indemnity = Convert.ToDecimal(reader["Indemnity"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Medical"])) { objHistory.Medical = Convert.ToDecimal(reader["Medical"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Expenses"])) { objHistory.Expenses = Convert.ToDecimal(reader["Expenses"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Total"])) { objHistory.Total = Convert.ToDecimal(reader["Total"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Updated_By"])) { objHistory.Updated_By = Convert.ToString(reader["Updated_By"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Update_Date"])) { objHistory.Update_Date = Convert.ToDateTime(reader["Update_Date"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FK_Workers_Comp_RW_ID"])) { objHistory.FK_Workers_Comp_RW_ID = Convert.ToDecimal(reader["FK_Workers_Comp_RW_ID"], CultureInfo.InvariantCulture); }
            return objHistory;
        }




    }


}

