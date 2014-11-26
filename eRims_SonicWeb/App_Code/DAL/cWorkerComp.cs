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


    public class cWorkerComp : RIMS_Base.cWorkerComp
    {

        public override int InsertUpdate_WorkerComp(RIMS_Base.cWorkerComp Obj_WorkComp)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            int nRetVal = -1;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("InsertUpdate_WorkerComp");
                dbHelper.AddParameter(cmd, "@PK_Workers_Comp", DbType.Int32, ParameterDirection.InputOutput, "PK_Workers_Comp", DataRowVersion.Current, Obj_WorkComp.PK_Workers_Comp);
                dbHelper.AddInParameter(cmd, "@Claim_Number", DbType.String, Obj_WorkComp.Claim_Number);
                dbHelper.AddInParameter(cmd, "@Employee", DbType.String, Obj_WorkComp.Employee);
                dbHelper.AddInParameter(cmd, "@FK_Employee_Claimant", DbType.Decimal, Obj_WorkComp.FK_Employee_Claimant);
                dbHelper.AddInParameter(cmd, "@FK_State_Coverage", DbType.Decimal, Obj_WorkComp.FK_State_Coverage);
                dbHelper.AddInParameter(cmd, "@FK_State_Accident", DbType.Decimal, Obj_WorkComp.FK_State_Accident);
                dbHelper.AddInParameter(cmd, "@Incident_Date", DbType.DateTime, Obj_WorkComp.Incident_Date);
                dbHelper.AddInParameter(cmd, "@EE_RTW", DbType.String, Obj_WorkComp.EE_RTW);
                dbHelper.AddInParameter(cmd, "@EE_RTW_Date", DbType.DateTime, Obj_WorkComp.EE_RTW_Date);
                dbHelper.AddInParameter(cmd, "@RTW_Wage", DbType.String, Obj_WorkComp.RTW_Wage);
                dbHelper.AddInParameter(cmd, "@Restricted_Duty", DbType.String, Obj_WorkComp.Restricted_Duty);
                dbHelper.AddInParameter(cmd, "@Restrict_Description", DbType.String, Obj_WorkComp.Restrict_Description);
                dbHelper.AddInParameter(cmd, "@Restriction_Begin_Date", DbType.DateTime, Obj_WorkComp.Restriction_Begin_Date);
                dbHelper.AddInParameter(cmd, "@Restriction_End_Date", DbType.DateTime, Obj_WorkComp.Restriction_End_Date);
                dbHelper.AddInParameter(cmd, "@Est_Disability_Length_Weeks", DbType.Decimal, Obj_WorkComp.Est_Disability_Length_Weeks);
                dbHelper.AddInParameter(cmd, "@Est_Disability_Length_Days", DbType.Decimal, Obj_WorkComp.Est_Disability_Length_Days);
                dbHelper.AddInParameter(cmd, "@Act_Disability_Length_Weeks", DbType.Decimal, Obj_WorkComp.Act_Disability_Length_Weeks);
                dbHelper.AddInParameter(cmd, "@Act_Disability_Length_Days", DbType.Decimal, Obj_WorkComp.Act_Disability_Length_Days);
                dbHelper.AddInParameter(cmd, "@MMI_Date", DbType.DateTime, Obj_WorkComp.MMI_Date);
                dbHelper.AddInParameter(cmd, "@PPD_Rating", DbType.String, Obj_WorkComp.PPD_Rating);
                dbHelper.AddInParameter(cmd, "@AWW_Dollars", DbType.Decimal, Obj_WorkComp.AWW_Dollars);
                dbHelper.AddInParameter(cmd, "@AWW_Method", DbType.String, Obj_WorkComp.AWW_Method);
                dbHelper.AddInParameter(cmd, "@TTD_Dollars", DbType.Decimal, Obj_WorkComp.TTD_Dollars);
                dbHelper.AddInParameter(cmd, "@Settlement_Method", DbType.String, Obj_WorkComp.Settlement_Method);
                dbHelper.AddInParameter(cmd, "@Claim_Description", DbType.String, Obj_WorkComp.Claim_Description);
                dbHelper.AddInParameter(cmd, "@Nature", DbType.Decimal, Obj_WorkComp.Nature);
                dbHelper.AddInParameter(cmd, "@Estimate", DbType.Decimal, Obj_WorkComp.Estimate);
                dbHelper.AddInParameter(cmd, "@Actual", DbType.Decimal, Obj_WorkComp.Actual);
                dbHelper.AddInParameter(cmd, "@FK_Claim_Cause", DbType.Decimal, Obj_WorkComp.FK_Claim_Cause);
                dbHelper.AddInParameter(cmd, "@FK_Body_Parts", DbType.Decimal, Obj_WorkComp.FK_Body_Parts);
                dbHelper.AddInParameter(cmd, "@FK_Injury", DbType.Decimal, Obj_WorkComp.FK_Injury);
                dbHelper.AddInParameter(cmd, "@FK_NCCI_Code", DbType.Decimal, Obj_WorkComp.FK_NCCI_Code);
                dbHelper.AddInParameter(cmd, "@Vocation_Rehab", DbType.String, Obj_WorkComp.Vocation_Rehab);
                dbHelper.AddInParameter(cmd, "@FK_WC_Major_Claim_Type", DbType.Decimal, Obj_WorkComp.FK_WC_Major_Claim_Type);
                dbHelper.AddInParameter(cmd, "@FK_WC_Minor_Claim_Type", DbType.Decimal, Obj_WorkComp.FK_WC_Minor_Claim_Type);
                dbHelper.AddInParameter(cmd, "@Convertible", DbType.String, Obj_WorkComp.Convertible);
                dbHelper.AddInParameter(cmd, "@FK_Fraud_Claim", DbType.Decimal, Obj_WorkComp.FK_Fraud_Claim);
                dbHelper.AddInParameter(cmd, "@Claim_Open_Date", DbType.DateTime, Obj_WorkComp.Claim_Open_Date);
                dbHelper.AddInParameter(cmd, "@Claim_Close_Date", DbType.DateTime, Obj_WorkComp.Claim_Close_Date);
                dbHelper.AddInParameter(cmd, "@Claim_Reopen_Date", DbType.DateTime, Obj_WorkComp.Claim_Reopen_Date);
                dbHelper.AddInParameter(cmd, "@Surgery_Required", DbType.String, Obj_WorkComp.Surgery_Required);
                dbHelper.AddInParameter(cmd, "@Indemnity_Weeks", DbType.Decimal, Obj_WorkComp.Indemnity_Weeks);
                dbHelper.AddInParameter(cmd, "@FK_State_Jurisdiction", DbType.Decimal, Obj_WorkComp.FK_State_Jurisdiction);
                dbHelper.AddInParameter(cmd, "@FK_Employee", DbType.Decimal, Obj_WorkComp.FK_Employee);
                dbHelper.AddInParameter(cmd, "@FK_Method_Pre_Injury_Wage", DbType.Decimal, Obj_WorkComp.FK_Method_Pre_Injury_Wage);
                dbHelper.AddInParameter(cmd, "@FK_Method_Of_Settlement", DbType.Decimal, Obj_WorkComp.FK_Method_Of_Settlement);
                dbHelper.AddInParameter(cmd, "@Pre_Injury_Weekly_Wage", DbType.Decimal, Obj_WorkComp.Pre_Injury_Weekly_Wage);
                dbHelper.AddInParameter(cmd, "@Post_Injury_Weekly_Wage", DbType.Decimal, Obj_WorkComp.Post_Injury_Weekly_Wage);
                dbHelper.AddInParameter(cmd, "@Present_Valuation_Future_Indemnity", DbType.Decimal, Obj_WorkComp.Present_Valuation_Future_Indemnity);
                dbHelper.AddInParameter(cmd, "@FK_Injury_1", DbType.Decimal, Obj_WorkComp.FK_Injury_1);
                dbHelper.AddInParameter(cmd, "@Benefits_Paid_To_Date_1", DbType.Decimal, Obj_WorkComp.Benefits_Paid_To_Date_1);
                dbHelper.AddInParameter(cmd, "@Weekly_Benefit_1", DbType.Decimal, Obj_WorkComp.Weekly_Benefit_1);
                dbHelper.AddInParameter(cmd, "@FK_Injury_2", DbType.Decimal, Obj_WorkComp.FK_Injury_2);
                dbHelper.AddInParameter(cmd, "@Benefits_Paid_To_Date_2", DbType.Decimal, Obj_WorkComp.Benefits_Paid_To_Date_2);
                dbHelper.AddInParameter(cmd, "@Weekly_Benefit_2", DbType.Decimal, Obj_WorkComp.Weekly_Benefit_2);
                dbHelper.AddInParameter(cmd, "@FK_Injury_3", DbType.Decimal, Obj_WorkComp.FK_Injury_3);
                dbHelper.AddInParameter(cmd, "@Benefits_Paid_To_Date_3", DbType.Decimal, Obj_WorkComp.Benefits_Paid_To_Date_3);
                dbHelper.AddInParameter(cmd, "@Weekly_Benefit_3", DbType.Decimal, Obj_WorkComp.Weekly_Benefit_3);
                dbHelper.AddInParameter(cmd, "@FK_Injury_4", DbType.Decimal, Obj_WorkComp.FK_Injury_4);
                dbHelper.AddInParameter(cmd, "@Benefits_Paid_To_Date_4", DbType.Decimal, Obj_WorkComp.Benefits_Paid_To_Date_4);
                dbHelper.AddInParameter(cmd, "@Weekly_Benefit_4", DbType.Decimal, Obj_WorkComp.Weekly_Benefit_4);
                dbHelper.AddInParameter(cmd, "@FK_Injury_5", DbType.Decimal, Obj_WorkComp.FK_Injury_5);
                dbHelper.AddInParameter(cmd, "@Benefits_Paid_To_Date_5", DbType.Decimal, Obj_WorkComp.Benefits_Paid_To_Date_5);
                dbHelper.AddInParameter(cmd, "@Weekly_Benefit_5", DbType.Decimal, Obj_WorkComp.Weekly_Benefit_5);
                dbHelper.AddInParameter(cmd, "@FK_Beneficiary_Code_1", DbType.Decimal, Obj_WorkComp.FK_Beneficiary_Code_1);
                dbHelper.AddInParameter(cmd, "@Beneficiary_DOB_1", DbType.DateTime, Obj_WorkComp.Beneficiary_DOB_1);
                dbHelper.AddInParameter(cmd, "@FK_Beneficiary_Code_2", DbType.Decimal, Obj_WorkComp.FK_Beneficiary_Code_2);
                dbHelper.AddInParameter(cmd, "@Beneficiary_DOB_2", DbType.DateTime, Obj_WorkComp.Beneficiary_DOB_2);
                dbHelper.AddInParameter(cmd, "@FK_Beneficiary_Code_3", DbType.Decimal, Obj_WorkComp.FK_Beneficiary_Code_3);
                dbHelper.AddInParameter(cmd, "@Beneficiary_DOB_3", DbType.DateTime, Obj_WorkComp.Beneficiary_DOB_3);
                dbHelper.AddInParameter(cmd, "@FK_Beneficiary_Code_4", DbType.Decimal, Obj_WorkComp.FK_Beneficiary_Code_4);
                dbHelper.AddInParameter(cmd, "@Beneficiary_DOB_4", DbType.DateTime, Obj_WorkComp.Beneficiary_DOB_4);
                dbHelper.AddInParameter(cmd, "@FK_Beneficiary_Code_5", DbType.Decimal, Obj_WorkComp.FK_Beneficiary_Code_5);
                dbHelper.AddInParameter(cmd, "@Beneficiary_DOB_5", DbType.DateTime, Obj_WorkComp.Beneficiary_DOB_5);
                dbHelper.AddInParameter(cmd, "@Suit_Date", DbType.DateTime, Obj_WorkComp.Suit_Date);
                dbHelper.AddInParameter(cmd, "@Attorney_Disclosure_Date", DbType.DateTime, Obj_WorkComp.Attorney_Disclosure_Date);
                dbHelper.AddInParameter(cmd, "@Client_Attorney_Name", DbType.String, Obj_WorkComp.Client_Attorney_Name);
                dbHelper.AddInParameter(cmd, "@Client_Attorney_Address_1", DbType.String, Obj_WorkComp.Client_Attorney_Address_1);
                dbHelper.AddInParameter(cmd, "@Client_Attorney_Address_2", DbType.String, Obj_WorkComp.Client_Attorney_Address_2);
                dbHelper.AddInParameter(cmd, "@Client_Attorney_City", DbType.String, Obj_WorkComp.Client_Attorney_City);
                dbHelper.AddInParameter(cmd, "@FK_State_Client_Attorney", DbType.Decimal, Obj_WorkComp.FK_State_Client_Attorney);
                dbHelper.AddInParameter(cmd, "@Client_Attorney_Zip_Code", DbType.String, Obj_WorkComp.Client_Attorney_Zip_Code);
                dbHelper.AddInParameter(cmd, "@Client_Attorney_Phone", DbType.String, Obj_WorkComp.Client_Attorney_Phone);
                dbHelper.AddInParameter(cmd, "@Client_Attorney_Fax", DbType.String, Obj_WorkComp.Client_Attorney_Fax);
                dbHelper.AddInParameter(cmd, "@Defense_Attorney_Name", DbType.String, Obj_WorkComp.Defense_Attorney_Name);
                dbHelper.AddInParameter(cmd, "@Defense_Attorney_Address_1", DbType.String, Obj_WorkComp.Defense_Attorney_Address_1);
                dbHelper.AddInParameter(cmd, "@Defense_Attorney_Address_2", DbType.String, Obj_WorkComp.Defense_Attorney_Address_2);
                dbHelper.AddInParameter(cmd, "@Defense_Attorney_City", DbType.String, Obj_WorkComp.Defense_Attorney_City);
                dbHelper.AddInParameter(cmd, "@FK_State_Defense_Attorney", DbType.Decimal, Obj_WorkComp.FK_State_Defense_Attorney);
                dbHelper.AddInParameter(cmd, "@Defense_Attorney_Zip_Code", DbType.String, Obj_WorkComp.Defense_Attorney_Zip_Code);
                dbHelper.AddInParameter(cmd, "@Defense_Attorney_Phone", DbType.String, Obj_WorkComp.Defense_Attorney_Phone);
                dbHelper.AddInParameter(cmd, "@Defense_Attorney_Fax", DbType.String, Obj_WorkComp.Defense_Attorney_Fax);
                dbHelper.AddInParameter(cmd, "@Medical_Provider", DbType.String, Obj_WorkComp.Medical_Provider);
                dbHelper.AddInParameter(cmd, "@Medical_Provider_Phone", DbType.String, Obj_WorkComp.Medical_Provider_Phone);
                dbHelper.AddInParameter(cmd, "@Hospital", DbType.String, Obj_WorkComp.Hospital);
                dbHelper.AddInParameter(cmd, "@MCO_Type", DbType.String, Obj_WorkComp.MCO_Type);
                dbHelper.AddInParameter(cmd, "@Death_Date", DbType.DateTime, Obj_WorkComp.Death_Date);
                dbHelper.AddInParameter(cmd, "@Delete_Reason", DbType.String, Obj_WorkComp.Delete_Reason);
                dbHelper.AddInParameter(cmd, "@Date_Max_Med_Imp", DbType.DateTime, Obj_WorkComp.Date_Max_Med_Imp);
                dbHelper.AddInParameter(cmd, "@FK_Managed_Care_Org_Type", DbType.Decimal, Obj_WorkComp.FK_Managed_Care_Org_Type);
                dbHelper.AddInParameter(cmd, "@Percentage_Impairment", DbType.Decimal, Obj_WorkComp.Percentage_Impairment);
                dbHelper.AddInParameter(cmd, "@Percentage_Disability", DbType.Decimal, Obj_WorkComp.Percentage_Disability);
                dbHelper.AddInParameter(cmd, "@FK_Employee_Reported", DbType.Decimal, Obj_WorkComp.FK_Employee_Reported);
                dbHelper.AddInParameter(cmd, "@Incident_Time", DbType.String, Obj_WorkComp.Incident_Time);
                dbHelper.AddInParameter(cmd, "@Within_24_Hours", DbType.String, Obj_WorkComp.Within_24_Hours);
                dbHelper.AddInParameter(cmd, "@Date_Reported", DbType.DateTime, Obj_WorkComp.Date_Reported);
                dbHelper.AddInParameter(cmd, "@Date_Reported_Employer", DbType.DateTime, Obj_WorkComp.Date_Reported_Employer);
                dbHelper.AddInParameter(cmd, "@Time_Reported", DbType.String, Obj_WorkComp.Time_Reported);
                dbHelper.AddInParameter(cmd, "@Location", DbType.String, Obj_WorkComp.Location);
                dbHelper.AddInParameter(cmd, "@Location_Address_1", DbType.String, Obj_WorkComp.Location_Address_1);
                dbHelper.AddInParameter(cmd, "@Location_Address_2", DbType.String, Obj_WorkComp.Location_Address_2);
                dbHelper.AddInParameter(cmd, "@Location_City", DbType.String, Obj_WorkComp.Location_City);
                dbHelper.AddInParameter(cmd, "@FK_State_Location", DbType.Decimal, Obj_WorkComp.FK_State_Location);
                dbHelper.AddInParameter(cmd, "@Location_Zip", DbType.String, Obj_WorkComp.Location_Zip);
                dbHelper.AddInParameter(cmd, "@Location_County", DbType.String, Obj_WorkComp.Location_County);
                dbHelper.AddInParameter(cmd, "@Location_Country", DbType.String, Obj_WorkComp.Location_Country);
                dbHelper.AddInParameter(cmd, "@Location_Phone", DbType.String, Obj_WorkComp.Location_Phone);
                dbHelper.AddInParameter(cmd, "@Location_Fax", DbType.String, Obj_WorkComp.Location_Fax);
                dbHelper.AddInParameter(cmd, "@Date_Return", DbType.DateTime, Obj_WorkComp.Date_Return);
                dbHelper.AddInParameter(cmd, "@Employer_Contact", DbType.String, Obj_WorkComp.Employer_Contact);
                dbHelper.AddInParameter(cmd, "@Employer_Contact_Date", DbType.DateTime, Obj_WorkComp.Employer_Contact_Date);
                dbHelper.AddInParameter(cmd, "@Claimant_Contact", DbType.String, Obj_WorkComp.Claimant_Contact);
                dbHelper.AddInParameter(cmd, "@Claimant_Contact_Date", DbType.DateTime, Obj_WorkComp.Claimant_Contact_Date);
                dbHelper.AddInParameter(cmd, "@Statement_Claimant", DbType.String, Obj_WorkComp.Statement_Claimant);
                dbHelper.AddInParameter(cmd, "@Statement_Claimant_Date", DbType.DateTime, Obj_WorkComp.Statement_Claimant_Date);
                dbHelper.AddInParameter(cmd, "@Witness_1", DbType.String, Obj_WorkComp.Witness_1);
                dbHelper.AddInParameter(cmd, "@Statement_Witness_1", DbType.String, Obj_WorkComp.Statement_Witness_1);
                dbHelper.AddInParameter(cmd, "@Statement_Witness_1_Date", DbType.DateTime, Obj_WorkComp.Statement_Witness_1_Date);
                dbHelper.AddInParameter(cmd, "@Witness_2", DbType.String, Obj_WorkComp.Witness_2);
                dbHelper.AddInParameter(cmd, "@Statement_Witness_2", DbType.String, Obj_WorkComp.Statement_Witness_2);
                dbHelper.AddInParameter(cmd, "@Statement_Witness_2_Date", DbType.DateTime, Obj_WorkComp.Statement_Witness_2_Date);
                dbHelper.AddInParameter(cmd, "@Witness_3", DbType.String, Obj_WorkComp.Witness_3);
                dbHelper.AddInParameter(cmd, "@Statement_Witness_3", DbType.String, Obj_WorkComp.Statement_Witness_3);
                dbHelper.AddInParameter(cmd, "@Statement_Witness_3_Date", DbType.DateTime, Obj_WorkComp.Statement_Witness_3_Date);
                dbHelper.AddInParameter(cmd, "@Updated_By", DbType.String, Obj_WorkComp.Updated_By);
                dbHelper.AddInParameter(cmd, "@Update_Date", DbType.DateTime, Obj_WorkComp.Update_Date);
                dbHelper.AddInParameter(cmd, "@Claim_Report_Date", DbType.DateTime, Obj_WorkComp.Claim_Report_Date);
                dbHelper.AddInParameter(cmd, "@Auto_Liability_Recovery", DbType.Decimal, Obj_WorkComp.Auto_Liability_Recovery);
                dbHelper.AddInParameter(cmd, "@Loss_Adj_Expense_PTD", DbType.Decimal, Obj_WorkComp.Loss_Adj_Expense_PTD);
                dbHelper.AddInParameter(cmd, "@Anuity_Purchased", DbType.Decimal, Obj_WorkComp.Anuity_Purchased);
                dbHelper.AddInParameter(cmd, "@Legal_Expense_PTD", DbType.Decimal, Obj_WorkComp.Legal_Expense_PTD);
                dbHelper.AddInParameter(cmd, "@Medical_Eval_PTD", DbType.Decimal, Obj_WorkComp.Medical_Eval_PTD);
                dbHelper.AddInParameter(cmd, "@FK_Cost_Center", DbType.String, Obj_WorkComp.FK_Cost_Center);
                dbHelper.AddInParameter(cmd, "@CREATED_DATE", DbType.DateTime, Obj_WorkComp.CREATED_DATE);
                dbHelper.AddInParameter(cmd, "@Jurisdiction_Claim_Number", DbType.String, Obj_WorkComp.Jurisdiction_Claim_Number);
                dbHelper.AddInParameter(cmd, "@HealthTech_Incident_Number", DbType.String, Obj_WorkComp.HealthTech_Incident_Number);
                dbHelper.AddInParameter(cmd, "@fk_initial_treatment", DbType.Decimal, Obj_WorkComp.Fk_initial_treatment);
                dbHelper.AddInParameter(cmd, "@FK_NCCI_Classification_Code", DbType.String, Obj_WorkComp.FK_NCCI_Classification_Code);
                dbHelper.AddInParameter(cmd, "@FK_NCCI_Cause", DbType.Decimal, Obj_WorkComp.FK_NCCI_Cause);
                dbHelper.AddInParameter(cmd, "@FK_NCCI_Nature", DbType.Decimal, Obj_WorkComp.FK_NCCI_Nature);
                dbHelper.AddInParameter(cmd, "@FK_County", DbType.String, Obj_WorkComp.FK_County);
                dbHelper.AddInParameter(cmd, "@FK_Hazard_Code", DbType.Decimal, Obj_WorkComp.FK_Hazard_Code);
                dbHelper.AddInParameter(cmd, "@Claim_to_be_sent_to_FROI", DbType.String, Obj_WorkComp.Claim_to_be_sent_to_FROI);
                dbHelper.AddInParameter(cmd, "@dt_FROI", DbType.DateTime, Obj_WorkComp.Dt_FROI);
                dbHelper.AddInParameter(cmd, "@TTD_Benefits_Paid_to_Date", DbType.DateTime, Obj_WorkComp.TTD_Benefits_Paid_to_Date);
                dbHelper.AddInParameter(cmd, "@Settlement_yes_no", DbType.String, Obj_WorkComp.Settlement_yes_no);
                dbHelper.AddInParameter(cmd, "@Annuity_Purchased", DbType.String, Obj_WorkComp.Annuity_Purchased);
                dbHelper.AddInParameter(cmd, "@Diagnosis", DbType.String, Obj_WorkComp.Diagnosis);
                dbHelper.AddInParameter(cmd, "@Last_Office_Visit_Date", DbType.DateTime, Obj_WorkComp.Last_Office_Visit_Date);
                dbHelper.AddInParameter(cmd, "@Next_scheduled_visit_date", DbType.DateTime, Obj_WorkComp.Next_scheduled_visit_date);
                dbHelper.AddInParameter(cmd, "@Referral", DbType.String, Obj_WorkComp.Referral);
                dbHelper.AddInParameter(cmd, "@Physical_Therapy", DbType.String, Obj_WorkComp.Physical_Therapy);
                dbHelper.AddInParameter(cmd, "@Physicians_Panel_Requested", DbType.String, Obj_WorkComp.Physicians_Panel_Requested);
                dbHelper.AddInParameter(cmd, "@New_Treating_Physician", DbType.String, Obj_WorkComp.New_Treating_Physician);
                dbHelper.AddInParameter(cmd, "@date_incident_reported_to_CMS", DbType.DateTime, Obj_WorkComp.Date_incident_reported_to_CMS);
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
        public override int Delete_WorkerComp(System.Decimal lPK_Workers_Comp)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            int nRetVal = -1;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Wor_Deleteers_Comp");
                dbHelper.AddInParameter(cmd, "@PK_Workers_Comp", DbType.Decimal, lPK_Workers_Comp);
                nRetVal = dbHelper.ExecuteNonQuery(cmd);
                dbHelper = null; cmd.Dispose(); cmd = null;
                return nRetVal;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public override string ActivateInactivate_WorkerComp(string strIDs, int intModifiedBy, bool bIsActive)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            int nRetVal = -1;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Wor_ActivateInactivateers_Comps");
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
        public override List<RIMS_Base.cWorkerComp> GetAll(Boolean blnIsActive)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("WorkerComp_Select");
               // dbHelper.AddInParameter(cmd, "@IsActive", DbType.Boolean, blnIsActive);
                IDataReader reader = dbHelper.ExecuteReader(cmd);
                List<RIMS_Base.cWorkerComp> results = new List<RIMS_Base.cWorkerComp>();
                while (reader.Read())
                {
                    cWorkerComp Obj_WorkComp = new cWorkerComp();
                    Obj_WorkComp = MapFrom(reader);
                    results.Add(Obj_WorkComp);
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


        public override List<RIMS_Base.cWorkerComp> GetWorkerCompByID(System.Int32 pK_Workers_Comp)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("WorkerComp_Select");
                dbHelper.AddInParameter(cmd, "@PK_Workers_Comp", DbType.Int32, pK_Workers_Comp);
                List<RIMS_Base.cWorkerComp> result = new List<RIMS_Base.cWorkerComp>();

                IDataReader reader = dbHelper.ExecuteReader(cmd);
                cWorkerComp Obj_WorkComp = new cWorkerComp();
                if (reader.Read())
                {
                    Obj_WorkComp = MapFrom(reader) ;
                    result.Add(Obj_WorkComp);
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

        public override List<RIMS_Base.cWorkerComp> GetEmpDataByID(System.Int32 pK_Workers_Comp, System.Int32 pK_Employee_ID, System.Int32 Criatearea)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Employee_Data_ByID");
                dbHelper.AddInParameter(cmd, "@PK_Workers_Comp", DbType.Int32, pK_Workers_Comp);
                dbHelper.AddInParameter(cmd, "@PK_Employee_ID", DbType.Int32, pK_Employee_ID);
                dbHelper.AddInParameter(cmd, "@Criatearea", DbType.Int32, Criatearea);

                List<RIMS_Base.cWorkerComp> result = new List<RIMS_Base.cWorkerComp>();

                IDataReader reader = dbHelper.ExecuteReader(cmd);
                cWorkerComp Obj_Emp = new cWorkerComp();
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

        protected RIMS_Base.Dal.cWorkerComp MapFromEmployee(IDataReader reader)
        {
            RIMS_Base.Dal.cWorkerComp Obj_Empmap = new RIMS_Base.Dal.cWorkerComp();
            if (!Convert.IsDBNull(reader["First_Name"])) { Obj_Empmap.First_Name = Convert.ToString(reader["First_Name"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Last_Name"])) { Obj_Empmap.Last_Name = Convert.ToString(reader["Last_Name"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Middle_Name"])) { Obj_Empmap.Middle_Name = Convert.ToString(reader["Middle_Name"], CultureInfo.InvariantCulture); }
            return Obj_Empmap;
        }



        protected RIMS_Base.Dal.cWorkerComp MapFrom(IDataReader reader)
        {
            RIMS_Base.Dal.cWorkerComp Obj_WorkComp = new RIMS_Base.Dal.cWorkerComp();
            if (!Convert.IsDBNull(reader["PK_Workers_Comp"])) { Obj_WorkComp.PK_Workers_Comp = Convert.ToInt32(reader["PK_Workers_Comp"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Claim_Number"])) { Obj_WorkComp.Claim_Number = Convert.ToString(reader["Claim_Number"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Employee"])) { Obj_WorkComp.Employee = Convert.ToString(reader["Employee"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["fk_employee_claimant"])) { Obj_WorkComp.FK_Employee_Claimant = Convert.ToDecimal(reader["fk_employee_claimant"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FK_State_Coverage"])) { Obj_WorkComp.FK_State_Coverage = Convert.ToDecimal(reader["FK_State_Coverage"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FK_State_Accident"])) { Obj_WorkComp.FK_State_Accident = Convert.ToDecimal(reader["FK_State_Accident"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Incident_Date"])) { Obj_WorkComp.Incident_Date = Convert.ToDateTime(reader["Incident_Date"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["EE_RTW"])) { Obj_WorkComp.EE_RTW = Convert.ToString(reader["EE_RTW"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["EE_RTW_Date"])) { Obj_WorkComp.EE_RTW_Date = Convert.ToDateTime(reader["EE_RTW_Date"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["RTW_Wage"])) { Obj_WorkComp.RTW_Wage = Convert.ToString(reader["RTW_Wage"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Restricted_Duty"])) { Obj_WorkComp.Restricted_Duty = Convert.ToString(reader["Restricted_Duty"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Restrict_Description"])) { Obj_WorkComp.Restrict_Description = Convert.ToString(reader["Restrict_Description"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Restriction_Begin_Date"])) { Obj_WorkComp.Restriction_Begin_Date = Convert.ToDateTime(reader["Restriction_Begin_Date"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Restriction_End_Date"])) { Obj_WorkComp.Restriction_End_Date = Convert.ToDateTime(reader["Restriction_End_Date"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Est_Disability_Length_Weeks"])) { Obj_WorkComp.Est_Disability_Length_Weeks = Convert.ToDecimal(reader["Est_Disability_Length_Weeks"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Est_Disability_Length_Days"])) { Obj_WorkComp.Est_Disability_Length_Days = Convert.ToDecimal(reader["Est_Disability_Length_Days"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Act_Disability_Length_Weeks"])) { Obj_WorkComp.Act_Disability_Length_Weeks = Convert.ToDecimal(reader["Act_Disability_Length_Weeks"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Act_Disability_Length_Days"])) { Obj_WorkComp.Act_Disability_Length_Days = Convert.ToDecimal(reader["Act_Disability_Length_Days"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["MMI_Date"])) { Obj_WorkComp.MMI_Date = Convert.ToDateTime(reader["MMI_Date"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["PPD_Rating"])) { Obj_WorkComp.PPD_Rating = Convert.ToString(reader["PPD_Rating"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["AWW_Dollars"])) { Obj_WorkComp.AWW_Dollars = Convert.ToDecimal(reader["AWW_Dollars"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["AWW_Method"])) { Obj_WorkComp.AWW_Method = Convert.ToString(reader["AWW_Method"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["TTD_Dollars"])) { Obj_WorkComp.TTD_Dollars = Convert.ToDecimal(reader["TTD_Dollars"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Settlement_Method"])) { Obj_WorkComp.Settlement_Method = Convert.ToString(reader["Settlement_Method"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Claim_Description"])) { Obj_WorkComp.Claim_Description = Convert.ToString(reader["Claim_Description"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Nature"])) { Obj_WorkComp.Nature = Convert.ToDecimal(reader["Nature"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Estimate"])) { Obj_WorkComp.Estimate = Convert.ToDecimal(reader["Estimate"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Actual"])) { Obj_WorkComp.Actual = Convert.ToDecimal(reader["Actual"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FK_Claim_Cause"])) { Obj_WorkComp.FK_Claim_Cause = Convert.ToDecimal(reader["FK_Claim_Cause"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FK_Body_Parts"])) { Obj_WorkComp.FK_Body_Parts = Convert.ToDecimal(reader["FK_Body_Parts"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FK_Injury"])) { Obj_WorkComp.FK_Injury = Convert.ToDecimal(reader["FK_Injury"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FK_NCCI_Code"])) { Obj_WorkComp.FK_NCCI_Code = Convert.ToDecimal(reader["FK_NCCI_Code"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Vocation_Rehab"])) { Obj_WorkComp.Vocation_Rehab = Convert.ToString(reader["Vocation_Rehab"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FK_WC_Major_Claim_Type"])) { Obj_WorkComp.FK_WC_Major_Claim_Type = Convert.ToDecimal(reader["FK_WC_Major_Claim_Type"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FK_WC_Minor_Claim_Type"])) { Obj_WorkComp.FK_WC_Minor_Claim_Type = Convert.ToDecimal(reader["FK_WC_Minor_Claim_Type"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Convertible"])) { Obj_WorkComp.Convertible = Convert.ToString(reader["Convertible"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FK_Fraud_Claim"])) { Obj_WorkComp.FK_Fraud_Claim = Convert.ToDecimal(reader["FK_Fraud_Claim"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Claim_Open_Date"])) { Obj_WorkComp.Claim_Open_Date = Convert.ToDateTime(reader["Claim_Open_Date"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Claim_Close_Date"])) { Obj_WorkComp.Claim_Close_Date = Convert.ToDateTime(reader["Claim_Close_Date"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Claim_Reopen_Date"])) { Obj_WorkComp.Claim_Reopen_Date = Convert.ToDateTime(reader["Claim_Reopen_Date"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Surgery_Required"])) { Obj_WorkComp.Surgery_Required = Convert.ToString(reader["Surgery_Required"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Indemnity_Weeks"])) { Obj_WorkComp.Indemnity_Weeks = Convert.ToDecimal(reader["Indemnity_Weeks"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FK_State_Jurisdiction"])) { Obj_WorkComp.FK_State_Jurisdiction = Convert.ToDecimal(reader["FK_State_Jurisdiction"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FK_Employee"])) { Obj_WorkComp.FK_Employee = Convert.ToDecimal(reader["FK_Employee"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FK_Method_Pre_Injury_Wage"])) { Obj_WorkComp.FK_Method_Pre_Injury_Wage = Convert.ToDecimal(reader["FK_Method_Pre_Injury_Wage"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FK_Method_Of_Settlement"])) { Obj_WorkComp.FK_Method_Of_Settlement = Convert.ToDecimal(reader["FK_Method_Of_Settlement"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Pre_Injury_Weekly_Wage"])) { Obj_WorkComp.Pre_Injury_Weekly_Wage = Convert.ToDecimal(reader["Pre_Injury_Weekly_Wage"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Post_Injury_Weekly_Wage"])) { Obj_WorkComp.Post_Injury_Weekly_Wage = Convert.ToDecimal(reader["Post_Injury_Weekly_Wage"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Present_Valuation_Future_Indemnity"])) { Obj_WorkComp.Present_Valuation_Future_Indemnity = Convert.ToDecimal(reader["Present_Valuation_Future_Indemnity"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FK_Injury_1"])) { Obj_WorkComp.FK_Injury_1 = Convert.ToDecimal(reader["FK_Injury_1"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Benefits_Paid_To_Date_1"])) { Obj_WorkComp.Benefits_Paid_To_Date_1 = Convert.ToDecimal(reader["Benefits_Paid_To_Date_1"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Weekly_Benefit_1"])) { Obj_WorkComp.Weekly_Benefit_1 = Convert.ToDecimal(reader["Weekly_Benefit_1"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FK_Injury_2"])) { Obj_WorkComp.FK_Injury_2 = Convert.ToDecimal(reader["FK_Injury_2"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Benefits_Paid_To_Date_2"])) { Obj_WorkComp.Benefits_Paid_To_Date_2 = Convert.ToDecimal(reader["Benefits_Paid_To_Date_2"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Weekly_Benefit_2"])) { Obj_WorkComp.Weekly_Benefit_2 = Convert.ToDecimal(reader["Weekly_Benefit_2"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FK_Injury_3"])) { Obj_WorkComp.FK_Injury_3 = Convert.ToDecimal(reader["FK_Injury_3"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Benefits_Paid_To_Date_3"])) { Obj_WorkComp.Benefits_Paid_To_Date_3 = Convert.ToDecimal(reader["Benefits_Paid_To_Date_3"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Weekly_Benefit_3"])) { Obj_WorkComp.Weekly_Benefit_3 = Convert.ToDecimal(reader["Weekly_Benefit_3"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FK_Injury_4"])) { Obj_WorkComp.FK_Injury_4 = Convert.ToDecimal(reader["FK_Injury_4"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Benefits_Paid_To_Date_4"])) { Obj_WorkComp.Benefits_Paid_To_Date_4 = Convert.ToDecimal(reader["Benefits_Paid_To_Date_4"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Weekly_Benefit_4"])) { Obj_WorkComp.Weekly_Benefit_4 = Convert.ToDecimal(reader["Weekly_Benefit_4"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FK_Injury_5"])) { Obj_WorkComp.FK_Injury_5 = Convert.ToDecimal(reader["FK_Injury_5"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Benefits_Paid_To_Date_5"])) { Obj_WorkComp.Benefits_Paid_To_Date_5 = Convert.ToDecimal(reader["Benefits_Paid_To_Date_5"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Weekly_Benefit_5"])) { Obj_WorkComp.Weekly_Benefit_5 = Convert.ToDecimal(reader["Weekly_Benefit_5"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FK_Beneficiary_Code_1"])) { Obj_WorkComp.FK_Beneficiary_Code_1 = Convert.ToDecimal(reader["FK_Beneficiary_Code_1"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Beneficiary_DOB_1"])) { Obj_WorkComp.Beneficiary_DOB_1 = Convert.ToDateTime(reader["Beneficiary_DOB_1"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FK_Beneficiary_Code_2"])) { Obj_WorkComp.FK_Beneficiary_Code_2 = Convert.ToDecimal(reader["FK_Beneficiary_Code_2"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Beneficiary_DOB_2"])) { Obj_WorkComp.Beneficiary_DOB_2 = Convert.ToDateTime(reader["Beneficiary_DOB_2"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FK_Beneficiary_Code_3"])) { Obj_WorkComp.FK_Beneficiary_Code_3 = Convert.ToDecimal(reader["FK_Beneficiary_Code_3"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Beneficiary_DOB_3"])) { Obj_WorkComp.Beneficiary_DOB_3 = Convert.ToDateTime(reader["Beneficiary_DOB_3"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FK_Beneficiary_Code_4"])) { Obj_WorkComp.FK_Beneficiary_Code_4 = Convert.ToDecimal(reader["FK_Beneficiary_Code_4"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Beneficiary_DOB_4"])) { Obj_WorkComp.Beneficiary_DOB_4 = Convert.ToDateTime(reader["Beneficiary_DOB_4"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FK_Beneficiary_Code_5"])) { Obj_WorkComp.FK_Beneficiary_Code_5 = Convert.ToDecimal(reader["FK_Beneficiary_Code_5"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Beneficiary_DOB_5"])) { Obj_WorkComp.Beneficiary_DOB_5 = Convert.ToDateTime(reader["Beneficiary_DOB_5"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Suit_Date"])) { Obj_WorkComp.Suit_Date = Convert.ToDateTime(reader["Suit_Date"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Attorney_Disclosure_Date"])) { Obj_WorkComp.Attorney_Disclosure_Date = Convert.ToDateTime(reader["Attorney_Disclosure_Date"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Client_Attorney_Name"])) { Obj_WorkComp.Client_Attorney_Name = Convert.ToString(reader["Client_Attorney_Name"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Client_Attorney_Address_1"])) { Obj_WorkComp.Client_Attorney_Address_1 = Convert.ToString(reader["Client_Attorney_Address_1"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Client_Attorney_Address_2"])) { Obj_WorkComp.Client_Attorney_Address_2 = Convert.ToString(reader["Client_Attorney_Address_2"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Client_Attorney_City"])) { Obj_WorkComp.Client_Attorney_City = Convert.ToString(reader["Client_Attorney_City"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FK_State_Client_Attorney"])) { Obj_WorkComp.FK_State_Client_Attorney = Convert.ToDecimal(reader["FK_State_Client_Attorney"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Client_Attorney_Zip_Code"])) { Obj_WorkComp.Client_Attorney_Zip_Code = Convert.ToString(reader["Client_Attorney_Zip_Code"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Client_Attorney_Phone"])) { Obj_WorkComp.Client_Attorney_Phone = Convert.ToString(reader["Client_Attorney_Phone"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Client_Attorney_Fax"])) { Obj_WorkComp.Client_Attorney_Fax = Convert.ToString(reader["Client_Attorney_Fax"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Defense_Attorney_Name"])) { Obj_WorkComp.Defense_Attorney_Name = Convert.ToString(reader["Defense_Attorney_Name"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Defense_Attorney_Address_1"])) { Obj_WorkComp.Defense_Attorney_Address_1 = Convert.ToString(reader["Defense_Attorney_Address_1"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Defense_Attorney_Address_2"])) { Obj_WorkComp.Defense_Attorney_Address_2 = Convert.ToString(reader["Defense_Attorney_Address_2"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Defense_Attorney_City"])) { Obj_WorkComp.Defense_Attorney_City = Convert.ToString(reader["Defense_Attorney_City"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FK_State_Defense_Attorney"])) { Obj_WorkComp.FK_State_Defense_Attorney = Convert.ToDecimal(reader["FK_State_Defense_Attorney"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Defense_Attorney_Zip_Code"])) { Obj_WorkComp.Defense_Attorney_Zip_Code = Convert.ToString(reader["Defense_Attorney_Zip_Code"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Defense_Attorney_Phone"])) { Obj_WorkComp.Defense_Attorney_Phone = Convert.ToString(reader["Defense_Attorney_Phone"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Defense_Attorney_Fax"])) { Obj_WorkComp.Defense_Attorney_Fax = Convert.ToString(reader["Defense_Attorney_Fax"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Medical_Provider"])) { Obj_WorkComp.Medical_Provider = Convert.ToString(reader["Medical_Provider"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Medical_Provider_Phone"])) { Obj_WorkComp.Medical_Provider_Phone = Convert.ToString(reader["Medical_Provider_Phone"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Hospital"])) { Obj_WorkComp.Hospital = Convert.ToString(reader["Hospital"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["MCO_Type"])) { Obj_WorkComp.MCO_Type = Convert.ToString(reader["MCO_Type"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Death_Date"])) { Obj_WorkComp.Death_Date = Convert.ToDateTime(reader["Death_Date"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Delete_Reason"])) { Obj_WorkComp.Delete_Reason = Convert.ToString(reader["Delete_Reason"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Date_Max_Med_Imp"])) { Obj_WorkComp.Date_Max_Med_Imp = Convert.ToDateTime(reader["Date_Max_Med_Imp"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FK_Managed_Care_Org_Type"])) { Obj_WorkComp.FK_Managed_Care_Org_Type = Convert.ToDecimal(reader["FK_Managed_Care_Org_Type"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Percentage_Impairment"])) { Obj_WorkComp.Percentage_Impairment = Convert.ToDecimal(reader["Percentage_Impairment"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Percentage_Disability"])) { Obj_WorkComp.Percentage_Disability = Convert.ToDecimal(reader["Percentage_Disability"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FK_Employee_Reported"])) { Obj_WorkComp.FK_Employee_Reported = Convert.ToDecimal(reader["FK_Employee_Reported"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Incident_Time"])) { Obj_WorkComp.Incident_Time = Convert.ToString(reader["Incident_Time"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Within_24_Hours"])) { Obj_WorkComp.Within_24_Hours = Convert.ToString(reader["Within_24_Hours"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Date_Reported"])) { Obj_WorkComp.Date_Reported = Convert.ToDateTime(reader["Date_Reported"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Date_Reported_Employer"])) { Obj_WorkComp.Date_Reported_Employer = Convert.ToDateTime(reader["Date_Reported_Employer"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Time_Reported"])) { Obj_WorkComp.Time_Reported = Convert.ToString(reader["Time_Reported"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Location"])) { Obj_WorkComp.Location = Convert.ToString(reader["Location"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Location_Address_1"])) { Obj_WorkComp.Location_Address_1 = Convert.ToString(reader["Location_Address_1"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Location_Address_2"])) { Obj_WorkComp.Location_Address_2 = Convert.ToString(reader["Location_Address_2"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Location_City"])) { Obj_WorkComp.Location_City = Convert.ToString(reader["Location_City"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FK_State_Location"])) { Obj_WorkComp.FK_State_Location = Convert.ToDecimal(reader["FK_State_Location"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Location_Zip"])) { Obj_WorkComp.Location_Zip = Convert.ToString(reader["Location_Zip"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Location_County"])) { Obj_WorkComp.Location_County = Convert.ToString(reader["Location_County"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Location_Country"])) { Obj_WorkComp.Location_Country = Convert.ToString(reader["Location_Country"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Location_Phone"])) { Obj_WorkComp.Location_Phone = Convert.ToString(reader["Location_Phone"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Location_Fax"])) { Obj_WorkComp.Location_Fax = Convert.ToString(reader["Location_Fax"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Date_Return"])) { Obj_WorkComp.Date_Return = Convert.ToDateTime(reader["Date_Return"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Employer_Contact"])) { Obj_WorkComp.Employer_Contact = Convert.ToString(reader["Employer_Contact"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Employer_Contact_Date"])) { Obj_WorkComp.Employer_Contact_Date = Convert.ToDateTime(reader["Employer_Contact_Date"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Claimant_Contact"])) { Obj_WorkComp.Claimant_Contact = Convert.ToString(reader["Claimant_Contact"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Claimant_Contact_Date"])) { Obj_WorkComp.Claimant_Contact_Date = Convert.ToDateTime(reader["Claimant_Contact_Date"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Statement_Claimant"])) { Obj_WorkComp.Statement_Claimant = Convert.ToString(reader["Statement_Claimant"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Statement_Claimant_Date"])) { Obj_WorkComp.Statement_Claimant_Date = Convert.ToDateTime(reader["Statement_Claimant_Date"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Witness_1"])) { Obj_WorkComp.Witness_1 = Convert.ToString(reader["Witness_1"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Statement_Witness_1"])) { Obj_WorkComp.Statement_Witness_1 = Convert.ToString(reader["Statement_Witness_1"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Statement_Witness_1_Date"])) { Obj_WorkComp.Statement_Witness_1_Date = Convert.ToDateTime(reader["Statement_Witness_1_Date"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Witness_2"])) { Obj_WorkComp.Witness_2 = Convert.ToString(reader["Witness_2"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Statement_Witness_2"])) { Obj_WorkComp.Statement_Witness_2 = Convert.ToString(reader["Statement_Witness_2"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Statement_Witness_2_Date"])) { Obj_WorkComp.Statement_Witness_2_Date = Convert.ToDateTime(reader["Statement_Witness_2_Date"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Witness_3"])) { Obj_WorkComp.Witness_3 = Convert.ToString(reader["Witness_3"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Statement_Witness_3"])) { Obj_WorkComp.Statement_Witness_3 = Convert.ToString(reader["Statement_Witness_3"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Statement_Witness_3_Date"])) { Obj_WorkComp.Statement_Witness_3_Date = Convert.ToDateTime(reader["Statement_Witness_3_Date"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Updated_By"])) { Obj_WorkComp.Updated_By = Convert.ToString(reader["Updated_By"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Update_Date"])) { Obj_WorkComp.Update_Date = Convert.ToDateTime(reader["Update_Date"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Claim_Report_Date"])) { Obj_WorkComp.Claim_Report_Date = Convert.ToDateTime(reader["Claim_Report_Date"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Auto_Liability_Recovery"])) { Obj_WorkComp.Auto_Liability_Recovery = Convert.ToDecimal(reader["Auto_Liability_Recovery"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Loss_Adj_Expense_PTD"])) { Obj_WorkComp.Loss_Adj_Expense_PTD = Convert.ToDecimal(reader["Loss_Adj_Expense_PTD"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Anuity_Purchased"])) { Obj_WorkComp.Anuity_Purchased = Convert.ToDecimal(reader["Anuity_Purchased"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Legal_Expense_PTD"])) { Obj_WorkComp.Legal_Expense_PTD = Convert.ToDecimal(reader["Legal_Expense_PTD"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Medical_Eval_PTD"])) { Obj_WorkComp.Medical_Eval_PTD = Convert.ToDecimal(reader["Medical_Eval_PTD"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FK_Cost_Center"])) { Obj_WorkComp.FK_Cost_Center = Convert.ToString(reader["FK_Cost_Center"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["CREATED_DATE"])) { Obj_WorkComp.CREATED_DATE = Convert.ToDateTime(reader["CREATED_DATE"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Jurisdiction_Claim_Number"])) { Obj_WorkComp.Jurisdiction_Claim_Number = Convert.ToString(reader["Jurisdiction_Claim_Number"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["HealthTech_Incident_Number"])) { Obj_WorkComp.HealthTech_Incident_Number = Convert.ToString(reader["HealthTech_Incident_Number"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["fk_initial_treatment"])) { Obj_WorkComp.Fk_initial_treatment = Convert.ToDecimal(reader["fk_initial_treatment"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FK_NCCI_Classification_Code"])) { Obj_WorkComp.FK_NCCI_Classification_Code = Convert.ToString(reader["FK_NCCI_Classification_Code"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FK_NCCI_Cause"])) { Obj_WorkComp.FK_NCCI_Cause = Convert.ToDecimal(reader["FK_NCCI_Cause"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FK_NCCI_Nature"])) { Obj_WorkComp.FK_NCCI_Nature = Convert.ToDecimal(reader["FK_NCCI_Nature"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FK_County"])) { Obj_WorkComp.FK_County = Convert.ToString(reader["FK_County"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FK_Hazard_Code"])) { Obj_WorkComp.FK_Hazard_Code = Convert.ToDecimal(reader["FK_Hazard_Code"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Claim_to_be_sent_to_FROI"])) { Obj_WorkComp.Claim_to_be_sent_to_FROI = Convert.ToString(reader["Claim_to_be_sent_to_FROI"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["dt_FROI"])) { Obj_WorkComp.Dt_FROI = Convert.ToDateTime(reader["dt_FROI"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["TTD_Benefits_Paid_to_Date"])) { Obj_WorkComp.TTD_Benefits_Paid_to_Date = Convert.ToDateTime(reader["TTD_Benefits_Paid_to_Date"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Settlement_yes_no"])) { Obj_WorkComp.Settlement_yes_no = Convert.ToString(reader["Settlement_yes_no"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Annuity_Purchased"])) { Obj_WorkComp.Annuity_Purchased = Convert.ToString(reader["Annuity_Purchased"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Diagnosis"])) { Obj_WorkComp.Diagnosis = Convert.ToString(reader["Diagnosis"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Last_Office_Visit_Date"])) { Obj_WorkComp.Last_Office_Visit_Date = Convert.ToDateTime(reader["Last_Office_Visit_Date"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Next_scheduled_visit_date"])) { Obj_WorkComp.Next_scheduled_visit_date = Convert.ToDateTime(reader["Next_scheduled_visit_date"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Referral"])) { Obj_WorkComp.Referral = Convert.ToString(reader["Referral"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Physical_Therapy"])) { Obj_WorkComp.Physical_Therapy = Convert.ToString(reader["Physical_Therapy"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Physicians_Panel_Requested"])) { Obj_WorkComp.Physicians_Panel_Requested = Convert.ToString(reader["Physicians_Panel_Requested"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["New_Treating_Physician"])) { Obj_WorkComp.New_Treating_Physician = Convert.ToString(reader["New_Treating_Physician"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["date_incident_reported_to_CMS"])) { Obj_WorkComp.Date_incident_reported_to_CMS = Convert.ToDateTime(reader["date_incident_reported_to_CMS"], CultureInfo.InvariantCulture); }
            return Obj_WorkComp;
        }




        public override List<RIMS_Base.cWorkerComp> GetCostCenterByID(System.Int32 pK_Workers_Comp, System.String cost_Center)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("CostCenter_Data_ByID");
                dbHelper.AddInParameter(cmd, "@PK_Workers_Comp", DbType.Int32, pK_Workers_Comp);
                dbHelper.AddInParameter(cmd, "@Cost_Center", DbType.String, cost_Center);
              // dbHelper.AddInParameter(cmd, "@Criatearea", DbType.Int32, Criatearea);

                List<RIMS_Base.cWorkerComp> result = new List<RIMS_Base.cWorkerComp>();

                IDataReader reader = dbHelper.ExecuteReader(cmd);
                cWorkerComp Obj_Emp = new cWorkerComp();
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

        protected RIMS_Base.Dal.cWorkerComp MapFromCostCenter(IDataReader reader)
        {
            RIMS_Base.Dal.cWorkerComp Obj_Empmap = new RIMS_Base.Dal.cWorkerComp();
           // if (!Convert.IsDBNull(reader["Cost_Center"])) { Obj_Empmap.Cost_Center = Convert.ToString(reader["Cost_Center"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Division_Name"])) { Obj_Empmap.Division_Name = Convert.ToString(reader["Division_Name"], CultureInfo.InvariantCulture); }
            //if (!Convert.IsDBNull(reader["Middle_Name"])) { Obj_Empmap.Middle_Name = Convert.ToString(reader["Middle_Name"], CultureInfo.InvariantCulture); }
            return Obj_Empmap;
        }



      






    }


}

