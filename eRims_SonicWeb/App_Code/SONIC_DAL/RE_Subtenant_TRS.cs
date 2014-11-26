using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
    /// <summary>
    /// Data access class for RE_Subtenant_TRS table.
    /// </summary>
    public sealed class RE_Subtenant_TRS
    {

        #region Private variables used to hold the property values

        private decimal? _PK_RE_Subtenant_TRS;
        private decimal? _FK_RE_Subtenant;
        private decimal? _Year;
        private DateTime? _From_Date;
        private DateTime? _To_Date;
        private decimal? _Months;
        private decimal? _Monthly_Rent;
        private decimal? _Additions;
        private decimal? _Percentage_Rate;
        private string _Updated_By;
        private DateTime? _Update_Date;

        #endregion

        #region Public Property

        /// <summary>
        /// Gets or sets the PK_RE_Subtenant_TRS value.
        /// </summary>
        public decimal? PK_RE_Subtenant_TRS
        {
            get { return _PK_RE_Subtenant_TRS; }
            set { _PK_RE_Subtenant_TRS = value; }
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
        /// Gets or sets the Year value.
        /// </summary>
        public decimal? Year
        {
            get { return _Year; }
            set { _Year = value; }
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
        /// Gets or sets the Additions value.
        /// </summary>
        public decimal? Additions
        {
            get { return _Additions; }
            set { _Additions = value; }
        }

        /// <summary>
        /// Gets or sets the Percentage_Rate value.
        /// </summary>
        public decimal? Percentage_Rate
        {
            get { return _Percentage_Rate; }
            set { _Percentage_Rate = value; }
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
        /// Initializes a new instance of the RE_Subtenant_TRS class with default value.
        /// </summary>
        public RE_Subtenant_TRS()
        {

            this._PK_RE_Subtenant_TRS = null;
            this._FK_RE_Subtenant = null;
            this._Year = null;
            this._From_Date = null;
            this._To_Date = null;
            this._Months = null;
            this._Monthly_Rent = null;
            this._Additions = null;
            this._Percentage_Rate = null;
            this._Updated_By = null;
            this._Update_Date = null;

        }

        #endregion

        #region Primary Constructors

        /// <summary>
        /// Initializes a new instance of the RE_Subtenant_TRS class based on Primary Key.
        /// </summary>
        public RE_Subtenant_TRS(decimal pK_RE_Subtenant_TRS)
        {
            DataTable dtRE_Subtenant_TRS = SelectByPK(pK_RE_Subtenant_TRS).Tables[0];

            if (dtRE_Subtenant_TRS.Rows.Count == 1)
            {
                DataRow drRE_Subtenant_TRS = dtRE_Subtenant_TRS.Rows[0];
                if (drRE_Subtenant_TRS["PK_RE_Subtenant_TRS"] == DBNull.Value)
                    this._PK_RE_Subtenant_TRS = null;
                else
                    this._PK_RE_Subtenant_TRS = (decimal?)drRE_Subtenant_TRS["PK_RE_Subtenant_TRS"];

                if (drRE_Subtenant_TRS["FK_RE_Subtenant"] == DBNull.Value)
                    this._FK_RE_Subtenant = null;
                else
                    this._FK_RE_Subtenant = (decimal?)drRE_Subtenant_TRS["FK_RE_Subtenant"];

                if (drRE_Subtenant_TRS["Year"] == DBNull.Value)
                    this._Year = null;
                else
                    this._Year = (decimal?)drRE_Subtenant_TRS["Year"];

                if (drRE_Subtenant_TRS["From_Date"] == DBNull.Value)
                    this._From_Date = null;
                else
                    this._From_Date = (DateTime?)drRE_Subtenant_TRS["From_Date"];

                if (drRE_Subtenant_TRS["To_Date"] == DBNull.Value)
                    this._To_Date = null;
                else
                    this._To_Date = (DateTime?)drRE_Subtenant_TRS["To_Date"];

                if (drRE_Subtenant_TRS["Months"] == DBNull.Value)
                    this._Months = null;
                else
                    this._Months = (decimal?)drRE_Subtenant_TRS["Months"];

                if (drRE_Subtenant_TRS["Monthly_Rent"] == DBNull.Value)
                    this._Monthly_Rent = null;
                else
                    this._Monthly_Rent = (decimal?)drRE_Subtenant_TRS["Monthly_Rent"];

                if (drRE_Subtenant_TRS["Additions"] == DBNull.Value)
                    this._Additions = null;
                else
                    this._Additions = (decimal?)drRE_Subtenant_TRS["Additions"];

                if (drRE_Subtenant_TRS["Percentage_Rate"] == DBNull.Value)
                    this._Percentage_Rate = null;
                else
                    this._Percentage_Rate = (decimal?)drRE_Subtenant_TRS["Percentage_Rate"];

                if (drRE_Subtenant_TRS["Updated_By"] == DBNull.Value)
                    this._Updated_By = null;
                else
                    this._Updated_By = (string)drRE_Subtenant_TRS["Updated_By"];

                if (drRE_Subtenant_TRS["Update_Date"] == DBNull.Value)
                    this._Update_Date = null;
                else
                    this._Update_Date = (DateTime?)drRE_Subtenant_TRS["Update_Date"];

            }
            else
            {
                this._PK_RE_Subtenant_TRS = null;
                this._FK_RE_Subtenant = null;
                this._Year = null;
                this._From_Date = null;
                this._To_Date = null;
                this._Months = null;
                this._Monthly_Rent = null;
                this._Additions = null;
                this._Percentage_Rate = null;
                this._Updated_By = null;
                this._Update_Date = null;
            }

        }

        #endregion

        /// <summary>
        /// Inserts a record into the RE_Subtenant_TRS table.
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("RE_Subtenant_TRSInsert");


            db.AddInParameter(dbCommand, "FK_RE_Subtenant", DbType.Decimal, this._FK_RE_Subtenant);

            db.AddInParameter(dbCommand, "Year", DbType.Decimal, this._Year);

            db.AddInParameter(dbCommand, "From_Date", DbType.DateTime, this._From_Date);

            db.AddInParameter(dbCommand, "To_Date", DbType.DateTime, this._To_Date);

            db.AddInParameter(dbCommand, "Months", DbType.Decimal, this._Months);

            db.AddInParameter(dbCommand, "Monthly_Rent", DbType.Decimal, this._Monthly_Rent);

            db.AddInParameter(dbCommand, "Additions", DbType.Decimal, this._Additions);

            db.AddInParameter(dbCommand, "Percentage_Rate", DbType.Decimal, this._Percentage_Rate);

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
        /// Selects a single record from the RE_Subtenant_TRS table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        private static DataSet SelectByPK(decimal pK_RE_Subtenant_TRS)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("RE_Subtenant_TRSSelectByPK");

            db.AddInParameter(dbCommand, "PK_RE_Subtenant_TRS", DbType.Decimal, pK_RE_Subtenant_TRS);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Select Max Year and Monthlyrent details
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectYearByPK(decimal FK_RE_Subtenant)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("RE_Subtenant_TRS_SelectYearByPK");

            db.AddInParameter(dbCommand, "FK_RE_Subtenant", DbType.Decimal, FK_RE_Subtenant);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the RE_Subtenant_TRS table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("RE_Subtenant_TRSSelectAll");

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Updates a record in the RE_Subtenant_TRS table.
        /// </summary>
        public void Update()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("RE_Subtenant_TRSUpdate");


            db.AddInParameter(dbCommand, "PK_RE_Subtenant_TRS", DbType.Decimal, this._PK_RE_Subtenant_TRS);

            db.AddInParameter(dbCommand, "FK_RE_Subtenant", DbType.Decimal, this._FK_RE_Subtenant);

            db.AddInParameter(dbCommand, "Year", DbType.Decimal, this._Year);

            db.AddInParameter(dbCommand, "From_Date", DbType.DateTime, this._From_Date);

            db.AddInParameter(dbCommand, "To_Date", DbType.DateTime, this._To_Date);

            db.AddInParameter(dbCommand, "Months", DbType.Decimal, this._Months);

            db.AddInParameter(dbCommand, "Monthly_Rent", DbType.Decimal, this._Monthly_Rent);

            db.AddInParameter(dbCommand, "Additions", DbType.Decimal, this._Additions);

            db.AddInParameter(dbCommand, "Percentage_Rate", DbType.Decimal, this._Percentage_Rate);

            if (string.IsNullOrEmpty(this._Updated_By))
                db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);

            db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Deletes a record from the RE_Subtenant_TRS table by a composite primary key.
        /// </summary>
        public static void DeleteByPK(decimal pK_RE_Subtenant_TRS)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("RE_Subtenant_TRSDeleteByPK");

            db.AddInParameter(dbCommand, "PK_RE_Subtenant_TRS", DbType.Decimal, pK_RE_Subtenant_TRS);

            db.ExecuteNonQuery(dbCommand);
        }


        public static DataSet SelectByFK(decimal fK_RE_SubTenant)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("RE_Subtenant_TRSSelectByFK");

            db.AddInParameter(dbCommand, "FK_RE_Subtenant", DbType.Decimal, fK_RE_SubTenant);

            return db.ExecuteDataSet(dbCommand);
        }

        public static void UpdateRents(decimal pK_RE_Subtenant_TRS, decimal monthly_Rent, decimal additions, decimal percentage_rate)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("RE_Subtenant_TRS_UpdateRents");

            db.AddInParameter(dbCommand, "PK_RE_Subtenant_TRS", DbType.Decimal, pK_RE_Subtenant_TRS);
            db.AddInParameter(dbCommand, "Monthly_Rent", DbType.Decimal, monthly_Rent);
            db.AddInParameter(dbCommand, "Additions", DbType.Decimal, additions);
            db.AddInParameter(dbCommand, "Percentage_Rate", DbType.Decimal, percentage_rate);
            db.ExecuteNonQuery(dbCommand);
        }
    }
}
