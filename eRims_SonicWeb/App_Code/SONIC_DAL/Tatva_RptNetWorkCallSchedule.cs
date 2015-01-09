using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for Tatva_RptNetWorkCallSchedule table.
	/// </summary>
    public sealed class Tatva_RptNetWorkCallSchedule : Tatva_ReportSchedule
    {

        #region Fields


        private decimal _PK_ID;
        private decimal _FK_Schedule;
        private DateTime _Start_Date;
        private DateTime _End_Date;
        private string _Region;
        private decimal? _Market;

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
        /// Gets or sets the Start_Date value.
        /// </summary>
        public DateTime Start_Date
        {
            get { return _Start_Date; }
            set { _Start_Date = value; }
        }


        /// <summary> 
        /// Gets or sets the End_Date value.
        /// </summary>
        public DateTime End_Date
        {
            get { return _End_Date; }
            set { _End_Date = value; }
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
        public decimal? Market
        {
            get { return _Market; }
            set { _Market = value; }
        }

        #endregion


        #region Constructors

        /// <summary> 

        /// Initializes a new instance of the Tatva_RptNetWorkCallSchedule class. with the default value.

        /// </summary>
        public Tatva_RptNetWorkCallSchedule()
        {

            this._PK_ID = -1;
            this._FK_Schedule = -1;
            this._Start_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            this._End_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            this._Region = "";
            this._Market = null;
        }



        /// <summary> 
        /// Initializes a new instance of the Tatva_RptNetWorkCallSchedule class for passed PrimaryKey with the values set from Database.
        /// </summary>
        public Tatva_RptNetWorkCallSchedule(decimal PK)
        {

            DataTable dtTatva_RptNetWorkCallSchedule = SelectByPK(PK).Tables[0];

            if (dtTatva_RptNetWorkCallSchedule.Rows.Count > 0)
            {

                DataRow drTatva_RptNetWorkCallSchedule = dtTatva_RptNetWorkCallSchedule.Rows[0];

                this._PK_ID = drTatva_RptNetWorkCallSchedule["PK_ID"] != DBNull.Value ? Convert.ToDecimal(drTatva_RptNetWorkCallSchedule["PK_ID"]) : 0;
                this._FK_Schedule = drTatva_RptNetWorkCallSchedule["FK_Schedule"] != DBNull.Value ? Convert.ToDecimal(drTatva_RptNetWorkCallSchedule["FK_Schedule"]) : 0;
                this._Start_Date = drTatva_RptNetWorkCallSchedule["Start_Date"] != DBNull.Value ? Convert.ToDateTime(drTatva_RptNetWorkCallSchedule["Start_Date"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._End_Date = drTatva_RptNetWorkCallSchedule["End_Date"] != DBNull.Value ? Convert.ToDateTime(drTatva_RptNetWorkCallSchedule["End_Date"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Region = Convert.ToString(drTatva_RptNetWorkCallSchedule["Region"]);
                this._Market = drTatva_RptNetWorkCallSchedule["Market"] != DBNull.Value ? Convert.ToDecimal(drTatva_RptNetWorkCallSchedule["Market"]) : 0;

            }

            else
            {

                this._PK_ID = -1;
                this._FK_Schedule = -1;
                this._Start_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._End_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Region = "";
                this._Market = null;

            }

        }



        #endregion


        #region Methods
        /// <summary>
		/// Inserts a record into the Tatva_RptNetWorkCallSchedule table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
            this._FK_Schedule = base.Insert();
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Tatva_RptNetWorkCallScheduleInsert");

			db.AddInParameter(dbCommand, "FK_Schedule", DbType.Decimal, this._FK_Schedule);
			db.AddInParameter(dbCommand, "Start_Date", DbType.DateTime, this._Start_Date);
			db.AddInParameter(dbCommand, "End_Date", DbType.DateTime, this._End_Date);
			db.AddInParameter(dbCommand, "Region", DbType.String, this._Region);
            db.AddInParameter(dbCommand, "Market", DbType.String, this._Market);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the Tatva_RptNetWorkCallSchedule table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectByPK(decimal pK_ID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Tatva_RptNetWorkCallScheduleSelectByPK");

			db.AddInParameter(dbCommand, "PK_ID", DbType.Decimal, pK_ID);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the Tatva_RptNetWorkCallSchedule table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Tatva_RptNetWorkCallScheduleSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the Tatva_RptNetWorkCallSchedule table.
		/// </summary>
		public void Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Tatva_RptNetWorkCallScheduleUpdate");

			db.AddInParameter(dbCommand, "PK_ID", DbType.Decimal, this._PK_ID);
			db.AddInParameter(dbCommand, "FK_Schedule", DbType.Decimal, this._FK_Schedule);
			db.AddInParameter(dbCommand, "Start_Date", DbType.DateTime, this._Start_Date);
			db.AddInParameter(dbCommand, "End_Date", DbType.DateTime, this._End_Date);
			db.AddInParameter(dbCommand, "Region", DbType.String, this._Region);
            db.AddInParameter(dbCommand, "Market", DbType.String, this._Market);
			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the Tatva_RptNetWorkCallSchedule table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_ID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Tatva_RptNetWorkCallScheduleDeleteByPK");

			db.AddInParameter(dbCommand, "PK_ID", DbType.Decimal, pK_ID);

			db.ExecuteNonQuery(dbCommand);
        }
        #endregion
    }
}
