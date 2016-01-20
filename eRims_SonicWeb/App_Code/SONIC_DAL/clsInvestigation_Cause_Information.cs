using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for Investigation_Cause_Information table.
	/// </summary>
	public sealed class clsInvestigation_Cause_Information
	{

		#region Private variables used to hold the property values

		private decimal? _PK_Investigation_Cause_Information;
		private decimal? _FK_Investigation;
		private decimal? _FK_LU_Cause_Code_Information;
		private string _Response;
		private string _Updated_By;
		private DateTime? _Update_Date;
        private string _Prevent_Reoccurrence;

        private string _Comments;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_Investigation_Cause_Information value.
		/// </summary>
		public decimal? PK_Investigation_Cause_Information
		{
			get { return _PK_Investigation_Cause_Information; }
			set { _PK_Investigation_Cause_Information = value; }
		}

		/// <summary>
		/// Gets or sets the FK_Investigation value.
		/// </summary>
		public decimal? FK_Investigation
		{
			get { return _FK_Investigation; }
			set { _FK_Investigation = value; }
		}

		/// <summary>
		/// Gets or sets the FK_LU_Cause_Code_Information value.
		/// </summary>
		public decimal? FK_LU_Cause_Code_Information
		{
			get { return _FK_LU_Cause_Code_Information; }
			set { _FK_LU_Cause_Code_Information = value; }
		}

		/// <summary>
		/// Gets or sets the Response value.
		/// </summary>
		public string Response
		{
			get { return _Response; }
			set { _Response = value; }
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

        /// <summary>
        /// Gets or sets the Prevent_Reoccurrence value.
        /// </summary>
        public string Prevent_Reoccurrence
        {
            get { return _Prevent_Reoccurrence; }
            set { _Prevent_Reoccurrence = value; }
        }

        /// <summary>
        /// Gets or sets the Comment value.
        /// </summary>
        public string Comments
        {
            get { return _Comments; }
            set { _Comments = value; }
        }

		#endregion

		#region Default Constructors

		/// <summary>
		/// Initializes a new instance of the clsInvestigation_Cause_Information class with default value.
		/// </summary>
		public clsInvestigation_Cause_Information() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the clsInvestigation_Cause_Information class based on Primary Key.
		/// </summary>
		public clsInvestigation_Cause_Information(decimal pK_Investigation_Cause_Information) 
		{
			DataTable dtInvestigation_Cause_Information = Select(pK_Investigation_Cause_Information).Tables[0];

			if (dtInvestigation_Cause_Information.Rows.Count == 1)
			{
				 SetValue(dtInvestigation_Cause_Information.Rows[0]);

			}

		}


		/// <summary>
		/// Initializes a new instance of the clsInvestigation_Cause_Information class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drInvestigation_Cause_Information) 
		{
				if (drInvestigation_Cause_Information["PK_Investigation_Cause_Information"] == DBNull.Value)
					this._PK_Investigation_Cause_Information = null;
				else
					this._PK_Investigation_Cause_Information = (decimal?)drInvestigation_Cause_Information["PK_Investigation_Cause_Information"];

				if (drInvestigation_Cause_Information["FK_Investigation"] == DBNull.Value)
					this._FK_Investigation = null;
				else
					this._FK_Investigation = (decimal?)drInvestigation_Cause_Information["FK_Investigation"];

				if (drInvestigation_Cause_Information["FK_LU_Cause_Code_Information"] == DBNull.Value)
					this._FK_LU_Cause_Code_Information = null;
				else
					this._FK_LU_Cause_Code_Information = (decimal?)drInvestigation_Cause_Information["FK_LU_Cause_Code_Information"];

				if (drInvestigation_Cause_Information["Response"] == DBNull.Value)
					this._Response = null;
				else
					this._Response = (string)drInvestigation_Cause_Information["Response"];

				if (drInvestigation_Cause_Information["Updated_By"] == DBNull.Value)
					this._Updated_By = null;
				else
					this._Updated_By = (string)drInvestigation_Cause_Information["Updated_By"];

				if (drInvestigation_Cause_Information["Update_Date"] == DBNull.Value)
					this._Update_Date = null;
				else
					this._Update_Date = (DateTime?)drInvestigation_Cause_Information["Update_Date"];

                if (drInvestigation_Cause_Information["Comments"] == DBNull.Value)
                    this._Comments = null;
                else
                    this._Comments = (string)drInvestigation_Cause_Information["Comments"];


		}

		#endregion

		/// <summary>
		/// Inserts a record into the Investigation_Cause_Information table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Investigation_Cause_InformationInsert");

			
			db.AddInParameter(dbCommand, "FK_Investigation", DbType.Decimal, this._FK_Investigation);
			
			db.AddInParameter(dbCommand, "FK_LU_Cause_Code_Information", DbType.Decimal, this._FK_LU_Cause_Code_Information);
			
			if (string.IsNullOrEmpty(this._Response))
				db.AddInParameter(dbCommand, "Response", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Response", DbType.String, this._Response);
			
			if (string.IsNullOrEmpty(this._Updated_By))
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);
			
			db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);

            if (string.IsNullOrEmpty(this._Prevent_Reoccurrence))
                db.AddInParameter(dbCommand, "Prevent_Reoccurrence", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Prevent_Reoccurrence", DbType.String, this._Prevent_Reoccurrence);

            if (string.IsNullOrEmpty(this._Comments))
                db.AddInParameter(dbCommand, "Comments", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Comments", DbType.String, this._Comments);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the Investigation_Cause_Information table.
		/// </summary>
		/// <returns>DataSet</returns>
		private DataSet Select(decimal pK_Investigation_Cause_Information)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Investigation_Cause_InformationSelect");

			db.AddInParameter(dbCommand, "PK_Investigation_Cause_Information", DbType.Decimal, pK_Investigation_Cause_Information);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the Investigation_Cause_Information table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Investigation_Cause_InformationSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the Investigation_Cause_Information table.
		/// </summary>
		public void Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Investigation_Cause_InformationUpdate");

			
			db.AddInParameter(dbCommand, "PK_Investigation_Cause_Information", DbType.Decimal, this._PK_Investigation_Cause_Information);
			
			db.AddInParameter(dbCommand, "FK_Investigation", DbType.Decimal, this._FK_Investigation);
			
			db.AddInParameter(dbCommand, "FK_LU_Cause_Code_Information", DbType.Decimal, this._FK_LU_Cause_Code_Information);
			
			if (string.IsNullOrEmpty(this._Response))
				db.AddInParameter(dbCommand, "Response", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Response", DbType.String, this._Response);
			
			if (string.IsNullOrEmpty(this._Updated_By))
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);
			
			db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);

            if (string.IsNullOrEmpty(this._Prevent_Reoccurrence))
                db.AddInParameter(dbCommand, "Prevent_Reoccurrence", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Prevent_Reoccurrence", DbType.String, this._Prevent_Reoccurrence);

            if (string.IsNullOrEmpty(this._Comments))
                db.AddInParameter(dbCommand, "Comments", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Comments", DbType.String, this._Comments);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the Investigation_Cause_Information table by a composite primary key.
		/// </summary>
		public static void Delete(decimal pK_Investigation_Cause_Information)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Investigation_Cause_InformationDelete");

			db.AddInParameter(dbCommand, "PK_Investigation_Cause_Information", DbType.Decimal, pK_Investigation_Cause_Information);

			db.ExecuteNonQuery(dbCommand);
		}

        /// <summary>
        /// Select records from the Investigation_Cause_Information table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectByInvestigationID(decimal pK_Investigation_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Investigation_Cause_InformationSelectByInvestigationID");

            db.AddInParameter(dbCommand, "FK_Investigation", DbType.Decimal, pK_Investigation_ID);
            
            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Deletes a record from the Investigation_Cause_Information table by a composite primary key.
        /// </summary>
        public static void DeleteByInvestigationID(decimal pK_Investigation_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Investigation_Cause_InformationDeleteByInvestigationID");

            db.AddInParameter(dbCommand, "FK_Investigation", DbType.Decimal, pK_Investigation_ID);

            db.ExecuteNonQuery(dbCommand);
        }
	}
}
