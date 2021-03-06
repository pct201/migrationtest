using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for DealershipDetails_AdHocReport table.
	/// </summary>
	public sealed class DealershipDetails_AdHocReport
	{

		#region Private variables used to hold the property values

		private decimal? _Pk_AdHocReport;
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
		private string _Updated_By;
		private DateTime? _Update_Date;
		private string _FirstGroupByOrder;
		private string _SecondGroupByOrder;
		private decimal? _FK_Schedule;

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


		#endregion

		#region Default Constructors

		/// <summary>
		/// Initializes a new instance of the clsDealershipDetails_AdHocReport class with default value.
		/// </summary>
        public DealershipDetails_AdHocReport() 
		{


		}
		#endregion		

         #region Primary Constructors

        /// <summary>
        /// Initializes a new instance of the AdHocReport class based on Primary Key.
        /// </summary>
        public DealershipDetails_AdHocReport(decimal pk_AdHocReport)
        {
            DataTable dtAdHocReport = SelectByPK(pk_AdHocReport).Tables[0];

            if (dtAdHocReport.Rows.Count == 1)
            {
                DataRow drAdHocReport = dtAdHocReport.Rows[0];
                if (drAdHocReport["Pk_AdHocReport"] == DBNull.Value)
                    this._Pk_AdHocReport = null;
                else
                    this._Pk_AdHocReport = (decimal?)drAdHocReport["Pk_AdHocReport"];

                if (drAdHocReport["ReportName"] == DBNull.Value)
                    this._ReportName = null;
                else
                    this._ReportName = (string)drAdHocReport["ReportName"];

                if (drAdHocReport["OutputFields"] == DBNull.Value)
                    this._OutputFields = null;
                else
                    this._OutputFields = (string)drAdHocReport["OutputFields"];

                if (drAdHocReport["FirstGroupBy"] == DBNull.Value)
                    this._FirstGroupBy = null;
                else
                    this._FirstGroupBy = (decimal?)drAdHocReport["FirstGroupBy"];

                if (drAdHocReport["SecondGroupBy"] == DBNull.Value)
                    this._SecondGroupBy = null;
                else
                    this._SecondGroupBy = (decimal?)drAdHocReport["SecondGroupBy"];

                if (drAdHocReport["FirstSortBy"] == DBNull.Value)
                    this._FirstSortBy = null;
                else
                    this._FirstSortBy = (decimal?)drAdHocReport["FirstSortBy"];

                if (drAdHocReport["FirstSortByOrder"] == DBNull.Value)
                    this._FirstSortByOrder = null;
                else
                    this._FirstSortByOrder = (string)drAdHocReport["FirstSortByOrder"];

                if (drAdHocReport["SecondSortBy"] == DBNull.Value)
                    this._SecondSortBy = null;
                else
                    this._SecondSortBy = (decimal?)drAdHocReport["SecondSortBy"];

                if (drAdHocReport["SecondSortByOrder"] == DBNull.Value)
                    this._SecondSortByOrder = null;
                else
                    this._SecondSortByOrder = (string)drAdHocReport["SecondSortByOrder"];

                if (drAdHocReport["ThirdSortByOrder"] == DBNull.Value)
                    this._ThirdSortByOrder = null;
                else
                    this._ThirdSortByOrder = (string)drAdHocReport["ThirdSortByOrder"];

                if (drAdHocReport["ThirdSortBy"] == DBNull.Value)
                    this._ThirdSortBy = null;
                else
                    this._ThirdSortBy = (decimal?)drAdHocReport["ThirdSortBy"];

                if (drAdHocReport["Updated_By"] == DBNull.Value)
                    this._Updated_By = null;
                else
                    this._Updated_By = (string)drAdHocReport["Updated_By"];

                if (drAdHocReport["Update_Date"] == DBNull.Value)
                    this._Update_Date = null;
                else
                    this._Update_Date = (DateTime?)drAdHocReport["Update_Date"];

                if (drAdHocReport["SecondGroupByOrder"] == DBNull.Value)
                    this._SecondGroupByOrder = null;
                else
                    this._SecondGroupByOrder = (string)drAdHocReport["SecondGroupByOrder"];

                if (drAdHocReport["FirstGroupByOrder"] == DBNull.Value)
                    this._FirstGroupByOrder = null;
                else
                    this._FirstGroupByOrder = (string)drAdHocReport["FirstGroupByOrder"];
            }
            else
            {
                this._Pk_AdHocReport = null;
                this._ReportName = null;
                this._OutputFields = null;
                this._FirstGroupBy = null;
                this._SecondGroupBy = null;
                this._FirstSortBy = null;
                this._FirstSortByOrder = null;
                this._SecondSortBy = null;
                this._SecondSortByOrder = null;
                this._ThirdSortByOrder = null;
                this._ThirdSortBy = null;
                this._Updated_By = null;
                this._Update_Date = null;
                this._SecondGroupByOrder = null;
                this._FirstGroupByOrder = null;
            }

        }

        #endregion

		/// <summary>
		/// Initializes a new instance of the clsDealershipDetails_AdHocReport class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drDealershipDetails_AdHocReport) 
		{
				if (drDealershipDetails_AdHocReport["Pk_AdHocReport"] == DBNull.Value)
					this._Pk_AdHocReport = null;
				else
					this._Pk_AdHocReport = (decimal?)drDealershipDetails_AdHocReport["Pk_AdHocReport"];

				if (drDealershipDetails_AdHocReport["ReportName"] == DBNull.Value)
					this._ReportName = null;
				else
					this._ReportName = (string)drDealershipDetails_AdHocReport["ReportName"];

				if (drDealershipDetails_AdHocReport["OutputFields"] == DBNull.Value)
					this._OutputFields = null;
				else
					this._OutputFields = (string)drDealershipDetails_AdHocReport["OutputFields"];

				if (drDealershipDetails_AdHocReport["FirstGroupBy"] == DBNull.Value)
					this._FirstGroupBy = null;
				else
					this._FirstGroupBy = (decimal?)drDealershipDetails_AdHocReport["FirstGroupBy"];

				if (drDealershipDetails_AdHocReport["SecondGroupBy"] == DBNull.Value)
					this._SecondGroupBy = null;
				else
					this._SecondGroupBy = (decimal?)drDealershipDetails_AdHocReport["SecondGroupBy"];

				if (drDealershipDetails_AdHocReport["FirstSortBy"] == DBNull.Value)
					this._FirstSortBy = null;
				else
					this._FirstSortBy = (decimal?)drDealershipDetails_AdHocReport["FirstSortBy"];

				if (drDealershipDetails_AdHocReport["FirstSortByOrder"] == DBNull.Value)
					this._FirstSortByOrder = null;
				else
					this._FirstSortByOrder = (string)drDealershipDetails_AdHocReport["FirstSortByOrder"];

				if (drDealershipDetails_AdHocReport["SecondSortBy"] == DBNull.Value)
					this._SecondSortBy = null;
				else
					this._SecondSortBy = (decimal?)drDealershipDetails_AdHocReport["SecondSortBy"];

				if (drDealershipDetails_AdHocReport["SecondSortByOrder"] == DBNull.Value)
					this._SecondSortByOrder = null;
				else
					this._SecondSortByOrder = (string)drDealershipDetails_AdHocReport["SecondSortByOrder"];

				if (drDealershipDetails_AdHocReport["ThirdSortBy"] == DBNull.Value)
					this._ThirdSortBy = null;
				else
					this._ThirdSortBy = (decimal?)drDealershipDetails_AdHocReport["ThirdSortBy"];

				if (drDealershipDetails_AdHocReport["ThirdSortByOrder"] == DBNull.Value)
					this._ThirdSortByOrder = null;
				else
					this._ThirdSortByOrder = (string)drDealershipDetails_AdHocReport["ThirdSortByOrder"];

				if (drDealershipDetails_AdHocReport["Updated_By"] == DBNull.Value)
					this._Updated_By = null;
				else
					this._Updated_By = (string)drDealershipDetails_AdHocReport["Updated_By"];

				if (drDealershipDetails_AdHocReport["Update_Date"] == DBNull.Value)
					this._Update_Date = null;
				else
					this._Update_Date = (DateTime?)drDealershipDetails_AdHocReport["Update_Date"];

				if (drDealershipDetails_AdHocReport["FirstGroupByOrder"] == DBNull.Value)
					this._FirstGroupByOrder = null;
				else
					this._FirstGroupByOrder = (string)drDealershipDetails_AdHocReport["FirstGroupByOrder"];

				if (drDealershipDetails_AdHocReport["SecondGroupByOrder"] == DBNull.Value)
					this._SecondGroupByOrder = null;
				else
					this._SecondGroupByOrder = (string)drDealershipDetails_AdHocReport["SecondGroupByOrder"];

				if (drDealershipDetails_AdHocReport["FK_Schedule"] == DBNull.Value)
					this._FK_Schedule = null;
				else
					this._FK_Schedule = (decimal?)drDealershipDetails_AdHocReport["FK_Schedule"];

		}
		

		/// <summary>
		/// Inserts a record into the DealershipDetails_AdHocReport table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("DealershipDetails_AdHocReportInsert");

			
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

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects all records from the DealershipDetails_AdHocReport table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("DealershipDetails_AdHocReportSelectAll");

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
            DbCommand dbCommand = db.GetStoredProcCommand("DealershipDetails_AdHocReportExistsReport");

            db.AddInParameter(dbCommand, "@ReportName", DbType.String, ReportName);
            db.AddInParameter(dbCommand, "@Pk_ID", DbType.Decimal, pk_AdHocReport);

            return db.ExecuteDataSet(dbCommand).Tables[0];

        }

        /// <summary>
        /// Deletes a record from the AdHocReport table by a composite primary key.
        /// </summary>
        public static void DeleteByPK(decimal pk_AdHocReport)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("DealershipDetails_AdHocReportDeleteByPK");

            db.AddInParameter(dbCommand, "Pk_AdHocReport", DbType.Decimal, pk_AdHocReport);

            db.ExecuteNonQuery(dbCommand);
        }


        /// <summary>
        /// Selects a single record from the AdHocReport table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        private static DataSet SelectByPK(decimal pk_AdHocReport)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("DealershipDetails_AdHocReportSelectByPK");

            db.AddInParameter(dbCommand, "Pk_AdHocReport", DbType.Decimal, pk_AdHocReport);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Select Report Name BY Coverage
        /// </summary>
        /// <param name="CoverageType"></param>
        /// <returns></returns>
        public static DataSet SelectReportName()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("DealershipDetails_AdHocReportSelect");

            return db.ExecuteDataSet(dbCommand);
        }

        public decimal Update()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("DealershipDetails_AdHocReportUpdate");


            db.AddInParameter(dbCommand, "Pk_AdHocReport", DbType.Decimal, this._Pk_AdHocReport);

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

            if (string.IsNullOrEmpty(this._ThirdSortByOrder))
                db.AddInParameter(dbCommand, "ThirdSortByOrder", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "ThirdSortByOrder", DbType.String, this._ThirdSortByOrder);

            db.AddInParameter(dbCommand, "ThirdSortBy", DbType.Decimal, this._ThirdSortBy);

            if (string.IsNullOrEmpty(this._Updated_By))
                db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);

            db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);

            if (string.IsNullOrEmpty(this._SecondGroupByOrder))
                db.AddInParameter(dbCommand, "SecondGroupByOrder", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "SecondGroupByOrder", DbType.String, this._SecondGroupByOrder);

            if (string.IsNullOrEmpty(this._FirstGroupByOrder))
                db.AddInParameter(dbCommand, "FirstGroupByOrder", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "FirstGroupByOrder", DbType.String, this._FirstGroupByOrder);

            db.AddInParameter(dbCommand, "FK_Schedule", DbType.Decimal, this._FK_Schedule);

            // Execute the query and return the new identity value
            decimal returnValue = Convert.ToDecimal(db.ExecuteScalar(dbCommand));

            return returnValue;
        }
	}
}
