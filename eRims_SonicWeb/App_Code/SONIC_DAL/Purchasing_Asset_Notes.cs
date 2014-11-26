using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;


namespace ERIMS.DAL
{



    /// <summary>
    /// Data access class for Purchasing_Asset_Notes table.
    /// </summary>
    public sealed class Purchasing_Asset_Notes
    {
        #region Fields


        private decimal _PK_Purchasing_Asset_Notes;
        private decimal _FK_Purchasing_Service_Contract;
        private DateTime _Note_Date;
        private string _Note;
        private string _Updated_By;
        private DateTime _Update_Date;

        #endregion


        #region Properties



        /// <summary> 
        /// Gets or sets the PK_Purchasing_Asset_Notes value.
        /// </summary>
        public decimal PK_Purchasing_Asset_Notes
        {
            get { return _PK_Purchasing_Asset_Notes; }
            set { _PK_Purchasing_Asset_Notes = value; }
        }


        /// <summary> 
        /// Gets or sets the FK_Purchasing_Service_Contract value.
        /// </summary>
        public decimal FK_Purchasing_Service_Contract
        {
            get { return _FK_Purchasing_Service_Contract; }
            set { _FK_Purchasing_Service_Contract = value; }
        }


        /// <summary> 
        /// Gets or sets the Note_Date value.
        /// </summary>
        public DateTime Note_Date
        {
            get { return _Note_Date; }
            set { _Note_Date = value; }
        }


        /// <summary> 
        /// Gets or sets the Note value.
        /// </summary>
        public string Note
        {
            get { return _Note; }
            set { _Note = value; }
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

        /// Initializes a new instance of the Purchasing_Asset_Notes class. with the default value.

        /// </summary>
        public Purchasing_Asset_Notes()
        {

            this._PK_Purchasing_Asset_Notes = -1;
            this._FK_Purchasing_Service_Contract = -1;
            this._Note_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            this._Note = "";
            this._Updated_By = "";
            this._Update_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;

        }



        /// <summary> 

        /// Initializes a new instance of the Purchasing_Asset_Notes class for passed PrimaryKey with the values set from Database.



        /// </summary>
        public Purchasing_Asset_Notes(decimal PK)
        {

            DataTable dtPurchasing_Asset_Notes = SelectByPK(PK).Tables[0];

            if (dtPurchasing_Asset_Notes.Rows.Count > 0)
            {

                DataRow drPurchasing_Asset_Notes = dtPurchasing_Asset_Notes.Rows[0];


                this._PK_Purchasing_Asset_Notes = drPurchasing_Asset_Notes["PK_Purchasing_Asset_Notes"] != DBNull.Value ? Convert.ToDecimal(drPurchasing_Asset_Notes["PK_Purchasing_Asset_Notes"]) : 0;
                this._FK_Purchasing_Service_Contract = drPurchasing_Asset_Notes["FK_Purchasing_Service_Contract"] != DBNull.Value ? Convert.ToDecimal(drPurchasing_Asset_Notes["FK_Purchasing_Service_Contract"]) : 0;
                this._Note_Date = drPurchasing_Asset_Notes["Note_Date"] != DBNull.Value ? Convert.ToDateTime(drPurchasing_Asset_Notes["Note_Date"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Note = Convert.ToString(drPurchasing_Asset_Notes["Note"]);
                this._Updated_By = Convert.ToString(drPurchasing_Asset_Notes["Updated_By"]);
                this._Update_Date = drPurchasing_Asset_Notes["Update_Date"] != DBNull.Value ? Convert.ToDateTime(drPurchasing_Asset_Notes["Update_Date"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;

            }

            else
            {


                this._PK_Purchasing_Asset_Notes = -1;
                this._FK_Purchasing_Service_Contract = -1;
                this._Note_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Note = "";
                this._Updated_By = "";
                this._Update_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;

            }
        }



        #endregion
        #region"Methods"


        /// <summary>
        /// Inserts a record into the Purchasing_Asset_Notes table.
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Purchasing_Asset_NotesInsert");

            db.AddInParameter(dbCommand, "FK_Purchasing_Service_Contract", DbType.Decimal, this._FK_Purchasing_Service_Contract);
            db.AddInParameter(dbCommand, "Note_Date", DbType.DateTime, this._Note_Date);
            db.AddInParameter(dbCommand, "Note", DbType.String, this._Note);
            db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);
            db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);

            // Execute the query and return the new identity value
            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
        }

        /// <summary>
        /// Selects a single record from the Purchasing_Asset_Notes table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectByPK(decimal pK_Purchasing_Asset_Notes)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Purchasing_Asset_NotesSelectByPK");

            db.AddInParameter(dbCommand, "PK_Purchasing_Asset_Notes", DbType.Decimal, pK_Purchasing_Asset_Notes);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects a single record from the Purchasing_Asset_Notes table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectByFK(decimal fK_Purchasing_Service_Contract)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Purchasing_Asset_NotesSelectByFK");

            db.AddInParameter(dbCommand, "FK_Purchasing_Service_Contract", DbType.Decimal, fK_Purchasing_Service_Contract);

            return db.ExecuteDataSet(dbCommand);
        }
        /// <summary>
        /// Selects all records from the Purchasing_Asset_Notes table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Purchasing_Asset_NotesSelectAll");

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Updates a record in the Purchasing_Asset_Notes table.
        /// </summary>
        public void Update()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Purchasing_Asset_NotesUpdate");

            db.AddInParameter(dbCommand, "PK_Purchasing_Asset_Notes", DbType.Decimal, this._PK_Purchasing_Asset_Notes);
            db.AddInParameter(dbCommand, "FK_Purchasing_Service_Contract", DbType.Decimal, this._FK_Purchasing_Service_Contract);
            db.AddInParameter(dbCommand, "Note_Date", DbType.DateTime, this._Note_Date);
            db.AddInParameter(dbCommand, "Note", DbType.String, this._Note);
            db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);
            db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Deletes a record from the Purchasing_Asset_Notes table by a composite primary key.
        /// </summary>
        public static void DeleteByPK(decimal pK_Purchasing_Asset_Notes)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Purchasing_Asset_NotesDeleteByPK");

            db.AddInParameter(dbCommand, "PK_Purchasing_Asset_Notes", DbType.Decimal, pK_Purchasing_Asset_Notes);

            db.ExecuteNonQuery(dbCommand);
        }

    }
        #endregion
}

