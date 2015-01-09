using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for Tatva_RptRM_Dealership_Facility_specsSchedule table.
	/// </summary>
    public sealed class clsTatva_RptRM_Dealership_Facility_specsSchedule : Tatva_ReportSchedule
	{

		#region Private variables used to hold the property values

		private decimal? _PK_ID;
		private decimal? _FK_Schedule;
		private string _Region;
        private string _Market;
		private string _Status;
		private string _Ownership;
		private string _Brand;

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
		/// Gets or sets the Status value.
		/// </summary>
		public string Status
		{
			get { return _Status; }
			set { _Status = value; }
		}

		/// <summary>
		/// Gets or sets the Ownership value.
		/// </summary>
		public string Ownership
		{
			get { return _Ownership; }
			set { _Ownership = value; }
		}

		/// <summary>
		/// Gets or sets the Brand value.
		/// </summary>
		public string Brand
		{
			get { return _Brand; }
			set { _Brand = value; }
		}


		#endregion

		#region Default Constructors

		/// <summary>
		/// Initializes a new instance of the clsTatva_RptRM_Dealership_Facility_specsSchedule class with default value.
		/// </summary>
		public clsTatva_RptRM_Dealership_Facility_specsSchedule() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the clsTatva_RptRM_Dealership_Facility_specsSchedule class based on Primary Key.
		/// </summary>
		public clsTatva_RptRM_Dealership_Facility_specsSchedule(decimal pK_ID) 
		{
			DataTable dtTatva_RptRM_Dealership_Facility_specsSchedule = SelectByPK(pK_ID).Tables[0];

			if (dtTatva_RptRM_Dealership_Facility_specsSchedule.Rows.Count == 1)
			{
				 SetValue(dtTatva_RptRM_Dealership_Facility_specsSchedule.Rows[0]);

			}

		}


		/// <summary>
		/// Initializes a new instance of the clsTatva_RptRM_Dealership_Facility_specsSchedule class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drTatva_RptRM_Dealership_Facility_specsSchedule) 
		{
				if (drTatva_RptRM_Dealership_Facility_specsSchedule["PK_ID"] == DBNull.Value)
					this._PK_ID = null;
				else
					this._PK_ID = (decimal?)drTatva_RptRM_Dealership_Facility_specsSchedule["PK_ID"];

				if (drTatva_RptRM_Dealership_Facility_specsSchedule["FK_Schedule"] == DBNull.Value)
					this._FK_Schedule = null;
				else
					this._FK_Schedule = (decimal?)drTatva_RptRM_Dealership_Facility_specsSchedule["FK_Schedule"];

				if (drTatva_RptRM_Dealership_Facility_specsSchedule["Region"] == DBNull.Value)
					this._Region = null;
				else
					this._Region = (string)drTatva_RptRM_Dealership_Facility_specsSchedule["Region"];

                if (drTatva_RptRM_Dealership_Facility_specsSchedule["Market"] == DBNull.Value)
                    this._Market = null;
                else
                    this._Market = (string)drTatva_RptRM_Dealership_Facility_specsSchedule["Market"];

				if (drTatva_RptRM_Dealership_Facility_specsSchedule["Status"] == DBNull.Value)
					this._Status = null;
				else
					this._Status = (string)drTatva_RptRM_Dealership_Facility_specsSchedule["Status"];

				if (drTatva_RptRM_Dealership_Facility_specsSchedule["Ownership"] == DBNull.Value)
					this._Ownership = null;
				else
					this._Ownership = (string)drTatva_RptRM_Dealership_Facility_specsSchedule["Ownership"];

				if (drTatva_RptRM_Dealership_Facility_specsSchedule["Brand"] == DBNull.Value)
					this._Brand = null;
				else
					this._Brand = (string)drTatva_RptRM_Dealership_Facility_specsSchedule["Brand"];


		}

		#endregion

		/// <summary>
		/// Inserts a record into the Tatva_RptRM_Dealership_Facility_specsSchedule table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Tatva_RptRM_Dealership_Facility_specsScheduleInsert");

            this._FK_Schedule = base.Insert();
			db.AddInParameter(dbCommand, "FK_Schedule", DbType.Decimal, this._FK_Schedule);
			
			if (string.IsNullOrEmpty(this._Region))
				db.AddInParameter(dbCommand, "Region", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Region", DbType.String, this._Region);

            if (string.IsNullOrEmpty(this._Market))
                db.AddInParameter(dbCommand, "Market", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Market", DbType.String, this._Market);
			
			if (string.IsNullOrEmpty(this._Status))
				db.AddInParameter(dbCommand, "Status", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Status", DbType.String, this._Status);
			
			if (string.IsNullOrEmpty(this._Ownership))
				db.AddInParameter(dbCommand, "Ownership", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Ownership", DbType.String, this._Ownership);
			
			if (string.IsNullOrEmpty(this._Brand))
				db.AddInParameter(dbCommand, "Brand", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Brand", DbType.String, this._Brand);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the Tatva_RptRM_Dealership_Facility_specsSchedule table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		private DataSet SelectByPK(decimal pK_ID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Tatva_RptRM_Dealership_Facility_specsScheduleSelectByPK");

			db.AddInParameter(dbCommand, "PK_ID", DbType.Decimal, pK_ID);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the Tatva_RptRM_Dealership_Facility_specsSchedule table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Tatva_RptRM_Dealership_Facility_specsScheduleSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the Tatva_RptRM_Dealership_Facility_specsSchedule table.
		/// </summary>
		public void Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Tatva_RptRM_Dealership_Facility_specsScheduleUpdate");

			
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
			
			if (string.IsNullOrEmpty(this._Status))
				db.AddInParameter(dbCommand, "Status", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Status", DbType.String, this._Status);
			
			if (string.IsNullOrEmpty(this._Ownership))
				db.AddInParameter(dbCommand, "Ownership", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Ownership", DbType.String, this._Ownership);
			
			if (string.IsNullOrEmpty(this._Brand))
				db.AddInParameter(dbCommand, "Brand", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Brand", DbType.String, this._Brand);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the Tatva_RptRM_Dealership_Facility_specsSchedule table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_ID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Tatva_RptRM_Dealership_Facility_specsScheduleDeleteByPK");

			db.AddInParameter(dbCommand, "PK_ID", DbType.Decimal, pK_ID);

			db.ExecuteNonQuery(dbCommand);
		}
	}
}
