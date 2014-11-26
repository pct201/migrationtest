using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for Tatva_RptLitigationSchedule table.
	/// </summary>
    public sealed class Tatva_RptLitigationSchedule : Tatva_ReportSchedule
    {

        #region Fields


        private decimal _PK_ID;
        private decimal _FK_Schedule;
        private DateTime _Start_Date;
        private DateTime _End_Date;
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



        #endregion


        #region Constructors

        /// <summary> 

        /// Initializes a new instance of the Tatva_RptLitigationSchedule class. with the default value.

        /// </summary>
        public Tatva_RptLitigationSchedule()
        {

            this._PK_ID = -1;
            this._FK_Schedule = -1;
            this._Start_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            this._End_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            this._Region = "";

        }



        /// <summary> 
        /// Initializes a new instance of the Tatva_RptLitigationSchedule class for passed PrimaryKey with the values set from Database.
        /// </summary>
        public Tatva_RptLitigationSchedule(decimal PK)
        {

            DataTable dtTatva_RptLitigationSchedule = SelectByPK(PK).Tables[0];

            if (dtTatva_RptLitigationSchedule.Rows.Count > 0)
            {

                DataRow drTatva_RptLitigationSchedule = dtTatva_RptLitigationSchedule.Rows[0];

                this._PK_ID = drTatva_RptLitigationSchedule["PK_ID"] != DBNull.Value ? Convert.ToDecimal(drTatva_RptLitigationSchedule["PK_ID"]) : 0;
                this._FK_Schedule = drTatva_RptLitigationSchedule["FK_Schedule"] != DBNull.Value ? Convert.ToDecimal(drTatva_RptLitigationSchedule["FK_Schedule"]) : 0;
                this._Start_Date = drTatva_RptLitigationSchedule["Start_Date"] != DBNull.Value ? Convert.ToDateTime(drTatva_RptLitigationSchedule["Start_Date"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._End_Date = drTatva_RptLitigationSchedule["End_Date"] != DBNull.Value ? Convert.ToDateTime(drTatva_RptLitigationSchedule["End_Date"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Region = Convert.ToString(drTatva_RptLitigationSchedule["Region"]);

            }

            else
            {

                this._PK_ID = -1;
                this._FK_Schedule = -1;
                this._Start_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._End_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Region = "";

            }

        }



        #endregion


        #region Methods

        /// <summary>
		/// Inserts a record into the Tatva_RptLitigationSchedule table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
            this._FK_Schedule = base.Insert();
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Tatva_RptLitigationScheduleInsert");

			db.AddInParameter(dbCommand, "FK_Schedule", DbType.Decimal, this._FK_Schedule);
			db.AddInParameter(dbCommand, "Start_Date", DbType.DateTime, this._Start_Date);
			db.AddInParameter(dbCommand, "End_Date", DbType.DateTime, this._End_Date);
			db.AddInParameter(dbCommand, "Region", DbType.String, this._Region);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the Tatva_RptLitigationSchedule table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectByPK(decimal pK_ID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Tatva_RptLitigationScheduleSelectByPK");

			db.AddInParameter(dbCommand, "PK_ID", DbType.Decimal, pK_ID);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the Tatva_RptLitigationSchedule table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Tatva_RptLitigationScheduleSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the Tatva_RptLitigationSchedule table.
		/// </summary>
		public void Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Tatva_RptLitigationScheduleUpdate");

			db.AddInParameter(dbCommand, "PK_ID", DbType.Decimal, this._PK_ID);
			db.AddInParameter(dbCommand, "FK_Schedule", DbType.Decimal, this._FK_Schedule);
			db.AddInParameter(dbCommand, "Start_Date", DbType.DateTime, this._Start_Date);
			db.AddInParameter(dbCommand, "End_Date", DbType.DateTime, this._End_Date);
			db.AddInParameter(dbCommand, "Region", DbType.String, this._Region);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the Tatva_RptLitigationSchedule table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_ID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Tatva_RptLitigationScheduleDeleteByPK");

			db.AddInParameter(dbCommand, "PK_ID", DbType.Decimal, pK_ID);

			db.ExecuteNonQuery(dbCommand);
        }
        #endregion
    }
}
