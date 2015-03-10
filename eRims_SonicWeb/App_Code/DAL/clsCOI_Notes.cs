using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for COI_Notes table.
	/// </summary>
	public sealed class clsCOI_Notes
	{

		#region Private variables used to hold the property values

		private decimal? _PK_COI_Notes;
		private decimal? _FK_COIs;
		private DateTime? _Note_Date;
		private string _Note;
		private DateTime? _Update_Date;
		private string _Updated_By;
		private DateTime? _Created_Date;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_COI_Notes value.
		/// </summary>
		public decimal? PK_COI_Notes
		{
			get { return _PK_COI_Notes; }
			set { _PK_COI_Notes = value; }
		}

		/// <summary>
		/// Gets or sets the FK_COIs value.
		/// </summary>
		public decimal? FK_COIs
		{
			get { return _FK_COIs; }
			set { _FK_COIs = value; }
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
		/// Gets or sets the Update_Date value.
		/// </summary>
		public DateTime? Update_Date
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

		/// <summary>
		/// Gets or sets the Created_Date value.
		/// </summary>
		public DateTime? Created_Date
		{
			get { return _Created_Date; }
			set { _Created_Date = value; }
		}


		#endregion

		#region Default Constructors

		/// <summary>
		/// Initializes a new instance of the clsCOI_Notes class with default value.
		/// </summary>
		public clsCOI_Notes() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the clsCOI_Notes class based on Primary Key.
		/// </summary>
		public clsCOI_Notes(decimal pK_COI_Notes) 
		{
			DataTable dtCOI_Notes = SelectByPK(pK_COI_Notes).Tables[0];

			if (dtCOI_Notes.Rows.Count == 1)
			{
				 SetValue(dtCOI_Notes.Rows[0]);

			}

		}


		/// <summary>
		/// Initializes a new instance of the clsCOI_Notes class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drCOI_Notes) 
		{
				if (drCOI_Notes["PK_COI_Notes"] == DBNull.Value)
					this._PK_COI_Notes = null;
				else
					this._PK_COI_Notes = (decimal?)drCOI_Notes["PK_COI_Notes"];

				if (drCOI_Notes["FK_COIs"] == DBNull.Value)
					this._FK_COIs = null;
				else
					this._FK_COIs = (decimal?)drCOI_Notes["FK_COIs"];

				if (drCOI_Notes["Note_Date"] == DBNull.Value)
					this._Note_Date = null;
				else
					this._Note_Date = (DateTime?)drCOI_Notes["Note_Date"];

				if (drCOI_Notes["Note"] == DBNull.Value)
					this._Note = null;
				else
					this._Note = (string)drCOI_Notes["Note"];

				if (drCOI_Notes["Update_Date"] == DBNull.Value)
					this._Update_Date = null;
				else
					this._Update_Date = (DateTime?)drCOI_Notes["Update_Date"];

				if (drCOI_Notes["Updated_By"] == DBNull.Value)
					this._Updated_By = null;
				else
					this._Updated_By = (string)drCOI_Notes["Updated_By"];

				if (drCOI_Notes["Created_Date"] == DBNull.Value)
					this._Created_Date = null;
				else
					this._Created_Date = (DateTime?)drCOI_Notes["Created_Date"];


		}

		#endregion

		/// <summary>
		/// Inserts a record into the COI_Notes table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("COI_NotesInsert");

			
			db.AddInParameter(dbCommand, "FK_COIs", DbType.Decimal, this._FK_COIs);
			
			db.AddInParameter(dbCommand, "Note_Date", DbType.DateTime, this._Note_Date);
			
			if (string.IsNullOrEmpty(this._Note))
				db.AddInParameter(dbCommand, "Note", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Note", DbType.String, this._Note);
			
			db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);
			
			if (string.IsNullOrEmpty(this._Updated_By))
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);
			
			db.AddInParameter(dbCommand, "Created_Date", DbType.DateTime, this._Created_Date);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the COI_Notes table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		private DataSet SelectByPK(decimal pK_COI_Notes)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("COI_NotesSelectByPK");

			db.AddInParameter(dbCommand, "PK_COI_Notes", DbType.Decimal, pK_COI_Notes);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the COI_Notes table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("COI_NotesSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the COI_Notes table.
		/// </summary>
		public void Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("COI_NotesUpdate");

			
			db.AddInParameter(dbCommand, "PK_COI_Notes", DbType.Decimal, this._PK_COI_Notes);
			
			db.AddInParameter(dbCommand, "FK_COIs", DbType.Decimal, this._FK_COIs);
			
			db.AddInParameter(dbCommand, "Note_Date", DbType.DateTime, this._Note_Date);
			
			if (string.IsNullOrEmpty(this._Note))
				db.AddInParameter(dbCommand, "Note", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Note", DbType.String, this._Note);
			
			db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);
			
			if (string.IsNullOrEmpty(this._Updated_By))
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);
			
			db.AddInParameter(dbCommand, "Created_Date", DbType.DateTime, this._Created_Date);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the COI_Notes table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_COI_Notes)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("COI_NotesDeleteByPK");

			db.AddInParameter(dbCommand, "PK_COI_Notes", DbType.Decimal, pK_COI_Notes);

			db.ExecuteNonQuery(dbCommand);
		}

        /// <summary>
        /// Selects records from the Claim_Notes table by a foreign key.
        /// </summary>
        /// <param name="pK_Claim_Notes"></param>
        /// <returns>DataSet</returns>
        public static DataSet SelectByFK_Table(decimal FK_COIs, int intPageNo, int intPageSize)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("COI_NotesSelectByFK_Table");

            db.AddInParameter(dbCommand, "FK_COIs", DbType.Decimal, FK_COIs);
            db.AddInParameter(dbCommand, "@intPageNo", DbType.String, intPageNo);
            db.AddInParameter(dbCommand, "@intPageSize", DbType.String, intPageSize);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects records from the Claim_Notes table by a foreign key.
        /// </summary>
        /// <param name="pK_Claim_Notes"></param>
        /// <returns>DataSet</returns>
        public static DataSet SelectByCOI(decimal FK_Claim)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("COI_NotesSelectByCOIClaim");

            db.AddInParameter(dbCommand, "FK_COIs", DbType.Decimal, FK_Claim);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects records from the Claim_Notes table by a foreign key.
        /// </summary>
        /// <param name="pK_Claim_Notes"></param>
        /// <returns>DataSet</returns>
        public static DataSet SelectCOIByPK(decimal FK_COIs)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("COIByPK");

            db.AddInParameter(dbCommand, "PK_COIs", DbType.Decimal, FK_COIs);

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
            DbCommand dbCommand = db.GetStoredProcCommand("COI_NotesSelectByIDs");

            db.AddInParameter(dbCommand, "PK_COI_Notes", DbType.String, strIDs);

            return db.ExecuteDataSet(dbCommand);
        }
	}
}
