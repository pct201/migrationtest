using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for COI_Coverage_Status table.
	/// </summary>
	public sealed class COI_Coverage_Status
    {
        #region Fields

        private decimal _PK_COI_Coverage_Status;
        private string _Fld_Desc;

        #endregion


        #region Properties

        /// <summary> 
        /// Gets or sets the PK_COI_Coverage_Status value.
        /// </summary>
        public decimal PK_COI_Coverage_Status
        {
            get { return _PK_COI_Coverage_Status; }
            set { _PK_COI_Coverage_Status = value; }
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

        /// Initializes a new instance of the COI_Coverage_Status class. with the default value.

        /// </summary>
        public COI_Coverage_Status()
        {

            this._PK_COI_Coverage_Status = -1;
            this._Fld_Desc = "";

        }



        /// <summary> 

        /// Initializes a new instance of the COI_Coverage_Status class for passed PrimaryKey with the values set from Database.

        /// </summary>
        public COI_Coverage_Status(decimal PK)
        {
            DataTable dtCOI_Coverage_Status = Select(PK).Tables[0];

            if (dtCOI_Coverage_Status.Rows.Count > 0)
            {

                DataRow drCOI_Coverage_Status = dtCOI_Coverage_Status.Rows[0];

                this._PK_COI_Coverage_Status = drCOI_Coverage_Status["PK_COI_Coverage_Status"] != DBNull.Value ? Convert.ToDecimal(drCOI_Coverage_Status["PK_COI_Coverage_Status"]) : 0;
                this._Fld_Desc = Convert.ToString(drCOI_Coverage_Status["Fld_Desc"]);

            }

            else
            {

                new COI_Coverage_Status();
            }

        }



        #endregion

        #region "Methods"
        
		/// <summary>
		/// Selects a single record from the COI_Coverage_Status table.
		/// <summary>
		/// <returns>DataSet</returns>
		public static DataSet Select(decimal pK_COI_Coverage_Status)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("COI_Coverage_StatusSelect");

			db.AddInParameter(dbCommand, "PK_COI_Coverage_Status", DbType.Decimal, pK_COI_Coverage_Status);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the COI_Coverage_Status table.
		/// <summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("COI_Coverage_StatusSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

        
        #endregion
    }
}
