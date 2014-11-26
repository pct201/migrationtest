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


    public class CCheckRegister : RIMS_Base.CCheckRegister
    {

        public override int InsertUpdateCheckRegister(RIMS_Base.CCheckRegister Objk_Register)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            int nRetVal = -1;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Che_InsertUpdatek_Register");
                dbHelper.AddParameter(cmd, "@PK_Check_Register", DbType.Decimal, ParameterDirection.InputOutput, "PK_Check_Register", DataRowVersion.Current, Objk_Register.PK_Check_Register);
                dbHelper.AddInParameter(cmd, "@Table_Name", DbType.String, Objk_Register.Table_Name);
                dbHelper.AddInParameter(cmd, "@FK_Table_Name", DbType.Decimal, Objk_Register.FK_Table_Name);
                dbHelper.AddInParameter(cmd, "@Last_Reserve_Change", DbType.DateTime, Objk_Register.Last_Reserve_Change);
                dbHelper.AddInParameter(cmd, "@Indemnity_Incurred", DbType.Decimal, Objk_Register.Indemnity_Incurred);
                dbHelper.AddInParameter(cmd, "@Indemnity_Paid", DbType.Decimal, Objk_Register.Indemnity_Paid);
                dbHelper.AddInParameter(cmd, "@Indemnity_Outstanding", DbType.Decimal, Objk_Register.Indemnity_Outstanding);
                dbHelper.AddInParameter(cmd, "@Indemnity_Current_Month", DbType.Decimal, Objk_Register.Indemnity_Current_Month);
                dbHelper.AddInParameter(cmd, "@Medical_Incurred", DbType.Decimal, Objk_Register.Medical_Incurred);
                dbHelper.AddInParameter(cmd, "@Medical_Paid", DbType.Decimal, Objk_Register.Medical_Paid);
                dbHelper.AddInParameter(cmd, "@Medical_Outstanding", DbType.Decimal, Objk_Register.Medical_Outstanding);
                dbHelper.AddInParameter(cmd, "@Medical_Current_Month", DbType.Decimal, Objk_Register.Medical_Current_Month);
                dbHelper.AddInParameter(cmd, "@Expense_Incurred", DbType.Decimal, Objk_Register.Expense_Incurred);
                dbHelper.AddInParameter(cmd, "@Expense_Paid", DbType.Decimal, Objk_Register.Expense_Paid);
                dbHelper.AddInParameter(cmd, "@Expense_Outstanding", DbType.Decimal, Objk_Register.Expense_Outstanding);
                dbHelper.AddInParameter(cmd, "@Expense_Current_Month", DbType.Decimal, Objk_Register.Expense_Current_Month);
                dbHelper.ExecuteNonQuery(cmd);
                nRetVal = int.Parse(dbHelper.GetParameterValue(cmd, "@PK_Check_Register").ToString());
                dbHelper = null; cmd.Dispose(); cmd = null;
                return nRetVal;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            { dbHelper = null; cmd.Dispose(); cmd = null; }
        }
        public override int DeleteCheckRegister(System.Decimal lPK_Check_Register)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            int nRetVal = -1;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Che_Deletek_Register");
                dbHelper.AddInParameter(cmd, "@PK_Check_Register", DbType.Decimal, lPK_Check_Register);
                nRetVal = dbHelper.ExecuteNonQuery(cmd);
                dbHelper = null; cmd.Dispose(); cmd = null;
                return nRetVal;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public override string ActivateInactivCheckRegister(string strIDs, int intModifiedBy, bool bIsActive)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            int nRetVal = -1;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Che_ActivateInactivatek_Registers");
                dbHelper.AddParameter(cmd, "@PK_Check_Registers", DbType.String, ParameterDirection.InputOutput, "PK_Check_Registers", DataRowVersion.Current, strIDs);
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
        public override List<RIMS_Base.CCheckRegister> GetAll()
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Che_Selectk_Register");
                IDataReader reader = dbHelper.ExecuteReader(cmd);
                List<RIMS_Base.CCheckRegister> results = new List<RIMS_Base.CCheckRegister>();
                while (reader.Read())
                {
                    CCheckRegister objk_Register = new CCheckRegister();
                    objk_Register = MapFrom(reader);
                    results.Add(objk_Register);
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


        public override List<RIMS_Base.CCheckRegister> GetCheckRegisterByID(System.Decimal Fk_Table_Name, System.String Table_Name)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("CheckRegister_Select");
                dbHelper.AddInParameter(cmd, "@FK_Table_Name", DbType.Decimal, Fk_Table_Name);
                dbHelper.AddInParameter(cmd, "@Table_Name", DbType.String, Table_Name);
                List<RIMS_Base.CCheckRegister> results = new List<RIMS_Base.CCheckRegister>();
                IDataReader reader = dbHelper.ExecuteReader(cmd);
                CCheckRegister objk_Register = new CCheckRegister();
                if (reader.Read())
                {
                    objk_Register = MapFrom(reader);
                    results.Add(objk_Register);
                }
                reader.Close();
                cmd = null;
                dbHelper = null;

                //return objk_Register;
                return results;
            }
            catch (Exception)
            {
                throw;
            }
        }


        protected RIMS_Base.Dal.CCheckRegister MapFrom(IDataReader reader)
        {
            RIMS_Base.Dal.CCheckRegister objk_Register = new RIMS_Base.Dal.CCheckRegister();
            if (!Convert.IsDBNull(reader["PK_Check_Register"])) { objk_Register.PK_Check_Register = Convert.ToDecimal(reader["PK_Check_Register"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Table_Name"])) { objk_Register.Table_Name = Convert.ToString(reader["Table_Name"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FK_Table_Name"])) { objk_Register.FK_Table_Name = Convert.ToDecimal(reader["FK_Table_Name"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Last_Reserve_Change"])) { objk_Register.Last_Reserve_Change = Convert.ToDateTime(reader["Last_Reserve_Change"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Indemnity_Incurred"])) { objk_Register.Indemnity_Incurred = Convert.ToDecimal(reader["Indemnity_Incurred"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Indemnity_Paid"])) { objk_Register.Indemnity_Paid = Convert.ToDecimal(reader["Indemnity_Paid"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Indemnity_Outstanding"])) { objk_Register.Indemnity_Outstanding = Convert.ToDecimal(reader["Indemnity_Outstanding"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Indemnity_Current_Month"])) { objk_Register.Indemnity_Current_Month = Convert.ToDecimal(reader["Indemnity_Current_Month"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Medical_Incurred"])) { objk_Register.Medical_Incurred = Convert.ToDecimal(reader["Medical_Incurred"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Medical_Paid"])) { objk_Register.Medical_Paid = Convert.ToDecimal(reader["Medical_Paid"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Medical_Outstanding"])) { objk_Register.Medical_Outstanding = Convert.ToDecimal(reader["Medical_Outstanding"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Medical_Current_Month"])) { objk_Register.Medical_Current_Month = Convert.ToDecimal(reader["Medical_Current_Month"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Expense_Incurred"])) { objk_Register.Expense_Incurred = Convert.ToDecimal(reader["Expense_Incurred"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Expense_Paid"])) { objk_Register.Expense_Paid = Convert.ToDecimal(reader["Expense_Paid"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Expense_Outstanding"])) { objk_Register.Expense_Outstanding = Convert.ToDecimal(reader["Expense_Outstanding"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Expense_Current_Month"])) { objk_Register.Expense_Current_Month = Convert.ToDecimal(reader["Expense_Current_Month"], CultureInfo.InvariantCulture); }
            return objk_Register;
        }




    }


}

