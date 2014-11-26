using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
    /// <summary>
    /// Data access class for Enviro_Recommendations table.
    /// </summary>
    public sealed class Enviro_Recommendations
    {
        #region Fields

        private int _PK_Enviro_Equipment_Recommendations_ID;
        private string _Foreign_Table;
        private int _Foreign_Key;
        private Nullable<DateTime> _Date;
        private string _Number;
        private string _Made_by;
        private string _status;
        private string _title;
        private string _description;
        private string _Assigned_to;
        private Nullable<DateTime> _Due_date;
        private string _Assigned_to_phone;
        private string _Assigned_to_email;
        private decimal? _Estimated_Cost;
        private decimal? _Final_Cost;
        private string _resolution;
        private Nullable<DateTime> _Date_closed;
        private DateTime _Update_Date;
        private string _Updated_By;

        #endregion

        #region Properties


        /// <summary> 
        /// Gets or sets the PK_Enviro_Equipment_Recommendations_ID value.
        /// </summary>
        public int PK_Enviro_Equipment_Recommendations_ID
        {
            get { return _PK_Enviro_Equipment_Recommendations_ID; }
            set { _PK_Enviro_Equipment_Recommendations_ID = value; }
        }
        /// <summary> 
        /// Gets or sets the Foreign_Table value.
        /// </summary>
        public string Foreign_Table
        {
            get { return _Foreign_Table; }
            set { _Foreign_Table = value; }
        }

        /// <summary> 
        /// Gets or sets the Foreign_Key value.
        /// </summary>
        public int Foreign_Key
        {
            get { return _Foreign_Key; }
            set { _Foreign_Key = value; }
        }

        /// <summary> 
        /// Gets or sets the Date value.
        /// </summary>
        public Nullable<DateTime> Date
        {
            get { return _Date; }
            set { _Date = value; }
        }

        /// <summary> 
        /// Gets or sets the Number value.
        /// </summary>
        public string Number
        {
            get { return _Number; }
            set { _Number = value; }
        }

        /// <summary> 
        /// Gets or sets the Made_by value.
        /// </summary>
        public string Made_by
        {
            get { return _Made_by; }
            set { _Made_by = value; }
        }

        /// <summary> 
        /// Gets or sets the status value.
        /// </summary>
        public string status
        {
            get { return _status; }
            set { _status = value; }
        }

        /// <summary> 
        /// Gets or sets the title value.
        /// </summary>
        public string title
        {
            get { return _title; }
            set { _title = value; }
        }

        /// <summary> 
        /// Gets or sets the description value.
        /// </summary>
        public string description
        {
            get { return _description; }
            set { _description = value; }
        }

        /// <summary> 
        /// Gets or sets the Assigned_to value.
        /// </summary>
        public string Assigned_to
        {
            get { return _Assigned_to; }
            set { _Assigned_to = value; }
        }

        /// <summary> 
        /// Gets or sets the Due_date value.
        /// </summary>
        public Nullable<DateTime> Due_date
        {
            get { return _Due_date; }
            set { _Due_date = value; }
        }

        /// <summary> 
        /// Gets or sets the Assigned_to_phone value.
        /// </summary>
        public string Assigned_to_phone
        {
            get { return _Assigned_to_phone; }
            set { _Assigned_to_phone = value; }
        }

        /// <summary> 
        /// Gets or sets the Assigned_to_email value.
        /// </summary>
        public string Assigned_to_email
        {
            get { return _Assigned_to_email; }
            set { _Assigned_to_email = value; }
        }

        /// <summary> 
        /// Gets or sets the resolution value.
        /// </summary>
        public Nullable<Decimal> Estimated_Cost
        {
            get { return _Estimated_Cost; }
            set { _Estimated_Cost = value; }
        }

        /// <summary> 
        /// Gets or sets the resolution value.
        /// </summary>
        public Nullable<Decimal> Final_Cost
        {
            get { return _Final_Cost; }
            set { _Final_Cost = value; }
        }

        /// <summary> 
        /// Gets or sets the resolution value.
        /// </summary>
        public string resolution
        {
            get { return _resolution; }
            set { _resolution = value; }
        }

        /// <summary> 
        /// Gets or sets the Date_closed value.
        /// </summary>
        public Nullable<DateTime> Date_closed
        {
            get { return _Date_closed; }
            set { _Date_closed = value; }
        }

        /// <summary> 
        /// Gets or sets the Update_Date value.
        /// </summary>
        public DateTime Update_Date
        {
            get { return _Update_Date; }
            set { _Update_Date = value; }
        }

        /// <summary> 
        /// Gets or sets the Updated_By value.
        /// </summary>
        public string Updated_By
        {
            get { return _Updated_By; }
            set { _Updated_By = value; }
        }

        #endregion

        #region Constructors

        /// <summary> 

        /// Initializes a new instance of the Enviro_Recommendations class. with the default value.

        /// </summary>
        public Enviro_Recommendations()
        {

            this._PK_Enviro_Equipment_Recommendations_ID = -1;
            this._Foreign_Table = "";
            this._Foreign_Key = -1;
            this._Date = null;
            this._Number = "";
            this._Made_by = "";
            this._status = "";
            this._title = "";
            this._description = "";
            this._Assigned_to = "";
            this._Due_date = null;
            this._Assigned_to_phone = "";
            this._Assigned_to_email = "";
            this._Estimated_Cost = null;
            this._Final_Cost = null;
            this._resolution = "";
            this._Date_closed = null;
            this._Updated_By = "";
            this._Update_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
        }



        /// <summary> 

        /// Initializes a new instance of the Enviro_Recommendations class for passed PrimaryKey with the values set from Database.


        /// </summary>
        public Enviro_Recommendations(int PK)
        {
            DataTable dtEnviro_Recommendations = SelectByPK(PK).Tables[0];

            if (dtEnviro_Recommendations.Rows.Count > 0)
            {
                DataRow drEnviro_Recommendations = dtEnviro_Recommendations.Rows[0];

                this._PK_Enviro_Equipment_Recommendations_ID = drEnviro_Recommendations["PK_Enviro_Equipment_Recommendations_ID"] != DBNull.Value ? Convert.ToInt32(drEnviro_Recommendations["PK_Enviro_Equipment_Recommendations_ID"]) : 0;
                this._Foreign_Table = Convert.ToString(drEnviro_Recommendations["Foreign_Table"]);
                this._Foreign_Key = drEnviro_Recommendations["Foreign_Key"] != DBNull.Value ? Convert.ToInt32(drEnviro_Recommendations["Foreign_Key"]) : 0;
                this._Date = clsGeneral.FormatNullDateToStore(drEnviro_Recommendations["Date"].ToString());
                this._Number = Convert.ToString(drEnviro_Recommendations["Number"]);
                this._Made_by = Convert.ToString(drEnviro_Recommendations["Made_by"]);
                this._status = Convert.ToString(drEnviro_Recommendations["status"]);
                this._title = Convert.ToString(drEnviro_Recommendations["title"]);
                this._description = Convert.ToString(drEnviro_Recommendations["description"]);
                this._Assigned_to = Convert.ToString(drEnviro_Recommendations["Assigned_to"]);
                this._Due_date = clsGeneral.FormatNullDateToStore(drEnviro_Recommendations["Due_date"].ToString());
                this._Assigned_to_phone = Convert.ToString(drEnviro_Recommendations["Assigned_to_phone"]);
                this._Assigned_to_email = Convert.ToString(drEnviro_Recommendations["Assigned_to_email"]);
                this._Final_Cost = drEnviro_Recommendations["Final_Cost"] != DBNull.Value ? Convert.ToDecimal(drEnviro_Recommendations["Final_Cost"]) : 0;
                this._Estimated_Cost = drEnviro_Recommendations["Estimated_Cost"] != DBNull.Value ? Convert.ToDecimal(drEnviro_Recommendations["Estimated_Cost"]) : 0; 
                this._resolution = Convert.ToString(drEnviro_Recommendations["resolution"]);
                this._Date_closed = clsGeneral.FormatNullDateToStore(drEnviro_Recommendations["Date_closed"].ToString());
                this._Updated_By = drEnviro_Recommendations["Updated_By"].ToString();
                this._Update_Date = drEnviro_Recommendations["Update_Date"] != DBNull.Value ? Convert.ToDateTime(drEnviro_Recommendations["Update_Date"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            }
            else
            {
                this._PK_Enviro_Equipment_Recommendations_ID = -1;
                this._Foreign_Table = "";
                this._Foreign_Key = -1;
                this._Date = null;
                this._Number = "";
                this._Made_by = "";
                this._status = "";
                this._title = "";
                this._description = "";
                this._Assigned_to = "";
                this._Due_date = null;
                this._Assigned_to_phone = "";
                this._Assigned_to_email = "";
                this._Estimated_Cost = null;
                this._Final_Cost = null;
                this._resolution = "";
                this._Date_closed = null;
                this._Updated_By = "";
                this._Update_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Inserts a record into the Enviro_Recommendations table.
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Enviro_RecommendationsInsert");

            db.AddInParameter(dbCommand, "Foreign_Table", DbType.String, this._Foreign_Table);
            db.AddInParameter(dbCommand, "Foreign_Key", DbType.Int32, this._Foreign_Key);
            db.AddInParameter(dbCommand, "Date", DbType.DateTime, this._Date);
            db.AddInParameter(dbCommand, "Number", DbType.String, this._Number);
            db.AddInParameter(dbCommand, "Made_by", DbType.String, this._Made_by);
            db.AddInParameter(dbCommand, "status", DbType.String, this._status);
            db.AddInParameter(dbCommand, "title", DbType.String, this._title);
            db.AddInParameter(dbCommand, "description", DbType.String, this._description);
            db.AddInParameter(dbCommand, "Assigned_to", DbType.String, this._Assigned_to);
            db.AddInParameter(dbCommand, "Due_date", DbType.DateTime, this._Due_date);
            db.AddInParameter(dbCommand, "Assigned_to_phone", DbType.String, this._Assigned_to_phone);
            db.AddInParameter(dbCommand, "Assigned_to_email", DbType.String, this._Assigned_to_email);
            db.AddInParameter(dbCommand, "Estimated_Cost", DbType.Decimal, this._Estimated_Cost);
            db.AddInParameter(dbCommand, "Final_Cost", DbType.Decimal, this._Final_Cost);
            db.AddInParameter(dbCommand, "resolution", DbType.String, this._resolution);
            db.AddInParameter(dbCommand, "Date_closed", DbType.DateTime, this._Date_closed);
            db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, DateTime.Now);
            db.AddInParameter(dbCommand, "Updated_By", DbType.String, clsSession.UserID);

            // Execute the query and return the new identity value
            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
        }

        /// <summary>
        /// Selects a single record from the Enviro_Recommendations table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectByPK(int pK_Enviro_Equipment_Recommendations_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Enviro_RecommendationsSelectByPK");

            db.AddInParameter(dbCommand, "PK_Enviro_Equipment_Recommendations_ID", DbType.Int32, pK_Enviro_Equipment_Recommendations_ID);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the Enviro_Recommendations table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Enviro_RecommendationsSelectAll");

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Updates a record in the Enviro_Recommendations table.
        /// </summary>
        public void Update()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Enviro_RecommendationsUpdate");

            db.AddInParameter(dbCommand, "PK_Enviro_Equipment_Recommendations_ID", DbType.Int32, this._PK_Enviro_Equipment_Recommendations_ID);
            db.AddInParameter(dbCommand, "Foreign_Table", DbType.String, this._Foreign_Table);
            db.AddInParameter(dbCommand, "Foreign_Key", DbType.Int32, this._Foreign_Key);
            db.AddInParameter(dbCommand, "Date", DbType.DateTime, this._Date);
            db.AddInParameter(dbCommand, "Number", DbType.String, this._Number);
            db.AddInParameter(dbCommand, "Made_by", DbType.String, this._Made_by);
            db.AddInParameter(dbCommand, "status", DbType.String, this._status);
            db.AddInParameter(dbCommand, "title", DbType.String, this._title);
            db.AddInParameter(dbCommand, "description", DbType.String, this._description);
            db.AddInParameter(dbCommand, "Assigned_to", DbType.String, this._Assigned_to);
            db.AddInParameter(dbCommand, "Due_date", DbType.DateTime, this._Due_date);
            db.AddInParameter(dbCommand, "Assigned_to_phone", DbType.String, this._Assigned_to_phone);
            db.AddInParameter(dbCommand, "Assigned_to_email", DbType.String, this._Assigned_to_email);
            db.AddInParameter(dbCommand, "Estimated_Cost", DbType.Decimal, this._Estimated_Cost);
            db.AddInParameter(dbCommand, "Final_Cost", DbType.Decimal, this._Final_Cost);
            db.AddInParameter(dbCommand, "resolution", DbType.String, this._resolution);
            db.AddInParameter(dbCommand, "Date_closed", DbType.DateTime, this._Date_closed);
            db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, DateTime.Now);
            db.AddInParameter(dbCommand, "Updated_By", DbType.String, clsSession.UserID);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Deletes a record from the Enviro_Recommendations table by a composite primary key.
        /// </summary>
        public static void DeleteByPK(int pK_Enviro_Equipment_Recommendations_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Enviro_RecommendationsDeleteByPK");

            db.AddInParameter(dbCommand, "PK_Enviro_Equipment_Recommendations_ID", DbType.Int32, pK_Enviro_Equipment_Recommendations_ID);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Select Records from the Enviro_Recommendations table by Foreign_Table and Foreign_Key
        /// </summary>
        /// <param name="Foreign_TableName"> Table Name</param>
        /// <param name="Foreign_KeyID"> Foreign key</param>
        /// <returns> Dataset </returns>
        public static DataSet SelectByForeignTableKey(string Foreign_TableName, int Foreign_KeyID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Enviro_RecommendationsSelectByForeignTableKey");

            db.AddInParameter(dbCommand, "Foreign_Table", DbType.String, Foreign_TableName);
            db.AddInParameter(dbCommand, "Foreign_Key", DbType.Int32, Foreign_KeyID);

            return db.ExecuteDataSet(dbCommand);
        }
        #endregion
    }
}
