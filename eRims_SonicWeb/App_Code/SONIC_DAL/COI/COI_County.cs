using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for County table.
	/// </summary>
	public sealed class COI_County
    {

        #region Fields


        private decimal _PK_Id;
        private string _FLD_county;
        private string _FLD_code;
        private string _FLD_state;

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
        /// Gets or sets the FLD_county value.
        /// </summary>
        public string FLD_county
        {
            get { return _FLD_county; }
            set { _FLD_county = value; }
        }


        /// <summary> 
        /// Gets or sets the FLD_code value.
        /// </summary>
        public string FLD_code
        {
            get { return _FLD_code; }
            set { _FLD_code = value; }
        }


        /// <summary> 
        /// Gets or sets the FLD_state value.
        /// </summary>
        public string FLD_state
        {
            get { return _FLD_state; }
            set { _FLD_state = value; }
        }



        #endregion


        #region Constructors

        /// <summary> 

        /// Initializes a new instance of the County class. with the default value.

        /// </summary>
        public COI_County()
        {

            this._PK_Id = -1;
            this._FLD_county = "";
            this._FLD_code = "";
            this._FLD_state = "";

        }



        /// <summary> 

        /// Initializes a new instance of the County class for passed PrimaryKey with the values set from Database.

        /// </summary>
        public COI_County(decimal PK)
        {
            DataTable dtCounty = Select(PK).Tables[0];

            if (dtCounty.Rows.Count > 0)
            {

                DataRow drCounty = dtCounty.Rows[0];

                this._PK_Id = drCounty["PK_Id"] != DBNull.Value ? Convert.ToDecimal(drCounty["PK_Id"]) : 0;
                this._FLD_county = Convert.ToString(drCounty["FLD_county"]);
                this._FLD_code = Convert.ToString(drCounty["FLD_code"]);
                this._FLD_state = Convert.ToString(drCounty["FLD_state"]);

            }

            else
            {

                new COI_County();
            }

        }



        #endregion


        #region "Methods"
        
		/// <summary>
		/// Selects a single record from the County table.
		/// <summary>
		/// <returns>DataSet</returns>
		public static DataSet Select(decimal pK_Id)
		{
			Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("COI_CountySelect");

			db.AddInParameter(dbCommand, "PK_Id", DbType.Decimal, pK_Id);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the County table.
		/// <summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("COI_CountySelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

        

        public static DataSet SelectByState(string strState)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("CountySelectByState");

            db.AddInParameter(dbCommand, "FLD_state", DbType.String, strState);

            return db.ExecuteDataSet(dbCommand);
        }
        #endregion
    }
}
