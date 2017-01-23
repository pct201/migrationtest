using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Collections.Generic;

namespace ERIMS_Sonic_EmailScheduler
{
    /// <summary>
    /// Data access class for Attachment table.
    /// </summary>
    public class Attachment
    {
        #region Private variables used to hold the property values

        private decimal? _PK_Attachment_Id;
        private string _Attachment_Table;
        private decimal? _Foreign_Key;
        private decimal? _FK_Attachment_Type;
        private string _Attachment_Description;
        private string _Attachment_Name;
        private string _Updated_By;
        private string _Attached_By;
        private DateTime? _Update_Date;
        private bool? _IsEmergencyDoc;
        private decimal? _FK_Folder;
        private decimal? _FK_New_Version_Attachment;


        #endregion

        #region Public Property

        /// <summary>
        /// Gets or sets the PK_Attachment_Id value.
        /// </summary>
        public decimal? PK_Attachment_Id
        {
            get { return _PK_Attachment_Id; }
            set { _PK_Attachment_Id = value; }
        }

        /// <summary>
        /// Gets or sets the Attachment_Table value.
        /// </summary>
        public string Attachment_Table
        {
            get { return _Attachment_Table; }
            set { _Attachment_Table = value; }
        }

        /// <summary>
        /// Gets or sets the Foreign_Key value.
        /// </summary>
        public decimal? Foreign_Key
        {
            get { return _Foreign_Key; }
            set { _Foreign_Key = value; }
        }

        /// <summary>
        /// Gets or sets the FK_Attachment_Type value.
        /// </summary>
        public decimal? FK_Attachment_Type
        {
            get { return _FK_Attachment_Type; }
            set { _FK_Attachment_Type = value; }
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
        /// Gets or sets the Attachment_Name value.
        /// </summary>
        public string Attachment_Name
        {
            get { return _Attachment_Name; }
            set { _Attachment_Name = value; }
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
        /// Gets Or Sets Attached_By value
        /// </summary>
        public string Attached_By
        {
            get { return _Attached_By; }
            set { _Attached_By = value; }
        }

        /// <summary>
        /// Gets or sets IsEmergencyDoc value
        /// </summary>
        public bool? IsEmergencyDoc
        {
            get { return _IsEmergencyDoc; }
            set { _IsEmergencyDoc = value; }
        }

        /// <summary>
        ///  Holds the value for FK_Folder
        /// </summary>
        public decimal? FK_Folder
        {
            get { return _FK_Folder; }
            set { _FK_Folder = value; }
        }

        /// <summary>
        ///  Holds the value for FK_New_Version_Attachment
        /// </summary>
        public decimal? FK_New_Version_Attachment
        {
            get { return _FK_New_Version_Attachment; }
            set { _FK_New_Version_Attachment = value; }
        }



        #endregion

        #region Default Constructors

        /// <summary>
        /// Initializes a new instance of the Attachment class with default value.
        /// </summary>
        public Attachment()
        {
        }

        #endregion

        #region Primary Constructors

        /// <summary>
        /// Initializes a new instance of the Attachment class based on Primary Key.
        /// </summary>
        public Attachment(decimal pK_Attachment_Id)
        {
            DataTable dtAttachment = SelectByPK(pK_Attachment_Id).Tables[0];

            if (dtAttachment.Rows.Count == 1)
            {
                SetValue(dtAttachment.Rows[0]);
            }
        }


        /// <summary>
        /// Initializes a new instance of the Attachment class based on Datarow passed.
        /// </summary>
        private void SetValue(DataRow drAttachment)
        {
            if (drAttachment["PK_Attachment_Id"] == DBNull.Value)
                this._PK_Attachment_Id = null;
            else
                this._PK_Attachment_Id = (decimal?)drAttachment["PK_Attachment_Id"];

            if (drAttachment["Attachment_Table"] == DBNull.Value)
                this._Attachment_Table = null;
            else
                this._Attachment_Table = (string)drAttachment["Attachment_Table"];

            if (drAttachment["Foreign_Key"] == DBNull.Value)
                this._Foreign_Key = null;
            else
                this._Foreign_Key = (decimal?)drAttachment["Foreign_Key"];

            if (drAttachment["FK_Attachment_Type"] == DBNull.Value)
                this._FK_Attachment_Type = null;
            else
                this._FK_Attachment_Type = (decimal?)drAttachment["FK_Attachment_Type"];

            if (drAttachment["Attachment_Description"] == DBNull.Value)
                this._Attachment_Description = null;
            else
                this._Attachment_Description = (string)drAttachment["Attachment_Description"];

            if (drAttachment["Attachment_Name"] == DBNull.Value)
                this._Attachment_Name = null;
            else
                this._Attachment_Name = (string)drAttachment["Attachment_Name"];

            if (drAttachment["Updated_By"] == DBNull.Value)
                this._Updated_By = null;
            else
                this._Updated_By = (string)drAttachment["Updated_By"];

            if (drAttachment["Update_Date"] == DBNull.Value)
                this._Update_Date = null;
            else
                this._Update_Date = (DateTime?)drAttachment["Update_Date"];

            if (drAttachment["IsEmergencyDoc"] == DBNull.Value)
                this._IsEmergencyDoc = null;
            else
                this._IsEmergencyDoc = (Boolean?)drAttachment["IsEmergencyDoc"];

            if (drAttachment["FK_Folder"] == DBNull.Value)
                this._FK_Folder = null;
            else
                this._FK_Folder = (decimal?)drAttachment["FK_Folder"];

            if (drAttachment["FK_New_Version_Attachment"] == DBNull.Value)
                this._FK_New_Version_Attachment = null;
            else
                this._FK_New_Version_Attachment = (decimal?)drAttachment["FK_New_Version_Attachment"];
        }

        #endregion

        #region "Methods"

        /// <summary>
        /// Inserts a record into the Attachment table.
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("AttachmentInsert");

            db.AddInParameter(dbCommand, "Attachment_Table", DbType.String, this._Attachment_Table);
            db.AddInParameter(dbCommand, "Foreign_Key", DbType.Decimal, this._Foreign_Key);
            db.AddInParameter(dbCommand, "FK_Attachment_Type", DbType.Decimal, this._FK_Attachment_Type);
            db.AddInParameter(dbCommand, "Attachment_Description", DbType.String, this._Attachment_Description);
            db.AddInParameter(dbCommand, "Attachment_Name", DbType.String, this._Attachment_Name);
            db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);
            db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);
            db.AddInParameter(dbCommand, "IsEmergencyDoc", DbType.Boolean, this._IsEmergencyDoc);
            db.AddInParameter(dbCommand, "Updated_By_Table", DbType.String, "Contractor_Security");
            db.AddInParameter(dbCommand, "FK_Folder", DbType.Decimal, _FK_Folder);
            db.AddInParameter(dbCommand, "FK_New_Version_Attachment", DbType.Decimal, _FK_New_Version_Attachment);

            // Execute the query and return the new identity value
            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
        }

        /// <summary>
        /// Selects a single record from the Attachment table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectByPK(decimal pK_Attachment_Id)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("AttachmentSelectByPK");

            db.AddInParameter(dbCommand, "PK_Attachment_Id", DbType.Decimal, pK_Attachment_Id);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects records from the Attachment table by a foreign key.
        /// </summary>
        /// <param name="fK_Attachment_Type"></param>
        /// <returns>DataSet</returns>
        public static DataSet SelectByFK_Attachment_Type(decimal fK_Attachment_Type)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("AttachmentSelectByFK_Attachment_Type");

            db.AddInParameter(dbCommand, "FK_Attachment_Type", DbType.Decimal, fK_Attachment_Type);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the Attachment table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("AttachmentSelectAll");

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Updates a record in the Attachment table.
        /// </summary>
        public void Update()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("AttachmentUpdate");

            db.AddInParameter(dbCommand, "PK_Attachment_Id", DbType.Decimal, this._PK_Attachment_Id);
            db.AddInParameter(dbCommand, "Attachment_Table", DbType.String, this._Attachment_Table);
            db.AddInParameter(dbCommand, "Foreign_Key", DbType.Decimal, this._Foreign_Key);
            db.AddInParameter(dbCommand, "FK_Attachment_Type", DbType.Decimal, this._FK_Attachment_Type);
            db.AddInParameter(dbCommand, "Attachment_Description", DbType.String, this._Attachment_Description);
            db.AddInParameter(dbCommand, "Attachment_Name", DbType.String, this._Attachment_Name);
            db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);
            db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);
            db.AddInParameter(dbCommand, "IsEmergencyDoc", DbType.Boolean, this._IsEmergencyDoc);
            db.AddInParameter(dbCommand, "Updated_By_Table", DbType.String, "Contractor_Security");
            db.AddInParameter(dbCommand, "FK_Folder", DbType.Decimal, _FK_Folder);
            db.AddInParameter(dbCommand, "FK_New_Version_Attachment", DbType.Decimal, _FK_New_Version_Attachment);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Deletes a record from the Attachment table by a composite primary key.
        /// </summary>
        public static void DeleteByPK(decimal pK_Attachment_Id)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("AttachmentDeleteByPK");
            db.AddInParameter(dbCommand, "PK_Attachment_Id", DbType.Decimal, pK_Attachment_Id);
            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Deletes a record from the Attachment table by a composite primary key.
        /// </summary>
        public static void DeleteByID(String strIDs)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("AttachmentDeleteByIDs");
            db.AddInParameter(dbCommand, "strIDs", DbType.String, strIDs);
            db.ExecuteNonQuery(dbCommand);
        }
        /// <summary>
        /// Deletes a record from the Attachment table by a foreign key.
        /// </summary>
        public static void DeleteByFK_Attachment_Type(decimal fK_Attachment_Type)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("AttachmentDeleteByFK_Attachment_Type");

            db.AddInParameter(dbCommand, "FK_Attachment_Type", DbType.Decimal, fK_Attachment_Type);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Selects a record depending on table name and related foreign key for the table
        /// </summary>
        /// <param name="Attachment_Table">Table name for which to store the record</param>
        /// <param name="Foreign_Key">Primary key value of the table</param>
        /// <returns></returns>
        public static DataSet SelectByTableName(string Attachment_Table, int Foreign_Key)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("AttachmentSelectByTableName");

            db.AddInParameter(dbCommand, "Attachment_Table", DbType.String, Attachment_Table);
            db.AddInParameter(dbCommand, "Foreign_Key", DbType.Int32, Foreign_Key);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects a record depending on table name and related foreign key for the table
        /// </summary>
        /// <param name="Attachment_Table">Table name for which to store the record</param>
        /// <param name="Foreign_Key">Primary key value of the table</param>
        /// <returns></returns>
        public static DataSet SelectByAttachmentName(string attachmentName)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("AttachmentSelectByName");

            db.AddInParameter(dbCommand, "Attachment_Name", DbType.String, attachmentName);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects  records of attachment type Image depending on table name and related foreign key for the table
        /// </summary>
        /// <param name="Attachment_Table">Table name for which to store the record</param>
        /// <param name="Foreign_Key">Primary key value of the table</param>
        /// <returns></returns>
        public static DataSet SelectByAttachmentImageTableName(string Attachment_Table, decimal Foreign_Key)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("AttachmentImageSelectBYFK");

            db.AddInParameter(dbCommand, "Attachment_Table", DbType.String, Attachment_Table);
            db.AddInParameter(dbCommand, "Foreign_Key", DbType.Decimal, Foreign_Key);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects  records of attachment type Image depending on table name and related foreign key for the table
        /// </summary>
        /// <param name="Attachment_Table">Table name for which to store the record</param>
        /// <param name="Foreign_Key">Primary key value of the table</param>
        /// <returns></returns>
        public static DataSet SelectAttachmentTableNameForeignKey(string Attachment_Table, string Foreign_Key)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("AttachmentSelectByFKTableName");

            db.AddInParameter(dbCommand, "Attachment_Table", DbType.String, Attachment_Table);
            db.AddInParameter(dbCommand, "Foreign_Key", DbType.String, string.IsNullOrEmpty(Foreign_Key) ? "0" : Foreign_Key);

            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet SelectAttachmentByUserID(string Attachment_Table, string Foreign_Key,string Updated_By)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("AttachmentSelectByFKTableNameUserID");

            db.AddInParameter(dbCommand, "Foreign_Key", DbType.String, string.IsNullOrEmpty(Foreign_Key) ? "0" : Foreign_Key);
            db.AddInParameter(dbCommand, "Attachment_Table", DbType.String, Attachment_Table);
            db.AddInParameter(dbCommand, "Updated_By", DbType.String, string.IsNullOrEmpty(Updated_By) ? "0" : Updated_By);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects  records of attachment type Image depending on table name and related foreign key for the table
        /// </summary>
        /// <param name="Attachment_Table">Table name for which to store the record</param>
        /// <param name="Foreign_Key">Primary key value of the table</param>
        /// <returns></returns>
        public static DataSet GetEmergencyDocument(Int32 fK_Facility_Construction_PM, Int32 fK_Building)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("AttachmentGetEmergencyDocumentByProjectNumberBuilding");

            db.AddInParameter(dbCommand, "FK_Facility_Construction_PM", DbType.Int32, fK_Facility_Construction_PM);
            db.AddInParameter(dbCommand, "FK_Building", DbType.Int32, fK_Building);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all attachment details by Inspection and Inspection area foreigh keys
        /// </summary>
        /// <param name="fK_Facility_Construction_Inspection"></param>
        /// <param name="fK_Facility_Inspection_Area"></param>
        /// <returns></returns>
        public static DataTable SelectByFacilityInspectionItem(decimal fK_Facility_Construction_Inspection, decimal fK_Facility_Inspection_Area)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("AttachmentGetDetailsByFacilityInspectionItem");
            db.AddInParameter(dbCommand, "FK_Facility_Construction_Inspection", DbType.Decimal, fK_Facility_Construction_Inspection);
            db.AddInParameter(dbCommand, "FK_Facility_Inspection_Area", DbType.Decimal, fK_Facility_Inspection_Area);

            return db.ExecuteDataSet(dbCommand).Tables[0];
        }

        /// <summary>
        /// Dataset return as list Format
        /// </summary>
        /// <param name="ds"></param>
        /// <returns></returns>
        public static List<Attachment> SelectList(DataSet ds, bool isAttachedByRequired)
        {
            List<Attachment> lstAttachments = new List<Attachment>();
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Attachment objAttachment = new Attachment();
                    objAttachment.SetValue(dr);
                    if (isAttachedByRequired)
                    {
                        objAttachment._Attached_By = (string)dr["AttachedBy"];
                    }

                    lstAttachments.Add(objAttachment);
                }
            }
            return lstAttachments;
        }

        public static DataTable SelectAttachmentVersions(decimal PK_Attachment_Id, decimal PK_Facility_construction_ProjectID, int PageSize, int PageNumber)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("SelectAttachmentVersions");
            db.AddInParameter(dbCommand, "PK_Attachment_Id", DbType.Decimal, PK_Attachment_Id);
            db.AddInParameter(dbCommand, "PK_Facility_construction_ProjectID", DbType.Decimal, PK_Facility_construction_ProjectID);
            db.AddInParameter(dbCommand, "PageSize", DbType.Int32, PageSize);
            db.AddInParameter(dbCommand, "PageNumber", DbType.Int32, PageNumber);

            return db.ExecuteDataSet(dbCommand).Tables[0];
        }

        #endregion
    }
}
