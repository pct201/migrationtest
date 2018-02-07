using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
    /// <summary>
    /// Data access class for Tatva_ReportSchedule table.
    /// </summary>
    public class Tatva_ReportSchedule
    {
        #region Fields
        public decimal _PK_Schedule;
        public DateTime _Scheduled_Date;
        private DateTime _Schedule_End_Date;
        public decimal _FK_Report;
        public decimal _Fk_RecipientList;
        private decimal _FK_Security_ID;
        private decimal _Recurring_Type;
        private DateTime _Created_Date;
        private int _Format_Type;
        private string _ReportSchedulerName;
        #endregion

        #region Properties
        /// <summary>  /// Gets or sets the PK_Schedule value. /// </summary> 
        public decimal PK_Schedule { get { return _PK_Schedule; } set { _PK_Schedule = value; } }
        /// <summary>  /// Gets or sets the Scheduled_Date value. /// </summary> 
        public DateTime Scheduled_Date { get { return _Scheduled_Date; } set { _Scheduled_Date = value; } }
        /// <summary>  /// Gets or sets the Schedule_End_Date value. /// </summary> 
        public DateTime Schedule_End_Date { get { return _Schedule_End_Date; } set { _Schedule_End_Date = value; } }
        /// <summary>  /// Gets or sets the FK_Report value. /// </summary> 
        public decimal FK_Report { get { return _FK_Report; } set { _FK_Report = value; } }
        /// <summary>  /// Gets or sets the Fk_RecipientList value. /// </summary> 
        public decimal Fk_RecipientList { get { return _Fk_RecipientList; } set { _Fk_RecipientList = value; } }
        /// <summary>  /// Gets or sets the FK_Security_ID value. /// </summary> 
        public decimal FK_Security_ID { get { return _FK_Security_ID; } set { _FK_Security_ID = value; } }
        /// <summary>  /// Gets or sets the FK_Security_ID value. /// </summary> 
        public decimal Recurring_Type { get { return _Recurring_Type; } set { _Recurring_Type = value; } }
        /// <summary>  /// Gets or sets the Scheduled_Date value. /// </summary> 
        public DateTime Created_Date { get { return _Created_Date; } set { _Created_Date = value; } }

        /// <summary>  /// Gets or sets the Format_Type value. /// </summary> 
        public int Format_Type { get { return _Format_Type; } set { _Format_Type = value; } }

        /// <summary>
        /// Gets or sets the FirstGroupBySorting value.
        /// </summary>
        public string ReportSchedulerName
        {
            get { return _ReportSchedulerName; }
            set { _ReportSchedulerName = value; }
        }
        #endregion

        #region Constructors
        public Tatva_ReportSchedule()
        {
            this._PK_Schedule = -1;
            this._Scheduled_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            this._Schedule_End_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            this._FK_Report = -1;
            this._Fk_RecipientList = -1;
            this._Recurring_Type = -1;
            this._Created_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            this._Format_Type = 1;
            this._ReportSchedulerName = null;
        }

        /// </summary> 
        public Tatva_ReportSchedule(decimal PK)
        {
            DataTable dtTatva_ReportSchedule = SelectByPK(PK).Tables[0];
            if (dtTatva_ReportSchedule.Rows.Count > 0)
            {
                DataRow drTatva_ReportSchedule = dtTatva_ReportSchedule.Rows[0];
                this._PK_Schedule = drTatva_ReportSchedule["PK_Schedule"] != DBNull.Value ? Convert.ToDecimal(drTatva_ReportSchedule["PK_Schedule"]) : 0;
                this._Scheduled_Date = drTatva_ReportSchedule["Scheduled_Date"] != DBNull.Value ? Convert.ToDateTime(drTatva_ReportSchedule["Scheduled_Date"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Schedule_End_Date = drTatva_ReportSchedule["Schedule_End_Date"] != DBNull.Value ? Convert.ToDateTime(drTatva_ReportSchedule["Schedule_End_Date"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._FK_Report = drTatva_ReportSchedule["FK_Report"] != DBNull.Value ? Convert.ToDecimal(drTatva_ReportSchedule["FK_Report"]) : 0;
                this._Fk_RecipientList = drTatva_ReportSchedule["Fk_RecipientList"] != DBNull.Value ? Convert.ToDecimal(drTatva_ReportSchedule["Fk_RecipientList"]) : 0;
                this._Recurring_Type = drTatva_ReportSchedule["Recurring_Type"] != DBNull.Value ? Convert.ToDecimal(drTatva_ReportSchedule["Recurring_Type"]) : 0;
                this._Created_Date = drTatva_ReportSchedule["Created_Date"] != DBNull.Value ? Convert.ToDateTime(drTatva_ReportSchedule["Created_Date"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Format_Type = drTatva_ReportSchedule["Format_Type"] != DBNull.Value ? Convert.ToInt32(drTatva_ReportSchedule["Format_Type"]) : 1;
                this._ReportSchedulerName = (string)drTatva_ReportSchedule["ReportSchedulerName"];
            }
            else
            {
                this._PK_Schedule = -1;
                this._Scheduled_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Schedule_End_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._FK_Report = -1;
                this._Fk_RecipientList = -1;
                this._Recurring_Type = -1;
                this._Created_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Format_Type = 1;
                this._ReportSchedulerName = null;
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Inserts a record into the Tatva_ReportSchedule table.
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Tatva_ReportScheduleInsert");


            db.AddInParameter(dbCommand, "Scheduled_Date", DbType.DateTime, this._Scheduled_Date);
            db.AddInParameter(dbCommand, "Schedule_End_Date", DbType.DateTime, this._Schedule_End_Date);
            db.AddInParameter(dbCommand, "FK_Report", DbType.Decimal, this._FK_Report);
            db.AddInParameter(dbCommand, "Fk_RecipientList", DbType.Decimal, this._Fk_RecipientList);
            db.AddInParameter(dbCommand, "FK_Security_ID", DbType.Decimal, this._FK_Security_ID);
            db.AddInParameter(dbCommand, "Recurring_Type", DbType.Decimal, this._Recurring_Type);
            db.AddInParameter(dbCommand, "Created_Date", DbType.DateTime, this._Created_Date);
            db.AddInParameter(dbCommand, "Format_Type", DbType.Int32, this._Format_Type);
            if (string.IsNullOrEmpty(this._ReportSchedulerName))
                db.AddInParameter(dbCommand, "ReportSchedulerName", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "ReportSchedulerName", DbType.String, this._ReportSchedulerName);
            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;

        }

        /// <summary>
        /// Selects a single record from the Tatva_ReportSchedule table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAllDetails(int intPageNo, string strOrderBy, string strOrder, int intPageSize)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Tatva_ReportScheduleSelectAllDetails");


            db.AddInParameter(dbCommand, "intPageNo", DbType.Decimal, intPageNo);
            db.AddInParameter(dbCommand, "strOrderBy", DbType.String, strOrderBy);
            db.AddInParameter(dbCommand, "strOrder", DbType.String, strOrder);
            db.AddInParameter(dbCommand, "intPageSize", DbType.Decimal, intPageSize);
            db.AddInParameter(dbCommand, "Report_Source", DbType.String, "Sonic");

            return db.ExecuteDataSet(dbCommand);
        }


        /// <summary>
        /// Selects a single record from the Tatva_ReportSchedule table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectByPK(decimal pK_Schedule)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Tatva_ReportScheduleSelectByPK");

            db.AddInParameter(dbCommand, "PK_Schedule", DbType.Decimal, pK_Schedule);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects records from the Tatva_ReportSchedule table by a foreign key.
        /// </summary>
        /// <param name="fk_RecipientList"></param>
        /// <returns>DataSet</returns>
        public static DataSet SelectByFk_RecipientList(decimal fk_RecipientList)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Tatva_ReportScheduleSelectByFk_RecipientList");

            db.AddInParameter(dbCommand, "Fk_RecipientList", DbType.Decimal, fk_RecipientList);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects records from the Tatva_ReportSchedule table by a foreign key.
        /// </summary>
        /// <param name="fK_Report"></param>
        /// <returns>DataSet</returns>
        public static DataSet SelectByFK_Report(decimal fK_Report)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Tatva_ReportScheduleSelectByFK_Report");

            db.AddInParameter(dbCommand, "FK_Report", DbType.Decimal, fK_Report);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the Tatva_ReportSchedule table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Tatva_ReportScheduleSelectAll");

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Updates a record in the Tatva_ReportSchedule table.
        /// </summary>
        public void Update()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Tatva_ReportScheduleUpdate");

            db.AddInParameter(dbCommand, "PK_Schedule", DbType.Decimal, this._PK_Schedule);
            db.AddInParameter(dbCommand, "Scheduled_Date", DbType.DateTime, this._Scheduled_Date);
            db.AddInParameter(dbCommand, "Schedule_End_Date", DbType.DateTime, this._Schedule_End_Date);
            db.AddInParameter(dbCommand, "FK_Report", DbType.Decimal, this._FK_Report);
            db.AddInParameter(dbCommand, "Fk_RecipientList", DbType.Decimal, this._Fk_RecipientList);
            db.AddInParameter(dbCommand, "Recurring_Type", DbType.Decimal, this._Recurring_Type);
            db.AddInParameter(dbCommand, "Created_Date", DbType.DateTime, this._Created_Date);
            db.AddInParameter(dbCommand, "Format_Type", DbType.Int32, this._Format_Type);
            if (string.IsNullOrEmpty(this._ReportSchedulerName))
                db.AddInParameter(dbCommand, "ReportSchedulerName", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "ReportSchedulerName", DbType.String, this._ReportSchedulerName);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Updates a record in the Tatva_ReportSchedule table.
        /// </summary>
        public decimal New_Update()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Tatva_ReportScheduleUpdate");

            db.AddInParameter(dbCommand, "PK_Schedule", DbType.Decimal, this._PK_Schedule);
            db.AddInParameter(dbCommand, "Scheduled_Date", DbType.DateTime, this._Scheduled_Date);
            db.AddInParameter(dbCommand, "Schedule_End_Date", DbType.DateTime, this._Schedule_End_Date);
            db.AddInParameter(dbCommand, "FK_Report", DbType.Decimal, this._FK_Report);
            db.AddInParameter(dbCommand, "Fk_RecipientList", DbType.Decimal, this._Fk_RecipientList);
            db.AddInParameter(dbCommand, "FK_Security_ID", DbType.Decimal, this._FK_Security_ID);
            db.AddInParameter(dbCommand, "Recurring_Type", DbType.Decimal, this._Recurring_Type);
            db.AddInParameter(dbCommand, "Format_Type", DbType.Int32, this._Format_Type);
            if (string.IsNullOrEmpty(this._ReportSchedulerName))
                db.AddInParameter(dbCommand, "ReportSchedulerName", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "ReportSchedulerName", DbType.String, this._ReportSchedulerName);
            return Convert.ToDecimal(db.ExecuteScalar(dbCommand));
        }


        /// <summary>
        /// Deletes a record from the Tatva_ReportSchedule table by a composite primary key.
        /// </summary>
        public static void DeleteByPK(decimal pK_Schedule)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Tatva_ReportScheduleDeleteByPK");

            db.AddInParameter(dbCommand, "PK_Schedule", DbType.Decimal, pK_Schedule);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Deletes a record from the Tatva_ReportSchedule table by a foreign key.
        /// </summary>
        public static void DeleteByFk_RecipientList(decimal fk_RecipientList)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Tatva_ReportScheduleDeleteByFk_RecipientList");

            db.AddInParameter(dbCommand, "Fk_RecipientList", DbType.Decimal, fk_RecipientList);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Deletes a record from the Tatva_ReportSchedule table by a foreign key.
        /// </summary>
        public static void DeleteByFK_Report(decimal fK_Report)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Tatva_ReportScheduleDeleteByFK_Report");

            db.AddInParameter(dbCommand, "FK_Report", DbType.Decimal, fK_Report);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Selects a single record from the Tatva_ReportSchedule table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAllDetailsBy_PK_Scheduler(decimal PK_Schedule)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Tatva_ReportScheduleSelectAllDetails_SelectByPK");


            db.AddInParameter(dbCommand, "PK_Schedule", DbType.Decimal, PK_Schedule);

            return db.ExecuteDataSet(dbCommand);
        }
        #endregion
    }
}
