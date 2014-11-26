using System;
using System.Data;
using System.Collections.Generic;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using Microsoft.Practices.EnterpriseLibrary.Common;
using System.Configuration;
using System.Globalization;
using System.Data.Common;


namespace RIMS_Base.Dal
{
    [Serializable]
    public class CPropertyDriver : RIMS_Base.CPropertyDriver
    {     
        public override List<RIMS_Base.CPropertyDriver> GetAll()
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("PropertyDriver_Select");
                IDataReader reader = dbHelper.ExecuteReader(cmd);
                List<RIMS_Base.CPropertyDriver> results = new List<RIMS_Base.CPropertyDriver>();
                while (reader.Read())
                {
                    CPropertyDriver objPropertyDriver = new CPropertyDriver();
                    objPropertyDriver = MapFrom(reader);
                    results.Add(objPropertyDriver);
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
        public override List<RIMS_Base.CPropertyDriver> GetPropertyDriverByID(decimal lPK_PropertyDriver_ID)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("PropertyDriver_Select");
                dbHelper.AddInParameter(cmd, "@PK_Property_Drivers", DbType.String, lPK_PropertyDriver_ID);
                IDataReader reader = dbHelper.ExecuteReader(cmd);
                List<RIMS_Base.CPropertyDriver> results = new List<RIMS_Base.CPropertyDriver>();
                while (reader.Read())
                {
                    CPropertyDriver objPropertyDriver = new CPropertyDriver();
                    objPropertyDriver = MapFrom(reader);
                    results.Add(objPropertyDriver);
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
        public override List<RIMS_Base.CPropertyDriver> Get_Search_Data(string m_strColumn, string m_strCriteria)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("PropertyDriver_Search_Data");
                dbHelper.AddInParameter(cmd, "@ColumnName", DbType.String, m_strColumn.Replace("'", "''"));
                dbHelper.AddInParameter(cmd, "@Criteria", DbType.String, m_strCriteria.Replace("'", "''"));

                List<RIMS_Base.CPropertyDriver> results = new List<RIMS_Base.CPropertyDriver>();
                IDataReader reader = dbHelper.ExecuteReader(cmd);
                CPropertyDriver obj_Details = new CPropertyDriver();
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
        public override List<RIMS_Base.CPropertyDriver> Get_AdvanceSearch_Data(string LastName, string FirstName, string Address, string City, string State, string Zipcode)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("PropertyDriver_AdvanceSearch_Data");
                dbHelper.AddInParameter(cmd, "@LastName", DbType.String, LastName.Replace("'", "''"));
                dbHelper.AddInParameter(cmd, "@FirstName", DbType.String, FirstName.Replace("'", "''"));
                dbHelper.AddInParameter(cmd, "@Address", DbType.String, Address.Replace("'", "''"));
                dbHelper.AddInParameter(cmd, "@City", DbType.String, City.Replace("'", "''"));
                dbHelper.AddInParameter(cmd, "@State", DbType.String, State.Replace("'", "''"));
                dbHelper.AddInParameter(cmd, "@Zipcode", DbType.String, Zipcode.Replace("'", "''"));

                List<RIMS_Base.CPropertyDriver> results = new List<RIMS_Base.CPropertyDriver>();
                IDataReader reader = dbHelper.ExecuteReader(cmd);
                CPropertyDriver obj_Details = new CPropertyDriver();
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


        public override int PropertyDriver_Delete(System.String lPK_Property_Drivers)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            int nRetVal = -1;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Property_Driver_Delete");
                dbHelper.AddInParameter(cmd, "@PK_Property_Drivers", DbType.String, lPK_Property_Drivers);
                nRetVal = dbHelper.ExecuteNonQuery(cmd);
                dbHelper = null; cmd.Dispose(); cmd = null;
                return nRetVal;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public override int PropertyDriver_InsertUpdate(RIMS_Base.CPropertyDriver Objerty_Drivers)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            int nRetVal = 0;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("PropertyDriver_InsertUpdate");
                dbHelper.AddParameter(cmd, "@PK_Property_Drivers", DbType.Int32, ParameterDirection.InputOutput, "PK_Property_Drivers", DataRowVersion.Current, Objerty_Drivers.PK_Property_Drivers);
                dbHelper.AddInParameter(cmd, "@PK_Driver_Status", DbType.Decimal, Objerty_Drivers.PK_Driver_Status);
                dbHelper.AddInParameter(cmd, "@Status_As_Of", DbType.DateTime, Objerty_Drivers.Status_As_Of);
                dbHelper.AddInParameter(cmd, "@PK_Entity", DbType.Decimal, Objerty_Drivers.PK_Entity);
                dbHelper.AddInParameter(cmd, "@Last_Name", DbType.String, Objerty_Drivers.Last_Name);
                dbHelper.AddInParameter(cmd, "@First_Name", DbType.String, Objerty_Drivers.First_Name);
                dbHelper.AddInParameter(cmd, "@Middle_Name", DbType.String, Objerty_Drivers.Middle_Name);
                dbHelper.AddInParameter(cmd, "@Work_Telephone", DbType.String, Objerty_Drivers.Work_Telephone);
                dbHelper.AddInParameter(cmd, "@Management", DbType.String, Objerty_Drivers.Management);
                dbHelper.AddInParameter(cmd, "@Interstate", DbType.String, Objerty_Drivers.Interstate);
                dbHelper.AddInParameter(cmd, "@GVW", DbType.String, Objerty_Drivers.GVW);
                dbHelper.AddInParameter(cmd, "@Last_MVR", DbType.DateTime, Objerty_Drivers.Last_MVR);
                dbHelper.AddInParameter(cmd, "@Address_1", DbType.String, Objerty_Drivers.Address_1);
                dbHelper.AddInParameter(cmd, "@Address_2", DbType.String, Objerty_Drivers.Address_2);
                dbHelper.AddInParameter(cmd, "@City", DbType.String, Objerty_Drivers.City);
                dbHelper.AddInParameter(cmd, "@State", DbType.Decimal, Objerty_Drivers.State);
                dbHelper.AddInParameter(cmd, "@Zip_Code", DbType.String, Objerty_Drivers.Zip_Code);
                dbHelper.AddInParameter(cmd, "@Home_Telephone", DbType.String, Objerty_Drivers.Home_Telephone);
                dbHelper.AddInParameter(cmd, "@Cell_Phone", DbType.String, Objerty_Drivers.Cell_Phone);
                dbHelper.AddInParameter(cmd, "@Pager", DbType.String, Objerty_Drivers.Pager);
                dbHelper.AddInParameter(cmd, "@Email", DbType.String, Objerty_Drivers.Email);
                dbHelper.AddInParameter(cmd, "@Social_Security_Number", DbType.String, Objerty_Drivers.Social_Security_Number);
                dbHelper.AddInParameter(cmd, "@FK_Gender", DbType.Decimal, Objerty_Drivers.FK_Gender);
                dbHelper.AddInParameter(cmd, "@Date_Of_Birth", DbType.DateTime, Objerty_Drivers.Date_Of_Birth);
                dbHelper.AddInParameter(cmd, "@FK_DL_State", DbType.Decimal, Objerty_Drivers.FK_DL_State);
                dbHelper.AddInParameter(cmd, "@Drivers_License_Number", DbType.String, Objerty_Drivers.Drivers_License_Number);
                dbHelper.AddInParameter(cmd, "@FK_Drivers_License_Class", DbType.Decimal, Objerty_Drivers.FK_Drivers_License_Class);
                dbHelper.AddInParameter(cmd, "@Drivers_License_Class", DbType.String, Objerty_Drivers.Drivers_License_Class);
                dbHelper.AddInParameter(cmd, "@Restrictions", DbType.String, Objerty_Drivers.Restrictions);
                dbHelper.AddInParameter(cmd, "@Endorsements", DbType.String, Objerty_Drivers.Endorsements);
                dbHelper.AddInParameter(cmd, "@DL_Begin_Date", DbType.DateTime, Objerty_Drivers.DL_Begin_Date);
                dbHelper.AddInParameter(cmd, "@DL_End_Date", DbType.DateTime, Objerty_Drivers.DL_End_Date);
                dbHelper.AddInParameter(cmd, "@Supervisor_Last", DbType.String, Objerty_Drivers.Supervisor_Last);
                dbHelper.AddInParameter(cmd, "@Supervisor_First", DbType.String, Objerty_Drivers.Supervisor_First);
                dbHelper.AddInParameter(cmd, "@Supervisor_Title", DbType.String, Objerty_Drivers.Supervisor_Title);
                dbHelper.AddInParameter(cmd, "@Supervisor_Phone", DbType.String, Objerty_Drivers.Supervisor_Phone);
                dbHelper.AddInParameter(cmd, "@Notes", DbType.String, Objerty_Drivers.Notes);
                dbHelper.AddInParameter(cmd, "@Updated_By", DbType.String, Objerty_Drivers.Updated_By);
                dbHelper.AddInParameter(cmd, "@Update_Date", DbType.DateTime, Objerty_Drivers.Update_Date);





                dbHelper.ExecuteNonQuery(cmd);
                nRetVal = int.Parse(dbHelper.GetParameterValue(cmd, "@PK_Property_Drivers").ToString());
              
                return nRetVal;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            { dbHelper = null; cmd.Dispose(); cmd = null; }
        }       
        protected RIMS_Base.Dal.CPropertyDriver MapFrom(IDataReader reader)
        {
            RIMS_Base.Dal.CPropertyDriver objPropertyDriver = new RIMS_Base.Dal.CPropertyDriver();
            if (!Convert.IsDBNull(reader["PK_Property_Drivers"])) { objPropertyDriver.PK_Property_Drivers = Convert.ToInt32(reader["PK_Property_Drivers"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["PK_Driver_Status"])) { objPropertyDriver.PK_Driver_Status = Convert.ToInt32(reader["PK_Driver_Status"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Status_As_Of"])) { objPropertyDriver.Status_As_Of = Convert.ToDateTime(reader["Status_As_Of"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["PK_Entity"])) { objPropertyDriver.PK_Entity = Convert.ToInt32(reader["PK_Entity"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Last_Name"])) { objPropertyDriver.Last_Name = Convert.ToString(reader["Last_Name"], CultureInfo.InvariantCulture).Replace("''","'"); }
            if (!Convert.IsDBNull(reader["First_Name"])) { objPropertyDriver.First_Name = Convert.ToString(reader["First_Name"], CultureInfo.InvariantCulture).Replace("''", "'"); }
            if (!Convert.IsDBNull(reader["Middle_Name"])) { objPropertyDriver.Middle_Name = Convert.ToString(reader["Middle_Name"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Work_Telephone"])) { objPropertyDriver.Work_Telephone = Convert.ToString(reader["Work_Telephone"], CultureInfo.InvariantCulture).Replace("''", "'"); }
            if (!Convert.IsDBNull(reader["Management"])) { objPropertyDriver.Management = Convert.ToString(reader["Management"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Interstate"])) { objPropertyDriver.Interstate = Convert.ToString(reader["Interstate"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["GVW"])) { objPropertyDriver.GVW = Convert.ToString(reader["GVW"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Last_MVR"])) { objPropertyDriver.Last_MVR = Convert.ToDateTime(reader["Last_MVR"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Address_1"])) { objPropertyDriver.Address_1 = Convert.ToString(reader["Address_1"], CultureInfo.InvariantCulture).Replace("''", "'"); }
            if (!Convert.IsDBNull(reader["Address_2"])) { objPropertyDriver.Address_2 = Convert.ToString(reader["Address_2"], CultureInfo.InvariantCulture).Replace("''", "'"); }
            if (!Convert.IsDBNull(reader["City"])) { objPropertyDriver.City = Convert.ToString(reader["City"], CultureInfo.InvariantCulture).Replace("''", "'"); }
            if (!Convert.IsDBNull(reader["State"])) { objPropertyDriver.State = Convert.ToInt32(reader["State"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Zip_Code"])) { objPropertyDriver.Zip_Code = Convert.ToString(reader["Zip_Code"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Home_Telephone"])) { objPropertyDriver.Home_Telephone = Convert.ToString(reader["Home_Telephone"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Cell_Phone"])) { objPropertyDriver.Cell_Phone = Convert.ToString(reader["Cell_Phone"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Pager"])) { objPropertyDriver.Pager = Convert.ToString(reader["Pager"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Email"])) { objPropertyDriver.Email = Convert.ToString(reader["Email"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Social_Security_Number"])) { objPropertyDriver.Social_Security_Number = Convert.ToString(reader["Social_Security_Number"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FK_Gender"])) { objPropertyDriver.FK_Gender = Convert.ToInt32(reader["FK_Gender"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Date_Of_Birth"])) { objPropertyDriver.Date_Of_Birth = Convert.ToDateTime(reader["Date_Of_Birth"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FK_DL_State"])) { objPropertyDriver.FK_DL_State = Convert.ToInt32(reader["FK_DL_State"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Drivers_License_Number"])) { objPropertyDriver.Drivers_License_Number = Convert.ToString(reader["Drivers_License_Number"], CultureInfo.InvariantCulture).Replace("''", "'"); }
            if (!Convert.IsDBNull(reader["FK_Drivers_License_Class"])) { objPropertyDriver.FK_Drivers_License_Class = Convert.ToInt32(reader["FK_Drivers_License_Class"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Drivers_License_Class"])) { objPropertyDriver.Drivers_License_Class = Convert.ToString(reader["Drivers_License_Class"], CultureInfo.InvariantCulture).Replace("''", "'"); }
            if (!Convert.IsDBNull(reader["Restrictions"])) { objPropertyDriver.Restrictions = Convert.ToString(reader["Restrictions"], CultureInfo.InvariantCulture).Replace("''", "'"); }
            if (!Convert.IsDBNull(reader["Endorsements"])) { objPropertyDriver.Endorsements = Convert.ToString(reader["Endorsements"], CultureInfo.InvariantCulture).Replace("''", "'"); }
            if (!Convert.IsDBNull(reader["DL_Begin_Date"])) { objPropertyDriver.DL_Begin_Date = Convert.ToDateTime(reader["DL_Begin_Date"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["DL_End_Date"])) { objPropertyDriver.DL_End_Date = Convert.ToDateTime(reader["DL_End_Date"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Supervisor_Last"])) { objPropertyDriver.Supervisor_Last = Convert.ToString(reader["Supervisor_Last"], CultureInfo.InvariantCulture).Replace("''", "'"); }
            if (!Convert.IsDBNull(reader["Supervisor_First"])) { objPropertyDriver.Supervisor_First = Convert.ToString(reader["Supervisor_First"], CultureInfo.InvariantCulture).Replace("''", "'"); }
            if (!Convert.IsDBNull(reader["Supervisor_Title"])) { objPropertyDriver.Supervisor_Title = Convert.ToString(reader["Supervisor_Title"], CultureInfo.InvariantCulture).Replace("''", "'"); }
            if (!Convert.IsDBNull(reader["Supervisor_Phone"])) { objPropertyDriver.Supervisor_Phone = Convert.ToString(reader["Supervisor_Phone"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Notes"])) { objPropertyDriver.Notes = Convert.ToString(reader["Notes"], CultureInfo.InvariantCulture).Replace("''", "'"); }
            if (!Convert.IsDBNull(reader["Updated_By"])) { objPropertyDriver.Updated_By = Convert.ToString(reader["Updated_By"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Update_Date"])) { objPropertyDriver.Update_Date = Convert.ToDateTime(reader["Update_Date"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["StateName"])) { objPropertyDriver.StateName = Convert.ToString(reader["StateName"], CultureInfo.InvariantCulture); }

            if (!Convert.IsDBNull(reader["Gender"])) { objPropertyDriver.Gender = Convert.ToString(reader["Gender"], CultureInfo.InvariantCulture); }
           // if (!Convert.IsDBNull(reader["DriverClass"])) { objPropertyDriver.DriverClass = Convert.ToString(reader["DriverClass"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["License_Type"])) { objPropertyDriver.License_Type = Convert.ToString(reader["License_Type"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["DriverLicence"])) { objPropertyDriver.DriverLicence = Convert.ToString(reader["DriverLicence"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["DLStatus"])) { objPropertyDriver.DLStatus = Convert.ToString(reader["DLStatus"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["EntityDesc"])) { objPropertyDriver.EntityDesc = Convert.ToString(reader["EntityDesc"], CultureInfo.InvariantCulture).Replace("''", "'"); }
            return objPropertyDriver;

        }


    }
}
