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


    public class CEmployeeTraining : RIMS_Base.CEmployeeTraining
    {

        public override int InsertUpdate_Employee_Training(RIMS_Base.CEmployeeTraining Objoyee_Training)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            int nRetVal = 0;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("EmployeeTraining_InsertUpdate");
                dbHelper.AddParameter(cmd, "@PK_Employee_Training_Id", DbType.Int32, ParameterDirection.InputOutput, "PK_Employee_Training_Id", DataRowVersion.Current, Objoyee_Training.PK_Employee_Training_Id);
                dbHelper.AddInParameter(cmd, "@Employee_FK", DbType.Decimal, Objoyee_Training.Employee_FK);
                dbHelper.AddInParameter(cmd, "@Training_Description", DbType.String, Objoyee_Training.Training_Description);
                dbHelper.AddInParameter(cmd, "@Training_Date", DbType.DateTime, Objoyee_Training.Training_Date);
                dbHelper.AddInParameter(cmd, "@Training_Status", DbType.Int32, Objoyee_Training.Training_Status);
                dbHelper.AddInParameter(cmd, "@Retrain_Date", DbType.DateTime, Objoyee_Training.Retrain_Date);
                dbHelper.AddInParameter(cmd, "@Training_Type", DbType.Int32, Objoyee_Training.Training_Type);
                dbHelper.AddInParameter(cmd, "@Training_Grade", DbType.Int32, Objoyee_Training.Training_Grade);
                dbHelper.AddInParameter(cmd, "@Updated_By", DbType.String, Objoyee_Training.Updated_By);
                dbHelper.AddInParameter(cmd, "@Update_Date", DbType.DateTime, Objoyee_Training.Update_Date);
                dbHelper.ExecuteNonQuery(cmd);
                nRetVal = int.Parse(dbHelper.GetParameterValue(cmd, "@PK_Employee_Training_Id").ToString());
               
                return nRetVal;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            { dbHelper = null; cmd.Dispose(); cmd = null; }
        }
        public override int DeleteEmployee_Training(System.String lPK_Employee_Training_Id)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            int nRetVal = -1;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("EmployeeTraining_Delete");
                dbHelper.AddInParameter(cmd, "@PK_Employee_Training_Id", DbType.String, lPK_Employee_Training_Id);
                nRetVal = dbHelper.ExecuteNonQuery(cmd);
                dbHelper = null; cmd.Dispose(); cmd = null;
                return nRetVal;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public override string ActivateInactivateEmployee_Training(string strIDs, int intModifiedBy, bool bIsActive)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            int nRetVal = -1;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Emp_ActivateInactivateoyee_Trainings");
                dbHelper.AddParameter(cmd, "@PK_Employee_Training_Ids", DbType.String, ParameterDirection.InputOutput, "PK_Employee_Training_Ids", DataRowVersion.Current, strIDs);
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
        public override List<RIMS_Base.CEmployeeTraining> GetAll()
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("EmployeeTraining_Select");
                IDataReader reader = dbHelper.ExecuteReader(cmd);
                List<RIMS_Base.CEmployeeTraining> results = new List<RIMS_Base.CEmployeeTraining>();
                while (reader.Read())
                {
                    CEmployeeTraining objoyee_Training = new CEmployeeTraining();
                    objoyee_Training = MapFrom(reader);
                    results.Add(objoyee_Training);
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
        public override List<RIMS_Base.CEmployeeTraining> GetEmployee_TrainingByID(System.Decimal pK_Employee_Training_Id)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("EmployeeTraining_Select");
                dbHelper.AddInParameter(cmd, "@PK_Employee_Training_Id", DbType.Decimal, pK_Employee_Training_Id);
                List<RIMS_Base.CEmployeeTraining> results = new List<RIMS_Base.CEmployeeTraining>();
                IDataReader reader = dbHelper.ExecuteReader(cmd);
                CEmployeeTraining objoyee_Training = new CEmployeeTraining();
                if (reader.Read())
                {
                    objoyee_Training = MapFrom(reader);
                    results.Add(objoyee_Training);
                }
                reader.Close();
                cmd = null;
                dbHelper = null;

               // return objoyee_Training;
                return results;
            }
            catch (Exception)
            {
                throw;
            }
        }
        protected RIMS_Base.Dal.CEmployeeTraining MapFrom(IDataReader reader)
        {
            RIMS_Base.Dal.CEmployeeTraining objoyee_Training = new RIMS_Base.Dal.CEmployeeTraining();
            if (!Convert.IsDBNull(reader["PK_Employee_Training_Id"])) { objoyee_Training.PK_Employee_Training_Id = Convert.ToInt32(reader["PK_Employee_Training_Id"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Employee_FK"])) { objoyee_Training.Employee_FK = Convert.ToDecimal(reader["Employee_FK"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Training_Description"])) { objoyee_Training.Training_Description = Convert.ToString(reader["Training_Description"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Training_Date"])) { objoyee_Training.Training_Date = Convert.ToDateTime(reader["Training_Date"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Training_Status"])) { objoyee_Training.Training_Status = Convert.ToInt32(reader["Training_Status"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Retrain_Date"])) { objoyee_Training.Retrain_Date = Convert.ToDateTime(reader["Retrain_Date"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Training_Type"])) { objoyee_Training.Training_Type = Convert.ToInt32(reader["Training_Type"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Training_Grade"])) { objoyee_Training.Training_Grade = Convert.ToInt32(reader["Training_Grade"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Updated_By"])) { objoyee_Training.Updated_By = Convert.ToString(reader["Updated_By"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Update_Date"])) { objoyee_Training.Update_Date = Convert.ToDateTime(reader["Update_Date"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Training_StatusText"])) { objoyee_Training.Training_StatusText = Convert.ToString(reader["Training_StatusText"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Training_TypeText"])) { objoyee_Training.Training_TypeText = Convert.ToString(reader["Training_TypeText"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Training_GradeText"])) { objoyee_Training.Training_GradeText = Convert.ToString(reader["Training_GradeText"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["First_Name"])) { objoyee_Training.First_Name = Convert.ToString(reader["First_Name"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Middle_Name"])) { objoyee_Training.Middle_Name = Convert.ToString(reader["Middle_Name"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Last_Name"])) { objoyee_Training.Last_Name = Convert.ToString(reader["Last_Name"], CultureInfo.InvariantCulture); }
            
            return objoyee_Training;
        }
        public override List<RIMS_Base.CEmployeeTraining> Get_Search_Data(System.String m_strColumn, System.String m_strCriteria)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("EmployeeTraining_Search_Data");
                dbHelper.AddInParameter(cmd, "@ColumnName", DbType.String, m_strColumn.Replace("'", "''"));
                dbHelper.AddInParameter(cmd, "@Criteria", DbType.String, m_strCriteria.Replace("'", "''"));

                List<RIMS_Base.CEmployeeTraining> results = new List<RIMS_Base.CEmployeeTraining>();
                IDataReader reader = dbHelper.ExecuteReader(cmd);
                CEmployeeTraining obj_Details = new CEmployeeTraining();
                while (reader.Read())
                {
                    obj_Details = MapFrom(reader);
                    results.Add(obj_Details);
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
        public override List<RIMS_Base.CEmployeeTraining> GetTrainingGrade()
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("[Select_TrainingGrade]");
                IDataReader reader = dbHelper.ExecuteReader(cmd);
                List<RIMS_Base.CEmployeeTraining> results = new List<RIMS_Base.CEmployeeTraining>();
                while (reader.Read())
                {
                    CEmployeeTraining obje = new CEmployeeTraining();
                    obje = MapFromGrade(reader);
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
        public override List<RIMS_Base.CEmployeeTraining> GetTrainingStatus()
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("[Select_TrainingStatus]");
                IDataReader reader = dbHelper.ExecuteReader(cmd);
                List<RIMS_Base.CEmployeeTraining> results = new List<RIMS_Base.CEmployeeTraining>();
                while (reader.Read())
                {
                    CEmployeeTraining obje = new CEmployeeTraining();
                    obje = MapFromStatus(reader);
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
        public override List<RIMS_Base.CEmployeeTraining> GetTrainingType()
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("[Select_TrainingType]");
                IDataReader reader = dbHelper.ExecuteReader(cmd);
                List<RIMS_Base.CEmployeeTraining> results = new List<RIMS_Base.CEmployeeTraining>();
                while (reader.Read())
                {
                    CEmployeeTraining obje = new CEmployeeTraining();
                    obje = MapFromType(reader);
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
        protected RIMS_Base.Dal.CEmployeeTraining MapFromType(IDataReader reader)
        {
            RIMS_Base.Dal.CEmployeeTraining obj_Type = new RIMS_Base.Dal.CEmployeeTraining();
            if (!Convert.IsDBNull(reader["PK_ID"])) { obj_Type.Training_Type = Convert.ToInt32(reader["PK_ID"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FLD_Desc"])) { obj_Type.Training_TypeText = Convert.ToString(reader["FLD_Desc"], CultureInfo.InvariantCulture); }
            return obj_Type;
        }
        protected RIMS_Base.Dal.CEmployeeTraining MapFromStatus(IDataReader reader)
        {
            RIMS_Base.Dal.CEmployeeTraining obj_Type = new RIMS_Base.Dal.CEmployeeTraining();
            if (!Convert.IsDBNull(reader["PK_ID"])) { obj_Type.Training_Status = Convert.ToInt32(reader["PK_ID"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FLD_Desc"])) { obj_Type.Training_StatusText = Convert.ToString(reader["FLD_Desc"], CultureInfo.InvariantCulture); }
            return obj_Type;
        }
        protected RIMS_Base.Dal.CEmployeeTraining MapFromGrade(IDataReader reader)
        {
            RIMS_Base.Dal.CEmployeeTraining obj_Type = new RIMS_Base.Dal.CEmployeeTraining();
            if (!Convert.IsDBNull(reader["PK_ID"])) { obj_Type.Training_Grade = Convert.ToInt32(reader["PK_ID"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FLD_Desc"])) { obj_Type.Training_GradeText = Convert.ToString(reader["FLD_Desc"], CultureInfo.InvariantCulture); }
            return obj_Type;
        }
    }


}

