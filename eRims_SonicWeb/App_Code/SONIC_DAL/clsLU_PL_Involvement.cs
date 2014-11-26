using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for LU_PL_Involvement table.
	/// </summary>
	public sealed class clsLU_PL_Involvement
	{

		#region Private variables used to hold the property values

		private decimal? _PK_LU_PL_Involvement;
		private string _Fld_Desc;
		private string _Active;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_LU_PL_Involvement value.
		/// </summary>
		public decimal? PK_LU_PL_Involvement
		{
			get { return _PK_LU_PL_Involvement; }
			set { _PK_LU_PL_Involvement = value; }
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
		/// Initializes a new instance of the clsLU_PL_Involvement class with default value.
		/// </summary>
		public clsLU_PL_Involvement() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the clsLU_PL_Involvement class based on Primary Key.
		/// </summary>
		public clsLU_PL_Involvement(decimal pK_LU_PL_Involvement) 
		{
			DataTable dtLU_PL_Involvement = SelectByPK(pK_LU_PL_Involvement).Tables[0];

			if (dtLU_PL_Involvement.Rows.Count == 1)
			{
				 SetValue(dtLU_PL_Involvement.Rows[0]);

			}

		}


		/// <summary>
		/// Initializes a new instance of the clsLU_PL_Involvement class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drLU_PL_Involvement) 
		{
				if (drLU_PL_Involvement["PK_LU_PL_Involvement"] == DBNull.Value)
					this._PK_LU_PL_Involvement = null;
				else
					this._PK_LU_PL_Involvement = (decimal?)drLU_PL_Involvement["PK_LU_PL_Involvement"];

				if (drLU_PL_Involvement["Fld_Desc"] == DBNull.Value)
					this._Fld_Desc = null;
				else
					this._Fld_Desc = (string)drLU_PL_Involvement["Fld_Desc"];

				if (drLU_PL_Involvement["Active"] == DBNull.Value)
					this._Active = null;
				else
					this._Active = (string)drLU_PL_Involvement["Active"];


		}

		#endregion

		/// <summary>
		/// Inserts a record into the LU_PL_Involvement table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_PL_InvolvementInsert");

			
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
		/// Selects a single record from the LU_PL_Involvement table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		private DataSet SelectByPK(decimal pK_LU_PL_Involvement)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_PL_InvolvementSelectByPK");

			db.AddInParameter(dbCommand, "PK_LU_PL_Involvement", DbType.Decimal, pK_LU_PL_Involvement);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the LU_PL_Involvement table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_PL_InvolvementSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the LU_PL_Involvement table.
		/// </summary>
		public decimal Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_PL_InvolvementUpdate");

			
			db.AddInParameter(dbCommand, "PK_LU_PL_Involvement", DbType.Decimal, this._PK_LU_PL_Involvement);
			
			if (string.IsNullOrEmpty(this._Fld_Desc))
				db.AddInParameter(dbCommand, "Fld_Desc", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Fld_Desc", DbType.String, this._Fld_Desc);
			
			if (string.IsNullOrEmpty(this._Active))
				db.AddInParameter(dbCommand, "Active", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Active", DbType.String, this._Active);

            return (Convert.ToDecimal(db.ExecuteScalar(dbCommand)));
		}

		/// <summary>
		/// Deletes a record from the LU_PL_Involvement table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_LU_PL_Involvement)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_PL_InvolvementDeleteByPK");

			db.AddInParameter(dbCommand, "PK_LU_PL_Involvement", DbType.Decimal, pK_LU_PL_Involvement);

			db.ExecuteNonQuery(dbCommand);
		}
	}
}
