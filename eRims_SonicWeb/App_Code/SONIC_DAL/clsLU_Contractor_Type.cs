using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;


namespace ERIMS.DAL
{
    /// <summary>
    /// Data access class for table LU_Contractor_Type
    /// </summary>
    public sealed class clsLU_Contractor_Type
    {

        #region Private variables used to hold the property values

        private decimal? _PK_LU_Contractor_Type;
        private string _CT_Desc;
        private string _Active;

        #endregion

        #region Public Property

        /// <summary>
        /// Gets or sets the PK_LU_Contractor_Type value.
        /// </summary>
        public decimal? PK_LU_Contractor_Type
        {
            get { return _PK_LU_Contractor_Type; }
            set { _PK_LU_Contractor_Type = value; }
        }

        /// <summary>
        /// Gets or sets the CT_Desc value.
        /// </summary>
        public string CT_Desc
        {
            get { return _CT_Desc; }
            set { _CT_Desc = value; }
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
        /// Initializes a new instance of the LU_Contractor_Type class with default value.
        /// </summary>
        public clsLU_Contractor_Type()
        {


        }

        #endregion

        #region Primary Constructors

        /// <summary>
        /// Initializes a new instance of the LU_Contractor_Type class based on Primary Key.
        /// </summary>
        public clsLU_Contractor_Type(decimal pK_LU_Contractor_Type)
        {
            DataTable dtLU_Contractor_Type = Select(pK_LU_Contractor_Type).Tables[0];

            if (dtLU_Contractor_Type.Rows.Count == 1)
            {
                SetValue(dtLU_Contractor_Type.Rows[0]);

            }

        }


        /// <summary>
        /// Initializes a new instance of the LU_Contractor_Type class based on Datarow passed.
        /// </summary>
        private void SetValue(DataRow drLU_Contractor_Type)
        {
            if (drLU_Contractor_Type["PK_LU_Contractor_Type"] == DBNull.Value)
                this._PK_LU_Contractor_Type = null;
            else
                this._PK_LU_Contractor_Type = (decimal?)drLU_Contractor_Type["PK_LU_Contractor_Type"];

            if (drLU_Contractor_Type["CT_Desc"] == DBNull.Value)
                this._CT_Desc = null;
            else
                this._CT_Desc = (string)drLU_Contractor_Type["CT_Desc"];

            if (drLU_Contractor_Type["Active"] == DBNull.Value)
                this._Active = null;
            else
                this._Active = (string)drLU_Contractor_Type["Active"];


        }

        #endregion

        /// <summary>
        /// Inserts a record into the LU_Contractor_Type table.
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_Contractor_TypeInsert");


            if (string.IsNullOrEmpty(this._CT_Desc))
                db.AddInParameter(dbCommand, "CT_Desc", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "CT_Desc", DbType.String, this._CT_Desc);

            if (string.IsNullOrEmpty(this._Active))
                db.AddInParameter(dbCommand, "Active", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Active", DbType.String, this._Active);

            // Execute the query and return the new identity value
            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
        }

        /// <summary>
        /// Selects a single record from the LU_Contractor_Type table.
        /// </summary>
        /// <returns>DataSet</returns>
        private DataSet Select(decimal pK_LU_Contractor_Type)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_Contractor_TypeSelect");

            db.AddInParameter(dbCommand, "PK_LU_Contractor_Type", DbType.Decimal, pK_LU_Contractor_Type);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the LU_Contractor_Type table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_Contractor_TypeSelectAll");

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Updates a record in the LU_Contractor_Type table.
        /// </summary>
        public decimal Update()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_Contractor_TypeUpdate");


            db.AddInParameter(dbCommand, "PK_LU_Contractor_Type", DbType.Decimal, this._PK_LU_Contractor_Type);

            if (string.IsNullOrEmpty(this._CT_Desc))
                db.AddInParameter(dbCommand, "CT_Desc", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "CT_Desc", DbType.String, this._CT_Desc);

            if (string.IsNullOrEmpty(this._Active))
                db.AddInParameter(dbCommand, "Active", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Active", DbType.String, this._Active);

           decimal ret = db.ExecuteNonQuery(dbCommand);

           return ret;
        }
    }
}
