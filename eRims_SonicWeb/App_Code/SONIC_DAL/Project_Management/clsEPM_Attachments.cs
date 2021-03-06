using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
    /// <summary>
    /// Data access class for EPM_Attachments table.
    /// </summary>
    public sealed class clsEPM_Attachments
    {

        #region Private variables used to hold the property values

        private decimal? _PK_EPM_Attachments;
        private decimal? _FK_EPM_Identification;
        private decimal? _Attachment_Type;
        private string _Attachment_Description;
        private string _Attachment_Filename;
        private DateTime? _Attach_Date;
        private string _Updated_By;
        private DateTime? _Update_Date;

        #endregion

        #region Public Property

        /// <summary>
        /// Gets or sets the PK_EPM_Attachments value.
        /// </summary>
        public decimal? PK_EPM_Attachments
        {
            get { return _PK_EPM_Attachments; }
            set { _PK_EPM_Attachments = value; }
        }

        /// <summary>
        /// Gets or sets the FK_EPM_Identification value.
        /// </summary>
        public decimal? FK_EPM_Identification
        {
            get { return _FK_EPM_Identification; }
            set { _FK_EPM_Identification = value; }
        }

        /// <summary>
        /// Gets or sets the Attachment_Type value.
        /// </summary>
        public decimal? Attachment_Type
        {
            get { return _Attachment_Type; }
            set { _Attachment_Type = value; }
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


        #endregion

        #region Default Constructors

        /// <summary>
        /// Initializes a new instance of the clsEPM_Attachments class with default value.
        /// </summary>
        public clsEPM_Attachments()
        {


        }

        #endregion

        #region Primary Constructors

        /// <summary>
        /// Initializes a new instance of the clsEPM_Attachments class based on Primary Key.
        /// </summary>
        public clsEPM_Attachments(decimal pK_EPM_Attachments)
        {
            DataTable dtEPM_Attachments = SelectByPK(pK_EPM_Attachments).Tables[0];

            if (dtEPM_Attachments.Rows.Count == 1)
            {
                SetValue(dtEPM_Attachments.Rows[0]);

            }

        }


        /// <summary>
        /// Initializes a new instance of the clsEPM_Attachments class based on Datarow passed.
        /// </summary>
        private void SetValue(DataRow drEPM_Attachments)
        {
            if (drEPM_Attachments["PK_EPM_Attachments"] == DBNull.Value)
                this._PK_EPM_Attachments = null;
            else
                this._PK_EPM_Attachments = (decimal?)drEPM_Attachments["PK_EPM_Attachments"];

            if (drEPM_Attachments["FK_EPM_Identification"] == DBNull.Value)
                this._FK_EPM_Identification = null;
            else
                this._FK_EPM_Identification = (decimal?)drEPM_Attachments["FK_EPM_Identification"];

            if (drEPM_Attachments["Attachment_Type"] == DBNull.Value)
                this._Attachment_Type = null;
            else
                this._Attachment_Type = (decimal?)drEPM_Attachments["Attachment_Type"];

            if (drEPM_Attachments["Attachment_Description"] == DBNull.Value)
                this._Attachment_Description = null;
            else
                this._Attachment_Description = (string)drEPM_Attachments["Attachment_Description"];

            if (drEPM_Attachments["Attachment_Filename"] == DBNull.Value)
                this._Attachment_Filename = null;
            else
                this._Attachment_Filename = (string)drEPM_Attachments["Attachment_Filename"];

            if (drEPM_Attachments["Attach_Date"] == DBNull.Value)
                this._Attach_Date = null;
            else
                this._Attach_Date = (DateTime?)drEPM_Attachments["Attach_Date"];

            if (drEPM_Attachments["Updated_By"] == DBNull.Value)
                this._Updated_By = null;
            else
                this._Updated_By = (string)drEPM_Attachments["Updated_By"];

            if (drEPM_Attachments["Update_Date"] == DBNull.Value)
                this._Update_Date = null;
            else
                this._Update_Date = (DateTime?)drEPM_Attachments["Update_Date"];


        }

        #endregion

        /// <summary>
        /// Inserts a record into the EPM_Attachments table.
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("EPM_AttachmentsInsert");


            db.AddInParameter(dbCommand, "FK_EPM_Identification", DbType.Decimal, this._FK_EPM_Identification);

            db.AddInParameter(dbCommand, "Attachment_Type", DbType.Decimal, this._Attachment_Type);

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

            // Execute the query and return the new identity value
            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
        }

        /// <summary>
        /// Selects a single record from the EPM_Attachments table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        private DataSet SelectByPK(decimal pK_EPM_Attachments)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("EPM_AttachmentsSelectByPK");

            db.AddInParameter(dbCommand, "PK_EPM_Attachments", DbType.Decimal, pK_EPM_Attachments);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the EPM_Attachments table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("EPM_AttachmentsSelectAll");

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Updates a record in the EPM_Attachments table.
        /// </summary>
        public void Update()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("EPM_AttachmentsUpdate");


            db.AddInParameter(dbCommand, "PK_EPM_Attachments", DbType.Decimal, this._PK_EPM_Attachments);

            db.AddInParameter(dbCommand, "FK_EPM_Identification", DbType.Decimal, this._FK_EPM_Identification);

            db.AddInParameter(dbCommand, "Attachment_Type", DbType.Decimal, this._Attachment_Type);

            if (string.IsNullOrEmpty(this._Attachment_Description))
                db.AddInParameter(dbCommand, "Attachment_Description", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Attachment_Description", DbType.String, this._Attachment_Description);

            if (string.IsNullOrEmpty(this._Attachment_Filename))
                db.AddInParameter(dbCommand, "Attachment_Filename", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Attachment_Filename", DbType.String, this._Attachment_Filename);

            if (string.IsNullOrEmpty(this._Updated_By))
                db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);

            db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Deletes a record from the EPM_Attachments table by a composite primary key.
        /// </summary>
        public static void DeleteByPK(decimal pK_EPM_Attachments)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("EPM_AttachmentsDeleteByPK");

            db.AddInParameter(dbCommand, "PK_EPM_Attachments", DbType.Decimal, pK_EPM_Attachments);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Selects all records from the EPM_Attachments table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet GetAttchmentFolderAndCount(decimal PK_EPM_Identification)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("EPM_AttachmentsFolderAndCount");

            db.AddInParameter(dbCommand, "PK_EPM_Identification", DbType.Decimal, PK_EPM_Identification);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects a single record from the EPM_Attachments table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectFilesByAttachmentType(string FK_Attachment_Type, decimal FK_EPM_Identification)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("EPM_AttachmentsSelectByAttachmentType");

            db.AddInParameter(dbCommand, "FK_Attachment_Type", DbType.String, FK_Attachment_Type);
            db.AddInParameter(dbCommand, "FK_EPM_Identification", DbType.Decimal, FK_EPM_Identification);

            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet GetAttchmentsByID(string PK_EPM_Attachments)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("EPM_AttachmentsByAttachmentID");

            db.AddInParameter(dbCommand, "PK_EPM_Attachments", DbType.String, PK_EPM_Attachments);

            return db.ExecuteDataSet(dbCommand);
        }
    }
}
