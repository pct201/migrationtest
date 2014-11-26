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


    public class CCOPE : RIMS_Base.CCOPE
    {

        public override int InsertUpdate_COPE(RIMS_Base.CCOPE Objerty_COPE)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            int nRetVal = -1;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Property_InsertUpdate_COPE");
                dbHelper.AddParameter(cmd, "@PK_Property_COPE", DbType.Decimal, ParameterDirection.InputOutput, "PK_Property_COPE", DataRowVersion.Current, Objerty_COPE.PK_Property_COPE);
                dbHelper.AddInParameter(cmd, "@FK_Entity", DbType.Decimal, Objerty_COPE.FK_Entity);
                dbHelper.AddInParameter(cmd, "@FK_Property_Location_Code", DbType.Decimal, Objerty_COPE.FK_Property_Location_Code);
                dbHelper.AddInParameter(cmd, "@Description", DbType.String, Objerty_COPE.Description);
                dbHelper.AddInParameter(cmd, "@FK_Property_Type", DbType.Decimal, Objerty_COPE.FK_Property_Type);
                dbHelper.AddInParameter(cmd, "@Year_Aquisition", DbType.Int32, Objerty_COPE.Year_Aquisition);
                dbHelper.AddInParameter(cmd, "@Address_1", DbType.String, Objerty_COPE.Address_1);
                dbHelper.AddInParameter(cmd, "@Address_2", DbType.String, Objerty_COPE.Address_2);
                dbHelper.AddInParameter(cmd, "@City", DbType.String, Objerty_COPE.City);
                dbHelper.AddInParameter(cmd, "@FK_State", DbType.Decimal, Objerty_COPE.FK_State);
                dbHelper.AddInParameter(cmd, "@Zip_Code", DbType.String, Objerty_COPE.Zip_Code);
                dbHelper.AddInParameter(cmd, "@FK_County", DbType.Decimal, Objerty_COPE.FK_County);
                dbHelper.AddInParameter(cmd, "@Ownership", DbType.String, Objerty_COPE.Ownership);
                dbHelper.AddInParameter(cmd, "@Property_Owner_Manager", DbType.String, Objerty_COPE.Property_Owner_Manager);
                dbHelper.AddInParameter(cmd, "@Leased_To_Third_Party", DbType.String, Objerty_COPE.Leased_To_Third_Party);
                dbHelper.AddInParameter(cmd, "@Third_Party_Lesee", DbType.String, Objerty_COPE.Third_Party_Lesee);
                dbHelper.AddInParameter(cmd, "@Third_Party_Use", DbType.String, Objerty_COPE.Third_Party_Use);
                dbHelper.AddInParameter(cmd, "@Yeat_Built", DbType.Int32, Objerty_COPE.Yeat_Built);
                dbHelper.AddInParameter(cmd, "@Number_Of_Floors", DbType.Int32, Objerty_COPE.Number_Of_Floors);
                dbHelper.AddInParameter(cmd, "@Square_Feet", DbType.Decimal, Objerty_COPE.Square_Feet);
                dbHelper.AddInParameter(cmd, "@Type_Of_Exterior_Walls", DbType.String, Objerty_COPE.Type_Of_Exterior_Walls);
                dbHelper.AddInParameter(cmd, "@Type_Of_Roof", DbType.String, Objerty_COPE.Type_Of_Roof);
                dbHelper.AddInParameter(cmd, "@Generator", DbType.String, Objerty_COPE.Generator);
                dbHelper.AddInParameter(cmd, "@Generator_Description", DbType.String, Objerty_COPE.Generator_Description);
                dbHelper.AddInParameter(cmd, "@Number_Of_Employees", DbType.Decimal, Objerty_COPE.Number_Of_Employees);
                dbHelper.AddInParameter(cmd, "@Workgroup_Business_Wholesale", DbType.String, Objerty_COPE.Workgroup_Business_Wholesale);
                dbHelper.AddInParameter(cmd, "@Workgroup_Finance_Accounting", DbType.String, Objerty_COPE.Workgroup_Finance_Accounting);
                dbHelper.AddInParameter(cmd, "@Workgroup_HR", DbType.String, Objerty_COPE.Workgroup_HR);
                dbHelper.AddInParameter(cmd, "@Workgroup_ISPE", DbType.String, Objerty_COPE.Workgroup_ISPE);
                dbHelper.AddInParameter(cmd, "@Workgroup_IT_IS", DbType.String, Objerty_COPE.Workgroup_IT_IS);
                dbHelper.AddInParameter(cmd, "@Workgroup_Legal", DbType.String, Objerty_COPE.Workgroup_Legal);
                dbHelper.AddInParameter(cmd, "@Workgroup_Marketing", DbType.String, Objerty_COPE.Workgroup_Marketing);
                dbHelper.AddInParameter(cmd, "@Workgroup_NOC", DbType.String, Objerty_COPE.Workgroup_NOC);
                dbHelper.AddInParameter(cmd, "@Workgroup_OSPE", DbType.String, Objerty_COPE.Workgroup_OSPE);
                dbHelper.AddInParameter(cmd, "@Workgroup_Regultory", DbType.String, Objerty_COPE.Workgroup_Regultory);
                dbHelper.AddInParameter(cmd, "@Workgroup_Residental_Small_Business", DbType.String, Objerty_COPE.Workgroup_Residental_Small_Business);
                dbHelper.AddInParameter(cmd, "@Workgroup_Supply_Chain", DbType.String, Objerty_COPE.Workgroup_Supply_Chain);
                dbHelper.AddInParameter(cmd, "@Workgroup_Support_Services", DbType.String, Objerty_COPE.Workgroup_Support_Services);
                dbHelper.AddInParameter(cmd, "@FK_Fire_Protection", DbType.Decimal, Objerty_COPE.FK_Fire_Protection);
                dbHelper.AddInParameter(cmd, "@Fire_Protection_Description", DbType.String, Objerty_COPE.Fire_Protection_Description);
                dbHelper.AddInParameter(cmd, "@Fire_Alarm", DbType.String, Objerty_COPE.Fire_Alarm);
                dbHelper.AddInParameter(cmd, "@Smoke_Detector", DbType.String, Objerty_COPE.Smoke_Detector);
                dbHelper.AddInParameter(cmd, "@Sub_Floor_Monitoring", DbType.String, Objerty_COPE.Sub_Floor_Monitoring);
                dbHelper.AddInParameter(cmd, "@Sub_Floor_Monitoring_Description", DbType.String, Objerty_COPE.Sub_Floor_Monitoring_Description);
                dbHelper.AddInParameter(cmd, "@Security", DbType.String, Objerty_COPE.Security);
                dbHelper.AddInParameter(cmd, "@Guards", DbType.String, Objerty_COPE.Guards);
                dbHelper.AddInParameter(cmd, "@Electronic_Access", DbType.String, Objerty_COPE.Electronic_Access);
                dbHelper.AddInParameter(cmd, "@Cipher_Lock", DbType.String, Objerty_COPE.Cipher_Lock);
                dbHelper.AddInParameter(cmd, "@Video", DbType.String, Objerty_COPE.Video);
                dbHelper.AddInParameter(cmd, "@Panic_Alarm", DbType.String, Objerty_COPE.Panic_Alarm);
                dbHelper.AddInParameter(cmd, "@Protection_Comments", DbType.String, Objerty_COPE.Protection_Comments);
                dbHelper.AddInParameter(cmd, "@Tier_1_County", DbType.String, Objerty_COPE.Tier_1_County);
                dbHelper.AddInParameter(cmd, "@FK_Flood_Zone", DbType.Decimal, Objerty_COPE.FK_Flood_Zone);
                dbHelper.AddInParameter(cmd, "@Earthquake", DbType.String, Objerty_COPE.Earthquake);
                dbHelper.AddInParameter(cmd, "@Asbestos", DbType.String, Objerty_COPE.Asbestos);
                dbHelper.AddInParameter(cmd, "@Asbestos_Materials_Description", DbType.String, Objerty_COPE.Asbestos_Materials_Description);
                dbHelper.AddInParameter(cmd, "@FK_Batteries", DbType.Decimal, Objerty_COPE.FK_Batteries);
                dbHelper.AddInParameter(cmd, "@Number_Of_Batteries", DbType.Decimal, Objerty_COPE.Number_Of_Batteries);
                dbHelper.AddInParameter(cmd, "@Size_Of_Batteris", DbType.String, Objerty_COPE.Size_Of_Batteris);
                dbHelper.AddInParameter(cmd, "@Tower", DbType.String, Objerty_COPE.Tower);
                dbHelper.AddInParameter(cmd, "@FK_Tower_Type", DbType.Decimal, Objerty_COPE.FK_Tower_Type);
                dbHelper.AddInParameter(cmd, "@Tower_Height", DbType.String, Objerty_COPE.Tower_Height);
                dbHelper.AddInParameter(cmd, "@Total_Height_From_Ground", DbType.String, Objerty_COPE.Total_Height_From_Ground);
                dbHelper.AddInParameter(cmd, "@Tower_Use_Description", DbType.String, Objerty_COPE.Tower_Use_Description);
                dbHelper.AddInParameter(cmd, "@Anti_Climbing_Device", DbType.String, Objerty_COPE.Anti_Climbing_Device);
                dbHelper.AddInParameter(cmd, "@Fence", DbType.String, Objerty_COPE.Fence);
                dbHelper.AddInParameter(cmd, "@Tower_Third_Party_Lessee", DbType.String, Objerty_COPE.Tower_Third_Party_Lessee);
                dbHelper.AddInParameter(cmd, "@Tower_Third_Party_Lessee_Name", DbType.String, Objerty_COPE.Tower_Third_Party_Lessee_Name);
                dbHelper.AddInParameter(cmd, "@Tower_Third_Party_Lessee_Use", DbType.String, Objerty_COPE.Tower_Third_Party_Lessee_Use);
                dbHelper.AddInParameter(cmd, "@Updated_By", DbType.Decimal, Objerty_COPE.Updated_By);
                dbHelper.AddInParameter(cmd, "@Update_Date", DbType.DateTime, Objerty_COPE.Update_Date);
                dbHelper.ExecuteNonQuery(cmd);
                nRetVal = int.Parse(dbHelper.GetParameterValue(cmd, "@PK_Property_COPE").ToString());
                
                return nRetVal;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            { dbHelper = null; cmd.Dispose(); cmd = null; }
        }
        public override int Delete_COPE(System.Decimal lPK_Property_COPE)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            int nRetVal = -1;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Pro_Deleteerty_COPE");
                dbHelper.AddInParameter(cmd, "@PK_Property_COPE", DbType.Decimal, lPK_Property_COPE);
                nRetVal = dbHelper.ExecuteNonQuery(cmd);
                dbHelper = null; cmd.Dispose(); cmd = null;
                return nRetVal;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public override List<RIMS_Base.CCOPE> GetAll( )
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Pro_Selecterty_COPE");
                IDataReader reader = dbHelper.ExecuteReader(cmd);
                List<RIMS_Base.CCOPE> results = new List<RIMS_Base.CCOPE>();
                while (reader.Read())
                {
                    CCOPE objerty_COPE = new CCOPE();
                    objerty_COPE = MapFrom(reader);
                    results.Add(objerty_COPE);
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


        public override DataSet Get_COPEByID(System.Decimal pK_Property_COPE)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            DataSet m_dsCommon = new DataSet();
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Pro_Selecterty_COPE");
                dbHelper.AddInParameter(cmd, "@PK_Property_COPE", DbType.Decimal, pK_Property_COPE);

                m_dsCommon = dbHelper.ExecuteDataSet(cmd);
                cmd = null;
                dbHelper = null;

                return m_dsCommon;
            }
            catch (Exception)
            {
                throw;
            }
        }


        protected RIMS_Base.Dal.CCOPE MapFrom(IDataReader reader)
        {
            RIMS_Base.Dal.CCOPE objerty_COPE = new RIMS_Base.Dal.CCOPE();
            if (!Convert.IsDBNull(reader["PK_Property_COPE"])) { objerty_COPE.PK_Property_COPE = Convert.ToDecimal(reader["PK_Property_COPE"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FK_Entity"])) { objerty_COPE.FK_Entity = Convert.ToDecimal(reader["FK_Entity"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FK_Property_Location_Code"])) { objerty_COPE.FK_Property_Location_Code = Convert.ToDecimal(reader["FK_Property_Location_Code"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Description"])) { objerty_COPE.Description = Convert.ToString(reader["Description"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FK_Property_Type"])) { objerty_COPE.FK_Property_Type = Convert.ToDecimal(reader["FK_Property_Type"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Year_Aquisition"])) { objerty_COPE.Year_Aquisition = Convert.ToInt32(reader["Year_Aquisition"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Address_1"])) { objerty_COPE.Address_1 = Convert.ToString(reader["Address_1"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Address_2"])) { objerty_COPE.Address_2 = Convert.ToString(reader["Address_2"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["City"])) { objerty_COPE.City = Convert.ToString(reader["City"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FK_State"])) { objerty_COPE.FK_State = Convert.ToDecimal(reader["FK_State"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Zip_Code"])) { objerty_COPE.Zip_Code = Convert.ToString(reader["Zip_Code"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FK_County"])) { objerty_COPE.FK_County = Convert.ToDecimal(reader["FK_County"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Ownership"])) { objerty_COPE.Ownership = Convert.ToString(reader["Ownership"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Property_Owner_Manager"])) { objerty_COPE.Property_Owner_Manager = Convert.ToString(reader["Property_Owner_Manager"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Leased_To_Third_Party"])) { objerty_COPE.Leased_To_Third_Party = Convert.ToString(reader["Leased_To_Third_Party"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Third_Party_Lesee"])) { objerty_COPE.Third_Party_Lesee = Convert.ToString(reader["Third_Party_Lesee"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Third_Party_Use"])) { objerty_COPE.Third_Party_Use = Convert.ToString(reader["Third_Party_Use"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Yeat_Built"])) { objerty_COPE.Yeat_Built = Convert.ToInt32(reader["Yeat_Built"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Number_Of_Floors"])) { objerty_COPE.Number_Of_Floors = Convert.ToInt32(reader["Number_Of_Floors"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Square_Feet"])) { objerty_COPE.Square_Feet = Convert.ToDecimal(reader["Square_Feet"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Type_Of_Exterior_Walls"])) { objerty_COPE.Type_Of_Exterior_Walls = Convert.ToString(reader["Type_Of_Exterior_Walls"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Type_Of_Roof"])) { objerty_COPE.Type_Of_Roof = Convert.ToString(reader["Type_Of_Roof"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Generator"])) { objerty_COPE.Generator = Convert.ToString(reader["Generator"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Generator_Description"])) { objerty_COPE.Generator_Description = Convert.ToString(reader["Generator_Description"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Number_Of_Employees"])) { objerty_COPE.Number_Of_Employees = Convert.ToDecimal(reader["Number_Of_Employees"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Workgroup_Business_Wholesale"])) { objerty_COPE.Workgroup_Business_Wholesale = Convert.ToString(reader["Workgroup_Business_Wholesale"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Workgroup_Finance_Accounting"])) { objerty_COPE.Workgroup_Finance_Accounting = Convert.ToString(reader["Workgroup_Finance_Accounting"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Workgroup_HR"])) { objerty_COPE.Workgroup_HR = Convert.ToString(reader["Workgroup_HR"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Workgroup_ISPE"])) { objerty_COPE.Workgroup_ISPE = Convert.ToString(reader["Workgroup_ISPE"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Workgroup_IT_IS"])) { objerty_COPE.Workgroup_IT_IS = Convert.ToString(reader["Workgroup_IT_IS"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Workgroup_Legal"])) { objerty_COPE.Workgroup_Legal = Convert.ToString(reader["Workgroup_Legal"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Workgroup_Marketing"])) { objerty_COPE.Workgroup_Marketing = Convert.ToString(reader["Workgroup_Marketing"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Workgroup_NOC"])) { objerty_COPE.Workgroup_NOC = Convert.ToString(reader["Workgroup_NOC"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Workgroup_OSPE"])) { objerty_COPE.Workgroup_OSPE = Convert.ToString(reader["Workgroup_OSPE"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Workgroup_Regultory"])) { objerty_COPE.Workgroup_Regultory = Convert.ToString(reader["Workgroup_Regultory"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Workgroup_Residental_Small_Business"])) { objerty_COPE.Workgroup_Residental_Small_Business = Convert.ToString(reader["Workgroup_Residental_Small_Business"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Workgroup_Supply_Chain"])) { objerty_COPE.Workgroup_Supply_Chain = Convert.ToString(reader["Workgroup_Supply_Chain"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Workgroup_Support_Services"])) { objerty_COPE.Workgroup_Support_Services = Convert.ToString(reader["Workgroup_Support_Services"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FK_Fire_Protection"])) { objerty_COPE.FK_Fire_Protection = Convert.ToDecimal(reader["FK_Fire_Protection"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Fire_Protection_Description"])) { objerty_COPE.Fire_Protection_Description = Convert.ToString(reader["Fire_Protection_Description"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Fire_Alarm"])) { objerty_COPE.Fire_Alarm = Convert.ToString(reader["Fire_Alarm"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Smoke_Detector"])) { objerty_COPE.Smoke_Detector = Convert.ToString(reader["Smoke_Detector"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Sub_Floor_Monitoring"])) { objerty_COPE.Sub_Floor_Monitoring = Convert.ToString(reader["Sub_Floor_Monitoring"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Sub_Floor_Monitoring_Description"])) { objerty_COPE.Sub_Floor_Monitoring_Description = Convert.ToString(reader["Sub_Floor_Monitoring_Description"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Security"])) { objerty_COPE.Security = Convert.ToString(reader["Security"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Guards"])) { objerty_COPE.Guards = Convert.ToString(reader["Guards"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Electronic_Access"])) { objerty_COPE.Electronic_Access = Convert.ToString(reader["Electronic_Access"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Cipher_Lock"])) { objerty_COPE.Cipher_Lock = Convert.ToString(reader["Cipher_Lock"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Video"])) { objerty_COPE.Video = Convert.ToString(reader["Video"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Panic_Alarm"])) { objerty_COPE.Panic_Alarm = Convert.ToString(reader["Panic_Alarm"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Protection_Comments"])) { objerty_COPE.Protection_Comments = Convert.ToString(reader["Protection_Comments"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Tier_1_County"])) { objerty_COPE.Tier_1_County = Convert.ToString(reader["Tier_1_County"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FK_Flood_Zone"])) { objerty_COPE.FK_Flood_Zone = Convert.ToDecimal(reader["FK_Flood_Zone"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Earthquake"])) { objerty_COPE.Earthquake = Convert.ToString(reader["Earthquake"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Asbestos"])) { objerty_COPE.Asbestos = Convert.ToString(reader["Asbestos"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Asbestos_Materials_Description"])) { objerty_COPE.Asbestos_Materials_Description = Convert.ToString(reader["Asbestos_Materials_Description"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FK_Batteries"])) { objerty_COPE.FK_Batteries = Convert.ToDecimal(reader["FK_Batteries"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Number_Of_Batteries"])) { objerty_COPE.Number_Of_Batteries = Convert.ToDecimal(reader["Number_Of_Batteries"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Size_Of_Batteris"])) { objerty_COPE.Size_Of_Batteris = Convert.ToString(reader["Size_Of_Batteris"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Tower"])) { objerty_COPE.Tower = Convert.ToString(reader["Tower"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FK_Tower_Type"])) { objerty_COPE.FK_Tower_Type = Convert.ToDecimal(reader["FK_Tower_Type"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Tower_Height"])) { objerty_COPE.Tower_Height = Convert.ToString(reader["Tower_Height"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Total_Height_From_Ground"])) { objerty_COPE.Total_Height_From_Ground = Convert.ToString(reader["Total_Height_From_Ground"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Tower_Use_Description"])) { objerty_COPE.Tower_Use_Description = Convert.ToString(reader["Tower_Use_Description"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Anti_Climbing_Device"])) { objerty_COPE.Anti_Climbing_Device = Convert.ToString(reader["Anti_Climbing_Device"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Fence"])) { objerty_COPE.Fence = Convert.ToString(reader["Fence"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Tower_Third_Party_Lessee"])) { objerty_COPE.Tower_Third_Party_Lessee = Convert.ToString(reader["Tower_Third_Party_Lessee"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Tower_Third_Party_Lessee_Name"])) { objerty_COPE.Tower_Third_Party_Lessee_Name = Convert.ToString(reader["Tower_Third_Party_Lessee_Name"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Tower_Third_Party_Lessee_Use"])) { objerty_COPE.Tower_Third_Party_Lessee_Use = Convert.ToString(reader["Tower_Third_Party_Lessee_Use"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Updated_By"])) { objerty_COPE.Updated_By = Convert.ToDecimal(reader["Updated_By"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Update_Date"])) { objerty_COPE.Update_Date = Convert.ToDateTime(reader["Update_Date"], CultureInfo.InvariantCulture); }
            return objerty_COPE;
        }




    }


}
