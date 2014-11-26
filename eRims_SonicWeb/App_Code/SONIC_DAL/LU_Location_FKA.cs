using System;
using System.Data;
using System.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
    /// <summary>
    /// Data access class for LU_Location_FKA table.
    /// </summary>
    public sealed class LU_Location_FKA
    {
        #region Fields


        private decimal _PK_LU_Location_FKA_ID;
        private decimal _FK_LU_Location_ID;
        private string _fka;

        #endregion


        #region Properties


        /// <summary> 
        /// Gets or sets the PK_LU_Location_FKA_ID value.
        /// </summary>
        public decimal PK_LU_Location_FKA_ID
        {
            get { return _PK_LU_Location_FKA_ID; }
            set { _PK_LU_Location_FKA_ID = value; }
        }


        /// <summary> 
        /// Gets or sets the FK_LU_Location_ID value.
        /// </summary>
        public decimal FK_LU_Location_ID
        {
            get { return _FK_LU_Location_ID; }
            set { _FK_LU_Location_ID = value; }
        }


        /// <summary> 
        /// Gets or sets the fka value.
        /// </summary>
        public string fka
        {
            get { return _fka; }
            set { _fka = value; }
        }



        #endregion


        #region Constructors

        /// <summary> 

        /// Initializes a new instance of the LU_Location_FKA class. with the default value.

        /// </summary>
        public LU_Location_FKA()
        {

            this._PK_LU_Location_FKA_ID = -1;
            this._FK_LU_Location_ID = -1;
            this._fka = "";

        }



        /// <summary> 

        /// Initializes a new instance of the LU_Location_FKA class for passed PrimaryKey with the values set from Database.


        /// </summary>
        public LU_Location_FKA(decimal PK)
        {

            DataTable dtLU_Location_FKA = SelectByPK(PK).Tables[0];

            if (dtLU_Location_FKA.Rows.Count > 0)
            {

                DataRow drLU_Location_FKA = dtLU_Location_FKA.Rows[0];

                this._PK_LU_Location_FKA_ID = drLU_Location_FKA["PK_LU_Location_FKA_ID"] != DBNull.Value ? Convert.ToDecimal(drLU_Location_FKA["PK_LU_Location_FKA_ID"]) : 0;
                this._FK_LU_Location_ID = drLU_Location_FKA["FK_LU_Location_ID"] != DBNull.Value ? Convert.ToDecimal(drLU_Location_FKA["FK_LU_Location_ID"]) : 0;
                this._fka = Convert.ToString(drLU_Location_FKA["fka"]);

            }

            else
            {

                this._PK_LU_Location_FKA_ID = -1;
                this._FK_LU_Location_ID = -1;
                this._fka = "";

            }

        }

        public LU_Location_FKA(decimal LocationID, bool ByLocationID)
        {
            DataTable dtLU_Location_FKA = SelectByLocationID(LocationID).Tables[0];

            if (dtLU_Location_FKA.Rows.Count > 0)
            {
                DataRow drLU_Location_FKA = dtLU_Location_FKA.Rows[0];

                this._PK_LU_Location_FKA_ID = drLU_Location_FKA["PK_LU_Location_FKA_ID"] != DBNull.Value ? Convert.ToDecimal(drLU_Location_FKA["PK_LU_Location_FKA_ID"]) : 0;
                this._FK_LU_Location_ID = drLU_Location_FKA["FK_LU_Location_ID"] != DBNull.Value ? Convert.ToDecimal(drLU_Location_FKA["FK_LU_Location_ID"]) : 0;
                this._fka = Convert.ToString(drLU_Location_FKA["fka"]);

            }
            else
            {
                                this._PK_LU_Location_FKA_ID = -1;
                this._FK_LU_Location_ID = -1;
                this._fka = "";
            }
        }

        #endregion


        #region Methods
        /// <summary>
        /// Inserts a record into the LU_Location_FKA table.
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_Location_FKAInsert");

            db.AddInParameter(dbCommand, "FK_LU_Location_ID", DbType.Decimal, this._FK_LU_Location_ID);
            db.AddInParameter(dbCommand, "fka", DbType.String, this._fka);

            // Execute the query and return the new identity value
            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
        }

        /// <summary>
        /// Selects a single record from the LU_Location_FKA table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectByPK(decimal pK_LU_Location_FKA_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_Location_FKASelectByPK");

            db.AddInParameter(dbCommand, "PK_LU_Location_FKA_ID", DbType.Decimal, pK_LU_Location_FKA_ID);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the LU_Location_FKA table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_Location_FKASelectAll");

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Updates a record in the LU_Location_FKA table.
        /// </summary>
        public void Update()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_Location_FKAUpdate");

            db.AddInParameter(dbCommand, "PK_LU_Location_FKA_ID", DbType.Decimal, this._PK_LU_Location_FKA_ID);
            db.AddInParameter(dbCommand, "FK_LU_Location_ID", DbType.Decimal, this._FK_LU_Location_ID);
            db.AddInParameter(dbCommand, "fka", DbType.String, this._fka);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Deletes a record from the LU_Location_FKA table by a composite primary key.
        /// </summary>
        public static void DeleteByPK(decimal pK_LU_Location_FKA_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_Location_FKADeleteByPK");

            db.AddInParameter(dbCommand, "PK_LU_Location_FKA_ID", DbType.Decimal, pK_LU_Location_FKA_ID);

            db.ExecuteNonQuery(dbCommand);
        }

        public static DataSet SelectByLocationID(decimal fK_LU_Location_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_Location_FKASelectByLocationID");

            db.AddInParameter(dbCommand, "FK_LU_Location_ID", DbType.Decimal, fK_LU_Location_ID);

            return db.ExecuteDataSet(dbCommand);
        }
    #endregion

        
    }
}
