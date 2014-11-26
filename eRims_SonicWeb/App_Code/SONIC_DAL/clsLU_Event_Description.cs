using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
    /// <summary>
    /// Data access class for LU_Event_Description table.
    /// </summary>
    public sealed class clsLU_Event_Description
    {

        #region Private variables used to hold the property values

        private decimal? _PK_LU_Event_Description;
        private string _Fld_code;
        private string _Fld_Desc;

        #endregion

        #region Public Property

        /// <summary>
        /// Gets or sets the PK_LU_Event_Description value.
        /// </summary>
        public decimal? PK_LU_Event_Description
        {
            get { return _PK_LU_Event_Description; }
            set { _PK_LU_Event_Description = value; }
        }

        /// <summary>
        /// Gets or sets the Fld_code value.
        /// </summary>
        public string Fld_code
        {
            get { return _Fld_code; }
            set { _Fld_code = value; }
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
        /// Initializes a new instance of the clsLU_Event_Description class with default value.
        /// </summary>
        public clsLU_Event_Description()
        {


        }

        #endregion

        #region Primary Constructors

        /// <summary>
        /// Initializes a new instance of the clsLU_Event_Description class based on Primary Key.
        /// </summary>
        public clsLU_Event_Description(decimal pK_LU_Event_Description)
        {
            DataTable dtLU_Event_Description = SelectByPK(pK_LU_Event_Description).Tables[0];

            if (dtLU_Event_Description.Rows.Count == 1)
            {
                SetValue(dtLU_Event_Description.Rows[0]);

            }

        }


        /// <summary>
        /// Initializes a new instance of the clsLU_Event_Description class based on Datarow passed.
        /// </summary>
        private void SetValue(DataRow drLU_Event_Description)
        {
            if (drLU_Event_Description["PK_LU_Event_Description"] == DBNull.Value)
                this._PK_LU_Event_Description = null;
            else
                this._PK_LU_Event_Description = (decimal?)drLU_Event_Description["PK_LU_Event_Description"];

            if (drLU_Event_Description["Fld_code"] == DBNull.Value)
                this._Fld_code = null;
            else
                this._Fld_code = (string)drLU_Event_Description["Fld_code"];

            if (drLU_Event_Description["Fld_Desc"] == DBNull.Value)
                this._Fld_Desc = null;
            else
                this._Fld_Desc = (string)drLU_Event_Description["Fld_Desc"];


        }

        #endregion

        /// <summary>
        /// Inserts a record into the LU_Event_Description table.
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_Event_DescriptionInsert");


            if (string.IsNullOrEmpty(this._Fld_code))
                db.AddInParameter(dbCommand, "Fld_code", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Fld_code", DbType.String, this._Fld_code);

            if (string.IsNullOrEmpty(this._Fld_Desc))
                db.AddInParameter(dbCommand, "Fld_Desc", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Fld_Desc", DbType.String, this._Fld_Desc);

            // Execute the query and return the new identity value
            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
        }

        /// <summary>
        /// Selects a single record from the LU_Event_Description table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        private DataSet SelectByPK(decimal pK_LU_Event_Description)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_Event_DescriptionSelectByPK");

            db.AddInParameter(dbCommand, "PK_LU_Event_Description", DbType.Decimal, pK_LU_Event_Description);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the LU_Event_Description table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_Event_DescriptionSelectAll");

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Updates a record in the LU_Event_Description table.
        /// </summary>
        public int Update()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_Event_DescriptionUpdate");


            db.AddInParameter(dbCommand, "PK_LU_Event_Description", DbType.Decimal, this._PK_LU_Event_Description);

            if (string.IsNullOrEmpty(this._Fld_code))
                db.AddInParameter(dbCommand, "Fld_code", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Fld_code", DbType.String, this._Fld_code);

            if (string.IsNullOrEmpty(this._Fld_Desc))
                db.AddInParameter(dbCommand, "Fld_Desc", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Fld_Desc", DbType.String, this._Fld_Desc);

            // Execute the query and return the new identity value
            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));
            return returnValue;

        }

        /// <summary>
        /// Deletes a record from the LU_Event_Description table by a composite primary key.
        /// </summary>
        public static void DeleteByPK(decimal pK_LU_Event_Description)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_Event_DescriptionDeleteByPK");

            db.AddInParameter(dbCommand, "PK_LU_Event_Description", DbType.Decimal, pK_LU_Event_Description);

            db.ExecuteNonQuery(dbCommand);
        }
    }
}
