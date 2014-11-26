using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for Tatva_rptInspectionsByInspectorSchedule table.
	/// </summary>
    public sealed class clsTatva_rptInspectionsByInspectorSchedule : Tatva_ReportSchedule
	{

		#region Private variables used to hold the property values

		private decimal? _PK_ID;
		private decimal? _FK_Schedule;
		private string _Region;
		private string _DBA;
		private string _Inspector_Name;
		private DateTime? _Inspection_Date_From;
		private DateTime? _Inspection_Date_To;

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
		/// Gets or sets the DBA value.
		/// </summary>
		public string DBA
		{
			get { return _DBA; }
			set { _DBA = value; }
		}

		/// <summary>
		/// Gets or sets the Inspector_Name value.
		/// </summary>
		public string Inspector_Name
		{
			get { return _Inspector_Name; }
			set { _Inspector_Name = value; }
		}

		/// <summary>
		/// Gets or sets the Inspection_Date_From value.
		/// </summary>
		public DateTime? Inspection_Date_From
		{
			get { return _Inspection_Date_From; }
			set { _Inspection_Date_From = value; }
		}

		/// <summary>
		/// Gets or sets the Inspection_Date_To value.
		/// </summary>
		public DateTime? Inspection_Date_To
		{
			get { return _Inspection_Date_To; }
			set { _Inspection_Date_To = value; }
		}


		#endregion

		#region Default Constructors

		/// <summary>
		/// Initializes a new instance of the clsTatva_rptInspectionsByInspectorSchedule class with default value.
		/// </summary>
		public clsTatva_rptInspectionsByInspectorSchedule() 
		{
            
		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the clsTatva_rptInspectionsByInspectorSchedule class based on Primary Key.
		/// </summary>
		public clsTatva_rptInspectionsByInspectorSchedule(decimal pK_ID) 
		{
			DataTable dtTatva_rptInspectionsByInspectorSchedule = SelectByPK(pK_ID).Tables[0];

			if (dtTatva_rptInspectionsByInspectorSchedule.Rows.Count == 1)
			{
				 SetValue(dtTatva_rptInspectionsByInspectorSchedule.Rows[0]);

			}

		}


		/// <summary>
		/// Initializes a new instance of the clsTatva_rptInspectionsByInspectorSchedule class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drTatva_rptInspectionsByInspectorSchedule) 
		{
				if (drTatva_rptInspectionsByInspectorSchedule["PK_ID"] == DBNull.Value)
					this._PK_ID = null;
				else
					this._PK_ID = (decimal?)drTatva_rptInspectionsByInspectorSchedule["PK_ID"];

				if (drTatva_rptInspectionsByInspectorSchedule["FK_Schedule"] == DBNull.Value)
					this._FK_Schedule = null;
				else
					this._FK_Schedule = (decimal?)drTatva_rptInspectionsByInspectorSchedule["FK_Schedule"];

				if (drTatva_rptInspectionsByInspectorSchedule["Region"] == DBNull.Value)
					this._Region = null;
				else
					this._Region = (string)drTatva_rptInspectionsByInspectorSchedule["Region"];

				if (drTatva_rptInspectionsByInspectorSchedule["DBA"] == DBNull.Value)
					this._DBA = null;
				else
					this._DBA = (string)drTatva_rptInspectionsByInspectorSchedule["DBA"];

				if (drTatva_rptInspectionsByInspectorSchedule["Inspector_Name"] == DBNull.Value)
					this._Inspector_Name = null;
				else
					this._Inspector_Name = (string)drTatva_rptInspectionsByInspectorSchedule["Inspector_Name"];

				if (drTatva_rptInspectionsByInspectorSchedule["Inspection_Date_From"] == DBNull.Value)
					this._Inspection_Date_From = null;
				else
					this._Inspection_Date_From = (DateTime?)drTatva_rptInspectionsByInspectorSchedule["Inspection_Date_From"];

				if (drTatva_rptInspectionsByInspectorSchedule["Inspection_Date_To"] == DBNull.Value)
					this._Inspection_Date_To = null;
				else
					this._Inspection_Date_To = (DateTime?)drTatva_rptInspectionsByInspectorSchedule["Inspection_Date_To"];


		}

		#endregion

		/// <summary>
		/// Inserts a record into the Tatva_rptInspectionsByInspectorSchedule table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
            this.FK_Schedule = base.Insert();

			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Tatva_rptInspectionsByInspectorScheduleInsert");

			
			db.AddInParameter(dbCommand, "FK_Schedule", DbType.Decimal, this._FK_Schedule);
			
			if (string.IsNullOrEmpty(this._Region))
				db.AddInParameter(dbCommand, "Region", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Region", DbType.String, this._Region);
			
			if (string.IsNullOrEmpty(this._DBA))
				db.AddInParameter(dbCommand, "DBA", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "DBA", DbType.String, this._DBA);
			
			if (string.IsNullOrEmpty(this._Inspector_Name))
				db.AddInParameter(dbCommand, "Inspector_Name", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Inspector_Name", DbType.String, this._Inspector_Name);
			
			db.AddInParameter(dbCommand, "Inspection_Date_From", DbType.DateTime, this._Inspection_Date_From);
			
			db.AddInParameter(dbCommand, "Inspection_Date_To", DbType.DateTime, this._Inspection_Date_To);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the Tatva_rptInspectionsByInspectorSchedule table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		private DataSet SelectByPK(decimal pK_ID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Tatva_rptInspectionsByInspectorScheduleSelectByPK");

			db.AddInParameter(dbCommand, "PK_ID", DbType.Decimal, pK_ID);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the Tatva_rptInspectionsByInspectorSchedule table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Tatva_rptInspectionsByInspectorScheduleSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the Tatva_rptInspectionsByInspectorSchedule table.
		/// </summary>
		public void Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Tatva_rptInspectionsByInspectorScheduleUpdate");

			
			db.AddInParameter(dbCommand, "PK_ID", DbType.Decimal, this._PK_ID);
			
			db.AddInParameter(dbCommand, "FK_Schedule", DbType.Decimal, this._FK_Schedule);
			
			if (string.IsNullOrEmpty(this._Region))
				db.AddInParameter(dbCommand, "Region", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Region", DbType.String, this._Region);
			
			if (string.IsNullOrEmpty(this._DBA))
				db.AddInParameter(dbCommand, "DBA", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "DBA", DbType.String, this._DBA);
			
			if (string.IsNullOrEmpty(this._Inspector_Name))
				db.AddInParameter(dbCommand, "Inspector_Name", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Inspector_Name", DbType.String, this._Inspector_Name);
			
			db.AddInParameter(dbCommand, "Inspection_Date_From", DbType.DateTime, this._Inspection_Date_From);
			
			db.AddInParameter(dbCommand, "Inspection_Date_To", DbType.DateTime, this._Inspection_Date_To);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the Tatva_rptInspectionsByInspectorSchedule table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_ID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Tatva_rptInspectionsByInspectorScheduleDeleteByPK");

			db.AddInParameter(dbCommand, "PK_ID", DbType.Decimal, pK_ID);

			db.ExecuteNonQuery(dbCommand);
		}
	}
}
