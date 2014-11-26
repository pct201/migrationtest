using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace BAL
{
	/// <summary>
	/// Data access class for table Sedgwick_Claim_Group
	/// </summary>
	public sealed class Sedgwick_Claim_Group
	{

		#region Private variables used to hold the property values

		private decimal? _PK_Sedgwick_Claim_Group;
		private decimal? _FK_LU_Sedgwick_Field_Office;
		private int? _Year;
		private int? _Quarter;
		private decimal? _FK_Workers_Comp_Claims;
		private string _Review_Complete;
		private decimal? _Total_of_Average_Numeric_Scores;
		private string _Updated_By;
		private DateTime? _Update_Date;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_Sedgwick_Claim_Group value.
		/// </summary>
		public decimal? PK_Sedgwick_Claim_Group
		{
			get { return _PK_Sedgwick_Claim_Group; }
			set { _PK_Sedgwick_Claim_Group = value; }
		}

		/// <summary>
		/// Gets or sets the FK_LU_Sedgwick_Field_Office value.
		/// </summary>
		public decimal? FK_LU_Sedgwick_Field_Office
		{
			get { return _FK_LU_Sedgwick_Field_Office; }
			set { _FK_LU_Sedgwick_Field_Office = value; }
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
		/// Gets or sets the Quarter value.
		/// </summary>
		public int? Quarter
		{
			get { return _Quarter; }
			set { _Quarter = value; }
		}

		/// <summary>
		/// Gets or sets the FK_Workers_Comp_Claims value.
		/// </summary>
		public decimal? FK_Workers_Comp_Claims
		{
			get { return _FK_Workers_Comp_Claims; }
			set { _FK_Workers_Comp_Claims = value; }
		}

		/// <summary>
		/// Gets or sets the Review_Complete value.
		/// </summary>
		public string Review_Complete
		{
			get { return _Review_Complete; }
			set { _Review_Complete = value; }
		}

		/// <summary>
		/// Gets or sets the Total_of_Average_Numeric_Scores value.
		/// </summary>
		public decimal? Total_of_Average_Numeric_Scores
		{
			get { return _Total_of_Average_Numeric_Scores; }
			set { _Total_of_Average_Numeric_Scores = value; }
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
		/// Initializes a new instance of the Sedgwick_Claim_Group class with default value.
		/// </summary>
		public Sedgwick_Claim_Group() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the Sedgwick_Claim_Group class based on Primary Key.
		/// </summary>
		public Sedgwick_Claim_Group(decimal pK_Sedgwick_Claim_Group) 
		{
			DataTable dtSedgwick_Claim_Group = Select(pK_Sedgwick_Claim_Group).Tables[0];

			if (dtSedgwick_Claim_Group.Rows.Count == 1)
			{
				 SetValue(dtSedgwick_Claim_Group.Rows[0]);

			}

		}


		/// <summary>
		/// Initializes a new instance of the Sedgwick_Claim_Group class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drSedgwick_Claim_Group) 
		{
				if (drSedgwick_Claim_Group["PK_Sedgwick_Claim_Group"] == DBNull.Value)
					this._PK_Sedgwick_Claim_Group = null;
				else
					this._PK_Sedgwick_Claim_Group = (decimal?)drSedgwick_Claim_Group["PK_Sedgwick_Claim_Group"];

				if (drSedgwick_Claim_Group["FK_LU_Sedgwick_Field_Office"] == DBNull.Value)
					this._FK_LU_Sedgwick_Field_Office = null;
				else
					this._FK_LU_Sedgwick_Field_Office = (decimal?)drSedgwick_Claim_Group["FK_LU_Sedgwick_Field_Office"];

				if (drSedgwick_Claim_Group["Year"] == DBNull.Value)
					this._Year = null;
				else
					this._Year = (int?)drSedgwick_Claim_Group["Year"];

				if (drSedgwick_Claim_Group["Quarter"] == DBNull.Value)
					this._Quarter = null;
				else
					this._Quarter = (int?)drSedgwick_Claim_Group["Quarter"];

                //if (drSedgwick_Claim_Group["FK_Workers_Comp_Claims"] == DBNull.Value)
                //    this._FK_Workers_Comp_Claims = null;
                //else
                //    this._FK_Workers_Comp_Claims = (decimal?)drSedgwick_Claim_Group["FK_Workers_Comp_Claims"];

				if (drSedgwick_Claim_Group["Review_Complete"] == DBNull.Value)
					this._Review_Complete = null;
				else
					this._Review_Complete = (string)drSedgwick_Claim_Group["Review_Complete"];

				if (drSedgwick_Claim_Group["Total_of_Average_Numeric_Scores"] == DBNull.Value)
					this._Total_of_Average_Numeric_Scores = null;
				else
					this._Total_of_Average_Numeric_Scores = (decimal?)drSedgwick_Claim_Group["Total_of_Average_Numeric_Scores"];

				if (drSedgwick_Claim_Group["Updated_By"] == DBNull.Value)
					this._Updated_By = null;
				else
					this._Updated_By = (string)drSedgwick_Claim_Group["Updated_By"];

				if (drSedgwick_Claim_Group["Update_Date"] == DBNull.Value)
					this._Update_Date = null;
				else
					this._Update_Date = (DateTime?)drSedgwick_Claim_Group["Update_Date"];


		}

		#endregion

		/// <summary>
		/// Inserts a record into the Sedgwick_Claim_Group table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Sedgwick_Claim_GroupInsert");

			
			db.AddInParameter(dbCommand, "FK_LU_Sedgwick_Field_Office", DbType.Decimal, this._FK_LU_Sedgwick_Field_Office);
			
			db.AddInParameter(dbCommand, "Year", DbType.Int32, this._Year);
			
			db.AddInParameter(dbCommand, "Quarter", DbType.Int32, this._Quarter);
			
			//db.AddInParameter(dbCommand, "FK_Workers_Comp_Claims", DbType.Decimal, this._FK_Workers_Comp_Claims);
			
			if (string.IsNullOrEmpty(this._Review_Complete))
				db.AddInParameter(dbCommand, "Review_Complete", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Review_Complete", DbType.String, this._Review_Complete);
			
			db.AddInParameter(dbCommand, "Total_of_Average_Numeric_Scores", DbType.Decimal, this._Total_of_Average_Numeric_Scores);
			
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
		/// Selects a single record from the Sedgwick_Claim_Group table.
		/// </summary>
		/// <returns>DataSet</returns>
		private DataSet Select(decimal pK_Sedgwick_Claim_Group)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Sedgwick_Claim_GroupSelect");

			db.AddInParameter(dbCommand, "PK_Sedgwick_Claim_Group", DbType.Decimal, pK_Sedgwick_Claim_Group);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the Sedgwick_Claim_Group table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Sedgwick_Claim_GroupSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the Sedgwick_Claim_Group table.
		/// </summary>
		public void Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Sedgwick_Claim_GroupUpdate");

			
			db.AddInParameter(dbCommand, "PK_Sedgwick_Claim_Group", DbType.Decimal, this._PK_Sedgwick_Claim_Group);
			
			db.AddInParameter(dbCommand, "FK_LU_Sedgwick_Field_Office", DbType.Decimal, this._FK_LU_Sedgwick_Field_Office);
			
			db.AddInParameter(dbCommand, "Year", DbType.Int32, this._Year);
			
			db.AddInParameter(dbCommand, "Quarter", DbType.Int32, this._Quarter);
			
			db.AddInParameter(dbCommand, "FK_Workers_Comp_Claims", DbType.Decimal, this._FK_Workers_Comp_Claims);
			
			if (string.IsNullOrEmpty(this._Review_Complete))
				db.AddInParameter(dbCommand, "Review_Complete", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Review_Complete", DbType.String, this._Review_Complete);
			
			db.AddInParameter(dbCommand, "Total_of_Average_Numeric_Scores", DbType.Decimal, this._Total_of_Average_Numeric_Scores);
			
			if (string.IsNullOrEmpty(this._Updated_By))
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);
			
			db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the Sedgwick_Claim_Group table by a composite primary key.
		/// </summary>
		public static void Delete(decimal pK_Sedgwick_Claim_Group)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Sedgwick_Claim_GroupDelete");

			db.AddInParameter(dbCommand, "PK_Sedgwick_Claim_Group", DbType.Decimal, pK_Sedgwick_Claim_Group);

			db.ExecuteNonQuery(dbCommand);
		}

        /// <summary>
        /// Returns all records that matches the search crieteria
        /// </summary>
        /// <param name="FK_LU_Sedgwick_Field_Office"></param>
        /// <param name="Year"></param>
        /// <param name="Quarter"></param>
        /// <returns>DataSet</returns>
        public static DataSet Search(decimal FK_LU_Sedgwick_Field_Office, int Year, int Quarter, string strOrderBy, string strOrder, int intPageNo, int intPageSize)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Sedgwick_ClaimReviewGroupSearch");

            db.AddInParameter(dbCommand, "FK_LU_Sedgwick_Field_Office", DbType.Int32, FK_LU_Sedgwick_Field_Office);
            db.AddInParameter(dbCommand, "Year", DbType.String, Year);
            db.AddInParameter(dbCommand, "Quarter", DbType.String, Quarter);
            db.AddInParameter(dbCommand, "@strOrderBy", DbType.String, strOrderBy);
            db.AddInParameter(dbCommand, "@strOrder", DbType.String, strOrder);
            db.AddInParameter(dbCommand, "@intPageNo", DbType.Decimal, intPageNo);
            db.AddInParameter(dbCommand, "@intPageSize", DbType.Decimal, intPageSize);
            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Returns all records that matches the search crieteria
        /// </summary>
        /// <param name="FK_LU_Sedgwick_Field_Office"></param>
        /// <param name="State_PK_ID"></param>
        /// <param name="WC_FR_Number"></param>
        /// <param name="Origin_Claim_Number"></param>
        /// <param name="strOrderBy"></param>
        /// <param name="strOrder"></param>
        /// <param name="intPageNo"></param>
        /// <param name="intPageSize"></param>
        /// <returns>DataSet</returns>
        public static DataSet ClaimReviewWorkSheetGroup_Search(decimal FK_LU_Sedgwick_Field_Office, int Year, int Quarter, decimal State_PK_ID, decimal WC_FR_Number, string Origin_Claim_Number, Int32 Associated_First_Report, string ClaimType, Nullable<DateTime> Date_FROM_Accident, Nullable<DateTime> Date_TO_Accident, string ClaimStatus, decimal LocationNumber, string LT_Med_Only_FlagForWC, string LT_Med_Only_FlagForNS, string strOrderBy, string strOrder, int intPageNo, int intPageSize)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Sedgwick_ClaimReviewWorksheetGroup_Search");

            db.AddInParameter(dbCommand, "FK_LU_Sedgwick_Field_Office", DbType.Decimal, FK_LU_Sedgwick_Field_Office);
            db.AddInParameter(dbCommand, "@Year", DbType.Int32, Year);
            db.AddInParameter(dbCommand, "@Quarter", DbType.Int32, Quarter);  
            db.AddInParameter(dbCommand, "State_PK_ID", DbType.Decimal, State_PK_ID);
            db.AddInParameter(dbCommand, "WC_FR_Number", DbType.Decimal, WC_FR_Number);
            db.AddInParameter(dbCommand, "Origin_Claim_Number", DbType.String, Origin_Claim_Number);
            db.AddInParameter(dbCommand, "Associated_First_Report", DbType.String, Associated_First_Report);
            db.AddInParameter(dbCommand, "Claim_Type", DbType.String, ClaimType);
            db.AddInParameter(dbCommand, "Date_FROM_Accident", DbType.DateTime, Date_FROM_Accident);
            db.AddInParameter(dbCommand, "Date_TO_Accident", DbType.DateTime, Date_TO_Accident);
            db.AddInParameter(dbCommand, "@ClaimStatus", DbType.String, ClaimStatus);
            db.AddInParameter(dbCommand, "@LocationNumber", DbType.Decimal, LocationNumber);
            db.AddInParameter(dbCommand, "LT_Med_Only_FlagForWC", DbType.String, LT_Med_Only_FlagForWC);
            db.AddInParameter(dbCommand, "LT_Med_Only_FlagForNS", DbType.String, LT_Med_Only_FlagForNS);
            db.AddInParameter(dbCommand, "@strOrderBy", DbType.String, strOrderBy);
            db.AddInParameter(dbCommand, "@strOrder", DbType.String, strOrder);
            db.AddInParameter(dbCommand, "@intPageNo", DbType.Decimal, intPageNo);
            db.AddInParameter(dbCommand, "@intPageSize", DbType.Decimal, intPageSize);
            return db.ExecuteDataSet(dbCommand);
        }
        public static DataSet ClaimReviewWorkSheetGroup_Search_New(decimal FK_LU_Sedgwick_Field_Office, int Year, int Quarter, string strOrderBy, string strOrder, int intPageNo, int intPageSize, decimal FK_Employee_Id)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Sedgwick_ClaimReviewWorksheetGroup_Search_NEW");

            db.AddInParameter(dbCommand, "@FK_LU_Sedgwick_Field_Office", DbType.Decimal, FK_LU_Sedgwick_Field_Office);
            db.AddInParameter(dbCommand, "@Year", DbType.Int32, Year);
            db.AddInParameter(dbCommand, "@Quarter", DbType.Int32, Quarter);            
            db.AddInParameter(dbCommand, "@strOrderBy", DbType.String, strOrderBy);
            db.AddInParameter(dbCommand, "@strOrder", DbType.String, strOrder);
            db.AddInParameter(dbCommand, "@intPageNo", DbType.Decimal, intPageNo);
            db.AddInParameter(dbCommand, "@intPageSize", DbType.Decimal, intPageSize);
            db.AddInParameter(dbCommand, "@FK_Employee_Id", DbType.Decimal, FK_Employee_Id);
            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet Previous_Sedgwick_ClaimReview_WithOpenActionItem(decimal FK_LU_Sedgwick_Field_Office, int Year, int Quarter, string strOrderBy, string strOrder, decimal FK_Employee_Id)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Sedgwick_ClaimReview_Previous_WithOpenActionItem");

            db.AddInParameter(dbCommand, "@FK_LU_Sedgwick_Field_Office", DbType.Decimal, FK_LU_Sedgwick_Field_Office);
            db.AddInParameter(dbCommand, "@Year", DbType.Int32, Year);
            db.AddInParameter(dbCommand, "@Quarter", DbType.Int32, Quarter);
            db.AddInParameter(dbCommand, "@strOrderBy", DbType.String, strOrderBy);
            db.AddInParameter(dbCommand, "@strOrder", DbType.String, strOrder);
            db.AddInParameter(dbCommand, "@FK_Employee_Id", DbType.Decimal, FK_Employee_Id);
            //db.AddInParameter(dbCommand, "@intPageNo", DbType.Decimal, intPageNo);
            //db.AddInParameter(dbCommand, "@intPageSize", DbType.Decimal, intPageSize);
            return db.ExecuteDataSet(dbCommand);
        }
        /// <summary>
        /// Returns all records that matches the search crieteria
        /// </summary>
        /// <param name="PK_Workers_Comp_Claims_ID"></param>
        /// <returns>DataSet</returns>
        public static DataSet ClaimSummary_SelectByPK(decimal PK_Workers_Comp_Claims_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("ClaimSummaryBY_PK_Workers_Comp_Claims_ID");

            db.AddInParameter(dbCommand, "PK_Workers_Comp_Claims_ID", DbType.Int32, PK_Workers_Comp_Claims_ID);
            return db.ExecuteDataSet(dbCommand);
        }
	}
}
