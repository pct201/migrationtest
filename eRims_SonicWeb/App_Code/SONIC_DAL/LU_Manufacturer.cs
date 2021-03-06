using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;


namespace ERIMS.DAL
{
    /// <summary>
    /// Data access class for LU_Dealership_Department table.
    /// </summary>
    public sealed class LU_Manufacturer
    {
        #region Fields



        private decimal _PK_LU_Manufacturer;
        private string _Fld_Desc;

        #endregion


        #region Properties



        /// <summary> 
        /// Gets or sets the PK_LU_Dealership_Department value.
        /// </summary>
        public decimal PK_LU_Manufacturer
        {
            get { return _PK_LU_Manufacturer; }
            set { _PK_LU_Manufacturer = value; }
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
        public LU_Manufacturer()
        {


            this._PK_LU_Manufacturer = -1;
            this._Fld_Desc = "";

        }



        /// <summary> 

        /// Initializes a new instance of the LU_Dealership_Department class for passed PrimaryKey with the values set from Database.



        /// </summary>
        public LU_Manufacturer(decimal PK)
        {

            DataTable dtLU_Equipment_Type = SelectByPK(PK).Tables[0];

            if (dtLU_Equipment_Type.Rows.Count > 0)
            {

                DataRow drLU_Equipment_Type = dtLU_Equipment_Type.Rows[0];


                this._PK_LU_Manufacturer = drLU_Equipment_Type["PK_LU_Manufacturer"] != DBNull.Value ? Convert.ToDecimal(drLU_Equipment_Type["PK_LU_Manufacturer"]) : 0;
                this._Fld_Desc = Convert.ToString(drLU_Equipment_Type["Fld_Desc"]);

            }

            else
            {


                this._PK_LU_Manufacturer = -1;
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
            DbCommand dbCommand = db.GetStoredProcCommand("LU_ManufacturerInsert");

            db.AddInParameter(dbCommand, "Fld_Desc", DbType.String, this._Fld_Desc);

            // Execute the query and return the new identity value
            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
        }

        /// <summary>
        /// Selects a single record from the LU_Dealership_Department table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectByPK(decimal pK_LU_Manufacturer)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_ManufacturerSelectByPK");

            db.AddInParameter(dbCommand, "PK_LU_Manufacturer", DbType.Decimal, pK_LU_Manufacturer);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the LU_Dealership_Department table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_ManufacturerSelectAll");

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Updates a record in the LU_Dealership_Department table.
        /// </summary>
        public int Update()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_ManufacturerInsertUpdate");

            db.AddInParameter(dbCommand, "PK_LU_Manufacturer", DbType.Decimal, this._PK_LU_Manufacturer);
            db.AddInParameter(dbCommand, "Fld_Desc", DbType.String, this._Fld_Desc);

            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));
            return returnValue;
        }

        /// <summary>
        /// Deletes a record from the LU_Dealership_Department table by a composite primary key.
        /// </summary>
        public static void DeleteByPK(decimal pK_LU_Manufacturer)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_ManufacturerDeleteByPK");

            db.AddInParameter(dbCommand, "PK_LU_Manufacturer", DbType.Decimal, pK_LU_Manufacturer);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Selects a single record from the LU_Dealership_Department table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet ManufacturerSearch(string fld_Desc)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_ManufacturerSearch");

            db.AddInParameter(dbCommand, "Fld_Desc", DbType.String, fld_Desc);

            return db.ExecuteDataSet(dbCommand);
        }
    }
}