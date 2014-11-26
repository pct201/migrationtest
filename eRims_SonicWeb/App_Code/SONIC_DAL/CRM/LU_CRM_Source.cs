using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

/// <summary>
/// Summary description for LU_CRM_Source
/// </summary>
/// 
namespace ERIMS.DAL
{
   
    /// <summary>
    /// Data access class for LU_Franchise_Additional_Land table.
    /// </summary>
    public sealed class LU_CRM_Source
    {

        #region Private variables used to hold the property values

        private decimal? _PK_LU_CRM_Source;
        private string _Fld_Desc;
        private string _Active;

        #endregion

        #region Public Property

        /// <summary>
        /// Gets or sets the PK_LU_Franchise_Additional_Land value.
        /// </summary>
        public decimal? PK_LU_CRM_Source
        {
            get { return _PK_LU_CRM_Source; }
            set { _PK_LU_CRM_Source = value; }
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
        /// Initializes a new instance of the LU_Franchise_Additional_Land class with default value.
        /// </summary>
        public LU_CRM_Source()
        {

            this._PK_LU_CRM_Source = null;
            this._Fld_Desc = null;
            this._Active = null;

        }

        #endregion

        #region Primary Constructors

        /// <summary>
        /// Initializes a new instance of the LU_Franchise_Additional_Land class based on Primary Key.
        /// </summary>
        public LU_CRM_Source(decimal pK_LU_CRM_Source)
        {
            DataTable dtLU_CRM_Source = SelectByPK(pK_LU_CRM_Source).Tables[0];

            if (dtLU_CRM_Source.Rows.Count == 1)
            {
                DataRow drLU_CRM_Source = dtLU_CRM_Source.Rows[0];
                if (drLU_CRM_Source["PK_LU_CRM_Source"] == DBNull.Value)
                    this._PK_LU_CRM_Source = null;
                else
                    this._PK_LU_CRM_Source = (decimal?)drLU_CRM_Source["PK_LU_CRM_Source"];

                if (drLU_CRM_Source["Fld_Desc"] == DBNull.Value)
                    this._Fld_Desc = null;
                else
                    this._Fld_Desc = (string)drLU_CRM_Source["Fld_Desc"];

                if (drLU_CRM_Source["Active"] == DBNull.Value)
                    this._Active = null;
                else
                    this._Active = (string)drLU_CRM_Source["Active"];

            }
            else
            {
                this._PK_LU_CRM_Source = null;
                this._Fld_Desc = null;
                this._Active = null;
            }

        }

        #endregion

        /// <summary>
        /// Inserts a record into the LU_Franchise_Additional_Land table.
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_CRM_SourceInsert");


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
        /// Selects a single record from the LU_Franchise_Additional_Land table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        private static DataSet SelectByPK(decimal pK_LU_CRM_Source)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_CRM_SourceSelectByPK");

            db.AddInParameter(dbCommand, "PK_LU_CRM_Source", DbType.Decimal, pK_LU_CRM_Source);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the LU_Franchise_Additional_Land table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_CRM_SourceSelectAll");

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Updates a record in the LU_Franchise_Additional_Land table.
        /// </summary>
        public decimal Update()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_CRM_SourceUpdate");


            db.AddInParameter(dbCommand, "PK_LU_CRM_Source", DbType.Decimal, this._PK_LU_CRM_Source);

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
        /// Deletes a record from the LU_Franchise_Additional_Land table by a composite primary key.
        /// </summary>
        public static void DeleteByPK(decimal pK_LU_CRM_Source)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_CRM_SourceDeleteByPK");

            db.AddInParameter(dbCommand, "PK_LU_CRM_Source", DbType.Decimal, pK_LU_CRM_Source);

            db.ExecuteNonQuery(dbCommand);
        }
    }
}