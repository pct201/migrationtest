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
using System.Data.SqlClient;
#endregion

namespace RIMS_Base.Dal
{
    [Serializable]


    public class CDiary : RIMS_Base.CDiary
    {
        public override int UpdateClaimAssign(RIMS_Base.CDiary obj)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            int nRetVal = -1;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Claim_Assign_U_Clear");                                                         
                dbHelper.AddParameter(cmd, "@Pk_Assign_Id", DbType.String, ParameterDirection.InputOutput, "Pk_Assign_Id", DataRowVersion.Current, obj.Pk_Assign_Id.ToString());
                dbHelper.ExecuteNonQuery(cmd);
                nRetVal = int.Parse(dbHelper.GetParameterValue(cmd, "@Pk_Assign_Id").ToString());
                return nRetVal;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            { dbHelper = null; cmd.Dispose(); cmd = null; }
        }

        public override void UpdateDiaryStatus(string Pk_Diary_Id)
        {
            Database dbHelper = null;
            DbCommand cmd = null;            
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Diary_UpdateStatus");
                dbHelper.AddInParameter(cmd, "@Pk_Diary_Id", DbType.String, Pk_Diary_Id);
                dbHelper.ExecuteNonQuery(cmd);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            { dbHelper = null; cmd.Dispose(); cmd = null; }

        }

        public override int InsertClaimAssign(RIMS_Base.CDiary ObjM_ASSIGN)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            int nRetVal = -1;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("CLAIM_ASSIGN_InsertUpdate");
                dbHelper.AddParameter(cmd, "@Pk_Assign_Id", DbType.Int32, ParameterDirection.InputOutput, "Pk_Assign_Id", DataRowVersion.Current, ObjM_ASSIGN.Pk_Assign_Id);
                dbHelper.AddInParameter(cmd, "@Claim_Number", DbType.String, ObjM_ASSIGN.ClaimNo);
                dbHelper.AddInParameter(cmd, "@claim_type", DbType.String, ObjM_ASSIGN.ClaimType);
                dbHelper.AddInParameter(cmd, "@Assigned_By", DbType.String, ObjM_ASSIGN.AssignBy);
                dbHelper.AddInParameter(cmd, "@Note", DbType.String, ObjM_ASSIGN.Note);
                dbHelper.AddInParameter(cmd, "@clear", DbType.String, ObjM_ASSIGN.Clear);
                dbHelper.AddInParameter(cmd, "@Assigned_To", DbType.String, ObjM_ASSIGN.Assigned_To);
                dbHelper.ExecuteNonQuery(cmd);
                nRetVal = int.Parse(dbHelper.GetParameterValue(cmd, "@Pk_Assign_Id").ToString());
                return nRetVal;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            { dbHelper = null; cmd.Dispose(); cmd = null; }
        }
        public override int InsertUpdateDiary(RIMS_Base.CDiary Objy)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            int nRetVal = -1;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Diary_InsertUpdate");
                dbHelper.AddParameter(cmd, "@PK_Diary_ID", DbType.Int32, ParameterDirection.InputOutput, "PK_Diary_ID", DataRowVersion.Current, Objy.PK_Diary_ID);
                dbHelper.AddInParameter(cmd, "@Table_Name", DbType.String, Objy.Table_Name);
                dbHelper.AddInParameter(cmd, "@FK_Table_Name", DbType.Decimal, Objy.FK_Table_Name);
                dbHelper.AddInParameter(cmd, "@DateOfNoteEntry", DbType.DateTime, Objy.DateOfNoteEntry);
                dbHelper.AddInParameter(cmd, "@UserDiary", DbType.String, Objy.UserDiary);
                dbHelper.AddInParameter(cmd, "@File_Number", DbType.String, Objy.File_Number);
                dbHelper.AddInParameter(cmd, "@Note", DbType.String, Objy.Note);
                dbHelper.AddInParameter(cmd, "@Clear", DbType.String, Objy.Clear);
                dbHelper.AddInParameter(cmd, "@Updated_By", DbType.String, Objy.Updated_By);
                dbHelper.AddInParameter(cmd, "@Update_Date", DbType.DateTime, Objy.Update_Date);
                dbHelper.AddInParameter(cmd, "@Assigned_To", DbType.String, Objy.Assigned_To);
                dbHelper.AddInParameter(cmd, "@Diary_Date", DbType.DateTime, Objy.Diary_Date);
                dbHelper.AddInParameter(cmd, "@FK_Diary_Module", DbType.Int32 , Objy.FK_Diary_Module );
                dbHelper.AddInParameter(cmd, "@FK_LU_Location_ID", DbType.Int32, Objy.FK_LU_Location_ID);
                dbHelper.AddInParameter(cmd, "@FK_LU_Task_Type", DbType.Int32, Objy.FK_LU_Task_Type);
                dbHelper.AddInParameter(cmd, "@Identification_Field", DbType.String , Objy.Identification_Field);

                dbHelper.ExecuteNonQuery(cmd);
                nRetVal = int.Parse(dbHelper.GetParameterValue(cmd, "@PK_Diary_ID").ToString());

                return nRetVal;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            { dbHelper = null; cmd.Dispose(); cmd = null; }
        }
        public override int DeleteDiary(System.String lPK_Diary_ID)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            int nRetVal = -1;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Diary_Delete");
                dbHelper.AddInParameter(cmd, "@PK_Diary_ID", DbType.String, lPK_Diary_ID);
                nRetVal = dbHelper.ExecuteNonQuery(cmd);
                dbHelper = null; cmd.Dispose(); cmd = null;
                return nRetVal;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public override string ActivateInactivateDiary(string strIDs, int intModifiedBy, bool bIsActive)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            int nRetVal = -1;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Dia_ActivateInactivateys");
                dbHelper.AddParameter(cmd, "@PK_Diary_IDs", DbType.String, ParameterDirection.InputOutput, "PK_Diary_IDs", DataRowVersion.Current, strIDs);
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
        public override List<RIMS_Base.CDiary> GetAll()
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Diary_SelectDetail");
                IDataReader reader = dbHelper.ExecuteReader(cmd);
                List<RIMS_Base.CDiary> results = new List<RIMS_Base.CDiary>();
                while (reader.Read())
                {
                    CDiary objy = new CDiary();
                    objy = MapFrom(reader);
                    results.Add(objy);
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


        public override List<RIMS_Base.CDiary> GetyByID(System.Decimal pK_Diary_ID)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Diary_SelectDetail");
                dbHelper.AddInParameter(cmd, "@PK_Diary_ID", DbType.Decimal, pK_Diary_ID);                
                List<RIMS_Base.CDiary> result = new List<RIMS_Base.CDiary>();
                IDataReader reader = dbHelper.ExecuteReader(cmd);
                CDiary objy = new CDiary();
                if (reader.Read())
                {
                    objy = MapFrom(reader);
                    result.Add(objy);
                }
                reader.Close();
                cmd = null;
                dbHelper = null;

                //return objy;
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public override List<RIMS_Base.CDiary> GetyByID(System.Decimal pK_Diary_ID, System.Boolean isView)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Diary_SelectDetail");
                dbHelper.AddInParameter(cmd, "@PK_Diary_ID", DbType.Decimal, pK_Diary_ID);
                dbHelper.AddInParameter(cmd, "@isView", DbType.Boolean, isView);
                List<RIMS_Base.CDiary> result = new List<RIMS_Base.CDiary>();
                IDataReader reader = dbHelper.ExecuteReader(cmd);
                CDiary objy = new CDiary();
                if (reader.Read())
                {
                    objy = MapFrom(reader);
                    result.Add(objy);
                }
                reader.Close();
                cmd = null;
                dbHelper = null;

                //return objy;
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public override List<RIMS_Base.CDiary> Search_DiaryData(string ColumnName, string Value, decimal Fk_Table_Name, string Table_Name, string LocationIds)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Search_DiaryData");
                dbHelper.AddInParameter(cmd, "@ColumnName", DbType.String, ColumnName);
                dbHelper.AddInParameter(cmd, "@Criteria", DbType.String, Value);
                dbHelper.AddInParameter(cmd, "@FK_Table_Name", DbType.Decimal, Fk_Table_Name);
                dbHelper.AddInParameter(cmd, "@Table_Name", DbType.String, Table_Name);
                dbHelper.AddInParameter(cmd, "@Employee_Id", DbType.Int32, clsSession.CurrentLoginEmployeeId);
                dbHelper.AddInParameter(cmd, "@LocationIds", DbType.String, LocationIds);
                dbHelper.AddInParameter(cmd, "@User_ID", DbType.Int32, clsSession.UserID);

                List<RIMS_Base.CDiary> results = new List<RIMS_Base.CDiary>();
                IDataReader reader = dbHelper.ExecuteReader(cmd);
                CDiary obj_Details = new CDiary();
                while (reader.Read())
                {
                    obj_Details = MapFrom(reader);
                    results.Add(obj_Details);
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

        public override List<RIMS_Base.CDiary> Search_DiaryData(string ColumnName, string Value, decimal Fk_Table_Name, string Table_Name)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Search_DiaryData");
                dbHelper.AddInParameter(cmd, "@ColumnName", DbType.String, ColumnName);
                dbHelper.AddInParameter(cmd, "@Criteria", DbType.String, Value);
                dbHelper.AddInParameter(cmd, "@FK_Table_Name", DbType.Decimal, Fk_Table_Name);
                dbHelper.AddInParameter(cmd, "@Table_Name", DbType.String, Table_Name);
                dbHelper.AddInParameter(cmd, "@Employee_Id", DbType.Int32, clsSession.CurrentLoginEmployeeId);                

                List<RIMS_Base.CDiary> results = new List<RIMS_Base.CDiary>();
                IDataReader reader = dbHelper.ExecuteReader(cmd);
                CDiary obj_Details = new CDiary();
                while (reader.Read())
                {
                    obj_Details = MapFrom(reader);
                    results.Add(obj_Details);
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

        protected RIMS_Base.Dal.CDiary MapFrom(IDataReader reader)
        {
            RIMS_Base.Dal.CDiary objy = new RIMS_Base.Dal.CDiary();
            if (!Convert.IsDBNull(reader["PK_Diary_ID"])) { objy.PK_Diary_ID = Convert.ToInt32(reader["PK_Diary_ID"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Table_Name"])) { objy.Table_Name = Convert.ToString(reader["Table_Name"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FK_Table_Name"])) { objy.FK_Table_Name = Convert.ToDecimal(reader["FK_Table_Name"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["DateOfNoteEntry"])) { objy.DateOfNoteEntry = Convert.ToDateTime(reader["DateOfNoteEntry"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["UserDiary"])) { objy.UserDiary = Convert.ToString(reader["UserDiary"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["File_Number"])) { objy.File_Number = Convert.ToString(reader["File_Number"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Note"])) { objy.Note = Convert.ToString(reader["Note"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Clear"])) { objy.Clear = Convert.ToString(reader["Clear"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Updated_By"])) { objy.Updated_By = Convert.ToString(reader["Updated_By"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Update_Date"])) { objy.Update_Date = Convert.ToDateTime(reader["Update_Date"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Assigned_To"])) { objy.Assigned_To = Convert.ToString(reader["Assigned_To"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Diary_Date"])) { objy.Diary_Date = Convert.ToDateTime(reader["Diary_Date"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FK_Diary_Module"])) { objy.FK_Diary_Module = Convert.ToInt32(reader["FK_Diary_Module"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FK_LU_Location_ID"])) { objy.FK_LU_Location_ID = Convert.ToInt32(reader["FK_LU_Location_ID"], CultureInfo.InvariantCulture); }              
            if (!Convert.IsDBNull(reader["Module_Name"])) { objy.Module_Name = Convert.ToString(reader["Module_Name"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Location"])) { objy.Location = Convert.ToString(reader["Location"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FK_LU_Task_Type"])) { objy.FK_LU_Task_Type = Convert.ToInt32(reader["FK_LU_Task_Type"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Task_Type"])) { objy.Task_Type = Convert.ToString(reader["Task_Type"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Region"])) { objy.Region = Convert.ToString(reader["Region"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["IsEdit"])) { objy.isEdit = Convert.ToBoolean(reader["IsEdit"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["IsView"])) { objy.isView = Convert.ToBoolean(reader["IsView"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Identification_Field"])) { objy.Identification_Field = Convert.ToString(reader["Identification_Field"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["First_Report_Wizard_ID"])) { objy.First_Report_Wizard_ID = Convert.ToInt32(reader["First_Report_Wizard_ID"], CultureInfo.InvariantCulture); }
            
            return objy;
        }

        public override DataSet GetClaimToAssign(decimal pK_Security_Id)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            DataSet m_dsCommon = new DataSet();
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Diary_GetClaimForAssign");
                dbHelper.AddInParameter(cmd, "@PK_Security_Id", DbType.Decimal, pK_Security_Id);
                List<RIMS_Base.CDiary> result = new List<RIMS_Base.CDiary>();
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
        public override DataSet GetUserToAssign(System.String m_strCostCenter)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            DataSet m_dsCommon1 = new DataSet();
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Diary_Assign_S_User");
                dbHelper.AddInParameter(cmd, "@CostCenter", DbType.String, m_strCostCenter);
                List<RIMS_Base.CDiary> result = new List<RIMS_Base.CDiary>();
                m_dsCommon1 = dbHelper.ExecuteDataSet(cmd);
                cmd = null;
                dbHelper = null;
                return m_dsCommon1;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public override List<RIMS_Base.CDiary> Search_DiaryData(string Value, decimal pK_Security_Id)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Diary_S_Search");
                dbHelper.AddInParameter(cmd, "@AssignTo", DbType.String, Value.Replace("'",""));
                dbHelper.AddInParameter(cmd, "@PK_Security_Id", DbType.Decimal, pK_Security_Id);
                List<RIMS_Base.CDiary> results = new List<RIMS_Base.CDiary>();
                IDataReader reader = dbHelper.ExecuteReader(cmd);
                CDiary obj_Details = new CDiary();
                while (reader.Read())
                {
                    obj_Details = MapFromSearchDiary(reader);
                    results.Add(obj_Details);
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
        public override DataSet GetAssignToUser(System.String m_strCostCenter)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            DataSet m_dsCommon1 = new DataSet();
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Diary_Assign_To");
                dbHelper.AddInParameter(cmd, "@CostCenter", DbType.String, m_strCostCenter);
                List<RIMS_Base.CDiary> result = new List<RIMS_Base.CDiary>();
                m_dsCommon1 = dbHelper.ExecuteDataSet(cmd);
                cmd = null;
                dbHelper = null;
                return m_dsCommon1;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public override DataSet GetDiaryLabel()
        {
            DbCommand cmd = null;
            DataSet dstDataset = null;
            Database dbHelper = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Get_WC_DiaryLabel");
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

        /// <summary>
        ///  return dataset of module for diary module
        /// </summary>
        /// <returns></returns>
        public override DataSet GetDiaryModule()
        {
            DbCommand cmd = null;
            DataSet dstDataset = null;
            Database dbHelper = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Get_Diary_Module_SelectAll");
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

        /// <summary>
        /// return dataset of identification fields for diary 
        /// </summary>
        /// <param name="PK_Diary_Module"> pk diary module </param>
        /// <param name="PK_LU_Location_ID">pk sonic location </param>
        /// <returns></returns>
        public override DataSet GetDiaryIdentificationField(int PK_Diary_Module, int PK_LU_Location_ID,int FK_Table_Name)
        {
            DbCommand cmd = null;
            DataSet dstDataset = null;
            Database dbHelper = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Diary_GetIdentification_Fields");
                dbHelper.AddInParameter(cmd, "@PK_Diary_Module", DbType.Int32, PK_Diary_Module);
                dbHelper.AddInParameter(cmd, "@PK_LU_Location_ID", DbType.Int32, PK_LU_Location_ID);
                dbHelper.AddInParameter(cmd, "@FK_Table_Name", DbType.Int32, FK_Table_Name);
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



        protected RIMS_Base.Dal.CDiary MapFromSearchDiary(IDataReader reader)
        {
            RIMS_Base.Dal.CDiary objy = new RIMS_Base.Dal.CDiary();
            if (!Convert.IsDBNull(reader["Pk_Assign_Id"])) { objy.Pk_Assign_Id = Convert.ToInt32(reader["Pk_Assign_Id"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Claim_Number"])) { objy.ClaimNo = Convert.ToString(reader["Claim_Number"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["User_Role"])) { objy.AssignBy = Convert.ToString(reader["AssignBy"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Note"])) { objy.Note = Convert.ToString(reader["Note"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["assigned_Date"])) { objy.Diary_Date = Convert.ToDateTime(reader["assigned_Date"], CultureInfo.InvariantCulture); }
            return objy;
        }
    }
}


