using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for LU_Company table.
	/// </summary>
	public sealed class clsLU_Company
	{

		#region Private variables used to hold the property values

		private decimal? _PK_LU_Company;
		private string _Fld_Code;
		private string _Fld_Desc;
		private string _Active;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_LU_Company value.
		/// </summary>
		public decimal? PK_LU_Company
		{
			get { return _PK_LU_Company; }
			set { _PK_LU_Company = value; }
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
		/// Initializes a new instance of the clsLU_Company class with default value.
		/// </summary>
		public clsLU_Company() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the clsLU_Company class based on Primary Key.
		/// </summary>
		public clsLU_Company(decimal pK_LU_Company) 
		{
			DataTable dtLU_Company = SelectByPK(pK_LU_Company).Tables[0];

			if (dtLU_Company.Rows.Count == 1)
			{
				 SetValue(dtLU_Company.Rows[0]);

			}

		}


		/// <summary>
		/// Initializes a new instance of the clsLU_Company class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drLU_Company) 
		{
				if (drLU_Company["PK_LU_Company"] == DBNull.Value)
					this._PK_LU_Company = null;
				else
					this._PK_LU_Company = (decimal?)drLU_Company["PK_LU_Company"];

				if (drLU_Company["Fld_Code"] == DBNull.Value)
					this._Fld_Code = null;
				else
					this._Fld_Code = (string)drLU_Company["Fld_Code"];

				if (drLU_Company["Fld_Desc"] == DBNull.Value)
					this._Fld_Desc = null;
				else
					this._Fld_Desc = (string)drLU_Company["Fld_Desc"];

				if (drLU_Company["Active"] == DBNull.Value)
					this._Active = null;
				else
					this._Active = (string)drLU_Company["Active"];


		}

		#endregion

		/// <summary>
		/// Inserts a record into the LU_Company table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_CompanyInsert");

			
			if (string.IsNullOrEmpty(this._Fld_Code))
				db.AddInParameter(dbCommand, "Fld_Code", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Fld_Code", DbType.String, this._Fld_Code);
			
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
		/// Selects a single record from the LU_Company table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		private DataSet SelectByPK(decimal pK_LU_Company)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_CompanySelectByPK");

			db.AddInParameter(dbCommand, "PK_LU_Company", DbType.Decimal, pK_LU_Company);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the LU_Company table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_CompanySelectAll");

			return db.ExecuteDataSet(dbCommand);
		}


		/// <summary>
		/// Updates a record in the LU_Company table.
		/// </summary>
		public int Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_CompanyUpdate");

			
			db.AddInParameter(dbCommand, "PK_LU_Company", DbType.Decimal, this._PK_LU_Company);
			
			if (string.IsNullOrEmpty(this._Fld_Code))
				db.AddInParameter(dbCommand, "Fld_Code", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Fld_Code", DbType.String, this._Fld_Code);
			
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
		/// Deletes a record from the LU_Company table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_LU_Company)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_CompanyDeleteByPK");

			db.AddInParameter(dbCommand, "PK_LU_Company", DbType.Decimal, pK_LU_Company);

			db.ExecuteNonQuery(dbCommand);
		}
	}
}
