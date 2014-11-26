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


    public class CVendor : RIMS_Base.CVendor
    {

        public override int InsertUpdateVendor(RIMS_Base.CVendor ObjCVendor)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            int nRetVal = -1;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Vendor_InsertUpdate");
                dbHelper.AddParameter(cmd, "@PK_Vendor_ID", DbType.Int32, ParameterDirection.InputOutput, "PK_Vendor_ID", DataRowVersion.Current, ObjCVendor.PK_Vendor_ID);
                dbHelper.AddInParameter(cmd, "@Vendor_Tax_Id", DbType.String, ObjCVendor.Vendor_Tax_Id);
                dbHelper.AddInParameter(cmd, "@Vendor_Name", DbType.String, ObjCVendor.Vendor_Name);
                dbHelper.AddInParameter(cmd, "@Address_1", DbType.String, ObjCVendor.Address_1);
                dbHelper.AddInParameter(cmd, "@Address_2", DbType.String, ObjCVendor.Address_2);
                dbHelper.AddInParameter(cmd, "@City", DbType.String, ObjCVendor.City);
                dbHelper.AddInParameter(cmd, "@State", DbType.String, ObjCVendor.State);
                dbHelper.AddInParameter(cmd, "@Zip_Code", DbType.String, ObjCVendor.Zip_Code);
                dbHelper.AddInParameter(cmd, "@Phone", DbType.String, ObjCVendor.Phone);
                dbHelper.AddInParameter(cmd, "@Facsimile", DbType.String, ObjCVendor.Facsimile);
                dbHelper.AddInParameter(cmd, "@Vendor_Type", DbType.String, ObjCVendor.Vendor_Type);
                dbHelper.AddInParameter(cmd, "@Updated_By", DbType.String, ObjCVendor.Updated_By);
                dbHelper.AddInParameter(cmd, "@Update_Date", DbType.DateTime, ObjCVendor.Update_Date);
                dbHelper.ExecuteNonQuery(cmd);
                nRetVal = int.Parse(dbHelper.GetParameterValue(cmd, "@PK_Vendor_ID").ToString());
                return nRetVal;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            { dbHelper = null; cmd.Dispose(); cmd = null; }
        }
        public override int DeleteVendor(System.String lPK_Vendor_ID)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            int nRetVal = -1;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Vendor_Delete_Details");
                dbHelper.AddInParameter(cmd, "@PK_Vendor_ID", DbType.String, lPK_Vendor_ID);
                nRetVal = dbHelper.ExecuteNonQuery(cmd);
                dbHelper = null; cmd.Dispose(); cmd = null;
                return nRetVal;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public override string ActivateInactivateVendor(string strIDs, int intModifiedBy, bool bIsActive)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            int nRetVal = -1;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Ven_ActivateInactivateors");
                dbHelper.AddParameter(cmd, "@PK_Vendor_IDs", DbType.String, ParameterDirection.InputOutput, "PK_Vendor_IDs", DataRowVersion.Current, strIDs);
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
        public override List<RIMS_Base.CVendor> GetAll()
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Vendor_Select");
                IDataReader reader = dbHelper.ExecuteReader(cmd);
                List<RIMS_Base.CVendor> results = new List<RIMS_Base.CVendor>();
                while (reader.Read())
                {
                    CVendor objor = new CVendor();
                    objor = MapFrom(reader);
                    results.Add(objor);
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
        public override List<RIMS_Base.CVendor> GetAllVendorType()
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Vendor_Select_Type");
                IDataReader reader = dbHelper.ExecuteReader(cmd);
                List<RIMS_Base.CVendor> results = new List<RIMS_Base.CVendor>();
                while (reader.Read())
                {
                    CVendor objVendor_Type = new CVendor();
                    objVendor_Type = MapFromType(reader);
                    results.Add(objVendor_Type);
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

        public override List<RIMS_Base.CVendor> GetorByID(System.Decimal pK_Vendor_ID)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Vendor_Select");
                dbHelper.AddInParameter(cmd, "@PK_Vendor_ID", DbType.Decimal, pK_Vendor_ID);
                List<RIMS_Base.CVendor> results = new List<RIMS_Base.CVendor>();
                
                IDataReader reader = dbHelper.ExecuteReader(cmd);
                CVendor objor = new CVendor();
                if (reader.Read())
                {
                    objor = MapFrom(reader);
                    results.Add(objor);
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

        public override List<RIMS_Base.CVendor> Get_Search_Data(System.String m_strColumn, System.String m_strCriteria)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Vendor_Search_Data");
                dbHelper.AddInParameter(cmd, "@ColumnName", DbType.String, m_strColumn.Replace("'", "''"));
                dbHelper.AddInParameter(cmd, "@Criteria", DbType.String, m_strCriteria.Replace("'", "''"));

                List<RIMS_Base.CVendor> results = new List<RIMS_Base.CVendor>();
                IDataReader reader = dbHelper.ExecuteReader(cmd);
                CVendor mObjCVendor = new CVendor();
                while (reader.Read())
                {
                    mObjCVendor = MapFrom(reader);
                    results.Add(mObjCVendor);
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
        protected RIMS_Base.Dal.CVendor MapFrom(IDataReader reader)
        {
            RIMS_Base.Dal.CVendor objCVendor = new RIMS_Base.Dal.CVendor();
            if (!Convert.IsDBNull(reader["PK_Vendor_ID"])) { objCVendor.PK_Vendor_ID = Convert.ToInt32(reader["PK_Vendor_ID"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Vendor_Tax_Id"])) { objCVendor.Vendor_Tax_Id = Convert.ToString(reader["Vendor_Tax_Id"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Vendor_Name"])) { objCVendor.Vendor_Name = Convert.ToString(reader["Vendor_Name"], CultureInfo.InvariantCulture).Replace("''","'"); }
            if (!Convert.IsDBNull(reader["Address_1"])) { objCVendor.Address_1 = Convert.ToString(reader["Address_1"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Address_2"])) { objCVendor.Address_2 = Convert.ToString(reader["Address_2"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["City"])) { objCVendor.City = Convert.ToString(reader["City"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["State"])) { objCVendor.State = Convert.ToString(reader["State"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Zip_Code"])) { objCVendor.Zip_Code = Convert.ToString(reader["Zip_Code"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Phone"])) { objCVendor.Phone = Convert.ToString(reader["Phone"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Facsimile"])) { objCVendor.Facsimile = Convert.ToString(reader["Facsimile"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Vendor_Type"])) { objCVendor.Vendor_Type = Convert.ToString(reader["Vendor_Type"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Updated_By"])) { objCVendor.Updated_By = Convert.ToString(reader["Updated_By"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Update_Date"])) { objCVendor.Update_Date = Convert.ToDateTime(reader["Update_Date"], CultureInfo.InvariantCulture); }
            return objCVendor;
        }
        protected RIMS_Base.Dal.CVendor MapFromType(IDataReader reader)
        {
            RIMS_Base.Dal.CVendor obj_Type = new RIMS_Base.Dal.CVendor();
            if (!Convert.IsDBNull(reader["PK_ID"])) { obj_Type.PK_ID = Convert.ToDecimal(reader["PK_ID"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FLD_Desc"])) { obj_Type.FLD_Desc = Convert.ToString(reader["FLD_Desc"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FLD_DescO"])) { obj_Type.FLD_DescO = Convert.ToString(reader["FLD_DescO"], CultureInfo.InvariantCulture); }
            return obj_Type;
        }



    }


}

