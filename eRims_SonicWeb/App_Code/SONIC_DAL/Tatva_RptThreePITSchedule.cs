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
    /// Summary description for Tatva_RptThreePITSchedule
    /// </summary>
    public class Tatva_RptThreePITSchedule : Tatva_ReportSchedule
    {
        #region Fields
        private decimal _PK_ID;
        private decimal _FK_Schedule;
        private string _Claim_Type;
        private DateTime _As_Of_Date1;
        private DateTime _Compare_First_Date1;
        private DateTime _Compare_Second_Date1;
        private DateTime _As_Of_Date2;
        private DateTime _Compare_First_Date2;
        private DateTime _Compare_Second_Date2;
        private DateTime _As_Of_Date3;
        private DateTime _Compare_First_Date3;
        private DateTime _Compare_Second_Date3;
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
        /// Gets or sets the As_Of_Date1 value.
        /// </summary> 
        public DateTime As_Of_Date1
        {
            get { return _As_Of_Date1; }
            set { _As_Of_Date1 = value; }
        }


        /// <summary> 
        /// Gets or sets the Compare_First_Date1 value.
        /// </summary> 
        public DateTime Compare_First_Date1
        {
            get { return _Compare_First_Date1; }
            set { _Compare_First_Date1 = value; }
        }


        /// <summary> 
        /// Gets or sets the Compare_Second_Date1 value.
        /// </summary> 
        public DateTime Compare_Second_Date1
        {
            get { return _Compare_Second_Date1; }
            set { _Compare_Second_Date1 = value; }
        }


        /// <summary> 
        /// Gets or sets the As_Of_Date2 value.
        /// </summary> 
        public DateTime As_Of_Date2
        {
            get { return _As_Of_Date2; }
            set { _As_Of_Date2 = value; }
        }


        /// <summary> 
        /// Gets or sets the Compare_First_Date2 value.
        /// </summary> 
        public DateTime Compare_First_Date2
        {
            get { return _Compare_First_Date2; }
            set { _Compare_First_Date2 = value; }
        }


        /// <summary> 
        /// Gets or sets the Compare_Second_Date2 value.
        /// </summary> 
        public DateTime Compare_Second_Date2
        {
            get { return _Compare_Second_Date2; }
            set { _Compare_Second_Date2 = value; }
        }


        /// <summary> 
        /// Gets or sets the As_Of_Date3 value.
        /// </summary> 
        public DateTime As_Of_Date3
        {
            get { return _As_Of_Date3; }
            set { _As_Of_Date3 = value; }
        }


        /// <summary> 
        /// Gets or sets the Compare_First_Date3 value.
        /// </summary> 
        public DateTime Compare_First_Date3
        {
            get { return _Compare_First_Date3; }
            set { _Compare_First_Date3 = value; }
        }


        /// <summary> 
        /// Gets or sets the Compare_Second_Date3 value.
        /// </summary> 
        public DateTime Compare_Second_Date3
        {
            get { return _Compare_Second_Date3; }
            set { _Compare_Second_Date3 = value; }
        }

        #endregion


        #region Constructors

        /// <summary> 
        /// Initializes a new instance of the Tatva_RptThreePITSchedule class. with the default value.
        /// </summary>
        public Tatva_RptThreePITSchedule()
        {
            this._PK_ID = -1;
            this._FK_Schedule = -1;
            this._Claim_Type = "";
            this._As_Of_Date1 = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            this._Compare_First_Date1 = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            this._Compare_Second_Date1 = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            this._As_Of_Date2 = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            this._Compare_First_Date2 = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            this._Compare_Second_Date2 = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            this._As_Of_Date3 = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            this._Compare_First_Date3 = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            this._Compare_Second_Date3 = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
        }


        /// <summary> 
        /// Initializes a new instance of the Tatva_RptThreePITSchedule class for passed PrimaryKey with the values set from Database.
        /// </summary>
        public Tatva_RptThreePITSchedule(decimal PK)
        {
            DataTable dtTatva_RptThreePITSchedule = SelectByPK(PK).Tables[0];
            if (dtTatva_RptThreePITSchedule.Rows.Count > 0)
            {
                DataRow drTatva_RptThreePITSchedule = dtTatva_RptThreePITSchedule.Rows[0];
                this._PK_ID = drTatva_RptThreePITSchedule["PK_ID"] != DBNull.Value ? Convert.ToDecimal(drTatva_RptThreePITSchedule["PK_ID"]) : 0;
                this._FK_Schedule = drTatva_RptThreePITSchedule["FK_Schedule"] != DBNull.Value ? Convert.ToDecimal(drTatva_RptThreePITSchedule["FK_Schedule"]) : 0;
                this._Claim_Type = Convert.ToString(drTatva_RptThreePITSchedule["Claim_Type"]);
                this._As_Of_Date1 = drTatva_RptThreePITSchedule["As_Of_Date1"] != DBNull.Value ? Convert.ToDateTime(drTatva_RptThreePITSchedule["As_Of_Date1"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Compare_First_Date1 = drTatva_RptThreePITSchedule["Compare_First_Date1"] != DBNull.Value ? Convert.ToDateTime(drTatva_RptThreePITSchedule["Compare_First_Date1"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Compare_Second_Date1 = drTatva_RptThreePITSchedule["Compare_Second_Date1"] != DBNull.Value ? Convert.ToDateTime(drTatva_RptThreePITSchedule["Compare_Second_Date1"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._As_Of_Date2 = drTatva_RptThreePITSchedule["As_Of_Date2"] != DBNull.Value ? Convert.ToDateTime(drTatva_RptThreePITSchedule["As_Of_Date2"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Compare_First_Date2 = drTatva_RptThreePITSchedule["Compare_First_Date2"] != DBNull.Value ? Convert.ToDateTime(drTatva_RptThreePITSchedule["Compare_First_Date2"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Compare_Second_Date2 = drTatva_RptThreePITSchedule["Compare_Second_Date2"] != DBNull.Value ? Convert.ToDateTime(drTatva_RptThreePITSchedule["Compare_Second_Date2"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._As_Of_Date3 = drTatva_RptThreePITSchedule["As_Of_Date3"] != DBNull.Value ? Convert.ToDateTime(drTatva_RptThreePITSchedule["As_Of_Date3"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Compare_First_Date3 = drTatva_RptThreePITSchedule["Compare_First_Date3"] != DBNull.Value ? Convert.ToDateTime(drTatva_RptThreePITSchedule["Compare_First_Date3"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Compare_Second_Date3 = drTatva_RptThreePITSchedule["Compare_Second_Date3"] != DBNull.Value ? Convert.ToDateTime(drTatva_RptThreePITSchedule["Compare_Second_Date3"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            }
            else
            {
                this._PK_ID = -1;
                this._FK_Schedule = -1;
                this._Claim_Type = "";
                this._As_Of_Date1 = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Compare_First_Date1 = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Compare_Second_Date1 = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._As_Of_Date2 = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Compare_First_Date2 = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Compare_Second_Date2 = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._As_Of_Date3 = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Compare_First_Date3 = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Compare_Second_Date3 = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            }
        }


        #endregion


        #region Methods
        /// <summary>
        /// Inserts a record into the Tatva_RptThreePITSchedule table.
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            this.FK_Schedule = base.Insert();
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Tatva_RptThreePITScheduleInsert");

            db.AddInParameter(dbCommand, "FK_Schedule", DbType.Decimal, this.FK_Schedule);
            db.AddInParameter(dbCommand, "Claim_Type", DbType.String, this._Claim_Type);
            db.AddInParameter(dbCommand, "As_Of_Date1", DbType.DateTime, this._As_Of_Date1);
            db.AddInParameter(dbCommand, "Compare_First_Date1", DbType.DateTime, this._Compare_First_Date1);
            db.AddInParameter(dbCommand, "Compare_Second_Date1", DbType.DateTime, this._Compare_Second_Date1);
            db.AddInParameter(dbCommand, "As_Of_Date2", DbType.DateTime, this._As_Of_Date2);
            db.AddInParameter(dbCommand, "Compare_First_Date2", DbType.DateTime, this._Compare_First_Date2);
            db.AddInParameter(dbCommand, "Compare_Second_Date2", DbType.DateTime, this._Compare_Second_Date2);
            db.AddInParameter(dbCommand, "As_Of_Date3", DbType.DateTime, this._As_Of_Date3);
            db.AddInParameter(dbCommand, "Compare_First_Date3", DbType.DateTime, this._Compare_First_Date3);
            db.AddInParameter(dbCommand, "Compare_Second_Date3", DbType.DateTime, this._Compare_Second_Date3);

            // Execute the query and return the new identity value
            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
        }

        /// <summary>
        /// Selects a single record from the Tatva_RptThreePITSchedule table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectByPK(decimal pK_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Tatva_RptThreePITScheduleSelectByPK");

            db.AddInParameter(dbCommand, "PK_ID", DbType.Decimal, pK_ID);

            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet SelectByFK_Schedule(decimal fK_Schedule)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Tatva_RptThreePITScheduleSelectByFK_Schedule");

            db.AddInParameter(dbCommand, "FK_Schedule", DbType.Decimal, fK_Schedule);

            return db.ExecuteDataSet(dbCommand);
        }
        #endregion

    }
}