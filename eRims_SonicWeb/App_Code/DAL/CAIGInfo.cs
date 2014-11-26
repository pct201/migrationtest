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


    public class CAIGInfo : RIMS_Base.CAIGInfo
    {

        public override int AIGInfo_InsertUpdate(RIMS_Base.CAIGInfo ObjInfo)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            int nRetVal = 0;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("AIG_InsertUpdate");
                dbHelper.AddInParameter(cmd, "@PK_AIG_Info_ID", DbType.Int32, ObjInfo.PK_AIG_Info_ID);
                dbHelper.AddParameter(cmd, "@AIGRM_Contract_Number", DbType.String, ParameterDirection.InputOutput, "AIGRM_Contract_Number", DataRowVersion.Current, ObjInfo.AIGRM_Contract_Number);
                dbHelper.AddInParameter(cmd, "@AIGRM_Start_Date", DbType.DateTime, ObjInfo.AIGRM_Start_Date);
                dbHelper.AddInParameter(cmd, "@AIGRM_End_Date", DbType.DateTime, ObjInfo.AIGRM_End_Date);
                dbHelper.AddInParameter(cmd, "@Updated_By", DbType.String, ObjInfo.Updated_By);
                dbHelper.AddInParameter(cmd, "@Update_Date", DbType.DateTime, ObjInfo.Update_Date);
                dbHelper.ExecuteNonQuery(cmd);
                nRetVal = int.Parse(dbHelper.GetParameterValue(cmd, "@PK_AIG_Info_ID").ToString());
                
                return nRetVal;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            { dbHelper = null; cmd.Dispose(); cmd = null; }
        }
        public override int AIG_Info_Delete(System.String lPK_AIG_Info_ID)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            int nRetVal = -1;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("AIG_Delete");
                dbHelper.AddInParameter(cmd, "@PK_AIG_Info_ID", DbType.String, lPK_AIG_Info_ID);
                nRetVal = dbHelper.ExecuteNonQuery(cmd);
                dbHelper = null; cmd.Dispose(); cmd = null;
                return nRetVal;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public override string ActivateInactivateInfo(string strIDs, int intModifiedBy, bool bIsActive)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            int nRetVal = -1;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("AIG_ActivateInactivateInfos");
                dbHelper.AddParameter(cmd, "@PK_AIG_Info_IDs", DbType.String, ParameterDirection.InputOutput, "PK_AIG_Info_IDs", DataRowVersion.Current, strIDs);
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
        public override List<RIMS_Base.CAIGInfo> GetAll()
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("AIG_Select");
                IDataReader reader = dbHelper.ExecuteReader(cmd);
                List<RIMS_Base.CAIGInfo> results = new List<RIMS_Base.CAIGInfo>();
                while (reader.Read())
                {
                    CAIGInfo objInfo = new CAIGInfo();
                    objInfo = MapFrom(reader);
                    results.Add(objInfo);
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


        public override List<RIMS_Base.CAIGInfo> AIGInfo_GetByID(System.Decimal pK_AIG_Info_ID)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("AIG_Select");
                dbHelper.AddInParameter(cmd, "@PK_AIG_Info_ID", DbType.Decimal, pK_AIG_Info_ID);
                List<RIMS_Base.CAIGInfo> results = new List<RIMS_Base.CAIGInfo>();
                IDataReader reader = dbHelper.ExecuteReader(cmd);
                CAIGInfo objInfo = new CAIGInfo();
                if (reader.Read())
                {
                    objInfo = MapFrom(reader);
                    results.Add(objInfo);
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


        protected RIMS_Base.Dal.CAIGInfo MapFrom(IDataReader reader)
        {
            RIMS_Base.Dal.CAIGInfo objInfo = new RIMS_Base.Dal.CAIGInfo();
            if (!Convert.IsDBNull(reader["PK_AIG_Info_ID"])) { objInfo.PK_AIG_Info_ID = Convert.ToInt32(reader["PK_AIG_Info_ID"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["AIGRM_Contract_Number"])) { objInfo.AIGRM_Contract_Number = Convert.ToString(reader["AIGRM_Contract_Number"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["AIGRM_Start_Date"])) { objInfo.AIGRM_Start_Date = Convert.ToDateTime(reader["AIGRM_Start_Date"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["AIGRM_End_Date"])) { objInfo.AIGRM_End_Date = Convert.ToDateTime(reader["AIGRM_End_Date"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Updated_By"])) { objInfo.Updated_By = Convert.ToString(reader["Updated_By"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Update_Date"])) { objInfo.Update_Date = Convert.ToDateTime(reader["Update_Date"], CultureInfo.InvariantCulture); }
            return objInfo;
        }

        public override List<RIMS_Base.CAIGInfo> Get_Search_Data(System.String m_strColumn, System.String m_strCriteria)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("AIG_Search_Data");
                dbHelper.AddInParameter(cmd, "@ColumnName", DbType.String, m_strColumn.Replace("'", "''")); ;
                dbHelper.AddInParameter(cmd, "@Criteria", DbType.String, m_strCriteria.Replace("'", "''"));
                List<RIMS_Base.CAIGInfo> results = new List<RIMS_Base.CAIGInfo>();
                IDataReader reader = dbHelper.ExecuteReader(cmd);
                CAIGInfo objoyee = new CAIGInfo();
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


    }


}

