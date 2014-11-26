using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for LU_Days_Of_Week table.
	/// </summary>
	public sealed class clsLU_Days_Of_Week
	{

		#region Private variables used to hold the property values

		private decimal? _PK_LU_Days_Of_Week;
		private string _Fld_Desc;
		private string _Active;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_LU_Days_Of_Week value.
		/// </summary>
		public decimal? PK_LU_Days_Of_Week
		{
			get { return _PK_LU_Days_Of_Week; }
			set { _PK_LU_Days_Of_Week = value; }
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
		/// Initializes a new instance of the clsLU_Days_Of_Week class with default value.
		/// </summary>
		public clsLU_Days_Of_Week() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the clsLU_Days_Of_Week class based on Primary Key.
		/// </summary>
		public clsLU_Days_Of_Week(decimal pK_LU_Days_Of_Week) 
		{
			DataTable dtLU_Days_Of_Week = SelectByPK(pK_LU_Days_Of_Week).Tables[0];

			if (dtLU_Days_Of_Week.Rows.Count == 1)
			{
				 SetValue(dtLU_Days_Of_Week.Rows[0]);

			}

		}


		/// <summary>
		/// Initializes a new instance of the clsLU_Days_Of_Week class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drLU_Days_Of_Week) 
		{
				if (drLU_Days_Of_Week["PK_LU_Days_Of_Week"] == DBNull.Value)
					this._PK_LU_Days_Of_Week = null;
				else
					this._PK_LU_Days_Of_Week = (decimal?)drLU_Days_Of_Week["PK_LU_Days_Of_Week"];

				if (drLU_Days_Of_Week["Fld_Desc"] == DBNull.Value)
					this._Fld_Desc = null;
				else
					this._Fld_Desc = (string)drLU_Days_Of_Week["Fld_Desc"];

				if (drLU_Days_Of_Week["Active"] == DBNull.Value)
					this._Active = null;
				else
					this._Active = (string)drLU_Days_Of_Week["Active"];


		}

		#endregion

		/// <summary>
		/// Inserts a record into the LU_Days_Of_Week table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Days_Of_WeekInsert");

			
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
		/// Selects a single record from the LU_Days_Of_Week table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		private DataSet SelectByPK(decimal pK_LU_Days_Of_Week)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Days_Of_WeekSelectByPK");

			db.AddInParameter(dbCommand, "PK_LU_Days_Of_Week", DbType.Decimal, pK_LU_Days_Of_Week);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the LU_Days_Of_Week table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Days_Of_WeekSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the LU_Days_Of_Week table.
		/// </summary>
		public void Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Days_Of_WeekUpdate");

			
			db.AddInParameter(dbCommand, "PK_LU_Days_Of_Week", DbType.Decimal, this._PK_LU_Days_Of_Week);
			
			if (string.IsNullOrEmpty(this._Fld_Desc))
				db.AddInParameter(dbCommand, "Fld_Desc", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Fld_Desc", DbType.String, this._Fld_Desc);
			
			if (string.IsNullOrEmpty(this._Active))
				db.AddInParameter(dbCommand, "Active", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Active", DbType.String, this._Active);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the LU_Days_Of_Week table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_LU_Days_Of_Week)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Days_Of_WeekDeleteByPK");

			db.AddInParameter(dbCommand, "PK_LU_Days_Of_Week", DbType.Decimal, pK_LU_Days_Of_Week);

			db.ExecuteNonQuery(dbCommand);
		}
	}
}
