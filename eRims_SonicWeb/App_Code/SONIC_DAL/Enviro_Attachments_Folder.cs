using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
    /// <summary>
    /// Data access class for Enviro_Attachments_Folder table.
    /// </summary>
    public sealed class Enviro_Attachments_Folder
    {
        #region Fields

        private int _PK_Enviro_Attachments_Folder_ID;
        private string _Folder_Name;

        #endregion


        #region Properties



        /// <summary> 
        /// Gets or sets the PK_Enviro_Attachments_Folder_ID value.
        /// </summary>
        public int PK_Enviro_Attachments_Folder_ID
        {
            get { return _PK_Enviro_Attachments_Folder_ID; }
            set { _PK_Enviro_Attachments_Folder_ID = value; }
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


        #region Constructors

        /// <summary> 

        /// Initializes a new instance of the Enviro_Attachments_Folder class. with the default value.

        /// </summary>
        public Enviro_Attachments_Folder()
        {

            this._PK_Enviro_Attachments_Folder_ID = -1;
            this._Folder_Name = "";

        }



        /// <summary> 

        /// Initializes a new instance of the Enviro_Attachments_Folder class for passed PrimaryKey with the values set from Database.



        /// </summary>
        public Enviro_Attachments_Folder(int PK)
        {

            DataTable dtEnviro_Attachments_Folder = SelectByPK(PK).Tables[0];

            if (dtEnviro_Attachments_Folder.Rows.Count > 0)
            {

                DataRow drEnviro_Attachments_Folder = dtEnviro_Attachments_Folder.Rows[0];

                this._PK_Enviro_Attachments_Folder_ID = drEnviro_Attachments_Folder["PK_Enviro_Attachments_Folder_ID"] != DBNull.Value ? Convert.ToInt32(drEnviro_Attachments_Folder["PK_Enviro_Attachments_Folder_ID"]) : 0;
                this._Folder_Name = Convert.ToString(drEnviro_Attachments_Folder["Folder_Name"]);

            }

            else
            {


                this._PK_Enviro_Attachments_Folder_ID = -1;
                this._Folder_Name = "";

            }

        }



        #endregion


        /// <summary>
        /// Inserts a record into the Enviro_Attachments_Folder table.
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Enviro_Attachments_FolderInsert");

            db.AddInParameter(dbCommand, "Folder_Name", DbType.String, this._Folder_Name);

            // Execute the query and return the new identity value
            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
        }

        /// <summary>
        /// Selects a single record from the Enviro_Attachments_Folder table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectByPK(int pK_Enviro_Attachments_Folder_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Enviro_Attachments_FolderSelectByPK");

            db.AddInParameter(dbCommand, "PK_Enviro_Attachments_Folder_ID", DbType.Int32, pK_Enviro_Attachments_Folder_ID);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the Enviro_Attachments_Folder table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Enviro_Attachments_FolderSelectAll");

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Updates a record in the Enviro_Attachments_Folder table.
        /// </summary>
        public void Update()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Enviro_Attachments_FolderUpdate");

            db.AddInParameter(dbCommand, "PK_Enviro_Attachments_Folder_ID", DbType.Int32, this._PK_Enviro_Attachments_Folder_ID);
            db.AddInParameter(dbCommand, "Folder_Name", DbType.String, this._Folder_Name);

            db.ExecuteNonQuery(dbCommand);
        }

        public static bool CheckFileName(string FolderName)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Enviro_Attachments_FolderSelectByFolderName");

            db.AddInParameter(dbCommand, "Folder_Name", DbType.String, FolderName);

            return (db.ExecuteDataSet(dbCommand).Tables[0].Rows.Count > 0);

        }

        /// <summary>
        /// Deletes a record from the Enviro_Attachments_Folder table by a composite primary key.
        /// </summary>
        public static void DeleteByPK(int pK_Enviro_Attachments_Folder_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Enviro_Attachments_FolderDeleteByPK");

            db.AddInParameter(dbCommand, "PK_Enviro_Attachments_Folder_ID", DbType.Int32, pK_Enviro_Attachments_Folder_ID);

            db.ExecuteNonQuery(dbCommand);
        }
    }
}
