using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for LU_Tank_Construction table.
	/// </summary>
	public sealed class LU_Tank_Construction
	{

		#region Private variables used to hold the property values

		private decimal? _PK_LU_Tank_Construction;
		private string _Fld_Desc;
		private string _Active;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_LU_Tank_Construction value.
		/// </summary>
		public decimal? PK_LU_Tank_Construction
		{
			get { return _PK_LU_Tank_Construction; }
			set { _PK_LU_Tank_Construction = value; }
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
		/// Initializes a new instance of the clsLU_Tank_Construction class with default value.
		/// </summary>
		public LU_Tank_Construction() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the clsLU_Tank_Construction class based on Primary Key.
		/// </summary>
		public LU_Tank_Construction(decimal pK_LU_Tank_Construction) 
		{
			DataTable dtLU_Tank_Construction = SelectByPK(pK_LU_Tank_Construction).Tables[0];

			if (dtLU_Tank_Construction.Rows.Count == 1)
			{
				 SetValue(dtLU_Tank_Construction.Rows[0]);

			}

		}


		/// <summary>
		/// Initializes a new instance of the clsLU_Tank_Construction class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drLU_Tank_Construction) 
		{
				if (drLU_Tank_Construction["PK_LU_Tank_Construction"] == DBNull.Value)
					this._PK_LU_Tank_Construction = null;
				else
					this._PK_LU_Tank_Construction = (decimal?)drLU_Tank_Construction["PK_LU_Tank_Construction"];

				if (drLU_Tank_Construction["Fld_Desc"] == DBNull.Value)
					this._Fld_Desc = null;
				else
					this._Fld_Desc = (string)drLU_Tank_Construction["Fld_Desc"];

				if (drLU_Tank_Construction["Active"] == DBNull.Value)
					this._Active = null;
				else
					this._Active = (string)drLU_Tank_Construction["Active"];


		}

		#endregion

		/// <summary>
		/// Inserts a record into the LU_Tank_Construction table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Tank_ConstructionInsert");

			
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
		/// Selects a single record from the LU_Tank_Construction table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		private DataSet SelectByPK(decimal pK_LU_Tank_Construction)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Tank_ConstructionSelectByPK");

			db.AddInParameter(dbCommand, "PK_LU_Tank_Construction", DbType.Decimal, pK_LU_Tank_Construction);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the LU_Tank_Construction table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Tank_ConstructionSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the LU_Tank_Construction table.
		/// </summary>
		public int Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Tank_ConstructionUpdate");

			
			db.AddInParameter(dbCommand, "PK_LU_Tank_Construction", DbType.Decimal, this._PK_LU_Tank_Construction);
			
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
		/// Deletes a record from the LU_Tank_Construction table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_LU_Tank_Construction)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Tank_ConstructionDeleteByPK");

			db.AddInParameter(dbCommand, "PK_LU_Tank_Construction", DbType.Decimal, pK_LU_Tank_Construction);

			db.ExecuteNonQuery(dbCommand);
		}
	}
}
