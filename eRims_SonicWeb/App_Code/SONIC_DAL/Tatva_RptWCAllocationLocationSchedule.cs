using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for Tatva_RptWCAllocationLocationSchedule table.
	/// </summary>
	public sealed class Tatva_RptWCAllocationLocationSchedule : Tatva_ReportSchedule
    {

        #region Fields

        private decimal _PK_ID;
        private decimal _FK_Schedule;
        private decimal _Year;
        private decimal _Month;
        private decimal _Location;

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


        /// <summary> 
        /// Gets or sets the Month value.
        /// </summary>
        public decimal Month
        {
            get { return _Month; }
            set { _Month = value; }
        }


        /// <summary> 
        /// Gets or sets the Location value.
        /// </summary>
        public decimal Location
        {
            get { return _Location; }
            set { _Location = value; }
        }



        #endregion


        #region Constructors

        /// <summary> 

        /// Initializes a new instance of the Tatva_RptWCAllocationLocationSchedule class. with the default value.

        /// </summary>
        public Tatva_RptWCAllocationLocationSchedule()
        {

            this._PK_ID = -1;
            this._FK_Schedule = -1;
            this._Year = -1;
            this._Month = -1;
            this._Location = -1;

        }



        /// <summary> 
        /// Initializes a new instance of the Tatva_RptWCAllocationLocationSchedule class for passed PrimaryKey with the values set from Database.
        /// </summary>
        public Tatva_RptWCAllocationLocationSchedule(decimal PK)
        {

            DataTable dtTatva_RptWCAllocationLocationSchedule = SelectByPK(PK).Tables[0];

            if (dtTatva_RptWCAllocationLocationSchedule.Rows.Count > 0)
            {

                DataRow drTatva_RptWCAllocationLocationSchedule = dtTatva_RptWCAllocationLocationSchedule.Rows[0];

                this._PK_ID = drTatva_RptWCAllocationLocationSchedule["PK_ID"] != DBNull.Value ? Convert.ToDecimal(drTatva_RptWCAllocationLocationSchedule["PK_ID"]) : 0;
                this._FK_Schedule = drTatva_RptWCAllocationLocationSchedule["FK_Schedule"] != DBNull.Value ? Convert.ToDecimal(drTatva_RptWCAllocationLocationSchedule["FK_Schedule"]) : 0;
                this._Year = drTatva_RptWCAllocationLocationSchedule["Year"] != DBNull.Value ? Convert.ToDecimal(drTatva_RptWCAllocationLocationSchedule["Year"]) : 0;
                this._Month = drTatva_RptWCAllocationLocationSchedule["Month"] != DBNull.Value ? Convert.ToDecimal(drTatva_RptWCAllocationLocationSchedule["Month"]) : 0;
                this._Location = drTatva_RptWCAllocationLocationSchedule["Location"] != DBNull.Value ? Convert.ToDecimal(drTatva_RptWCAllocationLocationSchedule["Location"]) : 0;

            }

            else
            {

                this._PK_ID = -1;
                this._FK_Schedule = -1;
                this._Year = -1;
                this._Month = -1;
                this._Location = -1;

            }

        }



        #endregion


        #region Methods
        /// <summary>
		/// Inserts a record into the Tatva_RptWCAllocationLocationSchedule table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
            this._FK_Schedule = base.Insert();
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Tatva_RptWCAllocationLocationScheduleInsert");

			db.AddInParameter(dbCommand, "FK_Schedule", DbType.Decimal, this._FK_Schedule);
			db.AddInParameter(dbCommand, "Year", DbType.Decimal, this._Year);
			db.AddInParameter(dbCommand, "Month", DbType.Decimal, this._Month);
			db.AddInParameter(dbCommand, "Location", DbType.Decimal, this._Location);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the Tatva_RptWCAllocationLocationSchedule table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectByPK(decimal pK_ID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Tatva_RptWCAllocationLocationScheduleSelectByPK");

			db.AddInParameter(dbCommand, "PK_ID", DbType.Decimal, pK_ID);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the Tatva_RptWCAllocationLocationSchedule table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Tatva_RptWCAllocationLocationScheduleSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the Tatva_RptWCAllocationLocationSchedule table.
		/// </summary>
		public void Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Tatva_RptWCAllocationLocationScheduleUpdate");

			db.AddInParameter(dbCommand, "PK_ID", DbType.Decimal, this._PK_ID);
			db.AddInParameter(dbCommand, "FK_Schedule", DbType.Decimal, this._FK_Schedule);
			db.AddInParameter(dbCommand, "Year", DbType.Decimal, this._Year);
			db.AddInParameter(dbCommand, "Month", DbType.Decimal, this._Month);
			db.AddInParameter(dbCommand, "Location", DbType.Decimal, this._Location);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the Tatva_RptWCAllocationLocationSchedule table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_ID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Tatva_RptWCAllocationLocationScheduleDeleteByPK");

			db.AddInParameter(dbCommand, "PK_ID", DbType.Decimal, pK_ID);

			db.ExecuteNonQuery(dbCommand);
        }

        #endregion
    }
}
