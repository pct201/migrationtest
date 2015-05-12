using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for LU_Work_Completed table.
	/// </summary>
	public sealed class clsLU_Work_Completed
	{

		#region Private variables used to hold the property values

		private decimal? _PK_LU_Work_Completed;
		private string _Fld_Desc;
		private string _Active;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_LU_Work_Completed value.
		/// </summary>
		public decimal? PK_LU_Work_Completed
		{
			get { return _PK_LU_Work_Completed; }
			set { _PK_LU_Work_Completed = value; }
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
		/// Initializes a new instance of the clsLU_Work_Completed class with default value.
		/// </summary>
		public clsLU_Work_Completed() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the clsLU_Work_Completed class based on Primary Key.
		/// </summary>
		public clsLU_Work_Completed(decimal pK_LU_Work_Completed) 
		{
			DataTable dtLU_Work_Completed = SelectByPK(pK_LU_Work_Completed).Tables[0];

			if (dtLU_Work_Completed.Rows.Count == 1)
			{
				 SetValue(dtLU_Work_Completed.Rows[0]);

			}

		}


		/// <summary>
		/// Initializes a new instance of the clsLU_Work_Completed class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drLU_Work_Completed) 
		{
				if (drLU_Work_Completed["PK_LU_Work_Completed"] == DBNull.Value)
					this._PK_LU_Work_Completed = null;
				else
					this._PK_LU_Work_Completed = (decimal?)drLU_Work_Completed["PK_LU_Work_Completed"];

				if (drLU_Work_Completed["Fld_Desc"] == DBNull.Value)
					this._Fld_Desc = null;
				else
					this._Fld_Desc = (string)drLU_Work_Completed["Fld_Desc"];

				if (drLU_Work_Completed["Active"] == DBNull.Value)
					this._Active = null;
				else
					this._Active = (string)drLU_Work_Completed["Active"];


		}

		#endregion

		/// <summary>
		/// Inserts a record into the LU_Work_Completed table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Work_CompletedInsert");

			
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
		/// Selects a single record from the LU_Work_Completed table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		private DataSet SelectByPK(decimal pK_LU_Work_Completed)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Work_CompletedSelectByPK");

			db.AddInParameter(dbCommand, "PK_LU_Work_Completed", DbType.Decimal, pK_LU_Work_Completed);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the LU_Work_Completed table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Work_CompletedSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the LU_Work_Completed table.
		/// </summary>
		public decimal Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Work_CompletedUpdate");

			
			db.AddInParameter(dbCommand, "PK_LU_Work_Completed", DbType.Decimal, this._PK_LU_Work_Completed);
			
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
		/// Deletes a record from the LU_Work_Completed table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_LU_Work_Completed)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Work_CompletedDeleteByPK");

			db.AddInParameter(dbCommand, "PK_LU_Work_Completed", DbType.Decimal, pK_LU_Work_Completed);

			db.ExecuteNonQuery(dbCommand);
		}
	}
}
