using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
    /// <summary>
    /// Data access class for LU_Security_Deposit_Held table.
    /// </summary>
    public sealed class LU_Security_Deposit_Held
    {

        #region Private variables used to hold the property values

        private decimal? _PK_LU_Security_Deposit_Held;
        private string _Fld_Desc;
        private string _Active;
        #endregion

        #region Public Property

        /// <summary>
        /// Gets or sets the PK_LU_Security_Deposit_Held value.
        /// </summary>
        public decimal? PK_LU_Security_Deposit_Held
        {
            get { return _PK_LU_Security_Deposit_Held; }
            set { _PK_LU_Security_Deposit_Held = value; }
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
        /// Initializes a new instance of the LU_Security_Deposit_Held class with default value.
        /// </summary>
        public LU_Security_Deposit_Held()
        {

            this._PK_LU_Security_Deposit_Held = null;
            this._Fld_Desc = null;
            this._Active = null;
        }

        #endregion

        #region Primary Constructors

        /// <summary>
        /// Initializes a new instance of the LU_Security_Deposit_Held class based on Primary Key.
        /// </summary>
        public LU_Security_Deposit_Held(decimal pK_LU_Security_Deposit_Held)
        {
            DataTable dtLU_Security_Deposit_Held = SelectByPK(pK_LU_Security_Deposit_Held).Tables[0];

            if (dtLU_Security_Deposit_Held.Rows.Count == 1)
            {
                DataRow drLU_Security_Deposit_Held = dtLU_Security_Deposit_Held.Rows[0];
                if (drLU_Security_Deposit_Held["PK_LU_Security_Deposit_Held"] == DBNull.Value)
                    this._PK_LU_Security_Deposit_Held = null;
                else
                    this._PK_LU_Security_Deposit_Held = (decimal?)drLU_Security_Deposit_Held["PK_LU_Security_Deposit_Held"];

                if (drLU_Security_Deposit_Held["Fld_Desc"] == DBNull.Value)
                    this._Fld_Desc = null;
                else
                    this._Fld_Desc = (string)drLU_Security_Deposit_Held["Fld_Desc"];

                if (drLU_Security_Deposit_Held["Active"] == DBNull.Value)
                    this._Active = null;
                else
                    this._Active = (string)drLU_Security_Deposit_Held["Active"];

            }
            else
            {
                this._PK_LU_Security_Deposit_Held = null;
                this._Fld_Desc = null;
                this._Active = null;
            }

        }

        #endregion

        /// <summary>
        /// Inserts a record into the LU_Security_Deposit_Held table.
        /// </summary>
        /// <returns></returns>
        public decimal Insert()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_Security_Deposit_HeldInsert");


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
        /// Selects a single record from the LU_Security_Deposit_Held table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        private static DataSet SelectByPK(decimal pK_LU_Security_Deposit_Held)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_Security_Deposit_HeldSelectByPK");

            db.AddInParameter(dbCommand, "PK_LU_Security_Deposit_Held", DbType.Decimal, pK_LU_Security_Deposit_Held);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the LU_Security_Deposit_Held table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_Security_Deposit_HeldSelectAll");

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Updates a record in the LU_Security_Deposit_Held table.
        /// </summary>
        public decimal Update()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_Security_Deposit_HeldUpdate");

            db.AddInParameter(dbCommand, "PK_LU_Security_Deposit_Held", DbType.Decimal, this._PK_LU_Security_Deposit_Held);

            if (string.IsNullOrEmpty(this._Fld_Desc))
                db.AddInParameter(dbCommand, "Fld_Desc", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Fld_Desc", DbType.String, this._Fld_Desc);

            if (string.IsNullOrEmpty(this._Active))
                db.AddInParameter(dbCommand, "Active", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Active", DbType.String, this._Active);

            return Convert.ToDecimal(db.ExecuteScalar(dbCommand));

        }

        /// <summary>
        /// Deletes a record from the LU_Security_Deposit_Held table by a composite primary key.
        /// </summary>
        public static void DeleteByPK(decimal pK_LU_Security_Deposit_Held)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_Security_Deposit_HeldDeleteByPK");

            db.AddInParameter(dbCommand, "PK_LU_Security_Deposit_Held", DbType.Decimal, pK_LU_Security_Deposit_Held);

            db.ExecuteNonQuery(dbCommand);
        }
    }
}
