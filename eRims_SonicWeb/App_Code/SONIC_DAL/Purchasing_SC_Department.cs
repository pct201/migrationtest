using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
    /// <summary>
    /// Data access class for Investigation table.
    /// </summary>
    public sealed class Purchasing_SC_Department
    {
        #region Fields
        private decimal pK_Purchasing_SC_Department;
        private decimal fK_Purchasing_Service_Contract;
        private decimal fK_LU_Dealership_Department;
        private string updated_By;
        private DateTime update_Date;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the Purchasing_SC_Department class.
        /// </summary>
        public Purchasing_SC_Department()
        {
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the PK_Purchasing_SC_Department value.
        /// </summary>
        public decimal PK_Purchasing_SC_Department
        {
            get { return pK_Purchasing_SC_Department; }
            set { pK_Purchasing_SC_Department = value; }
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
        /// Gets or sets the FK_LU_Dealership_Department value.
        /// </summary>
        public decimal FK_LU_Dealership_Department
        {
            get { return fK_LU_Dealership_Department; }
            set { fK_LU_Dealership_Department = value; }
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

        #region "Methods"

        /// <summary>
        /// Inserts a record into the Purchasing_SC_Department table.
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Purchasing_SC_DepartmentInsert");

            db.AddInParameter(dbCommand, "FK_Purchasing_Service_Contract", DbType.Decimal, fK_Purchasing_Service_Contract);
            db.AddInParameter(dbCommand, "FK_LU_Dealership_Department", DbType.Decimal, fK_LU_Dealership_Department);
            db.AddInParameter(dbCommand, "Updated_By", DbType.String, this.updated_By);
            db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this.update_Date);

            // Execute the query and return the new identity value
            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
        }

        /// <summary>
        /// Selects all records from the Purchasing_SC_Department table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAllByServiceContract(int _fK_Purchasing_Service_Contract, string strSortBy)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Purchasing_SC_DepartmentSelectBySC");

            db.AddInParameter(dbCommand, "FK_Purchasing_Service_Contract", DbType.Decimal, _fK_Purchasing_Service_Contract);
            db.AddInParameter(dbCommand, "strSortBy", DbType.String, strSortBy);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Deletes a record from the Purchasing_SC_Department table by a composite primary key.
        /// </summary>
        public static void DeleteByPK(decimal pK_Purchasing_SC_Department)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Purchasing_SC_DepartmentDeleteByPK");

            db.AddInParameter(dbCommand, "PK_Purchasing_SC_Department", DbType.Decimal, pK_Purchasing_SC_Department);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Selects a single record from the Purchasing_SC_Department table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectByPK(decimal pK_Purchasing_SC_Department)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Purchasing_SC_DepartmentSelectByPK");

            db.AddInParameter(dbCommand, "PK_Purchasing_SC_Department", DbType.Decimal, pK_Purchasing_SC_Department);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Updates a record in the Purchasing_SC_Department table.
        /// </summary>
        public void Update()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Purchasing_SC_DepartmentUpdate");

            db.AddInParameter(dbCommand, "PK_Purchasing_SC_Department", DbType.Decimal, this.pK_Purchasing_SC_Department);
            db.AddInParameter(dbCommand, "FK_Purchasing_Service_Contract", DbType.Decimal, fK_Purchasing_Service_Contract);
            db.AddInParameter(dbCommand, "FK_LU_Dealership_Department", DbType.Decimal, fK_LU_Dealership_Department);
            db.AddInParameter(dbCommand, "Updated_By", DbType.String, updated_By);
            db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, update_Date);

            db.ExecuteNonQuery(dbCommand);
        }

        #endregion
    }
}
