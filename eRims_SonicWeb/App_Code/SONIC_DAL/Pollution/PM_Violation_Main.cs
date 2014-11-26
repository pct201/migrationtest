using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for PM_Violation_Main table.
	/// </summary>
	public sealed class PM_Violation_Main
	{

		#region Private variables used to hold the property values

		private decimal? _PK_PM_Violation_Main;
		private decimal? _FK_PM_Site_Information;
		private string _Notes;
		private string _Updated_By;
		private DateTime? _Update_Date;
        private Guid _AuditID;
		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_PM_Violation_Main value.
		/// </summary>
		public decimal? PK_PM_Violation_Main
		{
			get { return _PK_PM_Violation_Main; }
			set { _PK_PM_Violation_Main = value; }
		}

		/// <summary>
		/// Gets or sets the FK_PM_Site_Information value.
		/// </summary>
		public decimal? FK_PM_Site_Information
		{
			get { return _FK_PM_Site_Information; }
			set { _FK_PM_Site_Information = value; }
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

        /// <summary>
        /// Gets or sets the AuditID value.
        /// </summary>
        public Guid AuditID
        {
            get { return _AuditID; }
            set { _AuditID = value; }
        }
		#endregion

		#region Default Constructors

		/// <summary>
		/// Initializes a new instance of the PM_Violation_Main class with default value.
		/// </summary>
		public PM_Violation_Main() 
		{

			this._PK_PM_Violation_Main = null;
			this._FK_PM_Site_Information = null;
			this._Notes = null;
			this._Updated_By = null;
			this._Update_Date = null;
            this._AuditID = Guid.NewGuid();
		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the PM_Violation_Main class based on Primary Key.
		/// </summary>
        public PM_Violation_Main(decimal pK_PM_Violation_Main, bool SelectByFK) 
		{
			DataTable dtPM_Violation_Main;

            if(SelectByFK)
                dtPM_Violation_Main = SelectByFK_SiteInfo(pK_PM_Violation_Main).Tables[0];
            else
                dtPM_Violation_Main = SelectByPK(pK_PM_Violation_Main).Tables[0];

			if (dtPM_Violation_Main.Rows.Count == 1)
			{
				DataRow drPM_Violation_Main = dtPM_Violation_Main.Rows[0];
				if (drPM_Violation_Main["PK_PM_Violation_Main"] == DBNull.Value)
					this._PK_PM_Violation_Main = null;
				else
					this._PK_PM_Violation_Main = (decimal?)drPM_Violation_Main["PK_PM_Violation_Main"];

				if (drPM_Violation_Main["FK_PM_Site_Information"] == DBNull.Value)
					this._FK_PM_Site_Information = null;
				else
					this._FK_PM_Site_Information = (decimal?)drPM_Violation_Main["FK_PM_Site_Information"];

				if (drPM_Violation_Main["Notes"] == DBNull.Value)
					this._Notes = null;
				else
					this._Notes = (string)drPM_Violation_Main["Notes"];

				if (drPM_Violation_Main["Updated_By"] == DBNull.Value)
					this._Updated_By = null;
				else
					this._Updated_By = (string)drPM_Violation_Main["Updated_By"];

				if (drPM_Violation_Main["Update_Date"] == DBNull.Value)
					this._Update_Date = null;
				else
					this._Update_Date = (DateTime?)drPM_Violation_Main["Update_Date"];

			}
			else
			{
				this._PK_PM_Violation_Main = null;
				this._FK_PM_Site_Information = null;
				this._Notes = null;
				this._Updated_By = null;
				this._Update_Date = null;
			}

		}

		#endregion

		/// <summary>
		/// Inserts a record into the PM_Violation_Main table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("PM_Violation_MainInsert");

			
			db.AddInParameter(dbCommand, "FK_PM_Site_Information", DbType.Decimal, this._FK_PM_Site_Information);
			
			if (string.IsNullOrEmpty(this._Notes))
				db.AddInParameter(dbCommand, "Notes", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Notes", DbType.String, this._Notes);
			
			if (string.IsNullOrEmpty(this._Updated_By))
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);
			
			db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);
            db.AddInParameter(dbCommand, "AuditID", DbType.Guid, this._AuditID);
			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the PM_Violation_Main table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		private static DataSet SelectByPK(decimal pK_PM_Violation_Main)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("PM_Violation_MainSelectByPK");

			db.AddInParameter(dbCommand, "PK_PM_Violation_Main", DbType.Decimal, pK_PM_Violation_Main);

			return db.ExecuteDataSet(dbCommand);
		}

        public static DataSet SelectByFK_SiteInfo(decimal fK_PM_Site_Information)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("PM_Violation_MainSelectByFK");

            db.AddInParameter(dbCommand, "FK_PM_Site_Information", DbType.Decimal, fK_PM_Site_Information);

            return db.ExecuteDataSet(dbCommand);
        }

		/// <summary>
		/// Selects all records from the PM_Violation_Main table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("PM_Violation_MainSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the PM_Violation_Main table.
		/// </summary>
		public void Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("PM_Violation_MainUpdate");

			
			db.AddInParameter(dbCommand, "PK_PM_Violation_Main", DbType.Decimal, this._PK_PM_Violation_Main);
			
			db.AddInParameter(dbCommand, "FK_PM_Site_Information", DbType.Decimal, this._FK_PM_Site_Information);
			
			if (string.IsNullOrEmpty(this._Notes))
				db.AddInParameter(dbCommand, "Notes", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Notes", DbType.String, this._Notes);
			
			if (string.IsNullOrEmpty(this._Updated_By))
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);
			
			db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);
            db.AddInParameter(dbCommand, "AuditID", DbType.Guid, this._AuditID);
			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the PM_Violation_Main table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_PM_Violation_Main)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("PM_Violation_MainDeleteByPK");

			db.AddInParameter(dbCommand, "PK_PM_Violation_Main", DbType.Decimal, pK_PM_Violation_Main);

			db.ExecuteNonQuery(dbCommand);
		}
	}
}
