using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for COI_Property_Policies table.
	/// </summary>
	public sealed class COI_Property_Policies
    {
        #region Fields


        private decimal _PK_COI_Property_Policies;
        private decimal _FK_COIs;
        private string _Insurance_Company;
        private string _Policy_Number;
        private DateTime? _Issue_Date;
        private DateTime? _Effective_Date;
        private DateTime? _Expiration_Date;
        private DateTime? _Cancellation_Date;
        private string _Notes;
        private DateTime _Update_Date;
        private string _Updated_By;
        private Nullable<decimal> _COI_Property_Policies_Deductible;
        private Nullable<decimal> _COI_Property_Policies_Building_Occurrence;
        private string _Is_Boiler_And_Machinery_Required;
        private string _Is_Flood_Required;
        private string _Is_Earthquake_Required;
        private string _If_No_Boiler_And_Machinery_Required;
        private string _If_No_Flood_Required;
        private string _If_No_Earthquake_Required;
        #endregion


        #region Properties

        
        /// <summary> 
        /// Gets or sets the PK_COI_Property_Policies value.
        /// </summary>
        public decimal PK_COI_Property_Policies
        {
            get { return _PK_COI_Property_Policies; }
            set { _PK_COI_Property_Policies = value; }
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
        public DateTime? Issue_Date
        {
            get { return _Issue_Date; }
            set { _Issue_Date = value; }
        }


        /// <summary> 
        /// Gets or sets the Effective_Date value.
        /// </summary>
        public DateTime? Effective_Date
        {
            get { return _Effective_Date; }
            set { _Effective_Date = value; }
        }


        /// <summary> 
        /// Gets or sets the Expiration_Date value.
        /// </summary>
        public DateTime? Expiration_Date
        {
            get { return _Expiration_Date; }
            set { _Expiration_Date = value; }
        }


        /// <summary> 
        /// Gets or sets the Cancellation_Date value.
        /// </summary>
        public DateTime? Cancellation_Date
        {
            get { return _Cancellation_Date; }
            set { _Cancellation_Date = value; }
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


        /// <summary> 
        /// Gets or sets the Property_Building_Occurrence value.
        /// </summary>
        public Nullable<decimal> COI_Property_Policies_Building_Occurrence
        {
            get { return _COI_Property_Policies_Building_Occurrence; }
            set { _COI_Property_Policies_Building_Occurrence = value; }
        }

        /// <summary> 
        /// Gets or sets the Property_Building_Occurrence value.
        /// </summary>
        public Nullable<decimal> COI_Property_Policies_Deductible
        {
            get { return _COI_Property_Policies_Deductible; }
            set { _COI_Property_Policies_Deductible = value; }
        }
        /// <summary> 
        /// Gets or sets the Boiler_And_Machinery_Required value.
        /// </summary>
        public string Is_Boiler_And_Machinery_Required
        {
            get { return _Is_Boiler_And_Machinery_Required; }
            set { _Is_Boiler_And_Machinery_Required = value; }
        }

        /// <summary> 
        /// Gets or sets the Flood_Required value.
        /// </summary>
        public string Is_Flood_Required
        {
            get { return _Is_Flood_Required; }
            set { _Is_Flood_Required = value; }
        }

        /// <summary> 
        /// Gets or sets the Earthquake_Required value.
        /// </summary>
        public string Is_Earthquake_Required
        {
            get { return _Is_Earthquake_Required; }
            set { _Is_Earthquake_Required = value; }
        }

        /// <summary> 
        /// Gets or sets the Boiler_And_Machinery_Required value.
        /// </summary>
        public string If_No_Boiler_And_Machinery_Required
        {
            get { return _If_No_Boiler_And_Machinery_Required; }
            set { _If_No_Boiler_And_Machinery_Required = value; }
        }

        /// <summary> 
        /// Gets or sets the Flood_Required value.
        /// </summary>
        public string If_No_Flood_Required
        {
            get { return _If_No_Flood_Required; }
            set { _If_No_Flood_Required = value; }
        }

        /// <summary> 
        /// Gets or sets the Earthquake_Required value.
        /// </summary>
        public string If_No_Earthquake_Required
        {
            get { return _If_No_Earthquake_Required; }
            set { _If_No_Earthquake_Required = value; }
        }


        #endregion


        #region Constructors

        /// <summary> 

        /// Initializes a new instance of the COI_Property_Policies class. with the default value.

        /// </summary>
        public COI_Property_Policies()
        {

            this._PK_COI_Property_Policies = -1;
            this._FK_COIs = -1;
            this._Insurance_Company = "";
            this._Policy_Number = "";
            this._Issue_Date = null;
            this._Effective_Date = null;
            this._Expiration_Date = null;
            this._Cancellation_Date = null;
            this._Notes = "";
            this._Update_Date = (DateTime) System.Data.SqlTypes.SqlDateTime.MinValue;;
            this._Updated_By = "";
            this._COI_Property_Policies_Building_Occurrence = null;
            this._COI_Property_Policies_Deductible = null;
            this._Is_Boiler_And_Machinery_Required = "";
            this._Is_Flood_Required = "";
            this._Is_Earthquake_Required = "";
            this._If_No_Boiler_And_Machinery_Required = "";
            this._If_No_Flood_Required = "";
            this._If_No_Earthquake_Required = "";

        }



        /// <summary> 

        /// Initializes a new instance of the COI_Property_Policies class for passed PrimaryKey with the values set from Database.

        /// </summary>
        public COI_Property_Policies(decimal PK)
        {
            DataTable dtCOI_Property_Policies = Select(PK).Tables[0];

            if (dtCOI_Property_Policies.Rows.Count > 0)
            {

                DataRow drCOI_Property_Policies = dtCOI_Property_Policies.Rows[0];

                this._PK_COI_Property_Policies = drCOI_Property_Policies["PK_COI_Property_Policies"] != DBNull.Value ? Convert.ToDecimal(drCOI_Property_Policies["PK_COI_Property_Policies"]) : 0;
                this._FK_COIs = drCOI_Property_Policies["FK_COIs"] != DBNull.Value ? Convert.ToDecimal(drCOI_Property_Policies["FK_COIs"]) : 0;
                this._Insurance_Company = Convert.ToString(drCOI_Property_Policies["Insurance_Company"]);
                this._Policy_Number = Convert.ToString(drCOI_Property_Policies["Policy_Number"]);             
                if (drCOI_Property_Policies["Issue_Date"] == DBNull.Value)
                    this._Issue_Date = null;
                else
                    this._Issue_Date = (DateTime?)drCOI_Property_Policies["Issue_Date"];
                if (drCOI_Property_Policies["Effective_Date"] == DBNull.Value)
                    this._Effective_Date = null;
                else
                    this._Effective_Date = (DateTime?)drCOI_Property_Policies["Effective_Date"];
                if (drCOI_Property_Policies["Expiration_Date"] == DBNull.Value)
                    this._Expiration_Date = null;
                else
                    this._Expiration_Date = (DateTime?)drCOI_Property_Policies["Expiration_Date"];
                if (drCOI_Property_Policies["Cancellation_Date"] == DBNull.Value)
                    this._Cancellation_Date = null;
                else
                    this._Cancellation_Date = (DateTime?)drCOI_Property_Policies["Cancellation_Date"];               
                this._Notes = Convert.ToString(drCOI_Property_Policies["Notes"]);
                this._Update_Date = drCOI_Property_Policies["Update_Date"] != DBNull.Value ? Convert.ToDateTime(drCOI_Property_Policies["Update_Date"]) : (DateTime) System.Data.SqlTypes.SqlDateTime.MinValue;;
                this._Updated_By = Convert.ToString(drCOI_Property_Policies["Updated_By"]);
                if (drCOI_Property_Policies["COI_Property_Policies_Building_Occurrence"] != DBNull.Value) this._COI_Property_Policies_Building_Occurrence = Convert.ToDecimal(drCOI_Property_Policies["COI_Property_Policies_Building_Occurrence"]);
                if (drCOI_Property_Policies["COI_Property_Policies_Deductible"] != DBNull.Value) this._COI_Property_Policies_Deductible = Convert.ToDecimal(drCOI_Property_Policies["COI_Property_Policies_Deductible"]);


                this._Is_Boiler_And_Machinery_Required = Convert.ToString(drCOI_Property_Policies["Is_Boiler_And_Machinery_Required"]);
                this._Is_Flood_Required = Convert.ToString(drCOI_Property_Policies["Is_Flood_Required"]);
                this._Is_Earthquake_Required = Convert.ToString(drCOI_Property_Policies["Is_Earthquake_Required"]);
                this._If_No_Boiler_And_Machinery_Required = Convert.ToString(drCOI_Property_Policies["If_No_Boiler_And_Machinery_Required"]);
                this._If_No_Flood_Required = Convert.ToString(drCOI_Property_Policies["If_No_Flood_Required"]);
                this._If_No_Earthquake_Required = Convert.ToString(drCOI_Property_Policies["If_No_Earthquake_Required"]);
            }

            else
            {

                new COI_Property_Policies();
            }

        }



        #endregion

        #region "Methods"
        /// <summary>
		/// Inserts a record into the COI_Property_Policies table.
		/// <summary>
		/// <param name="fK_COIs"></param>
		/// <param name="insurance_Company"></param>
		/// <param name="policy_Number"></param>
		/// <param name="issue_Date"></param>
		/// <param name="effective_Date"></param>
		/// <param name="expiration_Date"></param>
		/// <param name="cancellation_Date"></param>
		/// <param name="notes"></param>
		/// <param name="update_Date"></param>
		/// <param name="updated_By"></param>
		/// <returns></returns>
        public static int Insert(decimal fK_COIs, string insurance_Company, string policy_Number, DateTime? issue_Date, DateTime? effective_Date, DateTime? expiration_Date, DateTime? cancellation_Date, string notes, DateTime update_Date, string updated_By, Nullable<decimal> cOI_Property_Policies_Deductible, Nullable<decimal> cOI_Property_Policies_Building_Occurrence, string is_Boiler_And_Machinery_Required, string is_Flood_Required, string is_Earthquake_Required, string if_No_Boiler_And_Machinery_Required, string if_No_Flood_Required, string if_No_Earthquake_Required)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("COI_Property_PoliciesInsert");

			db.AddInParameter(dbCommand, "FK_COIs", DbType.Decimal, fK_COIs);
			db.AddInParameter(dbCommand, "Insurance_Company", DbType.String, insurance_Company);
			db.AddInParameter(dbCommand, "Policy_Number", DbType.String, policy_Number);
			db.AddInParameter(dbCommand, "Issue_Date", DbType.DateTime, issue_Date);
			db.AddInParameter(dbCommand, "Effective_Date", DbType.DateTime, effective_Date);
			db.AddInParameter(dbCommand, "Expiration_Date", DbType.DateTime, expiration_Date);
			db.AddInParameter(dbCommand, "Cancellation_Date", DbType.DateTime, cancellation_Date);
			db.AddInParameter(dbCommand, "Notes", DbType.String, notes);
			db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, update_Date);
			db.AddInParameter(dbCommand, "Updated_By", DbType.String, updated_By);
            db.AddInParameter(dbCommand, "COI_Property_Policies_Deductible", DbType.Decimal, cOI_Property_Policies_Deductible);
            db.AddInParameter(dbCommand, "COI_Property_Policies_Building_Occurrence", DbType.Decimal, cOI_Property_Policies_Building_Occurrence);
            db.AddInParameter(dbCommand, "Is_Boiler_And_Machinery_Required", DbType.String, is_Boiler_And_Machinery_Required);
            db.AddInParameter(dbCommand, "Is_Flood_Required", DbType.String, is_Flood_Required);
            db.AddInParameter(dbCommand, "Is_Earthquake_Required", DbType.String, is_Earthquake_Required);
            db.AddInParameter(dbCommand, "If_No_Boiler_And_Machinery_Required", DbType.String, if_No_Boiler_And_Machinery_Required);
            db.AddInParameter(dbCommand, "If_No_Flood_Required", DbType.String, if_No_Flood_Required);
            db.AddInParameter(dbCommand, "If_No_Earthquake_Required", DbType.String, if_No_Earthquake_Required);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the COI_Property_Policies table.
		/// <summary>
		/// <returns>DataSet</returns>
		public static DataSet Select(decimal pK_COI_Property_Policies)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("COI_Property_PoliciesSelect");

			db.AddInParameter(dbCommand, "PK_COI_Property_Policies", DbType.Decimal, pK_COI_Property_Policies);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects records from the COI_Property_Policies table by a foreign key.
		/// <summary>
		/// <param name="fK_COIs"></param>
		/// <returns>DataSet</returns>
		public static DataSet SelectByFK_COIs(decimal fK_COIs)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("COI_Property_PoliciesSelectByFK_COIs");

			db.AddInParameter(dbCommand, "FK_COIs", DbType.Decimal, fK_COIs);

			return db.ExecuteDataSet(dbCommand);
		}

        
		/// <summary>
		/// Updates a record in the COI_Property_Policies table.
		/// <summary>
		/// <param name="pK_COI_Property_Policies"></param>
		/// <param name="fK_COIs"></param>
		/// <param name="insurance_Company"></param>
		/// <param name="policy_Number"></param>
		/// <param name="issue_Date"></param>
		/// <param name="effective_Date"></param>
		/// <param name="expiration_Date"></param>
		/// <param name="cancellation_Date"></param>
		/// <param name="notes"></param>
		/// <param name="update_Date"></param>
		/// <param name="updated_By"></param>
        public static void Update(decimal pK_COI_Property_Policies, decimal fK_COIs, string insurance_Company, string policy_Number, DateTime? issue_Date, DateTime? effective_Date, DateTime? expiration_Date, DateTime? cancellation_Date, string notes, DateTime update_Date, string updated_By, Nullable<decimal> cOI_Property_Policies_Deductible, Nullable<decimal> cOI_Property_Policies_Building_Occurrence, string is_Boiler_And_Machinery_Required, string is_Flood_Required, string is_Earthquake_Required, string if_No_Boiler_And_Machinery_Required, string if_No_Flood_Required, string if_No_Earthquake_Required)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("COI_Property_PoliciesUpdate");

			db.AddInParameter(dbCommand, "PK_COI_Property_Policies", DbType.Decimal, pK_COI_Property_Policies);
			db.AddInParameter(dbCommand, "FK_COIs", DbType.Decimal, fK_COIs);
			db.AddInParameter(dbCommand, "Insurance_Company", DbType.String, insurance_Company);
			db.AddInParameter(dbCommand, "Policy_Number", DbType.String, policy_Number);
			db.AddInParameter(dbCommand, "Issue_Date", DbType.DateTime, issue_Date);
			db.AddInParameter(dbCommand, "Effective_Date", DbType.DateTime, effective_Date);
			db.AddInParameter(dbCommand, "Expiration_Date", DbType.DateTime, expiration_Date);
			db.AddInParameter(dbCommand, "Cancellation_Date", DbType.DateTime, cancellation_Date);
			db.AddInParameter(dbCommand, "Notes", DbType.String, notes);
			db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, update_Date);
			db.AddInParameter(dbCommand, "Updated_By", DbType.String, updated_By);
            db.AddInParameter(dbCommand, "COI_Property_Policies_Deductible", DbType.Decimal, cOI_Property_Policies_Deductible);
            db.AddInParameter(dbCommand, "COI_Property_Policies_Building_Occurrence", DbType.Decimal, cOI_Property_Policies_Building_Occurrence);
            db.AddInParameter(dbCommand, "Is_Boiler_And_Machinery_Required", DbType.String, is_Boiler_And_Machinery_Required);
            db.AddInParameter(dbCommand, "Is_Flood_Required", DbType.String, is_Flood_Required);
            db.AddInParameter(dbCommand, "Is_Earthquake_Required", DbType.String, is_Earthquake_Required);
            db.AddInParameter(dbCommand, "If_No_Boiler_And_Machinery_Required", DbType.String, if_No_Boiler_And_Machinery_Required);
            db.AddInParameter(dbCommand, "If_No_Flood_Required", DbType.String, if_No_Flood_Required);
            db.AddInParameter(dbCommand, "If_No_Earthquake_Required", DbType.String, if_No_Earthquake_Required);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the COI_Property_Policies table by a composite primary key.
		/// <summary>
		public static void Delete(decimal pK_COI_Property_Policies)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("COI_Property_PoliciesDelete");

			db.AddInParameter(dbCommand, "PK_COI_Property_Policies", DbType.Decimal, pK_COI_Property_Policies);

			db.ExecuteNonQuery(dbCommand);
		}

        /// <summary>
        /// Calls parameterized Insert method to Insert the record
        /// </summary>
        /// <returns>The primary key value for newly Inserted record</returns>
        public int Insert()
        {
            return Insert(_FK_COIs, _Insurance_Company, _Policy_Number, _Issue_Date, _Effective_Date, _Expiration_Date, _Cancellation_Date, _Notes, _Update_Date, _Updated_By, _COI_Property_Policies_Deductible,_COI_Property_Policies_Building_Occurrence,_Is_Boiler_And_Machinery_Required,_Is_Flood_Required,_Is_Earthquake_Required,_If_No_Boiler_And_Machinery_Required,_If_No_Flood_Required,_If_No_Earthquake_Required);
        }

        /// <summary>
        /// Calls parameterized Update method to Update the record
        /// </summary>
        public void Update()
        {
            Update(_PK_COI_Property_Policies, _FK_COIs, _Insurance_Company, _Policy_Number, _Issue_Date, _Effective_Date, _Expiration_Date, _Cancellation_Date, _Notes, _Update_Date, _Updated_By, _COI_Property_Policies_Deductible, _COI_Property_Policies_Building_Occurrence, _Is_Boiler_And_Machinery_Required, _Is_Flood_Required, _Is_Earthquake_Required, _If_No_Boiler_And_Machinery_Required, _If_No_Flood_Required, _If_No_Earthquake_Required);
        }
        /// <summary>
        /// Selects the record having properties with limits and risks
        /// </summary>
        /// <param name="FK_COIs">Perticular COI for which to find the records</param>
        /// <param name="FK_COI_Property_Policies">Property Policy for which to find the records,set 0 for all properties.</param>
        /// <returns></returns>
        //public static DataSet SelectByRiskProfile(decimal FK_COIs, decimal FK_COI_Property_Policies)
        //{
        //    Database db = DatabaseFactory.CreateDatabase();
        //    DbCommand dbCommand = db.GetStoredProcCommand("COI_Property_PoliciesSelectByRiskProfile");
        //    db.AddInParameter(dbCommand, "FK_COIs", DbType.Decimal, FK_COIs);
        //    db.AddInParameter(dbCommand, "FK_COI_Property_Policies", DbType.Decimal, FK_COI_Property_Policies);
        //    return db.ExecuteDataSet(dbCommand);
        //}
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
            DbCommand dbCommand = db.GetStoredProcCommand("COI_Property_Policies_SelectBy_RiskProfile");
            db.AddInParameter(dbCommand, "FK_COIs", DbType.Decimal, FK_COIs);
            db.AddInParameter(dbCommand, "PK_COI_Risk_Profile", DbType.Decimal, PK_COI_Risk_Profile);
            return db.ExecuteDataSet(dbCommand);
        }
        #endregion
    }
}
