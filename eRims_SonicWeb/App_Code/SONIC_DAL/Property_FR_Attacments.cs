using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
    /// <summary>
    /// Data access class for Property_FR_Attacments table.
    /// </summary>
    public sealed class Property_FR_Attacments
    {
        #region Fields


        private decimal _PK_Property_FR_Attacments_ID;
        private decimal _FK_Property_FR_ID;
        private string _Attachment_Type;
        private string _Description;
        private string _Attachment_Path;

        #endregion

        #region Properties


        /// <summary> 
        /// Gets or sets the PK_Property_FR_Attacments_ID value.
        /// </summary>
        public decimal PK_Property_FR_Attacments_ID
        {
            get { return _PK_Property_FR_Attacments_ID; }
            set { _PK_Property_FR_Attacments_ID = value; }
        }


        /// <summary> 
        /// Gets or sets the FK_Property_FR_ID value.
        /// </summary>
        public decimal FK_Property_FR_ID
        {
            get { return _FK_Property_FR_ID; }
            set { _FK_Property_FR_ID = value; }
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

        /// Initializes a new instance of the Property_FR_Attacments class. with the default value.

        /// </summary>
        public Property_FR_Attacments()
        {

            this._PK_Property_FR_Attacments_ID = -1;
            this._FK_Property_FR_ID = -1;
            this._Attachment_Type = "";
            this._Description = "";
            this._Attachment_Path = "";

        }



        /// <summary> 

        /// Initializes a new instance of the Property_FR_Attacments class for passed PrimaryKey with the values set from Database.


        /// </summary>
        public Property_FR_Attacments(decimal PK)
        {

            DataTable dtProperty_FR_Attacments = SelectByPK(PK).Tables[0];

            if (dtProperty_FR_Attacments.Rows.Count > 0)
            {

                DataRow drProperty_FR_Attacments = dtProperty_FR_Attacments.Rows[0];

                this._PK_Property_FR_Attacments_ID = drProperty_FR_Attacments["PK_Property_FR_Attacments_ID"] != DBNull.Value ? Convert.ToDecimal(drProperty_FR_Attacments["PK_Property_FR_Attacments_ID"]) : 0;
                this._FK_Property_FR_ID = drProperty_FR_Attacments["FK_Property_FR_ID"] != DBNull.Value ? Convert.ToDecimal(drProperty_FR_Attacments["FK_Property_FR_ID"]) : 0;
                this._Attachment_Type = Convert.ToString(drProperty_FR_Attacments["Attachment_Type"]);
                this._Description = Convert.ToString(drProperty_FR_Attacments["Description"]);
                this._Attachment_Path = Convert.ToString(drProperty_FR_Attacments["Attachment_Path"]);

            }

            else
            {

                this._PK_Property_FR_Attacments_ID = -1;
                this._FK_Property_FR_ID = -1;
                this._Attachment_Type = "";
                this._Description = "";
                this._Attachment_Path = "";

            }

        }



        #endregion

        #region Methods
        /// <summary>
        /// Inserts a record into the Property_FR_Attacments table.
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Property_FR_AttacmentsInsert");

            db.AddInParameter(dbCommand, "FK_Property_FR_ID", DbType.Decimal, this._FK_Property_FR_ID);
            db.AddInParameter(dbCommand, "Attachment_Type", DbType.String, this._Attachment_Type);
            db.AddInParameter(dbCommand, "Description", DbType.String, this._Description);
            db.AddInParameter(dbCommand, "Attachment_Path", DbType.String, this._Attachment_Path);

            // Execute the query and return the new identity value
            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
        }

        /// <summary>
        /// Selects a single record from the Property_FR_Attacments table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectByPK(decimal pK_Property_FR_Attacments_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Property_FR_AttacmentsSelectByPK");

            db.AddInParameter(dbCommand, "PK_Property_FR_Attacments_ID", DbType.Decimal, pK_Property_FR_Attacments_ID);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the Property_FR_Attacments table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Property_FR_AttacmentsSelectAll");

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Updates a record in the Property_FR_Attacments table.
        /// </summary>
        public void Update()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Property_FR_AttacmentsUpdate");

            db.AddInParameter(dbCommand, "PK_Property_FR_Attacments_ID", DbType.Decimal, this._PK_Property_FR_Attacments_ID);
            db.AddInParameter(dbCommand, "FK_Property_FR_ID", DbType.Decimal, this._FK_Property_FR_ID);
            db.AddInParameter(dbCommand, "Attachment_Type", DbType.String, this._Attachment_Type);
            db.AddInParameter(dbCommand, "Description", DbType.String, this._Description);
            db.AddInParameter(dbCommand, "Attachment_Path", DbType.String, this._Attachment_Path);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Deletes a record from the Property_FR_Attacments table by a composite primary key.
        /// </summary>
        public static void DeleteByPK(decimal pK_Property_FR_Attacments_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Property_FR_AttacmentsDeleteByPK");

            db.AddInParameter(dbCommand, "PK_Property_FR_Attacments_ID", DbType.Decimal, pK_Property_FR_Attacments_ID);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Selects a single record from the Property_FR_Attacments table by a FR ID
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectByFR_ID(decimal FK_Property_FR_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Property_FR_AttacmentsSelectByFR_ID");

            db.AddInParameter(dbCommand, "FK_Property_FR_ID", DbType.Decimal, FK_Property_FR_ID);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Deletes a Multiple record from the Property_FR_Attacments table by a composite primary key.
        /// </summary>
        public static void DeleteByMultiIDs(string strIDs)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Property_FRAttachmentDeleteByIDs");

            db.AddInParameter(dbCommand, "strIDs", DbType.String, strIDs);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Select attachments by FK_Porperty_FR_ID
        /// </summary>
        /// <param name="FK_Property_FR_ID"></param>
        /// <returns></returns>
        public static DataSet SelectByFK_Property_FR_ID(decimal FK_Property_FR_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Property_FR_AttacmentsSelectByFK_Property_FR_ID");

            db.AddInParameter(dbCommand, "FK_Property_FR_ID", DbType.Decimal, FK_Property_FR_ID);

            return db.ExecuteDataSet(dbCommand);
        }
        #endregion
    }
}
