using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for PM_Hazardous_Waste_Codes_Mapping table.
	/// </summary>
	public sealed class clsPM_Hazardous_Waste_Codes_Mapping
	{

		#region Private variables used to hold the property values

		private decimal? _PK_PM_Hazardous_Waste_Codes_Mapping;
		private decimal? _FK_PM_Waste_Removal;
		private decimal? _FK_LU_PM_Hazardous_Waste_Codes;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_PM_Hazardous_Waste_Codes_Mapping value.
		/// </summary>
		public decimal? PK_PM_Hazardous_Waste_Codes_Mapping
		{
			get { return _PK_PM_Hazardous_Waste_Codes_Mapping; }
			set { _PK_PM_Hazardous_Waste_Codes_Mapping = value; }
		}

		/// <summary>
		/// Gets or sets the FK_PM_Waste_Removal value.
		/// </summary>
		public decimal? FK_PM_Waste_Removal
		{
			get { return _FK_PM_Waste_Removal; }
			set { _FK_PM_Waste_Removal = value; }
		}

		/// <summary>
		/// Gets or sets the FK_LU_PM_Hazardous_Waste_Codes value.
		/// </summary>
		public decimal? FK_LU_PM_Hazardous_Waste_Codes
		{
			get { return _FK_LU_PM_Hazardous_Waste_Codes; }
			set { _FK_LU_PM_Hazardous_Waste_Codes = value; }
		}


		#endregion

		#region Default Constructors

		/// <summary>
		/// Initializes a new instance of the clsPM_Hazardous_Waste_Codes_Mapping class with default value.
		/// </summary>
		public clsPM_Hazardous_Waste_Codes_Mapping() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the clsPM_Hazardous_Waste_Codes_Mapping class based on Primary Key.
		/// </summary>
		public clsPM_Hazardous_Waste_Codes_Mapping(decimal pK_PM_Hazardous_Waste_Codes_Mapping) 
		{
			DataTable dtPM_Hazardous_Waste_Codes_Mapping = SelectByPK(pK_PM_Hazardous_Waste_Codes_Mapping).Tables[0];

			if (dtPM_Hazardous_Waste_Codes_Mapping.Rows.Count == 1)
			{
				 SetValue(dtPM_Hazardous_Waste_Codes_Mapping.Rows[0]);

			}

		}


		/// <summary>
		/// Initializes a new instance of the clsPM_Hazardous_Waste_Codes_Mapping class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drPM_Hazardous_Waste_Codes_Mapping) 
		{
				if (drPM_Hazardous_Waste_Codes_Mapping["PK_PM_Hazardous_Waste_Codes_Mapping"] == DBNull.Value)
					this._PK_PM_Hazardous_Waste_Codes_Mapping = null;
				else
					this._PK_PM_Hazardous_Waste_Codes_Mapping = (decimal?)drPM_Hazardous_Waste_Codes_Mapping["PK_PM_Hazardous_Waste_Codes_Mapping"];

				if (drPM_Hazardous_Waste_Codes_Mapping["FK_PM_Waste_Removal"] == DBNull.Value)
					this._FK_PM_Waste_Removal = null;
				else
					this._FK_PM_Waste_Removal = (decimal?)drPM_Hazardous_Waste_Codes_Mapping["FK_PM_Waste_Removal"];

				if (drPM_Hazardous_Waste_Codes_Mapping["FK_LU_PM_Hazardous_Waste_Codes"] == DBNull.Value)
					this._FK_LU_PM_Hazardous_Waste_Codes = null;
				else
					this._FK_LU_PM_Hazardous_Waste_Codes = (decimal?)drPM_Hazardous_Waste_Codes_Mapping["FK_LU_PM_Hazardous_Waste_Codes"];


		}

		#endregion

		/// <summary>
		/// Inserts a record into the PM_Hazardous_Waste_Codes_Mapping table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("PM_Hazardous_Waste_Codes_MappingInsert");

			
			db.AddInParameter(dbCommand, "FK_PM_Waste_Removal", DbType.Decimal, this._FK_PM_Waste_Removal);
			
			db.AddInParameter(dbCommand, "FK_LU_PM_Hazardous_Waste_Codes", DbType.Decimal, this._FK_LU_PM_Hazardous_Waste_Codes);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

        /// <summary>
        /// Inserts a record into the PM_Hazardous_Waste_Codes_Mapping table.
        /// </summary>
        /// <returns></returns>
        public int Insert(decimal FK_PM_Waste_Removal, string FK_LU_PM_Hazardous_Waste_Codes)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("PM_Hazardous_Waste_Codes_MappingMultiInsert");

            db.AddInParameter(dbCommand, "FK_PM_Waste_Removal", DbType.Decimal, FK_PM_Waste_Removal);
            db.AddInParameter(dbCommand, "FK_LU_PM_Hazardous_Waste_Codes", DbType.String, FK_LU_PM_Hazardous_Waste_Codes);

            // Execute the query and return the new identity value
            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
        }

		/// <summary>
		/// Selects a single record from the PM_Hazardous_Waste_Codes_Mapping table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		private DataSet SelectByPK(decimal pK_PM_Hazardous_Waste_Codes_Mapping)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("PM_Hazardous_Waste_Codes_MappingSelectByPK");

			db.AddInParameter(dbCommand, "PK_PM_Hazardous_Waste_Codes_Mapping", DbType.Decimal, pK_PM_Hazardous_Waste_Codes_Mapping);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the PM_Hazardous_Waste_Codes_Mapping table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("PM_Hazardous_Waste_Codes_MappingSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the PM_Hazardous_Waste_Codes_Mapping table.
		/// </summary>
		public void Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("PM_Hazardous_Waste_Codes_MappingUpdate");

			
			db.AddInParameter(dbCommand, "PK_PM_Hazardous_Waste_Codes_Mapping", DbType.Decimal, this._PK_PM_Hazardous_Waste_Codes_Mapping);
			
			db.AddInParameter(dbCommand, "FK_PM_Waste_Removal", DbType.Decimal, this._FK_PM_Waste_Removal);
			
			db.AddInParameter(dbCommand, "FK_LU_PM_Hazardous_Waste_Codes", DbType.Decimal, this._FK_LU_PM_Hazardous_Waste_Codes);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the PM_Hazardous_Waste_Codes_Mapping table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_PM_Hazardous_Waste_Codes_Mapping)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("PM_Hazardous_Waste_Codes_MappingDeleteByPK");

			db.AddInParameter(dbCommand, "PK_PM_Hazardous_Waste_Codes_Mapping", DbType.Decimal, pK_PM_Hazardous_Waste_Codes_Mapping);

			db.ExecuteNonQuery(dbCommand);
		}

        /// <summary>
        /// Selects a single record from the PM_Hazardous_Waste_Codes_Mapping table By FK_PM_Waste_Removal.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectBy_FK_PM_Waste_Removal(decimal FK_PM_Waste_Removal)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("PM_Hazardous_Waste_Codes_Mapping_SelectByFK");

            db.AddInParameter(dbCommand, "FK_PM_Waste_Removal", DbType.Decimal, FK_PM_Waste_Removal);

            return db.ExecuteDataSet(dbCommand);
        }
	}
}
