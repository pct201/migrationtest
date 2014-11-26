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
    public sealed class LU_LR_Type
    {
        #region Fields
        private decimal _PK_LU_LR_Type;
        private string _Fld_Desc;
        #endregion


        #region Properties

        /// <summary> 
        /// Gets or sets the _PK_LU_LR_Type value.
        /// </summary>
        public decimal PK_LU_LR_Type
        {
            get { return _PK_LU_LR_Type; }
            set { _PK_LU_LR_Type = value; }
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
        public LU_LR_Type()
        {
        }

        /// <summary> 
        /// Initializes a new instance of the LU_Location class. with the default value.
        /// </summary>
        public LU_LR_Type(decimal pK_LU_LR_Type)
        {
            DataTable dt = SelectByPk(pK_LU_LR_Type);

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
        /// Selects all records from the LU_LR_TYPE table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_LR_TypeSelectAll");

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the LU_LR_TYPE table by pk.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataTable SelectByPk(decimal pK_LU_LR_Type)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_LR_TypeSelect");
            db.AddInParameter(dbCommand, "pK_LU_LR_Type", DbType.Decimal, pK_LU_LR_Type);

            return db.ExecuteDataSet(dbCommand).Tables[0];
        }


        #endregion
    }
}
