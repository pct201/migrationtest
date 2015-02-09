using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for workers_comp_charges_By_Market table.
	/// </summary>
	public sealed class Workers_comp_charges_By_Market
	{

		#region Private variables used to hold the property values

		private decimal? _Worker_Comp_Market_id;
		private int? _Year;
		private string _Market;
		private string _Cause;
		private decimal? _Charge;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the Worker_Comp_Market_id value.
		/// </summary>
		public decimal? Worker_Comp_Market_id
		{
			get { return _Worker_Comp_Market_id; }
			set { _Worker_Comp_Market_id = value; }
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
		/// Gets or sets the Market value.
		/// </summary>
		public string Market
		{
			get { return _Market; }
			set { _Market = value; }
		}

		/// <summary>
		/// Gets or sets the Cause value.
		/// </summary>
		public string Cause
		{
			get { return _Cause; }
			set { _Cause = value; }
		}

		/// <summary>
		/// Gets or sets the Charge value.
		/// </summary>
		public decimal? Charge
		{
			get { return _Charge; }
			set { _Charge = value; }
		}


		#endregion

		#region Default Constructors

		/// <summary>
		/// Initializes a new instance of the clsWorkers_comp_charges_By_Market class with default value.
		/// </summary>
		public Workers_comp_charges_By_Market() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the clsWorkers_comp_charges_By_Market class based on Primary Key.
		/// </summary>
		public Workers_comp_charges_By_Market(decimal worker_Comp_Market_id) 
		{
			DataTable dtworkers_comp_charges_By_Market = SelectByPK(worker_Comp_Market_id).Tables[0];

			if (dtworkers_comp_charges_By_Market.Rows.Count == 1)
			{
				 SetValue(dtworkers_comp_charges_By_Market.Rows[0]);

			}

		}


		/// <summary>
		/// Initializes a new instance of the clsWorkers_comp_charges_By_Market class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drworkers_comp_charges_By_Market) 
		{
				if (drworkers_comp_charges_By_Market["Worker_Comp_Market_id"] == DBNull.Value)
					this._Worker_Comp_Market_id = null;
				else
					this._Worker_Comp_Market_id = (decimal?)drworkers_comp_charges_By_Market["Worker_Comp_Market_id"];

				if (drworkers_comp_charges_By_Market["Year"] == DBNull.Value)
					this._Year = null;
				else
					this._Year = (int?)drworkers_comp_charges_By_Market["Year"];

				if (drworkers_comp_charges_By_Market["Market"] == DBNull.Value)
					this._Market = null;
				else
					this._Market = (string)drworkers_comp_charges_By_Market["Market"];

				if (drworkers_comp_charges_By_Market["Cause"] == DBNull.Value)
					this._Cause = null;
				else
					this._Cause = (string)drworkers_comp_charges_By_Market["Cause"];

				if (drworkers_comp_charges_By_Market["Charge"] == DBNull.Value)
					this._Charge = null;
				else
					this._Charge = (decimal?)drworkers_comp_charges_By_Market["Charge"];


		}

		#endregion

		/// <summary>
		/// Inserts a record into the workers_comp_charges_By_Market table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("workers_comp_charges_By_MarketInsert");

			
			db.AddInParameter(dbCommand, "Year", DbType.Int32, this._Year);
			
			if (string.IsNullOrEmpty(this._Market))
				db.AddInParameter(dbCommand, "Market", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Market", DbType.String, this._Market);
			
			if (string.IsNullOrEmpty(this._Cause))
				db.AddInParameter(dbCommand, "Cause", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Cause", DbType.String, this._Cause);
			
			db.AddInParameter(dbCommand, "Charge", DbType.Decimal, this._Charge);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the workers_comp_charges_By_Market table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		private DataSet SelectByPK(decimal worker_Comp_Market_id)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("workers_comp_charges_By_MarketSelectByPK");

			db.AddInParameter(dbCommand, "Worker_Comp_Market_id", DbType.Decimal, worker_Comp_Market_id);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the workers_comp_charges_By_Market table.
		/// </summary>
		/// <returns>DataSet</returns>
        public static DataSet SelectAll(string strOrderBy)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("workers_comp_charges_By_MarketSelectAll");
                      
            db.AddInParameter(dbCommand, "strOrderBy", DbType.String, strOrderBy);
          
            return db.ExecuteDataSet(dbCommand);
        }

		/// <summary>
		/// Updates a record in the workers_comp_charges_By_Market table.
		/// </summary>
		public void Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("workers_comp_charges_By_MarketUpdate");

			
			db.AddInParameter(dbCommand, "Worker_Comp_Market_id", DbType.Decimal, this._Worker_Comp_Market_id);
			
			db.AddInParameter(dbCommand, "Year", DbType.Int32, this._Year);
			
			if (string.IsNullOrEmpty(this._Market))
				db.AddInParameter(dbCommand, "Market", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Market", DbType.String, this._Market);
			
			if (string.IsNullOrEmpty(this._Cause))
				db.AddInParameter(dbCommand, "Cause", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Cause", DbType.String, this._Cause);
			
			db.AddInParameter(dbCommand, "Charge", DbType.Decimal, this._Charge);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the workers_comp_charges_By_Market table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal worker_Comp_Market_id)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("workers_comp_charges_By_MarketDeleteByPK");

			db.AddInParameter(dbCommand, "Worker_Comp_Market_id", DbType.Decimal, worker_Comp_Market_id);

			db.ExecuteNonQuery(dbCommand);
		}
	}
}
