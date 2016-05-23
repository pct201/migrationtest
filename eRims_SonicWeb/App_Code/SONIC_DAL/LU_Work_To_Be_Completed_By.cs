using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
    /// <summary>
    /// Data access class for LU_Work_To_Be_Completed_By table.
    /// </summary>
    public sealed class LU_Work_To_Be_Completed_By
    {

        #region Private variables used to hold the property values

        private decimal? _PK_LU_Work_To_Be_Completed_By;
        private string _Fld_Desc;
        private string _Active;

        #endregion

        #region Public Property

        /// <summary>
        /// Gets or sets the PK_LU_Work_To_Be_Completed_By value.
        /// </summary>
        public decimal? PK_LU_Work_To_Be_Completed_By
        {
            get { return _PK_LU_Work_To_Be_Completed_By; }
            set { _PK_LU_Work_To_Be_Completed_By = value; }
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
        /// Initializes a new instance of the LU_Work_To_Be_Completed_By class with default value.
        /// </summary>
        public LU_Work_To_Be_Completed_By()
        {


        }

        #endregion

        #region Primary Constructors

        /// <summary>
        /// Initializes a new instance of the LU_Work_To_Be_Completed_By class based on Primary Key.
        /// </summary>
        public LU_Work_To_Be_Completed_By(decimal pK_LU_Work_To_Be_Completed_By)
        {
            DataTable dtLU_Work_To_Be_Completed_By = SelectByPK(pK_LU_Work_To_Be_Completed_By).Tables[0];

            if (dtLU_Work_To_Be_Completed_By.Rows.Count == 1)
            {
                SetValue(dtLU_Work_To_Be_Completed_By.Rows[0]);

            }

        }


        /// <summary>
        /// Initializes a new instance of the LU_Work_To_Be_Completed_By class based on Datarow passed.
        /// </summary>
        private void SetValue(DataRow drLU_Work_To_Be_Completed_By)
        {
            if (drLU_Work_To_Be_Completed_By["PK_LU_Work_To_Be_Completed_By"] == DBNull.Value)
                this._PK_LU_Work_To_Be_Completed_By = null;
            else
                this._PK_LU_Work_To_Be_Completed_By = (decimal?)drLU_Work_To_Be_Completed_By["PK_LU_Work_To_Be_Completed_By"];

            if (drLU_Work_To_Be_Completed_By["Fld_Desc"] == DBNull.Value)
                this._Fld_Desc = null;
            else
                this._Fld_Desc = (string)drLU_Work_To_Be_Completed_By["Fld_Desc"];

            if (drLU_Work_To_Be_Completed_By["Active"] == DBNull.Value)
                this._Active = null;
            else
                this._Active = (string)drLU_Work_To_Be_Completed_By["Active"];


        }

        #endregion

        /// <summary>
        /// Inserts a record into the LU_Work_To_Be_Completed_By table.
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_Work_To_Be_Completed_ByInsert");


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
        /// Selects a single record from the LU_Work_To_Be_Completed_By table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        private DataSet SelectByPK(decimal pK_LU_Work_To_Be_Completed_By)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_Work_To_Be_Completed_BySelectByPK");

            db.AddInParameter(dbCommand, "PK_LU_Work_To_Be_Completed_By", DbType.Decimal, pK_LU_Work_To_Be_Completed_By);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the LU_Work_To_Be_Completed_By table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_Work_To_Be_Completed_BySelectAll");

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Updates a record in the LU_Work_To_Be_Completed_By table.
        /// </summary>
        public decimal Update()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_Work_To_Be_Completed_ByUpdate");


            db.AddInParameter(dbCommand, "PK_LU_Work_To_Be_Completed_By", DbType.Decimal, this._PK_LU_Work_To_Be_Completed_By);

            if (string.IsNullOrEmpty(this._Fld_Desc))
                db.AddInParameter(dbCommand, "Fld_Desc", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Fld_Desc", DbType.String, this._Fld_Desc);

            if (string.IsNullOrEmpty(this._Active))
                db.AddInParameter(dbCommand, "Active", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Active", DbType.String, this._Active);

            return Convert.ToDecimal(db.ExecuteScalar(dbCommand));
        }

        /// <summary>
        /// Deletes a record from the LU_Work_To_Be_Completed_By table by a composite primary key.
        /// </summary>
        public static void DeleteByPK(decimal pK_LU_Work_To_Be_Completed_By)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_Work_To_Be_Completed_ByDeleteByPK");

            db.AddInParameter(dbCommand, "PK_LU_Work_To_Be_Completed_By", DbType.Decimal, pK_LU_Work_To_Be_Completed_By);

            db.ExecuteNonQuery(dbCommand);
        }
    }
}