using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
    /// <summary>
    /// Data access class for WC_Allocation_Charges table.
    /// </summary>
    public sealed class WC_Allocation_Charges
    {

        #region Private variables used to hold the property values

        private decimal? _PK_WC_Allocation_Charges;
        private decimal? _FK_WC_FR_ID;
        private string _Charge_Type;
        private DateTime? _ChargeDate;
        private decimal? _Charge;
        private string _Change_Explanation;
        private string _Change_login;
        private bool _Changed;

        #endregion

        #region Public Property

        /// <summary>
        /// Gets or sets the PK_WC_Allocation_Charges value.
        /// </summary>
        public decimal? PK_WC_Allocation_Charges
        {
            get { return _PK_WC_Allocation_Charges; }
            set { _PK_WC_Allocation_Charges = value; }
        }

        /// <summary>
        /// Gets or sets the FK_WC_FR_ID value.
        /// </summary>
        public decimal? FK_WC_FR_ID
        {
            get { return _FK_WC_FR_ID; }
            set { _FK_WC_FR_ID = value; }
        }

        /// <summary>
        /// Gets or sets the Charge_Type value.
        /// </summary>
        public string Charge_Type
        {
            get { return _Charge_Type; }
            set { _Charge_Type = value; }
        }

        /// <summary>
        /// Gets or sets the ChargeDate value.
        /// </summary>
        public DateTime? ChargeDate
        {
            get { return _ChargeDate; }
            set { _ChargeDate = value; }
        }

        /// <summary>
        /// Gets or sets the Charge value.
        /// </summary>
        public decimal? Charge
        {
            get { return _Charge; }
            set { _Charge = value; }
        }

        /// <summary>
        /// Gets or sets the Change_Explanation value.
        /// </summary>
        public string Change_Explanation
        {
            get { return _Change_Explanation; }
            set { _Change_Explanation = value; }
        }

        /// <summary>
        /// Gets or sets the Change_login value.
        /// </summary>
        public string Change_login
        {
            get { return _Change_login; }
            set { _Change_login = value; }
        }

        /// <summary>
        /// Gets or sets the Changed value.
        /// </summary>
        public bool Changed
        {
            get { return _Changed; }
            set { _Changed = value; }
        }


        #endregion

        #region Default Constructors

        /// <summary>
        /// Initializes a new instance of the WC_Allocation_Charges class with default value.
        /// </summary>
        public WC_Allocation_Charges()
        {

            this._PK_WC_Allocation_Charges = null;
            this._FK_WC_FR_ID = null;
            this._Charge_Type = null;
            this._ChargeDate = null;
            this._Charge = null;
            this._Change_Explanation = null;
            this._Change_login = null;
            this._Changed = false;

        }

        #endregion

        #region Primary Constructors

        /// <summary>
        /// Initializes a new instance of the WC_Allocation_Charges class based on Primary Key.
        /// </summary>
        public WC_Allocation_Charges(decimal pK_WC_Allocation_Charges)
        {
            DataTable dtWC_Allocation_Charges = SelectByPK(pK_WC_Allocation_Charges).Tables[0];

            if (dtWC_Allocation_Charges.Rows.Count == 1)
            {
                DataRow drWC_Allocation_Charges = dtWC_Allocation_Charges.Rows[0];
                if (drWC_Allocation_Charges["PK_WC_Allocation_Charges"] == DBNull.Value)
                    this._PK_WC_Allocation_Charges = null;
                else
                    this._PK_WC_Allocation_Charges = (decimal?)drWC_Allocation_Charges["PK_WC_Allocation_Charges"];

                if (drWC_Allocation_Charges["FK_WC_FR_ID"] == DBNull.Value)
                    this._FK_WC_FR_ID = null;
                else
                    this._FK_WC_FR_ID = (decimal?)drWC_Allocation_Charges["FK_WC_FR_ID"];

                if (drWC_Allocation_Charges["Charge_Type"] == DBNull.Value)
                    this._Charge_Type = null;
                else
                    this._Charge_Type = (string)drWC_Allocation_Charges["Charge_Type"];

                if (drWC_Allocation_Charges["ChargeDate"] == DBNull.Value)
                    this._ChargeDate = null;
                else
                    this._ChargeDate = (DateTime?)drWC_Allocation_Charges["ChargeDate"];

                if (drWC_Allocation_Charges["Charge"] == DBNull.Value)
                    this._Charge = null;
                else
                    this._Charge = (decimal?)drWC_Allocation_Charges["Charge"];

                if (drWC_Allocation_Charges["Change_Explanation"] == DBNull.Value)
                    this._Change_Explanation = null;
                else
                    this._Change_Explanation = (string)drWC_Allocation_Charges["Change_Explanation"];

                if (drWC_Allocation_Charges["Change_login"] == DBNull.Value)
                    this._Change_login = null;
                else
                    this._Change_login = (string)drWC_Allocation_Charges["Change_login"];

                if (drWC_Allocation_Charges["Changed"] == DBNull.Value)
                    this._Changed = false;
                else
                    this._Changed = (bool)drWC_Allocation_Charges["Changed"];

            }
            else
            {
                this._PK_WC_Allocation_Charges = null;
                this._FK_WC_FR_ID = null;
                this._Charge_Type = null;
                this._ChargeDate = null;
                this._Charge = null;
                this._Change_Explanation = null;
                this._Change_login = null;
                this._Changed = false;
            }

        }

        #endregion

        #region "Methods"
        /// <summary>
        /// Inserts a record into the WC_Allocation_Charges table.
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("WC_Allocation_ChargesInsert");

            db.AddInParameter(dbCommand, "FK_WC_FR_ID", DbType.Decimal, this._FK_WC_FR_ID);

            if (string.IsNullOrEmpty(this._Charge_Type))
                db.AddInParameter(dbCommand, "Charge_Type", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Charge_Type", DbType.String, this._Charge_Type);

            db.AddInParameter(dbCommand, "ChargeDate", DbType.DateTime, this._ChargeDate);

            db.AddInParameter(dbCommand, "Charge", DbType.Currency, this._Charge);

            if (string.IsNullOrEmpty(this._Change_Explanation))
                db.AddInParameter(dbCommand, "Change_Explanation", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Change_Explanation", DbType.String, this._Change_Explanation);

            if (string.IsNullOrEmpty(this._Change_login))
                db.AddInParameter(dbCommand, "Change_login", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Change_login", DbType.String, this._Change_login);

            db.AddInParameter(dbCommand, "Changed", DbType.Boolean, this._Changed);

            // Execute the query and return the new identity value
            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
        }

        /// <summary>
        /// Selects a single record from the WC_Allocation_Charges table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        private static DataSet SelectByPK(decimal pK_WC_Allocation_Charges)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("WC_Allocation_ChargesSelectByPK");

            db.AddInParameter(dbCommand, "PK_WC_Allocation_Charges", DbType.Decimal, pK_WC_Allocation_Charges);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the WC_Allocation_Charges table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("WC_Allocation_ChargesSelectAll");

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Updates a record in the WC_Allocation_Charges table.
        /// </summary>
        public void Update()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("WC_Allocation_ChargesUpdate");


            db.AddInParameter(dbCommand, "PK_WC_Allocation_Charges", DbType.Decimal, this._PK_WC_Allocation_Charges);
            db.AddInParameter(dbCommand, "FK_WC_FR_ID", DbType.Decimal, this._FK_WC_FR_ID);

            if (string.IsNullOrEmpty(this._Charge_Type))
                db.AddInParameter(dbCommand, "Charge_Type", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Charge_Type", DbType.String, this._Charge_Type);

            db.AddInParameter(dbCommand, "ChargeDate", DbType.DateTime, this._ChargeDate);

            db.AddInParameter(dbCommand, "Charge", DbType.Currency, this._Charge);

            if (string.IsNullOrEmpty(this._Change_Explanation))
                db.AddInParameter(dbCommand, "Change_Explanation", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Change_Explanation", DbType.String, this._Change_Explanation);

            if (string.IsNullOrEmpty(this._Change_login))
                db.AddInParameter(dbCommand, "Change_login", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Change_login", DbType.String, this._Change_login);

            db.AddInParameter(dbCommand, "Changed", DbType.Boolean, this._Changed);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Deletes a record from the WC_Allocation_Charges table by a composite primary key.
        /// </summary>
        public static void DeleteByPK(decimal pK_WC_Allocation_Charges)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("WC_Allocation_ChargesDeleteByPK");

            db.AddInParameter(dbCommand, "PK_WC_Allocation_Charges", DbType.Decimal, pK_WC_Allocation_Charges);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Insert Record with promoted Cuase Code 
        /// </summary>
        /// <param name="PK_WC_FR_ID"></param>
        /// <param name="Change_login"></param>
        public static void Promote_CauseCode(decimal PK_WC_FR_ID, string Change_login)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Promote_CauseCode");

            db.AddInParameter(dbCommand, "Change_login", DbType.Decimal, Change_login);
            db.AddInParameter(dbCommand, "PK_WC_FR_ID", DbType.Decimal, PK_WC_FR_ID);

            db.ExecuteNonQuery(dbCommand);

        }

        /// <summary>
        /// Search Wc_allocation using First Report Number
        /// </summary>
        /// <param name="First_Report_Number"></param>
        public static DataSet SearchByFR_Number(decimal FK_WC_FR_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("SearchWC_allocation_charges");

            db.AddInParameter(dbCommand, "FK_WC_FR_ID", DbType.Decimal, FK_WC_FR_ID);

            return db.ExecuteDataSet(dbCommand);

        }

        /// <summary>
        /// Insert record into Wc_Allocation_charges table from Claim
        /// </summary>
        /// <param name="month"></param>
        /// <param name="year"></param>
        public static void WC_Allocation_Charges_InsertProcess(int month, int year)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("WC_Allocation_Charges_InsertProcess");
            db.AddInParameter(dbCommand, "month", DbType.Int32, month);
            db.AddInParameter(dbCommand, "year", DbType.Int32, year);
            db.AddInParameter(dbCommand, "Change_login", DbType.String, clsSession.UserID);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Insert record into Wc_Allocation_charges table from Claim
        /// </summary>
        /// <param name="month"></param>
        /// <param name="year"></param>
        public static bool CheckMonthly_Allocation_Submission(int month, int year)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("CheckMonthly_Allocation_Submission");

            db.AddInParameter(dbCommand, "month", DbType.Int32, month);
            db.AddInParameter(dbCommand, "year", DbType.Int32, year);

            return Convert.ToBoolean(db.ExecuteScalar(dbCommand));
        }

        /// <summary>
        ///  get record for WC Allocation Monthly Detail Report
        /// </summary>
        /// <param name="month"></param>
        /// <param name="year"></param>
        /// <returns></returns>
        public static DataSet WCAllocationMonthlyDetailReport(int month, int year)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("WCAllocationMonthlyDetailReport");

            db.AddInParameter(dbCommand, "month", DbType.Int32, month);
            db.AddInParameter(dbCommand, "year", DbType.Int32, year);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        ///  get record for WC Allocation Monthly Detail Report By Market
        /// </summary>
        /// <param name="month"></param>
        /// <param name="year"></param>
        /// <returns></returns>
        public static DataSet WCAllocationMonthlyDetailReport_ByMarket(int month, int year)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("WCAllocationMonthlyDetailReport_ByMarket");

            db.AddInParameter(dbCommand, "month", DbType.Int32, month);
            db.AddInParameter(dbCommand, "year", DbType.Int32, year);

            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet WC_Monthly_Allocation_Summary_Report(decimal year)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("WCMonthlyAllocationSummaryReport");
            
            db.AddInParameter(dbCommand, "year", DbType.Int32, year);

            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet WC_Monthly_Allocation_Summary_Report_ByMarket(decimal year)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("WCMonthlyAllocationSummaryReport_ByMarket");

            db.AddInParameter(dbCommand, "year", DbType.Int32, year);

            return db.ExecuteDataSet(dbCommand);
        }
        #endregion



    }
}
