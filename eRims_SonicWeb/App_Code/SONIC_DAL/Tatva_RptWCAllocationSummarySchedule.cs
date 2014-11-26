using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for Tatva_RptWCAllocationSummarySchedule table.
	/// </summary>
	public sealed class Tatva_RptWCAllocationSummarySchedule : Tatva_ReportSchedule
    {
        #region Fields
        private decimal _PK_ID;
        private decimal _FK_Schedule;
        private decimal _Year;

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
        /// Gets or sets the Year value.
        /// </summary>
        public decimal Year
        {
            get { return _Year; }
            set { _Year = value; }
        }



        #endregion


        #region Constructors

        /// <summary> 

        /// Initializes a new instance of the Tatva_RptWCAllocationSummarySchedule class. with the default value.

        /// </summary>
        public Tatva_RptWCAllocationSummarySchedule()
        {

            this._PK_ID = -1;
            this._FK_Schedule = -1;
            this._Year = -1;

        }



        /// <summary> 
        /// Initializes a new instance of the Tatva_RptWCAllocationSummarySchedule class for passed PrimaryKey with the values set from Database.
        /// </summary>
        public Tatva_RptWCAllocationSummarySchedule(decimal PK)
        {

            DataTable dtTatva_RptWCAllocationSummarySchedule = SelectByPK(PK).Tables[0];

            if (dtTatva_RptWCAllocationSummarySchedule.Rows.Count > 0)
            {

                DataRow drTatva_RptWCAllocationSummarySchedule = dtTatva_RptWCAllocationSummarySchedule.Rows[0];

                this._PK_ID = drTatva_RptWCAllocationSummarySchedule["PK_ID"] != DBNull.Value ? Convert.ToDecimal(drTatva_RptWCAllocationSummarySchedule["PK_ID"]) : 0;
                this._FK_Schedule = drTatva_RptWCAllocationSummarySchedule["FK_Schedule"] != DBNull.Value ? Convert.ToDecimal(drTatva_RptWCAllocationSummarySchedule["FK_Schedule"]) : 0;
                this._Year = drTatva_RptWCAllocationSummarySchedule["Year"] != DBNull.Value ? Convert.ToDecimal(drTatva_RptWCAllocationSummarySchedule["Year"]) : 0;

            }

            else
            {

                this._PK_ID = -1;
                this._FK_Schedule = -1;
                this._Year = -1;

            }

        }



        #endregion


        #region Methods

        /// <summary>
		/// Inserts a record into the Tatva_RptWCAllocationSummarySchedule table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
            this._FK_Schedule = base.Insert();
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Tatva_RptWCAllocationSummaryScheduleInsert");

			db.AddInParameter(dbCommand, "FK_Schedule", DbType.Decimal, this._FK_Schedule);
			db.AddInParameter(dbCommand, "Year", DbType.Decimal, this._Year);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the Tatva_RptWCAllocationSummarySchedule table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectByPK(decimal pK_ID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Tatva_RptWCAllocationSummaryScheduleSelectByPK");

			db.AddInParameter(dbCommand, "PK_ID", DbType.Decimal, pK_ID);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the Tatva_RptWCAllocationSummarySchedule table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Tatva_RptWCAllocationSummaryScheduleSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the Tatva_RptWCAllocationSummarySchedule table.
		/// </summary>
		public void Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Tatva_RptWCAllocationSummaryScheduleUpdate");

			db.AddInParameter(dbCommand, "PK_ID", DbType.Decimal, this._PK_ID);
			db.AddInParameter(dbCommand, "FK_Schedule", DbType.Decimal, this._FK_Schedule);
			db.AddInParameter(dbCommand, "Year", DbType.Decimal, this._Year);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the Tatva_RptWCAllocationSummarySchedule table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_ID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Tatva_RptWCAllocationSummaryScheduleDeleteByPK");

			db.AddInParameter(dbCommand, "PK_ID", DbType.Decimal, pK_ID);

			db.ExecuteNonQuery(dbCommand);
        }

        #endregion
    }
}
