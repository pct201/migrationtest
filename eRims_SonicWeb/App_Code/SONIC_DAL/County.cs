using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
    /// <summary>
    /// Data access class for County table.
    /// </summary>
    public sealed class County
    {

        #region Private variables used to hold the property values

        private decimal? _PK_ID;
        private string _FLD_county;
        private string _FLD_code;
        private string _FLD_state;

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
        /// Gets or sets the FLD_county value.
        /// </summary>
        public string FLD_county
        {
            get { return _FLD_county; }
            set { _FLD_county = value; }
        }

        /// <summary>
        /// Gets or sets the FLD_code value.
        /// </summary>
        public string FLD_code
        {
            get { return _FLD_code; }
            set { _FLD_code = value; }
        }

        /// <summary>
        /// Gets or sets the FLD_state value.
        /// </summary>
        public string FLD_state
        {
            get { return _FLD_state; }
            set { _FLD_state = value; }
        }


        #endregion

        #region Default Constructors

        /// <summary>
        /// Initializes a new instance of the County class with default value.
        /// </summary>
        public County()
        {

            this._PK_ID = null;
            this._FLD_county = null;
            this._FLD_code = null;
            this._FLD_state = null;

        }

        #endregion

        #region Primary Constructors

        /// <summary>
        /// Initializes a new instance of the County class based on Primary Key.
        /// </summary>
        public County(decimal pK_ID)
        {
            DataTable dtCounty = SelectByPK(pK_ID).Tables[0];

            if (dtCounty.Rows.Count == 1)
            {
                DataRow drCounty = dtCounty.Rows[0];
                if (drCounty["PK_ID"] == DBNull.Value)
                    this._PK_ID = null;
                else
                    this._PK_ID = (decimal?)drCounty["PK_ID"];

                if (drCounty["FLD_county"] == DBNull.Value)
                    this._FLD_county = null;
                else
                    this._FLD_county = (string)drCounty["FLD_county"];

                if (drCounty["FLD_code"] == DBNull.Value)
                    this._FLD_code = null;
                else
                    this._FLD_code = (string)drCounty["FLD_code"];

                if (drCounty["FLD_state"] == DBNull.Value)
                    this._FLD_state = null;
                else
                    this._FLD_state = (string)drCounty["FLD_state"];

            }
            else
            {
                this._PK_ID = null;
                this._FLD_county = null;
                this._FLD_code = null;
                this._FLD_state = null;
            }

        }

        #endregion

        /// <summary>
        /// Selects a single record from the County table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        private static DataSet SelectByPK(decimal pK_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("CountySelectByPK");

            db.AddInParameter(dbCommand, "PK_ID", DbType.Decimal, pK_ID);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the County table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("CountySelectAll");

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the County table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAllByState(string strState)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("CountySelectAllByState");

            db.AddInParameter(dbCommand, "State", DbType.String, strState);

            return db.ExecuteDataSet(dbCommand);
        }
    }
}
