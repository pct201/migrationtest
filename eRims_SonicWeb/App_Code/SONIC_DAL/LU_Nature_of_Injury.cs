using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for LU_Nature_of_Injury table.
	/// </summary>
	public sealed class LU_Nature_of_Injury
    {
        #region Fields


        private decimal _PK_LU_Nature_of_Injury_ID;
        private string _Code;
        private string _Description;

        #endregion


        #region Properties


        /// <summary> 
        /// Gets or sets the PK_LU_Nature_of_Injury_ID value.
        /// </summary>
        public decimal PK_LU_Nature_of_Injury_ID
        {
            get { return _PK_LU_Nature_of_Injury_ID; }
            set { _PK_LU_Nature_of_Injury_ID = value; }
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

        /// Initializes a new instance of the LU_Nature_of_Injury class. with the default value.

        /// </summary>
        public LU_Nature_of_Injury()
        {

            this._PK_LU_Nature_of_Injury_ID = -1;
            this._Code = "";
            this._Description = "";

        }



        /// <summary> 

        /// Initializes a new instance of the LU_Nature_of_Injury class for passed PrimaryKey with the values set from Database.


        /// </summary>
        public LU_Nature_of_Injury(decimal PK)
        {

            DataTable dtLU_Nature_of_Injury = SelectByPK(PK).Tables[0];

            if (dtLU_Nature_of_Injury.Rows.Count > 0)
            {

                DataRow drLU_Nature_of_Injury = dtLU_Nature_of_Injury.Rows[0];

                this._PK_LU_Nature_of_Injury_ID = drLU_Nature_of_Injury["PK_LU_Nature_of_Injury_ID"] != DBNull.Value ? Convert.ToDecimal(drLU_Nature_of_Injury["PK_LU_Nature_of_Injury_ID"]) : 0;
                this._Code = Convert.ToString(drLU_Nature_of_Injury["Code"]);
                this._Description = Convert.ToString(drLU_Nature_of_Injury["Description"]);

            }

            else
            {

                this._PK_LU_Nature_of_Injury_ID = -1;
                this._Code = "";
                this._Description = "";

            }

        }



        #endregion


        #region Methods
        /// <summary>
        /// Inserts a record into the LU_Nature_of_Injury table.
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_Nature_of_InjuryInsert");

            db.AddInParameter(dbCommand, "Code", DbType.String, this._Code);
            db.AddInParameter(dbCommand, "Description", DbType.String, this._Description);

            // Execute the query and return the new identity value
            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
        }

        /// <summary>
        /// Selects a single record from the LU_Nature_of_Injury table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectByPK(decimal pK_LU_Nature_of_Injury_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_Nature_of_InjurySelectByPK");

            db.AddInParameter(dbCommand, "PK_LU_Nature_of_Injury_ID", DbType.Decimal, pK_LU_Nature_of_Injury_ID);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the LU_Nature_of_Injury table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_Nature_of_InjurySelectAll");

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Updates a record in the LU_Nature_of_Injury table.
        /// </summary>
        public void Update()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_Nature_of_InjuryUpdate");

            db.AddInParameter(dbCommand, "PK_LU_Nature_of_Injury_ID", DbType.Decimal, this._PK_LU_Nature_of_Injury_ID);
            db.AddInParameter(dbCommand, "Code", DbType.String, this._Code);
            db.AddInParameter(dbCommand, "Description", DbType.String, this._Description);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Deletes a record from the LU_Nature_of_Injury table by a composite primary key.
        /// </summary>
        public static void DeleteByPK(decimal pK_LU_Nature_of_Injury_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_Nature_of_InjuryDeleteByPK");

            db.AddInParameter(dbCommand, "PK_LU_Nature_of_Injury_ID", DbType.Decimal, pK_LU_Nature_of_Injury_ID);

            db.ExecuteNonQuery(dbCommand);
        }
        #endregion

        
	}
}
