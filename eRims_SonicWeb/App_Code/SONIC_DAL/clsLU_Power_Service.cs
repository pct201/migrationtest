using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
    /// <summary>
    /// Data access class for LU_Power_Service table.
    /// </summary>
    public sealed class clsLU_Power_Service
    {

        #region Private variables used to hold the property values

        private decimal? _PK_LU_Power_Service;
        private string _Fld_Desc;
        private string _Active;

        #endregion

        #region Public Property

        /// <summary>
        /// Gets or sets the PK_LU_Power_Service value.
        /// </summary>
        public decimal? PK_LU_Power_Service
        {
            get { return _PK_LU_Power_Service; }
            set { _PK_LU_Power_Service = value; }
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
        /// Initializes a new instance of the clsLU_Power_Service class with default value.
        /// </summary>
        public clsLU_Power_Service()
        {


        }

        #endregion

        #region Primary Constructors

        /// <summary>
        /// Initializes a new instance of the clsLU_Power_Service class based on Primary Key.
        /// </summary>
        public clsLU_Power_Service(decimal pK_LU_Power_Service)
        {
            DataTable dtLU_Power_Service = SelectByPK(pK_LU_Power_Service).Tables[0];

            if (dtLU_Power_Service.Rows.Count == 1)
            {
                SetValue(dtLU_Power_Service.Rows[0]);

            }

        }


        /// <summary>
        /// Initializes a new instance of the clsLU_Power_Service class based on Datarow passed.
        /// </summary>
        private void SetValue(DataRow drLU_Power_Service)
        {
            if (drLU_Power_Service["PK_LU_Power_Service"] == DBNull.Value)
                this._PK_LU_Power_Service = null;
            else
                this._PK_LU_Power_Service = (decimal?)drLU_Power_Service["PK_LU_Power_Service"];

            if (drLU_Power_Service["Fld_Desc"] == DBNull.Value)
                this._Fld_Desc = null;
            else
                this._Fld_Desc = (string)drLU_Power_Service["Fld_Desc"];

            if (drLU_Power_Service["Active"] == DBNull.Value)
                this._Active = null;
            else
                this._Active = (string)drLU_Power_Service["Active"];


        }

        #endregion

        /// <summary>
        /// Inserts a record into the LU_Power_Service table.
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_Power_ServiceInsert");


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
        /// Selects a single record from the LU_Power_Service table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        private DataSet SelectByPK(decimal pK_LU_Power_Service)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_Power_ServiceSelectByPK");

            db.AddInParameter(dbCommand, "PK_LU_Power_Service", DbType.Decimal, pK_LU_Power_Service);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the LU_Power_Service table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_Power_ServiceSelectAll");

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Updates a record in the LU_Power_Service table.
        /// </summary>
        public int Update()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_Power_ServiceUpdate");


            db.AddInParameter(dbCommand, "PK_LU_Power_Service", DbType.Decimal, this._PK_LU_Power_Service);

            if (string.IsNullOrEmpty(this._Fld_Desc))
                db.AddInParameter(dbCommand, "Fld_Desc", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Fld_Desc", DbType.String, this._Fld_Desc);

            if (string.IsNullOrEmpty(this._Active))
                db.AddInParameter(dbCommand, "Active", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Active", DbType.String, this._Active);

            return Convert.ToInt32(db.ExecuteScalar(dbCommand));
        }

        /// <summary>
        /// Deletes a record from the LU_Power_Service table by a composite primary key.
        /// </summary>
        public static void DeleteByPK(decimal pK_LU_Power_Service)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_Power_ServiceDeleteByPK");

            db.AddInParameter(dbCommand, "PK_LU_Power_Service", DbType.Decimal, pK_LU_Power_Service);

            db.ExecuteNonQuery(dbCommand);
        }
    }
}
