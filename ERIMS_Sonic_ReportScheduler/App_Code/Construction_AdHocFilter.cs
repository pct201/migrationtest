using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Collections.Generic;
using System.Globalization;

namespace ERIMS_DAL
{
    /// <summary>
    /// Data access class for table Construction_AdHocFilter
    /// </summary>
    public sealed class Construction_AdHocFilter
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
        private int? _IsNotSelected;

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
        public int? IsNotSelected
        {
            get { return _IsNotSelected; }
            set { _IsNotSelected = value; }
        }


        #endregion

        #region Default Constructors

        /// <summary>
        /// Initializes a new instance of the Construction_AdHocFilter class with default value.
        /// </summary>
        public Construction_AdHocFilter()
        {


        }

        #endregion

        #region Primary Constructors

        /// <summary>
        /// Initializes a new instance of the Construction_AdHocFilter class based on Primary Key.
        /// </summary>
        public Construction_AdHocFilter(decimal pK_AdHocFilter)
        {
            DataTable dtConstruction_AdHocFilter = SelectByPK(pK_AdHocFilter).Tables[0];

            if (dtConstruction_AdHocFilter.Rows.Count == 1)
            {
                SetValue(dtConstruction_AdHocFilter.Rows[0]);
            }
        }


        /// <summary>
        /// Initializes a new instance of the clsConstruction_AdHocFilter class based on Datarow passed.
        /// </summary>
        private void SetValue(DataRow drConstruction_AdHocFilter)
        {
            if (drConstruction_AdHocFilter["PK_AdHocFilter"] == DBNull.Value)
                this._PK_AdHocFilter = null;
            else
                this._PK_AdHocFilter = (decimal?)drConstruction_AdHocFilter["PK_AdHocFilter"];

            if (drConstruction_AdHocFilter["FK_AdHocReport"] == DBNull.Value)
                this._FK_AdHocReport = null;
            else
                this._FK_AdHocReport = (decimal?)drConstruction_AdHocFilter["FK_AdHocReport"];

            if (drConstruction_AdHocFilter["FK_AdHocReportFields"] == DBNull.Value)
                this._FK_AdHocReportFields = null;
            else
                this._FK_AdHocReportFields = (decimal?)drConstruction_AdHocFilter["FK_AdHocReportFields"];

            if (drConstruction_AdHocFilter["ConditionType"] == DBNull.Value)
                this._ConditionType = null;
            else
                this._ConditionType = (string)drConstruction_AdHocFilter["ConditionType"];

            if (drConstruction_AdHocFilter["ConditionValue"] == DBNull.Value)
                this._ConditionValue = null;
            else
                this._ConditionValue = (string)drConstruction_AdHocFilter["ConditionValue"];

            if (drConstruction_AdHocFilter["AmountFrom"] == DBNull.Value)
                this._AmountFrom = null;
            else
                this._AmountFrom = (decimal?)drConstruction_AdHocFilter["AmountFrom"];

            if (drConstruction_AdHocFilter["AmountTo"] == DBNull.Value)
                this._AmountTo = null;
            else
                this._AmountTo = (decimal?)drConstruction_AdHocFilter["AmountTo"];

            if (drConstruction_AdHocFilter["FromDate"] == DBNull.Value)
                this._FromDate = null;
            else
                this._FromDate = (DateTime?)drConstruction_AdHocFilter["FromDate"];

            if (drConstruction_AdHocFilter["FromRelativeCriteria"] == DBNull.Value)
                this._FromRelativeCriteria = null;
            else
                this._FromRelativeCriteria = (string)drConstruction_AdHocFilter["FromRelativeCriteria"];

            if (drConstruction_AdHocFilter["ToDate"] == DBNull.Value)
                this._ToDate = null;
            else
                this._ToDate = (DateTime?)drConstruction_AdHocFilter["ToDate"];

            if (drConstruction_AdHocFilter["ToRelativeCriteria"] == DBNull.Value)
                this._ToRelativeCriteria = null;
            else
                this._ToRelativeCriteria = (string)drConstruction_AdHocFilter["ToRelativeCriteria"];

            if (drConstruction_AdHocFilter["IsNotSelected"] == DBNull.Value)
                this._IsNotSelected = null;
            else
                this._IsNotSelected = (int?)drConstruction_AdHocFilter["IsNotSelected"];


        }

        #endregion

        /// <summary>
        /// Inserts a record into the Construction_AdHocFilter table.
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Construction_AdHocFilterInsert");


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

            db.AddInParameter(dbCommand, "IsNotSelected", DbType.Int32, this._IsNotSelected);

            // Execute the query and return the new identity value
            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
        }

        /// <summary>
        /// Selects a single record from the Construction_AdHocFilter table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        private DataSet SelectByPK(decimal pK_AdHocFilter)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Construction_AdHocFilterSelectByPK");

            db.AddInParameter(dbCommand, "PK_AdHocFilter", DbType.Decimal, pK_AdHocFilter);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the Construction_AdHocFilter table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Construction_AdHocFilterSelectAll");

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Gets Report Filter details by foreign key fK_AdHocReport
        /// </summary>
        /// <param name="fK_AdHocReport"></param>
        /// <returns></returns>
        public static DataSet SelectAdHocFilterByFK(Int32 fK_AdHocReport)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Construction_AdHocFilterSelectByFkAdHocReport");

            db.AddInParameter(dbCommand, "Pk_AdHocReport", DbType.Decimal, fK_AdHocReport);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Updates a record in the Construction_AdHocFilter table.
        /// </summary>
        public void Update()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Construction_AdHocFilterUpdate");


            db.AddInParameter(dbCommand, "PK_AdHocFilter", DbType.Decimal, this._PK_AdHocFilter);

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

            db.AddInParameter(dbCommand, "IsNotSelected", DbType.Int32, this._IsNotSelected);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Deletes a record from the Construction_AdHocFilter table by a composite primary key.
        /// </summary>
        public static void DeleteByPK(decimal pK_AdHocFilter)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Construction_AdHocFilterDeleteByPK");

            db.AddInParameter(dbCommand, "PK_AdHocFilter", DbType.Decimal, pK_AdHocFilter);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Deletes a record from the Construction_AdHocFilter table by a foreign key.
        /// </summary>
        public static void DeleteByFK(decimal fK_AdHocReport)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Construction_AdHocFilterDeleteByFK");

            db.AddInParameter(dbCommand, "FK_AdHocReport", DbType.Decimal, fK_AdHocReport);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Convert Dataset to list
        /// </summary>
        /// <param name="ds"></param>
        /// <returns></returns>
        public static List<Construction_AdHocFilter> SelectList(DataSet ds)
        {
            List<Construction_AdHocFilter> lstConstruction_AdHocFilter = new List<Construction_AdHocFilter>();
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Construction_AdHocFilter objConstruction_AdHocFilter = new Construction_AdHocFilter();
                    objConstruction_AdHocFilter.SetValue(dr);
                    lstConstruction_AdHocFilter.Add(objConstruction_AdHocFilter);
                }
            }
            return lstConstruction_AdHocFilter;
        }
    }
}
