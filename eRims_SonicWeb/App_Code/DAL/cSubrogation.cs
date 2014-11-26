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
    public class cSubrogation : RIMS_Base.cSubrogation
    {

        public override int InsertUpdateSubrogation(RIMS_Base.cSubrogation Objogation)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            int nRetVal = -1;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Subrogation_InsertUpdate");
                dbHelper.AddParameter(cmd, "@PK_Subrogation", DbType.Int32, ParameterDirection.InputOutput, "PK_Subrogation", DataRowVersion.Current, Objogation.PK_Subrogation);
                dbHelper.AddInParameter(cmd, "@Table_Name", DbType.String, Objogation.Table_Name);
                dbHelper.AddInParameter(cmd, "@FK_Table_Name", DbType.Decimal, Objogation.FK_Table_Name);
                dbHelper.AddInParameter(cmd, "@Check_Amount", DbType.Decimal, Objogation.Check_Amount);
                dbHelper.AddInParameter(cmd, "@FK_Provider", DbType.Decimal, Objogation.FK_Provider);
                dbHelper.AddInParameter(cmd, "@Check_Number", DbType.Decimal, Objogation.Check_Number);
                dbHelper.AddInParameter(cmd, "@Subrogation", DbType.String, Objogation.Subrogation);
                dbHelper.AddInParameter(cmd, "@Auto_Salvage", DbType.String, Objogation.Auto_Salvage);
                dbHelper.AddInParameter(cmd, "@Other", DbType.String, Objogation.Other);
                dbHelper.AddInParameter(cmd, "@Other_Description", DbType.String, Objogation.Other_Description);
                dbHelper.AddInParameter(cmd, "@Full_Refund", DbType.String, Objogation.Full_Refund);
                dbHelper.AddInParameter(cmd, "@Partial_Refund", DbType.String, Objogation.Partial_Refund);
                dbHelper.AddInParameter(cmd, "@Updated_By", DbType.String, Objogation.Updated_By);
                dbHelper.AddInParameter(cmd, "@Update_Date", DbType.DateTime, Objogation.Update_Date);
                dbHelper.AddInParameter(cmd, "@Payment_Id", DbType.String, Objogation.Payment_Id);
                dbHelper.AddInParameter(cmd, "@Paycode", DbType.String, Objogation.Paycode);
                dbHelper.AddInParameter(cmd, "@Recovery_Description", DbType.String, Objogation.Recovery_Description);
                dbHelper.ExecuteNonQuery(cmd);
                nRetVal = int.Parse(dbHelper.GetParameterValue(cmd, "@PK_Subrogation").ToString());
                return nRetVal;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            { dbHelper = null; cmd.Dispose(); cmd = null; }
        }

        public override int DeleteSubrogation(System.String lPK_Subrogation)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            int nRetVal = -1;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Subrogation_Delete");
                dbHelper.AddInParameter(cmd, "@PK_Subrogation", DbType.String, lPK_Subrogation);
                nRetVal = dbHelper.ExecuteNonQuery(cmd);
                dbHelper = null; cmd.Dispose(); cmd = null;
                return nRetVal;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public override string ActivateInactivateSubrogation(string strIDs, int intModifiedBy, bool bIsActive)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            int nRetVal = -1;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Subrogation_ActivateInactivate");
                dbHelper.AddParameter(cmd, "@PK_Subrogations", DbType.String, ParameterDirection.InputOutput, "PK_Subrogations", DataRowVersion.Current, strIDs);
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

        public override List<RIMS_Base.cSubrogation> GetAll(Decimal Fk_Table_Name, string Table_Name)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Subrogation_Select");
                dbHelper.AddInParameter(cmd, "@Table_Name", DbType.String, Table_Name);
                dbHelper.AddInParameter(cmd, "@Fk_Table_Name", DbType.Decimal, Fk_Table_Name);
                IDataReader reader = dbHelper.ExecuteReader(cmd);
                List<RIMS_Base.cSubrogation> results = new List<RIMS_Base.cSubrogation>();
                while (reader.Read())
                {
                    cSubrogation objSubrogation = new cSubrogation();
                    objSubrogation = MapFromPayCode(reader);
                    results.Add(objSubrogation);
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

        public override List<RIMS_Base.cSubrogation> GetSubrogationByID(System.Int32 pK_Subrogation)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Subrogation_Select");
                dbHelper.AddInParameter(cmd, "@PK_Subrogation", DbType.Int32, pK_Subrogation);
                List<RIMS_Base.cSubrogation> result = new List<RIMS_Base.cSubrogation>();
                IDataReader reader = dbHelper.ExecuteReader(cmd);
                RIMS_Base.cSubrogation objSubrogation = new cSubrogation();
                if (reader.Read())
                {
                    objSubrogation = MapFromPayCode(reader);
                    result.Add(objSubrogation);
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

        public override List<RIMS_Base.cSubrogation> GetProvider(System.Decimal Pk_ProviderID)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Provider_Select");
                dbHelper.AddInParameter(cmd, "@Pk_ProviderID", DbType.Decimal, Pk_ProviderID);
                IDataReader reader = dbHelper.ExecuteReader(cmd);
                List<RIMS_Base.cSubrogation> results = new List<RIMS_Base.cSubrogation>();
                while (reader.Read())
                {
                    cSubrogation objSubrogation = new cSubrogation();
                    objSubrogation = MapFromProvider(reader);
                    results.Add(objSubrogation);
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

        protected RIMS_Base.Dal.cSubrogation MapFromProvider(IDataReader reader)
        {
            RIMS_Base.Dal.cSubrogation objSubrogation = new RIMS_Base.Dal.cSubrogation();
            if (!Convert.IsDBNull(reader["PK_Provider_ID"])) { objSubrogation.PK_Provider_ID = Convert.ToDecimal(reader["PK_Provider_ID"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Name"])) { objSubrogation.Name = Convert.ToString(reader["Name"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Tax_Id"])) { objSubrogation.Tax_Id = Convert.ToString(reader["Tax_Id"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Address_1"])) { objSubrogation.Address_1 = Convert.ToString(reader["Address_1"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Address_2"])) { objSubrogation.Address_2 = Convert.ToString(reader["Address_2"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["City"])) { objSubrogation.City = Convert.ToString(reader["City"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FLD_state"])) { objSubrogation.State = Convert.ToString(reader["FLD_state"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Zip_Code"])) { objSubrogation.Zip_Code = Convert.ToString(reader["Zip_Code"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Phone"])) { objSubrogation.Phone = Convert.ToString(reader["Phone"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Facsimile"])) { objSubrogation.Facsimile = Convert.ToString(reader["Facsimile"], CultureInfo.InvariantCulture); }
            //if (!Convert.IsDBNull(reader["Updated_By"])) { objSubrogation.Provider_Updated_By = Convert.ToString(reader["Updated_By"], CultureInfo.InvariantCulture); }
            //if (!Convert.IsDBNull(reader["Update_Date"])) { objSubrogation.Provider_Update_Date = Convert.ToDateTime(reader["Update_Date"], CultureInfo.InvariantCulture); }

            return objSubrogation;
        }

        protected RIMS_Base.Dal.cSubrogation MapFromPayCode(IDataReader reader)
        {
            RIMS_Base.Dal.cSubrogation objSubrogation = new RIMS_Base.Dal.cSubrogation();
            if (!Convert.IsDBNull(reader["PK_Subrogation"])) { objSubrogation.PK_Subrogation = Convert.ToInt32(reader["PK_Subrogation"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Table_Name"])) { objSubrogation.Table_Name = Convert.ToString(reader["Table_Name"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FK_Table_Name"])) { objSubrogation.FK_Table_Name = Convert.ToDecimal(reader["FK_Table_Name"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Check_Amount"])) { objSubrogation.Check_Amount = Convert.ToDecimal(reader["Check_Amount"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FK_Provider"])) { objSubrogation.FK_Provider = Convert.ToDecimal(reader["FK_Provider"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Check_Number"])) { objSubrogation.Check_Number = Convert.ToDecimal(reader["Check_Number"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Subrogation"])) { objSubrogation.Subrogation = Convert.ToString(reader["Subrogation"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Auto_Salvage"])) { objSubrogation.Auto_Salvage = Convert.ToString(reader["Auto_Salvage"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Other"])) { objSubrogation.Other = Convert.ToString(reader["Other"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Other_Description"])) { objSubrogation.Other_Description = Convert.ToString(reader["Other_Description"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Full_Refund"])) { objSubrogation.Full_Refund = Convert.ToString(reader["Full_Refund"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Partial_Refund"])) { objSubrogation.Partial_Refund = Convert.ToString(reader["Partial_Refund"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Updated_By"])) { objSubrogation.Updated_By = Convert.ToString(reader["Updated_By"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Update_Date"])) { objSubrogation.Update_Date = Convert.ToDateTime(reader["Update_Date"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Payment_Id"])) { objSubrogation.Payment_Id = Convert.ToString(reader["Payment_Id"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Paycode"])) { objSubrogation.Paycode = Convert.ToString(reader["Paycode"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FLD_Paycode"])) { objSubrogation.FLD_Paycode = Convert.ToString(reader["FLD_Paycode"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Recovery_Description"])) { objSubrogation.Recovery_Description = Convert.ToString(reader["Recovery_Description"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["PK_Provider_ID"])) { objSubrogation.PK_Provider_ID = Convert.ToDecimal(reader["PK_Provider_ID"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Name"])) { objSubrogation.Name = Convert.ToString(reader["Name"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Tax_Id"])) { objSubrogation.Tax_Id = Convert.ToString(reader["Tax_Id"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Address_1"])) { objSubrogation.Address_1 = Convert.ToString(reader["Address_1"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Address_2"])) { objSubrogation.Address_2 = Convert.ToString(reader["Address_2"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["City"])) { objSubrogation.City = Convert.ToString(reader["City"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FLD_state"])) { objSubrogation.State = Convert.ToString(reader["FLD_state"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Zip_Code"])) { objSubrogation.Zip_Code = Convert.ToString(reader["Zip_Code"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Phone"])) { objSubrogation.Phone = Convert.ToString(reader["Phone"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Facsimile"])) { objSubrogation.Facsimile = Convert.ToString(reader["Facsimile"], CultureInfo.InvariantCulture); }
            //if (!Convert.IsDBNull(reader["Updated_By"])) { objSubrogation.Provider_Updated_By = Convert.ToString(reader["Updated_By"], CultureInfo.InvariantCulture); }
            //if (!Convert.IsDBNull(reader["Update_Date"])) { objSubrogation.Provider_Update_Date = Convert.ToDateTime(reader["Update_Date"], CultureInfo.InvariantCulture); }

            return objSubrogation;
        }

        public override List<RIMS_Base.cSubrogation> SearchSubrogationData(string FieldName, string FieldVal, decimal Fk_Table_Name, string Table_Name)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Search_SubrogationData");
                dbHelper.AddInParameter(cmd, "@Field_Name", DbType.String, FieldName);
                dbHelper.AddInParameter(cmd, "@Field_Value", DbType.String, FieldVal);
                dbHelper.AddInParameter(cmd, "@Fk_Table_Name", DbType.Decimal, Fk_Table_Name);
                dbHelper.AddInParameter(cmd, "@Table_Name", DbType.String, Table_Name);
                List<RIMS_Base.cSubrogation> result = new List<RIMS_Base.cSubrogation>();
                IDataReader reader = dbHelper.ExecuteReader(cmd);
                cSubrogation objsubrogation = new cSubrogation();
                while (reader.Read())
                {
                    objsubrogation = MapFrom(reader);
                    result.Add(objsubrogation);
                }
                reader.Close();
                cmd = null;
                dbHelper = null;

                //return objstor_Notes;
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public override DataSet GetSubrogationLabel()
        {
            DbCommand cmd = null;
            DataSet dstDataset = null;
            Database dbHelper = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Get_Subrogation_Label");
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
        protected RIMS_Base.Dal.cSubrogation MapFrom(IDataReader reader)
        {
            RIMS_Base.Dal.cSubrogation objSubrogation = new RIMS_Base.Dal.cSubrogation();
            if (!Convert.IsDBNull(reader["PK_Subrogation"])) { objSubrogation.PK_Subrogation = Convert.ToInt32(reader["PK_Subrogation"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Table_Name"])) { objSubrogation.Table_Name = Convert.ToString(reader["Table_Name"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FK_Table_Name"])) { objSubrogation.FK_Table_Name = Convert.ToDecimal(reader["FK_Table_Name"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Check_Amount"])) { objSubrogation.Check_Amount = Convert.ToDecimal(reader["Check_Amount"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FK_Provider"])) { objSubrogation.FK_Provider = Convert.ToDecimal(reader["FK_Provider"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Check_Number"])) { objSubrogation.Check_Number = Convert.ToDecimal(reader["Check_Number"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Subrogation"])) { objSubrogation.Subrogation = Convert.ToString(reader["Subrogation"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Auto_Salvage"])) { objSubrogation.Auto_Salvage = Convert.ToString(reader["Auto_Salvage"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Other"])) { objSubrogation.Other = Convert.ToString(reader["Other"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Other_Description"])) { objSubrogation.Other_Description = Convert.ToString(reader["Other_Description"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Full_Refund"])) { objSubrogation.Full_Refund = Convert.ToString(reader["Full_Refund"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Partial_Refund"])) { objSubrogation.Partial_Refund = Convert.ToString(reader["Partial_Refund"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Updated_By"])) { objSubrogation.Updated_By = Convert.ToString(reader["Updated_By"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Update_Date"])) { objSubrogation.Update_Date = Convert.ToDateTime(reader["Update_Date"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Payment_Id"])) { objSubrogation.Payment_Id = Convert.ToString(reader["Payment_Id"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Paycode"])) { objSubrogation.Paycode = Convert.ToString(reader["Paycode"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Recovery_Description"])) { objSubrogation.Recovery_Description = Convert.ToString(reader["Recovery_Description"], CultureInfo.InvariantCulture); }
            return objSubrogation;
        }




    }


}

