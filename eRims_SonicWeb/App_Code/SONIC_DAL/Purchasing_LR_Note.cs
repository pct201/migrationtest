using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
    /// <summary>
    /// Data access class for Investigation table.
    /// </summary>
    public sealed class Purchasing_LR_Note
    {
       #region Fields
		private decimal pK_Purchasing_LR_Notes;
        private decimal fK_Purchasing_LR_Agreement;
		private DateTime note_Date;
		private string note;
		private string updated_By;
		private DateTime update_Date;
		#endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the Purchasing_SC_Asset class.
        /// </summary>
        public Purchasing_LR_Note()
        {
        }

        #endregion

        #region Properties
		/// <summary>
		/// Gets or sets the PK_Purchasing_LR_Notes value.
		/// </summary>
		public decimal PK_Purchasing_LR_Notes {
			get { return pK_Purchasing_LR_Notes; }
			set { pK_Purchasing_LR_Notes = value; }
		}
		
		/// <summary>
		/// Gets or sets the FK_Purchasing_Service_Contract value.
		/// </summary>
        public decimal FK_Purchasing_LR_Agreement
        {
            get { return fK_Purchasing_LR_Agreement; }
            set { fK_Purchasing_LR_Agreement = value; }
		}
		
		/// <summary>
		/// Gets or sets the Note_Date value.
		/// </summary>
		public DateTime Note_Date {
			get { return note_Date; }
			set { note_Date = value; }
		}
		
		/// <summary>
		/// Gets or sets the Note value.
		/// </summary>
		public string Note {
			get { return note; }
			set { note = value; }
		}
		
		/// <summary>
		/// Gets or sets the Updated_By value.
		/// </summary>
		public string Updated_By {
			get { return updated_By; }
			set { updated_By = value; }
		}
		
		/// <summary>
		/// Gets or sets the Update_Date value.
		/// </summary>
		public DateTime Update_Date {
			get { return update_Date; }
			set { update_Date = value; }
		}
		#endregion

        #region "Method"

        /// <summary>
        /// Inserts a record into the Purchasing_LR_Notes table.
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Purchasing_LR_NotesInsert");

            db.AddInParameter(dbCommand, "fK_Purchasing_LR_Agreement", DbType.Decimal, fK_Purchasing_LR_Agreement);
            db.AddInParameter(dbCommand, "Note_Date", DbType.DateTime, note_Date);
            db.AddInParameter(dbCommand, "Note", DbType.String, note);
            db.AddInParameter(dbCommand, "Updated_By", DbType.String, updated_By);
            db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime,update_Date);

            // Execute the query and return the new identity value
            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
        }

        /// <summary>
        /// Updates a record in the Purchasing_LR_Notes table.
        /// </summary>
        public void Update()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Purchasing_LR_NotesUpdate");

            db.AddInParameter(dbCommand, "PK_Purchasing_LR_Notes", DbType.Decimal, pK_Purchasing_LR_Notes);
            db.AddInParameter(dbCommand, "fK_Purchasing_LR_Agreement", DbType.Decimal, fK_Purchasing_LR_Agreement);
            db.AddInParameter(dbCommand, "Note_Date", DbType.DateTime, this.note_Date);
            db.AddInParameter(dbCommand, "Note", DbType.String, this.note);
            db.AddInParameter(dbCommand, "Updated_By", DbType.String, this.updated_By);
            db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this.update_Date);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Selects a single record from the Purchasing_SC_Asset table by a foriegn key.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectByFK_LR(decimal _fK_Purchasing_LR_Agreement)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Purchasing_LR_NoteSelectByFK_LR");

            db.AddInParameter(dbCommand, "FK_Purchasing_LR_Agreement", DbType.Decimal, _fK_Purchasing_LR_Agreement);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects a single record from the Purchasing_LR_Notes table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectByPK(decimal pK_Purchasing_LR_Notes)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Purchasing_LR_NotesSelectByPK");

            db.AddInParameter(dbCommand, "PK_Purchasing_LR_Notes", DbType.Decimal, pK_Purchasing_LR_Notes);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Deletes a record from the Purchasing_LR_Notes table by a composite primary key.
        /// </summary>
        public static void DeleteByPK(decimal pK_Purchasing_LR_Notes)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Purchasing_LR_NotesDeleteByPK");

            db.AddInParameter(dbCommand, "PK_Purchasing_LR_Notes", DbType.Decimal, pK_Purchasing_LR_Notes);

            db.ExecuteNonQuery(dbCommand);
        }

        #endregion
    }
}
