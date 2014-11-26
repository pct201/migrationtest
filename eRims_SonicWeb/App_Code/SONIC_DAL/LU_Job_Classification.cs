using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for LU_Job_Classification table.
	/// </summary>
	public sealed class LU_Job_Classification
    {
        #region Fields


        private decimal _PK_LU_Job_Classification_ID;
        private string _Code;
        private string _Description;

        #endregion


        #region Properties


        /// <summary> 
        /// Gets or sets the PK_LU_Job_Classification_ID value.
        /// </summary>
        public decimal PK_LU_Job_Classification_ID
        {
            get { return _PK_LU_Job_Classification_ID; }
            set { _PK_LU_Job_Classification_ID = value; }
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

        /// Initializes a new instance of the LU_Job_Classification class. with the default value.

        /// </summary>
        public LU_Job_Classification()
        {

            this._PK_LU_Job_Classification_ID = -1;
            this._Code = "";
            this._Description = "";

        }



        /// <summary> 

        /// Initializes a new instance of the LU_Job_Classification class for passed PrimaryKey with the values set from Database.


        /// </summary>
        public LU_Job_Classification(decimal PK)
        {

            DataTable dtLU_Job_Classification = SelectByPK(PK).Tables[0];

            if (dtLU_Job_Classification.Rows.Count > 0)
            {

                DataRow drLU_Job_Classification = dtLU_Job_Classification.Rows[0];

                this._PK_LU_Job_Classification_ID = drLU_Job_Classification["PK_LU_Job_Classification_ID"] != DBNull.Value ? Convert.ToDecimal(drLU_Job_Classification["PK_LU_Job_Classification_ID"]) : 0;
                this._Code = Convert.ToString(drLU_Job_Classification["Code"]);
                this._Description = Convert.ToString(drLU_Job_Classification["Description"]);

            }

            else
            {

                this._PK_LU_Job_Classification_ID = -1;
                this._Code = "";
                this._Description = "";

            }

        }



        #endregion


        #region Methods
        /// <summary>
        /// Inserts a record into the LU_Job_Classification table.
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_Job_ClassificationInsert");

            db.AddInParameter(dbCommand, "Code", DbType.String, this._Code);
            db.AddInParameter(dbCommand, "Description", DbType.String, this._Description);

            // Execute the query and return the new identity value
            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
        }

        /// <summary>
        /// Selects a single record from the LU_Job_Classification table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectByPK(decimal pK_LU_Job_Classification_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_Job_ClassificationSelectByPK");

            db.AddInParameter(dbCommand, "PK_LU_Job_Classification_ID", DbType.Decimal, pK_LU_Job_Classification_ID);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the LU_Job_Classification table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_Job_ClassificationSelectAll");

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Updates a record in the LU_Job_Classification table.
        /// </summary>
        public void Update()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_Job_ClassificationUpdate");

            db.AddInParameter(dbCommand, "PK_LU_Job_Classification_ID", DbType.Decimal, this._PK_LU_Job_Classification_ID);
            db.AddInParameter(dbCommand, "Code", DbType.String, this._Code);
            db.AddInParameter(dbCommand, "Description", DbType.String, this._Description);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Deletes a record from the LU_Job_Classification table by a composite primary key.
        /// </summary>
        public static void DeleteByPK(decimal pK_LU_Job_Classification_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_Job_ClassificationDeleteByPK");

            db.AddInParameter(dbCommand, "PK_LU_Job_Classification_ID", DbType.Decimal, pK_LU_Job_Classification_ID);

            db.ExecuteNonQuery(dbCommand);
        }
        #endregion

        
	}
}
