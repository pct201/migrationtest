using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for COI_District table.
	/// </summary>
	public sealed class COI_District
    {
        #region Fields

        private decimal _PK_COI_District;
        private string _Fld_Desc;

        #endregion


        #region Properties

        /// <summary> 
        /// Gets or sets the PK_COI_District value.
        /// </summary>
        public decimal PK_COI_District
        {
            get { return _PK_COI_District; }
            set { _PK_COI_District = value; }
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

        /// Initializes a new instance of the COI_District class. with the default value.

        /// </summary>
        public COI_District()
        {
            this._PK_COI_District = -1;
            this._Fld_Desc = "";

        }



        /// <summary> 

        /// Initializes a new instance of the COI_District class for passed PrimaryKey with the values set from Database.

        /// </summary>
        public COI_District(decimal PK)
        {
            DataTable dtCOI_District = Select(PK).Tables[0];

            if (dtCOI_District.Rows.Count > 0)
            {

                DataRow drCOI_District = dtCOI_District.Rows[0];
                this._PK_COI_District = drCOI_District["PK_COI_District"] != DBNull.Value ? Convert.ToDecimal(drCOI_District["PK_COI_District"]) : 0;
                this._Fld_Desc = Convert.ToString(drCOI_District["Fld_Desc"]);

            }

            else
            {

                new COI_District();
            }

        }



        #endregion

        #region "Methods"
        
		/// <summary>
		/// Selects a single record from the COI_District table.
		/// <summary>
		/// <returns>DataSet</returns>
		public static DataSet Select(decimal pK_COI_District)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("COI_DistrictSelect");

			db.AddInParameter(dbCommand, "PK_COI_District", DbType.Decimal, pK_COI_District);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the COI_District table.
		/// <summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("COI_DistrictSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

        
        #endregion
    }
}
