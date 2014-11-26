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


    public class CCheckDetails : RIMS_Base.CCheckDetails
    {

        public override int InsertUpdate_CheckDetails(RIMS_Base.CCheckDetails Objk_details)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            int nRetVal = -1;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("CheckDetails_InsertUpdate");
                dbHelper.AddParameter(cmd, "@pk_check_no", DbType.Int64, ParameterDirection.InputOutput, "pk_check_no", DataRowVersion.Current, Objk_details.Pk_check_no);
                dbHelper.AddInParameter(cmd, "@check_Amount", DbType.Decimal, Objk_details.Check_Amount);
                dbHelper.AddInParameter(cmd, "@Current_Recurring_Number", DbType.Decimal, Objk_details.Current_Recurring_Number);
                dbHelper.AddInParameter(cmd, "@Original_Recurring", DbType.String, Objk_details.Original_Recurring);
                dbHelper.AddInParameter(cmd, "@Check_FK", DbType.Decimal, Objk_details.Check_FK);
                dbHelper.AddInParameter(cmd, "@Updated_By", DbType.String, Objk_details.Updated_By);
                dbHelper.AddInParameter(cmd, "@Updated_Date", DbType.DateTime, Objk_details.Updated_Date);
                dbHelper.AddInParameter(cmd, "@Due_Date", DbType.DateTime, Objk_details.Due_Date);
                dbHelper.AddInParameter(cmd, "@check_status", DbType.String, Objk_details.Check_status);
                dbHelper.AddInParameter(cmd, "@Printed_check", DbType.String, Objk_details.Printed_check);
                dbHelper.AddInParameter(cmd, "@Stop_Delete_Date", DbType.DateTime, Objk_details.Stop_Delete_Date);
                dbHelper.AddInParameter(cmd, "@printed_date", DbType.DateTime, Objk_details.Printed_date);
                dbHelper.AddInParameter(cmd, "@printed_by", DbType.String, Objk_details.Printed_by);
                dbHelper.AddInParameter(cmd, "@Void_Status", DbType.String, Objk_details.Void_Status);
                dbHelper.AddInParameter(cmd, "@Stop_Payment", DbType.String, Objk_details.Stop_Payment);
                dbHelper.AddInParameter(cmd, "@Rec_Issue_Date", DbType.String, Objk_details.RecIssueDate);
                dbHelper.AddInParameter(cmd, "@Check_Number", DbType.Decimal, Objk_details.CDCheckNumber);
                dbHelper.ExecuteNonQuery(cmd);
                nRetVal = int.Parse(dbHelper.GetParameterValue(cmd, "@pk_check_no").ToString());

                return nRetVal;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            { dbHelper = null; cmd.Dispose(); cmd = null; }
        }
        public override int Delete_CheckDetails(System.String lpk_check_no)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            int nRetVal = -1;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("CheckDetails_Delete");
                dbHelper.AddInParameter(cmd, "@pk_check_no", DbType.String, lpk_check_no);
                nRetVal = dbHelper.ExecuteNonQuery(cmd);
                dbHelper = null; cmd.Dispose(); cmd = null;
                return nRetVal;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public override string ActivateInactivate_CheckDetails(string strIDs, int intModifiedBy, bool bIsActive)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            int nRetVal = -1;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("CheckDetails_ActivateInactivate");
                dbHelper.AddParameter(cmd, "@pk_check_nos", DbType.String, ParameterDirection.InputOutput, "pk_check_nos", DataRowVersion.Current, strIDs);
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
        public override List<RIMS_Base.CCheckDetails> GetAll()
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("CheckDetails_SelectCheckDetails");

                IDataReader reader = dbHelper.ExecuteReader(cmd);
                List<RIMS_Base.CCheckDetails> results = new List<RIMS_Base.CCheckDetails>();
                while (reader.Read())
                {
                    CCheckDetails objk_details = new CCheckDetails();
                    objk_details = MapFrom(reader);
                    results.Add(objk_details);
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


        public override RIMS_Base.CCheckDetails GetCheckDetailsByID(System.Decimal pk_check_no)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("CheckDetails_SelectCheckDetails");
                dbHelper.AddInParameter(cmd, "@pk_check_no", DbType.Decimal, pk_check_no);

                IDataReader reader = dbHelper.ExecuteReader(cmd);
                CCheckDetails objk_details = new CCheckDetails();
                if (reader.Read())
                {
                    objk_details = MapFrom(reader);
                }
                reader.Close();
                cmd = null;
                dbHelper = null;

                return objk_details;
            }
            catch (Exception)
            {
                throw;
            }
        }


        protected RIMS_Base.Dal.CCheckDetails MapFrom(IDataReader reader)
        {
            RIMS_Base.Dal.CCheckDetails objk_details = new RIMS_Base.Dal.CCheckDetails();
            if (!Convert.IsDBNull(reader["pk_check_no"])) { objk_details.Pk_check_no = Convert.ToInt64(reader["pk_check_no"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["check_Amount"])) { objk_details.Check_Amount = Convert.ToDecimal(reader["check_Amount"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Current_Recurring_Number"])) { objk_details.Current_Recurring_Number = Convert.ToDecimal(reader["Current_Recurring_Number"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Original_Recurring"])) { objk_details.Original_Recurring = Convert.ToString(reader["Original_Recurring"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Check_FK"])) { objk_details.Check_FK = Convert.ToDecimal(reader["Check_FK"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Updated_By"])) { objk_details.Updated_By = Convert.ToString(reader["Updated_By"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Updated_Date"])) { objk_details.Updated_Date = Convert.ToDateTime(reader["Updated_Date"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Due_Date"])) { objk_details.Due_Date = Convert.ToDateTime(reader["Due_Date"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["check_status"])) { objk_details.Check_status = Convert.ToString(reader["check_status"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Printed_check"])) { objk_details.Printed_check = Convert.ToString(reader["Printed_check"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Stop_Delete_Date"])) { objk_details.Stop_Delete_Date = Convert.ToDateTime(reader["Stop_Delete_Date"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["printed_date"])) { objk_details.Printed_date = Convert.ToDateTime(reader["printed_date"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["printed_by"])) { objk_details.Printed_by = Convert.ToString(reader["printed_by"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Void_Status"])) { objk_details.Void_Status = Convert.ToString(reader["Void_Status"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Stop_Payment"])) { objk_details.Stop_Payment = Convert.ToString(reader["Stop_Payment"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Rec_Issue_Date"])) { objk_details.RecIssueDate = Convert.ToDateTime(reader["Rec_Issue_Date"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Check_Number"])) { objk_details.CDCheckNumber = Convert.ToDecimal(reader["Check_Number"], CultureInfo.InvariantCulture); }
            return objk_details;
        }
        public override List<RIMS_Base.CCheckDetails> GetCDAEP(System.Decimal pk_check_no)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("CheckWriting_Generated_Check");
                dbHelper.AddInParameter(cmd, "@Check_FK", DbType.Decimal, pk_check_no);

                IDataReader reader = dbHelper.ExecuteReader(cmd);
                List<RIMS_Base.CCheckDetails> results = new List<RIMS_Base.CCheckDetails>();
                while (reader.Read())
                {
                    CCheckDetails objk_details = new CCheckDetails();
                    objk_details = MapFromCDAEP(reader);
                    results.Add(objk_details);
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
        protected RIMS_Base.Dal.CCheckDetails MapFromCDAEP(IDataReader reader)
        {
            RIMS_Base.Dal.CCheckDetails objk_details = new RIMS_Base.Dal.CCheckDetails();
            if (!Convert.IsDBNull(reader["Rec_Issue_Date"])) { objk_details.RecIssueDate = Convert.ToDateTime(reader["Rec_Issue_Date"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Check_number"])) { objk_details.Pk_check_no = Convert.ToInt64(reader["Check_number"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FLD_Desc"])) { objk_details.AEPPaymentID = Convert.ToString(reader["FLD_Desc"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Service_Begin"])) { objk_details.AEPDtServiceBegin = Convert.ToDateTime(reader["Service_Begin"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Service_End"])) { objk_details.AEPDtServiceEnd = Convert.ToDateTime(reader["Service_End"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Invoice_Number"])) { objk_details.AEPInvoiceNo = Convert.ToString(reader["Invoice_Number"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Current_Recurring_Number"])) { objk_details.Current_Recurring_Number = Convert.ToDecimal(reader["Current_Recurring_Number"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["check_Amount"])) { objk_details.Check_Amount = Convert.ToDecimal(reader["check_Amount"], CultureInfo.InvariantCulture); }
            //if (!Convert.IsDBNull(reader["Check_FK"])) { objk_details.Check_FK = Convert.ToDecimal(reader["Check_FK"], CultureInfo.InvariantCulture); }
            //if (!Convert.IsDBNull(reader["Updated_By"])) { objk_details.Updated_By = Convert.ToString(reader["Updated_By"], CultureInfo.InvariantCulture); }
            //if (!Convert.IsDBNull(reader["Updated_Date"])) { objk_details.Updated_Date = Convert.ToDateTime(reader["Updated_Date"], CultureInfo.InvariantCulture); }
            //if (!Convert.IsDBNull(reader["Due_Date"])) { objk_details.Due_Date = Convert.ToDateTime(reader["Due_Date"], CultureInfo.InvariantCulture); }
            //if (!Convert.IsDBNull(reader["check_status"])) { objk_details.Check_status = Convert.ToString(reader["check_status"], CultureInfo.InvariantCulture); }
            //if (!Convert.IsDBNull(reader["Printed_check"])) { objk_details.Printed_check = Convert.ToString(reader["Printed_check"], CultureInfo.InvariantCulture); }
            //if (!Convert.IsDBNull(reader["Stop_Delete_Date"])) { objk_details.Stop_Delete_Date = Convert.ToDateTime(reader["Stop_Delete_Date"], CultureInfo.InvariantCulture); }
            //if (!Convert.IsDBNull(reader["printed_date"])) { objk_details.Printed_date = Convert.ToDateTime(reader["printed_date"], CultureInfo.InvariantCulture); }
            //if (!Convert.IsDBNull(reader["printed_by"])) { objk_details.Printed_by = Convert.ToString(reader["printed_by"], CultureInfo.InvariantCulture); }
            //if (!Convert.IsDBNull(reader["Void_Status"])) { objk_details.Void_Status = Convert.ToString(reader["Void_Status"], CultureInfo.InvariantCulture); }
            //if (!Convert.IsDBNull(reader["Stop_Payment"])) { objk_details.Stop_Payment = Convert.ToString(reader["Stop_Payment"], CultureInfo.InvariantCulture); }
            return objk_details;
        }

        public override List<RIMS_Base.CCheckDetails> GetChkDetailEditDel(System.Int64 chkNo)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("CheckWriting_Check_S_EditDelete");
                dbHelper.AddInParameter(cmd, "@Check_NO", DbType.Int64, chkNo);

                IDataReader reader = dbHelper.ExecuteReader(cmd);
                List<RIMS_Base.CCheckDetails> results = new List<RIMS_Base.CCheckDetails>();
                while (reader.Read())
                {
                    CCheckDetails objk_details = new CCheckDetails();
                    objk_details = MapFromChkDetailEditDel(reader);
                    results.Add(objk_details);
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
        //Get Search Check Result.
        public override DataSet GetCheckDetailsForSearch(System.String m_strClaimType1, System.String m_strClaimType2, System.String m_strClaimType3, System.String m_strClaimType4, System.String m_strClaimType5, System.String m_strClaimNo, System.String m_strOpenFrom, System.String m_strOpenTo, System.String m_strCloseFrom, System.String m_strCloseTo, System.String m_strCheckNo)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("CheckWriting_Check_S_Search");
                dbHelper.AddInParameter(cmd, "@ClaimType1", DbType.String, m_strClaimType1);
                dbHelper.AddInParameter(cmd, "@ClaimType2", DbType.String, m_strClaimType2);
                dbHelper.AddInParameter(cmd, "@ClaimType3", DbType.String, m_strClaimType3);
                dbHelper.AddInParameter(cmd, "@ClaimType4", DbType.String, m_strClaimType4);
                dbHelper.AddInParameter(cmd, "@ClaimType5", DbType.String, m_strClaimType5);
                dbHelper.AddInParameter(cmd, "@ClaimNumber", DbType.String, m_strClaimNo.Replace("'", "''"));
                dbHelper.AddInParameter(cmd, "@OpenFrom", DbType.String, m_strOpenFrom);
                dbHelper.AddInParameter(cmd, "@OpenTo", DbType.String, m_strOpenTo);
                dbHelper.AddInParameter(cmd, "@CloseFrom", DbType.String, m_strCloseFrom);
                dbHelper.AddInParameter(cmd, "@CloseTo", DbType.String, m_strCloseTo);
                dbHelper.AddInParameter(cmd, "@Check_NO", DbType.String, m_strCheckNo.Replace("'", "''"));


                DataSet m_dsCommon = dbHelper.ExecuteDataSet(cmd);
                //IDataReader reader = dbHelper.ExecuteReader(cmd);
                //List<RIMS_Base.CCheckDetails> results = new List<RIMS_Base.CCheckDetails>();
                //while (reader.Read())
                //{
                //    CCheckDetails objk_details = new CCheckDetails();
                //    objk_details = MapFromChkDetailEditDel(reader);
                //    results.Add(objk_details);
                //}
                //reader.Close();
                cmd = null;
                dbHelper = null;
                //return results;
                return m_dsCommon;
            }
            catch (Exception)
            {
                throw;
            }
        }


        public override DataSet GetCheckDetailsForSearch1(System.String m_strClaimType1, System.String m_strClaimType2, System.String m_strClaimType3, System.String m_strClaimType4, System.String m_strClaimType5, System.String m_strClaimNo, System.String m_strOpenFrom, System.String m_strOpenTo, System.String m_strCloseFrom, System.String m_strCloseTo, System.String m_strCheckNo)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("CheckWriting_Check_S_Search1");
                dbHelper.AddInParameter(cmd, "@ClaimType1", DbType.String, m_strClaimType1);
                dbHelper.AddInParameter(cmd, "@ClaimType2", DbType.String, m_strClaimType2);
                dbHelper.AddInParameter(cmd, "@ClaimType3", DbType.String, m_strClaimType3);
                dbHelper.AddInParameter(cmd, "@ClaimType4", DbType.String, m_strClaimType4);
                dbHelper.AddInParameter(cmd, "@ClaimType5", DbType.String, m_strClaimType5);
                dbHelper.AddInParameter(cmd, "@ClaimNumber", DbType.String, m_strClaimNo.Replace("'", "''"));
                dbHelper.AddInParameter(cmd, "@OpenFrom", DbType.String, m_strOpenFrom);
                dbHelper.AddInParameter(cmd, "@OpenTo", DbType.String, m_strOpenTo);
                dbHelper.AddInParameter(cmd, "@CloseFrom", DbType.String, m_strCloseFrom);
                dbHelper.AddInParameter(cmd, "@CloseTo", DbType.String, m_strCloseTo);
                dbHelper.AddInParameter(cmd, "@Check_NO", DbType.String, m_strCheckNo.Replace("'", "''"));


                DataSet m_dsCommon = dbHelper.ExecuteDataSet(cmd);
                //IDataReader reader = dbHelper.ExecuteReader(cmd);
                //List<RIMS_Base.CCheckDetails> results = new List<RIMS_Base.CCheckDetails>();
                //while (reader.Read())
                //{
                //    CCheckDetails objk_details = new CCheckDetails();
                //    objk_details = MapFromChkDetailEditDel(reader);
                //    results.Add(objk_details);
                //}
                //reader.Close();
                cmd = null;
                dbHelper = null;
                //return results;
                return m_dsCommon;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public override DataSet GetCheckDetailsForSearch2(System.String m_strClaimType1, System.String m_strClaimType2, System.String m_strClaimType3, System.String m_strClaimType4, System.String m_strClaimType5, System.String m_strClaimNo, System.String m_strOpenFrom, System.String m_strOpenTo, System.String m_strCloseFrom, System.String m_strCloseTo, System.String m_strCheckNo)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("CheckWriting_Check_S_Search2");
                dbHelper.AddInParameter(cmd, "@ClaimType1", DbType.String, m_strClaimType1);
                dbHelper.AddInParameter(cmd, "@ClaimType2", DbType.String, m_strClaimType2);
                dbHelper.AddInParameter(cmd, "@ClaimType3", DbType.String, m_strClaimType3);
                dbHelper.AddInParameter(cmd, "@ClaimType4", DbType.String, m_strClaimType4);
                dbHelper.AddInParameter(cmd, "@ClaimType5", DbType.String, m_strClaimType5);
                dbHelper.AddInParameter(cmd, "@ClaimNumber", DbType.String, m_strClaimNo.Replace("'", "''"));
                dbHelper.AddInParameter(cmd, "@OpenFrom", DbType.String, m_strOpenFrom);
                dbHelper.AddInParameter(cmd, "@OpenTo", DbType.String, m_strOpenTo);
                dbHelper.AddInParameter(cmd, "@CloseFrom", DbType.String, m_strCloseFrom);
                dbHelper.AddInParameter(cmd, "@CloseTo", DbType.String, m_strCloseTo);
                dbHelper.AddInParameter(cmd, "@Check_NO", DbType.String, m_strCheckNo.Replace("'", "''"));


                DataSet m_dsCommon = dbHelper.ExecuteDataSet(cmd);
                //IDataReader reader = dbHelper.ExecuteReader(cmd);
                //List<RIMS_Base.CCheckDetails> results = new List<RIMS_Base.CCheckDetails>();
                //while (reader.Read())
                //{
                //    CCheckDetails objk_details = new CCheckDetails();
                //    objk_details = MapFromChkDetailEditDel(reader);
                //    results.Add(objk_details);
                //}
                //reader.Close();
                cmd = null;
                dbHelper = null;
                //return results;
                return m_dsCommon;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public override DataSet GetCheckDetailsForSearch3(System.String m_strClaimType1, System.String m_strClaimType2, System.String m_strClaimType3, System.String m_strClaimType4, System.String m_strClaimType5, System.String m_strClaimNo, System.String m_strOpenFrom, System.String m_strOpenTo, System.String m_strCloseFrom, System.String m_strCloseTo, System.String m_strCheckNo)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("CheckWriting_Check_S_Search3");
                dbHelper.AddInParameter(cmd, "@ClaimType1", DbType.String, m_strClaimType1);
                dbHelper.AddInParameter(cmd, "@ClaimType2", DbType.String, m_strClaimType2);
                dbHelper.AddInParameter(cmd, "@ClaimType3", DbType.String, m_strClaimType3);
                dbHelper.AddInParameter(cmd, "@ClaimType4", DbType.String, m_strClaimType4);
                dbHelper.AddInParameter(cmd, "@ClaimType5", DbType.String, m_strClaimType5);
                dbHelper.AddInParameter(cmd, "@ClaimNumber", DbType.String, m_strClaimNo.Replace("'", "''"));
                dbHelper.AddInParameter(cmd, "@OpenFrom", DbType.String, m_strOpenFrom);
                dbHelper.AddInParameter(cmd, "@OpenTo", DbType.String, m_strOpenTo);
                dbHelper.AddInParameter(cmd, "@CloseFrom", DbType.String, m_strCloseFrom);
                dbHelper.AddInParameter(cmd, "@CloseTo", DbType.String, m_strCloseTo);
                dbHelper.AddInParameter(cmd, "@Check_NO", DbType.String, m_strCheckNo.Replace("'", "''"));


                DataSet m_dsCommon = dbHelper.ExecuteDataSet(cmd);
                //IDataReader reader = dbHelper.ExecuteReader(cmd);
                //List<RIMS_Base.CCheckDetails> results = new List<RIMS_Base.CCheckDetails>();
                //while (reader.Read())
                //{
                //    CCheckDetails objk_details = new CCheckDetails();
                //    objk_details = MapFromChkDetailEditDel(reader);
                //    results.Add(objk_details);
                //}
                //reader.Close();
                cmd = null;
                dbHelper = null;
                //return results;
                return m_dsCommon;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public override DataSet GetCheckDetailsForSearchByChk(string m_strCheckNo)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("CheckWriting_Check_S_SearchByChk"); 
                dbHelper.AddInParameter(cmd, "@Check_NO", DbType.String, m_strCheckNo.Replace("'", "''"));


                DataSet m_dsCommon = dbHelper.ExecuteDataSet(cmd);
                //IDataReader reader = dbHelper.ExecuteReader(cmd);
                //List<RIMS_Base.CCheckDetails> results = new List<RIMS_Base.CCheckDetails>();
                //while (reader.Read())
                //{
                //    CCheckDetails objk_details = new CCheckDetails();
                //    objk_details = MapFromChkDetailEditDel(reader);
                //    results.Add(objk_details);
                //}
                //reader.Close();
                cmd = null;
                dbHelper = null;
                //return results;
                return m_dsCommon;
            }
            catch (Exception)
            {
                throw;
            }
        }
        protected RIMS_Base.Dal.CCheckDetails MapFromChkDetailEditDel(IDataReader reader)
        {
            RIMS_Base.Dal.CCheckDetails objk_details = new RIMS_Base.Dal.CCheckDetails();
            if (!Convert.IsDBNull(reader["pk_check_no"])) { objk_details.Pk_check_no = Convert.ToInt64(reader["pk_check_no"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["issue_Date"])) { objk_details.RecIssueDate = Convert.ToDateTime(reader["issue_Date"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Check_Number"])) { objk_details.CDCheckNumber = Convert.ToDecimal(reader["Check_Number"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FLD_Desc"])) { objk_details.AEPPaymentID = Convert.ToString(reader["FLD_Desc"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Service_Begin"])) { objk_details.AEPDtServiceBegin = Convert.ToDateTime(reader["Service_Begin"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Service_End"])) { objk_details.AEPDtServiceEnd = Convert.ToDateTime(reader["Service_End"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Invoice_Number"])) { objk_details.AEPInvoiceNo = Convert.ToString(reader["Invoice_Number"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["check_Amount"])) { objk_details.Check_Amount = Convert.ToDecimal(reader["check_Amount"], CultureInfo.InvariantCulture); }

            if (!Convert.IsDBNull(reader["Claim_number"])) { objk_details.CEDClaimNo = Convert.ToString(reader["Claim_number"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["PayCode"])) { objk_details.CEDPayCode = Convert.ToString(reader["PayCode"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Comments"])) { objk_details.CEDComments = Convert.ToString(reader["Comments"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Fk_Payee"])) { objk_details.AEPPayee = Convert.ToString(reader["Fk_Payee"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Indemnity_outstanding"])) { objk_details.CEDIOutStand = Convert.ToDecimal(reader["Indemnity_outstanding"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Medical_outstanding"])) { objk_details.CEDMOutStand = Convert.ToDecimal(reader["Medical_outstanding"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Expense_outstanding"])) { objk_details.CEDEOutStand = Convert.ToDecimal(reader["Expense_outstanding"], CultureInfo.InvariantCulture); }

            //if (!Convert.IsDBNull(reader["Check_FK"])) { objk_details.Check_FK = Convert.ToDecimal(reader["Check_FK"], CultureInfo.InvariantCulture); }
            //if (!Convert.IsDBNull(reader["Updated_By"])) { objk_details.Updated_By = Convert.ToString(reader["Updated_By"], CultureInfo.InvariantCulture); }
            //if (!Convert.IsDBNull(reader["Updated_Date"])) { objk_details.Updated_Date = Convert.ToDateTime(reader["Updated_Date"], CultureInfo.InvariantCulture); }
            //if (!Convert.IsDBNull(reader["Due_Date"])) { objk_details.Due_Date = Convert.ToDateTime(reader["Due_Date"], CultureInfo.InvariantCulture); }
            //if (!Convert.IsDBNull(reader["check_status"])) { objk_details.Check_status = Convert.ToString(reader["check_status"], CultureInfo.InvariantCulture); }
            //if (!Convert.IsDBNull(reader["Printed_check"])) { objk_details.Printed_check = Convert.ToString(reader["Printed_check"], CultureInfo.InvariantCulture); }
            //if (!Convert.IsDBNull(reader["Stop_Delete_Date"])) { objk_details.Stop_Delete_Date = Convert.ToDateTime(reader["Stop_Delete_Date"], CultureInfo.InvariantCulture); }
            //if (!Convert.IsDBNull(reader["printed_date"])) { objk_details.Printed_date = Convert.ToDateTime(reader["printed_date"], CultureInfo.InvariantCulture); }
            //if (!Convert.IsDBNull(reader["printed_by"])) { objk_details.Printed_by = Convert.ToString(reader["printed_by"], CultureInfo.InvariantCulture); }
            //if (!Convert.IsDBNull(reader["Void_Status"])) { objk_details.Void_Status = Convert.ToString(reader["Void_Status"], CultureInfo.InvariantCulture); }
            //if (!Convert.IsDBNull(reader["Stop_Payment"])) { objk_details.Stop_Payment = Convert.ToString(reader["Stop_Payment"], CultureInfo.InvariantCulture); }
            return objk_details;
        }

        public override List<RIMS_Base.CCheckDetails> GetChecksForPrint()
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Check_S_PrintChecks");
                IDataReader reader = dbHelper.ExecuteReader(cmd);
                List<RIMS_Base.CCheckDetails> results = new List<RIMS_Base.CCheckDetails>();
                while (reader.Read())
                {
                    CCheckDetails objk_details = new CCheckDetails();
                    objk_details = MapFromChecksPrint(reader);
                    results.Add(objk_details);
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
        public override List<RIMS_Base.CCheckDetails> GetPostCheckRegister(System.Int64 m_intType)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Check_S_PrintChecks");
                dbHelper.AddInParameter(cmd, "@Type", DbType.Int64, m_intType);
                IDataReader reader = dbHelper.ExecuteReader(cmd);

                List<RIMS_Base.CCheckDetails> results = new List<RIMS_Base.CCheckDetails>();
                while (reader.Read())
                {
                    CCheckDetails objk_details = new CCheckDetails();
                    objk_details = MapFromChecksPrint(reader);
                    results.Add(objk_details);
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
        public override List<RIMS_Base.CCheckDetails> GetPostCheckRegisterForDateLimit(System.Int64 m_intType, System.DateTime m_DtStart, System.DateTime m_DtEnd)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Check_S_PrintChecks");
                dbHelper.AddInParameter(cmd, "@Type", DbType.Int64, m_intType);
                dbHelper.AddInParameter(cmd, "@StartDate", DbType.DateTime, m_DtStart);
                dbHelper.AddInParameter(cmd, "@EndDate", DbType.DateTime, m_DtEnd);
                IDataReader reader = dbHelper.ExecuteReader(cmd);

                List<RIMS_Base.CCheckDetails> results = new List<RIMS_Base.CCheckDetails>();
                while (reader.Read())
                {
                    CCheckDetails objk_details = new CCheckDetails();
                    objk_details = MapFromChecksPrint(reader);
                    results.Add(objk_details);
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
        protected RIMS_Base.Dal.CCheckDetails MapFromChecksPrint(IDataReader reader)
        {
            RIMS_Base.Dal.CCheckDetails objk_details = new RIMS_Base.Dal.CCheckDetails();
            if (!Convert.IsDBNull(reader["pk_check_no"])) { objk_details.Pk_check_no = Convert.ToInt64(reader["pk_check_no"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Claim_number"])) { objk_details.CEDClaimNo = Convert.ToString(reader["Claim_number"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Payee"])) { objk_details.AEPPayee = Convert.ToString(reader["Payee"].ToString().Replace("''", "'"), CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Payer"])) { objk_details.AEPPayer = Convert.ToString(reader["Payer"].ToString().Replace("''", "'"), CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Rec_Issue_Date"])) { objk_details.RecIssueDate = Convert.ToDateTime(reader["Rec_Issue_Date"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Check_Number"])) { objk_details.CDCheckNumber = Convert.ToDecimal(reader["Check_Number"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["check_Amount"])) { objk_details.Check_Amount = Convert.ToDecimal(reader["check_Amount"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["TotalAmount"])) { objk_details.TotalAmount = Convert.ToString(reader["TotalAmount"], CultureInfo.InvariantCulture); }
            return objk_details;
        }

        public override int Chek_MakePrinted(System.String lpk_check_no, System.String m_strUserName)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            int nRetVal = -1;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Check_U_Status_PrintChecks");
                dbHelper.AddInParameter(cmd, "@pk_check_no", DbType.String, lpk_check_no);
                dbHelper.AddInParameter(cmd, "@UserName", DbType.String, m_strUserName);
                nRetVal = dbHelper.ExecuteNonQuery(cmd);
                dbHelper = null; cmd.Dispose(); cmd = null;
                return nRetVal;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public override int Chek_MakeRePrinted(System.String lpk_check_no, System.String m_strUserName)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            int nRetVal = -1;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Check_U_Status_RePrintChecks");
                dbHelper.AddInParameter(cmd, "@pk_check_no", DbType.String, lpk_check_no);
                dbHelper.AddInParameter(cmd, "@UserName", DbType.String, m_strUserName);
                nRetVal = dbHelper.ExecuteNonQuery(cmd);
                dbHelper = null; cmd.Dispose(); cmd = null;
                return nRetVal;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public override int Chek_MakeStop(System.String lpk_check_no, System.String m_strUserName)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            int nRetVal = -1;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Check_U_Status_StopChecks");
                dbHelper.AddInParameter(cmd, "@pk_check_no", DbType.String, lpk_check_no);
                dbHelper.AddInParameter(cmd, "@UserName", DbType.String, m_strUserName);
                nRetVal = dbHelper.ExecuteNonQuery(cmd);
                dbHelper = null; cmd.Dispose(); cmd = null;
                return nRetVal;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public override int Chek_MakeVoid(System.String lpk_check_no, System.String m_strUserName)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            int nRetVal = -1;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Check_U_Status_VoidChecks");
                dbHelper.AddInParameter(cmd, "@pk_check_no", DbType.String, lpk_check_no);
                dbHelper.AddInParameter(cmd, "@UserName", DbType.String, m_strUserName);
                nRetVal = dbHelper.ExecuteNonQuery(cmd);
                dbHelper = null; cmd.Dispose(); cmd = null;
                return nRetVal;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public override List<RIMS_Base.CCheckDetails> GetStoppedVoidedCheck(System.Int64 m_intType)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Check_S_StopVoidChecks");
                dbHelper.AddInParameter(cmd, "@Type", DbType.Int64, m_intType);
                IDataReader reader = dbHelper.ExecuteReader(cmd);

                List<RIMS_Base.CCheckDetails> results = new List<RIMS_Base.CCheckDetails>();
                while (reader.Read())
                {
                    CCheckDetails objk_details = new CCheckDetails();
                    objk_details = MapFromStopVoidChecks(reader);
                    results.Add(objk_details);
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
        public override List<RIMS_Base.CCheckDetails> GetStoppedVoidedCheckForDateLimit(System.Int64 m_intType, System.DateTime m_DtStart, System.DateTime m_DtEnd)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Check_S_StopVoidChecks");
                dbHelper.AddInParameter(cmd, "@Type", DbType.Int64, m_intType);
                dbHelper.AddInParameter(cmd, "@StartDate", DbType.DateTime, m_DtStart);
                dbHelper.AddInParameter(cmd, "@EndDate", DbType.DateTime, m_DtEnd);
                IDataReader reader = dbHelper.ExecuteReader(cmd);

                List<RIMS_Base.CCheckDetails> results = new List<RIMS_Base.CCheckDetails>();
                while (reader.Read())
                {
                    CCheckDetails objk_details = new CCheckDetails();
                    objk_details = MapFromStopVoidChecks(reader);
                    results.Add(objk_details);
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
        protected RIMS_Base.Dal.CCheckDetails MapFromStopVoidChecks(IDataReader reader)
        {
            RIMS_Base.Dal.CCheckDetails objk_details = new RIMS_Base.Dal.CCheckDetails();
            if (!Convert.IsDBNull(reader["pk_check_no"])) { objk_details.Pk_check_no = Convert.ToInt64(reader["pk_check_no"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Rec_Issue_Date"])) { objk_details.RecIssueDate = Convert.ToDateTime(reader["Rec_Issue_Date"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Check_Number"])) { objk_details.CDCheckNumber = Convert.ToDecimal(reader["Check_Number"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Payment_Id"])) { objk_details.AEPPaymentID = Convert.ToString(reader["Payment_Id"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Service_Begin"])) { objk_details.AEPDtServiceBegin = Convert.ToDateTime(reader["Service_Begin"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Service_End"])) { objk_details.AEPDtServiceEnd = Convert.ToDateTime(reader["Service_End"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Payee"])) { objk_details.AEPPayee = Convert.ToString(reader["Payee"].ToString().Replace("''", "'"), CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Invoice_Number"])) { objk_details.AEPInvoiceNo = Convert.ToString(reader["Invoice_Number"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["check_Amount"])) { objk_details.Check_Amount = Convert.ToDecimal(reader["check_Amount"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Claim_number"])) { objk_details.CEDClaimNo = Convert.ToString(reader["Claim_number"], CultureInfo.InvariantCulture); }
            //if (!Convert.IsDBNull(reader["Payer"])) { objk_details.AEPPayer = Convert.ToString(reader["Payer"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["TotalAmount"])) { objk_details.TotalAmount = Convert.ToString(reader["TotalAmount"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Stop_Delete_Date"])) { objk_details.Stop_Delete_Date = Convert.ToDateTime(reader["Stop_Delete_Date"], CultureInfo.InvariantCulture); }


            return objk_details;
        }
        //Generate PDF
        public override DataSet GetDataForPDF(System.String m_strChkNo)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            DataSet results = new DataSet();
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Check_GetaDataForPDF");
                dbHelper.AddInParameter(cmd, "@pk_Check_No", DbType.String, m_strChkNo);
                results = dbHelper.ExecuteDataSet(cmd);
                cmd = null;
                dbHelper = null;
                return results;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }


}

