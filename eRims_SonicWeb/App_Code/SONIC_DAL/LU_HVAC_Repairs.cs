using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for table LU_HVAC_Repairs
	/// </summary>
	public sealed class LU_HVAC_Repairs
	{

		#region Private variables used to hold the property values

		private decimal? _PK_LU_HVAC_Repairs;
		private string _Description;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_LU_HVAC_Repairs value.
		/// </summary>
		public decimal? PK_LU_HVAC_Repairs
		{
			get { return _PK_LU_HVAC_Repairs; }
			set { _PK_LU_HVAC_Repairs = value; }
		}

		/// <summary>
		/// Gets or sets the Description value.
		/// </summary>
		public string Description
		{
			get { return _Description; }
			set { _Description = value; }
		}


		#endregion

		#region Default Constructors

		/// <summary>
		/// Initializes a new instance of the LU_HVAC_Repairs class with default value.
		/// </summary>
		public LU_HVAC_Repairs() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the LU_HVAC_Repairs class based on Primary Key.
		/// </summary>
		public LU_HVAC_Repairs(decimal pK_LU_HVAC_Repairs) 
		{
			DataTable dtLU_HVAC_Repairs = Select(pK_LU_HVAC_Repairs).Tables[0];

			if (dtLU_HVAC_Repairs.Rows.Count == 1)
			{
				 SetValue(dtLU_HVAC_Repairs.Rows[0]);

			}

		}


		/// <summary>
		/// Initializes a new instance of the LU_HVAC_Repairs class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drLU_HVAC_Repairs) 
		{
				if (drLU_HVAC_Repairs["PK_LU_HVAC_Repairs"] == DBNull.Value)
					this._PK_LU_HVAC_Repairs = null;
				else
					this._PK_LU_HVAC_Repairs = (decimal?)drLU_HVAC_Repairs["PK_LU_HVAC_Repairs"];

				if (drLU_HVAC_Repairs["Description"] == DBNull.Value)
					this._Description = null;
				else
					this._Description = (string)drLU_HVAC_Repairs["Description"];


		}

		#endregion

		/// <summary>
		/// Inserts a record into the LU_HVAC_Repairs table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_HVAC_RepairsInsert");

			
			if (string.IsNullOrEmpty(this._Description))
				db.AddInParameter(dbCommand, "Description", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Description", DbType.String, this._Description);

			// Execute the query and return the new identity value
			return Convert.ToInt32(db.ExecuteScalar(dbCommand));
		}

		/// <summary>
		/// Selects a single record from the LU_HVAC_Repairs table.
		/// </summary>
		/// <returns>DataSet</returns>
		private DataSet Select(decimal pK_LU_HVAC_Repairs)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_HVAC_RepairsSelect");

			db.AddInParameter(dbCommand, "PK_LU_HVAC_Repairs", DbType.Decimal, pK_LU_HVAC_Repairs);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the LU_HVAC_Repairs table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_HVAC_RepairsSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the LU_HVAC_Repairs table.
		/// </summary>
		public decimal Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_HVAC_RepairsUpdate");

			
			db.AddInParameter(dbCommand, "PK_LU_HVAC_Repairs", DbType.Decimal, this._PK_LU_HVAC_Repairs);
			
			if (string.IsNullOrEmpty(this._Description))
				db.AddInParameter(dbCommand, "Description", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Description", DbType.String, this._Description);

            return Convert.ToDecimal(db.ExecuteScalar(dbCommand));
		}

		/// <summary>
		/// Deletes a record from the LU_HVAC_Repairs table by a composite primary key.
		/// </summary>
		public static void Delete(decimal pK_LU_HVAC_Repairs)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_HVAC_RepairsDelete");

			db.AddInParameter(dbCommand, "PK_LU_HVAC_Repairs", DbType.Decimal, pK_LU_HVAC_Repairs);

			db.ExecuteNonQuery(dbCommand);
		}
	}
}
