using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for PA_National_Allocation table.
	/// </summary>
	public sealed class clsPA_National_Allocation
	{

		#region Private variables used to hold the property values

		private decimal? _PK_PA_National_Allocation;
		private int? _Year;
		private int? _Total_Locations;
		private int? _Total_Headcount;
		private decimal? _WC_Premium;
		private decimal? _WC_Rate;
		private decimal? _Texas_WC_Premium;
		private decimal? _Texas_WC_Rate;
		private decimal? _Excess_Umbrella_Premium;
		private decimal? _Excess_Umbrella_Rate;
		private decimal? _EPL_Premium;
		private decimal? _EPL_Rate;
		private decimal? _Garage_Liability_Premium;
		private decimal? _Garage_Liability_Rate;
		private decimal? _Crime_Premium;
		private decimal? _Crime_Rate;
		private decimal? _Cyber_Premium;
		private decimal? _Cyber_Rate;
		private DateTime? _Property_Valuation_Date;
		private decimal? _Property_Premium;
		private decimal? _Property_Rate;
		private decimal? _Earthquake_Premium;
		private decimal? _Earthquake_Rate;
		private decimal? _Pollution_Premium;
		private decimal? _Pollution_Rate;
		private decimal? _Total_Risk_Management_Fee;
		private decimal? _Total_Risk_Management_Rate;
		private decimal? _Total_Actual_Cost;
		private decimal? _Total_Store_Cost;
		private decimal? _Total_Surcharge_Amount;
		private DateTime? _Update_Date;
		private string _Updated_By;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_PA_National_Allocation value.
		/// </summary>
		public decimal? PK_PA_National_Allocation
		{
			get { return _PK_PA_National_Allocation; }
			set { _PK_PA_National_Allocation = value; }
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
		/// Gets or sets the Total_Locations value.
		/// </summary>
		public int? Total_Locations
		{
			get { return _Total_Locations; }
			set { _Total_Locations = value; }
		}

		/// <summary>
		/// Gets or sets the Total_Headcount value.
		/// </summary>
		public int? Total_Headcount
		{
			get { return _Total_Headcount; }
			set { _Total_Headcount = value; }
		}

		/// <summary>
		/// Gets or sets the WC_Premium value.
		/// </summary>
		public decimal? WC_Premium
		{
			get { return _WC_Premium; }
			set { _WC_Premium = value; }
		}

		/// <summary>
		/// Gets or sets the WC_Rate value.
		/// </summary>
		public decimal? WC_Rate
		{
			get { return _WC_Rate; }
			set { _WC_Rate = value; }
		}

		/// <summary>
		/// Gets or sets the Texas_WC_Premium value.
		/// </summary>
		public decimal? Texas_WC_Premium
		{
			get { return _Texas_WC_Premium; }
			set { _Texas_WC_Premium = value; }
		}

		/// <summary>
		/// Gets or sets the Texas_WC_Rate value.
		/// </summary>
		public decimal? Texas_WC_Rate
		{
			get { return _Texas_WC_Rate; }
			set { _Texas_WC_Rate = value; }
		}

		/// <summary>
		/// Gets or sets the Excess_Umbrella_Premium value.
		/// </summary>
		public decimal? Excess_Umbrella_Premium
		{
			get { return _Excess_Umbrella_Premium; }
			set { _Excess_Umbrella_Premium = value; }
		}

		/// <summary>
		/// Gets or sets the Excess_Umbrella_Rate value.
		/// </summary>
		public decimal? Excess_Umbrella_Rate
		{
			get { return _Excess_Umbrella_Rate; }
			set { _Excess_Umbrella_Rate = value; }
		}

		/// <summary>
		/// Gets or sets the EPL_Premium value.
		/// </summary>
		public decimal? EPL_Premium
		{
			get { return _EPL_Premium; }
			set { _EPL_Premium = value; }
		}

		/// <summary>
		/// Gets or sets the EPL_Rate value.
		/// </summary>
		public decimal? EPL_Rate
		{
			get { return _EPL_Rate; }
			set { _EPL_Rate = value; }
		}

		/// <summary>
		/// Gets or sets the Garage_Liability_Premium value.
		/// </summary>
		public decimal? Garage_Liability_Premium
		{
			get { return _Garage_Liability_Premium; }
			set { _Garage_Liability_Premium = value; }
		}

		/// <summary>
		/// Gets or sets the Garage_Liability_Rate value.
		/// </summary>
		public decimal? Garage_Liability_Rate
		{
			get { return _Garage_Liability_Rate; }
			set { _Garage_Liability_Rate = value; }
		}

		/// <summary>
		/// Gets or sets the Crime_Premium value.
		/// </summary>
		public decimal? Crime_Premium
		{
			get { return _Crime_Premium; }
			set { _Crime_Premium = value; }
		}

		/// <summary>
		/// Gets or sets the Crime_Rate value.
		/// </summary>
		public decimal? Crime_Rate
		{
			get { return _Crime_Rate; }
			set { _Crime_Rate = value; }
		}

		/// <summary>
		/// Gets or sets the Cyber_Premium value.
		/// </summary>
		public decimal? Cyber_Premium
		{
			get { return _Cyber_Premium; }
			set { _Cyber_Premium = value; }
		}

		/// <summary>
		/// Gets or sets the Cyber_Rate value.
		/// </summary>
		public decimal? Cyber_Rate
		{
			get { return _Cyber_Rate; }
			set { _Cyber_Rate = value; }
		}

		/// <summary>
		/// Gets or sets the Property_Valuation_Date value.
		/// </summary>
		public DateTime? Property_Valuation_Date
		{
			get { return _Property_Valuation_Date; }
			set { _Property_Valuation_Date = value; }
		}

		/// <summary>
		/// Gets or sets the Property_Premium value.
		/// </summary>
		public decimal? Property_Premium
		{
			get { return _Property_Premium; }
			set { _Property_Premium = value; }
		}

		/// <summary>
		/// Gets or sets the Property_Rate value.
		/// </summary>
		public decimal? Property_Rate
		{
			get { return _Property_Rate; }
			set { _Property_Rate = value; }
		}

		/// <summary>
		/// Gets or sets the Earthquake_Premium value.
		/// </summary>
		public decimal? Earthquake_Premium
		{
			get { return _Earthquake_Premium; }
			set { _Earthquake_Premium = value; }
		}

		/// <summary>
		/// Gets or sets the Earthquake_Rate value.
		/// </summary>
		public decimal? Earthquake_Rate
		{
			get { return _Earthquake_Rate; }
			set { _Earthquake_Rate = value; }
		}

		/// <summary>
		/// Gets or sets the Pollution_Premium value.
		/// </summary>
		public decimal? Pollution_Premium
		{
			get { return _Pollution_Premium; }
			set { _Pollution_Premium = value; }
		}

		/// <summary>
		/// Gets or sets the Pollution_Rate value.
		/// </summary>
		public decimal? Pollution_Rate
		{
			get { return _Pollution_Rate; }
			set { _Pollution_Rate = value; }
		}

		/// <summary>
		/// Gets or sets the Total_Risk_Management_Fee value.
		/// </summary>
		public decimal? Total_Risk_Management_Fee
		{
			get { return _Total_Risk_Management_Fee; }
			set { _Total_Risk_Management_Fee = value; }
		}

		/// <summary>
		/// Gets or sets the Total_Risk_Management_Rate value.
		/// </summary>
		public decimal? Total_Risk_Management_Rate
		{
			get { return _Total_Risk_Management_Rate; }
			set { _Total_Risk_Management_Rate = value; }
		}

		/// <summary>
		/// Gets or sets the Total_Actual_Cost value.
		/// </summary>
		public decimal? Total_Actual_Cost
		{
			get { return _Total_Actual_Cost; }
			set { _Total_Actual_Cost = value; }
		}

		/// <summary>
		/// Gets or sets the Total_Store_Cost value.
		/// </summary>
		public decimal? Total_Store_Cost
		{
			get { return _Total_Store_Cost; }
			set { _Total_Store_Cost = value; }
		}

		/// <summary>
		/// Gets or sets the Total_Surcharge_Amount value.
		/// </summary>
		public decimal? Total_Surcharge_Amount
		{
			get { return _Total_Surcharge_Amount; }
			set { _Total_Surcharge_Amount = value; }
		}

		/// <summary>
		/// Gets or sets the Update_Date value.
		/// </summary>
		public DateTime? Update_Date
		{
			get { return _Update_Date; }
			set { _Update_Date = value; }
		}

		/// <summary>
		/// Gets or sets the Updated_By value.
		/// </summary>
		public string Updated_By
		{
			get { return _Updated_By; }
			set { _Updated_By = value; }
		}


		#endregion

		#region Default Constructors

		/// <summary>
		/// Initializes a new instance of the clsPA_National_Allocation class with default value.
		/// </summary>
		public clsPA_National_Allocation() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the clsPA_National_Allocation class based on Primary Key.
		/// </summary>
		public clsPA_National_Allocation(decimal pK_PA_National_Allocation) 
		{
			DataTable dtPA_National_Allocation = SelectByPK(pK_PA_National_Allocation).Tables[0];

			if (dtPA_National_Allocation.Rows.Count == 1)
			{
				 SetValue(dtPA_National_Allocation.Rows[0]);

			}

		}


		/// <summary>
		/// Initializes a new instance of the clsPA_National_Allocation class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drPA_National_Allocation) 
		{
				if (drPA_National_Allocation["PK_PA_National_Allocation"] == DBNull.Value)
					this._PK_PA_National_Allocation = null;
				else
					this._PK_PA_National_Allocation = (decimal?)drPA_National_Allocation["PK_PA_National_Allocation"];

				if (drPA_National_Allocation["Year"] == DBNull.Value)
					this._Year = null;
				else
					this._Year = (int?)drPA_National_Allocation["Year"];

				if (drPA_National_Allocation["Total_Locations"] == DBNull.Value)
					this._Total_Locations = null;
				else
					this._Total_Locations = (int?)drPA_National_Allocation["Total_Locations"];

				if (drPA_National_Allocation["Total_Headcount"] == DBNull.Value)
					this._Total_Headcount = null;
				else
					this._Total_Headcount = (int?)drPA_National_Allocation["Total_Headcount"];

				if (drPA_National_Allocation["WC_Premium"] == DBNull.Value)
					this._WC_Premium = null;
				else
					this._WC_Premium = (decimal?)drPA_National_Allocation["WC_Premium"];

				if (drPA_National_Allocation["WC_Rate"] == DBNull.Value)
					this._WC_Rate = null;
				else
					this._WC_Rate = (decimal?)drPA_National_Allocation["WC_Rate"];

				if (drPA_National_Allocation["Texas_WC_Premium"] == DBNull.Value)
					this._Texas_WC_Premium = null;
				else
					this._Texas_WC_Premium = (decimal?)drPA_National_Allocation["Texas_WC_Premium"];

				if (drPA_National_Allocation["Texas_WC_Rate"] == DBNull.Value)
					this._Texas_WC_Rate = null;
				else
					this._Texas_WC_Rate = (decimal?)drPA_National_Allocation["Texas_WC_Rate"];

				if (drPA_National_Allocation["Excess_Umbrella_Premium"] == DBNull.Value)
					this._Excess_Umbrella_Premium = null;
				else
					this._Excess_Umbrella_Premium = (decimal?)drPA_National_Allocation["Excess_Umbrella_Premium"];

				if (drPA_National_Allocation["Excess_Umbrella_Rate"] == DBNull.Value)
					this._Excess_Umbrella_Rate = null;
				else
					this._Excess_Umbrella_Rate = (decimal?)drPA_National_Allocation["Excess_Umbrella_Rate"];

				if (drPA_National_Allocation["EPL_Premium"] == DBNull.Value)
					this._EPL_Premium = null;
				else
					this._EPL_Premium = (decimal?)drPA_National_Allocation["EPL_Premium"];

				if (drPA_National_Allocation["EPL_Rate"] == DBNull.Value)
					this._EPL_Rate = null;
				else
					this._EPL_Rate = (decimal?)drPA_National_Allocation["EPL_Rate"];

				if (drPA_National_Allocation["Garage_Liability_Premium"] == DBNull.Value)
					this._Garage_Liability_Premium = null;
				else
					this._Garage_Liability_Premium = (decimal?)drPA_National_Allocation["Garage_Liability_Premium"];

				if (drPA_National_Allocation["Garage_Liability_Rate"] == DBNull.Value)
					this._Garage_Liability_Rate = null;
				else
					this._Garage_Liability_Rate = (decimal?)drPA_National_Allocation["Garage_Liability_Rate"];

				if (drPA_National_Allocation["Crime_Premium"] == DBNull.Value)
					this._Crime_Premium = null;
				else
					this._Crime_Premium = (decimal?)drPA_National_Allocation["Crime_Premium"];

				if (drPA_National_Allocation["Crime_Rate"] == DBNull.Value)
					this._Crime_Rate = null;
				else
					this._Crime_Rate = (decimal?)drPA_National_Allocation["Crime_Rate"];

				if (drPA_National_Allocation["Cyber_Premium"] == DBNull.Value)
					this._Cyber_Premium = null;
				else
					this._Cyber_Premium = (decimal?)drPA_National_Allocation["Cyber_Premium"];

				if (drPA_National_Allocation["Cyber_Rate"] == DBNull.Value)
					this._Cyber_Rate = null;
				else
					this._Cyber_Rate = (decimal?)drPA_National_Allocation["Cyber_Rate"];

				if (drPA_National_Allocation["Property_Valuation_Date"] == DBNull.Value)
					this._Property_Valuation_Date = null;
				else
					this._Property_Valuation_Date = (DateTime?)drPA_National_Allocation["Property_Valuation_Date"];

				if (drPA_National_Allocation["Property_Premium"] == DBNull.Value)
					this._Property_Premium = null;
				else
					this._Property_Premium = (decimal?)drPA_National_Allocation["Property_Premium"];

				if (drPA_National_Allocation["Property_Rate"] == DBNull.Value)
					this._Property_Rate = null;
				else
					this._Property_Rate = (decimal?)drPA_National_Allocation["Property_Rate"];

				if (drPA_National_Allocation["Earthquake_Premium"] == DBNull.Value)
					this._Earthquake_Premium = null;
				else
					this._Earthquake_Premium = (decimal?)drPA_National_Allocation["Earthquake_Premium"];

				if (drPA_National_Allocation["Earthquake_Rate"] == DBNull.Value)
					this._Earthquake_Rate = null;
				else
					this._Earthquake_Rate = (decimal?)drPA_National_Allocation["Earthquake_Rate"];

				if (drPA_National_Allocation["Pollution_Premium"] == DBNull.Value)
					this._Pollution_Premium = null;
				else
					this._Pollution_Premium = (decimal?)drPA_National_Allocation["Pollution_Premium"];

				if (drPA_National_Allocation["Pollution_Rate"] == DBNull.Value)
					this._Pollution_Rate = null;
				else
					this._Pollution_Rate = (decimal?)drPA_National_Allocation["Pollution_Rate"];

				if (drPA_National_Allocation["Total_Risk_Management_Fee"] == DBNull.Value)
					this._Total_Risk_Management_Fee = null;
				else
					this._Total_Risk_Management_Fee = (decimal?)drPA_National_Allocation["Total_Risk_Management_Fee"];

				if (drPA_National_Allocation["Total_Risk_Management_Rate"] == DBNull.Value)
					this._Total_Risk_Management_Rate = null;
				else
					this._Total_Risk_Management_Rate = (decimal?)drPA_National_Allocation["Total_Risk_Management_Rate"];

				if (drPA_National_Allocation["Total_Actual_Cost"] == DBNull.Value)
					this._Total_Actual_Cost = null;
				else
					this._Total_Actual_Cost = (decimal?)drPA_National_Allocation["Total_Actual_Cost"];

				if (drPA_National_Allocation["Total_Store_Cost"] == DBNull.Value)
					this._Total_Store_Cost = null;
				else
					this._Total_Store_Cost = (decimal?)drPA_National_Allocation["Total_Store_Cost"];

				if (drPA_National_Allocation["Total_Surcharge_Amount"] == DBNull.Value)
					this._Total_Surcharge_Amount = null;
				else
					this._Total_Surcharge_Amount = (decimal?)drPA_National_Allocation["Total_Surcharge_Amount"];

				if (drPA_National_Allocation["Update_Date"] == DBNull.Value)
					this._Update_Date = null;
				else
					this._Update_Date = (DateTime?)drPA_National_Allocation["Update_Date"];

				if (drPA_National_Allocation["Updated_By"] == DBNull.Value)
					this._Updated_By = null;
				else
					this._Updated_By = (string)drPA_National_Allocation["Updated_By"];


		}

		#endregion

		/// <summary>
		/// Inserts a record into the PA_National_Allocation table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("PA_National_AllocationInsert");

			
			db.AddInParameter(dbCommand, "Year", DbType.Int32, this._Year);
			
			db.AddInParameter(dbCommand, "Total_Locations", DbType.Int32, this._Total_Locations);
			
			db.AddInParameter(dbCommand, "Total_Headcount", DbType.Int32, this._Total_Headcount);
			
			db.AddInParameter(dbCommand, "WC_Premium", DbType.Decimal, this._WC_Premium);
			
			db.AddInParameter(dbCommand, "WC_Rate", DbType.Decimal, this._WC_Rate);
			
			db.AddInParameter(dbCommand, "Texas_WC_Premium", DbType.Decimal, this._Texas_WC_Premium);
			
			db.AddInParameter(dbCommand, "Texas_WC_Rate", DbType.Decimal, this._Texas_WC_Rate);
			
			db.AddInParameter(dbCommand, "Excess_Umbrella_Premium", DbType.Decimal, this._Excess_Umbrella_Premium);
			
			db.AddInParameter(dbCommand, "Excess_Umbrella_Rate", DbType.Decimal, this._Excess_Umbrella_Rate);
			
			db.AddInParameter(dbCommand, "EPL_Premium", DbType.Decimal, this._EPL_Premium);
			
			db.AddInParameter(dbCommand, "EPL_Rate", DbType.Decimal, this._EPL_Rate);
			
			db.AddInParameter(dbCommand, "Garage_Liability_Premium", DbType.Decimal, this._Garage_Liability_Premium);
			
			db.AddInParameter(dbCommand, "Garage_Liability_Rate", DbType.Decimal, this._Garage_Liability_Rate);
			
			db.AddInParameter(dbCommand, "Crime_Premium", DbType.Decimal, this._Crime_Premium);
			
			db.AddInParameter(dbCommand, "Crime_Rate", DbType.Decimal, this._Crime_Rate);
			
			db.AddInParameter(dbCommand, "Cyber_Premium", DbType.Decimal, this._Cyber_Premium);
			
			db.AddInParameter(dbCommand, "Cyber_Rate", DbType.Decimal, this._Cyber_Rate);
			
			db.AddInParameter(dbCommand, "Property_Valuation_Date", DbType.DateTime, this._Property_Valuation_Date);
			
			db.AddInParameter(dbCommand, "Property_Premium", DbType.Decimal, this._Property_Premium);
			
			db.AddInParameter(dbCommand, "Property_Rate", DbType.Decimal, this._Property_Rate);
			
			db.AddInParameter(dbCommand, "Earthquake_Premium", DbType.Decimal, this._Earthquake_Premium);
			
			db.AddInParameter(dbCommand, "Earthquake_Rate", DbType.Decimal, this._Earthquake_Rate);
			
			db.AddInParameter(dbCommand, "Pollution_Premium", DbType.Decimal, this._Pollution_Premium);
			
			db.AddInParameter(dbCommand, "Pollution_Rate", DbType.Decimal, this._Pollution_Rate);
			
			db.AddInParameter(dbCommand, "Total_Risk_Management_Fee", DbType.Decimal, this._Total_Risk_Management_Fee);
			
			db.AddInParameter(dbCommand, "Total_Risk_Management_Rate", DbType.Decimal, this._Total_Risk_Management_Rate);
			
			db.AddInParameter(dbCommand, "Total_Actual_Cost", DbType.Decimal, this._Total_Actual_Cost);
			
			db.AddInParameter(dbCommand, "Total_Store_Cost", DbType.Decimal, this._Total_Store_Cost);
			
			db.AddInParameter(dbCommand, "Total_Surcharge_Amount", DbType.Decimal, this._Total_Surcharge_Amount);
			
			db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);
			
			if (string.IsNullOrEmpty(this._Updated_By))
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the PA_National_Allocation table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		private DataSet SelectByPK(decimal pK_PA_National_Allocation)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("PA_National_AllocationSelectByPK");

			db.AddInParameter(dbCommand, "PK_PA_National_Allocation", DbType.Decimal, pK_PA_National_Allocation);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the PA_National_Allocation table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("PA_National_AllocationSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the PA_National_Allocation table.
		/// </summary>
		public void Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("PA_National_AllocationUpdate");

			
			db.AddInParameter(dbCommand, "PK_PA_National_Allocation", DbType.Decimal, this._PK_PA_National_Allocation);
			
			db.AddInParameter(dbCommand, "Year", DbType.Int32, this._Year);
			
			db.AddInParameter(dbCommand, "Total_Locations", DbType.Int32, this._Total_Locations);
			
			db.AddInParameter(dbCommand, "Total_Headcount", DbType.Int32, this._Total_Headcount);
			
			db.AddInParameter(dbCommand, "WC_Premium", DbType.Decimal, this._WC_Premium);
			
			db.AddInParameter(dbCommand, "WC_Rate", DbType.Decimal, this._WC_Rate);
			
			db.AddInParameter(dbCommand, "Texas_WC_Premium", DbType.Decimal, this._Texas_WC_Premium);
			
			db.AddInParameter(dbCommand, "Texas_WC_Rate", DbType.Decimal, this._Texas_WC_Rate);
			
			db.AddInParameter(dbCommand, "Excess_Umbrella_Premium", DbType.Decimal, this._Excess_Umbrella_Premium);
			
			db.AddInParameter(dbCommand, "Excess_Umbrella_Rate", DbType.Decimal, this._Excess_Umbrella_Rate);
			
			db.AddInParameter(dbCommand, "EPL_Premium", DbType.Decimal, this._EPL_Premium);
			
			db.AddInParameter(dbCommand, "EPL_Rate", DbType.Decimal, this._EPL_Rate);
			
			db.AddInParameter(dbCommand, "Garage_Liability_Premium", DbType.Decimal, this._Garage_Liability_Premium);
			
			db.AddInParameter(dbCommand, "Garage_Liability_Rate", DbType.Decimal, this._Garage_Liability_Rate);
			
			db.AddInParameter(dbCommand, "Crime_Premium", DbType.Decimal, this._Crime_Premium);
			
			db.AddInParameter(dbCommand, "Crime_Rate", DbType.Decimal, this._Crime_Rate);
			
			db.AddInParameter(dbCommand, "Cyber_Premium", DbType.Decimal, this._Cyber_Premium);
			
			db.AddInParameter(dbCommand, "Cyber_Rate", DbType.Decimal, this._Cyber_Rate);
			
			db.AddInParameter(dbCommand, "Property_Valuation_Date", DbType.DateTime, this._Property_Valuation_Date);
			
			db.AddInParameter(dbCommand, "Property_Premium", DbType.Decimal, this._Property_Premium);
			
			db.AddInParameter(dbCommand, "Property_Rate", DbType.Decimal, this._Property_Rate);
			
			db.AddInParameter(dbCommand, "Earthquake_Premium", DbType.Decimal, this._Earthquake_Premium);
			
			db.AddInParameter(dbCommand, "Earthquake_Rate", DbType.Decimal, this._Earthquake_Rate);
			
			db.AddInParameter(dbCommand, "Pollution_Premium", DbType.Decimal, this._Pollution_Premium);
			
			db.AddInParameter(dbCommand, "Pollution_Rate", DbType.Decimal, this._Pollution_Rate);
			
			db.AddInParameter(dbCommand, "Total_Risk_Management_Fee", DbType.Decimal, this._Total_Risk_Management_Fee);
			
			db.AddInParameter(dbCommand, "Total_Risk_Management_Rate", DbType.Decimal, this._Total_Risk_Management_Rate);
			
			db.AddInParameter(dbCommand, "Total_Actual_Cost", DbType.Decimal, this._Total_Actual_Cost);
			
			db.AddInParameter(dbCommand, "Total_Store_Cost", DbType.Decimal, this._Total_Store_Cost);
			
			db.AddInParameter(dbCommand, "Total_Surcharge_Amount", DbType.Decimal, this._Total_Surcharge_Amount);
			
			db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);
			
			if (string.IsNullOrEmpty(this._Updated_By))
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the PA_National_Allocation table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_PA_National_Allocation)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("PA_National_AllocationDeleteByPK");

			db.AddInParameter(dbCommand, "PK_PA_National_Allocation", DbType.Decimal, pK_PA_National_Allocation);

			db.ExecuteNonQuery(dbCommand);
		}

        /// <summary>
        /// Selects all records from the PA_Location_Premium_Allocation table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectByFieldsCriteria(int Year, DateTime PropertyDate, decimal? WCPremium, decimal? Texas_WC_Premium,
            decimal? Excess_Umbrella_Premium, decimal? EPL_Premium, decimal? Garage_Liability_Premium, decimal? Crime_Premium, decimal? Cyber_Premium,            
            decimal? Pollution_Premium, decimal? Property_Premium, decimal? Earthquake_Premium,
            decimal? Total_Risk_Management_Fee, decimal? Total_Risk_Management_Rate, decimal? Total_Store_Cost, decimal? Total_Surcharge_Amount,
            DateTime UpdatedDate, string UpdatedBy, decimal PK_PA_National_Allocation)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("PA_NationalLocationByYear");
            db.AddInParameter(dbCommand, "Year", DbType.Int32, Year);
            db.AddInParameter(dbCommand, "PropertyDate", DbType.DateTime, PropertyDate);
            db.AddInParameter(dbCommand, "WorkerCompensationPremium", DbType.Decimal, WCPremium);
            db.AddInParameter(dbCommand, "TexasNonSubscriptionPremium", DbType.Decimal, Texas_WC_Premium);
            db.AddInParameter(dbCommand, "EPLIPremium", DbType.Decimal, EPL_Premium);
            db.AddInParameter(dbCommand, "Garage_Liability_Premium", DbType.Decimal, Garage_Liability_Premium);
            db.AddInParameter(dbCommand, "Crime_Premium", DbType.Decimal, Crime_Premium);
            db.AddInParameter(dbCommand, "CyberPremium", DbType.Decimal, Cyber_Premium);
            db.AddInParameter(dbCommand, "Pollution_Premium", DbType.Decimal, Pollution_Premium);
            db.AddInParameter(dbCommand, "ExcessUmbrellaPremium", DbType.Decimal, Excess_Umbrella_Premium);
            db.AddInParameter(dbCommand, "PropertyPremium", DbType.Decimal, Property_Premium);
            db.AddInParameter(dbCommand, "EarthquakePremium", DbType.Decimal, Earthquake_Premium);
            db.AddInParameter(dbCommand, "TotalRiskManagementFee", DbType.Decimal, Total_Risk_Management_Fee);
            db.AddInParameter(dbCommand, "TotalRiskManagementRate", DbType.Decimal, Total_Risk_Management_Rate);
            //db.AddInParameter(dbCommand, "TotalActualCost", DbType.Decimal, Total_Actual_Cost);
            db.AddInParameter(dbCommand, "TotalStoreCost", DbType.Decimal, Total_Store_Cost);
            db.AddInParameter(dbCommand, "TotalSurchargeAmount", DbType.Decimal, Total_Surcharge_Amount);

            db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, UpdatedDate);

            if (string.IsNullOrEmpty(UpdatedBy))
                db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Updated_By", DbType.String, UpdatedBy);
            db.AddInParameter(dbCommand, "PK_PA_National_Allocation", DbType.Decimal, PK_PA_National_Allocation);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the PA_Location_Premium_Allocation table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectByPropertyValuationYear(int PropertyYear, int Year)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("PA_NationalLocationByPropertyValuationYear");
            db.AddInParameter(dbCommand, "PropertyYear", DbType.Decimal, PropertyYear);
            db.AddInParameter(dbCommand, "Year", DbType.Decimal, Year);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the PA_Screen_Fields table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet PA_National_AllocationSelectByYear(int? Year, string strOrderBy, string strOrder, int intPageNo, int intPageSize)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("PA_National_AllocationSelectByYear");
            db.AddInParameter(dbCommand, "@Year", DbType.Int32, Year);
            db.AddInParameter(dbCommand, "@strOrderBy", DbType.String, strOrderBy);
            db.AddInParameter(dbCommand, "@strOrder", DbType.String, strOrder);
            db.AddInParameter(dbCommand, "@intPageNo", DbType.Decimal, intPageNo);
            db.AddInParameter(dbCommand, "@intPageSize", DbType.Decimal, intPageSize);
            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the PA_Screen_Fields table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static bool CheckAllocationYearExists(decimal PK_PA_Screen_Fields, int? Year)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("PA_National_AllocationYear_Check");

            db.AddInParameter(dbCommand, "PK_PA_National_Allocation", DbType.Decimal, PK_PA_Screen_Fields);
            db.AddInParameter(dbCommand, "Year", DbType.Int32, Year);

            return Convert.ToBoolean(db.ExecuteScalar(dbCommand));
        }

        public static DataSet SelectAllRiskManagementGrid(decimal fK_PA_National_Allocation)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("PA_National_Allocation_Service_GridByFk");

            db.AddInParameter(dbCommand, "FK_PA_National_Allocation", DbType.Decimal, fK_PA_National_Allocation);

            return db.ExecuteDataSet(dbCommand);
        }

        public DataSet UpdateTotalRiskValues(int? Year, int? Location, decimal? PK_PA_National_Allocation)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("PA_National_AllocationRiskValues");
            db.AddInParameter(dbCommand, "Year", DbType.Int32, Year);
            db.AddInParameter(dbCommand, "PK_PA_National_Allocation", DbType.Decimal, PK_PA_National_Allocation);
            db.AddInParameter(dbCommand, "TotalLocation", DbType.Int32, Location);

            return db.ExecuteDataSet(dbCommand);
        }
    }
}
