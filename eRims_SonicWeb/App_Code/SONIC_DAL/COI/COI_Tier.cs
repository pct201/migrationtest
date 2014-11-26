using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for COI_Tier table.
	/// </summary>
	public sealed class COI_Tier
    {
        #region Fields


        private decimal _PK_COI_Tier;
        private string _Fld_Desc;

        #endregion


        #region Properties

        /// <summary> 
        /// Gets or sets the PK_COI_Tier value.
        /// </summary>
        public decimal PK_COI_Tier
        {
            get { return _PK_COI_Tier; }
            set { _PK_COI_Tier = value; }
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

        /// Initializes a new instance of the COI_Tier class. with the default value.

        /// </summary>
        public COI_Tier()
        {
            this._PK_COI_Tier = -1;
            this._Fld_Desc = "";

        }



        /// <summary> 

        /// Initializes a new instance of the COI_Tier class for passed PrimaryKey with the values set from Database.

        /// </summary>
        public COI_Tier(decimal PK)
        {
            DataTable dtCOI_Tier = Select(PK).Tables[0];

            if (dtCOI_Tier.Rows.Count > 0)
            {

                DataRow drCOI_Tier = dtCOI_Tier.Rows[0];
                this._PK_COI_Tier = drCOI_Tier["PK_COI_Tier"] != DBNull.Value ? Convert.ToDecimal(drCOI_Tier["PK_COI_Tier"]) : 0;
                this._Fld_Desc = Convert.ToString(drCOI_Tier["Fld_Desc"]);

            }

            else
            {

                new COI_Tier();
            }

        }



        #endregion


        #region "Methods"
        

		/// <summary>
		/// Selects a single record from the COI_Tier table.
		/// <summary>
		/// <returns>DataSet</returns>
		public static DataSet Select(decimal pK_COI_Tier)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("COI_TierSelect");

			db.AddInParameter(dbCommand, "PK_COI_Tier", DbType.Decimal, pK_COI_Tier);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the COI_Tier table.
		/// <summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("COI_TierSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

        
        #endregion
    }
}
