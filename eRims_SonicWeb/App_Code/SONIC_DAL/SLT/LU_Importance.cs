using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for LU_Importance table.
	/// </summary>
	public sealed class LU_Importance
	{

		#region Private variables used to hold the property values

		private decimal? _PK_LU_Importance;
		private string _Fld_Code;
		private string _Fld_Desc;
		private bool? _Active;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_LU_Importance value.
		/// </summary>
		public decimal? PK_LU_Importance
		{
			get { return _PK_LU_Importance; }
			set { _PK_LU_Importance = value; }
		}

		/// <summary>
		/// Gets or sets the Fld_Code value.
		/// </summary>
		public string Fld_Code
		{
			get { return _Fld_Code; }
			set { _Fld_Code = value; }
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
		public bool? Active
		{
			get { return _Active; }
			set { _Active = value; }
		}


		#endregion

		#region Default Constructors

		/// <summary>
		/// Initializes a new instance of the clsLU_Importance class with default value.
		/// </summary>
		public LU_Importance() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the clsLU_Importance class based on Primary Key.
		/// </summary>
		public LU_Importance(decimal pK_LU_Importance) 
		{
			DataTable dtLU_Importance = SelectByPK(pK_LU_Importance).Tables[0];

			if (dtLU_Importance.Rows.Count == 1)
			{
				 SetValue(dtLU_Importance.Rows[0]);

			}

		}


		/// <summary>
		/// Initializes a new instance of the clsLU_Importance class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drLU_Importance) 
		{
				if (drLU_Importance["PK_LU_Importance"] == DBNull.Value)
					this._PK_LU_Importance = null;
				else
					this._PK_LU_Importance = (decimal?)drLU_Importance["PK_LU_Importance"];

				if (drLU_Importance["Fld_Code"] == DBNull.Value)
					this._Fld_Code = null;
				else
					this._Fld_Code = (string)drLU_Importance["Fld_Code"];

				if (drLU_Importance["Fld_Desc"] == DBNull.Value)
					this._Fld_Desc = null;
				else
					this._Fld_Desc = (string)drLU_Importance["Fld_Desc"];

				if (drLU_Importance["Active"] == DBNull.Value)
					this._Active = null;
				else
					this._Active = (bool?)drLU_Importance["Active"];


		}

		#endregion

		/// <summary>
		/// Inserts a record into the LU_Importance table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_ImportanceInsert");

			
			if (string.IsNullOrEmpty(this._Fld_Code))
				db.AddInParameter(dbCommand, "Fld_Code", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Fld_Code", DbType.String, this._Fld_Code);
			
			if (string.IsNullOrEmpty(this._Fld_Desc))
				db.AddInParameter(dbCommand, "Fld_Desc", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Fld_Desc", DbType.String, this._Fld_Desc);
			
			db.AddInParameter(dbCommand, "Active", DbType.Boolean, this._Active);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the LU_Importance table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		private DataSet SelectByPK(decimal pK_LU_Importance)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_ImportanceSelectByPK");

			db.AddInParameter(dbCommand, "PK_LU_Importance", DbType.Decimal, pK_LU_Importance);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the LU_Importance table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_ImportanceSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the LU_Importance table.
		/// </summary>
		public void Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_ImportanceUpdate");

			
			db.AddInParameter(dbCommand, "PK_LU_Importance", DbType.Decimal, this._PK_LU_Importance);
			
			if (string.IsNullOrEmpty(this._Fld_Code))
				db.AddInParameter(dbCommand, "Fld_Code", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Fld_Code", DbType.String, this._Fld_Code);
			
			if (string.IsNullOrEmpty(this._Fld_Desc))
				db.AddInParameter(dbCommand, "Fld_Desc", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Fld_Desc", DbType.String, this._Fld_Desc);
			
			db.AddInParameter(dbCommand, "Active", DbType.Boolean, this._Active);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the LU_Importance table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_LU_Importance)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_ImportanceDeleteByPK");

			db.AddInParameter(dbCommand, "PK_LU_Importance", DbType.Decimal, pK_LU_Importance);

			db.ExecuteNonQuery(dbCommand);
		}
	}
}
