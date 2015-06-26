using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for clsLU_Facility_Specific_Location table.
	/// </summary>
	public sealed class clsLU_Facility_Specific_Location
	{
       #region Private variables used to hold the property values

		private decimal? _PK_LU_Facility_Specific_Location;
		private decimal? _FK_LU_Facility_Area;
		private string _Description;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_LU_Facility_Specific_Location value.
		/// </summary>
		public decimal? PK_LU_Facility_Specific_Location
		{
			get { return _PK_LU_Facility_Specific_Location; }
			set { _PK_LU_Facility_Specific_Location = value; }
		}

		/// <summary>
		/// Gets or sets the FK_LU_Facility_Area value.
		/// </summary>
		public decimal? FK_LU_Facility_Area
		{
			get { return _FK_LU_Facility_Area; }
			set { _FK_LU_Facility_Area = value; }
		}

		/// <summary>
		/// Gets or sets the Description value.
		/// </summary>
		public string Description
		{
			get { return _Description; }
			set { _Description = value; }
		}


		#endregion

		#region Default Constructors

		/// <summary>
		/// Initializes a new instance of the LU_Facility_Specific_Location class with default value.
		/// </summary>
		public clsLU_Facility_Specific_Location() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the LU_Facility_Specific_Location class based on Primary Key.
		/// </summary>
        public clsLU_Facility_Specific_Location(decimal pK_LU_Facility_Specific_Location) 
		{
			DataTable dtLU_Facility_Specific_Location = Select(pK_LU_Facility_Specific_Location).Tables[0];

			if (dtLU_Facility_Specific_Location.Rows.Count == 1)
			{
				 SetValue(dtLU_Facility_Specific_Location.Rows[0]);

			}

		}


		/// <summary>
		/// Initializes a new instance of the LU_Facility_Specific_Location class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drLU_Facility_Specific_Location) 
		{
				if (drLU_Facility_Specific_Location["PK_LU_Facility_Specific_Location"] == DBNull.Value)
					this._PK_LU_Facility_Specific_Location = null;
				else
					this._PK_LU_Facility_Specific_Location = (decimal?)drLU_Facility_Specific_Location["PK_LU_Facility_Specific_Location"];

				if (drLU_Facility_Specific_Location["FK_LU_Facility_Area"] == DBNull.Value)
					this._FK_LU_Facility_Area = null;
				else
					this._FK_LU_Facility_Area = (decimal?)drLU_Facility_Specific_Location["FK_LU_Facility_Area"];

				if (drLU_Facility_Specific_Location["Description"] == DBNull.Value)
					this._Description = null;
				else
					this._Description = (string)drLU_Facility_Specific_Location["Description"];


		}

		#endregion

		/// <summary>
		/// Inserts a record into the LU_Facility_Specific_Location table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Facility_Specific_LocationInsert");

			
			db.AddInParameter(dbCommand, "FK_LU_Facility_Area", DbType.Decimal, this._FK_LU_Facility_Area);
			
			if (string.IsNullOrEmpty(this._Description))
				db.AddInParameter(dbCommand, "Description", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Description", DbType.String, this._Description);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the LU_Facility_Specific_Location table.
		/// </summary>
		/// <returns>DataSet</returns>
		private DataSet Select(decimal pK_LU_Facility_Specific_Location)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Facility_Specific_LocationSelect");

			db.AddInParameter(dbCommand, "PK_LU_Facility_Specific_Location", DbType.Decimal, pK_LU_Facility_Specific_Location);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the LU_Facility_Specific_Location table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Facility_Specific_LocationSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the LU_Facility_Specific_Location table.
		/// </summary>
		public Decimal Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Facility_Specific_LocationUpdate");

			
			db.AddInParameter(dbCommand, "PK_LU_Facility_Specific_Location", DbType.Decimal, this._PK_LU_Facility_Specific_Location);
			
			db.AddInParameter(dbCommand, "FK_LU_Facility_Area", DbType.Decimal, this._FK_LU_Facility_Area);
			
			if (string.IsNullOrEmpty(this._Description))
				db.AddInParameter(dbCommand, "Description", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Description", DbType.String, this._Description);

            return Convert.ToDecimal(db.ExecuteScalar(dbCommand));
		}

		/// <summary>
		/// Deletes a record from the LU_Facility_Specific_Location table by a composite primary key.
		/// </summary>
		public static void Delete(decimal pK_LU_Facility_Specific_Location)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Facility_Specific_LocationDelete");

			db.AddInParameter(dbCommand, "PK_LU_Facility_Specific_Location", DbType.Decimal, pK_LU_Facility_Specific_Location);

			db.ExecuteNonQuery(dbCommand);
		}
	}
}
