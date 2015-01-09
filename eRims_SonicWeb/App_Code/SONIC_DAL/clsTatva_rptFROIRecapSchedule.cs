using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for Tatva_rptFROIRecapSchedule table.
	/// </summary>
	public sealed class clsTatva_rptFROIRecapSchedule : Tatva_ReportSchedule
	{

		#region Private variables used to hold the property values

		private decimal? _PK_ID;
		private decimal? _FK_Schedule;
		private string _Region;
        private string _Market;
		private string _DBA;
		private DateTime? _Inspection_Date_From;
		private DateTime? _Inspection_Date_To;
		private string _First_Report_Category;

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

		/// <summary>
		/// Gets or sets the First_Report_Category value.
		/// </summary>
		public string First_Report_Category
		{
			get { return _First_Report_Category; }
			set { _First_Report_Category = value; }
		}


		#endregion

		#region Default Constructors

		/// <summary>
		/// Initializes a new instance of the clsTatva_rptFROIRecapSchedule class with default value.
		/// </summary>
		public clsTatva_rptFROIRecapSchedule() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the clsTatva_rptFROIRecapSchedule class based on Primary Key.
		/// </summary>
		public clsTatva_rptFROIRecapSchedule(decimal pK_ID) 
		{
			DataTable dtTatva_rptFROIRecapSchedule = SelectByPK(pK_ID).Tables[0];

			if (dtTatva_rptFROIRecapSchedule.Rows.Count == 1)
			{
				 SetValue(dtTatva_rptFROIRecapSchedule.Rows[0]);

			}

		}


		/// <summary>
		/// Initializes a new instance of the clsTatva_rptFROIRecapSchedule class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drTatva_rptFROIRecapSchedule) 
		{
				if (drTatva_rptFROIRecapSchedule["PK_ID"] == DBNull.Value)
					this._PK_ID = null;
				else
					this._PK_ID = (decimal?)drTatva_rptFROIRecapSchedule["PK_ID"];

				if (drTatva_rptFROIRecapSchedule["FK_Schedule"] == DBNull.Value)
					this._FK_Schedule = null;
				else
					this._FK_Schedule = (decimal?)drTatva_rptFROIRecapSchedule["FK_Schedule"];

				if (drTatva_rptFROIRecapSchedule["Region"] == DBNull.Value)
					this._Region = null;
				else
					this._Region = (string)drTatva_rptFROIRecapSchedule["Region"];

                if (drTatva_rptFROIRecapSchedule["Market"] == DBNull.Value)
                    this._Market = null;
                else
                    this._Market = (string)drTatva_rptFROIRecapSchedule["Market"];

				if (drTatva_rptFROIRecapSchedule["DBA"] == DBNull.Value)
					this._DBA = null;
				else
					this._DBA = (string)drTatva_rptFROIRecapSchedule["DBA"];

				if (drTatva_rptFROIRecapSchedule["Inspection_Date_From"] == DBNull.Value)
					this._Inspection_Date_From = null;
				else
					this._Inspection_Date_From = (DateTime?)drTatva_rptFROIRecapSchedule["Inspection_Date_From"];

				if (drTatva_rptFROIRecapSchedule["Inspection_Date_To"] == DBNull.Value)
					this._Inspection_Date_To = null;
				else
					this._Inspection_Date_To = (DateTime?)drTatva_rptFROIRecapSchedule["Inspection_Date_To"];

				if (drTatva_rptFROIRecapSchedule["First_Report_Category"] == DBNull.Value)
					this._First_Report_Category = null;
				else
					this._First_Report_Category = (string)drTatva_rptFROIRecapSchedule["First_Report_Category"];


		}

		#endregion

		/// <summary>
		/// Inserts a record into the Tatva_rptFROIRecapSchedule table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			this.FK_Schedule = base.Insert();

			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Tatva_rptFROIRecapScheduleInsert");

			
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
			
			db.AddInParameter(dbCommand, "Inspection_Date_From", DbType.DateTime, this._Inspection_Date_From);
			
			db.AddInParameter(dbCommand, "Inspection_Date_To", DbType.DateTime, this._Inspection_Date_To);
			
			if (string.IsNullOrEmpty(this._First_Report_Category))
				db.AddInParameter(dbCommand, "First_Report_Category", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "First_Report_Category", DbType.String, this._First_Report_Category);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the Tatva_rptFROIRecapSchedule table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		private DataSet SelectByPK(decimal pK_ID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Tatva_rptFROIRecapScheduleSelectByPK");

			db.AddInParameter(dbCommand, "PK_ID", DbType.Decimal, pK_ID);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the Tatva_rptFROIRecapSchedule table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Tatva_rptFROIRecapScheduleSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the Tatva_rptFROIRecapSchedule table.
		/// </summary>
		public void Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Tatva_rptFROIRecapScheduleUpdate");

			
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
			
			db.AddInParameter(dbCommand, "Inspection_Date_From", DbType.DateTime, this._Inspection_Date_From);
			
			db.AddInParameter(dbCommand, "Inspection_Date_To", DbType.DateTime, this._Inspection_Date_To);
			
			if (string.IsNullOrEmpty(this._First_Report_Category))
				db.AddInParameter(dbCommand, "First_Report_Category", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "First_Report_Category", DbType.String, this._First_Report_Category);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the Tatva_rptFROIRecapSchedule table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_ID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Tatva_rptFROIRecapScheduleDeleteByPK");

			db.AddInParameter(dbCommand, "PK_ID", DbType.Decimal, pK_ID);

			db.ExecuteNonQuery(dbCommand);
		}
	}
}
