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


    public class cSettlement : RIMS_Base.cSettlement
    {

        public override int InsertUpdate_settlement(RIMS_Base.cSettlement objsettlement)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            int nRetVal = -1;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Settlement_InsertUpdate");
                dbHelper.AddParameter(cmd, "@Pk_Settlement", DbType.Decimal, ParameterDirection.InputOutput, "Pk_Settlement", DataRowVersion.Current, objsettlement.Pk_Settlement);
                //dbHelper.AddInParameter(cmd, "@Claim_Number", DbType.String, objsettlement.Claim_Number);
                //dbHelper.AddInParameter(cmd, "@Table_Name", DbType.String, objsettlement.Table_Name);
                //dbHelper.AddInParameter(cmd, "@FK_Table_Name", DbType.Decimal, objsettlement.FK_Table_Name);
                //dbHelper.AddInParameter(cmd, "@DOB", DbType.DateTime, objsettlement.DOB);
                //dbHelper.AddInParameter(cmd, "@DOH", DbType.DateTime, objsettlement.DOH);
                //dbHelper.AddInParameter(cmd, "@Subsid", DbType.String, objsettlement.Subsid);
                //dbHelper.AddInParameter(cmd, "@Location", DbType.String, objsettlement.Location);
                //dbHelper.AddInParameter(cmd, "@Dept", DbType.String, objsettlement.Dept);
                //dbHelper.AddInParameter(cmd, "@JOB", DbType.String, objsettlement.JOB);
                //dbHelper.AddInParameter(cmd, "@Fk_State_of_Coverage", DbType.String, objsettlement.Fk_State_of_Coverage);
                //dbHelper.AddInParameter(cmd, "@FK_State_of_Accident", DbType.String, objsettlement.FK_State_of_Accident);
                //dbHelper.AddInParameter(cmd, "@DOI", DbType.DateTime, objsettlement.DOI);
                //dbHelper.AddInParameter(cmd, "@FK_Body_Parts", DbType.String, objsettlement.FK_Body_Parts);
                //dbHelper.AddInParameter(cmd, "@FK_Injury", DbType.String, objsettlement.FK_Injury);
                //dbHelper.AddInParameter(cmd, "@Description", DbType.String, objsettlement.Description);
                //dbHelper.AddInParameter(cmd, "@Treating_Physician", DbType.String, objsettlement.Treating_Physician);
                //dbHelper.AddInParameter(cmd, "@Diagnosis", DbType.String, objsettlement.Diagnosis);
                //dbHelper.AddInParameter(cmd, "@Last_Office_Visit_Date", DbType.DateTime, objsettlement.Last_Office_Visit_Date);
                //dbHelper.AddInParameter(cmd, "@Next_Scheduled_Visit", DbType.DateTime, objsettlement.Next_Scheduled_Visit);
                //dbHelper.AddInParameter(cmd, "@Referral", DbType.String, objsettlement.Referral);
                //dbHelper.AddInParameter(cmd, "@Treating_Physician_New", DbType.String, objsettlement.Treating_Physician_New);
                //dbHelper.AddInParameter(cmd, "@Physical_Therapy", DbType.String, objsettlement.Physical_Therapy);
                //dbHelper.AddInParameter(cmd, "@Surgery", DbType.String, objsettlement.Surgery);
                //dbHelper.AddInParameter(cmd, "@Off_Work", DbType.String, objsettlement.Off_Work);
                //dbHelper.AddInParameter(cmd, "@Estimated_RTW", DbType.String, objsettlement.Estimated_RTW);
                //dbHelper.AddInParameter(cmd, "@Return_to_Work_Ful_Duty", DbType.String, objsettlement.Return_to_Work_Ful_Duty);
                //dbHelper.AddInParameter(cmd, "@RTW_Date", DbType.DateTime, objsettlement.RTW_Date);
                //dbHelper.AddInParameter(cmd, "@Return_Work_Restricted_Duty", DbType.String, objsettlement.Return_Work_Restricted_Duty);
                //dbHelper.AddInParameter(cmd, "@Temporary_From", DbType.DateTime, objsettlement.Temporary_From);
                //dbHelper.AddInParameter(cmd, "@Temporary_to", DbType.DateTime, objsettlement.Temporary_to);
                //dbHelper.AddInParameter(cmd, "@Explain", DbType.String, objsettlement.Explain);
                //dbHelper.AddInParameter(cmd, "@Permanent_Fld", DbType.String, objsettlement.Permanent_Fld);
                //dbHelper.AddInParameter(cmd, "@Estimated_MMI", DbType.DateTime, objsettlement.Estimated_MMI);
                //dbHelper.AddInParameter(cmd, "@MMI", DbType.DateTime, objsettlement.MMI);
                //dbHelper.AddInParameter(cmd, "@Estimated_Impairment", DbType.Decimal, objsettlement.Estimated_Impairment);
                //dbHelper.AddInParameter(cmd, "@Actual_Impairment", DbType.Decimal, objsettlement.Actual_Impairment);
                //dbHelper.AddInParameter(cmd, "@Physicians_Panel_Requested", DbType.String, objsettlement.Physicians_Panel_Requested);
                //dbHelper.AddInParameter(cmd, "@New_TReating_Physician", DbType.String, objsettlement.New_TReating_Physician);
                //dbHelper.AddInParameter(cmd, "@Petition_Settlement", DbType.String, objsettlement.Petition_Settlement);
                //dbHelper.AddInParameter(cmd, "@Decree_and_Order", DbType.String, objsettlement.Decree_and_Order);
                //dbHelper.AddInParameter(cmd, "@Compromise", DbType.String, objsettlement.Compromise);
                //dbHelper.AddInParameter(cmd, "@Not_Applicable", DbType.String, objsettlement.Not_Applicable);
                //dbHelper.AddInParameter(cmd, "@No_Dispute", DbType.String, objsettlement.No_Dispute);
                dbHelper.AddInParameter(cmd, "@Status_Only", DbType.String, objsettlement.Status_Only);
                //dbHelper.AddInParameter(cmd, "@Classification", DbType.String, objsettlement.Classification);
                //dbHelper.AddInParameter(cmd, "@Defence_councils_Name", DbType.String, objsettlement.Defence_councils_Name);
                //dbHelper.AddInParameter(cmd, "@Phone", DbType.String, objsettlement.Phone);
                //dbHelper.AddInParameter(cmd, "@Claimant_Attorney", DbType.String, objsettlement.Claimant_Attorney);
                //dbHelper.AddInParameter(cmd, "@Phone1", DbType.String, objsettlement.Phone1);
                dbHelper.AddInParameter(cmd, "@Requested_Amount", DbType.Decimal, objsettlement.Requested_Amount);
                dbHelper.AddInParameter(cmd, "@Potential_Total_Exposure", DbType.Decimal, objsettlement.Potential_Total_Exposure);
                dbHelper.AddInParameter(cmd, "@Settled", DbType.String, objsettlement.Settled);
                dbHelper.AddInParameter(cmd, "@Amount", DbType.Decimal, objsettlement.Amount);
                dbHelper.AddInParameter(cmd, "@Location_Representative", DbType.DateTime, objsettlement.Location_Representative);
                dbHelper.AddInParameter(cmd, "@Claims_Manager", DbType.DateTime, objsettlement.Claims_Manager);
                dbHelper.AddInParameter(cmd, "@Risk_Manager", DbType.DateTime, objsettlement.Risk_Manager);
                dbHelper.AddInParameter(cmd, "@Treasury", DbType.DateTime, objsettlement.Treasury);
                dbHelper.AddInParameter(cmd, "@CFO", DbType.DateTime, objsettlement.CFO);
                //dbHelper.AddInParameter(cmd, "@Comments", DbType.String, objsettlement.Comments);
                dbHelper.AddInParameter(cmd, "@Updated_By", DbType.String, objsettlement.Updated_By);
                dbHelper.AddInParameter(cmd, "@Update_Date", DbType.DateTime, objsettlement.Update_Date);
                dbHelper.AddInParameter(cmd, "@Compensatiton", DbType.String, objsettlement.Compensatiton);
                dbHelper.AddInParameter(cmd, "@Reimbursement", DbType.String, objsettlement.Reimbursement);
                dbHelper.AddInParameter(cmd, "@Waive", DbType.String, objsettlement.Waive);
                dbHelper.AddInParameter(cmd, "@CloseMedicals", DbType.String, objsettlement.CloseMedicals);
                dbHelper.AddInParameter(cmd, "@Confidentiality", DbType.String, objsettlement.Confidentiality);
                dbHelper.AddInParameter(cmd, "@OtherMedicals", DbType.String, objsettlement.OtherMedicals);
                dbHelper.AddInParameter(cmd, "@PermanentTotal", DbType.String, objsettlement.PermanentTotal);
                dbHelper.AddInParameter(cmd, "@Resignation", DbType.String, objsettlement.Resignation);
                dbHelper.AddInParameter(cmd, "@Other", DbType.String, objsettlement.Other);
                //dbHelper.AddInParameter(cmd, "@Settlement_Method", DbType.String, objsettlement.Settlement_Method);
                //dbHelper.AddInParameter(cmd, "@FK_Method_Of_Settlement", DbType.String, objsettlement.FK_Method_Of_Settlement);
                dbHelper.AddInParameter(cmd, "@ResignationDate", DbType.DateTime, objsettlement.ResignationDate);
                dbHelper.ExecuteNonQuery(cmd);
                nRetVal = int.Parse(dbHelper.GetParameterValue(cmd, "@Pk_Settlement").ToString());

                return nRetVal;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            { dbHelper = null; cmd.Dispose(); cmd = null; }
        }
        public override int Delete_settlement(System.Decimal lPk_Settlement)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            int nRetVal = -1;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Set_Deletelement");
                dbHelper.AddInParameter(cmd, "@Pk_Settlement", DbType.Decimal, lPk_Settlement);
                nRetVal = dbHelper.ExecuteNonQuery(cmd);
                dbHelper = null; cmd.Dispose(); cmd = null;
                return nRetVal;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public override string ActivateInactivate_settlement(string strIDs, int intModifiedBy, bool bIsActive)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            int nRetVal = -1;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Set_ActivateInactivatelements");
                dbHelper.AddParameter(cmd, "@Pk_Settlements", DbType.String, ParameterDirection.InputOutput, "Pk_Settlements", DataRowVersion.Current, strIDs);
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
        public override List<RIMS_Base.cSettlement> GetAll(Boolean blnIsActive)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Set_Selectlement");
                dbHelper.AddInParameter(cmd, "@IsActive", DbType.Boolean, blnIsActive);
                IDataReader reader = dbHelper.ExecuteReader(cmd);
                List<RIMS_Base.cSettlement> results = new List<RIMS_Base.cSettlement>();
                while (reader.Read())
                {
                    cSettlement objsettlement = new cSettlement();
                    objsettlement = MapFrom(reader);
                    results.Add(objsettlement);
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
        public override List<RIMS_Base.cSettlement> GetsettlementByID(System.Decimal FK_Table_Name)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Settlement_SelectByID");
                dbHelper.AddInParameter(cmd, "@FK_Table_Name", DbType.Decimal, FK_Table_Name);

                IDataReader reader = dbHelper.ExecuteReader(cmd);
                List<RIMS_Base.cSettlement> result = new List<RIMS_Base.cSettlement>();
                cSettlement objsettlement = new cSettlement();
                if (reader.Read())
                {
                    objsettlement = MapFrom(reader);
                    result.Add(objsettlement);
                }
                reader.Close();
                cmd = null;
                dbHelper = null;
                return result;
                //return objsettlement;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public override DataSet GetSettlementLabel()
        {
            DbCommand cmd = null;
            DataSet dstDataset = null;
            Database dbHelper = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Get_Settlement_Label");
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

        protected RIMS_Base.Dal.cSettlement MapFrom(IDataReader reader)
        {
            RIMS_Base.Dal.cSettlement objsettlement = new RIMS_Base.Dal.cSettlement();
            if (!Convert.IsDBNull(reader["Pk_Settlement"])) { objsettlement.Pk_Settlement = Convert.ToDecimal(reader["Pk_Settlement"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Claim_Number"])) { objsettlement.Claim_Number = Convert.ToString(reader["Claim_Number"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Table_Name"])) { objsettlement.Table_Name = Convert.ToString(reader["Table_Name"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FK_Table_Name"])) { objsettlement.FK_Table_Name = Convert.ToDecimal(reader["FK_Table_Name"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["First_Name"])) { objsettlement.First_Name = Convert.ToString(reader["First_Name"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Last_Name"])) { objsettlement.Last_Name = Convert.ToString(reader["Last_Name"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["DOB"])) { objsettlement.DOB = Convert.ToDateTime(reader["DOB"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["DOH"])) { objsettlement.DOH = Convert.ToDateTime(reader["DOH"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Subsid"])) { objsettlement.Subsid = Convert.ToString(reader["Subsid"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Location"])) { objsettlement.Location = Convert.ToString(reader["Location"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Dept"])) { objsettlement.Dept = Convert.ToString(reader["Dept"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["JOB"])) { objsettlement.JOB = Convert.ToString(reader["JOB"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Fk_State_of_Coverage"])) { objsettlement.Fk_State_of_Coverage = Convert.ToString(reader["Fk_State_of_Coverage"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FK_State_of_Accident"])) { objsettlement.FK_State_of_Accident = Convert.ToString(reader["FK_State_of_Accident"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["DOI"])) { objsettlement.DOI = Convert.ToDateTime(reader["DOI"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FK_Body_Parts"])) { objsettlement.FK_Body_Parts = Convert.ToString(reader["FK_Body_Parts"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FK_Injury"])) { objsettlement.FK_Injury = Convert.ToString(reader["FK_Injury"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Description"])) { objsettlement.Description = Convert.ToString(reader["Description"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Treating_Physician"])) { objsettlement.Treating_Physician = Convert.ToString(reader["Treating_Physician"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Diagnosis"])) { objsettlement.Diagnosis = Convert.ToString(reader["Diagnosis"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Last_Office_Visit_Date"])) { objsettlement.Last_Office_Visit_Date = Convert.ToDateTime(reader["Last_Office_Visit_Date"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Next_Scheduled_Visit"])) { objsettlement.Next_Scheduled_Visit = Convert.ToDateTime(reader["Next_Scheduled_Visit"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Referral"])) { objsettlement.Referral = Convert.ToString(reader["Referral"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Treating_Physician_New"])) { objsettlement.Treating_Physician_New = Convert.ToString(reader["Treating_Physician_New"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Physical_Therapy"])) { objsettlement.Physical_Therapy = Convert.ToString(reader["Physical_Therapy"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Surgery"])) { objsettlement.Surgery = Convert.ToString(reader["Surgery"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Off_Work"])) { objsettlement.Off_Work = Convert.ToString(reader["Off_Work"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Estimated_RTW"])) { objsettlement.Estimated_RTW = Convert.ToString(reader["Estimated_RTW"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Return_to_Work_Ful_Duty"])) { objsettlement.Return_to_Work_Ful_Duty = Convert.ToString(reader["Return_to_Work_Ful_Duty"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["RTW_Date"])) { objsettlement.RTW_Date = Convert.ToDateTime(reader["RTW_Date"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Return_Work_Restricted_Duty"])) { objsettlement.Return_Work_Restricted_Duty = Convert.ToString(reader["Return_Work_Restricted_Duty"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Temporary_From"])) { objsettlement.Temporary_From = Convert.ToDateTime(reader["Temporary_From"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Temporary_to"])) { objsettlement.Temporary_to = Convert.ToDateTime(reader["Temporary_to"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Explain"])) { objsettlement.Explain = Convert.ToString(reader["Explain"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Permanent_Fld"])) { objsettlement.Permanent_Fld = Convert.ToString(reader["Permanent_Fld"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Estimated_MMI"])) { objsettlement.Estimated_MMI = Convert.ToDateTime(reader["Estimated_MMI"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["MMI"])) { objsettlement.MMI = Convert.ToDateTime(reader["MMI"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Estimated_Impairment"])) { objsettlement.Estimated_Impairment = Convert.ToDecimal(reader["Estimated_Impairment"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Actual_Impairment"])) { objsettlement.Actual_Impairment = Convert.ToDecimal(reader["Actual_Impairment"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Physicians_Panel_Requested"])) { objsettlement.Physicians_Panel_Requested = Convert.ToString(reader["Physicians_Panel_Requested"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["New_TReating_Physician"])) { objsettlement.New_TReating_Physician = Convert.ToString(reader["New_TReating_Physician"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Petition_Settlement"])) { objsettlement.Petition_Settlement = Convert.ToString(reader["Petition_Settlement"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Decree_and_Order"])) { objsettlement.Decree_and_Order = Convert.ToString(reader["Decree_and_Order"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Compromise"])) { objsettlement.Compromise = Convert.ToString(reader["Compromise"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Not_Applicable"])) { objsettlement.Not_Applicable = Convert.ToString(reader["Not_Applicable"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["No_Dispute"])) { objsettlement.No_Dispute = Convert.ToString(reader["No_Dispute"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Status_Only"])) { objsettlement.Status_Only = Convert.ToString(reader["Status_Only"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Classification"])) { objsettlement.Classification = Convert.ToString(reader["Classification"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Defence_councils_Name"])) { objsettlement.Defence_councils_Name = Convert.ToString(reader["Defence_councils_Name"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Phone"])) { objsettlement.Phone = Convert.ToString(reader["Phone"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Claimant_Attorney"])) { objsettlement.Claimant_Attorney = Convert.ToString(reader["Claimant_Attorney"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Phone1"])) { objsettlement.Phone1 = Convert.ToString(reader["Phone1"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Requested_Amount"])) { objsettlement.Requested_Amount = Convert.ToDecimal(reader["Requested_Amount"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Potential_Total_Exposure"])) { objsettlement.Potential_Total_Exposure = Convert.ToDecimal(reader["Potential_Total_Exposure"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Settled"])) { objsettlement.Settled = Convert.ToString(reader["Settled"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Amount"])) { objsettlement.Amount = Convert.ToDecimal(reader["Amount"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Location_Representative"])) { objsettlement.Location_Representative = Convert.ToDateTime(reader["Location_Representative"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Claims_Manager"])) { objsettlement.Claims_Manager = Convert.ToDateTime(reader["Claims_Manager"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Risk_Manager"])) { objsettlement.Risk_Manager = Convert.ToDateTime(reader["Risk_Manager"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Treasury"])) { objsettlement.Treasury = Convert.ToDateTime(reader["Treasury"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["CFO"])) { objsettlement.CFO = Convert.ToDateTime(reader["CFO"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["YComments"])) { objsettlement.YComments = Convert.ToString(reader["YComments"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["NComments"])) { objsettlement.NComments = Convert.ToString(reader["NComments"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Updated_By"])) { objsettlement.Updated_By = Convert.ToString(reader["Updated_By"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Update_Date"])) { objsettlement.Update_Date = Convert.ToDateTime(reader["Update_Date"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Compensatiton"])) { objsettlement.Compensatiton = Convert.ToString(reader["Compensatiton"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Reimbursement"])) { objsettlement.Reimbursement = Convert.ToString(reader["Reimbursement"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Waive"])) { objsettlement.Waive = Convert.ToString(reader["Waive"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["CloseMedicals"])) { objsettlement.CloseMedicals = Convert.ToString(reader["CloseMedicals"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Confidentiality"])) { objsettlement.Confidentiality = Convert.ToString(reader["Confidentiality"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["OtherMedicals"])) { objsettlement.OtherMedicals = Convert.ToString(reader["OtherMedicals"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["PermanentTotal"])) { objsettlement.PermanentTotal = Convert.ToString(reader["PermanentTotal"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Resignation"])) { objsettlement.Resignation = Convert.ToString(reader["Resignation"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Other"])) { objsettlement.Other = Convert.ToString(reader["Other"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Settlement_Method"])) { objsettlement.Settlement_Method = Convert.ToString(reader["Settlement_Method"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FK_Method_Of_Settlement"])) { objsettlement.FK_Method_Of_Settlement = Convert.ToString(reader["FK_Method_Of_Settlement"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["ResignationDate"])) { objsettlement.ResignationDate = Convert.ToDateTime(reader["ResignationDate"], CultureInfo.InvariantCulture); }
            return objsettlement;
        }




    }


}

