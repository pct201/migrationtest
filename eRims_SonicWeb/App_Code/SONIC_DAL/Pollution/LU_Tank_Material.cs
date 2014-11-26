using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for LU_Tank_Material table.
	/// </summary>
	public sealed class LU_Tank_Material
	{

		#region Private variables used to hold the property values

		private decimal? _PK_LU_Tank_Material;
		private string _Fld_Desc;
		private string _Active;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_LU_Tank_Material value.
		/// </summary>
		public decimal? PK_LU_Tank_Material
		{
			get { return _PK_LU_Tank_Material; }
			set { _PK_LU_Tank_Material = value; }
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
		/// Initializes a new instance of the clsLU_Tank_Material class with default value.
		/// </summary>
		public LU_Tank_Material() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the clsLU_Tank_Material class based on Primary Key.
		/// </summary>
		public LU_Tank_Material(decimal pK_LU_Tank_Material) 
		{
			DataTable dtLU_Tank_Material = SelectByPK(pK_LU_Tank_Material).Tables[0];

			if (dtLU_Tank_Material.Rows.Count == 1)
			{
				 SetValue(dtLU_Tank_Material.Rows[0]);

			}

		}


		/// <summary>
		/// Initializes a new instance of the clsLU_Tank_Material class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drLU_Tank_Material) 
		{
				if (drLU_Tank_Material["PK_LU_Tank_Material"] == DBNull.Value)
					this._PK_LU_Tank_Material = null;
				else
					this._PK_LU_Tank_Material = (decimal?)drLU_Tank_Material["PK_LU_Tank_Material"];

				if (drLU_Tank_Material["Fld_Desc"] == DBNull.Value)
					this._Fld_Desc = null;
				else
					this._Fld_Desc = (string)drLU_Tank_Material["Fld_Desc"];

				if (drLU_Tank_Material["Active"] == DBNull.Value)
					this._Active = null;
				else
					this._Active = (string)drLU_Tank_Material["Active"];


		}

		#endregion

		/// <summary>
		/// Inserts a record into the LU_Tank_Material table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Tank_MaterialInsert");

			
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
		/// Selects a single record from the LU_Tank_Material table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		private DataSet SelectByPK(decimal pK_LU_Tank_Material)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Tank_MaterialSelectByPK");

			db.AddInParameter(dbCommand, "PK_LU_Tank_Material", DbType.Decimal, pK_LU_Tank_Material);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the LU_Tank_Material table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Tank_MaterialSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the LU_Tank_Material table.
		/// </summary>
		public int Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Tank_MaterialUpdate");

			
			db.AddInParameter(dbCommand, "PK_LU_Tank_Material", DbType.Decimal, this._PK_LU_Tank_Material);
			
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
		/// Deletes a record from the LU_Tank_Material table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_LU_Tank_Material)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Tank_MaterialDeleteByPK");

			db.AddInParameter(dbCommand, "PK_LU_Tank_Material", DbType.Decimal, pK_LU_Tank_Material);

			db.ExecuteNonQuery(dbCommand);
		}
	}
}
