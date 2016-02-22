using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for table Property_Claims_AdHocReport
	/// </summary>
	public sealed class Property_Claims_AdHocReport
	{

		#region Private variables used to hold the property values

		private decimal? _Pk_AdHocReport;
		private string _CoverageType;
		private string _ReportName;
		private string _OutputFields;
		private decimal? _FirstGroupBy;
		private decimal? _SecondGroupBy;
		private decimal? _ThirdGroupBy;
		private decimal? _FirstSortBy;
		private string _FirstSortByOrder;
		private decimal? _SecondSortBy;
		private string _SecondSortByOrder;
		private decimal? _ThirdSortBy;
		private string _ThirdSortByOrder;
		private DateTime? _PriorValuationDate;
		private string _GrandTotal;
		private string _Updated_By;
		private DateTime? _Update_Date;
		private decimal? _FK_Schedule;
		private string _PriorValuation_RelativeDate;
        private string _FirstGroupByOrder;
        private string _SecondGroupByOrder;
        private string _ThirdGroupByOrder;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the Pk_AdHocReport value.
		/// </summary>
		public decimal? Pk_AdHocReport
		{
			get { return _Pk_AdHocReport; }
			set { _Pk_AdHocReport = value; }
		}

		/// <summary>
		/// Gets or sets the CoverageType value.
		/// </summary>
		public string CoverageType
		{
			get { return _CoverageType; }
			set { _CoverageType = value; }
		}

		/// <summary>
		/// Gets or sets the ReportName value.
		/// </summary>
		public string ReportName
		{
			get { return _ReportName; }
			set { _ReportName = value; }
		}

		/// <summary>
		/// Gets or sets the OutputFields value.
		/// </summary>
		public string OutputFields
		{
			get { return _OutputFields; }
			set { _OutputFields = value; }
		}

		/// <summary>
		/// Gets or sets the FirstGroupBy value.
		/// </summary>
		public decimal? FirstGroupBy
		{
			get { return _FirstGroupBy; }
			set { _FirstGroupBy = value; }
		}

		/// <summary>
		/// Gets or sets the SecondGroupBy value.
		/// </summary>
		public decimal? SecondGroupBy
		{
			get { return _SecondGroupBy; }
			set { _SecondGroupBy = value; }
		}

		/// <summary>
		/// Gets or sets the ThirdGroupBy value.
		/// </summary>
		public decimal? ThirdGroupBy
		{
			get { return _ThirdGroupBy; }
			set { _ThirdGroupBy = value; }
		}

		/// <summary>
		/// Gets or sets the FirstSortBy value.
		/// </summary>
		public decimal? FirstSortBy
		{
			get { return _FirstSortBy; }
			set { _FirstSortBy = value; }
		}

		/// <summary>
		/// Gets or sets the FirstSortByOrder value.
		/// </summary>
		public string FirstSortByOrder
		{
			get { return _FirstSortByOrder; }
			set { _FirstSortByOrder = value; }
		}

		/// <summary>
		/// Gets or sets the SecondSortBy value.
		/// </summary>
		public decimal? SecondSortBy
		{
			get { return _SecondSortBy; }
			set { _SecondSortBy = value; }
		}

		/// <summary>
		/// Gets or sets the SecondSortByOrder value.
		/// </summary>
		public string SecondSortByOrder
		{
			get { return _SecondSortByOrder; }
			set { _SecondSortByOrder = value; }
		}

		/// <summary>
		/// Gets or sets the ThirdSortBy value.
		/// </summary>
		public decimal? ThirdSortBy
		{
			get { return _ThirdSortBy; }
			set { _ThirdSortBy = value; }
		}

        /// <summary>
        /// Gets or sets the FirstGroupByOrder value.
        /// </summary>
        public string FirstGroupByOrder
        {
            get { return _FirstGroupByOrder; }
            set { _FirstGroupByOrder = value; }
        }

        /// <summary>
        /// Gets or sets the FirstGroupByOrder value.
        /// </summary>
        public string SecondGroupByOrder
        {
            get { return _SecondGroupByOrder; }
            set { _SecondGroupByOrder = value; }
        }

        /// <summary>
        /// Gets or sets the FirstGroupByOrder value.
        /// </summary>
        public string ThirdGroupByOrder
        {
            get { return _ThirdGroupByOrder; }
            set { _ThirdGroupByOrder = value; }
        }

		/// <summary>
		/// Gets or sets the ThirdSortByOrder value.
		/// </summary>
		public string ThirdSortByOrder
		{
			get { return _ThirdSortByOrder; }
			set { _ThirdSortByOrder = value; }
		}

		/// <summary>
		/// Gets or sets the PriorValuationDate value.
		/// </summary>
		public DateTime? PriorValuationDate
		{
			get { return _PriorValuationDate; }
			set { _PriorValuationDate = value; }
		}

		/// <summary>
		/// Gets or sets the GrandTotal value.
		/// </summary>
		public string GrandTotal
		{
			get { return _GrandTotal; }
			set { _GrandTotal = value; }
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
		/// Gets or sets the FK_Schedule value.
		/// </summary>
		public decimal? FK_Schedule
		{
			get { return _FK_Schedule; }
			set { _FK_Schedule = value; }
		}

		/// <summary>
		/// Gets or sets the PriorValuation_RelativeDate value.
		/// </summary>
		public string PriorValuation_RelativeDate
		{
			get { return _PriorValuation_RelativeDate; }
			set { _PriorValuation_RelativeDate = value; }
		}


		#endregion

		#region Default Constructors

		/// <summary>
		/// Initializes a new instance of the Property_Claims_AdHocReport class with default value.
		/// </summary>
		public Property_Claims_AdHocReport() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the Property_Claims_AdHocReport class based on Primary Key.
		/// </summary>
		public Property_Claims_AdHocReport(decimal pk_AdHocReport) 
		{
			DataTable dtProperty_Claims_AdHocReport = Select(pk_AdHocReport).Tables[0];

			if (dtProperty_Claims_AdHocReport.Rows.Count == 1)
			{
				 SetValue(dtProperty_Claims_AdHocReport.Rows[0]);

			}

		}


		/// <summary>
		/// Initializes a new instance of the Property_Claims_AdHocReport class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drProperty_Claims_AdHocReport) 
		{
				if (drProperty_Claims_AdHocReport["Pk_AdHocReport"] == DBNull.Value)
					this._Pk_AdHocReport = null;
				else
					this._Pk_AdHocReport = (decimal?)drProperty_Claims_AdHocReport["Pk_AdHocReport"];

				if (drProperty_Claims_AdHocReport["CoverageType"] == DBNull.Value)
					this._CoverageType = null;
				else
					this._CoverageType = (string)drProperty_Claims_AdHocReport["CoverageType"];

				if (drProperty_Claims_AdHocReport["ReportName"] == DBNull.Value)
					this._ReportName = null;
				else
					this._ReportName = (string)drProperty_Claims_AdHocReport["ReportName"];

				if (drProperty_Claims_AdHocReport["OutputFields"] == DBNull.Value)
					this._OutputFields = null;
				else
					this._OutputFields = (string)drProperty_Claims_AdHocReport["OutputFields"];

				if (drProperty_Claims_AdHocReport["FirstGroupBy"] == DBNull.Value)
					this._FirstGroupBy = null;
				else
					this._FirstGroupBy = (decimal?)drProperty_Claims_AdHocReport["FirstGroupBy"];

				if (drProperty_Claims_AdHocReport["SecondGroupBy"] == DBNull.Value)
					this._SecondGroupBy = null;
				else
					this._SecondGroupBy = (decimal?)drProperty_Claims_AdHocReport["SecondGroupBy"];

				if (drProperty_Claims_AdHocReport["ThirdGroupBy"] == DBNull.Value)
					this._ThirdGroupBy = null;
				else
					this._ThirdGroupBy = (decimal?)drProperty_Claims_AdHocReport["ThirdGroupBy"];

				if (drProperty_Claims_AdHocReport["FirstSortBy"] == DBNull.Value)
					this._FirstSortBy = null;
				else
					this._FirstSortBy = (decimal?)drProperty_Claims_AdHocReport["FirstSortBy"];

				if (drProperty_Claims_AdHocReport["FirstSortByOrder"] == DBNull.Value)
					this._FirstSortByOrder = null;
				else
					this._FirstSortByOrder = (string)drProperty_Claims_AdHocReport["FirstSortByOrder"];

				if (drProperty_Claims_AdHocReport["SecondSortBy"] == DBNull.Value)
					this._SecondSortBy = null;
				else
					this._SecondSortBy = (decimal?)drProperty_Claims_AdHocReport["SecondSortBy"];

				if (drProperty_Claims_AdHocReport["SecondSortByOrder"] == DBNull.Value)
					this._SecondSortByOrder = null;
				else
					this._SecondSortByOrder = (string)drProperty_Claims_AdHocReport["SecondSortByOrder"];

				if (drProperty_Claims_AdHocReport["ThirdSortBy"] == DBNull.Value)
					this._ThirdSortBy = null;
				else
					this._ThirdSortBy = (decimal?)drProperty_Claims_AdHocReport["ThirdSortBy"];

				if (drProperty_Claims_AdHocReport["ThirdSortByOrder"] == DBNull.Value)
					this._ThirdSortByOrder = null;
				else
					this._ThirdSortByOrder = (string)drProperty_Claims_AdHocReport["ThirdSortByOrder"];

				if (drProperty_Claims_AdHocReport["PriorValuationDate"] == DBNull.Value)
					this._PriorValuationDate = null;
				else
					this._PriorValuationDate = (DateTime?)drProperty_Claims_AdHocReport["PriorValuationDate"];

				if (drProperty_Claims_AdHocReport["GrandTotal"] == DBNull.Value)
					this._GrandTotal = null;
				else
					this._GrandTotal = (string)drProperty_Claims_AdHocReport["GrandTotal"];

				if (drProperty_Claims_AdHocReport["Updated_By"] == DBNull.Value)
					this._Updated_By = null;
				else
					this._Updated_By = (string)drProperty_Claims_AdHocReport["Updated_By"];

				if (drProperty_Claims_AdHocReport["Update_Date"] == DBNull.Value)
					this._Update_Date = null;
				else
					this._Update_Date = (DateTime?)drProperty_Claims_AdHocReport["Update_Date"];

				if (drProperty_Claims_AdHocReport["FK_Schedule"] == DBNull.Value)
					this._FK_Schedule = null;
				else
					this._FK_Schedule = (decimal?)drProperty_Claims_AdHocReport["FK_Schedule"];

				if (drProperty_Claims_AdHocReport["PriorValuation_RelativeDate"] == DBNull.Value)
					this._PriorValuation_RelativeDate = null;
				else
					this._PriorValuation_RelativeDate = (string)drProperty_Claims_AdHocReport["PriorValuation_RelativeDate"];


		}

		#endregion

		/// <summary>
		/// Inserts a record into the Property_Claims_AdHocReport table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Property_Claims_AdHocReportInsert");

			
			if (string.IsNullOrEmpty(this._CoverageType))
				db.AddInParameter(dbCommand, "CoverageType", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "CoverageType", DbType.String, this._CoverageType);
			
			if (string.IsNullOrEmpty(this._ReportName))
				db.AddInParameter(dbCommand, "ReportName", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "ReportName", DbType.String, this._ReportName);
			
			if (string.IsNullOrEmpty(this._OutputFields))
				db.AddInParameter(dbCommand, "OutputFields", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "OutputFields", DbType.String, this._OutputFields);
			
			db.AddInParameter(dbCommand, "FirstGroupBy", DbType.Decimal, this._FirstGroupBy);
			
			db.AddInParameter(dbCommand, "SecondGroupBy", DbType.Decimal, this._SecondGroupBy);
			
			db.AddInParameter(dbCommand, "ThirdGroupBy", DbType.Decimal, this._ThirdGroupBy);
			
			db.AddInParameter(dbCommand, "FirstSortBy", DbType.Decimal, this._FirstSortBy);
			
			if (string.IsNullOrEmpty(this._FirstSortByOrder))
				db.AddInParameter(dbCommand, "FirstSortByOrder", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "FirstSortByOrder", DbType.String, this._FirstSortByOrder);
			
			db.AddInParameter(dbCommand, "SecondSortBy", DbType.Decimal, this._SecondSortBy);
			
			if (string.IsNullOrEmpty(this._SecondSortByOrder))
				db.AddInParameter(dbCommand, "SecondSortByOrder", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "SecondSortByOrder", DbType.String, this._SecondSortByOrder);
			
			db.AddInParameter(dbCommand, "ThirdSortBy", DbType.Decimal, this._ThirdSortBy);
			
			if (string.IsNullOrEmpty(this._ThirdSortByOrder))
				db.AddInParameter(dbCommand, "ThirdSortByOrder", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "ThirdSortByOrder", DbType.String, this._ThirdSortByOrder);
			
			db.AddInParameter(dbCommand, "PriorValuationDate", DbType.DateTime, this._PriorValuationDate);
			
			if (string.IsNullOrEmpty(this._GrandTotal))
				db.AddInParameter(dbCommand, "GrandTotal", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "GrandTotal", DbType.String, this._GrandTotal);
			
			if (string.IsNullOrEmpty(this._Updated_By))
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);
			
			db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);
			
			db.AddInParameter(dbCommand, "FK_Schedule", DbType.Decimal, this._FK_Schedule);
			
			if (string.IsNullOrEmpty(this._PriorValuation_RelativeDate))
				db.AddInParameter(dbCommand, "PriorValuation_RelativeDate", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "PriorValuation_RelativeDate", DbType.String, this._PriorValuation_RelativeDate);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the Property_Claims_AdHocReport table.
		/// </summary>
		/// <returns>DataSet</returns>
		private DataSet Select(decimal pk_AdHocReport)
		{
			Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Property_Claims_AdHocReportSelectByPK");

			db.AddInParameter(dbCommand, "Pk_AdHocReport", DbType.Decimal, pk_AdHocReport);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the Property_Claims_AdHocReport table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Property_Claims_AdHocReportSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the Property_Claims_AdHocReport table.
		/// </summary>
		public void Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Property_Claims_AdHocReportUpdate");

			
			db.AddInParameter(dbCommand, "Pk_AdHocReport", DbType.Decimal, this._Pk_AdHocReport);
			
			if (string.IsNullOrEmpty(this._CoverageType))
				db.AddInParameter(dbCommand, "CoverageType", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "CoverageType", DbType.String, this._CoverageType);
			
			if (string.IsNullOrEmpty(this._ReportName))
				db.AddInParameter(dbCommand, "ReportName", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "ReportName", DbType.String, this._ReportName);
			
			if (string.IsNullOrEmpty(this._OutputFields))
				db.AddInParameter(dbCommand, "OutputFields", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "OutputFields", DbType.String, this._OutputFields);
			
			db.AddInParameter(dbCommand, "FirstGroupBy", DbType.Decimal, this._FirstGroupBy);
			
			db.AddInParameter(dbCommand, "SecondGroupBy", DbType.Decimal, this._SecondGroupBy);
			
			db.AddInParameter(dbCommand, "ThirdGroupBy", DbType.Decimal, this._ThirdGroupBy);
			
			db.AddInParameter(dbCommand, "FirstSortBy", DbType.Decimal, this._FirstSortBy);
			
			if (string.IsNullOrEmpty(this._FirstSortByOrder))
				db.AddInParameter(dbCommand, "FirstSortByOrder", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "FirstSortByOrder", DbType.String, this._FirstSortByOrder);
			
			db.AddInParameter(dbCommand, "SecondSortBy", DbType.Decimal, this._SecondSortBy);
			
			if (string.IsNullOrEmpty(this._SecondSortByOrder))
				db.AddInParameter(dbCommand, "SecondSortByOrder", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "SecondSortByOrder", DbType.String, this._SecondSortByOrder);
			
			db.AddInParameter(dbCommand, "ThirdSortBy", DbType.Decimal, this._ThirdSortBy);
			
			if (string.IsNullOrEmpty(this._ThirdSortByOrder))
				db.AddInParameter(dbCommand, "ThirdSortByOrder", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "ThirdSortByOrder", DbType.String, this._ThirdSortByOrder);
			
			db.AddInParameter(dbCommand, "PriorValuationDate", DbType.DateTime, this._PriorValuationDate);
			
			if (string.IsNullOrEmpty(this._GrandTotal))
				db.AddInParameter(dbCommand, "GrandTotal", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "GrandTotal", DbType.String, this._GrandTotal);
			
			if (string.IsNullOrEmpty(this._Updated_By))
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);
			
			db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);
			
			db.AddInParameter(dbCommand, "FK_Schedule", DbType.Decimal, this._FK_Schedule);
			
			if (string.IsNullOrEmpty(this._PriorValuation_RelativeDate))
				db.AddInParameter(dbCommand, "PriorValuation_RelativeDate", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "PriorValuation_RelativeDate", DbType.String, this._PriorValuation_RelativeDate);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the Property_Claims_AdHocReport table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pk_AdHocReport)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Property_Claims_AdHocReportDelete");

			db.AddInParameter(dbCommand, "Pk_AdHocReport", DbType.Decimal, pk_AdHocReport);

			db.ExecuteNonQuery(dbCommand);
		}

        /// <summary>
        /// Select Report Name 
        /// </summary>
        /// <param name="CoverageType"></param>
        /// <returns></returns>
        public static DataSet SelectReportName()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Property_Claims_AdHocReportSelect");

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Check Report name is exists by Coverage 
        /// </summary>
        /// <param name="CoverageType"></param>
        /// <returns></returns>
        public static DataTable ExistsReportName(string ReportName, decimal pk_AdHocReport)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Property_Claims_AdHocReportExistsReport");

            db.AddInParameter(dbCommand, "@ReportName", DbType.String, ReportName);
            db.AddInParameter(dbCommand, "@Pk_ID", DbType.Decimal, pk_AdHocReport);

            return db.ExecuteDataSet(dbCommand).Tables[0];

        }
	}
}
