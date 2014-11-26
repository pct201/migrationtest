using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for LU_NCCI_Occupation_Class_Code table.
	/// </summary>
	public sealed class LU_NCCI_Occupation_Class_Code
    {
        #region Fields


        private Int64 _PK_LU_NCCI_Occupation_Class_Code_ID;
        private string _Code;
        private string _Description;

        #endregion


        #region Properties


        /// <summary> 
        /// Gets or sets the PK_LU_NCCI_Occupation_Class_Code_ID value.
        /// </summary>
        public Int64 PK_LU_NCCI_Occupation_Class_Code_ID
        {
            get { return _PK_LU_NCCI_Occupation_Class_Code_ID; }
            set { _PK_LU_NCCI_Occupation_Class_Code_ID = value; }
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

        /// Initializes a new instance of the LU_NCCI_Occupation_Class_Code class. with the default value.

        /// </summary>
        public LU_NCCI_Occupation_Class_Code()
        {

            this._PK_LU_NCCI_Occupation_Class_Code_ID = 0;
            this._Code = "";
            this._Description = "";

        }



        /// <summary> 
        /// Initializes a new instance of the LU_NCCI_Occupation_Class_Code class for passed PrimaryKey with the values set from Database.
        /// </summary>
        public LU_NCCI_Occupation_Class_Code(Int64 PK)
        {

            DataTable dtLU_NCCI_Occupation_Class_Code = SelectByPK(PK).Tables[0];

            if (dtLU_NCCI_Occupation_Class_Code.Rows.Count > 0)
            {

                DataRow drLU_NCCI_Occupation_Class_Code = dtLU_NCCI_Occupation_Class_Code.Rows[0];

                this._PK_LU_NCCI_Occupation_Class_Code_ID = drLU_NCCI_Occupation_Class_Code["PK_LU_NCCI_Occupation_Class_Code_ID"] != DBNull.Value ? Convert.ToInt64(drLU_NCCI_Occupation_Class_Code["PK_LU_NCCI_Occupation_Class_Code_ID"]) : 0;
                this._Code = Convert.ToString(drLU_NCCI_Occupation_Class_Code["Code"]);
                this._Description = Convert.ToString(drLU_NCCI_Occupation_Class_Code["Description"]);

            }

            else
            {

                this._PK_LU_NCCI_Occupation_Class_Code_ID = 0;
                this._Code = "";
                this._Description = "";

            }

        }

        /// <summary> 
        /// Initializes a new instance of the LU_NCCI_Occupation_Class_Code class for passed PrimaryKey with the values set from Database.
        /// </summary>
        public LU_NCCI_Occupation_Class_Code(string Code)
        {

            DataTable dtLU_NCCI_Occupation_Class_Code = SelectByCode(Code).Tables[0];

            if (dtLU_NCCI_Occupation_Class_Code.Rows.Count > 0)
            {

                DataRow drLU_NCCI_Occupation_Class_Code = dtLU_NCCI_Occupation_Class_Code.Rows[0];

                this._PK_LU_NCCI_Occupation_Class_Code_ID = drLU_NCCI_Occupation_Class_Code["PK_LU_NCCI_Occupation_Class_Code_ID"] != DBNull.Value ? Convert.ToInt64(drLU_NCCI_Occupation_Class_Code["PK_LU_NCCI_Occupation_Class_Code_ID"]) : 0;
                this._Code = Convert.ToString(drLU_NCCI_Occupation_Class_Code["Code"]);
                this._Description = Convert.ToString(drLU_NCCI_Occupation_Class_Code["Description"]);

            }

            else
            {

                this._PK_LU_NCCI_Occupation_Class_Code_ID = 0;
                this._Code = "";
                this._Description = "";

            }

        }

        #endregion

        #region Methods

        /// <summary>
		/// Inserts a record into the LU_NCCI_Occupation_Class_Code table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_NCCI_Occupation_Class_CodeInsert");

			db.AddInParameter(dbCommand, "Code", DbType.String, this._Code);
			db.AddInParameter(dbCommand, "Description", DbType.String, this._Description);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the LU_NCCI_Occupation_Class_Code table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectByPK(Int64 pK_LU_NCCI_Occupation_Class_Code_ID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_NCCI_Occupation_Class_CodeSelectByPK");

			db.AddInParameter(dbCommand, "PK_LU_NCCI_Occupation_Class_Code_ID", DbType.Int64, pK_LU_NCCI_Occupation_Class_Code_ID);

			return db.ExecuteDataSet(dbCommand);
		}

        /// <summary>
        /// Selects a single record from the LU_NCCI_Occupation_Class_Code table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectByCode(string Code)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_NCCI_Occupation_Class_CodeSelectByCode");

            db.AddInParameter(dbCommand, "Code", DbType.String, Code);

            return db.ExecuteDataSet(dbCommand);
        }
		/// <summary>
		/// Selects all records from the LU_NCCI_Occupation_Class_Code table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_NCCI_Occupation_Class_CodeSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the LU_NCCI_Occupation_Class_Code table.
		/// </summary>
		public void Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_NCCI_Occupation_Class_CodeUpdate");

			db.AddInParameter(dbCommand, "PK_LU_NCCI_Occupation_Class_Code_ID", DbType.Int64, this._PK_LU_NCCI_Occupation_Class_Code_ID);
			db.AddInParameter(dbCommand, "Code", DbType.String, this._Code);
			db.AddInParameter(dbCommand, "Description", DbType.String, this._Description);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the LU_NCCI_Occupation_Class_Code table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(Int64 pK_LU_NCCI_Occupation_Class_Code_ID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_NCCI_Occupation_Class_CodeDeleteByPK");

			db.AddInParameter(dbCommand, "PK_LU_NCCI_Occupation_Class_Code_ID", DbType.Int64, pK_LU_NCCI_Occupation_Class_Code_ID);

			db.ExecuteNonQuery(dbCommand);
        }
        #endregion
    }
}
