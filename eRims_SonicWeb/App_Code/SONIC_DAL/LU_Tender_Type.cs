using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
    /// <summary>
    /// Data access class for LU_Tender_Type table.
    /// </summary>
    public sealed class LU_Tender_Type
    {

        #region Private variables used to hold the property values

        private decimal? _PK_LU_Tender_Type;
        private string _Fld_Desc;

        #endregion

        #region Public Property

        /// <summary>
        /// Gets or sets the PK_LU_Tender_Type value.
        /// </summary>
        public decimal? PK_LU_Tender_Type
        {
            get { return _PK_LU_Tender_Type; }
            set { _PK_LU_Tender_Type = value; }
        }

        /// <summary>
        /// Gets or sets the Fld_Desc value.
        /// </summary>
        public string Fld_Desc
        {
            get { return _Fld_Desc; }
            set { _Fld_Desc = value; }
        }


        #endregion

        #region Default Constructors

        /// <summary>
        /// Initializes a new instance of the LU_Tender_Type class with default value.
        /// </summary>
        public LU_Tender_Type()
        {

            this._PK_LU_Tender_Type = null;
            this._Fld_Desc = null;

        }

        #endregion

        #region Primary Constructors

        /// <summary>
        /// Initializes a new instance of the LU_Tender_Type class based on Primary Key.
        /// </summary>
        public LU_Tender_Type(decimal pK_LU_Tender_Type)
        {
            DataTable dtLU_Tender_Type = SelectByPK(pK_LU_Tender_Type).Tables[0];

            if (dtLU_Tender_Type.Rows.Count == 1)
            {
                DataRow drLU_Tender_Type = dtLU_Tender_Type.Rows[0];
                if (drLU_Tender_Type["PK_LU_Tender_Type"] == DBNull.Value)
                    this._PK_LU_Tender_Type = null;
                else
                    this._PK_LU_Tender_Type = (decimal?)drLU_Tender_Type["PK_LU_Tender_Type"];

                if (drLU_Tender_Type["Fld_Desc"] == DBNull.Value)
                    this._Fld_Desc = null;
                else
                    this._Fld_Desc = (string)drLU_Tender_Type["Fld_Desc"];

            }
            else
            {
                this._PK_LU_Tender_Type = null;
                this._Fld_Desc = null;
            }

        }

        #endregion

        /// <summary>
        /// Inserts a record into the LU_Tender_Type table.
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_Tender_TypeInsert");


            if (string.IsNullOrEmpty(this._Fld_Desc))
                db.AddInParameter(dbCommand, "Fld_Desc", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Fld_Desc", DbType.String, this._Fld_Desc);

            // Execute the query and return the new identity value
            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
        }

        /// <summary>
        /// Selects a single record from the LU_Tender_Type table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        private static DataSet SelectByPK(decimal pK_LU_Tender_Type)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_Tender_TypeSelectByPK");

            db.AddInParameter(dbCommand, "PK_LU_Tender_Type", DbType.Decimal, pK_LU_Tender_Type);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the LU_Tender_Type table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_Tender_TypeSelectAll");

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Updates a record in the LU_Tender_Type table.
        /// </summary>
        public void Update()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_Tender_TypeUpdate");


            db.AddInParameter(dbCommand, "PK_LU_Tender_Type", DbType.Decimal, this._PK_LU_Tender_Type);

            if (string.IsNullOrEmpty(this._Fld_Desc))
                db.AddInParameter(dbCommand, "Fld_Desc", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Fld_Desc", DbType.String, this._Fld_Desc);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Deletes a record from the LU_Tender_Type table by a composite primary key.
        /// </summary>
        public static void DeleteByPK(decimal pK_LU_Tender_Type)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_Tender_TypeDeleteByPK");

            db.AddInParameter(dbCommand, "PK_LU_Tender_Type", DbType.Decimal, pK_LU_Tender_Type);

            db.ExecuteNonQuery(dbCommand);
        }
    }
}
