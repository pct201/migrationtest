using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
    /// <summary>
    /// Data access class for Claim_Notes table.
    /// </summary>
    public sealed class Claim_Notes
    {

        #region Private variables used to hold the property values

        private decimal? _PK_Claim_Notes;
        private decimal? _FK_Table;
        private string _FK_Table_Name;
        private DateTime? _Note_Date;
        private string _Note;
        private string _Updated_By;
        private DateTime? _Update_Date;

        #endregion

        #region Public Property

        /// <summary>
        /// Gets or sets the PK_Claim_Notes value.
        /// </summary>
        public decimal? PK_Claim_Notes
        {
            get { return _PK_Claim_Notes; }
            set { _PK_Claim_Notes = value; }
        }

        /// <summary>
        /// Gets or sets the FK_Table value.
        /// </summary>
        public decimal? FK_Table
        {
            get { return _FK_Table; }
            set { _FK_Table = value; }
        }

        /// <summary>
        /// Gets or sets the FK_Table_Name value.
        /// </summary>
        public string FK_Table_Name
        {
            get { return _FK_Table_Name; }
            set { _FK_Table_Name = value; }
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
        /// Initializes a new instance of the Claim_Notes class with default value.
        /// </summary>
        public Claim_Notes()
        {

            this._PK_Claim_Notes = null;
            this._FK_Table = null;
            this._FK_Table_Name = null;
            this._Note_Date = null;
            this._Note = null;
            this._Updated_By = null;
            this._Update_Date = null;

        }

        #endregion

        #region Primary Constructors

        /// <summary>
        /// Initializes a new instance of the Claim_Notes class based on Primary Key.
        /// </summary>
        public Claim_Notes(decimal pK_Claim_Notes)
        {
            DataTable dtClaim_Notes = SelectByPK(pK_Claim_Notes).Tables[0];

            if (dtClaim_Notes.Rows.Count == 1)
            {
                DataRow drClaim_Notes = dtClaim_Notes.Rows[0];
                if (drClaim_Notes["PK_Claim_Notes"] == DBNull.Value)
                    this._PK_Claim_Notes = null;
                else
                    this._PK_Claim_Notes = (decimal?)drClaim_Notes["PK_Claim_Notes"];

                if (drClaim_Notes["FK_Table"] == DBNull.Value)
                    this._FK_Table = null;
                else
                    this._FK_Table = (decimal?)drClaim_Notes["FK_Table"];

                if (drClaim_Notes["FK_Table_Name"] == DBNull.Value)
                    this._FK_Table_Name = null;
                else
                    this._FK_Table_Name = (string)drClaim_Notes["FK_Table_Name"];

                if (drClaim_Notes["Note_Date"] == DBNull.Value)
                    this._Note_Date = null;
                else
                    this._Note_Date = (DateTime?)drClaim_Notes["Note_Date"];

                if (drClaim_Notes["Note"] == DBNull.Value)
                    this._Note = null;
                else
                    this._Note = (string)drClaim_Notes["Note"];

                if (drClaim_Notes["Updated_By"] == DBNull.Value)
                    this._Updated_By = null;
                else
                    this._Updated_By = (string)drClaim_Notes["Updated_By"];

                if (drClaim_Notes["Update_Date"] == DBNull.Value)
                    this._Update_Date = null;
                else
                    this._Update_Date = (DateTime?)drClaim_Notes["Update_Date"];

            }
            else
            {
                this._PK_Claim_Notes = null;
                this._FK_Table = null;
                this._FK_Table_Name = null;
                this._Note_Date = null;
                this._Note = null;
                this._Updated_By = null;
                this._Update_Date = null;
            }

        }

        #endregion

        /// <summary>
        /// Inserts a record into the Claim_Notes table.
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Claim_NotesInsert");


            db.AddInParameter(dbCommand, "FK_Table", DbType.Decimal, this._FK_Table);

            if (string.IsNullOrEmpty(this._FK_Table_Name))
                db.AddInParameter(dbCommand, "FK_Table_Name", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "FK_Table_Name", DbType.String, this._FK_Table_Name);

            db.AddInParameter(dbCommand, "Note_Date", DbType.DateTime, this._Note_Date);

            if (string.IsNullOrEmpty(this._Note))
                db.AddInParameter(dbCommand, "Note", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Note", DbType.String, this._Note);

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
        /// Selects a single record from the Claim_Notes table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        private static DataSet SelectByPK(decimal pK_Claim_Notes)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Claim_NotesSelectByPK");

            db.AddInParameter(dbCommand, "PK_Claim_Notes", DbType.Decimal, pK_Claim_Notes);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects records from the Claim_Notes table by a foreign key.
        /// </summary>
        /// <param name="pK_Claim_Notes"></param>
        /// <returns>DataSet</returns>
        public static DataSet SelectByFK_Table(decimal FK_Table, string FK_Table_Name, int intPageNo, int intPageSize)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Claim_NotesSelectByFK_Table");

            db.AddInParameter(dbCommand, "FK_Table", DbType.Decimal, FK_Table);
            db.AddInParameter(dbCommand, "FK_Table_Name", DbType.String, FK_Table_Name);
            db.AddInParameter(dbCommand, "@intPageNo", DbType.String, intPageNo);
            db.AddInParameter(dbCommand, "@intPageSize", DbType.String, intPageSize);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects records from the Claim_Notes table by a foreign key.
        /// </summary>
        /// <param name="pK_Claim_Notes"></param>
        /// <returns>DataSet</returns>
        public static DataSet SelectByIDs(string strIDs)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Claim_NotesSelectByIDs");

            db.AddInParameter(dbCommand, "PK_Claim_Notes", DbType.String, strIDs);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Updates a record in the Claim_Notes table.
        /// </summary>
        public void Update()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Claim_NotesUpdate");


            db.AddInParameter(dbCommand, "PK_Claim_Notes", DbType.Decimal, this._PK_Claim_Notes);

            db.AddInParameter(dbCommand, "FK_Table", DbType.Decimal, this._FK_Table);

            if (string.IsNullOrEmpty(this._FK_Table_Name))
                db.AddInParameter(dbCommand, "FK_Table_Name", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "FK_Table_Name", DbType.String, this._FK_Table_Name);

            db.AddInParameter(dbCommand, "Note_Date", DbType.DateTime, this._Note_Date);

            if (string.IsNullOrEmpty(this._Note))
                db.AddInParameter(dbCommand, "Note", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Note", DbType.String, this._Note);

            if (string.IsNullOrEmpty(this._Updated_By))
                db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);

            db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Deletes a record from the Claim_Notes table by a composite primary key.
        /// </summary>
        public static void DeleteByPK(decimal pK_Claim_Notes)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Claim_NotesDeleteByPK");

            db.AddInParameter(dbCommand, "PK_Claim_Notes", DbType.Decimal, pK_Claim_Notes);

            db.ExecuteNonQuery(dbCommand);
        }
    }
}
