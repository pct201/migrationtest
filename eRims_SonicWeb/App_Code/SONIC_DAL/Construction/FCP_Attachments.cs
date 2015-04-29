using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
    /// <summary>
    /// Data access class for table FCP_Attachments
    /// </summary>
    public sealed class FCP_Attachments
    {

        #region Private variables used to hold the property values

        private decimal? _PK_FCP_Attachments;
        private decimal? _FK_FCP_Identification;
        private decimal? _PK_LU_FC_Document_Folder;
        private string _Attachment_Description;
        private string _Attachment_Filename;
        private DateTime? _Attach_Date;
        private string _Updated_By;
        private DateTime? _Update_Date;
        private string _Updated_By_Table;

        #endregion

        #region Public Property

        /// <summary>
        /// Gets or sets the PK_FCP_Attachments value.
        /// </summary>
        public decimal? PK_FCP_Attachments
        {
            get { return _PK_FCP_Attachments; }
            set { _PK_FCP_Attachments = value; }
        }

        /// <summary>
        /// Gets or sets the FK_FCP_Identification value.
        /// </summary>
        public decimal? FK_FCP_Identification
        {
            get { return _FK_FCP_Identification; }
            set { _FK_FCP_Identification = value; }
        }

        /// <summary>
        /// Gets or sets the Attachment_Type value.
        /// </summary>
        public decimal? PK_LU_FC_Document_Folder
        {
            get { return _PK_LU_FC_Document_Folder; }
            set { _PK_LU_FC_Document_Folder = value; }
        }

        /// <summary>
        /// Gets or sets the Attachment_Description value.
        /// </summary>
        public string Attachment_Description
        {
            get { return _Attachment_Description; }
            set { _Attachment_Description = value; }
        }

        /// <summary>
        /// Gets or sets the Attachment_Filename value.
        /// </summary>
        public string Attachment_Filename
        {
            get { return _Attachment_Filename; }
            set { _Attachment_Filename = value; }
        }

        /// <summary>
        /// Gets or sets the Attach_Date value.
        /// </summary>
        public DateTime? Attach_Date
        {
            get { return _Attach_Date; }
            set { _Attach_Date = value; }
        }

        /// <summary>
        /// Gets or sets the Updated_By value.
        /// </summary>
        public string Updated_By
        {
            get { return _Updated_By; }
            set { _Updated_By = value; }
        }

        /// <summary>
        /// Gets or sets the Update_Date value.
        /// </summary>
        public DateTime? Update_Date
        {
            get { return _Update_Date; }
            set { _Update_Date = value; }
        }

        /// <summary>
        /// Gets or Sets Updated_By_Table Value
        /// </summary>
        public string Updated_By_Table
        {
            get { return _Updated_By_Table; }
            set { _Updated_By_Table = value; }
        }

        #endregion

        #region Default Constructors

        /// <summary>
        /// Initializes a new instance of the FCP_Attachments class with default value.
        /// </summary>
        public FCP_Attachments()
        {


        }

        #endregion

        #region Primary Constructors

        /// <summary>
        /// Initializes a new instance of the FCP_Attachments class based on Primary Key.
        /// </summary>
        public FCP_Attachments(decimal pK_FCP_Attachments)
        {
            DataTable dtFCP_Attachments = Select(pK_FCP_Attachments).Tables[0];

            if (dtFCP_Attachments.Rows.Count == 1)
            {
                SetValue(dtFCP_Attachments.Rows[0]);

            }

        }


        /// <summary>
        /// Initializes a new instance of the FCP_Attachments class based on Datarow passed.
        /// </summary>
        private void SetValue(DataRow drFCP_Attachments)
        {
            if (drFCP_Attachments["PK_FCP_Attachments"] == DBNull.Value)
                this._PK_FCP_Attachments = null;
            else
                this._PK_FCP_Attachments = (decimal?)drFCP_Attachments["PK_FCP_Attachments"];

            if (drFCP_Attachments["FK_FCP_Identification"] == DBNull.Value)
                this._FK_FCP_Identification = null;
            else
                this._FK_FCP_Identification = (decimal?)drFCP_Attachments["FK_FCP_Identification"];

            if (drFCP_Attachments["PK_LU_FC_Document_Folder"] == DBNull.Value)
                this._PK_LU_FC_Document_Folder = null;
            else
                this._PK_LU_FC_Document_Folder = (decimal?)drFCP_Attachments["PK_LU_FC_Document_Folder"];

            if (drFCP_Attachments["Attachment_Description"] == DBNull.Value)
                this._Attachment_Description = null;
            else
                this._Attachment_Description = (string)drFCP_Attachments["Attachment_Description"];

            if (drFCP_Attachments["Attachment_Filename"] == DBNull.Value)
                this._Attachment_Filename = null;
            else
                this._Attachment_Filename = (string)drFCP_Attachments["Attachment_Filename"];

            if (drFCP_Attachments["Attach_Date"] == DBNull.Value)
                this._Attach_Date = null;
            else
                this._Attach_Date = (DateTime?)drFCP_Attachments["Attach_Date"];

            if (drFCP_Attachments["Updated_By"] == DBNull.Value)
                this._Updated_By = null;
            else
                this._Updated_By = (string)drFCP_Attachments["Updated_By"];

            if (drFCP_Attachments["Update_Date"] == DBNull.Value)
                this._Update_Date = null;
            else
                this._Update_Date = (DateTime?)drFCP_Attachments["Update_Date"];

            if (drFCP_Attachments["Updated_By_Table"] == DBNull.Value)
                this._Updated_By_Table = null;
            else
                this._Updated_By_Table = (string)drFCP_Attachments["Updated_By_Table"];

        }

        #endregion

        /// <summary>
        /// Inserts a record into the FCP_Attachments table.
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("FCP_AttachmentsInsert");


            db.AddInParameter(dbCommand, "FK_FCP_Identification", DbType.Decimal, this._FK_FCP_Identification);

            db.AddInParameter(dbCommand, "PK_LU_FC_Document_Folder", DbType.Decimal, this._PK_LU_FC_Document_Folder);

            if (string.IsNullOrEmpty(this._Attachment_Description))
                db.AddInParameter(dbCommand, "Attachment_Description", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Attachment_Description", DbType.String, this._Attachment_Description);

            if (string.IsNullOrEmpty(this._Attachment_Filename))
                db.AddInParameter(dbCommand, "Attachment_Filename", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Attachment_Filename", DbType.String, this._Attachment_Filename);

            db.AddInParameter(dbCommand, "Attach_Date", DbType.DateTime, this._Attach_Date);

            if (string.IsNullOrEmpty(this._Updated_By))
                db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);

            db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);

            if (string.IsNullOrEmpty(this._Updated_By_Table))
                db.AddInParameter(dbCommand, "Updated_By_Table", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Updated_By_Table", DbType.String, this._Updated_By_Table);

            // Execute the query and return the new identity value
            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
        }

        /// <summary>
        /// Selects a single record from the FCP_Attachments table.
        /// </summary>
        /// <returns>DataSet</returns>
        private DataSet Select(decimal pK_FCP_Attachments)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("FCP_AttachmentsSelect");

            db.AddInParameter(dbCommand, "PK_FCP_Attachments", DbType.Decimal, pK_FCP_Attachments);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the FCP_Attachments table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("FCP_AttachmentsSelectAll");

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Updates a record in the FCP_Attachments table.
        /// </summary>
        public void Update()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("FCP_AttachmentsUpdate");


            db.AddInParameter(dbCommand, "PK_FCP_Attachments", DbType.Decimal, this._PK_FCP_Attachments);

            db.AddInParameter(dbCommand, "FK_FCP_Identification", DbType.Decimal, this._FK_FCP_Identification);

            db.AddInParameter(dbCommand, "PK_LU_FC_Document_Folder", DbType.Decimal, this._PK_LU_FC_Document_Folder);

            if (string.IsNullOrEmpty(this._Attachment_Description))
                db.AddInParameter(dbCommand, "Attachment_Description", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Attachment_Description", DbType.String, this._Attachment_Description);

            if (string.IsNullOrEmpty(this._Attachment_Filename))
                db.AddInParameter(dbCommand, "Attachment_Filename", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Attachment_Filename", DbType.String, this._Attachment_Filename);

            db.AddInParameter(dbCommand, "Attach_Date", DbType.DateTime, this._Attach_Date);

            if (string.IsNullOrEmpty(this._Updated_By))
                db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);

            db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);

            if (string.IsNullOrEmpty(this._Updated_By_Table))
                db.AddInParameter(dbCommand, "Updated_By_Table", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Updated_By_Table", DbType.String, this._Updated_By_Table);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Deletes a record from the FCP_Attachments table by a composite primary key.
        /// </summary>
        public static void Delete(decimal pK_FCP_Attachments)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("FCP_AttachmentsDelete");

            db.AddInParameter(dbCommand, "PK_FCP_Attachments", DbType.Decimal, pK_FCP_Attachments);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Selects all records from the FCP_Attachments table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet GetAttchmentFolderAndCount(decimal PK_FCP_Identification, decimal fK_User_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("FCP_AttachmentsFolderAndCount");

            db.AddInParameter(dbCommand, "PK_FCP_Identification", DbType.Decimal, PK_FCP_Identification);
            db.AddInParameter(dbCommand, "FK_User_ID", DbType.Decimal, fK_User_ID);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects a single record from the EPM_Attachments table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectFilesByAttachmentType(string FK_Attachment_Type, decimal FK_FCP_Identification)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("FCP_AttachmentsSelectByAttachmentType");

            db.AddInParameter(dbCommand, "FK_Attachment_Type", DbType.String, FK_Attachment_Type);
            db.AddInParameter(dbCommand, "FK_FCP_Identification", DbType.Decimal, FK_FCP_Identification);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects a single record from the EPM_Attachments table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectFilesByAttachmentTypeAndSecurityID(string FK_Attachment_Type, decimal FK_FCP_Identification)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("FCP_AttachmentsSelectByAttachmentTypeAndSecurityID");

            db.AddInParameter(dbCommand, "FK_Attachment_Type", DbType.String, FK_Attachment_Type);
            db.AddInParameter(dbCommand, "FK_FCP_Identification", DbType.Decimal, FK_FCP_Identification);
            db.AddInParameter(dbCommand, "SecurityID", DbType.Decimal, Convert.ToDecimal(clsSession.UserID));

            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet GetAttchmentsByID(string PK_FCP_Attachments)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("FCP_AttachmentsByAttachmentID");

            db.AddInParameter(dbCommand, "PK_FCP_Attachments", DbType.String, PK_FCP_Attachments);

            return db.ExecuteDataSet(dbCommand);
        }
    }
}
