using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for LU_Part_Of_Body table.
	/// </summary>
	public sealed class LU_Part_Of_Body
    {
        #region Fields


        private decimal _PK_LU_Part_Of_Body_ID;
        private string _Code;
        private string _Description;

        #endregion


        #region Properties


        /// <summary> 
        /// Gets or sets the PK_LU_Part_Of_Body_ID value.
        /// </summary>
        public decimal PK_LU_Part_Of_Body_ID
        {
            get { return _PK_LU_Part_Of_Body_ID; }
            set { _PK_LU_Part_Of_Body_ID = value; }
        }


        /// <summary> 
        /// Gets or sets the Code value.
        /// </summary>
        public string Code
        {
            get { return _Code; }
            set { _Code = value; }
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

        /// Initializes a new instance of the LU_Part_Of_Body class. with the default value.

        /// </summary>
        public LU_Part_Of_Body()
        {

            this._PK_LU_Part_Of_Body_ID = -1;
            this._Code = "";
            this._Description = "";

        }



        /// <summary> 

        /// Initializes a new instance of the LU_Part_Of_Body class for passed PrimaryKey with the values set from Database.


        /// </summary>
        public LU_Part_Of_Body(decimal PK)
        {

            DataTable dtLU_Part_Of_Body = SelectByPK(PK).Tables[0];

            if (dtLU_Part_Of_Body.Rows.Count > 0)
            {

                DataRow drLU_Part_Of_Body = dtLU_Part_Of_Body.Rows[0];

                this._PK_LU_Part_Of_Body_ID = drLU_Part_Of_Body["PK_LU_Part_Of_Body_ID"] != DBNull.Value ? Convert.ToDecimal(drLU_Part_Of_Body["PK_LU_Part_Of_Body_ID"]) : 0;
                this._Code = Convert.ToString(drLU_Part_Of_Body["Code"]);
                this._Description = Convert.ToString(drLU_Part_Of_Body["Description"]);

            }

            else
            {

                this._PK_LU_Part_Of_Body_ID = -1;
                this._Code = "";
                this._Description = "";

            }

        }



        #endregion


        #region Methods
        /// <summary>
        /// Inserts a record into the LU_Part_Of_Body table.
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_Part_Of_BodyInsert");

            db.AddInParameter(dbCommand, "Code", DbType.String, this._Code);
            db.AddInParameter(dbCommand, "Description", DbType.String, this._Description);

            // Execute the query and return the new identity value
            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
        }

        /// <summary>
        /// Selects a single record from the LU_Part_Of_Body table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectByPK(decimal pK_LU_Part_Of_Body_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_Part_Of_BodySelectByPK");

            db.AddInParameter(dbCommand, "PK_LU_Part_Of_Body_ID", DbType.Decimal, pK_LU_Part_Of_Body_ID);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the LU_Part_Of_Body table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_Part_Of_BodySelectAll");

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the LU_Part_Of_Body table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectByFirstReport(string Code)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_Part_Of_BodySelectByFirstReport");

            db.AddInParameter(dbCommand, "Code", DbType.String, Code);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Updates a record in the LU_Part_Of_Body table.
        /// </summary>
        public void Update()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_Part_Of_BodyUpdate");

            db.AddInParameter(dbCommand, "PK_LU_Part_Of_Body_ID", DbType.Decimal, this._PK_LU_Part_Of_Body_ID);
            db.AddInParameter(dbCommand, "Code", DbType.String, this._Code);
            db.AddInParameter(dbCommand, "Description", DbType.String, this._Description);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Deletes a record from the LU_Part_Of_Body table by a composite primary key.
        /// </summary>
        public static void DeleteByPK(decimal pK_LU_Part_Of_Body_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_Part_Of_BodyDeleteByPK");

            db.AddInParameter(dbCommand, "PK_LU_Part_Of_Body_ID", DbType.Decimal, pK_LU_Part_Of_Body_ID);

            db.ExecuteNonQuery(dbCommand);
        }
        #endregion
        
	}
}
