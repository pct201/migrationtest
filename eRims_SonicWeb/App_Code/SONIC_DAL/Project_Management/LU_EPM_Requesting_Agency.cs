using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for LU_EPM_Requesting_Agency table.
	/// </summary>
	public sealed class LU_EPM_Requesting_Agency
	{

		#region Private variables used to hold the property values

		private decimal? _PK_LU_EPM_Requesting_Agency;
		private string _Fld_Desc;
		private string _Active;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_LU_EPM_Requesting_Agency value.
		/// </summary>
		public decimal? PK_LU_EPM_Requesting_Agency
		{
			get { return _PK_LU_EPM_Requesting_Agency; }
			set { _PK_LU_EPM_Requesting_Agency = value; }
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
		/// Initializes a new instance of the clsLU_EPM_Requesting_Agency class with default value.
		/// </summary>
		public LU_EPM_Requesting_Agency() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the clsLU_EPM_Requesting_Agency class based on Primary Key.
		/// </summary>
		public LU_EPM_Requesting_Agency(decimal pK_LU_EPM_Requesting_Agency) 
		{
			DataTable dtLU_EPM_Requesting_Agency = SelectByPK(pK_LU_EPM_Requesting_Agency).Tables[0];

			if (dtLU_EPM_Requesting_Agency.Rows.Count == 1)
			{
				 SetValue(dtLU_EPM_Requesting_Agency.Rows[0]);

			}

		}


		/// <summary>
		/// Initializes a new instance of the clsLU_EPM_Requesting_Agency class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drLU_EPM_Requesting_Agency) 
		{
				if (drLU_EPM_Requesting_Agency["PK_LU_EPM_Requesting_Agency"] == DBNull.Value)
					this._PK_LU_EPM_Requesting_Agency = null;
				else
					this._PK_LU_EPM_Requesting_Agency = (decimal?)drLU_EPM_Requesting_Agency["PK_LU_EPM_Requesting_Agency"];

				if (drLU_EPM_Requesting_Agency["Fld_Desc"] == DBNull.Value)
					this._Fld_Desc = null;
				else
					this._Fld_Desc = (string)drLU_EPM_Requesting_Agency["Fld_Desc"];

				if (drLU_EPM_Requesting_Agency["Active"] == DBNull.Value)
					this._Active = null;
				else
					this._Active = (string)drLU_EPM_Requesting_Agency["Active"];


		}

		#endregion

		/// <summary>
		/// Inserts a record into the LU_EPM_Requesting_Agency table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_EPM_Requesting_AgencyInsert");

			
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
		/// Selects a single record from the LU_EPM_Requesting_Agency table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		private DataSet SelectByPK(decimal pK_LU_EPM_Requesting_Agency)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_EPM_Requesting_AgencySelectByPK");

			db.AddInParameter(dbCommand, "PK_LU_EPM_Requesting_Agency", DbType.Decimal, pK_LU_EPM_Requesting_Agency);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the LU_EPM_Requesting_Agency table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_EPM_Requesting_AgencySelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the LU_EPM_Requesting_Agency table.
		/// </summary>
		public decimal Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_EPM_Requesting_AgencyUpdate");

			
			db.AddInParameter(dbCommand, "PK_LU_EPM_Requesting_Agency", DbType.Decimal, this._PK_LU_EPM_Requesting_Agency);
			
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
		/// Deletes a record from the LU_EPM_Requesting_Agency table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_LU_EPM_Requesting_Agency)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_EPM_Requesting_AgencyDeleteByPK");

			db.AddInParameter(dbCommand, "PK_LU_EPM_Requesting_Agency", DbType.Decimal, pK_LU_EPM_Requesting_Agency);

			db.ExecuteNonQuery(dbCommand);
		}
	}
}
