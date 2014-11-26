using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for LU_EPM_Required_Activity table.
	/// </summary>
	public sealed class LU_EPM_Required_Activity
	{

		#region Private variables used to hold the property values

		private decimal? _PK_LU_EPM_Required_Activity;
		private string _Fld_Desc;
		private string _Active;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_LU_EPM_Required_Activity value.
		/// </summary>
		public decimal? PK_LU_EPM_Required_Activity
		{
			get { return _PK_LU_EPM_Required_Activity; }
			set { _PK_LU_EPM_Required_Activity = value; }
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
		/// Initializes a new instance of the clsLU_EPM_Required_Activity class with default value.
		/// </summary>
		public LU_EPM_Required_Activity() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the clsLU_EPM_Required_Activity class based on Primary Key.
		/// </summary>
		public LU_EPM_Required_Activity(decimal pK_LU_EPM_Required_Activity) 
		{
			DataTable dtLU_EPM_Required_Activity = SelectByPK(pK_LU_EPM_Required_Activity).Tables[0];

			if (dtLU_EPM_Required_Activity.Rows.Count == 1)
			{
				 SetValue(dtLU_EPM_Required_Activity.Rows[0]);

			}

		}


		/// <summary>
		/// Initializes a new instance of the clsLU_EPM_Required_Activity class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drLU_EPM_Required_Activity) 
		{
				if (drLU_EPM_Required_Activity["PK_LU_EPM_Required_Activity"] == DBNull.Value)
					this._PK_LU_EPM_Required_Activity = null;
				else
					this._PK_LU_EPM_Required_Activity = (decimal?)drLU_EPM_Required_Activity["PK_LU_EPM_Required_Activity"];

				if (drLU_EPM_Required_Activity["Fld_Desc"] == DBNull.Value)
					this._Fld_Desc = null;
				else
					this._Fld_Desc = (string)drLU_EPM_Required_Activity["Fld_Desc"];

				if (drLU_EPM_Required_Activity["Active"] == DBNull.Value)
					this._Active = null;
				else
					this._Active = (string)drLU_EPM_Required_Activity["Active"];


		}

		#endregion

		/// <summary>
		/// Inserts a record into the LU_EPM_Required_Activity table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_EPM_Required_ActivityInsert");

			
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
		/// Selects a single record from the LU_EPM_Required_Activity table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		private DataSet SelectByPK(decimal pK_LU_EPM_Required_Activity)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_EPM_Required_ActivitySelectByPK");

			db.AddInParameter(dbCommand, "PK_LU_EPM_Required_Activity", DbType.Decimal, pK_LU_EPM_Required_Activity);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the LU_EPM_Required_Activity table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_EPM_Required_ActivitySelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the LU_EPM_Required_Activity table.
		/// </summary>
		public decimal Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_EPM_Required_ActivityUpdate");

			
			db.AddInParameter(dbCommand, "PK_LU_EPM_Required_Activity", DbType.Decimal, this._PK_LU_EPM_Required_Activity);
			
			if (string.IsNullOrEmpty(this._Fld_Desc))
				db.AddInParameter(dbCommand, "Fld_Desc", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Fld_Desc", DbType.String, this._Fld_Desc);
			
			if (string.IsNullOrEmpty(this._Active))
				db.AddInParameter(dbCommand, "Active", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Active", DbType.String, this._Active);

            return Convert.ToDecimal(db.ExecuteScalar(dbCommand));
		}

		/// <summary>
		/// Deletes a record from the LU_EPM_Required_Activity table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_LU_EPM_Required_Activity)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_EPM_Required_ActivityDeleteByPK");

			db.AddInParameter(dbCommand, "PK_LU_EPM_Required_Activity", DbType.Decimal, pK_LU_EPM_Required_Activity);

			db.ExecuteNonQuery(dbCommand);
		}
	}
}
