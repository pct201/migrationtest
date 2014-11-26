using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
    /// <summary>
    /// Data access class for SLT_Training_RLCM table.
    /// </summary>
    public sealed class clsSLT_Training_RLCM
    {

        #region Private variables used to hold the property values

        private decimal? _PK_SLT_Training_RLCM;
        private decimal? _FK_SLT_Meeting;
        private int? _Calendar_Year;
        private int? _Quarter;
        private string _Focus;
        private string _Topic;
        private DateTime? _Date_Scheduled;
        private DateTime? _Date_Completed;
        private string _Reason_Not_Completed;
        private string _Updated_By;
        private DateTime? _Update_Date;

        #endregion

        #region Public Property

        /// <summary>
        /// Gets or sets the PK_SLT_Training_RLCM value.
        /// </summary>
        public decimal? PK_SLT_Training_RLCM
        {
            get { return _PK_SLT_Training_RLCM; }
            set { _PK_SLT_Training_RLCM = value; }
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
        /// Gets or sets the Calendar_Year value.
        /// </summary>
        public int? Calendar_Year
        {
            get { return _Calendar_Year; }
            set { _Calendar_Year = value; }
        }

        /// <summary>
        /// Gets or sets the Quarter value.
        /// </summary>
        public int? Quarter
        {
            get { return _Quarter; }
            set { _Quarter = value; }
        }

        /// <summary>
        /// Gets or sets the Focus value.
        /// </summary>
        public string Focus
        {
            get { return _Focus; }
            set { _Focus = value; }
        }

        /// <summary>
        /// Gets or sets the Topic value.
        /// </summary>
        public string Topic
        {
            get { return _Topic; }
            set { _Topic = value; }
        }

        /// <summary>
        /// Gets or sets the Date_Scheduled value.
        /// </summary>
        public DateTime? Date_Scheduled
        {
            get { return _Date_Scheduled; }
            set { _Date_Scheduled = value; }
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
        /// Gets or sets the Reason_Not_Completed value.
        /// </summary>
        public string Reason_Not_Completed
        {
            get { return _Reason_Not_Completed; }
            set { _Reason_Not_Completed = value; }
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
        /// Initializes a new instance of the clsSLT_Training_RLCM class with default value.
        /// </summary>
        public clsSLT_Training_RLCM()
        {


        }

        #endregion

        #region Primary Constructors

        /// <summary>
        /// Initializes a new instance of the clsSLT_Training_RLCM class based on Primary Key.
        /// </summary>
        public clsSLT_Training_RLCM(decimal pK_SLT_Training_RLCM)
        {
            DataTable dtSLT_Training_RLCM = SelectByPK(pK_SLT_Training_RLCM).Tables[0];

            if (dtSLT_Training_RLCM.Rows.Count == 1)
            {
                SetValue(dtSLT_Training_RLCM.Rows[0]);

            }

        }


        /// <summary>
        /// Initializes a new instance of the clsSLT_Training_RLCM class based on Datarow passed.
        /// </summary>
        private void SetValue(DataRow drSLT_Training_RLCM)
        {
            if (drSLT_Training_RLCM["PK_SLT_Training_RLCM"] == DBNull.Value)
                this._PK_SLT_Training_RLCM = null;
            else
                this._PK_SLT_Training_RLCM = (decimal?)drSLT_Training_RLCM["PK_SLT_Training_RLCM"];

            if (drSLT_Training_RLCM["FK_SLT_Meeting"] == DBNull.Value)
                this._FK_SLT_Meeting = null;
            else
                this._FK_SLT_Meeting = (decimal?)drSLT_Training_RLCM["FK_SLT_Meeting"];

            if (drSLT_Training_RLCM["Calendar_Year"] == DBNull.Value)
                this._Calendar_Year = null;
            else
                this._Calendar_Year = (int?)drSLT_Training_RLCM["Calendar_Year"];

            if (drSLT_Training_RLCM["Quarter"] == DBNull.Value)
                this._Quarter = null;
            else
                this._Quarter = (int?)drSLT_Training_RLCM["Quarter"];

            if (drSLT_Training_RLCM["Focus"] == DBNull.Value)
                this._Focus = null;
            else
                this._Focus = (string)drSLT_Training_RLCM["Focus"];

            if (drSLT_Training_RLCM["Topic"] == DBNull.Value)
                this._Topic = null;
            else
                this._Topic = (string)drSLT_Training_RLCM["Topic"];

            if (drSLT_Training_RLCM["Date_Scheduled"] == DBNull.Value)
                this._Date_Scheduled = null;
            else
                this._Date_Scheduled = (DateTime?)drSLT_Training_RLCM["Date_Scheduled"];

            if (drSLT_Training_RLCM["Date_Completed"] == DBNull.Value)
                this._Date_Completed = null;
            else
                this._Date_Completed = (DateTime?)drSLT_Training_RLCM["Date_Completed"];

            if (drSLT_Training_RLCM["Reason_Not_Completed"] == DBNull.Value)
                this._Reason_Not_Completed = null;
            else
                this._Reason_Not_Completed = (string)drSLT_Training_RLCM["Reason_Not_Completed"];

            if (drSLT_Training_RLCM["Updated_By"] == DBNull.Value)
                this._Updated_By = null;
            else
                this._Updated_By = (string)drSLT_Training_RLCM["Updated_By"];

            if (drSLT_Training_RLCM["Update_Date"] == DBNull.Value)
                this._Update_Date = null;
            else
                this._Update_Date = (DateTime?)drSLT_Training_RLCM["Update_Date"];


        }

        #endregion

        /// <summary>
        /// Inserts a record into the SLT_Training_RLCM table.
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("SLT_Training_RLCMInsert");


            db.AddInParameter(dbCommand, "FK_SLT_Meeting", DbType.Decimal, this._FK_SLT_Meeting);

            db.AddInParameter(dbCommand, "Calendar_Year", DbType.Int32, this._Calendar_Year);

            db.AddInParameter(dbCommand, "Quarter", DbType.Int32, this._Quarter);

            if (string.IsNullOrEmpty(this._Focus))
                db.AddInParameter(dbCommand, "Focus", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Focus", DbType.String, this._Focus);

            if (string.IsNullOrEmpty(this._Topic))
                db.AddInParameter(dbCommand, "Topic", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Topic", DbType.String, this._Topic);

            db.AddInParameter(dbCommand, "Date_Scheduled", DbType.DateTime, this._Date_Scheduled);

            db.AddInParameter(dbCommand, "Date_Completed", DbType.DateTime, this._Date_Completed);

            if (string.IsNullOrEmpty(this._Reason_Not_Completed))
                db.AddInParameter(dbCommand, "Reason_Not_Completed", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Reason_Not_Completed", DbType.String, this._Reason_Not_Completed);

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
        /// Selects a single record from the SLT_Training_RLCM table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        private DataSet SelectByPK(decimal pK_SLT_Training_RLCM)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("SLT_Training_RLCMSelectByPK");

            db.AddInParameter(dbCommand, "PK_SLT_Training_RLCM", DbType.Decimal, pK_SLT_Training_RLCM);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the SLT_Training_RLCM table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("SLT_Training_RLCMSelectAll");

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Updates a record in the SLT_Training_RLCM table.
        /// </summary>
        public void Update()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("SLT_Training_RLCMUpdate");


            db.AddInParameter(dbCommand, "PK_SLT_Training_RLCM", DbType.Decimal, this._PK_SLT_Training_RLCM);

            db.AddInParameter(dbCommand, "FK_SLT_Meeting", DbType.Decimal, this._FK_SLT_Meeting);

            db.AddInParameter(dbCommand, "Calendar_Year", DbType.Int32, this._Calendar_Year);

            db.AddInParameter(dbCommand, "Quarter", DbType.Int32, this._Quarter);

            if (string.IsNullOrEmpty(this._Focus))
                db.AddInParameter(dbCommand, "Focus", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Focus", DbType.String, this._Focus);

            if (string.IsNullOrEmpty(this._Topic))
                db.AddInParameter(dbCommand, "Topic", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Topic", DbType.String, this._Topic);

            db.AddInParameter(dbCommand, "Date_Scheduled", DbType.DateTime, this._Date_Scheduled);

            db.AddInParameter(dbCommand, "Date_Completed", DbType.DateTime, this._Date_Completed);

            if (string.IsNullOrEmpty(this._Reason_Not_Completed))
                db.AddInParameter(dbCommand, "Reason_Not_Completed", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Reason_Not_Completed", DbType.String, this._Reason_Not_Completed);

            if (string.IsNullOrEmpty(this._Updated_By))
                db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);

            db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Deletes a record from the SLT_Training_RLCM table by a composite primary key.
        /// </summary>
        public static void DeleteByPK(decimal pK_SLT_Training_RLCM)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("SLT_Training_RLCMDeleteByPK");

            db.AddInParameter(dbCommand, "PK_SLT_Training_RLCM", DbType.Decimal, pK_SLT_Training_RLCM);

            db.ExecuteNonQuery(dbCommand);
        }

        public static DataSet SelectRLCMTrainingByLocationAndYear(decimal PK_LU_Location_ID, int Year)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("SLT_Training_RLCM_BYLocationAndYear");

            db.AddInParameter(dbCommand, "PK_LU_Location_ID", DbType.Decimal, PK_LU_Location_ID);
            db.AddInParameter(dbCommand, "Year", DbType.Int32, Year);

            return db.ExecuteDataSet(dbCommand);
        }

    }
}
