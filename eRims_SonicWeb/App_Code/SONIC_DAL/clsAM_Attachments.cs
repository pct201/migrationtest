using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
    /// <summary>
    /// Data access class for AM_Attachments table.
    /// </summary>
    public sealed class clsAM_Attachments
    {

        #region Private variables used to hold the property values

        private decimal? _PK_AM_Attachments;
        private decimal? _FK_LU_Location;
        private decimal? _Attachment_Type;
        private string _Attachment_Description;
        private string _Attachment_Filename;
        private DateTime? _Attach_Date;
        private string _Updated_By;
        private DateTime? _Updated_Date;

        #endregion

        #region Public Property

        /// <summary>
        /// Gets or sets the PK_AM_Attachments value.
        /// </summary>
        public decimal? PK_AM_Attachments
        {
            get { return _PK_AM_Attachments; }
            set { _PK_AM_Attachments = value; }
        }

        /// <summary>
        /// Gets or sets the FK_LU_Location value.
        /// </summary>
        public decimal? FK_LU_Location
        {
            get { return _FK_LU_Location; }
            set { _FK_LU_Location = value; }
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
        /// Gets or sets the Updated_Date value.
        /// </summary>
        public DateTime? Updated_Date
        {
            get { return _Updated_Date; }
            set { _Updated_Date = value; }
        }


        #endregion

        #region Default Constructors

        /// <summary>
        /// Initializes a new instance of the clsAM_Attachments class with default value.
        /// </summary>
        public clsAM_Attachments()
        {


        }

        #endregion

        #region Primary Constructors

        /// <summary>
        /// Initializes a new instance of the clsAM_Attachments class based on Primary Key.
        /// </summary>
        public clsAM_Attachments(decimal pK_AM_Attachments)
        {
            DataTable dtAM_Attachments = SelectByPK(pK_AM_Attachments).Tables[0];

            if (dtAM_Attachments.Rows.Count == 1)
            {
                SetValue(dtAM_Attachments.Rows[0]);

            }

        }


        /// <summary>
        /// Initializes a new instance of the clsAM_Attachments class based on Datarow passed.
        /// </summary>
        private void SetValue(DataRow drAM_Attachments)
        {
            if (drAM_Attachments["PK_AM_Attachments"] == DBNull.Value)
                this._PK_AM_Attachments = null;
            else
                this._PK_AM_Attachments = (decimal?)drAM_Attachments["PK_AM_Attachments"];

            if (drAM_Attachments["FK_LU_Location"] == DBNull.Value)
                this._FK_LU_Location = null;
            else
                this._FK_LU_Location = (decimal?)drAM_Attachments["FK_LU_Location"];

            if (drAM_Attachments["Attachment_Type"] == DBNull.Value)
                this._Attachment_Type = null;
            else
                this._Attachment_Type = (decimal?)drAM_Attachments["Attachment_Type"];

            if (drAM_Attachments["Attachment_Description"] == DBNull.Value)
                this._Attachment_Description = null;
            else
                this._Attachment_Description = (string)drAM_Attachments["Attachment_Description"];

            if (drAM_Attachments["Attachment_Filename"] == DBNull.Value)
                this._Attachment_Filename = null;
            else
                this._Attachment_Filename = (string)drAM_Attachments["Attachment_Filename"];

            if (drAM_Attachments["Attach_Date"] == DBNull.Value)
                this._Attach_Date = null;
            else
                this._Attach_Date = (DateTime?)drAM_Attachments["Attach_Date"];

            if (drAM_Attachments["Updated_By"] == DBNull.Value)
                this._Updated_By = null;
            else
                this._Updated_By = (string)drAM_Attachments["Updated_By"];

            if (drAM_Attachments["Updated_Date"] == DBNull.Value)
                this._Updated_Date = null;
            else
                this._Updated_Date = (DateTime?)drAM_Attachments["Updated_Date"];


        }

        #endregion

        /// <summary>
        /// Inserts a record into the AM_Attachments table.
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("AM_AttachmentsInsert");


            db.AddInParameter(dbCommand, "FK_LU_Location", DbType.Decimal, this._FK_LU_Location);

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

            db.AddInParameter(dbCommand, "Updated_Date", DbType.DateTime, this._Updated_Date);

            // Execute the query and return the new identity value
            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
        }

        /// <summary>
        /// Selects a single record from the AM_Attachments table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        private DataSet SelectByPK(decimal pK_AM_Attachments)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("AM_AttachmentsSelectByPK");

            db.AddInParameter(dbCommand, "PK_AM_Attachments", DbType.Decimal, pK_AM_Attachments);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the AM_Attachments table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("AM_AttachmentsSelectAll");

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Updates a record in the AM_Attachments table.
        /// </summary>
        public void Update()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("AM_AttachmentsUpdate");


            db.AddInParameter(dbCommand, "PK_AM_Attachments", DbType.Decimal, this._PK_AM_Attachments);

            db.AddInParameter(dbCommand, "FK_LU_Location", DbType.Decimal, this._FK_LU_Location);

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

            db.AddInParameter(dbCommand, "Updated_Date", DbType.DateTime, this._Updated_Date);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Deletes a record from the AM_Attachments table by a composite primary key.
        /// </summary>
        public static void DeleteByPK(decimal pK_AM_Attachments)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("AM_AttachmentsDeleteByPK");

            db.AddInParameter(dbCommand, "PK_AM_Attachments", DbType.Decimal, pK_AM_Attachments);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Selects all records from the AM_Attachments table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet GetAttchmentFolderAndCount(decimal FK_LU_Location)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("AM_AttachmentsFolderAndCount");

            db.AddInParameter(dbCommand, "FK_LU_Location", DbType.Decimal, FK_LU_Location);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects a single record from the AM_Attachments table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectFilesByAttachmentType(string FK_Attachment_Type, decimal FK_LU_Location)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("AM_AttachmentsSelectByAttachmentType");

            db.AddInParameter(dbCommand, "FK_Attachment_Type", DbType.String, FK_Attachment_Type);
            db.AddInParameter(dbCommand, "FK_LU_Location", DbType.Decimal, FK_LU_Location);

            return db.ExecuteDataSet(dbCommand);
        }
    }
}
