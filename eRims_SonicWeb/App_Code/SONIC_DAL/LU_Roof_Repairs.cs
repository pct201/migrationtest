using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for table LU_Roof_Repairs
	/// </summary>
	public sealed class LU_Roof_Repairs
	{

		#region Private variables used to hold the property values

		private decimal? _PK_LU_Roof_Repairs;
		private string _Description;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_LU_Roof_Repairs value.
		/// </summary>
		public decimal? PK_LU_Roof_Repairs
		{
			get { return _PK_LU_Roof_Repairs; }
			set { _PK_LU_Roof_Repairs = value; }
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
		/// Initializes a new instance of the LU_Roof_Repairs class with default value.
		/// </summary>
		public LU_Roof_Repairs() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the LU_Roof_Repairs class based on Primary Key.
		/// </summary>
		public LU_Roof_Repairs(decimal pK_LU_Roof_Repairs) 
		{
			DataTable dtLU_Roof_Repairs = Select(pK_LU_Roof_Repairs).Tables[0];

			if (dtLU_Roof_Repairs.Rows.Count == 1)
			{
				 SetValue(dtLU_Roof_Repairs.Rows[0]);

			}

		}


		/// <summary>
		/// Initializes a new instance of the LU_Roof_Repairs class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drLU_Roof_Repairs) 
		{
				if (drLU_Roof_Repairs["PK_LU_Roof_Repairs"] == DBNull.Value)
					this._PK_LU_Roof_Repairs = null;
				else
					this._PK_LU_Roof_Repairs = (decimal?)drLU_Roof_Repairs["PK_LU_Roof_Repairs"];

				if (drLU_Roof_Repairs["Description"] == DBNull.Value)
					this._Description = null;
				else
					this._Description = (string)drLU_Roof_Repairs["Description"];


		}

		#endregion

		/// <summary>
		/// Inserts a record into the LU_Roof_Repairs table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Roof_RepairsInsert");

			
			if (string.IsNullOrEmpty(this._Description))
				db.AddInParameter(dbCommand, "Description", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Description", DbType.String, this._Description);

			// Execute the query and return the new identity value
			return Convert.ToInt32(db.ExecuteScalar(dbCommand));
		}

		/// <summary>
		/// Selects a single record from the LU_Roof_Repairs table.
		/// </summary>
		/// <returns>DataSet</returns>
		private DataSet Select(decimal pK_LU_Roof_Repairs)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Roof_RepairsSelect");

			db.AddInParameter(dbCommand, "PK_LU_Roof_Repairs", DbType.Decimal, pK_LU_Roof_Repairs);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the LU_Roof_Repairs table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Roof_RepairsSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the LU_Roof_Repairs table.
		/// </summary>
		public int Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Roof_RepairsUpdate");

			
			db.AddInParameter(dbCommand, "PK_LU_Roof_Repairs", DbType.Decimal, this._PK_LU_Roof_Repairs);
			
			if (string.IsNullOrEmpty(this._Description))
				db.AddInParameter(dbCommand, "Description", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Description", DbType.String, this._Description);

            return Convert.ToInt32(db.ExecuteScalar(dbCommand));
		}

		/// <summary>
		/// Deletes a record from the LU_Roof_Repairs table by a composite primary key.
		/// </summary>
		public static void Delete(decimal pK_LU_Roof_Repairs)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Roof_RepairsDelete");

			db.AddInParameter(dbCommand, "PK_LU_Roof_Repairs", DbType.Decimal, pK_LU_Roof_Repairs);

			db.ExecuteNonQuery(dbCommand);
		}
	}
}
