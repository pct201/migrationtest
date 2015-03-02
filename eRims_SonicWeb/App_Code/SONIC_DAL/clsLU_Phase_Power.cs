using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for LU_Phase_Power table.
	/// </summary>
	public sealed class clsLU_Phase_Power
	{

		#region Private variables used to hold the property values

		private decimal? _PK_LU_Phase_Power;
		private string _Fld_Desc;
		private string _Active;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_LU_Phase_Power value.
		/// </summary>
		public decimal? PK_LU_Phase_Power
		{
			get { return _PK_LU_Phase_Power; }
			set { _PK_LU_Phase_Power = value; }
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
		/// Initializes a new instance of the clsLU_Phase_Power class with default value.
		/// </summary>
		public clsLU_Phase_Power() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the clsLU_Phase_Power class based on Primary Key.
		/// </summary>
		public clsLU_Phase_Power(decimal pK_LU_Phase_Power) 
		{
			DataTable dtLU_Phase_Power = SelectByPK(pK_LU_Phase_Power).Tables[0];

			if (dtLU_Phase_Power.Rows.Count == 1)
			{
				 SetValue(dtLU_Phase_Power.Rows[0]);

			}

		}


		/// <summary>
		/// Initializes a new instance of the clsLU_Phase_Power class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drLU_Phase_Power) 
		{
				if (drLU_Phase_Power["PK_LU_Phase_Power"] == DBNull.Value)
					this._PK_LU_Phase_Power = null;
				else
					this._PK_LU_Phase_Power = (decimal?)drLU_Phase_Power["PK_LU_Phase_Power"];

				if (drLU_Phase_Power["Fld_Desc"] == DBNull.Value)
					this._Fld_Desc = null;
				else
					this._Fld_Desc = (string)drLU_Phase_Power["Fld_Desc"];

				if (drLU_Phase_Power["Active"] == DBNull.Value)
					this._Active = null;
				else
					this._Active = (string)drLU_Phase_Power["Active"];


		}

		#endregion

		/// <summary>
		/// Inserts a record into the LU_Phase_Power table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Phase_PowerInsert");

			
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
		/// Selects a single record from the LU_Phase_Power table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		private DataSet SelectByPK(decimal pK_LU_Phase_Power)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Phase_PowerSelectByPK");

			db.AddInParameter(dbCommand, "PK_LU_Phase_Power", DbType.Decimal, pK_LU_Phase_Power);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the LU_Phase_Power table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Phase_PowerSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the LU_Phase_Power table.
		/// </summary>
		public int Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Phase_PowerUpdate");

			
			db.AddInParameter(dbCommand, "PK_LU_Phase_Power", DbType.Decimal, this._PK_LU_Phase_Power);
			
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
		/// Deletes a record from the LU_Phase_Power table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_LU_Phase_Power)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Phase_PowerDeleteByPK");

			db.AddInParameter(dbCommand, "PK_LU_Phase_Power", DbType.Decimal, pK_LU_Phase_Power);

			db.ExecuteNonQuery(dbCommand);
		}
	}
}
