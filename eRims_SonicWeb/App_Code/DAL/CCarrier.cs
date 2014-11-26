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


    public class CCarrier : RIMS_Base.CCarrier
    {

        public override int InsertUpdateCarrier(RIMS_Base.CCarrier Objier)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            int nRetVal = -1;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Carrier_InsertUpdate");
                dbHelper.AddParameter(cmd, "@PK_Carrier", DbType.Int32, ParameterDirection.InputOutput, "PK_Carrier", DataRowVersion.Current, Objier.PK_Carrier);
                dbHelper.AddInParameter(cmd, "@Table_Name", DbType.String, Objier.Table_Name);
                dbHelper.AddInParameter(cmd, "@FK_Table_Name", DbType.Decimal, Objier.FK_Table_Name);
                dbHelper.AddInParameter(cmd, "@Claims_Made_Indicator", DbType.String, Objier.Claims_Made_Indicator);
                dbHelper.AddInParameter(cmd, "@Defense_Medical_Eval_PTD", DbType.Decimal, Objier.Defense_Medical_Eval_PTD);
                dbHelper.AddInParameter(cmd, "@Employer_Legal_Expense_To_Date", DbType.Decimal, Objier.Employer_Legal_Expense_To_Date);
                dbHelper.AddInParameter(cmd, "@FK_Employer_Payroll_Table", DbType.Decimal, Objier.FK_Employer_Payroll_Table);
                dbHelper.AddInParameter(cmd, "@Employer_Liability", DbType.Decimal, Objier.Employer_Liability);
                dbHelper.AddInParameter(cmd, "@Employer_Liability_PTD", DbType.Decimal, Objier.Employer_Liability_PTD);
                dbHelper.AddInParameter(cmd, "@Expert_Witness_PTD", DbType.Decimal, Objier.Expert_Witness_PTD);
                dbHelper.AddInParameter(cmd, "@Funeral_Expense_PTD", DbType.Decimal, Objier.Funeral_Expense_PTD);
                dbHelper.AddInParameter(cmd, "@Hospital_Cost_PTD", DbType.Decimal, Objier.Hospital_Cost_PTD);
                dbHelper.AddInParameter(cmd, "@Independent_Subcontractor_No", DbType.String, Objier.Independent_Subcontractor_No);
                dbHelper.AddInParameter(cmd, "@FK_Major_Class_Code", DbType.Decimal, Objier.FK_Major_Class_Code);
                dbHelper.AddInParameter(cmd, "@Producer_Code", DbType.Decimal, Objier.Producer_Code);
                dbHelper.AddInParameter(cmd, "@Product_Liability_Recovery", DbType.Decimal, Objier.Product_Liability_Recovery);
                dbHelper.AddInParameter(cmd, "@Product_Name", DbType.String, Objier.Product_Name);
                dbHelper.AddInParameter(cmd, "@FK_Loss_Conditions_Act", DbType.Decimal, Objier.FK_Loss_Conditions_Act);
                dbHelper.AddInParameter(cmd, "@FK_Loss_Conditions_Recovery", DbType.Decimal, Objier.FK_Loss_Conditions_Recovery);
                dbHelper.AddInParameter(cmd, "@FK_Loss_Coverage_Code", DbType.Decimal, Objier.FK_Loss_Coverage_Code);
                dbHelper.AddInParameter(cmd, "@Lump_Sum_Remarriage_Payment", DbType.Decimal, Objier.Lump_Sum_Remarriage_Payment);
                dbHelper.AddInParameter(cmd, "@Incurred_Loss", DbType.Decimal, Objier.Incurred_Loss);
                dbHelper.AddInParameter(cmd, "@Other_Benefit_Offset", DbType.String, Objier.Other_Benefit_Offset);
                dbHelper.AddInParameter(cmd, "@Other_Medical_PTD", DbType.Decimal, Objier.Other_Medical_PTD);
                dbHelper.AddInParameter(cmd, "@Other_Voc_Rehab_PTD", DbType.Decimal, Objier.Other_Voc_Rehab_PTD);
                dbHelper.AddInParameter(cmd, "@Penalties_PTD", DbType.Decimal, Objier.Penalties_PTD);
                dbHelper.AddInParameter(cmd, "@Pension_Indem_PTVD", DbType.Decimal, Objier.Pension_Indem_PTVD);
                dbHelper.AddInParameter(cmd, "@Pension_Reserved", DbType.Decimal, Objier.Pension_Reserved);
                dbHelper.AddInParameter(cmd, "@Pension_Offset", DbType.String, Objier.Pension_Offset);
                dbHelper.AddInParameter(cmd, "@FK_State_Garage", DbType.Decimal, Objier.FK_State_Garage);
                dbHelper.AddInParameter(cmd, "@FK_Injury_Code", DbType.Decimal, Objier.FK_Injury_Code);
                dbHelper.AddInParameter(cmd, "@FK_Property_Damage", DbType.Decimal, Objier.FK_Property_Damage);
                dbHelper.AddInParameter(cmd, "@Recovery_Current_Month", DbType.Decimal, Objier.Recovery_Current_Month);
                dbHelper.AddInParameter(cmd, "@Recovery_To_Date", DbType.Decimal, Objier.Recovery_To_Date);
                dbHelper.AddInParameter(cmd, "@Reserve_Type_Code", DbType.Decimal, Objier.Reserve_Type_Code);
                dbHelper.AddInParameter(cmd, "@Single_Sum_Paid_Date", DbType.DateTime, Objier.Single_Sum_Paid_Date);
                dbHelper.AddInParameter(cmd, "@Single_Sum_Paid", DbType.Decimal, Objier.Single_Sum_Paid);
                dbHelper.AddInParameter(cmd, "@SS_Benefit_Offset", DbType.String, Objier.SS_Benefit_Offset);
                dbHelper.AddInParameter(cmd, "@SS_Other_Amount", DbType.Decimal, Objier.SS_Other_Amount);
                dbHelper.AddInParameter(cmd, "@Special_Fund_Offset", DbType.String, Objier.Special_Fund_Offset);
                dbHelper.AddInParameter(cmd, "@Symbol", DbType.Decimal, Objier.Symbol);
                dbHelper.AddInParameter(cmd, "@FK_State_Tax", DbType.Decimal, Objier.FK_State_Tax);
                dbHelper.AddInParameter(cmd, "@TPA_Internal_Claim_Code", DbType.String, Objier.TPA_Internal_Claim_Code);
                dbHelper.AddInParameter(cmd, "@Temp_Indem_Incurred", DbType.Decimal, Objier.Temp_Indem_Incurred);
                dbHelper.AddInParameter(cmd, "@Temp_Indem_No_Weeks", DbType.Decimal, Objier.Temp_Indem_No_Weeks);
                dbHelper.AddInParameter(cmd, "@T_E_Current_Month", DbType.Decimal, Objier.T_E_Current_Month);
                dbHelper.AddInParameter(cmd, "@T_E_To_Date", DbType.Decimal, Objier.T_E_To_Date);
                dbHelper.AddInParameter(cmd, "@Total_Gross_Incurred", DbType.Decimal, Objier.Total_Gross_Incurred);
                dbHelper.AddInParameter(cmd, "@Total_Incurred_Voc_Rehab", DbType.Decimal, Objier.Total_Incurred_Voc_Rehab);
                dbHelper.AddInParameter(cmd, "@Total_Incurred_Voc_Rehab_Edu", DbType.Decimal, Objier.Total_Incurred_Voc_Rehab_Edu);
                dbHelper.AddInParameter(cmd, "@Total_Incurred_Voc_Rehab_Eval", DbType.Decimal, Objier.Total_Incurred_Voc_Rehab_Eval);
                dbHelper.AddInParameter(cmd, "@Total_Incurred_Voc_Rehab_Main", DbType.Decimal, Objier.Total_Incurred_Voc_Rehab_Main);
                dbHelper.AddInParameter(cmd, "@Total_Payments_Phys", DbType.Decimal, Objier.Total_Payments_Phys);
                dbHelper.AddInParameter(cmd, "@Trans_Type", DbType.Decimal, Objier.Trans_Type);
                dbHelper.AddInParameter(cmd, "@Unemp_Benefit_Offset", DbType.String, Objier.Unemp_Benefit_Offset);
                dbHelper.AddInParameter(cmd, "@Unique_Occur_Claim", DbType.String, Objier.Unique_Occur_Claim);
                dbHelper.AddInParameter(cmd, "@Lump_Sum_Settlement", DbType.Decimal, Objier.Lump_Sum_Settlement);
                dbHelper.AddInParameter(cmd, "@Other_Recovery", DbType.Decimal, Objier.Other_Recovery);
                dbHelper.AddInParameter(cmd, "@Other_Weekly_Pymnts", DbType.Decimal, Objier.Other_Weekly_Pymnts);
                dbHelper.AddInParameter(cmd, "@Updated_By", DbType.String, Objier.Updated_By);
                dbHelper.AddInParameter(cmd, "@Update_Date", DbType.DateTime, Objier.Update_Date);
                dbHelper.AddInParameter(cmd, "@WC_Cat_Number", DbType.Decimal, Objier.WC_Cat_Number);
                dbHelper.AddInParameter(cmd, "@WC_Indemnity_Payment", DbType.Decimal, Objier.WC_Indemnity_Payment);
                dbHelper.AddInParameter(cmd, "@Indemnity_Incurred", DbType.Decimal, Objier.Indemnity_Incurred);
                dbHelper.AddInParameter(cmd, "@Indemnity_Paid_Current", DbType.Decimal, Objier.Indemnity_Paid_Current);
                dbHelper.AddInParameter(cmd, "@Indemnity_PTD", DbType.Decimal, Objier.Indemnity_PTD);
                dbHelper.AddInParameter(cmd, "@Medical_Incurred", DbType.Decimal, Objier.Medical_Incurred);
                dbHelper.AddInParameter(cmd, "@Medical_Paid_Current", DbType.Decimal, Objier.Medical_Paid_Current);
                dbHelper.AddInParameter(cmd, "@Medical_PTD", DbType.Decimal, Objier.Medical_PTD);
                dbHelper.AddInParameter(cmd, "@Expense_Incurred", DbType.Decimal, Objier.Expense_Incurred);
                dbHelper.AddInParameter(cmd, "@Expense_Paid_Current", DbType.Decimal, Objier.Expense_Paid_Current);
                dbHelper.AddInParameter(cmd, "@Expense_PTD", DbType.Decimal, Objier.Expense_PTD);
                dbHelper.AddInParameter(cmd, "@Controverted_Case", DbType.String, Objier.Controverted_Case);
                dbHelper.AddInParameter(cmd, "@Deductible_Indicator", DbType.String, Objier.Deductible_Indicator);
                dbHelper.AddInParameter(cmd, "@AIG_Policy_Prefix", DbType.String, Objier.AIG_Policy_Prefix);
                dbHelper.AddInParameter(cmd, "@FK_AIG_Policy_Number", DbType.Decimal, Objier.FK_AIG_Policy_Number);
                dbHelper.AddInParameter(cmd, "@FK_Loss_Conditions_Loss", DbType.Decimal, Objier.FK_Loss_Conditions_Loss);
                dbHelper.AddInParameter(cmd, "@FK_Loss_Conditions_Settlement", DbType.Decimal, Objier.FK_Loss_Conditions_Settlement);
                dbHelper.AddInParameter(cmd, "@FK_Settlement_Method", DbType.Decimal, Objier.FK_Settlement_Method);
                dbHelper.AddInParameter(cmd, "@Legal_Representation", DbType.String, Objier.Legal_Representation);
                dbHelper.AddInParameter(cmd, "@FK_Attorney_Form", DbType.Decimal, Objier.FK_Attorney_Form);
                dbHelper.AddInParameter(cmd, "@Deductible_Reimbursement", DbType.Decimal, Objier.Deductible_Reimbursement);
                dbHelper.AddInParameter(cmd, "@Insurer_Reimbursed_Benifi_Payable_Claimant", DbType.String, Objier.Insurer_Reimbursed_Benifi_Payable_Claimant);
                dbHelper.ExecuteNonQuery(cmd);

                nRetVal = int.Parse(dbHelper.GetParameterValue(cmd, "@PK_Carrier").ToString());
                return nRetVal;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            { dbHelper = null; cmd.Dispose(); cmd = null; }
        }
        public override int DeleteCarrier(System.Decimal lPK_Carrier)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            int nRetVal = -1;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Carrier_Delete");
                dbHelper.AddInParameter(cmd, "@PK_Carrier", DbType.Decimal, lPK_Carrier);
                nRetVal = dbHelper.ExecuteNonQuery(cmd);
                dbHelper = null; cmd.Dispose(); cmd = null;
                return nRetVal;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public override string ActivateInactivCarrier(string strIDs, int intModifiedBy, bool bIsActive)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            int nRetVal = -1;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Car_ActivateInactivateiers");
                dbHelper.AddParameter(cmd, "@PK_Carriers", DbType.String, ParameterDirection.InputOutput, "PK_Carriers", DataRowVersion.Current, strIDs);
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
        public override List<RIMS_Base.CCarrier> GetAll()
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Carrier_SelectDetail");
                IDataReader reader = dbHelper.ExecuteReader(cmd);
                List<RIMS_Base.CCarrier> results = new List<RIMS_Base.CCarrier>();
                while (reader.Read())
                {
                    CCarrier objier = new CCarrier();
                    objier = MapFrom(reader);
                    results.Add(objier);
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


        public override List<RIMS_Base.CCarrier> GetCarrierByID(System.Decimal Fk_Table_Name, System.String Table_Name)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Carrier_SelectDetail");
                dbHelper.AddInParameter(cmd, "@FK_Table_Name", DbType.Decimal, Fk_Table_Name);
                dbHelper.AddInParameter(cmd, "@Table_Name", DbType.String, Table_Name);
                List<RIMS_Base.CCarrier> results = new List<RIMS_Base.CCarrier>();
                IDataReader reader = dbHelper.ExecuteReader(cmd);
                CCarrier objier = new CCarrier();
                if (reader.Read())
                {
                    objier = MapFrom(reader);
                    results.Add(objier);
                }
                reader.Close();
                cmd = null;
                dbHelper = null;

                //return objier;
                return results;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public override DataSet GetCarrierLabel()
        {
            DbCommand cmd = null;
            DataSet dstDataset = null;
            Database dbHelper = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Get_Carrier_Label");
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

        protected RIMS_Base.Dal.CCarrier MapFrom(IDataReader reader)
        {
            RIMS_Base.Dal.CCarrier objier = new RIMS_Base.Dal.CCarrier();
            if (!Convert.IsDBNull(reader["PK_Carrier"])) { objier.PK_Carrier = Convert.ToInt32(reader["PK_Carrier"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Table_Name"])) { objier.Table_Name = Convert.ToString(reader["Table_Name"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FK_Table_Name"])) { objier.FK_Table_Name = Convert.ToDecimal(reader["FK_Table_Name"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Claims_Made_Indicator"])) { objier.Claims_Made_Indicator = Convert.ToString(reader["Claims_Made_Indicator"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Defense_Medical_Eval_PTD"])) { objier.Defense_Medical_Eval_PTD = Convert.ToDecimal(reader["Defense_Medical_Eval_PTD"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Employer_Legal_Expense_To_Date"])) { objier.Employer_Legal_Expense_To_Date = Convert.ToDecimal(reader["Employer_Legal_Expense_To_Date"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FK_Employer_Payroll_Table"])) { objier.FK_Employer_Payroll_Table = Convert.ToDecimal(reader["FK_Employer_Payroll_Table"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Employer_Liability"])) { objier.Employer_Liability = Convert.ToDecimal(reader["Employer_Liability"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Employer_Liability_PTD"])) { objier.Employer_Liability_PTD = Convert.ToDecimal(reader["Employer_Liability_PTD"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Expert_Witness_PTD"])) { objier.Expert_Witness_PTD = Convert.ToDecimal(reader["Expert_Witness_PTD"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Funeral_Expense_PTD"])) { objier.Funeral_Expense_PTD = Convert.ToDecimal(reader["Funeral_Expense_PTD"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Hospital_Cost_PTD"])) { objier.Hospital_Cost_PTD = Convert.ToDecimal(reader["Hospital_Cost_PTD"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Independent_Subcontractor_No"])) { objier.Independent_Subcontractor_No = Convert.ToString(reader["Independent_Subcontractor_No"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FK_Major_Class_Code"])) { objier.FK_Major_Class_Code = Convert.ToDecimal(reader["FK_Major_Class_Code"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Producer_Code"])) { objier.Producer_Code = Convert.ToDecimal(reader["Producer_Code"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Product_Liability_Recovery"])) { objier.Product_Liability_Recovery = Convert.ToDecimal(reader["Product_Liability_Recovery"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Product_Name"])) { objier.Product_Name = Convert.ToString(reader["Product_Name"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FK_Loss_Conditions_Act"])) { objier.FK_Loss_Conditions_Act = Convert.ToDecimal(reader["FK_Loss_Conditions_Act"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FK_Loss_Conditions_Recovery"])) { objier.FK_Loss_Conditions_Recovery = Convert.ToDecimal(reader["FK_Loss_Conditions_Recovery"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FK_Loss_Coverage_Code"])) { objier.FK_Loss_Coverage_Code = Convert.ToDecimal(reader["FK_Loss_Coverage_Code"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Lump_Sum_Remarriage_Payment"])) { objier.Lump_Sum_Remarriage_Payment = Convert.ToDecimal(reader["Lump_Sum_Remarriage_Payment"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Incurred_Loss"])) { objier.Incurred_Loss = Convert.ToDecimal(reader["Incurred_Loss"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Other_Benefit_Offset"])) { objier.Other_Benefit_Offset = Convert.ToString(reader["Other_Benefit_Offset"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Other_Medical_PTD"])) { objier.Other_Medical_PTD = Convert.ToDecimal(reader["Other_Medical_PTD"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Other_Voc_Rehab_PTD"])) { objier.Other_Voc_Rehab_PTD = Convert.ToDecimal(reader["Other_Voc_Rehab_PTD"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Penalties_PTD"])) { objier.Penalties_PTD = Convert.ToDecimal(reader["Penalties_PTD"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Pension_Indem_PTVD"])) { objier.Pension_Indem_PTVD = Convert.ToDecimal(reader["Pension_Indem_PTVD"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Pension_Reserved"])) { objier.Pension_Reserved = Convert.ToDecimal(reader["Pension_Reserved"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Pension_Offset"])) { objier.Pension_Offset = Convert.ToString(reader["Pension_Offset"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FK_State_Garage"])) { objier.FK_State_Garage = Convert.ToDecimal(reader["FK_State_Garage"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FK_Injury_Code"])) { objier.FK_Injury_Code = Convert.ToDecimal(reader["FK_Injury_Code"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FK_Property_Damage"])) { objier.FK_Property_Damage = Convert.ToDecimal(reader["FK_Property_Damage"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Recovery_Current_Month"])) { objier.Recovery_Current_Month = Convert.ToDecimal(reader["Recovery_Current_Month"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Recovery_To_Date"])) { objier.Recovery_To_Date = Convert.ToDecimal(reader["Recovery_To_Date"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Reserve_Type_Code"])) { objier.Reserve_Type_Code = Convert.ToDecimal(reader["Reserve_Type_Code"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Single_Sum_Paid_Date"])) { objier.Single_Sum_Paid_Date = Convert.ToDateTime(reader["Single_Sum_Paid_Date"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Single_Sum_Paid"])) { objier.Single_Sum_Paid = Convert.ToDecimal(reader["Single_Sum_Paid"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["SS_Benefit_Offset"])) { objier.SS_Benefit_Offset = Convert.ToString(reader["SS_Benefit_Offset"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["SS_Other_Amount"])) { objier.SS_Other_Amount = Convert.ToDecimal(reader["SS_Other_Amount"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Special_Fund_Offset"])) { objier.Special_Fund_Offset = Convert.ToString(reader["Special_Fund_Offset"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Symbol"])) { objier.Symbol = Convert.ToDecimal(reader["Symbol"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FK_State_Tax"])) { objier.FK_State_Tax = Convert.ToDecimal(reader["FK_State_Tax"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["TPA_Internal_Claim_Code"])) { objier.TPA_Internal_Claim_Code = Convert.ToString(reader["TPA_Internal_Claim_Code"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Temp_Indem_Incurred"])) { objier.Temp_Indem_Incurred = Convert.ToDecimal(reader["Temp_Indem_Incurred"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Temp_Indem_No_Weeks"])) { objier.Temp_Indem_No_Weeks = Convert.ToDecimal(reader["Temp_Indem_No_Weeks"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["T_E_Current_Month"])) { objier.T_E_Current_Month = Convert.ToDecimal(reader["T_E_Current_Month"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["T_E_To_Date"])) { objier.T_E_To_Date = Convert.ToDecimal(reader["T_E_To_Date"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Total_Gross_Incurred"])) { objier.Total_Gross_Incurred = Convert.ToDecimal(reader["Total_Gross_Incurred"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Total_Incurred_Voc_Rehab"])) { objier.Total_Incurred_Voc_Rehab = Convert.ToDecimal(reader["Total_Incurred_Voc_Rehab"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Total_Incurred_Voc_Rehab_Edu"])) { objier.Total_Incurred_Voc_Rehab_Edu = Convert.ToDecimal(reader["Total_Incurred_Voc_Rehab_Edu"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Total_Incurred_Voc_Rehab_Eval"])) { objier.Total_Incurred_Voc_Rehab_Eval = Convert.ToDecimal(reader["Total_Incurred_Voc_Rehab_Eval"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Total_Incurred_Voc_Rehab_Main"])) { objier.Total_Incurred_Voc_Rehab_Main = Convert.ToDecimal(reader["Total_Incurred_Voc_Rehab_Main"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Total_Payments_Phys"])) { objier.Total_Payments_Phys = Convert.ToDecimal(reader["Total_Payments_Phys"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Trans_Type"])) { objier.Trans_Type = Convert.ToDecimal(reader["Trans_Type"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Unemp_Benefit_Offset"])) { objier.Unemp_Benefit_Offset = Convert.ToString(reader["Unemp_Benefit_Offset"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Unique_Occur_Claim"])) { objier.Unique_Occur_Claim = Convert.ToString(reader["Unique_Occur_Claim"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Lump_Sum_Settlement"])) { objier.Lump_Sum_Settlement = Convert.ToDecimal(reader["Lump_Sum_Settlement"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Other_Recovery"])) { objier.Other_Recovery = Convert.ToDecimal(reader["Other_Recovery"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Other_Weekly_Pymnts"])) { objier.Other_Weekly_Pymnts = Convert.ToDecimal(reader["Other_Weekly_Pymnts"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Updated_By"])) { objier.Updated_By = Convert.ToString(reader["Updated_By"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Update_Date"])) { objier.Update_Date = Convert.ToDateTime(reader["Update_Date"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["WC_Cat_Number"])) { objier.WC_Cat_Number = Convert.ToDecimal(reader["WC_Cat_Number"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["WC_Indemnity_Payment"])) { objier.WC_Indemnity_Payment = Convert.ToDecimal(reader["WC_Indemnity_Payment"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Indemnity_Incurred"])) { objier.Indemnity_Incurred = Convert.ToDecimal(reader["Indemnity_Incurred"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Indemnity_Paid_Current"])) { objier.Indemnity_Paid_Current = Convert.ToDecimal(reader["Indemnity_Paid_Current"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Indemnity_PTD"])) { objier.Indemnity_PTD = Convert.ToDecimal(reader["Indemnity_PTD"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Medical_Incurred"])) { objier.Medical_Incurred = Convert.ToDecimal(reader["Medical_Incurred"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Medical_Paid_Current"])) { objier.Medical_Paid_Current = Convert.ToDecimal(reader["Medical_Paid_Current"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Medical_PTD"])) { objier.Medical_PTD = Convert.ToDecimal(reader["Medical_PTD"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Expense_Incurred"])) { objier.Expense_Incurred = Convert.ToDecimal(reader["Expense_Incurred"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Expense_Paid_Current"])) { objier.Expense_Paid_Current = Convert.ToDecimal(reader["Expense_Paid_Current"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Expense_PTD"])) { objier.Expense_PTD = Convert.ToDecimal(reader["Expense_PTD"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Controverted_Case"])) { objier.Controverted_Case = Convert.ToString(reader["Controverted_Case"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Deductible_Indicator"])) { objier.Deductible_Indicator = Convert.ToString(reader["Deductible_Indicator"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["AIG_Policy_Prefix"])) { objier.AIG_Policy_Prefix = Convert.ToString(reader["AIG_Policy_Prefix"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FK_AIG_Policy_Number"])) { objier.FK_AIG_Policy_Number = Convert.ToDecimal(reader["FK_AIG_Policy_Number"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FK_Loss_Conditions_Loss"])) { objier.FK_Loss_Conditions_Loss = Convert.ToDecimal(reader["FK_Loss_Conditions_Loss"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FK_Loss_Conditions_Settlement"])) { objier.FK_Loss_Conditions_Settlement = Convert.ToDecimal(reader["FK_Loss_Conditions_Settlement"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FK_Settlement_Method"])) { objier.FK_Settlement_Method = Convert.ToDecimal(reader["FK_Settlement_Method"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Legal_Representation"])) { objier.Legal_Representation = Convert.ToString(reader["Legal_Representation"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FK_Attorney_Form"])) { objier.FK_Attorney_Form = Convert.ToDecimal(reader["FK_Attorney_Form"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Deductible_Reimbursement"])) { objier.Deductible_Reimbursement = Convert.ToDecimal(reader["Deductible_Reimbursement"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Insurer_Reimbursed_Benifi_Payable_Claimant"])) { objier.Insurer_Reimbursed_Benifi_Payable_Claimant = Convert.ToString(reader["Insurer_Reimbursed_Benifi_Payable_Claimant"], CultureInfo.InvariantCulture); }
            return objier;
        }




    }


}

