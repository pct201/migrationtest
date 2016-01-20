using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for LU_Claim_SubType table.
	/// </summary>
	public sealed class LU_Claim_SubType
	{

		#region Private variables used to hold the property values

		private decimal? _PK_LU_Claim_SubType;
		private string _Fld_Code;
		private string _Fld_Description;
		private string _active;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_LU_Claim_SubType value.
		/// </summary>
		public decimal? PK_LU_Claim_SubType
		{
			get { return _PK_LU_Claim_SubType; }
			set { _PK_LU_Claim_SubType = value; }
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
		/// Gets or sets the Fld_Description value.
		/// </summary>
		public string Fld_Description
		{
			get { return _Fld_Description; }
			set { _Fld_Description = value; }
		}

		/// <summary>
		/// Gets or sets the active value.
		/// </summary>
		public string active
		{
			get { return _active; }
			set { _active = value; }
		}


		#endregion

		#region Default Constructors

		/// <summary>
		/// Initializes a new instance of the 
        /// LU_Claim_SubType class with default value.
		/// </summary>
		public LU_Claim_SubType() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the LU_Claim_SubType class based on Primary Key.
		/// </summary>
		public LU_Claim_SubType(decimal pK_LU_Claim_SubType) 
		{
			DataTable dtLU_Claim_SubType = SelectByPK(pK_LU_Claim_SubType).Tables[0];

			if (dtLU_Claim_SubType.Rows.Count == 1)
			{
				 SetValue(dtLU_Claim_SubType.Rows[0]);

			}

		}


		/// <summary>
		/// Initializes a new instance of the LU_Claim_SubType class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drLU_Claim_SubType) 
		{
				if (drLU_Claim_SubType["PK_LU_Claim_SubType"] == DBNull.Value)
					this._PK_LU_Claim_SubType = null;
				else
					this._PK_LU_Claim_SubType = (decimal?)drLU_Claim_SubType["PK_LU_Claim_SubType"];

				if (drLU_Claim_SubType["Fld_Code"] == DBNull.Value)
					this._Fld_Code = null;
				else
					this._Fld_Code = (string)drLU_Claim_SubType["Fld_Code"];

				if (drLU_Claim_SubType["Fld_Description"] == DBNull.Value)
					this._Fld_Description = null;
				else
					this._Fld_Description = (string)drLU_Claim_SubType["Fld_Description"];

				if (drLU_Claim_SubType["active"] == DBNull.Value)
					this._active = null;
				else
					this._active = (string)drLU_Claim_SubType["active"];


		}

		#endregion

		/// <summary>
		/// Inserts a record into the LU_Claim_SubType table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Claim_SubTypeInsert");

			
			if (string.IsNullOrEmpty(this._Fld_Code))
				db.AddInParameter(dbCommand, "Fld_Code", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Fld_Code", DbType.String, this._Fld_Code);
			
			if (string.IsNullOrEmpty(this._Fld_Description))
				db.AddInParameter(dbCommand, "Fld_Description", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Fld_Description", DbType.String, this._Fld_Description);
			
			if (string.IsNullOrEmpty(this._active))
				db.AddInParameter(dbCommand, "active", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "active", DbType.String, this._active);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the LU_Claim_SubType table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		private DataSet SelectByPK(decimal pK_LU_Claim_SubType)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Claim_SubTypeSelectByPK");

			db.AddInParameter(dbCommand, "PK_LU_Claim_SubType", DbType.Decimal, pK_LU_Claim_SubType);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the LU_Claim_SubType table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Claim_SubTypeSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the LU_Claim_SubType table.
		/// </summary>
		public void Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Claim_SubTypeUpdate");

			
			db.AddInParameter(dbCommand, "PK_LU_Claim_SubType", DbType.Decimal, this._PK_LU_Claim_SubType);
			
			if (string.IsNullOrEmpty(this._Fld_Code))
				db.AddInParameter(dbCommand, "Fld_Code", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Fld_Code", DbType.String, this._Fld_Code);
			
			if (string.IsNullOrEmpty(this._Fld_Description))
				db.AddInParameter(dbCommand, "Fld_Description", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Fld_Description", DbType.String, this._Fld_Description);
			
			if (string.IsNullOrEmpty(this._active))
				db.AddInParameter(dbCommand, "active", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "active", DbType.String, this._active);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the LU_Claim_SubType table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_LU_Claim_SubType)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Claim_SubTypeDeleteByPK");

			db.AddInParameter(dbCommand, "PK_LU_Claim_SubType", DbType.Decimal, pK_LU_Claim_SubType);

			db.ExecuteNonQuery(dbCommand);
		}
	}
}
