using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for PM_FirstRepose_AEDEquipment table.
	/// </summary>
	public sealed class clsPM_FirstRepose_AEDEquipment
	{

		#region Private variables used to hold the property values

		private decimal? _PK_PM_FirstRepose_AEDEquipment;
		private decimal? _FK_PM_Site_Information;
		private decimal? _FK_LU_Location;
		private string _Store_Service;
		private string _AEDManufacturer;
		private decimal? _FK_LU_AED_Location;
		private DateTime? _AEDInstallDate;
		private string _AssociateName;
		private string _AssociateTitle;
		private DateTime? _AssociateTrainingDate;
		private string _Notes_Comments;
		private DateTime? _Update_Date;
		private string _Updated_By;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_PM_FirstRepose_AEDEquipment value.
		/// </summary>
		public decimal? PK_PM_FirstRepose_AEDEquipment
		{
			get { return _PK_PM_FirstRepose_AEDEquipment; }
			set { _PK_PM_FirstRepose_AEDEquipment = value; }
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
		/// Gets or sets the Store_Service value.
		/// </summary>
		public string Store_Service
		{
			get { return _Store_Service; }
			set { _Store_Service = value; }
		}

		/// <summary>
		/// Gets or sets the AEDManufacturer value.
		/// </summary>
		public string AEDManufacturer
		{
			get { return _AEDManufacturer; }
			set { _AEDManufacturer = value; }
		}

		/// <summary>
		/// Gets or sets the FK_LU_AED_Location value.
		/// </summary>
		public decimal? FK_LU_AED_Location
		{
			get { return _FK_LU_AED_Location; }
			set { _FK_LU_AED_Location = value; }
		}

		/// <summary>
		/// Gets or sets the AEDInstallDate value.
		/// </summary>
		public DateTime? AEDInstallDate
		{
			get { return _AEDInstallDate; }
			set { _AEDInstallDate = value; }
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
		/// Initializes a new instance of the clsPM_FirstRepose_AEDEquipment class with default value.
		/// </summary>
		public clsPM_FirstRepose_AEDEquipment() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the clsPM_FirstRepose_AEDEquipment class based on Primary Key.
		/// </summary>
		public clsPM_FirstRepose_AEDEquipment(decimal pK_PM_FirstRepose_AEDEquipment) 
		{
			DataTable dtPM_FirstRepose_AEDEquipment = SelectByPK(pK_PM_FirstRepose_AEDEquipment).Tables[0];

			if (dtPM_FirstRepose_AEDEquipment.Rows.Count == 1)
			{
				 SetValue(dtPM_FirstRepose_AEDEquipment.Rows[0]);

			}

		}


		/// <summary>
		/// Initializes a new instance of the clsPM_FirstRepose_AEDEquipment class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drPM_FirstRepose_AEDEquipment) 
		{
				if (drPM_FirstRepose_AEDEquipment["PK_PM_FirstRepose_AEDEquipment"] == DBNull.Value)
					this._PK_PM_FirstRepose_AEDEquipment = null;
				else
					this._PK_PM_FirstRepose_AEDEquipment = (decimal?)drPM_FirstRepose_AEDEquipment["PK_PM_FirstRepose_AEDEquipment"];

				if (drPM_FirstRepose_AEDEquipment["FK_PM_Site_Information"] == DBNull.Value)
					this._FK_PM_Site_Information = null;
				else
					this._FK_PM_Site_Information = (decimal?)drPM_FirstRepose_AEDEquipment["FK_PM_Site_Information"];

				if (drPM_FirstRepose_AEDEquipment["FK_LU_Location"] == DBNull.Value)
					this._FK_LU_Location = null;
				else
					this._FK_LU_Location = (decimal?)drPM_FirstRepose_AEDEquipment["FK_LU_Location"];

				if (drPM_FirstRepose_AEDEquipment["Store_Service"] == DBNull.Value)
					this._Store_Service = null;
				else
					this._Store_Service = (string)drPM_FirstRepose_AEDEquipment["Store_Service"];

				if (drPM_FirstRepose_AEDEquipment["AEDManufacturer"] == DBNull.Value)
					this._AEDManufacturer = null;
				else
					this._AEDManufacturer = (string)drPM_FirstRepose_AEDEquipment["AEDManufacturer"];

				if (drPM_FirstRepose_AEDEquipment["FK_LU_AED_Location"] == DBNull.Value)
					this._FK_LU_AED_Location = null;
				else
					this._FK_LU_AED_Location = (decimal?)drPM_FirstRepose_AEDEquipment["FK_LU_AED_Location"];

				if (drPM_FirstRepose_AEDEquipment["AEDInstallDate"] == DBNull.Value)
					this._AEDInstallDate = null;
				else
					this._AEDInstallDate = (DateTime?)drPM_FirstRepose_AEDEquipment["AEDInstallDate"];

				if (drPM_FirstRepose_AEDEquipment["AssociateName"] == DBNull.Value)
					this._AssociateName = null;
				else
					this._AssociateName = (string)drPM_FirstRepose_AEDEquipment["AssociateName"];

				if (drPM_FirstRepose_AEDEquipment["AssociateTitle"] == DBNull.Value)
					this._AssociateTitle = null;
				else
					this._AssociateTitle = (string)drPM_FirstRepose_AEDEquipment["AssociateTitle"];

				if (drPM_FirstRepose_AEDEquipment["AssociateTrainingDate"] == DBNull.Value)
					this._AssociateTrainingDate = null;
				else
					this._AssociateTrainingDate = (DateTime?)drPM_FirstRepose_AEDEquipment["AssociateTrainingDate"];

				if (drPM_FirstRepose_AEDEquipment["Notes_Comments"] == DBNull.Value)
					this._Notes_Comments = null;
				else
					this._Notes_Comments = (string)drPM_FirstRepose_AEDEquipment["Notes_Comments"];

				if (drPM_FirstRepose_AEDEquipment["Update_Date"] == DBNull.Value)
					this._Update_Date = null;
				else
					this._Update_Date = (DateTime?)drPM_FirstRepose_AEDEquipment["Update_Date"];

				if (drPM_FirstRepose_AEDEquipment["Updated_By"] == DBNull.Value)
					this._Updated_By = null;
				else
					this._Updated_By = (string)drPM_FirstRepose_AEDEquipment["Updated_By"];


		}

		#endregion

		/// <summary>
		/// Inserts a record into the PM_FirstRepose_AEDEquipment table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("PM_FirstRepose_AEDEquipmentInsert");

			
			db.AddInParameter(dbCommand, "FK_PM_Site_Information", DbType.Decimal, this._FK_PM_Site_Information);
			
			db.AddInParameter(dbCommand, "FK_LU_Location", DbType.Decimal, this._FK_LU_Location);
			
			if (string.IsNullOrEmpty(this._Store_Service))
				db.AddInParameter(dbCommand, "Store_Service", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Store_Service", DbType.String, this._Store_Service);
			
			if (string.IsNullOrEmpty(this._AEDManufacturer))
				db.AddInParameter(dbCommand, "AEDManufacturer", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "AEDManufacturer", DbType.String, this._AEDManufacturer);
			
			db.AddInParameter(dbCommand, "FK_LU_AED_Location", DbType.Decimal, this._FK_LU_AED_Location);
			
			db.AddInParameter(dbCommand, "AEDInstallDate", DbType.DateTime, this._AEDInstallDate);
			
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
		/// Selects a single record from the PM_FirstRepose_AEDEquipment table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		private DataSet SelectByPK(decimal pK_PM_FirstRepose_AEDEquipment)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("PM_FirstRepose_AEDEquipmentSelectByPK");

			db.AddInParameter(dbCommand, "PK_PM_FirstRepose_AEDEquipment", DbType.Decimal, pK_PM_FirstRepose_AEDEquipment);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the PM_FirstRepose_AEDEquipment table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("PM_FirstRepose_AEDEquipmentSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the PM_FirstRepose_AEDEquipment table.
		/// </summary>
		public void Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("PM_FirstRepose_AEDEquipmentUpdate");

			
			db.AddInParameter(dbCommand, "PK_PM_FirstRepose_AEDEquipment", DbType.Decimal, this._PK_PM_FirstRepose_AEDEquipment);
			
			db.AddInParameter(dbCommand, "FK_PM_Site_Information", DbType.Decimal, this._FK_PM_Site_Information);
			
			db.AddInParameter(dbCommand, "FK_LU_Location", DbType.Decimal, this._FK_LU_Location);
			
			if (string.IsNullOrEmpty(this._Store_Service))
				db.AddInParameter(dbCommand, "Store_Service", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Store_Service", DbType.String, this._Store_Service);
			
			if (string.IsNullOrEmpty(this._AEDManufacturer))
				db.AddInParameter(dbCommand, "AEDManufacturer", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "AEDManufacturer", DbType.String, this._AEDManufacturer);
			
			db.AddInParameter(dbCommand, "FK_LU_AED_Location", DbType.Decimal, this._FK_LU_AED_Location);
			
			db.AddInParameter(dbCommand, "AEDInstallDate", DbType.DateTime, this._AEDInstallDate);
			
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
		/// Deletes a record from the PM_FirstRepose_AEDEquipment table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_PM_FirstRepose_AEDEquipment)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("PM_FirstRepose_AEDEquipmentDeleteByPK");

			db.AddInParameter(dbCommand, "PK_PM_FirstRepose_AEDEquipment", DbType.Decimal, pK_PM_FirstRepose_AEDEquipment);

			db.ExecuteNonQuery(dbCommand);
		}

        /// <summary>
        /// Selects a single record from the PM_Respiratory_Protection table by a primary key. used for view mode
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectViewByPK(decimal pK_PM_FirstRepose_AEDEquipment)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("PM_FirstRepose_AEDEquipmentSelectViewByPK");

            db.AddInParameter(dbCommand, "PK_PM_FirstRepose_AEDEquipment", DbType.Decimal, pK_PM_FirstRepose_AEDEquipment);

            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet SelectByFK_SiteInfo(decimal fK_PM_Site_Information)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("PM_FirstRepose_AEDEquipmentSelectByFK_SiteInfo");

            db.AddInParameter(dbCommand, "FK_PM_Site_Information", DbType.Decimal, fK_PM_Site_Information);

            return db.ExecuteDataSet(dbCommand);
        }
	}
}
