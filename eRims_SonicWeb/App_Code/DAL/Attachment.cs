using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
    /// <summary>
    /// Data access class for Attachment table.
    /// </summary>
    public sealed class ERIMSAttachment
    {
        #region Fields


        private decimal _PK_Attachment_Id;
        private string _Attachment_Table;
        private decimal _Foreign_Key;
        private decimal _FK_Attachment_Type;
        private string _Attachment_Description;
        private string _Attachment_Name;
        private string _Updated_By;
        private DateTime _Update_Date;

        #endregion

        #region Properties


        /// <summary> 
        /// Gets or sets the PK_Attachment_Id value.
        /// </summary>
        public decimal PK_Attachment_Id
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
        public decimal Foreign_Key
        {
            get { return _Foreign_Key; }
            set { _Foreign_Key = value; }
        }


        /// <summary> 
        /// Gets or sets the FK_Attachment_Type value.
        /// </summary>
        public decimal FK_Attachment_Type
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
        public DateTime Update_Date
        {
            get { return _Update_Date; }
            set { _Update_Date = value; }
        }



        #endregion

        #region Constructors

        /// <summary> 

        /// Initializes a new instance of the Attachment class. with the default value.

        /// </summary>
        public ERIMSAttachment()
        {

            this._PK_Attachment_Id = -1;
            this._Attachment_Table = "";
            this._Foreign_Key = -1;
            this._FK_Attachment_Type = -1;
            this._Attachment_Description = "";
            this._Attachment_Name = "";
            this._Updated_By = "";
            this._Update_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;

        }



        /// <summary> 

        /// Initializes a new instance of the Attachment class for passed PrimaryKey with the values set from Database.


        /// </summary>
        public ERIMSAttachment(decimal PK)
        {

            DataTable dtAttachment = SelectByPK(PK).Tables[0];

            if (dtAttachment.Rows.Count > 0)
            {

                DataRow drAttachment = dtAttachment.Rows[0];

                this._PK_Attachment_Id = drAttachment["PK_Attachment_Id"] != DBNull.Value ? Convert.ToDecimal(drAttachment["PK_Attachment_Id"]) : 0;
                this._Attachment_Table = Convert.ToString(drAttachment["Attachment_Table"]);
                this._Foreign_Key = drAttachment["Foreign_Key"] != DBNull.Value ? Convert.ToDecimal(drAttachment["Foreign_Key"]) : 0;
                this._FK_Attachment_Type = drAttachment["FK_Attachment_Type"] != DBNull.Value ? Convert.ToDecimal(drAttachment["FK_Attachment_Type"]) : 0;
                this._Attachment_Description = Convert.ToString(drAttachment["Attachment_Description"]);
                this._Attachment_Name = Convert.ToString(drAttachment["Attachment_Name"]);
                this._Updated_By = Convert.ToString(drAttachment["Updated_By"]);
                this._Update_Date = drAttachment["Update_Date"] != DBNull.Value ? Convert.ToDateTime(drAttachment["Update_Date"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;

            }

            else
            {

                this._PK_Attachment_Id = -1;
                this._Attachment_Table = "";
                this._Foreign_Key = -1;
                this._FK_Attachment_Type = -1;
                this._Attachment_Description = "";
                this._Attachment_Name = "";
                this._Updated_By = "";
                this._Update_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;

            }

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
        /// select a record from the Attachment table by a composite primary key.
        /// </summary>
        public static DataSet SelectByID(String strIDs)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("SelectAttachmentByIDs");

            db.AddInParameter(dbCommand, "strIDs", DbType.String, strIDs);

            return db.ExecuteDataSet(dbCommand);
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
        /// Method to Get Attachment Details By table Name
        /// </summary>
        /// <param name="Attachment_Table"></param>
        /// <param name="Foreign_Key"></param>
        /// <param name="strOrderBy"></param>
        /// <param name="strOrder"></param>
        /// <returns></returns>
        public static DataSet SelectByTableName(string Attachment_Table, int Foreign_Key, string strOrderBy, string strOrder)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("AttachmentSelectByTableNameWithSorting");

            db.AddInParameter(dbCommand, "Attachment_Table", DbType.String, Attachment_Table);
            db.AddInParameter(dbCommand, "Foreign_Key", DbType.Int32, Foreign_Key);
            db.AddInParameter(dbCommand, "strOrderBy", DbType.String, strOrderBy);
            db.AddInParameter(dbCommand, "strOrder", DbType.String, strOrder);

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

        #endregion
    }
}
