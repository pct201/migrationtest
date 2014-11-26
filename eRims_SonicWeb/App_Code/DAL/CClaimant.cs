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


    public class CClaimant : RIMS_Base.CClaimant
    {

        public override int InsertUpdateClaimant(RIMS_Base.CClaimant Objmant)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            int nRetVal = 0;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Claimant_InsertUpdate");
                dbHelper.AddParameter(cmd, "@PK_Claimant_Id", DbType.Int32, ParameterDirection.InputOutput, "PK_Claimant_Id", DataRowVersion.Current, Objmant.PK_Claimant_Id);
                dbHelper.AddInParameter(cmd, "@Claimant_Id", DbType.String, Objmant.Claimant_Id);
                dbHelper.AddInParameter(cmd, "@Last_Name", DbType.String, Objmant.Last_Name);
                dbHelper.AddInParameter(cmd, "@First_Name", DbType.String, Objmant.First_Name);
                dbHelper.AddInParameter(cmd, "@Middle_Name", DbType.String, Objmant.Middle_Name);
                dbHelper.AddInParameter(cmd, "@Claimant_Address_1", DbType.String, Objmant.Claimant_Address_1);
                dbHelper.AddInParameter(cmd, "@Claimant_Address_2", DbType.String, Objmant.Claimant_Address_2);
                dbHelper.AddInParameter(cmd, "@Claimant_City", DbType.String, Objmant.Claimant_City);
                dbHelper.AddInParameter(cmd, "@Claimant_State", DbType.String, Objmant.Claimant_State);
                dbHelper.AddInParameter(cmd, "@Claimant_Zip_Code", DbType.String, Objmant.Claimant_Zip_Code);
                dbHelper.AddInParameter(cmd, "@Claimant_Home_Phone", DbType.String, Objmant.Claimant_Home_Phone);
                dbHelper.AddInParameter(cmd, "@Claimant_Cell_Phone", DbType.String, Objmant.Claimant_Cell_Phone);
                dbHelper.AddInParameter(cmd, "@Social_Security_Number", DbType.String, Objmant.Social_Security_Number);
                dbHelper.AddInParameter(cmd, "@FK_Cost_Center", DbType.Decimal, Objmant.FK_Cost_Center);
                dbHelper.AddInParameter(cmd, "@Updated_By", DbType.String, Objmant.Updated_By);
                dbHelper.AddInParameter(cmd, "@Update_Date", DbType.DateTime, Objmant.Update_Date);
                dbHelper.AddInParameter(cmd, "@Date_Of_Birth", DbType.DateTime, Objmant.Date_Of_Birth);
                dbHelper.AddInParameter(cmd, "@Drivers_License_State", DbType.String, Objmant.Drivers_License_State);
                dbHelper.AddInParameter(cmd, "@Drivers_License_Number", DbType.String, Objmant.Drivers_License_Number);
                dbHelper.ExecuteNonQuery(cmd);
                nRetVal = int.Parse(dbHelper.GetParameterValue(cmd, "@PK_Claimant_Id").ToString());
                
                return nRetVal;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            { dbHelper = null; cmd.Dispose(); cmd = null; }
        }
        public override int DeleteClaimant(System.String lPK_Claimant_Id)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            int nRetVal = -1;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Claimant_Delete");
                dbHelper.AddInParameter(cmd, "@PK_Claimant_Id", DbType.Decimal, lPK_Claimant_Id);
                nRetVal = dbHelper.ExecuteNonQuery(cmd);
                dbHelper = null; cmd.Dispose(); cmd = null;
                return nRetVal;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public override string ActivateInactivateClaimant(string strIDs, int intModifiedBy, bool bIsActive)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            int nRetVal = -1;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Cla_ActivateInactivatemants");
                dbHelper.AddParameter(cmd, "@PK_Claimant_Ids", DbType.String, ParameterDirection.InputOutput, "PK_Claimant_Ids", DataRowVersion.Current, strIDs);
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
        public override List<RIMS_Base.CClaimant> GetAll()
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Claimant_Select");
               
                IDataReader reader = dbHelper.ExecuteReader(cmd);
                List<RIMS_Base.CClaimant> results = new List<RIMS_Base.CClaimant>();
                while (reader.Read())
                {
                    CClaimant objmant = new CClaimant();
                    objmant = MapFrom(reader);
                    results.Add(objmant);
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
        public override List<RIMS_Base.CClaimant> GetClaimantByID(System.Decimal pK_Claimant_Id)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Claimant_Select");
                dbHelper.AddInParameter(cmd, "@PK_Claimant_Id", DbType.Decimal, pK_Claimant_Id);
                List<RIMS_Base.CClaimant> results = new List<RIMS_Base.CClaimant>();
                IDataReader reader = dbHelper.ExecuteReader(cmd);
                CClaimant objmant = new CClaimant();
                if (reader.Read())
                {
                    objmant = MapFrom(reader);
                    results.Add(objmant);
                }
                reader.Close();
                cmd = null;
                dbHelper = null;
                return results;
                //return objmant;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public override List<RIMS_Base.CClaimant> Get_Search_Data(System.String m_strColumn, System.String m_strCriteria)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Claimant_Search_Data");
                dbHelper.AddInParameter(cmd, "@ColumnName", DbType.String, m_strColumn.Replace("'","''"));
                dbHelper.AddInParameter(cmd, "@Criteria", DbType.String, m_strCriteria.Replace("'", "''"));

                List<RIMS_Base.CClaimant> results = new List<RIMS_Base.CClaimant>();
                IDataReader reader = dbHelper.ExecuteReader(cmd);
                CClaimant obj_Details = new CClaimant();
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
        public override List<RIMS_Base.CClaimant> Get_AdvanceSearch_Data(string LastName, string FirstName, string Address, string City, string State, string Zipcode)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Claimant_AdvanceSearch_Data");
                dbHelper.AddInParameter(cmd, "@LastName", DbType.String, LastName.Replace("'", "''"));
                dbHelper.AddInParameter(cmd, "@FirstName", DbType.String, FirstName.Replace("'", "''"));
                dbHelper.AddInParameter(cmd, "@Address", DbType.String, Address.Replace("'", "''"));
                dbHelper.AddInParameter(cmd, "@City", DbType.String, City.Replace("'", "''"));
                dbHelper.AddInParameter(cmd, "@State", DbType.String, State.Replace("'", "''"));
                dbHelper.AddInParameter(cmd, "@Zipcode", DbType.String, Zipcode.Replace("'", "''"));
                List<RIMS_Base.CClaimant> results = new List<RIMS_Base.CClaimant>();
                IDataReader reader = dbHelper.ExecuteReader(cmd);
                CClaimant obj_Details = new CClaimant();
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
        protected RIMS_Base.Dal.CClaimant MapFrom(IDataReader reader)
        {
            RIMS_Base.Dal.CClaimant objmant = new RIMS_Base.Dal.CClaimant();
            if (!Convert.IsDBNull(reader["PK_Claimant_Id"])) { objmant.PK_Claimant_Id = Convert.ToInt32(reader["PK_Claimant_Id"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Claimant_Id"])) { objmant.Claimant_Id = Convert.ToString(reader["Claimant_Id"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Last_Name"])) { objmant.Last_Name = Convert.ToString(reader["Last_Name"], CultureInfo.InvariantCulture).Replace("''", "'"); }
            if (!Convert.IsDBNull(reader["First_Name"])) { objmant.First_Name = Convert.ToString(reader["First_Name"], CultureInfo.InvariantCulture).Replace("''", "'"); }
            if (!Convert.IsDBNull(reader["Middle_Name"])) { objmant.Middle_Name = Convert.ToString(reader["Middle_Name"], CultureInfo.InvariantCulture).Replace("''", "'"); }
            if (!Convert.IsDBNull(reader["Claimant_Address_1"])) { objmant.Claimant_Address_1 = Convert.ToString(reader["Claimant_Address_1"], CultureInfo.InvariantCulture).Replace("''", "'"); }
            if (!Convert.IsDBNull(reader["Claimant_Address_2"])) { objmant.Claimant_Address_2 = Convert.ToString(reader["Claimant_Address_2"], CultureInfo.InvariantCulture).Replace("''", "'"); }
            if (!Convert.IsDBNull(reader["Claimant_City"])) { objmant.Claimant_City = Convert.ToString(reader["Claimant_City"], CultureInfo.InvariantCulture).Replace("''", "'"); }
            if (!Convert.IsDBNull(reader["Claimant_State"])) { objmant.Claimant_State = Convert.ToString(reader["Claimant_State"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Claimant_Zip_Code"])) { objmant.Claimant_Zip_Code = Convert.ToString(reader["Claimant_Zip_Code"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Claimant_Home_Phone"])) { objmant.Claimant_Home_Phone = Convert.ToString(reader["Claimant_Home_Phone"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Claimant_Cell_Phone"])) { objmant.Claimant_Cell_Phone = Convert.ToString(reader["Claimant_Cell_Phone"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Social_Security_Number"])) { objmant.Social_Security_Number = Convert.ToString(reader["Social_Security_Number"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FK_Cost_Center"])) { objmant.FK_Cost_Center = Convert.ToDecimal(reader["FK_Cost_Center"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Updated_By"])) { objmant.Updated_By = Convert.ToString(reader["Updated_By"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Update_Date"])) { objmant.Update_Date = Convert.ToDateTime(reader["Update_Date"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Date_Of_Birth"])) { objmant.Date_Of_Birth = Convert.ToDateTime(reader["Date_Of_Birth"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Drivers_License_State"])) { objmant.Drivers_License_State = Convert.ToString(reader["Drivers_License_State"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Drivers_License_Number"])) { objmant.Drivers_License_Number = Convert.ToString(reader["Drivers_License_Number"], CultureInfo.InvariantCulture); }
            return objmant;
        }

        public override List<RIMS_Base.CClaimant> GetClaimantAutopopulate()
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Select_ClaimantID");
              
                IDataReader reader = dbHelper.ExecuteReader(cmd);
                List<RIMS_Base.CClaimant> results = new List<RIMS_Base.CClaimant>();
               
                if (reader.Read())
                {
                    CClaimant objmant = new CClaimant();
                    objmant = MapFromAuto(reader);
                    results.Add(objmant);
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


        protected RIMS_Base.Dal.CClaimant MapFromAuto(IDataReader reader)
        {
            RIMS_Base.Dal.CClaimant objmant = new RIMS_Base.Dal.CClaimant();
            if (!Convert.IsDBNull(reader["Claimant_Id"])) { objmant.Claimant_Id = Convert.ToString(reader["Claimant_Id"], CultureInfo.InvariantCulture); }
            return objmant;
        }

    }


}

