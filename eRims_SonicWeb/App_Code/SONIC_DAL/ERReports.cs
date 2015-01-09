using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
    /// <summary>
    /// Summary description for ERReports
    /// </summary>
    public class ERReports
    {
        public ERReports()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public static DataSet Get_Bordereau_Report(DateTime dtStartDate,DateTime dtEndDate,string strRegion)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("ER_Bordereau_Report");

            db.AddInParameter(dbCommand, "StartDate", DbType.DateTime, dtStartDate);
            db.AddInParameter(dbCommand, "EndDate", DbType.DateTime, dtEndDate);
            db.AddInParameter(dbCommand, "Region", DbType.String, strRegion);

            return db.ExecuteDataSet(dbCommand);     
        }

        public static DataSet Get_Notification_Bordereau_Report(DateTime dtStartDate, DateTime dtEndDate, string strRegion, string strMarket)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("ER_Claim_Notification_Bordereau_Report");

            db.AddInParameter(dbCommand, "StartDate", DbType.DateTime, dtStartDate);
            db.AddInParameter(dbCommand, "EndDate", DbType.DateTime, dtEndDate);
            db.AddInParameter(dbCommand, "Region", DbType.String, strRegion);
            db.AddInParameter(dbCommand, "Market", DbType.String, strMarket);

            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet Get_Litigation_Summary_Report(DateTime dtStartDate, DateTime dtEndDate, string strRegion, string strMarket)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("ER_Litigation_Summary_Report");

            db.AddInParameter(dbCommand, "StartDate", DbType.DateTime, dtStartDate);
            db.AddInParameter(dbCommand, "EndDate", DbType.DateTime, dtEndDate);
            db.AddInParameter(dbCommand, "Region", DbType.String, strRegion);
            db.AddInParameter(dbCommand, "Market", DbType.String, strMarket);

            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet Get_Reportable_Claims_Report()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("ER_Reportable_Claims_Report");
            return db.ExecuteDataSet(dbCommand);
        }
        public static DataSet Get_Network_Call_Summary_Report(DateTime dtStartDate, DateTime dtEndDate, string strRegion, string strMarket)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("ER_Network_Call_Summary_Report");

            db.AddInParameter(dbCommand, "StartDate", DbType.DateTime, dtStartDate);
            db.AddInParameter(dbCommand, "EndDate", DbType.DateTime, dtEndDate);
            db.AddInParameter(dbCommand, "Region", DbType.String, strRegion);
            db.AddInParameter(dbCommand, "Market", DbType.String, strMarket);

            return db.ExecuteDataSet(dbCommand);
        }

    }
}