using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for WC_Allocation_Charges_ByMarket table.
	/// </summary>
	public sealed class WC_Allocation_Charges_ByMarket
	{

		#region Private variables used to hold the property values

		private decimal? _PK_WC_Allocation_Charges_ByMarket;
		private decimal? _FK_WC_FR_ID;
		private string _Charge_Type;
		private DateTime? _ChargeDate;
		private decimal? _Charge;
		private string _Change_Explanation;
		private string _Change_login;
		private bool _Changed;
		private string _Updated_By;
		private DateTime? _Update_Date;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_WC_Allocation_Charges_ByMarket value.
		/// </summary>
		public decimal? PK_WC_Allocation_Charges_ByMarket
		{
			get { return _PK_WC_Allocation_Charges_ByMarket; }
			set { _PK_WC_Allocation_Charges_ByMarket = value; }
		}

		/// <summary>
		/// Gets or sets the FK_WC_FR_ID value.
		/// </summary>
		public decimal? FK_WC_FR_ID
		{
			get { return _FK_WC_FR_ID; }
			set { _FK_WC_FR_ID = value; }
		}

		/// <summary>
		/// Gets or sets the Charge_Type value.
		/// </summary>
		public string Charge_Type
		{
			get { return _Charge_Type; }
			set { _Charge_Type = value; }
		}

		/// <summary>
		/// Gets or sets the ChargeDate value.
		/// </summary>
		public DateTime? ChargeDate
		{
			get { return _ChargeDate; }
			set { _ChargeDate = value; }
		}

		/// <summary>
		/// Gets or sets the Charge value.
		/// </summary>
		public decimal? Charge
		{
			get { return _Charge; }
			set { _Charge = value; }
		}

		/// <summary>
		/// Gets or sets the Change_Explanation value.
		/// </summary>
		public string Change_Explanation
		{
			get { return _Change_Explanation; }
			set { _Change_Explanation = value; }
		}

		/// <summary>
		/// Gets or sets the Change_login value.
		/// </summary>
		public string Change_login
		{
			get { return _Change_login; }
			set { _Change_login = value; }
		}

		/// <summary>
		/// Gets or sets the Changed value.
		/// </summary>
		public bool Changed
		{
			get { return _Changed; }
			set { _Changed = value; }
		}

		/// <summary>
		/// Gets or sets the Updated_By value.
		/// </summary>
		public string Updated_By
		{
			get { return _Updated_By; }
			set { _Updated_By = value; }
		}

		/// <summary>
		/// Gets or sets the Update_Date value.
		/// </summary>
		public DateTime? Update_Date
		{
			get { return _Update_Date; }
			set { _Update_Date = value; }
		}


		#endregion

		#region Default Constructors

		/// <summary>
		/// Initializes a new instance of the clsWC_Allocation_Charges_ByMarket class with default value.
		/// </summary>
		public WC_Allocation_Charges_ByMarket() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the clsWC_Allocation_Charges_ByMarket class based on Primary Key.
		/// </summary>
        public WC_Allocation_Charges_ByMarket(decimal pK_WC_Allocation_Charges_ByMarket) 
		{
			DataTable dtWC_Allocation_Charges_ByMarket = SelectByPK(pK_WC_Allocation_Charges_ByMarket).Tables[0];

			if (dtWC_Allocation_Charges_ByMarket.Rows.Count == 1)
			{
				 SetValue(dtWC_Allocation_Charges_ByMarket.Rows[0]);

			}

		}


		/// <summary>
		/// Initializes a new instance of the clsWC_Allocation_Charges_ByMarket class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drWC_Allocation_Charges_ByMarket) 
		{
				if (drWC_Allocation_Charges_ByMarket["PK_WC_Allocation_Charges_ByMarket"] == DBNull.Value)
					this._PK_WC_Allocation_Charges_ByMarket = null;
				else
					this._PK_WC_Allocation_Charges_ByMarket = (decimal?)drWC_Allocation_Charges_ByMarket["PK_WC_Allocation_Charges_ByMarket"];

				if (drWC_Allocation_Charges_ByMarket["FK_WC_FR_ID"] == DBNull.Value)
					this._FK_WC_FR_ID = null;
				else
					this._FK_WC_FR_ID = (decimal?)drWC_Allocation_Charges_ByMarket["FK_WC_FR_ID"];

				if (drWC_Allocation_Charges_ByMarket["Charge_Type"] == DBNull.Value)
					this._Charge_Type = null;
				else
					this._Charge_Type = (string)drWC_Allocation_Charges_ByMarket["Charge_Type"];

				if (drWC_Allocation_Charges_ByMarket["ChargeDate"] == DBNull.Value)
					this._ChargeDate = null;
				else
					this._ChargeDate = (DateTime?)drWC_Allocation_Charges_ByMarket["ChargeDate"];

				if (drWC_Allocation_Charges_ByMarket["Charge"] == DBNull.Value)
					this._Charge = null;
				else
					this._Charge = (decimal?)drWC_Allocation_Charges_ByMarket["Charge"];

				if (drWC_Allocation_Charges_ByMarket["Change_Explanation"] == DBNull.Value)
					this._Change_Explanation = null;
				else
					this._Change_Explanation = (string)drWC_Allocation_Charges_ByMarket["Change_Explanation"];

				if (drWC_Allocation_Charges_ByMarket["Change_login"] == DBNull.Value)
					this._Change_login = null;
				else
					this._Change_login = (string)drWC_Allocation_Charges_ByMarket["Change_login"];

				this._Changed = (bool)drWC_Allocation_Charges_ByMarket["Changed"];

				if (drWC_Allocation_Charges_ByMarket["Updated_By"] == DBNull.Value)
					this._Updated_By = null;
				else
					this._Updated_By = (string)drWC_Allocation_Charges_ByMarket["Updated_By"];

				if (drWC_Allocation_Charges_ByMarket["Update_Date"] == DBNull.Value)
					this._Update_Date = null;
				else
					this._Update_Date = (DateTime?)drWC_Allocation_Charges_ByMarket["Update_Date"];


		}

		#endregion

		/// <summary>
		/// Inserts a record into the WC_Allocation_Charges_ByMarket table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("WC_Allocation_Charges_ByMarketInsert");

			
			db.AddInParameter(dbCommand, "FK_WC_FR_ID", DbType.Decimal, this._FK_WC_FR_ID);
			
			if (string.IsNullOrEmpty(this._Charge_Type))
				db.AddInParameter(dbCommand, "Charge_Type", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Charge_Type", DbType.String, this._Charge_Type);
			
			db.AddInParameter(dbCommand, "ChargeDate", DbType.DateTime, this._ChargeDate);
			
			db.AddInParameter(dbCommand, "Charge", DbType.Currency, this._Charge);
			
			if (string.IsNullOrEmpty(this._Change_Explanation))
				db.AddInParameter(dbCommand, "Change_Explanation", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Change_Explanation", DbType.String, this._Change_Explanation);
			
			if (string.IsNullOrEmpty(this._Change_login))
				db.AddInParameter(dbCommand, "Change_login", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Change_login", DbType.String, this._Change_login);
			
			db.AddInParameter(dbCommand, "Changed", DbType.Boolean, this._Changed);
			
			if (string.IsNullOrEmpty(this._Updated_By))
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);
			
			db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the WC_Allocation_Charges_ByMarket table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		private DataSet SelectByPK(decimal pK_WC_Allocation_Charges_ByMarket)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("WC_Allocation_Charges_ByMarketSelectByPK");

			db.AddInParameter(dbCommand, "PK_WC_Allocation_Charges_ByMarket", DbType.Decimal, pK_WC_Allocation_Charges_ByMarket);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the WC_Allocation_Charges_ByMarket table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("WC_Allocation_Charges_ByMarketSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the WC_Allocation_Charges_ByMarket table.
		/// </summary>
		public void Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("WC_Allocation_Charges_ByMarketUpdate");

			
			db.AddInParameter(dbCommand, "PK_WC_Allocation_Charges_ByMarket", DbType.Decimal, this._PK_WC_Allocation_Charges_ByMarket);
			
			db.AddInParameter(dbCommand, "FK_WC_FR_ID", DbType.Decimal, this._FK_WC_FR_ID);
			
			if (string.IsNullOrEmpty(this._Charge_Type))
				db.AddInParameter(dbCommand, "Charge_Type", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Charge_Type", DbType.String, this._Charge_Type);
			
			db.AddInParameter(dbCommand, "ChargeDate", DbType.DateTime, this._ChargeDate);
			
			db.AddInParameter(dbCommand, "Charge", DbType.Currency, this._Charge);
			
			if (string.IsNullOrEmpty(this._Change_Explanation))
				db.AddInParameter(dbCommand, "Change_Explanation", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Change_Explanation", DbType.String, this._Change_Explanation);
			
			if (string.IsNullOrEmpty(this._Change_login))
				db.AddInParameter(dbCommand, "Change_login", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Change_login", DbType.String, this._Change_login);
			
			db.AddInParameter(dbCommand, "Changed", DbType.Boolean, this._Changed);
			
			if (string.IsNullOrEmpty(this._Updated_By))
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);
			
			db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the WC_Allocation_Charges_ByMarket table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_WC_Allocation_Charges_ByMarket)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("WC_Allocation_Charges_ByMarketDeleteByPK");

			db.AddInParameter(dbCommand, "PK_WC_Allocation_Charges_ByMarket", DbType.Decimal, pK_WC_Allocation_Charges_ByMarket);

			db.ExecuteNonQuery(dbCommand);
		}

        /// <summary>
        /// Search Wc_allocation using First Report Number
        /// </summary>
        /// <param name="First_Report_Number"></param>
        public static DataSet SearchByFR_Number(decimal FK_WC_FR_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("SearchWC_allocation_charges_By_Market");

            db.AddInParameter(dbCommand, "FK_WC_FR_ID", DbType.Decimal, FK_WC_FR_ID);

            return db.ExecuteDataSet(dbCommand);

        }
	}
}
