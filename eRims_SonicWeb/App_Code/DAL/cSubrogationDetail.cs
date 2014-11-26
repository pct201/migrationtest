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


    public class cSubrogationDetail : RIMS_Base.cSubrogationDetail
    {
        public override int InsertUpdateSubrogationDetail(RIMS_Base.cSubrogationDetail ObjSubrogationDetail)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            int nRetVal = -1;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("SubrogationDetail_InsertUpdate");
                dbHelper.AddParameter(cmd, "@PK_Subrogation_detail", DbType.Int32, ParameterDirection.InputOutput, "PK_Subrogation_detail", DataRowVersion.Current, ObjSubrogationDetail.PK_Subrogation_detail);
                dbHelper.AddInParameter(cmd, "@Table_Name", DbType.String, ObjSubrogationDetail.Table_Name);
                dbHelper.AddInParameter(cmd, "@FK_Table_Name", DbType.Decimal, ObjSubrogationDetail.FK_Table_Name);
                dbHelper.AddInParameter(cmd, "@Policy_Company", DbType.String, ObjSubrogationDetail.Policy_Company);
                dbHelper.AddInParameter(cmd, "@Policy", DbType.String, ObjSubrogationDetail.Policy);
                dbHelper.AddInParameter(cmd, "@Claim_Adjuster", DbType.String, ObjSubrogationDetail.Claim_Adjuster);
                dbHelper.AddInParameter(cmd, "@TP_Name", DbType.String, ObjSubrogationDetail.TP_Name);
                dbHelper.AddInParameter(cmd, "@TP_Address_1", DbType.String, ObjSubrogationDetail.TP_Address_1);
                dbHelper.AddInParameter(cmd, "@TP_Address_2", DbType.String, ObjSubrogationDetail.TP_Address_2);
                dbHelper.AddInParameter(cmd, "@TP_City", DbType.String, ObjSubrogationDetail.TP_City);
                dbHelper.AddInParameter(cmd, "@FK_State_TP", DbType.Decimal, ObjSubrogationDetail.FK_State_TP);
                dbHelper.AddInParameter(cmd, "@TP_Zip_Code", DbType.String, ObjSubrogationDetail.TP_Zip_Code);
                dbHelper.AddInParameter(cmd, "@TP_Telephone", DbType.String, ObjSubrogationDetail.TP_Telephone);
                dbHelper.AddInParameter(cmd, "@TP_Insurance_Company", DbType.String, ObjSubrogationDetail.TP_Insurance_Company);
                dbHelper.AddInParameter(cmd, "@TP_Insurance_Number", DbType.String, ObjSubrogationDetail.TP_Insurance_Number);
                dbHelper.AddInParameter(cmd, "@Notice_Date", DbType.DateTime, ObjSubrogationDetail.Notice_Date);
                dbHelper.AddInParameter(cmd, "@TPA", DbType.String, ObjSubrogationDetail.TPA);
                dbHelper.AddInParameter(cmd, "@TPA_Contact", DbType.String, ObjSubrogationDetail.TPA_Contact);
                dbHelper.AddInParameter(cmd, "@TPA_Address_1", DbType.String, ObjSubrogationDetail.TPA_Address_1);
                dbHelper.AddInParameter(cmd, "@TPA_Address_2", DbType.String, ObjSubrogationDetail.TPA_Address_2);
                dbHelper.AddInParameter(cmd, "@TPA_City", DbType.String, ObjSubrogationDetail.TPA_City);
                dbHelper.AddInParameter(cmd, "@FK_State_TPA", DbType.Decimal, ObjSubrogationDetail.FK_State_TPA);
                dbHelper.AddInParameter(cmd, "@TPA_Zip_Code", DbType.String, ObjSubrogationDetail.TPA_Zip_Code);
                dbHelper.AddInParameter(cmd, "@TPA_Telephone", DbType.String, ObjSubrogationDetail.TPA_Telephone);
                dbHelper.AddInParameter(cmd, "@Recovery", DbType.Decimal, ObjSubrogationDetail.Recovery);
                dbHelper.AddInParameter(cmd, "@Received", DbType.Decimal, ObjSubrogationDetail.Received);
                dbHelper.AddInParameter(cmd, "@Updated_By", DbType.String, ObjSubrogationDetail.Updated_By);
                dbHelper.AddInParameter(cmd, "@Update_Date", DbType.DateTime, ObjSubrogationDetail.Update_Date);
                dbHelper.ExecuteNonQuery(cmd);
                nRetVal = int.Parse(dbHelper.GetParameterValue(cmd, "@PK_Subrogation_detail").ToString());

                return nRetVal;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            { dbHelper = null; cmd.Dispose(); cmd = null; }
        }
        public override int DeleteSubrogationDetail(System.Int32 lPK_Subrogation_detail)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            int nRetVal = -1;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("SubrogationDetail_Delete");
                dbHelper.AddInParameter(cmd, "@PK_Subrogation_detail", DbType.Int32, lPK_Subrogation_detail);
                nRetVal = dbHelper.ExecuteNonQuery(cmd);
                dbHelper = null; cmd.Dispose(); cmd = null;
                return nRetVal;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public override string ActivateInactivateSubrogationDetail(string strIDs, int intModifiedBy, bool bIsActive)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            int nRetVal = -1;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("SubrogationDetail_ActivateInactivate");
                dbHelper.AddParameter(cmd, "@PK_Subrogation_details", DbType.String, ParameterDirection.InputOutput, "PK_Subrogation_details", DataRowVersion.Current, strIDs);
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
        public override List<RIMS_Base.cSubrogationDetail> GetAll(Boolean blnIsActive)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("SubrogationDetail_Select");
                dbHelper.AddInParameter(cmd, "@IsActive", DbType.Boolean, blnIsActive);
                IDataReader reader = dbHelper.ExecuteReader(cmd);
                List<RIMS_Base.cSubrogationDetail> results = new List<RIMS_Base.cSubrogationDetail>();
                while (reader.Read())
                {
                    cSubrogationDetail objogationDetail = new cSubrogationDetail();
                    objogationDetail = MapFrom(reader);
                    results.Add(objogationDetail);
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
        public override List<RIMS_Base.cSubrogationDetail> GetSubrogationDetailByID(System.Decimal Fk_Table_Name, System.String Table_Name)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("SubrogationDetail_Select");
                dbHelper.AddInParameter(cmd, "@Fk_Table_Name", DbType.Decimal, Fk_Table_Name);
                dbHelper.AddInParameter(cmd, "@Table_Name", DbType.String, Table_Name);
                List<RIMS_Base.cSubrogationDetail> result = new List<RIMS_Base.cSubrogationDetail>();
                IDataReader reader = dbHelper.ExecuteReader(cmd);
                cSubrogationDetail objSubrogationDetail = new cSubrogationDetail();
                if (reader.Read())
                {
                    objSubrogationDetail = MapFrom(reader);
                    result.Add(objSubrogationDetail);
                }
                reader.Close();
                cmd = null;
                dbHelper = null;

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public override DataSet GetSubrogationDetailLabel()
        {
            DbCommand cmd = null;
            DataSet dstDataset = null;
            Database dbHelper = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Get_SubrogationDetail_Label");
                dstDataset = dbHelper.ExecuteDataSet(cmd);
                cmd = null;
                dbHelper = null;
                return dstDataset;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected RIMS_Base.Dal.cSubrogationDetail MapFrom(IDataReader reader)
        {
            RIMS_Base.Dal.cSubrogationDetail objSubrogationDetail = new RIMS_Base.Dal.cSubrogationDetail();
            if (!Convert.IsDBNull(reader["PK_Subrogation_detail"])) { objSubrogationDetail.PK_Subrogation_detail = Convert.ToInt32(reader["PK_Subrogation_detail"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Table_Name"])) { objSubrogationDetail.Table_Name = Convert.ToString(reader["Table_Name"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FK_Table_Name"])) { objSubrogationDetail.FK_Table_Name = Convert.ToDecimal(reader["FK_Table_Name"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Policy_Company"])) { objSubrogationDetail.Policy_Company = Convert.ToString(reader["Policy_Company"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Policy"])) { objSubrogationDetail.Policy = Convert.ToString(reader["Policy"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Claim_Adjuster"])) { objSubrogationDetail.Claim_Adjuster = Convert.ToString(reader["Claim_Adjuster"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["TP_Name"])) { objSubrogationDetail.TP_Name = Convert.ToString(reader["TP_Name"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["TP_Address_1"])) { objSubrogationDetail.TP_Address_1 = Convert.ToString(reader["TP_Address_1"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["TP_Address_2"])) { objSubrogationDetail.TP_Address_2 = Convert.ToString(reader["TP_Address_2"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["TP_City"])) { objSubrogationDetail.TP_City = Convert.ToString(reader["TP_City"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FK_State_TP"])) { objSubrogationDetail.FK_State_TP = Convert.ToDecimal(reader["FK_State_TP"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["TP_Zip_Code"])) { objSubrogationDetail.TP_Zip_Code = Convert.ToString(reader["TP_Zip_Code"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["TP_Telephone"])) { objSubrogationDetail.TP_Telephone = Convert.ToString(reader["TP_Telephone"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["TP_Insurance_Company"])) { objSubrogationDetail.TP_Insurance_Company = Convert.ToString(reader["TP_Insurance_Company"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["TP_Insurance_Number"])) { objSubrogationDetail.TP_Insurance_Number = Convert.ToString(reader["TP_Insurance_Number"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Notice_Date"])) { objSubrogationDetail.Notice_Date = Convert.ToDateTime(reader["Notice_Date"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["TPA"])) { objSubrogationDetail.TPA = Convert.ToString(reader["TPA"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["TPA_Contact"])) { objSubrogationDetail.TPA_Contact = Convert.ToString(reader["TPA_Contact"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["TPA_Address_1"])) { objSubrogationDetail.TPA_Address_1 = Convert.ToString(reader["TPA_Address_1"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["TPA_Address_2"])) { objSubrogationDetail.TPA_Address_2 = Convert.ToString(reader["TPA_Address_2"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["TPA_City"])) { objSubrogationDetail.TPA_City = Convert.ToString(reader["TPA_City"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FK_State_TPA"])) { objSubrogationDetail.FK_State_TPA = Convert.ToDecimal(reader["FK_State_TPA"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["TPA_Zip_Code"])) { objSubrogationDetail.TPA_Zip_Code = Convert.ToString(reader["TPA_Zip_Code"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["TPA_Telephone"])) { objSubrogationDetail.TPA_Telephone = Convert.ToString(reader["TPA_Telephone"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Recovery"])) { objSubrogationDetail.Recovery = Convert.ToDecimal(reader["Recovery"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Received"])) { objSubrogationDetail.Received = Convert.ToDecimal(reader["Received"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Updated_By"])) { objSubrogationDetail.Updated_By = Convert.ToString(reader["Updated_By"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Update_Date"])) { objSubrogationDetail.Update_Date = Convert.ToDateTime(reader["Update_Date"], CultureInfo.InvariantCulture); }
            return objSubrogationDetail;
        }




    }


}

