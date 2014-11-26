using System;
using System.Data;
using System.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Common;
using System.Data.Common;

namespace ERIMS.DAL
{
    /// <summary>
    /// Data access class for LU_Location table.
    /// </summary>
    public sealed class LU_Service_Contract
    {
        #region Fields
        private decimal pK_LU_Service_Contract;
        private string fld_Desc;
        #endregion


        #region Properties

        /// <summary> 
        /// Gets or sets the _PK_LU_LR_Type value.
        /// </summary>
        public decimal PK_LU_Service_Contract
        {
            get { return pK_LU_Service_Contract; }
            set { pK_LU_Service_Contract = value; }
        }

        /// <summary> 
        /// Gets or sets the _Fld_Desc value.
        /// </summary>
        public string Fld_Desc
        {
            get { return fld_Desc; }
            set { fld_Desc = value; }
        }

        #endregion

        #region Constructors

        /// <summary> 
        /// Initializes a new instance of the LU_Location class. with the default value.
        /// </summary>
        public LU_Service_Contract()
        {
        }

        /// <summary> 
        /// Initializes a new instance of the LU_Service_Contract class. with the default value. with parameter
        /// </summary>
        public LU_Service_Contract(decimal _pK_LU_Service_Contract)
        {
            DataTable dt = SelectByPk(_pK_LU_Service_Contract);

            if (dt != null && dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                clsGeneral.SetDefaultValuesForDBNull(dr);

                fld_Desc = Convert.ToString(dr["Fld_Desc"]);                
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Selects all records from the LU_Service_Contract table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataTable SelectByPk(decimal _pK_LU_Service_Contract)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_Service_ContractSelect");
            db.AddInParameter(dbCommand, "PK_LU_Service_Contract", DbType.Decimal, _pK_LU_Service_Contract);

            return db.ExecuteDataSet(dbCommand).Tables[0];
        }

        /// <summary>
        /// select all service contract level
        /// </summary>
        /// <returns></returns>
        public static DataTable selectAll()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_Service_ContractSelectAll");

            return db.ExecuteDataSet(dbCommand).Tables[0];
        }

        #endregion
    }
}
