using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
    /// <summary>
    /// Data access class for Tatva_RptWCMonthlyAllocationSummaryReport table.
    /// </summary>
    public sealed class Tatva_RptWCMonthlyAllocationSummaryReport : Tatva_ReportSchedule
    {

        #region Private variables used to hold the property values

        private decimal? _PK_ID;
        private decimal? _FK_Schedule;
        private int? _Year;
        private string _Run_report_by;

        #endregion

        #region Public Property

        /// <summary>
        /// Gets or sets the PK_ID value.
        /// </summary>
        public decimal? PK_ID
        {
            get { return _PK_ID; }
            set { _PK_ID = value; }
        }

        /// <summary>
        /// Gets or sets the FK_Schedule value.
        /// </summary>
        public decimal? FK_Schedule
        {
            get { return _FK_Schedule; }
            set { _FK_Schedule = value; }
        }

        /// <summary>
        /// Gets or sets the Year value.
        /// </summary>
        public int? Year
        {
            get { return _Year; }
            set { _Year = value; }
        }

        /// <summary>
        /// Gets or sets the Run_report_by value.
        /// </summary>
        public string Run_report_by
        {
            get { return _Run_report_by; }
            set { _Run_report_by = value; }
        }


        #endregion

        #region Default Constructors

        /// <summary>
        /// Initializes a new instance of the Tatva_RptWCMonthlyAllocationSummaryReport class with default value.
        /// </summary>
        public Tatva_RptWCMonthlyAllocationSummaryReport()
        {

            this._PK_ID = null;
            this._FK_Schedule = null;
            this._Year = null;
            this._Run_report_by = null;

        }

        #endregion

        #region Primary Constructors

        /// <summary>
        /// Initializes a new instance of the Tatva_RptWCMonthlyAllocationSummaryReport class based on Primary Key.
        /// </summary>
        public Tatva_RptWCMonthlyAllocationSummaryReport(decimal pK_ID)
        {
            DataTable dtTatva_RptWCMonthlyAllocationSummaryReport = SelectByPK(pK_ID).Tables[0];

            if (dtTatva_RptWCMonthlyAllocationSummaryReport.Rows.Count == 1)
            {
                DataRow drTatva_RptWCMonthlyAllocationSummaryReport = dtTatva_RptWCMonthlyAllocationSummaryReport.Rows[0];
                if (drTatva_RptWCMonthlyAllocationSummaryReport["PK_ID"] == DBNull.Value)
                    this._PK_ID = null;
                else
                    this._PK_ID = (decimal?)drTatva_RptWCMonthlyAllocationSummaryReport["PK_ID"];

                if (drTatva_RptWCMonthlyAllocationSummaryReport["FK_Schedule"] == DBNull.Value)
                    this._FK_Schedule = null;
                else
                    this._FK_Schedule = (decimal?)drTatva_RptWCMonthlyAllocationSummaryReport["FK_Schedule"];

                if (drTatva_RptWCMonthlyAllocationSummaryReport["Year"] == DBNull.Value)
                    this._Year = null;
                else
                    this._Year = (int?)drTatva_RptWCMonthlyAllocationSummaryReport["Year"];

                if (drTatva_RptWCMonthlyAllocationSummaryReport["Run_report_by"] == DBNull.Value)
                    this._Run_report_by = null;
                else
                    this._Run_report_by = (string)drTatva_RptWCMonthlyAllocationSummaryReport["Run_report_by"];

            }
            else
            {
                this._PK_ID = null;
                this._FK_Schedule = null;
                this._Year = null;
                this._Run_report_by = null;
            }

        }

        #endregion

        /// <summary>
        /// Inserts a record into the Tatva_RptWCMonthlyAllocationSummaryReport table.
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            this._FK_Schedule = base.Insert();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Tatva_RptWCMonthlyAllocationSummaryReportInsert");

            db.AddInParameter(dbCommand, "FK_Schedule", DbType.Decimal, this._FK_Schedule);
            db.AddInParameter(dbCommand, "Year", DbType.Int32, this._Year);
            db.AddInParameter(dbCommand, "Run_report_by", DbType.String, this._Run_report_by);

            // Execute the query and return the new identity value
            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
        }

        /// <summary>
        /// Selects a single record from the Tatva_RptWCMonthlyAllocationSummaryReport table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        private static DataSet SelectByPK(decimal pK_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Tatva_RptWCMonthlyAllocationSummaryReportSelectByPK");

            db.AddInParameter(dbCommand, "PK_ID", DbType.Decimal, pK_ID);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the Tatva_RptWCMonthlyAllocationSummaryReport table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Tatva_RptWCMonthlyAllocationSummaryReportSelectAll");

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Updates a record in the Tatva_RptWCMonthlyAllocationSummaryReport table.
        /// </summary>
        public void Update()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Tatva_RptWCMonthlyAllocationSummaryReportUpdate");


            db.AddInParameter(dbCommand, "PK_ID", DbType.Decimal, this._PK_ID);

            db.AddInParameter(dbCommand, "FK_Schedule", DbType.Decimal, this._FK_Schedule);

            db.AddInParameter(dbCommand, "Year", DbType.Int32, this._Year);

            db.AddInParameter(dbCommand, "Run_report_by", DbType.String, this._Run_report_by);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Deletes a record from the Tatva_RptWCMonthlyAllocationSummaryReport table by a composite primary key.
        /// </summary>
        public static void DeleteByPK(decimal pK_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Tatva_RptWCMonthlyAllocationSummaryReportDeleteByPK");

            db.AddInParameter(dbCommand, "PK_ID", DbType.Decimal, pK_ID);

            db.ExecuteNonQuery(dbCommand);
        }
    }
}
