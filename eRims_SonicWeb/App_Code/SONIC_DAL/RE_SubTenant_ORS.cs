using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
    /// <summary>
    /// Data access class for RE_SubTenant_ORS table.
    /// </summary>
    public sealed class RE_SubTenant_ORS
    {

        #region Private variables used to hold the property values

        private decimal? _PK_RE_SubTenant_ORS;
        private decimal? _FK_RE_Subtenant;
        private decimal? _Option_Period;
        private DateTime? _From_Date;
        private DateTime? _To_Date;
        private decimal? _Months;
        private decimal? _Monthly_Rent;
        private string _Updated_By;
        private DateTime? _Update_Date;

        #endregion

        #region Public Property

        /// <summary>
        /// Gets or sets the PK_RE_SubTenant_ORS value.
        /// </summary>
        public decimal? PK_RE_SubTenant_ORS
        {
            get { return _PK_RE_SubTenant_ORS; }
            set { _PK_RE_SubTenant_ORS = value; }
        }

        /// <summary>
        /// Gets or sets the FK_RE_Subtenant value.
        /// </summary>
        public decimal? FK_RE_Subtenant
        {
            get { return _FK_RE_Subtenant; }
            set { _FK_RE_Subtenant = value; }
        }

        /// <summary>
        /// Gets or sets the Option_Period value.
        /// </summary>
        public decimal? Option_Period
        {
            get { return _Option_Period; }
            set { _Option_Period = value; }
        }

        /// <summary>
        /// Gets or sets the From_Date value.
        /// </summary>
        public DateTime? From_Date
        {
            get { return _From_Date; }
            set { _From_Date = value; }
        }

        /// <summary>
        /// Gets or sets the To_Date value.
        /// </summary>
        public DateTime? To_Date
        {
            get { return _To_Date; }
            set { _To_Date = value; }
        }

        /// <summary>
        /// Gets or sets the Months value.
        /// </summary>
        public decimal? Months
        {
            get { return _Months; }
            set { _Months = value; }
        }

        /// <summary>
        /// Gets or sets the Monthly_Rent value.
        /// </summary>
        public decimal? Monthly_Rent
        {
            get { return _Monthly_Rent; }
            set { _Monthly_Rent = value; }
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


        #endregion

        #region Default Constructors

        /// <summary>
        /// Initializes a new instance of the RE_SubTenant_ORS class with default value.
        /// </summary>
        public RE_SubTenant_ORS()
        {

            this._PK_RE_SubTenant_ORS = null;
            this._FK_RE_Subtenant = null;
            this._Option_Period = null;
            this._From_Date = null;
            this._To_Date = null;
            this._Months = null;
            this._Monthly_Rent = null;
            this._Updated_By = null;
            this._Update_Date = null;

        }

        #endregion

        #region Primary Constructors

        /// <summary>
        /// Initializes a new instance of the RE_SubTenant_ORS class based on Primary Key.
        /// </summary>
        public RE_SubTenant_ORS(decimal pK_RE_SubTenant_ORS)
        {
            DataTable dtRE_SubTenant_ORS = SelectByPK(pK_RE_SubTenant_ORS).Tables[0];

            if (dtRE_SubTenant_ORS.Rows.Count == 1)
            {
                DataRow drRE_SubTenant_ORS = dtRE_SubTenant_ORS.Rows[0];
                if (drRE_SubTenant_ORS["PK_RE_SubTenant_ORS"] == DBNull.Value)
                    this._PK_RE_SubTenant_ORS = null;
                else
                    this._PK_RE_SubTenant_ORS = (decimal?)drRE_SubTenant_ORS["PK_RE_SubTenant_ORS"];

                if (drRE_SubTenant_ORS["FK_RE_Subtenant"] == DBNull.Value)
                    this._FK_RE_Subtenant = null;
                else
                    this._FK_RE_Subtenant = (decimal?)drRE_SubTenant_ORS["FK_RE_Subtenant"];

                if (drRE_SubTenant_ORS["Option_Period"] == DBNull.Value)
                    this._Option_Period = null;
                else
                    this._Option_Period = (decimal?)drRE_SubTenant_ORS["Option_Period"];

                if (drRE_SubTenant_ORS["From_Date"] == DBNull.Value)
                    this._From_Date = null;
                else
                    this._From_Date = (DateTime?)drRE_SubTenant_ORS["From_Date"];

                if (drRE_SubTenant_ORS["To_Date"] == DBNull.Value)
                    this._To_Date = null;
                else
                    this._To_Date = (DateTime?)drRE_SubTenant_ORS["To_Date"];

                if (drRE_SubTenant_ORS["Months"] == DBNull.Value)
                    this._Months = null;
                else
                    this._Months = (decimal?)drRE_SubTenant_ORS["Months"];

                if (drRE_SubTenant_ORS["Monthly_Rent"] == DBNull.Value)
                    this._Monthly_Rent = null;
                else
                    this._Monthly_Rent = (decimal?)drRE_SubTenant_ORS["Monthly_Rent"];

                if (drRE_SubTenant_ORS["Updated_By"] == DBNull.Value)
                    this._Updated_By = null;
                else
                    this._Updated_By = (string)drRE_SubTenant_ORS["Updated_By"];

                if (drRE_SubTenant_ORS["Update_Date"] == DBNull.Value)
                    this._Update_Date = null;
                else
                    this._Update_Date = (DateTime?)drRE_SubTenant_ORS["Update_Date"];

            }
            else
            {
                this._PK_RE_SubTenant_ORS = null;
                this._FK_RE_Subtenant = null;
                this._Option_Period = null;
                this._From_Date = null;
                this._To_Date = null;
                this._Months = null;
                this._Monthly_Rent = null;
                this._Updated_By = null;
                this._Update_Date = null;
            }

        }

        #endregion

        /// <summary>
        /// Inserts a record into the RE_SubTenant_ORS table.
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("RE_SubTenant_ORSInsert");


            db.AddInParameter(dbCommand, "FK_RE_Subtenant", DbType.Decimal, this._FK_RE_Subtenant);

            db.AddInParameter(dbCommand, "Option_Period", DbType.Decimal, this._Option_Period);

            db.AddInParameter(dbCommand, "From_Date", DbType.DateTime, this._From_Date);

            db.AddInParameter(dbCommand, "To_Date", DbType.DateTime, this._To_Date);

            db.AddInParameter(dbCommand, "Months", DbType.Decimal, this._Months);

            db.AddInParameter(dbCommand, "Monthly_Rent", DbType.Decimal, this._Monthly_Rent);

            if (string.IsNullOrEmpty(this._Updated_By))
                db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);

            db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);

            // Execute the query and return the new identity value
            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
        }

        /// <summary>
        /// Selects a single record from the RE_SubTenant_ORS table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        private static DataSet SelectByPK(decimal pK_RE_SubTenant_ORS)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("RE_SubTenant_ORSSelectByPK");

            db.AddInParameter(dbCommand, "PK_RE_SubTenant_ORS", DbType.Decimal, pK_RE_SubTenant_ORS);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the RE_SubTenant_ORS table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("RE_SubTenant_ORSSelectAll");

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Updates a record in the RE_SubTenant_ORS table.
        /// </summary>
        public void Update()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("RE_SubTenant_ORSUpdate");


            db.AddInParameter(dbCommand, "PK_RE_SubTenant_ORS", DbType.Decimal, this._PK_RE_SubTenant_ORS);

            db.AddInParameter(dbCommand, "FK_RE_Subtenant", DbType.Decimal, this._FK_RE_Subtenant);

            db.AddInParameter(dbCommand, "Option_Period", DbType.Decimal, this._Option_Period);

            db.AddInParameter(dbCommand, "From_Date", DbType.DateTime, this._From_Date);

            db.AddInParameter(dbCommand, "To_Date", DbType.DateTime, this._To_Date);

            db.AddInParameter(dbCommand, "Months", DbType.Decimal, this._Months);

            db.AddInParameter(dbCommand, "Monthly_Rent", DbType.Decimal, this._Monthly_Rent);

            if (string.IsNullOrEmpty(this._Updated_By))
                db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);

            db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Deletes a record from the RE_SubTenant_ORS table by a composite primary key.
        /// </summary>
        public static void DeleteByPK(decimal pK_RE_SubTenant_ORS)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("RE_SubTenant_ORSDeleteByPK");

            db.AddInParameter(dbCommand, "PK_RE_SubTenant_ORS", DbType.Decimal, pK_RE_SubTenant_ORS);

            db.ExecuteNonQuery(dbCommand);
        }
        
        public static DataSet SelectByFK(decimal fK_RE_SubTenant)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("RE_Subtenant_ORSSelectByFK");

            db.AddInParameter(dbCommand, "FK_RE_Subtenant", DbType.Decimal, fK_RE_SubTenant);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Select Max Year and Monthlyrent details
        /// </summary>
        /// <returns>DataSet</returns>
        public static int SelectOptionPeriodByPK(decimal FK_RE_Subtenant)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("RE_Subtenant_ORS_OptionPeriodByPK");

            db.AddInParameter(dbCommand, "FK_RE_Subtenant", DbType.Decimal, FK_RE_Subtenant);

            return Convert.ToInt32(db.ExecuteScalar(dbCommand));
        }

        public static void UpdateRents(decimal pK_RE_Subtenant_ORS, decimal monthly_Rent)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("RE_Subtenant_ORS_UpdateRents");

            db.AddInParameter(dbCommand, "PK_RE_Subtenant_ORS", DbType.Decimal, pK_RE_Subtenant_ORS);
            db.AddInParameter(dbCommand, "Monthly_Rent", DbType.Decimal, monthly_Rent);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Select  Monthlyrent details
        /// </summary>
        /// <returns>DataSet</returns>
        public static Decimal  SelectMonthlyRent(decimal FK_RE_Subtenant, int intStartYear, int intEndYear)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("RE_SubtenantORS_MonthlyRent");

            db.AddInParameter(dbCommand, "FK_RE_Subtenant", DbType.Decimal, FK_RE_Subtenant);
            db.AddInParameter(dbCommand, "StartYear", DbType.Decimal, intStartYear);
            db.AddInParameter(dbCommand, "EndYear", DbType.Decimal, intEndYear);

            return Convert.ToDecimal(db.ExecuteScalar(dbCommand));
        }
    }
}
