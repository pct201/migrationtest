using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for Tatva_RptWCCauseAnalysisSchedule table.
	/// </summary>
    public sealed class Tatva_RptWCCauseAnalysisSchedule : Tatva_ReportSchedule
	{

		#region Private variables used to hold the property values

		private decimal _PK_ID;
		private decimal _FK_Schedule;
		private DateTime _From_Date_Of_Accident;
		private DateTime _To_Date_Of_Accident;

		#endregion

		#region Public Property

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

		#region Default Constructors

		/// <summary>
		/// Initializes a new instance of the Tatva_RptWCCauseAnalysisSchedule class with default value.
		/// </summary>
		public Tatva_RptWCCauseAnalysisSchedule() 
		{

            this._PK_ID = -1;
            this._FK_Schedule = -1;
            this._From_Date_Of_Accident = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            this._To_Date_Of_Accident = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;

		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the Tatva_RptWCCauseAnalysisSchedule class based on Primary Key.
		/// </summary>
		public Tatva_RptWCCauseAnalysisSchedule(decimal pK_ID) 
		{
			DataTable dtTatva_RptWCCauseAnalysisSchedule = SelectByPK(pK_ID).Tables[0];

			if (dtTatva_RptWCCauseAnalysisSchedule.Rows.Count == 1)
			{
				DataRow drTatva_RptWCCauseAnalysisSchedule = dtTatva_RptWCCauseAnalysisSchedule.Rows[0];
                this._PK_ID = drTatva_RptWCCauseAnalysisSchedule["PK_ID"] != DBNull.Value ? Convert.ToDecimal(drTatva_RptWCCauseAnalysisSchedule["PK_ID"]) : 0;
                this._FK_Schedule = drTatva_RptWCCauseAnalysisSchedule["FK_Schedule"] != DBNull.Value ? Convert.ToDecimal(drTatva_RptWCCauseAnalysisSchedule["FK_Schedule"]) : 0;
                this._From_Date_Of_Accident = drTatva_RptWCCauseAnalysisSchedule["From_Date_Of_Accident"] != DBNull.Value ? Convert.ToDateTime(drTatva_RptWCCauseAnalysisSchedule["From_Date_Of_Accident"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._To_Date_Of_Accident = drTatva_RptWCCauseAnalysisSchedule["To_Date_Of_Accident"] != DBNull.Value ? Convert.ToDateTime(drTatva_RptWCCauseAnalysisSchedule["To_Date_Of_Accident"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;

			}
			else
			{
                this._PK_ID = -1;
                this._FK_Schedule = -1;
                this._From_Date_Of_Accident = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._To_Date_Of_Accident = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
			}

		}

		#endregion

		/// <summary>
		/// Inserts a record into the Tatva_RptWCCauseAnalysisSchedule table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
            this._FK_Schedule = base.Insert();
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Tatva_RptWCCauseAnalysisScheduleInsert");


            db.AddInParameter(dbCommand, "FK_Schedule", DbType.Decimal, this._FK_Schedule);
            db.AddInParameter(dbCommand, "From_Date_Of_Accident", DbType.DateTime, this._From_Date_Of_Accident);
            db.AddInParameter(dbCommand, "To_Date_Of_Accident", DbType.DateTime, this._To_Date_Of_Accident);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the Tatva_RptWCCauseAnalysisSchedule table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		private static DataSet SelectByPK(decimal pK_ID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Tatva_RptWCCauseAnalysisScheduleSelectByPK");

			db.AddInParameter(dbCommand, "PK_ID", DbType.Decimal, pK_ID);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the Tatva_RptWCCauseAnalysisSchedule table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Tatva_RptWCCauseAnalysisScheduleSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the Tatva_RptWCCauseAnalysisSchedule table.
		/// </summary>
		public void Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Tatva_RptWCCauseAnalysisScheduleUpdate");

			
			db.AddInParameter(dbCommand, "PK_ID", DbType.Decimal, this._PK_ID);
			
			db.AddInParameter(dbCommand, "FK_Schedule", DbType.Decimal, this._FK_Schedule);
			
			db.AddInParameter(dbCommand, "From_Date_Of_Accident", DbType.DateTime, this._From_Date_Of_Accident);
			
			db.AddInParameter(dbCommand, "To_Date_Of_Accident", DbType.DateTime, this._To_Date_Of_Accident);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the Tatva_RptWCCauseAnalysisSchedule table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_ID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Tatva_RptWCCauseAnalysisScheduleDeleteByPK");

			db.AddInParameter(dbCommand, "PK_ID", DbType.Decimal, pK_ID);

			db.ExecuteNonQuery(dbCommand);
		}
	}
}
