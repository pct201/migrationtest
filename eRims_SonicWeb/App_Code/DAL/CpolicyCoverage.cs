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


    public class CPolicyCoverage : RIMS_Base.CPolicyCoverage
    {
        public override int InsertUpdatePolicy_Coverage(RIMS_Base.CPolicyCoverage Objcy_Coverage)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            int nRetVal = -1;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("PolicyCoverage_InsertUpdate");
                dbHelper.AddParameter(cmd, "@PK_Policy_Coverage_Id", DbType.Int32, ParameterDirection.InputOutput, "PK_Policy_Coverage_Id", DataRowVersion.Current, Objcy_Coverage.PK_Policy_Coverage_Id);
                dbHelper.AddInParameter(cmd, "@FK_Policy", DbType.Decimal, Objcy_Coverage.FK_Policy);
                dbHelper.AddInParameter(cmd, "@Policy_Coverage", DbType.String, Objcy_Coverage.Policy_Coverage);
                dbHelper.AddInParameter(cmd, "@Policy_Deductible", DbType.Decimal, Objcy_Coverage.Policy_Deductible);
                dbHelper.AddInParameter(cmd, "@Occurrence_Limit", DbType.Decimal, Objcy_Coverage.Occurrence_Limit);
                dbHelper.AddInParameter(cmd, "@Aggregate_Limit", DbType.Decimal, Objcy_Coverage.Aggregate_Limit);
                dbHelper.AddInParameter(cmd, "@GL_Rent_Damage", DbType.Decimal, Objcy_Coverage.GL_Rent_Damage);
                dbHelper.AddInParameter(cmd, "@GL_Medical", DbType.Decimal, Objcy_Coverage.GL_Medical);
                dbHelper.AddInParameter(cmd, "@GL_Products", DbType.Decimal, Objcy_Coverage.GL_Products);
                dbHelper.AddInParameter(cmd, "@AL_PIP", DbType.Decimal, Objcy_Coverage.AL_PIP);
                dbHelper.AddInParameter(cmd, "@AL_Medical", DbType.Decimal, Objcy_Coverage.AL_Medical);
                dbHelper.AddInParameter(cmd, "@AL_Uninsured", DbType.String, Objcy_Coverage.AL_Uninsured);
                dbHelper.AddInParameter(cmd, "@AL_Underinsured", DbType.String, Objcy_Coverage.AL_Underinsured);
                dbHelper.AddInParameter(cmd, "@Umbrella", DbType.Decimal, Objcy_Coverage.Umbrella);
                dbHelper.AddInParameter(cmd, "@Other_Policy_Type", DbType.String, Objcy_Coverage.Other_Policy_Type);
                dbHelper.AddInParameter(cmd, "@FK_Policy_Feature_1", DbType.Decimal, Objcy_Coverage.FK_Policy_Feature_1);
                dbHelper.AddInParameter(cmd, "@Deductible_1", DbType.Decimal, Objcy_Coverage.Deductible_1);
                dbHelper.AddInParameter(cmd, "@Limit_1", DbType.Decimal, Objcy_Coverage.Limit_1);
                dbHelper.AddInParameter(cmd, "@FK_Policy_Feature_2", DbType.Decimal, Objcy_Coverage.FK_Policy_Feature_2);
                dbHelper.AddInParameter(cmd, "@Deductible_2", DbType.Decimal, Objcy_Coverage.Deductible_2);
                dbHelper.AddInParameter(cmd, "@Limit_2", DbType.Decimal, Objcy_Coverage.Limit_2);
                dbHelper.AddInParameter(cmd, "@FK_Policy_Feature_3", DbType.Decimal, Objcy_Coverage.FK_Policy_Feature_3);
                dbHelper.AddInParameter(cmd, "@Deductible_3", DbType.Decimal, Objcy_Coverage.Deductible_3);
                dbHelper.AddInParameter(cmd, "@Limit_3", DbType.Decimal, Objcy_Coverage.Limit_3);
                dbHelper.AddInParameter(cmd, "@FK_Policy_Feature_4", DbType.Decimal, Objcy_Coverage.FK_Policy_Feature_4);
                dbHelper.AddInParameter(cmd, "@Deductible_4", DbType.Decimal, Objcy_Coverage.Deductible_4);
                dbHelper.AddInParameter(cmd, "@Limit_4", DbType.Decimal, Objcy_Coverage.Limit_4);
                dbHelper.AddInParameter(cmd, "@FK_Policy_Feature_5", DbType.Decimal, Objcy_Coverage.FK_Policy_Feature_5);
                dbHelper.AddInParameter(cmd, "@Deductible_5", DbType.Decimal, Objcy_Coverage.Deductible_5);
                dbHelper.AddInParameter(cmd, "@Limit_5", DbType.Decimal, Objcy_Coverage.Limit_5);
                dbHelper.AddInParameter(cmd, "@FK_Policy_Feature_6", DbType.Decimal, Objcy_Coverage.FK_Policy_Feature_6);
                dbHelper.AddInParameter(cmd, "@Deductible_6", DbType.Decimal, Objcy_Coverage.Deductible_6);
                dbHelper.AddInParameter(cmd, "@Limit_6", DbType.Decimal, Objcy_Coverage.Limit_6);
                dbHelper.AddInParameter(cmd, "@Updated_By", DbType.String, Objcy_Coverage.Updated_By);
                dbHelper.AddInParameter(cmd, "@Update_Date", DbType.DateTime, Objcy_Coverage.Update_Date);
                dbHelper.ExecuteNonQuery(cmd);
                nRetVal = int.Parse(dbHelper.GetParameterValue(cmd, "@PK_Policy_Coverage_Id").ToString());
                return nRetVal;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            { dbHelper = null; cmd.Dispose(); cmd = null; }
        }
        public override int DeletePolicy_Coverage(System.Decimal lPK_Policy_Coverage_Id)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            int nRetVal = -1;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Pol_Deletecy_Coverage");
                dbHelper.AddInParameter(cmd, "@PK_Policy_Coverage_Id", DbType.Decimal, lPK_Policy_Coverage_Id);
                nRetVal = dbHelper.ExecuteNonQuery(cmd);
                dbHelper = null; cmd.Dispose(); cmd = null;
                return nRetVal;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public override List<RIMS_Base.CPolicyCoverage> GetAll()
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("PolicyCoverage_Select");
                IDataReader reader = dbHelper.ExecuteReader(cmd);
                List<RIMS_Base.CPolicyCoverage> results = new List<RIMS_Base.CPolicyCoverage>();
                while (reader.Read())
                {
                    CPolicyCoverage objcy_Coverage = new CPolicyCoverage();
                    objcy_Coverage = MapFrom(reader);
                    results.Add(objcy_Coverage);
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


        public override List<RIMS_Base.CPolicyCoverage> GetPolicy_CoverageByID(System.Decimal pK_Policy_Coverage_Id)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("PolicyCoverage_Select");
                dbHelper.AddInParameter(cmd, "@PK_Policy_Coverage_Id", DbType.Decimal, pK_Policy_Coverage_Id);
                List<RIMS_Base.CPolicyCoverage> results = new List<RIMS_Base.CPolicyCoverage>();
                
                IDataReader reader = dbHelper.ExecuteReader(cmd);
                CPolicyCoverage objcy_Coverage = new CPolicyCoverage();
                while (reader.Read())
                {
                    objcy_Coverage = MapFromByID(reader);
                    results.Add(objcy_Coverage);
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
        public override List<RIMS_Base.CPolicyCoverage> Get_Search_Data(System.String m_strColumn, System.String m_strCriteria)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("PolicyCoverage_Search_Data");
                dbHelper.AddInParameter(cmd, "@ColumnName", DbType.String, m_strColumn.Replace("'", "''"));
                dbHelper.AddInParameter(cmd, "@Criteria", DbType.String, m_strCriteria.Replace("'", "''"));

                List<RIMS_Base.CPolicyCoverage> results = new List<RIMS_Base.CPolicyCoverage>();
                IDataReader reader = dbHelper.ExecuteReader(cmd);
                CPolicyCoverage mObjCPolicy = new CPolicyCoverage();
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
        public override List<RIMS_Base.CPolicyCoverage> GetPolicyFeatures()
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("PolicyCoverage_GetFeatures");

                List<RIMS_Base.CPolicyCoverage> results = new List<RIMS_Base.CPolicyCoverage>();
                IDataReader reader = dbHelper.ExecuteReader(cmd);
                CPolicyCoverage mObjCPolicy = new CPolicyCoverage();
                while (reader.Read())
                {
                    mObjCPolicy = MapFromFeature(reader);
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

        protected RIMS_Base.Dal.CPolicyCoverage MapFromByID(IDataReader reader)
        {
            RIMS_Base.Dal.CPolicyCoverage objcy_Coverage = new RIMS_Base.Dal.CPolicyCoverage();
            if (!Convert.IsDBNull(reader["PolicyFeature1"])) { objcy_Coverage.PolFeature1 = Convert.ToString(reader["PolicyFeature1"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["PolicyFeature2"])) { objcy_Coverage.PolFeature2 = Convert.ToString(reader["PolicyFeature2"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["PolicyFeature3"])) { objcy_Coverage.PolFeature3 = Convert.ToString(reader["PolicyFeature3"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["PolicyFeature4"])) { objcy_Coverage.PolFeature4 = Convert.ToString(reader["PolicyFeature4"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["PolicyFeature5"])) { objcy_Coverage.PolFeature5 = Convert.ToString(reader["PolicyFeature5"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["PolicyFeature6"])) { objcy_Coverage.PolFeature6 = Convert.ToString(reader["PolicyFeature6"], CultureInfo.InvariantCulture); }
            
            if (!Convert.IsDBNull(reader["Policy_Number"])) { objcy_Coverage.PolicyNumber = Convert.ToString(reader["Policy_Number"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["PK_Policy_Coverage_Id"])) { objcy_Coverage.PK_Policy_Coverage_Id = Convert.ToInt32(reader["PK_Policy_Coverage_Id"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FK_Policy"])) { objcy_Coverage.FK_Policy = Convert.ToDecimal(reader["FK_Policy"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Policy_Coverage"])) { objcy_Coverage.Policy_Coverage = Convert.ToString(reader["Policy_Coverage"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Policy_Deductible"])) { objcy_Coverage.Policy_Deductible = Convert.ToDecimal(reader["Policy_Deductible"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Occurrence_Limit"])) { objcy_Coverage.Occurrence_Limit = Convert.ToDecimal(reader["Occurrence_Limit"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Aggregate_Limit"])) { objcy_Coverage.Aggregate_Limit = Convert.ToDecimal(reader["Aggregate_Limit"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["GL_Rent_Damage"])) { objcy_Coverage.GL_Rent_Damage = Convert.ToDecimal(reader["GL_Rent_Damage"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["GL_Medical"])) { objcy_Coverage.GL_Medical = Convert.ToDecimal(reader["GL_Medical"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["GL_Products"])) { objcy_Coverage.GL_Products = Convert.ToDecimal(reader["GL_Products"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["AL_PIP"])) { objcy_Coverage.AL_PIP = Convert.ToDecimal(reader["AL_PIP"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["AL_Medical"])) { objcy_Coverage.AL_Medical = Convert.ToDecimal(reader["AL_Medical"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["AL_Uninsured"])) { objcy_Coverage.AL_Uninsured = Convert.ToString(reader["AL_Uninsured"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["AL_Underinsured"])) { objcy_Coverage.AL_Underinsured = Convert.ToString(reader["AL_Underinsured"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Umbrella"])) { objcy_Coverage.Umbrella = Convert.ToDecimal(reader["Umbrella"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Other_Policy_Type"])) { objcy_Coverage.Other_Policy_Type = Convert.ToString(reader["Other_Policy_Type"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FK_Policy_Feature_1"])) { objcy_Coverage.FK_Policy_Feature_1 = Convert.ToDecimal(reader["FK_Policy_Feature_1"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Deductible_1"])) { objcy_Coverage.Deductible_1 = Convert.ToDecimal(reader["Deductible_1"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Limit_1"])) { objcy_Coverage.Limit_1 = Convert.ToDecimal(reader["Limit_1"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FK_Policy_Feature_2"])) { objcy_Coverage.FK_Policy_Feature_2 = Convert.ToDecimal(reader["FK_Policy_Feature_2"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Deductible_2"])) { objcy_Coverage.Deductible_2 = Convert.ToDecimal(reader["Deductible_2"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Limit_2"])) { objcy_Coverage.Limit_2 = Convert.ToDecimal(reader["Limit_2"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FK_Policy_Feature_3"])) { objcy_Coverage.FK_Policy_Feature_3 = Convert.ToDecimal(reader["FK_Policy_Feature_3"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Deductible_3"])) { objcy_Coverage.Deductible_3 = Convert.ToDecimal(reader["Deductible_3"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Limit_3"])) { objcy_Coverage.Limit_3 = Convert.ToDecimal(reader["Limit_3"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FK_Policy_Feature_4"])) { objcy_Coverage.FK_Policy_Feature_4 = Convert.ToDecimal(reader["FK_Policy_Feature_4"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Deductible_4"])) { objcy_Coverage.Deductible_4 = Convert.ToDecimal(reader["Deductible_4"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Limit_4"])) { objcy_Coverage.Limit_4 = Convert.ToDecimal(reader["Limit_4"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FK_Policy_Feature_5"])) { objcy_Coverage.FK_Policy_Feature_5 = Convert.ToDecimal(reader["FK_Policy_Feature_5"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Deductible_5"])) { objcy_Coverage.Deductible_5 = Convert.ToDecimal(reader["Deductible_5"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Limit_5"])) { objcy_Coverage.Limit_5 = Convert.ToDecimal(reader["Limit_5"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FK_Policy_Feature_6"])) { objcy_Coverage.FK_Policy_Feature_6 = Convert.ToDecimal(reader["FK_Policy_Feature_6"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Deductible_6"])) { objcy_Coverage.Deductible_6 = Convert.ToDecimal(reader["Deductible_6"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Limit_6"])) { objcy_Coverage.Limit_6 = Convert.ToDecimal(reader["Limit_6"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Updated_By"])) { objcy_Coverage.Updated_By = Convert.ToString(reader["Updated_By"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Update_Date"])) { objcy_Coverage.Update_Date = Convert.ToDateTime(reader["Update_Date"], CultureInfo.InvariantCulture); }
            return objcy_Coverage;
        }
        protected RIMS_Base.Dal.CPolicyCoverage MapFrom(IDataReader reader)
        {
            RIMS_Base.Dal.CPolicyCoverage objcy_Coverage = new RIMS_Base.Dal.CPolicyCoverage();
            if (!Convert.IsDBNull(reader["Policy_Number"])) { objcy_Coverage.PolicyNumber = Convert.ToString(reader["Policy_Number"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["PK_Policy_Coverage_Id"])) { objcy_Coverage.PK_Policy_Coverage_Id = Convert.ToInt32(reader["PK_Policy_Coverage_Id"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FK_Policy"])) { objcy_Coverage.FK_Policy = Convert.ToDecimal(reader["FK_Policy"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Policy_Coverage"])) { objcy_Coverage.Policy_Coverage = Convert.ToString(reader["Policy_Coverage"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Policy_Deductible"])) { objcy_Coverage.Policy_Deductible = Convert.ToDecimal(reader["Policy_Deductible"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Occurrence_Limit"])) { objcy_Coverage.Occurrence_Limit = Convert.ToDecimal(reader["Occurrence_Limit"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Aggregate_Limit"])) { objcy_Coverage.Aggregate_Limit = Convert.ToDecimal(reader["Aggregate_Limit"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["GL_Rent_Damage"])) { objcy_Coverage.GL_Rent_Damage = Convert.ToDecimal(reader["GL_Rent_Damage"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["GL_Medical"])) { objcy_Coverage.GL_Medical = Convert.ToDecimal(reader["GL_Medical"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["GL_Products"])) { objcy_Coverage.GL_Products = Convert.ToDecimal(reader["GL_Products"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["AL_PIP"])) { objcy_Coverage.AL_PIP = Convert.ToDecimal(reader["AL_PIP"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["AL_Medical"])) { objcy_Coverage.AL_Medical = Convert.ToDecimal(reader["AL_Medical"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["AL_Uninsured"])) { objcy_Coverage.AL_Uninsured = Convert.ToString(reader["AL_Uninsured"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["AL_Underinsured"])) { objcy_Coverage.AL_Underinsured = Convert.ToString(reader["AL_Underinsured"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Umbrella"])) { objcy_Coverage.Umbrella = Convert.ToDecimal(reader["Umbrella"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Other_Policy_Type"])) { objcy_Coverage.Other_Policy_Type = Convert.ToString(reader["Other_Policy_Type"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FK_Policy_Feature_1"])) { objcy_Coverage.FK_Policy_Feature_1 = Convert.ToDecimal(reader["FK_Policy_Feature_1"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Deductible_1"])) { objcy_Coverage.Deductible_1 = Convert.ToDecimal(reader["Deductible_1"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Limit_1"])) { objcy_Coverage.Limit_1 = Convert.ToDecimal(reader["Limit_1"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FK_Policy_Feature_2"])) { objcy_Coverage.FK_Policy_Feature_2 = Convert.ToDecimal(reader["FK_Policy_Feature_2"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Deductible_2"])) { objcy_Coverage.Deductible_2 = Convert.ToDecimal(reader["Deductible_2"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Limit_2"])) { objcy_Coverage.Limit_2 = Convert.ToDecimal(reader["Limit_2"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FK_Policy_Feature_3"])) { objcy_Coverage.FK_Policy_Feature_3 = Convert.ToDecimal(reader["FK_Policy_Feature_3"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Deductible_3"])) { objcy_Coverage.Deductible_3 = Convert.ToDecimal(reader["Deductible_3"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Limit_3"])) { objcy_Coverage.Limit_3 = Convert.ToDecimal(reader["Limit_3"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FK_Policy_Feature_4"])) { objcy_Coverage.FK_Policy_Feature_4 = Convert.ToDecimal(reader["FK_Policy_Feature_4"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Deductible_4"])) { objcy_Coverage.Deductible_4 = Convert.ToDecimal(reader["Deductible_4"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Limit_4"])) { objcy_Coverage.Limit_4 = Convert.ToDecimal(reader["Limit_4"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FK_Policy_Feature_5"])) { objcy_Coverage.FK_Policy_Feature_5 = Convert.ToDecimal(reader["FK_Policy_Feature_5"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Deductible_5"])) { objcy_Coverage.Deductible_5 = Convert.ToDecimal(reader["Deductible_5"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Limit_5"])) { objcy_Coverage.Limit_5 = Convert.ToDecimal(reader["Limit_5"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FK_Policy_Feature_6"])) { objcy_Coverage.FK_Policy_Feature_6 = Convert.ToDecimal(reader["FK_Policy_Feature_6"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Deductible_6"])) { objcy_Coverage.Deductible_6 = Convert.ToDecimal(reader["Deductible_6"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Limit_6"])) { objcy_Coverage.Limit_6 = Convert.ToDecimal(reader["Limit_6"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Updated_By"])) { objcy_Coverage.Updated_By = Convert.ToString(reader["Updated_By"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Update_Date"])) { objcy_Coverage.Update_Date = Convert.ToDateTime(reader["Update_Date"], CultureInfo.InvariantCulture); }
            return objcy_Coverage;
        }
        protected RIMS_Base.Dal.CPolicyCoverage MapFromFeature(IDataReader reader)
        {
            RIMS_Base.Dal.CPolicyCoverage objcy_Coverage = new RIMS_Base.Dal.CPolicyCoverage();
            if (!Convert.IsDBNull(reader["Pk_PolicyFeature"])) { objcy_Coverage.PolicyFeature_Pk_Id = Convert.ToDecimal(reader["Pk_PolicyFeature"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["PolicyFeature"])) { objcy_Coverage.PolicyFeature = Convert.ToString(reader["PolicyFeature"], CultureInfo.InvariantCulture); }
            
            return objcy_Coverage;
        }
       
    }
}
