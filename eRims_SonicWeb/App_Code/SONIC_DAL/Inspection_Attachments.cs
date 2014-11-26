using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
    /// <summary>
    /// Data access class for Inspection_Attachments table.
    /// </summary>
    public sealed class Inspection_Attachments
    {

        #region Fields
        private string _Filename;
        private int _FK_Inspection_ID;
        private string _path;
        private int _PK_Inspection_Attachments_ID;
        private string _Type;

        #endregion


        #region Properties
        /// <summary> 
        /// Gets or sets the Filename value.
        /// </summary>
        public string Filename
        {
            get { return _Filename; }
            set { _Filename = value; }
        }


        /// <summary> 
        /// Gets or sets the FK_Inspection_ID value.
        /// </summary>
        public int FK_Inspection_ID
        {
            get { return _FK_Inspection_ID; }
            set { _FK_Inspection_ID = value; }
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
        /// Gets or sets the PK_Inspection_Attachments_ID value.
        /// </summary>
        public int PK_Inspection_Attachments_ID
        {
            get { return _PK_Inspection_Attachments_ID; }
            set { _PK_Inspection_Attachments_ID = value; }
        }


        /// <summary> 
        /// Gets or sets the Type value.
        /// </summary>
        public string Type
        {
            get { return _Type; }
            set { _Type = value; }
        }



        #endregion


        #region Constructors
        /// <summary> 
        /// Initializes a new instance of the Inspection_Attachments class. with the default value.
        /// </summary>
        public Inspection_Attachments()
        {
            this._Filename = "";
            this._FK_Inspection_ID = -1;
            this._path = "";
            this._PK_Inspection_Attachments_ID = -1;
            this._Type = "";

        }



        /// <summary> 
        /// Initializes a new instance of the Inspection_Attachments class for passed PrimaryKey with the values set from Database.
        /// </summary>
        public Inspection_Attachments(int PK)
        {

            DataTable dtInspection_Attachments = SelectByPK(PK).Tables[0];

            if (dtInspection_Attachments.Rows.Count > 0)
            {

                DataRow drInspection_Attachments = dtInspection_Attachments.Rows[0];
                this._Filename = Convert.ToString(drInspection_Attachments["Filename"]);
                this._FK_Inspection_ID = drInspection_Attachments["FK_Inspection_ID"] != DBNull.Value ? Convert.ToInt32(drInspection_Attachments["FK_Inspection_ID"]) : 0;
                this._path = Convert.ToString(drInspection_Attachments["path"]);
                this._PK_Inspection_Attachments_ID = drInspection_Attachments["PK_Inspection_Attachments_ID"] != DBNull.Value ? Convert.ToInt32(drInspection_Attachments["PK_Inspection_Attachments_ID"]) : 0;
                this._Type = Convert.ToString(drInspection_Attachments["Type"]);

            }

            else
            {
                this._Filename = "";
                this._FK_Inspection_ID = -1;
                this._path = "";
                this._PK_Inspection_Attachments_ID = -1;
                this._Type = "";

            }

        }



        #endregion

        #region "Methods"

        /// <summary>
        /// Inserts a record into the Inspection_Attachments table.
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Inspection_AttachmentsInsert");

            db.AddInParameter(dbCommand, "Filename", DbType.String, this._Filename);
            db.AddInParameter(dbCommand, "FK_Inspection_ID", DbType.Int32, this._FK_Inspection_ID);
            db.AddInParameter(dbCommand, "path", DbType.String, this._path);
            db.AddInParameter(dbCommand, "Type", DbType.String, this._Type);

            // Execute the query and return the new identity value
            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
        }

        /// <summary>
        /// Selects a single record from the Inspection_Attachments table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectByPK(int pK_Inspection_Attachments_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Inspection_AttachmentsSelectByPK");

            db.AddInParameter(dbCommand, "PK_Inspection_Attachments_ID", DbType.Int32, pK_Inspection_Attachments_ID);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the Inspection_Attachments table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Inspection_AttachmentsSelectAll");

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Updates a record in the Inspection_Attachments table.
        /// </summary>
        public void Update()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Inspection_AttachmentsUpdate");

            db.AddInParameter(dbCommand, "Filename", DbType.String, this._Filename);
            db.AddInParameter(dbCommand, "FK_Inspection_ID", DbType.Int32, this._FK_Inspection_ID);
            db.AddInParameter(dbCommand, "path", DbType.String, this._path);
            db.AddInParameter(dbCommand, "PK_Inspection_Attachments_ID", DbType.Int32, this._PK_Inspection_Attachments_ID);
            db.AddInParameter(dbCommand, "Type", DbType.String, this._Type);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Deletes a record from the Inspection_Attachments table by a composite primary key.
        /// </summary>
        public static void DeleteByPK(int pK_Inspection_Attachments_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Inspection_AttachmentsDeleteByPK");

            db.AddInParameter(dbCommand, "PK_Inspection_Attachments_ID", DbType.Int32, pK_Inspection_Attachments_ID);

            db.ExecuteNonQuery(dbCommand);
        }

        public static DataSet SelectByFK(int fK_Inspection_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Inspection_AttachmentsSelectByFK");

            db.AddInParameter(dbCommand, "FK_Inspection_ID", DbType.Int32, fK_Inspection_ID);

            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet SelectForMail(int fK_Inspection_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("GetInspectionAttachmnetForMail");

            db.AddInParameter(dbCommand, "PK_Inspection_ID", DbType.Int32, fK_Inspection_ID);

            return db.ExecuteDataSet(dbCommand);
        }
        #endregion
    }
}
