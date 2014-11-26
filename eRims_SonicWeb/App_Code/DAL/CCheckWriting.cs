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


    public class CCheckWriting : RIMS_Base.CCheckWriting
    {

        public override int InsertUpdate_CheckWriting(RIMS_Base.CCheckWriting Objk_Writing)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            int nRetVal = -1;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("CheckWriting_InsertUpdate");
                dbHelper.AddParameter(cmd, "@pk_check_no", DbType.Int64, ParameterDirection.InputOutput, "pk_check_no", DataRowVersion.Current, Objk_Writing.Pk_check_no);
                dbHelper.AddInParameter(cmd, "@Table_Name", DbType.String, Objk_Writing.Table_Name);
                dbHelper.AddInParameter(cmd, "@FK_Table_Name", DbType.Decimal, Objk_Writing.TableFK);
                dbHelper.AddInParameter(cmd, "@Check_Number", DbType.Decimal, Objk_Writing.Check_Number);
                dbHelper.AddInParameter(cmd, "@Input_Date", DbType.DateTime, Objk_Writing.Input_Date);
                dbHelper.AddInParameter(cmd, "@issue_date", DbType.DateTime, Objk_Writing.Issue_date);
                dbHelper.AddInParameter(cmd, "@Claimant_Vendor", DbType.String, Objk_Writing.Claimant_Vendor);
                dbHelper.AddInParameter(cmd, "@C_V_FK", DbType.Decimal, Objk_Writing.C_V_FK);
                dbHelper.AddInParameter(cmd, "@Payment_Id", DbType.String, Objk_Writing.Payment_Id);
                dbHelper.AddInParameter(cmd, "@Paycode", DbType.String, Objk_Writing.Paycode);
                dbHelper.AddInParameter(cmd, "@Payment_Amount", DbType.Decimal, Objk_Writing.Payment_Amount);
                dbHelper.AddInParameter(cmd, "@Service_Begin", DbType.DateTime, Objk_Writing.Service_Begin);
                dbHelper.AddInParameter(cmd, "@Service_End", DbType.DateTime, Objk_Writing.Service_End);
                dbHelper.AddInParameter(cmd, "@Recurring_Payments", DbType.String, Objk_Writing.Recurring_Payments);
                dbHelper.AddInParameter(cmd, "@Recurring_Number", DbType.Decimal, Objk_Writing.Recurring_Number);
                dbHelper.AddInParameter(cmd, "@Recurring_Period", DbType.Decimal, Objk_Writing.Recurring_Period);
                dbHelper.AddInParameter(cmd, "@Recurring_Begin_Date", DbType.DateTime, Objk_Writing.Recurring_Begin_Date);
                dbHelper.AddInParameter(cmd, "@Recurring_End_Date", DbType.DateTime, Objk_Writing.Recurring_End_Date);
                dbHelper.AddInParameter(cmd, "@Stop_Recurring", DbType.DateTime, Objk_Writing.Stop_Recurring);
                dbHelper.AddInParameter(cmd, "@Updated_By", DbType.String, Objk_Writing.Updated_By);
                dbHelper.AddInParameter(cmd, "@Updated_Date", DbType.DateTime, Objk_Writing.Updated_Date);
                dbHelper.AddInParameter(cmd, "@Current_Recurring_Number", DbType.Decimal, Objk_Writing.Current_Recurring_Number);
                dbHelper.AddInParameter(cmd, "@next_due_date", DbType.DateTime, Objk_Writing.Next_due_date);
                dbHelper.AddInParameter(cmd, "@Payment_Type", DbType.Decimal, Objk_Writing.Payment_Type);
                dbHelper.AddInParameter(cmd, "@FK_Supp_Doc_Type", DbType.Decimal, Objk_Writing.FK_Supp_Doc_Type);
                dbHelper.AddInParameter(cmd, "@Doc_Date", DbType.DateTime, Objk_Writing.Doc_Date);
                dbHelper.AddInParameter(cmd, "@Document_Number", DbType.String, Objk_Writing.Document_Number);
                dbHelper.AddInParameter(cmd, "@Invoice_Number", DbType.String, Objk_Writing.Invoice_Number);
                dbHelper.AddInParameter(cmd, "@FK_Bank", DbType.Decimal, Objk_Writing.FK_Bank);
                dbHelper.AddInParameter(cmd, "@FK_Payee", DbType.Decimal, Objk_Writing.FK_Payee);
                dbHelper.AddInParameter(cmd, "@FK_Table_Payee", DbType.String, Objk_Writing.FK_Table_Payee);
                dbHelper.AddInParameter(cmd, "@FK_Payer", DbType.Decimal, Objk_Writing.FK_Payer);
                dbHelper.AddInParameter(cmd, "@FK_Table_Payer", DbType.String, Objk_Writing.FK_Table_Payer);
                dbHelper.AddInParameter(cmd, "@Comments", DbType.String, Objk_Writing.Comments);
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
        public override int Delete_CheckWriting(System.Decimal lpk_check_no)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            int nRetVal = -1;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Che_Deletek_Writing");
                dbHelper.AddInParameter(cmd, "@pk_check_no", DbType.Decimal, lpk_check_no);
                nRetVal = dbHelper.ExecuteNonQuery(cmd);
                dbHelper = null; cmd.Dispose(); cmd = null;
                return nRetVal;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public override string ActivateInactivate_CheckWriting(string strIDs, int intModifiedBy, bool bIsActive)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            int nRetVal = -1;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Che_ActivateInactivatek_Writings");
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
        public override List<RIMS_Base.CCheckWriting> GetAll(Boolean blnIsActive)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Che_Selectk_Writing");
                dbHelper.AddInParameter(cmd, "@IsActive", DbType.Boolean, blnIsActive);
                IDataReader reader = dbHelper.ExecuteReader(cmd);
                List<RIMS_Base.CCheckWriting> results = new List<RIMS_Base.CCheckWriting>();
                while (reader.Read())
                {
                    CCheckWriting objk_Writing = new CCheckWriting();
                    objk_Writing = MapFrom(reader);
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
        public override RIMS_Base.CCheckWriting GetCheckWritingByID(System.Decimal pk_check_no)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Che_Selectk_Writing");
                dbHelper.AddInParameter(cmd, "@pk_check_no", DbType.Decimal, pk_check_no);

                IDataReader reader = dbHelper.ExecuteReader(cmd);
                CCheckWriting objk_Writing = new CCheckWriting();
                if (reader.Read())
                {
                    objk_Writing = MapFrom(reader);
                }
                reader.Close();
                cmd = null;
                dbHelper = null;

                return objk_Writing;
            }
            catch (Exception)
            {
                throw;
            }
        }
        protected RIMS_Base.Dal.CCheckWriting MapFrom(IDataReader reader)
        {
            RIMS_Base.Dal.CCheckWriting objk_Writing = new RIMS_Base.Dal.CCheckWriting();
            if (!Convert.IsDBNull(reader["pk_check_no"])) { objk_Writing.Pk_check_no = Convert.ToInt64(reader["pk_check_no"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Table_Name"])) { objk_Writing.Table_Name = Convert.ToString(reader["Table_Name"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FK_Table_Name"])) { objk_Writing.FK_Table_Name = Convert.ToDecimal(reader["FK_Table_Name"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Check_Number"])) { objk_Writing.Check_Number = Convert.ToDecimal(reader["Check_Number"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Input_Date"])) { objk_Writing.Input_Date = Convert.ToDateTime(reader["Input_Date"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["issue_date"])) { objk_Writing.Issue_date = Convert.ToDateTime(reader["issue_date"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Claimant_Vendor"])) { objk_Writing.Claimant_Vendor = Convert.ToString(reader["Claimant_Vendor"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["C_V_FK"])) { objk_Writing.C_V_FK = Convert.ToDecimal(reader["C_V_FK"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Payment_Id"])) { objk_Writing.Payment_Id = Convert.ToString(reader["Payment_Id"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Paycode"])) { objk_Writing.Paycode = Convert.ToString(reader["Paycode"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Payment_Amount"])) { objk_Writing.Payment_Amount = Convert.ToDecimal(reader["Payment_Amount"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Service_Begin"])) { objk_Writing.Service_Begin = Convert.ToDateTime(reader["Service_Begin"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Service_End"])) { objk_Writing.Service_End = Convert.ToDateTime(reader["Service_End"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Recurring_Payments"])) { objk_Writing.Recurring_Payments = Convert.ToString(reader["Recurring_Payments"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Recurring_Number"])) { objk_Writing.Recurring_Number = Convert.ToDecimal(reader["Recurring_Number"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Recurring_Period"])) { objk_Writing.Recurring_Period = Convert.ToDecimal(reader["Recurring_Period"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Recurring_Begin_Date"])) { objk_Writing.Recurring_Begin_Date = Convert.ToDateTime(reader["Recurring_Begin_Date"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Recurring_End_Date"])) { objk_Writing.Recurring_End_Date = Convert.ToDateTime(reader["Recurring_End_Date"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Stop_Recurring"])) { objk_Writing.Stop_Recurring = Convert.ToDateTime(reader["Stop_Recurring"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Updated_By"])) { objk_Writing.Updated_By = Convert.ToString(reader["Updated_By"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Updated_Date"])) { objk_Writing.Updated_Date = Convert.ToDateTime(reader["Updated_Date"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Current_Recurring_Number"])) { objk_Writing.Current_Recurring_Number = Convert.ToDecimal(reader["Current_Recurring_Number"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["next_due_date"])) { objk_Writing.Next_due_date = Convert.ToDateTime(reader["next_due_date"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Payment_Type"])) { objk_Writing.Payment_Type = Convert.ToDecimal(reader["Payment_Type"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FK_Supp_Doc_Type"])) { objk_Writing.FK_Supp_Doc_Type = Convert.ToDecimal(reader["FK_Supp_Doc_Type"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Doc_Date"])) { objk_Writing.Doc_Date = Convert.ToDateTime(reader["Doc_Date"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Document_Number"])) { objk_Writing.Document_Number = Convert.ToString(reader["Document_Number"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Invoice_Number"])) { objk_Writing.Invoice_Number = Convert.ToString(reader["Invoice_Number"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FK_Bank"])) { objk_Writing.FK_Bank = Convert.ToDecimal(reader["FK_Bank"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FK_Payee"])) { objk_Writing.FK_Payee = Convert.ToDecimal(reader["FK_Payee"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FK_Table_Payee"])) { objk_Writing.FK_Table_Payee = Convert.ToString(reader["FK_Table_Payee"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FK_Payer"])) { objk_Writing.FK_Payer = Convert.ToDecimal(reader["FK_Payer"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FK_Table_Payer"])) { objk_Writing.FK_Table_Payer = Convert.ToString(reader["FK_Table_Payer"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Comments"])) { objk_Writing.Comments = Convert.ToString(reader["Comments"], CultureInfo.InvariantCulture); } return objk_Writing;
        }

        //For Claim info
        public override List<RIMS_Base.CCheckWriting> GetClaimInfoByClaimNo(string m_strClaimNo)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("CheckWriting_GetClaimInfoByClaimNo");
                dbHelper.AddInParameter(cmd, "@Claim_Number", DbType.String, m_strClaimNo);
                IDataReader reader = dbHelper.ExecuteReader(cmd);
                List<RIMS_Base.CCheckWriting> results = new List<RIMS_Base.CCheckWriting>();
                while (reader.Read())
                {
                    CCheckWriting objk_Writing = new CCheckWriting();
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
        protected RIMS_Base.Dal.CCheckWriting MapFromClaimInfo(IDataReader reader)
        {
            RIMS_Base.Dal.CCheckWriting objk_Writing = new RIMS_Base.Dal.CCheckWriting();
            if (!Convert.IsDBNull(reader["tblName"])) { objk_Writing.TableName = Convert.ToString(reader["tblName"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["tblFK"])) { objk_Writing.TableFK = Convert.ToInt32(reader["tblFK"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["claim_number"])) { objk_Writing.Claim_Number = Convert.ToString(reader["claim_number"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FK_Claimant_id"])) { objk_Writing.FK_Claimant_id = Convert.ToDecimal(reader["FK_Claimant_id"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Last_name"])) { objk_Writing.LastName = Convert.ToString(reader["Last_name"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["first_name"])) { objk_Writing.FirstName = Convert.ToString(reader["first_name"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["middle_name"])) { objk_Writing.MiddleName = Convert.ToString(reader["middle_name"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Date_Of_Loss"])) { objk_Writing.Date_Of_Loss = Convert.ToDateTime(reader["Date_Of_Loss"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FK_Claimant_id"])) { objk_Writing.FK_Claimant_id = Convert.ToDecimal(reader["FK_Claimant_id"], CultureInfo.InvariantCulture); }

            if (!Convert.IsDBNull(reader["Incurred_Indemnity"])) { objk_Writing.Incurred_Indemnity = Convert.ToDecimal(reader["Incurred_Indemnity"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["INDEMNITY_PAID"])) { objk_Writing.PAID_INDEMNITY = Convert.ToDecimal(reader["INDEMNITY_PAID"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["INDEMNITY_outstanding"])) { objk_Writing.Outstanding_INDEMNITY = Convert.ToDecimal(reader["INDEMNITY_outstanding"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Incurred_Medical"])) { objk_Writing.Incurred_Medical = Convert.ToDecimal(reader["Incurred_Medical"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Medical_PAID"])) { objk_Writing.PAID_Medical = Convert.ToDecimal(reader["Medical_PAID"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Medical_outstanding"])) { objk_Writing.Outstanding_Medical = Convert.ToDecimal(reader["Medical_outstanding"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Incurred_Expense"])) { objk_Writing.Incurred_Expense = Convert.ToDecimal(reader["Incurred_Expense"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Expense_PAID"])) { objk_Writing.PAID_Expense = Convert.ToDecimal(reader["Expense_PAID"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Expense_outstanding"])) { objk_Writing.Outstanding_Expense = Convert.ToDecimal(reader["Expense_outstanding"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FK_ECD_Id"])) { objk_Writing.FK_ECD_Id = Convert.ToDecimal(reader["FK_ECD_Id"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FK_Claimant"])) { objk_Writing.FK_Claimant = Convert.ToDecimal(reader["FK_Claimant"], CultureInfo.InvariantCulture); }

            
            return objk_Writing;
        }

        //For Reserves
        public override List<RIMS_Base.CCheckWriting> GetReserves(string m_strTblName, int m_intTblFk)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("CheckWriting_GetReserves");
                dbHelper.AddInParameter(cmd, "@TableName", DbType.String, m_strTblName);
                dbHelper.AddInParameter(cmd, "@TblFk", DbType.Int32, m_intTblFk);
                IDataReader reader = dbHelper.ExecuteReader(cmd);
                List<RIMS_Base.CCheckWriting> results = new List<RIMS_Base.CCheckWriting>();
                while (reader.Read())
                {
                    CCheckWriting objk_Writing = new CCheckWriting();
                    objk_Writing = MapFromReservesInfo(reader);
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
        protected RIMS_Base.Dal.CCheckWriting MapFromReservesInfo(IDataReader reader)
        {
            RIMS_Base.Dal.CCheckWriting objReserves = new RIMS_Base.Dal.CCheckWriting();
            if (!Convert.IsDBNull(reader["Incurred_Indemnity"])) { objReserves.Incurred_Indemnity = Convert.ToDecimal(reader["Incurred_Indemnity"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["PAID_INDEMNITY"])) { objReserves.PAID_INDEMNITY = Convert.ToDecimal(reader["PAID_INDEMNITY"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["outstanding_INDEMNITY"])) { objReserves.Outstanding_INDEMNITY = Convert.ToDecimal(reader["outstanding_INDEMNITY"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Incurred_Medical"])) { objReserves.Incurred_Medical = Convert.ToDecimal(reader["Incurred_Medical"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["PAID_Medical"])) { objReserves.PAID_Medical = Convert.ToDecimal(reader["PAID_Medical"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["outstanding_Medical"])) { objReserves.Outstanding_Medical = Convert.ToDecimal(reader["outstanding_Medical"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Incurred_Expense"])) { objReserves.Incurred_Expense = Convert.ToDecimal(reader["Incurred_Expense"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["PAID_Expense"])) { objReserves.PAID_Expense = Convert.ToDecimal(reader["PAID_Expense"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["outstanding_Expense"])) { objReserves.Outstanding_Expense = Convert.ToDecimal(reader["outstanding_Expense"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FK_Table_Name"])) { objReserves.TableFkReserves = Convert.ToInt32(reader["FK_Table_Name"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Table_Name"])) { objReserves.Table_Name = Convert.ToString(reader["Table_Name"], CultureInfo.InvariantCulture); }
            return objReserves;
        }
        //For Payment Type
        public override List<RIMS_Base.CCheckWriting> GetAllPaymentType()
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("PaymentType_Select");
                IDataReader reader = dbHelper.ExecuteReader(cmd);
                List<RIMS_Base.CCheckWriting> results = new List<RIMS_Base.CCheckWriting>();
                while (reader.Read())
                {
                    CCheckWriting objent_Type = new CCheckWriting();
                    objent_Type = MapFromPaymentType(reader);
                    results.Add(objent_Type);
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
        protected RIMS_Base.Dal.CCheckWriting MapFromPaymentType(IDataReader reader)
        {
            RIMS_Base.Dal.CCheckWriting objent_Type = new RIMS_Base.Dal.CCheckWriting();
            if (!Convert.IsDBNull(reader["PK_Payment_Type_ID"])) { objent_Type.PK_Payment_Type_ID = Convert.ToDecimal(reader["PK_Payment_Type_ID"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FLD_Desc"])) { objent_Type.FLD_Desc = Convert.ToString(reader["FLD_Desc"], CultureInfo.InvariantCulture); }
            return objent_Type;
        }
        //For Check Edit Delete
        public override int Update_CEDCheckEditDel(RIMS_Base.CCheckWriting Objk_Writing)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            int nRetVal = -1;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Check_U_EditDelete");
                dbHelper.AddParameter(cmd, "@pk_check_no", DbType.Int64, ParameterDirection.InputOutput, "pk_check_no", DataRowVersion.Current, Objk_Writing.CEDPK_Chk_No);
                dbHelper.AddInParameter(cmd, "@issue_date", DbType.DateTime, Objk_Writing.Issue_date);
                dbHelper.AddInParameter(cmd, "@Payment_Id", DbType.String, Objk_Writing.Payment_Id);
                dbHelper.AddInParameter(cmd, "@Paycode", DbType.String, Objk_Writing.Paycode);
                dbHelper.AddInParameter(cmd, "@check_Amount", DbType.Decimal, Objk_Writing.CEDChkPayment);
                dbHelper.AddInParameter(cmd, "@Service_Begin", DbType.DateTime, Objk_Writing.Service_Begin);
                dbHelper.AddInParameter(cmd, "@Service_End", DbType.DateTime, Objk_Writing.Service_End);
                dbHelper.AddInParameter(cmd, "@Invoice_Number", DbType.String, Objk_Writing.Invoice_Number);
                dbHelper.AddInParameter(cmd, "@Comments", DbType.String, Objk_Writing.Comments);
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


        public override List<RIMS_Base.CCheckWriting> GetWorkerCompClaimInfoByClaimNo(string m_strClaimNo)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("CheckWriting_GetClaimInfoByClaimNo");
                dbHelper.AddInParameter(cmd, "@Claim_Number", DbType.String, m_strClaimNo);
                IDataReader reader = dbHelper.ExecuteReader(cmd);
                List<RIMS_Base.CCheckWriting> results = new List<RIMS_Base.CCheckWriting>();
                while (reader.Read())
                {
                    CCheckWriting objk_Writing = new CCheckWriting();
                    objk_Writing = MapFromWCClaimInfo(reader);
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
        protected RIMS_Base.Dal.CCheckWriting MapFromWCClaimInfo(IDataReader reader)
        {
            RIMS_Base.Dal.CCheckWriting objk_Writing = new RIMS_Base.Dal.CCheckWriting();
            if (!Convert.IsDBNull(reader["tblName"])) { objk_Writing.TableName = Convert.ToString(reader["tblName"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["tblFK"])) { objk_Writing.TableFK = Convert.ToInt32(reader["tblFK"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["claim_number"])) { objk_Writing.Claim_Number = Convert.ToString(reader["claim_number"], CultureInfo.InvariantCulture); }
          //  if (!Convert.IsDBNull(reader["FK_Claimant_id"])) { objk_Writing.FK_Claimant_id = Convert.ToDecimal(reader["FK_Claimant_id"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Last_name"])) { objk_Writing.LastName = Convert.ToString(reader["Last_name"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["first_name"])) { objk_Writing.FirstName = Convert.ToString(reader["first_name"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["middle_name"])) { objk_Writing.MiddleName = Convert.ToString(reader["middle_name"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Date_Of_Loss"])) { objk_Writing.IncidentDate = Convert.ToString(reader["Date_Of_Loss"], CultureInfo.InvariantCulture); }
          //  if (!Convert.IsDBNull(reader["FK_Claimant_id"])) { objk_Writing.FK_Claimant_id = Convert.ToDecimal(reader["FK_Claimant_id"], CultureInfo.InvariantCulture); }

            if (!Convert.IsDBNull(reader["Incurred_Indemnity"])) { objk_Writing.Incurred_Indemnity = Convert.ToDecimal(reader["Incurred_Indemnity"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["INDEMNITY_PAID"])) { objk_Writing.PAID_INDEMNITY = Convert.ToDecimal(reader["INDEMNITY_PAID"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["INDEMNITY_outstanding"])) { objk_Writing.Outstanding_INDEMNITY = Convert.ToDecimal(reader["INDEMNITY_outstanding"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Incurred_Medical"])) { objk_Writing.Incurred_Medical = Convert.ToDecimal(reader["Incurred_Medical"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Medical_PAID"])) { objk_Writing.PAID_Medical = Convert.ToDecimal(reader["Medical_PAID"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Medical_outstanding"])) { objk_Writing.Outstanding_Medical = Convert.ToDecimal(reader["Medical_outstanding"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Incurred_Expense"])) { objk_Writing.Incurred_Expense = Convert.ToDecimal(reader["Incurred_Expense"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Expense_PAID"])) { objk_Writing.PAID_Expense = Convert.ToDecimal(reader["Expense_PAID"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Expense_outstanding"])) { objk_Writing.Outstanding_Expense = Convert.ToDecimal(reader["Expense_outstanding"], CultureInfo.InvariantCulture); }


            return objk_Writing;
        }

        public override string GetClaimType(string ClaimNumber)
        {
           Database dbHelper = null;
            DbCommand cmd = null;
            
            string nRetVal = string.Empty;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("FindClaimType");
                dbHelper.AddParameter(cmd, "@Claim_Number", DbType.String, ParameterDirection.Input, "Claim_Number", DataRowVersion.Current, ClaimNumber);
                dbHelper.AddParameter(cmd, "@ClaimType", DbType.String, ParameterDirection.InputOutput, "ClaimType", DataRowVersion.Current, string.Empty);
                IDataReader reader = dbHelper.ExecuteReader(cmd);
                while (reader.Read())
                {
                    nRetVal = reader.GetValue(0).ToString();
                }
                return nRetVal;
            }
            catch
            { throw; }
            finally
            { dbHelper = null; cmd.Dispose(); cmd = null; }
        }


    }





}

