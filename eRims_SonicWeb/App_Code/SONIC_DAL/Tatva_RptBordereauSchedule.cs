using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for Tatva_RptBordereauSchedule table.
	/// </summary>
    public sealed class Tatva_RptBordereauSchedule : Tatva_ReportSchedule
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
        /// Initializes a new instance of the Tatva_RptBordereauSchedule class. with the default value.
        /// </summary>
        public Tatva_RptBordereauSchedule()
        {
            this._PK_ID = -1;
            this._FK_Schedule = -1;
            this._Start_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            this._End_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            this._Region = "";
            this._Market = null;

        }



        /// <summary> 
        /// Initializes a new instance of the Tatva_RptBordereauSchedule class for passed PrimaryKey with the values set from Database.
        /// </summary>
        public Tatva_RptBordereauSchedule(decimal PK)
        {

            DataTable dtTatva_RptBordereauSchedule = SelectByPK(PK).Tables[0];

            if (dtTatva_RptBordereauSchedule.Rows.Count > 0)
            {

                DataRow drTatva_RptBordereauSchedule = dtTatva_RptBordereauSchedule.Rows[0];

                this._PK_ID = drTatva_RptBordereauSchedule["PK_ID"] != DBNull.Value ? Convert.ToDecimal(drTatva_RptBordereauSchedule["PK_ID"]) : 0;
                this._FK_Schedule = drTatva_RptBordereauSchedule["FK_Schedule"] != DBNull.Value ? Convert.ToDecimal(drTatva_RptBordereauSchedule["FK_Schedule"]) : 0;
                this._Start_Date = drTatva_RptBordereauSchedule["Start_Date"] != DBNull.Value ? Convert.ToDateTime(drTatva_RptBordereauSchedule["Start_Date"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._End_Date = drTatva_RptBordereauSchedule["End_Date"] != DBNull.Value ? Convert.ToDateTime(drTatva_RptBordereauSchedule["End_Date"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Region = Convert.ToString(drTatva_RptBordereauSchedule["Region"]);
                this._Market = drTatva_RptBordereauSchedule["Market"] != DBNull.Value ? Convert.ToDecimal(drTatva_RptBordereauSchedule["PK_ID"]) : 0;

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
		/// Inserts a record into the Tatva_RptBordereauSchedule table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
            this._FK_Schedule = base.Insert();
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Tatva_RptBordereauScheduleInsert");

			db.AddInParameter(dbCommand, "FK_Schedule", DbType.Decimal, this._FK_Schedule);
			db.AddInParameter(dbCommand, "Start_Date", DbType.DateTime, this._Start_Date);
			db.AddInParameter(dbCommand, "End_Date", DbType.DateTime, this._End_Date);
			db.AddInParameter(dbCommand, "Region", DbType.String, this._Region);
            db.AddInParameter(dbCommand, "Market", DbType.Decimal, this._Market);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the Tatva_RptBordereauSchedule table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectByPK(decimal pK_ID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Tatva_RptBordereauScheduleSelectByPK");

			db.AddInParameter(dbCommand, "PK_ID", DbType.Decimal, pK_ID);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the Tatva_RptBordereauSchedule table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Tatva_RptBordereauScheduleSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the Tatva_RptBordereauSchedule table.
		/// </summary>
		public void Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Tatva_RptBordereauScheduleUpdate");

			db.AddInParameter(dbCommand, "PK_ID", DbType.Decimal, this._PK_ID);
			db.AddInParameter(dbCommand, "FK_Schedule", DbType.Decimal, this._FK_Schedule);
			db.AddInParameter(dbCommand, "Start_Date", DbType.DateTime, this._Start_Date);
			db.AddInParameter(dbCommand, "End_Date", DbType.DateTime, this._End_Date);
			db.AddInParameter(dbCommand, "Region", DbType.String, this._Region);
            db.AddInParameter(dbCommand, "Market", DbType.String, this._Market);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the Tatva_RptBordereauSchedule table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_ID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Tatva_RptBordereauScheduleDeleteByPK");

			db.AddInParameter(dbCommand, "PK_ID", DbType.Decimal, pK_ID);

			db.ExecuteNonQuery(dbCommand);
        }
        #endregion
    }
}
