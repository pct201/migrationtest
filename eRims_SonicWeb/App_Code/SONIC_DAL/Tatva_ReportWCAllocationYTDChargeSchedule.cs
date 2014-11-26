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
        private string _Location;
        private string _Year;

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

            }
            else
            {
                this._PK_ID = null;
                this._FK_Schedule = null;
                this._Region = null;
                this._Location = null;
                this._Year = null;
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

            if (string.IsNullOrEmpty(this._Location))
                db.AddInParameter(dbCommand, "Location", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Location", DbType.String, this._Location);

            if (string.IsNullOrEmpty(this._Year))
                db.AddInParameter(dbCommand, "Year", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Year", DbType.String, this._Year);

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

            if (string.IsNullOrEmpty(this._Location))
                db.AddInParameter(dbCommand, "Location", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Location", DbType.String, this._Location);

            if (string.IsNullOrEmpty(this._Year))
                db.AddInParameter(dbCommand, "Year", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Year", DbType.String, this._Year);

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
