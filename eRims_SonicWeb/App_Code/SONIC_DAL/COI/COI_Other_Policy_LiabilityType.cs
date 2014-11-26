using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
    /// <summary>
    /// Summary description for COI_Other_Policy_LiabilityType
    /// </summary>
    public class COI_Other_Policy_LiabilityType
    {
        #region Fields

        private decimal _PK_Other_Policy_Types;
        private string _Fld_Desc;

        #endregion

        #region Property

        /// <summary> 
        /// Gets or sets the PK_Other_Policy_Types.
        /// </summary>
        public decimal PK_Other_Policy_Types
        {
            get { return _PK_Other_Policy_Types; }
            set { _PK_Other_Policy_Types = value; }
        }
        /// <summary> 
        /// Gets or sets the Fld_Desc.
        /// </summary>
        public string Fld_Desc
        {
            get { return _Fld_Desc; }
            set { _Fld_Desc = value; }
        }
        #endregion

        #region Constructors
        public COI_Other_Policy_LiabilityType()
        {
            this._PK_Other_Policy_Types = -1;
            this._Fld_Desc = "";
        }
        /// <summary> 
        /// Initializes a new instance of the COI_Other_Policy_Types class for passed PrimaryKey with the values set from Database.
        /// </summary> 
        public COI_Other_Policy_LiabilityType(decimal PK)
        {
            DataTable dtCOI_Other_Policy_Types = SelectByPK(PK).Tables[0];

            if (dtCOI_Other_Policy_Types.Rows.Count > 0)
            {

                DataRow drCOI_Other_Policy_Types = dtCOI_Other_Policy_Types.Rows[0];
                this._PK_Other_Policy_Types = drCOI_Other_Policy_Types["PK_Other_Policy_Types"] != DBNull.Value ? Convert.ToDecimal(drCOI_Other_Policy_Types["PK_Other_Policy_Types"]) : 0;
                this._Fld_Desc = Convert.ToString(drCOI_Other_Policy_Types["Fld_Desc"]);
            }

            else
            {
                this._PK_Other_Policy_Types = -1;
                this._Fld_Desc = "";
            }

        }

        #endregion

        #region Methods

        /// <summary>
        /// Selects all records from the COI_Other_Policy_Types table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("COI_Other_Policy_TypesSelectAll");

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the COI_Other_Policy_Types table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectByPK(decimal PK_Other_Policy_Types)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("COI_Other_Policy_TypesSelectByPK");

            db.AddInParameter(dbCommand, "PK_Other_Policy_Types", DbType.String, PK_Other_Policy_Types);
            return db.ExecuteDataSet(dbCommand);
        }

        public void Insert()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("COI_Other_Policy_TypesInsert");

            db.AddInParameter(dbCommand, "Fld_Desc", DbType.String, Fld_Desc);
            db.ExecuteDataSet(dbCommand);
        }

        public void Update()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("COI_Other_Policy_TypesUpdate");

            db.AddInParameter(dbCommand, "PK_Other_Policy_Types", DbType.String, PK_Other_Policy_Types);
            db.AddInParameter(dbCommand, "Fld_Desc", DbType.String, Fld_Desc);
            db.ExecuteDataSet(dbCommand);
        }
        public void Delete()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("COI_Other_Policy_TypesDelete");

            db.AddInParameter(dbCommand, "PK_Other_Policy_Types", DbType.String, PK_Other_Policy_Types);
            db.ExecuteDataSet(dbCommand);
        }

        public static DataSet SelectByPaging(int intPageNo, int intPageSize, string strFld_Desc, string strOrderBy, string strOrder)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("COI_Other_Policy_TypesSelectAllByPaging");

            db.AddInParameter(dbCommand, "intPageNo", DbType.Int32, intPageNo);
            db.AddInParameter(dbCommand, "intPageSize", DbType.Int32, intPageSize);
            db.AddInParameter(dbCommand, "strFld_Desc", DbType.String, strFld_Desc);
            db.AddInParameter(dbCommand, "strOrderBy", DbType.String, strOrderBy);
            db.AddInParameter(dbCommand, "strOrder", DbType.String, strOrder);
            return db.ExecuteDataSet(dbCommand);
        }
        #endregion
    }
}