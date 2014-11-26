using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Microsoft.Practices.EnterpriseLibrary.Data;

/// <summary>
/// Summary description for Property_ViewClaimInfo
/// </summary>
/// 
namespace ERIMS.DAL
{
    public class Property_ClaimInfo
    {
        public Property_ClaimInfo()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        #region Fields
        private int _PK_Property_FR_ID;
        #endregion

        #region Property
        public int PK_Property_FR_ID
        {
            get
            {
                return _PK_Property_FR_ID;
            }
            set
            {
                _PK_Property_FR_ID = value;
            }
        }
        #endregion

        #region Methods

        public static DataSet SelectByPK(decimal pK_Property_FR_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Property_ViewClaimInfo");

            db.AddInParameter(dbCommand, "PK_Property_FR_ID", DbType.Decimal, pK_Property_FR_ID);

            return db.ExecuteDataSet(dbCommand);
        }

        #endregion
    }
}