using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for LU_Facility_Inspection_Focus_Area table.
	/// </summary>
	public sealed class clsLU_Facility_Inspection_Focus_Area
	{

		#region Private variables used to hold the property values

		private decimal? _PK_LU_Facility_Inspection_Focus_Area;
		private string _Description;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_LU_Facility_Inspection_Focus_Area value.
		/// </summary>
		public decimal? PK_LU_Facility_Inspection_Focus_Area
		{
			get { return _PK_LU_Facility_Inspection_Focus_Area; }
			set { _PK_LU_Facility_Inspection_Focus_Area = value; }
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
		/// Initializes a new instance of the clsLU_Facility_Inspection_Focus_Area class with default value.
		/// </summary>
		public clsLU_Facility_Inspection_Focus_Area() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the clsLU_Facility_Inspection_Focus_Area class based on Primary Key.
		/// </summary>
		public clsLU_Facility_Inspection_Focus_Area(decimal pK_LU_Facility_Inspection_Focus_Area) 
		{
			DataTable dtLU_Facility_Inspection_Focus_Area = SelectByPK(pK_LU_Facility_Inspection_Focus_Area).Tables[0];

			if (dtLU_Facility_Inspection_Focus_Area.Rows.Count == 1)
			{
				 SetValue(dtLU_Facility_Inspection_Focus_Area.Rows[0]);

			}

		}


		/// <summary>
		/// Initializes a new instance of the clsLU_Facility_Inspection_Focus_Area class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drLU_Facility_Inspection_Focus_Area) 
		{
				if (drLU_Facility_Inspection_Focus_Area["PK_LU_Facility_Inspection_Focus_Area"] == DBNull.Value)
					this._PK_LU_Facility_Inspection_Focus_Area = null;
				else
					this._PK_LU_Facility_Inspection_Focus_Area = (decimal?)drLU_Facility_Inspection_Focus_Area["PK_LU_Facility_Inspection_Focus_Area"];

				if (drLU_Facility_Inspection_Focus_Area["Description"] == DBNull.Value)
					this._Description = null;
				else
					this._Description = (string)drLU_Facility_Inspection_Focus_Area["Description"];


		}

		#endregion

		/// <summary>
		/// Inserts a record into the LU_Facility_Inspection_Focus_Area table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Facility_Inspection_Focus_AreaInsert");
			
			if (string.IsNullOrEmpty(this._Description))
				db.AddInParameter(dbCommand, "Description", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Description", DbType.String, this._Description);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the LU_Facility_Inspection_Focus_Area table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		private DataSet SelectByPK(decimal pK_LU_Facility_Inspection_Focus_Area)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Facility_Inspection_Focus_AreaSelectByPK");

			db.AddInParameter(dbCommand, "PK_LU_Facility_Inspection_Focus_Area", DbType.Decimal, pK_LU_Facility_Inspection_Focus_Area);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the LU_Facility_Inspection_Focus_Area table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Facility_Inspection_Focus_AreaSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the LU_Facility_Inspection_Focus_Area table.
		/// </summary>
		public decimal Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Facility_Inspection_Focus_AreaUpdate");

			db.AddInParameter(dbCommand, "PK_LU_Facility_Inspection_Focus_Area", DbType.Decimal, this._PK_LU_Facility_Inspection_Focus_Area);
			
			if (string.IsNullOrEmpty(this._Description))
				db.AddInParameter(dbCommand, "Description", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Description", DbType.String, this._Description);

            return (Convert.ToDecimal(db.ExecuteScalar(dbCommand)));
		}

		/// <summary>
		/// Deletes a record from the LU_Facility_Inspection_Focus_Area table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_LU_Facility_Inspection_Focus_Area)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Facility_Inspection_Focus_AreaDeleteByPK");

			db.AddInParameter(dbCommand, "PK_LU_Facility_Inspection_Focus_Area", DbType.Decimal, pK_LU_Facility_Inspection_Focus_Area);

			db.ExecuteNonQuery(dbCommand);
		}
	}
}
