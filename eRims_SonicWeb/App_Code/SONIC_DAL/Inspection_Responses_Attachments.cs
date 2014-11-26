using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
    /// <summary>
    /// Data access class for Inspection_Responses_Attachments table.
    /// </summary>
    public sealed class Inspection_Responses_Attachments
    {
        #region Private variables used to hold the property values

        private int? _PK_Inspection_Responses_Attachments_ID;
        private int? _FK_Inspection_Responses_ID;
        private string _Type;
        private string _Filename;
        private string _Path;

        #endregion

        #region Public Property

        /// <summary>
        /// Gets or sets the PK_Inspection_Responses_Attachments_ID value.
        /// </summary>
        public int? PK_Inspection_Responses_Attachments_ID
        {
            get { return _PK_Inspection_Responses_Attachments_ID; }
            set { _PK_Inspection_Responses_Attachments_ID = value; }
        }

        /// <summary>
        /// Gets or sets the FK_Inspection_Responses_ID value.
        /// </summary>
        public int? FK_Inspection_Responses_ID
        {
            get { return _FK_Inspection_Responses_ID; }
            set { _FK_Inspection_Responses_ID = value; }
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
        /// Gets or sets the Path value.
        /// </summary>
        public string Path
        {
            get { return _Path; }
            set { _Path = value; }
        }


        #endregion

        #region Default Constructors

        /// <summary>
        /// Initializes a new instance of the Inspection_Responses_Attachments class with default value.
        /// </summary>
        public Inspection_Responses_Attachments()
        {

            this._PK_Inspection_Responses_Attachments_ID = null;
            this._FK_Inspection_Responses_ID = null;
            this._Type = null;
            this._Filename = null;
            this._Path = null;

        }

        #endregion

        #region Primary Constructors

        /// <summary>
        /// Initializes a new instance of the Inspection_Responses_Attachments class based on Primary Key.
        /// </summary>
        public Inspection_Responses_Attachments(int pK_Inspection_Responses_Attachments_ID)
        {
            DataTable dtInspection_Responses_Attachments = SelectByPK(pK_Inspection_Responses_Attachments_ID).Tables[0];

            if (dtInspection_Responses_Attachments.Rows.Count == 1)
            {
                DataRow drInspection_Responses_Attachments = dtInspection_Responses_Attachments.Rows[0];
                if (drInspection_Responses_Attachments["PK_Inspection_Responses_Attachments_ID"] == DBNull.Value)
                    this._PK_Inspection_Responses_Attachments_ID = null;
                else
                    this._PK_Inspection_Responses_Attachments_ID = (int?)drInspection_Responses_Attachments["PK_Inspection_Responses_Attachments_ID"];

                if (drInspection_Responses_Attachments["FK_Inspection_Responses_ID"] == DBNull.Value)
                    this._FK_Inspection_Responses_ID = null;
                else
                    this._FK_Inspection_Responses_ID = (int?)drInspection_Responses_Attachments["FK_Inspection_Responses_ID"];

                if (drInspection_Responses_Attachments["Type"] == DBNull.Value)
                    this._Type = null;
                else
                    this._Type = (string)drInspection_Responses_Attachments["Type"];

                if (drInspection_Responses_Attachments["Filename"] == DBNull.Value)
                    this._Filename = null;
                else
                    this._Filename = (string)drInspection_Responses_Attachments["Filename"];

                if (drInspection_Responses_Attachments["Path"] == DBNull.Value)
                    this._Path = null;
                else
                    this._Path = (string)drInspection_Responses_Attachments["Path"];

            }
            else
            {
                this._PK_Inspection_Responses_Attachments_ID = null;
                this._FK_Inspection_Responses_ID = null;
                this._Type = null;
                this._Filename = null;
                this._Path = null;
            }

        }

        #endregion

        /// <summary>
        /// Inserts a record into the Inspection_Responses_Attachments table.
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Inspection_Responses_AttachmentsInsert");


            db.AddInParameter(dbCommand, "FK_Inspection_Responses_ID", DbType.Int32, this._FK_Inspection_Responses_ID);

            if (string.IsNullOrEmpty(this._Type))
                db.AddInParameter(dbCommand, "Type", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Type", DbType.String, this._Type);

            if (string.IsNullOrEmpty(this._Filename))
                db.AddInParameter(dbCommand, "Filename", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Filename", DbType.String, this._Filename);

            if (string.IsNullOrEmpty(this._Path))
                db.AddInParameter(dbCommand, "Path", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Path", DbType.String, this._Path);

            // Execute the query and return the new identity value
            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
        }

        /// <summary>
        /// Selects a single record from the Inspection_Responses_Attachments table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        private static DataSet SelectByPK(int pK_Inspection_Responses_Attachments_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Inspection_Responses_AttachmentsSelectByPK");

            db.AddInParameter(dbCommand, "PK_Inspection_Responses_Attachments_ID", DbType.Int32, pK_Inspection_Responses_Attachments_ID);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the Inspection_Responses_Attachments table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Inspection_Responses_AttachmentsSelectAll");

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Updates a record in the Inspection_Responses_Attachments table.
        /// </summary>
        public void Update()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Inspection_Responses_AttachmentsUpdate");


            db.AddInParameter(dbCommand, "PK_Inspection_Responses_Attachments_ID", DbType.Int32, this._PK_Inspection_Responses_Attachments_ID);

            db.AddInParameter(dbCommand, "FK_Inspection_Responses_ID", DbType.Int32, this._FK_Inspection_Responses_ID);

            if (string.IsNullOrEmpty(this._Type))
                db.AddInParameter(dbCommand, "Type", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Type", DbType.String, this._Type);

            if (string.IsNullOrEmpty(this._Filename))
                db.AddInParameter(dbCommand, "Filename", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Filename", DbType.String, this._Filename);

            if (string.IsNullOrEmpty(this._Path))
                db.AddInParameter(dbCommand, "Path", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Path", DbType.String, this._Path);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Deletes a record from the Inspection_Responses_Attachments table by a composite primary key.
        /// </summary>
        public static void DeleteByPK(int pK_Inspection_Responses_Attachments_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Inspection_Responses_AttachmentsDeleteByPK");

            db.AddInParameter(dbCommand, "PK_Inspection_Responses_Attachments_ID", DbType.Int32, pK_Inspection_Responses_Attachments_ID);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Selects a single record from the Inspection_Responses_Attachments table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectByFocusArea(string Item_Number_Focus_Area, int FK_Inspection_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Inspection_Responses_AttachmentsSelectByFocusArea");

            db.AddInParameter(dbCommand, "Item_Number_Focus_Area", DbType.String, Item_Number_Focus_Area);
            db.AddInParameter(dbCommand, "FK_Inspection_ID", DbType.Int32, FK_Inspection_ID);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects a single record from the Inspection_Responses_Attachments table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectImagesByFocusArea(string Item_Number_Focus_Area, int FK_Inspection_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Inspection_Responses_AttachmentsImagesSelectByFocusArea");

            db.AddInParameter(dbCommand, "Item_Number_Focus_Area", DbType.String, Item_Number_Focus_Area);
            db.AddInParameter(dbCommand, "FK_Inspection_ID", DbType.Int32, FK_Inspection_ID);

            return db.ExecuteDataSet(dbCommand);
        }
        //Inspection_Responses_AttachmentsImagesSelectByInspection
        public static DataSet SelectImagesByInspection(int FK_Inspection_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Inspection_Responses_AttachmentsImagesSelectByInspection");

            db.AddInParameter(dbCommand, "FK_Inspection_ID", DbType.Int32, FK_Inspection_ID);

            return db.ExecuteDataSet(dbCommand);
        }
    }
}
