using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for Screen table.
	/// </summary>
	public sealed class clsScreen
	{

		#region Private variables used to hold the property values

		private decimal? _ScreenId;
		private string _ScreenName;
		private decimal? _SubModuleId;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the ScreenId value.
		/// </summary>
		public decimal? ScreenId
		{
			get { return _ScreenId; }
			set { _ScreenId = value; }
		}

		/// <summary>
		/// Gets or sets the ScreenName value.
		/// </summary>
		public string ScreenName
		{
			get { return _ScreenName; }
			set { _ScreenName = value; }
		}

		/// <summary>
		/// Gets or sets the SubModuleId value.
		/// </summary>
		public decimal? SubModuleId
		{
			get { return _SubModuleId; }
			set { _SubModuleId = value; }
		}


		#endregion

		#region Default Constructors

		/// <summary>
		/// Initializes a new instance of the clsScreen class with default value.
		/// </summary>
		public clsScreen() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the clsScreen class based on Primary Key.
		/// </summary>
		public clsScreen(decimal screenId) 
		{
			DataTable dtScreen = SelectByPK(screenId).Tables[0];

			if (dtScreen.Rows.Count == 1)
			{
				 SetValue(dtScreen.Rows[0]);

			}

		}


		/// <summary>
		/// Initializes a new instance of the clsScreen class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drScreen) 
		{
				if (drScreen["ScreenId"] == DBNull.Value)
					this._ScreenId = null;
				else
					this._ScreenId = (decimal?)drScreen["ScreenId"];

				if (drScreen["ScreenName"] == DBNull.Value)
					this._ScreenName = null;
				else
					this._ScreenName = (string)drScreen["ScreenName"];

				if (drScreen["SubModuleId"] == DBNull.Value)
					this._SubModuleId = null;
				else
					this._SubModuleId = (decimal?)drScreen["SubModuleId"];


		}

		#endregion

		/// <summary>
		/// Inserts a record into the Screen table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("ScreenInsert");

			
			if (string.IsNullOrEmpty(this._ScreenName))
				db.AddInParameter(dbCommand, "ScreenName", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "ScreenName", DbType.String, this._ScreenName);
			
			db.AddInParameter(dbCommand, "SubModuleId", DbType.Decimal, this._SubModuleId);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the Screen table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		private DataSet SelectByPK(decimal screenId)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("ScreenSelectByPK");

			db.AddInParameter(dbCommand, "ScreenId", DbType.Decimal, screenId);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the Screen table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("ScreenSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the Screen table.
		/// </summary>
		public void Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("ScreenUpdate");

			
			db.AddInParameter(dbCommand, "ScreenId", DbType.Decimal, this._ScreenId);
			
			if (string.IsNullOrEmpty(this._ScreenName))
				db.AddInParameter(dbCommand, "ScreenName", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "ScreenName", DbType.String, this._ScreenName);
			
			db.AddInParameter(dbCommand, "SubModuleId", DbType.Decimal, this._SubModuleId);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the Screen table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal screenId)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("ScreenDeleteByPK");

			db.AddInParameter(dbCommand, "ScreenId", DbType.Decimal, screenId);

			db.ExecuteNonQuery(dbCommand);
		}
	}
}
