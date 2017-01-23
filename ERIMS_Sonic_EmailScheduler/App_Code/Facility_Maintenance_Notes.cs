using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Collections.Generic;

namespace ERIMS_Sonic_EmailScheduler
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

        /// <summary>
        /// Gets or sets the UserName value.
        /// </summary>
        public string AuthorName { get; set; }

        /// <summary>
        ///  Get Number of Records in Grid
        /// </summary>
        public Int32? TotalRecord { get; set; }

        /// <summary>
        /// Get No of Pages in Grid
        /// </summary>
        public System.Decimal? Pages { get; set; }

        #endregion

        #region Default Constructors

        /// <summary>
        /// Initializes a new instance of the Facility_Maintenance_Notes class with default value.
        /// </summary>
        public Facility_Maintenance_Notes()
        {


        }

        #endregion

        /// <summary>
        /// Inserts a record into the Facility_Maintenance_Notes table.
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("EmailReader_Facility_Maintenance_NotesInsert");

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

    }
}
