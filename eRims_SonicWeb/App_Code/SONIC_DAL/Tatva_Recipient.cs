using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
    /// <summary>
    /// Data access class for Tatva_Recipient table.
    /// </summary>
    public sealed class Tatva_Recipient
    {
        #region Fields

        private decimal _PK_Recipient_ID;
        private string _FirstName;
        private string _MidleName;
        private string _LastName;
        private string _Phone;
        private string _Email;
        private string _Updated_By;
        private DateTime _Update_Date;

        #endregion

        #region Properties

        /// <summary> 
        /// Gets or sets the PK_Recipient_ID value.
        /// </summary>
        public decimal PK_Recipient_ID
        {
            get { return _PK_Recipient_ID; }
            set { _PK_Recipient_ID = value; }
        }

        /// <summary> 
        /// Gets or sets the FirstName value.
        /// </summary>
        public string FirstName
        {
            get { return _FirstName; }
            set { _FirstName = value; }
        }

        /// <summary> 
        /// Gets or sets the MidleName value.
        /// </summary>
        public string MidleName
        {
            get { return _MidleName; }
            set { _MidleName = value; }
        }

        /// <summary> 
        /// Gets or sets the LastName value.
        /// </summary>
        public string LastName
        {
            get { return _LastName; }
            set { _LastName = value; }
        }

        /// <summary> 
        /// Gets or sets the Phone value.
        /// </summary>
        public string Phone
        {
            get { return _Phone; }
            set { _Phone = value; }
        }

        /// <summary> 
        /// Gets or sets the Email value.
        /// </summary>
        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
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
        /// Initializes a new instance of the Tatva_Recipient class. with the default value.
        /// </summary>
        public Tatva_Recipient()
        {
            this._PK_Recipient_ID = -1;
            this._FirstName = "";
            this._MidleName = "";
            this._LastName = "";
            this._Phone = "";
            this._Email = "";
            this._Updated_By = "";
            this._Update_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
        }

        /// <summary> 
        /// Initializes a new instance of the Tatva_Recipient class for passed PrimaryKey with the values set from Database.
        /// </summary>
        public Tatva_Recipient(decimal PK)
        {

            DataTable dtTatva_Recipient = SelectByPK(PK).Tables[0];

            if (dtTatva_Recipient.Rows.Count > 0)
            {

                DataRow drTatva_Recipient = dtTatva_Recipient.Rows[0];

                this._PK_Recipient_ID = drTatva_Recipient["PK_Recipient_ID"] != DBNull.Value ? Convert.ToDecimal(drTatva_Recipient["PK_Recipient_ID"]) : 0;                
                this._FirstName = Convert.ToString(drTatva_Recipient["FirstName"]);
                this._MidleName = Convert.ToString(drTatva_Recipient["MidleName"]);
                this._LastName = Convert.ToString(drTatva_Recipient["LastName"]);
                this._Phone = Convert.ToString(drTatva_Recipient["Phone"]);
                this._Email = Convert.ToString(drTatva_Recipient["Email"]);
                this._Updated_By = Convert.ToString(drTatva_Recipient["Updated_By"]);
                this._Update_Date = drTatva_Recipient["Update_Date"] != DBNull.Value ? Convert.ToDateTime(drTatva_Recipient["Update_Date"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;

            }

            else
            {

                this._PK_Recipient_ID = -1;
                this._FirstName = "";
                this._MidleName = "";
                this._LastName = "";
                this._Phone = "";
                this._Email = "";
                this._Updated_By = "";
                this._Update_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;

            }

        }

        #endregion

        /// <summary>
        /// Inserts or Update a record into the Tatva_Recipient table.
        /// </summary>
        /// <returns></returns>
        public int InsertUpdate()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Tatva_RecipientInsertUpdate");

            db.AddInParameter(dbCommand, "PK_Recipient_ID", DbType.Decimal, this._PK_Recipient_ID);
            db.AddInParameter(dbCommand, "FirstName", DbType.String, this._FirstName);
            db.AddInParameter(dbCommand, "MidleName", DbType.String, this._MidleName);
            db.AddInParameter(dbCommand, "LastName", DbType.String, this._LastName);
            db.AddInParameter(dbCommand, "Phone", DbType.String, this._Phone);
            db.AddInParameter(dbCommand, "Email", DbType.String, this._Email);
            db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);
            db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);

            // Execute the query and return the new identity value
            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
        }

        /// <summary>
        /// Selects a single record from the Tatva_Recipient table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectByPK(decimal pK_Recipient_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Tatva_RecipientSelectByPK");

            db.AddInParameter(dbCommand, "PK_Recipient_ID", DbType.Decimal, pK_Recipient_ID);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the Tatva_Recipient table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Tatva_RecipientSelectAll");

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Deletes a record from the Tatva_Recipient table by a composite primary key.
        /// </summary>
        public static void DeleteByPK(decimal pK_Recipient_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Tatva_RecipientDeleteByPK");

            db.AddInParameter(dbCommand, "PK_Recipient_ID", DbType.Decimal, pK_Recipient_ID);

            db.ExecuteNonQuery(dbCommand);
        }

    }
}
