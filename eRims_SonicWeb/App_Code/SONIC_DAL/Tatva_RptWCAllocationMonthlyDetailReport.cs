using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
    /// <summary>
    /// Data access class for Tatva_RptWCAllocationMonthlyDetailReport table.
    /// </summary>
    public sealed class Tatva_RptWCAllocationMonthlyDetailReport : Tatva_ReportSchedule
    {

        #region Private variables used to hold the property values

        private decimal? _PK_ID;
        private decimal? _FK_Schedule;
        private int? _Year;
        private int? _Month;
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
        /// Gets or sets the Month value.
        /// </summary>
        public int? Month
        {
            get { return _Month; }
            set { _Month = value; }
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
        /// Initializes a new instance of the Tatva_RptWCAllocationMonthlyDetailReport class with default value.
        /// </summary>
        public Tatva_RptWCAllocationMonthlyDetailReport()
        {

            this._PK_ID = null;
            this._FK_Schedule = null;
            this._Year = null;
            this._Month = null;
            this._Run_report_by = null;

        }

        #endregion

        #region Primary Constructors

        /// <summary>
        /// Initializes a new instance of the Tatva_RptWCAllocationMonthlyDetailReport class based on Primary Key.
        /// </summary>
        public Tatva_RptWCAllocationMonthlyDetailReport(decimal pK_ID)
        {
            DataTable dtTatva_RptWCAllocationMonthlyDetailReport = SelectByPK(pK_ID).Tables[0];

            if (dtTatva_RptWCAllocationMonthlyDetailReport.Rows.Count == 1)
            {
                DataRow drTatva_RptWCAllocationMonthlyDetailReport = dtTatva_RptWCAllocationMonthlyDetailReport.Rows[0];
                if (drTatva_RptWCAllocationMonthlyDetailReport["PK_ID"] == DBNull.Value)
                    this._PK_ID = null;
                else
                    this._PK_ID = (decimal?)drTatva_RptWCAllocationMonthlyDetailReport["PK_ID"];

                if (drTatva_RptWCAllocationMonthlyDetailReport["FK_Schedule"] == DBNull.Value)
                    this._FK_Schedule = null;
                else
                    this._FK_Schedule = (decimal?)drTatva_RptWCAllocationMonthlyDetailReport["FK_Schedule"];

                if (drTatva_RptWCAllocationMonthlyDetailReport["Year"] == DBNull.Value)
                    this._Year = null;
                else
                    this._Year = (int?)drTatva_RptWCAllocationMonthlyDetailReport["Year"];

                if (drTatva_RptWCAllocationMonthlyDetailReport["Month"] == DBNull.Value)
                    this._Month = null;
                else
                    this._Month = (int?)drTatva_RptWCAllocationMonthlyDetailReport["Month"];

                if (drTatva_RptWCAllocationMonthlyDetailReport["Run_report_by"] == DBNull.Value)
                    this._Run_report_by = null;
                else
                    this._Run_report_by = (string)drTatva_RptWCAllocationMonthlyDetailReport["Run_report_by"];


            }
            else
            {
                this._PK_ID = null;
                this._FK_Schedule = null;
                this._Year = null;
                this._Month = null;
                this._Run_report_by = null;
            }

        }

        #endregion

        /// <summary>
        /// Inserts a record into the Tatva_RptWCAllocationMonthlyDetailReport table.
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            this._FK_Schedule = base.Insert();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Tatva_RptWCAllocationMonthlyDetailReportInsert");


            db.AddInParameter(dbCommand, "FK_Schedule", DbType.Decimal, this._FK_Schedule);

            db.AddInParameter(dbCommand, "Year", DbType.Int32, this._Year);

            db.AddInParameter(dbCommand, "Month", DbType.Int32, this._Month);

            db.AddInParameter(dbCommand, "Run_report_by", DbType.String, this._Run_report_by);

            // Execute the query and return the new identity value
            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
        }

        /// <summary>
        /// Selects a single record from the Tatva_RptWCAllocationMonthlyDetailReport table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        private static DataSet SelectByPK(decimal pK_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Tatva_RptWCAllocationMonthlyDetailReportSelectByPK");

            db.AddInParameter(dbCommand, "PK_ID", DbType.Decimal, pK_ID);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the Tatva_RptWCAllocationMonthlyDetailReport table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Tatva_RptWCAllocationMonthlyDetailReportSelectAll");

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Updates a record in the Tatva_RptWCAllocationMonthlyDetailReport table.
        /// </summary>
        public void Update()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Tatva_RptWCAllocationMonthlyDetailReportUpdate");


            db.AddInParameter(dbCommand, "PK_ID", DbType.Decimal, this._PK_ID);

            db.AddInParameter(dbCommand, "FK_Schedule", DbType.Decimal, this._FK_Schedule);

            db.AddInParameter(dbCommand, "Year", DbType.Int32, this._Year);

            db.AddInParameter(dbCommand, "Month", DbType.Int32, this._Month);

            db.AddInParameter(dbCommand, "Run_report_by", DbType.String, this._Run_report_by);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Deletes a record from the Tatva_RptWCAllocationMonthlyDetailReport table by a composite primary key.
        /// </summary>
        public static void DeleteByPK(decimal pK_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Tatva_RptWCAllocationMonthlyDetailReportDeleteByPK");

            db.AddInParameter(dbCommand, "PK_ID", DbType.Decimal, pK_ID);

            db.ExecuteNonQuery(dbCommand);
        }
    }
}
