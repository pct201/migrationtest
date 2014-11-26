using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for COI_Region table.
	/// </summary>
	public sealed class COI_Region
    {
        #region Fields


        private decimal _PK_COI_Region;
        private string _Fld_Desc;

        #endregion


        #region Properties


        /// <summary> 
        /// Gets or sets the PK_COI_Region value.
        /// </summary>
        public decimal PK_COI_Region
        {
            get { return _PK_COI_Region; }
            set { _PK_COI_Region = value; }
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

        /// Initializes a new instance of the COI_Region class. with the default value.

        /// </summary>
        public COI_Region()
        {

            this._PK_COI_Region = -1;
            this._Fld_Desc = "";

        }



        /// <summary> 

        /// Initializes a new instance of the COI_Region class for passed PrimaryKey with the values set from Database.

        /// </summary>
        public COI_Region(decimal PK)
        {
            DataTable dtCOI_Region = Select(PK).Tables[0];

            if (dtCOI_Region.Rows.Count > 0)
            {

                DataRow drCOI_Region = dtCOI_Region.Rows[0];

                this._PK_COI_Region = drCOI_Region["PK_COI_Region"] != DBNull.Value ? Convert.ToDecimal(drCOI_Region["PK_COI_Region"]) : 0;
                this._Fld_Desc = Convert.ToString(drCOI_Region["Fld_Desc"]);

            }

            else
            {

                new COI_Region();
            }

        }



        #endregion

        #region "Methods"

        
		/// <summary>
		/// Selects a single record from the COI_Region table.
		/// <summary>
		/// <returns>DataSet</returns>
		public static DataSet Select(decimal pK_COI_Region)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("COI_RegionSelect");

			db.AddInParameter(dbCommand, "PK_COI_Region", DbType.Decimal, pK_COI_Region);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the COI_Region table.
		/// <summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("COI_RegionSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

        
        #endregion
    }
}
