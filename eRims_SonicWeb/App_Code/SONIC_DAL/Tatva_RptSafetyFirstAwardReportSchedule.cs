using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;


namespace ERIMS.DAL
{
    /// <summary>
    /// Summary description for Tatva_RptSafetyFirstAwardReportSchedule
    /// </summary>
    /// 
    public sealed class Tatva_RptSafetyFirstAwardReportSchedule : Tatva_ReportSchedule    
    {
      
        #region Private variables used to hold the property values

		private decimal? _PK_ID;
		private decimal? _FK_Schedule;		
		private int? _Year;
		private string _Region;
        private decimal? _Market;

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
        public decimal? Market
        {
            get { return _Market; }
            set { _Market = value; }
        }
        	
		#endregion

		#region Default Constructors

		/// <summary>
		/// Initializes a new instance of the Tatva_RptWCClaimManagementSchedule class with default value.
		/// </summary>
		public Tatva_RptSafetyFirstAwardReportSchedule() 
		{

			this._PK_ID = null;
			this._FK_Schedule = null;			
			this._Year = null;
			this._Region = null;
            this._Market = null;

		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the Tatva_RptWCClaimManagementSchedule class based on Primary Key.
		/// </summary>
        public Tatva_RptSafetyFirstAwardReportSchedule(decimal pK_ID) 
		{
			DataTable dtTatva_RptWCClaimManagementSchedule = SelectByPK(pK_ID).Tables[0];

			if (dtTatva_RptWCClaimManagementSchedule.Rows.Count == 1)
			{
				DataRow drTatva_RptWCClaimManagementSchedule = dtTatva_RptWCClaimManagementSchedule.Rows[0];
				if (drTatva_RptWCClaimManagementSchedule["PK_ID"] == DBNull.Value)
					this._PK_ID = null;
				else
					this._PK_ID = (decimal?)drTatva_RptWCClaimManagementSchedule["PK_ID"];

				if (drTatva_RptWCClaimManagementSchedule["FK_Schedule"] == DBNull.Value)
					this._FK_Schedule = null;
				else
					this._FK_Schedule = (decimal?)drTatva_RptWCClaimManagementSchedule["FK_Schedule"];
                				
				if (drTatva_RptWCClaimManagementSchedule["Year"] == DBNull.Value)
					this._Year = null;
				else
					this._Year = (int?)drTatva_RptWCClaimManagementSchedule["Year"];

				if (drTatva_RptWCClaimManagementSchedule["Region"] == DBNull.Value)
					this._Region = null;
				else
					this._Region = (string)drTatva_RptWCClaimManagementSchedule["Region"];

                if (drTatva_RptWCClaimManagementSchedule["Market"] == DBNull.Value)
                    this._Market = null;
                else
                    this._Market = (decimal?)drTatva_RptWCClaimManagementSchedule["Market"];
			}
			else
			{
				this._PK_ID = null;
				this._FK_Schedule = null;				
				this._Year = null;
				this._Region = null;
                this._Market = null;
			}

		}

		#endregion

		/// <summary>
		/// Inserts a record into the Tatva_RptWCClaimManagementSchedule table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Tatva_RptSafetyFirstAwardScheduleInsert");

            this._FK_Schedule = base.Insert();

			db.AddInParameter(dbCommand, "FK_Schedule", DbType.Decimal, this._FK_Schedule);
					
			db.AddInParameter(dbCommand, "Year", DbType.Int32, this._Year);
			
			if (string.IsNullOrEmpty(this._Region))
				db.AddInParameter(dbCommand, "Region", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Region", DbType.String, this._Region);

            db.AddInParameter(dbCommand, "Market", DbType.Decimal, this._Market);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the Tatva_RptWCClaimManagementSchedule table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		private static DataSet SelectByPK(decimal pK_ID)
		{
			Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Tatva_RptSafetyFirstAwardScheduleSelectByPK");

			db.AddInParameter(dbCommand, "PK_ID", DbType.Decimal, pK_ID);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the Tatva_RptWCClaimManagementSchedule table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Tatva_RptSafetyFirstAwardScheduleSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the Tatva_RptWCClaimManagementSchedule table.
		/// </summary>
		public void Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Tatva_RptSafetyFirstAwardScheduleUpdate");

			
			db.AddInParameter(dbCommand, "PK_ID", DbType.Decimal, this._PK_ID);
			
			db.AddInParameter(dbCommand, "FK_Schedule", DbType.Decimal, this._FK_Schedule);			
			
			db.AddInParameter(dbCommand, "Year", DbType.Int32, this._Year);
			
			if (string.IsNullOrEmpty(this._Region))
				db.AddInParameter(dbCommand, "Region", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Region", DbType.String, this._Region);

            db.AddInParameter(dbCommand, "Market", DbType.Decimal, this._Market);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the Tatva_RptWCClaimManagementSchedule table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_ID)
		{
			Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Tatva_RptSafetyFirstAwardScheduleDeleteByPK");

			db.AddInParameter(dbCommand, "PK_ID", DbType.Decimal, pK_ID);

			db.ExecuteNonQuery(dbCommand);
		}
    }
}