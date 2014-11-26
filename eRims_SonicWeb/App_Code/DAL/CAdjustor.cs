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


    public class CAdjustor : RIMS_Base.CAdjustor
    {

        public override int InsertUpdateAdjustor(RIMS_Base.CAdjustor Objstor_Notes)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            int nRetVal = -1;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Adjustor_InsertUpdate");
                dbHelper.AddParameter(cmd, "@PK_Adjustor_Notes_ID", DbType.Int32, ParameterDirection.InputOutput, "PK_Adjustor_Notes_ID", DataRowVersion.Current, Objstor_Notes.PK_Adjustor_Notes_ID);
                dbHelper.AddInParameter(cmd, "@Table_Name", DbType.String, Objstor_Notes.Table_Name);
                dbHelper.AddInParameter(cmd, "@FK_Table_Name", DbType.Decimal, Objstor_Notes.FK_Table_Name);
                dbHelper.AddInParameter(cmd, "@Activity_Date", DbType.DateTime, Objstor_Notes.Activity_Date);
                dbHelper.AddInParameter(cmd, "@Date_Of_Note", DbType.DateTime, Objstor_Notes.Date_Of_Note);
                dbHelper.AddInParameter(cmd, "@Author_Of_Note", DbType.String, Objstor_Notes.Author_Of_Note);
                dbHelper.AddInParameter(cmd, "@Note_Type", DbType.String, Objstor_Notes.Note_Type);
                dbHelper.AddInParameter(cmd, "@Update_By", DbType.String, Objstor_Notes.Update_By);
                dbHelper.AddInParameter(cmd, "@Notes", DbType.String, Objstor_Notes.Notes);
                dbHelper.AddInParameter(cmd, "@Updated_By", DbType.String, Objstor_Notes.Updated_By);
                dbHelper.AddInParameter(cmd, "@Update_Date", DbType.DateTime, Objstor_Notes.Update_Date);
                dbHelper.ExecuteNonQuery(cmd);
                nRetVal = int.Parse(dbHelper.GetParameterValue(cmd, "@PK_Adjustor_Notes_ID").ToString());

                return nRetVal;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            { dbHelper = null; cmd.Dispose(); cmd = null; }
        }
        public override int DeleteAdjustor(System.String lPK_Adjustor_Notes_ID)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            int nRetVal = -1;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Adjustor_Delete");
                dbHelper.AddInParameter(cmd, "@PK_Adjustor_Notes_ID", DbType.String, lPK_Adjustor_Notes_ID);
                nRetVal = dbHelper.ExecuteNonQuery(cmd);
                dbHelper = null; cmd.Dispose(); cmd = null;
                return nRetVal;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public override string ActivateInactivAdjustor(string strIDs, int intModifiedBy, bool bIsActive)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            int nRetVal = -1;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Adj_ActivateInactivatestor_Notess");
                dbHelper.AddParameter(cmd, "@PK_Adjustor_Notes_IDs", DbType.String, ParameterDirection.InputOutput, "PK_Adjustor_Notes_IDs", DataRowVersion.Current, strIDs);
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
        public override List<RIMS_Base.CAdjustor> GetAll()
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Adjustor_SelectDetails");
                IDataReader reader = dbHelper.ExecuteReader(cmd);
                List<RIMS_Base.CAdjustor> results = new List<RIMS_Base.CAdjustor>();
                while (reader.Read())
                {
                    CAdjustor objstor_Notes = new CAdjustor();
                    objstor_Notes = MapFrom(reader);
                    results.Add(objstor_Notes);
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


        public override List<RIMS_Base.CAdjustor> GetAdjustorByID(System.Int32 pK_Adjustor_Notes_ID)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Adjustor_SelectDetails");
                dbHelper.AddInParameter(cmd, "@PK_Adjustor_Notes_ID", DbType.Decimal, pK_Adjustor_Notes_ID);
                List<RIMS_Base.CAdjustor> result = new List<RIMS_Base.CAdjustor>();
                IDataReader reader = dbHelper.ExecuteReader(cmd);
                CAdjustor objstor_Notes = new CAdjustor();
                if (reader.Read())
                {
                    objstor_Notes = MapFrom(reader);
                    result.Add(objstor_Notes);
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

        public override List<RIMS_Base.CAdjustor> SearchAdjustorData(string FieldName, string FieldVal, decimal Fk_Table_Name, string Table_Name)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Search_AdjustorData");
                dbHelper.AddInParameter(cmd, "@Field_Name", DbType.String, FieldName);
                dbHelper.AddInParameter(cmd, "@Field_Value", DbType.String, FieldVal);
                dbHelper.AddInParameter(cmd, "@Fk_Table_Name", DbType.Decimal, Fk_Table_Name);
                dbHelper.AddInParameter(cmd, "@Table_Name", DbType.String, Table_Name);
                List<RIMS_Base.CAdjustor> result = new List<RIMS_Base.CAdjustor>();
                IDataReader reader = dbHelper.ExecuteReader(cmd);
                CAdjustor objstor_Notes = new CAdjustor();
                while (reader.Read())
                {
                    objstor_Notes = MapFrom(reader);
                    result.Add(objstor_Notes);
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
        public override DataSet GetAdjustorLabel()
        {
            DbCommand cmd = null;
            DataSet dstDataset = null;
            Database dbHelper = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Get_AdjustorNote_Label");
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
        protected RIMS_Base.Dal.CAdjustor MapFrom(IDataReader reader)
        {
            RIMS_Base.Dal.CAdjustor objstor_Notes = new RIMS_Base.Dal.CAdjustor();
            if (!Convert.IsDBNull(reader["PK_Adjustor_Notes_ID"])) { objstor_Notes.PK_Adjustor_Notes_ID = Convert.ToInt32(reader["PK_Adjustor_Notes_ID"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Table_Name"])) { objstor_Notes.Table_Name = Convert.ToString(reader["Table_Name"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FK_Table_Name"])) { objstor_Notes.FK_Table_Name = Convert.ToDecimal(reader["FK_Table_Name"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Activity_Date"])) { objstor_Notes.Activity_Date = Convert.ToDateTime(reader["Activity_Date"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Date_Of_Note"])) { objstor_Notes.Date_Of_Note = Convert.ToDateTime(reader["Date_Of_Note"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Author_Of_Note"])) { objstor_Notes.Author_Of_Note = Convert.ToString(reader["Author_Of_Note"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Note_Type"])) { objstor_Notes.Note_Type = Convert.ToString(reader["Note_Type"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Update_By"])) { objstor_Notes.Update_By = Convert.ToString(reader["Update_By"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Notes"])) { objstor_Notes.Notes = Convert.ToString(reader["Notes"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Updated_By"])) { objstor_Notes.Updated_By = Convert.ToString(reader["Updated_By"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Update_Date"])) { objstor_Notes.Update_Date = Convert.ToDateTime(reader["Update_Date"], CultureInfo.InvariantCulture); }
            return objstor_Notes;
        }

    }


}

