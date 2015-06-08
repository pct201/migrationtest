using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
    /// <summary>
    /// Data access class for table LU_Facility_Construction_Alert_Method
    /// </summary>
    public sealed class LU_Facility_Construction_Alert_Method
    {

        #region Private variables used to hold the property values

        private decimal? _PK_LU_Facility_Construction_Alert_Method;
        private string _Alert_Method;
        private string _Active;

        #endregion

        #region Public Property

        /// <summary>
        /// Gets or sets the PK_LU_Facility_Construction_Alert_Method value.
        /// </summary>
        public decimal? PK_LU_Facility_Construction_Alert_Method
        {
            get { return _PK_LU_Facility_Construction_Alert_Method; }
            set { _PK_LU_Facility_Construction_Alert_Method = value; }
        }

        /// <summary>
        /// Gets or sets the Alert_Method value.
        /// </summary>
        public string Alert_Method
        {
            get { return _Alert_Method; }
            set { _Alert_Method = value; }
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
        /// Initializes a new instance of the LU_Facility_Construction_Alert_Method class with default value.
        /// </summary>
        public LU_Facility_Construction_Alert_Method()
        {


        }

        #endregion

        #region Primary Constructors

        /// <summary>
        /// Initializes a new instance of the LU_Facility_Construction_Alert_Method class based on Primary Key.
        /// </summary>
        public LU_Facility_Construction_Alert_Method(decimal pK_LU_Facility_Construction_Alert_Method)
        {
            DataTable dtLU_Facility_Construction_Alert_Method = Select(pK_LU_Facility_Construction_Alert_Method).Tables[0];

            if (dtLU_Facility_Construction_Alert_Method.Rows.Count == 1)
            {
                SetValue(dtLU_Facility_Construction_Alert_Method.Rows[0]);

            }

        }


        /// <summary>
        /// Initializes a new instance of the LU_Facility_Construction_Alert_Method class based on Datarow passed.
        /// </summary>
        private void SetValue(DataRow drLU_Facility_Construction_Alert_Method)
        {
            if (drLU_Facility_Construction_Alert_Method["PK_LU_Facility_Construction_Alert_Method"] == DBNull.Value)
                this._PK_LU_Facility_Construction_Alert_Method = null;
            else
                this._PK_LU_Facility_Construction_Alert_Method = (decimal?)drLU_Facility_Construction_Alert_Method["PK_LU_Facility_Construction_Alert_Method"];

            if (drLU_Facility_Construction_Alert_Method["Alert_Method"] == DBNull.Value)
                this._Alert_Method = null;
            else
                this._Alert_Method = (string)drLU_Facility_Construction_Alert_Method["Alert_Method"];

            if (drLU_Facility_Construction_Alert_Method["Active"] == DBNull.Value)
                this._Active = null;
            else
                this._Active = (string)drLU_Facility_Construction_Alert_Method["Active"];


        }

        #endregion

        /// <summary>
        /// Inserts a record into the LU_Facility_Construction_Alert_Method table.
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_Facility_Construction_Alert_MethodInsert");


            if (string.IsNullOrEmpty(this._Alert_Method))
                db.AddInParameter(dbCommand, "Alert_Method", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Alert_Method", DbType.String, this._Alert_Method);

            if (string.IsNullOrEmpty(this._Active))
                db.AddInParameter(dbCommand, "Active", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Active", DbType.String, this._Active);

            // Execute the query and return the new identity value
            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
        }

        /// <summary>
        /// Selects a single record from the LU_Facility_Construction_Alert_Method table.
        /// </summary>
        /// <returns>DataSet</returns>
        private DataSet Select(decimal pK_LU_Facility_Construction_Alert_Method)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_Facility_Construction_Alert_MethodSelect");

            db.AddInParameter(dbCommand, "PK_LU_Facility_Construction_Alert_Method", DbType.Decimal, pK_LU_Facility_Construction_Alert_Method);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the LU_Facility_Construction_Alert_Method table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_Facility_Construction_Alert_MethodSelectAll");

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the LU_Facility_Construction_Alert_Method table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAllActive()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_Facility_Construction_Alert_MethodSelectAllActive");

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Updates a record in the LU_Facility_Construction_Alert_Method table.
        /// </summary>
        public void Update()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_Facility_Construction_Alert_MethodUpdate");


            db.AddInParameter(dbCommand, "PK_LU_Facility_Construction_Alert_Method", DbType.Decimal, this._PK_LU_Facility_Construction_Alert_Method);

            if (string.IsNullOrEmpty(this._Alert_Method))
                db.AddInParameter(dbCommand, "Alert_Method", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Alert_Method", DbType.String, this._Alert_Method);

            if (string.IsNullOrEmpty(this._Active))
                db.AddInParameter(dbCommand, "Active", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Active", DbType.String, this._Active);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Deletes a record from the LU_Facility_Construction_Alert_Method table by a composite primary key.
        /// </summary>
        public static void Delete(decimal pK_LU_Facility_Construction_Alert_Method)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_Facility_Construction_Alert_MethodDelete");

            db.AddInParameter(dbCommand, "PK_LU_Facility_Construction_Alert_Method", DbType.Decimal, pK_LU_Facility_Construction_Alert_Method);

            db.ExecuteNonQuery(dbCommand);
        }
    }
}
