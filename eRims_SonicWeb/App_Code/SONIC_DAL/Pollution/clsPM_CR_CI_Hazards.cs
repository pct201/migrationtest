using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for PM_CR_CI_Hazards table.
	/// </summary>
	public sealed class clsPM_CR_CI_Hazards
	{

		#region Private variables used to hold the property values

		private decimal? _PK_PM_CR_CI_Hazards;
		private decimal? _FK_PM_CR_Chemical_Inventory;
		private decimal? _FK_LU_Hazard_Type;
		private string _Updated_By;
		private DateTime? _Update_Date;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_PM_CR_CI_Hazards value.
		/// </summary>
		public decimal? PK_PM_CR_CI_Hazards
		{
			get { return _PK_PM_CR_CI_Hazards; }
			set { _PK_PM_CR_CI_Hazards = value; }
		}

		/// <summary>
		/// Gets or sets the FK_PM_CR_Chemical_Inventory value.
		/// </summary>
		public decimal? FK_PM_CR_Chemical_Inventory
		{
			get { return _FK_PM_CR_Chemical_Inventory; }
			set { _FK_PM_CR_Chemical_Inventory = value; }
		}

		/// <summary>
		/// Gets or sets the FK_LU_Hazard_Type value.
		/// </summary>
		public decimal? FK_LU_Hazard_Type
		{
			get { return _FK_LU_Hazard_Type; }
			set { _FK_LU_Hazard_Type = value; }
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
		/// Initializes a new instance of the clsPM_CR_CI_Hazards class with default value.
		/// </summary>
		public clsPM_CR_CI_Hazards() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the clsPM_CR_CI_Hazards class based on Primary Key.
		/// </summary>
		public clsPM_CR_CI_Hazards(decimal pK_PM_CR_CI_Hazards) 
		{
			DataTable dtPM_CR_CI_Hazards = SelectByPK(pK_PM_CR_CI_Hazards).Tables[0];

			if (dtPM_CR_CI_Hazards.Rows.Count == 1)
			{
				 SetValue(dtPM_CR_CI_Hazards.Rows[0]);

			}

		}


		/// <summary>
		/// Initializes a new instance of the clsPM_CR_CI_Hazards class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drPM_CR_CI_Hazards) 
		{
				if (drPM_CR_CI_Hazards["PK_PM_CR_CI_Hazards"] == DBNull.Value)
					this._PK_PM_CR_CI_Hazards = null;
				else
					this._PK_PM_CR_CI_Hazards = (decimal?)drPM_CR_CI_Hazards["PK_PM_CR_CI_Hazards"];

				if (drPM_CR_CI_Hazards["FK_PM_CR_Chemical_Inventory"] == DBNull.Value)
					this._FK_PM_CR_Chemical_Inventory = null;
				else
					this._FK_PM_CR_Chemical_Inventory = (decimal?)drPM_CR_CI_Hazards["FK_PM_CR_Chemical_Inventory"];

				if (drPM_CR_CI_Hazards["FK_LU_Hazard_Type"] == DBNull.Value)
					this._FK_LU_Hazard_Type = null;
				else
					this._FK_LU_Hazard_Type = (decimal?)drPM_CR_CI_Hazards["FK_LU_Hazard_Type"];

				if (drPM_CR_CI_Hazards["Updated_By"] == DBNull.Value)
					this._Updated_By = null;
				else
					this._Updated_By = (string)drPM_CR_CI_Hazards["Updated_By"];

				if (drPM_CR_CI_Hazards["Update_Date"] == DBNull.Value)
					this._Update_Date = null;
				else
					this._Update_Date = (DateTime?)drPM_CR_CI_Hazards["Update_Date"];


		}

		#endregion

		/// <summary>
		/// Inserts a record into the PM_CR_CI_Hazards table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("PM_CR_CI_HazardsInsert");

			
			db.AddInParameter(dbCommand, "FK_PM_CR_Chemical_Inventory", DbType.Decimal, this._FK_PM_CR_Chemical_Inventory);
			
			db.AddInParameter(dbCommand, "FK_LU_Hazard_Type", DbType.Decimal, this._FK_LU_Hazard_Type);
			
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
		/// Selects a single record from the PM_CR_CI_Hazards table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		private DataSet SelectByPK(decimal pK_PM_CR_CI_Hazards)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("PM_CR_CI_HazardsSelectByPK");

			db.AddInParameter(dbCommand, "PK_PM_CR_CI_Hazards", DbType.Decimal, pK_PM_CR_CI_Hazards);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the PM_CR_CI_Hazards table.
		/// </summary>
		/// <returns>DataSet</returns>
        public static DataSet SelectAllByFK(decimal _FK_PM_CR_Chemical_Inventory)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("PM_CR_CI_HazardsSelectAllByFK");
            db.AddInParameter(dbCommand, "FK_PM_CR_Chemical_Inventory", DbType.Decimal, _FK_PM_CR_Chemical_Inventory);
			return db.ExecuteDataSet(dbCommand);
		}
        /// <summary>
        /// Selects all records from the PM_CR_CI_Hazards table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("PM_CR_CI_HazardsSelectAll");           
            return db.ExecuteDataSet(dbCommand);
        }


		/// <summary>
		/// Updates a record in the PM_CR_CI_Hazards table.
		/// </summary>
		public void Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("PM_CR_CI_HazardsUpdate");

			
			db.AddInParameter(dbCommand, "PK_PM_CR_CI_Hazards", DbType.Decimal, this._PK_PM_CR_CI_Hazards);
			
			db.AddInParameter(dbCommand, "FK_PM_CR_Chemical_Inventory", DbType.Decimal, this._FK_PM_CR_Chemical_Inventory);
			
			db.AddInParameter(dbCommand, "FK_LU_Hazard_Type", DbType.Decimal, this._FK_LU_Hazard_Type);
			
			if (string.IsNullOrEmpty(this._Updated_By))
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);
			
			db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the PM_CR_CI_Hazards table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_PM_CR_CI_Hazards)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("PM_CR_CI_HazardsDeleteByPK");

			db.AddInParameter(dbCommand, "PK_PM_CR_CI_Hazards", DbType.Decimal, pK_PM_CR_CI_Hazards);

			db.ExecuteNonQuery(dbCommand);
		}
	}
}
