using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for Property_COPE table.
	/// </summary>
	public sealed class Property_COPE
	{
        #region Fields
        private decimal _PK_Property_Cope_ID;
        private decimal _FK_LU_Location_ID;
        private string _Status;
        private DateTime _Status_As_Of_Date;
        private string _Disposal_Type;
        private Nullable<bool> _Union_shop;
        private string _Property_Boundary_Dimemsions;
        private string _Address_1;
        private string _Address_2;
        private string _City;
        private string _State;
        private string _Zip;
        private string _Telephone;
        private string _Web_site;
        private DateTime _Valuation_Date;
        private Nullable<decimal> _Business_Interruption_Salaries;
        private Nullable<decimal> _Business_Interruption_Benefits;
        private Nullable<decimal> _Business_interruption_fixed_costs;
        private Nullable<decimal> _Business_interruption_net_profit;
        private decimal _Updated_By;
        private DateTime _Updated_Date;
        #endregion


        #region Properties


        /// <summary> 
        /// Gets or sets the PK_Property_Cope_ID value.
        /// </summary>
        public decimal PK_Property_Cope_ID
        {
            get { return _PK_Property_Cope_ID; }
            set { _PK_Property_Cope_ID = value; }
        }


        /// <summary> 
        /// Gets or sets the FK_LU_Location_ID value.
        /// </summary>
        public decimal FK_LU_Location_ID
        {
            get { return _FK_LU_Location_ID; }
            set { _FK_LU_Location_ID = value; }
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
        /// Gets or sets the Status_As_Of_Date value.
        /// </summary>
        public DateTime Status_As_Of_Date
        {
            get { return _Status_As_Of_Date; }
            set { _Status_As_Of_Date = value; }
        }


        /// <summary> 
        /// Gets or sets the Disposal_Type value.
        /// </summary>
        public string Disposal_Type
        {
            get { return _Disposal_Type; }
            set { _Disposal_Type = value; }
        }


        /// <summary> 
        /// Gets or sets the Union_shop value.
        /// </summary>
        public Nullable<bool> Union_shop
        {
            get { return _Union_shop; }
            set { _Union_shop = value; }
        }


        /// <summary> 
        /// Gets or sets the Property_Boundary_Dimemsions value.
        /// </summary>
        public string Property_Boundary_Dimemsions
        {
            get { return _Property_Boundary_Dimemsions; }
            set { _Property_Boundary_Dimemsions = value; }
        }


        /// <summary> 
        /// Gets or sets the Address_1 value.
        /// </summary>
        public string Address_1
        {
            get { return _Address_1; }
            set { _Address_1 = value; }
        }


        /// <summary> 
        /// Gets or sets the Address_2 value.
        /// </summary>
        public string Address_2
        {
            get { return _Address_2; }
            set { _Address_2 = value; }
        }


        /// <summary> 
        /// Gets or sets the City value.
        /// </summary>
        public string City
        {
            get { return _City; }
            set { _City = value; }
        }


        /// <summary> 
        /// Gets or sets the State value.
        /// </summary>
        public string State
        {
            get { return _State; }
            set { _State = value; }
        }


        /// <summary> 
        /// Gets or sets the Zip value.
        /// </summary>
        public string Zip
        {
            get { return _Zip; }
            set { _Zip = value; }
        }


        /// <summary> 
        /// Gets or sets the Telephone value.
        /// </summary>
        public string Telephone
        {
            get { return _Telephone; }
            set { _Telephone = value; }
        }


        /// <summary> 
        /// Gets or sets the Web_site value.
        /// </summary>
        public string Web_site
        {
            get { return _Web_site; }
            set { _Web_site = value; }
        }


        /// <summary> 
        /// Gets or sets the Valuation_Date value.
        /// </summary>
        public DateTime Valuation_Date
        {
            get { return _Valuation_Date; }
            set { _Valuation_Date = value; }
        }


        /// <summary> 
        /// Gets or sets the Business_Interruption_Salaries value.
        /// </summary>
        public Nullable<decimal> Business_Interruption_Salaries
        {
            get { return _Business_Interruption_Salaries; }
            set { _Business_Interruption_Salaries = value; }
        }


        /// <summary> 
        /// Gets or sets the Business_Interruption_Benefits value.
        /// </summary>
        public Nullable<decimal> Business_Interruption_Benefits
        {
            get { return _Business_Interruption_Benefits; }
            set { _Business_Interruption_Benefits = value; }
        }


        /// <summary> 
        /// Gets or sets the Business_interruption_fixed_costs value.
        /// </summary>
        public Nullable<decimal> Business_interruption_fixed_costs
        {
            get { return _Business_interruption_fixed_costs; }
            set { _Business_interruption_fixed_costs = value; }
        }


        /// <summary> 
        /// Gets or sets the Business_interruption_net_profit value.
        /// </summary>
        public Nullable<decimal> Business_interruption_net_profit
        {
            get { return _Business_interruption_net_profit; }
            set { _Business_interruption_net_profit = value; }
        }

        /// <summary> 
        /// Gets or sets the Updated_By value.
        /// </summary>
        public decimal Updated_By
        {
            get { return _Updated_By; }
            set { _Updated_By = value; }
        }


        /// <summary> 
        /// Gets or sets the Updated_Date value.
        /// </summary>
        public DateTime Updated_Date
        {
            get { return _Updated_Date; }
            set { _Updated_Date = value; }
        }

        #endregion


        #region Constructors

        /// <summary> 
        /// Initializes a new instance of the Property_COPE class. with the default value.
        /// </summary>
        public Property_COPE()
        {

            this._PK_Property_Cope_ID = -1;
            this._FK_LU_Location_ID = -1;
            this._Status = "";
            this._Status_As_Of_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            this._Disposal_Type = "";
            this._Union_shop = null;
            this._Property_Boundary_Dimemsions = "";
            this._Address_1 = "";
            this._Address_2 = "";
            this._City = "";
            this._State = "";
            this._Zip = "";
            this._Telephone = "";
            this._Web_site = "";
            this._Valuation_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            this._Business_Interruption_Salaries = null;
            this._Business_Interruption_Benefits = null;
            this._Business_interruption_fixed_costs = null;
            this._Business_interruption_net_profit = null;
            this._Updated_By = -1;
            this._Updated_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;

        }



        /// <summary> 
        /// Initializes a new instance of the Property_COPE class for passed PrimaryKey with the values set from Database.
        /// </summary>
        public Property_COPE(decimal PK)
        {

            DataTable dtProperty_COPE = SelectByPK(PK).Tables[0];

            if (dtProperty_COPE.Rows.Count > 0)
            {

                DataRow drProperty_COPE = dtProperty_COPE.Rows[0];

                this._PK_Property_Cope_ID = drProperty_COPE["PK_Property_Cope_ID"] != DBNull.Value ? Convert.ToDecimal(drProperty_COPE["PK_Property_Cope_ID"]) : 0;
                this._FK_LU_Location_ID = drProperty_COPE["FK_LU_Location_ID"] != DBNull.Value ? Convert.ToDecimal(drProperty_COPE["FK_LU_Location_ID"]) : 0;
                this._Status = Convert.ToString(drProperty_COPE["Status"]);
                this._Status_As_Of_Date = drProperty_COPE["Status_As_Of_Date"] != DBNull.Value ? Convert.ToDateTime(drProperty_COPE["Status_As_Of_Date"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Disposal_Type = Convert.ToString(drProperty_COPE["Disposal_Type"]);
                if (drProperty_COPE["Union_shop"] != DBNull.Value) 
                    this._Union_shop = Convert.ToBoolean(drProperty_COPE["Union_shop"]);
                this._Property_Boundary_Dimemsions = Convert.ToString(drProperty_COPE["Property_Boundary_Dimemsions"]);
                this._Address_1 = Convert.ToString(drProperty_COPE["Address_1"]);
                this._Address_2 = Convert.ToString(drProperty_COPE["Address_2"]);
                this._City = Convert.ToString(drProperty_COPE["City"]);
                this._State = Convert.ToString(drProperty_COPE["State"]);
                this._Zip = Convert.ToString(drProperty_COPE["Zip"]);
                this._Telephone = Convert.ToString(drProperty_COPE["Telephone"]);
                this._Web_site = Convert.ToString(drProperty_COPE["Web_site"]);
                this._Valuation_Date = drProperty_COPE["Valuation_Date"] != DBNull.Value ? Convert.ToDateTime(drProperty_COPE["Valuation_Date"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                if (drProperty_COPE["Business_Interruption_Salaries"] != DBNull.Value) this._Business_Interruption_Salaries = Convert.ToDecimal(drProperty_COPE["Business_Interruption_Salaries"]);
                if (drProperty_COPE["Business_Interruption_Benefits"] != DBNull.Value) this._Business_Interruption_Benefits = Convert.ToDecimal(drProperty_COPE["Business_Interruption_Benefits"]);
                if (drProperty_COPE["Business_interruption_fixed_costs"] != DBNull.Value) this._Business_interruption_fixed_costs = Convert.ToDecimal(drProperty_COPE["Business_interruption_fixed_costs"]);
                if (drProperty_COPE["Business_interruption_net_profit"] != DBNull.Value) this._Business_interruption_net_profit = Convert.ToDecimal(drProperty_COPE["Business_interruption_net_profit"]);
                this._Updated_By = drProperty_COPE["Updated_By"] != DBNull.Value ? Convert.ToDecimal(drProperty_COPE["Updated_By"]) : 0;
                this._Updated_Date = drProperty_COPE["Updated_Date"] != DBNull.Value ? Convert.ToDateTime(drProperty_COPE["Updated_Date"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            }
            else
            {

                this._PK_Property_Cope_ID = -1;
                this._FK_LU_Location_ID = -1;
                this._Status = "";
                this._Status_As_Of_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Disposal_Type = "";
                this._Union_shop = null;
                this._Property_Boundary_Dimemsions = "";
                this._Address_1 = "";
                this._Address_2 = "";
                this._City = "";
                this._State = "";
                this._Zip = "";
                this._Telephone = "";
                this._Web_site = "";
                this._Valuation_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Business_Interruption_Salaries = null;
                this._Business_Interruption_Benefits = null;
                this._Business_interruption_fixed_costs = null;
                this._Business_interruption_net_profit = null;
                this._Updated_By = -1;
                this._Updated_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            }

        }



        #endregion

        #region "Methods"

        /// <summary>
		/// Inserts a record into the Property_COPE table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Property_COPEInsert");

			db.AddInParameter(dbCommand, "FK_LU_Location_ID", DbType.Decimal, this._FK_LU_Location_ID);
			db.AddInParameter(dbCommand, "Status", DbType.String, this._Status);
			db.AddInParameter(dbCommand, "Status_As_Of_Date", DbType.DateTime, this._Status_As_Of_Date);
			db.AddInParameter(dbCommand, "Disposal_Type", DbType.String, this._Disposal_Type);
            if (this._Union_shop != null)
                db.AddInParameter(dbCommand, "Union_shop", DbType.Boolean, this._Union_shop);
            else
                db.AddInParameter(dbCommand, "Union_shop", DbType.Boolean, DBNull.Value);

			db.AddInParameter(dbCommand, "Property_Boundary_Dimemsions", DbType.String, this._Property_Boundary_Dimemsions);
			db.AddInParameter(dbCommand, "Address_1", DbType.String, this._Address_1);
			db.AddInParameter(dbCommand, "Address_2", DbType.String, this._Address_2);
			db.AddInParameter(dbCommand, "City", DbType.String, this._City);
			db.AddInParameter(dbCommand, "State", DbType.String, this._State);
			db.AddInParameter(dbCommand, "Zip", DbType.String, this._Zip);
			db.AddInParameter(dbCommand, "Telephone", DbType.String, this._Telephone);
			db.AddInParameter(dbCommand, "Web_site", DbType.String, this._Web_site);
			db.AddInParameter(dbCommand, "Valuation_Date", DbType.DateTime, this._Valuation_Date);

            if (this._Business_Interruption_Salaries != null)
                db.AddInParameter(dbCommand, "Business_Interruption_Salaries", DbType.Decimal, this._Business_Interruption_Salaries);
            else
                db.AddInParameter(dbCommand, "Business_Interruption_Salaries", DbType.Decimal, DBNull.Value);

            if (this._Business_Interruption_Benefits != null)
                db.AddInParameter(dbCommand, "Business_Interruption_Benefits", DbType.Decimal, this._Business_Interruption_Benefits);
            else
                db.AddInParameter(dbCommand, "Business_Interruption_Benefits", DbType.Decimal, DBNull.Value);

            if (this._Business_interruption_fixed_costs != null)
                db.AddInParameter(dbCommand, "Business_interruption_fixed_costs", DbType.Decimal, this._Business_interruption_fixed_costs);
            else
                db.AddInParameter(dbCommand, "Business_interruption_fixed_costs", DbType.Decimal, DBNull.Value);

            if (this._Business_interruption_net_profit != null)
                db.AddInParameter(dbCommand, "Business_interruption_net_profit", DbType.Decimal, this._Business_interruption_net_profit);
            else
                db.AddInParameter(dbCommand, "Business_interruption_net_profit", DbType.Decimal, DBNull.Value);

            db.AddInParameter(dbCommand, "Updated_By", DbType.Decimal, this._Updated_By);
            db.AddInParameter(dbCommand, "Updated_Date", DbType.DateTime, this._Updated_Date);
			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the Property_COPE table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectByPK(decimal pK_Property_Cope_ID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Property_COPESelectByPK");

			db.AddInParameter(dbCommand, "PK_Property_Cope_ID", DbType.Decimal, pK_Property_Cope_ID);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the Property_COPE table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Property_COPESelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the Property_COPE table.
		/// </summary>
		public void Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Property_COPEUpdate");

			db.AddInParameter(dbCommand, "PK_Property_Cope_ID", DbType.Decimal, this._PK_Property_Cope_ID);
			db.AddInParameter(dbCommand, "FK_LU_Location_ID", DbType.Decimal, this._FK_LU_Location_ID);
			db.AddInParameter(dbCommand, "Status", DbType.String, this._Status);
			db.AddInParameter(dbCommand, "Status_As_Of_Date", DbType.DateTime, this._Status_As_Of_Date);
			db.AddInParameter(dbCommand, "Disposal_Type", DbType.String, this._Disposal_Type);

            if (this._Union_shop != null)
                db.AddInParameter(dbCommand, "Union_shop", DbType.Boolean, this._Union_shop);
            else
                db.AddInParameter(dbCommand, "Union_shop", DbType.Boolean, DBNull.Value);

			db.AddInParameter(dbCommand, "Property_Boundary_Dimemsions", DbType.String, this._Property_Boundary_Dimemsions);
			db.AddInParameter(dbCommand, "Address_1", DbType.String, this._Address_1);
			db.AddInParameter(dbCommand, "Address_2", DbType.String, this._Address_2);
			db.AddInParameter(dbCommand, "City", DbType.String, this._City);
			db.AddInParameter(dbCommand, "State", DbType.String, this._State);
			db.AddInParameter(dbCommand, "Zip", DbType.String, this._Zip);
			db.AddInParameter(dbCommand, "Telephone", DbType.String, this._Telephone);
			db.AddInParameter(dbCommand, "Web_site", DbType.String, this._Web_site);
			db.AddInParameter(dbCommand, "Valuation_Date", DbType.DateTime, this._Valuation_Date);

            if (this._Business_Interruption_Salaries != null)
                db.AddInParameter(dbCommand, "Business_Interruption_Salaries", DbType.Decimal, this._Business_Interruption_Salaries);
            else
                db.AddInParameter(dbCommand, "Business_Interruption_Salaries", DbType.Decimal, DBNull.Value);

            if (this._Business_Interruption_Benefits != null)
                db.AddInParameter(dbCommand, "Business_Interruption_Benefits", DbType.Decimal, this._Business_Interruption_Benefits);
            else
                db.AddInParameter(dbCommand, "Business_Interruption_Benefits", DbType.Decimal, DBNull.Value);

            if (this._Business_interruption_fixed_costs != null)
                db.AddInParameter(dbCommand, "Business_interruption_fixed_costs", DbType.Decimal, this._Business_interruption_fixed_costs);
            else
                db.AddInParameter(dbCommand, "Business_interruption_fixed_costs", DbType.Decimal, DBNull.Value);

            if (this._Business_interruption_net_profit != null)
                db.AddInParameter(dbCommand, "Business_interruption_net_profit", DbType.Decimal, this._Business_interruption_net_profit);
            else
                db.AddInParameter(dbCommand, "Business_interruption_net_profit", DbType.Decimal, DBNull.Value);

            db.AddInParameter(dbCommand, "Updated_By", DbType.Decimal, this._Updated_By);
            db.AddInParameter(dbCommand, "Updated_Date", DbType.DateTime, this._Updated_Date);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the Property_COPE table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_Property_Cope_ID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Property_COPEDeleteByPK");

			db.AddInParameter(dbCommand, "PK_Property_Cope_ID", DbType.Decimal, pK_Property_Cope_ID);

			db.ExecuteNonQuery(dbCommand);
        }

        public static int SelectPKByLocation(int fK_LU_Location_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();

            DbCommand dbCommand = db.GetStoredProcCommand("Property_COPESelectPKByLocation");

            db.AddInParameter(dbCommand, "FK_LU_Location_ID", DbType.Int32, fK_LU_Location_ID);
            db.AddOutParameter(dbCommand, "PK_Property_Cope_ID", DbType.Int32,1);

            db.ExecuteNonQuery(dbCommand);
            return Convert.ToInt32(dbCommand.Parameters["@PK_Property_Cope_ID"].Value);

        }
        #endregion
    }
}
