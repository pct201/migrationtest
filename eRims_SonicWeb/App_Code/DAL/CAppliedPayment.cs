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


    public class CAppliedPayment : RIMS_Base.CAppliedPayment
    {

        public override int InsertUpdateApp_Payment(RIMS_Base.CAppliedPayment ObjIED_PAYMENTS)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            int nRetVal = -1;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("AppliedPayment_InsertUpdate");
                dbHelper.AddParameter(cmd, "@pk_applied_id", DbType.Int64, ParameterDirection.InputOutput, "pk_applied_id", DataRowVersion.Current, ObjIED_PAYMENTS.Pk_applied_id);
                dbHelper.AddInParameter(cmd, "@bank_name", DbType.String, ObjIED_PAYMENTS.Bank_name);
                dbHelper.AddInParameter(cmd, "@bank_address1", DbType.String, ObjIED_PAYMENTS.Bank_address1);
                dbHelper.AddInParameter(cmd, "@bank_address2", DbType.String, ObjIED_PAYMENTS.Bank_address2);
                dbHelper.AddInParameter(cmd, "@bank_city", DbType.String, ObjIED_PAYMENTS.Bank_city);
                dbHelper.AddInParameter(cmd, "@bank_state_code", DbType.String, ObjIED_PAYMENTS.Bank_state_code);
                dbHelper.AddInParameter(cmd, "@bank_zip", DbType.String, ObjIED_PAYMENTS.Bank_zip);
                dbHelper.AddInParameter(cmd, "@bank_state", DbType.String, ObjIED_PAYMENTS.Bank_state);
                dbHelper.AddInParameter(cmd, "@Fld_Bank_No1", DbType.String, ObjIED_PAYMENTS.Fld_Bank_No1);
                dbHelper.AddInParameter(cmd, "@Fld_Bank_No2", DbType.String, ObjIED_PAYMENTS.Fld_Bank_No2);
                dbHelper.AddInParameter(cmd, "@issue_date", DbType.DateTime, ObjIED_PAYMENTS.Issue_date);
                dbHelper.AddInParameter(cmd, "@Amount", DbType.Decimal, ObjIED_PAYMENTS.Amount);
                dbHelper.AddInParameter(cmd, "@payee_name", DbType.String, ObjIED_PAYMENTS.Payee_name);
                dbHelper.AddInParameter(cmd, "@payee_address1", DbType.String, ObjIED_PAYMENTS.Payee_address1);
                dbHelper.AddInParameter(cmd, "@payee_address2", DbType.String, ObjIED_PAYMENTS.Payee_address2);
                dbHelper.AddInParameter(cmd, "@employeer", DbType.String, ObjIED_PAYMENTS.Employeer);
                dbHelper.AddInParameter(cmd, "@employee_name", DbType.String, ObjIED_PAYMENTS.Employee_name);
                dbHelper.AddInParameter(cmd, "@employee_ssn", DbType.String, ObjIED_PAYMENTS.Employee_ssn);
                dbHelper.AddInParameter(cmd, "@claim_no", DbType.String, ObjIED_PAYMENTS.Claim_no);
                dbHelper.AddInParameter(cmd, "@date_of_loss", DbType.String, ObjIED_PAYMENTS.Date_of_loss);
                dbHelper.AddInParameter(cmd, "@adjuster", DbType.String, ObjIED_PAYMENTS.Adjuster);
                dbHelper.AddInParameter(cmd, "@payment_type", DbType.String, ObjIED_PAYMENTS.Payment_type);
                dbHelper.AddInParameter(cmd, "@service_date_from", DbType.DateTime, ObjIED_PAYMENTS.Service_date_from);
                dbHelper.AddInParameter(cmd, "@service_date_to", DbType.DateTime, ObjIED_PAYMENTS.Service_date_to);
                dbHelper.AddInParameter(cmd, "@comments", DbType.String, ObjIED_PAYMENTS.Comments);
                dbHelper.AddInParameter(cmd, "@timeofloss", DbType.String, ObjIED_PAYMENTS.Timeofloss);
                dbHelper.AddInParameter(cmd, "@check_no", DbType.String, ObjIED_PAYMENTS.Check_no);
                dbHelper.AddInParameter(cmd, "@Fld_AccountNo", DbType.String, ObjIED_PAYMENTS.Fld_AccountNo);
                dbHelper.AddInParameter(cmd, "@Fld_RoutingNo", DbType.String, ObjIED_PAYMENTS.Fld_RoutingNo);
                dbHelper.AddInParameter(cmd, "@check_fk", DbType.Decimal, ObjIED_PAYMENTS.Check_fk);
                dbHelper.AddInParameter(cmd, "@Check_Writting_FK", DbType.Decimal, ObjIED_PAYMENTS.Check_Writting_FK);
                dbHelper.AddInParameter(cmd, "@Check_Status", DbType.String, ObjIED_PAYMENTS.Check_Status);
                dbHelper.AddInParameter(cmd, "@Stop_Delete_Date", DbType.DateTime, ObjIED_PAYMENTS.Stop_Delete_Date);
                dbHelper.AddInParameter(cmd, "@Invoice_Number", DbType.String, ObjIED_PAYMENTS.Invoice_Number);
                dbHelper.AddInParameter(cmd, "@Void_Status", DbType.Int32, ObjIED_PAYMENTS.Void_Status);
                dbHelper.AddInParameter(cmd, "@Cleared_Bank", DbType.String, ObjIED_PAYMENTS.Cleared_Bank);
                dbHelper.ExecuteNonQuery(cmd);
                nRetVal = int.Parse(dbHelper.GetParameterValue(cmd, "@pk_applied_id").ToString());
                return nRetVal;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            { dbHelper = null; cmd.Dispose(); cmd = null; }
        }
        public override int DeleteApp_Payment(System.Decimal lpk_applied_id)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            int nRetVal = -1;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("APP_DeleteIED_PAYMENTS");
                dbHelper.AddInParameter(cmd, "@pk_applied_id", DbType.Decimal, lpk_applied_id);
                nRetVal = dbHelper.ExecuteNonQuery(cmd);
                dbHelper = null; cmd.Dispose(); cmd = null;
                return nRetVal;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public override string ActivateInactivateApp_Payment(string strIDs, int intModifiedBy, bool bIsActive)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            int nRetVal = -1;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("APP_ActivateInactivateIED_PAYMENTSs");
                dbHelper.AddParameter(cmd, "@pk_applied_ids", DbType.String, ParameterDirection.InputOutput, "pk_applied_ids", DataRowVersion.Current, strIDs);
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
        public override List<RIMS_Base.CAppliedPayment> GetAll()
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("APP_SelectIED_PAYMENTS");
                IDataReader reader = dbHelper.ExecuteReader(cmd);
                List<RIMS_Base.CAppliedPayment> results = new List<RIMS_Base.CAppliedPayment>();
                while (reader.Read())
                {
                    CAppliedPayment objIED_PAYMENTS = new CAppliedPayment();
                    objIED_PAYMENTS = MapFrom(reader);
                    results.Add(objIED_PAYMENTS);
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


        public override RIMS_Base.CAppliedPayment GetApp_PaymentByID(System.Decimal pk_applied_id)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("APP_SelectIED_PAYMENTS");
                dbHelper.AddInParameter(cmd, "@pk_applied_id", DbType.Decimal, pk_applied_id);

                IDataReader reader = dbHelper.ExecuteReader(cmd);
                CAppliedPayment objIED_PAYMENTS = new CAppliedPayment();
                if (reader.Read())
                {
                    objIED_PAYMENTS = MapFrom(reader);
                }
                reader.Close();
                cmd = null;
                dbHelper = null;

                return objIED_PAYMENTS;
            }
            catch (Exception)
            {
                throw;
            }
        }


        protected RIMS_Base.Dal.CAppliedPayment MapFrom(IDataReader reader)
        {
            RIMS_Base.Dal.CAppliedPayment objIED_PAYMENTS = new RIMS_Base.Dal.CAppliedPayment();
            if (!Convert.IsDBNull(reader["pk_applied_id"])) { objIED_PAYMENTS.Pk_applied_id = Convert.ToInt64(reader["pk_applied_id"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["bank_name"])) { objIED_PAYMENTS.Bank_name = Convert.ToString(reader["bank_name"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["bank_address1"])) { objIED_PAYMENTS.Bank_address1 = Convert.ToString(reader["bank_address1"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["bank_address2"])) { objIED_PAYMENTS.Bank_address2 = Convert.ToString(reader["bank_address2"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["bank_city"])) { objIED_PAYMENTS.Bank_city = Convert.ToString(reader["bank_city"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["bank_state_code"])) { objIED_PAYMENTS.Bank_state_code = Convert.ToString(reader["bank_state_code"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["bank_zip"])) { objIED_PAYMENTS.Bank_zip = Convert.ToString(reader["bank_zip"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["bank_state"])) { objIED_PAYMENTS.Bank_state = Convert.ToString(reader["bank_state"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Fld_Bank_No1"])) { objIED_PAYMENTS.Fld_Bank_No1 = Convert.ToString(reader["Fld_Bank_No1"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Fld_Bank_No2"])) { objIED_PAYMENTS.Fld_Bank_No2 = Convert.ToString(reader["Fld_Bank_No2"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["issue_date"])) { objIED_PAYMENTS.Issue_date = Convert.ToDateTime(reader["issue_date"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Amount"])) { objIED_PAYMENTS.Amount = Convert.ToDecimal(reader["Amount"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["payee_name"])) { objIED_PAYMENTS.Payee_name = Convert.ToString(reader["payee_name"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["payee_address1"])) { objIED_PAYMENTS.Payee_address1 = Convert.ToString(reader["payee_address1"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["payee_address2"])) { objIED_PAYMENTS.Payee_address2 = Convert.ToString(reader["payee_address2"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["employeer"])) { objIED_PAYMENTS.Employeer = Convert.ToString(reader["employeer"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["employee_name"])) { objIED_PAYMENTS.Employee_name = Convert.ToString(reader["employee_name"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["employee_ssn"])) { objIED_PAYMENTS.Employee_ssn = Convert.ToString(reader["employee_ssn"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["claim_no"])) { objIED_PAYMENTS.Claim_no = Convert.ToString(reader["claim_no"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["date_of_loss"])) { objIED_PAYMENTS.Date_of_loss = Convert.ToString(reader["date_of_loss"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["adjuster"])) { objIED_PAYMENTS.Adjuster = Convert.ToString(reader["adjuster"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["payment_type"])) { objIED_PAYMENTS.Payment_type = Convert.ToString(reader["payment_type"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["service_date_from"])) { objIED_PAYMENTS.Service_date_from = Convert.ToDateTime(reader["service_date_from"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["service_date_to"])) { objIED_PAYMENTS.Service_date_to = Convert.ToDateTime(reader["service_date_to"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["comments"])) { objIED_PAYMENTS.Comments = Convert.ToString(reader["comments"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["timeofloss"])) { objIED_PAYMENTS.Timeofloss = Convert.ToString(reader["timeofloss"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["check_no"])) { objIED_PAYMENTS.Check_no = Convert.ToString(reader["check_no"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Fld_AccountNo"])) { objIED_PAYMENTS.Fld_AccountNo = Convert.ToString(reader["Fld_AccountNo"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Fld_RoutingNo"])) { objIED_PAYMENTS.Fld_RoutingNo = Convert.ToString(reader["Fld_RoutingNo"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["check_fk"])) { objIED_PAYMENTS.Check_fk = Convert.ToDecimal(reader["check_fk"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Check_Writting_FK"])) { objIED_PAYMENTS.Check_Writting_FK = Convert.ToDecimal(reader["Check_Writting_FK"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Check_Status"])) { objIED_PAYMENTS.Check_Status = Convert.ToString(reader["Check_Status"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Stop_Delete_Date"])) { objIED_PAYMENTS.Stop_Delete_Date = Convert.ToDateTime(reader["Stop_Delete_Date"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Invoice_Number"])) { objIED_PAYMENTS.Invoice_Number = Convert.ToString(reader["Invoice_Number"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Void_Status"])) { objIED_PAYMENTS.Void_Status = Convert.ToInt32(reader["Void_Status"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Cleared_Bank"])) { objIED_PAYMENTS.Cleared_Bank = Convert.ToString(reader["Cleared_Bank"], CultureInfo.InvariantCulture); }
            return objIED_PAYMENTS;
        }




    }


}

