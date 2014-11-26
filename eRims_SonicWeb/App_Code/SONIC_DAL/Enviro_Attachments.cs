using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
    /// <summary>
    /// Data access class for Enviro_Attachments table.
    /// </summary>
    public sealed class Enviro_Attachments
    {

        #region Fields

        private int _PK_Enviro_Equipment_Attachments_ID;
        private string _Foreign_Table;
        private int _Foreign_Key;
        private string _Type;
        private string _Filename;
        private string _path;
        private int _FK_Enviro_Attachments_Folder_ID;
        private string _description;

        #endregion


        #region Properties
        /// <summary> 
        /// Gets or sets the PK_Enviro_Equipment_Attachments_ID value.
        /// </summary>
        public int PK_Enviro_Equipment_Attachments_ID
        {
            get { return _PK_Enviro_Equipment_Attachments_ID; }
            set { _PK_Enviro_Equipment_Attachments_ID = value; }
        }


        /// <summary> 
        /// Gets or sets the Foreign_Table value.
        /// </summary>
        public string Foreign_Table
        {
            get { return _Foreign_Table; }
            set { _Foreign_Table = value; }
        }


        /// <summary> 
        /// Gets or sets the Foreign_Key value.
        /// </summary>
        public int Foreign_Key
        {
            get { return _Foreign_Key; }
            set { _Foreign_Key = value; }
        }


        /// <summary> 
        /// Gets or sets the Type value.
        /// </summary>
        public string Type
        {
            get { return _Type; }
            set { _Type = value; }
        }


        /// <summary> 
        /// Gets or sets the Filename value.
        /// </summary>
        public string Filename
        {
            get { return _Filename; }
            set { _Filename = value; }
        }


        /// <summary> 
        /// Gets or sets the path value.
        /// </summary>
        public string path
        {
            get { return _path; }
            set { _path = value; }
        }


        /// <summary> 
        /// Gets or sets the FK_Enviro_Attachments_Folder_ID value.
        /// </summary>
        public int FK_Enviro_Attachments_Folder_ID
        {
            get { return _FK_Enviro_Attachments_Folder_ID; }
            set { _FK_Enviro_Attachments_Folder_ID = value; }
        }


        /// <summary> 
        /// Gets or sets the description value.
        /// </summary>
        public string description
        {
            get { return _description; }
            set { _description = value; }
        }



        #endregion


        #region Constructors

        /// <summary> 

        /// Initializes a new instance of the Enviro_Attachments class. with the default value.

        /// </summary>
        public Enviro_Attachments()
        {

            this._PK_Enviro_Equipment_Attachments_ID = -1;
            this._Foreign_Table = "";
            this._Foreign_Key = -1;
            this._Type = "";
            this._Filename = "";
            this._path = "";
            this._FK_Enviro_Attachments_Folder_ID = -1;
            this._description = "";

        }



        /// <summary> 

        /// Initializes a new instance of the Enviro_Attachments class for passed PrimaryKey with the values set from Database.

        /// </summary>
        public Enviro_Attachments(int PK)
        {

            DataTable dtEnviro_Attachments = SelectByPK(PK).Tables[0];

            if (dtEnviro_Attachments.Rows.Count > 0)
            {

                DataRow drEnviro_Attachments = dtEnviro_Attachments.Rows[0];

                this._PK_Enviro_Equipment_Attachments_ID = drEnviro_Attachments["PK_Enviro_Equipment_Attachments_ID"] != DBNull.Value ? Convert.ToInt32(drEnviro_Attachments["PK_Enviro_Equipment_Attachments_ID"]) : 0;
                this._Foreign_Table = Convert.ToString(drEnviro_Attachments["Foreign_Table"]);
                this._Foreign_Key = drEnviro_Attachments["Foreign_Key"] != DBNull.Value ? Convert.ToInt32(drEnviro_Attachments["Foreign_Key"]) : 0;
                this._Type = Convert.ToString(drEnviro_Attachments["Type"]);
                this._Filename = Convert.ToString(drEnviro_Attachments["Filename"]);
                this._path = Convert.ToString(drEnviro_Attachments["path"]);
                this._FK_Enviro_Attachments_Folder_ID = drEnviro_Attachments["FK_Enviro_Attachments_Folder_ID"] != DBNull.Value ? Convert.ToInt32(drEnviro_Attachments["FK_Enviro_Attachments_Folder_ID"]) : 0;
                this._description = Convert.ToString(drEnviro_Attachments["description"]);

            }

            else
            {
                this._PK_Enviro_Equipment_Attachments_ID = -1;
                this._Foreign_Table = "";
                this._Foreign_Key = -1;
                this._Type = "";
                this._Filename = "";
                this._path = "";
                this._FK_Enviro_Attachments_Folder_ID = -1;
                this._description = "";

            }

        }



        #endregion

        /// <summary>
        /// Inserts a record into the Enviro_Attachments table.
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Enviro_AttachmentsInsert");

            db.AddInParameter(dbCommand, "Foreign_Table", DbType.String, this._Foreign_Table);
            db.AddInParameter(dbCommand, "Foreign_Key", DbType.Int32, this._Foreign_Key);
            db.AddInParameter(dbCommand, "Type", DbType.String, this._Type);
            db.AddInParameter(dbCommand, "Filename", DbType.String, this._Filename);
            db.AddInParameter(dbCommand, "path", DbType.String, this._path);
            db.AddInParameter(dbCommand, "FK_Enviro_Attachments_Folder_ID", DbType.Int32, this._FK_Enviro_Attachments_Folder_ID);
            db.AddInParameter(dbCommand, "description", DbType.String, this._description);

            // Execute the query and return the new identity value
            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
        }

        /// <summary>
        /// Selects a single record from the Enviro_Attachments table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectByPK(int pK_Enviro_Equipment_Attachments_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Enviro_AttachmentsSelectByPK");

            db.AddInParameter(dbCommand, "PK_Enviro_Equipment_Attachments_ID", DbType.Int32, pK_Enviro_Equipment_Attachments_ID);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects  all record from the Enviro_Attachments table by a Foreign Table Name and Foreign Table Key.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectByForeignTable(string ForeignTableName, int Foreign_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("SelectByTableFK");

            db.AddInParameter(dbCommand, "Foreign_Table", DbType.String, ForeignTableName);
            db.AddInParameter(dbCommand, "Foreign_Key", DbType.Int32, Foreign_ID);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the Enviro_Attachments table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Enviro_AttachmentsSelectAll");

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Updates a record in the Enviro_Attachments table.
        /// </summary>
        public void Update()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Enviro_AttachmentsUpdate");

            db.AddInParameter(dbCommand, "PK_Enviro_Equipment_Attachments_ID", DbType.Int32, this._PK_Enviro_Equipment_Attachments_ID);
            db.AddInParameter(dbCommand, "Foreign_Table", DbType.String, this._Foreign_Table);
            db.AddInParameter(dbCommand, "Foreign_Key", DbType.Int32, this._Foreign_Key);
            db.AddInParameter(dbCommand, "Type", DbType.String, this._Type);
            db.AddInParameter(dbCommand, "Filename", DbType.String, this._Filename);
            db.AddInParameter(dbCommand, "path", DbType.String, this._path);
            db.AddInParameter(dbCommand, "FK_Enviro_Attachments_Folder_ID", DbType.Int32, this._FK_Enviro_Attachments_Folder_ID);
            db.AddInParameter(dbCommand, "description", DbType.String, this._description);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Deletes a record from the Enviro_Attachments table by a composite primary key.
        /// </summary>
        public static void DeleteByPK(int pK_Enviro_Equipment_Attachments_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Enviro_AttachmentsDeleteByPK");

            db.AddInParameter(dbCommand, "PK_Enviro_Equipment_Attachments_ID", DbType.Int32, pK_Enviro_Equipment_Attachments_ID);

            db.ExecuteNonQuery(dbCommand);
        }
        
        //Enviro_AttachmentsDeleteByIDs

        /// <summary>
        /// Deletes  records from the Enviro_Attachments table by Multiple Id .
        /// </summary>
        public static void DeleteByMultipleIDs(string PK_Attachments_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Enviro_AttachmentsDeleteByIDs");

            db.AddInParameter(dbCommand, "PK_Attachments_ID", DbType.String, PK_Attachments_ID);

            db.ExecuteNonQuery(dbCommand);
        }


        //Enviro_Equipment_GetAttachmentByIDs

        //Enviro_AttachmentsDeleteByIDs

        /// <summary>
        /// select records from the Enviro_Attachments table by Multiple Id .
        /// </summary>
        public static DataSet SelectByMultipleIDs(string PK_Attachments_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Enviro_Equipment_GetAttachmentByIDs");

            db.AddInParameter(dbCommand, "Attachments_IDs", DbType.String, PK_Attachments_ID);
            return db.ExecuteDataSet(dbCommand);
        }

    }
}
