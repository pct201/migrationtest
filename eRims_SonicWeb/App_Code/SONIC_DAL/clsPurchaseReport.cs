using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

/// <summary>
/// Summary description for clsPurchaseReport
/// </summary>
public class clsPurchaseReport
{
    public clsPurchaseReport()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public static DataSet GetService_Contract_Detail_Report(string strRegion, string strMarket, string strLocation, string strServiceContract, string strServiceType, Nullable<DateTime> dtStartToDate, Nullable<DateTime> dtStartFromDate, Nullable<DateTime> dtEndToDate, Nullable<DateTime> dtEndFromDate)
    {
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetStoredProcCommand("Purchase_Service_Contract_Detail_Report");
        db.AddInParameter(dbCommand, "Region", DbType.String, strRegion);
        db.AddInParameter(dbCommand, "Market", DbType.String, strMarket);
        db.AddInParameter(dbCommand, "Location", DbType.String, strLocation);
        db.AddInParameter(dbCommand, "ServiceContract", DbType.String, strServiceContract);
        db.AddInParameter(dbCommand, "ServiceType", DbType.String, strServiceType);
        db.AddInParameter(dbCommand, "StartToDate", DbType.DateTime, dtStartToDate);
        db.AddInParameter(dbCommand, "StartFromDate", DbType.DateTime, dtStartFromDate);
        db.AddInParameter(dbCommand, "EndToDate", DbType.DateTime, dtEndToDate);
        db.AddInParameter(dbCommand, "EndFromDate", DbType.DateTime, dtEndFromDate);
        db.AddInParameter(dbCommand, "PK_Security_ID", DbType.Decimal, clsSession.UserID);
        return db.ExecuteDataSet(dbCommand);
    }

    public static DataSet GetLease_Rental_Detail_Report(string strRegion, string strMarket, string strLocation, string strEquipmentType, string strLeaseRentalType, Nullable<DateTime> dtStartToDate, Nullable<DateTime> dtStartFromDate, Nullable<DateTime> dtEndToDate, Nullable<DateTime> dtEndFromDate)
    {
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetStoredProcCommand("Purchase_Rental_Lease_Detail_Report");
        db.AddInParameter(dbCommand, "Region", DbType.String, strRegion);
        db.AddInParameter(dbCommand, "Market", DbType.String, strMarket);
        db.AddInParameter(dbCommand, "Location", DbType.String, strLocation);
        db.AddInParameter(dbCommand, "EquipmentType", DbType.String, strEquipmentType);
        db.AddInParameter(dbCommand, "LeaseRentalType", DbType.String, strLeaseRentalType);
        db.AddInParameter(dbCommand, "StartToDate", DbType.DateTime, dtStartToDate);
        db.AddInParameter(dbCommand, "StartFromDate", DbType.DateTime, dtStartFromDate);
        db.AddInParameter(dbCommand, "EndToDate", DbType.DateTime, dtEndToDate);
        db.AddInParameter(dbCommand, "EndFromDate", DbType.DateTime, dtEndFromDate);
        db.AddInParameter(dbCommand, "PK_Security_ID", DbType.Decimal, clsSession.UserID);
        return db.ExecuteDataSet(dbCommand);
    }
}
