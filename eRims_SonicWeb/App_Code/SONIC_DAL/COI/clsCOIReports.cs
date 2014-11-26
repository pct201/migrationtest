using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
namespace ERIMS.DAL
{

    /// <summary>
    /// Summary description for clsCOIReports
    /// </summary>
    public class clsCOIReports
    {
        public clsCOIReports()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public static DataSet NonCompliantByEntityReport(int intType)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("NonCompliantByEntityReport");
            db.AddInParameter(dbCommand, "Type", DbType.Int32, intType);
            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet NonCompliantSummaryReport(int intType)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("NonCompliantSummaryReport");
            db.AddInParameter(dbCommand, "Type", DbType.Int32, intType);
            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet EntityReport(int intType)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("EntityReport");
            db.AddInParameter(dbCommand, "Type", DbType.Int32, intType);
            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet LocationsByStateReport(int intType)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LocationsByStateReport");
            db.AddInParameter(dbCommand, "Type", DbType.Int32, intType);
            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet VerificationReport(int intType)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("VerificationReport");
            db.AddInParameter(dbCommand, "Type", DbType.Int32, intType);
            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet PoliciesExpiringIn90Days(int intType)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("PoliciesExpiringIn90Days");
            db.AddInParameter(dbCommand, "Type", DbType.Int32, intType);
            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet PoliciesExpirationDates(int intType)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("PoliciesExpirationDates");
            db.AddInParameter(dbCommand, "Type", DbType.Int32, intType);
            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet AUTOSCHETESTING()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("AUTOSCHETESTING");            
            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet PropertyScheduleTesting()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("PropertyScheduleTesting");
            return db.ExecuteDataSet(dbCommand);
        }
    }
}