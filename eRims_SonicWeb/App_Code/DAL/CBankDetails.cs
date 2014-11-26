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


    public class CBankDetails : RIMS_Base.CBankDetails
    {

        public override int InsertUpdate_Details(RIMS_Base.CBankDetails Obj_Details)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            int nRetVal = -1;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Ban_InsertUpdate_Details");
                dbHelper.AddInParameter(cmd, "@PK_Bank_Details_ID", DbType.Decimal, Obj_Details.PK_Bank_Details_ID);
                dbHelper.AddInParameter(cmd, "@Fld_Bank_Name", DbType.String, Obj_Details.Fld_Bank_Name);
                dbHelper.AddInParameter(cmd, "@Fld_Address_1", DbType.String, Obj_Details.Fld_Address_1);
                dbHelper.AddInParameter(cmd, "@Fld_Address_2", DbType.String, Obj_Details.Fld_Address_2);
                dbHelper.AddInParameter(cmd, "@Fld_City", DbType.String, Obj_Details.Fld_City);
                dbHelper.AddInParameter(cmd, "@Fld_State", DbType.String, Obj_Details.Fld_State);
                dbHelper.AddInParameter(cmd, "@Fld_Zip", DbType.String, Obj_Details.Fld_Zip);
                dbHelper.AddInParameter(cmd, "@Fld_AccountNo", DbType.String, Obj_Details.Fld_AccountNo);
                dbHelper.AddInParameter(cmd, "@Fld_RoutingNo", DbType.String, Obj_Details.Fld_RoutingNo);
                dbHelper.AddInParameter(cmd, "@Fld_Bank_State", DbType.String, Obj_Details.Fld_Bank_State);
                dbHelper.AddInParameter(cmd, "@Fld_Bank_No1", DbType.String, Obj_Details.Fld_Bank_No1);
                dbHelper.AddInParameter(cmd, "@Fld_Bank_No2", DbType.String, Obj_Details.Fld_Bank_No2);
                dbHelper.AddInParameter(cmd, "@Updated_By", DbType.String, Obj_Details.Updated_By);
                dbHelper.AddInParameter(cmd, "@Update_Date", DbType.DateTime, Obj_Details.Update_Date);
                dbHelper.ExecuteNonQuery(cmd);
                nRetVal = int.Parse(dbHelper.GetParameterValue(cmd, "@PK_Bank_Details_ID").ToString());
                //dbHelper = null; cmd.Dispose(); cmd = null;
                return nRetVal;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            { dbHelper = null; cmd.Dispose(); cmd = null; }
        }
        public override int Delete_Details(System.String lPK_Bank_Details_ID)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            int nRetVal = -1;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Ban_Delete_Details");
                dbHelper.AddInParameter(cmd, "@PK_Bank_Details_ID", DbType.String, lPK_Bank_Details_ID);
                nRetVal = dbHelper.ExecuteNonQuery(cmd);
                dbHelper = null; cmd.Dispose(); cmd = null;
                return nRetVal;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public override string ActivateInactivate_Details(string strIDs, int intModifiedBy, bool bIsActive)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            int nRetVal = -1;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Ban_ActivateInactivate_Detailss");
                dbHelper.AddParameter(cmd, "@PK_Bank_Details_IDs", DbType.String, ParameterDirection.InputOutput, "PK_Bank_Details_IDs", DataRowVersion.Current, strIDs);
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
        public override List<RIMS_Base.CBankDetails> GetAll()
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Ban_Select_Details");
                IDataReader reader = dbHelper.ExecuteReader(cmd);
                List<RIMS_Base.CBankDetails> results = new List<RIMS_Base.CBankDetails>();
                while (reader.Read())
                {
                    CBankDetails obj_Details = new CBankDetails();
                    obj_Details = MapFrom(reader);
                    results.Add(obj_Details);
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


        public override List<RIMS_Base.CBankDetails> Get_DetailsByID(System.Decimal pK_Bank_Details_ID)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Ban_Select_Details");
                dbHelper.AddInParameter(cmd, "@PK_Bank_Details_ID", DbType.Decimal, pK_Bank_Details_ID);
                List<RIMS_Base.CBankDetails> results = new List<RIMS_Base.CBankDetails>();
                IDataReader reader = dbHelper.ExecuteReader(cmd);
                CBankDetails obj_Details = new CBankDetails();
                if(reader.Read())
                {
                    obj_Details = MapFrom(reader);
                    results.Add(obj_Details);
                }
                reader.Close();
                cmd = null;
                dbHelper = null;
                //return obj_Details;
                return results;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public override List<RIMS_Base.CBankDetails> Get_Search_Data(System.String m_strColumn, System.String m_strCriteria)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Ban_Search_Data");
                dbHelper.AddInParameter(cmd, "@ColumnName", DbType.String, m_strColumn.Replace("'", "''"));
                dbHelper.AddInParameter(cmd, "@Criteria", DbType.String, m_strCriteria.Replace("'", "''"));
                
                List<RIMS_Base.CBankDetails> results = new List<RIMS_Base.CBankDetails>();
                IDataReader reader = dbHelper.ExecuteReader(cmd);
                CBankDetails obj_Details = new CBankDetails();
                while (reader.Read())
                {
                    obj_Details = MapFrom(reader);
                    results.Add(obj_Details);
                }
                reader.Close();
                cmd = null;
                dbHelper = null;
                //return obj_Details;
                return results;
            }
            catch (Exception)
            {
                throw;
            }
        }
        protected RIMS_Base.Dal.CBankDetails MapFrom(IDataReader reader)
        {
            RIMS_Base.Dal.CBankDetails obj_Details = new RIMS_Base.Dal.CBankDetails();
            if (!Convert.IsDBNull(reader["PK_Bank_Details_ID"])) { obj_Details.PK_Bank_Details_ID = Convert.ToDecimal(reader["PK_Bank_Details_ID"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Fld_Bank_Name"])) { obj_Details.Fld_Bank_Name = Convert.ToString(reader["Fld_Bank_Name"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Fld_Address_1"])) { obj_Details.Fld_Address_1 = Convert.ToString(reader["Fld_Address_1"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Fld_Address_2"])) { obj_Details.Fld_Address_2 = Convert.ToString(reader["Fld_Address_2"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Fld_City"])) { obj_Details.Fld_City = Convert.ToString(reader["Fld_City"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Fld_State"])) { obj_Details.Fld_State = Convert.ToString(reader["Fld_State"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Fld_Zip"])) { obj_Details.Fld_Zip = Convert.ToString(reader["Fld_Zip"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Fld_AccountNo"])) { obj_Details.Fld_AccountNo = Convert.ToString(reader["Fld_AccountNo"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Fld_RoutingNo"])) { obj_Details.Fld_RoutingNo = Convert.ToString(reader["Fld_RoutingNo"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Fld_Bank_State"])) { obj_Details.Fld_Bank_State = Convert.ToString(reader["Fld_Bank_State"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Fld_Bank_No1"])) { obj_Details.Fld_Bank_No1 = Convert.ToString(reader["Fld_Bank_No1"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Fld_Bank_No2"])) { obj_Details.Fld_Bank_No2 = Convert.ToString(reader["Fld_Bank_No2"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Updated_By"])) { obj_Details.Updated_By = Convert.ToString(reader["Updated_By"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Update_Date"])) { obj_Details.Update_Date = Convert.ToDateTime(reader["Update_Date"], CultureInfo.InvariantCulture); }
            return obj_Details;
        }

        


    }


}

