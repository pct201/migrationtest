using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for PM_Frequency table.
	/// </summary>
	public sealed class PM_Frequency
	{

		#region Private variables used to hold the property values

		private decimal? _PK_PM_Frequency;
		private decimal? _FK_PM_Site_Information;
		private DateTime? _Last_Inspection_Date;
		private DateTime? _Next_Inspection_Date;
		private decimal? _Cost;
		private string _Next_Report_Due;
		private DateTime? _Next_Report_Date;
		private string _Recommendations;
		private string _Updated_By;
		private DateTime? _Update_Date;
		private string _Notes;
        private string _Apply_To_Location;
		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_PM_Frequency value.
		/// </summary>
		public decimal? PK_PM_Frequency
		{
			get { return _PK_PM_Frequency; }
			set { _PK_PM_Frequency = value; }
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
		/// Gets or sets the Last_Inspection_Date value.
		/// </summary>
		public DateTime? Last_Inspection_Date
		{
			get { return _Last_Inspection_Date; }
			set { _Last_Inspection_Date = value; }
		}

		/// <summary>
		/// Gets or sets the Next_Inspection_Date value.
		/// </summary>
		public DateTime? Next_Inspection_Date
		{
			get { return _Next_Inspection_Date; }
			set { _Next_Inspection_Date = value; }
		}

		/// <summary>
		/// Gets or sets the Cost value.
		/// </summary>
		public decimal? Cost
		{
			get { return _Cost; }
			set { _Cost = value; }
		}

		/// <summary>
		/// Gets or sets the Next_Report_Due value.
		/// </summary>
		public string Next_Report_Due
		{
			get { return _Next_Report_Due; }
			set { _Next_Report_Due = value; }
		}

		/// <summary>
		/// Gets or sets the Next_Report_Date value.
		/// </summary>
		public DateTime? Next_Report_Date
		{
			get { return _Next_Report_Date; }
			set { _Next_Report_Date = value; }
		}

		/// <summary>
		/// Gets or sets the Recommendations value.
		/// </summary>
		public string Recommendations
		{
			get { return _Recommendations; }
			set { _Recommendations = value; }
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
		/// Gets or sets the Notes value.
		/// </summary>
		public string Notes
		{
			get { return _Notes; }
			set { _Notes = value; }
		}

        public string Apply_To_Location
        {
            get { return _Apply_To_Location; }
            set { _Apply_To_Location = value; }
        }
		#endregion

		#region Default Constructors

		/// <summary>
		/// Initializes a new instance of the clsPM_Frequency class with default value.
		/// </summary>
		public PM_Frequency() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the clsPM_Frequency class based on Primary Key.
		/// </summary>
		public PM_Frequency(decimal pK_PM_Frequency) 
		{
			DataTable dtPM_Frequency = SelectByPK(pK_PM_Frequency).Tables[0];

			if (dtPM_Frequency.Rows.Count == 1)
			{
				 SetValue(dtPM_Frequency.Rows[0]);

			}

		}


		/// <summary>
		/// Initializes a new instance of the clsPM_Frequency class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drPM_Frequency) 
		{
				if (drPM_Frequency["PK_PM_Frequency"] == DBNull.Value)
					this._PK_PM_Frequency = null;
				else
					this._PK_PM_Frequency = (decimal?)drPM_Frequency["PK_PM_Frequency"];

				if (drPM_Frequency["FK_PM_Site_Information"] == DBNull.Value)
					this._FK_PM_Site_Information = null;
				else
					this._FK_PM_Site_Information = (decimal?)drPM_Frequency["FK_PM_Site_Information"];

				if (drPM_Frequency["Last_Inspection_Date"] == DBNull.Value)
					this._Last_Inspection_Date = null;
				else
					this._Last_Inspection_Date = (DateTime?)drPM_Frequency["Last_Inspection_Date"];

				if (drPM_Frequency["Next_Inspection_Date"] == DBNull.Value)
					this._Next_Inspection_Date = null;
				else
					this._Next_Inspection_Date = (DateTime?)drPM_Frequency["Next_Inspection_Date"];

				if (drPM_Frequency["Cost"] == DBNull.Value)
					this._Cost = null;
				else
					this._Cost = (decimal?)drPM_Frequency["Cost"];

				if (drPM_Frequency["Next_Report_Due"] == DBNull.Value)
					this._Next_Report_Due = null;
				else
					this._Next_Report_Due = (string)drPM_Frequency["Next_Report_Due"];

				if (drPM_Frequency["Next_Report_Date"] == DBNull.Value)
					this._Next_Report_Date = null;
				else
					this._Next_Report_Date = (DateTime?)drPM_Frequency["Next_Report_Date"];

				if (drPM_Frequency["Recommendations"] == DBNull.Value)
					this._Recommendations = null;
				else
					this._Recommendations = (string)drPM_Frequency["Recommendations"];

				if (drPM_Frequency["Updated_By"] == DBNull.Value)
					this._Updated_By = null;
				else
					this._Updated_By = (string)drPM_Frequency["Updated_By"];

				if (drPM_Frequency["Update_Date"] == DBNull.Value)
					this._Update_Date = null;
				else
					this._Update_Date = (DateTime?)drPM_Frequency["Update_Date"];

				if (drPM_Frequency["Notes"] == DBNull.Value)
					this._Notes = null;
				else
					this._Notes = (string)drPM_Frequency["Notes"];

                if (drPM_Frequency["Apply_To_Location"] == DBNull.Value)
                    this._Apply_To_Location = null;
                else
                    this._Apply_To_Location = (string)drPM_Frequency["Apply_To_Location"];
		}

		#endregion

		/// <summary>
		/// Inserts a record into the PM_Frequency table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("PM_FrequencyInsert");

			
			db.AddInParameter(dbCommand, "FK_PM_Site_Information", DbType.Decimal, this._FK_PM_Site_Information);
			
			db.AddInParameter(dbCommand, "Last_Inspection_Date", DbType.DateTime, this._Last_Inspection_Date);
			
			db.AddInParameter(dbCommand, "Next_Inspection_Date", DbType.DateTime, this._Next_Inspection_Date);
			
			db.AddInParameter(dbCommand, "Cost", DbType.Decimal, this._Cost);
			
			if (string.IsNullOrEmpty(this._Next_Report_Due))
				db.AddInParameter(dbCommand, "Next_Report_Due", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Next_Report_Due", DbType.String, this._Next_Report_Due);
			
			db.AddInParameter(dbCommand, "Next_Report_Date", DbType.DateTime, this._Next_Report_Date);
			
			if (string.IsNullOrEmpty(this._Recommendations))
				db.AddInParameter(dbCommand, "Recommendations", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Recommendations", DbType.String, this._Recommendations);
			
			if (string.IsNullOrEmpty(this._Updated_By))
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);
			
			db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);
			
			if (string.IsNullOrEmpty(this._Notes))
				db.AddInParameter(dbCommand, "Notes", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Notes", DbType.String, this._Notes);

            if (string.IsNullOrEmpty(this._Apply_To_Location))
                db.AddInParameter(dbCommand, "Apply_To_Location", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Apply_To_Location", DbType.String, this._Apply_To_Location);

            // Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the PM_Frequency table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		private DataSet SelectByPK(decimal pK_PM_Frequency)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("PM_FrequencySelectByPK");

			db.AddInParameter(dbCommand, "PK_PM_Frequency", DbType.Decimal, pK_PM_Frequency);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the PM_Frequency table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("PM_FrequencySelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the PM_Frequency table.
		/// </summary>
		public void Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("PM_FrequencyUpdate");

			
			db.AddInParameter(dbCommand, "PK_PM_Frequency", DbType.Decimal, this._PK_PM_Frequency);
			
			db.AddInParameter(dbCommand, "FK_PM_Site_Information", DbType.Decimal, this._FK_PM_Site_Information);
			
			db.AddInParameter(dbCommand, "Last_Inspection_Date", DbType.DateTime, this._Last_Inspection_Date);
			
			db.AddInParameter(dbCommand, "Next_Inspection_Date", DbType.DateTime, this._Next_Inspection_Date);
			
			db.AddInParameter(dbCommand, "Cost", DbType.Decimal, this._Cost);
			
			if (string.IsNullOrEmpty(this._Next_Report_Due))
				db.AddInParameter(dbCommand, "Next_Report_Due", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Next_Report_Due", DbType.String, this._Next_Report_Due);
			
			db.AddInParameter(dbCommand, "Next_Report_Date", DbType.DateTime, this._Next_Report_Date);
			
			if (string.IsNullOrEmpty(this._Recommendations))
				db.AddInParameter(dbCommand, "Recommendations", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Recommendations", DbType.String, this._Recommendations);
			
			if (string.IsNullOrEmpty(this._Updated_By))
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);
			
			db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);
			
			if (string.IsNullOrEmpty(this._Notes))
				db.AddInParameter(dbCommand, "Notes", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Notes", DbType.String, this._Notes);

            if (string.IsNullOrEmpty(this._Apply_To_Location))
                db.AddInParameter(dbCommand, "Apply_To_Location", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Apply_To_Location", DbType.String, this._Apply_To_Location);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the PM_Frequency table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_PM_Frequency)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("PM_FrequencyDeleteByPK");

			db.AddInParameter(dbCommand, "PK_PM_Frequency", DbType.Decimal, pK_PM_Frequency);

			db.ExecuteNonQuery(dbCommand);
		}

        /// <summary>
        /// Selects records by FK
        /// </summary>
        /// <param name="pK_PM_SI_Utility_Provider"></param>
        /// <returns></returns>
        public static DataSet SelectByFK_SiteInfo(decimal fK_PM_Site_Information)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("PM_FrequencySelectByFK");

            db.AddInParameter(dbCommand, "FK_PM_Site_Information", DbType.Decimal, fK_PM_Site_Information);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Get Audit View details
        /// </summary>
        /// <param name="pK_PM_SI_Utility_Provider"></param>
        /// <returns></returns>
        public static DataSet GetAuditView(decimal PK_PM_Frequency)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("PM_Frequency_AuditView");

            db.AddInParameter(dbCommand, "PK_PM_Frequency", DbType.Decimal, PK_PM_Frequency);

            return db.ExecuteDataSet(dbCommand);
        }
	}
}
