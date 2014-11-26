using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for COI_Interest table.
	/// </summary>
	public sealed class COI_Interest
    {
        #region Fields

        private decimal _PK_COI_Interest;
        private string _Fld_Desc;

        #endregion


        #region Properties

        /// <summary> 
        /// Gets or sets the PK_COI_Interest value.
        /// </summary>
        public decimal PK_COI_Interest
        {
            get { return _PK_COI_Interest; }
            set { _PK_COI_Interest = value; }
        }


        /// <summary> 
        /// Gets or sets the Fld_Desc value.
        /// </summary>
        public string Fld_Desc
        {
            get { return _Fld_Desc; }
            set { _Fld_Desc = value; }
        }



        #endregion


        #region Constructors

        /// <summary> 

        /// Initializes a new instance of the COI_Interest class. with the default value.

        /// </summary>
        public COI_Interest()
        {
            this._PK_COI_Interest = -1;
            this._Fld_Desc = "";

        }



        /// <summary> 

        /// Initializes a new instance of the COI_Interest class for passed PrimaryKey with the values set from Database.

        /// </summary>
        public COI_Interest(decimal PK)
        {
            DataTable dtCOI_Interest = Select(PK).Tables[0];

            if (dtCOI_Interest.Rows.Count > 0)
            {

                DataRow drCOI_Interest = dtCOI_Interest.Rows[0];

                
                this._PK_COI_Interest = drCOI_Interest["PK_COI_Interest"] != DBNull.Value ? Convert.ToDecimal(drCOI_Interest["PK_COI_Interest"]) : 0;
                this._Fld_Desc = Convert.ToString(drCOI_Interest["Fld_Desc"]);

            }

            else
            {

                new COI_Interest();
            }

        }



        #endregion


        #region "Methods"
       

		/// <summary>
		/// Selects a single record from the COI_Interest table.
		/// <summary>
		/// <returns>DataSet</returns>
		public static DataSet Select(decimal pK_COI_Interest)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("COI_InterestSelect");

			db.AddInParameter(dbCommand, "PK_COI_Interest", DbType.Decimal, pK_COI_Interest);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the COI_Interest table.
		/// <summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("COI_InterestSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

        
        #endregion
    }
}
