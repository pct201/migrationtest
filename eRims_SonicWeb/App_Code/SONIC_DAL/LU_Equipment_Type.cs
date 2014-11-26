using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;



namespace ERIMS.DAL
{
    /// <summary>
    /// Data access class for LU_Dealership_Department table.
    /// </summary>
    public sealed class LU_Equipment_Type
    {
        #region Fields



        private decimal _PK_LU_Equipment_Type;
        private string _Fld_Desc;

        #endregion


        #region Properties



        /// <summary> 
        /// Gets or sets the PK_LU_Dealership_Department value.
        /// </summary>
        public decimal PK_LU_Equipment_Type
        {
            get { return _PK_LU_Equipment_Type; }
            set { _PK_LU_Equipment_Type = value; }
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
        public LU_Equipment_Type()
        {


            this._PK_LU_Equipment_Type = -1;
            this._Fld_Desc = "";

        }



        /// <summary> 

        /// Initializes a new instance of the LU_Dealership_Department class for passed PrimaryKey with the values set from Database.



        /// </summary>
        public LU_Equipment_Type(decimal PK)
        {

            DataTable dtLU_Equipment_Type = SelectByPK(PK).Tables[0];

            if (dtLU_Equipment_Type.Rows.Count > 0)
            {

                DataRow drLU_Equipment_Type = dtLU_Equipment_Type.Rows[0];


                this._PK_LU_Equipment_Type = drLU_Equipment_Type["PK_LU_Equipment_Type"] != DBNull.Value ? Convert.ToDecimal(drLU_Equipment_Type["PK_LU_Equipment_Type"]) : 0;
                this._Fld_Desc = Convert.ToString(drLU_Equipment_Type["Fld_Desc"]);

            }

            else
            {


                this._PK_LU_Equipment_Type = -1;
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
            DbCommand dbCommand = db.GetStoredProcCommand("LU_Equipment_TypeInsert");

            db.AddInParameter(dbCommand, "Fld_Desc", DbType.String, this._Fld_Desc);

            // Execute the query and return the new identity value
            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
        }

        /// <summary>
        /// Selects a single record from the LU_Dealership_Department table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectByPK(decimal pK_LU_Equipment_Type)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_Equipment_TypeSelectByPK");

            db.AddInParameter(dbCommand, "PK_LU_Equipment_Type", DbType.Decimal, pK_LU_Equipment_Type);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the LU_Dealership_Department table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_Equipment_TypeSelectAll");

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Updates a record in the LU_Dealership_Department table.
        /// </summary>
        public int Update()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_Equipment_TypeInsertUpdate");

            db.AddInParameter(dbCommand, "PK_LU_Equipment_Type", DbType.Decimal, this._PK_LU_Equipment_Type);
            db.AddInParameter(dbCommand, "Fld_Desc", DbType.String, this._Fld_Desc);

            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));
            return returnValue;
        }

        /// <summary>
        /// Deletes a record from the LU_Dealership_Department table by a composite primary key.
        /// </summary>
        public static void DeleteByPK(decimal pK_LU_Equipment_Type)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_Equipment_TypeDeleteByPK");

            db.AddInParameter(dbCommand, "PK_LU_Equipment_Type", DbType.Decimal, pK_LU_Equipment_Type);

            db.ExecuteNonQuery(dbCommand);
        }
    }
}