using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using Microsoft.Practices.EnterpriseLibrary.Common;
using System.Data.Common;

namespace ERIMS_Sonic_ReportScheduler
{
    public class Report
    {
        #region Public Variables

        public static String strConn = String.Empty;

        #endregion

        #region Constuctor

        public Report()
        {
            // 
            // TODO: Add constructor logic here
            //
        }

        #endregion

        #region Report Methods

        public static DataSet Get_Bordereau_Report(DateTime dtStartDate, DateTime dtEndDate, string strRegion)
        {
            SqlDatabase db = new SqlDatabase(strConn);
            DbCommand dbCommand = db.GetStoredProcCommand("ER_Bordereau_Report");

            db.AddInParameter(dbCommand, "StartDate", DbType.DateTime, dtStartDate);
            db.AddInParameter(dbCommand, "EndDate", DbType.DateTime, dtEndDate);
            db.AddInParameter(dbCommand, "Region", DbType.String, strRegion);

            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet Get_Notification_Bordereau_Report(DateTime dtStartDate, DateTime dtEndDate, string strRegion)
        {
            SqlDatabase db = new SqlDatabase(strConn);
            DbCommand dbCommand = db.GetStoredProcCommand("ER_Claim_Notification_Bordereau_Report");

            db.AddInParameter(dbCommand, "StartDate", DbType.DateTime, dtStartDate);
            db.AddInParameter(dbCommand, "EndDate", DbType.DateTime, dtEndDate);
            db.AddInParameter(dbCommand, "Region", DbType.String, strRegion);

            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet Get_Litigation_Summary_Report(DateTime dtStartDate, DateTime dtEndDate, string strRegion)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("ER_Litigation_Summary_Report");

            db.AddInParameter(dbCommand, "StartDate", DbType.DateTime, dtStartDate);
            db.AddInParameter(dbCommand, "EndDate", DbType.DateTime, dtEndDate);
            db.AddInParameter(dbCommand, "Region", DbType.String, strRegion);

            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet Get_Reportable_Claims_Report()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("ER_Reportable_Claims_Report");
            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet Get_Network_Call_Summary_Report(DateTime dtStartDate, DateTime dtEndDate, string strRegion)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("ER_Network_Call_Summary_Report");

            db.AddInParameter(dbCommand, "StartDate", DbType.DateTime, dtStartDate);
            db.AddInParameter(dbCommand, "EndDate", DbType.DateTime, dtEndDate);
            db.AddInParameter(dbCommand, "Region", DbType.String, strRegion);

            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet GetWCAllocationDetailData(int intYear, int intMonth, string strRegion)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("WCAllocationDetailReport");

            db.AddInParameter(dbCommand, "Year", DbType.Int32, intYear);
            db.AddInParameter(dbCommand, "Month", DbType.Int32, intMonth);
            db.AddInParameter(dbCommand, "Region", DbType.String, strRegion);

            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet GetWC_Allocation_Location_Report(decimal Year, decimal Month, decimal PK_LU_Location_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("WCAllocationLocationReport");

            db.AddInParameter(dbCommand, "Year", DbType.Decimal, Year);
            db.AddInParameter(dbCommand, "Month", DbType.Decimal, Month);
            db.AddInParameter(dbCommand, "PK_LU_Location_ID", DbType.Decimal, PK_LU_Location_ID);

            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet GetWC_Allocation_Location_Summary_Report(decimal Year)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("WCAllocationLocationSummaryReport");

            db.AddInParameter(dbCommand, "Year", DbType.Decimal, Year);

            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet GetFinancialSummaryData(string strYear, string strClaimType, string strRegion, DateTime valuation_date)
        {
            SqlDatabase db = new SqlDatabase(strConn);
            DbCommand dbCommand = db.GetStoredProcCommand("rptFinancialSummary");
            db.AddInParameter(dbCommand, "year", DbType.String, strYear);
            db.AddInParameter(dbCommand, "claim_type", DbType.String, strClaimType);
            db.AddInParameter(dbCommand, "region", DbType.String, strRegion);
            db.AddInParameter(dbCommand, "valuation_date", DbType.DateTime, valuation_date);
            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet GetFinancialPayTypeSummaryData(string strYear, string strRegion, DateTime valuation_date)
        {
            SqlDatabase db = new SqlDatabase(strConn);
            DbCommand dbCommand = db.GetStoredProcCommand("rptFinancialPayTypeSummary");
            db.AddInParameter(dbCommand, "year", DbType.String, strYear);
            db.AddInParameter(dbCommand, "region", DbType.String, strRegion);
            db.AddInParameter(dbCommand, "valuation_date", DbType.DateTime, valuation_date);
            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet GetEmployerLagSummaryData(DateTime dtFrom, DateTime dtTo, string strRegion)
        {
            SqlDatabase db = new SqlDatabase(strConn);
            DbCommand dbCommand = db.GetStoredProcCommand("rptEmployerLagSummary");
            db.AddInParameter(dbCommand, "From_Date", DbType.DateTime, dtFrom);
            db.AddInParameter(dbCommand, "To_Date", DbType.DateTime, dtTo);
            db.AddInParameter(dbCommand, "Region", DbType.String, strRegion);
            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet GetInsurerLagSummaryData(DateTime dtFrom, DateTime dtTo, string strRegion)
        {
            SqlDatabase db = new SqlDatabase(strConn);
            DbCommand dbCommand = db.GetStoredProcCommand("rptInsurerLagSummary");
            db.AddInParameter(dbCommand, "From_Date", DbType.DateTime, dtFrom);
            db.AddInParameter(dbCommand, "To_Date", DbType.DateTime, dtTo);
            db.AddInParameter(dbCommand, "Region", DbType.String, strRegion);
            return db.ExecuteDataSet(dbCommand);
        }
        public static DataSet GetCompletionLagSummaryData(DateTime dtFrom, DateTime dtTo, string strRegion)
        {
            SqlDatabase db = new SqlDatabase(strConn);
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
        public static DataSet GetFrequencyAnalysisData(DateTime dtFrom, DateTime dtTo, string strClaimType, Decimal pK_Security_ID)
        {
            SqlDatabase db = new SqlDatabase(strConn);
            DbCommand dbCommand = db.GetStoredProcCommand("rptFrequencyAnalysis");
            db.AddInParameter(dbCommand, "FromDate", DbType.DateTime, dtFrom);
            db.AddInParameter(dbCommand, "ToDate", DbType.DateTime, dtTo);
            db.AddInParameter(dbCommand, "claim_type", DbType.String, strClaimType);
            db.AddInParameter(dbCommand, "PK_Security_ID", DbType.Int32, pK_Security_ID);
            return db.ExecuteDataSet(dbCommand);
        }
        public static DataSet GetWCCauseAnalysisData(DateTime dtFrom, DateTime dtTo, Decimal pK_Security_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("rptWCCauseAnalysis");
            db.AddInParameter(dbCommand, "FromDate", DbType.DateTime, dtFrom);
            db.AddInParameter(dbCommand, "ToDate", DbType.DateTime, dtTo);
            db.AddInParameter(dbCommand, "PK_Security_ID", DbType.Int32, pK_Security_ID);
            return db.ExecuteDataSet(dbCommand);
        }
        public static DataSet GetLossLimitationData(DateTime LossFromDate1, DateTime LossToDate1, decimal LossLimit1,
                                                    DateTime LossFromDate2, DateTime LossToDate2, decimal LossLimit2,
                                                    DateTime LossFromDate3, DateTime LossToDate3, decimal LossLimit3,
                                                    string strClaimType, Decimal pK_Security_ID)
        {
            SqlDatabase db = new SqlDatabase(strConn);
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
            db.AddInParameter(dbCommand, "PK_Security_ID", DbType.Int32, pK_Security_ID);

            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet GetLossStratificationData(string Accident_Year, string Claim_Type, Decimal pK_Security_ID)
        {
            SqlDatabase db = new SqlDatabase(strConn);
            DbCommand dbCommand = db.GetStoredProcCommand("rptLossStratification");
            db.AddInParameter(dbCommand, "Accident_Year", DbType.String, Accident_Year);
            db.AddInParameter(dbCommand, "Claim_Type", DbType.String, Claim_Type);
            db.AddInParameter(dbCommand, "PK_Security_ID", DbType.Int32, pK_Security_ID);
            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet GetPointInTimeDetailData(DateTime Comp_St_Date, DateTime Comp_En_Date, DateTime Accident_St_Date, DateTime Accident_En_Date, string strClaimType, Decimal pK_Security_ID)
        {
            SqlDatabase db = new SqlDatabase(strConn);
            DbCommand dbCommand = db.GetStoredProcCommand("rptPointInTimeDetail");
            db.AddInParameter(dbCommand, "Comp_St_Date", DbType.DateTime, Comp_St_Date);
            db.AddInParameter(dbCommand, "Comp_En_Date", DbType.DateTime, Comp_En_Date);
            db.AddInParameter(dbCommand, "Accident_St_Date", DbType.DateTime, Accident_St_Date);
            db.AddInParameter(dbCommand, "Accident_En_Date", DbType.DateTime, Accident_En_Date);
            db.AddInParameter(dbCommand, "Claim_Type", DbType.String, strClaimType);
            db.AddInParameter(dbCommand, "PK_Security_ID", DbType.Int32, pK_Security_ID);
            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet GetPointInTimeSummaryData(DateTime Comp_St_Date, DateTime Comp_En_Date, string strYears, string strClaimType, Decimal pK_Security_ID)
        {
            SqlDatabase db = new SqlDatabase(strConn);
            DbCommand dbCommand = db.GetStoredProcCommand("rptPointInTimeSummary");
            db.AddInParameter(dbCommand, "Comp_St_Date", DbType.DateTime, Comp_St_Date);
            db.AddInParameter(dbCommand, "Comp_En_Date", DbType.DateTime, Comp_En_Date);
            db.AddInParameter(dbCommand, "Claim_Type", DbType.String, strClaimType);
            db.AddInParameter(dbCommand, "year", DbType.String, strYears);
            db.AddInParameter(dbCommand, "PK_Security_ID", DbType.Int32, pK_Security_ID);
            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet GetThreePITSummaryData(DateTime dtAsOf1, DateTime dtLossFrom1, DateTime dtLossTo1,
                                                       DateTime dtAsOf2, DateTime dtLossFrom2, DateTime dtLossTo2,
                                                       DateTime dtAsOf3, DateTime dtLossFrom3, DateTime dtLossTo3, String strClaimType, Decimal pK_Security_ID)
        {
            SqlDatabase db = new SqlDatabase(strConn);
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
            db.AddInParameter(dbCommand, "PK_Security_Id", DbType.Decimal, pK_Security_ID);

            return db.ExecuteDataSet(dbCommand);
        }
        /// <summary>
        ///  get record for WC Allocation Monthly Detail Report
        /// </summary>
        /// <param name="month"></param>
        /// <param name="year"></param>
        /// <returns></returns>
        public static DataSet WCAllocationMonthlyDetailReport(int month, int year)
        {
            SqlDatabase db = new SqlDatabase(strConn);
            DbCommand dbCommand = db.GetStoredProcCommand("WCAllocationMonthlyDetailReport");

            db.AddInParameter(dbCommand, "month", DbType.Int32, month);
            db.AddInParameter(dbCommand, "year", DbType.Int32, year);

            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet WC_Monthly_Allocation_Summary_Report(decimal year)
        {
            SqlDatabase db = new SqlDatabase(strConn);
            DbCommand dbCommand = db.GetStoredProcCommand("WCMonthlyAllocationSummaryReport");

            db.AddInParameter(dbCommand, "year", DbType.Int32, year);

            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet GetService_Contract_Detail_Report(string strRegion, string strLocation, string strServiceContract, string strServiceType, Nullable<DateTime> dtStartToDate, Nullable<DateTime> dtStartFromDate, Nullable<DateTime> dtEndToDate, Nullable<DateTime> dtEndFromDate)
        {
            SqlDatabase db = new SqlDatabase(strConn);
            DbCommand dbCommand = db.GetStoredProcCommand("Purchase_Service_Contract_Detail_Report");
            db.AddInParameter(dbCommand, "Region", DbType.String, strRegion);
            db.AddInParameter(dbCommand, "Location", DbType.String, strLocation);
            db.AddInParameter(dbCommand, "ServiceContract", DbType.String, strServiceContract);
            db.AddInParameter(dbCommand, "ServiceType", DbType.String, strServiceType);
            db.AddInParameter(dbCommand, "StartToDate", DbType.DateTime, dtStartToDate);
            db.AddInParameter(dbCommand, "StartFromDate", DbType.DateTime, dtStartFromDate);
            db.AddInParameter(dbCommand, "EndToDate", DbType.DateTime, dtEndToDate);
            db.AddInParameter(dbCommand, "EndFromDate", DbType.DateTime, dtEndFromDate);

            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet GetLease_Rental_Detail_Report(string strRegion, string strLocation, string strEquipmentType, string strLeaseRentalType, Nullable<DateTime> dtStartToDate, Nullable<DateTime> dtStartFromDate, Nullable<DateTime> dtEndToDate, Nullable<DateTime> dtEndFromDate)
        {
            SqlDatabase db = new SqlDatabase(strConn);
            DbCommand dbCommand = db.GetStoredProcCommand("Purchase_Rental_Lease_Detail_Report");
            db.AddInParameter(dbCommand, "Region", DbType.String, strRegion);
            db.AddInParameter(dbCommand, "Location", DbType.String, strLocation);
            db.AddInParameter(dbCommand, "EquipmentType", DbType.String, strEquipmentType);
            db.AddInParameter(dbCommand, "LeaseRentalType", DbType.String, strLeaseRentalType);
            db.AddInParameter(dbCommand, "StartToDate", DbType.DateTime, dtStartToDate);
            db.AddInParameter(dbCommand, "StartFromDate", DbType.DateTime, dtStartFromDate);
            db.AddInParameter(dbCommand, "EndToDate", DbType.DateTime, dtEndToDate);
            db.AddInParameter(dbCommand, "EndFromDate", DbType.DateTime, dtEndFromDate);

            return db.ExecuteDataSet(dbCommand);
        }

        // public static DataSet Get_Purchase_Report(int FK_LU_Location_Id,string Type,string strRegion,string Manufacturer)
        public static DataSet Get_Purchase_Report(string strRegion, string Manufacturer, string Type, string Location)
        {
            SqlDatabase db = new SqlDatabase(strConn);
            DbCommand dbCommand = db.GetStoredProcCommand("Purchasing_Asset_Report");

            db.AddInParameter(dbCommand, "Region", DbType.String, strRegion);
            db.AddInParameter(dbCommand, "Manufacturer", DbType.String, Manufacturer);
            db.AddInParameter(dbCommand, "Type", DbType.String, Type);
            db.AddInParameter(dbCommand, "Location", DbType.String, Location);
            return db.ExecuteDataSet(dbCommand);
        }


        /// <summary>
        /// Selects a single record from the LU_Manufacturer table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectManufacturerByPK(decimal pK_LU_Manufacturer)
        {
            SqlDatabase db = new SqlDatabase(strConn);
            DbCommand dbCommand = db.GetStoredProcCommand("LU_ManufacturerSelectByPK");

            db.AddInParameter(dbCommand, "PK_LU_Manufacturer", DbType.Decimal, pK_LU_Manufacturer);

            return db.ExecuteDataSet(dbCommand);
        }
        /// <summary>
        /// Select Report Sonic Cause Code Reclassification Report
        /// </summary>
        /// <param name="strRegion"></param>
        /// <param name="strDBA"></param>
        /// <param name="DateofInjury_From"></param>
        /// <param name="DateofInjury_To"></param>
        /// <param name="FirstReportNumber"></param>
        /// <param name="IncidentInvestigationNumber"></param>
        /// <param name="strCliamNumber"></param>
        /// <returns></returns>
        public static DataSet GetSonicCauseCodeReclassification_Report(string strRegion, string strDBA, DateTime? DateofInjury_From, DateTime? DateofInjury_To, decimal? FirstReportNumber, decimal? IncidentInvestigationNumber, string strCliamNumber)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("rptWCSonicCauseCodeReclassificationReport");


            if (!string.IsNullOrEmpty(strRegion))
                db.AddInParameter(dbCommand, "Region", DbType.String, strRegion);

            if (!string.IsNullOrEmpty(strDBA))
                db.AddInParameter(dbCommand, "Location", DbType.String, strDBA);

            if (DateofInjury_From != null)
                db.AddInParameter(dbCommand, "DateofInjury_From", DbType.DateTime, DateofInjury_From);

            if (DateofInjury_To != null)
                db.AddInParameter(dbCommand, "DateofInjury_To", DbType.DateTime, DateofInjury_To);

            db.AddInParameter(dbCommand, "FirstReportNumber", DbType.Decimal, FirstReportNumber);
            db.AddInParameter(dbCommand, "IncidentInvestigationNumber", DbType.Decimal, IncidentInvestigationNumber);

            if (!string.IsNullOrEmpty(strCliamNumber))
                db.AddInParameter(dbCommand, "ClaimNumber", DbType.String, strCliamNumber);

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
        #endregion

        #region "Lease - Real Estate Report"

        /// <summary>
        /// Get Lease Details Report
        /// </summary>
        /// <param name="strRegion"></param>
        /// <param name="strLeaseType"></param>
        /// <param name="dtLCDFrom"></param>
        /// <param name="dtLCDTo"></param>
        /// <param name="dtLEDFrom"></param>
        /// <param name="dtLEDTo"></param>
        /// <param name="strOrder"></param>
        /// <returns></returns>
        public static DataSet GetLeaseDetailReport(string strRegion, string strLeaseType, DateTime? dtLCDFrom, DateTime? dtLCDTo, DateTime? dtLEDFrom, DateTime? dtLEDTo, string strOrder)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Lease_Detail_Report");

            db.AddInParameter(dbCommand, "Region", DbType.String, strRegion);
            db.AddInParameter(dbCommand, "Lease_Type", DbType.String, strLeaseType);
            db.AddInParameter(dbCommand, "LCD_From", DbType.DateTime, dtLCDFrom);
            db.AddInParameter(dbCommand, "LCD_To", DbType.DateTime, dtLCDTo);
            db.AddInParameter(dbCommand, "LED_From", DbType.DateTime, dtLEDFrom);
            db.AddInParameter(dbCommand, "LED_To", DbType.DateTime, dtLEDTo);
            db.AddInParameter(dbCommand, "strorder", DbType.String, strOrder);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Lease details Report sub details
        /// </summary>
        /// <param name="strRegion"></param>
        /// <param name="strLeaseType"></param>
        /// <param name="dtLCDFrom"></param>
        /// <param name="dtLCDTo"></param>
        /// <param name="dtLEDFrom"></param>
        /// <param name="dtLEDTo"></param>
        /// <param name="strOrder"></param>
        /// <returns></returns>
        public static DataSet GetLeaseDetailReport_SubDetails(string strRegion, string strLeaseType, DateTime? dtLCDFrom, DateTime? dtLCDTo, DateTime? dtLEDFrom, DateTime? dtLEDTo, string strOrder)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Lease_Detail_Report_SubDetails");


            db.AddInParameter(dbCommand, "Region", DbType.String, strRegion);
            db.AddInParameter(dbCommand, "Lease_Type", DbType.String, strLeaseType);
            db.AddInParameter(dbCommand, "LCD_From", DbType.DateTime, dtLCDFrom);
            db.AddInParameter(dbCommand, "LCD_To", DbType.DateTime, dtLCDTo);
            db.AddInParameter(dbCommand, "LED_From", DbType.DateTime, dtLEDFrom);
            db.AddInParameter(dbCommand, "LED_To", DbType.DateTime, dtLEDTo);
            db.AddInParameter(dbCommand, "strorder", DbType.String, strOrder);

            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet GetRentProjectionsHistory(string strDBA, string strLeaseType, Int16? RentYearFrom, Int16? RentYearTo, string EscalationType)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("rptRentProjectionsHistory");

            if (!string.IsNullOrEmpty(strDBA))
                db.AddInParameter(dbCommand, "DBA", DbType.String, strDBA);

            if (!string.IsNullOrEmpty(strLeaseType))
                db.AddInParameter(dbCommand, "LeaseType", DbType.String, strLeaseType);

            if (RentYearFrom != null)
                db.AddInParameter(dbCommand, "@RentYearFrom", DbType.Int16, RentYearFrom);

            if (RentYearTo != null)
                db.AddInParameter(dbCommand, "RentYearTo", DbType.Int16, RentYearTo);

            if (!string.IsNullOrEmpty(EscalationType))
                db.AddInParameter(dbCommand, "EscalationType", DbType.String, EscalationType);

            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet GetLeaseTermReport(string strRegion, string strLeaseType, DateTime? dtLCDFrom, DateTime? dtLCDTo, DateTime? dtLEDFrom, DateTime? dtLEDTo)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("rptLeaseTerm");

            if (!string.IsNullOrEmpty(strRegion))
                db.AddInParameter(dbCommand, "Region", DbType.String, strRegion);

            if (!string.IsNullOrEmpty(strLeaseType))
                db.AddInParameter(dbCommand, "LeaseType", DbType.String, strLeaseType);

            if (dtLCDFrom != null)
                db.AddInParameter(dbCommand, "LCD_From", DbType.DateTime, dtLCDFrom);

            if (dtLCDTo != null)
                db.AddInParameter(dbCommand, "LCD_To", DbType.DateTime, dtLCDTo);

            if (dtLEDFrom != null)
                db.AddInParameter(dbCommand, "LED_From", DbType.DateTime, dtLEDFrom);

            if (dtLEDTo != null)
                db.AddInParameter(dbCommand, "LED_To", DbType.DateTime, dtLEDTo);

            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet GetMasterDealership(string strRegion, DateTime? dtLCDFrom, DateTime? dtLCDTo, DateTime? dtLEDFrom, DateTime? dtLEDTo)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("rptMasterDealershipByRegion");

            if (!string.IsNullOrEmpty(strRegion))
                db.AddInParameter(dbCommand, "Region", DbType.String, strRegion);

            if (dtLCDFrom != null)
                db.AddInParameter(dbCommand, "LCD_From", DbType.DateTime, dtLCDFrom);

            if (dtLCDTo != null)
                db.AddInParameter(dbCommand, "LCD_To", DbType.DateTime, dtLCDTo);

            if (dtLEDFrom != null)
                db.AddInParameter(dbCommand, "LED_From", DbType.DateTime, dtLEDFrom);

            if (dtLEDTo != null)
                db.AddInParameter(dbCommand, "LED_To", DbType.DateTime, dtLEDTo);

            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet GetSubspacesByLocation(string strRegion, string strLeaseType, DateTime? dtLCDFrom, DateTime? dtLCDTo, DateTime? dtLEDFrom, DateTime? dtLEDTo)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("rptSubspacesByLocation");


            if (!string.IsNullOrEmpty(strRegion))
                db.AddInParameter(dbCommand, "Region", DbType.String, strRegion);

            if (!string.IsNullOrEmpty(strLeaseType))
                db.AddInParameter(dbCommand, "LeaseType", DbType.String, strLeaseType);

            if (dtLCDFrom != null)
                db.AddInParameter(dbCommand, "LCD_From", DbType.DateTime, dtLCDFrom);

            if (dtLCDTo != null)
                db.AddInParameter(dbCommand, "LCD_To", DbType.DateTime, dtLCDTo);

            if (dtLEDFrom != null)
                db.AddInParameter(dbCommand, "LED_From", DbType.DateTime, dtLEDFrom);

            if (dtLEDTo != null)
                db.AddInParameter(dbCommand, "LED_To", DbType.DateTime, dtLEDTo);

            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet GetRentableAreaByExpirationDate(string strRegion, string strLeaseType, DateTime? dtLCDFrom, DateTime? dtLCDTo, DateTime? dtLEDFrom, DateTime? dtLEDTo)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("rptRentableAreaByExpirationDate");

            db.AddInParameter(dbCommand, "Year", DbType.Int32, System.DateTime.Today.Year);

            if (!string.IsNullOrEmpty(strRegion))
                db.AddInParameter(dbCommand, "Region", DbType.String, strRegion);

            if (!string.IsNullOrEmpty(strLeaseType))
                db.AddInParameter(dbCommand, "LeaseType", DbType.String, strLeaseType);

            if (dtLCDFrom != null)
                db.AddInParameter(dbCommand, "LCD_From", DbType.DateTime, dtLCDFrom);

            if (dtLCDTo != null)
                db.AddInParameter(dbCommand, "LCD_To", DbType.DateTime, dtLCDTo);

            if (dtLEDFrom != null)
                db.AddInParameter(dbCommand, "LED_From", DbType.DateTime, dtLEDFrom);

            if (dtLEDTo != null)
                db.AddInParameter(dbCommand, "LED_To", DbType.DateTime, dtLEDTo);

            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet GetMonthlyExpenseByLocation(string strRegion, string strLeaseType, DateTime? dtLCDFrom, DateTime? dtLCDTo, DateTime? dtLEDFrom, DateTime? dtLEDTo)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("rptMonthlyExpenseByLocation");

            db.AddInParameter(dbCommand, "Curr_Date", DbType.DateTime, System.DateTime.Today);
            if (!string.IsNullOrEmpty(strRegion))
                db.AddInParameter(dbCommand, "Region", DbType.String, strRegion);

            if (!string.IsNullOrEmpty(strLeaseType))
                db.AddInParameter(dbCommand, "LeaseType", DbType.String, strLeaseType);

            if (dtLCDFrom != null)
                db.AddInParameter(dbCommand, "LCD_From", DbType.DateTime, dtLCDFrom);

            if (dtLCDTo != null)
                db.AddInParameter(dbCommand, "LCD_To", DbType.DateTime, dtLCDTo);

            if (dtLEDFrom != null)
                db.AddInParameter(dbCommand, "LED_From", DbType.DateTime, dtLEDFrom);

            if (dtLEDTo != null)
                db.AddInParameter(dbCommand, "LED_To", DbType.DateTime, dtLEDTo);

            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet GetLeasesWithSecurityDeposits(string strRegion, string strLeaseType, DateTime? dtLCDFrom, DateTime? dtLCDTo, DateTime? dtLEDFrom, DateTime? dtLEDTo)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("rptLeasesWithSecurityDeposits");


            if (!string.IsNullOrEmpty(strRegion))
                db.AddInParameter(dbCommand, "Region", DbType.String, strRegion);

            if (!string.IsNullOrEmpty(strLeaseType))
                db.AddInParameter(dbCommand, "LeaseType", DbType.String, strLeaseType);

            if (dtLCDFrom != null)
                db.AddInParameter(dbCommand, "LCD_From", DbType.DateTime, dtLCDFrom);

            if (dtLCDTo != null)
                db.AddInParameter(dbCommand, "LCD_To", DbType.DateTime, dtLCDTo);

            if (dtLEDFrom != null)
                db.AddInParameter(dbCommand, "LED_From", DbType.DateTime, dtLEDFrom);

            if (dtLEDTo != null)
                db.AddInParameter(dbCommand, "LED_To", DbType.DateTime, dtLEDTo);

            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet GetLandlordReport(string strRegion, string strLeaseType, DateTime? dtLCDFrom, DateTime? dtLCDTo, DateTime? dtLEDFrom, DateTime? dtLEDTo)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("rptLandlord");


            if (!string.IsNullOrEmpty(strRegion))
                db.AddInParameter(dbCommand, "Region", DbType.String, strRegion);

            if (!string.IsNullOrEmpty(strLeaseType))
                db.AddInParameter(dbCommand, "LeaseType", DbType.String, strLeaseType);

            if (dtLCDFrom != null)
                db.AddInParameter(dbCommand, "LCD_From", DbType.DateTime, dtLCDFrom);

            if (dtLCDTo != null)
                db.AddInParameter(dbCommand, "LCD_To", DbType.DateTime, dtLCDTo);

            if (dtLEDFrom != null)
                db.AddInParameter(dbCommand, "LED_From", DbType.DateTime, dtLEDFrom);

            if (dtLEDTo != null)
                db.AddInParameter(dbCommand, "LED_To", DbType.DateTime, dtLEDTo);

            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet GetMaintenanceAndRepairItems(string strRegion, string strLeaseType, DateTime? dtLCDFrom, DateTime? dtLCDTo, DateTime? dtLEDFrom, DateTime? dtLEDTo)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("rptREMaintenanceAndRepair");


            if (!string.IsNullOrEmpty(strRegion))
                db.AddInParameter(dbCommand, "Region", DbType.String, strRegion);

            if (!string.IsNullOrEmpty(strLeaseType))
                db.AddInParameter(dbCommand, "LeaseType", DbType.String, strLeaseType);

            if (dtLCDFrom != null)
                db.AddInParameter(dbCommand, "LCD_From", DbType.DateTime, dtLCDFrom);

            if (dtLCDTo != null)
                db.AddInParameter(dbCommand, "LCD_To", DbType.DateTime, dtLCDTo);

            if (dtLEDFrom != null)
                db.AddInParameter(dbCommand, "LED_From", DbType.DateTime, dtLEDFrom);

            if (dtLEDTo != null)
                db.AddInParameter(dbCommand, "LED_To", DbType.DateTime, dtLEDTo);

            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet GetWCAllocationYTDChargeReport(string strRegion, string strLocation, string strYear)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("rptWCAllocationYTDChargeReport");

            if (!string.IsNullOrEmpty(strRegion))
                db.AddInParameter(dbCommand, "region", DbType.String, strRegion);

            if (!string.IsNullOrEmpty(strLocation))
                db.AddInParameter(dbCommand, "location", DbType.String, strLocation);

            if (!string.IsNullOrEmpty(strYear))
                db.AddInParameter(dbCommand, "Accident_year", DbType.String, strYear);

            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet GetLandlordInfoReport(string strRegion, DateTime? dtLCDFrom, DateTime? dtLCDTo, DateTime? dtLEDFrom, DateTime? dtLEDTo)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("rptlandlordInfo");

            if (!string.IsNullOrEmpty(strRegion))
                db.AddInParameter(dbCommand, "Region", DbType.String, strRegion);

            if (dtLCDFrom != null)
                db.AddInParameter(dbCommand, "LCD_From", DbType.DateTime, dtLCDFrom);

            if (dtLCDTo != null)
                db.AddInParameter(dbCommand, "LCD_To", DbType.DateTime, dtLCDTo);

            if (dtLEDFrom != null)
                db.AddInParameter(dbCommand, "LED_From", DbType.DateTime, dtLEDFrom);

            if (dtLEDTo != null)
                db.AddInParameter(dbCommand, "LED_To", DbType.DateTime, dtLEDTo);

            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet GetCriticalDatesReport(string strRegion, DateTime? dtLCDFrom, DateTime? dtLCDTo, DateTime? dtLEDFrom, DateTime? dtLEDTo, string strLocation_Status, string strReportName)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("rptCriticalDates");


            if (!string.IsNullOrEmpty(strRegion))
                db.AddInParameter(dbCommand, "Region", DbType.String, strRegion);

            if (dtLCDFrom != null)
                db.AddInParameter(dbCommand, "LCD_From", DbType.DateTime, dtLCDFrom);

            if (dtLCDTo != null)
                db.AddInParameter(dbCommand, "LCD_To", DbType.DateTime, dtLCDTo);

            if (dtLEDFrom != null)
                db.AddInParameter(dbCommand, "LED_From", DbType.DateTime, dtLEDFrom);

            if (dtLEDTo != null)
                db.AddInParameter(dbCommand, "LED_To", DbType.DateTime, dtLEDTo);
            
            if (!string.IsNullOrEmpty(strLocation_Status))
                db.AddInParameter(dbCommand, "Location_Status", DbType.String, strLocation_Status);

            if (!string.IsNullOrEmpty(strReportName))
                db.AddInParameter(dbCommand, "strReportName", DbType.String, strReportName);

            return db.ExecuteDataSet(dbCommand);
        }
        public static DataSet GetLandlordNotificationReport(string strRegion, DateTime? dtLCDFrom, DateTime? dtLCDTo, DateTime? dtLEDFrom, DateTime? dtLEDTo, string strLocation_Status)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("rptLandlordNotificationReportDates");


            if (!string.IsNullOrEmpty(strRegion))
                db.AddInParameter(dbCommand, "Region", DbType.String, strRegion);

            if (dtLCDFrom != null)
                db.AddInParameter(dbCommand, "LCD_From", DbType.DateTime, dtLCDFrom);

            if (dtLCDTo != null)
                db.AddInParameter(dbCommand, "LCD_To", DbType.DateTime, dtLCDTo);

            if (dtLEDFrom != null)
                db.AddInParameter(dbCommand, "LED_From", DbType.DateTime, dtLEDFrom);

            if (dtLEDTo != null)
                db.AddInParameter(dbCommand, "LED_To", DbType.DateTime, dtLEDTo);

            if (!string.IsNullOrEmpty(strLocation_Status))
                db.AddInParameter(dbCommand, "Location_Status", DbType.String, strLocation_Status);

            return db.ExecuteDataSet(dbCommand);
        }
        public static DataSet GetSubLeaseReport(string strDBA, DateTime? dtLCDFrom, DateTime? dtLCDTo, DateTime? dtLEDFrom, DateTime? dtLEDTo, decimal FK_Security_Id, string strStatus)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("rptSubLeaseReport");


            if (!string.IsNullOrEmpty(strDBA))
                db.AddInParameter(dbCommand, "DBA", DbType.String, strDBA);

            if (dtLCDFrom != null)
                db.AddInParameter(dbCommand, "LCD_From", DbType.DateTime, dtLCDFrom);

            if (dtLCDTo != null)
                db.AddInParameter(dbCommand, "LCD_To", DbType.DateTime, dtLCDTo);

            if (dtLEDFrom != null)
                db.AddInParameter(dbCommand, "LED_From", DbType.DateTime, dtLEDFrom);

            if (dtLEDTo != null)
                db.AddInParameter(dbCommand, "LED_To", DbType.DateTime, dtLEDTo);
            db.AddInParameter(dbCommand, "Pk_Security_ID", DbType.Decimal, FK_Security_Id);
            db.AddInParameter(dbCommand, "Status", DbType.String, strStatus);
            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet SelectByFK_RE_Information(decimal fK_RE_Information)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("RE_BuildingSelectByRE");
            db.AddInParameter(dbCommand, "FK_RE_Information", DbType.Decimal, fK_RE_Information);
            return db.ExecuteDataSet(dbCommand);
        }
        #endregion

        #region Other Methods

        public static DataTable GetScheduleReports(DateTime dtSchduleDate)
        {
            SqlDatabase db = new SqlDatabase(strConn);
            DbCommand dbCommand = db.GetStoredProcCommand("Tatva_ReportScheduleSelectByScheduled_Date");

            db.AddInParameter(dbCommand, "Scheduled_Date", DbType.DateTime, dtSchduleDate);

            return db.ExecuteDataSet(dbCommand).Tables[0];
        }

        public static DataSet SelectOneRecordWithRecipientList(decimal fK_RecipientList)
        {
            SqlDatabase db = new SqlDatabase(strConn);
            DbCommand dbCommand = db.GetStoredProcCommand("Tatva_RecipientListMatrixSelectWithRecipientList");

            db.AddInParameter(dbCommand, "FK_RecipientList", DbType.Decimal, fK_RecipientList);

            return db.ExecuteDataSet(dbCommand);
        }
        public static DataSet SelectSecurityByPK(decimal pK_Security_ID)
        {
            SqlDatabase db = new SqlDatabase(strConn);
            DbCommand dbCommand = db.GetStoredProcCommand("Get_SecrityUser");

            db.AddInParameter(dbCommand, "PK_Security_ID", DbType.Decimal, pK_Security_ID);

            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet ReportScheduleSelectByPK(decimal pK_Schedule)
        {
            SqlDatabase db = new SqlDatabase(strConn);
            DbCommand dbCommand = db.GetStoredProcCommand("Tatva_ReportScheduleSelectByPK");

            db.AddInParameter(dbCommand, "PK_Schedule", DbType.Decimal, pK_Schedule);

            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet SelectFilterCriteria(int pK_ReportID, decimal pK_Schedule_ID)
        {
            SqlDatabase db = new SqlDatabase(strConn);
            DbCommand dbCommand;

            dbCommand = db.GetStoredProcCommand("Tatva_ReportScheduleSelectFilterCriteria");

            db.AddInParameter(dbCommand, "FK_Schedule", DbType.Decimal, pK_Schedule_ID);
            db.AddInParameter(dbCommand, "PK_ReportID", DbType.Decimal, pK_ReportID);

            return db.ExecuteDataSet(dbCommand);
        }
        /// <summary>
        /// Selects a single record from the LU_Location table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectLocationInfoById(decimal pK_LU_Location_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_LocationSelectByPK");

            db.AddInParameter(dbCommand, "PK_LU_Location_ID", DbType.Decimal, pK_LU_Location_ID);

            return db.ExecuteDataSet(dbCommand);
        }

        public static string GetLeaseTypeList(string strLeaseType)
        {
            SqlDatabase db = new SqlDatabase(strConn);
            DbCommand dbCommand = db.GetStoredProcCommand("GetLeaseTypeList");

            db.AddInParameter(dbCommand, "strLeaseType", DbType.String, strLeaseType);

            return Convert.ToString(db.ExecuteScalar(dbCommand));
        }

        public static string GetEscalationTypeList(string strEscalationType)
        {
            SqlDatabase db = new SqlDatabase(strConn);
            DbCommand dbCommand = db.GetStoredProcCommand("GetEscalationTypeList");

            db.AddInParameter(dbCommand, "strEscalationType", DbType.String, strEscalationType);

            return Convert.ToString(db.ExecuteScalar(dbCommand));
        }

        public static DataSet getLocationByIds(string strLocation)
        {
            SqlDatabase db = new SqlDatabase(strConn);
            DbCommand dbCommand = db.GetStoredProcCommand("LU_LocationSelectByIds");

            db.AddInParameter(dbCommand, "strLocation", DbType.String, strLocation);

            return db.ExecuteDataSet(dbCommand);
        }

        public static string GetCommaSeperatedDescFromVal(string Table_Name, string ColName_Desc, string ColName_PK, string PK_List)
        {
            string strValues = "";
            SqlDatabase db = new SqlDatabase(strConn);
            DbCommand dbCommand = db.GetStoredProcCommand("GetCommaSeperatedDescFromVal");
            db.AddInParameter(dbCommand, "Table_Name", DbType.String, Table_Name);
            db.AddInParameter(dbCommand, "ColName_Desc", DbType.String, ColName_Desc);
            db.AddInParameter(dbCommand, "ColName_PK", DbType.String, ColName_PK);
            db.AddInParameter(dbCommand, "PK_List", DbType.String, PK_List);
            DataSet ds = db.ExecuteDataSet(dbCommand);
            if (ds.Tables[0].Rows.Count > 0)
                strValues = Convert.ToString(ds.Tables[0].Rows[0][0]);

            return strValues;
        }
        #endregion

        #region Exposures Reports

        public static DataSet GetPropertyStatementofValues(string strRegion, string strStatus, string strOwnership, DateTime? dtPropertyValuationDateFrom, DateTime? dtPropertyValuationDateTo)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("rptPropertyStatementofValues");

            db.AddInParameter(dbCommand, "Region", DbType.String, strRegion);
            db.AddInParameter(dbCommand, "Status", DbType.String, strStatus);
            db.AddInParameter(dbCommand, "Ownership", DbType.String, strOwnership);
            db.AddInParameter(dbCommand, "PropertyValuationDateFrom", DbType.DateTime, dtPropertyValuationDateFrom);
            db.AddInParameter(dbCommand, "PropertyValuationDateTo", DbType.DateTime, dtPropertyValuationDateTo);

            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet GetNewExposuresreport(string strRegion, string strStatus, decimal FK_Security_Id)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("rptNEWExposuresreport");
            if (strRegion != string.Empty)
                db.AddInParameter(dbCommand, "Region", DbType.String, strRegion);
            if (strStatus != string.Empty)
                db.AddInParameter(dbCommand, "Status", DbType.String, strStatus);
            db.AddInParameter(dbCommand, "Pk_Security_ID", DbType.Decimal, FK_Security_Id);
            return db.ExecuteDataSet(dbCommand);
        }
        public static DataSet GetFacilityInspectionReport(string strRegion, int intYear, string strInterval, decimal FK_Security_Id)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("rptFacilityInspection");
            db.AddInParameter(dbCommand, "Region", DbType.String, strRegion);
            db.AddInParameter(dbCommand, "Year", DbType.Int32, intYear);
            db.AddInParameter(dbCommand, "strInterval", DbType.String, strInterval);
            db.AddInParameter(dbCommand, "Pk_Security_ID", DbType.Decimal, FK_Security_Id);

            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet GetInspectionsByInspector(string strRegion, string strDBA, string strInspectorName, DateTime? dtInspectionDateFrom, DateTime? dtInspectionDateTo)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("rptInspectionsByInspector");

            db.AddInParameter(dbCommand, "Region", DbType.String, strRegion);
            db.AddInParameter(dbCommand, "Inspector_Name", DbType.String, strInspectorName);
            db.AddInParameter(dbCommand, "DBA", DbType.String, strDBA);
            db.AddInParameter(dbCommand, "Inspection_From", DbType.DateTime, dtInspectionDateFrom);
            db.AddInParameter(dbCommand, "Inspection_To", DbType.DateTime, dtInspectionDateTo);

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

        public static DataSet GetInspectionLagTime(string strRegion, string strDBA, string strInspectionArea, string strInspectorName, DateTime? dtInspectionDateFrom, DateTime? dtInspectionDateTo, string strLagDayOption)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("rptInspectionLagTime");

            db.AddInParameter(dbCommand, "Region", DbType.String, strRegion);
            db.AddInParameter(dbCommand, "Inspector_Name", DbType.String, strInspectorName);
            db.AddInParameter(dbCommand, "DBA", DbType.String, strDBA);
            db.AddInParameter(dbCommand, "InspectionArea", DbType.String, strInspectionArea);
            db.AddInParameter(dbCommand, "Inspection_From", DbType.DateTime, dtInspectionDateFrom);
            db.AddInParameter(dbCommand, "Inspection_To", DbType.DateTime, dtInspectionDateTo);
            db.AddInParameter(dbCommand, "LagDayOption", DbType.String, strLagDayOption);
            return db.ExecuteDataSet(dbCommand);
        }

        #endregion

        #region " Policy Report "

        public static DataSet GetInsuranceSchedule(int? intPolicy_Year, string strProgramIDs, string strPolicyTypes)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("rptInsurance");

            db.AddInParameter(dbCommand, "Policy_Year", DbType.Int32, intPolicy_Year);
            db.AddInParameter(dbCommand, "ProgramID", DbType.String, strProgramIDs);
            db.AddInParameter(dbCommand, "PolicyType", DbType.String, strPolicyTypes);
            return db.ExecuteDataSet(dbCommand);
        }

        public static string SelectPolicyTypes(string strPolicyTypes)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Policy_TypeSelectCommaSeparated");

            db.AddInParameter(dbCommand, "PK_IDs", DbType.String, strPolicyTypes);

            DataSet ds = db.ExecuteDataSet(dbCommand);
            if (ds.Tables[0].Rows.Count > 0)
                return Convert.ToString(ds.Tables[0].Rows[0][0]);
            else
                return "";

        }

        public static string SelectPrograms(string strProgramIDs)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Tatva_ProgramSelectCommaSeparated");

            db.AddInParameter(dbCommand, "PK_IDs", DbType.String, strProgramIDs);

            DataSet ds = db.ExecuteDataSet(dbCommand);
            if (ds.Tables[0].Rows.Count > 0)
                return Convert.ToString(ds.Tables[0].Rows[0][0]);
            else
                return "";

        }
        #endregion

        #region  CRM Reports "

        public static DataSet GetCustomerIncidentSummary(int intYear, string strFK_LU_Location)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("rptCustomerIncidentSummary");
            db.AddInParameter(dbCommand, "Year", DbType.String, intYear.ToString());
            db.AddInParameter(dbCommand, "strFK_LU_Location", DbType.String, strFK_LU_Location);

            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet GetNonCustomerInquiryData(int intYear, string strFK_LU_Location)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("rptNonCustomerInquiry");
            db.AddInParameter(dbCommand, "Year", DbType.String, intYear.ToString());
            db.AddInParameter(dbCommand, "strFK_LU_Location", DbType.String, strFK_LU_Location);

            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet GetIncidentTotalsByDealership(DateTime? dtBegin, DateTime? dtEnd, string strFK_LU_Location)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("rptIncidentTotalsByDealership");
            db.AddInParameter(dbCommand, "Begin_Date", DbType.DateTime, dtBegin);
            db.AddInParameter(dbCommand, "End_Date", DbType.DateTime, dtEnd);
            db.AddInParameter(dbCommand, "strFK_LU_Location", DbType.String, strFK_LU_Location);

            return db.ExecuteDataSet(dbCommand);
        }

        public static string GetCommaSepratedDBAFromIDs(string strFK_LU_Location_IDs)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("GetCommaSepratedDBAFromIDs");
            db.AddInParameter(dbCommand, "PK_LU_Location_IDs", DbType.String, strFK_LU_Location_IDs);

            DataSet ds = db.ExecuteDataSet(dbCommand);

            return Convert.ToString(ds.Tables[0].Rows[0][0]);
        }

        #endregion

        #region " Dashboard Reports "

        public static DataSet GetIncidentInvestigationReport(string strRegion, int intYear, string strInterval, decimal FK_Security_Id)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("rptIncidentInvestigation");
            db.AddInParameter(dbCommand, "Region", DbType.String, strRegion);
            db.AddInParameter(dbCommand, "Year", DbType.Int32, intYear);
            db.AddInParameter(dbCommand, "strInterval", DbType.String, strInterval);
            db.AddInParameter(dbCommand, "Pk_Security_ID", DbType.Decimal, FK_Security_Id);

            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet GetIncidentReductionReport(string strRegion, int intYear, string strInterval, decimal FK_Security_Id)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("rptIncidentReduction");
            db.AddInParameter(dbCommand, "Region", DbType.String, strRegion);
            db.AddInParameter(dbCommand, "Year", DbType.Int32, intYear);
            db.AddInParameter(dbCommand, "strInterval", DbType.String, strInterval);
            db.AddInParameter(dbCommand, "Pk_Security_ID", DbType.Decimal, FK_Security_Id);

            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet GetWCClaimManagementReport(string strRegion, int intYear, string strInterval, decimal FK_Security_Id)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("rptWCClaimManagement");
            db.AddInParameter(dbCommand, "Region", DbType.String, strRegion);
            db.AddInParameter(dbCommand, "Year", DbType.Int32, intYear);
            db.AddInParameter(dbCommand, "strInterval", DbType.String, strInterval);
            db.AddInParameter(dbCommand, "Pk_Security_ID", DbType.Decimal, FK_Security_Id);

            return db.ExecuteDataSet(dbCommand);
        }
        public static DataSet GetSafertyFirstAwardReport(string strRegion, int Year, decimal FK_Security_Id)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("SafertyFirstAwardReport");

            db.AddInParameter(dbCommand, "Pk_Security_ID", DbType.Decimal,FK_Security_Id);
            db.AddInParameter(dbCommand, "Regions", DbType.String, strRegion);
            db.AddInParameter(dbCommand, "Year", DbType.Int32, Year);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// select Comma seperated Accident Year
        /// </summary>
        /// <param name="strSelectedYear"></param>
        /// <returns></returns>
        public static string FillAccidentYear(string strSelectedYear)
        {
            if (!string.IsNullOrEmpty(strSelectedYear))
                return strSelectedYear;
            int intMinYear, intMaxYear;
            string strYear = SelectMinAccidentYear().Trim();
            if (strYear.Trim() != "")
            {
                intMinYear = Convert.ToInt32(strYear);
                intMaxYear = DateTime.Now.Year;

                for (int i = intMaxYear; i >= intMinYear; i--)
                {
                    strSelectedYear += i.ToString() + ", ";
                }
                strSelectedYear = strSelectedYear.TrimEnd(',');
            }
            return strSelectedYear;
        }

        /// <summary>
        /// Deletes a record from the Claim table by a composite primary key.
        /// </summary>
        public static string SelectMinAccidentYear()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("GetMinLossYear");

            string strYear = Convert.ToString(db.ExecuteScalar(dbCommand));

            return strYear;
        }

        #endregion

        #region " Date Where "

        /// <summary>
        /// function which return Relative date for Current date based on RaltiveDates Criteria
        /// </summary>
        /// <param name="RelDateType"></param>
        /// <returns></returns>
        public static DateTime GetRelativeDate(string RelDateType)
        {
            DateTime dtReturn = DateTime.Now;

            // Check Relative Date Criteria
            if (RelDateType == "8")
                return dtReturn;
            else if (RelDateType == "2")
                dtReturn = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            else if (RelDateType == "6")
                dtReturn = new DateTime(DateTime.Today.Year, 1, 1);
            else if (RelDateType == "0")
                dtReturn = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1).AddMonths(-1);
            else if (RelDateType == "4")
                dtReturn = new DateTime(DateTime.Today.AddYears(-1).Year, 1, 1);
            else if (RelDateType == "3")
                dtReturn = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.DaysInMonth(DateTime.Today.Year, DateTime.Today.Month));
            else if (RelDateType == "7")
                dtReturn = new DateTime(DateTime.Today.AddYears(1).Year, 1, 1).AddDays(-1);
            else if (RelDateType == "1")
                dtReturn = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1).AddDays(-1);
            else if (RelDateType == "5")
                dtReturn = new DateTime(DateTime.Today.Year, 1, 1).AddDays(-1);

            return dtReturn;
        }

        /// <summary>
        /// function return where query for passed Field name for relative date from and To criteria
        /// </summary>
        /// <param name="DateFieldName"></param>
        /// <param name="FromRelDate"></param>
        /// <param name="ToRelDate"></param>
        /// <param name="DateCriteria"></param>
        /// <returns></returns>
        public static string GetDateWhereAbsolute(string DateFieldName, DateTime? FromDate, DateTime? ToDate, string DateCriteria)
        {
            string strWhere = string.Empty;

            // Cast Date time field for remove time from date
            DateFieldName = "CAST(CONVERT(VARCHAR," + DateFieldName + " ,102) as DATETIME)";

            if (DateCriteria == "O" && FromDate.HasValue)
                strWhere = " AND " + DateFieldName + " = CAST('" + FromDate.Value.ToString(eRIMS_Sonic_ReportScheduler.DateDisplayFormat) + "' as DATETIME)";
            else if (DateCriteria == "BF" && FromDate.HasValue)
                strWhere = " AND " + DateFieldName + " <= CAST('" + FromDate.Value.ToString(eRIMS_Sonic_ReportScheduler.DateDisplayFormat) + "' as DATETIME)";
            else if (DateCriteria == "A" && FromDate.HasValue)
                strWhere = " AND " + DateFieldName + " >= CAST('" + FromDate.Value.ToString(eRIMS_Sonic_ReportScheduler.DateDisplayFormat) + "' as DATETIME)";
            else if (DateCriteria == "B")
            {
                if (FromDate.HasValue)
                    strWhere = " AND " + DateFieldName + " >= CAST('" + FromDate.Value.ToString(eRIMS_Sonic_ReportScheduler.DateDisplayFormat) + "' as DATETIME)";

                // if to date is passed and then add and condition for between
                if (ToDate.HasValue)
                    strWhere += " AND " + DateFieldName + " <= CAST('" + ToDate.Value.ToString(eRIMS_Sonic_ReportScheduler.DateDisplayFormat) + "' as DATETIME)";
            }

            return strWhere;
        }

        /// <summary>
        /// function return where query for passed Field name for relative date from and To criteria
        /// </summary>
        /// <param name="DateFieldName"></param>
        /// <param name="FromRelDate"></param>
        /// <param name="ToRelDate"></param>
        /// <param name="DateCriteria"></param>
        /// <returns></returns>
        public static string GetDateWhere(string DateFieldName, string FromRelDate, string ToRelDate, string DateCriteria)
        {
            DateTime dtFromDate = GetRelativeDate(FromRelDate);
            DateTime? dtToDate = null;

            if (string.IsNullOrEmpty(ToRelDate))
                dtToDate = GetRelativeDate(ToRelDate);

            return GetDateWhereAbsolute(DateFieldName, dtFromDate, dtToDate, DateCriteria);
        }

        public static DataSet GetUserAccessForAdHocReport(decimal UserID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("GetUserAccessForAdHocReport");

            db.AddInParameter(dbCommand, "User_ID", DbType.Decimal, UserID);

            return db.ExecuteDataSet(dbCommand);
        }
        #endregion
    }
}
