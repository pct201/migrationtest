using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace  ERIMS.DAL
{
	/// <summary>
	/// Data access class for LU_Function_Area table.
	/// </summary>
	public sealed class clsLU_Function_Area
	{
		#region Private variables used to hold the property values

		private decimal? _PK_LU_Function_Area;
		private string _Description;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_LU_Function_Area value.
		/// </summary>
		public decimal? PK_LU_Function_Area
		{
			get { return _PK_LU_Function_Area; }
			set { _PK_LU_Function_Area = value; }
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
		/// Initializes a new instance of the clsLU_Function_Area class with default value.
		/// </summary>
		public clsLU_Function_Area() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the clsLU_Function_Area class based on Primary Key.
		/// </summary>
		public clsLU_Function_Area(decimal pK_LU_Function_Area) 
		{
			DataTable dtLU_Function_Area = SelectByPK(pK_LU_Function_Area).Tables[0];

			if (dtLU_Function_Area.Rows.Count == 1)
			{
				 SetValue(dtLU_Function_Area.Rows[0]);

			}

		}

		/// <summary>
		/// Initializes a new instance of the clsLU_Function_Area class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drLU_Function_Area) 
		{
				if (drLU_Function_Area["PK_LU_Function_Area"] == DBNull.Value)
					this._PK_LU_Function_Area = null;
				else
					this._PK_LU_Function_Area = (decimal?)drLU_Function_Area["PK_LU_Function_Area"];

				if (drLU_Function_Area["Description"] == DBNull.Value)
					this._Description = null;
				else
					this._Description = (string)drLU_Function_Area["Description"];


		}

		#endregion

		/// <summary>
		/// Inserts a record into the LU_Function_Area table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Function_AreaInsert");

			
			if (string.IsNullOrEmpty(this._Description))
				db.AddInParameter(dbCommand, "Description", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Description", DbType.String, this._Description);

            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
		}

		/// <summary>
		/// Selects a single record from the LU_Function_Area table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		private DataSet SelectByPK(decimal pK_LU_Function_Area)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Function_AreaSelectByPK");

			db.AddInParameter(dbCommand, "PK_LU_Function_Area", DbType.Decimal, pK_LU_Function_Area);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the LU_Function_Area table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Function_AreaSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the LU_Function_Area table.
		/// </summary>
        public decimal Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Function_AreaUpdate");

			db.AddInParameter(dbCommand, "PK_LU_Function_Area", DbType.Decimal, this._PK_LU_Function_Area);
			
			if (string.IsNullOrEmpty(this._Description))
				db.AddInParameter(dbCommand, "Description", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Description", DbType.String, this._Description);

            return (Convert.ToDecimal(db.ExecuteScalar(dbCommand)));
		}

		/// <summary>
		/// Deletes a record from the LU_Function_Area table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_LU_Function_Area)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Function_AreaDeleteByPK");

			db.AddInParameter(dbCommand, "PK_LU_Function_Area", DbType.Decimal, pK_LU_Function_Area);

			db.ExecuteNonQuery(dbCommand);
		}
	}
}
