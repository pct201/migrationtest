using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{/// <summary>
    /// Summary description for Tatva_RptSafetyTrainingSchedule
    /// </summary>
    public sealed class Tatva_RptSafetyTrainingSchedule : Tatva_ReportSchedule
    {
        #region Private variables used to hold the property values

        private decimal? _PK_ID;
        private decimal? _FK_Schedule;
        private decimal? _Market;
        private string _Report_Interval;
        private int? _Year;
        private string _Region;

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
        /// Gets or sets the Report_Interval value.
        /// </summary>
        public string Report_Interval
        {
            get { return _Report_Interval; }
            set { _Report_Interval = value; }
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
        /// Gets or sets the Region value.
        /// </summary>
        public string Region
        {
            get { return _Region; }
            set { _Region = value; }
        }

        /// <summary>
        /// Gets or sets the Market value.
        /// </summary>
        public decimal? Market
        {
            get { return _Market; }
            set { _Market = value; }
        }
        #endregion

        #region Default Constructors

        /// <summary>
        /// Initializes a new instance of the Tatva_RptSafetyTrainingSchedule class with default value.
        /// </summary>
        public Tatva_RptSafetyTrainingSchedule()
        {

            this._PK_ID = null;
            this._FK_Schedule = null;
            this._Report_Interval = null;
            this._Year = null;
            this._Region = null;
            this._Market = null;

        }

        #endregion

        #region Primary Constructors

        /// <summary>
        /// Initializes a new instance of the Tatva_RptSafetyTrainingSchedule class based on Primary Key.
        /// </summary>
        public Tatva_RptSafetyTrainingSchedule(decimal pK_ID)
        {
            DataTable dtTatva_RptSafetyTrainingSchedule = SelectByPK(pK_ID).Tables[0];

            if (dtTatva_RptSafetyTrainingSchedule.Rows.Count == 1)
            {
                DataRow drTatva_RptSafetyTrainingSchedule = dtTatva_RptSafetyTrainingSchedule.Rows[0];
                if (drTatva_RptSafetyTrainingSchedule["PK_ID"] == DBNull.Value)
                    this._PK_ID = null;
                else
                    this._PK_ID = (decimal?)drTatva_RptSafetyTrainingSchedule["PK_ID"];

                if (drTatva_RptSafetyTrainingSchedule["FK_Schedule"] == DBNull.Value)
                    this._FK_Schedule = null;
                else
                    this._FK_Schedule = (decimal?)drTatva_RptSafetyTrainingSchedule["FK_Schedule"];

                if (drTatva_RptSafetyTrainingSchedule["Market"] == DBNull.Value)
                    this._Market = null;
                else
                    this._Market = (decimal?)drTatva_RptSafetyTrainingSchedule["Market"];

                if (drTatva_RptSafetyTrainingSchedule["Report_Interval"] == DBNull.Value)
                    this._Report_Interval = null;
                else
                    this._Report_Interval = (string)drTatva_RptSafetyTrainingSchedule["Report_Interval"];

                if (drTatva_RptSafetyTrainingSchedule["Year"] == DBNull.Value)
                    this._Year = null;
                else
                    this._Year = (int?)drTatva_RptSafetyTrainingSchedule["Year"];

                if (drTatva_RptSafetyTrainingSchedule["Region"] == DBNull.Value)
                    this._Region = null;
                else
                    this._Region = (string)drTatva_RptSafetyTrainingSchedule["Region"];

            }
            else
            {
                this._PK_ID = null;
                this._FK_Schedule = null;
                this._Report_Interval = null;
                this._Year = null;
                this._Region = null;
            }

        }

        #endregion

        /// <summary>
        /// Inserts a record into the Tatva_RptSafetyTrainingSchedule table.
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Tatva_RptSafetyTrainingScheduleInsert");

            this._FK_Schedule = base.Insert();

            db.AddInParameter(dbCommand, "FK_Schedule", DbType.Decimal, this._FK_Schedule);

            //if (string.IsNullOrEmpty(this._Report_Interval))
            //    db.AddInParameter(dbCommand, "Report_Interval", DbType.String, DBNull.Value);
            //else
            //    db.AddInParameter(dbCommand, "Report_Interval", DbType.String, this._Report_Interval);

            db.AddInParameter(dbCommand, "Year", DbType.Int32, this._Year);

            if (string.IsNullOrEmpty(this._Region))
                db.AddInParameter(dbCommand, "Region", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Region", DbType.String, this._Region);

            db.AddInParameter(dbCommand, "Market", DbType.Decimal, this._Market);

            // Execute the query and return the new identity value
            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
        }

        /// <summary>
        /// Selects a single record from the Tatva_RptSafetyTrainingSchedule table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        private static DataSet SelectByPK(decimal pK_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Tatva_RptSafetyTrainingScheduleSelectByPK");

            db.AddInParameter(dbCommand, "PK_ID", DbType.Decimal, pK_ID);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the Tatva_RptSafetyTrainingSchedule table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Tatva_RptSafetyTrainingScheduleSelectAll");

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Updates a record in the Tatva_RptSafetyTrainingSchedule table.
        /// </summary>
        public void Update()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Tatva_RptSafetyTrainingScheduleUpdate");


            db.AddInParameter(dbCommand, "PK_ID", DbType.Decimal, this._PK_ID);

            db.AddInParameter(dbCommand, "FK_Schedule", DbType.Decimal, this._FK_Schedule);

            if (string.IsNullOrEmpty(this._Report_Interval))
                db.AddInParameter(dbCommand, "Report_Interval", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Report_Interval", DbType.String, this._Report_Interval);

            db.AddInParameter(dbCommand, "Year", DbType.Int32, this._Year);

            if (string.IsNullOrEmpty(this._Region))
                db.AddInParameter(dbCommand, "Region", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Region", DbType.String, this._Region);

            db.AddInParameter(dbCommand, "Market", DbType.Decimal, this._Market);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Deletes a record from the Tatva_RptSafetyTrainingSchedule table by a composite primary key.
        /// </summary>
        public static void DeleteByPK(decimal pK_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Tatva_RptSafetyTrainingScheduleDeleteByPK");

            db.AddInParameter(dbCommand, "PK_ID", DbType.Decimal, pK_ID);

            db.ExecuteNonQuery(dbCommand);
        }
    }
}