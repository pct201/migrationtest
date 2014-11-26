using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
    /// <summary>
    /// Data access class for Tatva_rptInspectionLagTimeSchedule table.
    /// </summary>
    public sealed class Tatva_rptInspectionLagTimeSchedule : Tatva_ReportSchedule
    {

        #region Private variables used to hold the property values

        private decimal? _PK_ID;
        private decimal? _FK_Schedule;
        private string _Region;
        private string _DBA;
        private string _Inspector_Name;
        private DateTime? _Inspection_Date_From;
        private DateTime? _Inspection_Date_To;
        private string _InspectionArea;
        private string _LagDayOption;

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
        /// Gets or sets the DBA value.
        /// </summary>
        public string DBA
        {
            get { return _DBA; }
            set { _DBA = value; }
        }

        /// <summary>
        /// Gets or sets the Inspector_Name value.
        /// </summary>
        public string Inspector_Name
        {
            get { return _Inspector_Name; }
            set { _Inspector_Name = value; }
        }

        /// <summary>
        /// Gets or sets the Inspection_Date_From value.
        /// </summary>
        public DateTime? Inspection_Date_From
        {
            get { return _Inspection_Date_From; }
            set { _Inspection_Date_From = value; }
        }

        /// <summary>
        /// Gets or sets the Inspection_Date_To value.
        /// </summary>
        public DateTime? Inspection_Date_To
        {
            get { return _Inspection_Date_To; }
            set { _Inspection_Date_To = value; }
        }

        /// <summary>
        /// Gets or sets the InspectionArea value.
        /// </summary>
        public string InspectionArea
        {
            get { return _InspectionArea; }
            set { _InspectionArea = value; }
        }

        /// <summary>
        /// Gets or sets the LagDayOption value.
        /// </summary>
        public string LagDayOption
        {
            get { return _LagDayOption; }
            set { _LagDayOption = value; }
        }


        #endregion

        #region Default Constructors

        /// <summary>
        /// Initializes a new instance of the clsTatva_rptInspectionLagTimeSchedule class with default value.
        /// </summary>
        public Tatva_rptInspectionLagTimeSchedule()
        {


        }

        #endregion

        #region Primary Constructors

        /// <summary>
        /// Initializes a new instance of the clsTatva_rptInspectionLagTimeSchedule class based on Primary Key.
        /// </summary>
        public Tatva_rptInspectionLagTimeSchedule(decimal pK_ID)
        {
            DataTable dtTatva_rptInspectionLagTimeSchedule = SelectByPK(pK_ID).Tables[0];

            if (dtTatva_rptInspectionLagTimeSchedule.Rows.Count == 1)
            {
                SetValue(dtTatva_rptInspectionLagTimeSchedule.Rows[0]);

            }

        }


        /// <summary>
        /// Initializes a new instance of the clsTatva_rptInspectionLagTimeSchedule class based on Datarow passed.
        /// </summary>
        private void SetValue(DataRow drTatva_rptInspectionLagTimeSchedule)
        {
            if (drTatva_rptInspectionLagTimeSchedule["PK_ID"] == DBNull.Value)
                this._PK_ID = null;
            else
                this._PK_ID = (decimal?)drTatva_rptInspectionLagTimeSchedule["PK_ID"];

            if (drTatva_rptInspectionLagTimeSchedule["FK_Schedule"] == DBNull.Value)
                this._FK_Schedule = null;
            else
                this._FK_Schedule = (decimal?)drTatva_rptInspectionLagTimeSchedule["FK_Schedule"];

            if (drTatva_rptInspectionLagTimeSchedule["Region"] == DBNull.Value)
                this._Region = null;
            else
                this._Region = (string)drTatva_rptInspectionLagTimeSchedule["Region"];

            if (drTatva_rptInspectionLagTimeSchedule["DBA"] == DBNull.Value)
                this._DBA = null;
            else
                this._DBA = (string)drTatva_rptInspectionLagTimeSchedule["DBA"];

            if (drTatva_rptInspectionLagTimeSchedule["Inspector_Name"] == DBNull.Value)
                this._Inspector_Name = null;
            else
                this._Inspector_Name = (string)drTatva_rptInspectionLagTimeSchedule["Inspector_Name"];

            if (drTatva_rptInspectionLagTimeSchedule["Inspection_Date_From"] == DBNull.Value)
                this._Inspection_Date_From = null;
            else
                this._Inspection_Date_From = (DateTime?)drTatva_rptInspectionLagTimeSchedule["Inspection_Date_From"];

            if (drTatva_rptInspectionLagTimeSchedule["Inspection_Date_To"] == DBNull.Value)
                this._Inspection_Date_To = null;
            else
                this._Inspection_Date_To = (DateTime?)drTatva_rptInspectionLagTimeSchedule["Inspection_Date_To"];

            if (drTatva_rptInspectionLagTimeSchedule["InspectionArea"] == DBNull.Value)
                this._InspectionArea = null;
            else
                this._InspectionArea = (string)drTatva_rptInspectionLagTimeSchedule["InspectionArea"];

            if (drTatva_rptInspectionLagTimeSchedule["LagDayOption"] == DBNull.Value)
                this._LagDayOption = null;
            else
                this._LagDayOption = (string)drTatva_rptInspectionLagTimeSchedule["LagDayOption"];


        }

        #endregion

        /// <summary>
        /// Inserts a record into the Tatva_rptInspectionLagTimeSchedule table.
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Tatva_rptInspectionLagTimeScheduleInsert");

            this._FK_Schedule = base.Insert();
            db.AddInParameter(dbCommand, "FK_Schedule", DbType.Decimal, this._FK_Schedule);

            if (string.IsNullOrEmpty(this._Region))
                db.AddInParameter(dbCommand, "Region", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Region", DbType.String, this._Region);

            if (string.IsNullOrEmpty(this._DBA))
                db.AddInParameter(dbCommand, "DBA", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "DBA", DbType.String, this._DBA);

            if (string.IsNullOrEmpty(this._Inspector_Name))
                db.AddInParameter(dbCommand, "Inspector_Name", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Inspector_Name", DbType.String, this._Inspector_Name);

            db.AddInParameter(dbCommand, "Inspection_Date_From", DbType.DateTime, this._Inspection_Date_From);

            db.AddInParameter(dbCommand, "Inspection_Date_To", DbType.DateTime, this._Inspection_Date_To);

            if (string.IsNullOrEmpty(this._InspectionArea))
                db.AddInParameter(dbCommand, "InspectionArea", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "InspectionArea", DbType.String, this._InspectionArea);

            if (string.IsNullOrEmpty(this._LagDayOption))
                db.AddInParameter(dbCommand, "LagDayOption", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "LagDayOption", DbType.String, this._LagDayOption);

            // Execute the query and return the new identity value
            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
        }

        /// <summary>
        /// Selects a single record from the Tatva_rptInspectionLagTimeSchedule table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        private DataSet SelectByPK(decimal pK_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Tatva_rptInspectionLagTimeScheduleSelectByPK");

            db.AddInParameter(dbCommand, "PK_ID", DbType.Decimal, pK_ID);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the Tatva_rptInspectionLagTimeSchedule table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Tatva_rptInspectionLagTimeScheduleSelectAll");

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Updates a record in the Tatva_rptInspectionLagTimeSchedule table.
        /// </summary>
        public void Update()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Tatva_rptInspectionLagTimeScheduleUpdate");


            db.AddInParameter(dbCommand, "PK_ID", DbType.Decimal, this._PK_ID);

            db.AddInParameter(dbCommand, "FK_Schedule", DbType.Decimal, this._FK_Schedule);

            if (string.IsNullOrEmpty(this._Region))
                db.AddInParameter(dbCommand, "Region", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Region", DbType.String, this._Region);

            if (string.IsNullOrEmpty(this._DBA))
                db.AddInParameter(dbCommand, "DBA", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "DBA", DbType.String, this._DBA);

            if (string.IsNullOrEmpty(this._Inspector_Name))
                db.AddInParameter(dbCommand, "Inspector_Name", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Inspector_Name", DbType.String, this._Inspector_Name);

            db.AddInParameter(dbCommand, "Inspection_Date_From", DbType.DateTime, this._Inspection_Date_From);

            db.AddInParameter(dbCommand, "Inspection_Date_To", DbType.DateTime, this._Inspection_Date_To);

            if (string.IsNullOrEmpty(this._InspectionArea))
                db.AddInParameter(dbCommand, "InspectionArea", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "InspectionArea", DbType.String, this._InspectionArea);

            if (string.IsNullOrEmpty(this._LagDayOption))
                db.AddInParameter(dbCommand, "LagDayOption", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "LagDayOption", DbType.String, this._LagDayOption);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Deletes a record from the Tatva_rptInspectionLagTimeSchedule table by a composite primary key.
        /// </summary>
        public static void DeleteByPK(decimal pK_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Tatva_rptInspectionLagTimeScheduleDeleteByPK");

            db.AddInParameter(dbCommand, "PK_ID", DbType.Decimal, pK_ID);

            db.ExecuteNonQuery(dbCommand);
        }
    }
}
