using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
    /// <summary>
    /// Data access class for LU_Status table.
    /// </summary>
    public sealed class LU_Status
    {

        #region Private variables used to hold the property values

        private decimal? _PK_LU_Status;
        private string _Fld_Desc;
        private string _Active;

        #endregion

        #region Public Property

        /// <summary>
        /// Gets or sets the PK_LU_Status value.
        /// </summary>
        public decimal? PK_LU_Status
        {
            get { return _PK_LU_Status; }
            set { _PK_LU_Status = value; }
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
        /// Initializes a new instance of the LU_Status class with default value.
        /// </summary>
        public LU_Status()
        {

            this._PK_LU_Status = null;
            this._Fld_Desc = null;
            this._Active = null;
        }

        #endregion

        #region Primary Constructors

        /// <summary>
        /// Initializes a new instance of the LU_Status class based on Primary Key.
        /// </summary>
        public LU_Status(decimal pK_LU_Status)
        {
            DataTable dtLU_Status = SelectByPK(pK_LU_Status).Tables[0];

            if (dtLU_Status.Rows.Count == 1)
            {
                DataRow drLU_Status = dtLU_Status.Rows[0];
                if (drLU_Status["PK_LU_Status"] == DBNull.Value)
                    this._PK_LU_Status = null;
                else
                    this._PK_LU_Status = (decimal?)drLU_Status["PK_LU_Status"];

                if (drLU_Status["Fld_Desc"] == DBNull.Value)
                    this._Fld_Desc = null;
                else
                    this._Fld_Desc = (string)drLU_Status["Fld_Desc"];

                if (drLU_Status["Active"] == DBNull.Value)
                    this._Active = null;
                else
                    this._Active = (string)drLU_Status["Active"];
            }
            else
            {
                this._PK_LU_Status = null;
                this._Fld_Desc = null;
                this._Active = null;
            }

        }

        #endregion

        /// <summary>
        /// Inserts a record into the LU_Status table.
        /// </summary>
        /// <returns></returns>
        public decimal Insert()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_StatusInsert");


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
        /// Selects a single record from the LU_Status table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        private static DataSet SelectByPK(decimal pK_LU_Status)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_StatusSelectByPK");

            db.AddInParameter(dbCommand, "PK_LU_Status", DbType.Decimal, pK_LU_Status);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the LU_Status table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_StatusSelectAll");

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Updates a record in the LU_Status table.
        /// </summary>
        public decimal Update()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_StatusUpdate");


            db.AddInParameter(dbCommand, "PK_LU_Status", DbType.Decimal, this._PK_LU_Status);

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
        /// Deletes a record from the LU_Status table by a composite primary key.
        /// </summary>
        public static void DeleteByPK(decimal pK_LU_Status)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_StatusDeleteByPK");

            db.AddInParameter(dbCommand, "PK_LU_Status", DbType.Decimal, pK_LU_Status);

            db.ExecuteNonQuery(dbCommand);
        }
    }
}
