using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
    /// <summary>
    /// Data access class for Incident table.
    /// </summary>
    public sealed class clsIncident
    {

        #region Private variables used to hold the property values

        private decimal? _PK_Incident;
        private string _Incident_Number;
        private DateTime? _Incident_Date;
        private string _Incident_Time;
        private decimal? _FK_LU_Classification;
        private string _Updated_By;
        private DateTime? _Update_Date;
        private string _Incident_Desc;
        private DateTime? _Date_Opened;

        #endregion

        #region Public Property

        /// <summary>
        /// Gets or sets the PK_Incident value.
        /// </summary>
        public decimal? PK_Incident
        {
            get { return _PK_Incident; }
            set { _PK_Incident = value; }
        }

        /// <summary>
        /// Gets or sets the Incident_Number value.
        /// </summary>
        public string Incident_Number
        {
            get { return _Incident_Number; }
            set { _Incident_Number = value; }
        }

        /// <summary>
        /// Gets or sets the Incident_Date value.
        /// </summary>
        public DateTime? Incident_Date
        {
            get { return _Incident_Date; }
            set { _Incident_Date = value; }
        }

        /// <summary>
        /// Gets or sets the Incident_Time value.
        /// </summary>
        public string Incident_Time
        {
            get { return _Incident_Time; }
            set { _Incident_Time = value; }
        }

        /// <summary>
        /// Gets or sets the FK_LU_Classification value.
        /// </summary>
        public decimal? FK_LU_Classification
        {
            get { return _FK_LU_Classification; }
            set { _FK_LU_Classification = value; }
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
        /// Gets or sets the Incident_Desc value.
        /// </summary>
        public string Incident_Desc
        {
            get { return _Incident_Desc; }
            set { _Incident_Desc = value; }
        }

        /// <summary>
        /// Gets or sets the Date_Opened value.
        /// </summary>
        public DateTime? Date_Opened
        {
            get { return _Date_Opened; }
            set { _Date_Opened = value; }
        }


        #endregion

        #region Default Constructors

        /// <summary>
        /// Initializes a new instance of the clsIncident class with default value.
        /// </summary>
        public clsIncident()
        {


        }

        #endregion

        #region Primary Constructors

        /// <summary>
        /// Initializes a new instance of the clsIncident class based on Primary Key.
        /// </summary>
        public clsIncident(decimal pK_Incident)
        {
            DataTable dtIncident = SelectByPK(pK_Incident).Tables[0];

            if (dtIncident.Rows.Count == 1)
            {
                SetValue(dtIncident.Rows[0]);

            }

        }


        /// <summary>
        /// Initializes a new instance of the clsIncident class based on Datarow passed.
        /// </summary>
        private void SetValue(DataRow drIncident)
        {
            if (drIncident["PK_Incident"] == DBNull.Value)
                this._PK_Incident = null;
            else
                this._PK_Incident = (decimal?)drIncident["PK_Incident"];

            if (drIncident["Incident_Number"] == DBNull.Value)
                this._Incident_Number = null;
            else
                this._Incident_Number = (string)drIncident["Incident_Number"];

            if (drIncident["Incident_Date"] == DBNull.Value)
                this._Incident_Date = null;
            else
                this._Incident_Date = (DateTime?)drIncident["Incident_Date"];

            if (drIncident["Incident_Time"] == DBNull.Value)
                this._Incident_Time = null;
            else
                this._Incident_Time = (string)drIncident["Incident_Time"];

            if (drIncident["FK_LU_Classification"] == DBNull.Value)
                this._FK_LU_Classification = null;
            else
                this._FK_LU_Classification = (decimal?)drIncident["FK_LU_Classification"];

            if (drIncident["Updated_By"] == DBNull.Value)
                this._Updated_By = null;
            else
                this._Updated_By = (string)drIncident["Updated_By"];

            if (drIncident["Update_Date"] == DBNull.Value)
                this._Update_Date = null;
            else
                this._Update_Date = (DateTime?)drIncident["Update_Date"];

            if (drIncident["Incident_Desc"] == DBNull.Value)
                this._Incident_Desc = null;
            else
                this._Incident_Desc = (string)drIncident["Incident_Desc"];

            if (drIncident["Date_Opened"] == DBNull.Value)
                this._Date_Opened = null;
            else
                this._Date_Opened = (DateTime?)drIncident["Date_Opened"];


        }

        #endregion

        /// <summary>
        /// Inserts a record into the Incident table.
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("IncidentInsert");


            if (string.IsNullOrEmpty(this._Incident_Number))
                db.AddInParameter(dbCommand, "Incident_Number", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Incident_Number", DbType.String, this._Incident_Number);

            db.AddInParameter(dbCommand, "Incident_Date", DbType.DateTime, this._Incident_Date);

            if (string.IsNullOrEmpty(this._Incident_Time))
                db.AddInParameter(dbCommand, "Incident_Time", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Incident_Time", DbType.String, this._Incident_Time);

            db.AddInParameter(dbCommand, "FK_LU_Classification", DbType.Decimal, this._FK_LU_Classification);

            if (string.IsNullOrEmpty(this._Updated_By))
                db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);

            db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);

            if (string.IsNullOrEmpty(this._Incident_Desc))
                db.AddInParameter(dbCommand, "Incident_Desc", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Incident_Desc", DbType.String, this._Incident_Desc);

            db.AddInParameter(dbCommand, "Date_Opened", DbType.DateTime, this._Date_Opened);

            // Execute the query and return the new identity value
            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
        }

        /// <summary>
        /// Selects a single record from the Incident table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        private DataSet SelectByPK(decimal pK_Incident)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("IncidentSelectByPK");

            db.AddInParameter(dbCommand, "PK_Incident", DbType.Decimal, pK_Incident);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the Incident table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("IncidentSelectAll");

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Updates a record in the Incident table.
        /// </summary>
        public void Update()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("IncidentUpdate");


            db.AddInParameter(dbCommand, "PK_Incident", DbType.Decimal, this._PK_Incident);

            if (string.IsNullOrEmpty(this._Incident_Number))
                db.AddInParameter(dbCommand, "Incident_Number", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Incident_Number", DbType.String, this._Incident_Number);

            db.AddInParameter(dbCommand, "Incident_Date", DbType.DateTime, this._Incident_Date);

            if (string.IsNullOrEmpty(this._Incident_Time))
                db.AddInParameter(dbCommand, "Incident_Time", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Incident_Time", DbType.String, this._Incident_Time);

            db.AddInParameter(dbCommand, "FK_LU_Classification", DbType.Decimal, this._FK_LU_Classification);

            if (string.IsNullOrEmpty(this._Updated_By))
                db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);

            db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);

            if (string.IsNullOrEmpty(this._Incident_Desc))
                db.AddInParameter(dbCommand, "Incident_Desc", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Incident_Desc", DbType.String, this._Incident_Desc);

            db.AddInParameter(dbCommand, "Date_Opened", DbType.DateTime, this._Date_Opened);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Deletes a record from the Incident table by a composite primary key.
        /// </summary>
        public static void DeleteByPK(decimal pK_Incident)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("IncidentDeleteByPK");

            db.AddInParameter(dbCommand, "PK_Incident", DbType.Decimal, pK_Incident);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Search Incident
        /// </summary>
        /// <param name="Incident_Number"></param>
        /// <param name="FK_LU_Classification"></param>
        /// <param name="Incident_Date_From"></param>
        /// <param name="Incident_Date_To"></param>
        /// <param name="Incident_Time_From"></param>
        /// <param name="Incident_Time_To"></param>
        /// <param name="strOrderBy"></param>
        /// <param name="strOrder"></param>
        /// <param name="intPageNo"></param>
        /// <param name="intPageSize"></param>
        /// <returns></returns>
        public static DataSet IncidentSearch(string Incident_Number, decimal? FK_LU_Classification, DateTime? Incident_Date_From, DateTime? Incident_Date_To, string Incident_Time_From, string Incident_Time_To,
            string strOrderBy, string strOrder, int intPageNo, int intPageSize)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("IncidentSearch");

            db.AddInParameter(dbCommand, "Incident_Number", DbType.String, Incident_Number);
            db.AddInParameter(dbCommand, "FK_LU_Classification", DbType.Decimal, FK_LU_Classification);
            db.AddInParameter(dbCommand, "Incident_Date_From", DbType.DateTime, Incident_Date_From);
            db.AddInParameter(dbCommand, "Incident_Date_To", DbType.DateTime, Incident_Date_To);
            db.AddInParameter(dbCommand, "Incident_Time_From", DbType.String, Incident_Time_From);
            db.AddInParameter(dbCommand, "Incident_Time_To", DbType.String, Incident_Time_To);
            db.AddInParameter(dbCommand, "strOrderBy", DbType.String, strOrderBy);
            db.AddInParameter(dbCommand, "strOrder", DbType.String, strOrder);
            db.AddInParameter(dbCommand, "intPageNo", DbType.Int32, intPageNo);
            db.AddInParameter(dbCommand, "intPageSize", DbType.Int32, intPageSize);

            dbCommand.CommandTimeout = 10000;
            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Check if Alarm is exist or not for Event
        /// </summary>
        /// <param name="pK_Event"></param>
        /// <returns></returns>
        public static DataSet IsValidToDelete(decimal pK_Incident)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Incident_IsValidToDelete");
            db.AddInParameter(dbCommand, "PK_Incident", DbType.Decimal, pK_Incident);

            db.ExecuteNonQuery(dbCommand);

            return db.ExecuteDataSet(dbCommand);
        }
    }
}
