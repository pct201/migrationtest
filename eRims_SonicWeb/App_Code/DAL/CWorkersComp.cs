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
    public class CWorkersComp : RIMS_Base.CWorkersComp
    {

        public override int InsertUpdateers_Compensation(RIMS_Base.CWorkersComp Objers_Compensation)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            int nRetVal = -1;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Workers_Compensation_InsertUpdate");
                dbHelper.AddParameter(cmd, "@PK_Workers_Comp", DbType.Int32, ParameterDirection.InputOutput, "PK_Workers_Comp", DataRowVersion.Current, Objers_Compensation.PK_Workers_Comp);
                dbHelper.AddInParameter(cmd, "@Claim_Number", DbType.String, Objers_Compensation.Claim_Number);
                dbHelper.AddInParameter(cmd, "@Carrier_Claim_Number", DbType.String, Objers_Compensation.Carrier_Claim_Number);
                dbHelper.AddInParameter(cmd, "@Status", DbType.String, Objers_Compensation.Status);
               // dbHelper.AddInParameter(cmd, "@Claimant_Last_Name", DbType.String, Objers_Compensation.Claimant_Last_Name);
                dbHelper.AddInParameter(cmd, "@Date_Reported_To_FairPoint", DbType.DateTime, Objers_Compensation.Date_Reported_To_FairPoint);
                dbHelper.AddInParameter(cmd, "@FK_Claimant", DbType.String, Objers_Compensation.FK_Claimant);
                dbHelper.AddInParameter(cmd, "@Date_Claim_Opened", DbType.DateTime, Objers_Compensation.Date_Claim_Opened);
                dbHelper.AddInParameter(cmd, "@Union_Member", DbType.String, Objers_Compensation.Union_Member);
                dbHelper.AddInParameter(cmd, "@Date_Claim_Closed", DbType.DateTime, Objers_Compensation.Date_Claim_Closed);
                dbHelper.AddInParameter(cmd, "@FK_Entity", DbType.Decimal, Objers_Compensation.FK_Entity);
                dbHelper.AddInParameter(cmd, "@Date_Claim_Reopened", DbType.DateTime, Objers_Compensation.Date_Claim_Reopened);
                dbHelper.AddInParameter(cmd, "@Date_Of_Incident", DbType.DateTime, Objers_Compensation.Date_Of_Incident);
                dbHelper.AddInParameter(cmd, "@Date_Reported_To_Carrier", DbType.DateTime, Objers_Compensation.Date_Reported_To_Carrier);
                dbHelper.AddInParameter(cmd, "@Benefit_State", DbType.Decimal, Objers_Compensation.Benefit_State);
                dbHelper.AddInParameter(cmd, "@FK_Policy", DbType.Decimal, Objers_Compensation.FK_Policy);
                dbHelper.AddInParameter(cmd, "@Comp_Rate", DbType.Decimal, Objers_Compensation.Comp_Rate);
                dbHelper.AddInParameter(cmd, "@TPA", DbType.String, Objers_Compensation.TPA);
                dbHelper.AddInParameter(cmd, "@Time_Of_Loss", DbType.String, Objers_Compensation.Time_Of_Loss);
                dbHelper.AddInParameter(cmd, "@Last_Date_Worked", DbType.DateTime, Objers_Compensation.Last_Date_Worked);
                dbHelper.AddInParameter(cmd, "@Date_RTW", DbType.DateTime, Objers_Compensation.Date_RTW);
                dbHelper.AddInParameter(cmd, "@Transitional_Duty", DbType.String, Objers_Compensation.Transitional_Duty);
                dbHelper.AddInParameter(cmd, "@Transitional_Duty_Refused", DbType.String, Objers_Compensation.Transitional_Duty_Refused);
                dbHelper.AddInParameter(cmd, "@Claim_Type", DbType.String, Objers_Compensation.Claim_Type);
                dbHelper.AddInParameter(cmd, "@FK_Injury_Code", DbType.Decimal, Objers_Compensation.FK_Injury_Code);
                dbHelper.AddInParameter(cmd, "@FK_Cause_Code", DbType.Decimal, Objers_Compensation.FK_Cause_Code);
                dbHelper.AddInParameter(cmd, "@FK_Body_Part", DbType.Decimal, Objers_Compensation.FK_Body_Part);
                dbHelper.AddInParameter(cmd, "@Accident_Description", DbType.String, Objers_Compensation.Accident_Description);
                dbHelper.AddInParameter(cmd, "@Fatility", DbType.String, Objers_Compensation.Fatility);
                dbHelper.AddInParameter(cmd, "@DOB", DbType.DateTime, Objers_Compensation.DOB);
                dbHelper.AddInParameter(cmd, "@Date_Of_Hire", DbType.DateTime, Objers_Compensation.Date_Of_Hire);
                dbHelper.AddInParameter(cmd, "@Legal_Representation", DbType.String, Objers_Compensation.Legal_Representation);
                dbHelper.AddInParameter(cmd, "@Attorney_Name", DbType.String, Objers_Compensation.Attorney_Name);
                dbHelper.AddInParameter(cmd, "@Attorney_Telephone", DbType.String, Objers_Compensation.Attorney_Telephone);
                dbHelper.AddInParameter(cmd, "@CR_Name_Internal", DbType.String, Objers_Compensation.CR_Name_Internal);
                dbHelper.AddInParameter(cmd, "@CR_Telephone_Internal", DbType.String, Objers_Compensation.CR_Telephone_Internal);
                dbHelper.AddInParameter(cmd, "@CR_E_Mail_Internal", DbType.String, Objers_Compensation.CR_E_Mail_Internal);
                dbHelper.AddInParameter(cmd, "@CR_Name_Other", DbType.String, Objers_Compensation.CR_Name_Other);
                dbHelper.AddInParameter(cmd, "@CR_Telephone_Other", DbType.String, Objers_Compensation.CR_Telephone_Other);
                dbHelper.AddInParameter(cmd, "@CR_E_Mail_Other", DbType.String, Objers_Compensation.CR_E_Mail_Other);
                dbHelper.AddInParameter(cmd, "@Updated_By", DbType.String, Objers_Compensation.Updated_By);
                dbHelper.AddInParameter(cmd, "@Update_Date", DbType.DateTime, Objers_Compensation.Update_Date);
                dbHelper.ExecuteNonQuery(cmd);
                nRetVal = int.Parse(dbHelper.GetParameterValue(cmd, "@PK_Workers_Comp").ToString());
              //  dbHelper = null; cmd.Dispose(); cmd = null;
                return nRetVal;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            { dbHelper = null; cmd.Dispose(); cmd = null; }
        }
        public override int Deleteers_Compensation(System.Int32 lPK_Workers_Comp)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            int nRetVal = -1;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Wor_Deleteers_Compensation");
                dbHelper.AddInParameter(cmd, "@PK_Workers_Comp", DbType.Int32, lPK_Workers_Comp);
                nRetVal = dbHelper.ExecuteNonQuery(cmd);
                dbHelper = null; cmd.Dispose(); cmd = null;
                return nRetVal;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public override string ActivateInactivateers_Compensation(string strIDs, int intModifiedBy, bool bIsActive)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            int nRetVal = -1;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Wor_ActivateInactivateers_Compensations");
                dbHelper.AddParameter(cmd, "@PK_Workers_Comps", DbType.String, ParameterDirection.InputOutput, "PK_Workers_Comps", DataRowVersion.Current, strIDs);
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
        public override List<RIMS_Base.CWorkersComp> GetAll(Boolean blnIsActive)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Wor_Selecters_Compensation");
                dbHelper.AddInParameter(cmd, "@IsActive", DbType.Boolean, blnIsActive);
                IDataReader reader = dbHelper.ExecuteReader(cmd);
                List<RIMS_Base.CWorkersComp> results = new List<RIMS_Base.CWorkersComp>();
                while (reader.Read())
                {
                    CWorkersComp objers_Compensation = new CWorkersComp();
                    objers_Compensation = MapFrom(reader);
                    results.Add(objers_Compensation);
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


        public override List<RIMS_Base.CWorkersComp> Get_Worker_CompensationByID(System.Int32 pK_Workers_Comp)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Workers_Compensation_Select");
                dbHelper.AddInParameter(cmd, "@PK_Workers_Comp", DbType.Int32, pK_Workers_Comp);

                IDataReader reader = dbHelper.ExecuteReader(cmd);
                List<RIMS_Base.CWorkersComp> results = new List<RIMS_Base.CWorkersComp>();
                while (reader.Read())
                {
                    CWorkersComp objers_Compensation = new CWorkersComp();
                    objers_Compensation = MapFrom(reader);
                    results.Add(objers_Compensation);
                   
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


        protected RIMS_Base.Dal.CWorkersComp MapFrom(IDataReader reader)
        {
            RIMS_Base.Dal.CWorkersComp objers_Compensation = new RIMS_Base.Dal.CWorkersComp();
            if (!Convert.IsDBNull(reader["PK_Workers_Comp"])) { objers_Compensation.PK_Workers_Comp = Convert.ToInt32(reader["PK_Workers_Comp"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Claim_Number"])) { objers_Compensation.Claim_Number = Convert.ToString(reader["Claim_Number"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Carrier_Claim_Number"])) { objers_Compensation.Carrier_Claim_Number = Convert.ToString(reader["Carrier_Claim_Number"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Status"])) { objers_Compensation.Status = Convert.ToString(reader["Status"], CultureInfo.InvariantCulture); }
           // if (!Convert.IsDBNull(reader["Claimant_Last_Name"])) { objers_Compensation.Claimant_Last_Name = Convert.ToString(reader["Claimant_Last_Name"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Date_Reported_To_FairPoint"])) { objers_Compensation.Date_Reported_To_FairPoint = Convert.ToDateTime(reader["Date_Reported_To_FairPoint"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FK_Claimant"])) { objers_Compensation.FK_Claimant = Convert.ToDecimal(reader["FK_Claimant"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Claim_Open_Date"])) { objers_Compensation.Date_Claim_Opened = Convert.ToDateTime(reader["Claim_Open_Date"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Union_Member"])) { objers_Compensation.Union_Member = Convert.ToString(reader["Union_Member"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Claim_Close_Date"])) { objers_Compensation.Date_Claim_Closed = Convert.ToDateTime(reader["Claim_Close_Date"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FK_Entity"])) { objers_Compensation.FK_Entity = Convert.ToDecimal(reader["FK_Entity"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Claim_Reopen_Date"])) { objers_Compensation.Date_Claim_Reopened = Convert.ToDateTime(reader["Claim_Reopen_Date"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Date_Of_Loss"])) { objers_Compensation.Date_Of_Incident = Convert.ToDateTime(reader["Date_Of_Loss"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Date_Reported_To_Carrier"])) { objers_Compensation.Date_Reported_To_Carrier = Convert.ToDateTime(reader["Date_Reported_To_Carrier"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Benefit_State"])) { objers_Compensation.Benefit_State = Convert.ToDecimal(reader["Benefit_State"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FK_Policy"])) { objers_Compensation.FK_Policy = Convert.ToDecimal(reader["FK_Policy"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Comp_Rate"])) { objers_Compensation.Comp_Rate = Convert.ToDecimal(reader["Comp_Rate"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["TPA"])) { objers_Compensation.TPA = Convert.ToString(reader["TPA"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Time_Of_Loss"])) { objers_Compensation.Time_Of_Loss = Convert.ToString(reader["Time_Of_Loss"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Last_Date_Worked"])) { objers_Compensation.Last_Date_Worked = Convert.ToDateTime(reader["Last_Date_Worked"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Date_RTW"])) { objers_Compensation.Date_RTW = Convert.ToDateTime(reader["Date_RTW"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Transitional_Duty"])) { objers_Compensation.Transitional_Duty = Convert.ToString(reader["Transitional_Duty"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Transitional_Duty_Refused"])) { objers_Compensation.Transitional_Duty_Refused = Convert.ToString(reader["Transitional_Duty_Refused"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Claim_Type"])) { objers_Compensation.Claim_Type = Convert.ToString(reader["Claim_Type"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FK_Injury_Code"])) { objers_Compensation.FK_Injury_Code = Convert.ToDecimal(reader["FK_Injury_Code"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FK_Cause_Code"])) { objers_Compensation.FK_Cause_Code = Convert.ToDecimal(reader["FK_Cause_Code"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FK_Body_Part"])) { objers_Compensation.FK_Body_Part = Convert.ToDecimal(reader["FK_Body_Part"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Accident_Description"])) { objers_Compensation.Accident_Description = Convert.ToString(reader["Accident_Description"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Fatility"])) { objers_Compensation.Fatility = Convert.ToString(reader["Fatility"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["DOB"])) { objers_Compensation.DOB = Convert.ToDateTime(reader["DOB"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Date_Of_Hire"])) { objers_Compensation.Date_Of_Hire = Convert.ToDateTime(reader["Date_Of_Hire"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Legal_Representation"])) { objers_Compensation.Legal_Representation = Convert.ToString(reader["Legal_Representation"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Attorney_Name"])) { objers_Compensation.Attorney_Name = Convert.ToString(reader["Attorney_Name"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Attorney_Telephone"])) { objers_Compensation.Attorney_Telephone = Convert.ToString(reader["Attorney_Telephone"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["CR_Name_Internal"])) { objers_Compensation.CR_Name_Internal = Convert.ToString(reader["CR_Name_Internal"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["CR_Telephone_Internal"])) { objers_Compensation.CR_Telephone_Internal = Convert.ToString(reader["CR_Telephone_Internal"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["CR_E_Mail_Internal"])) { objers_Compensation.CR_E_Mail_Internal = Convert.ToString(reader["CR_E_Mail_Internal"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["CR_Name_Other"])) { objers_Compensation.CR_Name_Other = Convert.ToString(reader["CR_Name_Other"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["CR_Telephone_Other"])) { objers_Compensation.CR_Telephone_Other = Convert.ToString(reader["CR_Telephone_Other"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["CR_E_Mail_Other"])) { objers_Compensation.CR_E_Mail_Other = Convert.ToString(reader["CR_E_Mail_Other"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Updated_By"])) { objers_Compensation.Updated_By = Convert.ToString(reader["Updated_By"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Update_Date"])) { objers_Compensation.Update_Date = Convert.ToDateTime(reader["Update_Date"], CultureInfo.InvariantCulture); }
            return objers_Compensation;
        }


        public override List<RIMS_Base.CWorkersComp> GetCliamant_ByID(System.Int32 pK_Workers_Comp, System.Decimal pK_Claimant_Id)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("WorkerComp_Cliamant_Data_ByID");
                dbHelper.AddInParameter(cmd, "@PK_Workers_Comp", DbType.Int32, pK_Workers_Comp);
                dbHelper.AddInParameter(cmd, "@PK_Claimant_Id", DbType.Int32, pK_Claimant_Id);
                List<RIMS_Base.CWorkersComp> results = new List<RIMS_Base.CWorkersComp>();
                IDataReader reader = dbHelper.ExecuteReader(cmd);
                CWorkersComp objility_Claim = new CWorkersComp();

                if (reader.Read())
                {
                    objility_Claim = MapFromCliamant(reader);
                    results.Add(objility_Claim);
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

        protected RIMS_Base.Dal.CWorkersComp MapFromCliamant(IDataReader reader)
        {
            RIMS_Base.Dal.CWorkersComp objility_Claim = new RIMS_Base.Dal.CWorkersComp();
            if (!Convert.IsDBNull(reader["First_Name"])) { objility_Claim.First_Name = Convert.ToString(reader["First_Name"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Last_Name"])) { objility_Claim.Last_Name = Convert.ToString(reader["Last_Name"], CultureInfo.InvariantCulture); }
          
            return objility_Claim;
        }

        public override List<RIMS_Base.CWorkersComp> GetCarrier_ByID(System.Int32 pK_Workers_Comp, System.Decimal pK_Policy_Id)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("WorkerComp_Carrier_Data_ByID");
                dbHelper.AddInParameter(cmd, "@PK_Workers_Comp", DbType.Int32, pK_Workers_Comp);
                dbHelper.AddInParameter(cmd, "@PK_Policy_Id", DbType.Int32, pK_Policy_Id);
                List<RIMS_Base.CWorkersComp> results = new List<RIMS_Base.CWorkersComp>();
                IDataReader reader = dbHelper.ExecuteReader(cmd);
                CWorkersComp objility_Claim = new CWorkersComp();

                if (reader.Read())
                {
                    objility_Claim = MapFromCarrier(reader);
                    results.Add(objility_Claim);
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

        protected RIMS_Base.Dal.CWorkersComp MapFromCarrier(IDataReader reader)
        {
            RIMS_Base.Dal.CWorkersComp objility_Claim = new RIMS_Base.Dal.CWorkersComp();
           
            if (!Convert.IsDBNull(reader["Carrier"])) { objility_Claim.Carrier = Convert.ToString(reader["Carrier"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Policy_Number"])) { objility_Claim.Policy_Number_Claim = Convert.ToString(reader["Policy_Number"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Policy_Begin_Date"])) { objility_Claim.Effective_Policy_Date = Convert.ToDateTime(reader["Policy_Begin_Date"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Policy_Expiration_Date"])) { objility_Claim.Expiration_Policy_Date = Convert.ToDateTime(reader["Policy_Expiration_Date"], CultureInfo.InvariantCulture); }


            return objility_Claim;
        }

    }
}
