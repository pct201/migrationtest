using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace BAL
{
	/// <summary>
	/// Data access class for table Sedgwick_Claim_RLCM_Comments
	/// </summary>
	public sealed class Sedgwick_Claim_RLCM_Comments
	{

		#region Private variables used to hold the property values

		private decimal? _PK_Sedgwick_Claim_RLCM_Comments;
		private decimal? _FK_Sedgwick_Claim_Review;
		private string _Management_Section;
		private decimal? _FK_LU_Sedgwick_Evaluation;
		private string _Comments;
		private string _Updated_By;
		private DateTime? _Update_Date;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_Sedgwick_Claim_RLCM_Comments value.
		/// </summary>
		public decimal? PK_Sedgwick_Claim_RLCM_Comments
		{
			get { return _PK_Sedgwick_Claim_RLCM_Comments; }
			set { _PK_Sedgwick_Claim_RLCM_Comments = value; }
		}

		/// <summary>
		/// Gets or sets the FK_Sedgwick_Claim_Review value.
		/// </summary>
		public decimal? FK_Sedgwick_Claim_Review
		{
			get { return _FK_Sedgwick_Claim_Review; }
			set { _FK_Sedgwick_Claim_Review = value; }
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
		/// Gets or sets the FK_LU_Sedgwick_Evaluation value.
		/// </summary>
		public decimal? FK_LU_Sedgwick_Evaluation
		{
			get { return _FK_LU_Sedgwick_Evaluation; }
			set { _FK_LU_Sedgwick_Evaluation = value; }
		}

		/// <summary>
		/// Gets or sets the Comments value.
		/// </summary>
		public string Comments
		{
			get { return _Comments; }
			set { _Comments = value; }
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
		/// Initializes a new instance of the Sedgwick_Claim_RLCM_Comments class with default value.
		/// </summary>
		public Sedgwick_Claim_RLCM_Comments() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the Sedgwick_Claim_RLCM_Comments class based on Primary Key.
		/// </summary>
		public Sedgwick_Claim_RLCM_Comments(decimal pK_Sedgwick_Claim_RLCM_Comments) 
		{
			DataTable dtSedgwick_Claim_RLCM_Comments = Select(pK_Sedgwick_Claim_RLCM_Comments).Tables[0];

			if (dtSedgwick_Claim_RLCM_Comments.Rows.Count == 1)
			{
				 SetValue(dtSedgwick_Claim_RLCM_Comments.Rows[0]);

			}

		}


		/// <summary>
		/// Initializes a new instance of the Sedgwick_Claim_RLCM_Comments class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drSedgwick_Claim_RLCM_Comments) 
		{
				if (drSedgwick_Claim_RLCM_Comments["PK_Sedgwick_Claim_RLCM_Comments"] == DBNull.Value)
					this._PK_Sedgwick_Claim_RLCM_Comments = null;
				else
					this._PK_Sedgwick_Claim_RLCM_Comments = (decimal?)drSedgwick_Claim_RLCM_Comments["PK_Sedgwick_Claim_RLCM_Comments"];

				if (drSedgwick_Claim_RLCM_Comments["FK_Sedgwick_Claim_Review"] == DBNull.Value)
					this._FK_Sedgwick_Claim_Review = null;
				else
					this._FK_Sedgwick_Claim_Review = (decimal?)drSedgwick_Claim_RLCM_Comments["FK_Sedgwick_Claim_Review"];

				if (drSedgwick_Claim_RLCM_Comments["Management_Section"] == DBNull.Value)
					this._Management_Section = null;
				else
					this._Management_Section = (string)drSedgwick_Claim_RLCM_Comments["Management_Section"];

				if (drSedgwick_Claim_RLCM_Comments["FK_LU_Sedgwick_Evaluation"] == DBNull.Value)
					this._FK_LU_Sedgwick_Evaluation = null;
				else
					this._FK_LU_Sedgwick_Evaluation = (decimal?)drSedgwick_Claim_RLCM_Comments["FK_LU_Sedgwick_Evaluation"];

				if (drSedgwick_Claim_RLCM_Comments["Comments"] == DBNull.Value)
					this._Comments = null;
				else
					this._Comments = (string)drSedgwick_Claim_RLCM_Comments["Comments"];

				if (drSedgwick_Claim_RLCM_Comments["Updated_By"] == DBNull.Value)
					this._Updated_By = null;
				else
					this._Updated_By = (string)drSedgwick_Claim_RLCM_Comments["Updated_By"];

				if (drSedgwick_Claim_RLCM_Comments["Update_Date"] == DBNull.Value)
					this._Update_Date = null;
				else
					this._Update_Date = (DateTime?)drSedgwick_Claim_RLCM_Comments["Update_Date"];


		}

		#endregion

		/// <summary>
		/// Inserts a record into the Sedgwick_Claim_RLCM_Comments table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Sedgwick_Claim_RLCM_CommentsInsert");

			
			db.AddInParameter(dbCommand, "FK_Sedgwick_Claim_Review", DbType.Decimal, this._FK_Sedgwick_Claim_Review);
			
			if (string.IsNullOrEmpty(this._Management_Section))
				db.AddInParameter(dbCommand, "Management_Section", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Management_Section", DbType.String, this._Management_Section);
			
			db.AddInParameter(dbCommand, "FK_LU_Sedgwick_Evaluation", DbType.Decimal, this._FK_LU_Sedgwick_Evaluation);
			
			if (string.IsNullOrEmpty(this._Comments))
				db.AddInParameter(dbCommand, "Comments", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Comments", DbType.String, this._Comments);
			
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
		/// Selects a single record from the Sedgwick_Claim_RLCM_Comments table.
		/// </summary>
		/// <returns>DataSet</returns>
		private DataSet Select(decimal pK_Sedgwick_Claim_RLCM_Comments)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Sedgwick_Claim_RLCM_CommentsSelect");

			db.AddInParameter(dbCommand, "PK_Sedgwick_Claim_RLCM_Comments", DbType.Decimal, pK_Sedgwick_Claim_RLCM_Comments);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the Sedgwick_Claim_RLCM_Comments table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Sedgwick_Claim_RLCM_CommentsSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the Sedgwick_Claim_RLCM_Comments table.
		/// </summary>
		public void Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Sedgwick_Claim_RLCM_CommentsUpdate");

			
			db.AddInParameter(dbCommand, "PK_Sedgwick_Claim_RLCM_Comments", DbType.Decimal, this._PK_Sedgwick_Claim_RLCM_Comments);
			
			db.AddInParameter(dbCommand, "FK_Sedgwick_Claim_Review", DbType.Decimal, this._FK_Sedgwick_Claim_Review);
			
			if (string.IsNullOrEmpty(this._Management_Section))
				db.AddInParameter(dbCommand, "Management_Section", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Management_Section", DbType.String, this._Management_Section);
			
			db.AddInParameter(dbCommand, "FK_LU_Sedgwick_Evaluation", DbType.Decimal, this._FK_LU_Sedgwick_Evaluation);
			
			if (string.IsNullOrEmpty(this._Comments))
				db.AddInParameter(dbCommand, "Comments", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Comments", DbType.String, this._Comments);
			
			if (string.IsNullOrEmpty(this._Updated_By))
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);
			
			db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the Sedgwick_Claim_RLCM_Comments table by a composite primary key.
		/// </summary>
		public static void Delete(decimal pK_Sedgwick_Claim_RLCM_Comments)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Sedgwick_Claim_RLCM_CommentsDelete");

			db.AddInParameter(dbCommand, "PK_Sedgwick_Claim_RLCM_Comments", DbType.Decimal, pK_Sedgwick_Claim_RLCM_Comments);

			db.ExecuteNonQuery(dbCommand);
		}
	}
}
