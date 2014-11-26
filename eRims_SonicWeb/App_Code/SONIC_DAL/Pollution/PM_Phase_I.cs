using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for PM_Phase_I table.
	/// </summary>
	public sealed class PM_Phase_I
	{
		#region Private variables used to hold the property values

		private decimal? _PK_PM_Phase_I;
		private decimal? _FK_PM_Site_Information;
		private string _Assessor;
		private string _Contact_Name;
		private string _Contact_Telephone;
		private DateTime? _Report_Date;
		private decimal? _Cost;
		private DateTime? _Next_Review_Date;
		private DateTime? _Next_Report_Date;
		private string _Recommendations;
		private string _Updated_By;
		private DateTime? _Update_Date;
		private string _Notes;
        private string _PhaseII_Recommended;
        private string _Apply_To_Location;
		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_PM_Phase_I value.
		/// </summary>
		public decimal? PK_PM_Phase_I
		{
			get { return _PK_PM_Phase_I; }
			set { _PK_PM_Phase_I = value; }
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
		/// Gets or sets the Assessor value.
		/// </summary>
		public string Assessor
		{
			get { return _Assessor; }
			set { _Assessor = value; }
		}

        /// <summary>
        /// Gets or sets the _PhaseII_Recommended value.
        /// </summary>
        public string PhaseII_Recommended
        {
            get { return _PhaseII_Recommended; }
            set { _PhaseII_Recommended = value; }
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
		/// Gets or sets the Report_Date value.
		/// </summary>
		public DateTime? Report_Date
		{
			get { return _Report_Date; }
			set { _Report_Date = value; }
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
		/// Gets or sets the Next_Review_Date value.
		/// </summary>
		public DateTime? Next_Review_Date
		{
			get { return _Next_Review_Date; }
			set { _Next_Review_Date = value; }
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
		/// Initializes a new instance of the clsPM_Phase_I class with default value.
		/// </summary>
		public PM_Phase_I() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the clsPM_Phase_I class based on Primary Key.
		/// </summary>
		public PM_Phase_I(decimal pK_PM_Phase_I) 
		{
			DataTable dtPM_Phase_I = SelectByPK(pK_PM_Phase_I).Tables[0];

			if (dtPM_Phase_I.Rows.Count == 1)
			{
				 SetValue(dtPM_Phase_I.Rows[0]);

			}

		}


		/// <summary>
		/// Initializes a new instance of the clsPM_Phase_I class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drPM_Phase_I) 
		{
				if (drPM_Phase_I["PK_PM_Phase_I"] == DBNull.Value)
					this._PK_PM_Phase_I = null;
				else
					this._PK_PM_Phase_I = (decimal?)drPM_Phase_I["PK_PM_Phase_I"];

				if (drPM_Phase_I["FK_PM_Site_Information"] == DBNull.Value)
					this._FK_PM_Site_Information = null;
				else
					this._FK_PM_Site_Information = (decimal?)drPM_Phase_I["FK_PM_Site_Information"];

				if (drPM_Phase_I["Assessor"] == DBNull.Value)
					this._Assessor = null;
				else
					this._Assessor = (string)drPM_Phase_I["Assessor"];

				if (drPM_Phase_I["Contact_Name"] == DBNull.Value)
					this._Contact_Name = null;
				else
					this._Contact_Name = (string)drPM_Phase_I["Contact_Name"];

				if (drPM_Phase_I["Contact_Telephone"] == DBNull.Value)
					this._Contact_Telephone = null;
				else
					this._Contact_Telephone = (string)drPM_Phase_I["Contact_Telephone"];

				if (drPM_Phase_I["Report_Date"] == DBNull.Value)
					this._Report_Date = null;
				else
					this._Report_Date = (DateTime?)drPM_Phase_I["Report_Date"];

				if (drPM_Phase_I["Cost"] == DBNull.Value)
					this._Cost = null;
				else
					this._Cost = (decimal?)drPM_Phase_I["Cost"];

				if (drPM_Phase_I["Next_Review_Date"] == DBNull.Value)
					this._Next_Review_Date = null;
				else
					this._Next_Review_Date = (DateTime?)drPM_Phase_I["Next_Review_Date"];

				if (drPM_Phase_I["Next_Report_Date"] == DBNull.Value)
					this._Next_Report_Date = null;
				else
					this._Next_Report_Date = (DateTime?)drPM_Phase_I["Next_Report_Date"];

				if (drPM_Phase_I["Recommendations"] == DBNull.Value)
					this._Recommendations = null;
				else
					this._Recommendations = (string)drPM_Phase_I["Recommendations"];

				if (drPM_Phase_I["Updated_By"] == DBNull.Value)
					this._Updated_By = null;
				else
					this._Updated_By = (string)drPM_Phase_I["Updated_By"];

				if (drPM_Phase_I["Update_Date"] == DBNull.Value)
					this._Update_Date = null;
				else
					this._Update_Date = (DateTime?)drPM_Phase_I["Update_Date"];

				if (drPM_Phase_I["Notes"] == DBNull.Value)
					this._Notes = null;
				else
					this._Notes = (string)drPM_Phase_I["Notes"];

                if (drPM_Phase_I["PhaseII_Recommended"] == DBNull.Value)
                    this._PhaseII_Recommended = null;
				else
                    this._PhaseII_Recommended = (string)drPM_Phase_I["PhaseII_Recommended"];

                if (drPM_Phase_I["Apply_To_Location"] == DBNull.Value)
                    this._Apply_To_Location = null;
                else
                    this._Apply_To_Location = (string)drPM_Phase_I["Apply_To_Location"];
		}

		#endregion

		/// <summary>
		/// Inserts a record into the PM_Phase_I table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("PM_Phase_IInsert");
			
			db.AddInParameter(dbCommand, "FK_PM_Site_Information", DbType.Decimal, this._FK_PM_Site_Information);
			
			if (string.IsNullOrEmpty(this._Assessor))
				db.AddInParameter(dbCommand, "Assessor", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Assessor", DbType.String, this._Assessor);
			
			if (string.IsNullOrEmpty(this._Contact_Name))
				db.AddInParameter(dbCommand, "Contact_Name", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Contact_Name", DbType.String, this._Contact_Name);
			
			if (string.IsNullOrEmpty(this._Contact_Telephone))
				db.AddInParameter(dbCommand, "Contact_Telephone", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Contact_Telephone", DbType.String, this._Contact_Telephone);
			
			db.AddInParameter(dbCommand, "Report_Date", DbType.DateTime, this._Report_Date);
			
			db.AddInParameter(dbCommand, "Cost", DbType.Decimal, this._Cost);
			
			db.AddInParameter(dbCommand, "Next_Review_Date", DbType.DateTime, this._Next_Review_Date);
			
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

            if (string.IsNullOrEmpty(this._PhaseII_Recommended))
                db.AddInParameter(dbCommand, "PhaseII_Recommended", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "PhaseII_Recommended", DbType.String, this._PhaseII_Recommended);

            if (string.IsNullOrEmpty(this._Apply_To_Location))
                db.AddInParameter(dbCommand, "Apply_To_Location", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Apply_To_Location", DbType.String, this._Apply_To_Location);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the PM_Phase_I table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		private DataSet SelectByPK(decimal pK_PM_Phase_I)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("PM_Phase_ISelectByPK");

			db.AddInParameter(dbCommand, "PK_PM_Phase_I", DbType.Decimal, pK_PM_Phase_I);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the PM_Phase_I table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("PM_Phase_ISelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the PM_Phase_I table.
		/// </summary>
		public int Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("PM_Phase_IUpdate");
			
			db.AddInParameter(dbCommand, "PK_PM_Phase_I", DbType.Decimal, this._PK_PM_Phase_I);
			
			db.AddInParameter(dbCommand, "FK_PM_Site_Information", DbType.Decimal, this._FK_PM_Site_Information);
			
			if (string.IsNullOrEmpty(this._Assessor))
				db.AddInParameter(dbCommand, "Assessor", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Assessor", DbType.String, this._Assessor);
			
			if (string.IsNullOrEmpty(this._Contact_Name))
				db.AddInParameter(dbCommand, "Contact_Name", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Contact_Name", DbType.String, this._Contact_Name);
			
			if (string.IsNullOrEmpty(this._Contact_Telephone))
				db.AddInParameter(dbCommand, "Contact_Telephone", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Contact_Telephone", DbType.String, this._Contact_Telephone);
			
			db.AddInParameter(dbCommand, "Report_Date", DbType.DateTime, this._Report_Date);
			
			db.AddInParameter(dbCommand, "Cost", DbType.Decimal, this._Cost);
			
			db.AddInParameter(dbCommand, "Next_Review_Date", DbType.DateTime, this._Next_Review_Date);
			
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

            if (string.IsNullOrEmpty(this._PhaseII_Recommended))
                db.AddInParameter(dbCommand, "PhaseII_Recommended", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "PhaseII_Recommended", DbType.String, this._PhaseII_Recommended);

            if (string.IsNullOrEmpty(this._Apply_To_Location))
                db.AddInParameter(dbCommand, "Apply_To_Location", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Apply_To_Location", DbType.String, this._Apply_To_Location);

            // Execute the query and return the new identity value
            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
		}

		/// <summary>
		/// Deletes a record from the PM_Phase_I table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_PM_Phase_I)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("PM_Phase_IDeleteByPK");

			db.AddInParameter(dbCommand, "PK_PM_Phase_I", DbType.Decimal, pK_PM_Phase_I);

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
            DbCommand dbCommand = db.GetStoredProcCommand("PM_Phase_ISelectByFK");

            db.AddInParameter(dbCommand, "FK_PM_Site_Information", DbType.Decimal, fK_PM_Site_Information);

            return db.ExecuteDataSet(dbCommand);
        }
        /// <summary>
        /// Get Audit View details
        /// </summary>
        /// <param name="pK_PM_SI_Utility_Provider"></param>
        /// <returns></returns>
        public static DataSet GetAuditView(decimal pK_PM_Phase_I)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("PM_Phase_I_Audit_AuditView");

            db.AddInParameter(dbCommand, "pK_PM_Phase_I", DbType.Decimal, pK_PM_Phase_I);

            return db.ExecuteDataSet(dbCommand);
        }
	}
}
