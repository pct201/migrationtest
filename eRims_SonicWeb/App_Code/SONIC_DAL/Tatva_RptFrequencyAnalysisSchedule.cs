using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for Tatva_RptFrequencyAnalysisSchedule table.
	/// </summary>
	public sealed class Tatva_RptFrequencyAnalysisSchedule : Tatva_ReportSchedule
	{
        #region Fields

        private decimal _PK_ID;
        private decimal _FK_Schedule;
        private string _Claim_Type;
        private DateTime _From_Date_Of_Accident;
        private DateTime _To_Date_Of_Accident;

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
        /// Gets or sets the From_Date_Of_Accident value.
        /// </summary>
        public DateTime From_Date_Of_Accident
        {
            get { return _From_Date_Of_Accident; }
            set { _From_Date_Of_Accident = value; }
        }


        /// <summary> 
        /// Gets or sets the To_Date_Of_Accident value.
        /// </summary>
        public DateTime To_Date_Of_Accident
        {
            get { return _To_Date_Of_Accident; }
            set { _To_Date_Of_Accident = value; }
        }



        #endregion


        #region Constructors

        /// <summary> 
        /// Initializes a new instance of the Tatva_RptFrequencyAnalysisSchedule class. with the default value.
        /// </summary>
        public Tatva_RptFrequencyAnalysisSchedule()
        {
            this._PK_ID = -1;
            this._FK_Schedule = -1;
            this._Claim_Type = "";
            this._From_Date_Of_Accident = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            this._To_Date_Of_Accident = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;

        }



        /// <summary> 
        /// Initializes a new instance of the Tatva_RptFrequencyAnalysisSchedule class for passed PrimaryKey with the values set from Database.
        /// </summary>
        public Tatva_RptFrequencyAnalysisSchedule(decimal PK)
        {

            DataTable dtTatva_RptFrequencyAnalysisSchedule = SelectByPK(PK).Tables[0];

            if (dtTatva_RptFrequencyAnalysisSchedule.Rows.Count > 0)
            {

                DataRow drTatva_RptFrequencyAnalysisSchedule = dtTatva_RptFrequencyAnalysisSchedule.Rows[0];

                this._PK_ID = drTatva_RptFrequencyAnalysisSchedule["PK_ID"] != DBNull.Value ? Convert.ToDecimal(drTatva_RptFrequencyAnalysisSchedule["PK_ID"]) : 0;
                this._FK_Schedule = drTatva_RptFrequencyAnalysisSchedule["FK_Schedule"] != DBNull.Value ? Convert.ToDecimal(drTatva_RptFrequencyAnalysisSchedule["FK_Schedule"]) : 0;
                this._Claim_Type = Convert.ToString(drTatva_RptFrequencyAnalysisSchedule["Claim_Type"]);
                this._From_Date_Of_Accident = drTatva_RptFrequencyAnalysisSchedule["From_Date_Of_Accident"] != DBNull.Value ? Convert.ToDateTime(drTatva_RptFrequencyAnalysisSchedule["From_Date_Of_Accident"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._To_Date_Of_Accident = drTatva_RptFrequencyAnalysisSchedule["To_Date_Of_Accident"] != DBNull.Value ? Convert.ToDateTime(drTatva_RptFrequencyAnalysisSchedule["To_Date_Of_Accident"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;

            }

            else
            {

                this._PK_ID = -1;
                this._FK_Schedule = -1;
                this._Claim_Type = "";
                this._From_Date_Of_Accident = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._To_Date_Of_Accident = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;

            }

        }



        #endregion

        #region "Methods"
        /// <summary>
		/// Inserts a record into the Tatva_RptFrequencyAnalysisSchedule table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
            this._FK_Schedule = base.Insert();
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Tatva_RptFrequencyAnalysisScheduleInsert");

			db.AddInParameter(dbCommand, "FK_Schedule", DbType.Decimal, this._FK_Schedule);
			db.AddInParameter(dbCommand, "Claim_Type", DbType.String, this._Claim_Type);
			db.AddInParameter(dbCommand, "From_Date_Of_Accident", DbType.DateTime, this._From_Date_Of_Accident);
			db.AddInParameter(dbCommand, "To_Date_Of_Accident", DbType.DateTime, this._To_Date_Of_Accident);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the Tatva_RptFrequencyAnalysisSchedule table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectByPK(decimal pK_ID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Tatva_RptFrequencyAnalysisScheduleSelectByPK");

			db.AddInParameter(dbCommand, "PK_ID", DbType.Decimal, pK_ID);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the Tatva_RptFrequencyAnalysisSchedule table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Tatva_RptFrequencyAnalysisScheduleSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the Tatva_RptFrequencyAnalysisSchedule table.
		/// </summary>
		public void Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Tatva_RptFrequencyAnalysisScheduleUpdate");

			db.AddInParameter(dbCommand, "PK_ID", DbType.Decimal, this._PK_ID);
			db.AddInParameter(dbCommand, "FK_Schedule", DbType.Decimal, this._FK_Schedule);
			db.AddInParameter(dbCommand, "Claim_Type", DbType.String, this._Claim_Type);
			db.AddInParameter(dbCommand, "From_Date_Of_Accident", DbType.DateTime, this._From_Date_Of_Accident);
			db.AddInParameter(dbCommand, "To_Date_Of_Accident", DbType.DateTime, this._To_Date_Of_Accident);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the Tatva_RptFrequencyAnalysisSchedule table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_ID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Tatva_RptFrequencyAnalysisScheduleDeleteByPK");

			db.AddInParameter(dbCommand, "PK_ID", DbType.Decimal, pK_ID);

			db.ExecuteNonQuery(dbCommand);
        }
        #endregion
    }
}
