using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for Tatva_RptFinancialPayTypeSchedule table.
	/// </summary>
	public sealed class Tatva_RptFinancialPayTypeSchedule : Tatva_ReportSchedule
	{
        #region Fields

        private decimal _PK_ID;
        private decimal _FK_Schedule;
        private string _Accident_Year;
        private string _Region;
        private DateTime _Prior_Valuation_Date;

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
        /// Gets or sets the Accident_Year value.
        /// </summary>
        public string Accident_Year
        {
            get { return _Accident_Year; }
            set { _Accident_Year = value; }
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
        /// Gets or sets the Prior_Valuation_Date value.
        /// </summary>
        public DateTime Prior_Valuation_Date
        {
            get { return _Prior_Valuation_Date; }
            set { _Prior_Valuation_Date = value; }
        }



        #endregion


        #region Constructors

        /// <summary> 
        /// Initializes a new instance of the Tatva_RptFinancialPayTypeSchedule class. with the default value.
        /// </summary>
        public Tatva_RptFinancialPayTypeSchedule()
        {
            this._PK_ID = -1;
            this._FK_Schedule = -1;
            this._Accident_Year = "";
            this._Region = "";
            this._Prior_Valuation_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;

        }



        /// <summary> 
        /// Initializes a new instance of the Tatva_RptFinancialPayTypeSchedule class for passed PrimaryKey with the values set from Database.
        /// </summary>
        public Tatva_RptFinancialPayTypeSchedule(decimal PK)
        {

            DataTable dtTatva_RptFinancialPayTypeSchedule = SelectByPK(PK).Tables[0];

            if (dtTatva_RptFinancialPayTypeSchedule.Rows.Count > 0)
            {

                DataRow drTatva_RptFinancialPayTypeSchedule = dtTatva_RptFinancialPayTypeSchedule.Rows[0];

                this._PK_ID = drTatva_RptFinancialPayTypeSchedule["PK_ID"] != DBNull.Value ? Convert.ToDecimal(drTatva_RptFinancialPayTypeSchedule["PK_ID"]) : 0;
                this._FK_Schedule = drTatva_RptFinancialPayTypeSchedule["FK_Schedule"] != DBNull.Value ? Convert.ToDecimal(drTatva_RptFinancialPayTypeSchedule["FK_Schedule"]) : 0;
                this._Accident_Year = Convert.ToString(drTatva_RptFinancialPayTypeSchedule["Accident_Year"]);
                this._Region = Convert.ToString(drTatva_RptFinancialPayTypeSchedule["Region"]);
                this._Prior_Valuation_Date = drTatva_RptFinancialPayTypeSchedule["Prior_Valuation_Date"] != DBNull.Value ? Convert.ToDateTime(drTatva_RptFinancialPayTypeSchedule["Prior_Valuation_Date"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;

            }

            else
            {

                this._PK_ID = -1;
                this._FK_Schedule = -1;
                this._Accident_Year = "";
                this._Region = "";
                this._Prior_Valuation_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;

            }

        }



        #endregion

        #region "Methods"
        /// <summary>
		/// Inserts a record into the Tatva_RptFinancialPayTypeSchedule table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
            this.FK_Schedule = base.Insert();
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Tatva_RptFinancialPayTypeScheduleInsert");

			db.AddInParameter(dbCommand, "FK_Schedule", DbType.Decimal, this._FK_Schedule);
			db.AddInParameter(dbCommand, "Accident_Year", DbType.String, this._Accident_Year);
			db.AddInParameter(dbCommand, "Region", DbType.String, this._Region);
			db.AddInParameter(dbCommand, "Prior_Valuation_Date", DbType.DateTime, this._Prior_Valuation_Date);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the Tatva_RptFinancialPayTypeSchedule table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectByPK(decimal pK_ID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Tatva_RptFinancialPayTypeScheduleSelectByPK");

			db.AddInParameter(dbCommand, "PK_ID", DbType.Decimal, pK_ID);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the Tatva_RptFinancialPayTypeSchedule table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Tatva_RptFinancialPayTypeScheduleSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the Tatva_RptFinancialPayTypeSchedule table.
		/// </summary>
		public void Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Tatva_RptFinancialPayTypeScheduleUpdate");

			db.AddInParameter(dbCommand, "PK_ID", DbType.Decimal, this._PK_ID);
			db.AddInParameter(dbCommand, "FK_Schedule", DbType.Decimal, this._FK_Schedule);
			db.AddInParameter(dbCommand, "Accident_Year", DbType.String, this._Accident_Year);
			db.AddInParameter(dbCommand, "Region", DbType.String, this._Region);
			db.AddInParameter(dbCommand, "Prior_Valuation_Date", DbType.DateTime, this._Prior_Valuation_Date);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the Tatva_RptFinancialPayTypeSchedule table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_ID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Tatva_RptFinancialPayTypeScheduleDeleteByPK");

			db.AddInParameter(dbCommand, "PK_ID", DbType.Decimal, pK_ID);

			db.ExecuteNonQuery(dbCommand);
        }
        #endregion
    }
}
