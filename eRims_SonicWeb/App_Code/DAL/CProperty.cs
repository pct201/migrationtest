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


    public class CProperty : RIMS_Base.CProperty
    {

        public override int InsertUpdateProperty(RIMS_Base.CProperty Objerty)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            int nRetVal = -1;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Property_InsertUpdate");
                dbHelper.AddParameter(cmd, "@PK_Property_ID", DbType.Int32, ParameterDirection.InputOutput, "PK_Property_ID", DataRowVersion.Current, Objerty.PK_Property_ID);
                dbHelper.AddInParameter(cmd, "@Cost_Center", DbType.String, Objerty.Cost_Center);
                dbHelper.AddInParameter(cmd, "@Facility", DbType.String, Objerty.Facility);
                dbHelper.AddInParameter(cmd, "@Property_Description", DbType.String, Objerty.Property_Description);
                dbHelper.AddInParameter(cmd, "@Value", DbType.Decimal, Objerty.Value);
                dbHelper.AddInParameter(cmd, "@Valuation_Date", DbType.DateTime, Objerty.Valuation_Date);
                dbHelper.AddInParameter(cmd, "@Premium", DbType.Decimal, Objerty.Premium);
                dbHelper.AddInParameter(cmd, "@Coverage", DbType.Decimal, Objerty.Coverage);
                dbHelper.AddInParameter(cmd, "@Mobile_Type", DbType.String, Objerty.Mobile_Type);
                dbHelper.AddInParameter(cmd, "@Mobile_VIN", DbType.String, Objerty.Mobile_VIN);
                dbHelper.AddInParameter(cmd, "@Mobile_Make", DbType.String, Objerty.Mobile_Make);
                dbHelper.AddInParameter(cmd, "@Mobile_Model", DbType.String, Objerty.Mobile_Model);
                dbHelper.AddInParameter(cmd, "@Mobile_Year", DbType.Decimal, Objerty.Mobile_Year);
                dbHelper.AddInParameter(cmd, "@Mobile_Title", DbType.String, Objerty.Mobile_Title);
                dbHelper.AddInParameter(cmd, "@Stationary_Type", DbType.String, Objerty.Stationary_Type);
                dbHelper.AddInParameter(cmd, "@Stationary_Year", DbType.Decimal, Objerty.Stationary_Year);
                dbHelper.AddInParameter(cmd, "@Stationary_Address_1", DbType.String, Objerty.Stationary_Address_1);
                dbHelper.AddInParameter(cmd, "@Stationary_Address_2", DbType.String, Objerty.Stationary_Address_2);
                dbHelper.AddInParameter(cmd, "@Stationary_City", DbType.String, Objerty.Stationary_City);
                dbHelper.AddInParameter(cmd, "@Stationary_State", DbType.String, Objerty.Stationary_State);
                dbHelper.AddInParameter(cmd, "@Stationary_Zip", DbType.String, Objerty.Stationary_Zip);
                dbHelper.AddInParameter(cmd, "@Stationary_Category", DbType.String, Objerty.Stationary_Category);
                dbHelper.AddInParameter(cmd, "@Stationary_Title", DbType.String, Objerty.Stationary_Title);
                dbHelper.AddInParameter(cmd, "@Stationary_Deed", DbType.String, Objerty.Stationary_Deed);
                dbHelper.AddInParameter(cmd, "@Stationary_Safety", DbType.String, Objerty.Stationary_Safety);
                dbHelper.AddInParameter(cmd, "@Stationary_Security", DbType.String, Objerty.Stationary_Security);
                dbHelper.AddInParameter(cmd, "@Stationary_Flood_Zone", DbType.String, Objerty.Stationary_Flood_Zone);
                dbHelper.AddInParameter(cmd, "@Stationary_Foreclosure", DbType.String, Objerty.Stationary_Foreclosure);
                dbHelper.AddInParameter(cmd, "@Foreclosed", DbType.String, Objerty.Foreclosed);
                dbHelper.AddInParameter(cmd, "@Contact_Name", DbType.String, Objerty.Contact_Name);
                dbHelper.AddInParameter(cmd, "@Contact_Phone", DbType.String, Objerty.Contact_Phone);
                dbHelper.AddInParameter(cmd, "@Contact_Facsimile", DbType.String, Objerty.Contact_Facsimile);
                dbHelper.AddInParameter(cmd, "@Emergency_Police", DbType.String, Objerty.Emergency_Police);
                dbHelper.AddInParameter(cmd, "@Emergency_Fire", DbType.String, Objerty.Emergency_Fire);
                dbHelper.AddInParameter(cmd, "@Emergency_Sheriff", DbType.String, Objerty.Emergency_Sheriff);
                dbHelper.AddInParameter(cmd, "@Emergency_State_Police", DbType.String, Objerty.Emergency_State_Police);
                dbHelper.AddInParameter(cmd, "@Emergency_Ambulance", DbType.String, Objerty.Emergency_Ambulance);
                dbHelper.AddInParameter(cmd, "@Emergency_FBI", DbType.String, Objerty.Emergency_FBI);
                dbHelper.AddInParameter(cmd, "@Emergency_Secret_Service", DbType.String, Objerty.Emergency_Secret_Service);
                dbHelper.AddInParameter(cmd, "@Phone_Company_Contact", DbType.String, Objerty.Phone_Company_Contact);
                dbHelper.AddInParameter(cmd, "@Phone_Company_Telephone", DbType.String, Objerty.Phone_Company_Telephone);
                dbHelper.AddInParameter(cmd, "@Power_Company_Contact", DbType.String, Objerty.Power_Company_Contact);
                dbHelper.AddInParameter(cmd, "@Power_Company_Telephone", DbType.String, Objerty.Power_Company_Telephone);
                dbHelper.AddInParameter(cmd, "@Water_Utility_Contact", DbType.String, Objerty.Water_Utility_Contact);
                dbHelper.AddInParameter(cmd, "@Water_Utility_Telephone", DbType.String, Objerty.Water_Utility_Telephone);
                dbHelper.AddInParameter(cmd, "@Gas_Utility_Contact", DbType.String, Objerty.Gas_Utility_Contact);
                dbHelper.AddInParameter(cmd, "@Gas_Utility_Telephone", DbType.String, Objerty.Gas_Utility_Telephone);
                dbHelper.AddInParameter(cmd, "@Cleaning_Company_Contact", DbType.String, Objerty.Cleaning_Company_Contact);
                dbHelper.AddInParameter(cmd, "@Cleaning_Company_Telephone", DbType.String, Objerty.Cleaning_Company_Telephone);
                dbHelper.AddInParameter(cmd, "@Cleaning_Company_Contract", DbType.String, Objerty.Cleaning_Company_Contract);
                dbHelper.AddInParameter(cmd, "@Cleaning_Company_Date", DbType.DateTime, Objerty.Cleaning_Company_Date);
                dbHelper.AddInParameter(cmd, "@Courier_Company_Contact", DbType.String, Objerty.Courier_Company_Contact);
                dbHelper.AddInParameter(cmd, "@Courier_Company_Telephone", DbType.String, Objerty.Courier_Company_Telephone);
                dbHelper.AddInParameter(cmd, "@Courier_Company_Contract", DbType.String, Objerty.Courier_Company_Contract);
                dbHelper.AddInParameter(cmd, "@Courier_Company_Date", DbType.DateTime, Objerty.Courier_Company_Date);
                dbHelper.AddInParameter(cmd, "@After_Hours_Contact", DbType.String, Objerty.After_Hours_Contact);
                dbHelper.AddInParameter(cmd, "@After_Hours_Phone", DbType.String, Objerty.After_Hours_Phone);
                dbHelper.AddInParameter(cmd, "@After_Hours_Cell", DbType.String, Objerty.After_Hours_Cell);
                dbHelper.AddInParameter(cmd, "@After_Hours_Pager", DbType.String, Objerty.After_Hours_Pager);
                dbHelper.AddInParameter(cmd, "@Contact_For_1", DbType.String, Objerty.Contact_For_1);
                dbHelper.AddInParameter(cmd, "@Special_Contact_1", DbType.String, Objerty.Special_Contact_1);
                dbHelper.AddInParameter(cmd, "@Special_Phone_1", DbType.String, Objerty.Special_Phone_1);
                dbHelper.AddInParameter(cmd, "@Special_Cell_1", DbType.String, Objerty.Special_Cell_1);
                dbHelper.AddInParameter(cmd, "@Special_Pager_1", DbType.String, Objerty.Special_Pager_1);
                dbHelper.AddInParameter(cmd, "@Contact_For_2", DbType.String, Objerty.Contact_For_2);
                dbHelper.AddInParameter(cmd, "@Special_Contact_2", DbType.String, Objerty.Special_Contact_2);
                dbHelper.AddInParameter(cmd, "@Special_Phone_2", DbType.String, Objerty.Special_Phone_2);
                dbHelper.AddInParameter(cmd, "@Special_Cell_2", DbType.String, Objerty.Special_Cell_2);
                dbHelper.AddInParameter(cmd, "@Special_Pager_2", DbType.String, Objerty.Special_Pager_2);
                dbHelper.AddInParameter(cmd, "@Contact_For_3", DbType.String, Objerty.Contact_For_3);
                dbHelper.AddInParameter(cmd, "@Special_Contact_3", DbType.String, Objerty.Special_Contact_3);
                dbHelper.AddInParameter(cmd, "@Special_Phone_3", DbType.String, Objerty.Special_Phone_3);
                dbHelper.AddInParameter(cmd, "@Special_Cell_3", DbType.String, Objerty.Special_Cell_3);
                dbHelper.AddInParameter(cmd, "@Special_Pager_3", DbType.String, Objerty.Special_Pager_3);
                dbHelper.AddInParameter(cmd, "@Open_Time", DbType.String, Objerty.Open_Time);
                dbHelper.AddInParameter(cmd, "@Close_Time", DbType.String, Objerty.Close_Time);
                dbHelper.AddInParameter(cmd, "@Number_Of_Employees", DbType.Decimal, Objerty.Number_Of_Employees);
                dbHelper.AddInParameter(cmd, "@ATM", DbType.String, Objerty.ATM);
                dbHelper.AddInParameter(cmd, "@ATM_Location", DbType.String, Objerty.ATM_Location);
                dbHelper.AddInParameter(cmd, "@Updated_By", DbType.String, Objerty.Updated_By);
                dbHelper.AddInParameter(cmd, "@Update_Date", DbType.DateTime, Objerty.Update_Date);
                dbHelper.AddInParameter(cmd, "@FK_Entity", DbType.Decimal, Objerty.FK_Entity);
                dbHelper.AddInParameter(cmd, "@Property_Name", DbType.String, Objerty.Property_Name);
                dbHelper.AddInParameter(cmd, "@FK_County", DbType.String, Objerty.FK_County);
                dbHelper.AddInParameter(cmd, "@County_Tier_1", DbType.String, Objerty.County_Tier_1);
                dbHelper.AddInParameter(cmd, "@County_Tri_County", DbType.String, Objerty.County_Tri_County);
                dbHelper.AddInParameter(cmd, "@FK_Land_Status", DbType.Decimal, Objerty.FK_Land_Status);
                dbHelper.AddInParameter(cmd, "@Acreage", DbType.Decimal, Objerty.Acreage);
                dbHelper.AddInParameter(cmd, "@Road_Frontage", DbType.Decimal, Objerty.Road_Frontage);
                dbHelper.AddInParameter(cmd, "@Road_Frontage_Units", DbType.String, Objerty.Road_Frontage_Units);
                dbHelper.AddInParameter(cmd, "@Occupancy", DbType.String, Objerty.Occupancy);
                dbHelper.AddInParameter(cmd, "@Flood_Zone", DbType.String, Objerty.Flood_Zone);
                dbHelper.AddInParameter(cmd, "@Number_Of_Employees1", DbType.Decimal, Objerty.Number_Of_Employees1);
                dbHelper.AddInParameter(cmd, "@Building", DbType.Decimal, Objerty.Building);
                dbHelper.AddInParameter(cmd, "@Signs", DbType.Decimal, Objerty.Signs);
                dbHelper.AddInParameter(cmd, "@Contents", DbType.Decimal, Objerty.Contents);
                dbHelper.AddInParameter(cmd, "@Computers", DbType.Decimal, Objerty.Computers);
                dbHelper.AddInParameter(cmd, "@ATMs", DbType.Decimal, Objerty.ATMs);
                dbHelper.AddInParameter(cmd, "@Lease_Improvements", DbType.Decimal, Objerty.Lease_Improvements);
                dbHelper.AddInParameter(cmd, "@Total", DbType.Decimal, Objerty.Total);
                dbHelper.AddInParameter(cmd, "@Gross_Sq_Feet", DbType.Decimal, Objerty.Gross_Sq_Feet);
                dbHelper.AddInParameter(cmd, "@Public_Acc_Sq_Feet", DbType.Decimal, Objerty.Public_Acc_Sq_Feet);
                dbHelper.AddInParameter(cmd, "@Stories_Up", DbType.Decimal, Objerty.Stories_Up);
                dbHelper.AddInParameter(cmd, "@Stories_Down", DbType.Decimal, Objerty.Stories_Down);
                dbHelper.AddInParameter(cmd, "@Construction_Cost", DbType.Decimal, Objerty.Construction_Cost);
                dbHelper.AddInParameter(cmd, "@Construction_Type", DbType.String, Objerty.Construction_Type);
                dbHelper.AddInParameter(cmd, "@Year_Built", DbType.Decimal, Objerty.Year_Built);
                dbHelper.AddInParameter(cmd, "@Purchase_Date", DbType.DateTime, Objerty.Purchase_Date);
                dbHelper.AddInParameter(cmd, "@Purchase_Price", DbType.Decimal, Objerty.Purchase_Price);
                dbHelper.AddInParameter(cmd, "@Sprinkler", DbType.Decimal, Objerty.Sprinkler);
                dbHelper.AddInParameter(cmd, "@Fire_Alarms", DbType.Decimal, Objerty.Fire_Alarms);
                dbHelper.AddInParameter(cmd, "@Security_Alarm", DbType.String, Objerty.Security_Alarm);
                dbHelper.AddInParameter(cmd, "@Security_Console", DbType.Decimal, Objerty.Security_Console);
                dbHelper.AddInParameter(cmd, "@Ownership", DbType.String, Objerty.Ownership);
                dbHelper.AddInParameter(cmd, "@Number_Vaults", DbType.Decimal, Objerty.Number_Vaults);
                dbHelper.AddInParameter(cmd, "@Number_DU_Windows", DbType.Decimal, Objerty.Number_DU_Windows);
                dbHelper.AddInParameter(cmd, "@Number_SD_Boxes", DbType.Decimal, Objerty.Number_SD_Boxes);
                dbHelper.AddInParameter(cmd, "@Number_WU_ATMs", DbType.Decimal, Objerty.Number_WU_ATMs);
                dbHelper.AddInParameter(cmd, "@Number_DU_ATMs", DbType.Decimal, Objerty.Number_DU_ATMs);
                dbHelper.AddInParameter(cmd, "@Regions_Lessor", DbType.Decimal, Objerty.Regions_Lessor);
                dbHelper.AddInParameter(cmd, "@Net_Leasable_Sq_Ft", DbType.Decimal, Objerty.Net_Leasable_Sq_Ft);
                dbHelper.AddInParameter(cmd, "@Current_Monthly_Rent", DbType.Decimal, Objerty.Current_Monthly_Rent);
                dbHelper.AddInParameter(cmd, "@Ocupancy_Rent", DbType.String, Objerty.Ocupancy_Rent);
                dbHelper.AddInParameter(cmd, "@Fine_Arts", DbType.Decimal, Objerty.Fine_Arts);
                dbHelper.AddInParameter(cmd, "@Rental_Income", DbType.Decimal, Objerty.Rental_Income);
                dbHelper.AddInParameter(cmd, "@ATM_Vendor_Contact", DbType.String, Objerty.ATM_Vendor_Contact);
                dbHelper.AddInParameter(cmd, "@ATM_Telephone", DbType.String, Objerty.ATM_Telephone);
                dbHelper.AddInParameter(cmd, "@ATM_Contract", DbType.String, Objerty.ATM_Contract);
                dbHelper.AddInParameter(cmd, "@ATM_Date", DbType.DateTime, Objerty.ATM_Date);
                dbHelper.AddInParameter(cmd, "@Monday_Open", DbType.String, Objerty.Monday_Open);
                dbHelper.AddInParameter(cmd, "@Monday_Close", DbType.String, Objerty.Monday_Close);
                dbHelper.AddInParameter(cmd, "@Tuesday_Open", DbType.String, Objerty.Tuesday_Open);
                dbHelper.AddInParameter(cmd, "@Tuesday_Close", DbType.String, Objerty.Tuesday_Close);
                dbHelper.AddInParameter(cmd, "@Wednesday_Open", DbType.String, Objerty.Wednesday_Open);
                dbHelper.AddInParameter(cmd, "@Wednesday_Close", DbType.String, Objerty.Wednesday_Close);
                dbHelper.AddInParameter(cmd, "@Thursday_Open", DbType.String, Objerty.Thursday_Open);
                dbHelper.AddInParameter(cmd, "@Thursday_Close", DbType.String, Objerty.Thursday_Close);
                dbHelper.AddInParameter(cmd, "@Friday_Open", DbType.String, Objerty.Friday_Open);
                dbHelper.AddInParameter(cmd, "@Friday_Close", DbType.String, Objerty.Friday_Close);
                dbHelper.AddInParameter(cmd, "@Saturday_Open", DbType.String, Objerty.Saturday_Open);
                dbHelper.AddInParameter(cmd, "@Saturday_Close", DbType.String, Objerty.Saturday_Close);
                dbHelper.AddInParameter(cmd, "@Sunday_Open", DbType.String, Objerty.Sunday_Open);
                dbHelper.AddInParameter(cmd, "@Sunday_Close", DbType.String, Objerty.Sunday_Close);
                dbHelper.AddInParameter(cmd, "@Cash_Chests", DbType.Decimal, Objerty.Cash_Chests);
                dbHelper.AddInParameter(cmd, "@Tenant_Type", DbType.String, Objerty.Tenant_Type);
                dbHelper.AddInParameter(cmd, "@Lessee", DbType.Decimal, Objerty.Lessee);
                dbHelper.AddInParameter(cmd, "@Lessee_Rent_Sq_Ft", DbType.Decimal, Objerty.Lessee_Rent_Sq_Ft);
                dbHelper.AddInParameter(cmd, "@SA_SECURITY_CONSOLE", DbType.String, Objerty.SA_SECURITY_CONSOLE);
                dbHelper.ExecuteNonQuery(cmd);
                nRetVal = int.Parse(dbHelper.GetParameterValue(cmd, "@PK_Property_ID").ToString());
                
                return nRetVal;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            { dbHelper = null; cmd.Dispose(); cmd = null; }
        }
        public override int DeleteProperty(System.String lPK_Property_ID)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            int nRetVal = -1;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Property_Delete");
                dbHelper.AddInParameter(cmd, "@PK_Property_ID", DbType.String, lPK_Property_ID);
                nRetVal = dbHelper.ExecuteNonQuery(cmd);
                dbHelper = null; cmd.Dispose(); cmd = null;
                return nRetVal;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public override string ActivateInactivateProperty(string strIDs, int intModifiedBy, bool bIsActive)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            int nRetVal = -1;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Property_ActivateInactivate");
                dbHelper.AddParameter(cmd, "@PK_Property_IDs", DbType.String, ParameterDirection.InputOutput, "PK_Property_IDs", DataRowVersion.Current, strIDs);
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
        public override List<RIMS_Base.CProperty> GetAll()
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Proprty_Select");
                IDataReader reader = dbHelper.ExecuteReader(cmd);
                List<RIMS_Base.CProperty> results = new List<RIMS_Base.CProperty>();
                while (reader.Read())
                {
                    CProperty objerty = new CProperty();
                    objerty = MapFrom(reader);
                    results.Add(objerty);
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
        public override List<RIMS_Base.CProperty> GetPropertyGridData()
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Proprty_Select_GridData");
                IDataReader reader = dbHelper.ExecuteReader(cmd);
                List<RIMS_Base.CProperty> results = new List<RIMS_Base.CProperty>();
                while (reader.Read())
                {
                    CProperty objerty = new CProperty();
                    objerty = MapFromGrid(reader);
                    results.Add(objerty);
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
        public override List<RIMS_Base.CProperty> Get_Search_Data(System.String m_strColumn, System.String m_strCriteria)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Proprty_Search_GridData");
                dbHelper.AddInParameter(cmd, "@ColumnName", DbType.String, m_strColumn.Replace("'", "''"));
                dbHelper.AddInParameter(cmd, "@Criteria", DbType.String, m_strCriteria.Replace("'", "''"));

                IDataReader reader = dbHelper.ExecuteReader(cmd);
                List<RIMS_Base.CProperty> results = new List<RIMS_Base.CProperty>();
                while (reader.Read())
                {
                    CProperty objerty = new CProperty();
                    objerty = MapFromGrid(reader);
                    results.Add(objerty);
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

        public override DataSet GetPropertyByID(System.Decimal pK_Property_ID)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            DataSet m_dsProperty=new DataSet();
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Proprty_Select");
                 dbHelper.AddInParameter(cmd, "@PK_Property_ID", DbType.Decimal, pK_Property_ID);
                m_dsProperty = dbHelper.ExecuteDataSet(cmd);
                cmd = null;
                dbHelper = null;

                return m_dsProperty;
            }
            catch (Exception)
            {
                throw;
            }
        }


        protected RIMS_Base.Dal.CProperty MapFrom(IDataReader reader)
        {
            RIMS_Base.Dal.CProperty objerty = new RIMS_Base.Dal.CProperty();
            if (!Convert.IsDBNull(reader["PK_Property_ID"])) { objerty.PK_Property_ID = Convert.ToInt32(reader["PK_Property_ID"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Cost_Center"])) { objerty.Cost_Center = Convert.ToString(reader["Cost_Center"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Facility"])) { objerty.Facility = Convert.ToString(reader["Facility"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Property_Description"])) { objerty.Property_Description = Convert.ToString(reader["Property_Description"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Value"])) { objerty.Value = Convert.ToDecimal(reader["Value"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Valuation_Date"])) { objerty.Valuation_Date = Convert.ToDateTime(reader["Valuation_Date"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Premium"])) { objerty.Premium = Convert.ToDecimal(reader["Premium"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Coverage"])) { objerty.Coverage = Convert.ToDecimal(reader["Coverage"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Mobile_Type"])) { objerty.Mobile_Type = Convert.ToString(reader["Mobile_Type"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Mobile_VIN"])) { objerty.Mobile_VIN = Convert.ToString(reader["Mobile_VIN"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Mobile_Make"])) { objerty.Mobile_Make = Convert.ToString(reader["Mobile_Make"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Mobile_Model"])) { objerty.Mobile_Model = Convert.ToString(reader["Mobile_Model"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Mobile_Year"])) { objerty.Mobile_Year = Convert.ToDecimal(reader["Mobile_Year"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Mobile_Title"])) { objerty.Mobile_Title = Convert.ToString(reader["Mobile_Title"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Stationary_Type"])) { objerty.Stationary_Type = Convert.ToString(reader["Stationary_Type"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Stationary_Year"])) { objerty.Stationary_Year = Convert.ToDecimal(reader["Stationary_Year"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Stationary_Address_1"])) { objerty.Stationary_Address_1 = Convert.ToString(reader["Stationary_Address_1"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Stationary_Address_2"])) { objerty.Stationary_Address_2 = Convert.ToString(reader["Stationary_Address_2"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Stationary_City"])) { objerty.Stationary_City = Convert.ToString(reader["Stationary_City"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Stationary_State"])) { objerty.Stationary_State = Convert.ToString(reader["Stationary_State"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Stationary_Zip"])) { objerty.Stationary_Zip = Convert.ToString(reader["Stationary_Zip"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Stationary_Category"])) { objerty.Stationary_Category = Convert.ToString(reader["Stationary_Category"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Stationary_Title"])) { objerty.Stationary_Title = Convert.ToString(reader["Stationary_Title"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Stationary_Deed"])) { objerty.Stationary_Deed = Convert.ToString(reader["Stationary_Deed"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Stationary_Safety"])) { objerty.Stationary_Safety = Convert.ToString(reader["Stationary_Safety"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Stationary_Security"])) { objerty.Stationary_Security = Convert.ToString(reader["Stationary_Security"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Stationary_Flood_Zone"])) { objerty.Stationary_Flood_Zone = Convert.ToString(reader["Stationary_Flood_Zone"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Stationary_Foreclosure"])) { objerty.Stationary_Foreclosure = Convert.ToString(reader["Stationary_Foreclosure"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Foreclosed"])) { objerty.Foreclosed = Convert.ToString(reader["Foreclosed"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Contact_Name"])) { objerty.Contact_Name = Convert.ToString(reader["Contact_Name"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Contact_Phone"])) { objerty.Contact_Phone = Convert.ToString(reader["Contact_Phone"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Contact_Facsimile"])) { objerty.Contact_Facsimile = Convert.ToString(reader["Contact_Facsimile"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Emergency_Police"])) { objerty.Emergency_Police = Convert.ToString(reader["Emergency_Police"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Emergency_Fire"])) { objerty.Emergency_Fire = Convert.ToString(reader["Emergency_Fire"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Emergency_Sheriff"])) { objerty.Emergency_Sheriff = Convert.ToString(reader["Emergency_Sheriff"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Emergency_State_Police"])) { objerty.Emergency_State_Police = Convert.ToString(reader["Emergency_State_Police"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Emergency_Ambulance"])) { objerty.Emergency_Ambulance = Convert.ToString(reader["Emergency_Ambulance"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Emergency_FBI"])) { objerty.Emergency_FBI = Convert.ToString(reader["Emergency_FBI"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Emergency_Secret_Service"])) { objerty.Emergency_Secret_Service = Convert.ToString(reader["Emergency_Secret_Service"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Phone_Company_Contact"])) { objerty.Phone_Company_Contact = Convert.ToString(reader["Phone_Company_Contact"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Phone_Company_Telephone"])) { objerty.Phone_Company_Telephone = Convert.ToString(reader["Phone_Company_Telephone"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Power_Company_Contact"])) { objerty.Power_Company_Contact = Convert.ToString(reader["Power_Company_Contact"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Power_Company_Telephone"])) { objerty.Power_Company_Telephone = Convert.ToString(reader["Power_Company_Telephone"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Water_Utility_Contact"])) { objerty.Water_Utility_Contact = Convert.ToString(reader["Water_Utility_Contact"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Water_Utility_Telephone"])) { objerty.Water_Utility_Telephone = Convert.ToString(reader["Water_Utility_Telephone"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Gas_Utility_Contact"])) { objerty.Gas_Utility_Contact = Convert.ToString(reader["Gas_Utility_Contact"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Gas_Utility_Telephone"])) { objerty.Gas_Utility_Telephone = Convert.ToString(reader["Gas_Utility_Telephone"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Cleaning_Company_Contact"])) { objerty.Cleaning_Company_Contact = Convert.ToString(reader["Cleaning_Company_Contact"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Cleaning_Company_Telephone"])) { objerty.Cleaning_Company_Telephone = Convert.ToString(reader["Cleaning_Company_Telephone"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Cleaning_Company_Contract"])) { objerty.Cleaning_Company_Contract = Convert.ToString(reader["Cleaning_Company_Contract"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Cleaning_Company_Date"])) { objerty.Cleaning_Company_Date = Convert.ToDateTime(reader["Cleaning_Company_Date"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Courier_Company_Contact"])) { objerty.Courier_Company_Contact = Convert.ToString(reader["Courier_Company_Contact"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Courier_Company_Telephone"])) { objerty.Courier_Company_Telephone = Convert.ToString(reader["Courier_Company_Telephone"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Courier_Company_Contract"])) { objerty.Courier_Company_Contract = Convert.ToString(reader["Courier_Company_Contract"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Courier_Company_Date"])) { objerty.Courier_Company_Date = Convert.ToDateTime(reader["Courier_Company_Date"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["After_Hours_Contact"])) { objerty.After_Hours_Contact = Convert.ToString(reader["After_Hours_Contact"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["After_Hours_Phone"])) { objerty.After_Hours_Phone = Convert.ToString(reader["After_Hours_Phone"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["After_Hours_Cell"])) { objerty.After_Hours_Cell = Convert.ToString(reader["After_Hours_Cell"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["After_Hours_Pager"])) { objerty.After_Hours_Pager = Convert.ToString(reader["After_Hours_Pager"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Contact_For_1"])) { objerty.Contact_For_1 = Convert.ToString(reader["Contact_For_1"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Special_Contact_1"])) { objerty.Special_Contact_1 = Convert.ToString(reader["Special_Contact_1"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Special_Phone_1"])) { objerty.Special_Phone_1 = Convert.ToString(reader["Special_Phone_1"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Special_Cell_1"])) { objerty.Special_Cell_1 = Convert.ToString(reader["Special_Cell_1"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Special_Pager_1"])) { objerty.Special_Pager_1 = Convert.ToString(reader["Special_Pager_1"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Contact_For_2"])) { objerty.Contact_For_2 = Convert.ToString(reader["Contact_For_2"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Special_Contact_2"])) { objerty.Special_Contact_2 = Convert.ToString(reader["Special_Contact_2"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Special_Phone_2"])) { objerty.Special_Phone_2 = Convert.ToString(reader["Special_Phone_2"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Special_Cell_2"])) { objerty.Special_Cell_2 = Convert.ToString(reader["Special_Cell_2"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Special_Pager_2"])) { objerty.Special_Pager_2 = Convert.ToString(reader["Special_Pager_2"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Contact_For_3"])) { objerty.Contact_For_3 = Convert.ToString(reader["Contact_For_3"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Special_Contact_3"])) { objerty.Special_Contact_3 = Convert.ToString(reader["Special_Contact_3"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Special_Phone_3"])) { objerty.Special_Phone_3 = Convert.ToString(reader["Special_Phone_3"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Special_Cell_3"])) { objerty.Special_Cell_3 = Convert.ToString(reader["Special_Cell_3"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Special_Pager_3"])) { objerty.Special_Pager_3 = Convert.ToString(reader["Special_Pager_3"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Open_Time"])) { objerty.Open_Time = Convert.ToString(reader["Open_Time"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Close_Time"])) { objerty.Close_Time = Convert.ToString(reader["Close_Time"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Number_Of_Employees"])) { objerty.Number_Of_Employees = Convert.ToDecimal(reader["Number_Of_Employees"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["ATM"])) { objerty.ATM = Convert.ToString(reader["ATM"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["ATM_Location"])) { objerty.ATM_Location = Convert.ToString(reader["ATM_Location"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Updated_By"])) { objerty.Updated_By = Convert.ToString(reader["Updated_By"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Update_Date"])) { objerty.Update_Date = Convert.ToDateTime(reader["Update_Date"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FK_Entity"])) { objerty.FK_Entity = Convert.ToDecimal(reader["FK_Entity"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Property_Name"])) { objerty.Property_Name = Convert.ToString(reader["Property_Name"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FK_County"])) { objerty.FK_County = Convert.ToString(reader["FK_County"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["County_Tier_1"])) { objerty.County_Tier_1 = Convert.ToString(reader["County_Tier_1"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["County_Tri_County"])) { objerty.County_Tri_County = Convert.ToString(reader["County_Tri_County"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FK_Land_Status"])) { objerty.FK_Land_Status = Convert.ToDecimal(reader["FK_Land_Status"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Acreage"])) { objerty.Acreage = Convert.ToDecimal(reader["Acreage"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Road_Frontage"])) { objerty.Road_Frontage = Convert.ToDecimal(reader["Road_Frontage"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Road_Frontage_Units"])) { objerty.Road_Frontage_Units = Convert.ToString(reader["Road_Frontage_Units"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Occupancy"])) { objerty.Occupancy = Convert.ToString(reader["Occupancy"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Flood_Zone"])) { objerty.Flood_Zone = Convert.ToString(reader["Flood_Zone"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Number_Of_Employees1"])) { objerty.Number_Of_Employees1 = Convert.ToDecimal(reader["Number_Of_Employees1"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Building"])) { objerty.Building = Convert.ToDecimal(reader["Building"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Signs"])) { objerty.Signs = Convert.ToDecimal(reader["Signs"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Contents"])) { objerty.Contents = Convert.ToDecimal(reader["Contents"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Computers"])) { objerty.Computers = Convert.ToDecimal(reader["Computers"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["ATMs"])) { objerty.ATMs = Convert.ToDecimal(reader["ATMs"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Lease_Improvements"])) { objerty.Lease_Improvements = Convert.ToDecimal(reader["Lease_Improvements"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Total"])) { objerty.Total = Convert.ToDecimal(reader["Total"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Gross_Sq_Feet"])) { objerty.Gross_Sq_Feet = Convert.ToDecimal(reader["Gross_Sq_Feet"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Public_Acc_Sq_Feet"])) { objerty.Public_Acc_Sq_Feet = Convert.ToDecimal(reader["Public_Acc_Sq_Feet"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Stories_Up"])) { objerty.Stories_Up = Convert.ToDecimal(reader["Stories_Up"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Stories_Down"])) { objerty.Stories_Down = Convert.ToDecimal(reader["Stories_Down"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Construction_Cost"])) { objerty.Construction_Cost = Convert.ToDecimal(reader["Construction_Cost"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Construction_Type"])) { objerty.Construction_Type = Convert.ToString(reader["Construction_Type"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Year_Built"])) { objerty.Year_Built = Convert.ToDecimal(reader["Year_Built"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Purchase_Date"])) { objerty.Purchase_Date = Convert.ToDateTime(reader["Purchase_Date"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Purchase_Price"])) { objerty.Purchase_Price = Convert.ToDecimal(reader["Purchase_Price"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Sprinkler"])) { objerty.Sprinkler = Convert.ToDecimal(reader["Sprinkler"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Fire_Alarms"])) { objerty.Fire_Alarms = Convert.ToDecimal(reader["Fire_Alarms"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Security_Alarm"])) { objerty.Security_Alarm = Convert.ToString(reader["Security_Alarm"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Security_Console"])) { objerty.Security_Console = Convert.ToDecimal(reader["Security_Console"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Ownership"])) { objerty.Ownership = Convert.ToString(reader["Ownership"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Number_Vaults"])) { objerty.Number_Vaults = Convert.ToDecimal(reader["Number_Vaults"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Number_DU_Windows"])) { objerty.Number_DU_Windows = Convert.ToDecimal(reader["Number_DU_Windows"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Number_SD_Boxes"])) { objerty.Number_SD_Boxes = Convert.ToDecimal(reader["Number_SD_Boxes"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Number_WU_ATMs"])) { objerty.Number_WU_ATMs = Convert.ToDecimal(reader["Number_WU_ATMs"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Number_DU_ATMs"])) { objerty.Number_DU_ATMs = Convert.ToDecimal(reader["Number_DU_ATMs"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Regions_Lessor"])) { objerty.Regions_Lessor = Convert.ToDecimal(reader["Regions_Lessor"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Net_Leasable_Sq_Ft"])) { objerty.Net_Leasable_Sq_Ft = Convert.ToDecimal(reader["Net_Leasable_Sq_Ft"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Current_Monthly_Rent"])) { objerty.Current_Monthly_Rent = Convert.ToDecimal(reader["Current_Monthly_Rent"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Ocupancy_Rent"])) { objerty.Ocupancy_Rent = Convert.ToString(reader["Ocupancy_Rent"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Fine_Arts"])) { objerty.Fine_Arts = Convert.ToDecimal(reader["Fine_Arts"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Rental_Income"])) { objerty.Rental_Income = Convert.ToDecimal(reader["Rental_Income"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["ATM_Vendor_Contact"])) { objerty.ATM_Vendor_Contact = Convert.ToString(reader["ATM_Vendor_Contact"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["ATM_Telephone"])) { objerty.ATM_Telephone = Convert.ToString(reader["ATM_Telephone"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["ATM_Contract"])) { objerty.ATM_Contract = Convert.ToString(reader["ATM_Contract"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["ATM_Date"])) { objerty.ATM_Date = Convert.ToDateTime(reader["ATM_Date"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Monday_Open"])) { objerty.Monday_Open = Convert.ToString(reader["Monday_Open"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Monday_Close"])) { objerty.Monday_Close = Convert.ToString(reader["Monday_Close"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Tuesday_Open"])) { objerty.Tuesday_Open = Convert.ToString(reader["Tuesday_Open"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Tuesday_Close"])) { objerty.Tuesday_Close = Convert.ToString(reader["Tuesday_Close"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Wednesday_Open"])) { objerty.Wednesday_Open = Convert.ToString(reader["Wednesday_Open"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Wednesday_Close"])) { objerty.Wednesday_Close = Convert.ToString(reader["Wednesday_Close"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Thursday_Open"])) { objerty.Thursday_Open = Convert.ToString(reader["Thursday_Open"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Thursday_Close"])) { objerty.Thursday_Close = Convert.ToString(reader["Thursday_Close"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Friday_Open"])) { objerty.Friday_Open = Convert.ToString(reader["Friday_Open"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Friday_Close"])) { objerty.Friday_Close = Convert.ToString(reader["Friday_Close"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Saturday_Open"])) { objerty.Saturday_Open = Convert.ToString(reader["Saturday_Open"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Saturday_Close"])) { objerty.Saturday_Close = Convert.ToString(reader["Saturday_Close"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Sunday_Open"])) { objerty.Sunday_Open = Convert.ToString(reader["Sunday_Open"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Sunday_Close"])) { objerty.Sunday_Close = Convert.ToString(reader["Sunday_Close"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Cash_Chests"])) { objerty.Cash_Chests = Convert.ToDecimal(reader["Cash_Chests"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Tenant_Type"])) { objerty.Tenant_Type = Convert.ToString(reader["Tenant_Type"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Lessee"])) { objerty.Lessee = Convert.ToDecimal(reader["Lessee"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Lessee_Rent_Sq_Ft"])) { objerty.Lessee_Rent_Sq_Ft = Convert.ToDecimal(reader["Lessee_Rent_Sq_Ft"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["SA_SECURITY_CONSOLE"])) { objerty.SA_SECURITY_CONSOLE = Convert.ToString(reader["SA_SECURITY_CONSOLE"], CultureInfo.InvariantCulture); }
            return objerty;
        }

        protected RIMS_Base.Dal.CProperty MapFromGrid(IDataReader reader)
        {
            RIMS_Base.Dal.CProperty objerty = new RIMS_Base.Dal.CProperty();
            if (!Convert.IsDBNull(reader["PK_Property_ID"])) { objerty.PK_Property_ID = Convert.ToInt32(reader["PK_Property_ID"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Property_Name"])) { objerty.Property_Name = Convert.ToString(reader["Property_Name"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Stationary_Type"])) { objerty.Stationary_Type = Convert.ToString(reader["Stationary_Type"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Description"])) { objerty.Property_Description = Convert.ToString(reader["Description"], CultureInfo.InvariantCulture); }
            return objerty;
        }


    }


}

