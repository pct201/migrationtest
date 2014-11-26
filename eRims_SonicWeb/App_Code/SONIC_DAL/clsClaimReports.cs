using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace ERIMS.DAL
{
    /// <summary>
    /// Summary description for clsClaimReports
    /// </summary>
    public class clsClaimReports
    {
        public clsClaimReports()
        {

        }

        public static DataSet GetClaimReportYears()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("GetClaimReportYears");
            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet SelectRegions()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("SelectRegionsForClaimReports");
            db.AddInParameter(dbCommand, "PK_Security_ID", DbType.Int32, clsSession.UserID);
            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet GetFinancialSummaryData(string strYear, string strClaimType, string strRegion, DateTime valuation_date)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("rptFinancialSummary");
            db.AddInParameter(dbCommand, "year", DbType.String, strYear);
            db.AddInParameter(dbCommand, "claim_type", DbType.String, strClaimType);
            db.AddInParameter(dbCommand, "region", DbType.String, strRegion);
            db.AddInParameter(dbCommand, "valuation_date", DbType.DateTime, valuation_date);
            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet GetFinancialPayTypeSummaryData(string strYear, string strRegion, DateTime valuation_date)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("rptFinancialPayTypeSummary");
            db.AddInParameter(dbCommand, "year", DbType.String, strYear);
            db.AddInParameter(dbCommand, "region", DbType.String, strRegion);
            db.AddInParameter(dbCommand, "valuation_date", DbType.DateTime, valuation_date);
            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet GetEmployerLagSummaryData(DateTime dtFrom, DateTime dtTo, string strRegion)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("rptEmployerLagSummary");
            db.AddInParameter(dbCommand, "From_Date", DbType.DateTime, dtFrom);
            db.AddInParameter(dbCommand, "To_Date", DbType.DateTime, dtTo);
            db.AddInParameter(dbCommand, "Region", DbType.String, strRegion);
            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet GetInsurerLagSummaryData(DateTime dtFrom, DateTime dtTo, string strRegion)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("rptInsurerLagSummary");
            db.AddInParameter(dbCommand, "From_Date", DbType.DateTime, dtFrom);
            db.AddInParameter(dbCommand, "To_Date", DbType.DateTime, dtTo);
            db.AddInParameter(dbCommand, "Region", DbType.String, strRegion);
            return db.ExecuteDataSet(dbCommand);
        }
        public static DataSet GetCompletionLagSummaryData(DateTime dtFrom, DateTime dtTo, string strRegion)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("rptCompletionLagSummary");
            db.AddInParameter(dbCommand, "From_Date", DbType.DateTime, dtFrom);
            db.AddInParameter(dbCommand, "To_Date", DbType.DateTime, dtTo);
            db.AddInParameter(dbCommand, "Region", DbType.String, strRegion);
            return db.ExecuteDataSet(dbCommand);
        }
        public static DataSet GetTPALagSummaryData(DateTime dtFrom, DateTime dtTo, string strRegion)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("rptTPALagSummary");
            db.AddInParameter(dbCommand, "From_Date", DbType.DateTime, dtFrom);
            db.AddInParameter(dbCommand, "To_Date", DbType.DateTime, dtTo);
            db.AddInParameter(dbCommand, "Region", DbType.String, strRegion);
            return db.ExecuteDataSet(dbCommand);
        }
        public static DataSet GetFrequencyAnalysisData(DateTime dtFrom, DateTime dtTo, string strClaimType)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("rptFrequencyAnalysis");
            db.AddInParameter(dbCommand, "FromDate", DbType.DateTime, dtFrom);
            db.AddInParameter(dbCommand, "ToDate", DbType.DateTime, dtTo);
            db.AddInParameter(dbCommand, "claim_type", DbType.String, strClaimType);
            db.AddInParameter(dbCommand, "PK_Security_ID", DbType.Int32, clsSession.UserID);
            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet GetWCCauseAnalysisData(DateTime dtFrom, DateTime dtTo)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("rptWCCauseAnalysis");
            db.AddInParameter(dbCommand, "FromDate", DbType.DateTime, dtFrom);
            db.AddInParameter(dbCommand, "ToDate", DbType.DateTime, dtTo);
            db.AddInParameter(dbCommand, "PK_Security_ID", DbType.Int32, clsSession.UserID);
            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet GetLossLimitationData(DateTime LossFromDate1, DateTime LossToDate1, decimal LossLimit1,
                                                    DateTime LossFromDate2, DateTime LossToDate2, decimal LossLimit2,
                                                    DateTime LossFromDate3, DateTime LossToDate3, decimal LossLimit3,
                                                    string strClaimType)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("rptLossLimitation");
            db.AddInParameter(dbCommand, "LossFromDate1", DbType.DateTime, LossFromDate1);
            db.AddInParameter(dbCommand, "LossToDate1", DbType.DateTime, LossToDate1);
            db.AddInParameter(dbCommand, "LosLimit1", DbType.Decimal, LossLimit1);

            db.AddInParameter(dbCommand, "LossFromDate2", DbType.DateTime, LossFromDate2);
            db.AddInParameter(dbCommand, "LossToDate2", DbType.DateTime, LossToDate2);
            db.AddInParameter(dbCommand, "LosLimit2", DbType.Decimal, LossLimit2);

            db.AddInParameter(dbCommand, "LossFromDate3", DbType.DateTime, LossFromDate3);
            db.AddInParameter(dbCommand, "LossToDate3", DbType.DateTime, LossToDate3);
            db.AddInParameter(dbCommand, "LosLimit3", DbType.Decimal, LossLimit3);

            db.AddInParameter(dbCommand, "claim_type", DbType.String, strClaimType);
            db.AddInParameter(dbCommand, "PK_Security_ID", DbType.Int32, clsSession.UserID);

            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet GetLossStratificationData(string Accident_Year, string Claim_Type)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("rptLossStratification");
            db.AddInParameter(dbCommand, "Accident_Year", DbType.String, Accident_Year);
            db.AddInParameter(dbCommand, "Claim_Type", DbType.String, Claim_Type);
            db.AddInParameter(dbCommand, "PK_Security_ID", DbType.Int32, clsSession.UserID);
            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet GetPointInTimeDetailData(DateTime Comp_St_Date, DateTime Comp_En_Date, DateTime Accident_St_Date, DateTime Accident_En_Date, string strClaimType)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("rptPointInTimeDetail");
            db.AddInParameter(dbCommand, "Comp_St_Date", DbType.DateTime, Comp_St_Date);
            db.AddInParameter(dbCommand, "Comp_En_Date", DbType.DateTime, Comp_En_Date);
            db.AddInParameter(dbCommand, "Accident_St_Date", DbType.DateTime, Accident_St_Date);
            db.AddInParameter(dbCommand, "Accident_En_Date", DbType.DateTime, Accident_En_Date);
            db.AddInParameter(dbCommand, "Claim_Type", DbType.String, strClaimType);
            db.AddInParameter(dbCommand, "PK_Security_ID", DbType.Int32, clsSession.UserID);
            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet GetPointInTimeSummaryData(DateTime Comp_St_Date, DateTime Comp_En_Date, string strYears, string strClaimType)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("rptPointInTimeSummary");
            db.AddInParameter(dbCommand, "Comp_St_Date", DbType.DateTime, Comp_St_Date);
            db.AddInParameter(dbCommand, "Comp_En_Date", DbType.DateTime, Comp_En_Date);
            db.AddInParameter(dbCommand, "Claim_Type", DbType.String, strClaimType);
            db.AddInParameter(dbCommand, "year", DbType.String, strYears);
            db.AddInParameter(dbCommand, "PK_Security_ID", DbType.Int32, clsSession.UserID);
            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet GetThreePITSummaryData(DateTime dtAsOf1, DateTime dtLossFrom1, DateTime dtLossTo1,
                                                       DateTime dtAsOf2, DateTime dtLossFrom2, DateTime dtLossTo2,
                                                       DateTime dtAsOf3, DateTime dtLossFrom3, DateTime dtLossTo3, String strClaimType)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("rptThreePITSummaryReport");

            db.AddInParameter(dbCommand, "ClaimType", DbType.String, strClaimType);
            db.AddInParameter(dbCommand, "dt_AsOf1", DbType.DateTime, dtAsOf1);
            db.AddInParameter(dbCommand, "dt_LossFrom1", DbType.DateTime, dtLossFrom1);
            db.AddInParameter(dbCommand, "dt_LossTo1", DbType.DateTime, dtLossTo1);

            db.AddInParameter(dbCommand, "dt_AsOf2", DbType.DateTime, dtAsOf2);
            db.AddInParameter(dbCommand, "dt_LossFrom2", DbType.DateTime, dtLossFrom2);
            db.AddInParameter(dbCommand, "dt_LossTo2", DbType.DateTime, dtLossTo2);

            db.AddInParameter(dbCommand, "dt_AsOf3", DbType.DateTime, dtAsOf3);
            db.AddInParameter(dbCommand, "dt_LossFrom3", DbType.DateTime, dtLossFrom3);
            db.AddInParameter(dbCommand, "dt_LossTo3", DbType.DateTime, dtLossTo3);
            db.AddInParameter(dbCommand, "PK_Security_Id", DbType.Decimal, clsSession.UserID);

            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet GetRiskManagementWorksheet(string strRegion, string strDBA, DateTime? dtIncidentFrom, DateTime? dtIncidentTo, string strBodyParts, string strClaimStatus)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("rptRiskManagementWorkSheet");

            db.AddInParameter(dbCommand, "region", DbType.String, strRegion);
            db.AddInParameter(dbCommand, "dba", DbType.String, strDBA);
            db.AddInParameter(dbCommand, "From_Date", DbType.DateTime, dtIncidentFrom);
            db.AddInParameter(dbCommand, "To_Date", DbType.DateTime, dtIncidentTo);
            db.AddInParameter(dbCommand, "FK_Part_of_Body_Code", DbType.String, strBodyParts);
            db.AddInParameter(dbCommand, "Claim_Status", DbType.String, strClaimStatus);

            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet GetReconciliationReport(string FilePath)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("rpt_Reconciliation_Report_New");
            dbCommand.CommandTimeout = 1000;
            db.AddInParameter(dbCommand, "FilePath", DbType.String, FilePath);
            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet GetFroiRecapReport(string strRegion, string LocationDBA, DateTime? IncidentBeginDate, DateTime? IncidentEndDate, string FirstReportCategory)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("rptFROIRecapReport");
            dbCommand.CommandTimeout = 1000;
            db.AddInParameter(dbCommand, "Region", DbType.String, strRegion);
            db.AddInParameter(dbCommand, "LocaionDBA", DbType.String, LocationDBA);
            db.AddInParameter(dbCommand, "IncidentBeginDate", DbType.DateTime, IncidentBeginDate);
            db.AddInParameter(dbCommand, "IncidentEndDate", DbType.DateTime, IncidentEndDate);
            db.AddInParameter(dbCommand, "FirstReportCategory", DbType.String, FirstReportCategory);

            return db.ExecuteDataSet(dbCommand);
        }
    }
}