using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for Marital_Status table.
	/// </summary>
	public sealed class Marital_Status
    {
        #region Fields


        private decimal _PK_ID;
        private string _FLD_desc;
        private string _FLD_code;

        #endregion


        #region Properties


        /// <summary> 
        /// Gets or sets the PK_ID value.
        /// </summary>
        public decimal PK_ID
        {
            get { return _PK_ID; }
            set { _PK_ID = value; }
        }


        /// <summary> 
        /// Gets or sets the FLD_desc value.
        /// </summary>
        public string FLD_desc
        {
            get { return _FLD_desc; }
            set { _FLD_desc = value; }
        }


        /// <summary> 
        /// Gets or sets the FLD_code value.
        /// </summary>
        public string FLD_code
        {
            get { return _FLD_code; }
            set { _FLD_code = value; }
        }



        #endregion


        #region Constructors

        /// <summary> 

        /// Initializes a new instance of the Marital_Status class. with the default value.

        /// </summary>
        public Marital_Status()
        {

            this._PK_ID = -1;
            this._FLD_desc = "";
            this._FLD_code = "";

        }



        /// <summary> 

        /// Initializes a new instance of the Marital_Status class for passed PrimaryKey with the values set from Database.


        /// </summary>
        public Marital_Status(decimal PK)
        {

            DataTable dtMarital_Status = SelectByPK(PK).Tables[0];

            if (dtMarital_Status.Rows.Count > 0)
            {

                DataRow drMarital_Status = dtMarital_Status.Rows[0];

                this._PK_ID = drMarital_Status["PK_ID"] != DBNull.Value ? Convert.ToDecimal(drMarital_Status["PK_ID"]) : 0;
                this._FLD_desc = Convert.ToString(drMarital_Status["FLD_desc"]);
                this._FLD_code = Convert.ToString(drMarital_Status["FLD_code"]);

            }

            else
            {

                this._PK_ID = -1;
                this._FLD_desc = "";
                this._FLD_code = "";

            }

        }



        #endregion


        #region Methods
        /// <summary>
        /// Inserts a record into the Marital_Status table.
        /// </summary>
        /// <returns></returns>
        public void Insert()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Marital_StatusInsert");

            db.AddInParameter(dbCommand, "PK_ID", DbType.Decimal, this._PK_ID);
            db.AddInParameter(dbCommand, "FLD_desc", DbType.String, this._FLD_desc);
            db.AddInParameter(dbCommand, "FLD_code", DbType.String, this._FLD_code);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Selects a single record from the Marital_Status table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectByPK(decimal pK_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Marital_StatusSelectByPK");

            db.AddInParameter(dbCommand, "PK_ID", DbType.Decimal, pK_ID);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the Marital_Status table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Marital_StatusSelectAll");

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Updates a record in the Marital_Status table.
        /// </summary>
        public void Update()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Marital_StatusUpdate");

            db.AddInParameter(dbCommand, "PK_ID", DbType.Decimal, this._PK_ID);
            db.AddInParameter(dbCommand, "FLD_desc", DbType.String, this._FLD_desc);
            db.AddInParameter(dbCommand, "FLD_code", DbType.String, this._FLD_code);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Deletes a record from the Marital_Status table by a composite primary key.
        /// </summary>
        public static void DeleteByPK(decimal pK_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Marital_StatusDeleteByPK");

            db.AddInParameter(dbCommand, "PK_ID", DbType.Decimal, pK_ID);

            db.ExecuteNonQuery(dbCommand);
        }
        #endregion

        
	}
}
