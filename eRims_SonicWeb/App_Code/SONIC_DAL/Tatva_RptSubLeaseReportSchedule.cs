using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
  
/// <summary>
/// Summary description for Tatva_RptSubLeaseReportSchedule
/// </summary>
public class Tatva_RptSubLeaseReportSchedule : Tatva_ReportSchedule
{
	 #region Private variables used to hold the property values

        private decimal? _PK_ID;
        private decimal? _FK_Schedule;
        private string _Location;
        private string _LeaseType;
        private DateTime? _LCDFrom_Date;
        private DateTime? _LCDTo_Date;
        private DateTime? _LEDFrom_Date;
        private DateTime? _LEDTo_Date;
        private string _Building_Status;

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
        public string Location
        {
            get { return _Location; }
            set { _Location = value; }
        }

        /// <summary>
        /// Gets or sets the LeaseType value.
        /// </summary>
        public string LeaseType
        {
            get { return _LeaseType; }
            set { _LeaseType = value; }
        }

        /// <summary>
        /// Gets or sets the LCDFrom_Date value.
        /// </summary>
        public DateTime? LCDFrom_Date
        {
            get { return _LCDFrom_Date; }
            set { _LCDFrom_Date = value; }
        }

        /// <summary>
        /// Gets or sets the LCDTo_Date value.
        /// </summary>
        public DateTime? LCDTo_Date
        {
            get { return _LCDTo_Date; }
            set { _LCDTo_Date = value; }
        }

        /// <summary>
        /// Gets or sets the LEDFrom_Date value.
        /// </summary>
        public DateTime? LEDFrom_Date
        {
            get { return _LEDFrom_Date; }
            set { _LEDFrom_Date = value; }
        }

        /// <summary>
        /// Gets or sets the LEDTo_Date value.
        /// </summary>
        public DateTime? LEDTo_Date
        {
            get { return _LEDTo_Date; }
            set { _LEDTo_Date = value; }
        }

        public string Building_Status
        {
            get { return _Building_Status; }
            set { _Building_Status = value; }
        }
        #endregion

        #region Default Constructors

        /// <summary>
        /// Initializes a new instance of the Tatva_RptRealEstateSchedule class with default value.
        /// </summary>
        public Tatva_RptSubLeaseReportSchedule()
        {

            this._PK_ID = null;
            this._FK_Schedule = null;
            this._Location = null;
            this._LeaseType = null;
            this._LCDFrom_Date = null;
            this._LCDTo_Date = null;
            this._LEDFrom_Date = null;
            this._LEDTo_Date = null;
            this._Building_Status = null;
        }

        #endregion

        #region Primary Constructors

        /// <summary>
        /// Initializes a new instance of the Tatva_RptRealEstateSchedule class based on Primary Key.
        /// </summary>
        public Tatva_RptSubLeaseReportSchedule(decimal pK_ID)
        {
            DataTable dtTatva_RptRealEstateSchedule = SelectByPK(pK_ID).Tables[0];

            if (dtTatva_RptRealEstateSchedule.Rows.Count == 1)
            {
                DataRow drTatva_RptRealEstateSchedule = dtTatva_RptRealEstateSchedule.Rows[0];
                if (drTatva_RptRealEstateSchedule["PK_ID"] == DBNull.Value)
                    this._PK_ID = null;
                else
                    this._PK_ID = (decimal?)drTatva_RptRealEstateSchedule["PK_ID"];

                if (drTatva_RptRealEstateSchedule["FK_Schedule"] == DBNull.Value)
                    this._FK_Schedule = null;
                else
                    this._FK_Schedule = (decimal?)drTatva_RptRealEstateSchedule["FK_Schedule"];

                if (drTatva_RptRealEstateSchedule["Location"] == DBNull.Value)
                    this._Location = null;
                else
                    this._Location = (string)drTatva_RptRealEstateSchedule["Region"];

                if (drTatva_RptRealEstateSchedule["LeaseType"] == DBNull.Value)
                    this._LeaseType = null;
                else
                    this._LeaseType = (string)drTatva_RptRealEstateSchedule["LeaseType"];

                if (drTatva_RptRealEstateSchedule["LCDFrom_Date"] == DBNull.Value)
                    this._LCDFrom_Date = null;
                else
                    this._LCDFrom_Date = (DateTime?)drTatva_RptRealEstateSchedule["LCDFrom_Date"];

                if (drTatva_RptRealEstateSchedule["LCDTo_Date"] == DBNull.Value)
                    this._LCDTo_Date = null;
                else
                    this._LCDTo_Date = (DateTime?)drTatva_RptRealEstateSchedule["LCDTo_Date"];

                if (drTatva_RptRealEstateSchedule["LEDFrom_Date"] == DBNull.Value)
                    this._LEDFrom_Date = null;
                else
                    this._LEDFrom_Date = (DateTime?)drTatva_RptRealEstateSchedule["LEDFrom_Date"];

                if (drTatva_RptRealEstateSchedule["LEDTo_Date"] == DBNull.Value)
                    this._LEDTo_Date = null;
                else
                    this._LEDTo_Date = (DateTime?)drTatva_RptRealEstateSchedule["LEDTo_Date"];

            }
            else
            {
                this._PK_ID = null;
                this._FK_Schedule = null;
                this._Location = null;
                this._LeaseType = null;
                this._LCDFrom_Date = null;
                this._LCDTo_Date = null;
                this._LEDFrom_Date = null;
                this._LEDTo_Date = null;
            }

        }

        #endregion

        /// <summary>
        /// Inserts a record into the Tatva_RptRealEstateSchedule table.
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            this._FK_Schedule = base.Insert();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Tatva_RptSubLeaseReportScheduleInsert");

            db.AddInParameter(dbCommand, "FK_Schedule", DbType.Decimal, this._FK_Schedule);

            if (string.IsNullOrEmpty(this._Location))
                db.AddInParameter(dbCommand, "Location", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Location", DbType.String, this._Location);

            if (string.IsNullOrEmpty(this._LeaseType))
                db.AddInParameter(dbCommand, "LeaseType", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "LeaseType", DbType.String, this._LeaseType);

            db.AddInParameter(dbCommand, "LCDFrom_Date", DbType.DateTime, this._LCDFrom_Date);

            db.AddInParameter(dbCommand, "LCDTo_Date", DbType.DateTime, this._LCDTo_Date);

            db.AddInParameter(dbCommand, "LEDFrom_Date", DbType.DateTime, this._LEDFrom_Date);

            db.AddInParameter(dbCommand, "LEDTo_Date", DbType.DateTime, this._LEDTo_Date);
            db.AddInParameter(dbCommand, "Status", DbType.String, this._Building_Status);
            // Execute the query and return the new identity value
            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
        }

        /// <summary>
        /// Selects a single record from the Tatva_RptRealEstateSchedule table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        private static DataSet SelectByPK(decimal pK_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Tatva_RptSubLeaseReportScheduleSelectByPK");

            db.AddInParameter(dbCommand, "PK_ID", DbType.Decimal, pK_ID);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the Tatva_RptRealEstateSchedule table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Tatva_RptSubLeaseReportScheduleSelectAll");

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Updates a record in the Tatva_RptRealEstateSchedule table.
        /// </summary>
        public void Update()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Tatva_RptSubLeaseReportScheduleUpdate");


            db.AddInParameter(dbCommand, "PK_ID", DbType.Decimal, this._PK_ID);

            db.AddInParameter(dbCommand, "FK_Schedule", DbType.Decimal, this._FK_Schedule);

            if (string.IsNullOrEmpty(this._Location))
                db.AddInParameter(dbCommand, "Location", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Location", DbType.String, this._Location);

            if (string.IsNullOrEmpty(this._LeaseType))
                db.AddInParameter(dbCommand, "LeaseType", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "LeaseType", DbType.String, this._LeaseType);

            db.AddInParameter(dbCommand, "LCDFrom_Date", DbType.DateTime, this._LCDFrom_Date);

            db.AddInParameter(dbCommand, "LCDTo_Date", DbType.DateTime, this._LCDTo_Date);

            db.AddInParameter(dbCommand, "LEDFrom_Date", DbType.DateTime, this._LEDFrom_Date);

            db.AddInParameter(dbCommand, "LEDTo_Date", DbType.DateTime, this._LEDTo_Date);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Deletes a record from the Tatva_RptRealEstateSchedule table by a composite primary key.
        /// </summary>
        public static void DeleteByPK(decimal pK_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Tatva_RptSubLeaseReportScheduleDeleteByPK");

            db.AddInParameter(dbCommand, "PK_ID", DbType.Decimal, pK_ID);

            db.ExecuteNonQuery(dbCommand);
        }
    }


}