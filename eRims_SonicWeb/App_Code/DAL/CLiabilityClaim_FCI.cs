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


    public class CLiabilityClaim_FCI : RIMS_Base.CLiabilityClaim_FCI
    {
        public override List<RIMS_Base.CLiabilityClaim_FCI> GetAll(Boolean blnIsActive)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("AutoLiability_Select_Claim");
                dbHelper.AddInParameter(cmd, "@IsActive", DbType.Boolean, blnIsActive);
                IDataReader reader = dbHelper.ExecuteReader(cmd);
                List<RIMS_Base.CLiabilityClaim_FCI> results = new List<RIMS_Base.CLiabilityClaim_FCI>();
                while (reader.Read())
                {
                    CLiabilityClaim_FCI objility_Claim = new CLiabilityClaim_FCI();
                    objility_Claim = MapFrom(reader);
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
        public override List<RIMS_Base.CLiabilityClaim_FCI> GetAL_ClaimByID(System.Int32 pK_Liability_Claim)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("AutoLiability_Select_Claim");
                dbHelper.AddInParameter(cmd, "@PK_Liability_Claim", DbType.Int32, pK_Liability_Claim);

                List<RIMS_Base.CLiabilityClaim_FCI> results = new List<RIMS_Base.CLiabilityClaim_FCI>();
                IDataReader reader = dbHelper.ExecuteReader(cmd);
                CLiabilityClaim_FCI objility_Claim = new CLiabilityClaim_FCI();

                if (reader.Read())
                {
                    objility_Claim = MapFrom(reader);
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
        public override List<RIMS_Base.CLiabilityClaim_FCI> GetAL_ClaimByClaimNo(String strClaimNo)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("AutoLiability_Select_Claim_ByClaimNo");
                dbHelper.AddInParameter(cmd, "Claim_Number", DbType.String, strClaimNo);

                List<RIMS_Base.CLiabilityClaim_FCI> results = new List<RIMS_Base.CLiabilityClaim_FCI>();
                IDataReader reader = dbHelper.ExecuteReader(cmd);
                CLiabilityClaim_FCI objility_Claim = new CLiabilityClaim_FCI();

                if (reader.Read())
                {
                    objility_Claim = MapFrom(reader);
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

        public override int InsertUpdateility_Claim(RIMS_Base.CLiabilityClaim_FCI objility_Claim)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            int nRetVal = -1;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("AutoLiability_InsertUpdate");

                //-- Claim_Detail
                dbHelper.AddParameter(cmd, "@PK_Liability_Claim", DbType.Int32, ParameterDirection.InputOutput, "PK_Liability_Claim", DataRowVersion.Current, objility_Claim.PK_Liability_Claim);
                dbHelper.AddInParameter(cmd, "@Claim_Number", DbType.String, objility_Claim.Claim_Number);
                dbHelper.AddInParameter(cmd, "@FK_Claim_Type", DbType.Decimal, objility_Claim.FK_Claim_Type);
                dbHelper.AddInParameter(cmd, "@FK_Claimant_id", DbType.Decimal, objility_Claim.FK_Claimant_id);

                dbHelper.AddInParameter(cmd, "@FK_Entity", DbType.Decimal, objility_Claim.FK_Entity);
                dbHelper.AddInParameter(cmd, "@Fk_ECD_Id", DbType.Decimal, objility_Claim.Fk_ECD_Id);
                dbHelper.AddInParameter(cmd, "@Date_Of_Loss", DbType.DateTime, objility_Claim.Date_Of_Loss);
                dbHelper.AddInParameter(cmd, "@Time_Of_Loss", DbType.String, objility_Claim.Time_Of_Loss);
                dbHelper.AddInParameter(cmd, "@Legal", DbType.String, objility_Claim.Legal);
                dbHelper.AddInParameter(cmd, "@Report_To_Carrier", DbType.String, objility_Claim.Report_To_Carrier);
                dbHelper.AddInParameter(cmd, "@Date_To_Fairpoint", DbType.DateTime, objility_Claim.Date_To_Fairpoint);
                dbHelper.AddInParameter(cmd, "@Claim_Open_Date", DbType.DateTime, objility_Claim.Claim_Open_Date);
                dbHelper.AddInParameter(cmd, "@Claim_Close_Date", DbType.DateTime, objility_Claim.Claim_Close_Date);
                dbHelper.AddInParameter(cmd, "@Claim_Reopen_Date", DbType.DateTime, objility_Claim.Claim_Reopen_Date);
                dbHelper.AddInParameter(cmd, "@Date_To_Carrier", DbType.DateTime, objility_Claim.Date_To_Carrier);
                dbHelper.AddInParameter(cmd, "@FK_Carrier", DbType.Decimal, objility_Claim.FK_Carrier);
                dbHelper.AddInParameter(cmd, "@Carrier_Claim_Number", DbType.String, objility_Claim.Carrier_Claim_Number);
                dbHelper.AddInParameter(cmd, "@TPA_Name", DbType.String, objility_Claim.TPA_Name);
                dbHelper.AddInParameter(cmd, "@FK_Liability_Major_Claim_Type", DbType.Decimal, objility_Claim.FK_Liability_Major_Claim_Type);
                dbHelper.AddInParameter(cmd, "@FK_Liability_Coverage", DbType.Decimal, objility_Claim.FK_Liability_Coverage);

                dbHelper.AddInParameter(cmd, "@Cliamant_An_Employee", DbType.String, objility_Claim.Cliamant_An_Employee);
                dbHelper.AddInParameter(cmd, "@AddTo", DbType.String, objility_Claim.ADDTO);
                // dbHelper.AddInParameter(cmd,"@Policy_Number_Claim", DbType.String, objility_Claim.Policy_Number_Claim);
                //dbHelper.AddInParameter(cmd,"@Effective_Policy_Date",DbType.DateTime,objility_Claim.Effective_Policy_Date);
                //dbHelper.AddInParameter(cmd,"@Expiration_Policy_Date",DbType.DateTime,objility_Claim.Expiration_Policy_Date);



                #region comment

                #endregion  //comment




                dbHelper.ExecuteNonQuery(cmd);
                nRetVal = int.Parse(dbHelper.GetParameterValue(cmd, "PK_Liability_Claim").ToString());
                //	dbHelper = null; cmd.Dispose(); cmd = null;
                return nRetVal;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            { dbHelper = null; cmd.Dispose(); cmd = null; }
        }
        public override int InsertUpdate_PropertyClaim(RIMS_Base.CLiabilityClaim_FCI objility_Claim)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            int nRetVal = -1;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("LiabilityClaim_InsertUpdate_PropertyClaim");

                //-- Claim_Detail
                dbHelper.AddParameter(cmd, "@PK_Liability_Claim", DbType.Int32, ParameterDirection.InputOutput, "PK_Liability_Claim", DataRowVersion.Current, objility_Claim.PK_Liability_Claim);
                dbHelper.AddInParameter(cmd, "@Claim_Number", DbType.String, objility_Claim.Claim_Number);
                dbHelper.AddInParameter(cmd, "@FK_Claim_Type", DbType.Decimal, objility_Claim.FK_Claim_Type);
                dbHelper.AddInParameter(cmd, "@FK_Claimant_id", DbType.Decimal, objility_Claim.FK_Claimant_id);

                dbHelper.AddInParameter(cmd, "@FK_Entity", DbType.Decimal, objility_Claim.FK_Entity);
                dbHelper.AddInParameter(cmd, "@Fk_ECD_Id", DbType.Decimal, objility_Claim.Fk_ECD_Id);
                dbHelper.AddInParameter(cmd, "@Date_Of_Loss", DbType.DateTime, objility_Claim.Date_Of_Loss);
                dbHelper.AddInParameter(cmd, "@Time_Of_Loss", DbType.String, objility_Claim.Time_Of_Loss);
                dbHelper.AddInParameter(cmd, "@Legal", DbType.String, objility_Claim.Legal);
                dbHelper.AddInParameter(cmd, "@Report_To_Carrier", DbType.String, objility_Claim.Report_To_Carrier);
                dbHelper.AddInParameter(cmd, "@Date_To_Fairpoint", DbType.DateTime, objility_Claim.Date_To_Fairpoint);
                dbHelper.AddInParameter(cmd, "@Claim_Open_Date", DbType.DateTime, objility_Claim.Claim_Open_Date);
                dbHelper.AddInParameter(cmd, "@Claim_Close_Date", DbType.DateTime, objility_Claim.Claim_Close_Date);
                dbHelper.AddInParameter(cmd, "@Claim_Reopen_Date", DbType.DateTime, objility_Claim.Claim_Reopen_Date);
                dbHelper.AddInParameter(cmd, "@Date_To_Carrier", DbType.DateTime, objility_Claim.Date_To_Carrier);
                dbHelper.AddInParameter(cmd, "@FK_Carrier", DbType.Decimal, objility_Claim.FK_Carrier);
                dbHelper.AddInParameter(cmd, "@Carrier_Claim_Number", DbType.String, objility_Claim.Carrier_Claim_Number);
                dbHelper.AddInParameter(cmd, "@TPA_Name", DbType.String, objility_Claim.TPA_Name);
                dbHelper.AddInParameter(cmd, "@FK_Liability_Major_Claim_Type", DbType.Decimal, objility_Claim.FK_Liability_Major_Claim_Type);
                dbHelper.AddInParameter(cmd, "@FK_Liability_Coverage", DbType.Decimal, objility_Claim.FK_Liability_Coverage);

                dbHelper.AddInParameter(cmd, "@Cliamant_An_Employee", DbType.String, objility_Claim.Cliamant_An_Employee);
                //dbHelper.AddInParameter(cmd, "@AddTo", DbType.String, objility_Claim.ADDTO);
                // dbHelper.AddInParameter(cmd,"@Policy_Number_Claim", DbType.String, objility_Claim.Policy_Number_Claim);
                //dbHelper.AddInParameter(cmd,"@Effective_Policy_Date",DbType.DateTime,objility_Claim.Effective_Policy_Date);
                //dbHelper.AddInParameter(cmd,"@Expiration_Policy_Date",DbType.DateTime,objility_Claim.Expiration_Policy_Date);



                #region comment

                #endregion  //comment




                dbHelper.ExecuteNonQuery(cmd);
                nRetVal = int.Parse(dbHelper.GetParameterValue(cmd, "PK_Liability_Claim").ToString());
                //	dbHelper = null; cmd.Dispose(); cmd = null;
                return nRetVal;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            { dbHelper = null; cmd.Dispose(); cmd = null; }
        }
        public override int Deleteility_Claim(System.Int32 lPK_Liability_Claim)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            int nRetVal = -1;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Lia_Deleteility_Claim");
                dbHelper.AddInParameter(cmd, "@PK_Liability_Claim", DbType.Int32, lPK_Liability_Claim);
                nRetVal = dbHelper.ExecuteNonQuery(cmd);
                dbHelper = null; cmd.Dispose(); cmd = null;
                return nRetVal;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public override string ActivateInactivateility_Claim(string strIDs, int intModifiedBy, bool bIsActive)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            int nRetVal = -1;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Lia_ActivateInactivateility_Claims");
                dbHelper.AddParameter(cmd, "@PK_Liability_Claims", DbType.String, ParameterDirection.InputOutput, "PK_Liability_Claims", DataRowVersion.Current, strIDs);
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

        protected RIMS_Base.Dal.CLiabilityClaim_FCI MapFrom(IDataReader reader)
        {
            RIMS_Base.Dal.CLiabilityClaim_FCI objility_Claim = new RIMS_Base.Dal.CLiabilityClaim_FCI();
            if (!Convert.IsDBNull(reader["PK_Liability_Claim"])) { objility_Claim.PK_Liability_Claim = Convert.ToInt32(reader["PK_Liability_Claim"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Claim_Number"])) { objility_Claim.Claim_Number = Convert.ToString(reader["Claim_Number"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FK_Claim_Type"])) { objility_Claim.FK_Claim_Type = Convert.ToDecimal(reader["FK_Claim_Type"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Fk_ECD_Id"])) { objility_Claim.Fk_ECD_Id = Convert.ToDecimal(reader["Fk_ECD_Id"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FK_Claimant_id"])) { objility_Claim.FK_Claimant_id = Convert.ToDecimal(reader["FK_Claimant_id"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FK_Entity"])) { objility_Claim.FK_Entity = Convert.ToDecimal(reader["FK_Entity"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Date_Of_Loss"])) { objility_Claim.Date_Of_Loss = Convert.ToDateTime(reader["Date_Of_Loss"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Time_Of_Loss"])) { objility_Claim.Time_Of_Loss = Convert.ToString(reader["Time_Of_Loss"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Legal"])) { objility_Claim.Legal = Convert.ToString(reader["Legal"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Report_To_Carrier"])) { objility_Claim.Report_To_Carrier = Convert.ToString(reader["Report_To_Carrier"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Date_To_Fairpoint"])) { objility_Claim.Date_To_Fairpoint = Convert.ToDateTime(reader["Date_To_Fairpoint"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Claim_Open_Date"])) { objility_Claim.Claim_Open_Date = Convert.ToDateTime(reader["Claim_Open_Date"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Claim_Close_Date"])) { objility_Claim.Claim_Close_Date = Convert.ToDateTime(reader["Claim_Close_Date"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Claim_Reopen_Date"])) { objility_Claim.Claim_Reopen_Date = Convert.ToDateTime(reader["Claim_Reopen_Date"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Date_To_Carrier"])) { objility_Claim.Date_To_Carrier = Convert.ToDateTime(reader["Date_To_Carrier"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FK_Carrier"])) { objility_Claim.FK_Carrier = Convert.ToDecimal(reader["FK_Carrier"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Carrier_Claim_Number"])) { objility_Claim.Carrier_Claim_Number = Convert.ToString(reader["Carrier_Claim_Number"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["TPA_Name"])) { objility_Claim.TPA_Name = Convert.ToString(reader["TPA_Name"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FK_Liability_Coverage"])) { objility_Claim.FK_Liability_Coverage = Convert.ToDecimal(reader["FK_Liability_Coverage"], CultureInfo.InvariantCulture); }

            if (!Convert.IsDBNull(reader["Cliamant_An_Employee"])) { objility_Claim.Cliamant_An_Employee = Convert.ToString(reader["Cliamant_An_Employee"], CultureInfo.InvariantCulture); }
            //if (!Convert.IsDBNull(reader["Policy_Number"]))  {objility_Claim.Policy_Number_Claim=Convert.ToString(reader["Policy_Number"], CultureInfo.InvariantCulture);}
            //if (!Convert.IsDBNull(reader["Effective_Policy_Date"]))  {objility_Claim.Effective_Policy_Date=Convert.ToDateTime(reader["Effective_Policy_Date"], CultureInfo.InvariantCulture);}
            //if (!Convert.IsDBNull(reader["Expiration_Policy_Date"]))  {objility_Claim.Expiration_Policy_Date=Convert.ToDateTime(reader["Expiration_Policy_Date"], CultureInfo.InvariantCulture); }
            return objility_Claim;
            #region
            // //--Claim Representative
            // //if (!Convert.IsDBNull(reader["FK_Liability_Claim"])) { objility_Claim_Representative.FK_Liability_Claim = Convert.ToDecimal(reader["FK_Liability_Claim"], CultureInfo.InvariantCulture); }
            // if (!Convert.IsDBNull(reader["FairPoint_Name"])) { objility_Claim.FairPoint_Name = Convert.ToString(reader["FairPoint_Name"], CultureInfo.InvariantCulture); }
            // if (!Convert.IsDBNull(reader["Email"])) { objility_Claim.Email_Claim = Convert.ToString(reader["Email"], CultureInfo.InvariantCulture); }
            // if (!Convert.IsDBNull(reader["Telephone"])) { objility_Claim.Telephone_Claim = Convert.ToString(reader["Telephone"], CultureInfo.InvariantCulture); }
            //// if (!Convert.IsDBNull(reader["Updated_By"])) { objility_Claim_Representative.Updated_By = Convert.ToString(reader["Updated_By"], CultureInfo.InvariantCulture); }
            //// if (!Convert.IsDBNull(reader["Updated_Date"])) { objility_Claim_Representative.Updated_Date = Convert.ToDateTime(reader["Updated_Date"], CultureInfo.InvariantCulture); }

            // //--Loss Location
            // //if (!Convert.IsDBNull(reader["FK_Liability_Claim"])) { objility_Claim_LossLocation.FK_Liability_Claim = Convert.ToDecimal(reader["FK_Liability_Claim"], CultureInfo.InvariantCulture); }
            // if (!Convert.IsDBNull(reader["Address1"])) { objility_Claim.Address1 = Convert.ToString(reader["Address1"], CultureInfo.InvariantCulture); }
            // if (!Convert.IsDBNull(reader["Address2"])) { objility_Claim.Address2 = Convert.ToString(reader["Address2"], CultureInfo.InvariantCulture); }
            // if (!Convert.IsDBNull(reader["City"])) { objility_Claim.City = Convert.ToString(reader["City"], CultureInfo.InvariantCulture); }
            // if (!Convert.IsDBNull(reader["FK_State"])) { objility_Claim.FK_State = Convert.ToDecimal(reader["FK_State"], CultureInfo.InvariantCulture); }
            // if (!Convert.IsDBNull(reader["Zip"])) { objility_Claim.Zip = Convert.ToString(reader["Zip"], CultureInfo.InvariantCulture); }
            // if (!Convert.IsDBNull(reader["County"])) { objility_Claim.County = Convert.ToString(reader["County"], CultureInfo.InvariantCulture); }
            // if (!Convert.IsDBNull(reader["Accident_In_Company"])) { objility_Claim.Accident_In_Company = Convert.ToString(reader["Accident_In_Company"], CultureInfo.InvariantCulture); }
            // //if (!Convert.IsDBNull(reader["Updated_By"])) { objility_Claim_LossLocation.Updated_By = Convert.ToString(reader["Updated_By"], CultureInfo.InvariantCulture); }
            // //if (!Convert.IsDBNull(reader["Updated_Date"])) { objility_Claim_LossLocation.Updated_Date = Convert.ToDateTime(reader["Updated_Date"], CultureInfo.InvariantCulture); }


            // //--Loss Information
            // //if (!Convert.IsDBNull(reader["FK_Liability_Claim"])) { objility_Claim_LossInfo.FK_Liability_Claim = Convert.ToDecimal(reader["FK_Liability_Claim"], CultureInfo.InvariantCulture); }
            // if (!Convert.IsDBNull(reader["Full_Desc_loss"])) { objility_Claim.Full_Desc_loss = Convert.ToString(reader["Full_Desc_loss"], CultureInfo.InvariantCulture); }
            // if (!Convert.IsDBNull(reader["Police_Notified"])) { objility_Claim.Police_Notified = Convert.ToString(reader["Police_Notified"], CultureInfo.InvariantCulture); }
            // if (!Convert.IsDBNull(reader["Name_Of_Agency"])) { objility_Claim.Name_Of_Agency = Convert.ToString(reader["Name_Of_Agency"], CultureInfo.InvariantCulture); }
            // if (!Convert.IsDBNull(reader["Officer_Name"])) { objility_Claim.Officer_Name = Convert.ToString(reader["Officer_Name"], CultureInfo.InvariantCulture); }
            // if (!Convert.IsDBNull(reader["Officer_BadgeNo"])) { objility_Claim.Officer_BadgeNo = Convert.ToString(reader["Officer_BadgeNo"], CultureInfo.InvariantCulture); }
            // if (!Convert.IsDBNull(reader["Ticket_Issued"])) { objility_Claim.Ticket_Issued = Convert.ToString(reader["Ticket_Issued"], CultureInfo.InvariantCulture); }
            // if (!Convert.IsDBNull(reader["Injury_To_Cmp_Emps"])) { objility_Claim.Injury_To_Cmp_Emps = Convert.ToString(reader["Injury_To_Cmp_Emps"], CultureInfo.InvariantCulture); }
            // if (!Convert.IsDBNull(reader["Injury_Desc_Emps"])) { objility_Claim.Injury_Desc_Emps = Convert.ToString(reader["Injury_Desc_Emps"], CultureInfo.InvariantCulture); }
            // if (!Convert.IsDBNull(reader["Injury_To_Others"])) { objility_Claim.Injury_To_Others = Convert.ToString(reader["Injury_To_Others"], CultureInfo.InvariantCulture); }
            // if (!Convert.IsDBNull(reader["Injury_Desc_Others"])) { objility_Claim.Injury_Desc_Others = Convert.ToString(reader["Injury_Desc_Others"], CultureInfo.InvariantCulture); }
            // if (!Convert.IsDBNull(reader["Accident_Prev_Less_10k"])) { objility_Claim.Accident_Prev_Less_10k = Convert.ToString(reader["Accident_Prev_Less_10k"], CultureInfo.InvariantCulture); }
            // if (!Convert.IsDBNull(reader["Accident_Prev_Greater_10k"])) { objility_Claim.Accident_Prev_Greater_10k = Convert.ToString(reader["Accident_Prev_Greater_10k"], CultureInfo.InvariantCulture); }
            // if (!Convert.IsDBNull(reader["Accident_NonPrev"])) { objility_Claim.Accident_NonPrev = Convert.ToString(reader["Accident_NonPrev"], CultureInfo.InvariantCulture); }
            // //if (!Convert.IsDBNull(reader["Updated_By"])) { objility_Claim_LossInfo.Updated_By = Convert.ToString(reader["Updated_By"], CultureInfo.InvariantCulture); }
            // //if (!Convert.IsDBNull(reader["Updated_Date"])) { objility_Claim_LossInfo.Updated_Date = Convert.ToDateTime(reader["Updated_Date"], CultureInfo.InvariantCulture); }

            // //--Company Vehicle Information
            // //if (!Convert.IsDBNull(reader["FK_Liability_Claim"])) { objility_Claim_CmpVehicleInfo.FK_Liability_Claim = Convert.ToDecimal(reader["FK_Liability_Claim"], CultureInfo.InvariantCulture); }
            // if (!Convert.IsDBNull(reader["Year"])) { objility_Claim.Year = Convert.ToString(reader["Year"], CultureInfo.InvariantCulture); }
            // if (!Convert.IsDBNull(reader["Model"])) { objility_Claim.Model = Convert.ToString(reader["Model"], CultureInfo.InvariantCulture); }
            // if (!Convert.IsDBNull(reader["License_Plate_Number"])) { objility_Claim.License_Plate_Number = Convert.ToString(reader["License_Plate_Number"], CultureInfo.InvariantCulture); }
            // if (!Convert.IsDBNull(reader["Vehicle_Color"])) { objility_Claim.Vehicle_Color = Convert.ToString(reader["Vehicle_Color"], CultureInfo.InvariantCulture); }
            // if (!Convert.IsDBNull(reader["Make"])) { objility_Claim.Make = Convert.ToString(reader["Make"], CultureInfo.InvariantCulture); }
            // if (!Convert.IsDBNull(reader["VIN"])) { objility_Claim.VIN = Convert.ToString(reader["VIN"], CultureInfo.InvariantCulture); }
            // if (!Convert.IsDBNull(reader["FK_License_Plate_State"])) { objility_Claim.FK_License_Plate_State = Convert.ToDecimal(reader["FK_License_Plate_State"], CultureInfo.InvariantCulture); }
            // if (!Convert.IsDBNull(reader["CmpVeh_Only_Veh"])) { objility_Claim.CmpVeh_Only_Veh = Convert.ToString(reader["CmpVeh_Only_Veh"], CultureInfo.InvariantCulture); }
            // if (!Convert.IsDBNull(reader["Damage_To_CmpVeh"])) { objility_Claim.Damage_To_CmpVeh = Convert.ToString(reader["Damage_To_CmpVeh"], CultureInfo.InvariantCulture); }
            // //if (!Convert.IsDBNull(reader["Updated_By"])) { objility_Claim_CmpVehicleInfo.Updated_By = Convert.ToString(reader["Updated_By"], CultureInfo.InvariantCulture); }
            // //if (!Convert.IsDBNull(reader["Updated_Date"])) { objility_Claim_CmpVehicleInfo.Updated_Date = Convert.ToDateTime(reader["Updated_Date"], CultureInfo.InvariantCulture); }

            // //--Company Driver Information
            // //if (!Convert.IsDBNull(reader["FK_Liability_Claim"])) { objlility_Claim_CmpDriverInfo.FK_Liability_Claim = Convert.ToDecimal(reader["FK_Liability_Claim"], CultureInfo.InvariantCulture); }
            // if (!Convert.IsDBNull(reader["Name"])) { objility_Claim.Name = Convert.ToString(reader["Name"], CultureInfo.InvariantCulture); }
            // if (!Convert.IsDBNull(reader["Supervisor"])) { objility_Claim.Supervisor = Convert.ToString(reader["Supervisor"], CultureInfo.InvariantCulture); }
            // if (!Convert.IsDBNull(reader["Telephone_No"])) { objility_Claim.Telephone_No = Convert.ToString(reader["Telephone_No"], CultureInfo.InvariantCulture); }
            // if (!Convert.IsDBNull(reader["Supervisor_TeleNo"])) { objility_Claim.Supervisor_TeleNo = Convert.ToString(reader["Supervisor_TeleNo"], CultureInfo.InvariantCulture); }
            // if (!Convert.IsDBNull(reader["List_Company_Passengers"])) { objility_Claim.List_Company_Passengers = Convert.ToString(reader["List_Company_Passengers"], CultureInfo.InvariantCulture); }
            // //if (!Convert.IsDBNull(reader["Updated_By"])) { objlility_Claim_CmpDriverInfo.Updated_By = Convert.ToString(reader["Updated_By"], CultureInfo.InvariantCulture); }
            // //if (!Convert.IsDBNull(reader["Updated_Date"])) { objlility_Claim_CmpDriverInfo.Updated_Date = Convert.ToDateTime(reader["Updated_Date"], CultureInfo.InvariantCulture); }

            // //--Other Property Damage
            // //if (!Convert.IsDBNull(reader["FK_Liability_Claim"])) { objility_Claim_OtherPropertyDamage.FK_Liability_Claim = Convert.ToDecimal(reader["FK_Liability_Claim"], CultureInfo.InvariantCulture); }
            // if (!Convert.IsDBNull(reader["Damage_To_Property"])) { objility_Claim.Damage_To_Property = Convert.ToString(reader["Damage_To_Property"], CultureInfo.InvariantCulture); }
            // if (!Convert.IsDBNull(reader["Damage_Desc"])) { objility_Claim.Damage_Desc = Convert.ToString(reader["Damage_Desc"], CultureInfo.InvariantCulture); }
            // if (!Convert.IsDBNull(reader["Cost_To_Repair"])) { objility_Claim.Cost_To_Repair = Convert.ToDecimal(reader["Cost_To_Repair"], CultureInfo.InvariantCulture); }

            // //--Financial Summary

            // //--Other Party
            // //if (!Convert.IsDBNull(reader["FK_Liability_Claim"])) { objility_Claim_OtherParty.FK_Liability_Claim = Convert.ToDecimal(reader["FK_Liability_Claim"], CultureInfo.InvariantCulture); }
            // if (!Convert.IsDBNull(reader["Name"])) { objility_Claim.Name = Convert.ToString(reader["Name"], CultureInfo.InvariantCulture); }
            // if (!Convert.IsDBNull(reader["Email"])) { objility_Claim.Email = Convert.ToString(reader["Email"], CultureInfo.InvariantCulture); }
            // if (!Convert.IsDBNull(reader["TelePhone"])) { objility_Claim.TelePhone = Convert.ToString(reader["TelePhone"], CultureInfo.InvariantCulture); }
            // //if (!Convert.IsDBNull(reader["Updated_By"])) { objility_Claim_OtherParty.Updated_By = Convert.ToString(reader["Updated_By"], CultureInfo.InvariantCulture); }
            // //if (!Convert.IsDBNull(reader["Updated_Date"])) { objility_Claim_OtherParty.Updated_Date = Convert.ToDateTime(reader["Updated_Date"], CultureInfo.InvariantCulture); }

            // //--Other Vehicle Information
            // //if (!Convert.IsDBNull(reader["FK_Liability_Claim"])) { objility_Claim_OtherVehInfo.FK_Liability_Claim = Convert.ToDecimal(reader["FK_Liability_Claim"], CultureInfo.InvariantCulture); }
            // if (!Convert.IsDBNull(reader["Owner_Name"])) { objility_Claim.Owner_Name = Convert.ToString(reader["Owner_Name"], CultureInfo.InvariantCulture); }
            // if (!Convert.IsDBNull(reader["Owner_Address1"])) { objility_Claim.Owner_Address1 = Convert.ToString(reader["Owner_Address1"], CultureInfo.InvariantCulture); }
            // if (!Convert.IsDBNull(reader["Owner_Address2"])) { objility_Claim.Owner_Address2 = Convert.ToString(reader["Owner_Address2"], CultureInfo.InvariantCulture); }
            // if (!Convert.IsDBNull(reader["Owner_City"])) { objility_Claim.Owner_City = Convert.ToString(reader["Owner_City"], CultureInfo.InvariantCulture); }
            // if (!Convert.IsDBNull(reader["FK_Owner_State"])) { objility_Claim.FK_Owner_State = Convert.ToDecimal(reader["FK_Owner_State"], CultureInfo.InvariantCulture); }
            // if (!Convert.IsDBNull(reader["Owner_Zipcode"])) { objility_Claim.Owner_Zipcode = Convert.ToString(reader["Owner_Zipcode"], CultureInfo.InvariantCulture); }
            // if (!Convert.IsDBNull(reader["Owner_Telephone"])) { objility_Claim.Owner_Telephone = Convert.ToString(reader["Owner_Telephone"], CultureInfo.InvariantCulture); }
            // if (!Convert.IsDBNull(reader["Insurance_Carrier"])) { objility_Claim.Insurance_Carrier = Convert.ToString(reader["Insurance_Carrier"], CultureInfo.InvariantCulture); }
            // if (!Convert.IsDBNull(reader["Insurance_Telephone"])) { objility_Claim.Insurance_Telephone = Convert.ToString(reader["Insurance_Telephone"], CultureInfo.InvariantCulture); }
            // if (!Convert.IsDBNull(reader["Insurance_Agent_Name"])) { objility_Claim.Insurance_Agent_Name = Convert.ToString(reader["Insurance_Agent_Name"], CultureInfo.InvariantCulture); }
            // if (!Convert.IsDBNull(reader["Insurance_Agent_Telephone"])) { objility_Claim.Insurance_Agent_Telephone = Convert.ToString(reader["Insurance_Agent_Telephone"], CultureInfo.InvariantCulture); }
            // if (!Convert.IsDBNull(reader["Policy_Number"])) { objility_Claim.Policy_Number = Convert.ToString(reader["Policy_Number"], CultureInfo.InvariantCulture); }
            // if (!Convert.IsDBNull(reader["Vehicle_Year"])) { objility_Claim.Vehicle_Year = Convert.ToString(reader["Vehicle_Year"], CultureInfo.InvariantCulture); }
            // if (!Convert.IsDBNull(reader["Vehicle_Make"])) { objility_Claim.Vehicle_Make = Convert.ToString(reader["Vehicle_Make"], CultureInfo.InvariantCulture); }
            // if (!Convert.IsDBNull(reader["Vehicle_Model"])) { objility_Claim.Vehicle_Model = Convert.ToString(reader["Vehicle_Model"], CultureInfo.InvariantCulture); }
            // if (!Convert.IsDBNull(reader["Vehicle_VIN"])) { objility_Claim.Vehicle_VIN = Convert.ToString(reader["Vehicle_VIN"], CultureInfo.InvariantCulture); }
            // if (!Convert.IsDBNull(reader["Vehicle_Plate_Number"])) { objility_Claim.Vehicle_Plate_Number = Convert.ToString(reader["Vehicle_Plate_Number"], CultureInfo.InvariantCulture); }
            // if (!Convert.IsDBNull(reader["FK_Vehicle_State"])) { objility_Claim.FK_Vehicle_State = Convert.ToDecimal(reader["FK_Vehicle_State"], CultureInfo.InvariantCulture); }
            // if (!Convert.IsDBNull(reader["Vehicle_Color"])) { objility_Claim.Vehicle_Color = Convert.ToString(reader["Vehicle_Color"], CultureInfo.InvariantCulture); }
            // if (!Convert.IsDBNull(reader["Desc_Damage"])) { objility_Claim.Desc_Damage = Convert.ToString(reader["Desc_Damage"], CultureInfo.InvariantCulture); }
            // //if (!Convert.IsDBNull(reader["Updated_By"])) { objility_Claim_OtherVehInfo.Updated_By = Convert.ToString(reader["Updated_By"], CultureInfo.InvariantCulture); }
            // //if (!Convert.IsDBNull(reader["Updated_Date"])) { objility_Claim_OtherVehInfo.Updated_Date = Convert.ToDateTime(reader["Updated_Date"], CultureInfo.InvariantCulture); }

            // //--Other Driver Information
            // //if (!Convert.IsDBNull(reader["FK_Liability_Claim"])) { objility_Claim_OtherDriverInfo.FK_Liability_Claim = Convert.ToDecimal(reader["FK_Liability_Claim"], CultureInfo.InvariantCulture); }
            // if (!Convert.IsDBNull(reader["Driver_Name"])) { objility_Claim.Driver_Name = Convert.ToString(reader["Driver_Name"], CultureInfo.InvariantCulture); }
            // if (!Convert.IsDBNull(reader["Driver_Address1"])) { objility_Claim.Driver_Address1 = Convert.ToString(reader["Driver_Address1"], CultureInfo.InvariantCulture); }
            // if (!Convert.IsDBNull(reader["Driver_Address2"])) { objility_Claim.Driver_Address2 = Convert.ToString(reader["Driver_Address2"], CultureInfo.InvariantCulture); }
            // if (!Convert.IsDBNull(reader["Driver_City"])) { objility_Claim.Driver_City = Convert.ToString(reader["Driver_City"], CultureInfo.InvariantCulture); }
            // if (!Convert.IsDBNull(reader["FK_Driver_State"])) { objility_Claim.FK_Driver_State = Convert.ToDecimal(reader["FK_Driver_State"], CultureInfo.InvariantCulture); }
            // if (!Convert.IsDBNull(reader["Driver_Zipcode"])) { objility_Claim.Driver_Zipcode = Convert.ToString(reader["Driver_Zipcode"], CultureInfo.InvariantCulture); }
            // if (!Convert.IsDBNull(reader["Driver_Telephone"])) { objility_Claim.Driver_Telephone = Convert.ToString(reader["Driver_Telephone"], CultureInfo.InvariantCulture); }
            // if (!Convert.IsDBNull(reader["Driver_License_Number"])) { objility_Claim.Driver_License_Number = Convert.ToString(reader["Driver_License_Number"], CultureInfo.InvariantCulture); }
            // if (!Convert.IsDBNull(reader["FK_Driver_License_State"])) { objility_Claim.FK_Driver_License_State = Convert.ToDecimal(reader["FK_Driver_License_State"], CultureInfo.InvariantCulture); }
            // if (!Convert.IsDBNull(reader["Insurance_Carrier"])) { objility_Claim.Insurance_Carrier = Convert.ToString(reader["Insurance_Carrier"], CultureInfo.InvariantCulture); }
            // if (!Convert.IsDBNull(reader["Insurance_Telephone"])) { objility_Claim.Insurance_Telephone = Convert.ToString(reader["Insurance_Telephone"], CultureInfo.InvariantCulture); }
            // if (!Convert.IsDBNull(reader["Insurance_Agent_Name"])) { objility_Claim.Insurance_Agent_Name = Convert.ToString(reader["Insurance_Agent_Name"], CultureInfo.InvariantCulture); }
            // if (!Convert.IsDBNull(reader["Insurance_Agent_Telephone"])) { objility_Claim.Insurance_Agent_Telephone = Convert.ToString(reader["Insurance_Agent_Telephone"], CultureInfo.InvariantCulture); }
            // if (!Convert.IsDBNull(reader["Policy_number"])) { objility_Claim.Policy_number = Convert.ToString(reader["Policy_number"], CultureInfo.InvariantCulture); }
            // //if (!Convert.IsDBNull(reader["Updated_By"])) { objility_Claim_OtherDriverInfo.Updated_By = Convert.ToString(reader["Updated_By"], CultureInfo.InvariantCulture); }
            // //if (!Convert.IsDBNull(reader["Updated_Date"])) { objility_Claim_OtherDriverInfo.Updated_Date = Convert.ToDateTime(reader["Updated_Date"], CultureInfo.InvariantCulture); }

            // //--Injured Persons Information

            // //--Witness
            // //if (!Convert.IsDBNull(reader["FK_Liability_Claim"])) { objility_Claim_Witness.FK_Liability_Claim = Convert.ToDecimal(reader["FK_Liability_Claim"], CultureInfo.InvariantCulture); }
            // if (!Convert.IsDBNull(reader["Witeness_Name"])) { objility_Claim.Witeness_Name = Convert.ToString(reader["Witeness_Name"], CultureInfo.InvariantCulture); }
            // if (!Convert.IsDBNull(reader["Witness_Address1"])) { objility_Claim.Witness_Address1 = Convert.ToString(reader["Witness_Address1"], CultureInfo.InvariantCulture); }
            // if (!Convert.IsDBNull(reader["Witness_Address2"])) { objility_Claim.Witness_Address2 = Convert.ToString(reader["Witness_Address2"], CultureInfo.InvariantCulture); }
            // if (!Convert.IsDBNull(reader["Witness_City"])) { objility_Claim.Witness_City = Convert.ToString(reader["Witness_City"], CultureInfo.InvariantCulture); }
            // if (!Convert.IsDBNull(reader["FK_Witness_State"])) { objility_Claim.FK_Witness_State = Convert.ToDecimal(reader["FK_Witness_State"], CultureInfo.InvariantCulture); }
            // if (!Convert.IsDBNull(reader["Witness_Zipcode"])) { objility_Claim.Witness_Zipcode = Convert.ToString(reader["Witness_Zipcode"], CultureInfo.InvariantCulture); }
            // if (!Convert.IsDBNull(reader["Witness_Telephone"])) { objility_Claim.Witness_Telephone = Convert.ToString(reader["Witness_Telephone"], CultureInfo.InvariantCulture); }
            // if (!Convert.IsDBNull(reader["Witness_Statement"])) { objility_Claim.Witness_Statement = Convert.ToString(reader["Witness_Statement"], CultureInfo.InvariantCulture); }
            // //if (!Convert.IsDBNull(reader["Updated_By"])) { objility_Claim_Witness.Updated_By = Convert.ToString(reader["Updated_By"], CultureInfo.InvariantCulture); }
            // //if (!Convert.IsDBNull(reader["Updated_Date"])) { objility_Claim_Witness.Updated_Date = Convert.ToDateTime(reader["Updated_Date"], CultureInfo.InvariantCulture); }
            #endregion


        }

        public override List<RIMS_Base.CLiabilityClaim_FCI> GetEmployee_ByID(System.Int32 pK_Liability_Claim, System.Decimal pK_Employee_Id)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("AutoLiabilityEmployee_Data_ByID");
                dbHelper.AddInParameter(cmd, "@PK_Liability_Claim", DbType.Int32, pK_Liability_Claim);
                dbHelper.AddInParameter(cmd, "@PK_Employee_ID", DbType.Int32, pK_Employee_Id);
                List<RIMS_Base.CLiabilityClaim_FCI> results = new List<RIMS_Base.CLiabilityClaim_FCI>();
                IDataReader reader = dbHelper.ExecuteReader(cmd);
                CLiabilityClaim_FCI objility_Claim = new CLiabilityClaim_FCI();

                if (reader.Read())
                {
                    objility_Claim = MapFromEmp(reader);
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
        protected RIMS_Base.Dal.CLiabilityClaim_FCI MapFromEmp(IDataReader reader)
        {
            RIMS_Base.Dal.CLiabilityClaim_FCI objility_Claim = new RIMS_Base.Dal.CLiabilityClaim_FCI();
            if (!Convert.IsDBNull(reader["First_Name"])) { objility_Claim.First_Name = Convert.ToString(reader["First_Name"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Last_Name"])) { objility_Claim.Last_Name = Convert.ToString(reader["Last_Name"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Middle_Name"])) { objility_Claim.Middle_Name = Convert.ToString(reader["Middle_Name"], CultureInfo.InvariantCulture); }
            return objility_Claim;
        }

        public override List<RIMS_Base.CLiabilityClaim_FCI> GetCliamant_ByID(System.Int32 pK_Liability_Claim, System.Decimal pK_Claimant_Id)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("AutoLiabilityCliamant_Data_ByID");
                dbHelper.AddInParameter(cmd, "@PK_Liability_Claim", DbType.Int32, pK_Liability_Claim);
                dbHelper.AddInParameter(cmd, "@PK_Claimant_Id", DbType.Int32, pK_Claimant_Id);
                List<RIMS_Base.CLiabilityClaim_FCI> results = new List<RIMS_Base.CLiabilityClaim_FCI>();
                IDataReader reader = dbHelper.ExecuteReader(cmd);
                CLiabilityClaim_FCI objility_Claim = new CLiabilityClaim_FCI();

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
        protected RIMS_Base.Dal.CLiabilityClaim_FCI MapFromCliamant(IDataReader reader)
        {
            RIMS_Base.Dal.CLiabilityClaim_FCI objility_Claim = new RIMS_Base.Dal.CLiabilityClaim_FCI();
            if (!Convert.IsDBNull(reader["First_Name"])) { objility_Claim.Cliamant_First_Name = Convert.ToString(reader["First_Name"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Last_Name"])) { objility_Claim.Cliamant_Last_Name = Convert.ToString(reader["Last_Name"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Middle_Name"])) { objility_Claim.Cliamant_Middle_Name = Convert.ToString(reader["Middle_Name"], CultureInfo.InvariantCulture); }
            return objility_Claim;
        }

        public override List<RIMS_Base.CLiabilityClaim_FCI> GetDriver_ByID(System.Int32 pK_Liability_Claim, System.Decimal pK_Property_Drivers)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("AutoLiabilityDriver_Data_ByID");
                dbHelper.AddInParameter(cmd, "@PK_Liability_Claim", DbType.Int32, pK_Liability_Claim);
                dbHelper.AddInParameter(cmd, "@PK_Property_Drivers", DbType.Int32, pK_Property_Drivers);
                List<RIMS_Base.CLiabilityClaim_FCI> results = new List<RIMS_Base.CLiabilityClaim_FCI>();
                IDataReader reader = dbHelper.ExecuteReader(cmd);
                CLiabilityClaim_FCI objility_Claim = new CLiabilityClaim_FCI();

                if (reader.Read())
                {
                    objility_Claim = MapFromDriver(reader);
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
        protected RIMS_Base.Dal.CLiabilityClaim_FCI MapFromDriver(IDataReader reader)
        {
            RIMS_Base.Dal.CLiabilityClaim_FCI objility_Claim = new RIMS_Base.Dal.CLiabilityClaim_FCI();
            if (!Convert.IsDBNull(reader["First_Name"])) { objility_Claim.Driver_First_Name = Convert.ToString(reader["First_Name"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Last_Name"])) { objility_Claim.Driver_Last_Name = Convert.ToString(reader["Last_Name"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Middle_Name"])) { objility_Claim.Driver_Middle_Name = Convert.ToString(reader["Middle_Name"], CultureInfo.InvariantCulture); }
            return objility_Claim;
        }

        public override List<RIMS_Base.CLiabilityClaim_FCI> GetCarrier_ByID(System.Int32 pK_Liability_Claim, System.Decimal pK_Policy_Id)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("AutoLiabilityCarrier_Data_ByID");
                dbHelper.AddInParameter(cmd, "@PK_Liability_Claim", DbType.Int32, pK_Liability_Claim);
                dbHelper.AddInParameter(cmd, "@PK_Policy_Id", DbType.Int32, pK_Policy_Id);
                List<RIMS_Base.CLiabilityClaim_FCI> results = new List<RIMS_Base.CLiabilityClaim_FCI>();
                IDataReader reader = dbHelper.ExecuteReader(cmd);
                CLiabilityClaim_FCI objility_Claim = new CLiabilityClaim_FCI();

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
        protected RIMS_Base.Dal.CLiabilityClaim_FCI MapFromCarrier(IDataReader reader)
        {
            RIMS_Base.Dal.CLiabilityClaim_FCI objility_Claim = new RIMS_Base.Dal.CLiabilityClaim_FCI();
            //if (!Convert.IsDBNull(reader["First_Name"])) { objility_Claim.Driver_First_Name = Convert.ToString(reader["First_Name"], CultureInfo.InvariantCulture); }
            //if (!Convert.IsDBNull(reader["Last_Name"])) { objility_Claim.Driver_Last_Name = Convert.ToString(reader["Last_Name"], CultureInfo.InvariantCulture); }
            //if (!Convert.IsDBNull(reader["Middle_Name"])) { objility_Claim.Driver_Middle_Name = Convert.ToString(reader["Middle_Name"], CultureInfo.InvariantCulture); }


            if (!Convert.IsDBNull(reader["Carrier"])) { objility_Claim.Carrier = Convert.ToString(reader["Carrier"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Policy_Number"])) { objility_Claim.Policy_Number_Claim = Convert.ToString(reader["Policy_Number"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Policy_Begin_Date"])) { objility_Claim.Effective_Policy_Date = Convert.ToDateTime(reader["Policy_Begin_Date"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Policy_Expiration_Date"])) { objility_Claim.Expiration_Policy_Date = Convert.ToDateTime(reader["Policy_Expiration_Date"], CultureInfo.InvariantCulture); }


            return objility_Claim;
        }
    }
}

