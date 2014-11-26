using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for Tatva_RptWCAllocationDetailSchedule table.
	/// </summary>
	public sealed class Tatva_RptWCAllocationDetailSchedule : Tatva_ReportSchedule
    {

        #region Fields
        private decimal _PK_ID;
        private decimal _FK_Schedule;
        private decimal _Year;
        private decimal _Month;
        private string _Region;

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
        /// Gets or sets the Region value.
        /// </summary>
        public string Region
        {
            get { return _Region; }
            set { _Region = value; }
        }



        #endregion


        #region Constructors

        /// <summary> 

        /// Initializes a new instance of the Tatva_RptWCAllocationDetailSchedule class. with the default value.

        /// </summary>
        public Tatva_RptWCAllocationDetailSchedule()
        {

            this._PK_ID = -1;
            this._FK_Schedule = -1;
            this._Year = -1;
            this._Month = -1;
            this._Region = "";

        }



        /// <summary> 
        /// Initializes a new instance of the Tatva_RptWCAllocationDetailSchedule class for passed PrimaryKey with the values set from Database.
        /// </summary>
        public Tatva_RptWCAllocationDetailSchedule(decimal PK)
        {

            DataTable dtTatva_RptWCAllocationDetailSchedule = SelectByPK(PK).Tables[0];

            if (dtTatva_RptWCAllocationDetailSchedule.Rows.Count > 0)
            {

                DataRow drTatva_RptWCAllocationDetailSchedule = dtTatva_RptWCAllocationDetailSchedule.Rows[0];

                this._PK_ID = drTatva_RptWCAllocationDetailSchedule["PK_ID"] != DBNull.Value ? Convert.ToDecimal(drTatva_RptWCAllocationDetailSchedule["PK_ID"]) : 0;
                this._FK_Schedule = drTatva_RptWCAllocationDetailSchedule["FK_Schedule"] != DBNull.Value ? Convert.ToDecimal(drTatva_RptWCAllocationDetailSchedule["FK_Schedule"]) : 0;
                this._Year = drTatva_RptWCAllocationDetailSchedule["Year"] != DBNull.Value ? Convert.ToDecimal(drTatva_RptWCAllocationDetailSchedule["Year"]) : 0;
                this._Month = drTatva_RptWCAllocationDetailSchedule["Month"] != DBNull.Value ? Convert.ToDecimal(drTatva_RptWCAllocationDetailSchedule["Month"]) : 0;
                this._Region = Convert.ToString(drTatva_RptWCAllocationDetailSchedule["Region"]);

            }

            else
            {

                this._PK_ID = -1;
                this._FK_Schedule = -1;
                this._Year = -1;
                this._Month = -1;
                this._Region = "";

            }

        }



        #endregion


        #region methods

        /// <summary>
		/// Inserts a record into the Tatva_RptWCAllocationDetailSchedule table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
            this._FK_Schedule = base.Insert();
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Tatva_RptWCAllocationDetailScheduleInsert");

			db.AddInParameter(dbCommand, "FK_Schedule", DbType.Decimal, this._FK_Schedule);
			db.AddInParameter(dbCommand, "Year", DbType.Decimal, this._Year);
			db.AddInParameter(dbCommand, "Month", DbType.Decimal, this._Month);
			db.AddInParameter(dbCommand, "Region", DbType.String, this._Region);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the Tatva_RptWCAllocationDetailSchedule table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectByPK(decimal pK_ID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Tatva_RptWCAllocationDetailScheduleSelectByPK");

			db.AddInParameter(dbCommand, "PK_ID", DbType.Decimal, pK_ID);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the Tatva_RptWCAllocationDetailSchedule table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Tatva_RptWCAllocationDetailScheduleSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the Tatva_RptWCAllocationDetailSchedule table.
		/// </summary>
		public void Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Tatva_RptWCAllocationDetailScheduleUpdate");

			db.AddInParameter(dbCommand, "PK_ID", DbType.Decimal, this._PK_ID);
			db.AddInParameter(dbCommand, "FK_Schedule", DbType.Decimal, this._FK_Schedule);
			db.AddInParameter(dbCommand, "Year", DbType.Decimal, this._Year);
			db.AddInParameter(dbCommand, "Month", DbType.Decimal, this._Month);
			db.AddInParameter(dbCommand, "Region", DbType.String, this._Region);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the Tatva_RptWCAllocationDetailSchedule table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_ID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Tatva_RptWCAllocationDetailScheduleDeleteByPK");

			db.AddInParameter(dbCommand, "PK_ID", DbType.Decimal, pK_ID);

			db.ExecuteNonQuery(dbCommand);
		}

#endregion
	}
}
