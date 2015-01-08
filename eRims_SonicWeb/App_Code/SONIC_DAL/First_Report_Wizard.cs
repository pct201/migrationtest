using System;
using System.Data;
using System.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{


    /// <summary>
    /// Data access class for First_Report_Wizard table.
    /// </summary>
    public sealed class First_Report_Wizard
    {
        /// <summary>
        /// Enum for the Report Type in First Report Module
        /// </summary>
        public enum Tables : int
        {
            WC_FR = 0,
            AL_FR = 1,
            PL_FR = 2,
            DPD_FR = 3,
            Property_FR = 4
        }

        #region Fields


        private decimal _PK_First_Report_Wizard_ID;
        private decimal _FK_Location_ID;
        private decimal _FK_Employee_ID;
        private bool _Injured_Employee;
        private bool _Inventoried_Vehicle;
        private bool _Customer_Vehicle;
        private bool _Other_Vehicle;
        private bool _General_Claim;
        private bool _Property_Claim;
        private string _Contact_Fax;
        private string _Contact_Best_Time;
        private string _TelephoneNumber1;
        private string _TelephoneNumber2;
        private string _Email;

        #endregion


        #region Properties


        /// <summary> 
        /// Gets or sets the PK_First_Report_Wizard_ID value.
        /// </summary>
        public decimal PK_First_Report_Wizard_ID
        {
            get { return _PK_First_Report_Wizard_ID; }
            set { _PK_First_Report_Wizard_ID = value; }
        }


        /// <summary> 
        /// Gets or sets the FK_Location_ID value.
        /// </summary>
        public decimal FK_Location_ID
        {
            get { return _FK_Location_ID; }
            set { _FK_Location_ID = value; }
        }


        /// <summary> 
        /// Gets or sets the FK_Employee_ID value.
        /// </summary>
        public decimal FK_Employee_ID
        {
            get { return _FK_Employee_ID; }
            set { _FK_Employee_ID = value; }
        }


        /// <summary> 
        /// Gets or sets the Injured_Employee value.
        /// </summary>
        public bool Injured_Employee
        {
            get { return _Injured_Employee; }
            set { _Injured_Employee = value; }
        }


        /// <summary> 
        /// Gets or sets the Inventoried_Vehicle value.
        /// </summary>
        public bool Inventoried_Vehicle
        {
            get { return _Inventoried_Vehicle; }
            set { _Inventoried_Vehicle = value; }
        }


        /// <summary> 
        /// Gets or sets the Customer_Vehicle value.
        /// </summary>
        public bool Customer_Vehicle
        {
            get { return _Customer_Vehicle; }
            set { _Customer_Vehicle = value; }
        }


        /// <summary> 
        /// Gets or sets the Other_Vehicle value.
        /// </summary>
        public bool Other_Vehicle
        {
            get { return _Other_Vehicle; }
            set { _Other_Vehicle = value; }
        }


        /// <summary> 
        /// Gets or sets the General_Claim value.
        /// </summary>
        public bool General_Claim
        {
            get { return _General_Claim; }
            set { _General_Claim = value; }
        }


        /// <summary> 
        /// Gets or sets the Property_Claim value.
        /// </summary>
        public bool Property_Claim
        {
            get { return _Property_Claim; }
            set { _Property_Claim = value; }
        }


        /// <summary> 
        /// Gets or sets the Contact_Fax value.
        /// </summary>
        public string Contact_Fax
        {
            get { return _Contact_Fax; }
            set { _Contact_Fax = value; }
        }


        /// <summary> 
        /// Gets or sets the Contact_Best_Time value.
        /// </summary>
        public string Contact_Best_Time
        {
            get { return _Contact_Best_Time; }
            set { _Contact_Best_Time = value; }
        }


        /// <summary> 
        /// Gets or sets the Contact_Fax value.
        /// </summary>
        public string TelephoneNumber1
        {
            get { return _TelephoneNumber1; }
            set { _TelephoneNumber1 = value; }
        }


        /// <summary> 
        /// Gets or sets the Contact_Best_Time value.
        /// </summary>
        public string TelephoneNumber2
        {
            get { return _TelephoneNumber2; }
            set { _TelephoneNumber2 = value; }
        }

        /// <summary> 
        /// Gets or sets the Contact_Best_Time value.
        /// </summary>
        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }

        #endregion


        #region Constructors

        /// <summary> 

        /// Initializes a new instance of the First_Report_Wizard class. with the default value.

        /// </summary>
        public First_Report_Wizard()
        {

            this._PK_First_Report_Wizard_ID = -1;
            this._FK_Location_ID = -1;
            this._FK_Employee_ID = -1;
            this._Injured_Employee = false;
            this._Inventoried_Vehicle = false;
            this._Customer_Vehicle = false;
            this._Other_Vehicle = false;
            this._General_Claim = false;
            this._Property_Claim = false;
            this._Contact_Fax = "";
            this._Contact_Best_Time = "";
            this._TelephoneNumber1 = "";
            this._TelephoneNumber2 = "";
            this._Email = "";

        }



        /// <summary> 

        /// Initializes a new instance of the First_Report_Wizard class for passed PrimaryKey with the values set from Database.


        /// </summary>
        public First_Report_Wizard(decimal PK)
        {

            DataTable dtFirst_Report_Wizard = SelectByPK(PK).Tables[0];

            if (dtFirst_Report_Wizard.Rows.Count > 0)
            {

                DataRow drFirst_Report_Wizard = dtFirst_Report_Wizard.Rows[0];

                this._PK_First_Report_Wizard_ID = drFirst_Report_Wizard["PK_First_Report_Wizard_ID"] != DBNull.Value ? Convert.ToDecimal(drFirst_Report_Wizard["PK_First_Report_Wizard_ID"]) : 0;
                this._FK_Location_ID = drFirst_Report_Wizard["FK_Location_ID"] != DBNull.Value ? Convert.ToDecimal(drFirst_Report_Wizard["FK_Location_ID"]) : 0;
                this._FK_Employee_ID = drFirst_Report_Wizard["FK_Employee_ID"] != DBNull.Value ? Convert.ToDecimal(drFirst_Report_Wizard["FK_Employee_ID"]) : 0;
                this._Injured_Employee = drFirst_Report_Wizard["Injured_Employee"] != DBNull.Value ? Convert.ToBoolean(drFirst_Report_Wizard["Injured_Employee"]) : false;
                this._Inventoried_Vehicle = drFirst_Report_Wizard["Inventoried_Vehicle"] != DBNull.Value ? Convert.ToBoolean(drFirst_Report_Wizard["Inventoried_Vehicle"]) : false;
                this._Customer_Vehicle = drFirst_Report_Wizard["Customer_Vehicle"] != DBNull.Value ? Convert.ToBoolean(drFirst_Report_Wizard["Customer_Vehicle"]) : false;
                this._Other_Vehicle = drFirst_Report_Wizard["Other_Vehicle"] != DBNull.Value ? Convert.ToBoolean(drFirst_Report_Wizard["Other_Vehicle"]) : false;
                this._General_Claim = drFirst_Report_Wizard["General_Claim"] != DBNull.Value ? Convert.ToBoolean(drFirst_Report_Wizard["General_Claim"]) : false;
                this._Property_Claim = drFirst_Report_Wizard["Property_Claim"] != DBNull.Value ? Convert.ToBoolean(drFirst_Report_Wizard["Property_Claim"]) : false;
                this._Contact_Fax = Convert.ToString(drFirst_Report_Wizard["Contact_Fax"]);
                this._Contact_Best_Time = Convert.ToString(drFirst_Report_Wizard["Contact_Best_Time"]);
                this._TelephoneNumber1 = Convert.ToString(drFirst_Report_Wizard["TelephoneNumber1"]);
                this._TelephoneNumber2 = Convert.ToString(drFirst_Report_Wizard["TelephoneNumber2"]);
                this._Email = Convert.ToString(drFirst_Report_Wizard["Email"]);

            }
            else
            {
                this._PK_First_Report_Wizard_ID = -1;
                this._FK_Location_ID = -1;
                this._FK_Employee_ID = -1;
                this._Injured_Employee = false;
                this._Inventoried_Vehicle = false;
                this._Customer_Vehicle = false;
                this._Other_Vehicle = false;
                this._General_Claim = false;
                this._Property_Claim = false;
                this._Contact_Fax = "";
                this._Contact_Best_Time = "";
                this._TelephoneNumber1 = "";
                this._TelephoneNumber2 = "";
                this._Email = "";

            }

        }

        #endregion


        #region Methods
        /// <summary>
        /// Inserts a record into the First_Report_Wizard table.
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("First_Report_WizardInsert_New");

            db.AddInParameter(dbCommand, "FK_Location_ID", DbType.Decimal, this._FK_Location_ID);
            db.AddInParameter(dbCommand, "FK_Employee_ID", DbType.Decimal, this._FK_Employee_ID);
            db.AddInParameter(dbCommand, "Injured_Employee", DbType.Boolean, this._Injured_Employee);
            db.AddInParameter(dbCommand, "Inventoried_Vehicle", DbType.Boolean, this._Inventoried_Vehicle);
            db.AddInParameter(dbCommand, "Customer_Vehicle", DbType.Boolean, this._Customer_Vehicle);
            db.AddInParameter(dbCommand, "Other_Vehicle", DbType.Boolean, this._Other_Vehicle);
            db.AddInParameter(dbCommand, "General_Claim", DbType.Boolean, this._General_Claim);
            db.AddInParameter(dbCommand, "Property_Claim", DbType.Boolean, this._Property_Claim);
            db.AddInParameter(dbCommand, "Contact_Fax", DbType.String, this._Contact_Fax);
            db.AddInParameter(dbCommand, "Contact_Best_Time", DbType.String, this._Contact_Best_Time);
            db.AddInParameter(dbCommand, "TelephoneNumber1", DbType.String, this._TelephoneNumber1);
            db.AddInParameter(dbCommand, "TelephoneNumber2", DbType.String, this._TelephoneNumber2);
            db.AddInParameter(dbCommand, "Email", DbType.String, this._Email);
            db.AddInParameter(dbCommand, "Updated_By", DbType.Decimal, clsSession.UserID);
            db.AddInParameter(dbCommand, "Updated_Date", DbType.DateTime, DateTime.Now);
            // Execute the query and return the new identity value
            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
        }

        /// <summary>
        /// Add NEw Report
        /// </summary>
        /// <returns></returns>
        public int AddNewReport()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("AddNewReport");

            db.AddInParameter(dbCommand, "First_Report_Wizard_ID", DbType.Decimal, this._PK_First_Report_Wizard_ID);
            db.AddInParameter(dbCommand, "Injured_Employee", DbType.Boolean, this._Injured_Employee);
            db.AddInParameter(dbCommand, "Inventoried_Vehicle", DbType.Boolean, this._Inventoried_Vehicle);
            db.AddInParameter(dbCommand, "Customer_Vehicle", DbType.Boolean, this._Customer_Vehicle);
            db.AddInParameter(dbCommand, "Other_Vehicle", DbType.Boolean, this._Other_Vehicle);
            db.AddInParameter(dbCommand, "General_Claim", DbType.Boolean, this._General_Claim);
            db.AddInParameter(dbCommand, "Property_Claim", DbType.Boolean, this._Property_Claim);
            db.AddInParameter(dbCommand, "Updated_By", DbType.Decimal, clsSession.UserID);
            db.AddInParameter(dbCommand, "Updated_Date", DbType.DateTime, DateTime.Now);
            // Execute the query and return the new identity value
            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
        }
        /// <summary>
        /// Selects a single record from the First_Report_Wizard table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectByPK(decimal pK_First_Report_Wizard_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("First_Report_WizardSelectByPK");

            db.AddInParameter(dbCommand, "PK_First_Report_Wizard_ID", DbType.Decimal, pK_First_Report_Wizard_ID);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the First_Report_Wizard table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("First_Report_WizardSelectAll");

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Updates a record in the First_Report_Wizard table.
        /// </summary>
        public void Update()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("First_Report_WizardUpdate");

            db.AddInParameter(dbCommand, "PK_First_Report_Wizard_ID", DbType.Decimal, this._PK_First_Report_Wizard_ID);
            db.AddInParameter(dbCommand, "FK_Location_ID", DbType.Decimal, this._FK_Location_ID);
            db.AddInParameter(dbCommand, "FK_Employee_ID", DbType.Decimal, this._FK_Employee_ID);
            db.AddInParameter(dbCommand, "Injured_Employee", DbType.Boolean, this._Injured_Employee);
            db.AddInParameter(dbCommand, "Inventoried_Vehicle", DbType.Boolean, this._Inventoried_Vehicle);
            db.AddInParameter(dbCommand, "Customer_Vehicle", DbType.Boolean, this._Customer_Vehicle);
            db.AddInParameter(dbCommand, "Other_Vehicle", DbType.Boolean, this._Other_Vehicle);
            db.AddInParameter(dbCommand, "General_Claim", DbType.Boolean, this._General_Claim);
            db.AddInParameter(dbCommand, "Property_Claim", DbType.Boolean, this._Property_Claim);
            db.AddInParameter(dbCommand, "Contact_Fax", DbType.String, this._Contact_Fax);
            db.AddInParameter(dbCommand, "Contact_Best_Time", DbType.String, this._Contact_Best_Time);
            db.AddInParameter(dbCommand, "TelephoneNumber1", DbType.String, this._TelephoneNumber1);
            db.AddInParameter(dbCommand, "TelephoneNumber2", DbType.String, this._TelephoneNumber2);
            db.AddInParameter(dbCommand, "Email", DbType.String, this._Email);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Deletes a record from the First_Report_Wizard table by a composite primary key.
        /// </summary>
        public static void DeleteByPK(decimal pK_First_Report_Wizard_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("First_Report_WizardDeleteByPK");

            db.AddInParameter(dbCommand, "PK_First_Report_Wizard_ID", DbType.Decimal, pK_First_Report_Wizard_ID);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// GEt Contact Information and Location Information By Wizard ID
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet GetInfoByWizardID(decimal pK_First_Report_Wizard_ID, First_Report_Wizard.Tables tbl, decimal FK_First_Report_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("GetContactandLocationInfo_byWizardID");

            db.AddInParameter(dbCommand, "@PK_First_Report_Wizard_ID", DbType.Decimal, pK_First_Report_Wizard_ID);
            db.AddInParameter(dbCommand, "@First_Report_Table", DbType.String, tbl);
            db.AddInParameter(dbCommand, "@FK_First_Report_ID", DbType.Decimal, FK_First_Report_ID);
            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// GEt Search Result
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet GetSearchResults(decimal LocationNumber, Nullable<DateTime> DateOfIncident,string strIncidentStartDate,string IncidentEndDate, decimal FirstReportNumber, decimal EmployeeID, string strOrderBy, string strOrder, int intPageNo, int intPageSize, string Regional, Nullable<decimal> CurrentEmployee, string ClaimType)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("SearchFirstReports");

            db.AddInParameter(dbCommand, "@LocationNumber", DbType.Decimal, LocationNumber);
            db.AddInParameter(dbCommand, "@DateOfIncident", DbType.DateTime, DateOfIncident);
            db.AddInParameter(dbCommand, "@IncidentStartDate", DbType.String, strIncidentStartDate);
            db.AddInParameter(dbCommand, "@IncidentEndDate", DbType.String, IncidentEndDate);
            db.AddInParameter(dbCommand, "@FirstReportNumber", DbType.Decimal, FirstReportNumber);
            db.AddInParameter(dbCommand, "@EmployeeID", DbType.Decimal, EmployeeID);
            db.AddInParameter(dbCommand, "@strOrderBy", DbType.String, strOrderBy);
            db.AddInParameter(dbCommand, "@strOrder", DbType.String, strOrder);
            db.AddInParameter(dbCommand, "@intPageNo", DbType.Decimal, intPageNo);
            db.AddInParameter(dbCommand, "@intPageSize", DbType.Decimal, intPageSize);
            db.AddInParameter(dbCommand, "@Regional", DbType.String, Regional);
            db.AddInParameter(dbCommand, "@CurrentEmployee", DbType.Decimal, CurrentEmployee);
            db.AddInParameter(dbCommand, "@ClaimType", DbType.String, ClaimType);

            return db.ExecuteDataSet(dbCommand);
        }
        //
        /// <summary>
        /// Delete all record related to Passed PK_ID and Table Name
        /// </summary>
        public static Int32 DeleteFirstReport(decimal PK_ID, First_Report_Wizard.Tables tbl)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("DeleteFirstReport");

            db.AddInParameter(dbCommand, "@PK_ID", DbType.Decimal, PK_ID);
            db.AddInParameter(dbCommand, "@First_Report_Table", DbType.String, tbl);
            db.AddInParameter(dbCommand, "@Deleted_By", DbType.Decimal, Convert.ToDecimal(clsSession.UserID));

            object retVal = db.ExecuteScalar(dbCommand);

            return Convert.ToInt32(retVal);
        }

        /// <summary>
        /// Select Wizard ID having Un-complete First Reports
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectWizardWithUncompleteReport(decimal EmployeeId)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("GetUncompleteReportID");

            db.AddInParameter(dbCommand, "EmployeeId", DbType.Decimal, EmployeeId);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// GEt Search Result
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SearchFirstReportsForEvent(decimal LocationNumber, decimal FirstReportNumber, string ClaimType, string Regional, Nullable<decimal> CurrentEmployee)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("SearchFirstReportsForEvent");

            db.AddInParameter(dbCommand, "@LocationNumber", DbType.Decimal, LocationNumber);
            db.AddInParameter(dbCommand, "@FirstReportNumber", DbType.Decimal, FirstReportNumber);
            db.AddInParameter(dbCommand, "@ClaimType", DbType.String, ClaimType);
            db.AddInParameter(dbCommand, "@Regional", DbType.String, Regional);
            db.AddInParameter(dbCommand, "@CurrentEmployee", DbType.Decimal, CurrentEmployee);

            return db.ExecuteDataSet(dbCommand);
        }

        #endregion
    }
}
