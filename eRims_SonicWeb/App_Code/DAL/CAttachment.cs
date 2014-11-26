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


    public class CAttachment : RIMS_Base.CAttachment
    {

        public override int InsertUpdateAttachment(RIMS_Base.CAttachment Objchment)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            int nRetVal = -1;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Attachment_InsertUpdate");
                dbHelper.AddParameter(cmd, "@PK_Attachment_Id", DbType.Int32, ParameterDirection.InputOutput, "PK_Attachment_Id", DataRowVersion.Current, Objchment.PK_Attachment_Id);
                dbHelper.AddInParameter(cmd, "@Attachment_Table", DbType.String, Objchment.Attachment_Table);
                dbHelper.AddInParameter(cmd, "@Foreign_Key", DbType.Int32, Objchment.Foreign_Key);
                dbHelper.AddInParameter(cmd, "@FK_Attachment_Type", DbType.Int32, Objchment.FK_Attachment_Type);
                dbHelper.AddInParameter(cmd, "@Attachment_Description", DbType.String, Objchment.Attachment_Description);
                dbHelper.AddInParameter(cmd, "@Attachment_Name", DbType.String, Objchment.Attachment_Name);
                dbHelper.AddInParameter(cmd, "@Updated_By", DbType.String, Objchment.Updated_By);
                dbHelper.AddInParameter(cmd, "@Update_Date", DbType.DateTime, Objchment.Update_Date);
                dbHelper.ExecuteNonQuery(cmd);
                nRetVal = int.Parse(dbHelper.GetParameterValue(cmd, "@PK_Attachment_Id").ToString());
                return nRetVal;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            { dbHelper = null; cmd.Dispose(); cmd = null; }
        }
        public override int DeleteAttachment(System.String lPK_Attachment_Id)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            int nRetVal = -1;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Attachment_Delete");
                dbHelper.AddInParameter(cmd, "@PK_Attachment_ID", DbType.String, lPK_Attachment_Id);
                nRetVal = dbHelper.ExecuteNonQuery(cmd);
                dbHelper = null; cmd.Dispose(); cmd = null;
                return nRetVal;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public override string ActivateInactivateAttachment(string strIDs, int intModifiedBy, bool bIsActive)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            int nRetVal = -1;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Att_ActivateInactivatechments");
                dbHelper.AddParameter(cmd, "@PK_Attachment_Ids", DbType.String, ParameterDirection.InputOutput, "PK_Attachment_Ids", DataRowVersion.Current, strIDs);
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
        public override List<RIMS_Base.CAttachment> GetAll(Int32 pK_Attachment_Id, Int32 Foreign_Key, System.String Table_Name)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Attachment_Select");
                dbHelper.AddInParameter(cmd, "@PK_Attachment_Id", DbType.Int32, pK_Attachment_Id);
                dbHelper.AddInParameter(cmd, "@Foreign_Key", DbType.Int32, Foreign_Key);
                dbHelper.AddInParameter(cmd, "@Table_Name", DbType.String, Table_Name);
                IDataReader reader = dbHelper.ExecuteReader(cmd);
                List<RIMS_Base.CAttachment> results = new List<RIMS_Base.CAttachment>();
                while (reader.Read())
                {
                    CAttachment objchment = new CAttachment();
                    objchment = MapFrom1(reader);
                    results.Add(objchment);
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


        public override RIMS_Base.CAttachment GetchmentByID(System.Decimal pK_Attachment_Id)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Att_Selectchment");
                dbHelper.AddInParameter(cmd, "@PK_Attachment_Id", DbType.Decimal, pK_Attachment_Id);

                IDataReader reader = dbHelper.ExecuteReader(cmd);
                CAttachment objchment = new CAttachment();
                if (reader.Read())
                {
                    objchment = MapFrom(reader);
                }
                reader.Close();
                cmd = null;
                dbHelper = null;

                return objchment;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public override List<RIMS_Base.CAttachment> GetAttachMentMail(System.String Attachment_Ids)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Attachment_S_ForMail");
                dbHelper.AddInParameter(cmd, "@AttIds", DbType.String, Attachment_Ids);
                //dbHelper.AddParameter(cmd, "@strOriginalName", DbType.Int32, ParameterDirection.InputOutput, "Name1", DataRowVersion.Current,objchment.Attachment_Name );
                //dbHelper.AddParameter(cmd, "@strDisplayName", DbType.Int32, ParameterDirection.InputOutput, "Name2", DataRowVersion.Current, objchment.Attachment_Name1);
                
                IDataReader reader = dbHelper.ExecuteReader(cmd);
                List<RIMS_Base.CAttachment> results = new List<RIMS_Base.CAttachment>();
                while(reader.Read())
                {
                    CAttachment objchment = new CAttachment();
                    objchment = MapFromMail(reader);
                    results.Add(objchment);
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
        public override List<RIMS_Base.CAttachment> GetAllAttachmentGroup(System.String Fk_Table_ID, System.String Table_Name)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Attachment_SelectForGroup");
                dbHelper.AddInParameter(cmd, "@FK_Attachment_Type", DbType.String, Fk_Table_ID);
                dbHelper.AddInParameter(cmd, "@Table_Name", DbType.String, Table_Name);
                List<RIMS_Base.CAttachment> result = new List<RIMS_Base.CAttachment>();
                IDataReader reader = dbHelper.ExecuteReader(cmd);
                CAttachment objchment = new CAttachment();
                while (reader.Read())
                {
                    objchment = MapFrom(reader);
                    result.Add(objchment);
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


        protected RIMS_Base.Dal.CAttachment MapFrom(IDataReader reader)
        {
            RIMS_Base.Dal.CAttachment objchment = new RIMS_Base.Dal.CAttachment();
            if (!Convert.IsDBNull(reader["PK_Attachment_Id"])) { objchment.PK_Attachment_Id = Convert.ToInt32(reader["PK_Attachment_Id"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Attachment_Table"])) { objchment.Attachment_Table = Convert.ToString(reader["Attachment_Table"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Foreign_Key"])) { objchment.Foreign_Key = Convert.ToInt32(reader["Foreign_Key"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FK_Attachment_Type"])) { objchment.FK_Attachment_Type = Convert.ToInt32(reader["FK_Attachment_Type"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Attachment_Description"])) { objchment.Attachment_Description = Convert.ToString(reader["Attachment_Description"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Attachment_Name"])) { objchment.Attachment_Name = Convert.ToString(reader["Attachment_Name"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Updated_By"])) { objchment.Updated_By = Convert.ToString(reader["Updated_By"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Update_Date"])) { objchment.Update_Date = Convert.ToDateTime(reader["Update_Date"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FLD_DESC"])) { objchment.Attachment_Type = Convert.ToString(reader["FLD_DESC"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Attachment_Name"])) { objchment.Attachment_Name1 = Convert.ToString(reader["Attachment_Name1"], CultureInfo.InvariantCulture); }
            return objchment;
        }
        protected RIMS_Base.Dal.CAttachment MapFrom1(IDataReader reader)
        {
            RIMS_Base.Dal.CAttachment objchment = new RIMS_Base.Dal.CAttachment();
            if (!Convert.IsDBNull(reader["PK_Attachment_Id"])) { objchment.PK_Attachment_Id = Convert.ToInt32(reader["PK_Attachment_Id"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Attachment_Table"])) { objchment.Attachment_Table = Convert.ToString(reader["Attachment_Table"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Foreign_Key"])) { objchment.Foreign_Key = Convert.ToInt32(reader["Foreign_Key"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FK_Attachment_Type"])) { objchment.FK_Attachment_Type = Convert.ToInt32(reader["FK_Attachment_Type"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Attachment_Description"])) { objchment.Attachment_Description = Convert.ToString(reader["Attachment_Description"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Attachment_Name"])) { objchment.Attachment_Name = Convert.ToString(reader["Attachment_Name"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Attachment_Name1"])) { objchment.Attachment_Name1 = Convert.ToString(reader["Attachment_Name1"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Updated_By"])) { objchment.Updated_By = Convert.ToString(reader["Updated_By"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Update_Date"])) { objchment.Update_Date = Convert.ToDateTime(reader["Update_Date"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FLD_DESC"])) { objchment.Attachment_Type = Convert.ToString(reader["FLD_DESC"], CultureInfo.InvariantCulture); }
            return objchment;
        }
        protected RIMS_Base.Dal.CAttachment MapFromMail(IDataReader reader)
        {
            RIMS_Base.Dal.CAttachment objchment = new RIMS_Base.Dal.CAttachment();
            if (!Convert.IsDBNull(reader["Attachment_Name"])) { objchment.Attachment_Name = Convert.ToString(reader["Attachment_Name"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Attachment_Name1"])) { objchment.Attachment_Name1 = Convert.ToString(reader["Attachment_Name1"], CultureInfo.InvariantCulture); }
            return objchment;
        }



    }


}

