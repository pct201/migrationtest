using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Collections.Generic;

namespace ERIMS_DAL
{
    /// <summary>
    /// Data access class for table Construction_AdHocReport
    /// </summary>
    public sealed class Construction_AdHocReport
    {

        #region Private variables used to hold the property values

        private decimal? _Pk_AdHocReport;
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
        private string _Updated_By;
        private DateTime? _Update_Date;
        private string _FirstGroupByOrder;
        private string _SecondGroupByOrder;
        private string _ThirdGroupByOrder;
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
        /// Gets or sets the ThirdGroupByOrder value.
        /// </summary>
        public string ThirdGroupByOrder
        {
            get { return _ThirdGroupByOrder; }
            set { _ThirdGroupByOrder = value; }
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
        /// Initializes a new instance of the Construction_AdHocReport class with default value.
        /// </summary>
        public Construction_AdHocReport()
        {

        }

        /// <summary>
        /// Initializes a new instance of the Construction_AdHocReport class based on Primary Key.
        /// </summary>
        public Construction_AdHocReport(decimal pK_AdHocReport)
        {
            DataTable dtConstruction_AdHocReport = Select(pK_AdHocReport).Tables[0];

            if (dtConstruction_AdHocReport.Rows.Count == 1)
            {
                SetValue(dtConstruction_AdHocReport.Rows[0]);
            }
        }

        #endregion

        #region Primary Constructors

        /// <summary>
        /// Initializes a new instance of the Construction_AdHocReport class based on Datarow passed.
        /// </summary>
        private void SetValue(DataRow drConstruction_AdHocReport)
        {
            if (drConstruction_AdHocReport["Pk_AdHocReport"] == DBNull.Value)
                this._Pk_AdHocReport = null;
            else
                this._Pk_AdHocReport = (decimal?)drConstruction_AdHocReport["Pk_AdHocReport"];

            if (drConstruction_AdHocReport["ReportName"] == DBNull.Value)
                this._ReportName = null;
            else
                this._ReportName = (string)drConstruction_AdHocReport["ReportName"];

            if (drConstruction_AdHocReport["OutputFields"] == DBNull.Value)
                this._OutputFields = null;
            else
                this._OutputFields = (string)drConstruction_AdHocReport["OutputFields"];

            if (drConstruction_AdHocReport["FirstGroupBy"] == DBNull.Value)
                this._FirstGroupBy = null;
            else
                this._FirstGroupBy = (decimal?)drConstruction_AdHocReport["FirstGroupBy"];

            if (drConstruction_AdHocReport["SecondGroupBy"] == DBNull.Value)
                this._SecondGroupBy = null;
            else
                this._SecondGroupBy = (decimal?)drConstruction_AdHocReport["SecondGroupBy"];

            if (drConstruction_AdHocReport["ThirdGroupBy"] == DBNull.Value)
                this._ThirdGroupBy = null;
            else
                this._ThirdGroupBy = (decimal?)drConstruction_AdHocReport["ThirdGroupBy"];

            if (drConstruction_AdHocReport["FirstSortBy"] == DBNull.Value)
                this._FirstSortBy = null;
            else
                this._FirstSortBy = (decimal?)drConstruction_AdHocReport["FirstSortBy"];

            if (drConstruction_AdHocReport["FirstSortByOrder"] == DBNull.Value)
                this._FirstSortByOrder = null;
            else
                this._FirstSortByOrder = (string)drConstruction_AdHocReport["FirstSortByOrder"];

            if (drConstruction_AdHocReport["SecondSortBy"] == DBNull.Value)
                this._SecondSortBy = null;
            else
                this._SecondSortBy = (decimal?)drConstruction_AdHocReport["SecondSortBy"];

            if (drConstruction_AdHocReport["SecondSortByOrder"] == DBNull.Value)
                this._SecondSortByOrder = null;
            else
                this._SecondSortByOrder = (string)drConstruction_AdHocReport["SecondSortByOrder"];

            if (drConstruction_AdHocReport["ThirdSortBy"] == DBNull.Value)
                this._ThirdSortBy = null;
            else
                this._ThirdSortBy = (decimal?)drConstruction_AdHocReport["ThirdSortBy"];

            if (drConstruction_AdHocReport["ThirdSortByOrder"] == DBNull.Value)
                this._ThirdSortByOrder = null;
            else
                this._ThirdSortByOrder = (string)drConstruction_AdHocReport["ThirdSortByOrder"];

            if (drConstruction_AdHocReport["Updated_By"] == DBNull.Value)
                this._Updated_By = null;
            else
                this._Updated_By = (string)drConstruction_AdHocReport["Updated_By"];

            if (drConstruction_AdHocReport["Update_Date"] == DBNull.Value)
                this._Update_Date = null;
            else
                this._Update_Date = (DateTime?)drConstruction_AdHocReport["Update_Date"];

            if (drConstruction_AdHocReport["FirstGroupByOrder"] == DBNull.Value)
                this._FirstGroupByOrder = null;
            else
                this._FirstGroupByOrder = (string)drConstruction_AdHocReport["FirstGroupByOrder"];

            if (drConstruction_AdHocReport["SecondGroupByOrder"] == DBNull.Value)
                this._SecondGroupByOrder = null;
            else
                this._SecondGroupByOrder = (string)drConstruction_AdHocReport["SecondGroupByOrder"];

            if (drConstruction_AdHocReport["ThirdGroupByOrder"] == DBNull.Value)
                this._ThirdGroupByOrder = null;
            else
                this._ThirdGroupByOrder = (string)drConstruction_AdHocReport["ThirdGroupByOrder"];

            if (drConstruction_AdHocReport["FK_Schedule"] == DBNull.Value)
                this._FK_Schedule = null;
            else
                this._FK_Schedule = (decimal?)drConstruction_AdHocReport["FK_Schedule"];


        }

        #endregion

        /// <summary>
        /// Inserts a record into the Construction_AdHocReport table.
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Construction_AdHocReportInsert");


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

            if (string.IsNullOrEmpty(this._ThirdGroupByOrder))
                db.AddInParameter(dbCommand, "ThirdGroupByOrder", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "ThirdGroupByOrder", DbType.String, this._ThirdGroupByOrder);

            db.AddInParameter(dbCommand, "FK_Schedule", DbType.Decimal, this._FK_Schedule);

            // Execute the query and return the new identity value
            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
        }

        /// <summary>
        /// Selects a single record from the Construction_AdHocReport table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet Select(decimal pk_AdHocReport)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Construction_AdHocReportSelect");

            db.AddInParameter(dbCommand, "Pk_AdHocReport", DbType.Decimal, pk_AdHocReport);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the Construction_AdHocReport table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Construction_AdHocReportSelectAll");

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Updates a record in the Construction_AdHocReport table.
        /// </summary>
        public void Update()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Construction_AdHocReportUpdate");


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

            if (string.IsNullOrEmpty(this._ThirdGroupByOrder))
                db.AddInParameter(dbCommand, "ThirdGroupByOrder", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "ThirdGroupByOrder", DbType.String, this._ThirdGroupByOrder);

            db.AddInParameter(dbCommand, "FK_Schedule", DbType.Decimal, this._FK_Schedule);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Deletes a record from the Construction_AdHocReport table by a composite primary key.
        /// </summary>
        public static void Delete(decimal pk_AdHocReport)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Construction_AdHocReportDelete");

            db.AddInParameter(dbCommand, "Pk_AdHocReport", DbType.Decimal, pk_AdHocReport);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Selects a single record from the Construction_AdHocReport table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet CheckReportExists(decimal pk_AdHocReport, string reportName)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Construction_AdHocReportExistsReport");

            db.AddInParameter(dbCommand, "Pk_AdHocReport", DbType.Decimal, pk_AdHocReport);
            db.AddInParameter(dbCommand, "ReportName", DbType.String, reportName);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Method to get result of Construction Adhoc Report by filter fields
        /// </summary>
        /// <param name="selectedField"></param>
        /// <param name="groupBy"></param>
        /// <param name="PVDWhere"></param>
        /// <param name="sqlWhere"></param>
        /// <param name="sqlSortBy"></param>
        /// <param name="strFilterIds"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public static IDataReader GetConstructionAdHocReport(string selectedField, string groupBy, string sqlWhere, string sqlSortBy, string strFilterIds, decimal userId)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("rptConstruction_AdHocReport");
            dbCommand.CommandTimeout = 100000;

            db.AddInParameter(dbCommand, "SelectedField", DbType.String, selectedField);
            db.AddInParameter(dbCommand, "GroupBy", DbType.String, groupBy);
            db.AddInParameter(dbCommand, "SqlWhere1", DbType.String, sqlWhere);
            db.AddInParameter(dbCommand, "SqlSortBy", DbType.String, sqlSortBy);
            db.AddInParameter(dbCommand, "SqlWhereIds", DbType.String, strFilterIds);
            db.AddInParameter(dbCommand, "PK_Security_ID", DbType.Decimal, userId);
            return db.ExecuteReader(dbCommand);
        }
    }
}
