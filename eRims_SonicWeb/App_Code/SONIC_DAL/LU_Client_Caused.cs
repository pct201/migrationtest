using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for LU_Client_Caused table.
	/// </summary>
	public sealed class LU_Client_Caused
	{

		#region Private variables used to hold the property values

		private decimal? _PK_LU_Client_Caused;
		private string _Fld_Code;
		private string _Fld_Desc;
		private string _Active;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_LU_Client_Caused value.
		/// </summary>
		public decimal? PK_LU_Client_Caused
		{
			get { return _PK_LU_Client_Caused; }
			set { _PK_LU_Client_Caused = value; }
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
		public string Active
		{
			get { return _Active; }
			set { _Active = value; }
		}


		#endregion

		#region Default Constructors

		/// <summary>
		/// Initializes a new instance of the clsLU_Client_Caused class with default value.
		/// </summary>
		public LU_Client_Caused() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the clsLU_Client_Caused class based on Primary Key.
		/// </summary>
		public LU_Client_Caused(decimal pK_LU_Client_Caused) 
		{
			DataTable dtLU_Client_Caused = SelectByPK(pK_LU_Client_Caused).Tables[0];

			if (dtLU_Client_Caused.Rows.Count == 1)
			{
				 SetValue(dtLU_Client_Caused.Rows[0]);

			}

		}


		/// <summary>
		/// Initializes a new instance of the clsLU_Client_Caused class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drLU_Client_Caused) 
		{
				if (drLU_Client_Caused["PK_LU_Client_Caused"] == DBNull.Value)
					this._PK_LU_Client_Caused = null;
				else
					this._PK_LU_Client_Caused = (decimal?)drLU_Client_Caused["PK_LU_Client_Caused"];

				if (drLU_Client_Caused["Fld_Code"] == DBNull.Value)
					this._Fld_Code = null;
				else
					this._Fld_Code = (string)drLU_Client_Caused["Fld_Code"];

				if (drLU_Client_Caused["Fld_Desc"] == DBNull.Value)
					this._Fld_Desc = null;
				else
					this._Fld_Desc = (string)drLU_Client_Caused["Fld_Desc"];

				if (drLU_Client_Caused["Active"] == DBNull.Value)
					this._Active = null;
				else
					this._Active = (string)drLU_Client_Caused["Active"];


		}

		#endregion

		/// <summary>
		/// Inserts a record into the LU_Client_Caused table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Client_CausedInsert");

			
			if (string.IsNullOrEmpty(this._Fld_Code))
				db.AddInParameter(dbCommand, "Fld_Code", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Fld_Code", DbType.String, this._Fld_Code);
			
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
		/// Selects a single record from the LU_Client_Caused table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		private DataSet SelectByPK(decimal pK_LU_Client_Caused)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Client_CausedSelectByPK");

			db.AddInParameter(dbCommand, "PK_LU_Client_Caused", DbType.Decimal, pK_LU_Client_Caused);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the LU_Client_Caused table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Client_CausedSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the LU_Client_Caused table.
		/// </summary>
		public int Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Client_CausedUpdate");

			
			db.AddInParameter(dbCommand, "PK_LU_Client_Caused", DbType.Decimal, this._PK_LU_Client_Caused);
			
			if (string.IsNullOrEmpty(this._Fld_Code))
				db.AddInParameter(dbCommand, "Fld_Code", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Fld_Code", DbType.String, this._Fld_Code);
			
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
		/// Deletes a record from the LU_Client_Caused table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_LU_Client_Caused)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Client_CausedDeleteByPK");

			db.AddInParameter(dbCommand, "PK_LU_Client_Caused", DbType.Decimal, pK_LU_Client_Caused);

			db.ExecuteNonQuery(dbCommand);
		}
	}
}
