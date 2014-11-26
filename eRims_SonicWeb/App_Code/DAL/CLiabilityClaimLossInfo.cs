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


    public class CLiabilityClaimLossInfo : RIMS_Base.CLiabilityClaimLossInfo
    {

        public override int InsertUpdateility_Claim_LossInfo(RIMS_Base.CLiabilityClaimLossInfo Objility_Claim_LossInfo)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            int nRetVal = -1;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("AutoLiability_InsertUpdate_LossInfo");
                dbHelper.AddInParameter(cmd, "@FK_Liability_Claim", DbType.Int32, Objility_Claim_LossInfo.FK_Liability_Claim);
                dbHelper.AddInParameter(cmd, "@Full_Desc_loss", DbType.String, Objility_Claim_LossInfo.Full_Desc_loss);
                dbHelper.AddInParameter(cmd, "@Police_Notified", DbType.String, Objility_Claim_LossInfo.Police_Notified);
                dbHelper.AddInParameter(cmd, "@Name_Of_Agency", DbType.String, Objility_Claim_LossInfo.Name_Of_Agency);
                dbHelper.AddInParameter(cmd, "@Officer_Name", DbType.String, Objility_Claim_LossInfo.Officer_Name);
                dbHelper.AddInParameter(cmd, "@Officer_BadgeNo", DbType.String, Objility_Claim_LossInfo.Officer_BadgeNo);
                dbHelper.AddInParameter(cmd, "@Ticket_Issued", DbType.String, Objility_Claim_LossInfo.Ticket_Issued);
                dbHelper.AddInParameter(cmd, "@Injury_To_Cmp_Emps", DbType.String, Objility_Claim_LossInfo.Injury_To_Cmp_Emps);
                dbHelper.AddInParameter(cmd, "@Injury_Desc_Emps", DbType.String, Objility_Claim_LossInfo.Injury_Desc_Emps);
                dbHelper.AddInParameter(cmd, "@Injury_To_Others", DbType.String, Objility_Claim_LossInfo.Injury_To_Others);
                dbHelper.AddInParameter(cmd, "@Injury_Desc_Others", DbType.String, Objility_Claim_LossInfo.Injury_Desc_Others);
                dbHelper.AddInParameter(cmd, "@Accident_Prev_Less_10k", DbType.String, Objility_Claim_LossInfo.Accident_Prev_Less_10k);
                dbHelper.AddInParameter(cmd, "@Accident_Prev_Greater_10k", DbType.String, Objility_Claim_LossInfo.Accident_Prev_Greater_10k);
                dbHelper.AddInParameter(cmd, "@Accident_NonPrev", DbType.String, Objility_Claim_LossInfo.Accident_NonPrev);
                dbHelper.AddInParameter(cmd, "@Updated_By", DbType.String, Objility_Claim_LossInfo.Updated_By);
                dbHelper.AddInParameter(cmd, "@Updated_Date", DbType.DateTime, Objility_Claim_LossInfo.Updated_Date);
                dbHelper.ExecuteNonQuery(cmd);
                nRetVal = int.Parse(dbHelper.GetParameterValue(cmd, "@FK_Liability_Claim").ToString());
               // dbHelper = null; cmd.Dispose(); cmd = null;
                return nRetVal;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            { dbHelper = null; cmd.Dispose(); cmd = null; }
        }
        public override int Deleteility_Claim_LossInfo(System.Decimal lFK_Liability_Claim)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            int nRetVal = -1;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Lia_Deleteility_Claim_LossInfo");
                dbHelper.AddInParameter(cmd, "@FK_Liability_Claim", DbType.Decimal, lFK_Liability_Claim);
                nRetVal = dbHelper.ExecuteNonQuery(cmd);
                dbHelper = null; cmd.Dispose(); cmd = null;
                return nRetVal;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public override string ActivateInactivateility_Claim_LossInfo(string strIDs, int intModifiedBy, bool bIsActive)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            int nRetVal = -1;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Lia_ActivateInactivateility_Claim_LossInfos");
                dbHelper.AddParameter(cmd, "@FK_Liability_Claims", DbType.String, ParameterDirection.InputOutput, "FK_Liability_Claims", DataRowVersion.Current, strIDs);
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
        public override List<RIMS_Base.CLiabilityClaimLossInfo> GetAll(Boolean blnIsActive)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("AutoLiability_Select_LossInfo");
               // dbHelper.AddInParameter(cmd, "@IsActive", DbType.Boolean, blnIsActive);
                IDataReader reader = dbHelper.ExecuteReader(cmd);
                List<RIMS_Base.CLiabilityClaimLossInfo> results = new List<RIMS_Base.CLiabilityClaimLossInfo>();
                while (reader.Read())
                {
                    CLiabilityClaimLossInfo objility_Claim_LossInfo = new CLiabilityClaimLossInfo();
                    objility_Claim_LossInfo = MapFrom(reader);
                    results.Add(objility_Claim_LossInfo);
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


        public override List<RIMS_Base.CLiabilityClaimLossInfo> GetAL_Claim_LossInfoByID(System.Decimal fK_Liability_Claim)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("AutoLiability_Select_LossInfo");
                dbHelper.AddInParameter(cmd, "@FK_Liability_Claim", DbType.Decimal, fK_Liability_Claim);
                List<RIMS_Base.CLiabilityClaimLossInfo> results = new List<RIMS_Base.CLiabilityClaimLossInfo>();
                IDataReader reader = dbHelper.ExecuteReader(cmd);
                CLiabilityClaimLossInfo objility_Claim_LossInfo = new CLiabilityClaimLossInfo();
                if (reader.Read())
                {
                    objility_Claim_LossInfo = MapFrom(reader);
                    results.Add(objility_Claim_LossInfo);
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


        protected RIMS_Base.Dal.CLiabilityClaimLossInfo MapFrom(IDataReader reader)
        {
            RIMS_Base.Dal.CLiabilityClaimLossInfo objility_Claim_LossInfo = new RIMS_Base.Dal.CLiabilityClaimLossInfo();
            if (!Convert.IsDBNull(reader["FK_Liability_Claim"])) { objility_Claim_LossInfo.FK_Liability_Claim = Convert.ToInt32(reader["FK_Liability_Claim"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Full_Desc_loss"])) { objility_Claim_LossInfo.Full_Desc_loss = Convert.ToString(reader["Full_Desc_loss"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Police_Notified"])) { objility_Claim_LossInfo.Police_Notified = Convert.ToString(reader["Police_Notified"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Name_Of_Agency"])) { objility_Claim_LossInfo.Name_Of_Agency = Convert.ToString(reader["Name_Of_Agency"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Officer_Name"])) { objility_Claim_LossInfo.Officer_Name = Convert.ToString(reader["Officer_Name"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Officer_BadgeNo"])) { objility_Claim_LossInfo.Officer_BadgeNo = Convert.ToString(reader["Officer_BadgeNo"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Ticket_Issued"])) { objility_Claim_LossInfo.Ticket_Issued = Convert.ToString(reader["Ticket_Issued"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Injury_To_Cmp_Emps"])) { objility_Claim_LossInfo.Injury_To_Cmp_Emps = Convert.ToString(reader["Injury_To_Cmp_Emps"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Injury_Desc_Emps"])) { objility_Claim_LossInfo.Injury_Desc_Emps = Convert.ToString(reader["Injury_Desc_Emps"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Injury_To_Others"])) { objility_Claim_LossInfo.Injury_To_Others = Convert.ToString(reader["Injury_To_Others"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Injury_Desc_Others"])) { objility_Claim_LossInfo.Injury_Desc_Others = Convert.ToString(reader["Injury_Desc_Others"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Accident_Prev_Less_10k"])) { objility_Claim_LossInfo.Accident_Prev_Less_10k = Convert.ToString(reader["Accident_Prev_Less_10k"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Accident_Prev_Greater_10k"])) { objility_Claim_LossInfo.Accident_Prev_Greater_10k = Convert.ToString(reader["Accident_Prev_Greater_10k"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Accident_NonPrev"])) { objility_Claim_LossInfo.Accident_NonPrev = Convert.ToString(reader["Accident_NonPrev"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Updated_By"])) { objility_Claim_LossInfo.Updated_By = Convert.ToString(reader["Updated_By"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Updated_Date"])) { objility_Claim_LossInfo.Updated_Date = Convert.ToDateTime(reader["Updated_Date"], CultureInfo.InvariantCulture); }
            return objility_Claim_LossInfo;
        }




    }


}

