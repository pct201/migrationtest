using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for COI_Noncompliance_Level table.
	/// </summary>
	public sealed class COI_Noncompliance_Level
    {
        #region Fields

        private decimal _PK_COI_Noncompliance_Level;
        private string _Fld_Desc;

        #endregion


        #region Properties

        /// <summary> 
        /// Gets or sets the PK_COI_Noncompliance_Level value.
        /// </summary>
        public decimal PK_COI_Noncompliance_Level
        {
            get { return _PK_COI_Noncompliance_Level; }
            set { _PK_COI_Noncompliance_Level = value; }
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

        /// Initializes a new instance of the COI_Noncompliance_Level class. with the default value.

        /// </summary>
        public COI_Noncompliance_Level()
        {
            this._PK_COI_Noncompliance_Level = -1;
            this._Fld_Desc = "";

        }



        /// <summary> 

        /// Initializes a new instance of the COI_Noncompliance_Level class for passed PrimaryKey with the values set from Database.

        /// </summary>
        public COI_Noncompliance_Level(decimal PK)
        {
            DataTable dtCOI_Noncompliance_Level = Select(PK).Tables[0];

            if (dtCOI_Noncompliance_Level.Rows.Count > 0)
            {

                DataRow drCOI_Noncompliance_Level = dtCOI_Noncompliance_Level.Rows[0];
                this._PK_COI_Noncompliance_Level = drCOI_Noncompliance_Level["PK_COI_Noncompliance_Level"] != DBNull.Value ? Convert.ToDecimal(drCOI_Noncompliance_Level["PK_COI_Noncompliance_Level"]) : 0;
                this._Fld_Desc = Convert.ToString(drCOI_Noncompliance_Level["Fld_Desc"]);

            }

            else
            {

                new COI_Noncompliance_Level();
            }

        }



        #endregion

        #region "Methods"        

		/// <summary>
		/// Selects a single record from the COI_Noncompliance_Level table.
		/// <summary>
		/// <returns>DataSet</returns>
		public static DataSet Select(decimal pK_COI_Noncompliance_Level)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("COI_Noncompliance_LevelSelect");

			db.AddInParameter(dbCommand, "PK_COI_Noncompliance_Level", DbType.Decimal, pK_COI_Noncompliance_Level);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the COI_Noncompliance_Level table.
		/// <summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("COI_Noncompliance_LevelSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

        
        #endregion
    }
}
