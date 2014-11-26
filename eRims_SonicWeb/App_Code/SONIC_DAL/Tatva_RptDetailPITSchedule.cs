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
    /// Summary description for Tatva_RptDetailPITSchedule
    /// </summary>
    public class Tatva_RptDetailPITSchedule : Tatva_ReportSchedule
    {
        #region Fields
        private decimal _PK_ID;
        private decimal _FK_Schedule;
        private string _Claim_Type;
        private DateTime _Compare_First_Date;
        private DateTime _Compare_Second_Date;
        private DateTime _From_Date_Of_Loss;
        private DateTime _To_Date_Of_Loss;
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
        /// Gets or sets the From_Date_Of_Loss value.
        /// </summary> 
        public DateTime From_Date_Of_Loss
        {
            get { return _From_Date_Of_Loss; }
            set { _From_Date_Of_Loss = value; }
        }


        /// <summary> 
        /// Gets or sets the To_Date_Of_Loss value.
        /// </summary> 
        public DateTime To_Date_Of_Loss
        {
            get { return _To_Date_Of_Loss; }
            set { _To_Date_Of_Loss = value; }
        }



        #endregion


        #region Constructors

        /// <summary> 
        /// Initializes a new instance of the Tatva_RptDetailPITSchedule class. with the default value.
        /// </summary>
        public Tatva_RptDetailPITSchedule()
        {
            this._PK_ID = -1;
            this._FK_Schedule = -1;
            this._Claim_Type = "";
            this._Compare_First_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            this._Compare_Second_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            this._From_Date_Of_Loss = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            this._To_Date_Of_Loss = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
        }


        /// <summary> 
        /// Initializes a new instance of the Tatva_RptDetailPITSchedule class for passed PrimaryKey with the values set from Database.
        /// </summary>
        public Tatva_RptDetailPITSchedule(decimal PK)
        {
            DataTable dtTatva_RptDetailPITSchedule = SelectByPK(PK).Tables[0];
            if (dtTatva_RptDetailPITSchedule.Rows.Count > 0)
            {
                DataRow drTatva_RptDetailPITSchedule = dtTatva_RptDetailPITSchedule.Rows[0];
                this._PK_ID = drTatva_RptDetailPITSchedule["PK_ID"] != DBNull.Value ? Convert.ToDecimal(drTatva_RptDetailPITSchedule["PK_ID"]) : 0;
                this._FK_Schedule = drTatva_RptDetailPITSchedule["FK_Schedule"] != DBNull.Value ? Convert.ToDecimal(drTatva_RptDetailPITSchedule["FK_Schedule"]) : 0;
                this._Claim_Type = Convert.ToString(drTatva_RptDetailPITSchedule["Claim_Type"]);
                this._Compare_First_Date = drTatva_RptDetailPITSchedule["Compare_First_Date"] != DBNull.Value ? Convert.ToDateTime(drTatva_RptDetailPITSchedule["Compare_First_Date"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Compare_Second_Date = drTatva_RptDetailPITSchedule["Compare_Second_Date"] != DBNull.Value ? Convert.ToDateTime(drTatva_RptDetailPITSchedule["Compare_Second_Date"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._From_Date_Of_Loss = drTatva_RptDetailPITSchedule["From_Date_Of_Loss"] != DBNull.Value ? Convert.ToDateTime(drTatva_RptDetailPITSchedule["From_Date_Of_Loss"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._To_Date_Of_Loss = drTatva_RptDetailPITSchedule["To_Date_Of_Loss"] != DBNull.Value ? Convert.ToDateTime(drTatva_RptDetailPITSchedule["To_Date_Of_Loss"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            }
            else
            {
                this._PK_ID = -1;
                this._FK_Schedule = -1;
                this._Claim_Type = "";
                this._Compare_First_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Compare_Second_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._From_Date_Of_Loss = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._To_Date_Of_Loss = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            }
        }


        #endregion


        #region Methods

        /// <summary>
        /// Inserts a record into the Tatva_RptDetailPITSchedule table.
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            this.FK_Schedule = base.Insert();

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Tatva_RptDetailPITScheduleInsert");

            db.AddInParameter(dbCommand, "FK_Schedule", DbType.Decimal, this.FK_Schedule);
            db.AddInParameter(dbCommand, "Claim_Type", DbType.String, this._Claim_Type);
            db.AddInParameter(dbCommand, "Compare_First_Date", DbType.DateTime, this._Compare_First_Date);
            db.AddInParameter(dbCommand, "Compare_Second_Date", DbType.DateTime, this._Compare_Second_Date);
            db.AddInParameter(dbCommand, "From_Date_Of_Loss", DbType.DateTime, this._From_Date_Of_Loss);
            db.AddInParameter(dbCommand, "To_Date_Of_Loss", DbType.DateTime, this._To_Date_Of_Loss);

            // Execute the query and return the new identity value
            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
        }
        /// <summary>
        /// Selects a single record from the Tatva_RptDetailPITSchedule table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectByPK(decimal pK_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Tatva_RptDetailPITScheduleSelectByPK");

            db.AddInParameter(dbCommand, "PK_ID", DbType.Decimal, pK_ID);

            return db.ExecuteDataSet(dbCommand);
        }
        public static DataSet SelectByFK_Schedule(decimal fK_Schedule)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Tatva_RptDetailPITScheduleSelectByFK_Schedule");

            db.AddInParameter(dbCommand, "FK_Schedule", DbType.Decimal, fK_Schedule);

            return db.ExecuteDataSet(dbCommand);
        }
        #endregion
    }
}