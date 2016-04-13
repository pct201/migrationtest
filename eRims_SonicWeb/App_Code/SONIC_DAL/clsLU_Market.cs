using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for LU_Market table.
	/// </summary>
	public sealed class clsLU_Market
	{

		#region Private variables used to hold the property values

		private decimal? _PK_LU_Market;
		private string _Market;
		private string _Active;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_LU_Market value.
		/// </summary>
		public decimal? PK_LU_Market
		{
			get { return _PK_LU_Market; }
			set { _PK_LU_Market = value; }
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
		/// Gets or sets the Active value.
		/// </summary>
		public string Active
		{
			get { return _Active; }
			set { _Active = value; }
		}


		#endregion

		#region Default Constructors

		/// <summary>
		/// Initializes a new instance of the clsLU_Market class with default value.
		/// </summary>
		public clsLU_Market() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the clsLU_Market class based on Primary Key.
		/// </summary>
		public clsLU_Market(decimal pK_LU_Market) 
		{
			DataTable dtLU_Market = SelectByPK(pK_LU_Market).Tables[0];

			if (dtLU_Market.Rows.Count == 1)
			{
				 SetValue(dtLU_Market.Rows[0]);

			}

		}


		/// <summary>
		/// Initializes a new instance of the clsLU_Market class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drLU_Market) 
		{
				if (drLU_Market["PK_LU_Market"] == DBNull.Value)
					this._PK_LU_Market = null;
				else
					this._PK_LU_Market = (decimal?)drLU_Market["PK_LU_Market"];

				if (drLU_Market["Market"] == DBNull.Value)
					this._Market = null;
				else
					this._Market = (string)drLU_Market["Market"];

				if (drLU_Market["Active"] == DBNull.Value)
					this._Active = null;
				else
					this._Active = (string)drLU_Market["Active"];


		}

		#endregion

		/// <summary>
		/// Inserts a record into the LU_Market table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_MarketInsert");

			
			if (string.IsNullOrEmpty(this._Market))
				db.AddInParameter(dbCommand, "Market", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Market", DbType.String, this._Market);
			
			if (string.IsNullOrEmpty(this._Active))
				db.AddInParameter(dbCommand, "Active", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Active", DbType.String, this._Active);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the LU_Market table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		private DataSet SelectByPK(decimal pK_LU_Market)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_MarketSelectByPK");

			db.AddInParameter(dbCommand, "PK_LU_Market", DbType.Decimal, pK_LU_Market);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the LU_Market table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_MarketSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

        public static DataSet SelectActiveMarkets()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_MarketSelectActive");

            return db.ExecuteDataSet(dbCommand);
        }

		/// <summary>
		/// Updates a record in the LU_Market table.
		/// </summary>
		public decimal Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_MarketUpdate");

			
			db.AddInParameter(dbCommand, "PK_LU_Market", DbType.Decimal, this._PK_LU_Market);
			
			if (string.IsNullOrEmpty(this._Market))
				db.AddInParameter(dbCommand, "Market", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Market", DbType.String, this._Market);
			
			if (string.IsNullOrEmpty(this._Active))
				db.AddInParameter(dbCommand, "Active", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Active", DbType.String, this._Active);

            return (Convert.ToDecimal(db.ExecuteScalar(dbCommand)));
		}

		/// <summary>
		/// Deletes a record from the LU_Market table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_LU_Market)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_MarketDeleteByPK");

			db.AddInParameter(dbCommand, "PK_LU_Market", DbType.Decimal, pK_LU_Market);

			db.ExecuteNonQuery(dbCommand);
		}

        /// <summary>
        /// Select Market By LU_Location Region
        /// </summary>
        /// <param name="Regional"></param>
        /// <returns></returns>
        public static DataSet SelectByRegion(string Regional)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_Market_SelectByRegoin");
            db.AddInParameter(dbCommand, "Regional", DbType.String, Regional);
            return db.ExecuteDataSet(dbCommand);
        }
	}
}
