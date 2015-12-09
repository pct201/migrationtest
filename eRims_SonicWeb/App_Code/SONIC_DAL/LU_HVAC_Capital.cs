using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for table LU_HVAC_Capital
	/// </summary>
	public sealed class LU_HVAC_Capital
	{

		#region Private variables used to hold the property values

		private decimal? _PK_LU_HVAC_Capital;
		private string _Description;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_LU_HVAC_Capital value.
		/// </summary>
		public decimal? PK_LU_HVAC_Capital
		{
			get { return _PK_LU_HVAC_Capital; }
			set { _PK_LU_HVAC_Capital = value; }
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
		/// Initializes a new instance of the LU_HVAC_Capital class with default value.
		/// </summary>
		public LU_HVAC_Capital() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the LU_HVAC_Capital class based on Primary Key.
		/// </summary>
		public LU_HVAC_Capital(decimal pK_LU_HVAC_Capital) 
		{
			DataTable dtLU_HVAC_Capital = Select(pK_LU_HVAC_Capital).Tables[0];

			if (dtLU_HVAC_Capital.Rows.Count == 1)
			{
				 SetValue(dtLU_HVAC_Capital.Rows[0]);

			}

		}


		/// <summary>
		/// Initializes a new instance of the LU_HVAC_Capital class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drLU_HVAC_Capital) 
		{
				if (drLU_HVAC_Capital["PK_LU_HVAC_Capital"] == DBNull.Value)
					this._PK_LU_HVAC_Capital = null;
				else
					this._PK_LU_HVAC_Capital = (decimal?)drLU_HVAC_Capital["PK_LU_HVAC_Capital"];

				if (drLU_HVAC_Capital["Description"] == DBNull.Value)
					this._Description = null;
				else
					this._Description = (string)drLU_HVAC_Capital["Description"];


		}

		#endregion

		/// <summary>
		/// Inserts a record into the LU_HVAC_Capital table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_HVAC_CapitalInsert");

			
			if (string.IsNullOrEmpty(this._Description))
				db.AddInParameter(dbCommand, "Description", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Description", DbType.String, this._Description);

			// Execute the query and return the new identity value
			return Convert.ToInt32(db.ExecuteScalar(dbCommand));
		}

		/// <summary>
		/// Selects a single record from the LU_HVAC_Capital table.
		/// </summary>
		/// <returns>DataSet</returns>
		private DataSet Select(decimal pK_LU_HVAC_Capital)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_HVAC_CapitalSelect");

			db.AddInParameter(dbCommand, "PK_LU_HVAC_Capital", DbType.Decimal, pK_LU_HVAC_Capital);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the LU_HVAC_Capital table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_HVAC_CapitalSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the LU_HVAC_Capital table.
		/// </summary>
		public int Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_HVAC_CapitalUpdate");

			
			db.AddInParameter(dbCommand, "PK_LU_HVAC_Capital", DbType.Decimal, this._PK_LU_HVAC_Capital);
			
			if (string.IsNullOrEmpty(this._Description))
				db.AddInParameter(dbCommand, "Description", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Description", DbType.String, this._Description);

            return Convert.ToInt32(db.ExecuteScalar(dbCommand));
		}

		/// <summary>
		/// Deletes a record from the LU_HVAC_Capital table by a composite primary key.
		/// </summary>
		public static void Delete(decimal pK_LU_HVAC_Capital)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_HVAC_CapitalDelete");

			db.AddInParameter(dbCommand, "PK_LU_HVAC_Capital", DbType.Decimal, pK_LU_HVAC_Capital);

			db.ExecuteNonQuery(dbCommand);
		}
	}
}
