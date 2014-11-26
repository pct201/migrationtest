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


    public class CPropMain : RIMS_Base.CPropMain
    {

        public override int PropMain_InsertUpdate(RIMS_Base.CPropMain Objerty_Maintenance)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            int nRetVal = 0;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("PropMain_InsertUpdate");
                dbHelper.AddParameter(cmd, "@PK_Property_Maintenance_ID", DbType.Int32, ParameterDirection.InputOutput, "PK_Property_Maintenance_ID", DataRowVersion.Current, Objerty_Maintenance.PK_Property_Maintenance_ID);
                dbHelper.AddInParameter(cmd, "@Property_FK", DbType.Decimal, Objerty_Maintenance.Property_FK);
                dbHelper.AddInParameter(cmd, "@Requestor", DbType.String, Objerty_Maintenance.Requestor);
                dbHelper.AddInParameter(cmd, "@Type", DbType.String, Objerty_Maintenance.Type);
                dbHelper.AddInParameter(cmd, "@Subject", DbType.String, Objerty_Maintenance.Subject);
                dbHelper.AddInParameter(cmd, "@Equipment_FK", DbType.Decimal, Objerty_Maintenance.Equipment_FK);
                dbHelper.AddInParameter(cmd, "@Performed_By", DbType.String, Objerty_Maintenance.Performed_By);
                dbHelper.AddInParameter(cmd, "@Description", DbType.String, Objerty_Maintenance.Description);
                dbHelper.AddInParameter(cmd, "@Severity", DbType.String, Objerty_Maintenance.Severity);
                dbHelper.AddInParameter(cmd, "@Expected_Date", DbType.DateTime, Objerty_Maintenance.Expected_Date);
                dbHelper.AddInParameter(cmd, "@Expected_Time", DbType.String, Objerty_Maintenance.Expected_Time);
                dbHelper.AddInParameter(cmd, "@Date", DbType.DateTime, Objerty_Maintenance.Date);
                dbHelper.AddInParameter(cmd, "@Status", DbType.String, Objerty_Maintenance.Status);
                dbHelper.AddInParameter(cmd, "@Regions_Work_Order", DbType.String, Objerty_Maintenance.Regions_Work_Order);
                dbHelper.AddInParameter(cmd, "@Vendor_Work_Order", DbType.String, Objerty_Maintenance.Vendor_Work_Order);
                dbHelper.AddInParameter(cmd, "@Vendor", DbType.String, Objerty_Maintenance.Vendor);
                dbHelper.AddInParameter(cmd, "@Vendor_Contact", DbType.String, Objerty_Maintenance.Vendor_Contact);
                dbHelper.AddInParameter(cmd, "@Vendor_Address_1", DbType.String, Objerty_Maintenance.Vendor_Address_1);
                dbHelper.AddInParameter(cmd, "@Vendor_Address_2", DbType.String, Objerty_Maintenance.Vendor_Address_2);
                dbHelper.AddInParameter(cmd, "@Vendor_City", DbType.String, Objerty_Maintenance.Vendor_City);
                dbHelper.AddInParameter(cmd, "@Vendor_State", DbType.String, Objerty_Maintenance.Vendor_State);
                dbHelper.AddInParameter(cmd, "@Vendor_Zip_Code", DbType.String, Objerty_Maintenance.Vendor_Zip_Code);
                dbHelper.AddInParameter(cmd, "@Vendor_Phone", DbType.String, Objerty_Maintenance.Vendor_Phone);
                dbHelper.AddInParameter(cmd, "@Vendor_Facsmilie", DbType.String, Objerty_Maintenance.Vendor_Facsmilie);
                dbHelper.AddInParameter(cmd, "@Vendor_E_Mail", DbType.String, Objerty_Maintenance.Vendor_E_Mail);
                dbHelper.AddInParameter(cmd, "@Credit_Card", DbType.String, Objerty_Maintenance.Credit_Card);
                dbHelper.AddInParameter(cmd, "@Amount_Approved", DbType.Decimal, Objerty_Maintenance.Amount_Approved);
                dbHelper.AddInParameter(cmd, "@Date_Approved", DbType.DateTime, Objerty_Maintenance.Date_Approved);
                dbHelper.AddInParameter(cmd, "@Approved_By", DbType.String, Objerty_Maintenance.Approved_By);
                dbHelper.AddInParameter(cmd, "@Updated_By", DbType.String, Objerty_Maintenance.Updated_By);
                dbHelper.AddInParameter(cmd, "@Update_Date", DbType.DateTime, Objerty_Maintenance.Update_Date);
                dbHelper.AddInParameter(cmd, "@Date_Of_Request", DbType.DateTime, Objerty_Maintenance.Date_Of_Request);
                dbHelper.AddInParameter(cmd, "@Time_Of_Request", DbType.String, Objerty_Maintenance.Time_Of_Request);
                dbHelper.AddInParameter(cmd, "@Branch_FK", DbType.Decimal, Objerty_Maintenance.Branch_FK);
                dbHelper.AddInParameter(cmd, "@ASO", DbType.String, Objerty_Maintenance.ASO);
                dbHelper.ExecuteNonQuery(cmd);
                nRetVal = int.Parse(dbHelper.GetParameterValue(cmd, "@PK_Property_Maintenance_ID").ToString());
                
                return nRetVal;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            { dbHelper = null; cmd.Dispose(); cmd = null; }
        }
        public override int PropMain_Delete(System.String lPK_Property_Maintenance_ID)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            int nRetVal = -1;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("PropMain_Delete");
                dbHelper.AddInParameter(cmd, "@PK_Property_Maintenance_ID", DbType.String, lPK_Property_Maintenance_ID);
                nRetVal = dbHelper.ExecuteNonQuery(cmd);
                dbHelper = null; cmd.Dispose(); cmd = null;
                return nRetVal;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public override string ActivateInactivateerty_Maintenance(string strIDs, int intModifiedBy, bool bIsActive)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            int nRetVal = -1;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Pro_ActivateInactivateerty_Maintenances");
                dbHelper.AddParameter(cmd, "@PK_Property_Maintenance_IDs", DbType.String, ParameterDirection.InputOutput, "PK_Property_Maintenance_IDs", DataRowVersion.Current, strIDs);
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
        public override List<RIMS_Base.CPropMain> GetAll()
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("PropMain_Select");
                IDataReader reader = dbHelper.ExecuteReader(cmd);
                List<RIMS_Base.CPropMain> results = new List<RIMS_Base.CPropMain>();
                while (reader.Read())
                {
                    CPropMain objerty_Maintenance = new CPropMain();
                    objerty_Maintenance = MapFrom(reader);
                    results.Add(objerty_Maintenance);
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
        public override List<RIMS_Base.CPropMain> PropMain_GetByID(System.Decimal pK_Property_Maintenance_ID)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("PropMain_Select");
                dbHelper.AddInParameter(cmd, "@PK_Property_Maintenance_ID", DbType.Decimal, pK_Property_Maintenance_ID);
                List<RIMS_Base.CPropMain> results = new List<RIMS_Base.CPropMain>();
                IDataReader reader = dbHelper.ExecuteReader(cmd);
                CPropMain objerty_Maintenance = new CPropMain();
                if (reader.Read())
                {
                    objerty_Maintenance = MapFrom(reader);
                    results.Add(objerty_Maintenance);
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
        protected RIMS_Base.Dal.CPropMain MapFrom(IDataReader reader)
        {
            RIMS_Base.Dal.CPropMain objerty_Maintenance = new RIMS_Base.Dal.CPropMain();
            if (!Convert.IsDBNull(reader["PK_Property_Maintenance_ID"])) { objerty_Maintenance.PK_Property_Maintenance_ID = Convert.ToInt32(reader["PK_Property_Maintenance_ID"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Property_FK"])) { objerty_Maintenance.Property_FK = Convert.ToDecimal(reader["Property_FK"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Requestor"])) { objerty_Maintenance.Requestor = Convert.ToString(reader["Requestor"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Type"])) { objerty_Maintenance.Type = Convert.ToString(reader["Type"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Subject"])) { objerty_Maintenance.Subject = Convert.ToString(reader["Subject"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Equipment_FK"])) { objerty_Maintenance.Equipment_FK = Convert.ToDecimal(reader["Equipment_FK"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Performed_By"])) { objerty_Maintenance.Performed_By = Convert.ToString(reader["Performed_By"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Description"])) { objerty_Maintenance.Description = Convert.ToString(reader["Description"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Severity"])) { objerty_Maintenance.Severity = Convert.ToString(reader["Severity"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Expected_Date"])) { objerty_Maintenance.Expected_Date = Convert.ToDateTime(reader["Expected_Date"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Expected_Time"])) { objerty_Maintenance.Expected_Time = Convert.ToString(reader["Expected_Time"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Date"])) { objerty_Maintenance.Date = Convert.ToDateTime(reader["Date"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Status"])) { objerty_Maintenance.Status = Convert.ToString(reader["Status"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Regions_Work_Order"])) { objerty_Maintenance.Regions_Work_Order = Convert.ToString(reader["Regions_Work_Order"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Vendor_Work_Order"])) { objerty_Maintenance.Vendor_Work_Order = Convert.ToString(reader["Vendor_Work_Order"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Vendor"])) { objerty_Maintenance.Vendor = Convert.ToString(reader["Vendor"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Vendor_Contact"])) { objerty_Maintenance.Vendor_Contact = Convert.ToString(reader["Vendor_Contact"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Vendor_Address_1"])) { objerty_Maintenance.Vendor_Address_1 = Convert.ToString(reader["Vendor_Address_1"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Vendor_Address_2"])) { objerty_Maintenance.Vendor_Address_2 = Convert.ToString(reader["Vendor_Address_2"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Vendor_City"])) { objerty_Maintenance.Vendor_City = Convert.ToString(reader["Vendor_City"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Vendor_State"])) { objerty_Maintenance.Vendor_State = Convert.ToString(reader["Vendor_State"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Vendor_Zip_Code"])) { objerty_Maintenance.Vendor_Zip_Code = Convert.ToString(reader["Vendor_Zip_Code"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Vendor_Phone"])) { objerty_Maintenance.Vendor_Phone = Convert.ToString(reader["Vendor_Phone"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Vendor_Facsmilie"])) { objerty_Maintenance.Vendor_Facsmilie = Convert.ToString(reader["Vendor_Facsmilie"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Vendor_E_Mail"])) { objerty_Maintenance.Vendor_E_Mail = Convert.ToString(reader["Vendor_E_Mail"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Credit_Card"])) { objerty_Maintenance.Credit_Card = Convert.ToString(reader["Credit_Card"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Amount_Approved"])) { objerty_Maintenance.Amount_Approved = Convert.ToDecimal(reader["Amount_Approved"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Date_Approved"])) { objerty_Maintenance.Date_Approved = Convert.ToDateTime(reader["Date_Approved"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Approved_By"])) { objerty_Maintenance.Approved_By = Convert.ToString(reader["Approved_By"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Updated_By"])) { objerty_Maintenance.Updated_By = Convert.ToString(reader["Updated_By"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Update_Date"])) { objerty_Maintenance.Update_Date = Convert.ToDateTime(reader["Update_Date"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Date_Of_Request"])) { objerty_Maintenance.Date_Of_Request = Convert.ToDateTime(reader["Date_Of_Request"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Time_Of_Request"])) { objerty_Maintenance.Time_Of_Request = Convert.ToString(reader["Time_Of_Request"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Branch_FK"])) { objerty_Maintenance.Branch_FK = Convert.ToDecimal(reader["Branch_FK"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["ASO"])) { objerty_Maintenance.ASO = Convert.ToString(reader["ASO"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Property"])) { objerty_Maintenance.Property = Convert.ToString(reader["Property"], CultureInfo.InvariantCulture); }
            return objerty_Maintenance;
        }

        public override List<RIMS_Base.CPropMain> Get_Search_Data(System.String m_strColumn, System.String m_strCriteria)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("PropMain_Search_Data");
                dbHelper.AddInParameter(cmd, "@ColumnName", DbType.String, m_strColumn.Replace("'", "''")); ;
                dbHelper.AddInParameter(cmd, "@Criteria", DbType.String, m_strCriteria.Replace("'", "''"));
                List<RIMS_Base.CPropMain> results = new List<RIMS_Base.CPropMain>();
                IDataReader reader = dbHelper.ExecuteReader(cmd);
                CPropMain objoyee = new CPropMain();
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
        public override List<RIMS_Base.CPropMain> GetMType()
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("[Select_MType]");
                IDataReader reader = dbHelper.ExecuteReader(cmd);
                List<RIMS_Base.CPropMain> results = new List<RIMS_Base.CPropMain>();
                while (reader.Read())
                {
                    CPropMain obje = new CPropMain();
                    obje = MapFromMType(reader);
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
        protected RIMS_Base.Dal.CPropMain MapFromMType(IDataReader reader)
        {
            RIMS_Base.Dal.CPropMain obj_Type = new RIMS_Base.Dal.CPropMain();
            if (!Convert.IsDBNull(reader["PK_ID"])) { obj_Type.FK_Mtype = Convert.ToInt32(reader["PK_ID"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FLD_Desc"])) { obj_Type.Str_Mtype = Convert.ToString(reader["FLD_Desc"], CultureInfo.InvariantCulture); }
            return obj_Type;
        }

        public override List<RIMS_Base.CPropMain> GetPO()
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("[Select_PO]");
                IDataReader reader = dbHelper.ExecuteReader(cmd);
                List<RIMS_Base.CPropMain> results = new List<RIMS_Base.CPropMain>();
                while (reader.Read())
                {
                    CPropMain obje = new CPropMain();
                    obje = MapFromPO(reader);
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
        protected RIMS_Base.Dal.CPropMain MapFromPO(IDataReader reader)
        {
            RIMS_Base.Dal.CPropMain obj_Type = new RIMS_Base.Dal.CPropMain();
            if (!Convert.IsDBNull(reader["PK_ID"])) { obj_Type.FK_PO = Convert.ToInt32(reader["PK_ID"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FLD_Desc"])) { obj_Type.Str_PO = Convert.ToString(reader["FLD_Desc"], CultureInfo.InvariantCulture); }
            return obj_Type;
        }

        public override List<RIMS_Base.CPropMain> GetSeverity()
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("[Select_Severity]");
                IDataReader reader = dbHelper.ExecuteReader(cmd);
                List<RIMS_Base.CPropMain> results = new List<RIMS_Base.CPropMain>();
                while (reader.Read())
                {
                    CPropMain obje = new CPropMain();
                    obje = MapFromSeverity(reader);
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
        protected RIMS_Base.Dal.CPropMain MapFromSeverity(IDataReader reader)
        {
            RIMS_Base.Dal.CPropMain obj_Type = new RIMS_Base.Dal.CPropMain();
            if (!Convert.IsDBNull(reader["PK_ID"])) { obj_Type.FK_Severity = Convert.ToInt32(reader["PK_ID"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FLD_Desc"])) { obj_Type.Str_Severity = Convert.ToString(reader["FLD_Desc"], CultureInfo.InvariantCulture); }
            return obj_Type;
        }

    }


}

