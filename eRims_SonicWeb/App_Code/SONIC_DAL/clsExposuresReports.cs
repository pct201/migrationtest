using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
/// <summary>
/// Summary description for clsExposuresReports
/// </summary>
public class clsExposuresReports
{
    public clsExposuresReports()
    {
        //
        // TODO: Add constructor logic here
        //
    }


    #region Report

    public static DataSet GetPropertyStatementofValues(string strRegion, string strMarket, string strStatus, string strBuildingStatus, string strOwnership, DateTime? dtPropertyValuationDateFrom, DateTime? dtPropertyValuationDateTo)
    {
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetStoredProcCommand("rptPropertyStatementofValues");

        if (!string.IsNullOrEmpty(strRegion))
            db.AddInParameter(dbCommand, "Region", DbType.String, strRegion);
        if (!string.IsNullOrEmpty(strMarket)) 
            db.AddInParameter(dbCommand, "Market", DbType.String, strMarket);
        if (!string.IsNullOrEmpty(strStatus)) 
            db.AddInParameter(dbCommand, "Status", DbType.String, strStatus);
        if (!string.IsNullOrEmpty(strBuildingStatus))
            db.AddInParameter(dbCommand, "BuildingStatus", DbType.String, strBuildingStatus);
        if (!string.IsNullOrEmpty(strOwnership))
            db.AddInParameter(dbCommand, "Ownership", DbType.String, strOwnership);
        db.AddInParameter(dbCommand, "PropertyValuationDateFrom", DbType.DateTime, dtPropertyValuationDateFrom);
        db.AddInParameter(dbCommand, "PropertyValuationDateTo", DbType.DateTime, dtPropertyValuationDateTo);

        return db.ExecuteDataSet(dbCommand);
    }
    public static DataSet GetPropertyStatementofValues_NEW(string strRegion, string strMarket, string strStatus, string strBuildingStatus, string strOwnership, DateTime? dtPropertyValuationDateFrom, DateTime? dtPropertyValuationDateTo)
    {
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetStoredProcCommand("rptPropertyStatementofValues_NEW");

        if (strRegion != string.Empty)
            db.AddInParameter(dbCommand, "Region", DbType.String, strRegion);
        if (strMarket != string.Empty)
            db.AddInParameter(dbCommand, "Market", DbType.String, strMarket);
        if (strStatus != string.Empty)
            db.AddInParameter(dbCommand, "Status", DbType.String, strStatus);
        if (strBuildingStatus != string.Empty)
            db.AddInParameter(dbCommand, "BuildingStatus", DbType.String, strBuildingStatus);
        if (strOwnership != string.Empty)
            db.AddInParameter(dbCommand, "Ownership", DbType.String, strOwnership);
        db.AddInParameter(dbCommand, "PropertyValuationDateFrom", DbType.DateTime, dtPropertyValuationDateFrom);
        db.AddInParameter(dbCommand, "PropertyValuationDateTo", DbType.DateTime, dtPropertyValuationDateTo);

        dbCommand.CommandTimeout = 10000;

        return db.ExecuteDataSet(dbCommand);
    }

    public static DataSet GetInspectionsByInspector(string strRegion, string strMarket, string strDBA, string strInspectionArea, string strInspectorName, DateTime? dtInspectionDateFrom, DateTime? dtInspectionDateTo)
    {
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetStoredProcCommand("rptInspectionsByInspector");

        db.AddInParameter(dbCommand, "Region", DbType.String, strRegion);
        db.AddInParameter(dbCommand, "Market", DbType.String, strMarket);
        db.AddInParameter(dbCommand, "Inspector_Name", DbType.String, strInspectorName);
        db.AddInParameter(dbCommand, "DBA", DbType.String, strDBA);
        db.AddInParameter(dbCommand, "InspectionArea", DbType.String, strInspectionArea);
        db.AddInParameter(dbCommand, "Inspection_From", DbType.DateTime, dtInspectionDateFrom);
        db.AddInParameter(dbCommand, "Inspection_To", DbType.DateTime, dtInspectionDateTo);

        return db.ExecuteDataSet(dbCommand);
    }

    public static DataSet GetInspectionLagTime(string strRegion, string strMarket, string strDBA, string strInspectionArea, string strInspectorName, DateTime? dtInspectionDateFrom, DateTime? dtInspectionDateTo, string strLagDayOption)
    {
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetStoredProcCommand("rptInspectionLagTime");

        db.AddInParameter(dbCommand, "Region", DbType.String, strRegion);
        db.AddInParameter(dbCommand, "Market", DbType.String, strMarket);
        db.AddInParameter(dbCommand, "Inspector_Name", DbType.String, strInspectorName);
        db.AddInParameter(dbCommand, "DBA", DbType.String, strDBA);
        db.AddInParameter(dbCommand, "InspectionArea", DbType.String, strInspectionArea);
        db.AddInParameter(dbCommand, "Inspection_From", DbType.DateTime, dtInspectionDateFrom);
        db.AddInParameter(dbCommand, "Inspection_To", DbType.DateTime, dtInspectionDateTo);
        db.AddInParameter(dbCommand, "LagDayOption", DbType.String, strLagDayOption);
        return db.ExecuteDataSet(dbCommand);
    }

    public static DataSet GetNewExposuresreport(string strRegion, string strStatus, string strMarket)
    {
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetStoredProcCommand("rptNEWExposuresreport");
        if (strRegion != string.Empty)
            db.AddInParameter(dbCommand, "Region", DbType.String, strRegion);
        if (strMarket != string.Empty)
            db.AddInParameter(dbCommand, "Market", DbType.String, strMarket);
        if (strStatus != string.Empty)
            db.AddInParameter(dbCommand, "Status", DbType.String, strStatus);

        db.AddInParameter(dbCommand, "Pk_Security_ID", DbType.Decimal, Convert.ToDecimal(clsSession.UserID));

        return db.ExecuteDataSet(dbCommand);
    }
    public static DataSet GetFacilityInspectionReport(string strRegion,string strMarket, int intYear, string strInterval)
    {
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetStoredProcCommand("rptFacilityInspection");
        db.AddInParameter(dbCommand, "Region", DbType.String, strRegion);
        db.AddInParameter(dbCommand, "Market", DbType.String, strMarket);
        db.AddInParameter(dbCommand, "Year", DbType.Int32, intYear);
        db.AddInParameter(dbCommand, "strInterval", DbType.String, strInterval);
        db.AddInParameter(dbCommand, "Pk_Security_ID", DbType.Decimal, Convert.ToDecimal(clsSession.UserID));

        return db.ExecuteDataSet(dbCommand);
    }

    public static DataSet GetSafetyTrainingReport(string strRegion, string strMarket, int intYear, string strInterval)
    {
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetStoredProcCommand("DealershipDashBoardReport_New");
        db.AddInParameter(dbCommand, "Region", DbType.String, strRegion);
        db.AddInParameter(dbCommand, "Market", DbType.String, strMarket);
        db.AddInParameter(dbCommand, "Year", DbType.Int32, intYear);
        db.AddInParameter(dbCommand, "strInterval", DbType.String, strInterval);
        db.AddInParameter(dbCommand, "Pk_Security_ID", DbType.Decimal, Convert.ToDecimal(clsSession.UserID));

        dbCommand.CommandTimeout = 10000;
        return db.ExecuteDataSet(dbCommand);
    }

    public static DataSet GetRegionList()
    {
        decimal PK_security_ID = 0;
        if (!string.IsNullOrEmpty(clsSession.UserID))
            PK_security_ID = Convert.ToDecimal(clsSession.UserID);
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetSqlStringCommand("SELECT DISTINCT [Region] FROM [LU_Location] WHERE [Show_On_Dashboard] = 'Y' AND " +
            "PK_LU_Location_ID in (SELECT PK_LU_Location_ID FROM [dbo].[GetDashboardLocations](" + PK_security_ID + "))");

        return db.ExecuteDataSet(dbCommand);
    }
    public static DataSet GetrptRM_Dealership_Facility_Specs(string strRegion, string strStatus, string strOwnership, string strBrand, string strMarket)
    {
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetStoredProcCommand("rptRM_Dealership_Facility_Specs");

        if (strRegion != string.Empty)
            db.AddInParameter(dbCommand, "Region", DbType.String, strRegion);
        if (strMarket != string.Empty)
            db.AddInParameter(dbCommand, "Market", DbType.String, strMarket);
        if (strStatus != string.Empty)
            db.AddInParameter(dbCommand, "Status", DbType.String, strStatus);
        if (strOwnership != string.Empty)
            db.AddInParameter(dbCommand, "Ownership", DbType.String, strOwnership);
        if (strBrand != string.Empty)
            db.AddInParameter(dbCommand, "Brand", DbType.String, strBrand);
        db.AddInParameter(dbCommand, "Pk_Security_ID", DbType.Decimal, Convert.ToDecimal(clsSession.UserID));
        return db.ExecuteDataSet(dbCommand);
    }

    public static DataSet Getrpt_d_b_a_Main_Report(string strRegion, string strMarket, string strState, string strRLCM, string strLocationCode, string strActive, string strShowOnDashboard)
    {
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetStoredProcCommand("rpt_d_b_a_Main_Report");

        if (strRegion != string.Empty)
            db.AddInParameter(dbCommand, "Region", DbType.String, strRegion);
        if (strMarket != string.Empty)
            db.AddInParameter(dbCommand, "Market", DbType.String, strMarket);
        if (strState != string.Empty)
            db.AddInParameter(dbCommand, "State", DbType.String, strState);
        if (strRLCM != string.Empty)
            db.AddInParameter(dbCommand, "RLCM", DbType.String, strRLCM);
        if (strLocationCode != string.Empty)
            db.AddInParameter(dbCommand, "LocationCode", DbType.String, strLocationCode);
        if (strActive != string.Empty)
            db.AddInParameter(dbCommand, "Active", DbType.String, strActive);
        if (strShowOnDashboard != string.Empty)
            db.AddInParameter(dbCommand, "ShowOnDashboard", DbType.String, strShowOnDashboard);
        return db.ExecuteDataSet(dbCommand);
    }   


    public static DataSet GetSafetyTrainingReportByRegionLocation(int intYear, string strRegion)
    {
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetStoredProcCommand("DealershipDetailsbyRegionLocation_New");
        db.AddInParameter(dbCommand, "Year", DbType.Int32, intYear);
        db.AddInParameter(dbCommand, "Region", DbType.String, strRegion);
        
        //db.AddInParameter(dbCommand, "Pk_Security_ID", DbType.Decimal, Convert.ToDecimal(clsSession.UserID));
        dbCommand.CommandTimeout = 10000;
        return db.ExecuteDataSet(dbCommand);
    }

    public static DataSet GetACI_Key_Contact_Report(string strDBA, string strJob_Titles)
    {
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetStoredProcCommand("rptACI_Key_Contact_Report");
        db.AddInParameter(dbCommand, "DBA", DbType.String, strDBA);
        db.AddInParameter(dbCommand, "Job_Titles", DbType.String, strJob_Titles);
        
        return db.ExecuteDataSet(dbCommand);
    }

    #endregion
}
