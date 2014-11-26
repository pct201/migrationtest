using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for PM_Remediation_Grid table.
	/// </summary>
	public sealed class PM_Remediation_Grid
	{

		#region Private variables used to hold the property values

		private decimal? _PK_PM_Remediation_Grid;
		private decimal? _FK_PM_Remediation;
        private string _Description;
		private string _Assessor;
		private string _Contact_Name;
		private string _Contact_Telephone;
		private DateTime? _Report_Date;
		private decimal? _Cost;
		private DateTime? _Next_Review_Date;
		private DateTime? _Next_Report_Date;
		private string _Recommendations;
        private decimal? _FK_LU_Result_Of;
        private string _Describe;
        private string _Analytical_Tests;
        private string _Analytical_Desciption;        
        private string _Letter_Obtained;
        private string _Post_Remediation_Other;
        private decimal? _FK_LU_PM_Remediation_Type;
        private decimal? _FK_PM_Violation;
		private string _Updated_By;
		private DateTime? _Update_Date;
        private string _Apply_To_Location;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_PM_Remediation_Grid value.
		/// </summary>
		public decimal? PK_PM_Remediation_Grid
		{
			get { return _PK_PM_Remediation_Grid; }
			set { _PK_PM_Remediation_Grid = value; }
		}

		/// <summary>
		/// Gets or sets the FK_PM_Remediation value.
		/// </summary>
		public decimal? FK_PM_Remediation
		{
			get { return _FK_PM_Remediation; }
			set { _FK_PM_Remediation = value; }
		}

		/// <summary>
        /// Gets or sets the Description value.
		/// </summary>
        public string Description
		{
            get { return _Description; }
            set { _Description = value; }
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
        /// Gets or sets the FK_LU_Result_Of value.
        /// </summary>
        public decimal? FK_LU_Result_Of
        {
            get { return _FK_LU_Result_Of; }
            set { _FK_LU_Result_Of = value; }
        }

        /// <summary>
        /// Gets or sets the Describe value.
        /// </summary>
        public string Describe
        {
            get { return _Describe; }
            set { _Describe = value; }
        }

        /// <summary>
        /// Gets or sets the Analytical_Tests value.
        /// </summary>
        public string Analytical_Tests
        {
            get { return _Analytical_Tests; }
            set { _Analytical_Tests = value; }
        }

        /// <summary>
        /// Gets or sets the Analytical_Desciption value.
        /// </summary>
        public string Analytical_Desciption
        {
            get { return _Analytical_Desciption; }
            set { _Analytical_Desciption = value; }
        }

        /// <summary>
        /// Gets or sets the Letter_Obtained value.
        /// </summary>
        public string Letter_Obtained
        {
            get { return _Letter_Obtained; }
            set { _Letter_Obtained = value; }
        }

        /// <summary>
        /// Gets or sets the Post_Remediation_Other value.
        /// </summary>
        public string Post_Remediation_Other
        {
            get { return _Post_Remediation_Other; }
            set { _Post_Remediation_Other = value; }
        }

        /// <summary>
        /// Gets or sets the FK_LU_PM_Remediation_Type value.
        /// </summary>
        public decimal? FK_LU_PM_Remediation_Type
        {
            get { return _FK_LU_PM_Remediation_Type; }
            set { _FK_LU_PM_Remediation_Type = value; }
        }

        /// <summary>
        /// Gets or sets the FK_PM_Violation value.
        /// </summary>
        public decimal? FK_PM_Violation
        {
            get { return _FK_PM_Violation; }
            set { _FK_PM_Violation = value; }
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

        public string Apply_To_Location
        {
            get { return _Apply_To_Location; }
            set { _Apply_To_Location = value; }
        }
		#endregion

		#region Default Constructors

		/// <summary>
		/// Initializes a new instance of the PM_Remediation_Grid class with default value.
		/// </summary>
		public PM_Remediation_Grid() 
		{

			this._PK_PM_Remediation_Grid = null;
			this._FK_PM_Remediation = null;
            this._Description = null;
			this._Assessor = null;
			this._Contact_Name = null;
			this._Contact_Telephone = null;
			this._Report_Date = null;
			this._Cost = null;
			this._Next_Review_Date = null;
			this._Next_Report_Date = null;
			this._Recommendations = null;
            this._FK_LU_Result_Of = null;
            this._Describe = null;
            this._Analytical_Tests = null;
            this._Analytical_Desciption = null;
            this._Letter_Obtained = null;
            this._Post_Remediation_Other = null;
            this._FK_LU_PM_Remediation_Type = null;
            this._FK_PM_Violation = null;
			this._Updated_By = null;
			this._Update_Date = null;

		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the PM_Remediation_Grid class based on Primary Key.
		/// </summary>
		public PM_Remediation_Grid(decimal pK_PM_Remediation_Grid) 
		{
			DataTable dtPM_Remediation_Grid = SelectByPK(pK_PM_Remediation_Grid).Tables[0];

			if (dtPM_Remediation_Grid.Rows.Count == 1)
			{
				DataRow drPM_Remediation_Grid = dtPM_Remediation_Grid.Rows[0];
				if (drPM_Remediation_Grid["PK_PM_Remediation_Grid"] == DBNull.Value)
					this._PK_PM_Remediation_Grid = null;
				else
					this._PK_PM_Remediation_Grid = (decimal?)drPM_Remediation_Grid["PK_PM_Remediation_Grid"];

				if (drPM_Remediation_Grid["FK_PM_Remediation"] == DBNull.Value)
					this._FK_PM_Remediation = null;
				else
					this._FK_PM_Remediation = (decimal?)drPM_Remediation_Grid["FK_PM_Remediation"];

                if (drPM_Remediation_Grid["Description"] == DBNull.Value)
                    this._Description = null;
				else
                    this._Description = (string)drPM_Remediation_Grid["Description"];

				if (drPM_Remediation_Grid["Assessor"] == DBNull.Value)
					this._Assessor = null;
				else
					this._Assessor = (string)drPM_Remediation_Grid["Assessor"];

				if (drPM_Remediation_Grid["Contact_Name"] == DBNull.Value)
					this._Contact_Name = null;
				else
					this._Contact_Name = (string)drPM_Remediation_Grid["Contact_Name"];

				if (drPM_Remediation_Grid["Contact_Telephone"] == DBNull.Value)
					this._Contact_Telephone = null;
				else
					this._Contact_Telephone = (string)drPM_Remediation_Grid["Contact_Telephone"];

				if (drPM_Remediation_Grid["Report_Date"] == DBNull.Value)
					this._Report_Date = null;
				else
					this._Report_Date = (DateTime?)drPM_Remediation_Grid["Report_Date"];

				if (drPM_Remediation_Grid["Cost"] == DBNull.Value)
					this._Cost = null;
				else
					this._Cost = (decimal?)drPM_Remediation_Grid["Cost"];

				if (drPM_Remediation_Grid["Next_Review_Date"] == DBNull.Value)
					this._Next_Review_Date = null;
				else
					this._Next_Review_Date = (DateTime?)drPM_Remediation_Grid["Next_Review_Date"];

				if (drPM_Remediation_Grid["Next_Report_Date"] == DBNull.Value)
					this._Next_Report_Date = null;
				else
					this._Next_Report_Date = (DateTime?)drPM_Remediation_Grid["Next_Report_Date"];

				if (drPM_Remediation_Grid["Recommendations"] == DBNull.Value)
					this._Recommendations = null;
				else
					this._Recommendations = (string)drPM_Remediation_Grid["Recommendations"];

                if (drPM_Remediation_Grid["FK_LU_Result_Of"] == DBNull.Value)
                    this._FK_LU_Result_Of = null;
                else
                    this._FK_LU_Result_Of = (decimal?)drPM_Remediation_Grid["FK_LU_Result_Of"];

                if (drPM_Remediation_Grid["Describe"] == DBNull.Value)
                    this._Describe = null;
                else
                    this._Describe = (string)drPM_Remediation_Grid["Describe"];

                if (drPM_Remediation_Grid["Analytical_Tests"] == DBNull.Value)
                    this._Analytical_Tests = null;
                else
                    this._Analytical_Tests = (string)drPM_Remediation_Grid["Analytical_Tests"];

                if (drPM_Remediation_Grid["Analytical_Desciption"] == DBNull.Value)
                    this._Analytical_Desciption = null;
                else
                    this._Analytical_Desciption = (string)drPM_Remediation_Grid["Analytical_Desciption"];

                if (drPM_Remediation_Grid["Letter_Obtained"] == DBNull.Value)
                    this._Letter_Obtained = null;
                else
                    this._Letter_Obtained = (string)drPM_Remediation_Grid["Letter_Obtained"];

                if (drPM_Remediation_Grid["Post_Remediation_Other"] == DBNull.Value)
                    this._Post_Remediation_Other = null;
                else
                    this._Post_Remediation_Other = (string)drPM_Remediation_Grid["Post_Remediation_Other"];

                if (drPM_Remediation_Grid["FK_LU_PM_Remediation_Type"] == DBNull.Value)
                    this._FK_LU_PM_Remediation_Type = null;
                else
                    this._FK_LU_PM_Remediation_Type = (decimal?)drPM_Remediation_Grid["FK_LU_PM_Remediation_Type"];

                if (drPM_Remediation_Grid["FK_PM_Violation"] == DBNull.Value)
                    this._FK_PM_Violation = null;
                else
                    this._FK_PM_Violation = (decimal?)drPM_Remediation_Grid["FK_PM_Violation"];

				if (drPM_Remediation_Grid["Updated_By"] == DBNull.Value)
					this._Updated_By = null;
				else
					this._Updated_By = (string)drPM_Remediation_Grid["Updated_By"];

				if (drPM_Remediation_Grid["Update_Date"] == DBNull.Value)
					this._Update_Date = null;
				else
					this._Update_Date = (DateTime?)drPM_Remediation_Grid["Update_Date"];

                if (drPM_Remediation_Grid["Apply_To_Location"] == DBNull.Value)
                    this._Apply_To_Location = null;
                else
                    this._Apply_To_Location = (string)drPM_Remediation_Grid["Apply_To_Location"];

			}
			else
			{
				this._PK_PM_Remediation_Grid = null;
				this._FK_PM_Remediation = null;
                this._Description = null;
				this._Assessor = null;
				this._Contact_Name = null;
				this._Contact_Telephone = null;
				this._Report_Date = null;
				this._Cost = null;
				this._Next_Review_Date = null;
				this._Next_Report_Date = null;
				this._Recommendations = null;
                this._FK_LU_Result_Of = null;
                this._Describe = null;
                this._Analytical_Tests = null;
                this._Analytical_Desciption = null;
                this._Letter_Obtained = null;
                this._Post_Remediation_Other = null;
                this._FK_LU_PM_Remediation_Type = null;
                this._FK_PM_Violation = null;
				this._Updated_By = null;
				this._Update_Date = null;
			}

		}

		#endregion

		/// <summary>
		/// Inserts a record into the PM_Remediation_Grid table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("PM_Remediation_GridInsert");

			
			db.AddInParameter(dbCommand, "FK_PM_Remediation", DbType.Decimal, this._FK_PM_Remediation);

            if (string.IsNullOrEmpty(this._Description))
                db.AddInParameter(dbCommand, "Description", DbType.String, DBNull.Value);
			else
                db.AddInParameter(dbCommand, "Description", DbType.String, this._Description);
			
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

            db.AddInParameter(dbCommand, "FK_LU_Result_Of", DbType.Decimal, this._FK_LU_Result_Of);

            if (string.IsNullOrEmpty(this._Describe))
                db.AddInParameter(dbCommand, "Describe", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Describe", DbType.String, this._Describe);
            
            if (string.IsNullOrEmpty(this._Analytical_Tests))
                db.AddInParameter(dbCommand, "Analytical_Tests", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Analytical_Tests", DbType.String, this._Analytical_Tests);

            if (string.IsNullOrEmpty(this._Analytical_Desciption))
                db.AddInParameter(dbCommand, "Analytical_Desciption", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Analytical_Desciption", DbType.String, this._Analytical_Desciption);

            if (string.IsNullOrEmpty(this._Letter_Obtained))
                db.AddInParameter(dbCommand, "Letter_Obtained", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Letter_Obtained", DbType.String, this._Letter_Obtained);

            if (string.IsNullOrEmpty(this._Post_Remediation_Other))
                db.AddInParameter(dbCommand, "Post_Remediation_Other", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Post_Remediation_Other", DbType.String, this._Post_Remediation_Other);

            db.AddInParameter(dbCommand, "FK_LU_PM_Remediation_Type", DbType.Decimal, this._FK_LU_PM_Remediation_Type);

            db.AddInParameter(dbCommand, "FK_PM_Violation", DbType.Decimal, this._FK_PM_Violation);
			
			if (string.IsNullOrEmpty(this._Updated_By))
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);
			
			db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);

            if (string.IsNullOrEmpty(this._Apply_To_Location))
                db.AddInParameter(dbCommand, "Apply_To_Location", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Apply_To_Location", DbType.String, this._Apply_To_Location);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the PM_Remediation_Grid table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		private static DataSet SelectByPK(decimal pK_PM_Remediation_Grid)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("PM_Remediation_GridSelectByPK");

			db.AddInParameter(dbCommand, "PK_PM_Remediation_Grid", DbType.Decimal, pK_PM_Remediation_Grid);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the PM_Remediation_Grid table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("PM_Remediation_GridSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the PM_Remediation_Grid table.
		/// </summary>
		public int Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("PM_Remediation_GridUpdate");

			
			db.AddInParameter(dbCommand, "PK_PM_Remediation_Grid", DbType.Decimal, this._PK_PM_Remediation_Grid);
			
			db.AddInParameter(dbCommand, "FK_PM_Remediation", DbType.Decimal, this._FK_PM_Remediation);

            if (string.IsNullOrEmpty(this._Description))
                db.AddInParameter(dbCommand, "Description", DbType.String, DBNull.Value);
			else
                db.AddInParameter(dbCommand, "Description", DbType.String, this._Description);
			
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

            db.AddInParameter(dbCommand, "FK_LU_Result_Of", DbType.Decimal, this._FK_LU_Result_Of);

            if (string.IsNullOrEmpty(this._Describe))
                db.AddInParameter(dbCommand, "Describe", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Describe", DbType.String, this._Describe);

            if (string.IsNullOrEmpty(this._Analytical_Tests))
                db.AddInParameter(dbCommand, "Analytical_Tests", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Analytical_Tests", DbType.String, this._Analytical_Tests);

            if (string.IsNullOrEmpty(this._Analytical_Desciption))
                db.AddInParameter(dbCommand, "Analytical_Desciption", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Analytical_Desciption", DbType.String, this._Analytical_Desciption);

            if (string.IsNullOrEmpty(this._Letter_Obtained))
                db.AddInParameter(dbCommand, "Letter_Obtained", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Letter_Obtained", DbType.String, this._Letter_Obtained);

            if (string.IsNullOrEmpty(this._Post_Remediation_Other))
                db.AddInParameter(dbCommand, "Post_Remediation_Other", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Post_Remediation_Other", DbType.String, this._Post_Remediation_Other);

            db.AddInParameter(dbCommand, "FK_LU_PM_Remediation_Type", DbType.Decimal, this._FK_LU_PM_Remediation_Type);

            db.AddInParameter(dbCommand, "FK_PM_Violation", DbType.Decimal, this._FK_PM_Violation);

			if (string.IsNullOrEmpty(this._Updated_By))
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);
			
			db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);
            if (string.IsNullOrEmpty(this._Apply_To_Location))
                db.AddInParameter(dbCommand, "Apply_To_Location", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Apply_To_Location", DbType.String, this._Apply_To_Location);
            // Execute the query and return the new identity value
            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
		}

		/// <summary>
		/// Deletes a record from the PM_Remediation_Grid table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_PM_Remediation_Grid)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("PM_Remediation_GridDeleteByPK");

			db.AddInParameter(dbCommand, "PK_PM_Remediation_Grid", DbType.Decimal, pK_PM_Remediation_Grid);

			db.ExecuteNonQuery(dbCommand);
		}

        public static DataSet SelectByFK_SiteInfo(decimal fK_PM_Site_Information)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("PM_Remediation_GridSelectByFK");

            db.AddInParameter(dbCommand, "FK_PM_Site_Information", DbType.Decimal, fK_PM_Site_Information);

            return db.ExecuteDataSet(dbCommand);
        }
        /// <summary>
        /// Get Audit View details
        /// </summary>
        /// <param name="pK_PM_SI_Utility_Provider"></param>
        /// <returns></returns>
        public static DataSet GetAuditView(decimal pK_PM_Remediation_Grid)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("PM_Remediation_Grid_AuditView");

            db.AddInParameter(dbCommand, "PK_PM_Remediation_Grid", DbType.Decimal, pK_PM_Remediation_Grid);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Get Violation details
        /// </summary>
        /// <param name="fK_PM_Site_Information"></param>
        /// <returns></returns>
        public static DataSet GetViolations(decimal fK_PM_Site_Information)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("GetViolationBySite");

            db.AddInParameter(dbCommand, "FK_PM_Site_Information", DbType.Decimal, fK_PM_Site_Information);

            return db.ExecuteDataSet(dbCommand);
        }
	}
}
