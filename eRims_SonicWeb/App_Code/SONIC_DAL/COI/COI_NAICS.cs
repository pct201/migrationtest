using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for NAICS table.
	/// </summary>
	public sealed class COI_NAICS
    {

        #region Fields


        private decimal _PK_NAICS;
        private string _Fld_Desc;
        private string _Fld_Code;

        #endregion


        #region Properties


        /// <summary> 
        /// Gets or sets the PK_NAICS value.
        /// </summary>
        public decimal PK_NAICS
        {
            get { return _PK_NAICS; }
            set { _PK_NAICS = value; }
        }


        /// <summary> 
        /// Gets or sets the Fld_Desc value.
        /// </summary>
        public string Fld_Desc
        {
            get { return _Fld_Desc; }
            set { _Fld_Desc = value; }
        }


        /// <summary> 
        /// Gets or sets the Fld_Code value.
        /// </summary>
        public string Fld_Code
        {
            get { return _Fld_Code; }
            set { _Fld_Code = value; }
        }



        #endregion


        #region Constructors

        /// <summary> 

        /// Initializes a new instance of the NAICS class. with the default value.

        /// </summary>
        public COI_NAICS()
        {

            this._PK_NAICS = -1;
            this._Fld_Desc = "";
            this._Fld_Code = "";

        }



        /// <summary> 

        /// Initializes a new instance of the NAICS class for passed PrimaryKey with the values set from Database.

        /// </summary>
        public COI_NAICS(decimal PK)
        {
            DataTable dtNAICS = Select(PK).Tables[0];

            if (dtNAICS.Rows.Count > 0)
            {

                DataRow drNAICS = dtNAICS.Rows[0];

                this._PK_NAICS = drNAICS["PK_NAICS"] != DBNull.Value ? Convert.ToDecimal(drNAICS["PK_NAICS"]) : 0;
                this._Fld_Desc = Convert.ToString(drNAICS["Fld_Desc"]);
                this._Fld_Code = Convert.ToString(drNAICS["Fld_Code"]);

            }

            else
            {

                new COI_NAICS();
            }

        }



        #endregion


        #region "Methods"
        
		/// <summary>
		/// Selects a single record from the NAICS table.
		/// <summary>
		/// <returns>DataSet</returns>
		public static DataSet Select(decimal pK_NAICS)
		{
			Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("COI_NAICSSelect");

			db.AddInParameter(dbCommand, "PK_NAICS", DbType.Decimal, pK_NAICS);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the NAICS table.
		/// <summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("COI_NAICSSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

        
        #endregion
    }
}
