using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for AP_Notes table.
	/// </summary>
	public sealed class clsAP_Notes
	{

		#region Private variables used to hold the property values

		private decimal? _PK_AP_Notes;
		private decimal? _FK_Table;
		private string _FK_Table_Name;
		private DateTime? _Note_Date;
		private string _Note;
		private string _Updated_By;
		private DateTime? _Update_Date;
		private DateTime? _Created_Date;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_AP_Notes value.
		/// </summary>
		public decimal? PK_AP_Notes
		{
			get { return _PK_AP_Notes; }
			set { _PK_AP_Notes = value; }
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
		/// Initializes a new instance of the clsAP_Notes class with default value.
		/// </summary>
		public clsAP_Notes() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the clsAP_Notes class based on Primary Key.
		/// </summary>
		public clsAP_Notes(decimal pK_AP_Notes) 
		{
			DataTable dtAP_Notes = SelectByPK(pK_AP_Notes).Tables[0];

			if (dtAP_Notes.Rows.Count == 1)
			{
				 SetValue(dtAP_Notes.Rows[0]);

			}

		}


		/// <summary>
		/// Initializes a new instance of the clsAP_Notes class based on Datarow passed.
		/// </summary>
		private void SetValue(DataRow drAP_Notes) 
		{
				if (drAP_Notes["PK_AP_Notes"] == DBNull.Value)
					this._PK_AP_Notes = null;
				else
					this._PK_AP_Notes = (decimal?)drAP_Notes["PK_AP_Notes"];

				if (drAP_Notes["FK_Table"] == DBNull.Value)
					this._FK_Table = null;
				else
					this._FK_Table = (decimal?)drAP_Notes["FK_Table"];

				if (drAP_Notes["FK_Table_Name"] == DBNull.Value)
					this._FK_Table_Name = null;
				else
					this._FK_Table_Name = (string)drAP_Notes["FK_Table_Name"];

				if (drAP_Notes["Note_Date"] == DBNull.Value)
					this._Note_Date = null;
				else
					this._Note_Date = (DateTime?)drAP_Notes["Note_Date"];

				if (drAP_Notes["Note"] == DBNull.Value)
					this._Note = null;
				else
					this._Note = (string)drAP_Notes["Note"];

				if (drAP_Notes["Updated_By"] == DBNull.Value)
					this._Updated_By = null;
				else
					this._Updated_By = (string)drAP_Notes["Updated_By"];

				if (drAP_Notes["Update_Date"] == DBNull.Value)
					this._Update_Date = null;
				else
					this._Update_Date = (DateTime?)drAP_Notes["Update_Date"];

				if (drAP_Notes["Created_Date"] == DBNull.Value)
					this._Created_Date = null;
				else
					this._Created_Date = (DateTime?)drAP_Notes["Created_Date"];


		}

		#endregion

		/// <summary>
		/// Inserts a record into the AP_Notes table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("AP_NotesInsert");

			
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
			
			db.AddInParameter(dbCommand, "Created_Date", DbType.DateTime, this._Created_Date);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the AP_Notes table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		private DataSet SelectByPK(decimal pK_AP_Notes)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("AP_NotesSelectByPK");

			db.AddInParameter(dbCommand, "PK_AP_Notes", DbType.Decimal, pK_AP_Notes);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the AP_Notes table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("AP_NotesSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the AP_Notes table.
		/// </summary>
		public void Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("AP_NotesUpdate");

			
			db.AddInParameter(dbCommand, "PK_AP_Notes", DbType.Decimal, this._PK_AP_Notes);
			
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
			
			db.AddInParameter(dbCommand, "Created_Date", DbType.DateTime, this._Created_Date);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the AP_Notes table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_AP_Notes)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("AP_NotesDeleteByPK");

			db.AddInParameter(dbCommand, "PK_AP_Notes", DbType.Decimal, pK_AP_Notes);

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
            DbCommand dbCommand = db.GetStoredProcCommand("AP_NotesSelectByIDs");

            db.AddInParameter(dbCommand, "PK_AP_Notes", DbType.String, strIDs);

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
            DbCommand dbCommand = db.GetStoredProcCommand("AP_NotesSelectByFK_Table");

            db.AddInParameter(dbCommand, "FK_Table", DbType.Decimal, FK_Table);
            db.AddInParameter(dbCommand, "FK_Table_Name", DbType.String, FK_Table_Name);
            db.AddInParameter(dbCommand, "@intPageNo", DbType.String, intPageNo);
            db.AddInParameter(dbCommand, "@intPageSize", DbType.String, intPageSize);

            return db.ExecuteDataSet(dbCommand);
        }
	}
}
