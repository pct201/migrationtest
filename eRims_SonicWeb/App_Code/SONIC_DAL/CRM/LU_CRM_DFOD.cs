using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
namespace ERIMS.DAL
{
    public sealed class LU_CRM_DFOD
    {

        #region Private variables used to hold the property values

        private decimal? _PK_LU_CRM_DFOD;
        private string _Fld_Desc;
        private string _Active;

        #endregion

        #region Public Property

        /// <summary>
        /// Gets or sets the PK_LU_CRM_DFOD value.
        /// </summary>
        public decimal? PK_LU_CRM_DFOD
        {
            get { return _PK_LU_CRM_DFOD; }
            set { _PK_LU_CRM_DFOD = value; }
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
        /// Initializes a new instance of the LU_CRM_DFOD class with default value.
        /// </summary>
        public LU_CRM_DFOD()
        {

            this._PK_LU_CRM_DFOD = null;
            this._Fld_Desc = null;
            this._Active = null;

        }

        #endregion

        #region Primary Constructors

        /// <summary>
        /// Initializes a new instance of the LU_CRM_DFOD class based on Primary Key.
        /// </summary>
        public LU_CRM_DFOD(decimal pK_LU_CRM_DFOD)
        {
            DataTable dtLU_CRM_DFOD = SelectByPK(pK_LU_CRM_DFOD).Tables[0];

            if (dtLU_CRM_DFOD.Rows.Count == 1)
            {
                DataRow drLU_CRM_DFOD = dtLU_CRM_DFOD.Rows[0];
                if (drLU_CRM_DFOD["PK_LU_CRM_DFOD"] == DBNull.Value)
                    this._PK_LU_CRM_DFOD = null;
                else
                    this._PK_LU_CRM_DFOD = (decimal?)drLU_CRM_DFOD["PK_LU_CRM_DFOD"];

                if (drLU_CRM_DFOD["Fld_Desc"] == DBNull.Value)
                    this._Fld_Desc = null;
                else
                    this._Fld_Desc = (string)drLU_CRM_DFOD["Fld_Desc"];

                if (drLU_CRM_DFOD["Active"] == DBNull.Value)
                    this._Active = null;
                else
                    this._Active = (string)drLU_CRM_DFOD["Active"];

            }
            else
            {
                this._PK_LU_CRM_DFOD = null;
                this._Fld_Desc = null;
                this._Active = null;
            }

        }

        #endregion

        /// <summary>
        /// Inserts a record into the LU_CRM_DFOD table.
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_CRM_DFODInsert");


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
        /// Selects a single record from the LU_CRM_DFOD table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        private static DataSet SelectByPK(decimal pK_LU_CRM_DFOD)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_CRM_DFODSelectByPK");

            db.AddInParameter(dbCommand, "PK_LU_CRM_DFOD", DbType.Decimal, pK_LU_CRM_DFOD);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the LU_CRM_DFOD table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_CRM_DFODSelectAll");

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Updates a record in the LU_CRM_DFOD table.
        /// </summary>
        public decimal Update()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_CRM_DFODUpdate");


            db.AddInParameter(dbCommand, "PK_LU_CRM_DFOD", DbType.Decimal, this._PK_LU_CRM_DFOD);

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
        /// Deletes a record from the LU_CRM_DFOD table by a composite primary key.
        /// </summary>
        public static void DeleteByPK(decimal pK_LU_CRM_DFOD)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_CRM_DFODDeleteByPK");

            db.AddInParameter(dbCommand, "PK_LU_CRM_DFOD", DbType.Decimal, pK_LU_CRM_DFOD);

            db.ExecuteNonQuery(dbCommand);
        }
    }
}