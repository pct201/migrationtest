using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
    /// <summary>
    /// Data access class for AdHocReport table.
    /// </summary>
    public sealed class ACI_AdHocReport
    {

        #region Private variables used to hold the property values

        private decimal? _Pk_AdHocReport;
        private decimal? _FK_Schedule;
        private string _CoverageType;
        private string _ReportName;
        private string _OutputFields;
        private decimal? _FirstGroupBy;
        private string _FirstGroupByOrder;
        private decimal? _SecondGroupBy;
        private string _SecondGroupByOrder;

        private decimal? _ThirdGroupBy;
        private string _ThirdGroupByOrder;

        private decimal? _FourthGroupBy;
        private string _FourthGroupByOrder;

        private decimal? _FifthGroupBy;
        private string _FifthGroupByOrder;

        private decimal? _FirstSortBy;
        private string _FirstSortByOrder;
        private decimal? _SecondSortBy;
        private string _SecondSortByOrder;
        private string _ThirdSortByOrder;
        private decimal? _ThirdSortBy;

        private string _FourthSortByOrder;
        private decimal? _FourthSortBy;

        private string _FifthSortByOrder;
        private decimal? _FifthSortBy;

        private DateTime? _PriorValuationDate;
        private string _GrandTotal;
        private string _Updated_By;
        private DateTime? _Update_Date;
        private string _PriorValuation_RelativeDate;
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
        /// Gets or sets the FirstGroupByOrder value.
        /// </summary>
        public string ThirdGroupByOrder
        {
            get { return _ThirdGroupByOrder; }
            set { _ThirdGroupByOrder = value; }
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
        /// Gets or sets the FourthGroupByOrder value.
        /// </summary>
        public string FourthGroupByOrder
        {
            get { return _FourthGroupByOrder; }
            set { _FourthGroupByOrder = value; }
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
        /// Gets or sets the FourthGroupByOrder value.
        /// </summary>
        public string FifthGroupByOrder
        {
            get { return _FifthGroupByOrder; }
            set { _FifthGroupByOrder = value; }
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
        /// Gets or sets the ThirdSortByOrder value.
        /// </summary>
        public string ThirdSortByOrder
        {
            get { return _ThirdSortByOrder; }
            set { _ThirdSortByOrder = value; }
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
        /// Gets or sets the FourthSortByOrder value.
        /// </summary>
        public string FourthSortByOrder
        {
            get { return _FourthSortByOrder; }
            set { _FourthSortByOrder = value; }
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
        /// Gets or sets the FifthSortByOrder value.
        /// </summary>
        public string FifthSortByOrder
        {
            get { return _FifthSortByOrder; }
            set { _FifthSortByOrder = value; }
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

        public string PriorValuation_RelativeDate
        {
            get { return _PriorValuation_RelativeDate; }
            set { _PriorValuation_RelativeDate = value; }
        }
        #endregion

        #region Default Constructors

        /// <summary>
        /// Initializes a new instance of the AdHocReport class with default value.
        /// </summary>
        public ACI_AdHocReport()
        {
         
            this._Pk_AdHocReport = null;
            this._CoverageType = null;
            this._ReportName = null;
            this._OutputFields = null;
            this._FirstGroupBy = null;
            this._SecondGroupBy = null;
            this._ThirdGroupBy = null;
            this._FourthGroupBy = null;
            this._FifthGroupBy = null;
            this._FirstSortBy = null;
            this._FirstSortByOrder = null;
            this._SecondGroupByOrder = null;
            this._FirstGroupByOrder = null;
            this._ThirdGroupByOrder =null;
            this._FourthGroupByOrder = null;
            this._FifthGroupByOrder = null;
            this._SecondSortBy = null;
            this._SecondSortByOrder = null;
            this._ThirdSortByOrder = null;
            this._ThirdSortBy = null;
            this._FourthSortByOrder = null;
            this._FourthSortBy = null;
            this._FifthSortByOrder = null;
            this._FifthSortBy = null;
            this._PriorValuationDate = null;
            this._GrandTotal = null;
            this._Updated_By = null;
            this._Update_Date = null;
            this._PriorValuation_RelativeDate = null;
        }

        #endregion

        #region Primary Constructors

        /// <summary>
        /// Initializes a new instance of the AdHocReport class based on Primary Key.
        /// </summary>
        public ACI_AdHocReport(decimal pk_AdHocReport)
        {
            DataTable dtAdHocReport = SelectByPK(pk_AdHocReport).Tables[0];

            if (dtAdHocReport.Rows.Count == 1)
            {
                DataRow drAdHocReport = dtAdHocReport.Rows[0];
                if (drAdHocReport["Pk_AdHocReport"] == DBNull.Value)
                    this._Pk_AdHocReport = null;
                else
                    this._Pk_AdHocReport = (decimal?)drAdHocReport["Pk_AdHocReport"];

                if (drAdHocReport["CoverageType"] == DBNull.Value)
                    this._CoverageType = null;
                else
                    this._CoverageType = (string)drAdHocReport["CoverageType"];

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


                if (drAdHocReport["ThirdGroupBy"] == DBNull.Value)
                    this._ThirdGroupBy = null;
                else
                    this._ThirdGroupBy = (decimal?)drAdHocReport["ThirdGroupBy"];

                if (drAdHocReport["FourthGroupBy"] == DBNull.Value)
                    this._FourthGroupBy = null;
                else
                    this._FourthGroupBy = (decimal?)drAdHocReport["FourthGroupBy"];
                
                if (drAdHocReport["FifthGroupBy"] == DBNull.Value)
                    this._FifthGroupBy = null;
                else
                    this._FifthGroupBy = (decimal?)drAdHocReport["FifthGroupBy"];




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


                if (drAdHocReport["FourthSortByOrder"] == DBNull.Value)
                    this._FourthSortByOrder = null;
                else
                    this._FourthSortByOrder = (string)drAdHocReport["FourthSortByOrder"];

                if (drAdHocReport["FourthSortBy"] == DBNull.Value)
                    this._FourthSortBy = null;
                else
                    this._FourthSortBy = (decimal?)drAdHocReport["FourthSortBy"];

                if (drAdHocReport["FifthSortByOrder"] == DBNull.Value)
                    this._FifthSortByOrder = null;
                else
                    this._FifthSortByOrder = (string)drAdHocReport["FifthSortByOrder"];

                if (drAdHocReport["FifthSortBy"] == DBNull.Value)
                    this._FifthSortBy = null;
                else
                    this._FifthSortBy = (decimal?)drAdHocReport["FifthSortBy"];


                if (drAdHocReport["PriorValuationDate"] == DBNull.Value)
                    this._PriorValuationDate = null;
                else
                    this._PriorValuationDate = (DateTime?)drAdHocReport["PriorValuationDate"];

                if (drAdHocReport["GrandTotal"] == DBNull.Value)
                    this._GrandTotal = null;
                else
                    this._GrandTotal = (string)drAdHocReport["GrandTotal"];

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

                if (drAdHocReport["ThirdGroupByOrder"] == DBNull.Value)
                    this._ThirdGroupByOrder = null;
                else
                    this._ThirdGroupByOrder = (string)drAdHocReport["ThirdGroupByOrder"];

                if (drAdHocReport["FourthGroupByOrder"] == DBNull.Value)
                    this._FourthGroupByOrder = null;
                else
                    this._FourthGroupByOrder = (string)drAdHocReport["FourthGroupByOrder"];

                if (drAdHocReport["FifthGroupByOrder"] == DBNull.Value)
                    this._FifthGroupByOrder = null;
                else
                    this._FifthGroupByOrder = (string)drAdHocReport["FifthGroupByOrder"];

                if (drAdHocReport["PriorValuation_RelativeDate"] == DBNull.Value)
                    this._PriorValuation_RelativeDate = null;
                else
                    this._PriorValuation_RelativeDate = (string)drAdHocReport["PriorValuation_RelativeDate"];

            }
            else
            {
                this._Pk_AdHocReport = null;
                this._CoverageType = null;
                this._ReportName = null;
                this._OutputFields = null;
                this._FirstGroupBy = null;
                this._SecondGroupBy = null;
                this._ThirdGroupBy = null;
                this._FourthGroupBy = null;
                this._FifthGroupBy = null;
                this._FirstSortBy = null;
                this._FirstSortByOrder = null;
                this._SecondSortBy = null;
                this._SecondSortByOrder = null;
                this._ThirdSortByOrder = null;
                this._ThirdSortBy = null;
                this._FourthSortBy = null;
                this._FourthSortByOrder = null;
                this._FifthSortByOrder = null;
                this._FifthSortBy = null;
                this._PriorValuationDate = null;
                this._GrandTotal = null;
                this._Updated_By = null;
                this._Update_Date = null;
                this._SecondGroupByOrder = null;
                this._FirstGroupByOrder = null;
                this._PriorValuation_RelativeDate = null;
            }

        }

        #endregion

        /// <summary>
        /// Inserts a record into the AdHocReport table.
        /// </summary>
        /// <returns></returns>
        public decimal Insert()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("ACI_AdHocReportInsert");


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

            db.AddInParameter(dbCommand, "FourthGroupBy", DbType.Decimal, this._FourthGroupBy);
            db.AddInParameter(dbCommand, "FifthGroupBy", DbType.Decimal, this._FifthGroupBy);

            


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

            if (string.IsNullOrEmpty(this._SecondGroupByOrder))
                db.AddInParameter(dbCommand, "SecondGroupByOrder", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "SecondGroupByOrder", DbType.String, this._SecondGroupByOrder);

            if (string.IsNullOrEmpty(this._FirstGroupByOrder))
                db.AddInParameter(dbCommand, "FirstGroupByOrder", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "FirstGroupByOrder", DbType.String, this._FirstGroupByOrder);

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



            db.AddInParameter(dbCommand, "FK_Schedule", DbType.Decimal, this._FK_Schedule);

            db.AddInParameter(dbCommand, "PriorValuation_RelativeDate", DbType.String, this._PriorValuation_RelativeDate);
            // Execute the query and return the new identity value
            decimal returnValue = Convert.ToDecimal(db.ExecuteScalar(dbCommand));

            return returnValue;
        }

        /// <summary>
        /// Selects a single record from the AdHocReport table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        private static DataSet SelectByPK(decimal pk_AdHocReport)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("ACI_AdHocReportSelectByPK");

            db.AddInParameter(dbCommand, "Pk_AdHocReport", DbType.Decimal, pk_AdHocReport);

            return db.ExecuteDataSet(dbCommand);
        }
            
        /// <summary>
        /// Updates a record in the AdHocReport table.
        /// </summary>
        public decimal Update()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("ACI_AdHocReportUpdate");


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

            db.AddInParameter(dbCommand, "FourthGroupBy", DbType.Decimal, this._FourthGroupBy);
            db.AddInParameter(dbCommand, "FifthGroupBy", DbType.Decimal, this._FifthGroupBy);


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


            db.AddInParameter(dbCommand, "FourthSortBy", DbType.Decimal, this._FourthSortBy);

            if (string.IsNullOrEmpty(this._FourthSortByOrder))
                db.AddInParameter(dbCommand, "FourthSortByOrder", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "FourthSortByOrder", DbType.String, this._FourthSortByOrder);

            db.AddInParameter(dbCommand, "FifthSortBy", DbType.Decimal, this._ThirdSortBy);

            if (string.IsNullOrEmpty(this._FifthSortByOrder))
                db.AddInParameter(dbCommand, "FifthSortByOrder", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "FifthSortByOrder", DbType.String, this._FifthSortByOrder);


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

            if (string.IsNullOrEmpty(this._SecondGroupByOrder))
                db.AddInParameter(dbCommand, "SecondGroupByOrder", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "SecondGroupByOrder", DbType.String, this._SecondGroupByOrder);

            if (string.IsNullOrEmpty(this._FirstGroupByOrder))
                db.AddInParameter(dbCommand, "FirstGroupByOrder", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "FirstGroupByOrder", DbType.String, this._FirstGroupByOrder);

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

            db.AddInParameter(dbCommand, "FK_Schedule", DbType.Decimal, this._FK_Schedule);
            db.AddInParameter(dbCommand, "PriorValuation_RelativeDate", DbType.String, this._PriorValuation_RelativeDate);
            // Execute the query and return the new identity value
            decimal returnValue = Convert.ToDecimal(db.ExecuteScalar(dbCommand));

            return returnValue;
        }

        /// <summary>
        /// Deletes a record from the AdHocReport table by a composite primary key.
        /// </summary>
        public static void DeleteByPK(decimal pk_AdHocReport)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("ACI_AdHocReportDeleteByPK");

            db.AddInParameter(dbCommand, "Pk_AdHocReport", DbType.Decimal, pk_AdHocReport);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Select Report Name BY Coverage
        /// </summary>
        /// <param name="CoverageType"></param>
        /// <returns></returns>
        public static DataSet SelectReportName(string CoverageType)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("ACI_AdHocReportSelectByCoverage");

            db.AddInParameter(dbCommand, "@CoverageType", DbType.String, CoverageType);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Check Report name is exists by Coverage 
        /// </summary>
        /// <param name="CoverageType"></param>
        /// <returns></returns>
        public static DataTable ExistsReportName(string CoverageType, string ReportName, decimal pk_AdHocReport)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("ACI_AdHocReportExistsReport");

            db.AddInParameter(dbCommand, "@CoverageType", DbType.String, CoverageType);
            db.AddInParameter(dbCommand, "@ReportName", DbType.String, ReportName);
            db.AddInParameter(dbCommand, "@Pk_ID", DbType.Decimal, pk_AdHocReport);

            return db.ExecuteDataSet(dbCommand).Tables[0];

        }
    }
}
