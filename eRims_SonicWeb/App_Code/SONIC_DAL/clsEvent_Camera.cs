using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
    /// <summary>
    /// Data access class for Event_Camera table.
    /// </summary>
    public sealed class clsEvent_Camera
    {

        #region Private variables used to hold the property values

        private decimal? _PK_Event_Camera;
        private decimal? _FK_Event;
        private string _Camera_Name;
        private string _Camera_Number;
        private string _Event_Time_From;
        private string _Event_Time_To;

        #endregion

        #region Public Property

        /// <summary>
        /// Gets or sets the PK_Event_Camera value.
        /// </summary>
        public decimal? PK_Event_Camera
        {
            get { return _PK_Event_Camera; }
            set { _PK_Event_Camera = value; }
        }

        /// <summary>
        /// Gets or sets the FK_Event value.
        /// </summary>
        public decimal? FK_Event
        {
            get { return _FK_Event; }
            set { _FK_Event = value; }
        }

        /// <summary>
        /// Gets or sets the Camera_Name value.
        /// </summary>
        public string Camera_Name
        {
            get { return _Camera_Name; }
            set { _Camera_Name = value; }
        }

        /// <summary>
        /// Gets or sets the Camera_Number value.
        /// </summary>
        public string Camera_Number
        {
            get { return _Camera_Number; }
            set { _Camera_Number = value; }
        }

        /// <summary>
        /// Gets or sets the Event_Time_From value.
        /// </summary>
        public string Event_Time_From
        {
            get { return _Event_Time_From; }
            set { _Event_Time_From = value; }
        }

        /// <summary>
        /// Gets or sets the Event_Time_To value.
        /// </summary>
        public string Event_Time_To
        {
            get { return _Event_Time_To; }
            set { _Event_Time_To = value; }
        }


        #endregion

        #region Default Constructors

        /// <summary>
        /// Initializes a new instance of the clsEvent_Camera class with default value.
        /// </summary>
        public clsEvent_Camera()
        {


        }

        #endregion

        #region Primary Constructors

        /// <summary>
        /// Initializes a new instance of the clsEvent_Camera class based on Primary Key.
        /// </summary>
        public clsEvent_Camera(decimal pK_Event_Camera)
        {
            DataTable dtEvent_Camera = SelectByPK(pK_Event_Camera).Tables[0];

            if (dtEvent_Camera.Rows.Count == 1)
            {
                SetValue(dtEvent_Camera.Rows[0]);

            }

        }


        /// <summary>
        /// Initializes a new instance of the clsEvent_Camera class based on Datarow passed.
        /// </summary>
        private void SetValue(DataRow drEvent_Camera)
        {
            if (drEvent_Camera["PK_Event_Camera"] == DBNull.Value)
                this._PK_Event_Camera = null;
            else
                this._PK_Event_Camera = (decimal?)drEvent_Camera["PK_Event_Camera"];

            if (drEvent_Camera["FK_Event"] == DBNull.Value)
                this._FK_Event = null;
            else
                this._FK_Event = (decimal?)drEvent_Camera["FK_Event"];

            if (drEvent_Camera["Camera_Name"] == DBNull.Value)
                this._Camera_Name = null;
            else
                this._Camera_Name = (string)drEvent_Camera["Camera_Name"];

            if (drEvent_Camera["Camera_Number"] == DBNull.Value)
                this._Camera_Number = null;
            else
                this._Camera_Number = (string)drEvent_Camera["Camera_Number"];

            if (drEvent_Camera["Event_Time_From"] == DBNull.Value)
                this._Event_Time_From = null;
            else
                this._Event_Time_From = (string)drEvent_Camera["Event_Time_From"];

            if (drEvent_Camera["Event_Time_To"] == DBNull.Value)
                this._Event_Time_To = null;
            else
                this._Event_Time_To = (string)drEvent_Camera["Event_Time_To"];


        }

        #endregion

        /// <summary>
        /// Inserts a record into the Event_Camera table.
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Event_CameraInsert");


            db.AddInParameter(dbCommand, "FK_Event", DbType.Decimal, this._FK_Event);

            if (string.IsNullOrEmpty(this._Camera_Name))
                db.AddInParameter(dbCommand, "Camera_Name", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Camera_Name", DbType.String, this._Camera_Name);

            if (string.IsNullOrEmpty(this._Camera_Number))
                db.AddInParameter(dbCommand, "Camera_Number", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Camera_Number", DbType.String, this._Camera_Number);

            if (string.IsNullOrEmpty(this._Event_Time_From))
                db.AddInParameter(dbCommand, "Event_Time_From", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Event_Time_From", DbType.String, this._Event_Time_From);

            if (string.IsNullOrEmpty(this._Event_Time_To))
                db.AddInParameter(dbCommand, "Event_Time_To", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Event_Time_To", DbType.String, this._Event_Time_To);

            dbCommand.CommandTimeout = 50000;
            // Execute the query and return the new identity value
            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
        }

        /// <summary>
        /// Selects a single record from the Event_Camera table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        private DataSet SelectByPK(decimal pK_Event_Camera)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Event_CameraSelectByPK");

            db.AddInParameter(dbCommand, "PK_Event_Camera", DbType.Decimal, pK_Event_Camera);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the Event_Camera table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Event_CameraSelectAll");

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Updates a record in the Event_Camera table.
        /// </summary>
        public void Update()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Event_CameraUpdate");


            db.AddInParameter(dbCommand, "PK_Event_Camera", DbType.Decimal, this._PK_Event_Camera);

            db.AddInParameter(dbCommand, "FK_Event", DbType.Decimal, this._FK_Event);

            if (string.IsNullOrEmpty(this._Camera_Name))
                db.AddInParameter(dbCommand, "Camera_Name", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Camera_Name", DbType.String, this._Camera_Name);

            if (string.IsNullOrEmpty(this._Camera_Number))
                db.AddInParameter(dbCommand, "Camera_Number", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Camera_Number", DbType.String, this._Camera_Number);

            if (string.IsNullOrEmpty(this._Event_Time_From))
                db.AddInParameter(dbCommand, "Event_Time_From", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Event_Time_From", DbType.String, this._Event_Time_From);

            if (string.IsNullOrEmpty(this._Event_Time_To))
                db.AddInParameter(dbCommand, "Event_Time_To", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Event_Time_To", DbType.String, this._Event_Time_To);

            dbCommand.CommandTimeout = 50000;
            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Deletes a record from the Event_Camera table by a composite primary key.
        /// </summary>
        public static void DeleteByPK(decimal pK_Event_Camera)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Event_CameraDeleteByPK");

            db.AddInParameter(dbCommand, "PK_Event_Camera", DbType.Decimal, pK_Event_Camera);

            dbCommand.CommandTimeout = 50000;
            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Selects a single record from the Event_Camera table by FK_Event.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectByFK_Event(decimal FK_Event)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Event_CameraSelectByFK_Event");

            db.AddInParameter(dbCommand, "FK_Event", DbType.Decimal, FK_Event);

            return db.ExecuteDataSet(dbCommand);
        }
    }
}
