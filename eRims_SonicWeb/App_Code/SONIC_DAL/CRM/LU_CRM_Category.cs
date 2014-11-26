using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

/// <summary>
/// Summary description for LU_CRM_Category
/// </summary>
/// 
namespace ERIMS.DAL
{
    /// <summary>
    /// Data access class for LU_CRM_Category table.
    /// </summary>
    public sealed class LU_CRM_Category
    {

        #region Private variables used to hold the property values

        private decimal? _PK_LU_CRM_Category;
        private string _Fld_Desc;
        private string _Email;
        private string _Active;

        #endregion

        #region Public Property

        /// <summary>
        /// Gets or sets the PK_LU_CRM_Category value.
        /// </summary>
        public decimal? PK_LU_CRM_Category
        {
            get { return _PK_LU_CRM_Category; }
            set { _PK_LU_CRM_Category = value; }
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
        /// Gets or sets the Email value.
        /// </summary>
        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
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
        /// Initializes a new instance of the LU_CRM_Category class with default value.
        /// </summary>
        public LU_CRM_Category()
        {

            this._PK_LU_CRM_Category = null;
            this._Fld_Desc = null;
            this._Email = null;
            this._Active = null;

        }

        #endregion

        #region Primary Constructors

        /// <summary>
        /// Initializes a new instance of the LU_CRM_Category class based on Primary Key.
        /// </summary>
        public LU_CRM_Category(decimal pK_LU_CRM_Category)
        {
            DataTable dtLU_CRM_Category = SelectByPK(pK_LU_CRM_Category).Tables[0];

            if (dtLU_CRM_Category.Rows.Count == 1)
            {
                DataRow drLU_CRM_Category = dtLU_CRM_Category.Rows[0];
                if (drLU_CRM_Category["PK_LU_CRM_Category"] == DBNull.Value)
                    this._PK_LU_CRM_Category = null;
                else
                    this._PK_LU_CRM_Category = (decimal?)drLU_CRM_Category["PK_LU_CRM_Category"];

                if (drLU_CRM_Category["Fld_Desc"] == DBNull.Value)
                    this._Fld_Desc = null;
                else
                    this._Fld_Desc = (string)drLU_CRM_Category["Fld_Desc"];

                if (drLU_CRM_Category["Email"] == DBNull.Value)
                    this._Email = null;
                else
                    this._Email = (string)drLU_CRM_Category["Email"];

                if (drLU_CRM_Category["Active"] == DBNull.Value)
                    this._Active = null;
                else
                    this._Active = (string)drLU_CRM_Category["Active"];

            }
            else
            {
                this._PK_LU_CRM_Category = null;
                this._Fld_Desc = null;
                this._Email = null;
                this._Active = null;
            }

        }

        #endregion

        /// <summary>
        /// Inserts a record into the LU_CRM_Category table.
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_CRM_CategoryInsert");


            if (string.IsNullOrEmpty(this._Fld_Desc))
                db.AddInParameter(dbCommand, "Fld_Desc", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Fld_Desc", DbType.String, this._Fld_Desc);

            if (string.IsNullOrEmpty(this._Email))
                db.AddInParameter(dbCommand, "Email", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Email", DbType.String, this._Email);

            if (string.IsNullOrEmpty(this._Active))
                db.AddInParameter(dbCommand, "Active", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Active", DbType.String, this._Active);

            // Execute the query and return the new identity value
            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
        }

        /// <summary>
        /// Selects a single record from the LU_CRM_Category table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        private static DataSet SelectByPK(decimal pK_LU_CRM_Category)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_CRM_CategorySelectByPK");

            db.AddInParameter(dbCommand, "PK_LU_CRM_Category", DbType.Decimal, pK_LU_CRM_Category);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the LU_CRM_Category table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_CRM_CategorySelectAll");

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Updates a record in the LU_CRM_Category table.
        /// </summary>
        public decimal Update()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_CRM_CategoryUpdate");


            db.AddInParameter(dbCommand, "PK_LU_CRM_Category", DbType.Decimal, this._PK_LU_CRM_Category);

            if (string.IsNullOrEmpty(this._Fld_Desc))
                db.AddInParameter(dbCommand, "Fld_Desc", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Fld_Desc", DbType.String, this._Fld_Desc);

            if (string.IsNullOrEmpty(this._Email))
                db.AddInParameter(dbCommand, "Email", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Email", DbType.String, this._Email);

            if (string.IsNullOrEmpty(this._Active))
                db.AddInParameter(dbCommand, "Active", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Active", DbType.String, this._Active);

            return (Convert.ToDecimal(db.ExecuteScalar(dbCommand)));
        }

        /// <summary>
        /// Deletes a record from the LU_CRM_Category table by a composite primary key.
        /// </summary>
        public static void DeleteByPK(decimal pK_LU_CRM_Category)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_CRM_CategoryDeleteByPK");

            db.AddInParameter(dbCommand, "PK_LU_CRM_Category", DbType.Decimal, pK_LU_CRM_Category);

            db.ExecuteNonQuery(dbCommand);
        }
    }
}