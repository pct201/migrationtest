using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for PM_CR_Grids table.
	/// </summary>
	public sealed class PM_CR_Grids
	{

		#region Private variables used to hold the property values

		private decimal? _PK_PM_CR_Grids;
		private decimal? _FK_PM_Compliance_Reporting;
		private string _Grid_Type;
		private DateTime? _Report_Due_Date;
		private DateTime? _Report_Submission_Date;
		private DateTime? _Rejection_Date;
		private DateTime? _Resubmission_Date;
		private string _Initial_Notification;
		private string _Compliance_Verification;
		private string _Report_Changes;
		private decimal? _Associated_Fees;
		private string _Notes;
		private string _Updated_By;
		private DateTime? _Update_Date;
        private string _Regualtory_Contact;
        private string _Regualtory_Telephone;
        private string _Regualtory_Email;
        private string _Apply_To_Location;
		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_PM_CR_Grids value.
		/// </summary>
		public decimal? PK_PM_CR_Grids
		{
			get { return _PK_PM_CR_Grids; }
			set { _PK_PM_CR_Grids = value; }
		}

		/// <summary>
		/// Gets or sets the FK_PM_Compliance_Reporting value.
		/// </summary>
		public decimal? FK_PM_Compliance_Reporting
		{
			get { return _FK_PM_Compliance_Reporting; }
			set { _FK_PM_Compliance_Reporting = value; }
		}

		/// <summary>
		/// Gets or sets the Grid_Type value.
		/// </summary>
		public string Grid_Type
		{
			get { return _Grid_Type; }
			set { _Grid_Type = value; }
		}

		/// <summary>
		/// Gets or sets the Report_Due_Date value.
		/// </summary>
		public DateTime? Report_Due_Date
		{
			get { return _Report_Due_Date; }
			set { _Report_Due_Date = value; }
		}

		/// <summary>
		/// Gets or sets the Report_Submission_Date value.
		/// </summary>
		public DateTime? Report_Submission_Date
		{
			get { return _Report_Submission_Date; }
			set { _Report_Submission_Date = value; }
		}

		/// <summary>
		/// Gets or sets the Rejection_Date value.
		/// </summary>
		public DateTime? Rejection_Date
		{
			get { return _Rejection_Date; }
			set { _Rejection_Date = value; }
		}

		/// <summary>
		/// Gets or sets the Resubmission_Date value.
		/// </summary>
		public DateTime? Resubmission_Date
		{
			get { return _Resubmission_Date; }
			set { _Resubmission_Date = value; }
		}

		/// <summary>
		/// Gets or sets the Initial_Notification value.
		/// </summary>
		public string Initial_Notification
		{
			get { return _Initial_Notification; }
			set { _Initial_Notification = value; }
		}

		/// <summary>
		/// Gets or sets the Compliance_Verification value.
		/// </summary>
		public string Compliance_Verification
		{
			get { return _Compliance_Verification; }
			set { _Compliance_Verification = value; }
		}

		/// <summary>
		/// Gets or sets the Report_Changes value.
		/// </summary>
		public string Report_Changes
		{
			get { return _Report_Changes; }
			set { _Report_Changes = value; }
		}

		/// <summary>
		/// Gets or sets the Associated_Fees value.
		/// </summary>
		public decimal? Associated_Fees
		{
			get { return _Associated_Fees; }
			set { _Associated_Fees = value; }
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

        public string Regualtory_Contact
        {
            get { return _Regualtory_Contact; }
            set { _Regualtory_Contact = value; }
        }

        public string Regualtory_Telephone
        {
            get { return _Regualtory_Telephone; }
            set { _Regualtory_Telephone = value; }
        }

        public string Regualtory_Email
        {
            get { return _Regualtory_Email; }
            set { _Regualtory_Email = value; }
        }

        public string Apply_To_Location
        {
            get { return _Apply_To_Location; }
            set { _Apply_To_Location = value; }
        }
		#endregion

		#region Default Constructors

		/// <summary>
		/// Initializes a new instance of the clsPM_CR_Grids class with default value.
		/// </summary>
		public PM_CR_Grids() 
		{
		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the clsPM_CR_Grids class based on Primary Key.
		/// </summary>
		public PM_CR_Grids(decimal pK_PM_CR_Grids) 
		{
			DataTable dtPM_CR_Grids = SelectByPK(pK_PM_CR_Grids).Tables[0];

			if (dtPM_CR_Grids.Rows.Count == 1)
			{
				 SetValue(dtPM_CR_Grids.Rows[0]);
			}
		}


		/// <summary>
		/// Initializes a new instance of the clsPM_CR_Grids class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drPM_CR_Grids) 
		{
				if (drPM_CR_Grids["PK_PM_CR_Grids"] == DBNull.Value)
					this._PK_PM_CR_Grids = null;
				else
					this._PK_PM_CR_Grids = (decimal?)drPM_CR_Grids["PK_PM_CR_Grids"];

				if (drPM_CR_Grids["FK_PM_Compliance_Reporting"] == DBNull.Value)
					this._FK_PM_Compliance_Reporting = null;
				else
					this._FK_PM_Compliance_Reporting = (decimal?)drPM_CR_Grids["FK_PM_Compliance_Reporting"];

				if (drPM_CR_Grids["Grid_Type"] == DBNull.Value)
					this._Grid_Type = null;
				else
					this._Grid_Type = (string)drPM_CR_Grids["Grid_Type"];

				if (drPM_CR_Grids["Report_Due_Date"] == DBNull.Value)
					this._Report_Due_Date = null;
				else
					this._Report_Due_Date = (DateTime?)drPM_CR_Grids["Report_Due_Date"];

				if (drPM_CR_Grids["Report_Submission_Date"] == DBNull.Value)
					this._Report_Submission_Date = null;
				else
					this._Report_Submission_Date = (DateTime?)drPM_CR_Grids["Report_Submission_Date"];

				if (drPM_CR_Grids["Rejection_Date"] == DBNull.Value)
					this._Rejection_Date = null;
				else
					this._Rejection_Date = (DateTime?)drPM_CR_Grids["Rejection_Date"];

				if (drPM_CR_Grids["Resubmission_Date"] == DBNull.Value)
					this._Resubmission_Date = null;
				else
					this._Resubmission_Date = (DateTime?)drPM_CR_Grids["Resubmission_Date"];

				if (drPM_CR_Grids["Initial_Notification"] == DBNull.Value)
					this._Initial_Notification = null;
				else
					this._Initial_Notification = (string)drPM_CR_Grids["Initial_Notification"];

				if (drPM_CR_Grids["Compliance_Verification"] == DBNull.Value)
					this._Compliance_Verification = null;
				else
					this._Compliance_Verification = (string)drPM_CR_Grids["Compliance_Verification"];

				if (drPM_CR_Grids["Report_Changes"] == DBNull.Value)
					this._Report_Changes = null;
				else
					this._Report_Changes = (string)drPM_CR_Grids["Report_Changes"];

				if (drPM_CR_Grids["Associated_Fees"] == DBNull.Value)
					this._Associated_Fees = null;
				else
					this._Associated_Fees = (decimal?)drPM_CR_Grids["Associated_Fees"];

				if (drPM_CR_Grids["Notes"] == DBNull.Value)
					this._Notes = null;
				else
					this._Notes = (string)drPM_CR_Grids["Notes"];

				if (drPM_CR_Grids["Updated_By"] == DBNull.Value)
					this._Updated_By = null;
				else
					this._Updated_By = (string)drPM_CR_Grids["Updated_By"];

				if (drPM_CR_Grids["Update_Date"] == DBNull.Value)
					this._Update_Date = null;
				else
					this._Update_Date = (DateTime?)drPM_CR_Grids["Update_Date"];

                if (drPM_CR_Grids["Regualtory_Contact"] == DBNull.Value)
                    this._Regualtory_Contact = null;
                else
                    this._Regualtory_Contact = (string)drPM_CR_Grids["Regualtory_Contact"];

                if (drPM_CR_Grids["Regualtory_Telephone"] == DBNull.Value)
                    this._Regualtory_Telephone = null;
                else
                    this._Regualtory_Telephone = (string)drPM_CR_Grids["Regualtory_Telephone"];

                if (drPM_CR_Grids["Regualtory_Email"] == DBNull.Value)
                    this._Regualtory_Email = null;
                else
                    this._Regualtory_Email = (string)drPM_CR_Grids["Regualtory_Email"];

                if (drPM_CR_Grids["Apply_To_Location"] == DBNull.Value)
                    this._Apply_To_Location = null;
                else
                    this._Apply_To_Location = (string)drPM_CR_Grids["Apply_To_Location"];
		}

		#endregion

		/// <summary>
		/// Inserts a record into the PM_CR_Grids table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("PM_CR_GridsInsert");
			
			db.AddInParameter(dbCommand, "FK_PM_Compliance_Reporting", DbType.Decimal, this._FK_PM_Compliance_Reporting);
			
			if (string.IsNullOrEmpty(this._Grid_Type))
				db.AddInParameter(dbCommand, "Grid_Type", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Grid_Type", DbType.String, this._Grid_Type);
			
			db.AddInParameter(dbCommand, "Report_Due_Date", DbType.DateTime, this._Report_Due_Date);
			
			db.AddInParameter(dbCommand, "Report_Submission_Date", DbType.DateTime, this._Report_Submission_Date);
			
			db.AddInParameter(dbCommand, "Rejection_Date", DbType.DateTime, this._Rejection_Date);
			
			db.AddInParameter(dbCommand, "Resubmission_Date", DbType.DateTime, this._Resubmission_Date);
			
			if (string.IsNullOrEmpty(this._Initial_Notification))
				db.AddInParameter(dbCommand, "Initial_Notification", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Initial_Notification", DbType.String, this._Initial_Notification);
			
			if (string.IsNullOrEmpty(this._Compliance_Verification))
				db.AddInParameter(dbCommand, "Compliance_Verification", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Compliance_Verification", DbType.String, this._Compliance_Verification);
			
			if (string.IsNullOrEmpty(this._Report_Changes))
				db.AddInParameter(dbCommand, "Report_Changes", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Report_Changes", DbType.String, this._Report_Changes);
			
			db.AddInParameter(dbCommand, "Associated_Fees", DbType.Decimal, this._Associated_Fees);
			
			if (string.IsNullOrEmpty(this._Notes))
				db.AddInParameter(dbCommand, "Notes", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Notes", DbType.String, this._Notes);
			
			if (string.IsNullOrEmpty(this._Updated_By))
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);
			
			db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);

            if (string.IsNullOrEmpty(this._Regualtory_Contact))
                db.AddInParameter(dbCommand, "Regualtory_Contact", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Regualtory_Contact", DbType.String, this._Regualtory_Contact);

            if (string.IsNullOrEmpty(this._Regualtory_Telephone))
                db.AddInParameter(dbCommand, "Regualtory_Telephone", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Regualtory_Telephone", DbType.String, this._Regualtory_Telephone);

            if (string.IsNullOrEmpty(this._Regualtory_Email))
                db.AddInParameter(dbCommand, "Regualtory_Email", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Regualtory_Email", DbType.String, this._Regualtory_Email);

            if (string.IsNullOrEmpty(this._Apply_To_Location))
                db.AddInParameter(dbCommand, "Apply_To_Location", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Apply_To_Location", DbType.String, this._Apply_To_Location);
			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the PM_CR_Grids table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		private DataSet SelectByPK(decimal pK_PM_CR_Grids)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("PM_CR_GridsSelectByPK");

			db.AddInParameter(dbCommand, "PK_PM_CR_Grids", DbType.Decimal, pK_PM_CR_Grids);

			return db.ExecuteDataSet(dbCommand);
		}

        /// <summary>
        /// Selects a records from the PM_CR_Grids table by a foreign key.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectByFK(decimal fK_PM_Site_Information, string gridType)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("PM_CR_GridsSelectByFK");

            db.AddInParameter(dbCommand, "FK_PM_Site_Information", DbType.Decimal, fK_PM_Site_Information);

            if (string.IsNullOrEmpty(gridType))
                db.AddInParameter(dbCommand, "Grid_Type", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Grid_Type", DbType.String, gridType);

            return db.ExecuteDataSet(dbCommand);
        }

		/// <summary>
		/// Selects all records from the PM_CR_Grids table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("PM_CR_GridsSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the PM_CR_Grids table.
		/// </summary>
		public void Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("PM_CR_GridsUpdate");
			
			db.AddInParameter(dbCommand, "PK_PM_CR_Grids", DbType.Decimal, this._PK_PM_CR_Grids);
			
			db.AddInParameter(dbCommand, "FK_PM_Compliance_Reporting", DbType.Decimal, this._FK_PM_Compliance_Reporting);
			
			if (string.IsNullOrEmpty(this._Grid_Type))
				db.AddInParameter(dbCommand, "Grid_Type", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Grid_Type", DbType.String, this._Grid_Type);
			
			db.AddInParameter(dbCommand, "Report_Due_Date", DbType.DateTime, this._Report_Due_Date);
			
			db.AddInParameter(dbCommand, "Report_Submission_Date", DbType.DateTime, this._Report_Submission_Date);
			
			db.AddInParameter(dbCommand, "Rejection_Date", DbType.DateTime, this._Rejection_Date);
			
			db.AddInParameter(dbCommand, "Resubmission_Date", DbType.DateTime, this._Resubmission_Date);
			
			if (string.IsNullOrEmpty(this._Initial_Notification))
				db.AddInParameter(dbCommand, "Initial_Notification", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Initial_Notification", DbType.String, this._Initial_Notification);
			
			if (string.IsNullOrEmpty(this._Compliance_Verification))
				db.AddInParameter(dbCommand, "Compliance_Verification", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Compliance_Verification", DbType.String, this._Compliance_Verification);
			
			if (string.IsNullOrEmpty(this._Report_Changes))
				db.AddInParameter(dbCommand, "Report_Changes", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Report_Changes", DbType.String, this._Report_Changes);
			
			db.AddInParameter(dbCommand, "Associated_Fees", DbType.Decimal, this._Associated_Fees);
			
			if (string.IsNullOrEmpty(this._Notes))
				db.AddInParameter(dbCommand, "Notes", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Notes", DbType.String, this._Notes);
			
			if (string.IsNullOrEmpty(this._Updated_By))
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);
			
			db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);

            if (string.IsNullOrEmpty(this._Regualtory_Contact))
                db.AddInParameter(dbCommand, "Regualtory_Contact", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Regualtory_Contact", DbType.String, this._Regualtory_Contact);

            if (string.IsNullOrEmpty(this._Regualtory_Telephone))
                db.AddInParameter(dbCommand, "Regualtory_Telephone", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Regualtory_Telephone", DbType.String, this._Regualtory_Telephone);

            if (string.IsNullOrEmpty(this._Regualtory_Email))
                db.AddInParameter(dbCommand, "Regualtory_Email", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Regualtory_Email", DbType.String, this._Regualtory_Email);

            if (string.IsNullOrEmpty(this._Apply_To_Location))
                db.AddInParameter(dbCommand, "Apply_To_Location", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Apply_To_Location", DbType.String, this._Apply_To_Location);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the PM_CR_Grids table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_PM_CR_Grids)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("PM_CR_GridsDeleteByPK");

			db.AddInParameter(dbCommand, "PK_PM_CR_Grids", DbType.Decimal, pK_PM_CR_Grids);

			db.ExecuteNonQuery(dbCommand);
		}
        /// <summary>
        /// Get Audit View details
        /// </summary>
        /// <param name="pK_PM_SI_Utility_Provider"></param>
        /// <returns></returns>
        public static DataSet GetAuditView(decimal pK_PM_CR_Grids)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("PM_CR_Grids_AuditView");

            db.AddInParameter(dbCommand, "PK_PM_CR_Grids", DbType.Decimal, pK_PM_CR_Grids);

            return db.ExecuteDataSet(dbCommand);
        }
	}
}
