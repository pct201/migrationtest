using System;
using System.Data;
using System.Configuration;
using System.Web.Security;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Common;
using System.Data.Common;

/// <summary>
/// Summary description for Charts
/// </summary>
public class Charts
{
    public Charts()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public static DataSet GetRegionListByUser(decimal pk_Security_ID)
    {
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetSqlStringCommand("select * from [dbo].GetRegionsForDashboard(" + pk_Security_ID.ToString() + ")");

        return db.ExecuteDataSet(dbCommand);
    }

    public static DataSet GetFacilityInspectionByRegion(int Year)
    {
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetStoredProcCommand("Chart_FacilityInspectionByRegion");
        dbCommand.CommandTimeout = 1000;

        db.AddInParameter(dbCommand, "Year", DbType.Int32, Year);
        db.AddInParameter(dbCommand, "PK_Security_ID", DbType.Decimal, clsSession.UserID);

        return db.ExecuteDataSet(dbCommand);
    }

    public static DataSet GetFacilityInspectionByLocation(int Year, string strRegion)
    {
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetStoredProcCommand("Chart_FacilityInspectionByLocation");
        dbCommand.CommandTimeout = 1000;

        db.AddInParameter(dbCommand, "Year", DbType.Int32, Year);
        db.AddInParameter(dbCommand, "Region", DbType.String, strRegion);
        db.AddInParameter(dbCommand, "PK_Security_ID", DbType.Decimal, clsSession.UserID);
        return db.ExecuteDataSet(dbCommand);
    }

    public static DataSet GetFacilityInspectionDetail(int Year, string DBA, string Sonic_Location_Code)
    {
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetStoredProcCommand("Chart_FacilityInspectionDetail");
        dbCommand.CommandTimeout = 1000;

        db.AddInParameter(dbCommand, "Year", DbType.Int32, Year);
        db.AddInParameter(dbCommand, "DBA", DbType.String, DBA);
        db.AddInParameter(dbCommand, "Sonic_Location_Code", DbType.String, Sonic_Location_Code);

        return db.ExecuteDataSet(dbCommand);
    }

    public static DataSet GetIncidentInvestigationByRegion(int Year)
    {
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetStoredProcCommand("Chart_IncidentInvestigationByRegion");

        db.AddInParameter(dbCommand, "Year", DbType.Int32, Year);
        db.AddInParameter(dbCommand, "PK_Security_ID", DbType.Decimal, clsSession.UserID);
        return db.ExecuteDataSet(dbCommand);
    }

    public static DataSet GetIncidentInvestigationByLocation(int Year, string strRegion)
    {
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetStoredProcCommand("Chart_IncidentInvestigationByLocation");

        db.AddInParameter(dbCommand, "Year", DbType.Int32, Year);
        db.AddInParameter(dbCommand, "Region", DbType.String, strRegion);
        db.AddInParameter(dbCommand, "PK_Security_ID", DbType.Decimal, clsSession.UserID);
        return db.ExecuteDataSet(dbCommand);
    }

    public static DataSet GetIncidentInvestigationDetail(int Year, string DBA, string Sonic_Location_Code)
    {
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetStoredProcCommand("Chart_IncidentInvestigationDetail");

        db.AddInParameter(dbCommand, "Year", DbType.Int32, Year);
        db.AddInParameter(dbCommand, "DBA", DbType.String, DBA);
        db.AddInParameter(dbCommand, "Sonic_Location_Code", DbType.String, Sonic_Location_Code);

        return db.ExecuteDataSet(dbCommand);
    }

    public static DataSet GetSabaTrainingByRegion(int Year)
    {
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetStoredProcCommand("Chart_SabaTrainingByRegion");

        db.AddInParameter(dbCommand, "Year", DbType.Int32, Year);
        db.AddInParameter(dbCommand, "UserID", DbType.Decimal, clsSession.UserID);

        return db.ExecuteDataSet(dbCommand);
    }

    public static DataSet GetSabaTrainingByLocation(int Year, string Region)
    {
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetStoredProcCommand("Chart_SabaTrainingByLocation");
        db.AddInParameter(dbCommand, "Year", DbType.Int32, Year);
        db.AddInParameter(dbCommand, "Region", DbType.String, Region);
        db.AddInParameter(dbCommand, "UserID", DbType.Decimal, clsSession.UserID);
        return db.ExecuteDataSet(dbCommand);
    }

    public static DataSet GetSabaTrainingDetail(int Year, string DBA, string Sonic_Location_Code)
    {
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetStoredProcCommand("Chart_SabaTrainingDetail");

        db.AddInParameter(dbCommand, "Year", DbType.Int32, Year);
        db.AddInParameter(dbCommand, "DBA", DbType.String, DBA);
        db.AddInParameter(dbCommand, "Sonic_Location_Code", DbType.String, Sonic_Location_Code);
        db.AddInParameter(dbCommand, "UserID", DbType.Decimal, clsSession.UserID);

        return db.ExecuteDataSet(dbCommand);
    }

    public static DataSet GetIncidentReductionByRegion(int Year)
    {
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetStoredProcCommand("Chart_IncidentReductionByRegion");

        db.AddInParameter(dbCommand, "Year", DbType.Int32, Year);
        db.AddInParameter(dbCommand, "UserID", DbType.Decimal, clsSession.UserID);
        return db.ExecuteDataSet(dbCommand);
    }

    public static DataSet GetIncidentReductionByLocation(int Year, string strRegion)
    {
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetStoredProcCommand("Chart_IncidentReductionByLocation");

        db.AddInParameter(dbCommand, "Year", DbType.Int32, Year);
        db.AddInParameter(dbCommand, "Region", DbType.String, strRegion);
        db.AddInParameter(dbCommand, "UserID", DbType.Decimal, clsSession.UserID);
        return db.ExecuteDataSet(dbCommand);
    }

    public static DataSet GetIncidentReductionDetail(int Year, string strDBA, string Sonic_Location_Code)
    {
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetStoredProcCommand("Chart_IncidentReductionDetail");

        db.AddInParameter(dbCommand, "Year", DbType.Int32, Year);
        db.AddInParameter(dbCommand, "DBA", DbType.String, strDBA);
        db.AddInParameter(dbCommand, "Sonic_Location_Code", DbType.String, Sonic_Location_Code);
        db.AddInParameter(dbCommand, "UserID", DbType.Decimal, clsSession.UserID);
        return db.ExecuteDataSet(dbCommand);
    }

    public static DataSet GetWCClaimMgmtByRegion(int Year)
    {
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetStoredProcCommand("Chart_WCCLaimMgmtByRegion");

        db.AddInParameter(dbCommand, "Year", DbType.Int32, Year);
        db.AddInParameter(dbCommand, "PK_Security_ID", DbType.Decimal, clsSession.UserID);
        return db.ExecuteDataSet(dbCommand);
    }

    public static DataSet GetWCClaimMgmtByLocation(int Year, string strRegion)
    {
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetStoredProcCommand("Chart_WCCLaimMgmtByLocation");

        db.AddInParameter(dbCommand, "Year", DbType.Int32, Year);
        db.AddInParameter(dbCommand, "Region", DbType.String, strRegion);
        db.AddInParameter(dbCommand, "PK_Security_ID", DbType.Decimal, clsSession.UserID);

        return db.ExecuteDataSet(dbCommand);
    }

    /// <summary>
    /// Gets Chart Details For region for slt module
    /// </summary>
    /// <param name="Year"></param>
    /// <returns></returns>
    public static DataSet GETSLTBYRegion(int Year)
    {
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetStoredProcCommand("Chart_SLTByRegion");

        db.AddInParameter(dbCommand, "Year", DbType.Int32, Year);
        db.AddInParameter(dbCommand, "PK_Security_ID", DbType.Decimal, clsSession.UserID);
        return db.ExecuteDataSet(dbCommand);
    }
    /// <summary>
    /// Gets Chart Details For Location for slt module
    /// </summary>
    /// <param name="Year"></param>
    /// <returns></returns>
    public static DataSet GETSLTBYLocation(int Year, string strRegion)
    {
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetStoredProcCommand("Chart_SLTByLocation");

        db.AddInParameter(dbCommand, "Year", DbType.Int32, Year);
        db.AddInParameter(dbCommand, "Region", DbType.String, strRegion);
        db.AddInParameter(dbCommand, "PK_Security_ID", DbType.Decimal, clsSession.UserID);

        return db.ExecuteDataSet(dbCommand);
    }
    /// <summary>
    /// Gets Chart Details by Year,DBA and Sonic_Location_Code for slt module
    /// </summary>
    /// <param name="Year"></param>
    /// <returns></returns>
    public static DataSet GetSLTDetail(int Year, string strDBA, string Sonic_Location_Code)
    {
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetStoredProcCommand("Chart_SLTDetail");

        db.AddInParameter(dbCommand, "Year", DbType.Int32, Year);
        db.AddInParameter(dbCommand, "DBA", DbType.String, strDBA);
        db.AddInParameter(dbCommand, "Sonic_Location_Code", DbType.String, Sonic_Location_Code);
        return db.ExecuteDataSet(dbCommand);
    }

    /// <summary>
    /// funtion used to generate
    /// RLCMQuarterlyPerformanceReport
    /// </summary>
    /// <param name="pk_Security_ID">user id</param>
    /// <param name="Regions">list of regions comma seperated</param>
    /// <param name="idState">state id</param>
    /// <param name="FromDate">current year from date</param>
    /// <param name="ToDate">current year to date</param>
    /// <param name="PreviousFromDate">previous year from date</param>
    /// <param name="PreviousToDate">previous year to date</param>
    /// <returns></returns>
    public static DataSet RLCMQuarterlyPerformanceReport(decimal pk_Security_ID, string Regions, string Markets, int idState, DateTime FromDate, DateTime ToDate, DateTime PreviousFromDate, DateTime PreviousToDate, string Rlcms)
    {
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetStoredProcCommand("RLCM_Quarterly_Performance");

        dbCommand.CommandTimeout = 1000;
        db.AddInParameter(dbCommand, "PK_Security_ID", DbType.Decimal, pk_Security_ID);
        db.AddInParameter(dbCommand, "Regions", DbType.String, Regions);
        db.AddInParameter(dbCommand, "Markets", DbType.String, Markets);
        db.AddInParameter(dbCommand, "idState", DbType.Int32, idState);
        db.AddInParameter(dbCommand, "FromDate", DbType.DateTime, FromDate);
        db.AddInParameter(dbCommand, "ToDate", DbType.DateTime, ToDate);
        db.AddInParameter(dbCommand, "PreviousFromDate", DbType.DateTime, PreviousFromDate);
        db.AddInParameter(dbCommand, "PreviousToDate", DbType.DateTime, PreviousToDate);
        db.AddInParameter(dbCommand, "Rlcms", DbType.String, Rlcms);

        return db.ExecuteDataSet(dbCommand);

    }

    public static DataSet RLCMQuarterlyPerformanceReportGrid(decimal pk_Security_ID, string Regions, string Markets, int idState, DateTime FromDate, DateTime ToDate, string Rlcms)
    {
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetStoredProcCommand("rptQuarterlyPerformanceSLT");

        dbCommand.CommandTimeout = 1000;
        db.AddInParameter(dbCommand, "PK_Security_ID", DbType.Decimal, pk_Security_ID);
        db.AddInParameter(dbCommand, "idState", DbType.Int32, idState);
        db.AddInParameter(dbCommand, "Regions", DbType.String, Regions);
        db.AddInParameter(dbCommand, "Markets", DbType.String, Markets);
        db.AddInParameter(dbCommand, "From_Date", DbType.DateTime, FromDate);
        db.AddInParameter(dbCommand, "To_Date", DbType.DateTime, ToDate);
        db.AddInParameter(dbCommand, "Rlcms", DbType.String, Rlcms);
        //db.AddInParameter(dbCommand, "PreviousFromDate", DbType.DateTime, PreviousFromDate);
        //db.AddInParameter(dbCommand, "PreviousToDate", DbType.DateTime, PreviousToDate);

        return db.ExecuteDataSet(dbCommand);
    }


    public static DataSet RLCMFacilityInspections(decimal pk_Security_ID, string Regions, string Markets, int idState, DateTime FromDate, DateTime ToDate, DateTime PreviousFromDate, DateTime PreviousToDate, string Rlcms)
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("rptQuarterlyPerformanceFacilityInspections");

            dbCommand.CommandTimeout = 1000;
            db.AddInParameter(dbCommand, "PK_Security_ID", DbType.Decimal, pk_Security_ID);
            db.AddInParameter(dbCommand, "Regions", DbType.String, Regions);
            db.AddInParameter(dbCommand, "Markets", DbType.String, Markets);
            db.AddInParameter(dbCommand, "idState", DbType.Int32, idState);
            db.AddInParameter(dbCommand, "FromDate", DbType.DateTime, FromDate);
            db.AddInParameter(dbCommand, "ToDate", DbType.DateTime, ToDate);
            db.AddInParameter(dbCommand, "PreviousFromDate", DbType.DateTime, PreviousFromDate);
            db.AddInParameter(dbCommand, "PreviousToDate", DbType.DateTime, PreviousToDate);
            db.AddInParameter(dbCommand, "Rlcms", DbType.String, Rlcms);

            return db.ExecuteDataSet(dbCommand);
        }
        catch (Exception ex)
        {
            throw;
        }
        return null;
    }

    public static DataSet RLCMSonicUniversityTraining(decimal pk_Security_ID, string Regions, string Markets, int idState, DateTime FromDate, DateTime ToDate, DateTime PreviousFromDate, DateTime PreviousToDate, string Rlcms)
    {
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetStoredProcCommand("rptQuarterlyPerformanceSabaTraining");

        dbCommand.CommandTimeout = 1000;
        db.AddInParameter(dbCommand, "PK_Security_ID", DbType.Decimal, pk_Security_ID);
        db.AddInParameter(dbCommand, "idState", DbType.Int32, idState);
        db.AddInParameter(dbCommand, "Regions", DbType.String, Regions);
        db.AddInParameter(dbCommand, "Markets", DbType.String, Markets);
        db.AddInParameter(dbCommand, "PrevYearFrom_Date", DbType.DateTime, PreviousFromDate);
        db.AddInParameter(dbCommand, "PrevYearTo_Date", DbType.DateTime, PreviousToDate);
        db.AddInParameter(dbCommand, "CurrYearFrom_Date", DbType.DateTime, FromDate);
        db.AddInParameter(dbCommand, "CurrYearTo_Date", DbType.DateTime, ToDate);
        db.AddInParameter(dbCommand, "Rlcms", DbType.String, Rlcms);
        return db.ExecuteDataSet(dbCommand);
    }

    public static DataSet RLCMWcClaimManagement(decimal pk_Security_ID, string Regions, string Markets, int idState, DateTime FromDate, DateTime ToDate, DateTime PreviousFromDate, DateTime PreviousToDate, string Rlcms)
    {
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetStoredProcCommand("rptQuarterlyPerformWCIncident");

        dbCommand.CommandTimeout = 1000;
        db.AddInParameter(dbCommand, "PK_Security_ID", DbType.Decimal, pk_Security_ID);
        db.AddInParameter(dbCommand, "idState", DbType.Int32, idState);
        db.AddInParameter(dbCommand, "Regions", DbType.String, Regions);
        db.AddInParameter(dbCommand, "Markets", DbType.String, Markets);
        db.AddInParameter(dbCommand, "PrevYearFrom_Date", DbType.DateTime, PreviousFromDate);
        db.AddInParameter(dbCommand, "PrevYearTo_Date", DbType.DateTime, PreviousToDate);
        db.AddInParameter(dbCommand, "CurrYearFrom_Date", DbType.DateTime, FromDate);
        db.AddInParameter(dbCommand, "CurrYearTo_Date", DbType.DateTime, ToDate);
        db.AddInParameter(dbCommand, "Rlcms", DbType.String, Rlcms);

        return db.ExecuteDataSet(dbCommand);
    }

    public static DataSet RLCMIncidentInvestigation(decimal pk_Security_ID, string Regions, string Markets, int idState, DateTime FromDate, DateTime ToDate, DateTime PreviousFromDate, DateTime PreviousToDate, string Rlcms)
    {
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetStoredProcCommand("rptQuarterlyPerformInvestigation");

        dbCommand.CommandTimeout = 1000;
        db.AddInParameter(dbCommand, "PK_Security_ID", DbType.Decimal, pk_Security_ID);
        db.AddInParameter(dbCommand, "idState", DbType.Int32, idState);
        db.AddInParameter(dbCommand, "Regions", DbType.String, Regions);
        db.AddInParameter(dbCommand, "Markets", DbType.String, Markets);
        db.AddInParameter(dbCommand, "PrevYearFrom_Date", DbType.DateTime, PreviousFromDate);
        db.AddInParameter(dbCommand, "PrevYearTo_Date", DbType.DateTime, PreviousToDate);
        db.AddInParameter(dbCommand, "CurrYearFrom_Date", DbType.DateTime, FromDate);
        db.AddInParameter(dbCommand, "CurrYearTo_Date", DbType.DateTime, ToDate);
        db.AddInParameter(dbCommand, "Rlcms", DbType.String, Rlcms);

        return db.ExecuteDataSet(dbCommand);
    }
}
