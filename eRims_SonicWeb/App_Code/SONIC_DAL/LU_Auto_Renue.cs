using System;
using System.Data;
using System.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Common;
using System.Data.Common;

namespace ERIMS.DAL
{
    /// <summary>
    /// Data access class for LU_Auto_Renue table.
    /// </summary>
    public sealed class LU_Auto_Renue
    {
        #region Fields
        private decimal _PK_LU_Auto_Renew;
        private string _Fld_Desc;
        #endregion

        #region Properties

        /// <summary> 
        /// Gets or sets the LU_Auto_Renue value.
        /// </summary>
        public decimal PK_LU_Auto_Renew
        {
            get { return _PK_LU_Auto_Renew; }
            set { _PK_LU_Auto_Renew = value; }
        }

        /// <summary> 
        /// Gets or sets the _Fld_Desc value.
        /// </summary>
        public string Fld_Desc
        {
            get { return _Fld_Desc; }
            set { _Fld_Desc = value; }
        }

        #endregion

        #region Constructors

        /// <summary> 
        /// Initializes a new instance of the LU_Location class. with the default value.
        /// </summary>
        public LU_Auto_Renue()
        {
        }

        /// <summary> 
        /// Initializes a new instance of the LU_Auto_Renue class. with the default value.
        /// </summary>
        public LU_Auto_Renue(decimal pK_LU_Auto_Renew)
        {
            DataTable dt = SelectByPk(pK_LU_Auto_Renew);

            if (dt != null && dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                clsGeneral.SetDefaultValuesForDBNull(dr);

                _Fld_Desc = Convert.ToString(dr["Fld_Desc"]);
            }            
        }

        #endregion

        #region Methods

        /// <summary>
        /// Selects all records from the LU_Auto_Renue table by pk.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataTable SelectByPk(decimal pK_LU_Auto_Renew)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_Auto_RenewSelect");
            db.AddInParameter(dbCommand, "pK_LU_Auto_Renew", DbType.Decimal, pK_LU_Auto_Renew);

            return db.ExecuteDataSet(dbCommand).Tables[0];
        }

        /// <summary>
        /// Select all Auto Renue options
        /// </summary>
        /// <returns></returns>
        public static DataTable AutoRenewOptionSelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_Auto_RenewSelectAll");

            return db.ExecuteDataSet(dbCommand).Tables[0];
        }


        #endregion
    }
}
