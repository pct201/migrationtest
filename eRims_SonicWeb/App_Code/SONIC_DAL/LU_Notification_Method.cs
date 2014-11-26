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
    public sealed class LU_Notification_Method
    {
        #region Fields
        private decimal _PK_LU_Notification_Method;
        private string _Fld_Desc;
        #endregion


        #region Properties

        /// <summary> 
        /// Gets or sets the PK_LU_Notification_Method value.
        /// </summary>
        public decimal PK_LU_Notification_Method
        {
            get { return _PK_LU_Notification_Method; }
            set { _PK_LU_Notification_Method = value; }
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
        /// Initializes a new instance of the LU_Notification_Method class. with the default value.
        /// </summary>
        public LU_Notification_Method()
        {
        }

        /// <summary> 
        /// Initializes a new instance of the LU_Notification_Method class. with the default value.
        /// </summary>
        public LU_Notification_Method(decimal pK_LU_Notification_Method)
        {
            DataTable dt = SelectByPK(pK_LU_Notification_Method);

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
        /// Select all Notification Methods
        /// </summary>
        /// <returns></returns>
        public static DataTable NotificationMethodsSelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_Notification_MethodSelectAll");

            return db.ExecuteDataSet(dbCommand).Tables[0];
        }

        /// <summary>
        /// Select  Notification Methods by PK
        /// </summary>
        /// <returns></returns>
        public static DataTable SelectByPK(decimal pK_LU_Notification_Method)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_Notification_MethodSelect");
            db.AddInParameter(dbCommand, "pK_LU_Notification_Method", DbType.Decimal, pK_LU_Notification_Method);

            return db.ExecuteDataSet(dbCommand).Tables[0];
        }


        #endregion
    }
}
