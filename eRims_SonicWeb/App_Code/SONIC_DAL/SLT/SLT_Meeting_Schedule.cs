using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
    /// <summary>
    /// Data access class for SLT_Meeting_Schedule table.
    /// </summary>
    public sealed class SLT_Meeting_Schedule
    {

        #region Private variables used to hold the property values

        private decimal? _PK_SLT_Meeting_Schedule;
        private decimal? _FK_SLT_Meeting;
        private DateTime? _Actual_Meeting_Date;
        private DateTime? _Scheduled_Meeting_Date;
        private string _Scheduled_Meeting_Time;
        private string _Meeting_Place;
        private bool? _Email_Members;
        private string _Updated_By;
        private DateTime? _Update_Date;
        private string _Meeting_Start_Time;
        private string _Meeting_End_Time;
        private bool? _Prev_Meeting_Review;
        private DateTime? _Meeting_Approved_date;
        private decimal? _FK_LU_Meeting_Quality;
        private string _Meeting_Comments;
        private string _UniqueVal;
        private int? _Full_Participation;
        private int? _Full_SW_Participation;
        private int? _Incident_Review;
        private int? _RLCM_Score;
        private int? _SLT_Score;

        private int? _Overwrite_Full_Participation;
        private int? _Overwrite_Full_SW_Participation;
        private int? _Overwrite_Incident_Review;
        private int? _Overwrite_RLCM_Score;

        private DateTime? _Date_Meeting_Minutes_Sent;
        private DateTime? _Date_Scored;
        private int? _Lag_Time;
        private string _RLCM_Attended;
        private string _Safety_Board_Updated;
        private string _Time_Zone;
        private int _SLT_Meeting_CutOff_Day;
        #endregion

        #region Public Property

        /// <summary>
        /// Gets or sets the PK_SLT_Meeting_Schedule value.
        /// </summary>
        public decimal? PK_SLT_Meeting_Schedule
        {
            get { return _PK_SLT_Meeting_Schedule; }
            set { _PK_SLT_Meeting_Schedule = value; }
        }

        /// <summary>
        /// Gets or sets the FK_SLT_Meeting value.
        /// </summary>
        public decimal? FK_SLT_Meeting
        {
            get { return _FK_SLT_Meeting; }
            set { _FK_SLT_Meeting = value; }
        }

        /// <summary>
        /// Gets or sets the Actual_Meeting_Date value.
        /// </summary>
        public DateTime? Actual_Meeting_Date
        {
            get { return _Actual_Meeting_Date; }
            set { _Actual_Meeting_Date = value; }
        }

        /// <summary>
        /// Gets or sets the Scheduled_Meeting_Date value.
        /// </summary>
        public DateTime? Scheduled_Meeting_Date
        {
            get { return _Scheduled_Meeting_Date; }
            set { _Scheduled_Meeting_Date = value; }
        }

        /// <summary>
        /// Gets or sets the Scheduled_Meeting_Time value.
        /// </summary>
        public string Scheduled_Meeting_Time
        {
            get { return _Scheduled_Meeting_Time; }
            set { _Scheduled_Meeting_Time = value; }
        }

        /// <summary>
        /// Gets or sets the Meeting_Place value.
        /// </summary>
        public string Meeting_Place
        {
            get { return _Meeting_Place; }
            set { _Meeting_Place = value; }
        }

        /// <summary>
        /// Gets or sets the Email_Members value.
        /// </summary>
        public bool? Email_Members
        {
            get { return _Email_Members; }
            set { _Email_Members = value; }
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

        /// <summary>
        /// Gets or sets the Meeting_Start_Time value.
        /// </summary>
        public string Meeting_Start_Time
        {
            get { return _Meeting_Start_Time; }
            set { _Meeting_Start_Time = value; }
        }

        /// <summary>
        /// Gets or sets the Meeting_End_Time value.
        /// </summary>
        public string Meeting_End_Time
        {
            get { return _Meeting_End_Time; }
            set { _Meeting_End_Time = value; }
        }

        /// <summary>
        /// Gets or sets the Prev_Meeting_Review value.
        /// </summary>
        public bool? Prev_Meeting_Review
        {
            get { return _Prev_Meeting_Review; }
            set { _Prev_Meeting_Review = value; }
        }


        /// <summary>
        /// Gets or sets the Meeting_Approved_date value.
        /// </summary>
        public DateTime? Meeting_Approved_date
        {
            get { return _Meeting_Approved_date; }
            set { _Meeting_Approved_date = value; }
        }

        /// <summary>
        /// Gets or sets the FK_LU_Meeting_Quality value.
        /// </summary>
        public decimal? FK_LU_Meeting_Quality
        {
            get { return _FK_LU_Meeting_Quality; }
            set { _FK_LU_Meeting_Quality = value; }
        }

        /// <summary>
        /// Gets or Sets the Meeting_Comments value
        /// </summary>
        public string Meeting_Comments
        {
            get { return _Meeting_Comments; }
            set { _Meeting_Comments = value; }
        }
        /// <summary>
        /// Gets or sets the UniqueVal value.
        /// </summary>
        public string UniqueVal
        {
            get { return _UniqueVal; }
            set { _UniqueVal = value; }
        }
        /// <summary>
        /// Gets or Sets the Full_Participation value
        /// </summary>
        public int? Full_Participation
        {
            get { return _Full_Participation; }
            set { _Full_Participation = value; }
        }
        /// <summary>
        /// Gets Or sets the Full_SW_Participation value
        /// </summary>
        public int? Full_SW_Participation
        {
            get { return _Full_SW_Participation; }
            set { _Full_SW_Participation = value; }
        }
        /// <summary>
        /// Gets or sets Incident_Review value
        /// </summary>
        public int? Incident_Review
        {
            get { return _Incident_Review; }
            set { _Incident_Review = value; }
        }
        /// <summary>
        /// Gets or sets RLCM_Score value
        /// </summary>
        public int? RLCM_Score
        {
            get { return _RLCM_Score; }
            set { _RLCM_Score = value; }
        }
        /// <summary>
        /// get or set SLT_Score value
        /// </summary>
        public int? SLT_Score
        {
            get { return _SLT_Score; }
            set { _SLT_Score = value; }
        }

        public int? Overwrite_Full_Participation
        {
            get { return _Overwrite_Full_Participation; }
            set { _Overwrite_Full_Participation = value; }
        }

        public int? Overwrite_Full_SW_Participation
        {
            get { return _Overwrite_Full_SW_Participation; }
            set { _Overwrite_Full_SW_Participation = value; }
        }

        public int? Overwrite_Incident_Review
        {
            get { return _Overwrite_Incident_Review; }
            set { _Overwrite_Incident_Review = value; }
        }

        public int? Overwrite_RLCM_Score
        {
            get { return _Overwrite_RLCM_Score; }
            set { _Overwrite_RLCM_Score = value; }
        }

        public DateTime? Date_Meeting_Minutes_Sent
        {
            get { return _Date_Meeting_Minutes_Sent; }
            set { _Date_Meeting_Minutes_Sent = value; }
        }

        public DateTime? Date_Scored
        {
            get { return _Date_Scored; }
            set { _Date_Scored = value; }
        }

        public int? Lag_Time
        {
            get { return _Lag_Time; }
            set { _Lag_Time = value; }
        }

        public string RLCM_Attended
        {
            get { return _RLCM_Attended; }
            set { _RLCM_Attended = value; }
        }

        public string Safety_Board_Updated
        {
            get { return _Safety_Board_Updated; }
            set { _Safety_Board_Updated=value;}
        }

        /// <summary>
        /// Gets or sets the Time_Zone value.
        /// </summary>
        public string Time_Zone
        {
            get { return _Time_Zone; }
            set { _Time_Zone = value; }
        }

        public int SLT_Meeting_CutOff_Day
        {
            get { return _SLT_Meeting_CutOff_Day; }
            set { _SLT_Meeting_CutOff_Day = value; }
        }

        #endregion

        #region Default Constructors

        /// <summary>
        /// Initializes a new instance of the clsSLT_Meeting_Schedule class with default value.
        /// </summary>
        public SLT_Meeting_Schedule()
        {


        }

        #endregion

        #region Primary Constructors

        /// <summary>
        /// Initializes a new instance of the clsSLT_Meeting_Schedule class based on Primary Key.
        /// </summary>
        public SLT_Meeting_Schedule(decimal pK_SLT_Meeting_Schedule)
        {
            DataTable dtSLT_Meeting_Schedule = SelectByPK(pK_SLT_Meeting_Schedule).Tables[0];

            if (dtSLT_Meeting_Schedule.Rows.Count == 1)
            {
                SetValue(dtSLT_Meeting_Schedule.Rows[0]);

            }

        }

        public SLT_Meeting_Schedule(decimal FK_SLT_Meeting, bool Status, DateTime? Actual_Meeting_DateFrom, DateTime? Actual_Meeting_DateTo, int Year, int Month)
        {
            DataTable dtSLT_Meeting_Schedule = SelectBYFK(FK_SLT_Meeting, Actual_Meeting_DateFrom, Actual_Meeting_DateTo, Year, Month, "Actual_Meeting_Date", "DESC").Tables[0];//Default value of order by

            if (dtSLT_Meeting_Schedule.Rows.Count == 1)
            {
                SetValue(dtSLT_Meeting_Schedule.Rows[0]);

            }

        }


        /// <summary>
        /// Initializes a new instance of the clsSLT_Meeting_Schedule class based on Datarow passed.
        /// </summary>
        private void SetValue(DataRow drSLT_Meeting_Schedule)
        {
            if (drSLT_Meeting_Schedule["PK_SLT_Meeting_Schedule"] == DBNull.Value)
                this._PK_SLT_Meeting_Schedule = null;
            else
                this._PK_SLT_Meeting_Schedule = (decimal?)drSLT_Meeting_Schedule["PK_SLT_Meeting_Schedule"];

            if (drSLT_Meeting_Schedule["FK_SLT_Meeting"] == DBNull.Value)
                this._FK_SLT_Meeting = null;
            else
                this._FK_SLT_Meeting = (decimal?)drSLT_Meeting_Schedule["FK_SLT_Meeting"];

            if (drSLT_Meeting_Schedule["Actual_Meeting_Date"] == DBNull.Value)
                this._Actual_Meeting_Date = null;
            else
                this._Actual_Meeting_Date = (DateTime?)drSLT_Meeting_Schedule["Actual_Meeting_Date"];

            if (drSLT_Meeting_Schedule["Scheduled_Meeting_Date"] == DBNull.Value)
                this._Scheduled_Meeting_Date = null;
            else
                this._Scheduled_Meeting_Date = (DateTime?)drSLT_Meeting_Schedule["Scheduled_Meeting_Date"];

            if (drSLT_Meeting_Schedule["Scheduled_Meeting_Time"] == DBNull.Value)
                this._Scheduled_Meeting_Time = null;
            else
                this._Scheduled_Meeting_Time = (string)drSLT_Meeting_Schedule["Scheduled_Meeting_Time"];

            if (drSLT_Meeting_Schedule["Meeting_Place"] == DBNull.Value)
                this._Meeting_Place = null;
            else
                this._Meeting_Place = (string)drSLT_Meeting_Schedule["Meeting_Place"];

            if (drSLT_Meeting_Schedule["Email_Members"] == DBNull.Value)
                this._Email_Members = null;
            else
                this._Email_Members = (bool?)drSLT_Meeting_Schedule["Email_Members"];

            if (drSLT_Meeting_Schedule["Updated_By"] == DBNull.Value)
                this._Updated_By = null;
            else
                this._Updated_By = (string)drSLT_Meeting_Schedule["Updated_By"];

            if (drSLT_Meeting_Schedule["Update_Date"] == DBNull.Value)
                this._Update_Date = null;
            else
                this._Update_Date = (DateTime?)drSLT_Meeting_Schedule["Update_Date"];

            if (drSLT_Meeting_Schedule["Meeting_Start_Time"] == DBNull.Value)
                this._Meeting_Start_Time = null;
            else
                this._Meeting_Start_Time = (string)drSLT_Meeting_Schedule["Meeting_Start_Time"];

            if (drSLT_Meeting_Schedule["Meeting_End_Time"] == DBNull.Value)
                this._Meeting_End_Time = null;
            else
                this._Meeting_End_Time = (string)drSLT_Meeting_Schedule["Meeting_End_Time"];

            if (drSLT_Meeting_Schedule["Prev_Meeting_Review"] == DBNull.Value)
                this._Prev_Meeting_Review = null;
            else
                this._Prev_Meeting_Review = (bool?)drSLT_Meeting_Schedule["Prev_Meeting_Review"];

            if (drSLT_Meeting_Schedule["Safety_Board_Updated"] == DBNull.Value)
                this._Safety_Board_Updated = null;
            else
                this._Safety_Board_Updated = (string)drSLT_Meeting_Schedule["Safety_Board_Updated"];

            if (drSLT_Meeting_Schedule["Meeting_Approved_date"] == DBNull.Value)
                this._Meeting_Approved_date = null;
            else
                this._Meeting_Approved_date = (DateTime?)drSLT_Meeting_Schedule["Meeting_Approved_date"];

            if (drSLT_Meeting_Schedule["FK_LU_Meeting_Quality"] == DBNull.Value)
                this._FK_LU_Meeting_Quality = null;
            else
                this._FK_LU_Meeting_Quality = (decimal?)drSLT_Meeting_Schedule["FK_LU_Meeting_Quality"];

            if (drSLT_Meeting_Schedule["Meeting_Comments"] == DBNull.Value)
                this._Meeting_Comments = null;
            else
                this._Meeting_Comments = (string)drSLT_Meeting_Schedule["Meeting_Comments"];

            if (drSLT_Meeting_Schedule["Full_Participation"] == DBNull.Value)
                this._Full_Participation = null;
            else
                this._Full_Participation = (int?)drSLT_Meeting_Schedule["Full_Participation"];

            if (drSLT_Meeting_Schedule["Full_SW_Participation"] == DBNull.Value)
                this._Full_SW_Participation = null;
            else
                this._Full_SW_Participation = (int?)drSLT_Meeting_Schedule["Full_SW_Participation"];

            if (drSLT_Meeting_Schedule["Incident_Review"] == DBNull.Value)
                this._Incident_Review = null;
            else
                this._Incident_Review = (int?)drSLT_Meeting_Schedule["Incident_Review"];

            if (drSLT_Meeting_Schedule["RLCM_Score"] == DBNull.Value)
                this._RLCM_Score = null;
            else
                this._RLCM_Score = (int?)drSLT_Meeting_Schedule["RLCM_Score"];

            if (drSLT_Meeting_Schedule["SLT_Score"] == DBNull.Value)
                this._SLT_Score = null;
            else
                this._SLT_Score = (int?)drSLT_Meeting_Schedule["SLT_Score"];

            if (drSLT_Meeting_Schedule["Overwrite_Full_Participation"] == DBNull.Value)
                this._Overwrite_Full_Participation = null;
            else
                this._Overwrite_Full_Participation = (int?)drSLT_Meeting_Schedule["Overwrite_Full_Participation"];

            if (drSLT_Meeting_Schedule["Overwrite_Full_SW_Participation"] == DBNull.Value)
                this._Overwrite_Full_SW_Participation = null;
            else
                this._Overwrite_Full_SW_Participation = (int?)drSLT_Meeting_Schedule["Overwrite_Full_SW_Participation"];

            if (drSLT_Meeting_Schedule["Overwrite_Incident_Review"] == DBNull.Value)
                this._Overwrite_Incident_Review = null;
            else
                this._Overwrite_Incident_Review = (int?)drSLT_Meeting_Schedule["Overwrite_Incident_Review"];


            if (drSLT_Meeting_Schedule["Overwrite_RLCM_Score"] == DBNull.Value)
                this._Overwrite_RLCM_Score = null;
            else
                this._Overwrite_RLCM_Score = (int?)drSLT_Meeting_Schedule["Overwrite_RLCM_Score"];

            if (drSLT_Meeting_Schedule["Date_Meeting_Minutes_Sent"] == DBNull.Value)
                this._Date_Meeting_Minutes_Sent = null;
            else
                this._Date_Meeting_Minutes_Sent = (DateTime?)drSLT_Meeting_Schedule["Date_Meeting_Minutes_Sent"];

            if (drSLT_Meeting_Schedule["Date_Scored"] == DBNull.Value)
                this._Date_Scored = null;
            else
                this._Date_Scored = (DateTime?)drSLT_Meeting_Schedule["Date_Scored"];

            if (drSLT_Meeting_Schedule["Lag_Time"] == DBNull.Value)
                this._Lag_Time = null;
            else
                this._Lag_Time = (int?)drSLT_Meeting_Schedule["Lag_Time"];

            if (drSLT_Meeting_Schedule["RLCM_Attended"] == DBNull.Value)
                this._RLCM_Attended = null;
            else
                this._RLCM_Attended = (string)drSLT_Meeting_Schedule["RLCM_Attended"];

            if (drSLT_Meeting_Schedule["Time_Zone"] == DBNull.Value)
                this._Time_Zone = null;
            else
                this._Time_Zone = (string)drSLT_Meeting_Schedule["Time_Zone"];

        }


        #endregion

        /// <summary>
        /// Inserts a record into the SLT_Meeting_Schedule table.
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("SLT_Meeting_ScheduleInsert");


            db.AddInParameter(dbCommand, "FK_SLT_Meeting", DbType.Decimal, this._FK_SLT_Meeting);

            db.AddInParameter(dbCommand, "Actual_Meeting_Date", DbType.DateTime, this._Actual_Meeting_Date);

            db.AddInParameter(dbCommand, "Scheduled_Meeting_Date", DbType.DateTime, this._Scheduled_Meeting_Date);

            if (string.IsNullOrEmpty(this._Scheduled_Meeting_Time))
                db.AddInParameter(dbCommand, "Scheduled_Meeting_Time", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Scheduled_Meeting_Time", DbType.String, this._Scheduled_Meeting_Time);

            if (string.IsNullOrEmpty(this._Meeting_Place))
                db.AddInParameter(dbCommand, "Meeting_Place", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Meeting_Place", DbType.String, this._Meeting_Place);

            db.AddInParameter(dbCommand, "Email_Members", DbType.Boolean, this._Email_Members);

            if (string.IsNullOrEmpty(this._Updated_By))
                db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);

            db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);

            if (string.IsNullOrEmpty(this._Meeting_Start_Time))
                db.AddInParameter(dbCommand, "Meeting_Start_Time", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Meeting_Start_Time", DbType.String, this._Meeting_Start_Time);

            if (string.IsNullOrEmpty(this._Meeting_End_Time))
                db.AddInParameter(dbCommand, "Meeting_End_Time", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Meeting_End_Time", DbType.String, this._Meeting_End_Time);

            db.AddInParameter(dbCommand, "Prev_Meeting_Review", DbType.Boolean, this._Prev_Meeting_Review);

            if (string.IsNullOrEmpty(this._Safety_Board_Updated))
                db.AddInParameter(dbCommand, "Safety_Board_Updated", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Safety_Board_Updated", DbType.String, this._Safety_Board_Updated);

            db.AddInParameter(dbCommand, "Meeting_Approved_date", DbType.DateTime, this._Meeting_Approved_date);

            db.AddInParameter(dbCommand, "FK_LU_Meeting_Quality", DbType.Decimal, this._FK_LU_Meeting_Quality);

            if (string.IsNullOrEmpty(this._Meeting_Comments))
                db.AddInParameter(dbCommand, "Meeting_Comments", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Meeting_Comments", DbType.String, this._Meeting_Comments);
            if (string.IsNullOrEmpty(this._UniqueVal))
                db.AddInParameter(dbCommand, "UniqueVal", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "UniqueVal", DbType.String, this._UniqueVal);
            db.AddInParameter(dbCommand, "Full_Participation", DbType.Int32, this._Full_Participation);
            db.AddInParameter(dbCommand, "Full_SW_Participation", DbType.Int32, this._Full_SW_Participation);
            db.AddInParameter(dbCommand, "Incident_Review", DbType.Int32, this._Incident_Review);
            db.AddInParameter(dbCommand, "RLCM_Score", DbType.Int32, this._RLCM_Score);
            db.AddInParameter(dbCommand, "SLT_Score", DbType.Int32, this._SLT_Score);
            db.AddInParameter(dbCommand, "Date_Meeting_Minutes_Sent", DbType.DateTime, this._Date_Meeting_Minutes_Sent);
            db.AddInParameter(dbCommand, "Date_Scored", DbType.DateTime, this._Date_Scored);
            if (string.IsNullOrEmpty(this._RLCM_Attended))
                db.AddInParameter(dbCommand, "RLCM_Attended", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "RLCM_Attended", DbType.String, this._RLCM_Attended);

            if (string.IsNullOrEmpty(this._Time_Zone))
                db.AddInParameter(dbCommand, "Time_Zone", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Time_Zone", DbType.String, this._Time_Zone);

            db.AddInParameter(dbCommand, "SLT_Meeting_CutOff_Day", DbType.Int16, this._SLT_Meeting_CutOff_Day);

            //db.AddInParameter(dbCommand, "Lag_Time", DbType.Int32, this._Lag_Time);

            //db.AddInParameter(dbCommand, "Overwrite_Full_Participation", DbType.Int32, this._Overwrite_Full_Participation);

            //db.AddInParameter(dbCommand, "Overwrite_Full_SW_Participation", DbType.Int32, this._Overwrite_Full_SW_Participation);

            //db.AddInParameter(dbCommand, "Overwrite_Incident_Review", DbType.Int32, this._Overwrite_Incident_Review);

            //db.AddInParameter(dbCommand, "Overwrite_RLCM_Score", DbType.Int32, this._Overwrite_RLCM_Score);
            //db.AddInParameter(dbCommand, "FK_LU_Location", DbType.Decimal, FK_LU_Location);
            // Execute the query and return the new identity value
            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
        }

        /// <summary>
        /// Selects a single record from the SLT_Meeting_Schedule table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        private DataSet SelectByPK(decimal pK_SLT_Meeting_Schedule)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("SLT_Meeting_ScheduleSelectByPK");

            db.AddInParameter(dbCommand, "PK_SLT_Meeting_Schedule", DbType.Decimal, pK_SLT_Meeting_Schedule);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the SLT_Meeting_Schedule table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("SLT_Meeting_ScheduleSelectAll");

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Updates a record in the SLT_Meeting_Schedule table.
        /// </summary>
        public void Update()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("SLT_Meeting_ScheduleUpdate");


            db.AddInParameter(dbCommand, "PK_SLT_Meeting_Schedule", DbType.Decimal, this._PK_SLT_Meeting_Schedule);

            db.AddInParameter(dbCommand, "FK_SLT_Meeting", DbType.Decimal, this._FK_SLT_Meeting);

            db.AddInParameter(dbCommand, "Actual_Meeting_Date", DbType.DateTime, this._Actual_Meeting_Date);

            db.AddInParameter(dbCommand, "Scheduled_Meeting_Date", DbType.DateTime, this._Scheduled_Meeting_Date);

            if (string.IsNullOrEmpty(this._Scheduled_Meeting_Time))
                db.AddInParameter(dbCommand, "Scheduled_Meeting_Time", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Scheduled_Meeting_Time", DbType.String, this._Scheduled_Meeting_Time);

            if (string.IsNullOrEmpty(this._Meeting_Place))
                db.AddInParameter(dbCommand, "Meeting_Place", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Meeting_Place", DbType.String, this._Meeting_Place);

            db.AddInParameter(dbCommand, "Email_Members", DbType.Boolean, this._Email_Members);

            if (string.IsNullOrEmpty(this._Updated_By))
                db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);

            db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);

            if (string.IsNullOrEmpty(this._Meeting_Start_Time))
                db.AddInParameter(dbCommand, "Meeting_Start_Time", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Meeting_Start_Time", DbType.String, this._Meeting_Start_Time);

            if (string.IsNullOrEmpty(this._Meeting_End_Time))
                db.AddInParameter(dbCommand, "Meeting_End_Time", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Meeting_End_Time", DbType.String, this._Meeting_End_Time);

            db.AddInParameter(dbCommand, "Prev_Meeting_Review", DbType.Boolean, this._Prev_Meeting_Review);

            if (string.IsNullOrEmpty(this._Safety_Board_Updated))
                db.AddInParameter(dbCommand, "Safety_Board_Updated", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Safety_Board_Updated", DbType.String, this._Safety_Board_Updated);

            db.AddInParameter(dbCommand, "Meeting_Approved_date", DbType.DateTime, this._Meeting_Approved_date);

            db.AddInParameter(dbCommand, "FK_LU_Meeting_Quality", DbType.Decimal, this._FK_LU_Meeting_Quality);

            if (string.IsNullOrEmpty(this._Meeting_Comments))
                db.AddInParameter(dbCommand, "Meeting_Comments", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Meeting_Comments", DbType.String, this._Meeting_Comments);
            if (string.IsNullOrEmpty(this._UniqueVal))
                db.AddInParameter(dbCommand, "UniqueVal", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "UniqueVal", DbType.String, this._UniqueVal);
            db.AddInParameter(dbCommand, "Full_Participation", DbType.Int32, this._Full_Participation);
            db.AddInParameter(dbCommand, "Full_SW_Participation", DbType.Int32, this._Full_SW_Participation);
            db.AddInParameter(dbCommand, "Incident_Review", DbType.Int32, this._Incident_Review);
            db.AddInParameter(dbCommand, "RLCM_Score", DbType.Int32, this._RLCM_Score);
            db.AddInParameter(dbCommand, "SLT_Score", DbType.Int32, this._SLT_Score);
            db.AddInParameter(dbCommand, "Date_Meeting_Minutes_Sent", DbType.DateTime, this._Date_Meeting_Minutes_Sent);
            db.AddInParameter(dbCommand, "Date_Scored", DbType.DateTime, this._Date_Scored);

            if (string.IsNullOrEmpty(this._RLCM_Attended))
                db.AddInParameter(dbCommand, "RLCM_Attended", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "RLCM_Attended", DbType.String, this._RLCM_Attended);

            if (string.IsNullOrEmpty(this._Time_Zone))
                db.AddInParameter(dbCommand, "Time_Zone", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Time_Zone", DbType.String, this._Time_Zone);

            //db.AddInParameter(dbCommand, "Lag_Time", DbType.Int32, this._Lag_Time);

            //db.AddInParameter(dbCommand, "Overwrite_Full_Participation", DbType.Int32, this._Overwrite_Full_Participation);

            //db.AddInParameter(dbCommand, "Overwrite_Full_SW_Participation", DbType.Int32, this._Overwrite_Full_SW_Participation);

            //db.AddInParameter(dbCommand, "Overwrite_Incident_Review", DbType.Int32, this._Overwrite_Incident_Review);

            //db.AddInParameter(dbCommand, "Overwrite_RLCM_Score", DbType.Int32, this._Overwrite_RLCM_Score);
            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Deletes a record from the SLT_Meeting_Schedule table by a composite primary key.
        /// </summary>
        public static void DeleteByPK(decimal pK_SLT_Meeting_Schedule)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("SLT_Meeting_ScheduleDeleteByPK");

            db.AddInParameter(dbCommand, "PK_SLT_Meeting_Schedule", DbType.Decimal, pK_SLT_Meeting_Schedule);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Selects all records from the SLT_Meeting_Schedule table By FK.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectBYFK(decimal FK_SLT_Meeting, DateTime? Actual_Meeting_DateFrom, DateTime? Actual_Meeting_DateTo, int Year, int Month, string strOrderBy, string strOrder)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("SelectSLT_Meeting_ScheduleBYFK");
            db.AddInParameter(dbCommand, "FK_SLT_Meeting", DbType.Decimal, FK_SLT_Meeting);
            db.AddInParameter(dbCommand, "Actual_Meeting_DateFrom", DbType.DateTime, Actual_Meeting_DateFrom);
            db.AddInParameter(dbCommand, "Actual_Meeting_DateTo", DbType.DateTime, Actual_Meeting_DateTo);
            db.AddInParameter(dbCommand, "Year", DbType.Int32, Year);
            db.AddInParameter(dbCommand, "Month", DbType.Int32, Month);
            db.AddInParameter(dbCommand, "strOrderBy", DbType.String, strOrderBy);
            db.AddInParameter(dbCommand, "strOrder", DbType.String, strOrder);
            return db.ExecuteDataSet(dbCommand);
        }
        /// <summary>
        /// Deletes a record from the SLT_Meeting_Schedule table by a composite primary key.
        /// </summary>
        public static DataSet SelectNextMeeting(decimal pK_SLT_Meeting_Schedule, decimal FK_SLT_Meeting)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("SLT_Meeting_ScheduleSelectNextMeeting");

            db.AddInParameter(dbCommand, "PK_SLT_Meeting_Schedule", DbType.Decimal, pK_SLT_Meeting_Schedule);
            db.AddInParameter(dbCommand, "FK_SLT_Meeting", DbType.Decimal, FK_SLT_Meeting);

            return db.ExecuteDataSet(dbCommand);
        }
    }
}
