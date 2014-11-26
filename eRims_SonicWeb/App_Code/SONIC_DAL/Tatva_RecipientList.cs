using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{

    /// <summary>
    /// Data access class for Tatva_RecipientList table.
    /// </summary>
    public sealed class Tatva_RecipientList
    {
        #region Fields


        private decimal _Pk_RecipientList_ID;
        private string _ListName;
        private string _Updated_By;
        private DateTime _Update_Date;

        #endregion


        #region Properties



        /// <summary> 
        /// Gets or sets the Pk_RecipientList_ID value.
        /// </summary>
        public decimal Pk_RecipientList_ID
        {
            get { return _Pk_RecipientList_ID; }
            set { _Pk_RecipientList_ID = value; }
        }


        /// <summary> 
        /// Gets or sets the ListName value.
        /// </summary>
        public string ListName
        {
            get { return _ListName; }
            set { _ListName = value; }
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
        /// Initializes a new instance of the Tatva_RecipientList class. with the default value.
        /// </summary>
        public Tatva_RecipientList()
        {
            this._Pk_RecipientList_ID = -1;
            this._ListName = "";
            this._Updated_By = "";
            this._Update_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
        }

        /// <summary> 
        /// Initializes a new instance of the Tatva_RecipientList class for passed PrimaryKey with the values set from Database.
        /// </summary>
        public Tatva_RecipientList(decimal PK)
        {

            DataTable dtTatva_RecipientList = SelectByPK(PK).Tables[0];

            if (dtTatva_RecipientList.Rows.Count > 0)
            {

                DataRow drTatva_RecipientList = dtTatva_RecipientList.Rows[0];

                this._Pk_RecipientList_ID = drTatva_RecipientList["Pk_RecipientList_ID"] != DBNull.Value ? Convert.ToDecimal(drTatva_RecipientList["Pk_RecipientList_ID"]) : 0;
                this._ListName = Convert.ToString(drTatva_RecipientList["ListName"]);
                this._Updated_By = Convert.ToString(drTatva_RecipientList["Updated_By"]);
                this._Update_Date = drTatva_RecipientList["Update_Date"] != DBNull.Value ? Convert.ToDateTime(drTatva_RecipientList["Update_Date"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;

            }

            else
            {

                this._Pk_RecipientList_ID = -1;
                this._ListName = "";
                this._Updated_By = "";
                this._Update_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;

            }

        }

        #endregion

        /// <summary>
        /// Inserts a record into the Tatva_RecipientList table.
        /// </summary>
        /// <returns></returns>
        public int InsertUpdate()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Tatva_RecipientListInsertUpdate");

            db.AddInParameter(dbCommand, "RecipientList_ID", DbType.Decimal, this._Pk_RecipientList_ID);
            db.AddInParameter(dbCommand, "ListName", DbType.String, this._ListName);
            db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);
            db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);

            // Execute the query and return the new identity value
            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
        }

        /// <summary>
        /// Selects a single record from the Tatva_RecipientList table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectByPK(decimal pk_RecipientList_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Tatva_RecipientListSelectByPK");

            db.AddInParameter(dbCommand, "Pk_RecipientList_ID", DbType.Decimal, pk_RecipientList_ID);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the Tatva_RecipientList table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Tatva_RecipientListSelectAll");

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Deletes a record from the Tatva_RecipientList table by a composite primary key.
        /// </summary>
        public static void DeleteByPK(decimal pk_RecipientList_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Tatva_RecipientListDeleteByPK");

            db.AddInParameter(dbCommand, "Pk_RecipientList_ID", DbType.Decimal, pk_RecipientList_ID);

            db.ExecuteNonQuery(dbCommand);
        }

        public bool CheckListNameExist(string strListName, decimal PK_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Tatva_RecipientListCheckIsExist");

            db.AddInParameter(dbCommand, "Pk_RecipientList_ID", DbType.Decimal, PK_ID);
            db.AddInParameter(dbCommand, "ListName", DbType.String, strListName);

            Int32 retVal = Convert.ToInt32(db.ExecuteScalar(dbCommand));
            if (retVal == 1)
                return true;
            else
                return false;
        }
    }
}
