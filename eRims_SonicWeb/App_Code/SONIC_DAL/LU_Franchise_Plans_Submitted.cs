using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
    /// <summary>
    /// Data access class for LU_Franchise_Plans_Submitted table.
    /// </summary>
    public sealed class LU_Franchise_Plans_Submitted
    {

        #region Private variables used to hold the property values

        private decimal? _PK_LU_Franchise_Plans_Submitted;
        private string _Fld_Desc;
        private string _Active;

        #endregion

        #region Public Property

        /// <summary>
        /// Gets or sets the PK_LU_Franchise_Plans_Submitted value.
        /// </summary>
        public decimal? PK_LU_Franchise_Plans_Submitted
        {
            get { return _PK_LU_Franchise_Plans_Submitted; }
            set { _PK_LU_Franchise_Plans_Submitted = value; }
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
        /// Initializes a new instance of the LU_Franchise_Plans_Submitted class with default value.
        /// </summary>
        public LU_Franchise_Plans_Submitted()
        {

            this._PK_LU_Franchise_Plans_Submitted = null;
            this._Fld_Desc = null;
            this._Active = null;

        }

        #endregion

        #region Primary Constructors

        /// <summary>
        /// Initializes a new instance of the LU_Franchise_Plans_Submitted class based on Primary Key.
        /// </summary>
        public LU_Franchise_Plans_Submitted(decimal pK_LU_Franchise_Plans_Submitted)
        {
            DataTable dtLU_Franchise_Plans_Submitted = SelectByPK(pK_LU_Franchise_Plans_Submitted).Tables[0];

            if (dtLU_Franchise_Plans_Submitted.Rows.Count == 1)
            {
                DataRow drLU_Franchise_Plans_Submitted = dtLU_Franchise_Plans_Submitted.Rows[0];
                if (drLU_Franchise_Plans_Submitted["PK_LU_Franchise_Plans_Submitted"] == DBNull.Value)
                    this._PK_LU_Franchise_Plans_Submitted = null;
                else
                    this._PK_LU_Franchise_Plans_Submitted = (decimal?)drLU_Franchise_Plans_Submitted["PK_LU_Franchise_Plans_Submitted"];

                if (drLU_Franchise_Plans_Submitted["Fld_Desc"] == DBNull.Value)
                    this._Fld_Desc = null;
                else
                    this._Fld_Desc = (string)drLU_Franchise_Plans_Submitted["Fld_Desc"];

                if (drLU_Franchise_Plans_Submitted["Active"] == DBNull.Value)
                    this._Active = null;
                else
                    this._Active = (string)drLU_Franchise_Plans_Submitted["Active"];

            }
            else
            {
                this._PK_LU_Franchise_Plans_Submitted = null;
                this._Fld_Desc = null;
                this._Active = null;
            }

        }

        #endregion

        /// <summary>
        /// Inserts a record into the LU_Franchise_Plans_Submitted table.
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_Franchise_Plans_SubmittedInsert");


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
        /// Selects a single record from the LU_Franchise_Plans_Submitted table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        private static DataSet SelectByPK(decimal pK_LU_Franchise_Plans_Submitted)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_Franchise_Plans_SubmittedSelectByPK");

            db.AddInParameter(dbCommand, "PK_LU_Franchise_Plans_Submitted", DbType.Decimal, pK_LU_Franchise_Plans_Submitted);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the LU_Franchise_Plans_Submitted table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_Franchise_Plans_SubmittedSelectAll");

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Updates a record in the LU_Franchise_Plans_Submitted table.
        /// </summary>
        public decimal Update()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_Franchise_Plans_SubmittedUpdate");


            db.AddInParameter(dbCommand, "PK_LU_Franchise_Plans_Submitted", DbType.Decimal, this._PK_LU_Franchise_Plans_Submitted);

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
        /// Deletes a record from the LU_Franchise_Plans_Submitted table by a composite primary key.
        /// </summary>
        public static void DeleteByPK(decimal pK_LU_Franchise_Plans_Submitted)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_Franchise_Plans_SubmittedDeleteByPK");

            db.AddInParameter(dbCommand, "PK_LU_Franchise_Plans_Submitted", DbType.Decimal, pK_LU_Franchise_Plans_Submitted);

            db.ExecuteNonQuery(dbCommand);
        }
    }
}
