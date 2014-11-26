using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
    /// <summary>
    /// Data access class for LU_Escalation table.
    /// </summary>
    public sealed class LU_Escalation
    {

        #region Private variables used to hold the property values

        private decimal? _PK_LU_Escalation;
        private string _Fld_Desc;

        #endregion

        #region Public Property

        /// <summary>
        /// Gets or sets the PK_LU_Escalation value.
        /// </summary>
        public decimal? PK_LU_Escalation
        {
            get { return _PK_LU_Escalation; }
            set { _PK_LU_Escalation = value; }
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
        /// Initializes a new instance of the LU_Escalation class with default value.
        /// </summary>
        public LU_Escalation()
        {

            this._PK_LU_Escalation = null;
            this._Fld_Desc = null;

        }

        #endregion

        #region Primary Constructors

        /// <summary>
        /// Initializes a new instance of the LU_Escalation class based on Primary Key.
        /// </summary>
        public LU_Escalation(decimal pK_LU_Escalation)
        {
            DataTable dtLU_Escalation = SelectByPK(pK_LU_Escalation).Tables[0];

            if (dtLU_Escalation.Rows.Count == 1)
            {
                DataRow drLU_Escalation = dtLU_Escalation.Rows[0];
                if (drLU_Escalation["PK_LU_Escalation"] == DBNull.Value)
                    this._PK_LU_Escalation = null;
                else
                    this._PK_LU_Escalation = (decimal?)drLU_Escalation["PK_LU_Escalation"];

                if (drLU_Escalation["Fld_Desc"] == DBNull.Value)
                    this._Fld_Desc = null;
                else
                    this._Fld_Desc = (string)drLU_Escalation["Fld_Desc"];

            }
            else
            {
                this._PK_LU_Escalation = null;
                this._Fld_Desc = null;
            }

        }

        #endregion

        /// <summary>
        /// Inserts a record into the LU_Escalation table.
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_EscalationInsert");


            if (string.IsNullOrEmpty(this._Fld_Desc))
                db.AddInParameter(dbCommand, "Fld_Desc", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Fld_Desc", DbType.String, this._Fld_Desc);

            // Execute the query and return the new identity value
            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
        }

        /// <summary>
        /// Selects a single record from the LU_Escalation table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        private static DataSet SelectByPK(decimal pK_LU_Escalation)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_EscalationSelectByPK");

            db.AddInParameter(dbCommand, "PK_LU_Escalation", DbType.Decimal, pK_LU_Escalation);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the LU_Escalation table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_EscalationSelectAll");

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Updates a record in the LU_Escalation table.
        /// </summary>
        public void Update()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_EscalationUpdate");


            db.AddInParameter(dbCommand, "PK_LU_Escalation", DbType.Decimal, this._PK_LU_Escalation);

            if (string.IsNullOrEmpty(this._Fld_Desc))
                db.AddInParameter(dbCommand, "Fld_Desc", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Fld_Desc", DbType.String, this._Fld_Desc);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Deletes a record from the LU_Escalation table by a composite primary key.
        /// </summary>
        public static void DeleteByPK(decimal pK_LU_Escalation)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_EscalationDeleteByPK");

            db.AddInParameter(dbCommand, "PK_LU_Escalation", DbType.Decimal, pK_LU_Escalation);

            db.ExecuteNonQuery(dbCommand);
        }
    }
}
