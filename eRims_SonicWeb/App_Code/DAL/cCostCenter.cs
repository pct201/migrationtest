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


    public class  cCostCenter : RIMS_Base. cCostCenter
    {

        public override int InsertUpdate_Center(RIMS_Base. cCostCenter Obj_Center)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            int nRetVal = -1;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Cos_InsertUpdate_Center");
                dbHelper.AddParameter(cmd, "@PK_ID", DbType.Decimal, ParameterDirection.InputOutput, "PK_ID", DataRowVersion.Current, Obj_Center.PK_ID);
                dbHelper.AddInParameter(cmd, "@Cost_Center", DbType.String, Obj_Center.Cost_Center);
                dbHelper.AddInParameter(cmd, "@Subsidiary", DbType.String, Obj_Center.Subsidiary);
                dbHelper.AddInParameter(cmd, "@BCBS_Group_Number", DbType.String, Obj_Center.BCBS_Group_Number);
                dbHelper.AddInParameter(cmd, "@Division_Name", DbType.String, Obj_Center.Division_Name);
                dbHelper.AddInParameter(cmd, "@Address", DbType.String, Obj_Center.Address);
                dbHelper.AddInParameter(cmd, "@City", DbType.String, Obj_Center.City);
                dbHelper.AddInParameter(cmd, "@State", DbType.String, Obj_Center.State);
                dbHelper.AddInParameter(cmd, "@Zip", DbType.String, Obj_Center.Zip);
                dbHelper.AddInParameter(cmd, "@Occupancy", DbType.String, Obj_Center.Occupancy);
                dbHelper.AddInParameter(cmd, "@Number_of_Employees", DbType.Decimal, Obj_Center.Number_of_Employees);
                dbHelper.AddInParameter(cmd, "@Shifts", DbType.Decimal, Obj_Center.Shifts);
                dbHelper.AddInParameter(cmd, "@Employees_Per_Shift", DbType.Decimal, Obj_Center.Employees_Per_Shift);
                dbHelper.AddInParameter(cmd, "@FEIN", DbType.String, Obj_Center.FEIN);
                dbHelper.ExecuteNonQuery(cmd);
                nRetVal = int.Parse(dbHelper.GetParameterValue(cmd, "@PK_ID").ToString());
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
        public override int Delete_Center(System.Int32 lPK_ID)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            int nRetVal = -1;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Cos_Delete_Center");
                dbHelper.AddInParameter(cmd, "@PK_ID", DbType.Int32, lPK_ID);
                nRetVal = dbHelper.ExecuteNonQuery(cmd);
                dbHelper = null; cmd.Dispose(); cmd = null;
                return nRetVal;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public override string ActivateInactivate_Center(string strIDs, int intModifiedBy, bool bIsActive)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            int nRetVal = -1;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Cos_ActivateInactivate_Centers");
                dbHelper.AddParameter(cmd, "@PK_IDs", DbType.String, ParameterDirection.InputOutput, "PK_IDs", DataRowVersion.Current, strIDs);
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
        public override List<RIMS_Base. cCostCenter> GetAll()
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("CostCenter_Select");
                IDataReader reader = dbHelper.ExecuteReader(cmd);
                List<RIMS_Base. cCostCenter> results = new List<RIMS_Base. cCostCenter>();
                while (reader.Read())
                {
                     cCostCenter obj_Center = new  cCostCenter();
                    obj_Center = MapFrom(reader);
                    results.Add(obj_Center);
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


        public override List<RIMS_Base.cCostCenter> Get_Search_Data(System.String m_strColumn, System.String m_strCriteria)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("CostCenter_Search_Data");
                dbHelper.AddInParameter(cmd, "@ColumnName", DbType.String, m_strColumn.Replace("'","''"));
                dbHelper.AddInParameter(cmd, "@Criteria", DbType.String, m_strCriteria.Replace("'", "''"));
                List<RIMS_Base.cCostCenter> results = new List<RIMS_Base.cCostCenter>();
                IDataReader reader = dbHelper.ExecuteReader(cmd);
                 cCostCenter obj_Center = new  cCostCenter();
                while (reader.Read())
                {
                    obj_Center = MapFrom(reader);
                    results.Add(obj_Center);
                }
                reader.Close();
                cmd = null;
                dbHelper = null;

               // return obj_Center;
                return results;
            }
            catch (Exception)
            {
                throw;
            }
        }


        protected RIMS_Base.Dal. cCostCenter MapFrom(IDataReader reader)
        {
            RIMS_Base.Dal. cCostCenter obj_Center = new RIMS_Base.Dal. cCostCenter();
            if (!Convert.IsDBNull(reader["PK_ID"])) { obj_Center.PK_ID = Convert.ToInt32(reader["PK_ID"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Cost_Center"])) { obj_Center.Cost_Center = Convert.ToString(reader["Cost_Center"], CultureInfo.InvariantCulture); }
            //if (!Convert.IsDBNull(reader["Subsidiary"])) { obj_Center.Subsidiary = Convert.ToString(reader["Subsidiary"], CultureInfo.InvariantCulture); }
            //if (!Convert.IsDBNull(reader["BCBS_Group_Number"])) { obj_Center.BCBS_Group_Number = Convert.ToString(reader["BCBS_Group_Number"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Division_Name"])) { obj_Center.Division_Name = Convert.ToString(reader["Division_Name"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Address"])) { obj_Center.Address = Convert.ToString(reader["Address"], CultureInfo.InvariantCulture); }
            /*if (!Convert.IsDBNull(reader["City"])) { obj_Center.City = Convert.ToString(reader["City"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["State"])) { obj_Center.State = Convert.ToString(reader["State"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Zip"])) { obj_Center.Zip = Convert.ToString(reader["Zip"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Occupancy"])) { obj_Center.Occupancy = Convert.ToString(reader["Occupancy"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Number_of_Employees"])) { obj_Center.Number_of_Employees = Convert.ToDecimal(reader["Number_of_Employees"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Shifts"])) { obj_Center.Shifts = Convert.ToDecimal(reader["Shifts"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Employees_Per_Shift"])) { obj_Center.Employees_Per_Shift = Convert.ToDecimal(reader["Employees_Per_Shift"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FEIN"])) { obj_Center.FEIN = Convert.ToString(reader["FEIN"], CultureInfo.InvariantCulture); }
             * */
            return obj_Center;
        }




    }


}

