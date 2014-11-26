using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for RE_Notes table.
	/// </summary>
	public sealed class RE_Notes
	{

		#region Private variables used to hold the property values

		private decimal? _PK_RE_Notes;
		private decimal? _FK_RE_Information;
		private DateTime? _Note_Date;
		private string _Notes;
		private string _Updated_By;
		private DateTime? _Update_Date;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_RE_Notes value.
		/// </summary>
		public decimal? PK_RE_Notes
		{
			get { return _PK_RE_Notes; }
			set { _PK_RE_Notes = value; }
		}

		/// <summary>
		/// Gets or sets the FK_RE_Information value.
		/// </summary>
		public decimal? FK_RE_Information
		{
			get { return _FK_RE_Information; }
			set { _FK_RE_Information = value; }
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
		/// Gets or sets the Notes value.
		/// </summary>
		public string Notes
		{
			get { return _Notes; }
			set { _Notes = value; }
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
		/// Initializes a new instance of the RE_Notes class with default value.
		/// </summary>
		public RE_Notes() 
		{

			this._PK_RE_Notes = null;
			this._FK_RE_Information = null;
			this._Note_Date = null;
			this._Notes = null;
			this._Updated_By = null;
			this._Update_Date = null;

		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the RE_Notes class based on Primary Key.
		/// </summary>
		public RE_Notes(decimal pK_RE_Notes) 
		{
			DataTable dtRE_Notes = SelectByPK(pK_RE_Notes).Tables[0];

			if (dtRE_Notes.Rows.Count == 1)
			{
				DataRow drRE_Notes = dtRE_Notes.Rows[0];
				if (drRE_Notes["PK_RE_Notes"] == DBNull.Value)
					this._PK_RE_Notes = null;
				else
					this._PK_RE_Notes = (decimal?)drRE_Notes["PK_RE_Notes"];

				if (drRE_Notes["FK_RE_Information"] == DBNull.Value)
					this._FK_RE_Information = null;
				else
					this._FK_RE_Information = (decimal?)drRE_Notes["FK_RE_Information"];

				if (drRE_Notes["Note_Date"] == DBNull.Value)
					this._Note_Date = null;
				else
					this._Note_Date = (DateTime?)drRE_Notes["Note_Date"];

				if (drRE_Notes["Notes"] == DBNull.Value)
					this._Notes = null;
				else
					this._Notes = (string)drRE_Notes["Notes"];

				if (drRE_Notes["Updated_By"] == DBNull.Value)
					this._Updated_By = null;
				else
					this._Updated_By = (string)drRE_Notes["Updated_By"];

				if (drRE_Notes["Update_Date"] == DBNull.Value)
					this._Update_Date = null;
				else
					this._Update_Date = (DateTime?)drRE_Notes["Update_Date"];

			}
			else
			{
				this._PK_RE_Notes = null;
				this._FK_RE_Information = null;
				this._Note_Date = null;
				this._Notes = null;
				this._Updated_By = null;
				this._Update_Date = null;
			}

		}

		#endregion

		/// <summary>
		/// Inserts a record into the RE_Notes table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("RE_NotesInsert");

			
			db.AddInParameter(dbCommand, "FK_RE_Information", DbType.Decimal, this._FK_RE_Information);
			
			db.AddInParameter(dbCommand, "Note_Date", DbType.DateTime, this._Note_Date);
			
			if (string.IsNullOrEmpty(this._Notes))
				db.AddInParameter(dbCommand, "Notes", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Notes", DbType.String, this._Notes);
			
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
		/// Selects a single record from the RE_Notes table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		private static DataSet SelectByPK(decimal pK_RE_Notes)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("RE_NotesSelectByPK");

			db.AddInParameter(dbCommand, "PK_RE_Notes", DbType.Decimal, pK_RE_Notes);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the RE_Notes table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("RE_NotesSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the RE_Notes table.
		/// </summary>
		public void Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("RE_NotesUpdate");

			
			db.AddInParameter(dbCommand, "PK_RE_Notes", DbType.Decimal, this._PK_RE_Notes);
			
			db.AddInParameter(dbCommand, "FK_RE_Information", DbType.Decimal, this._FK_RE_Information);
			
			db.AddInParameter(dbCommand, "Note_Date", DbType.DateTime, this._Note_Date);
			
			if (string.IsNullOrEmpty(this._Notes))
				db.AddInParameter(dbCommand, "Notes", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Notes", DbType.String, this._Notes);
			
			if (string.IsNullOrEmpty(this._Updated_By))
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);
			
			db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the RE_Notes table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_RE_Notes)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("RE_NotesDeleteByPK");

			db.AddInParameter(dbCommand, "PK_RE_Notes", DbType.Decimal, pK_RE_Notes);

			db.ExecuteNonQuery(dbCommand);
		}

        public static DataSet SeleteByFK(decimal fK_RE_Information)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("RE_NotesSelectByFK");
            db.AddInParameter(dbCommand, "FK_RE_Information", DbType.Decimal, fK_RE_Information);
            return db.ExecuteDataSet(dbCommand);
        }

	}
}
