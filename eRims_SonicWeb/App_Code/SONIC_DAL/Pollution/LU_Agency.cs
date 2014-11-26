using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for LU_Agency table.
	/// </summary>
	public sealed class LU_Agency
	{

		#region Private variables used to hold the property values

		private decimal? _PK_LU_Agency;
		private string _Fld_Desc;
		private string _Active;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_LU_Agency value.
		/// </summary>
		public decimal? PK_LU_Agency
		{
			get { return _PK_LU_Agency; }
			set { _PK_LU_Agency = value; }
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
		/// Initializes a new instance of the LU_Agency class with default value.
		/// </summary>
		public LU_Agency() 
		{

			this._PK_LU_Agency = null;
			this._Fld_Desc = null;
			this._Active = null;

		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the LU_Agency class based on Primary Key.
		/// </summary>
		public LU_Agency(decimal pK_LU_Agency) 
		{
			DataTable dtLU_Agency = SelectByPK(pK_LU_Agency).Tables[0];

			if (dtLU_Agency.Rows.Count == 1)
			{
				DataRow drLU_Agency = dtLU_Agency.Rows[0];
				if (drLU_Agency["PK_LU_Agency"] == DBNull.Value)
					this._PK_LU_Agency = null;
				else
					this._PK_LU_Agency = (decimal?)drLU_Agency["PK_LU_Agency"];

				if (drLU_Agency["Fld_Desc"] == DBNull.Value)
					this._Fld_Desc = null;
				else
					this._Fld_Desc = (string)drLU_Agency["Fld_Desc"];

				if (drLU_Agency["Active"] == DBNull.Value)
					this._Active = null;
				else
					this._Active = (string)drLU_Agency["Active"];

			}
			else
			{
				this._PK_LU_Agency = null;
				this._Fld_Desc = null;
				this._Active = null;
			}

		}

		#endregion

		/// <summary>
		/// Inserts a record into the LU_Agency table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_AgencyInsert");

			
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
		/// Selects a single record from the LU_Agency table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		private static DataSet SelectByPK(decimal pK_LU_Agency)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_AgencySelectByPK");

			db.AddInParameter(dbCommand, "PK_LU_Agency", DbType.Decimal, pK_LU_Agency);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the LU_Agency table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_AgencySelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the LU_Agency table.
		/// </summary>
		public int Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_AgencyUpdate");

			
			db.AddInParameter(dbCommand, "PK_LU_Agency", DbType.Decimal, this._PK_LU_Agency);
			
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
		/// Deletes a record from the LU_Agency table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_LU_Agency)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_AgencyDeleteByPK");

			db.AddInParameter(dbCommand, "PK_LU_Agency", DbType.Decimal, pK_LU_Agency);

			db.ExecuteNonQuery(dbCommand);
		}
	}
}
