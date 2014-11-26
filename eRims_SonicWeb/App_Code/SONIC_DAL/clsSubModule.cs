using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for SubModule table.
	/// </summary>
	public sealed class clsSubModule
	{

		#region Private variables used to hold the property values

		private decimal? _SubModuleId;
		private string _SubModuleName;
		private decimal? _ModuleId;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the SubModuleId value.
		/// </summary>
		public decimal? SubModuleId
		{
			get { return _SubModuleId; }
			set { _SubModuleId = value; }
		}

		/// <summary>
		/// Gets or sets the SubModuleName value.
		/// </summary>
		public string SubModuleName
		{
			get { return _SubModuleName; }
			set { _SubModuleName = value; }
		}

		/// <summary>
		/// Gets or sets the ModuleId value.
		/// </summary>
		public decimal? ModuleId
		{
			get { return _ModuleId; }
			set { _ModuleId = value; }
		}


		#endregion

		#region Default Constructors

		/// <summary>
		/// Initializes a new instance of the clsSubModule class with default value.
		/// </summary>
		public clsSubModule() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the clsSubModule class based on Primary Key.
		/// </summary>
		public clsSubModule(decimal subModuleId) 
		{
			DataTable dtSubModule = SelectByPK(subModuleId).Tables[0];

			if (dtSubModule.Rows.Count == 1)
			{
				 SetValue(dtSubModule.Rows[0]);

			}

		}


		/// <summary>
		/// Initializes a new instance of the clsSubModule class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drSubModule) 
		{
				if (drSubModule["SubModuleId"] == DBNull.Value)
					this._SubModuleId = null;
				else
					this._SubModuleId = (decimal?)drSubModule["SubModuleId"];

				if (drSubModule["SubModuleName"] == DBNull.Value)
					this._SubModuleName = null;
				else
					this._SubModuleName = (string)drSubModule["SubModuleName"];

				if (drSubModule["ModuleId"] == DBNull.Value)
					this._ModuleId = null;
				else
					this._ModuleId = (decimal?)drSubModule["ModuleId"];


		}

		#endregion

		/// <summary>
		/// Inserts a record into the SubModule table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("SubModuleInsert");

			
			if (string.IsNullOrEmpty(this._SubModuleName))
				db.AddInParameter(dbCommand, "SubModuleName", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "SubModuleName", DbType.String, this._SubModuleName);
			
			db.AddInParameter(dbCommand, "ModuleId", DbType.Decimal, this._ModuleId);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the SubModule table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		private DataSet SelectByPK(decimal subModuleId)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("SubModuleSelectByPK");

			db.AddInParameter(dbCommand, "SubModuleId", DbType.Decimal, subModuleId);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the SubModule table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("SubModuleSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the SubModule table.
		/// </summary>
		public void Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("SubModuleUpdate");

			
			db.AddInParameter(dbCommand, "SubModuleId", DbType.Decimal, this._SubModuleId);
			
			if (string.IsNullOrEmpty(this._SubModuleName))
				db.AddInParameter(dbCommand, "SubModuleName", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "SubModuleName", DbType.String, this._SubModuleName);
			
			db.AddInParameter(dbCommand, "ModuleId", DbType.Decimal, this._ModuleId);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the SubModule table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal subModuleId)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("SubModuleDeleteByPK");

			db.AddInParameter(dbCommand, "SubModuleId", DbType.Decimal, subModuleId);

			db.ExecuteNonQuery(dbCommand);
		}
	}
}
