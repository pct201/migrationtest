using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for CRM_Notes table.
	/// </summary>
	public sealed class CRM_Notes
	{

		#region Private variables used to hold the property values

		private decimal? _PK_CRM_Notes;
		private string _Table_Name;
		private decimal? _FK_Table_Name;
		private decimal? _FK_LU_CRM_Note_Type;
		private DateTime? _Note_Date;
		private string _Note;
		private DateTime? _Update_Date;
		private string _Updated_By;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_CRM_Notes value.
		/// </summary>
		public decimal? PK_CRM_Notes
		{
			get { return _PK_CRM_Notes; }
			set { _PK_CRM_Notes = value; }
		}

		/// <summary>
		/// Gets or sets the Table_Name value.
		/// </summary>
		public string Table_Name
		{
			get { return _Table_Name; }
			set { _Table_Name = value; }
		}

		/// <summary>
		/// Gets or sets the FK_Table_Name value.
		/// </summary>
		public decimal? FK_Table_Name
		{
			get { return _FK_Table_Name; }
			set { _FK_Table_Name = value; }
		}

		/// <summary>
		/// Gets or sets the FK_LU_CRM_Note_Type value.
		/// </summary>
		public decimal? FK_LU_CRM_Note_Type
		{
			get { return _FK_LU_CRM_Note_Type; }
			set { _FK_LU_CRM_Note_Type = value; }
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


		#endregion

		#region Default Constructors

		/// <summary>
		/// Initializes a new instance of the CRM_Notes class with default value.
		/// </summary>
		public CRM_Notes() 
		{

			this._PK_CRM_Notes = null;
			this._Table_Name = null;
			this._FK_Table_Name = null;
			this._FK_LU_CRM_Note_Type = null;
			this._Note_Date = null;
			this._Note = null;
			this._Update_Date = null;
			this._Updated_By = null;

		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the CRM_Notes class based on Primary Key.
		/// </summary>
		public CRM_Notes(decimal pK_CRM_Notes) 
		{
			DataTable dtCRM_Notes = SelectByPK(pK_CRM_Notes).Tables[0];

			if (dtCRM_Notes.Rows.Count == 1)
			{
				DataRow drCRM_Notes = dtCRM_Notes.Rows[0];
				if (drCRM_Notes["PK_CRM_Notes"] == DBNull.Value)
					this._PK_CRM_Notes = null;
				else
					this._PK_CRM_Notes = (decimal?)drCRM_Notes["PK_CRM_Notes"];

				if (drCRM_Notes["Table_Name"] == DBNull.Value)
					this._Table_Name = null;
				else
					this._Table_Name = (string)drCRM_Notes["Table_Name"];

				if (drCRM_Notes["FK_Table_Name"] == DBNull.Value)
					this._FK_Table_Name = null;
				else
					this._FK_Table_Name = (decimal?)drCRM_Notes["FK_Table_Name"];

				if (drCRM_Notes["FK_LU_CRM_Note_Type"] == DBNull.Value)
					this._FK_LU_CRM_Note_Type = null;
				else
					this._FK_LU_CRM_Note_Type = (decimal?)drCRM_Notes["FK_LU_CRM_Note_Type"];

				if (drCRM_Notes["Note_Date"] == DBNull.Value)
					this._Note_Date = null;
				else
					this._Note_Date = (DateTime?)drCRM_Notes["Note_Date"];

				if (drCRM_Notes["Note"] == DBNull.Value)
					this._Note = null;
				else
					this._Note = (string)drCRM_Notes["Note"];

				if (drCRM_Notes["Update_Date"] == DBNull.Value)
					this._Update_Date = null;
				else
					this._Update_Date = (DateTime?)drCRM_Notes["Update_Date"];

				if (drCRM_Notes["Updated_By"] == DBNull.Value)
					this._Updated_By = null;
				else
					this._Updated_By = (string)drCRM_Notes["Updated_By"];

			}
			else
			{
				this._PK_CRM_Notes = null;
				this._Table_Name = null;
				this._FK_Table_Name = null;
				this._FK_LU_CRM_Note_Type = null;
				this._Note_Date = null;
				this._Note = null;
				this._Update_Date = null;
				this._Updated_By = null;
			}

		}

		#endregion

		/// <summary>
		/// Inserts a record into the CRM_Notes table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("CRM_NotesInsert");

			
			if (string.IsNullOrEmpty(this._Table_Name))
				db.AddInParameter(dbCommand, "Table_Name", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Table_Name", DbType.String, this._Table_Name);
			
			db.AddInParameter(dbCommand, "FK_Table_Name", DbType.Decimal, this._FK_Table_Name);
			
			db.AddInParameter(dbCommand, "FK_LU_CRM_Note_Type", DbType.Decimal, this._FK_LU_CRM_Note_Type);
			
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

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the CRM_Notes table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		private static DataSet SelectByPK(decimal pK_CRM_Notes)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("CRM_NotesSelectByPK");

			db.AddInParameter(dbCommand, "PK_CRM_Notes", DbType.Decimal, pK_CRM_Notes);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the CRM_Notes table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("CRM_NotesSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the CRM_Notes table.
		/// </summary>
		public void Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("CRM_NotesUpdate");

			
			db.AddInParameter(dbCommand, "PK_CRM_Notes", DbType.Decimal, this._PK_CRM_Notes);
			
			if (string.IsNullOrEmpty(this._Table_Name))
				db.AddInParameter(dbCommand, "Table_Name", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Table_Name", DbType.String, this._Table_Name);
			
			db.AddInParameter(dbCommand, "FK_Table_Name", DbType.Decimal, this._FK_Table_Name);
			
			db.AddInParameter(dbCommand, "FK_LU_CRM_Note_Type", DbType.Decimal, this._FK_LU_CRM_Note_Type);
			
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

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the CRM_Notes table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_CRM_Notes)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("CRM_NotesDeleteByPK");

			db.AddInParameter(dbCommand, "PK_CRM_Notes", DbType.Decimal, pK_CRM_Notes);

			db.ExecuteNonQuery(dbCommand);
		}

        /// <summary>
        /// Selects a single record from the CRM_Notes table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectByFK_CRM(decimal fK_Table_Name, clsGeneral.CRM_Tables objTable, decimal fK_LU_CRM_Note_Type)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("CRM_NotesSelectByFK");

            db.AddInParameter(dbCommand, "FK_Table_Name", DbType.Decimal, fK_Table_Name);
            db.AddInParameter(dbCommand, "Table_Name", DbType.String, objTable.ToString());
            db.AddInParameter(dbCommand, "FK_LU_CRM_Note_Type", DbType.Decimal, fK_LU_CRM_Note_Type);
            return db.ExecuteDataSet(dbCommand);
        }
        //public static DataSet SelectByFK_CRM(decimal _FK_Table_Name, string _TableName, decimal _FK_LU_CRM_Note_Type)
        //{
        //    Database db = DatabaseFactory.CreateDatabase();
        //    DbCommand dbCommand = db.GetStoredProcCommand("CRM_NotesSelectBy_CRM_Note_Type");

        //    db.AddInParameter(dbCommand, "FK_Table_Name", DbType.Decimal, _FK_Table_Name);
        //    db.AddInParameter(dbCommand, "Table_Name", DbType.String, _TableName);
        //    db.AddInParameter(dbCommand, "FK_LU_CRM_Note_Type", DbType.Decimal, _FK_LU_CRM_Note_Type);

        //    return db.ExecuteDataSet(dbCommand);
        //}
        /// <summary>
        /// Selects a single record from the CRM_Notes table by a desc.
        /// </summary>
        /// <returns>DataSet</returns>
        public static decimal SelectByDesc_CRM(clsGeneral.CRM_Tables objTable, string CRM_Note_Type_Desc)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("CRM_NotesSelectByDesc");
           
            db.AddInParameter(dbCommand, "Table_Name", DbType.String, objTable.ToString());
            db.AddInParameter(dbCommand, "Fld_Desc", DbType.String, CRM_Note_Type_Desc);
            return Convert.ToDecimal(db.ExecuteScalar(dbCommand));
        }
	}
}
