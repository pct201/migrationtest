using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for COI_Division table.
	/// </summary>
	public sealed class COI_Division
    {
        #region Fields

        private decimal _PK_COI_Division;
        private string _Fld_Desc;

        #endregion


        #region Properties

        /// <summary> 
        /// Gets or sets the PK_COI_Division value.
        /// </summary>
        public decimal PK_COI_Division
        {
            get { return _PK_COI_Division; }
            set { _PK_COI_Division = value; }
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

        /// Initializes a new instance of the COI_Division class. with the default value.

        /// </summary>
        public COI_Division()
        {
            this._PK_COI_Division = -1;
            this._Fld_Desc = "";

        }



        /// <summary> 

        /// Initializes a new instance of the COI_Division class for passed PrimaryKey with the values set from Database.

        /// </summary>
        public COI_Division(decimal PK)
        {
            DataTable dtCOI_Division = Select(PK).Tables[0];

            if (dtCOI_Division.Rows.Count > 0)
            {

                DataRow drCOI_Division = dtCOI_Division.Rows[0];
                this._PK_COI_Division = drCOI_Division["PK_COI_Division"] != DBNull.Value ? Convert.ToDecimal(drCOI_Division["PK_COI_Division"]) : 0;
                this._Fld_Desc = Convert.ToString(drCOI_Division["Fld_Desc"]);

            }

            else
            {

                new COI_Division();
            }

        }



        #endregion

        #region "Methods"
        

		/// <summary>
		/// Selects a single record from the COI_Division table.
		/// <summary>
		/// <returns>DataSet</returns>
		public static DataSet Select(decimal pK_COI_Division)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("COI_DivisionSelect");

			db.AddInParameter(dbCommand, "PK_COI_Division", DbType.Decimal, pK_COI_Division);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the COI_Division table.
		/// <summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("COI_DivisionSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

        
        #endregion
    }
}
