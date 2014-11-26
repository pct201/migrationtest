using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
    /// <summary>
    /// Data access class for Tatva_RptRentProjectionsSchedule table.
    /// </summary>
    public sealed class Tatva_RptRentProjectionsSchedule : Tatva_ReportSchedule
    {

        #region Private variables used to hold the property values

        private decimal? _PK_ID;
        private decimal? _FK_Schedule;
        private string _Region;
        private string _LeaseType;
        private string _EscalationType;
        private int? _RentYear_From;
        private int? _RentYear_To;

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
        /// Gets or sets the LeaseType value.
        /// </summary>
        public string LeaseType
        {
            get { return _LeaseType; }
            set { _LeaseType = value; }
        }

        /// <summary>
        /// Gets or sets the EscalationType value.
        /// </summary>
        public string EscalationType
        {
            get { return _EscalationType; }
            set { _EscalationType = value; }
        }

        /// <summary>
        /// Gets or sets the RentYear_From value.
        /// </summary>
        public int? RentYear_From
        {
            get { return _RentYear_From; }
            set { _RentYear_From = value; }
        }

        /// <summary>
        /// Gets or sets the RentYear_To value.
        /// </summary>
        public int? RentYear_To
        {
            get { return _RentYear_To; }
            set { _RentYear_To = value; }
        }


        #endregion

        #region Default Constructors

        /// <summary>
        /// Initializes a new instance of the Tatva_RptRentProjectionsSchedule class with default value.
        /// </summary>
        public Tatva_RptRentProjectionsSchedule()
        {

            this._PK_ID = null;
            this._FK_Schedule = null;
            this._Region = null;
            this._LeaseType = null;
            this._EscalationType = null;
            this._RentYear_From = null;
            this._RentYear_To = null;

        }

        #endregion

        #region Primary Constructors

        /// <summary>
        /// Initializes a new instance of the Tatva_RptRentProjectionsSchedule class based on Primary Key.
        /// </summary>
        public Tatva_RptRentProjectionsSchedule(decimal pK_ID)
        {
            DataTable dtTatva_RptRentProjectionsSchedule = SelectByPK(pK_ID).Tables[0];

            if (dtTatva_RptRentProjectionsSchedule.Rows.Count == 1)
            {
                DataRow drTatva_RptRentProjectionsSchedule = dtTatva_RptRentProjectionsSchedule.Rows[0];
                if (drTatva_RptRentProjectionsSchedule["PK_ID"] == DBNull.Value)
                    this._PK_ID = null;
                else
                    this._PK_ID = (decimal?)drTatva_RptRentProjectionsSchedule["PK_ID"];

                if (drTatva_RptRentProjectionsSchedule["FK_Schedule"] == DBNull.Value)
                    this._FK_Schedule = null;
                else
                    this._FK_Schedule = (decimal?)drTatva_RptRentProjectionsSchedule["FK_Schedule"];

                if (drTatva_RptRentProjectionsSchedule["Region"] == DBNull.Value)
                    this._Region = null;
                else
                    this._Region = (string)drTatva_RptRentProjectionsSchedule["Region"];

                if (drTatva_RptRentProjectionsSchedule["LeaseType"] == DBNull.Value)
                    this._LeaseType = null;
                else
                    this._LeaseType = (string)drTatva_RptRentProjectionsSchedule["LeaseType"];

                if (drTatva_RptRentProjectionsSchedule["EscalationType"] == DBNull.Value)
                    this._EscalationType = null;
                else
                    this._EscalationType = (string)drTatva_RptRentProjectionsSchedule["EscalationType"];

                if (drTatva_RptRentProjectionsSchedule["RentYear_From"] == DBNull.Value)
                    this._RentYear_From = null;
                else
                    this._RentYear_From = (int?)drTatva_RptRentProjectionsSchedule["RentYear_From"];

                if (drTatva_RptRentProjectionsSchedule["RentYear_To"] == DBNull.Value)
                    this._RentYear_To = null;
                else
                    this._RentYear_To = (int?)drTatva_RptRentProjectionsSchedule["RentYear_To"];

            }
            else
            {
                this._PK_ID = null;
                this._FK_Schedule = null;
                this._Region = null;
                this._LeaseType = null;
                this._EscalationType = null;
                this._RentYear_From = null;
                this._RentYear_To = null;
            }

        }

        #endregion

        /// <summary>
        /// Inserts a record into the Tatva_RptRentProjectionsSchedule table.
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Tatva_RptRentProjectionsScheduleInsert");

            this.FK_Schedule = base.Insert();
            db.AddInParameter(dbCommand, "FK_Schedule", DbType.Decimal, this._FK_Schedule);

            if (string.IsNullOrEmpty(this._Region))
                db.AddInParameter(dbCommand, "Region", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Region", DbType.String, this._Region);

            if (string.IsNullOrEmpty(this._LeaseType))
                db.AddInParameter(dbCommand, "LeaseType", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "LeaseType", DbType.String, this._LeaseType);

            if (string.IsNullOrEmpty(this._EscalationType))
                db.AddInParameter(dbCommand, "EscalationType", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "EscalationType", DbType.String, this._EscalationType);

            db.AddInParameter(dbCommand, "RentYear_From", DbType.Int32, this._RentYear_From);

            db.AddInParameter(dbCommand, "RentYear_To", DbType.Int32, this._RentYear_To);

            // Execute the query and return the new identity value
            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
        }

        /// <summary>
        /// Selects a single record from the Tatva_RptRentProjectionsSchedule table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        private static DataSet SelectByPK(decimal pK_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Tatva_RptRentProjectionsScheduleSelectByPK");

            db.AddInParameter(dbCommand, "PK_ID", DbType.Decimal, pK_ID);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the Tatva_RptRentProjectionsSchedule table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Tatva_RptRentProjectionsScheduleSelectAll");

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Updates a record in the Tatva_RptRentProjectionsSchedule table.
        /// </summary>
        public void Update()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Tatva_RptRentProjectionsScheduleUpdate");


            db.AddInParameter(dbCommand, "PK_ID", DbType.Decimal, this._PK_ID);

            db.AddInParameter(dbCommand, "FK_Schedule", DbType.Decimal, this._FK_Schedule);

            if (string.IsNullOrEmpty(this._Region))
                db.AddInParameter(dbCommand, "Region", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Region", DbType.String, this._Region);

            if (string.IsNullOrEmpty(this._LeaseType))
                db.AddInParameter(dbCommand, "LeaseType", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "LeaseType", DbType.String, this._LeaseType);

            if (string.IsNullOrEmpty(this._EscalationType))
                db.AddInParameter(dbCommand, "EscalationType", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "EscalationType", DbType.String, this._EscalationType);

            db.AddInParameter(dbCommand, "RentYear_From", DbType.Int32, this._RentYear_From);

            db.AddInParameter(dbCommand, "RentYear_To", DbType.Int32, this._RentYear_To);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Deletes a record from the Tatva_RptRentProjectionsSchedule table by a composite primary key.
        /// </summary>
        public static void DeleteByPK(decimal pK_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Tatva_RptRentProjectionsScheduleDeleteByPK");

            db.AddInParameter(dbCommand, "PK_ID", DbType.Decimal, pK_ID);

            db.ExecuteNonQuery(dbCommand);
        }
    }
}
