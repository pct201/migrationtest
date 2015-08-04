using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
    /// <summary>
    /// Data access class for Tatva_ReportWCAllocationYTDChargeSchedule table.
    /// </summary>
    public sealed class Tatva_ReportWCAllocationYTDChargeSchedule : Tatva_ReportSchedule
    {

        #region Private variables used to hold the property values

        private decimal? _PK_ID;
        private decimal? _FK_Schedule;
        private string _Region;
        private string _Market;
        private string _Location;
        private string _Year;
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
        /// Gets or sets the Region value.
        /// </summary>
        public string Region
        {
            get { return _Region; }
            set { _Region = value; }
        }

       
        /// <summary>
        /// Gets or sets the Location value.
        /// </summary>
        public string Location
        {
            get { return _Location; }
            set { _Location = value; }
        }

        /// <summary>
        /// Gets or sets the Year value.
        /// </summary>
        public string Year
        {
            get { return _Year; }
            set { _Year = value; }
        }

        /// <summary>
        /// Gets or sets Market Value
        /// </summary>
        public string Market
        {
            get { return _Market; }
            set { _Market = value; }
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
        /// Initializes a new instance of the Tatva_ReportWCAllocationYTDChargeSchedule class with default value.
        /// </summary>
        public Tatva_ReportWCAllocationYTDChargeSchedule()
        {

            this._PK_ID = null;
            this._FK_Schedule = null;
            this._Region = null;
            this._Location = null;
            this._Year = null;
            this._Market = null;
            this._Run_report_by = null;

        }

        #endregion

        #region Primary Constructors

        /// <summary>
        /// Initializes a new instance of the Tatva_ReportWCAllocationYTDChargeSchedule class based on Primary Key.
        /// </summary>
        public Tatva_ReportWCAllocationYTDChargeSchedule(decimal pK_ID)
        {
            DataTable dtTatva_ReportWCAllocationYTDChargeSchedule = SelectByPK(pK_ID).Tables[0];

            if (dtTatva_ReportWCAllocationYTDChargeSchedule.Rows.Count == 1)
            {
                DataRow drTatva_ReportWCAllocationYTDChargeSchedule = dtTatva_ReportWCAllocationYTDChargeSchedule.Rows[0];
                if (drTatva_ReportWCAllocationYTDChargeSchedule["PK_ID"] == DBNull.Value)
                    this._PK_ID = null;
                else
                    this._PK_ID = (decimal?)drTatva_ReportWCAllocationYTDChargeSchedule["PK_ID"];

                if (drTatva_ReportWCAllocationYTDChargeSchedule["FK_Schedule"] == DBNull.Value)
                    this._FK_Schedule = null;
                else
                    this._FK_Schedule = (decimal?)drTatva_ReportWCAllocationYTDChargeSchedule["FK_Schedule"];

                if (drTatva_ReportWCAllocationYTDChargeSchedule["Region"] == DBNull.Value)
                    this._Region = null;
                else
                    this._Region = (string)drTatva_ReportWCAllocationYTDChargeSchedule["Region"];

                if (drTatva_ReportWCAllocationYTDChargeSchedule["Location"] == DBNull.Value)
                    this._Location = null;
                else
                    this._Location = (string)drTatva_ReportWCAllocationYTDChargeSchedule["Location"];

                if (drTatva_ReportWCAllocationYTDChargeSchedule["Year"] == DBNull.Value)
                    this._Year = null;
                else
                    this._Year = (string)drTatva_ReportWCAllocationYTDChargeSchedule["Year"];

                if (drTatva_ReportWCAllocationYTDChargeSchedule["Market"] == DBNull.Value)
                    this._Market = null;
                else
                    this._Market = (string)drTatva_ReportWCAllocationYTDChargeSchedule["Market"];

                if (drTatva_ReportWCAllocationYTDChargeSchedule["Run_report_by"] == DBNull.Value)
                    this._Run_report_by = null;
                else
                    this._Run_report_by = (string)drTatva_ReportWCAllocationYTDChargeSchedule["Run_report_by"];
            }
            else
            {
                this._PK_ID = null;
                this._FK_Schedule = null;
                this._Region = null;
                this._Location = null;
                this._Year = null;
                this._Market = null;
                this._Run_report_by = null;
            }

        }

        #endregion

        /// <summary>
        /// Inserts a record into the Tatva_ReportWCAllocationYTDChargeSchedule table.
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            this.FK_Schedule = base.Insert();

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Tatva_ReportWCAllocationYTDChargeScheduleInsert");


            db.AddInParameter(dbCommand, "FK_Schedule", DbType.Decimal, this._FK_Schedule);

            if (string.IsNullOrEmpty(this._Region))
                db.AddInParameter(dbCommand, "Region", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Region", DbType.String, this._Region);

            if (string.IsNullOrEmpty(this._Market))
                db.AddInParameter(dbCommand, "Market", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Market", DbType.String, this._Market);

            if (string.IsNullOrEmpty(this._Location))
                db.AddInParameter(dbCommand, "Location", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Location", DbType.String, this._Location);

            if (string.IsNullOrEmpty(this._Year))
                db.AddInParameter(dbCommand, "Year", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Year", DbType.String, this._Year);

            if (string.IsNullOrEmpty(this._Run_report_by))
                db.AddInParameter(dbCommand, "Run_report_by", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Run_report_by", DbType.String, this._Run_report_by);

            // Execute the query and return the new identity value
            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
        }

        /// <summary>
        /// Selects a single record from the Tatva_ReportWCAllocationYTDChargeSchedule table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        private static DataSet SelectByPK(decimal pK_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Tatva_ReportWCAllocationYTDChargeScheduleSelectByPK");

            db.AddInParameter(dbCommand, "PK_ID", DbType.Decimal, pK_ID);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the Tatva_ReportWCAllocationYTDChargeSchedule table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Tatva_ReportWCAllocationYTDChargeScheduleSelectAll");

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Updates a record in the Tatva_ReportWCAllocationYTDChargeSchedule table.
        /// </summary>
        public void Update()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Tatva_ReportWCAllocationYTDChargeScheduleUpdate");


            db.AddInParameter(dbCommand, "PK_ID", DbType.Decimal, this._PK_ID);

            db.AddInParameter(dbCommand, "FK_Schedule", DbType.Decimal, this._FK_Schedule);

            if (string.IsNullOrEmpty(this._Region))
                db.AddInParameter(dbCommand, "Region", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Region", DbType.String, this._Region);

            if (string.IsNullOrEmpty(this._Market))
                db.AddInParameter(dbCommand, "Market", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Market", DbType.String, this._Market);

            if (string.IsNullOrEmpty(this._Location))
                db.AddInParameter(dbCommand, "Location", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Location", DbType.String, this._Location);

            if (string.IsNullOrEmpty(this._Year))
                db.AddInParameter(dbCommand, "Year", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Year", DbType.String, this._Year);

            if (string.IsNullOrEmpty(this._Run_report_by))
                db.AddInParameter(dbCommand, "Run_report_by", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Run_report_by", DbType.String, this._Run_report_by);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Deletes a record from the Tatva_ReportWCAllocationYTDChargeSchedule table by a composite primary key.
        /// </summary>
        public static void DeleteByPK(decimal pK_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Tatva_ReportWCAllocationYTDChargeScheduleDeleteByPK");

            db.AddInParameter(dbCommand, "PK_ID", DbType.Decimal, pK_ID);

            db.ExecuteNonQuery(dbCommand);
        }
    }
}
