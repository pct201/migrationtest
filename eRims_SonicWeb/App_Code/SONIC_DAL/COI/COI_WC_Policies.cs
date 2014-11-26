using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for COI_WC_Policies table.
	/// </summary>
	public sealed class COI_WC_Policies
    {
        #region Fields


        private decimal _PK_COI_WC_Policies;
        private decimal _FK_COIs;
        private string _Insurance_Company;
        private string _Policy_Number;
        private DateTime _Issue_Date;
        private DateTime _Effective_Date;
        private DateTime _Expiration_Date;
        private DateTime _Cancellation_Date;
        private string _State_Limits;
        private string _Management;
        private string _Leased_Employees;
        private string _State_Funded;
        private string _Other;
        private Nullable<decimal> _Accident;
        private Nullable<decimal> _Disease_Each;
        private Nullable<decimal> _Disease_Limit;
        private string _Notes;
        private DateTime _Update_Date;
        private string _Updated_By;

        #endregion


        #region Properties


        /// <summary> 
        /// Gets or sets the PK_COI_WC_Policies value.
        /// </summary>
        public decimal PK_COI_WC_Policies
        {
            get { return _PK_COI_WC_Policies; }
            set { _PK_COI_WC_Policies = value; }
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
        /// Gets or sets the State_Limits value.
        /// </summary>
        public string State_Limits
        {
            get { return _State_Limits; }
            set { _State_Limits = value; }
        }


        /// <summary> 
        /// Gets or sets the Management value.
        /// </summary>
        public string Management
        {
            get { return _Management; }
            set { _Management = value; }
        }


        /// <summary> 
        /// Gets or sets the Leased_Employees value.
        /// </summary>
        public string Leased_Employees
        {
            get { return _Leased_Employees; }
            set { _Leased_Employees = value; }
        }


        /// <summary> 
        /// Gets or sets the State_Funded value.
        /// </summary>
        public string State_Funded
        {
            get { return _State_Funded; }
            set { _State_Funded = value; }
        }


        /// <summary> 
        /// Gets or sets the Other value.
        /// </summary>
        public string Other
        {
            get { return _Other; }
            set { _Other = value; }
        }


        /// <summary> 
        /// Gets or sets the Accident value.
        /// </summary>
        public Nullable<decimal> Accident
        {
            get { return _Accident; }
            set { _Accident = value; }
        }


        /// <summary> 
        /// Gets or sets the Disease_Each value.
        /// </summary>
        public Nullable<decimal> Disease_Each
        {
            get { return _Disease_Each; }
            set { _Disease_Each = value; }
        }


        /// <summary> 
        /// Gets or sets the Disease_Limit value.
        /// </summary>
        public Nullable<decimal> Disease_Limit
        {
            get { return _Disease_Limit; }
            set { _Disease_Limit = value; }
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



        #endregion


        #region Constructors

        /// <summary> 

        /// Initializes a new instance of the COI_WC_Policies class. with the default value.

        /// </summary>
        public COI_WC_Policies()
        {

            this._PK_COI_WC_Policies = -1;
            this._FK_COIs = -1;
            this._Insurance_Company = "";
            this._Policy_Number = "";
            this._Issue_Date = (DateTime) System.Data.SqlTypes.SqlDateTime.MinValue;;
            this._Effective_Date = (DateTime) System.Data.SqlTypes.SqlDateTime.MinValue;;
            this._Expiration_Date = (DateTime) System.Data.SqlTypes.SqlDateTime.MinValue;;
            this._Cancellation_Date = (DateTime) System.Data.SqlTypes.SqlDateTime.MinValue;;
            this._State_Limits = "";
            this._Management = "";
            this._Leased_Employees = "";
            this._State_Funded = "";
            this._Other = "";
            this._Accident = null;
            this._Disease_Each = null;
            this._Disease_Limit = null;
            this._Notes = "";
            this._Update_Date = (DateTime) System.Data.SqlTypes.SqlDateTime.MinValue;;
            this._Updated_By = "";

        }



        /// <summary> 

        /// Initializes a new instance of the COI_WC_Policies class for passed PrimaryKey with the values set from Database.

        /// </summary>
        public COI_WC_Policies(decimal PK)
        {
            DataTable dtCOI_WC_Policies = Select(PK).Tables[0];

            if (dtCOI_WC_Policies.Rows.Count > 0)
            {

                DataRow drCOI_WC_Policies = dtCOI_WC_Policies.Rows[0];

                this._PK_COI_WC_Policies = drCOI_WC_Policies["PK_COI_WC_Policies"] != DBNull.Value ? Convert.ToDecimal(drCOI_WC_Policies["PK_COI_WC_Policies"]) : 0;
                this._FK_COIs = drCOI_WC_Policies["FK_COIs"] != DBNull.Value ? Convert.ToDecimal(drCOI_WC_Policies["FK_COIs"]) : 0;
                this._Insurance_Company = Convert.ToString(drCOI_WC_Policies["Insurance_Company"]);
                this._Policy_Number = Convert.ToString(drCOI_WC_Policies["Policy_Number"]);
                this._Issue_Date = drCOI_WC_Policies["Issue_Date"] != DBNull.Value ? Convert.ToDateTime(drCOI_WC_Policies["Issue_Date"]) : (DateTime) System.Data.SqlTypes.SqlDateTime.MinValue;;
                this._Effective_Date = drCOI_WC_Policies["Effective_Date"] != DBNull.Value ? Convert.ToDateTime(drCOI_WC_Policies["Effective_Date"]) : (DateTime) System.Data.SqlTypes.SqlDateTime.MinValue;;
                this._Expiration_Date = drCOI_WC_Policies["Expiration_Date"] != DBNull.Value ? Convert.ToDateTime(drCOI_WC_Policies["Expiration_Date"]) : (DateTime) System.Data.SqlTypes.SqlDateTime.MinValue;;
                this._Cancellation_Date = drCOI_WC_Policies["Cancellation_Date"] != DBNull.Value ? Convert.ToDateTime(drCOI_WC_Policies["Cancellation_Date"]) : (DateTime) System.Data.SqlTypes.SqlDateTime.MinValue;;
                this._State_Limits = Convert.ToString(drCOI_WC_Policies["State_Limits"]);
                this._Management = Convert.ToString(drCOI_WC_Policies["Management"]);
                this._Leased_Employees = Convert.ToString(drCOI_WC_Policies["Leased_Employees"]);
                this._State_Funded = Convert.ToString(drCOI_WC_Policies["State_Funded"]);
                this._Other = Convert.ToString(drCOI_WC_Policies["Other"]);
                if (drCOI_WC_Policies["Accident"] != DBNull.Value) this._Accident = Convert.ToDecimal(drCOI_WC_Policies["Accident"]);
                if (drCOI_WC_Policies["Disease_Each"] != DBNull.Value) this._Disease_Each = Convert.ToDecimal(drCOI_WC_Policies["Disease_Each"]);
                if (drCOI_WC_Policies["Disease_Limit"] != DBNull.Value) this._Disease_Limit = Convert.ToDecimal(drCOI_WC_Policies["Disease_Limit"]);
                this._Notes = Convert.ToString(drCOI_WC_Policies["Notes"]);
                this._Update_Date = drCOI_WC_Policies["Update_Date"] != DBNull.Value ? Convert.ToDateTime(drCOI_WC_Policies["Update_Date"]) : (DateTime) System.Data.SqlTypes.SqlDateTime.MinValue;;
                this._Updated_By = Convert.ToString(drCOI_WC_Policies["Updated_By"]);

            }

            else
            {

                new COI_WC_Policies();
            }

        }



        #endregion


        #region "Methods"
        /// <summary>
		/// Inserts a record into the COI_WC_Policies table.
		/// <summary>
		/// <param name="fK_COIs"></param>
		/// <param name="insurance_Company"></param>
		/// <param name="policy_Number"></param>
		/// <param name="issue_Date"></param>
		/// <param name="effective_Date"></param>
		/// <param name="expiration_Date"></param>
		/// <param name="cancellation_Date"></param>
		/// <param name="state_Limits"></param>
		/// <param name="management"></param>
		/// <param name="leased_Employees"></param>
		/// <param name="state_Funded"></param>
		/// <param name="other"></param>
		/// <param name="accident"></param>
		/// <param name="disease_Each"></param>
		/// <param name="disease_Limit"></param>
		/// <param name="notes"></param>
		/// <param name="update_Date"></param>
		/// <param name="updated_By"></param>
		/// <returns></returns>
        public static int Insert(decimal fK_COIs, string insurance_Company, string policy_Number, DateTime issue_Date, DateTime effective_Date, DateTime expiration_Date, DateTime cancellation_Date, string state_Limits, string management, string leased_Employees, string state_Funded, string other, Nullable<decimal> accident, Nullable<decimal> disease_Each, Nullable<decimal> disease_Limit, string notes, DateTime update_Date, string updated_By)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("COI_WC_PoliciesInsert");

			db.AddInParameter(dbCommand, "FK_COIs", DbType.Decimal, fK_COIs);
			db.AddInParameter(dbCommand, "Insurance_Company", DbType.String, insurance_Company);
			db.AddInParameter(dbCommand, "Policy_Number", DbType.String, policy_Number);
			db.AddInParameter(dbCommand, "Issue_Date", DbType.DateTime, issue_Date);
			db.AddInParameter(dbCommand, "Effective_Date", DbType.DateTime, effective_Date);
			db.AddInParameter(dbCommand, "Expiration_Date", DbType.DateTime, expiration_Date);
			db.AddInParameter(dbCommand, "Cancellation_Date", DbType.DateTime, cancellation_Date);
			db.AddInParameter(dbCommand, "State_Limits", DbType.String, state_Limits);
			db.AddInParameter(dbCommand, "Management", DbType.String, management);
			db.AddInParameter(dbCommand, "Leased_Employees", DbType.String, leased_Employees);
			db.AddInParameter(dbCommand, "State_Funded", DbType.String, state_Funded);
			db.AddInParameter(dbCommand, "Other", DbType.String, other);
			db.AddInParameter(dbCommand, "Accident", DbType.Decimal, accident);
			db.AddInParameter(dbCommand, "Disease_Each", DbType.Decimal, disease_Each);
			db.AddInParameter(dbCommand, "Disease_Limit", DbType.Decimal, disease_Limit);
			db.AddInParameter(dbCommand, "Notes", DbType.String, notes);
			db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, update_Date);
			db.AddInParameter(dbCommand, "Updated_By", DbType.String, updated_By);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the COI_WC_Policies table.
		/// <summary>
		/// <returns>DataSet</returns>
		public static DataSet Select(decimal pK_COI_WC_Policies)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("COI_WC_PoliciesSelect");

			db.AddInParameter(dbCommand, "PK_COI_WC_Policies", DbType.Decimal, pK_COI_WC_Policies);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects records from the COI_WC_Policies table by a foreign key.
		/// <summary>
		/// <param name="fK_COIs"></param>
		/// <returns>DataSet</returns>
		public static DataSet SelectByFK_COIs(decimal fK_COIs)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("COI_WC_PoliciesSelectByFK_COIs");

			db.AddInParameter(dbCommand, "FK_COIs", DbType.Decimal, fK_COIs);

			return db.ExecuteDataSet(dbCommand);
		}

        

		/// <summary>
		/// Updates a record in the COI_WC_Policies table.
		/// <summary>
		/// <param name="pK_COI_WC_Policies"></param>
		/// <param name="fK_COIs"></param>
		/// <param name="insurance_Company"></param>
		/// <param name="policy_Number"></param>
		/// <param name="issue_Date"></param>
		/// <param name="effective_Date"></param>
		/// <param name="expiration_Date"></param>
		/// <param name="cancellation_Date"></param>
		/// <param name="state_Limits"></param>
		/// <param name="management"></param>
		/// <param name="leased_Employees"></param>
		/// <param name="state_Funded"></param>
		/// <param name="other"></param>
		/// <param name="accident"></param>
		/// <param name="disease_Each"></param>
		/// <param name="disease_Limit"></param>
		/// <param name="notes"></param>
		/// <param name="update_Date"></param>
		/// <param name="updated_By"></param>
        public static void Update(decimal pK_COI_WC_Policies, Nullable<decimal> fK_COIs, string insurance_Company, string policy_Number, DateTime issue_Date, DateTime effective_Date, DateTime expiration_Date, DateTime cancellation_Date, string state_Limits, string management, string leased_Employees, string state_Funded, string other, Nullable<decimal> accident, Nullable<decimal> disease_Each, Nullable<decimal> disease_Limit, string notes, DateTime update_Date, string updated_By)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("COI_WC_PoliciesUpdate");

			db.AddInParameter(dbCommand, "PK_COI_WC_Policies", DbType.Decimal, pK_COI_WC_Policies);
			db.AddInParameter(dbCommand, "FK_COIs", DbType.Decimal, fK_COIs);
			db.AddInParameter(dbCommand, "Insurance_Company", DbType.String, insurance_Company);
			db.AddInParameter(dbCommand, "Policy_Number", DbType.String, policy_Number);
			db.AddInParameter(dbCommand, "Issue_Date", DbType.DateTime, issue_Date);
			db.AddInParameter(dbCommand, "Effective_Date", DbType.DateTime, effective_Date);
			db.AddInParameter(dbCommand, "Expiration_Date", DbType.DateTime, expiration_Date);
			db.AddInParameter(dbCommand, "Cancellation_Date", DbType.DateTime, cancellation_Date);
			db.AddInParameter(dbCommand, "State_Limits", DbType.String, state_Limits);
			db.AddInParameter(dbCommand, "Management", DbType.String, management);
			db.AddInParameter(dbCommand, "Leased_Employees", DbType.String, leased_Employees);
			db.AddInParameter(dbCommand, "State_Funded", DbType.String, state_Funded);
			db.AddInParameter(dbCommand, "Other", DbType.String, other);
			db.AddInParameter(dbCommand, "Accident", DbType.Decimal, accident);
			db.AddInParameter(dbCommand, "Disease_Each", DbType.Decimal, disease_Each);
			db.AddInParameter(dbCommand, "Disease_Limit", DbType.Decimal, disease_Limit);
			db.AddInParameter(dbCommand, "Notes", DbType.String, notes);
			db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, update_Date);
			db.AddInParameter(dbCommand, "Updated_By", DbType.String, updated_By);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the COI_WC_Policies table by a composite primary key.
		/// <summary>
		public static void Delete(decimal pK_COI_WC_Policies)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("COI_WC_PoliciesDelete");

			db.AddInParameter(dbCommand, "PK_COI_WC_Policies", DbType.Decimal, pK_COI_WC_Policies);

			db.ExecuteNonQuery(dbCommand);
		}

        

        /// <summary>
        /// Calls parameterized Insert method to Insert the record
        /// </summary>
        /// <returns>The primary key value for newly Inserted record</returns>
        public int Insert()
        {
            return Insert(_FK_COIs, _Insurance_Company, _Policy_Number, _Issue_Date, _Effective_Date, _Expiration_Date, _Cancellation_Date, _State_Limits, _Management, _Leased_Employees, _State_Funded, _Other, _Accident, _Disease_Each, _Disease_Limit, _Notes, _Update_Date, _Updated_By);
        }

        /// <summary>
        /// Calls parameterized Update method to Update the record
        /// </summary>
        public void Update()
        {
            Update(_PK_COI_WC_Policies, _FK_COIs, _Insurance_Company, _Policy_Number, _Issue_Date, _Effective_Date, _Expiration_Date, _Cancellation_Date, _State_Limits, _Management, _Leased_Employees, _State_Funded, _Other, _Accident, _Disease_Each, _Disease_Limit, _Notes, _Update_Date, _Updated_By);
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
            DbCommand dbCommand = db.GetStoredProcCommand("COI_WC_PoliciesSelectByRiskProfile");
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
            DbCommand dbCommand = db.GetStoredProcCommand("COI_WC_PoliciesSearch");

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
            DbCommand dbCommand = db.GetStoredProcCommand("COI_WorkersCompLocationsSelectWithRiskInfo");
            db.AddInParameter(dbCommand, "FK_Table_Name", DbType.Decimal, fK_Table_Name);
            db.AddInParameter(dbCommand, "Table_Name", DbType.String, table_Name);
            return db.ExecuteDataSet(dbCommand);
        }
        #endregion
    }
}
