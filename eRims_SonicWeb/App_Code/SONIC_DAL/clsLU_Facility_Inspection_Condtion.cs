using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for LU_Facility_Inspection_Condition table.
	/// </summary>
	public sealed class clsLU_Facility_Inspection_Condition
	{
		#region Private variables used to hold the property values

		private decimal? _PK_LU_Facility_Inspection_Condition;
		private string _Description;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_LU_Facility_Inspection_Condition value.
		/// </summary>
		public decimal? PK_LU_Facility_Inspection_Condition
		{
			get { return _PK_LU_Facility_Inspection_Condition; }
			set { _PK_LU_Facility_Inspection_Condition = value; }
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
		/// Initializes a new instance of the clsLU_Facility_Inspection_Condition class with default value.
		/// </summary>
		public clsLU_Facility_Inspection_Condition() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the clsLU_Facility_Inspection_Condition class based on Primary Key.
		/// </summary>
		public clsLU_Facility_Inspection_Condition(decimal pK_LU_Facility_Inspection_Condition) 
		{
			DataTable dtLU_Facility_Inspection_Condition = SelectByPK(pK_LU_Facility_Inspection_Condition).Tables[0];

			if (dtLU_Facility_Inspection_Condition.Rows.Count == 1)
			{
				 SetValue(dtLU_Facility_Inspection_Condition.Rows[0]);

			}
		}

		/// <summary>
		/// Initializes a new instance of the clsLU_Facility_Inspection_Condition class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drLU_Facility_Inspection_Condition) 
		{
				if (drLU_Facility_Inspection_Condition["PK_LU_Facility_Inspection_Condition"] == DBNull.Value)
					this._PK_LU_Facility_Inspection_Condition = null;
				else
					this._PK_LU_Facility_Inspection_Condition = (decimal?)drLU_Facility_Inspection_Condition["PK_LU_Facility_Inspection_Condition"];

				if (drLU_Facility_Inspection_Condition["Description"] == DBNull.Value)
					this._Description = null;
				else
					this._Description = (string)drLU_Facility_Inspection_Condition["Description"];
		}

		#endregion

		/// <summary>
		/// Inserts a record into the LU_Facility_Inspection_Condition table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Facility_Inspection_ConditionInsert");
			
			if (string.IsNullOrEmpty(this._Description))
				db.AddInParameter(dbCommand, "Description", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Description", DbType.String, this._Description);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the LU_Facility_Inspection_Condition table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		private DataSet SelectByPK(decimal pK_LU_Facility_Inspection_Condition)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Facility_Inspection_ConditionSelectByPK");

			db.AddInParameter(dbCommand, "PK_LU_Facility_Inspection_Condition", DbType.Decimal, pK_LU_Facility_Inspection_Condition);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the LU_Facility_Inspection_Condition table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Facility_Inspection_ConditionSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the LU_Facility_Inspection_Condition table.
		/// </summary>
		public decimal Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Facility_Inspection_ConditionUpdate");
			
			db.AddInParameter(dbCommand, "PK_LU_Facility_Inspection_Condition", DbType.Decimal, this._PK_LU_Facility_Inspection_Condition);
			
			if (string.IsNullOrEmpty(this._Description))
				db.AddInParameter(dbCommand, "Description", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Description", DbType.String, this._Description);

            return (Convert.ToDecimal(db.ExecuteScalar(dbCommand)));
		}

		/// <summary>
		/// Deletes a record from the LU_Facility_Inspection_Condition table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_LU_Facility_Inspection_Condition)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Facility_Inspection_ConditionDeleteByPK");

			db.AddInParameter(dbCommand, "PK_LU_Facility_Inspection_Condition", DbType.Decimal, pK_LU_Facility_Inspection_Condition);

			db.ExecuteNonQuery(dbCommand);
		}
	}
}
