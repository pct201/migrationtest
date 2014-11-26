using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for Constituent_First_Report table.
	/// </summary>
	public sealed class Constituent_First_Report
    {
        #region Fields


        private decimal _PK_Constituent_First_Report_ID;
        private decimal _FK_First_Report_Wizard_ID;
        private string _First_Report_Table;
        private decimal _FK_First_Report_ID;

        #endregion


        #region Properties


        /// <summary> 
        /// Gets or sets the PK_Constituent_First_Report_ID value.
        /// </summary>
        public decimal PK_Constituent_First_Report_ID
        {
            get { return _PK_Constituent_First_Report_ID; }
            set { _PK_Constituent_First_Report_ID = value; }
        }


        /// <summary> 
        /// Gets or sets the FK_First_Report_Wizard_ID value.
        /// </summary>
        public decimal FK_First_Report_Wizard_ID
        {
            get { return _FK_First_Report_Wizard_ID; }
            set { _FK_First_Report_Wizard_ID = value; }
        }


        /// <summary> 
        /// Gets or sets the First_Report_Table value.
        /// </summary>
        public string First_Report_Table
        {
            get { return _First_Report_Table; }
            set { _First_Report_Table = value; }
        }


        /// <summary> 
        /// Gets or sets the FK_First_Report_ID value.
        /// </summary>
        public decimal FK_First_Report_ID
        {
            get { return _FK_First_Report_ID; }
            set { _FK_First_Report_ID = value; }
        }



        #endregion


        #region Constructors

        /// <summary> 

        /// Initializes a new instance of the Constituent_First_Report class. with the default value.

        /// </summary>
        public Constituent_First_Report()
        {

            this._PK_Constituent_First_Report_ID = -1;
            this._FK_First_Report_Wizard_ID = -1;
            this._First_Report_Table = "";
            this._FK_First_Report_ID = -1;

        }



        /// <summary> 

        /// Initializes a new instance of the Constituent_First_Report class for passed PrimaryKey with the values set from Database.


        /// </summary>
        public Constituent_First_Report(decimal PK)
        {

            DataTable dtConstituent_First_Report = SelectByPK(PK).Tables[0];

            if (dtConstituent_First_Report.Rows.Count > 0)
            {

                DataRow drConstituent_First_Report = dtConstituent_First_Report.Rows[0];

                this._PK_Constituent_First_Report_ID = drConstituent_First_Report["PK_Constituent_First_Report_ID"] != DBNull.Value ? Convert.ToDecimal(drConstituent_First_Report["PK_Constituent_First_Report_ID"]) : 0;
                this._FK_First_Report_Wizard_ID = drConstituent_First_Report["FK_First_Report_Wizard_ID"] != DBNull.Value ? Convert.ToDecimal(drConstituent_First_Report["FK_First_Report_Wizard_ID"]) : 0;
                this._First_Report_Table = Convert.ToString(drConstituent_First_Report["First_Report_Table"]);
                this._FK_First_Report_ID = drConstituent_First_Report["FK_First_Report_ID"] != DBNull.Value ? Convert.ToDecimal(drConstituent_First_Report["FK_First_Report_ID"]) : 0;

            }

            else
            {

                this._PK_Constituent_First_Report_ID = -1;
                this._FK_First_Report_Wizard_ID = -1;
                this._First_Report_Table = "";
                this._FK_First_Report_ID = -1;

            }

        }



        #endregion

        #region Methods
        /// <summary>
        /// Inserts a record into the Constituent_First_Report table.
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Constituent_First_ReportInsert");

            db.AddInParameter(dbCommand, "FK_First_Report_Wizard_ID", DbType.Decimal, this._FK_First_Report_Wizard_ID);
            db.AddInParameter(dbCommand, "First_Report_Table", DbType.String, this._First_Report_Table);
            db.AddInParameter(dbCommand, "FK_First_Report_ID", DbType.Decimal, this._FK_First_Report_ID);

            // Execute the query and return the new identity value
            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
        }

        /// <summary>
        /// Selects a single record from the Constituent_First_Report table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectByPK(decimal pK_Constituent_First_Report_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Constituent_First_ReportSelectByPK");

            db.AddInParameter(dbCommand, "PK_Constituent_First_Report_ID", DbType.Decimal, pK_Constituent_First_Report_ID);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the Constituent_First_Report table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Constituent_First_ReportSelectAll");

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Updates a record in the Constituent_First_Report table.
        /// </summary>
        public void Update()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Constituent_First_ReportUpdate");

            db.AddInParameter(dbCommand, "PK_Constituent_First_Report_ID", DbType.Decimal, this._PK_Constituent_First_Report_ID);
            db.AddInParameter(dbCommand, "FK_First_Report_Wizard_ID", DbType.Decimal, this._FK_First_Report_Wizard_ID);
            db.AddInParameter(dbCommand, "First_Report_Table", DbType.String, this._First_Report_Table);
            db.AddInParameter(dbCommand, "FK_First_Report_ID", DbType.Decimal, this._FK_First_Report_ID);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Deletes a record from the Constituent_First_Report table by a composite primary key.
        /// </summary>
        public static void DeleteByPK(decimal pK_Constituent_First_Report_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Constituent_First_ReportDeleteByPK");

            db.AddInParameter(dbCommand, "PK_Constituent_First_Report_ID", DbType.Decimal, pK_Constituent_First_Report_ID);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// get Constituent First Report by First Report Wizard ID
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectConstituentDetails_byFirstReportID(decimal FK_First_Report_Wizard_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Companion_First_Report_GetDetails");

            db.AddInParameter(dbCommand, "FK_First_Report_Wizard_ID", DbType.Decimal, FK_First_Report_Wizard_ID);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// get Constituent First Report List by First Report Wizard ID
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectConstituentReportList_byFirstReportID(decimal FK_First_Report_Wizard_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Companion_First_Report_GetReportList");

            db.AddInParameter(dbCommand, "FK_First_Report_Wizard_ID", DbType.Decimal, FK_First_Report_Wizard_ID);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// get Constituent Clim First Report List by First Report ID
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectConstituentReportList_byFirstReportID_Claim(decimal Fk_First_Report_ID, string First_Report_Table)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Companion_Claim_Report_GetReportList");

            db.AddInParameter(dbCommand, "Fk_First_Report_ID", DbType.Decimal, Fk_First_Report_ID);
            db.AddInParameter(dbCommand, "First_Report_Table", DbType.String, First_Report_Table);

            return db.ExecuteDataSet(dbCommand);
        }
        #endregion

        
	}
}
