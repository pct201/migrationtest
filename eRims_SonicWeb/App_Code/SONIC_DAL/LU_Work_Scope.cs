using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
    /// <summary>
    /// Data access class for LU_Work_Scope table.
    /// </summary>
    public sealed class LU_Work_Scope
    {

        #region Private variables used to hold the property values

        private decimal? _PK_LU_Work_Scope;
        private string _Fld_Desc;
        private string _Active;
        #endregion

        #region Public Property

        /// <summary>
        /// Gets or sets the PK_LU_Work_Scope value.
        /// </summary>
        public decimal? PK_LU_Work_Scope
        {
            get { return _PK_LU_Work_Scope; }
            set { _PK_LU_Work_Scope = value; }
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
        /// Initializes a new instance of the LU_Work_Scope class with default value.
        /// </summary>
        public LU_Work_Scope()
        {

            this._PK_LU_Work_Scope = null;
            this._Fld_Desc = null;
            this._Active = null;
        }

        #endregion

        #region Primary Constructors

        /// <summary>
        /// Initializes a new instance of the LU_Work_Scope class based on Primary Key.
        /// </summary>
        public LU_Work_Scope(decimal pK_LU_Work_Scope)
        {
            DataTable dtLU_Work_Scope = SelectByPK(pK_LU_Work_Scope).Tables[0];

            if (dtLU_Work_Scope.Rows.Count == 1)
            {
                DataRow drLU_Work_Scope = dtLU_Work_Scope.Rows[0];
                if (drLU_Work_Scope["PK_LU_Work_Scope"] == DBNull.Value)
                    this._PK_LU_Work_Scope = null;
                else
                    this._PK_LU_Work_Scope = (decimal?)drLU_Work_Scope["PK_LU_Work_Scope"];

                if (drLU_Work_Scope["Fld_Desc"] == DBNull.Value)
                    this._Fld_Desc = null;
                else
                    this._Fld_Desc = (string)drLU_Work_Scope["Fld_Desc"];

                if (drLU_Work_Scope["Active"] == DBNull.Value)
                    this._Active = null;
                else
                    this._Active = (string)drLU_Work_Scope["Active"];
            }
            else
            {
                this._PK_LU_Work_Scope = null;
                this._Fld_Desc = null;
                this._Active = null;
            }

        }

        #endregion

        /// <summary>
        /// Inserts a record into the LU_Work_Scope table.
        /// </summary>
        /// <returns></returns>
        public decimal Insert()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_Work_ScopeInsert");


            if (string.IsNullOrEmpty(this._Fld_Desc))
                db.AddInParameter(dbCommand, "Fld_Desc", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Fld_Desc", DbType.String, this._Fld_Desc);


            if (string.IsNullOrEmpty(this._Active))
                db.AddInParameter(dbCommand, "Active", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Active", DbType.String, this._Active);
            // Execute the query and return the new identity value
            return Convert.ToDecimal(db.ExecuteScalar(dbCommand));
        }

        /// <summary>
        /// Selects a single record from the LU_Work_Scope table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        private static DataSet SelectByPK(decimal pK_LU_Work_Scope)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_Work_ScopeSelectByPK");

            db.AddInParameter(dbCommand, "PK_LU_Work_Scope", DbType.Decimal, pK_LU_Work_Scope);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the LU_Work_Scope table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_Work_ScopeSelectAll");

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Updates a record in the LU_Work_Scope table.
        /// </summary>
        public decimal Update()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_Work_ScopeUpdate");

            db.AddInParameter(dbCommand, "PK_LU_Work_Scope", DbType.Decimal, this._PK_LU_Work_Scope);
            
            if (string.IsNullOrEmpty(this._Active))
                db.AddInParameter(dbCommand, "Active", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Active", DbType.String, this._Active);

            if (string.IsNullOrEmpty(this._Fld_Desc))
                db.AddInParameter(dbCommand, "Fld_Desc", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Fld_Desc", DbType.String, this._Fld_Desc);

            return Convert.ToDecimal(db.ExecuteScalar(dbCommand));
        }

        /// <summary>
        /// Deletes a record from the LU_Work_Scope table by a composite primary key.
        /// </summary>
        public static void DeleteByPK(decimal pK_LU_Work_Scope)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_Work_ScopeDeleteByPK");

            db.AddInParameter(dbCommand, "PK_LU_Work_Scope", DbType.Decimal, pK_LU_Work_Scope);

            db.ExecuteNonQuery(dbCommand);
        }
    }
}
