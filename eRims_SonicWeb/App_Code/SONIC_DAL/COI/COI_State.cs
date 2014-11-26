using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for State table.
	/// </summary>
	public sealed class COI_State
    {
        #region Fields


        private decimal _PK_Id;
        private string _FLD_state;
        private string _FLD_abbreviation;
        private string _Code;

        #endregion


        #region Properties


        /// <summary> 
        /// Gets or sets the PK_Id value.
        /// </summary>
        public decimal PK_Id
        {
            get { return _PK_Id; }
            set { _PK_Id = value; }
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
        public COI_State()
        {

            this._PK_Id = -1;
            this._FLD_state = "";
            this._FLD_abbreviation = "";
            this._Code = "";

        }



        /// <summary> 

        /// Initializes a new instance of the State class for passed PrimaryKey with the values set from Database.

        /// </summary>
        public COI_State(decimal PK)
        {
            DataTable dtState = Select(PK).Tables[0];

            if (dtState.Rows.Count > 0)
            {

                DataRow drState = dtState.Rows[0];

                this._PK_Id = drState["PK_Id"] != DBNull.Value ? Convert.ToDecimal(drState["PK_Id"]) : 0;
                this._FLD_state = Convert.ToString(drState["FLD_state"]);
                this._FLD_abbreviation = Convert.ToString(drState["FLD_abbreviation"]);
                this._Code = Convert.ToString(drState["Code"]);

            }

            else
            {

                new COI_State();
            }

        }



        #endregion

        #region "Methods"
       

		/// <summary>
		/// Selects a single record from the State table.
		/// <summary>
		/// <returns>DataSet</returns>
		public static DataSet Select(decimal pK_Id)
		{
			Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("COI_StateSelect");

			db.AddInParameter(dbCommand, "PK_Id", DbType.Decimal, pK_Id);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the State table.
		/// <summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("COI_StateSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

        
        #endregion
    }
}
