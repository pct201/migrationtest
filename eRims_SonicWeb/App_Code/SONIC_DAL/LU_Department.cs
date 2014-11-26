using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for LU_Department table.
	/// </summary>
	public sealed class LU_Department
    {
        #region Fields

        private decimal _PK_LU_Department_ID;
        private decimal _Department_number;
        private string _Description;

        #endregion


        #region Properties

        /// <summary> 
        /// Gets or sets the PK_LU_Department_ID value.
        /// </summary>
        public decimal PK_LU_Department_ID
        {
            get { return _PK_LU_Department_ID; }
            set { _PK_LU_Department_ID = value; }
        }


        /// <summary> 
        /// Gets or sets the Department Number value.
        /// </summary>
        public decimal Department_number
        {
            get { return _Department_number; }
            set { _Department_number = value; }
        }


        /// <summary> 
        /// Gets or sets the Description value.
        /// </summary>
        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }



        #endregion


        #region Constructors

        /// <summary> 

        /// Initializes a new instance of the LU_Department class. with the default value.

        /// </summary>
        public LU_Department()
        {

            this._PK_LU_Department_ID = -1;
            this._Department_number = -1;
            this._Description = "";

        }



        /// <summary> 

        /// Initializes a new instance of the LU_Department class for passed PrimaryKey with the values set from Database.


        /// </summary>
        public LU_Department(decimal PK)
        {

            DataTable dtLU_Department = SelectByPK(PK).Tables[0];

            if (dtLU_Department.Rows.Count > 0)
            {

                DataRow drLU_Department = dtLU_Department.Rows[0];

                this._PK_LU_Department_ID = drLU_Department["PK_LU_Department_ID"] != DBNull.Value ? Convert.ToDecimal(drLU_Department["PK_LU_Department_ID"]) : 0;
                this._Department_number = drLU_Department["Department_number"] != DBNull.Value ? Convert.ToDecimal(drLU_Department["Department_number"]) : 0; 
                this._Description = Convert.ToString(drLU_Department["Description"]);

            }

            else
            {

                this._PK_LU_Department_ID = -1;
                this._Department_number = -1;
                this._Description = "";

            }

        }



        #endregion


        #region Methods
        /// <summary>
        /// Inserts a record into the LU_Department table.
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_DepartmentInsert");

            db.AddInParameter(dbCommand, "Department_number", DbType.Decimal, this._Department_number);
            db.AddInParameter(dbCommand, "Description", DbType.String, this._Description);

            // Execute the query and return the new identity value
            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
        }

        /// <summary>
        /// Selects a single record from the LU_Department table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectByPK(decimal pK_LU_Department_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_DepartmentSelectByPK");

            db.AddInParameter(dbCommand, "PK_LU_Department_ID", DbType.Decimal, pK_LU_Department_ID);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the LU_Department table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_DepartmentSelectAll");

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the LU_Department table by FK_LU_Dealership_Department.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAll_SC_Department(decimal FK_LU_Dealership_Department, decimal FK_Purchasing_Service_Contract)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_DepartmentSelectAll_SC");
            db.AddInParameter(dbCommand, "FK_LU_Dealership_Department", DbType.Decimal, FK_LU_Dealership_Department);
            db.AddInParameter(dbCommand, "FK_Purchasing_Service_Contract", DbType.Decimal, FK_Purchasing_Service_Contract);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Updates a record in the LU_Department table.
        /// </summary>
        public void Update()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_DepartmentUpdate");

            db.AddInParameter(dbCommand, "PK_LU_Department_ID", DbType.Decimal, this._PK_LU_Department_ID);
            db.AddInParameter(dbCommand, "Department_number", DbType.Decimal, this._Department_number);
            db.AddInParameter(dbCommand, "Description", DbType.String, this._Description);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Deletes a record from the LU_Department table by a composite primary key.
        /// </summary>
        public static void DeleteByPK(decimal pK_LU_Department_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_DepartmentDeleteByPK");

            db.AddInParameter(dbCommand, "PK_LU_Department_ID", DbType.Decimal, pK_LU_Department_ID);

            db.ExecuteNonQuery(dbCommand);
        }
        

        #endregion

        
	}
}
