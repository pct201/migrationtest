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
    /// Summary description for Tatva_RptLossLimitationSchedule
    /// </summary>
    public class Tatva_RptLossLimitationSchedule : Tatva_ReportSchedule
    {
        #region Fields
        private decimal _PK_ID;
        private decimal _FK_Schedule;
        private decimal _Limit1;
        private DateTime _From_Date_Of_Loss1;
        private DateTime _To_Date_Of_Loss1;
        private decimal _Limit2;
        private DateTime _From_Date_Of_Loss2;
        private DateTime _To_Date_Of_Loss2;
        private decimal _Limit3;
        private DateTime _From_Date_Of_Loss3;
        private DateTime _To_Date_Of_Loss3;
        private string _Claim_Type;
        #endregion

        #region Properties

        /// <summary> 
        /// Gets or sets the Claim_Type value.
        /// </summary> 
        public string Claim_Type
        {
            get { return _Claim_Type; }
            set { _Claim_Type = value; }
        }

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
        /// Gets or sets the Limit1 value.
        /// </summary> 
        public decimal Limit1
        {
            get { return _Limit1; }
            set { _Limit1 = value; }
        }

        /// <summary> 
        /// Gets or sets the From_Date_Of_Loss1 value.
        /// </summary> 
        public DateTime From_Date_Of_Loss1
        {
            get { return _From_Date_Of_Loss1; }
            set { _From_Date_Of_Loss1 = value; }
        }

        /// <summary> 
        /// Gets or sets the To_Date_Of_Loss1 value.
        /// </summary> 
        public DateTime To_Date_Of_Loss1
        {
            get { return _To_Date_Of_Loss1; }
            set { _To_Date_Of_Loss1 = value; }
        }

        /// <summary> 
        /// Gets or sets the Limit2 value.
        /// </summary> 
        public decimal Limit2
        {
            get { return _Limit2; }
            set { _Limit2 = value; }
        }

        /// <summary> 
        /// Gets or sets the From_Date_Of_Loss2 value.
        /// </summary> 
        public DateTime From_Date_Of_Loss2
        {
            get { return _From_Date_Of_Loss2; }
            set { _From_Date_Of_Loss2 = value; }
        }

        /// <summary> 
        /// Gets or sets the To_Date_Of_Loss2 value.
        /// </summary> 
        public DateTime To_Date_Of_Loss2
        {
            get { return _To_Date_Of_Loss2; }
            set { _To_Date_Of_Loss2 = value; }
        }

        /// <summary> 
        /// Gets or sets the Limit3 value.
        /// </summary> 
        public decimal Limit3
        {
            get { return _Limit3; }
            set { _Limit3 = value; }
        }

        /// <summary> 
        /// Gets or sets the From_Date_Of_Loss3 value.
        /// </summary> 
        public DateTime From_Date_Of_Loss3
        {
            get { return _From_Date_Of_Loss3; }
            set { _From_Date_Of_Loss3 = value; }
        }

        /// <summary> 
        /// Gets or sets the To_Date_Of_Loss3 value.
        /// </summary> 
        public DateTime To_Date_Of_Loss3
        {
            get { return _To_Date_Of_Loss3; }
            set { _To_Date_Of_Loss3 = value; }
        }

        #endregion

        #region Constructors

        /// <summary> 
        /// Initializes a new instance of the Tatva_RptLossLimitationSchedule class. with the default value.
        /// </summary>
        public Tatva_RptLossLimitationSchedule()
        {
            this._Claim_Type = "";
            this._PK_ID = -1;
            this._FK_Schedule = -1;
            this._Limit1 = -1;
            this._From_Date_Of_Loss1 = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            this._To_Date_Of_Loss1 = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            this._Limit2 = -1;
            this._From_Date_Of_Loss2 = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            this._To_Date_Of_Loss2 = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            this._Limit3 = -1;
            this._From_Date_Of_Loss3 = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            this._To_Date_Of_Loss3 = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
        }


        /// <summary> 
        /// Initializes a new instance of the Tatva_RptLossLimitationSchedule class for passed PrimaryKey with the values set from Database.
        /// </summary>
        public Tatva_RptLossLimitationSchedule(decimal PK)
        {
            DataTable dtTatva_RptLossLimitationSchedule = SelectByPK(PK).Tables[0];
            if (dtTatva_RptLossLimitationSchedule.Rows.Count > 0)
            {
                DataRow drTatva_RptLossLimitationSchedule = dtTatva_RptLossLimitationSchedule.Rows[0];
                this._Claim_Type = drTatva_RptLossLimitationSchedule["Claim_Type"] != DBNull.Value ? Convert.ToString(drTatva_RptLossLimitationSchedule["Claim_Type"]) : "";
                this._PK_ID = drTatva_RptLossLimitationSchedule["PK_ID"] != DBNull.Value ? Convert.ToDecimal(drTatva_RptLossLimitationSchedule["PK_ID"]) : 0;
                this._FK_Schedule = drTatva_RptLossLimitationSchedule["FK_Schedule"] != DBNull.Value ? Convert.ToDecimal(drTatva_RptLossLimitationSchedule["FK_Schedule"]) : 0;
                this._Limit1 = drTatva_RptLossLimitationSchedule["Limit1"] != DBNull.Value ? Convert.ToDecimal(drTatva_RptLossLimitationSchedule["Limit1"]) : 0;
                this._From_Date_Of_Loss1 = drTatva_RptLossLimitationSchedule["From_Date_Of_Loss1"] != DBNull.Value ? Convert.ToDateTime(drTatva_RptLossLimitationSchedule["From_Date_Of_Loss1"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._To_Date_Of_Loss1 = drTatva_RptLossLimitationSchedule["To_Date_Of_Loss1"] != DBNull.Value ? Convert.ToDateTime(drTatva_RptLossLimitationSchedule["To_Date_Of_Loss1"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Limit2 = drTatva_RptLossLimitationSchedule["Limit2"] != DBNull.Value ? Convert.ToDecimal(drTatva_RptLossLimitationSchedule["Limit2"]) : 0;
                this._From_Date_Of_Loss2 = drTatva_RptLossLimitationSchedule["From_Date_Of_Loss2"] != DBNull.Value ? Convert.ToDateTime(drTatva_RptLossLimitationSchedule["From_Date_Of_Loss2"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._To_Date_Of_Loss2 = drTatva_RptLossLimitationSchedule["To_Date_Of_Loss2"] != DBNull.Value ? Convert.ToDateTime(drTatva_RptLossLimitationSchedule["To_Date_Of_Loss2"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Limit3 = drTatva_RptLossLimitationSchedule["Limit3"] != DBNull.Value ? Convert.ToDecimal(drTatva_RptLossLimitationSchedule["Limit3"]) : 0;
                this._From_Date_Of_Loss3 = drTatva_RptLossLimitationSchedule["From_Date_Of_Loss3"] != DBNull.Value ? Convert.ToDateTime(drTatva_RptLossLimitationSchedule["From_Date_Of_Loss3"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._To_Date_Of_Loss3 = drTatva_RptLossLimitationSchedule["To_Date_Of_Loss3"] != DBNull.Value ? Convert.ToDateTime(drTatva_RptLossLimitationSchedule["To_Date_Of_Loss3"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            }
            else
            {
                this._Claim_Type = "";
                this._PK_ID = -1;
                this._FK_Schedule = -1;
                this._Limit1 = -1;
                this._From_Date_Of_Loss1 = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._To_Date_Of_Loss1 = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Limit2 = -1;
                this._From_Date_Of_Loss2 = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._To_Date_Of_Loss2 = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Limit3 = -1;
                this._From_Date_Of_Loss3 = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._To_Date_Of_Loss3 = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            }
        }


        #endregion

        #region Methods
        /// <summary>
        /// Inserts a record into the Tatva_RptLossLimitationSchedule table.
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            this.FK_Schedule = base.Insert();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Tatva_RptLossLimitationScheduleInsert");

            db.AddInParameter(dbCommand, "Claim_Type", DbType.String, this.Claim_Type);
            db.AddInParameter(dbCommand, "FK_Schedule", DbType.Decimal, this.FK_Schedule);
            db.AddInParameter(dbCommand, "Limit1", DbType.Decimal, this._Limit1);
            db.AddInParameter(dbCommand, "From_Date_Of_Loss1", DbType.DateTime, this._From_Date_Of_Loss1);
            db.AddInParameter(dbCommand, "To_Date_Of_Loss1", DbType.DateTime, this._To_Date_Of_Loss1);
            db.AddInParameter(dbCommand, "Limit2", DbType.Decimal, this._Limit2);
            db.AddInParameter(dbCommand, "From_Date_Of_Loss2", DbType.DateTime, this._From_Date_Of_Loss2);
            db.AddInParameter(dbCommand, "To_Date_Of_Loss2", DbType.DateTime, this._To_Date_Of_Loss2);
            db.AddInParameter(dbCommand, "Limit3", DbType.Decimal, this._Limit3);
            db.AddInParameter(dbCommand, "From_Date_Of_Loss3", DbType.DateTime, this._From_Date_Of_Loss3);
            db.AddInParameter(dbCommand, "To_Date_Of_Loss3", DbType.DateTime, this._To_Date_Of_Loss3);

            // Execute the query and return the new identity value
            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
        }

        /// <summary>
        /// Selects a single record from the Tatva_RptLossLimitationSchedule table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectByPK(decimal pK_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Tatva_RptLossLimitationScheduleSelectByPK");

            db.AddInParameter(dbCommand, "PK_ID", DbType.Decimal, pK_ID);

            return db.ExecuteDataSet(dbCommand);
        }
        public static DataSet SelectByFK_Schedule(decimal fK_Schedule)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Tatva_RptLossLimitationScheduleSelectByFK_Schedule");

            db.AddInParameter(dbCommand, "FK_Schedule", DbType.Decimal, fK_Schedule);

            return db.ExecuteDataSet(dbCommand);
        }
        #endregion
    }
}