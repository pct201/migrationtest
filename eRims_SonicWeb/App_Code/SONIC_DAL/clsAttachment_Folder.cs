using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
    /// <summary>
    /// Data access class for Attachment_Folder table.
    /// </summary>
    public sealed class clsAttachment_Folder
    {

        #region Private variables used to hold the property values

        private decimal? _PK_Attachment_Folder;
        private string _Folder_Name;

        #endregion

        #region Public Property

        /// <summary>
        /// Gets or sets the PK_Attachment_Folder value.
        /// </summary>
        public decimal? PK_Attachment_Folder
        {
            get { return _PK_Attachment_Folder; }
            set { _PK_Attachment_Folder = value; }
        }

        /// <summary>
        /// Gets or sets the Folder_Name value.
        /// </summary>
        public string Folder_Name
        {
            get { return _Folder_Name; }
            set { _Folder_Name = value; }
        }


        #endregion

        #region Default Constructors

        /// <summary>
        /// Initializes a new instance of the clsAttachment_Folder class with default value.
        /// </summary>
        public clsAttachment_Folder()
        {


        }

        #endregion

        #region Primary Constructors

        /// <summary>
        /// Initializes a new instance of the clsAttachment_Folder class based on Primary Key.
        /// </summary>
        public clsAttachment_Folder(decimal pK_Attachment_Folder)
        {
            DataTable dtAttachment_Folder = SelectByPK(pK_Attachment_Folder).Tables[0];

            if (dtAttachment_Folder.Rows.Count == 1)
            {
                SetValue(dtAttachment_Folder.Rows[0]);

            }

        }


        /// <summary>
        /// Initializes a new instance of the clsAttachment_Folder class based on Datarow passed.
        /// </summary>
        private void SetValue(DataRow drAttachment_Folder)
        {
            if (drAttachment_Folder["PK_Attachment_Folder"] == DBNull.Value)
                this._PK_Attachment_Folder = null;
            else
                this._PK_Attachment_Folder = (decimal?)drAttachment_Folder["PK_Attachment_Folder"];

            if (drAttachment_Folder["Folder_Name"] == DBNull.Value)
                this._Folder_Name = null;
            else
                this._Folder_Name = (string)drAttachment_Folder["Folder_Name"];


        }

        #endregion

        /// <summary>
        /// Inserts a record into the Attachment_Folder table.
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Attachment_FolderInsert");


            if (string.IsNullOrEmpty(this._Folder_Name))
                db.AddInParameter(dbCommand, "Folder_Name", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Folder_Name", DbType.String, this._Folder_Name);

            // Execute the query and return the new identity value
            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
        }

        /// <summary>
        /// Selects a single record from the Attachment_Folder table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        private DataSet SelectByPK(decimal pK_Attachment_Folder)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Attachment_FolderSelectByPK");

            db.AddInParameter(dbCommand, "PK_Attachment_Folder", DbType.Decimal, pK_Attachment_Folder);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the Attachment_Folder table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAll(int intPageNo, string strOrderBy, string strOrder, int intPageSize)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Attachment_FolderSelectAll");
            db.AddInParameter(dbCommand, "intPageNo", DbType.Decimal, intPageNo);
            db.AddInParameter(dbCommand, "strOrderBy", DbType.String, strOrderBy);
            db.AddInParameter(dbCommand, "strOrder", DbType.String, strOrder);
            db.AddInParameter(dbCommand, "intPageSize", DbType.Decimal, intPageSize);
            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Updates a record in the Attachment_Folder table.
        /// </summary>
        public void Update()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Attachment_FolderUpdate");


            db.AddInParameter(dbCommand, "PK_Attachment_Folder", DbType.Decimal, this._PK_Attachment_Folder);

            if (string.IsNullOrEmpty(this._Folder_Name))
                db.AddInParameter(dbCommand, "Folder_Name", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Folder_Name", DbType.String, this._Folder_Name);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Deletes a record from the Attachment_Folder table by a composite primary key.
        /// </summary>
        public static void DeleteByPK(decimal pK_Attachment_Folder)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Attachment_FolderDeleteByPK");

            db.AddInParameter(dbCommand, "PK_Attachment_Folder", DbType.Decimal, pK_Attachment_Folder);

            db.ExecuteNonQuery(dbCommand);
        }

        public static int SelectByFolder_Name(string Folder_Name, decimal PK_Attachment_Folder)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Attachment_FolderSelectByFolder_Name");

            db.AddInParameter(dbCommand, "PK_Attachment_Folder", DbType.Decimal, PK_Attachment_Folder);
            db.AddInParameter(dbCommand, "Folder_Name", DbType.String, Folder_Name);

            return Convert.ToInt32(db.ExecuteScalar(dbCommand));
        }
    }
}
