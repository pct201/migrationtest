using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for PM_Compliance_Reporting table.
	/// </summary>
	public sealed class PM_Compliance_Reporting
	{

		#region Private variables used to hold the property values

		private decimal? _PK_PM_Compliance_Reporting;
		private decimal? _FK_PM_Site_Information;
		private string _Federal_Facility_Identification_Number;
		private string _State_Facility_Identification_Number;
		private string _Contact_Name;
		private string _Contact_Telephone;
		private string _Emergency_Contact_Name;
		private string _Emergency_Telephone;
		private string _Updated_By;
		private DateTime? _Update_Date;
        private Guid _AuditID;
		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_PM_Compliance_Reporting value.
		/// </summary>
		public decimal? PK_PM_Compliance_Reporting
		{
			get { return _PK_PM_Compliance_Reporting; }
			set { _PK_PM_Compliance_Reporting = value; }
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
		/// Gets or sets the Federal_Facility_Identification_Number value.
		/// </summary>
		public string Federal_Facility_Identification_Number
		{
			get { return _Federal_Facility_Identification_Number; }
			set { _Federal_Facility_Identification_Number = value; }
		}

		/// <summary>
		/// Gets or sets the State_Facility_Identification_Number value.
		/// </summary>
		public string State_Facility_Identification_Number
		{
			get { return _State_Facility_Identification_Number; }
			set { _State_Facility_Identification_Number = value; }
		}

		/// <summary>
		/// Gets or sets the Contact_Name value.
		/// </summary>
		public string Contact_Name
		{
			get { return _Contact_Name; }
			set { _Contact_Name = value; }
		}

		/// <summary>
		/// Gets or sets the Contact_Telephone value.
		/// </summary>
		public string Contact_Telephone
		{
			get { return _Contact_Telephone; }
			set { _Contact_Telephone = value; }
		}

		/// <summary>
		/// Gets or sets the Emergency_Contact_Name value.
		/// </summary>
		public string Emergency_Contact_Name
		{
			get { return _Emergency_Contact_Name; }
			set { _Emergency_Contact_Name = value; }
		}

		/// <summary>
		/// Gets or sets the Emergency_Telephone value.
		/// </summary>
		public string Emergency_Telephone
		{
			get { return _Emergency_Telephone; }
			set { _Emergency_Telephone = value; }
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
		/// Initializes a new instance of the clsPM_Compliance_Reporting class with default value.
		/// </summary>
		public PM_Compliance_Reporting() 
		{

            this._AuditID = Guid.NewGuid();
		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the clsPM_Compliance_Reporting class based on Primary Key.
		/// </summary>
		public PM_Compliance_Reporting(decimal pK_PM_Compliance_Reporting, bool SelectByFK) 
		{
            DataTable dtPM_Compliance_Reporting = null;

            if(SelectByFK)
                dtPM_Compliance_Reporting = SelectByFK_SiteInfo(pK_PM_Compliance_Reporting).Tables[0];   
            else
                dtPM_Compliance_Reporting = SelectByPK(pK_PM_Compliance_Reporting).Tables[0];

			if (dtPM_Compliance_Reporting.Rows.Count == 1)
			{
				 SetValue(dtPM_Compliance_Reporting.Rows[0]);
			}

		}


		/// <summary>
		/// Initializes a new instance of the clsPM_Compliance_Reporting class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drPM_Compliance_Reporting) 
		{
				if (drPM_Compliance_Reporting["PK_PM_Compliance_Reporting"] == DBNull.Value)
					this._PK_PM_Compliance_Reporting = null;
				else
					this._PK_PM_Compliance_Reporting = (decimal?)drPM_Compliance_Reporting["PK_PM_Compliance_Reporting"];

				if (drPM_Compliance_Reporting["FK_PM_Site_Information"] == DBNull.Value)
					this._FK_PM_Site_Information = null;
				else
					this._FK_PM_Site_Information = (decimal?)drPM_Compliance_Reporting["FK_PM_Site_Information"];

				if (drPM_Compliance_Reporting["Federal_Facility_Identification_Number"] == DBNull.Value)
					this._Federal_Facility_Identification_Number = null;
				else
					this._Federal_Facility_Identification_Number = (string)drPM_Compliance_Reporting["Federal_Facility_Identification_Number"];

				if (drPM_Compliance_Reporting["State_Facility_Identification_Number"] == DBNull.Value)
					this._State_Facility_Identification_Number = null;
				else
					this._State_Facility_Identification_Number = (string)drPM_Compliance_Reporting["State_Facility_Identification_Number"];

				if (drPM_Compliance_Reporting["Contact_Name"] == DBNull.Value)
					this._Contact_Name = null;
				else
					this._Contact_Name = (string)drPM_Compliance_Reporting["Contact_Name"];

				if (drPM_Compliance_Reporting["Contact_Telephone"] == DBNull.Value)
					this._Contact_Telephone = null;
				else
					this._Contact_Telephone = (string)drPM_Compliance_Reporting["Contact_Telephone"];

				if (drPM_Compliance_Reporting["Emergency_Contact_Name"] == DBNull.Value)
					this._Emergency_Contact_Name = null;
				else
					this._Emergency_Contact_Name = (string)drPM_Compliance_Reporting["Emergency_Contact_Name"];

				if (drPM_Compliance_Reporting["Emergency_Telephone"] == DBNull.Value)
					this._Emergency_Telephone = null;
				else
					this._Emergency_Telephone = (string)drPM_Compliance_Reporting["Emergency_Telephone"];

				if (drPM_Compliance_Reporting["Updated_By"] == DBNull.Value)
					this._Updated_By = null;
				else
					this._Updated_By = (string)drPM_Compliance_Reporting["Updated_By"];

				if (drPM_Compliance_Reporting["Update_Date"] == DBNull.Value)
					this._Update_Date = null;
				else
					this._Update_Date = (DateTime?)drPM_Compliance_Reporting["Update_Date"];


		}

		#endregion

		/// <summary>
		/// Inserts a record into the PM_Compliance_Reporting table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("PM_Compliance_ReportingInsert");

			
			db.AddInParameter(dbCommand, "FK_PM_Site_Information", DbType.Decimal, this._FK_PM_Site_Information);
			
			if (string.IsNullOrEmpty(this._Federal_Facility_Identification_Number))
				db.AddInParameter(dbCommand, "Federal_Facility_Identification_Number", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Federal_Facility_Identification_Number", DbType.String, this._Federal_Facility_Identification_Number);
			
			if (string.IsNullOrEmpty(this._State_Facility_Identification_Number))
				db.AddInParameter(dbCommand, "State_Facility_Identification_Number", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "State_Facility_Identification_Number", DbType.String, this._State_Facility_Identification_Number);
			
			if (string.IsNullOrEmpty(this._Contact_Name))
				db.AddInParameter(dbCommand, "Contact_Name", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Contact_Name", DbType.String, this._Contact_Name);
			
			if (string.IsNullOrEmpty(this._Contact_Telephone))
				db.AddInParameter(dbCommand, "Contact_Telephone", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Contact_Telephone", DbType.String, this._Contact_Telephone);
			
			if (string.IsNullOrEmpty(this._Emergency_Contact_Name))
				db.AddInParameter(dbCommand, "Emergency_Contact_Name", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Emergency_Contact_Name", DbType.String, this._Emergency_Contact_Name);
			
			if (string.IsNullOrEmpty(this._Emergency_Telephone))
				db.AddInParameter(dbCommand, "Emergency_Telephone", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Emergency_Telephone", DbType.String, this._Emergency_Telephone);
			
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
		/// Selects a single record from the PM_Compliance_Reporting table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		private DataSet SelectByPK(decimal pK_PM_Compliance_Reporting)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("PM_Compliance_ReportingSelectByPK");

			db.AddInParameter(dbCommand, "PK_PM_Compliance_Reporting", DbType.Decimal, pK_PM_Compliance_Reporting);

			return db.ExecuteDataSet(dbCommand);
		}

        private DataSet SelectByFK_SiteInfo(decimal fK_PM_Site_Information)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("PM_Compliance_ReportingSelectByFK");

            db.AddInParameter(dbCommand, "FK_PM_Site_Information", DbType.Decimal, fK_PM_Site_Information);

            return db.ExecuteDataSet(dbCommand);
        }

		/// <summary>
		/// Selects all records from the PM_Compliance_Reporting table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("PM_Compliance_ReportingSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the PM_Compliance_Reporting table.
		/// </summary>
		public void Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("PM_Compliance_ReportingUpdate");

			
			db.AddInParameter(dbCommand, "PK_PM_Compliance_Reporting", DbType.Decimal, this._PK_PM_Compliance_Reporting);
			
			db.AddInParameter(dbCommand, "FK_PM_Site_Information", DbType.Decimal, this._FK_PM_Site_Information);
			
			if (string.IsNullOrEmpty(this._Federal_Facility_Identification_Number))
				db.AddInParameter(dbCommand, "Federal_Facility_Identification_Number", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Federal_Facility_Identification_Number", DbType.String, this._Federal_Facility_Identification_Number);
			
			if (string.IsNullOrEmpty(this._State_Facility_Identification_Number))
				db.AddInParameter(dbCommand, "State_Facility_Identification_Number", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "State_Facility_Identification_Number", DbType.String, this._State_Facility_Identification_Number);
			
			if (string.IsNullOrEmpty(this._Contact_Name))
				db.AddInParameter(dbCommand, "Contact_Name", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Contact_Name", DbType.String, this._Contact_Name);
			
			if (string.IsNullOrEmpty(this._Contact_Telephone))
				db.AddInParameter(dbCommand, "Contact_Telephone", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Contact_Telephone", DbType.String, this._Contact_Telephone);
			
			if (string.IsNullOrEmpty(this._Emergency_Contact_Name))
				db.AddInParameter(dbCommand, "Emergency_Contact_Name", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Emergency_Contact_Name", DbType.String, this._Emergency_Contact_Name);
			
			if (string.IsNullOrEmpty(this._Emergency_Telephone))
				db.AddInParameter(dbCommand, "Emergency_Telephone", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Emergency_Telephone", DbType.String, this._Emergency_Telephone);
			
			if (string.IsNullOrEmpty(this._Updated_By))
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);
			
			db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);
            db.AddInParameter(dbCommand, "AuditID", DbType.Guid, this._AuditID);
			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the PM_Compliance_Reporting table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_PM_Compliance_Reporting)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("PM_Compliance_ReportingDeleteByPK");

			db.AddInParameter(dbCommand, "PK_PM_Compliance_Reporting", DbType.Decimal, pK_PM_Compliance_Reporting);

			db.ExecuteNonQuery(dbCommand);
		}
	}
}
