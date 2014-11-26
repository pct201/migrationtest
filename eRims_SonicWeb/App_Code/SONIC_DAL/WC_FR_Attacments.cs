using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
    /// <summary>
    /// Data access class for WC_FR_Attacments table.
    /// </summary>
    public sealed class WC_FR_Attacments
    {
        #region Fields


        private decimal _PK_WC_FROI_ATTACHMENTS_ID;
        private decimal _FK_WC_FROI_ID;
        private string _Attachment_Type;
        private string _Description;
        private string _Attachment_Path;

        #endregion


        #region Properties


        /// <summary> 
        /// Gets or sets the PK_WC_FROI_ATTACHMENTS_ID value.
        /// </summary>
        public decimal PK_WC_FROI_ATTACHMENTS_ID
        {
            get { return _PK_WC_FROI_ATTACHMENTS_ID; }
            set { _PK_WC_FROI_ATTACHMENTS_ID = value; }
        }


        /// <summary> 
        /// Gets or sets the FK_WC_FROI_ID value.
        /// </summary>
        public decimal FK_WC_FROI_ID
        {
            get { return _FK_WC_FROI_ID; }
            set { _FK_WC_FROI_ID = value; }
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

        /// Initializes a new instance of the WC_FR_Attacments class. with the default value.

        /// </summary>
        public WC_FR_Attacments()
        {

            this._PK_WC_FROI_ATTACHMENTS_ID = -1;
            this._FK_WC_FROI_ID = -1;
            this._Attachment_Type = "";
            this._Description = "";
            this._Attachment_Path = "";

        }



        /// <summary> 

        /// Initializes a new instance of the WC_FR_Attacments class for passed PrimaryKey with the values set from Database.


        /// </summary>
        public WC_FR_Attacments(decimal PK)
        {

            DataTable dtWC_FR_Attacments = SelectByPK(PK).Tables[0];

            if (dtWC_FR_Attacments.Rows.Count > 0)
            {

                DataRow drWC_FR_Attacments = dtWC_FR_Attacments.Rows[0];

                this._PK_WC_FROI_ATTACHMENTS_ID = drWC_FR_Attacments["PK_WC_FROI_ATTACHMENTS_ID"] != DBNull.Value ? Convert.ToDecimal(drWC_FR_Attacments["PK_WC_FROI_ATTACHMENTS_ID"]) : 0;
                this._FK_WC_FROI_ID = drWC_FR_Attacments["FK_WC_FROI_ID"] != DBNull.Value ? Convert.ToDecimal(drWC_FR_Attacments["FK_WC_FROI_ID"]) : 0;
                this._Attachment_Type = Convert.ToString(drWC_FR_Attacments["Attachment_Type"]);
                this._Description = Convert.ToString(drWC_FR_Attacments["Description"]);
                this._Attachment_Path = Convert.ToString(drWC_FR_Attacments["Attachment_Path"]);

            }

            else
            {

                this._PK_WC_FROI_ATTACHMENTS_ID = -1;
                this._FK_WC_FROI_ID = -1;
                this._Attachment_Type = "";
                this._Description = "";
                this._Attachment_Path = "";

            }

        }


        #endregion


        #region Methods
        /// <summary>
        /// Inserts a record into the WC_FR_Attacments table.
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("WC_FR_AttacmentsInsert");

            db.AddInParameter(dbCommand, "FK_WC_FROI_ID", DbType.Decimal, this._FK_WC_FROI_ID);
            db.AddInParameter(dbCommand, "Attachment_Type", DbType.String, this._Attachment_Type);
            db.AddInParameter(dbCommand, "Description", DbType.String, this._Description);
            db.AddInParameter(dbCommand, "Attachment_Path", DbType.String, this._Attachment_Path);

            // Execute the query and return the new identity value
            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
        }

        /// <summary>
        /// Selects a single record from the WC_FR_Attacments table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectByPK(decimal pK_WC_FROI_ATTACHMENTS_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("WC_FR_AttacmentsSelectByPK");

            db.AddInParameter(dbCommand, "PK_WC_FROI_ATTACHMENTS_ID", DbType.Decimal, pK_WC_FROI_ATTACHMENTS_ID);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the WC_FR_Attacments table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("WC_FR_AttacmentsSelectAll");

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Updates a record in the WC_FR_Attacments table.
        /// </summary>
        public void Update()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("WC_FR_AttacmentsUpdate");

            db.AddInParameter(dbCommand, "PK_WC_FROI_ATTACHMENTS_ID", DbType.Decimal, this._PK_WC_FROI_ATTACHMENTS_ID);
            db.AddInParameter(dbCommand, "FK_WC_FROI_ID", DbType.Decimal, this._FK_WC_FROI_ID);
            db.AddInParameter(dbCommand, "Attachment_Type", DbType.String, this._Attachment_Type);
            db.AddInParameter(dbCommand, "Description", DbType.String, this._Description);
            db.AddInParameter(dbCommand, "Attachment_Path", DbType.String, this._Attachment_Path);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Deletes a record from the WC_FR_Attacments table by a composite primary key.
        /// </summary>
        public static void DeleteByPK(decimal pK_WC_FROI_ATTACHMENTS_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("WC_FR_AttacmentsDeleteByPK");

            db.AddInParameter(dbCommand, "PK_WC_FROI_ATTACHMENTS_ID", DbType.Decimal, pK_WC_FROI_ATTACHMENTS_ID);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Selects a single record from the WC_FR_Attacments table by a FROI ID
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectByFROI_ID(decimal FK_WC_FROI_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("WC_FR_AttacmentsSelectByFROI_ID");

            db.AddInParameter(dbCommand, "FK_WC_FROI_ID", DbType.Decimal, FK_WC_FROI_ID);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Deletes a Multiple record from the WC_FR_Attacments table by a composite primary key.
        /// </summary>
        public static void DeleteByMultiIDs(string strIDs)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("WC_FRAttachmentDeleteByIDs");

            db.AddInParameter(dbCommand, "strIDs", DbType.String, strIDs);

            db.ExecuteNonQuery(dbCommand);
        }

        #endregion

        
    }
}
