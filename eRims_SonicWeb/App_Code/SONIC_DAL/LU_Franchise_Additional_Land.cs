using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for LU_Franchise_Additional_Land table.
	/// </summary>
	public sealed class LU_Franchise_Additional_Land
	{

		#region Private variables used to hold the property values

		private decimal? _PK_LU_Franchise_Additional_Land;
		private string _Fld_Desc;
		private string _Active;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_LU_Franchise_Additional_Land value.
		/// </summary>
		public decimal? PK_LU_Franchise_Additional_Land
		{
			get { return _PK_LU_Franchise_Additional_Land; }
			set { _PK_LU_Franchise_Additional_Land = value; }
		}

		/// <summary>
		/// Gets or sets the Fld_Desc value.
		/// </summary>
		public string Fld_Desc
		{
			get { return _Fld_Desc; }
			set { _Fld_Desc = value; }
		}

		/// <summary>
		/// Gets or sets the Active value.
		/// </summary>
		public string Active
		{
			get { return _Active; }
			set { _Active = value; }
		}


		#endregion

		#region Default Constructors

		/// <summary>
		/// Initializes a new instance of the LU_Franchise_Additional_Land class with default value.
		/// </summary>
		public LU_Franchise_Additional_Land() 
		{

			this._PK_LU_Franchise_Additional_Land = null;
			this._Fld_Desc = null;
			this._Active = null;

		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the LU_Franchise_Additional_Land class based on Primary Key.
		/// </summary>
		public LU_Franchise_Additional_Land(decimal pK_LU_Franchise_Additional_Land) 
		{
			DataTable dtLU_Franchise_Additional_Land = SelectByPK(pK_LU_Franchise_Additional_Land).Tables[0];

			if (dtLU_Franchise_Additional_Land.Rows.Count == 1)
			{
				DataRow drLU_Franchise_Additional_Land = dtLU_Franchise_Additional_Land.Rows[0];
				if (drLU_Franchise_Additional_Land["PK_LU_Franchise_Additional_Land"] == DBNull.Value)
					this._PK_LU_Franchise_Additional_Land = null;
				else
					this._PK_LU_Franchise_Additional_Land = (decimal?)drLU_Franchise_Additional_Land["PK_LU_Franchise_Additional_Land"];

				if (drLU_Franchise_Additional_Land["Fld_Desc"] == DBNull.Value)
					this._Fld_Desc = null;
				else
					this._Fld_Desc = (string)drLU_Franchise_Additional_Land["Fld_Desc"];

				if (drLU_Franchise_Additional_Land["Active"] == DBNull.Value)
					this._Active = null;
				else
					this._Active = (string)drLU_Franchise_Additional_Land["Active"];

			}
			else
			{
				this._PK_LU_Franchise_Additional_Land = null;
				this._Fld_Desc = null;
				this._Active = null;
			}

		}

		#endregion

		/// <summary>
		/// Inserts a record into the LU_Franchise_Additional_Land table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Franchise_Additional_LandInsert");

			
			if (string.IsNullOrEmpty(this._Fld_Desc))
				db.AddInParameter(dbCommand, "Fld_Desc", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Fld_Desc", DbType.String, this._Fld_Desc);
			
			if (string.IsNullOrEmpty(this._Active))
				db.AddInParameter(dbCommand, "Active", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Active", DbType.String, this._Active);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the LU_Franchise_Additional_Land table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		private static DataSet SelectByPK(decimal pK_LU_Franchise_Additional_Land)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Franchise_Additional_LandSelectByPK");

			db.AddInParameter(dbCommand, "PK_LU_Franchise_Additional_Land", DbType.Decimal, pK_LU_Franchise_Additional_Land);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the LU_Franchise_Additional_Land table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Franchise_Additional_LandSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the LU_Franchise_Additional_Land table.
		/// </summary>
		public decimal Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Franchise_Additional_LandUpdate");

			
			db.AddInParameter(dbCommand, "PK_LU_Franchise_Additional_Land", DbType.Decimal, this._PK_LU_Franchise_Additional_Land);
			
			if (string.IsNullOrEmpty(this._Fld_Desc))
				db.AddInParameter(dbCommand, "Fld_Desc", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Fld_Desc", DbType.String, this._Fld_Desc);
			
			if (string.IsNullOrEmpty(this._Active))
				db.AddInParameter(dbCommand, "Active", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Active", DbType.String, this._Active);

            return (Convert.ToDecimal(db.ExecuteScalar(dbCommand)));
		}

		/// <summary>
		/// Deletes a record from the LU_Franchise_Additional_Land table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_LU_Franchise_Additional_Land)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Franchise_Additional_LandDeleteByPK");

			db.AddInParameter(dbCommand, "PK_LU_Franchise_Additional_Land", DbType.Decimal, pK_LU_Franchise_Additional_Land);

			db.ExecuteNonQuery(dbCommand);
		}
	}
}
