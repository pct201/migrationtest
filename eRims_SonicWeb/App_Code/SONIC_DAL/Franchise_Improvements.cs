using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for Franchise_Improvements table.
	/// </summary>
	public sealed class Franchise_Improvements
	{

		#region Private variables used to hold the property values

		private decimal? _PK_Franchise_Improvements;
		private decimal? _FK_Franchise;
		private string _Improvement;
		private string _Description_Of_Work;
		private DateTime? _Scheduled_Start;
		private DateTime? _Actual_Start;
		private DateTime? _Actual_Completion;
		private DateTime? _Anticipated_Completion;
		private string _Updates;
		private string _Updated_By;
		private DateTime? _Update_Date;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_Franchise_Improvements value.
		/// </summary>
		public decimal? PK_Franchise_Improvements
		{
			get { return _PK_Franchise_Improvements; }
			set { _PK_Franchise_Improvements = value; }
		}

		/// <summary>
		/// Gets or sets the FK_Franchise value.
		/// </summary>
		public decimal? FK_Franchise
		{
			get { return _FK_Franchise; }
			set { _FK_Franchise = value; }
		}

		/// <summary>
		/// Gets or sets the Improvement value.
		/// </summary>
		public string Improvement
		{
			get { return _Improvement; }
			set { _Improvement = value; }
		}

		/// <summary>
		/// Gets or sets the Description_Of_Work value.
		/// </summary>
		public string Description_Of_Work
		{
			get { return _Description_Of_Work; }
			set { _Description_Of_Work = value; }
		}

		/// <summary>
		/// Gets or sets the Scheduled_Start value.
		/// </summary>
		public DateTime? Scheduled_Start
		{
			get { return _Scheduled_Start; }
			set { _Scheduled_Start = value; }
		}

		/// <summary>
		/// Gets or sets the Actual_Start value.
		/// </summary>
		public DateTime? Actual_Start
		{
			get { return _Actual_Start; }
			set { _Actual_Start = value; }
		}

		/// <summary>
		/// Gets or sets the Actual_Completion value.
		/// </summary>
		public DateTime? Actual_Completion
		{
			get { return _Actual_Completion; }
			set { _Actual_Completion = value; }
		}

		/// <summary>
		/// Gets or sets the Anticipated_Completion value.
		/// </summary>
		public DateTime? Anticipated_Completion
		{
			get { return _Anticipated_Completion; }
			set { _Anticipated_Completion = value; }
		}

		/// <summary>
		/// Gets or sets the Updates value.
		/// </summary>
		public string Updates
		{
			get { return _Updates; }
			set { _Updates = value; }
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
		/// Initializes a new instance of the Franchise_Improvements class with default value.
		/// </summary>
		public Franchise_Improvements() 
		{

			this._PK_Franchise_Improvements = null;
			this._FK_Franchise = null;
			this._Improvement = null;
			this._Description_Of_Work = null;
			this._Scheduled_Start = null;
			this._Actual_Start = null;
			this._Actual_Completion = null;
			this._Anticipated_Completion = null;
			this._Updates = null;
			this._Updated_By = null;
			this._Update_Date = null;

		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the Franchise_Improvements class based on Primary Key.
		/// </summary>
		public Franchise_Improvements(decimal pK_Franchise_Improvements) 
		{
			DataTable dtFranchise_Improvements = SelectByPK(pK_Franchise_Improvements).Tables[0];

			if (dtFranchise_Improvements.Rows.Count == 1)
			{
				DataRow drFranchise_Improvements = dtFranchise_Improvements.Rows[0];
				if (drFranchise_Improvements["PK_Franchise_Improvements"] == DBNull.Value)
					this._PK_Franchise_Improvements = null;
				else
					this._PK_Franchise_Improvements = (decimal?)drFranchise_Improvements["PK_Franchise_Improvements"];

				if (drFranchise_Improvements["FK_Franchise"] == DBNull.Value)
					this._FK_Franchise = null;
				else
					this._FK_Franchise = (decimal?)drFranchise_Improvements["FK_Franchise"];

				if (drFranchise_Improvements["Improvement"] == DBNull.Value)
					this._Improvement = null;
				else
					this._Improvement = (string)drFranchise_Improvements["Improvement"];

				if (drFranchise_Improvements["Description_Of_Work"] == DBNull.Value)
					this._Description_Of_Work = null;
				else
					this._Description_Of_Work = (string)drFranchise_Improvements["Description_Of_Work"];

				if (drFranchise_Improvements["Scheduled_Start"] == DBNull.Value)
					this._Scheduled_Start = null;
				else
					this._Scheduled_Start = (DateTime?)drFranchise_Improvements["Scheduled_Start"];

				if (drFranchise_Improvements["Actual_Start"] == DBNull.Value)
					this._Actual_Start = null;
				else
					this._Actual_Start = (DateTime?)drFranchise_Improvements["Actual_Start"];

				if (drFranchise_Improvements["Actual_Completion"] == DBNull.Value)
					this._Actual_Completion = null;
				else
					this._Actual_Completion = (DateTime?)drFranchise_Improvements["Actual_Completion"];

				if (drFranchise_Improvements["Anticipated_Completion"] == DBNull.Value)
					this._Anticipated_Completion = null;
				else
					this._Anticipated_Completion = (DateTime?)drFranchise_Improvements["Anticipated_Completion"];

				if (drFranchise_Improvements["Updates"] == DBNull.Value)
					this._Updates = null;
				else
					this._Updates = (string)drFranchise_Improvements["Updates"];

				if (drFranchise_Improvements["Updated_By"] == DBNull.Value)
					this._Updated_By = null;
				else
					this._Updated_By = (string)drFranchise_Improvements["Updated_By"];

				if (drFranchise_Improvements["Update_Date"] == DBNull.Value)
					this._Update_Date = null;
				else
					this._Update_Date = (DateTime?)drFranchise_Improvements["Update_Date"];

			}
			else
			{
				this._PK_Franchise_Improvements = null;
				this._FK_Franchise = null;
				this._Improvement = null;
				this._Description_Of_Work = null;
				this._Scheduled_Start = null;
				this._Actual_Start = null;
				this._Actual_Completion = null;
				this._Anticipated_Completion = null;
				this._Updates = null;
				this._Updated_By = null;
				this._Update_Date = null;
			}

		}

		#endregion

		/// <summary>
		/// Inserts a record into the Franchise_Improvements table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Franchise_ImprovementsInsert");

			
			db.AddInParameter(dbCommand, "FK_Franchise", DbType.Decimal, this._FK_Franchise);
			
			if (string.IsNullOrEmpty(this._Improvement))
				db.AddInParameter(dbCommand, "Improvement", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Improvement", DbType.String, this._Improvement);
			
			if (string.IsNullOrEmpty(this._Description_Of_Work))
				db.AddInParameter(dbCommand, "Description_Of_Work", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Description_Of_Work", DbType.String, this._Description_Of_Work);
			
			db.AddInParameter(dbCommand, "Scheduled_Start", DbType.DateTime, this._Scheduled_Start);
			
			db.AddInParameter(dbCommand, "Actual_Start", DbType.DateTime, this._Actual_Start);
			
			db.AddInParameter(dbCommand, "Actual_Completion", DbType.DateTime, this._Actual_Completion);
			
			db.AddInParameter(dbCommand, "Anticipated_Completion", DbType.DateTime, this._Anticipated_Completion);
			
			if (string.IsNullOrEmpty(this._Updates))
				db.AddInParameter(dbCommand, "Updates", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Updates", DbType.String, this._Updates);
			
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
		/// Selects a single record from the Franchise_Improvements table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		private static DataSet SelectByPK(decimal pK_Franchise_Improvements)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Franchise_ImprovementsSelectByPK");

			db.AddInParameter(dbCommand, "PK_Franchise_Improvements", DbType.Decimal, pK_Franchise_Improvements);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the Franchise_Improvements table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Franchise_ImprovementsSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the Franchise_Improvements table.
		/// </summary>
		public void Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Franchise_ImprovementsUpdate");

			
			db.AddInParameter(dbCommand, "PK_Franchise_Improvements", DbType.Decimal, this._PK_Franchise_Improvements);
			
			db.AddInParameter(dbCommand, "FK_Franchise", DbType.Decimal, this._FK_Franchise);
			
			if (string.IsNullOrEmpty(this._Improvement))
				db.AddInParameter(dbCommand, "Improvement", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Improvement", DbType.String, this._Improvement);
			
			if (string.IsNullOrEmpty(this._Description_Of_Work))
				db.AddInParameter(dbCommand, "Description_Of_Work", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Description_Of_Work", DbType.String, this._Description_Of_Work);
			
			db.AddInParameter(dbCommand, "Scheduled_Start", DbType.DateTime, this._Scheduled_Start);
			
			db.AddInParameter(dbCommand, "Actual_Start", DbType.DateTime, this._Actual_Start);
			
			db.AddInParameter(dbCommand, "Actual_Completion", DbType.DateTime, this._Actual_Completion);
			
			db.AddInParameter(dbCommand, "Anticipated_Completion", DbType.DateTime, this._Anticipated_Completion);
			
			if (string.IsNullOrEmpty(this._Updates))
				db.AddInParameter(dbCommand, "Updates", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Updates", DbType.String, this._Updates);
			
			if (string.IsNullOrEmpty(this._Updated_By))
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);
			
			db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the Franchise_Improvements table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_Franchise_Improvements)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Franchise_ImprovementsDeleteByPK");

			db.AddInParameter(dbCommand, "PK_Franchise_Improvements", DbType.Decimal, pK_Franchise_Improvements);

			db.ExecuteNonQuery(dbCommand);
		}

        
        public static DataSet SelectByFK(decimal fK_Franchise)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Franchise_ImprovementsSelectByFK");

            db.AddInParameter(dbCommand, "FK_Franchise", DbType.Decimal, fK_Franchise);

            return db.ExecuteDataSet(dbCommand);
        }
	}
}
