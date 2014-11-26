using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for LU_Explain table.
	/// </summary>
	public sealed class LU_Explain
	{

		#region Private variables used to hold the property values

		private decimal? _PK_LU_Explain;
		private string _Fld_Code;
		private string _Fld_Desc;
		private bool? _Active;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_LU_Explain value.
		/// </summary>
		public decimal? PK_LU_Explain
		{
			get { return _PK_LU_Explain; }
			set { _PK_LU_Explain = value; }
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
		/// Initializes a new instance of the clsLU_Explain class with default value.
		/// </summary>
		public LU_Explain() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the clsLU_Explain class based on Primary Key.
		/// </summary>
		public LU_Explain(decimal pK_LU_Explain) 
		{
			DataTable dtLU_Explain = SelectByPK(pK_LU_Explain).Tables[0];

			if (dtLU_Explain.Rows.Count == 1)
			{
				 SetValue(dtLU_Explain.Rows[0]);

			}

		}


		/// <summary>
		/// Initializes a new instance of the clsLU_Explain class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drLU_Explain) 
		{
				if (drLU_Explain["PK_LU_Explain"] == DBNull.Value)
					this._PK_LU_Explain = null;
				else
					this._PK_LU_Explain = (decimal?)drLU_Explain["PK_LU_Explain"];

				if (drLU_Explain["Fld_Code"] == DBNull.Value)
					this._Fld_Code = null;
				else
					this._Fld_Code = (string)drLU_Explain["Fld_Code"];

				if (drLU_Explain["Fld_Desc"] == DBNull.Value)
					this._Fld_Desc = null;
				else
					this._Fld_Desc = (string)drLU_Explain["Fld_Desc"];

				if (drLU_Explain["Active"] == DBNull.Value)
					this._Active = null;
				else
					this._Active = (bool?)drLU_Explain["Active"];


		}

		#endregion

		/// <summary>
		/// Inserts a record into the LU_Explain table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_ExplainInsert");

			
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
		/// Selects a single record from the LU_Explain table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		private DataSet SelectByPK(decimal pK_LU_Explain)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_ExplainSelectByPK");

			db.AddInParameter(dbCommand, "PK_LU_Explain", DbType.Decimal, pK_LU_Explain);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the LU_Explain table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_ExplainSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the LU_Explain table.
		/// </summary>
		public void Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_ExplainUpdate");

			
			db.AddInParameter(dbCommand, "PK_LU_Explain", DbType.Decimal, this._PK_LU_Explain);
			
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
		/// Deletes a record from the LU_Explain table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_LU_Explain)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_ExplainDeleteByPK");

			db.AddInParameter(dbCommand, "PK_LU_Explain", DbType.Decimal, pK_LU_Explain);

			db.ExecuteNonQuery(dbCommand);
		}
	}
}
