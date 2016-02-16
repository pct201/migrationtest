using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
    /// <summary>
    /// Data access class for Employee table.
    /// </summary>
    public sealed class Employee
    {
        #region Fields

        private decimal _PK_Employee_ID;
        private string _Employee_Id;
        private string _Last_Name;
        private string _First_Name;
        private string _Middle_Name;
        private string _Employee_Address_1;
        private string _Employee_Address_2;
        private string _Employee_City;
        private decimal? _Employee_State;
        private string _Employee_Zip_Code;
        private string _Employee_Home_Phone;
        private string _Employee_Cell_Phone;
        private string _Social_Security_Number;
        private decimal? _FK_Marital_Status;
        private string _Sex;
        private decimal? _Number_Of_Dependents;
        private DateTime? _Date_Of_Birth;
        private DateTime? _Date_Of_Death;
        private string _Drivers_License_State;
        private string _Drivers_License_Number;
        private string _Drivers_License_Type;
        private string _Drivers_License_Class;
        private string _Drivers_License_Restrictions;
        private string _Drivers_License_Endorsements;
        private DateTime? _Drivers_License_Issued;
        private DateTime? _Drivers_License_Expires;
        private decimal? _FK_Bank_Number;
        private string _Job_Title;
        private string _Occupation_Description;
        private decimal? _Salary;
        private string _Frequency;
        private decimal? _Wages_YTD;
        private string _Supervisor;
        private DateTime? _Hire_Date;
        private string _Work_Phone;
        private string _Active_Inactive_Leave;
        private string _Inactive;
        private string _Updated_By;
        private DateTime? _Update_Date;
        private decimal? _FK_Job_Classification;
        private decimal? _FK_Cost_Center;
        private string _Email;
        private string _Department;

        #endregion


        #region Public Property

        /// <summary>
        /// Gets or sets the PK_Employee_ID value.
        /// </summary>
        public decimal PK_Employee_ID
        {
            get { return _PK_Employee_ID; }
            set { _PK_Employee_ID = value; }
        }

        /// <summary>
        /// Gets or sets the Employee_Id value.
        /// </summary>
        public string Employee_Id
        {
            get { return _Employee_Id; }
            set { _Employee_Id = value; }
        }

        /// <summary>
        /// Gets or sets the Last_Name value.
        /// </summary>
        public string Last_Name
        {
            get { return _Last_Name; }
            set { _Last_Name = value; }
        }

        /// <summary>
        /// Gets or sets the First_Name value.
        /// </summary>
        public string First_Name
        {
            get { return _First_Name; }
            set { _First_Name = value; }
        }

        /// <summary>
        /// Gets or sets the Middle_Name value.
        /// </summary>
        public string Middle_Name
        {
            get { return _Middle_Name; }
            set { _Middle_Name = value; }
        }

        /// <summary>
        /// Gets or sets the Employee_Address_1 value.
        /// </summary>
        public string Employee_Address_1
        {
            get { return _Employee_Address_1; }
            set { _Employee_Address_1 = value; }
        }

        /// <summary>
        /// Gets or sets the Employee_Address_2 value.
        /// </summary>
        public string Employee_Address_2
        {
            get { return _Employee_Address_2; }
            set { _Employee_Address_2 = value; }
        }

        /// <summary>
        /// Gets or sets the Employee_City value.
        /// </summary>
        public string Employee_City
        {
            get { return _Employee_City; }
            set { _Employee_City = value; }
        }

        /// <summary>
        /// Gets or sets the Employee_State value.
        /// </summary>
        public decimal? Employee_State
        {
            get { return _Employee_State; }
            set { _Employee_State = value; }
        }

        /// <summary>
        /// Gets or sets the Employee_Zip_Code value.
        /// </summary>
        public string Employee_Zip_Code
        {
            get { return _Employee_Zip_Code; }
            set { _Employee_Zip_Code = value; }
        }

        /// <summary>
        /// Gets or sets the Employee_Home_Phone value.
        /// </summary>
        public string Employee_Home_Phone
        {
            get { return _Employee_Home_Phone; }
            set { _Employee_Home_Phone = value; }
        }

        /// <summary>
        /// Gets or sets the Employee_Cell_Phone value.
        /// </summary>
        public string Employee_Cell_Phone
        {
            get { return _Employee_Cell_Phone; }
            set { _Employee_Cell_Phone = value; }
        }

        /// <summary>
        /// Gets or sets the Social_Security_Number value.
        /// </summary>
        public string Social_Security_Number
        {
            get { return _Social_Security_Number; }
            set { _Social_Security_Number = value; }
        }

        /// <summary>
        /// Gets or sets the FK_Marital_Status value.
        /// </summary>
        public decimal? FK_Marital_Status
        {
            get { return _FK_Marital_Status; }
            set { _FK_Marital_Status = value; }
        }

        /// <summary>
        /// Gets or sets the Sex value.
        /// </summary>
        public string Sex
        {
            get { return _Sex; }
            set { _Sex = value; }
        }

        /// <summary>
        /// Gets or sets the Number_Of_Dependents value.
        /// </summary>
        public decimal? Number_Of_Dependents
        {
            get { return _Number_Of_Dependents; }
            set { _Number_Of_Dependents = value; }
        }

        /// <summary>
        /// Gets or sets the Date_Of_Birth value.
        /// </summary>
        public DateTime? Date_Of_Birth
        {
            get { return _Date_Of_Birth; }
            set { _Date_Of_Birth = value; }
        }

        /// <summary>
        /// Gets or sets the Date_Of_Death value.
        /// </summary>
        public DateTime? Date_Of_Death
        {
            get { return _Date_Of_Death; }
            set { _Date_Of_Death = value; }
        }

        /// <summary>
        /// Gets or sets the Drivers_License_State value.
        /// </summary>
        public string Drivers_License_State
        {
            get { return _Drivers_License_State; }
            set { _Drivers_License_State = value; }
        }

        /// <summary>
        /// Gets or sets the Drivers_License_Number value.
        /// </summary>
        public string Drivers_License_Number
        {
            get { return _Drivers_License_Number; }
            set { _Drivers_License_Number = value; }
        }

        /// <summary>
        /// Gets or sets the Drivers_License_Type value.
        /// </summary>
        public string Drivers_License_Type
        {
            get { return _Drivers_License_Type; }
            set { _Drivers_License_Type = value; }
        }

        /// <summary>
        /// Gets or sets the Drivers_License_Class value.
        /// </summary>
        public string Drivers_License_Class
        {
            get { return _Drivers_License_Class; }
            set { _Drivers_License_Class = value; }
        }

        /// <summary>
        /// Gets or sets the Drivers_License_Restrictions value.
        /// </summary>
        public string Drivers_License_Restrictions
        {
            get { return _Drivers_License_Restrictions; }
            set { _Drivers_License_Restrictions = value; }
        }

        /// <summary>
        /// Gets or sets the Drivers_License_Endorsements value.
        /// </summary>
        public string Drivers_License_Endorsements
        {
            get { return _Drivers_License_Endorsements; }
            set { _Drivers_License_Endorsements = value; }
        }

        /// <summary>
        /// Gets or sets the Drivers_License_Issued value.
        /// </summary>
        public DateTime? Drivers_License_Issued
        {
            get { return _Drivers_License_Issued; }
            set { _Drivers_License_Issued = value; }
        }

        /// <summary>
        /// Gets or sets the Drivers_License_Expires value.
        /// </summary>
        public DateTime? Drivers_License_Expires
        {
            get { return _Drivers_License_Expires; }
            set { _Drivers_License_Expires = value; }
        }

        /// <summary>
        /// Gets or sets the FK_Bank_Number value.
        /// </summary>
        public decimal? FK_Bank_Number
        {
            get { return _FK_Bank_Number; }
            set { _FK_Bank_Number = value; }
        }

        /// <summary>
        /// Gets or sets the Job_Title value.
        /// </summary>
        public string Job_Title
        {
            get { return _Job_Title; }
            set { _Job_Title = value; }
        }

        /// <summary>
        /// Gets or sets the Occupation_Description value.
        /// </summary>
        public string Occupation_Description
        {
            get { return _Occupation_Description; }
            set { _Occupation_Description = value; }
        }

        /// <summary>
        /// Gets or sets the Salary value.
        /// </summary>
        public decimal? Salary
        {
            get { return _Salary; }
            set { _Salary = value; }
        }

        /// <summary>
        /// Gets or sets the Frequency value.
        /// </summary>
        public string Frequency
        {
            get { return _Frequency; }
            set { _Frequency = value; }
        }

        /// <summary>
        /// Gets or sets the Wages_YTD value.
        /// </summary>
        public decimal? Wages_YTD
        {
            get { return _Wages_YTD; }
            set { _Wages_YTD = value; }
        }

        /// <summary>
        /// Gets or sets the Supervisor value.
        /// </summary>
        public string Supervisor
        {
            get { return _Supervisor; }
            set { _Supervisor = value; }
        }

        /// <summary>
        /// Gets or sets the Hire_Date value.
        /// </summary>
        public DateTime? Hire_Date
        {
            get { return _Hire_Date; }
            set { _Hire_Date = value; }
        }

        /// <summary>
        /// Gets or sets the Work_Phone value.
        /// </summary>
        public string Work_Phone
        {
            get { return _Work_Phone; }
            set { _Work_Phone = value; }
        }

        /// <summary>
        /// Gets or sets the Active_Inactive_Leave value.
        /// </summary>
        public string Active_Inactive_Leave
        {
            get { return _Active_Inactive_Leave; }
            set { _Active_Inactive_Leave = value; }
        }

        /// <summary>
        /// Gets or sets the Inactive value.
        /// </summary>
        public string Inactive
        {
            get { return _Inactive; }
            set { _Inactive = value; }
        }

        /// <summary>
        /// Gets or sets the Updated_By value.
        /// </summary>
        public string Updated_By
        {
            get { return _Updated_By; }
            set { _Updated_By = value; }
        }

        /// <summary>
        /// Gets or sets the Update_Date value.
        /// </summary>
        public DateTime? Update_Date
        {
            get { return _Update_Date; }
            set { _Update_Date = value; }
        }

        /// <summary>
        /// Gets or sets the FK_Job_Classification value.
        /// </summary>
        public decimal? FK_Job_Classification
        {
            get { return _FK_Job_Classification; }
            set { _FK_Job_Classification = value; }
        }

        /// <summary>
        /// Gets or sets the FK_Cost_Center value.
        /// </summary>
        public decimal? FK_Cost_Center
        {
            get { return _FK_Cost_Center; }
            set { _FK_Cost_Center = value; }
        }

        /// <summary>
        /// Gets or sets the Email value.
        /// </summary>
        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }

        /// <summary>
        /// Gets or sets the Department value.
        /// </summary>
        public string Department
        {
            get { return _Department; }
            set { _Department = value; }
        }


        #endregion



        #region Constructors

        /// <summary> 
        /// Initializes a new instance of the Employee class. with the default value.
        /// </summary>
        public Employee()
        {
            this._PK_Employee_ID = -1;
            this._Employee_Id = null;
            this._Last_Name = null;
            this._First_Name = null;
            this._Middle_Name = null;
            this._Employee_Address_1 = null;
            this._Employee_Address_2 = null;
            this._Employee_City = null;
            this._Employee_State = null;
            this._Employee_Zip_Code = null;
            this._Employee_Home_Phone = null;
            this._Employee_Cell_Phone = null;
            this._Social_Security_Number = null;
            this._FK_Marital_Status = null;
            this._Sex = null;
            this._Number_Of_Dependents = null;
            this._Date_Of_Birth = null;
            this._Date_Of_Death = null;
            this._Drivers_License_State = null;
            this._Drivers_License_Number = null;
            this._Drivers_License_Type = null;
            this._Drivers_License_Class = null;
            this._Drivers_License_Restrictions = null;
            this._Drivers_License_Endorsements = null;
            this._Drivers_License_Issued = null;
            this._Drivers_License_Expires = null;
            this._FK_Bank_Number = null;
            this._Job_Title = null;
            this._Occupation_Description = null;
            this._Salary = null;
            this._Frequency = null;
            this._Wages_YTD = null;
            this._Supervisor = null;
            this._Hire_Date = null;
            this._Work_Phone = null;
            this._Active_Inactive_Leave = null;
            this._Inactive = null;
            this._Updated_By = null;
            this._Update_Date = null;
            this._FK_Job_Classification = null;
            this._FK_Cost_Center = null;
            this._Email = null;
            this._Department = null;

        }

        /// <summary> 
        /// Initializes a new instance of the Employee class for passed PrimaryKey with the values set from Database.
        /// </summary>
        public Employee(decimal PK)
        {

            DataTable dtEmployee = SelectByPK(PK).Tables[0];

            if (dtEmployee.Rows.Count > 0)
            {
                DataRow drEmployee = dtEmployee.Rows[0];

                this._PK_Employee_ID = (decimal)drEmployee["PK_Employee_ID"];

                if (drEmployee["Employee_Id"] == DBNull.Value)
                    this._Employee_Id = null;
                else
                    this._Employee_Id = (string)drEmployee["Employee_Id"];

                if (drEmployee["Last_Name"] == DBNull.Value)
                    this._Last_Name = null;
                else
                    this._Last_Name = (string)drEmployee["Last_Name"];

                if (drEmployee["First_Name"] == DBNull.Value)
                    this._First_Name = null;
                else
                    this._First_Name = (string)drEmployee["First_Name"];

                if (drEmployee["Middle_Name"] == DBNull.Value)
                    this._Middle_Name = null;
                else
                    this._Middle_Name = (string)drEmployee["Middle_Name"];

                if (drEmployee["Employee_Address_1"] == DBNull.Value)
                    this._Employee_Address_1 = null;
                else
                    this._Employee_Address_1 = (string)drEmployee["Employee_Address_1"];

                if (drEmployee["Employee_Address_2"] == DBNull.Value)
                    this._Employee_Address_2 = null;
                else
                    this._Employee_Address_2 = (string)drEmployee["Employee_Address_2"];

                if (drEmployee["Employee_City"] == DBNull.Value)
                    this._Employee_City = null;
                else
                    this._Employee_City = (string)drEmployee["Employee_City"];

                if (drEmployee["Employee_State"] == DBNull.Value)
                    this._Employee_State = null;
                else
                    this._Employee_State = (decimal?)drEmployee["Employee_State"];

                if (drEmployee["Employee_Zip_Code"] == DBNull.Value)
                    this._Employee_Zip_Code = null;
                else
                    this._Employee_Zip_Code = (string)drEmployee["Employee_Zip_Code"];

                if (drEmployee["Employee_Home_Phone"] == DBNull.Value)
                    this._Employee_Home_Phone = null;
                else
                    this._Employee_Home_Phone = (string)drEmployee["Employee_Home_Phone"];

                if (drEmployee["Employee_Cell_Phone"] == DBNull.Value)
                    this._Employee_Cell_Phone = null;
                else
                    this._Employee_Cell_Phone = (string)drEmployee["Employee_Cell_Phone"];

                if (drEmployee["Social_Security_Number"] == DBNull.Value)
                    this._Social_Security_Number = null;
                else
                    this._Social_Security_Number = (string)drEmployee["Social_Security_Number"];

                if (drEmployee["FK_Marital_Status"] == DBNull.Value)
                    this._FK_Marital_Status = null;
                else
                    this._FK_Marital_Status = (decimal?)drEmployee["FK_Marital_Status"];

                if (drEmployee["Sex"] == DBNull.Value)
                    this._Sex = null;
                else
                    this._Sex = (string)drEmployee["Sex"];

                if (drEmployee["Number_Of_Dependents"] == DBNull.Value)
                    this._Number_Of_Dependents = null;
                else
                    this._Number_Of_Dependents = (decimal?)drEmployee["Number_Of_Dependents"];

                if (drEmployee["Date_Of_Birth"] == DBNull.Value)
                    this._Date_Of_Birth = null;
                else
                    this._Date_Of_Birth = (DateTime?)drEmployee["Date_Of_Birth"];

                if (drEmployee["Date_Of_Death"] == DBNull.Value)
                    this._Date_Of_Death = null;
                else
                    this._Date_Of_Death = (DateTime?)drEmployee["Date_Of_Death"];

                if (drEmployee["Drivers_License_State"] == DBNull.Value)
                    this._Drivers_License_State = null;
                else
                    this._Drivers_License_State = (string)drEmployee["Drivers_License_State"];

                if (drEmployee["Drivers_License_Number"] == DBNull.Value)
                    this._Drivers_License_Number = null;
                else
                    this._Drivers_License_Number = (string)drEmployee["Drivers_License_Number"];

                if (drEmployee["Drivers_License_Type"] == DBNull.Value)
                    this._Drivers_License_Type = null;
                else
                    this._Drivers_License_Type = (string)drEmployee["Drivers_License_Type"];

                if (drEmployee["Drivers_License_Class"] == DBNull.Value)
                    this._Drivers_License_Class = null;
                else
                    this._Drivers_License_Class = (string)drEmployee["Drivers_License_Class"];

                if (drEmployee["Drivers_License_Restrictions"] == DBNull.Value)
                    this._Drivers_License_Restrictions = null;
                else
                    this._Drivers_License_Restrictions = (string)drEmployee["Drivers_License_Restrictions"];

                if (drEmployee["Drivers_License_Endorsements"] == DBNull.Value)
                    this._Drivers_License_Endorsements = null;
                else
                    this._Drivers_License_Endorsements = (string)drEmployee["Drivers_License_Endorsements"];

                if (drEmployee["Drivers_License_Issued"] == DBNull.Value)
                    this._Drivers_License_Issued = null;
                else
                    this._Drivers_License_Issued = (DateTime?)drEmployee["Drivers_License_Issued"];

                if (drEmployee["Drivers_License_Expires"] == DBNull.Value)
                    this._Drivers_License_Expires = null;
                else
                    this._Drivers_License_Expires = (DateTime?)drEmployee["Drivers_License_Expires"];

                if (drEmployee["FK_Bank_Number"] == DBNull.Value)
                    this._FK_Bank_Number = null;
                else
                    this._FK_Bank_Number = (decimal?)drEmployee["FK_Bank_Number"];

                if (drEmployee["Job_Title"] == DBNull.Value)
                    this._Job_Title = null;
                else
                    this._Job_Title = (string)drEmployee["Job_Title"];

                if (drEmployee["Occupation_Description"] == DBNull.Value)
                    this._Occupation_Description = null;
                else
                    this._Occupation_Description = (string)drEmployee["Occupation_Description"];

                if (drEmployee["Salary"] == DBNull.Value)
                    this._Salary = null;
                else
                    this._Salary = (decimal?)drEmployee["Salary"];

                if (drEmployee["Frequency"] == DBNull.Value)
                    this._Frequency = null;
                else
                    this._Frequency = (string)drEmployee["Frequency"];

                if (drEmployee["Wages_YTD"] == DBNull.Value)
                    this._Wages_YTD = null;
                else
                    this._Wages_YTD = (decimal?)drEmployee["Wages_YTD"];

                if (drEmployee["Supervisor"] == DBNull.Value)
                    this._Supervisor = null;
                else
                    this._Supervisor = (string)drEmployee["Supervisor"];

                if (drEmployee["Hire_Date"] == DBNull.Value)
                    this._Hire_Date = null;
                else
                    this._Hire_Date = (DateTime?)drEmployee["Hire_Date"];

                if (drEmployee["Work_Phone"] == DBNull.Value)
                    this._Work_Phone = null;
                else
                    this._Work_Phone = (string)drEmployee["Work_Phone"];

                if (drEmployee["Active_Inactive_Leave"] == DBNull.Value)
                    this._Active_Inactive_Leave = null;
                else
                    this._Active_Inactive_Leave = (string)drEmployee["Active_Inactive_Leave"];

                if (drEmployee["Inactive"] == DBNull.Value)
                    this._Inactive = null;
                else
                    this._Inactive = (string)drEmployee["Inactive"];

                if (drEmployee["Updated_By"] == DBNull.Value)
                    this._Updated_By = null;
                else
                    this._Updated_By = (string)drEmployee["Updated_By"];

                if (drEmployee["Update_Date"] == DBNull.Value)
                    this._Update_Date = null;
                else
                    this._Update_Date = (DateTime?)drEmployee["Update_Date"];

                if (drEmployee["FK_Job_Classification"] == DBNull.Value)
                    this._FK_Job_Classification = null;
                else
                    this._FK_Job_Classification = (decimal?)drEmployee["FK_Job_Classification"];

                if (drEmployee["FK_Cost_Center"] == DBNull.Value)
                    this._FK_Cost_Center = null;
                else
                    this._FK_Cost_Center = (decimal?)drEmployee["FK_Cost_Center"];

                if (drEmployee["Email"] == DBNull.Value)
                    this._Email = null;
                else
                    this._Email = (string)drEmployee["Email"];

                if (drEmployee["Department"] == DBNull.Value)
                    this._Department = null;
                else
                    this._Department = (string)drEmployee["Department"];

            }
            else
            {
                this._PK_Employee_ID = -1;
                this._Employee_Id = null;
                this._Last_Name = null;
                this._First_Name = null;
                this._Middle_Name = null;
                this._Employee_Address_1 = null;
                this._Employee_Address_2 = null;
                this._Employee_City = null;
                this._Employee_State = null;
                this._Employee_Zip_Code = null;
                this._Employee_Home_Phone = null;
                this._Employee_Cell_Phone = null;
                this._Social_Security_Number = null;
                this._FK_Marital_Status = null;
                this._Sex = null;
                this._Number_Of_Dependents = null;
                this._Date_Of_Birth = null;
                this._Date_Of_Death = null;
                this._Drivers_License_State = null;
                this._Drivers_License_Number = null;
                this._Drivers_License_Type = null;
                this._Drivers_License_Class = null;
                this._Drivers_License_Restrictions = null;
                this._Drivers_License_Endorsements = null;
                this._Drivers_License_Issued = null;
                this._Drivers_License_Expires = null;
                this._FK_Bank_Number = null;
                this._Job_Title = null;
                this._Occupation_Description = null;
                this._Salary = null;
                this._Frequency = null;
                this._Wages_YTD = null;
                this._Supervisor = null;
                this._Hire_Date = null;
                this._Work_Phone = null;
                this._Active_Inactive_Leave = null;
                this._Inactive = null;
                this._Updated_By = null;
                this._Update_Date = null;
                this._FK_Job_Classification = null;
                this._FK_Cost_Center = null;
                this._Email = null;
                this._Department = null;
            }

        }

        /// <summary> 
        /// Initializes a new instance of the Employee class for passed PrimaryKey with the values set from Database.
        /// </summary>
        public Employee(decimal EmployeeId, Boolean Temp)
        {

            DataTable dtEmployee = SelectByEmployee_ID(EmployeeId).Tables[0];

            if (dtEmployee.Rows.Count > 0)
            {

                DataRow drEmployee = dtEmployee.Rows[0];

                this._PK_Employee_ID = drEmployee["PK_Employee_ID"] != DBNull.Value ? Convert.ToDecimal(drEmployee["PK_Employee_ID"]) : 0;
                this._Employee_Id = Convert.ToString(drEmployee["Employee_Id"]);
                this._Last_Name = Convert.ToString(drEmployee["Last_Name"]);
                this._First_Name = Convert.ToString(drEmployee["First_Name"]);
                this._Middle_Name = Convert.ToString(drEmployee["Middle_Name"]);
                this._Employee_Address_1 = Convert.ToString(drEmployee["Employee_Address_1"]);
                this._Employee_Address_2 = Convert.ToString(drEmployee["Employee_Address_2"]);
                this._Employee_City = Convert.ToString(drEmployee["Employee_City"]);
                this._Employee_State = drEmployee["Employee_State"] != DBNull.Value ? Convert.ToDecimal(drEmployee["Employee_State"]) : 0;
                this._Employee_Zip_Code = Convert.ToString(drEmployee["Employee_Zip_Code"]);
                this._Employee_Home_Phone = Convert.ToString(drEmployee["Employee_Home_Phone"]);
                this._Employee_Cell_Phone = Convert.ToString(drEmployee["Employee_Cell_Phone"]);
                this._Social_Security_Number = Convert.ToString(drEmployee["Social_Security_Number"]);
                this._FK_Marital_Status = drEmployee["FK_Marital_Status"] != DBNull.Value ? Convert.ToDecimal(drEmployee["FK_Marital_Status"]) : 0;
                this._Sex = Convert.ToString(drEmployee["Sex"]);
                this._Number_Of_Dependents = drEmployee["Number_Of_Dependents"] != DBNull.Value ? Convert.ToDecimal(drEmployee["Number_Of_Dependents"]) : 0;
                this._Date_Of_Birth = drEmployee["Date_Of_Birth"] != DBNull.Value ? Convert.ToDateTime(drEmployee["Date_Of_Birth"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Date_Of_Death = drEmployee["Date_Of_Death"] != DBNull.Value ? Convert.ToDateTime(drEmployee["Date_Of_Death"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Drivers_License_State = Convert.ToString(drEmployee["Drivers_License_State"]);
                this._Drivers_License_Number = Convert.ToString(drEmployee["Drivers_License_Number"]);
                this._Drivers_License_Type = Convert.ToString(drEmployee["Drivers_License_Type"]);
                this._Drivers_License_Class = Convert.ToString(drEmployee["Drivers_License_Class"]);
                this._Drivers_License_Restrictions = Convert.ToString(drEmployee["Drivers_License_Restrictions"]);
                this._Drivers_License_Endorsements = Convert.ToString(drEmployee["Drivers_License_Endorsements"]);
                this._Drivers_License_Issued = drEmployee["Drivers_License_Issued"] != DBNull.Value ? Convert.ToDateTime(drEmployee["Drivers_License_Issued"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Drivers_License_Expires = drEmployee["Drivers_License_Expires"] != DBNull.Value ? Convert.ToDateTime(drEmployee["Drivers_License_Expires"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._FK_Bank_Number = drEmployee["FK_Bank_Number"] != DBNull.Value ? Convert.ToDecimal(drEmployee["FK_Bank_Number"]) : 0;
                this._Job_Title = Convert.ToString(drEmployee["Job_Title"]);
                this._Occupation_Description = Convert.ToString(drEmployee["Occupation_Description"]);
                this._Salary = drEmployee["Salary"] != DBNull.Value ? Convert.ToDecimal(drEmployee["Salary"]) : 0;
                this._Frequency = Convert.ToString(drEmployee["Frequency"]);
                this._Wages_YTD = drEmployee["Wages_YTD"] != DBNull.Value ? Convert.ToDecimal(drEmployee["Wages_YTD"]) : 0;
                this._Supervisor = Convert.ToString(drEmployee["Supervisor"]);
                this._Hire_Date = drEmployee["Hire_Date"] != DBNull.Value ? Convert.ToDateTime(drEmployee["Hire_Date"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Work_Phone = Convert.ToString(drEmployee["Work_Phone"]);
                this._Active_Inactive_Leave = Convert.ToString(drEmployee["Active_Inactive_Leave"]);
                this._Inactive = Convert.ToString(drEmployee["Inactive"]);
                this._Updated_By = Convert.ToString(drEmployee["Updated_By"]);
                this._Update_Date = drEmployee["Update_Date"] != DBNull.Value ? Convert.ToDateTime(drEmployee["Update_Date"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._FK_Job_Classification = drEmployee["FK_Job_Classification"] != DBNull.Value ? Convert.ToDecimal(drEmployee["FK_Job_Classification"]) : 0;
                this._FK_Cost_Center = drEmployee["FK_Cost_Center"] != DBNull.Value ? Convert.ToDecimal(drEmployee["FK_Cost_Center"]) : 0;
                this._Email = Convert.ToString(drEmployee["Email"]);
                this._Department = Convert.ToString(drEmployee["Department"]);

            }

            else
            {

                this._PK_Employee_ID = -1;
                this._Employee_Id = "";
                this._Last_Name = "";
                this._First_Name = "";
                this._Middle_Name = "";
                this._Employee_Address_1 = "";
                this._Employee_Address_2 = "";
                this._Employee_City = "";
                this._Employee_State = -1;
                this._Employee_Zip_Code = "";
                this._Employee_Home_Phone = "";
                this._Employee_Cell_Phone = "";
                this._Social_Security_Number = "";
                this._FK_Marital_Status = -1;
                this._Sex = "";
                this._Number_Of_Dependents = -1;
                this._Date_Of_Birth = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Date_Of_Death = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Drivers_License_State = "";
                this._Drivers_License_Number = "";
                this._Drivers_License_Type = "";
                this._Drivers_License_Class = "";
                this._Drivers_License_Restrictions = "";
                this._Drivers_License_Endorsements = "";
                this._Drivers_License_Issued = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Drivers_License_Expires = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._FK_Bank_Number = -1;
                this._Job_Title = "";
                this._Occupation_Description = "";
                this._Salary = -1;
                this._Frequency = "";
                this._Wages_YTD = -1;
                this._Supervisor = "";
                this._Hire_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Work_Phone = "";
                this._Active_Inactive_Leave = "";
                this._Inactive = "";
                this._Updated_By = "";
                this._Update_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._FK_Job_Classification = -1;
                this._FK_Cost_Center = -1;
                this._Email = "";
                this._Department = "";

            }

        }

        #endregion


        #region Methods

        /// <summary>
        /// Inserts a record into the Employee table.
        /// </summary>
        /// <returns></returns>
        public decimal Insert()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("EmployeeInsert");

            if (string.IsNullOrEmpty(this._Employee_Id))
                db.AddInParameter(dbCommand, "Employee_Id", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Employee_Id", DbType.String, this._Employee_Id);

            if (string.IsNullOrEmpty(this._Last_Name))
                db.AddInParameter(dbCommand, "Last_Name", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Last_Name", DbType.String, this._Last_Name);

            if (string.IsNullOrEmpty(this._First_Name))
                db.AddInParameter(dbCommand, "First_Name", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "First_Name", DbType.String, this._First_Name);

            if (string.IsNullOrEmpty(this._Middle_Name))
                db.AddInParameter(dbCommand, "Middle_Name", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Middle_Name", DbType.String, this._Middle_Name);

            if (string.IsNullOrEmpty(this._Employee_Address_1))
                db.AddInParameter(dbCommand, "Employee_Address_1", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Employee_Address_1", DbType.String, this._Employee_Address_1);

            if (string.IsNullOrEmpty(this._Employee_Address_2))
                db.AddInParameter(dbCommand, "Employee_Address_2", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Employee_Address_2", DbType.String, this._Employee_Address_2);

            if (string.IsNullOrEmpty(this._Employee_City))
                db.AddInParameter(dbCommand, "Employee_City", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Employee_City", DbType.String, this._Employee_City);

            db.AddInParameter(dbCommand, "Employee_State", DbType.Decimal, this._Employee_State);

            if (string.IsNullOrEmpty(this._Employee_Zip_Code))
                db.AddInParameter(dbCommand, "Employee_Zip_Code", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Employee_Zip_Code", DbType.String, this._Employee_Zip_Code);

            if (string.IsNullOrEmpty(this._Employee_Home_Phone))
                db.AddInParameter(dbCommand, "Employee_Home_Phone", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Employee_Home_Phone", DbType.String, this._Employee_Home_Phone);

            if (string.IsNullOrEmpty(this._Employee_Cell_Phone))
                db.AddInParameter(dbCommand, "Employee_Cell_Phone", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Employee_Cell_Phone", DbType.String, this._Employee_Cell_Phone);

            if (string.IsNullOrEmpty(this._Social_Security_Number))
                db.AddInParameter(dbCommand, "Social_Security_Number", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Social_Security_Number", DbType.String, this._Social_Security_Number);

            db.AddInParameter(dbCommand, "FK_Marital_Status", DbType.Decimal, this._FK_Marital_Status);

            if (string.IsNullOrEmpty(this._Sex))
                db.AddInParameter(dbCommand, "Sex", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Sex", DbType.String, this._Sex);

            db.AddInParameter(dbCommand, "Number_Of_Dependents", DbType.Decimal, this._Number_Of_Dependents);

            db.AddInParameter(dbCommand, "Date_Of_Birth", DbType.DateTime, this._Date_Of_Birth);

            db.AddInParameter(dbCommand, "Date_Of_Death", DbType.DateTime, this._Date_Of_Death);

            if (string.IsNullOrEmpty(this._Drivers_License_State))
                db.AddInParameter(dbCommand, "Drivers_License_State", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Drivers_License_State", DbType.String, this._Drivers_License_State);

            if (string.IsNullOrEmpty(this._Drivers_License_Number))
                db.AddInParameter(dbCommand, "Drivers_License_Number", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Drivers_License_Number", DbType.String, this._Drivers_License_Number);

            if (string.IsNullOrEmpty(this._Drivers_License_Type))
                db.AddInParameter(dbCommand, "Drivers_License_Type", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Drivers_License_Type", DbType.String, this._Drivers_License_Type);

            if (string.IsNullOrEmpty(this._Drivers_License_Class))
                db.AddInParameter(dbCommand, "Drivers_License_Class", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Drivers_License_Class", DbType.String, this._Drivers_License_Class);

            if (string.IsNullOrEmpty(this._Drivers_License_Restrictions))
                db.AddInParameter(dbCommand, "Drivers_License_Restrictions", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Drivers_License_Restrictions", DbType.String, this._Drivers_License_Restrictions);

            if (string.IsNullOrEmpty(this._Drivers_License_Endorsements))
                db.AddInParameter(dbCommand, "Drivers_License_Endorsements", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Drivers_License_Endorsements", DbType.String, this._Drivers_License_Endorsements);

            db.AddInParameter(dbCommand, "Drivers_License_Issued", DbType.DateTime, this._Drivers_License_Issued);

            db.AddInParameter(dbCommand, "Drivers_License_Expires", DbType.DateTime, this._Drivers_License_Expires);

            db.AddInParameter(dbCommand, "FK_Bank_Number", DbType.Decimal, this._FK_Bank_Number);

            if (string.IsNullOrEmpty(this._Job_Title))
                db.AddInParameter(dbCommand, "Job_Title", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Job_Title", DbType.String, this._Job_Title);

            if (string.IsNullOrEmpty(this._Occupation_Description))
                db.AddInParameter(dbCommand, "Occupation_Description", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Occupation_Description", DbType.String, this._Occupation_Description);

            db.AddInParameter(dbCommand, "Salary", DbType.Decimal, this._Salary);

            if (string.IsNullOrEmpty(this._Frequency))
                db.AddInParameter(dbCommand, "Frequency", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Frequency", DbType.String, this._Frequency);

            db.AddInParameter(dbCommand, "Wages_YTD", DbType.Decimal, this._Wages_YTD);

            if (string.IsNullOrEmpty(this._Supervisor))
                db.AddInParameter(dbCommand, "Supervisor", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Supervisor", DbType.String, this._Supervisor);

            db.AddInParameter(dbCommand, "Hire_Date", DbType.DateTime, this._Hire_Date);

            if (string.IsNullOrEmpty(this._Work_Phone))
                db.AddInParameter(dbCommand, "Work_Phone", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Work_Phone", DbType.String, this._Work_Phone);

            if (string.IsNullOrEmpty(this._Active_Inactive_Leave))
                db.AddInParameter(dbCommand, "Active_Inactive_Leave", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Active_Inactive_Leave", DbType.String, this._Active_Inactive_Leave);

            if (string.IsNullOrEmpty(this._Inactive))
                db.AddInParameter(dbCommand, "Inactive", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Inactive", DbType.String, this._Inactive);

            if (string.IsNullOrEmpty(this._Updated_By))
                db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);

            db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);

            db.AddInParameter(dbCommand, "FK_Job_Classification", DbType.Decimal, this._FK_Job_Classification);

            db.AddInParameter(dbCommand, "FK_Cost_Center", DbType.Decimal, this._FK_Cost_Center);

            if (string.IsNullOrEmpty(this._Email))
                db.AddInParameter(dbCommand, "Email", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Email", DbType.String, this._Email);

            if (string.IsNullOrEmpty(this._Department))
                db.AddInParameter(dbCommand, "Department", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Department", DbType.String, this._Department);

            // Execute the query and return the new identity value
            decimal returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
        }

        /// <summary>
        /// Selects a single record from the Employee table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectByPK(decimal pK_Employee_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("EmployeeSelectByPK");

            db.AddInParameter(dbCommand, "PK_Employee_ID", DbType.Decimal, pK_Employee_ID);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects records from the Employee table by a foreign key.
        /// </summary>
        /// <param name="fK_Marital_Status"></param>
        /// <returns>DataSet</returns>
        public static DataSet SelectByFK_Marital_Status(decimal fK_Marital_Status)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("EmployeeSelectByFK_Marital_Status");

            db.AddInParameter(dbCommand, "FK_Marital_Status", DbType.Decimal, fK_Marital_Status);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects records from the Employee table by a foreign key.
        /// </summary>
        /// <param name="employee_State"></param>
        /// <returns>DataSet</returns>
        public static DataSet SelectByEmployee_State(decimal employee_State)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("EmployeeSelectByEmployee_State");

            db.AddInParameter(dbCommand, "Employee_State", DbType.Decimal, employee_State);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the Employee table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("EmployeeSelectAll");

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Updates a record in the Employee table.
        /// </summary>
        public void Update()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("EmployeeUpdate");

            db.AddInParameter(dbCommand, "PK_Employee_ID", DbType.Decimal, this._PK_Employee_ID);

            if (string.IsNullOrEmpty(this._Employee_Id))
                db.AddInParameter(dbCommand, "Employee_Id", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Employee_Id", DbType.String, this._Employee_Id);

            if (string.IsNullOrEmpty(this._Last_Name))
                db.AddInParameter(dbCommand, "Last_Name", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Last_Name", DbType.String, this._Last_Name);

            if (string.IsNullOrEmpty(this._First_Name))
                db.AddInParameter(dbCommand, "First_Name", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "First_Name", DbType.String, this._First_Name);

            if (string.IsNullOrEmpty(this._Middle_Name))
                db.AddInParameter(dbCommand, "Middle_Name", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Middle_Name", DbType.String, this._Middle_Name);

            if (string.IsNullOrEmpty(this._Employee_Address_1))
                db.AddInParameter(dbCommand, "Employee_Address_1", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Employee_Address_1", DbType.String, this._Employee_Address_1);

            if (string.IsNullOrEmpty(this._Employee_Address_2))
                db.AddInParameter(dbCommand, "Employee_Address_2", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Employee_Address_2", DbType.String, this._Employee_Address_2);

            if (string.IsNullOrEmpty(this._Employee_City))
                db.AddInParameter(dbCommand, "Employee_City", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Employee_City", DbType.String, this._Employee_City);

            db.AddInParameter(dbCommand, "Employee_State", DbType.Decimal, this._Employee_State);

            if (string.IsNullOrEmpty(this._Employee_Zip_Code))
                db.AddInParameter(dbCommand, "Employee_Zip_Code", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Employee_Zip_Code", DbType.String, this._Employee_Zip_Code);

            if (string.IsNullOrEmpty(this._Employee_Home_Phone))
                db.AddInParameter(dbCommand, "Employee_Home_Phone", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Employee_Home_Phone", DbType.String, this._Employee_Home_Phone);

            if (string.IsNullOrEmpty(this._Employee_Cell_Phone))
                db.AddInParameter(dbCommand, "Employee_Cell_Phone", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Employee_Cell_Phone", DbType.String, this._Employee_Cell_Phone);

            if (string.IsNullOrEmpty(this._Social_Security_Number))
                db.AddInParameter(dbCommand, "Social_Security_Number", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Social_Security_Number", DbType.String, this._Social_Security_Number);

            db.AddInParameter(dbCommand, "FK_Marital_Status", DbType.Decimal, this._FK_Marital_Status);

            if (string.IsNullOrEmpty(this._Sex))
                db.AddInParameter(dbCommand, "Sex", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Sex", DbType.String, this._Sex);

            db.AddInParameter(dbCommand, "Number_Of_Dependents", DbType.Decimal, this._Number_Of_Dependents);

            db.AddInParameter(dbCommand, "Date_Of_Birth", DbType.DateTime, this._Date_Of_Birth);

            db.AddInParameter(dbCommand, "Date_Of_Death", DbType.DateTime, this._Date_Of_Death);

            if (string.IsNullOrEmpty(this._Drivers_License_State))
                db.AddInParameter(dbCommand, "Drivers_License_State", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Drivers_License_State", DbType.String, this._Drivers_License_State);

            if (string.IsNullOrEmpty(this._Drivers_License_Number))
                db.AddInParameter(dbCommand, "Drivers_License_Number", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Drivers_License_Number", DbType.String, this._Drivers_License_Number);

            if (string.IsNullOrEmpty(this._Drivers_License_Type))
                db.AddInParameter(dbCommand, "Drivers_License_Type", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Drivers_License_Type", DbType.String, this._Drivers_License_Type);

            if (string.IsNullOrEmpty(this._Drivers_License_Class))
                db.AddInParameter(dbCommand, "Drivers_License_Class", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Drivers_License_Class", DbType.String, this._Drivers_License_Class);

            if (string.IsNullOrEmpty(this._Drivers_License_Restrictions))
                db.AddInParameter(dbCommand, "Drivers_License_Restrictions", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Drivers_License_Restrictions", DbType.String, this._Drivers_License_Restrictions);

            if (string.IsNullOrEmpty(this._Drivers_License_Endorsements))
                db.AddInParameter(dbCommand, "Drivers_License_Endorsements", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Drivers_License_Endorsements", DbType.String, this._Drivers_License_Endorsements);

            db.AddInParameter(dbCommand, "Drivers_License_Issued", DbType.DateTime, this._Drivers_License_Issued);

            db.AddInParameter(dbCommand, "Drivers_License_Expires", DbType.DateTime, this._Drivers_License_Expires);

            db.AddInParameter(dbCommand, "FK_Bank_Number", DbType.Decimal, this._FK_Bank_Number);

            if (string.IsNullOrEmpty(this._Job_Title))
                db.AddInParameter(dbCommand, "Job_Title", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Job_Title", DbType.String, this._Job_Title);

            if (string.IsNullOrEmpty(this._Occupation_Description))
                db.AddInParameter(dbCommand, "Occupation_Description", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Occupation_Description", DbType.String, this._Occupation_Description);

            db.AddInParameter(dbCommand, "Salary", DbType.Decimal, this._Salary);

            if (string.IsNullOrEmpty(this._Frequency))
                db.AddInParameter(dbCommand, "Frequency", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Frequency", DbType.String, this._Frequency);

            db.AddInParameter(dbCommand, "Wages_YTD", DbType.Decimal, this._Wages_YTD);

            if (string.IsNullOrEmpty(this._Supervisor))
                db.AddInParameter(dbCommand, "Supervisor", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Supervisor", DbType.String, this._Supervisor);

            db.AddInParameter(dbCommand, "Hire_Date", DbType.DateTime, this._Hire_Date);

            if (string.IsNullOrEmpty(this._Work_Phone))
                db.AddInParameter(dbCommand, "Work_Phone", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Work_Phone", DbType.String, this._Work_Phone);

            if (string.IsNullOrEmpty(this._Active_Inactive_Leave))
                db.AddInParameter(dbCommand, "Active_Inactive_Leave", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Active_Inactive_Leave", DbType.String, this._Active_Inactive_Leave);

            if (string.IsNullOrEmpty(this._Inactive))
                db.AddInParameter(dbCommand, "Inactive", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Inactive", DbType.String, this._Inactive);

            if (string.IsNullOrEmpty(this._Updated_By))
                db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);

            db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);

            db.AddInParameter(dbCommand, "FK_Job_Classification", DbType.Decimal, this._FK_Job_Classification);

            db.AddInParameter(dbCommand, "FK_Cost_Center", DbType.Decimal, this._FK_Cost_Center);

            if (string.IsNullOrEmpty(this._Email))
                db.AddInParameter(dbCommand, "Email", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Email", DbType.String, this._Email);

            if (string.IsNullOrEmpty(this._Department))
                db.AddInParameter(dbCommand, "Department", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Department", DbType.String, this._Department);
            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Deletes a record from the Employee table by a composite primary key.
        /// </summary>
        public static void DeleteByPK(decimal pK_Employee_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("EmployeeDeleteByPK");

            db.AddInParameter(dbCommand, "PK_Employee_ID", DbType.Decimal, pK_Employee_ID);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Deletes a record from the Employee table by a foreign key.
        /// </summary>
        public static void DeleteByFK_Marital_Status(decimal fK_Marital_Status)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("EmployeeDeleteByFK_Marital_Status");

            db.AddInParameter(dbCommand, "FK_Marital_Status", DbType.Decimal, fK_Marital_Status);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Deletes a record from the Employee table by a foreign key.
        /// </summary>
        public static void DeleteByEmployee_State(decimal employee_State)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("EmployeeDeleteByEmployee_State");

            db.AddInParameter(dbCommand, "Employee_State", DbType.Decimal, employee_State);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Selects records from the Employee table by a Cost Center.
        /// </summary>
        /// <param name="Fk_Cost_Center"></param>
        /// <returns>DataSet</returns>
        public static DataSet SelectByEmployee_CostCenter(int Sonic_Location_Code)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("GetEmployeeByCostCenter");

            db.AddInParameter(dbCommand, "Sonic_Location_Code", DbType.Int32, Sonic_Location_Code);

            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet SelectActiveEmployessByLocation(int Sonic_Location_Code)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("SelectActiveEmployessByLocation");

            db.AddInParameter(dbCommand, "Sonic_Location_Code", DbType.Int32, Sonic_Location_Code);

            return db.ExecuteDataSet(dbCommand);
        }
       
        /// <summary>
        /// Selects all records from the Employee table by First Name and Last Name.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectEmployeeByName(string First_Name, string Last_Name, string Filter)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("EmployeeByName");
            db.AddInParameter(dbCommand, "Last_Name", DbType.String, Last_Name);
            db.AddInParameter(dbCommand, "First_Name", DbType.String, First_Name);
            db.AddInParameter(dbCommand, "Filter", DbType.String, Filter);
            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects a single record from the Employee table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectByEmployee_ID(decimal Employee_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("EmployeeSelectByEmployee_ID");

            db.AddInParameter(dbCommand, "Employee_ID", DbType.Decimal, Employee_ID);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the Employee table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAll(string SearchString, string strOrderBy, string strOrder, int intPageNo, int intPageSize)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("EmployeeSearchResult");
            db.AddInParameter(dbCommand, "@SearchString", DbType.String, SearchString);
            db.AddInParameter(dbCommand, "@strOrderBy", DbType.String, strOrderBy);
            db.AddInParameter(dbCommand, "@strOrder", DbType.String, strOrder);
            db.AddInParameter(dbCommand, "@intPageNo", DbType.Decimal, intPageNo);
            db.AddInParameter(dbCommand, "@intPageSize", DbType.Decimal, intPageSize);
            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet SelectAll(string EmpID, string Fname, string Lname, decimal Location_ID, string strOrderBy, string strOrder, int intPageNo, int intPageSize)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("EmployeeSearchResult2");
            db.AddInParameter(dbCommand, "@Employee_Id", DbType.String, EmpID);
            db.AddInParameter(dbCommand, "@First_Name", DbType.String, Fname);
            db.AddInParameter(dbCommand, "@Last_Name", DbType.String, Lname);
            db.AddInParameter(dbCommand, "@LocationID", DbType.String, Location_ID);
            db.AddInParameter(dbCommand, "@strOrderBy", DbType.String, strOrderBy);
            db.AddInParameter(dbCommand, "@strOrder", DbType.String, strOrder);
            db.AddInParameter(dbCommand, "@intPageNo", DbType.Decimal, intPageNo);
            db.AddInParameter(dbCommand, "@intPageSize", DbType.Decimal, intPageSize);
            return db.ExecuteDataSet(dbCommand);
        }

        // 
        public static bool CheckEmployee_IDExists(decimal Pk_Employee_ID, string Employee_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Employee_CheckEmployeeID");

            db.AddInParameter(dbCommand, "PK_Employee_ID", DbType.Decimal, Pk_Employee_ID);
            db.AddInParameter(dbCommand, "Employee_ID", DbType.String, Employee_ID);

            return Convert.ToBoolean(db.ExecuteScalar(dbCommand));
        }

        public static DataSet SelectRLCM_Emp()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Employee_SelectRLCMs");
            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects records from the Employee table by First Name and Last Name and DBA location.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectEmployeeByDBALocation(string First_Name, string Last_Name, string Filter, int Sonic_Location_Code)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("EmployeeByNameAndByDBALocation");
            db.AddInParameter(dbCommand, "Last_Name", DbType.String, Last_Name);
            db.AddInParameter(dbCommand, "First_Name", DbType.String, First_Name);
            db.AddInParameter(dbCommand, "Filter", DbType.String, Filter);
            db.AddInParameter(dbCommand, "Sonic_Location_Code", DbType.Int32, Sonic_Location_Code);
            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet SelectPayrollCodes()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Employee_SelectPayrollCodes");
            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet SelectEmployessByLocation(int Sonic_Location_Code)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("SelectEmployessByLocation");

            db.AddInParameter(dbCommand, "Sonic_Location_Code", DbType.Int32, Sonic_Location_Code);

            return db.ExecuteDataSet(dbCommand);
        }


        public static DataSet SelectEmployee_For_OSHA()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Employee_For_OSHA");
            return db.ExecuteDataSet(dbCommand);
        }

        // ticket# 3544
        public static DataSet SelectAllActiveEmployess()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("SelectAllActiveEmployess");            

            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet SelectEmployeeBY_Location_FOR_Training(decimal? pK_LU_Location_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Get_EmployeeBY_Location_Training");

            db.AddInParameter(dbCommand, "PK_LU_Location_ID", DbType.Decimal, pK_LU_Location_ID);
            dbCommand.CommandTimeout = 10000;
            return db.ExecuteDataSet(dbCommand);
        }


        #endregion
    }
}
