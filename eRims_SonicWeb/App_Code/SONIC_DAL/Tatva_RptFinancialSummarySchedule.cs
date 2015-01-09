using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for Tatva_RptFinancialSummarySchedule table.
	/// </summary>
	public sealed class Tatva_RptFinancialSummarySchedule : Tatva_ReportSchedule
	{
        #region Fields

        private decimal _PK_ID;
        private decimal _FK_Schedule;
        private string _Claim_Type;
        private string _Accident_Year;
        private string _Region;
        private string _Market;
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
        /// Gets or sets the Claim_Type value.
        /// </summary>
        public string Claim_Type
        {
            get { return _Claim_Type; }
            set { _Claim_Type = value; }
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
        /// Gets or sets the Market value.
        /// </summary>
        public string Market
        {
            get { return _Market; }
            set { _Market = value; }
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
        /// Initializes a new instance of the Tatva_RptFinancialSummarySchedule class. with the default value.
        /// </summary>
        public Tatva_RptFinancialSummarySchedule()
        {
            this._PK_ID = -1;
            this._FK_Schedule = -1;
            this._Claim_Type = "";
            this._Accident_Year = "";
            this._Region = "";
            this._Market = string.Empty;
            this._Prior_Valuation_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
        }


        /// <summary> 
        /// Initializes a new instance of the Tatva_RptFinancialSummarySchedule class for passed PrimaryKey with the values set from Database.
        /// </summary>
        public Tatva_RptFinancialSummarySchedule(decimal PK)
        {

            DataTable dtTatva_RptFinancialSummarySchedule = SelectByPK(PK).Tables[0];

            if (dtTatva_RptFinancialSummarySchedule.Rows.Count > 0)
            {

                DataRow drTatva_RptFinancialSummarySchedule = dtTatva_RptFinancialSummarySchedule.Rows[0];

                this._PK_ID = drTatva_RptFinancialSummarySchedule["PK_ID"] != DBNull.Value ? Convert.ToDecimal(drTatva_RptFinancialSummarySchedule["PK_ID"]) : 0;
                this._FK_Schedule = drTatva_RptFinancialSummarySchedule["FK_Schedule"] != DBNull.Value ? Convert.ToDecimal(drTatva_RptFinancialSummarySchedule["FK_Schedule"]) : 0;
                this._Claim_Type = Convert.ToString(drTatva_RptFinancialSummarySchedule["Claim_Type"]);
                this._Accident_Year = Convert.ToString(drTatva_RptFinancialSummarySchedule["Accident_Year"]);
                this._Region = Convert.ToString(drTatva_RptFinancialSummarySchedule["Region"]);
                this._Market = Convert.ToString(drTatva_RptFinancialSummarySchedule["Market"]);
                this._Prior_Valuation_Date = drTatva_RptFinancialSummarySchedule["Prior_Valuation_Date"] != DBNull.Value ? Convert.ToDateTime(drTatva_RptFinancialSummarySchedule["Prior_Valuation_Date"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;

            }
            else
            {

                this._PK_ID = -1;
                this._FK_Schedule = -1;
                this._Claim_Type = "";
                this._Accident_Year = "";
                this._Region = "";
                this._Market = string.Empty;
                this._Prior_Valuation_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;

            }

        }



        #endregion


        #region "Methods"
        /// <summary>
		/// Inserts a record into the Tatva_RptFinancialSummarySchedule table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
            this.FK_Schedule = base.Insert();

			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Tatva_RptFinancialSummaryScheduleInsert");

			db.AddInParameter(dbCommand, "FK_Schedule", DbType.Decimal, this._FK_Schedule);
			db.AddInParameter(dbCommand, "Claim_Type", DbType.String, this._Claim_Type);
			db.AddInParameter(dbCommand, "Accident_Year", DbType.String, this._Accident_Year);
			db.AddInParameter(dbCommand, "Region", DbType.String, this._Region);
            db.AddInParameter(dbCommand, "Market", DbType.String, this._Market);
			db.AddInParameter(dbCommand, "Prior_Valuation_Date", DbType.DateTime, this._Prior_Valuation_Date);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the Tatva_RptFinancialSummarySchedule table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectByPK(decimal pK_ID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Tatva_RptFinancialSummaryScheduleSelectByPK");

			db.AddInParameter(dbCommand, "PK_ID", DbType.Decimal, pK_ID);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the Tatva_RptFinancialSummarySchedule table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Tatva_RptFinancialSummaryScheduleSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the Tatva_RptFinancialSummarySchedule table.
		/// </summary>
		public void Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Tatva_RptFinancialSummaryScheduleUpdate");

			db.AddInParameter(dbCommand, "PK_ID", DbType.Decimal, this._PK_ID);
			db.AddInParameter(dbCommand, "FK_Schedule", DbType.Decimal, this._FK_Schedule);
			db.AddInParameter(dbCommand, "Claim_Type", DbType.String, this._Claim_Type);
			db.AddInParameter(dbCommand, "Accident_Year", DbType.String, this._Accident_Year);
			db.AddInParameter(dbCommand, "Region", DbType.String, this._Region);
            db.AddInParameter(dbCommand, "Market", DbType.String, this._Market);
			db.AddInParameter(dbCommand, "Prior_Valuation_Date", DbType.DateTime, this._Prior_Valuation_Date);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the Tatva_RptFinancialSummarySchedule table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_ID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Tatva_RptFinancialSummaryScheduleDeleteByPK");

			db.AddInParameter(dbCommand, "PK_ID", DbType.Decimal, pK_ID);

			db.ExecuteNonQuery(dbCommand);
        }
        #endregion
    }
}
