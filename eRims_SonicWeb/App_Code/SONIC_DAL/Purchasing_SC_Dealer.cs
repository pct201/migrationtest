using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
    /// <summary>
    /// Data access class for Investigation table.
    /// </summary>
    public sealed class Purchasing_SC_Dealer
    {
        #region Fields
        private decimal pK_Purchasing_SC_Dealer;
        private decimal fK_Purchasing_Service_Contract;
        private decimal fK_LU_Location_Id;
        private string updated_By;
        private DateTime update_Date;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the Purchasing_SC_Dealer class.
        /// </summary>
        public Purchasing_SC_Dealer()
        {
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the PK_Purchasing_SC_Dealer value.
        /// </summary>
        public decimal PK_Purchasing_SC_Dealer
        {
            get { return pK_Purchasing_SC_Dealer; }
            set { pK_Purchasing_SC_Dealer = value; }
        }

        /// <summary>
        /// Gets or sets the FK_Purchasing_Service_Contract value.
        /// </summary>
        public decimal FK_Purchasing_Service_Contract
        {
            get { return fK_Purchasing_Service_Contract; }
            set { fK_Purchasing_Service_Contract = value; }
        }

        /// <summary>
        /// Gets or sets the FK_LU_Location_Id value.
        /// </summary>
        public decimal FK_LU_Location_Id
        {
            get { return fK_LU_Location_Id; }
            set { fK_LU_Location_Id = value; }
        }

        /// <summary>
        /// Gets or sets the Updated_By value.
        /// </summary>
        public string Updated_By
        {
            get { return updated_By; }
            set { updated_By = value; }
        }

        /// <summary>
        /// Gets or sets the Update_Date value.
        /// </summary>
        public DateTime Update_Date
        {
            get { return update_Date; }
            set { update_Date = value; }
        }
        #endregion		

        #region "Method"

        /// <summary>
        /// Inserts a record into the Purchasing_SC_Dealer table.
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Purchasing_SC_DealerInsert");

            db.AddInParameter(dbCommand, "FK_Purchasing_Service_Contract", DbType.Decimal,fK_Purchasing_Service_Contract);
            db.AddInParameter(dbCommand, "FK_LU_Location_Id", DbType.Decimal, fK_LU_Location_Id);
            db.AddInParameter(dbCommand, "Updated_By", DbType.String, updated_By);
            db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, update_Date);

            // Execute the query and return the new identity value
            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
        }

        /// <summary>
        /// Selects a single record from the Purchasing_SC_Dealer table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectByServiceContract(decimal pK_Purchasing_SC_Dealer,string strSortBy)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Purchasing_SC_DealerSelectByServiceContract");

            db.AddInParameter(dbCommand, "PK_Purchasing_SC_Dealer", DbType.Decimal, pK_Purchasing_SC_Dealer);
            db.AddInParameter(dbCommand, "strSortBy", DbType.String, strSortBy);
            db.AddInParameter(dbCommand, "PK_Security_ID", DbType.Decimal, Convert.ToDecimal(clsSession.UserID));
            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Deletes a record from the Purchasing_SC_Dealer table by a composite primary key.
        /// </summary>
        public static void DeleteByPK(decimal pK_Purchasing_SC_Dealer)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Purchasing_SC_DealerDeleteByPK");

            db.AddInParameter(dbCommand, "PK_Purchasing_SC_Dealer", DbType.Decimal, pK_Purchasing_SC_Dealer);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Selects a single record from the Purchasing_SC_Dealer table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectByPK(decimal pK_Purchasing_SC_Dealer)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Purchasing_SC_DealerSelectByPK");

            db.AddInParameter(dbCommand, "PK_Purchasing_SC_Dealer", DbType.Decimal, pK_Purchasing_SC_Dealer);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Updates a record in the Purchasing_SC_Dealer table.
        /// </summary>
        public void Update()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Purchasing_SC_DealerUpdate");

            db.AddInParameter(dbCommand, "PK_Purchasing_SC_Dealer", DbType.Decimal, pK_Purchasing_SC_Dealer);
            db.AddInParameter(dbCommand, "FK_Purchasing_Service_Contract", DbType.Decimal,fK_Purchasing_Service_Contract);
            db.AddInParameter(dbCommand, "FK_LU_Location_Id", DbType.Decimal, fK_LU_Location_Id);
            db.AddInParameter(dbCommand, "Updated_By", DbType.String, updated_By);
            db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, update_Date);

            db.ExecuteNonQuery(dbCommand);
        }

        #endregion
    }
}
