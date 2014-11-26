using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
    /// <summary>
    /// Data access class for LU_CRM_RVP table.
    /// </summary>
    public sealed class LU_CRM_RVP
    {

        #region Private variables used to hold the property values

        private decimal? _PK_LU_CRM_RVP;
        private string _Fld_Desc;
        private string _Active;

        #endregion

        #region Public Property

        /// <summary>
        /// Gets or sets the PK_LU_CRM_RVP value.
        /// </summary>
        public decimal? PK_LU_CRM_RVP
        {
            get { return _PK_LU_CRM_RVP; }
            set { _PK_LU_CRM_RVP = value; }
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
        /// Initializes a new instance of the LU_CRM_RVP class with default value.
        /// </summary>
        public LU_CRM_RVP()
        {

            this._PK_LU_CRM_RVP = null;
            this._Fld_Desc = null;
            this._Active = null;

        }

        #endregion

        #region Primary Constructors

        /// <summary>
        /// Initializes a new instance of the LU_CRM_RVP class based on Primary Key.
        /// </summary>
        public LU_CRM_RVP(decimal pK_LU_CRM_RVP)
        {
            DataTable dtLU_CRM_RVP = SelectByPK(pK_LU_CRM_RVP).Tables[0];

            if (dtLU_CRM_RVP.Rows.Count == 1)
            {
                DataRow drLU_CRM_RVP = dtLU_CRM_RVP.Rows[0];
                if (drLU_CRM_RVP["PK_LU_CRM_RVP"] == DBNull.Value)
                    this._PK_LU_CRM_RVP = null;
                else
                    this._PK_LU_CRM_RVP = (decimal?)drLU_CRM_RVP["PK_LU_CRM_RVP"];

                if (drLU_CRM_RVP["Fld_Desc"] == DBNull.Value)
                    this._Fld_Desc = null;
                else
                    this._Fld_Desc = (string)drLU_CRM_RVP["Fld_Desc"];

                if (drLU_CRM_RVP["Active"] == DBNull.Value)
                    this._Active = null;
                else
                    this._Active = (string)drLU_CRM_RVP["Active"];

            }
            else
            {
                this._PK_LU_CRM_RVP = null;
                this._Fld_Desc = null;
                this._Active = null;
            }

        }

        #endregion

        /// <summary>
        /// Inserts a record into the LU_CRM_RVP table.
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_CRM_RVPInsert");


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
        /// Selects a single record from the LU_CRM_RVP table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        private static DataSet SelectByPK(decimal pK_LU_CRM_RVP)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_CRM_RVPSelectByPK");

            db.AddInParameter(dbCommand, "PK_LU_CRM_RVP", DbType.Decimal, pK_LU_CRM_RVP);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the LU_CRM_RVP table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_CRM_RVPSelectAll");

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Updates a record in the LU_CRM_RVP table.
        /// </summary>
        public decimal Update()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_CRM_RVPUpdate");


            db.AddInParameter(dbCommand, "PK_LU_CRM_RVP", DbType.Decimal, this._PK_LU_CRM_RVP);

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
        /// Deletes a record from the LU_CRM_RVP table by a composite primary key.
        /// </summary>
        public static void DeleteByPK(decimal pK_LU_CRM_RVP)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_CRM_RVPDeleteByPK");

            db.AddInParameter(dbCommand, "PK_LU_CRM_RVP", DbType.Decimal, pK_LU_CRM_RVP);

            db.ExecuteNonQuery(dbCommand);
        }
    }
}
