using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
    /// <summary>
    /// Data access class for Tatva_RptPropertyStatementofValuesSchedule table.
    /// </summary>
    public sealed class Tatva_RptPropertyStatementofValuesSchedule : Tatva_ReportSchedule
    {
        #region Private variables used to hold the property values

        private decimal? _PK_ID;
        private decimal? _FK_Schedule;
        private string _Region;
        private string _Status;
        private string _Ownership;
        private DateTime? _Property_Valuation_Date_FROM;
        private DateTime? _Property_Valuation_Date_To;

        #endregion

        #region Public Property

        /// <summary>
        /// Gets or sets the PK_ID value.
        /// </summary>
        public decimal? PK_ID
        {
            get { return _PK_ID; }
            set { _PK_ID = value; }
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
        /// Gets or sets the Region value.
        /// </summary>
        public string Region
        {
            get { return _Region; }
            set { _Region = value; }
        }

        /// <summary>
        /// Gets or sets the Region value.
        /// </summary>
        public string Status
        {
            get { return _Status; }
            set { _Status = value; }
        }

        /// <summary>
        /// Gets or sets the Region value.
        /// </summary>
        public string Ownership
        {
            get { return _Ownership; }
            set { _Ownership = value; }
        }


        /// <summary>
        /// Gets or sets the property valuation Date from value.
        /// </summary>
        public DateTime? Property_Valuation_Date_FROM
        {
            get { return _Property_Valuation_Date_FROM; }
            set { _Property_Valuation_Date_FROM = value; }
        }

        /// <summary>
        /// Gets or sets the property valuation Date to value.
        /// </summary>
        public DateTime? Property_Valuation_Date_To
        {
            get { return _Property_Valuation_Date_To; }
            set { _Property_Valuation_Date_To = value; }
        }

        #endregion

        #region Default Constructors

        /// <summary>
        /// Initializes a new instance of the Tatva_RptPropertyStatementofValuesSchedule class with default value.
        /// </summary>
        public Tatva_RptPropertyStatementofValuesSchedule()
        {
            this._PK_ID = null;
            this._FK_Schedule = null;
            this._Region = null;
            this._Ownership = null;
            this._Status = null;
            this._Property_Valuation_Date_To = null;
            this._Property_Valuation_Date_FROM = null;
        }

        #endregion

        #region Primary Constructors

        /// <summary>
        /// Initializes a new instance of the Tatva_RptPropertyStatementofValuesSchedule class based on Primary Key.
        /// </summary>
        public Tatva_RptPropertyStatementofValuesSchedule(decimal pK_ID)
        {
            DataTable dtTatva_RptPropertyStatementofValuesSchedule = SelectByPK(pK_ID).Tables[0];

            if (dtTatva_RptPropertyStatementofValuesSchedule.Rows.Count == 1)
            {
                DataRow drTatva_RptPropertyStatementofValuesSchedule = dtTatva_RptPropertyStatementofValuesSchedule.Rows[0];
                if (drTatva_RptPropertyStatementofValuesSchedule["PK_ID"] == DBNull.Value)
                    this._PK_ID = null;
                else
                    this._PK_ID = (decimal?)drTatva_RptPropertyStatementofValuesSchedule["PK_ID"];

                if (drTatva_RptPropertyStatementofValuesSchedule["FK_Schedule"] == DBNull.Value)
                    this._FK_Schedule = null;
                else
                    this._FK_Schedule = (decimal?)drTatva_RptPropertyStatementofValuesSchedule["FK_Schedule"];

                if (drTatva_RptPropertyStatementofValuesSchedule["Region"] == DBNull.Value)
                    this._Region = null;
                else
                    this._Region = (string)drTatva_RptPropertyStatementofValuesSchedule["Region"];

                if (drTatva_RptPropertyStatementofValuesSchedule["Status"] == DBNull.Value)
                    this._Status = null;
                else
                    this._Status = (string)drTatva_RptPropertyStatementofValuesSchedule["Status"];

                if (drTatva_RptPropertyStatementofValuesSchedule["Ownership"] == DBNull.Value)
                    this._Ownership = null;
                else
                    this._Ownership = (string)drTatva_RptPropertyStatementofValuesSchedule["Ownership"];

                if (drTatva_RptPropertyStatementofValuesSchedule["Property_Valuation_Date_FROM"] == DBNull.Value)
                    this._Property_Valuation_Date_FROM = null;
                else
                    this._Property_Valuation_Date_FROM = (DateTime)drTatva_RptPropertyStatementofValuesSchedule["Property_Valuation_Date_FROM"];

                if (drTatva_RptPropertyStatementofValuesSchedule["Property_Valuation_Date_To"] == DBNull.Value)
                    this._Property_Valuation_Date_To = null;
                else
                    this._Property_Valuation_Date_To = (DateTime)drTatva_RptPropertyStatementofValuesSchedule["Property_Valuation_Date_To"];
            }
            else
            {
                this._PK_ID = null;
                this._FK_Schedule = null;
                this._Region = null;
                this._Ownership = null;
                this._Status = null;
                this._Property_Valuation_Date_To = null;
                this._Property_Valuation_Date_FROM = null;
            }
        }

        #endregion

        /// <summary>
        /// Inserts a record into the Tatva_RptPropertyStatementofValuesSchedule table.
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Tatva_RptPropertyStatementofValuesScheduleInsert");

            this._FK_Schedule = base.Insert();
            db.AddInParameter(dbCommand, "FK_Schedule", DbType.Decimal, this._FK_Schedule);

            if (string.IsNullOrEmpty(this._Region))
                db.AddInParameter(dbCommand, "Region", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Region", DbType.String, this._Region);

            if (string.IsNullOrEmpty(this._Status))
                db.AddInParameter(dbCommand, "Status", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Status", DbType.String, this._Status);

            if (string.IsNullOrEmpty(this._Ownership))
                db.AddInParameter(dbCommand, "Ownership", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Ownership", DbType.String, this._Ownership);

           
                db.AddInParameter(dbCommand, "Property_Valuation_Date_FROM", DbType.String, this._Property_Valuation_Date_FROM);
            
                db.AddInParameter(dbCommand, "Property_Valuation_Date_To", DbType.String, this._Property_Valuation_Date_To);

            // Execute the query and return the new identity value
            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
        }

        /// <summary>
        /// Selects a single record from the Tatva_RptPropertyStatementofValuesSchedule table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        private static DataSet SelectByPK(decimal pK_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Tatva_RptPropertyStatementofValuesScheduleSelectByPK");

            db.AddInParameter(dbCommand, "PK_ID", DbType.Decimal, pK_ID);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the Tatva_RptPropertyStatementofValuesSchedule table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Tatva_RptPropertyStatementofValuesScheduleSelectAll");

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Updates a record in the Tatva_RptPropertyStatementofValuesSchedule table.
        /// </summary>
        public void Update()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Tatva_RptPropertyStatementofValuesScheduleUpdate");


            db.AddInParameter(dbCommand, "PK_ID", DbType.Decimal, this._PK_ID);

            db.AddInParameter(dbCommand, "FK_Schedule", DbType.Decimal, this._FK_Schedule);

            if (string.IsNullOrEmpty(this._Region))
                db.AddInParameter(dbCommand, "Region", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Region", DbType.String, this._Region);

            if (string.IsNullOrEmpty(this._Status))
                db.AddInParameter(dbCommand, "Status", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Status", DbType.String, this._Status);

            if (string.IsNullOrEmpty(this._Ownership))
                db.AddInParameter(dbCommand, "Ownership", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Ownership", DbType.String, this._Ownership);
           
                db.AddInParameter(dbCommand, "Property_Valuation_Date_FROM", DbType.String, this._Property_Valuation_Date_FROM);
            
                db.AddInParameter(dbCommand, "Property_Valuation_Date_To", DbType.String, this._Property_Valuation_Date_To);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Deletes a record from the Tatva_RptPropertyStatementofValuesSchedule table by a composite primary key.
        /// </summary>
        public static void DeleteByPK(decimal pK_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Tatva_RptPropertyStatementofValuesScheduleDeleteByPK");

            db.AddInParameter(dbCommand, "PK_ID", DbType.Decimal, pK_ID);

            db.ExecuteNonQuery(dbCommand);
        }
    }
}
