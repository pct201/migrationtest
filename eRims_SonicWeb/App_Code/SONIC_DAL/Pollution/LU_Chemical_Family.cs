using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for LU_Chemical_Family table.
	/// </summary>
	public sealed class LU_Chemical_Family
	{

		#region Private variables used to hold the property values

		private decimal? _PK_LU_Chemical_Family;
		private string _Fld_Desc;
		private string _Active;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_LU_Chemical_Family value.
		/// </summary>
		public decimal? PK_LU_Chemical_Family
		{
			get { return _PK_LU_Chemical_Family; }
			set { _PK_LU_Chemical_Family = value; }
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
		/// Initializes a new instance of the clsLU_Chemical_Family class with default value.
		/// </summary>
		public LU_Chemical_Family() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the clsLU_Chemical_Family class based on Primary Key.
		/// </summary>
		public LU_Chemical_Family(decimal pK_LU_Chemical_Family) 
		{
			DataTable dtLU_Chemical_Family = SelectByPK(pK_LU_Chemical_Family).Tables[0];

			if (dtLU_Chemical_Family.Rows.Count == 1)
			{
				 SetValue(dtLU_Chemical_Family.Rows[0]);

			}

		}


		/// <summary>
		/// Initializes a new instance of the clsLU_Chemical_Family class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drLU_Chemical_Family) 
		{
				if (drLU_Chemical_Family["PK_LU_Chemical_Family"] == DBNull.Value)
					this._PK_LU_Chemical_Family = null;
				else
					this._PK_LU_Chemical_Family = (decimal?)drLU_Chemical_Family["PK_LU_Chemical_Family"];

				if (drLU_Chemical_Family["Fld_Desc"] == DBNull.Value)
					this._Fld_Desc = null;
				else
					this._Fld_Desc = (string)drLU_Chemical_Family["Fld_Desc"];

				if (drLU_Chemical_Family["Active"] == DBNull.Value)
					this._Active = null;
				else
					this._Active = (string)drLU_Chemical_Family["Active"];


		}

		#endregion

		/// <summary>
		/// Inserts a record into the LU_Chemical_Family table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Chemical_FamilyInsert");

			
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
		/// Selects a single record from the LU_Chemical_Family table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		private DataSet SelectByPK(decimal pK_LU_Chemical_Family)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Chemical_FamilySelectByPK");

			db.AddInParameter(dbCommand, "PK_LU_Chemical_Family", DbType.Decimal, pK_LU_Chemical_Family);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the LU_Chemical_Family table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Chemical_FamilySelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the LU_Chemical_Family table.
		/// </summary>
		public int Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Chemical_FamilyUpdate");

			
			db.AddInParameter(dbCommand, "PK_LU_Chemical_Family", DbType.Decimal, this._PK_LU_Chemical_Family);
			
			if (string.IsNullOrEmpty(this._Fld_Desc))
				db.AddInParameter(dbCommand, "Fld_Desc", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Fld_Desc", DbType.String, this._Fld_Desc);
			
			if (string.IsNullOrEmpty(this._Active))
				db.AddInParameter(dbCommand, "Active", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Active", DbType.String, this._Active);

            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
		}

		/// <summary>
		/// Deletes a record from the LU_Chemical_Family table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_LU_Chemical_Family)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Chemical_FamilyDeleteByPK");

			db.AddInParameter(dbCommand, "PK_LU_Chemical_Family", DbType.Decimal, pK_LU_Chemical_Family);

			db.ExecuteNonQuery(dbCommand);
		}
	}
}
