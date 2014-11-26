using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace BAL
{
	/// <summary>
	/// Data access class for table LU_Sedgwick_Evaluation
	/// </summary>
	public sealed class LU_Sedgwick_Evaluation
	{

		#region Private variables used to hold the property values

		private decimal? _PK_LU_Sedgwick_Evaluation;
		private string _Management_Section;
		private decimal? _Sort_Order;
		private string _Evaluation;
		private string _Active;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_LU_Sedgwick_Evaluation value.
		/// </summary>
		public decimal? PK_LU_Sedgwick_Evaluation
		{
			get { return _PK_LU_Sedgwick_Evaluation; }
			set { _PK_LU_Sedgwick_Evaluation = value; }
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
		/// Gets or sets the Evaluation value.
		/// </summary>
		public string Evaluation
		{
			get { return _Evaluation; }
			set { _Evaluation = value; }
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
		/// Initializes a new instance of the LU_Sedgwick_Evaluation class with default value.
		/// </summary>
		public LU_Sedgwick_Evaluation() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the LU_Sedgwick_Evaluation class based on Primary Key.
		/// </summary>
		public LU_Sedgwick_Evaluation(decimal pK_LU_Sedgwick_Evaluation) 
		{
			DataTable dtLU_Sedgwick_Evaluation = Select(pK_LU_Sedgwick_Evaluation).Tables[0];

			if (dtLU_Sedgwick_Evaluation.Rows.Count == 1)
			{
				 SetValue(dtLU_Sedgwick_Evaluation.Rows[0]);

			}

		}


		/// <summary>
		/// Initializes a new instance of the LU_Sedgwick_Evaluation class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drLU_Sedgwick_Evaluation) 
		{
				if (drLU_Sedgwick_Evaluation["PK_LU_Sedgwick_Evaluation"] == DBNull.Value)
					this._PK_LU_Sedgwick_Evaluation = null;
				else
					this._PK_LU_Sedgwick_Evaluation = (decimal?)drLU_Sedgwick_Evaluation["PK_LU_Sedgwick_Evaluation"];

				if (drLU_Sedgwick_Evaluation["Management_Section"] == DBNull.Value)
					this._Management_Section = null;
				else
					this._Management_Section = (string)drLU_Sedgwick_Evaluation["Management_Section"];

				if (drLU_Sedgwick_Evaluation["Sort_Order"] == DBNull.Value)
					this._Sort_Order = null;
				else
					this._Sort_Order = (decimal?)drLU_Sedgwick_Evaluation["Sort_Order"];

				if (drLU_Sedgwick_Evaluation["Evaluation"] == DBNull.Value)
					this._Evaluation = null;
				else
					this._Evaluation = (string)drLU_Sedgwick_Evaluation["Evaluation"];

				if (drLU_Sedgwick_Evaluation["Active"] == DBNull.Value)
					this._Active = null;
				else
					this._Active = (string)drLU_Sedgwick_Evaluation["Active"];


		}

		#endregion

		/// <summary>
		/// Inserts a record into the LU_Sedgwick_Evaluation table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Sedgwick_EvaluationInsert");

			
			if (string.IsNullOrEmpty(this._Management_Section))
				db.AddInParameter(dbCommand, "Management_Section", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Management_Section", DbType.String, this._Management_Section);
			
			db.AddInParameter(dbCommand, "Sort_Order", DbType.Decimal, this._Sort_Order);
			
			if (string.IsNullOrEmpty(this._Evaluation))
				db.AddInParameter(dbCommand, "Evaluation", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Evaluation", DbType.String, this._Evaluation);
			
			if (string.IsNullOrEmpty(this._Active))
				db.AddInParameter(dbCommand, "Active", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Active", DbType.String, this._Active);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the LU_Sedgwick_Evaluation table.
		/// </summary>
		/// <returns>DataSet</returns>
		private DataSet Select(decimal pK_LU_Sedgwick_Evaluation)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Sedgwick_EvaluationSelect");

			db.AddInParameter(dbCommand, "PK_LU_Sedgwick_Evaluation", DbType.Decimal, pK_LU_Sedgwick_Evaluation);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the LU_Sedgwick_Evaluation table.
		/// </summary>
		/// <returns>DataSet</returns>
        public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Sedgwick_EvaluationSelectAll");
            //db.AddInParameter(dbCommand, "@intPageNo", DbType.String, intPageNo);
            //db.AddInParameter(dbCommand, "@intPageSize", DbType.String, intPageSize);

			return db.ExecuteDataSet(dbCommand);
		}

        /// <summary>
        /// Selects Distinct Management Section records from the LU_Sedgwick_Evaluation table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAllDistinctMgtSection()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_Sedgwick_Evaluation_SelectDistinctMgtSection");
            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects by Management Section records from the LU_Sedgwick_Evaluation table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectBy_MgtSection(string MgtSection, decimal FK_Sedgwick_Claim_Review)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_Sedgwick_EvaluationSelect_ByMgtSection");
            db.AddInParameter(dbCommand, "@MgtSection", DbType.String, MgtSection);
            db.AddInParameter(dbCommand, "@FK_Sedgwick_Claim_Review", DbType.Decimal, FK_Sedgwick_Claim_Review);
            return db.ExecuteDataSet(dbCommand);
        }

		/// <summary>
		/// Updates a record in the LU_Sedgwick_Evaluation table.
		/// </summary>
        public decimal Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Sedgwick_EvaluationUpdate");

			
			db.AddInParameter(dbCommand, "PK_LU_Sedgwick_Evaluation", DbType.Decimal, this._PK_LU_Sedgwick_Evaluation);
			
			if (string.IsNullOrEmpty(this._Management_Section))
				db.AddInParameter(dbCommand, "Management_Section", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Management_Section", DbType.String, this._Management_Section);
			
			db.AddInParameter(dbCommand, "Sort_Order", DbType.Decimal, this._Sort_Order);
			
			if (string.IsNullOrEmpty(this._Evaluation))
				db.AddInParameter(dbCommand, "Evaluation", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Evaluation", DbType.String, this._Evaluation);
			
			if (string.IsNullOrEmpty(this._Active))
				db.AddInParameter(dbCommand, "Active", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Active", DbType.String, this._Active);

            return (Convert.ToDecimal(db.ExecuteScalar(dbCommand)));
		}

		/// <summary>
		/// Deletes a record from the LU_Sedgwick_Evaluation table by a composite primary key.
		/// </summary>
		public static void Delete(decimal pK_LU_Sedgwick_Evaluation)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Sedgwick_EvaluationDelete");

			db.AddInParameter(dbCommand, "PK_LU_Sedgwick_Evaluation", DbType.Decimal, pK_LU_Sedgwick_Evaluation);

			db.ExecuteNonQuery(dbCommand);
		}
	}
}
