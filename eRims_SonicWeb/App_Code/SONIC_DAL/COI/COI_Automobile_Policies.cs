using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for COI_Automobile_Policies table.
	/// </summary>
	public sealed class COI_Automobile_Policies
    {
        #region Fields

        private decimal _PK_COI_Automobile_Policies;
        private decimal _FK_COIs;
        private string _Insurance_Company;
        private string _Policy_Number;
        private DateTime _Issue_Date;
        private DateTime _Effective_Date;
        private DateTime _Expiration_Date;
        private DateTime _Cancellation_Date;
        private string _Any_Auto;
        private string _All_Owned_Vehicles;
        private string _Scheduled_Autos;
        private string _Hired_Autos;
        private string _Non_Owned_Autos;
        private string _Other_Coverage;
        private Nullable<decimal> _Combined_Single_Limit;
        private Nullable<decimal> _Bodily_Injury_Person;
        private Nullable<decimal> _Bodily_Injury_Accident;
        private Nullable<decimal> _Property_Damage;
        private string _Notes;
        private DateTime _Update_Date;
        private string _Updated_By;
        private Nullable<decimal> _Physical_Damage_Comprehensive;
        private Nullable<decimal> _Physical_Damage_Collision;
        private string _Other_Liability1;
        private Nullable<decimal> _Other_Liability_Coverage1;
        private string _Other_Liability2;
        private Nullable<decimal> _Other_Liability_Coverage2;
        #endregion


        #region Properties


        /// <summary> 
        /// Gets or sets the PK_COI_Automobile_Policies value.
        /// </summary>
        public decimal PK_COI_Automobile_Policies
        {
            get { return _PK_COI_Automobile_Policies; }
            set { _PK_COI_Automobile_Policies = value; }
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
        /// Gets or sets the Any_Auto value.
        /// </summary>
        public string Any_Auto
        {
            get { return _Any_Auto; }
            set { _Any_Auto = value; }
        }


        /// <summary> 
        /// Gets or sets the All_Owned_Vehicles value.
        /// </summary>
        public string All_Owned_Vehicles
        {
            get { return _All_Owned_Vehicles; }
            set { _All_Owned_Vehicles = value; }
        }


        /// <summary> 
        /// Gets or sets the Scheduled_Autos value.
        /// </summary>
        public string Scheduled_Autos
        {
            get { return _Scheduled_Autos; }
            set { _Scheduled_Autos = value; }
        }


        /// <summary> 
        /// Gets or sets the Hired_Autos value.
        /// </summary>
        public string Hired_Autos
        {
            get { return _Hired_Autos; }
            set { _Hired_Autos = value; }
        }


        /// <summary> 
        /// Gets or sets the Non_Owned_Autos value.
        /// </summary>
        public string Non_Owned_Autos
        {
            get { return _Non_Owned_Autos; }
            set { _Non_Owned_Autos = value; }
        }


        /// <summary> 
        /// Gets or sets the Other_Coverage value.
        /// </summary>
        public string Other_Coverage
        {
            get { return _Other_Coverage; }
            set { _Other_Coverage = value; }
        }


        /// <summary> 
        /// Gets or sets the Combined_Single_Limit value.
        /// </summary>
        public Nullable<decimal> Combined_Single_Limit
        {
            get { return _Combined_Single_Limit; }
            set { _Combined_Single_Limit = value; }
        }


        /// <summary> 
        /// Gets or sets the Bodily_Injury_Person value.
        /// </summary>
        public Nullable<decimal> Bodily_Injury_Person
        {
            get { return _Bodily_Injury_Person; }
            set { _Bodily_Injury_Person = value; }
        }


        /// <summary> 
        /// Gets or sets the Bodily_Injury_Accident value.
        /// </summary>
        public Nullable<decimal> Bodily_Injury_Accident
        {
            get { return _Bodily_Injury_Accident; }
            set { _Bodily_Injury_Accident = value; }
        }


        /// <summary> 
        /// Gets or sets the Property_Damage value.
        /// </summary>
        public Nullable<decimal> Property_Damage
        {
            get { return _Property_Damage; }
            set { _Property_Damage = value; }
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
        /// <summary>  /// Gets or sets the Physical_Damage_Comprehensive value. /// </summary> 
        public Nullable<decimal> Physical_Damage_Comprehensive { get { return _Physical_Damage_Comprehensive; } set { _Physical_Damage_Comprehensive = value; } }  
        /// <summary>  /// Gets or sets the Physical_Damage_Collision value. /// </summary> 
        public Nullable<decimal> Physical_Damage_Collision { get { return _Physical_Damage_Collision; } set { _Physical_Damage_Collision = value; } }  
        /// <summary>  /// Gets or sets the Other_Liability1 value. /// </summary> 
        public string Other_Liability1 { get { return _Other_Liability1; } set { _Other_Liability1 = value; } }
        /// <summary>  /// Gets or sets the Other_Liability_Coverage1 value. /// </summary> 
        public Nullable<decimal> Other_Liability_Coverage1 { get { return _Other_Liability_Coverage1; } set { _Other_Liability_Coverage1 = value; } }
        /// <summary>  /// Gets or sets the Other_Liability2 value. /// </summary> 
        public string Other_Liability2 { get { return _Other_Liability2; } set { _Other_Liability2 = value; } }
        /// <summary>  /// Gets or sets the Other_Liability_Coverage2 value. /// </summary> 
        public Nullable<decimal> Other_Liability_Coverage2 { get { return _Other_Liability_Coverage2; } set { _Other_Liability_Coverage2 = value; } }  


        #endregion


        #region Constructors

        /// <summary> 

        /// Initializes a new instance of the COI_Automobile_Policies class. with the default value.

        /// </summary>
        public COI_Automobile_Policies()
        {

            this._PK_COI_Automobile_Policies = -1;
            this._FK_COIs = -1;
            this._Insurance_Company = "";
            this._Policy_Number = "";
            this._Issue_Date = (DateTime) System.Data.SqlTypes.SqlDateTime.MinValue;;
            this._Effective_Date = (DateTime) System.Data.SqlTypes.SqlDateTime.MinValue;;
            this._Expiration_Date = (DateTime) System.Data.SqlTypes.SqlDateTime.MinValue;;
            this._Cancellation_Date = (DateTime) System.Data.SqlTypes.SqlDateTime.MinValue;;
            this._Any_Auto = "";
            this._All_Owned_Vehicles = "";
            this._Scheduled_Autos = "";
            this._Hired_Autos = "";
            this._Non_Owned_Autos = "";
            this._Other_Coverage = "";
            this._Combined_Single_Limit = null;
            this._Bodily_Injury_Person = null;
            this._Bodily_Injury_Accident = null;
            this._Property_Damage = null;
            this._Notes = "";
            this._Update_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue; 
            this._Updated_By = "";
            this.Physical_Damage_Collision = null;
            this.Physical_Damage_Comprehensive = null;
            this._Other_Liability1 = "";
            this._Other_Liability_Coverage1 = null;
            this._Other_Liability2 = "";
            this._Other_Liability_Coverage2 = null;
        }



        /// <summary> 

        /// Initializes a new instance of the COI_Automobile_Policies class for passed PrimaryKey with the values set from Database.

        /// </summary>
        public COI_Automobile_Policies(decimal PK)
        {
            DataTable dtCOI_Automobile_Policies = Select(PK).Tables[0];

            if (dtCOI_Automobile_Policies.Rows.Count > 0)
            {

                DataRow drCOI_Automobile_Policies = dtCOI_Automobile_Policies.Rows[0];

                this._PK_COI_Automobile_Policies = drCOI_Automobile_Policies["PK_COI_Automobile_Policies"] != DBNull.Value ? Convert.ToDecimal(drCOI_Automobile_Policies["PK_COI_Automobile_Policies"]) : 0;
                this._FK_COIs = drCOI_Automobile_Policies["FK_COIs"] != DBNull.Value ? Convert.ToDecimal(drCOI_Automobile_Policies["FK_COIs"]) : 0;
                this._Insurance_Company = Convert.ToString(drCOI_Automobile_Policies["Insurance_Company"]);
                this._Policy_Number = Convert.ToString(drCOI_Automobile_Policies["Policy_Number"]);
                this._Issue_Date = drCOI_Automobile_Policies["Issue_Date"] != DBNull.Value ? Convert.ToDateTime(drCOI_Automobile_Policies["Issue_Date"]) : (DateTime) System.Data.SqlTypes.SqlDateTime.MinValue;;
                this._Effective_Date = drCOI_Automobile_Policies["Effective_Date"] != DBNull.Value ? Convert.ToDateTime(drCOI_Automobile_Policies["Effective_Date"]) : (DateTime) System.Data.SqlTypes.SqlDateTime.MinValue;;
                this._Expiration_Date = drCOI_Automobile_Policies["Expiration_Date"] != DBNull.Value ? Convert.ToDateTime(drCOI_Automobile_Policies["Expiration_Date"]) : (DateTime) System.Data.SqlTypes.SqlDateTime.MinValue;;
                this._Cancellation_Date = drCOI_Automobile_Policies["Cancellation_Date"] != DBNull.Value ? Convert.ToDateTime(drCOI_Automobile_Policies["Cancellation_Date"]) : (DateTime) System.Data.SqlTypes.SqlDateTime.MinValue;;
                this._Any_Auto = Convert.ToString(drCOI_Automobile_Policies["Any_Auto"]);
                this._All_Owned_Vehicles = Convert.ToString(drCOI_Automobile_Policies["All_Owned_Vehicles"]);
                this._Scheduled_Autos = Convert.ToString(drCOI_Automobile_Policies["Scheduled_Autos"]);
                this._Hired_Autos = Convert.ToString(drCOI_Automobile_Policies["Hired_Autos"]);
                this._Non_Owned_Autos = Convert.ToString(drCOI_Automobile_Policies["Non_Owned_Autos"]);
                this._Other_Coverage = Convert.ToString(drCOI_Automobile_Policies["Other_Coverage"]);
                if (drCOI_Automobile_Policies["Combined_Single_Limit"] != DBNull.Value) this._Combined_Single_Limit = Convert.ToDecimal(drCOI_Automobile_Policies["Combined_Single_Limit"]);
                if (drCOI_Automobile_Policies["Bodily_Injury_Person"] != DBNull.Value) this._Bodily_Injury_Person = Convert.ToDecimal(drCOI_Automobile_Policies["Bodily_Injury_Person"]);
                if (drCOI_Automobile_Policies["Bodily_Injury_Accident"] != DBNull.Value) this._Bodily_Injury_Accident = Convert.ToDecimal(drCOI_Automobile_Policies["Bodily_Injury_Accident"]);
                if (drCOI_Automobile_Policies["Property_Damage"] != DBNull.Value) this._Property_Damage = Convert.ToDecimal(drCOI_Automobile_Policies["Property_Damage"]);
                this._Notes = Convert.ToString(drCOI_Automobile_Policies["Notes"]);
                this._Update_Date = drCOI_Automobile_Policies["Update_Date"] != DBNull.Value ? Convert.ToDateTime(drCOI_Automobile_Policies["Update_Date"]) : (DateTime) System.Data.SqlTypes.SqlDateTime.MinValue;;
                this._Updated_By = Convert.ToString(drCOI_Automobile_Policies["Updated_By"]);
                this._Physical_Damage_Collision = drCOI_Automobile_Policies["Physical_Damage_Collision"] != DBNull.Value ? Convert.ToDecimal(drCOI_Automobile_Policies["Physical_Damage_Collision"]) : 0;
                if (drCOI_Automobile_Policies["Physical_Damage_Comprehensive"] != DBNull.Value) this._Physical_Damage_Comprehensive = Convert.ToDecimal(drCOI_Automobile_Policies["Physical_Damage_Comprehensive"]);
                if (drCOI_Automobile_Policies["Physical_Damage_Collision"] != DBNull.Value) this._Physical_Damage_Collision = Convert.ToDecimal(drCOI_Automobile_Policies["Physical_Damage_Collision"]);
                this._Other_Liability1 = Convert.ToString(drCOI_Automobile_Policies["Other_Liability1"]);
                if (drCOI_Automobile_Policies["Other_Liability_Coverage1"] != DBNull.Value) this._Other_Liability_Coverage1 = Convert.ToDecimal(drCOI_Automobile_Policies["Other_Liability_Coverage1"]);
                this._Other_Liability2 = Convert.ToString(drCOI_Automobile_Policies["Other_Liability2"]);
                if (drCOI_Automobile_Policies["Other_Liability_Coverage2"] != DBNull.Value) this._Other_Liability_Coverage2 = Convert.ToDecimal(drCOI_Automobile_Policies["Other_Liability_Coverage2"]);
 
            }

            else
            {

                new COI_Automobile_Policies();
            }

        }



        #endregion

        #region "Methods"
        
        /// <summary>
		/// Inserts a record into the COI_Automobile_Policies table.
		/// <summary>
		/// <param name="fK_COIs"></param>
		/// <param name="insurance_Company"></param>
		/// <param name="policy_Number"></param>
		/// <param name="issue_Date"></param>
		/// <param name="effective_Date"></param>
		/// <param name="expiration_Date"></param>
		/// <param name="cancellation_Date"></param>
		/// <param name="any_Auto"></param>
		/// <param name="all_Owned_Vehicles"></param>
		/// <param name="scheduled_Autos"></param>
		/// <param name="hired_Autos"></param>
		/// <param name="non_Owned_Autos"></param>
		/// <param name="other_Coverage"></param>
		/// <param name="combined_Single_Limit"></param>
		/// <param name="bodily_Injury_Person"></param>
		/// <param name="bodily_Injury_Accident"></param>
		/// <param name="property_Damage"></param>
		/// <param name="notes"></param>
		/// <param name="update_Date"></param>
		/// <param name="updated_By"></param>
		/// <returns></returns>
        public static int Insert(decimal fK_COIs, string insurance_Company, string policy_Number, DateTime issue_Date, DateTime effective_Date, DateTime expiration_Date, DateTime cancellation_Date, string any_Auto, string all_Owned_Vehicles, string scheduled_Autos, string hired_Autos, string non_Owned_Autos, string other_Coverage, Nullable<decimal> combined_Single_Limit, Nullable<decimal> bodily_Injury_Person, Nullable<decimal> bodily_Injury_Accident, Nullable<decimal> property_Damage, string notes, DateTime update_Date, string updated_By, Nullable<decimal> physical_Damage_Comprehensive, Nullable<decimal> physical_Damage_Collision, string other_Liability1, Nullable<decimal> other_Liability_Coverage1, string other_Liability2, Nullable<decimal> other_Liability_Coverage2)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("COI_Automobile_PoliciesInsert");

			db.AddInParameter(dbCommand, "FK_COIs", DbType.Decimal, fK_COIs);
			db.AddInParameter(dbCommand, "Insurance_Company", DbType.String, insurance_Company);
			db.AddInParameter(dbCommand, "Policy_Number", DbType.String, policy_Number);
			db.AddInParameter(dbCommand, "Issue_Date", DbType.DateTime, issue_Date);
			db.AddInParameter(dbCommand, "Effective_Date", DbType.DateTime, effective_Date);
			db.AddInParameter(dbCommand, "Expiration_Date", DbType.DateTime, expiration_Date);
			db.AddInParameter(dbCommand, "Cancellation_Date", DbType.DateTime, cancellation_Date);
			db.AddInParameter(dbCommand, "Any_Auto", DbType.String, any_Auto);
			db.AddInParameter(dbCommand, "All_Owned_Vehicles", DbType.String, all_Owned_Vehicles);
			db.AddInParameter(dbCommand, "Scheduled_Autos", DbType.String, scheduled_Autos);
			db.AddInParameter(dbCommand, "Hired_Autos", DbType.String, hired_Autos);
			db.AddInParameter(dbCommand, "Non_Owned_Autos", DbType.String, non_Owned_Autos);
			db.AddInParameter(dbCommand, "Other_Coverage", DbType.String, other_Coverage);
			db.AddInParameter(dbCommand, "Combined_Single_Limit", DbType.Decimal, combined_Single_Limit);
			db.AddInParameter(dbCommand, "Bodily_Injury_Person", DbType.Decimal, bodily_Injury_Person);
			db.AddInParameter(dbCommand, "Bodily_Injury_Accident", DbType.Decimal, bodily_Injury_Accident);
			db.AddInParameter(dbCommand, "Property_Damage", DbType.Decimal, property_Damage);
			db.AddInParameter(dbCommand, "Notes", DbType.String, notes);
			db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, update_Date);
			db.AddInParameter(dbCommand, "Updated_By", DbType.String, updated_By);
            db.AddInParameter(dbCommand, "Physical_Damage_Comprehensive", DbType.Decimal, physical_Damage_Comprehensive);
            db.AddInParameter(dbCommand, "Physical_Damage_Collision", DbType.Decimal, physical_Damage_Collision);
            db.AddInParameter(dbCommand, "Other_Liability1", DbType.String, other_Liability1);
            db.AddInParameter(dbCommand, "Other_Liability_Coverage1", DbType.Decimal, other_Liability_Coverage1);
            db.AddInParameter(dbCommand, "Other_Liability2", DbType.String, other_Liability2);
            db.AddInParameter(dbCommand, "Other_Liability_Coverage2", DbType.Decimal, other_Liability_Coverage2);
			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the COI_Automobile_Policies table.
		/// <summary>
		/// <returns>DataSet</returns>
		public static DataSet Select(decimal pK_COI_Automobile_Policies)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("COI_Automobile_PoliciesSelect");

			db.AddInParameter(dbCommand, "PK_COI_Automobile_Policies", DbType.Decimal, pK_COI_Automobile_Policies);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects records from the COI_Automobile_Policies table by a foreign key.
		/// <summary>
		/// <param name="fK_COIs"></param>
		/// <returns>DataSet</returns>
		public static DataSet SelectByFK_COIs(decimal fK_COIs)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("COI_Automobile_PoliciesSelectByFK_COIs");

			db.AddInParameter(dbCommand, "FK_COIs", DbType.Decimal, fK_COIs);

			return db.ExecuteDataSet(dbCommand);
		}

        /// <summary>
		/// Updates a record in the COI_Automobile_Policies table.
		/// <summary>
		/// <param name="pK_COI_Automobile_Policies"></param>
		/// <param name="fK_COIs"></param>
		/// <param name="insurance_Company"></param>
		/// <param name="policy_Number"></param>
		/// <param name="issue_Date"></param>
		/// <param name="effective_Date"></param>
		/// <param name="expiration_Date"></param>
		/// <param name="cancellation_Date"></param>
		/// <param name="any_Auto"></param>
		/// <param name="all_Owned_Vehicles"></param>
		/// <param name="scheduled_Autos"></param>
		/// <param name="hired_Autos"></param>
		/// <param name="non_Owned_Autos"></param>
		/// <param name="other_Coverage"></param>
		/// <param name="combined_Single_Limit"></param>
		/// <param name="bodily_Injury_Person"></param>
		/// <param name="bodily_Injury_Accident"></param>
		/// <param name="property_Damage"></param>
		/// <param name="notes"></param>
		/// <param name="update_Date"></param>
		/// <param name="updated_By"></param>
        public static void Update(decimal pK_COI_Automobile_Policies, Nullable<decimal> fK_COIs, string insurance_Company, string policy_Number, DateTime issue_Date, DateTime effective_Date, DateTime expiration_Date, DateTime cancellation_Date, string any_Auto, string all_Owned_Vehicles, string scheduled_Autos, string hired_Autos, string non_Owned_Autos, string other_Coverage, Nullable<decimal> combined_Single_Limit, Nullable<decimal> bodily_Injury_Person, Nullable<decimal> bodily_Injury_Accident, Nullable<decimal> property_Damage, string notes, DateTime update_Date, string updated_By, Nullable<decimal> physical_Damage_Comprehensive, Nullable<decimal> physical_Damage_Collision, string other_Liability1, Nullable<decimal> other_Liability_Coverage1, string other_Liability2, Nullable<decimal> other_Liability_Coverage2)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("COI_Automobile_PoliciesUpdate");

			db.AddInParameter(dbCommand, "PK_COI_Automobile_Policies", DbType.Decimal, pK_COI_Automobile_Policies);
			db.AddInParameter(dbCommand, "FK_COIs", DbType.Decimal, fK_COIs);
			db.AddInParameter(dbCommand, "Insurance_Company", DbType.String, insurance_Company);
			db.AddInParameter(dbCommand, "Policy_Number", DbType.String, policy_Number);
			db.AddInParameter(dbCommand, "Issue_Date", DbType.DateTime, issue_Date);
			db.AddInParameter(dbCommand, "Effective_Date", DbType.DateTime, effective_Date);
			db.AddInParameter(dbCommand, "Expiration_Date", DbType.DateTime, expiration_Date);
			db.AddInParameter(dbCommand, "Cancellation_Date", DbType.DateTime, cancellation_Date);
			db.AddInParameter(dbCommand, "Any_Auto", DbType.String, any_Auto);
			db.AddInParameter(dbCommand, "All_Owned_Vehicles", DbType.String, all_Owned_Vehicles);
			db.AddInParameter(dbCommand, "Scheduled_Autos", DbType.String, scheduled_Autos);
			db.AddInParameter(dbCommand, "Hired_Autos", DbType.String, hired_Autos);
			db.AddInParameter(dbCommand, "Non_Owned_Autos", DbType.String, non_Owned_Autos);
			db.AddInParameter(dbCommand, "Other_Coverage", DbType.String, other_Coverage);
			db.AddInParameter(dbCommand, "Combined_Single_Limit", DbType.Decimal, combined_Single_Limit);
			db.AddInParameter(dbCommand, "Bodily_Injury_Person", DbType.Decimal, bodily_Injury_Person);
			db.AddInParameter(dbCommand, "Bodily_Injury_Accident", DbType.Decimal, bodily_Injury_Accident);
			db.AddInParameter(dbCommand, "Property_Damage", DbType.Decimal, property_Damage);
			db.AddInParameter(dbCommand, "Notes", DbType.String, notes);
			db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, update_Date);
			db.AddInParameter(dbCommand, "Updated_By", DbType.String, updated_By);
            db.AddInParameter(dbCommand, "Physical_Damage_Comprehensive", DbType.Decimal, physical_Damage_Comprehensive);
            db.AddInParameter(dbCommand, "Physical_Damage_Collision", DbType.Decimal, physical_Damage_Collision);
            db.AddInParameter(dbCommand, "Other_Liability1", DbType.String, other_Liability1);
            db.AddInParameter(dbCommand, "Other_Liability_Coverage1", DbType.Decimal, other_Liability_Coverage1);
            db.AddInParameter(dbCommand, "Other_Liability2", DbType.String, other_Liability2);
            db.AddInParameter(dbCommand, "Other_Liability_Coverage2", DbType.Decimal, other_Liability_Coverage2);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the COI_Automobile_Policies table by a composite primary key.
		/// <summary>
		public static void Delete(decimal pK_COI_Automobile_Policies)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("COI_Automobile_PoliciesDelete");

			db.AddInParameter(dbCommand, "PK_COI_Automobile_Policies", DbType.Decimal, pK_COI_Automobile_Policies);

			db.ExecuteNonQuery(dbCommand);
		}

        
        /// <summary>
        /// Calls parameterized Insert method to Insert the record
        /// </summary>
        /// <returns>The primary key value for newly Inserted record</returns>
        public int Insert()
        {
           return Insert(_FK_COIs, _Insurance_Company, _Policy_Number, _Issue_Date, _Effective_Date, _Expiration_Date, _Cancellation_Date, 
                _Any_Auto, _All_Owned_Vehicles, _Scheduled_Autos, _Hired_Autos, _Non_Owned_Autos, _Other_Coverage, _Combined_Single_Limit,
                _Bodily_Injury_Person, _Bodily_Injury_Accident, _Property_Damage, _Notes, _Update_Date, _Updated_By, _Physical_Damage_Comprehensive,
                _Physical_Damage_Collision,_Other_Liability1 , _Other_Liability_Coverage1 , _Other_Liability2 , _Other_Liability_Coverage2);
        }

        /// <summary>
        /// Calls parameterized Update method to Update the record
        /// </summary>
        public void Update()
        {
            Update(_PK_COI_Automobile_Policies, _FK_COIs, _Insurance_Company, _Policy_Number, _Issue_Date, _Effective_Date, _Expiration_Date, _Cancellation_Date,
                _Any_Auto, _All_Owned_Vehicles, _Scheduled_Autos, _Hired_Autos, _Non_Owned_Autos, _Other_Coverage, _Combined_Single_Limit,
                _Bodily_Injury_Person, _Bodily_Injury_Accident, _Property_Damage, _Notes, _Update_Date, _Updated_By, _Physical_Damage_Comprehensive,
                _Physical_Damage_Collision, _Other_Liability1, _Other_Liability_Coverage1, _Other_Liability2, _Other_Liability_Coverage2);
        }

        /// <summary>
        /// Selects records by COI Foreign key and Compares the column values with 
        /// Risk profile using primary key in Risk profile table
        /// </summary>
        /// <param name="FK_COIs"></param>
        /// <param name="PK_COI_Risk_Profile"></param>
        /// <returns>DataSet</returns>
        public static DataSet SelectByRiskProfile(decimal FK_COIs, decimal PK_COI_Risk_Profile)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("COI_Automobile_PoliciesSelectByRiskProfile");
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
            DbCommand dbCommand = db.GetStoredProcCommand("COI_Automobile_PoliciesSearch");

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
            DbCommand dbCommand = db.GetStoredProcCommand("COI_AutomobileLocationsSelectWithRiskInfo");
            db.AddInParameter(dbCommand, "FK_Table_Name", DbType.Decimal, fK_Table_Name);
            db.AddInParameter(dbCommand, "Table_Name", DbType.String, table_Name);
            return db.ExecuteDataSet(dbCommand);
        }
        #endregion
    }
        
}
