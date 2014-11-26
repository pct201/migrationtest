using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for LU_Classification table.
	/// </summary>
	public sealed class LU_Classification
	{

		#region Private variables used to hold the property values

		private decimal? _PK_LU_Classification;
		private string _Fld_Code;
		private string _Fld_Desc;
		private string _Active;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_LU_Classification value.
		/// </summary>
		public decimal? PK_LU_Classification
		{
			get { return _PK_LU_Classification; }
			set { _PK_LU_Classification = value; }
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
		/// Initializes a new instance of the clsLU_Classification class with default value.
		/// </summary>
		public LU_Classification() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the clsLU_Classification class based on Primary Key.
		/// </summary>
		public LU_Classification(decimal pK_LU_Classification) 
		{
			DataTable dtLU_Classification = SelectByPK(pK_LU_Classification).Tables[0];

			if (dtLU_Classification.Rows.Count == 1)
			{
				 SetValue(dtLU_Classification.Rows[0]);

			}

		}


		/// <summary>
		/// Initializes a new instance of the clsLU_Classification class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drLU_Classification) 
		{
				if (drLU_Classification["PK_LU_Classification"] == DBNull.Value)
					this._PK_LU_Classification = null;
				else
					this._PK_LU_Classification = (decimal?)drLU_Classification["PK_LU_Classification"];

				if (drLU_Classification["Fld_Code"] == DBNull.Value)
					this._Fld_Code = null;
				else
					this._Fld_Code = (string)drLU_Classification["Fld_Code"];

				if (drLU_Classification["Fld_Desc"] == DBNull.Value)
					this._Fld_Desc = null;
				else
					this._Fld_Desc = (string)drLU_Classification["Fld_Desc"];

				if (drLU_Classification["Active"] == DBNull.Value)
					this._Active = null;
				else
					this._Active = (string)drLU_Classification["Active"];


		}

		#endregion

		/// <summary>
		/// Inserts a record into the LU_Classification table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_ClassificationInsert");

			
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
		/// Selects a single record from the LU_Classification table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		private DataSet SelectByPK(decimal pK_LU_Classification)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_ClassificationSelectByPK");

			db.AddInParameter(dbCommand, "PK_LU_Classification", DbType.Decimal, pK_LU_Classification);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the LU_Classification table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_ClassificationSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the LU_Classification table.
		/// </summary>
		public int Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_ClassificationUpdate");

			
			db.AddInParameter(dbCommand, "PK_LU_Classification", DbType.Decimal, this._PK_LU_Classification);
			
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
		/// Deletes a record from the LU_Classification table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_LU_Classification)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_ClassificationDeleteByPK");

			db.AddInParameter(dbCommand, "PK_LU_Classification", DbType.Decimal, pK_LU_Classification);

			db.ExecuteNonQuery(dbCommand);
		}
	}
}
