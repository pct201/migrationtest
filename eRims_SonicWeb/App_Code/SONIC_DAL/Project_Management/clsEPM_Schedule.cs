using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
    /// <summary>
    /// Data access class for EPM_Schedule table.
    /// </summary>
    public sealed class clsEPM_Schedule
    {

        #region Private variables used to hold the property values

        private decimal? _PK_EPM_Schedule;
        private decimal? _FK_EPM_Identification;
        private DateTime? _Date_To_Consultant;
        private DateTime? _RM_Notification_Date;
        private DateTime? _Estimated_Project_Start_Date;
        private DateTime? _Actual_Project_Start_Date;
        private DateTime? _Estimated_Project_Completion_Date;
        private DateTime? _Actual_Project_Completion_Date;
        private string _Updated_By;
        private DateTime? _Update_Date;

        #endregion

        #region Public Property

        /// <summary>
        /// Gets or sets the PK_EPM_Schedule value.
        /// </summary>
        public decimal? PK_EPM_Schedule
        {
            get { return _PK_EPM_Schedule; }
            set { _PK_EPM_Schedule = value; }
        }

        /// <summary>
        /// Gets or sets the FK_EPM_Identification value.
        /// </summary>
        public decimal? FK_EPM_Identification
        {
            get { return _FK_EPM_Identification; }
            set { _FK_EPM_Identification = value; }
        }

        /// <summary>
        /// Gets or sets the Date_To_Consultant value.
        /// </summary>
        public DateTime? Date_To_Consultant
        {
            get { return _Date_To_Consultant; }
            set { _Date_To_Consultant = value; }
        }

        /// <summary>
        /// Gets or sets the RM_Notification_Date value.
        /// </summary>
        public DateTime? RM_Notification_Date
        {
            get { return _RM_Notification_Date; }
            set { _RM_Notification_Date = value; }
        }

        /// <summary>
        /// Gets or sets the Estimated_Project_Start_Date value.
        /// </summary>
        public DateTime? Estimated_Project_Start_Date
        {
            get { return _Estimated_Project_Start_Date; }
            set { _Estimated_Project_Start_Date = value; }
        }

        /// <summary>
        /// Gets or sets the Actual_Project_Start_Date value.
        /// </summary>
        public DateTime? Actual_Project_Start_Date
        {
            get { return _Actual_Project_Start_Date; }
            set { _Actual_Project_Start_Date = value; }
        }

        /// <summary>
        /// Gets or sets the Estimated_Project_Completion_Date value.
        /// </summary>
        public DateTime? Estimated_Project_Completion_Date
        {
            get { return _Estimated_Project_Completion_Date; }
            set { _Estimated_Project_Completion_Date = value; }
        }

        /// <summary>
        /// Gets or sets the Actual_Project_Completion_Date value.
        /// </summary>
        public DateTime? Actual_Project_Completion_Date
        {
            get { return _Actual_Project_Completion_Date; }
            set { _Actual_Project_Completion_Date = value; }
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
        /// Initializes a new instance of the clsEPM_Schedule class with default value.
        /// </summary>
        public clsEPM_Schedule()
        {


        }

        #endregion

        #region Primary Constructors

        /// <summary>
        /// Initializes a new instance of the clsEPM_Schedule class based on Primary Key.
        /// </summary>
        public clsEPM_Schedule(decimal pK_EPM_Schedule)
        {
            DataTable dtEPM_Schedule = SelectByPK(pK_EPM_Schedule).Tables[0];

            if (dtEPM_Schedule.Rows.Count == 1)
            {
                SetValue(dtEPM_Schedule.Rows[0]);

            }

        }


        /// <summary>
        /// Initializes a new instance of the clsEPM_Schedule class based on Foreign Key.
        /// </summary>
        public clsEPM_Schedule(int FK_EPM_Identification)
        {
            DataTable dtEPM_Schedule = SelectByFK(FK_EPM_Identification).Tables[0];

            if (dtEPM_Schedule.Rows.Count == 1)
            {
                SetValue(dtEPM_Schedule.Rows[0]);
            }
        }

        /// <summary>
        /// Initializes a new instance of the clsEPM_Schedule class based on Datarow passed.
        /// </summary>
        private void SetValue(DataRow drEPM_Schedule)
        {
            if (drEPM_Schedule["PK_EPM_Schedule"] == DBNull.Value)
                this._PK_EPM_Schedule = null;
            else
                this._PK_EPM_Schedule = (decimal?)drEPM_Schedule["PK_EPM_Schedule"];

            if (drEPM_Schedule["FK_EPM_Identification"] == DBNull.Value)
                this._FK_EPM_Identification = null;
            else
                this._FK_EPM_Identification = (decimal?)drEPM_Schedule["FK_EPM_Identification"];

            if (drEPM_Schedule["Date_To_Consultant"] == DBNull.Value)
                this._Date_To_Consultant = null;
            else
                this._Date_To_Consultant = (DateTime?)drEPM_Schedule["Date_To_Consultant"];

            if (drEPM_Schedule["RM_Notification_Date"] == DBNull.Value)
                this._RM_Notification_Date = null;
            else
                this._RM_Notification_Date = (DateTime?)drEPM_Schedule["RM_Notification_Date"];

            if (drEPM_Schedule["Estimated_Project_Start_Date"] == DBNull.Value)
                this._Estimated_Project_Start_Date = null;
            else
                this._Estimated_Project_Start_Date = (DateTime?)drEPM_Schedule["Estimated_Project_Start_Date"];

            if (drEPM_Schedule["Actual_Project_Start_Date"] == DBNull.Value)
                this._Actual_Project_Start_Date = null;
            else
                this._Actual_Project_Start_Date = (DateTime?)drEPM_Schedule["Actual_Project_Start_Date"];

            if (drEPM_Schedule["Estimated_Project_Completion_Date"] == DBNull.Value)
                this._Estimated_Project_Completion_Date = null;
            else
                this._Estimated_Project_Completion_Date = (DateTime?)drEPM_Schedule["Estimated_Project_Completion_Date"];

            if (drEPM_Schedule["Actual_Project_Completion_Date"] == DBNull.Value)
                this._Actual_Project_Completion_Date = null;
            else
                this._Actual_Project_Completion_Date = (DateTime?)drEPM_Schedule["Actual_Project_Completion_Date"];

            if (drEPM_Schedule["Updated_By"] == DBNull.Value)
                this._Updated_By = null;
            else
                this._Updated_By = (string)drEPM_Schedule["Updated_By"];

            if (drEPM_Schedule["Update_Date"] == DBNull.Value)
                this._Update_Date = null;
            else
                this._Update_Date = (DateTime?)drEPM_Schedule["Update_Date"];


        }

        #endregion

        /// <summary>
        /// Inserts a record into the EPM_Schedule table.
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("EPM_ScheduleInsert");


            db.AddInParameter(dbCommand, "FK_EPM_Identification", DbType.Decimal, this._FK_EPM_Identification);

            db.AddInParameter(dbCommand, "Date_To_Consultant", DbType.DateTime, this._Date_To_Consultant);

            db.AddInParameter(dbCommand, "RM_Notification_Date", DbType.DateTime, this._RM_Notification_Date);

            db.AddInParameter(dbCommand, "Estimated_Project_Start_Date", DbType.DateTime, this._Estimated_Project_Start_Date);

            db.AddInParameter(dbCommand, "Actual_Project_Start_Date", DbType.DateTime, this._Actual_Project_Start_Date);

            db.AddInParameter(dbCommand, "Estimated_Project_Completion_Date", DbType.DateTime, this._Estimated_Project_Completion_Date);

            db.AddInParameter(dbCommand, "Actual_Project_Completion_Date", DbType.DateTime, this._Actual_Project_Completion_Date);

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
        /// Selects a single record from the EPM_Schedule table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        private DataSet SelectByPK(decimal pK_EPM_Schedule)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("EPM_ScheduleSelectByPK");

            db.AddInParameter(dbCommand, "PK_EPM_Schedule", DbType.Decimal, pK_EPM_Schedule);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the EPM_Schedule table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("EPM_ScheduleSelectAll");

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Updates a record in the EPM_Schedule table.
        /// </summary>
        public int Update()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("EPM_ScheduleUpdate");


            db.AddInParameter(dbCommand, "PK_EPM_Schedule", DbType.Decimal, this._PK_EPM_Schedule);

            db.AddInParameter(dbCommand, "FK_EPM_Identification", DbType.Decimal, this._FK_EPM_Identification);

            db.AddInParameter(dbCommand, "Date_To_Consultant", DbType.DateTime, this._Date_To_Consultant);

            db.AddInParameter(dbCommand, "RM_Notification_Date", DbType.DateTime, this._RM_Notification_Date);

            db.AddInParameter(dbCommand, "Estimated_Project_Start_Date", DbType.DateTime, this._Estimated_Project_Start_Date);

            db.AddInParameter(dbCommand, "Actual_Project_Start_Date", DbType.DateTime, this._Actual_Project_Start_Date);

            db.AddInParameter(dbCommand, "Estimated_Project_Completion_Date", DbType.DateTime, this._Estimated_Project_Completion_Date);

            db.AddInParameter(dbCommand, "Actual_Project_Completion_Date", DbType.DateTime, this._Actual_Project_Completion_Date);

            if (string.IsNullOrEmpty(this._Updated_By))
                db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);

            db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);

            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
        }

        /// <summary>
        /// Deletes a record from the EPM_Schedule table by a composite primary key.
        /// </summary>
        public static void DeleteByPK(decimal pK_EPM_Schedule)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("EPM_ScheduleDeleteByPK");

            db.AddInParameter(dbCommand, "PK_EPM_Schedule", DbType.Decimal, pK_EPM_Schedule);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Selects a single record from the EPM_Schedule table by a Foreign key.
        /// </summary>
        /// <returns>DataSet</returns>
        private DataSet SelectByFK(decimal FK_EPM_Identification)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("EPM_ScheduleSelectByFK");

            db.AddInParameter(dbCommand, "FK_EPM_Identification", DbType.Int64, FK_EPM_Identification);

            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet GetDateDiffByPK(decimal PK_EPM_Schedule)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("EPM_ScheduleGetDateDiffByPk");

            db.AddInParameter(dbCommand, "PK_EPM_Schedule", DbType.Int64, PK_EPM_Schedule);

            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet GetRegionByLocationID(string PK_LU_Location_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("EPM_ScheduleGetRegionByLocationID");

            db.AddInParameter(dbCommand, "PK_LU_Location_ID", DbType.String, PK_LU_Location_ID);

            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet GetdbaByRegion(string Region, decimal PK_Security_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("EPM_Scheduler_GetdbaByRegion");

            db.AddInParameter(dbCommand, "Region", DbType.String, Region);
            db.AddInParameter(dbCommand, "PK_Security_ID", DbType.String, PK_Security_ID);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Get Recipient List to get Mail ids
        /// </summary>
        /// <returns></returns>
        public static DataSet GetRecipientsListForMail()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("EPM_Scheduler_GetRecipients");

            return db.ExecuteDataSet(dbCommand);
        }
        
    }
}
