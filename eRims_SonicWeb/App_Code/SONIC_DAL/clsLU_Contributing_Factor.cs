using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
    /// <summary>
    /// Data access class for LU_Contributing_Factor table.
    /// </summary>
    public sealed class clsLU_Contributing_Factor
    {

        #region Private variables used to hold the property values

        private decimal? _PK_LU_Contributing_Factor;
        private string _Field_Description;
        private string _Active;

        #endregion

        #region Public Property

        /// <summary>
        /// Gets or sets the PK_LU_Contributing_Factor value.
        /// </summary>
        public decimal? PK_LU_Contributing_Factor
        {
            get { return _PK_LU_Contributing_Factor; }
            set { _PK_LU_Contributing_Factor = value; }
        }

        /// <summary>
        /// Gets or sets the Field_Description value.
        /// </summary>
        public string Field_Description
        {
            get { return _Field_Description; }
            set { _Field_Description = value; }
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
        /// Initializes a new instance of the clsLU_Contributing_Factor class with default value.
        /// </summary>
        public clsLU_Contributing_Factor()
        {


        }

        #endregion

        #region Primary Constructors

        /// <summary>
        /// Initializes a new instance of the clsLU_Contributing_Factor class based on Primary Key.
        /// </summary>
        public clsLU_Contributing_Factor(decimal pK_LU_Contributing_Factor)
        {
            DataTable dtLU_Contributing_Factor = SelectByPK(pK_LU_Contributing_Factor).Tables[0];

            if (dtLU_Contributing_Factor.Rows.Count == 1)
            {
                SetValue(dtLU_Contributing_Factor.Rows[0]);

            }

        }


        /// <summary>
        /// Initializes a new instance of the clsLU_Contributing_Factor class based on Datarow passed.
        /// </summary>
        private void SetValue(DataRow drLU_Contributing_Factor)
        {
            if (drLU_Contributing_Factor["PK_LU_Contributing_Factor"] == DBNull.Value)
                this._PK_LU_Contributing_Factor = null;
            else
                this._PK_LU_Contributing_Factor = (decimal?)drLU_Contributing_Factor["PK_LU_Contributing_Factor"];

            if (drLU_Contributing_Factor["Field_Description"] == DBNull.Value)
                this._Field_Description = null;
            else
                this._Field_Description = (string)drLU_Contributing_Factor["Field_Description"];

            if (drLU_Contributing_Factor["Active"] == DBNull.Value)
                this._Active = null;
            else
                this._Active = (string)drLU_Contributing_Factor["Active"];


        }

        #endregion

        /// <summary>
        /// Inserts a record into the LU_Contributing_Factor table.
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_Contributing_FactorInsert");


            if (string.IsNullOrEmpty(this._Field_Description))
                db.AddInParameter(dbCommand, "Field_Description", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Field_Description", DbType.String, this._Field_Description);

            if (string.IsNullOrEmpty(this._Active))
                db.AddInParameter(dbCommand, "Active", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Active", DbType.String, this._Active);

            // Execute the query and return the new identity value
            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
        }

        /// <summary>
        /// Selects a single record from the LU_Contributing_Factor table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        private DataSet SelectByPK(decimal pK_LU_Contributing_Factor)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_Contributing_FactorSelectByPK");

            db.AddInParameter(dbCommand, "PK_LU_Contributing_Factor", DbType.Decimal, pK_LU_Contributing_Factor);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the LU_Contributing_Factor table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_Contributing_FactorSelectAll");

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Updates a record in the LU_Contributing_Factor table.
        /// </summary>
        public decimal Update()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_Contributing_FactorUpdate");


            db.AddInParameter(dbCommand, "PK_LU_Contributing_Factor", DbType.Decimal, this._PK_LU_Contributing_Factor);

            if (string.IsNullOrEmpty(this._Field_Description))
                db.AddInParameter(dbCommand, "Field_Description", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Field_Description", DbType.String, this._Field_Description);

            if (string.IsNullOrEmpty(this._Active))
                db.AddInParameter(dbCommand, "Active", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Active", DbType.String, this._Active);

            db.ExecuteNonQuery(dbCommand);
            return Convert.ToDecimal(db.ExecuteScalar(dbCommand));
        }

        /// <summary>
        /// Deletes a record from the LU_Contributing_Factor table by a composite primary key.
        /// </summary>
        public static void DeleteByPK(decimal pK_LU_Contributing_Factor)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_Contributing_FactorDeleteByPK");

            db.AddInParameter(dbCommand, "PK_LU_Contributing_Factor", DbType.Decimal, pK_LU_Contributing_Factor);

            db.ExecuteNonQuery(dbCommand);
        }
    }
}
