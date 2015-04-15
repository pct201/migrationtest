using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
    /// <summary>
    /// Data access class for LU_FC_Document_Folder_Rights table.
    /// </summary>
    public sealed class clsLU_FC_Document_Folder_Rights
    {

        #region Private variables used to hold the property values

        private decimal? _PK_LU_FC_Document_Folder_Rights;
        private decimal? _FK_LU_FC_Document_Folder;
        private string _Right_Name;
        private decimal? _RightType_ID;

        #endregion

        #region Public Property

        /// <summary>
        /// Gets or sets the PK_LU_FC_Document_Folder_Rights value.
        /// </summary>
        public decimal? PK_LU_FC_Document_Folder_Rights
        {
            get { return _PK_LU_FC_Document_Folder_Rights; }
            set { _PK_LU_FC_Document_Folder_Rights = value; }
        }

        /// <summary>
        /// Gets or sets the FK_LU_FC_Document_Folder value.
        /// </summary>
        public decimal? FK_LU_FC_Document_Folder
        {
            get { return _FK_LU_FC_Document_Folder; }
            set { _FK_LU_FC_Document_Folder = value; }
        }

        /// <summary>
        /// Gets or sets the Right_Name value.
        /// </summary>
        public string Right_Name
        {
            get { return _Right_Name; }
            set { _Right_Name = value; }
        }

        /// <summary>
        /// Gets or sets the RightType_ID value.
        /// </summary>
        public decimal? RightType_ID
        {
            get { return _RightType_ID; }
            set { _RightType_ID = value; }
        }


        #endregion

        #region Default Constructors

        /// <summary>
        /// Initializes a new instance of the clsLU_FC_Document_Folder_Rights class with default value.
        /// </summary>
        public clsLU_FC_Document_Folder_Rights()
        {


        }

        #endregion

        #region Primary Constructors

        /// <summary>
        /// Initializes a new instance of the clsLU_FC_Document_Folder_Rights class based on Primary Key.
        /// </summary>
        public clsLU_FC_Document_Folder_Rights(decimal pK_LU_FC_Document_Folder_Rights)
        {
            DataTable dtLU_FC_Document_Folder_Rights = SelectByPK(pK_LU_FC_Document_Folder_Rights).Tables[0];

            if (dtLU_FC_Document_Folder_Rights.Rows.Count == 1)
            {
                SetValue(dtLU_FC_Document_Folder_Rights.Rows[0]);

            }

        }


        /// <summary>
        /// Initializes a new instance of the clsLU_FC_Document_Folder_Rights class based on Datarow passed.
        /// </summary>
        private void SetValue(DataRow drLU_FC_Document_Folder_Rights)
        {
            if (drLU_FC_Document_Folder_Rights["PK_LU_FC_Document_Folder_Rights"] == DBNull.Value)
                this._PK_LU_FC_Document_Folder_Rights = null;
            else
                this._PK_LU_FC_Document_Folder_Rights = (decimal?)drLU_FC_Document_Folder_Rights["PK_LU_FC_Document_Folder_Rights"];

            if (drLU_FC_Document_Folder_Rights["FK_LU_FC_Document_Folder"] == DBNull.Value)
                this._FK_LU_FC_Document_Folder = null;
            else
                this._FK_LU_FC_Document_Folder = (decimal?)drLU_FC_Document_Folder_Rights["FK_LU_FC_Document_Folder"];

            if (drLU_FC_Document_Folder_Rights["Right_Name"] == DBNull.Value)
                this._Right_Name = null;
            else
                this._Right_Name = (string)drLU_FC_Document_Folder_Rights["Right_Name"];

            if (drLU_FC_Document_Folder_Rights["RightType_ID"] == DBNull.Value)
                this._RightType_ID = null;
            else
                this._RightType_ID = (decimal?)drLU_FC_Document_Folder_Rights["RightType_ID"];


        }

        #endregion

        /// <summary>
        /// Inserts a record into the Document_Folder_Rights table.
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_FC_Document_Folder_RightsInsert");


            db.AddInParameter(dbCommand, "FK_LU_FC_Document_Folder", DbType.Decimal, this._FK_LU_FC_Document_Folder);

            // Execute the query and return the new identity value
            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
        }

        public static void DeleteByFK(decimal FK_LU_FC_Document_Folder)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_FC_Document_Folder_RightsDeleteByFK");

            db.AddInParameter(dbCommand, "FK_LU_FC_Document_Folder", DbType.Decimal, FK_LU_FC_Document_Folder);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Selects a single record from the LU_FC_Document_Folder_Rights table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        private DataSet SelectByPK(decimal pK_LU_FC_Document_Folder_Rights)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_FC_Document_Folder_RightsSelectByPK");

            db.AddInParameter(dbCommand, "PK_LU_FC_Document_Folder_Rights", DbType.Decimal, pK_LU_FC_Document_Folder_Rights);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Select all record from the LU_FC_Document_Folder_Rights table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_FC_Document_Folder_RightsSelectAll");

            return db.ExecuteDataSet(dbCommand);
        }
    }
}
