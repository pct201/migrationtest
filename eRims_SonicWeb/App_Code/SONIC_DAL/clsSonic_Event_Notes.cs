using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for Sonic_Event_Notes table.
	/// </summary>
	public sealed class clsSonic_Event_Notes
	{

        #region Private variables used to hold the property values

        private decimal? _PK_Sonic_Event_Notes;
        private decimal? _FK_Event;
        private DateTime? _Note_Date;
        private string _Note;
        private decimal? _Updated_by;

        #endregion

        #region Public Property

        /// <summary>
        /// Gets or sets the PK_Sonic_Event_Notes value.
        /// </summary>
        public decimal? PK_Sonic_Event_Notes
        {
            get { return _PK_Sonic_Event_Notes; }
            set { _PK_Sonic_Event_Notes = value; }
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
        /// Gets or sets the Note_Date value.
        /// </summary>
        public DateTime? Note_Date
        {
            get { return _Note_Date; }
            set { _Note_Date = value; }
        }

        /// <summary>
        /// Gets or sets the Note value.
        /// </summary>
        public string Note
        {
            get { return _Note; }
            set { _Note = value; }
        }

        /// <summary>
        /// Gets or sets the Updated_by value.
        /// </summary>
        public decimal? Updated_by
        {
            get { return _Updated_by; }
            set { _Updated_by = value; }
        }


        #endregion

        #region Default Constructors

        /// <summary>
        /// Initializes a new instance of the clsSonic_Event_Notes class with default value.
        /// </summary>
        public clsSonic_Event_Notes()
        {


        }

        #endregion

        #region Primary Constructors

        /// <summary>
        /// Initializes a new instance of the clsSonic_Event_Notes class based on Primary Key.
        /// </summary>
        public clsSonic_Event_Notes(decimal pK_Sonic_Event_Notes)
        {
            DataTable dtSonic_Event_Notes = SelectByPK(pK_Sonic_Event_Notes).Tables[0];

            if (dtSonic_Event_Notes.Rows.Count == 1)
            {
                SetValue(dtSonic_Event_Notes.Rows[0]);

            }

        }


        /// <summary>
        /// Initializes a new instance of the clsSonic_Event_Notes class based on Datarow passed.
        /// </summary>
        private void SetValue(DataRow drSonic_Event_Notes)
        {
            if (drSonic_Event_Notes["PK_Sonic_Event_Notes"] == DBNull.Value)
                this._PK_Sonic_Event_Notes = null;
            else
                this._PK_Sonic_Event_Notes = (decimal?)drSonic_Event_Notes["PK_Sonic_Event_Notes"];

            if (drSonic_Event_Notes["FK_Event"] == DBNull.Value)
                this._FK_Event = null;
            else
                this._FK_Event = (decimal?)drSonic_Event_Notes["FK_Event"];

            if (drSonic_Event_Notes["Note_Date"] == DBNull.Value)
                this._Note_Date = null;
            else
                this._Note_Date = (DateTime?)drSonic_Event_Notes["Note_Date"];

            if (drSonic_Event_Notes["Note"] == DBNull.Value)
                this._Note = null;
            else
                this._Note = (string)drSonic_Event_Notes["Note"];

            if (drSonic_Event_Notes["Updated_by"] == DBNull.Value)
                this._Updated_by = null;
            else
                this._Updated_by = (decimal?)drSonic_Event_Notes["Updated_by"];


        }

        #endregion

        /// <summary>
        /// Inserts a record into the Sonic_Event_Notes table.
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Sonic_Event_NotesInsert");


            db.AddInParameter(dbCommand, "FK_Event", DbType.Decimal, this._FK_Event);

            db.AddInParameter(dbCommand, "Note_Date", DbType.DateTime, this._Note_Date);

            if (string.IsNullOrEmpty(this._Note))
                db.AddInParameter(dbCommand, "Note", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Note", DbType.String, this._Note);

            db.AddInParameter(dbCommand, "Updated_by", DbType.Decimal, this._Updated_by);

            // Execute the query and return the new identity value
            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
        }

        /// <summary>
        /// Selects a single record from the Sonic_Event_Notes table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        private DataSet SelectByPK(decimal pK_Sonic_Event_Notes)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Sonic_Event_NotesSelectByPK");

            db.AddInParameter(dbCommand, "PK_Sonic_Event_Notes", DbType.Decimal, pK_Sonic_Event_Notes);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the Sonic_Event_Notes table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Sonic_Event_NotesSelectAll");

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Updates a record in the Sonic_Event_Notes table.
        /// </summary>
        public void Update()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Sonic_Event_NotesUpdate");


            db.AddInParameter(dbCommand, "PK_Sonic_Event_Notes", DbType.Decimal, this._PK_Sonic_Event_Notes);

            db.AddInParameter(dbCommand, "FK_Event", DbType.Decimal, this._FK_Event);

            db.AddInParameter(dbCommand, "Note_Date", DbType.DateTime, this._Note_Date);

            if (string.IsNullOrEmpty(this._Note))
                db.AddInParameter(dbCommand, "Note", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Note", DbType.String, this._Note);

            db.AddInParameter(dbCommand, "Updated_by", DbType.Decimal, this._Updated_by);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Deletes a record from the Sonic_Event_Notes table by a composite primary key.
        /// </summary>
        public static void DeleteByPK(decimal pK_Sonic_Event_Notes)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Sonic_Event_NotesDeleteByPK");

            db.AddInParameter(dbCommand, "PK_Sonic_Event_Notes", DbType.Decimal, pK_Sonic_Event_Notes);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Selects record from the Sonic_Event_Notes table by FK_Event.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectByFK_Event(decimal FK_Event)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Sonic_Event_NotesSelectByFK_Event");

            db.AddInParameter(dbCommand, "FK_Event", DbType.Decimal, FK_Event);

            return db.ExecuteDataSet(dbCommand);
        }
    }
}
