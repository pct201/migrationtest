using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
    /// <summary>
    /// Data access class for PL_FR_Attachments table.
    /// </summary>
    public sealed class PL_FR_Attachments
    {
        #region Fields


        private decimal _PK_PL_FR_Attachments_ID;
        private decimal _FK_PL_FR_ID;
        private string _Attachment_Type;
        private string _Description;
        private string _Attachment_Path;

        #endregion


        #region Properties


        /// <summary> 
        /// Gets or sets the PK_PL_FR_Attachments_ID value.
        /// </summary>
        public decimal PK_PL_FR_Attachments_ID
        {
            get { return _PK_PL_FR_Attachments_ID; }
            set { _PK_PL_FR_Attachments_ID = value; }
        }


        /// <summary> 
        /// Gets or sets the FK_PL_FR_ID value.
        /// </summary>
        public decimal FK_PL_FR_ID
        {
            get { return _FK_PL_FR_ID; }
            set { _FK_PL_FR_ID = value; }
        }


        /// <summary> 
        /// Gets or sets the Attachment_Type value.
        /// </summary>
        public string Attachment_Type
        {
            get { return _Attachment_Type; }
            set { _Attachment_Type = value; }
        }


        /// <summary> 
        /// Gets or sets the Description value.
        /// </summary>
        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }


        /// <summary> 
        /// Gets or sets the Attachment_Path value.
        /// </summary>
        public string Attachment_Path
        {
            get { return _Attachment_Path; }
            set { _Attachment_Path = value; }
        }



        #endregion


        #region Constructors

        /// <summary> 

        /// Initializes a new instance of the PL_FR_Attachments class. with the default value.

        /// </summary>
        public PL_FR_Attachments()
        {

            this._PK_PL_FR_Attachments_ID = -1;
            this._FK_PL_FR_ID = -1;
            this._Attachment_Type = "";
            this._Description = "";
            this._Attachment_Path = "";

        }



        /// <summary> 

        /// Initializes a new instance of the PL_FR_Attachments class for passed PrimaryKey with the values set from Database.


        /// </summary>
        public PL_FR_Attachments(decimal PK)
        {

            DataTable dtPL_FR_Attachments = SelectByPK(PK).Tables[0];

            if (dtPL_FR_Attachments.Rows.Count > 0)
            {

                DataRow drPL_FR_Attachments = dtPL_FR_Attachments.Rows[0];

                this._PK_PL_FR_Attachments_ID = drPL_FR_Attachments["PK_PL_FR_Attachments_ID"] != DBNull.Value ? Convert.ToDecimal(drPL_FR_Attachments["PK_PL_FR_Attachments_ID"]) : 0;
                this._FK_PL_FR_ID = drPL_FR_Attachments["FK_PL_FR_ID"] != DBNull.Value ? Convert.ToDecimal(drPL_FR_Attachments["FK_PL_FR_ID"]) : 0;
                this._Attachment_Type = Convert.ToString(drPL_FR_Attachments["Attachment_Type"]);
                this._Description = Convert.ToString(drPL_FR_Attachments["Description"]);
                this._Attachment_Path = Convert.ToString(drPL_FR_Attachments["Attachment_Path"]);

            }

            else
            {

                this._PK_PL_FR_Attachments_ID = -1;
                this._FK_PL_FR_ID = -1;
                this._Attachment_Type = "";
                this._Description = "";
                this._Attachment_Path = "";

            }

        }



        #endregion


        #region Methods
        /// <summary>
        /// Inserts a record into the PL_FR_Attachments table.
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("PL_FR_AttachmentsInsert");

            db.AddInParameter(dbCommand, "FK_PL_FR_ID", DbType.Decimal, this._FK_PL_FR_ID);
            db.AddInParameter(dbCommand, "Attachment_Type", DbType.String, this._Attachment_Type);
            db.AddInParameter(dbCommand, "Description", DbType.String, this._Description);
            db.AddInParameter(dbCommand, "Attachment_Path", DbType.String, this._Attachment_Path);

            // Execute the query and return the new identity value
            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
        }

        /// <summary>
        /// Selects a single record from the PL_FR_Attachments table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectByPK(decimal pK_PL_FR_Attachments_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("PL_FR_AttachmentsSelectByPK");

            db.AddInParameter(dbCommand, "PK_PL_FR_Attachments_ID", DbType.Decimal, pK_PL_FR_Attachments_ID);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the PL_FR_Attachments table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("PL_FR_AttachmentsSelectAll");

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Updates a record in the PL_FR_Attachments table.
        /// </summary>
        public void Update()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("PL_FR_AttachmentsUpdate");

            db.AddInParameter(dbCommand, "PK_PL_FR_Attachments_ID", DbType.Decimal, this._PK_PL_FR_Attachments_ID);
            db.AddInParameter(dbCommand, "FK_PL_FR_ID", DbType.Decimal, this._FK_PL_FR_ID);
            db.AddInParameter(dbCommand, "Attachment_Type", DbType.String, this._Attachment_Type);
            db.AddInParameter(dbCommand, "Description", DbType.String, this._Description);
            db.AddInParameter(dbCommand, "Attachment_Path", DbType.String, this._Attachment_Path);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Deletes a record from the PL_FR_Attachments table by a composite primary key.
        /// </summary>
        public static void DeleteByPK(decimal pK_PL_FR_Attachments_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("PL_FR_AttachmentsDeleteByPK");

            db.AddInParameter(dbCommand, "PK_PL_FR_Attachments_ID", DbType.Decimal, pK_PL_FR_Attachments_ID);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Selects a single record from the PL_FR_Attachments table by a FR ID
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectByFR_ID(decimal FK_PL_FR_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("PL_FR_AttacmentsSelectByFR_ID");

            db.AddInParameter(dbCommand, "FK_PL_FR_ID", DbType.Decimal, FK_PL_FR_ID);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Deletes a Multiple record from the PL_FR_Attachments table by a composite primary key.
        /// </summary>
        public static void DeleteByMultiIDs(string strIDs)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("PL_FRAttachmentDeleteByIDs");

            db.AddInParameter(dbCommand, "strIDs", DbType.String, strIDs);

            db.ExecuteNonQuery(dbCommand);
        }
        #endregion

    }
}
