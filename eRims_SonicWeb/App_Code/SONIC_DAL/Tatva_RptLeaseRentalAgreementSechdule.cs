using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
    /// <summary>
    /// Data access class for Tatva_RptLeaseRentalAgreementSechdule table.
    /// </summary>
    public sealed class Tatva_RptLeaseRentalAgreementSechdule : Tatva_ReportSchedule
    {
        #region Fields

        private decimal _PK_ID;
        private decimal _FK_Schedule;
        private string _Region;
        private string _Market;
        private string _Location;
        private string _EquipmentType;
        private string _LeaseRentalType;
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
        /// Gets or sets the Market value.
        /// </summary>
        public string Market
        {
            get { return _Market; }
            set { _Market = value; }
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
        /// Gets or sets the EquipmentType value.
        /// </summary>
        public string EquipmentType
        {
            get { return _EquipmentType; }
            set { _EquipmentType = value; }
        }

        /// <summary> 
        /// Gets or sets the LeaseRentalType value.
        /// </summary>
        public string LeaseRentalType
        {
            get { return _LeaseRentalType; }
            set { _LeaseRentalType = value; }
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
        /// Initializes a new instance of the Tatva_RptLeaseRentalAgreementSechdule class. with the default value.
        /// </summary>
        public Tatva_RptLeaseRentalAgreementSechdule()
        {
            this._PK_ID = -1;
            this._FK_Schedule = -1;
            this._Region = "";
            this._Market = string.Empty;
            this._Location = "";
            this._EquipmentType = "";
            this._LeaseRentalType = "";
            this._StartToDate = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            this._StartFromDate = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            this._EndToDate = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            this._EndFromDate = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;

        }



        /// <summary> 
        /// Initializes a new instance of the Tatva_RptLeaseRentalAgreementSechdule class for passed PrimaryKey with the values set from Database.
        /// </summary>
        public Tatva_RptLeaseRentalAgreementSechdule(decimal PK)
        {

            DataTable dtTatva_RptLeaseRentalAgreementSechdule = SelectByPK(PK).Tables[0];

            if (dtTatva_RptLeaseRentalAgreementSechdule.Rows.Count > 0)
            {

                DataRow drTatva_RptLeaseRentalAgreementSechdule = dtTatva_RptLeaseRentalAgreementSechdule.Rows[0];

                this._PK_ID = drTatva_RptLeaseRentalAgreementSechdule["PK_ID"] != DBNull.Value ? Convert.ToDecimal(drTatva_RptLeaseRentalAgreementSechdule["PK_ID"]) : 0;
                this._FK_Schedule = drTatva_RptLeaseRentalAgreementSechdule["FK_Schedule"] != DBNull.Value ? Convert.ToDecimal(drTatva_RptLeaseRentalAgreementSechdule["FK_Schedule"]) : 0;
                this._Region = Convert.ToString(drTatva_RptLeaseRentalAgreementSechdule["Region"]);
                this._Market = Convert.ToString(drTatva_RptLeaseRentalAgreementSechdule["Market"]);
                this._Location = Convert.ToString(drTatva_RptLeaseRentalAgreementSechdule["Location"]);
                this._EquipmentType = Convert.ToString(drTatva_RptLeaseRentalAgreementSechdule["EquipmentType"]);
                this._LeaseRentalType = Convert.ToString(drTatva_RptLeaseRentalAgreementSechdule["LeaseRentalType"]);
                this._StartToDate = drTatva_RptLeaseRentalAgreementSechdule["StartToDate"] != DBNull.Value ? Convert.ToDateTime(drTatva_RptLeaseRentalAgreementSechdule["StartToDate"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._StartFromDate = drTatva_RptLeaseRentalAgreementSechdule["StartFromDate"] != DBNull.Value ? Convert.ToDateTime(drTatva_RptLeaseRentalAgreementSechdule["StartFromDate"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._EndToDate = drTatva_RptLeaseRentalAgreementSechdule["EndToDate"] != DBNull.Value ? Convert.ToDateTime(drTatva_RptLeaseRentalAgreementSechdule["EndToDate"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._EndFromDate = drTatva_RptLeaseRentalAgreementSechdule["EndFromDate"] != DBNull.Value ? Convert.ToDateTime(drTatva_RptLeaseRentalAgreementSechdule["EndFromDate"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;

            }

            else
            {

                this._PK_ID = -1;
                this._FK_Schedule = -1;
                this._Region = "";
                this._Market = string.Empty;
                this._Location = "";
                this._EquipmentType = "";
                this._LeaseRentalType = "";
                this._StartToDate = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._StartFromDate = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._EndToDate = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._EndFromDate = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;

            }

        }



        #endregion

        #region Methods
        /// <summary>
        /// Inserts a record into the Tatva_RptLeaseRentalAgreementSechdule table.
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            this._FK_Schedule = base.Insert();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Tatva_RptLeaseRentalAgreementSechduleInsert");

            db.AddInParameter(dbCommand, "FK_Schedule", DbType.Decimal, this._FK_Schedule);
            db.AddInParameter(dbCommand, "Region", DbType.String, this._Region);
            db.AddInParameter(dbCommand, "Market", DbType.String, this._Market);
            db.AddInParameter(dbCommand, "Location", DbType.String, this._Location);
            db.AddInParameter(dbCommand, "EquipmentType", DbType.String, this._EquipmentType);
            db.AddInParameter(dbCommand, "LeaseRentalType", DbType.String, this._LeaseRentalType);
            db.AddInParameter(dbCommand, "StartToDate", DbType.DateTime, this._StartToDate);
            db.AddInParameter(dbCommand, "StartFromDate", DbType.DateTime, this._StartFromDate);
            db.AddInParameter(dbCommand, "EndToDate", DbType.DateTime, this._EndToDate);
            db.AddInParameter(dbCommand, "EndFromDate", DbType.DateTime, this._EndFromDate);

            // Execute the query and return the new identity value
            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
        }

        /// <summary>
        /// Selects a single record from the Tatva_RptLeaseRentalAgreementSechdule table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectByPK(decimal pK_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Tatva_RptLeaseRentalAgreementSechduleSelectByPK");

            db.AddInParameter(dbCommand, "PK_ID", DbType.Decimal, pK_ID);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the Tatva_RptLeaseRentalAgreementSechdule table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Tatva_RptLeaseRentalAgreementSechduleSelectAll");

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Updates a record in the Tatva_RptLeaseRentalAgreementSechdule table.
        /// </summary>
        public void Update()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Tatva_RptLeaseRentalAgreementSechduleUpdate");

            db.AddInParameter(dbCommand, "PK_ID", DbType.Decimal, this._PK_ID);
            db.AddInParameter(dbCommand, "FK_Schedule", DbType.Decimal, this._FK_Schedule);
            db.AddInParameter(dbCommand, "Region", DbType.String, this._Region);
            db.AddInParameter(dbCommand, "Market", DbType.String, this._Market);
            db.AddInParameter(dbCommand, "Location", DbType.String, this._Location);
            db.AddInParameter(dbCommand, "EquipmentType", DbType.String, this._EquipmentType);
            db.AddInParameter(dbCommand, "LeaseRentalType", DbType.String, this._LeaseRentalType);
            db.AddInParameter(dbCommand, "StartToDate", DbType.DateTime, this._StartToDate);
            db.AddInParameter(dbCommand, "StartFromDate", DbType.DateTime, this._StartFromDate);
            db.AddInParameter(dbCommand, "EndToDate", DbType.DateTime, this._EndToDate);
            db.AddInParameter(dbCommand, "EndFromDate", DbType.DateTime, this._EndFromDate);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Deletes a record from the Tatva_RptLeaseRentalAgreementSechdule table by a composite primary key.
        /// </summary>
        public static void DeleteByPK(decimal pK_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Tatva_RptLeaseRentalAgreementSechduleDeleteByPK");

            db.AddInParameter(dbCommand, "PK_ID", DbType.Decimal, pK_ID);

            db.ExecuteNonQuery(dbCommand);
        }

        #endregion
    }
}
