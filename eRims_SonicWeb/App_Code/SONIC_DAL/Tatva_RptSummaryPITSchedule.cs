using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using ERIMS.DAL;

namespace ERIMS.DAL
{
    /// <summary>
    /// Summary description for Tatva_RptSummaryPITSchedule
    /// </summary>
    public class Tatva_RptSummaryPITSchedule : Tatva_ReportSchedule
    {
        #region Fields
        private decimal _PK_ID;
        private decimal _FK_Schedule;
        private string _Claim_Type;
        private DateTime _Compare_First_Date;
        private DateTime _Compare_Second_Date;
        private string _Policy_Year;

        #endregion


        #region Properties
        /// <summary> 
        /// Gets or sets the PK_ID value.
        /// </summary> 
        public decimal PK_ID
        {
            get { return _PK_ID; }
            set { _PK_ID = value; }
        }


        /// <summary> 
        /// Gets or sets the FK_Schedule value.
        /// </summary> 
        public decimal FK_Schedule
        {
            get { return _FK_Schedule; }
            set { _FK_Schedule = value; }
        }


        /// <summary> 
        /// Gets or sets the Claim_Type value.
        /// </summary> 
        public string Claim_Type
        {
            get { return _Claim_Type; }
            set { _Claim_Type = value; }
        }


        /// <summary> 
        /// Gets or sets the Compare_First_Date value.
        /// </summary> 
        public DateTime Compare_First_Date
        {
            get { return _Compare_First_Date; }
            set { _Compare_First_Date = value; }
        }


        /// <summary> 
        /// Gets or sets the Compare_Second_Date value.
        /// </summary> 
        public DateTime Compare_Second_Date
        {
            get { return _Compare_Second_Date; }
            set { _Compare_Second_Date = value; }
        }


        /// <summary> 
        /// Gets or sets the Policy_Year value.
        /// </summary> 
        public string Policy_Year
        {
            get { return _Policy_Year; }
            set { _Policy_Year = value; }
        }



        #endregion


        #region Constructors

        /// <summary> 
        /// Initializes a new instance of the Tatva_RptSummaryPITSchedule class. with the default value.
        /// </summary>
        public Tatva_RptSummaryPITSchedule()
        {
            this._PK_ID = -1;
            this._FK_Schedule = -1;
            this._Claim_Type = "";
            this._Compare_First_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            this._Compare_Second_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            this._Policy_Year = "";
        }


        /// <summary> 
        /// Initializes a new instance of the Tatva_RptSummaryPITSchedule class for passed PrimaryKey with the values set from Database.
        /// </summary>
        public Tatva_RptSummaryPITSchedule(decimal PK)
        {
            DataTable dtTatva_RptSummaryPITSchedule = SelectByPK(PK).Tables[0];
            if (dtTatva_RptSummaryPITSchedule.Rows.Count > 0)
            {
                DataRow drTatva_RptSummaryPITSchedule = dtTatva_RptSummaryPITSchedule.Rows[0];
                this._PK_ID = drTatva_RptSummaryPITSchedule["PK_ID"] != DBNull.Value ? Convert.ToDecimal(drTatva_RptSummaryPITSchedule["PK_ID"]) : 0;
                this._FK_Schedule = drTatva_RptSummaryPITSchedule["FK_Schedule"] != DBNull.Value ? Convert.ToDecimal(drTatva_RptSummaryPITSchedule["FK_Schedule"]) : 0;
                this._Claim_Type = Convert.ToString(drTatva_RptSummaryPITSchedule["Claim_Type"]);
                this._Compare_First_Date = drTatva_RptSummaryPITSchedule["Compare_First_Date"] != DBNull.Value ? Convert.ToDateTime(drTatva_RptSummaryPITSchedule["Compare_First_Date"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Compare_Second_Date = drTatva_RptSummaryPITSchedule["Compare_Second_Date"] != DBNull.Value ? Convert.ToDateTime(drTatva_RptSummaryPITSchedule["Compare_Second_Date"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Policy_Year = Convert.ToString(drTatva_RptSummaryPITSchedule["Policy_Year"]);
            }
            else
            {
                this._PK_ID = -1;
                this._FK_Schedule = -1;
                this._Claim_Type = "";
                this._Compare_First_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Compare_Second_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Policy_Year = "";
            }
        }


        #endregion


        #region Methods
        /// <summary>
        /// Inserts a record into the Tatva_RptSummaryPITSchedule table.
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            this.FK_Schedule = base.Insert();

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Tatva_RptSummaryPITScheduleInsert");

            db.AddInParameter(dbCommand, "FK_Schedule", DbType.Decimal, this.FK_Schedule);
            db.AddInParameter(dbCommand, "Claim_Type", DbType.String, this._Claim_Type);
            db.AddInParameter(dbCommand, "Compare_First_Date", DbType.DateTime, this._Compare_First_Date);
            db.AddInParameter(dbCommand, "Compare_Second_Date", DbType.DateTime, this._Compare_Second_Date);
            db.AddInParameter(dbCommand, "Policy_Year", DbType.String, this._Policy_Year);

            // Execute the query and return the new identity value
            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
        }

        /// <summary>
        /// Selects a single record from the Tatva_RptSummaryPITSchedule table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectByPK(decimal pK_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Tatva_RptSummaryPITScheduleSelectByPK");

            db.AddInParameter(dbCommand, "PK_ID", DbType.Decimal, pK_ID);

            return db.ExecuteDataSet(dbCommand);
        }
        public static DataSet SelectByFK_Schedule(decimal fK_Schedule)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Tatva_RptSummaryPITScheduleSelectByFK_Schedule");

            db.AddInParameter(dbCommand, "FK_Schedule", DbType.Decimal, fK_Schedule);

            return db.ExecuteDataSet(dbCommand);
        }
        #endregion
    }
}