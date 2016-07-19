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
    //change as per #Issue 3600 comment 35279
    public static string Platinum = "90EE90";//Light Green
    public static string Gold = "ADD8E6";//Light Blue
    public static string Silver = "FFFF00";//Yellow
    public static string Bronze = "FFA500";//Orange
    public static string Tin = "FF0000";//Red
    public static string White = "FFFFFF";
    public static string Platinum_Label = "Platinum";
    public static string Gold_Label = "Gold";
    public static string Silver_Label = "Silver";
    public static string Bronze_Label = "Bronze";
    public static string Tin_Label = "Tin";
    
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
		////change Reverted for sonic u training. ticket #3503/////
        DbCommand dbCommand = db.GetStoredProcCommand("Chart_SabaTrainingByRegion_New");
         
        db.AddInParameter(dbCommand, "Year", DbType.Int32, Year);
        db.AddInParameter(dbCommand, "UserID", DbType.Decimal, clsSession.UserID);

        dbCommand.CommandTimeout = 10000;
        return db.ExecuteDataSet(dbCommand);
    }

    public static DataSet GetSabaTrainingByLocation(int Year, string Region)
    {
        Database db = DatabaseFactory.CreateDatabase();
		////change Reverted for sonic u training. ticket #3503/////
        DbCommand dbCommand = db.GetStoredProcCommand("Chart_SabaTrainingByLocation_New");
        db.AddInParameter(dbCommand, "Year", DbType.Int32, Year);
        db.AddInParameter(dbCommand, "Region", DbType.String, Region);
        db.AddInParameter(dbCommand, "UserID", DbType.Decimal, clsSession.UserID);
        dbCommand.CommandTimeout = 10000;
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


	////change Reverted for sonic u training. ticket #3503/////
    public static DataSet GetSabaTrainingDetail1(int Year, string DBA, string Sonic_Location_Code, int Quarter, string AssociateStatus)
    {
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetStoredProcCommand("DealerShipDetails");

        db.AddInParameter(dbCommand, "@DealerShipYear", DbType.Int32, Year);
        if (Quarter == 0)
            db.AddInParameter(dbCommand, "@DealerShipQuarter", DbType.Int32, null);
        else
            db.AddInParameter(dbCommand, "@DealerShipQuarter", DbType.Int32, Quarter);
        db.AddInParameter(dbCommand, "@AssociateStatus", DbType.String, AssociateStatus);
        db.AddInParameter(dbCommand, "DBA", DbType.String, DBA);
        db.AddInParameter(dbCommand, "Sonic_Location_Code", DbType.String, Sonic_Location_Code);
        db.AddInParameter(dbCommand, "UserID", DbType.Decimal, clsSession.UserID);

        return db.ExecuteDataSet(dbCommand);
    }

    public static DataSet GetSabaTrainingDetail2(int Year, string DBA, string Sonic_Location_Code, int Quarter, string AssociateStatus,bool validate_Quarter)
    {
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetStoredProcCommand("DealerShipDetailsLatest_New");

        db.AddInParameter(dbCommand, "@DealerShipYear", DbType.Int32, Year);
        if (Quarter == 0)
            db.AddInParameter(dbCommand, "@DealerShipQuarter", DbType.Int32, null);
        else
            db.AddInParameter(dbCommand, "@DealerShipQuarter", DbType.Int32, Quarter);
        db.AddInParameter(dbCommand, "@AssociateStatus", DbType.String, AssociateStatus);
        db.AddInParameter(dbCommand, "DBA", DbType.String, DBA);
        db.AddInParameter(dbCommand, "Sonic_Location_Code", DbType.String, Sonic_Location_Code);
        db.AddInParameter(dbCommand, "Validate_Quarter", DbType.Boolean, validate_Quarter);

        dbCommand.CommandTimeout = 10000;
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
    public static DataSet RLCMQuarterlyPerformanceReport(decimal pk_Security_ID, string Regions, string Markets, int idState, DateTime FromDate, DateTime ToDate, DateTime PreviousFromDate, DateTime PreviousToDate, string Rlcms, string Sort)
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
        db.AddInParameter(dbCommand, "Sort", DbType.String, Sort);

        return db.ExecuteDataSet(dbCommand);

    }

    public static DataSet RLCMQuarterlyPerformanceReportGrid(decimal pk_Security_ID, string Regions, string Markets, int idState, DateTime FromDate, DateTime ToDate, string Rlcms)
    {
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetStoredProcCommand("rptQuarterlyPerformanceSLT_New");

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

    public static DataSet RLCMQuarterlyPerformanceReportGrid_ByRLCM(decimal pk_Security_ID, string Regions, string Markets, int idState, DateTime FromDate, DateTime ToDate, string Rlcms)
    {
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetStoredProcCommand("rptQuarterlyPerformanceSLT_ByRLCM_New");

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

    public static DataSet RLCMFacilityInspections_ByRLCM(decimal pk_Security_ID, string Regions, string Markets, int idState, DateTime FromDate, DateTime ToDate, DateTime PreviousFromDate, DateTime PreviousToDate, string Rlcms)
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("rptQuarterlyPerformanceFacilityInspections_ByRLCM");

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
		////change Reverted for sonic u training. ticket #3503/////
        DbCommand dbCommand = db.GetStoredProcCommand("rptQuarterlyPerformanceSabaTraining_New");

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

        dbCommand.CommandTimeout = 10000;
        return db.ExecuteDataSet(dbCommand);
    }

    public static DataSet RLCMSonicUniversityTraining_ByRLCM(decimal pk_Security_ID, string Regions, string Markets, int idState, DateTime FromDate, DateTime ToDate, DateTime PreviousFromDate, DateTime PreviousToDate, string Rlcms)
    {
        Database db = DatabaseFactory.CreateDatabase();
		////change Reverted for sonic u training. ticket #3503/////
        DbCommand dbCommand = db.GetStoredProcCommand("rptQuarterlyPerformanceSabaTraining_ByRLCM_New");

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

        dbCommand.CommandTimeout = 10000;
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

    public static DataSet RLCMWcClaimManagement_ByRLCM(decimal pk_Security_ID, string Regions, string Markets, int idState, DateTime FromDate, DateTime ToDate, DateTime PreviousFromDate, DateTime PreviousToDate, string Rlcms)
    {
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetStoredProcCommand("rptQuarterlyPerformWCIncident_ByRLCM");

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

    public static DataSet RLCMIncidentInvestigation_ByRLCM(decimal pk_Security_ID, string Regions, string Markets, int idState, DateTime FromDate, DateTime ToDate, DateTime PreviousFromDate, DateTime PreviousToDate, string Rlcms)
    {
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetStoredProcCommand("rptQuarterlyPerformInvestigation_ByRLCM");

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

    public static string GetColorCodeFromCategory(string catgory)
    {
        string color = string.Empty;
        switch (catgory.ToUpper())
        {
            case "PLATINUM":
                color = Platinum;
                break;
            case "GOLD":
                color = Gold;
                break;
            case "SILVER":
                color = Silver;
                break;
            case "BRONZE":
                color = Bronze;
                break;
            case "TIN":
                color = Tin;
                break;
        }
        return color;
    }

    public static string GetColorCodeFromScore(decimal _intScore)
    {
        string color = string.Empty;
        if (_intScore > 11 && _intScore <= 14)
        {
            color = Platinum;
        }
        else if (_intScore > 8 && _intScore <= 11)
        {
            color = Gold;
        }
        else if (_intScore > 5 && _intScore <= 8)
        {
            color = Silver;
        }
        else if (_intScore > 2 && _intScore <= 5)
        {
            color = Bronze;
        }
        else if (_intScore >= 0 && _intScore <= 2)
        {
            color = Tin;
        }
        //else if (_intScore >= 0 && _intScore < 4)
        //{
        //    color = White;
        //}
        return color;
    }

    public static string GetColorCodeFromScore_SLT(decimal _intScore)
    {
        string color = string.Empty;
        if (_intScore >= 30)
        {
            color = Platinum;
        }
        else if (_intScore > 23.5m && _intScore < 30)
        {
            color = Gold;
        }
        else if (_intScore > 17.5m && _intScore <= 23.5m)
        {
            color = Silver;
        }
        else if (_intScore > 11.5m && _intScore <= 17.5m)
        {
            color = Bronze;
        }
        else if (_intScore >= 0 && _intScore <= 11.5m)
        {
            color = Tin;
        }
        //else if (_intScore >= 0 && _intScore < 13)
        //{
        //    color = White;
        //}
        return color;
    }

    public static string GetColorCodeFromScoreAggregate(decimal _intScore)
    {
        string color = string.Empty;
        if (_intScore >= 95 && _intScore <= 100)
        {
            color = Platinum;
        }
        else if (_intScore >= 90 && _intScore < 95)
        {
            color = Gold;
        }
        else if (_intScore >= 80 && _intScore < 90)
        {
            color = Silver;
        }
        else if (_intScore >= 70 && _intScore < 80)
        {
            color = Bronze;
        }
        else if (_intScore >= 0 && _intScore < 70)
        {
            color = Tin;
        }
        
        return color;
    }
}
