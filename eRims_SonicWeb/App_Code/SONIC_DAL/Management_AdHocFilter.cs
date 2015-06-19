using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Collections.Generic;
using System.Globalization;

namespace ERIMS.DAL
{
    /// <summary>
    /// Summary description for Management_AdHocFilter
    /// </summary>
    public sealed class Management_AdHocFilter
    {

        #region Private variables used to hold the property values

        private decimal? _PK_Management_AdHocFilter;
        private decimal? _FK_AdHocReport;
        private decimal? _FK_AdHocReportFields;
        private string _ConditionType;
        private string _ConditionValue;
        private decimal? _AmountFrom;
        private decimal? _AmountTo;
        private DateTime? _FromDate;
        private string _FromRelativeCriteria;
        private DateTime? _ToDate;
        private string _ToRelativeCriteria;
        private string _ReportName;
        private string _Field_Header;
        private int? _Fk_ControlType;
        private bool _IsNotSelected = false;

        #endregion

        #region Public Property

        /// <summary>
        /// Gets or sets the PK_Management_AdHocFilter value.
        /// </summary>
        public decimal? PK_Management_AdHocFilter
        {
            get { return _PK_Management_AdHocFilter; }
            set { _PK_Management_AdHocFilter = value; }
        }

        /// <summary>
        /// Gets or sets the FK_Management_AdHocReport value.
        /// </summary>
        public decimal? FK_Management_AdHocReport
        {
            get { return _FK_AdHocReport; }
            set { _FK_AdHocReport = value; }
        }

        /// <summary>
        /// Gets or sets the FK_Management_AdhocReportFields value.
        /// </summary>
        public decimal? FK_Management_AdhocReportFields
        {
            get { return _FK_AdHocReportFields; }
            set { _FK_AdHocReportFields = value; }
        }

        /// <summary>
        /// Gets or sets the ConditionType value.
        /// </summary>
        public string ConditionType
        {
            get { return _ConditionType; }
            set { _ConditionType = value; }
        }

        /// <summary>
        /// Gets or sets the ConditionValue value.
        /// </summary>
        public string ConditionValue
        {
            get { return _ConditionValue; }
            set { _ConditionValue = value; }
        }

        /// <summary>
        /// Gets or sets the AmountFrom value.
        /// </summary>
        public decimal? AmountFrom
        {
            get { return _AmountFrom; }
            set { _AmountFrom = value; }
        }

        /// <summary>
        /// Gets or sets the AmountTo value.
        /// </summary>
        public decimal? AmountTo
        {
            get { return _AmountTo; }
            set { _AmountTo = value; }
        }

        /// <summary>
        /// Gets or sets the FromDate value.
        /// </summary>
        public DateTime? FromDate
        {
            get { return _FromDate; }
            set { _FromDate = value; }
        }

        /// <summary>
        /// Gets or sets the FromRelativeCriteria value.
        /// </summary>
        public string FromRelativeCriteria
        {
            get { return _FromRelativeCriteria; }
            set { _FromRelativeCriteria = value; }
        }

        /// <summary>
        /// Gets or sets the ToDate value.
        /// </summary>
        public DateTime? ToDate
        {
            get { return _ToDate; }
            set { _ToDate = value; }
        }

        /// <summary>
        /// Gets or sets the ToRelativeCriteria value.
        /// </summary>
        public string ToRelativeCriteria
        {
            get { return _ToRelativeCriteria; }
            set { _ToRelativeCriteria = value; }
        }

        /// <summary>
        /// Gets or sets the ToRelativeCriteria value.
        /// </summary>
        public string ReportName
        {
            get { return _ReportName; }
            set { _ReportName = value; }
        }
        /// <summary>
        /// Gets or sets the ToRelativeCriteria value.
        /// </summary>
        public string Field_Header
        {
            get { return _Field_Header; }
            set { _Field_Header = value; }
        }
        /// <summary>
        /// Gets or sets the ToRelativeCriteria value.
        /// </summary>
        public int? Fk_ControlType
        {
            get { return _Fk_ControlType; }
            set { _Fk_ControlType = value; }
        }

        public bool IsNotSelected
        {
            get { return _IsNotSelected; }
            set { _IsNotSelected = value; }
        }

        #endregion

        #region Default Constructors

        /// <summary>
        /// Initializes a new instance of the AdHocFilter class with default value.
        /// </summary>
        public Management_AdHocFilter()
        {
            this._PK_Management_AdHocFilter = null;
            this._FK_AdHocReport = null;
            this._FK_AdHocReportFields = null;
            this._ConditionType = null;
            this._ConditionValue = null;
            this._AmountFrom = null;
            this._AmountTo = null;
            this._FromDate = null;
            this._FromRelativeCriteria = null;
            this._ToDate = null;
            this._ToRelativeCriteria = null;
            this._ReportName = null;
            this._Field_Header = null;
            this._Fk_ControlType = null;
            this._IsNotSelected = false;
        }

        #endregion

        #region Primary Constructors

        /// <summary>
        /// Initializes a new instance of the AdHocFilter class based on Primary Key.
        /// </summary>
        public Management_AdHocFilter(decimal PK_Management_AdHocFilter)
        {
            DataTable dtAdHocFilter = SelectByPK(PK_Management_AdHocFilter).Tables[0];

            if (dtAdHocFilter.Rows.Count == 1)
            {
                DataRow drAdHocFilter = dtAdHocFilter.Rows[0];
                if (drAdHocFilter["PK_Management_AdHocFilter"] == DBNull.Value)
                    this._PK_Management_AdHocFilter = null;
                else
                    this._PK_Management_AdHocFilter = (decimal?)drAdHocFilter["PK_Management_AdHocFilter"];

                if (drAdHocFilter["FK_Management_AdHocReport"] == DBNull.Value)
                    this._FK_AdHocReport = null;
                else
                    this._FK_AdHocReport = (decimal?)drAdHocFilter["FK_Management_AdHocReport"];

                if (drAdHocFilter["FK_Management_AdhocReportFields"] == DBNull.Value)
                    this._FK_AdHocReportFields = null;
                else
                    this._FK_AdHocReportFields = (decimal?)drAdHocFilter["FK_Management_AdhocReportFields"];

                if (drAdHocFilter["ConditionType"] == DBNull.Value)
                    this._ConditionType = null;
                else
                    this._ConditionType = (string)drAdHocFilter["ConditionType"];

                if (drAdHocFilter["ConditionValue"] == DBNull.Value)
                    this._ConditionValue = null;
                else
                    this._ConditionValue = (string)drAdHocFilter["ConditionValue"];

                if (drAdHocFilter["AmountFrom"] == DBNull.Value)
                    this._AmountFrom = null;
                else
                    this._AmountFrom = (decimal?)drAdHocFilter["AmountFrom"];

                if (drAdHocFilter["AmountTo"] == DBNull.Value)
                    this._AmountTo = null;
                else
                    this._AmountTo = (decimal?)drAdHocFilter["AmountTo"];

                if (drAdHocFilter["FromDate"] == DBNull.Value)
                    this._FromDate = null;
                else
                    this._FromDate = (DateTime?)drAdHocFilter["FromDate"];

                if (drAdHocFilter["FromRelativeCriteria"] == DBNull.Value)
                    this._FromRelativeCriteria = null;
                else
                    this._FromRelativeCriteria = (string)drAdHocFilter["FromRelativeCriteria"];

                if (drAdHocFilter["ToDate"] == DBNull.Value)
                    this._ToDate = null;
                else
                    this._ToDate = (DateTime?)drAdHocFilter["ToDate"];

                if (drAdHocFilter["ToRelativeCriteria"] == DBNull.Value)
                    this._ToRelativeCriteria = null;
                else
                    this._ToRelativeCriteria = (string)drAdHocFilter["ToRelativeCriteria"];

                if (drAdHocFilter["IsNotSelected"] == DBNull.Value)
                    this._IsNotSelected = false;
                else
                    this._IsNotSelected = (bool)drAdHocFilter["IsNotSelected"];

            }
            else
            {
                this._PK_Management_AdHocFilter = null;
                this._FK_AdHocReport = null;
                this._FK_AdHocReportFields = null;
                this._ConditionType = null;
                this._ConditionValue = null;
                this._AmountFrom = null;
                this._AmountTo = null;
                this._FromDate = null;
                this._FromRelativeCriteria = null;
                this._ToDate = null;
                this._ToRelativeCriteria = null;
                this._IsNotSelected = false;
            }
        }

        #endregion

        /// <summary>
        /// Inserts a record into the AdHocFilter table.
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Management_AdHocFilterInsert");


            db.AddInParameter(dbCommand, "FK_Management_AdHocReport", DbType.Decimal, this._FK_AdHocReport);

            db.AddInParameter(dbCommand, "FK_Management_AdhocReportFields", DbType.Decimal, this._FK_AdHocReportFields);

            if (string.IsNullOrEmpty(this._ConditionType))
                db.AddInParameter(dbCommand, "ConditionType", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "ConditionType", DbType.String, this._ConditionType);

            if (string.IsNullOrEmpty(this._ConditionValue))
                db.AddInParameter(dbCommand, "ConditionValue", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "ConditionValue", DbType.String, this._ConditionValue);

            db.AddInParameter(dbCommand, "AmountFrom", DbType.Decimal, this._AmountFrom);

            db.AddInParameter(dbCommand, "AmountTo", DbType.Decimal, this._AmountTo);

            db.AddInParameter(dbCommand, "FromDate", DbType.DateTime, this._FromDate);

            if (string.IsNullOrEmpty(this._FromRelativeCriteria))
                db.AddInParameter(dbCommand, "FromRelativeCriteria", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "FromRelativeCriteria", DbType.String, this._FromRelativeCriteria);

            db.AddInParameter(dbCommand, "ToDate", DbType.DateTime, this._ToDate);

            if (string.IsNullOrEmpty(this._ToRelativeCriteria))
                db.AddInParameter(dbCommand, "ToRelativeCriteria", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "ToRelativeCriteria", DbType.String, this._ToRelativeCriteria);

            db.AddInParameter(dbCommand, "IsNotSelected", DbType.Boolean, this._IsNotSelected);

            // Execute the query and return the new identity value
            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
        }

        /// <summary>
        /// Selects a single record from the AdHocFilter table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        private static DataSet SelectByPK(decimal PK_Management_AdHocFilter)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Management_AdHocFilterSelectByPK");

            db.AddInParameter(dbCommand, "PK_Management_AdHocFilter", DbType.Decimal, PK_Management_AdHocFilter);

            return db.ExecuteDataSet(dbCommand);
        }


        /// <summary>
        /// Updates a record in the AdHocFilter table.
        /// </summary>
        public void Update()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Management_AdHocFilterUpdate");


            db.AddInParameter(dbCommand, "PK_Management_AdHocFilter", DbType.Decimal, this._PK_Management_AdHocFilter);

            db.AddInParameter(dbCommand, "FK_Management_AdHocReport", DbType.Decimal, this._FK_AdHocReport);

            db.AddInParameter(dbCommand, "FK_Management_AdhocReportFields", DbType.Decimal, this._FK_AdHocReportFields);

            if (string.IsNullOrEmpty(this._ConditionType))
                db.AddInParameter(dbCommand, "ConditionType", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "ConditionType", DbType.String, this._ConditionType);

            if (string.IsNullOrEmpty(this._ConditionValue))
                db.AddInParameter(dbCommand, "ConditionValue", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "ConditionValue", DbType.String, this._ConditionValue);

            db.AddInParameter(dbCommand, "AmountFrom", DbType.Decimal, this._AmountFrom);

            db.AddInParameter(dbCommand, "AmountTo", DbType.Decimal, this._AmountTo);

            db.AddInParameter(dbCommand, "FromDate", DbType.DateTime, this._FromDate);

            if (string.IsNullOrEmpty(this._FromRelativeCriteria))
                db.AddInParameter(dbCommand, "FromRelativeCriteria", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "FromRelativeCriteria", DbType.String, this._FromRelativeCriteria);

            db.AddInParameter(dbCommand, "ToDate", DbType.DateTime, this._ToDate);

            if (string.IsNullOrEmpty(this._ToRelativeCriteria))
                db.AddInParameter(dbCommand, "ToRelativeCriteria", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "ToRelativeCriteria", DbType.String, this._ToRelativeCriteria);

            db.AddInParameter(dbCommand, "IsNotSelected", DbType.Boolean, this._IsNotSelected);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Deletes a record from the AdHocFilter table by a composite primary key.
        /// </summary>
        public static void DeleteByPK(decimal PK_Management_AdHocFilter)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Management_AdHocFilterDeleteByPK");

            db.AddInParameter(dbCommand, "PK_Management_AdHocFilter", DbType.Decimal, PK_Management_AdHocFilter);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Delete All AdHocFilter Records by FK_Management_AdHocReport 
        /// </summary>
        /// <param name="FK_Management_AdHocReport"></param>
        public static void DeleteByFk_AdHocReport(decimal FK_Management_AdHocReport)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Management_AdHocFilterDeleteByFK_AdHocReport");

            db.AddInParameter(dbCommand, "FK_Management_AdHocReport", DbType.Decimal, FK_Management_AdHocReport);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Get Adhoc Report filter fields by AdHoc Report ID
        /// </summary>
        /// <param name="Pk_AdHocReport"></param>
        /// <returns></returns>
        public List<Management_AdHocFilter> GetAdHocReportFieldByPk(decimal FK_Management_AdHocReport)
        {

            Database dbHelper = null;
            DbCommand cmd = null;
            IDataReader reader = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                List<ERIMS.DAL.Management_AdHocFilter> results = new List<ERIMS.DAL.Management_AdHocFilter>();
                ERIMS.DAL.Management_AdHocFilter objAdHoc;

                cmd = dbHelper.GetStoredProcCommand("Management_AdHocFilterSelectByFkAdHocReport");
                dbHelper.AddInParameter(cmd, "FK_Management_AdHocReport", DbType.Decimal, FK_Management_AdHocReport);
                reader = dbHelper.ExecuteReader(cmd);
                while (reader.Read())
                {
                    objAdHoc = MapFrom(reader);
                    results.Add(objAdHoc);
                }
                return results;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (reader != null)
                {
                    if (!reader.IsClosed)
                        reader.Close();
                    reader.Dispose();
                }
                reader = null;
                cmd.Dispose();
                cmd = null;
                dbHelper = null;
            }

        }

        /// <summary>
        /// Map Data Reader value with variables
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        private ERIMS.DAL.Management_AdHocFilter MapFrom(IDataReader reader)
        {
            ERIMS.DAL.Management_AdHocFilter objAdHoc = new ERIMS.DAL.Management_AdHocFilter();
            try
            {
                if (!Convert.IsDBNull(reader["PK_Management_AdHocFilter"])) { objAdHoc.PK_Management_AdHocFilter = Convert.ToDecimal(reader["PK_Management_AdHocFilter"], CultureInfo.InvariantCulture); }
                if (!Convert.IsDBNull(reader["FK_Management_AdHocReport"])) { objAdHoc.FK_Management_AdHocReport = Convert.ToDecimal(reader["FK_Management_AdHocReport"], CultureInfo.InvariantCulture); }
                if (!Convert.IsDBNull(reader["FK_Management_AdhocReportFields"])) { objAdHoc.FK_Management_AdhocReportFields = Convert.ToDecimal(reader["FK_Management_AdhocReportFields"], CultureInfo.InvariantCulture); }
                if (!Convert.IsDBNull(reader["Fk_ControlType"])) { objAdHoc.Fk_ControlType = Convert.ToInt32(reader["Fk_ControlType"], CultureInfo.InvariantCulture); }
                if (!Convert.IsDBNull(reader["Field_Header"])) { objAdHoc.Field_Header = Convert.ToString(reader["Field_Header"], CultureInfo.InvariantCulture); }
                if (!Convert.IsDBNull(reader["ConditionType"])) { objAdHoc.ConditionType = Convert.ToString(reader["ConditionType"], CultureInfo.InvariantCulture); }
                if (!Convert.IsDBNull(reader["ConditionValue"])) { objAdHoc.ConditionValue = Convert.ToString(reader["ConditionValue"], CultureInfo.InvariantCulture); }

                if (!Convert.IsDBNull(reader["AmountFrom"])) { objAdHoc.AmountFrom = Convert.ToDecimal(reader["AmountFrom"], CultureInfo.InvariantCulture); }
                if (!Convert.IsDBNull(reader["AmountTo"])) { objAdHoc.AmountTo = Convert.ToDecimal(reader["AmountTo"], CultureInfo.InvariantCulture); }

                if (!Convert.IsDBNull(reader["FromDate"])) { objAdHoc.FromDate = Convert.ToDateTime(reader["FromDate"], CultureInfo.InvariantCulture); }
                if (!Convert.IsDBNull(reader["ToDate"])) { objAdHoc.ToDate = Convert.ToDateTime(reader["ToDate"], CultureInfo.InvariantCulture); }

                if (!Convert.IsDBNull(reader["FromRelativeCriteria"])) { objAdHoc.FromRelativeCriteria = Convert.ToString(reader["FromRelativeCriteria"], CultureInfo.InvariantCulture); }
                if (!Convert.IsDBNull(reader["ToRelativeCriteria"])) { objAdHoc.ToRelativeCriteria = Convert.ToString(reader["ToRelativeCriteria"], CultureInfo.InvariantCulture); }

                if (!Convert.IsDBNull(reader["IsNotSelected"])) { objAdHoc.IsNotSelected = Convert.ToBoolean(reader["IsNotSelected"]); } else { objAdHoc.IsNotSelected = false; }

                return objAdHoc;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataSet SelectByAdHocReportScheduler(decimal PK_Schedule, decimal FK_Report)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Management_AdHocReport_Schedule_SelectByFK");

            db.AddInParameter(dbCommand, "PK_Schedule", DbType.Decimal, PK_Schedule);
            db.AddInParameter(dbCommand, "FK_Report", DbType.Decimal, FK_Report);

            return db.ExecuteDataSet(dbCommand);
        }
    }
}
