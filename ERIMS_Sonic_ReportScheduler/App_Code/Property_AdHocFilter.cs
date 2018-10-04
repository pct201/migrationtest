using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Collections.Generic;
using System.Text;
using System.Globalization;


namespace ERIMS_DAL
{
    /// <summary>
    /// Data access class for table Property_AdHocFilter
    /// </summary>
    public sealed class Property_AdHocFilter
    {

        #region Private variables used to hold the property values

        private decimal? _PK_AdHocFilter;
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
        private bool? _IsNotSelected;
        private string _ReportName;
        private string _Field_Header;
        private int? _Fk_ControlType;

        #endregion

        #region Public Property

        /// <summary>
        /// Gets or sets the PK_AdHocFilter value.
        /// </summary>
        public decimal? PK_AdHocFilter
        {
            get { return _PK_AdHocFilter; }
            set { _PK_AdHocFilter = value; }
        }

        /// <summary>
        /// Gets or sets the FK_AdHocReport value.
        /// </summary>
        public decimal? FK_AdHocReport
        {
            get { return _FK_AdHocReport; }
            set { _FK_AdHocReport = value; }
        }

        /// <summary>
        /// Gets or sets the FK_AdHocReportFields value.
        /// </summary>
        public decimal? FK_AdHocReportFields
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
        /// Gets or sets the IsNotSelected value.
        /// </summary>
        public bool? IsNotSelected
        {
            get { return _IsNotSelected; }
            set { _IsNotSelected = value; }
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


        #endregion

        #region Default Constructors

        /// <summary>
        /// Initializes a new instance of the Property_AdHocFilter class with default value.
        /// </summary>
        public Property_AdHocFilter()
        {


        }

        #endregion


        /// <summary>
        /// Inserts a record into the Property_AdHocFilter table.
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Property_AdHocFilterInsert");


            db.AddInParameter(dbCommand, "FK_AdHocReport", DbType.Decimal, this._FK_AdHocReport);

            db.AddInParameter(dbCommand, "FK_AdHocReportFields", DbType.Decimal, this._FK_AdHocReportFields);

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
        /// Get Adhoc Report filter fields by AdHoc Report ID
        /// </summary>
        /// <param name="Pk_AdHocReport"></param>
        /// <returns></returns>
        public List<Property_AdHocFilter> GetAdHocReportFieldByPk(decimal Pk_AdHocReport)
        {

            Database dbHelper = null;
            DbCommand cmd = null;
            IDataReader reader = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                List<Property_AdHocFilter> results = new List<Property_AdHocFilter>();
                Property_AdHocFilter objAdHoc;

                cmd = dbHelper.GetStoredProcCommand("Property_AdHocFilterSelectByFK");
                dbHelper.AddInParameter(cmd, "Pk_AdHocReport", DbType.Decimal, Pk_AdHocReport);
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
        /// Delete All AdHocFilter Records by Fk_AdHocReport 
        /// </summary>
        /// <param name="fK_AdhocReport"></param>
        public static void DeleteByFk_AdHocReport(decimal fK_AdhocReport)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Property_AdHocFilterDeleteByFK");

            db.AddInParameter(dbCommand, "Pk_AdHocReport", DbType.Decimal, fK_AdhocReport);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Map Data Reader value with variables
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        private Property_AdHocFilter MapFrom(IDataReader reader)
        {
            Property_AdHocFilter objAdHoc = new Property_AdHocFilter();
            try
            {
                if (!Convert.IsDBNull(reader["PK_AdHocFilter"])) { objAdHoc.PK_AdHocFilter = Convert.ToDecimal(reader["PK_AdHocFilter"], CultureInfo.InvariantCulture); }
                if (!Convert.IsDBNull(reader["FK_AdHocReport"])) { objAdHoc.FK_AdHocReport = Convert.ToDecimal(reader["FK_AdHocReport"], CultureInfo.InvariantCulture); }
                if (!Convert.IsDBNull(reader["FK_AdHocReportFields"])) { objAdHoc.FK_AdHocReportFields = Convert.ToDecimal(reader["FK_AdHocReportFields"], CultureInfo.InvariantCulture); }
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

                return objAdHoc;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }



}
