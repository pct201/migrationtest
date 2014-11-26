using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for LU_PM_Hazardous_Waste_Codes table.
	/// </summary>
	public sealed class LU_PM_Hazardous_Waste_Codes
	{

		#region Private variables used to hold the property values

		private decimal? _PK_LU_PM_Hazardous_Waste_Codes;
		private string _Fld_Code;
		private string _Active;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_LU_PM_Hazardous_Waste_Codes value.
		/// </summary>
		public decimal? PK_LU_PM_Hazardous_Waste_Codes
		{
			get { return _PK_LU_PM_Hazardous_Waste_Codes; }
			set { _PK_LU_PM_Hazardous_Waste_Codes = value; }
		}

		/// <summary>
		/// Gets or sets the Fld_Code value.
		/// </summary>
		public string Fld_Code
		{
			get { return _Fld_Code; }
			set { _Fld_Code = value; }
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
		/// Initializes a new instance of the clsLU_PM_Hazardous_Waste_Codes class with default value.
		/// </summary>
		public LU_PM_Hazardous_Waste_Codes() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the clsLU_PM_Hazardous_Waste_Codes class based on Primary Key.
		/// </summary>
		public LU_PM_Hazardous_Waste_Codes(decimal pK_LU_PM_Hazardous_Waste_Codes) 
		{
			DataTable dtLU_PM_Hazardous_Waste_Codes = SelectByPK(pK_LU_PM_Hazardous_Waste_Codes).Tables[0];

			if (dtLU_PM_Hazardous_Waste_Codes.Rows.Count == 1)
			{
				 SetValue(dtLU_PM_Hazardous_Waste_Codes.Rows[0]);

			}

		}


		/// <summary>
		/// Initializes a new instance of the clsLU_PM_Hazardous_Waste_Codes class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drLU_PM_Hazardous_Waste_Codes) 
		{
				if (drLU_PM_Hazardous_Waste_Codes["PK_LU_PM_Hazardous_Waste_Codes"] == DBNull.Value)
					this._PK_LU_PM_Hazardous_Waste_Codes = null;
				else
					this._PK_LU_PM_Hazardous_Waste_Codes = (decimal?)drLU_PM_Hazardous_Waste_Codes["PK_LU_PM_Hazardous_Waste_Codes"];

				if (drLU_PM_Hazardous_Waste_Codes["Fld_Code"] == DBNull.Value)
					this._Fld_Code = null;
				else
					this._Fld_Code = (string)drLU_PM_Hazardous_Waste_Codes["Fld_Code"];

				if (drLU_PM_Hazardous_Waste_Codes["Active"] == DBNull.Value)
					this._Active = null;
				else
					this._Active = (string)drLU_PM_Hazardous_Waste_Codes["Active"];


		}

		#endregion

		/// <summary>
		/// Inserts a record into the LU_PM_Hazardous_Waste_Codes table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_PM_Hazardous_Waste_CodesInsert");

			
			if (string.IsNullOrEmpty(this._Fld_Code))
				db.AddInParameter(dbCommand, "Fld_Code", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Fld_Code", DbType.String, this._Fld_Code);
			
			if (string.IsNullOrEmpty(this._Active))
				db.AddInParameter(dbCommand, "Active", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Active", DbType.String, this._Active);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the LU_PM_Hazardous_Waste_Codes table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		private DataSet SelectByPK(decimal pK_LU_PM_Hazardous_Waste_Codes)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_PM_Hazardous_Waste_CodesSelectByPK");

			db.AddInParameter(dbCommand, "PK_LU_PM_Hazardous_Waste_Codes", DbType.Decimal, pK_LU_PM_Hazardous_Waste_Codes);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the LU_PM_Hazardous_Waste_Codes table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_PM_Hazardous_Waste_CodesSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the LU_PM_Hazardous_Waste_Codes table.
		/// </summary>
		public int Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_PM_Hazardous_Waste_CodesUpdate");
			
			db.AddInParameter(dbCommand, "PK_LU_PM_Hazardous_Waste_Codes", DbType.Decimal, this._PK_LU_PM_Hazardous_Waste_Codes);
			
			if (string.IsNullOrEmpty(this._Fld_Code))
				db.AddInParameter(dbCommand, "Fld_Code", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Fld_Code", DbType.String, this._Fld_Code);
			
			if (string.IsNullOrEmpty(this._Active))
				db.AddInParameter(dbCommand, "Active", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Active", DbType.String, this._Active);

            // Execute the query and return the new identity value
            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
		}

		/// <summary>
		/// Deletes a record from the LU_PM_Hazardous_Waste_Codes table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_LU_PM_Hazardous_Waste_Codes)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_PM_Hazardous_Waste_CodesDeleteByPK");

			db.AddInParameter(dbCommand, "PK_LU_PM_Hazardous_Waste_Codes", DbType.Decimal, pK_LU_PM_Hazardous_Waste_Codes);

			db.ExecuteNonQuery(dbCommand);
		}
	}
}
