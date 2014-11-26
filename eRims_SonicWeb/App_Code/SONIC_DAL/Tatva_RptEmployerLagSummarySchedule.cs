using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for Tatva_RptEmployerLagSummarySchedule table.
	/// </summary>
    public sealed class Tatva_RptEmployerLagSummarySchedule : Tatva_ReportSchedule
	{
        #region Fields

        private decimal _PK_ID;
        private decimal _FK_Schedule;
        private string _Region;
        private DateTime _From_Date_Of_Loss;
        private DateTime _To_Date_Of_Loss;

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
        /// Gets or sets the From_Date_Of_Loss value.
        /// </summary>
        public DateTime From_Date_Of_Loss
        {
            get { return _From_Date_Of_Loss; }
            set { _From_Date_Of_Loss = value; }
        }


        /// <summary> 
        /// Gets or sets the To_Date_Of_Loss value.
        /// </summary>
        public DateTime To_Date_Of_Loss
        {
            get { return _To_Date_Of_Loss; }
            set { _To_Date_Of_Loss = value; }
        }



        #endregion


        #region Constructors

        /// <summary> 

        /// Initializes a new instance of the Tatva_RptEmployerLagSummarySchedule class. with the default value.

        /// </summary>
        public Tatva_RptEmployerLagSummarySchedule()
        {
            this._PK_ID = -1;
            this._FK_Schedule = -1;
            this._Region = "";
            this._From_Date_Of_Loss = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            this._To_Date_Of_Loss = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;

        }



        /// <summary> 
        /// Initializes a new instance of the Tatva_RptEmployerLagSummarySchedule class for passed PrimaryKey with the values set from Database.
        /// </summary>
        public Tatva_RptEmployerLagSummarySchedule(decimal PK)
        {

            DataTable dtTatva_RptEmployerLagSummarySchedule = SelectByPK(PK).Tables[0];

            if (dtTatva_RptEmployerLagSummarySchedule.Rows.Count > 0)
            {

                DataRow drTatva_RptEmployerLagSummarySchedule = dtTatva_RptEmployerLagSummarySchedule.Rows[0];

                this._PK_ID = drTatva_RptEmployerLagSummarySchedule["PK_ID"] != DBNull.Value ? Convert.ToDecimal(drTatva_RptEmployerLagSummarySchedule["PK_ID"]) : 0;
                this._FK_Schedule = drTatva_RptEmployerLagSummarySchedule["FK_Schedule"] != DBNull.Value ? Convert.ToDecimal(drTatva_RptEmployerLagSummarySchedule["FK_Schedule"]) : 0;
                this._Region = Convert.ToString(drTatva_RptEmployerLagSummarySchedule["Region"]);
                this._From_Date_Of_Loss = drTatva_RptEmployerLagSummarySchedule["From_Date_Of_Loss"] != DBNull.Value ? Convert.ToDateTime(drTatva_RptEmployerLagSummarySchedule["From_Date_Of_Loss"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._To_Date_Of_Loss = drTatva_RptEmployerLagSummarySchedule["To_Date_Of_Loss"] != DBNull.Value ? Convert.ToDateTime(drTatva_RptEmployerLagSummarySchedule["To_Date_Of_Loss"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;

            }

            else
            {

                this._PK_ID = -1;
                this._FK_Schedule = -1;
                this._Region = "";
                this._From_Date_Of_Loss = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._To_Date_Of_Loss = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;

            }

        }



        #endregion

        #region "Methods"
        /// <summary>
		/// Inserts a record into the Tatva_RptEmployerLagSummarySchedule table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
            this.FK_Schedule = base.Insert();
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Tatva_RptEmployerLagSummaryScheduleInsert");

			db.AddInParameter(dbCommand, "FK_Schedule", DbType.Decimal, this._FK_Schedule);
			db.AddInParameter(dbCommand, "Region", DbType.String, this._Region);
			db.AddInParameter(dbCommand, "From_Date_Of_Loss", DbType.DateTime, this._From_Date_Of_Loss);
			db.AddInParameter(dbCommand, "To_Date_Of_Loss", DbType.DateTime, this._To_Date_Of_Loss);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the Tatva_RptEmployerLagSummarySchedule table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectByPK(decimal pK_ID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Tatva_RptEmployerLagSummaryScheduleSelectByPK");

			db.AddInParameter(dbCommand, "PK_ID", DbType.Decimal, pK_ID);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the Tatva_RptEmployerLagSummarySchedule table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Tatva_RptEmployerLagSummaryScheduleSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the Tatva_RptEmployerLagSummarySchedule table.
		/// </summary>
		public void Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Tatva_RptEmployerLagSummaryScheduleUpdate");

			db.AddInParameter(dbCommand, "PK_ID", DbType.Decimal, this._PK_ID);
			db.AddInParameter(dbCommand, "FK_Schedule", DbType.Decimal, this._FK_Schedule);
			db.AddInParameter(dbCommand, "Region", DbType.String, this._Region);
			db.AddInParameter(dbCommand, "From_Date_Of_Loss", DbType.DateTime, this._From_Date_Of_Loss);
			db.AddInParameter(dbCommand, "To_Date_Of_Loss", DbType.DateTime, this._To_Date_Of_Loss);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the Tatva_RptEmployerLagSummarySchedule table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_ID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Tatva_RptEmployerLagSummaryScheduleDeleteByPK");

			db.AddInParameter(dbCommand, "PK_ID", DbType.Decimal, pK_ID);

			db.ExecuteNonQuery(dbCommand);
        }
        #endregion
    }
}
