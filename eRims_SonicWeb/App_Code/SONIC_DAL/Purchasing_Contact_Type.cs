using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
    /// <summary>
    /// Data access class for Purchasing_Contact_Type table.
    /// </summary>
    public sealed class Purchasing_Contact_Type
    {

        #region Private variables used to hold the property values

        private decimal? _PK_ID;
        private string _FLD_desc;
        private string _FLD_code;

        #endregion

        #region Public Property

        /// <summary>
        /// Gets or sets the PK_ID value.
        /// </summary>
        public decimal? PK_ID
        {
            get { return _PK_ID; }
            set { _PK_ID = value; }
        }

        /// <summary>
        /// Gets or sets the FLD_desc value.
        /// </summary>
        public string FLD_desc
        {
            get { return _FLD_desc; }
            set { _FLD_desc = value; }
        }

        /// <summary>
        /// Gets or sets the FLD_code value.
        /// </summary>
        public string FLD_code
        {
            get { return _FLD_code; }
            set { _FLD_code = value; }
        }


        #endregion

        #region Default Constructors

        /// <summary>
        /// Initializes a new instance of the Purchasing_Contact_Type class with default value.
        /// </summary>
        public Purchasing_Contact_Type()
        {

            this._PK_ID = null;
            this._FLD_desc = null;
            this._FLD_code = null;

        }

        #endregion

        #region Primary Constructors

        /// <summary>
        /// Initializes a new instance of the Purchasing_Contact_Type class based on Primary Key.
        /// </summary>
        public Purchasing_Contact_Type(decimal pK_ID)
        {
            DataTable dtPurchasing_Contact_Type = SelectByPK(pK_ID).Tables[0];

            if (dtPurchasing_Contact_Type.Rows.Count == 1)
            {
                DataRow drPurchasing_Contact_Type = dtPurchasing_Contact_Type.Rows[0];
                if (drPurchasing_Contact_Type["PK_ID"] == DBNull.Value)
                    this._PK_ID = null;
                else
                    this._PK_ID = (decimal?)drPurchasing_Contact_Type["PK_ID"];

                if (drPurchasing_Contact_Type["FLD_desc"] == DBNull.Value)
                    this._FLD_desc = null;
                else
                    this._FLD_desc = (string)drPurchasing_Contact_Type["FLD_desc"];

                if (drPurchasing_Contact_Type["FLD_code"] == DBNull.Value)
                    this._FLD_code = null;
                else
                    this._FLD_code = (string)drPurchasing_Contact_Type["FLD_code"];

            }
            else
            {
                this._PK_ID = null;
                this._FLD_desc = null;
                this._FLD_code = null;
            }

        }

        #endregion

        /// <summary>
        /// Inserts a record into the Purchasing_Contact_Type table.
        /// </summary>
        /// <returns></returns>
        public void Insert()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Purchasing_Contact_TypeInsert");


            db.AddInParameter(dbCommand, "PK_ID", DbType.Decimal, this._PK_ID);

            if (string.IsNullOrEmpty(this._FLD_desc))
                db.AddInParameter(dbCommand, "FLD_desc", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "FLD_desc", DbType.String, this._FLD_desc);

            if (string.IsNullOrEmpty(this._FLD_code))
                db.AddInParameter(dbCommand, "FLD_code", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "FLD_code", DbType.String, this._FLD_code);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Selects a single record from the Purchasing_Contact_Type table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        private static DataSet SelectByPK(decimal pK_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Purchasing_Contact_TypeSelectByPK");

            db.AddInParameter(dbCommand, "PK_ID", DbType.Decimal, pK_ID);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the Purchasing_Contact_Type table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Purchasing_Contact_TypeSelectAll");

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Updates a record in the Purchasing_Contact_Type table.
        /// </summary>
        public void Update()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Purchasing_Contact_TypeUpdate");


            db.AddInParameter(dbCommand, "PK_ID", DbType.Decimal, this._PK_ID);

            if (string.IsNullOrEmpty(this._FLD_desc))
                db.AddInParameter(dbCommand, "FLD_desc", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "FLD_desc", DbType.String, this._FLD_desc);

            if (string.IsNullOrEmpty(this._FLD_code))
                db.AddInParameter(dbCommand, "FLD_code", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "FLD_code", DbType.String, this._FLD_code);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Deletes a record from the Purchasing_Contact_Type table by a composite primary key.
        /// </summary>
        public static void DeleteByPK(decimal pK_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Purchasing_Contact_TypeDeleteByPK");

            db.AddInParameter(dbCommand, "PK_ID", DbType.Decimal, pK_ID);

            db.ExecuteNonQuery(dbCommand);
        }
    }
}
