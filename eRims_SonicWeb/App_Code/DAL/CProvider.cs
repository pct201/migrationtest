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


    public class CProvider : RIMS_Base.CProvider
    {

        public override int Provider_InsertUpdate(RIMS_Base.CProvider Objider)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            int nRetVal = 0;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Provider_InsertUpdate");
                dbHelper.AddParameter(cmd, "@PK_Provider_ID", DbType.Int32, ParameterDirection.InputOutput, "PK_Provider_ID", DataRowVersion.Current, Objider.PK_Provider_ID);
                dbHelper.AddInParameter(cmd, "@Name", DbType.String, Objider.Name);
                dbHelper.AddInParameter(cmd, "@Tax_Id", DbType.String, Objider.Tax_Id);
                dbHelper.AddInParameter(cmd, "@Address_1", DbType.String, Objider.Address_1);
                dbHelper.AddInParameter(cmd, "@Address_2", DbType.String, Objider.Address_2);
                dbHelper.AddInParameter(cmd, "@City", DbType.String, Objider.City);
                dbHelper.AddInParameter(cmd, "@State", DbType.String, Objider.State);
                dbHelper.AddInParameter(cmd, "@Zip_Code", DbType.String, Objider.Zip_Code);
                dbHelper.AddInParameter(cmd, "@Phone", DbType.String, Objider.Phone);
                dbHelper.AddInParameter(cmd, "@Facsimile", DbType.String, Objider.Facsimile);
                dbHelper.AddInParameter(cmd, "@Updated_By", DbType.String, Objider.Updated_By);
                dbHelper.AddInParameter(cmd, "@Update_Date", DbType.DateTime, Objider.Update_Date);
                dbHelper.ExecuteNonQuery(cmd);
                nRetVal = int.Parse(dbHelper.GetParameterValue(cmd, "@PK_Provider_ID").ToString());
                return nRetVal;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            { dbHelper = null; cmd.Dispose(); cmd = null; }
        }
        public override int Provider_Delete(System.String lPK_Provider_ID)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            int nRetVal = -1;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Provider_Delete");
                dbHelper.AddInParameter(cmd, "@PK_Provider_ID", DbType.String, lPK_Provider_ID);
                nRetVal = dbHelper.ExecuteNonQuery(cmd);
                dbHelper = null; cmd.Dispose(); cmd = null;
                return nRetVal;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public override string ActivateInactivateider(string strIDs, int intModifiedBy, bool bIsActive)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            int nRetVal = -1;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Pro_ActivateInactivateiders");
                dbHelper.AddParameter(cmd, "@PK_Provider_IDs", DbType.String, ParameterDirection.InputOutput, "PK_Provider_IDs", DataRowVersion.Current, strIDs);
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
        public override List<RIMS_Base.CProvider> GetAll()
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("ProviderMain_Select");
                IDataReader reader = dbHelper.ExecuteReader(cmd);
                List<RIMS_Base.CProvider> results = new List<RIMS_Base.CProvider>();
                while (reader.Read())
                {
                    CProvider objider = new CProvider();
                    objider = MapFrom(reader);
                    results.Add(objider);
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


        public override List<RIMS_Base.CProvider> Provider_GetByID(System.Decimal pK_Provider_ID)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("ProviderMain_Select");
                dbHelper.AddInParameter(cmd, "@PK_Provider_ID", DbType.Decimal, pK_Provider_ID);
                List<RIMS_Base.CProvider> results = new List<RIMS_Base.CProvider>();
                IDataReader reader = dbHelper.ExecuteReader(cmd);
                CProvider objider = new CProvider();
                if (reader.Read())
                {
                    objider = MapFrom(reader);
                    results.Add(objider);
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

        public override List<RIMS_Base.CProvider> Get_Search_Data(System.String m_strColumn, System.String m_strCriteria)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Provider_Search_Data");
                dbHelper.AddInParameter(cmd, "@ColumnName", DbType.String, m_strColumn.Replace("'", "''")); ;
                dbHelper.AddInParameter(cmd, "@Criteria", DbType.String, m_strCriteria.Replace("'", "''"));
                List<RIMS_Base.CProvider> results = new List<RIMS_Base.CProvider>();
                IDataReader reader = dbHelper.ExecuteReader(cmd);
                CProvider objoyee = new CProvider();
                while (reader.Read())
                {
                    objoyee = MapFrom(reader);
                    results.Add(objoyee);
                }
                reader.Close();
                cmd = null;
                dbHelper = null;
                return results;
                //return objoyee;
            }
            catch (Exception)
            {
                throw;
            }
        }
        protected RIMS_Base.Dal.CProvider MapFrom(IDataReader reader)
        {
            RIMS_Base.Dal.CProvider objider = new RIMS_Base.Dal.CProvider();
            if (!Convert.IsDBNull(reader["PK_Provider_ID"])) { objider.PK_Provider_ID = Convert.ToInt32(reader["PK_Provider_ID"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Name"])) { objider.Name = Convert.ToString(reader["Name"], CultureInfo.InvariantCulture).Replace("''","'"); }
            if (!Convert.IsDBNull(reader["Tax_Id"])) { objider.Tax_Id = Convert.ToString(reader["Tax_Id"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Address_1"])) { objider.Address_1 = Convert.ToString(reader["Address_1"], CultureInfo.InvariantCulture).Replace("''", "'"); }
            if (!Convert.IsDBNull(reader["Address_2"])) { objider.Address_2 = Convert.ToString(reader["Address_2"], CultureInfo.InvariantCulture).Replace("''", "'"); }
            if (!Convert.IsDBNull(reader["City"])) { objider.City = Convert.ToString(reader["City"], CultureInfo.InvariantCulture).Replace("''", "'"); }
            if (!Convert.IsDBNull(reader["State"])) { objider.State = Convert.ToString(reader["State"], CultureInfo.InvariantCulture).Replace("''", "'"); }
            if (!Convert.IsDBNull(reader["Zip_Code"])) { objider.Zip_Code = Convert.ToString(reader["Zip_Code"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Phone"])) { objider.Phone = Convert.ToString(reader["Phone"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Facsimile"])) { objider.Facsimile = Convert.ToString(reader["Facsimile"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Updated_By"])) { objider.Updated_By = Convert.ToString(reader["Updated_By"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Update_Date"])) { objider.Update_Date = Convert.ToDateTime(reader["Update_Date"], CultureInfo.InvariantCulture); }
            return objider;
        }




    }


}

