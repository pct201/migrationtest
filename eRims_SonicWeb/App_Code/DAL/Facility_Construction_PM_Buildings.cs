using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for table Facility_Construction_PM_Buildings
	/// </summary>
	public sealed class Facility_Construction_PM_Buildings
	{

		#region Private variables used to hold the property values

		private decimal? _PK_Facility_Construction_PM_Buildings;
		private decimal? _FK_Facility_Construction_PM;
		private decimal? _FK_Building;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_Facility_Construction_PM_Buildings value.
		/// </summary>
		public decimal? PK_Facility_Construction_PM_Buildings
		{
			get { return _PK_Facility_Construction_PM_Buildings; }
			set { _PK_Facility_Construction_PM_Buildings = value; }
		}

		/// <summary>
		/// Gets or sets the FK_Facility_Construction_PM value.
		/// </summary>
		public decimal? FK_Facility_Construction_PM
		{
			get { return _FK_Facility_Construction_PM; }
			set { _FK_Facility_Construction_PM = value; }
		}

		/// <summary>
		/// Gets or sets the FK_Building value.
		/// </summary>
		public decimal? FK_Building
		{
			get { return _FK_Building; }
			set { _FK_Building = value; }
		}


		#endregion

		#region Default Constructors

		/// <summary>
		/// Initializes a new instance of the Facility_Construction_PM_Buildings class with default value.
		/// </summary>
		public Facility_Construction_PM_Buildings() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the Facility_Construction_PM_Buildings class based on Primary Key.
		/// </summary>
		public Facility_Construction_PM_Buildings(decimal pK_Facility_Construction_PM_Buildings) 
		{
			DataTable dtFacility_Construction_PM_Buildings = Select(pK_Facility_Construction_PM_Buildings).Tables[0];

			if (dtFacility_Construction_PM_Buildings.Rows.Count == 1)
			{
				 SetValue(dtFacility_Construction_PM_Buildings.Rows[0]);

			}

		}


		/// <summary>
		/// Initializes a new instance of the Facility_Construction_PM_Buildings class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drFacility_Construction_PM_Buildings) 
		{
				if (drFacility_Construction_PM_Buildings["PK_Facility_Construction_PM_Buildings"] == DBNull.Value)
					this._PK_Facility_Construction_PM_Buildings = null;
				else
					this._PK_Facility_Construction_PM_Buildings = (decimal?)drFacility_Construction_PM_Buildings["PK_Facility_Construction_PM_Buildings"];

				if (drFacility_Construction_PM_Buildings["FK_Facility_Construction_PM"] == DBNull.Value)
					this._FK_Facility_Construction_PM = null;
				else
					this._FK_Facility_Construction_PM = (decimal?)drFacility_Construction_PM_Buildings["FK_Facility_Construction_PM"];

				if (drFacility_Construction_PM_Buildings["FK_Building"] == DBNull.Value)
					this._FK_Building = null;
				else
					this._FK_Building = (decimal?)drFacility_Construction_PM_Buildings["FK_Building"];


		}

		#endregion

		/// <summary>
		/// Inserts a record into the Facility_Construction_PM_Buildings table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Facility_Construction_PM_BuildingsInsert");

			
			db.AddInParameter(dbCommand, "FK_Facility_Construction_PM", DbType.Decimal, this._FK_Facility_Construction_PM);
			
			db.AddInParameter(dbCommand, "FK_Building", DbType.Decimal, this._FK_Building);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the Facility_Construction_PM_Buildings table.
		/// </summary>
		/// <returns>DataSet</returns>
		private DataSet Select(decimal pK_Facility_Construction_PM_Buildings)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Facility_Construction_PM_BuildingsSelect");

			db.AddInParameter(dbCommand, "PK_Facility_Construction_PM_Buildings", DbType.Decimal, pK_Facility_Construction_PM_Buildings);

			return db.ExecuteDataSet(dbCommand);
		}

        /// <summary>
        /// Selects a single record from the Facility_Construction_PM_Buildings table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectBuildingsBasedOnConstrctionProjectId(decimal FK_Facility_Construction_PM)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("SelectBuildingsBasedOnConstrctionProjectId");

            db.AddInParameter(dbCommand, "FK_Facility_Construction_PM", DbType.Decimal, FK_Facility_Construction_PM);

            return db.ExecuteDataSet(dbCommand);
        }

		/// <summary>
		/// Selects all records from the Facility_Construction_PM_Buildings table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Facility_Construction_PM_BuildingsSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the Facility_Construction_PM_Buildings table.
		/// </summary>
		public void Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Facility_Construction_PM_BuildingsUpdate");

			
			db.AddInParameter(dbCommand, "PK_Facility_Construction_PM_Buildings", DbType.Decimal, this._PK_Facility_Construction_PM_Buildings);
			
			db.AddInParameter(dbCommand, "FK_Facility_Construction_PM", DbType.Decimal, this._FK_Facility_Construction_PM);
			
			db.AddInParameter(dbCommand, "FK_Building", DbType.Decimal, this._FK_Building);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the Facility_Construction_PM_Buildings table by a composite primary key.
		/// </summary>
		public static void Delete(decimal pK_Facility_Construction_PM_Buildings)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Facility_Construction_PM_BuildingsDelete");

			db.AddInParameter(dbCommand, "PK_Facility_Construction_PM_Buildings", DbType.Decimal, pK_Facility_Construction_PM_Buildings);

			db.ExecuteNonQuery(dbCommand);
		}

        /// <summary>
        /// Deletes a record from the Facility_Construction_PM_Buildings table by a composite primary key.
        /// </summary>
        public static void DeleteBuildingsByConstructionProjectId(decimal FK_Facility_Construction_PM)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("DeleteBuildingsByConstructionProjectId");

            db.AddInParameter(dbCommand, "FK_Facility_Construction_PM", DbType.Decimal, FK_Facility_Construction_PM);

            db.ExecuteNonQuery(dbCommand);
        }
	}
}
