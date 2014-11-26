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


    public class cEmployee : RIMS_Base.cEmployee
    {

        public override int Employee_InsertUpdate(RIMS_Base.cEmployee Objoyee)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            int nRetVal = 0;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Emp_InsertUpdateoyee");
                dbHelper.AddParameter(cmd, "@PK_Employee_ID", DbType.Int32, ParameterDirection.InputOutput, "PK_Employee_ID", DataRowVersion.Current, Objoyee.PK_Employee_ID);
                dbHelper.AddInParameter(cmd, "@Employee_Id", DbType.String, Objoyee.Employee_Id);
                dbHelper.AddInParameter(cmd, "@Last_Name", DbType.String, Objoyee.Last_Name.Replace("'", "''"));
                dbHelper.AddInParameter(cmd, "@First_Name", DbType.String, Objoyee.First_Name.Replace("'", "''"));
                dbHelper.AddInParameter(cmd, "@Middle_Name", DbType.String, Objoyee.Middle_Name.Replace("'", "''"));
                dbHelper.AddInParameter(cmd, "@Employee_Address_1", DbType.String, Objoyee.Employee_Address_1.Replace("'", "''"));
                dbHelper.AddInParameter(cmd, "@Employee_Address_2", DbType.String, Objoyee.Employee_Address_2.Replace("'", "''"));
                dbHelper.AddInParameter(cmd, "@Employee_City", DbType.String, Objoyee.Employee_City.Replace("'", "''"));
                dbHelper.AddInParameter(cmd, "@Employee_State", DbType.Decimal, Objoyee.Employee_State);
                dbHelper.AddInParameter(cmd, "@Employee_Zip_Code", DbType.String, Objoyee.Employee_Zip_Code);
                dbHelper.AddInParameter(cmd, "@Employee_Home_Phone", DbType.String, Objoyee.Employee_Home_Phone);
                dbHelper.AddInParameter(cmd, "@Employee_Cell_Phone", DbType.String, Objoyee.Employee_Cell_Phone);
                dbHelper.AddInParameter(cmd, "@Social_Security_Number", DbType.String, Objoyee.Social_Security_Number);
                dbHelper.AddInParameter(cmd, "@FK_Marital_Status", DbType.Decimal, Objoyee.FK_Marital_Status);
                dbHelper.AddInParameter(cmd, "@Sex", DbType.String, Objoyee.Sex);
                dbHelper.AddInParameter(cmd, "@Number_Of_Dependents", DbType.Decimal, Objoyee.Number_Of_Dependents);
                dbHelper.AddInParameter(cmd, "@Date_Of_Birth", DbType.DateTime, Objoyee.Date_Of_Birth);
                dbHelper.AddInParameter(cmd, "@Date_Of_Death", DbType.DateTime, Objoyee.Date_Of_Death);
                dbHelper.AddInParameter(cmd, "@Drivers_License_State", DbType.String, Objoyee.Drivers_License_State);
                dbHelper.AddInParameter(cmd, "@Drivers_License_Number", DbType.String, Objoyee.Drivers_License_Number);
                dbHelper.AddInParameter(cmd, "@Drivers_License_Type", DbType.String, Objoyee.Drivers_License_Type);
                dbHelper.AddInParameter(cmd, "@Drivers_License_Class", DbType.String, Objoyee.Drivers_License_Class);
                dbHelper.AddInParameter(cmd, "@Drivers_License_Restrictions", DbType.String, Objoyee.Drivers_License_Restrictions);
                dbHelper.AddInParameter(cmd, "@Drivers_License_Endorsements", DbType.String, Objoyee.Drivers_License_Endorsements);
                dbHelper.AddInParameter(cmd, "@Drivers_License_Issued", DbType.DateTime, Objoyee.Drivers_License_Issued);
                dbHelper.AddInParameter(cmd, "@Drivers_License_Expires", DbType.DateTime, Objoyee.Drivers_License_Expires);
                dbHelper.AddInParameter(cmd, "@FK_Bank_Number", DbType.Decimal, Objoyee.FK_Bank_Number);
                dbHelper.AddInParameter(cmd, "@Job_Title", DbType.String, Objoyee.Job_Title);
                dbHelper.AddInParameter(cmd, "@Occupation_Description", DbType.String, Objoyee.Occupation_Description.Replace("'", "''"));
                dbHelper.AddInParameter(cmd, "@Salary", DbType.Decimal, Objoyee.Salary);
                dbHelper.AddInParameter(cmd, "@Supervisor", DbType.Decimal, Objoyee.Supervisor);
                dbHelper.AddInParameter(cmd, "@Hire_Date", DbType.DateTime, Objoyee.Hire_Date);
                dbHelper.AddInParameter(cmd, "@Work_Phone", DbType.String, Objoyee.Work_Phone);
                dbHelper.AddInParameter(cmd, "@Inactive", DbType.String, Objoyee.Inactive);
                dbHelper.AddInParameter(cmd, "@Updated_By", DbType.String, Objoyee.Updated_By);
                dbHelper.AddInParameter(cmd, "@Update_Date", DbType.DateTime, Objoyee.Update_Date);
                dbHelper.AddInParameter(cmd, "@FK_Job_Classification", DbType.Decimal, Objoyee.FK_Job_Classification);
                dbHelper.AddInParameter(cmd, "@FK_Cost_Center", DbType.Decimal, Objoyee.FK_Cost_Center);
                dbHelper.AddInParameter(cmd, "@Email", DbType.String, Objoyee.Email);
                dbHelper.ExecuteNonQuery(cmd);
                nRetVal = int.Parse(dbHelper.GetParameterValue(cmd, "@PK_Employee_ID").ToString());

                return nRetVal;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            { dbHelper = null; cmd.Dispose(); cmd = null; }
        }
        public override int Employee_Delete(System.String lPK_Employee_ID)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            int nRetVal = -1;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Employee_Delete");
                dbHelper.AddInParameter(cmd, "@PK_Employee_ID", DbType.String, lPK_Employee_ID);
                nRetVal = dbHelper.ExecuteNonQuery(cmd);
                dbHelper = null; cmd.Dispose(); cmd = null;
                return nRetVal;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public override string ActivateInactivateoyee(string strIDs, int intModifiedBy, bool bIsActive)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            int nRetVal = -1;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Emp_ActivateInactivateoyees");
                dbHelper.AddParameter(cmd, "@PK_Employee_IDs", DbType.String, ParameterDirection.InputOutput, "PK_Employee_IDs", DataRowVersion.Current, strIDs);
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
        public override List<RIMS_Base.cEmployee> GetAll()
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Employee_Select");
                IDataReader reader = dbHelper.ExecuteReader(cmd);
                List<RIMS_Base.cEmployee> results = new List<RIMS_Base.cEmployee>();
                while (reader.Read())
                {
                    cEmployee objoyee = new cEmployee();
                    objoyee = MapFrom(reader);
                    results.Add(objoyee);
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
        public override List<RIMS_Base.cEmployee> GetAll_State()
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Employee_SelectState");
                IDataReader reader = dbHelper.ExecuteReader(cmd);
                List<RIMS_Base.cEmployee> results = new List<RIMS_Base.cEmployee>();
                while (reader.Read())
                {
                    cEmployee objoyee = new cEmployee();
                    objoyee = MapFromState(reader);
                    results.Add(objoyee);
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
        public override List<RIMS_Base.cEmployee> GetEmployeeByID(System.Decimal pK_Employee_Id)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Employee_Select");
                dbHelper.AddInParameter(cmd, "@PK_Employee_Id", DbType.Decimal, pK_Employee_Id);
                IDataReader reader = dbHelper.ExecuteReader(cmd);
                List<RIMS_Base.cEmployee> results = new List<RIMS_Base.cEmployee>();
                while (reader.Read())
                {
                    cEmployee objoyee = new cEmployee();
                    objoyee = MapFrom(reader);
                    results.Add(objoyee);
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
        public override List<RIMS_Base.cEmployee> Get_Search_Data(System.String m_strColumn, System.String m_strCriteria)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Employee_Search_Data");
                dbHelper.AddInParameter(cmd, "@ColumnName", DbType.String, m_strColumn.Replace("'","''"));;
                dbHelper.AddInParameter(cmd, "@Criteria", DbType.String, m_strCriteria.Replace("'","''"));
                List<RIMS_Base.cEmployee> results = new List<RIMS_Base.cEmployee>();
                IDataReader reader = dbHelper.ExecuteReader(cmd);
                cEmployee objoyee = new cEmployee();
                while (reader.Read())
                {
                    objoyee = MapFrom(reader);
                    results.Add(objoyee);
                }
                reader.Close();
                cmd = null;
                dbHelper = null;
                return results;
                //return objoyee;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public override List<RIMS_Base.cEmployee> Get_Search_Data_State(string m_strColumn, string m_strCriteria)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Employee_Search_Data_State");
                dbHelper.AddInParameter(cmd, "@ColumnName", DbType.String, m_strColumn.Replace("'", "''")); ;
                dbHelper.AddInParameter(cmd, "@Criteria", DbType.String, m_strCriteria.Replace("'", "''"));
                List<RIMS_Base.cEmployee> results = new List<RIMS_Base.cEmployee>();
                IDataReader reader = dbHelper.ExecuteReader(cmd);
                cEmployee objoyee = new cEmployee();
                while (reader.Read())
                {
                    objoyee = MapFromState(reader);
                    results.Add(objoyee);
                }
                reader.Close();
                cmd = null;
                dbHelper = null;
                return results;
                //return objoyee;
            }
            catch (Exception)
            {
                throw;
            }   
        }
        public override List<RIMS_Base.cEmployee> Get_AdvanceSearch_Data(string LastName, string FirstName, string Address, string City, string State, string Zipcode, decimal Entity)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Employee_AdvanceSearch_Data");
                dbHelper.AddInParameter(cmd, "@LastName", DbType.String, LastName.Replace("'", "''"));
                dbHelper.AddInParameter(cmd, "@FirstName", DbType.String, FirstName.Replace("'", "''"));
                dbHelper.AddInParameter(cmd, "@Address", DbType.String, Address.Replace("'", "''"));
                dbHelper.AddInParameter(cmd, "@City", DbType.String, City.Replace("'", "''"));
                dbHelper.AddInParameter(cmd, "@State", DbType.String, State.Replace("'", "''"));
                dbHelper.AddInParameter(cmd, "@Zipcode", DbType.String, Zipcode.Replace("'", "''"));
                dbHelper.AddInParameter(cmd, "@Entity", DbType.Int32, Entity);
                List<RIMS_Base.cEmployee> results = new List<RIMS_Base.cEmployee>();
                IDataReader reader = dbHelper.ExecuteReader(cmd);
                cEmployee objoyee = new cEmployee();
                while (reader.Read())
                {
                    objoyee = MapFromState(reader);
                    results.Add(objoyee);
                }
                reader.Close();
                cmd = null;
                dbHelper = null;
                return results;
                //return objoyee;
            }
            catch (Exception)
            {
                throw;
            }   
        }             
        protected RIMS_Base.Dal.cEmployee MapFrom(IDataReader reader)
        {
            RIMS_Base.Dal.cEmployee objoyee = new RIMS_Base.Dal.cEmployee();
            if (!Convert.IsDBNull(reader["PK_Employee_ID"])) { objoyee.PK_Employee_ID = Convert.ToInt32(reader["PK_Employee_ID"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Employee_Id"])) { objoyee.Employee_Id = Convert.ToString(reader["Employee_Id"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Last_Name"])) { objoyee.Last_Name = Convert.ToString(reader["Last_Name"], CultureInfo.InvariantCulture).Replace("''", "'"); }
            if (!Convert.IsDBNull(reader["First_Name"])) { objoyee.First_Name = Convert.ToString(reader["First_Name"], CultureInfo.InvariantCulture).Replace("''", "'"); }
            if (!Convert.IsDBNull(reader["Middle_Name"])) { objoyee.Middle_Name = Convert.ToString(reader["Middle_Name"], CultureInfo.InvariantCulture).Replace("''", "'"); }
            if (!Convert.IsDBNull(reader["Employee_Address_1"])) { objoyee.Employee_Address_1 = Convert.ToString(reader["Employee_Address_1"], CultureInfo.InvariantCulture).Replace("''", "'"); }
            if (!Convert.IsDBNull(reader["Employee_Address_2"])) { objoyee.Employee_Address_2 = Convert.ToString(reader["Employee_Address_2"], CultureInfo.InvariantCulture).Replace("''", "'"); }
            if (!Convert.IsDBNull(reader["Employee_City"])) { objoyee.Employee_City = Convert.ToString(reader["Employee_City"], CultureInfo.InvariantCulture).Replace("''", "'"); }
            if (!Convert.IsDBNull(reader["Employee_State"])) { objoyee.Employee_State = Convert.ToDecimal(reader["Employee_State"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Employee_Zip_Code"])) { objoyee.Employee_Zip_Code = Convert.ToString(reader["Employee_Zip_Code"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Employee_Home_Phone"])) { objoyee.Employee_Home_Phone = Convert.ToString(reader["Employee_Home_Phone"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Employee_Cell_Phone"])) { objoyee.Employee_Cell_Phone = Convert.ToString(reader["Employee_Cell_Phone"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Social_Security_Number"])) { objoyee.Social_Security_Number = Convert.ToString(reader["Social_Security_Number"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FK_Marital_Status"])) { objoyee.FK_Marital_Status = Convert.ToDecimal(reader["FK_Marital_Status"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Sex"])) { objoyee.Sex = Convert.ToString(reader["Sex"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Number_Of_Dependents"])) { objoyee.Number_Of_Dependents = Convert.ToDecimal(reader["Number_Of_Dependents"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Date_Of_Birth"])) { objoyee.Date_Of_Birth = Convert.ToDateTime(reader["Date_Of_Birth"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Date_Of_Death"])) { objoyee.Date_Of_Death = Convert.ToDateTime(reader["Date_Of_Death"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Drivers_License_State"])) { objoyee.Drivers_License_State = Convert.ToString(reader["Drivers_License_State"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Drivers_License_Number"])) { objoyee.Drivers_License_Number = Convert.ToString(reader["Drivers_License_Number"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Drivers_License_Type"])) { objoyee.Drivers_License_Type = Convert.ToString(reader["Drivers_License_Type"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Drivers_License_Class"])) { objoyee.Drivers_License_Class = Convert.ToString(reader["Drivers_License_Class"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Drivers_License_Restrictions"])) { objoyee.Drivers_License_Restrictions = Convert.ToString(reader["Drivers_License_Restrictions"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Drivers_License_Endorsements"])) { objoyee.Drivers_License_Endorsements = Convert.ToString(reader["Drivers_License_Endorsements"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Drivers_License_Issued"])) { objoyee.Drivers_License_Issued = Convert.ToDateTime(reader["Drivers_License_Issued"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Drivers_License_Expires"])) { objoyee.Drivers_License_Expires = Convert.ToDateTime(reader["Drivers_License_Expires"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FK_Bank_Number"])) { objoyee.FK_Bank_Number = Convert.ToDecimal(reader["FK_Bank_Number"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Job_Title"])) { objoyee.Job_Title = Convert.ToString(reader["Job_Title"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Occupation_Description"])) { objoyee.Occupation_Description = Convert.ToString(reader["Occupation_Description"], CultureInfo.InvariantCulture).Replace("''", "'"); }
            if (!Convert.IsDBNull(reader["Salary"])) { objoyee.Salary = Convert.ToDecimal(reader["Salary"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Supervisor"])) { objoyee.Supervisor = Convert.ToDecimal(reader["Supervisor"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Hire_Date"])) { objoyee.Hire_Date = Convert.ToDateTime(reader["Hire_Date"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Work_Phone"])) { objoyee.Work_Phone = Convert.ToString(reader["Work_Phone"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Inactive"])) { objoyee.Inactive = Convert.ToString(reader["Inactive"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Updated_By"])) { objoyee.Updated_By = Convert.ToString(reader["Updated_By"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Update_Date"])) { objoyee.Update_Date = Convert.ToDateTime(reader["Update_Date"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FK_Job_Classification"])) { objoyee.FK_Job_Classification = Convert.ToDecimal(reader["FK_Job_Classification"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FK_Cost_Center"])) { objoyee.FK_Cost_Center = Convert.ToDecimal(reader["FK_Cost_Center"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Email"])) { objoyee.Email = Convert.ToString(reader["Email"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["JobClassification"])) { objoyee.JobClassfication = Convert.ToString(reader["JobClassification"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["SupFirstName"])) { objoyee.SupFirstName = Convert.ToString(reader["SupFirstName"], CultureInfo.InvariantCulture).Replace("''", "'"); }
            if (!Convert.IsDBNull(reader["SupLastName"])) { objoyee.SupLastName = Convert.ToString(reader["SupLastName"], CultureInfo.InvariantCulture).Replace("''", "'"); }
            if (!Convert.IsDBNull(reader["SupMiddleName"])) { objoyee.SupMiddleName = Convert.ToString(reader["SupMiddleName"], CultureInfo.InvariantCulture).Replace("''", "'"); }
            if (!Convert.IsDBNull(reader["Cost_Center"])) { objoyee.Cost_Center = Convert.ToString(reader["Cost_Center"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["CCAddress"])) { objoyee.CCAddress = Convert.ToString(reader["CCAddress"], CultureInfo.InvariantCulture).Replace("''", "'"); }
            if (!Convert.IsDBNull(reader["Fld_State"])) { objoyee.FldState = Convert.ToString(reader["Fld_State"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["MaritalStatus"])) { objoyee.MaritalStatus = Convert.ToString(reader["MaritalStatus"], CultureInfo.InvariantCulture); }           
            return objoyee;
        }
        protected RIMS_Base.Dal.cEmployee MapFromState(IDataReader reader)
        {
            RIMS_Base.Dal.cEmployee objoyee = new RIMS_Base.Dal.cEmployee();
            if (!Convert.IsDBNull(reader["PK_Employee_ID"])) { objoyee.PK_Employee_ID = Convert.ToInt32(reader["PK_Employee_ID"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Employee_Id"])) { objoyee.Employee_Id = Convert.ToString(reader["Employee_Id"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Last_Name"])) { objoyee.Last_Name = Convert.ToString(reader["Last_Name"], CultureInfo.InvariantCulture).Replace("''", "'"); }
            if (!Convert.IsDBNull(reader["First_Name"])) { objoyee.First_Name = Convert.ToString(reader["First_Name"], CultureInfo.InvariantCulture).Replace("''", "'"); }
            if (!Convert.IsDBNull(reader["Middle_Name"])) { objoyee.Middle_Name = Convert.ToString(reader["Middle_Name"], CultureInfo.InvariantCulture).Replace("''", "'"); }
            if (!Convert.IsDBNull(reader["Employee_Address_1"])) { objoyee.Employee_Address_1 = Convert.ToString(reader["Employee_Address_1"], CultureInfo.InvariantCulture).Replace("''", "'"); }
            if (!Convert.IsDBNull(reader["Employee_Address_2"])) { objoyee.Employee_Address_2 = Convert.ToString(reader["Employee_Address_2"], CultureInfo.InvariantCulture).Replace("''", "'"); }
            if (!Convert.IsDBNull(reader["Employee_City"])) { objoyee.Employee_City = Convert.ToString(reader["Employee_City"], CultureInfo.InvariantCulture).Replace("''", "'"); }
            if (!Convert.IsDBNull(reader["Employee_State"])) { objoyee.Employee_State = Convert.ToDecimal(reader["Employee_State"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Employee_Zip_Code"])) { objoyee.Employee_Zip_Code = Convert.ToString(reader["Employee_Zip_Code"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Employee_Home_Phone"])) { objoyee.Employee_Home_Phone = Convert.ToString(reader["Employee_Home_Phone"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Employee_Cell_Phone"])) { objoyee.Employee_Cell_Phone = Convert.ToString(reader["Employee_Cell_Phone"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Social_Security_Number"])) { objoyee.Social_Security_Number = Convert.ToString(reader["Social_Security_Number"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FK_Marital_Status"])) { objoyee.FK_Marital_Status = Convert.ToDecimal(reader["FK_Marital_Status"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Sex"])) { objoyee.Sex = Convert.ToString(reader["Sex"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Number_Of_Dependents"])) { objoyee.Number_Of_Dependents = Convert.ToDecimal(reader["Number_Of_Dependents"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Date_Of_Birth"])) { objoyee.Date_Of_Birth = Convert.ToDateTime(reader["Date_Of_Birth"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Date_Of_Death"])) { objoyee.Date_Of_Death = Convert.ToDateTime(reader["Date_Of_Death"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Drivers_License_State"])) { objoyee.Drivers_License_State = Convert.ToString(reader["Drivers_License_State"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Drivers_License_Number"])) { objoyee.Drivers_License_Number = Convert.ToString(reader["Drivers_License_Number"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Drivers_License_Type"])) { objoyee.Drivers_License_Type = Convert.ToString(reader["Drivers_License_Type"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Drivers_License_Class"])) { objoyee.Drivers_License_Class = Convert.ToString(reader["Drivers_License_Class"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Drivers_License_Restrictions"])) { objoyee.Drivers_License_Restrictions = Convert.ToString(reader["Drivers_License_Restrictions"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Drivers_License_Endorsements"])) { objoyee.Drivers_License_Endorsements = Convert.ToString(reader["Drivers_License_Endorsements"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Drivers_License_Issued"])) { objoyee.Drivers_License_Issued = Convert.ToDateTime(reader["Drivers_License_Issued"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Drivers_License_Expires"])) { objoyee.Drivers_License_Expires = Convert.ToDateTime(reader["Drivers_License_Expires"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FK_Bank_Number"])) { objoyee.FK_Bank_Number = Convert.ToDecimal(reader["FK_Bank_Number"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Job_Title"])) { objoyee.Job_Title = Convert.ToString(reader["Job_Title"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Occupation_Description"])) { objoyee.Occupation_Description = Convert.ToString(reader["Occupation_Description"], CultureInfo.InvariantCulture).Replace("''", "'"); }
            if (!Convert.IsDBNull(reader["Salary"])) { objoyee.Salary = Convert.ToDecimal(reader["Salary"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Supervisor"])) { objoyee.Supervisor = Convert.ToDecimal(reader["Supervisor"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Hire_Date"])) { objoyee.Hire_Date = Convert.ToDateTime(reader["Hire_Date"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Work_Phone"])) { objoyee.Work_Phone = Convert.ToString(reader["Work_Phone"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Inactive"])) { objoyee.Inactive = Convert.ToString(reader["Inactive"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Updated_By"])) { objoyee.Updated_By = Convert.ToString(reader["Updated_By"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Update_Date"])) { objoyee.Update_Date = Convert.ToDateTime(reader["Update_Date"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FK_Job_Classification"])) { objoyee.FK_Job_Classification = Convert.ToDecimal(reader["FK_Job_Classification"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FK_Cost_Center"])) { objoyee.FK_Cost_Center = Convert.ToDecimal(reader["FK_Cost_Center"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Email"])) { objoyee.Email = Convert.ToString(reader["Email"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["JobClassification"])) { objoyee.JobClassfication = Convert.ToString(reader["JobClassification"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["SupFirstName"])) { objoyee.SupFirstName = Convert.ToString(reader["SupFirstName"], CultureInfo.InvariantCulture).Replace("''", "'"); }
            if (!Convert.IsDBNull(reader["SupLastName"])) { objoyee.SupLastName = Convert.ToString(reader["SupLastName"], CultureInfo.InvariantCulture).Replace("''", "'"); }
            if (!Convert.IsDBNull(reader["SupMiddleName"])) { objoyee.SupMiddleName = Convert.ToString(reader["SupMiddleName"], CultureInfo.InvariantCulture).Replace("''", "'"); }
            if (!Convert.IsDBNull(reader["Cost_Center"])) { objoyee.Cost_Center = Convert.ToString(reader["Cost_Center"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["CCAddress"])) { objoyee.CCAddress = Convert.ToString(reader["CCAddress"], CultureInfo.InvariantCulture).Replace("''", "'"); }
            if (!Convert.IsDBNull(reader["Fld_State"])) { objoyee.FldState = Convert.ToString(reader["Fld_State"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["MaritalStatus"])) { objoyee.MaritalStatus = Convert.ToString(reader["MaritalStatus"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["StateName"])) { objoyee.StateName = Convert.ToString(reader["StateName"], CultureInfo.InvariantCulture); }
            return objoyee;
        }
        public override List<RIMS_Base.cEmployee> GetMaritalStatus()
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("[Select_MaritalStatus]");
                IDataReader reader = dbHelper.ExecuteReader(cmd);
                List<RIMS_Base.cEmployee> results = new List<RIMS_Base.cEmployee>();
                while (reader.Read())
                {
                    cEmployee obje = new cEmployee();
                    obje = MapFromMaritalStatus(reader);
                    results.Add(obje);
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
        public override List<RIMS_Base.cEmployee> GetLicenseType()
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("[Select_LicenseType]");
                IDataReader reader = dbHelper.ExecuteReader(cmd);
                List<RIMS_Base.cEmployee> results = new List<RIMS_Base.cEmployee>();
                while (reader.Read())
                {
                    cEmployee obje = new cEmployee();
                    obje = MapFromLicenseType(reader);
                    results.Add(obje);
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
        public override List<RIMS_Base.cEmployee> GetJobClassfication()
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("[Select_JobClassification]");
                IDataReader reader = dbHelper.ExecuteReader(cmd);
                List<RIMS_Base.cEmployee> results = new List<RIMS_Base.cEmployee>();
                while (reader.Read())
                {
                    cEmployee obje = new cEmployee();
                    obje = MapFromJobClassification(reader);
                    results.Add(obje);
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
        protected RIMS_Base.Dal.cEmployee MapFromMaritalStatus(IDataReader reader)
        {
            RIMS_Base.Dal.cEmployee obj_Type = new RIMS_Base.Dal.cEmployee();
            if (!Convert.IsDBNull(reader["PK_ID"])) { obj_Type.FK_Marital_Status = Convert.ToInt32(reader["PK_ID"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FLD_Desc"])) { obj_Type.MaritalStatus = Convert.ToString(reader["FLD_Desc"], CultureInfo.InvariantCulture); }
            return obj_Type;
        }
        protected RIMS_Base.Dal.cEmployee MapFromLicenseType(IDataReader reader)
        {
            RIMS_Base.Dal.cEmployee obj_Type = new RIMS_Base.Dal.cEmployee();
            if (!Convert.IsDBNull(reader["FLD_Desc"])) { obj_Type.Drivers_License_Type = Convert.ToString(reader["FLD_Desc"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FLD_Desc"])) { obj_Type.LicenseType = Convert.ToString(reader["FLD_Desc"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["PK_ID"])) { obj_Type.PK_ID = Convert.ToDecimal(reader["PK_ID"], CultureInfo.InvariantCulture); }
            return obj_Type;
        }
        protected RIMS_Base.Dal.cEmployee MapFromJobClassification(IDataReader reader)
        {
            RIMS_Base.Dal.cEmployee obj_Type = new RIMS_Base.Dal.cEmployee();
            if (!Convert.IsDBNull(reader["PK_ID"])) { obj_Type.FK_Job_Classification = Convert.ToInt32(reader["PK_ID"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FLD_Desc"])) { obj_Type.JobClassfication = Convert.ToString(reader["FLD_Desc"], CultureInfo.InvariantCulture); }
            return obj_Type;
        }



        public override List<RIMS_Base.cEmployee> GetAutoPopulateEmployeeId()
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Select_EmployeeAutoID");
                IDataReader reader = dbHelper.ExecuteReader(cmd);
                List<RIMS_Base.cEmployee> results = new List<RIMS_Base.cEmployee>();
                while (reader.Read())
                {
                    cEmployee objoyee = new cEmployee();
                    objoyee = MapFromAuto(reader);
                    results.Add(objoyee);
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


        protected RIMS_Base.Dal.cEmployee MapFromAuto(IDataReader reader)
        {
            RIMS_Base.Dal.cEmployee objoyee = new RIMS_Base.Dal.cEmployee();
            if (!Convert.IsDBNull(reader["Employee_Id"])) { objoyee.Employee_Id = Convert.ToString(reader["Employee_Id"], CultureInfo.InvariantCulture); }
            return objoyee;
        }


    }


}

