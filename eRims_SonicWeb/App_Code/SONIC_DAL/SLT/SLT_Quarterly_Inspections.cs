using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
    /// <summary>
    /// Data access class for SLT_Quarterly_Inspections table.
    /// </summary>
    public sealed class SLT_Quarterly_Inspections
    {

        #region Private variables used to hold the property values

        private decimal? _PK_SLT_Quarterly_Inspections;
        private decimal? _FK_SLT_Meeting;
        private decimal? _FK_SLT_Members;
        private DateTime? _Date_Completed;
        private string _Comments;
        private bool? _RLCM_Notified;
        private string _Updated_By;
        private DateTime? _Update_Date;
        private decimal? _FK_Inspection_ID;
        private decimal? _FK_Inspection_Responses_ID;
        private decimal? _FK_SLT_Meeting_Schedule;

        #endregion

        #region Public Property

        /// <summary>
        /// Gets or sets the PK_SLT_Quarterly_Inspections value.
        /// </summary>
        public decimal? PK_SLT_Quarterly_Inspections
        {
            get { return _PK_SLT_Quarterly_Inspections; }
            set { _PK_SLT_Quarterly_Inspections = value; }
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
        /// Gets or sets the FK_SLT_Members value.
        /// </summary>
        public decimal? FK_SLT_Members
        {
            get { return _FK_SLT_Members; }
            set { _FK_SLT_Members = value; }
        }

        /// <summary>
        /// Gets or sets the Date_Completed value.
        /// </summary>
        public DateTime? Date_Completed
        {
            get { return _Date_Completed; }
            set { _Date_Completed = value; }
        }

        /// <summary>
        /// Gets or sets the Comments value.
        /// </summary>
        public string Comments
        {
            get { return _Comments; }
            set { _Comments = value; }
        }

        /// <summary>
        /// Gets or sets the RLCM_Notified value.
        /// </summary>
        public bool? RLCM_Notified
        {
            get { return _RLCM_Notified; }
            set { _RLCM_Notified = value; }
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
        /// Gets or sets the FK_Inspection_ID value.
        /// </summary>
        public decimal? FK_Inspection_ID
        {
            get { return _FK_Inspection_ID; }
            set { _FK_Inspection_ID = value; }
        }
        /// <summary>
        /// Gets or sets the FK_Inspection_ID value.
        /// </summary>
        public decimal? FK_Inspection_Responses_ID
        {
            get { return _FK_Inspection_Responses_ID; }
            set { _FK_Inspection_Responses_ID = value; }
        }
        /// <summary>
        /// Gets or sets the FK_SLT_Meeting_Schedule value.
        /// </summary>
        public decimal? FK_SLT_Meeting_Schedule
        {
            get { return _FK_SLT_Meeting_Schedule; }
            set { _FK_SLT_Meeting_Schedule = value; }
        }
        #endregion

        #region Default Constructors

        /// <summary>
        /// Initializes a new instance of the clsSLT_Quarterly_Inspections class with default value.
        /// </summary>
        public SLT_Quarterly_Inspections()
        {


        }

        #endregion

        #region Primary Constructors

        /// <summary>
        /// Initializes a new instance of the clsSLT_Quarterly_Inspections class based on Primary Key.
        /// </summary>
        public SLT_Quarterly_Inspections(decimal pK_SLT_Quarterly_Inspections)
        {
            DataTable dtSLT_Quarterly_Inspections = SelectByPK(pK_SLT_Quarterly_Inspections).Tables[0];

            if (dtSLT_Quarterly_Inspections.Rows.Count == 1)
            {
                SetValue(dtSLT_Quarterly_Inspections.Rows[0]);

            }

        }
        /// <summary>
        /// Initializes a new instance of the clsSLT_Quarterly_Inspections class based on Foreign Key.
        /// </summary>
        public SLT_Quarterly_Inspections(decimal FK_Inspection_ID, decimal FK_Inspection_Responses_ID, decimal FK_SLT_Meeting_Schedule)
        {
            DataTable dtSLT_Quarterly_Inspections = SelectBYFK(FK_Inspection_ID, FK_Inspection_Responses_ID, FK_SLT_Meeting_Schedule).Tables[0];

            if (dtSLT_Quarterly_Inspections.Rows.Count == 1)
            {
                SetValue(dtSLT_Quarterly_Inspections.Rows[0]);

            }

        }

        /// <summary>
        /// Initializes a new instance of the clsSLT_Quarterly_Inspections class based on Datarow passed.
        /// </summary>
        private void SetValue(DataRow drSLT_Quarterly_Inspections)
        {
            if (drSLT_Quarterly_Inspections["PK_SLT_Quarterly_Inspections"] == DBNull.Value)
                this._PK_SLT_Quarterly_Inspections = null;
            else
                this._PK_SLT_Quarterly_Inspections = (decimal?)drSLT_Quarterly_Inspections["PK_SLT_Quarterly_Inspections"];

            if (drSLT_Quarterly_Inspections["FK_SLT_Meeting"] == DBNull.Value)
                this._FK_SLT_Meeting = null;
            else
                this._FK_SLT_Meeting = (decimal?)drSLT_Quarterly_Inspections["FK_SLT_Meeting"];

            if (drSLT_Quarterly_Inspections["FK_SLT_Members"] == DBNull.Value)
                this._FK_SLT_Members = null;
            else
                this._FK_SLT_Members = (decimal?)drSLT_Quarterly_Inspections["FK_SLT_Members"];

            if (drSLT_Quarterly_Inspections["Date_Completed"] == DBNull.Value)
                this._Date_Completed = null;
            else
                this._Date_Completed = (DateTime?)drSLT_Quarterly_Inspections["Date_Completed"];

            if (drSLT_Quarterly_Inspections["Comments"] == DBNull.Value)
                this._Comments = null;
            else
                this._Comments = (string)drSLT_Quarterly_Inspections["Comments"];

            if (drSLT_Quarterly_Inspections["RLCM_Notified"] == DBNull.Value)
                this._RLCM_Notified = null;
            else
                this._RLCM_Notified = (bool?)drSLT_Quarterly_Inspections["RLCM_Notified"];

            if (drSLT_Quarterly_Inspections["Updated_By"] == DBNull.Value)
                this._Updated_By = null;
            else
                this._Updated_By = (string)drSLT_Quarterly_Inspections["Updated_By"];

            if (drSLT_Quarterly_Inspections["Update_Date"] == DBNull.Value)
                this._Update_Date = null;
            else
                this._Update_Date = (DateTime?)drSLT_Quarterly_Inspections["Update_Date"];

            if (drSLT_Quarterly_Inspections["FK_Inspection_ID"] == DBNull.Value)
                this._FK_Inspection_ID = null;
            else
                this._FK_Inspection_ID = (decimal?)drSLT_Quarterly_Inspections["FK_Inspection_ID"];

            if (drSLT_Quarterly_Inspections["FK_Inspection_Responses_ID"] == DBNull.Value)
                this._FK_Inspection_Responses_ID = null;
            else
                this._FK_Inspection_Responses_ID = (decimal?)drSLT_Quarterly_Inspections["FK_Inspection_Responses_ID"];

            if (drSLT_Quarterly_Inspections["FK_SLT_Meeting_Schedule"] == DBNull.Value)
                this._FK_SLT_Meeting_Schedule = null;
            else
                this._FK_SLT_Meeting_Schedule = (decimal?)drSLT_Quarterly_Inspections["FK_SLT_Meeting_Schedule"];


        }

        #endregion

        /// <summary>
        /// Inserts a record into the SLT_Quarterly_Inspections table.
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("SLT_Quarterly_InspectionsInsert");


            db.AddInParameter(dbCommand, "FK_SLT_Meeting", DbType.Decimal, this._FK_SLT_Meeting);

            //if (string.IsNullOrEmpty(this._FK_SLT_Members))
            //    db.AddInParameter(dbCommand, "FK_SLT_Members", DbType.String, DBNull.Value);
            //else
            db.AddInParameter(dbCommand, "FK_SLT_Members", DbType.Decimal, this._FK_SLT_Members);

            db.AddInParameter(dbCommand, "Date_Completed", DbType.DateTime, this._Date_Completed);

            if (string.IsNullOrEmpty(this._Comments))
                db.AddInParameter(dbCommand, "Comments", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Comments", DbType.String, this._Comments);

            db.AddInParameter(dbCommand, "RLCM_Notified", DbType.Boolean, this._RLCM_Notified);

            if (string.IsNullOrEmpty(this._Updated_By))
                db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);

            db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);
            db.AddInParameter(dbCommand, "FK_Inspection_ID", DbType.Decimal, this._FK_Inspection_ID);
            db.AddInParameter(dbCommand, "FK_Inspection_Responses_ID", DbType.Decimal, this._FK_Inspection_Responses_ID);
            db.AddInParameter(dbCommand, "FK_SLT_Meeting_Schedule", DbType.Decimal, this._FK_SLT_Meeting_Schedule);
            // Execute the query and return the new identity value
            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
        }

        /// <summary>
        /// Selects a single record from the SLT_Quarterly_Inspections table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        private DataSet SelectByPK(decimal pK_SLT_Quarterly_Inspections)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("SLT_Quarterly_InspectionsSelectByPK");

            db.AddInParameter(dbCommand, "PK_SLT_Quarterly_Inspections", DbType.Decimal, pK_SLT_Quarterly_Inspections);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the SLT_Quarterly_Inspections table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("SLT_Quarterly_InspectionsSelectAll");

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Updates a record in the SLT_Quarterly_Inspections table.
        /// </summary>
        public void Update()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("SLT_Quarterly_InspectionsUpdate");


            db.AddInParameter(dbCommand, "PK_SLT_Quarterly_Inspections", DbType.Decimal, this._PK_SLT_Quarterly_Inspections);

            db.AddInParameter(dbCommand, "FK_SLT_Meeting", DbType.Decimal, this._FK_SLT_Meeting);


            db.AddInParameter(dbCommand, "FK_SLT_Members", DbType.Decimal, this._FK_SLT_Members);

            db.AddInParameter(dbCommand, "Date_Completed", DbType.DateTime, this._Date_Completed);

            if (string.IsNullOrEmpty(this._Comments))
                db.AddInParameter(dbCommand, "Comments", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Comments", DbType.String, this._Comments);

            db.AddInParameter(dbCommand, "RLCM_Notified", DbType.Boolean, this._RLCM_Notified);

            if (string.IsNullOrEmpty(this._Updated_By))
                db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);

            db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);
            db.AddInParameter(dbCommand, "FK_Inspection_ID", DbType.Decimal, this._FK_Inspection_ID);
            db.AddInParameter(dbCommand, "FK_Inspection_Responses_ID", DbType.Decimal, this._FK_Inspection_Responses_ID);
            db.AddInParameter(dbCommand, "FK_SLT_Meeting_Schedule", DbType.Decimal, this._FK_SLT_Meeting_Schedule);
            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Deletes a record from the SLT_Quarterly_Inspections table by a composite primary key.
        /// </summary>
        public static void DeleteByPK(decimal pK_SLT_Quarterly_Inspections)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("SLT_Quarterly_InspectionsDeleteByPK");

            db.AddInParameter(dbCommand, "PK_SLT_Quarterly_Inspections", DbType.Decimal, pK_SLT_Quarterly_Inspections);

            db.ExecuteNonQuery(dbCommand);
        }

        public static DataSet SelectQuarterlyInspections(decimal FK_LU_Location, int intQuarter, int Year, DateTime? Actual_Meeting_Date)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("SLT_SelectQuarterlyInspections");

            db.AddInParameter(dbCommand, "FK_LU_Location", DbType.Decimal, FK_LU_Location);
            db.AddInParameter(dbCommand, "Quarter", DbType.Int32, intQuarter);
            db.AddInParameter(dbCommand, "Year", DbType.Int32, Year);
            db.AddInParameter(dbCommand, "Actual_Meeting_Date", DbType.DateTime, Actual_Meeting_Date);

            return db.ExecuteDataSet(dbCommand);
        }
        public static DataSet SelectQuarterlyInspection_Responses(decimal FK_Inspection_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Inspection_ResponsesForSLT");

            db.AddInParameter(dbCommand, "FK_Inspection_ID", DbType.Decimal, FK_Inspection_ID);

            return db.ExecuteDataSet(dbCommand);
        }
        /// <summary>
        /// Selects all records from the SLT_Quarterly_Inspections table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectBYFK(decimal FK_Inspection_ID, decimal FK_Inspection_Responses_ID, decimal FK_SLT_Meeting_Schedule)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("SLT_Quarterly_InspectionsSelectBYFK");
            db.AddInParameter(dbCommand, "FK_Inspection_ID", DbType.Decimal, FK_Inspection_ID);
            db.AddInParameter(dbCommand, "FK_Inspection_Responses_ID", DbType.Decimal, FK_Inspection_Responses_ID);
            db.AddInParameter(dbCommand, "FK_SLT_Meeting_Schedule", DbType.Decimal, FK_SLT_Meeting_Schedule);
            return db.ExecuteDataSet(dbCommand);
        }
    }
}
