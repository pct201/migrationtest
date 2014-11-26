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
    public class cLiabilityReserveWorkHistory : RIMS_Base.cLiabilityReserveWorkHistory
    {
        public override int InsertUpdate_RWComp(RIMS_Base.cLiabilityReserveWorkHistory obj_WorkCompRW)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            int nRetVal = -1;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("LiabilityReserve_InsertUpdate");
                dbHelper.AddParameter(cmd, "@PK_Liability_Claim_RW_ID", DbType.Int32, ParameterDirection.InputOutput, "PK_Liability_Claim_RW_ID", DataRowVersion.Current, obj_WorkCompRW.PK_Liability_Claim_RW_ID);
                dbHelper.AddInParameter(cmd, "@FK_Liability_Claim", DbType.Decimal, obj_WorkCompRW.FK_Liability_Claim);
                dbHelper.AddInParameter(cmd, "@Transaction_Date", DbType.DateTime, obj_WorkCompRW.Transaction_Date);
                //dbHelper.AddInParameter(cmd, "@Hospital", DbType.Decimal, obj_WorkCompRW.Hospital);
                //dbHelper.AddInParameter(cmd, "@Physician", DbType.Decimal, obj_WorkCompRW.Physician);
                //dbHelper.AddInParameter(cmd, "@Radiology", DbType.Decimal, obj_WorkCompRW.Radiology);
                //dbHelper.AddInParameter(cmd, "@Pharmacy", DbType.Decimal, obj_WorkCompRW.Pharmacy);
                //dbHelper.AddInParameter(cmd, "@IME", DbType.Decimal, obj_WorkCompRW.IME);
                //dbHelper.AddInParameter(cmd, "@Anesthesiologist", DbType.Decimal, obj_WorkCompRW.Anesthesiologist);
                //dbHelper.AddInParameter(cmd, "@Nursing_Care", DbType.Decimal, obj_WorkCompRW.Nursing_Care);
                //dbHelper.AddInParameter(cmd, "@Transportation", DbType.Decimal, obj_WorkCompRW.Transportation);
                //dbHelper.AddInParameter(cmd, "@Medical_Report", DbType.Decimal, obj_WorkCompRW.Medical_Report);
                dbHelper.AddInParameter(cmd, "@Medical_Total", DbType.Decimal, obj_WorkCompRW.Medical_Total);
                //dbHelper.AddInParameter(cmd, "@TTD_Payment", DbType.Decimal, obj_WorkCompRW.TTD_Payment);
                //dbHelper.AddInParameter(cmd, "@TTD_Weeks", DbType.Decimal, obj_WorkCompRW.TTD_Weeks);
                //dbHelper.AddInParameter(cmd, "@TTD_Total", DbType.Decimal, obj_WorkCompRW.TTD_Total);
                //dbHelper.AddInParameter(cmd, "@TPD_Payment", DbType.Decimal, obj_WorkCompRW.TPD_Payment);
                //dbHelper.AddInParameter(cmd, "@TPD_Weeks", DbType.Decimal, obj_WorkCompRW.TPD_Weeks);
                //dbHelper.AddInParameter(cmd, "@TPD_Total", DbType.Decimal, obj_WorkCompRW.TPD_Total);
                //dbHelper.AddInParameter(cmd, "@Estimated_Award", DbType.Decimal, obj_WorkCompRW.Estimated_Award);
                //dbHelper.AddInParameter(cmd, "@Death_Benefit", DbType.Decimal, obj_WorkCompRW.Death_Benefit);
                //dbHelper.AddInParameter(cmd, "@Vocational_Rehab", DbType.Decimal, obj_WorkCompRW.Vocational_Rehab);
                //dbHelper.AddInParameter(cmd, "@Funeral_Expense", DbType.Decimal, obj_WorkCompRW.Funeral_Expense);
                //dbHelper.AddInParameter(cmd, "@Disability_Total", DbType.Decimal, obj_WorkCompRW.Disability_Total);
                //dbHelper.AddInParameter(cmd, "@Defense_Cost", DbType.Decimal, obj_WorkCompRW.Defense_Cost);
                //dbHelper.AddInParameter(cmd, "@Medical_Case_Management", DbType.Decimal, obj_WorkCompRW.Medical_Case_Management);
                //dbHelper.AddInParameter(cmd, "@Surveillance", DbType.Decimal, obj_WorkCompRW.Surveillance);
                //dbHelper.AddInParameter(cmd, "@Court_Costs", DbType.Decimal, obj_WorkCompRW.Court_Costs);
                //dbHelper.AddInParameter(cmd, "@Depositions", DbType.Decimal, obj_WorkCompRW.Depositions);
                //dbHelper.AddInParameter(cmd, "@Expense_Other_1_Description", DbType.String, obj_WorkCompRW.Expense_Other_1_Description);
                //dbHelper.AddInParameter(cmd, "@Expense_Other_1", DbType.Decimal, obj_WorkCompRW.Expense_Other_1);
                //dbHelper.AddInParameter(cmd, "@Expense_Other_2_Description", DbType.String, obj_WorkCompRW.Expense_Other_2_Description);
                //dbHelper.AddInParameter(cmd, "@Expense_Other_2", DbType.Decimal, obj_WorkCompRW.Expense_Other_2);
                //dbHelper.AddInParameter(cmd, "@Expense_Other_3_Description", DbType.String, obj_WorkCompRW.Expense_Other_3_Description);
                //dbHelper.AddInParameter(cmd, "@Expense_Other_3", DbType.Decimal, obj_WorkCompRW.Expense_Other_3);
                dbHelper.AddInParameter(cmd, "@Expenses_Total", DbType.Decimal, obj_WorkCompRW.Expenses_Total);
                // dbHelper.AddInParameter(cmd, "@Bill_Review", DbType.Decimal, obj_WorkCompRW.Bill_Review);
                dbHelper.AddInParameter(cmd, "@Updated_By", DbType.String, obj_WorkCompRW.Updated_By);
                dbHelper.AddInParameter(cmd, "@Update_Date", DbType.DateTime, obj_WorkCompRW.Update_Date);
                dbHelper.AddInParameter(cmd, "@Total", DbType.Decimal, obj_WorkCompRW.Total);
                dbHelper.AddInParameter(cmd, "@Indemnity_Total", DbType.Decimal, obj_WorkCompRW.Indemnity_Total);
                dbHelper.ExecuteNonQuery(cmd);
                nRetVal = int.Parse(dbHelper.GetParameterValue(cmd, "@PK_Liability_Claim_RW_ID").ToString());
                return nRetVal;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            { dbHelper = null; cmd.Dispose(); cmd = null; }
        }
        public override int Delete_RWComp(System.String lPK_Liability_Claim_RW_ID)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            int nRetVal = -1;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("LiabilityReserve_Delete");
                dbHelper.AddInParameter(cmd, "@PK_Liability_Claim_RW_ID", DbType.String, lPK_Liability_Claim_RW_ID);
                nRetVal = dbHelper.ExecuteNonQuery(cmd);
                dbHelper = null; cmd.Dispose(); cmd = null;
                return nRetVal;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public override string ActivateInactivate_RWComp(string strIDs, int intModifiedBy, bool bIsActive)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            int nRetVal = -1;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Wor_ActivateInactivateers_Comp_RWs");
                dbHelper.AddParameter(cmd, "@PK_Workers_Comp_RW_IDs", DbType.String, ParameterDirection.InputOutput, "PK_Workers_Comp_RW_IDs", DataRowVersion.Current, strIDs);
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
        public override List<RIMS_Base.cLiabilityReserveWorkHistory> GetAll(Boolean blnIsActive)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("WorkerCompReserve_Select");
                dbHelper.AddInParameter(cmd, "@IsActive", DbType.Boolean, blnIsActive);
                IDataReader reader = dbHelper.ExecuteReader(cmd);
                List<RIMS_Base.cLiabilityReserveWorkHistory> results = new List<RIMS_Base.cLiabilityReserveWorkHistory>();
                while (reader.Read())
                {
                    cLiabilityReserveWorkHistory obj_WorkCompRW = new cLiabilityReserveWorkHistory();
                    obj_WorkCompRW = MapFrom(reader);
                    results.Add(obj_WorkCompRW);
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

        public override List<RIMS_Base.cLiabilityReserveWorkHistory> Workers_Comp_RWRecords(System.Decimal Liability_Claim_RW_ID)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("LiabilityReserve_Records");
                dbHelper.AddInParameter(cmd, "@PK_Liability_Claim_RW_ID", DbType.Decimal, Liability_Claim_RW_ID);
                IDataReader reader = dbHelper.ExecuteReader(cmd);
                List<RIMS_Base.cLiabilityReserveWorkHistory> results = new List<RIMS_Base.cLiabilityReserveWorkHistory>();
                while (reader.Read())
                {
                    cLiabilityReserveWorkHistory obj_WorkCompRW = new cLiabilityReserveWorkHistory();
                    obj_WorkCompRW = MapFrom(reader);
                    results.Add(obj_WorkCompRW);
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
        public override List<RIMS_Base.cLiabilityReserveWorkHistory> Workers_Comp_RWRecords_OutStand(decimal Liability_Claim_RW_ID)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("LiabilityReserve_Records_OutStand");
                dbHelper.AddInParameter(cmd, "@PK_Liability_Claim_RW_ID", DbType.Decimal, Liability_Claim_RW_ID);
                IDataReader reader = dbHelper.ExecuteReader(cmd);
                List<RIMS_Base.cLiabilityReserveWorkHistory> results = new List<RIMS_Base.cLiabilityReserveWorkHistory>();
                while (reader.Read())
                {
                    cLiabilityReserveWorkHistory obj_WorkCompRW = new cLiabilityReserveWorkHistory();
                    obj_WorkCompRW = MapFrom(reader);
                    results.Add(obj_WorkCompRW);
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
        public override List<RIMS_Base.cLiabilityReserveWorkHistory> Geters_Comp_RWByID(System.Decimal Liability_Claim_RW_ID)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("LiabilityReserve_Select");
                dbHelper.AddInParameter(cmd, "@PK_Liability_Claim_RW_ID", DbType.Decimal, Liability_Claim_RW_ID);
                dbHelper.AddInParameter(cmd, "@IsActive", DbType.Boolean, true);
                List<RIMS_Base.cLiabilityReserveWorkHistory> results = new List<RIMS_Base.cLiabilityReserveWorkHistory>();
                IDataReader reader = dbHelper.ExecuteReader(cmd);
                cLiabilityReserveWorkHistory obj_WorkCompRW = new cLiabilityReserveWorkHistory();
                if (reader.Read())
                {
                    obj_WorkCompRW = MapFrom(reader);
                    results.Add(obj_WorkCompRW);
                }
                reader.Close();
                cmd = null;
                dbHelper = null;

                //return obj_WorkCompRW;
                return results;
            }
            catch (Exception)
            {
                throw;
            }
        }
        // For Payment Details
        public override System.Data.DataSet GetPaymentRecords(System.Decimal Liability_Claim_RW_ID)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            DataSet m_dsProperty = new DataSet();
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("LiabilityReserve_PaymentDetails");
                dbHelper.AddInParameter(cmd, "@FK_Liability_Claim", DbType.Decimal, Liability_Claim_RW_ID);
                m_dsProperty = dbHelper.ExecuteDataSet(cmd);
                cmd = null;
                dbHelper = null;

                return m_dsProperty;
            }
            catch (Exception)
            {
                throw;
            }
            // WorkerCompReserve_PaymentDetails
        }

        protected RIMS_Base.Dal.cLiabilityReserveWorkHistory MapFrom(IDataReader reader)
        {
            RIMS_Base.Dal.cLiabilityReserveWorkHistory obj_WorkCompRW = new RIMS_Base.Dal.cLiabilityReserveWorkHistory();
            if (!Convert.IsDBNull(reader["PK_Liability_Claim_RW_ID"])) { obj_WorkCompRW.PK_Liability_Claim_RW_ID = Convert.ToInt32(reader["PK_Liability_Claim_RW_ID"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FK_Liability_Claim"])) { obj_WorkCompRW.FK_Liability_Claim = Convert.ToDecimal(reader["FK_Liability_Claim"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Transaction_Date"])) { obj_WorkCompRW.Transaction_Date = Convert.ToDateTime(reader["Transaction_Date"], CultureInfo.InvariantCulture); }
            //if (!Convert.IsDBNull(reader["Hospital"])) { obj_WorkCompRW.Hospital = Convert.ToDecimal(reader["Hospital"], CultureInfo.InvariantCulture); }
            //if (!Convert.IsDBNull(reader["Physician"])) { obj_WorkCompRW.Physician = Convert.ToDecimal(reader["Physician"], CultureInfo.InvariantCulture); }
            //if (!Convert.IsDBNull(reader["Radiology"])) { obj_WorkCompRW.Radiology = Convert.ToDecimal(reader["Radiology"], CultureInfo.InvariantCulture); }
            //if (!Convert.IsDBNull(reader["Pharmacy"])) { obj_WorkCompRW.Pharmacy = Convert.ToDecimal(reader["Pharmacy"], CultureInfo.InvariantCulture); }
            //if (!Convert.IsDBNull(reader["IME"])) { obj_WorkCompRW.IME = Convert.ToDecimal(reader["IME"], CultureInfo.InvariantCulture); }
            //if (!Convert.IsDBNull(reader["Anesthesiologist"])) { obj_WorkCompRW.Anesthesiologist = Convert.ToDecimal(reader["Anesthesiologist"], CultureInfo.InvariantCulture); }
            //if (!Convert.IsDBNull(reader["Nursing_Care"])) { obj_WorkCompRW.Nursing_Care = Convert.ToDecimal(reader["Nursing_Care"], CultureInfo.InvariantCulture); }
            //if (!Convert.IsDBNull(reader["Transportation"])) { obj_WorkCompRW.Transportation = Convert.ToDecimal(reader["Transportation"], CultureInfo.InvariantCulture); }
            //if (!Convert.IsDBNull(reader["Medical_Report"])) { obj_WorkCompRW.Medical_Report = Convert.ToDecimal(reader["Medical_Report"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Medical_Total"])) { obj_WorkCompRW.Medical_Total = Convert.ToDecimal(reader["Medical_Total"], CultureInfo.InvariantCulture); }
            //if (!Convert.IsDBNull(reader["TTD_Payment"])) { obj_WorkCompRW.TTD_Payment = Convert.ToDecimal(reader["TTD_Payment"], CultureInfo.InvariantCulture); }
            //if (!Convert.IsDBNull(reader["TTD_Weeks"])) { obj_WorkCompRW.TTD_Weeks = Convert.ToDecimal(reader["TTD_Weeks"], CultureInfo.InvariantCulture); }
            //if (!Convert.IsDBNull(reader["TTD_Total"])) { obj_WorkCompRW.TTD_Total = Convert.ToDecimal(reader["TTD_Total"], CultureInfo.InvariantCulture); }
            //if (!Convert.IsDBNull(reader["TPD_Payment"])) { obj_WorkCompRW.TPD_Payment = Convert.ToDecimal(reader["TPD_Payment"], CultureInfo.InvariantCulture); }
            //if (!Convert.IsDBNull(reader["TPD_Weeks"])) { obj_WorkCompRW.TPD_Weeks = Convert.ToDecimal(reader["TPD_Weeks"], CultureInfo.InvariantCulture); }
            //if (!Convert.IsDBNull(reader["TPD_Total"])) { obj_WorkCompRW.TPD_Total = Convert.ToDecimal(reader["TPD_Total"], CultureInfo.InvariantCulture); }
            //if (!Convert.IsDBNull(reader["Estimated_Award"])) { obj_WorkCompRW.Estimated_Award = Convert.ToDecimal(reader["Estimated_Award"], CultureInfo.InvariantCulture); }
            //if (!Convert.IsDBNull(reader["Death_Benefit"])) { obj_WorkCompRW.Death_Benefit = Convert.ToDecimal(reader["Death_Benefit"], CultureInfo.InvariantCulture); }
            //if (!Convert.IsDBNull(reader["Vocational_Rehab"])) { obj_WorkCompRW.Vocational_Rehab = Convert.ToDecimal(reader["Vocational_Rehab"], CultureInfo.InvariantCulture); }
            //if (!Convert.IsDBNull(reader["Funeral_Expense"])) { obj_WorkCompRW.Funeral_Expense = Convert.ToDecimal(reader["Funeral_Expense"], CultureInfo.InvariantCulture); }
            //if (!Convert.IsDBNull(reader["Disability_Total"])) { obj_WorkCompRW.Disability_Total = Convert.ToDecimal(reader["Disability_Total"], CultureInfo.InvariantCulture); }
            //if (!Convert.IsDBNull(reader["Defense_Cost"])) { obj_WorkCompRW.Defense_Cost = Convert.ToDecimal(reader["Defense_Cost"], CultureInfo.InvariantCulture); }
            //if (!Convert.IsDBNull(reader["Medical_Case_Management"])) { obj_WorkCompRW.Medical_Case_Management = Convert.ToDecimal(reader["Medical_Case_Management"], CultureInfo.InvariantCulture); }
            //if (!Convert.IsDBNull(reader["Surveillance"])) { obj_WorkCompRW.Surveillance = Convert.ToDecimal(reader["Surveillance"], CultureInfo.InvariantCulture); }
            //if (!Convert.IsDBNull(reader["Court_Costs"])) { obj_WorkCompRW.Court_Costs = Convert.ToDecimal(reader["Court_Costs"], CultureInfo.InvariantCulture); }
            //if (!Convert.IsDBNull(reader["Depositions"])) { obj_WorkCompRW.Depositions = Convert.ToDecimal(reader["Depositions"], CultureInfo.InvariantCulture); }
            //if (!Convert.IsDBNull(reader["Expense_Other_1_Description"])) { obj_WorkCompRW.Expense_Other_1_Description = Convert.ToString(reader["Expense_Other_1_Description"], CultureInfo.InvariantCulture); }
            //if (!Convert.IsDBNull(reader["Expense_Other_1"])) { obj_WorkCompRW.Expense_Other_1 = Convert.ToDecimal(reader["Expense_Other_1"], CultureInfo.InvariantCulture); }
            //if (!Convert.IsDBNull(reader["Expense_Other_2_Description"])) { obj_WorkCompRW.Expense_Other_2_Description = Convert.ToString(reader["Expense_Other_2_Description"], CultureInfo.InvariantCulture); }
            //if (!Convert.IsDBNull(reader["Expense_Other_2"])) { obj_WorkCompRW.Expense_Other_2 = Convert.ToDecimal(reader["Expense_Other_2"], CultureInfo.InvariantCulture); }
            //if (!Convert.IsDBNull(reader["Expense_Other_3_Description"])) { obj_WorkCompRW.Expense_Other_3_Description = Convert.ToString(reader["Expense_Other_3_Description"], CultureInfo.InvariantCulture); }
            //if (!Convert.IsDBNull(reader["Expense_Other_3"])) { obj_WorkCompRW.Expense_Other_3 = Convert.ToDecimal(reader["Expense_Other_3"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Expenses_Total"])) { obj_WorkCompRW.Expenses_Total = Convert.ToDecimal(reader["Expenses_Total"], CultureInfo.InvariantCulture); }
            // if (!Convert.IsDBNull(reader["Bill_Review"])) { obj_WorkCompRW.Bill_Review = Convert.ToDecimal(reader["Bill_Review"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Updated_By"])) { obj_WorkCompRW.Updated_By = Convert.ToString(reader["Updated_By"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Update_Date"])) { obj_WorkCompRW.Update_Date = Convert.ToDateTime(reader["Update_Date"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Indemnity_Total"])) { obj_WorkCompRW.Indemnity_Total = Convert.ToDecimal(reader["Indemnity_Total"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Total"])) { obj_WorkCompRW.Total = Convert.ToDecimal(reader["Total"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["LTotal"])) { obj_WorkCompRW.LTotal = Convert.ToDecimal(reader["LTotal"], CultureInfo.InvariantCulture); }

            return obj_WorkCompRW;
        }

        //For Claim info
        public override List<RIMS_Base.cLiabilityReserveWorkHistory> GetClaimInfoByClaimNo(string m_strClaimNo)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("CheckWriting_GetClaimInfoByClaimNo");
                dbHelper.AddInParameter(cmd, "@Claim_Number", DbType.String, m_strClaimNo);
                IDataReader reader = dbHelper.ExecuteReader(cmd);
                List<RIMS_Base.cLiabilityReserveWorkHistory> results = new List<RIMS_Base.cLiabilityReserveWorkHistory>();
                while (reader.Read())
                {
                    cLiabilityReserveWorkHistory objk_Writing = new cLiabilityReserveWorkHistory();
                    objk_Writing = MapFromClaimInfo(reader);
                    results.Add(objk_Writing);
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
        protected RIMS_Base.Dal.cLiabilityReserveWorkHistory MapFromClaimInfo(IDataReader reader)
        {
            RIMS_Base.Dal.cLiabilityReserveWorkHistory objk_Writing = new RIMS_Base.Dal.cLiabilityReserveWorkHistory();
            if (!Convert.IsDBNull(reader["tblName"])) { objk_Writing.TableName = Convert.ToString(reader["tblName"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["tblFK"])) { objk_Writing.TableFK = Convert.ToInt32(reader["tblFK"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["claim_number"])) { objk_Writing.Claim_Number = Convert.ToString(reader["claim_number"], CultureInfo.InvariantCulture); }

           // if (!Convert.IsDBNull(reader["Fk_ECD_Id"])) { objk_Writing.Fk_ECD_Id = Convert.ToDecimal(reader["Fk_ECD_Id"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FK_Claimant_id"])) { objk_Writing.FK_Claimant_id = Convert.ToDecimal(reader["FK_Claimant_id"], CultureInfo.InvariantCulture); }
	

            //if (!Convert.IsDBNull(reader["employee"])) { objk_Writing.Employee = Convert.ToString(reader["employee"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Last_name"])) { objk_Writing.LastName = Convert.ToString(reader["Last_name"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["first_name"])) { objk_Writing.FirstName = Convert.ToString(reader["first_name"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["middle_name"])) { objk_Writing.MiddleName = Convert.ToString(reader["middle_name"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Date_Of_Loss"])) { objk_Writing.Date_Of_Loss = Convert.ToDateTime(reader["Date_Of_Loss"], CultureInfo.InvariantCulture); }
          // if (!Convert.IsDBNull(reader["FK_Employee_Claimant"])) { objk_Writing.Employee_Claimant = Convert.ToInt32(reader["FK_Employee_Claimant"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["INDEMNITY_outstanding"])) { objk_Writing.Outstanding_INDEMNITY = Convert.ToDecimal(reader["INDEMNITY_outstanding"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Medical_outstanding"])) { objk_Writing.Outstanding_Medical = Convert.ToDecimal(reader["Medical_outstanding"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Expense_outstanding"])) { objk_Writing.Outstanding_Expense = Convert.ToDecimal(reader["Expense_outstanding"], CultureInfo.InvariantCulture); }
            return objk_Writing;
        }

        public override DataSet GetLiabilityReserveLabel()
        {
            DbCommand cmd = null;
            DataSet dstDataset = null;
            Database dbHelper = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Get_LiabilityReserve_Label");
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


        //public override List<RIMS_Base.cLiabilityReserveWorkHistory> GetClaimInfoByClaimNo(string m_strClaimNo)
        //{
        //    Database dbHelper = null;
        //    DbCommand cmd = null;
        //    try
        //    {
        //        dbHelper = DatabaseFactory.CreateDatabase();
        //        cmd = dbHelper.GetStoredProcCommand("CheckWriting_GetClaimInfoByClaimNo");
        //        dbHelper.AddInParameter(cmd, "@Claim_Number", DbType.String, m_strClaimNo);
        //        IDataReader reader = dbHelper.ExecuteReader(cmd);
        //        List<RIMS_Base.cLiabilityReserveWorkHistory> results = new List<RIMS_Base.cLiabilityReserveWorkHistory>();
        //        while (reader.Read())
        //        {
        //            cLiabilityReserveWorkHistory objk_Writing = new cLiabilityReserveWorkHistory();
        //            objk_Writing = MapFromClaimInfo(reader);
        //            results.Add(objk_Writing);
        //        }
        //        reader.Close();
        //        cmd = null;
        //        dbHelper = null;
        //        return results;
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}
        //protected RIMS_Base.Dal.cLiabilityReserveWorkHistory MapFromClaimInfo(IDataReader reader)
        //{
        //    RIMS_Base.Dal.cLiabilityReserveWorkHistory objk_Writing = new RIMS_Base.Dal.cLiabilityReserveWorkHistory();
        //    if (!Convert.IsDBNull(reader["tblName"])) { objk_Writing.TableName = Convert.ToString(reader["tblName"], CultureInfo.InvariantCulture); }
        //    if (!Convert.IsDBNull(reader["tblFK"])) { objk_Writing.TableFK = Convert.ToInt32(reader["tblFK"], CultureInfo.InvariantCulture); }
        //    if (!Convert.IsDBNull(reader["claim_number"])) { objk_Writing.Claim_Number = Convert.ToString(reader["claim_number"], CultureInfo.InvariantCulture); }
        //    if (!Convert.IsDBNull(reader["employee"])) { objk_Writing.Employee = Convert.ToString(reader["employee"], CultureInfo.InvariantCulture); }
        //    if (!Convert.IsDBNull(reader["Last_name"])) { objk_Writing.LastName = Convert.ToString(reader["Last_name"], CultureInfo.InvariantCulture); }
        //    if (!Convert.IsDBNull(reader["first_name"])) { objk_Writing.FirstName = Convert.ToString(reader["first_name"], CultureInfo.InvariantCulture); }
        //    if (!Convert.IsDBNull(reader["middle_name"])) { objk_Writing.MiddleName = Convert.ToString(reader["middle_name"], CultureInfo.InvariantCulture); }
        //    if (!Convert.IsDBNull(reader["Incident_Date"])) { objk_Writing.IncidentDate = Convert.ToString(reader["Incident_Date"], CultureInfo.InvariantCulture); }
        //    if (!Convert.IsDBNull(reader["FK_Employee_Claimant"])) { objk_Writing.Employee_Claimant = Convert.ToInt32(reader["FK_Employee_Claimant"], CultureInfo.InvariantCulture); }
        //    if (!Convert.IsDBNull(reader["INDEMNITY_outstanding"])) { objk_Writing.Outstanding_INDEMNITY = Convert.ToDecimal(reader["INDEMNITY_outstanding"], CultureInfo.InvariantCulture); }
        //    if (!Convert.IsDBNull(reader["Medical_outstanding"])) { objk_Writing.Outstanding_Medical = Convert.ToDecimal(reader["Medical_outstanding"], CultureInfo.InvariantCulture); }
        //    if (!Convert.IsDBNull(reader["Expense_outstanding"])) { objk_Writing.Outstanding_Expense = Convert.ToDecimal(reader["Expense_outstanding"], CultureInfo.InvariantCulture); }
        //    return objk_Writing;
        //}


    }
}
