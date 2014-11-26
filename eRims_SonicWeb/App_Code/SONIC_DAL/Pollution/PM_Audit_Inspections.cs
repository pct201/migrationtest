using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for PM_Audit_Inspections table.
	/// </summary>
	public sealed class PM_Audit_Inspections
	{

		#region Private variables used to hold the property values

		private decimal? _PK_PM_Audit_Inspections;
		private decimal? _FK_PM_Site_Information;
		private string _Notes;
		private string _Updated_By;
		private DateTime? _Update_Date;
        private Guid _AuditID;
		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_PM_Audit_Inspections value.
		/// </summary>
		public decimal? PK_PM_Audit_Inspections
		{
			get { return _PK_PM_Audit_Inspections; }
			set { _PK_PM_Audit_Inspections = value; }
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
		/// Initializes a new instance of the PM_Audit_Inspections class with default value.
		/// </summary>
		public PM_Audit_Inspections() 
		{

			this._PK_PM_Audit_Inspections = null;
			this._FK_PM_Site_Information = null;
			this._Notes = null;
			this._Updated_By = null;
			this._Update_Date = null;
            this._AuditID = Guid.NewGuid();
		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the PM_Audit_Inspections class based on Primary Key.
		/// </summary>
        public PM_Audit_Inspections(decimal pK_PM_Audit_Inspections, bool SelectByFK) 
		{
			DataTable dtPM_Audit_Inspections;

            if(SelectByFK)
                dtPM_Audit_Inspections = SelectByFK_SiteInfo(pK_PM_Audit_Inspections).Tables[0];
            else
                dtPM_Audit_Inspections = SelectByPK(pK_PM_Audit_Inspections).Tables[0];

			if (dtPM_Audit_Inspections.Rows.Count == 1)
			{
				DataRow drPM_Audit_Inspections = dtPM_Audit_Inspections.Rows[0];
				if (drPM_Audit_Inspections["PK_PM_Audit_Inspections"] == DBNull.Value)
					this._PK_PM_Audit_Inspections = null;
				else
					this._PK_PM_Audit_Inspections = (decimal?)drPM_Audit_Inspections["PK_PM_Audit_Inspections"];

				if (drPM_Audit_Inspections["FK_PM_Site_Information"] == DBNull.Value)
					this._FK_PM_Site_Information = null;
				else
					this._FK_PM_Site_Information = (decimal?)drPM_Audit_Inspections["FK_PM_Site_Information"];

				if (drPM_Audit_Inspections["Notes"] == DBNull.Value)
					this._Notes = null;
				else
					this._Notes = (string)drPM_Audit_Inspections["Notes"];

				if (drPM_Audit_Inspections["Updated_By"] == DBNull.Value)
					this._Updated_By = null;
				else
					this._Updated_By = (string)drPM_Audit_Inspections["Updated_By"];

				if (drPM_Audit_Inspections["Update_Date"] == DBNull.Value)
					this._Update_Date = null;
				else
					this._Update_Date = (DateTime?)drPM_Audit_Inspections["Update_Date"];

			}
			else
			{
				this._PK_PM_Audit_Inspections = null;
				this._FK_PM_Site_Information = null;
				this._Notes = null;
				this._Updated_By = null;
				this._Update_Date = null;
			}

		}

		#endregion

		/// <summary>
		/// Inserts a record into the PM_Audit_Inspections table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("PM_Audit_InspectionsInsert");

			
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
		/// Selects a single record from the PM_Audit_Inspections table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		private static DataSet SelectByPK(decimal pK_PM_Audit_Inspections)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("PM_Audit_InspectionsSelectByPK");

			db.AddInParameter(dbCommand, "PK_PM_Audit_Inspections", DbType.Decimal, pK_PM_Audit_Inspections);

			return db.ExecuteDataSet(dbCommand);
		}

        public static DataSet SelectByFK_SiteInfo(decimal fK_PM_Site_Information)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("PM_Audit_InspectionsSelectByFK");

            db.AddInParameter(dbCommand, "FK_PM_Site_Information", DbType.Decimal, fK_PM_Site_Information);

            return db.ExecuteDataSet(dbCommand);
        }

		/// <summary>
		/// Selects all records from the PM_Audit_Inspections table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("PM_Audit_InspectionsSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the PM_Audit_Inspections table.
		/// </summary>
		public void Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("PM_Audit_InspectionsUpdate");

			
			db.AddInParameter(dbCommand, "PK_PM_Audit_Inspections", DbType.Decimal, this._PK_PM_Audit_Inspections);
			
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
		/// Deletes a record from the PM_Audit_Inspections table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_PM_Audit_Inspections)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("PM_Audit_InspectionsDeleteByPK");

			db.AddInParameter(dbCommand, "PK_PM_Audit_Inspections", DbType.Decimal, pK_PM_Audit_Inspections);

			db.ExecuteNonQuery(dbCommand);
		}
	}
}
