using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for LU_Equipment_Type_Pollution table.
	/// </summary>
	public sealed class clsLU_Equipment_Type_Pollution
	{

		#region Private variables used to hold the property values

		private decimal? _PK_LU_Equipment_Type_Pollution;
		private string _Fld_Desc;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_LU_Equipment_Type_Pollution value.
		/// </summary>
		public decimal? PK_LU_Equipment_Type_Pollution
		{
			get { return _PK_LU_Equipment_Type_Pollution; }
			set { _PK_LU_Equipment_Type_Pollution = value; }
		}

		/// <summary>
		/// Gets or sets the Fld_Desc value.
		/// </summary>
		public string Fld_Desc
		{
			get { return _Fld_Desc; }
			set { _Fld_Desc = value; }
		}


		#endregion

		#region Default Constructors

		/// <summary>
		/// Initializes a new instance of the clsLU_Equipment_Type_Pollution class with default value.
		/// </summary>
		public clsLU_Equipment_Type_Pollution() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the clsLU_Equipment_Type_Pollution class based on Primary Key.
		/// </summary>
		public clsLU_Equipment_Type_Pollution(decimal pK_LU_Equipment_Type_Pollution) 
		{
			DataTable dtLU_Equipment_Type_Pollution = SelectByPK(pK_LU_Equipment_Type_Pollution).Tables[0];

			if (dtLU_Equipment_Type_Pollution.Rows.Count == 1)
			{
				 SetValue(dtLU_Equipment_Type_Pollution.Rows[0]);

			}

		}


		/// <summary>
		/// Initializes a new instance of the clsLU_Equipment_Type_Pollution class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drLU_Equipment_Type_Pollution) 
		{
				if (drLU_Equipment_Type_Pollution["PK_LU_Equipment_Type_Pollution"] == DBNull.Value)
					this._PK_LU_Equipment_Type_Pollution = null;
				else
					this._PK_LU_Equipment_Type_Pollution = (decimal?)drLU_Equipment_Type_Pollution["PK_LU_Equipment_Type_Pollution"];

				if (drLU_Equipment_Type_Pollution["Fld_Desc"] == DBNull.Value)
					this._Fld_Desc = null;
				else
					this._Fld_Desc = (string)drLU_Equipment_Type_Pollution["Fld_Desc"];


		}

		#endregion

		/// <summary>
		/// Inserts a record into the LU_Equipment_Type_Pollution table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Equipment_Type_PollutionInsert");

			
			if (string.IsNullOrEmpty(this._Fld_Desc))
				db.AddInParameter(dbCommand, "Fld_Desc", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Fld_Desc", DbType.String, this._Fld_Desc);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the LU_Equipment_Type_Pollution table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		private DataSet SelectByPK(decimal pK_LU_Equipment_Type_Pollution)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Equipment_Type_PollutionSelectByPK");

			db.AddInParameter(dbCommand, "PK_LU_Equipment_Type_Pollution", DbType.Decimal, pK_LU_Equipment_Type_Pollution);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the LU_Equipment_Type_Pollution table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Equipment_Type_PollutionSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the LU_Equipment_Type_Pollution table.
		/// </summary>
		public decimal Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Equipment_Type_PollutionUpdate");

			
			db.AddInParameter(dbCommand, "PK_LU_Equipment_Type_Pollution", DbType.Decimal, this._PK_LU_Equipment_Type_Pollution);
			
			if (string.IsNullOrEmpty(this._Fld_Desc))
				db.AddInParameter(dbCommand, "Fld_Desc", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Fld_Desc", DbType.String, this._Fld_Desc);

            return (Convert.ToDecimal(db.ExecuteScalar(dbCommand)));
		}

		/// <summary>
		/// Deletes a record from the LU_Equipment_Type_Pollution table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_LU_Equipment_Type_Pollution)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Equipment_Type_PollutionDeleteByPK");

			db.AddInParameter(dbCommand, "PK_LU_Equipment_Type_Pollution", DbType.Decimal, pK_LU_Equipment_Type_Pollution);

			db.ExecuteNonQuery(dbCommand);
		}
	}
}
