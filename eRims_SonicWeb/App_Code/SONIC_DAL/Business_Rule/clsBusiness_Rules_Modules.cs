using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for Business_Rules_Modules table.
	/// </summary>
	public sealed class clsBusiness_Rules_Modules 
	{

		#region Private variables used to hold the property values

		private decimal? _PK_Business_Rules_Modules;
		private string _Module;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_Business_Rules_Modules value.
		/// </summary>
		public decimal? PK_Business_Rules_Modules
		{
			get { return _PK_Business_Rules_Modules; }
			set { _PK_Business_Rules_Modules = value; }
		}

		/// <summary>
		/// Gets or sets the Module value.
		/// </summary>
		public string Module
		{
			get { return _Module; }
			set { _Module = value; }
		}


		#endregion

		#region Default Constructors

		/// <summary>
		/// Initializes a new instance of the clsBusiness_Rules_Modules class with default value.
		/// </summary>
		public clsBusiness_Rules_Modules() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the clsBusiness_Rules_Modules class based on Primary Key.
		/// </summary>
		public clsBusiness_Rules_Modules(decimal pK_Business_Rules_Modules) 
		{
			DataTable dtBusiness_Rules_Modules = SelectByPK(pK_Business_Rules_Modules).Tables[0];

			if (dtBusiness_Rules_Modules.Rows.Count == 1)
			{
				 SetValue(dtBusiness_Rules_Modules.Rows[0]);

			}

		}


		/// <summary>
		/// Initializes a new instance of the clsBusiness_Rules_Modules class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drBusiness_Rules_Modules) 
		{
				if (drBusiness_Rules_Modules["PK_Business_Rules_Modules"] == DBNull.Value)
					this._PK_Business_Rules_Modules = null;
				else
					this._PK_Business_Rules_Modules = (decimal?)drBusiness_Rules_Modules["PK_Business_Rules_Modules"];

				if (drBusiness_Rules_Modules["Module"] == DBNull.Value)
					this._Module = null;
				else
					this._Module = (string)drBusiness_Rules_Modules["Module"];


		}

		#endregion

		/// <summary>
		/// Inserts a record into the Business_Rules_Modules table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Business_Rules_ModulesInsert");

			
			if (string.IsNullOrEmpty(this._Module))
				db.AddInParameter(dbCommand, "Module", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Module", DbType.String, this._Module);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the Business_Rules_Modules table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		private DataSet SelectByPK(decimal pK_Business_Rules_Modules)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Business_Rules_ModulesSelectByPK");

			db.AddInParameter(dbCommand, "PK_Business_Rules_Modules", DbType.Decimal, pK_Business_Rules_Modules);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the Business_Rules_Modules table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Business_Rules_ModulesSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the Business_Rules_Modules table.
		/// </summary>
		public void Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Business_Rules_ModulesUpdate");

			
			db.AddInParameter(dbCommand, "PK_Business_Rules_Modules", DbType.Decimal, this._PK_Business_Rules_Modules);
			
			if (string.IsNullOrEmpty(this._Module))
				db.AddInParameter(dbCommand, "Module", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Module", DbType.String, this._Module);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the Business_Rules_Modules table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_Business_Rules_Modules)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Business_Rules_ModulesDeleteByPK");

			db.AddInParameter(dbCommand, "PK_Business_Rules_Modules", DbType.Decimal, pK_Business_Rules_Modules);

			db.ExecuteNonQuery(dbCommand);
		}
	}
}
