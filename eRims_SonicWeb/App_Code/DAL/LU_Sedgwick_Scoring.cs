using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace BAL
{
	/// <summary>
	/// Data access class for table LU_Sedgwick_Scoring
	/// </summary>
	public sealed class LU_Sedgwick_Scoring
	{

		#region Private variables used to hold the property values

		private decimal? _PK_LU_Sedgwick_Scoring;
		private string _Management_Section;
		private decimal? _Sort_Order;
		private string _Scoring_Note;
		private string _Active;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_LU_Sedgwick_Scoring value.
		/// </summary>
		public decimal? PK_LU_Sedgwick_Scoring
		{
			get { return _PK_LU_Sedgwick_Scoring; }
			set { _PK_LU_Sedgwick_Scoring = value; }
		}

		/// <summary>
		/// Gets or sets the Management_Section value.
		/// </summary>
		public string Management_Section
		{
			get { return _Management_Section; }
			set { _Management_Section = value; }
		}

		/// <summary>
		/// Gets or sets the Sort_Order value.
		/// </summary>
		public decimal? Sort_Order
		{
			get { return _Sort_Order; }
			set { _Sort_Order = value; }
		}

		/// <summary>
		/// Gets or sets the Scoring_Note value.
		/// </summary>
		public string Scoring_Note
		{
			get { return _Scoring_Note; }
			set { _Scoring_Note = value; }
		}

		/// <summary>
		/// Gets or sets the Active value.
		/// </summary>
		public string Active
		{
			get { return _Active; }
			set { _Active = value; }
		}


		#endregion

		#region Default Constructors

		/// <summary>
		/// Initializes a new instance of the LU_Sedgwick_Scoring class with default value.
		/// </summary>
		public LU_Sedgwick_Scoring() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the LU_Sedgwick_Scoring class based on Primary Key.
		/// </summary>
		public LU_Sedgwick_Scoring(decimal pK_LU_Sedgwick_Scoring) 
		{
			DataTable dtLU_Sedgwick_Scoring = Select(pK_LU_Sedgwick_Scoring).Tables[0];

			if (dtLU_Sedgwick_Scoring.Rows.Count == 1)
			{
				 SetValue(dtLU_Sedgwick_Scoring.Rows[0]);

			}

		}


		/// <summary>
		/// Initializes a new instance of the LU_Sedgwick_Scoring class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drLU_Sedgwick_Scoring) 
		{
				if (drLU_Sedgwick_Scoring["PK_LU_Sedgwick_Scoring"] == DBNull.Value)
					this._PK_LU_Sedgwick_Scoring = null;
				else
					this._PK_LU_Sedgwick_Scoring = (decimal?)drLU_Sedgwick_Scoring["PK_LU_Sedgwick_Scoring"];

				if (drLU_Sedgwick_Scoring["Management_Section"] == DBNull.Value)
					this._Management_Section = null;
				else
					this._Management_Section = (string)drLU_Sedgwick_Scoring["Management_Section"];

				if (drLU_Sedgwick_Scoring["Sort_Order"] == DBNull.Value)
					this._Sort_Order = null;
				else
					this._Sort_Order = (decimal?)drLU_Sedgwick_Scoring["Sort_Order"];

				if (drLU_Sedgwick_Scoring["Scoring_Note"] == DBNull.Value)
					this._Scoring_Note = null;
				else
					this._Scoring_Note = (string)drLU_Sedgwick_Scoring["Scoring_Note"];

				if (drLU_Sedgwick_Scoring["Active"] == DBNull.Value)
					this._Active = null;
				else
					this._Active = (string)drLU_Sedgwick_Scoring["Active"];


		}

		#endregion

		/// <summary>
		/// Inserts a record into the LU_Sedgwick_Scoring table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Sedgwick_ScoringInsert");

			
			if (string.IsNullOrEmpty(this._Management_Section))
				db.AddInParameter(dbCommand, "Management_Section", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Management_Section", DbType.String, this._Management_Section);
			
			db.AddInParameter(dbCommand, "Sort_Order", DbType.Decimal, this._Sort_Order);
			
			if (string.IsNullOrEmpty(this._Scoring_Note))
				db.AddInParameter(dbCommand, "Scoring_Note", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Scoring_Note", DbType.String, this._Scoring_Note);
			
			if (string.IsNullOrEmpty(this._Active))
				db.AddInParameter(dbCommand, "Active", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Active", DbType.String, this._Active);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the LU_Sedgwick_Scoring table.
		/// </summary>
		/// <returns>DataSet</returns>
		private DataSet Select(decimal pK_LU_Sedgwick_Scoring)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Sedgwick_ScoringSelect");

			db.AddInParameter(dbCommand, "PK_LU_Sedgwick_Scoring", DbType.Decimal, pK_LU_Sedgwick_Scoring);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the LU_Sedgwick_Scoring table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Sedgwick_ScoringSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

        /// <summary>
        /// Selects by Management Section records from the LU_Sedgwick_Scoring table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectBy_MgtSection(string MgtSection)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_Sedgwick_ScoringSelect_ByMgtSection");
            db.AddInParameter(dbCommand, "@MgtSection", DbType.String, MgtSection);

            return db.ExecuteDataSet(dbCommand);
        }

		/// <summary>
		/// Updates a record in the LU_Sedgwick_Scoring table.
		/// </summary>
		public decimal Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Sedgwick_ScoringUpdate");

			
			db.AddInParameter(dbCommand, "PK_LU_Sedgwick_Scoring", DbType.Decimal, this._PK_LU_Sedgwick_Scoring);
			
			if (string.IsNullOrEmpty(this._Management_Section))
				db.AddInParameter(dbCommand, "Management_Section", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Management_Section", DbType.String, this._Management_Section);
			
			db.AddInParameter(dbCommand, "Sort_Order", DbType.Decimal, this._Sort_Order);
			
			if (string.IsNullOrEmpty(this._Scoring_Note))
				db.AddInParameter(dbCommand, "Scoring_Note", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Scoring_Note", DbType.String, this._Scoring_Note);
			
			if (string.IsNullOrEmpty(this._Active))
				db.AddInParameter(dbCommand, "Active", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Active", DbType.String, this._Active);

            return (Convert.ToDecimal(db.ExecuteScalar(dbCommand)));
		}

		/// <summary>
		/// Deletes a record from the LU_Sedgwick_Scoring table by a composite primary key.
		/// </summary>
		public static void Delete(decimal pK_LU_Sedgwick_Scoring)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Sedgwick_ScoringDelete");

			db.AddInParameter(dbCommand, "PK_LU_Sedgwick_Scoring", DbType.Decimal, pK_LU_Sedgwick_Scoring);

			db.ExecuteNonQuery(dbCommand);
		}

        /// <summary>
        /// Select records for the Review ScoreCard.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet GetReviewScoreCard(decimal FK_Sedgwick_Claim_Group, decimal FK_LU_Sedgwick_Field_Office, int Year, int Quarter, decimal PK_Sedgwick_Claim_Review)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("GetReviewScoreCard");
            db.AddInParameter(dbCommand, "FK_LU_Sedgwick_Field_Office", DbType.Decimal, FK_LU_Sedgwick_Field_Office);
            db.AddInParameter(dbCommand, "@Year", DbType.Int32, Year);
            db.AddInParameter(dbCommand, "@Quarter", DbType.Int32, Quarter);  
            db.AddInParameter(dbCommand, "@FK_Sedgwick_Claim_Group", DbType.Decimal, FK_Sedgwick_Claim_Group);
            db.AddInParameter(dbCommand, "@PK_Sedgwick_Claim_Review", DbType.Decimal, PK_Sedgwick_Claim_Review);
            return db.ExecuteDataSet(dbCommand);
        }
	}
}
