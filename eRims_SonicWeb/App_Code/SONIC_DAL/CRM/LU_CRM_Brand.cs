using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;


/// <summary>
/// Summary description for LU_CRM_Brand
/// </summary>
/// 
namespace ERIMS.DAL
{

    public sealed class LU_CRM_Brand
    {

        #region Private variables used to hold the property values

        private decimal? _PK_LU_CRM_Brand;
        private string _Fld_Desc;
        private string _Active;

        #endregion

        #region Public Property

        /// <summary>
        /// Gets or sets the PK_LU_CRM_Brand value.
        /// </summary>
        public decimal? PK_LU_CRM_Brand
        {
            get { return _PK_LU_CRM_Brand; }
            set { _PK_LU_CRM_Brand = value; }
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
        /// Initializes a new instance of the LU_CRM_Brand class with default value.
        /// </summary>
        public LU_CRM_Brand()
        {

            this._PK_LU_CRM_Brand = null;
            this._Fld_Desc = null;
            this._Active = null;

        }

        #endregion

        #region Primary Constructors

        /// <summary>
        /// Initializes a new instance of the LU_CRM_Brand class based on Primary Key.
        /// </summary>
        public LU_CRM_Brand(decimal pK_LU_CRM_Brand)
        {
            DataTable dtLU_CRM_Brand = SelectByPK(pK_LU_CRM_Brand).Tables[0];

            if (dtLU_CRM_Brand.Rows.Count == 1)
            {
                DataRow drLU_CRM_Brand = dtLU_CRM_Brand.Rows[0];
                if (drLU_CRM_Brand["PK_LU_CRM_Brand"] == DBNull.Value)
                    this._PK_LU_CRM_Brand = null;
                else
                    this._PK_LU_CRM_Brand = (decimal?)drLU_CRM_Brand["PK_LU_CRM_Brand"];

                if (drLU_CRM_Brand["Fld_Desc"] == DBNull.Value)
                    this._Fld_Desc = null;
                else
                    this._Fld_Desc = (string)drLU_CRM_Brand["Fld_Desc"];

                if (drLU_CRM_Brand["Active"] == DBNull.Value)
                    this._Active = null;
                else
                    this._Active = (string)drLU_CRM_Brand["Active"];

            }
            else
            {
                this._PK_LU_CRM_Brand = null;
                this._Fld_Desc = null;
                this._Active = null;
            }

        }

        #endregion

        /// <summary>
        /// Inserts a record into the LU_CRM_Brand table.
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_CRM_BrandInsert");


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
        /// Selects a single record from the LU_CRM_Brand table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        private static DataSet SelectByPK(decimal pK_LU_CRM_Brand)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_CRM_BrandSelectByPK");

            db.AddInParameter(dbCommand, "PK_LU_CRM_Brand", DbType.Decimal, pK_LU_CRM_Brand);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the LU_CRM_Brand table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_CRM_BrandSelectAll");

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Updates a record in the LU_CRM_Brand table.
        /// </summary>
        public decimal Update()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_CRM_BrandUpdate");


            db.AddInParameter(dbCommand, "PK_LU_CRM_Brand", DbType.Decimal, this._PK_LU_CRM_Brand);

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
        /// Deletes a record from the LU_CRM_Brand table by a composite primary key.
        /// </summary>
        public static void DeleteByPK(decimal pK_LU_CRM_Brand)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_CRM_BrandDeleteByPK");

            db.AddInParameter(dbCommand, "PK_LU_CRM_Brand", DbType.Decimal, pK_LU_CRM_Brand);

            db.ExecuteNonQuery(dbCommand);
        }
    }
}