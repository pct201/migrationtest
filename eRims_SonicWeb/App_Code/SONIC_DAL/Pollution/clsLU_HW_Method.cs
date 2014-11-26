using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for LU_HW_Method table.
	/// </summary>
	public sealed class clsLU_HW_Method
	{

		#region Private variables used to hold the property values

		private decimal? _PK_LU_HW_Method;
		private string _Fld_Desc;
		private string _Active;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_LU_HW_Method value.
		/// </summary>
		public decimal? PK_LU_HW_Method
		{
			get { return _PK_LU_HW_Method; }
			set { _PK_LU_HW_Method = value; }
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
		/// Initializes a new instance of the clsLU_HW_Method class with default value.
		/// </summary>
		public clsLU_HW_Method() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the clsLU_HW_Method class based on Primary Key.
		/// </summary>
		public clsLU_HW_Method(decimal pK_LU_HW_Method) 
		{
			DataTable dtLU_HW_Method = SelectByPK(pK_LU_HW_Method).Tables[0];

			if (dtLU_HW_Method.Rows.Count == 1)
			{
				 SetValue(dtLU_HW_Method.Rows[0]);

			}

		}


		/// <summary>
		/// Initializes a new instance of the clsLU_HW_Method class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drLU_HW_Method) 
		{
				if (drLU_HW_Method["PK_LU_HW_Method"] == DBNull.Value)
					this._PK_LU_HW_Method = null;
				else
					this._PK_LU_HW_Method = (decimal?)drLU_HW_Method["PK_LU_HW_Method"];

				if (drLU_HW_Method["Fld_Desc"] == DBNull.Value)
					this._Fld_Desc = null;
				else
					this._Fld_Desc = (string)drLU_HW_Method["Fld_Desc"];

				if (drLU_HW_Method["Active"] == DBNull.Value)
					this._Active = null;
				else
					this._Active = (string)drLU_HW_Method["Active"];


		}

		#endregion

		/// <summary>
		/// Inserts a record into the LU_HW_Method table.
		/// </summary>
		/// <returns></returns>
		public int Insert() 
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_HW_MethodInsert");

			
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
		/// Selects a single record from the LU_HW_Method table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		private DataSet SelectByPK(decimal pK_LU_HW_Method)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_HW_MethodSelectByPK");

			db.AddInParameter(dbCommand, "PK_LU_HW_Method", DbType.Decimal, pK_LU_HW_Method);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the LU_HW_Method table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_HW_MethodSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the LU_HW_Method table.
		/// </summary>
		public int Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_HW_MethodUpdate");

			
			db.AddInParameter(dbCommand, "PK_LU_HW_Method", DbType.Decimal, this._PK_LU_HW_Method);
			
			if (string.IsNullOrEmpty(this._Fld_Desc))
				db.AddInParameter(dbCommand, "Fld_Desc", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Fld_Desc", DbType.String, this._Fld_Desc);
			
			if (string.IsNullOrEmpty(this._Active))
				db.AddInParameter(dbCommand, "Active", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Active", DbType.String, this._Active);

            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
		}

		/// <summary>
		/// Deletes a record from the LU_HW_Method table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_LU_HW_Method)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_HW_MethodDeleteByPK");

			db.AddInParameter(dbCommand, "PK_LU_HW_Method", DbType.Decimal, pK_LU_HW_Method);

			db.ExecuteNonQuery(dbCommand);
		}
	}
}
