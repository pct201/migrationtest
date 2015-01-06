using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
    /// <summary>
    /// Data access class for Assoc_Attachment_Rights table.
    /// </summary>
    public sealed class clsAssoc_Attachment_Rights
    {

        #region Private variables used to hold the property values

        private decimal? _PK_Assoc_Attachment_Rights;
        private decimal? _FK_User_ID;
        private decimal? _FK_Attachment_Right;

        #endregion

        #region Public Property

        /// <summary>
        /// Gets or sets the PK_Assoc_Attachment_Rights value.
        /// </summary>
        public decimal? PK_Assoc_Attachment_Rights
        {
            get { return _PK_Assoc_Attachment_Rights; }
            set { _PK_Assoc_Attachment_Rights = value; }
        }

        /// <summary>
        /// Gets or sets the FK_User_ID value.
        /// </summary>
        public decimal? FK_User_ID
        {
            get { return _FK_User_ID; }
            set { _FK_User_ID = value; }
        }

        /// <summary>
        /// Gets or sets the FK_Attachment_Right value.
        /// </summary>
        public decimal? FK_Attachment_Right
        {
            get { return _FK_Attachment_Right; }
            set { _FK_Attachment_Right = value; }
        }


        #endregion

        #region Default Constructors

        /// <summary>
        /// Initializes a new instance of the clsAssoc_Attachment_Rights class with default value.
        /// </summary>
        public clsAssoc_Attachment_Rights()
        {


        }

        #endregion

        #region Primary Constructors

        /// <summary>
        /// Initializes a new instance of the clsAssoc_Attachment_Rights class based on Primary Key.
        /// </summary>
        public clsAssoc_Attachment_Rights(decimal pK_Assoc_Attachment_Rights)
        {
            DataTable dtAssoc_Attachment_Rights = SelectByPK(pK_Assoc_Attachment_Rights).Tables[0];

            if (dtAssoc_Attachment_Rights.Rows.Count == 1)
            {
                SetValue(dtAssoc_Attachment_Rights.Rows[0]);

            }

        }


        /// <summary>
        /// Initializes a new instance of the clsAssoc_Attachment_Rights class based on Datarow passed.
        /// </summary>
        private void SetValue(DataRow drAssoc_Attachment_Rights)
        {
            if (drAssoc_Attachment_Rights["PK_Assoc_Attachment_Rights"] == DBNull.Value)
                this._PK_Assoc_Attachment_Rights = null;
            else
                this._PK_Assoc_Attachment_Rights = (decimal?)drAssoc_Attachment_Rights["PK_Assoc_Attachment_Rights"];

            if (drAssoc_Attachment_Rights["FK_User_ID"] == DBNull.Value)
                this._FK_User_ID = null;
            else
                this._FK_User_ID = (decimal?)drAssoc_Attachment_Rights["FK_User_ID"];

            if (drAssoc_Attachment_Rights["FK_Attachment_Right"] == DBNull.Value)
                this._FK_Attachment_Right = null;
            else
                this._FK_Attachment_Right = (decimal?)drAssoc_Attachment_Rights["FK_Attachment_Right"];


        }

        #endregion

        /// <summary>
        /// Inserts a record into the Assoc_Attachment_Rights table.
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Assoc_Attachment_RightsInsert");


            db.AddInParameter(dbCommand, "FK_User_ID", DbType.Decimal, this._FK_User_ID);

            db.AddInParameter(dbCommand, "FK_Attachment_Right", DbType.Decimal, this._FK_Attachment_Right);

            // Execute the query and return the new identity value
            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
        }

        /// <summary>
        /// Selects a single record from the Assoc_Attachment_Rights table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        private DataSet SelectByPK(decimal pK_Assoc_Attachment_Rights)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Assoc_Attachment_RightsSelectByPK");

            db.AddInParameter(dbCommand, "PK_Assoc_Attachment_Rights", DbType.Decimal, pK_Assoc_Attachment_Rights);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the Assoc_Attachment_Rights table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Assoc_Attachment_RightsSelectAll");

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Updates a record in the Assoc_Attachment_Rights table.
        /// </summary>
        public void Update()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Assoc_Attachment_RightsUpdate");


            db.AddInParameter(dbCommand, "PK_Assoc_Attachment_Rights", DbType.Decimal, this._PK_Assoc_Attachment_Rights);

            db.AddInParameter(dbCommand, "FK_User_ID", DbType.Decimal, this._FK_User_ID);

            db.AddInParameter(dbCommand, "FK_Attachment_Right", DbType.Decimal, this._FK_Attachment_Right);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Deletes a record from the Assoc_Attachment_Rights table by a composite primary key.
        /// </summary>
        public static void DeleteByPK(decimal pK_Assoc_Attachment_Rights)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Assoc_Attachment_RightsDeleteByPK");

            db.AddInParameter(dbCommand, "PK_Assoc_Attachment_Rights", DbType.Decimal, pK_Assoc_Attachment_Rights);

            db.ExecuteNonQuery(dbCommand);
        }

        public static void DeleteByFK(decimal FK_User_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Assoc_Attachment_RightsDeleteByFK");

            db.AddInParameter(dbCommand, "FK_User_ID", DbType.Decimal, FK_User_ID);

            db.ExecuteNonQuery(dbCommand);
        }

        public static DataSet SelectByFK(decimal FK_User_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Assoc_Attachment_RightsSelectByFK");

            db.AddInParameter(dbCommand, "FK_User_ID", DbType.Decimal, FK_User_ID);

            return db.ExecuteDataSet(dbCommand);
        }
        
    }
}
