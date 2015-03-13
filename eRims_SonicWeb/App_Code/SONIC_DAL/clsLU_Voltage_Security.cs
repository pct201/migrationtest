using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for LU_Voltage_Security table.
	/// </summary>
	public sealed class clsLU_Voltage_Security
	{

		#region Private variables used to hold the property values

		private decimal? _PK_LU_Voltage_Security;
		private string _Fld_Desc;
		private string _Active;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_LU_Voltage_Security value.
		/// </summary>
		public decimal? PK_LU_Voltage_Security
		{
			get { return _PK_LU_Voltage_Security; }
			set { _PK_LU_Voltage_Security = value; }
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
		/// Initializes a new instance of the clsLU_Voltage_Security class with default value.
		/// </summary>
		public clsLU_Voltage_Security() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the clsLU_Voltage_Security class based on Primary Key.
		/// </summary>
		public clsLU_Voltage_Security(decimal pK_LU_Voltage_Security) 
		{
			DataTable dtLU_Voltage_Security = SelectByPK(pK_LU_Voltage_Security).Tables[0];

			if (dtLU_Voltage_Security.Rows.Count == 1)
			{
				 SetValue(dtLU_Voltage_Security.Rows[0]);

			}

		}


		/// <summary>
		/// Initializes a new instance of the clsLU_Voltage_Security class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drLU_Voltage_Security) 
		{
				if (drLU_Voltage_Security["PK_LU_Voltage_Security"] == DBNull.Value)
					this._PK_LU_Voltage_Security = null;
				else
					this._PK_LU_Voltage_Security = (decimal?)drLU_Voltage_Security["PK_LU_Voltage_Security"];

				if (drLU_Voltage_Security["Fld_Desc"] == DBNull.Value)
					this._Fld_Desc = null;
				else
					this._Fld_Desc = (string)drLU_Voltage_Security["Fld_Desc"];

				if (drLU_Voltage_Security["Active"] == DBNull.Value)
					this._Active = null;
				else
					this._Active = (string)drLU_Voltage_Security["Active"];


		}

		#endregion

		/// <summary>
		/// Inserts a record into the LU_Voltage_Security table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Voltage_SecurityInsert");

			
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
		/// Selects a single record from the LU_Voltage_Security table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		private DataSet SelectByPK(decimal pK_LU_Voltage_Security)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Voltage_SecuritySelectByPK");

			db.AddInParameter(dbCommand, "PK_LU_Voltage_Security", DbType.Decimal, pK_LU_Voltage_Security);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the LU_Voltage_Security table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Voltage_SecuritySelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

        /// <summary>
        /// Selects all records from the LU_Voltage_Security table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAllByActive()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_Voltage_SecuritySelectAllByActive");

            return db.ExecuteDataSet(dbCommand);
        }

		/// <summary>
		/// Updates a record in the LU_Voltage_Security table.
		/// </summary>
		public int Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Voltage_SecurityUpdate");

			
			db.AddInParameter(dbCommand, "PK_LU_Voltage_Security", DbType.Decimal, this._PK_LU_Voltage_Security);
			
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
		/// Deletes a record from the LU_Voltage_Security table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_LU_Voltage_Security)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Voltage_SecurityDeleteByPK");

			db.AddInParameter(dbCommand, "PK_LU_Voltage_Security", DbType.Decimal, pK_LU_Voltage_Security);

			db.ExecuteNonQuery(dbCommand);
		}
	}
}
