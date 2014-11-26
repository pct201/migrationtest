using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
    /// <summary>
    /// Data access class for Investigation table.
    /// </summary>
    public sealed class Purchasing_SC_Notes
    {
        #region Fields
        private decimal pK_Purchasing_SC_Notes;
        private decimal fK_Purchasing_Service_Contract;
        private DateTime note_Date;
        private string note;
        private string updated_By;
        private DateTime update_Date;
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the PK_Purchasing_SC_Notes value.
        /// </summary>
        public decimal PK_Purchasing_SC_Notes
        {
            get { return pK_Purchasing_SC_Notes; }
            set { pK_Purchasing_SC_Notes = value; }
        }

        /// <summary>
        /// Gets or sets the FK_Purchasing_Service_Contract value.
        /// </summary>
        public decimal FK_Purchasing_Service_Contract
        {
            get { return fK_Purchasing_Service_Contract; }
            set { fK_Purchasing_Service_Contract = value; }
        }

        /// <summary>
        /// Gets or sets the Note_Date value.
        /// </summary>
        public DateTime Note_Date
        {
            get { return note_Date; }
            set { note_Date = value; }
        }

        /// <summary>
        /// Gets or sets the Note value.
        /// </summary>
        public string Note
        {
            get { return note; }
            set { note = value; }
        }

        /// <summary>
        /// Gets or sets the Updated_By value.
        /// </summary>
        public string Updated_By
        {
            get { return updated_By; }
            set { updated_By = value; }
        }

        /// <summary>
        /// Gets or sets the Update_Date value.
        /// </summary>
        public DateTime Update_Date
        {
            get { return update_Date; }
            set { update_Date = value; }
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the Purchasing_SC_Note class.
        /// </summary>
        public Purchasing_SC_Notes()
        {
        }
        #endregion

        #region "Methods"
        /// <summary>
        /// Inserts a record into the Purchasing_SC_Notes table.
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Purchasing_SC_NotesInsert");

            db.AddInParameter(dbCommand, "FK_Purchasing_Service_Contract", DbType.Decimal, this.fK_Purchasing_Service_Contract);
            db.AddInParameter(dbCommand, "Note_Date", DbType.DateTime, this.note_Date);
            db.AddInParameter(dbCommand, "Note", DbType.String, this.note);
            db.AddInParameter(dbCommand, "Updated_By", DbType.String, this.updated_By);
            db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this.update_Date);

            // Execute the query and return the new identity value
            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
        }

        /// <summary>
        /// Selects all records from the Purchasing_SC_Notes table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAllByServiceContract(int _fK_Purchasing_Service_Contract)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Purchasing_SC_NotesSelectAllByServiceContract");

            db.AddInParameter(dbCommand, "FK_Purchasing_Service_Contract", DbType.Decimal, _fK_Purchasing_Service_Contract);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects a single record from the Purchasing_SC_Notes table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectByPK(decimal pK_Purchasing_SC_Notes)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Purchasing_SC_NotesSelectByPK");

            db.AddInParameter(dbCommand, "PK_Purchasing_SC_Notes", DbType.Decimal, pK_Purchasing_SC_Notes);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Updates a record in the Purchasing_SC_Notes table.
        /// </summary>
        public void Update()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Purchasing_SC_NotesUpdate");

            db.AddInParameter(dbCommand, "PK_Purchasing_SC_Notes", DbType.Decimal, pK_Purchasing_SC_Notes);
            db.AddInParameter(dbCommand, "FK_Purchasing_Service_Contract", DbType.Decimal, fK_Purchasing_Service_Contract);
            db.AddInParameter(dbCommand, "Note_Date", DbType.DateTime, note_Date);
            db.AddInParameter(dbCommand, "Note", DbType.String, note);
            db.AddInParameter(dbCommand, "Updated_By", DbType.String, updated_By);
            db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, update_Date);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Deletes a record from the Purchasing_SC_Notes table by a composite primary key.
        /// </summary>
        public static void DeleteByPK(decimal pK_Purchasing_SC_Notes)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Purchasing_SC_NotesDeleteByPK");

            db.AddInParameter(dbCommand, "PK_Purchasing_SC_Notes", DbType.Decimal, pK_Purchasing_SC_Notes);

            db.ExecuteNonQuery(dbCommand);
        }

        #endregion

    }
}
