using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
    /// <summary>
    /// Data access class for LU_CRM_Letter_NA_Reason table.
    /// </summary>
    public sealed class LU_CRM_Letter_NA_Reason
    {

        #region Private variables used to hold the property values

        private decimal? _PK_LU_CRM_Letter_NA_Reason;
        private string _Fld_Desc;
        private string _Active;

        #endregion

        #region Public Property

        /// <summary>
        /// Gets or sets the PK_LU_CRM_Letter_NA_Reason value.
        /// </summary>
        public decimal? PK_LU_CRM_Letter_NA_Reason
        {
            get { return _PK_LU_CRM_Letter_NA_Reason; }
            set { _PK_LU_CRM_Letter_NA_Reason = value; }
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
        /// Initializes a new instance of the LU_CRM_Letter_NA_Reason class with default value.
        /// </summary>
        public LU_CRM_Letter_NA_Reason()
        {

            this._PK_LU_CRM_Letter_NA_Reason = null;
            this._Fld_Desc = null;
            this._Active = null;

        }

        #endregion

        #region Primary Constructors

        /// <summary>
        /// Initializes a new instance of the LU_CRM_Letter_NA_Reason class based on Primary Key.
        /// </summary>
        public LU_CRM_Letter_NA_Reason(decimal pK_LU_CRM_Letter_NA_Reason)
        {
            DataTable dtLU_CRM_Letter_NA_Reason = SelectByPK(pK_LU_CRM_Letter_NA_Reason).Tables[0];

            if (dtLU_CRM_Letter_NA_Reason.Rows.Count == 1)
            {
                DataRow drLU_CRM_Letter_NA_Reason = dtLU_CRM_Letter_NA_Reason.Rows[0];
                if (drLU_CRM_Letter_NA_Reason["PK_LU_CRM_Letter_NA_Reason"] == DBNull.Value)
                    this._PK_LU_CRM_Letter_NA_Reason = null;
                else
                    this._PK_LU_CRM_Letter_NA_Reason = (decimal?)drLU_CRM_Letter_NA_Reason["PK_LU_CRM_Letter_NA_Reason"];

                if (drLU_CRM_Letter_NA_Reason["Fld_Desc"] == DBNull.Value)
                    this._Fld_Desc = null;
                else
                    this._Fld_Desc = (string)drLU_CRM_Letter_NA_Reason["Fld_Desc"];

                if (drLU_CRM_Letter_NA_Reason["Active"] == DBNull.Value)
                    this._Active = null;
                else
                    this._Active = (string)drLU_CRM_Letter_NA_Reason["Active"];

            }
            else
            {
                this._PK_LU_CRM_Letter_NA_Reason = null;
                this._Fld_Desc = null;
                this._Active = null;
            }

        }

        #endregion

        /// <summary>
        /// Inserts a record into the LU_CRM_Letter_NA_Reason table.
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_CRM_Letter_NA_ReasonInsert");


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
        /// Selects a single record from the LU_CRM_Letter_NA_Reason table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        private static DataSet SelectByPK(decimal pK_LU_CRM_Letter_NA_Reason)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_CRM_Letter_NA_ReasonSelectByPK");

            db.AddInParameter(dbCommand, "PK_LU_CRM_Letter_NA_Reason", DbType.Decimal, pK_LU_CRM_Letter_NA_Reason);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the LU_CRM_Letter_NA_Reason table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_CRM_Letter_NA_ReasonSelectAll");

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Updates a record in the LU_CRM_Letter_NA_Reason table.
        /// </summary>
        public decimal Update()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_CRM_Letter_NA_ReasonUpdate");


            db.AddInParameter(dbCommand, "PK_LU_CRM_Letter_NA_Reason", DbType.Decimal, this._PK_LU_CRM_Letter_NA_Reason);

            if (string.IsNullOrEmpty(this._Fld_Desc))
                db.AddInParameter(dbCommand, "Fld_Desc", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Fld_Desc", DbType.String, this._Fld_Desc);

            if (string.IsNullOrEmpty(this._Active))
                db.AddInParameter(dbCommand, "Active", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Active", DbType.String, this._Active);

            return (Convert.ToDecimal(db.ExecuteScalar(dbCommand)));
        }

        /// <summary>
        /// Deletes a record from the LU_CRM_Letter_NA_Reason table by a composite primary key.
        /// </summary>
        public static void DeleteByPK(decimal pK_LU_CRM_Letter_NA_Reason)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_CRM_Letter_NA_ReasonDeleteByPK");

            db.AddInParameter(dbCommand, "PK_LU_CRM_Letter_NA_Reason", DbType.Decimal, pK_LU_CRM_Letter_NA_Reason);

            db.ExecuteNonQuery(dbCommand);
        }
    }
}
