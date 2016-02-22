using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
    /// <summary>
    /// Data access class for Virtual_Folder table.
    /// </summary>
    public sealed class clsVirtual_Folder
    {

        #region Private variables used to hold the property values

        private decimal? _PK_Virtual_Folder;
        private decimal? _FK_Attachment_Folder;
        private string _Major_Coverage;

        #endregion

        #region Public Property

        /// <summary>
        /// Gets or sets the PK_Virtual_Folder value.
        /// </summary>
        public decimal? PK_Virtual_Folder
        {
            get { return _PK_Virtual_Folder; }
            set { _PK_Virtual_Folder = value; }
        }

        /// <summary>
        /// Gets or sets the FK_Attachment_Folder value.
        /// </summary>
        public decimal? FK_Attachment_Folder
        {
            get { return _FK_Attachment_Folder; }
            set { _FK_Attachment_Folder = value; }
        }

        /// <summary>
        /// Gets or sets the Major_Coverage value.
        /// </summary>
        public string Major_Coverage
        {
            get { return _Major_Coverage; }
            set { _Major_Coverage = value; }
        }


        #endregion

        #region Default Constructors

        /// <summary>
        /// Initializes a new instance of the clsVirtual_Folder class with default value.
        /// </summary>
        public clsVirtual_Folder()
        {


        }

        #endregion

        #region Primary Constructors

        /// <summary>
        /// Initializes a new instance of the clsVirtual_Folder class based on Primary Key.
        /// </summary>
        public clsVirtual_Folder(decimal pK_Virtual_Folder)
        {
            DataTable dtVirtual_Folder = SelectByPK(pK_Virtual_Folder).Tables[0];

            if (dtVirtual_Folder.Rows.Count == 1)
            {
                SetValue(dtVirtual_Folder.Rows[0]);

            }

        }


        /// <summary>
        /// Initializes a new instance of the clsVirtual_Folder class based on Datarow passed.
        /// </summary>
        private void SetValue(DataRow drVirtual_Folder)
        {
            if (drVirtual_Folder["PK_Virtual_Folder"] == DBNull.Value)
                this._PK_Virtual_Folder = null;
            else
                this._PK_Virtual_Folder = (decimal?)drVirtual_Folder["PK_Virtual_Folder"];

            if (drVirtual_Folder["FK_Attachment_Folder"] == DBNull.Value)
                this._FK_Attachment_Folder = null;
            else
                this._FK_Attachment_Folder = (decimal?)drVirtual_Folder["FK_Attachment_Folder"];

            if (drVirtual_Folder["Major_Coverage"] == DBNull.Value)
                this._Major_Coverage = null;
            else
                this._Major_Coverage = (string)drVirtual_Folder["Major_Coverage"];


        }

        #endregion

        /// <summary>
        /// Inserts a record into the Virtual_Folder table.
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Virtual_FolderInsert");


            db.AddInParameter(dbCommand, "FK_Attachment_Folder", DbType.Decimal, this._FK_Attachment_Folder);

            if (string.IsNullOrEmpty(this._Major_Coverage))
                db.AddInParameter(dbCommand, "Major_Coverage", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Major_Coverage", DbType.String, this._Major_Coverage);

            // Execute the query and return the new identity value
            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
        }

        /// <summary>
        /// Selects a single record from the Virtual_Folder table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        private DataSet SelectByPK(decimal pK_Virtual_Folder)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Virtual_FolderSelectByPK");

            db.AddInParameter(dbCommand, "PK_Virtual_Folder", DbType.Decimal, pK_Virtual_Folder);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the Virtual_Folder table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Virtual_FolderSelectAll");

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Updates a record in the Virtual_Folder table.
        /// </summary>
        public void Update()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Virtual_FolderUpdate");


            db.AddInParameter(dbCommand, "PK_Virtual_Folder", DbType.Decimal, this._PK_Virtual_Folder);

            db.AddInParameter(dbCommand, "FK_Attachment_Folder", DbType.Decimal, this._FK_Attachment_Folder);

            if (string.IsNullOrEmpty(this._Major_Coverage))
                db.AddInParameter(dbCommand, "Major_Coverage", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Major_Coverage", DbType.String, this._Major_Coverage);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Deletes a record from the Virtual_Folder table by a composite primary key.
        /// </summary>
        public static void DeleteByPK(decimal pK_Virtual_Folder)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Virtual_FolderDeleteByPK");

            db.AddInParameter(dbCommand, "PK_Virtual_Folder", DbType.Decimal, pK_Virtual_Folder);

            db.ExecuteNonQuery(dbCommand);
        }

        public static void DeleteByFK(decimal FK_Attachment_Folder)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Virtual_FolderDeleteByFK");

            db.AddInParameter(dbCommand, "FK_Attachment_Folder", DbType.Decimal, FK_Attachment_Folder);

            db.ExecuteNonQuery(dbCommand);
        }

        public DataSet SelectByFK(decimal FK_Attachment_Folder)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Virtual_FolderSelectByFK");

            db.AddInParameter(dbCommand, "FK_Attachment_Folder", DbType.Decimal, FK_Attachment_Folder);

            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet SelectForAddAttachment(string major_Coverage, string attachment_table, decimal fK_Table, decimal PK_Security_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Virtual_FolderSelectForAddAttachment");

            db.AddInParameter(dbCommand, "Major_Coverage", DbType.String, major_Coverage);
            db.AddInParameter(dbCommand, "FK_Table", DbType.Decimal, fK_Table);
            db.AddInParameter(dbCommand, "Attachment_Table", DbType.String, attachment_table);
            db.AddInParameter(dbCommand, "PK_Security_ID", DbType.Decimal, PK_Security_ID);

            dbCommand.CommandTimeout = 100000;

            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet SelectForClaimAttachment(string major_Coverage, decimal fK_Table)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Virtual_FolderSelectForClaimAttachment");

            db.AddInParameter(dbCommand, "Major_Coverage", DbType.String, major_Coverage);
            db.AddInParameter(dbCommand, "FK_Table", DbType.Decimal, fK_Table);
            dbCommand.CommandTimeout = 100000;

            return db.ExecuteDataSet(dbCommand);
        }

        public int IsValid()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Virtual_FolderIsValid");

            db.AddInParameter(dbCommand, "FK_Attachment_Folder", DbType.Decimal, this._FK_Attachment_Folder);
            db.AddInParameter(dbCommand, "Major_Coverage", DbType.String, this._Major_Coverage);

            return Convert.ToInt32(db.ExecuteScalar(dbCommand));
        }

        public int isExist()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Virtual_FolderIsExist");

            db.AddInParameter(dbCommand, "FK_Attachment_Folder", DbType.Decimal, this._FK_Attachment_Folder);
            db.AddInParameter(dbCommand, "Major_Coverage", DbType.String, this._Major_Coverage);

            return Convert.ToInt32(db.ExecuteScalar(dbCommand));
        }

        public DataSet SelectByObj()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Virtual_FolderSelectByVal");

            db.AddInParameter(dbCommand, "FK_Attachment_Folder", DbType.Decimal, this._FK_Attachment_Folder);
            db.AddInParameter(dbCommand, "Major_Coverage", DbType.String, this._Major_Coverage);

            return db.ExecuteDataSet(dbCommand);
        }

        public static decimal GetPKByFolderName(string strFolderName, string strMajorCoverage)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand("select A.PK_Virtual_Folder from Virtual_Folder A inner join Attachment_Folder B on " +
                "A.FK_Attachment_Folder = B.PK_Attachment_Folder where B.Folder_Name = '" + strFolderName.Replace("'", "''") + "' and Major_Coverage = '" + strMajorCoverage + "'");

            decimal decPK;
            decimal.TryParse(Convert.ToString(db.ExecuteScalar(dbCommand)), out decPK);
            return decPK;
        }

        public static DataSet SelectForAddAttachmentPolicy(string attachment_table, decimal fK_Table, decimal PK_Security_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Virtual_FolderSelectForAddAttachment_Policy");

            db.AddInParameter(dbCommand, "FK_Table", DbType.Decimal, fK_Table);
            db.AddInParameter(dbCommand, "Attachment_Table", DbType.String, attachment_table);
            db.AddInParameter(dbCommand, "PK_Security_ID", DbType.Decimal, PK_Security_ID);

            dbCommand.CommandTimeout = 100000;

            return db.ExecuteDataSet(dbCommand);
        }
    }
}
