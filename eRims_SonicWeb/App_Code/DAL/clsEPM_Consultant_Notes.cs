using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for EPM_Consultant_Notes table.
	/// </summary>
	public sealed class clsEPM_Consultant_Notes
	{

		#region Private variables used to hold the property values

		private decimal? _PK_EPM_Consultant_Notes;
		private decimal? _FK_EPM_Consultant;
		private DateTime? _Note_Date;
		private string _Note;
		private string _Updated_By;
		private DateTime? _Update_Date;
		private DateTime? _Created_Date;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_EPM_Consultant_Notes value.
		/// </summary>
		public decimal? PK_EPM_Consultant_Notes
		{
			get { return _PK_EPM_Consultant_Notes; }
			set { _PK_EPM_Consultant_Notes = value; }
		}

		/// <summary>
		/// Gets or sets the FK_EPM_Consultant value.
		/// </summary>
		public decimal? FK_EPM_Consultant
		{
			get { return _FK_EPM_Consultant; }
			set { _FK_EPM_Consultant = value; }
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
		/// Initializes a new instance of the clsEPM_Consultant_Notes class with default value.
		/// </summary>
		public clsEPM_Consultant_Notes() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the clsEPM_Consultant_Notes class based on Primary Key.
		/// </summary>
		public clsEPM_Consultant_Notes(decimal pK_EPM_Consultant_Notes) 
		{
			DataTable dtEPM_Consultant_Notes = SelectByPK(pK_EPM_Consultant_Notes).Tables[0];

			if (dtEPM_Consultant_Notes.Rows.Count == 1)
			{
				 SetValue(dtEPM_Consultant_Notes.Rows[0]);

			}

		}


		/// <summary>
		/// Initializes a new instance of the clsEPM_Consultant_Notes class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drEPM_Consultant_Notes) 
		{
				if (drEPM_Consultant_Notes["PK_EPM_Consultant_Notes"] == DBNull.Value)
					this._PK_EPM_Consultant_Notes = null;
				else
					this._PK_EPM_Consultant_Notes = (decimal?)drEPM_Consultant_Notes["PK_EPM_Consultant_Notes"];

				if (drEPM_Consultant_Notes["FK_EPM_Consultant"] == DBNull.Value)
					this._FK_EPM_Consultant = null;
				else
					this._FK_EPM_Consultant = (decimal?)drEPM_Consultant_Notes["FK_EPM_Consultant"];

				if (drEPM_Consultant_Notes["Note_Date"] == DBNull.Value)
					this._Note_Date = null;
				else
					this._Note_Date = (DateTime?)drEPM_Consultant_Notes["Note_Date"];

				if (drEPM_Consultant_Notes["Note"] == DBNull.Value)
					this._Note = null;
				else
					this._Note = (string)drEPM_Consultant_Notes["Note"];

				if (drEPM_Consultant_Notes["Updated_By"] == DBNull.Value)
					this._Updated_By = null;
				else
					this._Updated_By = (string)drEPM_Consultant_Notes["Updated_By"];

				if (drEPM_Consultant_Notes["Update_Date"] == DBNull.Value)
					this._Update_Date = null;
				else
					this._Update_Date = (DateTime?)drEPM_Consultant_Notes["Update_Date"];

				if (drEPM_Consultant_Notes["Created_Date"] == DBNull.Value)
					this._Created_Date = null;
				else
					this._Created_Date = (DateTime?)drEPM_Consultant_Notes["Created_Date"];


		}

		#endregion

		/// <summary>
		/// Inserts a record into the EPM_Consultant_Notes table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("EPM_Consultant_NotesInsert");

			
			db.AddInParameter(dbCommand, "FK_EPM_Consultant", DbType.Decimal, this._FK_EPM_Consultant);
			
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
			
			db.AddInParameter(dbCommand, "Created_Date", DbType.DateTime, this._Created_Date);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the EPM_Consultant_Notes table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		private DataSet SelectByPK(decimal pK_EPM_Consultant_Notes)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("EPM_Consultant_NotesSelectByPK");

			db.AddInParameter(dbCommand, "PK_EPM_Consultant_Notes", DbType.Decimal, pK_EPM_Consultant_Notes);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the EPM_Consultant_Notes table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("EPM_Consultant_NotesSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the EPM_Consultant_Notes table.
		/// </summary>
		public void Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("EPM_Consultant_NotesUpdate");

			
			db.AddInParameter(dbCommand, "PK_EPM_Consultant_Notes", DbType.Decimal, this._PK_EPM_Consultant_Notes);
			
			db.AddInParameter(dbCommand, "FK_EPM_Consultant", DbType.Decimal, this._FK_EPM_Consultant);
			
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
			
			db.AddInParameter(dbCommand, "Created_Date", DbType.DateTime, this._Created_Date);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the EPM_Consultant_Notes table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_EPM_Consultant_Notes)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("EPM_Consultant_NotesDeleteByPK");

			db.AddInParameter(dbCommand, "PK_EPM_Consultant_Notes", DbType.Decimal, pK_EPM_Consultant_Notes);

			db.ExecuteNonQuery(dbCommand);
		}

        /// <summary>
        /// Selects records from the Claim_Notes table by a foreign key.
        /// </summary>
        /// <param name="pK_Claim_Notes"></param>
        /// <returns>DataSet</returns>
        public static DataSet SelectByIDs(string strIDs)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("EPM_Consultant_NotesSelectByIDs");

            db.AddInParameter(dbCommand, "PK_EPM_Consultant_Notes", DbType.String, strIDs);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects records from the Claim_Notes table by a foreign key.
        /// </summary>
        /// <param name="pK_Claim_Notes"></param>
        /// <returns>DataSet</returns>
        public static DataSet SelectByFK_Table(decimal FK_EPM_Consultant, int intPageNo, int intPageSize)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("EPM_Consultant_NotesSelectByFK_Table");

            db.AddInParameter(dbCommand, "FK_EPM_Consultant", DbType.Decimal, FK_EPM_Consultant);
            db.AddInParameter(dbCommand, "@intPageNo", DbType.String, intPageNo);
            db.AddInParameter(dbCommand, "@intPageSize", DbType.String, intPageSize);

            return db.ExecuteDataSet(dbCommand);
        }
	}
}
