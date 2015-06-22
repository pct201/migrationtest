using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for clsLU_Facility_Area table.
	/// </summary>
	public sealed class clsLU_Facility_Area
	{

		#region Private variables used to hold the property values

		private decimal? _PK_LU_Facility_Area;
		private string _Description;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_LU_Facility_Area value.
		/// </summary>
		public decimal? PK_LU_Facility_Area
		{
			get { return _PK_LU_Facility_Area; }
			set { _PK_LU_Facility_Area = value; }
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
		/// Initializes a new instance of the LU_Facility_Area class with default value.
		/// </summary>
		public clsLU_Facility_Area() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the LU_Facility_Area class based on Primary Key.
		/// </summary>
		public clsLU_Facility_Area(decimal pK_LU_Facility_Area) 
		{
			DataTable dtLU_Facility_Area = Select(pK_LU_Facility_Area).Tables[0];

			if (dtLU_Facility_Area.Rows.Count == 1)
			{
				 SetValue(dtLU_Facility_Area.Rows[0]);

			}

		}


		/// <summary>
		/// Initializes a new instance of the LU_Facility_Area class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drLU_Facility_Area) 
		{
				if (drLU_Facility_Area["PK_LU_Facility_Area"] == DBNull.Value)
					this._PK_LU_Facility_Area = null;
				else
					this._PK_LU_Facility_Area = (decimal?)drLU_Facility_Area["PK_LU_Facility_Area"];

				if (drLU_Facility_Area["Description"] == DBNull.Value)
					this._Description = null;
				else
					this._Description = (string)drLU_Facility_Area["Description"];


		}

		#endregion

		/// <summary>
		/// Inserts a record into the LU_Facility_Area table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Facility_AreaInsert");

			
			if (string.IsNullOrEmpty(this._Description))
				db.AddInParameter(dbCommand, "Description", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Description", DbType.String, this._Description);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the LU_Facility_Area table.
		/// </summary>
		/// <returns>DataSet</returns>
		private DataSet Select(decimal pK_LU_Facility_Area)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Facility_AreaSelect");

			db.AddInParameter(dbCommand, "PK_LU_Facility_Area", DbType.Decimal, pK_LU_Facility_Area);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the LU_Facility_Area table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Facility_AreaSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the LU_Facility_Area table.
		/// </summary>
        public decimal Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Facility_AreaUpdate");

			
			db.AddInParameter(dbCommand, "PK_LU_Facility_Area", DbType.Decimal, this._PK_LU_Facility_Area);
			
			if (string.IsNullOrEmpty(this._Description))
				db.AddInParameter(dbCommand, "Description", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Description", DbType.String, this._Description);

			return (Convert.ToDecimal(db.ExecuteNonQuery(dbCommand)));
		}

		/// <summary>
		/// Deletes a record from the LU_Facility_Area table by a composite primary key.
		/// </summary>
		public static void Delete(decimal pK_LU_Facility_Area)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Facility_AreaDelete");

			db.AddInParameter(dbCommand, "PK_LU_Facility_Area", DbType.Decimal, pK_LU_Facility_Area);

			db.ExecuteNonQuery(dbCommand);
		}
	}
}
