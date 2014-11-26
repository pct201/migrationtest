using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for LU_Transaction_Category table.
	/// </summary>
	public sealed class clsLU_Transaction_Category
	{

		#region Private variables used to hold the property values

		private decimal? _PK_LU_Transaction_Category;
		private string _Fld_Desc;
		private string _ACTIVE;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_LU_Transaction_Category value.
		/// </summary>
		public decimal? PK_LU_Transaction_Category
		{
			get { return _PK_LU_Transaction_Category; }
			set { _PK_LU_Transaction_Category = value; }
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
		/// Gets or sets the ACTIVE value.
		/// </summary>
		public string ACTIVE
		{
			get { return _ACTIVE; }
			set { _ACTIVE = value; }
		}


		#endregion

		#region Default Constructors

		/// <summary>
		/// Initializes a new instance of the clsLU_Transaction_Category class with default value.
		/// </summary>
		public clsLU_Transaction_Category() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the clsLU_Transaction_Category class based on Primary Key.
		/// </summary>
		public clsLU_Transaction_Category(decimal pK_LU_Transaction_Category) 
		{
			DataTable dtLU_Transaction_Category = SelectByPK(pK_LU_Transaction_Category).Tables[0];

			if (dtLU_Transaction_Category.Rows.Count == 1)
			{
				 SetValue(dtLU_Transaction_Category.Rows[0]);

			}

		}


		/// <summary>
		/// Initializes a new instance of the clsLU_Transaction_Category class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drLU_Transaction_Category) 
		{
				if (drLU_Transaction_Category["PK_LU_Transaction_Category"] == DBNull.Value)
					this._PK_LU_Transaction_Category = null;
				else
					this._PK_LU_Transaction_Category = (decimal?)drLU_Transaction_Category["PK_LU_Transaction_Category"];

				if (drLU_Transaction_Category["Fld_Desc"] == DBNull.Value)
					this._Fld_Desc = null;
				else
					this._Fld_Desc = (string)drLU_Transaction_Category["Fld_Desc"];

				if (drLU_Transaction_Category["ACTIVE"] == DBNull.Value)
					this._ACTIVE = null;
				else
					this._ACTIVE = (string)drLU_Transaction_Category["ACTIVE"];


		}

		#endregion

		/// <summary>
		/// Inserts a record into the LU_Transaction_Category table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Transaction_CategoryInsert");

			
			if (string.IsNullOrEmpty(this._Fld_Desc))
				db.AddInParameter(dbCommand, "Fld_Desc", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Fld_Desc", DbType.String, this._Fld_Desc);
			
			if (string.IsNullOrEmpty(this._ACTIVE))
				db.AddInParameter(dbCommand, "ACTIVE", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "ACTIVE", DbType.String, this._ACTIVE);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the LU_Transaction_Category table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		private DataSet SelectByPK(decimal pK_LU_Transaction_Category)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Transaction_CategorySelectByPK");

			db.AddInParameter(dbCommand, "PK_LU_Transaction_Category", DbType.Decimal, pK_LU_Transaction_Category);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the LU_Transaction_Category table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Transaction_CategorySelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the LU_Transaction_Category table.
		/// </summary>
		public void Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Transaction_CategoryUpdate");

			
			db.AddInParameter(dbCommand, "PK_LU_Transaction_Category", DbType.Decimal, this._PK_LU_Transaction_Category);
			
			if (string.IsNullOrEmpty(this._Fld_Desc))
				db.AddInParameter(dbCommand, "Fld_Desc", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Fld_Desc", DbType.String, this._Fld_Desc);
			
			if (string.IsNullOrEmpty(this._ACTIVE))
				db.AddInParameter(dbCommand, "ACTIVE", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "ACTIVE", DbType.String, this._ACTIVE);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the LU_Transaction_Category table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_LU_Transaction_Category)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Transaction_CategoryDeleteByPK");

			db.AddInParameter(dbCommand, "PK_LU_Transaction_Category", DbType.Decimal, pK_LU_Transaction_Category);

			db.ExecuteNonQuery(dbCommand);
		}
	}
}
