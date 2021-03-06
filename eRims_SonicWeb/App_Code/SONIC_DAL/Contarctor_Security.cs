﻿using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
    /// <summary>
    /// Data access class for table Contractor_Security
    /// </summary>
    public sealed class Contractor_Security
    {

        #region Private variables used to hold the property values

        private decimal? _PK_Contactor_Security;
        private string _User_Name;
        private string _First_Name;
        private string _Last_Name;
        private string _Password;
        private string _Previous_Password_1;
        private string _Previous_Password_2;
        private string _Previous_Password_3;
        private string _Contractor_Company_Name;
        private string _Address_1;
        private string _Address_2;
        private string _City;
        private string _State;
        private decimal? _FK_State;
        private string _Zip_Code;
        private string _Office_Telephone;
        private string _Cell_Telephone;
        private string _Pager;
        private string _Email;
        private decimal? _FL_LU_FACILITY_CONSTRUCTION_ALERT_METHOD;
        private string _Texting_Address;
        private DateTime? _Update_Date;
        private string _Updated_By;
        private decimal? _FK_LU_Contractor_Type;
        private decimal? _FK_Contractor_Firm;
        private int _Dashboard_Type;
        private string _Vendor_Number;
        private decimal? _FK_LU_Contract_Type;
        private int? _IS_SRM;
        private int? _IS_GC;
        private decimal? _FK_LU_User_Status;

        #endregion

        #region Public Property

        /// <summary>
        /// Gets or sets the PK_Contactor_Security value.
        /// </summary>
        public decimal? PK_Contactor_Security
        {
            get { return _PK_Contactor_Security; }
            set { _PK_Contactor_Security = value; }
        }

        /// <summary>
        /// Gets or sets the User_Name value.
        /// </summary>
        public string User_Name
        {
            get { return _User_Name; }
            set { _User_Name = value; }
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
        /// Gets or sets the Last_Name value.
        /// </summary>
        public string Last_Name
        {
            get { return _Last_Name; }
            set { _Last_Name = value; }
        }

        /// <summary>
        /// Gets or sets the Password value.
        /// </summary>
        public string Password
        {
            get { return _Password; }
            set { _Password = value; }
        }

        /// <summary>
        /// Gets or sets the Previous_Password_1 value.
        /// </summary>
        public string Previous_Password_1
        {
            get { return _Previous_Password_1; }
            set { _Previous_Password_1 = value; }
        }

        /// <summary>
        /// Gets or sets the Previous_Password_2 value.
        /// </summary>
        public string Previous_Password_2
        {
            get { return _Previous_Password_2; }
            set { _Previous_Password_2 = value; }
        }

        /// <summary>
        /// Gets or sets the Previous_Password_3 value.
        /// </summary>
        public string Previous_Password_3
        {
            get { return _Previous_Password_3; }
            set { _Previous_Password_3 = value; }
        }

        /// <summary>
        /// Gets or sets the Contractor_Company_Name value.
        /// </summary>
        public string Contractor_Company_Name
        {
            get { return _Contractor_Company_Name; }
            set { _Contractor_Company_Name = value; }
        }

        /// <summary>
        /// Gets or sets the Address_1 value.
        /// </summary>
        public string Address_1
        {
            get { return _Address_1; }
            set { _Address_1 = value; }
        }

        /// <summary>
        /// Gets or sets the Address_2 value.
        /// </summary>
        public string Address_2
        {
            get { return _Address_2; }
            set { _Address_2 = value; }
        }

        /// <summary>
        /// Gets or sets the City value.
        /// </summary>
        public string City
        {
            get { return _City; }
            set { _City = value; }
        }

        /// <summary>
        /// Gets or sets the FK_State value.
        /// </summary>
        public decimal? FK_State
        {
            get { return _FK_State; }
            set { _FK_State = value; }
        }

        public string State
        {
            get { return _State; }
            set { _State = value; }
        }

        /// <summary>
        /// Gets or sets the Zip_Code value.
        /// </summary>
        public string Zip_Code
        {
            get { return _Zip_Code; }
            set { _Zip_Code = value; }
        }

        /// <summary>
        /// Gets or sets the Office_Telephone value.
        /// </summary>
        public string Office_Telephone
        {
            get { return _Office_Telephone; }
            set { _Office_Telephone = value; }
        }

        /// <summary>
        /// Gets or sets the Cell_Telephone value.
        /// </summary>
        public string Cell_Telephone
        {
            get { return _Cell_Telephone; }
            set { _Cell_Telephone = value; }
        }

        /// <summary>
        /// Gets or sets the Pager value.
        /// </summary>
        public string Pager
        {
            get { return _Pager; }
            set { _Pager = value; }
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
        /// Gets or sets the FL_LU_FACILITY_CONSTRUCTION_ALERT_METHOD value.
        /// </summary>
        public decimal? FL_LU_FACILITY_CONSTRUCTION_ALERT_METHOD
        {
            get { return _FL_LU_FACILITY_CONSTRUCTION_ALERT_METHOD; }
            set { _FL_LU_FACILITY_CONSTRUCTION_ALERT_METHOD = value; }
        }

        /// <summary>
        /// Gets or sets the Texting_Address value.
        /// </summary>
        public string Texting_Address
        {
            get { return _Texting_Address; }
            set { _Texting_Address = value; }
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
        /// Gets or sets the Updated_By value.
        /// </summary>
        public string Updated_By
        {
            get { return _Updated_By; }
            set { _Updated_By = value; }
        }

        /// <summary>
        /// Gets or sets the FK_LU_Contractor_Type value.
        /// </summary>
        public decimal? FK_LU_Contractor_Type
        {
            get { return _FK_LU_Contractor_Type; }
            set { _FK_LU_Contractor_Type = value; }
        }

        /// <summary>
        /// Gets or sets the FK_Contractor_Firm value.
        /// </summary>
        public decimal? FK_Contractor_Firm
        {
            get { return _FK_Contractor_Firm; }
            set { _FK_Contractor_Firm = value; }
        }

        /// <summary>
        /// Gets or sets the Dashboard_Type value.
        /// </summary>
        public int Dashboard_Type
        {
            get { return _Dashboard_Type; }
            set { _Dashboard_Type = value; }
        }

        /// <summary>
        /// Gets or sets the Vendor_Number value.
        /// </summary>
        public string Vendor_Number
        {
            get { return _Vendor_Number; }
            set { _Vendor_Number = value; }
        }

        /// <summary>
        /// Gets or sets the FK_LU_Contract_Type value.
        /// </summary>
        public decimal? FK_LU_Contract_Type
        {
            get { return _FK_LU_Contract_Type; }
            set { _FK_LU_Contract_Type = value; }
        }

        /// <summary>
        /// Gets or sets the IS_SRM value.
        /// </summary>
        public int? IS_SRM
        {
            get { return _IS_SRM; }
            set { _IS_SRM = value; }
        }

        /// <summary>
        /// Gets or sets the IS_GC value.
        /// </summary>
        public int? IS_GC
        {
            get { return _IS_GC; }
            set { _IS_GC = value; }
        }

        /// <summary>
        /// Gets or sets the Fk_LU_User_Status value.
        /// </summary>
        public decimal? FK_LU_User_Status
        {
            get { return _FK_LU_User_Status; }
            set { _FK_LU_User_Status = value; }
        }

        #endregion

        #region Default Constructors

        /// <summary>
        /// Initializes a new instance of the Contractor_Security class with default value.
        /// </summary>
        public Contractor_Security()
        {


        }

        #endregion

        #region Primary Constructors

        /// <summary>
        /// Initializes a new instance of the Contractor_Security class based on Primary Key.
        /// </summary>
        public Contractor_Security(decimal pK_Contactor_Security)
        {
            DataTable dtContractor_Security = Select(pK_Contactor_Security).Tables[0];

            if (dtContractor_Security.Rows.Count == 1)
            {
                SetValue(dtContractor_Security.Rows[0]);
            }
        }


        /// <summary>
        /// Initializes a new instance of the Contractor_Security class based on Datarow passed.
        /// </summary>
        private void SetValue(DataRow drContractor_Security)
        {
            if (drContractor_Security["PK_Contactor_Security"] == DBNull.Value)
                this._PK_Contactor_Security = null;
            else
                this._PK_Contactor_Security = (decimal?)drContractor_Security["PK_Contactor_Security"];

            if (drContractor_Security["User_Name"] == DBNull.Value)
                this._User_Name = null;
            else
                this._User_Name = (string)drContractor_Security["User_Name"];

            if (drContractor_Security["First_Name"] == DBNull.Value)
                this._First_Name = null;
            else
                this._First_Name = (string)drContractor_Security["First_Name"];

            if (drContractor_Security["Last_Name"] == DBNull.Value)
                this._Last_Name = null;
            else
                this._Last_Name = (string)drContractor_Security["Last_Name"];

            if (drContractor_Security["Password"] == DBNull.Value)
                this._Password = null;
            else
                this._Password = (string)drContractor_Security["Password"];

            if (drContractor_Security["Previous_Password_1"] == DBNull.Value)
                this._Previous_Password_1 = null;
            else
                this._Previous_Password_1 = (string)drContractor_Security["Previous_Password_1"];

            if (drContractor_Security["Previous_Password_2"] == DBNull.Value)
                this._Previous_Password_2 = null;
            else
                this._Previous_Password_2 = (string)drContractor_Security["Previous_Password_2"];

            if (drContractor_Security["Previous_Password_3"] == DBNull.Value)
                this._Previous_Password_3 = null;
            else
                this._Previous_Password_3 = (string)drContractor_Security["Previous_Password_3"];

            if (drContractor_Security["Contractor_Company_Name"] == DBNull.Value)
                this._Contractor_Company_Name = null;
            else
                this._Contractor_Company_Name = (string)drContractor_Security["Contractor_Company_Name"];

            if (drContractor_Security["Address_1"] == DBNull.Value)
                this._Address_1 = null;
            else
                this._Address_1 = (string)drContractor_Security["Address_1"];

            if (drContractor_Security["Address_2"] == DBNull.Value)
                this._Address_2 = null;
            else
                this._Address_2 = (string)drContractor_Security["Address_2"];

            if (drContractor_Security["City"] == DBNull.Value)
                this._City = null;
            else
                this._City = (string)drContractor_Security["City"];

            if (drContractor_Security["FK_State"] == DBNull.Value)
                this._FK_State = null;
            else
                this._FK_State = (decimal?)drContractor_Security["FK_State"];

            if (drContractor_Security["Zip_Code"] == DBNull.Value)
                this._Zip_Code = null;
            else
                this._Zip_Code = (string)drContractor_Security["Zip_Code"];

            if (drContractor_Security["Office_Telephone"] == DBNull.Value)
                this._Office_Telephone = null;
            else
                this._Office_Telephone = (string)drContractor_Security["Office_Telephone"];

            if (drContractor_Security["Cell_Telephone"] == DBNull.Value)
                this._Cell_Telephone = null;
            else
                this._Cell_Telephone = (string)drContractor_Security["Cell_Telephone"];

            if (drContractor_Security["Pager"] == DBNull.Value)
                this._Pager = null;
            else
                this._Pager = (string)drContractor_Security["Pager"];

            if (drContractor_Security["Email"] == DBNull.Value)
                this._Email = null;
            else
                this._Email = (string)drContractor_Security["Email"];

            if (drContractor_Security["FL_LU_FACILITY_CONSTRUCTION_ALERT_METHOD"] == DBNull.Value)
                this._FL_LU_FACILITY_CONSTRUCTION_ALERT_METHOD = null;
            else
                this._FL_LU_FACILITY_CONSTRUCTION_ALERT_METHOD = (decimal?)drContractor_Security["FL_LU_FACILITY_CONSTRUCTION_ALERT_METHOD"];

            if (drContractor_Security["Texting_Address"] == DBNull.Value)
                this._Texting_Address = null;
            else
                this._Texting_Address = (string)drContractor_Security["Texting_Address"];

            if (drContractor_Security["Update_Date"] == DBNull.Value)
                this._Update_Date = null;
            else
                this._Update_Date = (DateTime?)drContractor_Security["Update_Date"];

            if (drContractor_Security["Updated_By"] == DBNull.Value)
                this._Updated_By = null;
            else
                this._Updated_By = (string)drContractor_Security["Updated_By"];

            if (drContractor_Security["FK_LU_Contractor_Type"] == DBNull.Value)
                this._FK_LU_Contractor_Type = null;
            else
                this._FK_LU_Contractor_Type = (decimal?)drContractor_Security["FK_LU_Contractor_Type"];

            if (drContractor_Security["FK_Contractor_Firm"] == DBNull.Value)
                this._FK_Contractor_Firm = null;
            else
                this._FK_Contractor_Firm = (decimal?)drContractor_Security["FK_Contractor_Firm"];

            if (drContractor_Security["Vendor_Number"] == DBNull.Value)
                this._Vendor_Number = null;
            else
                this._Vendor_Number = (string)drContractor_Security["Vendor_Number"];

            if (drContractor_Security["FK_LU_Contract_Type"] == DBNull.Value)
                this._FK_LU_Contract_Type = null;
            else
                this._FK_LU_Contract_Type = (decimal?)drContractor_Security["FK_LU_Contract_Type"];

            this._Dashboard_Type = (int)drContractor_Security["Dashboard_Type"];

            if (drContractor_Security["IS_SRM"] == DBNull.Value)
                this._IS_SRM = null;
            else
                this._IS_SRM = (int?)drContractor_Security["IS_SRM"];

            if (drContractor_Security["IS_GC"] == DBNull.Value)
                this._IS_GC = null;
            else
                this._IS_GC = (int?)drContractor_Security["IS_GC"];

            if (drContractor_Security["FK_LU_User_Status"] == DBNull.Value)
                this._FK_LU_User_Status = null;
            else
                this._FK_LU_User_Status = (decimal)drContractor_Security["FK_LU_User_Status"];
        }



        #endregion

        /// <summary>
        /// Inserts a record into the Contractor_Security table.
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Contractor_SecurityInsert");


            if (string.IsNullOrEmpty(this._User_Name))
                db.AddInParameter(dbCommand, "User_Name", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "User_Name", DbType.String, this._User_Name);

            if (string.IsNullOrEmpty(this._First_Name))
                db.AddInParameter(dbCommand, "First_Name", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "First_Name", DbType.String, this._First_Name);

            if (string.IsNullOrEmpty(this._Last_Name))
                db.AddInParameter(dbCommand, "Last_Name", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Last_Name", DbType.String, this._Last_Name);

            if (string.IsNullOrEmpty(this._Password))
                db.AddInParameter(dbCommand, "Password", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Password", DbType.String, this._Password);

            if (string.IsNullOrEmpty(this._Previous_Password_1))
                db.AddInParameter(dbCommand, "Previous_Password_1", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Previous_Password_1", DbType.String, this._Previous_Password_1);

            if (string.IsNullOrEmpty(this._Previous_Password_2))
                db.AddInParameter(dbCommand, "Previous_Password_2", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Previous_Password_2", DbType.String, this._Previous_Password_2);

            if (string.IsNullOrEmpty(this._Previous_Password_3))
                db.AddInParameter(dbCommand, "Previous_Password_3", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Previous_Password_3", DbType.String, this._Previous_Password_3);

            if (string.IsNullOrEmpty(this._Contractor_Company_Name))
                db.AddInParameter(dbCommand, "Contractor_Company_Name", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Contractor_Company_Name", DbType.String, this._Contractor_Company_Name);

            if (string.IsNullOrEmpty(this._Address_1))
                db.AddInParameter(dbCommand, "Address_1", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Address_1", DbType.String, this._Address_1);

            if (string.IsNullOrEmpty(this._Address_2))
                db.AddInParameter(dbCommand, "Address_2", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Address_2", DbType.String, this._Address_2);

            if (string.IsNullOrEmpty(this._City))
                db.AddInParameter(dbCommand, "City", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "City", DbType.String, this._City);

            db.AddInParameter(dbCommand, "FK_State", DbType.Decimal, this._FK_State);

            if (string.IsNullOrEmpty(this._Zip_Code))
                db.AddInParameter(dbCommand, "Zip_Code", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Zip_Code", DbType.String, this._Zip_Code);

            if (string.IsNullOrEmpty(this._Office_Telephone))
                db.AddInParameter(dbCommand, "Office_Telephone", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Office_Telephone", DbType.String, this._Office_Telephone);

            if (string.IsNullOrEmpty(this._Cell_Telephone))
                db.AddInParameter(dbCommand, "Cell_Telephone", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Cell_Telephone", DbType.String, this._Cell_Telephone);

            if (string.IsNullOrEmpty(this._Pager))
                db.AddInParameter(dbCommand, "Pager", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Pager", DbType.String, this._Pager);

            if (string.IsNullOrEmpty(this._Email))
                db.AddInParameter(dbCommand, "Email", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Email", DbType.String, this._Email);

            db.AddInParameter(dbCommand, "FL_LU_FACILITY_CONSTRUCTION_ALERT_METHOD", DbType.Decimal, this._FL_LU_FACILITY_CONSTRUCTION_ALERT_METHOD);

            if (string.IsNullOrEmpty(this._Texting_Address))
                db.AddInParameter(dbCommand, "Texting_Address", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Texting_Address", DbType.String, this._Texting_Address);

            db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);

            if (string.IsNullOrEmpty(this._Updated_By))
                db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);

            db.AddInParameter(dbCommand, "FK_LU_Contractor_Type", DbType.Decimal, this._FK_LU_Contractor_Type);

            if (!(this._FK_Contractor_Firm.HasValue))
                db.AddInParameter(dbCommand, "FK_Contractor_Firm", DbType.Decimal, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "FK_Contractor_Firm", DbType.Decimal, this._FK_Contractor_Firm);

            db.AddInParameter(dbCommand, "Dashboard_Type", DbType.Decimal, this._Dashboard_Type);

            db.AddInParameter(dbCommand, "Vendor_Number", DbType.String, this._Vendor_Number);

            if (!(this._FK_LU_Contract_Type.HasValue))
                db.AddInParameter(dbCommand, "FK_LU_Contract_Type", DbType.Decimal, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "FK_LU_Contract_Type", DbType.Decimal, this._FK_LU_Contract_Type);

            db.AddInParameter(dbCommand, "IS_SRM", DbType.Int32, this._IS_SRM);

            db.AddInParameter(dbCommand, "IS_GC", DbType.Int32, this._IS_GC);

            db.AddInParameter(dbCommand, "FK_LU_User_Status", DbType.Decimal, clsGeneral.UserStatus.Active);

            // Execute the query and return the new identity value
            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
        }

        /// <summary>
        /// Selects a single record from the Contractor_Security table.
        /// </summary>
        /// <returns>DataSet</returns>
        private DataSet Select(decimal pK_Contactor_Security)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Contractor_SecuritySelect");

            db.AddInParameter(dbCommand, "PK_Contactor_Security", DbType.Decimal, pK_Contactor_Security);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the Contractor_Security table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAll(string SearchString, string strOrderBy, string strOrder, int intPageNo, int intPageSize)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Contractor_SecuritySelectAll");
            db.AddInParameter(dbCommand, "@SearchString", DbType.String, SearchString);
            db.AddInParameter(dbCommand, "@strOrderBy", DbType.String, strOrderBy);
            db.AddInParameter(dbCommand, "@strOrder", DbType.String, strOrder);
            db.AddInParameter(dbCommand, "@intPageNo", DbType.Decimal, intPageNo);
            db.AddInParameter(dbCommand, "@intPageSize", DbType.Decimal, intPageSize);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all active records from the Contractor_Security table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Contractor_SecuritySelectAllActive");

            return db.ExecuteDataSet(dbCommand);
        }


        /// <summary>
        /// Updates a Password in the Contractor_Security table.
        /// </summary>
        public static void UpdateContractorSecurityPassword(decimal PK_Contractor_Security, string PASSWORD, DateTime UPDATE_DATE)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Contractor_SecurityPasswordUpdate");

            db.AddInParameter(dbCommand, "PK_Contractor_Security", DbType.Decimal, PK_Contractor_Security);
            db.AddInParameter(dbCommand, "PASSWORD", DbType.String, PASSWORD);
            db.AddInParameter(dbCommand, "UPDATE_DATE", DbType.DateTime, UPDATE_DATE);
            db.ExecuteScalar(dbCommand);
        }

        public static DataSet GetContractorSecurityByLocation(Int32 locationID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("GetContractorSecurityByLocation");
            db.AddInParameter(dbCommand, "PK_LU_Location_ID", DbType.Decimal, locationID);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Select Management User
        /// </summary>
        public DataSet GetContractorSecurityForManagementUser()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("GetContractorSecurityForManagementUser");

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Select EVP User
        /// </summary>
        public DataSet GetContractorSecurityForEVPUser()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("GetContractorSecurityForEVPUser");

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Updates a record in the Contractor_Security table.
        /// </summary>
        public int Update()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Contractor_SecurityUpdate");


            db.AddInParameter(dbCommand, "PK_Contactor_Security", DbType.Decimal, this._PK_Contactor_Security);

            if (string.IsNullOrEmpty(this._User_Name))
                db.AddInParameter(dbCommand, "User_Name", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "User_Name", DbType.String, this._User_Name);


            if (string.IsNullOrEmpty(this._First_Name))
                db.AddInParameter(dbCommand, "First_Name", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "First_Name", DbType.String, this._First_Name);

            if (string.IsNullOrEmpty(this._Last_Name))
                db.AddInParameter(dbCommand, "Last_Name", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Last_Name", DbType.String, this._Last_Name);

            if (string.IsNullOrEmpty(this._Password))
                db.AddInParameter(dbCommand, "Password", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Password", DbType.String, this._Password);

            if (string.IsNullOrEmpty(this._Previous_Password_1))
                db.AddInParameter(dbCommand, "Previous_Password_1", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Previous_Password_1", DbType.String, this._Previous_Password_1);

            if (string.IsNullOrEmpty(this._Previous_Password_2))
                db.AddInParameter(dbCommand, "Previous_Password_2", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Previous_Password_2", DbType.String, this._Previous_Password_2);

            if (string.IsNullOrEmpty(this._Previous_Password_3))
                db.AddInParameter(dbCommand, "Previous_Password_3", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Previous_Password_3", DbType.String, this._Previous_Password_3);

            if (string.IsNullOrEmpty(this._Contractor_Company_Name))
                db.AddInParameter(dbCommand, "Contractor_Company_Name", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Contractor_Company_Name", DbType.String, this._Contractor_Company_Name);

            if (string.IsNullOrEmpty(this._Address_1))
                db.AddInParameter(dbCommand, "Address_1", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Address_1", DbType.String, this._Address_1);

            if (string.IsNullOrEmpty(this._Address_2))
                db.AddInParameter(dbCommand, "Address_2", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Address_2", DbType.String, this._Address_2);

            if (string.IsNullOrEmpty(this._City))
                db.AddInParameter(dbCommand, "City", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "City", DbType.String, this._City);

            db.AddInParameter(dbCommand, "FK_State", DbType.Decimal, this._FK_State);

            if (string.IsNullOrEmpty(this._Zip_Code))
                db.AddInParameter(dbCommand, "Zip_Code", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Zip_Code", DbType.String, this._Zip_Code);

            if (string.IsNullOrEmpty(this._Office_Telephone))
                db.AddInParameter(dbCommand, "Office_Telephone", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Office_Telephone", DbType.String, this._Office_Telephone);

            if (string.IsNullOrEmpty(this._Cell_Telephone))
                db.AddInParameter(dbCommand, "Cell_Telephone", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Cell_Telephone", DbType.String, this._Cell_Telephone);

            if (string.IsNullOrEmpty(this._Pager))
                db.AddInParameter(dbCommand, "Pager", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Pager", DbType.String, this._Pager);

            if (string.IsNullOrEmpty(this._Email))
                db.AddInParameter(dbCommand, "Email", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Email", DbType.String, this._Email);

            db.AddInParameter(dbCommand, "FL_LU_FACILITY_CONSTRUCTION_ALERT_METHOD", DbType.Decimal, this._FL_LU_FACILITY_CONSTRUCTION_ALERT_METHOD);

            if (string.IsNullOrEmpty(this._Texting_Address))
                db.AddInParameter(dbCommand, "Texting_Address", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Texting_Address", DbType.String, this._Texting_Address);

            db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);

            if (string.IsNullOrEmpty(this._Updated_By))
                db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);

            db.AddInParameter(dbCommand, "FK_LU_Contractor_Type", DbType.Decimal, this._FK_LU_Contractor_Type);

            if (!(this._FK_Contractor_Firm.HasValue))
                db.AddInParameter(dbCommand, "FK_Contractor_Firm", DbType.Decimal, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "FK_Contractor_Firm", DbType.Decimal, this._FK_Contractor_Firm);

            db.AddInParameter(dbCommand, "Dashboard_Type", DbType.Decimal, this._Dashboard_Type);

            db.AddInParameter(dbCommand, "Vendor_Number", DbType.String, this._Vendor_Number);

            if (!(this._FK_LU_Contract_Type.HasValue))
                db.AddInParameter(dbCommand, "FK_LU_Contract_Type", DbType.Decimal, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "FK_LU_Contract_Type", DbType.Decimal, this._FK_LU_Contract_Type);

            db.AddInParameter(dbCommand, "IS_SRM", DbType.Int32, this._IS_SRM);

            db.AddInParameter(dbCommand, "IS_GC", DbType.Int32, this._IS_GC);

            db.AddInParameter(dbCommand, "FK_LU_User_Status", DbType.Decimal, this._FK_LU_User_Status);

            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));
            return returnValue;
        }

        /// <summary>
        /// Deletes a record from the Contractor_Security table by a composite primary key.
        /// </summary>
        public static void DeleteByPKs(string pK_Contactor_Security)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Contractor_SecurityDeleteByPKs");

            db.AddInParameter(dbCommand, "PK_Contactor_Security", DbType.String, pK_Contactor_Security);

            db.ExecuteNonQuery(dbCommand);
        }

        public string ImportContractorSecurityFromVCard(string ActionType)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("ImportContractorSecurityFromVCard");

            if (string.IsNullOrEmpty(this._First_Name))
                db.AddInParameter(dbCommand, "First_Name", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "First_Name", DbType.String, this._First_Name);

            if (string.IsNullOrEmpty(this._Last_Name))
                db.AddInParameter(dbCommand, "Last_Name", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Last_Name", DbType.String, this._Last_Name);

            if (string.IsNullOrEmpty(this._Contractor_Company_Name))
                db.AddInParameter(dbCommand, "Contractor_Company_Name", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Contractor_Company_Name", DbType.String, this._Contractor_Company_Name);

            if (string.IsNullOrEmpty(this._Address_1))
                db.AddInParameter(dbCommand, "Address_1", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Address_1", DbType.String, this._Address_1);

            if (string.IsNullOrEmpty(this._City))
                db.AddInParameter(dbCommand, "City", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "City", DbType.String, this._City);

            if (string.IsNullOrEmpty(this._State))
                db.AddInParameter(dbCommand, "State", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "State", DbType.String, this._State);

            if (string.IsNullOrEmpty(this._Zip_Code))
                db.AddInParameter(dbCommand, "Zip_Code", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Zip_Code", DbType.String, this._Zip_Code);

            if (string.IsNullOrEmpty(this._Office_Telephone))
                db.AddInParameter(dbCommand, "Office_Telephone", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Office_Telephone", DbType.String, this._Office_Telephone);

            if (string.IsNullOrEmpty(this._Cell_Telephone))
                db.AddInParameter(dbCommand, "Cell_Telephone", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Cell_Telephone", DbType.String, this._Cell_Telephone);

            if (string.IsNullOrEmpty(this._Pager))
                db.AddInParameter(dbCommand, "Pager", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Pager", DbType.String, this._Pager);

            if (string.IsNullOrEmpty(this._Email))
                db.AddInParameter(dbCommand, "Email", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Email", DbType.String, this._Email);

            //db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);

            if (string.IsNullOrEmpty(this._Updated_By))
                db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);

            db.AddInParameter(dbCommand, "ActionType", DbType.String, ActionType);

            db.AddInParameter(dbCommand, "PK_Contactor_Security", DbType.Decimal, this._PK_Contactor_Security);

            db.AddInParameter(dbCommand, "FK_LU_User_Status", DbType.Decimal, clsGeneral.UserStatus.Active);

            db.AddOutParameter(dbCommand, "Status", DbType.String, 10);
            // Execute the query and return the new identity value
            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));
            PK_Contactor_Security = returnValue;
            return Convert.ToString(db.GetParameterValue(dbCommand, "Status"));
        }

        /// <summary>
        /// Selects a single record from the Security table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectByUserName(string pUser_Name)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("ContractorSecuritySelectByUserName");

            db.AddInParameter(dbCommand, "User_Name", DbType.String, pUser_Name);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects the Contractor Users From Loaction ID and ProjectID.
        /// </summary>
        /// <param name="userID">The user identifier.</param>
        /// <returns></returns>
        public static DataSet SelectContractorUserByLoactionIDAndProjectID(decimal PK_LocationID, decimal PK_Facility_construction_ProjectID)
        {
            // Create Database object
            Database db = DatabaseFactory.CreateDatabase();
            // Create a suitable command type and add the required parameter
            using (DbCommand dbCommand = db.GetStoredProcCommand("getContractorUserFromLoactionIDAndProjectID"))
            {
                db.AddInParameter(dbCommand, "PK_Facility_construction_ProjectID", DbType.Int32, PK_Facility_construction_ProjectID);
                db.AddInParameter(dbCommand, "PK_LU_Location_ID", DbType.Int32, PK_LocationID);
                db.AddInParameter(dbCommand, "TableName", DbType.String, "Contractor_Security");
                return db.ExecuteDataSet(dbCommand);
            }
        }


        /// <summary>
        /// Selects the Contractor Users From Loaction ID.
        /// </summary>
        /// <param name="userID">The user identifier.</param>
        /// <returns></returns>
        public static DataSet SelectContractorUserByLoactionID(decimal PK_LocationID)
        {
            // Create Database object
            Database db = DatabaseFactory.CreateDatabase();
            // Create a suitable command type and add the required parameter
            using (DbCommand dbCommand = db.GetStoredProcCommand("getContractorUserFromLoactionID"))
            {
                db.AddInParameter(dbCommand, "PK_LU_Location_ID", DbType.Int32, PK_LocationID);
                db.AddInParameter(dbCommand, "TableName", DbType.String, "Contractor_Security");
                return db.ExecuteDataSet(dbCommand);
            }
        }

        /// <summary>
        /// Copy all projects from source to target 
        /// </summary>
        /// <param name="target_FK_Contractor_Security"></param>
        /// <param name="source_FK_Contrator_Security"></param>
        /// <param name="updatedBy"></param>
        /// <returns></returns>
        public static int CopyProjects(int target_FK_Contractor_Security, int source_FK_Contrator_Security, int updatedBy)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Contractor_SecurityCopyProjects");

            db.AddInParameter(dbCommand, "Target_FK_Contractor_Security", DbType.Decimal, target_FK_Contractor_Security);

            db.AddInParameter(dbCommand, "Source_FK_Contractor_Security", DbType.Decimal, source_FK_Contrator_Security);

            db.AddInParameter(dbCommand, "Updated_By", DbType.Decimal, updatedBy);
            
            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
        }

        /// <summary>
        /// Select All user except current specified
        /// </summary>
        /// <param name="FK_Contractor_Security"></param>
        /// <returns></returns>
        public static DataSet SelectAllExceptCurrentUser(int FK_Contractor_Security)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Contractor_SecuritySelectAllExceptCurrentUser");

            db.AddInParameter(dbCommand, "PK_Contractor_Security", DbType.Decimal, FK_Contractor_Security);

            return db.ExecuteDataSet(dbCommand);
        }


        /// <summary>
        /// Selects all Maintenance type user records from the Contractor_Security table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAllMaintenanceUser()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Contractor_SecuritySelectAllMaintenanceUser");
            return db.ExecuteDataSet(dbCommand);
        }



        
        /// <summary>
        /// select user with EVP OR Management Role
        /// </summary>
        /// <param name="FK_LU_Contractor_Type"></param>
        /// <returns></returns>
        public DataSet SelectEVPMGMTRoleForUser(decimal? FK_LU_Contractor_Type, decimal? PK_Contactor_Security)
        {

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Select_EVP_MGMT_RoleForUser");
           
            db.AddInParameter(dbCommand, "FK_LU_Contractor_Type", DbType.Decimal, FK_LU_Contractor_Type);
            db.AddInParameter(dbCommand, "PK_Contactor_Security", DbType.Decimal, PK_Contactor_Security);

            return db.ExecuteDataSet(dbCommand);
        }

    


    }
}
