using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for EPM_Action_Notes_RM table.
	/// </summary>
	public sealed class clsEPM_Action_Notes_RM
	{

		#region Private variables used to hold the property values

		private decimal? _PK_EPM_Action_Notes_RM;
		private decimal? _FK_EPM_Action_Notes;
		private DateTime? _Note_Date;
		private string _Note;
		private string _Updated_By;
		private DateTime? _Update_Date;
		private DateTime? _Created_Date;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_EPM_Action_Notes_RM value.
		/// </summary>
		public decimal? PK_EPM_Action_Notes_RM
		{
			get { return _PK_EPM_Action_Notes_RM; }
			set { _PK_EPM_Action_Notes_RM = value; }
		}

		/// <summary>
		/// Gets or sets the FK_EPM_Action_Notes value.
		/// </summary>
		public decimal? FK_EPM_Action_Notes
		{
			get { return _FK_EPM_Action_Notes; }
			set { _FK_EPM_Action_Notes = value; }
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
		/// Initializes a new instance of the clsEPM_Action_Notes_RM class with default value.
		/// </summary>
		public clsEPM_Action_Notes_RM() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the clsEPM_Action_Notes_RM class based on Primary Key.
		/// </summary>
		public clsEPM_Action_Notes_RM(decimal pK_EPM_Action_Notes_RM) 
		{
			DataTable dtEPM_Action_Notes_RM = SelectByPK(pK_EPM_Action_Notes_RM).Tables[0];

			if (dtEPM_Action_Notes_RM.Rows.Count == 1)
			{
				 SetValue(dtEPM_Action_Notes_RM.Rows[0]);

			}

		}


		/// <summary>
		/// Initializes a new instance of the clsEPM_Action_Notes_RM class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drEPM_Action_Notes_RM) 
		{
				if (drEPM_Action_Notes_RM["PK_EPM_Action_Notes_RM"] == DBNull.Value)
					this._PK_EPM_Action_Notes_RM = null;
				else
					this._PK_EPM_Action_Notes_RM = (decimal?)drEPM_Action_Notes_RM["PK_EPM_Action_Notes_RM"];

				if (drEPM_Action_Notes_RM["FK_EPM_Action_Notes"] == DBNull.Value)
					this._FK_EPM_Action_Notes = null;
				else
					this._FK_EPM_Action_Notes = (decimal?)drEPM_Action_Notes_RM["FK_EPM_Action_Notes"];

				if (drEPM_Action_Notes_RM["Note_Date"] == DBNull.Value)
					this._Note_Date = null;
				else
					this._Note_Date = (DateTime?)drEPM_Action_Notes_RM["Note_Date"];

				if (drEPM_Action_Notes_RM["Note"] == DBNull.Value)
					this._Note = null;
				else
					this._Note = (string)drEPM_Action_Notes_RM["Note"];

				if (drEPM_Action_Notes_RM["Updated_By"] == DBNull.Value)
					this._Updated_By = null;
				else
					this._Updated_By = (string)drEPM_Action_Notes_RM["Updated_By"];

				if (drEPM_Action_Notes_RM["Update_Date"] == DBNull.Value)
					this._Update_Date = null;
				else
					this._Update_Date = (DateTime?)drEPM_Action_Notes_RM["Update_Date"];

				if (drEPM_Action_Notes_RM["Created_Date"] == DBNull.Value)
					this._Created_Date = null;
				else
					this._Created_Date = (DateTime?)drEPM_Action_Notes_RM["Created_Date"];


		}

		#endregion

		/// <summary>
		/// Inserts a record into the EPM_Action_Notes_RM table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("EPM_Action_Notes_RMInsert");

			
			db.AddInParameter(dbCommand, "FK_EPM_Action_Notes", DbType.Decimal, this._FK_EPM_Action_Notes);
			
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
		/// Selects a single record from the EPM_Action_Notes_RM table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		private DataSet SelectByPK(decimal pK_EPM_Action_Notes_RM)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("EPM_Action_Notes_RMSelectByPK");

			db.AddInParameter(dbCommand, "PK_EPM_Action_Notes_RM", DbType.Decimal, pK_EPM_Action_Notes_RM);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the EPM_Action_Notes_RM table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("EPM_Action_Notes_RMSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the EPM_Action_Notes_RM table.
		/// </summary>
		public void Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("EPM_Action_Notes_RMUpdate");

			
			db.AddInParameter(dbCommand, "PK_EPM_Action_Notes_RM", DbType.Decimal, this._PK_EPM_Action_Notes_RM);
			
			db.AddInParameter(dbCommand, "FK_EPM_Action_Notes", DbType.Decimal, this._FK_EPM_Action_Notes);
			
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
		/// Deletes a record from the EPM_Action_Notes_RM table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_EPM_Action_Notes_RM)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("EPM_Action_Notes_RMDeleteByPK");

			db.AddInParameter(dbCommand, "PK_EPM_Action_Notes_RM", DbType.Decimal, pK_EPM_Action_Notes_RM);

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
            DbCommand dbCommand = db.GetStoredProcCommand("EPM_Action_Notes_RMSelectByIDs");

            db.AddInParameter(dbCommand, "PK_EPM_Action_Notes_RM", DbType.String, strIDs);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects records from the Claim_Notes table by a foreign key.
        /// </summary>
        /// <param name="pK_Claim_Notes"></param>
        /// <returns>DataSet</returns>
        public static DataSet SelectByFK_Table(decimal FK_EPM_Action_Notes, int intPageNo, int intPageSize)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("EPM_Action_Notes_RMSelectByFK_Table");

            db.AddInParameter(dbCommand, "@FK_EPM_Action_Notes", DbType.Decimal, FK_EPM_Action_Notes);
            db.AddInParameter(dbCommand, "@intPageNo", DbType.String, intPageNo);
            db.AddInParameter(dbCommand, "@intPageSize", DbType.String, intPageSize);

            return db.ExecuteDataSet(dbCommand);
        }
	}
}
