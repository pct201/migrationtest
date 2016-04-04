using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for PM_Permits table.
	/// </summary>
	public sealed class PM_Permits
	{

		#region Private variables used to hold the property values

		private decimal? _PK_PM_Permits;
		private decimal? _FK_PM_Site_Information;
		private decimal? _FK_Permit_Type;
		private string _Permit_Required;
		private string _Certification_Number;
		private string _Application_Regulation_Number;
		private DateTime? _Permit_Start_Date;
		private DateTime? _Permit_End_Date;
		private DateTime? _Last_Inspection_Date;
		private DateTime? _Next_Inspection_Date;
		private DateTime? _Next_Report_Date;
		private string _Updated_By;
		private DateTime? _Update_Date;
		private string _Notes;
		private string _Recommendations;
        private string _Apply_To_Location;
		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_PM_Permits value.
		/// </summary>
		public decimal? PK_PM_Permits
		{
			get { return _PK_PM_Permits; }
			set { _PK_PM_Permits = value; }
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
		/// Gets or sets the FK_Permit_Type value.
		/// </summary>
		public decimal? FK_Permit_Type
		{
			get { return _FK_Permit_Type; }
			set { _FK_Permit_Type = value; }
		}

		/// <summary>
		/// Gets or sets the Permit_Required value.
		/// </summary>
		public string Permit_Required
		{
			get { return _Permit_Required; }
			set { _Permit_Required = value; }
		}

		/// <summary>
		/// Gets or sets the Certification_Number value.
		/// </summary>
		public string Certification_Number
		{
			get { return _Certification_Number; }
			set { _Certification_Number = value; }
		}

		/// <summary>
		/// Gets or sets the Application_Regulation_Number value.
		/// </summary>
		public string Application_Regulation_Number
		{
			get { return _Application_Regulation_Number; }
			set { _Application_Regulation_Number = value; }
		}

		/// <summary>
		/// Gets or sets the Permit_Start_Date value.
		/// </summary>
		public DateTime? Permit_Start_Date
		{
			get { return _Permit_Start_Date; }
			set { _Permit_Start_Date = value; }
		}

		/// <summary>
		/// Gets or sets the Permit_End_Date value.
		/// </summary>
		public DateTime? Permit_End_Date
		{
			get { return _Permit_End_Date; }
			set { _Permit_End_Date = value; }
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
		/// Gets or sets the Next_Report_Date value.
		/// </summary>
		public DateTime? Next_Report_Date
		{
			get { return _Next_Report_Date; }
			set { _Next_Report_Date = value; }
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

		/// <summary>
		/// Gets or sets the Recommendations value.
		/// </summary>
		public string Recommendations
		{
			get { return _Recommendations; }
			set { _Recommendations = value; }
		}

        public string Apply_To_Location
        {
            get { return _Apply_To_Location; }
            set { _Apply_To_Location = value; }
        }
		#endregion

		#region Default Constructors

		/// <summary>
		/// Initializes a new instance of the clsPM_Permits class with default value.
		/// </summary>
		public PM_Permits() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the clsPM_Permits class based on Primary Key.
		/// </summary>
        public PM_Permits(decimal pK_PM_Permits) 
		{
			DataTable dtPM_Permits = SelectByPK(pK_PM_Permits).Tables[0];

			if (dtPM_Permits.Rows.Count == 1)
			{
				 SetValue(dtPM_Permits.Rows[0]);

			}

		}


		/// <summary>
		/// Initializes a new instance of the clsPM_Permits class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drPM_Permits) 
		{
				if (drPM_Permits["PK_PM_Permits"] == DBNull.Value)
					this._PK_PM_Permits = null;
				else
					this._PK_PM_Permits = (decimal?)drPM_Permits["PK_PM_Permits"];

				if (drPM_Permits["FK_PM_Site_Information"] == DBNull.Value)
					this._FK_PM_Site_Information = null;
				else
					this._FK_PM_Site_Information = (decimal?)drPM_Permits["FK_PM_Site_Information"];

				if (drPM_Permits["FK_Permit_Type"] == DBNull.Value)
					this._FK_Permit_Type = null;
				else
					this._FK_Permit_Type = (decimal?)drPM_Permits["FK_Permit_Type"];

				if (drPM_Permits["Permit_Required"] == DBNull.Value)
					this._Permit_Required = null;
				else
					this._Permit_Required = (string)drPM_Permits["Permit_Required"];

				if (drPM_Permits["Certification_Number"] == DBNull.Value)
					this._Certification_Number = null;
				else
					this._Certification_Number = (string)drPM_Permits["Certification_Number"];

				if (drPM_Permits["Application_Regulation_Number"] == DBNull.Value)
					this._Application_Regulation_Number = null;
				else
					this._Application_Regulation_Number = (string)drPM_Permits["Application_Regulation_Number"];

				if (drPM_Permits["Permit_Start_Date"] == DBNull.Value)
					this._Permit_Start_Date = null;
				else
					this._Permit_Start_Date = (DateTime?)drPM_Permits["Permit_Start_Date"];

				if (drPM_Permits["Permit_End_Date"] == DBNull.Value)
					this._Permit_End_Date = null;
				else
					this._Permit_End_Date = (DateTime?)drPM_Permits["Permit_End_Date"];

				if (drPM_Permits["Last_Inspection_Date"] == DBNull.Value)
					this._Last_Inspection_Date = null;
				else
					this._Last_Inspection_Date = (DateTime?)drPM_Permits["Last_Inspection_Date"];

				if (drPM_Permits["Next_Inspection_Date"] == DBNull.Value)
					this._Next_Inspection_Date = null;
				else
					this._Next_Inspection_Date = (DateTime?)drPM_Permits["Next_Inspection_Date"];

				if (drPM_Permits["Next_Report_Date"] == DBNull.Value)
					this._Next_Report_Date = null;
				else
					this._Next_Report_Date = (DateTime?)drPM_Permits["Next_Report_Date"];

				if (drPM_Permits["Updated_By"] == DBNull.Value)
					this._Updated_By = null;
				else
					this._Updated_By = (string)drPM_Permits["Updated_By"];

				if (drPM_Permits["Update_Date"] == DBNull.Value)
					this._Update_Date = null;
				else
					this._Update_Date = (DateTime?)drPM_Permits["Update_Date"];

				if (drPM_Permits["Notes"] == DBNull.Value)
					this._Notes = null;
				else
					this._Notes = (string)drPM_Permits["Notes"];

				if (drPM_Permits["Recommendations"] == DBNull.Value)
					this._Recommendations = null;
				else
					this._Recommendations = (string)drPM_Permits["Recommendations"];

                if (drPM_Permits["Apply_To_Location"] == DBNull.Value)
                    this._Apply_To_Location = null;
                else
                    this._Apply_To_Location = (string)drPM_Permits["Apply_To_Location"];
		}

		#endregion

		/// <summary>
		/// Inserts a record into the PM_Permits table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("PM_PermitsInsert");

			
			db.AddInParameter(dbCommand, "FK_PM_Site_Information", DbType.Decimal, this._FK_PM_Site_Information);
			
			db.AddInParameter(dbCommand, "FK_Permit_Type", DbType.Decimal, this._FK_Permit_Type);
			
			if (string.IsNullOrEmpty(this._Permit_Required))
				db.AddInParameter(dbCommand, "Permit_Required", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Permit_Required", DbType.String, this._Permit_Required);
			
			if (string.IsNullOrEmpty(this._Certification_Number))
				db.AddInParameter(dbCommand, "Certification_Number", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Certification_Number", DbType.String, this._Certification_Number);
			
			if (string.IsNullOrEmpty(this._Application_Regulation_Number))
				db.AddInParameter(dbCommand, "Application_Regulation_Number", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Application_Regulation_Number", DbType.String, this._Application_Regulation_Number);
			
			db.AddInParameter(dbCommand, "Permit_Start_Date", DbType.DateTime, this._Permit_Start_Date);
			
			db.AddInParameter(dbCommand, "Permit_End_Date", DbType.DateTime, this._Permit_End_Date);
			
			db.AddInParameter(dbCommand, "Last_Inspection_Date", DbType.DateTime, this._Last_Inspection_Date);
			
			db.AddInParameter(dbCommand, "Next_Inspection_Date", DbType.DateTime, this._Next_Inspection_Date);
			
			db.AddInParameter(dbCommand, "Next_Report_Date", DbType.DateTime, this._Next_Report_Date);
			
			if (string.IsNullOrEmpty(this._Updated_By))
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);
			
			db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);
			
			if (string.IsNullOrEmpty(this._Notes))
				db.AddInParameter(dbCommand, "Notes", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Notes", DbType.String, this._Notes);
			
			if (string.IsNullOrEmpty(this._Recommendations))
				db.AddInParameter(dbCommand, "Recommendations", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Recommendations", DbType.String, this._Recommendations);

            if (string.IsNullOrEmpty(this._Apply_To_Location))
                db.AddInParameter(dbCommand, "Apply_To_Location", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Apply_To_Location", DbType.String, this._Apply_To_Location);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the PM_Permits table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		private DataSet SelectByPK(decimal pK_PM_Permits)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("PM_PermitsSelectByPK");

			db.AddInParameter(dbCommand, "PK_PM_Permits", DbType.Decimal, pK_PM_Permits);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the PM_Permits table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("PM_PermitsSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the PM_Permits table.
		/// </summary>
		public int Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("PM_PermitsUpdate");

			
			db.AddInParameter(dbCommand, "PK_PM_Permits", DbType.Decimal, this._PK_PM_Permits);
			
			db.AddInParameter(dbCommand, "FK_PM_Site_Information", DbType.Decimal, this._FK_PM_Site_Information);
			
			db.AddInParameter(dbCommand, "FK_Permit_Type", DbType.Decimal, this._FK_Permit_Type);
			
			if (string.IsNullOrEmpty(this._Permit_Required))
				db.AddInParameter(dbCommand, "Permit_Required", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Permit_Required", DbType.String, this._Permit_Required);
			
			if (string.IsNullOrEmpty(this._Certification_Number))
				db.AddInParameter(dbCommand, "Certification_Number", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Certification_Number", DbType.String, this._Certification_Number);
			
			if (string.IsNullOrEmpty(this._Application_Regulation_Number))
				db.AddInParameter(dbCommand, "Application_Regulation_Number", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Application_Regulation_Number", DbType.String, this._Application_Regulation_Number);
			
			db.AddInParameter(dbCommand, "Permit_Start_Date", DbType.DateTime, this._Permit_Start_Date);
			
			db.AddInParameter(dbCommand, "Permit_End_Date", DbType.DateTime, this._Permit_End_Date);
			
			db.AddInParameter(dbCommand, "Last_Inspection_Date", DbType.DateTime, this._Last_Inspection_Date);
			
			db.AddInParameter(dbCommand, "Next_Inspection_Date", DbType.DateTime, this._Next_Inspection_Date);
			
			db.AddInParameter(dbCommand, "Next_Report_Date", DbType.DateTime, this._Next_Report_Date);
			
			if (string.IsNullOrEmpty(this._Updated_By))
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);
			
			db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);
			
			if (string.IsNullOrEmpty(this._Notes))
				db.AddInParameter(dbCommand, "Notes", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Notes", DbType.String, this._Notes);
			
			if (string.IsNullOrEmpty(this._Recommendations))
				db.AddInParameter(dbCommand, "Recommendations", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Recommendations", DbType.String, this._Recommendations);

            if (string.IsNullOrEmpty(this._Apply_To_Location))
                db.AddInParameter(dbCommand, "Apply_To_Location", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Apply_To_Location", DbType.String, this._Apply_To_Location);

            // Execute the query and return the new identity value
            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
		}

		/// <summary>
		/// Deletes a record from the PM_Permits table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_PM_Permits)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("PM_PermitsDeleteByPK");

			db.AddInParameter(dbCommand, "PK_PM_Permits", DbType.Decimal, pK_PM_Permits);

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
            DbCommand dbCommand = db.GetStoredProcCommand("PM_PermitsSelectByFK");

            db.AddInParameter(dbCommand, "FK_PM_Site_Information", DbType.Decimal, fK_PM_Site_Information);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Get Audit View details
        /// </summary>
        /// <param name="pK_PM_SI_Utility_Provider"></param>
        /// <returns></returns>
        public static DataSet GetAuditView(decimal pK_PM_Permits)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("PM_Permits_AuditView");

            db.AddInParameter(dbCommand, "pK_PM_Permits", DbType.Decimal, pK_PM_Permits);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Get PK from Location and Phone Number
        /// </summary>
        /// <param name="pK_PM_SI_Utility_Provider"></param>
        /// <returns></returns>
        public static int SelectByLocationAndPhoneNumber(string location, string phone_Number)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("PM_Permits_SelectByLoactionAndPhoneNumber");

            db.AddInParameter(dbCommand, "Location", DbType.String, location);
            db.AddInParameter(dbCommand, "Phone_Number", DbType.String, phone_Number);

            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));
            return returnValue;
        }
	}
}
