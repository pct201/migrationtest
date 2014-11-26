using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{

    /// <summary>
    /// Data access class for Tatva_RecipientListMatrix table.
    /// </summary>
    public sealed class Tatva_RecipientListMatrix
    {


        #region Fields


        private decimal _PK_RecipientListMatrix_ID;
        private decimal _FK_RecipientList;
        private decimal _FK_Recipient;
        private string _Updated_By;
        private DateTime _Updated_Date;

        #endregion


        #region Properties


        /// <summary> 
        /// Gets or sets the PK_RecipientListMatrix_ID value.
        /// </summary>
        public decimal PK_RecipientListMatrix_ID
        {
            get { return _PK_RecipientListMatrix_ID; }
            set { _PK_RecipientListMatrix_ID = value; }
        }


        /// <summary> 
        /// Gets or sets the FK_RecipientList value.
        /// </summary>
        public decimal FK_RecipientList
        {
            get { return _FK_RecipientList; }
            set { _FK_RecipientList = value; }
        }


        /// <summary> 
        /// Gets or sets the FK_Recipient value.
        /// </summary>
        public decimal FK_Recipient
        {
            get { return _FK_Recipient; }
            set { _FK_Recipient = value; }
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
        /// Gets or sets the Updated_Date value.
        /// </summary>
        public DateTime Updated_Date
        {
            get { return _Updated_Date; }
            set { _Updated_Date = value; }
        }



        #endregion


        #region Constructors

        /// <summary> 

        /// Initializes a new instance of the Tatva_RecipientListMatrix class. with the default value.

        /// </summary>
        public Tatva_RecipientListMatrix()
        {

            this._PK_RecipientListMatrix_ID = -1;
            this._FK_RecipientList = -1;
            this._FK_Recipient = -1;
            this._Updated_By = "";
            this._Updated_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;

        }



        /// <summary> 

        /// Initializes a new instance of the Tatva_RecipientListMatrix class for passed PrimaryKey with the values set from Database.


        /// </summary>
        public Tatva_RecipientListMatrix(decimal PK)
        {

            DataTable dtTatva_RecipientListMatrix = SelectByPK(PK).Tables[0];

            if (dtTatva_RecipientListMatrix.Rows.Count > 0)
            {

                DataRow drTatva_RecipientListMatrix = dtTatva_RecipientListMatrix.Rows[0];

                this._PK_RecipientListMatrix_ID = drTatva_RecipientListMatrix["PK_RecipientListMatrix_ID"] != DBNull.Value ? Convert.ToDecimal(drTatva_RecipientListMatrix["PK_RecipientListMatrix_ID"]) : 0;
                this._FK_RecipientList = drTatva_RecipientListMatrix["FK_RecipientList"] != DBNull.Value ? Convert.ToDecimal(drTatva_RecipientListMatrix["FK_RecipientList"]) : 0;
                this._FK_Recipient = drTatva_RecipientListMatrix["FK_Recipient"] != DBNull.Value ? Convert.ToDecimal(drTatva_RecipientListMatrix["FK_Recipient"]) : 0;
                this._Updated_By = Convert.ToString(drTatva_RecipientListMatrix["Updated_By"]);
                this._Updated_Date = drTatva_RecipientListMatrix["Updated_Date"] != DBNull.Value ? Convert.ToDateTime(drTatva_RecipientListMatrix["Updated_Date"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;

            }

            else
            {

                this._PK_RecipientListMatrix_ID = -1;
                this._FK_RecipientList = -1;
                this._FK_Recipient = -1;
                this._Updated_By = "";
                this._Updated_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;

            }

        }



        #endregion


        /// <summary>
        /// Inserts a record into the Tatva_RecipientListMatrix table.
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Tatva_RecipientListMatrixInsert");

            db.AddInParameter(dbCommand, "FK_RecipientList", DbType.Decimal, this._FK_RecipientList);
            db.AddInParameter(dbCommand, "FK_Recipient", DbType.Decimal, this._FK_Recipient);
            db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);
            db.AddInParameter(dbCommand, "Updated_Date", DbType.DateTime, this._Updated_Date);

            // Execute the query and return the new identity value
            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
        }

        /// <summary>
        /// Selects a single record from the Tatva_RecipientListMatrix table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectByPK(decimal pK_RecipientListMatrix_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Tatva_RecipientListMatrixSelectByPK");

            db.AddInParameter(dbCommand, "PK_RecipientListMatrix_ID", DbType.Decimal, pK_RecipientListMatrix_ID);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects records from the Tatva_RecipientListMatrix table by a foreign key.
        /// </summary>
        /// <param name="fK_Recipient"></param>
        /// <returns>DataSet</returns>
        public static DataSet SelectByFK_Recipient(decimal fK_Recipient)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Tatva_RecipientListMatrixSelectByFK_Recipient");

            db.AddInParameter(dbCommand, "FK_Recipient", DbType.Decimal, fK_Recipient);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects records from the Tatva_RecipientListMatrix table by a foreign key.
        /// </summary>
        /// <param name="fK_RecipientList"></param>
        /// <returns>DataSet</returns>
        public static DataSet SelectByFK_RecipientList(decimal fK_RecipientList)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Tatva_RecipientListMatrixSelectByFK_RecipientList");

            db.AddInParameter(dbCommand, "FK_RecipientList", DbType.Decimal, fK_RecipientList);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the Tatva_RecipientListMatrix table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Tatva_RecipientListMatrixSelectAll");

            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet SelectAllRecordWithRecipientList(decimal fK_RecipientList)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Tatva_RecipientListMatrixSelectAllWithRecipientList");

            db.AddInParameter(dbCommand, "FK_RecipientList", DbType.Decimal, fK_RecipientList);

            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet SelectOneRecordWithRecipientList(decimal fK_RecipientList)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Tatva_RecipientListMatrixSelectWithRecipientList");

            db.AddInParameter(dbCommand, "FK_RecipientList", DbType.Decimal, fK_RecipientList);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Updates a record in the Tatva_RecipientListMatrix table.
        /// </summary>
        public void Update()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Tatva_RecipientListMatrixUpdate");

            db.AddInParameter(dbCommand, "PK_RecipientListMatrix_ID", DbType.Decimal, this._PK_RecipientListMatrix_ID);
            db.AddInParameter(dbCommand, "FK_RecipientList", DbType.Decimal, this._FK_RecipientList);
            db.AddInParameter(dbCommand, "FK_Recipient", DbType.Decimal, this._FK_Recipient);
            db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);
            db.AddInParameter(dbCommand, "Updated_Date", DbType.DateTime, this._Updated_Date);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Deletes a record from the Tatva_RecipientListMatrix table by a composite primary key.
        /// </summary>
        public static void DeleteByPK(decimal pK_RecipientListMatrix_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Tatva_RecipientListMatrixDeleteByPK");

            db.AddInParameter(dbCommand, "PK_RecipientListMatrix_ID", DbType.Decimal, pK_RecipientListMatrix_ID);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Deletes a record from the Tatva_RecipientListMatrix table by a foreign key.
        /// </summary>
        public static void DeleteByFK_Recipient(decimal fK_Recipient)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Tatva_RecipientListMatrixDeleteByFK_Recipient");

            db.AddInParameter(dbCommand, "FK_Recipient", DbType.Decimal, fK_Recipient);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Deletes a record from the Tatva_RecipientListMatrix table by a foreign key.
        /// </summary>
        public static void DeleteByFK_RecipientList(decimal fK_RecipientList)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Tatva_RecipientListMatrixDeleteByFK_RecipientList");

            db.AddInParameter(dbCommand, "FK_RecipientList", DbType.Decimal, fK_RecipientList);

            db.ExecuteNonQuery(dbCommand);
        }
    }
}
