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


    public class CPolicy : RIMS_Base.CPolicy
    {

        public override int InsertUpdate_Policy(RIMS_Base.CPolicy Objcy)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            int nRetVal = -1;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Policy_InsertUpdatePolicy");
                dbHelper.AddParameter(cmd, "@PK_Policy_Id", DbType.Int64, ParameterDirection.InputOutput, "PK_Policy_Id", DataRowVersion.Current, Objcy.PK_Policy_Id);
                dbHelper.AddInParameter(cmd, "@FK_Policy_Type", DbType.Decimal, Objcy.FK_Policy_Type);
                dbHelper.AddInParameter(cmd, "@Policy_Number", DbType.String, Objcy.Policy_Number);
                dbHelper.AddInParameter(cmd, "@Carrier", DbType.String, Objcy.Carrier);
                dbHelper.AddInParameter(cmd, "@Underwriter", DbType.String, Objcy.Underwriter);
                dbHelper.AddInParameter(cmd, "@Policy_Begin_Date", DbType.DateTime, Objcy.Policy_Begin_Date);
                dbHelper.AddInParameter(cmd, "@Policy_Expiration_Date", DbType.DateTime, Objcy.Policy_Expiration_Date);
                dbHelper.AddInParameter(cmd, "@FK_Policy_Status", DbType.Decimal, Objcy.FK_Policy_Status);
                dbHelper.AddInParameter(cmd, "@Annual_Premium", DbType.Decimal, Objcy.Annual_Premium);
                dbHelper.AddInParameter(cmd, "@Client_Id", DbType.Decimal, Objcy.Client_Id);
                dbHelper.AddInParameter(cmd, "@Client_Location_Code", DbType.String, Objcy.Client_Location_Code);
                dbHelper.AddInParameter(cmd, "@Contract_End_Date", DbType.DateTime, Objcy.Contract_End_Date);
                dbHelper.AddInParameter(cmd, "@Contract_Number", DbType.Decimal, Objcy.Contract_Number);
                dbHelper.AddInParameter(cmd, "@Contract_Start_Date", DbType.DateTime, Objcy.Contract_Start_Date);
                dbHelper.AddInParameter(cmd, "@Employer_Fed_ID_No", DbType.Decimal, Objcy.Employer_Fed_ID_No);
                dbHelper.AddInParameter(cmd, "@Employer_SIC", DbType.Decimal, Objcy.Employer_SIC);
                dbHelper.AddInParameter(cmd, "@Deductible", DbType.String, Objcy.Deductible);
                dbHelper.AddInParameter(cmd, "@Division_AIG", DbType.Decimal, Objcy.Division_AIG);
                dbHelper.AddInParameter(cmd, "@Policy_Prefix", DbType.String, Objcy.Policy_Prefix);
                dbHelper.AddInParameter(cmd, "@Insured_ISO_Cat", DbType.Decimal, Objcy.Insured_ISO_Cat);
                dbHelper.AddInParameter(cmd, "@Updated_By", DbType.String, Objcy.Updated_By);
                dbHelper.AddInParameter(cmd, "@Update_Date", DbType.DateTime, Objcy.Update_Date);
                dbHelper.AddInParameter(cmd, "@Coverage_Description", DbType.String, Objcy.Coverage_Description);
                dbHelper.AddInParameter(cmd, "@Layer_Number", DbType.Decimal, Objcy.Layer_Number);
                dbHelper.AddInParameter(cmd, "@States_Covered", DbType.String, Objcy.States_Covered);
                dbHelper.AddInParameter(cmd, "@NCCI_Classification_Code", DbType.String, Objcy.NCCI_Classification_Code);
                dbHelper.AddInParameter(cmd, "@FK_Coverage_Code", DbType.Decimal, Objcy.FK_Coverage_Code);
                dbHelper.ExecuteNonQuery(cmd);
                nRetVal = int.Parse(dbHelper.GetParameterValue(cmd, "@PK_Policy_Id").ToString());
                
                return nRetVal;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            { dbHelper = null; cmd.Dispose(); cmd = null; }
        }
        public override int Delete_Policy(System.String Policy_Ids)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            int nRetVal = -1;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Policy_Delete");
                dbHelper.AddInParameter(cmd, "@PK_Policy_Id", DbType.String, Policy_Ids);
                nRetVal = dbHelper.ExecuteNonQuery(cmd);
                dbHelper = null; cmd.Dispose(); cmd = null;
                return nRetVal;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public override string ActivateInactivate_Policy(string strIDs, int intModifiedBy, bool bIsActive)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            int nRetVal = -1;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Policy_ActivateInactivate");
                dbHelper.AddParameter(cmd, "@PK_Policy_Ids", DbType.String, ParameterDirection.InputOutput, "PK_Policy_Ids", DataRowVersion.Current, strIDs);
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
        public override List<RIMS_Base.CPolicy> GetAll()
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Policy_GetAll");
                IDataReader reader = dbHelper.ExecuteReader(cmd);
                List<RIMS_Base.CPolicy> results = new List<RIMS_Base.CPolicy>();
                while (reader.Read())
                {
                    CPolicy objcy = new CPolicy();
                    objcy = MapFrom(reader);
                    results.Add(objcy);
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


        public override List<RIMS_Base.CPolicy> GetPolicyByID(System.Decimal pK_Policy_Id)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Policy_SelectPolicy");
                dbHelper.AddInParameter(cmd, "@PK_Policy_Id", DbType.Decimal, pK_Policy_Id);

                IDataReader reader = dbHelper.ExecuteReader(cmd);
                CPolicy objcy = new CPolicy();
                List<RIMS_Base.CPolicy> results = new List<RIMS_Base.CPolicy>();
                while(reader.Read())
                {
                    objcy = MapFrom(reader);
                    results.Add(objcy);
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


        protected RIMS_Base.Dal.CPolicy MapFrom(IDataReader reader)
        {
            RIMS_Base.Dal.CPolicy objcy = new RIMS_Base.Dal.CPolicy();
            if (!Convert.IsDBNull(reader["Fld_desc"])) { objcy.PolicyType = Convert.ToString(reader["Fld_desc"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Status"])) { objcy.PolicyStatus = Convert.ToString(reader["Status"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Fld_Code"])) { objcy.CovCode = Convert.ToString(reader["Fld_Code"], CultureInfo.InvariantCulture); }
           
            if (!Convert.IsDBNull(reader["PK_Policy_Id"])) { objcy.PK_Policy_Id = Convert.ToInt64(reader["PK_Policy_Id"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FK_Policy_Type"])) { objcy.FK_Policy_Type = Convert.ToDecimal(reader["FK_Policy_Type"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Policy_Number"])) { objcy.Policy_Number = Convert.ToString(reader["Policy_Number"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Carrier"])) { objcy.Carrier = Convert.ToString(reader["Carrier"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Underwriter"])) { objcy.Underwriter = Convert.ToString(reader["Underwriter"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Policy_Begin_Date"])) { objcy.Policy_Begin_Date = Convert.ToDateTime(reader["Policy_Begin_Date"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Policy_Expiration_Date"])) { objcy.Policy_Expiration_Date = Convert.ToDateTime(reader["Policy_Expiration_Date"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FK_Policy_Status"])) { objcy.FK_Policy_Status = Convert.ToDecimal(reader["FK_Policy_Status"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Annual_Premium"])) { objcy.Annual_Premium = Convert.ToDecimal(reader["Annual_Premium"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Client_Id"])) { objcy.Client_Id = Convert.ToDecimal(reader["Client_Id"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Client_Location_Code"])) { objcy.Client_Location_Code = Convert.ToString(reader["Client_Location_Code"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Contract_End_Date"])) { objcy.Contract_End_Date = Convert.ToDateTime(reader["Contract_End_Date"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Contract_Number"])) { objcy.Contract_Number = Convert.ToDecimal(reader["Contract_Number"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Contract_Start_Date"])) { objcy.Contract_Start_Date = Convert.ToDateTime(reader["Contract_Start_Date"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Employer_Fed_ID_No"])) { objcy.Employer_Fed_ID_No = Convert.ToDecimal(reader["Employer_Fed_ID_No"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Employer_SIC"])) { objcy.Employer_SIC = Convert.ToDecimal(reader["Employer_SIC"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Deductible"])) { objcy.Deductible = Convert.ToString(reader["Deductible"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Division_AIG"])) { objcy.Division_AIG = Convert.ToDecimal(reader["Division_AIG"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Policy_Prefix"])) { objcy.Policy_Prefix = Convert.ToString(reader["Policy_Prefix"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Insured_ISO_Cat"])) { objcy.Insured_ISO_Cat = Convert.ToDecimal(reader["Insured_ISO_Cat"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Updated_By"])) { objcy.Updated_By = Convert.ToString(reader["Updated_By"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Update_Date"])) { objcy.Update_Date = Convert.ToDateTime(reader["Update_Date"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Coverage_Description"])) { objcy.Coverage_Description = Convert.ToString(reader["Coverage_Description"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Layer_Number"])) { objcy.Layer_Number = Convert.ToDecimal(reader["Layer_Number"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["States_Covered"])) { objcy.States_Covered = Convert.ToString(reader["States_Covered"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["NCCI_Classification_Code"])) { objcy.NCCI_Classification_Code = Convert.ToString(reader["NCCI_Classification_Code"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FK_Coverage_Code"])) { objcy.FK_Coverage_Code = Convert.ToDecimal(reader["FK_Coverage_Code"], CultureInfo.InvariantCulture); }
            return objcy;
        }

        public override List<RIMS_Base.CPolicy> Get_Search_Data(System.String m_strColumn, System.String m_strCriteria)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Policy_Search_Data");
                dbHelper.AddInParameter(cmd, "@ColumnName", DbType.String, m_strColumn.Replace("'", "''"));
                dbHelper.AddInParameter(cmd, "@Criteria", DbType.String, m_strCriteria.Replace("'", "''"));

                List<RIMS_Base.CPolicy> results = new List<RIMS_Base.CPolicy>();
                IDataReader reader = dbHelper.ExecuteReader(cmd);
                CPolicy mObjCPolicy = new CPolicy();
                while (reader.Read())
                {
                    mObjCPolicy = MapFrom(reader);
                    results.Add(mObjCPolicy);
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
        public override List<RIMS_Base.CPolicy> GetAllPolicyType()
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Policy_SelectPolicyType");
                IDataReader reader = dbHelper.ExecuteReader(cmd);
                List<RIMS_Base.CPolicy> results = new List<RIMS_Base.CPolicy>();
                while (reader.Read())
                {
                    CPolicy objcy = new CPolicy();
                    objcy = MapFromPolType(reader);
                    results.Add(objcy);
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
        protected RIMS_Base.Dal.CPolicy MapFromPolType(IDataReader reader)
        {
            RIMS_Base.Dal.CPolicy objcy_Type = new RIMS_Base.Dal.CPolicy();
            if (!Convert.IsDBNull(reader["PK_ID"])) { objcy_Type.PolicyTypePK_ID = Convert.ToDecimal(reader["PK_ID"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FLD_desc"])) { objcy_Type.PolicyTypeFLD_desc = Convert.ToString(reader["FLD_desc"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FLD_code"])) { objcy_Type.PolicyTypeFLD_code = Convert.ToString(reader["FLD_code"], CultureInfo.InvariantCulture); }
            return objcy_Type;
        }
        public override List<RIMS_Base.CPolicy> GetAllPolicyStatus()
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Policy_SelectPolicyStatus");
                IDataReader reader = dbHelper.ExecuteReader(cmd);
                List<RIMS_Base.CPolicy> results = new List<RIMS_Base.CPolicy>();
                while (reader.Read())
                {
                    CPolicy objcy = new CPolicy();
                    objcy = MapFromPolStatus(reader);
                    results.Add(objcy);
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
        protected RIMS_Base.Dal.CPolicy MapFromPolStatus(IDataReader reader)
        {
            RIMS_Base.Dal.CPolicy objcy_Type = new RIMS_Base.Dal.CPolicy();
            if (!Convert.IsDBNull(reader["PK_ID"])) { objcy_Type.PolicyStatusPK_ID = Convert.ToDecimal(reader["PK_ID"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FLD_desc"])) { objcy_Type.PolicyStatusFLD_desc = Convert.ToString(reader["FLD_desc"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FLD_code"])) { objcy_Type.PolicyStatusFLD_code = Convert.ToString(reader["FLD_code"], CultureInfo.InvariantCulture); }
            return objcy_Type;
        }

        public override List<RIMS_Base.CPolicy> GetCovCodeByPolType(System.Decimal pK_PolicyType_Id)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("CovCode_ByPolicyType");
                dbHelper.AddInParameter(cmd, "@FK_PolicyType_Id", DbType.Decimal, pK_PolicyType_Id);

                IDataReader reader = dbHelper.ExecuteReader(cmd);
                CPolicy objcy = new CPolicy();
                List<RIMS_Base.CPolicy> results = new List<RIMS_Base.CPolicy>();
                while (reader.Read())
                {
                    objcy = MapFromCovCode(reader);
                    results.Add(objcy);
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
        protected RIMS_Base.Dal.CPolicy MapFromCovCode(IDataReader reader)
        {
            RIMS_Base.Dal.CPolicy objcy_Type = new RIMS_Base.Dal.CPolicy();
            if (!Convert.IsDBNull(reader["PK_Coverage_Code"])) { objcy_Type.CovCode_PK_Id = Convert.ToDecimal(reader["PK_Coverage_Code"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FLD_desc"])) { objcy_Type.CovCode_FLD_Desc = Convert.ToString(reader["FLD_desc"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FLD_code"])) { objcy_Type.CovCode_FLD_Code = Convert.ToString(reader["FLD_code"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FK_Policy_Type"])) { objcy_Type.CovCode_FK_PolType = Convert.ToDecimal(reader["FK_Policy_Type"], CultureInfo.InvariantCulture); }
            return objcy_Type;
        }


    }


}

