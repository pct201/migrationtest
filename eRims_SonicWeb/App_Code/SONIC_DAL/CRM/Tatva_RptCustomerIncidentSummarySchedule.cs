using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for Tatva_RptCustomerIncidentSummarySchedule table.
	/// </summary>
	public sealed class Tatva_RptCustomerIncidentSummarySchedule : Tatva_ReportSchedule
	{

		#region Private variables used to hold the property values

		private decimal? _PK_ID;
		private decimal? _FK_Schedule;
		private int? _Year;
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
		/// Gets or sets the Year value.
		/// </summary>
		public int? Year
		{
			get { return _Year; }
			set { _Year = value; }
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
		/// Initializes a new instance of the Tatva_RptCustomerIncidentSummarySchedule class with default value.
		/// </summary>
		public Tatva_RptCustomerIncidentSummarySchedule() 
		{

			this._PK_ID = null;
			this._FK_Schedule = null;
			this._Year = null;
			this._FK_LU_LocationIDs = null;

		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the Tatva_RptCustomerIncidentSummarySchedule class based on Primary Key.
		/// </summary>
		public Tatva_RptCustomerIncidentSummarySchedule(decimal pK_ID) 
		{
			DataTable dtTatva_RptCustomerIncidentSummarySchedule = SelectByPK(pK_ID).Tables[0];

			if (dtTatva_RptCustomerIncidentSummarySchedule.Rows.Count == 1)
			{
				DataRow drTatva_RptCustomerIncidentSummarySchedule = dtTatva_RptCustomerIncidentSummarySchedule.Rows[0];
				if (drTatva_RptCustomerIncidentSummarySchedule["PK_ID"] == DBNull.Value)
					this._PK_ID = null;
				else
					this._PK_ID = (decimal?)drTatva_RptCustomerIncidentSummarySchedule["PK_ID"];

				if (drTatva_RptCustomerIncidentSummarySchedule["FK_Schedule"] == DBNull.Value)
					this._FK_Schedule = null;
				else
					this._FK_Schedule = (decimal?)drTatva_RptCustomerIncidentSummarySchedule["FK_Schedule"];

				if (drTatva_RptCustomerIncidentSummarySchedule["Year"] == DBNull.Value)
					this._Year = null;
				else
					this._Year = (int?)drTatva_RptCustomerIncidentSummarySchedule["Year"];

				if (drTatva_RptCustomerIncidentSummarySchedule["FK_LU_LocationIDs"] == DBNull.Value)
					this._FK_LU_LocationIDs = null;
				else
					this._FK_LU_LocationIDs = (string)drTatva_RptCustomerIncidentSummarySchedule["FK_LU_LocationIDs"];

			}
			else
			{
				this._PK_ID = null;
				this._FK_Schedule = null;
				this._Year = null;
				this._FK_LU_LocationIDs = null;
			}

		}

		#endregion

		/// <summary>
		/// Inserts a record into the Tatva_RptCustomerIncidentSummarySchedule table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Tatva_RptCustomerIncidentSummaryScheduleInsert");

            this._FK_Schedule = base.Insert();
	
			db.AddInParameter(dbCommand, "FK_Schedule", DbType.Decimal, this._FK_Schedule);
			
			db.AddInParameter(dbCommand, "Year", DbType.Int32, this._Year);
			
			if (string.IsNullOrEmpty(this._FK_LU_LocationIDs))
				db.AddInParameter(dbCommand, "FK_LU_LocationIDs", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "FK_LU_LocationIDs", DbType.String, this._FK_LU_LocationIDs);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the Tatva_RptCustomerIncidentSummarySchedule table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		private static DataSet SelectByPK(decimal pK_ID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Tatva_RptCustomerIncidentSummaryScheduleSelectByPK");

			db.AddInParameter(dbCommand, "PK_ID", DbType.Decimal, pK_ID);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the Tatva_RptCustomerIncidentSummarySchedule table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Tatva_RptCustomerIncidentSummaryScheduleSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the Tatva_RptCustomerIncidentSummarySchedule table.
		/// </summary>
		public void Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Tatva_RptCustomerIncidentSummaryScheduleUpdate");

			
			db.AddInParameter(dbCommand, "PK_ID", DbType.Decimal, this._PK_ID);
			
			db.AddInParameter(dbCommand, "FK_Schedule", DbType.Decimal, this._FK_Schedule);
			
			db.AddInParameter(dbCommand, "Year", DbType.Int32, this._Year);
			
			if (string.IsNullOrEmpty(this._FK_LU_LocationIDs))
				db.AddInParameter(dbCommand, "FK_LU_LocationIDs", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "FK_LU_LocationIDs", DbType.String, this._FK_LU_LocationIDs);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the Tatva_RptCustomerIncidentSummarySchedule table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_ID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Tatva_RptCustomerIncidentSummaryScheduleDeleteByPK");

			db.AddInParameter(dbCommand, "PK_ID", DbType.Decimal, pK_ID);

			db.ExecuteNonQuery(dbCommand);
		}
	}
}
