using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for LU_Inspection_Area table.
	/// </summary>
	public sealed class clsLU_Inspection_Area
	{

		#region Private variables used to hold the property values

		private decimal? _PK_LU_Inspection_Area;
		private string _Fld_Desc;
		private string _Active;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_LU_Inspection_Area value.
		/// </summary>
		public decimal? PK_LU_Inspection_Area
		{
			get { return _PK_LU_Inspection_Area; }
			set { _PK_LU_Inspection_Area = value; }
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
		/// Initializes a new instance of the clsLU_Inspection_Area class with default value.
		/// </summary>
		public clsLU_Inspection_Area() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the clsLU_Inspection_Area class based on Primary Key.
		/// </summary>
		public clsLU_Inspection_Area(decimal pK_LU_Inspection_Area) 
		{
			DataTable dtLU_Inspection_Area = SelectByPK(pK_LU_Inspection_Area).Tables[0];

			if (dtLU_Inspection_Area.Rows.Count == 1)
			{
				 SetValue(dtLU_Inspection_Area.Rows[0]);

			}

		}


		/// <summary>
		/// Initializes a new instance of the clsLU_Inspection_Area class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drLU_Inspection_Area) 
		{
				if (drLU_Inspection_Area["PK_LU_Inspection_Area"] == DBNull.Value)
					this._PK_LU_Inspection_Area = null;
				else
					this._PK_LU_Inspection_Area = (decimal?)drLU_Inspection_Area["PK_LU_Inspection_Area"];

				if (drLU_Inspection_Area["Fld_Desc"] == DBNull.Value)
					this._Fld_Desc = null;
				else
					this._Fld_Desc = (string)drLU_Inspection_Area["Fld_Desc"];

				if (drLU_Inspection_Area["Active"] == DBNull.Value)
					this._Active = null;
				else
					this._Active = (string)drLU_Inspection_Area["Active"];


		}

		#endregion

		/// <summary>
		/// Inserts a record into the LU_Inspection_Area table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Inspection_AreaInsert");

			
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
		/// Selects a single record from the LU_Inspection_Area table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		private DataSet SelectByPK(decimal pK_LU_Inspection_Area)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Inspection_AreaSelectByPK");

			db.AddInParameter(dbCommand, "PK_LU_Inspection_Area", DbType.Decimal, pK_LU_Inspection_Area);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the LU_Inspection_Area table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Inspection_AreaSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the LU_Inspection_Area table.
		/// </summary>
        public decimal Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Inspection_AreaUpdate");

			
			db.AddInParameter(dbCommand, "PK_LU_Inspection_Area", DbType.Decimal, this._PK_LU_Inspection_Area);
			
			if (string.IsNullOrEmpty(this._Fld_Desc))
				db.AddInParameter(dbCommand, "Fld_Desc", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Fld_Desc", DbType.String, this._Fld_Desc);
			
			if (string.IsNullOrEmpty(this._Active))
				db.AddInParameter(dbCommand, "Active", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Active", DbType.String, this._Active);

			db.ExecuteNonQuery(dbCommand);
            return (Convert.ToDecimal(db.ExecuteScalar(dbCommand)));
		}

		/// <summary>
		/// Deletes a record from the LU_Inspection_Area table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_LU_Inspection_Area)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Inspection_AreaDeleteByPK");

			db.AddInParameter(dbCommand, "PK_LU_Inspection_Area", DbType.Decimal, pK_LU_Inspection_Area);

			db.ExecuteNonQuery(dbCommand);
		}
	}
}
