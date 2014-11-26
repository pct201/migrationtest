using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
    /// <summary>
    /// Data access class for LU_Dealership_Department table.
    /// </summary>
    public sealed class LU_Dealership_Department
    {
        #region Fields



        private decimal _PK_LU_Dealership_Department;
        private string _Fld_Desc;

        #endregion

        #region Properties



        /// <summary> 
        /// Gets or sets the PK_LU_Dealership_Department value.
        /// </summary>
        public decimal PK_LU_Dealership_Department
        {
            get { return _PK_LU_Dealership_Department; }
            set { _PK_LU_Dealership_Department = value; }
        }


        /// <summary> 
        /// Gets or sets the Fld_Desc value.
        /// </summary>
        public string Fld_Desc
        {
            get { return _Fld_Desc; }
            set { _Fld_Desc = value; }
        }



        #endregion

        #region Constructors

        /// <summary> 

        /// Initializes a new instance of the LU_Dealership_Department class. with the default value.

        /// </summary>
        public LU_Dealership_Department()
        {
            this._PK_LU_Dealership_Department = -1;
            this._Fld_Desc = "";
        }

        /// <summary> 
        /// Initializes a new instance of the LU_Dealership_Department class for passed PrimaryKey with the values set from Database.
        /// </summary>
        public LU_Dealership_Department(decimal PK)
        {

            DataTable dtLU_Dealership_Department = SelectByPK(PK).Tables[0];

            if (dtLU_Dealership_Department.Rows.Count > 0)
            {
                DataRow drLU_Dealership_Department = dtLU_Dealership_Department.Rows[0];

                this._PK_LU_Dealership_Department = drLU_Dealership_Department["PK_LU_Dealership_Department"] != DBNull.Value ? Convert.ToDecimal(drLU_Dealership_Department["PK_LU_Dealership_Department"]) : 0;
                this._Fld_Desc = Convert.ToString(drLU_Dealership_Department["Fld_Desc"]);
            }

            else
            {
                this._PK_LU_Dealership_Department = -1;
                this._Fld_Desc = "";

            }

        }



        #endregion

        /// <summary>
        /// Inserts a record into the LU_Dealership_Department table.
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_Dealership_DepartmentInsert");

            db.AddInParameter(dbCommand, "Fld_Desc", DbType.String, this._Fld_Desc);

            // Execute the query and return the new identity value
            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
        }

        /// <summary>
        /// Selects a single record from the LU_Dealership_Department table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectByPK(decimal pK_LU_Dealership_Department)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_Dealership_DepartmentSelectByPK");

            db.AddInParameter(dbCommand, "PK_LU_Dealership_Department", DbType.Decimal, pK_LU_Dealership_Department);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the LU_Dealership_Department table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_Dealership_DepartmentSelectAll");

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Updates a record in the LU_Dealership_Department table.
        /// </summary>
        public int Update()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_Dealership_DepartmentUpdate");

            db.AddInParameter(dbCommand, "PK_LU_Dealership_Department", DbType.Decimal, this._PK_LU_Dealership_Department);
            db.AddInParameter(dbCommand, "Fld_Desc", DbType.String, this._Fld_Desc);

            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));
            return returnValue;
        }

        /// <summary>
        /// Deletes a record from the LU_Dealership_Department table by a composite primary key.
        /// </summary>
        public static void DeleteByPK(decimal pK_LU_Dealership_Department)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_Dealership_DepartmentDeleteByPK");

            db.AddInParameter(dbCommand, "PK_LU_Dealership_Department", DbType.Decimal, pK_LU_Dealership_Department);

            db.ExecuteNonQuery(dbCommand);
        }
    }
}
