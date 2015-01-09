using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for Tatva_RptRiskManagementWorksheetSchedule table.
	/// </summary>
	public sealed class Tatva_RptRiskManagementWorksheetSchedule:Tatva_ReportSchedule
	{
		#region Private variables used to hold the property values

		private decimal? _PK_ID;
		private decimal? _FK_Schedule;
		private string _Region;
        private string _Market;
		private string _DBA;
		private DateTime? _Date_of_Incident_From;
		private DateTime? _Date_of_Incident_To;
		private string _FK_Part_of_Body;
		private string _Claim_Status;
        private string _Claim_StatusSelected;
        private string _Part_of_Body;
        private string _DBAList;

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
        /// Gets or sets the Market value.
        /// </summary>
        public string Market
        {
            get { return _Market; }
            set { _Market = value; }
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
		/// Gets or sets the Date_of_Incident_From value.
		/// </summary>
		public DateTime? Date_of_Incident_From
		{
			get { return _Date_of_Incident_From; }
			set { _Date_of_Incident_From = value; }
		}

		/// <summary>
		/// Gets or sets the Date_of_Incident_To value.
		/// </summary>
		public DateTime? Date_of_Incident_To
		{
			get { return _Date_of_Incident_To; }
			set { _Date_of_Incident_To = value; }
		}

		/// <summary>
		/// Gets or sets the FK_Part_of_Body value.
		/// </summary>
		public string FK_Part_of_Body
		{
			get { return _FK_Part_of_Body; }
			set { _FK_Part_of_Body = value; }
		}

		/// <summary>
		/// Gets or sets the Claim_Status value.
		/// </summary>
		public string Claim_Status
		{
			get { return _Claim_Status; }
			set { _Claim_Status = value; }
		}

        /// <summary>
        /// Gets or sets the Claim_Status value.
        /// </summary>
        public string Part_of_Body
        {
            get { return _Part_of_Body; }
            set { _Part_of_Body = value; }
        }

        /// <summary>
        /// Gets or sets the Claim_Status value.
        /// </summary>
        public string Claim_StatusSelected
        {
            get { return _Claim_StatusSelected; }
            set { _Claim_StatusSelected = value; }
        }

        /// <summary>
        /// Gets or sets the Claim_Status value.
        /// </summary>
        public string DBAList
        {
            get { return _DBAList; }
            set { _DBAList = value; }
        }

		#endregion

		#region Default Constructors

		/// <summary>
		/// Initializes a new instance of the clsTatva_RptRiskManagementWorksheetSchedule class with default value.
		/// </summary>
		public Tatva_RptRiskManagementWorksheetSchedule() 
		{		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the clsTatva_RptRiskManagementWorksheetSchedule class based on Primary Key.
		/// </summary>
		public Tatva_RptRiskManagementWorksheetSchedule(decimal pK_ID) 
		{
			DataTable dtTatva_RptRiskManagementWorksheetSchedule = SelectByPK(pK_ID).Tables[0];

			if (dtTatva_RptRiskManagementWorksheetSchedule.Rows.Count == 1)
			{
				 SetValue(dtTatva_RptRiskManagementWorksheetSchedule.Rows[0]);
			}
		}
        
		/// <summary>
		/// Initializes a new instance of the clsTatva_RptRiskManagementWorksheetSchedule class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drTatva_RptRiskManagementWorksheetSchedule) 
		{
				if (drTatva_RptRiskManagementWorksheetSchedule["PK_ID"] == DBNull.Value)
					this._PK_ID = null;
				else
					this._PK_ID = (decimal?)drTatva_RptRiskManagementWorksheetSchedule["PK_ID"];

				if (drTatva_RptRiskManagementWorksheetSchedule["FK_Schedule"] == DBNull.Value)
					this._FK_Schedule = null;
				else
					this._FK_Schedule = (decimal?)drTatva_RptRiskManagementWorksheetSchedule["FK_Schedule"];

				if (drTatva_RptRiskManagementWorksheetSchedule["Region"] == DBNull.Value)
					this._Region = null;
				else
					this._Region = (string)drTatva_RptRiskManagementWorksheetSchedule["Region"];

                if (drTatva_RptRiskManagementWorksheetSchedule["Market"] == DBNull.Value)
                    this._Market = null;
                else
                    this._Market = (string)drTatva_RptRiskManagementWorksheetSchedule["Market"];

				if (drTatva_RptRiskManagementWorksheetSchedule["DBA"] == DBNull.Value)
					this._DBA = null;
				else
					this._DBA = (string)drTatva_RptRiskManagementWorksheetSchedule["DBA"];

				if (drTatva_RptRiskManagementWorksheetSchedule["Date_of_Incident_From"] == DBNull.Value)
					this._Date_of_Incident_From = null;
				else
					this._Date_of_Incident_From = (DateTime?)drTatva_RptRiskManagementWorksheetSchedule["Date_of_Incident_From"];

				if (drTatva_RptRiskManagementWorksheetSchedule["Date_of_Incident_To"] == DBNull.Value)
					this._Date_of_Incident_To = null;
				else
					this._Date_of_Incident_To = (DateTime?)drTatva_RptRiskManagementWorksheetSchedule["Date_of_Incident_To"];

				if (drTatva_RptRiskManagementWorksheetSchedule["FK_Part_of_Body"] == DBNull.Value)
					this._FK_Part_of_Body = null;
				else
					this._FK_Part_of_Body = (string)drTatva_RptRiskManagementWorksheetSchedule["FK_Part_of_Body"];

				if (drTatva_RptRiskManagementWorksheetSchedule["Claim_Status"] == DBNull.Value)
					this._Claim_Status = null;
				else
					this._Claim_Status = (string)drTatva_RptRiskManagementWorksheetSchedule["Claim_Status"];

                if (drTatva_RptRiskManagementWorksheetSchedule["Claim_StatusSelected"] == DBNull.Value)
                    this._Claim_StatusSelected = null;
                else
                    this._Claim_StatusSelected = (string)drTatva_RptRiskManagementWorksheetSchedule["Claim_StatusSelected"];

                if (drTatva_RptRiskManagementWorksheetSchedule["Part_of_Body"] == DBNull.Value)
                    this._Part_of_Body = null;
                else
                    this._Part_of_Body = (string)drTatva_RptRiskManagementWorksheetSchedule["Part_of_Body"];

                if (drTatva_RptRiskManagementWorksheetSchedule["DBAList"] == DBNull.Value)
                    this._DBAList = null;
                else
                    this._DBAList = (string)drTatva_RptRiskManagementWorksheetSchedule["DBAList"];
		}

		#endregion

		/// <summary>
		/// Inserts a record into the Tatva_RptRiskManagementWorksheetSchedule table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
             this.FK_Schedule = base.Insert();
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Tatva_RptRiskManagementWorksheetScheduleInsert");
			
			db.AddInParameter(dbCommand, "FK_Schedule", DbType.Decimal, this._FK_Schedule);			
			if (string.IsNullOrEmpty(this._Region))
				db.AddInParameter(dbCommand, "Region", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Region", DbType.String, this._Region);

            if (string.IsNullOrEmpty(this._Market))
                db.AddInParameter(dbCommand, "Market", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Market", DbType.String, this._Market);
			
			if (string.IsNullOrEmpty(this._DBA))
				db.AddInParameter(dbCommand, "DBA", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "DBA", DbType.String, this._DBA);
			
			db.AddInParameter(dbCommand, "Date_of_Incident_From", DbType.DateTime, this._Date_of_Incident_From);
			
			db.AddInParameter(dbCommand, "Date_of_Incident_To", DbType.DateTime, this._Date_of_Incident_To);
			
			if (string.IsNullOrEmpty(this._FK_Part_of_Body))
				db.AddInParameter(dbCommand, "FK_Part_of_Body", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "FK_Part_of_Body", DbType.String, this._FK_Part_of_Body);
			
			if (string.IsNullOrEmpty(this._Claim_Status))
				db.AddInParameter(dbCommand, "Claim_Status", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Claim_Status", DbType.String, this._Claim_Status);

            if (string.IsNullOrEmpty(this._Claim_StatusSelected))
                db.AddInParameter(dbCommand, "Claim_StatusSelected", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Claim_StatusSelected", DbType.String, this._Claim_StatusSelected);

            if (string.IsNullOrEmpty(this._Part_of_Body))
                db.AddInParameter(dbCommand, "Part_of_Body", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Part_of_Body", DbType.String, this._Part_of_Body);

            if (string.IsNullOrEmpty(this._DBAList))
                db.AddInParameter(dbCommand, "DBAList", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "DBAList", DbType.String, this._DBAList);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the Tatva_RptRiskManagementWorksheetSchedule table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		private DataSet SelectByPK(decimal pK_ID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Tatva_RptRiskManagementWorksheetScheduleSelectByPK");

			db.AddInParameter(dbCommand, "PK_ID", DbType.Decimal, pK_ID);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the Tatva_RptRiskManagementWorksheetSchedule table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Tatva_RptRiskManagementWorksheetScheduleSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the Tatva_RptRiskManagementWorksheetSchedule table.
		/// </summary>
		public void Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Tatva_RptRiskManagementWorksheetScheduleUpdate");

			
			db.AddInParameter(dbCommand, "PK_ID", DbType.Decimal, this._PK_ID);
			
			db.AddInParameter(dbCommand, "FK_Schedule", DbType.Decimal, this._FK_Schedule);
			
			if (string.IsNullOrEmpty(this._Region))
				db.AddInParameter(dbCommand, "Region", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Region", DbType.String, this._Region);

            if (string.IsNullOrEmpty(this._Market))
                db.AddInParameter(dbCommand, "Market", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Market", DbType.String, this._Market);
			
			if (string.IsNullOrEmpty(this._DBA))
				db.AddInParameter(dbCommand, "DBA", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "DBA", DbType.String, this._DBA);
			
			db.AddInParameter(dbCommand, "Date_of_Incident_From", DbType.DateTime, this._Date_of_Incident_From);
			
			db.AddInParameter(dbCommand, "Date_of_Incident_To", DbType.DateTime, this._Date_of_Incident_To);
			
			if (string.IsNullOrEmpty(this._FK_Part_of_Body))
				db.AddInParameter(dbCommand, "FK_Part_of_Body", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "FK_Part_of_Body", DbType.String, this._FK_Part_of_Body);
			
			if (string.IsNullOrEmpty(this._Claim_Status))
				db.AddInParameter(dbCommand, "Claim_Status", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Claim_Status", DbType.String, this._Claim_Status);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the Tatva_RptRiskManagementWorksheetSchedule table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_ID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Tatva_RptRiskManagementWorksheetScheduleDeleteByPK");

			db.AddInParameter(dbCommand, "PK_ID", DbType.Decimal, pK_ID);

			db.ExecuteNonQuery(dbCommand);
		}
	}
}
