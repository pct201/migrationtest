using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for PA_Screen_Fields table.
	/// </summary>
	public sealed class clsPA_Screen_Fields
	{

		#region Private variables used to hold the property values

		private decimal? _PK_PA_Screen_Fields;
		private int? _Year;
		private decimal? _WC_Premium;
		private decimal? _Texas_WC_Premium;
		private decimal? _Loss_Fund_Premium;
		private decimal? _Garage_Liability_Premium;
		private decimal? _Property_Premium;
		private decimal? _Crime_Premium;
		private decimal? _Umbrella_Premium;
		private decimal? _Excess_Umbrella_Premium;
		private decimal? _Second_Layer_Umbrella_Premium;
		private decimal? _EPL_Premium;
		private decimal? _Cyber_Premium;
		private decimal? _Total_Risk_Management_Fee;
		private DateTime? _Update_Date;
		private string _Updated_By;
        private decimal? _Pollution_Premium;
        private DateTime? _Property_Valuation_Date;
        private decimal? _Directors_Officers_Premium;
        private decimal? _Fiduciary_Premium;
        private decimal? _Kidnap_Ransom_Premium;
        private decimal? _Earthquake_Premium;
        private decimal? _Dealers_Physical_Damage_Premium;
        private int? _Total_Locations;

        private int? _WC_Headcount;
        private int? _Texas_WC_Headcount;
         private decimal? _Texas_WC_Payroll;
        private decimal? _WC_Payroll;
        private decimal? _PP_Total_RS_Means;
        private decimal? _PP_Total_Business_Interruption;
        private decimal? _PP_Total_Contents;
         private decimal? _PP_Total_Parts;
        private decimal? _EP_Total_RS_Means;
        private decimal? _EP_Total_Business_Interruption;
        private decimal? _EP_Total_Contents;
        private decimal? _EP_Total_Parts;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_PA_Screen_Fields value.
		/// </summary>
		public decimal? PK_PA_Screen_Fields
		{
			get { return _PK_PA_Screen_Fields; }
			set { _PK_PA_Screen_Fields = value; }
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
		/// Gets or sets the WC_Premium value.
		/// </summary>
		public decimal? WC_Premium
		{
			get { return _WC_Premium; }
			set { _WC_Premium = value; }
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
		/// Gets or sets the Loss_Fund_Premium value.
		/// </summary>
		public decimal? Loss_Fund_Premium
		{
			get { return _Loss_Fund_Premium; }
			set { _Loss_Fund_Premium = value; }
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
		/// Gets or sets the Property_Premium value.
		/// </summary>
		public decimal? Property_Premium
		{
			get { return _Property_Premium; }
			set { _Property_Premium = value; }
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
		/// Gets or sets the Umbrella_Premium value.
		/// </summary>
		public decimal? Umbrella_Premium
		{
			get { return _Umbrella_Premium; }
			set { _Umbrella_Premium = value; }
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
		/// Gets or sets the Second_Layer_Umbrella_Premium value.
		/// </summary>
		public decimal? Second_Layer_Umbrella_Premium
		{
			get { return _Second_Layer_Umbrella_Premium; }
			set { _Second_Layer_Umbrella_Premium = value; }
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
		/// Gets or sets the Cyber_Premium value.
		/// </summary>
		public decimal? Cyber_Premium
		{
			get { return _Cyber_Premium; }
			set { _Cyber_Premium = value; }
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

        // <summary>
        /// Gets or sets the Pollution_Premium value.
        /// </summary>
        public decimal? Pollution_Premium
        {
            get { return _Pollution_Premium; }
            set { _Pollution_Premium = value; }
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
        /// Gets or sets the Directors_Officers_Premium value.
        /// </summary>
        public decimal? Directors_Officers_Premium
        {
            get { return _Directors_Officers_Premium; }
            set { _Directors_Officers_Premium = value; }
        }

        /// <summary>
        /// Gets or sets the Fiduciary_Premium value.
        /// </summary>
        public decimal? Fiduciary_Premium
        {
            get { return _Fiduciary_Premium; }
            set { _Fiduciary_Premium = value; }
        }

        /// <summary>
        /// Gets or sets the Kidnap_Ransom_Premium value.
        /// </summary>
        public decimal? Kidnap_Ransom_Premium
        {
            get { return _Kidnap_Ransom_Premium; }
            set { _Kidnap_Ransom_Premium = value; }
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
        /// Gets or sets the Dealers_Physical_Damage_Premium value.
        /// </summary>
        public decimal? Dealers_Physical_Damage_Premium
        {
            get { return _Dealers_Physical_Damage_Premium; }
            set { _Dealers_Physical_Damage_Premium = value; }
        }

        /// <summary>
        /// Gets or sets the Total_Locations value.
        /// </summary>
        public int? Total_Locations
        {
            get { return _Total_Locations; }
            set { _Total_Locations = value; }
        }



        public decimal? Texas_WC_Payroll
        {
            get { return _Texas_WC_Payroll; }
            set { _Texas_WC_Payroll = value; }
        }
        public int? WC_Headcount
        {
            get { return _WC_Headcount; }
            set { _WC_Headcount = value; }
        }
        public int? Texas_WC_Headcount
        {
            get { return _Texas_WC_Headcount; }
            set { _Texas_WC_Headcount = value; }}
        


        public  decimal? WC_Payroll
        {
            get { return _WC_Payroll;}
            set { _WC_Payroll = value;}
        }
        public decimal? PP_Total_RS_Means
        {
             get { return _PP_Total_RS_Means; }
            set { _PP_Total_RS_Means = value; }
        }
        public decimal? PP_Total_Business_Interruption
        {
             get { return _PP_Total_Business_Interruption; }
            set { _PP_Total_Business_Interruption = value; }
        }
        public decimal? PP_Total_Contents
        {
            get { return _PP_Total_Contents; }
            set { _PP_Total_Contents = value; }
        }
        public decimal? PP_Total_Parts
        {
             get { return _PP_Total_Parts; }
            set { _PP_Total_Parts = value; }
        }
        public decimal? EP_Total_RS_Means
        {
             get { return _EP_Total_RS_Means; }
            set { _EP_Total_RS_Means = value; }
        }
        public decimal? EP_Total_Business_Interruption
        {
            get { return _EP_Total_Business_Interruption; }
            set { _EP_Total_Business_Interruption = value; }
        }
        public decimal? EP_Total_Contents
        {
           get { return _EP_Total_Contents; }
            set { _EP_Total_Contents = value; }
        }
        public decimal? EP_Total_Parts
        {
            get { return _EP_Total_Parts; }
            set { _EP_Total_Parts = value; }
        }
		#endregion

		#region Default Constructors

		/// <summary>
		/// Initializes a new instance of the clsPA_Screen_Fields class with default value.
		/// </summary>
		public clsPA_Screen_Fields() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the clsPA_Screen_Fields class based on Primary Key.
		/// </summary>
		public clsPA_Screen_Fields(decimal pK_PA_Screen_Fields) 
		{
			DataTable dtPA_Screen_Fields = SelectByPK(pK_PA_Screen_Fields).Tables[0];

			if (dtPA_Screen_Fields.Rows.Count == 1)
			{
				 SetValue(dtPA_Screen_Fields.Rows[0]);

			}

		}


		/// <summary>
		/// Initializes a new instance of the clsPA_Screen_Fields class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drPA_Screen_Fields) 
		{
				if (drPA_Screen_Fields["PK_PA_Screen_Fields"] == DBNull.Value)
					this._PK_PA_Screen_Fields = null;
				else
					this._PK_PA_Screen_Fields = (decimal?)drPA_Screen_Fields["PK_PA_Screen_Fields"];

				if (drPA_Screen_Fields["Year"] == DBNull.Value)
					this._Year = null;
				else
					this._Year = (int?)drPA_Screen_Fields["Year"];

				if (drPA_Screen_Fields["WC_Premium"] == DBNull.Value)
					this._WC_Premium = null;
				else
					this._WC_Premium = (decimal?)drPA_Screen_Fields["WC_Premium"];

				if (drPA_Screen_Fields["Texas_WC_Premium"] == DBNull.Value)
					this._Texas_WC_Premium = null;
				else
					this._Texas_WC_Premium = (decimal?)drPA_Screen_Fields["Texas_WC_Premium"];

				if (drPA_Screen_Fields["Loss_Fund_Premium"] == DBNull.Value)
					this._Loss_Fund_Premium = null;
				else
					this._Loss_Fund_Premium = (decimal?)drPA_Screen_Fields["Loss_Fund_Premium"];

				if (drPA_Screen_Fields["Garage_Liability_Premium"] == DBNull.Value)
					this._Garage_Liability_Premium = null;
				else
					this._Garage_Liability_Premium = (decimal?)drPA_Screen_Fields["Garage_Liability_Premium"];

				if (drPA_Screen_Fields["Property_Premium"] == DBNull.Value)
					this._Property_Premium = null;
				else
					this._Property_Premium = (decimal?)drPA_Screen_Fields["Property_Premium"];

				if (drPA_Screen_Fields["Crime_Premium"] == DBNull.Value)
					this._Crime_Premium = null;
				else
					this._Crime_Premium = (decimal?)drPA_Screen_Fields["Crime_Premium"];

				if (drPA_Screen_Fields["Umbrella_Premium"] == DBNull.Value)
					this._Umbrella_Premium = null;
				else
					this._Umbrella_Premium = (decimal?)drPA_Screen_Fields["Umbrella_Premium"];

				if (drPA_Screen_Fields["Excess_Umbrella_Premium"] == DBNull.Value)
					this._Excess_Umbrella_Premium = null;
				else
					this._Excess_Umbrella_Premium = (decimal?)drPA_Screen_Fields["Excess_Umbrella_Premium"];

				if (drPA_Screen_Fields["Second_Layer_Umbrella_Premium"] == DBNull.Value)
					this._Second_Layer_Umbrella_Premium = null;
				else
					this._Second_Layer_Umbrella_Premium = (decimal?)drPA_Screen_Fields["Second_Layer_Umbrella_Premium"];

				if (drPA_Screen_Fields["EPL_Premium"] == DBNull.Value)
					this._EPL_Premium = null;
				else
					this._EPL_Premium = (decimal?)drPA_Screen_Fields["EPL_Premium"];

				if (drPA_Screen_Fields["Cyber_Premium"] == DBNull.Value)
					this._Cyber_Premium = null;
				else
					this._Cyber_Premium = (decimal?)drPA_Screen_Fields["Cyber_Premium"];

				if (drPA_Screen_Fields["Total_Risk_Management_Fee"] == DBNull.Value)
					this._Total_Risk_Management_Fee = null;
				else
					this._Total_Risk_Management_Fee = (decimal?)drPA_Screen_Fields["Total_Risk_Management_Fee"];

				if (drPA_Screen_Fields["Update_Date"] == DBNull.Value)
					this._Update_Date = null;
				else
					this._Update_Date = (DateTime?)drPA_Screen_Fields["Update_Date"];

				if (drPA_Screen_Fields["Updated_By"] == DBNull.Value)
					this._Updated_By = null;
				else
					this._Updated_By = (string)drPA_Screen_Fields["Updated_By"];

                if (drPA_Screen_Fields["Pollution_Premium"] == DBNull.Value)
                    this._Pollution_Premium = null;
                else
                    this._Pollution_Premium = (decimal?)drPA_Screen_Fields["Pollution_Premium"];

                if (drPA_Screen_Fields["Property_Valuation_Date"] == DBNull.Value)
                    this._Property_Valuation_Date = null;
                else
                    this._Property_Valuation_Date = (DateTime?)drPA_Screen_Fields["Property_Valuation_Date"];

                if (drPA_Screen_Fields["Directors_Officers_Premium"] == DBNull.Value)
                    this._Directors_Officers_Premium = null;
                else
                    this._Directors_Officers_Premium = (decimal?)drPA_Screen_Fields["Directors_Officers_Premium"];

                if (drPA_Screen_Fields["Fiduciary_Premium"] == DBNull.Value)
                    this._Fiduciary_Premium = null;
                else
                    this._Fiduciary_Premium = (decimal?)drPA_Screen_Fields["Fiduciary_Premium"];

                if (drPA_Screen_Fields["Kidnap_Ransom_Premium"] == DBNull.Value)
                    this._Kidnap_Ransom_Premium = null;
                else
                    this._Kidnap_Ransom_Premium = (decimal?)drPA_Screen_Fields["Kidnap_Ransom_Premium"];

                if (drPA_Screen_Fields["Earthquake_Premium"] == DBNull.Value)
                    this._Earthquake_Premium = null;
                else
                    this._Earthquake_Premium = (decimal?)drPA_Screen_Fields["Earthquake_Premium"];

                if (drPA_Screen_Fields["Dealers_Physical_Damage_Premium"] == DBNull.Value)
                    this._Dealers_Physical_Damage_Premium = null;
                else
                    this._Dealers_Physical_Damage_Premium = (decimal?)drPA_Screen_Fields["Dealers_Physical_Damage_Premium"];

                if (drPA_Screen_Fields["Total_Locations"] == DBNull.Value)
                    this._Total_Locations = null;
                else
                    this._Total_Locations = (int?)drPA_Screen_Fields["Total_Locations"];

                if (drPA_Screen_Fields["WC_Headcount"] == DBNull.Value)
                    this.WC_Headcount  = null;
                else
                    this.WC_Headcount = (int?)drPA_Screen_Fields["WC_Headcount"];

                if (drPA_Screen_Fields["Texas_WC_Headcount"] == DBNull.Value)
                    this.Texas_WC_Headcount = null;
                else
                    this.Texas_WC_Headcount = (int?)drPA_Screen_Fields["Texas_WC_Headcount"];

                if (drPA_Screen_Fields["WC_Payroll"] == DBNull.Value)
                    this.WC_Payroll = null;
                else
                    this.WC_Payroll = (decimal?)drPA_Screen_Fields["WC_Payroll"];

                if (drPA_Screen_Fields["Texas_WC_Payroll"] == DBNull.Value)
                    this.Texas_WC_Payroll = null;
                else
                    this.Texas_WC_Payroll = (decimal?)drPA_Screen_Fields["Texas_WC_Payroll"];

                if (drPA_Screen_Fields["PP_Total_RS_Means"] == DBNull.Value)
                    this.PP_Total_RS_Means = null;
                else
                    this.PP_Total_RS_Means = (decimal?)drPA_Screen_Fields["PP_Total_RS_Means"];

                if (drPA_Screen_Fields["PP_Total_Business_Interruption"] == DBNull.Value)
                    this.PP_Total_Business_Interruption = null;
                else
                    this.PP_Total_Business_Interruption = (decimal?)drPA_Screen_Fields["PP_Total_Business_Interruption"];

                if (drPA_Screen_Fields["PP_Total_Contents"] == DBNull.Value)
                    this.PP_Total_Contents = null;
                else
                    this.PP_Total_Contents = (decimal?)drPA_Screen_Fields["PP_Total_Contents"];

                if (drPA_Screen_Fields["PP_Total_Parts"] == DBNull.Value)
                    this.PP_Total_Parts = null;
                else
                    this.PP_Total_Parts = (decimal?)drPA_Screen_Fields["PP_Total_Parts"];

                if (drPA_Screen_Fields["EP_Total_RS_Means"] == DBNull.Value)
                    this.EP_Total_RS_Means = null;
                else
                    this.EP_Total_RS_Means = (decimal?)drPA_Screen_Fields["EP_Total_RS_Means"];

                if (drPA_Screen_Fields["EP_Total_Business_Interruption"] == DBNull.Value)
                    this.EP_Total_Business_Interruption = null;
                else
                    this.EP_Total_Business_Interruption = (decimal?)drPA_Screen_Fields["EP_Total_Business_Interruption"];

                if (drPA_Screen_Fields["EP_Total_Contents"] == DBNull.Value)
                    this.EP_Total_Contents = null;
                else
                    this.EP_Total_Contents = (decimal?)drPA_Screen_Fields["EP_Total_Contents"];

                if (drPA_Screen_Fields["EP_Total_Parts"] == DBNull.Value)
                    this.EP_Total_Parts = null;
                else
                    this.EP_Total_Parts = (decimal?)drPA_Screen_Fields["EP_Total_Parts"];
		}

		#endregion

		/// <summary>
		/// Inserts a record into the PA_Screen_Fields table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("PA_Screen_FieldsInsert");

			
			db.AddInParameter(dbCommand, "Year", DbType.Int32, this._Year);
			
			db.AddInParameter(dbCommand, "WC_Premium", DbType.Decimal, this._WC_Premium);
			
			db.AddInParameter(dbCommand, "Texas_WC_Premium", DbType.Decimal, this._Texas_WC_Premium);
			
			db.AddInParameter(dbCommand, "Loss_Fund_Premium", DbType.Decimal, this._Loss_Fund_Premium);
			
			db.AddInParameter(dbCommand, "Garage_Liability_Premium", DbType.Decimal, this._Garage_Liability_Premium);
			
			db.AddInParameter(dbCommand, "Property_Premium", DbType.Decimal, this._Property_Premium);
			
			db.AddInParameter(dbCommand, "Crime_Premium", DbType.Decimal, this._Crime_Premium);
			
			db.AddInParameter(dbCommand, "Umbrella_Premium", DbType.Decimal, this._Umbrella_Premium);
			
			db.AddInParameter(dbCommand, "Excess_Umbrella_Premium", DbType.Decimal, this._Excess_Umbrella_Premium);
			
			db.AddInParameter(dbCommand, "Second_Layer_Umbrella_Premium", DbType.Decimal, this._Second_Layer_Umbrella_Premium);
			
			db.AddInParameter(dbCommand, "EPL_Premium", DbType.Decimal, this._EPL_Premium);
			
			db.AddInParameter(dbCommand, "Cyber_Premium", DbType.Decimal, this._Cyber_Premium);
			
			db.AddInParameter(dbCommand, "Total_Risk_Management_Fee", DbType.Decimal, this._Total_Risk_Management_Fee);
			
			db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);
			
			if (string.IsNullOrEmpty(this._Updated_By))
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);

            db.AddInParameter(dbCommand, "Pollution_Premium", DbType.Decimal, this._Pollution_Premium);

            db.AddInParameter(dbCommand, "Property_Valuation_Date", DbType.DateTime, this._Property_Valuation_Date);

            db.AddInParameter(dbCommand, "Directors_Officers_Premium", DbType.Decimal, this._Directors_Officers_Premium);

            db.AddInParameter(dbCommand, "Fiduciary_Premium", DbType.Decimal, this._Fiduciary_Premium);

            db.AddInParameter(dbCommand, "Kidnap_Ransom_Premium", DbType.Decimal, this._Kidnap_Ransom_Premium);

            db.AddInParameter(dbCommand, "Earthquake_Premium", DbType.Decimal, this._Earthquake_Premium);

            db.AddInParameter(dbCommand, "Dealers_Physical_Damage_Premium", DbType.Decimal, this._Dealers_Physical_Damage_Premium);

            db.AddInParameter(dbCommand, "Total_Locations", DbType.Int32, this._Total_Locations);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the PA_Screen_Fields table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		private DataSet SelectByPK(decimal pK_PA_Screen_Fields)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("PA_Screen_FieldsSelectByPK");

			db.AddInParameter(dbCommand, "PK_PA_Screen_Fields", DbType.Decimal, pK_PA_Screen_Fields);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the PA_Screen_Fields table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("PA_Screen_FieldsSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the PA_Screen_Fields table.
		/// </summary>
		public void Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("PA_Screen_FieldsUpdate");

			
			db.AddInParameter(dbCommand, "PK_PA_Screen_Fields", DbType.Decimal, this._PK_PA_Screen_Fields);
			
			db.AddInParameter(dbCommand, "Year", DbType.Int32, this._Year);
			
			db.AddInParameter(dbCommand, "WC_Premium", DbType.Decimal, this._WC_Premium);
			
			db.AddInParameter(dbCommand, "Texas_WC_Premium", DbType.Decimal, this._Texas_WC_Premium);
			
			db.AddInParameter(dbCommand, "Loss_Fund_Premium", DbType.Decimal, this._Loss_Fund_Premium);
			
			db.AddInParameter(dbCommand, "Garage_Liability_Premium", DbType.Decimal, this._Garage_Liability_Premium);
			
			db.AddInParameter(dbCommand, "Property_Premium", DbType.Decimal, this._Property_Premium);
			
			db.AddInParameter(dbCommand, "Crime_Premium", DbType.Decimal, this._Crime_Premium);
			
			db.AddInParameter(dbCommand, "Umbrella_Premium", DbType.Decimal, this._Umbrella_Premium);
			
			db.AddInParameter(dbCommand, "Excess_Umbrella_Premium", DbType.Decimal, this._Excess_Umbrella_Premium);
			
			db.AddInParameter(dbCommand, "Second_Layer_Umbrella_Premium", DbType.Decimal, this._Second_Layer_Umbrella_Premium);
			
			db.AddInParameter(dbCommand, "EPL_Premium", DbType.Decimal, this._EPL_Premium);
			
			db.AddInParameter(dbCommand, "Cyber_Premium", DbType.Decimal, this._Cyber_Premium);
			
			db.AddInParameter(dbCommand, "Total_Risk_Management_Fee", DbType.Decimal, this._Total_Risk_Management_Fee);
			
			db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);
			
			if (string.IsNullOrEmpty(this._Updated_By))
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);

            db.AddInParameter(dbCommand, "Pollution_Premium", DbType.Decimal, this._Pollution_Premium);

            db.AddInParameter(dbCommand, "Property_Valuation_Date", DbType.DateTime, this._Property_Valuation_Date);

            db.AddInParameter(dbCommand, "Directors_Officers_Premium", DbType.Decimal, this._Directors_Officers_Premium);

            db.AddInParameter(dbCommand, "Fiduciary_Premium", DbType.Decimal, this._Fiduciary_Premium);

            db.AddInParameter(dbCommand, "Kidnap_Ransom_Premium", DbType.Decimal, this._Kidnap_Ransom_Premium);

            db.AddInParameter(dbCommand, "Earthquake_Premium", DbType.Decimal, this._Earthquake_Premium);

            db.AddInParameter(dbCommand, "Dealers_Physical_Damage_Premium", DbType.Decimal, this._Dealers_Physical_Damage_Premium);

            db.AddInParameter(dbCommand, "Total_Locations", DbType.Int32, this._Total_Locations);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the PA_Screen_Fields table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_PA_Screen_Fields)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("PA_Screen_FieldsDeleteByPK");

			db.AddInParameter(dbCommand, "PK_PA_Screen_Fields", DbType.Decimal, pK_PA_Screen_Fields);

			db.ExecuteNonQuery(dbCommand);
		}


        /// <summary>
        /// Selects all records from the PA_Screen_Fields table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet PA_Screen_FieldsSelectByYear(int? Year, string strOrderBy, string strOrder, int intPageNo, int intPageSize)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("PA_Screen_FieldsSelectByYear");
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
            DbCommand dbCommand = db.GetStoredProcCommand("AllocationYear_Check");

            db.AddInParameter(dbCommand, "PK_PA_Screen_Fields", DbType.Decimal, PK_PA_Screen_Fields);
            db.AddInParameter(dbCommand, "Year", DbType.Int32, Year);

            return Convert.ToBoolean(db.ExecuteScalar(dbCommand));
        }

        /// <summary>
        /// Generate Report For Premium Allocation.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet rptSonic_Premium_Allocation(int? Year, string Region, decimal? Market, decimal? State, decimal? Location)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("rptSonic_Premium_Allocation");
            db.AddInParameter(dbCommand, "Year", DbType.Int32, Year);
            db.AddInParameter(dbCommand, "Region", DbType.String, Region);
            db.AddInParameter(dbCommand, "Market", DbType.Decimal, Market);
            db.AddInParameter(dbCommand, "State", DbType.Decimal, State);
            db.AddInParameter(dbCommand, "Location", DbType.Decimal, Location);
            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Check Duplicate Status For Premium Allocation Annual Report.
        /// </summary>
        /// <returns>DataSet</returns>
        public static int GetStatusOfDuplicateAnnualReport(int? Year)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("GetStatusOfDuplicateAnnualReport");
            db.AddInParameter(dbCommand, "Year", DbType.Int32, Year);

            // Execute the query and return the new identity value
            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
        }


        /// <summary>
        /// Generate Report For Premium Allocation Annual Report.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet Generate_PremiumAllocation_Annual_Report(int? Year, decimal? Location, string Report_Type)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Generate_PremiumAllocation_Annual_Report");
            db.AddInParameter(dbCommand, "Year", DbType.Int32, Year);
            db.AddInParameter(dbCommand, "Location", DbType.Decimal, Location);
            db.AddInParameter(dbCommand, "Report_Type", DbType.String, Report_Type);
            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet Generate_PremiumAllocation_Annual_Report_New(int? Year)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("GeneratePremiumAllocationAnnualReport");
            db.AddInParameter(dbCommand, "Year", DbType.Int32, Year);
            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Generate Report For Premium Allocation Monthly BreakDown Report.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet Generate_Monthly_Premium_Allocation_Report(int? Year, int? Month, string Report_Type)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Generate_Monthly_Premium_Allocation_Report");
            db.AddInParameter(dbCommand, "Year", DbType.Int32, Year);
            db.AddInParameter(dbCommand, "Month", DbType.Int32, Month);
            db.AddInParameter(dbCommand, "Report_Type", DbType.String, Report_Type);
            return db.ExecuteDataSet(dbCommand);
        }


        /// <summary>
        /// Bind Year Dropdown for add location.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet GetYearPremiumAllocation()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("GetYearPremiumAllocation");
            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Deletes a record from the PA_Premium_Allocation_Monthly table.
        /// </summary>
        public static void PremiumAllocation_Removelocation(int? Year, int? Month, decimal Location)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("PremiumAllocation_Removelocation");

            db.AddInParameter(dbCommand, "Year", DbType.Int32, Year);
            db.AddInParameter(dbCommand, "Month", DbType.Int32, Month);
            db.AddInParameter(dbCommand, "Location", DbType.Decimal, Location);

            db.ExecuteNonQuery(dbCommand);
        }

        public static DataSet PA_Values_Imported_SelectByYearAndLocation(int? Year, decimal Location)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("PA_Values_Imported_SelectByYearAndLocation");

            db.AddInParameter(dbCommand, "Year", DbType.Int32, Year);
            db.AddInParameter(dbCommand, "Location", DbType.Decimal, Location);

            return db.ExecuteDataSet(dbCommand);
        }


        ///// <summary>
        ///// Selects a single record from the PA_Screen_Fields table by a primary key.
        ///// </summary>
        ///// <returns>DataSet</returns>
        //public static DataSet SelectFieldsByValuationDate(DateTime valuationdate)
        //{
        //    Database db = DatabaseFactory.CreateDatabase();
        //    DbCommand dbCommand = db.GetStoredProcCommand("PA_Screen_FieldsSelect_ByValuation_Date");

        //    db.AddInParameter(dbCommand, "ValuationDate", DbType.DateTime, valuationdate);

        //    return db.ExecuteDataSet(dbCommand);
        //}

        ///// <summary>
        ///// Selects a single record from the PA_Screen_Fields table by a primary key.
        ///// </summary>
        ///// <returns>DataSet</returns>
        //public static DataSet SelectFieldsByYearWise(int year)
        //{
        //    Database db = DatabaseFactory.CreateDatabase();
        //    DbCommand dbCommand = db.GetStoredProcCommand("PA_Screen_FieldsSelect_Yearwise");

        //    db.AddInParameter(dbCommand, "Year", DbType.Int32 , year);

        //    return db.ExecuteDataSet(dbCommand);
        //}
	}
}
