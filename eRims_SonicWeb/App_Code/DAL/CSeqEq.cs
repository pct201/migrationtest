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


    public class CSecEq : RIMS_Base.CSecEq
    {

        public override int Sec_Equipment_InsertUpdate(RIMS_Base.CSecEq Objrity_Equipment)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            int nRetVal = 0;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("SecEquipment_InsertUpdate");
                dbHelper.AddParameter(cmd, "@PK_Security_Equipment_ID", DbType.Int32, ParameterDirection.InputOutput, "PK_Security_Equipment_ID", DataRowVersion.Current, Objrity_Equipment.PK_Security_Equipment_ID);
                dbHelper.AddInParameter(cmd, "@Property_FK", DbType.Decimal, Objrity_Equipment.Property_FK);
                dbHelper.AddInParameter(cmd, "@Type", DbType.String, Objrity_Equipment.Type);
                dbHelper.AddInParameter(cmd, "@General_Location", DbType.String, Objrity_Equipment.General_Location);
                dbHelper.AddInParameter(cmd, "@Specific_Location", DbType.String, Objrity_Equipment.Specific_Location);
                dbHelper.AddInParameter(cmd, "@Floor", DbType.Decimal, Objrity_Equipment.Floor);
                dbHelper.AddInParameter(cmd, "@Internal_Number", DbType.String, Objrity_Equipment.Internal_Number);
                dbHelper.AddInParameter(cmd, "@Usage", DbType.String, Objrity_Equipment.Usage);
                dbHelper.AddInParameter(cmd, "@Manufacturer", DbType.String, Objrity_Equipment.Manufacturer);
                dbHelper.AddInParameter(cmd, "@Model", DbType.String, Objrity_Equipment.Model);
                dbHelper.AddInParameter(cmd, "@Serial_Number", DbType.String, Objrity_Equipment.Serial_Number);
                dbHelper.AddInParameter(cmd, "@Resolution", DbType.String, Objrity_Equipment.Resolution);
                dbHelper.AddInParameter(cmd, "@Color", DbType.String, Objrity_Equipment.Color);
                dbHelper.AddInParameter(cmd, "@IPAddress", DbType.String, Objrity_Equipment.IPAddress);
                dbHelper.AddInParameter(cmd, "@Date_Purchased", DbType.DateTime, Objrity_Equipment.Date_Purchased);
                dbHelper.AddInParameter(cmd, "@Warranty_Expiration", DbType.DateTime, Objrity_Equipment.Warranty_Expiration);
                dbHelper.AddInParameter(cmd, "@Installer", DbType.String, Objrity_Equipment.Installer);
                dbHelper.AddInParameter(cmd, "@Monitor", DbType.String, Objrity_Equipment.Monitor);
                dbHelper.AddInParameter(cmd, "@Backup_System_Access", DbType.String, Objrity_Equipment.Backup_System_Access);
                dbHelper.AddInParameter(cmd, "@Backup_Cell", DbType.String, Objrity_Equipment.Backup_Cell);
                dbHelper.AddInParameter(cmd, "@Backup_Cell_Cost", DbType.Decimal, Objrity_Equipment.Backup_Cell_Cost);
                dbHelper.AddInParameter(cmd, "@Updated_By", DbType.String, Objrity_Equipment.Updated_By);
                dbHelper.AddInParameter(cmd, "@Update_Date", DbType.DateTime, Objrity_Equipment.Update_Date);
                dbHelper.ExecuteNonQuery(cmd);
                nRetVal = int.Parse(dbHelper.GetParameterValue(cmd, "@PK_Security_Equipment_ID").ToString());
                return nRetVal;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            { dbHelper = null; cmd.Dispose(); cmd = null; }
        }
        public override int Sec_Equipment_Delete(System.String lPK_Security_Equipment_ID)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            int nRetVal = -1;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("SecEquipment_Delete");
                dbHelper.AddInParameter(cmd, "@PK_Security_Equipment_ID", DbType.String, lPK_Security_Equipment_ID);
                nRetVal = dbHelper.ExecuteNonQuery(cmd);
                dbHelper = null; cmd.Dispose(); cmd = null;
                return nRetVal;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public override string ActivateInactivaterity_Equipment(string strIDs, int intModifiedBy, bool bIsActive)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            int nRetVal = -1;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Sec_ActivateInactivaterity_Equipments");
                dbHelper.AddParameter(cmd, "@PK_Security_Equipment_IDs", DbType.String, ParameterDirection.InputOutput, "PK_Security_Equipment_IDs", DataRowVersion.Current, strIDs);
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
        public override List<RIMS_Base.CSecEq> GetAll()
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Sec_Equipment_Select");
                IDataReader reader = dbHelper.ExecuteReader(cmd);
                List<RIMS_Base.CSecEq> results = new List<RIMS_Base.CSecEq>();
                while (reader.Read())
                {
                    CSecEq objrity_Equipment = new CSecEq();
                    objrity_Equipment = MapFrom(reader);
                    results.Add(objrity_Equipment);
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


        public override List<RIMS_Base.CSecEq> GetSec_EquipmentByID(System.Decimal pK_Security_Equipment_ID)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Sec_Equipment_Select");
                dbHelper.AddInParameter(cmd, "@PK_Security_Equipment_ID", DbType.Decimal, pK_Security_Equipment_ID);
                List<RIMS_Base.CSecEq> results = new List<RIMS_Base.CSecEq>();
                IDataReader reader = dbHelper.ExecuteReader(cmd);
                CSecEq objrity_Equipment = new CSecEq();
                if (reader.Read())
                {
                    objrity_Equipment = MapFrom(reader);
                    results.Add(objrity_Equipment);
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

        public override List<RIMS_Base.CSecEq> Get_Search_Data(System.String m_strColumn, System.String m_strCriteria)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("SecEq_Search_Data");
                dbHelper.AddInParameter(cmd, "@ColumnName", DbType.String, m_strColumn.Replace("'", "''")); ;
                dbHelper.AddInParameter(cmd, "@Criteria", DbType.String, m_strCriteria.Replace("'", "''"));
                List<RIMS_Base.CSecEq> results = new List<RIMS_Base.CSecEq>();
                IDataReader reader = dbHelper.ExecuteReader(cmd);
                CSecEq objoyee = new CSecEq();
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
        protected RIMS_Base.Dal.CSecEq MapFrom(IDataReader reader)
        {
            RIMS_Base.Dal.CSecEq objrity_Equipment = new RIMS_Base.Dal.CSecEq();
            if (!Convert.IsDBNull(reader["PK_Security_Equipment_ID"])) { objrity_Equipment.PK_Security_Equipment_ID = Convert.ToInt32(reader["PK_Security_Equipment_ID"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Property_FK"])) { objrity_Equipment.Property_FK = Convert.ToDecimal(reader["Property_FK"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Type"])) { objrity_Equipment.Type = Convert.ToString(reader["Type"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["General_Location"])) { objrity_Equipment.General_Location = Convert.ToString(reader["General_Location"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Specific_Location"])) { objrity_Equipment.Specific_Location = Convert.ToString(reader["Specific_Location"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Floor"])) { objrity_Equipment.Floor = Convert.ToDecimal(reader["Floor"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Internal_Number"])) { objrity_Equipment.Internal_Number = Convert.ToString(reader["Internal_Number"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Usage"])) { objrity_Equipment.Usage = Convert.ToString(reader["Usage"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Manufacturer"])) { objrity_Equipment.Manufacturer = Convert.ToString(reader["Manufacturer"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Model"])) { objrity_Equipment.Model = Convert.ToString(reader["Model"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Serial_Number"])) { objrity_Equipment.Serial_Number = Convert.ToString(reader["Serial_Number"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Resolution"])) { objrity_Equipment.Resolution = Convert.ToString(reader["Resolution"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Color"])) { objrity_Equipment.Color = Convert.ToString(reader["Color"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["IPAddress"])) { objrity_Equipment.IPAddress = Convert.ToString(reader["IPAddress"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Date_Purchased"])) { objrity_Equipment.Date_Purchased = Convert.ToDateTime(reader["Date_Purchased"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Warranty_Expiration"])) { objrity_Equipment.Warranty_Expiration = Convert.ToDateTime(reader["Warranty_Expiration"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Installer"])) { objrity_Equipment.Installer = Convert.ToString(reader["Installer"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Monitor"])) { objrity_Equipment.Monitor = Convert.ToString(reader["Monitor"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Backup_System_Access"])) { objrity_Equipment.Backup_System_Access = Convert.ToString(reader["Backup_System_Access"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Backup_Cell"])) { objrity_Equipment.Backup_Cell = Convert.ToString(reader["Backup_Cell"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Backup_Cell_Cost"])) { objrity_Equipment.Backup_Cell_Cost = Convert.ToDecimal(reader["Backup_Cell_Cost"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Updated_By"])) { objrity_Equipment.Updated_By = Convert.ToString(reader["Updated_By"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Update_Date"])) { objrity_Equipment.Update_Date = Convert.ToDateTime(reader["Update_Date"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Property"])) { objrity_Equipment.Property = Convert.ToString(reader["Property"], CultureInfo.InvariantCulture); }
            return objrity_Equipment;
        }

        public override List<RIMS_Base.CSecEq> GetBSA()
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("[Select_BSA]");
                IDataReader reader = dbHelper.ExecuteReader(cmd);
                List<RIMS_Base.CSecEq> results = new List<RIMS_Base.CSecEq>();
                while (reader.Read())
                {
                    CSecEq obje = new CSecEq();
                    obje = MapFromBSA(reader);
                    results.Add(obje);
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
        protected RIMS_Base.Dal.CSecEq MapFromBSA(IDataReader reader)
        {
            RIMS_Base.Dal.CSecEq obj_Type = new RIMS_Base.Dal.CSecEq();
            if (!Convert.IsDBNull(reader["PK_ID"])) { obj_Type.FK_Backup = Convert.ToInt32(reader["PK_ID"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FLD_Desc"])) { obj_Type.SFK_Backup = Convert.ToString(reader["FLD_Desc"], CultureInfo.InvariantCulture); }
            return obj_Type;
        }

        public override List<RIMS_Base.CSecEq> GetEqType()
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("[Select_EqType]");
                IDataReader reader = dbHelper.ExecuteReader(cmd);
                List<RIMS_Base.CSecEq> results = new List<RIMS_Base.CSecEq>();
                while (reader.Read())
                {
                    CSecEq obje = new CSecEq();
                    obje = MapFromEqType(reader);
                    results.Add(obje);
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
        protected RIMS_Base.Dal.CSecEq MapFromEqType(IDataReader reader)
        {
            RIMS_Base.Dal.CSecEq obj_Type = new RIMS_Base.Dal.CSecEq();
            if (!Convert.IsDBNull(reader["PK_ID"])) { obj_Type.FK_EqType = Convert.ToInt32(reader["PK_ID"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FLD_Desc"])) { obj_Type.SFK_EqType = Convert.ToString(reader["FLD_Desc"], CultureInfo.InvariantCulture); }
            return obj_Type;
        }

        public override List<RIMS_Base.CSecEq> GetLocation()
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("[Select_Location]");
                IDataReader reader = dbHelper.ExecuteReader(cmd);
                List<RIMS_Base.CSecEq> results = new List<RIMS_Base.CSecEq>();
                while (reader.Read())
                {
                    CSecEq obje = new CSecEq();
                    obje = MapFromLocation(reader);
                    results.Add(obje);
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
        protected RIMS_Base.Dal.CSecEq MapFromLocation(IDataReader reader)
        {
            RIMS_Base.Dal.CSecEq obj_Type = new RIMS_Base.Dal.CSecEq();
            if (!Convert.IsDBNull(reader["PK_ID"])) { obj_Type.FK_Location = Convert.ToInt32(reader["PK_ID"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FLD_Desc"])) { obj_Type.SFK_Location = Convert.ToString(reader["FLD_Desc"], CultureInfo.InvariantCulture); }
            return obj_Type;
        }

        public override List<RIMS_Base.CSecEq> GetUsage()
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("[Select_Usage]");
                IDataReader reader = dbHelper.ExecuteReader(cmd);
                List<RIMS_Base.CSecEq> results = new List<RIMS_Base.CSecEq>();
                while (reader.Read())
                {
                    CSecEq obje = new CSecEq();
                    obje = MapFromUsage(reader);
                    results.Add(obje);
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
        protected RIMS_Base.Dal.CSecEq MapFromUsage(IDataReader reader)
        {
            RIMS_Base.Dal.CSecEq obj_Type = new RIMS_Base.Dal.CSecEq();
            if (!Convert.IsDBNull(reader["PK_ID"])) { obj_Type.FK_Usage = Convert.ToInt32(reader["PK_ID"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FLD_Desc"])) { obj_Type.SFK_Usage = Convert.ToString(reader["FLD_Desc"], CultureInfo.InvariantCulture); }
            return obj_Type;
        }

        public override List<RIMS_Base.CSecEq> GetColor()
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("[Select_Color]");
                IDataReader reader = dbHelper.ExecuteReader(cmd);
                List<RIMS_Base.CSecEq> results = new List<RIMS_Base.CSecEq>();
                while (reader.Read())
                {
                    CSecEq obje = new CSecEq();
                    obje = MapFromColor(reader);
                    results.Add(obje);
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
        protected RIMS_Base.Dal.CSecEq MapFromColor(IDataReader reader)
        {
            RIMS_Base.Dal.CSecEq obj_Type = new RIMS_Base.Dal.CSecEq();
            if (!Convert.IsDBNull(reader["PK_ID"])) { obj_Type.FK_Color = Convert.ToInt32(reader["PK_ID"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FLD_Desc"])) { obj_Type.SFK_Color = Convert.ToString(reader["FLD_Desc"], CultureInfo.InvariantCulture); }
            return obj_Type;
        }
    }


}

