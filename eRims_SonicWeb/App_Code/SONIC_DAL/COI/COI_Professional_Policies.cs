using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for COI_Professional_Policies table.
	/// </summary>
	public sealed class COI_Professional_Policies
    {
        #region Fields

        private decimal _PK_COI_Professional_Policies;
        private decimal _FK_COIs;
        private string _Insurance_Company;
        private string _Policy_Number;
        private DateTime _Issue_Date;
        private DateTime _Effective_Date;
        private DateTime _Expiration_Date;
        private DateTime _Cancellation_Date;
        private Nullable<decimal> _Occurrence;
        private Nullable<decimal> _Aggregate;
        private string _Notes;
        private DateTime _Update_Date;
        private string _Updated_By;

        #endregion


        #region Properties

        /// <summary> 
        /// Gets or sets the PK_COI_Professional_Policies value.
        /// </summary>
        public decimal PK_COI_Professional_Policies
        {
            get { return _PK_COI_Professional_Policies; }
            set { _PK_COI_Professional_Policies = value; }
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
        /// Gets or sets the Occurrence value.
        /// </summary>
        public Nullable<decimal> Occurrence
        {
            get { return _Occurrence; }
            set { _Occurrence = value; }
        }


        /// <summary> 
        /// Gets or sets the Aggregate value.
        /// </summary>
        public Nullable<decimal> Aggregate
        {
            get { return _Aggregate; }
            set { _Aggregate = value; }
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

        /// Initializes a new instance of the COI_Professional_Policies class. with the default value.

        /// </summary>
        public COI_Professional_Policies()
        {

            this._PK_COI_Professional_Policies = -1;
            this._FK_COIs = -1;
            this._Insurance_Company = "";
            this._Policy_Number = "";
            this._Issue_Date = (DateTime) System.Data.SqlTypes.SqlDateTime.MinValue;;
            this._Effective_Date = (DateTime) System.Data.SqlTypes.SqlDateTime.MinValue;;
            this._Expiration_Date = (DateTime) System.Data.SqlTypes.SqlDateTime.MinValue;;
            this._Cancellation_Date = (DateTime) System.Data.SqlTypes.SqlDateTime.MinValue;;
            this._Occurrence = null;
            this._Aggregate = null;
            this._Notes = "";
            this._Update_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue; 
            this._Updated_By = "";

        }



        /// <summary> 

        /// Initializes a new instance of the COI_Professional_Policies class for passed PrimaryKey with the values set from Database.

        /// </summary>
        public COI_Professional_Policies(decimal PK)
        {
            DataTable dtCOI_Professional_Policies = Select(PK).Tables[0];

            if (dtCOI_Professional_Policies.Rows.Count > 0)
            {

                DataRow drCOI_Professional_Policies = dtCOI_Professional_Policies.Rows[0];

                this._PK_COI_Professional_Policies = drCOI_Professional_Policies["PK_COI_Professional_Policies"] != DBNull.Value ? Convert.ToDecimal(drCOI_Professional_Policies["PK_COI_Professional_Policies"]) : 0;
                this._FK_COIs = drCOI_Professional_Policies["FK_COIs"] != DBNull.Value ? Convert.ToDecimal(drCOI_Professional_Policies["FK_COIs"]) : 0;
                this._Insurance_Company = Convert.ToString(drCOI_Professional_Policies["Insurance_Company"]);
                this._Policy_Number = Convert.ToString(drCOI_Professional_Policies["Policy_Number"]);
                this._Issue_Date = drCOI_Professional_Policies["Issue_Date"] != DBNull.Value ? Convert.ToDateTime(drCOI_Professional_Policies["Issue_Date"]) : (DateTime) System.Data.SqlTypes.SqlDateTime.MinValue;;
                this._Effective_Date = drCOI_Professional_Policies["Effective_Date"] != DBNull.Value ? Convert.ToDateTime(drCOI_Professional_Policies["Effective_Date"]) : (DateTime) System.Data.SqlTypes.SqlDateTime.MinValue;;
                this._Expiration_Date = drCOI_Professional_Policies["Expiration_Date"] != DBNull.Value ? Convert.ToDateTime(drCOI_Professional_Policies["Expiration_Date"]) : (DateTime) System.Data.SqlTypes.SqlDateTime.MinValue;;
                this._Cancellation_Date = drCOI_Professional_Policies["Cancellation_Date"] != DBNull.Value ? Convert.ToDateTime(drCOI_Professional_Policies["Cancellation_Date"]) : (DateTime) System.Data.SqlTypes.SqlDateTime.MinValue;;
                if (drCOI_Professional_Policies["Occurrence"] != DBNull.Value) this._Occurrence = Convert.ToDecimal(drCOI_Professional_Policies["Occurrence"]);
                if (drCOI_Professional_Policies["Aggregate"] != DBNull.Value) this._Aggregate = Convert.ToDecimal(drCOI_Professional_Policies["Aggregate"]);
                this._Notes = Convert.ToString(drCOI_Professional_Policies["Notes"]);
                this._Update_Date = drCOI_Professional_Policies["Update_Date"] != DBNull.Value ? Convert.ToDateTime(drCOI_Professional_Policies["Update_Date"]) : (DateTime) System.Data.SqlTypes.SqlDateTime.MinValue;;
                this._Updated_By = Convert.ToString(drCOI_Professional_Policies["Updated_By"]);

            }

            else
            {

                new COI_Professional_Policies();
            }

        }



        #endregion

        #region "Methods"

        /// <summary>
		/// Inserts a record into the COI_Professional_Policies table.
		/// <summary>
		/// <param name="fK_COIs"></param>
		/// <param name="insurance_Company"></param>
		/// <param name="policy_Number"></param>
		/// <param name="issue_Date"></param>
		/// <param name="effective_Date"></param>
		/// <param name="expiration_Date"></param>
		/// <param name="cancellation_Date"></param>
		/// <param name="occurrence"></param>
		/// <param name="aggregate"></param>
		/// <param name="notes"></param>
		/// <param name="update_Date"></param>
		/// <param name="updated_By"></param>
		/// <returns></returns>
        public static int Insert(decimal fK_COIs, string insurance_Company, string policy_Number, DateTime issue_Date, DateTime effective_Date, DateTime expiration_Date, DateTime cancellation_Date, Nullable<decimal> occurrence, Nullable<decimal> aggregate, string notes, DateTime update_Date, string updated_By)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("COI_Professional_PoliciesInsert");

			db.AddInParameter(dbCommand, "FK_COIs", DbType.Decimal, fK_COIs);
			db.AddInParameter(dbCommand, "Insurance_Company", DbType.String, insurance_Company);
			db.AddInParameter(dbCommand, "Policy_Number", DbType.String, policy_Number);
			db.AddInParameter(dbCommand, "Issue_Date", DbType.DateTime, issue_Date);
			db.AddInParameter(dbCommand, "Effective_Date", DbType.DateTime, effective_Date);
			db.AddInParameter(dbCommand, "Expiration_Date", DbType.DateTime, expiration_Date);
			db.AddInParameter(dbCommand, "Cancellation_Date", DbType.DateTime, cancellation_Date);
			db.AddInParameter(dbCommand, "Occurrence", DbType.Decimal, occurrence);
			db.AddInParameter(dbCommand, "Aggregate", DbType.Decimal, aggregate);
			db.AddInParameter(dbCommand, "Notes", DbType.String, notes);
			db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, update_Date);
			db.AddInParameter(dbCommand, "Updated_By", DbType.String, updated_By);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the COI_Professional_Policies table.
		/// <summary>
		/// <returns>DataSet</returns>
		public static DataSet Select(decimal pK_COI_Professional_Policies)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("COI_Professional_PoliciesSelect");

			db.AddInParameter(dbCommand, "PK_COI_Professional_Policies", DbType.Decimal, pK_COI_Professional_Policies);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects records from the COI_Professional_Policies table by a foreign key.
		/// <summary>
		/// <param name="fK_COIs"></param>
		/// <returns>DataSet</returns>
		public static DataSet SelectByFK_COIs(decimal fK_COIs)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("COI_Professional_PoliciesSelectByFK_COIs");

			db.AddInParameter(dbCommand, "FK_COIs", DbType.Decimal, fK_COIs);

			return db.ExecuteDataSet(dbCommand);
		}

        

		/// <summary>
		/// Updates a record in the COI_Professional_Policies table.
		/// <summary>
		/// <param name="pK_COI_Professional_Policies"></param>
		/// <param name="fK_COIs"></param>
		/// <param name="insurance_Company"></param>
		/// <param name="policy_Number"></param>
		/// <param name="issue_Date"></param>
		/// <param name="effective_Date"></param>
		/// <param name="expiration_Date"></param>
		/// <param name="cancellation_Date"></param>
		/// <param name="occurrence"></param>
		/// <param name="aggregate"></param>
		/// <param name="notes"></param>
		/// <param name="update_Date"></param>
		/// <param name="updated_By"></param>
        public static void Update(decimal pK_COI_Professional_Policies, Nullable<decimal> fK_COIs, string insurance_Company, string policy_Number, DateTime issue_Date, DateTime effective_Date, DateTime expiration_Date, DateTime cancellation_Date, Nullable<decimal> occurrence, Nullable<decimal> aggregate, string notes, DateTime update_Date, string updated_By)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("COI_Professional_PoliciesUpdate");

			db.AddInParameter(dbCommand, "PK_COI_Professional_Policies", DbType.Decimal, pK_COI_Professional_Policies);
			db.AddInParameter(dbCommand, "FK_COIs", DbType.Decimal, fK_COIs);
			db.AddInParameter(dbCommand, "Insurance_Company", DbType.String, insurance_Company);
			db.AddInParameter(dbCommand, "Policy_Number", DbType.String, policy_Number);
			db.AddInParameter(dbCommand, "Issue_Date", DbType.DateTime, issue_Date);
			db.AddInParameter(dbCommand, "Effective_Date", DbType.DateTime, effective_Date);
			db.AddInParameter(dbCommand, "Expiration_Date", DbType.DateTime, expiration_Date);
			db.AddInParameter(dbCommand, "Cancellation_Date", DbType.DateTime, cancellation_Date);
			db.AddInParameter(dbCommand, "Occurrence", DbType.Decimal, occurrence);
			db.AddInParameter(dbCommand, "Aggregate", DbType.Decimal, aggregate);
			db.AddInParameter(dbCommand, "Notes", DbType.String, notes);
			db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, update_Date);
			db.AddInParameter(dbCommand, "Updated_By", DbType.String, updated_By);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the COI_Professional_Policies table by a composite primary key.
		/// <summary>
		public static void Delete(decimal pK_COI_Professional_Policies)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("COI_Professional_PoliciesDelete");

			db.AddInParameter(dbCommand, "PK_COI_Professional_Policies", DbType.Decimal, pK_COI_Professional_Policies);

			db.ExecuteNonQuery(dbCommand);
		}

        

        /// <summary>
        /// Calls parameterized Insert method to Insert the record
        /// </summary>
        /// <returns>The primary key value for newly Inserted record</returns>
        public int Insert()
        {
           return Insert(_FK_COIs, _Insurance_Company, _Policy_Number, _Issue_Date, _Effective_Date, _Expiration_Date, _Cancellation_Date, 
               _Occurrence, _Aggregate, _Notes, _Update_Date, _Updated_By);
        }

        /// <summary>
        /// Calls parameterized Update method to Update the record
        /// </summary>
        public void Update()
        {
            Update(_PK_COI_Professional_Policies, _FK_COIs, _Insurance_Company, _Policy_Number, _Issue_Date, _Effective_Date, _Expiration_Date, _Cancellation_Date,
               _Occurrence, _Aggregate, _Notes, _Update_Date, _Updated_By);
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
            DbCommand dbCommand = db.GetStoredProcCommand("COI_Professional_PoliciesSelectByRiskProfile");
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
            DbCommand dbCommand = db.GetStoredProcCommand("COI_Professional_PoliciesSearch");

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
            DbCommand dbCommand = db.GetStoredProcCommand("COI_ProfessionalLocationsSelectWithRiskInfo");
            db.AddInParameter(dbCommand, "FK_Table_Name", DbType.Decimal, fK_Table_Name);
            db.AddInParameter(dbCommand, "Table_Name", DbType.String, table_Name);
            return db.ExecuteDataSet(dbCommand);
        }
        #endregion
    }
}
