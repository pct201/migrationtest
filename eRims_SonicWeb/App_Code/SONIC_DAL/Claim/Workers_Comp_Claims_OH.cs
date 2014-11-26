using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
    /// <summary>
    /// Data access class for Workers_Comp_Claims_OH table.
    /// </summary>
    public sealed class Workers_Comp_Claims_OH
    {

        #region Private variables used to hold the property values

        private decimal? _PK_Workers_Comp_Claims_OH_Id;
        private decimal? _FK_WC_RD_Id;
        private string _Claim_Number;
        private DateTime? _Date_Entered;
        private DateTime? _Date_Closed;
        private DateTime? _Date_Reopened;
        private string _Active_InActive;
        private DateTime? _Date_Of_Incident;
        private string _Type;
        private decimal? _Total_Medical;
        private decimal? _Total_Comp;
        private decimal? _Total_Reserve;
        private decimal? _Unlimited_Cost;
        private decimal? _Limited_to_MV;
        private decimal? _HC_Percent;
        private decimal? _HC_Relief;
        private decimal? _Subrogation_Collected;
        private string _Claim_Activity;
        private decimal? _Total_Charged;
        private string _Imported;
        private string _Updated_By;
        private DateTime? _Update_Date;

        #endregion

        #region Public Property

        

        /// <summary>
        /// Gets or sets the PK_Workers_Comp_Claims_OH_Id value.
        /// </summary>
        public decimal? PK_Workers_Comp_Claims_OH_Id
        {
            get { return _PK_Workers_Comp_Claims_OH_Id; }
            set { _PK_Workers_Comp_Claims_OH_Id = value; }
        }

        /// <summary>
        /// Gets or sets the FK_WC_RD_Id value.
        /// </summary>
        public decimal? FK_WC_RD_Id
        {
            get { return _FK_WC_RD_Id; }
            set { _FK_WC_RD_Id = value; }
        }

        /// <summary>
        /// Gets or sets the Claim_Number value.
        /// </summary>
        public string Claim_Number
        {
            get { return _Claim_Number; }
            set { _Claim_Number = value; }
        }

        /// <summary>
        /// Gets or sets the Date_Entered value.
        /// </summary>
        public DateTime? Date_Entered
        {
            get { return _Date_Entered; }
            set { _Date_Entered = value; }
        }

        /// <summary>
        /// Gets or sets the Date_Closed value.
        /// </summary>
        public DateTime? Date_Closed
        {
            get { return _Date_Closed; }
            set { _Date_Closed = value; }
        }

        /// <summary>
        /// Gets or sets the Date_Reopened value.
        /// </summary>
        public DateTime? Date_Reopened
        {
            get { return _Date_Reopened; }
            set { _Date_Reopened = value; }
        }

        /// <summary>
        /// Get or set Active Inactive value
        /// </summary>
        public string Active_InActive 
        {
            get
            {
                return _Active_InActive;
            }
            set
            {
                _Active_InActive = value;
            }
        }

        /// <summary>
        /// get or set Date of Incident
        /// </summary>
        public DateTime? Date_Of_Incident 
        {
            get
            {
                return _Date_Of_Incident;
            }
            set
            {
                _Date_Of_Incident = value;
            }
        }

        /// <summary>
        /// Get or set Type value
        /// </summary>
        public string Type 
        {
            get { return _Type; }
            set { _Type = value; }
        }

        /// <summary>
        /// Get or set Total Medical value
        /// </summary>
        public decimal? Total_Medical 
        {
            get { return _Total_Medical; }
            set { _Total_Medical = value; }
        }

        /// <summary>
        /// Get or Set Total Comp
        /// </summary>
        public decimal? Total_Comp 
        {
            get { return _Total_Comp; }
            set { _Total_Comp = value; }
        }

        /// <summary>
        /// Get or Set Total Reserve
        /// </summary>
        public decimal? Total_Reserve 
        {
            get { return _Total_Reserve;  }
            set { _Total_Reserve = value; }
        }

        /// <summary>
        /// Get or Set Unlimited Cost
        /// </summary>
        public decimal? Unlimited_Cost 
        {
            get { return _Unlimited_Cost; }
            set { _Unlimited_Cost = value; }
        }

        /// <summary>
        /// Get or set Limited_to_MV
        /// </summary>
        public decimal? Limited_to_MV 
        {
            get { return _Limited_to_MV; }
            set { _Limited_to_MV = value; }
        }

        /// <summary>
        /// Get or set HC Percent
        /// </summary>
        public decimal? HC_Percent 
        {
            get { return _HC_Percent; }
            set { _HC_Percent = value; }
        }

        /// <summary>
        /// get or set HC Relief
        /// </summary>
        public decimal? HC_Relief 
        {
            get { return _HC_Relief; }
            set { _HC_Relief = value; }
        }

        /// <summary>
        /// Get or Set Subrogation Collected
        /// </summary>
        public decimal? Subrogation_Collected 
        {
            get { return _Subrogation_Collected; }
            set { _Subrogation_Collected = value; }
        }

        /// <summary>
        ///  Get or Set Claim Activity
        /// </summary>
        public string Claim_Activity 
        {
            get { return _Claim_Activity; }
            set { _Claim_Activity = value; }
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
        /// Get or set Imported value in table
        /// </summary>
        public string Imported
        {
            get { return _Imported; }
            set { _Imported = value; }
        }

        /// <summary>
        /// Get or set Total charged value
        /// </summary>
        public decimal? Total_Charged 
        {
            get { return _Total_Charged; }
            set { _Total_Charged = value; }
        }


        #endregion

        #region Default Constructors

        /// <summary>
        /// Initializes a new instance of the Workers_Comp_Claims_OH class with default value.
        /// </summary>
        public Workers_Comp_Claims_OH()
        {

            this._PK_Workers_Comp_Claims_OH_Id = null;
            this._FK_WC_RD_Id = null;
            this._Claim_Number = null;
            this._Date_Entered = null;
            this._Date_Closed = null;
            this._Date_Reopened = null;
            this._Updated_By = null;
            this._Update_Date = null;

        }

        #endregion

        #region Primary Constructors

        /// <summary>
        /// Initializes a new instance of the Workers_Comp_Claims_OH class based on Primary Key.
        /// </summary>
        public Workers_Comp_Claims_OH(decimal pK_Workers_Comp_Claims_OH_Id)
        {
            DataTable dtWorkers_Comp_Claims_OH = SelectByPK(pK_Workers_Comp_Claims_OH_Id).Tables[0];

            if (dtWorkers_Comp_Claims_OH.Rows.Count == 1)
            {
                DataRow drWorkers_Comp_Claims_OH = dtWorkers_Comp_Claims_OH.Rows[0];
                if (drWorkers_Comp_Claims_OH["PK_Workers_Comp_Claims_OH_Id"] == DBNull.Value)
                    this._PK_Workers_Comp_Claims_OH_Id = null;
                else
                    this._PK_Workers_Comp_Claims_OH_Id = (decimal?)drWorkers_Comp_Claims_OH["PK_Workers_Comp_Claims_OH_Id"];

                if (drWorkers_Comp_Claims_OH["FK_WC_RD_Id"] == DBNull.Value)
                    this._FK_WC_RD_Id = null;
                else
                    this._FK_WC_RD_Id = (decimal?)drWorkers_Comp_Claims_OH["FK_WC_RD_Id"];

                if (drWorkers_Comp_Claims_OH["Claim_Number"] == DBNull.Value)
                    this._Claim_Number = null;
                else
                    this._Claim_Number = (string)drWorkers_Comp_Claims_OH["Claim_Number"];

                if (drWorkers_Comp_Claims_OH["Date_Entered"] == DBNull.Value)
                    this._Date_Entered = null;
                else
                    this._Date_Entered = (DateTime?)drWorkers_Comp_Claims_OH["Date_Entered"];

                if (drWorkers_Comp_Claims_OH["Date_Closed"] == DBNull.Value)
                    this._Date_Closed = null;
                else
                    this._Date_Closed = (DateTime?)drWorkers_Comp_Claims_OH["Date_Closed"];

                if (drWorkers_Comp_Claims_OH["Date_Reopened"] == DBNull.Value)
                    this._Date_Reopened = null;
                else
                    this._Date_Reopened = (DateTime?)drWorkers_Comp_Claims_OH["Date_Reopened"];
                
                if (drWorkers_Comp_Claims_OH["Active_InActive"] == DBNull.Value)
                    this._Active_InActive = null;
                else
                    this._Active_InActive = Convert.ToString(drWorkers_Comp_Claims_OH["Active_InActive"]);

                if (drWorkers_Comp_Claims_OH["Date_Of_Incident"] == DBNull.Value)
                    this._Date_Of_Incident = null;
                else
                    this._Date_Of_Incident = (DateTime?)drWorkers_Comp_Claims_OH["Date_Of_Incident"];

                if (drWorkers_Comp_Claims_OH["Type"] == DBNull.Value)
                    this._Type = null;
                else
                    this._Type = Convert.ToString(drWorkers_Comp_Claims_OH["Type"]);

                if (drWorkers_Comp_Claims_OH["Total_Medical"] == DBNull.Value)
                    this._Total_Medical = null;
                else
                    this._Total_Medical = Convert.ToDecimal(drWorkers_Comp_Claims_OH["Total_Medical"]);

                if (drWorkers_Comp_Claims_OH["Total_Comp"] == DBNull.Value)
                    this._Total_Comp = null;
                else
                    this._Total_Comp = Convert.ToDecimal(drWorkers_Comp_Claims_OH["Total_Comp"]);

                if (drWorkers_Comp_Claims_OH["Total_Reserve"] == DBNull.Value)
                    this._Total_Reserve = null;
                else
                    this._Total_Reserve = Convert.ToDecimal(drWorkers_Comp_Claims_OH["Total_Reserve"]);

                if (drWorkers_Comp_Claims_OH["Unlimited_Cost"] == DBNull.Value)
                    this._Unlimited_Cost = null;
                else
                    this._Unlimited_Cost = Convert.ToDecimal(drWorkers_Comp_Claims_OH["Unlimited_Cost"]);

                if (drWorkers_Comp_Claims_OH["Limited_to_MV"] == DBNull.Value)
                    this._Limited_to_MV = null;
                else
                    this._Limited_to_MV = Convert.ToDecimal(drWorkers_Comp_Claims_OH["Limited_to_MV"]);

                if (drWorkers_Comp_Claims_OH["HC_Percent"] == DBNull.Value)
                    this._HC_Percent = null;
                else
                    this._HC_Percent = Convert.ToDecimal(drWorkers_Comp_Claims_OH["HC_Percent"]);

                if (drWorkers_Comp_Claims_OH["HC_Relief"] == DBNull.Value)
                    this._HC_Relief = null;
                else
                    this._HC_Relief = Convert.ToDecimal(drWorkers_Comp_Claims_OH["HC_Relief"]);

                if (drWorkers_Comp_Claims_OH["Subrogation_Collected"] == DBNull.Value)
                    this._Subrogation_Collected = null;
                else
                    this._Subrogation_Collected = Convert.ToDecimal(drWorkers_Comp_Claims_OH["Subrogation_Collected"]);

                if (drWorkers_Comp_Claims_OH["Claim_Activity"] == DBNull.Value)
                    this._Claim_Activity = null;
                else
                    this._Claim_Activity = Convert.ToString(drWorkers_Comp_Claims_OH["Claim_Activity"]);


                if (drWorkers_Comp_Claims_OH["Updated_By"] == DBNull.Value)
                    this._Updated_By = null;
                else
                    this._Updated_By = (string)drWorkers_Comp_Claims_OH["Updated_By"];

                if (drWorkers_Comp_Claims_OH["Update_Date"] == DBNull.Value)
                    this._Update_Date = null;
                else
                    this._Update_Date = (DateTime?)drWorkers_Comp_Claims_OH["Update_Date"];

                if (drWorkers_Comp_Claims_OH["Total_Charged"] == DBNull.Value)
                    this._Total_Charged = null;
                else
                    this._Total_Charged = Convert.ToDecimal(drWorkers_Comp_Claims_OH["Total_Charged"]);

                if (drWorkers_Comp_Claims_OH["Imported"] == DBNull.Value)
                    this._Imported = null;
                else
                    this._Imported = Convert.ToString(drWorkers_Comp_Claims_OH["Imported"]);

            }
            else
            {
                this._PK_Workers_Comp_Claims_OH_Id = null;
                this._FK_WC_RD_Id = null;
                this._Claim_Number = null;
                this._Date_Entered = null;
                this._Date_Closed = null;
                this._Date_Reopened = null;
                this._Updated_By = null;
                this._Update_Date = null;
            }

        }

        #endregion

        /// <summary>
        /// Inserts a record into the Workers_Comp_Claims_OH table.
        /// </summary>
        /// <returns></returns>
        public decimal Insert()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Workers_Comp_Claims_OHInsert");


            db.AddInParameter(dbCommand, "FK_WC_RD_Id", DbType.Decimal, this._FK_WC_RD_Id);

            if (string.IsNullOrEmpty(this._Claim_Number))
                db.AddInParameter(dbCommand, "Claim_Number", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Claim_Number", DbType.String, this._Claim_Number);

            db.AddInParameter(dbCommand, "Date_Entered", DbType.DateTime, this._Date_Entered);

            db.AddInParameter(dbCommand, "Date_Closed", DbType.DateTime, this._Date_Closed);

            db.AddInParameter(dbCommand, "Date_Reopened", DbType.DateTime, this._Date_Reopened);

            db.AddInParameter(dbCommand, "Active_InActive", DbType.String, this._Active_InActive);

            db.AddInParameter(dbCommand, "Date_Of_Incident", DbType.DateTime, this._Date_Of_Incident);

            db.AddInParameter(dbCommand, "Type", DbType.String, this._Type);

            db.AddInParameter(dbCommand, "Total_Medical", DbType.Decimal, this._Total_Medical);

            db.AddInParameter(dbCommand, "Total_Comp", DbType.Decimal, this._Total_Comp);

            db.AddInParameter(dbCommand, "Total_Reserve", DbType.Decimal, this._Total_Reserve);

            db.AddInParameter(dbCommand, "Unlimited_Cost", DbType.Decimal, this._Unlimited_Cost);

            db.AddInParameter(dbCommand, "Limited_to_MV", DbType.Decimal, this._Limited_to_MV);

            db.AddInParameter(dbCommand, "HC_Percent", DbType.Decimal, this._HC_Percent);

            db.AddInParameter(dbCommand, "HC_Relief", DbType.Decimal, this._HC_Relief);

            db.AddInParameter(dbCommand, "Subrogation_Collected", DbType.Decimal, this._Subrogation_Collected);

            db.AddInParameter(dbCommand, "Claim_Activity", DbType.String, this._Claim_Activity);

            db.AddInParameter(dbCommand, "Total_Charged", DbType.Decimal, this._Total_Charged);

            if (string.IsNullOrEmpty(this._Updated_By))
                db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);

            db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);

            // Execute the query and return the new identity value
            decimal returnValue = Convert.ToDecimal(db.ExecuteScalar(dbCommand));

            return returnValue;
        }

        /// <summary>
        /// Selects a single record from the Workers_Comp_Claims_OH table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        private static DataSet SelectByPK(decimal pK_Workers_Comp_Claims_OH_Id)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Workers_Comp_Claims_OHSelectByPK");

            db.AddInParameter(dbCommand, "PK_Workers_Comp_Claims_OH_Id", DbType.Decimal, pK_Workers_Comp_Claims_OH_Id);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the Workers_Comp_Claims_OH table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Workers_Comp_Claims_OHSelectAll");

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Updates a record in the Workers_Comp_Claims_OH table.
        /// </summary>
        public decimal Update()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Workers_Comp_Claims_OHUpdate");


            db.AddInParameter(dbCommand, "PK_Workers_Comp_Claims_OH_Id", DbType.Decimal, this._PK_Workers_Comp_Claims_OH_Id);

            db.AddInParameter(dbCommand, "FK_WC_RD_Id", DbType.Decimal, this._FK_WC_RD_Id);

            if (string.IsNullOrEmpty(this._Claim_Number))
                db.AddInParameter(dbCommand, "Claim_Number", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Claim_Number", DbType.String, this._Claim_Number);

            db.AddInParameter(dbCommand, "Date_Entered", DbType.DateTime, this._Date_Entered);

            db.AddInParameter(dbCommand, "Date_Closed", DbType.DateTime, this._Date_Closed);

            db.AddInParameter(dbCommand, "Date_Reopened", DbType.DateTime, this._Date_Reopened);

            db.AddInParameter(dbCommand, "Active_InActive", DbType.String, this._Active_InActive);

            db.AddInParameter(dbCommand, "Date_Of_Incident", DbType.DateTime, this._Date_Of_Incident);

            db.AddInParameter(dbCommand, "Type", DbType.String, this._Type);

            db.AddInParameter(dbCommand, "Total_Medical", DbType.Decimal, this._Total_Medical);

            db.AddInParameter(dbCommand, "Total_Comp", DbType.Decimal, this._Total_Comp);

            db.AddInParameter(dbCommand, "Total_Reserve", DbType.Decimal, this._Total_Reserve);

            db.AddInParameter(dbCommand, "Unlimited_Cost", DbType.Decimal, this._Unlimited_Cost);

            db.AddInParameter(dbCommand, "Limited_to_MV", DbType.Decimal, this._Limited_to_MV);

            db.AddInParameter(dbCommand, "HC_Percent", DbType.Decimal, this._HC_Percent);

            db.AddInParameter(dbCommand, "HC_Relief", DbType.Decimal, this._HC_Relief);

            db.AddInParameter(dbCommand, "Subrogation_Collected", DbType.Decimal, this._Subrogation_Collected);

            db.AddInParameter(dbCommand, "Claim_Activity", DbType.String, this._Claim_Activity);

            db.AddInParameter(dbCommand, "Total_Charged", DbType.Decimal, this._Total_Charged);

            if (string.IsNullOrEmpty(this._Updated_By))
                db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);

            db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);

            decimal returnValue = Convert.ToDecimal(db.ExecuteScalar(dbCommand));

            return returnValue;
        }

        /// <summary>
        /// Deletes a record from the Workers_Comp_Claims_OH table by a composite primary key.
        /// </summary>
        public static void DeleteByPK(decimal pK_Workers_Comp_Claims_OH_Id)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Workers_Comp_Claims_OHDeleteByPK");

            db.AddInParameter(dbCommand, "PK_Workers_Comp_Claims_OH_Id", DbType.Decimal, pK_Workers_Comp_Claims_OH_Id);

            db.ExecuteNonQuery(dbCommand);
        }

        public static DataSet SelectAssociatedFirstReport(string Regional, decimal? CurrentEmployee)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("GETAssociatedFirstReport");

            db.AddInParameter(dbCommand, "@Regional", DbType.String, Regional);
            db.AddInParameter(dbCommand, "@CurrentEmployee", DbType.Decimal, CurrentEmployee);

            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet SelectAssociatedFirstReportByPk(decimal PK_WC_FR_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("GETAssociatedFirstReportByPk");
            db.AddInParameter(dbCommand, "PK_WC_FR_ID", DbType.Decimal, PK_WC_FR_ID);
            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet SelectAssociatedFirstReportAuditView(decimal PK_Workers_Comp_Claims_OH_Id)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Workers_Comp_Claims_OHAuditView");
            db.AddInParameter(dbCommand, "PK_Workers_Comp_Claims_OH_Id", DbType.Decimal, PK_Workers_Comp_Claims_OH_Id);
            return db.ExecuteDataSet(dbCommand);
        }

        public static int SelectPKByWc_FR_ID(int Wc_FR_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("TPAClaimNumberSelectByFk");

            db.AddInParameter(dbCommand, "FK_WC_FR_ID", DbType.Int32, Wc_FR_ID);
            db.AddOutParameter(dbCommand, "PK_Workers_Comp_Claims_ID", DbType.Int32, 1);

            db.ExecuteNonQuery(dbCommand);
            return Convert.ToInt32(dbCommand.Parameters["@PK_Workers_Comp_Claims_ID"].Value);
        }

        public static DataSet GetWorkersCompClaimsBySearchCriteria(decimal LocationNumber, DateTime? Date_of_Accident, decimal First_Report_Number, decimal AssociateName, string Claim_Number, decimal PK_Employee_Id, string Active_Inactive, string strOrderBy, string strOrder, int intPageNo, int intPageSize)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("SearchWorkers_Comp_Claims_OH_Information");
            db.AddInParameter(dbCommand, "LocationNumber", DbType.Decimal, LocationNumber);
            db.AddInParameter(dbCommand, "Date_of_Accident", DbType.DateTime, Date_of_Accident);
            db.AddInParameter(dbCommand, "First_Report_Number", DbType.Decimal, First_Report_Number);
            db.AddInParameter(dbCommand, "AssociateNameID", DbType.Decimal, AssociateName);
            db.AddInParameter(dbCommand, "Claim_Number", DbType.String, Claim_Number);
            db.AddInParameter(dbCommand, "ClaimantNameID", DbType.Decimal, PK_Employee_Id);
            db.AddInParameter(dbCommand, "Active_Inactive", DbType.String,Active_Inactive);
            db.AddInParameter(dbCommand, "strOrderBy", DbType.String, strOrderBy);
            db.AddInParameter(dbCommand, "strOrder", DbType.String, strOrder);
            db.AddInParameter(dbCommand, "intPageNo", DbType.Int32, intPageNo);
            db.AddInParameter(dbCommand, "intPageSize", DbType.Int32, intPageSize);
            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet GetAssociateList()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("GetAssociateList");            
            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet GetClaimantNameList()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("GetClaimantNameList");
            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet GetClaimantNumberListFromWorkersCompClaimsOH()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("GetClaimantNumberListFromWorkersCompClaimsOH");
            return db.ExecuteDataSet(dbCommand);
        }

        public static void ImportOhioWCClaimRecord(string FilePath)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Import_Workers_Comp_Claims_Ohio");
            db.AddInParameter(dbCommand, "FilePath", DbType.String, FilePath);
            db.ExecuteNonQuery(dbCommand);
        }

    }
}
