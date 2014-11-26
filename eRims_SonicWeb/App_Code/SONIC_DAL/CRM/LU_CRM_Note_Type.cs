using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
    /// <summary>
    /// Data access class for LU_CRM_Note_Type table.
    /// </summary>
    public sealed class LU_CRM_Note_Type
    {

        #region Private variables used to hold the property values

        private decimal? _PK_LU_CRM_Note_Type;
        private string _Table_Name;
        private string _Fld_Desc;
        private string _Active;

        #endregion

        #region Public Property

        /// <summary>
        /// Gets or sets the PK_LU_CRM_Note_Type value.
        /// </summary>
        public decimal? PK_LU_CRM_Note_Type
        {
            get { return _PK_LU_CRM_Note_Type; }
            set { _PK_LU_CRM_Note_Type = value; }
        }

        /// <summary>
        /// Gets or sets the Table_Name value.
        /// </summary>
        public string Table_Name
        {
            get { return _Table_Name; }
            set { _Table_Name = value; }
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
        /// Initializes a new instance of the LU_CRM_Note_Type class with default value.
        /// </summary>
        public LU_CRM_Note_Type()
        {

            this._PK_LU_CRM_Note_Type = null;
            this._Table_Name = null;
            this._Fld_Desc = null;
            this._Active = null;

        }

        #endregion

        #region Primary Constructors

        /// <summary>
        /// Initializes a new instance of the LU_CRM_Note_Type class based on Primary Key.
        /// </summary>
        public LU_CRM_Note_Type(decimal pK_LU_CRM_Note_Type)
        {
            DataTable dtLU_CRM_Note_Type = SelectByPK(pK_LU_CRM_Note_Type).Tables[0];

            if (dtLU_CRM_Note_Type.Rows.Count == 1)
            {
                DataRow drLU_CRM_Note_Type = dtLU_CRM_Note_Type.Rows[0];
                if (drLU_CRM_Note_Type["PK_LU_CRM_Note_Type"] == DBNull.Value)
                    this._PK_LU_CRM_Note_Type = null;
                else
                    this._PK_LU_CRM_Note_Type = (decimal?)drLU_CRM_Note_Type["PK_LU_CRM_Note_Type"];

                if (drLU_CRM_Note_Type["Table_Name"] == DBNull.Value)
                    this._Table_Name = null;
                else
                    this._Table_Name = (string)drLU_CRM_Note_Type["Table_Name"];

                if (drLU_CRM_Note_Type["Fld_Desc"] == DBNull.Value)
                    this._Fld_Desc = null;
                else
                    this._Fld_Desc = (string)drLU_CRM_Note_Type["Fld_Desc"];

                if (drLU_CRM_Note_Type["Active"] == DBNull.Value)
                    this._Active = null;
                else
                    this._Active = (string)drLU_CRM_Note_Type["Active"];

            }
            else
            {
                this._PK_LU_CRM_Note_Type = null;
                this._Table_Name = null;
                this._Fld_Desc = null;
                this._Active = null;
            }

        }

        #endregion

        /// <summary>
        /// Inserts a record into the LU_CRM_Note_Type table.
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_CRM_Note_TypeInsert");


            if (string.IsNullOrEmpty(this._Table_Name))
                db.AddInParameter(dbCommand, "Table_Name", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Table_Name", DbType.String, this._Table_Name);

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
        /// Selects a single record from the LU_CRM_Note_Type table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        private static DataSet SelectByPK(decimal pK_LU_CRM_Note_Type)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_CRM_Note_TypeSelectByPK");

            db.AddInParameter(dbCommand, "PK_LU_CRM_Note_Type", DbType.Decimal, pK_LU_CRM_Note_Type);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the LU_CRM_Note_Type table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_CRM_Note_TypeSelectAll");

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Updates a record in the LU_CRM_Note_Type table.
        /// </summary>
        public decimal Update()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_CRM_Note_TypeUpdate");


            db.AddInParameter(dbCommand, "PK_LU_CRM_Note_Type", DbType.Decimal, this._PK_LU_CRM_Note_Type);

            if (string.IsNullOrEmpty(this._Table_Name))
                db.AddInParameter(dbCommand, "Table_Name", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Table_Name", DbType.String, this._Table_Name);

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
        /// Deletes a record from the LU_CRM_Note_Type table by a composite primary key.
        /// </summary>
        public static void DeleteByPK(decimal pK_LU_CRM_Note_Type)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_CRM_Note_TypeDeleteByPK");

            db.AddInParameter(dbCommand, "PK_LU_CRM_Note_Type", DbType.Decimal, pK_LU_CRM_Note_Type);

            db.ExecuteNonQuery(dbCommand);
        }
    }
}
