using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for PM_AssociateTrainingFirstRepose_AED table.
	/// </summary>
	public sealed class clsPM_AssociateTrainingFirstRepose_AED
	{

		#region Private variables used to hold the property values

		private decimal? _PK_PM_AssociateTrainingFirstRepose_AED;
		private decimal? _FK_PM_Site_Information;
		private decimal? _FK_LU_Location;
		private string _AssociateName;
		private string _AssociateTitle;
		private DateTime? _AssociateTrainingDate;
		private string _Notes_Comments;
		private DateTime? _Update_Date;
		private string _Updated_By;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_PM_AssociateTrainingFirstRepose_AED value.
		/// </summary>
		public decimal? PK_PM_AssociateTrainingFirstRepose_AED
		{
			get { return _PK_PM_AssociateTrainingFirstRepose_AED; }
			set { _PK_PM_AssociateTrainingFirstRepose_AED = value; }
		}

		/// <summary>
		/// Gets or sets the FK_PM_Site_Information value.
		/// </summary>
		public decimal? FK_PM_Site_Information
		{
			get { return _FK_PM_Site_Information; }
			set { _FK_PM_Site_Information = value; }
		}

		/// <summary>
		/// Gets or sets the FK_LU_Location value.
		/// </summary>
		public decimal? FK_LU_Location
		{
			get { return _FK_LU_Location; }
			set { _FK_LU_Location = value; }
		}

		/// <summary>
		/// Gets or sets the AssociateName value.
		/// </summary>
		public string AssociateName
		{
			get { return _AssociateName; }
			set { _AssociateName = value; }
		}

		/// <summary>
		/// Gets or sets the AssociateTitle value.
		/// </summary>
		public string AssociateTitle
		{
			get { return _AssociateTitle; }
			set { _AssociateTitle = value; }
		}

		/// <summary>
		/// Gets or sets the AssociateTrainingDate value.
		/// </summary>
		public DateTime? AssociateTrainingDate
		{
			get { return _AssociateTrainingDate; }
			set { _AssociateTrainingDate = value; }
		}

		/// <summary>
		/// Gets or sets the Notes_Comments value.
		/// </summary>
		public string Notes_Comments
		{
			get { return _Notes_Comments; }
			set { _Notes_Comments = value; }
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
		/// Gets or sets the Updated_By value.
		/// </summary>
		public string Updated_By
		{
			get { return _Updated_By; }
			set { _Updated_By = value; }
		}


		#endregion

		#region Default Constructors

		/// <summary>
		/// Initializes a new instance of the clsPM_AssociateTrainingFirstRepose_AED class with default value.
		/// </summary>
		public clsPM_AssociateTrainingFirstRepose_AED() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the clsPM_AssociateTrainingFirstRepose_AED class based on Primary Key.
		/// </summary>
		public clsPM_AssociateTrainingFirstRepose_AED(decimal pK_PM_AssociateTrainingFirstRepose_AED) 
		{
			DataTable dtPM_AssociateTrainingFirstRepose_AED = SelectByPK(pK_PM_AssociateTrainingFirstRepose_AED).Tables[0];

			if (dtPM_AssociateTrainingFirstRepose_AED.Rows.Count == 1)
			{
				 SetValue(dtPM_AssociateTrainingFirstRepose_AED.Rows[0]);

			}

		}


		/// <summary>
		/// Initializes a new instance of the clsPM_AssociateTrainingFirstRepose_AED class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drPM_AssociateTrainingFirstRepose_AED) 
		{
				if (drPM_AssociateTrainingFirstRepose_AED["PK_PM_AssociateTrainingFirstRepose_AED"] == DBNull.Value)
					this._PK_PM_AssociateTrainingFirstRepose_AED = null;
				else
					this._PK_PM_AssociateTrainingFirstRepose_AED = (decimal?)drPM_AssociateTrainingFirstRepose_AED["PK_PM_AssociateTrainingFirstRepose_AED"];

				if (drPM_AssociateTrainingFirstRepose_AED["FK_PM_Site_Information"] == DBNull.Value)
					this._FK_PM_Site_Information = null;
				else
					this._FK_PM_Site_Information = (decimal?)drPM_AssociateTrainingFirstRepose_AED["FK_PM_Site_Information"];

				if (drPM_AssociateTrainingFirstRepose_AED["FK_LU_Location"] == DBNull.Value)
					this._FK_LU_Location = null;
				else
					this._FK_LU_Location = (decimal?)drPM_AssociateTrainingFirstRepose_AED["FK_LU_Location"];

				if (drPM_AssociateTrainingFirstRepose_AED["AssociateName"] == DBNull.Value)
					this._AssociateName = null;
				else
					this._AssociateName = (string)drPM_AssociateTrainingFirstRepose_AED["AssociateName"];

				if (drPM_AssociateTrainingFirstRepose_AED["AssociateTitle"] == DBNull.Value)
					this._AssociateTitle = null;
				else
					this._AssociateTitle = (string)drPM_AssociateTrainingFirstRepose_AED["AssociateTitle"];

				if (drPM_AssociateTrainingFirstRepose_AED["AssociateTrainingDate"] == DBNull.Value)
					this._AssociateTrainingDate = null;
				else
					this._AssociateTrainingDate = (DateTime?)drPM_AssociateTrainingFirstRepose_AED["AssociateTrainingDate"];

				if (drPM_AssociateTrainingFirstRepose_AED["Notes_Comments"] == DBNull.Value)
					this._Notes_Comments = null;
				else
					this._Notes_Comments = (string)drPM_AssociateTrainingFirstRepose_AED["Notes_Comments"];

				if (drPM_AssociateTrainingFirstRepose_AED["Update_Date"] == DBNull.Value)
					this._Update_Date = null;
				else
					this._Update_Date = (DateTime?)drPM_AssociateTrainingFirstRepose_AED["Update_Date"];

				if (drPM_AssociateTrainingFirstRepose_AED["Updated_By"] == DBNull.Value)
					this._Updated_By = null;
				else
					this._Updated_By = (string)drPM_AssociateTrainingFirstRepose_AED["Updated_By"];


		}

		#endregion

		/// <summary>
		/// Inserts a record into the PM_AssociateTrainingFirstRepose_AED table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("PM_AssociateTrainingFirstRepose_AEDInsert");

			
			db.AddInParameter(dbCommand, "FK_PM_Site_Information", DbType.Decimal, this._FK_PM_Site_Information);
			
			db.AddInParameter(dbCommand, "FK_LU_Location", DbType.Decimal, this._FK_LU_Location);
			
			if (string.IsNullOrEmpty(this._AssociateName))
				db.AddInParameter(dbCommand, "AssociateName", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "AssociateName", DbType.String, this._AssociateName);
			
			if (string.IsNullOrEmpty(this._AssociateTitle))
				db.AddInParameter(dbCommand, "AssociateTitle", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "AssociateTitle", DbType.String, this._AssociateTitle);
			
			db.AddInParameter(dbCommand, "AssociateTrainingDate", DbType.DateTime, this._AssociateTrainingDate);
			
			if (string.IsNullOrEmpty(this._Notes_Comments))
				db.AddInParameter(dbCommand, "Notes_Comments", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Notes_Comments", DbType.String, this._Notes_Comments);
			
			db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);
			
			if (string.IsNullOrEmpty(this._Updated_By))
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the PM_AssociateTrainingFirstRepose_AED table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		public DataSet SelectByPK(decimal pK_PM_AssociateTrainingFirstRepose_AED)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("PM_AssociateTrainingFirstRepose_AEDSelectByPK");

			db.AddInParameter(dbCommand, "PK_PM_AssociateTrainingFirstRepose_AED", DbType.Decimal, pK_PM_AssociateTrainingFirstRepose_AED);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the PM_AssociateTrainingFirstRepose_AED table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("PM_AssociateTrainingFirstRepose_AEDSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the PM_AssociateTrainingFirstRepose_AED table.
		/// </summary>
		public void Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("PM_AssociateTrainingFirstRepose_AEDUpdate");

			
			db.AddInParameter(dbCommand, "PK_PM_AssociateTrainingFirstRepose_AED", DbType.Decimal, this._PK_PM_AssociateTrainingFirstRepose_AED);
			
			db.AddInParameter(dbCommand, "FK_PM_Site_Information", DbType.Decimal, this._FK_PM_Site_Information);
			
			db.AddInParameter(dbCommand, "FK_LU_Location", DbType.Decimal, this._FK_LU_Location);
			
			if (string.IsNullOrEmpty(this._AssociateName))
				db.AddInParameter(dbCommand, "AssociateName", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "AssociateName", DbType.String, this._AssociateName);
			
			if (string.IsNullOrEmpty(this._AssociateTitle))
				db.AddInParameter(dbCommand, "AssociateTitle", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "AssociateTitle", DbType.String, this._AssociateTitle);
			
			db.AddInParameter(dbCommand, "AssociateTrainingDate", DbType.DateTime, this._AssociateTrainingDate);
			
			if (string.IsNullOrEmpty(this._Notes_Comments))
				db.AddInParameter(dbCommand, "Notes_Comments", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Notes_Comments", DbType.String, this._Notes_Comments);
			
			db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);
			
			if (string.IsNullOrEmpty(this._Updated_By))
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the PM_AssociateTrainingFirstRepose_AED table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_PM_AssociateTrainingFirstRepose_AED)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("PM_AssociateTrainingFirstRepose_AEDDeleteByPK");

			db.AddInParameter(dbCommand, "PK_PM_AssociateTrainingFirstRepose_AED", DbType.Decimal, pK_PM_AssociateTrainingFirstRepose_AED);

			db.ExecuteNonQuery(dbCommand);
		}

        /// <summary>
        /// Selects the by fk site information.
        /// </summary>
        /// <param name="fK_PM_Site_Information">The f k pm site information.</param>
        /// <returns></returns>
        public static DataSet SelectByFK_SiteInfo(decimal fK_PM_Site_Information)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("PM_AssociateTrainingFirstRepose_AEDSelectByFK_SiteInfo");

            db.AddInParameter(dbCommand, "FK_PM_Site_Information", DbType.Decimal, fK_PM_Site_Information);

            return db.ExecuteDataSet(dbCommand);
        }
	}
}
