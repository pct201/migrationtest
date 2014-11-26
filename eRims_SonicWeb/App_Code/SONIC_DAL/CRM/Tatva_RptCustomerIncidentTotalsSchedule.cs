using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for Tatva_RptCustomerIncidentTotalsSchedule table.
	/// </summary>
	public sealed class Tatva_RptCustomerIncidentTotalsSchedule : Tatva_ReportSchedule
	{

		#region Private variables used to hold the property values

		private decimal? _PK_ID;
		private decimal? _FK_Schedule;
		private DateTime? _Begin_Date;
		private DateTime? _End_Date;
		private string _FK_LU_LocationIDs;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_ID value.
		/// </summary>
		public decimal? PK_ID
		{
			get { return _PK_ID; }
			set { _PK_ID = value; }
		}

		/// <summary>
		/// Gets or sets the FK_Schedule value.
		/// </summary>
		public decimal? FK_Schedule
		{
			get { return _FK_Schedule; }
			set { _FK_Schedule = value; }
		}

		/// <summary>
		/// Gets or sets the Begin_Date value.
		/// </summary>
		public DateTime? Begin_Date
		{
			get { return _Begin_Date; }
			set { _Begin_Date = value; }
		}

		/// <summary>
		/// Gets or sets the End_Date value.
		/// </summary>
		public DateTime? End_Date
		{
			get { return _End_Date; }
			set { _End_Date = value; }
		}

		/// <summary>
		/// Gets or sets the FK_LU_LocationIDs value.
		/// </summary>
		public string FK_LU_LocationIDs
		{
			get { return _FK_LU_LocationIDs; }
			set { _FK_LU_LocationIDs = value; }
		}


		#endregion

		#region Default Constructors

		/// <summary>
		/// Initializes a new instance of the Tatva_RptCustomerIncidentTotalsSchedule class with default value.
		/// </summary>
		public Tatva_RptCustomerIncidentTotalsSchedule() 
		{

			this._PK_ID = null;
			this._FK_Schedule = null;
			this._Begin_Date = null;
			this._End_Date = null;
			this._FK_LU_LocationIDs = null;

		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the Tatva_RptCustomerIncidentTotalsSchedule class based on Primary Key.
		/// </summary>
		public Tatva_RptCustomerIncidentTotalsSchedule(decimal pK_ID) 
		{
			DataTable dtTatva_RptCustomerIncidentTotalsSchedule = SelectByPK(pK_ID).Tables[0];

			if (dtTatva_RptCustomerIncidentTotalsSchedule.Rows.Count == 1)
			{
				DataRow drTatva_RptCustomerIncidentTotalsSchedule = dtTatva_RptCustomerIncidentTotalsSchedule.Rows[0];
				if (drTatva_RptCustomerIncidentTotalsSchedule["PK_ID"] == DBNull.Value)
					this._PK_ID = null;
				else
					this._PK_ID = (decimal?)drTatva_RptCustomerIncidentTotalsSchedule["PK_ID"];

				if (drTatva_RptCustomerIncidentTotalsSchedule["FK_Schedule"] == DBNull.Value)
					this._FK_Schedule = null;
				else
					this._FK_Schedule = (decimal?)drTatva_RptCustomerIncidentTotalsSchedule["FK_Schedule"];

				if (drTatva_RptCustomerIncidentTotalsSchedule["Begin_Date"] == DBNull.Value)
					this._Begin_Date = null;
				else
					this._Begin_Date = (DateTime?)drTatva_RptCustomerIncidentTotalsSchedule["Begin_Date"];

				if (drTatva_RptCustomerIncidentTotalsSchedule["End_Date"] == DBNull.Value)
					this._End_Date = null;
				else
					this._End_Date = (DateTime?)drTatva_RptCustomerIncidentTotalsSchedule["End_Date"];

				if (drTatva_RptCustomerIncidentTotalsSchedule["FK_LU_LocationIDs"] == DBNull.Value)
					this._FK_LU_LocationIDs = null;
				else
					this._FK_LU_LocationIDs = (string)drTatva_RptCustomerIncidentTotalsSchedule["FK_LU_LocationIDs"];

			}
			else
			{
				this._PK_ID = null;
				this._FK_Schedule = null;
				this._Begin_Date = null;
				this._End_Date = null;
				this._FK_LU_LocationIDs = null;
			}

		}

		#endregion

		/// <summary>
		/// Inserts a record into the Tatva_RptCustomerIncidentTotalsSchedule table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Tatva_RptCustomerIncidentTotalsScheduleInsert");

            this._FK_Schedule = base.Insert();
			
			db.AddInParameter(dbCommand, "FK_Schedule", DbType.Decimal, this._FK_Schedule);
			
			db.AddInParameter(dbCommand, "Begin_Date", DbType.DateTime, this._Begin_Date);
			
			db.AddInParameter(dbCommand, "End_Date", DbType.DateTime, this._End_Date);
			
			if (string.IsNullOrEmpty(this._FK_LU_LocationIDs))
				db.AddInParameter(dbCommand, "FK_LU_LocationIDs", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "FK_LU_LocationIDs", DbType.String, this._FK_LU_LocationIDs);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the Tatva_RptCustomerIncidentTotalsSchedule table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		private static DataSet SelectByPK(decimal pK_ID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Tatva_RptCustomerIncidentTotalsScheduleSelectByPK");

			db.AddInParameter(dbCommand, "PK_ID", DbType.Decimal, pK_ID);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the Tatva_RptCustomerIncidentTotalsSchedule table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Tatva_RptCustomerIncidentTotalsScheduleSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the Tatva_RptCustomerIncidentTotalsSchedule table.
		/// </summary>
		public void Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Tatva_RptCustomerIncidentTotalsScheduleUpdate");

			
			db.AddInParameter(dbCommand, "PK_ID", DbType.Decimal, this._PK_ID);
			
			db.AddInParameter(dbCommand, "FK_Schedule", DbType.Decimal, this._FK_Schedule);
			
			db.AddInParameter(dbCommand, "Begin_Date", DbType.DateTime, this._Begin_Date);
			
			db.AddInParameter(dbCommand, "End_Date", DbType.DateTime, this._End_Date);
			
			if (string.IsNullOrEmpty(this._FK_LU_LocationIDs))
				db.AddInParameter(dbCommand, "FK_LU_LocationIDs", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "FK_LU_LocationIDs", DbType.String, this._FK_LU_LocationIDs);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the Tatva_RptCustomerIncidentTotalsSchedule table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_ID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Tatva_RptCustomerIncidentTotalsScheduleDeleteByPK");

			db.AddInParameter(dbCommand, "PK_ID", DbType.Decimal, pK_ID);

			db.ExecuteNonQuery(dbCommand);
		}
	}
}
