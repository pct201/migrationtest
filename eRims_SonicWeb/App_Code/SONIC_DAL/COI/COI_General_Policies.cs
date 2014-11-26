using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for COI_General_Policies table.
	/// </summary>
	public sealed class COI_General_Policies
    {
        #region Fields

        private decimal _PK_COI_General_Policies;
        private decimal _FK_COIs;
        private string _Insurance_Company;
        private string _Policy_Number;
        private DateTime _Issue_Date;
        private DateTime _Effective_Date;
        private DateTime _Expiration_Date;
        private DateTime _Cancellation_Date;
        private string _Commercial_Liability;
        private string _Product_Liability;
        private string _Occurrence_Liability;
        private string _Stop_Gap_Endorsement;
        private string _Auto_Liability;
        private int _GALimitAppliesTo;
        private Nullable<decimal> _Occurrence_Covereage;
        private Nullable<decimal> _Fire_Damage;
        private Nullable<decimal> _Medical_Expense;
        private Nullable<decimal> _Personal_Advertising_Injury;
        private Nullable<decimal> _General_Aggregate;
        private Nullable<decimal> _Products_Operations;
        private Nullable<decimal> _Stop_Gap_Coverage;
        private Nullable<decimal> _Auto_Coverage;
        private string _Notes;
        private DateTime _Update_Date;
        private string _Updated_By;
        private string _Other_Liability1;
        private Nullable<decimal> _Other_Liability_Coverage1;
        private string _Other_Liability2;
        private Nullable<decimal> _Other_Liability_Coverage2;

        #endregion


        #region Properties

        /// <summary> 
        /// Gets or sets the PK_COI_General_Policies value.
        /// </summary>
        public decimal PK_COI_General_Policies
        {
            get { return _PK_COI_General_Policies; }
            set { _PK_COI_General_Policies = value; }
        }


        /// <summary> 
        /// Gets or sets the FK_COIs value.
        /// </summary>
        public decimal FK_COIs
        {
            get { return _FK_COIs; }
            set { _FK_COIs = value; }
        }


        /// <summary> 
        /// Gets or sets the Insurance_Company value.
        /// </summary>
        public string Insurance_Company
        {
            get { return _Insurance_Company; }
            set { _Insurance_Company = value; }
        }


        /// <summary> 
        /// Gets or sets the Policy_Number value.
        /// </summary>
        public string Policy_Number
        {
            get { return _Policy_Number; }
            set { _Policy_Number = value; }
        }


        /// <summary> 
        /// Gets or sets the Issue_Date value.
        /// </summary>
        public DateTime Issue_Date
        {
            get { return _Issue_Date; }
            set { _Issue_Date = value; }
        }


        /// <summary> 
        /// Gets or sets the Effective_Date value.
        /// </summary>
        public DateTime Effective_Date
        {
            get { return _Effective_Date; }
            set { _Effective_Date = value; }
        }


        /// <summary> 
        /// Gets or sets the Expiration_Date value.
        /// </summary>
        public DateTime Expiration_Date
        {
            get { return _Expiration_Date; }
            set { _Expiration_Date = value; }
        }


        /// <summary> 
        /// Gets or sets the Cancellation_Date value.
        /// </summary>
        public DateTime Cancellation_Date
        {
            get { return _Cancellation_Date; }
            set { _Cancellation_Date = value; }
        }


        /// <summary> 
        /// Gets or sets the Commercial_Liability value.
        /// </summary>
        public string Commercial_Liability
        {
            get { return _Commercial_Liability; }
            set { _Commercial_Liability = value; }
        }


        /// <summary> 
        /// Gets or sets the Product_Liability value.
        /// </summary>
        public string Product_Liability
        {
            get { return _Product_Liability; }
            set { _Product_Liability = value; }
        }


        /// <summary> 
        /// Gets or sets the Occurrence_Liability value.
        /// </summary>
        public string Occurrence_Liability
        {
            get { return _Occurrence_Liability; }
            set { _Occurrence_Liability = value; }
        }


        /// <summary> 
        /// Gets or sets the Stop_Gap_Endorsement value.
        /// </summary>
        public string Stop_Gap_Endorsement
        {
            get { return _Stop_Gap_Endorsement; }
            set { _Stop_Gap_Endorsement = value; }
        }


        /// <summary> 
        /// Gets or sets the Auto_Liability value.
        /// </summary>
        public string Auto_Liability
        {
            get { return _Auto_Liability; }
            set { _Auto_Liability = value; }
        }

        /// <summary> 
        /// Gets or sets the GALimitAppliesTo value.
        /// </summary>
        public int GALimitAppliesTo
        {
            get { return _GALimitAppliesTo; }
            set { _GALimitAppliesTo = value; }
        }

        /// <summary> 
        /// Gets or sets the Occurrence_Covereage value.
        /// </summary>
        public Nullable<decimal> Occurrence_Covereage
        {
            get { return _Occurrence_Covereage; }
            set { _Occurrence_Covereage = value; }
        }


        /// <summary> 
        /// Gets or sets the Fire_Damage value.
        /// </summary>
        public Nullable<decimal> Fire_Damage
        {
            get { return _Fire_Damage; }
            set { _Fire_Damage = value; }
        }


        /// <summary> 
        /// Gets or sets the Medical_Expense value.
        /// </summary>
        public Nullable<decimal> Medical_Expense
        {
            get { return _Medical_Expense; }
            set { _Medical_Expense = value; }
        }


        /// <summary> 
        /// Gets or sets the Personal_Advertising_Injury value.
        /// </summary>
        public Nullable<decimal> Personal_Advertising_Injury
        {
            get { return _Personal_Advertising_Injury; }
            set { _Personal_Advertising_Injury = value; }
        }


        /// <summary> 
        /// Gets or sets the General_Aggregate value.
        /// </summary>
        public Nullable<decimal> General_Aggregate
        {
            get { return _General_Aggregate; }
            set { _General_Aggregate = value; }
        }


        /// <summary> 
        /// Gets or sets the Products_Operations value.
        /// </summary>
        public Nullable<decimal> Products_Operations
        {
            get { return _Products_Operations; }
            set { _Products_Operations = value; }
        }



        /// <summary> 
        /// Gets or sets the Stop_Gap_Coverage value.
        /// </summary>
        public Nullable<decimal> Stop_Gap_Coverage
        {
            get { return _Stop_Gap_Coverage; }
            set { _Stop_Gap_Coverage = value; }
        }


        /// <summary> 
        /// Gets or sets the Auto_Coverage value.
        /// </summary>
        public Nullable<decimal> Auto_Coverage
        {
            get { return _Auto_Coverage; }
            set { _Auto_Coverage = value; }
        }


        /// <summary> 
        /// Gets or sets the Notes value.
        /// </summary>
        public string Notes
        {
            get { return _Notes; }
            set { _Notes = value; }
        }


        /// <summary> 
        /// Gets or sets the Update_Date value.
        /// </summary>
        public DateTime Update_Date
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

        /// <summary>  /// Gets or sets the Other_Liability1 value. /// </summary> 
        public string Other_Liability1 {  get { return _Other_Liability1; }  set { _Other_Liability1 = value; } }  
        /// <summary>  /// Gets or sets the Other_Liability_Coverage1 value. /// </summary> 
        public Nullable<decimal> Other_Liability_Coverage1 { get { return _Other_Liability_Coverage1; } set { _Other_Liability_Coverage1 = value; } }  
        /// <summary>  /// Gets or sets the Other_Liability2 value. /// </summary> 
        public string Other_Liability2 {  get { return _Other_Liability2; }  set { _Other_Liability2 = value; } }  
        /// <summary>  /// Gets or sets the Other_Liability_Coverage2 value. /// </summary> 
        public Nullable<decimal> Other_Liability_Coverage2 { get { return _Other_Liability_Coverage2; } set { _Other_Liability_Coverage2 = value; } }  

        #endregion


        #region Constructors

        /// <summary> 

        /// Initializes a new instance of the COI_General_Policies class. with the default value.

        /// </summary>
        public COI_General_Policies()
        {
            this._PK_COI_General_Policies = -1;
            this._FK_COIs = -1;
            this._Insurance_Company = "";
            this._Policy_Number = "";
            this._Issue_Date = (DateTime) System.Data.SqlTypes.SqlDateTime.MinValue;;
            this._Effective_Date = (DateTime) System.Data.SqlTypes.SqlDateTime.MinValue;;
            this._Expiration_Date = (DateTime) System.Data.SqlTypes.SqlDateTime.MinValue;;
            this._Cancellation_Date = (DateTime) System.Data.SqlTypes.SqlDateTime.MinValue;;
            this._Commercial_Liability = "";
            this._Product_Liability = "";
            this._Occurrence_Liability = "";
            this._Stop_Gap_Endorsement = "";
            this._Auto_Liability = "";
            this._GALimitAppliesTo = 0;
            this._Occurrence_Covereage = null;
            this._Fire_Damage = null;
            this._Medical_Expense = null;
            this._Personal_Advertising_Injury = null;
            this._General_Aggregate = null;
            this._Products_Operations = null;
            this._Stop_Gap_Coverage = null;
            this._Auto_Coverage = null;
            this._Notes = "";
            this._Update_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue; 
            this._Updated_By = "";
            this._Other_Liability1 = "";
            this._Other_Liability_Coverage1 = null;
            this._Other_Liability2 = "";
            this._Other_Liability_Coverage2 = null;
        }



        /// <summary> 

        /// Initializes a new instance of the COI_General_Policies class for passed PrimaryKey with the values set from Database.

        /// </summary>
        public COI_General_Policies(decimal PK)
        {
            DataTable dtCOI_General_Policies = Select(PK).Tables[0];

            if (dtCOI_General_Policies.Rows.Count > 0)
            {

                DataRow drCOI_General_Policies = dtCOI_General_Policies.Rows[0];
                this._PK_COI_General_Policies = drCOI_General_Policies["PK_COI_General_Policies"] != DBNull.Value ? Convert.ToDecimal(drCOI_General_Policies["PK_COI_General_Policies"]) : 0;
                this._FK_COIs = drCOI_General_Policies["FK_COIs"] != DBNull.Value ? Convert.ToDecimal(drCOI_General_Policies["FK_COIs"]) : 0;
                this._Insurance_Company = Convert.ToString(drCOI_General_Policies["Insurance_Company"]);
                this._Policy_Number = Convert.ToString(drCOI_General_Policies["Policy_Number"]);
                this._Issue_Date = drCOI_General_Policies["Issue_Date"] != DBNull.Value ? Convert.ToDateTime(drCOI_General_Policies["Issue_Date"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue; ;
                this._Effective_Date = drCOI_General_Policies["Effective_Date"] != DBNull.Value ? Convert.ToDateTime(drCOI_General_Policies["Effective_Date"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue; ;
                this._Expiration_Date = drCOI_General_Policies["Expiration_Date"] != DBNull.Value ? Convert.ToDateTime(drCOI_General_Policies["Expiration_Date"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue; ;
                this._Cancellation_Date = drCOI_General_Policies["Cancellation_Date"] != DBNull.Value ? Convert.ToDateTime(drCOI_General_Policies["Cancellation_Date"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue; ;
                this._Commercial_Liability = Convert.ToString(drCOI_General_Policies["Commercial_Liability"]);
                this._Product_Liability = Convert.ToString(drCOI_General_Policies["Product_Liability"]);
                this._Occurrence_Liability = Convert.ToString(drCOI_General_Policies["Occurrence_Liability"]);
                this._Stop_Gap_Endorsement = Convert.ToString(drCOI_General_Policies["Stop_Gap_Endorsement"]);
                this._Auto_Liability = Convert.ToString(drCOI_General_Policies["Auto_Liability"]);
                this._GALimitAppliesTo = drCOI_General_Policies["GALimitAppliesTo"] != DBNull.Value ? Convert.ToInt32(drCOI_General_Policies["GALimitAppliesTo"]) : 0;
                if (drCOI_General_Policies["Occurrence_Covereage"] != DBNull.Value) this._Occurrence_Covereage = Convert.ToDecimal(drCOI_General_Policies["Occurrence_Covereage"]);
                if (drCOI_General_Policies["Fire_Damage"] != DBNull.Value) this._Fire_Damage = Convert.ToDecimal(drCOI_General_Policies["Fire_Damage"]);
                if (drCOI_General_Policies["Medical_Expense"] != DBNull.Value) this._Medical_Expense = Convert.ToDecimal(drCOI_General_Policies["Medical_Expense"]);
                if (drCOI_General_Policies["Personal_Advertising_Injury"] != DBNull.Value) this._Personal_Advertising_Injury = Convert.ToDecimal(drCOI_General_Policies["Personal_Advertising_Injury"]);
                if (drCOI_General_Policies["General_Aggregate"] != DBNull.Value) this._General_Aggregate = Convert.ToDecimal(drCOI_General_Policies["General_Aggregate"]);
                if (drCOI_General_Policies["Products_Operations"] != DBNull.Value) this._Products_Operations = Convert.ToDecimal(drCOI_General_Policies["Products_Operations"]);
                if (drCOI_General_Policies["Stop_Gap_Coverage"] != DBNull.Value) this._Stop_Gap_Coverage = Convert.ToDecimal(drCOI_General_Policies["Stop_Gap_Coverage"]);
                if (drCOI_General_Policies["Auto_Coverage"] != DBNull.Value) this._Auto_Coverage = Convert.ToDecimal(drCOI_General_Policies["Auto_Coverage"]);
                this._Notes = Convert.ToString(drCOI_General_Policies["Notes"]);
                this._Update_Date = drCOI_General_Policies["Update_Date"] != DBNull.Value ? Convert.ToDateTime(drCOI_General_Policies["Update_Date"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue; ;
                this._Updated_By = Convert.ToString(drCOI_General_Policies["Updated_By"]);
                this._Other_Liability1 = Convert.ToString(drCOI_General_Policies["Other_Liability1"]);
                if (drCOI_General_Policies["Other_Liability_Coverage1"] != DBNull.Value) this._Other_Liability_Coverage1 = Convert.ToDecimal(drCOI_General_Policies["Other_Liability_Coverage1"]);
                this._Other_Liability2 = Convert.ToString(drCOI_General_Policies["Other_Liability2"]);
                if (drCOI_General_Policies["Other_Liability_Coverage2"] != DBNull.Value) this._Other_Liability_Coverage2 = Convert.ToDecimal(drCOI_General_Policies["Other_Liability_Coverage2"]);
            }

            else
            {

                new COI_General_Policies();
            }

        }



        #endregion

        #region "Methods"

        /// <summary>
		/// Inserts a record into the COI_General_Policies table.
		/// <summary>
		/// <param name="fK_COIs"></param>
		/// <param name="insurance_Company"></param>
		/// <param name="policy_Number"></param>
		/// <param name="issue_Date"></param>
		/// <param name="effective_Date"></param>
		/// <param name="expiration_Date"></param>
		/// <param name="cancellation_Date"></param>
		/// <param name="commercial_Liability"></param>
		/// <param name="product_Liability"></param>
		/// <param name="occurrence_Liability"></param>
		/// <param name="stop_Gap_Endorsement"></param>
		/// <param name="auto_Liability"></param>
		/// <param name="occurrence_Covereage"></param>
		/// <param name="fire_Damage"></param>
		/// <param name="medical_Expense"></param>
		/// <param name="personal_Advertising_Injury"></param>
		/// <param name="general_Aggregate"></param>
		/// <param name="products_Operations"></param>
		/// <param name="other_Liability"></param>
		/// <param name="other_Liability_Coverage"></param>
		/// <param name="stop_Gap_Coverage"></param>
		/// <param name="auto_Coverage"></param>
		/// <param name="notes"></param>
		/// <param name="update_Date"></param>
		/// <param name="updated_By"></param>
		/// <returns></returns>
        public static int Insert(decimal fK_COIs, string insurance_Company, string policy_Number, DateTime issue_Date, DateTime effective_Date, DateTime expiration_Date, DateTime cancellation_Date, string commercial_Liability, string product_Liability, string occurrence_Liability, string stop_Gap_Endorsement, string auto_Liability, int gALimitAppliesTo, Nullable<decimal> occurrence_Covereage, Nullable<decimal> fire_Damage, Nullable<decimal> medical_Expense, Nullable<decimal> personal_Advertising_Injury, Nullable<decimal> general_Aggregate, Nullable<decimal> products_Operations,  Nullable<decimal> stop_Gap_Coverage, Nullable<decimal> auto_Coverage, string notes, DateTime update_Date, string updated_By, string other_Liability1, Nullable<decimal> other_Liability_Coverage1, string other_Liability2, Nullable<decimal> other_Liability_Coverage2)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("COI_General_PoliciesInsert");

			db.AddInParameter(dbCommand, "FK_COIs", DbType.Decimal, fK_COIs);
			db.AddInParameter(dbCommand, "Insurance_Company", DbType.String, insurance_Company);
			db.AddInParameter(dbCommand, "Policy_Number", DbType.String, policy_Number);
			db.AddInParameter(dbCommand, "Issue_Date", DbType.DateTime, issue_Date);
			db.AddInParameter(dbCommand, "Effective_Date", DbType.DateTime, effective_Date);
			db.AddInParameter(dbCommand, "Expiration_Date", DbType.DateTime, expiration_Date);
			db.AddInParameter(dbCommand, "Cancellation_Date", DbType.DateTime, cancellation_Date);
			db.AddInParameter(dbCommand, "Commercial_Liability", DbType.String, commercial_Liability);
			db.AddInParameter(dbCommand, "Product_Liability", DbType.String, product_Liability);
			db.AddInParameter(dbCommand, "Occurrence_Liability", DbType.String, occurrence_Liability);
			db.AddInParameter(dbCommand, "Stop_Gap_Endorsement", DbType.String, stop_Gap_Endorsement);
			db.AddInParameter(dbCommand, "Auto_Liability", DbType.String, auto_Liability);
            db.AddInParameter(dbCommand, "GALimitAppliesTo", DbType.Int32, gALimitAppliesTo);
			db.AddInParameter(dbCommand, "Occurrence_Covereage", DbType.Decimal, occurrence_Covereage);
			db.AddInParameter(dbCommand, "Fire_Damage", DbType.Decimal, fire_Damage);
			db.AddInParameter(dbCommand, "Medical_Expense", DbType.Decimal, medical_Expense);
			db.AddInParameter(dbCommand, "Personal_Advertising_Injury", DbType.Decimal, personal_Advertising_Injury);
			db.AddInParameter(dbCommand, "General_Aggregate", DbType.Decimal, general_Aggregate);
			db.AddInParameter(dbCommand, "Products_Operations", DbType.Decimal, products_Operations);
			db.AddInParameter(dbCommand, "Stop_Gap_Coverage", DbType.Decimal, stop_Gap_Coverage);
			db.AddInParameter(dbCommand, "Auto_Coverage", DbType.Decimal, auto_Coverage);
			db.AddInParameter(dbCommand, "Notes", DbType.String, notes);
			db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, update_Date);
			db.AddInParameter(dbCommand, "Updated_By", DbType.String, updated_By);
            db.AddInParameter(dbCommand, "Other_Liability1", DbType.String, other_Liability1);
            db.AddInParameter(dbCommand, "Other_Liability_Coverage1", DbType.Decimal, other_Liability_Coverage1);
            db.AddInParameter(dbCommand, "Other_Liability2", DbType.String, other_Liability2);
            db.AddInParameter(dbCommand, "Other_Liability_Coverage2", DbType.Decimal, other_Liability_Coverage2);
			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the COI_General_Policies table.
		/// <summary>
		/// <returns>DataSet</returns>
		public static DataSet Select(decimal pK_COI_General_Policies)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("COI_General_PoliciesSelect");

			db.AddInParameter(dbCommand, "PK_COI_General_Policies", DbType.Decimal, pK_COI_General_Policies);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects records from the COI_General_Policies table by a foreign key.
		/// <summary>
		/// <param name="fK_COIs"></param>
		/// <returns>DataSet</returns>
		public static DataSet SelectByFK_COIs(decimal fK_COIs)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("COI_General_PoliciesSelectByFK_COIs");

			db.AddInParameter(dbCommand, "FK_COIs", DbType.Decimal, fK_COIs);

			return db.ExecuteDataSet(dbCommand);
		}

        

		/// <summary>
		/// Updates a record in the COI_General_Policies table.
		/// <summary>
		/// <param name="pK_COI_General_Policies"></param>
		/// <param name="fK_COIs"></param>
		/// <param name="insurance_Company"></param>
		/// <param name="policy_Number"></param>
		/// <param name="issue_Date"></param>
		/// <param name="effective_Date"></param>
		/// <param name="expiration_Date"></param>
		/// <param name="cancellation_Date"></param>
		/// <param name="commercial_Liability"></param>
		/// <param name="product_Liability"></param>
		/// <param name="occurrence_Liability"></param>
		/// <param name="stop_Gap_Endorsement"></param>
		/// <param name="auto_Liability"></param>
		/// <param name="occurrence_Covereage"></param>
		/// <param name="fire_Damage"></param>
		/// <param name="medical_Expense"></param>
		/// <param name="personal_Advertising_Injury"></param>
		/// <param name="general_Aggregate"></param>
		/// <param name="products_Operations"></param>
		/// <param name="other_Liability"></param>
		/// <param name="other_Liability_Coverage"></param>
		/// <param name="stop_Gap_Coverage"></param>
		/// <param name="auto_Coverage"></param>
		/// <param name="notes"></param>
		/// <param name="update_Date"></param>
		/// <param name="updated_By"></param>
        public static void Update(decimal pK_COI_General_Policies, Nullable<decimal> fK_COIs, string insurance_Company, string policy_Number, DateTime issue_Date, DateTime effective_Date, DateTime expiration_Date, DateTime cancellation_Date, string commercial_Liability, string product_Liability, string occurrence_Liability, string stop_Gap_Endorsement, string auto_Liability, int gALimitAppliesTo, Nullable<decimal> occurrence_Covereage, Nullable<decimal> fire_Damage, Nullable<decimal> medical_Expense, Nullable<decimal> personal_Advertising_Injury, Nullable<decimal> general_Aggregate, Nullable<decimal> products_Operations, Nullable<decimal> stop_Gap_Coverage, Nullable<decimal> auto_Coverage, string notes, DateTime update_Date, string updated_By, string other_Liability1, Nullable<decimal> other_Liability_Coverage1, string other_Liability2, Nullable<decimal> other_Liability_Coverage2)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("COI_General_PoliciesUpdate");

			db.AddInParameter(dbCommand, "PK_COI_General_Policies", DbType.Decimal, pK_COI_General_Policies);
			db.AddInParameter(dbCommand, "FK_COIs", DbType.Decimal, fK_COIs);
			db.AddInParameter(dbCommand, "Insurance_Company", DbType.String, insurance_Company);
			db.AddInParameter(dbCommand, "Policy_Number", DbType.String, policy_Number);
			db.AddInParameter(dbCommand, "Issue_Date", DbType.DateTime, issue_Date);
			db.AddInParameter(dbCommand, "Effective_Date", DbType.DateTime, effective_Date);
			db.AddInParameter(dbCommand, "Expiration_Date", DbType.DateTime, expiration_Date);
			db.AddInParameter(dbCommand, "Cancellation_Date", DbType.DateTime, cancellation_Date);
			db.AddInParameter(dbCommand, "Commercial_Liability", DbType.String, commercial_Liability);
			db.AddInParameter(dbCommand, "Product_Liability", DbType.String, product_Liability);
			db.AddInParameter(dbCommand, "Occurrence_Liability", DbType.String, occurrence_Liability);
			db.AddInParameter(dbCommand, "Stop_Gap_Endorsement", DbType.String, stop_Gap_Endorsement);
			db.AddInParameter(dbCommand, "Auto_Liability", DbType.String, auto_Liability);
            db.AddInParameter(dbCommand, "GALimitAppliesTo", DbType.Int32, gALimitAppliesTo);
			db.AddInParameter(dbCommand, "Occurrence_Covereage", DbType.Decimal, occurrence_Covereage);
			db.AddInParameter(dbCommand, "Fire_Damage", DbType.Decimal, fire_Damage);
			db.AddInParameter(dbCommand, "Medical_Expense", DbType.Decimal, medical_Expense);
			db.AddInParameter(dbCommand, "Personal_Advertising_Injury", DbType.Decimal, personal_Advertising_Injury);
			db.AddInParameter(dbCommand, "General_Aggregate", DbType.Decimal, general_Aggregate);
			db.AddInParameter(dbCommand, "Products_Operations", DbType.Decimal, products_Operations);
			db.AddInParameter(dbCommand, "Stop_Gap_Coverage", DbType.Decimal, stop_Gap_Coverage);
			db.AddInParameter(dbCommand, "Auto_Coverage", DbType.Decimal, auto_Coverage);
			db.AddInParameter(dbCommand, "Notes", DbType.String, notes);
			db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, update_Date);
			db.AddInParameter(dbCommand, "Updated_By", DbType.String, updated_By);
            db.AddInParameter(dbCommand, "Other_Liability1", DbType.String, other_Liability1);
            db.AddInParameter(dbCommand, "Other_Liability_Coverage1", DbType.Decimal, other_Liability_Coverage1);
            db.AddInParameter(dbCommand, "Other_Liability2", DbType.String, other_Liability2);
            db.AddInParameter(dbCommand, "Other_Liability_Coverage2", DbType.Decimal, other_Liability_Coverage2);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the COI_General_Policies table by a composite primary key.
		/// <summary>
		public static void Delete(decimal pK_COI_General_Policies)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("COI_General_PoliciesDelete");

			db.AddInParameter(dbCommand, "PK_COI_General_Policies", DbType.Decimal, pK_COI_General_Policies);

			db.ExecuteNonQuery(dbCommand);
		}

        

        /// <summary>
        /// Calls parameterized Insert method to Insert the record
        /// </summary>
        /// <returns>The primary key value for newly Inserted record</returns>
        public int Insert()
        {
           return Insert(_FK_COIs, _Insurance_Company, _Policy_Number, _Issue_Date, _Effective_Date, _Expiration_Date, 
                _Cancellation_Date, _Commercial_Liability, _Product_Liability, _Occurrence_Liability, _Stop_Gap_Endorsement, 
                _Auto_Liability, _GALimitAppliesTo, _Occurrence_Covereage, _Fire_Damage, _Medical_Expense, _Personal_Advertising_Injury, 
                _General_Aggregate, _Products_Operations, 
                _Stop_Gap_Coverage, _Auto_Coverage, _Notes, _Update_Date, _Updated_By, _Other_Liability1, _Other_Liability_Coverage1, _Other_Liability2, _Other_Liability_Coverage2);
        }

        /// <summary>
        /// Calls parameterized Update method to Update the record
        /// </summary>
        public void Update()
        {
            Update(_PK_COI_General_Policies, _FK_COIs, _Insurance_Company, _Policy_Number, _Issue_Date, _Effective_Date, _Expiration_Date,
                _Cancellation_Date, _Commercial_Liability, _Product_Liability, _Occurrence_Liability, _Stop_Gap_Endorsement,
                _Auto_Liability, _GALimitAppliesTo, _Occurrence_Covereage, _Fire_Damage, _Medical_Expense, _Personal_Advertising_Injury,
                _General_Aggregate, _Products_Operations, 
                _Stop_Gap_Coverage, _Auto_Coverage, _Notes, _Update_Date, _Updated_By, _Other_Liability1, _Other_Liability_Coverage1, _Other_Liability2, _Other_Liability_Coverage2);
        }

        /// <summary>
        /// Selects records by COI Foreign key and Compares the column values with 
        /// Risk profile using primary key in Risk profile table
        /// </summary>
        /// <param name="FK_COIs"></param>
        /// <param name="PK_COI_Risk_Profile"></param>
        /// <returns>DataSet</returns>
        public static DataSet SelectByRiskProfile(decimal FK_COIs,decimal PK_COI_Risk_Profile)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("COI_General_PoliciesSelectByRiskProfile");
            db.AddInParameter(dbCommand, "FK_COIs", DbType.Decimal, FK_COIs);
            db.AddInParameter(dbCommand, "PK_COI_Risk_Profile", DbType.Decimal, PK_COI_Risk_Profile);
            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Returns all records that matches the search crieteria
        /// </summary>
        /// <param name="fk_COIs"></param>
        /// <param name="company"></param>
        /// <returns>DataSet</returns>
        public static DataSet Search(int fk_COIs, string company)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("COI_General_PoliciesSearch");

            db.AddInParameter(dbCommand, "FK_COIs", DbType.Int32, fk_COIs);
            db.AddInParameter(dbCommand, "Company", DbType.String, company);
         
            return db.ExecuteDataSet(dbCommand);
        }
        /// <summary>
        /// Selects the record having properties with limits and risks
        /// </summary>
        /// <param name="FK_COIs">Perticular COI for which to find the records</param>
        /// <param name="FK_Table_Name">Property Policy for which to find the records,set 0 for all properties.</param>
        /// <returns></returns>
        public static DataSet SelectWithRiskInfo(decimal fK_Table_Name, string table_Name)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("COI_GeneralLocationsSelectWithRiskInfo");
            db.AddInParameter(dbCommand, "FK_Table_Name", DbType.Decimal, fK_Table_Name);
            db.AddInParameter(dbCommand, "Table_Name", DbType.String, table_Name);
            return db.ExecuteDataSet(dbCommand);
        }
        #endregion
    }
}
