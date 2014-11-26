using System;
using System.Data;
using System.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
    /// <summary>
    /// Data access class for State table.
    /// </summary>
    public sealed class State
    {
        #region Fields


        private decimal _PK_ID;
        private string _FLD_state;
        private string _FLD_abbreviation;
        private string _Code;

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
        /// Gets or sets the FLD_state value.
        /// </summary>
        public string FLD_state
        {
            get { return _FLD_state; }
            set { _FLD_state = value; }
        }


        /// <summary> 
        /// Gets or sets the FLD_abbreviation value.
        /// </summary>
        public string FLD_abbreviation
        {
            get { return _FLD_abbreviation; }
            set { _FLD_abbreviation = value; }
        }


        /// <summary> 
        /// Gets or sets the Code value.
        /// </summary>
        public string Code
        {
            get { return _Code; }
            set { _Code = value; }
        }



        #endregion


        #region Constructors

        /// <summary> 

        /// Initializes a new instance of the State class. with the default value.

        /// </summary>
        public State()
        {

            this._PK_ID = -1;
            this._FLD_state = "";
            this._FLD_abbreviation = "";
            this._Code = "";

        }



        /// <summary> 

        /// Initializes a new instance of the State class for passed PrimaryKey with the values set from Database.


        /// </summary>
        public State(decimal PK)
        {

            DataTable dtState = SelectByPK(PK).Tables[0];

            if (dtState.Rows.Count > 0)
            {

                DataRow drState = dtState.Rows[0];

                this._PK_ID = drState["PK_ID"] != DBNull.Value ? Convert.ToDecimal(drState["PK_ID"]) : 0;
                this._FLD_state = Convert.ToString(drState["FLD_state"]);
                this._FLD_abbreviation = Convert.ToString(drState["FLD_abbreviation"]);
                this._Code = Convert.ToString(drState["Code"]);

            }

            else
            {

                this._PK_ID = -1;
                this._FLD_state = "";
                this._FLD_abbreviation = "";
                this._Code = "";

            }

        }



        #endregion


        #region Methods
        /// <summary>
        /// Inserts a record into the State table.
        /// </summary>
        /// <returns></returns>
        public void Insert()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("StateInsert");

            db.AddInParameter(dbCommand, "PK_ID", DbType.Decimal, this._PK_ID);
            db.AddInParameter(dbCommand, "FLD_state", DbType.String, this._FLD_state);
            db.AddInParameter(dbCommand, "FLD_abbreviation", DbType.String, this._FLD_abbreviation);
            db.AddInParameter(dbCommand, "Code", DbType.String, this._Code);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Selects a single record from the State table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectByPK(decimal pK_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("StateSelectByPK");

            db.AddInParameter(dbCommand, "PK_ID", DbType.Decimal, pK_ID);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the State table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("StateSelectAll");

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records of State from lu_location table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAllFromLU_Location()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("StateSelectAllFromLU_Location");

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Updates a record in the State table.
        /// </summary>
        public void Update()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("StateUpdate");

            db.AddInParameter(dbCommand, "PK_ID", DbType.Decimal, this._PK_ID);
            db.AddInParameter(dbCommand, "FLD_state", DbType.String, this._FLD_state);
            db.AddInParameter(dbCommand, "FLD_abbreviation", DbType.String, this._FLD_abbreviation);
            db.AddInParameter(dbCommand, "Code", DbType.String, this._Code);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Deletes a record from the State table by a composite primary key.
        /// </summary>
        public static void DeleteByPK(decimal pK_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("StateDeleteByPK");

            db.AddInParameter(dbCommand, "PK_ID", DbType.Decimal, pK_ID);

            db.ExecuteNonQuery(dbCommand);
        }

        public static DataSet SelectByAbbreviation(string strAbbreviation)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("StateSelectByAbbreviation");

            db.AddInParameter(dbCommand, "@Abbreviation", DbType.String, strAbbreviation);

            return db.ExecuteDataSet(dbCommand);
        }
        #endregion


    }
}
