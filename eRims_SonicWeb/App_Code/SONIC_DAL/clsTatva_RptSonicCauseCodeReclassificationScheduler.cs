using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for Tatva_RptSonicCauseCodeReclassificationScheduler table.
	/// </summary>
    public sealed class clsTatva_RptSonicCauseCodeReclassificationScheduler : Tatva_ReportSchedule
	{

		#region Private variables used to hold the property values

		private decimal? _PK_ID;
		private decimal? _FK_Schedule;
		private string _Region;
		private string _Location;
		private DateTime? _Date_of_Injury_Begin;
		private DateTime? _Date_of_Injury_End;
		private decimal? _FirstReportNumber;
		private decimal? _IncidentInvestigationNumber;
		private string _ClaimNumber;

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
		/// Gets or sets the Region value.
		/// </summary>
		public string Region
		{
			get { return _Region; }
			set { _Region = value; }
		}

		/// <summary>
		/// Gets or sets the Location value.
		/// </summary>
		public string Location
		{
			get { return _Location; }
			set { _Location = value; }
		}

		/// <summary>
		/// Gets or sets the Date_of_Injury_Begin value.
		/// </summary>
		public DateTime? Date_of_Injury_Begin
		{
			get { return _Date_of_Injury_Begin; }
			set { _Date_of_Injury_Begin = value; }
		}

		/// <summary>
		/// Gets or sets the Date_of_Injury_End value.
		/// </summary>
		public DateTime? Date_of_Injury_End
		{
			get { return _Date_of_Injury_End; }
			set { _Date_of_Injury_End = value; }
		}

		/// <summary>
		/// Gets or sets the FirstReportNumber value.
		/// </summary>
		public decimal? FirstReportNumber
		{
			get { return _FirstReportNumber; }
			set { _FirstReportNumber = value; }
		}

		/// <summary>
		/// Gets or sets the IncidentInvestigationNumber value.
		/// </summary>
		public decimal? IncidentInvestigationNumber
		{
			get { return _IncidentInvestigationNumber; }
			set { _IncidentInvestigationNumber = value; }
		}

		/// <summary>
		/// Gets or sets the ClaimNumber value.
		/// </summary>
		public string ClaimNumber
		{
			get { return _ClaimNumber; }
			set { _ClaimNumber = value; }
		}


		#endregion

		#region Default Constructors

		/// <summary>
		/// Initializes a new instance of the clsTatva_RptSonicCauseCodeReclassificationScheduler class with default value.
		/// </summary>
		public clsTatva_RptSonicCauseCodeReclassificationScheduler() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the clsTatva_RptSonicCauseCodeReclassificationScheduler class based on Primary Key.
		/// </summary>
		public clsTatva_RptSonicCauseCodeReclassificationScheduler(decimal pK_ID) 
		{
			DataTable dtTatva_RptSonicCauseCodeReclassificationScheduler = SelectByPK(pK_ID).Tables[0];

			if (dtTatva_RptSonicCauseCodeReclassificationScheduler.Rows.Count == 1)
			{
				 SetValue(dtTatva_RptSonicCauseCodeReclassificationScheduler.Rows[0]);

			}

		}


		/// <summary>
		/// Initializes a new instance of the clsTatva_RptSonicCauseCodeReclassificationScheduler class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drTatva_RptSonicCauseCodeReclassificationScheduler) 
		{
				if (drTatva_RptSonicCauseCodeReclassificationScheduler["PK_ID"] == DBNull.Value)
					this._PK_ID = null;
				else
					this._PK_ID = (decimal?)drTatva_RptSonicCauseCodeReclassificationScheduler["PK_ID"];

				if (drTatva_RptSonicCauseCodeReclassificationScheduler["FK_Schedule"] == DBNull.Value)
					this._FK_Schedule = null;
				else
					this._FK_Schedule = (decimal?)drTatva_RptSonicCauseCodeReclassificationScheduler["FK_Schedule"];

				if (drTatva_RptSonicCauseCodeReclassificationScheduler["Region"] == DBNull.Value)
					this._Region = null;
				else
					this._Region = (string)drTatva_RptSonicCauseCodeReclassificationScheduler["Region"];

				if (drTatva_RptSonicCauseCodeReclassificationScheduler["Location"] == DBNull.Value)
					this._Location = null;
				else
					this._Location = (string)drTatva_RptSonicCauseCodeReclassificationScheduler["Location"];

				if (drTatva_RptSonicCauseCodeReclassificationScheduler["Date_of_Injury_Begin"] == DBNull.Value)
					this._Date_of_Injury_Begin = null;
				else
					this._Date_of_Injury_Begin = (DateTime?)drTatva_RptSonicCauseCodeReclassificationScheduler["Date_of_Injury_Begin"];

				if (drTatva_RptSonicCauseCodeReclassificationScheduler["Date_of_Injury_End"] == DBNull.Value)
					this._Date_of_Injury_End = null;
				else
					this._Date_of_Injury_End = (DateTime?)drTatva_RptSonicCauseCodeReclassificationScheduler["Date_of_Injury_End"];

				if (drTatva_RptSonicCauseCodeReclassificationScheduler["FirstReportNumber"] == DBNull.Value)
					this._FirstReportNumber = null;
				else
					this._FirstReportNumber = (decimal?)drTatva_RptSonicCauseCodeReclassificationScheduler["FirstReportNumber"];

				if (drTatva_RptSonicCauseCodeReclassificationScheduler["IncidentInvestigationNumber"] == DBNull.Value)
					this._IncidentInvestigationNumber = null;
				else
					this._IncidentInvestigationNumber = (decimal?)drTatva_RptSonicCauseCodeReclassificationScheduler["IncidentInvestigationNumber"];

				if (drTatva_RptSonicCauseCodeReclassificationScheduler["ClaimNumber"] == DBNull.Value)
					this._ClaimNumber = null;
				else
					this._ClaimNumber = (string)drTatva_RptSonicCauseCodeReclassificationScheduler["ClaimNumber"];


		}

		#endregion

		/// <summary>
		/// Inserts a record into the Tatva_RptSonicCauseCodeReclassificationScheduler table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
            this.FK_Schedule = base.Insert();

			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Tatva_RptSonicCauseCodeReclassificationSchedulerInsert");

			
			db.AddInParameter(dbCommand, "FK_Schedule", DbType.Decimal, this._FK_Schedule);
			
			if (string.IsNullOrEmpty(this._Region))
				db.AddInParameter(dbCommand, "Region", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Region", DbType.String, this._Region);
			
			if (string.IsNullOrEmpty(this._Location))
				db.AddInParameter(dbCommand, "Location", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Location", DbType.String, this._Location);
			
			db.AddInParameter(dbCommand, "Date_of_Injury_Begin", DbType.DateTime, this._Date_of_Injury_Begin);
			
			db.AddInParameter(dbCommand, "Date_of_Injury_End", DbType.DateTime, this._Date_of_Injury_End);
			
			db.AddInParameter(dbCommand, "FirstReportNumber", DbType.Decimal, this._FirstReportNumber);
			
			db.AddInParameter(dbCommand, "IncidentInvestigationNumber", DbType.Decimal, this._IncidentInvestigationNumber);
			
			if (string.IsNullOrEmpty(this._ClaimNumber))
				db.AddInParameter(dbCommand, "ClaimNumber", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "ClaimNumber", DbType.String, this._ClaimNumber);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the Tatva_RptSonicCauseCodeReclassificationScheduler table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		private DataSet SelectByPK(decimal pK_ID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Tatva_RptSonicCauseCodeReclassificationSchedulerSelectByPK");

			db.AddInParameter(dbCommand, "PK_ID", DbType.Decimal, pK_ID);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the Tatva_RptSonicCauseCodeReclassificationScheduler table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Tatva_RptSonicCauseCodeReclassificationSchedulerSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the Tatva_RptSonicCauseCodeReclassificationScheduler table.
		/// </summary>
		public void Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Tatva_RptSonicCauseCodeReclassificationSchedulerUpdate");

			
			db.AddInParameter(dbCommand, "PK_ID", DbType.Decimal, this._PK_ID);
			
			db.AddInParameter(dbCommand, "FK_Schedule", DbType.Decimal, this._FK_Schedule);
			
			if (string.IsNullOrEmpty(this._Region))
				db.AddInParameter(dbCommand, "Region", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Region", DbType.String, this._Region);
			
			if (string.IsNullOrEmpty(this._Location))
				db.AddInParameter(dbCommand, "Location", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Location", DbType.String, this._Location);
			
			db.AddInParameter(dbCommand, "Date_of_Injury_Begin", DbType.DateTime, this._Date_of_Injury_Begin);
			
			db.AddInParameter(dbCommand, "Date_of_Injury_End", DbType.DateTime, this._Date_of_Injury_End);
			
			db.AddInParameter(dbCommand, "FirstReportNumber", DbType.Decimal, this._FirstReportNumber);
			
			db.AddInParameter(dbCommand, "IncidentInvestigationNumber", DbType.Decimal, this._IncidentInvestigationNumber);
			
			if (string.IsNullOrEmpty(this._ClaimNumber))
				db.AddInParameter(dbCommand, "ClaimNumber", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "ClaimNumber", DbType.String, this._ClaimNumber);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the Tatva_RptSonicCauseCodeReclassificationScheduler table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_ID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Tatva_RptSonicCauseCodeReclassificationSchedulerDeleteByPK");

			db.AddInParameter(dbCommand, "PK_ID", DbType.Decimal, pK_ID);

			db.ExecuteNonQuery(dbCommand);
		}
	}
}
