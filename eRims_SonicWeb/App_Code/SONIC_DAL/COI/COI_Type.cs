using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for COI_Type table.
	/// </summary>
	public sealed class COI_Type
    {
        #region Fields


        private decimal _PK_COI_Type;
        private string _Fld_Desc;
        private decimal _FK_COI_Risk_Profile;
        #endregion


        #region Properties

        /// <summary> 
        /// Gets or sets the PK_COI_Type value.
        /// </summary>
        public decimal PK_COI_Type
        {
            get { return _PK_COI_Type; }
            set { _PK_COI_Type = value; }
        }


        /// <summary> 
        /// Gets or sets the Fld_Desc value.
        /// </summary>
        public string Fld_Desc
        {
            get { return _Fld_Desc; }
            set { _Fld_Desc = value; }
        }


        /// <summary>  /// Gets or sets the FK_COI_Risk_Profile value. /// </summary> 
        public decimal FK_COI_Risk_Profile {  get { return _FK_COI_Risk_Profile; }  set { _FK_COI_Risk_Profile = value; } }  
        #endregion


        #region Constructors

        /// <summary> 

        /// Initializes a new instance of the COI_Type class. with the default value.

        /// </summary>
        public COI_Type()
        {
            this._PK_COI_Type = -1;
            this._Fld_Desc = "";
            this._FK_COI_Risk_Profile = -1;
        }



        /// <summary> 

        /// Initializes a new instance of the COI_Type class for passed PrimaryKey with the values set from Database.

        /// </summary>
        public COI_Type(decimal PK)
        {
            DataTable dtCOI_Type = Select(PK).Tables[0];

            if (dtCOI_Type.Rows.Count > 0)
            {

                DataRow drCOI_Type = dtCOI_Type.Rows[0];
                this._PK_COI_Type = drCOI_Type["PK_COI_Type"] != DBNull.Value ? Convert.ToDecimal(drCOI_Type["PK_COI_Type"]) : 0;
                this._Fld_Desc = Convert.ToString(drCOI_Type["Fld_Desc"]);
                this._FK_COI_Risk_Profile = drCOI_Type["FK_COI_Risk_Profile"] != DBNull.Value ? Convert.ToDecimal(drCOI_Type["FK_COI_Risk_Profile"]) : 0;
            }

            else
            {

                new COI_Type();
            }

        }



        #endregion

        #region "Methods"
        

		/// <summary>
		/// Selects a single record from the COI_Type table.
		/// <summary>
		/// <returns>DataSet</returns>
		public static DataSet Select(decimal pK_COI_Type)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("COI_TypeSelect");

			db.AddInParameter(dbCommand, "PK_COI_Type", DbType.Decimal, pK_COI_Type);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the COI_Type table.
		/// <summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("COI_TypeSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

        
        #endregion
    }
}
