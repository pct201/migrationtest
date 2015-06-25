using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace BAL
{
	/// <summary>
	/// Data access class for table Property_AdHocReport
	/// </summary>
	public sealed class Property_AdHocReport
	{

		#region Private variables used to hold the property values

		private decimal? _Pk_AdHocReport;
		private string _CoverageType;
		private string _ReportName;
		private string _OutputFields;
		private decimal? _FirstGroupBy;
		private decimal? _SecondGroupBy;
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
		private string _FirstGroupByOrder;
		private string _SecondGroupByOrder;
		private decimal? _FK_Schedule;
		private string _PriorValuation_RelativeDate;
		private decimal? _ThirdGroupBy;
		private decimal? _FourthGroupBy;
		private decimal? _FifthGroupBy;
		private decimal? _FourthSortBy;
		private string _FourthSortByOrder;
		private decimal? _FifthSortBy;
		private string _FifthSortByOrder;
		private string _ThirdGroupByOrder;
		private string _FourthGroupByOrder;
		private string _FifthGroupByOrder;

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
		/// Gets or sets the FirstGroupByOrder value.
		/// </summary>
		public string FirstGroupByOrder
		{
			get { return _FirstGroupByOrder; }
			set { _FirstGroupByOrder = value; }
		}

		/// <summary>
		/// Gets or sets the SecondGroupByOrder value.
		/// </summary>
		public string SecondGroupByOrder
		{
			get { return _SecondGroupByOrder; }
			set { _SecondGroupByOrder = value; }
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

		/// <summary>
		/// Gets or sets the ThirdGroupBy value.
		/// </summary>
		public decimal? ThirdGroupBy
		{
			get { return _ThirdGroupBy; }
			set { _ThirdGroupBy = value; }
		}

		/// <summary>
		/// Gets or sets the FourthGroupBy value.
		/// </summary>
		public decimal? FourthGroupBy
		{
			get { return _FourthGroupBy; }
			set { _FourthGroupBy = value; }
		}

		/// <summary>
		/// Gets or sets the FifthGroupBy value.
		/// </summary>
		public decimal? FifthGroupBy
		{
			get { return _FifthGroupBy; }
			set { _FifthGroupBy = value; }
		}

		/// <summary>
		/// Gets or sets the FourthSortBy value.
		/// </summary>
		public decimal? FourthSortBy
		{
			get { return _FourthSortBy; }
			set { _FourthSortBy = value; }
		}

		/// <summary>
		/// Gets or sets the FourthSortByOrder value.
		/// </summary>
		public string FourthSortByOrder
		{
			get { return _FourthSortByOrder; }
			set { _FourthSortByOrder = value; }
		}

		/// <summary>
		/// Gets or sets the FifthSortBy value.
		/// </summary>
		public decimal? FifthSortBy
		{
			get { return _FifthSortBy; }
			set { _FifthSortBy = value; }
		}

		/// <summary>
		/// Gets or sets the FifthSortByOrder value.
		/// </summary>
		public string FifthSortByOrder
		{
			get { return _FifthSortByOrder; }
			set { _FifthSortByOrder = value; }
		}

		/// <summary>
		/// Gets or sets the ThirdGroupByOrder value.
		/// </summary>
		public string ThirdGroupByOrder
		{
			get { return _ThirdGroupByOrder; }
			set { _ThirdGroupByOrder = value; }
		}

		/// <summary>
		/// Gets or sets the FourthGroupByOrder value.
		/// </summary>
		public string FourthGroupByOrder
		{
			get { return _FourthGroupByOrder; }
			set { _FourthGroupByOrder = value; }
		}

		/// <summary>
		/// Gets or sets the FifthGroupByOrder value.
		/// </summary>
		public string FifthGroupByOrder
		{
			get { return _FifthGroupByOrder; }
			set { _FifthGroupByOrder = value; }
		}


		#endregion

		#region Default Constructors

		/// <summary>
		/// Initializes a new instance of the Property_AdHocReport class with default value.
		/// </summary>
		public Property_AdHocReport() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the Property_AdHocReport class based on Primary Key.
		/// </summary>
		public Property_AdHocReport(decimal pk_AdHocReport) 
		{
			DataTable dtProperty_AdHocReport = Select(pk_AdHocReport).Tables[0];

			if (dtProperty_AdHocReport.Rows.Count == 1)
			{
				 SetValue(dtProperty_AdHocReport.Rows[0]);

			}

		}


		/// <summary>
		/// Initializes a new instance of the Property_AdHocReport class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drProperty_AdHocReport) 
		{
				if (drProperty_AdHocReport["Pk_AdHocReport"] == DBNull.Value)
					this._Pk_AdHocReport = null;
				else
					this._Pk_AdHocReport = (decimal?)drProperty_AdHocReport["Pk_AdHocReport"];

				if (drProperty_AdHocReport["CoverageType"] == DBNull.Value)
					this._CoverageType = null;
				else
					this._CoverageType = (string)drProperty_AdHocReport["CoverageType"];

				if (drProperty_AdHocReport["ReportName"] == DBNull.Value)
					this._ReportName = null;
				else
					this._ReportName = (string)drProperty_AdHocReport["ReportName"];

				if (drProperty_AdHocReport["OutputFields"] == DBNull.Value)
					this._OutputFields = null;
				else
					this._OutputFields = (string)drProperty_AdHocReport["OutputFields"];

				if (drProperty_AdHocReport["FirstGroupBy"] == DBNull.Value)
					this._FirstGroupBy = null;
				else
					this._FirstGroupBy = (decimal?)drProperty_AdHocReport["FirstGroupBy"];

				if (drProperty_AdHocReport["SecondGroupBy"] == DBNull.Value)
					this._SecondGroupBy = null;
				else
					this._SecondGroupBy = (decimal?)drProperty_AdHocReport["SecondGroupBy"];

				if (drProperty_AdHocReport["FirstSortBy"] == DBNull.Value)
					this._FirstSortBy = null;
				else
					this._FirstSortBy = (decimal?)drProperty_AdHocReport["FirstSortBy"];

				if (drProperty_AdHocReport["FirstSortByOrder"] == DBNull.Value)
					this._FirstSortByOrder = null;
				else
					this._FirstSortByOrder = (string)drProperty_AdHocReport["FirstSortByOrder"];

				if (drProperty_AdHocReport["SecondSortBy"] == DBNull.Value)
					this._SecondSortBy = null;
				else
					this._SecondSortBy = (decimal?)drProperty_AdHocReport["SecondSortBy"];

				if (drProperty_AdHocReport["SecondSortByOrder"] == DBNull.Value)
					this._SecondSortByOrder = null;
				else
					this._SecondSortByOrder = (string)drProperty_AdHocReport["SecondSortByOrder"];

				if (drProperty_AdHocReport["ThirdSortBy"] == DBNull.Value)
					this._ThirdSortBy = null;
				else
					this._ThirdSortBy = (decimal?)drProperty_AdHocReport["ThirdSortBy"];

				if (drProperty_AdHocReport["ThirdSortByOrder"] == DBNull.Value)
					this._ThirdSortByOrder = null;
				else
					this._ThirdSortByOrder = (string)drProperty_AdHocReport["ThirdSortByOrder"];

				if (drProperty_AdHocReport["PriorValuationDate"] == DBNull.Value)
					this._PriorValuationDate = null;
				else
					this._PriorValuationDate = (DateTime?)drProperty_AdHocReport["PriorValuationDate"];

				if (drProperty_AdHocReport["GrandTotal"] == DBNull.Value)
					this._GrandTotal = null;
				else
					this._GrandTotal = (string)drProperty_AdHocReport["GrandTotal"];

				if (drProperty_AdHocReport["Updated_By"] == DBNull.Value)
					this._Updated_By = null;
				else
					this._Updated_By = (string)drProperty_AdHocReport["Updated_By"];

				if (drProperty_AdHocReport["Update_Date"] == DBNull.Value)
					this._Update_Date = null;
				else
					this._Update_Date = (DateTime?)drProperty_AdHocReport["Update_Date"];

				if (drProperty_AdHocReport["FirstGroupByOrder"] == DBNull.Value)
					this._FirstGroupByOrder = null;
				else
					this._FirstGroupByOrder = (string)drProperty_AdHocReport["FirstGroupByOrder"];

				if (drProperty_AdHocReport["SecondGroupByOrder"] == DBNull.Value)
					this._SecondGroupByOrder = null;
				else
					this._SecondGroupByOrder = (string)drProperty_AdHocReport["SecondGroupByOrder"];

				if (drProperty_AdHocReport["FK_Schedule"] == DBNull.Value)
					this._FK_Schedule = null;
				else
					this._FK_Schedule = (decimal?)drProperty_AdHocReport["FK_Schedule"];

				if (drProperty_AdHocReport["PriorValuation_RelativeDate"] == DBNull.Value)
					this._PriorValuation_RelativeDate = null;
				else
					this._PriorValuation_RelativeDate = (string)drProperty_AdHocReport["PriorValuation_RelativeDate"];

				if (drProperty_AdHocReport["ThirdGroupBy"] == DBNull.Value)
					this._ThirdGroupBy = null;
				else
					this._ThirdGroupBy = (decimal?)drProperty_AdHocReport["ThirdGroupBy"];

				if (drProperty_AdHocReport["FourthGroupBy"] == DBNull.Value)
					this._FourthGroupBy = null;
				else
					this._FourthGroupBy = (decimal?)drProperty_AdHocReport["FourthGroupBy"];

				if (drProperty_AdHocReport["FifthGroupBy"] == DBNull.Value)
					this._FifthGroupBy = null;
				else
					this._FifthGroupBy = (decimal?)drProperty_AdHocReport["FifthGroupBy"];

				if (drProperty_AdHocReport["FourthSortBy"] == DBNull.Value)
					this._FourthSortBy = null;
				else
					this._FourthSortBy = (decimal?)drProperty_AdHocReport["FourthSortBy"];

				if (drProperty_AdHocReport["FourthSortByOrder"] == DBNull.Value)
					this._FourthSortByOrder = null;
				else
					this._FourthSortByOrder = (string)drProperty_AdHocReport["FourthSortByOrder"];

				if (drProperty_AdHocReport["FifthSortBy"] == DBNull.Value)
					this._FifthSortBy = null;
				else
					this._FifthSortBy = (decimal?)drProperty_AdHocReport["FifthSortBy"];

				if (drProperty_AdHocReport["FifthSortByOrder"] == DBNull.Value)
					this._FifthSortByOrder = null;
				else
					this._FifthSortByOrder = (string)drProperty_AdHocReport["FifthSortByOrder"];

				if (drProperty_AdHocReport["ThirdGroupByOrder"] == DBNull.Value)
					this._ThirdGroupByOrder = null;
				else
					this._ThirdGroupByOrder = (string)drProperty_AdHocReport["ThirdGroupByOrder"];

				if (drProperty_AdHocReport["FourthGroupByOrder"] == DBNull.Value)
					this._FourthGroupByOrder = null;
				else
					this._FourthGroupByOrder = (string)drProperty_AdHocReport["FourthGroupByOrder"];

				if (drProperty_AdHocReport["FifthGroupByOrder"] == DBNull.Value)
					this._FifthGroupByOrder = null;
				else
					this._FifthGroupByOrder = (string)drProperty_AdHocReport["FifthGroupByOrder"];


		}

		#endregion

		/// <summary>
		/// Inserts a record into the Property_AdHocReport table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Property_AdHocReportInsert");

			
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
			
			if (string.IsNullOrEmpty(this._FirstGroupByOrder))
				db.AddInParameter(dbCommand, "FirstGroupByOrder", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "FirstGroupByOrder", DbType.String, this._FirstGroupByOrder);
			
			if (string.IsNullOrEmpty(this._SecondGroupByOrder))
				db.AddInParameter(dbCommand, "SecondGroupByOrder", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "SecondGroupByOrder", DbType.String, this._SecondGroupByOrder);
			
			db.AddInParameter(dbCommand, "FK_Schedule", DbType.Decimal, this._FK_Schedule);
			
			if (string.IsNullOrEmpty(this._PriorValuation_RelativeDate))
				db.AddInParameter(dbCommand, "PriorValuation_RelativeDate", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "PriorValuation_RelativeDate", DbType.String, this._PriorValuation_RelativeDate);
			
			db.AddInParameter(dbCommand, "ThirdGroupBy", DbType.Decimal, this._ThirdGroupBy);
			
			db.AddInParameter(dbCommand, "FourthGroupBy", DbType.Decimal, this._FourthGroupBy);
			
			db.AddInParameter(dbCommand, "FifthGroupBy", DbType.Decimal, this._FifthGroupBy);
			
			db.AddInParameter(dbCommand, "FourthSortBy", DbType.Decimal, this._FourthSortBy);
			
			if (string.IsNullOrEmpty(this._FourthSortByOrder))
				db.AddInParameter(dbCommand, "FourthSortByOrder", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "FourthSortByOrder", DbType.String, this._FourthSortByOrder);
			
			db.AddInParameter(dbCommand, "FifthSortBy", DbType.Decimal, this._FifthSortBy);
			
			if (string.IsNullOrEmpty(this._FifthSortByOrder))
				db.AddInParameter(dbCommand, "FifthSortByOrder", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "FifthSortByOrder", DbType.String, this._FifthSortByOrder);
			
			if (string.IsNullOrEmpty(this._ThirdGroupByOrder))
				db.AddInParameter(dbCommand, "ThirdGroupByOrder", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "ThirdGroupByOrder", DbType.String, this._ThirdGroupByOrder);
			
			if (string.IsNullOrEmpty(this._FourthGroupByOrder))
				db.AddInParameter(dbCommand, "FourthGroupByOrder", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "FourthGroupByOrder", DbType.String, this._FourthGroupByOrder);
			
			if (string.IsNullOrEmpty(this._FifthGroupByOrder))
				db.AddInParameter(dbCommand, "FifthGroupByOrder", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "FifthGroupByOrder", DbType.String, this._FifthGroupByOrder);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the Property_AdHocReport table.
		/// </summary>
		/// <returns>DataSet</returns>
		private DataSet Select(decimal pk_AdHocReport)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Property_AdHocReportSelect");

			db.AddInParameter(dbCommand, "Pk_AdHocReport", DbType.Decimal, pk_AdHocReport);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the Property_AdHocReport table.
		/// </summary>
		public void Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Property_AdHocReportUpdate");

			
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
			
			if (string.IsNullOrEmpty(this._FirstGroupByOrder))
				db.AddInParameter(dbCommand, "FirstGroupByOrder", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "FirstGroupByOrder", DbType.String, this._FirstGroupByOrder);
			
			if (string.IsNullOrEmpty(this._SecondGroupByOrder))
				db.AddInParameter(dbCommand, "SecondGroupByOrder", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "SecondGroupByOrder", DbType.String, this._SecondGroupByOrder);
			
			db.AddInParameter(dbCommand, "FK_Schedule", DbType.Decimal, this._FK_Schedule);
			
			if (string.IsNullOrEmpty(this._PriorValuation_RelativeDate))
				db.AddInParameter(dbCommand, "PriorValuation_RelativeDate", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "PriorValuation_RelativeDate", DbType.String, this._PriorValuation_RelativeDate);
			
			db.AddInParameter(dbCommand, "ThirdGroupBy", DbType.Decimal, this._ThirdGroupBy);
			
			db.AddInParameter(dbCommand, "FourthGroupBy", DbType.Decimal, this._FourthGroupBy);
			
			db.AddInParameter(dbCommand, "FifthGroupBy", DbType.Decimal, this._FifthGroupBy);
			
			db.AddInParameter(dbCommand, "FourthSortBy", DbType.Decimal, this._FourthSortBy);
			
			if (string.IsNullOrEmpty(this._FourthSortByOrder))
				db.AddInParameter(dbCommand, "FourthSortByOrder", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "FourthSortByOrder", DbType.String, this._FourthSortByOrder);
			
			db.AddInParameter(dbCommand, "FifthSortBy", DbType.Decimal, this._FifthSortBy);
			
			if (string.IsNullOrEmpty(this._FifthSortByOrder))
				db.AddInParameter(dbCommand, "FifthSortByOrder", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "FifthSortByOrder", DbType.String, this._FifthSortByOrder);
			
			if (string.IsNullOrEmpty(this._ThirdGroupByOrder))
				db.AddInParameter(dbCommand, "ThirdGroupByOrder", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "ThirdGroupByOrder", DbType.String, this._ThirdGroupByOrder);
			
			if (string.IsNullOrEmpty(this._FourthGroupByOrder))
				db.AddInParameter(dbCommand, "FourthGroupByOrder", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "FourthGroupByOrder", DbType.String, this._FourthGroupByOrder);
			
			if (string.IsNullOrEmpty(this._FifthGroupByOrder))
				db.AddInParameter(dbCommand, "FifthGroupByOrder", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "FifthGroupByOrder", DbType.String, this._FifthGroupByOrder);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the Property_AdHocReport table by a composite primary key.
		/// </summary>
		public static void Delete(decimal pk_AdHocReport)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Property_AdHocReportDelete");

			db.AddInParameter(dbCommand, "Pk_AdHocReport", DbType.Decimal, pk_AdHocReport);

			db.ExecuteNonQuery(dbCommand);
		}

        /// <summary>
        /// Select Report Name BY Coverage
        /// </summary>
        /// <param name="CoverageType"></param>
        /// <returns></returns>
        public static DataSet SelectReportName()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Property_AdHocReportNameSelect");

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
            DbCommand dbCommand = db.GetStoredProcCommand("Property_AdHocReportExistsReport");

            db.AddInParameter(dbCommand, "@ReportName", DbType.String, ReportName);
            db.AddInParameter(dbCommand, "@Pk_ID", DbType.Decimal, pk_AdHocReport);

            return db.ExecuteDataSet(dbCommand).Tables[0];

        }
	}
}
