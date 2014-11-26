using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for Tatva_RptReportableClaimsSchedule table.
	/// </summary>
	public sealed class Tatva_RptReportableClaimsSchedule : Tatva_ReportSchedule
    {
        #region Fields


        private decimal _PK_ID;
        private decimal _FK_Schedule;

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



        #endregion


        #region Constructors

        /// <summary> 

        /// Initializes a new instance of the Tatva_RptReportableClaimsSchedule class. with the default value.

        /// </summary>
        public Tatva_RptReportableClaimsSchedule()
        {

            this._PK_ID = -1;
            this._FK_Schedule = -1;

        }



        /// <summary> 
        /// Initializes a new instance of the Tatva_RptReportableClaimsSchedule class for passed PrimaryKey with the values set from Database.
        /// </summary>
        public Tatva_RptReportableClaimsSchedule(decimal PK)
        {

            DataTable dtTatva_RptReportableClaimsSchedule = SelectByPK(PK).Tables[0];

            if (dtTatva_RptReportableClaimsSchedule.Rows.Count > 0)
            {

                DataRow drTatva_RptReportableClaimsSchedule = dtTatva_RptReportableClaimsSchedule.Rows[0];

                this._PK_ID = drTatva_RptReportableClaimsSchedule["PK_ID"] != DBNull.Value ? Convert.ToDecimal(drTatva_RptReportableClaimsSchedule["PK_ID"]) : 0;
                this._FK_Schedule = drTatva_RptReportableClaimsSchedule["FK_Schedule"] != DBNull.Value ? Convert.ToDecimal(drTatva_RptReportableClaimsSchedule["FK_Schedule"]) : 0;

            }

            else
            {

                this._PK_ID = -1;
                this._FK_Schedule = -1;

            }

        }



        #endregion


        #region Methods
        /// <summary>
		/// Inserts a record into the Tatva_RptReportableClaimsSchedule table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
            this._FK_Schedule = base.Insert();
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Tatva_RptReportableClaimsScheduleInsert");

			db.AddInParameter(dbCommand, "FK_Schedule", DbType.Decimal, this._FK_Schedule);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the Tatva_RptReportableClaimsSchedule table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectByPK(decimal pK_ID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Tatva_RptReportableClaimsScheduleSelectByPK");

			db.AddInParameter(dbCommand, "PK_ID", DbType.Decimal, pK_ID);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the Tatva_RptReportableClaimsSchedule table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Tatva_RptReportableClaimsScheduleSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the Tatva_RptReportableClaimsSchedule table.
		/// </summary>
		public void Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Tatva_RptReportableClaimsScheduleUpdate");

			db.AddInParameter(dbCommand, "PK_ID", DbType.Decimal, this._PK_ID);
			db.AddInParameter(dbCommand, "FK_Schedule", DbType.Decimal, this._FK_Schedule);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the Tatva_RptReportableClaimsSchedule table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_ID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Tatva_RptReportableClaimsScheduleDeleteByPK");

			db.AddInParameter(dbCommand, "PK_ID", DbType.Decimal, pK_ID);

			db.ExecuteNonQuery(dbCommand);
        }
        #endregion
    }
}
