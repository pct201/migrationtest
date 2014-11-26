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


    public class CLiabilityClaim : RIMS_Base.CLiabilityClaim
    {

        public override int InsertUpdate_Claim(RIMS_Base.CLiabilityClaim ObjLiability_Claim)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            int nRetVal = -1;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Liability_Claim_InsertUpdate_Temp");
                dbHelper.AddParameter(cmd, "@PK_Liability_Claim", DbType.Int32, ParameterDirection.InputOutput, "PK_Liability_Claim", DataRowVersion.Current, ObjLiability_Claim.PK_Liability_Claim);
                dbHelper.AddInParameter(cmd, "@Claim_Number", DbType.String, ObjLiability_Claim.Claim_Number);
                dbHelper.AddInParameter(cmd, "@Employee", DbType.String, ObjLiability_Claim.Employee);
                dbHelper.AddInParameter(cmd, "@FK_Employee_Claimant", DbType.Decimal, ObjLiability_Claim.FK_Employee_Claimant);
                dbHelper.AddInParameter(cmd, "@Owner", DbType.String, ObjLiability_Claim.Owner);
                dbHelper.AddInParameter(cmd, "@Owner_Address_1", DbType.String, ObjLiability_Claim.Owner_Address_1);
                dbHelper.AddInParameter(cmd, "@Owner_Address_2", DbType.String, ObjLiability_Claim.Owner_Address_2);
                dbHelper.AddInParameter(cmd, "@Owner_City", DbType.String, ObjLiability_Claim.Owner_City);
                dbHelper.AddInParameter(cmd, "@FK_State_Owner", DbType.Decimal, ObjLiability_Claim.FK_State_Owner);
                dbHelper.AddInParameter(cmd, "@Owner_Zip", DbType.String, ObjLiability_Claim.Owner_Zip);
                dbHelper.AddInParameter(cmd, "@Owner_Home_Phone", DbType.String, ObjLiability_Claim.Owner_Home_Phone);
                dbHelper.AddInParameter(cmd, "@Owner_Work_Phone", DbType.String, ObjLiability_Claim.Owner_Work_Phone);
                dbHelper.AddInParameter(cmd, "@Claim_Description", DbType.String, ObjLiability_Claim.Claim_Description);
                dbHelper.AddInParameter(cmd, "@Nature", DbType.Decimal, ObjLiability_Claim.Nature);
                dbHelper.AddInParameter(cmd, "@Estimate", DbType.Decimal, ObjLiability_Claim.Estimate);
                dbHelper.AddInParameter(cmd, "@Actual", DbType.Decimal, ObjLiability_Claim.Actual);
                dbHelper.AddInParameter(cmd, "@FK_Road_Type", DbType.Decimal, ObjLiability_Claim.FK_Road_Type);
                dbHelper.AddInParameter(cmd, "@FK_Road_Surface", DbType.Decimal, ObjLiability_Claim.FK_Road_Surface);
                dbHelper.AddInParameter(cmd, "@FK_Claim_Cause", DbType.Decimal, ObjLiability_Claim.FK_Claim_Cause);
                dbHelper.AddInParameter(cmd, "@FK_Body_Parts", DbType.Decimal, ObjLiability_Claim.FK_Body_Parts);
                dbHelper.AddInParameter(cmd, "@FK_Injury", DbType.Decimal, ObjLiability_Claim.FK_Injury);
                dbHelper.AddInParameter(cmd, "@FK_NCCI_Code", DbType.Decimal, ObjLiability_Claim.FK_NCCI_Code);
                dbHelper.AddInParameter(cmd, "@Vocation_Rehab", DbType.String, ObjLiability_Claim.Vocation_Rehab);
                dbHelper.AddInParameter(cmd, "@FK_Liability_Major_Claim_Type", DbType.Decimal, ObjLiability_Claim.FK_Liability_Major_Claim_Type);
                dbHelper.AddInParameter(cmd, "@FK_Liability_Minor_Claim_Type", DbType.Decimal, ObjLiability_Claim.FK_Liability_Minor_Claim_Type);
                dbHelper.AddInParameter(cmd, "@Convertible", DbType.String, ObjLiability_Claim.Convertible);
                dbHelper.AddInParameter(cmd, "@Incident_Date", DbType.DateTime, ObjLiability_Claim.Incident_Date);
                dbHelper.AddInParameter(cmd, "@FK_Fraud_Claim", DbType.Decimal, ObjLiability_Claim.FK_Fraud_Claim);
                dbHelper.AddInParameter(cmd, "@Date_Reported", DbType.DateTime, ObjLiability_Claim.Date_Reported);
                dbHelper.AddInParameter(cmd, "@Claim_Open_Date", DbType.DateTime, ObjLiability_Claim.Claim_Open_Date);
                dbHelper.AddInParameter(cmd, "@Claim_Close_Date", DbType.DateTime, ObjLiability_Claim.Claim_Close_Date);
                dbHelper.AddInParameter(cmd, "@Claim_Reopen_Date", DbType.DateTime, ObjLiability_Claim.Claim_Reopen_Date);
                dbHelper.AddInParameter(cmd, "@Surgery_Required", DbType.String, ObjLiability_Claim.Surgery_Required);
                dbHelper.AddInParameter(cmd, "@Indemnity_Weeks", DbType.Decimal, ObjLiability_Claim.Indemnity_Weeks);
                dbHelper.AddInParameter(cmd, "@FK_State_Jurisdiction", DbType.Decimal, ObjLiability_Claim.FK_State_Jurisdiction);
                dbHelper.AddInParameter(cmd, "@FK_Employee", DbType.Decimal, ObjLiability_Claim.FK_Employee);
                dbHelper.AddInParameter(cmd, "@Reported_To_Police", DbType.String, ObjLiability_Claim.Reported_To_Police);
                dbHelper.AddInParameter(cmd, "@Police_Date", DbType.DateTime, ObjLiability_Claim.Police_Date);
                dbHelper.AddInParameter(cmd, "@Police_Case", DbType.String, ObjLiability_Claim.Police_Case);
                dbHelper.AddInParameter(cmd, "@Police_Officer", DbType.String, ObjLiability_Claim.Police_Officer);
                dbHelper.AddInParameter(cmd, "@Police_Address_1", DbType.String, ObjLiability_Claim.Police_Address_1);
                dbHelper.AddInParameter(cmd, "@Police_Address_2", DbType.String, ObjLiability_Claim.Police_Address_2);
                dbHelper.AddInParameter(cmd, "@Police_City", DbType.String, ObjLiability_Claim.Police_City);
                dbHelper.AddInParameter(cmd, "@FK_State_Police", DbType.Decimal, ObjLiability_Claim.FK_State_Police);
                dbHelper.AddInParameter(cmd, "@Police_Zip_Code", DbType.String, ObjLiability_Claim.Police_Zip_Code);
                dbHelper.AddInParameter(cmd, "@Police_Phone", DbType.String, ObjLiability_Claim.Police_Phone);
                dbHelper.AddInParameter(cmd, "@Police_Comments", DbType.String, ObjLiability_Claim.Police_Comments);
                dbHelper.AddInParameter(cmd, "@FK_Weather", DbType.String, ObjLiability_Claim.FK_Weather);
                dbHelper.AddInParameter(cmd, "@Mobile_Restrictions", DbType.String, ObjLiability_Claim.Mobile_Restrictions);
                dbHelper.AddInParameter(cmd, "@Mobile_Impact_Point", DbType.String, ObjLiability_Claim.Mobile_Impact_Point);
                dbHelper.AddInParameter(cmd, "@Mobile_Parts_Damaged", DbType.String, ObjLiability_Claim.Mobile_Parts_Damaged);
                dbHelper.AddInParameter(cmd, "@Vehicle_Make", DbType.String, ObjLiability_Claim.Vehicle_Make);
                dbHelper.AddInParameter(cmd, "@Vehicle_Model", DbType.String, ObjLiability_Claim.Vehicle_Model);
                dbHelper.AddInParameter(cmd, "@Vehicle_Year", DbType.Decimal, ObjLiability_Claim.Vehicle_Year);
                dbHelper.AddInParameter(cmd, "@Vehicle_Color", DbType.String, ObjLiability_Claim.Vehicle_Color);
                dbHelper.AddInParameter(cmd, "@Vehicle_Identification_Number", DbType.String, ObjLiability_Claim.Vehicle_Identification_Number);
                dbHelper.AddInParameter(cmd, "@Vehicle_Value", DbType.Decimal, ObjLiability_Claim.Vehicle_Value);
                dbHelper.AddInParameter(cmd, "@Mobile_Towed", DbType.String, ObjLiability_Claim.Mobile_Towed);
                dbHelper.AddInParameter(cmd, "@Mobile_Storage_Location", DbType.String, ObjLiability_Claim.Mobile_Storage_Location);
                dbHelper.AddInParameter(cmd, "@Driver_Age", DbType.Decimal, ObjLiability_Claim.Driver_Age);
                dbHelper.AddInParameter(cmd, "@Permission", DbType.String, ObjLiability_Claim.Permission);
                dbHelper.AddInParameter(cmd, "@Second_Driver_Name", DbType.String, ObjLiability_Claim.Second_Driver_Name);
                dbHelper.AddInParameter(cmd, "@Second_Driver_Address_1", DbType.String, ObjLiability_Claim.Second_Driver_Address_1);
                dbHelper.AddInParameter(cmd, "@Second_Driver_Address_2", DbType.String, ObjLiability_Claim.Second_Driver_Address_2);
                dbHelper.AddInParameter(cmd, "@Second_Driver_City", DbType.String, ObjLiability_Claim.Second_Driver_City);
                dbHelper.AddInParameter(cmd, "@FK_State_Second_Driver", DbType.Decimal, ObjLiability_Claim.FK_State_Second_Driver);
                dbHelper.AddInParameter(cmd, "@Second_Driver_Zip_Code", DbType.String, ObjLiability_Claim.Second_Driver_Zip_Code);
                dbHelper.AddInParameter(cmd, "@Second_Driver_Phone", DbType.String, ObjLiability_Claim.Second_Driver_Phone);
                dbHelper.AddInParameter(cmd, "@Second_Driver_Ins_Company", DbType.String, ObjLiability_Claim.Second_Driver_Ins_Company);
                dbHelper.AddInParameter(cmd, "@Second_Driver_Ins_Number", DbType.String, ObjLiability_Claim.Second_Driver_Ins_Number);
                dbHelper.AddInParameter(cmd, "@EMS_Contacted", DbType.String, ObjLiability_Claim.EMS_Contacted);
                dbHelper.AddInParameter(cmd, "@Loss_Payee_Automobiles", DbType.String, ObjLiability_Claim.Loss_Payee_Automobiles);
                dbHelper.AddInParameter(cmd, "@Suit_Date", DbType.DateTime, ObjLiability_Claim.Suit_Date);
                dbHelper.AddInParameter(cmd, "@Attorney_Disclosure_Date", DbType.DateTime, ObjLiability_Claim.Attorney_Disclosure_Date);
                dbHelper.AddInParameter(cmd, "@Client_Attorney_Name", DbType.String, ObjLiability_Claim.Client_Attorney_Name);
                dbHelper.AddInParameter(cmd, "@Client_Attorney_Address_1", DbType.String, ObjLiability_Claim.Client_Attorney_Address_1);
                dbHelper.AddInParameter(cmd, "@Client_Attorney_Address_2", DbType.String, ObjLiability_Claim.Client_Attorney_Address_2);
                dbHelper.AddInParameter(cmd, "@Client_Attorney_City", DbType.String, ObjLiability_Claim.Client_Attorney_City);
                dbHelper.AddInParameter(cmd, "@FK_State_Client_Attorney", DbType.Decimal, ObjLiability_Claim.FK_State_Client_Attorney);
                dbHelper.AddInParameter(cmd, "@Client_Attorney_Zip_Code", DbType.String, ObjLiability_Claim.Client_Attorney_Zip_Code);
                dbHelper.AddInParameter(cmd, "@Client_Attorney_Phone", DbType.String, ObjLiability_Claim.Client_Attorney_Phone);
                dbHelper.AddInParameter(cmd, "@Client_Attorney_Fax", DbType.String, ObjLiability_Claim.Client_Attorney_Fax);
                dbHelper.AddInParameter(cmd, "@Defense_Attorney_Name", DbType.String, ObjLiability_Claim.Defense_Attorney_Name);
                dbHelper.AddInParameter(cmd, "@Defense_Attorney_Address_1", DbType.String, ObjLiability_Claim.Defense_Attorney_Address_1);
                dbHelper.AddInParameter(cmd, "@Defense_Attorney_Address_2", DbType.String, ObjLiability_Claim.Defense_Attorney_Address_2);
                dbHelper.AddInParameter(cmd, "@Defense_Attorney_City", DbType.String, ObjLiability_Claim.Defense_Attorney_City);
                dbHelper.AddInParameter(cmd, "@FK_State_Defense_Attorney", DbType.Decimal, ObjLiability_Claim.FK_State_Defense_Attorney);
                dbHelper.AddInParameter(cmd, "@Defense_Attorney_Zip_Code", DbType.String, ObjLiability_Claim.Defense_Attorney_Zip_Code);
                dbHelper.AddInParameter(cmd, "@Defense_Attorney_Phone", DbType.String, ObjLiability_Claim.Defense_Attorney_Phone);
                dbHelper.AddInParameter(cmd, "@Defense_Attorney_Fax", DbType.String, ObjLiability_Claim.Defense_Attorney_Fax);
                dbHelper.AddInParameter(cmd, "@Updated_By", DbType.String, ObjLiability_Claim.Updated_By);
                dbHelper.AddInParameter(cmd, "@Update_Date", DbType.DateTime, ObjLiability_Claim.Update_Date);
                dbHelper.AddInParameter(cmd, "@Criminal_Violation", DbType.String, ObjLiability_Claim.Criminal_Violation);
                dbHelper.AddInParameter(cmd, "@FK_Property", DbType.Decimal, ObjLiability_Claim.FK_Property);
                dbHelper.AddInParameter(cmd, "@FK_Weather_Incident", DbType.Decimal, ObjLiability_Claim.FK_Weather_Incident);
                dbHelper.AddInParameter(cmd, "@Loss_Description", DbType.String, ObjLiability_Claim.Loss_Description);
                dbHelper.AddInParameter(cmd, "@FK_Policy_Number", DbType.Decimal, ObjLiability_Claim.FK_Policy_Number);
                dbHelper.AddInParameter(cmd, "@Percent_Flood", DbType.Decimal, ObjLiability_Claim.Percent_Flood);
                dbHelper.AddInParameter(cmd, "@Percent_Wind", DbType.Decimal, ObjLiability_Claim.Percent_Wind);
                dbHelper.AddInParameter(cmd, "@Percent_Fire", DbType.Decimal, ObjLiability_Claim.Percent_Fire);
                dbHelper.AddInParameter(cmd, "@Percent_Other", DbType.Decimal, ObjLiability_Claim.Percent_Other);
                dbHelper.AddInParameter(cmd, "@Date_Bus_Closed", DbType.DateTime, ObjLiability_Claim.Date_Bus_Closed);
                dbHelper.AddInParameter(cmd, "@Date_Bus_Reopened", DbType.DateTime, ObjLiability_Claim.Date_Bus_Reopened);
                dbHelper.AddInParameter(cmd, "@FK_Cost_Center", DbType.String, ObjLiability_Claim.FK_Cost_Center);
                dbHelper.AddInParameter(cmd, "@Building_Percent_Flood", DbType.Decimal, ObjLiability_Claim.Building_Percent_Flood);
                dbHelper.AddInParameter(cmd, "@Building_Percent_Wind", DbType.Decimal, ObjLiability_Claim.Building_Percent_Wind);
                dbHelper.AddInParameter(cmd, "@Building_Percent_Fire", DbType.Decimal, ObjLiability_Claim.Building_Percent_Fire);
                dbHelper.AddInParameter(cmd, "@Building_Percent_Other", DbType.Decimal, ObjLiability_Claim.Building_Percent_Other);
                dbHelper.AddInParameter(cmd, "@Contents_Percent_Flood", DbType.Decimal, ObjLiability_Claim.Contents_Percent_Flood);
                dbHelper.AddInParameter(cmd, "@Contents_Percent_Wind", DbType.Decimal, ObjLiability_Claim.Contents_Percent_Wind);
                dbHelper.AddInParameter(cmd, "@Contents_Percent_Fire", DbType.Decimal, ObjLiability_Claim.Contents_Percent_Fire);
                dbHelper.AddInParameter(cmd, "@Contents_Percent_Other", DbType.Decimal, ObjLiability_Claim.Contents_Percent_Other);
                dbHelper.AddInParameter(cmd, "@Computers_Percent_Flood", DbType.Decimal, ObjLiability_Claim.Computers_Percent_Flood);
                dbHelper.AddInParameter(cmd, "@Computers_Percent_Wind", DbType.Decimal, ObjLiability_Claim.Computers_Percent_Wind);
                dbHelper.AddInParameter(cmd, "@Computers_Percent_Fire", DbType.Decimal, ObjLiability_Claim.Computers_Percent_Fire);
                dbHelper.AddInParameter(cmd, "@Computers_Percent_Other", DbType.Decimal, ObjLiability_Claim.Computers_Percent_Other);
                dbHelper.AddInParameter(cmd, "@ATMs_Percent_Flood", DbType.Decimal, ObjLiability_Claim.ATMs_Percent_Flood);
                dbHelper.AddInParameter(cmd, "@ATMs_Percent_Wind", DbType.Decimal, ObjLiability_Claim.ATMs_Percent_Wind);
                dbHelper.AddInParameter(cmd, "@ATMs_Percent_Fire", DbType.Decimal, ObjLiability_Claim.ATMs_Percent_Fire);
                dbHelper.AddInParameter(cmd, "@ATMs_Percent_Other", DbType.Decimal, ObjLiability_Claim.ATMs_Percent_Other);
                dbHelper.AddInParameter(cmd, "@Leasehold_Improvements_Percent_Flood", DbType.Decimal, ObjLiability_Claim.Leasehold_Improvements_Percent_Flood);
                dbHelper.AddInParameter(cmd, "@Leasehold_Improvements_Percent_Wind", DbType.Decimal, ObjLiability_Claim.Leasehold_Improvements_Percent_Wind);
                dbHelper.AddInParameter(cmd, "@Leasehold_Improvements_Percent_Fire", DbType.Decimal, ObjLiability_Claim.Leasehold_Improvements_Percent_Fire);
                dbHelper.AddInParameter(cmd, "@Leasehold_Improvements_Percent_Other", DbType.Decimal, ObjLiability_Claim.Leasehold_Improvements_Percent_Other);
                dbHelper.AddInParameter(cmd, "@Signs_Percent_Flood", DbType.Decimal, ObjLiability_Claim.Signs_Percent_Flood);
                dbHelper.AddInParameter(cmd, "@Signs_Percent_Wind", DbType.Decimal, ObjLiability_Claim.Signs_Percent_Wind);
                dbHelper.AddInParameter(cmd, "@Signs_Percent_Fire", DbType.Decimal, ObjLiability_Claim.Signs_Percent_Fire);
                dbHelper.AddInParameter(cmd, "@Signs_Percent_Other", DbType.Decimal, ObjLiability_Claim.Signs_Percent_Other);
                dbHelper.AddInParameter(cmd, "@Fine_Arts_Percent_Flood", DbType.Decimal, ObjLiability_Claim.Fine_Arts_Percent_Flood);
                dbHelper.AddInParameter(cmd, "@Fine_Arts_Percent_Wind", DbType.Decimal, ObjLiability_Claim.Fine_Arts_Percent_Wind);
                dbHelper.AddInParameter(cmd, "@Fine_Arts_Percent_Fire", DbType.Decimal, ObjLiability_Claim.Fine_Arts_Percent_Fire);
                dbHelper.AddInParameter(cmd, "@Fine_Arts_Percent_Other", DbType.Decimal, ObjLiability_Claim.Fine_Arts_Percent_Other);
                dbHelper.AddInParameter(cmd, "@FK_NCCI_Nature", DbType.Decimal, ObjLiability_Claim.FK_NCCI_Nature);
                dbHelper.AddInParameter(cmd, "@Liability_Product_Name_new", DbType.String, ObjLiability_Claim.Liability_Product_Name_new);
                dbHelper.AddInParameter(cmd, "@FK_Hazard_Code", DbType.Decimal, ObjLiability_Claim.FK_Hazard_Code);
                dbHelper.AddInParameter(cmd, "@Location_Description", DbType.String, ObjLiability_Claim.Location_Description);
                dbHelper.AddInParameter(cmd, "@FK_Comprehensive_Deductible", DbType.Decimal, ObjLiability_Claim.FK_Comprehensive_Deductible);
                dbHelper.AddInParameter(cmd, "@FK_Collision_Deductible", DbType.Decimal, ObjLiability_Claim.FK_Collision_Deductible);
                dbHelper.AddInParameter(cmd, "@FK_Original_Cost", DbType.Decimal, ObjLiability_Claim.FK_Original_Cost);
                dbHelper.ExecuteNonQuery(cmd);
                nRetVal = int.Parse(dbHelper.GetParameterValue(cmd, "@PK_Liability_Claim").ToString());
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
        public override int Delete_Claim(System.Int32 lPK_Liability_Claim)
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
        public override string ActivateInactivate_Claim(string strIDs, int intModifiedBy, bool bIsActive)
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
        public override List<RIMS_Base.CLiabilityClaim> GetAll(Boolean blnIsActive)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Lia_Selectility_Claim");
                dbHelper.AddInParameter(cmd, "@IsActive", DbType.Boolean, blnIsActive);
                IDataReader reader = dbHelper.ExecuteReader(cmd);
                List<RIMS_Base.CLiabilityClaim> results = new List<RIMS_Base.CLiabilityClaim>();
                while (reader.Read())
                {
                    CLiabilityClaim ObjLiability_Claim = new CLiabilityClaim();
                    ObjLiability_Claim = MapFrom(reader);
                    results.Add(ObjLiability_Claim);
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


        public override List<RIMS_Base.CLiabilityClaim> Getility_ClaimByID(System.Int32 pK_Liability_Claim)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Liability_Select_Temp");
                dbHelper.AddInParameter(cmd, "@PK_Liability_Claim", DbType.Int32, pK_Liability_Claim);

                IDataReader reader = dbHelper.ExecuteReader(cmd);

                List<RIMS_Base.CLiabilityClaim> results = new List<RIMS_Base.CLiabilityClaim>();

                while (reader.Read())
                {
                    CLiabilityClaim ObjLiability_Claim = new CLiabilityClaim();
                    ObjLiability_Claim = MapFrom(reader);
                    results.Add(ObjLiability_Claim);
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


        protected RIMS_Base.Dal.CLiabilityClaim MapFrom(IDataReader reader)
        {
            RIMS_Base.Dal.CLiabilityClaim ObjLiability_Claim = new RIMS_Base.Dal.CLiabilityClaim();
            if (!Convert.IsDBNull(reader["PK_Liability_Claim"])) { ObjLiability_Claim.PK_Liability_Claim = Convert.ToInt32(reader["PK_Liability_Claim"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Claim_Number"])) { ObjLiability_Claim.Claim_Number = Convert.ToString(reader["Claim_Number"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Employee"])) { ObjLiability_Claim.Employee = Convert.ToString(reader["Employee"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FK_Employee_Claimant"])) { ObjLiability_Claim.FK_Employee_Claimant = Convert.ToDecimal(reader["FK_Employee_Claimant"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Owner"])) { ObjLiability_Claim.Owner = Convert.ToString(reader["Owner"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Owner_Address_1"])) { ObjLiability_Claim.Owner_Address_1 = Convert.ToString(reader["Owner_Address_1"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Owner_Address_2"])) { ObjLiability_Claim.Owner_Address_2 = Convert.ToString(reader["Owner_Address_2"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Owner_City"])) { ObjLiability_Claim.Owner_City = Convert.ToString(reader["Owner_City"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FK_State_Owner"])) { ObjLiability_Claim.FK_State_Owner = Convert.ToDecimal(reader["FK_State_Owner"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Owner_Zip"])) { ObjLiability_Claim.Owner_Zip = Convert.ToString(reader["Owner_Zip"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Owner_Home_Phone"])) { ObjLiability_Claim.Owner_Home_Phone = Convert.ToString(reader["Owner_Home_Phone"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Owner_Work_Phone"])) { ObjLiability_Claim.Owner_Work_Phone = Convert.ToString(reader["Owner_Work_Phone"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Claim_Description"])) { ObjLiability_Claim.Claim_Description = Convert.ToString(reader["Claim_Description"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Nature"])) { ObjLiability_Claim.Nature = Convert.ToDecimal(reader["Nature"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Estimate"])) { ObjLiability_Claim.Estimate = Convert.ToDecimal(reader["Estimate"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Actual"])) { ObjLiability_Claim.Actual = Convert.ToDecimal(reader["Actual"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FK_Road_Type"])) { ObjLiability_Claim.FK_Road_Type = Convert.ToDecimal(reader["FK_Road_Type"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FK_Road_Surface"])) { ObjLiability_Claim.FK_Road_Surface = Convert.ToDecimal(reader["FK_Road_Surface"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FK_Claim_Cause"])) { ObjLiability_Claim.FK_Claim_Cause = Convert.ToDecimal(reader["FK_Claim_Cause"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FK_Body_Parts"])) { ObjLiability_Claim.FK_Body_Parts = Convert.ToDecimal(reader["FK_Body_Parts"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FK_Injury"])) { ObjLiability_Claim.FK_Injury = Convert.ToDecimal(reader["FK_Injury"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FK_NCCI_Code"])) { ObjLiability_Claim.FK_NCCI_Code = Convert.ToDecimal(reader["FK_NCCI_Code"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Vocation_Rehab"])) { ObjLiability_Claim.Vocation_Rehab = Convert.ToString(reader["Vocation_Rehab"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FK_Liability_Major_Claim_Type"])) { ObjLiability_Claim.FK_Liability_Major_Claim_Type = Convert.ToDecimal(reader["FK_Liability_Major_Claim_Type"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FK_Liability_Minor_Claim_Type"])) { ObjLiability_Claim.FK_Liability_Minor_Claim_Type = Convert.ToDecimal(reader["FK_Liability_Minor_Claim_Type"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Convertible"])) { ObjLiability_Claim.Convertible = Convert.ToString(reader["Convertible"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Incident_Date"])) { ObjLiability_Claim.Incident_Date = Convert.ToDateTime(reader["Incident_Date"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FK_Fraud_Claim"])) { ObjLiability_Claim.FK_Fraud_Claim = Convert.ToDecimal(reader["FK_Fraud_Claim"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Date_Reported"])) { ObjLiability_Claim.Date_Reported = Convert.ToDateTime(reader["Date_Reported"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Claim_Open_Date"])) { ObjLiability_Claim.Claim_Open_Date = Convert.ToDateTime(reader["Claim_Open_Date"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Claim_Close_Date"])) { ObjLiability_Claim.Claim_Close_Date = Convert.ToDateTime(reader["Claim_Close_Date"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Claim_Reopen_Date"])) { ObjLiability_Claim.Claim_Reopen_Date = Convert.ToDateTime(reader["Claim_Reopen_Date"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Surgery_Required"])) { ObjLiability_Claim.Surgery_Required = Convert.ToString(reader["Surgery_Required"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Indemnity_Weeks"])) { ObjLiability_Claim.Indemnity_Weeks = Convert.ToDecimal(reader["Indemnity_Weeks"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FK_State_Jurisdiction"])) { ObjLiability_Claim.FK_State_Jurisdiction = Convert.ToDecimal(reader["FK_State_Jurisdiction"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FK_Employee"])) { ObjLiability_Claim.FK_Employee = Convert.ToDecimal(reader["FK_Employee"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Reported_To_Police"])) { ObjLiability_Claim.Reported_To_Police = Convert.ToString(reader["Reported_To_Police"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Police_Date"])) { ObjLiability_Claim.Police_Date = Convert.ToDateTime(reader["Police_Date"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Police_Case"])) { ObjLiability_Claim.Police_Case = Convert.ToString(reader["Police_Case"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Police_Officer"])) { ObjLiability_Claim.Police_Officer = Convert.ToString(reader["Police_Officer"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Police_Address_1"])) { ObjLiability_Claim.Police_Address_1 = Convert.ToString(reader["Police_Address_1"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Police_Address_2"])) { ObjLiability_Claim.Police_Address_2 = Convert.ToString(reader["Police_Address_2"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Police_City"])) { ObjLiability_Claim.Police_City = Convert.ToString(reader["Police_City"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FK_State_Police"])) { ObjLiability_Claim.FK_State_Police = Convert.ToDecimal(reader["FK_State_Police"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Police_Zip_Code"])) { ObjLiability_Claim.Police_Zip_Code = Convert.ToString(reader["Police_Zip_Code"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Police_Phone"])) { ObjLiability_Claim.Police_Phone = Convert.ToString(reader["Police_Phone"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Police_Comments"])) { ObjLiability_Claim.Police_Comments = Convert.ToString(reader["Police_Comments"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FK_Weather"])) { ObjLiability_Claim.FK_Weather = Convert.ToString(reader["FK_Weather"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Mobile_Restrictions"])) { ObjLiability_Claim.Mobile_Restrictions = Convert.ToString(reader["Mobile_Restrictions"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Mobile_Impact_Point"])) { ObjLiability_Claim.Mobile_Impact_Point = Convert.ToString(reader["Mobile_Impact_Point"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Mobile_Parts_Damaged"])) { ObjLiability_Claim.Mobile_Parts_Damaged = Convert.ToString(reader["Mobile_Parts_Damaged"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Vehicle_Make"])) { ObjLiability_Claim.Vehicle_Make = Convert.ToString(reader["Vehicle_Make"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Vehicle_Model"])) { ObjLiability_Claim.Vehicle_Model = Convert.ToString(reader["Vehicle_Model"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Vehicle_Year"])) { ObjLiability_Claim.Vehicle_Year = Convert.ToDecimal(reader["Vehicle_Year"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Vehicle_Color"])) { ObjLiability_Claim.Vehicle_Color = Convert.ToString(reader["Vehicle_Color"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Vehicle_Identification_Number"])) { ObjLiability_Claim.Vehicle_Identification_Number = Convert.ToString(reader["Vehicle_Identification_Number"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Vehicle_Value"])) { ObjLiability_Claim.Vehicle_Value = Convert.ToDecimal(reader["Vehicle_Value"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Mobile_Towed"])) { ObjLiability_Claim.Mobile_Towed = Convert.ToString(reader["Mobile_Towed"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Mobile_Storage_Location"])) { ObjLiability_Claim.Mobile_Storage_Location = Convert.ToString(reader["Mobile_Storage_Location"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Driver_Age"])) { ObjLiability_Claim.Driver_Age = Convert.ToDecimal(reader["Driver_Age"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Permission"])) { ObjLiability_Claim.Permission = Convert.ToString(reader["Permission"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Second_Driver_Name"])) { ObjLiability_Claim.Second_Driver_Name = Convert.ToString(reader["Second_Driver_Name"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Second_Driver_Address_1"])) { ObjLiability_Claim.Second_Driver_Address_1 = Convert.ToString(reader["Second_Driver_Address_1"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Second_Driver_Address_2"])) { ObjLiability_Claim.Second_Driver_Address_2 = Convert.ToString(reader["Second_Driver_Address_2"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Second_Driver_City"])) { ObjLiability_Claim.Second_Driver_City = Convert.ToString(reader["Second_Driver_City"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FK_State_Second_Driver"])) { ObjLiability_Claim.FK_State_Second_Driver = Convert.ToDecimal(reader["FK_State_Second_Driver"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Second_Driver_Zip_Code"])) { ObjLiability_Claim.Second_Driver_Zip_Code = Convert.ToString(reader["Second_Driver_Zip_Code"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Second_Driver_Phone"])) { ObjLiability_Claim.Second_Driver_Phone = Convert.ToString(reader["Second_Driver_Phone"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Second_Driver_Ins_Company"])) { ObjLiability_Claim.Second_Driver_Ins_Company = Convert.ToString(reader["Second_Driver_Ins_Company"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Second_Driver_Ins_Number"])) { ObjLiability_Claim.Second_Driver_Ins_Number = Convert.ToString(reader["Second_Driver_Ins_Number"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["EMS_Contacted"])) { ObjLiability_Claim.EMS_Contacted = Convert.ToString(reader["EMS_Contacted"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Loss_Payee_Automobiles"])) { ObjLiability_Claim.Loss_Payee_Automobiles = Convert.ToString(reader["Loss_Payee_Automobiles"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Suit_Date"])) { ObjLiability_Claim.Suit_Date = Convert.ToDateTime(reader["Suit_Date"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Attorney_Disclosure_Date"])) { ObjLiability_Claim.Attorney_Disclosure_Date = Convert.ToDateTime(reader["Attorney_Disclosure_Date"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Client_Attorney_Name"])) { ObjLiability_Claim.Client_Attorney_Name = Convert.ToString(reader["Client_Attorney_Name"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Client_Attorney_Address_1"])) { ObjLiability_Claim.Client_Attorney_Address_1 = Convert.ToString(reader["Client_Attorney_Address_1"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Client_Attorney_Address_2"])) { ObjLiability_Claim.Client_Attorney_Address_2 = Convert.ToString(reader["Client_Attorney_Address_2"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Client_Attorney_City"])) { ObjLiability_Claim.Client_Attorney_City = Convert.ToString(reader["Client_Attorney_City"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FK_State_Client_Attorney"])) { ObjLiability_Claim.FK_State_Client_Attorney = Convert.ToDecimal(reader["FK_State_Client_Attorney"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Client_Attorney_Zip_Code"])) { ObjLiability_Claim.Client_Attorney_Zip_Code = Convert.ToString(reader["Client_Attorney_Zip_Code"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Client_Attorney_Phone"])) { ObjLiability_Claim.Client_Attorney_Phone = Convert.ToString(reader["Client_Attorney_Phone"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Client_Attorney_Fax"])) { ObjLiability_Claim.Client_Attorney_Fax = Convert.ToString(reader["Client_Attorney_Fax"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Defense_Attorney_Name"])) { ObjLiability_Claim.Defense_Attorney_Name = Convert.ToString(reader["Defense_Attorney_Name"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Defense_Attorney_Address_1"])) { ObjLiability_Claim.Defense_Attorney_Address_1 = Convert.ToString(reader["Defense_Attorney_Address_1"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Defense_Attorney_Address_2"])) { ObjLiability_Claim.Defense_Attorney_Address_2 = Convert.ToString(reader["Defense_Attorney_Address_2"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Defense_Attorney_City"])) { ObjLiability_Claim.Defense_Attorney_City = Convert.ToString(reader["Defense_Attorney_City"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FK_State_Defense_Attorney"])) { ObjLiability_Claim.FK_State_Defense_Attorney = Convert.ToDecimal(reader["FK_State_Defense_Attorney"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Defense_Attorney_Zip_Code"])) { ObjLiability_Claim.Defense_Attorney_Zip_Code = Convert.ToString(reader["Defense_Attorney_Zip_Code"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Defense_Attorney_Phone"])) { ObjLiability_Claim.Defense_Attorney_Phone = Convert.ToString(reader["Defense_Attorney_Phone"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Defense_Attorney_Fax"])) { ObjLiability_Claim.Defense_Attorney_Fax = Convert.ToString(reader["Defense_Attorney_Fax"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Updated_By"])) { ObjLiability_Claim.Updated_By = Convert.ToString(reader["Updated_By"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Update_Date"])) { ObjLiability_Claim.Update_Date = Convert.ToDateTime(reader["Update_Date"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Criminal_Violation"])) { ObjLiability_Claim.Criminal_Violation = Convert.ToString(reader["Criminal_Violation"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FK_Property"])) { ObjLiability_Claim.FK_Property = Convert.ToDecimal(reader["FK_Property"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FK_Weather_Incident"])) { ObjLiability_Claim.FK_Weather_Incident = Convert.ToDecimal(reader["FK_Weather_Incident"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Loss_Description"])) { ObjLiability_Claim.Loss_Description = Convert.ToString(reader["Loss_Description"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FK_Policy_Number"])) { ObjLiability_Claim.FK_Policy_Number = Convert.ToDecimal(reader["FK_Policy_Number"], CultureInfo.InvariantCulture); }
            //if (!Convert.IsDBNull(reader["Percent_Flood"])) { ObjLiability_Claim.Percent_Flood = Convert.ToDecimal(reader["Percent_Flood"], CultureInfo.InvariantCulture); }
            //if (!Convert.IsDBNull(reader["Percent_Wind"])) { ObjLiability_Claim.Percent_Wind = Convert.ToDecimal(reader["Percent_Wind"], CultureInfo.InvariantCulture); }
            //if (!Convert.IsDBNull(reader["Percent_Fire"])) { ObjLiability_Claim.Percent_Fire = Convert.ToDecimal(reader["Percent_Fire"], CultureInfo.InvariantCulture); }
            //if (!Convert.IsDBNull(reader["Percent_Other"])) { ObjLiability_Claim.Percent_Other = Convert.ToDecimal(reader["Percent_Other"], CultureInfo.InvariantCulture); }
            //if (!Convert.IsDBNull(reader["Date_Bus_Closed"])) { ObjLiability_Claim.Date_Bus_Closed = Convert.ToDateTime(reader["Date_Bus_Closed"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Date_Bus_Reopened"])) { ObjLiability_Claim.Date_Bus_Reopened = Convert.ToDateTime(reader["Date_Bus_Reopened"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FK_Cost_Center"])) { ObjLiability_Claim.FK_Cost_Center = Convert.ToString(reader["FK_Cost_Center"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Building_Percent_Flood"])) { ObjLiability_Claim.Building_Percent_Flood = Convert.ToDecimal(reader["Building_Percent_Flood"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Building_Percent_Wind"])) { ObjLiability_Claim.Building_Percent_Wind = Convert.ToDecimal(reader["Building_Percent_Wind"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Building_Percent_Fire"])) { ObjLiability_Claim.Building_Percent_Fire = Convert.ToDecimal(reader["Building_Percent_Fire"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Building_Percent_Other"])) { ObjLiability_Claim.Building_Percent_Other = Convert.ToDecimal(reader["Building_Percent_Other"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Contents_Percent_Flood"])) { ObjLiability_Claim.Contents_Percent_Flood = Convert.ToDecimal(reader["Contents_Percent_Flood"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Contents_Percent_Wind"])) { ObjLiability_Claim.Contents_Percent_Wind = Convert.ToDecimal(reader["Contents_Percent_Wind"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Contents_Percent_Fire"])) { ObjLiability_Claim.Contents_Percent_Fire = Convert.ToDecimal(reader["Contents_Percent_Fire"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Contents_Percent_Other"])) { ObjLiability_Claim.Contents_Percent_Other = Convert.ToDecimal(reader["Contents_Percent_Other"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Computers_Percent_Flood"])) { ObjLiability_Claim.Computers_Percent_Flood = Convert.ToDecimal(reader["Computers_Percent_Flood"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Computers_Percent_Wind"])) { ObjLiability_Claim.Computers_Percent_Wind = Convert.ToDecimal(reader["Computers_Percent_Wind"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Computers_Percent_Fire"])) { ObjLiability_Claim.Computers_Percent_Fire = Convert.ToDecimal(reader["Computers_Percent_Fire"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Computers_Percent_Other"])) { ObjLiability_Claim.Computers_Percent_Other = Convert.ToDecimal(reader["Computers_Percent_Other"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["ATMs_Percent_Flood"])) { ObjLiability_Claim.ATMs_Percent_Flood = Convert.ToDecimal(reader["ATMs_Percent_Flood"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["ATMs_Percent_Wind"])) { ObjLiability_Claim.ATMs_Percent_Wind = Convert.ToDecimal(reader["ATMs_Percent_Wind"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["ATMs_Percent_Fire"])) { ObjLiability_Claim.ATMs_Percent_Fire = Convert.ToDecimal(reader["ATMs_Percent_Fire"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["ATMs_Percent_Other"])) { ObjLiability_Claim.ATMs_Percent_Other = Convert.ToDecimal(reader["ATMs_Percent_Other"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Leasehold_Improvements_Percent_Flood"])) { ObjLiability_Claim.Leasehold_Improvements_Percent_Flood = Convert.ToDecimal(reader["Leasehold_Improvements_Percent_Flood"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Leasehold_Improvements_Percent_Wind"])) { ObjLiability_Claim.Leasehold_Improvements_Percent_Wind = Convert.ToDecimal(reader["Leasehold_Improvements_Percent_Wind"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Leasehold_Improvements_Percent_Fire"])) { ObjLiability_Claim.Leasehold_Improvements_Percent_Fire = Convert.ToDecimal(reader["Leasehold_Improvements_Percent_Fire"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Leasehold_Improvements_Percent_Other"])) { ObjLiability_Claim.Leasehold_Improvements_Percent_Other = Convert.ToDecimal(reader["Leasehold_Improvements_Percent_Other"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Signs_Percent_Flood"])) { ObjLiability_Claim.Signs_Percent_Flood = Convert.ToDecimal(reader["Signs_Percent_Flood"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Signs_Percent_Wind"])) { ObjLiability_Claim.Signs_Percent_Wind = Convert.ToDecimal(reader["Signs_Percent_Wind"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Signs_Percent_Fire"])) { ObjLiability_Claim.Signs_Percent_Fire = Convert.ToDecimal(reader["Signs_Percent_Fire"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Signs_Percent_Other"])) { ObjLiability_Claim.Signs_Percent_Other = Convert.ToDecimal(reader["Signs_Percent_Other"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Fine_Arts_Percent_Flood"])) { ObjLiability_Claim.Fine_Arts_Percent_Flood = Convert.ToDecimal(reader["Fine_Arts_Percent_Flood"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Fine_Arts_Percent_Wind"])) { ObjLiability_Claim.Fine_Arts_Percent_Wind = Convert.ToDecimal(reader["Fine_Arts_Percent_Wind"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Fine_Arts_Percent_Fire"])) { ObjLiability_Claim.Fine_Arts_Percent_Fire = Convert.ToDecimal(reader["Fine_Arts_Percent_Fire"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Fine_Arts_Percent_Other"])) { ObjLiability_Claim.Fine_Arts_Percent_Other = Convert.ToDecimal(reader["Fine_Arts_Percent_Other"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FK_NCCI_Nature"])) { ObjLiability_Claim.FK_NCCI_Nature = Convert.ToDecimal(reader["FK_NCCI_Nature"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Liability_Product_Name_new"])) { ObjLiability_Claim.Liability_Product_Name_new = Convert.ToString(reader["Liability_Product_Name_new"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FK_Hazard_Code"])) { ObjLiability_Claim.FK_Hazard_Code = Convert.ToDecimal(reader["FK_Hazard_Code"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Location_Description"])) { ObjLiability_Claim.Location_Description = Convert.ToString(reader["Location_Description"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FK_Comprehensive_Deductible"])) { ObjLiability_Claim.FK_Comprehensive_Deductible = Convert.ToDecimal(reader["FK_Comprehensive_Deductible"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FK_Collision_Deductible"])) { ObjLiability_Claim.FK_Collision_Deductible = Convert.ToDecimal(reader["FK_Collision_Deductible"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FK_Original_Cost"])) { ObjLiability_Claim.FK_Original_Cost = Convert.ToDecimal(reader["FK_Original_Cost"], CultureInfo.InvariantCulture); }
            return ObjLiability_Claim;
        }


        public override List<RIMS_Base.CLiabilityClaim> Get_Property_ByID(System.Int32 @fK_Liability_Claim, System.Decimal pK_Property_ID)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            //  DataSet m_dsProperty = new DataSet();
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Proprty_Select_ByID");
                dbHelper.AddInParameter(cmd, "@FK_Liability_Claim", DbType.Int32, fK_Liability_Claim);
                dbHelper.AddInParameter(cmd, "@PK_Property_ID", DbType.Decimal, pK_Property_ID);


                List<RIMS_Base.CLiabilityClaim> result = new List<RIMS_Base.CLiabilityClaim>();

                IDataReader reader = dbHelper.ExecuteReader(cmd);
                CLiabilityClaim Obj_Property = new CLiabilityClaim();
                if (reader.Read())
                {
                    Obj_Property = MapFromProperty(reader);
                    result.Add(Obj_Property);
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


        protected RIMS_Base.Dal.CLiabilityClaim MapFromProperty(IDataReader reader)
        {
            RIMS_Base.Dal.CLiabilityClaim objerty = new RIMS_Base.Dal.CLiabilityClaim();
            if (!Convert.IsDBNull(reader["PK_Property_ID"])) { objerty.PK_Property_ID = Convert.ToInt32(reader["PK_Property_ID"], CultureInfo.InvariantCulture); }
            // if (!Convert.IsDBNull(reader["Cost_Center"])) { objerty.Cost_Center = Convert.ToString(reader["Cost_Center"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Facility"])) { objerty.Facility = Convert.ToString(reader["Facility"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Property_Description"])) { objerty.Property_Description = Convert.ToString(reader["Property_Description"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Value"])) { objerty.Value = Convert.ToDecimal(reader["Value"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Valuation_Date"])) { objerty.Valuation_Date = Convert.ToDateTime(reader["Valuation_Date"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Premium"])) { objerty.Premium = Convert.ToDecimal(reader["Premium"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Coverage"])) { objerty.Coverage = Convert.ToDecimal(reader["Coverage"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Mobile_Type"])) { objerty.Mobile_Type = Convert.ToString(reader["Mobile_Type"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Mobile_VIN"])) { objerty.Mobile_VIN = Convert.ToString(reader["Mobile_VIN"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Mobile_Make"])) { objerty.Mobile_Make = Convert.ToString(reader["Mobile_Make"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Mobile_Model"])) { objerty.Mobile_Model = Convert.ToString(reader["Mobile_Model"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Mobile_Year"])) { objerty.Mobile_Year = Convert.ToDecimal(reader["Mobile_Year"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Mobile_Title"])) { objerty.Mobile_Title = Convert.ToString(reader["Mobile_Title"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Stationary_Type"])) { objerty.Stationary_Type = Convert.ToString(reader["Stationary_Type"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Stationary_Year"])) { objerty.Stationary_Year = Convert.ToDecimal(reader["Stationary_Year"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Stationary_Address_1"])) { objerty.Stationary_Address_1 = Convert.ToString(reader["Stationary_Address_1"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Stationary_Address_2"])) { objerty.Stationary_Address_2 = Convert.ToString(reader["Stationary_Address_2"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Stationary_City"])) { objerty.Stationary_City = Convert.ToString(reader["Stationary_City"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Stationary_State"])) { objerty.Stationary_State = Convert.ToString(reader["Stationary_State"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Stationary_Zip"])) { objerty.Stationary_Zip = Convert.ToString(reader["Stationary_Zip"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Stationary_Category"])) { objerty.Stationary_Category = Convert.ToString(reader["Stationary_Category"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Stationary_Title"])) { objerty.Stationary_Title = Convert.ToString(reader["Stationary_Title"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Stationary_Deed"])) { objerty.Stationary_Deed = Convert.ToString(reader["Stationary_Deed"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Stationary_Safety"])) { objerty.Stationary_Safety = Convert.ToString(reader["Stationary_Safety"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Stationary_Security"])) { objerty.Stationary_Security = Convert.ToString(reader["Stationary_Security"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Stationary_Flood_Zone"])) { objerty.Stationary_Flood_Zone = Convert.ToString(reader["Stationary_Flood_Zone"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Stationary_Foreclosure"])) { objerty.Stationary_Foreclosure = Convert.ToString(reader["Stationary_Foreclosure"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Foreclosed"])) { objerty.Foreclosed = Convert.ToString(reader["Foreclosed"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Contact_Name"])) { objerty.Contact_Name = Convert.ToString(reader["Contact_Name"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Contact_Phone"])) { objerty.Contact_Phone = Convert.ToString(reader["Contact_Phone"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Contact_Facsimile"])) { objerty.Contact_Facsimile = Convert.ToString(reader["Contact_Facsimile"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Emergency_Police"])) { objerty.Emergency_Police = Convert.ToString(reader["Emergency_Police"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Emergency_Fire"])) { objerty.Emergency_Fire = Convert.ToString(reader["Emergency_Fire"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Emergency_Sheriff"])) { objerty.Emergency_Sheriff = Convert.ToString(reader["Emergency_Sheriff"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Emergency_State_Police"])) { objerty.Emergency_State_Police = Convert.ToString(reader["Emergency_State_Police"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Emergency_Ambulance"])) { objerty.Emergency_Ambulance = Convert.ToString(reader["Emergency_Ambulance"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Emergency_FBI"])) { objerty.Emergency_FBI = Convert.ToString(reader["Emergency_FBI"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Emergency_Secret_Service"])) { objerty.Emergency_Secret_Service = Convert.ToString(reader["Emergency_Secret_Service"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Phone_Company_Contact"])) { objerty.Phone_Company_Contact = Convert.ToString(reader["Phone_Company_Contact"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Phone_Company_Telephone"])) { objerty.Phone_Company_Telephone = Convert.ToString(reader["Phone_Company_Telephone"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Power_Company_Contact"])) { objerty.Power_Company_Contact = Convert.ToString(reader["Power_Company_Contact"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Power_Company_Telephone"])) { objerty.Power_Company_Telephone = Convert.ToString(reader["Power_Company_Telephone"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Water_Utility_Contact"])) { objerty.Water_Utility_Contact = Convert.ToString(reader["Water_Utility_Contact"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Water_Utility_Telephone"])) { objerty.Water_Utility_Telephone = Convert.ToString(reader["Water_Utility_Telephone"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Gas_Utility_Contact"])) { objerty.Gas_Utility_Contact = Convert.ToString(reader["Gas_Utility_Contact"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Gas_Utility_Telephone"])) { objerty.Gas_Utility_Telephone = Convert.ToString(reader["Gas_Utility_Telephone"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Cleaning_Company_Contact"])) { objerty.Cleaning_Company_Contact = Convert.ToString(reader["Cleaning_Company_Contact"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Cleaning_Company_Telephone"])) { objerty.Cleaning_Company_Telephone = Convert.ToString(reader["Cleaning_Company_Telephone"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Cleaning_Company_Contract"])) { objerty.Cleaning_Company_Contract = Convert.ToString(reader["Cleaning_Company_Contract"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Cleaning_Company_Date"])) { objerty.Cleaning_Company_Date = Convert.ToDateTime(reader["Cleaning_Company_Date"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Courier_Company_Contact"])) { objerty.Courier_Company_Contact = Convert.ToString(reader["Courier_Company_Contact"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Courier_Company_Telephone"])) { objerty.Courier_Company_Telephone = Convert.ToString(reader["Courier_Company_Telephone"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Courier_Company_Contract"])) { objerty.Courier_Company_Contract = Convert.ToString(reader["Courier_Company_Contract"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Courier_Company_Date"])) { objerty.Courier_Company_Date = Convert.ToDateTime(reader["Courier_Company_Date"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["After_Hours_Contact"])) { objerty.After_Hours_Contact = Convert.ToString(reader["After_Hours_Contact"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["After_Hours_Phone"])) { objerty.After_Hours_Phone = Convert.ToString(reader["After_Hours_Phone"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["After_Hours_Cell"])) { objerty.After_Hours_Cell = Convert.ToString(reader["After_Hours_Cell"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["After_Hours_Pager"])) { objerty.After_Hours_Pager = Convert.ToString(reader["After_Hours_Pager"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Contact_For_1"])) { objerty.Contact_For_1 = Convert.ToString(reader["Contact_For_1"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Special_Contact_1"])) { objerty.Special_Contact_1 = Convert.ToString(reader["Special_Contact_1"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Special_Phone_1"])) { objerty.Special_Phone_1 = Convert.ToString(reader["Special_Phone_1"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Special_Cell_1"])) { objerty.Special_Cell_1 = Convert.ToString(reader["Special_Cell_1"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Special_Pager_1"])) { objerty.Special_Pager_1 = Convert.ToString(reader["Special_Pager_1"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Contact_For_2"])) { objerty.Contact_For_2 = Convert.ToString(reader["Contact_For_2"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Special_Contact_2"])) { objerty.Special_Contact_2 = Convert.ToString(reader["Special_Contact_2"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Special_Phone_2"])) { objerty.Special_Phone_2 = Convert.ToString(reader["Special_Phone_2"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Special_Cell_2"])) { objerty.Special_Cell_2 = Convert.ToString(reader["Special_Cell_2"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Special_Pager_2"])) { objerty.Special_Pager_2 = Convert.ToString(reader["Special_Pager_2"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Contact_For_3"])) { objerty.Contact_For_3 = Convert.ToString(reader["Contact_For_3"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Special_Contact_3"])) { objerty.Special_Contact_3 = Convert.ToString(reader["Special_Contact_3"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Special_Phone_3"])) { objerty.Special_Phone_3 = Convert.ToString(reader["Special_Phone_3"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Special_Cell_3"])) { objerty.Special_Cell_3 = Convert.ToString(reader["Special_Cell_3"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Special_Pager_3"])) { objerty.Special_Pager_3 = Convert.ToString(reader["Special_Pager_3"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Open_Time"])) { objerty.Open_Time = Convert.ToString(reader["Open_Time"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Close_Time"])) { objerty.Close_Time = Convert.ToString(reader["Close_Time"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Number_Of_Employees"])) { objerty.Number_Of_Employees = Convert.ToDecimal(reader["Number_Of_Employees"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["ATM"])) { objerty.ATM = Convert.ToString(reader["ATM"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["ATM_Location"])) { objerty.ATM_Location = Convert.ToString(reader["ATM_Location"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Updated_By"])) { objerty.Updated_By = Convert.ToString(reader["Updated_By"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Update_Date"])) { objerty.Update_Date = Convert.ToDateTime(reader["Update_Date"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FK_Entity"])) { objerty.FK_Entity = Convert.ToDecimal(reader["FK_Entity"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Property_Name"])) { objerty.Property_Name = Convert.ToString(reader["Property_Name"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FK_County"])) { objerty.FK_County_property = Convert.ToString(reader["FK_County"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["County_Tier_1"])) { objerty.County_Tier_1 = Convert.ToString(reader["County_Tier_1"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["County_Tri_County"])) { objerty.County_Tri_County = Convert.ToString(reader["County_Tri_County"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FK_Land_Status"])) { objerty.FK_Land_Status = Convert.ToDecimal(reader["FK_Land_Status"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Acreage"])) { objerty.Acreage = Convert.ToDecimal(reader["Acreage"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Road_Frontage"])) { objerty.Road_Frontage = Convert.ToDecimal(reader["Road_Frontage"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Road_Frontage_Units"])) { objerty.Road_Frontage_Units = Convert.ToString(reader["Road_Frontage_Units"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Occupancy"])) { objerty.Occupancy = Convert.ToString(reader["Occupancy"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Flood_Zone"])) { objerty.Flood_Zone = Convert.ToString(reader["Flood_Zone"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Number_Of_Employees1"])) { objerty.Number_Of_Employees1 = Convert.ToDecimal(reader["Number_Of_Employees1"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Building"])) { objerty.Building = Convert.ToDecimal(reader["Building"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Signs"])) { objerty.Signs = Convert.ToDecimal(reader["Signs"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Contents"])) { objerty.Contents = Convert.ToDecimal(reader["Contents"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Computers"])) { objerty.Computers = Convert.ToDecimal(reader["Computers"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["ATMs"])) { objerty.ATMs = Convert.ToDecimal(reader["ATMs"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Lease_Improvements"])) { objerty.Lease_Improvements = Convert.ToDecimal(reader["Lease_Improvements"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Total"])) { objerty.Total = Convert.ToDecimal(reader["Total"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Gross_Sq_Feet"])) { objerty.Gross_Sq_Feet = Convert.ToDecimal(reader["Gross_Sq_Feet"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Public_Acc_Sq_Feet"])) { objerty.Public_Acc_Sq_Feet = Convert.ToDecimal(reader["Public_Acc_Sq_Feet"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Stories_Up"])) { objerty.Stories_Up = Convert.ToDecimal(reader["Stories_Up"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Stories_Down"])) { objerty.Stories_Down = Convert.ToDecimal(reader["Stories_Down"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Construction_Cost"])) { objerty.Construction_Cost = Convert.ToDecimal(reader["Construction_Cost"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Construction_Type"])) { objerty.Construction_Type = Convert.ToString(reader["Construction_Type"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Year_Built"])) { objerty.Year_Built = Convert.ToDecimal(reader["Year_Built"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Purchase_Date"])) { objerty.Purchase_Date = Convert.ToDateTime(reader["Purchase_Date"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Purchase_Price"])) { objerty.Purchase_Price = Convert.ToDecimal(reader["Purchase_Price"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Sprinkler"])) { objerty.Sprinkler = Convert.ToDecimal(reader["Sprinkler"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Fire_Alarms"])) { objerty.Fire_Alarms = Convert.ToDecimal(reader["Fire_Alarms"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Security_Alarm"])) { objerty.Security_Alarm = Convert.ToString(reader["Security_Alarm"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Security_Console"])) { objerty.Security_Console = Convert.ToDecimal(reader["Security_Console"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Ownership"])) { objerty.Ownership = Convert.ToString(reader["Ownership"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Number_Vaults"])) { objerty.Number_Vaults = Convert.ToDecimal(reader["Number_Vaults"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Number_DU_Windows"])) { objerty.Number_DU_Windows = Convert.ToDecimal(reader["Number_DU_Windows"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Number_SD_Boxes"])) { objerty.Number_SD_Boxes = Convert.ToDecimal(reader["Number_SD_Boxes"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Number_WU_ATMs"])) { objerty.Number_WU_ATMs = Convert.ToDecimal(reader["Number_WU_ATMs"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Number_DU_ATMs"])) { objerty.Number_DU_ATMs = Convert.ToDecimal(reader["Number_DU_ATMs"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Regions_Lessor"])) { objerty.Regions_Lessor = Convert.ToDecimal(reader["Regions_Lessor"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Net_Leasable_Sq_Ft"])) { objerty.Net_Leasable_Sq_Ft = Convert.ToDecimal(reader["Net_Leasable_Sq_Ft"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Current_Monthly_Rent"])) { objerty.Current_Monthly_Rent = Convert.ToDecimal(reader["Current_Monthly_Rent"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Ocupancy_Rent"])) { objerty.Ocupancy_Rent = Convert.ToString(reader["Ocupancy_Rent"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Fine_Arts"])) { objerty.Fine_Arts = Convert.ToDecimal(reader["Fine_Arts"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Rental_Income"])) { objerty.Rental_Income = Convert.ToDecimal(reader["Rental_Income"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["ATM_Vendor_Contact"])) { objerty.ATM_Vendor_Contact = Convert.ToString(reader["ATM_Vendor_Contact"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["ATM_Telephone"])) { objerty.ATM_Telephone = Convert.ToString(reader["ATM_Telephone"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["ATM_Contract"])) { objerty.ATM_Contract = Convert.ToString(reader["ATM_Contract"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["ATM_Date"])) { objerty.ATM_Date = Convert.ToDateTime(reader["ATM_Date"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Monday_Open"])) { objerty.Monday_Open = Convert.ToString(reader["Monday_Open"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Monday_Close"])) { objerty.Monday_Close = Convert.ToString(reader["Monday_Close"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Tuesday_Open"])) { objerty.Tuesday_Open = Convert.ToString(reader["Tuesday_Open"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Tuesday_Close"])) { objerty.Tuesday_Close = Convert.ToString(reader["Tuesday_Close"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Wednesday_Open"])) { objerty.Wednesday_Open = Convert.ToString(reader["Wednesday_Open"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Wednesday_Close"])) { objerty.Wednesday_Close = Convert.ToString(reader["Wednesday_Close"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Thursday_Open"])) { objerty.Thursday_Open = Convert.ToString(reader["Thursday_Open"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Thursday_Close"])) { objerty.Thursday_Close = Convert.ToString(reader["Thursday_Close"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Friday_Open"])) { objerty.Friday_Open = Convert.ToString(reader["Friday_Open"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Friday_Close"])) { objerty.Friday_Close = Convert.ToString(reader["Friday_Close"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Saturday_Open"])) { objerty.Saturday_Open = Convert.ToString(reader["Saturday_Open"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Saturday_Close"])) { objerty.Saturday_Close = Convert.ToString(reader["Saturday_Close"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Sunday_Open"])) { objerty.Sunday_Open = Convert.ToString(reader["Sunday_Open"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Sunday_Close"])) { objerty.Sunday_Close = Convert.ToString(reader["Sunday_Close"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Cash_Chests"])) { objerty.Cash_Chests = Convert.ToDecimal(reader["Cash_Chests"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Tenant_Type"])) { objerty.Tenant_Type = Convert.ToString(reader["Tenant_Type"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Lessee"])) { objerty.Lessee = Convert.ToDecimal(reader["Lessee"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Lessee_Rent_Sq_Ft"])) { objerty.Lessee_Rent_Sq_Ft = Convert.ToDecimal(reader["Lessee_Rent_Sq_Ft"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["SA_SECURITY_CONSOLE"])) { objerty.SA_SECURITY_CONSOLE = Convert.ToString(reader["SA_SECURITY_CONSOLE"], CultureInfo.InvariantCulture); }
            return objerty;
        }

        public override List<RIMS_Base.CLiabilityClaim> GetLiabilityEmp_Data_ByID(System.Int32 pK_Liability_Claim, System.Int32 pK_Employee_ID, System.Int32 Criatearea)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("LiabilityEmployee_Data_ByID");
                dbHelper.AddInParameter(cmd, "@PK_Liability_Claim", DbType.Int32, pK_Liability_Claim);
                dbHelper.AddInParameter(cmd, "@PK_Employee_ID", DbType.Int32, pK_Employee_ID);
                dbHelper.AddInParameter(cmd, "@Criatearea", DbType.Int32, Criatearea);
                List<RIMS_Base.CLiabilityClaim> result = new List<RIMS_Base.CLiabilityClaim>();

                IDataReader reader = dbHelper.ExecuteReader(cmd);
                CLiabilityClaim Obj_Emp = new CLiabilityClaim();
                if (reader.Read())
                {
                    Obj_Emp = MapFromEmployee(reader);
                    result.Add(Obj_Emp);
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

        protected RIMS_Base.Dal.CLiabilityClaim MapFromEmployee(IDataReader reader)
        {
            RIMS_Base.Dal.CLiabilityClaim Obj_Empmap = new RIMS_Base.Dal.CLiabilityClaim();
            if (!Convert.IsDBNull(reader["First_Name"])) { Obj_Empmap.First_Name = Convert.ToString(reader["First_Name"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Last_Name"])) { Obj_Empmap.Last_Name = Convert.ToString(reader["Last_Name"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Middle_Name"])) { Obj_Empmap.Middle_Name = Convert.ToString(reader["Middle_Name"], CultureInfo.InvariantCulture); }
            return Obj_Empmap;
        }




        public override List<RIMS_Base.CLiabilityClaim> GetLiability_CostCenterByID(System.Int32 pK_Liability_Claim, System.String cost_Center)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Liability_CostCenter_Data_ByID");
                dbHelper.AddInParameter(cmd, "@PK_Liability_Claim", DbType.Int32, pK_Liability_Claim);
                dbHelper.AddInParameter(cmd, "@Cost_Center", DbType.String, cost_Center);
                // dbHelper.AddInParameter(cmd, "@Criatearea", DbType.Int32, Criatearea);

                List<RIMS_Base.CLiabilityClaim> result = new List<RIMS_Base.CLiabilityClaim>();

                IDataReader reader = dbHelper.ExecuteReader(cmd);
                CLiabilityClaim Obj_Emp = new CLiabilityClaim();
                if (reader.Read())
                {
                    Obj_Emp = MapFromCostCenter(reader);
                    result.Add(Obj_Emp);
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

        protected RIMS_Base.Dal.CLiabilityClaim MapFromCostCenter(IDataReader reader)
        {
            RIMS_Base.Dal.CLiabilityClaim Obj_Empmap = new RIMS_Base.Dal.CLiabilityClaim();
            // if (!Convert.IsDBNull(reader["Cost_Center"])) { Obj_Empmap.Cost_Center = Convert.ToString(reader["Cost_Center"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Division_Name"])) { Obj_Empmap.Division_Name = Convert.ToString(reader["Division_Name"], CultureInfo.InvariantCulture); }
            //if (!Convert.IsDBNull(reader["Middle_Name"])) { Obj_Empmap.Middle_Name = Convert.ToString(reader["Middle_Name"], CultureInfo.InvariantCulture); }
            return Obj_Empmap;
        }



        public override List<RIMS_Base.CLiabilityClaim> GetLiability_CliamantByID(System.Int32 pK_Liability_Claim, System.Decimal pK_Claimant_Id)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("LiabilityCliamant_Data_ByID");
                dbHelper.AddInParameter(cmd, "@PK_Liability_Claim", DbType.Int32, pK_Liability_Claim);
                dbHelper.AddInParameter(cmd, "@PK_Claimant_Id", DbType.Int32, pK_Claimant_Id);
                //  dbHelper.AddInParameter(cmd, "@Criatearea", DbType.Int32, Criatearea);
                List<RIMS_Base.CLiabilityClaim> result = new List<RIMS_Base.CLiabilityClaim>();

                IDataReader reader = dbHelper.ExecuteReader(cmd);
                CLiabilityClaim Obj_Emp = new CLiabilityClaim();
                if (reader.Read())
                {
                    Obj_Emp = MapFromCliamant(reader);
                    result.Add(Obj_Emp);
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
        public override DataSet GetLiabilityLabel()
        {
            DbCommand cmd = null;
            DataSet dstDataset = null;
            Database dbHelper = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Get_Liability_Label");
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
        protected RIMS_Base.Dal.CLiabilityClaim MapFromCliamant(IDataReader reader)
        {
            RIMS_Base.Dal.CLiabilityClaim Obj_Empmap = new RIMS_Base.Dal.CLiabilityClaim();
            if (!Convert.IsDBNull(reader["First_Name"])) { Obj_Empmap.Cliamant_First_Name = Convert.ToString(reader["First_Name"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Last_Name"])) { Obj_Empmap.Cliamant_Last_Name = Convert.ToString(reader["Last_Name"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Middle_Name"])) { Obj_Empmap.Cliamant_Middle_Name = Convert.ToString(reader["Middle_Name"], CultureInfo.InvariantCulture); }
            return Obj_Empmap;
        }







    }


}

