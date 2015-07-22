using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for LU_Facility_Cost_Codes table.
	/// </summary>
	public sealed class clsLU_Facility_Cost_Codes
	{

		#region Private variables used to hold the property values

		private decimal? _PK_LU_Facility_Cost_Codes;
		private string _Code;
		private string _Description;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_LU_Facility_Cost_Codes value.
		/// </summary>
		public decimal? PK_LU_Facility_Cost_Codes
		{
			get { return _PK_LU_Facility_Cost_Codes; }
			set { _PK_LU_Facility_Cost_Codes = value; }
		}

		/// <summary>
		/// Gets or sets the Code value.
		/// </summary>
		public string Code
		{
			get { return _Code; }
			set { _Code = value; }
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
		/// Initializes a new instance of the clsLU_Facility_Cost_Codes class with default value.
		/// </summary>
		public clsLU_Facility_Cost_Codes() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the clsLU_Facility_Cost_Codes class based on Primary Key.
		/// </summary>
		public clsLU_Facility_Cost_Codes(decimal pK_LU_Facility_Cost_Codes) 
		{
			DataTable dtLU_Facility_Cost_Codes = SelectByPK(pK_LU_Facility_Cost_Codes).Tables[0];

			if (dtLU_Facility_Cost_Codes.Rows.Count == 1)
			{
				 SetValue(dtLU_Facility_Cost_Codes.Rows[0]);

			}

		}


		/// <summary>
		/// Initializes a new instance of the clsLU_Facility_Cost_Codes class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drLU_Facility_Cost_Codes) 
		{
				if (drLU_Facility_Cost_Codes["PK_LU_Facility_Cost_Codes"] == DBNull.Value)
					this._PK_LU_Facility_Cost_Codes = null;
				else
					this._PK_LU_Facility_Cost_Codes = (decimal?)drLU_Facility_Cost_Codes["PK_LU_Facility_Cost_Codes"];

				if (drLU_Facility_Cost_Codes["Code"] == DBNull.Value)
					this._Code = null;
				else
					this._Code = (string)drLU_Facility_Cost_Codes["Code"];

				if (drLU_Facility_Cost_Codes["Description"] == DBNull.Value)
					this._Description = null;
				else
					this._Description = (string)drLU_Facility_Cost_Codes["Description"];


		}

		#endregion

		/// <summary>
		/// Inserts a record into the LU_Facility_Cost_Codes table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Facility_Cost_CodesInsert");

			
			if (string.IsNullOrEmpty(this._Code))
				db.AddInParameter(dbCommand, "Code", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Code", DbType.String, this._Code);
			
			if (string.IsNullOrEmpty(this._Description))
				db.AddInParameter(dbCommand, "Description", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Description", DbType.String, this._Description);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the LU_Facility_Cost_Codes table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		private DataSet SelectByPK(decimal pK_LU_Facility_Cost_Codes)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Facility_Cost_CodesSelectByPK");

			db.AddInParameter(dbCommand, "PK_LU_Facility_Cost_Codes", DbType.Decimal, pK_LU_Facility_Cost_Codes);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the LU_Facility_Cost_Codes table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Facility_Cost_CodesSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the LU_Facility_Cost_Codes table.
		/// </summary>
		public decimal Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Facility_Cost_CodesUpdate");

			
			db.AddInParameter(dbCommand, "PK_LU_Facility_Cost_Codes", DbType.Decimal, this._PK_LU_Facility_Cost_Codes);
			
			if (string.IsNullOrEmpty(this._Code))
				db.AddInParameter(dbCommand, "Code", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Code", DbType.String, this._Code);
			
			if (string.IsNullOrEmpty(this._Description))
				db.AddInParameter(dbCommand, "Description", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Description", DbType.String, this._Description);

            return Convert.ToDecimal(db.ExecuteScalar(dbCommand));
		}
	}
}
