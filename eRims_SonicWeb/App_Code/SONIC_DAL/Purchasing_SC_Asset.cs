using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
    /// <summary>
    /// Data access class for Investigation table.
    /// </summary>
    public sealed class Purchasing_SC_Asset
    {
        #region Fields
        private decimal pK_Purchasing_SC_Asset;
        private decimal fK_Purchasing_Service_Contract;
        private decimal fK_Purchasing_Asset;
        private string updated_By;
        private DateTime update_Date;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the Purchasing_SC_Asset class.
        /// </summary>
        public Purchasing_SC_Asset()
        {
        }

        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the PK_Purchasing_SC_Asset value.
        /// </summary>
        public decimal PK_Purchasing_SC_Asset
        {
            get { return pK_Purchasing_SC_Asset; }
            set { pK_Purchasing_SC_Asset = value; }
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
        /// Gets or sets the FK_Purchasing_Asset value.
        /// </summary>
        public decimal FK_Purchasing_Asset
        {
            get { return fK_Purchasing_Asset; }
            set { fK_Purchasing_Asset = value; }
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
        /// Inserts a record into the Purchasing_SC_Asset table.
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Purchasing_SC_AssetInsert");

            db.AddInParameter(dbCommand, "FK_Purchasing_Service_Contract", DbType.Decimal, fK_Purchasing_Service_Contract);
            db.AddInParameter(dbCommand, "FK_Purchasing_Asset", DbType.Decimal, fK_Purchasing_Asset);
            db.AddInParameter(dbCommand, "Updated_By", DbType.String, updated_By);
            db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, update_Date);

            // Execute the query and return the new identity value
            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
        }

        /// <summary>
        /// Updates a record in the Purchasing_SC_Asset table.
        /// </summary>
        public void Update()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Purchasing_SC_AssetUpdate");

            db.AddInParameter(dbCommand, "PK_Purchasing_SC_Asset", DbType.Decimal, pK_Purchasing_SC_Asset);
            db.AddInParameter(dbCommand, "FK_Purchasing_Service_Contract", DbType.Decimal, fK_Purchasing_Service_Contract);
            db.AddInParameter(dbCommand, "FK_Purchasing_Asset", DbType.Decimal, fK_Purchasing_Asset);
            db.AddInParameter(dbCommand, "Updated_By", DbType.String, updated_By);
            db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, update_Date);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Selects a single record from the Purchasing_SC_Asset table by a foriegn key.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectByFK_Service_Contract(decimal FK_Purchasing_Service_Contract,string strSortBy)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Purchasing_SC_AssetSelectByFK_SC");

            db.AddInParameter(dbCommand, "FK_Purchasing_Service_Contract", DbType.Decimal, FK_Purchasing_Service_Contract);
            db.AddInParameter(dbCommand, "strSortBy", DbType.String, strSortBy);

            return db.ExecuteDataSet(dbCommand);
        }


        /// <summary>
        /// Selects a single record from the Purchasing_SC_Asset table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectByPK(decimal pK_Purchasing_SC_Asset)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Purchasing_SC_AssetSelectByPK");

            db.AddInParameter(dbCommand, "PK_Purchasing_SC_Asset", DbType.Decimal, pK_Purchasing_SC_Asset);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Deletes a record from the Purchasing_SC_Asset table by a composite primary key.
        /// </summary>
        public static void DeleteByPK(decimal pK_Purchasing_SC_Asset)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Purchasing_SC_AssetDeleteByPK");

            db.AddInParameter(dbCommand, "PK_Purchasing_SC_Asset", DbType.Decimal, pK_Purchasing_SC_Asset);

            db.ExecuteNonQuery(dbCommand);
        }

        #endregion
    }
}
