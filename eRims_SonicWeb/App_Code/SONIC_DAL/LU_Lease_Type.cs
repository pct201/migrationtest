using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
    /// <summary>
    /// Data access class for LU_Lease_Type table.
    /// </summary>
    public sealed class LU_Lease_Type
    {

        #region Private variables used to hold the property values

        private decimal? _PK_LU_Lease_Type;
        private string _Fld_Desc;
        private string _Active;
        #endregion

        #region Public Property

        /// <summary>
        /// Gets or sets the PK_LU_Lease_Type value.
        /// </summary>
        public decimal? PK_LU_Lease_Type
        {
            get { return _PK_LU_Lease_Type; }
            set { _PK_LU_Lease_Type = value; }
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
        /// Initializes a new instance of the LU_Lease_Type class with default value.
        /// </summary>
        public LU_Lease_Type()
        {

            this._PK_LU_Lease_Type = null;
            this._Fld_Desc = null;
            this._Active = null;

        }

        #endregion

        #region Primary Constructors

        /// <summary>
        /// Initializes a new instance of the LU_Lease_Type class based on Primary Key.
        /// </summary>
        public LU_Lease_Type(decimal pK_LU_Lease_Type)
        {
            DataTable dtLU_Lease_Type = SelectByPK(pK_LU_Lease_Type).Tables[0];

            if (dtLU_Lease_Type.Rows.Count == 1)
            {
                DataRow drLU_Lease_Type = dtLU_Lease_Type.Rows[0];
                if (drLU_Lease_Type["PK_LU_Lease_Type"] == DBNull.Value)
                    this._PK_LU_Lease_Type = null;
                else
                    this._PK_LU_Lease_Type = (decimal?)drLU_Lease_Type["PK_LU_Lease_Type"];

                if (drLU_Lease_Type["Fld_Desc"] == DBNull.Value)
                    this._Fld_Desc = null;
                else
                    this._Fld_Desc = (string)drLU_Lease_Type["Fld_Desc"];
                if (drLU_Lease_Type["Active"] == DBNull.Value)
                    this._Active = null;
                else
                    this._Active = (string)drLU_Lease_Type["Active"];
            }
            else
            {
                this._PK_LU_Lease_Type = null;
                this._Fld_Desc = null;
                this._Active = null;
            }

        }

        #endregion

        /// <summary>
        /// Inserts a record into the LU_Lease_Type table.
        /// </summary>
        /// <returns></returns>
        public decimal Insert()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_Lease_TypeInsert");


            if (string.IsNullOrEmpty(this._Fld_Desc))
                db.AddInParameter(dbCommand, "Fld_Desc", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Fld_Desc", DbType.String, this._Fld_Desc);


            if (string.IsNullOrEmpty(this._Active))
                db.AddInParameter(dbCommand, "Active", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Active", DbType.String, this._Active);

            // Execute the query and return the new identity value
            return (Convert.ToDecimal(db.ExecuteScalar(dbCommand)));
        }

        /// <summary>
        /// Selects a single record from the LU_Lease_Type table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        private static DataSet SelectByPK(decimal pK_LU_Lease_Type)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_Lease_TypeSelectByPK");

            db.AddInParameter(dbCommand, "PK_LU_Lease_Type", DbType.Decimal, pK_LU_Lease_Type);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the LU_Lease_Type table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_Lease_TypeSelectAll");

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Updates a record in the LU_Lease_Type table.
        /// </summary>
        public decimal Update()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_Lease_TypeUpdate");


            db.AddInParameter(dbCommand, "PK_LU_Lease_Type", DbType.Decimal, this._PK_LU_Lease_Type);

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
        /// Deletes a record from the LU_Lease_Type table by a composite primary key.
        /// </summary>
        public static void DeleteByPK(decimal pK_LU_Lease_Type)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_Lease_TypeDeleteByPK");

            db.AddInParameter(dbCommand, "PK_LU_Lease_Type", DbType.Decimal, pK_LU_Lease_Type);

            db.ExecuteNonQuery(dbCommand);
        }
    }
}
