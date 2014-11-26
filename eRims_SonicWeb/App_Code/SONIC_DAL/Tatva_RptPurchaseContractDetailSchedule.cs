using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
    /// <summary>
    /// Data access class for Tatva_RptPurchaseContractDetailSchedule table.
    /// </summary>
    public sealed class Tatva_RptPurchaseContractDetailSchedule : Tatva_ReportSchedule
    {
        #region Fields


        private decimal _PK_ID;
        private decimal _FK_Schedule;
        private string _Region;
        private string _Location;
        private string _ServiceContract;
        private string _ServiceType;
        private Nullable<DateTime> _StartToDate;
        private Nullable<DateTime> _StartFromDate;
        private Nullable<DateTime> _EndToDate;
        private Nullable<DateTime> _EndFromDate;

        #endregion

        #region Properties


        /// <summary> 
        /// Gets or sets the PK_ID value.
        /// </summary>
        public decimal PK_ID
        {
            get { return _PK_ID; }
            set { _PK_ID = value; }
        }


        /// <summary> 
        /// Gets or sets the FK_Schedule value.
        /// </summary>
        public decimal FK_Schedule
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
        /// Gets or sets the Location value.
        /// </summary>
        public string Location
        {
            get { return _Location; }
            set { _Location = value; }
        }


        /// <summary> 
        /// Gets or sets the ServiceContract value.
        /// </summary>
        public string ServiceContract
        {
            get { return _ServiceContract; }
            set { _ServiceContract = value; }
        }


        /// <summary> 
        /// Gets or sets the ServiceType value.
        /// </summary>
        public string ServiceType
        {
            get { return _ServiceType; }
            set { _ServiceType = value; }
        }


        /// <summary> 
        /// Gets or sets the StartToDate value.
        /// </summary>
        public Nullable<DateTime> StartToDate
        {
            get { return _StartToDate; }
            set { _StartToDate = value; }
        }


        /// <summary> 
        /// Gets or sets the StartFromDate value.
        /// </summary>
        public Nullable<DateTime> StartFromDate
        {
            get { return _StartFromDate; }
            set { _StartFromDate = value; }
        }


        /// <summary> 
        /// Gets or sets the EndToDate value.
        /// </summary>
        public Nullable<DateTime> EndToDate
        {
            get { return _EndToDate; }
            set { _EndToDate = value; }
        }


        /// <summary> 
        /// Gets or sets the EndFromDate value.
        /// </summary>
        public Nullable<DateTime> EndFromDate
        {
            get { return _EndFromDate; }
            set { _EndFromDate = value; }
        }



        #endregion

        #region Constructors

        /// <summary> 
        /// Initializes a new instance of the Tatva_RptPurchaseContractDetailSchedule class. with the default value.
        /// </summary>
        public Tatva_RptPurchaseContractDetailSchedule()
        {
            this._PK_ID = -1;
            this._FK_Schedule = -1;
            this._Region = "";
            this._Location = "";
            this._ServiceContract = "";
            this._ServiceType = "";
            this._StartToDate = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            this._StartFromDate = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            this._EndToDate = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            this._EndFromDate = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
        }

        /// <summary> 
        /// Initializes a new instance of the Tatva_RptPurchaseContractDetailSchedule class for passed PrimaryKey with the values set from Database.
        /// </summary>
        public Tatva_RptPurchaseContractDetailSchedule(decimal PK)
        {

            DataTable dtTatva_RptPurchaseContractDetailSchedule = SelectByPK(PK).Tables[0];

            if (dtTatva_RptPurchaseContractDetailSchedule.Rows.Count > 0)
            {

                DataRow drTatva_RptPurchaseContractDetailSchedule = dtTatva_RptPurchaseContractDetailSchedule.Rows[0];

                this._PK_ID = drTatva_RptPurchaseContractDetailSchedule["PK_ID"] != DBNull.Value ? Convert.ToDecimal(drTatva_RptPurchaseContractDetailSchedule["PK_ID"]) : 0;
                this._FK_Schedule = drTatva_RptPurchaseContractDetailSchedule["FK_Schedule"] != DBNull.Value ? Convert.ToDecimal(drTatva_RptPurchaseContractDetailSchedule["FK_Schedule"]) : 0;
                this._Region = Convert.ToString(drTatva_RptPurchaseContractDetailSchedule["Region"]);
                this._Location = Convert.ToString(drTatva_RptPurchaseContractDetailSchedule["Location"]);
                this._ServiceContract = Convert.ToString(drTatva_RptPurchaseContractDetailSchedule["ServiceContract"]);
                this._ServiceType = Convert.ToString(drTatva_RptPurchaseContractDetailSchedule["ServiceType"]);
                this._StartToDate = drTatva_RptPurchaseContractDetailSchedule["StartToDate"] != DBNull.Value ? Convert.ToDateTime(drTatva_RptPurchaseContractDetailSchedule["StartToDate"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._StartFromDate = drTatva_RptPurchaseContractDetailSchedule["StartFromDate"] != DBNull.Value ? Convert.ToDateTime(drTatva_RptPurchaseContractDetailSchedule["StartFromDate"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._EndToDate = drTatva_RptPurchaseContractDetailSchedule["EndToDate"] != DBNull.Value ? Convert.ToDateTime(drTatva_RptPurchaseContractDetailSchedule["EndToDate"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._EndFromDate = drTatva_RptPurchaseContractDetailSchedule["EndFromDate"] != DBNull.Value ? Convert.ToDateTime(drTatva_RptPurchaseContractDetailSchedule["EndFromDate"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;

            }

            else
            {

                this._PK_ID = -1;
                this._FK_Schedule = -1;
                this._Region = "";
                this._Location = "";
                this._ServiceContract = "";
                this._ServiceType = "";
                this._StartToDate = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._StartFromDate = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._EndToDate = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._EndFromDate = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;

            }

        }

        #endregion

        #region Methods
        /// <summary>
        /// Inserts a record into the Tatva_RptPurchaseContractDetailSchedule table.
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            this._FK_Schedule = base.Insert();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Tatva_RptPurchaseContractDetailScheduleInsert");

            db.AddInParameter(dbCommand, "FK_Schedule", DbType.Decimal, this._FK_Schedule);
            db.AddInParameter(dbCommand, "Region", DbType.String, this._Region);
            db.AddInParameter(dbCommand, "Location", DbType.String, this._Location);
            db.AddInParameter(dbCommand, "ServiceContract", DbType.String, this._ServiceContract);
            db.AddInParameter(dbCommand, "ServiceType", DbType.String, this._ServiceType);
            db.AddInParameter(dbCommand, "StartToDate", DbType.DateTime, this._StartToDate);
            db.AddInParameter(dbCommand, "StartFromDate", DbType.DateTime, this._StartFromDate);
            db.AddInParameter(dbCommand, "EndToDate", DbType.DateTime, this._EndToDate);
            db.AddInParameter(dbCommand, "EndFromDate", DbType.DateTime, this._EndFromDate);

            // Execute the query and return the new identity value
            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
        }

        /// <summary>
        /// Selects a single record from the Tatva_RptPurchaseContractDetailSchedule table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectByPK(decimal pK_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Tatva_RptPurchaseContractDetailScheduleSelectByPK");

            db.AddInParameter(dbCommand, "PK_ID", DbType.Decimal, pK_ID);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the Tatva_RptPurchaseContractDetailSchedule table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Tatva_RptPurchaseContractDetailScheduleSelectAll");

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Updates a record in the Tatva_RptPurchaseContractDetailSchedule table.
        /// </summary>
        public void Update()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Tatva_RptPurchaseContractDetailScheduleUpdate");

            db.AddInParameter(dbCommand, "PK_ID", DbType.Decimal, this._PK_ID);
            db.AddInParameter(dbCommand, "FK_Schedule", DbType.Decimal, this._FK_Schedule);
            db.AddInParameter(dbCommand, "Region", DbType.String, this._Region);
            db.AddInParameter(dbCommand, "Location", DbType.String, this._Location);
            db.AddInParameter(dbCommand, "ServiceContract", DbType.String, this._ServiceContract);
            db.AddInParameter(dbCommand, "ServiceType", DbType.String, this._ServiceType);
            db.AddInParameter(dbCommand, "StartToDate", DbType.DateTime, this._StartToDate);
            db.AddInParameter(dbCommand, "StartFromDate", DbType.DateTime, this._StartFromDate);
            db.AddInParameter(dbCommand, "EndToDate", DbType.DateTime, this._EndToDate);
            db.AddInParameter(dbCommand, "EndFromDate", DbType.DateTime, this._EndFromDate);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Deletes a record from the Tatva_RptPurchaseContractDetailSchedule table by a composite primary key.
        /// </summary>
        public static void DeleteByPK(decimal pK_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Tatva_RptPurchaseContractDetailScheduleDeleteByPK");

            db.AddInParameter(dbCommand, "PK_ID", DbType.Decimal, pK_ID);

            db.ExecuteNonQuery(dbCommand);
        }
        #endregion
    }
}
