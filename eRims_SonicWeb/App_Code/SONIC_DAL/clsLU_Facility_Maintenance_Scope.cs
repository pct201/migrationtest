using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for LU_Facility_Maintenance_Scope table.
	/// </summary>
	public sealed class clsLU_Facility_Maintenance_Scope
	{

		#region Private variables used to hold the property values

		private decimal? _PK_LU_Facility_Maintenance_Scope;
		private string _Description;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_LU_Facility_Maintenance_Scope value.
		/// </summary>
		public decimal? PK_LU_Facility_Maintenance_Scope
		{
			get { return _PK_LU_Facility_Maintenance_Scope; }
			set { _PK_LU_Facility_Maintenance_Scope = value; }
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
		/// Initializes a new instance of the clsLU_Facility_Maintenance_Scope class with default value.
		/// </summary>
		public clsLU_Facility_Maintenance_Scope() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the clsLU_Facility_Maintenance_Scope class based on Primary Key.
		/// </summary>
		
        public clsLU_Facility_Maintenance_Scope(decimal pK_clsLU_Facility_Maintenance_Scope) 
		{
            DataTable dtLU_Facility_Maintenance_Scope = SelectByPK(pK_clsLU_Facility_Maintenance_Scope).Tables[0];

            if (dtLU_Facility_Maintenance_Scope.Rows.Count == 1)
			{
                SetValue(dtLU_Facility_Maintenance_Scope.Rows[0]);
			}
		}

		/// <summary>
		/// Initializes a new instance of the clsLU_Facility_Maintenance_Scope class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drLU_Facility_Maintenance_Scope) 
		{
				if (drLU_Facility_Maintenance_Scope["PK_LU_Facility_Maintenance_Scope"] == DBNull.Value)
					this._PK_LU_Facility_Maintenance_Scope = null;
				else
					this._PK_LU_Facility_Maintenance_Scope = (decimal?)drLU_Facility_Maintenance_Scope["PK_LU_Facility_Maintenance_Scope"];

				if (drLU_Facility_Maintenance_Scope["Description"] == DBNull.Value)
					this._Description = null;
				else
					this._Description = (string)drLU_Facility_Maintenance_Scope["Description"];


		}

		#endregion

		/// <summary>
		/// Inserts a record into the LU_Facility_Maintenance_Scope table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Facility_Maintenance_ScopeInsert");
			
			if (string.IsNullOrEmpty(this._Description))
				db.AddInParameter(dbCommand, "Description", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Description", DbType.String, this._Description);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

        /// <summary>
        /// Selects a single record from the LU_Facility_Maintenance_Scope table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        private DataSet SelectByPK(decimal pK_LU_Facility_Maintenance_Scope)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_Facility_Maintenance_ScopeSelectByPK");

            db.AddInParameter(dbCommand, "PK_LU_Facility_Maintenance_Scope", DbType.Decimal, pK_LU_Facility_Maintenance_Scope);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the LU_Facility_Maintenance_Scope table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_Facility_Maintenance_ScopeSelectAll");

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Updates a record in the LU_Facility_Maintenance_Scope table.
        /// </summary>
        public decimal Update()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_Facility_Maintenance_ScopeUpdate");


            db.AddInParameter(dbCommand, "PK_LU_Facility_Maintenance_Scope", DbType.Decimal, this._PK_LU_Facility_Maintenance_Scope);

            if (string.IsNullOrEmpty(this._Description))
                db.AddInParameter(dbCommand, "Description", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Description", DbType.String, this._Description);

            return (Convert.ToDecimal(db.ExecuteScalar(dbCommand)));
        }

        /// <summary>
        /// Deletes a record from the LU_Facility_Maintenance_Scope table by a composite primary key.
        /// </summary>
        public static void DeleteByPK(decimal pK_LU_Facility_Maintenance_Scope)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_Facility_Maintenance_ScopeDeleteByPK");

            db.AddInParameter(dbCommand, "PK_LU_Facility_Maintenance_Scope", DbType.Decimal, pK_LU_Facility_Maintenance_Scope);

            db.ExecuteNonQuery(dbCommand);
        }
	}
}
