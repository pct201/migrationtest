using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for Business_Rules_Screens table.
	/// </summary>
	public sealed class clsBusiness_Rules_Screens
	{

        #region Private variables used to hold the property values

        private decimal? _PK_Business_Rules_Screens;
        private decimal? _FK_Buisness_Rules_Modules;
        private string _Screen;
        private bool? _Active;
        private string _Main_Table;
        private string _UpdateDateCol;

        #endregion

        #region Public Property

        /// <summary>
        /// Gets or sets the PK_Business_Rules_Screens value.
        /// </summary>
        public decimal? PK_Business_Rules_Screens
        {
            get { return _PK_Business_Rules_Screens; }
            set { _PK_Business_Rules_Screens = value; }
        }

        /// <summary>
        /// Gets or sets the FK_Buisness_Rules_Modules value.
        /// </summary>
        public decimal? FK_Buisness_Rules_Modules
        {
            get { return _FK_Buisness_Rules_Modules; }
            set { _FK_Buisness_Rules_Modules = value; }
        }

        /// <summary>
        /// Gets or sets the Screen value.
        /// </summary>
        public string Screen
        {
            get { return _Screen; }
            set { _Screen = value; }
        }

        /// <summary>
        /// Gets or sets the Active value.
        /// </summary>
        public bool? Active
        {
            get { return _Active; }
            set { _Active = value; }
        }

        /// <summary>
        /// Gets or sets the Main_Table value.
        /// </summary>
        public string Main_Table
        {
            get { return _Main_Table; }
            set { _Main_Table = value; }
        }

        /// <summary>
        /// Gets or sets the UpdateDateCol value.
        /// </summary>
        public string UpdateDateCol
        {
            get { return _UpdateDateCol; }
            set { _UpdateDateCol = value; }
        }


        #endregion

        #region Default Constructors

        /// <summary>
        /// Initializes a new instance of the clsBusiness_Rules_Screens class with default value.
        /// </summary>
        public clsBusiness_Rules_Screens()
        {


        }

        #endregion

        #region Primary Constructors

        /// <summary>
        /// Initializes a new instance of the clsBusiness_Rules_Screens class based on Primary Key.
        /// </summary>
        public clsBusiness_Rules_Screens(decimal pK_Business_Rules_Screens)
        {
            DataTable dtBusiness_Rules_Screens = SelectByPK(pK_Business_Rules_Screens).Tables[0];

            if (dtBusiness_Rules_Screens.Rows.Count == 1)
            {
                SetValue(dtBusiness_Rules_Screens.Rows[0]);

            }

        }


        /// <summary>
        /// Initializes a new instance of the clsBusiness_Rules_Screens class based on Datarow passed.
        /// </summary>
        private void SetValue(DataRow drBusiness_Rules_Screens)
        {
            if (drBusiness_Rules_Screens["PK_Business_Rules_Screens"] == DBNull.Value)
                this._PK_Business_Rules_Screens = null;
            else
                this._PK_Business_Rules_Screens = (decimal?)drBusiness_Rules_Screens["PK_Business_Rules_Screens"];

            if (drBusiness_Rules_Screens["FK_Buisness_Rules_Modules"] == DBNull.Value)
                this._FK_Buisness_Rules_Modules = null;
            else
                this._FK_Buisness_Rules_Modules = (decimal?)drBusiness_Rules_Screens["FK_Buisness_Rules_Modules"];

            if (drBusiness_Rules_Screens["Screen"] == DBNull.Value)
                this._Screen = null;
            else
                this._Screen = (string)drBusiness_Rules_Screens["Screen"];

            if (drBusiness_Rules_Screens["Active"] == DBNull.Value)
                this._Active = null;
            else
                this._Active = (bool?)drBusiness_Rules_Screens["Active"];

            if (drBusiness_Rules_Screens["Main_Table"] == DBNull.Value)
                this._Main_Table = null;
            else
                this._Main_Table = (string)drBusiness_Rules_Screens["Main_Table"];

            if (drBusiness_Rules_Screens["UpdateDateCol"] == DBNull.Value)
                this._UpdateDateCol = null;
            else
                this._UpdateDateCol = (string)drBusiness_Rules_Screens["UpdateDateCol"];


        }

        #endregion

		
		/// <summary>
		/// Selects a single record from the Business_Rules_Screens table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		public DataSet SelectByPK(decimal pK_Business_Rules_Screens)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Business_Rules_ScreensSelectByPK");

			db.AddInParameter(dbCommand, "PK_Business_Rules_Screens", DbType.Decimal, pK_Business_Rules_Screens);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the Business_Rules_Screens table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Business_Rules_ScreensSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

        /// <summary>
        /// Selects a single record from the Business_Rules_Screens table by a foreign key.
        /// </summary>
        /// <returns>DataSet</returns>
        public DataSet SelectByFK(decimal fK_Buisness_Rules_Modules)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Business_Rules_ScreensSelectByFK");

            db.AddInParameter(dbCommand, "FK_Buisness_Rules_Modules", DbType.Decimal, fK_Buisness_Rules_Modules);

            return db.ExecuteDataSet(dbCommand);
        }
		
	}
}
