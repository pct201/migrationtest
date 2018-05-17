using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
    /// <summary>
    /// Data access class for Tatva_Report table.
    /// </summary>
    public class Tatva_Report
    {
        #region Fields
        private decimal _PK_ReportID;
        private string _Report_Name;
        private string _Report_Description;
        #endregion

        #region Properties
        /// <summary>  /// Gets or sets the PK_ReportID value. /// </summary> 
        public decimal PK_ReportID { get { return _PK_ReportID; } set { _PK_ReportID = value; } }
        /// <summary>  /// Gets or sets the Report_Name value. /// </summary> 
        public string Report_Name { get { return _Report_Name; } set { _Report_Name = value; } }
        /// <summary>  /// Gets or sets the Report_Description value. /// </summary> 
        public string Report_Description { get { return _Report_Description; } set { _Report_Description = value; } }
        #endregion

        #region Constructors
        private Tatva_Report()
        {
            this._PK_ReportID = -1;
            this._Report_Name = "";
            this._Report_Description = "";
        }
        /// </summary> 
        public Tatva_Report(decimal PK)
        {
            DataTable dtTatva_Report = SelectByPK(PK).Tables[0];
            if (dtTatva_Report.Rows.Count > 0)
            {
                DataRow drTatva_Report = dtTatva_Report.Rows[0];
                this._PK_ReportID = drTatva_Report["PK_ReportID"] != DBNull.Value ? Convert.ToDecimal(drTatva_Report["PK_ReportID"]) : 0;
                this._Report_Name = Convert.ToString(drTatva_Report["Report_Name"]);
                this._Report_Description = Convert.ToString(drTatva_Report["Report_Description"]);
            }
            else
            {
                this._PK_ReportID = -1;
                this._Report_Name = "";
                this._Report_Description = "";
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Inserts a record into the Tatva_Report table.
        /// </summary>
        /// <returns></returns>
        public void Insert()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Tatva_ReportInsert");

            db.AddInParameter(dbCommand, "PK_ReportID", DbType.Decimal, this._PK_ReportID);
            db.AddInParameter(dbCommand, "Report_Name", DbType.String, this._Report_Name);
            db.AddInParameter(dbCommand, "Report_Description", DbType.String, this._Report_Description);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Selects a single record from the Tatva_Report table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectByPK(decimal pK_ReportID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Tatva_ReportSelectByPK");

            db.AddInParameter(dbCommand, "PK_ReportID", DbType.Decimal, pK_ReportID);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the Tatva_Report table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Tatva_ReportSelectAll");

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Updates a record in the Tatva_Report table.
        /// </summary>
        public void Update()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Tatva_ReportUpdate");

            db.AddInParameter(dbCommand, "PK_ReportID", DbType.Decimal, this._PK_ReportID);
            db.AddInParameter(dbCommand, "Report_Name", DbType.String, this._Report_Name);
            db.AddInParameter(dbCommand, "Report_Description", DbType.String, this._Report_Description);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Deletes a record from the Tatva_Report table by a composite primary key.
        /// </summary>
        public static void DeleteByPK(decimal pK_ReportID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Tatva_ReportDeleteByPK");

            db.AddInParameter(dbCommand, "PK_ReportID", DbType.Decimal, pK_ReportID);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Selects records by report type from the Tatva_Report table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectByReportType(string ReportType,bool IsACI_User)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Tatva_ReportSelectByReportType");
            db.AddInParameter(dbCommand, "ReportType", DbType.String, ReportType);
            db.AddInParameter(dbCommand, "IsACI_User", DbType.Boolean, IsACI_User);
            return db.ExecuteDataSet(dbCommand);
        }
        #endregion







    }
}
