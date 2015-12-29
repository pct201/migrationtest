using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
    /// <summary>
    /// Data access class for table Facility_Maintenance_Notes
    /// </summary>
    public sealed class Facility_Maintenance_Notes
    {

        #region Private variables used to hold the property values

        private decimal? _PK_Facility_Maintenance_Notes;
        private decimal? _FK_Facility_Maintenance_Item;
        private decimal? _FK_Author;
        private string _Author_Table;
        private string _Note;
        private DateTime? _Note_Date;

        #endregion

        #region Public Property

        /// <summary>
        /// Gets or sets the PK_Facility_Maintenance_Notes value.
        /// </summary>
        public decimal? PK_Facility_Maintenance_Notes
        {
            get { return _PK_Facility_Maintenance_Notes; }
            set { _PK_Facility_Maintenance_Notes = value; }
        }

        /// <summary>
        /// Gets or sets the FK_Facility_Maintenance_Item value.
        /// </summary>
        public decimal? FK_Facility_Maintenance_Item
        {
            get { return _FK_Facility_Maintenance_Item; }
            set { _FK_Facility_Maintenance_Item = value; }
        }

        /// <summary>
        /// Gets or sets the FK_Author value.
        /// </summary>
        public decimal? FK_Author
        {
            get { return _FK_Author; }
            set { _FK_Author = value; }
        }

        /// <summary>
        /// Gets or sets the Author_Table value.
        /// </summary>
        public string Author_Table
        {
            get { return _Author_Table; }
            set { _Author_Table = value; }
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
        /// Gets or sets the Note_Date value.
        /// </summary>
        public DateTime? Note_Date
        {
            get { return _Note_Date; }
            set { _Note_Date = value; }
        }


        #endregion

        #region Default Constructors

        /// <summary>
        /// Initializes a new instance of the Facility_Maintenance_Notes class with default value.
        /// </summary>
        public Facility_Maintenance_Notes()
        {


        }

        #endregion

        #region Primary Constructors

        /// <summary>
        /// Initializes a new instance of the Facility_Maintenance_Notes class based on Primary Key.
        /// </summary>
        public Facility_Maintenance_Notes(decimal pK_Facility_Maintenance_Notes)
        {
            DataTable dtFacility_Maintenance_Notes = Select(pK_Facility_Maintenance_Notes).Tables[0];

            if (dtFacility_Maintenance_Notes.Rows.Count == 1)
            {
                SetValue(dtFacility_Maintenance_Notes.Rows[0]);

            }

        }


        /// <summary>
        /// Initializes a new instance of the Facility_Maintenance_Notes class based on Datarow passed.
        /// </summary>
        private void SetValue(DataRow drFacility_Maintenance_Notes)
        {
            if (drFacility_Maintenance_Notes["PK_Facility_Maintenance_Notes"] == DBNull.Value)
                this._PK_Facility_Maintenance_Notes = null;
            else
                this._PK_Facility_Maintenance_Notes = (decimal?)drFacility_Maintenance_Notes["PK_Facility_Maintenance_Notes"];

            if (drFacility_Maintenance_Notes["FK_Facility_Maintenance_Item"] == DBNull.Value)
                this._FK_Facility_Maintenance_Item = null;
            else
                this._FK_Facility_Maintenance_Item = (decimal?)drFacility_Maintenance_Notes["FK_Facility_Maintenance_Item"];

            if (drFacility_Maintenance_Notes["FK_Author"] == DBNull.Value)
                this._FK_Author = null;
            else
                this._FK_Author = (decimal?)drFacility_Maintenance_Notes["FK_Author"];

            if (drFacility_Maintenance_Notes["Author_Table"] == DBNull.Value)
                this._Author_Table = null;
            else
                this._Author_Table = (string)drFacility_Maintenance_Notes["Author_Table"];

            if (drFacility_Maintenance_Notes["Note"] == DBNull.Value)
                this._Note = null;
            else
                this._Note = (string)drFacility_Maintenance_Notes["Note"];

            if (drFacility_Maintenance_Notes["Note_Date"] == DBNull.Value)
                this._Note_Date = null;
            else
                this._Note_Date = (DateTime?)drFacility_Maintenance_Notes["Note_Date"];


        }

        #endregion

        /// <summary>
        /// Inserts a record into the Facility_Maintenance_Notes table.
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Facility_Maintenance_NotesInsert");


            db.AddInParameter(dbCommand, "FK_Facility_Maintenance_Item", DbType.Decimal, this._FK_Facility_Maintenance_Item);

            db.AddInParameter(dbCommand, "FK_Author", DbType.Decimal, this._FK_Author);

            if (string.IsNullOrEmpty(this._Author_Table))
                db.AddInParameter(dbCommand, "Author_Table", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Author_Table", DbType.String, this._Author_Table);

            if (string.IsNullOrEmpty(this._Note))
                db.AddInParameter(dbCommand, "Note", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Note", DbType.String, this._Note);

            db.AddInParameter(dbCommand, "Note_Date", DbType.DateTime, this._Note_Date);

            // Execute the query and return the new identity value
            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
        }

        /// <summary>
        /// Selects a single record from the Facility_Maintenance_Notes table.
        /// </summary>
        /// <returns>DataSet</returns>
        private DataSet Select(decimal pK_Facility_Maintenance_Notes)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Facility_Maintenance_NotesSelect");

            db.AddInParameter(dbCommand, "PK_Facility_Maintenance_Notes", DbType.Decimal, pK_Facility_Maintenance_Notes);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the Facility_Maintenance_Notes table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Facility_Maintenance_NotesSelectAll");

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Updates a record in the Facility_Maintenance_Notes table.
        /// </summary>
        public void Update()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Facility_Maintenance_NotesUpdate");


            db.AddInParameter(dbCommand, "PK_Facility_Maintenance_Notes", DbType.Decimal, this._PK_Facility_Maintenance_Notes);

            db.AddInParameter(dbCommand, "FK_Facility_Maintenance_Item", DbType.Decimal, this._FK_Facility_Maintenance_Item);

            db.AddInParameter(dbCommand, "FK_Author", DbType.Decimal, this._FK_Author);

            if (string.IsNullOrEmpty(this._Author_Table))
                db.AddInParameter(dbCommand, "Author_Table", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Author_Table", DbType.String, this._Author_Table);

            if (string.IsNullOrEmpty(this._Note))
                db.AddInParameter(dbCommand, "Note", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Note", DbType.String, this._Note);

            db.AddInParameter(dbCommand, "Note_Date", DbType.DateTime, this._Note_Date);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Deletes a record from the Facility_Maintenance_Notes table by a composite primary key.
        /// </summary>
        public static void Delete(decimal pK_Facility_Maintenance_Notes)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Facility_Maintenance_NotesDelete");

            db.AddInParameter(dbCommand, "PK_Facility_Maintenance_Notes", DbType.Decimal, pK_Facility_Maintenance_Notes);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Selects a single record from the Facility_Maintenance_Notes table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectByFK_Table(decimal fK_Facility_Maintenance_Item, int intPageNo, int intPageSize)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Facility_Maintenance_NotesSelectByFK_Table");

            db.AddInParameter(dbCommand, "FK_Facility_Maintenance_Item", DbType.Decimal, fK_Facility_Maintenance_Item);
            db.AddInParameter(dbCommand, "intPageNo", DbType.Int32, intPageNo);
            db.AddInParameter(dbCommand, "intPageSize", DbType.Int32, intPageSize);

            return db.ExecuteDataSet(dbCommand);
        }
    }
}
