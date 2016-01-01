using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for Sonic_Management_Notes table.
	/// </summary>
	public sealed class clsSonic_Management_Notes
	{

		#region Private variables used to hold the property values

		private decimal? _PK_Sonic_Management_Notes;
		private decimal? _FK_Management;
		private DateTime? _Note_Date;
		private string _Note;
		private decimal? _Updated_by;
		private DateTime? _Updated_Date;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_Sonic_Management_Notes value.
		/// </summary>
		public decimal? PK_Sonic_Management_Notes
		{
			get { return _PK_Sonic_Management_Notes; }
			set { _PK_Sonic_Management_Notes = value; }
		}

		/// <summary>
		/// Gets or sets the FK_Management value.
		/// </summary>
		public decimal? FK_Management
		{
			get { return _FK_Management; }
			set { _FK_Management = value; }
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

		/// <summary>
		/// Gets or sets the Updated_Date value.
		/// </summary>
		public DateTime? Updated_Date
		{
			get { return _Updated_Date; }
			set { _Updated_Date = value; }
		}


		#endregion

		#region Default Constructors

		/// <summary>
		/// Initializes a new instance of the clsSonic_Management_Notes class with default value.
		/// </summary>
		public clsSonic_Management_Notes() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the clsSonic_Management_Notes class based on Primary Key.
		/// </summary>
		public clsSonic_Management_Notes(decimal pK_Sonic_Management_Notes) 
		{
			DataTable dtSonic_Management_Notes = SelectByPK(pK_Sonic_Management_Notes).Tables[0];

			if (dtSonic_Management_Notes.Rows.Count == 1)
			{
				 SetValue(dtSonic_Management_Notes.Rows[0]);

			}

		}


		/// <summary>
		/// Initializes a new instance of the clsSonic_Management_Notes class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drSonic_Management_Notes) 
		{
				if (drSonic_Management_Notes["PK_Sonic_Management_Notes"] == DBNull.Value)
					this._PK_Sonic_Management_Notes = null;
				else
					this._PK_Sonic_Management_Notes = (decimal?)drSonic_Management_Notes["PK_Sonic_Management_Notes"];

				if (drSonic_Management_Notes["FK_Management"] == DBNull.Value)
					this._FK_Management = null;
				else
					this._FK_Management = (decimal?)drSonic_Management_Notes["FK_Management"];

				if (drSonic_Management_Notes["Note_Date"] == DBNull.Value)
					this._Note_Date = null;
				else
					this._Note_Date = (DateTime?)drSonic_Management_Notes["Note_Date"];

				if (drSonic_Management_Notes["Note"] == DBNull.Value)
					this._Note = null;
				else
					this._Note = (string)drSonic_Management_Notes["Note"];

				if (drSonic_Management_Notes["Updated_by"] == DBNull.Value)
					this._Updated_by = null;
				else
					this._Updated_by = (decimal?)drSonic_Management_Notes["Updated_by"];

				if (drSonic_Management_Notes["Updated_Date"] == DBNull.Value)
					this._Updated_Date = null;
				else
					this._Updated_Date = (DateTime?)drSonic_Management_Notes["Updated_Date"];


		}

		#endregion

		/// <summary>
		/// Inserts a record into the Sonic_Management_Notes table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Sonic_Management_NotesInsert");

			
			db.AddInParameter(dbCommand, "FK_Management", DbType.Decimal, this._FK_Management);
			
			db.AddInParameter(dbCommand, "Note_Date", DbType.DateTime, this._Note_Date);
			
			if (string.IsNullOrEmpty(this._Note))
				db.AddInParameter(dbCommand, "Note", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Note", DbType.String, this._Note);
			
			db.AddInParameter(dbCommand, "Updated_by", DbType.Decimal, this._Updated_by);
			
			db.AddInParameter(dbCommand, "Updated_Date", DbType.DateTime, this._Updated_Date);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the Sonic_Management_Notes table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		private DataSet SelectByPK(decimal pK_Sonic_Management_Notes)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Sonic_Management_NotesSelectByPK");

			db.AddInParameter(dbCommand, "PK_Sonic_Management_Notes", DbType.Decimal, pK_Sonic_Management_Notes);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the Sonic_Management_Notes table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Sonic_Management_NotesSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the Sonic_Management_Notes table.
		/// </summary>
		public void Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Sonic_Management_NotesUpdate");

			
			db.AddInParameter(dbCommand, "PK_Sonic_Management_Notes", DbType.Decimal, this._PK_Sonic_Management_Notes);
			
			db.AddInParameter(dbCommand, "FK_Management", DbType.Decimal, this._FK_Management);
			
			db.AddInParameter(dbCommand, "Note_Date", DbType.DateTime, this._Note_Date);
			
			if (string.IsNullOrEmpty(this._Note))
				db.AddInParameter(dbCommand, "Note", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Note", DbType.String, this._Note);
			
			db.AddInParameter(dbCommand, "Updated_by", DbType.Decimal, this._Updated_by);
			
			db.AddInParameter(dbCommand, "Updated_Date", DbType.DateTime, this._Updated_Date);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the Sonic_Management_Notes table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_Sonic_Management_Notes)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Sonic_Management_NotesDeleteByPK");

			db.AddInParameter(dbCommand, "PK_Sonic_Management_Notes", DbType.Decimal, pK_Sonic_Management_Notes);

			db.ExecuteNonQuery(dbCommand);
		}

        /// <summary>
        /// Selects record from the Sonic_Management_Notes table by FK_Management.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectByFK_Management_WithPaging(decimal FK_Management, int intPageNo, int intPageSize, string strOrderBy, string strOrder)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Sonic_Management_NotesSelectPagingByFK_Management");

            db.AddInParameter(dbCommand, "FK_Management", DbType.Decimal, FK_Management);
            db.AddInParameter(dbCommand, "intPageNo", DbType.String, intPageNo);
            db.AddInParameter(dbCommand, "intPageSize", DbType.String, intPageSize);
            db.AddInParameter(dbCommand, "strOrderBy", DbType.String, strOrderBy);
            db.AddInParameter(dbCommand, "strOrder", DbType.String, strOrder);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects records from the Sonic_Management_Notes table by a foreign key.
        /// </summary>
        /// <param name="pK_Claim_Notes"></param>
        /// <returns>DataSet</returns>
        public static DataSet SelectByIDs(string strIDs)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Management_NotesSelectByIDs");

            db.AddInParameter(dbCommand, "PK_Management_Notes", DbType.String, strIDs);

            return db.ExecuteDataSet(dbCommand);
        }

        // <summary>
        // Selects record from the Sonic_Management_Notes table by FK_Event.
        // </summary>
        // <returns>DataSet</returns>
        public static DataSet SelectByFK_Management(decimal FK_Management)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Sonic_Management_NotesSelectByFK_Management");

            db.AddInParameter(dbCommand, "FK_Management", DbType.Decimal, FK_Management);

            return db.ExecuteDataSet(dbCommand);
        }
	}
}
