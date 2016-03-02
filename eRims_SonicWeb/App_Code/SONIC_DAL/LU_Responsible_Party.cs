using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Web;

namespace ERIMS.DAL
{
    /// <summary>
    /// Data access class for LU_Responsible_Party table.
    /// </summary>
    public sealed class LU_Responsible_Party
    {

        #region Private variables used to hold the property values

        private decimal? _PK_LU_Responsible_Party;
        private string _Description;
        private string _Active;

        #endregion

        #region Public Property

        /// <summary>
        /// Gets or sets the PK_LU_Responsible_Party value.
        /// </summary>
        public decimal? PK_LU_Responsible_Party
        {
            get { return _PK_LU_Responsible_Party; }
            set { _PK_LU_Responsible_Party = value; }
        }

        /// <summary>
        /// Gets or sets the Description value.
        /// </summary>
        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
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
        /// Initializes a new instance of the LU_Responsible_Party class with default value.
        /// </summary>
        public LU_Responsible_Party()
        {


        }

        #endregion

        #region Primary Constructors

        /// <summary>
        /// Initializes a new instance of the LU_Responsible_Party class based on Primary Key.
        /// </summary>
        public LU_Responsible_Party(decimal pK_LU_Responsible_Party)
        {
            DataTable dtLU_Responsible_Party = SelectByPK(pK_LU_Responsible_Party).Tables[0];

            if (dtLU_Responsible_Party.Rows.Count == 1)
            {
                SetValue(dtLU_Responsible_Party.Rows[0]);

            }

        }

        /// <summary>
        /// Initializes a new instance of the LU_Responsible_Party class based on Datarow passed.
        /// </summary>
        private void SetValue(DataRow drLU_Responsible_Party)
        {
            if (drLU_Responsible_Party["PK_LU_Responsible_Party"] == DBNull.Value)
                this._PK_LU_Responsible_Party = null;
            else
                this._PK_LU_Responsible_Party = (decimal?)drLU_Responsible_Party["PK_LU_Responsible_Party"];

            if (drLU_Responsible_Party["Description"] == DBNull.Value)
                this._Description = null;
            else
                this._Description = (string)drLU_Responsible_Party["Description"];

            if (drLU_Responsible_Party["Active"] == DBNull.Value)
                this._Active = null;
            else
                this._Active = (string)drLU_Responsible_Party["Active"];

        }

        #endregion

        /// <summary>
        /// Inserts a record into the LU_Responsible_Party table.
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_Responsible_PartyInsert");

            if (string.IsNullOrEmpty(this._Description))
                db.AddInParameter(dbCommand, "Description", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Description", DbType.String, this._Description);

            if (string.IsNullOrEmpty(this._Active))
                db.AddInParameter(dbCommand, "Active", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Active", DbType.String, this._Active);

            // Execute the query and return the new identity value
            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
        }

        /// <summary>
        /// Selects a single record from the LU_Responsible_Party table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        private DataSet SelectByPK(decimal pK_LU_Responsible_Party)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_Responsible_PartySelectByPK");

            db.AddInParameter(dbCommand, "PK_LU_Responsible_Party", DbType.Decimal, pK_LU_Responsible_Party);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the LU_Responsible_Party table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_Responsible_PartySelectAll");

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Updates a record in the LU_Responsible_Party table.
        /// </summary>
        public decimal Update()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_Responsible_PartyUpdate");

            db.AddInParameter(dbCommand, "PK_LU_Responsible_Party", DbType.Decimal, this._PK_LU_Responsible_Party);

            if (string.IsNullOrEmpty(this._Description))
                db.AddInParameter(dbCommand, "Description", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Description", DbType.String, this._Description);

            if (string.IsNullOrEmpty(this._Active))
                db.AddInParameter(dbCommand, "Active", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Active", DbType.String, this._Active);

             return Convert.ToDecimal(db.ExecuteScalar(dbCommand));
        }

        /// <summary>
        /// Deletes a record from the LU_Responsible_Party table by a composite primary key.
        /// </summary>
        public static void DeleteByPK(decimal pK_LU_Responsible_Party)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_Responsible_PartyDeleteByPK");

            db.AddInParameter(dbCommand, "PK_LU_Responsible_Party", DbType.Decimal, pK_LU_Responsible_Party);

            db.ExecuteNonQuery(dbCommand);
        }
    }
}