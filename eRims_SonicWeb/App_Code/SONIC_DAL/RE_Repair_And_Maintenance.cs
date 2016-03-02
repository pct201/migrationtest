using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for RE_Repair_Maintenance table.
	/// </summary>
	public sealed class RE_Repair_And_Maintenance
	{

		#region Private variables used to hold the property values

		private decimal? _PK_RE_Repair_Maintenance;
		private decimal? _FK_RE_Information;
		private decimal? _FK_LU_Responsibilie_Party_HVAC_Repairs;
		private decimal? _FK_LU_Responsibilie_Party_HVAC_Capital;
		private decimal? _FK_LU_Responsibilie_Party_Roof_Repairs;
		private decimal? _FK_LU_Responsibilie_Party_Roof_Capital;
		private decimal? _FK_LU_Responsibilie_Party_Other_Repairs;
		private string _Maintenance_Notes;
		private string _Updated_By;
		private DateTime? _Update_Date;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_RE_Repair_Maintenance value.
		/// </summary>
		public decimal? PK_RE_Repair_Maintenance
		{
			get { return _PK_RE_Repair_Maintenance; }
			set { _PK_RE_Repair_Maintenance = value; }
		}

		/// <summary>
		/// Gets or sets the FK_RE_Information value.
		/// </summary>
		public decimal? FK_RE_Information
		{
			get { return _FK_RE_Information; }
			set { _FK_RE_Information = value; }
		}

		/// <summary>
		/// Gets or sets the FK_LU_Responsibilie_Party_HVAC_Repairs value.
		/// </summary>
		public decimal? FK_LU_Responsibilie_Party_HVAC_Repairs
		{
			get { return _FK_LU_Responsibilie_Party_HVAC_Repairs; }
			set { _FK_LU_Responsibilie_Party_HVAC_Repairs = value; }
		}

		/// <summary>
		/// Gets or sets the FK_LU_Responsibilie_Party_HVAC_Capital value.
		/// </summary>
		public decimal? FK_LU_Responsibilie_Party_HVAC_Capital
		{
			get { return _FK_LU_Responsibilie_Party_HVAC_Capital; }
			set { _FK_LU_Responsibilie_Party_HVAC_Capital = value; }
		}

		/// <summary>
		/// Gets or sets the FK_LU_Responsibilie_Party_Roof_Repairs value.
		/// </summary>
		public decimal? FK_LU_Responsibilie_Party_Roof_Repairs
		{
			get { return _FK_LU_Responsibilie_Party_Roof_Repairs; }
			set { _FK_LU_Responsibilie_Party_Roof_Repairs = value; }
		}

		/// <summary>
		/// Gets or sets the FK_LU_Responsibilie_Party_Roof_Capital value.
		/// </summary>
		public decimal? FK_LU_Responsibilie_Party_Roof_Capital
		{
			get { return _FK_LU_Responsibilie_Party_Roof_Capital; }
			set { _FK_LU_Responsibilie_Party_Roof_Capital = value; }
		}

		/// <summary>
		/// Gets or sets the FK_LU_Responsibilie_Party_Other_Repairs value.
		/// </summary>
		public decimal? FK_LU_Responsibilie_Party_Other_Repairs
		{
			get { return _FK_LU_Responsibilie_Party_Other_Repairs; }
			set { _FK_LU_Responsibilie_Party_Other_Repairs = value; }
		}

		/// <summary>
		/// Gets or sets the Maintenance_Notes value.
		/// </summary>
		public string Maintenance_Notes
		{
			get { return _Maintenance_Notes; }
			set { _Maintenance_Notes = value; }
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
		/// Initializes a new instance of the clsRE_Repair_Maintenance class with default value.
		/// </summary>
		public RE_Repair_And_Maintenance() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the clsRE_Repair_Maintenance class based on Primary Key.
		/// </summary>
        public RE_Repair_And_Maintenance(decimal pK_RE_Repair_Maintenance) 
		{
			DataTable dtRE_Repair_Maintenance = SelectByPK(pK_RE_Repair_Maintenance).Tables[0];

			if (dtRE_Repair_Maintenance.Rows.Count == 1)
			{
				 SetValue(dtRE_Repair_Maintenance.Rows[0]);

			}

		}


		/// <summary>
		/// Initializes a new instance of the clsRE_Repair_Maintenance class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drRE_Repair_Maintenance) 
		{
				if (drRE_Repair_Maintenance["PK_RE_Repair_Maintenance"] == DBNull.Value)
					this._PK_RE_Repair_Maintenance = null;
				else
					this._PK_RE_Repair_Maintenance = (decimal?)drRE_Repair_Maintenance["PK_RE_Repair_Maintenance"];

				if (drRE_Repair_Maintenance["FK_RE_Information"] == DBNull.Value)
					this._FK_RE_Information = null;
				else
					this._FK_RE_Information = (decimal?)drRE_Repair_Maintenance["FK_RE_Information"];

				if (drRE_Repair_Maintenance["FK_LU_Responsibilie_Party_HVAC_Repairs"] == DBNull.Value)
					this._FK_LU_Responsibilie_Party_HVAC_Repairs = null;
				else
					this._FK_LU_Responsibilie_Party_HVAC_Repairs = (decimal?)drRE_Repair_Maintenance["FK_LU_Responsibilie_Party_HVAC_Repairs"];

				if (drRE_Repair_Maintenance["FK_LU_Responsibilie_Party_HVAC_Capital"] == DBNull.Value)
					this._FK_LU_Responsibilie_Party_HVAC_Capital = null;
				else
					this._FK_LU_Responsibilie_Party_HVAC_Capital = (decimal?)drRE_Repair_Maintenance["FK_LU_Responsibilie_Party_HVAC_Capital"];

				if (drRE_Repair_Maintenance["FK_LU_Responsibilie_Party_Roof_Repairs"] == DBNull.Value)
					this._FK_LU_Responsibilie_Party_Roof_Repairs = null;
				else
					this._FK_LU_Responsibilie_Party_Roof_Repairs = (decimal?)drRE_Repair_Maintenance["FK_LU_Responsibilie_Party_Roof_Repairs"];

				if (drRE_Repair_Maintenance["FK_LU_Responsibilie_Party_Roof_Capital"] == DBNull.Value)
					this._FK_LU_Responsibilie_Party_Roof_Capital = null;
				else
					this._FK_LU_Responsibilie_Party_Roof_Capital = (decimal?)drRE_Repair_Maintenance["FK_LU_Responsibilie_Party_Roof_Capital"];

				if (drRE_Repair_Maintenance["FK_LU_Responsibilie_Party_Other_Repairs"] == DBNull.Value)
					this._FK_LU_Responsibilie_Party_Other_Repairs = null;
				else
					this._FK_LU_Responsibilie_Party_Other_Repairs = (decimal?)drRE_Repair_Maintenance["FK_LU_Responsibilie_Party_Other_Repairs"];

				if (drRE_Repair_Maintenance["Maintenance_Notes"] == DBNull.Value)
					this._Maintenance_Notes = null;
				else
					this._Maintenance_Notes = (string)drRE_Repair_Maintenance["Maintenance_Notes"];

				if (drRE_Repair_Maintenance["Updated_By"] == DBNull.Value)
					this._Updated_By = null;
				else
					this._Updated_By = (string)drRE_Repair_Maintenance["Updated_By"];

				if (drRE_Repair_Maintenance["Update_Date"] == DBNull.Value)
					this._Update_Date = null;
				else
					this._Update_Date = (DateTime?)drRE_Repair_Maintenance["Update_Date"];


		}

		#endregion

		/// <summary>
		/// Inserts a record into the RE_Repair_Maintenance table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("RE_Repair_MaintenanceInsert");

			
			db.AddInParameter(dbCommand, "FK_RE_Information", DbType.Decimal, this._FK_RE_Information);
			
			db.AddInParameter(dbCommand, "FK_LU_Responsibilie_Party_HVAC_Repairs", DbType.Decimal, this._FK_LU_Responsibilie_Party_HVAC_Repairs);
			
			db.AddInParameter(dbCommand, "FK_LU_Responsibilie_Party_HVAC_Capital", DbType.Decimal, this._FK_LU_Responsibilie_Party_HVAC_Capital);
			
			db.AddInParameter(dbCommand, "FK_LU_Responsibilie_Party_Roof_Repairs", DbType.Decimal, this._FK_LU_Responsibilie_Party_Roof_Repairs);
			
			db.AddInParameter(dbCommand, "FK_LU_Responsibilie_Party_Roof_Capital", DbType.Decimal, this._FK_LU_Responsibilie_Party_Roof_Capital);
			
			db.AddInParameter(dbCommand, "FK_LU_Responsibilie_Party_Other_Repairs", DbType.Decimal, this._FK_LU_Responsibilie_Party_Other_Repairs);
			
			if (string.IsNullOrEmpty(this._Maintenance_Notes))
				db.AddInParameter(dbCommand, "Maintenance_Notes", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Maintenance_Notes", DbType.String, this._Maintenance_Notes);
			
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
		/// Selects a single record from the RE_Repair_Maintenance table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		private DataSet SelectByPK(decimal pK_RE_Repair_Maintenance)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("RE_Repair_MaintenanceSelectByPK");

			db.AddInParameter(dbCommand, "PK_RE_Repair_Maintenance", DbType.Decimal, pK_RE_Repair_Maintenance);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the RE_Repair_Maintenance table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("RE_Repair_MaintenanceSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the RE_Repair_Maintenance table.
		/// </summary>
		public void Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("RE_Repair_MaintenanceUpdate");

			
			db.AddInParameter(dbCommand, "PK_RE_Repair_Maintenance", DbType.Decimal, this._PK_RE_Repair_Maintenance);
			
			db.AddInParameter(dbCommand, "FK_RE_Information", DbType.Decimal, this._FK_RE_Information);
			
			db.AddInParameter(dbCommand, "FK_LU_Responsibilie_Party_HVAC_Repairs", DbType.Decimal, this._FK_LU_Responsibilie_Party_HVAC_Repairs);
			
			db.AddInParameter(dbCommand, "FK_LU_Responsibilie_Party_HVAC_Capital", DbType.Decimal, this._FK_LU_Responsibilie_Party_HVAC_Capital);
			
			db.AddInParameter(dbCommand, "FK_LU_Responsibilie_Party_Roof_Repairs", DbType.Decimal, this._FK_LU_Responsibilie_Party_Roof_Repairs);
			
			db.AddInParameter(dbCommand, "FK_LU_Responsibilie_Party_Roof_Capital", DbType.Decimal, this._FK_LU_Responsibilie_Party_Roof_Capital);
			
			db.AddInParameter(dbCommand, "FK_LU_Responsibilie_Party_Other_Repairs", DbType.Decimal, this._FK_LU_Responsibilie_Party_Other_Repairs);
			
			if (string.IsNullOrEmpty(this._Maintenance_Notes))
				db.AddInParameter(dbCommand, "Maintenance_Notes", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Maintenance_Notes", DbType.String, this._Maintenance_Notes);
			
			if (string.IsNullOrEmpty(this._Updated_By))
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);
			
			db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the RE_Repair_Maintenance table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_RE_Repair_Maintenance)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("RE_Repair_MaintenanceDeleteByPK");

			db.AddInParameter(dbCommand, "PK_RE_Repair_Maintenance", DbType.Decimal, pK_RE_Repair_Maintenance);

			db.ExecuteNonQuery(dbCommand);
		}

        //RE_Repair_MaintenanceSelectByFK
        public static DataSet SelectByFK(decimal fK_RE_Information)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("RE_Repair_MaintenanceSelectByFK");

            db.AddInParameter(dbCommand, "FK_RE_Information", DbType.Decimal, fK_RE_Information);

            return db.ExecuteDataSet(dbCommand);
        }
	}
}
