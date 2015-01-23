using System;
using System.Configuration;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.ServiceProcess;
using System.Text;
using System.IO;
using System.Net.Mail;
using System.Threading;
using ERIMS_DAL;

namespace ERIMS_Sonic_ReportScheduler
{
    //*****************************************************//
    // This is a window service to send the scheduled report 
    // Report will be sent to the recipient selected while scheduling
    // Service is continuously running on system and invoke function
    // to send report everyday at the 12:01 AM
    //*****************************************************//
    partial class eRIMS_Sonic_ReportScheduler : ServiceBase
    {
        #region Public Variables
        private const string FirstMonthName = "Jan";
        private const string LastMonthName = "Dec";
        //flag to check status of mail for today is sent or not
        bool flgSendEmail = true;

        //Report schedule on this date will be send.
        DateTime dtSchduleDate = DateTime.Today;

        //Date time format to display in attached excel with Email
        public const String DateDisplayFormat = "MM/dd/yyyy";

        #endregion

        #region Private enum Variable
        private enum DashboardReport
        {
            Facility_Inspection = 1,
            Incident_Investigation = 2,
            Incident_Reduction = 3,
            WC_Claim_Management = 4
        }
        #endregion

        #region Constructor
        public eRIMS_Sonic_ReportScheduler()
        {
            InitializeComponent();
        }
        #endregion

        #region Events
        /// <summary>
        /// Being Executed when Scheduler service starts
        /// </summary>
        /// <param name="args"></param>
        protected override void OnStart(string[] args)
        {
            // TODO: Add code here to start your service.

            //Make event log entry to indicate starting of service
            EventLog.WriteEntry("eRIMS_Sonic Report Scheduler Started At : " + DateTime.Now.ToString());

            //Create a thread for the function which send email
            Thread TSendMail = default(Thread);
            TSendMail = new System.Threading.Thread(SendReportAsAttachment);

            //Start the thread
            TSendMail.Start();
            TSendMail.CurrentCulture = new System.Globalization.CultureInfo("en-US");
        }

        //public void OnStart()
        //{
        //    // TODO: Add code here to start your service.

        //    //Make event log entry to indicate starting of service
        //    EventLog.WriteEntry("eRIMS_Sonic Report Scheduler Started At : " + DateTime.Now.ToString());

        //    //Create a thread for the function which send email
        //    Thread TSendMail = default(Thread);
        //    TSendMail = new System.Threading.Thread(SendReportAsAttachment);

        //    //Start the thread
        //    TSendMail.Start();
        //    TSendMail.CurrentCulture = new System.Globalization.CultureInfo("en-US");
        //}

        /// <summary>
        /// Being Executed when Scheduler service stops
        /// </summary>
        protected override void OnStop()
        {
            // TODO: Add code here to perform any tear-down necessary to stop your service.
        }

        #endregion

        #region Private Methods
        /// <summary>
        /// Main Function which contains infinite loop and send report when date changed
        /// </summary>
        public void SendReportAsAttachment()
        {
            Thread.Sleep(15000);
            //Thread.Sleep(3600000);
            while (true)
            {
                object objMailSending = ConfigurationManager.AppSettings.Get("AllowMailSending");
                bool _bAllowMailSending = false;
                bool bOutMail;
                if (bool.TryParse(Convert.ToString(objMailSending), out bOutMail))
                    _bAllowMailSending = bOutMail;
                else
                    _bAllowMailSending = false;

                //Check send mail status for today
                if (flgSendEmail && _bAllowMailSending)
                {
                    EventLog.WriteEntry("Total No of Database Connection String Found : " + ConfigurationManager.ConnectionStrings.Count.ToString());
                    for (int i = 1; i < ConfigurationManager.ConnectionStrings.Count; i++)
                    {
                        Report.strConn = ConfigurationManager.ConnectionStrings[i].ConnectionString;
                        //Send report for the schedule date
                        SendReports();
                    }
                    flgSendEmail = false;
                }

                //Stop Process For 1 Hour to reduce CPU Utilization
                //Thread.Sleep(300000);
                Thread.Sleep(3600000);

                //if date changes set schedule date to today's date(new schedule date)
                if (dtSchduleDate.Date < DateTime.Today.Date)
                {
                    dtSchduleDate = DateTime.Today;
                    flgSendEmail = true;
                }
            }
        }

        /// <summary>
        /// Sub function to get the scheduled report and send as per report type(report number)
        /// </summary>
        private void SendReports()
        {
            try
            {
                //Fetch All scheduled report for the specified schedule date
                DataTable dtScheduleReports = Report.GetScheduleReports(dtSchduleDate);

                //Send Each report as per report type
                for (int i = 0; i < dtScheduleReports.Rows.Count; i++)
                {
                    switch (Convert.ToInt32(dtScheduleReports.Rows[i]["FK_Report"]))
                    {
                        case 1:
                            BindFinancialSummaryReport(dtScheduleReports.Rows[i]);
                            break;
                        case 2:
                            BindFinancialPayTypeSummaryReport(dtScheduleReports.Rows[i]);
                            break;
                        case 3:
                            BindEmployerLagSummaryReport(dtScheduleReports.Rows[i]);
                            break;
                        case 4:
                            BindInsurerLagSummaryReport(dtScheduleReports.Rows[i]);
                            break;
                        case 5:
                            BindCompletionLagSummaryReport(dtScheduleReports.Rows[i]);
                            break;
                        case 6:
                            BindFreqencyAnalysisReport(dtScheduleReports.Rows[i]);
                            break;
                        case 7:
                            BindWCCauseAnalysisReport(dtScheduleReports.Rows[i]);
                            break;
                        case 8:
                            BindLossLimitationReport(dtScheduleReports.Rows[i]);
                            break;
                        case 9:
                            BindLossStratificationReport(dtScheduleReports.Rows[i]);
                            break;
                        case 10:
                            BindDetailPITReport(dtScheduleReports.Rows[i]);
                            break;
                        case 11:
                            BindTPALagSummaryReport(dtScheduleReports.Rows[i]);
                            break;
                        case 12:
                            BindSummaryPITReport(dtScheduleReports.Rows[i]);
                            break;
                        case 13:
                            BindThreePITSummaryReport(dtScheduleReports.Rows[i]);
                            break;
                        case 14:
                            BindBordereauReport(dtScheduleReports.Rows[i]);
                            break;
                        case 15:
                            BindNotif_BordereauReport(dtScheduleReports.Rows[i]);
                            break;
                        case 16:
                            BindEPLIPendingInvestigationandLitigationSummaryReport(dtScheduleReports.Rows[i]);
                            break;
                        case 17:
                            BindImmediatelyReportableClaims(dtScheduleReports.Rows[i]);
                            break;
                        case 18:
                            BindNetworkCallSummaryReport(dtScheduleReports.Rows[i]);
                            break;
                        case 19:
                            BindWCAllocationDetailReport(dtScheduleReports.Rows[i]);
                            break;
                        case 20:
                            BindWCAllocationSummaryReport(dtScheduleReports.Rows[i]);
                            break;
                        case 21:
                            BindWCAllocationLocationReport(dtScheduleReports.Rows[i]);
                            break;
                        case 22:
                            BindWCAllocationMonthlyDetailReport(dtScheduleReports.Rows[i]);
                            break;
                        case 23:
                            BindWCMonthlyAllocationSummaryReport(dtScheduleReports.Rows[i]);
                            break;
                        case 24:
                            BindPurchaseServiceContractDetailReport(dtScheduleReports.Rows[i]);
                            break;
                        case 25:
                            BindLeaseRentalAgreementDetailReport(dtScheduleReports.Rows[i]);
                            break;
                        case 26:
                            BindPurchaseAssetReport(dtScheduleReports.Rows[i]);
                            break;
                        case 27:
                            BindLeaseDetailReport(dtScheduleReports.Rows[i]);
                            break;
                        case 28:
                            BindRentProjectionsHistoryReport(dtScheduleReports.Rows[i]);
                            break;
                        case 29:
                            BindLeaseTerm(dtScheduleReports.Rows[i]);
                            break;
                        case 30:
                            BindSubspacesByLocation(dtScheduleReports.Rows[i]);
                            break;
                        case 31:
                            BindRentableAreaByExpirationDate(dtScheduleReports.Rows[i]);
                            break;
                        case 32:
                            BindMonthlyExpenseByLocation(dtScheduleReports.Rows[i]);
                            break;
                        case 33:
                            BindLeasesWithSecurityDeposit(dtScheduleReports.Rows[i]);
                            break;
                        case 34:
                            BindLandlordReport(dtScheduleReports.Rows[i]);
                            break;
                        case 35:
                            BindMaintenanceReport(dtScheduleReports.Rows[i]);
                            break;
                        case 36:
                            BindWCAllocationYTDCharge(dtScheduleReports.Rows[i]);
                            break;
                        case 37:
                            BindExposuresPropertyStatementofValue(dtScheduleReports.Rows[i]);
                            break;
                        case 38:
                            BindLeaseReport(dtScheduleReports.Rows[i]);
                            break;
                        case 39:
                            BindMasterDealership(dtScheduleReports.Rows[i]);
                            break;
                        case 40:
                            BindLandlordInfoReport(dtScheduleReports.Rows[i]);
                            break;
                        case 41:
                            BindPolicyInsuranceScheduleReport(dtScheduleReports.Rows[i]);
                            break;
                        case 42:
                            BindExp_ThirdPartyOwnedReport(dtScheduleReports.Rows[i]);
                            break;
                        case 43:
                            BindFacilityInspectionReport(dtScheduleReports.Rows[i]);
                            break;
                        case 44:
                            BindCustomerIncidentSummaryReport(dtScheduleReports.Rows[i]);
                            break;
                        case 45:
                            BindNonCustomerInquirySummaryReport(dtScheduleReports.Rows[i]);
                            break;
                        case 46:
                            BindCustomerIncidentTotalsReport(dtScheduleReports.Rows[i]);
                            break;
                        case 47:
                            BindDashboardReport(DashboardReport.Facility_Inspection, dtScheduleReports.Rows[i], 47);
                            break;
                        case 48:
                            BindDashboardReport(DashboardReport.Incident_Investigation, dtScheduleReports.Rows[i], 48);
                            break;
                        case 49:
                            BindDashboardReport(DashboardReport.Incident_Reduction, dtScheduleReports.Rows[i], 49);
                            break;
                        case 50:
                            BindDashboardReport(DashboardReport.WC_Claim_Management, dtScheduleReports.Rows[i], 50);
                            break;
                        case 51:
                            BindCriticalDatesReport(dtScheduleReports.Rows[i]);
                            break;
                        case 52:
                            BindSubLeaseReport(dtScheduleReports.Rows[i]);
                            break;
                        case 53:
                            BindSonicCauseCodeReclassificationReport(dtScheduleReports.Rows[i]);
                            break;
                        case 54:
                            BindSafetyFirstAwardReport(dtScheduleReports.Rows[i]);
                            break;
                        case 55:
                            BindLandlordNotificationReport(dtScheduleReports.Rows[i]);
                            break;
                        case 56:
                            BindInpectionsByInspector(dtScheduleReports.Rows[i]);
                            break;
                        case 57:
                            BindRiskManagementWorkSheet(dtScheduleReports.Rows[i]);
                            break;
                        case 59:
                            BindInspectionLagTime(dtScheduleReports.Rows[i]);
                            break;
                        case 60:
                            BindAdHocReportWriter(dtScheduleReports.Rows[i]);
                            break;
                        case 62:
                            BindFROIRecapReport(dtScheduleReports.Rows[i]);
                            break;
                        default:
                            break;
                    }
                }
                //Make evenlog entry on successful completion of sending mail.
                EventLog.WriteEntry("eRIMS_Sonic Scheduled Reports sent successfully on " + dtSchduleDate.ToString());
            }
            catch (Exception ex)
            {
                //write exception to event log
                EventLog.WriteEntry("Error Occured while sending eRIMS_Sonic Scheduled Reports on " + dtSchduleDate.ToString() + ", " + ex.Message);
            }
        }


        private void BindAdHocReportWriter(DataRow drReportSchedule)
        //private void BindAdHocReportWriter()
        {
            //Commented this section due to errors on 22-9-2014
            //IDataReader Reader = null;
            //try
            //{
            //    decimal pK_Schedule_ID = Convert.ToDecimal(drReportSchedule["PK_Schedule"]);
            //    decimal Fk_RecipientList = Convert.ToDecimal(drReportSchedule["Fk_RecipientList"]);
            //    decimal FK_Security_Id = Convert.ToDecimal(drReportSchedule["FK_Security_Id"]);
            //    string strReportSchedulerName = Convert.ToString(drReportSchedule["ReportSchedulerName"]);
            //    //decimal pK_Schedule_ID = 6;
            //    //decimal Fk_RecipientList = 2;
            //    //decimal FK_Security_Id = 1;
            //    //string strReportSchedulerName = "test";
            //    //Get Report criteria for the scheduled report
            //    DataSet ds = new DataSet();
            //    ds = Report.SelectFilterCriteria(60, pK_Schedule_ID);
            //    if (ds != null && ds.Tables[0].Rows.Count > 0)
            //    {
            //        DataTable dtFilter = ds.Tables[0];
            //        if (dtFilter.Rows.Count > 0)
            //        {
            //            string strCoverageType = string.Empty, strOutPutFields = string.Empty, strFirstGroupBy = string.Empty, strSecGroupBy = string.Empty;
            //            DateTime? dtPriorValuationDate = null;

            //            if (!string.IsNullOrEmpty(Convert.ToString(dtFilter.Rows[0]["PriorValuationDate"])))
            //                dtPriorValuationDate = Convert.ToDateTime(dtFilter.Rows[0]["PriorValuationDate"]);

            //            if (!string.IsNullOrEmpty(Convert.ToString(dtFilter.Rows[0]["PriorValuation_RelativeDate"])))
            //            {
            //                // set Relative Date From criteria
            //                AdHocReportHelper.RaltiveDates RelType = (AdHocReportHelper.RaltiveDates)Enum.Parse(typeof(AdHocReportHelper.RaltiveDates), Convert.ToString(dtFilter.Rows[0]["PriorValuation_RelativeDate"]));
            //                dtPriorValuationDate = AdHocReportHelper.GetRelativeDate(RelType);
            //            }

            //            decimal _dcSelectedReport = 0;

            //            List<AdHocFilter> lstFilter = new List<AdHocFilter>();

            //            _dcSelectedReport = Convert.ToDecimal(dtFilter.Rows[0]["Pk_AdHocReport"]);
            //            lstFilter = new ERIMS_DAL.AdHocFilter().GetAdHocReportFieldByPk(_dcSelectedReport);

            //            ERIMS_DAL.AdHocReport ObjAdHocReport = new ERIMS_DAL.AdHocReport(_dcSelectedReport);

            //            strOutPutFields = ObjAdHocReport.OutputFields;
            //            string strFilterIDs = string.Empty;
            //            for (int i = 0; i < lstFilter.Count; i++)
            //            {
            //                AdhocReportFields obj = new AdhocReportFields();
            //                List<AdhocReportFields> lstAdhoc = obj.GetAdHocReportFieldByPk(Convert.ToDecimal(lstFilter[i].FK_AdHocReportFields));
            //                strFilterIDs += lstFilter[i].FK_AdHocReportFields + ",";
            //            }
            //            strFilterIDs = strFilterIDs.TrimEnd(',');

            //            StringBuilder sbRecord = new StringBuilder();
            //            if (dtFilter.Rows.Count > 0)
            //            {
            //                //Get the recipient from the recipient list 
            //                DataTable dtRecipients = Report.SelectOneRecordWithRecipientList(Fk_RecipientList).Tables[0];
            //                DataRow drFilterCriteria = dtFilter.Rows[0];
            //                //Get the user who has scheduled the report
            //                DataTable dtUser = Report.SelectSecurityByPK(FK_Security_Id).Tables[0];

            //                String strFirstName, strLastName, strMailFrom;
            //                strFirstName = strLastName = strMailFrom = "";
            //                if (dtUser.Rows.Count > 0)
            //                {
            //                    strFirstName = Convert.ToString(dtUser.Rows[0]["FIRST_NAME"]).Trim();
            //                    strLastName = Convert.ToString(dtUser.Rows[0]["LAST_NAME"]).Trim();
            //                    strMailFrom = Convert.ToString(dtUser.Rows[0]["Email"]).Trim();
            //                }
            //                //Get Records in Reader
            //                Reader = AdHocReportHelper.GetAdHocReport(strOutPutFields, BindGroupBy(ObjAdHocReport), dtPriorValuationDate, GetWhereCondition(lstFilter), BindOrderBy(ObjAdHocReport), strFilterIDs, FK_Security_Id, true);
            //                //Get File path where Records Save.
            //                string strFilePath = BindReport(ref sbRecord, Reader, ObjAdHocReport, lstFilter, strReportSchedulerName);

            //                //If records found
            //                if (File.Exists(strFilePath))
            //                {
            //                    try
            //                    {
            //                        SendMail(strReportSchedulerName, strReportSchedulerName + ".xls", strFirstName, strLastName, strMailFrom, strFilePath, dtRecipients, FK_Security_Id);
            //                        ErrorLog.WriteLog("eRIMS_ACI Scheduled Reports Sent successfully scheduled on " + dtSchduleDate.ToString(), _strFolderPath, false);
            //                    }
            //                    catch (Exception ex)
            //                    {
            //                        ErrorLog.WriteLog("Error Occurred while sending eRIMS_ACI Scheduled Reports on " + dtSchduleDate.ToString() + ", " + ex.Message, _strFolderPath, true);
            //                    }
            //                    finally
            //                    {
            //                        dtRecipients.Dispose();
            //                        dtUser.Dispose();
            //                    }
            //                }
            //            }
            //        }
            //    }
            //}

            //catch (Exception ex)
            //{
            //    ErrorLog.WriteLog("Error Occurred while sending eRIMS_Sonic ACI Scheduled Reports on " + dtSchduleDate.ToString() + ", " + ex.Message, _strFolderPath, true);
            //}
        }

        /// <summary>
        /// get claim type description from the initial claim type
        /// </summary>
        /// <param name="strClaimType"></param>
        /// <returns></returns>
        private String GetClaimTypeDescription(String strClaimType)
        {
            switch (strClaimType.ToUpper())
            {
                case "W":
                    return "Workers Compensation";
                case "A":
                    return "Auto Loss";
                case "P":
                    return "Premises Loss";
                default:
                    return String.Empty;
            }
        }

        /// <summary>
        /// Get the Claim type string to display in filter setting for all claims
        /// </summary>
        /// <param name="strClaimTypes"></param>
        /// <returns></returns>
        private String GetClaimTypeString(String strClaimTypes)
        {
            return strClaimTypes.Replace("W", "Workers Compensation").Replace("A", "Auto Loss").Replace("P", "Premises Loss");
        }

        /// <summary>
        ///  Generates report HTML as a string- Being called from BindDashboardReport
        /// </summary>
        /// <param name="drReportSchedule"></param>
        /// <param name="dtFilter"></param>
        /// <param name="FK_Security_Id"></param>
        /// <param name="objRptDashboard"></param>
        /// <returns></returns>
        private StringBuilder GetDashboardReportText(DataRow drReportSchedule, DataTable dtFilter, decimal FK_Security_Id, DashboardReport objRptDashboard)
        {
            string strRegion = Convert.ToString(dtFilter.Rows[0]["Region"]).Trim();
            string strMarket = null;
            if (!string.IsNullOrEmpty(Convert.ToString(dtFilter.Rows[0]["Market"])))
            {
                strMarket = Convert.ToString(dtFilter.Rows[0]["Market"]).Trim();
            }
            string strYear = Convert.ToString(dtFilter.Rows[0]["Year"]).Trim();
            string strReportInterval = Convert.ToString(dtFilter.Rows[0]["Report_Interval"]).Trim();

            //Create HTML for the report and write into HTML Write object
            StringBuilder strHTML = new StringBuilder();


            string strReportTitle = "";
            string strGridHeader = "";

            switch (objRptDashboard)
            {
                case DashboardReport.Facility_Inspection:
                    strReportTitle = "Facility Inspection";
                    strGridHeader = strReportTitle.ToUpper();
                    break;
                case DashboardReport.Incident_Investigation:
                    strReportTitle = "Incident Investigation";
                    strGridHeader = strReportTitle.ToUpper();
                    break;
                case DashboardReport.Incident_Reduction:
                    strReportTitle = "Incident Reduction";
                    strGridHeader = strReportTitle.ToUpper();
                    break;
                case DashboardReport.WC_Claim_Management:
                    strReportTitle = "Worker's Compensation Claims Management";
                    strGridHeader = strReportTitle;
                    break;
            }

            #region "Report Title"

            //Retrieve Market Values
            string strMarketString = string.Empty;
            if (string.IsNullOrEmpty(strMarket))
            {
                strMarketString = "All Market";
            }
            else
            {
                string[] strMar = strMarket.Split(Convert.ToChar(","));
                for (int i = 0; i < strMar.Length; i++)
                {
                    strMarketString += Report.SelectMarketInfoById(Convert.ToDecimal(strMar[i].ToString())).Tables[0].Rows[0]["Market"].ToString() + ",";
                }
                strMarketString = strMarketString.TrimEnd(',');
            }

            //Add Report Title and Schedule Date
            strHTML.Append("<br />");
            strHTML.Append("<b>Report Title : " + strReportTitle + " </b>");
            strHTML.Append("<br /><br />");
            strHTML.Append("Schedule Date : " + Convert.ToDateTime(drReportSchedule["Scheduled_Date"]).ToString(DateDisplayFormat));
            strHTML.Append("&nbsp;&nbsp;&nbsp;&nbsp;Schedule End Date : " + Convert.ToDateTime(drReportSchedule["Schedule_End_Date"]).ToString(DateDisplayFormat));
            strHTML.Append("<br />");
            strHTML.Append("Recurring Period : " + drReportSchedule["Recurring_Period"].ToString());
            strHTML.Append("<br />");
            strHTML.Append("Recurring Date : " + dtSchduleDate.ToString(DateDisplayFormat));

            //Add Report Filter Criteria 
            strHTML.Append("<br /><br /><table> <tr> <td>");
            strHTML.Append("<b>Report Filters </b>");
            strHTML.Append("<br /><table> <tr> <td colspan='8'>");
            strHTML.Append("Report Interval   : " + strReportInterval);
            strHTML.Append("</td> </tr>");
            strHTML.Append("<tr> <td colspan='8'>");
            strHTML.Append("Year   : " + strYear);
            strHTML.Append("</td> </tr>");
            strHTML.Append("<tr> <td colspan='8'>");
            strHTML.Append("Region   : " + strRegion);
            strHTML.Append("</td> </tr>");
            strHTML.Append("<tr> <td colspan='8'>");
            strHTML.Append("Market        : " + strMarketString);
            strHTML.Append("</td> </tr>");
            strHTML.Append("<tr> <td colspan='8'>");
            strHTML.Append("</td></tr></table> ");

            #endregion

            #region "Report Data"
            //Monthly Report
            DataSet dsReport = null;

            if (objRptDashboard == DashboardReport.Facility_Inspection)
                dsReport = Report.GetFacilityInspectionReport(strRegion, strMarket, Convert.ToInt32(strYear), strReportInterval, FK_Security_Id);
            else if (objRptDashboard == DashboardReport.Incident_Investigation)
                dsReport = Report.GetIncidentInvestigationReport(strRegion, strMarket, Convert.ToInt32(strYear), strReportInterval, FK_Security_Id);
            else if (objRptDashboard == DashboardReport.Incident_Reduction)
                dsReport = Report.GetIncidentReductionReport(strRegion, strMarket, Convert.ToInt32(strYear), strReportInterval, FK_Security_Id);
            else if (objRptDashboard == DashboardReport.WC_Claim_Management)
                dsReport = Report.GetWCClaimManagementReport(strRegion, strMarket, Convert.ToInt32(strYear), strReportInterval, FK_Security_Id);

            if (strReportInterval.ToString() == "Monthly")
            {
                #region " MONTHLY "
                if (dsReport != null && dsReport.Tables.Count > 0 && dsReport.Tables[0].Rows.Count > 0)
                {
                    // get data tables from dataset
                    DataTable dtRegions = dsReport.Tables[0];

                    strHTML.Append("<table border='1' style='border: black 0.5px solid;border-collapse: collapse;' cellpadding='0' cellspacing='0'  Width='100%px'><tr><td>");

                    strHTML.Append("<table border='1' style='padding-left:4px;font-size:8.5pt;font-family:Tahoma' cellpadding='4' cellspacing='0' Width='1980px'>");//Sub Table
                    strHTML.Append("<tr style='font-weight: bold;font-size:11pt;height:25'>"); //Title
                    strHTML.Append("<td align='left' style='font-size:9pt;' colspan='2'><b>Sonic Automotive</b></td>");
                    strHTML.Append("<td align='center' style='font-size:9pt;' colspan='9' ><b> " + strGridHeader + " - MONTHLY REPORT FOR " + strYear + " </b></td>");
                    strHTML.Append("<td style='font-size:9pt' align='right' colspan='4'>Valuation Date: " + DateTime.Now.ToString("MM/dd/yyy HH:mm tt") + "</td></tr>");

                    strHTML.Append("<tr align='left' border='1' style='border: black 0.5px solid;'>");
                    strHTML.Append("<td  width='180px'><b>REGION</b></td>");
                    strHTML.Append("<td  width='230px'><b>STORE</b></td>");
                    strHTML.Append("<td  width='120px'><b>JANUARY</b></td>");
                    strHTML.Append("<td  width='120px'><b>FEBRUARY</b></td>");
                    strHTML.Append("<td  width='120px'><b>MARCH</b></td>");
                    strHTML.Append("<td  width='120px'><b>APRIL</b></td>");
                    strHTML.Append("<td  width='120px'><b>MAY</b></td>");
                    strHTML.Append("<td  width='120px'><b>JUNE</b></td>");
                    strHTML.Append("<td  width='120px'><b>JULY</b></td>");
                    strHTML.Append("<td  width='120px'><b>AUGUST</b></td>");
                    strHTML.Append("<td  width='120px'><b>SEPTEMBER</b></td>");
                    strHTML.Append("<td  width='120px'><b>OCTOBER</b></td>");
                    strHTML.Append("<td  width='120px'><b>NOVEMBER</b></td>");
                    strHTML.Append("<td  width='120px'><b>DECEMBER</b></td>");
                    strHTML.Append("<td  width='130px'><b>AVERAGE SCORE</b></td>");
                    strHTML.Append("</tr>");
                    for (int intI3 = 0; intI3 < dtRegions.Rows.Count; intI3++)
                    {
                        DataRow drRecords = dtRegions.Rows[intI3];
                        //int intRes;
                        //int intDiv = System.Math.DivRem(intI3, 2, out intRes);
                        //if (intRes == 0)
                        //strHTML.Append("<tr align='left' style='font-size:8pt;background-color:#EAEAEA;font-family:Tahoma;'>");
                        // else
                        strHTML.Append("<tr align='left' style='font-size:8pt;border: black 0.5px solid;' border='1'>");

                        strHTML.Append("<td  align='left' >" + Convert.ToString(drRecords["Region"]) + "</td>");
                        strHTML.Append("<td  align='left'>" + Convert.ToString(drRecords["DBA"]) + "</td>");
                        strHTML.Append("<td  align='left'>" + GetScoreName(drRecords["JANUARY"]) + "</td>");
                        strHTML.Append("<td  align='left'>" + GetScoreName(drRecords["FEBRUARY"]) + "</td>");
                        strHTML.Append("<td  align='left'>" + GetScoreName(drRecords["MARCH"]) + "</td>");
                        strHTML.Append("<td  align='left'>" + GetScoreName(drRecords["APRIL"]) + "</td>");
                        strHTML.Append("<td  align='left'>" + GetScoreName(drRecords["MAY"]) + "</td>");
                        strHTML.Append("<td  align='left'>" + GetScoreName(drRecords["JUNE"]) + "</td>");
                        strHTML.Append("<td  align='left'>" + GetScoreName(drRecords["JULY"]) + "</td>");
                        strHTML.Append("<td  align='left'>" + GetScoreName(drRecords["AUGUST"]) + "</td>");
                        strHTML.Append("<td  align='left'>" + GetScoreName(drRecords["SEPTEMBER"]) + "</td>");
                        strHTML.Append("<td  align='left'>" + GetScoreName(drRecords["OCTOBER"]) + "</td>");
                        strHTML.Append("<td  align='left'>" + GetScoreName(drRecords["NOVEMBER"]) + "</td>");
                        strHTML.Append("<td  align='left'>" + GetScoreName(drRecords["DECEMBER"]) + "</td>");
                        strHTML.Append("<td  align='left'>" + GetScoreName(drRecords["Average"]) + "</td>");
                        strHTML.Append("</tr>");
                    }

                    //strHTML.Append("<tr><td colspan='15' class='cols_'>&nbsp;</td></tr>");
                    strHTML.Append("</table>");
                    strHTML.Append("</table>");
                }
                else
                {
                    strHTML.Append("<table style='font-family:Tahoma' cellpadding='4' cellspacing='0' Width='100%'>");
                    strHTML.Append("<tr style='background-color:#F2F2F2;color:Black;'>");
                    strHTML.Append("<td align='center' style='font-size:9pt;'>No Records found.</td></tr></table>");
                }
                #endregion
            }
            else if (strReportInterval.ToString() == "Quarterly")
            {
                #region " QUARTERLY "
                if (dsReport != null && dsReport.Tables.Count > 0 && dsReport.Tables[0].Rows.Count > 0)
                {
                    DataTable dtRegions = dsReport.Tables[0];

                    strHTML.Append("<table border='1' style='border: black 0.5px solid;border-collapse: collapse;' cellpadding='0' cellspacing='0'  Width='100%px'><tr><td>");

                    strHTML.Append("<table border='1' style='padding-left:4px;font-size:8.5pt;font-family:Tahoma' cellpadding='4' cellspacing='0' Width='995px'>");//Sub Table
                    strHTML.Append("<tr style='font-weight: bold;font-size:11pt;height:25'>"); //Title
                    strHTML.Append("<td align='left' style='font-size:9pt;' colspan='1'><b>Sonic Automotive</b></td>");
                    strHTML.Append("<td align='center' style='font-size:9pt;' colspan='3' ><b> " + strGridHeader + " - QUARTERLY REPORT FOR " + strYear + " </b></td>");
                    strHTML.Append("<td style='font-size:9pt' align='right' colspan='3'>Valuation Date: " + DateTime.Now.ToString("MM/dd/yyy HH:mm tt") + "</td></tr>");

                    strHTML.Append("<tr align='left' border='1' style='border: black 0.5px solid;' >");
                    strHTML.Append("<td  width='185px'><b>REGION</b></td>");
                    strHTML.Append("<td  width='220px'><b>STORE</b></td>");
                    strHTML.Append("<td  width='120px'><b>Q1</b></td>");
                    strHTML.Append("<td  width='120px'><b>Q2</b></td>");
                    strHTML.Append("<td  width='120px'><b>Q3</b></td>");
                    strHTML.Append("<td  width='120px'><b>Q4</b></td>");
                    strHTML.Append("<td  width='110px'><b>AVERAGE SCORE</b></td>");
                    strHTML.Append("</tr>");
                    for (int intI3 = 0; intI3 < dtRegions.Rows.Count; intI3++)
                    {
                        DataRow drRecords = dtRegions.Rows[intI3];
                        //int intRes;
                        //int intDiv = System.Math.DivRem(intI3, 2, out intRes);
                        //if (intRes == 0)
                        //    strHTML.Append("<tr align='left' style='font-size:8pt;background-color:#EAEAEA;font-family:Tahoma;'>");
                        //else
                        strHTML.Append("<tr align='left' style='font-size:8pt;border: black 0.5px solid;' border='1'>");

                        strHTML.Append("<td  align='left' >" + Convert.ToString(drRecords["Region"]) + "</td>");
                        strHTML.Append("<td>" + Convert.ToString(drRecords["DBA"]) + "</td>");
                        strHTML.Append("<td align='left'>" + GetScoreName(drRecords["Q1"]) + "</td>");
                        strHTML.Append("<td align='left'>" + GetScoreName(drRecords["Q2"]) + "</td>");
                        strHTML.Append("<td align='left'>" + GetScoreName(drRecords["Q3"]) + "</td>");
                        strHTML.Append("<td align='left'>" + GetScoreName(drRecords["Q4"]) + "</td>");
                        strHTML.Append("<td align='left'>" + GetScoreName(drRecords["Average"]) + "</td>");
                        strHTML.Append("</tr>");
                    }
                    strHTML.Append("</table>");
                    strHTML.Append("</table>");
                }
                else
                {
                    strHTML.Append("<table style='font-family:Tahoma' cellpadding='4' cellspacing='0' Width='100%'>");
                    strHTML.Append("<tr style='background-color:#F2F2F2;color:Black;'>");
                    strHTML.Append("<td align='center' style='font-size:9pt;'>No Records found.</td></tr></table>");
                }
                #endregion
            }
            else if (strReportInterval.ToString() == "Annually")
            {
                #region " ANNUALLY "
                if (dsReport != null && dsReport.Tables.Count > 0 && dsReport.Tables[0].Rows.Count > 0)
                {
                    DataTable dtRegions = dsReport.Tables[0];
                    strHTML.Append("<table border='1' style='border: black 0.5px solid;border-collapse: collapse;' cellpadding='0' cellspacing='0'  Width='100%px'><tr><td>");

                    strHTML.Append("<table border='1' style='padding-left:4px;font-size:8.5pt;font-family:Tahoma' cellpadding='4' cellspacing='0' Width='996px'>");//Sub Table
                    strHTML.Append("<tr style='font-weight: bold;font-size:11pt;height:25'>"); //Title
                    strHTML.Append("<td align='left' style='font-size:9pt;' colspan='1'><b>Sonic Automotive</b></td>");
                    strHTML.Append("<td align='center' style='font-size:9pt;' colspan='4' ><b> " + strGridHeader + " - ANNAUL REPORT FOR " + strYear + " </b></td>");
                    strHTML.Append("<td style='font-size:9pt' align='right' colspan='3'>Valuation Date: " + DateTime.Now.ToString("MM/dd/yyy HH:mm tt") + "</td></tr>");

                    strHTML.Append("<tr align='left' border='1' style='border: black 0.5px solid;'>");
                    strHTML.Append("<td width='180px'><b>REGION</b></td>");
                    strHTML.Append("<td width='230px'><b>STORE</b></td>");
                    strHTML.Append("<td width='120px'><b>" + Convert.ToString(Convert.ToInt32(strYear) - 4) + "</b></td>");
                    strHTML.Append("<td width='120px'><b>" + Convert.ToString(Convert.ToInt32(strYear) - 3) + "</b></td>");
                    strHTML.Append("<td width='120px'><b>" + Convert.ToString(Convert.ToInt32(strYear) - 2) + "</b></td>");
                    strHTML.Append("<td width='120px'><b>" + Convert.ToString(Convert.ToInt32(strYear) - 1) + "</b></td>");
                    strHTML.Append("<td width='120px'><b>" + Convert.ToString(Convert.ToInt32(strYear)) + "</b></td>");
                    strHTML.Append("<td width='110px'><b>AVERAGE SCORE</b></td>");
                    strHTML.Append("</tr>");
                    for (int intI3 = 0; intI3 < dtRegions.Rows.Count; intI3++)
                    {
                        DataRow drRecords = dtRegions.Rows[intI3];
                        //int intRes;
                        //int intDiv = System.Math.DivRem(intI3, 2, out intRes);
                        //if (intRes == 0)
                        //    strHTML.Append("<tr align='left' style='font-size:8pt;background-color:#EAEAEA;font-family:Tahoma;'>");
                        //else
                        strHTML.Append("<tr align='left' style='font-size:8pt;border: black 0.5px solid;' border='1'>");

                        strHTML.Append("<td align='left' >" + Convert.ToString(drRecords["Region"]) + "</td>");
                        strHTML.Append("<td>" + Convert.ToString(drRecords["DBA"]) + "</td>");
                        strHTML.Append("<td align='left'>" + GetScoreName(drRecords["Year1"]) + "</td>");
                        strHTML.Append("<td align='left'>" + GetScoreName(drRecords["Year2"]) + "</td>");
                        strHTML.Append("<td align='left'>" + GetScoreName(drRecords["Year3"]) + "</td>");
                        strHTML.Append("<td align='left'>" + GetScoreName(drRecords["Year4"]) + "</td>");
                        strHTML.Append("<td align='left'>" + GetScoreName(drRecords["Year5"]) + "</td>");
                        strHTML.Append("<td align='left'>" + GetScoreName(drRecords["Average"]) + "</td>");
                        strHTML.Append("</tr>");
                    }
                    // sbRecorords.Append("<tr><td colspan='7' class='cols_'>&nbsp;</td></tr>");
                    strHTML.Append("</table>");
                    // sbRecorords.Append("</div>");
                    strHTML.Append("</table>");
                }
                else
                {
                    strHTML.Append("<table style='font-family:Tahoma' cellpadding='4' cellspacing='0' Width='100%'>");
                    strHTML.Append("<tr style='background-color:#F2F2F2;color:Black;'>");
                    strHTML.Append("<td align='center' style='font-size:9pt;'>No Records found.</td></tr></table>");
                }
                #endregion
            }
            #endregion
            return strHTML;

        }

        /// <summary>
        /// Combines two addresses
        /// </summary>
        /// <param name="objAddress1"></param>
        /// <param name="objAddress2"></param>
        /// <returns></returns>
        public static string FormatAddress(object objAddress1, object objAddress2, object objCity, object objState, object objZipcode)
        {
            string strAddress = string.Empty;
            if (!string.IsNullOrEmpty(Convert.ToString(objAddress1)))
                strAddress = objAddress1.ToString().Trim();
            if (!string.IsNullOrEmpty(Convert.ToString(objAddress2)))
                strAddress = (strAddress != string.Empty) ? string.Concat(strAddress, ",&nbsp;", objAddress2.ToString().Trim()) : objAddress2.ToString().Trim();
            if (!string.IsNullOrEmpty(Convert.ToString(objCity)))
                strAddress = (strAddress != string.Empty) ? string.Concat(strAddress, ",&nbsp;", objCity.ToString().Trim()) : objCity.ToString().Trim();
            if (!string.IsNullOrEmpty(Convert.ToString(objState)))
                strAddress = (strAddress != string.Empty) ? string.Concat(strAddress, ",&nbsp;", objState.ToString().Trim()) : objState.ToString().Trim();
            if (!string.IsNullOrEmpty(Convert.ToString(objZipcode)))
                strAddress = (strAddress != string.Empty) ? string.Concat(strAddress, "&nbsp;", objZipcode.ToString().Trim()) : objZipcode.ToString().Trim();

            return strAddress;
        }
        #endregion

        #region Report Methods

        //Report 1
        private void BindFinancialSummaryReport(DataRow drReportSchedule)
        {
            try
            {
                decimal pK_Schedule_ID = Convert.ToDecimal(drReportSchedule["PK_Schedule"]);
                decimal Fk_RecipientList = Convert.ToDecimal(drReportSchedule["Fk_RecipientList"]);
                decimal FK_Security_Id = Convert.ToDecimal(drReportSchedule["FK_Security_Id"]);

                //Get Report criteria for the scheduled report
                DataTable dtFilter = Report.SelectFilterCriteria(1, pK_Schedule_ID).Tables[0];
                if (dtFilter.Rows.Count > 0)
                {
                    //Get the recipient from the recipient list 
                    DataTable dtRecipients = Report.SelectOneRecordWithRecipientList(Fk_RecipientList).Tables[0];

                    //Get the user who has scheduled the report
                    DataTable dtUser = Report.SelectSecurityByPK(FK_Security_Id).Tables[0];

                    String strFirstName, strLastName, strMailFrom;
                    strFirstName = strLastName = strMailFrom = "";
                    if (dtUser.Rows.Count > 0)
                    {
                        strFirstName = dtUser.Rows[0]["FIRST_NAME"].ToString();
                        strLastName = dtUser.Rows[0]["LAST_NAME"].ToString();
                        strMailFrom = dtUser.Rows[0]["Email"].ToString();

                        //Set all filters to a variable as per report type
                        String strPolicy_Year = dtFilter.Rows[0]["Accident_Year"].ToString();
                        String strClaim_Type = dtFilter.Rows[0]["Claim_Type"].ToString();
                        string strRegion = dtFilter.Rows[0]["Region"].ToString();
                        string strMarket = null;
                        if (!string.IsNullOrEmpty(Convert.ToString(dtFilter.Rows[0]["Market"])))
                        {
                            strMarket = Convert.ToString(dtFilter.Rows[0]["Market"]).Trim();
                        }
                        string strValuationDate = Convert.ToDateTime(dtFilter.Rows[0]["Prior_Valuation_Date"]).ToString(DateDisplayFormat);

                        //Get the report data
                        DataSet dsReport = Report.GetFinancialSummaryData(strPolicy_Year, strClaim_Type, strRegion, strMarket, Convert.ToDateTime(strValuationDate));

                        //Create HTML for the report and wirte into HTML Write object
                        StringBuilder strHTML = new StringBuilder();
                        System.IO.StringWriter stringWrite = new System.IO.StringWriter();
                        System.Web.UI.HtmlTextWriter htmlWrite = new System.Web.UI.HtmlTextWriter(stringWrite);

                        #region "Header"

                        //Retrieve Market Values
                        string strMarketString = string.Empty;
                        if (string.IsNullOrEmpty(strMarket))
                        {
                            strMarketString = "All Market";
                        }
                        else
                        {
                            string[] strMar = strMarket.Split(Convert.ToChar(","));
                            for (int i = 0; i < strMar.Length; i++)
                            {
                                strMarketString += Report.SelectMarketInfoById(Convert.ToDecimal(strMar[i].ToString())).Tables[0].Rows[0]["Market"].ToString() + ",";
                            }
                            strMarketString = strMarketString.TrimEnd(',');
                        }

                        //Add Report Title and Schedule Date
                        strHTML.Append("<br />");
                        strHTML.Append("<b>Report Title : Financial Summary Report</b>");
                        strHTML.Append("<br /><br />");
                        strHTML.Append("Schedule Date : " + Convert.ToDateTime(drReportSchedule["Scheduled_Date"]).ToString(DateDisplayFormat));
                        strHTML.Append("&nbsp;&nbsp;&nbsp;&nbsp;Schedule End Date : " + Convert.ToDateTime(drReportSchedule["Schedule_End_Date"]).ToString(DateDisplayFormat));
                        strHTML.Append("<br />");
                        strHTML.Append("Recurring Period : " + drReportSchedule["Recurring_Period"]).ToString();
                        strHTML.Append("<br />");
                        strHTML.Append("Recurring Date : " + dtSchduleDate.ToString(DateDisplayFormat));

                        //Add Report Filter Criteria 
                        strHTML.Append("<br /><br />");
                        strHTML.Append("<b>Report Filters </b>");
                        strHTML.Append("<br /><br />");
                        strHTML.Append("Accident Year        : " + strPolicy_Year);
                        strHTML.Append("<br />");
                        strHTML.Append("Claim Types          : " + GetClaimTypeString(strClaim_Type));
                        strHTML.Append("<br />");
                        strHTML.Append("Regions              : " + strRegion.Replace("'", ""));
                        strHTML.Append("<br />");
                        strHTML.Append("Market        : " + strMarketString);
                        strHTML.Append("<br /><br />");
                        strHTML.Append("Prior Valuation Date : " + strValuationDate);
                        strHTML.Append("<br /><br />");

                        //Add Header HTML
                        strHTML.Append("<table width='100%' cellpadding='0' cellspacing='0'><tr><td>");
                        strHTML.Append("<table width='100%' cellpadding='0' cellspacing='0'><tr><td>");
                        strHTML.Append("<table width='100%' cellpadding='0' cellspacing='0'><tr><td>");
                        strHTML.Append("<table width='100%' cellpadding='0' cellspacing='0' style='font-weight: bold;' border='1'><tr>");
                        strHTML.Append("<td style='width: 25%;' align='left'>Financial Summary Report</td>");
                        strHTML.Append("<td style='width: 15%;' align='right'>Total Incurred Amount</td>");
                        strHTML.Append("<td style='width: 15%;' align='right'>Total Paid Amount</td>");
                        strHTML.Append("<td style='width: 20%;' align='right'>Total Outstanding Amount</td>");
                        strHTML.Append("<td style='width: 13%;' align='right'>Number Of Claims</td>");
                        strHTML.Append("<td style='width: 12%;' align='right'>Percent<br />Paid/Inc</td>");
                        strHTML.Append("</tr></table>");
                        strHTML.Append("</td></tr></table>");
                        strHTML.Append("</td></tr></table>");
                        strHTML.Append("</td></tr></table>");

                        #endregion
                        // get datatbles from dataset
                        DataTable dtYears = dsReport.Tables[0];
                        DataTable dtDetails = dsReport.Tables[1];
                        DataTable dtRegionTotal = dsReport.Tables[2];
                        DataTable dtGrandTotal = dsReport.Tables[3];

                        if (dtDetails.Rows.Count > 0)
                        {
                            //Add Report Data Table 
                            strHTML.Append("<table style='width: 100%;' border='1' align='left' cellpadding='4' cellspacing='0'>");

                            #region " Report Data "

                            #region " List Accident Years "

                            foreach (DataRow drYear in dtYears.Rows)
                            {
                                //Add Header for Sub Report (Year wise)
                                strHTML.Append("<tr><td width='100%' align='left'>");
                                strHTML.Append("<span style='color: Chocolate; font-weight: bold;'>Accident Year - " + drYear["AccidentYear"].ToString() + "</span>");
                                strHTML.Append("</td></tr><tr><td align='left'>");
                                strHTML.Append("<table cellspacing='0' cellpadding='0' align='Left' border='1' style='width: 100%;border-collapse: collapse;'>");
                                DataRow[] drRegions = dtRegionTotal.Select("AccidentYear='" + drYear["AccidentYear"].ToString() + "'");

                                #region " List Regions "
                                foreach (DataRow drRegion in drRegions)
                                {
                                    strHTML.Append("<tr><td align='left' style='width: 100%;'><table cellpadding='0' cellspacing='0' width='100%'>");
                                    strHTML.Append("<tr><td width='100%' align='left'><b>Region - " + drRegion["Region"].ToString() + "</span></b></td></tr>");
                                    strHTML.Append("<tr><td align='Left'><table style='width: 100%;' border='1' align='left' cellpadding='4' cellspacing='0'>");
                                    DataRow[] drDetails = dtDetails.Select("AccidentYear='" + drYear["AccidentYear"].ToString() + "' and Region='" + drRegion["Region"].ToString() + "'");

                                    #region " Print Claim Details "
                                    foreach (DataRow drDetail in drDetails)
                                    {
                                        strHTML.Append("<tr>");
                                        strHTML.Append("<td align='left' style='width: 25%;'>" + drDetail["dba"].ToString() + "</td>");
                                        strHTML.Append("<td align='right' style='width: 15%;'>" + string.Format("{0:C2}", drDetail["Incurred"]) + "</td>");
                                        strHTML.Append("<td align='right' style='width: 15%;'>" + string.Format("{0:C2}", drDetail["Paid"]) + "</td>");
                                        strHTML.Append("<td align='right' style='width: 20%;'>" + string.Format("{0:C2}", drDetail["Outstanding"]) + "</td>");
                                        strHTML.Append("<td align='right' style='width: 13%;'>" + string.Format("{0:N0}", drDetail["ClaimCount"]) + "</td>");
                                        strHTML.Append("<td align='right' style='width: 12%;'>" + string.Format("{0:N2}", drDetail["Percentage"]) + "</td>");
                                        strHTML.Append("</tr>");
                                    }
                                    #endregion

                                    #region " Print Region-wise sub totals "
                                    // print sub totals for region
                                    strHTML.Append("<tr style='color: Black; font-weight: bold;'>");
                                    strHTML.Append("<td align='left'>Sub Totals For Region: </td>");
                                    strHTML.Append("<td align='right'>" + string.Format("{0:C2}", drRegion["Total_Incurred"]) + "</td>");
                                    strHTML.Append("<td align='right'>" + string.Format("{0:C2}", drRegion["Total_Paid"]) + "</td>");
                                    strHTML.Append("<td align='right'>" + string.Format("{0:C2}", drRegion["Total_OutStanding"]) + "</td>");
                                    strHTML.Append("<td align='right'>" + string.Format("{0:N0}", drRegion["Total_Claims"]) + "</td>");
                                    strHTML.Append("<td align='right'>" + string.Format("{0:N2}", drRegion["Total_Percent"]) + "</td>");
                                    strHTML.Append("</tr>");
                                    strHTML.Append("</table></td></tr></table></td></tr>");
                                    #endregion
                                }
                                #endregion

                                strHTML.Append("</table></td></tr>");
                            }
                            #endregion

                            #endregion

                            strHTML.Append("</table>");

                            #region " Print Grand Totals "
                            if (dtGrandTotal.Rows.Count > 0)
                            {
                                DataRow drTotal = dtGrandTotal.Rows[0];
                                strHTML.Append("<table width='100%' cellpadding='0' cellspacing='0'><tr><td>");
                                strHTML.Append("<table width='100%' cellpadding='0' cellspacing='0'><tr><td>");
                                strHTML.Append("<table width='100%' cellpadding='0' cellspacing='0'><tr><td>");
                                strHTML.Append("<table width='100%' style='font-weight: bold; background-color: #507CD1;color: White;' border='1'><tr>");
                                strHTML.Append("<td style='width: 25%;' align='left'>Totals - </td>");
                                strHTML.Append("<td style='width: 15%;' align='right'>" + string.Format("{0:C2}", drTotal["Total_Incurred"]) + "</td>");
                                strHTML.Append("<td style='width: 15%;' align='right'>" + string.Format("{0:C2}", drTotal["Total_Paid"]) + "</td>");
                                strHTML.Append("<td style='width: 20%;' align='right'>" + string.Format("{0:C2}", drTotal["Total_OutStanding"]) + "</td>");
                                strHTML.Append("<td style='width: 13%;' align='right'>" + drTotal["Total_Claims"].ToString() + "</td>");
                                strHTML.Append("<td style='width: 12%;' align='right'>" + string.Format("{0:N2}", drTotal["Total_Percent"]) + "</td>");
                                strHTML.Append("</tr></table>");
                                strHTML.Append("</td></tr></table>");
                                strHTML.Append("</td></tr></table>");
                                strHTML.Append("</td></tr></table>");
                            }
                            #endregion
                        }
                        else
                        {
                            //Add No record found line for year
                            strHTML.Append("<tr><td align='left' colspan='6'>No Record Found!</td></tr>");
                        }
                        //Write HTML in to HtmlWriter
                        htmlWrite.WriteLine(strHTML.ToString());

                        //Send Mail
                        SendMail("Financial Summary Report", "FinancialSummary.xls", strFirstName, strLastName, strMailFrom, stringWrite, dtRecipients);
                    }
                }
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("ERROR in Financial Summary, " + ex.Message);
            }
        }

        //Report 2
        private void BindFinancialPayTypeSummaryReport(DataRow drReportSchedule)
        {
            try
            {
                decimal pK_Schedule_ID = Convert.ToDecimal(drReportSchedule["PK_Schedule"]);
                decimal Fk_RecipientList = Convert.ToDecimal(drReportSchedule["Fk_RecipientList"]);
                decimal FK_Security_Id = Convert.ToDecimal(drReportSchedule["FK_Security_Id"]);

                //Get Report criteria for the scheduled report
                DataTable dtFilter = Report.SelectFilterCriteria(2, pK_Schedule_ID).Tables[0];
                if (dtFilter.Rows.Count > 0)
                {
                    //Get the recipient from the recipient list 
                    DataTable dtRecipients = Report.SelectOneRecordWithRecipientList(Fk_RecipientList).Tables[0];

                    //Get the user who has scheduled the report
                    DataTable dtUser = Report.SelectSecurityByPK(FK_Security_Id).Tables[0];
                    String strFirstName, strLastName, strMailFrom;
                    strFirstName = strLastName = strMailFrom = "";
                    if (dtUser.Rows.Count > 0)
                    {
                        strFirstName = dtUser.Rows[0]["FIRST_NAME"].ToString();
                        strLastName = dtUser.Rows[0]["LAST_NAME"].ToString();
                        strMailFrom = dtUser.Rows[0]["Email"].ToString();

                        //Set all filters to a variable as per report type
                        String strPolicy_Year = dtFilter.Rows[0]["Accident_Year"].ToString();
                        string strRegion = dtFilter.Rows[0]["Region"].ToString();
                        string strMarket = null;
                        if (!string.IsNullOrEmpty(Convert.ToString(dtFilter.Rows[0]["Market"])))
                        {
                            strMarket = Convert.ToString(dtFilter.Rows[0]["Market"]).Trim();
                        }
                        string strValuationDate = Convert.ToDateTime(dtFilter.Rows[0]["Prior_Valuation_Date"]).ToString(DateDisplayFormat);

                        //Get the report data
                        DataSet dsReport = Report.GetFinancialPayTypeSummaryData(strPolicy_Year, strRegion, strMarket, Convert.ToDateTime(strValuationDate));

                        //Create HTML for the report and wirte into HTML Write object
                        StringBuilder strHTML = new StringBuilder();
                        System.IO.StringWriter stringWrite = new System.IO.StringWriter();
                        System.Web.UI.HtmlTextWriter htmlWrite = new System.Web.UI.HtmlTextWriter(stringWrite);

                        #region " Header "


                        //Retrieve Market Values
                        string strMarketString = string.Empty;
                        if (string.IsNullOrEmpty(strMarket))
                        {
                            strMarketString = "All Market";
                        }
                        else
                        {
                            string[] strMar = strMarket.Split(Convert.ToChar(","));
                            for (int i = 0; i < strMar.Length; i++)
                            {
                                strMarketString += Report.SelectMarketInfoById(Convert.ToDecimal(strMar[i].ToString())).Tables[0].Rows[0]["Market"].ToString() + ",";
                            }
                            strMarketString = strMarketString.TrimEnd(',');
                        }

                        //Add Report Title and Schedule Date
                        strHTML.Append("<br />");
                        strHTML.Append("<b>Report Title : Financial Pay Type Summary Report</b>");
                        strHTML.Append("<br /><br />");
                        strHTML.Append("Schedule Date : " + Convert.ToDateTime(drReportSchedule["Scheduled_Date"]).ToString(DateDisplayFormat));
                        strHTML.Append("&nbsp;&nbsp;&nbsp;&nbsp;Schedule End Date : " + Convert.ToDateTime(drReportSchedule["Schedule_End_Date"]).ToString(DateDisplayFormat));
                        strHTML.Append("<br />");
                        strHTML.Append("Recurring Period : " + drReportSchedule["Recurring_Period"]).ToString();
                        strHTML.Append("<br />");
                        strHTML.Append("Recurring Date : " + dtSchduleDate.ToString(DateDisplayFormat));

                        //Add Report Filter Criteria 
                        strHTML.Append("<br /><br />");
                        strHTML.Append("<b>Report Filters </b>");
                        strHTML.Append("<br /><br />");
                        strHTML.Append("Accident Year        : " + strPolicy_Year);
                        strHTML.Append("<br />");
                        strHTML.Append("Regions              : " + strRegion.Replace("'", ""));
                        strHTML.Append("<br />");
                        strHTML.Append("Market        : " + strMarketString);
                        strHTML.Append("<br /><br />");
                        strHTML.Append("Prior Valuation Date : " + strValuationDate);
                        strHTML.Append("<br /><br />");

                        //Add Header HTML
                        strHTML.Append("<table width='100%' cellpadding='0' cellspacing='0'><tr><td>");
                        strHTML.Append("<table width='100%' cellpadding='0' cellspacing='0'><tr><td>");
                        strHTML.Append("<table width='100%' cellpadding='0' cellspacing='0'><tr><td>");
                        strHTML.Append("<table border='0' cellpadding='0' cellspacing='0' width='100%' style='font-weight:bold;' border='1'>");
                        strHTML.Append("<tr><td style='width: 20%'>&nbsp;</td>");
                        strHTML.Append("<td style='width: 16%;' align='right'>Indemnity/PD</td>");
                        strHTML.Append("<td style='width: 16%;' align='right'>Medical/BI</td>");
                        strHTML.Append("<td style='width: 16%;' align='right'>Expense</td>");
                        strHTML.Append("<td style='width: 16%;' align='right'>Total</td>");
                        strHTML.Append("<td style='width: 16%;' align='center'>Claim Count</td></tr>");
                        strHTML.Append("</tr></table>");
                        strHTML.Append("</td></tr></table>");
                        strHTML.Append("</td></tr></table>");
                        strHTML.Append("</td></tr></table>");
                        #endregion

                        // get datatbles from dataset
                        DataTable dtYears = dsReport.Tables[0];
                        DataTable dtDetails = dsReport.Tables[1];
                        DataTable dtRegionTotal = dsReport.Tables[2];
                        DataTable dtGrandTotal = dsReport.Tables[3];

                        if (dtDetails.Rows.Count > 0)
                        {
                            //Add Report Data Table 
                            strHTML.Append("<table style='width: 100%;' border='1' align='left' cellpadding='4' cellspacing='0'>");

                            #region " Report Data "

                            #region " List Accident Years "

                            foreach (DataRow drYear in dtYears.Rows)
                            {
                                //Add Header for Sub Report (Year wise)
                                strHTML.Append("<tr><td width='100%' align='left'>");
                                strHTML.Append("<span style='color: Chocolate; font-weight: bold;'>Accident Year - " + drYear["AccidentYear"].ToString() + "</span>");
                                strHTML.Append("</td></tr><tr><td align='left'>");
                                strHTML.Append("<table cellspacing='0' cellpadding='0' align='Left' border='1' style='width: 100%;border-collapse: collapse;'>");
                                DataRow[] drRegions = dtRegionTotal.Select("AccidentYear='" + drYear["AccidentYear"].ToString() + "'");

                                #region " List Regions "
                                foreach (DataRow drRegion in drRegions)
                                {
                                    strHTML.Append("<tr><td align='left' style='width: 100%;'><table cellpadding='0' cellspacing='0' width='100%'>");
                                    strHTML.Append("<tr><td width='100%' align='left'><b>Region - " + drRegion["Region"].ToString() + "</span></b></td></tr>");
                                    strHTML.Append("<tr><td align='Left'><table style='width: 100%;' border='1' align='left' cellpadding='4' cellspacing='0'>");
                                    DataRow[] drDetails = dtDetails.Select("AccidentYear='" + drYear["AccidentYear"].ToString() + "' and Region='" + drRegion["Region"].ToString() + "'");

                                    #region " Print Claim Details "
                                    foreach (DataRow drDetail in drDetails)
                                    {
                                        strHTML.Append("<tr><td align='left' colspan='6'><b>" + drDetail["ClaimType"].ToString() + "</b></td></tr>");

                                        strHTML.Append("<tr>");
                                        strHTML.Append("<td style='width: 20%' align='left'>Incurred</td>");
                                        strHTML.Append("<td style='width: 16%' align='right'>" + string.Format("{0:C2}", drDetail["Indemnity_Incurred"]) + "</td>");
                                        strHTML.Append("<td style='width: 16%' align='right'>" + string.Format("{0:C2}", drDetail["Medical_Incurred"]) + "</td>");
                                        strHTML.Append("<td style='width: 16%' align='right'>" + string.Format("{0:C2}", drDetail["Expense_Incurred"]) + "</td>");
                                        strHTML.Append("<td style='width: 16%' align='right'>" + string.Format("{0:C2}", drDetail["Total_Incurred"]) + "</td>");
                                        strHTML.Append("<td style='width: 16%' align='center'>" + string.Format("{0:N0}", drDetail["ClaimCount"]) + "</td>");
                                        strHTML.Append("</tr>");

                                        strHTML.Append("<tr>");
                                        strHTML.Append("<td style='width: 20%' align='left'>Paid</td>");
                                        strHTML.Append("<td style='width: 16%' align='right'>" + string.Format("{0:C2}", drDetail["Indemnity_Paid"]) + "</td>");
                                        strHTML.Append("<td style='width: 16%' align='right'>" + string.Format("{0:C2}", drDetail["Medical_Paid"]) + "</td>");
                                        strHTML.Append("<td style='width: 16%' align='right'>" + string.Format("{0:C2}", drDetail["Expense_Paid"]) + "</td>");
                                        strHTML.Append("<td style='width: 16%' align='right'>" + string.Format("{0:C2}", drDetail["Total_Paid"]) + "</td>");
                                        strHTML.Append("<td style='width: 16%' align='center'>&nbsp;</td>");
                                        strHTML.Append("</tr>");

                                        strHTML.Append("<tr>");
                                        strHTML.Append("<td style='width: 20%' align='left'>Outstanding</td>");
                                        strHTML.Append("<td style='width: 16%' align='right'>" + string.Format("{0:C2}", drDetail["Indemnity_Outstanding"]) + "</td>");
                                        strHTML.Append("<td style='width: 16%' align='right'>" + string.Format("{0:C2}", drDetail["Medical_Outstanding"]) + "</td>");
                                        strHTML.Append("<td style='width: 16%' align='right'>" + string.Format("{0:C2}", drDetail["Expense_Outstanding"]) + "</td>");
                                        strHTML.Append("<td style='width: 16%' align='right'>" + string.Format("{0:C2}", drDetail["Total_Outstanding"]) + "</td>");
                                        strHTML.Append("<td style='width: 16%' align='center'>&nbsp;</td>");
                                        strHTML.Append("</tr>");
                                    }
                                    #endregion

                                    #region " Print Region-wise sub totals "
                                    // print sub totals for region
                                    strHTML.Append("<tr style='color: Black; font-weight: bold;'><td align='left' colspan='6'>Sub Total</td></tr>");
                                    strHTML.Append("<tr style='color: Black; font-weight: bold;'>");

                                    strHTML.Append("<td align='left'>Incurred</td>");
                                    strHTML.Append("<td align='right'>" + string.Format("{0:C2}", drRegion["Total_Indemnity_Incurred"]) + "</td>");
                                    strHTML.Append("<td align='right'>" + string.Format("{0:C2}", drRegion["Total_Medical_Incurred"]) + "</td>");
                                    strHTML.Append("<td align='right'>" + string.Format("{0:C2}", drRegion["Total_Expense_Incurred"]) + "</td>");
                                    strHTML.Append("<td align='right'>" + string.Format("{0:C2}", drRegion["Total_Incurred"]) + "</td>");
                                    strHTML.Append("<td align='center'>" + string.Format("{0:N2}", drRegion["Total_Claims"]) + "</td>");
                                    strHTML.Append("</tr>");

                                    strHTML.Append("<tr style='color: Black; font-weight: bold;'>");
                                    strHTML.Append("<td align='left'>Paid</td>");
                                    strHTML.Append("<td align='right'>" + string.Format("{0:C2}", drRegion["Total_Indemnity_Paid"]) + "</td>");
                                    strHTML.Append("<td align='right'>" + string.Format("{0:C2}", drRegion["Total_Medical_Paid"]) + "</td>");
                                    strHTML.Append("<td align='right'>" + string.Format("{0:C2}", drRegion["Total_Expense_Paid"]) + "</td>");
                                    strHTML.Append("<td align='right'>" + string.Format("{0:C2}", drRegion["Total_Paid"]) + "</td>");
                                    strHTML.Append("<td align='center'>&nbsp;</td>");
                                    strHTML.Append("</tr>");
                                    strHTML.Append("<tr style='color: Black; font-weight: bold;'>");
                                    strHTML.Append("<td align='left'>Outstanding</td>");
                                    strHTML.Append("<td align='right'>" + string.Format("{0:C2}", drRegion["Total_Indemnity_OutStanding"]) + "</td>");
                                    strHTML.Append("<td align='right'>" + string.Format("{0:C2}", drRegion["Total_Medical_OutStanding"]) + "</td>");
                                    strHTML.Append("<td align='right'>" + string.Format("{0:C2}", drRegion["Total_Expense_OutStanding"]) + "</td>");
                                    strHTML.Append("<td align='right'>" + string.Format("{0:C2}", drRegion["Total_Outstanding"]) + "</td>");
                                    strHTML.Append("<td align='center'>&nbsp;</td>");
                                    strHTML.Append("</tr>");
                                    strHTML.Append("</table></td></tr></table></td></tr>");
                                    #endregion
                                }
                                #endregion

                                strHTML.Append("</table></td></tr>");
                            }
                            #endregion

                            #endregion

                            strHTML.Append("</table>");

                            #region " Print Grand Totals "
                            if (dtGrandTotal.Rows.Count > 0)
                            {
                                DataRow drTotal = dtGrandTotal.Rows[0];
                                strHTML.Append("<table width='100%' cellpadding='0' cellspacing='0'><tr><td>");
                                strHTML.Append("<table width='100%' cellpadding='0' cellspacing='0'><tr><td>");
                                strHTML.Append("<table width='100%' cellpadding='0' cellspacing='0'><tr><td>");
                                strHTML.Append("<table border='0' cellpadding='0' cellspacing='0' style='font-weight: bold; background-color: #507CD1;color: White;' border='1'>");
                                strHTML.Append("<tr><td style='width: 100%' colspan='6'>* Report Grand Total</td></tr>");

                                strHTML.Append("<tr><td style='width: 20%'>Incurred</td>");
                                strHTML.Append("<td style='width: 16%;' align='right'>" + string.Format("{0:C2}", drTotal["Total_Indemnity_Incurred"]) + "</td>");
                                strHTML.Append("<td style='width: 16%;' align='right'>" + string.Format("{0:C2}", drTotal["Total_Medical_Incurred"]) + "</td>");
                                strHTML.Append("<td style='width: 16%;' align='right'>" + string.Format("{0:C2}", drTotal["Total_Expense_Incurred"]) + "</td>");
                                strHTML.Append("<td style='width: 16%;' align='right'>" + string.Format("{0:C2}", drTotal["Total_Incurred"]) + "</td>");
                                strHTML.Append("<td style='width: 16%;' align='center'>" + string.Format("{0:N2}", drTotal["Total_Claims"]) + "</td></tr>");

                                strHTML.Append("<tr>");
                                strHTML.Append("<td align='left'>Paid</td>");
                                strHTML.Append("<td align='right'>" + string.Format("{0:C2}", drTotal["Total_Indemnity_Paid"]) + "</td>");
                                strHTML.Append("<td align='right'>" + string.Format("{0:C2}", drTotal["Total_Medical_Paid"]) + "</td>");
                                strHTML.Append("<td align='right'>" + string.Format("{0:C2}", drTotal["Total_Expense_Paid"]) + "</td>");
                                strHTML.Append("<td align='right'>" + string.Format("{0:C2}", drTotal["Total_Paid"]) + "</td>");
                                strHTML.Append("<td align='center'>&nbsp;</td>");
                                strHTML.Append("</tr>");

                                strHTML.Append("<tr>");
                                strHTML.Append("<td align='left'>Outstanding</td>");
                                strHTML.Append("<td align='right'>" + string.Format("{0:C2}", drTotal["Total_Indemnity_OutStanding"]) + "</td>");
                                strHTML.Append("<td align='right'>" + string.Format("{0:C2}", drTotal["Total_Medical_OutStanding"]) + "</td>");
                                strHTML.Append("<td align='right'>" + string.Format("{0:C2}", drTotal["Total_Expense_OutStanding"]) + "</td>");
                                strHTML.Append("<td align='right'>" + string.Format("{0:C2}", drTotal["Total_Outstanding"]) + "</td>");
                                strHTML.Append("<td align='center'>&nbsp;</td>");
                                strHTML.Append("</tr>");

                                strHTML.Append("</tr></table>");
                                strHTML.Append("</td></tr></table>");
                                strHTML.Append("</td></tr></table>");
                                strHTML.Append("</td></tr></table>");
                            }
                            #endregion
                        }
                        else
                        {
                            //Add No record found line for year
                            strHTML.Append("<tr><td align='left' colspan='6'>No Record Found!</td></tr>");
                        }

                        //Write HTML in to HtmlWriter
                        htmlWrite.WriteLine(strHTML.ToString());

                        //Send Mail
                        SendMail("Financial Pay Type Summary Report", "FinancialPayTypeSummary.xls", strFirstName, strLastName, strMailFrom, stringWrite, dtRecipients);
                    }
                }
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("ERROR in Financial Pay Type Summary, " + ex.Message);
            }
        }

        //Report 3
        private void BindEmployerLagSummaryReport(DataRow drReportSchedule)
        {
            try
            {
                decimal pK_Schedule_ID = Convert.ToDecimal(drReportSchedule["PK_Schedule"]);
                decimal Fk_RecipientList = Convert.ToDecimal(drReportSchedule["Fk_RecipientList"]);
                decimal FK_Security_Id = Convert.ToDecimal(drReportSchedule["FK_Security_Id"]);

                //Get Report criteria for the scheduled report
                DataTable dtFilter = Report.SelectFilterCriteria(3, pK_Schedule_ID).Tables[0];
                if (dtFilter.Rows.Count > 0)
                {
                    //Get the recipient from the recipient list 
                    DataTable dtRecipients = Report.SelectOneRecordWithRecipientList(Fk_RecipientList).Tables[0];

                    //Get the user who has scheduled the report
                    DataTable dtUser = Report.SelectSecurityByPK(FK_Security_Id).Tables[0];
                    String strFirstName, strLastName, strMailFrom;
                    strFirstName = strLastName = strMailFrom = "";
                    if (dtUser.Rows.Count > 0)
                    {
                        strFirstName = dtUser.Rows[0]["FIRST_NAME"].ToString();
                        strLastName = dtUser.Rows[0]["LAST_NAME"].ToString();
                        strMailFrom = dtUser.Rows[0]["Email"].ToString();

                        //Set all filters to a variable as per report type
                        String strRegions = dtFilter.Rows[0]["Region"].ToString();
                        string strMarket = null;
                        if (!string.IsNullOrEmpty(Convert.ToString(dtFilter.Rows[0]["Market"])))
                        {
                            strMarket = Convert.ToString(dtFilter.Rows[0]["Market"]).Trim();
                        }
                        DateTime date_of_loss_from = Convert.ToDateTime(dtFilter.Rows[0]["From_Date_Of_Loss"].ToString());
                        DateTime date_of_loss_to = Convert.ToDateTime(dtFilter.Rows[0]["To_Date_Of_Loss"].ToString());

                        //Get the report data
                        DataSet dsReport = Report.GetEmployerLagSummaryData(date_of_loss_from, date_of_loss_to, strRegions, strMarket);

                        //Create HTML for the report and wirte into HTML Write object
                        StringBuilder strHTML = new StringBuilder();
                        System.IO.StringWriter stringWrite = new System.IO.StringWriter();
                        System.Web.UI.HtmlTextWriter htmlWrite = new System.Web.UI.HtmlTextWriter(stringWrite);

                        #region " Header "

                        //Retrieve Market Values
                        string strMarketString = string.Empty;
                        if (string.IsNullOrEmpty(strMarket))
                        {
                            strMarketString = "All Market";
                        }
                        else
                        {
                            string[] strMar = strMarket.Split(Convert.ToChar(","));
                            for (int i = 0; i < strMar.Length; i++)
                            {
                                strMarketString += Report.SelectMarketInfoById(Convert.ToDecimal(strMar[i].ToString())).Tables[0].Rows[0]["Market"].ToString() + ",";
                            }
                            strMarketString = strMarketString.TrimEnd(',');
                        }

                        //Add Report Title and Schedule Date
                        strHTML.Append("<br />");
                        strHTML.Append("<b>Report Title : Reported to Employer Lag Summary Report</b>");
                        strHTML.Append("<br /><br />");
                        strHTML.Append("Schedule Date : " + Convert.ToDateTime(drReportSchedule["Scheduled_Date"]).ToString(DateDisplayFormat));
                        strHTML.Append("&nbsp;&nbsp;&nbsp;&nbsp;Schedule End Date : " + Convert.ToDateTime(drReportSchedule["Schedule_End_Date"]).ToString(DateDisplayFormat));
                        strHTML.Append("<br />");
                        strHTML.Append("Recurring Period : " + drReportSchedule["Recurring_Period"]).ToString();
                        strHTML.Append("<br />");
                        strHTML.Append("Recurring Date : " + dtSchduleDate.ToString(DateDisplayFormat));

                        //Add Report Filter Criteria 
                        strHTML.Append("<br /><br />");
                        strHTML.Append("<b>Report Filters </b>");
                        strHTML.Append("<br /><br />");
                        strHTML.Append("Regions :" + strRegions.Replace("'", ""));
                        strHTML.Append("<br />");
                        strHTML.Append("Market        : " + strMarketString);
                        strHTML.Append("<br /><br />");
                        strHTML.Append("Date Of Loss : From : " + date_of_loss_from.ToString(DateDisplayFormat) + " &nbsp;&nbsp&nbsp;&nbsp; To : " + date_of_loss_to.ToString(DateDisplayFormat));
                        strHTML.Append("<br /><br />");

                        //Add Header HTML
                        strHTML.Append("<table style='font-weight: bold;' cellpadding='0' cellspacing='0' width='100%' border='0'><tr><td>");
                        strHTML.Append("<table style='font-weight: bold;' cellpadding='0' cellspacing='0' width='100%' border='1'>");
                        strHTML.Append("<tr><td style='width: 26%;' align='left'>Lag Period(Days)</td>");
                        strHTML.Append("<td style='width: 14%;' align='center'>No of Claims</td>");
                        strHTML.Append("<td style='width: 14%;' align='center'>Percentage To <br />Total Claim</td>");
                        strHTML.Append("<td style='width: 18%;' align='center'>Total<br/>Incurred Dollars</td>");
                        strHTML.Append("<td style='width: 14%;' align='center'>Percentage To <br />Total Dollars</td></tr></table>");
                        strHTML.Append("</td></tr></table>");

                        #endregion

                        //Get the no of descriptions selected
                        strHTML.Append("<table style='width: 100%;' border='1' align='left' cellpadding='4' cellspacing='0'>");
                        // get data tables from dataset
                        DataTable dtRegions = dsReport.Tables[0];
                        DataTable dtDetails = dsReport.Tables[1];
                        DataTable dtRegionTotal = dsReport.Tables[2];
                        DataTable dtGrandTotal = dsReport.Tables[3];
                        int intMedian = Convert.ToInt32(dsReport.Tables[4].Rows[0][0]);
                        if (dtDetails.Rows.Count > 0)
                        {
                            foreach (DataRow drRegion in dtRegionTotal.Rows)
                            {
                                //Add Header for Sub Report (Description wise)
                                strHTML.Append("<tr><td colspan='5' style='font-weight:bold;'>" + drRegion["Region"].ToString() + "</td></tr>");
                                DataRow[] drDetails = dtDetails.Select("Region='" + drRegion["Region"].ToString() + "'");

                                foreach (DataRow drDetail in drDetails)
                                {
                                    //Add Report Data Table 
                                    strHTML.Append("<tr><td align='left' style='width: 26%'>" + drDetail["StartLimit"] + " To " + drDetail["EndLimit"] + "</td>");
                                    strHTML.Append("<td align='right' style='width: 14%'>" + String.Format("{0:N0}", drDetail["ClaimCount"]) + "</td>");
                                    strHTML.Append("<td align='right' style='width: 14%'>" + String.Format("{0:N2}", drDetail["ClaimPercent"]) + "</td>");
                                    strHTML.Append("<td align='right' style='width: 18%'>" + String.Format("{0:C2}", drDetail["Incurred"]) + "</td>");
                                    strHTML.Append("<td align='right' style='width: 14%'>" + String.Format("{0:N2}", drDetail["IncurredPercent"]) + "</td>");
                                }
                                //Add Sub Total (Region wise)
                                strHTML.Append("<tr style='font-weight: bold;background-color: white; color: black;'><td align='left' style='width: 26%;'>Total </td>");
                                strHTML.Append("<td align='right' style='width: 14%'>" + String.Format("{0:N0}", drRegion["TotalClaims"]) + "</td>");
                                strHTML.Append("<td align='right' style='width: 14%'>" + String.Format("{0:N2}", drRegion["TotalClaimPercent"]) + "</td>");
                                strHTML.Append("<td align='right' style='width: 18%'>" + String.Format("{0:C2}", drRegion["TotalIncurred"]) + "</td>");
                                strHTML.Append("<td align='right' style='width: 14%'>" + String.Format("{0:N2}", drRegion["TotalIncurredPercent"]) + "</td></tr>");
                            }
                            strHTML.Append("</table>");

                            #region " Grand Total "
                            if (dtGrandTotal.Rows.Count > 0)
                            {
                                DataRow drTotal = dtGrandTotal.Rows[0];
                                strHTML.Append("<table style='font-weight: bold;' cellpadding='0' cellspacing='0' width='100%' border='0'><tr><td>");
                                strHTML.Append("<table style='font-weight: bold;' cellpadding='0' cellspacing='0' width='100%' border='1' style='font-weight: bold;background-color: #507CD1; color: #FFFFFF;'>");
                                strHTML.Append("<tr><td style='width: 26%;' align='left'>Total</td>");
                                strHTML.Append("<td style='width: 14%;' align='right'>" + String.Format("{0:N0}", drTotal["TotalClaims"]) + "</td>");
                                strHTML.Append("<td style='width: 14%;' align='right'>" + String.Format("{0:N2}", drTotal["TotalClaimPercent"]) + "</td>");
                                strHTML.Append("<td style='width: 18%;' align='right'>" + String.Format("{0:C2}", drTotal["TotalIncurred"]) + "</td>");
                                strHTML.Append("<td style='width: 14%;' align='right'>" + String.Format("{0:N2}", drTotal["TotalIncurredPercent"]) + "</td></tr></table>");
                                strHTML.Append("</td></tr></table>");
                            }
                            #endregion

                            strHTML.Append("<table style='width: 100%;' border='0' align='left' cellpadding='4' cellspacing='0'>");
                            strHTML.Append("<tr><td width='100%' align='left' colspan='5'><b>Median Lag Time in Days : " + intMedian + "</b></td></tr>");
                            strHTML.Append("</table>");
                        }
                        else
                        {
                            //Add No record found line for year
                            strHTML.Append("<tr><td align='left' colspan='5'>No Record Found!</td></tr></table>");
                        }


                        //Write HTML in to HtmlWriter
                        htmlWrite.WriteLine(strHTML.ToString());

                        //Send Mail
                        SendMail("Reported to Employer Lag Summary Report", "EmployerLagSummaryReport.xls", strFirstName, strLastName, strMailFrom, stringWrite, dtRecipients);
                    }
                }
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("ERROR in Lag Summary : 3, " + ex.Message);
            }
        }

        //Report 4
        private void BindInsurerLagSummaryReport(DataRow drReportSchedule)
        {
            try
            {
                decimal pK_Schedule_ID = Convert.ToDecimal(drReportSchedule["PK_Schedule"]);
                decimal Fk_RecipientList = Convert.ToDecimal(drReportSchedule["Fk_RecipientList"]);
                decimal FK_Security_Id = Convert.ToDecimal(drReportSchedule["FK_Security_Id"]);

                //Get Report criteria for the scheduled report
                DataTable dtFilter = Report.SelectFilterCriteria(4, pK_Schedule_ID).Tables[0];
                if (dtFilter.Rows.Count > 0)
                {
                    //Get the recipient from the recipient list 
                    DataTable dtRecipients = Report.SelectOneRecordWithRecipientList(Fk_RecipientList).Tables[0];

                    //Get the user who has scheduled the report
                    DataTable dtUser = Report.SelectSecurityByPK(FK_Security_Id).Tables[0];
                    String strFirstName, strLastName, strMailFrom;
                    strFirstName = strLastName = strMailFrom = "";
                    if (dtUser.Rows.Count > 0)
                    {
                        strFirstName = dtUser.Rows[0]["FIRST_NAME"].ToString();
                        strLastName = dtUser.Rows[0]["LAST_NAME"].ToString();
                        strMailFrom = dtUser.Rows[0]["Email"].ToString();

                        //Set all filters to a variable as per report type
                        String strRegions = dtFilter.Rows[0]["Region"].ToString();
                        string strMarket = null;
                        if (!string.IsNullOrEmpty(Convert.ToString(dtFilter.Rows[0]["Market"])))
                        {
                            strMarket = Convert.ToString(dtFilter.Rows[0]["Market"]).Trim();
                        }
                        DateTime date_of_loss_from = Convert.ToDateTime(dtFilter.Rows[0]["From_Date_Of_Loss"].ToString());
                        DateTime date_of_loss_to = Convert.ToDateTime(dtFilter.Rows[0]["To_Date_Of_Loss"].ToString());

                        //Get the report data
                        DataSet dsReport = Report.GetInsurerLagSummaryData(date_of_loss_from, date_of_loss_to, strRegions, strMarket);

                        //Create HTML for the report and wirte into HTML Write object
                        StringBuilder strHTML = new StringBuilder();
                        System.IO.StringWriter stringWrite = new System.IO.StringWriter();
                        System.Web.UI.HtmlTextWriter htmlWrite = new System.Web.UI.HtmlTextWriter(stringWrite);

                        #region " Header "

                        //Retrieve Market Values
                        string strMarketString = string.Empty;
                        if (string.IsNullOrEmpty(strMarket))
                        {
                            strMarketString = "All Market";
                        }
                        else
                        {
                            string[] strMar = strMarket.Split(Convert.ToChar(","));
                            for (int i = 0; i < strMar.Length; i++)
                            {
                                strMarketString += Report.SelectMarketInfoById(Convert.ToDecimal(strMar[i].ToString())).Tables[0].Rows[0]["Market"].ToString() + ",";
                            }
                            strMarketString = strMarketString.TrimEnd(',');
                        }

                        //Add Report Title and Schedule Date
                        strHTML.Append("<br />");
                        strHTML.Append("<b>Report Title : Reported to Insurer Lag Summary Report</b>");
                        strHTML.Append("<br /><br />");
                        strHTML.Append("Schedule Date : " + Convert.ToDateTime(drReportSchedule["Scheduled_Date"]).ToString(DateDisplayFormat));
                        strHTML.Append("&nbsp;&nbsp;&nbsp;&nbsp;Schedule End Date : " + Convert.ToDateTime(drReportSchedule["Schedule_End_Date"]).ToString(DateDisplayFormat));
                        strHTML.Append("<br />");
                        strHTML.Append("Recurring Period : " + drReportSchedule["Recurring_Period"]).ToString();
                        strHTML.Append("<br />");
                        strHTML.Append("Recurring Date : " + dtSchduleDate.ToString(DateDisplayFormat));

                        //Add Report Filter Criteria 
                        strHTML.Append("<br /><br />");
                        strHTML.Append("<b>Report Filters </b>");
                        strHTML.Append("<br /><br />");
                        strHTML.Append("Regions :" + strRegions.Replace("'", ""));
                        strHTML.Append("<br />");
                        strHTML.Append("Market        : " + strMarketString);
                        strHTML.Append("<br /><br />");
                        strHTML.Append("Date Of Loss : From : " + date_of_loss_from.ToString(DateDisplayFormat) + " &nbsp;&nbsp&nbsp;&nbsp; To : " + date_of_loss_to.ToString(DateDisplayFormat));
                        strHTML.Append("<br /><br />");

                        //Add Header HTML
                        strHTML.Append("<table style='font-weight: bold;' cellpadding='0' cellspacing='0' width='100%' border='0'><tr><td>");
                        strHTML.Append("<table style='font-weight: bold;' cellpadding='0' cellspacing='0' width='100%' border='1'>");
                        strHTML.Append("<tr><td style='width: 26%;' align='left'>Lag Period(Days)</td>");
                        strHTML.Append("<td style='width: 14%;' align='center'>No of Claims</td>");
                        strHTML.Append("<td style='width: 14%;' align='center'>Percentage To <br />Total Claim</td>");
                        strHTML.Append("<td style='width: 18%;' align='center'>Total<br/>Incurred Dollars</td>");
                        strHTML.Append("<td style='width: 14%;' align='center'>Percentage To <br />Total Dollars</td></tr></table>");
                        strHTML.Append("</td></tr></table>");

                        #endregion

                        //Get the no of descriptions selected
                        strHTML.Append("<table style='width: 100%;' border='1' align='left' cellpadding='4' cellspacing='0'>");
                        // get data tables from dataset
                        DataTable dtRegions = dsReport.Tables[0];
                        DataTable dtDetails = dsReport.Tables[1];
                        DataTable dtRegionTotal = dsReport.Tables[2];
                        DataTable dtGrandTotal = dsReport.Tables[3];
                        int intMedian = Convert.ToInt32(dsReport.Tables[4].Rows[0][0]);
                        if (dtDetails.Rows.Count > 0)
                        {
                            foreach (DataRow drRegion in dtRegionTotal.Rows)
                            {
                                //Add Header for Sub Report (Description wise)
                                strHTML.Append("<tr><td colspan='5' style='font-weight:bold;'>" + drRegion["Region"].ToString() + "</td></tr>");
                                DataRow[] drDetails = dtDetails.Select("Region='" + drRegion["Region"].ToString() + "'");

                                foreach (DataRow drDetail in drDetails)
                                {
                                    //Add Report Data Table 
                                    strHTML.Append("<tr><td align='left' style='width: 26%'>" + drDetail["StartLimit"] + " To " + drDetail["EndLimit"] + "</td>");
                                    strHTML.Append("<td align='right' style='width: 14%'>" + String.Format("{0:N0}", drDetail["ClaimCount"]) + "</td>");
                                    strHTML.Append("<td align='right' style='width: 14%'>" + String.Format("{0:N2}", drDetail["ClaimPercent"]) + "</td>");
                                    strHTML.Append("<td align='right' style='width: 18%'>" + String.Format("{0:C2}", drDetail["Incurred"]) + "</td>");
                                    strHTML.Append("<td align='right' style='width: 14%'>" + String.Format("{0:N2}", drDetail["IncurredPercent"]) + "</td>");
                                }
                                //Add Sub Total (Region wise)
                                strHTML.Append("<tr style='font-weight: bold;background-color: white; color: black;'><td align='left' style='width: 26%;'>Total </td>");
                                strHTML.Append("<td align='right' style='width: 14%'>" + String.Format("{0:N0}", drRegion["TotalClaims"]) + "</td>");
                                strHTML.Append("<td align='right' style='width: 14%'>" + String.Format("{0:N2}", drRegion["TotalClaimPercent"]) + "</td>");
                                strHTML.Append("<td align='right' style='width: 18%'>" + String.Format("{0:C2}", drRegion["TotalIncurred"]) + "</td>");
                                strHTML.Append("<td align='right' style='width: 14%'>" + String.Format("{0:N2}", drRegion["TotalIncurredPercent"]) + "</td></tr>");
                            }
                            strHTML.Append("</table>");
                            #region " Grand Total "
                            if (dtGrandTotal.Rows.Count > 0)
                            {
                                DataRow drTotal = dtGrandTotal.Rows[0];
                                strHTML.Append("<table style='font-weight: bold;' cellpadding='0' cellspacing='0' width='100%' border='0'><tr><td>");
                                strHTML.Append("<table style='font-weight: bold;' cellpadding='0' cellspacing='0' width='100%' border='1' style='font-weight: bold;background-color: #507CD1; color: #FFFFFF;'>");
                                strHTML.Append("<tr><td style='width: 26%;' align='left'>Total</td>");
                                strHTML.Append("<td style='width: 14%;' align='right'>" + String.Format("{0:N0}", drTotal["TotalClaims"]) + "</td>");
                                strHTML.Append("<td style='width: 14%;' align='right'>" + String.Format("{0:N2}", drTotal["TotalClaimPercent"]) + "</td>");
                                strHTML.Append("<td style='width: 18%;' align='right'>" + String.Format("{0:C2}", drTotal["TotalIncurred"]) + "</td>");
                                strHTML.Append("<td style='width: 14%;' align='right'>" + String.Format("{0:N2}", drTotal["TotalIncurredPercent"]) + "</td></tr></table>");
                                strHTML.Append("</td></tr></table>");
                            }
                            #endregion

                            strHTML.Append("<table style='width: 100%;' border='0' align='left' cellpadding='4' cellspacing='0'>");
                            strHTML.Append("<tr><td width='100%' align='left' colspan='5'><b>Median Lag Time in Days : " + intMedian + "</b></td></tr>");
                            strHTML.Append("</table>");
                        }
                        else
                        {
                            //Add No record found line for year
                            strHTML.Append("<tr><td align='left' colspan='5'>No Record Found!</td></tr></table>");
                        }

                        //Write HTML in to HtmlWriter
                        htmlWrite.WriteLine(strHTML.ToString());

                        //Send Mail
                        SendMail("Reported to Insurer Lag Summary Report", "InsurerLagSummaryReport.xls", strFirstName, strLastName, strMailFrom, stringWrite, dtRecipients);
                    }
                }
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("ERROR in Lag Summary : 4, " + ex.Message);
            }
        }

        //Report 5
        private void BindCompletionLagSummaryReport(DataRow drReportSchedule)
        {
            try
            {
                decimal pK_Schedule_ID = Convert.ToDecimal(drReportSchedule["PK_Schedule"]);
                decimal Fk_RecipientList = Convert.ToDecimal(drReportSchedule["Fk_RecipientList"]);
                decimal FK_Security_Id = Convert.ToDecimal(drReportSchedule["FK_Security_Id"]);

                //Get Report criteria for the scheduled report
                DataTable dtFilter = Report.SelectFilterCriteria(5, pK_Schedule_ID).Tables[0];
                if (dtFilter.Rows.Count > 0)
                {
                    //Get the recipient from the recipient list 
                    DataTable dtRecipients = Report.SelectOneRecordWithRecipientList(Fk_RecipientList).Tables[0];

                    //Get the user who has scheduled the report
                    DataTable dtUser = Report.SelectSecurityByPK(FK_Security_Id).Tables[0];
                    String strFirstName, strLastName, strMailFrom;
                    strFirstName = strLastName = strMailFrom = "";
                    if (dtUser.Rows.Count > 0)
                    {
                        strFirstName = dtUser.Rows[0]["FIRST_NAME"].ToString();
                        strLastName = dtUser.Rows[0]["LAST_NAME"].ToString();
                        strMailFrom = dtUser.Rows[0]["Email"].ToString();

                        //Set all filters to a variable as per report type
                        String strRegions = dtFilter.Rows[0]["Region"].ToString();
                        string strMarket = null;
                        if (!string.IsNullOrEmpty(Convert.ToString(dtFilter.Rows[0]["Market"])))
                        {
                            strMarket = Convert.ToString(dtFilter.Rows[0]["Market"]).Trim();
                        }
                        DateTime date_of_loss_from = Convert.ToDateTime(dtFilter.Rows[0]["From_Date_Of_Loss"].ToString());
                        DateTime date_of_loss_to = Convert.ToDateTime(dtFilter.Rows[0]["To_Date_Of_Loss"].ToString());

                        //Get the report data
                        DataSet dsReport = Report.GetCompletionLagSummaryData(date_of_loss_from, date_of_loss_to, strRegions, strMarket);

                        //Create HTML for the report and wirte into HTML Write object
                        StringBuilder strHTML = new StringBuilder();
                        System.IO.StringWriter stringWrite = new System.IO.StringWriter();
                        System.Web.UI.HtmlTextWriter htmlWrite = new System.Web.UI.HtmlTextWriter(stringWrite);

                        #region " Header "

                        //Retrieve Market Values
                        string strMarketString = string.Empty;
                        if (string.IsNullOrEmpty(strMarket))
                        {
                            strMarketString = "All Market";
                        }
                        else
                        {
                            string[] strMar = strMarket.Split(Convert.ToChar(","));
                            for (int i = 0; i < strMar.Length; i++)
                            {
                                strMarketString += Report.SelectMarketInfoById(Convert.ToDecimal(strMar[i].ToString())).Tables[0].Rows[0]["Market"].ToString() + ",";
                            }
                            strMarketString = strMarketString.TrimEnd(',');
                        }

                        //Add Report Title and Schedule Date
                        strHTML.Append("<br />");
                        strHTML.Append("<b>Report Title : Reported to Completion Lag Summary Report</b>");
                        strHTML.Append("<br /><br />");
                        strHTML.Append("Schedule Date : " + Convert.ToDateTime(drReportSchedule["Scheduled_Date"]).ToString(DateDisplayFormat));
                        strHTML.Append("&nbsp;&nbsp;&nbsp;&nbsp;Schedule End Date : " + Convert.ToDateTime(drReportSchedule["Schedule_End_Date"]).ToString(DateDisplayFormat));
                        strHTML.Append("<br />");
                        strHTML.Append("Recurring Period : " + drReportSchedule["Recurring_Period"]).ToString();
                        strHTML.Append("<br />");
                        strHTML.Append("Recurring Date : " + dtSchduleDate.ToString(DateDisplayFormat));

                        //Add Report Filter Criteria 
                        strHTML.Append("<br /><br />");
                        strHTML.Append("<b>Report Filters </b>");
                        strHTML.Append("<br /><br />");
                        strHTML.Append("Regions :" + strRegions.Replace("'", ""));
                        strHTML.Append("<br />");
                        strHTML.Append("Market        : " + strMarketString);
                        strHTML.Append("<br /><br />");
                        strHTML.Append("Date Of Loss : From : " + date_of_loss_from.ToString(DateDisplayFormat) + " &nbsp;&nbsp&nbsp;&nbsp; To : " + date_of_loss_to.ToString(DateDisplayFormat));
                        strHTML.Append("<br /><br />");

                        //Add Header HTML
                        strHTML.Append("<table style='font-weight: bold;' cellpadding='0' cellspacing='0' width='100%' border='0'><tr><td>");
                        strHTML.Append("<table style='font-weight: bold;' cellpadding='0' cellspacing='0' width='100%' border='1'>");
                        strHTML.Append("<tr><td style='width: 26%;' align='left'>Lag Period(Days)</td>");
                        strHTML.Append("<td style='width: 14%;' align='center'>No of Claims</td>");
                        strHTML.Append("<td style='width: 14%;' align='center'>Percentage To <br />Total Claim</td>");
                        strHTML.Append("<td style='width: 18%;' align='center'>Total<br/>Incurred Dollars</td>");
                        strHTML.Append("<td style='width: 14%;' align='center'>Percentage To <br />Total Dollars</td></tr></table>");
                        strHTML.Append("</td></tr></table>");

                        #endregion

                        //Get the no of descriptions selected
                        strHTML.Append("<table style='width: 100%;' border='1' align='left' cellpadding='4' cellspacing='0'>");
                        // get data tables from dataset
                        DataTable dtRegions = dsReport.Tables[0];
                        DataTable dtDetails = dsReport.Tables[1];
                        DataTable dtRegionTotal = dsReport.Tables[2];
                        DataTable dtGrandTotal = dsReport.Tables[3];
                        int intMedian = Convert.ToInt32(dsReport.Tables[4].Rows[0][0]);
                        if (dtDetails.Rows.Count > 0)
                        {
                            foreach (DataRow drRegion in dtRegionTotal.Rows)
                            {
                                //Add Header for Sub Report (Description wise)
                                strHTML.Append("<tr><td colspan='5' style='font-weight:bold;'>" + drRegion["Region"].ToString() + "</td></tr>");
                                DataRow[] drDetails = dtDetails.Select("Region='" + drRegion["Region"].ToString() + "'");

                                foreach (DataRow drDetail in drDetails)
                                {
                                    //Add Report Data Table 
                                    strHTML.Append("<tr><td align='left' style='width: 26%'>" + drDetail["StartLimit"] + " To " + drDetail["EndLimit"] + "</td>");
                                    strHTML.Append("<td align='right' style='width: 14%'>" + String.Format("{0:N0}", drDetail["ClaimCount"]) + "</td>");
                                    strHTML.Append("<td align='right' style='width: 14%'>" + String.Format("{0:N2}", drDetail["ClaimPercent"]) + "</td>");
                                    strHTML.Append("<td align='right' style='width: 18%'>" + String.Format("{0:C2}", drDetail["Incurred"]) + "</td>");
                                    strHTML.Append("<td align='right' style='width: 14%'>" + String.Format("{0:N2}", drDetail["IncurredPercent"]) + "</td>");
                                }
                                //Add Sub Total (Region wise)
                                strHTML.Append("<tr style='font-weight: bold;background-color: white; color: black;'><td align='left' style='width: 26%;'>Total </td>");
                                strHTML.Append("<td align='right' style='width: 14%'>" + String.Format("{0:N0}", drRegion["TotalClaims"]) + "</td>");
                                strHTML.Append("<td align='right' style='width: 14%'>" + String.Format("{0:N2}", drRegion["TotalClaimPercent"]) + "</td>");
                                strHTML.Append("<td align='right' style='width: 18%'>" + String.Format("{0:C2}", drRegion["TotalIncurred"]) + "</td>");
                                strHTML.Append("<td align='right' style='width: 14%'>" + String.Format("{0:N2}", drRegion["TotalIncurredPercent"]) + "</td></tr>");
                            }
                            strHTML.Append("</table>");
                            #region " Grand Total "
                            if (dtGrandTotal.Rows.Count > 0)
                            {
                                DataRow drTotal = dtGrandTotal.Rows[0];
                                strHTML.Append("<table style='font-weight: bold;' cellpadding='0' cellspacing='0' width='100%' border='0'><tr><td>");
                                strHTML.Append("<table style='font-weight: bold;' cellpadding='0' cellspacing='0' width='100%' border='1' style='font-weight: bold;background-color: #507CD1; color: #FFFFFF;'>");
                                strHTML.Append("<tr><td style='width: 26%;' align='left'>Total</td>");
                                strHTML.Append("<td style='width: 14%;' align='right'>" + String.Format("{0:N0}", drTotal["TotalClaims"]) + "</td>");
                                strHTML.Append("<td style='width: 14%;' align='right'>" + String.Format("{0:N2}", drTotal["TotalClaimPercent"]) + "</td>");
                                strHTML.Append("<td style='width: 18%;' align='right'>" + String.Format("{0:C2}", drTotal["TotalIncurred"]) + "</td>");
                                strHTML.Append("<td style='width: 14%;' align='right'>" + String.Format("{0:N2}", drTotal["TotalIncurredPercent"]) + "</td></tr></table>");
                                strHTML.Append("</td></tr></table>");
                            }
                            #endregion

                            strHTML.Append("<table style='width: 100%;' border='0' align='left' cellpadding='4' cellspacing='0'>");
                            strHTML.Append("<tr><td width='100%' align='left' colspan='5'><b>Median Lag Time in Days : " + intMedian + "</b></td></tr>");
                            strHTML.Append("</table>");
                        }
                        else
                        {
                            //Add No record found line for year
                            strHTML.Append("<tr><td align='left' colspan='5'>No Record Found!</td></tr></table>");
                        }

                        //Write HTML in to HtmlWriter
                        htmlWrite.WriteLine(strHTML.ToString());

                        //Send Mail
                        SendMail("Reported to Completion Lag Summary Report", "CompletionLagSummaryReport.xls", strFirstName, strLastName, strMailFrom, stringWrite, dtRecipients);
                    }
                }
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("ERROR in Lag Summary : 5, " + ex.Message);
            }
        }

        //Report 6
        private void BindFreqencyAnalysisReport(DataRow drReportSchedule)
        {
            try
            {
                decimal pK_Schedule_ID = Convert.ToDecimal(drReportSchedule["PK_Schedule"]);
                decimal Fk_RecipientList = Convert.ToDecimal(drReportSchedule["Fk_RecipientList"]);
                decimal FK_Security_Id = Convert.ToDecimal(drReportSchedule["FK_Security_Id"]);

                //Get Report criteria for the scheduled report
                DataTable dtFilter = Report.SelectFilterCriteria(6, pK_Schedule_ID).Tables[0];
                if (dtFilter.Rows.Count > 0)
                {
                    //Get the recipient from the recipient list 
                    DataTable dtRecipients = Report.SelectOneRecordWithRecipientList(Fk_RecipientList).Tables[0];

                    //Get the user who has scheduled the report
                    DataTable dtUser = Report.SelectSecurityByPK(FK_Security_Id).Tables[0];
                    String strFirstName, strLastName, strMailFrom;
                    strFirstName = strLastName = strMailFrom = "";
                    if (dtUser.Rows.Count > 0)
                    {
                        strFirstName = dtUser.Rows[0]["FIRST_NAME"].ToString();
                        strLastName = dtUser.Rows[0]["LAST_NAME"].ToString();
                        strMailFrom = dtUser.Rows[0]["Email"].ToString();

                        //Set all filters to a variable as per report type
                        String strClaim_Type = dtFilter.Rows[0]["Claim_Type"].ToString();
                        DateTime date_of_loss_from = Convert.ToDateTime(dtFilter.Rows[0]["From_Date_Of_Accident"].ToString());
                        DateTime date_of_loss_to = Convert.ToDateTime(dtFilter.Rows[0]["To_Date_Of_Accident"].ToString());

                        //Get the report data
                        DataSet dsReport = Report.GetFrequencyAnalysisData(date_of_loss_from, date_of_loss_to, strClaim_Type, FK_Security_Id);
                        // get data tables from the dataset
                        DataTable dtDetails = dsReport.Tables[0];
                        DataTable dtRegionTotal = dsReport.Tables[1];
                        DataTable dtGrandTotal = dsReport.Tables[2];

                        #region " Header "

                        //Create HTML for the report and wirte into HTML Write objec    
                        StringBuilder strHTML = new StringBuilder();
                        System.IO.StringWriter stringWrite = new System.IO.StringWriter();
                        System.Web.UI.HtmlTextWriter htmlWrite = new System.Web.UI.HtmlTextWriter(stringWrite);

                        //Add Report Title and Schedule Date
                        strHTML.Append("<br />");
                        strHTML.Append("<b>Report Title : Frequency Analysis Report</b>");
                        strHTML.Append("<br /><br />");
                        strHTML.Append("Schedule Date : " + Convert.ToDateTime(drReportSchedule["Scheduled_Date"]).ToString(DateDisplayFormat));
                        strHTML.Append("&nbsp;&nbsp;&nbsp;&nbsp;Schedule End Date : " + Convert.ToDateTime(drReportSchedule["Schedule_End_Date"]).ToString(DateDisplayFormat));
                        strHTML.Append("<br />");
                        strHTML.Append("Recurring Period : " + drReportSchedule["Recurring_Period"]).ToString();
                        strHTML.Append("<br />");
                        strHTML.Append("Recurring Date : " + dtSchduleDate.ToString(DateDisplayFormat));

                        //Add Report Filter Criteria
                        strHTML.Append("<br /><br />");
                        strHTML.Append("<b>Report Filters </b>");
                        strHTML.Append("<br /><br />");
                        strHTML.Append("Claim Types :" + GetClaimTypeString(strClaim_Type));
                        strHTML.Append("<br />");
                        strHTML.Append("Date Of Accident : From : " + date_of_loss_from.ToString(DateDisplayFormat) + " &nbsp;&nbsp&nbsp;&nbsp; To :" + date_of_loss_to.ToString(DateDisplayFormat));
                        strHTML.Append("<br /><br />");

                        //Add Header HTML
                        strHTML.Append("<table style='font-weight: bold;' cellpadding='0' cellspacing='0' width='100%' border='0'><tr><td>");
                        strHTML.Append("<table style='font-weight: bold;' cellpadding='0' cellspacing='0' width='100%' border='1'>");
                        strHTML.Append("<tr><td style='width: 20%;' align='left'>Location</td>");
                        strHTML.Append("<td style='width: 10%;' align='right'>Number of Claims</td>");
                        strHTML.Append("<td style='width: 15%;' align='right'>Percent to Total Claims</td>");
                        strHTML.Append("<td style='width: 15%;' align='right'>Total Incurred Dollars</td>");
                        strHTML.Append("<td style='width: 15%;' align='right'>Percent to Total Dollars</td>");
                        strHTML.Append("<td style='width: 15%;' align='right'>Average Cost Per Claim</td>");
                        strHTML.Append("<td style='width: 10%;' align='right'>Largest Loss</td></tr></table>");
                        strHTML.Append("</td></tr></table>");

                        #endregion

                        //Add Report Data Table 
                        strHTML.Append("<table style='width: 100%;' border='1' align='left' cellpadding='4' cellspacing='0'>");

                        if (dtDetails.Rows.Count > 0)
                        {
                            foreach (DataRow drRegion in dtRegionTotal.Rows)
                            {
                                //Add Header for Sub Report (Description wise)
                                strHTML.Append("<tr><td colspan='5' style='font-weight:bold;'>Region : " + drRegion["Region"].ToString() + "</td></tr>");
                                DataRow[] drDetails = dtDetails.Select("Region='" + drRegion["Region"].ToString() + "'");
                                foreach (DataRow drDetail in drDetails)
                                {
                                    strHTML.Append("<tr><td style='width: 20%;' align='left'>" + drDetail["dba"] + "</td>");
                                    strHTML.Append("<td style='width: 10%; align='right'>" + String.Format("{0:N0}", drDetail["ClaimCount"]) + "</td>");
                                    strHTML.Append("<td style='width: 15%;' align='right'>" + String.Format("{0:N2}", drDetail["ClaimPercent"]) + "</td>");
                                    strHTML.Append("<td style='width: 15%;' align='right'>" + String.Format("{0:C2}", drDetail["Incurred"]) + "</td>");
                                    strHTML.Append("<td style='width: 15%;' align='right'>" + String.Format("{0:N2}", drDetail["IncurredPercent"]) + "</td>");
                                    strHTML.Append("<td style='width: 15%;' align='right'>" + String.Format("{0:C2}", drDetail["AvgCostPerClaim"]) + "</td>");
                                    strHTML.Append("<td style='width: 10%;' align='right'>" + String.Format("{0:C2}", drDetail["Largest_Loss"]) + "</td></tr>");
                                }
                                //Add Sub Total (Region wise)
                                strHTML.Append("<tr style='font-weight: bold;background-color: white; color: black;'><td style='width: 20%;' align='left'>Totals</td>");
                                strHTML.Append("<td style='width: 10%; align='right'>" + String.Format("{0:N0}", drRegion["Total_ClaimCount"]) + "</td>");
                                strHTML.Append("<td style='width: 15%;' align='right'></td>");
                                strHTML.Append("<td style='width: 15%;' align='right'>" + String.Format("{0:C2}", drRegion["Total_Incurred"]) + "</td>");
                                strHTML.Append("<td style='width: 15%;' align='right'></td>");
                                strHTML.Append("<td style='width: 15%;' align='right'>" + String.Format("{0:C2}", drRegion["Total_AvgCostPerClaim"]) + "</td>");
                                strHTML.Append("<td style='width: 10%;' align='right'></td></tr>");
                            }
                            #region " Grand Total "
                            if (dtGrandTotal.Rows.Count > 0)
                            {
                                DataRow drTotal = dtGrandTotal.Rows[0];
                                strHTML.Append("<table style='font-weight: bold;' cellpadding='0' cellspacing='0' width='100%' border='0'><tr><td>");
                                strHTML.Append("<table style='font-weight: bold;' cellpadding='0' cellspacing='0' width='100%' border='1' style='font-weight: bold;background-color: #507CD1; color: #FFFFFF;'>");
                                strHTML.Append("<tr><td style='width: 20%;' align='left'>Report Grand Totals</td>");
                                strHTML.Append("<td style='width: 10%; align='right'>" + String.Format("{0:N0}", drTotal["Total_ClaimCount"]) + "</td>");
                                strHTML.Append("<td style='width: 15%;' align='right'></td>");
                                strHTML.Append("<td style='width: 15%;' align='right'>" + String.Format("{0:C2}", drTotal["Total_Incurred"]) + "</td>");
                                strHTML.Append("<td style='width: 15%;' align='right'></td>");
                                strHTML.Append("<td style='width: 15%;' align='right'>" + String.Format("{0:C2}", drTotal["Total_AvgCostPerClaim"]) + "</td>");
                                strHTML.Append("<td style='width: 10%;' align='right'></td></tr>");
                                strHTML.Append("</td></tr></table>");
                            }
                            #endregion
                        }
                        else
                        {
                            //Add No record found line for year
                            strHTML.Append("<tr><td colspan='7'>No Record Found!</td></tr>");
                        }
                        strHTML.Append("</table>");

                        //Write HTML in to HtmlWriter
                        htmlWrite.WriteLine(strHTML.ToString());

                        //Send Mail
                        SendMail("Frequency Analysis Report", "FrequencyAnalysis.xls", strFirstName, strLastName, strMailFrom, stringWrite, dtRecipients);
                    }
                }
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("ERROR in Frequency Severity Report, " + ex.Message);
            }
        }

        //Report 7
        private void BindWCCauseAnalysisReport(DataRow drReportSchedule)
        {
            try
            {
                decimal pK_Schedule_ID = Convert.ToDecimal(drReportSchedule["PK_Schedule"]);
                decimal Fk_RecipientList = Convert.ToDecimal(drReportSchedule["Fk_RecipientList"]);
                decimal FK_Security_Id = Convert.ToDecimal(drReportSchedule["FK_Security_Id"]);

                //Get Report criteria for the scheduled report
                DataTable dtFilter = Report.SelectFilterCriteria(7, pK_Schedule_ID).Tables[0];
                if (dtFilter.Rows.Count > 0)
                {
                    //Get the recipient from the recipient list 
                    DataTable dtRecipients = Report.SelectOneRecordWithRecipientList(Fk_RecipientList).Tables[0];

                    //Get the user who has scheduled the report
                    DataTable dtUser = Report.SelectSecurityByPK(FK_Security_Id).Tables[0];
                    String strFirstName, strLastName, strMailFrom;
                    strFirstName = strLastName = strMailFrom = "";
                    if (dtUser.Rows.Count > 0)
                    {
                        strFirstName = dtUser.Rows[0]["FIRST_NAME"].ToString();
                        strLastName = dtUser.Rows[0]["LAST_NAME"].ToString();
                        strMailFrom = dtUser.Rows[0]["Email"].ToString();

                        //Set all filters to a variable as per report type
                        DateTime date_of_loss_from = Convert.ToDateTime(dtFilter.Rows[0]["From_Date_Of_Accident"].ToString());
                        DateTime date_of_loss_to = Convert.ToDateTime(dtFilter.Rows[0]["To_Date_Of_Accident"].ToString());

                        //Get the report data
                        DataSet dsReport = Report.GetWCCauseAnalysisData(date_of_loss_from, date_of_loss_to, FK_Security_Id);
                        // get data tables from the dataset
                        DataTable dtDetails = dsReport.Tables[0];
                        DataTable dtRegionTotal = dsReport.Tables[1];
                        DataTable dtGrandTotal = dsReport.Tables[2];

                        #region " Header "

                        //Create HTML for the report and wirte into HTML Write objec    
                        StringBuilder strHTML = new StringBuilder();
                        System.IO.StringWriter stringWrite = new System.IO.StringWriter();
                        System.Web.UI.HtmlTextWriter htmlWrite = new System.Web.UI.HtmlTextWriter(stringWrite);

                        //Add Report Title and Schedule Date
                        strHTML.Append("<br />");
                        strHTML.Append("<b>Report Title : WC Cause Analysis Report</b>");
                        strHTML.Append("<br /><br />");
                        strHTML.Append("Schedule Date : " + Convert.ToDateTime(drReportSchedule["Scheduled_Date"]).ToString(DateDisplayFormat));
                        strHTML.Append("&nbsp;&nbsp;&nbsp;&nbsp;Schedule End Date : " + Convert.ToDateTime(drReportSchedule["Schedule_End_Date"]).ToString(DateDisplayFormat));
                        strHTML.Append("<br />");
                        strHTML.Append("Recurring Period : " + drReportSchedule["Recurring_Period"]).ToString();
                        strHTML.Append("<br />");
                        strHTML.Append("Recurring Date : " + dtSchduleDate.ToString(DateDisplayFormat));

                        //Add Report Filter Criteria
                        strHTML.Append("<br /><br />");
                        strHTML.Append("<b>Report Filters </b>");
                        strHTML.Append("<br /><br />");
                        strHTML.Append("<br />");
                        strHTML.Append("Date Of Accident : From : " + date_of_loss_from.ToString(DateDisplayFormat) + " &nbsp;&nbsp&nbsp;&nbsp; To :" + date_of_loss_to.ToString(DateDisplayFormat));
                        strHTML.Append("<br /><br />");

                        //Add Header HTML
                        strHTML.Append("<table style='font-weight: bold;' cellpadding='0' cellspacing='0' width='100%' border='0'><tr><td>");
                        strHTML.Append("<table style='font-weight: bold;' cellpadding='0' cellspacing='0' width='100%' border='1'>");
                        strHTML.Append("<tr><td style='width: 20%;' align='left'>Cause of Claim</td>");
                        strHTML.Append("<td style='width: 10%;' align='right'>Number of Claims</td>");
                        strHTML.Append("<td style='width: 15%;' align='right'>Percent to Total Claims</td>");
                        strHTML.Append("<td style='width: 15%;' align='right'>Total Incurred Dollars</td>");
                        strHTML.Append("<td style='width: 15%;' align='right'>Percent to Total Dollars</td>");
                        strHTML.Append("<td style='width: 15%;' align='right'>Average Cost Per Claim</td>");
                        strHTML.Append("<td style='width: 10%;' align='right'>Largest Loss</td></tr></table>");
                        strHTML.Append("</td></tr></table>");

                        #endregion

                        //Add Report Data Table 
                        strHTML.Append("<table style='width: 100%;' border='1' align='left' cellpadding='4' cellspacing='0'>");

                        if (dtDetails.Rows.Count > 0)
                        {
                            foreach (DataRow drRegion in dtRegionTotal.Rows)
                            {
                                //Add Header for Sub Report (Description wise)
                                strHTML.Append("<tr><td colspan='5' style='font-weight:bold;'>Region : " + drRegion["Region"].ToString() + "</td></tr>");
                                DataRow[] drDetails = dtDetails.Select("Region='" + drRegion["Region"].ToString() + "'");
                                foreach (DataRow drDetail in drDetails)
                                {
                                    strHTML.Append("<tr><td style='width: 20%;' align='left'>" + drDetail["Description"] + "</td>");
                                    strHTML.Append("<td style='width: 10%; align='right'>" + String.Format("{0:N0}", drDetail["ClaimCount"]) + "</td>");
                                    strHTML.Append("<td style='width: 15%;' align='right'>" + String.Format("{0:N2}", drDetail["ClaimPercent"]) + "</td>");
                                    strHTML.Append("<td style='width: 15%;' align='right'>" + String.Format("{0:C2}", drDetail["Incurred"]) + "</td>");
                                    strHTML.Append("<td style='width: 15%;' align='right'>" + String.Format("{0:N2}", drDetail["IncurredPercent"]) + "</td>");
                                    strHTML.Append("<td style='width: 15%;' align='right'>" + String.Format("{0:C2}", drDetail["AvgCostPerClaim"]) + "</td>");
                                    strHTML.Append("<td style='width: 10%;' align='right'>" + String.Format("{0:C2}", drDetail["Largest_Loss"]) + "</td></tr>");
                                }
                                //Add Sub Total (Region wise)
                                strHTML.Append("<tr style='font-weight: bold;background-color: white; color: black;'><td style='width: 20%;' align='left'>Totals</td>");
                                strHTML.Append("<td style='width: 10%; align='right'>" + String.Format("{0:N0}", drRegion["Total_ClaimCount"]) + "</td>");
                                strHTML.Append("<td style='width: 15%;' align='right'></td>");
                                strHTML.Append("<td style='width: 15%;' align='right'>" + String.Format("{0:C2}", drRegion["Total_Incurred"]) + "</td>");
                                strHTML.Append("<td style='width: 15%;' align='right'></td>");
                                strHTML.Append("<td style='width: 15%;' align='right'>" + String.Format("{0:C2}", drRegion["Total_AvgCostPerClaim"]) + "</td>");
                                strHTML.Append("<td style='width: 10%;' align='right'></td></tr>");
                            }
                            #region " Grand Total "
                            if (dtGrandTotal.Rows.Count > 0)
                            {
                                DataRow drTotal = dtGrandTotal.Rows[0];
                                strHTML.Append("<table style='font-weight: bold;' cellpadding='0' cellspacing='0' width='100%' border='0'><tr><td>");
                                strHTML.Append("<table style='font-weight: bold;' cellpadding='0' cellspacing='0' width='100%' border='1' style='font-weight: bold;background-color: #507CD1; color: #FFFFFF;'>");
                                strHTML.Append("<tr><td style='width: 20%;' align='left'>Report Grand Totals</td>");
                                strHTML.Append("<td style='width: 10%; align='right'>" + String.Format("{0:N0}", drTotal["Total_ClaimCount"]) + "</td>");
                                strHTML.Append("<td style='width: 15%;' align='right'></td>");
                                strHTML.Append("<td style='width: 15%;' align='right'>" + String.Format("{0:C2}", drTotal["Total_Incurred"]) + "</td>");
                                strHTML.Append("<td style='width: 15%;' align='right'></td>");
                                strHTML.Append("<td style='width: 15%;' align='right'>" + String.Format("{0:C2}", drTotal["Total_AvgCostPerClaim"]) + "</td>");
                                strHTML.Append("<td style='width: 10%;' align='right'></td></tr>");
                                strHTML.Append("</td></tr></table>");
                            }
                            #endregion
                        }
                        else
                        {
                            //Add No record found line for year
                            strHTML.Append("<tr><td colspan='7'>No Record Found!</td></tr>");
                        }
                        strHTML.Append("</table>");

                        //Write HTML in to HtmlWriter
                        htmlWrite.WriteLine(strHTML.ToString());

                        //Send Mail
                        SendMail("WC Cause Analysis Report", "WCCauseAnalysis.xls", strFirstName, strLastName, strMailFrom, stringWrite, dtRecipients);
                    }
                }
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("ERROR in Frequency Severity Report, " + ex.Message);
            }
        }

        //Report 8
        private void BindLossLimitationReport(DataRow drReportSchedule)
        {
            try
            {
                decimal pK_Schedule_ID = Convert.ToDecimal(drReportSchedule["PK_Schedule"]);
                decimal Fk_RecipientList = Convert.ToDecimal(drReportSchedule["Fk_RecipientList"]);
                decimal FK_Security_Id = Convert.ToDecimal(drReportSchedule["FK_Security_Id"]);

                //Get Report criteria for the scheduled report
                DataTable dtFilter = Report.SelectFilterCriteria(8, pK_Schedule_ID).Tables[0];
                if (dtFilter.Rows.Count > 0)
                {
                    //Get the recipient from the recipient list
                    DataTable dtRecipients = Report.SelectOneRecordWithRecipientList(Fk_RecipientList).Tables[0];

                    //Get the user who has scheduled the report
                    DataTable dtUser = Report.SelectSecurityByPK(FK_Security_Id).Tables[0];
                    String strFirstName, strLastName, strMailFrom;
                    strFirstName = strLastName = strMailFrom = "";
                    if (dtUser.Rows.Count > 0)
                    {
                        strFirstName = dtUser.Rows[0]["FIRST_NAME"].ToString();
                        strLastName = dtUser.Rows[0]["LAST_NAME"].ToString();
                        strMailFrom = dtUser.Rows[0]["Email"].ToString();

                        //Set all filters to a variable as per report type
                        String strClaim_Type = dtFilter.Rows[0]["Claim_Type"].ToString();

                        //Get the report data
                        DataSet dsReport = Report.GetLossLimitationData(Convert.ToDateTime(dtFilter.Rows[0]["From_Date_Of_Loss1"]), Convert.ToDateTime(dtFilter.Rows[0]["To_Date_Of_Loss1"]), Convert.ToDecimal(dtFilter.Rows[0]["limit1"])
                            , dtFilter.Rows[0]["From_Date_Of_Loss2"] == DBNull.Value ? Convert.ToDateTime(System.Data.SqlTypes.SqlDateTime.MaxValue.ToString()) : Convert.ToDateTime(dtFilter.Rows[0]["From_Date_Of_Loss2"]), dtFilter.Rows[0]["To_Date_Of_Loss2"] == DBNull.Value ? Convert.ToDateTime(System.Data.SqlTypes.SqlDateTime.MinValue.ToString()) : Convert.ToDateTime(dtFilter.Rows[0]["To_Date_Of_Loss2"]), dtFilter.Rows[0]["limit2"] == DBNull.Value ? 0 : Convert.ToDecimal(dtFilter.Rows[0]["limit2"])
                            , dtFilter.Rows[0]["From_Date_Of_Loss3"] == DBNull.Value ? Convert.ToDateTime(System.Data.SqlTypes.SqlDateTime.MaxValue.ToString()) : Convert.ToDateTime(dtFilter.Rows[0]["From_Date_Of_Loss3"]), dtFilter.Rows[0]["To_Date_Of_Loss3"] == DBNull.Value ? Convert.ToDateTime(System.Data.SqlTypes.SqlDateTime.MinValue.ToString()) : Convert.ToDateTime(dtFilter.Rows[0]["To_Date_Of_Loss3"]), dtFilter.Rows[0]["limit3"] == DBNull.Value ? 0 : Convert.ToDecimal(dtFilter.Rows[0]["limit3"])
                            , strClaim_Type, FK_Security_Id);

                        // get data tables from the dataset
                        DataTable dtRegions = dsReport.Tables[0];
                        DataTable dtDetails = dsReport.Tables[1];
                        DataTable dtRegionTotal = dsReport.Tables[2];
                        DataTable dtGrandTotal = dsReport.Tables[3];

                        //Create HTML for the report and wirte into HTML Write object
                        Int32 rangeCount = 1;
                        StringBuilder strHTML = new StringBuilder();
                        System.IO.StringWriter stringWrite = new System.IO.StringWriter();
                        System.Web.UI.HtmlTextWriter htmlWrite = new System.Web.UI.HtmlTextWriter(stringWrite);

                        #region " Header "

                        //Add Report Title and Schedule Date
                        strHTML.Append("<br />");
                        strHTML.Append("<b>Report Title : Loss Limitation Report</b>");
                        strHTML.Append("<br /><br />");
                        strHTML.Append("Schedule Date : " + Convert.ToDateTime(drReportSchedule["Scheduled_Date"]).ToString(DateDisplayFormat));
                        strHTML.Append("&nbsp;&nbsp;&nbsp;&nbsp;Schedule End Date : " + Convert.ToDateTime(drReportSchedule["Schedule_End_Date"]).ToString(DateDisplayFormat));
                        strHTML.Append("<br />");
                        strHTML.Append("Recurring Period : " + drReportSchedule["Recurring_Period"]).ToString();
                        strHTML.Append("<br />");
                        strHTML.Append("Recurring Date : " + dtSchduleDate.ToString(DateDisplayFormat));

                        //Add Report Filter Criteria 
                        strHTML.Append("<br /><br />");
                        strHTML.Append("<b>Report Filters </b>");
                        strHTML.Append("<br /><br />");
                        strHTML.Append("Claim Types :" + GetClaimTypeString(strClaim_Type));
                        strHTML.Append("<br />");
                        strHTML.Append("Accident Date Range " + rangeCount.ToString() + " : From : " + Convert.ToDateTime(dtFilter.Rows[0]["From_Date_Of_Loss1"]).ToString(DateDisplayFormat) + " &nbsp;&nbsp;&nbsp&nbsp; TO : " + Convert.ToDateTime(dtFilter.Rows[0]["To_Date_Of_Loss1"]).ToString(DateDisplayFormat) + " &nbsp;&nbsp&nbsp;&nbsp; Limit : " + String.Format("{0:f}", dtFilter.Rows[0]["limit1"]));
                        if (Convert.ToDateTime(dtFilter.Rows[0]["From_Date_Of_Loss2"]) != Convert.ToDateTime(System.Data.SqlTypes.SqlDateTime.MinValue.ToString()))
                        {
                            rangeCount++;
                            strHTML.Append("<br />Accident Date Range " + rangeCount.ToString() + " : From : " + Convert.ToDateTime(dtFilter.Rows[0]["From_Date_Of_Loss2"]).ToString(DateDisplayFormat) + " &nbsp;&nbsp&nbsp;&nbsp; TO : " + Convert.ToDateTime(dtFilter.Rows[0]["To_Date_Of_Loss2"]).ToString(DateDisplayFormat) + "  &nbsp;&nbsp;&nbsp&nbsp; Limit : " + String.Format("{0:f}", dtFilter.Rows[0]["limit2"]));
                        }
                        if (Convert.ToDateTime(dtFilter.Rows[0]["From_Date_Of_Loss3"]) != Convert.ToDateTime(System.Data.SqlTypes.SqlDateTime.MinValue.ToString()))
                        {
                            rangeCount++;
                            strHTML.Append("<br />Accident Date Range " + rangeCount.ToString() + " : From : " + Convert.ToDateTime(dtFilter.Rows[0]["From_Date_Of_Loss3"]).ToString(DateDisplayFormat) + " &nbsp;&nbsp;&nbsp&nbsp; TO : " + Convert.ToDateTime(dtFilter.Rows[0]["To_Date_Of_Loss3"]).ToString(DateDisplayFormat) + " &nbsp;&nbsp;&nbsp&nbsp; Limit : " + String.Format("{0:f}", dtFilter.Rows[0]["limit3"]));
                        }
                        strHTML.Append("<br /><br />");

                        //Add Header HTML
                        strHTML.Append("<table style='font-weight: bold;' cellpadding='0' cellspacing='0' width='100%' border='0'><tr><td>");
                        strHTML.Append("<table style='font-weight: bold;' cellpadding='0' cellspacing='0' width='100%' border='1'>");
                        strHTML.Append("<tr><td style='width: 30%;' align='left'>Location</td>");
                        strHTML.Append("<td style='width: 15%;' align='right'>Claim Count</td>");
                        strHTML.Append("<td style='width: 20%;' align='right'>Total Incurred Dollars</td>");
                        strHTML.Append("<td style='width: 20%;' align='right'>Limited Incurred</td>");
                        strHTML.Append("<td style='width: 15%;' align='right'>Excess</td></tr></table>");
                        strHTML.Append("</td></tr></table>");

                        #endregion

                        //Add Report Data Table 
                        strHTML.Append("<table style='width: 100%;' border='1' align='left' cellpadding='4' cellspacing='0'>");

                        if (dtDetails.Rows.Count > 0)
                        {
                            foreach (DataRow drRegion in dtRegionTotal.Rows)
                            {
                                //Add Header for Sub Report (Description wise)
                                strHTML.Append("<tr><td colspan='5' style='font-weight:bold;'>" + drRegion["Region"].ToString() + "</td></tr>");
                                DataRow[] drDetails = dtDetails.Select("Region='" + drRegion["Region"].ToString() + "'");
                                foreach (DataRow drDetail in drDetails)
                                {
                                    strHTML.Append("<tr><td style='width: 30%;' align='left'>" + drDetail["dba"] + "</td>");
                                    strHTML.Append("<td style='width: 15%; align='right'>" + String.Format("{0:N0}", drDetail["ClaimCount"]) + "</td>");
                                    strHTML.Append("<td style='width: 20%;' align='right'>" + String.Format("{0:C2}", drDetail["TotalIncurred"]) + "</td>");
                                    strHTML.Append("<td style='width: 20%;' align='right'>" + String.Format("{0:C2}", drDetail["LimitedIncurred"]) + "</td>");
                                    strHTML.Append("<td style='width: 15%;' align='right'>" + String.Format("{0:C2}", drDetail["Excess"]) + "</td></tr>");
                                }
                                //Add Sub Total (Region wise)
                                strHTML.Append("<tr style='font-weight: bold;background-color: white; color: black;'><td style='width: 30%;' align='left'>Sub Totals</td>");
                                strHTML.Append("<td style='width: 15%; align='right'>" + String.Format("{0:N0}", drRegion["TotalClaimCount"]) + "</td>");
                                strHTML.Append("<td style='width: 20%;' align='right'>" + String.Format("{0:C2}", drRegion["TotalIncurred"]) + "</td>");
                                strHTML.Append("<td style='width: 20%;' align='right'>" + String.Format("{0:C2}", drRegion["TotalLimitedIncurred"]) + "</td>");
                                strHTML.Append("<td style='width: 15%;' align='right'>" + String.Format("{0:C2}", drRegion["TotalExcess"]) + "</td></tr>");
                            }
                            #region " Grand Total "
                            if (dtGrandTotal.Rows.Count > 0)
                            {
                                DataRow drTotal = dtGrandTotal.Rows[0];
                                strHTML.Append("<table style='font-weight: bold;' cellpadding='0' cellspacing='0' width='100%' border='0'><tr><td>");
                                strHTML.Append("<table style='font-weight: bold;' cellpadding='0' cellspacing='0' width='100%' border='1' style='font-weight: bold;background-color: #507CD1; color: #FFFFFF;'>");
                                strHTML.Append("<tr><td style='width: 20%;' align='left'>Report Grand Total</td>");
                                strHTML.Append("<td style='width: 15%; align='right'>" + String.Format("{0:N0}", drTotal["TotalClaimCount"]) + "</td>");
                                strHTML.Append("<td style='width: 20%;' align='right'>" + String.Format("{0:C2}", drTotal["TotalIncurred"]) + "</td>");
                                strHTML.Append("<td style='width: 20%;' align='right'>" + String.Format("{0:C2}", drTotal["TotalLimitedIncurred"]) + "</td>");
                                strHTML.Append("<td style='width: 15%;' align='right'>" + String.Format("{0:C2}", drTotal["TotalExcess"]) + "</td></tr>");
                                strHTML.Append("</td></tr></table>");
                            }
                            #endregion
                        }
                        else
                        {
                            //Add No record found line for year
                            strHTML.Append("<tr><td colspan='5'>No Record Found!</td></tr>");
                        }
                        strHTML.Append("</table>");

                        //Write HTML in to HtmlWriter
                        htmlWrite.WriteLine(strHTML.ToString());

                        //Send Mail
                        SendMail("Loss Limitation Report", "LossLimitation.xls", strFirstName, strLastName, strMailFrom, stringWrite, dtRecipients);
                    }
                }
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("ERROR in Loss Limitation Report, " + ex.Message);
            }
        }

        //Report 9
        private void BindLossStratificationReport(DataRow drReportSchedule)
        {
            try
            {
                decimal pK_Schedule_ID = Convert.ToDecimal(drReportSchedule["PK_Schedule"]);
                decimal Fk_RecipientList = Convert.ToDecimal(drReportSchedule["Fk_RecipientList"]);
                decimal FK_Security_Id = Convert.ToDecimal(drReportSchedule["FK_Security_Id"]);

                //Get Report criteria for the scheduled report
                DataTable dtFilter = Report.SelectFilterCriteria(9, pK_Schedule_ID).Tables[0];
                if (dtFilter.Rows.Count > 0)
                {
                    //Get the recipient from the recipient list 
                    DataTable dtRecipients = Report.SelectOneRecordWithRecipientList(Fk_RecipientList).Tables[0];

                    //Get the user who has scheduled the report
                    DataTable dtUser = Report.SelectSecurityByPK(FK_Security_Id).Tables[0];
                    String strFirstName, strLastName, strMailFrom;
                    strFirstName = strLastName = strMailFrom = "";
                    if (dtUser.Rows.Count > 0)
                    {
                        strFirstName = dtUser.Rows[0]["FIRST_NAME"].ToString();
                        strLastName = dtUser.Rows[0]["LAST_NAME"].ToString();
                        strMailFrom = dtUser.Rows[0]["Email"].ToString();

                        //Set all filters to a variable as per report type
                        String strPolicy_Year = dtFilter.Rows[0]["Policy_Year"].ToString();
                        String strClaim_Type = dtFilter.Rows[0]["Claim_Type"].ToString();

                        //Get the report data
                        DataSet dsReport = Report.GetLossStratificationData(strPolicy_Year, strClaim_Type, FK_Security_Id);
                        // get data tables from dataset
                        DataTable dtClaimTotals = dsReport.Tables[0];
                        DataTable dtDetails = dsReport.Tables[1];
                        DataTable dtYearTotals = dsReport.Tables[2];
                        // used for calculating grand totals
                        double _dblGrandClaimCount, _dblGrandIncurredCount;
                        _dblGrandClaimCount = 0.0; _dblGrandIncurredCount = 0.0;
                        if (dtYearTotals.Rows.Count > 0)
                        {
                            _dblGrandClaimCount = Convert.ToDouble(dtYearTotals.Compute("SUM(ClaimCount)", ""));
                            _dblGrandIncurredCount = Convert.ToDouble(dtYearTotals.Compute("SUM(TotalIncurred)", ""));
                        }
                        //Create HTML for the report and wirte into HTML Write object
                        StringBuilder strHTML = new StringBuilder();
                        System.IO.StringWriter stringWrite = new System.IO.StringWriter();
                        System.Web.UI.HtmlTextWriter htmlWrite = new System.Web.UI.HtmlTextWriter(stringWrite);

                        #region " Header "
                        //Add Report Title and Schedule Date
                        strHTML.Append("<br />");
                        strHTML.Append("<b>Report Title : Loss Stratification Report</b>");
                        strHTML.Append("<br /><br />");
                        strHTML.Append("Schedule Date : " + Convert.ToDateTime(drReportSchedule["Scheduled_Date"]).ToString(DateDisplayFormat));
                        strHTML.Append("&nbsp;&nbsp;&nbsp;&nbsp;Schedule End Date : " + Convert.ToDateTime(drReportSchedule["Schedule_End_Date"]).ToString(DateDisplayFormat));
                        strHTML.Append("<br />");
                        strHTML.Append("Recurring Period : " + drReportSchedule["Recurring_Period"]).ToString();
                        strHTML.Append("<br />");
                        strHTML.Append("Recurring Date : " + dtSchduleDate.ToString(DateDisplayFormat));

                        //Add Report Filter Criteria 
                        strHTML.Append("<br /><br />");
                        strHTML.Append("<b>Report Filters </b>");
                        strHTML.Append("<br /><br />");
                        strHTML.Append("Accident Year :" + strPolicy_Year);
                        strHTML.Append("<br />");
                        strHTML.Append("Claim Types   :" + GetClaimTypeString(strClaim_Type));
                        strHTML.Append("<br /><br />");

                        //Add Header HTML
                        strHTML.Append("<table width='100%' cellpadding='0' cellspacing='0'><tr><td>");
                        strHTML.Append("<table width='100%' cellpadding='0' cellspacing='0'><tr><td>");
                        strHTML.Append("<table width='100%' cellpadding='0' cellspacing='0'><tr><td>");
                        strHTML.Append("<table width='100%' cellpadding='0' cellspacing='0' style='font-weight: bold;' border='1'><tr>");
                        strHTML.Append("<td align='center' style='width: 50%;' valign='middle'>Claim Size (in $)</td>");
                        strHTML.Append("<td align='center'>Number Of Claims</td>");
                        strHTML.Append("<td style='width: 12%' align='center'>Percent To<br />Total Claim</td>");
                        strHTML.Append("<td style='width: 16%' align='center'>Total<br />Incurred Dollars</td>");
                        strHTML.Append("<td style='width: 10%' align='center'>Percent To<br />Total Dollar</td>");
                        strHTML.Append("</tr></table>");
                        strHTML.Append("</td></tr></table>");
                        strHTML.Append("</td></tr></table>");
                        strHTML.Append("</td></tr></table>");

                        #endregion

                        strHTML.Append("<table style='width: 100%;' border='1' align='left' cellpadding='4' cellspacing='0'>");
                        if (dtYearTotals.Rows.Count > 0)
                        {
                            #region " List Accident Years "
                            foreach (DataRow drYear in dtYearTotals.Rows)
                            {
                                //Add Header for Sub Report (Year wise)
                                strHTML.Append("<tr><td width='100%' align='left' colspan='5'>");
                                strHTML.Append("<span style='color: Chocolate; font-weight: bold;'>Year - " + drYear["AccidentYear"].ToString() + "</span>");
                                strHTML.Append("</td></tr><tr><td align='left' colspan='5'>");
                                strHTML.Append("<table cellspacing='0' cellpadding='0' align='Left' border='1' style='width: 100%;border-collapse: collapse;'>");
                                DataRow[] drClaimTotals = dtClaimTotals.Select("AccidentYear='" + drYear["AccidentYear"].ToString() + "'");
                                #region " List Claim Types for Accident Year "

                                foreach (DataRow drClaimTotal in drClaimTotals)
                                {
                                    strHTML.Append("<tr><td align='left' style='width: 100%;' colspan='5'><table cellpadding='0' cellspacing='0' width='100%'>");
                                    strHTML.Append("<tr><td width='100%' align='left' colspan='5'><b>Claim Type - " + drClaimTotal["Claim_Type"].ToString() + "</b></td></tr>");
                                    strHTML.Append("<tr><td align='Left' colspan='5'><table style='width: 100%;' border='1' align='left' cellpadding='4' cellspacing='0'>");
                                    DataRow[] drDetails = dtDetails.Select("AccidentYear='" + drYear["AccidentYear"].ToString() + "' and Claim_Type = '" + drClaimTotal["Claim_Type"].ToString() + "'");

                                    if (drDetails.Length > 0)
                                    {
                                        #region " Print Details "
                                        foreach (DataRow drDetail in drDetails)
                                        {
                                            string strClaimSize = "";
                                            if (Convert.ToDecimal(drDetail["EndLimit"]) <= 0.01m) strClaimSize = "Less than 0.01";
                                            else if (Convert.ToDecimal(drDetail["StartLimit"]) >= 500000.01m) strClaimSize = "Greater than " + (string.Format("{0:0,0.00}", 500000.00m));
                                            else strClaimSize = string.Format("{0:0,0.00}", drDetail["StartLimit"]) + " To " + string.Format("{0:0,0.00}", drDetail["EndLimit"]);

                                            strHTML.Append("<tr>");
                                            strHTML.Append("<td align='left' style='width: 50%;' valign='middle'>" + strClaimSize + "</td>");
                                            strHTML.Append("<td align='right'>" + String.Format("{0:N0}", drDetail["ClaimCount"]) + "</td>");
                                            strHTML.Append("<td align='right' style='width: 12%'>" + String.Format("{0:N2}", drDetail["ClaimPercent"]) + "</td>");
                                            strHTML.Append("<td style='width: 16%' align='right'>" + String.Format("{0:C2}", drDetail["Incurred"]) + "</td>");
                                            strHTML.Append("<td align='right' style='width: 10%'>" + String.Format("{0:N2}", drDetail["IncurredPercent"]) + "</td>");
                                            strHTML.Append("</tr>");
                                        }
                                        #endregion
                                        strHTML.Append("</table></td></tr></table></td></tr>");
                                        #region " Print Claim-wise sub totals "
                                        DataRow[] drTotals = dtClaimTotals.Select("AccidentYear='" + drYear["AccidentYear"].ToString() + "' and Claim_Type = '" + drClaimTotal["Claim_Type"].ToString() + "'");
                                        DataRow drTotal = drTotals[0];

                                        // print sub totals for Accident Year
                                        strHTML.Append("<tr style='color: Black; font-weight: bold;'>");
                                        strHTML.Append("<td align='left' style='width: 50%;'>Total Claim Type : " + drTotal["Claim_Type"].ToString() + "</td>");
                                        strHTML.Append("<td align='right' >" + String.Format("{0:N0}", drTotal["ClaimCount"]) + "</td>");
                                        strHTML.Append("<td align='right' style='width: 12%;'>100.00</td>");
                                        strHTML.Append("<td align='right' style='width: 16%;'>" + string.Format("{0:C2}", drTotal["TotalIncurred"]) + "</td>");
                                        strHTML.Append("<td align='right' style='width: 10%'>100.00</td>");
                                        strHTML.Append("</tr>");
                                        #endregion
                                    }
                                    else
                                    {
                                        strHTML.Append("<tr><td align='left' colspan='5'>No Record Found!</td></tr></table></td></tr></table></td></tr>");
                                    }
                                }

                                #region " Print Year-wise totals "
                                double _dblGrandClaimPercent = (_dblGrandClaimCount != 0) ? System.Math.Round(Convert.ToDouble(drYear["ClaimCount"]) * 100 / _dblGrandClaimCount, 2) : 0.00;
                                double _dblGrandIncurredPercent = (_dblGrandIncurredCount != 0) ? System.Math.Round(Convert.ToDouble(drYear["TotalIncurred"]) * 100 / _dblGrandIncurredCount, 2) : 0.00;
                                // print sub totals for Accident Year
                                strHTML.Append("<tr style='color: Black; font-weight: bold;'>");
                                strHTML.Append("<td align='left'  style='width: 50%;'>Total Accident Year : " + drYear["AccidentYear"].ToString() + "</td>");
                                strHTML.Append("<td align='right'>" + String.Format("{0:N0}", drYear["ClaimCount"]) + "</td>");
                                strHTML.Append("<td align='right' style='width: 12%;'>" + string.Format("{0:0.00}", _dblGrandClaimPercent) + "</td>");
                                strHTML.Append("<td align='right' style='width: 16%;'>" + string.Format("{0:C2}", drYear["TotalIncurred"]) + "</td>");
                                strHTML.Append("<td align='right' style='width: 10%'>" + string.Format("{0:0.00}", _dblGrandIncurredPercent) + "</td>");
                                strHTML.Append("</tr></table></td></tr>");
                                #endregion

                                #endregion

                            }
                            strHTML.Append("</table>");
                            #endregion
                            #region " Print Grand Totals "
                            if (dtYearTotals.Rows.Count > 0)
                            {
                                strHTML.Append("<table width='100%' cellpadding='0' cellspacing='0'><tr><td>");
                                strHTML.Append("<table width='100%' cellpadding='0' cellspacing='0'><tr><td>");
                                strHTML.Append("<table width='100%' cellpadding='0' cellspacing='0'><tr><td>");
                                strHTML.Append("<table width='100%' style='font-weight: bold; background-color: #507CD1;color: White;' border='1'><tr>");
                                strHTML.Append("<td align='left' style='width: 50%;' valign='middle'>Report Grand Total</td>");
                                strHTML.Append("<td align='right'>" + String.Format("{0:N0}", _dblGrandClaimCount) + "</td>");
                                strHTML.Append("<td align='right' style='width: 12%'>100.00</td>");
                                strHTML.Append("<td style='width: 16%' align='right'>" + String.Format("{0:C2}", _dblGrandIncurredCount) + "</td>");
                                strHTML.Append("<td align='right' style='width: 10%'>100.00</td>");
                                strHTML.Append("</tr></table>");
                                strHTML.Append("</td></tr></table>");
                                strHTML.Append("</td></tr></table>");
                                strHTML.Append("</td></tr></table>");
                            }
                            #endregion
                        }
                        else
                        {
                            //Add No record found line for year
                            strHTML.Append("<tr><td align='left' colspan='5'>No Record Found!</td></tr></table>");
                        }


                        //Write HTML in to HtmlWriter
                        htmlWrite.WriteLine(strHTML.ToString());

                        //Send Mail
                        SendMail("Loss Stratification Report", "LossStratification.xls", strFirstName, strLastName, strMailFrom, stringWrite, dtRecipients);
                    }
                }
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("ERROR in Loss Stratification Report, " + ex.Message);
            }
        }

        //Report 10
        private void BindDetailPITReport(DataRow drReportSchedule)
        {
            try
            {
                decimal pK_Schedule_ID = Convert.ToDecimal(drReportSchedule["PK_Schedule"]);
                decimal Fk_RecipientList = Convert.ToDecimal(drReportSchedule["Fk_RecipientList"]);
                decimal FK_Security_Id = Convert.ToDecimal(drReportSchedule["FK_Security_Id"]);

                //Get Report criteria for the scheduled report
                DataTable dtFilter = Report.SelectFilterCriteria(10, pK_Schedule_ID).Tables[0];
                if (dtFilter.Rows.Count > 0)
                {
                    //Get the recipient from the recipient list 
                    DataTable dtRecipients = Report.SelectOneRecordWithRecipientList(Fk_RecipientList).Tables[0];

                    //Get the user who has scheduled the report
                    DataTable dtUser = Report.SelectSecurityByPK(FK_Security_Id).Tables[0];
                    String strFirstName, strLastName, strMailFrom;
                    strFirstName = strLastName = strMailFrom = "";
                    if (dtUser.Rows.Count > 0)
                    {
                        strFirstName = dtUser.Rows[0]["FIRST_NAME"].ToString();
                        strLastName = dtUser.Rows[0]["LAST_NAME"].ToString();
                        strMailFrom = dtUser.Rows[0]["Email"].ToString();

                        //Set all filters to a variable as per report type
                        String strClaim_Type = dtFilter.Rows[0]["Claim_Type"].ToString();
                        DateTime date_of_loss_from = Convert.ToDateTime(dtFilter.Rows[0]["From_Date_Of_Loss"]);
                        DateTime date_of_loss_to = Convert.ToDateTime(dtFilter.Rows[0]["To_Date_Of_Loss"]);
                        DateTime date_of_compare_first = Convert.ToDateTime(dtFilter.Rows[0]["Compare_First_Date"]);
                        DateTime date_of_compare_second = Convert.ToDateTime(dtFilter.Rows[0]["Compare_Second_Date"]);

                        //Get the report data
                        DataSet dsReport = Report.GetPointInTimeDetailData(date_of_compare_first, date_of_compare_second, date_of_loss_from, date_of_loss_to, strClaim_Type, FK_Security_Id);

                        //Create HTML for the report and wirte into HTML Write object
                        StringBuilder strHTML = new StringBuilder();
                        System.IO.StringWriter stringWrite = new System.IO.StringWriter();
                        System.Web.UI.HtmlTextWriter htmlWrite = new System.Web.UI.HtmlTextWriter(stringWrite);

                        #region " Header "

                        //Add Report Title and Schedule Date
                        strHTML.Append("<br />");
                        strHTML.Append("<b>Report Title : Point-in-Time Detail Report</b>");
                        strHTML.Append("<br /><br />");
                        strHTML.Append("Schedule Date : " + Convert.ToDateTime(drReportSchedule["Scheduled_Date"]).ToString(DateDisplayFormat));
                        strHTML.Append("&nbsp;&nbsp;&nbsp;&nbsp;Schedule End Date : " + Convert.ToDateTime(drReportSchedule["Schedule_End_Date"]).ToString(DateDisplayFormat));
                        strHTML.Append("<br />");
                        strHTML.Append("Recurring Period : " + drReportSchedule["Recurring_Period"]).ToString();
                        strHTML.Append("<br />");
                        strHTML.Append("Recurring Date : " + dtSchduleDate.ToString(DateDisplayFormat));

                        //Add Report Filter Criteria
                        strHTML.Append("<br /><br />");
                        strHTML.Append("<b>Report Filters </b>");
                        strHTML.Append("<br /><br />");
                        strHTML.Append("Comparison Dates :  First : " + date_of_compare_first.ToString(DateDisplayFormat) + " &nbsp;&nbsp&nbsp;&nbsp;  Second : " + date_of_compare_second.ToString(DateDisplayFormat));
                        strHTML.Append("<br />");
                        strHTML.Append("Accident Date : From : " + date_of_loss_from.ToString(DateDisplayFormat) + " &nbsp;&nbsp&nbsp;&nbsp; To : " + date_of_loss_to.ToString(DateDisplayFormat));
                        strHTML.Append("<br />");
                        strHTML.Append("Claim Types :" + GetClaimTypeString(strClaim_Type));
                        strHTML.Append("<br /><br />");

                        //Add Header HTML
                        strHTML.Append("<table style='font-weight: bold;' cellpadding='0' cellspacing='0' width='100%' border='1'>");
                        strHTML.Append("<tr align='right' valign='bottom'>");
                        strHTML.Append("<td align='left'>Claim Number/Name</td>");
                        strHTML.Append("<td align='left'>Accident Date</td>");
                        strHTML.Append("<td>&nbsp;</td>");
                        strHTML.Append("<td align='right'>" + date_of_compare_first.ToString(DateDisplayFormat) + " <br /> Total Dollars</td>");
                        strHTML.Append("<td align='right'>" + date_of_compare_second.ToString(DateDisplayFormat) + " <br /> Total Dollars</td>");
                        strHTML.Append("<td align='right'>Difference</td>");
                        strHTML.Append("</tr></table>");

                        #endregion

                        //Add Report Data
                        strHTML.Append("<table style='width: 100%;' border='1' align='left' cellpadding='4' cellspacing='0'>");
                        DataTable dtReport = dsReport.Tables[0];
                        if (dtReport.Rows.Count > 0)
                        {
                            for (int i = 0; i < dtReport.Rows.Count; i++)
                            {
                                strHTML.Append("<tr align='left'><td><span style='text-decoration: underline;'>" + dtReport.Rows[i]["origin_claim_number"].ToString() + "</span><br>" + dtReport.Rows[i]["Name"].ToString() + "</td>");
                                strHTML.Append("<td style='width: 70px;' valign='middle'><br />" + Convert.ToDateTime(dtReport.Rows[i]["Date_Of_Accident"]).ToString(DateDisplayFormat) + "<br /><br /></span></td>");
                                strHTML.Append("<td style='width: 90px;' align='right'>Incurred:<br>Paid:<br>Outstandings:<br></td>");
                                strHTML.Append("<td style='width: 100px;' align='right'>" + String.Format("{0:C2}", dtReport.Rows[i]["Incurred_1"]) + "<br>" + String.Format("{0:C2}", dtReport.Rows[i]["Paid_1"]) + "<br>" + String.Format("{0:C2}", dtReport.Rows[i]["Outstanding_1"]) + "<br></td>");
                                strHTML.Append("<td style='width: 100px;' align='right'>" + String.Format("{0:C2}", dtReport.Rows[i]["Incurred_2"]) + "<br>" + String.Format("{0:C2}", dtReport.Rows[i]["Paid_2"]) + "<br>" + String.Format("{0:C2}", dtReport.Rows[i]["Outstanding_2"]) + "<br></td>");
                                strHTML.Append("<td style='width: 100px;' align='right'>" + String.Format("{0:C2}", dtReport.Rows[i]["Diff_Inc"]) + "<br>" + String.Format("{0:C2}", dtReport.Rows[i]["Diff_Paid"]) + "<br>" + String.Format("{0:C2}", dtReport.Rows[i]["Diff_Out"]) + "<br></td>");
                                strHTML.Append("</td></tr>");
                            }
                        }
                        else
                        {
                            //Add No record found line for year
                            strHTML.Append("<tr><td>No Record Found!</td></tr>");
                        }
                        strHTML.Append("</table>");

                        //Write HTML in to HtmlWriter
                        htmlWrite.WriteLine(strHTML.ToString());

                        //Send Mail
                        SendMail("Point-in-Time Detail Report", "PITDetailReport.xls", strFirstName, strLastName, strMailFrom, stringWrite, dtRecipients);
                    }
                }
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("ERROR in Details Point In time Report, " + ex.Message);
            }
        }

        //Report 11
        private void BindTPALagSummaryReport(DataRow drReportSchedule)
        {
            try
            {
                decimal pK_Schedule_ID = Convert.ToDecimal(drReportSchedule["PK_Schedule"]);
                decimal Fk_RecipientList = Convert.ToDecimal(drReportSchedule["Fk_RecipientList"]);
                decimal FK_Security_Id = Convert.ToDecimal(drReportSchedule["FK_Security_Id"]);

                //Get Report criteria for the scheduled report
                DataTable dtFilter = Report.SelectFilterCriteria(11, pK_Schedule_ID).Tables[0];
                if (dtFilter.Rows.Count > 0)
                {
                    //Get the recipient from the recipient list 
                    DataTable dtRecipients = Report.SelectOneRecordWithRecipientList(Fk_RecipientList).Tables[0];

                    //Get the user who has scheduled the report
                    DataTable dtUser = Report.SelectSecurityByPK(FK_Security_Id).Tables[0];
                    String strFirstName, strLastName, strMailFrom;
                    strFirstName = strLastName = strMailFrom = "";
                    if (dtUser.Rows.Count > 0)
                    {
                        strFirstName = dtUser.Rows[0]["FIRST_NAME"].ToString();
                        strLastName = dtUser.Rows[0]["LAST_NAME"].ToString();
                        strMailFrom = dtUser.Rows[0]["Email"].ToString();

                        //Set all filters to a variable as per report type
                        String strRegions = dtFilter.Rows[0]["Region"].ToString();
                        string strMarket = null;
                        if (!string.IsNullOrEmpty(Convert.ToString(dtFilter.Rows[0]["Market"])))
                        {
                            strMarket = Convert.ToString(dtFilter.Rows[0]["Market"]).Trim();
                        }
                        DateTime date_of_loss_from = Convert.ToDateTime(dtFilter.Rows[0]["From_Date_Of_Loss"].ToString());
                        DateTime date_of_loss_to = Convert.ToDateTime(dtFilter.Rows[0]["To_Date_Of_Loss"].ToString());

                        //Get the report data
                        DataSet dsReport = Report.GetTPALagSummaryData(date_of_loss_from, date_of_loss_to, strRegions, strMarket);

                        //Create HTML for the report and wirte into HTML Write object
                        StringBuilder strHTML = new StringBuilder();
                        System.IO.StringWriter stringWrite = new System.IO.StringWriter();
                        System.Web.UI.HtmlTextWriter htmlWrite = new System.Web.UI.HtmlTextWriter(stringWrite);

                        #region " Header "

                        //Retrieve Market Values
                        string strMarketString = string.Empty;
                        if (string.IsNullOrEmpty(strMarket))
                        {
                            strMarketString = "All Market";
                        }
                        else
                        {
                            string[] strMar = strMarket.Split(Convert.ToChar(","));
                            for (int i = 0; i < strMar.Length; i++)
                            {
                                strMarketString += Report.SelectMarketInfoById(Convert.ToDecimal(strMar[i].ToString())).Tables[0].Rows[0]["Market"].ToString() + ",";
                            }
                            strMarketString = strMarketString.TrimEnd(',');
                        }

                        //Add Report Title and Schedule Date
                        strHTML.Append("<br />");
                        strHTML.Append("<b>Report Title : Reported to TPA Lag Summary Report</b>");
                        strHTML.Append("<br /><br />");
                        strHTML.Append("Schedule Date : " + Convert.ToDateTime(drReportSchedule["Scheduled_Date"]).ToString(DateDisplayFormat));
                        strHTML.Append("&nbsp;&nbsp;&nbsp;&nbsp;Schedule End Date : " + Convert.ToDateTime(drReportSchedule["Schedule_End_Date"]).ToString(DateDisplayFormat));
                        strHTML.Append("<br />");
                        strHTML.Append("Recurring Period : " + drReportSchedule["Recurring_Period"]).ToString();
                        strHTML.Append("<br />");
                        strHTML.Append("Recurring Date : " + dtSchduleDate.ToString(DateDisplayFormat));

                        //Add Report Filter Criteria 
                        strHTML.Append("<br /><br />");
                        strHTML.Append("<b>Report Filters </b>");
                        strHTML.Append("<br /><br />");
                        strHTML.Append("Regions :" + strRegions.Replace("'", ""));
                        strHTML.Append("<br />");
                        strHTML.Append("Market        : " + strMarketString);
                        strHTML.Append("<br /><br />");
                        strHTML.Append("Date Of Loss : From : " + date_of_loss_from.ToString(DateDisplayFormat) + " &nbsp;&nbsp&nbsp;&nbsp; To : " + date_of_loss_to.ToString(DateDisplayFormat));
                        strHTML.Append("<br /><br />");

                        //Add Header HTML
                        strHTML.Append("<table style='font-weight: bold;' cellpadding='0' cellspacing='0' width='100%' border='0'><tr><td>");
                        strHTML.Append("<table style='font-weight: bold;' cellpadding='0' cellspacing='0' width='100%' border='1'>");
                        strHTML.Append("<tr><td style='width: 26%;' align='left'>Lag Period(Days)</td>");
                        strHTML.Append("<td style='width: 14%;' align='center'>No of Claims</td>");
                        strHTML.Append("<td style='width: 14%;' align='center'>Percentage To <br />Total Claim</td>");
                        strHTML.Append("<td style='width: 18%;' align='center'>Total<br/>Incurred Dollars</td>");
                        strHTML.Append("<td style='width: 14%;' align='center'>Percentage To <br />Total Dollars</td></tr></table>");
                        strHTML.Append("</td></tr></table>");

                        #endregion

                        //Get the no of descriptions selected
                        strHTML.Append("<table style='width: 100%;' border='1' align='left' cellpadding='4' cellspacing='0'>");
                        // get data tables from dataset
                        DataTable dtRegions = dsReport.Tables[0];
                        DataTable dtDetails = dsReport.Tables[1];
                        DataTable dtRegionTotal = dsReport.Tables[2];
                        DataTable dtGrandTotal = dsReport.Tables[3];
                        int intMedian = Convert.ToInt32(dsReport.Tables[4].Rows[0][0]);

                        if (dtDetails.Rows.Count > 0)
                        {
                            foreach (DataRow drRegion in dtRegionTotal.Rows)
                            {
                                //Add Header for Sub Report (Description wise)
                                strHTML.Append("<tr><td colspan='5' style='font-weight:bold;'>" + drRegion["Region"].ToString() + "</td></tr>");
                                DataRow[] drDetails = dtDetails.Select("Region='" + drRegion["Region"].ToString() + "'");

                                foreach (DataRow drDetail in drDetails)
                                {
                                    //Add Report Data Table 
                                    strHTML.Append("<tr><td align='left' style='width: 26%'>" + drDetail["StartLimit"] + " To " + drDetail["EndLimit"] + "</td>");
                                    strHTML.Append("<td align='right' style='width: 14%'>" + String.Format("{0:N0}", drDetail["ClaimCount"]) + "</td>");
                                    strHTML.Append("<td align='right' style='width: 14%'>" + String.Format("{0:N2}", drDetail["ClaimPercent"]) + "</td>");
                                    strHTML.Append("<td align='right' style='width: 18%'>" + String.Format("{0:C2}", drDetail["Incurred"]) + "</td>");
                                    strHTML.Append("<td align='right' style='width: 14%'>" + String.Format("{0:N2}", drDetail["IncurredPercent"]) + "</td>");
                                }
                                //Add Sub Total (Region wise)
                                strHTML.Append("<tr style='font-weight: bold;background-color: white; color: black;'><td align='left' style='width: 26%;'>Total </td>");
                                strHTML.Append("<td align='right' style='width: 14%'>" + String.Format("{0:N0}", drRegion["TotalClaims"]) + "</td>");
                                strHTML.Append("<td align='right' style='width: 14%'>" + String.Format("{0:N2}", drRegion["TotalClaimPercent"]) + "</td>");
                                strHTML.Append("<td align='right' style='width: 18%'>" + String.Format("{0:C2}", drRegion["TotalIncurred"]) + "</td>");
                                strHTML.Append("<td align='right' style='width: 14%'>" + String.Format("{0:N2}", drRegion["TotalIncurredPercent"]) + "</td></tr>");
                            }

                            strHTML.Append("</table>");
                            #region " Grand Total "
                            if (dtGrandTotal.Rows.Count > 0)
                            {
                                DataRow drTotal = dtGrandTotal.Rows[0];
                                strHTML.Append("<table style='font-weight: bold;' cellpadding='0' cellspacing='0' width='100%' border='0'><tr><td>");
                                strHTML.Append("<table style='font-weight: bold;' cellpadding='0' cellspacing='0' width='100%' border='1' style='font-weight: bold;background-color: #507CD1; color: #FFFFFF;'>");
                                strHTML.Append("<tr><td style='width: 26%;' align='left'>Total</td>");
                                strHTML.Append("<td style='width: 14%;' align='right'>" + String.Format("{0:N0}", drTotal["TotalClaims"]) + "</td>");
                                strHTML.Append("<td style='width: 14%;' align='right'>" + String.Format("{0:N2}", drTotal["TotalClaimPercent"]) + "</td>");
                                strHTML.Append("<td style='width: 18%;' align='right'>" + String.Format("{0:C2}", drTotal["TotalIncurred"]) + "</td>");
                                strHTML.Append("<td style='width: 14%;' align='right'>" + String.Format("{0:N2}", drTotal["TotalIncurredPercent"]) + "</td></tr></table>");
                                strHTML.Append("</td></tr></table>");
                            }
                            #endregion

                            strHTML.Append("<table style='width: 100%;' border='0' align='left' cellpadding='4' cellspacing='0'>");
                            strHTML.Append("<tr><td width='100%' align='left' colspan='5'><b>Median Lag Time in Days : " + intMedian + "</b></td></tr>");
                            strHTML.Append("</table>");
                        }
                        else
                        {
                            //Add No record found line for year
                            strHTML.Append("<tr><td align='left' colspan='5'>No Record Found!</td></tr></table>");
                        }


                        //Write HTML in to HtmlWriter
                        htmlWrite.WriteLine(strHTML.ToString());

                        //Send Mail
                        SendMail("Reported to TPA Lag Summary Report", "TPALagSummaryReport.xls", strFirstName, strLastName, strMailFrom, stringWrite, dtRecipients);
                    }
                }
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("ERROR in Lag Summary : 11, " + ex.Message);
            }
        }

        //Report 12
        private void BindSummaryPITReport(DataRow drReportSchedule)
        {
            try
            {
                decimal pK_Schedule_ID = Convert.ToDecimal(drReportSchedule["PK_Schedule"]);
                decimal Fk_RecipientList = Convert.ToDecimal(drReportSchedule["Fk_RecipientList"]);
                decimal FK_Security_Id = Convert.ToDecimal(drReportSchedule["FK_Security_Id"]);

                //Get Report criteria for the scheduled report
                DataTable dtFilter = Report.SelectFilterCriteria(12, pK_Schedule_ID).Tables[0];
                if (dtFilter.Rows.Count > 0)
                {
                    //Get the recipient from the recipient list 
                    DataTable dtRecipients = Report.SelectOneRecordWithRecipientList(Fk_RecipientList).Tables[0];

                    //Get the user who has scheduled the report
                    DataTable dtUser = Report.SelectSecurityByPK(FK_Security_Id).Tables[0];

                    String strFirstName, strLastName, strMailFrom;
                    strFirstName = strLastName = strMailFrom = "";
                    if (dtUser.Rows.Count > 0)
                    {
                        strFirstName = dtUser.Rows[0]["FIRST_NAME"].ToString();
                        strLastName = dtUser.Rows[0]["LAST_NAME"].ToString();
                        strMailFrom = dtUser.Rows[0]["Email"].ToString();

                        //Set all filters to a variable as per report type
                        String strClaim_Type = dtFilter.Rows[0]["Claim_Type"].ToString();
                        String strPolicy_Year = dtFilter.Rows[0]["Policy_Year"].ToString();
                        DateTime date_of_compare_first = Convert.ToDateTime(dtFilter.Rows[0]["Compare_First_Date"]);
                        DateTime date_of_compare_second = Convert.ToDateTime(dtFilter.Rows[0]["Compare_Second_Date"]);

                        //Get the report data
                        DataSet dsReport = Report.GetPointInTimeSummaryData(date_of_compare_first, date_of_compare_second, strPolicy_Year, strClaim_Type, FK_Security_Id);

                        //Create HTML for the report and wirte into HTML Write object
                        StringBuilder strHTML = new StringBuilder();
                        System.IO.StringWriter stringWrite = new System.IO.StringWriter();
                        System.Web.UI.HtmlTextWriter htmlWrite = new System.Web.UI.HtmlTextWriter(stringWrite);

                        #region " Header "
                        //Add Report Title and Schedule Date
                        strHTML.Append("<br />");
                        strHTML.Append("<b>Report Title : Point-in-Time Summary Report</b>");
                        strHTML.Append("<br /><br />");
                        strHTML.Append("Schedule Date : " + Convert.ToDateTime(drReportSchedule["Scheduled_Date"]).ToString(DateDisplayFormat));
                        strHTML.Append("&nbsp;&nbsp;&nbsp;&nbsp;Schedule End Date : " + Convert.ToDateTime(drReportSchedule["Schedule_End_Date"]).ToString(DateDisplayFormat));
                        strHTML.Append("<br />");
                        strHTML.Append("Recurring Period : " + drReportSchedule["Recurring_Period"]).ToString();
                        strHTML.Append("<br />");
                        strHTML.Append("Recurring Date : " + dtSchduleDate.ToString(DateDisplayFormat));

                        //Add Report Filter Criteria
                        strHTML.Append("<br /><br />");
                        strHTML.Append("<b>Report Filters </b>");
                        strHTML.Append("<br /><br />");
                        strHTML.Append("Comparison Dates :  First : " + date_of_compare_first.ToString(DateDisplayFormat) + " &nbsp;&nbsp&nbsp;&nbsp; Second : " + date_of_compare_second.ToString(DateDisplayFormat));
                        strHTML.Append("<br />");
                        strHTML.Append("Accident Year    :" + strPolicy_Year.Trim(new char[] { ',', '|', ' ' }));
                        strHTML.Append("<br />");
                        strHTML.Append("Claim Type :" + GetClaimTypeString(strClaim_Type));
                        strHTML.Append("<br /><br />");

                        //Add Header HTML
                        strHTML.Append("<table style='font-weight: bold;' cellpadding='0' cellspacing='0' width='100%' border='1'><tr><td>");
                        strHTML.Append("<table style='font-weight: bold;' cellpadding='0' cellspacing='0' width='100%' border='1'>");
                        strHTML.Append("<tr align='right' valign='bottom'>");
                        strHTML.Append("<td align='left'>Claim Type</td>");
                        strHTML.Append("<td>&nbsp;</td>");
                        strHTML.Append("<td>" + date_of_compare_first.ToString(DateDisplayFormat) + " <br> Total Dollars</td>");
                        strHTML.Append("<td>" + date_of_compare_second.ToString(DateDisplayFormat) + " <br> Total Dollars</td>");
                        strHTML.Append("<td>Difference</td>");
                        strHTML.Append("<td>Claim Count</td></tr>");
                        strHTML.Append("</table>");
                        strHTML.Append("</td></tr></table>");

                        #endregion

                        DataTable dtYears = dsReport.Tables[0];
                        DataTable dtDetails = dsReport.Tables[1];
                        DataTable dtYearTotals = dsReport.Tables[2];
                        DataTable dtGrandTotals = dsReport.Tables[3];

                        strHTML.Append("<table style='width: 100%;' border='1' align='left' cellpadding='4' cellspacing='0'>");

                        foreach (DataRow drYear in dtYears.Rows)
                        {
                            //Add Header for Sub Report (Year wise)
                            strHTML.Append("<tr><td style='font-weight:bold;'>Accident Year - " + drYear["AccidentYear"].ToString() + "</td></tr><tr><td align='left'>");
                            DataRow[] drDetails = dtDetails.Select("AccidentYear = '" + drYear["AccidentYear"].ToString() + "'");


                            foreach (DataRow drDetail in drDetails)
                            {
                                #region " Print details data "
                                strHTML.Append("<table align='left' border='1' cellpadding='0' cellspacing='0' style='width: 100%;border-collapse: collapse;'>");
                                strHTML.Append("<tr><td colspan='6'>Claim Type - " + drDetail["ClaimType"].ToString() + "</td></tr>");
                                strHTML.Append("<tr><td></td>");
                                strHTML.Append("<td width='150px' align='right'>Incurred :</td>");
                                strHTML.Append("<td width='120px' align='right'>" + String.Format("{0:C2}", drDetail["Incurred_1"]) + "</td>");
                                strHTML.Append("<td width='120px' align='right'>" + String.Format("{0:C2}", drDetail["Incurred_2"]) + "</td>");
                                strHTML.Append("<td width='120px' align='right'>" + String.Format("{0:C2}", drDetail["Incurred_D"]) + "</td>");
                                strHTML.Append("<td width='120px' align='center'>" + String.Format("{0:N0}", drDetail["ClaimCount"]) + "</td></tr>");
                                strHTML.Append("<tr><td>&nbsp;</td>");
                                strHTML.Append("<td align='right'>Paid :</td>");
                                strHTML.Append("<td align='right'>" + String.Format("{0:C2}", drDetail["Paid_1"]) + "</td>");
                                strHTML.Append("<td align='right'>" + String.Format("{0:C2}", drDetail["Paid_2"]) + "</td>");
                                strHTML.Append("<td align='right'>" + String.Format("{0:C2}", drDetail["Paid_D"]) + "</td>");
                                strHTML.Append("<td align='center'></td></tr>");
                                strHTML.Append("<tr><td>&nbsp;</td>");
                                strHTML.Append("<td align='right'>Outstandings :</td>");
                                strHTML.Append("<td align='right'>" + String.Format("{0:C2}", drDetail["OutStanding_1"]) + "</td>");
                                strHTML.Append("<td align='right'>" + String.Format("{0:C2}", drDetail["OutStanding_2"]) + "</td>");
                                strHTML.Append("<td align='right'>" + String.Format("{0:C2}", drDetail["Out_D"]) + "</td>");
                                strHTML.Append("<td align='center'></td></tr></table>");
                                #endregion
                            }
                            if (drDetails.Length > 0)
                            {
                                #region "Add Sub Total (Year wise)"
                                DataRow[] drYearTotal = dtYearTotals.Select("AccidentYear = '" + drYear["AccidentYear"].ToString() + "'");

                                strHTML.Append("<table align='left' border='1' cellpadding='0' cellspacing='0' style='width: 100%;font-weight:bold;'>");
                                strHTML.Append("<tr><td colspan='6'>Sub Totals for Accident Year : " + drYearTotal[0]["AccidentYear"].ToString() + "</td></tr>");
                                strHTML.Append("<tr><td>&nbsp;</td>");
                                strHTML.Append("<td width='150px' align='right'>Incurred :</td>");
                                strHTML.Append("<td width='120px' align='right'>" + String.Format("{0:C2}", drYearTotal[0]["Total_Incurred_1"]) + "</td>");
                                strHTML.Append("<td width='120px' align='right'>" + String.Format("{0:C2}", drYearTotal[0]["Total_Incurred_2"]) + "</td>");
                                strHTML.Append("<td width='120px' align='right'>" + String.Format("{0:C2}", drYearTotal[0]["Total_Incurred_D"]) + "</td>");
                                strHTML.Append("<td width='120px' align='center'>" + String.Format("{0:N0}", drYearTotal[0]["Total_Claims"]) + "</td></tr>");
                                strHTML.Append("<tr><td>&nbsp;</td>");
                                strHTML.Append("<td align='right'>Paid :</td>");
                                strHTML.Append("<td align='right'>" + String.Format("{0:C2}", drYearTotal[0]["Total_Paid_1"]) + "</td>");
                                strHTML.Append("<td align='right'>" + String.Format("{0:C2}", drYearTotal[0]["Total_Paid_2"]) + "</td>");
                                strHTML.Append("<td align='right'>" + String.Format("{0:C2}", drYearTotal[0]["Total_Paid_D"]) + "</td>");
                                strHTML.Append("<td align='center'></td></tr>");
                                strHTML.Append("<tr><td>&nbsp;</td>");
                                strHTML.Append("<td align='right'>Outstandings :</td>");
                                strHTML.Append("<td align='right'>" + String.Format("{0:C2}", drYearTotal[0]["Total_Outstanding_1"]) + "</td>");
                                strHTML.Append("<td align='right'>" + String.Format("{0:C2}", drYearTotal[0]["Total_Outstanding_2"]) + "</td>");
                                strHTML.Append("<td align='right'>" + String.Format("{0:C2}", drYearTotal[0]["Total_Out_D"]) + "</td>");
                                strHTML.Append("<td align='center'>&nbsp;</td></tr></table>");
                                #endregion
                            }
                            else
                            {
                                //Add No record found line for year
                                strHTML.Append("No Record Found!");
                            }
                            strHTML.Append("</td></tr>");
                        }

                        #region " Finally Add Report Grand Total "

                        DataRow drTotal = dtGrandTotals.Rows[0];
                        strHTML.Append("<tr><td align='left'>");
                        strHTML.Append("<table align='left' border='1' cellpadding='0' cellspacing='0' style='width: 100%;font-weight: bold;background-color: #507CD1; color: #FFFFFF;'>");
                        strHTML.Append("<tr><td colspan='6'>Report Grand Total </td></tr>");
                        strHTML.Append("<tr><td>&nbsp;</td>");
                        strHTML.Append("<td width='150px' align='right'>Incurred :</td>");
                        strHTML.Append("<td width='120px' align='right'>" + String.Format("{0:C2}", drTotal["Total_Incurred_1"]) + "</td>");
                        strHTML.Append("<td width='120px' align='right'>" + String.Format("{0:C2}", drTotal["Total_Incurred_2"]) + "</td>");
                        strHTML.Append("<td width='120px' align='right'>" + String.Format("{0:C2}", drTotal["Total_Incurred_D"]) + "</td>");
                        strHTML.Append("<td width='120px' align='center'>" + String.Format("{0:N0}", drTotal["Total_Claims"]) + "</td></tr>");
                        strHTML.Append("<tr><td>&nbsp;</td>");
                        strHTML.Append("<td align='right'>Paid :</td>");
                        strHTML.Append("<td align='right'>" + String.Format("{0:C2}", drTotal["Total_Paid_1"]) + "</td>");
                        strHTML.Append("<td align='right'>" + String.Format("{0:C2}", drTotal["Total_Paid_2"]) + "</td>");
                        strHTML.Append("<td align='right'>" + String.Format("{0:C2}", drTotal["Total_Paid_D"]) + "</td>");
                        strHTML.Append("<td align='center'></td></tr>");
                        strHTML.Append("<tr><td>&nbsp;</td>");
                        strHTML.Append("<td align='right'>Outstandings :</td>");
                        strHTML.Append("<td align='right'>" + String.Format("{0:C2}", drTotal["Total_Outstanding_1"]) + "</td>");
                        strHTML.Append("<td align='right'>" + String.Format("{0:C2}", drTotal["Total_Outstanding_2"]) + "</td>");
                        strHTML.Append("<td align='right'>" + String.Format("{0:C2}", drTotal["Total_Out_D"]) + "</td>");
                        strHTML.Append("<td align='center'>&nbsp;</td></tr></table>");
                        strHTML.Append("</td></tr>");

                        #endregion

                        strHTML.Append("</table>");

                        //Write HTML in to HtmlWriter
                        htmlWrite.WriteLine(strHTML.ToString());

                        //Send Mail
                        SendMail("Point-in-Time Summary Report", "PITSummaryReport.xls", strFirstName, strLastName, strMailFrom, stringWrite, dtRecipients);
                    }
                }
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("ERROR in Summary Point-in-Time Comparison Report, " + ex.Message);
            }
        }

        //Report 13
        private void BindThreePITSummaryReport(DataRow drReportSchedule)
        {
            try
            {
                decimal pK_Schedule_ID = Convert.ToDecimal(drReportSchedule["PK_Schedule"]);
                decimal Fk_RecipientList = Convert.ToDecimal(drReportSchedule["Fk_RecipientList"]);
                decimal FK_Security_Id = Convert.ToDecimal(drReportSchedule["FK_Security_Id"]);

                //Get Report criteria for the scheduled report
                DataTable dtFilter = Report.SelectFilterCriteria(13, pK_Schedule_ID).Tables[0];
                if (dtFilter.Rows.Count > 0)
                {
                    //Get the recipient from the recipient list
                    DataTable dtRecipients = Report.SelectOneRecordWithRecipientList(Fk_RecipientList).Tables[0];

                    //Get the user who has scheduled the report
                    DataTable dtUser = Report.SelectSecurityByPK(FK_Security_Id).Tables[0];

                    String strFirstName, strLastName, strMailFrom;
                    strFirstName = strLastName = strMailFrom = "";
                    if (dtUser.Rows.Count > 0)
                    {
                        strFirstName = dtUser.Rows[0]["FIRST_NAME"].ToString();
                        strLastName = dtUser.Rows[0]["LAST_NAME"].ToString();
                        strMailFrom = dtUser.Rows[0]["Email"].ToString();

                        //Set all filters to a variable as per report type
                        DataRow drReport = dtFilter.Rows[0];
                        DateTime as_of_date1 = Convert.ToDateTime(drReport["As_Of_Date1"]);
                        DateTime as_of_date2 = Convert.ToDateTime(drReport["As_Of_Date2"]);
                        DateTime as_of_date3 = Convert.ToDateTime(drReport["As_Of_Date3"]);

                        DateTime Compare_First_Date1 = Convert.ToDateTime(drReport["Compare_First_Date1"]);
                        DateTime Compare_First_Date2 = Convert.ToDateTime(drReport["Compare_First_Date2"]);
                        DateTime Compare_First_Date3 = Convert.ToDateTime(drReport["Compare_First_Date3"]);

                        DateTime Compare_Second_Date1 = Convert.ToDateTime(drReport["Compare_Second_Date1"]);
                        DateTime Compare_Second_Date2 = Convert.ToDateTime(drReport["Compare_Second_Date2"]);
                        DateTime Compare_Second_Date3 = Convert.ToDateTime(drReport["Compare_Second_Date3"]);

                        //Get the report data
                        DataSet dsReport = Report.GetThreePITSummaryData(as_of_date1, Compare_First_Date1, Compare_Second_Date1,
                                                                    as_of_date2, Compare_First_Date2, Compare_Second_Date2,
                                                                    as_of_date3, Compare_First_Date3, Compare_Second_Date3,
                                                                    drReport["Claim_Type"].ToString(), FK_Security_Id);
                        DataTable dtReport = dsReport.Tables[0];

                        //Create HTML for the report and wirte into HTML Write object
                        StringBuilder strHTML = new StringBuilder();
                        System.IO.StringWriter stringWrite = new System.IO.StringWriter();
                        System.Web.UI.HtmlTextWriter htmlWrite = new System.Web.UI.HtmlTextWriter(stringWrite);

                        #region " Header "
                        //Add Report Title and Schedule Date
                        strHTML.Append("<br />");
                        strHTML.Append("<b>Title : Three Points in Time Summary Report</b>");
                        strHTML.Append("<br /><br />");
                        strHTML.Append("Schedule Date : " + Convert.ToDateTime(drReportSchedule["Scheduled_Date"]).ToString(DateDisplayFormat));
                        strHTML.Append("&nbsp;&nbsp;&nbsp;&nbsp;Schedule End Date : " + Convert.ToDateTime(drReportSchedule["Schedule_End_Date"]).ToString(DateDisplayFormat));
                        strHTML.Append("<br />");
                        strHTML.Append("Recurring Period : " + drReportSchedule["Recurring_Period"]).ToString();
                        strHTML.Append("<br />");
                        strHTML.Append("Recurring Date : " + dtSchduleDate.ToString(DateDisplayFormat));

                        //Add Report Filter Criteria 
                        strHTML.Append("<br /><br />");
                        strHTML.Append("<b>Report Filters </b>");
                        strHTML.Append("<br /><br />");
                        strHTML.Append("Claim Types :" + GetClaimTypeString(drReport["Claim_Type"].ToString()));
                        strHTML.Append("<br /><br />");

                        //Add Header HTML
                        strHTML.Append("<table width='100%' cellspacing=0 cellpadding=0><tr><td width='100%'>");
                        strHTML.Append("<table style='width: 100%; ' border='1' cellpadding='4' cellspacing='0'>");
                        strHTML.Append("<tr style='font-weight: bold;' align='center'>");
                        strHTML.Append("<td width='14%'>&nbsp;</td> "
                                            + " <td colspan='2'>Period 1 <br> " + Compare_First_Date1.ToString(DateDisplayFormat) + " To " + Compare_Second_Date1.ToString(DateDisplayFormat) + " <br> As Of " + as_of_date1.ToString("MM/yyyy") + "</td> "
                                            + " <td colspan='4'>Period 2 <br> " + Compare_First_Date2.ToString(DateDisplayFormat) + " To " + Compare_Second_Date2.ToString(DateDisplayFormat) + " <br> As Of " + as_of_date2.ToString("MM/yyyy") + "</td> "
                                            + " <td colspan='4'>Period 3 <br> " + Compare_First_Date3.ToString(DateDisplayFormat) + " To " + Compare_Second_Date3.ToString(DateDisplayFormat) + " <br> As Of " + as_of_date3.ToString("MM/yyyy") + "</td></tr>"
                                            + " <tr style='font-weight: bold;' align='center'>"
                                            + " <td style='width:14%' align='left'>Location</td> "
                                            + " <td style='width:10%' align='right'>Total Incurred Dollars</td> "
                                            + " <td style='width:8%' align='right'># of Claims</td> "
                                            + " <td style='width:10%' align='right'>Total Incurred Dollars</td> "
                                            + " <td style='width:8%' align='right'>Fin Chg Pd 2-1</td> "
                                            + " <td style='width:8%' align='right'># of Claims</td>"
                                            + " <td style='width:8%' align='right'>Claims % Chg P 1-2</td> "
                                            + " <td style='width:10%' align='right'>Total Incurred Dollars</td> "
                                            + " <td style='width:8%' align='right'>Fin chg Pd 2-3</td> "
                                            + " <td style='width:8%' align='right'># of Claims</td> "
                                            + " <td style='width:8%' align='right'>Claims % chg P 2-3</td></tr></table></td></tr></table>");

                        #endregion

                        DataTable dtDetails = dsReport.Tables[0];
                        DataTable dtRegionTotals = dsReport.Tables[1];
                        DataTable dtGrandTotal = dsReport.Tables[2];
                        //Get the no of descriptions selected
                        strHTML.Append("<table style='width: 100%;' border='1' align='left' cellpadding='4' cellspacing='0'>");

                        if (dtDetails.Rows.Count > 0)
                        {
                            foreach (DataRow drRegion in dtRegionTotals.Rows)
                            {
                                //Add Header for Sub Report (Description wise)
                                strHTML.Append("<tr><td colspan='11' style='font-weight:bold;'>Region : " + drRegion["Region"].ToString() + "</td></tr>");
                                DataRow[] drDetails = dtDetails.Select("Region = '" + drRegion["Region"] + "'");

                                #region " Region-wise Details "
                                foreach (DataRow drDetail in drDetails)
                                {

                                    strHTML.Append("<tr align='right'>" +
                                                    " <td style='width:14%' align='left'> " + drDetail["Location"].ToString() + "</td>" +
                                                    " <td style='width:10%' align='right'> " + String.Format("{0:C2}", Convert.ToDouble(drDetail["Incurred_1"])) + "</td>" +
                                                    " <td style='width:8%' align='right'> " + String.Format("{0:N0}", Convert.ToDouble(drDetail["ClaimCount_1"])) + "</td>" +
                                                    " <td style='width:10%' align='right'> " + String.Format("{0:C2}", Convert.ToDouble(drDetail["Incurred_2"])) + "</td>" +
                                                    " <td style='width:8%' align='right'> " + String.Format("{0:f}", Convert.ToDouble(drDetail["FinChgPd2Inc_2"])) + "</td>" +
                                                    " <td style='width:8%' align='right'> " + String.Format("{0:N0}", Convert.ToDouble(drDetail["ClaimCount_2"])) + "</td>" +
                                                    " <td style='width:8%' align='right'> " + String.Format("{0:f}", Convert.ToDouble(drDetail["FinChgPd2Cnt_2"])) + "</td>" +
                                                    " <td style='width:10%' align='right'> " + String.Format("{0:C2}", Convert.ToDouble(drDetail["Incurred_3"])) + "</td>" +
                                                    " <td style='width:8%' align='right'> " + String.Format("{0:f}", Convert.ToDouble(drDetail["FinChgPd2Inc_3"])) + "</td>" +
                                                    " <td style='width:8%' align='right'> " + String.Format("{0:N0}", Convert.ToDouble(drDetail["ClaimCount_3"])) + "</td>" +
                                                    " <td style='width:8%' align='right'> " + String.Format("{0:f}", Convert.ToDouble(drDetail["FinChgPd2Cnt_3"])) + "</td>");
                                }
                                #endregion

                                #region " Sub Totals for Region "
                                //Add Sub Total (Region wise)
                                strHTML.Append("<tr style='font-weight: bold;background-color: white; color: black;'>");
                                strHTML.Append(" <td align='left'>Totals</td>" +
                                               " <td align='right'> " + String.Format("{0:C2}", Convert.ToDouble(drRegion["Incurred_1"])) + "</td>" +
                                               " <td align='right'> " + String.Format("{0:N0}", Convert.ToDouble(drRegion["ClaimCount_1"])) + "</td>" +
                                               " <td align='right'> " + String.Format("{0:C2}", Convert.ToDouble(drRegion["Incurred_2"])) + "</td>" +
                                               " <td align='right'> " + String.Format("{0:f}", Convert.ToDouble(drRegion["FinChgPd2Inc_2"])) + "</td>" +
                                               " <td align='right'> " + String.Format("{0:N0}", Convert.ToDouble(drRegion["ClaimCount_2"])) + "</td>" +
                                               " <td align='right'> " + String.Format("{0:f}", Convert.ToDouble(drRegion["FinChgPd2Cnt_2"])) + "</td>" +
                                               " <td align='right'> " + String.Format("{0:C2}", Convert.ToDouble(drRegion["Incurred_3"])) + "</td>" +
                                               " <td align='right'> " + String.Format("{0:f}", Convert.ToDouble(drRegion["FinChgPd2Inc_3"])) + "</td>" +
                                               " <td align='right'> " + String.Format("{0:N0}", Convert.ToDouble(drRegion["ClaimCount_3"])) + "</td>" +
                                               " <td align='right'> " + String.Format("{0:f}", Convert.ToDouble(drRegion["FinChgPd2Cnt_3"])) + "</td></tr>");
                                #endregion
                            }

                            #region " Grand Total "
                            if (dtGrandTotal.Rows.Count > 0)
                            {
                                DataRow drTotal = dtGrandTotal.Rows[0];
                                strHTML.Append("<table style='font-weight: bold;' cellpadding='0' cellspacing='0' width='100%' border='0'><tr><td>");
                                strHTML.Append("<table style='font-weight: bold;' cellpadding='0' cellspacing='0' width='100%' border='1' style='font-weight: bold;background-color: #507CD1; color: #FFFFFF;'><tr>");
                                strHTML.Append(" <td style='width:14%' align='left'>Report Grand Totals</td>");
                                strHTML.Append(" <td style='width:10%' align='right'> " + String.Format("{0:C2}", Convert.ToDouble(drTotal["Incurred_1"])) + "</td>" +
                                               " <td style='width:8%' align='right'> " + String.Format("{0:N0}", Convert.ToDouble(drTotal["ClaimCount_1"])) + "</td>" +
                                               " <td style='width:10%' align='right'> " + String.Format("{0:C2}", Convert.ToDouble(drTotal["Incurred_2"])) + "</td>" +
                                               " <td style='width:8%' align='right'> " + String.Format("{0:f}", Convert.ToDouble(drTotal["FinChgPd2Inc_2"])) + "</td>" +
                                               " <td style='width:8%' align='right'> " + String.Format("{0:N0}", Convert.ToDouble(drTotal["ClaimCount_2"])) + "</td>" +
                                               " <td style='width:8%' align='right'> " + String.Format("{0:f}", Convert.ToDouble(drTotal["FinChgPd2Cnt_2"])) + "</td>" +
                                               " <td style='width:10%' align='right'> " + String.Format("{0:C2}", Convert.ToDouble(drTotal["Incurred_3"])) + "</td>" +
                                               " <td style='width:8%' align='right'> " + String.Format("{0:f}", Convert.ToDouble(drTotal["FinChgPd2Inc_3"])) + "</td>" +
                                               " <td style='width:8%' align='right'> " + String.Format("{0:N0}", Convert.ToDouble(drTotal["ClaimCount_3"])) + "</td>" +
                                               " <td style='width:8%' align='right'> " + String.Format("{0:f}", Convert.ToDouble(drTotal["FinChgPd2Cnt_3"])) + "</td>");
                                strHTML.Append("</tr></table></td></tr></table>");
                            }
                            #endregion
                        }
                        else
                        {
                            //Add No record found line for year
                            strHTML.Append("<tr><td align='left' colspan='11'>No Record Found!</td></tr></table>");
                        }

                        //Write HTML in to HtmlWriter
                        htmlWrite.WriteLine(strHTML.ToString());

                        //Send Mail
                        SendMail("Three Points in Time Summary Report", "ThreePITSummaryReport.xls", strFirstName, strLastName, strMailFrom, stringWrite, dtRecipients);
                    }
                }
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("ERROR in Three Point-in-Time Summary Report, " + ex.Message);
            }
        }

        //Report 14
        private void BindBordereauReport(DataRow drReportSchedule)
        {
            try
            {
                decimal pK_Schedule_ID = Convert.ToDecimal(drReportSchedule["PK_Schedule"]);
                decimal Fk_RecipientList = Convert.ToDecimal(drReportSchedule["Fk_RecipientList"]);
                decimal FK_Security_Id = Convert.ToDecimal(drReportSchedule["FK_Security_Id"]);

                //Get Report criteria for the scheduled report
                DataTable dtFilter = Report.SelectFilterCriteria(14, pK_Schedule_ID).Tables[0];
                if (dtFilter.Rows.Count > 0)
                {
                    //Get the recipient from the recipient list
                    DataTable dtRecipients = Report.SelectOneRecordWithRecipientList(Fk_RecipientList).Tables[0];

                    //Get the user who has scheduled the report
                    DataTable dtUser = Report.SelectSecurityByPK(FK_Security_Id).Tables[0];

                    String strFirstName, strLastName, strMailFrom;
                    strFirstName = strLastName = strMailFrom = "";
                    if (dtUser.Rows.Count > 0)
                    {
                        strFirstName = dtUser.Rows[0]["FIRST_NAME"].ToString();
                        strLastName = dtUser.Rows[0]["LAST_NAME"].ToString();
                        strMailFrom = dtUser.Rows[0]["Email"].ToString();

                        // get start date
                        DateTime Start_Date = Convert.ToDateTime(dtFilter.Rows[0]["Start_Date"]);
                        // get end date
                        DateTime End_Date = Convert.ToDateTime(dtFilter.Rows[0]["End_Date"]);

                        string strMarket = null;
                        decimal? decMarket = null;
                        if (!string.IsNullOrEmpty(Convert.ToString(dtFilter.Rows[0]["Market"])))
                        {
                            decMarket = Convert.ToDecimal(dtFilter.Rows[0]["Market"]);
                        }

                        // get result records from database for the report
                        DataSet dsReport = Report.Get_Bordereau_Report(Start_Date, End_Date, Convert.ToString(dtFilter.Rows[0]["Region"]), decMarket);

                        //Create HTML for the report and wirte into HTML Write object
                        StringBuilder strHTML = new StringBuilder();
                        System.IO.StringWriter stringWrite = new System.IO.StringWriter();
                        System.Web.UI.HtmlTextWriter htmlWrite = new System.Web.UI.HtmlTextWriter(stringWrite);

                        #region "Header"

                        //Retrieve Market Values
                        string strMarketString = string.Empty;
                        if (string.IsNullOrEmpty(strMarket))
                        {
                            strMarketString = "All Market";
                        }
                        else
                        {
                            string[] strMar = strMarket.Split(Convert.ToChar(","));
                            for (int i = 0; i < strMar.Length; i++)
                            {
                                strMarketString += Report.SelectMarketInfoById(Convert.ToDecimal(strMar[i].ToString())).Tables[0].Rows[0]["Market"].ToString() + ",";
                            }
                            strMarketString = strMarketString.TrimEnd(',');
                        }

                        //Add Report Title and Schedule Date
                        strHTML.Append("<span style=\"font-family:Calibri;\">");
                        strHTML.Append("<br />");
                        strHTML.Append("<b>Report Title : FINPRO  Bordereau Report</b>");
                        strHTML.Append("<br /><br />");
                        strHTML.Append("Schedule Date : " + Convert.ToDateTime(drReportSchedule["Scheduled_Date"]).ToString(DateDisplayFormat));
                        strHTML.Append("&nbsp;&nbsp;&nbsp;&nbsp;Schedule End Date : " + Convert.ToDateTime(drReportSchedule["Schedule_End_Date"]).ToString(DateDisplayFormat));
                        strHTML.Append("<br />");
                        strHTML.Append("Recurring Period : " + drReportSchedule["Recurring_Period"]).ToString();
                        strHTML.Append("<br />");
                        strHTML.Append("Recurring Date : " + dtSchduleDate.ToString(DateDisplayFormat));

                        //Add Report Filter Criteria 
                        strHTML.Append("<br /><br />");
                        strHTML.Append("<b>Report Filters </b>");
                        strHTML.Append("<br /><br />");
                        strHTML.Append("Date Claim Opened Between " + Start_Date.ToString(DateDisplayFormat) + " and " + End_Date.ToString(DateDisplayFormat));
                        strHTML.Append("<br />");
                        strHTML.Append("Regions              : " + (string.IsNullOrEmpty(Convert.ToString(dtFilter.Rows[0]["Region"])) ? "All" : dtFilter.Rows[0]["Region"].ToString()));
                        strHTML.Append("<br />");
                        strHTML.Append("Markets              : " + strMarketString );
                        strHTML.Append("<br /><br />");
                        strHTML.Append("</span>");

                        //Add Header HTML
                        strHTML.Append("<div style=\"overflow-x:scroll;overflow-y:hidden;width:1200px;\">");
                        strHTML.Append("<table cellpadding='4' cellspacing='0' style='font-weight: bold;font-family:Calibri;' width='3150px' border='1'><tr valign='top'>");
                        strHTML.Append("<td style='width: 150px;' align='left'>Claim Number</td>");
                        strHTML.Append("<td style='width: 150px;' align='left'>Type of Allegation</td>");
                        strHTML.Append("<td style='width: 150px;' align='left'>Complainant/Plaintiff</td>");
                        strHTML.Append("<td style='width: 250px;' align='left'>Claim Description</td>");
                        strHTML.Append("<td style='width: 100px;' align='left'>Carrier</td>");
                        strHTML.Append("<td style='width: 150px;' align='left'>Type of Claim</td>");
                        strHTML.Append("<td style='width: 150px;' align='left'>Other Type Description</td>");
                        strHTML.Append("<td style='width: 150px;' align='left'>Policy Number</td>");
                        strHTML.Append("<td style='width: 250px;' align='right'>Deductible</td>");
                        strHTML.Append("<td style='width: 150px;' align='left'>Date of Alleged Wrongful Act</td>");
                        strHTML.Append("<td style='width: 200px;' align='left'>Date Claim Opened</td>");
                        strHTML.Append("<td style='width: 200px;' align='left'>Policy Effective Date</td>");
                        strHTML.Append("<td style='width: 150px;' align='left'>Policy Expiration Date</td>");
                        strHTML.Append("<td style='width: 250px;' align='right'>Estimated Demand Exposure</td>");
                        strHTML.Append("<td style='width: 350px;' align='left'>Claim Status/Comments</td>");
                        strHTML.Append("<td style='width: 150px;' align='left'>Internal Counsel</td>");
                        strHTML.Append("<td style='width: 200px;' align='left'>Internal Counsel Phone</td>");
                        strHTML.Append("<td style='width: 200px;' align='left'>Location Code</td>");
                        strHTML.Append("<td style='width: 250px;' align='left'>Sonic Location Name</td>");
                        strHTML.Append("<td style='width: 250px;' align='left'>Location dba</td>");
                        strHTML.Append("<td style='width: 250px;' align='left'>Entity</td>");
                        strHTML.Append("<td style='width: 200px;' align='left'>Defense Attorney</td>");
                        strHTML.Append("<td >");
                        strHTML.Append("<table style='font-weight: bold'> <tr valign='top'> <td colspan='4'>Plaintiff Attorney Information</td></tr><tr valign='top'>");
                        strHTML.Append("<td style='width: 200px;' align='left'>Firm</td>");
                        strHTML.Append("<td style='width: 200px;' align='left'>Name</td>");
                        strHTML.Append("<td style='width: 200px;' align='left'>Address</td>");
                        strHTML.Append("<td style='width: 200px;' align='left'>Phone Number</td>");
                        strHTML.Append("</tr></table>");
                        strHTML.Append("</td>");
                        strHTML.Append("</tr></table>");
                        #endregion

                        DataTable dtReportData = dsReport.Tables[0];
                        DataTable dtRegion = dsReport.Tables[1];
                        DataTable dtTotal = dsReport.Tables[2];
                        if (dtRegion.Rows.Count > 0)
                        {
                            //Add Report Data Table 
                            strHTML.Append("<table style='width: 3150px;' border='1' align='left' cellpadding='4' cellspacing='0'>");
                            foreach (DataRow drRegion in dtRegion.Rows)
                            {
                                strHTML.Append("<tr><td colspan='26' style='font-family:Calibri;'><b>");
                                strHTML.Append(drRegion["Region"].ToString());
                                strHTML.Append("</b></td></tr>");
                                strHTML.Append("<tr><td colspan='26'>");
                                strHTML.Append("<table style='width: 3150px;font-family:Calibri;' border='1' align='left' cellpadding='4' cellspacing='0'>");
                                DataRow[] drDataByRegion = dtReportData.Select("Region='" + drRegion["Region"].ToString() + "'");
                                foreach (DataRow drData in drDataByRegion)
                                {
                                    strHTML.Append("<tr style='background-color:#FFFFFF;' valign='top'>");
                                    strHTML.Append("<td style='width: 150px;' align='left'>" + drData["Claim_Number"] + "</td>");
                                    strHTML.Append("<td style='width: 150px;' align='left'>" + drData["Type_of_Allegation"] + "</td>");
                                    strHTML.Append("<td style='width: 150px;' align='left'>" + drData["Complainant_Plaintiff"] + "</td>");
                                    strHTML.Append("<td style='width: 250px;' align='left'>" + drData["Claim_Description"] + "</td>");
                                    strHTML.Append("<td style='width: 100px;' align='left'>" + drData["Carrier"] + "</td>");
                                    strHTML.Append("<td style='width: 150px;' align='left'>" + drData["Type_Of_Claim"] + "</td>");
                                    strHTML.Append("<td style='width: 150px;' align='left'>" + drData["Claim_Type_Other"] + "</td>");
                                    strHTML.Append("<td style='width: 150px;' align='left'>" + drData["Primary_Insurance_Policy_Number"] + "</td>");
                                    strHTML.Append("<td style='width: 250px;' align='right'>$ " + string.Format("{0:N2}", drData["Primary_Deductable"]) + "</td>");
                                    //Convert.ToDateTime(System.Data.SqlTypes.SqlDateTime.MinValue.ToString())
                                    if (Convert.ToDateTime(drData["Date_Alleged_Wrongful_Act"]) != Convert.ToDateTime(System.Data.SqlTypes.SqlDateTime.MinValue.ToString()))
                                    {
                                        strHTML.Append("<td style='width: 150px;' align='left'>" + Convert.ToDateTime(drData["Date_Alleged_Wrongful_Act"]).ToString(DateDisplayFormat) + "</td>");
                                    }
                                    else
                                    {
                                        strHTML.Append("<td style='width: 150px;' align='left'>&nbsp;</td>");
                                    }

                                    if (Convert.ToDateTime(drData["Claim_Open_Date"]) != Convert.ToDateTime(System.Data.SqlTypes.SqlDateTime.MinValue.ToString()))
                                    {
                                        strHTML.Append("<td style='width: 200px;' align='left'>" + Convert.ToDateTime(drData["Claim_Open_Date"]).ToString(DateDisplayFormat) + "</td>");
                                    }
                                    else
                                    {
                                        strHTML.Append("<td style='width: 1200px;' align='left'>&nbsp;</td>");
                                    }

                                    if (Convert.ToDateTime(drData["Primary_Policy_Effective_Date"]) != Convert.ToDateTime(System.Data.SqlTypes.SqlDateTime.MinValue.ToString()))
                                    {
                                        strHTML.Append("<td style='width: 200px;' align='left'>" + Convert.ToDateTime(drData["Primary_Policy_Effective_Date"]).ToString(DateDisplayFormat) + "</td>");
                                    }
                                    else
                                    {
                                        strHTML.Append("<td style='width: 200px;' align='left'>&nbsp;</td>");
                                    }

                                    if (Convert.ToDateTime(drData["Primary_Policy_Expiration_Date"]) != Convert.ToDateTime(System.Data.SqlTypes.SqlDateTime.MinValue.ToString()))
                                    {
                                        strHTML.Append("<td style='width: 150px;' align='left'>" + Convert.ToDateTime(drData["Primary_Policy_Expiration_Date"]).ToString(DateDisplayFormat) + "</td>");
                                    }
                                    else
                                    {
                                        strHTML.Append("<td style='width: 150px;' align='left'>&nbsp;</td>");
                                    }
                                    strHTML.Append("<td style='width: 250px;' align='right'>$ " + string.Format("{0:N2}", drData["Estimated_Demand_Exposure"]) + "</td>");
                                    strHTML.Append("<td style='width: 350px;' align='left'>" + drData["Claim_Status_Comments"] + "</td>");
                                    strHTML.Append("<td style='width: 150px;' align='left'>" + drData["Internal_Counsel"] + "</td>");
                                    strHTML.Append("<td style='width: 200px;' align='left'>" + drData["Legal_Telephone"] + "</td>");

                                    strHTML.Append("<td style='width: 200px;' align='left'>" + drData["Sonic_Location_Code"] + "</td>");
                                    strHTML.Append("<td style='width: 250px;' align='left'>" + drData["legal_entity"] + "</td>");
                                    strHTML.Append("<td style='width: 250px;' align='left'>" + drData["dba"] + "</td>");

                                    strHTML.Append("<td style='width: 250px;' align='left'>" + drData["Entity"] + "</td>");
                                    strHTML.Append("<td style='width: 200px;' align='left'>" + drData["Firm"] + "</td>");
                                    strHTML.Append("<td colspan=4>");

                                    strHTML.Append("<table border=1>");


                                    Int32 PK_Exe = Convert.ToInt32(drData["PK_Executive_Risk"]);

                                    DataRow[] drTADtl = dsReport.Tables[3].Select(" FK_Executive_Risk = " + PK_Exe.ToString());

                                    foreach (DataRow dr in drTADtl)
                                    {
                                        strHTML.Append("<tr align='left' valign='top'>");
                                        strHTML.Append("<td align='left'>" + dr["Firm"] + "</td>");
                                        strHTML.Append("<td align='left'>" + dr["Name"] + "</td>");
                                        strHTML.Append("<td align='left'>" + dr["Full_Address"] + "</td>");
                                        strHTML.Append("<td align='left'>" + dr["Telephone"] + "</td>");
                                        strHTML.Append("</tr>");
                                    }

                                    if (drTADtl.Length <= 0)
                                    {
                                        strHTML.Append("<tr>");
                                        strHTML.Append("<td>&nbsp;</td>");
                                        strHTML.Append("<td>&nbsp;</td>");
                                        strHTML.Append("<td>&nbsp;</td>");
                                        strHTML.Append("<td>&nbsp;</td>");
                                        strHTML.Append("</tr>");
                                    }
                                    strHTML.Append("</table>");
                                    strHTML.Append("</td>");
                                    strHTML.Append("</tr>");
                                }
                                strHTML.Append("<tr style='background-color:#FFFFFF;'>");
                                strHTML.Append("<td style='width: 150px;' align='left'><b>Total</b></td>");
                                strHTML.Append("<td style='width: 250px;' align='left'><b>" + drRegion["Total"].ToString() + "</b></td>");
                                strHTML.Append("<td style='width: 100px;' align='left'>&nbsp;</td>");
                                strHTML.Append("<td style='width: 150px;' align='left'>&nbsp;</td>");
                                strHTML.Append("<td style='width: 150px;' align='left'>&nbsp;</td>");
                                strHTML.Append("<td style='width: 250px;' align='right'>&nbsp;</td>");
                                strHTML.Append("<td style='width: 150px;' align='left'>&nbsp;</td>");
                                strHTML.Append("<td style='width: 200px;' align='left'>&nbsp;</td>");
                                strHTML.Append("<td style='width: 200px;' align='left'>&nbsp;</td>");
                                strHTML.Append("<td style='width: 150px;' align='left'>&nbsp;</td>");
                                strHTML.Append("<td align='left'>&nbsp;</td>");
                                strHTML.Append("<td align='left'>&nbsp;</td>");
                                strHTML.Append("<td align='left'>&nbsp;</td>");
                                strHTML.Append("<td style='width: 250px;' align='right'><b>$ " + string.Format("{0:N2}", drRegion["Total_Exposure"]) + "</b></td>");
                                strHTML.Append("<td style='width: 350px;' align='left'>&nbsp;</td>");
                                strHTML.Append("<td style='width: 150px;' align='left'>&nbsp;</td>");
                                strHTML.Append("<td style='width: 200px;' align='left'>&nbsp;</td>");
                                strHTML.Append("<td style='width: 200px;' align='left'>&nbsp;</td>");
                                strHTML.Append("<td style='width: 250px;' align='left'>&nbsp;</td>");
                                strHTML.Append("<td style='width: 250px;' align='left'>&nbsp;</td>");
                                strHTML.Append("<td style='width: 250px;' align='left'>&nbsp;</td>");
                                strHTML.Append("<td style='width: 200px;' align='left'>&nbsp;</td>");
                                strHTML.Append("<td align='left'></td>");
                                strHTML.Append("<td align='left'></td>");
                                strHTML.Append("<td align='left'></td>");
                                strHTML.Append("<td align='left'></td>");
                                strHTML.Append("</tr>");
                                strHTML.Append("</table>");
                                strHTML.Append("</td></tr>");
                            }
                            strHTML.Append("<tr style='background-color:#507cd1;font-family:Calibri;color:White;'>");
                            strHTML.Append("<td  align='left'><b>Grand Total</b></td>");
                            strHTML.Append("<td  align='left'><b>" + dtTotal.Rows[0]["Total"].ToString() + "</b></td>");
                            strHTML.Append("<td  align='left'>&nbsp;</td>");
                            strHTML.Append("<td  align='left'>&nbsp;</td>");
                            strHTML.Append("<td  align='left'>&nbsp;</td>");
                            strHTML.Append("<td  align='left'>&nbsp;</td>");
                            strHTML.Append("<td  align='left'>&nbsp;</td>");
                            strHTML.Append("<td  align='left'>&nbsp;</td>");
                            strHTML.Append("<td  align='left'>&nbsp;</td>");
                            strHTML.Append("<td  align='left'>&nbsp;</td>");
                            strHTML.Append("<td  align='left'>&nbsp;</td>");
                            strHTML.Append("<td align='left'>&nbsp;</td>");
                            strHTML.Append("<td align='left'>&nbsp;</td>");
                            strHTML.Append("<td  align='right'><b>$ " + string.Format("{0:N2}", dtTotal.Rows[0]["Total_Exposure"]) + "</b></td>");
                            strHTML.Append("<td align='left'>&nbsp;</td>");
                            strHTML.Append("<td align='left'>&nbsp;</td>");
                            strHTML.Append("<td align='left'>&nbsp;</td>");
                            strHTML.Append("<td align='left'>&nbsp;</td>");
                            strHTML.Append("<td align='left'>&nbsp;</td>");
                            strHTML.Append("<td align='left'>&nbsp;</td>");
                            strHTML.Append("<td align='left'>&nbsp;</td>");
                            strHTML.Append("<td align='left'>&nbsp;</td>");
                            strHTML.Append("<td align='left'></td>");
                            strHTML.Append("<td align='left'></td>");
                            strHTML.Append("<td align='left'></td>");
                            strHTML.Append("<td align='left'></td>");
                            strHTML.Append("</tr>");
                            strHTML.Append("</table>");
                            strHTML.Append("</td></tr>");
                            strHTML.Append("</table>");
                        }
                        else
                        {
                            //Add No record found line for year
                            strHTML.Append("<tr><td align='left' colspan='26'>No Record Found!</td></tr>");
                        }

                        strHTML.Append("</div>");

                        //Write HTML in to HtmlWriter
                        htmlWrite.WriteLine(strHTML.ToString());

                        //Send Mail
                        SendMail("FINPRO Bordereau Report", "BordereauReport.xls", strFirstName, strLastName, strMailFrom, stringWrite, dtRecipients);


                    }
                }
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("ERROR in Bordereau Report, " + ex.Message);
            }
        }

        //Report 15
        private void BindNotif_BordereauReport(DataRow drReportSchedule)
        {
            try
            {
                decimal pK_Schedule_ID = Convert.ToDecimal(drReportSchedule["PK_Schedule"]);
                decimal Fk_RecipientList = Convert.ToDecimal(drReportSchedule["Fk_RecipientList"]);
                decimal FK_Security_Id = Convert.ToDecimal(drReportSchedule["FK_Security_Id"]);

                //Get Report criteria for the scheduled report
                DataTable dtFilter = Report.SelectFilterCriteria(15, pK_Schedule_ID).Tables[0];
                if (dtFilter.Rows.Count > 0)
                {
                    //Get the recipient from the recipient list
                    DataTable dtRecipients = Report.SelectOneRecordWithRecipientList(Fk_RecipientList).Tables[0];

                    //Get the user who has scheduled the report
                    DataTable dtUser = Report.SelectSecurityByPK(FK_Security_Id).Tables[0];

                    String strFirstName, strLastName, strMailFrom;
                    strFirstName = strLastName = strMailFrom = "";
                    if (dtUser.Rows.Count > 0)
                    {
                        strFirstName = dtUser.Rows[0]["FIRST_NAME"].ToString();
                        strLastName = dtUser.Rows[0]["LAST_NAME"].ToString();
                        strMailFrom = dtUser.Rows[0]["Email"].ToString();
                        string strMarket = null;
                        if (!string.IsNullOrEmpty(Convert.ToString(dtFilter.Rows[0]["Market"])))
                        {
                            strMarket = Convert.ToString(dtFilter.Rows[0]["Market"]).Trim();
                        }
                        // get start date
                        DateTime Start_Date = Convert.ToDateTime(dtFilter.Rows[0]["Start_Date"]);
                        // get end date
                        DateTime End_Date = Convert.ToDateTime(dtFilter.Rows[0]["End_Date"]);


                        // get result records from database for the report
                        DataSet dsReport = Report.Get_Notification_Bordereau_Report(Start_Date, End_Date, Convert.ToString(dtFilter.Rows[0]["Region"]), strMarket);

                        //Create HTML for the report and wirte into HTML Write object
                        StringBuilder strHTML = new StringBuilder();
                        System.IO.StringWriter stringWrite = new System.IO.StringWriter();
                        System.Web.UI.HtmlTextWriter htmlWrite = new System.Web.UI.HtmlTextWriter(stringWrite);

                        #region "Header"

                        //Retrieve Market Values
                        string strMarketString = string.Empty;
                        if (string.IsNullOrEmpty(strMarket))
                        {
                            strMarketString = "All Market";
                        }
                        else
                        {
                            string[] strMar = strMarket.Split(Convert.ToChar(","));
                            for (int i = 0; i < strMar.Length; i++)
                            {
                                strMarketString += Report.SelectMarketInfoById(Convert.ToDecimal(strMar[i].ToString())).Tables[0].Rows[0]["Market"].ToString() + ",";
                            }
                            strMarketString = strMarketString.TrimEnd(',');
                        }

                        //Add Report Title and Schedule Date
                        strHTML.Append("<span style=\"font-family:Calibri;\">");
                        strHTML.Append("<br />");
                        strHTML.Append("<b>Report Title : FINPRO Claim Notification Bordereau Report</b>");
                        strHTML.Append("<br /><br />");
                        strHTML.Append("Schedule Date : " + Convert.ToDateTime(drReportSchedule["Scheduled_Date"]).ToString(DateDisplayFormat));
                        strHTML.Append("&nbsp;&nbsp;&nbsp;&nbsp;Schedule End Date : " + Convert.ToDateTime(drReportSchedule["Schedule_End_Date"]).ToString(DateDisplayFormat));
                        strHTML.Append("<br />");
                        strHTML.Append("Recurring Period : " + drReportSchedule["Recurring_Period"]).ToString();
                        strHTML.Append("<br />");
                        strHTML.Append("Recurring Date : " + dtSchduleDate.ToString(DateDisplayFormat));

                        //Add Report Filter Criteria 
                        strHTML.Append("<br /><br />");
                        strHTML.Append("<b>Report Filters </b>");
                        strHTML.Append("<br /><br />");
                        strHTML.Append("Date Claim Opened Between " + Start_Date.ToString(DateDisplayFormat) + " and " + End_Date.ToString(DateDisplayFormat));
                        strHTML.Append("<br />");
                        strHTML.Append("Regions              : " + (string.IsNullOrEmpty(Convert.ToString(dtFilter.Rows[0]["Region"])) ? "All" : dtFilter.Rows[0]["Region"].ToString()));
                        strHTML.Append("<br /><br />");
                        strHTML.Append("Market        : " + strMarketString);
                        strHTML.Append("<br /><br />");
                        strHTML.Append("</span>");

                        //Add Header HTML
                        strHTML.Append("<div style=\"overflow-x:scroll;overflow-y:hidden;width:1200px;\">");
                        strHTML.Append("<table cellpadding='4' cellspacing='0' style='font-weight: bold;font-family:Calibri;' width='1400px' border='1'><tr>");
                        strHTML.Append("<td style='width: 150px;' align='left'>Date Claim Opened</td>");
                        strHTML.Append("<td style='width: 250px;' align='left'>Claimant/Plaintiff</td>");

                        strHTML.Append("<td style='width: 120px;' align='left'>Location Code</td>");
                        strHTML.Append("<td style='width: 120px;' align='left'>Sonic Location Name</td>");
                        strHTML.Append("<td style='width: 120px;' align='left'>Location dba</td>");
                        strHTML.Append("<td style='width: 120px;' align='left'>Entity</td>");
                        strHTML.Append("<td style='width: 150px;' align='right'>Defense Cost</td>");
                        strHTML.Append("<td style='width: 150px;' align='left'>Defense Attorney</td>");
                        strHTML.Append("<td style='width: 250px;' align='left'>Type of Allegation</td>");
                        strHTML.Append("<td style='width: 150px;' align='left'>Claim Status/Comments</td>");
                        strHTML.Append("<td style='width: 200px;' align='left'>Settlement</td>");
                        strHTML.Append("</tr></table>");
                        #endregion

                        DataTable dtReportData = dsReport.Tables[0];
                        DataTable dtRegion = dsReport.Tables[1];
                        DataTable dtTotal = dsReport.Tables[2];
                        if (dtRegion.Rows.Count > 0)
                        {
                            //Add Report Data Table 
                            strHTML.Append("<table style='width: 1400px;' border='1' align='left' cellpadding='4' cellspacing='0'>");
                            foreach (DataRow drRegion in dtRegion.Rows)
                            {
                                strHTML.Append("<tr><td colspan='8' style='font-family:Calibri;'><b>");
                                strHTML.Append(drRegion["Region"].ToString());
                                strHTML.Append("</b></td></tr>");
                                strHTML.Append("<tr><td colspan='8'>");
                                strHTML.Append("<table style='width: 1400px;font-family:Calibri;' border='1' align='left' cellpadding='4' cellspacing='0'>");
                                DataRow[] drDataByRegion = dtReportData.Select("Region='" + drRegion["Region"].ToString() + "'");
                                foreach (DataRow drData in drDataByRegion)
                                {
                                    strHTML.Append("<tr style='background-color:#FFFFFF;'>");
                                    if (Convert.ToDateTime(drData["Claim_Open_Date"]) != Convert.ToDateTime(System.Data.SqlTypes.SqlDateTime.MinValue.ToString()))
                                    {
                                        strHTML.Append("<td style='width: 150px;' align='left'>" + Convert.ToDateTime(drData["Claim_Open_Date"]).ToString(DateDisplayFormat) + "</td>");
                                    }
                                    else
                                    {
                                        strHTML.Append("<td style='width: 150px;' align='left'>&nbsp;</td>");
                                    }
                                    strHTML.Append("<td style='width: 250px;' align='left'>" + drData["Complainant_Plaintiff"] + "</td>");

                                    strHTML.Append("<td style='width: 120px;' align='left'>" + drData["Sonic_Location_Code"] + "</td>");
                                    strHTML.Append("<td style='width: 120px;' align='left'>" + drData["legal_entity"] + "</td>");
                                    strHTML.Append("<td style='width: 120px;' align='left'>" + drData["dba"] + "</td>");
                                    strHTML.Append("<td style='width: 120px;' align='left'>" + drData["Entity"] + "</td>");
                                    if (!string.IsNullOrEmpty(Convert.ToString(drData["DefenseCost"])))
                                        strHTML.Append("<td style='width: 150px;' align='right'>$ " + string.Format("{0:N2}", drData["DefenseCost"]) + "</td>");
                                    else
                                        strHTML.Append("<td style='width: 150px;' align='right'>&nbsp;</td>");
                                    strHTML.Append("<td style='width: 150px;' align='left'>" + drData["DefenseAttorney"] + "</td>");
                                    strHTML.Append("<td style='width: 250px;' align='left'>" + drData["Type_of_Allegation"] + "</td>");
                                    strHTML.Append("<td style='width: 150px;' align='left'>" + drData["Claim_Status_Comments"] + "</td>");
                                    strHTML.Append("<td style='width: 200px;' align='right'>$ " + string.Format("{0:N2}", drData["Actual_Settlement"]) + "</td>");
                                    strHTML.Append("</tr>");
                                }
                                strHTML.Append("<tr style='background-color:#FFFFFF;'>");
                                strHTML.Append("<td style='width: 150px;' align='left'><b>Total</b></td>");
                                strHTML.Append("<td style='width: 250px;' align='left'><b>" + drRegion["Total"].ToString() + "</b></td>");
                                strHTML.Append("<td style='width: 100px;' align='left'>&nbsp;</td>");
                                strHTML.Append("<td style='width: 150px;' align='right'><b>$ " + string.Format("{0:N2}", drRegion["Total_DefenseCost"]) + "</b></td>");
                                strHTML.Append("<td style='width: 150px;' align='left'>&nbsp;</td>");
                                strHTML.Append("<td style='width: 250px;' align='left'>&nbsp;</td>");
                                strHTML.Append("<td style='width: 150px;' align='left'>&nbsp;</td>");
                                strHTML.Append("<td style='width: 200px;' align='left'>&nbsp;</td>");
                                strHTML.Append("</tr>");
                                strHTML.Append("</table>");
                                strHTML.Append("</td></tr>");
                            }
                            strHTML.Append("<tr style='background-color:#507cd1;font-family:Calibri;color:White;'>");
                            strHTML.Append("<td style='width: 150px;' align='left'><b>Grand Total</b></td>");
                            strHTML.Append("<td style='width: 250px;' align='left'><b>" + dtTotal.Rows[0]["Total"].ToString() + "</b></td>");
                            strHTML.Append("<td style='width: 120px;' align='left'>&nbsp;</td>");
                            strHTML.Append("<td style='width: 120px;' align='left'>&nbsp;</td>");
                            strHTML.Append("<td style='width: 120px;' align='left'>&nbsp;</td>");
                            strHTML.Append("<td style='width: 120px;' align='left'>&nbsp;</td>");
                            strHTML.Append("<td style='width: 150px;' align='right'><b>$ " + string.Format("{0:N2}", dtTotal.Rows[0]["Total_DefenseCost"]) + "</b></td>");
                            strHTML.Append("<td style='width: 150px;' align='left'>&nbsp;</td>");
                            strHTML.Append("<td style='width: 250px;' align='lef'>&nbsp;</td>");
                            strHTML.Append("<td style='width: 150px;' align='left'>&nbsp;</td>");
                            strHTML.Append("<td style='width: 200px;' align='left'>&nbsp;</td>");
                            strHTML.Append("</tr>");
                            strHTML.Append("</table>");
                            strHTML.Append("</td></tr>");
                            strHTML.Append("</table>");
                        }
                        else
                        {
                            //Add No record found line for year
                            strHTML.Append("<tr><td align='left' colspan='8'>No Record Found!</td></tr>");
                        }

                        strHTML.Append("</div>");

                        //Write HTML in to HtmlWriter
                        htmlWrite.WriteLine(strHTML.ToString());

                        //Send Mail
                        SendMail("FINPRO Claim Notification Bordereau Report", "ClaimNotificationBordereauReport .xls", strFirstName, strLastName, strMailFrom, stringWrite, dtRecipients);


                    }
                }
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("ERROR in Claim Notification Bordereau Report , " + ex.Message);
            }
        }

        //Report 16
        private void BindEPLIPendingInvestigationandLitigationSummaryReport(DataRow drReportSchedule)
        {
            try
            {
                decimal pK_Schedule_ID = Convert.ToDecimal(drReportSchedule["PK_Schedule"]);
                decimal Fk_RecipientList = Convert.ToDecimal(drReportSchedule["Fk_RecipientList"]);
                decimal FK_Security_Id = Convert.ToDecimal(drReportSchedule["FK_Security_Id"]);

                //Get Report criteria for the scheduled report
                DataTable dtFilter = Report.SelectFilterCriteria(16, pK_Schedule_ID).Tables[0];
                if (dtFilter.Rows.Count > 0)
                {
                    //Get the recipient from the recipient list
                    DataTable dtRecipients = Report.SelectOneRecordWithRecipientList(Fk_RecipientList).Tables[0];

                    //Get the user who has scheduled the report
                    DataTable dtUser = Report.SelectSecurityByPK(FK_Security_Id).Tables[0];

                    String strFirstName, strLastName, strMailFrom;
                    strFirstName = strLastName = strMailFrom = "";
                    if (dtUser.Rows.Count > 0)
                    {
                        strFirstName = dtUser.Rows[0]["FIRST_NAME"].ToString();
                        strLastName = dtUser.Rows[0]["LAST_NAME"].ToString();
                        strMailFrom = dtUser.Rows[0]["Email"].ToString();
                        string strMarket = null;
                        if (!string.IsNullOrEmpty(Convert.ToString(dtFilter.Rows[0]["Market"])))
                        {
                            strMarket = Convert.ToString(dtFilter.Rows[0]["Market"]).Trim();
                        }
                        // get start date
                        DateTime Start_Date = Convert.ToDateTime(dtFilter.Rows[0]["Start_Date"]);
                        // get end date
                        DateTime End_Date = Convert.ToDateTime(dtFilter.Rows[0]["End_Date"]);

                        // get result records from database for the report
                        DataSet dsReport = Report.Get_Litigation_Summary_Report(Start_Date, End_Date, Convert.ToString(dtFilter.Rows[0]["Region"]),strMarket);

                        //Create HTML for the report and wirte into HTML Write object
                        StringBuilder strHTML = new StringBuilder();
                        System.IO.StringWriter stringWrite = new System.IO.StringWriter();
                        System.Web.UI.HtmlTextWriter htmlWrite = new System.Web.UI.HtmlTextWriter(stringWrite);

                        #region "Header"

                        //Retrieve Market Values
                        string strMarketString = string.Empty;
                        if (string.IsNullOrEmpty(strMarket))
                        {
                            strMarketString = "All Market";
                        }
                        else
                        {
                            string[] strMar = strMarket.Split(Convert.ToChar(","));
                            for (int i = 0; i < strMar.Length; i++)
                            {
                                strMarketString += Report.SelectMarketInfoById(Convert.ToDecimal(strMar[i].ToString())).Tables[0].Rows[0]["Market"].ToString() + ",";
                            }
                            strMarketString = strMarketString.TrimEnd(',');
                        }

                        //Add Report Title and Schedule Date
                        strHTML.Append("<span style=\"font-family:Calibri;\">");
                        strHTML.Append("<br />");
                        strHTML.Append("<b>Report Title : EPLI Pending Investigation and Litigation Summary Report </b>");
                        strHTML.Append("<br /><br />");
                        strHTML.Append("Schedule Date : " + Convert.ToDateTime(drReportSchedule["Scheduled_Date"]).ToString(DateDisplayFormat));
                        strHTML.Append("&nbsp;&nbsp;&nbsp;&nbsp;Schedule End Date : " + Convert.ToDateTime(drReportSchedule["Schedule_End_Date"]).ToString(DateDisplayFormat));
                        strHTML.Append("<br />");
                        strHTML.Append("Recurring Period : " + drReportSchedule["Recurring_Period"]).ToString();
                        strHTML.Append("<br />");
                        strHTML.Append("Recurring Date : " + dtSchduleDate.ToString(DateDisplayFormat));

                        //Add Report Filter Criteria 
                        strHTML.Append("<br /><br />");
                        strHTML.Append("<b>Report Filters </b>");
                        strHTML.Append("<br /><br />");
                        strHTML.Append("Date Claim Opened Between " + Start_Date.ToString(DateDisplayFormat) + " and " + End_Date.ToString(DateDisplayFormat));
                        strHTML.Append("<br />");
                        strHTML.Append("Regions              : " + (string.IsNullOrEmpty(Convert.ToString(dtFilter.Rows[0]["Region"])) ? "All" : dtFilter.Rows[0]["Region"].ToString()));
                        strHTML.Append("<br /><br />");
                        strHTML.Append("Market        : " + strMarketString);
                        strHTML.Append("<br /><br />");
                        strHTML.Append("</span>");

                        //Add Header HTML
                        strHTML.Append("<div style=\"overflow-x:scroll;overflow-y:hidden;width:1750px;\">");
                        strHTML.Append("<table cellpadding='4' cellspacing='0' style='font-weight: bold;font-family:Calibri;' width='1750px' border='1'><tr>");
                        strHTML.Append("<td style='width: 150px;' align='left'>Region</td>");
                        strHTML.Append("<td style='width: 250px;' align='left'>Store</td>");
                        strHTML.Append("<td style='width: 150px;' align='left'>Date Claim Opened</td>");
                        strHTML.Append("<td style='width: 150px;' align='left'>Complainant/Plaintiff</td>");
                        strHTML.Append("<td style='width: 150px;' align='left'>Defense Attorney</td>");
                        strHTML.Append("<td style='width: 450px;' align='left'>Claim Description</td>");
                        strHTML.Append("<td style='width: 450px;' align='left'>Claim Status/Comments</td>");
                        strHTML.Append("</tr></table>");
                        #endregion

                        DataTable dtReportData = dsReport.Tables[0];
                        DataTable dtRegion = dsReport.Tables[1];
                        DataTable dtTotal = dsReport.Tables[2];
                        if (dtRegion.Rows.Count > 0)
                        {
                            //Add Report Data Table 
                            strHTML.Append("<table style='width: 1750px;' border='1' align='left' cellpadding='4' cellspacing='0'>");
                            foreach (DataRow drRegion in dtRegion.Rows)
                            {
                                strHTML.Append("<tr><td colspan='7'>");
                                strHTML.Append("<table style='width: 1750px;font-family:Calibri;' border='1' align='left' cellpadding='4' cellspacing='0'>");
                                DataRow[] drDataByRegion = dtReportData.Select("Region='" + drRegion["Region"].ToString() + "'");
                                foreach (DataRow drData in drDataByRegion)
                                {
                                    strHTML.Append("<tr style='background-color:#FFFFFF;'>");
                                    strHTML.Append("<td style='width: 150px;' align='left'>" + drData["Region"] + "</td>");
                                    strHTML.Append("<td style='width: 250px;' align='left'>" + drData["Location_Description"] + "</td>");
                                    if (Convert.ToDateTime(drData["Claim_Open_Date"]) != Convert.ToDateTime(System.Data.SqlTypes.SqlDateTime.MinValue.ToString()))
                                    {
                                        strHTML.Append("<td style='width: 150px;' align='left'>" + Convert.ToDateTime(drData["Claim_Open_Date"]).ToString(DateDisplayFormat) + "</td>");
                                    }
                                    else
                                    {
                                        strHTML.Append("<td style='width: 150px;' align='left'>&nbsp;</td>");
                                    }

                                    strHTML.Append("<td style='width: 150px;' align='left'>" + drData["Complainant_Plaintiff"] + "</td>");
                                    strHTML.Append("<td style='width: 150px;' align='left'>" + drData["DefenseAttorney"] + "</td>");
                                    strHTML.Append("<td style='width: 450px;' align='left'>");
                                    if (!string.IsNullOrEmpty(Convert.ToString(drData["Type_of_Allegation"])))
                                        strHTML.Append("<b>" + drData["Type_of_Allegation"] + "</b>:" + drData["Claim_Description"] + "</td>");
                                    else
                                        strHTML.Append(drData["Claim_Description"] + "</td>");
                                    strHTML.Append("<td style='width: 450px;' align='left'>" + drData["Claim_Status_Comments"] + "</td>");

                                    strHTML.Append("</tr>");
                                }
                                strHTML.Append("<tr style='background-color:#FFFFFF;'>");
                                strHTML.Append("<td style='width: 150px;' align='left'><b>Total</b></td>");
                                strHTML.Append("<td style='width: 250px;' align='left'><b>" + drRegion["Total"].ToString() + "</b></td>");
                                strHTML.Append("<td style='width: 150px;' align='left'>&nbsp;</td>");
                                strHTML.Append("<td style='width: 150px;' align='left'>&nbsp;</td>");
                                strHTML.Append("<td style='width: 150px;' align='left'>&nbsp;</td>");
                                strHTML.Append("<td style='width: 450px;' align='left'>&nbsp;</td>");
                                strHTML.Append("<td style='width: 450px;' align='left'>&nbsp;</td>");
                                strHTML.Append("</tr>");
                                strHTML.Append("</table>");
                                strHTML.Append("</td></tr>");
                            }
                            strHTML.Append("<tr style='background-color:#507cd1;font-family:Calibri;color:White;'>");
                            strHTML.Append("<td style='width: 150px;' align='left'><b>Grand Total</b></td>");
                            strHTML.Append("<td style='width: 250px;' align='left'><b>" + dtTotal.Rows[0]["Total"].ToString() + "</b></td>");
                            strHTML.Append("<td style='width: 150px;' align='left'>&nbsp;</td>");
                            strHTML.Append("<td style='width: 150px;' align='left'>&nbsp;</td>");
                            strHTML.Append("<td style='width: 150px;' align='left'>&nbsp;</td>");
                            strHTML.Append("<td style='width: 450px;' align='lef'>&nbsp;</td>");
                            strHTML.Append("<td style='width: 450px;' align='left'>&nbsp;</td>");
                            strHTML.Append("</tr>");
                            strHTML.Append("</table>");
                            strHTML.Append("</td></tr>");
                            strHTML.Append("</table>");
                        }
                        else
                        {
                            //Add No record found line for year
                            strHTML.Append("<tr><td align='left' colspan='7'>No Record Found!</td></tr>");
                        }

                        strHTML.Append("</div>");

                        //Write HTML in to HtmlWriter
                        htmlWrite.WriteLine(strHTML.ToString());

                        //Send Mail
                        SendMail("EPLI Pending Investigation and Litigation Summary Report", "EPLIPendingInvestigationandLitigationSummaryReport .xls", strFirstName, strLastName, strMailFrom, stringWrite, dtRecipients);


                    }
                }
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("ERROR in EPLI Pending Investigation and Litigation Summary Report , " + ex.Message);
            }
        }

        //Report 17
        private void BindImmediatelyReportableClaims(DataRow drReportSchedule)
        {
            try
            {
                decimal pK_Schedule_ID = Convert.ToDecimal(drReportSchedule["PK_Schedule"]);
                decimal Fk_RecipientList = Convert.ToDecimal(drReportSchedule["Fk_RecipientList"]);
                decimal FK_Security_Id = Convert.ToDecimal(drReportSchedule["FK_Security_Id"]);

                //Get Report criteria for the scheduled report
                DataTable dtFilter = Report.SelectFilterCriteria(17, pK_Schedule_ID).Tables[0];
                if (dtFilter.Rows.Count > 0)
                {
                    //Get the recipient from the recipient list
                    DataTable dtRecipients = Report.SelectOneRecordWithRecipientList(Fk_RecipientList).Tables[0];

                    //Get the user who has scheduled the report
                    DataTable dtUser = Report.SelectSecurityByPK(FK_Security_Id).Tables[0];

                    String strFirstName, strLastName, strMailFrom;
                    strFirstName = strLastName = strMailFrom = "";
                    if (dtUser.Rows.Count > 0)
                    {
                        strFirstName = dtUser.Rows[0]["FIRST_NAME"].ToString();
                        strLastName = dtUser.Rows[0]["LAST_NAME"].ToString();
                        strMailFrom = dtUser.Rows[0]["Email"].ToString();

                        // get result records from database for the report
                        DataSet dsReport = Report.Get_Reportable_Claims_Report();

                        //Create HTML for the report and wirte into HTML Write object
                        StringBuilder strHTML = new StringBuilder();
                        System.IO.StringWriter stringWrite = new System.IO.StringWriter();
                        System.Web.UI.HtmlTextWriter htmlWrite = new System.Web.UI.HtmlTextWriter(stringWrite);

                        #region "Header"

                        //Add Report Title and Schedule Date
                        strHTML.Append("<span style=\"font-family:Calibri;\">");
                        strHTML.Append("<br />");
                        strHTML.Append("<b>Report Title : FINPRO Immediately Reportable Claims</b>");
                        strHTML.Append("<br /><br />");
                        strHTML.Append("Schedule Date : " + Convert.ToDateTime(drReportSchedule["Scheduled_Date"]).ToString(DateDisplayFormat));
                        strHTML.Append("&nbsp;&nbsp;&nbsp;&nbsp;Schedule End Date : " + Convert.ToDateTime(drReportSchedule["Schedule_End_Date"]).ToString(DateDisplayFormat));
                        strHTML.Append("<br />");
                        strHTML.Append("Recurring Period : " + drReportSchedule["Recurring_Period"]).ToString();
                        strHTML.Append("<br />");
                        strHTML.Append("Recurring Date : " + dtSchduleDate.ToString(DateDisplayFormat));

                        //Add Header HTML
                        strHTML.Append("<div style=\"overflow-x:scroll;overflow-y:hidden;width:1200px;\">");
                        strHTML.Append("<table cellpadding='4' cellspacing='0' style='font-weight: bold;font-family:Calibri;' width='3150px' border='1'><tr>");
                        strHTML.Append("<td style='width: 150px;' align='left'>Type of Allegation</td>");
                        strHTML.Append("<td style='width: 250px;' align='left'>Claim Description</td>");
                        strHTML.Append("<td style='width: 100px;' align='left'>Carrier</td>");
                        strHTML.Append("<td style='width: 150px;' align='left'>Type of Claim</td>");
                        strHTML.Append("<td style='width: 150px;' align='left'>Policy Number</td>");
                        strHTML.Append("<td style='width: 250px;' align='right'>Deductible</td>");
                        strHTML.Append("<td style='width: 150px;' align='left'>Date of Alleged Wrongful Act</td>");
                        strHTML.Append("<td style='width: 200px;' align='left'>Date Claim Opened</td>");
                        strHTML.Append("<td style='width: 200px;' align='left'>Policy Effective Date</td>");
                        strHTML.Append("<td style='width: 150px;' align='left'>Policy Expiration Date</td>");
                        strHTML.Append("<td style='width: 250px;' align='right'>Estimated Demand Exposure</td>");
                        strHTML.Append("<td style='width: 350px;' align='left'>Claim Status/Comments</td>");
                        strHTML.Append("<td style='width: 150px;' align='left'>Internal Counsel</td>");
                        strHTML.Append("<td style='width: 200px;' align='left'>Internal Counsel Phone</td>");

                        strHTML.Append("<td style='width: 250px;' align='left'>Location Code</td>");
                        strHTML.Append("<td style='width: 250px;' align='left'>Sonic Location Name</td>");
                        strHTML.Append("<td style='width: 250px;' align='left'>Location dba</td>");
                        strHTML.Append("<td style='width: 250px;' align='left'>Entity</td>");
                        strHTML.Append("<td style='width: 200px;' align='left'>Defense Attorney</td>");
                        strHTML.Append("</tr></table>");
                        #endregion

                        DataTable dtReportData = dsReport.Tables[0];
                        DataTable dtRegion = dsReport.Tables[1];
                        DataTable dtTotal = dsReport.Tables[2];
                        if (dtRegion.Rows.Count > 0)
                        {
                            //Add Report Data Table 
                            strHTML.Append("<table style='width: 3150px;' border='1' align='left' cellpadding='4' cellspacing='0'>");
                            foreach (DataRow drRegion in dtRegion.Rows)
                            {
                                strHTML.Append("<tr><td colspan='16' style='font-family:Calibri;'><b>");
                                strHTML.Append(drRegion["Region"].ToString());
                                strHTML.Append("</b></td></tr>");
                                strHTML.Append("<tr><td colspan='16'>");
                                strHTML.Append("<table style='width: 3150px;font-family:Calibri;' border='1' align='left' cellpadding='4' cellspacing='0'>");
                                DataRow[] drDataByRegion = dtReportData.Select("Region='" + drRegion["Region"].ToString() + "'");
                                foreach (DataRow drData in drDataByRegion)
                                {
                                    strHTML.Append("<tr style='background-color:#FFFFFF;'>");
                                    strHTML.Append("<td style='width: 150px;' align='left'>" + drData["Type_of_Allegation"] + "</td>");
                                    strHTML.Append("<td style='width: 250px;' align='left'>" + drData["Claim_Description"] + "</td>");
                                    strHTML.Append("<td style='width: 100px;' align='left'>" + drData["Carrier"] + "</td>");
                                    strHTML.Append("<td style='width: 150px;' align='left'>" + drData["Type_Of_Claim"] + "</td>");
                                    strHTML.Append("<td style='width: 150px;' align='left'>" + drData["Primary_Insurance_Policy_Number"] + "</td>");
                                    strHTML.Append("<td style='width: 250px;' align='right'>$ " + string.Format("{0:N2}", drData["Primary_Deductable"]) + "</td>");
                                    //Convert.ToDateTime(System.Data.SqlTypes.SqlDateTime.MinValue.ToString())
                                    if (Convert.ToDateTime(drData["Date_Alleged_Wrongful_Act"]) != Convert.ToDateTime(System.Data.SqlTypes.SqlDateTime.MinValue.ToString()))
                                    {
                                        strHTML.Append("<td style='width: 150px;' align='left'>" + Convert.ToDateTime(drData["Date_Alleged_Wrongful_Act"]).ToString(DateDisplayFormat) + "</td>");
                                    }
                                    else
                                    {
                                        strHTML.Append("<td style='width: 150px;' align='left'>&nbsp;</td>");
                                    }

                                    if (Convert.ToDateTime(drData["Claim_Open_Date"]) != Convert.ToDateTime(System.Data.SqlTypes.SqlDateTime.MinValue.ToString()))
                                    {
                                        strHTML.Append("<td style='width: 200px;' align='left'>" + Convert.ToDateTime(drData["Claim_Open_Date"]).ToString(DateDisplayFormat) + "</td>");
                                    }
                                    else
                                    {
                                        strHTML.Append("<td style='width: 1200px;' align='left'>&nbsp;</td>");
                                    }

                                    if (Convert.ToDateTime(drData["Primary_Policy_Effective_Date"]) != Convert.ToDateTime(System.Data.SqlTypes.SqlDateTime.MinValue.ToString()))
                                    {
                                        strHTML.Append("<td style='width: 200px;' align='left'>" + Convert.ToDateTime(drData["Primary_Policy_Effective_Date"]).ToString(DateDisplayFormat) + "</td>");
                                    }
                                    else
                                    {
                                        strHTML.Append("<td style='width: 200px;' align='left'>&nbsp;</td>");
                                    }

                                    if (Convert.ToDateTime(drData["Primary_Policy_Expiration_Date"]) != Convert.ToDateTime(System.Data.SqlTypes.SqlDateTime.MinValue.ToString()))
                                    {
                                        strHTML.Append("<td style='width: 150px;' align='left'>" + Convert.ToDateTime(drData["Primary_Policy_Expiration_Date"]).ToString(DateDisplayFormat) + "</td>");
                                    }
                                    else
                                    {
                                        strHTML.Append("<td style='width: 150px;' align='left'>&nbsp;</td>");
                                    }
                                    strHTML.Append("<td style='width: 250px;' align='right'>$ " + string.Format("{0:N2}", drData["Estimated_Demand_Exposure"]) + "</td>");
                                    strHTML.Append("<td style='width: 350px;' align='left'>" + drData["Claim_Status_Comments"] + "</td>");
                                    strHTML.Append("<td style='width: 150px;' align='left'>" + drData["Internal_Counsel"] + "</td>");
                                    strHTML.Append("<td style='width: 200px;' align='left'>" + drData["Legal_Telephone"] + "</td>");

                                    strHTML.Append("<td style='width: 250px;' align='left'>" + drData["Sonic_Location_Code"] + "</td>");
                                    strHTML.Append("<td style='width: 250px;' align='left'>" + drData["legal_entity"] + "</td>");
                                    strHTML.Append("<td style='width: 250px;' align='left'>" + drData["dba"] + "</td>");
                                    strHTML.Append("<td style='width: 250px;' align='left'>" + drData["Entity"] + "</td>");
                                    strHTML.Append("<td style='width: 200px;' align='left'>" + drData["Firm"] + "</td>");
                                    strHTML.Append("</tr>");
                                }
                                strHTML.Append("<tr style='background-color:#FFFFFF;'>");
                                strHTML.Append("<td style='width: 150px;' align='left'><b>Total</b></td>");
                                strHTML.Append("<td style='width: 250px;' align='left'><b>" + drRegion["Total"].ToString() + "</b></td>");
                                strHTML.Append("<td style='width: 100px;' align='left'>&nbsp;</td>");
                                strHTML.Append("<td style='width: 150px;' align='left'>&nbsp;</td>");
                                strHTML.Append("<td style='width: 150px;' align='left'>&nbsp;</td>");
                                strHTML.Append("<td style='width: 250px;' align='right'>&nbsp;</td>");
                                strHTML.Append("<td style='width: 150px;' align='left'>&nbsp;</td>");
                                strHTML.Append("<td style='width: 200px;' align='left'>&nbsp;</td>");
                                strHTML.Append("<td style='width: 200px;' align='left'>&nbsp;</td>");
                                strHTML.Append("<td style='width: 150px;' align='left'>&nbsp;</td>");
                                strHTML.Append("<td style='width: 250px;' align='right'><b>$ " + string.Format("{0:N2}", drRegion["Total_Exposure"]) + "</b></td>");
                                strHTML.Append("<td style='width: 350px;' align='left'>&nbsp;</td>");
                                strHTML.Append("<td style='width: 150px;' align='left'>&nbsp;</td>");
                                strHTML.Append("<td style='width: 200px;' align='left'>&nbsp;</td>");
                                strHTML.Append("<td style='width: 250px;' align='left'>&nbsp;</td>");
                                strHTML.Append("<td style='width: 250px;' align='left'>&nbsp;</td>");
                                strHTML.Append("<td style='width: 250px;' align='left'>&nbsp;</td>");
                                strHTML.Append("<td style='width: 250px;' align='left'>&nbsp;</td>");
                                strHTML.Append("<td style='width: 200px;' align='left'>&nbsp;</td>");
                                strHTML.Append("</tr>");
                                strHTML.Append("</table>");
                                strHTML.Append("</td></tr>");
                            }
                            strHTML.Append("<tr style='background-color:#507cd1;font-family:Calibri;color:White;'>");
                            strHTML.Append("<td style='width: 150px;' align='left'><b>Grand Total</b></td>");
                            strHTML.Append("<td style='width: 250px;' align='left'><b>" + dtTotal.Rows[0]["Total"].ToString() + "</b></td>");
                            strHTML.Append("<td style='width: 100px;' align='left'>&nbsp;</td>");
                            strHTML.Append("<td style='width: 150px;' align='left'>&nbsp;</td>");
                            strHTML.Append("<td style='width: 150px;' align='left'>&nbsp;</td>");
                            strHTML.Append("<td style='width: 250px;' align='right'>&nbsp;</td>");
                            strHTML.Append("<td style='width: 150px;' align='left'>&nbsp;</td>");
                            strHTML.Append("<td style='width: 200px;' align='left'>&nbsp;</td>");
                            strHTML.Append("<td style='width: 200px;' align='left'>&nbsp;</td>");
                            strHTML.Append("<td style='width: 150px;' align='left'>&nbsp;</td>");
                            strHTML.Append("<td style='width: 250px;' align='right'><b>$ " + string.Format("{0:N2}", dtTotal.Rows[0]["Total_Exposure"]) + "</b></td>");
                            strHTML.Append("<td style='width: 350px;' align='left'>&nbsp;</td>");
                            strHTML.Append("<td style='width: 150px;' align='left'>&nbsp;</td>");
                            strHTML.Append("<td style='width: 200px;' align='left'>&nbsp;</td>");
                            strHTML.Append("<td style='width: 250px;' align='left'>&nbsp;</td>");
                            strHTML.Append("<td style='width: 200px;' align='left'>&nbsp;</td>");
                            strHTML.Append("</tr>");
                            strHTML.Append("</table>");
                            strHTML.Append("</td></tr>");
                            strHTML.Append("</table>");
                        }
                        else
                        {
                            //Add No record found line for year
                            strHTML.Append("<tr><td align='left' colspan='16'>No Record Found!</td></tr>");
                        }

                        strHTML.Append("</div>");

                        //Write HTML in to HtmlWriter
                        htmlWrite.WriteLine(strHTML.ToString());

                        //Send Mail
                        SendMail("FINPRO Immediately Reportable Claims Report", "ImmediatelyReportableClaimsReport.xls", strFirstName, strLastName, strMailFrom, stringWrite, dtRecipients);


                    }
                }
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("ERROR in Immediately Reportable Claims Report, " + ex.Message);
            }
        }

        //Report 18
        private void BindNetworkCallSummaryReport(DataRow drReportSchedule)
        {
            try
            {
                decimal pK_Schedule_ID = Convert.ToDecimal(drReportSchedule["PK_Schedule"]);
                decimal Fk_RecipientList = Convert.ToDecimal(drReportSchedule["Fk_RecipientList"]);
                decimal FK_Security_Id = Convert.ToDecimal(drReportSchedule["FK_Security_Id"]);

                //Get Report criteria for the scheduled report
                DataTable dtFilter = Report.SelectFilterCriteria(18, pK_Schedule_ID).Tables[0];
                if (dtFilter.Rows.Count > 0)
                {
                    //Get the recipient from the recipient list
                    DataTable dtRecipients = Report.SelectOneRecordWithRecipientList(Fk_RecipientList).Tables[0];

                    //Get the user who has scheduled the report
                    DataTable dtUser = Report.SelectSecurityByPK(FK_Security_Id).Tables[0];

                    String strFirstName, strLastName, strMailFrom;
                    strFirstName = strLastName = strMailFrom = "";
                    if (dtUser.Rows.Count > 0)
                    {
                        strFirstName = dtUser.Rows[0]["FIRST_NAME"].ToString();
                        strLastName = dtUser.Rows[0]["LAST_NAME"].ToString();
                        strMailFrom = dtUser.Rows[0]["Email"].ToString();
                        string strMarket = null;
                        if (!string.IsNullOrEmpty(Convert.ToString(dtFilter.Rows[0]["Market"])))
                        {
                            strMarket = Convert.ToString(dtFilter.Rows[0]["Market"]).Trim();
                        }
                        // get start date
                        DateTime Start_Date = Convert.ToDateTime(dtFilter.Rows[0]["Start_Date"]);
                        // get end date
                        DateTime End_Date = Convert.ToDateTime(dtFilter.Rows[0]["End_Date"]);

                        // get result records from database for the report
                        DataSet dsReport = Report.Get_Network_Call_Summary_Report(Start_Date, End_Date, Convert.ToString(dtFilter.Rows[0]["Region"]),strMarket);

                        //Create HTML for the report and wirte into HTML Write object
                        StringBuilder strHTML = new StringBuilder();
                        System.IO.StringWriter stringWrite = new System.IO.StringWriter();
                        System.Web.UI.HtmlTextWriter htmlWrite = new System.Web.UI.HtmlTextWriter(stringWrite);

                        #region "Header"

                        //Retrieve Market Values
                        string strMarketString = string.Empty;
                        if (string.IsNullOrEmpty(strMarket))
                        {
                            strMarketString = "All Market";
                        }
                        else
                        {
                            string[] strMar = strMarket.Split(Convert.ToChar(","));
                            for (int i = 0; i < strMar.Length; i++)
                            {
                                strMarketString += Report.SelectMarketInfoById(Convert.ToDecimal(strMar[i].ToString())).Tables[0].Rows[0]["Market"].ToString() + ",";
                            }
                            strMarketString = strMarketString.TrimEnd(',');
                        }

                        //Add Report Title and Schedule Date
                        strHTML.Append("<span style=\"font-family:Calibri;\">");
                        strHTML.Append("<br />");
                        strHTML.Append("<b>Report Title : FINPRO Network Call Summary Report</b>");
                        strHTML.Append("<br /><br />");
                        strHTML.Append("Schedule Date : " + Convert.ToDateTime(drReportSchedule["Scheduled_Date"]).ToString(DateDisplayFormat));
                        strHTML.Append("&nbsp;&nbsp;&nbsp;&nbsp;Schedule End Date : " + Convert.ToDateTime(drReportSchedule["Schedule_End_Date"]).ToString(DateDisplayFormat));
                        strHTML.Append("<br />");
                        strHTML.Append("Recurring Period : " + drReportSchedule["Recurring_Period"]).ToString();
                        strHTML.Append("<br />");
                        strHTML.Append("Recurring Date : " + dtSchduleDate.ToString(DateDisplayFormat));

                        //Add Report Filter Criteria 
                        strHTML.Append("<br /><br />");
                        strHTML.Append("<b>Report Filters </b>");                       
                        strHTML.Append("<br /><br />");
                        strHTML.Append("Date Claim Opened Between " + Start_Date.ToString(DateDisplayFormat) + " and " + End_Date.ToString(DateDisplayFormat));
                        strHTML.Append("<br />");
                        strHTML.Append("Regions              : " + (string.IsNullOrEmpty(Convert.ToString(dtFilter.Rows[0]["Region"])) ? "All" : dtFilter.Rows[0]["Region"].ToString()));
                        strHTML.Append("<br />");
                        strHTML.Append("Markets        : " + strMarketString);
                        strHTML.Append("<br /><br />");
                        strHTML.Append("</span>");

                        //Add Header HTML
                        strHTML.Append("<div style=\"overflow-x:scroll;overflow-y:hidden;width:1300px;\">");
                        strHTML.Append("<table cellpadding='4' cellspacing='0' style='font-weight: bold;font-family:Calibri;' width='1300px' border='1'><tr>");
                        strHTML.Append("<td style='width: 150px;' align='left'>Date Claim Opened</td>");
                        strHTML.Append("<td style='width: 250px;' align='left'>Type of Allegation</td>");
                        strHTML.Append("<td style='width: 250px;' align='left'>Complainant/Plaintiff</td>");
                        strHTML.Append("<td style='width: 230px;' align='left'>Store/Facility</td>");
                        strHTML.Append("<td style='width: 250px;' align='left'>Claim Description</td>");
                        strHTML.Append("<td style='width: 250px;' align='left'>Claim Status/Comments</td>");
                        strHTML.Append("<td style='width: 150px;' align='left'>HR Contact Name</td>");
                        strHTML.Append("</tr></table>");
                        #endregion

                        DataTable dtReportData = dsReport.Tables[0];
                        DataTable dtRegion = dsReport.Tables[1];
                        DataTable dtTotal = dsReport.Tables[2];
                        if (dtRegion.Rows.Count > 0)
                        {
                            //Add Report Data Table 
                            strHTML.Append("<table style='width: 1400px;' border='1' align='left' cellpadding='4' cellspacing='0'>");
                            foreach (DataRow drRegion in dtRegion.Rows)
                            {
                                strHTML.Append("<tr><td colspan='7' style='font-family:Calibri;'><b>");
                                strHTML.Append(drRegion["Region"].ToString());
                                strHTML.Append("</b></td></tr>");
                                strHTML.Append("<tr><td colspan='7'>");
                                strHTML.Append("<table style='width: 1400px;font-family:Calibri;' border='1' align='left' cellpadding='4' cellspacing='0'>");
                                DataRow[] drDataByRegion = dtReportData.Select("Region='" + drRegion["Region"].ToString() + "'");
                                foreach (DataRow drData in drDataByRegion)
                                {
                                    strHTML.Append("<tr style='background-color:#FFFFFF;'>");
                                    if (Convert.ToDateTime(drData["Claim_Open_Date"]) != Convert.ToDateTime(System.Data.SqlTypes.SqlDateTime.MinValue.ToString()))
                                    {
                                        strHTML.Append("<td style='width: 150px;' align='left'>" + Convert.ToDateTime(drData["Claim_Open_Date"]).ToString(DateDisplayFormat) + "</td>");
                                    }
                                    else
                                    {
                                        strHTML.Append("<td style='width: 150px;' align='left'>&nbsp;</td>");
                                    }
                                    strHTML.Append("<td style='width: 250px;' align='left'>" + drData["Type_of_Allegation"] + "</td>");
                                    strHTML.Append("<td style='width: 250px;' align='left'>" + drData["Complainant_Plaintiff"] + "</td>");
                                    strHTML.Append("<td style='width: 230px;' align='left'> " + drData["Location_Description"] + "</td>");
                                    strHTML.Append("<td style='width: 250px;' align='left'>" + drData["Claim_Description"] + "</td>");
                                    strHTML.Append("<td style='width: 250px;' align='left'>" + drData["Claim_Status_Comments"] + "</td>");
                                    strHTML.Append("<td style='width: 150px;' align='left'>" + drData["Contact_Name"] + "</td>");
                                    strHTML.Append("</tr>");
                                }
                                strHTML.Append("<tr style='background-color:#FFFFFF;'>");
                                strHTML.Append("<td style='width: 150px;' align='left'><b>Total</b></td>");
                                strHTML.Append("<td style='width: 250px;' align='left'><b>" + drRegion["Total"].ToString() + "</b></td>");
                                strHTML.Append("<td style='width: 250px;' align='left'>&nbsp;</td>");
                                strHTML.Append("<td style='width: 230px;' align='left'>&nbsp;</td>");
                                strHTML.Append("<td style='width: 250px;' align='left'>&nbsp;</td>");
                                strHTML.Append("<td style='width: 250px;' align='left'>&nbsp;</td>");
                                strHTML.Append("<td style='width: 150px;' align='left'>&nbsp;</td>");
                                strHTML.Append("</tr>");
                                strHTML.Append("</table>");
                                strHTML.Append("</td></tr>");
                            }
                            strHTML.Append("<tr style='background-color:#507cd1;font-family:Calibri;color:White;'>");
                            strHTML.Append("<td style='width: 150px;' align='left'><b>Grand Total</b></td>");
                            strHTML.Append("<td style='width: 250px;' align='left'><b>" + dtTotal.Rows[0]["Total"].ToString() + "</b></td>");
                            strHTML.Append("<td style='width: 250px;' align='left'>&nbsp;</td>");
                            strHTML.Append("<td style='width: 230px;' align='left'>&nbsp;</td>");
                            strHTML.Append("<td style='width: 250px;' align='left'>&nbsp;</td>");
                            strHTML.Append("<td style='width: 250px;' align='lef'>&nbsp;</td>");
                            strHTML.Append("<td style='width: 150px;' align='left'>&nbsp;</td>");
                            strHTML.Append("</tr>");
                            strHTML.Append("</table>");
                            strHTML.Append("</td></tr>");
                            strHTML.Append("</table>");
                        }
                        else
                        {
                            //Add No record found line for year
                            strHTML.Append("<tr><td align='left' colspan='7'>No Record Found!</td></tr>");
                        }

                        strHTML.Append("</div>");

                        //Write HTML in to HtmlWriter
                        htmlWrite.WriteLine(strHTML.ToString());

                        //Send Mail
                        SendMail("FINPRO Network Call Summary Report", "NetworkCallSummaryReport.xls", strFirstName, strLastName, strMailFrom, stringWrite, dtRecipients);


                    }
                }
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("ERROR in Network Call Summary Report, " + ex.Message);
            }
        }

        //Report 19
        private void BindWCAllocationDetailReport(DataRow drReportSchedule)
        {
            try
            {
                decimal pK_Schedule_ID = Convert.ToDecimal(drReportSchedule["PK_Schedule"]);
                decimal Fk_RecipientList = Convert.ToDecimal(drReportSchedule["Fk_RecipientList"]);
                decimal FK_Security_Id = Convert.ToDecimal(drReportSchedule["FK_Security_Id"]);

                //Get Report criteria for the scheduled report
                DataTable dtFilter = Report.SelectFilterCriteria(19, pK_Schedule_ID).Tables[0];
                if (dtFilter.Rows.Count > 0)
                {
                    //Get the recipient from the recipient list
                    DataTable dtRecipients = Report.SelectOneRecordWithRecipientList(Fk_RecipientList).Tables[0];

                    //Get the user who has scheduled the report
                    DataTable dtUser = Report.SelectSecurityByPK(FK_Security_Id).Tables[0];

                    String strFirstName, strLastName, strMailFrom;
                    strFirstName = strLastName = strMailFrom = "";
                    if (dtUser.Rows.Count > 0)
                    {
                        strFirstName = dtUser.Rows[0]["FIRST_NAME"].ToString();
                        strLastName = dtUser.Rows[0]["LAST_NAME"].ToString();
                        strMailFrom = dtUser.Rows[0]["Email"].ToString();

                        // get start date
                        Decimal Year = Convert.ToDecimal(dtFilter.Rows[0]["Year"]);
                        // get end date
                        Decimal Month = Convert.ToDecimal(dtFilter.Rows[0]["Month"]);
                        // get Region
                        string strRegion = dtFilter.Rows[0]["Region"].ToString();

                        // get result records from database for the report
                        DataSet dsReport = Report.GetWCAllocationDetailData(Convert.ToInt32(Year), Convert.ToInt32(Month), strRegion);

                        //Create HTML for the report and wirte into HTML Write object
                        StringBuilder strHTML = new StringBuilder();
                        System.IO.StringWriter stringWrite = new System.IO.StringWriter();
                        System.Web.UI.HtmlTextWriter htmlWrite = new System.Web.UI.HtmlTextWriter(stringWrite);

                        #region "Header"

                        //Add Report Title and Schedule Date
                        strHTML.Append("<span style=\"font-family:Calibri;\">");
                        strHTML.Append("<br />");
                        strHTML.Append("<b>Report Title : WC Allocation Detail Report</b>");
                        strHTML.Append("<br /><br />");
                        strHTML.Append("Schedule Date : " + Convert.ToDateTime(drReportSchedule["Scheduled_Date"]).ToString(DateDisplayFormat));
                        strHTML.Append("&nbsp;&nbsp;&nbsp;&nbsp;Schedule End Date : " + Convert.ToDateTime(drReportSchedule["Schedule_End_Date"]).ToString(DateDisplayFormat));
                        strHTML.Append("<br />");
                        strHTML.Append("Recurring Period : " + drReportSchedule["Recurring_Period"]).ToString();
                        strHTML.Append("<br />");
                        strHTML.Append("Recurring Date : " + dtSchduleDate.ToString(DateDisplayFormat));

                        //Add Report Filter Criteria 
                        strHTML.Append("<br /><br />");
                        strHTML.Append("<b>Report Filters </b>");
                        strHTML.Append("<br /><br />");
                        strHTML.Append("Year        : " + Year);
                        strHTML.Append("<br />");
                        strHTML.Append("Month          : " + GetMonthString(Convert.ToInt32(Month)));
                        strHTML.Append("<br />");
                        strHTML.Append("Regions              : " + strRegion.TrimStart(Convert.ToChar(",")).Replace("'", ""));
                        strHTML.Append("<br /><br />");
                        strHTML.Append("</span>");

                        //Add Header HTML
                        strHTML.Append("<table cellpadding='4' cellspacing='0' style='font-weight: bold;font-family:Calibri;' width='100%' border='1'>");
                        strHTML.Append("<tr>");
                        strHTML.Append("<td colspan='11' align='center'>Sonic Automotive WC Loss Allocation Report (First Report Only)</td>");
                        strHTML.Append("</tr>");
                        strHTML.Append("<tr>");
                        strHTML.Append("<td style='width: 13%;' align='left' valign='top'>Location</td>");
                        strHTML.Append("<td style='width: 8%;' align='left' valign='top'>First Report<br/>Number</td>");
                        strHTML.Append("<td style='width: 10%;' align='left' valign='top'>Employee</td>");
                        strHTML.Append("<td style='width: 13%;' align='left' valign='top'>Cause of Incident</td>");
                        strHTML.Append("<td style='width: 8%;' align='left' valign='top'>Date of Incident</td>");
                        strHTML.Append("<td style='width: 8%;' align='left' valign='top'>Date Reported to Sonic</td>");
                        strHTML.Append("<td style='width: 8%;' align='right' valign='top'>Report Lag</td>");
                        strHTML.Append("<td style='width: 8%;' align='right' valign='top'>Claim Charge</td>");
                        strHTML.Append("<td style='width: 8%;' align='right' valign='top'>Penalty Charge</td>");
                        strHTML.Append("<td style='width: 8%;' align='right' valign='top'>Performance Credit</td>");
                        strHTML.Append("<td style='width: 8%;' align='right' valign='top'>Total Charge</td>");
                        strHTML.Append("</tr></table>");
                        #endregion

                        DataTable dtReportData = dsReport.Tables[0];
                        DataTable dtRegion = dsReport.Tables[1];
                        DataTable dtTotal = dsReport.Tables[2];
                        if (dtRegion.Rows.Count > 0)
                        {
                            //Add Report Data Table 
                            strHTML.Append("<table style='width: 100%;' border='1' align='left' cellpadding='4' cellspacing='0'>");
                            foreach (DataRow drRegion in dtRegion.Rows)
                            {
                                strHTML.Append("<tr><td colspan='11' style='font-family:Calibri;'><b>Region : ");
                                strHTML.Append(drRegion["Region"].ToString());
                                strHTML.Append("</b></td></tr>");
                                strHTML.Append("<tr><td colspan='11'>");
                                strHTML.Append("<table style='width: 100%;font-family:Calibri;' border='1' align='left' cellpadding='4' cellspacing='0'>");
                                DataRow[] drDataByRegion = dtReportData.Select("Region='" + drRegion["Region"].ToString() + "'");
                                foreach (DataRow drData in drDataByRegion)
                                {
                                    strHTML.Append("<tr style='background-color:#FFFFFF;'>");
                                    strHTML.Append("<td style='width: 13%;' align='left' valign='top'>" + drData["dba"] + "</td>");
                                    strHTML.Append("<td style='width: 8%;' align='left' valign='top'>WC-" + drData["WC_FR_Number"] + "</td>");
                                    strHTML.Append("<td style='width: 10%;' align='left' valign='top'>" + drData["Employee_Name"] + "</td>");
                                    strHTML.Append("<td style='width: 13%;' align='left' valign='top'>" + drData["Sonic_Cause_Code"] + "</td>");
                                    if (Convert.ToDateTime(drData["Date_Of_Incident"]) != Convert.ToDateTime(System.Data.SqlTypes.SqlDateTime.MinValue.ToString()))
                                    {
                                        strHTML.Append("<td style='width: 8%;' align='left' valign='top'>" + Convert.ToDateTime(drData["Date_Of_Incident"]).ToString(DateDisplayFormat) + "</td>");
                                    }
                                    else
                                    {
                                        strHTML.Append("<td style='width: 8%;' align='left' valign='top'>&nbsp;</td>");
                                    }

                                    if (Convert.ToDateTime(drData["Date_Reported_To_Sonic"]) != Convert.ToDateTime(System.Data.SqlTypes.SqlDateTime.MinValue.ToString()))
                                    {
                                        strHTML.Append("<td style='width: 8%;' align='left' valign='top'>" + Convert.ToDateTime(drData["Date_Reported_To_Sonic"]).ToString(DateDisplayFormat) + "</td>");
                                    }
                                    else
                                    {
                                        strHTML.Append("<td style='width: 8%;' align='left' valign='top'>&nbsp;</td>");
                                    }
                                    strHTML.Append("<td style='width: 8%;' align='right' valign='top'>" + string.Format("{0:N0}", drData["Report_Lag"]) + "</td>");
                                    strHTML.Append("<td style='width: 8%;' align='right' valign='top'>$ " + string.Format("{0:N2}", drData["claimCharge"]) + "</td>");
                                    strHTML.Append("<td style='width: 8%;' align='right' valign='top'>$ " + string.Format("{0:N2}", drData["PenaltyCharge"]) + "</td>");
                                    strHTML.Append("<td style='width: 8%;' align='right' valign='top'>$ " + string.Format("{0:N2}", drData["PerformanceCredit"]) + "</td>");
                                    strHTML.Append("<td style='width: 8%;' align='right' valign='top'>$ " + string.Format("{0:N2}", drData["TotalCharge"]) + "</td>");
                                    strHTML.Append("</tr>");
                                }
                                strHTML.Append("<tr style='background-color:#FFFFFF;'>");
                                strHTML.Append("<td style='width: 13%;' align='left' valign='top'><b>Total</b></td>");
                                strHTML.Append("<td style='width: 8%;' align='left' valign='top'>&nbsp;</td>");
                                strHTML.Append("<td style='width: 10%;' align='left' valign='top'>&nbsp;</td>");
                                strHTML.Append("<td style='width: 13%;' align='left' valign='top'>&nbsp;</td>");
                                strHTML.Append("<td style='width: 8%;' align='left' valign='top'>&nbsp;</td>");
                                strHTML.Append("<td style='width: 8%;' align='left' valign='top'>&nbsp;</td>");
                                strHTML.Append("<td style='width: 8%;' align='right' valign='top'><b>" + string.Format("{0:N0}", drRegion["Report_Lag"]) + "</b></td>");
                                strHTML.Append("<td style='width: 8%;' align='right' valign='top'><b>$ " + string.Format("{0:N2}", drRegion["claimCharge"]) + "</b></td>");
                                strHTML.Append("<td style='width: 8%;' align='right' valign='top'><b>$ " + string.Format("{0:N2}", drRegion["PenaltyCharge"]) + "</b></td>");
                                strHTML.Append("<td style='width: 8%;' align='right' valign='top'><b>$ " + string.Format("{0:N2}", drRegion["PerformanceCredit"]) + "</b></td>");
                                strHTML.Append("<td style='width: 8%;' align='right' valign='top'><b>$ " + string.Format("{0:N2}", drRegion["TotalCharge"]) + "</b></td>");
                                strHTML.Append("</tr>");
                                strHTML.Append("</table>");
                                strHTML.Append("</td></tr>");
                            }
                            strHTML.Append("<tr style='background-color:#507cd1;font-family:Calibri;color:White;'>");
                            strHTML.Append("<td style='width: 13%;' align='left' valign='top'><b>Grand Total</b></td>");
                            strHTML.Append("<td style='width: 8%;' align='left' valign='top'>&nbsp;</td>");
                            strHTML.Append("<td style='width: 10%;' align='left' valign='top'>&nbsp;</td>");
                            strHTML.Append("<td style='width: 13%;' align='left' valign='top'>&nbsp;</td>");
                            strHTML.Append("<td style='width: 8%;' align='left' valign='top'>&nbsp;</td>");
                            strHTML.Append("<td style='width: 8%;' align='left' valign='top'>&nbsp;</td>");
                            strHTML.Append("<td style='width: 8%;' align='right' valign='top'><b>" + string.Format("{0:N0}", dtTotal.Rows[0]["Report_Lag"]) + "</b></td>");
                            strHTML.Append("<td style='width: 8%;' align='right' valign='top'><b>$ " + string.Format("{0:N2}", dtTotal.Rows[0]["claimCharge"]) + "</b></td>");
                            strHTML.Append("<td style='width: 8%;' align='right' valign='top'><b>$ " + string.Format("{0:N2}", dtTotal.Rows[0]["PenaltyCharge"]) + "</b></td>");
                            strHTML.Append("<td style='width: 8%;' align='right' valign='top'><b>$ " + string.Format("{0:N2}", dtTotal.Rows[0]["PerformanceCredit"]) + "</b></td>");
                            strHTML.Append("<td style='width: 8%;' align='right' valign='top'><b>$ " + string.Format("{0:N2}", dtTotal.Rows[0]["TotalCharge"]) + "</b></td>");
                            strHTML.Append("</tr>");
                            strHTML.Append("</table>");
                            strHTML.Append("</td></tr>");
                            strHTML.Append("</table>");
                        }
                        else
                        {
                            //Add No record found line for year
                            strHTML.Append("<tr><td align='left' colspan='16'>No Record Found!</td></tr>");
                        }


                        //Write HTML in to HtmlWriter
                        htmlWrite.WriteLine(strHTML.ToString());

                        //Send Mail
                        SendMail("WC Allocation Detail Report", "WCAllocationDetailReport.xls", strFirstName, strLastName, strMailFrom, stringWrite, dtRecipients);


                    }
                }
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("ERROR in WC Allocation Detail Report, " + ex.Message);
            }
        }

        //Report 20
        private void BindWCAllocationSummaryReport(DataRow drReportSchedule)
        {
            try
            {
                decimal pK_Schedule_ID = Convert.ToDecimal(drReportSchedule["PK_Schedule"]);
                decimal Fk_RecipientList = Convert.ToDecimal(drReportSchedule["Fk_RecipientList"]);
                decimal FK_Security_Id = Convert.ToDecimal(drReportSchedule["FK_Security_Id"]);

                //Get Report criteria for the scheduled report
                DataTable dtFilter = Report.SelectFilterCriteria(20, pK_Schedule_ID).Tables[0];
                if (dtFilter.Rows.Count > 0)
                {
                    //Get the recipient from the recipient list
                    DataTable dtRecipients = Report.SelectOneRecordWithRecipientList(Fk_RecipientList).Tables[0];

                    //Get the user who has scheduled the report
                    DataTable dtUser = Report.SelectSecurityByPK(FK_Security_Id).Tables[0];

                    String strFirstName, strLastName, strMailFrom;
                    strFirstName = strLastName = strMailFrom = "";
                    if (dtUser.Rows.Count > 0)
                    {
                        strFirstName = dtUser.Rows[0]["FIRST_NAME"].ToString();
                        strLastName = dtUser.Rows[0]["LAST_NAME"].ToString();
                        strMailFrom = dtUser.Rows[0]["Email"].ToString();

                        // get start date
                        Decimal Year = Convert.ToDecimal(dtFilter.Rows[0]["Year"]);

                        // get result records from database for the report
                        DataSet dsReport = Report.GetWC_Allocation_Location_Summary_Report(Year);

                        //Create HTML for the report and wirte into HTML Write object
                        StringBuilder strHTML = new StringBuilder();
                        System.IO.StringWriter stringWrite = new System.IO.StringWriter();
                        System.Web.UI.HtmlTextWriter htmlWrite = new System.Web.UI.HtmlTextWriter(stringWrite);

                        #region "Header"

                        //Add Report Title and Schedule Date
                        strHTML.Append("<span style=\"font-family:Calibri;\">");
                        strHTML.Append("<br />");
                        strHTML.Append("<b>Report Title : WC Allocation Summary Report</b>");
                        strHTML.Append("<br /><br />");
                        strHTML.Append("Schedule Date : " + Convert.ToDateTime(drReportSchedule["Scheduled_Date"]).ToString(DateDisplayFormat));
                        strHTML.Append("&nbsp;&nbsp;&nbsp;&nbsp;Schedule End Date : " + Convert.ToDateTime(drReportSchedule["Schedule_End_Date"]).ToString(DateDisplayFormat));
                        strHTML.Append("<br />");
                        strHTML.Append("Recurring Period : " + drReportSchedule["Recurring_Period"]).ToString();
                        strHTML.Append("<br />");
                        strHTML.Append("Recurring Date : " + dtSchduleDate.ToString(DateDisplayFormat));

                        //Add Report Filter Criteria 
                        strHTML.Append("<br /><br />");
                        strHTML.Append("<b>Report Filters </b>");
                        strHTML.Append("<br /><br />");
                        strHTML.Append("Year        : " + Year);
                        strHTML.Append("<br /><br />");
                        strHTML.Append("</span>");

                        //Add Header HTML
                        strHTML.Append("<table cellpadding='4' cellspacing='0' style='font-weight: bold;font-family:Calibri;' width='100%' border='1'>");
                        strHTML.Append("<tr>");
                        strHTML.Append("<td style='width: 6%;' align='left' valign='top'>Dealership</td>");
                        strHTML.Append("<td style='width: 3%;' align='left' valign='top'>Location<br/>Code</td>");
                        strHTML.Append("<td style='width: 7%;' align='right' valign='top'>JAN'" + Year.ToString().Substring(2, 2) + "</td>");
                        strHTML.Append("<td style='width: 7%;' align='right' valign='top'>FEB'" + Year.ToString().Substring(2, 2) + "</td>");
                        strHTML.Append("<td style='width: 7%;' align='right' valign='top'>MAR'" + Year.ToString().Substring(2, 2) + "</td>");
                        strHTML.Append("<td style='width: 7;' align='right' valign='top'>APR'" + Year.ToString().Substring(2, 2) + "</td>");
                        strHTML.Append("<td style='width: 7%;' align='right' valign='top'>MAY'" + Year.ToString().Substring(2, 2) + "</td>");
                        strHTML.Append("<td style='width: 7%;' align='right' valign='top'>JUN'" + Year.ToString().Substring(2, 2) + "</td>");
                        strHTML.Append("<td style='width: 7%;' align='right' valign='top'>JUL'" + Year.ToString().Substring(2, 2) + "</td>");
                        strHTML.Append("<td style='width: 7%;' align='right' valign='top'>AUG'" + Year.ToString().Substring(2, 2) + "</td>");
                        strHTML.Append("<td style='width: 7%;' align='right' valign='top'>SEP'" + Year.ToString().Substring(2, 2) + "</td>");
                        strHTML.Append("<td style='width: 7%;' align='right' valign='top'>OCT'" + Year.ToString().Substring(2, 2) + "</td>");
                        strHTML.Append("<td style='width: 7%;' align='right' valign='top'>NOV'" + Year.ToString().Substring(2, 2) + "</td>");
                        strHTML.Append("<td style='width: 7%;' align='right' valign='top'>DEC'" + Year.ToString().Substring(2, 2) + "</td>");
                        strHTML.Append("<td style='width: 7%;' align='right' valign='top'>Total Count'" + Year.ToString().Substring(2, 2) + "</td>");
                        strHTML.Append("</tr></table>");
                        #endregion

                        DataTable dtReportData = dsReport.Tables[0];
                        DataTable dtTotal = dsReport.Tables[1];
                        if (dtReportData.Rows.Count > 0)
                        {
                            //Add Report Data Table 
                            strHTML.Append("<table style='width: 100%;' border='1' align='left' cellpadding='4' cellspacing='0'>");
                            //foreach (DataRow drRegion in dtRegion.Rows)
                            //{
                            strHTML.Append("<tr><td colspan='15'>");
                            strHTML.Append("<table style='width: 100%;font-family:Calibri;' border='1' align='left' cellpadding='4' cellspacing='0'>");
                            foreach (DataRow drData in dtReportData.Rows)
                            {
                                strHTML.Append("<tr style='background-color:#FFFFFF;'>");
                                strHTML.Append("<td style='width: 6%;' align='left' valign='top'>" + drData["dba"] + "</td>");
                                strHTML.Append("<td style='width: 3%;' align='left' valign='top'>" + drData["sonic_location_code"] + "</td>");
                                strHTML.Append("<td style='width: 7%;' align='left' valign='top'>$ " + string.Format("{0:N2}", drData["JAN"]) + "</td>");
                                strHTML.Append("<td style='width: 7%;' align='left' valign='top'>$ " + string.Format("{0:N2}", drData["FEB"]) + "</td>");
                                strHTML.Append("<td style='width: 7%;' align='right' valign='top'>$ " + string.Format("{0:N2}", drData["MAR"]) + "</td>");
                                strHTML.Append("<td style='width: 7%;' align='right' valign='top'>$ " + string.Format("{0:N2}", drData["APR"]) + "</td>");
                                strHTML.Append("<td style='width: 7%;' align='right' valign='top'>$ " + string.Format("{0:N2}", drData["MAY"]) + "</td>");
                                strHTML.Append("<td style='width: 7%;' align='right' valign='top'>$ " + string.Format("{0:N2}", drData["JUN"]) + "</td>");
                                strHTML.Append("<td style='width: 7%;' align='right' valign='top'>$ " + string.Format("{0:N2}", drData["JUL"]) + "</td>");
                                strHTML.Append("<td style='width: 7%;' align='right' valign='top'>$ " + string.Format("{0:N2}", drData["AUG"]) + "</td>");
                                strHTML.Append("<td style='width: 7%;' align='right' valign='top'>$ " + string.Format("{0:N2}", drData["SEP"]) + "</td>");
                                strHTML.Append("<td style='width: 7%;' align='right' valign='top'>$ " + string.Format("{0:N2}", drData["OCT"]) + "</td>");
                                strHTML.Append("<td style='width: 7%;' align='right' valign='top'>$ " + string.Format("{0:N2}", drData["NOV"]) + "</td>");
                                strHTML.Append("<td style='width: 7%;' align='right' valign='top'>$ " + string.Format("{0:N2}", drData["DEC"]) + "</td>");
                                strHTML.Append("<td style='width: 7%;' align='right' valign='top'>$ " + string.Format("{0:N2}", drData["Total_Count"]) + "</td>");
                                strHTML.Append("</tr>");
                            }
                            strHTML.Append("<tr style='background-color:#507cd1;font-weight:bold;font-family:Calibri;color:White;'>");
                            strHTML.Append("<td style='width: 6%;' align='left' valign='top'>Total</td>");
                            strHTML.Append("<td style='width: 3%;' align='left' valign='top'>&nbsp;</td>");
                            strHTML.Append("<td style='width: 7%;' align='left' valign='top'>$ " + string.Format("{0:N2}", dtTotal.Rows[0]["JAN"]) + "</td>");
                            strHTML.Append("<td style='width: 7%;' align='left' valign='top'>$ " + string.Format("{0:N2}", dtTotal.Rows[0]["FEB"]) + "</td>");
                            strHTML.Append("<td style='width: 7%;' align='right' valign='top'>$ " + string.Format("{0:N2}", dtTotal.Rows[0]["MAR"]) + "</td>");
                            strHTML.Append("<td style='width: 7%;' align='right' valign='top'>$ " + string.Format("{0:N2}", dtTotal.Rows[0]["APR"]) + "</td>");
                            strHTML.Append("<td style='width: 7%;' align='right' valign='top'>$ " + string.Format("{0:N2}", dtTotal.Rows[0]["MAY"]) + "</td>");
                            strHTML.Append("<td style='width: 7%;' align='right' valign='top'>$ " + string.Format("{0:N2}", dtTotal.Rows[0]["JUN"]) + "</td>");
                            strHTML.Append("<td style='width: 7%;' align='right' valign='top'>$ " + string.Format("{0:N2}", dtTotal.Rows[0]["JUL"]) + "</td>");
                            strHTML.Append("<td style='width: 7%;' align='right' valign='top'>$ " + string.Format("{0:N2}", dtTotal.Rows[0]["AUG"]) + "</td>");
                            strHTML.Append("<td style='width: 7%;' align='right' valign='top'>$ " + string.Format("{0:N2}", dtTotal.Rows[0]["SEP"]) + "</td>");
                            strHTML.Append("<td style='width: 7%;' align='right' valign='top'>$ " + string.Format("{0:N2}", dtTotal.Rows[0]["OCT"]) + "</td>");
                            strHTML.Append("<td style='width: 7%;' align='right' valign='top'>$ " + string.Format("{0:N2}", dtTotal.Rows[0]["NOV"]) + "</td>");
                            strHTML.Append("<td style='width: 7%;' align='right' valign='top'>$ " + string.Format("{0:N2}", dtTotal.Rows[0]["DEC"]) + "</td>");
                            strHTML.Append("<td style='width: 7%;' align='right' valign='top'>$ " + string.Format("{0:N2}", dtTotal.Rows[0]["Total_Count"]) + "</td>");
                            strHTML.Append("</tr>");
                            strHTML.Append("</table>");
                            strHTML.Append("</td></tr>");
                            //}
                            strHTML.Append("</table>");
                            strHTML.Append("</td></tr>");
                            strHTML.Append("</table>");
                        }
                        else
                        {
                            //Add No record found line for year
                            strHTML.Append("<tr><td align='left' colspan='16'>No Record Found!</td></tr>");
                        }


                        //Write HTML in to HtmlWriter
                        htmlWrite.WriteLine(strHTML.ToString());

                        //Send Mail
                        SendMail("WC Allocation Summary Report", "WCAllocationSummaryReport.xls", strFirstName, strLastName, strMailFrom, stringWrite, dtRecipients);


                    }
                }
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("ERROR in WC Allocation Detail Report, " + ex.Message);
            }
        }

        //Report 21
        private void BindWCAllocationLocationReport(DataRow drReportSchedule)
        {
            try
            {
                decimal pK_Schedule_ID = Convert.ToDecimal(drReportSchedule["PK_Schedule"]);
                decimal Fk_RecipientList = Convert.ToDecimal(drReportSchedule["Fk_RecipientList"]);
                decimal FK_Security_Id = Convert.ToDecimal(drReportSchedule["FK_Security_Id"]);

                //Get Report criteria for the scheduled report
                DataTable dtFilter = Report.SelectFilterCriteria(21, pK_Schedule_ID).Tables[0];
                if (dtFilter.Rows.Count > 0)
                {
                    //Get the recipient from the recipient list
                    DataTable dtRecipients = Report.SelectOneRecordWithRecipientList(Fk_RecipientList).Tables[0];

                    //Get the user who has scheduled the report
                    DataTable dtUser = Report.SelectSecurityByPK(FK_Security_Id).Tables[0];

                    String strFirstName, strLastName, strMailFrom;
                    strFirstName = strLastName = strMailFrom = "";
                    if (dtUser.Rows.Count > 0)
                    {
                        strFirstName = dtUser.Rows[0]["FIRST_NAME"].ToString();
                        strLastName = dtUser.Rows[0]["LAST_NAME"].ToString();
                        strMailFrom = dtUser.Rows[0]["Email"].ToString();

                        // get start date
                        Decimal Year = Convert.ToDecimal(dtFilter.Rows[0]["Year"]);
                        // get end date
                        Decimal Month = Convert.ToDecimal(dtFilter.Rows[0]["Month"]);
                        // get Region
                        Decimal Location = Convert.ToDecimal(dtFilter.Rows[0]["Location"]);
                        // get result records from database for the report
                        DataSet dsReport = Report.GetWC_Allocation_Location_Report(Year, Month, Location);

                        //Create HTML for the report and wirte into HTML Write object
                        StringBuilder strHTML = new StringBuilder();
                        System.IO.StringWriter stringWrite = new System.IO.StringWriter();
                        System.Web.UI.HtmlTextWriter htmlWrite = new System.Web.UI.HtmlTextWriter(stringWrite);

                        #region "Header"

                        //Add Report Title and Schedule Date
                        strHTML.Append("<span style=\"font-family:Calibri;\">");
                        strHTML.Append("<br />");
                        strHTML.Append("<b>Report Title : WC Allocation Location Report</b>");
                        strHTML.Append("<br /><br />");
                        strHTML.Append("Schedule Date : " + Convert.ToDateTime(drReportSchedule["Scheduled_Date"]).ToString(DateDisplayFormat));
                        strHTML.Append("&nbsp;&nbsp;&nbsp;&nbsp;Schedule End Date : " + Convert.ToDateTime(drReportSchedule["Schedule_End_Date"]).ToString(DateDisplayFormat));
                        strHTML.Append("<br />");
                        strHTML.Append("Recurring Period : " + drReportSchedule["Recurring_Period"]).ToString();
                        strHTML.Append("<br />");
                        strHTML.Append("Recurring Date : " + dtSchduleDate.ToString(DateDisplayFormat));

                        DataTable dtLocationInfo = Report.SelectLocationInfoById(Location).Tables[0];
                        //Add Report Filter Criteria 
                        strHTML.Append("<br /><br />");
                        strHTML.Append("<b>Report Filters </b>");
                        strHTML.Append("<br /><br />");
                        strHTML.Append("Year        : " + Year);
                        strHTML.Append("<br />");
                        strHTML.Append("Month          : " + GetMonthString(Convert.ToInt32(Month)));
                        strHTML.Append("<br />");
                        strHTML.Append("Location              : " + dtLocationInfo.Rows[0]["dba"].ToString());
                        strHTML.Append("<br /><br />");
                        strHTML.Append("</span>");

                        //Add Header HTML
                        strHTML.Append("<table cellpadding='4' cellspacing='0' style='font-weight: bold;font-family:Calibri;' width='100%' border='1'>");
                        strHTML.Append("<tr>");
                        strHTML.Append("<td style='width: 7%;' align='left' valign='top'>Claim Number</td>");
                        strHTML.Append("<td style='width: 4%;' align='left' valign='top'>Employee</td>");
                        strHTML.Append("<td style='width: 9%;' align='left' valign='top'>Cause of Incident</td>");
                        strHTML.Append("<td style='width: 8%;' align='left' valign='top'>Date of Loss</td>");
                        strHTML.Append("<td style='width: 8%;' align='left' valign='top'>Date Reported</td>");
                        strHTML.Append("<td style='width: 8%;' align='right' valign='top'>Report Lag</td>");
                        strHTML.Append("<td style='width: 8%;' align='left' valign='top'>Date Claim Opened</td>");
                        strHTML.Append("<td style='width: 8%;' align='left' valign='top'>Date Claim Closed</td>");
                        strHTML.Append("<td style='width: 8%;' align='left' valign='top'>Date Claim Reopened</td>");
                        strHTML.Append("<td style='width: 8%;' align='right' valign='top'>Claim Charge</td>");
                        strHTML.Append("<td style='width: 8%;' align='right' valign='top'>Penalty Charge</td>");
                        strHTML.Append("<td style='width: 8%;' align='right' valign='top'>Performance Credit</td>");
                        strHTML.Append("<td style='width: 8%;' align='right' valign='top'>Total Charge</td>");
                        strHTML.Append("</tr></table>");
                        #endregion

                        DataTable dtReportData = dsReport.Tables[0];
                        //DataTable dtTotal = dsReport.Tables[1];
                        if (dtReportData.Rows.Count > 0)
                        {
                            //Add Report Data Table 
                            strHTML.Append("<table style='width: 100%;' border='1' align='left' cellpadding='4' cellspacing='0'>");
                            //foreach (DataRow drRegion in dtRegion.Rows)
                            //{
                            strHTML.Append("<tr><td colspan='13'>");
                            strHTML.Append("<table style='width: 100%;font-family:Calibri;' border='1' align='left' cellpadding='4' cellspacing='0'>");
                            foreach (DataRow drData in dtReportData.Rows)
                            {
                                strHTML.Append("<tr style='background-color:#FFFFFF;'>");
                                strHTML.Append("<td style='width: 7%;' align='left' valign='top'>" + drData["Claim_Number"] + "</td>");
                                strHTML.Append("<td style='width: 4%;' align='left' valign='top'>" + drData["Employee_Name"] + "</td>");
                                strHTML.Append("<td style='width: 9%;' align='left' valign='top'>" + drData["Cause_Injury_Body_Part_Description"] + "</td>");
                                if (Convert.ToDateTime(drData["Date_of_Accident"]) != Convert.ToDateTime(System.Data.SqlTypes.SqlDateTime.MinValue.ToString()))
                                {
                                    strHTML.Append("<td style='width: 8%;' align='left' valign='top'>" + Convert.ToDateTime(drData["Date_of_Accident"]).ToString(DateDisplayFormat) + "</td>");
                                }
                                else
                                {
                                    strHTML.Append("<td style='width: 8%;' align='left' valign='top'>&nbsp;</td>");
                                }

                                if (Convert.ToDateTime(drData["Date_Reported_to_Insurer"]) != Convert.ToDateTime(System.Data.SqlTypes.SqlDateTime.MinValue.ToString()))
                                {
                                    strHTML.Append("<td style='width: 8%;' align='left' valign='top'>" + Convert.ToDateTime(drData["Date_Reported_to_Insurer"]).ToString(DateDisplayFormat) + "</td>");
                                }
                                else
                                {
                                    strHTML.Append("<td style='width: 8%;' align='left' valign='top'>&nbsp;</td>");
                                }
                                strHTML.Append("<td style='width: 8%;' align='right' valign='top'>" + string.Format("{0:N0}", drData["Report_Lag"]) + "</td>");
                                if (Convert.ToDateTime(drData["Date_Entered"]) != Convert.ToDateTime(System.Data.SqlTypes.SqlDateTime.MinValue.ToString()))
                                {
                                    strHTML.Append("<td style='width: 8%;' align='left' valign='top'>" + Convert.ToDateTime(drData["Date_Entered"]).ToString(DateDisplayFormat) + "</td>");
                                }
                                else
                                {
                                    strHTML.Append("<td style='width: 8%;' align='left' valign='top'>&nbsp;</td>");
                                }

                                if (Convert.ToDateTime(drData["Date_Closed"]) != Convert.ToDateTime(System.Data.SqlTypes.SqlDateTime.MinValue.ToString()))
                                {
                                    strHTML.Append("<td style='width: 8%;' align='left' valign='top'>" + Convert.ToDateTime(drData["Date_Closed"]).ToString(DateDisplayFormat) + "</td>");
                                }
                                else
                                {
                                    strHTML.Append("<td style='width: 8%;' align='left' valign='top'>&nbsp;</td>");
                                }

                                if (drData["Date_claim_Reopened"] != DBNull.Value)
                                {
                                    if (Convert.ToDateTime(drData["Date_claim_Reopened"]) != Convert.ToDateTime(System.Data.SqlTypes.SqlDateTime.MinValue.ToString()))
                                        strHTML.Append("<td style='width: 8%;' align='left' valign='top'>" + Convert.ToDateTime(drData["Date_claim_Reopened"]).ToString(DateDisplayFormat) + "</td>");
                                    else
                                        strHTML.Append("<td style='width: 8%;' align='left' valign='top'>&nbsp;</td>");
                                }
                                else
                                {
                                    strHTML.Append("<td style='width: 8%;' align='left' valign='top'>&nbsp;</td>");
                                }
                                strHTML.Append("<td style='width: 8%;' align='right' valign='top'>$ " + string.Format("{0:N2}", drData["Charge"]) + "</td>");
                                strHTML.Append("<td style='width: 8%;' align='right' valign='top'>$ " + string.Format("{0:N2}", drData["Late_Penalty_Charge"]) + "</td>");
                                strHTML.Append("<td style='width: 8%;' align='right' valign='top'>$ " + string.Format("{0:N2}", drData["Early_Reporting_Performance_Credit"]) + "</td>");
                                strHTML.Append("<td style='width: 8%;' align='right' valign='top'>$ " + string.Format("{0:N2}", drData["Total_Charge"]) + "</td>");
                                strHTML.Append("</tr>");
                            }
                            //strHTML.Append("<tr style='background-color:#FFFFFF;font-weight:bold;'>");
                            //strHTML.Append("<td style='width: 6%;' align='left' valign='top'>Total</td>");
                            //strHTML.Append("<td style='width: 3%;' align='left' valign='top'>&nbsp;</td>");
                            //strHTML.Append("<td style='width: 7%;' align='left' valign='top'>$ " + string.Format("{0:N2}", dtTotal.Rows[0]["JAN"]) + "</td>");
                            //strHTML.Append("<td style='width: 7%;' align='left' valign='top'>$ " + string.Format("{0:N2}", dtTotal.Rows[0]["FEB"]) + "</td>");
                            //strHTML.Append("<td style='width: 7%;' align='right' valign='top'>$ " + string.Format("{0:N2}", dtTotal.Rows[0]["MAR"]) + "</td>");
                            //strHTML.Append("<td style='width: 7%;' align='right' valign='top'>$ " + string.Format("{0:N2}", dtTotal.Rows[0]["APR"]) + "</td>");
                            //strHTML.Append("<td style='width: 7%;' align='right' valign='top'>$ " + string.Format("{0:N2}", dtTotal.Rows[0]["MAY"]) + "</td>");
                            //strHTML.Append("<td style='width: 7%;' align='right' valign='top'>$ " + string.Format("{0:N2}", dtTotal.Rows[0]["JUN"]) + "</td>");
                            //strHTML.Append("<td style='width: 7%;' align='right' valign='top'>$ " + string.Format("{0:N2}", dtTotal.Rows[0]["JUL"]) + "</td>");
                            //strHTML.Append("<td style='width: 7%;' align='right' valign='top'>$ " + string.Format("{0:N2}", dtTotal.Rows[0]["AUG"]) + "</td>");
                            //strHTML.Append("<td style='width: 7%;' align='right' valign='top'>$ " + string.Format("{0:N2}", dtTotal.Rows[0]["SEP"]) + "</td>");
                            //strHTML.Append("<td style='width: 7%;' align='right' valign='top'>$ " + string.Format("{0:N2}", dtTotal.Rows[0]["OCT"]) + "</td>");
                            //strHTML.Append("<td style='width: 7%;' align='right' valign='top'>$ " + string.Format("{0:N2}", dtTotal.Rows[0]["NOV"]) + "</td>");
                            //strHTML.Append("<td style='width: 7%;' align='right' valign='top'>$ " + string.Format("{0:N2}", dtTotal.Rows[0]["DEC"]) + "</td>");
                            //strHTML.Append("<td style='width: 7%;' align='right' valign='top'>$ " + string.Format("{0:N2}", dtTotal.Rows[0]["Total_Count"]) + "</td>");
                            //strHTML.Append("</tr>");
                            strHTML.Append("</table>");
                            strHTML.Append("</td></tr>");
                            //}
                            strHTML.Append("</table>");
                            strHTML.Append("</td></tr>");
                            strHTML.Append("</table>");
                        }
                        else
                        {
                            //Add No record found line for year
                            strHTML.Append("<tr><td align='left' colspan='13'>No Record Found!</td></tr>");
                        }


                        //Write HTML in to HtmlWriter
                        htmlWrite.WriteLine(strHTML.ToString());

                        //Send Mail
                        SendMail("WC Allocation Location Report", "WCAllocationLocationReport.xls", strFirstName, strLastName, strMailFrom, stringWrite, dtRecipients);


                    }
                }
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("ERROR in WC Allocation Location Report, " + ex.Message);
            }
        }

        //Report 22
        private void BindWCAllocationMonthlyDetailReport(DataRow drReportSchedule)
        {
            try
            {
                decimal pK_Schedule_ID = Convert.ToDecimal(drReportSchedule["PK_Schedule"]);
                decimal Fk_RecipientList = Convert.ToDecimal(drReportSchedule["Fk_RecipientList"]);
                decimal FK_Security_Id = Convert.ToDecimal(drReportSchedule["FK_Security_Id"]);

                //Get Report criteria for the scheduled report
                DataTable dtFilter = Report.SelectFilterCriteria(22, pK_Schedule_ID).Tables[0];
                if (dtFilter.Rows.Count > 0)
                {
                    //Get the recipient from the recipient list
                    DataTable dtRecipients = Report.SelectOneRecordWithRecipientList(Fk_RecipientList).Tables[0];

                    //Get the user who has scheduled the report
                    DataTable dtUser = Report.SelectSecurityByPK(FK_Security_Id).Tables[0];

                    String strFirstName, strLastName, strMailFrom;
                    strFirstName = strLastName = strMailFrom = "";
                    if (dtUser.Rows.Count > 0)
                    {
                        strFirstName = dtUser.Rows[0]["FIRST_NAME"].ToString();
                        strLastName = dtUser.Rows[0]["LAST_NAME"].ToString();
                        strMailFrom = dtUser.Rows[0]["Email"].ToString();

                        // get start date
                        int Year = Convert.ToInt32(dtFilter.Rows[0]["Year"]);
                        // get end date
                        int Month = Convert.ToInt32(dtFilter.Rows[0]["Month"]);

                        // get result records from database for the report
                        DataSet dsReport = Report.WCAllocationMonthlyDetailReport(Month, Year);

                        //Create HTML for the report and wirte into HTML Write object
                        StringBuilder strHTML = new StringBuilder();
                        System.IO.StringWriter stringWrite = new System.IO.StringWriter();
                        System.Web.UI.HtmlTextWriter htmlWrite = new System.Web.UI.HtmlTextWriter(stringWrite);

                        #region "Header"

                        //Add Report Title and Schedule Date
                        strHTML.Append("<span style=\"font-family:Calibri;\">");
                        strHTML.Append("<br />");
                        strHTML.Append("<b>Report Title : WC Allocation Monthly Detail Report</b>");
                        strHTML.Append("<br /><br />");
                        strHTML.Append("Schedule Date : " + Convert.ToDateTime(drReportSchedule["Scheduled_Date"]).ToString(DateDisplayFormat));
                        strHTML.Append("&nbsp;&nbsp;&nbsp;&nbsp;Schedule End Date : " + Convert.ToDateTime(drReportSchedule["Schedule_End_Date"]).ToString(DateDisplayFormat));
                        strHTML.Append("<br />");
                        strHTML.Append("Recurring Period : " + drReportSchedule["Recurring_Period"]).ToString();
                        strHTML.Append("<br />");
                        strHTML.Append("Recurring Date : " + dtSchduleDate.ToString(DateDisplayFormat));

                        //Add Report Filter Criteria 
                        strHTML.Append("<br /><br />");
                        strHTML.Append("<b>Report Filters </b>");
                        strHTML.Append("<br /><br />");
                        strHTML.Append("Year        : " + Year);
                        strHTML.Append("<br />");
                        strHTML.Append("Month          : " + GetMonthString(Convert.ToInt32(Month)));
                        strHTML.Append("<br /><br />");
                        strHTML.Append("</span>");

                        //Add Header HTML
                        strHTML.Append("<table cellpadding='4' cellspacing='0' style='font-weight: bold;font-family:Calibri;' width='100%' border='1'>");
                        strHTML.Append("<tr>");
                        strHTML.Append("<td colspan='19' align='center'>WC Allocation Monthly Detail Report</td>");
                        strHTML.Append("</tr>");
                        strHTML.Append("<tr>");
                        strHTML.Append("<td  align='left' valign='top'>Location</td>");
                        strHTML.Append("<td  align='left' valign='top'>Location Number</td>");
                        strHTML.Append("<td align='left' valign='top'>First Report<br/>Number</td>");
                        strHTML.Append("<td  align='left' valign='top'>Claim Number</td>");
                        strHTML.Append("<td  align='left' valign='top'>Employee</td>");
                        strHTML.Append("<td  align='left' valign='top'>Cause of Incident</td>");
                        strHTML.Append("<td align='left' valign='top'>Date of<br/>Incident</td>");
                        strHTML.Append("<td align='right' valign='top'>Claim<br/>Charge</td>");
                        strHTML.Append("<td align='left' valign='top'>Date<br/>Reported to<br/>SRS</td>");
                        strHTML.Append("<td align='right' valign='top'>Report<br/>Lag</td>");
                        strHTML.Append("<td align='right' valign='top'>Report Lag<br />Credit</td>");
                        strHTML.Append("<td align='right' valign='top'>Report Lag<br />Charge</td>");

                        strHTML.Append("<td align='right' valign='top'>Nurse Triage<br />Credit</td>");
                        strHTML.Append("<td align='right' valign='top'>Incident Investigation<br />Credit</td>");

                        strHTML.Append("<td align='left' valign='top'>Claim Closed<br />Date</td>");
                        strHTML.Append("<td align='right' valign='top'>Claim Closed<br />Credit</td>");

                        strHTML.Append("<td align='left' valign='top'>Claim Reopened<br />Date</td>");
                        strHTML.Append("<td align='right' valign='top'>Claim Reopened<br />Charge</td>");

                        strHTML.Append("<td align='right' valign='top'>Total<br/>Charge</td>");
                        strHTML.Append("</tr></table>");
                        #endregion

                        DataTable dtReportData = dsReport.Tables[0];
                        DataTable dtRegion = dsReport.Tables[1];
                        DataTable dtTotal = dsReport.Tables[2];

                        if (dtRegion.Rows.Count > 0)
                        {
                            //Add Report Data Table 
                            strHTML.Append("<table style='width: 100%;' border='1' align='left' cellpadding='4' cellspacing='0'>");
                            foreach (DataRow drRegion in dtRegion.Rows)
                            {
                                strHTML.Append("<tr><td colspan='19' style='font-family:Calibri;'><b>");
                                strHTML.Append("Region : " + drRegion["Region"].ToString());
                                strHTML.Append("</b></td></tr>");
                                strHTML.Append("<tr><td colspan='19'>");
                                strHTML.Append("<table style='width: 100%;font-family:Calibri;' border='1' align='left' cellpadding='4' cellspacing='0'>");
                                DataRow[] drDataByRegion = dtReportData.Select("Region='" + drRegion["Region"].ToString() + "'");
                                foreach (DataRow drData in drDataByRegion)
                                {
                                    strHTML.Append("<td  align='left' valign='top'>" + drData["dba"] + "</td>");
                                    strHTML.Append("<td align='left' valign='top'>" + drData["Sonic_Location_Code"] + "</td>");
                                    strHTML.Append("<td  align='left' valign='top'>WC-" + drData["WC_FR_Number"] + "</td>");
                                    strHTML.Append("<td  align='left' valign='top'>" + drData["Origin_Claim_Number"] + "</td>");
                                    strHTML.Append("<td  align='left' valign='top'>" + drData["Employee_Name"] + "</td>");
                                    strHTML.Append("<td  align='left' valign='top'>" + drData["Sonic_Cause_Code"] + "</td>");

                                    if (Convert.ToDateTime(drData["Date_Of_Incident"]) != Convert.ToDateTime(System.Data.SqlTypes.SqlDateTime.MinValue.ToString()))
                                        strHTML.Append("<td style='width: 8%;' align='left' valign='top'>" + Convert.ToDateTime(drData["Date_Of_Incident"]).ToString(DateDisplayFormat) + "</td>");
                                    else
                                        strHTML.Append("<td style='width: 8%;' align='left' valign='top'>&nbsp;</td>");

                                    strHTML.Append("<td style='width: 8%;' align='right' valign='top'>$ " + string.Format("{0:N2}", drData["Initial_Charge"]) + "</td>");

                                    if (drData["Initial_Charge_Date"] != DBNull.Value)
                                        strHTML.Append("<td style='width: 8%;' align='left' valign='top'>" + Convert.ToDateTime(drData["Initial_Charge_Date"]).ToString(DateDisplayFormat) + "</td>");
                                    else
                                        strHTML.Append("<td style='width: 8%;' align='left' valign='top'>&nbsp;</td>");

                                    strHTML.Append("<td style='width: 8%;' align='right' valign='top'>" + string.Format("{0:N0}", drData["Report_Lag"]) + "</td>");

                                    strHTML.Append("<td style='width: 8%;' align='right' valign='top'>$ " + string.Format("{0:N2}", drData["Lag_Credit"]) + "</td>");
                                    strHTML.Append("<td style='width: 8%;' align='right' valign='top'>$ " + string.Format("{0:N2}", drData["Lag_Charge"]) + "</td>");

                                    strHTML.Append("<td style='width: 8%;' align='right' valign='top'>$ " + string.Format("{0:N2}", drData["Nurse_Triage_Credit"]) + "</td>");
                                    strHTML.Append("<td style='width: 8%;' align='right' valign='top'>$ " + string.Format("{0:N2}", drData["Incident_Investigation_Credit"]) + "</td>");

                                    if (drData["Early_Close_Credit_Date"] != DBNull.Value)
                                        strHTML.Append("<td style='width: 8%;' align='left' valign='top'>" + Convert.ToDateTime(drData["Early_Close_Credit_Date"]).ToString(DateDisplayFormat) + "</td>");
                                    else
                                        strHTML.Append("<td style='width: 8%;' align='left' valign='top'>&nbsp;</td>");

                                    strHTML.Append("<td style='width: 8%;' align='right' valign='top'>$ " + string.Format("{0:N2}", drData["Early_Close_Credit"]) + "</td>");

                                    if (drData["Reopen_Charge_Date"] != DBNull.Value)
                                        strHTML.Append("<td style='width: 8%;' align='left' valign='top'>" + Convert.ToDateTime(drData["Reopen_Charge_Date"]).ToString(DateDisplayFormat) + "</td>");
                                    else
                                        strHTML.Append("<td style='width: 8%;' align='left' valign='top'>&nbsp;</td>");

                                    strHTML.Append("<td style='width: 8%;' align='right' valign='top'>$ " + string.Format("{0:N2}", drData["Reopen_Charge"]) + "</td>");

                                    strHTML.Append("<td style='width: 8%;' align='right' valign='top'>$ " + string.Format("{0:N2}", drData["Total_Charge"]) + "</td>");
                                    strHTML.Append("</tr>");
                                }
                                strHTML.Append("<tr style='background-color:#FFFFFF;'>");
                                strHTML.Append("<td style='width: 13%;' align='left' valign='top'><b>Total</b></td>");
                                strHTML.Append("<td style='width: 8%;' align='left' valign='top'>&nbsp;</td>");
                                strHTML.Append("<td style='width: 10%;' align='left' valign='top'>&nbsp;</td>");
                                strHTML.Append("<td style='width: 13%;' align='left' valign='top'>&nbsp;</td>");
                                strHTML.Append("<td style='width: 8%;' align='left' valign='top'>&nbsp;</td>");
                                strHTML.Append("<td style='width: 8%;' align='left' valign='top'>&nbsp;</td>");
                                strHTML.Append("<td style='width: 8%;' align='left' valign='top'>&nbsp;</td>");
                                strHTML.Append("<td style='width: 8%;' align='right' valign='top'><b>$ " + string.Format("{0:N2}", drRegion["Initial_Charge"]) + "</b></td>");
                                strHTML.Append("<td style='width: 8%;' align='left' valign='top'>&nbsp;</td>");
                                strHTML.Append("<td style='width: 8%;' align='right' valign='top'><b>" + string.Format("{0:N0}", drRegion["Report_Lag"]) + "</b></td>");
                                strHTML.Append("<td style='width: 8%;' align='right' valign='top'><b>$" + string.Format("{0:N2}", drRegion["Lag_Credit"]) + "</b></td>");
                                strHTML.Append("<td style='width: 8%;' align='right' valign='top'><b>$ " + string.Format("{0:N2}", drRegion["Lag_Charge"]) + "</b></td>");

                                strHTML.Append("<td style='width: 8%;' align='right' valign='top'><b>$" + string.Format("{0:N2}", drRegion["Nurse_Triage_Credit"]) + "</b></td>");
                                strHTML.Append("<td style='width: 8%;' align='right' valign='top'><b>$ " + string.Format("{0:N2}", drRegion["Incident_Investigation_Credit"]) + "</b></td>");
                                strHTML.Append("<td style='width: 8%;' align='left' valign='top'>&nbsp;</td>");
                                strHTML.Append("<td style='width: 8%;' align='right' valign='top'><b>$ " + string.Format("{0:N2}", drRegion["Early_Close_Credit"]) + "</b></td>");
                                strHTML.Append("<td style='width: 8%;' align='left' valign='top'>&nbsp;</td>");
                                strHTML.Append("<td style='width: 8%;' align='right' valign='top'><b>$ " + string.Format("{0:N2}", drRegion["Reopen_Charge"]) + "</b></td>");
                                strHTML.Append("<td style='width: 8%;' align='right' valign='top'><b>$ " + string.Format("{0:N2}", drRegion["Total_Charge"]) + "</b></td>");
                                strHTML.Append("</tr>");
                                strHTML.Append("</table>");
                                strHTML.Append("</td></tr>");
                            }
                            strHTML.Append("<tr style='background-color:#507cd1;font-family:Calibri;color:White;'>");
                            strHTML.Append("<td style='width: 13%;' align='left' valign='top'><b>Grand Total</b></td>");
                            strHTML.Append("<td style='width: 8%;' align='left' valign='top'>&nbsp;</td>");
                            strHTML.Append("<td style='width: 10%;' align='left' valign='top'>&nbsp;</td>");
                            strHTML.Append("<td style='width: 13%;' align='left' valign='top'>&nbsp;</td>");
                            strHTML.Append("<td style='width: 8%;' align='left' valign='top'>&nbsp;</td>");
                            strHTML.Append("<td style='width: 8%;' align='left' valign='top'>&nbsp;</td>");
                            strHTML.Append("<td style='width: 8%;' align='left' valign='top'>&nbsp;</td>");
                            strHTML.Append("<td style='width: 8%;' align='right' valign='top'><b>$ " + string.Format("{0:N2}", dtTotal.Rows[0]["Initial_Charge"]) + "</b></td>");
                            strHTML.Append("<td style='width: 8%;' align='left' valign='top'>&nbsp;</td>");
                            strHTML.Append("<td style='width: 8%;' align='right' valign='top'><b>" + string.Format("{0:N0}", dtTotal.Rows[0]["Report_Lag"]) + "</b></td>");
                            strHTML.Append("<td style='width: 8%;' align='right' valign='top'><b>$" + string.Format("{0:N2}", dtTotal.Rows[0]["Lag_Credit"]) + "</b></td>");
                            strHTML.Append("<td style='width: 8%;' align='right' valign='top'><b>$ " + string.Format("{0:N2}", dtTotal.Rows[0]["Lag_Charge"]) + "</b></td>");

                            strHTML.Append("<td style='width: 8%;' align='right' valign='top'><b>$ " + string.Format("{0:N2}", dtTotal.Rows[0]["Nurse_Triage_Credit"]) + "</b></td>");
                            strHTML.Append("<td style='width: 8%;' align='right' valign='top'><b>$ " + string.Format("{0:N2}", dtTotal.Rows[0]["Incident_Investigation_Credit"]) + "</b></td>");
                            strHTML.Append("<td style='width: 8%;' align='left' valign='top'>&nbsp;</td>");
                            strHTML.Append("<td style='width: 8%;' align='right' valign='top'><b>$ " + string.Format("{0:N2}", dtTotal.Rows[0]["Early_Close_Credit"]) + "</b></td>");
                            strHTML.Append("<td style='width: 8%;' align='left' valign='top'>&nbsp;</td>");
                            strHTML.Append("<td style='width: 8%;' align='right' valign='top'><b>$ " + string.Format("{0:N2}", dtTotal.Rows[0]["Reopen_Charge"]) + "</b></td>");
                            strHTML.Append("<td style='width: 8%;' align='right' valign='top'><b>$ " + string.Format("{0:N2}", dtTotal.Rows[0]["Total_Charge"]) + "</b></td>");
                            strHTML.Append("</tr>");
                            strHTML.Append("</table>");
                            strHTML.Append("</td></tr>");
                            strHTML.Append("</table>");
                        }
                        else
                        {
                            //Add No record found line for year
                            strHTML.Append("<tr><td align='left' colspan='19'>No Record Found!</td></tr>");
                        }


                        //Write HTML in to HtmlWriter
                        htmlWrite.WriteLine(strHTML.ToString());

                        //Send Mail
                        SendMail("WC Allocation Monthly Detail Report", "WCAllocationMonthlyDetailReport.xls", strFirstName, strLastName, strMailFrom, stringWrite, dtRecipients);


                    }
                }
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("ERROR in WC Allocation Monthly Detail Report, " + ex.Message);
            }
        }

        //Report 23
        private void BindWCMonthlyAllocationSummaryReport(DataRow drReportSchedule)
        {
            try
            {
                decimal pK_Schedule_ID = Convert.ToDecimal(drReportSchedule["PK_Schedule"]);
                decimal Fk_RecipientList = Convert.ToDecimal(drReportSchedule["Fk_RecipientList"]);
                decimal FK_Security_Id = Convert.ToDecimal(drReportSchedule["FK_Security_Id"]);

                //Get Report criteria for the scheduled report
                DataTable dtFilter = Report.SelectFilterCriteria(23, pK_Schedule_ID).Tables[0];
                if (dtFilter.Rows.Count > 0)
                {
                    //Get the recipient from the recipient list
                    DataTable dtRecipients = Report.SelectOneRecordWithRecipientList(Fk_RecipientList).Tables[0];

                    //Get the user who has scheduled the report
                    DataTable dtUser = Report.SelectSecurityByPK(FK_Security_Id).Tables[0];

                    String strFirstName, strLastName, strMailFrom;
                    strFirstName = strLastName = strMailFrom = "";
                    if (dtUser.Rows.Count > 0)
                    {
                        strFirstName = dtUser.Rows[0]["FIRST_NAME"].ToString();
                        strLastName = dtUser.Rows[0]["LAST_NAME"].ToString();
                        strMailFrom = dtUser.Rows[0]["Email"].ToString();

                        // get start date
                        Decimal Year = Convert.ToDecimal(dtFilter.Rows[0]["Year"]);

                        // get result records from database for the report
                        DataSet dsReport = Report.WC_Monthly_Allocation_Summary_Report(Year);

                        //Create HTML for the report and wirte into HTML Write object
                        StringBuilder strHTML = new StringBuilder();
                        System.IO.StringWriter stringWrite = new System.IO.StringWriter();
                        System.Web.UI.HtmlTextWriter htmlWrite = new System.Web.UI.HtmlTextWriter(stringWrite);

                        #region "Header"

                        //Add Report Title and Schedule Date
                        strHTML.Append("<span style=\"font-family:Calibri;\">");
                        strHTML.Append("<br />");
                        strHTML.Append("<b>Report Title : WC Monthly Allocation Summary Report</b>");
                        strHTML.Append("<br /><br />");
                        strHTML.Append("Schedule Date : " + Convert.ToDateTime(drReportSchedule["Scheduled_Date"]).ToString(DateDisplayFormat));
                        strHTML.Append("&nbsp;&nbsp;&nbsp;&nbsp;Schedule End Date : " + Convert.ToDateTime(drReportSchedule["Schedule_End_Date"]).ToString(DateDisplayFormat));
                        strHTML.Append("<br />");
                        strHTML.Append("Recurring Period : " + drReportSchedule["Recurring_Period"]).ToString();
                        strHTML.Append("<br />");
                        strHTML.Append("Recurring Date : " + dtSchduleDate.ToString(DateDisplayFormat));

                        //Add Report Filter Criteria 
                        strHTML.Append("<br /><br />");
                        strHTML.Append("<b>Report Filters </b>");
                        strHTML.Append("<br /><br />");
                        strHTML.Append("Year        : " + Year);
                        strHTML.Append("<br /><br />");
                        strHTML.Append("</span>");

                        //Add Header HTML
                        strHTML.Append("<table cellpadding='4' cellspacing='0' style='font-weight: bold;font-family:Calibri;' width='100%' border='1'>");
                        strHTML.Append("<tr>");
                        strHTML.Append("<td  align='left' valign='top'>Location</td>");
                        strHTML.Append("<td  align='left' valign='top'>Location<br/>Code</td>");
                        strHTML.Append("<td  align='right' valign='top'>JAN'" + Year.ToString().Substring(2, 2) + "</td>");
                        strHTML.Append("<td  align='right' valign='top'>FEB'" + Year.ToString().Substring(2, 2) + "</td>");
                        strHTML.Append("<td  align='right' valign='top'>MAR'" + Year.ToString().Substring(2, 2) + "</td>");
                        strHTML.Append("<td  align='right' valign='top'>APR'" + Year.ToString().Substring(2, 2) + "</td>");
                        strHTML.Append("<td  align='right' valign='top'>MAY'" + Year.ToString().Substring(2, 2) + "</td>");
                        strHTML.Append("<td  align='right' valign='top'>JUN'" + Year.ToString().Substring(2, 2) + "</td>");
                        strHTML.Append("<td  align='right' valign='top'>JUL'" + Year.ToString().Substring(2, 2) + "</td>");
                        strHTML.Append("<td  align='right' valign='top'>AUG'" + Year.ToString().Substring(2, 2) + "</td>");
                        strHTML.Append("<td  align='right' valign='top'>SEP'" + Year.ToString().Substring(2, 2) + "</td>");
                        strHTML.Append("<td  align='right' valign='top'>OCT'" + Year.ToString().Substring(2, 2) + "</td>");
                        strHTML.Append("<td  align='right' valign='top'>NOV'" + Year.ToString().Substring(2, 2) + "</td>");
                        strHTML.Append("<td  align='right' valign='top'>DEC'" + Year.ToString().Substring(2, 2) + "</td>");
                        strHTML.Append("<td  align='right' valign='top'>JAN'" + string.Format("{0:D2}", Convert.ToInt32(Year.ToString().Substring(2, 2)) + 1) + "</td>");
                        strHTML.Append("<td  align='right' valign='top'>FEB'" + string.Format("{0:D2}", Convert.ToInt32(Year.ToString().Substring(2, 2)) + 1) + "</td>");
                        strHTML.Append("<td  align='right' valign='top'>MAR'" + string.Format("{0:D2}", Convert.ToInt32(Year.ToString().Substring(2, 2)) + 1) + "</td>");
                        strHTML.Append("<td  align='right' valign='top'>Total Count'" + Year.ToString().Substring(2, 2) + "</td>");
                        strHTML.Append("</tr></table>");
                        #endregion

                        DataTable dtReportData = dsReport.Tables[0];
                        DataTable dtTotal = dsReport.Tables[1];
                        bool bolAlternateRow = false;
                        if (dtReportData.Rows.Count > 0)
                        {
                            //Add Report Data Table 
                            strHTML.Append("<table style='width: 100%;' border='1' align='left' cellpadding='4' cellspacing='0'>");
                            //foreach (DataRow drRegion in dtRegion.Rows)
                            //{
                            strHTML.Append("<tr><td colspan='15'>");
                            strHTML.Append("<table style='width: 100%;font-family:Calibri;' border='1' align='left' cellpadding='4' cellspacing='0'>");
                            foreach (DataRow drData in dtReportData.Rows)
                            {
                                strHTML.Append("<td  align='left' valign='top'>" + drData["dba"] + "</td>");
                                strHTML.Append("<td  align='left' valign='top'>" + drData["sonic_location_code"] + "</td>");
                                strHTML.Append("<td  align='right' valign='top'>$ " + string.Format("{0:N2}", drData["JAN"]) + "</td>");
                                strHTML.Append("<td  align='right' valign='top'>$ " + string.Format("{0:N2}", drData["FEB"]) + "</td>");
                                strHTML.Append("<td  align='right' valign='top'>$ " + string.Format("{0:N2}", drData["MAR"]) + "</td>");
                                strHTML.Append("<td  align='right' valign='top'>$ " + string.Format("{0:N2}", drData["APR"]) + "</td>");
                                strHTML.Append("<td  align='right' valign='top'>$ " + string.Format("{0:N2}", drData["MAY"]) + "</td>");
                                strHTML.Append("<td  align='right' valign='top'>$ " + string.Format("{0:N2}", drData["JUN"]) + "</td>");
                                strHTML.Append("<td  align='right' valign='top'>$ " + string.Format("{0:N2}", drData["JUL"]) + "</td>");
                                strHTML.Append("<td  align='right' valign='top'>$ " + string.Format("{0:N2}", drData["AUG"]) + "</td>");
                                strHTML.Append("<td  align='right' valign='top'>$ " + string.Format("{0:N2}", drData["SEP"]) + "</td>");
                                strHTML.Append("<td  align='right' valign='top'>$ " + string.Format("{0:N2}", drData["OCT"]) + "</td>");
                                strHTML.Append("<td  align='right' valign='top'>$ " + string.Format("{0:N2}", drData["NOV"]) + "</td>");
                                strHTML.Append("<td  align='right' valign='top'>$ " + string.Format("{0:N2}", drData["DEC"]) + "</td>");
                                strHTML.Append("<td  align='right' valign='top'>$ " + string.Format("{0:N2}", drData["Next_JAN"]) + "</td>");
                                strHTML.Append("<td  align='right' valign='top'>$ " + string.Format("{0:N2}", drData["Next_FEB"]) + "</td>");
                                strHTML.Append("<td  align='right' valign='top'>$ " + string.Format("{0:N2}", drData["Next_MAR"]) + "</td>");
                                strHTML.Append("<td  align='right' valign='top'>$ " + string.Format("{0:N2}", drData["Total"]) + "</td>");
                                strHTML.Append("</tr>");
                            }
                            strHTML.Append("<tr style='background-color:#507cd1;font-weight:bold;font-family:Calibri;color:White;'>");
                            strHTML.Append("<td align='left' valign='top'>Total</td>");
                            strHTML.Append("<td align='left' valign='top'>&nbsp;</td>");
                            strHTML.Append("<td align='right' valign='top'>$ " + string.Format("{0:N2}", dtTotal.Rows[0]["JAN"]) + "</td>");
                            strHTML.Append("<td align='right' valign='top'>$ " + string.Format("{0:N2}", dtTotal.Rows[0]["FEB"]) + "</td>");
                            strHTML.Append("<td align='right' valign='top'>$ " + string.Format("{0:N2}", dtTotal.Rows[0]["MAR"]) + "</td>");
                            strHTML.Append("<td align='right' valign='top'>$ " + string.Format("{0:N2}", dtTotal.Rows[0]["APR"]) + "</td>");
                            strHTML.Append("<td align='right' valign='top'>$ " + string.Format("{0:N2}", dtTotal.Rows[0]["MAY"]) + "</td>");
                            strHTML.Append("<td align='right' valign='top'>$ " + string.Format("{0:N2}", dtTotal.Rows[0]["JUN"]) + "</td>");
                            strHTML.Append("<td align='right' valign='top'>$ " + string.Format("{0:N2}", dtTotal.Rows[0]["JUL"]) + "</td>");
                            strHTML.Append("<td align='right' valign='top'>$ " + string.Format("{0:N2}", dtTotal.Rows[0]["AUG"]) + "</td>");
                            strHTML.Append("<td align='right' valign='top'>$ " + string.Format("{0:N2}", dtTotal.Rows[0]["SEP"]) + "</td>");
                            strHTML.Append("<td align='right' valign='top'>$ " + string.Format("{0:N2}", dtTotal.Rows[0]["OCT"]) + "</td>");
                            strHTML.Append("<td align='right' valign='top'>$ " + string.Format("{0:N2}", dtTotal.Rows[0]["NOV"]) + "</td>");
                            strHTML.Append("<td align='right' valign='top'>$ " + string.Format("{0:N2}", dtTotal.Rows[0]["DEC"]) + "</td>");
                            strHTML.Append("<td align='right' valign='top'>$ " + string.Format("{0:N2}", dtTotal.Rows[0]["Next_JAN"]) + "</td>");
                            strHTML.Append("<td align='right' valign='top'>$ " + string.Format("{0:N2}", dtTotal.Rows[0]["Next_FEB"]) + "</td>");
                            strHTML.Append("<td align='right' valign='top'>$ " + string.Format("{0:N2}", dtTotal.Rows[0]["Next_MAR"]) + "</td>");
                            strHTML.Append("<td align='right' valign='top'>$ " + string.Format("{0:N2}", dtTotal.Rows[0]["Total"]) + "</td>");
                            strHTML.Append("</tr>");
                            strHTML.Append("</table>");
                            strHTML.Append("</td></tr>");
                            //}
                            strHTML.Append("</table>");
                            strHTML.Append("</td></tr>");
                            strHTML.Append("</table>");
                        }
                        else
                        {
                            //Add No record found line for year
                            strHTML.Append("<tr><td align='left' colspan='16'>No Record Found!</td></tr>");
                        }


                        //Write HTML in to HtmlWriter
                        htmlWrite.WriteLine(strHTML.ToString());

                        //Send Mail
                        SendMail("WC Monthly Allocation Summary Report", "WCMonthlyAllocationSummaryReport.xls", strFirstName, strLastName, strMailFrom, stringWrite, dtRecipients);


                    }
                }
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("ERROR in WC Monthly Allocation Summary Report, " + ex.Message);
            }
        }

        //Report 24
        private void BindPurchaseServiceContractDetailReport(DataRow drReportSchedule)
        {
            try
            {
                decimal pK_Schedule_ID = Convert.ToDecimal(drReportSchedule["PK_Schedule"]);
                decimal Fk_RecipientList = Convert.ToDecimal(drReportSchedule["Fk_RecipientList"]);
                decimal FK_Security_Id = Convert.ToDecimal(drReportSchedule["FK_Security_Id"]);

                //Get Report criteria for the scheduled report
                DataTable dtFilter = Report.SelectFilterCriteria(24, pK_Schedule_ID).Tables[0];
                if (dtFilter.Rows.Count > 0)
                {
                    //Get the recipient from the recipient list
                    DataTable dtRecipients = Report.SelectOneRecordWithRecipientList(Fk_RecipientList).Tables[0];

                    //Get the user who has scheduled the report
                    DataTable dtUser = Report.SelectSecurityByPK(FK_Security_Id).Tables[0];

                    String strFirstName, strLastName, strMailFrom;
                    strFirstName = strLastName = strMailFrom = "";
                    if (dtUser.Rows.Count > 0)
                    {
                        strFirstName = dtUser.Rows[0]["FIRST_NAME"].ToString();
                        strLastName = dtUser.Rows[0]["LAST_NAME"].ToString();
                        strMailFrom = dtUser.Rows[0]["Email"].ToString();

                        // get start date
                        string strRegion = dtFilter.Rows[0]["Region"].ToString();
                        string strMarket = null;
                        if (!string.IsNullOrEmpty(Convert.ToString(dtFilter.Rows[0]["Market"])))
                        {
                            strMarket = Convert.ToString(dtFilter.Rows[0]["Market"]).Trim();
                        }
                        string strLocation = dtFilter.Rows[0]["Location"].ToString();
                        string strServiceContract = dtFilter.Rows[0]["ServiceContract"].ToString();
                        string strServiceType = dtFilter.Rows[0]["ServiceType"].ToString();
                        Nullable<DateTime> StartToDate = null;
                        Nullable<DateTime> StartFromDate = null;
                        Nullable<DateTime> EndToDate = null;
                        Nullable<DateTime> EndFromDate = null;

                        if (dtFilter.Rows[0]["StartToDate"] != null && dtFilter.Rows[0]["StartToDate"] != DBNull.Value)
                            StartToDate = Convert.ToDateTime(dtFilter.Rows[0]["StartToDate"].ToString());
                        if (dtFilter.Rows[0]["StartFromDate"] != null && dtFilter.Rows[0]["StartFromDate"] != DBNull.Value)
                            StartFromDate = Convert.ToDateTime(dtFilter.Rows[0]["StartFromDate"].ToString());
                        if (dtFilter.Rows[0]["EndToDate"] != null && dtFilter.Rows[0]["EndToDate"] != DBNull.Value)
                            EndToDate = Convert.ToDateTime(dtFilter.Rows[0]["EndToDate"].ToString());
                        if (dtFilter.Rows[0]["EndFromDate"] != null && dtFilter.Rows[0]["EndFromDate"] != DBNull.Value)
                            EndFromDate = Convert.ToDateTime(dtFilter.Rows[0]["EndFromDate"].ToString());
                       
                        // get result records from database for the report
                        DataSet dsReport = Report.GetService_Contract_Detail_Report(strRegion, strMarket, strLocation, strServiceContract, strServiceType, StartToDate, StartFromDate, EndToDate, EndFromDate);

                        //Create HTML for the report and wirte into HTML Write object
                        StringBuilder strHTML = new StringBuilder();
                        System.IO.StringWriter stringWrite = new System.IO.StringWriter();
                        System.Web.UI.HtmlTextWriter htmlWrite = new System.Web.UI.HtmlTextWriter(stringWrite);

                        #region "Header"

                        //Retrieve Market Values
                        string strMarketString = string.Empty;
                        if (string.IsNullOrEmpty(strMarket))
                        {
                            strMarketString = "All Market";
                        }
                        else
                        {
                            string[] strMar = strMarket.Split(Convert.ToChar(","));
                            for (int i = 0; i < strMar.Length; i++)
                            {
                                strMarketString += Report.SelectMarketInfoById(Convert.ToDecimal(strMar[i].ToString())).Tables[0].Rows[0]["Market"].ToString() + ",";
                            }
                            strMarketString = strMarketString.TrimEnd(',');
                        }
                        //Add Report Title and Schedule Date
                        strHTML.Append("<span style=\"font-family:Calibri;\">");
                        strHTML.Append("<br />");
                        strHTML.Append("<b>Report Title : Purchase Service Contract Detail Report</b>");
                        strHTML.Append("<br /><br />");
                        strHTML.Append("Schedule Date : " + Convert.ToDateTime(drReportSchedule["Scheduled_Date"]).ToString(DateDisplayFormat));
                        strHTML.Append("&nbsp;&nbsp;&nbsp;&nbsp;Schedule End Date : " + Convert.ToDateTime(drReportSchedule["Schedule_End_Date"]).ToString(DateDisplayFormat));
                        strHTML.Append("<br />");
                        strHTML.Append("Recurring Period : " + drReportSchedule["Recurring_Period"]).ToString();
                        strHTML.Append("<br />");
                        strHTML.Append("Recurring Date : " + dtSchduleDate.ToString(DateDisplayFormat));

                        string strLocationString = string.Empty;
                        string[] strLoc = strLocation.Split(Convert.ToChar(","));
                        for (int i = 0; i < strLoc.Length - 1; i++)
                        {
                            strLocationString += Report.SelectLocationInfoById(Convert.ToDecimal(strLoc[i].ToString())).Tables[0].Rows[0]["dba"].ToString() + ",";
                        }
                        //foreach (string strl in strLoc)
                        //{
                        //    strLocationString += Report.SelectLocationInfoById(Convert.ToDecimal(strl.ToString())).Tables[0].Rows[0]["dba"].ToString() + ",";
                        //}

                        //Add Report Filter Criteria 
                        strHTML.Append("<br /><br />");
                        strHTML.Append("<b>Report Filters </b>");
                        strHTML.Append("<br /><br />");
                        strHTML.Append("Region        : " + strRegion.Trim(Convert.ToChar("'")).Replace("','", "<b>,</b>").ToString());
                        strHTML.Append("<br /><br />");
                        strHTML.Append("Location        : " + strLocationString);
                        //strHTML.Append("Location        : " + strLocation.Replace("/", "_").Replace("'", "_").Replace("-","_").Replace(".","_").Replace("&","_").Replace(" ","_"));
                        strHTML.Append("<br /><br />");
                        strHTML.Append("Service Contract        : " + strServiceContract.Trim(Convert.ToChar("'")).Replace("','", "<b>,</b>").ToString());
                        strHTML.Append("<br /><br />");
                        strHTML.Append("Service Type        : " + strServiceType.Trim(Convert.ToChar("'")).Replace("','", "<b>,</b>").ToString());
                        strHTML.Append("<br /><br />");
                        strHTML.Append("Start Date between " + StartFromDate != null ? Convert.ToDateTime(StartFromDate).ToString(DateDisplayFormat) : "" + " and " + StartToDate != null ? Convert.ToDateTime(StartToDate).ToString(DateDisplayFormat) : "");
                        strHTML.Append("<br /><br />");
                        strHTML.Append("End Date between " + EndFromDate != null ? Convert.ToDateTime(EndFromDate).ToString(DateDisplayFormat) : "" + " and " + EndToDate != null ? Convert.ToDateTime(EndToDate).ToString(DateDisplayFormat) : "");
                        strHTML.Append("<br /><br />");
                        strHTML.Append("</span>");

                        //Add Header HTML
                        strHTML.Append("<table cellpadding='4' cellspacing='0' style='font-weight: bold;font-family:Calibri;' width='100%' border='1'>");
                        strHTML.Append("<tr>");
                        strHTML.Append("<td  align='left' valign='top'>Region</td>");
                        strHTML.Append("<td  align='left' valign='top'>Supplier</td>");
                        strHTML.Append("<td  align='left' valign='top'>Location</td>");
                        strHTML.Append("<td  align='left' valign='top'>Service Type</td>");
                        strHTML.Append("<td  align='left' valign='top'>Start Date</td>");
                        strHTML.Append("<td  align='left' valign='top'>End Date</td>");
                        strHTML.Append("<td  align='right' valign='top'>Monthly Cost</td>");
                        strHTML.Append("<td  align='right' valign='top'>Annual Cost</td>");
                        strHTML.Append("</tr></table>");
                        #endregion

                        DataTable dtDetails = dsReport.Tables[0];
                        DataTable dtSupplierTotals = dsReport.Tables[1];
                        DataTable dtGrandTotal = dsReport.Tables[2];


                        DataView dvSupplierTotals = dtSupplierTotals.DefaultView;
                        dvSupplierTotals.Sort = "Region";
                        dtSupplierTotals = dvSupplierTotals.ToTable();
                        if (dtSupplierTotals.Rows.Count > 0)
                        {
                            //Add Report Data Table 
                            strHTML.Append("<table style='width: 100%;' border='1' align='left' cellpadding='4' cellspacing='0'>");
                            foreach (DataRow drSupplier in dtSupplierTotals.Rows)
                            {
                                //strHTML.Append("<tr><td colspan='11' style='font-family:Calibri;'><b>Region : ");
                                //strHTML.Append(drRegion["Region"].ToString());
                                //strHTML.Append("</b></td></tr>");
                                strHTML.Append("<tr><td colspan='8'>");
                                strHTML.Append("<table style='width: 100%;font-family:Calibri;' border='1' align='left' cellpadding='4' cellspacing='0'>");
                                DataRow[] drDataBySupplier = dtDetails.Select("Region='" + drSupplier["Region"].ToString() + "'");
                                foreach (DataRow drData in drDataBySupplier)
                                {
                                    strHTML.Append("<tr style='background-color:#FFFFFF;'>");
                                    strHTML.Append("<td style='width: 8%;' align='left' valign='top'>" + drData["Region"] + "</td>");
                                    strHTML.Append("<td style='width: 15%;' align='left' valign='top'>" + drData["Supplier"] + "</td>");
                                    strHTML.Append("<td style='width: 16%;' align='left' valign='top'>" + drData["Location"] + "</td>");
                                    strHTML.Append("<td style='width: 12%;' align='left' valign='top'>" + drData["ServiceType"] + "</td>");
                                    strHTML.Append("<td style='width: 10%;' align='left' valign='top'>" + FormatDBNullDateToDisplay(drData["Start_Date"]) + "</td>");
                                    strHTML.Append("<td style='width: 10%;' align='left' valign='top'>" + FormatDBNullDateToDisplay(drData["End_Date"]) + "</td>");
                                    strHTML.Append("<td style='width: 12%;' align='right' valign='top'>$ " + string.Format("{0:N2}", drData["Monthly_Cost"]) + "</td>");
                                    strHTML.Append("<td style='width: 12%;' align='right' valign='top'>$ " + string.Format("{0:N2}", drData["Annual_Cost"]) + "</td>");
                                    strHTML.Append("</tr>");
                                }
                                strHTML.Append("<tr style='background-color:#FFFFFF;'>");
                                strHTML.Append("<td style='width: 15%;' align='left' valign='top'><b>Total</b></td>");
                                strHTML.Append("<td style='width: 8%;' align='left' valign='top'><b>" + string.Format("{0:N0}", drSupplier["Total"]) + "</b></td>");
                                strHTML.Append("<td style='width: 16%;' align='left' valign='top'>&nbsp;</td>");
                                strHTML.Append("<td style='width: 12%;' align='left' valign='top'>&nbsp;</td>");
                                strHTML.Append("<td style='width: 10%;' align='left' valign='top'>&nbsp;</td>");
                                strHTML.Append("<td style='width: 10%;' align='left' valign='top'>&nbsp;</td>");
                                strHTML.Append("<td style='width: 12%;' align='right' valign='top'><b>$ " + string.Format("{0:N2}", drSupplier["Monthly_Cost"]) + "</b></td>");
                                strHTML.Append("<td style='width: 12%;' align='right' valign='top'><b>$ " + string.Format("{0:N2}", drSupplier["Annual_Cost"]) + "</b></td>");
                                strHTML.Append("</tr>");
                                strHTML.Append("</table>");
                                strHTML.Append("</td></tr>");
                            }
                            strHTML.Append("<tr style='background-color:#507cd1;font-family:Calibri;color:White;'>");
                            strHTML.Append("<td style='width: 15%;' align='left' valign='top'><b>Grand Total</b></td>");
                            strHTML.Append("<td style='width: 8%;' align='left' valign='top'><b>" + string.Format("{0:N0}", dtGrandTotal.Rows[0]["Total"]) + "</b></td>");
                            strHTML.Append("<td style='width: 16%;' align='left' valign='top'>&nbsp;</td>");
                            strHTML.Append("<td style='width: 12%;' align='left' valign='top'>&nbsp;</td>");
                            strHTML.Append("<td style='width: 10%;' align='left' valign='top'>&nbsp;</td>");
                            strHTML.Append("<td style='width: 10%;' align='left' valign='top'>&nbsp;</td>");
                            strHTML.Append("<td style='width: 12%;' align='right' valign='top'><b>$ " + string.Format("{0:N2}", dtGrandTotal.Rows[0]["Monthly_Cost"]) + "</b></td>");
                            strHTML.Append("<td style='width: 12%;' align='right' valign='top'><b>$ " + string.Format("{0:N2}", dtGrandTotal.Rows[0]["Annual_Cost"]) + "</b></td>");
                            strHTML.Append("</tr>");
                            strHTML.Append("</table>");
                            strHTML.Append("</td></tr>");
                            strHTML.Append("</table>");
                        }
                        else
                        {
                            //Add No record found line for year
                            strHTML.Append("<tr><td align='left' colspan='8'>No Record Found!</td></tr>");
                        }

                        //Write HTML in to HtmlWriter
                        htmlWrite.WriteLine(strHTML.ToString());

                        //Send Mail
                        SendMail("Purchase Serice Contract Detail Report", "PurchaseServiceContractDetail.xls", strFirstName, strLastName, strMailFrom, stringWrite, dtRecipients);


                    }
                }
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("ERROR in Purchase Serice Contract Detail Report, " + ex.Message);
            }
        }

        //Report 25
        private void BindLeaseRentalAgreementDetailReport(DataRow drReportSchedule)
        {
            try
            {
                decimal pK_Schedule_ID = Convert.ToDecimal(drReportSchedule["PK_Schedule"]);
                decimal Fk_RecipientList = Convert.ToDecimal(drReportSchedule["Fk_RecipientList"]);
                decimal FK_Security_Id = Convert.ToDecimal(drReportSchedule["FK_Security_Id"]);

                //Get Report criteria for the scheduled report
                DataTable dtFilter = Report.SelectFilterCriteria(25, pK_Schedule_ID).Tables[0];
                if (dtFilter.Rows.Count > 0)
                {
                    //Get the recipient from the recipient list
                    DataTable dtRecipients = Report.SelectOneRecordWithRecipientList(Fk_RecipientList).Tables[0];

                    //Get the user who has scheduled the report
                    DataTable dtUser = Report.SelectSecurityByPK(FK_Security_Id).Tables[0];

                    String strFirstName, strLastName, strMailFrom;
                    strFirstName = strLastName = strMailFrom = "";
                    if (dtUser.Rows.Count > 0)
                    {
                        strFirstName = dtUser.Rows[0]["FIRST_NAME"].ToString();
                        strLastName = dtUser.Rows[0]["LAST_NAME"].ToString();
                        strMailFrom = dtUser.Rows[0]["Email"].ToString();

                        // get start date
                        string strRegion = dtFilter.Rows[0]["Region"].ToString();
                        string strMarket = null;
                        if (!string.IsNullOrEmpty(Convert.ToString(dtFilter.Rows[0]["Market"])))
                        {
                            strMarket = Convert.ToString(dtFilter.Rows[0]["Market"]).Trim();
                        }
                        string strLocation = dtFilter.Rows[0]["Location"].ToString();
                        string strEquipmentType = dtFilter.Rows[0]["EquipmentType"].ToString();
                        string strLeaseRentalType = dtFilter.Rows[0]["LeaseRentalType"].ToString();

                        Nullable<DateTime> StartToDate = null;
                        Nullable<DateTime> StartFromDate = null;
                        Nullable<DateTime> EndToDate = null;
                        Nullable<DateTime> EndFromDate = null;

                        if (dtFilter.Rows[0]["StartToDate"] != null && dtFilter.Rows[0]["StartToDate"] != DBNull.Value)
                            StartToDate = Convert.ToDateTime(dtFilter.Rows[0]["StartToDate"].ToString());
                        if (dtFilter.Rows[0]["StartFromDate"] != null && dtFilter.Rows[0]["StartFromDate"] != DBNull.Value)
                            StartFromDate = Convert.ToDateTime(dtFilter.Rows[0]["StartFromDate"].ToString());
                        if (dtFilter.Rows[0]["EndToDate"] != null && dtFilter.Rows[0]["EndToDate"] != DBNull.Value)
                            EndToDate = Convert.ToDateTime(dtFilter.Rows[0]["EndToDate"].ToString());
                        if (dtFilter.Rows[0]["EndFromDate"] != null && dtFilter.Rows[0]["EndFromDate"] != DBNull.Value)
                            EndFromDate = Convert.ToDateTime(dtFilter.Rows[0]["EndFromDate"].ToString());

                        // get result records from database for the report
                        DataSet dsReport = Report.GetLease_Rental_Detail_Report(strRegion, strMarket, strLocation, strEquipmentType, strLeaseRentalType, StartToDate, StartFromDate, EndToDate, EndFromDate);

                        //Create HTML for the report and wirte into HTML Write object
                        StringBuilder strHTML = new StringBuilder();
                        System.IO.StringWriter stringWrite = new System.IO.StringWriter();
                        System.Web.UI.HtmlTextWriter htmlWrite = new System.Web.UI.HtmlTextWriter(stringWrite);

                        #region "Header"

                        //Add Report Title and Schedule Date
                        strHTML.Append("<span style=\"font-family:Calibri;\">");
                        strHTML.Append("<br />");
                        strHTML.Append("<b>Report Title : Lease/Rental Agreement Detail Report</b>");
                        strHTML.Append("<br /><br />");
                        strHTML.Append("Schedule Date : " + Convert.ToDateTime(drReportSchedule["Scheduled_Date"]).ToString(DateDisplayFormat));
                        strHTML.Append("&nbsp;&nbsp;&nbsp;&nbsp;Schedule End Date : " + Convert.ToDateTime(drReportSchedule["Schedule_End_Date"]).ToString(DateDisplayFormat));
                        strHTML.Append("<br />");
                        strHTML.Append("Recurring Period : " + drReportSchedule["Recurring_Period"]).ToString();
                        strHTML.Append("<br />");
                        strHTML.Append("Recurring Date : " + dtSchduleDate.ToString(DateDisplayFormat));

                        string strLocationString = string.Empty;
                        string[] strLoc = strLocation.Split(Convert.ToChar(","));
                        for (int i = 0; i < strLoc.Length - 1; i++)
                        {
                            strLocationString += Report.SelectLocationInfoById(Convert.ToDecimal(strLoc[i].ToString())).Tables[0].Rows[0]["dba"].ToString() + ",";
                        }
                        strLocationString = strLocationString.TrimEnd(',');

                        //Retrieve Market Values
                        string strMarketString = string.Empty;
                        if (string.IsNullOrEmpty(strMarket))
                        {
                            strMarketString = "All Market";
                        }
                        else
                        {
                            string[] strMar = strMarket.Split(Convert.ToChar(","));
                            for (int i = 0; i < strMar.Length; i++)
                            {
                                strMarketString += Report.SelectMarketInfoById(Convert.ToDecimal(strMar[i].ToString())).Tables[0].Rows[0]["Market"].ToString() + ",";
                            }
                            strMarketString = strMarketString.TrimEnd(',');
                        }

                        //foreach (string strl in strLoc)
                        //{
                        //    strLocationString += Report.SelectLocationInfoById(Convert.ToDecimal(strl.ToString())).Tables[0].Rows[0]["dba"].ToString() + ",";
                        //}

                        //Add Report Filter Criteria 
                        strHTML.Append("<br /><br />");
                        strHTML.Append("<b>Report Filters </b>");
                        strHTML.Append("<br /><br />");
                        strHTML.Append("Region        : " + strRegion.Trim(Convert.ToChar("'")).Replace("','", "<b>,</b>").ToString());
                        strHTML.Append("<br /><br />");
                        strHTML.Append("Location        : " + strLocationString);
                        strHTML.Append("<br /><br />");
                        strHTML.Append("Market        : " + strMarketString);
                        //strHTML.Append("Location        : " + strLocation.Replace("/", "_").Replace("'", "_").Replace("-","_").Replace(".","_").Replace("&","_").Replace(" ","_"));
                        strHTML.Append("<br /><br />");
                        strHTML.Append("Equipment Type        : " + strEquipmentType.Trim(Convert.ToChar("'")).Replace("','", "<b>,</b>").ToString());
                        strHTML.Append("<br /><br />");
                        strHTML.Append("Lease/Rental Type        : " + strLeaseRentalType.Trim(Convert.ToChar("'")).Replace("','", "<b>,</b>").ToString());
                        strHTML.Append("<br /><br />");
                        strHTML.Append("Start Date between " + StartFromDate != null ? Convert.ToDateTime(StartFromDate).ToString(DateDisplayFormat) : "" + " and " + StartToDate != null ? Convert.ToDateTime(StartToDate).ToString(DateDisplayFormat) : "");
                        strHTML.Append("<br /><br />");
                        strHTML.Append("End Date between " + EndFromDate != null ? Convert.ToDateTime(EndFromDate).ToString(DateDisplayFormat) : "" + " and " + EndToDate != null ? Convert.ToDateTime(EndToDate).ToString(DateDisplayFormat) : "");
                        strHTML.Append("<br /><br />");
                        strHTML.Append("</span>");

                        //Add Header HTML
                        strHTML.Append("<table cellpadding='4' cellspacing='0' style='font-weight: bold;font-family:Calibri;' width='100%' border='1'>");
                        strHTML.Append("<tr>");
                        strHTML.Append("<td  align='left' valign='top'>Region</td>");
                        strHTML.Append("<td  align='left' valign='top'>Supplier</td>");
                        strHTML.Append("<td  align='left' valign='top'>Location</td>");
                        strHTML.Append("<td  align='left' valign='top'>Equipment Type</td>");
                        strHTML.Append("<td  align='left' valign='top'>Lease/Rental Type</td>");
                        strHTML.Append("<td  align='left' valign='top'>Start Date</td>");
                        strHTML.Append("<td  align='left' valign='top'>End Date</td>");
                        strHTML.Append("<td  align='right' valign='top'>Monthly Cost</td>");
                        strHTML.Append("<td  align='right' valign='top'>Annual Cost</td>");
                        strHTML.Append("<td  align='right' valign='top'>Total Committed</td>");
                        strHTML.Append("<td  align='right' valign='top'>Months Remaining</td>");
                        strHTML.Append("</tr></table>");
                        #endregion

                        DataTable dtDetails = dsReport.Tables[0];
                        DataTable dtSupplierTotals = dsReport.Tables[1];
                        DataTable dtGrandTotal = dsReport.Tables[2];


                        DataView dvSupplierTotals = dtSupplierTotals.DefaultView;
                        dvSupplierTotals.Sort = "Region";
                        dtSupplierTotals = dvSupplierTotals.ToTable();
                        if (dtSupplierTotals.Rows.Count > 0)
                        {
                            //Add Report Data Table 
                            strHTML.Append("<table style='width: 100%;' border='1' align='left' cellpadding='4' cellspacing='0'>");
                            foreach (DataRow drSupplier in dtSupplierTotals.Rows)
                            {
                                //strHTML.Append("<tr><td colspan='11' style='font-family:Calibri;'><b>Region : ");
                                //strHTML.Append(drRegion["Region"].ToString());
                                //strHTML.Append("</b></td></tr>");
                                strHTML.Append("<tr><td colspan='11'>");
                                strHTML.Append("<table style='width: 100%;font-family:Calibri;' border='1' align='left' cellpadding='4' cellspacing='0'>");
                                DataRow[] drDataBySupplier = dtDetails.Select("Region='" + drSupplier["Region"].ToString() + "'");
                                foreach (DataRow drData in drDataBySupplier)
                                {
                                    strHTML.Append("<tr style='background-color:#FFFFFF;'>");
                                    strHTML.Append("<td style='width: 11%;' align='left' valign='top'>" + drData["Region"] + "</td>");
                                    strHTML.Append("<td style='width: 12%;' align='left' valign='top'>" + drData["Supplier"] + "</td>");
                                    strHTML.Append("<td style='width: 16%;' align='left' valign='top'>" + drData["Location"] + "</td>");
                                    strHTML.Append("<td style='width: 12%;' align='left' valign='top'>" + drData["EquipmentType"] + "</td>");
                                    strHTML.Append("<td style='width: 12%;' align='left' valign='top'>" + drData["Lease_Rental_Type"] + "</td>");

                                    strHTML.Append("<td style='width: 10%;' align='left' valign='top'>" + FormatDBNullDateToDisplay(drData["Start_Date"]) + "</td>");

                                    strHTML.Append("<td style='width: 10%;' align='left' valign='top'>" + FormatDBNullDateToDisplay(drData["End_Date"]) + "</td>");

                                    strHTML.Append("<td style='width: 12%;' align='right' valign='top'>$ " + string.Format("{0:N2}", drData["Monthly_Cost"]) + "</td>");
                                    strHTML.Append("<td style='width: 12%;' align='right' valign='top'>$ " + string.Format("{0:N2}", drData["Annual_Cost"]) + "</td>");
                                    strHTML.Append("<td style='width: 12%;' align='right' valign='top'>$ " + string.Format("{0:N2}", drData["Total_Committed"]) + "</td>");
                                    strHTML.Append("<td style='width: 12%;' align='right' valign='top'>" + string.Format("{0:N0}", drData["Months_Remaining"]) + "</td>");
                                    strHTML.Append("</tr>");
                                }
                                strHTML.Append("<tr style='background-color:#FFFFFF;'>");
                                strHTML.Append("<td style='width: 11%;' align='left' valign='top'><b>Total</b></td>");
                                strHTML.Append("<td style='width: 12%;' align='left' valign='top'><b>" + string.Format("{0:N0}", drSupplier["Total"]) + "</b></td>");
                                strHTML.Append("<td style='width: 16%;' align='left' valign='top'>&nbsp;</td>");
                                strHTML.Append("<td style='width: 12%;' align='left' valign='top'>&nbsp;</td>");
                                strHTML.Append("<td style='width: 12%;' align='left' valign='top'>&nbsp;</td>");
                                strHTML.Append("<td style='width: 10%;' align='left' valign='top'>&nbsp;</td>");
                                strHTML.Append("<td style='width: 10%;' align='left' valign='top'>&nbsp;</td>");
                                strHTML.Append("<td style='width: 12%;' align='right' valign='top'><b>$ " + string.Format("{0:N2}", drSupplier["Monthly_Cost"]) + "</b></td>");
                                strHTML.Append("<td style='width: 12%;' align='right' valign='top'><b>$ " + string.Format("{0:N2}", drSupplier["Annual_Cost"]) + "</b></td>");
                                strHTML.Append("<td style='width: 12%;' align='right' valign='top'><b>$ " + string.Format("{0:N2}", drSupplier["Total_Committed"]) + "</b></td>");
                                strHTML.Append("<td style='width: 12%;' align='right' valign='top'><b>" + string.Format("{0:N0}", drSupplier["Months_Remaining"]) + "</b></td>");
                                strHTML.Append("</tr>");
                                strHTML.Append("</table>");
                                strHTML.Append("</td></tr>");
                            }
                            strHTML.Append("<tr style='background-color:#507cd1;font-family:Calibri;color:White;'>");
                            strHTML.Append("<td style='width: 11%;' align='left' valign='top'><b>Grand Total</b></td>");
                            strHTML.Append("<td style='width: 12%;' align='left' valign='top'><b>" + string.Format("{0:N0}", dtGrandTotal.Rows[0]["Total"]) + "</b></td>");
                            strHTML.Append("<td style='width: 16%;' align='left' valign='top'>&nbsp;</td>");
                            strHTML.Append("<td style='width: 12%;' align='left' valign='top'>&nbsp;</td>");
                            strHTML.Append("<td style='width: 12%;' align='left' valign='top'>&nbsp;</td>");
                            strHTML.Append("<td style='width: 10%;' align='left' valign='top'>&nbsp;</td>");
                            strHTML.Append("<td style='width: 10%;' align='left' valign='top'>&nbsp;</td>");
                            strHTML.Append("<td style='width: 12%;' align='right' valign='top'><b>$ " + string.Format("{0:N2}", dtGrandTotal.Rows[0]["Monthly_Cost"]) + "</b></td>");
                            strHTML.Append("<td style='width: 12%;' align='right' valign='top'><b>$ " + string.Format("{0:N2}", dtGrandTotal.Rows[0]["Annual_Cost"]) + "</b></td>");
                            strHTML.Append("<td style='width: 12%;' align='right' valign='top'><b>$ " + string.Format("{0:N0}", dtGrandTotal.Rows[0]["Total_Committed"]) + "</b></td>");
                            strHTML.Append("<td style='width: 12%;' align='right' valign='top'><b>" + string.Format("{0:N0}", dtGrandTotal.Rows[0]["Months_Remaining"]) + "</b></td>");
                            strHTML.Append("</tr>");
                            strHTML.Append("</table>");
                            strHTML.Append("</td></tr>");
                            strHTML.Append("</table>");
                        }
                        else
                        {
                            //Add No record found line for year
                            strHTML.Append("<tr><td align='left' colspan='11'>No Record Found!</td></tr>");
                        }

                        //Write HTML in to HtmlWriter
                        htmlWrite.WriteLine(strHTML.ToString());

                        //Send Mail
                        SendMail("Lease/Rental Agreement Detail Report", "LeaseRentalAgreementDetail.xls", strFirstName, strLastName, strMailFrom, stringWrite, dtRecipients);


                    }
                }
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("ERROR in Lease/Rental Agreement Detail Report, " + ex.Message);
            }
        }

        //Report 26
        private void BindPurchaseAssetReport(DataRow drReportSchedule)
        {
            try
            {
                decimal pK_Schedule_ID = Convert.ToDecimal(drReportSchedule["PK_Schedule"]);
                decimal Fk_RecipientList = Convert.ToDecimal(drReportSchedule["Fk_RecipientList"]);
                decimal FK_Security_Id = Convert.ToDecimal(drReportSchedule["FK_Security_Id"]);

                //Get Report criteria for the scheduled report
                DataTable dtFilter = Report.SelectFilterCriteria(26, pK_Schedule_ID).Tables[0];
                if (dtFilter.Rows.Count > 0)
                {
                    //Get the recipient from the recipient list
                    DataTable dtRecipients = Report.SelectOneRecordWithRecipientList(Fk_RecipientList).Tables[0];

                    //Get the user who has scheduled the report
                    DataTable dtUser = Report.SelectSecurityByPK(FK_Security_Id).Tables[0];

                    String strFirstName, strLastName, strMailFrom;
                    strFirstName = strLastName = strMailFrom = "";
                    if (dtUser.Rows.Count > 0)
                    {
                        strFirstName = dtUser.Rows[0]["FIRST_NAME"].ToString();
                        strLastName = dtUser.Rows[0]["LAST_NAME"].ToString();
                        strMailFrom = dtUser.Rows[0]["Email"].ToString();

                        // get Region
                        string strRegion = dtFilter.Rows[0]["Region"].ToString();
                        string strMarket = null;
                        if (!string.IsNullOrEmpty(Convert.ToString(dtFilter.Rows[0]["Market"])))
                        {
                            strMarket = Convert.ToString(dtFilter.Rows[0]["Market"]).Trim();
                        }
                        string strManufacturer = dtFilter.Rows[0]["Manufacutrer"].ToString();
                        string strLocation = dtFilter.Rows[0]["Location"].ToString();
                        string strType = dtFilter.Rows[0]["Type"].ToString();

                        // get result records from database for the report
                        DataSet dsReport = Report.Get_Purchase_Report(strRegion, strMarket, strManufacturer, strType, strLocation);

                        //Create HTML for the report and wirte into HTML Write object
                        StringBuilder strHTML = new StringBuilder();
                        System.IO.StringWriter stringWrite = new System.IO.StringWriter();
                        System.Web.UI.HtmlTextWriter htmlWrite = new System.Web.UI.HtmlTextWriter(stringWrite);

                        string strLocationString = string.Empty;
                        string[] strLoc = strLocation.Split(Convert.ToChar(","));
                        for (int i = 0; i < strLoc.Length - 1; i++)
                        {
                            strLocationString += Report.SelectLocationInfoById(Convert.ToDecimal(strLoc[i].ToString().TrimStart(Convert.ToChar("'")).TrimEnd(Convert.ToChar("'")))).Tables[0].Rows[0]["dba"].ToString() + ",";
                        }

                        string strManuFac = string.Empty;
                        string[] strManu = strManufacturer.Split(Convert.ToChar(","));
                        for (int j = 0; j < strManu.Length - 1; j++)
                        {
                            strManuFac += Report.SelectManufacturerByPK(Convert.ToDecimal(strManu[j].ToString().TrimStart(Convert.ToChar("'")).TrimEnd(Convert.ToChar("'")))).Tables[0].Rows[0]["Fld_Desc"].ToString() + ",";
                        }

                        #region "Header"

                        //Retrieve Market Values
                        string strMarketString = string.Empty;
                        if (string.IsNullOrEmpty(strMarket))
                        {
                            strMarketString = "All Market";
                        }
                        else
                        {
                            string[] strMar = strMarket.Split(Convert.ToChar(","));
                            for (int i = 0; i < strMar.Length; i++)
                            {
                                strMarketString += Report.SelectMarketInfoById(Convert.ToDecimal(strMar[i].ToString())).Tables[0].Rows[0]["Market"].ToString() + ",";
                            }
                            strMarketString = strMarketString.TrimEnd(',');
                        }


                        //Add Report Title and Schedule Date
                        strHTML.Append("<span style=\"font-family:Calibri;\">");
                        strHTML.Append("<br />");
                        strHTML.Append("<b>Report Title : Purchasing Asset Report</b>");
                        strHTML.Append("<br /><br />");
                        strHTML.Append("Schedule Date : " + Convert.ToDateTime(drReportSchedule["Scheduled_Date"]).ToString(DateDisplayFormat));
                        strHTML.Append("&nbsp;&nbsp;&nbsp;&nbsp;Schedule End Date : " + Convert.ToDateTime(drReportSchedule["Schedule_End_Date"]).ToString(DateDisplayFormat));
                        strHTML.Append("<br /><br />");
                        strHTML.Append("Recurring Period : " + drReportSchedule["Recurring_Period"]).ToString();
                        strHTML.Append("<br />");
                        strHTML.Append("Recurring Date : " + dtSchduleDate.ToString(DateDisplayFormat));

                        //Add Report Filter Criteria 
                        strHTML.Append("<br /><br />");
                        strHTML.Append("<b>Report Filters </b>");
                        strHTML.Append("<br /><br />");
                        strHTML.Append("Regions              : " + strRegion.TrimStart(Convert.ToChar(",")).Replace("'", ""));
                        strHTML.Append("<br /><br />");                        
                        strHTML.Append("Market        : " + strMarketString);
                        strHTML.Append("<br /><br />");
                        strHTML.Append("Location          : " + strLocationString);
                        strHTML.Append("<br />");
                        strHTML.Append("<br />");
                        strHTML.Append("Type          : " + strType.TrimStart(Convert.ToChar(",")).Replace("'", ""));
                        strHTML.Append("<br />");
                        strHTML.Append("<br />");
                        strHTML.Append("Manufacturer          : " + strManuFac);
                        strHTML.Append("<br /><br />");
                        strHTML.Append("</span>");

                        //Add Header HTML
                        strHTML.Append("<table cellpadding='4' cellspacing='0' style='font-weight: bold;font-family:Calibri;' width='100%' border='1'>");
                        //strHTML.Append("<tr>");
                        //strHTML.Append("<td colspan='10' align='center'>Sonic Automotive WC Loss Allocation Report (First Report Only)</td>");
                        //strHTML.Append("</tr>");
                        strHTML.Append("<tr>");
                        strHTML.Append("<td style='width: 10%;' align='left' valign='top'>Type</td>");
                        strHTML.Append("<td style='width: 8%;' align='left' valign='top'>Region</td>");
                        strHTML.Append("<td style='width: 8%;' align='left' valign='top'>Manufacturer</td>");
                        strHTML.Append("<td style='width: 8%;' align='left' valign='top'>Location</td>");
                        strHTML.Append("<td style='width: 10%;' align='left' valign='top'>Dealership Department</td>");
                        strHTML.Append("<td style='width: 8%;' align='left' valign='top'>Serial Number</td>");
                        strHTML.Append("<td style='width: 8%;' align='left' valign='top'>Model Number</td>");
                        strHTML.Append("<td style='width: 8%;' align='left' valign='top'>Acquisition Date</td>");
                        strHTML.Append("<td style='width: 8%;' align='right' valign='top'>Acquisition Cost</td>");
                        strHTML.Append("<td style='width: 8%;' align='right' valign='top'>Amortization Months Remaining</td>");
                        strHTML.Append("<td style='width: 8%;' align='left' valign='top'>Service Supplier</td>");
                        strHTML.Append("<td style='width: 8%;' align='left' valign='top'>Lease/Rental Supplier</td>");
                        strHTML.Append("</tr></table>");
                        #endregion

                        DataTable dtReportData = dsReport.Tables[0];
                        DataTable dtRegion = dsReport.Tables[1];
                        DataTable dtTotal = dsReport.Tables[2];
                        if (dtRegion.Rows.Count > 0)
                        {
                            //Add Report Data Table 
                            strHTML.Append("<table style='width: 100%;' border='1' align='left' cellpadding='4' cellspacing='0'>");
                            foreach (DataRow drRegion in dtRegion.Rows)
                            {
                                //strHTML.Append("<tr><td colspan='10' style='font-family:Calibri;'><b>Region : ");
                                //strHTML.Append(drRegion["Region"].ToString());
                                //strHTML.Append("</b></td></tr>");
                                strHTML.Append("<tr><td>");
                                strHTML.Append("<table style='width: 100%;font-family:Calibri;' border='1' align='left' cellpadding='4' cellspacing='0'>");
                                DataRow[] drDataByRegion = dtReportData.Select("Region='" + drRegion["Region"].ToString() + "'");
                                foreach (DataRow drData in drDataByRegion)
                                {
                                    strHTML.Append("<tr style='background-color:#FFFFFF;'>");
                                    strHTML.Append("<td style='width: 10%;' align='left' valign='top'>" + drData["Type"] + "</td>");
                                    strHTML.Append("<td style='width: 8%;' align='left' valign='top'>" + drData["Region"] + "</td>");
                                    strHTML.Append("<td style='width: 8%;' align='left' valign='top'>WC-" + drData["Manufacturer"] + "</td>");
                                    strHTML.Append("<td style='width: 8%;' align='left' valign='top'>" + drData["Location"] + "</td>");
                                    strHTML.Append("<td style='width: 10%;' align='left' valign='top'>" + drData["Dealership_Department"] + "</td>");
                                    strHTML.Append("<td style='width: 8%;' align='left' valign='top'>" + drData["Serial_Number"] + "</td>");
                                    strHTML.Append("<td style='width: 8%;' align='left' valign='top'>" + drData["Model_Number"] + "</td>");
                                    if (Convert.ToDateTime(drData["Acquisition_Date"]) != Convert.ToDateTime(System.Data.SqlTypes.SqlDateTime.MinValue.ToString()))
                                    {
                                        strHTML.Append("<td style='width: 8%;' align='left' valign='top'>" + Convert.ToDateTime(drData["Acquisition_Date"]).ToString(DateDisplayFormat) + "</td>");
                                    }
                                    else
                                    {
                                        strHTML.Append("<td style='width: 8%;' align='left' valign='top'>&nbsp;</td>");
                                    }
                                    strHTML.Append("<td style='width: 8%;' align='right' valign='top'>$ " + string.Format("{0:N2}", drData["Acquisition_Cost"]) + "</td>");
                                    strHTML.Append("<td style='width: 8%;' align='right' valign='top'>" + drData["AmortizationMonthsRemaining"] + "</td>");
                                    strHTML.Append("<td style='width: 8%;' align='left' valign='top'>" + drData["SCSupplier"] + "</td>");
                                    strHTML.Append("<td style='width: 8%;' align='left' valign='top'>" + drData["LRSupplier"] + "</td>");
                                    strHTML.Append("</tr>");
                                }
                                strHTML.Append("<tr style='background-color:#FFFFFF;'>");
                                strHTML.Append("<td style='width: 10%;' align='left' valign='top'><b>Total</b></td>");
                                strHTML.Append("<td style='width: 8%;' align='left' valign='top'><b>" + string.Format("{0:N0}", drRegion["Total"]) + "</b></td>");
                                strHTML.Append("<td style='width: 8%;' align='left' valign='top'>&nbsp;</td>");
                                strHTML.Append("<td style='width: 8%;' align='left' valign='top'>&nbsp;</td>");
                                strHTML.Append("<td style='width: 10%;' align='left' valign='top'>&nbsp;</td>");
                                strHTML.Append("<td style='width: 8%;' align='left' valign='top'>&nbsp;</td>");
                                strHTML.Append("<td style='width: 8%;' align='left' valign='top'>&nbsp;</td>");
                                strHTML.Append("<td style='width: 8%;' align='left' valign='top'>&nbsp;</td>");
                                strHTML.Append("<td style='width: 8%;' align='right' valign='top'><b>$ " + string.Format("{0:N2}", drRegion["Acquisition_Cost"]) + "</b></td>");
                                strHTML.Append("<td style='width: 8%;' align='right' valign='top'>&nbsp;</td>");
                                strHTML.Append("<td style='width: 8%;' align='left' valign='top'>&nbsp;</td>");
                                strHTML.Append("<td style='width: 8%;' align='left' valign='top'>&nbsp;</td>");
                                strHTML.Append("</tr>");
                                strHTML.Append("</table>");
                                strHTML.Append("</td></tr>");
                            }
                            strHTML.Append("<tr style='background-color:#507cd1;font-family:Calibri;color:White;'>");
                            strHTML.Append("<td style='width: 10%;' align='left' valign='top'><b>Grand Total</b></td>");
                            strHTML.Append("<td style='width: 8%;' align='left' valign='top'><b>" + string.Format("{0:N0}", dtTotal.Rows[0]["Total"]) + "</b></td>");
                            strHTML.Append("<td style='width: 8%;' align='left' valign='top'>&nbsp;</td>");
                            strHTML.Append("<td style='width: 8%;' align='left' valign='top'>&nbsp;</td>");
                            strHTML.Append("<td style='width: 10%;' align='left' valign='top'>&nbsp;</td>");
                            strHTML.Append("<td style='width: 8%;' align='left' valign='top'>&nbsp;</td>");
                            strHTML.Append("<td style='width: 8%;' align='left' valign='top'>&nbsp;</td>");
                            strHTML.Append("<td style='width: 8%;' align='left' valign='top'>&nbsp;</td>");
                            strHTML.Append("<td style='width: 8%;' align='right' valign='top'><b>$ " + string.Format("{0:N2}", dtTotal.Rows[0]["Acquisition_Cost"]) + "</b></td>");
                            strHTML.Append("<td style='width: 8%;' align='right' valign='top'>&nbsp;</td>");
                            strHTML.Append("<td style='width: 8%;' align='left' valign='top'>&nbsp;</td>");
                            strHTML.Append("<td style='width: 8%;' align='left' valign='top'>&nbsp;</td>");
                            strHTML.Append("</tr>");
                            strHTML.Append("</table>");
                            strHTML.Append("</td></tr>");
                            strHTML.Append("</table>");
                        }
                        else
                        {
                            //Add No record found line for year
                            strHTML.Append("<tr><td align='left' colspan='10'>No Record Found!</td></tr>");
                        }

                        //Write HTML in to HtmlWriter
                        htmlWrite.WriteLine(strHTML.ToString());

                        //Send Mail
                        SendMail("Purchase Asset Detail Report", "PurchaseAssetDetailReport.xls", strFirstName, strLastName, strMailFrom, stringWrite, dtRecipients);


                    }
                }
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("ERROR in Purchase Asset Detail Report, " + ex.Message);
            }
        }

        //Report 27
        private void BindLeaseDetailReport(DataRow drReportSchedule)
        {
            try
            {
                decimal pK_Schedule_ID = Convert.ToDecimal(drReportSchedule["PK_Schedule"]);
                decimal Fk_RecipientList = Convert.ToDecimal(drReportSchedule["Fk_RecipientList"]);
                decimal FK_Security_Id = Convert.ToDecimal(drReportSchedule["FK_Security_Id"]);

                //Get Report criteria for the scheduled report
                DataTable dtFilter = Report.SelectFilterCriteria(27, pK_Schedule_ID).Tables[0];
                if (dtFilter.Rows.Count > 0)
                {
                    //Get the recipient from the recipient list 
                    DataTable dtRecipients = Report.SelectOneRecordWithRecipientList(Fk_RecipientList).Tables[0];

                    //Get the user who has scheduled the report
                    DataTable dtUser = Report.SelectSecurityByPK(FK_Security_Id).Tables[0];

                    String strFirstName, strLastName, strMailFrom;
                    strFirstName = strLastName = strMailFrom = "";
                    if (dtUser.Rows.Count > 0)
                    {
                        strFirstName = Convert.ToString(dtUser.Rows[0]["FIRST_NAME"]).Trim();
                        strLastName = Convert.ToString(dtUser.Rows[0]["LAST_NAME"]).Trim();
                        strMailFrom = Convert.ToString(dtUser.Rows[0]["Email"]).Trim();

                        //Set all filters to a variable as per report type
                        DateTime? dtLCDFrom = null, dtLCDTo = null, dtLEDFrom = null, dtLEDTo = null;

                        string strRegion = Convert.ToString(dtFilter.Rows[0]["Region"]).Trim();
                        string strMarket = null;
                        if (!string.IsNullOrEmpty(Convert.ToString(dtFilter.Rows[0]["Market"])))
                        {
                            strMarket = Convert.ToString(dtFilter.Rows[0]["Market"]).Trim();
                        }
                        string strLeaseType = Convert.ToString(dtFilter.Rows[0]["LeaseType"]).Trim();


                        if (dtFilter.Rows[0]["LCDFrom_Date"] != null && dtFilter.Rows[0]["LCDFrom_Date"] != string.Empty && dtFilter.Rows[0]["LCDFrom_Date"] != DBNull.Value)
                            dtLCDFrom = Convert.ToDateTime(dtFilter.Rows[0]["LCDFrom_Date"]);

                        if (dtFilter.Rows[0]["LCDTo_Date"] != null && dtFilter.Rows[0]["LCDTo_Date"] != string.Empty && dtFilter.Rows[0]["LCDTo_Date"] != DBNull.Value)
                            dtLCDTo = Convert.ToDateTime(dtFilter.Rows[0]["LCDTo_Date"]);

                        if (dtFilter.Rows[0]["LEDFrom_Date"] != null && dtFilter.Rows[0]["LEDFrom_Date"] != string.Empty && dtFilter.Rows[0]["LEDFrom_Date"] != DBNull.Value)
                            dtLEDFrom = Convert.ToDateTime(dtFilter.Rows[0]["LEDFrom_Date"]);

                        if (dtFilter.Rows[0]["LEDTo_Date"] != null && dtFilter.Rows[0]["LEDTo_Date"] != string.Empty && dtFilter.Rows[0]["LEDTo_Date"] != DBNull.Value)
                            dtLEDTo = Convert.ToDateTime(dtFilter.Rows[0]["LEDTo_Date"]);


                        //Get the all Unique records for Selected group (default - last name -sort) by search criteria
                        DataSet dsGroup = Report.GetLeaseDetailReport(strRegion, strMarket, strLeaseType, dtLCDFrom, dtLCDTo, dtLEDFrom, dtLEDTo, "asc");

                        //Create HTML for the report and wirte into HTML Write object
                        StringBuilder lstLeaseType = new StringBuilder();
                        System.IO.StringWriter stringWrite = new System.IO.StringWriter();
                        System.Web.UI.HtmlTextWriter htmlWrite = new System.Web.UI.HtmlTextWriter(stringWrite);

                        #region "Search Criteria"

                        //Retrieve Market Values
                        string strMarketString = string.Empty;
                        if (string.IsNullOrEmpty(strMarket))
                        {
                            strMarketString = "All Market";
                        }
                        else
                        {
                            string[] strMar = strMarket.Split(Convert.ToChar(","));
                            for (int i = 0; i < strMar.Length; i++)
                            {
                                strMarketString += Report.SelectMarketInfoById(Convert.ToDecimal(strMar[i].ToString())).Tables[0].Rows[0]["Market"].ToString() + ",";
                            }
                            strMarketString = strMarketString.TrimEnd(',');
                        }

                        //Add Report Title and Schedule Date
                        lstLeaseType.Append("<br />");
                        lstLeaseType.Append("<b>Report Title : Lease Detail Report</b>");
                        lstLeaseType.Append("<br /><br />");
                        lstLeaseType.Append("Schedule Date : " + Convert.ToDateTime(drReportSchedule["Scheduled_Date"]).ToString(DateDisplayFormat));
                        lstLeaseType.Append("&nbsp;&nbsp;&nbsp;&nbsp;Schedule End Date : " + Convert.ToDateTime(drReportSchedule["Schedule_End_Date"]).ToString(DateDisplayFormat));
                        lstLeaseType.Append("<br />");
                        lstLeaseType.Append("Recurring Period : " + drReportSchedule["Recurring_Period"].ToString());
                        lstLeaseType.Append("<br />");
                        lstLeaseType.Append("Recurring Date : " + dtSchduleDate.ToString(DateDisplayFormat));

                        //Add Report Filter Criteria 
                        lstLeaseType.Append("<br /><br />");
                        lstLeaseType.Append("<b>Report Filters </b>");
                        lstLeaseType.Append("<br /><br />");
                        lstLeaseType.Append("Region        : " + strRegion.Replace("'", ""));
                        lstLeaseType.Append("<br />");
                        lstLeaseType.Append("Market        : " + strMarketString);
                        lstLeaseType.Append("<br /><br />");
                        lstLeaseType.Append("Lease Type    : " + Report.GetLeaseTypeList(strLeaseType));
                        lstLeaseType.Append("<br />");
                        lstLeaseType.Append("LCD From      : " + FormatDBNullDateToDisplay(dtLCDFrom));
                        lstLeaseType.Append("<br />");
                        lstLeaseType.Append("LCD To        : " + FormatDBNullDateToDisplay(dtLCDTo));
                        lstLeaseType.Append("<br />");
                        lstLeaseType.Append("LED From      : " + FormatDBNullDateToDisplay(dtLEDFrom));
                        lstLeaseType.Append("<br />");
                        lstLeaseType.Append("LED To        : " + FormatDBNullDateToDisplay(dtLEDTo));
                        lstLeaseType.Append("<br /><br />");

                        #endregion

                        #region "Grid Data"

                        lstLeaseType.Append("<table cellspacing='0' cellpadding='0' align='Left' border='0' style='width: 2800px; border-collapse: collapse;'>");
                        //Header Row
                        lstLeaseType.Append("<tr align='left'><td align='left'>");
                        lstLeaseType.Append("<table width='2800px' cellpadding='0' cellspacing='0' border='0'>");
                        lstLeaseType.Append("<tr><td align='left'>");
                        lstLeaseType.Append("<table width='2800px' cellpadding='4' cellspacing='0' border='1' style='font-weight: bold;'>");
                        lstLeaseType.Append("<tr style='font-weight: bold;'>");
                        lstLeaseType.Append("<td align='left' colspan='6'>Sonic Automotive</td>");
                        lstLeaseType.Append("<td align='left' colspan='8'>Lease Detail Report</td>");
                        lstLeaseType.Append("<td align='right' colspan='2'>" + DateTime.Now.ToString() + " </td>");
                        lstLeaseType.Append("</tr>");

                        lstLeaseType.Append(" <tr style='font-weight: bold;'>");
                        lstLeaseType.Append("<td align='left' style='width: 120px'>Lease Code </td>");
                        lstLeaseType.Append("<td align='left' style='width: 150px'>Region </td>");
                        lstLeaseType.Append("<td align='left' style='width: 180px'>Location</td>");
                        lstLeaseType.Append("<td align='left' style='width: 180px'>Address</td>");
                        lstLeaseType.Append("<td align='left' style='width: 150px'>City</td>");
                        lstLeaseType.Append("<td align='left' style='width: 150px'>State</td>");
                        lstLeaseType.Append("<td align='left' style='width: 120px'>Zip</td>");
                        lstLeaseType.Append("<td align='left' style='width: 150px'>Primary Use</td>");
                        lstLeaseType.Append("<td align='right' style='width: 150px'>Rentable Area </td>");
                        lstLeaseType.Append("<td align='left' style='width: 150px'>Lease Type</td>");
                        lstLeaseType.Append("<td align='left' style='width: 180px'>Leasee</td>");
                        lstLeaseType.Append("<td align='left' style='width: 100px'>LCD</td>");
                        lstLeaseType.Append("<td align='left' style='width: 100px'>LED</td>");
                        lstLeaseType.Append("<td align='left' style='width:120px'>Lease Term</td>");
                        lstLeaseType.Append("<td align='left' style='width: 250px'>Renew Option</td>");
                        lstLeaseType.Append("<td align='left' style='width: 250px'>Cancel Option</td>");
                        lstLeaseType.Append(" </tr>");

                        lstLeaseType.Append("</table>");
                        lstLeaseType.Append("</td></tr>");
                        lstLeaseType.Append("</table>");
                        lstLeaseType.Append("</td></tr>");
                        if (dsGroup != null && dsGroup.Tables.Count > 0 && dsGroup.Tables[0].Rows.Count > 0)
                        {
                            //Data Row
                            foreach (DataRow drGroup in dsGroup.Tables[0].Rows)
                            {
                                strRegion = Convert.ToString(drGroup["Region"]);
                                //get the all Employee records by search criteria by group
                                DataSet dsDetails = Report.GetLeaseDetailReport_SubDetails(strRegion, strLeaseType, dtLCDFrom, dtLCDTo, dtLEDFrom, dtLEDTo, "asc");
                                if (dsDetails != null && dsDetails.Tables.Count > 0 && dsDetails.Tables[0].Rows.Count > 0)
                                {
                                    lstLeaseType.Append("<tr align='left'><td align='left'>");
                                    lstLeaseType.Append("<table width='2800px' cellpadding='0' cellspacing='0' border='0'>");
                                    lstLeaseType.Append("<tr><td align='left'>");
                                    lstLeaseType.Append("<table cellspacing='0' cellpadding='0' align='Left' border='1' style='width: 100%; border-collapse: collapse;'>");

                                    foreach (DataRow dr in dsDetails.Tables[0].Rows)
                                    {
                                        lstLeaseType.Append(" <tr>");
                                        lstLeaseType.Append("<td align='left' style='width: 120px'>" + Convert.ToString(dr["Lease_Codes"]) + "</td>");
                                        lstLeaseType.Append("<td align='left' style='width: 150px'>" + Convert.ToString(dr["Region"]) + " </td>");
                                        lstLeaseType.Append("<td align='left' style='width: 180px'>" + Convert.ToString(dr["Location"]) + "</td>");
                                        lstLeaseType.Append("<td align='left' style='width: 180px'>" + Convert.ToString(dr["Address"]) + "</td>");
                                        lstLeaseType.Append("<td align='left' style='width: 150px'>" + Convert.ToString(dr["City"]) + "</td>");
                                        lstLeaseType.Append("<td align='left' style='width: 150px'>" + Convert.ToString(dr["State"]) + "</td>");
                                        lstLeaseType.Append("<td align='left' style='width: 120px'>" + Convert.ToString(dr["Zip_Code"]) + "</td>");
                                        lstLeaseType.Append("<td align='left' style='width: 150px'>" + Convert.ToString(dr["PrimaryUse"]) + "</td>");
                                        lstLeaseType.Append("<td align='right' style='width: 150px'>" + string.Format("{0:N0}", Convert.ToString(dr["Total_Gross_Leaseable_Area"])) + "</td>");
                                        lstLeaseType.Append("<td align='left' style='width: 150px'>" + Convert.ToString(dr["Lease_Type"]) + "</td>");
                                        lstLeaseType.Append("<td align='left' style='width: 180px'>" + Convert.ToString(dr["Landlord"]) + "</td>");
                                        lstLeaseType.Append("<td align='left' style='width: 100px'>" + FormatDBNullDateToDisplay(dr["Lease_Commencement_Date"]) + "</td>");
                                        lstLeaseType.Append("<td align='left' style='width: 100px'>" + FormatDBNullDateToDisplay(dr["Lease_Expiration_Date"]) + "</td>");
                                        lstLeaseType.Append("<td align='left' style='width: 120px'>" + Convert.ToString(dr["Lease_Term_Months"]) + "</td>");
                                        lstLeaseType.Append("<td align='left' style='width: 250px'>" + Convert.ToString(dr["Renew_Options"]) + "</td>");
                                        lstLeaseType.Append("<td align='left' style='width: 250px'>" + Convert.ToString(dr["Cancel_Options"]) + "</td>");

                                        lstLeaseType.Append(" </tr>");
                                    }
                                    lstLeaseType.Append(" <tr style='font-weight: bold;'>");
                                    lstLeaseType.Append("<td align='left' style='width: 120px'>Total:</td>");
                                    lstLeaseType.Append("<td align='left' style='width: 150px'>" + Convert.ToString(dsDetails.Tables[1].Rows[0][0]) + " </td>");
                                    lstLeaseType.Append("<td align='left' style='width: 180px'>&nbsp;</td>");
                                    lstLeaseType.Append("<td align='left' style='width: 180px'>&nbsp;</td>");
                                    lstLeaseType.Append("<td align='left' style='width: 150px'>&nbsp;</td>");
                                    lstLeaseType.Append("<td align='left' style='width: 150px'>&nbsp;</td>");
                                    lstLeaseType.Append("<td align='left' style='width: 120px'>&nbsp;</td>");
                                    lstLeaseType.Append("<td align='left' style='width: 150px'>&nbsp;</td>");
                                    lstLeaseType.Append("<td align='right' style='width: 150px'>" + string.Format("{0:N0}", Convert.ToString(dsDetails.Tables[2].Rows[0][0])) + "</td>");
                                    lstLeaseType.Append("<td align='left' style='width: 150px'>&nbsp;</td>");
                                    lstLeaseType.Append("<td align='left' style='width: 180px'>&nbsp;</td>");
                                    lstLeaseType.Append("<td align='left' style='width: 100px'>&nbsp;</td>");
                                    lstLeaseType.Append("<td align='left' style='width: 100px'>&nbsp;</td>");
                                    lstLeaseType.Append("<td align='left' style='width: 120px'>&nbsp;</td>");
                                    lstLeaseType.Append("<td align='left' style='width: 250px'>&nbsp;</td>");
                                    lstLeaseType.Append("<td align='left' style='width: 250px'>&nbsp;</td>");
                                    lstLeaseType.Append(" </tr>");

                                    lstLeaseType.Append("</table>");
                                    lstLeaseType.Append("</td></tr>");
                                    lstLeaseType.Append("</table>");
                                    lstLeaseType.Append("</td></tr>");
                                }
                            }
                            //Footer Row
                            lstLeaseType.Append("<tr align='left'><td align='left'>");
                            lstLeaseType.Append(" <table width='2500px' cellpadding='0' cellspacing='0' border='0'>");
                            lstLeaseType.Append("<tr><td align='left'>");
                            lstLeaseType.Append("<table width='2500px' cellpadding='4' cellspacing='0' border='1' style='font-weight: bold;background-color: #507CD1; color: White;'>");

                            lstLeaseType.Append(" <tr style='font-weight: bold;'>");
                            lstLeaseType.Append("<td align='left' style='width: 120px'>Grand Total : </td>");
                            lstLeaseType.Append("<td align='left' style='width: 150px'>" + Convert.ToString(dsGroup.Tables[1].Rows[0][0]) + "</td>");
                            lstLeaseType.Append("<td align='left' style='width: 180px'>&nbsp;</td>");
                            lstLeaseType.Append("<td align='left' style='width: 180px'>&nbsp;</td>");
                            lstLeaseType.Append("<td align='left' style='width: 150px'>&nbsp;</td>");
                            lstLeaseType.Append("<td align='left' style='width: 150px'>&nbsp;</td>");
                            lstLeaseType.Append("<td align='left' style='width: 120px'>&nbsp;</td>");
                            lstLeaseType.Append("<td align='left' style='width: 150px'>&nbsp;</td>");
                            lstLeaseType.Append("<td align='right' style='width: 150px'>" + string.Format("{0:N0}", Convert.ToString(dsGroup.Tables[2].Rows[0][0])) + " </td>");
                            lstLeaseType.Append("<td align='left' style='width: 150px'>&nbsp;</td>");
                            lstLeaseType.Append("<td align='left' style='width: 180px'>&nbsp;</td>");
                            lstLeaseType.Append("<td align='left' style='width: 100px'>&nbsp;</td>");
                            lstLeaseType.Append("<td align='left' style='width: 100px'>&nbsp;</td>");
                            lstLeaseType.Append("<td align='left' style='width: 120px'>&nbsp;</td>");
                            lstLeaseType.Append("<td align='left' style='width: 250px'>&nbsp;</td>");
                            lstLeaseType.Append("<td align='left' style='width: 250px'>&nbsp;</td>");
                            lstLeaseType.Append(" </tr>");

                            lstLeaseType.Append("</table>");
                            lstLeaseType.Append("</td></tr>");
                            lstLeaseType.Append("</table>");
                            lstLeaseType.Append("</td></tr>");
                        }
                        else
                        {
                            lstLeaseType.Append("<tr> <td style='font-weight: bold;'> No Record Found.");
                            lstLeaseType.Append("</td></tr>");
                        }
                        lstLeaseType.Append("</table>");
                        #endregion

                        //Write HTML in to HtmlWriter
                        htmlWrite.WriteLine(lstLeaseType.ToString());

                        //Send Mail
                        SendMail("Lease Details Report", "LeaseDetails.xls", strFirstName, strLastName, strMailFrom, stringWrite, dtRecipients);
                    }
                }
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("ERROR in Lease Detail Report, " + ex.Message + " - " + ex.StackTrace.ToString() + " - " + ex.Source.ToString());
            }
        }

        //Report 28
        private void BindRentProjectionsHistoryReport(DataRow drReportSchedule)
        {
            try
            {
                decimal pK_Schedule_ID = Convert.ToDecimal(drReportSchedule["PK_Schedule"]);
                decimal Fk_RecipientList = Convert.ToDecimal(drReportSchedule["Fk_RecipientList"]);
                decimal FK_Security_Id = Convert.ToDecimal(drReportSchedule["FK_Security_Id"]);

                //Get Report criteria for the scheduled report
                DataTable dtFilter = Report.SelectFilterCriteria(28, pK_Schedule_ID).Tables[0];
                if (dtFilter.Rows.Count > 0)
                {
                    //Get the recipient from the recipient list 
                    DataTable dtRecipients = Report.SelectOneRecordWithRecipientList(Fk_RecipientList).Tables[0];

                    //Get the user who has scheduled the report
                    DataTable dtUser = Report.SelectSecurityByPK(FK_Security_Id).Tables[0];

                    String strFirstName, strLastName, strMailFrom;
                    strFirstName = strLastName = strMailFrom = "";
                    if (dtUser.Rows.Count > 0)
                    {
                        strFirstName = Convert.ToString(dtUser.Rows[0]["FIRST_NAME"]).Trim();
                        strLastName = Convert.ToString(dtUser.Rows[0]["LAST_NAME"]).Trim();
                        strMailFrom = Convert.ToString(dtUser.Rows[0]["Email"]).Trim();

                        string strRegion = Convert.ToString(dtFilter.Rows[0]["Region"]).Trim();
                        string strLeaseType = Convert.ToString(dtFilter.Rows[0]["LeaseType"]).Trim();
                        string strEscalationType = Convert.ToString(dtFilter.Rows[0]["EscalationType"]).Trim();

                        Int16? RentYear_From = null, RentYear_To = null;

                        if (dtFilter.Rows[0]["RentYear_From"] != DBNull.Value)
                            RentYear_From = Convert.ToInt16(dtFilter.Rows[0]["RentYear_From"]);

                        if (dtFilter.Rows[0]["RentYear_To"] != DBNull.Value)
                            RentYear_To = Convert.ToInt16(dtFilter.Rows[0]["RentYear_To"]);

                        //Get the all Unique records for Selected group (default - last name -sort) by search criteria
                        DataSet dsResult = Report.GetRentProjectionsHistory(strRegion, strLeaseType, RentYear_From, RentYear_To, strEscalationType);

                        //Create HTML for the report and wirte into HTML Write object
                        StringBuilder strHTML = new StringBuilder();
                        System.IO.StringWriter stringWrite = new System.IO.StringWriter();
                        System.Web.UI.HtmlTextWriter htmlWrite = new System.Web.UI.HtmlTextWriter(stringWrite);

                        #region "Report Title"

                        //Add Report Title and Schedule Date
                        strHTML.Append("<br />");
                        strHTML.Append("<b>Report Title : Rent Projections/History</b>");
                        strHTML.Append("<br /><br />");
                        strHTML.Append("Schedule Date : " + Convert.ToDateTime(drReportSchedule["Scheduled_Date"]).ToString(DateDisplayFormat));
                        strHTML.Append("&nbsp;&nbsp;&nbsp;&nbsp;Schedule End Date : " + Convert.ToDateTime(drReportSchedule["Schedule_End_Date"]).ToString(DateDisplayFormat));
                        strHTML.Append("<br />");
                        strHTML.Append("Recurring Period : " + drReportSchedule["Recurring_Period"].ToString());
                        strHTML.Append("<br />");
                        strHTML.Append("Recurring Date : " + dtSchduleDate.ToString(DateDisplayFormat));

                        //Add Report Filter Criteria 
                        strHTML.Append("<br /><br /><table> <tr> <td>");
                        strHTML.Append("<b>Report Filters </b>");
                        strHTML.Append("<br /><table> <tr> <td colspan='8'>");
                        strHTML.Append("Location   : " + (string.IsNullOrEmpty(strRegion) ? "" : GetCommaValueFromTable(Report.getLocationByIds(strRegion).Tables[0], "DBA")));
                        strHTML.Append("</td> </tr> <tr> <td colspan='8'>");
                        strHTML.Append("Lease Type : " + Report.GetLeaseTypeList(strLeaseType));
                        strHTML.Append("</td></tr> <tr> <td colspan='8'>");
                        strHTML.Append("Escalation Type : " + Report.GetEscalationTypeList(strEscalationType));
                        strHTML.Append("</td></tr> <tr> <td>");
                        strHTML.Append("Lease Year From : " + (RentYear_From == null ? "" : RentYear_From.ToString()));
                        strHTML.Append("</td></tr> <tr> <td>");
                        strHTML.Append("Lease Year To : " + (RentYear_To == null ? "" : RentYear_To.ToString()));
                        strHTML.Append("</td></tr></table> ");
                        strHTML.Append("<br /><br />");

                        #endregion

                        #region "Report Grid header"

                        strHTML.Append("<table border='1'>");
                        strHTML.Append("<tr style='font-weight: bold' valign='bottom' align='left'>");
                        strHTML.Append("<td align='left' colspan='2'> Sonic Automotive </td>");
                        strHTML.Append("<td align='center' colspan='3'> Rent Projections/History </td>");
                        strHTML.Append("<td align='right' colspan='3'> " + DateTime.Now.ToString() + "</td></tr>");
                        strHTML.Append("<tr valign='bottom;' style='font-weight: bold' align='left'>");
                        strHTML.Append("<td> Location </td>");
                        strHTML.Append("<td> Year </td>");
                        strHTML.Append("<td> From </td>");
                        strHTML.Append("<td> To </td>");
                        strHTML.Append("<td align='right'> No. of Month </td>");
                        strHTML.Append("<td align='right'> Annual Rent </td>");
                        strHTML.Append("<td align='right'> CPI Rate </td>");
                        strHTML.Append("<td align='right'> Total Rent </td>");
                        strHTML.Append("</tr>");


                        if (dsResult.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow drReport in dsResult.Tables[0].Rows)
                            {
                                strHTML.Append("<tr valign='bottom' align='left'>");
                                strHTML.Append("<td> " + Convert.ToString(drReport["DBA"]) + " </td>");
                                strHTML.Append("<td> " + (drReport["Year"] != DBNull.Value ? drReport["Year"].ToString() : "") + " </td>");
                                strHTML.Append("<td> " + FormatDBNullDateToDisplay(drReport["From_Date"]) + " </td>");
                                strHTML.Append("<td> " + FormatDBNullDateToDisplay(drReport["To_Date"]) + " </td>");
                                strHTML.Append("<td align='right'> " + string.Format("{0:N2}", drReport["Months"]) + " </td>");
                                strHTML.Append("<td align='right'> " + string.Format("{0:C2}", drReport["Monthly_Rent"]) + " </td>");
                                strHTML.Append("<td align='right'> " + string.Format("{0:N2}", drReport["Percentage_Rate"]) + " </td>");
                                strHTML.Append("<td align='right'> " + string.Format("{0:C2}", drReport["Total_Rent"]) + " </td>");
                                strHTML.Append("</tr>");
                            }
                        }
                        else
                        {
                            //Add No record found line for year
                            strHTML.Append("<tr><td align='left' colspan='8'>No Record Found!</td></tr>");
                        }
                        strHTML.Append("</table>");
                        #endregion

                        //Write HTML in to HtmlWriter
                        htmlWrite.WriteLine(strHTML.ToString());

                        //Send Mail
                        SendMail("Rent Projections/History Report", "RentProjectionsHistoryReport.xls", strFirstName, strLastName, strMailFrom, stringWrite, dtRecipients);
                    }
                }
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("ERROR in Rent Projections/History Report, " + ex.Message + " - " + ex.StackTrace.ToString() + " - " + ex.Source.ToString());
            }
        }

        // Report 29
        private void BindLeaseTerm(DataRow drReportSchedule)
        {
            try
            {
                decimal pK_Schedule_ID = Convert.ToDecimal(drReportSchedule["PK_Schedule"]);
                decimal Fk_RecipientList = Convert.ToDecimal(drReportSchedule["Fk_RecipientList"]);
                decimal FK_Security_Id = Convert.ToDecimal(drReportSchedule["FK_Security_Id"]);

                //Get Report criteria for the scheduled report
                DataTable dtFilter = Report.SelectFilterCriteria(29, pK_Schedule_ID).Tables[0];
                if (dtFilter.Rows.Count > 0)
                {
                    //Get the recipient from the recipient list 
                    DataTable dtRecipients = Report.SelectOneRecordWithRecipientList(Fk_RecipientList).Tables[0];

                    //Get the user who has scheduled the report
                    DataTable dtUser = Report.SelectSecurityByPK(FK_Security_Id).Tables[0];

                    String strFirstName, strLastName, strMailFrom;
                    strFirstName = strLastName = strMailFrom = "";
                    if (dtUser.Rows.Count > 0)
                    {
                        strFirstName = Convert.ToString(dtUser.Rows[0]["FIRST_NAME"]).Trim();
                        strLastName = Convert.ToString(dtUser.Rows[0]["LAST_NAME"]).Trim();
                        strMailFrom = Convert.ToString(dtUser.Rows[0]["Email"]).Trim();

                        //Set all filters to a variable as per report type
                        DateTime? dtLCDFrom = null, dtLCDTo = null, dtLEDFrom = null, dtLEDTo = null;

                        string strRegion = Convert.ToString(dtFilter.Rows[0]["Region"]).Trim();
                        string strMarket = null;
                        if (!string.IsNullOrEmpty(Convert.ToString(dtFilter.Rows[0]["Market"])))
                        {
                            strMarket = Convert.ToString(dtFilter.Rows[0]["Market"]).Trim();
                        }
                        string strLeaseType = Convert.ToString(dtFilter.Rows[0]["LeaseType"]).Trim();

                        if (dtFilter.Rows[0]["LCDFrom_Date"] != DBNull.Value)
                            dtLCDFrom = Convert.ToDateTime(dtFilter.Rows[0]["LCDFrom_Date"]);

                        if (Convert.ToString(dtFilter.Rows[0]["LCDTo_Date"]) != string.Empty && dtFilter.Rows[0]["LCDTo_Date"] != DBNull.Value)
                            dtLCDTo = Convert.ToDateTime(dtFilter.Rows[0]["LCDTo_Date"]);

                        if (Convert.ToString(dtFilter.Rows[0]["LEDFrom_Date"]) != string.Empty && dtFilter.Rows[0]["LEDFrom_Date"] != DBNull.Value)
                            dtLEDFrom = Convert.ToDateTime(dtFilter.Rows[0]["LEDFrom_Date"]);

                        if (Convert.ToString(dtFilter.Rows[0]["LEDTo_Date"]) != string.Empty && dtFilter.Rows[0]["LEDTo_Date"] != DBNull.Value)
                            dtLEDTo = Convert.ToDateTime(dtFilter.Rows[0]["LEDTo_Date"]);

                        //Get the all Unique records for Selected group (default - last name -sort) by search criteria
                        DataSet dsResult = Report.GetLeaseTermReport(strRegion, strMarket, strLeaseType, dtLCDFrom, dtLCDTo, dtLEDFrom, dtLEDTo);

                        //Create HTML for the report and wirte into HTML Write object
                        StringBuilder strHTML = new StringBuilder();
                        System.IO.StringWriter stringWrite = new System.IO.StringWriter();
                        System.Web.UI.HtmlTextWriter htmlWrite = new System.Web.UI.HtmlTextWriter(stringWrite);

                        #region "Search Criteria"

                        //Retrieve Market Values
                        string strMarketString = string.Empty;
                        if (string.IsNullOrEmpty(strMarket))
                        {
                            strMarketString = "All Market";
                        }
                        else
                        {
                            string[] strMar = strMarket.Split(Convert.ToChar(","));
                            for (int i = 0; i < strMar.Length; i++)
                            {
                                strMarketString += Report.SelectMarketInfoById(Convert.ToDecimal(strMar[i].ToString())).Tables[0].Rows[0]["Market"].ToString() + ",";
                            }
                            strMarketString = strMarketString.TrimEnd(',');
                        }

                        //Add Report Title and Schedule Date
                        strHTML.Append("<br />");
                        strHTML.Append("<b>Report Title : Lease Term Report</b>");
                        strHTML.Append("<br /><br />");
                        strHTML.Append("Schedule Date : " + Convert.ToDateTime(drReportSchedule["Scheduled_Date"]).ToString(DateDisplayFormat));
                        strHTML.Append("&nbsp;&nbsp;&nbsp;&nbsp;Schedule End Date : " + Convert.ToDateTime(drReportSchedule["Schedule_End_Date"]).ToString(DateDisplayFormat));
                        strHTML.Append("<br />");
                        strHTML.Append("Recurring Period : " + drReportSchedule["Recurring_Period"].ToString());
                        strHTML.Append("<br />");
                        strHTML.Append("Recurring Date : " + dtSchduleDate.ToString(DateDisplayFormat));

                        //Add Report Filter Criteria 
                        strHTML.Append("<br /><br />");
                        strHTML.Append("<b>Report Filters </b>");
                        strHTML.Append("<br /><br />");
                        strHTML.Append("Region        : " + strRegion.Replace("'", ""));
                        strHTML.Append("<br />");
                        strHTML.Append("Market        : " + strMarketString);
                        strHTML.Append("<br /><br />");
                        strHTML.Append("Lease Type    : " + Report.GetLeaseTypeList(strLeaseType));
                        strHTML.Append("<br />");
                        strHTML.Append("LCD From      : " + FormatDBNullDateToDisplay(dtLCDFrom));
                        strHTML.Append("<br />");
                        strHTML.Append("LCD To        : " + FormatDBNullDateToDisplay(dtLCDTo));
                        strHTML.Append("<br />");
                        strHTML.Append("LED From      : " + FormatDBNullDateToDisplay(dtLEDFrom));
                        strHTML.Append("<br />");
                        strHTML.Append("LED To        : " + FormatDBNullDateToDisplay(dtLEDTo));
                        strHTML.Append("<br /><br />");

                        #endregion

                        #region "Report Grid header"

                        strHTML.Append("<table border='1'>");
                        strHTML.Append("<tr style='font-weight: bold' valign='bottom' align='left'>");
                        strHTML.Append("<td align='left' colspan='3'>Sonic Automotive</td>");
                        strHTML.Append("<td align='center' colspan='5'>Lease Term</td>");
                        strHTML.Append("<td align='right' colspan='2'> " + DateTime.Now.ToString() + " </td>");
                        strHTML.Append("</tr>");
                        strHTML.Append("<tr valign='bottom' align='left' style='font-weight: bold'>");
                        strHTML.Append("<td>LL Notify Date</td>");
                        strHTML.Append("<td>Location</td>");
                        strHTML.Append("<td>Region</td>");
                        strHTML.Append("<td>Lease Type</td>");
                        strHTML.Append("<td align='right'>Rentable Area</td>");
                        strHTML.Append("<td>LCD</td>");
                        strHTML.Append("<td>Prior Lease Commencement Date</td>");
                        strHTML.Append("<td>LED</td>");
                        strHTML.Append("<td align='center'>Lease Term</td>");
                        strHTML.Append("<td>Renew/ Cancel Option</td>");
                        strHTML.Append("</tr>");

                        if (dsResult.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow drReport in dsResult.Tables[0].Rows)
                            {
                                strHTML.Append("<tr valign='top' align='left'>");
                                strHTML.Append("<td> " + FormatDBNullDateToDisplay(drReport["Landlord_Notification_Date"]) + " </td>");
                                strHTML.Append("<td> " + Convert.ToString(drReport["DBA"]) + " </td>");
                                strHTML.Append("<td> " + Convert.ToString(drReport["Region"]) + " </td>");
                                strHTML.Append("<td> " + Convert.ToString(drReport["LU_Lease_Type"]) + " </td>");
                                strHTML.Append("<td align='right'> " + string.Format("{0:N0}", drReport["Total_Gross_Leaseable_Area"]) + " </td>");
                                strHTML.Append("<td> " + FormatDBNullDateToDisplay(drReport["Lease_Commencement_Date"]) + " </td>");
                                strHTML.Append("<td> " + FormatDBNullDateToDisplay(drReport["Prior_Lease_Commencement_Date"]) + " </td>");
                                strHTML.Append("<td> " + FormatDBNullDateToDisplay(drReport["Lease_Expiration_Date"]) + " </td>");
                                strHTML.Append("<td align='right'> " + string.Format("{0:N0}", drReport["Lease_Term_Months"]) + " </td>");
                                strHTML.Append("<td align='left'> " + Convert.ToString("<b>Cancel Options</b> " + drReport["Cancel_Options"] + "<br style='mso-data-placement:same-cell;'>" + "<b>Renew Options</b> " + drReport["Renew_Options"]) + " </td>");
                                strHTML.Append("</tr>");
                            }

                            strHTML.Append("<tr valign='top' align='left' style='font-weight: bold; background-color: #507CD1;color: White;'>");
                            strHTML.Append("<td> Grand Total </td>");
                            strHTML.Append("<td>" + dsResult.Tables[0].Rows.Count.ToString() + "</td><td></td><td></td>");
                            strHTML.Append("<td align='right'> " + string.Format("{0:N0}", dsResult.Tables[0].Compute("SUM(Total_Gross_Leaseable_Area)", "")) + " </td>");
                            strHTML.Append("<td> </td><td> </td><td> </td>");
                            strHTML.Append("<td> </td>");
                            strHTML.Append("<td </td>");
                            strHTML.Append("</tr>");
                        }
                        else
                        {
                            //Add No record found line for year
                            strHTML.Append("<tr><td align='left' colspan='10'>No Record Found!</td></tr>");
                        }
                        strHTML.Append("</table>");
                        #endregion

                        //Write HTML in to HtmlWriter
                        htmlWrite.WriteLine(strHTML.ToString());

                        //Send Mail
                        SendMail("Lease Term Report", "LeaseTermReport.xls", strFirstName, strLastName, strMailFrom, stringWrite, dtRecipients);
                    }
                }
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("ERROR in Lease Term Report, " + ex.Message + " - " + ex.StackTrace.ToString() + " - " + ex.Source.ToString());
            }
        }

        // Report 30
        private void BindSubspacesByLocation(DataRow drReportSchedule)
        {
            try
            {
                decimal pK_Schedule_ID = Convert.ToDecimal(drReportSchedule["PK_Schedule"]);
                decimal Fk_RecipientList = Convert.ToDecimal(drReportSchedule["Fk_RecipientList"]);
                decimal FK_Security_Id = Convert.ToDecimal(drReportSchedule["FK_Security_Id"]);

                //Get Report criteria for the scheduled report
                DataTable dtFilter = Report.SelectFilterCriteria(30, pK_Schedule_ID).Tables[0];
                if (dtFilter.Rows.Count > 0)
                {
                    //Get the recipient from the recipient list 
                    DataTable dtRecipients = Report.SelectOneRecordWithRecipientList(Fk_RecipientList).Tables[0];

                    //Get the user who has scheduled the report
                    DataTable dtUser = Report.SelectSecurityByPK(FK_Security_Id).Tables[0];

                    String strFirstName, strLastName, strMailFrom;
                    strFirstName = strLastName = strMailFrom = "";
                    if (dtUser.Rows.Count > 0)
                    {
                        strFirstName = Convert.ToString(dtUser.Rows[0]["FIRST_NAME"]).Trim();
                        strLastName = Convert.ToString(dtUser.Rows[0]["LAST_NAME"]).Trim();
                        strMailFrom = Convert.ToString(dtUser.Rows[0]["Email"]).Trim();

                        //Set all filters to a variable as per report type
                        DateTime? dtLCDFrom = null, dtLCDTo = null, dtLEDFrom = null, dtLEDTo = null;

                        string strRegion = Convert.ToString(dtFilter.Rows[0]["Region"]).Trim();
                        string strMarket = null;
                        if (!string.IsNullOrEmpty(Convert.ToString(dtFilter.Rows[0]["Market"])))
                        {
                            strMarket = Convert.ToString(dtFilter.Rows[0]["Market"]).Trim();
                        }
                        string strLeaseType = Convert.ToString(dtFilter.Rows[0]["LeaseType"]).Trim();

                        if (dtFilter.Rows[0]["LCDFrom_Date"] != DBNull.Value)
                            dtLCDFrom = Convert.ToDateTime(dtFilter.Rows[0]["LCDFrom_Date"]);

                        if (Convert.ToString(dtFilter.Rows[0]["LCDTo_Date"]) != string.Empty && dtFilter.Rows[0]["LCDTo_Date"] != DBNull.Value)
                            dtLCDTo = Convert.ToDateTime(dtFilter.Rows[0]["LCDTo_Date"]);

                        if (Convert.ToString(dtFilter.Rows[0]["LEDFrom_Date"]) != string.Empty && dtFilter.Rows[0]["LEDFrom_Date"] != DBNull.Value)
                            dtLEDFrom = Convert.ToDateTime(dtFilter.Rows[0]["LEDFrom_Date"]);

                        if (Convert.ToString(dtFilter.Rows[0]["LEDTo_Date"]) != string.Empty && dtFilter.Rows[0]["LEDTo_Date"] != DBNull.Value)
                            dtLEDTo = Convert.ToDateTime(dtFilter.Rows[0]["LEDTo_Date"]);

                        //Get the all Unique records for Selected group (default - last name -sort) by search criteria
                        DataSet dsResult = Report.GetSubspacesByLocation(strRegion, strMarket, strLeaseType, dtLCDFrom, dtLCDTo, dtLEDFrom, dtLEDTo);

                        //Create HTML for the report and wirte into HTML Write object
                        StringBuilder strHTML = new StringBuilder();
                        System.IO.StringWriter stringWrite = new System.IO.StringWriter();
                        System.Web.UI.HtmlTextWriter htmlWrite = new System.Web.UI.HtmlTextWriter(stringWrite);

                        #region "Report Criteria"

                        //Retrieve Market Values
                        string strMarketString = string.Empty;
                        if (string.IsNullOrEmpty(strMarket))
                        {
                            strMarketString = "All Market";
                        }
                        else
                        {
                            string[] strMar = strMarket.Split(Convert.ToChar(","));
                            for (int i = 0; i < strMar.Length; i++)
                            {
                                strMarketString += Report.SelectMarketInfoById(Convert.ToDecimal(strMar[i].ToString())).Tables[0].Rows[0]["Market"].ToString() + ",";
                            }
                            strMarketString = strMarketString.TrimEnd(',');
                        }

                        //Add Report Title and Schedule Date
                        strHTML.Append("<br />");
                        strHTML.Append("<b>Report Title : Subspaces By Location </b>");
                        strHTML.Append("<br /><br />");
                        strHTML.Append("Schedule Date : " + Convert.ToDateTime(drReportSchedule["Scheduled_Date"]).ToString(DateDisplayFormat));
                        strHTML.Append("&nbsp;&nbsp;&nbsp;&nbsp;Schedule End Date : " + Convert.ToDateTime(drReportSchedule["Schedule_End_Date"]).ToString(DateDisplayFormat));
                        strHTML.Append("<br />");
                        strHTML.Append("Recurring Period : " + drReportSchedule["Recurring_Period"].ToString());
                        strHTML.Append("<br />");
                        strHTML.Append("Recurring Date : " + dtSchduleDate.ToString(DateDisplayFormat));

                        //Add Report Filter Criteria 
                        strHTML.Append("<br /><br />");
                        strHTML.Append("<b>Report Filters </b>");
                        strHTML.Append("<br /><br />");
                        strHTML.Append("Region        : " + strRegion.Replace("'", ""));
                        strHTML.Append("<br />");
                        strHTML.Append("Market        : " + strMarketString);
                        strHTML.Append("<br /><br />");
                        strHTML.Append("Lease Type    : " + Report.GetLeaseTypeList(strLeaseType));
                        strHTML.Append("<br />");
                        strHTML.Append("LCD From      : " + FormatDBNullDateToDisplay(dtLCDFrom));
                        strHTML.Append("<br />");
                        strHTML.Append("LCD To        : " + FormatDBNullDateToDisplay(dtLCDTo));
                        strHTML.Append("<br />");
                        strHTML.Append("LED From      : " + FormatDBNullDateToDisplay(dtLEDFrom));
                        strHTML.Append("<br />");
                        strHTML.Append("LED To        : " + FormatDBNullDateToDisplay(dtLEDTo));
                        strHTML.Append("<br /><br />");

                        #endregion

                        #region "Report Grid header"

                        strHTML.Append("<table border='1'>");
                        strHTML.Append("<tr style='font-weight: bold' valign='bottom' align='left'>");
                        strHTML.Append("<td align='left' colspan='3'>Sonic Automotive</td>");
                        strHTML.Append("<td align='center' colspan='4'>Subspaces By Location </td>");
                        strHTML.Append("<td align='right' colspan='3'>" + DateTime.Now.ToString() + "</td>");
                        strHTML.Append("</tr>");
                        strHTML.Append("<tr valign='bottom' align='left' style='font-weight: bold'>");
                        strHTML.Append("<td>Region </td>");
                        strHTML.Append("<td>Lease Type</td>");
                        strHTML.Append("<td align='right'>Rentable Area</td>");
                        strHTML.Append("<td>Subtenant DBA</td>");
                        strHTML.Append("<td>LED </td>");
                        strHTML.Append("<td>Prior Lease Commencement Date</td>");
                        strHTML.Append("<td>LCD</td>");
                        strHTML.Append("<td align='center'>Subspaces Term</td>");
                        strHTML.Append("<td>Renew/ Cancel Option</td>");
                        strHTML.Append("<td>Landlord </td>");
                        strHTML.Append("</tr>");

                        // set Location Table 
                        DataTable dtLocation = dsResult.Tables[1];

                        // Check if record is exist for location
                        if (dtLocation.Rows.Count > 0)
                        {
                            // loop for all location
                            foreach (DataRow drLocation in dtLocation.Rows)
                            {
                                // filter Reprot Result by Locaion ID
                                DataTable dtReportDetail = dsResult.Tables[0];
                                dtReportDetail.DefaultView.RowFilter = " PK_LU_Location_Id = " + drLocation["PK_LU_Location_Id"].ToString();
                                dtReportDetail.DefaultView.Sort = "Region";
                                dtReportDetail = dtReportDetail.DefaultView.ToTable();

                                // display location for filter
                                strHTML.Append("<tr valign='top' align='left'>");
                                strHTML.Append("<td colspan='10' align-'left'><b> Location : " + Convert.ToString(drLocation["dba"]) + "</b></td>");
                                strHTML.Append("</tr>");

                                // print Report Detail
                                if (dtReportDetail.Rows.Count > 0)
                                {
                                    // display record for Location
                                    foreach (DataRow drReport in dtReportDetail.Rows)
                                    {
                                        strHTML.Append("<tr valign='top' align='left'>");
                                        strHTML.Append("<td> " + Convert.ToString(drReport["Region"]) + " </td>");
                                        strHTML.Append("<td> " + Convert.ToString(drReport["LU_Lease_Type"]) + " </td>");
                                        strHTML.Append("<td  align='right'> " + string.Format("{0:N0}", drReport["Total_Gross_Leaseable_Area"]) + " </td>");
                                        strHTML.Append("<td> " + Convert.ToString(drReport["Subtenant_DBA"]) + " </td>");
                                        strHTML.Append("<td> " + FormatDBNullDateToDisplay(drReport["Lease_Expiration_Date"]) + " </td>");
                                        strHTML.Append("<td> " + FormatDBNullDateToDisplay(drReport["Prior_Lease_Commencement_Date"]) + " </td>");
                                        strHTML.Append("<td> " + FormatDBNullDateToDisplay(drReport["Lease_Commencement_Date"]) + " </td>");
                                        strHTML.Append("<td align='right'> " + string.Format("{0:N0}", drReport["Lease_Term_Months"]) + " </td>");
                                        strHTML.Append("<td align='left'> " + Convert.ToString("<b>Cancel Options</b> " + drReport["Cancel_Options"] + "<br style='mso-data-placement:same-cell;'>" + "<b>Renew Options</b> " + drReport["Renew_Options"]) + " </td>");
                                        strHTML.Append("<td> " + Convert.ToString(drReport["Landlord"]) + " </td>");
                                        strHTML.Append("</tr>");
                                    }

                                    // print Sub Total by Location
                                    strHTML.Append("<tr valign='top' align='left' style='font-weight: bold;'>");
                                    strHTML.Append("<td> Sub Total </td>");
                                    strHTML.Append("<td>" + dtReportDetail.Rows.Count.ToString() + "</td>");
                                    strHTML.Append("<td align='right'> " + string.Format("{0:N0}", dtReportDetail.Compute("SUM(Total_Gross_Leaseable_Area)", "")) + " </td>");
                                    strHTML.Append("<td> <td> <td> <td> <td> <td><td></td>");
                                    strHTML.Append("</tr>");
                                }
                                else
                                {
                                    //Add No record found line for year
                                    strHTML.Append("<tr><td align='left' colspan='10'>No Record Found!</td></tr>");
                                }

                            }

                            // print Grand Total for Whole Report
                            strHTML.Append("<tr valign='top' align='left' style='font-weight: bold; background-color: #507CD1;color: White;'>");
                            strHTML.Append("<td> Grand Total </td>");
                            strHTML.Append("<td>" + dsResult.Tables[0].Rows.Count.ToString() + "</td>");
                            strHTML.Append("<td align='right'> " + string.Format("{0:N0}", dsResult.Tables[0].Compute("SUM(Total_Gross_Leaseable_Area)", "")) + " </td>");
                            strHTML.Append("<td> <td> <td> <td> <td> <td><td></td>");
                            strHTML.Append("</tr>");

                        }
                        strHTML.Append("</table>");
                        #endregion

                        //Write HTML in to HtmlWriter
                        htmlWrite.WriteLine(strHTML.ToString());

                        //Send Mail
                        SendMail("Subspaces By Location Report", "SubspacesByLocationReprot.xls", strFirstName, strLastName, strMailFrom, stringWrite, dtRecipients);
                    }
                }
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("ERROR in Subspaces By Location, " + ex.Message + " - " + ex.StackTrace.ToString() + " - " + ex.Source.ToString());
            }
        }

        // Report 31
        private void BindRentableAreaByExpirationDate(DataRow drReportSchedule)
        {
            try
            {
                decimal pK_Schedule_ID = Convert.ToDecimal(drReportSchedule["PK_Schedule"]);
                decimal Fk_RecipientList = Convert.ToDecimal(drReportSchedule["Fk_RecipientList"]);
                decimal FK_Security_Id = Convert.ToDecimal(drReportSchedule["FK_Security_Id"]);

                //Get Report criteria for the scheduled report
                DataTable dtFilter = Report.SelectFilterCriteria(31, pK_Schedule_ID).Tables[0];
                if (dtFilter.Rows.Count > 0)
                {
                    //Get the recipient from the recipient list 
                    DataTable dtRecipients = Report.SelectOneRecordWithRecipientList(Fk_RecipientList).Tables[0];

                    //Get the user who has scheduled the report
                    DataTable dtUser = Report.SelectSecurityByPK(FK_Security_Id).Tables[0];

                    String strFirstName, strLastName, strMailFrom;
                    strFirstName = strLastName = strMailFrom = "";
                    if (dtUser.Rows.Count > 0)
                    {
                        strFirstName = Convert.ToString(dtUser.Rows[0]["FIRST_NAME"]).Trim();
                        strLastName = Convert.ToString(dtUser.Rows[0]["LAST_NAME"]).Trim();
                        strMailFrom = Convert.ToString(dtUser.Rows[0]["Email"]).Trim();

                        //Set all filters to a variable as per report type
                        DateTime? dtLCDFrom = null, dtLCDTo = null, dtLEDFrom = null, dtLEDTo = null;

                        string strRegion = Convert.ToString(dtFilter.Rows[0]["Region"]).Trim();
                        string strMarket = null;
                        if (!string.IsNullOrEmpty(Convert.ToString(dtFilter.Rows[0]["Market"])))
                        {
                            strMarket = Convert.ToString(dtFilter.Rows[0]["Market"]).Trim();
                        }
                        string strLeaseType = Convert.ToString(dtFilter.Rows[0]["LeaseType"]).Trim();

                        if (dtFilter.Rows[0]["LCDFrom_Date"] != DBNull.Value)
                            dtLCDFrom = Convert.ToDateTime(dtFilter.Rows[0]["LCDFrom_Date"]);

                        if (Convert.ToString(dtFilter.Rows[0]["LCDTo_Date"]) != string.Empty && dtFilter.Rows[0]["LCDTo_Date"] != DBNull.Value)
                            dtLCDTo = Convert.ToDateTime(dtFilter.Rows[0]["LCDTo_Date"]);

                        if (Convert.ToString(dtFilter.Rows[0]["LEDFrom_Date"]) != string.Empty && dtFilter.Rows[0]["LEDFrom_Date"] != DBNull.Value)
                            dtLEDFrom = Convert.ToDateTime(dtFilter.Rows[0]["LEDFrom_Date"]);

                        if (Convert.ToString(dtFilter.Rows[0]["LEDTo_Date"]) != string.Empty && dtFilter.Rows[0]["LEDTo_Date"] != DBNull.Value)
                            dtLEDTo = Convert.ToDateTime(dtFilter.Rows[0]["LEDTo_Date"]);

                        //Get the all Unique records for Selected group (default - last name -sort) by search criteria
                        DataSet dsResult = Report.GetRentableAreaByExpirationDate(strRegion, strMarket, strLeaseType, dtLCDFrom, dtLCDTo, dtLEDFrom, dtLEDTo);

                        //Create HTML for the report and wirte into HTML Write object
                        StringBuilder strHTML = new StringBuilder();
                        System.IO.StringWriter stringWrite = new System.IO.StringWriter();
                        System.Web.UI.HtmlTextWriter htmlWrite = new System.Web.UI.HtmlTextWriter(stringWrite);

                        #region "Search Criteria"

                        //Retrieve Market Values
                        string strMarketString = string.Empty;
                        if (string.IsNullOrEmpty(strMarket))
                        {
                            strMarketString = "All Market";
                        }
                        else
                        {
                            string[] strMar = strMarket.Split(Convert.ToChar(","));
                            for (int i = 0; i < strMar.Length; i++)
                            {
                                strMarketString += Report.SelectMarketInfoById(Convert.ToDecimal(strMar[i].ToString())).Tables[0].Rows[0]["Market"].ToString() + ",";
                            }
                            strMarketString = strMarketString.TrimEnd(',');
                        }

                        //Add Report Title and Schedule Date
                        strHTML.Append("<br />");
                        strHTML.Append("<b>Report Title : Rentable Area By Expiration Date </b>");
                        strHTML.Append("<br /><br />");
                        strHTML.Append("Schedule Date : " + Convert.ToDateTime(drReportSchedule["Scheduled_Date"]).ToString(DateDisplayFormat));
                        strHTML.Append("&nbsp;&nbsp;&nbsp;&nbsp;Schedule End Date : " + Convert.ToDateTime(drReportSchedule["Schedule_End_Date"]).ToString(DateDisplayFormat));
                        strHTML.Append("<br />");
                        strHTML.Append("Recurring Period : " + drReportSchedule["Recurring_Period"].ToString());
                        strHTML.Append("<br />");
                        strHTML.Append("Recurring Date : " + dtSchduleDate.ToString(DateDisplayFormat));

                        //Add Report Filter Criteria 
                        strHTML.Append("<br /><br />");
                        strHTML.Append("<b>Report Filters </b>");
                        strHTML.Append("<br /><br />");
                        strHTML.Append("Region        : " + strRegion.Replace("'", ""));
                        strHTML.Append("<br />");
                        strHTML.Append("Market        : " + strMarketString);
                        strHTML.Append("<br /><br />");
                        strHTML.Append("Lease Type    : " + Report.GetLeaseTypeList(strLeaseType));
                        strHTML.Append("<br />");
                        strHTML.Append("LCD From      : " + FormatDBNullDateToDisplay(dtLCDFrom));
                        strHTML.Append("<br />");
                        strHTML.Append("LCD To        : " + FormatDBNullDateToDisplay(dtLCDTo));
                        strHTML.Append("<br />");
                        strHTML.Append("LED From      : " + FormatDBNullDateToDisplay(dtLEDFrom));
                        strHTML.Append("<br />");
                        strHTML.Append("LED To        : " + FormatDBNullDateToDisplay(dtLEDTo));
                        strHTML.Append("<br /><br />");

                        #endregion

                        #region "Report Grid header"
                        //FirstMonthName + "&nbsp;" + (Curr_Month + 1).ToString() + "<br style='mso-data-placement:same-cell;'> To " + LastMonthName + "&nbsp;" + (Curr_Month + 1).ToString()

                        strHTML.Append("<table border='1'>");
                        strHTML.Append("<tr style='font-weight: bold' valign='bottom' align='left'>");
                        strHTML.Append("<td align='left' colspan='3'>Sonic Automotive</td>");
                        strHTML.Append("<td align='center' colspan='5'>Rentable Area By Expiration Date</td>");
                        strHTML.Append("<td align='right' colspan='3'> " + DateTime.Now.ToString() + " </td>");
                        strHTML.Append("</tr>");
                        strHTML.Append("<tr valign='bottom' align='left' style='font-weight: bold'>");
                        strHTML.Append("<td>Region</td>");

                        for (int i = 0; i < 10; i++)
                            strHTML.Append("<td align='center'> " + FirstMonthName + "&nbsp;" + (DateTime.Now.Year + i).ToString() + "<br style='mso-data-placement:same-cell;'> To " + LastMonthName + "&nbsp;" + (DateTime.Now.Year + 1).ToString() + "</td>");

                        strHTML.Append("</tr>");

                        if (dsResult.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow drReport in dsResult.Tables[0].Rows)
                            {
                                strHTML.Append("<tr valign='top' align='left'>");
                                strHTML.Append("<td> " + Convert.ToString(drReport["Region"]) + " </td>");

                                for (int j = 1; j <= 10; j++)
                                    strHTML.Append("<td align='right'> " + string.Format("{0:N0}", drReport["Total_Gross_Leaseable_Area" + j.ToString()]) + " </td>");
                                strHTML.Append("</tr>");
                            }

                            strHTML.Append("<tr valign='top' align='left' style='font-weight: bold; background-color: #507CD1;color: White;'>");
                            strHTML.Append("<td> Grand Total </td>");

                            for (int j = 1; j <= 10; j++)
                                strHTML.Append("<td align='right'> " + string.Format("{0:N0}", dsResult.Tables[0].Compute("sum(Total_Gross_Leaseable_Area" + j.ToString() + ")", "")) + " </td>");

                            strHTML.Append("</tr>");
                        }
                        else
                        {
                            //Add No record found line for year
                            strHTML.Append("<tr><td align='left' colspan='11'>No Record Found!</td></tr>");
                        }
                        strHTML.Append("</table>");
                        #endregion

                        //Write HTML in to HtmlWriter
                        htmlWrite.WriteLine(strHTML.ToString());

                        //Send Mail
                        SendMail("Rentable Area By Expiration Date Report", "RentableAreaByExpirationDate.xls", strFirstName, strLastName, strMailFrom, stringWrite, dtRecipients);
                    }
                }
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("ERROR in Rentable Area By Expiration Date Report, " + ex.Message + " - " + ex.StackTrace.ToString() + " - " + ex.Source.ToString());
            }
        }

        // Report 32
        private void BindMonthlyExpenseByLocation(DataRow drReportSchedule)
        {
            try
            {
                decimal pK_Schedule_ID = Convert.ToDecimal(drReportSchedule["PK_Schedule"]);
                decimal Fk_RecipientList = Convert.ToDecimal(drReportSchedule["Fk_RecipientList"]);
                decimal FK_Security_Id = Convert.ToDecimal(drReportSchedule["FK_Security_Id"]);

                //Get Report criteria for the scheduled report
                DataTable dtFilter = Report.SelectFilterCriteria(32, pK_Schedule_ID).Tables[0];

                if (dtFilter.Rows.Count > 0)
                {
                    //Get the recipient from the recipient list 
                    DataTable dtRecipients = Report.SelectOneRecordWithRecipientList(Fk_RecipientList).Tables[0];
                    DataTable dtLocationDtl, dtLocation, dtReportDetail;
                    //Get the user who has scheduled the report
                    DataTable dtUser = Report.SelectSecurityByPK(FK_Security_Id).Tables[0];

                    String strFirstName, strLastName, strMailFrom, strAddress = "";

                    strFirstName = strLastName = strMailFrom = "";
                    if (dtUser.Rows.Count > 0)
                    {
                        strFirstName = Convert.ToString(dtUser.Rows[0]["FIRST_NAME"]).Trim();
                        strLastName = Convert.ToString(dtUser.Rows[0]["LAST_NAME"]).Trim();
                        strMailFrom = Convert.ToString(dtUser.Rows[0]["Email"]).Trim();

                        //Set all filters to a variable as per report type
                        DateTime? dtLCDFrom = null, dtLCDTo = null, dtLEDFrom = null, dtLEDTo = null;

                        string strRegion = Convert.ToString(dtFilter.Rows[0]["Region"]).Trim();
                        string strMarket = null;
                        if (!string.IsNullOrEmpty(Convert.ToString(dtFilter.Rows[0]["Market"])))
                        {
                            strMarket = Convert.ToString(dtFilter.Rows[0]["Market"]).Trim();
                        }
                        string strLeaseType = Convert.ToString(dtFilter.Rows[0]["LeaseType"]).Trim();

                        if (dtFilter.Rows[0]["LCDFrom_Date"] != DBNull.Value)
                            dtLCDFrom = Convert.ToDateTime(dtFilter.Rows[0]["LCDFrom_Date"]);

                        if (Convert.ToString(dtFilter.Rows[0]["LCDTo_Date"]) != string.Empty && dtFilter.Rows[0]["LCDTo_Date"] != DBNull.Value)
                            dtLCDTo = Convert.ToDateTime(dtFilter.Rows[0]["LCDTo_Date"]);

                        if (Convert.ToString(dtFilter.Rows[0]["LEDFrom_Date"]) != string.Empty && dtFilter.Rows[0]["LEDFrom_Date"] != DBNull.Value)
                            dtLEDFrom = Convert.ToDateTime(dtFilter.Rows[0]["LEDFrom_Date"]);

                        if (Convert.ToString(dtFilter.Rows[0]["LEDTo_Date"]) != string.Empty && dtFilter.Rows[0]["LEDTo_Date"] != DBNull.Value)
                            dtLEDTo = Convert.ToDateTime(dtFilter.Rows[0]["LEDTo_Date"]);

                        //Get the all Unique records for Selected group (default - last name -sort) by search criteria
                        DataSet dsResult = Report.GetMonthlyExpenseByLocation(strRegion, strMarket, strLeaseType, dtLCDFrom, dtLCDTo, dtLEDFrom, dtLEDTo);

                        //Create HTML for the report and wirte into HTML Write object
                        StringBuilder strHTML = new StringBuilder();
                        System.IO.StringWriter stringWrite = new System.IO.StringWriter();
                        System.Web.UI.HtmlTextWriter htmlWrite = new System.Web.UI.HtmlTextWriter(stringWrite);

                        #region "Report Criteria"

                        //Retrieve Market Values
                        string strMarketString = string.Empty;
                        if (string.IsNullOrEmpty(strMarket))
                        {
                            strMarketString = "All Market";
                        }
                        else
                        {
                            string[] strMar = strMarket.Split(Convert.ToChar(","));
                            for (int i = 0; i < strMar.Length; i++)
                            {
                                strMarketString += Report.SelectMarketInfoById(Convert.ToDecimal(strMar[i].ToString())).Tables[0].Rows[0]["Market"].ToString() + ",";
                            }
                            strMarketString = strMarketString.TrimEnd(',');
                        }

                        //Add Report Title and Schedule Date
                        strHTML.Append("<br />");
                        strHTML.Append("<b>Report Title : Monthly Expense By Location </b>");
                        strHTML.Append("<br /><br />");
                        strHTML.Append("Schedule Date : " + Convert.ToDateTime(drReportSchedule["Scheduled_Date"]).ToString(DateDisplayFormat));
                        strHTML.Append("&nbsp;&nbsp;&nbsp;&nbsp;Schedule End Date : " + Convert.ToDateTime(drReportSchedule["Schedule_End_Date"]).ToString(DateDisplayFormat));
                        strHTML.Append("<br />");
                        strHTML.Append("Recurring Period : " + drReportSchedule["Recurring_Period"].ToString());
                        strHTML.Append("<br />");
                        strHTML.Append("Recurring Date : " + dtSchduleDate.ToString(DateDisplayFormat));

                        //Add Report Filter Criteria 
                        strHTML.Append("<br /><br />");
                        strHTML.Append("<b>Report Filters </b>");
                        strHTML.Append("<br /><br />");
                        strHTML.Append("Region        : " + strRegion.Replace("'", ""));
                        strHTML.Append("<br />");
                        strHTML.Append("Market        : " + strMarketString);
                        strHTML.Append("<br /><br />");
                        strHTML.Append("Lease Type    : " + Report.GetLeaseTypeList(strLeaseType));
                        strHTML.Append("<br />");
                        strHTML.Append("LCD From      : " + FormatDBNullDateToDisplay(dtLCDFrom));
                        strHTML.Append("<br />");
                        strHTML.Append("LCD To        : " + FormatDBNullDateToDisplay(dtLCDTo));
                        strHTML.Append("<br />");
                        strHTML.Append("LED From      : " + FormatDBNullDateToDisplay(dtLEDFrom));
                        strHTML.Append("<br />");
                        strHTML.Append("LED To        : " + FormatDBNullDateToDisplay(dtLEDTo));
                        strHTML.Append("<br /><br />");

                        #endregion

                        #region "Report Grid header"

                        strHTML.Append("<table border='1'>");
                        strHTML.Append("<tr style='font-weight: bold' valign='bottom' align='left'>");
                        strHTML.Append("<td align='left' colspan='2'>Sonic Automotive</td>");
                        strHTML.Append("<td align='center' colspan='4'>Monthly Expense By Location </td>");
                        strHTML.Append("<td align='right' colspan='11'>" + DateTime.Now.ToString() + "</td>");
                        strHTML.Append("</tr>");
                        strHTML.Append("<tr valign='bottom' align='left' style='font-weight: bold'>");
                        strHTML.Append("<td>Location </td>");
                        strHTML.Append("<td>Address </td>");
                        strHTML.Append("<td>Region </td>");
                        strHTML.Append("<td>Subtenant </td>");
                        strHTML.Append("<td align='right'>Rentable Area </td>");

                        // for Display Month in Header 
                        for (int i = 0; i < 12; i++)
                            strHTML.Append("<td align='right' style=" + "\"" + "mso-number-format: 'mmm\\-yy';" + "\"" + ">" + Microsoft.VisualBasic.DateAndTime.MonthName(DateTime.Now.AddMonths(i).Month, true) + "-" + DateTime.Now.AddMonths(1).ToString("yy") + " </td>");

                        strHTML.Append("</tr>");

                        // Location Wise Total and Sum
                        dtLocationDtl = dsResult.Tables[1];
                        // set Location Table 
                        dtLocation = dsResult.Tables[2];

                        // Check if record is exist for location
                        if (dtLocation.Rows.Count > 0)
                        {
                            // loop for all location
                            foreach (DataRow drLocation in dtLocation.Rows)
                            {
                                // filter Reprot Result by Locaion ID
                                dtReportDetail = dsResult.Tables[0];
                                dtReportDetail.DefaultView.RowFilter = " PK_LU_Location_Id = " + drLocation["PK_LU_Location_Id"].ToString();
                                dtReportDetail.DefaultView.Sort = "Region";
                                dtReportDetail = dtReportDetail.DefaultView.ToTable();

                                // display location for filter
                                strHTML.Append("<tr valign='top' align='left'>");
                                strHTML.Append("<td colspan='17' align-'left'><b> Location : " + Convert.ToString(drLocation["dba"]) + "</b></td>");
                                strHTML.Append("</tr>");

                                #region "Report Detail"
                                // print Report Detail
                                if (dtReportDetail.Rows.Count > 0)
                                {
                                    // display record for Location
                                    foreach (DataRow drReport in dtReportDetail.Rows)
                                    {
                                        strAddress = Convert.ToString(drReport["Address_1"]).Trim() + "<br style='mso-data-placement:same-cell;'>" + Convert.ToString(drReport["City"]).Trim() +
                                                                                    "<br style='mso-data-placement:same-cell;'>" + Convert.ToString(drReport["State"]).Trim() +
                                                                                    "<br style='mso-data-placement:same-cell;'>" + Convert.ToString(drReport["ZIP_Code"]).Trim();
                                        strHTML.Append("<tr valign='top' align='left'>");
                                        strHTML.Append("<td> " + Convert.ToString(drReport["DBA"]) + " </td>");
                                        strHTML.Append("<td> " + strAddress + " </td>");
                                        strHTML.Append("<td  align='right'> " + drReport["Region"] + " </td>");
                                        strHTML.Append("<td> " + Convert.ToString(drReport["Subtenant_DBA"]) + " </td>");
                                        strHTML.Append("<td align='right'> " + string.Format("{0:N0}", drReport["Leaseable_Area"]) + " </td>");

                                        // for Display Month in Report Detail
                                        for (int i = 1; i <= 12; i++)
                                            strHTML.Append("<td align='right'>" + string.Format("{0:C2}", drReport["Month_" + i.ToString()]) + " </td>");

                                        strHTML.Append("</tr>");

                                    }

                                    // print Grand Total for Whole Report
                                    strHTML.Append("<tr valign='top' align='left' style='font-weight: bold;'>");
                                    strHTML.Append("<td> Sub Total </td>");

                                    // filter Location Detail Record
                                    DataRow[] dr = dtLocationDtl.Select("PK_LU_Location_ID = " + drLocation["PK_LU_Location_Id"].ToString());

                                    if (dr.Length > 0)
                                    {
                                        strHTML.Append("<td> " + string.Format("{0:N0}", dr[0]["LeaseCount"]) + "</td><td><td>");
                                        strHTML.Append("<td align='right'> " + string.Format("{0:N0}", dr[0]["Leaseable_Area"]) + "</td>");

                                        // display Monthly rent for next 12 month included Current Month
                                        for (int i = 1; i <= 12; i++)
                                            strHTML.Append("<td align='right'> " + string.Format("{0:C2}", dr[0]["Month_" + i.ToString()]) + "</td>");

                                    }

                                    strHTML.Append("</tr>");
                                }
                                else
                                {
                                    //Add No record found line for year
                                    strHTML.Append("<tr><td align='left' colspan='17'>No Record Found!</td></tr>");
                                }
                                #endregion
                            }

                            // print Grand Total for Whole Report
                            strHTML.Append("<tr valign='top' align='left' style='font-weight: bold; background-color: #507CD1;color: White;'>");
                            strHTML.Append("<td> Grand Total </td>");

                            if (dsResult.Tables[3].Rows.Count > 0)
                            {
                                strHTML.Append("<td> " + string.Format("{0:N0}", dsResult.Tables[3].Rows[0]["LeaseCount"]) + "</td><td><td>");
                                strHTML.Append("<td> " + string.Format("{0:N0}", dsResult.Tables[3].Rows[0]["Leaseable_Area"]) + "</td>");

                                // display Monthly rent for next 12 month included Current Month
                                for (int i = 1; i <= 12; i++)
                                    strHTML.Append("<td> " + string.Format("{0:C2}", dsResult.Tables[3].Rows[0]["Month_" + i.ToString()]) + "</td>");
                            }

                            strHTML.Append("</tr>");

                        }
                        strHTML.Append("</table>");
                        #endregion

                        //Write HTML in to HtmlWriter
                        htmlWrite.WriteLine(strHTML.ToString());

                        //Send Mail
                        SendMail("Monthly Expense By Location Report", "MonthlyExpenseByLocation.xls", strFirstName, strLastName, strMailFrom, stringWrite, dtRecipients);
                    }

                    // Clean Up Memory
                    dtRecipients.Dispose();
                    dtLocation = null;
                    dtRecipients = null;
                    dtLocationDtl = null;
                    dtReportDetail = null;

                }
                dtFilter.Dispose();
                dtFilter = null;
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("ERROR in Monthly Expense By Location Report, " + ex.Message + " - " + ex.StackTrace.ToString() + " - " + ex.Source.ToString());
            }
        }

        // Report 33
        private void BindLeasesWithSecurityDeposit(DataRow drReportSchedule)
        {
            try
            {
                decimal pK_Schedule_ID = Convert.ToDecimal(drReportSchedule["PK_Schedule"]);
                decimal Fk_RecipientList = Convert.ToDecimal(drReportSchedule["Fk_RecipientList"]);
                decimal FK_Security_Id = Convert.ToDecimal(drReportSchedule["FK_Security_Id"]);

                //Get Report criteria for the scheduled report
                DataTable dtFilter = Report.SelectFilterCriteria(33, pK_Schedule_ID).Tables[0];
                if (dtFilter.Rows.Count > 0)
                {
                    //Get the recipient from the recipient list 
                    DataTable dtRecipients = Report.SelectOneRecordWithRecipientList(Fk_RecipientList).Tables[0];

                    //Get the user who has scheduled the report
                    DataTable dtUser = Report.SelectSecurityByPK(FK_Security_Id).Tables[0];

                    String strFirstName, strLastName, strMailFrom;
                    strFirstName = strLastName = strMailFrom = "";
                    if (dtUser.Rows.Count > 0)
                    {
                        strFirstName = Convert.ToString(dtUser.Rows[0]["FIRST_NAME"]).Trim();
                        strLastName = Convert.ToString(dtUser.Rows[0]["LAST_NAME"]).Trim();
                        strMailFrom = Convert.ToString(dtUser.Rows[0]["Email"]).Trim();

                        //Set all filters to a variable as per report type
                        DateTime? dtLCDFrom = null, dtLCDTo = null, dtLEDFrom = null, dtLEDTo = null;

                        string strRegion = Convert.ToString(dtFilter.Rows[0]["Region"]).Trim();
                        string strMarket = null;
                        if (!string.IsNullOrEmpty(Convert.ToString(dtFilter.Rows[0]["Market"])))
                        {
                            strMarket = Convert.ToString(dtFilter.Rows[0]["Market"]).Trim();
                        }
                        string strLeaseType = Convert.ToString(dtFilter.Rows[0]["LeaseType"]).Trim();


                        if (!string.IsNullOrEmpty(Convert.ToString(dtFilter.Rows[0]["LCDFrom_Date"])))
                            dtLCDFrom = Convert.ToDateTime(dtFilter.Rows[0]["LCDFrom_Date"]);

                        if (!string.IsNullOrEmpty(Convert.ToString(dtFilter.Rows[0]["LCDTo_Date"])))
                            dtLCDTo = Convert.ToDateTime(dtFilter.Rows[0]["LCDTo_Date"]);

                        if (!string.IsNullOrEmpty(Convert.ToString(dtFilter.Rows[0]["LEDFrom_Date"])))
                            dtLEDFrom = Convert.ToDateTime(dtFilter.Rows[0]["LEDFrom_Date"]);

                        if (!string.IsNullOrEmpty(Convert.ToString(dtFilter.Rows[0]["LEDTo_Date"])))
                            dtLEDTo = Convert.ToDateTime(dtFilter.Rows[0]["LEDTo_Date"]);



                        //Create HTML for the report and wirte into HTML Write object
                        StringBuilder strHTML = new StringBuilder();
                        System.IO.StringWriter stringWrite = new System.IO.StringWriter();
                        System.Web.UI.HtmlTextWriter htmlWrite = new System.Web.UI.HtmlTextWriter(stringWrite);

                        #region "Search Criteria"

                        //Retrieve Market Values
                        string strMarketString = string.Empty;
                        if (string.IsNullOrEmpty(strMarket))
                        {
                            strMarketString = "All Market";
                        }
                        else
                        {
                            string[] strMar = strMarket.Split(Convert.ToChar(","));
                            for (int i = 0; i < strMar.Length; i++)
                            {
                                strMarketString += Report.SelectMarketInfoById(Convert.ToDecimal(strMar[i].ToString())).Tables[0].Rows[0]["Market"].ToString() + ",";
                            }
                            strMarketString = strMarketString.TrimEnd(',');
                        }

                        //Add Report Title and Schedule Date
                        strHTML.Append("<br />");
                        strHTML.Append("<b>Report Title : Leases With Security Deposits</b>");
                        strHTML.Append("<br /><br />");
                        strHTML.Append("Schedule Date : " + Convert.ToDateTime(drReportSchedule["Scheduled_Date"]).ToString(DateDisplayFormat));
                        strHTML.Append("&nbsp;&nbsp;&nbsp;&nbsp;Schedule End Date : " + Convert.ToDateTime(drReportSchedule["Schedule_End_Date"]).ToString(DateDisplayFormat));
                        strHTML.Append("<br />");
                        strHTML.Append("Recurring Period : " + drReportSchedule["Recurring_Period"].ToString());
                        strHTML.Append("<br />");
                        strHTML.Append("Recurring Date : " + dtSchduleDate.ToString(DateDisplayFormat));

                        //Add Report Filter Criteria 
                        strHTML.Append("<br /><br />");
                        strHTML.Append("<b>Report Filters </b>");
                        strHTML.Append("<br /><br />");
                        strHTML.Append("Region        : " + strRegion.Replace("'", ""));
                        strHTML.Append("<br />");
                        strHTML.Append("Market        : " + strMarketString);
                        strHTML.Append("<br /><br />");
                        strHTML.Append("Lease Type    : " + Report.GetLeaseTypeList(strLeaseType));
                        strHTML.Append("<br />");
                        strHTML.Append("LCD From      : " + FormatDBNullDateToDisplay(dtLCDFrom));
                        strHTML.Append("<br />");
                        strHTML.Append("LCD To        : " + FormatDBNullDateToDisplay(dtLCDTo));
                        strHTML.Append("<br />");
                        strHTML.Append("LED From      : " + FormatDBNullDateToDisplay(dtLEDFrom));
                        strHTML.Append("<br />");
                        strHTML.Append("LED To        : " + FormatDBNullDateToDisplay(dtLEDTo));
                        strHTML.Append("<br /><br />");

                        #endregion

                        #region "Grid Data"

                        strHTML.Append("<table cellspacing='0' cellpadding='0' align='Left' border='0' style='width: 1160px; border-collapse: collapse;'>");
                        //Header Row
                        strHTML.Append("<tr align='left'><td align='left'>");
                        strHTML.Append("<table width='1160px' cellpadding='0' cellspacing='0' border='0'>");
                        strHTML.Append("<tr><td align='left'>");
                        strHTML.Append("<table width='1160px' cellpadding='0' cellspacing='0' border='1' style='font-weight: bold;'>");
                        strHTML.Append("<tr style='font-weight: bold;'>");
                        strHTML.Append("<td align='left' colspan='2'>Sonic Automotive</td>");
                        strHTML.Append("<td align='center' colspan='5'>Leases With Security Deposits</td>");
                        strHTML.Append("<td align='right' colspan='2'>" + DateTime.Now.ToString() + " </td>");
                        strHTML.Append("</tr>");

                        strHTML.Append(" <tr style='font-weight: bold;'>");
                        strHTML.Append("<td align='left' style='width: 135px'>Lease</td>");
                        strHTML.Append("<td align='left' style='width: 250px'>Location</td>");
                        strHTML.Append("<td align='right' style='width: 100px'>Lease Term</td>");
                        strHTML.Append("<td align='right' style='width: 150px'>Rentable Area</td>");
                        strHTML.Append("<td align='left' style='width: 125px'>Landlord</td>");
                        strHTML.Append("<td align='left' style='width: 100px'>Deposit</td>");
                        strHTML.Append("<td align='center' style='width: 75px'>Deposit Reduced?</td>");
                        strHTML.Append("<td align='center' style='width: 75px'>Deposit Returned?</td>");
                        strHTML.Append("<td align='right' style='width: 150px'>Security Deposit Amount</td>");
                        strHTML.Append(" </tr>");

                        strHTML.Append("</table>");
                        strHTML.Append("</td></tr>");
                        strHTML.Append("</table>");
                        strHTML.Append("</td></tr>");


                        //get the all Employee records by search criteria by group
                        DataSet dsDetails = Report.GetLeasesWithSecurityDeposits(strRegion, strMarket, strLeaseType, dtLCDFrom, dtLCDTo, dtLEDFrom, dtLEDTo);

                        if (dsDetails != null && dsDetails.Tables.Count > 0 && dsDetails.Tables[0].Rows.Count > 0)
                        {
                            DataTable dtLocation = dsDetails.Tables[0];
                            DataTable dtDetails = dsDetails.Tables[1];

                            strHTML.Append("<tr align='left'><td align='left'>");
                            strHTML.Append("<table width='1160px' cellpadding='0' cellspacing='0' border='0'>");
                            strHTML.Append("<tr><td align='left'>");
                            strHTML.Append("<table cellspacing='0' cellpadding='0' align='Left' border='1' style='width: 100%; border-collapse: collapse;'>");

                            foreach (DataRow dr in dtLocation.Rows)
                            {
                                DataRow[] drDetails = dtDetails.Select("DBA='" + dr["DBA"] + "'");
                                foreach (DataRow drDetail in drDetails)
                                {
                                    strHTML.Append(" <tr>");
                                    strHTML.Append("<td align='left' style='width: 135px'>" + Convert.ToString(drDetail["Lease_Codes"]) + "</td>");
                                    strHTML.Append("<td align='left' style='width: 250px'>" + Convert.ToString(drDetail["DBA"]) + "<br />" + Convert.ToString(drDetail["Address"]) + " </td>");
                                    strHTML.Append("<td align='right' style='width: 100px'>" + string.Format("{0:N0}", drDetail["Lease_Term"] != DBNull.Value ? Convert.ToDecimal(drDetail["Lease_Term"]) : 0) + "</td>");
                                    strHTML.Append("<td align='right' style='width: 150px'>" + string.Format("{0:N0}", drDetail["Rentable_Area"] != DBNull.Value ? Convert.ToDecimal(drDetail["Rentable_Area"]) : 0) + "</td>");
                                    strHTML.Append("<td align='left' style='width: 125px'>" + Convert.ToString(drDetail["Landlord"]) + "</td>");
                                    strHTML.Append("<td align='left' style='width: 100px'>" + Convert.ToString(drDetail["Tender_Type"]) + "</td>");
                                    strHTML.Append("<td align='center' style='width: 75px'>" + (Convert.ToString(drDetail["Security_Deposit_Reduced"]) == "Y" ? "Yes" : "No") + "</td>");
                                    strHTML.Append("<td align='center' style='width: 75px'>" + (Convert.ToString(drDetail["Security_Deposit_Returned"]) == "Y" ? "Yes" : "No") + "</td>");
                                    strHTML.Append("<td align='right' style='width: 150px'>" + string.Format("{0:C2}", drDetail["Amount"] != DBNull.Value ? Convert.ToDecimal(drDetail["Amount"]) : 0) + "</td>");
                                    strHTML.Append(" </tr>");
                                }
                                strHTML.Append(" <tr style='font-weight: bold;'>");
                                strHTML.Append("<td align='left' style='width: 135px'>Sub Total</td>");
                                strHTML.Append("<td align='left' style='width: 250px'>" + drDetails.Length.ToString() + " </td>");
                                strHTML.Append("<td align='right' style='width: 100px'>" + string.Format("{0:N0}", dtDetails.Compute("sum(Lease_Term)", "DBA='" + dr["DBA"] + "'")) + "</td>");
                                strHTML.Append("<td align='right' style='width: 150px'>" + string.Format("{0:N0}", dtDetails.Compute("sum(Rentable_Area)", "DBA='" + dr["DBA"] + "'")) + "</td>");
                                strHTML.Append("<td align='left' style='width: 125px'>&nbsp;</td>");
                                strHTML.Append("<td align='left' style='width: 100px'>&nbsp;</td>");
                                strHTML.Append("<td align='left' style='width: 75px'>&nbsp;</td>");
                                strHTML.Append("<td align='left' style='width: 75px'>&nbsp;</td>");
                                strHTML.Append("<td align='right' style='width: 150px'>" + string.Format("{0:c2}", dtDetails.Compute("sum(Amount)", "DBA='" + dr["DBA"] + "'")) + "</td>");
                                strHTML.Append(" </tr>");
                            }
                            strHTML.Append("</table>");
                            strHTML.Append("</td></tr>");
                            strHTML.Append("</table>");
                            strHTML.Append("</td></tr>");

                            //Footer Row
                            strHTML.Append("<tr align='left'><td align='left'>");
                            strHTML.Append(" <table width='1160px' cellpadding='0' cellspacing='0' border='0'>");
                            strHTML.Append("<tr><td align='left'>");
                            strHTML.Append("<table width='1160px' cellpadding='4' cellspacing='0' border='1' style='font-weight: bold;background-color: #507CD1; color: White;'>");
                            strHTML.Append(" <tr style='font-weight: bold;'>");
                            strHTML.Append("<td align='left' style='width: 135px'>Report Grand Totals</td>");
                            strHTML.Append("<td align='left' style='width: 250px'>" + Convert.ToString(dtDetails.Rows.Count) + " </td>");
                            strHTML.Append("<td align='right' style='width: 100px'>" + string.Format("{0:N0}", dtDetails.Compute("sum(Lease_Term)", "")) + "</td>");
                            strHTML.Append("<td align='right' style='width: 150px'>" + string.Format("{0:N0}", dtDetails.Compute("sum(Rentable_Area)", "")) + "</td>");
                            strHTML.Append("<td align='left' style='width: 125px'>&nbsp;</td>");
                            strHTML.Append("<td align='left' style='width: 100px'>&nbsp;</td>");
                            strHTML.Append("<td align='left' style='width: 75px'>&nbsp;</td>");
                            strHTML.Append("<td align='left' style='width: 75px'>&nbsp;</td>");
                            strHTML.Append("<td align='right' style='width: 150px'>" + string.Format("{0:c2}", dtDetails.Compute("sum(Amount)", "")) + "</td>");
                            strHTML.Append(" </tr>");
                            strHTML.Append("</table>");
                            strHTML.Append("</td></tr>");
                            strHTML.Append("</table>");
                            strHTML.Append("</td></tr>");
                        }
                        else
                        {
                            strHTML.Append("<tr> <td style='font-weight: bold;'> No Record Found.");
                            strHTML.Append("</td></tr>");
                        }


                        strHTML.Append("</table>");
                        #endregion

                        //Write HTML in to HtmlWriter
                        htmlWrite.WriteLine(strHTML.ToString());

                        //Send Mail
                        SendMail("Leases With Security Deposits Report", "LeasesWithSecurityDeposits.xls", strFirstName, strLastName, strMailFrom, stringWrite, dtRecipients);
                    }
                }
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("ERROR in Leases With Security Deposits Report, " + ex.Message);
            }
        }

        //Report 34
        private void BindLandlordReport(DataRow drReportSchedule)
        {
            try
            {
                decimal pK_Schedule_ID = Convert.ToDecimal(drReportSchedule["PK_Schedule"]);
                decimal Fk_RecipientList = Convert.ToDecimal(drReportSchedule["Fk_RecipientList"]);
                decimal FK_Security_Id = Convert.ToDecimal(drReportSchedule["FK_Security_Id"]);

                //Get Report criteria for the scheduled report
                DataTable dtFilter = Report.SelectFilterCriteria(34, pK_Schedule_ID).Tables[0];
                if (dtFilter.Rows.Count > 0)
                {
                    //Get the recipient from the recipient list 
                    DataTable dtRecipients = Report.SelectOneRecordWithRecipientList(Fk_RecipientList).Tables[0];

                    //Get the user who has scheduled the report
                    DataTable dtUser = Report.SelectSecurityByPK(FK_Security_Id).Tables[0];

                    String strFirstName, strLastName, strMailFrom;
                    strFirstName = strLastName = strMailFrom = "";
                    if (dtUser.Rows.Count > 0)
                    {
                        strFirstName = Convert.ToString(dtUser.Rows[0]["FIRST_NAME"]).Trim();
                        strLastName = Convert.ToString(dtUser.Rows[0]["LAST_NAME"]).Trim();
                        strMailFrom = Convert.ToString(dtUser.Rows[0]["Email"]).Trim();

                        //Set all filters to a variable as per report type
                        DateTime? dtLCDFrom = null, dtLCDTo = null, dtLEDFrom = null, dtLEDTo = null;

                        string strRegion = Convert.ToString(dtFilter.Rows[0]["Region"]).Trim();
                        string strMarket = null;
                        if (!string.IsNullOrEmpty(Convert.ToString(dtFilter.Rows[0]["Market"])))
                        {
                            strMarket = Convert.ToString(dtFilter.Rows[0]["Market"]).Trim();
                        }
                        string strLeaseType = Convert.ToString(dtFilter.Rows[0]["LeaseType"]).Trim();


                        if (!string.IsNullOrEmpty(Convert.ToString(dtFilter.Rows[0]["LCDFrom_Date"])))
                            dtLCDFrom = Convert.ToDateTime(dtFilter.Rows[0]["LCDFrom_Date"]);

                        if (!string.IsNullOrEmpty(Convert.ToString(dtFilter.Rows[0]["LCDTo_Date"])))
                            dtLCDTo = Convert.ToDateTime(dtFilter.Rows[0]["LCDTo_Date"]);

                        if (!string.IsNullOrEmpty(Convert.ToString(dtFilter.Rows[0]["LEDFrom_Date"])))
                            dtLEDFrom = Convert.ToDateTime(dtFilter.Rows[0]["LEDFrom_Date"]);

                        if (!string.IsNullOrEmpty(Convert.ToString(dtFilter.Rows[0]["LEDTo_Date"])))
                            dtLEDTo = Convert.ToDateTime(dtFilter.Rows[0]["LEDTo_Date"]);

                        //Create HTML for the report and wirte into HTML Write object
                        StringBuilder strHTML = new StringBuilder();
                        System.IO.StringWriter stringWrite = new System.IO.StringWriter();
                        System.Web.UI.HtmlTextWriter htmlWrite = new System.Web.UI.HtmlTextWriter(stringWrite);

                        #region "Search Criteria"

                        //Retrieve Market Values
                        string strMarketString = string.Empty;
                        if (string.IsNullOrEmpty(strMarket))
                        {
                            strMarketString = "All Market";
                        }
                        else
                        {
                            string[] strMar = strMarket.Split(Convert.ToChar(","));
                            for (int i = 0; i < strMar.Length; i++)
                            {
                                strMarketString += Report.SelectMarketInfoById(Convert.ToDecimal(strMar[i].ToString())).Tables[0].Rows[0]["Market"].ToString() + ",";
                            }
                            strMarketString = strMarketString.TrimEnd(',');
                        }


                        //Add Report Title and Schedule Date
                        strHTML.Append("<br />");
                        strHTML.Append("<b>Report Title : Landlord Report</b>");
                        strHTML.Append("<br /><br />");
                        strHTML.Append("Schedule Date : " + Convert.ToDateTime(drReportSchedule["Scheduled_Date"]).ToString(DateDisplayFormat));
                        strHTML.Append("&nbsp;&nbsp;&nbsp;&nbsp;Schedule End Date : " + Convert.ToDateTime(drReportSchedule["Schedule_End_Date"]).ToString(DateDisplayFormat));
                        strHTML.Append("<br />");
                        strHTML.Append("Recurring Period : " + drReportSchedule["Recurring_Period"].ToString());
                        strHTML.Append("<br />");
                        strHTML.Append("Recurring Date : " + dtSchduleDate.ToString(DateDisplayFormat));

                        //Add Report Filter Criteria 
                        strHTML.Append("<br /><br />");
                        strHTML.Append("<b>Report Filters </b>");
                        strHTML.Append("<br /><br />");
                        strHTML.Append("Region        : " + strRegion.Replace("'", ""));
                        strHTML.Append("<br />");
                        strHTML.Append("Market        : " + strMarketString);
                        strHTML.Append("<br /><br />");
                        strHTML.Append("Lease Type    : " + Report.GetLeaseTypeList(strLeaseType));
                        strHTML.Append("<br />");
                        strHTML.Append("LCD From      : " + FormatDBNullDateToDisplay(dtLCDFrom));
                        strHTML.Append("<br />");
                        strHTML.Append("LCD To        : " + FormatDBNullDateToDisplay(dtLCDTo));
                        strHTML.Append("<br />");
                        strHTML.Append("LED From      : " + FormatDBNullDateToDisplay(dtLEDFrom));
                        strHTML.Append("<br />");
                        strHTML.Append("LED To        : " + FormatDBNullDateToDisplay(dtLEDTo));
                        strHTML.Append("<br /><br />");

                        #endregion

                        #region "Grid Data"

                        strHTML.Append("<table cellspacing='0' cellpadding='0' align='Left' border='0' style='width: 1285px; border-collapse: collapse;'>");
                        //Header Row
                        strHTML.Append("<tr align='left'><td align='left'>");
                        strHTML.Append("<table width='1285px' cellpadding='0' cellspacing='0' border='0'>");
                        strHTML.Append("<tr><td align='left'>");
                        strHTML.Append("<table width='1285px' cellpadding='0' cellspacing='0' border='1' style='font-weight: bold;'>");
                        strHTML.Append("<tr style='font-weight: bold;'>");
                        strHTML.Append("<td align='left' colspan='2'>Sonic Automotive</td>");
                        strHTML.Append("<td align='center' colspan='4'>Landlord Report</td>");
                        strHTML.Append("<td align='right' colspan='2'>" + DateTime.Now.ToString() + " </td>");
                        strHTML.Append("</tr>");

                        strHTML.Append(" <tr style='font-weight: bold;'>");
                        strHTML.Append("<td align='left' style='width: 250px'>Location</td>");
                        strHTML.Append("<td align='left' style='width: 200px'>First In House Contact</td>");
                        strHTML.Append("<td align='left' style='width: 190px'>Primary Use</td>");
                        strHTML.Append("<td align='left' style='width: 125px'>Landlord</td>");
                        strHTML.Append("<td align='left' style='width: 200px'>Type</td>");
                        strHTML.Append("<td align='left' style='width: 100px'>Lease Codes</td>");
                        strHTML.Append("<td align='right' style='width: 120px'>Rentable Area</td>");
                        strHTML.Append("<td align='right' style='width: 100px'>Lease Term</td>");
                        strHTML.Append(" </tr>");
                        strHTML.Append("</table>");
                        strHTML.Append("</td></tr>");
                        strHTML.Append("</table>");
                        strHTML.Append("</td></tr>");


                        //get the all Employee records by search criteria by group
                        DataSet dsDetails = Report.GetLandlordReport(strRegion, strMarket, strLeaseType, dtLCDFrom, dtLCDTo, dtLEDFrom, dtLEDTo);

                        if (dsDetails != null && dsDetails.Tables.Count > 0 && dsDetails.Tables[0].Rows.Count > 0)
                        {
                            DataTable dtLocation = dsDetails.Tables[0];
                            DataTable dtDetails = dsDetails.Tables[1];

                            strHTML.Append("<tr align='left'><td align='left'>");
                            strHTML.Append("<table width='1285px' cellpadding='0' cellspacing='0' border='0'>");
                            strHTML.Append("<tr><td align='left'>");
                            strHTML.Append("<table cellspacing='0' cellpadding='0' align='Left' border='1' style='width: 100%; border-collapse: collapse;'>");

                            foreach (DataRow dr in dtLocation.Rows)
                            {
                                DataRow[] drDetails = dtDetails.Select("DBA='" + dr["DBA"] + "'");
                                foreach (DataRow drDetail in drDetails)
                                {
                                    strHTML.Append(" <tr>");
                                    strHTML.Append("<td align='left' style='width: 250px'>" + Convert.ToString(drDetail["DBA"]) + "<br />" + Convert.ToString(drDetail["Address"]) + " </td>");
                                    strHTML.Append("<td align='left' style='width: 200px'>" + Convert.ToString(drDetail["Tenant_Contact"]) + "</td>");
                                    strHTML.Append("<td align='left' style='width: 190px'>" + Convert.ToString(drDetail["Primary_Use"]) + "</td>");
                                    strHTML.Append("<td align='left' style='width: 125px'>" + Convert.ToString(drDetail["Landlord"]) + "</td>");
                                    strHTML.Append("<td align='left' style='width: 200px'>" + Convert.ToString(drDetail["Type"]) + "</td>");
                                    strHTML.Append("<td align='left' style='width: 100px'>" + Convert.ToString(drDetail["Lease_Codes"]) + "</td>");
                                    strHTML.Append("<td align='right' style='width: 120px'>" + string.Format("{0:N0}", drDetail["Rentable_Area"] != DBNull.Value ? Convert.ToDecimal(drDetail["Rentable_Area"]) : 0) + "</td>");
                                    strHTML.Append("<td align='right' style='width: 100px'>" + string.Format("{0:N0}", drDetail["Lease_Term"] != DBNull.Value ? Convert.ToDecimal(drDetail["Lease_Term"]) : 0) + "</td>");
                                    strHTML.Append(" </tr>");
                                }
                                strHTML.Append(" <tr style='font-weight: bold;'>");
                                strHTML.Append("<td align='left' style='width: 250px'>Sub Total</td>");
                                strHTML.Append("<td align='left' style='width: 200px'>" + drDetails.Length.ToString() + " </td>");
                                strHTML.Append("<td align='left' style='width: 190px'>&nbsp;</td>");
                                strHTML.Append("<td align='left' style='width: 125px'>&nbsp;</td>");
                                strHTML.Append("<td align='left' style='width: 200px'>&nbsp;</td>");
                                strHTML.Append("<td align='left' style='width: 100px'>&nbsp;</td>");
                                strHTML.Append("<td align='right' style='width: 120px'>" + string.Format("{0:N0}", dtDetails.Compute("sum(Rentable_Area)", "DBA='" + dr["DBA"] + "'")) + "</td>");
                                strHTML.Append("<td align='right' style='width: 100px'>" + string.Format("{0:N0}", dtDetails.Compute("sum(Lease_Term)", "DBA='" + dr["DBA"] + "'")) + "</td>");
                                strHTML.Append(" </tr>");
                            }
                            strHTML.Append("</table>");
                            strHTML.Append("</td></tr>");
                            strHTML.Append("</table>");
                            strHTML.Append("</td></tr>");

                            //Footer Row
                            strHTML.Append("<tr align='left'><td align='left'>");
                            strHTML.Append(" <table width='1285px' cellpadding='0' cellspacing='0' border='0'>");
                            strHTML.Append("<tr><td align='left'>");
                            strHTML.Append("<table width='1285px' cellpadding='4' cellspacing='0' border='1' style='font-weight: bold;background-color: #507CD1; color: White;'>");
                            strHTML.Append(" <tr style='font-weight: bold;'>");
                            strHTML.Append("<td align='left' style='width: 250px'>Report Grand Totals</td>");
                            strHTML.Append("<td align='left' style='width: 200px'>" + Convert.ToString(dtDetails.Rows.Count) + " </td>");
                            strHTML.Append("<td align='left' style='width: 190px'>&nbsp;</td>");
                            strHTML.Append("<td align='left' style='width: 125px'>&nbsp;</td>");
                            strHTML.Append("<td align='left' style='width: 200px'>&nbsp;</td>");
                            strHTML.Append("<td align='left' style='width: 100px'>&nbsp;</td>");
                            strHTML.Append("<td align='right' style='width: 120px'>" + string.Format("{0:N0}", dtDetails.Compute("sum(Rentable_Area)", "")) + "</td>");
                            strHTML.Append("<td align='right' style='width: 100px'>" + string.Format("{0:N0}", dtDetails.Compute("sum(Lease_Term)", "")) + "</td>");
                            strHTML.Append(" </tr>");
                            strHTML.Append("</table>");
                            strHTML.Append("</td></tr>");
                            strHTML.Append("</table>");
                            strHTML.Append("</td></tr>");
                        }
                        else
                        {
                            strHTML.Append("<tr> <td style='font-weight: bold;'> No Record Found.");
                            strHTML.Append("</td></tr>");
                        }


                        strHTML.Append("</table>");
                        #endregion

                        //Write HTML in to HtmlWriter
                        htmlWrite.WriteLine(strHTML.ToString());

                        //Send Mail
                        SendMail("Landlord Report", "LandlordReport.xls", strFirstName, strLastName, strMailFrom, stringWrite, dtRecipients);
                    }
                }
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("ERROR in Landlord Report, " + ex.Message);
            }
        }

        // Report 35
        private void BindMaintenanceReport(DataRow drReportSchedule)
        {
            try
            {
                decimal pK_Schedule_ID = Convert.ToDecimal(drReportSchedule["PK_Schedule"]);
                decimal Fk_RecipientList = Convert.ToDecimal(drReportSchedule["Fk_RecipientList"]);
                decimal FK_Security_Id = Convert.ToDecimal(drReportSchedule["FK_Security_Id"]);

                //Get Report criteria for the scheduled report
                DataTable dtFilter = Report.SelectFilterCriteria(34, pK_Schedule_ID).Tables[0];
                if (dtFilter.Rows.Count > 0)
                {
                    //Get the recipient from the recipient list 
                    DataTable dtRecipients = Report.SelectOneRecordWithRecipientList(Fk_RecipientList).Tables[0];

                    //Get the user who has scheduled the report
                    DataTable dtUser = Report.SelectSecurityByPK(FK_Security_Id).Tables[0];

                    String strFirstName, strLastName, strMailFrom;
                    strFirstName = strLastName = strMailFrom = "";
                    if (dtUser.Rows.Count > 0)
                    {
                        strFirstName = Convert.ToString(dtUser.Rows[0]["FIRST_NAME"]).Trim();
                        strLastName = Convert.ToString(dtUser.Rows[0]["LAST_NAME"]).Trim();
                        strMailFrom = Convert.ToString(dtUser.Rows[0]["Email"]).Trim();

                        //Set all filters to a variable as per report type
                        DateTime? dtLCDFrom = null, dtLCDTo = null, dtLEDFrom = null, dtLEDTo = null;

                        string strRegion = Convert.ToString(dtFilter.Rows[0]["Region"]).Trim();
                        string strMarket = null;
                        if (!string.IsNullOrEmpty(Convert.ToString(dtFilter.Rows[0]["Market"])))
                        {
                            strMarket = Convert.ToString(dtFilter.Rows[0]["Market"]).Trim();
                        }
                        string strLeaseType = Convert.ToString(dtFilter.Rows[0]["LeaseType"]).Trim();


                        if (!string.IsNullOrEmpty(Convert.ToString(dtFilter.Rows[0]["LCDFrom_Date"])))
                            dtLCDFrom = Convert.ToDateTime(dtFilter.Rows[0]["LCDFrom_Date"]);

                        if (!string.IsNullOrEmpty(Convert.ToString(dtFilter.Rows[0]["LCDTo_Date"])))
                            dtLCDTo = Convert.ToDateTime(dtFilter.Rows[0]["LCDTo_Date"]);

                        if (!string.IsNullOrEmpty(Convert.ToString(dtFilter.Rows[0]["LEDFrom_Date"])))
                            dtLEDFrom = Convert.ToDateTime(dtFilter.Rows[0]["LEDFrom_Date"]);

                        if (!string.IsNullOrEmpty(Convert.ToString(dtFilter.Rows[0]["LEDTo_Date"])))
                            dtLEDTo = Convert.ToDateTime(dtFilter.Rows[0]["LEDTo_Date"]);

                        //Create HTML for the report and wirte into HTML Write object
                        StringBuilder strHTML = new StringBuilder();
                        System.IO.StringWriter stringWrite = new System.IO.StringWriter();
                        System.Web.UI.HtmlTextWriter htmlWrite = new System.Web.UI.HtmlTextWriter(stringWrite);

                        #region "Search Criteria"

                        //Retrieve Market Values
                        string strMarketString = string.Empty;
                        if (string.IsNullOrEmpty(strMarket))
                        {
                            strMarketString = "All Market";
                        }
                        else
                        {
                            string[] strMar = strMarket.Split(Convert.ToChar(","));
                            for (int i = 0; i < strMar.Length; i++)
                            {
                                strMarketString += Report.SelectMarketInfoById(Convert.ToDecimal(strMar[i].ToString())).Tables[0].Rows[0]["Market"].ToString() + ",";
                            }
                            strMarketString = strMarketString.TrimEnd(',');
                        }

                        //Add Report Title and Schedule Date
                        strHTML.Append("<br />");
                        strHTML.Append("<b>Report Title : Maintenance and Repair Items Report</b>");
                        strHTML.Append("<br /><br />");
                        strHTML.Append("Schedule Date : " + Convert.ToDateTime(drReportSchedule["Scheduled_Date"]).ToString(DateDisplayFormat));
                        strHTML.Append("&nbsp;&nbsp;&nbsp;&nbsp;Schedule End Date : " + Convert.ToDateTime(drReportSchedule["Schedule_End_Date"]).ToString(DateDisplayFormat));
                        strHTML.Append("<br />");
                        strHTML.Append("Recurring Period : " + drReportSchedule["Recurring_Period"].ToString());
                        strHTML.Append("<br />");
                        strHTML.Append("Recurring Date : " + dtSchduleDate.ToString(DateDisplayFormat));

                        //Add Report Filter Criteria 
                        strHTML.Append("<br /><br />");
                        strHTML.Append("<b>Report Filters </b>");
                        strHTML.Append("<br /><br />");
                        strHTML.Append("Region        : " + strRegion.Replace("'", ""));
                        strHTML.Append("<br />");
                        strHTML.Append("Market        : " + strMarketString);
                        strHTML.Append("<br /><br />");
                        strHTML.Append("Lease Type    : " + Report.GetLeaseTypeList(strLeaseType));
                        strHTML.Append("<br />");
                        strHTML.Append("LCD From      : " + FormatDBNullDateToDisplay(dtLCDFrom));
                        strHTML.Append("<br />");
                        strHTML.Append("LCD To        : " + FormatDBNullDateToDisplay(dtLCDTo));
                        strHTML.Append("<br />");
                        strHTML.Append("LED From      : " + FormatDBNullDateToDisplay(dtLEDFrom));
                        strHTML.Append("<br />");
                        strHTML.Append("LED To        : " + FormatDBNullDateToDisplay(dtLEDTo));
                        strHTML.Append("<br /><br />");

                        #endregion

                        #region "Grid Data"

                        strHTML.Append("<table cellspacing='0' cellpadding='0' align='Left' border='0' style='width: 950px; border-collapse: collapse;'>");
                        //Header Row
                        strHTML.Append("<tr align='left'><td align='left'>");
                        strHTML.Append("<table width='100%' cellpadding='0' cellspacing='0' border='0'>");
                        strHTML.Append("<tr><td align='left'>");
                        strHTML.Append("<table width='100%' cellpadding='0' cellspacing='0' border='1' style='font-weight: bold;'>");
                        strHTML.Append("<tr style='font-weight: bold;'>");
                        strHTML.Append("<td align='left'>Sonic Automotive</td>");
                        strHTML.Append("<td align='center' colspan='3'>Maintenance and Repair Items</td>");
                        strHTML.Append("<td align='right'>" + DateTime.Now.ToString() + " </td>");
                        strHTML.Append("</tr>");

                        strHTML.Append(" <tr style='font-weight: bold;'>");
                        strHTML.Append("<td align='left' style='width: 20%'>Lease Codes</td>");
                        strHTML.Append("<td align='left' style='width: 20%'>Location</td>");
                        strHTML.Append("<td align='right' style='width: 20%'>Rentable Area</td>");
                        strHTML.Append("<td align='right' style='width: 20%'>Lease Term</td>");
                        strHTML.Append("<td align='right' style='width: 20%'>Total Repair Items</td>");
                        strHTML.Append(" </tr>");
                        strHTML.Append("</table>");
                        strHTML.Append("</td></tr>");
                        strHTML.Append("</table>");
                        strHTML.Append("</td></tr>");


                        //get the all Employee records by search criteria by group
                        DataSet dsDetails = Report.GetMaintenanceAndRepairItems(strRegion, strMarket, strLeaseType, dtLCDFrom, dtLCDTo, dtLEDFrom, dtLEDTo);

                        if (dsDetails != null && dsDetails.Tables.Count > 0 && dsDetails.Tables[0].Rows.Count > 0)
                        {
                            DataTable dtLocation = dsDetails.Tables[0];
                            DataTable dtDetails = dsDetails.Tables[1];

                            strHTML.Append("<tr align='left'><td align='left'>");
                            strHTML.Append("<table width='100%' cellpadding='0' cellspacing='0' border='0'>");
                            strHTML.Append("<tr><td align='left'>");
                            strHTML.Append("<table cellspacing='0' cellpadding='0' align='Left' border='1' style='width: 100%; border-collapse: collapse;'>");

                            foreach (DataRow dr in dtLocation.Rows)
                            {
                                DataRow[] drDetails = dtDetails.Select("DBA='" + dr["DBA"] + "'");
                                foreach (DataRow drDetail in drDetails)
                                {
                                    strHTML.Append(" <tr>");
                                    strHTML.Append("<td align='left' style='width: 20%'>" + Convert.ToString(drDetail["Lease_Codes"]) + "</td>");
                                    strHTML.Append("<td align='left' style='width: 20%'>" + Convert.ToString(drDetail["DBA"]) + "<br />" + Convert.ToString(drDetail["Address"]) + " </td>");
                                    strHTML.Append("<td align='right' style='width: 20%'>" + string.Format("{0:N0}", drDetail["Rentable_Area"] != DBNull.Value ? Convert.ToDecimal(drDetail["Rentable_Area"]) : 0) + "</td>");
                                    strHTML.Append("<td align='right' style='width: 20%'>" + string.Format("{0:N0}", drDetail["Lease_Term"] != DBNull.Value ? Convert.ToDecimal(drDetail["Lease_Term"]) : 0) + "</td>");
                                    strHTML.Append("<td align='right' style='width: 20%'>" + string.Format("{0:N0}", drDetail["Items_Per_Location"] != DBNull.Value ? Convert.ToDecimal(drDetail["Items_Per_Location"]) : 0) + "</td>");
                                    strHTML.Append(" </tr>");
                                }
                                strHTML.Append(" <tr style='font-weight: bold;'>");
                                strHTML.Append("<td align='left' style='width: 20%'>Sub Total</td>");
                                strHTML.Append("<td align='left' style='width: 20%'>" + drDetails.Length.ToString() + " </td>");
                                strHTML.Append("<td align='right' style='width: 20%'>" + string.Format("{0:N0}", dtDetails.Compute("sum(Rentable_Area)", "DBA='" + dr["DBA"] + "'")) + "</td>");
                                strHTML.Append("<td align='right' style='width: 20%'>" + string.Format("{0:N0}", dtDetails.Compute("sum(Lease_Term)", "DBA='" + dr["DBA"] + "'")) + "</td>");
                                strHTML.Append("<td align='right' style='width: 20%'>" + string.Format("{0:N0}", dtDetails.Compute("sum(Items_Per_Location)", "DBA='" + dr["DBA"] + "'")) + "</td>");
                                strHTML.Append(" </tr>");
                            }
                            strHTML.Append("</table>");
                            strHTML.Append("</td></tr>");
                            strHTML.Append("</table>");
                            strHTML.Append("</td></tr>");

                            //Footer Row
                            strHTML.Append("<tr align='left'><td align='left'>");
                            strHTML.Append(" <table width='100%' cellpadding='0' cellspacing='0' border='0'>");
                            strHTML.Append("<tr><td align='left'>");
                            strHTML.Append("<table width='100%' cellpadding='4' cellspacing='0' border='1' style='font-weight: bold;background-color: #507CD1; color: White;'>");
                            strHTML.Append(" <tr style='font-weight: bold;'>");
                            strHTML.Append("<td align='left' style='width: 20%'>Report Grand Totals</td>");
                            strHTML.Append("<td align='left' style='width: 20%'>" + Convert.ToString(dtDetails.Rows.Count) + " </td>");
                            strHTML.Append("<td align='right' style='width: 20%'>" + string.Format("{0:N0}", dtDetails.Compute("sum(Rentable_Area)", "")) + "</td>");
                            strHTML.Append("<td align='right' style='width: 20%'>" + string.Format("{0:N0}", dtDetails.Compute("sum(Lease_Term)", "")) + "</td>");
                            strHTML.Append("<td align='right' style='width: 20%'>" + string.Format("{0:N0}", dtDetails.Compute("sum(Items_Per_Location)", "")) + "</td>");
                            strHTML.Append(" </tr>");
                            strHTML.Append("</table>");
                            strHTML.Append("</td></tr>");
                            strHTML.Append("</table>");
                            strHTML.Append("</td></tr>");
                        }
                        else
                        {
                            strHTML.Append("<tr> <td style='font-weight: bold;'> No Record Found.");
                            strHTML.Append("</td></tr>");
                        }


                        strHTML.Append("</table>");
                        #endregion

                        //Write HTML in to HtmlWriter
                        htmlWrite.WriteLine(strHTML.ToString());

                        //Send Mail
                        SendMail("Maintenance and Repair Items Report", "MaintenanceAndRepairItems.xls", strFirstName, strLastName, strMailFrom, stringWrite, dtRecipients);
                    }
                }
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("ERROR in Maintenance and Repair Items Report, " + ex.Message);
            }
        }

        // Report 36
        private void BindWCAllocationYTDCharge(DataRow drReportSchedule)
        {
            try
            {
                decimal pK_Schedule_ID = Convert.ToDecimal(drReportSchedule["PK_Schedule"]);
                decimal Fk_RecipientList = Convert.ToDecimal(drReportSchedule["Fk_RecipientList"]);
                decimal FK_Security_Id = Convert.ToDecimal(drReportSchedule["FK_Security_Id"]);

                //Get Report criteria for the scheduled report
                DataTable dtFilter = Report.SelectFilterCriteria(36, pK_Schedule_ID).Tables[0];
                if (dtFilter.Rows.Count > 0)
                {
                    //Get the recipient from the recipient list 
                    DataTable dtRecipients = Report.SelectOneRecordWithRecipientList(Fk_RecipientList).Tables[0];

                    //Get the user who has scheduled the report
                    DataTable dtUser = Report.SelectSecurityByPK(FK_Security_Id).Tables[0];

                    String strFirstName, strLastName, strMailFrom;
                    strFirstName = strLastName = strMailFrom  = "";
                    if (dtUser.Rows.Count > 0)
                    {
                        strFirstName = Convert.ToString(dtUser.Rows[0]["FIRST_NAME"]).Trim();
                        strLastName = Convert.ToString(dtUser.Rows[0]["LAST_NAME"]).Trim();
                        strMailFrom = Convert.ToString(dtUser.Rows[0]["Email"]).Trim();

                        string strRegion = Convert.ToString(dtFilter.Rows[0]["Region"]).Trim();                        
                      
                        string strLocation = Convert.ToString(dtFilter.Rows[0]["Location"]).Trim();
                        string strYear = Convert.ToString(dtFilter.Rows[0]["Year"]).Trim();

                        //Get the all Unique records for Selected group (default - last name -sort) by search criteria
                        DataSet dsResult = Report.GetWCAllocationYTDChargeReport(strRegion, strLocation, strYear);

                        //Create HTML for the report and wirte into HTML Write object
                        StringBuilder strHTML = new StringBuilder();
                        System.IO.StringWriter stringWrite = new System.IO.StringWriter();
                        System.Web.UI.HtmlTextWriter htmlWrite = new System.Web.UI.HtmlTextWriter(stringWrite);

                        #region "Report Title"
                        //Retrieve Market Values

                      
                        //Add Report Title and Schedule Date
                        strHTML.Append("<br />");
                        strHTML.Append("<b>Report Title : Workers Comp Allocation YTD Charge Report </b>");
                        strHTML.Append("<br /><br />");
                        strHTML.Append("Schedule Date : " + Convert.ToDateTime(drReportSchedule["Scheduled_Date"]).ToString(DateDisplayFormat));
                        strHTML.Append("&nbsp;&nbsp;&nbsp;&nbsp;Schedule End Date : " + Convert.ToDateTime(drReportSchedule["Schedule_End_Date"]).ToString(DateDisplayFormat));
                        strHTML.Append("<br />");
                        strHTML.Append("Recurring Period : " + drReportSchedule["Recurring_Period"].ToString());
                        strHTML.Append("<br />");
                        strHTML.Append("Recurring Date : " + dtSchduleDate.ToString(DateDisplayFormat));

                        //Add Report Filter Criteria 
                        strHTML.Append("<br /><br /><table> <tr> <td>");
                        strHTML.Append("<b>Report Filters </b>");
                        strHTML.Append("<br /><table> <tr> <td colspan='8'>");
                        strHTML.Append("Region   : " + strRegion);
                        strHTML.Append("</td> </tr> <tr> <td colspan='8'>");
                        strHTML.Append("Location : " + (string.IsNullOrEmpty(strLocation) ? "" : GetCommaValueFromTable(Report.getLocationByIds(strLocation).Tables[0], "DBA")));
                        strHTML.Append("</td></tr> <tr> <td colspan='8'>");
                        strHTML.Append("Accident Year : " + strYear);
                        strHTML.Append("</td></tr></table> ");
                        strHTML.Append("<br /><br />");

                        #endregion

                        #region "Report Grid header"

                        strHTML.Append("<table border='1'>");
                        strHTML.Append("<tr style='font-weight: bold' valign='bottom' align='left'>");
                        strHTML.Append("<td align='left' colspan='3'>Sonic Automotive</td>");
                        strHTML.Append("<td align='center' colspan='4'>WC Allocation YTD Charge Report</td>");
                        strHTML.Append("<td align='right' colspan='8'> Accident Year :" + strYear + " </td>");
                        strHTML.Append("</tr>");
                        strHTML.Append("<tr valign='bottom' align='left' style='font-weight: bold'>");
                        strHTML.Append("<td > First Report Number </td>");
                        strHTML.Append("<td >Date of Incident</td>");
                        strHTML.Append("<td >Date Reported To SRS</td>");
                        strHTML.Append("<td >Location</td>");
                        strHTML.Append("<td >Region</td>");
                        strHTML.Append("<td >Department</td>");
                        strHTML.Append("<td >Employee</td>");
                        strHTML.Append("<td >Description of Incident</td>");
                        strHTML.Append("<td >Invst. Comp.</td>");
                        strHTML.Append("<td >Cause Code</td>");
                        strHTML.Append("<td >Rep. Only</td>");
                        strHTML.Append("<td align='Right'>Initial Charge</td>");
                        strHTML.Append("<td align='Right'>Total Credits</td>");
                        strHTML.Append("<td align='Right'>Total Penalties</td>");
                        strHTML.Append("<td align='Right'>Total Charge Amount</td>");
                        strHTML.Append("</tr>");

                        // set Location Table 
                        DataTable dtLocation = dsResult.Tables[1];

                        // Check if record is exist for location
                        if (dtLocation.Rows.Count > 0)
                        {
                            // loop for all location
                            foreach (DataRow drLocation in dtLocation.Rows)
                            {
                                // filter Reprot Result by Locaion ID
                                DataTable dtReportDetail = dsResult.Tables[0];
                                dtReportDetail.DefaultView.RowFilter = " PK_LU_Location_Id = " + drLocation["PK_LU_Location_Id"].ToString();
                                dtReportDetail.DefaultView.Sort = "Region";
                                dtReportDetail = dtReportDetail.DefaultView.ToTable();

                                // display location for filter
                                strHTML.Append("<tr valign='top' align='left'>");
                                strHTML.Append("<td colspan='15' align='left'><b> Location : " + Convert.ToString(drLocation["dba"]) + "</b></td>");
                                strHTML.Append("</tr>");

                                // print Report Detail
                                if (dtReportDetail.Rows.Count > 0)
                                {
                                    // display record for Location
                                    foreach (DataRow drReport in dtReportDetail.Rows)
                                    {
                                        strHTML.Append("<tr valign='top' align='left'>");
                                        strHTML.Append("<td> " + Convert.ToString(drReport["WC_Fr_Number"]) + " </td>");
                                        strHTML.Append("<td> " + (string.IsNullOrEmpty(Convert.ToString(drReport["Date_Of_Incident"]).Trim()) ? "" : FormatDBNullDateToDisplay(drReport["Date_Of_Incident"])) + " </td>");
                                        strHTML.Append("<td> " + (Convert.ToString(drReport["Date_Reported_to_SRS"]) != string.Empty ? FormatDateToDisplay(FormatDateToStore(drReport["Date_Reported_to_SRS"])) : "") + " </td>");
                                        strHTML.Append("<td> " + Convert.ToString(drReport["DBA"]) + " </td>");
                                        strHTML.Append("<td> " + Convert.ToString(drReport["Region"]) + " </td>");
                                        strHTML.Append("<td> " + Convert.ToString(drReport["Description"]) + " </td>");
                                        strHTML.Append("<td> " + Convert.ToString(drReport["Employee_Name"]) + " </td>");
                                        strHTML.Append("<td> " + Convert.ToString(drReport["Description_of_Incident"]) + " </td>");
                                        strHTML.Append("<td> " + Convert.ToString(drReport["Inv_Comp"]) + " </td>");
                                        strHTML.Append("<td> " + Convert.ToString(drReport["Sonic_Cause_Code"]) + " </td>");
                                        strHTML.Append("<td> " + Convert.ToString(drReport["Report_Only"]) + " </td>");
                                        strHTML.Append("<td align='right'> " + string.Format("{0:C2}", drReport["Initial_Charge"]) + " </td>");
                                        strHTML.Append("<td align='right'> " + string.Format("{0:C2}", drReport["Total_Credits"]) + " </td>");
                                        strHTML.Append("<td align='right'> " + string.Format("{0:C2}", drReport["Total_Penalties"]) + " </td>");
                                        strHTML.Append("<td align='right'> " + string.Format("{0:C2}", drReport["Total_Charge"]) + " </td>");
                                        strHTML.Append("</tr>");
                                    }

                                    // print Sub Total by Location
                                    strHTML.Append("<tr valign='top' align='left' style='font-weight: bold;'>");
                                    strHTML.Append("<td> Sub Total </td>");
                                    strHTML.Append("<td>" + dtReportDetail.Rows.Count.ToString() + "</td>");
                                    strHTML.Append("<td> <td> <td> <td> <td> <td><td><td><td>");
                                    strHTML.Append("<td align='right'> " + string.Format("{0:C2}", dtReportDetail.Compute("SUM(Initial_Charge)", "")) + " </td>");
                                    strHTML.Append("<td align='right'> " + string.Format("{0:C2}", dtReportDetail.Compute("SUM(Total_Credits)", "")) + " </td>");
                                    strHTML.Append("<td align='right'> " + string.Format("{0:C2}", dtReportDetail.Compute("SUM(Total_Penalties)", "")) + " </td>");
                                    strHTML.Append("<td align='right'> " + string.Format("{0:C2}", dtReportDetail.Compute("SUM(Total_Charge)", "")) + " </td>");
                                    strHTML.Append("</tr>");
                                }
                                else
                                {
                                    //Add No record found line for year
                                    strHTML.Append("<tr><td align='left' colspan='15'>No Record Found!</td></tr>");
                                }

                            }

                            // print Grand Total for Whole Report
                            strHTML.Append("<tr valign='top' align='left' style='font-weight: bold; background-color: #507CD1;color: White;'>");
                            strHTML.Append("<td> Grand Total </td>");
                            strHTML.Append("<td>" + dsResult.Tables[0].Rows.Count.ToString() + "</td>");
                            strHTML.Append("<td> <td> <td> <td> <td> <td><td><td><td>");
                            strHTML.Append("<td align='right'> " + string.Format("{0:C2}", dsResult.Tables[0].Compute("SUM(Initial_Charge)", "")) + " </td>");
                            strHTML.Append("<td align='right'> " + string.Format("{0:C2}", dsResult.Tables[0].Compute("SUM(Total_Credits)", "")) + " </td>");
                            strHTML.Append("<td align='right'> " + string.Format("{0:C2}", dsResult.Tables[0].Compute("SUM(Total_Penalties)", "")) + " </td>");
                            strHTML.Append("<td align='right'> " + string.Format("{0:C2}", dsResult.Tables[0].Compute("SUM(Total_Charge)", "")) + " </td>");
                            strHTML.Append("</tr>");

                        }
                        else
                        {
                            //Add No record found line for year
                            strHTML.Append("<tr><td align='left' colspan='15'>No Record Found!</td></tr>");
                        }
                        strHTML.Append("</table>");

                        #endregion

                        //Write HTML in to HtmlWriter
                        htmlWrite.WriteLine(strHTML.ToString());

                        //Send Mail
                        SendMail("Workers Comp Allocation YTD Charge Report", "WCAllocationYTDChargeReport.xls", strFirstName, strLastName, strMailFrom, stringWrite, dtRecipients);
                    }
                }
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("ERROR in Workers Comp Allocation YTD Charge Report, " + ex.Message + " - " + ex.StackTrace.ToString() + " - " + ex.Source.ToString());
            }
        }

        // Report 37
        private void BindExposuresPropertyStatementofValue(DataRow drReportSchedule)
        {
            try
            {
                decimal pK_Schedule_ID = Convert.ToDecimal(drReportSchedule["PK_Schedule"]);
                decimal Fk_RecipientList = Convert.ToDecimal(drReportSchedule["Fk_RecipientList"]);
                decimal FK_Security_Id = Convert.ToDecimal(drReportSchedule["FK_Security_Id"]);

                //Get Report criteria for the scheduled report
                DataTable dtFilter = Report.SelectFilterCriteria(37, pK_Schedule_ID).Tables[0];
                if (dtFilter.Rows.Count > 0)
                {
                    //Get the recipient from the recipient list 
                    DataTable dtRecipients = Report.SelectOneRecordWithRecipientList(Fk_RecipientList).Tables[0];

                    //Get the user who has scheduled the report
                    DataTable dtUser = Report.SelectSecurityByPK(FK_Security_Id).Tables[0];

                    String strFirstName, strLastName, strMailFrom;
                    strFirstName = strLastName = strMailFrom = "";
                    if (dtUser.Rows.Count > 0)
                    {
                        strFirstName = Convert.ToString(dtUser.Rows[0]["FIRST_NAME"]).Trim();
                        strLastName = Convert.ToString(dtUser.Rows[0]["LAST_NAME"]).Trim();
                        strMailFrom = Convert.ToString(dtUser.Rows[0]["Email"]).Trim();

                        string strRegion = Convert.ToString(dtFilter.Rows[0]["Region"]).Trim();
                        string strMarket = null;
                        if (!string.IsNullOrEmpty(Convert.ToString(dtFilter.Rows[0]["Market"])))
                        {
                            strMarket = Convert.ToString(dtFilter.Rows[0]["Market"]).Trim();
                        }
                        string strStatus = Convert.ToString(dtFilter.Rows[0]["Status"]).Trim();
                        string strOwnership = Convert.ToString(dtFilter.Rows[0]["Ownership"]).Trim();
                        DateTime? dtPropertyValuationDateFrom = null;
                        if (!string.IsNullOrEmpty(Convert.ToString(dtFilter.Rows[0]["Property_Valuation_Date_FROM"])))
                            dtPropertyValuationDateFrom = Convert.ToDateTime(dtFilter.Rows[0]["Property_Valuation_Date_FROM"]);
                        DateTime? dtPropertyValuationDateTo = null;
                        if (!string.IsNullOrEmpty(Convert.ToString(dtFilter.Rows[0]["Property_Valuation_Date_To"])))
                            dtPropertyValuationDateTo = Convert.ToDateTime(dtFilter.Rows[0]["Property_Valuation_Date_To"]);

                        //Get the all Unique records for Selected group (default - last name -sort) by search criteria
                        DataSet dsResult = Report.GetPropertyStatementofValues(strRegion, strMarket, strStatus, strOwnership, dtPropertyValuationDateFrom, dtPropertyValuationDateTo);

                        //Create HTML for the report and wirte into HTML Write object
                        StringBuilder strHTML = new StringBuilder();
                        System.IO.StringWriter stringWrite = new System.IO.StringWriter();
                        System.Web.UI.HtmlTextWriter htmlWrite = new System.Web.UI.HtmlTextWriter(stringWrite);

                        #region "Report Title"

                        //Retrieve Market Values
                        string strMarketString = string.Empty;
                        if (string.IsNullOrEmpty(strMarket))
                        {
                            strMarketString = "All Market";
                        }
                        else
                        {
                            string[] strMar = strMarket.Split(Convert.ToChar(","));
                            for (int i = 0; i < strMar.Length; i++)
                            {
                                strMarketString += Report.SelectMarketInfoById(Convert.ToDecimal(strMar[i].ToString())).Tables[0].Rows[0]["Market"].ToString() + ",";
                            }
                            strMarketString = strMarketString.TrimEnd(',');
                        }

                        //Add Report Title and Schedule Date
                        strHTML.Append("<br />");
                        strHTML.Append("<b>Report Title : Property – Statement of Values Report </b>");
                        strHTML.Append("<br /><br />");
                        strHTML.Append("Schedule Date : " + Convert.ToDateTime(drReportSchedule["Scheduled_Date"]).ToString(DateDisplayFormat));
                        strHTML.Append("&nbsp;&nbsp;&nbsp;&nbsp;Schedule End Date : " + Convert.ToDateTime(drReportSchedule["Schedule_End_Date"]).ToString(DateDisplayFormat));
                        strHTML.Append("<br />");
                        strHTML.Append("Recurring Period : " + drReportSchedule["Recurring_Period"].ToString());
                        strHTML.Append("<br />");
                        strHTML.Append("Recurring Date : " + dtSchduleDate.ToString(DateDisplayFormat));

                        //Add Report Filter Criteria 
                        strHTML.Append("<br /><br /><table> <tr> <td>");
                        strHTML.Append("<b>Report Filters </b>");
                        strHTML.Append("<br /><table> <tr> <td colspan='8'>");
                        strHTML.Append("Region   : " + strRegion);
                        strHTML.Append("</td> </tr>");
                        strHTML.Append("<br /><table> <tr> <td colspan='8'>");
                        strHTML.Append("Market        : " + strMarketString);
                        strHTML.Append("</td> </tr>");
                        strHTML.Append("<tr> <td colspan='8'>");
                        strHTML.Append("Location Status   : " + strStatus);
                        strHTML.Append("</td> </tr>");
                        strHTML.Append("<tr> <td colspan='8'>");
                        strHTML.Append("Ownership   : " + strOwnership);
                        strHTML.Append("</td> </tr>");
                        strHTML.Append("<tr> <td colspan='8'>");
                        strHTML.Append("Property valuation Date From   : " + Convert.ToString(dtPropertyValuationDateFrom));
                        strHTML.Append("</td> </tr>");
                        strHTML.Append("<tr> <td colspan='8'>");
                        strHTML.Append("Property valuation Date To   : " + Convert.ToString(dtPropertyValuationDateTo));
                        strHTML.Append("</td> </tr>");
                        strHTML.Append("<tr> <td colspan='8'>");
                        strHTML.Append("</td></tr></table> ");
                        strHTML.Append("<br /><br />");

                        #endregion

                        #region "Report Grid header"
                        //Top Header
                        strHTML.Append("<table border='1'>");
                        strHTML.Append("<tr style='font-weight: bold;' valign='bottom' align='left'>");
                        strHTML.Append("<td align='left' colspan='2'>Sonic Automotive</td>");
                        strHTML.Append("<td align='center' colspan='89'>Property Statement of Values Report</td>");
                        strHTML.Append("<td align='right' colspan='3'> " + DateTime.Now.ToString() + " </td>");
                        strHTML.Append("</tr>");

                        //Sub Header
                        strHTML.Append("<tr style='font-weight:bold;  color : White;' align='center'>");
                        strHTML.Append("<td colspan='15' style='background: #993300;'>LOCATION/ADDRESS INFORMATION</td>");
                        strHTML.Append("<td colspan='8' style='background: #000000;'>OCCUPANCY</td>");
                        strHTML.Append("<td colspan='7' style='background: #008000;'>FINANCIAL INFORMATION</td>");
                        strHTML.Append("<td colspan='12' style='background-color: #9999FF; color: #FFFFFF'>FIRE INSPECTION COMPANY</td>");
                        strHTML.Append("<td colspan='13' style='background: #000084;'>SECURITY GUARD SERVICES</td>");
                        strHTML.Append("<td colspan='13' style='background: #FF6500;'>INTRUSION ALARM SERVICES</td>");
                        strHTML.Append("<td colspan='2' style='background: #840084;'>FENCE</td>");
                        strHTML.Append("<td colspan='3' style='background: #31CFCF;'>GENERATOR</td>");
                        strHTML.Append("<td colspan='2' style='background: #ff0000;'>FIRE DEPARTMENT</td>");
                        strHTML.Append("<td colspan='4' style='background: #ffff00;'></td>");
                        strHTML.Append("<td colspan='6' style='background: #31309C;'>CONSTRUCTION OF FLOORS (Yes to all apply)</td>");
                        strHTML.Append("<td colspan='6' style='background: #ff0000;'>CONSTRUCTION OF EXTERIOR WALLS (Yes to all apply)</td>");
                        strHTML.Append("<td colspan='3' style='background: #008284;'>MISC INFORMAION</td>");
                        strHTML.Append("</tr>");

                        strHTML.Append("<tr valign='bottom' align='left' style='font-weight: bold'>");


                        //LOCATION/ADDRESS INFORMATION 
                        strHTML.Append("<td width='150'>Region</td>");
                        strHTML.Append("<td width='150'>Sonic Location Code</td>");
                        strHTML.Append("<td width='150'>Location Name</td>");
                        strHTML.Append("<td width='150'>Legal Entity</td>");
                        strHTML.Append("<td width='150'>Federal Id</td>");
                        strHTML.Append("<td width='150'>Location Status</td>");
                        strHTML.Append("<td width='150'>Building #</td>");
                        strHTML.Append("<td width='150'>Building Status</td>");
                        strHTML.Append("<td width='200'>Address 1</td>");
                        strHTML.Append("<td width='200'>Address 2</td>");
                        strHTML.Append("<td width='150'>City</td>");
                        strHTML.Append("<td width='150'>State</td>");
                        strHTML.Append("<td width='150'>Zip Code</td>");
                        strHTML.Append("<td width='150'>County</td>");
                        strHTML.Append("<td width='150'>Owned/Leased/Sub Leased/Assigned/ Management Agreement</td>");

                        //OCCUPANCY
                        strHTML.Append("<td width='120'>Sales - New</td>");
                        strHTML.Append("<td width='120'>Sales - Used</td>");
                        strHTML.Append("<td width='120'>Services</td>");
                        strHTML.Append("<td width='120'>Body Shop</td>");
                        strHTML.Append("<td width='120'>Parts</td>");
                        strHTML.Append("<td width='120'>Office</td>");
                        strHTML.Append("<td width='120'>Parking Lot</td>");
                        strHTML.Append("<td width='120'>Row Land</td>");

                        //FINANCIAL INFORMATION
                        strHTML.Append("<td width='150'>Property Valuation Date</td>");
                        strHTML.Append("<td width='150'>RS Means Building Limit</td>");
                        strHTML.Append("<td width='150'>Associate Tools Limit</td>");
                        strHTML.Append("<td width='150'>Contents Limit</td>");
                        strHTML.Append("<td width='150'>Parts Limit</td>");
                        strHTML.Append("<td width='150' align='right'>Business Interruption</td>");
                        strHTML.Append("<td width='150'>Total</td>");

                        // Fire Inspection Company
                        strHTML.Append("<td width='150'>Contact Name</td>");
                        strHTML.Append("<td width='150'>Vendor Name</td>");
                        strHTML.Append("<td width='150'>Contract Expiration Date</td>");
                        strHTML.Append("<td width='150'>Address 1</td>");
                        strHTML.Append("<td width='150'>Address 2</td>");
                        strHTML.Append("<td width='150'>City</td>");
                        strHTML.Append("<td width='150'>State</td>");
                        strHTML.Append("<td width='150'>Zip</td>");
                        strHTML.Append("<td width='150'>Email</td>");
                        strHTML.Append("<td width='150'>Telephone Number</td>");
                        strHTML.Append("<td width='150'>Alternate Number</td>");
                        strHTML.Append("<td width='150'>Comments</td>");

                        //Security Guard Services
                        strHTML.Append("<td width='150'>System</td>");
                        strHTML.Append("<td width='150'>Vendor Name</td>");
                        strHTML.Append("<td width='150'>Address 1</td>");
                        strHTML.Append("<td width='150'>Address 2</td>");
                        strHTML.Append("<td width='150'>City</td>");
                        strHTML.Append("<td width='150'>State</td>");
                        strHTML.Append("<td width='150'>Zip</td>");
                        strHTML.Append("<td width='150'>Contact Name</td>");
                        strHTML.Append("<td width='150'>Contract Expiration Date</td>");
                        strHTML.Append("<td width='150'>Telephone Number</td>");
                        strHTML.Append("<td width='150'>Alternet Number</td>");
                        strHTML.Append("<td width='150'>email</td>");
                        strHTML.Append("<td width='150'>Comments</td>");


                        //INTRUSION ALARM SERVICES
                        strHTML.Append("<td width='150'>System</td>");
                        strHTML.Append("<td width='150'>Vendor Name</td>");
                        strHTML.Append("<td width='150'>Address 1</td>");
                        strHTML.Append("<td width='150'>Address 2</td>");
                        strHTML.Append("<td width='150'>City</td>");
                        strHTML.Append("<td width='150'>State</td>");
                        strHTML.Append("<td width='150'>Zip</td>");
                        strHTML.Append("<td width='150'>Contact Name</td>");
                        strHTML.Append("<td width='150'>Contract Expiration Date</td>");
                        strHTML.Append("<td width='150'>Telephone Number</td>");
                        strHTML.Append("<td width='150'>Alternet Number</td>");
                        strHTML.Append("<td width='150'>email</td>");
                        strHTML.Append("<td width='150'>Comments</td>");

                        //FENCE
                        strHTML.Append("<td width='150'>Razor Wire<br />YES/No</td>");
                        strHTML.Append("<td width='150'>Electrified<br />YES/No</td>");


                        //GENERATOR
                        strHTML.Append("<td width='150'>Make</td>");
                        strHTML.Append("<td width='150'>Model</td>");
                        strHTML.Append("<td width='150'>Size</td>");

                        //Fire Department
                        strHTML.Append("<td width='150'>Type (Paid/Part Paid/Volunteer)</td>");
                        strHTML.Append("<td width='150'>Distance - Miles</td>");


                        //___________________________
                        strHTML.Append("<td width='150'>Year Built</td>");
                        strHTML.Append("<td width='150'>Squre Footage</td>");
                        strHTML.Append("<td width='150'>Number of Floors</td>");
                        strHTML.Append("<td width='150'>% Sprink</td>");


                        //CONSTRUCTION OF FLOORS
                        strHTML.Append("<td width='150'>Reinforced Concrete</td>");
                        strHTML.Append("<td width='150'>Poured Concrete</td>");
                        strHTML.Append("<td width='150'>Concrete Panels</td>");
                        strHTML.Append("<td width='150'>Steel Deck</td>");
                        strHTML.Append("<td width='150'>Steel Deck Fastener</td>");
                        strHTML.Append("<td width='150'>Wood Joists</td>");

                        // CONSTRUCTION OF EXTERIOR WALLS
                        strHTML.Append("<td width='150'>Reinforced Concrete</td>");
                        strHTML.Append("<td width='150'>Tilt Up Concrete</td>");
                        strHTML.Append("<td width='150'>Masonry</td>");
                        strHTML.Append("<td width='150'>Glass and Steel Curtain</td>");
                        strHTML.Append("<td width='150'>Corrugated Metal Panels</td>");
                        strHTML.Append("<td width='150'>Wood Frame</td>");


                        //MISC INFORMAION 
                        strHTML.Append("<td width='150'>Number of Lifts</td>");
                        strHTML.Append("<td width='150'>Number of Paint Booths</td>");
                        strHTML.Append("<td width='300'>Other Building Comments</td>");

                        strHTML.Append("</tr>");

                        //Check Whether Record Exists or Not
                        if (dsResult != null && dsResult.Tables.Count > 0 && dsResult.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow dr in dsResult.Tables[0].Rows)
                            {
                                strHTML.Append("<tr valign='top' align='left'>");
                                //LOCATION/ADDRESS INFORMATION 
                                strHTML.Append("<td width='150'>" + Convert.ToString(dr["Region"]) + "</td>");
                                strHTML.Append("<td width='150'>" + Convert.ToString(dr["Sonic_Location_Code"]) + "</td>");
                                strHTML.Append("<td width='150'>" + Convert.ToString(dr["Location_Name"]) + "</td>");
                                strHTML.Append("<td width='150'>" + Convert.ToString(dr["Legal_Entity"]) + "</td>");
                                strHTML.Append("<td width='150'>" + Convert.ToString(dr["Federal_id"]) + "</td>");
                                strHTML.Append("<td width='150'>" + Convert.ToString(dr["Location_Status"]) + "</td>");
                                strHTML.Append("<td width='150'>" + Convert.ToString(dr["Building"]) + "</td>");
                                strHTML.Append("<td width='150'>" + Convert.ToString(dr["Building_Status"]) + "</td>");
                                strHTML.Append("<td width='200'>" + Convert.ToString(dr["Address1"]) + "</td>");
                                strHTML.Append("<td width='200'>" + Convert.ToString(dr["Address2"]) + "</td>");
                                strHTML.Append("<td width='150'>" + Convert.ToString(dr["City"]) + "</td>");
                                strHTML.Append("<td width='150'>" + Convert.ToString(dr["State"]) + "</td>");
                                strHTML.Append("<td width='150'>" + Convert.ToString(dr["Zip_Code"]) + "</td>");
                                strHTML.Append("<td width='150'>" + Convert.ToString(dr["County"]) + "</td>");
                                strHTML.Append("<td width='150'>" + Convert.ToString(dr["Ownership"]) + "</td>");


                                //OCCUPANCY
                                strHTML.Append("<td width='120'>" + Convert.ToString(dr["Sales_New"]) + "</td>");
                                strHTML.Append("<td width='120'>" + Convert.ToString(dr["Sales_Used"]) + "</td>");
                                strHTML.Append("<td width='120'>" + Convert.ToString(dr["Service"]) + "</td>");
                                strHTML.Append("<td width='120'>" + Convert.ToString(dr["Body_Shop"]) + "</td>");
                                strHTML.Append("<td width='120'>" + Convert.ToString(dr["Parts"]) + "</td>");
                                strHTML.Append("<td width='120'>" + Convert.ToString(dr["Office"]) + "</td>");
                                strHTML.Append("<td width='120'>" + Convert.ToString(dr["Parking_Lot"]) + "t</td>");
                                strHTML.Append("<td width='120'>" + Convert.ToString(dr["Raw_Land"]) + "</td>");

                                //FINANCIAL INFORMATION
                                strHTML.Append("<td width='150'>" + FormatDBNullDateToDisplay(dr["Property_Valuation_Date"]) + "</td>");
                                strHTML.Append("<td width='150'>" + GetStringValue(dr["Building_Limit"]) + "t</td>");
                                strHTML.Append("<td width='150'>" + GetStringValue(dr["Associate_Tools_Limit"]) + "</td>");
                                strHTML.Append("<td width='150'>" + GetStringValue(dr["Contents_Limit"]) + "</td>");
                                strHTML.Append("<td width='150'>" + GetStringValue(dr["Parts_Limit"]) + "</td>");
                                strHTML.Append("<td width='150' align='right'>" + String.Format("{0:C2}", dr["Business_Interruption"]) + "</td>");
                                strHTML.Append("<td width='150'>" + GetStringValue(dr["Total"]) + "</td>");

                                // Fire Inspection Company
                                strHTML.Append("<td width='150'>" + Convert.ToString(dr["Fire_Contact_Name"]) + "</td>");
                                strHTML.Append("<td width='150'>" + Convert.ToString(dr["Fire_Vendor_Name"]) + "</td>");
                                strHTML.Append("<td width='150'>" + FormatDBNullDateToDisplay(dr["Fire_Contact_Expiration_Date"]) + "</td>");
                                strHTML.Append("<td width='150'>" + Convert.ToString(dr["Fire_Address_1"]) + "</td>");
                                strHTML.Append("<td width='150'>" + Convert.ToString(dr["Fire_Address_2"]) + "</td>");
                                strHTML.Append("<td width='150'>" + Convert.ToString(dr["Fire_City"]) + "</td>");
                                strHTML.Append("<td width='150'>" + Convert.ToString(dr["Fire_State"]) + "</td>");
                                strHTML.Append("<td width='150'>" + Convert.ToString(dr["Fire_Zip"]) + "</td>");
                                strHTML.Append("<td width='150'>" + Convert.ToString(dr["Fire_Email"]) + "</td>");
                                strHTML.Append("<td width='150'>" + Convert.ToString(dr["Fire_Telephone_Number"]) + "</td>");
                                strHTML.Append("<td width='150'>" + Convert.ToString(dr["Fire_Alternate_Number"]) + "</td>");
                                strHTML.Append("<td width='150'>" + Convert.ToString(dr["Fire_Comments"]) + "</td>");

                                //Security Guard Services
                                strHTML.Append("<td width='150'>" + Convert.ToString(dr["System"]) + "</td>");
                                strHTML.Append("<td width='150'>" + Convert.ToString(dr["Vendor_Name"]) + "</td>");
                                strHTML.Append("<td width='150'>" + Convert.ToString(dr["Guard_Address_1"]) + "</td>");
                                strHTML.Append("<td width='150'>" + Convert.ToString(dr["Guard_Address_2"]) + "</td>");
                                strHTML.Append("<td width='150'>" + Convert.ToString(dr["Guard_City"]) + "</td>");
                                strHTML.Append("<td width='150'>" + Convert.ToString(dr["Guard_State"]) + "</td>");
                                strHTML.Append("<td width='150'>" + Convert.ToString(dr["Guard_Zip"]) + "</td>");
                                strHTML.Append("<td width='150'>" + Convert.ToString(dr["Contact_Name"]) + "</td>");
                                strHTML.Append("<td width='150'>" + FormatDBNullDateToDisplay(dr["Guard_Expiration_Date"]) + "</td>");
                                strHTML.Append("<td width='150'>" + Convert.ToString(dr["Guard_Telephone_Number"]) + "</td>");
                                strHTML.Append("<td width='150'>" + Convert.ToString(dr["Guard_Alternate_Number"]) + "</td>");
                                strHTML.Append("<td width='150'>" + Convert.ToString(dr["Guard_Email"]) + "</td>");
                                strHTML.Append("<td width='150'>" + Convert.ToString(dr["Guard_Comments"]) + "</td>");


                                //INTRUSION ALARM SERVICES
                                strHTML.Append("<td width='150'>" + Convert.ToString(dr["Intru_System_Name"]) + "</td>");
                                strHTML.Append("<td width='150'>" + Convert.ToString(dr["Intru_Vendor_Name"]) + "</td>");
                                strHTML.Append("<td width='150'>" + Convert.ToString(dr["Intru_Address_1"]) + "</td>");
                                strHTML.Append("<td width='150'>" + Convert.ToString(dr["Intru_Address_2"]) + "</td>");
                                strHTML.Append("<td width='150'>" + Convert.ToString(dr["Intru_City"]) + "</td>");
                                strHTML.Append("<td width='150'>" + Convert.ToString(dr["Intru_State"]) + "</td>");
                                strHTML.Append("<td width='150'>" + Convert.ToString(dr["Intru_Zip"]) + "</td>");
                                strHTML.Append("<td width='150'>" + Convert.ToString(dr["Intru_Contact_Name"]) + "</td>");
                                strHTML.Append("<td width='150'>" + FormatDBNullDateToDisplay(dr["Intru_Contract_Expiration_Date"]) + "</td>");
                                strHTML.Append("<td width='150'>" + Convert.ToString(dr["Intru_Telephone_Number"]) + "</td>");
                                strHTML.Append("<td width='150'>" + Convert.ToString(dr["Intru_Alternate_Number"]) + "</td>");
                                strHTML.Append("<td width='150'>" + Convert.ToString(dr["Intru_Email"]) + "</td>");
                                strHTML.Append("<td width='150'>" + Convert.ToString(dr["Intru_Comments"]) + "</td>");

                                //FENCE
                                strHTML.Append("<td width='150'>" + Convert.ToString(dr["Fence_Razor_Wire"]) + "</td>");
                                strHTML.Append("<td width='150'>" + Convert.ToString(dr["Fence_Electrified"]) + "</td>");


                                //GENERATOR
                                strHTML.Append("<td width='150'>" + Convert.ToString(dr["Generator_Make"]) + "</td>");
                                strHTML.Append("<td width='150'>" + Convert.ToString(dr["Generator_Model"]) + "</td>");
                                strHTML.Append("<td width='150'>" + Convert.ToString(dr["Generator_Size"]) + "</td>");

                                //Fire Department
                                strHTML.Append("<td width='150'>" + Convert.ToString(dr["Fire_Department_Type"]) + "</td>");
                                strHTML.Append("<td width='150'>" + Convert.ToString(dr["Fire_Department_Distance"]) + "</td>");


                                //___________________________
                                strHTML.Append("<td width='150'>" + Convert.ToString(dr["Year_Built"]) + "</td>");
                                strHTML.Append("<td width='150'>" + Convert.ToString(dr["Square_Footage"]) + "</td>");
                                strHTML.Append("<td width='150'>" + Convert.ToString(dr["Number_Of_Stories"]) + "</td>");
                                strHTML.Append("<td width='150'>" + Convert.ToString(dr["Percent_Sprinklered"]) + "</td>");

                                //CONSTRUCTION OF FLOORS
                                strHTML.Append("<td width='150'>" + Convert.ToString(dr["Roof_Reinforced_Concrete"]) + "</td>");
                                strHTML.Append("<td width='150'>" + Convert.ToString(dr["Roof_Poured_Concrete"]) + "</td>");
                                strHTML.Append("<td width='150'>" + Convert.ToString(dr["Roof_Concrete_Panels"]) + "</td>");
                                strHTML.Append("<td width='150'>" + Convert.ToString(dr["Roof_Steel_Deck"]) + "</td>");
                                strHTML.Append("<td width='150'>" + Convert.ToString(dr["Roof_Steel_Deck_With_Fasteners"]) + "</td>");
                                strHTML.Append("<td width='150'>" + Convert.ToString(dr["Roof_Wood_Joists"]) + "</td>");

                                // CONSTRUCTION OF EXTERIOR WALLS
                                strHTML.Append("<td width='150'>" + Convert.ToString(dr["Ext_Walls_Reinforced_Concrete"]) + "</td>");
                                strHTML.Append("<td width='150'>" + Convert.ToString(dr["Ext_Walls_Tilt_Up_Concrete"]) + "</td>");
                                strHTML.Append("<td width='150'>" + Convert.ToString(dr["Ext_Walls_Masonary"]) + "</td>");
                                strHTML.Append("<td width='150'>" + Convert.ToString(dr["Ext_Walls_Glass_And_Steel_Curtain"]) + "</td>");
                                strHTML.Append("<td width='150'>" + Convert.ToString(dr["Ext_Walls_Corrugated_Metal_Panels"]) + "</td>");
                                strHTML.Append("<td width='150'>" + Convert.ToString(dr["Ext_Walls_Wood_Frame"]) + "</td>");


                                //MISC INFORMAION 
                                strHTML.Append("<td width='150'>" + Convert.ToString(dr["Number_Of_Lifts"]) + "</td>");
                                strHTML.Append("<td width='150'>" + Convert.ToString(dr["Number_Of_Paint_Booths"]) + "</td>");
                                strHTML.Append("<td width='300'>" + Convert.ToString(dr["Comments"]) + "</td>");

                                strHTML.Append("</tr>");
                            }
                        }
                        else
                        {
                            //Add No record found line for year
                            strHTML.Append("<tr><td align='left' colspan='81'>No Record Found!</td></tr>");
                        }
                        strHTML.Append("</table>");

                        #endregion

                        //Write HTML in to HtmlWriter
                        htmlWrite.WriteLine(strHTML.ToString());

                        //Send Mail
                        SendMail("Property – Statement of Values Report", "ExposuresPropertyStatementofValuesReport.xls", strFirstName, strLastName, strMailFrom, stringWrite, dtRecipients);
                    }
                }
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("ERROR in Property – Statement of Values Report, " + ex.Message + " - " + ex.StackTrace.ToString() + " - " + ex.Source.ToString());
            }
        }

        //Report 38
        private void BindLeaseReport(DataRow drReportSchedule)
        {
            try
            {
                decimal pK_Schedule_ID = Convert.ToDecimal(drReportSchedule["PK_Schedule"]);
                decimal Fk_RecipientList = Convert.ToDecimal(drReportSchedule["Fk_RecipientList"]);
                decimal FK_Security_Id = Convert.ToDecimal(drReportSchedule["FK_Security_Id"]);

                //Get Report criteria for the scheduled report
                DataTable dtFilter = Report.SelectFilterCriteria(38, pK_Schedule_ID).Tables[0];
                if (dtFilter.Rows.Count > 0)
                {
                    //Get the recipient from the recipient list 
                    DataTable dtRecipients = Report.SelectOneRecordWithRecipientList(Fk_RecipientList).Tables[0];

                    //Get the user who has scheduled the report
                    DataTable dtUser = Report.SelectSecurityByPK(FK_Security_Id).Tables[0];

                    String strFirstName, strLastName, strMailFrom;
                    strFirstName = strLastName = strMailFrom = "";
                    if (dtUser.Rows.Count > 0)
                    {
                        strFirstName = Convert.ToString(dtUser.Rows[0]["FIRST_NAME"]).Trim();
                        strLastName = Convert.ToString(dtUser.Rows[0]["LAST_NAME"]).Trim();
                        strMailFrom = Convert.ToString(dtUser.Rows[0]["Email"]).Trim();

                        //Set all filters to a variable as per report type
                        DateTime? dtLCDFrom = null, dtLCDTo = null, dtLEDFrom = null, dtLEDTo = null;

                        string strRegion = Convert.ToString(dtFilter.Rows[0]["Region"]).Trim();
                        string strMarket = null;
                        if (!string.IsNullOrEmpty(Convert.ToString(dtFilter.Rows[0]["Market"])))
                        {
                            strMarket = Convert.ToString(dtFilter.Rows[0]["Market"]).Trim();
                        }
                        string strLeaseType = Convert.ToString(dtFilter.Rows[0]["LeaseType"]).Trim();
                        string strStatus = Convert.ToString(dtFilter.Rows[0]["Status"]).Trim();

                        if (!string.IsNullOrEmpty(Convert.ToString(dtFilter.Rows[0]["LCDFrom_Date"])))
                            dtLCDFrom = Convert.ToDateTime(dtFilter.Rows[0]["LCDFrom_Date"]);

                        if (!string.IsNullOrEmpty(Convert.ToString(dtFilter.Rows[0]["LCDTo_Date"])))
                            dtLCDTo = Convert.ToDateTime(dtFilter.Rows[0]["LCDTo_Date"]);

                        if (!string.IsNullOrEmpty(Convert.ToString(dtFilter.Rows[0]["LEDFrom_Date"])))
                            dtLEDFrom = Convert.ToDateTime(dtFilter.Rows[0]["LEDFrom_Date"]);

                        if (!string.IsNullOrEmpty(Convert.ToString(dtFilter.Rows[0]["LEDTo_Date"])))
                            dtLEDTo = Convert.ToDateTime(dtFilter.Rows[0]["LEDTo_Date"]);

                        //Create HTML for the report and wirte into HTML Write object
                        StringBuilder strHTML = new StringBuilder();
                        System.IO.StringWriter stringWrite = new System.IO.StringWriter();
                        System.Web.UI.HtmlTextWriter htmlWrite = new System.Web.UI.HtmlTextWriter(stringWrite);

                        #region "Search Criteria"

                        //Retrieve Market Values
                        string strMarketString = string.Empty;
                        if (string.IsNullOrEmpty(strMarket))
                        {
                            strMarketString = "All Market";
                        }
                        else
                        {
                            string[] strMar = strMarket.Split(Convert.ToChar(","));
                            for (int i = 0; i < strMar.Length; i++)
                            {
                                strMarketString += Report.SelectMarketInfoById(Convert.ToDecimal(strMar[i].ToString())).Tables[0].Rows[0]["Market"].ToString() + ",";
                            }
                            strMarketString = strMarketString.TrimEnd(',');
                        }

                        //Add Report Title and Schedule Date
                        strHTML.Append("<br />");
                        strHTML.Append("<b>Report Title : Lease Report</b>");
                        strHTML.Append("<br /><br />");
                        strHTML.Append("Schedule Date : " + Convert.ToDateTime(drReportSchedule["Scheduled_Date"]).ToString(DateDisplayFormat));
                        strHTML.Append("&nbsp;&nbsp;&nbsp;&nbsp;Schedule End Date : " + Convert.ToDateTime(drReportSchedule["Schedule_End_Date"]).ToString(DateDisplayFormat));
                        strHTML.Append("<br />");
                        strHTML.Append("Recurring Period : " + drReportSchedule["Recurring_Period"].ToString());
                        strHTML.Append("<br />");
                        strHTML.Append("Recurring Date : " + dtSchduleDate.ToString(DateDisplayFormat));

                        //Add Report Filter Criteria 
                        strHTML.Append("<br /><br />");
                        strHTML.Append("<b>Report Filters </b>");
                        strHTML.Append("<br /><br />");
                        strHTML.Append("Region        : " + strRegion.Replace("'", ""));
                        strHTML.Append("<br />");
                        strHTML.Append("Market        : " + strMarketString);
                        strHTML.Append("<br /><br />");
                        strHTML.Append("LCD From      : " + FormatDBNullDateToDisplay(dtLCDFrom));
                        strHTML.Append("<br />");
                        strHTML.Append("LCD To        : " + FormatDBNullDateToDisplay(dtLCDTo));
                        strHTML.Append("<br />");
                        strHTML.Append("LED From      : " + FormatDBNullDateToDisplay(dtLEDFrom));
                        strHTML.Append("<br />");
                        strHTML.Append("LED To        : " + FormatDBNullDateToDisplay(dtLEDTo));
                        strHTML.Append("<br />");
                        strHTML.Append("Building Status        : " + strStatus.Replace("'", ""));
                        strHTML.Append("<br /><br />");

                        #endregion

                        #region "Grid Data"

                        strHTML.Append("<table cellspacing='0' cellpadding='0' align='Left' border='0' style='width: 2200px; border-collapse: collapse;'>");
                        //Header Row
                        strHTML.Append("<tr align='left'><td align='left'>");
                        strHTML.Append("<table width='2035px' cellpadding='0' cellspacing='0' border='0'>");
                        strHTML.Append("<tr><td align='left'>");
                        strHTML.Append("<table width='2035px' cellpadding='0' cellspacing='0' border='1' style='font-weight: bold;'>");
                        strHTML.Append("<tr style='font-weight: bold;'>");
                        strHTML.Append("<td align='left' colspan='2'>Sonic Automotive</td>");
                        strHTML.Append("<td align='center' colspan='3'>Lease Report</td>");
                        strHTML.Append("<td align='right' colspan='6'>" + FormatDBNullDateToDisplay(DateTime.Now) + " </td>");
                        strHTML.Append("</tr>");

                        strHTML.Append("<tr style='font-weight: bold;'>");
                        strHTML.Append("<td align='left' style='width: 180px'>Location</td>");
                        strHTML.Append("<td align='left' style='width: 560px'>");
                        strHTML.Append("<table width='100%' cellpadding='0' cellspacing='0' border='1' style='font-weight: bold;'>");
                        strHTML.Append("<tr>");
                        strHTML.Append("<td align='left' style='width: 40%'>Building Address</td>");
                        strHTML.Append("<td align='left' style='width: 30%'>Building Number</td>");
                        strHTML.Append("<td align='left' style='width: 30%'>Building Landlord Name</td>");
                        strHTML.Append("</tr>");
                        strHTML.Append("</table>");
                        strHTML.Append("</td>");
                        strHTML.Append("<td align='left' style='width: 100px'>LCD</td>");
                        strHTML.Append("<td align='left' style='width: 100px'>LED</td>");
                        strHTML.Append("<td align='left' style='width: 100px'>LL Notify Date</td>");
                        strHTML.Append("<td align='left' style='width: 100px'>Reminder Date</td>");
                        strHTML.Append("<td align='left' style='width: 100px'>Review Date</td>");
                        strHTML.Append("<td align='right' style='width: 100px'>Monthly Rent</td>");
                        strHTML.Append("<td align='left' style='width: 180px'>Renewals</td>");
                        strHTML.Append("<td align='left' style='width: 180px'>Rent Details</td>");
                        strHTML.Append("<td align='left' style='width: 180px'>Rent Adjustments</td>");


                        strHTML.Append("</tr>");
                        strHTML.Append("</table>");
                        strHTML.Append("</td></tr>");
                        strHTML.Append("</table>");
                        strHTML.Append("</td></tr>");


                        //get the all Employee records by search criteria by group
                        DataSet dsDetails = Report.GetCriticalDatesReport(strRegion, strMarket, dtLCDFrom, dtLCDTo, dtLEDFrom, dtLEDTo, strStatus, "");

                        if (dsDetails != null && dsDetails.Tables.Count > 0 && dsDetails.Tables[0].Rows.Count > 0)
                        {
                            DataTable dtLocation = dsDetails.Tables[0];
                            DataTable dtDetails = dsDetails.Tables[0];

                            strHTML.Append("<tr align='left'><td align='left'>");
                            strHTML.Append("<table width='1675px' cellpadding='0' cellspacing='0' border='0'>");
                            strHTML.Append("<tr><td align='left'>");
                            strHTML.Append("<table cellspacing='0' cellpadding='0' align='Left' border='1' style='width: 100%; border-collapse: collapse;'>");

                            //foreach (DataRow dr in dtLocation.Rows)
                            //{

                            //DataRow[] drDetails = dtDetails.Select("DBA='" + dr["DBA"] + "'");
                            foreach (DataRow drDetail in dtDetails.Rows)
                            {

                                strHTML.Append("<tr>");
                                strHTML.Append("<td align='left' valign='top' style='width: 180px'>" + Convert.ToString(drDetail["DBA"]) + "</td>");
                                strHTML.Append("<td align='left' valign='top' style='width: 560px'>");
                                decimal _PK_RE_Information = Convert.ToDecimal(drDetail["PK_RE_Information"]);
                                DataTable dtBuilding = Report.SelectByFK_RE_Information(_PK_RE_Information).Tables[0];
                                if (dtBuilding.Rows.Count > 0)
                                {
                                    foreach (DataRow drBuilding in dtBuilding.Rows)
                                    {

                                        strHTML.Append("<table cellspacing='0' cellpadding='0' align='Left' border='1' style='width: 100%; border-collapse: collapse;'>");
                                        strHTML.Append("<tr>");
                                        strHTML.Append("<td align='left' valign='top' style='width:40%'>" + (drBuilding["Address"]) + "</td>");
                                        strHTML.Append("<td align='left' valign='top' style='width:30%'>" + Convert.ToString(drBuilding["Building_Number"]) + "</td>");
                                        strHTML.Append("<td align='left' valign='top' style='width:30%'>" + Convert.ToString(drBuilding["Landlord_Name"]) + "</td>");
                                        strHTML.Append("</tr>");
                                        strHTML.Append("</table>");

                                    }
                                }
                                else
                                {
                                    strHTML.Append("<table cellspacing='0' cellpadding='0' align='Left' border='1' style='width: 100%; border-collapse: collapse;'>");
                                    strHTML.Append("<tr>");
                                    strHTML.Append("<td align='left' valign='top' style='width:40%'>" + "" + "</td>");
                                    strHTML.Append("<td align='left' valign='top' style='width:30%'>" + "" + "</td>");
                                    strHTML.Append("<td align='left' valign='top' style='width:30%'>" + "" + "</td>");
                                    strHTML.Append("</tr>");
                                    strHTML.Append("</table>");
                                }
                                strHTML.Append("</td>");
                                strHTML.Append("<td align='left' valign='top' style='width: 100px'>" + FormatDBNullDateToDisplay(drDetail["LCD"]) + "</td>");
                                strHTML.Append("<td align='left' valign='top' style='width: 100px'>" + FormatDBNullDateToDisplay(drDetail["LED"]) + "</td>");
                                strHTML.Append("<td align='left' valign='top' style='width: 100px'>" + FormatDBNullDateToDisplay(drDetail["LLNotifyDate"]) + "</td>");
                                strHTML.Append("<td align='left' valign='top' style='width: 100px'>" + FormatDBNullDateToDisplay(drDetail["ReminderDate"]) + "</td>");
                                strHTML.Append("<td align='left' valign='top' style='width: 100px'>" + FormatDBNullDateToDisplay(drDetail["ReviewDate"]) + "</td>");
                                strHTML.Append("<td align='right' valign='top' style='width: 100px'>" + string.Format("{0:N2}", drDetail["MonthlyRent"] != DBNull.Value ? Convert.ToDecimal(drDetail["MonthlyRent"]) : 0) + "</td>");
                                strHTML.Append("<td align='left' valign='top' style='width: 180px'>" + Convert.ToString(drDetail["Renewals"]) + "</td>");
                                strHTML.Append("<td align='left' valign='top' style='width: 180px'>" + Convert.ToString(drDetail["Rent_Details"]) + "</td>");
                                strHTML.Append("<td align='left' valign='top' style='width: 180px'>" + Convert.ToString(drDetail["Rent_Adjustments"]) + "</td>");

                                strHTML.Append(" </tr>");
                            }
                            //}
                            strHTML.Append("</table>");
                            strHTML.Append("</td></tr>");
                            strHTML.Append("</table>");
                            strHTML.Append("</td></tr>");

                            //Footer Row
                            strHTML.Append("<tr align='left'><td align='left'>");
                            strHTML.Append("<table width='1675px' cellpadding='0' cellspacing='0' border='0'>");
                            strHTML.Append("<tr><td align='left'>");
                            strHTML.Append("<table width='1675px' cellpadding='4' cellspacing='0' border='1' style='font-weight: bold;background-color: #507CD1; color: White;'>");
                            strHTML.Append("<tr style='font-weight: bold;'>");
                            strHTML.Append("<td align='left' style='width: 180px'>Report Grand Totals</td>");
                            strHTML.Append("<td align='left' style='width: 560px'>" + Convert.ToString(dtDetails.Rows.Count) + " </td>");
                            strHTML.Append("<td align='left' style='width: 100px'>&nbsp;</td>");
                            strHTML.Append("<td align='left' style='width: 100px'>&nbsp;</td>");
                            strHTML.Append("<td align='left' style='width: 100px'>&nbsp;</td>");
                            strHTML.Append("<td align='left' style='width: 100px'>&nbsp;</td>");
                            strHTML.Append("<td align='left' style='width: 100px'>&nbsp;</td>");
                            strHTML.Append("<td align='right' style='width: 100px'>" + string.Format("{0:N2}", dtDetails.Compute("sum(MonthlyRent)", "")) + "</td>");
                            strHTML.Append("<td align='left' style='width: 180px'>&nbsp;</td>");
                            strHTML.Append("<td align='left' style='width: 180px'>&nbsp;</td>");
                            strHTML.Append("<td align='left' style='width: 180px'>&nbsp;</td>");
                            strHTML.Append("</tr>");
                            strHTML.Append("</table>");
                            strHTML.Append("</td></tr>");
                            strHTML.Append("</table>");
                            strHTML.Append("</td></tr>");
                        }
                        else
                        {
                            strHTML.Append("<tr> <td style='font-weight: bold;'> No Record Found.");
                            strHTML.Append("</td></tr>");
                        }

                        strHTML.Append("</table>");
                        #endregion

                        //Write HTML in to HtmlWriter
                        htmlWrite.WriteLine(strHTML.ToString());

                        //Send Mail
                        SendMail("Lease Report", "LeaseReport.xls", strFirstName, strLastName, strMailFrom, stringWrite, dtRecipients);
                    }
                }
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("ERROR in Lease Report, " + ex.Message);
            }
        }

        // Report 39
        private void BindMasterDealership(DataRow drReportSchedule)
        {
            try
            {
                decimal pK_Schedule_ID = Convert.ToDecimal(drReportSchedule["PK_Schedule"]);
                decimal Fk_RecipientList = Convert.ToDecimal(drReportSchedule["Fk_RecipientList"]);
                decimal FK_Security_Id = Convert.ToDecimal(drReportSchedule["FK_Security_Id"]);

                //Get Report criteria for the scheduled report
                DataTable dtFilter = Report.SelectFilterCriteria(39, pK_Schedule_ID).Tables[0];
                if (dtFilter.Rows.Count > 0)
                {
                    //Get the recipient from the recipient list 
                    DataTable dtRecipients = Report.SelectOneRecordWithRecipientList(Fk_RecipientList).Tables[0];

                    //Get the user who has scheduled the report
                    DataTable dtUser = Report.SelectSecurityByPK(FK_Security_Id).Tables[0];

                    String strFirstName, strLastName, strMailFrom;
                    strFirstName = strLastName = strMailFrom = "";
                    if (dtUser.Rows.Count > 0)
                    {
                        strFirstName = Convert.ToString(dtUser.Rows[0]["FIRST_NAME"]).Trim();
                        strLastName = Convert.ToString(dtUser.Rows[0]["LAST_NAME"]).Trim();
                        strMailFrom = Convert.ToString(dtUser.Rows[0]["Email"]).Trim();

                        //Set all filters to a variable as per report type
                        DateTime? dtLCDFrom = null, dtLCDTo = null, dtLEDFrom = null, dtLEDTo = null;

                        string strRegion = Convert.ToString(dtFilter.Rows[0]["Region"]).Trim();
                        string strMarket = null;
                        if (!string.IsNullOrEmpty(Convert.ToString(dtFilter.Rows[0]["Market"])))
                        {
                            strMarket = Convert.ToString(dtFilter.Rows[0]["Market"]).Trim();
                        }
                        string strLeaseType = Convert.ToString(dtFilter.Rows[0]["LeaseType"]).Trim();

                        if (dtFilter.Rows[0]["LCDFrom_Date"] != DBNull.Value)
                            dtLCDFrom = Convert.ToDateTime(dtFilter.Rows[0]["LCDFrom_Date"]);

                        if (Convert.ToString(dtFilter.Rows[0]["LCDTo_Date"]) != string.Empty && dtFilter.Rows[0]["LCDTo_Date"] != DBNull.Value)
                            dtLCDTo = Convert.ToDateTime(dtFilter.Rows[0]["LCDTo_Date"]);

                        if (Convert.ToString(dtFilter.Rows[0]["LEDFrom_Date"]) != string.Empty && dtFilter.Rows[0]["LEDFrom_Date"] != DBNull.Value)
                            dtLEDFrom = Convert.ToDateTime(dtFilter.Rows[0]["LEDFrom_Date"]);

                        if (Convert.ToString(dtFilter.Rows[0]["LEDTo_Date"]) != string.Empty && dtFilter.Rows[0]["LEDTo_Date"] != DBNull.Value)
                            dtLEDTo = Convert.ToDateTime(dtFilter.Rows[0]["LEDTo_Date"]);

                        //Get the all Unique records for Selected group (default - last name -sort) by search criteria
                        DataSet dsResult = Report.GetMasterDealership(strRegion, strMarket, dtLCDFrom, dtLCDTo, dtLEDFrom, dtLEDTo);

                        //Create HTML for the report and wirte into HTML Write object
                        StringBuilder strHTML = new StringBuilder();
                        System.IO.StringWriter stringWrite = new System.IO.StringWriter();
                        System.Web.UI.HtmlTextWriter htmlWrite = new System.Web.UI.HtmlTextWriter(stringWrite);

                        #region "Report Criteria"

                        //Retrieve Market Values
                        string strMarketString = string.Empty;
                        if (string.IsNullOrEmpty(strMarket))
                        {
                            strMarketString = "All Market";
                        }
                        else
                        {
                            string[] strMar = strMarket.Split(Convert.ToChar(","));
                            for (int i = 0; i < strMar.Length; i++)
                            {
                                strMarketString += Report.SelectMarketInfoById(Convert.ToDecimal(strMar[i].ToString())).Tables[0].Rows[0]["Market"].ToString() + ",";
                            }
                            strMarketString = strMarketString.TrimEnd(',');
                        }

                        //Add Report Title and Schedule Date
                        strHTML.Append("<br />");
                        strHTML.Append("<b>Report Title : Master Dealership </b>");
                        strHTML.Append("<br /><br />");
                        strHTML.Append("Schedule Date : " + Convert.ToDateTime(drReportSchedule["Scheduled_Date"]).ToString(DateDisplayFormat));
                        strHTML.Append("&nbsp;&nbsp;&nbsp;&nbsp;Schedule End Date : " + Convert.ToDateTime(drReportSchedule["Schedule_End_Date"]).ToString(DateDisplayFormat));
                        strHTML.Append("<br />");
                        strHTML.Append("Recurring Period : " + drReportSchedule["Recurring_Period"].ToString());
                        strHTML.Append("<br />");
                        strHTML.Append("Recurring Date : " + dtSchduleDate.ToString(DateDisplayFormat));

                        //Add Report Filter Criteria 
                        strHTML.Append("<br /><br />");
                        strHTML.Append("<b>Report Filters </b>");
                        strHTML.Append("<br /><br />");
                        strHTML.Append("Region        : " + strRegion.Replace("'", ""));
                        strHTML.Append("<br />");
                        strHTML.Append("Market        : " + strMarketString);
                        strHTML.Append("<br />");
                        strHTML.Append("LCD From      : " + FormatDBNullDateToDisplay(dtLCDFrom));
                        strHTML.Append("<br />");
                        strHTML.Append("LCD To        : " + FormatDBNullDateToDisplay(dtLCDTo));
                        strHTML.Append("<br />");
                        strHTML.Append("LED From      : " + FormatDBNullDateToDisplay(dtLEDFrom));
                        strHTML.Append("<br />");
                        strHTML.Append("LED To        : " + FormatDBNullDateToDisplay(dtLEDTo));
                        strHTML.Append("<br /><br />");

                        #endregion

                        #region "Report Grid header"

                        strHTML.Append("<table border='1'>");
                        strHTML.Append("<tr style='font-weight: bold' valign='bottom' align='left'>");
                        strHTML.Append("<td align='left' colspan='2'>Sonic Automotive</td>");
                        strHTML.Append("<td align='center' colspan='5'>Master Dealership </td>");
                        strHTML.Append("<td align='right' colspan='5'>" + FormatDBNullDateToDisplay(DateTime.Now) + "&nbsp;</td>");
                        strHTML.Append("</tr>");
                        strHTML.Append("<tr valign='bottom' align='left' style='font-weight: bold'>");
                        strHTML.Append("<td>Location  </td>");
                        strHTML.Append("<td align='left' style='width: 360px'>");
                        strHTML.Append("<table width='100%' cellpadding='0' cellspacing='0' border='1' style='font-weight: bold;'>");
                        strHTML.Append("<tr>");
                        strHTML.Append("<td align='left' style='width: 30%'>Building Number</td>");
                        strHTML.Append("<td align='left' style='width: 70%'>Building Address</td>");
                        strHTML.Append("</tr>");
                        strHTML.Append("</table>");
                        strHTML.Append("</td>");
                        strHTML.Append("<td>City </td>");
                        strHTML.Append("<td>State </td>");
                        strHTML.Append("<td>Zip  </td>");
                        strHTML.Append("<td>LCD </td>");
                        strHTML.Append("<td>LED </td>");
                        strHTML.Append("<td>Renewals </td>");
                        strHTML.Append("<td>Building Landlord Name </td>");
                        strHTML.Append("<td  align='center'>Monthly Rent </td>");
                        strHTML.Append("<td>Subtenant </td>");
                        strHTML.Append("<td align='center'>Subtenant Monthly Rent </td>");
                        strHTML.Append("</tr>");

                        // set Location Table 
                        //DataTable dtLocation = dsResult.Tables[0];

                        // Check if record is exist for location
                        // if (dtLocation.Rows.Count > 0)
                        //{
                        // loop for all location
                        // foreach (DataRow drLocation in dtLocation.Rows)
                        //{
                        // filter Reprot Result by Locaion ID
                        DataTable dtReportDetail = dsResult.Tables[0];
                        //dtReportDetail.DefaultView.RowFilter = " Region = '" + drLocation["Region"].ToString() + "'";
                        // dtReportDetail.DefaultView.Sort = "Region";
                        //dtReportDetail = dtReportDetail.DefaultView.ToTable();

                        // display location for filter
                        //strHTML.Append("<tr valign='top' align='left'>");
                        //strHTML.Append("<td colspan='10' align-'left'><b> Region : " + Convert.ToString(drLocation["Region"]) + "</b></td>");
                        //strHTML.Append("</tr>");

                        // print Report Detail
                        if (dtReportDetail.Rows.Count > 0)
                        {
                            // display record for Location
                            foreach (DataRow drReport in dtReportDetail.Rows)
                            {
                                strHTML.Append("<tr valign='top' align='left'>");
                                strHTML.Append("<td> " + Convert.ToString(drReport["DBA"]) + " </td>");
                                strHTML.Append("<td align='left' valign='top' style='width: 360px'>");
                                decimal _PK_RE_Information = Convert.ToDecimal(drReport["PK_RE_Information"]);
                                DataTable dtBuilding = Report.SelectByFK_RE_Information(_PK_RE_Information).Tables[0];
                                if (dtBuilding.Rows.Count > 0)
                                {
                                    foreach (DataRow drBuilding in dtBuilding.Rows)
                                    {

                                        strHTML.Append("<table cellspacing='0' cellpadding='0' align='Left' border='1' style='width: 100%; border-collapse: collapse;'>");
                                        strHTML.Append("<tr>");
                                        strHTML.Append("<td align='left' valign='top' style='width:30%'>" + Convert.ToString(drBuilding["Building_Number"]) + "</td>");
                                        strHTML.Append("<td align='left' valign='top' style='width:70%'>" + (drBuilding["Address"]) + "</td>");
                                        strHTML.Append("</tr>");
                                        strHTML.Append("</table>");
                                    }
                                }
                                else
                                {
                                    strHTML.Append("<table cellspacing='0' cellpadding='0' align='Left' border='1' style='width: 100%; border-collapse: collapse;'>");
                                    strHTML.Append("<tr>");
                                    strHTML.Append("<td align='left' valign='top' style='width:30%'>" + "" + "</td>");
                                    strHTML.Append("<td align='left' valign='top' style='width:70%'>" + "" + "</td>");
                                    strHTML.Append("</tr>");
                                    strHTML.Append("</table>");
                                }
                                strHTML.Append("</td>");
                                strHTML.Append("<td> " + Convert.ToString(drReport["CITY"]) + " </td>");
                                strHTML.Append("<td> " + Convert.ToString(drReport["STATE"]) + " </td>");
                                strHTML.Append("<td> " + Convert.ToString(drReport["ZIP"]) + " </td>");
                                strHTML.Append("<td> " + FormatDBNullDateToDisplay(drReport["LCD"]) + " </td>");
                                strHTML.Append("<td> " + FormatDBNullDateToDisplay(drReport["LED"]) + " </td>");
                                strHTML.Append("<td> " + Convert.ToString(drReport["Renewals"]) + " </td>");
                                strHTML.Append("<td> " + Convert.ToString(drReport["Landlord_Name"]) + " </td>");
                                strHTML.Append("<td align='right'> " + string.Format("{0:N0}", drReport["MonthlyRent"]) + " </td>");
                                strHTML.Append("<td> " + Convert.ToString(drReport["Subtenant"]) + " </td>");
                                strHTML.Append("<td align='right'> " + string.Format("{0:N0}", drReport["SubtenantMonthlyRent"]) + " </td>");
                                strHTML.Append("</tr>");
                            }

                            // print Sub Total by Location
                            //strHTML.Append("<tr valign='top' align='left' style='font-weight: bold;'>");
                            //strHTML.Append("<td> Sub Total </td>");
                            //strHTML.Append("<td>" + dtReportDetail.Rows.Count.ToString() + "</td>");
                            //strHTML.Append("<td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td>");
                            //strHTML.Append("<td align='right'> " + string.Format("{0:N0}", dtReportDetail.Compute("SUM(MonthlyRent)", "")) + " </td>");
                            //strHTML.Append("<td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td>");
                            //strHTML.Append("</tr>");
                        }
                        else
                        {
                            //Add No record found line for year
                            strHTML.Append("<tr><td align='left' colspan='10'>No Record Found!</td></tr>");
                        }

                        //}

                        // print Grand Total for Whole Report
                        strHTML.Append("<tr valign='top' align='left' style='font-weight: bold; background-color: #507CD1;color: White;'>");
                        strHTML.Append("<td> Grand Total </td>");
                        strHTML.Append("<td>" + dsResult.Tables[0].Rows.Count.ToString() + "</td>");
                        strHTML.Append("<td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td>");
                        strHTML.Append("<td align='right'> " + string.Format("{0:N0}", dsResult.Tables[0].Compute("SUM(MonthlyRent)", "")) + " </td>");
                        strHTML.Append("<td>&nbsp;</td><td align='right'> " + string.Format("{0:N0}", dsResult.Tables[0].Compute("SUM(SubtenantMonthlyRent)", "")) + " </td>");
                        strHTML.Append("</tr>");

                        //}
                        strHTML.Append("</table>");
                        #endregion

                        //Write HTML in to HtmlWriter
                        htmlWrite.WriteLine(strHTML.ToString());

                        //Send Mail
                        SendMail("Master Dealership Report", "MasterDealershipReport.xls", strFirstName, strLastName, strMailFrom, stringWrite, dtRecipients);
                    }
                }
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("ERROR in Master Dealership Report, " + ex.Message + " - " + ex.StackTrace.ToString() + " - " + ex.Source.ToString());
            }
        }

        // Report 40
        private void BindLandlordInfoReport(DataRow drReportSchedule)
        {
            {
                decimal pK_Schedule_ID = Convert.ToDecimal(drReportSchedule["PK_Schedule"]);
                decimal Fk_RecipientList = Convert.ToDecimal(drReportSchedule["Fk_RecipientList"]);
                decimal FK_Security_Id = Convert.ToDecimal(drReportSchedule["FK_Security_Id"]);

                //Get Report criteria for the scheduled report
                DataTable dtFilter = Report.SelectFilterCriteria(40, pK_Schedule_ID).Tables[0];
                if (dtFilter.Rows.Count > 0)
                {
                    //Get the recipient from the recipient list 
                    DataTable dtRecipients = Report.SelectOneRecordWithRecipientList(Fk_RecipientList).Tables[0];

                    //Get the user who has scheduled the report
                    DataTable dtUser = Report.SelectSecurityByPK(FK_Security_Id).Tables[0];

                    String strFirstName, strLastName, strMailFrom;
                    strFirstName = strLastName = strMailFrom = "";
                    if (dtUser.Rows.Count > 0)
                    {
                        strFirstName = Convert.ToString(dtUser.Rows[0]["FIRST_NAME"]).Trim();
                        strLastName = Convert.ToString(dtUser.Rows[0]["LAST_NAME"]).Trim();
                        strMailFrom = Convert.ToString(dtUser.Rows[0]["Email"]).Trim();

                        //Set all filters to a variable as per report type
                        DateTime? dtLCDFrom = null, dtLCDTo = null, dtLEDFrom = null, dtLEDTo = null;

                        string strRegion = Convert.ToString(dtFilter.Rows[0]["Region"]).Trim();
                        string strMarket = null;
                        if (!string.IsNullOrEmpty(Convert.ToString(dtFilter.Rows[0]["Market"])))
                        {
                            strMarket = Convert.ToString(dtFilter.Rows[0]["Market"]).Trim();
                        }

                        if (dtFilter.Rows[0]["LCDFrom_Date"] != DBNull.Value)
                            dtLCDFrom = Convert.ToDateTime(dtFilter.Rows[0]["LCDFrom_Date"]);

                        if (Convert.ToString(dtFilter.Rows[0]["LCDTo_Date"]) != string.Empty && dtFilter.Rows[0]["LCDTo_Date"] != DBNull.Value)
                            dtLCDTo = Convert.ToDateTime(dtFilter.Rows[0]["LCDTo_Date"]);

                        if (Convert.ToString(dtFilter.Rows[0]["LEDFrom_Date"]) != string.Empty && dtFilter.Rows[0]["LEDFrom_Date"] != DBNull.Value)
                            dtLEDFrom = Convert.ToDateTime(dtFilter.Rows[0]["LEDFrom_Date"]);

                        if (Convert.ToString(dtFilter.Rows[0]["LEDTo_Date"]) != string.Empty && dtFilter.Rows[0]["LEDTo_Date"] != DBNull.Value)
                            dtLEDTo = Convert.ToDateTime(dtFilter.Rows[0]["LEDTo_Date"]);

                        //Get the all Unique records for Selected group (default - last name -sort) by search criteria
                        DataSet dsResult = Report.GetLandlordInfoReport(strRegion, strMarket, dtLCDFrom, dtLCDTo, dtLEDFrom, dtLEDTo);

                        //Create HTML for the report and wirte into HTML Write object
                        StringBuilder strHTML = new StringBuilder();
                        System.IO.StringWriter stringWrite = new System.IO.StringWriter();
                        System.Web.UI.HtmlTextWriter htmlWrite = new System.Web.UI.HtmlTextWriter(stringWrite);

                        #region "Report Criteria"

                        //Retrieve Market Values
                        string strMarketString = string.Empty;
                        if (string.IsNullOrEmpty(strMarket))
                        {
                            strMarketString = "All Market";
                        }
                        else
                        {
                            string[] strMar = strMarket.Split(Convert.ToChar(","));
                            for (int i = 0; i < strMar.Length; i++)
                            {
                                strMarketString += Report.SelectMarketInfoById(Convert.ToDecimal(strMar[i].ToString())).Tables[0].Rows[0]["Market"].ToString() + ",";
                            }
                            strMarketString = strMarketString.TrimEnd(',');
                        }

                        //Add Report Title and Schedule Date
                        strHTML.Append("<br />");
                        strHTML.Append("<b>Report Title : Landlord Report </b>");
                        strHTML.Append("<br /><br />");
                        strHTML.Append("Schedule Date : " + Convert.ToDateTime(drReportSchedule["Scheduled_Date"]).ToString(DateDisplayFormat));
                        strHTML.Append("&nbsp;&nbsp;&nbsp;&nbsp;Schedule End Date : " + Convert.ToDateTime(drReportSchedule["Schedule_End_Date"]).ToString(DateDisplayFormat));
                        strHTML.Append("<br />");
                        strHTML.Append("Recurring Period : " + drReportSchedule["Recurring_Period"].ToString());
                        strHTML.Append("<br />");
                        strHTML.Append("Recurring Date : " + dtSchduleDate.ToString(DateDisplayFormat));

                        //Add Report Filter Criteria 
                        strHTML.Append("<br /><br />");
                        strHTML.Append("<b>Report Filters </b>");
                        strHTML.Append("<br /><br />");
                        strHTML.Append("Region        : " + strRegion.Replace("'", ""));
                        strHTML.Append("<br />");
                        strHTML.Append("Market        : " + strMarketString);
                        strHTML.Append("<br /><br />");
                        strHTML.Append("LCD From      : " + FormatDBNullDateToDisplay(dtLCDFrom));
                        strHTML.Append("<br />");
                        strHTML.Append("LCD To        : " + FormatDBNullDateToDisplay(dtLCDTo));
                        strHTML.Append("<br />");
                        strHTML.Append("LED From      : " + FormatDBNullDateToDisplay(dtLEDFrom));
                        strHTML.Append("<br />");
                        strHTML.Append("LED To        : " + FormatDBNullDateToDisplay(dtLEDTo));
                        strHTML.Append("<br /><br />");

                        #endregion

                        #region "Report Grid header"

                        strHTML.Append("<table border='1'>");
                        strHTML.Append("<tr style='font-weight: bold' valign='bottom' align='left'>");
                        strHTML.Append("<td align='left' colspan='2'>Sonic Automotive</td>");
                        strHTML.Append("<td align='center' colspan='7'>Landlord Report</td>");
                        strHTML.Append("<td align='right' colspan='6'>" + DateTime.Now.ToString() + "</td>");
                        strHTML.Append("</tr>");
                        strHTML.Append("<tr valign='bottom' align='left' style='font-weight: bold'>");
                        strHTML.Append("<td> Location</td>");
                        strHTML.Append("<td align='left' style='width: 400px'>");
                        strHTML.Append("<table width='100%' cellpadding='0' cellspacing='0' border='1' style='font-weight: bold;'>");
                        strHTML.Append("<tr>");
                        strHTML.Append("<td align='left' style='width: 30%'>Building Number</td>");
                        strHTML.Append("<td align='left' style='width: 70%'>Building Address</td>");
                        strHTML.Append("</tr>");
                        strHTML.Append("</table>");
                        strHTML.Append("</td>");
                        strHTML.Append("<td> City</td>");
                        strHTML.Append("<td> State</td>");
                        strHTML.Append("<td> Zip</td>");
                        strHTML.Append("<td> LCD</td>");
                        strHTML.Append("<td> LED</td>");
                        strHTML.Append("<td> Renewals</td>");
                        strHTML.Append("<td> Building Landlord Name</td>");
                        strHTML.Append("<td> Address 1</td>");
                        strHTML.Append("<td> Address 2</td>");
                        strHTML.Append("<td> City</td>");
                        strHTML.Append("<td> State</td>");
                        strHTML.Append("<td> Zip</td>");
                        strHTML.Append("<td> Phone</td>");
                        strHTML.Append("</tr>");

                        // set Location Table 
                        // DataTable dtLocation = dsResult.Tables[0];

                        // Check if record is exist for location
                        // if (dtLocation.Rows.Count > 0)
                        //{
                        // loop for all location

                        // filter Reprot Result by Locaion ID
                        DataTable dtReportDetail = dsResult.Tables[0];


                        //dtReportDetail.DefaultView.RowFilter = " PK_LU_Location_Id = " + drLocation["PK_LU_Location_Id"].ToString();
                        //dtReportDetail.DefaultView.Sort = "DBA";
                        //dtReportDetail = dtReportDetail.DefaultView.ToTable();

                        // display location for filter
                        //strHTML.Append("<tr valign='top' align='left'>");
                        //strHTML.Append("<td colspan='15' align-'left'><b> Location : " + Convert.ToString(drLocation["dba"]) + "</b></td>");
                        //strHTML.Append("</tr>");

                        // print Report Detail
                        if (dtReportDetail.Rows.Count > 0)
                        {
                            // display record for Location
                            foreach (DataRow drReport in dtReportDetail.Rows)
                            {
                                strHTML.Append("<tr valign='top' align='left'>");
                                strHTML.Append("<td> " + Convert.ToString(drReport["DBA"]) + " </td>");
                                strHTML.Append("<td align='left' valign='top' style='width: 400px'>");
                                decimal _PK_RE_Information = Convert.ToDecimal(drReport["PK_RE_Information"]);
                                DataTable dtBuilding = Report.SelectByFK_RE_Information(_PK_RE_Information).Tables[0];
                                if (dtBuilding.Rows.Count > 0)
                                {
                                    foreach (DataRow drBuilding in dtBuilding.Rows)
                                    {

                                        strHTML.Append("<table cellspacing='0' cellpadding='0' align='Left' border='1' style='width: 100%; border-collapse: collapse;'>");
                                        strHTML.Append("<tr>");
                                        strHTML.Append("<td align='left' valign='top' style='width:30%'>" + Convert.ToString(drBuilding["Building_Number"]) + "</td>");
                                        strHTML.Append("<td align='left' valign='top' style='width:70%'>" + (drBuilding["Address"]) + "</td>");
                                        strHTML.Append("</tr>");
                                        strHTML.Append("</table>");
                                    }
                                }
                                else
                                {
                                    strHTML.Append("<table cellspacing='0' cellpadding='0' align='Left' border='1' style='width: 100%; border-collapse: collapse;'>");
                                    strHTML.Append("<tr>");
                                    strHTML.Append("<td align='left' valign='top' style='width:30%'>" + "" + "</td>");
                                    strHTML.Append("<td align='left' valign='top' style='width:70%'>" + "" + "</td>");
                                    strHTML.Append("</tr>");
                                    strHTML.Append("</table>");
                                }
                                strHTML.Append("</td>");
                                strHTML.Append("<td> " + Convert.ToString(drReport["City"]) + " </td>");
                                strHTML.Append("<td> " + Convert.ToString(drReport["State"]) + " </td>");
                                strHTML.Append("<td> " + Convert.ToString(drReport["Zip"]) + " </td>");
                                strHTML.Append("<td> " + (drReport["Lease_Commencement_Date"] != DBNull.Value ? Convert.ToDateTime(drReport["Lease_Commencement_Date"]) == System.Data.SqlTypes.SqlDateTime.MinValue ? "" : string.Format("{0:MM/dd/yyyy}", drReport["Lease_Commencement_Date"]) : "") + " </td>");
                                strHTML.Append("<td> " + (drReport["Lease_Expiration_Date"] != DBNull.Value ? Convert.ToDateTime(drReport["Lease_Expiration_Date"]) == System.Data.SqlTypes.SqlDateTime.MinValue ? "" : string.Format("{0:MM/dd/yyyy}", drReport["Lease_Expiration_Date"]) : "") + " </td>");
                                strHTML.Append("<td> " + Convert.ToString(drReport["Renewals"]) + " </td>");
                                strHTML.Append("<td> " + Convert.ToString(drReport["Landlord_Name"]) + " </td>");
                                strHTML.Append("<td> " + Convert.ToString(drReport["Landlord_Address_1"]) + " </td>");
                                strHTML.Append("<td> " + Convert.ToString(drReport["Landlord_Address_2"]) + " </td>");
                                strHTML.Append("<td> " + Convert.ToString(drReport["Landlord_City"]) + " </td>");
                                strHTML.Append("<td> " + Convert.ToString(drReport["Landlord_State"]) + " </td>");
                                strHTML.Append("<td> " + Convert.ToString(drReport["Landlord_Zip"]) + " </td>");
                                strHTML.Append("<td> " + Convert.ToString(drReport["Landlord_Telephone"]) + " </td>");
                                strHTML.Append("</tr>");
                            }

                            //// print Sub Total by Location
                            //strHTML.Append("<tr valign='top' align='left' style='font-weight: bold;'>");
                            //strHTML.Append("<td> Total </td>");
                            //strHTML.Append("<td>" + dtReportDetail.Rows.Count.ToString() + "</td>");
                            //strHTML.Append("<td> <td> <td> <td> <td> <td><td><td><td> <td><td><td><td></td><td></td>");
                            //strHTML.Append("</tr>");
                        }
                        else
                        {
                            //Add No record found line for year
                            strHTML.Append("<tr><td align='left' colspan='15'>No Record Found!</td></tr>");
                        }


                        // print Grand Total for Whole Report
                        strHTML.Append("<tr valign='top' align='left' style='font-weight: bold; background-color: #507CD1;color: White;'>");
                        strHTML.Append("<td> Grand Total </td>");
                        strHTML.Append("<td>" + dsResult.Tables[0].Rows.Count.ToString() + "</td>");
                        strHTML.Append("<td colspan='13'>&nbsp; </td> ");
                        strHTML.Append("</tr>");

                        //}
                        strHTML.Append("</table>");
                        #endregion

                        //Write HTML in to HtmlWriter
                        htmlWrite.WriteLine(strHTML.ToString());

                        //Send Mail
                        SendMail("Landlord Report", "LandlordReport.xls", strFirstName, strLastName, strMailFrom, stringWrite, dtRecipients);
                    }
                }
            }
        }

        // Report 41
        private void BindPolicyInsuranceScheduleReport(DataRow drReportSchedule)
        {
            decimal pK_Schedule_ID = Convert.ToDecimal(drReportSchedule["PK_Schedule"]);
            decimal Fk_RecipientList = Convert.ToDecimal(drReportSchedule["Fk_RecipientList"]);
            decimal FK_Security_Id = Convert.ToDecimal(drReportSchedule["FK_Security_Id"]);

            //Get Report criteria for the scheduled report
            DataTable dtFilter = Report.SelectFilterCriteria(41, pK_Schedule_ID).Tables[0];
            if (dtFilter.Rows.Count > 0)
            {
                //Get the recipient from the recipient list 
                DataTable dtRecipients = Report.SelectOneRecordWithRecipientList(Fk_RecipientList).Tables[0];

                //Get the user who has scheduled the report
                DataTable dtUser = Report.SelectSecurityByPK(FK_Security_Id).Tables[0];

                String strFirstName, strLastName, strMailFrom;
                strFirstName = strLastName = strMailFrom = "";
                if (dtUser.Rows.Count > 0)
                {
                    strFirstName = Convert.ToString(dtUser.Rows[0]["FIRST_NAME"]).Trim();
                    strLastName = Convert.ToString(dtUser.Rows[0]["LAST_NAME"]).Trim();
                    strMailFrom = Convert.ToString(dtUser.Rows[0]["Email"]).Trim();

                    //Set all filters to a variable as per report type
                    int? intPolicyYear = null;
                    string strProgramIDs = "";
                    string strPolicyTypes = "";


                    if (dtFilter.Rows[0]["Policy_Year"] != DBNull.Value)
                        intPolicyYear = Convert.ToInt32(dtFilter.Rows[0]["Policy_Year"]);

                    if (!string.IsNullOrEmpty(Convert.ToString(dtFilter.Rows[0]["ProgramID"])))
                        strProgramIDs = Convert.ToString(dtFilter.Rows[0]["ProgramID"]);

                    if (!string.IsNullOrEmpty(Convert.ToString(dtFilter.Rows[0]["PolicyType"])))
                        strPolicyTypes = Convert.ToString(dtFilter.Rows[0]["PolicyType"]);

                    //Get the all Unique records for Selected group (default - last name -sort) by search criteria
                    DataSet dsResult = Report.GetInsuranceSchedule(intPolicyYear, strProgramIDs, strPolicyTypes);

                    //Create HTML for the report and wirte into HTML Write object
                    StringBuilder strHTML = new StringBuilder();
                    System.IO.StringWriter stringWrite = new System.IO.StringWriter();
                    System.Web.UI.HtmlTextWriter htmlWrite = new System.Web.UI.HtmlTextWriter(stringWrite);

                    #region "Report Criteria"

                    //Add Report Title and Schedule Date
                    strHTML.Append("<br />");
                    strHTML.Append("<b>Report Title : Insurance Schedule </b>");
                    strHTML.Append("<br /><br />");
                    strHTML.Append("Schedule Date : " + Convert.ToDateTime(drReportSchedule["Scheduled_Date"]).ToString(DateDisplayFormat));
                    strHTML.Append("&nbsp;&nbsp;&nbsp;&nbsp;Schedule End Date : " + Convert.ToDateTime(drReportSchedule["Schedule_End_Date"]).ToString(DateDisplayFormat));
                    strHTML.Append("<br />");
                    strHTML.Append("Recurring Period : " + drReportSchedule["Recurring_Period"].ToString());
                    strHTML.Append("<br />");
                    strHTML.Append("Recurring Date : " + dtSchduleDate.ToString(DateDisplayFormat));

                    //Add Report Filter Criteria 
                    strHTML.Append("<br /><br />");
                    strHTML.Append("<b>Report Filters </b>");
                    strHTML.Append("<br /><br />");
                    strHTML.Append("Policy Year         : " + (intPolicyYear > 0 ? intPolicyYear.ToString() : string.Empty));
                    strHTML.Append("<br />");
                    strHTML.Append("Program             : " + Report.SelectPrograms(strProgramIDs));
                    strHTML.Append("<br />");
                    strHTML.Append("Policy Type         : " + Report.SelectPolicyTypes(strPolicyTypes));
                    strHTML.Append("<br /><br />");

                    #endregion

                    #region "Report Grid header"

                    strHTML.Append("<table border='1'>");
                    strHTML.Append("<tr style='font-weight: bold' valign='bottom' align='left'>");
                    strHTML.Append("<td align='left' colspan='2'>Sonic Automotive</td>");
                    strHTML.Append("<td align='center' colspan='13'>Insurance Schedule</td>");
                    strHTML.Append("<td align='right' colspan='3'>" + (intPolicyYear > 0 ? intPolicyYear.ToString() : string.Empty) + "</td>");
                    strHTML.Append("</tr>");
                    strHTML.Append("<tr valign='bottom' align='left' style='font-weight: bold'>");
                    strHTML.Append("<td align='left' width='125px'>Program</td>");
                    strHTML.Append("<td align='left' width='200px'>Policy Type</td>");
                    strHTML.Append("<td align='left' width='150px'>Layer</td>");
                    strHTML.Append("<td align='left' width='150px'>Insurance Carrier</td>");
                    strHTML.Append("<td align='left' width='150px'>Policy Number</td>");
                    strHTML.Append("<td align='left' width='150px'>Policy Effective Date</td>");
                    strHTML.Append("<td align='left' width='150px'>Policy Expiration Date</td>");
                    strHTML.Append("<td align='left' width='125px'>Coverage Form</td>");
                    strHTML.Append("<td align='right' width='130px'>Per Occurrence Limit $</td>");
                    strHTML.Append("<td align='right' width='125px'>Aggregate Limit $</td>");
                    strHTML.Append("<td align='right' width='125px'>Underlying Limit $</td>");
                    strHTML.Append("<td align='right' width='125px'>Share Percentage $</td>");
                    strHTML.Append("<td align='right' width='125px'>Share Limit $</td>");
                    strHTML.Append("<td align='right' width='125px'>Deductible $</td>");
                    strHTML.Append("<td align='right' width='125px'>Store Deductible $</td>");
                    strHTML.Append("<td align='right' width='125px'>Annual Premium $</td>");
                    strHTML.Append("<td align='right' width='125px'>S/L Fees $</td>");
                    strHTML.Append("<td align='right' width='125px'>Total $</td>");
                    strHTML.Append("</tr>");

                    // set Location Table 
                    DataTable dtPolicy = dsResult.Tables[0];

                    // Check if record is exist for location
                    if (dtPolicy.Rows.Count > 0)
                    {
                        // display record for Location
                        foreach (DataRow drReport in dtPolicy.Rows)
                        {
                            strHTML.Append("<tr valign='top' align='left'>");
                            strHTML.Append("<td align='left' width='125px'>" + drReport["Program"] + "</td>");
                            strHTML.Append("<td align='left' width='200px'>" + drReport["Policy_Type"] + "</td>");
                            strHTML.Append("<td align='left' width='150px'>" + drReport["Layer"] + "</td>");
                            strHTML.Append("<td align='left' width='150px'>" + drReport["Carrier"] + "</td>");
                            strHTML.Append("<td align='left' width='150px'>" + drReport["Policy_Number"] + "</td>");
                            strHTML.Append("<td align='left' width='150px'>" + string.Format("{0:MM/dd/yyyy}", drReport["Policy_Effective_Date"]) + "</td>");
                            strHTML.Append("<td align='left' width='150px'>" + string.Format("{0:MM/dd/yyyy}", drReport["Policy_Expiration_Date"]) + "</td>");
                            strHTML.Append("<td align='left' width='125px'>" + drReport["Coverage_Form"] + "</td>");
                            strHTML.Append("<td align='right' width='130px'>" + string.Format("{0:N2}", drReport["Per_Occurrence_Limit"]) + "</td>");
                            strHTML.Append("<td align='right' width='125px'>" + string.Format("{0:N2}", drReport["Aggregate_Limit"]) + "</td>");
                            strHTML.Append("<td align='right' width='125px'>" + string.Format("{0:N2}", drReport["Underlying_Limit"]) + "</td>");
                            strHTML.Append("<td align='right' width='125px'>" + string.Format("{0:N2}", drReport["Share_Precentage"]) + "</td>");
                            strHTML.Append("<td align='right' width='125px'>" + string.Format("{0:N2}", drReport["Share_Limit"]) + "</td>");
                            strHTML.Append("<td align='right' width='125px'>" + string.Format("{0:N2}", drReport["Deductible_Amount"]) + "</td>");
                            strHTML.Append("<td align='right' width='125px'>" + string.Format("{0:N2}", drReport["Store_Deductible"]) + "</td>");
                            strHTML.Append("<td align='right' width='125px'>" + string.Format("{0:N2}", drReport["Annual_Premium"]) + "</td>");
                            strHTML.Append("<td align='right' width='125px'>" + string.Format("{0:N2}", drReport["Surplus_Lines_Fees"]) + "</td>");
                            strHTML.Append("<td align='right' width='125px'>" + string.Format("{0:N2}", drReport["Total"]) + "</td>");
                            strHTML.Append("</tr>");
                        }

                        // print Sub Total by Location
                        strHTML.Append("<tr valign='top' align='left' style='font-weight: bold;'>");
                        strHTML.Append("<td>Total</td>");
                        strHTML.Append("<td> <td> <td> <td> <td><td><td><td> <td><td><td><td><td><td></td>");
                        strHTML.Append("<td align='right'>" + string.Format("{0:N2}", dtPolicy.Compute("SUM(Annual_Premium)", "")) + "</td>");
                        strHTML.Append("<td align='right'>" + string.Format("{0:N2}", dtPolicy.Compute("SUM(Surplus_Lines_Fees)", "")) + "</td>");
                        strHTML.Append("<td align='right'>" + string.Format("{0:N2}", dtPolicy.Compute("SUM(Total)", "")) + "</td>");
                        strHTML.Append("</tr>");
                    }
                    strHTML.Append("</table>");
                    #endregion

                    //Write HTML in to HtmlWriter
                    htmlWrite.WriteLine(strHTML.ToString());

                    //Send Mail
                    SendMail("Insurance Schedule", "InsuranceScheduleReport.xls", strFirstName, strLastName, strMailFrom, stringWrite, dtRecipients);
                }
            }
        }

        //Report 42
        private void BindExp_ThirdPartyOwnedReport(DataRow drReportSchedule)
        {
            decimal pK_Schedule_ID = Convert.ToDecimal(drReportSchedule["PK_Schedule"]);
            decimal Fk_RecipientList = Convert.ToDecimal(drReportSchedule["Fk_RecipientList"]);
            decimal FK_Security_Id = Convert.ToDecimal(drReportSchedule["FK_Security_Id"]);

            //Get Report criteria for the scheduled report
            DataTable dtFilter = Report.SelectFilterCriteria(42, pK_Schedule_ID).Tables[0];
            if (dtFilter.Rows.Count > 0)
            {
                //Get the recipient from the recipient list 
                DataTable dtRecipients = Report.SelectOneRecordWithRecipientList(Fk_RecipientList).Tables[0];

                //Get the user who has scheduled the report
                DataTable dtUser = Report.SelectSecurityByPK(FK_Security_Id).Tables[0];

                String strFirstName, strLastName, strMailFrom;
                strFirstName = strLastName = strMailFrom = "";
                if (dtUser.Rows.Count > 0)
                {
                    strFirstName = Convert.ToString(dtUser.Rows[0]["FIRST_NAME"]).Trim();
                    strLastName = Convert.ToString(dtUser.Rows[0]["LAST_NAME"]).Trim();
                    strMailFrom = Convert.ToString(dtUser.Rows[0]["Email"]).Trim();
                }
                string strRegion = Convert.ToString(dtFilter.Rows[0]["Region"]).Trim();
                string strMarket = null;
                if (!string.IsNullOrEmpty(Convert.ToString(dtFilter.Rows[0]["Market"])))
                {
                    strMarket = Convert.ToString(dtFilter.Rows[0]["Market"]).Trim();
                }
                string strStatus = Convert.ToString(dtFilter.Rows[0]["Status"]).Trim();

                //Get the all Unique records for Selected group (default - last name -sort) by search criteria
                DataSet dsResult = Report.GetNewExposuresreport(strRegion, strMarket, strStatus, FK_Security_Id);

                //Create HTML for the report and wirte into HTML Write object
                StringBuilder strHTML = new StringBuilder();
                System.IO.StringWriter stringWrite = new System.IO.StringWriter();
                System.Web.UI.HtmlTextWriter htmlWrite = new System.Web.UI.HtmlTextWriter(stringWrite);

                #region "Report Title"

                //Retrieve Market Values
                string strMarketString = string.Empty;
                if (string.IsNullOrEmpty(strMarket))
                {
                    strMarketString = "All Market";
                }
                else
                {
                    string[] strMar = strMarket.Split(Convert.ToChar(","));
                    for (int i = 0; i < strMar.Length; i++)
                    {
                        strMarketString += Report.SelectMarketInfoById(Convert.ToDecimal(strMar[i].ToString())).Tables[0].Rows[0]["Market"].ToString() + ",";
                    }
                    strMarketString = strMarketString.TrimEnd(',');
                }

                //Add Report Title and Schedule Date
                strHTML.Append("<br />");
                strHTML.Append("<b>Report Title : Third Party Owned and Sonic Leased, Subleased to Third Party and Sonic Owned with Third Party Lease</b>");
                strHTML.Append("<br /><br />");
                strHTML.Append("Schedule Date : " + Convert.ToDateTime(drReportSchedule["Scheduled_Date"]).ToString(DateDisplayFormat));
                strHTML.Append("&nbsp;&nbsp;&nbsp;&nbsp;Schedule End Date : " + Convert.ToDateTime(drReportSchedule["Schedule_End_Date"]).ToString(DateDisplayFormat));
                strHTML.Append("<br />");
                strHTML.Append("Recurring Period : " + drReportSchedule["Recurring_Period"].ToString());
                strHTML.Append("<br />");
                strHTML.Append("Recurring Date : " + dtSchduleDate.ToString(DateDisplayFormat));

                //Add Report Filter Criteria 
                strHTML.Append("<br /><br /><table> <tr> <td>");
                strHTML.Append("<b>Report Filters </b>");
                strHTML.Append("<br /><table> <tr> <td colspan='8'>");
                strHTML.Append("Region   : " + strRegion);
                strHTML.Append("</td> </tr>");
                strHTML.Append("Market        : " + strMarketString);
                strHTML.Append("<br /><br />");
                strHTML.Append("<tr> <td colspan='8'>");
                strHTML.Append("Location Status   : " + strStatus);
                strHTML.Append("</td> </tr>");
                strHTML.Append("<tr> <td colspan='8'>");
                strHTML.Append("</td></tr></table> ");

                #endregion

                #region "Report Grid header"
                //Top Header
                strHTML.Append("<table border='1'>");
                strHTML.Append("<tr style='font-weight: bold;' valign='bottom' align='left'>");
                strHTML.Append("<td align='left' colspan='2'>Sonic Automotive</td>");
                strHTML.Append("<td align='center' colspan='22'>Third Party Owned and Sonic Leased, Subleased to Third Party and Sonic Owned with Third Party Lease</td>");
                strHTML.Append("<td align='right' colspan='3'> " + DateTime.Now.ToString() + " </td>");
                strHTML.Append("</tr>");

                //Sub Header
                strHTML.Append("<tr valign='bottom' align='left' style='font-weight: bold'>");
                strHTML.Append("<td width='150'>Region</td>");
                strHTML.Append("<td width='150'>Sonic Location D/B/A</td>");
                strHTML.Append("<td width='150'> Building Number</td>");
                strHTML.Append("<td width='160'> Building Street Address 1</td>");
                strHTML.Append("<td width='160'> Building Street Address 2</td>");
                strHTML.Append("<td width='150'> Building City</td>");
                strHTML.Append("<td width='150'> Building State</td>");
                strHTML.Append("<td width='150'> Building Zip Code</td>");
                strHTML.Append("<td width='150'>Status</td>");
                strHTML.Append("<td width='200'>Ownership</td>");
                strHTML.Append("<td width='150'>Landlord Name</td>");
                strHTML.Append("<td width='150'>Landlord Legal Entity</td>");
                strHTML.Append("<td width='150'> Address 1</td>");
                strHTML.Append("<td width='150'> Address 2</td>");
                strHTML.Append("<td width='150'>City</td>");
                strHTML.Append("<td width='150'>State</td>");
                strHTML.Append("<td width='150'>Zip Code</td>");
                strHTML.Append("<td width='150'>Lease ID</td>");
                strHTML.Append("<td width='150'>Commencement Date</td>");
                strHTML.Append("<td width='150'>Expiration Date</td>");
                strHTML.Append("<td width='150'> Sub-Lease Name</td>");
                strHTML.Append("<td width='150'> Sub-Lease Landlord</td>");
                strHTML.Append("<td width='150'>Address 1</td>");
                strHTML.Append("<td width='150'>Address 2</td>");
                strHTML.Append("<td width='150'>City</td>");
                strHTML.Append("<td width='150'>State</td>");
                strHTML.Append("<td width='150'>Zip</td>");


                strHTML.Append("</tr>");

                //Check Whether Record Exists or Not
                if (dsResult != null && dsResult.Tables.Count > 0 && dsResult.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in dsResult.Tables[0].Rows)
                    {
                        strHTML.Append("<tr valign='top' align='left'>");

                        strHTML.Append("<td width='150'>" + Convert.ToString(dr["Region"]) + "</td>");
                        strHTML.Append("<td width='150'>" + Convert.ToString(dr["dba"]) + "</td>");
                        strHTML.Append("<td width='150'>" + Convert.ToString(dr["BUILDING_NUMBER"]) + "</td>");
                        strHTML.Append("<td width='160'>" + Convert.ToString(dr["Building_Address_1"]) + "</td>");
                        strHTML.Append("<td width='160'>" + Convert.ToString(dr["Building_Address_2"]) + "</td>");
                        strHTML.Append("<td width='150'>" + Convert.ToString(dr["Building_City"]) + "</td>");
                        strHTML.Append("<td width='150'>" + Convert.ToString(dr["Building_State"]) + "</td>");
                        strHTML.Append("<td width='150'>" + Convert.ToString(dr["Building_Zip"]) + "</td>");
                        strHTML.Append("<td width='150'>" + Convert.ToString(dr["LOCATION_STATUS"]) + "</td>");
                        strHTML.Append("<td width='150'>" + Convert.ToString(dr["Ownership"]) + "</td>");
                        strHTML.Append("<td width='150'>" + Convert.ToString(dr["LANDLORD_NAME"]) + "</td>");
                        strHTML.Append("<td width='150'>" + Convert.ToString(dr["LANDLORD_LEGAL_ENTITY"]) + "</td>");
                        strHTML.Append("<td width='150'>" + Convert.ToString(dr["LANDLORD_ADDRESS_1"]) + "</td>");
                        strHTML.Append("<td width='150'>" + Convert.ToString(dr["LANDLORD_ADDRESS_2"]) + "</td>");
                        strHTML.Append("<td width='150'>" + Convert.ToString(dr["LANDLORD_CITY"]) + "</td>");
                        strHTML.Append("<td width='150'>" + Convert.ToString(dr["Landlord_State"]) + "</td>");
                        strHTML.Append("<td width='150'>" + Convert.ToString(dr["LANDLORD_ZIP"]) + "</td>");
                        strHTML.Append("<td width='150'>" + Convert.ToString(dr["LEASE_ID"]) + "</td>");
                        strHTML.Append("<td width='150'>" + FormatDBNullDateToDisplay(dr["COMMENCEMENT_DATE"]) + "</td>");
                        strHTML.Append("<td width='150'>" + FormatDBNullDateToDisplay(dr["EXPIRATION_DATE"]) + "</td>");
                        strHTML.Append("<td width='150'>" + Convert.ToString(dr["SUBLEASE_NAME"]) + "</td>");
                        strHTML.Append("<td width='150'>" + Convert.ToString(dr["SUBLANDLORD"]) + "</td>");
                        strHTML.Append("<td width='150'>" + Convert.ToString(dr["SUBLEASE_ADDRESS_1"]) + "</td>");
                        strHTML.Append("<td width='150'>" + Convert.ToString(dr["SUBLEASE_ADDRESS_2"]) + "</td>");
                        strHTML.Append("<td width='150'>" + Convert.ToString(dr["SUBLEASE_CITY"]) + "</td>");
                        strHTML.Append("<td width='150'>" + Convert.ToString(dr["Sublease_State"]) + "</td>");
                        strHTML.Append("<td width='150'>" + Convert.ToString(dr["SUBLEASE_ZIP"]) + "</td>");


                        strHTML.Append("</tr>");
                    }
                }
                else
                {
                    //Add No record found line for year
                    strHTML.Append("<tr><td align='left' colspan='81'>No Record Found!</td></tr>");
                }
                strHTML.Append("</table>");

                #endregion

                //Write HTML in to HtmlWriter
                htmlWrite.WriteLine(strHTML.ToString());
                //Send Mail
                SendMail("Third Party Owned and Sonic Leased and Subleased to Third Party Report", "Third_Party_Owned_Report.xls", strFirstName, strLastName, strMailFrom, stringWrite, dtRecipients);
            }

        }

        // Report 43
        private void BindFacilityInspectionReport(DataRow drReportSchedule)
        {
            decimal pK_Schedule_ID = Convert.ToDecimal(drReportSchedule["PK_Schedule"]);
            decimal Fk_RecipientList = Convert.ToDecimal(drReportSchedule["Fk_RecipientList"]);
            decimal FK_Security_Id = Convert.ToDecimal(drReportSchedule["FK_Security_Id"]);

            //Get Report criteria for the scheduled report
            DataTable dtFilter = Report.SelectFilterCriteria(43, pK_Schedule_ID).Tables[0];
            if (dtFilter.Rows.Count > 0)
            {
                //Get the recipient from the recipient list 
                DataTable dtRecipients = Report.SelectOneRecordWithRecipientList(Fk_RecipientList).Tables[0];

                //Get the user who has scheduled the report
                DataTable dtUser = Report.SelectSecurityByPK(FK_Security_Id).Tables[0];

                String strFirstName, strLastName, strMailFrom;
                strFirstName = strLastName = strMailFrom = "";
                if (dtUser.Rows.Count > 0)
                {
                    strFirstName = Convert.ToString(dtUser.Rows[0]["FIRST_NAME"]).Trim();
                    strLastName = Convert.ToString(dtUser.Rows[0]["LAST_NAME"]).Trim();
                    strMailFrom = Convert.ToString(dtUser.Rows[0]["Email"]).Trim();
                }
                string strRegion = Convert.ToString(dtFilter.Rows[0]["Region"]).Trim();
                string strMarket = null;
                if (!string.IsNullOrEmpty(Convert.ToString(dtFilter.Rows[0]["Market"])))
                {
                  strMarket = Convert.ToString(dtFilter.Rows[0]["Market"]).Trim();
                }
                string strYear = Convert.ToString(dtFilter.Rows[0]["Year"]).Trim();
                string strReportInterval = Convert.ToString(dtFilter.Rows[0]["Report_Interval"]).Trim();

                //Create HTML for the report and wirte into HTML Write object
                StringBuilder strHTML = new StringBuilder();
                System.IO.StringWriter stringWrite = new System.IO.StringWriter();
                System.Web.UI.HtmlTextWriter htmlWrite = new System.Web.UI.HtmlTextWriter(stringWrite);

                #region "Report Title"

                //Retrieve Market Values
                string strMarketString = string.Empty;
                if (string.IsNullOrEmpty(strMarket))
                {
                    strMarketString = "All Market";
                }
                else
                {
                    string[] strMar = strMarket.Split(Convert.ToChar(","));
                    for (int i = 0; i < strMar.Length; i++)
                    {
                        strMarketString += Report.SelectMarketInfoById(Convert.ToDecimal(strMar[i].ToString())).Tables[0].Rows[0]["Market"].ToString() + ",";
                    }
                    strMarketString = strMarketString.TrimEnd(',');
                }

                //Add Report Title and Schedule Date
                strHTML.Append("<br />");
                strHTML.Append("<b>Report Title : Facility Inspection </b>");
                strHTML.Append("<br /><br />");
                strHTML.Append("Schedule Date : " + Convert.ToDateTime(drReportSchedule["Scheduled_Date"]).ToString(DateDisplayFormat));
                strHTML.Append("&nbsp;&nbsp;&nbsp;&nbsp;Schedule End Date : " + Convert.ToDateTime(drReportSchedule["Schedule_End_Date"]).ToString(DateDisplayFormat));
                strHTML.Append("<br />");
                strHTML.Append("Recurring Period : " + drReportSchedule["Recurring_Period"].ToString());
                strHTML.Append("<br />");
                strHTML.Append("Recurring Date : " + dtSchduleDate.ToString(DateDisplayFormat));

                //Add Report Filter Criteria 
                strHTML.Append("<br /><br /><table> <tr> <td>");
                strHTML.Append("<b>Report Filters </b>");
                strHTML.Append("<br /><table> <tr> <td colspan='8'>");
                strHTML.Append("Report Interval   : " + strReportInterval);
                strHTML.Append("</td> </tr>");
                strHTML.Append("<tr> <td colspan='8'>");
                strHTML.Append("Year   : " + strYear);
                strHTML.Append("</td> </tr>");
                strHTML.Append("<tr> <td colspan='8'>");
                strHTML.Append("Region   : " + strRegion);
                strHTML.Append("</td> </tr>");
                strHTML.Append("<tr> <td colspan='8'>");
                strHTML.Append("</td></tr></table> ");

                #endregion

                #region "Report Data"
                //Monthly Report

                if (strReportInterval.ToString() == "Monthly")
                {
                    DataSet dsReport = Report.GetFacilityInspectionReport(strRegion, strMarket, Convert.ToInt32(strYear), strReportInterval, FK_Security_Id);
                    if (dsReport != null && dsReport.Tables.Count > 0 && dsReport.Tables[0].Rows.Count > 0)
                    {
                        // get data tables from dataset
                        DataTable dtRegions = dsReport.Tables[0];

                        strHTML.Append("<table border='1' style='border: black 0.5px solid;border-collapse: collapse;' cellpadding='0' cellspacing='0'  Width='100%px'><tr><td>");

                        strHTML.Append("<table border='1' style='padding-left:4px;font-size:8.5pt;font-family:Tahoma' cellpadding='4' cellspacing='0' Width='1980px'>");//Sub Table
                        strHTML.Append("<tr style='font-weight: bold;font-size:11pt;height:25'>"); //Title
                        strHTML.Append("<td align='left' style='font-size:9pt;' colspan='2'><b>Sonic Automotive</b></td>");
                        strHTML.Append("<td align='center' style='font-size:9pt;' colspan='9' ><b> FACILITY INSPECTIONS - MONTHLY REPORT FOR " + strYear + " </b></td>");
                        strHTML.Append("<td style='font-size:9pt' align='right' colspan='4'>Valuation Date: " + DateTime.Now.ToString("MM/dd/yyy HH:mm tt") + "</td></tr>");

                        strHTML.Append("<tr align='left' border='1' style='border: black 0.5px solid;'>");
                        strHTML.Append("<td  width='180px'><b>REGION</b></td>");
                        strHTML.Append("<td  width='230px'><b>STORE</b></td>");
                        strHTML.Append("<td  width='120px'><b>JANUARY</b></td>");
                        strHTML.Append("<td  width='120px'><b>FEBRUARY</b></td>");
                        strHTML.Append("<td  width='120px'><b>MARCH</b></td>");
                        strHTML.Append("<td  width='120px'><b>APRIL</b></td>");
                        strHTML.Append("<td  width='120px'><b>MAY</b></td>");
                        strHTML.Append("<td  width='120px'><b>JUNE</b></td>");
                        strHTML.Append("<td  width='120px'><b>JULY</b></td>");
                        strHTML.Append("<td  width='120px'><b>AUGUST</b></td>");
                        strHTML.Append("<td  width='120px'><b>SEPTEMBER</b></td>");
                        strHTML.Append("<td  width='120px'><b>OCTOBER</b></td>");
                        strHTML.Append("<td  width='120px'><b>NOVEMBER</b></td>");
                        strHTML.Append("<td  width='120px'><b>DECEMBER</b></td>");
                        strHTML.Append("<td  width='130px'><b>AVERAGE SCORE</b></td>");
                        strHTML.Append("</tr>");
                        for (int intI3 = 0; intI3 < dtRegions.Rows.Count; intI3++)
                        {
                            DataRow drRecords = dtRegions.Rows[intI3];
                            //int intRes;
                            //int intDiv = System.Math.DivRem(intI3, 2, out intRes);
                            //if (intRes == 0)
                            //strHTML.Append("<tr align='left' style='font-size:8pt;background-color:#EAEAEA;font-family:Tahoma;'>");
                            // else
                            strHTML.Append("<tr align='left' style='font-size:8pt;border: black 0.5px solid;' border='1'>");

                            strHTML.Append("<td  align='left' >" + Convert.ToString(drRecords["Region"]) + "</td>");
                            strHTML.Append("<td  align='left'>" + Convert.ToString(drRecords["DBA"]) + "</td>");
                            strHTML.Append("<td  align='left'>" + GetScoreName(drRecords["JANUARY"]) + "</td>");
                            strHTML.Append("<td  align='left'>" + GetScoreName(drRecords["FEBRUARY"]) + "</td>");
                            strHTML.Append("<td  align='left'>" + GetScoreName(drRecords["MARCH"]) + "</td>");
                            strHTML.Append("<td  align='left'>" + GetScoreName(drRecords["APRIL"]) + "</td>");
                            strHTML.Append("<td  align='left'>" + GetScoreName(drRecords["MAY"]) + "</td>");
                            strHTML.Append("<td  align='left'>" + GetScoreName(drRecords["JUNE"]) + "</td>");
                            strHTML.Append("<td  align='left'>" + GetScoreName(drRecords["JULY"]) + "</td>");
                            strHTML.Append("<td  align='left'>" + GetScoreName(drRecords["AUGUST"]) + "</td>");
                            strHTML.Append("<td  align='left'>" + GetScoreName(drRecords["SEPTEMBER"]) + "</td>");
                            strHTML.Append("<td  align='left'>" + GetScoreName(drRecords["OCTOBER"]) + "</td>");
                            strHTML.Append("<td  align='left'>" + GetScoreName(drRecords["NOVEMBER"]) + "</td>");
                            strHTML.Append("<td  align='left'>" + GetScoreName(drRecords["DECEMBER"]) + "</td>");
                            strHTML.Append("<td  align='left'>" + GetScoreName(drRecords["Average"]) + "</td>");
                            strHTML.Append("</tr>");
                        }

                        //strHTML.Append("<tr><td colspan='15' class='cols_'>&nbsp;</td></tr>");
                        strHTML.Append("</table>");
                        strHTML.Append("</table>");
                    }
                    else
                    {
                        strHTML.Append("<table style='font-family:Tahoma' cellpadding='4' cellspacing='0' Width='100%'>");
                        strHTML.Append("<tr style='background-color:#F2F2F2;color:Black;'>");
                        strHTML.Append("<td align='center' style='font-size:9pt;'>No Records found.</td></tr></table>");
                    }
                }
                else if (strReportInterval.ToString() == "Quarterly")
                {
                    DataSet dsReport = Report.GetFacilityInspectionReport(strRegion, strMarket, Convert.ToInt32(strYear), strReportInterval, FK_Security_Id);
                    if (dsReport != null && dsReport.Tables.Count > 0 && dsReport.Tables[0].Rows.Count > 0)
                    {
                        DataTable dtRegions = dsReport.Tables[0];

                        strHTML.Append("<table border='1' style='border: black 0.5px solid;border-collapse: collapse;' cellpadding='0' cellspacing='0'  Width='100%px'><tr><td>");

                        strHTML.Append("<table border='1' style='padding-left:4px;font-size:8.5pt;font-family:Tahoma' cellpadding='4' cellspacing='0' Width='995px'>");//Sub Table
                        strHTML.Append("<tr style='font-weight: bold;font-size:11pt;height:25'>"); //Title
                        strHTML.Append("<td align='left' style='font-size:9pt;' colspan='1'><b>Sonic Automotive</b></td>");
                        strHTML.Append("<td align='center' style='font-size:9pt;' colspan='3' ><b> FACILITY INSPECTION - QUARTERLY REPORT FOR " + strYear + " </b></td>");
                        strHTML.Append("<td style='font-size:9pt' align='right' colspan='3'>Valuation Date: " + DateTime.Now.ToString("MM/dd/yyy HH:mm tt") + "</td></tr>");

                        strHTML.Append("<tr align='left' border='1' style='border: black 0.5px solid;' >");
                        strHTML.Append("<td  width='185px'><b>REGION</b></td>");
                        strHTML.Append("<td  width='220px'><b>STORE</b></td>");
                        strHTML.Append("<td  width='120px'><b>Q1</b></td>");
                        strHTML.Append("<td  width='120px'><b>Q2</b></td>");
                        strHTML.Append("<td  width='120px'><b>Q3</b></td>");
                        strHTML.Append("<td  width='120px'><b>Q4</b></td>");
                        strHTML.Append("<td  width='110px'><b>AVERAGE SCORE</b></td>");
                        strHTML.Append("</tr>");
                        for (int intI3 = 0; intI3 < dtRegions.Rows.Count; intI3++)
                        {
                            DataRow drRecords = dtRegions.Rows[intI3];
                            //int intRes;
                            //int intDiv = System.Math.DivRem(intI3, 2, out intRes);
                            //if (intRes == 0)
                            //    strHTML.Append("<tr align='left' style='font-size:8pt;background-color:#EAEAEA;font-family:Tahoma;'>");
                            //else
                            strHTML.Append("<tr align='left' style='font-size:8pt;border: black 0.5px solid;' border='1'>");

                            strHTML.Append("<td  align='left' >" + Convert.ToString(drRecords["Region"]) + "</td>");
                            strHTML.Append("<td>" + Convert.ToString(drRecords["DBA"]) + "</td>");
                            strHTML.Append("<td align='left'>" + GetScoreName(drRecords["Q1"]) + "</td>");
                            strHTML.Append("<td align='left'>" + GetScoreName(drRecords["Q2"]) + "</td>");
                            strHTML.Append("<td align='left'>" + GetScoreName(drRecords["Q3"]) + "</td>");
                            strHTML.Append("<td align='left'>" + GetScoreName(drRecords["Q4"]) + "</td>");
                            strHTML.Append("<td align='left'>" + GetScoreName(drRecords["Average"]) + "</td>");
                            strHTML.Append("</tr>");
                        }
                        strHTML.Append("</table>");
                        strHTML.Append("</table>");
                    }
                    else
                    {
                        strHTML.Append("<table style='font-family:Tahoma' cellpadding='4' cellspacing='0' Width='100%'>");
                        strHTML.Append("<tr style='background-color:#F2F2F2;color:Black;'>");
                        strHTML.Append("<td align='center' style='font-size:9pt;'>No Records found.</td></tr></table>");
                    }
                }
                else if (strReportInterval.ToString() == "Annually")
                {
                    DataSet dsReport = Report.GetFacilityInspectionReport(strRegion, strMarket, Convert.ToInt32(strYear), strReportInterval, FK_Security_Id);
                    if (dsReport != null && dsReport.Tables.Count > 0 && dsReport.Tables[0].Rows.Count > 0)
                    {
                        DataTable dtRegions = dsReport.Tables[0];
                        strHTML.Append("<table border='1' style='border: black 0.5px solid;border-collapse: collapse;' cellpadding='0' cellspacing='0'  Width='100%px'><tr><td>");

                        strHTML.Append("<table border='1' style='padding-left:4px;font-size:8.5pt;font-family:Tahoma' cellpadding='4' cellspacing='0' Width='996px'>");//Sub Table
                        strHTML.Append("<tr style='font-weight: bold;font-size:11pt;height:25'>"); //Title
                        strHTML.Append("<td align='left' style='font-size:9pt;' colspan='1'><b>Sonic Automotive</b></td>");
                        strHTML.Append("<td align='center' style='font-size:9pt;' colspan='4' ><b> FACILITY INSPECTION - ANNAUL REPORT FOR " + strYear + " </b></td>");
                        strHTML.Append("<td style='font-size:9pt' align='right' colspan='3'>Valuation Date: " + DateTime.Now.ToString("MM/dd/yyy HH:mm tt") + "</td></tr>");

                        strHTML.Append("<tr align='left' border='1' style='border: black 0.5px solid;'>");
                        strHTML.Append("<td width='180px'><b>REGION</b></td>");
                        strHTML.Append("<td width='230px'><b>STORE</b></td>");
                        strHTML.Append("<td width='120px'><b>" + Convert.ToString(Convert.ToInt32(strYear) - 4) + "</b></td>");
                        strHTML.Append("<td width='120px'><b>" + Convert.ToString(Convert.ToInt32(strYear) - 3) + "</b></td>");
                        strHTML.Append("<td width='120px'><b>" + Convert.ToString(Convert.ToInt32(strYear) - 2) + "</b></td>");
                        strHTML.Append("<td width='120px'><b>" + Convert.ToString(Convert.ToInt32(strYear) - 1) + "</b></td>");
                        strHTML.Append("<td width='120px'><b>" + Convert.ToString(Convert.ToInt32(strYear)) + "</b></td>");
                        strHTML.Append("<td width='110px'><b>AVERAGE SCORE</b></td>");
                        strHTML.Append("</tr>");
                        for (int intI3 = 0; intI3 < dtRegions.Rows.Count; intI3++)
                        {
                            DataRow drRecords = dtRegions.Rows[intI3];
                            //int intRes;
                            //int intDiv = System.Math.DivRem(intI3, 2, out intRes);
                            //if (intRes == 0)
                            //    strHTML.Append("<tr align='left' style='font-size:8pt;background-color:#EAEAEA;font-family:Tahoma;'>");
                            //else
                            strHTML.Append("<tr align='left' style='font-size:8pt;border: black 0.5px solid;' border='1'>");

                            strHTML.Append("<td align='left' >" + Convert.ToString(drRecords["Region"]) + "</td>");
                            strHTML.Append("<td>" + Convert.ToString(drRecords["DBA"]) + "</td>");
                            strHTML.Append("<td align='left'>" + GetScoreName(drRecords["Year1"]) + "</td>");
                            strHTML.Append("<td align='left'>" + GetScoreName(drRecords["Year2"]) + "</td>");
                            strHTML.Append("<td align='left'>" + GetScoreName(drRecords["Year3"]) + "</td>");
                            strHTML.Append("<td align='left'>" + GetScoreName(drRecords["Year4"]) + "</td>");
                            strHTML.Append("<td align='left'>" + GetScoreName(drRecords["Year5"]) + "</td>");
                            strHTML.Append("<td align='left'>" + GetScoreName(drRecords["Average"]) + "</td>");
                            strHTML.Append("</tr>");
                        }
                        // sbRecorords.Append("<tr><td colspan='7' class='cols_'>&nbsp;</td></tr>");
                        strHTML.Append("</table>");
                        // sbRecorords.Append("</div>");
                        strHTML.Append("</table>");
                    }
                    else
                    {
                        strHTML.Append("<table style='font-family:Tahoma' cellpadding='4' cellspacing='0' Width='100%'>");
                        strHTML.Append("<tr style='background-color:#F2F2F2;color:Black;'>");
                        strHTML.Append("<td align='center' style='font-size:9pt;'>No Records found.</td></tr></table>");
                    }
                }
                #endregion

                //Write HTML in to HtmlWriter
                htmlWrite.WriteLine(strHTML.ToString());
                //Send Mail
                SendMail("Facility Inspection Report", "FacilityInspectionReprot.xls", strFirstName, strLastName, strMailFrom, stringWrite, dtRecipients);
            }
        }

        // Report 44
        private void BindCustomerIncidentSummaryReport(DataRow drReportSchedule)
        {
            decimal pK_Schedule_ID = Convert.ToDecimal(drReportSchedule["PK_Schedule"]);
            decimal Fk_RecipientList = Convert.ToDecimal(drReportSchedule["Fk_RecipientList"]);
            decimal FK_Security_Id = Convert.ToDecimal(drReportSchedule["FK_Security_Id"]);

            //Get Report criteria for the scheduled report
            DataTable dtFilter = Report.SelectFilterCriteria(44, pK_Schedule_ID).Tables[0];
            if (dtFilter.Rows.Count > 0)
            {
                //Get the recipient from the recipient list 
                DataTable dtRecipients = Report.SelectOneRecordWithRecipientList(Fk_RecipientList).Tables[0];

                //Get the user who has scheduled the report
                DataTable dtUser = Report.SelectSecurityByPK(FK_Security_Id).Tables[0];

                String strFirstName, strLastName, strMailFrom;
                strFirstName = strLastName = strMailFrom = "";
                if (dtUser.Rows.Count > 0)
                {
                    strFirstName = Convert.ToString(dtUser.Rows[0]["FIRST_NAME"]).Trim();
                    strLastName = Convert.ToString(dtUser.Rows[0]["LAST_NAME"]).Trim();
                    strMailFrom = Convert.ToString(dtUser.Rows[0]["Email"]).Trim();
                }

                string strFK_LU_Locations = Convert.ToString(dtFilter.Rows[0]["FK_LU_LocationIDs"]).Trim();
                string strYear = Convert.ToString(dtFilter.Rows[0]["Year"]);

                //Create HTML for the report and wirte into HTML Write object
                StringBuilder strHTML = new StringBuilder();
                System.IO.StringWriter stringWrite = new System.IO.StringWriter();
                System.Web.UI.HtmlTextWriter htmlWrite = new System.Web.UI.HtmlTextWriter(stringWrite);

                #region "Report Title"

                //Add Report Title and Schedule Date
                strHTML.Append("<br />");
                strHTML.Append("<b>Report Title : Customer Relations Incident Summary Report </b>");
                strHTML.Append("<br /><br />");
                strHTML.Append("Schedule Start Date : " + Convert.ToDateTime(drReportSchedule["Scheduled_Date"]).ToString(DateDisplayFormat));
                strHTML.Append("&nbsp;&nbsp;&nbsp;&nbsp;Schedule End Date : " + Convert.ToDateTime(drReportSchedule["Schedule_End_Date"]).ToString(DateDisplayFormat));
                strHTML.Append("<br />");
                strHTML.Append("Recurring Period : " + drReportSchedule["Recurring_Period"].ToString());
                strHTML.Append("<br />");
                strHTML.Append("Recurring Date : " + dtSchduleDate.ToString(DateDisplayFormat));

                //Add Report Filter Criteria 
                strHTML.Append("<br /><br /><table> <tr> <td colspan='14'>");
                strHTML.Append("<b>Report Filters </b>");
                strHTML.Append("<br /></td></tr><tr> <td colspan='14'>");
                strHTML.Append("Year             : " + strYear);
                strHTML.Append("</td></tr>");
                strHTML.Append("<tr> <td colspan='14'><table cellspacing='0' cellpadding='0' width='100%'><tr><td colspan='14'>");
                strHTML.Append("Location D/B/A   : " + Report.GetCommaSepratedDBAFromIDs(strFK_LU_Locations) + "</td></tr></table>");
                strHTML.Append("</td> </tr>");
                strHTML.Append("<tr> <td colspan='14'>");
                strHTML.Append("</td></tr></table> ");

                #endregion

                #region "Report Data"
                DataSet dsReport = Report.GetCustomerIncidentSummary(Convert.ToInt32(strYear), Convert.ToString(dtFilter.Rows[0]["FK_LU_LocationIDs"]));

                DataTable dtRecordType = dsReport.Tables[0];
                DataTable dtReport = dsReport.Tables[1];

                // Check if record found or not.
                if (dtReport.Rows.Count > 0)
                {
                    strHTML.Append("<table border='1' cellpadding='0' cellspacing='0'  Width='100%px'><tr><td  >");
                    strHTML.Append("<table  cellpadding='4' cellspacing='0' Width='100%' border='1'>");//Sub Table
                    strHTML.Append("<tr style='font-weight: bold;'>"); //Title
                    strHTML.Append("<td align='center'  colspan='14' ><b> Customer Relations Incident Summary Report for " + strYear + " </b></td>");
                    strHTML.Append("</tr>");

                    strHTML.Append("<tr align='left' style='font-weight: bold;'>");
                    strHTML.Append("<td  width='130px'>&nbsp;</td>");
                    strHTML.Append("<td  width='56px' align='left'>JAN</td>");
                    strHTML.Append("<td  width='56px' align='left'>FEB</td>");
                    strHTML.Append("<td  width='56px' align='left'>MAR</td>");
                    strHTML.Append("<td  width='56px' align='left'>APR</td>");
                    strHTML.Append("<td  width='56px' align='left'>MAY</td>");
                    strHTML.Append("<td  width='56px' align='left'>JUN</td>");
                    strHTML.Append("<td  width='56px' align='left'>JUL</td>");
                    strHTML.Append("<td  width='56px' align='left'>AUG</td>");
                    strHTML.Append("<td  width='56px' align='left'>SEP</td>");
                    strHTML.Append("<td  width='56px' align='left'>OCT</td>");
                    strHTML.Append("<td  width='56px' align='left'>NOV</td>");
                    strHTML.Append("<td  width='56px' align='left'>DEC</td>");
                    strHTML.Append("<td  width='56px' align='left'>Total</td>");
                    strHTML.Append("</tr>");

                    strHTML.Append("<tr><td style='color: #FF9C09;font-weight: bold;' colspan='14'>Analysis by Incident</td></tr>");

                    for (int i = 0; i < dtRecordType.Rows.Count; i++)
                    {
                        string strRecordType = Convert.ToString(dtRecordType.Rows[i]["Type"]);
                        DataRow[] drReport = dtReport.Select("Type = '" + strRecordType + "'");

                        if (strRecordType == "Number of Dealerships with a Reported Incident")
                            strHTML.Append("<tr><td style='color: #FF9C09;font-weight: bold;' colspan='14'>Analysis by Dealership</td></tr>");

                        strHTML.Append("<tr align='left' >");

                        if (strRecordType == "Method of Contact")
                        {
                            strHTML.Append("<td   align='left' colspan='13'><b>" + strRecordType + "</b></td>");
                            strHTML.Append("<td   align='left'><b>TOTAL</b></td>");
                        }
                        else
                            strHTML.Append("<td   align='left' " + ((drReport.Length > 1) ? "colspan='14'" : "") + "><b>" + strRecordType + "</b></td>");

                        if (drReport.Length > 1) strHTML.Append("</tr>");

                        for (int j = 0; j < drReport.Length; j++)
                        {
                            DataRow drRecords = drReport[j];
                            if (drReport.Length > 1)
                            {
                                strHTML.Append("<tr align='left' >");
                                strHTML.Append("<td  align='left'>" + Convert.ToString(drRecords["Description"]) + "</td>");
                            }

                            strHTML.Append("<td  align='left'>" + string.Format(Convert.ToBoolean(drRecords["ShowDecimalPoint"]) == true ? "{0:N1}" : "{0:N0}", drRecords["JAN"]) + "</td>");
                            strHTML.Append("<td  align='left'>" + string.Format(Convert.ToBoolean(drRecords["ShowDecimalPoint"]) == true ? "{0:N1}" : "{0:N0}", drRecords["FEB"]) + "</td>");
                            strHTML.Append("<td  align='left'>" + string.Format(Convert.ToBoolean(drRecords["ShowDecimalPoint"]) == true ? "{0:N1}" : "{0:N0}", drRecords["MAR"]) + "</td>");
                            strHTML.Append("<td  align='left'>" + string.Format(Convert.ToBoolean(drRecords["ShowDecimalPoint"]) == true ? "{0:N1}" : "{0:N0}", drRecords["APR"]) + "</td>");
                            strHTML.Append("<td  align='left'>" + string.Format(Convert.ToBoolean(drRecords["ShowDecimalPoint"]) == true ? "{0:N1}" : "{0:N0}", drRecords["MAY"]) + "</td>");
                            strHTML.Append("<td  align='left'>" + string.Format(Convert.ToBoolean(drRecords["ShowDecimalPoint"]) == true ? "{0:N1}" : "{0:N0}", drRecords["JUN"]) + "</td>");
                            strHTML.Append("<td  align='left'>" + string.Format(Convert.ToBoolean(drRecords["ShowDecimalPoint"]) == true ? "{0:N1}" : "{0:N0}", drRecords["JUL"]) + "</td>");
                            strHTML.Append("<td  align='left'>" + string.Format(Convert.ToBoolean(drRecords["ShowDecimalPoint"]) == true ? "{0:N1}" : "{0:N0}", drRecords["AUG"]) + "</td>");
                            strHTML.Append("<td  align='left'>" + string.Format(Convert.ToBoolean(drRecords["ShowDecimalPoint"]) == true ? "{0:N1}" : "{0:N0}", drRecords["SEP"]) + "</td>");
                            strHTML.Append("<td  align='left'>" + string.Format(Convert.ToBoolean(drRecords["ShowDecimalPoint"]) == true ? "{0:N1}" : "{0:N0}", drRecords["OCT"]) + "</td>");
                            strHTML.Append("<td  align='left'>" + string.Format(Convert.ToBoolean(drRecords["ShowDecimalPoint"]) == true ? "{0:N1}" : "{0:N0}", drRecords["NOV"]) + "</td>");
                            strHTML.Append("<td  align='left'>" + string.Format(Convert.ToBoolean(drRecords["ShowDecimalPoint"]) == true ? "{0:N1}" : "{0:N0}", drRecords["DEC"]) + "</td>");

                            if (strRecordType == "Incidents Closed in Month Received")
                                strHTML.Append("<td  align='left'><b>AVG</b></td>");
                            else
                                strHTML.Append("<td  align='left'>" + string.Format(Convert.ToBoolean(drRecords["ShowDecimalPoint"]) == true ? "{0:N1}" : "{0:N0}", drRecords["Total"]) + "</td>");

                            if (drReport.Length > 1) strHTML.Append("</tr>");
                        }
                        if (i < dtRecordType.Rows.Count - 1)
                            strHTML.Append("<tr align='left'><td colspan='14'>&nbsp;</td>");
                    }

                    //strHTML.Append("<tr><td colspan='14' >&nbsp;</td></tr>");
                    strHTML.Append("</table>");
                    strHTML.Append("</table>");
                }
                else
                {
                    // if record not found then hide Header and set width and height so scroll bar not visible.            
                    strHTML.Append("<table style='font-family:Tahoma' cellpadding='4' cellspacing='0' Width='100%' border='1'>");
                    strHTML.Append("<tr>");
                    strHTML.Append("<td align='center' >No Records found.</td></tr></table>");
                }
                #endregion

                //Write HTML in to HtmlWriter
                htmlWrite.WriteLine(strHTML.ToString());
                //Send Mail
                SendMail("Customer Relations Incident Summary Report", "CustomerRelationsIncidentSummaryReport.xls", strFirstName, strLastName, strMailFrom, stringWrite, dtRecipients);
            }
        }

        // Report 45
        private void BindNonCustomerInquirySummaryReport(DataRow drReportSchedule)
        {
            decimal pK_Schedule_ID = Convert.ToDecimal(drReportSchedule["PK_Schedule"]);
            decimal Fk_RecipientList = Convert.ToDecimal(drReportSchedule["Fk_RecipientList"]);
            decimal FK_Security_Id = Convert.ToDecimal(drReportSchedule["FK_Security_Id"]);

            //Get Report criteria for the scheduled report
            DataTable dtFilter = Report.SelectFilterCriteria(45, pK_Schedule_ID).Tables[0];
            if (dtFilter.Rows.Count > 0)
            {
                //Get the recipient from the recipient list 
                DataTable dtRecipients = Report.SelectOneRecordWithRecipientList(Fk_RecipientList).Tables[0];

                //Get the user who has scheduled the report
                DataTable dtUser = Report.SelectSecurityByPK(FK_Security_Id).Tables[0];

                String strFirstName, strLastName, strMailFrom;
                strFirstName = strLastName = strMailFrom = "";
                if (dtUser.Rows.Count > 0)
                {
                    strFirstName = Convert.ToString(dtUser.Rows[0]["FIRST_NAME"]).Trim();
                    strLastName = Convert.ToString(dtUser.Rows[0]["LAST_NAME"]).Trim();
                    strMailFrom = Convert.ToString(dtUser.Rows[0]["Email"]).Trim();
                }

                string strFK_LU_Locations = Convert.ToString(dtFilter.Rows[0]["FK_LU_LocationIDs"]).Trim();
                string strYear = Convert.ToString(dtFilter.Rows[0]["Year"]);

                //Create HTML for the report and wirte into HTML Write object
                StringBuilder strHTML = new StringBuilder();
                System.IO.StringWriter stringWrite = new System.IO.StringWriter();
                System.Web.UI.HtmlTextWriter htmlWrite = new System.Web.UI.HtmlTextWriter(stringWrite);

                #region "Report Title"

                //Add Report Title and Schedule Date
                strHTML.Append("<br />");
                strHTML.Append("<b>Report Title : Non-Customer Inquiry Summary </b>");
                strHTML.Append("<br /><br />");
                strHTML.Append("Schedule Start Date : " + Convert.ToDateTime(drReportSchedule["Scheduled_Date"]).ToString(DateDisplayFormat));
                strHTML.Append("&nbsp;&nbsp;&nbsp;&nbsp;Schedule End Date : " + Convert.ToDateTime(drReportSchedule["Schedule_End_Date"]).ToString(DateDisplayFormat));
                strHTML.Append("<br />");
                strHTML.Append("Recurring Period : " + drReportSchedule["Recurring_Period"].ToString());
                strHTML.Append("<br />");
                strHTML.Append("Recurring Date : " + dtSchduleDate.ToString(DateDisplayFormat));

                //Add Report Filter Criteria 
                strHTML.Append("<br /><br /><table> <tr> <td colspan='14'>");
                strHTML.Append("<b>Report Filters </b>");
                strHTML.Append("<br /><tr> <td colspan='14'>");
                strHTML.Append("Year   : " + strYear);
                strHTML.Append("</td> </tr>");
                strHTML.Append("<tr> <td colspan='14'><table cellspacing='0' cellpadding='0' width='100%'><tr><td colspan='14'>");
                strHTML.Append("Location D/B/A   : " + Report.GetCommaSepratedDBAFromIDs(strFK_LU_Locations) + "</td></tr></table>");
                strHTML.Append("</td> </tr>");
                strHTML.Append("<tr> <td colspan='14'>");
                strHTML.Append("</td></tr></table> ");

                #endregion

                #region "Report Data"

                DataSet dsReport = Report.GetNonCustomerInquiryData(Convert.ToInt32(strYear), Convert.ToString(dtFilter.Rows[0]["FK_LU_LocationIDs"]));

                DataTable dtRecordType = dsReport.Tables[0];
                DataTable dtReport = dsReport.Tables[1];

                // Check if record found or not.
                if (dtReport.Rows.Count > 0)
                {
                    strHTML.Append("<table border='1'  cellpadding='0' cellspacing='0'  Width='100%px'><tr><td  >");
                    strHTML.Append("<table cellpadding='4' cellspacing='0' Width='100%' border='1'>");//Sub Table
                    strHTML.Append("<tr style='font-weight: bold;'>"); //Title
                    strHTML.Append("<td align='center' colspan='14' ><b> Non-Customer Inquiry Summary Report for " + strYear + " </b></td>");
                    strHTML.Append("</tr>");

                    strHTML.Append("<tr align='left'  style='font-weight: bold;'>");
                    strHTML.Append("<td  width='100px'>&nbsp;</td>");
                    strHTML.Append("<td  width='56px' align='left'>JAN</td>");
                    strHTML.Append("<td  width='56px' align='left'>FEB</td>");
                    strHTML.Append("<td  width='56px' align='left'>MAR</td>");
                    strHTML.Append("<td  width='56px' align='left'>APR</td>");
                    strHTML.Append("<td  width='56px' align='left'>MAY</td>");
                    strHTML.Append("<td  width='56px' align='left'>JUN</td>");
                    strHTML.Append("<td  width='56px' align='left'>JUL</td>");
                    strHTML.Append("<td  width='56px' align='left'>AUG</td>");
                    strHTML.Append("<td  width='56px' align='left'>SEP</td>");
                    strHTML.Append("<td  width='56px' align='left'>OCT</td>");
                    strHTML.Append("<td  width='56px' align='left'>NOV</td>");
                    strHTML.Append("<td  width='56px' align='left'>DEC</td>");
                    strHTML.Append("<td  width='56px' align='left'>Total</td>");
                    strHTML.Append("</tr>");


                    for (int i = 0; i < dtRecordType.Rows.Count; i++)
                    {
                        string strRecordType = Convert.ToString(dtRecordType.Rows[i]["Type"]);
                        DataRow[] drReport = dtReport.Select("Type = '" + strRecordType + "'");

                        strHTML.Append("<tr align='left'>");
                        strHTML.Append("<td align='left' " + ((drReport.Length > 1) ? "colspan='14'" : "") + "><b>" + strRecordType + "</b></td>");

                        if (drReport.Length > 1) strHTML.Append("</tr>");

                        for (int j = 0; j < drReport.Length; j++)
                        {
                            DataRow drRecords = drReport[j];
                            if (drReport.Length > 1)
                            {
                                strHTML.Append("<tr align='left'>");
                                strHTML.Append("<td  align='left'>" + Convert.ToString(drRecords["Description"]) + "</td>");
                            }

                            strHTML.Append("<td  align='left'>" + string.Format("{0:N0}", drRecords["JAN"]) + "</td>");
                            strHTML.Append("<td  align='left'>" + string.Format("{0:N0}", drRecords["FEB"]) + "</td>");
                            strHTML.Append("<td  align='left'>" + string.Format("{0:N0}", drRecords["MAR"]) + "</td>");
                            strHTML.Append("<td  align='left'>" + string.Format("{0:N0}", drRecords["APR"]) + "</td>");
                            strHTML.Append("<td  align='left'>" + string.Format("{0:N0}", drRecords["MAY"]) + "</td>");
                            strHTML.Append("<td  align='left'>" + string.Format("{0:N0}", drRecords["JUN"]) + "</td>");
                            strHTML.Append("<td  align='left'>" + string.Format("{0:N0}", drRecords["JUL"]) + "</td>");
                            strHTML.Append("<td  align='left'>" + string.Format("{0:N0}", drRecords["AUG"]) + "</td>");
                            strHTML.Append("<td  align='left'>" + string.Format("{0:N0}", drRecords["SEP"]) + "</td>");
                            strHTML.Append("<td  align='left'>" + string.Format("{0:N0}", drRecords["OCT"]) + "</td>");
                            strHTML.Append("<td  align='left'>" + string.Format("{0:N0}", drRecords["NOV"]) + "</td>");
                            strHTML.Append("<td  align='left'>" + string.Format("{0:N0}", drRecords["DEC"]) + "</td>");
                            strHTML.Append("<td  align='left'>" + string.Format("{0:N0}", drRecords["Total"]) + "</td>");

                            if (drReport.Length > 1) strHTML.Append("</tr>");
                        }

                        if (i < dtRecordType.Rows.Count - 1)
                            strHTML.Append("<tr align='left'><td colspan='14'>&nbsp;</td>");
                    }

                    //strHTML.Append("<tr><td colspan='14' >&nbsp;</td></tr>");
                    strHTML.Append("</table>");
                    strHTML.Append("</table>");
                }
                else
                {
                    // if record not found then hide Header and set width and height so scroll bar not visible.            
                    strHTML.Append("<table cellpadding='4' cellspacing='0' Width='100%' border='1'>");
                    strHTML.Append("<tr>");
                    strHTML.Append("<td align='center'>No Records found.</td></tr></table>");
                }
                #endregion

                //Write HTML in to HtmlWriter
                htmlWrite.WriteLine(strHTML.ToString());
                //Send Mail
                SendMail("Non-Customer Inquiry Summary", "NonCustomerInquirySummary.xls", strFirstName, strLastName, strMailFrom, stringWrite, dtRecipients);
            }
        }

        // Report 46
        private void BindCustomerIncidentTotalsReport(DataRow drReportSchedule)
        {
            decimal pK_Schedule_ID = Convert.ToDecimal(drReportSchedule["PK_Schedule"]);
            decimal Fk_RecipientList = Convert.ToDecimal(drReportSchedule["Fk_RecipientList"]);
            decimal FK_Security_Id = Convert.ToDecimal(drReportSchedule["FK_Security_Id"]);

            //Get Report criteria for the scheduled report
            DataTable dtFilter = Report.SelectFilterCriteria(46, pK_Schedule_ID).Tables[0];
            if (dtFilter.Rows.Count > 0)
            {
                //Get the recipient from the recipient list 
                DataTable dtRecipients = Report.SelectOneRecordWithRecipientList(Fk_RecipientList).Tables[0];

                //Get the user who has scheduled the report
                DataTable dtUser = Report.SelectSecurityByPK(FK_Security_Id).Tables[0];

                String strFirstName, strLastName, strMailFrom;
                strFirstName = strLastName = strMailFrom = "";
                if (dtUser.Rows.Count > 0)
                {
                    strFirstName = Convert.ToString(dtUser.Rows[0]["FIRST_NAME"]).Trim();
                    strLastName = Convert.ToString(dtUser.Rows[0]["LAST_NAME"]).Trim();
                    strMailFrom = Convert.ToString(dtUser.Rows[0]["Email"]).Trim();
                }

                string strFK_LU_Locations = Convert.ToString(dtFilter.Rows[0]["FK_LU_LocationIDs"]).Trim();
                DateTime dtBegin = Convert.ToDateTime(dtFilter.Rows[0]["Begin_Date"]);
                DateTime dtEnd = Convert.ToDateTime(dtFilter.Rows[0]["End_Date"]);

                //Create HTML for the report and wirte into HTML Write object
                StringBuilder strHTML = new StringBuilder();
                System.IO.StringWriter stringWrite = new System.IO.StringWriter();
                System.Web.UI.HtmlTextWriter htmlWrite = new System.Web.UI.HtmlTextWriter(stringWrite);

                #region "Report Title"

                //Add Report Title and Schedule Date
                strHTML.Append("<br />");
                strHTML.Append("<b>Report Title : Customer Relationship Incident Totals by Dealership </b>");
                strHTML.Append("<br /><br />");
                strHTML.Append("Schedule Start Date : " + Convert.ToDateTime(drReportSchedule["Scheduled_Date"]).ToString(DateDisplayFormat));
                strHTML.Append("&nbsp;&nbsp;&nbsp;&nbsp;Schedule End Date : " + Convert.ToDateTime(drReportSchedule["Schedule_End_Date"]).ToString(DateDisplayFormat));
                strHTML.Append("<br />");
                strHTML.Append("Recurring Period : " + drReportSchedule["Recurring_Period"].ToString());
                strHTML.Append("<br />");
                strHTML.Append("Recurring Date : " + dtSchduleDate.ToString(DateDisplayFormat));

                //Add Report Filter Criteria 
                strHTML.Append("<br /><br /><table> <tr> <td colspan='7'>");
                strHTML.Append("<b>Report Filters </b>");
                strHTML.Append("<br /><tr> <td colspan='7'>");
                strHTML.Append("Time Period Begin   : " + FormatDateToDisplay(dtBegin));
                strHTML.Append("</td> </tr>");
                strHTML.Append("<tr> <td colspan='7'>");
                strHTML.Append("Time Period End  : " + FormatDateToDisplay(dtEnd));
                strHTML.Append("</td> </tr>");
                strHTML.Append("<tr> <td colspan='7'><table cellspacing='0' cellpadding='0' width='100%'><tr><td colspan='7'>");
                strHTML.Append("Location D/B/A   : " + Report.GetCommaSepratedDBAFromIDs(strFK_LU_Locations) + "</td></tr></table>");
                strHTML.Append("</td> </tr>");
                strHTML.Append("<tr> <td colspan='7'>");
                strHTML.Append("</td></tr></table> ");

                #endregion

                #region "Report Data"

                DataSet dsReport = Report.GetIncidentTotalsByDealership(dtBegin, dtEnd, Convert.ToString(dtFilter.Rows[0]["FK_LU_LocationIDs"]));

                DataTable dtReport = dsReport.Tables[0];
                dtReport.Columns.Add(new DataColumn("Total", typeof(int)));

                for (int i = 0; i < dtReport.Rows.Count; i++)
                {
                    decimal? decTotal = 0;

                    for (int j = 1; j < dtReport.Columns.Count - 1; j++)
                    {
                        decTotal = decTotal + Convert.ToDecimal(dtReport.Rows[i][j]);
                    }
                    dtReport.Rows[i]["Total"] = decTotal;
                }

                int intColspan = dtReport.Columns.Count;

                // Check if record found or not.
                if (dtReport.Rows.Count > 0)
                {
                    strHTML.Append("<table border='1' cellpadding='0' cellspacing='0'  Width='100%px'><tr><td >");
                    strHTML.Append("<table cellpadding='4' cellspacing='0' Width='100%' border='1'>");//Sub Table
                    strHTML.Append("<tr style='font-weight: bold;'>"); //Title
                    strHTML.Append("<td align='center' colspan='" + intColspan.ToString() + "' ><b> Customer Relationship Incident Totals by Dealership Report for " + FormatDateToDisplay(dtBegin) + " To " + FormatDateToDisplay(dtEnd) + " </b></td>");
                    strHTML.Append("</tr>");

                    strHTML.Append("<tr align='left'  style='font-weight: bold;'>");
                    strHTML.Append("<td width='230px'>Location D/B/A</td>");
                    for (int j = 1; j < dtReport.Columns.Count; j++)
                    {
                        strHTML.Append("<td width='120px' align='left'>" + dtReport.Columns[j].ColumnName + "</td>");
                    }
                    strHTML.Append("</tr>");


                    for (int i = 0; i < dtReport.Rows.Count; i++)
                    {
                        strHTML.Append("<tr align='left'>");

                        DataRow drRecords = dtReport.Rows[i];

                        for (int j = 0; j < dtReport.Columns.Count; j++)
                        {
                            if (j == 0)
                                strHTML.Append("<td align='left'>" + Convert.ToString(drRecords["DBA"]) + "</td>");
                            else
                                strHTML.Append("<td align='left'>" + string.Format("{0:N0}", drRecords[j]) + "</td>");
                        }
                    }

                    //strHTML.Append("<tr><td colspan='14' class='cols_'>&nbsp;</td></tr>");
                    strHTML.Append("</table>");
                    strHTML.Append("</table>");
                }
                else
                {
                    // if record not found then hide Header and set width and height so scroll bar not visible.            
                    strHTML.Append("<table cellpadding='4' cellspacing='0' Width='100%' border='1'>");
                    strHTML.Append("<tr>");
                    strHTML.Append("<td align='center'>No Records found.</td></tr></table>");
                }
                #endregion

                //Write HTML in to HtmlWriter
                htmlWrite.WriteLine(strHTML.ToString());
                //Send Mail
                SendMail("Customer Relationship Incident Totals by Dealership", "CustomerIncidentTotalsbyDealership.xls", strFirstName, strLastName, strMailFrom, stringWrite, dtRecipients);
            }
        }

        // Report 47, 48, 49, 50
        private void BindDashboardReport(DashboardReport objRptDashboard, DataRow drReportSchedule, int intReportID)
        {
            decimal pK_Schedule_ID = Convert.ToDecimal(drReportSchedule["PK_Schedule"]);
            decimal Fk_RecipientList = Convert.ToDecimal(drReportSchedule["Fk_RecipientList"]);
            decimal FK_Security_Id = Convert.ToDecimal(drReportSchedule["FK_Security_Id"]);


            //Get Report criteria for the scheduled report
            DataTable dtFilter = Report.SelectFilterCriteria(intReportID, pK_Schedule_ID).Tables[0];
            if (dtFilter.Rows.Count > 0)
            {
                //Get the recipient from the recipient list 
                DataTable dtRecipients = Report.SelectOneRecordWithRecipientList(Fk_RecipientList).Tables[0];

                //Get the user who has scheduled the report
                DataTable dtUser = Report.SelectSecurityByPK(FK_Security_Id).Tables[0];

                String strFirstName, strLastName, strMailFrom;
                strFirstName = strLastName = strMailFrom = "";
                if (dtUser.Rows.Count > 0)
                {
                    strFirstName = Convert.ToString(dtUser.Rows[0]["FIRST_NAME"]).Trim();
                    strLastName = Convert.ToString(dtUser.Rows[0]["LAST_NAME"]).Trim();
                    strMailFrom = Convert.ToString(dtUser.Rows[0]["Email"]).Trim();
                }

                //Create HTML for the report and wirte into HTML Write object
                StringBuilder strHTML = new StringBuilder();

                // get report text as per the report type
                strHTML.Append(GetDashboardReportText(drReportSchedule, dtFilter, FK_Security_Id, objRptDashboard));

                System.IO.StringWriter stringWrite = new System.IO.StringWriter();
                System.Web.UI.HtmlTextWriter htmlWrite = new System.Web.UI.HtmlTextWriter(stringWrite);
                //Write HTML in to HtmlWriter
                htmlWrite.WriteLine(strHTML.ToString());


                string strReportTitle = "";
                string strXLSFileName = "";

                if (objRptDashboard == DashboardReport.Facility_Inspection)
                {
                    strReportTitle = "Facility Inspection Report"; strXLSFileName = "FacilityInspectionReport.xls";
                }
                else if (objRptDashboard == DashboardReport.Incident_Investigation)
                {
                    strReportTitle = "Incident Investigation Report"; strXLSFileName = "IncidentInvestigationReport.xls";
                }
                else if (objRptDashboard == DashboardReport.Incident_Reduction)
                {
                    strReportTitle = "Incident Reduction Report"; strXLSFileName = "IncidentReductionReport.xls";
                }
                else if (objRptDashboard == DashboardReport.WC_Claim_Management)
                {
                    strReportTitle = "Worker's Compensation Claims Management"; strXLSFileName = "WCClaimsManagement.xls";
                }
                //Send Mail
                SendMail(strReportTitle, strXLSFileName, strFirstName, strLastName, strMailFrom, stringWrite, dtRecipients);
            }
        }

        //Report 51
        private void BindCriticalDatesReport(DataRow drReportSchedule)
        {
            try
            {
                decimal pK_Schedule_ID = Convert.ToDecimal(drReportSchedule["PK_Schedule"]);
                decimal Fk_RecipientList = Convert.ToDecimal(drReportSchedule["Fk_RecipientList"]);
                decimal FK_Security_Id = Convert.ToDecimal(drReportSchedule["FK_Security_Id"]);

                //Get Report criteria for the scheduled report
                DataTable dtFilter = Report.SelectFilterCriteria(51, pK_Schedule_ID).Tables[0];
                if (dtFilter.Rows.Count > 0)
                {
                    //Get the recipient from the recipient list 
                    DataTable dtRecipients = Report.SelectOneRecordWithRecipientList(Fk_RecipientList).Tables[0];

                    //Get the user who has scheduled the report
                    DataTable dtUser = Report.SelectSecurityByPK(FK_Security_Id).Tables[0];

                    String strFirstName, strLastName, strMailFrom, strStatus;
                    strFirstName = strLastName = strMailFrom = "";
                    if (dtUser.Rows.Count > 0)
                    {
                        strFirstName = Convert.ToString(dtUser.Rows[0]["FIRST_NAME"]).Trim();
                        strLastName = Convert.ToString(dtUser.Rows[0]["LAST_NAME"]).Trim();
                        strMailFrom = Convert.ToString(dtUser.Rows[0]["Email"]).Trim();

                        //Set all filters to a variable as per report type
                        DateTime? dtLCDFrom = null, dtLCDTo = null, dtLEDFrom = null, dtLEDTo = null;

                        string strRegion = Convert.ToString(dtFilter.Rows[0]["Region"]).Trim();
                        string strMarket = null;
                        if (!string.IsNullOrEmpty(Convert.ToString(dtFilter.Rows[0]["Market"])))
                        {
                            strMarket = Convert.ToString(dtFilter.Rows[0]["Market"]).Trim();
                        }
                        string strLeaseType = Convert.ToString(dtFilter.Rows[0]["LeaseType"]).Trim();
                        strStatus = Convert.ToString(dtFilter.Rows[0]["Status"]).Trim();

                        if (!string.IsNullOrEmpty(Convert.ToString(dtFilter.Rows[0]["LCDFrom_Date"])))
                            dtLCDFrom = Convert.ToDateTime(dtFilter.Rows[0]["LCDFrom_Date"]);

                        if (!string.IsNullOrEmpty(Convert.ToString(dtFilter.Rows[0]["LCDTo_Date"])))
                            dtLCDTo = Convert.ToDateTime(dtFilter.Rows[0]["LCDTo_Date"]);

                        if (!string.IsNullOrEmpty(Convert.ToString(dtFilter.Rows[0]["LEDFrom_Date"])))
                            dtLEDFrom = Convert.ToDateTime(dtFilter.Rows[0]["LEDFrom_Date"]);

                        if (!string.IsNullOrEmpty(Convert.ToString(dtFilter.Rows[0]["LEDTo_Date"])))
                            dtLEDTo = Convert.ToDateTime(dtFilter.Rows[0]["LEDTo_Date"]);


                        //Create HTML for the report and wirte into HTML Write object
                        StringBuilder strHTML = new StringBuilder();
                        System.IO.StringWriter stringWrite = new System.IO.StringWriter();
                        System.Web.UI.HtmlTextWriter htmlWrite = new System.Web.UI.HtmlTextWriter(stringWrite);

                        #region "Search Criteria"

                        //Retrieve Market Values
                        string strMarketString = string.Empty;
                        if (string.IsNullOrEmpty(strMarket))
                        {
                            strMarketString = "All Market";
                        }
                        else
                        {
                            string[] strMar = strMarket.Split(Convert.ToChar(","));
                            for (int i = 0; i < strMar.Length; i++)
                            {
                                strMarketString += Report.SelectMarketInfoById(Convert.ToDecimal(strMar[i].ToString())).Tables[0].Rows[0]["Market"].ToString() + ",";
                            }
                            strMarketString = strMarketString.TrimEnd(',');
                        }

                        //Add Report Title and Schedule Date
                        strHTML.Append("<br />");
                        strHTML.Append("<b>Report Title : Critical Dates Report</b>");
                        strHTML.Append("<br /><br />");
                        strHTML.Append("Schedule Date : " + Convert.ToDateTime(drReportSchedule["Scheduled_Date"]).ToString(DateDisplayFormat));
                        strHTML.Append("&nbsp;&nbsp;&nbsp;&nbsp;Schedule End Date : " + Convert.ToDateTime(drReportSchedule["Schedule_End_Date"]).ToString(DateDisplayFormat));
                        strHTML.Append("<br />");
                        strHTML.Append("Recurring Period : " + drReportSchedule["Recurring_Period"].ToString());
                        strHTML.Append("<br />");
                        strHTML.Append("Recurring Date : " + dtSchduleDate.ToString(DateDisplayFormat));

                        //Add Report Filter Criteria 
                        strHTML.Append("<br /><br />");
                        strHTML.Append("<b>Report Filters </b>");
                        strHTML.Append("<br /><br />");
                        strHTML.Append("Region        : " + strRegion.Replace("'", ""));
                        strHTML.Append("<br />");
                        strHTML.Append("Market        : " + strMarketString);
                        strHTML.Append("<br /><br />");
                        strHTML.Append("LCD From      : " + FormatDBNullDateToDisplay(dtLCDFrom));
                        strHTML.Append("<br />");
                        strHTML.Append("LCD To        : " + FormatDBNullDateToDisplay(dtLCDTo));
                        strHTML.Append("<br />");
                        strHTML.Append("LED From      : " + FormatDBNullDateToDisplay(dtLEDFrom));
                        strHTML.Append("<br />");
                        strHTML.Append("LED To        : " + FormatDBNullDateToDisplay(dtLEDTo));
                        strHTML.Append("<br />");
                        strHTML.Append("Building Status        : " + strStatus.Replace("'", ""));
                        strHTML.Append("<br /><br />");

                        #endregion

                        #region "Grid Data"

                        strHTML.Append("<table cellspacing='0' cellpadding='0' align='Left' border='0' style='width: 1340px; border-collapse: collapse;'>");
                        //Header Row
                        strHTML.Append("<tr align='left'><td align='left'>");
                        strHTML.Append("<table width='1625px' cellpadding='0' cellspacing='0' border='0'>");
                        strHTML.Append("<tr><td align='left'>");
                        strHTML.Append("<table width='1625px' cellpadding='0' cellspacing='0' border='1' style='font-weight: bold;'>");
                        strHTML.Append("<tr style='font-weight: bold;'>");
                        strHTML.Append("<td align='left' colspan='2'>Sonic Automotive</td>");
                        strHTML.Append("<td align='center' colspan='3'>Critical Dates Report</td>");
                        strHTML.Append("<td align='right' colspan='4'>" + FormatDBNullDateToDisplay(DateTime.Now) + " </td>");
                        strHTML.Append("</tr>");

                        strHTML.Append("<tr style='font-weight: bold;'>");
                        strHTML.Append("<td align='left' style='width: 100px'>LED</td>");
                        strHTML.Append("<td align='left' style='width: 180px'>Location</td>");
                        strHTML.Append("<td align='left' style='width: 560px'>");
                        strHTML.Append("<table width='100%' cellpadding='0' cellspacing='0' border='1' style='font-weight: bold;'>");
                        strHTML.Append("<tr>");
                        strHTML.Append("<td align='left' style='width: 40%'>Building Address</td>");
                        strHTML.Append("<td align='left' style='width: 30%'>Building Number</td>");
                        strHTML.Append("<td align='left' style='width: 30%'>Building Landlord Name</td>");
                        strHTML.Append("</tr>");
                        strHTML.Append("</table>");
                        strHTML.Append("</td>");
                        strHTML.Append("<td align='left' style='width: 100px'>LCD</td>");
                        strHTML.Append("<td align='left' style='width: 100px'>LL Notify Date</td>");
                        strHTML.Append("<td align='left' style='width: 100px'>Reminder Date</td>");
                        strHTML.Append("<td align='left' style='width: 100px'>Review Date</td>");
                        strHTML.Append("<td align='right' style='width: 100px'>Monthly Rent</td>");
                        strHTML.Append("<td align='left' style='width: 180px'>Renewals</td>");

                        strHTML.Append("</tr>");
                        strHTML.Append("</table>");
                        strHTML.Append("</td></tr>");
                        strHTML.Append("</table>");
                        strHTML.Append("</td></tr>");


                        //get the all Employee records by search criteria by group
                        DataSet dsDetails = Report.GetCriticalDatesReport(strRegion, strMarket, dtLCDFrom, dtLCDTo, dtLEDFrom, dtLEDTo, strStatus, "CriticalDates");

                        if (dsDetails != null && dsDetails.Tables.Count > 0 && dsDetails.Tables[0].Rows.Count > 0)
                        {
                            DataTable dtLocation = dsDetails.Tables[0];
                            DataTable dtDetails = dsDetails.Tables[0];

                            strHTML.Append("<tr align='left'><td align='left'>");
                            strHTML.Append("<table width='1625px' cellpadding='0' cellspacing='0' border='0'>");
                            strHTML.Append("<tr><td align='left'>");
                            strHTML.Append("<table cellspacing='0' cellpadding='0' align='Left' border='1' style='width: 100%; border-collapse: collapse;'>");

                            //foreach (DataRow dr in dtLocation.Rows)
                            //{
                            // DataRow[] drDetails = dtDetails.Select("DBA='" + dr["DBA"] + "'");
                            foreach (DataRow drDetail in dtLocation.Rows)
                            {
                                strHTML.Append("<tr>");
                                strHTML.Append("<td valign='top' align='left' style='width: 100px'>" + FormatDBNullDateToDisplay(drDetail["LED"]) + "</td>");
                                strHTML.Append("<td valign='top' align='left' style='width: 180px'>" + Convert.ToString(drDetail["DBA"]) + "</td>");
                                strHTML.Append("<td valign='top' align='left' valign='top' style='width: 560px'>");
                                decimal _PK_RE_Information = Convert.ToDecimal(drDetail["PK_RE_Information"]);
                                DataTable dtBuilding = Report.SelectByFK_RE_Information(_PK_RE_Information).Tables[0];
                                if (dtBuilding.Rows.Count > 0)
                                {
                                    foreach (DataRow drBuilding in dtBuilding.Rows)
                                    {

                                        strHTML.Append("<table cellspacing='0' cellpadding='0' align='Left' border='1' style='width: 100%; border-collapse: collapse;'>");
                                        strHTML.Append("<tr>");
                                        strHTML.Append("<td align='left' valign='top' style='width:40%'>" + (drBuilding["Address"]) + "</td>");
                                        strHTML.Append("<td align='left' valign='top' style='width:30%'>" + Convert.ToString(drBuilding["Building_Number"]) + "</td>");
                                        strHTML.Append("<td align='left' valign='top' style='width:30%'>" + Convert.ToString(drBuilding["Landlord_Name"]) + "</td>");
                                        strHTML.Append("</tr>");
                                        strHTML.Append("</table>");
                                    }
                                }
                                else
                                {
                                    strHTML.Append("<table cellspacing='0' cellpadding='0' align='Left' border='1' style='width: 100%; border-collapse: collapse;'>");
                                    strHTML.Append("<tr>");
                                    strHTML.Append("<td align='left' valign='top' style='width:40%'>" + "" + "</td>");
                                    strHTML.Append("<td align='left' valign='top' style='width:30%'>" + "" + "</td>");
                                    strHTML.Append("<td align='left' valign='top' style='width:30%'>" + "" + "</td>");
                                    strHTML.Append("</tr>");
                                    strHTML.Append("</table>");
                                }

                                strHTML.Append("</td>");
                                strHTML.Append("<td valign='top' align='left' style='width: 100px'>" + FormatDBNullDateToDisplay(drDetail["LCD"]) + "</td>");
                                strHTML.Append("<td valign='top' align='left' style='width: 100px'>" + FormatDBNullDateToDisplay(drDetail["LLNotifyDate"]) + "</td>");
                                strHTML.Append("<td valign='top' align='left' style='width: 100px'>" + FormatDBNullDateToDisplay(drDetail["ReminderDate"]) + "</td>");
                                strHTML.Append("<td valign='top' align='left' style='width: 100px'>" + FormatDBNullDateToDisplay(drDetail["ReviewDate"]) + "</td>");
                                strHTML.Append("<td valign='top' align='right' style='width: 100px'>" + string.Format("{0:N2}", drDetail["MonthlyRent"] != DBNull.Value ? Convert.ToDecimal(drDetail["MonthlyRent"]) : 0) + "</td>");
                                strHTML.Append("<td valign='top' align='left' style='width: 180px'>" + Convert.ToString(drDetail["Renewals"]) + "</td>");


                                strHTML.Append(" </tr>");
                            }
                            //}
                            strHTML.Append("</table>");
                            strHTML.Append("</td></tr>");
                            strHTML.Append("</table>");
                            strHTML.Append("</td></tr>");

                            //Footer Row
                            strHTML.Append("<tr align='left'><td align='left'>");
                            strHTML.Append(" <table width='1625px' cellpadding='0' cellspacing='0' border='0'>");
                            strHTML.Append("<tr><td align='left'>");
                            strHTML.Append("<table width='1625px' cellpadding='4' cellspacing='0' border='1' style='font-weight: bold;background-color: #507CD1; color: White;'>");
                            strHTML.Append("<tr style='font-weight: bold;'>");
                            strHTML.Append("<td align='left' style='width: 100px'>Report Grand Totals</td>");
                            strHTML.Append("<td align='left' style='width: 180px'>" + Convert.ToString(dtDetails.Rows.Count) + " </td>");
                            strHTML.Append("<td align='left' style='width: 560px'>&nbsp;</td>");
                            strHTML.Append("<td align='left' style='width: 100px'>&nbsp;</td>");
                            strHTML.Append("<td align='left' style='width: 100px'>&nbsp;</td>");
                            strHTML.Append("<td align='left' style='width: 100px'>&nbsp;</td>");
                            strHTML.Append("<td align='left' style='width: 100px'>&nbsp;</td>");
                            strHTML.Append("<td align='right' style='width: 100px'>" + string.Format("{0:N2}", dtDetails.Compute("sum(MonthlyRent)", "")) + "</td>");
                            strHTML.Append("<td align='left' style='width: 180px'>&nbsp;</td>");

                            strHTML.Append(" </tr>");
                            strHTML.Append("</table>");
                            strHTML.Append("</td></tr>");
                            strHTML.Append("</table>");
                            strHTML.Append("</td></tr>");
                        }
                        else
                        {
                            strHTML.Append("<tr> <td style='font-weight: bold;'> No Record Found.");
                            strHTML.Append("</td></tr>");
                        }

                        strHTML.Append("</table>");
                        #endregion

                        //Write HTML in to HtmlWriter
                        htmlWrite.WriteLine(strHTML.ToString());

                        //Send Mail
                        SendMail("Critical Dates Report", "CriticalDates.xls", strFirstName, strLastName, strMailFrom, stringWrite, dtRecipients);
                    }
                }
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("ERROR in Critical Dates Report, " + ex.Message);
            }
        }

        //Report 52
        private void BindSubLeaseReport(DataRow drReportSchedule)
        {
            decimal pK_Schedule_ID = Convert.ToDecimal(drReportSchedule["PK_Schedule"]);
            decimal Fk_RecipientList = Convert.ToDecimal(drReportSchedule["Fk_RecipientList"]);
            decimal FK_Security_Id = Convert.ToDecimal(drReportSchedule["FK_Security_Id"]);

            //Get Report criteria for the scheduled report
            DataTable dtFilter = Report.SelectFilterCriteria(52, pK_Schedule_ID).Tables[0];
            if (dtFilter.Rows.Count > 0)
            {
                //Get the recipient from the recipient list 
                DataTable dtRecipients = Report.SelectOneRecordWithRecipientList(Fk_RecipientList).Tables[0];

                //Get the user who has scheduled the report
                DataTable dtUser = Report.SelectSecurityByPK(FK_Security_Id).Tables[0];

                String strFirstName, strLastName, strMailFrom;
                strFirstName = strLastName = strMailFrom = "";
                if (dtUser.Rows.Count > 0)
                {
                    strFirstName = Convert.ToString(dtUser.Rows[0]["FIRST_NAME"]).Trim();
                    strLastName = Convert.ToString(dtUser.Rows[0]["LAST_NAME"]).Trim();
                    strMailFrom = Convert.ToString(dtUser.Rows[0]["Email"]).Trim();
                }
                string strRegion = Convert.ToString(dtFilter.Rows[0]["Location"]).Trim();
                string strMarket = null;
                if (!string.IsNullOrEmpty(Convert.ToString(dtFilter.Rows[0]["Market"])))
                {
                    strMarket = Convert.ToString(dtFilter.Rows[0]["Market"]).Trim();
                }
                string strStatus = Convert.ToString(dtFilter.Rows[0]["Status"]).Trim();
                //Set all filters to a variable as per report type
                DateTime? dtLCDFrom = null, dtLCDTo = null, dtLEDFrom = null, dtLEDTo = null;

                if (dtFilter.Rows[0]["LCDFrom_Date"] != DBNull.Value)
                    dtLCDFrom = Convert.ToDateTime(dtFilter.Rows[0]["LCDFrom_Date"]);

                if (Convert.ToString(dtFilter.Rows[0]["LCDTo_Date"]) != string.Empty && dtFilter.Rows[0]["LCDTo_Date"] != DBNull.Value)
                    dtLCDTo = Convert.ToDateTime(dtFilter.Rows[0]["LCDTo_Date"]);

                if (Convert.ToString(dtFilter.Rows[0]["LEDFrom_Date"]) != string.Empty && dtFilter.Rows[0]["LEDFrom_Date"] != DBNull.Value)
                    dtLEDFrom = Convert.ToDateTime(dtFilter.Rows[0]["LEDFrom_Date"]);

                if (Convert.ToString(dtFilter.Rows[0]["LEDTo_Date"]) != string.Empty && dtFilter.Rows[0]["LEDTo_Date"] != DBNull.Value)
                    dtLEDTo = Convert.ToDateTime(dtFilter.Rows[0]["LEDTo_Date"]);

                DataSet dsResult = Report.GetSubLeaseReport(strRegion, strMarket, dtLCDFrom, dtLCDTo, dtLEDFrom, dtLEDTo, FK_Security_Id, strStatus);


                //Create HTML for the report and wirte into HTML Write object
                StringBuilder strHTML = new StringBuilder();
                System.IO.StringWriter stringWrite = new System.IO.StringWriter();
                System.Web.UI.HtmlTextWriter htmlWrite = new System.Web.UI.HtmlTextWriter(stringWrite);

                #region "Report Title"

                //Retrieve Market Values
                string strMarketString = string.Empty;
                if (string.IsNullOrEmpty(strMarket))
                {
                    strMarketString = "All Market";
                }
                else
                {
                    string[] strMar = strMarket.Split(Convert.ToChar(","));
                    for (int i = 0; i < strMar.Length; i++)
                    {
                        strMarketString += Report.SelectMarketInfoById(Convert.ToDecimal(strMar[i].ToString())).Tables[0].Rows[0]["Market"].ToString() + ",";
                    }
                    strMarketString = strMarketString.TrimEnd(',');
                }

                //Add Report Title and Schedule Date
                strHTML.Append("<br />");
                strHTML.Append("<b>Report Title : Sublease Report</b>");
                strHTML.Append("<br /><br />");
                strHTML.Append("Schedule Date : " + Convert.ToDateTime(drReportSchedule["Scheduled_Date"]).ToString(DateDisplayFormat));
                strHTML.Append("&nbsp;&nbsp;&nbsp;&nbsp;Schedule End Date : " + Convert.ToDateTime(drReportSchedule["Schedule_End_Date"]).ToString(DateDisplayFormat));
                strHTML.Append("<br />");
                strHTML.Append("Recurring Period : " + drReportSchedule["Recurring_Period"].ToString());
                strHTML.Append("<br />");
                strHTML.Append("Recurring Date : " + dtSchduleDate.ToString(DateDisplayFormat));

                //Add Report Filter Criteria 
                strHTML.Append("<br /><br /><table> <tr> <td>");
                strHTML.Append("<b>Report Filters </b>");
                strHTML.Append("<br /><table> <tr> <td colspan='8'>");
                strHTML.Append("Region : " + (string.IsNullOrEmpty(strRegion) ? "" : strRegion.Replace("'", "")));
                // strHTML.Append("Location DBA   : " + strRegion);
                strHTML.Append("</td> </tr>");
                strHTML.Append("<br /><table> <tr> <td colspan='8'>");
                strHTML.Append("Market        : " + strMarketString);
                strHTML.Append("</td> </tr>");
                strHTML.Append("<br />");
                strHTML.Append("LCD From      : " + FormatDBNullDateToDisplay(dtLCDFrom));
                strHTML.Append("<br />");
                strHTML.Append("LCD To        : " + FormatDBNullDateToDisplay(dtLCDTo));
                strHTML.Append("<br />");
                strHTML.Append("LED From      : " + FormatDBNullDateToDisplay(dtLEDFrom));
                strHTML.Append("<br />");
                strHTML.Append("LED To        : " + FormatDBNullDateToDisplay(dtLEDTo));
                strHTML.Append("<br />");
                strHTML.Append("Building Status        : " + strStatus.Replace("'", ""));
                strHTML.Append("<br /><br />");
                strHTML.Append("<tr> <td colspan='8'>");
                strHTML.Append("</td></tr></table> ");


                #endregion

                #region "Report Grid header"
                //Top Header
                strHTML.Append("<table border='1'>");
                strHTML.Append("<tr style='font-weight: bold;' valign='bottom' align='left'>");
                strHTML.Append("<td align='left' colspan='2'>Sonic Automotive</td>");
                strHTML.Append("<td align='center' colspan='9'>Sublease Report</td>");
                strHTML.Append("<td align='right' colspan='3'> " + DateTime.Now.ToString() + " </td>");
                strHTML.Append("</tr>");

                //Sub Header
                strHTML.Append("<tr valign='bottom' align='left' style='font-weight: bold'>");
                strHTML.Append("<td width='150'>Location</td>");
                strHTML.Append("<td width='150'> Building Number</td>");
                strHTML.Append("<td width='160'>  Address 1</td>");
                strHTML.Append("<td width='160'>  Address 2</td>");
                strHTML.Append("<td width='150'>  City</td>");
                strHTML.Append("<td width='150'>  State</td>");
                strHTML.Append("<td width='150'>  Zip Code</td>");
                strHTML.Append("<td width='150'>Landlord Name</td>");
                strHTML.Append("<td width='150'> Sub-Lease Name</td>");
                strHTML.Append("<td width='210'>SubLease Commencement Date</td>");
                strHTML.Append("<td width='210'>SubLease Expiration Date</td>");
                strHTML.Append("<td width='210'>Sublease Notification Due Date </td>");
                strHTML.Append("<td width='150'>Monthly Sub-Rent</td>");
                strHTML.Append("<td width='150'>Renewals</td>");



                strHTML.Append("</tr>");

                //Check Whether Record Exists or Not
                if (dsResult != null && dsResult.Tables.Count > 0 && dsResult.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in dsResult.Tables[0].Rows)
                    {
                        strHTML.Append("<tr valign='top' align='left'>");

                        strHTML.Append("<td width='150'>" + Convert.ToString(dr["dba"]) + "</td>");
                        strHTML.Append("<td width='150'>" + Convert.ToString(dr["BUILDING_NUMBER"]) + "</td>");
                        strHTML.Append("<td width='160'>" + Convert.ToString(dr["Building_Address_1"]) + "</td>");
                        strHTML.Append("<td width='160'>" + Convert.ToString(dr["Building_Address_2"]) + "</td>");
                        strHTML.Append("<td width='150'>" + Convert.ToString(dr["Building_City"]) + "</td>");
                        strHTML.Append("<td width='150'>" + Convert.ToString(dr["Building_State"]) + "</td>");
                        strHTML.Append("<td width='150'>" + Convert.ToString(dr["Building_Zip"]) + "</td>");
                        strHTML.Append("<td width='150'>" + Convert.ToString(dr["LANDLORD_NAME"]) + "</td>");
                        strHTML.Append("<td width='150'>" + Convert.ToString(dr["SUBLEASE_NAME"]) + "</td>");
                        strHTML.Append("<td width='150'>" + FormatDBNullDateToDisplay(dr["COMMENCEMENT_DATE"]) + "</td>");
                        strHTML.Append("<td width='150'>" + FormatDBNullDateToDisplay(dr["EXPIRATION_DATE"]) + "</td>");
                        strHTML.Append("<td width='150'>" + FormatDBNullDateToDisplay(dr["Landlord_Notification_Date"]) + "</td>");
                        strHTML.Append("<td width='150'>" + Convert.ToString(String.Format("{0:C2}", dr["Subtenant_Monthly_Rent"])) + "</td>");
                        strHTML.Append("<td width='150'>" + Convert.ToString(dr["Renew_Options"]) + "</td>");


                        strHTML.Append("</tr>");
                    }
                }
                else
                {
                    //Add No record found line for year
                    strHTML.Append("<tr><td align='left' colspan='14'>No Record Found!</td></tr>");
                }
                strHTML.Append("</table>");

                #endregion

                //Write HTML in to HtmlWriter
                htmlWrite.WriteLine(strHTML.ToString());
                //Send Mail
                SendMail("Sublease Report", "SubLeaseReport.xls", strFirstName, strLastName, strMailFrom, stringWrite, dtRecipients);
            }

        }

        //Report 53
        private void BindSonicCauseCodeReclassificationReport(DataRow drReportSchedule)
        {
            try
            {
                decimal pK_Schedule_ID = Convert.ToDecimal(drReportSchedule["PK_Schedule"]);
                decimal Fk_RecipientList = Convert.ToDecimal(drReportSchedule["Fk_RecipientList"]);
                decimal FK_Security_Id = Convert.ToDecimal(drReportSchedule["FK_Security_Id"]);

                //Get Report criteria for the scheduled report
                DataTable dtFilter = Report.SelectFilterCriteria(53, pK_Schedule_ID).Tables[0];
                if (dtFilter.Rows.Count > 0)
                {
                    //Get the recipient from the recipient list 
                    DataTable dtRecipients = Report.SelectOneRecordWithRecipientList(Fk_RecipientList).Tables[0];

                    //Get the user who has scheduled the report
                    DataTable dtUser = Report.SelectSecurityByPK(FK_Security_Id).Tables[0];

                    String strFirstName, strLastName, strMailFrom;
                    strFirstName = strLastName = strMailFrom = "";
                    if (dtUser.Rows.Count > 0)
                    {
                        strFirstName = Convert.ToString(dtUser.Rows[0]["FIRST_NAME"]).Trim();
                        strLastName = Convert.ToString(dtUser.Rows[0]["LAST_NAME"]).Trim();
                        strMailFrom = Convert.ToString(dtUser.Rows[0]["Email"]).Trim();

                        DateTime? dtInjuryDateFrom = null, dtInjuryDateEnd = null;
                        string strRegion = string.Empty, strLocationStatus = string.Empty, strDBA = string.Empty, strClaimnumber = string.Empty;
                        decimal? decFirsrRepot = null, decIncidentNumber = null;


                        strRegion = Convert.ToString(dtFilter.Rows[0]["Region"]).Trim();
                        string strMarket = null;
                        if (!string.IsNullOrEmpty(Convert.ToString(dtFilter.Rows[0]["Market"])))
                        {
                            strMarket = Convert.ToString(dtFilter.Rows[0]["Market"]).Trim();
                        }
                        strDBA = Convert.ToString(dtFilter.Rows[0]["Location"]).Trim();
                        strClaimnumber = Convert.ToString(dtFilter.Rows[0]["ClaimNumber"]).Trim();


                        if (!string.IsNullOrEmpty(Convert.ToString(dtFilter.Rows[0]["Date_of_Injury_Begin"])))
                            dtInjuryDateFrom = Convert.ToDateTime(dtFilter.Rows[0]["Date_of_Injury_Begin"]);

                        if (!string.IsNullOrEmpty(Convert.ToString(dtFilter.Rows[0]["Date_of_Injury_End"])))
                            dtInjuryDateEnd = Convert.ToDateTime(dtFilter.Rows[0]["Date_of_Injury_End"]);

                        if (dtFilter.Rows[0]["FirstReportNumber"] != DBNull.Value)
                            decFirsrRepot = Convert.ToDecimal(dtFilter.Rows[0]["FirstReportNumber"]);
                        if (dtFilter.Rows[0]["IncidentInvestigationNumber"] != DBNull.Value)
                            decIncidentNumber = Convert.ToDecimal(dtFilter.Rows[0]["IncidentInvestigationNumber"]);

                        //Create HTML for the report and wirte into HTML Write object
                        StringBuilder strHTML = new StringBuilder();
                        System.IO.StringWriter stringWrite = new System.IO.StringWriter();
                        System.Web.UI.HtmlTextWriter htmlWrite = new System.Web.UI.HtmlTextWriter(stringWrite);

                        #region "Search Criteria"

                        //Retrieve Market Values
                        string strMarketString = string.Empty;
                        if (string.IsNullOrEmpty(strMarket))
                        {
                            strMarketString = "All Market";
                        }
                        else
                        {
                            string[] strMar = strMarket.Split(Convert.ToChar(","));
                            for (int i = 0; i < strMar.Length; i++)
                            {
                                strMarketString += Report.SelectMarketInfoById(Convert.ToDecimal(strMar[i].ToString())).Tables[0].Rows[0]["Market"].ToString() + ",";
                            }
                            strMarketString = strMarketString.TrimEnd(',');
                        }

                        //Add Report Title and Schedule Date
                        strHTML.Append("<br />");
                        strHTML.Append("<b>Report Title : Sonic Cause Code Reclassification Report</b>");
                        strHTML.Append("<br /><br />");
                        strHTML.Append("Schedule Date : " + Convert.ToDateTime(drReportSchedule["Scheduled_Date"]).ToString(DateDisplayFormat));
                        strHTML.Append("&nbsp;&nbsp;&nbsp;&nbsp;Schedule End Date : " + Convert.ToDateTime(drReportSchedule["Schedule_End_Date"]).ToString(DateDisplayFormat));
                        strHTML.Append("<br />");
                        strHTML.Append("Recurring Period : " + drReportSchedule["Recurring_Period"].ToString());
                        strHTML.Append("<br />");
                        strHTML.Append("Recurring Date : " + dtSchduleDate.ToString(DateDisplayFormat));

                        //Add Report Filter Criteria 
                        strHTML.Append("<br /><br />");
                        strHTML.Append("<b>Report Filters </b>");
                        strHTML.Append("<br /><br />");
                        strHTML.Append("Region        : " + strRegion.Replace("'", ""));
                        strHTML.Append("<br />");
                        strHTML.Append("Market        : " + strMarketString);
                        strHTML.Append("<br /><br />");
                        strHTML.Append("Location : " + (string.IsNullOrEmpty(strDBA) ? "" : GetCommaValueFromTable(Report.getLocationByIds(strDBA).Tables[0], "DBA")));
                        strHTML.Append("<br />");
                        strHTML.Append("Date of Injury Begin      : " + FormatDBNullDateToDisplay(dtInjuryDateFrom));
                        strHTML.Append("<br />");
                        strHTML.Append("Date of Injury End        : " + FormatDBNullDateToDisplay(dtInjuryDateEnd));
                        strHTML.Append("<br />");
                        strHTML.Append("First Report Number       : " + decFirsrRepot);
                        strHTML.Append("<br />");
                        strHTML.Append("Incident Investigation Number        : " + decIncidentNumber);
                        strHTML.Append("<br />");
                        strHTML.Append("Claim Number        : " + strClaimnumber.Replace("'", ""));
                        strHTML.Append("<br /><br />");

                        #endregion

                        #region "Grid Data"

                        strHTML.Append("<table cellspacing='0' cellpadding='0' align='Left' border='0' style='width: 2340px; border-collapse: collapse;'>");
                        //Header Row



                        strHTML.Append("<tr align='left'><td align='left'>");
                        strHTML.Append("<table width='2340px' cellpadding='0' cellspacing='0' border='0'>");
                        strHTML.Append("<tr><td align='left'>");
                        strHTML.Append("<table width='2340px' cellpadding='0' cellspacing='0' border='1' style='font-weight: bold;'>");
                        strHTML.Append("<tr style='font-weight: bold;'>");
                        strHTML.Append("<td align='left' colspan='2'>Sonic Automotive</td>");
                        strHTML.Append("<td align='center' colspan='9'>Sonic Cause Code Reclassification Report</td>");
                        strHTML.Append("<td align='right' colspan='3'>" + FormatDBNullDateToDisplay(DateTime.Now) + " </td>");
                        strHTML.Append("</tr>");

                        strHTML.Append("<tr style='font-weight: bold;'>");
                        strHTML.Append("<td align='left' style='width: 150px'>Region</td>");
                        strHTML.Append("<td align='left' style='width: 150px'>Location</td>");
                        strHTML.Append("<td align='left' style='width: 140px'>Claim Number</td>");
                        strHTML.Append("<td align='left' style='width: 150px'>First Report Number</td>");
                        strHTML.Append("<td align='left' style='width: 210px'>Incident Investigation Number</td>");
                        strHTML.Append("<td align='left' style='width: 150px'>Date of Injury</td>");
                        strHTML.Append("<td align='left' style='width: 150px'>Date Reported to Sonic</td>");
                        strHTML.Append("<td align='left' style='width: 180px'>Date Reported to SRS</td>");
                        strHTML.Append("<td align='left' style='width: 200px'>Date when SRS Closed File/Claim</td>");
                        strHTML.Append("<td align='left' style='width: 150px'>Original S0 Code</td>");
                        strHTML.Append("<td align='left' style='width: 150px'>Reclassified S-Code</td>");
                        strHTML.Append("<td align='right' style='width: 150px'>Total Incurred</td>");
                        strHTML.Append("<td align='right' style='width: 150px'>Total Paid</td>");
                        strHTML.Append("<td align='right' style='width: 150px'>Total Outstanding</td>");
                        strHTML.Append("</tr>");
                        strHTML.Append("</table>");
                        strHTML.Append("</td></tr>");
                        strHTML.Append("</table>");
                        strHTML.Append("</td></tr>");


                        DataSet dsDetails = Report.GetSonicCauseCodeReclassification_Report(strRegion, strMarket, strDBA, dtInjuryDateFrom, dtInjuryDateEnd, decFirsrRepot, decIncidentNumber, strClaimnumber);

                        if (dsDetails != null && dsDetails.Tables.Count > 0 && dsDetails.Tables[0].Rows.Count > 0)
                        {
                            DataTable dtLocation = dsDetails.Tables[0];
                            DataTable dtDetails = dsDetails.Tables[0];

                            strHTML.Append("<tr align='left'><td align='left'>");
                            strHTML.Append("<table width='2340px' cellpadding='0' cellspacing='0' border='0'>");
                            strHTML.Append("<tr><td align='left'>");
                            strHTML.Append("<table cellspacing='0' cellpadding='0' align='Left' border='1' style='width: 100%; border-collapse: collapse;'>");


                            foreach (DataRow drDetail in dsDetails.Tables[0].Rows)
                            {
                                strHTML.Append("<tr>");
                                strHTML.Append("<td align='left' style='width: 150px'>" + Convert.ToString(drDetail["Region"]) + "</td>");
                                strHTML.Append("<td align='left' style='width: 150px'>" + Convert.ToString(drDetail["DBA"]) + "</td>");
                                strHTML.Append("<td align='left' style='width: 140px'>" + Convert.ToString(drDetail["Origin_Claim_Number"]) + "</td>");
                                strHTML.Append("<td align='left' style='width: 150px'>" + Convert.ToString(drDetail["WC_FR_Number"]) + "</td>");
                                strHTML.Append("<td align='left' style='width: 210px'>" + Convert.ToString(drDetail["PK_Investigation_Id"]) + "</td>");

                                strHTML.Append("<td align='left' style='width: 150px'>" + FormatDBNullDateToDisplay(drDetail["Date_Of_Accident"]) + "</td>");
                                strHTML.Append("<td align='left' style='width: 150px'>" + FormatDBNullDateToDisplay(drDetail["Date_Reported_To_Employer"]) + "</td>");
                                strHTML.Append("<td align='left' style='width: 180px'>" + FormatDBNullDateToDisplay(drDetail["Date_Reported_To_Insurer"]) + "</td>");
                                strHTML.Append("<td align='left' style='width: 200px'>" + FormatDBNullDateToDisplay(drDetail["Date_Closed"]) + "</td>");
                                strHTML.Append("<td align='left' style='width: 150px'>" + Convert.ToString(drDetail["Original_Sonic_S0_Cause_Code"]) + "</td>");
                                strHTML.Append("<td align='left' style='width: 150px'>" + Convert.ToString(drDetail["Sonic_Cause_Code"]) + "</td>");

                                strHTML.Append("<td align='right' style='width: 150px'>" + string.Format("{0:C2}", drDetail["TotalIncurred"] != DBNull.Value ? Convert.ToDecimal(drDetail["TotalIncurred"]) : 0) + "</td>");
                                strHTML.Append("<td align='right' style='width: 150px'>" + string.Format("{0:C2}", drDetail["TotalPaid"] != DBNull.Value ? Convert.ToDecimal(drDetail["TotalPaid"]) : 0) + "</td>");
                                strHTML.Append("<td align='right' style='width: 150px'>" + string.Format("{0:C2}", drDetail["TotalOutstanding"] != DBNull.Value ? Convert.ToDecimal(drDetail["TotalOutstanding"]) : 0) + "</td>");

                                strHTML.Append(" </tr>");
                            }

                            strHTML.Append("</table>");
                            strHTML.Append("</td></tr>");
                            strHTML.Append("</table>");
                            strHTML.Append("</td></tr>");

                            //Footer Row
                            strHTML.Append("<tr align='left'><td align='left'>");
                            strHTML.Append(" <table width='2340px' cellpadding='0' cellspacing='0' border='0'>");
                            strHTML.Append("<tr><td align='left'>");
                            strHTML.Append("<table width='2340px' cellpadding='4' cellspacing='0' border='1' style='font-weight: bold;background-color: #507CD1; color: White;'>");
                            strHTML.Append("<tr style='font-weight: bold;'>");
                            strHTML.Append("<td align='left' style='width: 150px'>Report Grand Totals</td>");
                            strHTML.Append("<td align='left' style='width: 150px'>" + Convert.ToString(dtDetails.Rows.Count) + " </td>");
                            strHTML.Append("<td align='left' style='width: 140px'>&nbsp;</td>");
                            strHTML.Append("<td align='left' style='width: 150px'>&nbsp;</td>");
                            strHTML.Append("<td align='left' style='width: 210px'>&nbsp;</td>");
                            strHTML.Append("<td align='left' style='width: 150px'>&nbsp;</td>");
                            strHTML.Append("<td align='left' style='width: 150px'>&nbsp;</td>");
                            strHTML.Append("<td align='left' style='width: 180px'>&nbsp;</td>");
                            strHTML.Append("<td align='left' style='width: 200px'>&nbsp;</td>");
                            strHTML.Append("<td align='left' style='width: 150px'>&nbsp;</td>");
                            strHTML.Append("<td align='left' style='width: 150px'>&nbsp;</td>");
                            strHTML.Append("<td align='right' style='width: 150px'>" + string.Format("{0:C2}", dtDetails.Compute("sum(TotalIncurred)", "")) + "</td>");
                            strHTML.Append("<td align='right' style='width: 150px'>" + string.Format("{0:C2}", dtDetails.Compute("sum(TotalPaid)", "")) + "</td>");
                            strHTML.Append("<td align='right' style='width: 150px'>" + string.Format("{0:C2}", dtDetails.Compute("sum(TotalOutstanding)", "")) + "</td>");

                            strHTML.Append(" </tr>");
                            strHTML.Append("</table>");
                            strHTML.Append("</td></tr>");
                            strHTML.Append("</table>");
                            strHTML.Append("</td></tr>");
                        }
                        else
                        {
                            strHTML.Append("<tr> <td style='font-weight: bold;'> No Record Found.");
                            strHTML.Append("</td></tr>");
                        }

                        strHTML.Append("</table>");
                        #endregion

                        //Write HTML in to HtmlWriter
                        htmlWrite.WriteLine(strHTML.ToString());

                        //Send Mail
                        SendMail("Sonic Cause Code Reclassification Report", "SonicCauseCodeReclassificationReport.xls", strFirstName, strLastName, strMailFrom, stringWrite, dtRecipients);
                    }
                }
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("ERROR in Sonic Cause Code Reclassification Report , " + ex.Message);
            }




        }

        // Report 54
        private void BindSafetyFirstAwardReport(DataRow drReportSchedule)
        {
            decimal pK_Schedule_ID = Convert.ToDecimal(drReportSchedule["PK_Schedule"]);
            decimal Fk_RecipientList = Convert.ToDecimal(drReportSchedule["Fk_RecipientList"]);
            decimal FK_Security_Id = Convert.ToDecimal(drReportSchedule["FK_Security_Id"]);

            //Get Report criteria for the scheduled report
            DataTable dtFilter = Report.SelectFilterCriteria(54, pK_Schedule_ID).Tables[0];
            if (dtFilter.Rows.Count > 0)
            {
                //Get the recipient from the recipient list 
                DataTable dtRecipients = Report.SelectOneRecordWithRecipientList(Fk_RecipientList).Tables[0];

                //Get the user who has scheduled the report
                DataTable dtUser = Report.SelectSecurityByPK(FK_Security_Id).Tables[0];

                String strFirstName, strLastName, strMailFrom;
                strFirstName = strLastName = strMailFrom = "";
                if (dtUser.Rows.Count > 0)
                {
                    strFirstName = Convert.ToString(dtUser.Rows[0]["FIRST_NAME"]).Trim();
                    strLastName = Convert.ToString(dtUser.Rows[0]["LAST_NAME"]).Trim();
                    strMailFrom = Convert.ToString(dtUser.Rows[0]["Email"]).Trim();
                }

                string strYear = Convert.ToString(dtFilter.Rows[0]["Year"]).Trim();
                string strRegion = Convert.ToString(dtFilter.Rows[0]["Region"]);
                string strMarket = null;
                if (!string.IsNullOrEmpty(Convert.ToString(dtFilter.Rows[0]["Market"])))
                {
                    strMarket = Convert.ToString(dtFilter.Rows[0]["Market"]).Trim();
                }
                //Create HTML for the report and wirte into HTML Write object
                StringBuilder strHTML = new StringBuilder();
                System.IO.StringWriter stringWrite = new System.IO.StringWriter();
                System.Web.UI.HtmlTextWriter htmlWrite = new System.Web.UI.HtmlTextWriter(stringWrite);

                #region "Report Title"

                //Retrieve Market Values
                string strMarketString = string.Empty;
                if (string.IsNullOrEmpty(strMarket))
                {
                    strMarketString = "All Market";
                }
                else
                {
                    string[] strMar = strMarket.Split(Convert.ToChar(","));
                    for (int i = 0; i < strMar.Length; i++)
                    {
                        strMarketString += Report.SelectMarketInfoById(Convert.ToDecimal(strMar[i].ToString())).Tables[0].Rows[0]["Market"].ToString() + ",";
                    }
                    strMarketString = strMarketString.TrimEnd(',');
                }

                //Add Report Title and Schedule Date
                strHTML.Append("<br />");
                strHTML.Append("<b>Report Title : Safety First Award Report </b>");
                strHTML.Append("<br /><br />");
                strHTML.Append("Schedule Start Date : " + Convert.ToDateTime(drReportSchedule["Scheduled_Date"]).ToString(DateDisplayFormat));
                strHTML.Append("&nbsp;&nbsp;&nbsp;&nbsp;Schedule End Date : " + Convert.ToDateTime(drReportSchedule["Schedule_End_Date"]).ToString(DateDisplayFormat));
                strHTML.Append("<br />");
                strHTML.Append("Recurring Period : " + drReportSchedule["Recurring_Period"].ToString());
                strHTML.Append("<br />");
                strHTML.Append("Recurring Date : " + dtSchduleDate.ToString(DateDisplayFormat));

                //Add Report Filter Criteria    
                strHTML.Append("<br /><br /><table> <tr> <td>");
                strHTML.Append("<b>Report Filters </b>");
                strHTML.Append("<br /><table>");
                strHTML.Append("<tr> <td colspan='8'>");
                strHTML.Append("Year   : " + strYear);
                strHTML.Append("</td> </tr>");
                strHTML.Append("<tr> <td colspan='8'>");
                strHTML.Append("Region   : " + strRegion);                
                strHTML.Append("<tr> <td colspan='8'>");
                strHTML.Append("Market        : " + strMarketString);
                strHTML.Append("</td> </tr>");
                strHTML.Append("<tr> <td colspan='8'>");
                strHTML.Append("</td></tr></table> ");

                #endregion


                #region "Grid Data"

                strHTML.Append("<table cellspacing='0' cellpadding='0' align='Left' border='0' style='width: 1700px; border-collapse: collapse;'>");
                //Header Row                
                strHTML.Append("<tr align='left'><td align='left'>");
                strHTML.Append("<table width='1700px' cellpadding='0' cellspacing='0' border='0'>");
                strHTML.Append("<tr><td align='left'>");
                strHTML.Append("<table width='1700px' cellpadding='0' cellspacing='0' border='1' style='font-weight: bold;'>");
                strHTML.Append("<tr style='font-weight: bold;'>");
                strHTML.Append("<td align='left' colspan='2'>Sonic Automotive</td>");
                strHTML.Append("<td align='center' colspan='4'>Safety First Award Report </td>");
                strHTML.Append("<td align='right' colspan='3'>Valuation Date: " + DateTime.Now.ToString("MM/dd/yyy") + " </td>");
                strHTML.Append("</tr>");

                strHTML.Append("<tr style='font-weight: bold;'>");
                strHTML.Append("<td align='left' style='width: 200px'>Region</td>");
                strHTML.Append("<td align='left' style='width: 200px'>Location D/B/A</td>");
                strHTML.Append("<td align='left' style='width: 150px'>Facility Inspection Score</td>");
                strHTML.Append("<td align='left' style='width: 150px'>Sonic U Training Score</td>");
                strHTML.Append("<td align='left' style='width: 170px'>Incident Investigation Score</td>");
                strHTML.Append("<td align='left' style='width: 180px'>W.C. Claims Management Score</td>");
                strHTML.Append("<td align='left' style='width: 150px'>Incident Reduction Score</td>");
                strHTML.Append("<td align='left' style='width: 150px'>Total Aggregate Score</td>");
                strHTML.Append("<td align='left' style='width: 150px'>Resulting Score</td>");
                strHTML.Append("</tr>");
                strHTML.Append("</table>");
                strHTML.Append("</td></tr>");
                strHTML.Append("</table>");
                strHTML.Append("</td></tr>");


                DataSet dsReport = Report.GetSafertyFirstAwardReport(strRegion, strMarket, Convert.ToInt32(strYear), FK_Security_Id);

                if (dsReport != null && dsReport.Tables.Count > 0 && dsReport.Tables[0].Rows.Count > 0)
                {
                    DataTable dtLocation = dsReport.Tables[0];
                    DataTable dtDetails = dsReport.Tables[0];

                    strHTML.Append("<tr align='left'><td align='left'>");
                    strHTML.Append("<table width='1700px' cellpadding='0' cellspacing='0' border='0'>");
                    strHTML.Append("<tr><td align='left'>");
                    strHTML.Append("<table cellspacing='0' cellpadding='0' align='Left' border='1' style='width: 100%; border-collapse: collapse;'>");

                    foreach (DataRow drDetail in dsReport.Tables[0].Rows)
                    {
                        strHTML.Append("<tr>");
                        strHTML.Append("<td align='left' style='width: 200px'>" + Convert.ToString(drDetail["Region"]) + "</td>");
                        strHTML.Append("<td align='left' style='width: 200px'>" + Convert.ToString(drDetail["DBA"]) + "</td>");
                        strHTML.Append("<td align='left' style='width: 150px'>" + Convert.ToString(drDetail["FI_Score"]) + "</td>");
                        strHTML.Append("<td align='left' style='width: 150px'>" + Convert.ToString(drDetail["SUT_Score"]) + "</td>");
                        strHTML.Append("<td align='left' style='width: 170px'>" + Convert.ToString(drDetail["II_Score"]) + "</td>");

                        strHTML.Append("<td align='left' style='width: 180px'>" + Convert.ToString(drDetail["WM_Score"]) + "</td>");
                        strHTML.Append("<td align='left' style='width: 150px'>" + Convert.ToString(drDetail["IR_Score"]) + "</td>");
                        strHTML.Append("<td align='left' style='width: 150px'>" + Convert.ToString(drDetail["TotalScore"]) + "</td>");
                        strHTML.Append("<td align='left' style='width: 150px'>" + ResultingScore(Convert.ToString(drDetail["ResultingScore"])) + "</td>");
                        strHTML.Append(" </tr>");
                    }
                    strHTML.Append("</table>");
                    strHTML.Append("</td></tr>");
                    strHTML.Append("</table>");
                    strHTML.Append("</td></tr>");
                }
                else
                {
                    strHTML.Append("<tr> <td style='font-weight: bold;'> No Record Found.");
                    strHTML.Append("</td></tr>");
                }

                strHTML.Append("</table>");
                #endregion

                //Write HTML in to HtmlWriter
                htmlWrite.WriteLine(strHTML.ToString());
                //Send Mail
                SendMail("Safety First Award Report", "SafetyFirstAwardReport.xls", strFirstName, strLastName, strMailFrom, stringWrite, dtRecipients);
            }
        }

        //Report 55
        private void BindLandlordNotificationReport(DataRow drReportSchedule)
        {
            try
            {
                decimal pK_Schedule_ID = Convert.ToDecimal(drReportSchedule["PK_Schedule"]);
                decimal Fk_RecipientList = Convert.ToDecimal(drReportSchedule["Fk_RecipientList"]);
                decimal FK_Security_Id = Convert.ToDecimal(drReportSchedule["FK_Security_Id"]);

                //Get Report criteria for the scheduled report
                DataTable dtFilter = Report.SelectFilterCriteria(55, pK_Schedule_ID).Tables[0];
                if (dtFilter.Rows.Count > 0)
                {
                    //Get the recipient from the recipient list 
                    DataTable dtRecipients = Report.SelectOneRecordWithRecipientList(Fk_RecipientList).Tables[0];

                    //Get the user who has scheduled the report
                    DataTable dtUser = Report.SelectSecurityByPK(FK_Security_Id).Tables[0];

                    String strFirstName, strLastName, strMailFrom, strStatus;
                    strFirstName = strLastName = strMailFrom = "";
                    if (dtUser.Rows.Count > 0)
                    {
                        strFirstName = Convert.ToString(dtUser.Rows[0]["FIRST_NAME"]).Trim();
                        strLastName = Convert.ToString(dtUser.Rows[0]["LAST_NAME"]).Trim();
                        strMailFrom = Convert.ToString(dtUser.Rows[0]["Email"]).Trim();

                        //Set all filters to a variable as per report type
                        DateTime? dtLCDFrom = null, dtLCDTo = null, dtLEDFrom = null, dtLEDTo = null;

                        string strRegion = Convert.ToString(dtFilter.Rows[0]["Region"]).Trim();
                        string strMarket = null;
                        if (!string.IsNullOrEmpty(Convert.ToString(dtFilter.Rows[0]["Market"])))
                        {
                            strMarket = Convert.ToString(dtFilter.Rows[0]["Market"]).Trim();
                        }
                        string strLeaseType = Convert.ToString(dtFilter.Rows[0]["LeaseType"]).Trim();
                        strStatus = Convert.ToString(dtFilter.Rows[0]["Status"]).Trim();

                        if (!string.IsNullOrEmpty(Convert.ToString(dtFilter.Rows[0]["LCDFrom_Date"])))
                            dtLCDFrom = Convert.ToDateTime(dtFilter.Rows[0]["LCDFrom_Date"]);

                        if (!string.IsNullOrEmpty(Convert.ToString(dtFilter.Rows[0]["LCDTo_Date"])))
                            dtLCDTo = Convert.ToDateTime(dtFilter.Rows[0]["LCDTo_Date"]);

                        if (!string.IsNullOrEmpty(Convert.ToString(dtFilter.Rows[0]["LEDFrom_Date"])))
                            dtLEDFrom = Convert.ToDateTime(dtFilter.Rows[0]["LEDFrom_Date"]);

                        if (!string.IsNullOrEmpty(Convert.ToString(dtFilter.Rows[0]["LEDTo_Date"])))
                            dtLEDTo = Convert.ToDateTime(dtFilter.Rows[0]["LEDTo_Date"]);


                        //Create HTML for the report and wirte into HTML Write object
                        StringBuilder strHTML = new StringBuilder();
                        System.IO.StringWriter stringWrite = new System.IO.StringWriter();
                        System.Web.UI.HtmlTextWriter htmlWrite = new System.Web.UI.HtmlTextWriter(stringWrite);

                        #region "Search Criteria"

                        //Retrieve Market Values
                        string strMarketString = string.Empty;
                        if (string.IsNullOrEmpty(strMarket))
                        {
                            strMarketString = "All Market";
                        }
                        else
                        {
                            string[] strMar = strMarket.Split(Convert.ToChar(","));
                            for (int i = 0; i < strMar.Length; i++)
                            {
                                strMarketString += Report.SelectMarketInfoById(Convert.ToDecimal(strMar[i].ToString())).Tables[0].Rows[0]["Market"].ToString() + ",";
                            }
                            strMarketString = strMarketString.TrimEnd(',');
                        }

                        //Add Report Title and Schedule Date
                        strHTML.Append("<br />");
                        strHTML.Append("<b>Report Title : Landlord Notification Report</b>");
                        strHTML.Append("<br /><br />");
                        strHTML.Append("Schedule Date : " + Convert.ToDateTime(drReportSchedule["Scheduled_Date"]).ToString(DateDisplayFormat));
                        strHTML.Append("&nbsp;&nbsp;&nbsp;&nbsp;Schedule End Date : " + Convert.ToDateTime(drReportSchedule["Schedule_End_Date"]).ToString(DateDisplayFormat));
                        strHTML.Append("<br />");
                        strHTML.Append("Recurring Period : " + drReportSchedule["Recurring_Period"].ToString());
                        strHTML.Append("<br />");
                        strHTML.Append("Recurring Date : " + dtSchduleDate.ToString(DateDisplayFormat));

                        //Add Report Filter Criteria 
                        strHTML.Append("<br /><br />");
                        strHTML.Append("<b>Report Filters </b>");
                        strHTML.Append("<br /><br />");
                        strHTML.Append("Region        : " + strRegion.Replace("'", ""));
                        strHTML.Append("Market        : " + strMarketString);
                        strHTML.Append("<br /><br />");
                        strHTML.Append("<br />");
                        strHTML.Append("LCD From      : " + FormatDBNullDateToDisplay(dtLCDFrom));
                        strHTML.Append("<br />");
                        strHTML.Append("LCD To        : " + FormatDBNullDateToDisplay(dtLCDTo));
                        strHTML.Append("<br />");
                        strHTML.Append("LED From      : " + FormatDBNullDateToDisplay(dtLEDFrom));
                        strHTML.Append("<br />");
                        strHTML.Append("LED To        : " + FormatDBNullDateToDisplay(dtLEDTo));
                        strHTML.Append("<br />");
                        strHTML.Append("Building Status        : " + strStatus.Replace("'", ""));
                        strHTML.Append("<br /><br />");

                        #endregion

                        #region "Grid Data"

                        strHTML.Append("<table cellspacing='0' cellpadding='0' align='Left' border='0' style='width: 1340px; border-collapse: collapse;'>");
                        //Header Row
                        strHTML.Append("<tr align='left'><td align='left'>");
                        strHTML.Append("<table width='1625px' cellpadding='0' cellspacing='0' border='0'>");
                        strHTML.Append("<tr><td align='left'>");
                        strHTML.Append("<table width='1625px' cellpadding='0' cellspacing='0' border='1' style='font-weight: bold;'>");
                        strHTML.Append("<tr style='font-weight: bold;'>");
                        strHTML.Append("<td align='left' colspan='2'>Sonic Automotive</td>");
                        strHTML.Append("<td align='center' colspan='3'>Landlord Notification Report</td>");
                        strHTML.Append("<td align='right' colspan='4'>" + FormatDBNullDateToDisplay(DateTime.Now) + " </td>");
                        strHTML.Append("</tr>");

                        strHTML.Append("<tr style='font-weight: bold;'>");
                        strHTML.Append("<td align='left' style='width: 100px'>LL Notify Date</td>");
                        strHTML.Append("<td align='left' style='width: 180px'>Location</td>");
                        strHTML.Append("<td align='left' style='width: 560px'>");
                        strHTML.Append("<table width='100%' cellpadding='0' cellspacing='0' border='1' style='font-weight: bold;'>");
                        strHTML.Append("<tr>");
                        strHTML.Append("<td align='left' style='width: 40%'>Building Address</td>");
                        strHTML.Append("<td align='left' style='width: 30%'>Building Number</td>");
                        strHTML.Append("<td align='left' style='width: 30%'>Building Landlord Name</td>");
                        strHTML.Append("</tr>");
                        strHTML.Append("</table>");
                        strHTML.Append("</td>");
                        strHTML.Append("<td align='left' style='width: 100px'>LCD</td>");
                        strHTML.Append("<td align='left' style='width: 100px'>LED</td>");
                        strHTML.Append("<td align='left' style='width: 100px'>Reminder Date</td>");
                        strHTML.Append("<td align='left' style='width: 100px'>Review Date</td>");
                        strHTML.Append("<td align='right' style='width: 100px'>Monthly Rent</td>");
                        strHTML.Append("<td align='left' style='width: 180px'>Renewals</td>");

                        strHTML.Append("</tr>");
                        strHTML.Append("</table>");
                        strHTML.Append("</td></tr>");
                        strHTML.Append("</table>");
                        strHTML.Append("</td></tr>");


                        //get the all Employee records by search criteria by group
                        DataSet dsDetails = Report.GetLandlordNotificationReport(strRegion, strMarket, dtLCDFrom, dtLCDTo, dtLEDFrom, dtLEDTo, strStatus);

                        if (dsDetails != null && dsDetails.Tables.Count > 0 && dsDetails.Tables[0].Rows.Count > 0)
                        {
                            DataTable dtLocation = dsDetails.Tables[0];
                            DataTable dtDetails = dsDetails.Tables[0];

                            strHTML.Append("<tr align='left'><td align='left'>");
                            strHTML.Append("<table width='1625px' cellpadding='0' cellspacing='0' border='0'>");
                            strHTML.Append("<tr><td align='left'>");
                            strHTML.Append("<table cellspacing='0' cellpadding='0' align='Left' border='1' style='width: 100%; border-collapse: collapse;'>");

                            //foreach (DataRow dr in dtLocation.Rows)
                            //{
                            // DataRow[] drDetails = dtDetails.Select("DBA='" + dr["DBA"] + "'");
                            foreach (DataRow drDetail in dtLocation.Rows)
                            {
                                strHTML.Append("<tr>");
                                strHTML.Append("<td valign='top' align='left' style='width: 100px'>" + FormatDBNullDateToDisplay(drDetail["LLNotifyDate"]) + "</td>");
                                strHTML.Append("<td valign='top' align='left' style='width: 180px'>" + Convert.ToString(drDetail["DBA"]) + "</td>");
                                strHTML.Append("<td valign='top' align='left' valign='top' style='width: 560px'>");
                                decimal _PK_RE_Information = Convert.ToDecimal(drDetail["PK_RE_Information"]);
                                DataTable dtBuilding = Report.SelectByFK_RE_Information(_PK_RE_Information).Tables[0];
                                if (dtBuilding.Rows.Count > 0)
                                {
                                    foreach (DataRow drBuilding in dtBuilding.Rows)
                                    {

                                        strHTML.Append("<table cellspacing='0' cellpadding='0' align='Left' border='1' style='width: 100%; border-collapse: collapse;'>");
                                        strHTML.Append("<tr>");
                                        strHTML.Append("<td align='left' valign='top' style='width:40%'>" + (drBuilding["Address"]) + "</td>");
                                        strHTML.Append("<td align='left' valign='top' style='width:30%'>" + Convert.ToString(drBuilding["Building_Number"]) + "</td>");
                                        strHTML.Append("<td align='left' valign='top' style='width:30%'>" + Convert.ToString(drBuilding["Landlord_Name"]) + "</td>");
                                        strHTML.Append("</tr>");
                                        strHTML.Append("</table>");
                                    }
                                }
                                else
                                {
                                    strHTML.Append("<table cellspacing='0' cellpadding='0' align='Left' border='1' style='width: 100%; border-collapse: collapse;'>");
                                    strHTML.Append("<tr>");
                                    strHTML.Append("<td align='left' valign='top' style='width:40%'>" + "" + "</td>");
                                    strHTML.Append("<td align='left' valign='top' style='width:30%'>" + "" + "</td>");
                                    strHTML.Append("<td align='left' valign='top' style='width:30%'>" + "" + "</td>");
                                    strHTML.Append("</tr>");
                                    strHTML.Append("</table>");
                                }

                                strHTML.Append("</td>");
                                strHTML.Append("<td valign='top' align='left' style='width: 100px'>" + FormatDBNullDateToDisplay(drDetail["LCD"]) + "</td>");
                                strHTML.Append("<td valign='top' align='left' style='width: 100px'>" + FormatDBNullDateToDisplay(drDetail["LED"]) + "</td>");
                                strHTML.Append("<td valign='top' align='left' style='width: 100px'>" + FormatDBNullDateToDisplay(drDetail["ReminderDate"]) + "</td>");
                                strHTML.Append("<td valign='top' align='left' style='width: 100px'>" + FormatDBNullDateToDisplay(drDetail["ReviewDate"]) + "</td>");
                                strHTML.Append("<td valign='top' align='right' style='width: 100px'>" + string.Format("{0:N2}", drDetail["MonthlyRent"] != DBNull.Value ? Convert.ToDecimal(drDetail["MonthlyRent"]) : 0) + "</td>");
                                strHTML.Append("<td valign='top' align='left' style='width: 180px'>" + Convert.ToString(drDetail["Renewals"]) + "</td>");


                                strHTML.Append(" </tr>");
                            }
                            //}
                            strHTML.Append("</table>");
                            strHTML.Append("</td></tr>");
                            strHTML.Append("</table>");
                            strHTML.Append("</td></tr>");

                            //Footer Row
                            strHTML.Append("<tr align='left'><td align='left'>");
                            strHTML.Append(" <table width='1625px' cellpadding='0' cellspacing='0' border='0'>");
                            strHTML.Append("<tr><td align='left'>");
                            strHTML.Append("<table width='1625px' cellpadding='4' cellspacing='0' border='1' style='font-weight: bold;background-color: #507CD1; color: White;'>");
                            strHTML.Append("<tr style='font-weight: bold;'>");
                            strHTML.Append("<td align='left' style='width: 100px'>Report Grand Totals</td>");
                            strHTML.Append("<td align='left' style='width: 180px'>" + Convert.ToString(dtDetails.Rows.Count) + " </td>");
                            strHTML.Append("<td align='left' style='width: 560px'>&nbsp;</td>");
                            strHTML.Append("<td align='left' style='width: 100px'>&nbsp;</td>");
                            strHTML.Append("<td align='left' style='width: 100px'>&nbsp;</td>");
                            strHTML.Append("<td align='left' style='width: 100px'>&nbsp;</td>");
                            strHTML.Append("<td align='left' style='width: 100px'>&nbsp;</td>");
                            strHTML.Append("<td align='right' style='width: 100px'>" + string.Format("{0:N2}", dtDetails.Compute("sum(MonthlyRent)", "")) + "</td>");
                            strHTML.Append("<td align='left' style='width: 180px'>&nbsp;</td>");

                            strHTML.Append(" </tr>");
                            strHTML.Append("</table>");
                            strHTML.Append("</td></tr>");
                            strHTML.Append("</table>");
                            strHTML.Append("</td></tr>");
                        }
                        else
                        {
                            strHTML.Append("<tr> <td style='font-weight: bold;'> No Record Found.");
                            strHTML.Append("</td></tr>");
                        }

                        strHTML.Append("</table>");
                        #endregion

                        //Write HTML in to HtmlWriter
                        htmlWrite.WriteLine(strHTML.ToString());

                        //Send Mail
                        SendMail("Landlord Notification Report", "LandlordNotificationReport.xls", strFirstName, strLastName, strMailFrom, stringWrite, dtRecipients);
                    }
                }
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("ERROR in Landlord Notification Report, " + ex.Message);
            }
        }

        //Report 56
        private void BindInpectionsByInspector(DataRow drReportSchedule)
        {
            decimal pK_Schedule_ID = Convert.ToDecimal(drReportSchedule["PK_Schedule"]);
            decimal Fk_RecipientList = Convert.ToDecimal(drReportSchedule["Fk_RecipientList"]);
            decimal FK_Security_Id = Convert.ToDecimal(drReportSchedule["FK_Security_Id"]);

            //Get Report criteria for the scheduled report
            DataTable dtFilter = Report.SelectFilterCriteria(56, pK_Schedule_ID).Tables[0];
            if (dtFilter.Rows.Count > 0)
            {
                //Get the recipient from the recipient list 
                DataTable dtRecipients = Report.SelectOneRecordWithRecipientList(Fk_RecipientList).Tables[0];

                //Get the user who has scheduled the report
                DataTable dtUser = Report.SelectSecurityByPK(FK_Security_Id).Tables[0];

                String strFirstName, strLastName, strMailFrom;
                strFirstName = strLastName = strMailFrom = "";
                if (dtUser.Rows.Count > 0)
                {
                    strFirstName = Convert.ToString(dtUser.Rows[0]["FIRST_NAME"]).Trim();
                    strLastName = Convert.ToString(dtUser.Rows[0]["LAST_NAME"]).Trim();
                    strMailFrom = Convert.ToString(dtUser.Rows[0]["Email"]).Trim();
                }
                string strRegion = Convert.ToString(dtFilter.Rows[0]["Region"]).Trim();
                string strMarket = null;
                if (!string.IsNullOrEmpty(Convert.ToString(dtFilter.Rows[0]["Market"])))
                {
                    strMarket = Convert.ToString(dtFilter.Rows[0]["Market"]).Trim();
                }
                string strDBA = Convert.ToString(dtFilter.Rows[0]["DBA"]).Trim();
                string strInspector = Convert.ToString(dtFilter.Rows[0]["Inspector_Name"]).Trim();
                DateTime? dtInspection_Date_From;
                DateTime? dtInspection_Date_To;
                if (dtFilter.Rows[0]["Inspection_Date_From"] != DBNull.Value)
                    dtInspection_Date_From = Convert.ToDateTime(dtFilter.Rows[0]["Inspection_Date_From"]);
                else
                    dtInspection_Date_From = null;
                if (dtFilter.Rows[0]["Inspection_Date_To"] != DBNull.Value)
                    dtInspection_Date_To = Convert.ToDateTime(dtFilter.Rows[0]["Inspection_Date_To"]);
                else
                    dtInspection_Date_To = null;

                //Get the all Unique records for Selected group (default - last name -sort) by search criteria
                DataSet dsResult = Report.GetInspectionsByInspector(strRegion, strMarket, strDBA, strInspector, dtInspection_Date_From, dtInspection_Date_To);

                //Create HTML for the report and wirte into HTML Write object
                StringBuilder strHTML = new StringBuilder();
                System.IO.StringWriter stringWrite = new System.IO.StringWriter();
                System.Web.UI.HtmlTextWriter htmlWrite = new System.Web.UI.HtmlTextWriter(stringWrite);

                #region "Report Title"

                //Retrieve Market Values
                string strMarketString = string.Empty;
                if (string.IsNullOrEmpty(strMarket))
                {
                    strMarketString = "All Market";
                }
                else
                {
                    string[] strMar = strMarket.Split(Convert.ToChar(","));
                    for (int i = 0; i < strMar.Length; i++)
                    {
                        strMarketString += Report.SelectMarketInfoById(Convert.ToDecimal(strMar[i].ToString())).Tables[0].Rows[0]["Market"].ToString() + ",";
                    }
                    strMarketString = strMarketString.TrimEnd(',');
                }

                //Add Report Title and Schedule Date
                strHTML.Append("<br />");
                strHTML.Append("<b>Report Title : Inspections By Inspector</b>");
                strHTML.Append("<br /><br />");
                strHTML.Append("Schedule Date : " + Convert.ToDateTime(drReportSchedule["Scheduled_Date"]).ToString(DateDisplayFormat));
                strHTML.Append("&nbsp;&nbsp;&nbsp;&nbsp;Schedule End Date : " + Convert.ToDateTime(drReportSchedule["Schedule_End_Date"]).ToString(DateDisplayFormat));
                strHTML.Append("<br />");
                strHTML.Append("Recurring Period : " + drReportSchedule["Recurring_Period"].ToString());
                strHTML.Append("<br />");
                strHTML.Append("Recurring Date : " + dtSchduleDate.ToString(DateDisplayFormat));

                //Add Report Filter Criteria 
                strHTML.Append("<br /><br /><table> <tr> <td>");
                strHTML.Append("<b>Report Filters </b>");
                strHTML.Append("<br /><table> <tr> <td colspan='8'>");
                strHTML.Append("Region   : " + strRegion);
                strHTML.Append("</td> </tr>");
                strHTML.Append("<br /><table> <tr> <td colspan='8'>");
                strHTML.Append("Market        : " + strMarketString);
                strHTML.Append("</td> </tr>");
                strHTML.Append("<tr> <td colspan='8'>");
                strHTML.Append("Location D/B/A   : " + strDBA);
                strHTML.Append("</td> </tr>");
                strHTML.Append("<tr> <td colspan='8'>");
                strHTML.Append("Inspector Name   : " + strInspector);
                strHTML.Append("</td> </tr>");
                strHTML.Append("<tr> <td colspan='8'>");
                strHTML.Append("Inspection Date From   : " + Convert.ToString(dtInspection_Date_From));
                strHTML.Append("</td> </tr>");
                strHTML.Append("<tr> <td colspan='8'>");
                strHTML.Append("Inspection Date To   : " + Convert.ToString(dtInspection_Date_To));
                strHTML.Append("</td> </tr>");
                strHTML.Append("<tr> <td colspan='8'>");
                strHTML.Append("</td></tr></table> ");

                #endregion

                #region "Report Grid header"
                //Top Header
                strHTML.Append("<table border='1'>");
                strHTML.Append("<tr style='font-weight: bold;' valign='bottom' align='left'>");
                strHTML.Append("<td align='left' >Sonic Automotive</td>");
                strHTML.Append("<td align='center' colspan='3'>Inspections By Inspector</td>");
                strHTML.Append("<td align='right' > " + DateTime.Now.ToString() + " </td>");
                strHTML.Append("</tr>");

                //Sub Header
                strHTML.Append("<tr valign='bottom' align='left' style='font-weight: bold'>");
                strHTML.Append("<td width='150'>Region</td>");
                strHTML.Append("<td width='150'>Inspector</td>");
                strHTML.Append("<td width='150'>Location D/B/A</td>");
                strHTML.Append("<td width='160'>Inspection Date</td>");
                strHTML.Append("<td width='160'>Number of Deficiencies</td>");

                strHTML.Append("</tr>");

                //Check Whether Record Exists or Not
                if (dsResult != null && dsResult.Tables.Count > 0 && dsResult.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in dsResult.Tables[0].Rows)
                    {
                        strHTML.Append("<tr valign='top' align='left'>");

                        strHTML.Append("<td width='150'>" + Convert.ToString(dr["Region"]) + "</td>");
                        strHTML.Append("<td width='150'>" + Convert.ToString(dr["Inspector_Name"]) + "</td>");
                        strHTML.Append("<td width='150'>" + Convert.ToString(dr["dba"]) + "</td>");
                        strHTML.Append("<td width='150'>" + FormatDBNullDateToDisplay(dr["Date"]) + "</td>");
                        strHTML.Append("<td width='150'>" + Convert.ToString(dr["No_Deficiencies"]) + "</td>");

                        strHTML.Append("</tr>");
                    }
                }
                else
                {
                    //Add No record found line for year
                    strHTML.Append("<tr><td align='left' colspan='5'>No Record Found!</td></tr>");
                }
                strHTML.Append("</table>");

                #endregion

                //Write HTML in to HtmlWriter
                htmlWrite.WriteLine(strHTML.ToString());
                //Send Mail
                SendMail("Inspections By Inspector", "Inspections_By_Inspector_Report.xls", strFirstName, strLastName, strMailFrom, stringWrite, dtRecipients);
            }
        }

        //Report 57
        private void BindRiskManagementWorkSheet(DataRow drReportSchedule)
        {
            decimal pK_Schedule_ID = Convert.ToDecimal(drReportSchedule["PK_Schedule"]);
            decimal Fk_RecipientList = Convert.ToDecimal(drReportSchedule["Fk_RecipientList"]);
            decimal FK_Security_Id = Convert.ToDecimal(drReportSchedule["FK_Security_Id"]);

            //Get Report criteria for the scheduled report
            DataTable dtFilter = Report.SelectFilterCriteria(57, pK_Schedule_ID).Tables[0];
            if (dtFilter.Rows.Count > 0)
            {
                //Get the recipient from the recipient list 
                DataTable dtRecipients = Report.SelectOneRecordWithRecipientList(Fk_RecipientList).Tables[0];

                //Get the user who has scheduled the report
                DataTable dtUser = Report.SelectSecurityByPK(FK_Security_Id).Tables[0];
                String strFirstName, strLastName, strMailFrom;
                strFirstName = strLastName = strMailFrom = "";
                if (dtUser.Rows.Count > 0)
                {
                    strFirstName = Convert.ToString(dtUser.Rows[0]["FIRST_NAME"]).Trim();
                    strLastName = Convert.ToString(dtUser.Rows[0]["LAST_NAME"]).Trim();
                    strMailFrom = Convert.ToString(dtUser.Rows[0]["Email"]).Trim();
                }

                string strRegion = Convert.ToString(dtFilter.Rows[0]["Region"]).Trim();
                string strMarket = null;
                if (!string.IsNullOrEmpty(Convert.ToString(dtFilter.Rows[0]["Market"])))
                {
                    strMarket = Convert.ToString(dtFilter.Rows[0]["Market"]).Trim();
                }
                string strDBA = Convert.ToString(dtFilter.Rows[0]["DBA"]).Trim();
                string strBodyPart = Convert.ToString(dtFilter.Rows[0]["FK_Part_of_Body"]).Trim();
                string strClaimStatus = Convert.ToString(dtFilter.Rows[0]["Claim_Status"]).Trim();
                string strClaim_StatusSelected = Convert.ToString(dtFilter.Rows[0]["Claim_StatusSelected"]).Trim();
                string strDBAList = Convert.ToString(dtFilter.Rows[0]["DBAList"]).Trim();
                string strPartofBodyist = Convert.ToString(dtFilter.Rows[0]["Part_of_Body"]).Trim();
                DateTime? dtIncident_Date_From;
                DateTime? dtIncident_Date_To;
                if (dtFilter.Rows[0]["Date_of_Incident_From"] != DBNull.Value)
                    dtIncident_Date_From = Convert.ToDateTime(dtFilter.Rows[0]["Date_of_Incident_From"]);
                else
                    dtIncident_Date_From = null;
                if (dtFilter.Rows[0]["Date_of_Incident_To"] != DBNull.Value)
                    dtIncident_Date_To = Convert.ToDateTime(dtFilter.Rows[0]["Date_of_Incident_To"]);
                else
                    dtIncident_Date_To = null;

                DataSet dsResult = Report.GetRiskManagementWorksheet(strRegion, strMarket, strDBA, dtIncident_Date_From, dtIncident_Date_To, strBodyPart, strClaimStatus);

                //Create HTML for the report and wirte into HTML Write object
                StringBuilder strHTML = new StringBuilder();
                System.IO.StringWriter stringWrite = new System.IO.StringWriter();
                System.Web.UI.HtmlTextWriter htmlWrite = new System.Web.UI.HtmlTextWriter(stringWrite);

                 #region "Report Title"

                //Retrieve Market Values
                string strMarketString = string.Empty;
                if (string.IsNullOrEmpty(strMarket))
                {
                    strMarketString = "All Market";
                }
                else
                {
                    string[] strMar = strMarket.Split(Convert.ToChar(","));
                    for (int i = 0; i < strMar.Length; i++)
                    {
                        strMarketString += Report.SelectMarketInfoById(Convert.ToDecimal(strMar[i].ToString())).Tables[0].Rows[0]["Market"].ToString() + ",";
                    }
                    strMarketString = strMarketString.TrimEnd(',');
                }

                //Add Report Title and Schedule Date
                strHTML.Append("<br />");
                strHTML.Append("<b>Report Title : Risk Management Worksheet</b>");
                strHTML.Append("<br /><br />");
                strHTML.Append("Schedule Date : " + Convert.ToDateTime(drReportSchedule["Scheduled_Date"]).ToString(DateDisplayFormat));
                strHTML.Append("&nbsp;&nbsp;&nbsp;&nbsp;Schedule End Date : " + Convert.ToDateTime(drReportSchedule["Schedule_End_Date"]).ToString(DateDisplayFormat));
                strHTML.Append("<br />");
                strHTML.Append("Recurring Period : " + drReportSchedule["Recurring_Period"].ToString());
                strHTML.Append("<br />");
                strHTML.Append("Recurring Date : " + dtSchduleDate.ToString(DateDisplayFormat));

                //Add Report Filter Criteria 
                strHTML.Append("<br /><br /><table> <tr> <td>");
                strHTML.Append("<b>Report Filters </b>");
                strHTML.Append("<br /><table> <tr> <td colspan='11'>");
                strHTML.Append("Region   : " + strRegion.Replace("'",""));
                strHTML.Append("</td> </tr>");
                strHTML.Append("<br /><table> <tr> <td colspan='11'>");
                strHTML.Append("Market        : " + strMarketString);
                strHTML.Append("</td> </tr>");
                strHTML.Append("<tr> <td colspan='11'>");
                strHTML.Append("Location D/B/A   : " + strDBAList);
                strHTML.Append("</td> </tr>");
                strHTML.Append("<tr> <td colspan='11'>");
                strHTML.Append("Parts of Body   : " + strPartofBodyist);
                strHTML.Append("</td> </tr>");
                strHTML.Append("<tr> <td colspan='11'>");
                strHTML.Append("Date of Incident From   : " + Convert.ToString(dtIncident_Date_From));
                strHTML.Append("</td> </tr>");
                strHTML.Append("<tr> <td colspan='11'>");
                strHTML.Append("Date of Incident To   : " + Convert.ToString(dtIncident_Date_To));
                strHTML.Append("</td> </tr>");
                strHTML.Append("<tr> <td colspan='11'>");
                strHTML.Append("Claim Status   : " + strClaim_StatusSelected);
                strHTML.Append("</td> </tr>");
                strHTML.Append("<tr> <td colspan='11'>");
                strHTML.Append("</td></tr></table> ");

                #endregion


                #region "Report Grid header"
                //Top Header
                strHTML.Append("<table border='1'>");
                strHTML.Append("<tr style='font-weight: bold;' valign='bottom' align='left'>");
                strHTML.Append("<td align='left' >Sonic Automotive</td>");
                strHTML.Append("<td align='center' colspan='9'>Risk Management Worksheet</td>");
                strHTML.Append("<td align='right' > " + DateTime.Now.ToString() + " </td>");
                strHTML.Append("</tr>");

                //Sub Header
                strHTML.Append("<tr valign='bottom' align='left' style='font-weight: bold'>");
                strHTML.Append("<td width='120'>Region</td>");
                strHTML.Append("<td width='150'>Location D/B/A</td>");
                strHTML.Append("<td width='130'>Associate Name</td>");
                strHTML.Append("<td width='100'>Claim Number</td>");
                strHTML.Append("<td width='100'>Date of Incident</td>");
                strHTML.Append("<td width='180'>Part of Body</td>");
                strHTML.Append("<td width='100'>Claim Status</td>");
                strHTML.Append("<td width='500' align='center'>Reserves and Payments</td>");
                strHTML.Append("<td width='100'>Resignation</td>");
                strHTML.Append("<td width='120' align='right'>Settlement Amount</td>");
                strHTML.Append("<td width='100'>Who Approved</td>");
                strHTML.Append("</tr>");

                //Check Whether Record Exists or Not
                if (dsResult != null && dsResult.Tables.Count > 0 && dsResult.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in dsResult.Tables[0].Rows)
                    {
                        strHTML.Append("<tr valign='top' align='left'>");

                        strHTML.Append("<td >" + Convert.ToString(dr["Region"]) + "</td>");
                        strHTML.Append("<td >" + Convert.ToString(dr["DBA"]) + "</td>");
                        strHTML.Append("<td >" + Convert.ToString(dr["Employee_Name"]) + "</td>");
                        strHTML.Append("<td >" + Convert.ToString(dr["Origin_Claim_Number"]) + "</td>");
                        strHTML.Append("<td >" + FormatDBNullDateToDisplay( dr["Date_Of_Accident"]) + "</td>");
                        strHTML.Append("<td >" + Convert.ToString(dr["Part_of_Body"]) + "</td>");
                        strHTML.Append("<td >" + Convert.ToString(dr["Claim_Status"]) + "</td>");

                        strHTML.Append("<td > <table width='100%' cellpadding='3' cellspacing='2' border='0'>");
                        strHTML.Append("<tr><td width='16%' align='left'>&nbsp;</td>");
                        strHTML.Append("<td width='21%' align='right'><b>Indemnity $</b></td>");
                        strHTML.Append("<td width='21%' align='right'><b>Medical $</b></td>");
                        strHTML.Append("<td width='21%' align='right'><b>Expenses $</b></td>");
                        strHTML.Append("<td width='21%' align='right'><b>Total $</b></td></tr>");
                        strHTML.Append("<tr><td  align='left'><b>Reserve</b></td>");
                        strHTML.Append("<td  align='right'>" + string.Format("{0:C2}", dr["Reserve_Indemnity"]) + "</td>");
                        strHTML.Append("<td  align='right'>" + string.Format("{0:C2}", dr["Resrve_Medical"]) + "</td>");
                        strHTML.Append("<td  align='right'>" + string.Format("{0:C2}", dr["Reserve_Expense"]) + "</td>");
                        strHTML.Append("<td  align='right'>" + string.Format("{0:C2}", dr["Reserve_Total"]) + "</td> </tr>");
                        strHTML.Append("<tr><td  align='left'><b>Paid</b></td>");
                        strHTML.Append("<td  align='right'>" + string.Format("{0:C2}", dr["Paid_Indemnity"]) + "</td>");
                        strHTML.Append("<td  align='right'>" + string.Format("{0:C2}", dr["Paid_Medical"]) + "</td>");
                        strHTML.Append("<td  align='right'>" + string.Format("{0:C2}", dr["Paid_Expense"]) + "</td>");
                        strHTML.Append("<td  align='right'>" + string.Format("{0:C2}", dr["Paid_Total"]) + "</td></tr>");
                        strHTML.Append(" <tr><td  align='left'><b>Outstanding</b></td>");
                        strHTML.Append("<td  align='right'>" + string.Format("{0:C2}", dr["Out_Indemnity"]) + "</td>");
                        strHTML.Append("<td  align='right'>" + string.Format("{0:C2}", dr["Out_Medical"]) + "</td>");
                        strHTML.Append("<td  align='right'>" + string.Format("{0:C2}", dr["Out_Expense"]) + "</td>");
                        strHTML.Append("<td  align='right'>" + string.Format("{0:C2}", dr["Out_Total"]) + "</td>");
                        strHTML.Append(" </tr></table></td>");                       
                        strHTML.Append("<td >" + Convert.ToString(dr["Resignation"]) + "</td>");
                        strHTML.Append("<td align='right'>" + string.Format("{0:C2}", dr["Settled_Amount"]) + "</td>");
                        strHTML.Append("<td >" + Convert.ToString(dr["Who_Approved"]).Replace("<br/>"," , ") + "</td>");
                        strHTML.Append("</tr>");
                    }
                }
                else
                {
                    //Add No record found line for year
                    strHTML.Append("<tr><td align='left' colspan='5'>No Record Found!</td></tr>");
                }
                strHTML.Append("</table>");

                #endregion

                //Write HTML in to HtmlWriter
                htmlWrite.WriteLine(strHTML.ToString());
                //Send Mail
                SendMail("Risk Management Worksheet", "Risk_Management_Worksheet_Report.xls", strFirstName, strLastName, strMailFrom, stringWrite, dtRecipients);

            }
        }

        //Report 59
        private void BindInspectionLagTime(DataRow drReportSchedule)
        {
            decimal pK_Schedule_ID = Convert.ToDecimal(drReportSchedule["PK_Schedule"]);
            decimal Fk_RecipientList = Convert.ToDecimal(drReportSchedule["Fk_RecipientList"]);
            decimal FK_Security_Id = Convert.ToDecimal(drReportSchedule["FK_Security_Id"]);

            //Get Report criteria for the scheduled report
            DataTable dtFilter = Report.SelectFilterCriteria(59, pK_Schedule_ID).Tables[0];
            if (dtFilter.Rows.Count > 0)
            {
                //Get the recipient from the recipient list 
                DataTable dtRecipients = Report.SelectOneRecordWithRecipientList(Fk_RecipientList).Tables[0];

                //Get the user who has scheduled the report
                DataTable dtUser = Report.SelectSecurityByPK(FK_Security_Id).Tables[0];

                String strFirstName, strLastName, strMailFrom;
                strFirstName = strLastName = strMailFrom = "";
                if (dtUser.Rows.Count > 0)
                {
                    strFirstName = Convert.ToString(dtUser.Rows[0]["FIRST_NAME"]).Trim();
                    strLastName = Convert.ToString(dtUser.Rows[0]["LAST_NAME"]).Trim();
                    strMailFrom = Convert.ToString(dtUser.Rows[0]["Email"]).Trim();
                }
                string strRegion = Convert.ToString(dtFilter.Rows[0]["Region"]).Trim();
                string strMarket = null;
                if (!string.IsNullOrEmpty(Convert.ToString(dtFilter.Rows[0]["Market"])))
                {
                    strMarket = Convert.ToString(dtFilter.Rows[0]["Market"]).Trim();
                }
                string strDBA = Convert.ToString(dtFilter.Rows[0]["DBA"]).Trim();
                string strInspector = Convert.ToString(dtFilter.Rows[0]["Inspector_Name"]).Trim();
                string strInspectionArea = Convert.ToString(dtFilter.Rows[0]["InspectionArea"]).Trim();
                string strLagDayOption = Convert.ToString(dtFilter.Rows[0]["LagDayOption"]).Trim();

                DateTime? dtInspection_Date_From;
                DateTime? dtInspection_Date_To;
                if (dtFilter.Rows[0]["Inspection_Date_From"] != DBNull.Value)
                    dtInspection_Date_From = Convert.ToDateTime(dtFilter.Rows[0]["Inspection_Date_From"]);
                else
                    dtInspection_Date_From = null;
                if (dtFilter.Rows[0]["Inspection_Date_To"] != DBNull.Value)
                    dtInspection_Date_To = Convert.ToDateTime(dtFilter.Rows[0]["Inspection_Date_To"]);
                else
                    dtInspection_Date_To = null;

                //Get the all Unique records for Selected group (default - last name -sort) by search criteria
                DataSet dsResult = Report.GetInspectionLagTime(strRegion, strMarket, strDBA, strInspectionArea, strInspector, dtInspection_Date_From, dtInspection_Date_To, strLagDayOption);

                //Create HTML for the report and wirte into HTML Write object
                StringBuilder strHTML = new StringBuilder();
                System.IO.StringWriter stringWrite = new System.IO.StringWriter();
                System.Web.UI.HtmlTextWriter htmlWrite = new System.Web.UI.HtmlTextWriter(stringWrite);

                #region "Report Title"

                //Retrieve Market Values
                string strMarketString = string.Empty;
                if (string.IsNullOrEmpty(strMarket))
                {
                    strMarketString = "All Market";
                }
                else
                {
                    string[] strMar = strMarket.Split(Convert.ToChar(","));
                    for (int i = 0; i < strMar.Length; i++)
                    {
                        strMarketString += Report.SelectMarketInfoById(Convert.ToDecimal(strMar[i].ToString())).Tables[0].Rows[0]["Market"].ToString() + ",";
                    }
                    strMarketString = strMarketString.TrimEnd(',');
                }

                //Add Report Title and Schedule Date
                strHTML.Append("<br />");
                strHTML.Append("<b>Report Title : Inspection Distribution Lag Time</b>");
                strHTML.Append("<br /><br />");
                strHTML.Append("Schedule Date : " + Convert.ToDateTime(drReportSchedule["Scheduled_Date"]).ToString(DateDisplayFormat));
                strHTML.Append("&nbsp;&nbsp;&nbsp;&nbsp;Schedule End Date : " + Convert.ToDateTime(drReportSchedule["Schedule_End_Date"]).ToString(DateDisplayFormat));
                strHTML.Append("<br />");
                strHTML.Append("Recurring Period : " + drReportSchedule["Recurring_Period"].ToString());
                strHTML.Append("<br />");
                strHTML.Append("Recurring Date : " + dtSchduleDate.ToString(DateDisplayFormat));

                //Add Report Filter Criteria 
                strHTML.Append("<br /><br /><table> <tr> <td>");
                strHTML.Append("<b>Report Filters </b>");
                strHTML.Append("<br /><table> <tr> <td colspan='8'>");
                strHTML.Append("Region   : " + strRegion);
                strHTML.Append("</td> </tr>");
                strHTML.Append("<br /><table> <tr> <td colspan='8'>");
                strHTML.Append("Market        : " + strMarketString);
                strHTML.Append("</td> </tr>");
                strHTML.Append("<tr> <td colspan='8'>");
                strHTML.Append("Location D/B/A   : " + ((!string.IsNullOrEmpty(strDBA)) ? Report.GetCommaSeperatedDescFromVal("LU_Location", "dba", "PK_LU_Location_ID", strDBA) : ""));
                strHTML.Append("</td> </tr>");
                strHTML.Append("<tr> <td colspan='8'>");
                strHTML.Append("Inspector Name   : " + strInspector);
                strHTML.Append("</td> </tr>");
                strHTML.Append("<tr> <td colspan='8'>");
                strHTML.Append("Inspection Date From   : " + Convert.ToString(dtInspection_Date_From));
                strHTML.Append("</td> </tr>");
                strHTML.Append("<tr> <td colspan='8'>");
                strHTML.Append("Inspection Date To   : " + Convert.ToString(dtInspection_Date_To));
                strHTML.Append("</td> </tr>");
                strHTML.Append("<tr> <td colspan='8'>");
                strHTML.Append("Inspection Area   : " + ((!string.IsNullOrEmpty(strInspectionArea)) ? Report.GetCommaSeperatedDescFromVal("LU_Inspection_Area", "Fld_desc", "PK_LU_Inspection_Area", strInspectionArea) : ""));
                strHTML.Append("</td> </tr>");
                strHTML.Append("<tr> <td colspan='8'>");
                string strLagTimeDesc = "";
                if (strLagDayOption.IndexOf("1") > -1)
                    strLagTimeDesc = "<=2";
                if (strLagDayOption.IndexOf("2") > -1)
                    strLagTimeDesc = strLagTimeDesc + (strLagTimeDesc != "" ? ", " : "") + "3 to 5";
                if (strLagDayOption.IndexOf("3") > -1)
                    strLagTimeDesc = strLagTimeDesc + (strLagTimeDesc != "" ? ", " : "") + "6 to 10";
                if (strLagDayOption.IndexOf("4") > -1)
                    strLagTimeDesc = strLagTimeDesc + (strLagTimeDesc != "" ? ", " : "") + "11 to 15";
                if (strLagDayOption.IndexOf("5") > -1)
                    strLagTimeDesc = strLagTimeDesc + (strLagTimeDesc != "" ? ", " : "") + ">15";

                strHTML.Append("Lag Time in Days  : " + strLagTimeDesc);
                strHTML.Append("</td> </tr>");
                strHTML.Append("<tr> <td colspan='8'>");
                strHTML.Append("</td></tr></table> ");

                #endregion

                #region "Report Grid header"
                //Top Header
                strHTML.Append("<table border='1'>");
                strHTML.Append("<tr style='font-weight: bold;' valign='bottom' align='left'>");
                strHTML.Append("<td align='left' >Sonic Automotive</td>");
                strHTML.Append("<td align='center' colspan='5'>Inspection Distribution Lag Time</td>");
                strHTML.Append("<td align='right' > " + DateTime.Now.ToString() + " </td>");
                strHTML.Append("</tr>");

                //Sub Header
                strHTML.Append("<tr valign='bottom' align='left' style='font-weight: bold'>");
                strHTML.Append("<td width='150'>Region</td>");
                strHTML.Append("<td width='150'>Inspector</td>");
                strHTML.Append("<td width='150'>Location D/B/A</td>");
                strHTML.Append("<td width='150'>Inspection Area</td>");
                strHTML.Append("<td width='150'>Inspection Date</td>");
                strHTML.Append("<td width='160'>Date Inspection Report was Initially Distributed</td>");
                strHTML.Append("<td width='150' align='right'>Lag Time in Days</td>");

                strHTML.Append("</tr>");

                //Check Whether Record Exists or Not
                if (dsResult != null && dsResult.Tables.Count > 0 && dsResult.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in dsResult.Tables[0].Rows)
                    {
                        strHTML.Append("<tr valign='top' align='left'>");

                        strHTML.Append("<td width='150'>" + Convert.ToString(dr["Region"]) + "</td>");
                        strHTML.Append("<td width='150'>" + Convert.ToString(dr["Inspector_Name"]) + "</td>");
                        strHTML.Append("<td width='150'>" + Convert.ToString(dr["dba"]) + "</td>");
                        strHTML.Append("<td width='150'>" + Convert.ToString(dr["FLD_Desc"]) + "</td>");
                        strHTML.Append("<td width='150'>" + FormatDBNullDateToDisplay(dr["Date"]) + "</td>");
                        strHTML.Append("<td width='160'>" + FormatDBNullDateToDisplay(dr["Date_Report_Initially_Distibuted"]) + "</td>");
                        strHTML.Append("<td width='150' align='right'>" + string.Format("{0:N0}", dr["Lag_Time"]) + "</td>");
                        strHTML.Append("</tr>");
                    }
                }
                else
                {
                    //Add No record found line for year
                    strHTML.Append("<tr><td align='left' colspan='5'>No Record Found!</td></tr>");
                }
                strHTML.Append("</table>");

                #endregion

                //Write HTML in to HtmlWriter
                htmlWrite.WriteLine(strHTML.ToString());
                //Send Mail
                SendMail("Inspection Distribution Lag Time", "Inspection_Distribution_Lag_Time.xls", strFirstName, strLastName, strMailFrom, stringWrite, dtRecipients);
            }
        }

        private static string TotalAggregateScore(string strscore)
        {
            string strTotalAggregateScore = "";
            int TotalScore = 0;
            int.TryParse(Convert.ToString(strscore), out TotalScore);
            if (TotalScore >= 25)
                strTotalAggregateScore = "All Pro";
            else if (TotalScore >= 20 && TotalScore < 25)
                strTotalAggregateScore = "Starter";
            else if (TotalScore >= 15 && TotalScore < 20)
                strTotalAggregateScore = "Second String";
            else if (TotalScore >= 10 && TotalScore < 15)
                strTotalAggregateScore = "Water boy";
            else if (TotalScore < 10)
                strTotalAggregateScore = "Spectator";
            return strTotalAggregateScore;
        }

        private static string ResultingScore(string strscore)
        {
            string strResultingScore = "";
            double decTotalScore = 0;
            double.TryParse(Convert.ToString(strscore), out decTotalScore);
            if (decTotalScore >= 5)
                strResultingScore = "All Pro";
            else if (decTotalScore >= 4 && decTotalScore < 5)
                strResultingScore = "Starter";
            else if (decTotalScore >= 3 && decTotalScore < 4)
                strResultingScore = "Second String";
            else if (decTotalScore >= 2 && decTotalScore < 3)
                strResultingScore = "Water boy";
            else if (decTotalScore < 2)
                strResultingScore = "Spectator";
            return strResultingScore;
        }

        //Report 62
        private void BindFROIRecapReport(DataRow drReportSchedule)
        {
            decimal pK_Schedule_ID = Convert.ToDecimal(drReportSchedule["PK_Schedule"]);
            decimal Fk_RecipientList = Convert.ToDecimal(drReportSchedule["Fk_RecipientList"]);
            decimal FK_Security_Id = Convert.ToDecimal(drReportSchedule["FK_Security_Id"]);

            //Get Report criteria for the scheduled report
            DataTable dtFilter = Report.SelectFilterCriteria(62, pK_Schedule_ID).Tables[0];
            if (dtFilter.Rows.Count > 0)
            {
                try
                {
                    //Get the recipient from the recipient list 
                    DataTable dtRecipients = Report.SelectOneRecordWithRecipientList(Fk_RecipientList).Tables[0];

                    //Get the user who has scheduled the report
                    DataTable dtUser = Report.SelectSecurityByPK(FK_Security_Id).Tables[0];
                    String strFirstName, strLastName, strMailFrom;
                    strFirstName = strLastName = strMailFrom = "";
                    if (dtUser.Rows.Count > 0)
                    {
                        strFirstName = Convert.ToString(dtUser.Rows[0]["FIRST_NAME"]).Trim();
                        strLastName = Convert.ToString(dtUser.Rows[0]["LAST_NAME"]).Trim();
                        strMailFrom = Convert.ToString(dtUser.Rows[0]["Email"]).Trim();
                    }

                    string strRegion = Convert.ToString(dtFilter.Rows[0]["Region"]).Trim();
                    string strMarket = null;
                    if (!string.IsNullOrEmpty(Convert.ToString(dtFilter.Rows[0]["Market"])))
                    {
                        strMarket = Convert.ToString(dtFilter.Rows[0]["Market"]).Trim();
                    }
                    string strDBA = Convert.ToString(dtFilter.Rows[0]["DBA"]).Trim();
                    string strCategory = Convert.ToString(dtFilter.Rows[0]["First_Report_Category"]).Trim();


                    DateTime? dtIncident_Date_From;
                    DateTime? dtIncident_Date_To;
                    if (dtFilter.Rows[0]["Inspection_Date_From"] != DBNull.Value)
                        dtIncident_Date_From = Convert.ToDateTime(dtFilter.Rows[0]["Inspection_Date_From"]);
                    else
                        dtIncident_Date_From = null;
                    if (dtFilter.Rows[0]["Inspection_Date_To"] != DBNull.Value)
                        dtIncident_Date_To = Convert.ToDateTime(dtFilter.Rows[0]["Inspection_Date_To"]);
                    else
                        dtIncident_Date_To = null;

                    DataSet dsResult = Report.GetFroiRecapReport(strRegion, strMarket, strDBA, dtIncident_Date_From, dtIncident_Date_To, strCategory);

                    StringBuilder strHTML = new StringBuilder();
                    System.IO.StringWriter stringWrite = new System.IO.StringWriter();
                    System.Web.UI.HtmlTextWriter htmlWrite = new System.Web.UI.HtmlTextWriter(stringWrite);

                    #region "Report Title"

                    //Retrieve Market Values
                    string strMarketString = string.Empty;
                    if (string.IsNullOrEmpty(strMarket))
                    {
                        strMarketString = "All Market";
                    }
                    else
                    {
                        string[] strMar = strMarket.Split(Convert.ToChar(","));
                        for (int i = 0; i < strMar.Length; i++)
                        {
                            strMarketString += Report.SelectMarketInfoById(Convert.ToDecimal(strMar[i].ToString())).Tables[0].Rows[0]["Market"].ToString() + ",";
                        }
                        strMarketString = strMarketString.TrimEnd(',');
                    }

                    //Add Report Title and Schedule Date
                    strHTML.Append("<br />");
                    strHTML.Append("<b>Report Title : FROI Recapt Report</b>");
                    strHTML.Append("<br /><br />");
                    strHTML.Append("Schedule Date : " + Convert.ToDateTime(drReportSchedule["Scheduled_Date"]).ToString(DateDisplayFormat));
                    strHTML.Append("&nbsp;&nbsp;&nbsp;&nbsp;Schedule End Date : " + Convert.ToDateTime(drReportSchedule["Schedule_End_Date"]).ToString(DateDisplayFormat));
                    strHTML.Append("<br />");
                    strHTML.Append("Recurring Period : " + drReportSchedule["Recurring_Period"].ToString());
                    strHTML.Append("<br />");
                    strHTML.Append("Recurring Date : " + dtSchduleDate.ToString(DateDisplayFormat));

                    //Add Report Filter Criteria 
                    strHTML.Append("<br /><br /><table> <tr> <td>");
                    strHTML.Append("<b>Report Filters </b>");
                    strHTML.Append("<br /><table> <tr> <td colspan='11'>");
                    strHTML.Append("Region   : " + strRegion.Replace("'", ""));
                    strHTML.Append("</td> </tr>");
                    strHTML.Append("<br /><table> <tr> <td colspan='11'>");
                    strHTML.Append("Market        : " + strMarketString);
                    strHTML.Append("</td> </tr>");
                    strHTML.Append("<tr> <td colspan='11'>");
                    strHTML.Append("Location D/B/A   : " + strDBA.Replace("'", ""));
                    strHTML.Append("</td> </tr>");
                    strHTML.Append("<tr> <td colspan='11'>");
                    strHTML.Append("Date of Incident From   : " + Convert.ToString(dtIncident_Date_From));
                    strHTML.Append("</td> </tr>");
                    strHTML.Append("<tr> <td colspan='11'>");
                    strHTML.Append("Date of Incident To   : " + Convert.ToString(dtIncident_Date_To));
                    strHTML.Append("</td> </tr>");
                    strHTML.Append("<tr> <td colspan='11'>");
                    strHTML.Append("</td></tr></table> ");

                    #endregion

                    #region "Report Grid header"
                    //Top Header
                    strHTML.Append("<table border='1'>");
                    strHTML.Append("<tr style='font-weight: bold;' valign='bottom' align='left'>");
                    strHTML.Append("<td align='left' >Sonic Automotive</td>");
                    strHTML.Append("<td align='center' colspan='9'>FROI Recap Report</td>");
                    strHTML.Append("<td align='right' > " + DateTime.Now.ToString() + " </td>");
                    strHTML.Append("</tr>");
                    strHTML.Append("</table>");




                    for (int i = 0; i < dsResult.Tables.Count; i = i + 2)
                    {
                        string strReportType = dsResult.Tables[i].Rows[0][0].ToString();
                        DataTable dtTemp = new DataTable();
                        switch (strReportType)
                        {
                            case "AL":
                                #region Generate AL region
                                strHTML.Append("<table><tr><td>&nbsp;</td></tr>");
                                strHTML.Append("<tr><td>&nbsp;</td></tr>");
                                strHTML.Append("<tr><td><b>AL FROI</b></td></tr>");
                                strHTML.Append("<tr><td>&nbsp;</td></tr>");
                                strHTML.Append("<table>");
                                //Sub Header
                                strHTML.Append("<table border='1'><tr valign='bottom' align='left' style='font-weight: bold'>");
                                strHTML.Append("<td width='150'>Location</td>");
                                strHTML.Append("<td width='100'>Location Number</td>");
                                strHTML.Append("<td width='120'>FROI Number</td>");
                                strHTML.Append("<td width='100'>Date Of Loss</td>");
                                strHTML.Append("<td width='250'>Description of Loss</td>");
                                strHTML.Append("<td width='50' align='center'>Vehicle SubType<br style=\"mso-data-placement:same-cell;\">Vehicle Make<br style=\"mso-data-placement:same-cell;\">Vehicle Model<br style=\"mso-data-placement:same-cell;\">Vehicle Year</td>");
                                strHTML.Append("<td width='50'>Were Policed Notified?</td>");
                                strHTML.Append("<td width='50'>Is there a Security Video<br style=\"mso-data-placement:same-cell;\">Surveillance System?</td>");
                                strHTML.Append("<td width='250'>Comments</td>");
                                strHTML.Append("</tr>");
                                dtTemp = dsResult.Tables[i + 1];
                                if (dtTemp.Rows.Count > 0)
                                {
                                    foreach (DataRow dr in dtTemp.Rows)
                                    {
                                        strHTML.Append("<tr valign='top'>");
                                        strHTML.Append("<td >" + Convert.ToString(dr["dba"]) + "</td>");
                                        strHTML.Append("<td >" + Convert.ToString(dr["Sonic_Location_Code"]) + "</td>");
                                        strHTML.Append("<td >" + Convert.ToString(dr["AL_FR_Number"]) + "</td>");
                                        strHTML.Append("<td >" + FormatDBNullDateToDisplay(dr["Date_Of_Loss"]) + "</td>");
                                        strHTML.Append("<td >" + Convert.ToString(dr["Description_Of_Loss"]) + "</td>");
                                        strHTML.Append("<td >" + Convert.ToString(dr["Vehicle"]).Replace("</br>", "<br style=\"mso-data-placement:same-cell;\">") + "</td>");
                                        strHTML.Append("<td >" + Convert.ToString(dr["Were_Police_Notified"]) + "</td>");
                                        strHTML.Append("<td >" + Convert.ToString(dr["Security_Video_System"]) + "</td>");
                                        strHTML.Append("<td >" + Convert.ToString(dr["Comments"]) + "</td>");
                                        strHTML.Append("</tr>");
                                    }
                                }
                                else
                                {
                                    //Add No record found line for year
                                    strHTML.Append("<tr><td align='left' colspan='5'>No Record Found!</td></tr>");
                                }
                                strHTML.Append("</table>");

                                #endregion
                                break;
                            case "DPD":
                                #region Generate DPD region
                                strHTML.Append("<table><tr><td>&nbsp;</td></tr>");
                                strHTML.Append("<tr><td>&nbsp;</td></tr>");
                                strHTML.Append("<tr><td><b>DPD FROI</b></td></tr>");
                                strHTML.Append("<tr><td>&nbsp;</td></tr>");
                                strHTML.Append("<table>");
                                //Sub Header

                                strHTML.Append("<table border='1'><tr valign='bottom' align='left' style='font-weight: bold'>");
                                strHTML.Append("<td width='150'>Location</td>");
                                strHTML.Append("<td width='100'>Location Number</td>");
                                strHTML.Append("<td width='120'>FROI Number</td>");
                                strHTML.Append("<td width='100'>Date Of Loss</td>");
                                strHTML.Append("<td width='100'>Cause Of Loss</td>");
                                strHTML.Append("<td width='250'>Loss Description</td>");
                                strHTML.Append("<td width='80' align='center'>Vehicle Make<br style=\"mso-data-placement:same-cell;\">Vehicle Model<br style=\"mso-data-placement:same-cell;\">Vehicle Year<br style=\"mso-data-placement:same-cell;\">Invoice Value</td>");
                                strHTML.Append("<td width='80'>Were Policed Notified?</td>");
                                strHTML.Append("<td width='80'>Is there a Security Video<br style=\"mso-data-placement:same-cell;\">Surveillance System?</td>");
                                strHTML.Append("<td width='100'>Recovered<br style=\"mso-data-placement:same-cell;\">Damage Amount<br style=\"mso-data-placement:same-cell;\">Recovered Amount</td>");
                                strHTML.Append("<td width='250'>Comments</td>");
                                strHTML.Append("</tr>");
                                dtTemp = dsResult.Tables[i + 1];
                                if (dtTemp.Rows.Count > 0)
                                {
                                    foreach (DataRow dr in dtTemp.Rows)
                                    {
                                        strHTML.Append("<tr valign='top'>");
                                        strHTML.Append("<td >" + Convert.ToString(dr["dba"]) + "</td>");
                                        strHTML.Append("<td >" + Convert.ToString(dr["Sonic_Location_Code"]) + "</td>");
                                        strHTML.Append("<td >" + Convert.ToString(dr["DPD_FR_Number"]) + "</td>");
                                        strHTML.Append("<td >" + FormatDBNullDateToDisplay(dr["Date_Of_Loss"]) + "</td>");
                                        strHTML.Append("<td >" + Convert.ToString(dr["Cause_Of_Loss"]).Replace("</br>", "<br style=\"mso-data-placement:same-cell;\">") + "</td>");
                                        strHTML.Append("<td >" + Convert.ToString(dr["Loss_Description"]) + "</td>");
                                        strHTML.Append("<td >" + Convert.ToString(dr["Vehicle"]).Replace("</br>", "<br style=\"mso-data-placement:same-cell;\">") + "</td>");
                                        strHTML.Append("<td >" + Convert.ToString(dr["Were_Police_Notified"]) + "</td>");
                                        strHTML.Append("<td >" + Convert.ToString(dr["Security_Video_System"]) + "</td>");
                                        strHTML.Append("<td >" + Convert.ToString(dr["Recovered"]).Replace("</br>", "<br style=\"mso-data-placement:same-cell;\">") + "</td>");
                                        strHTML.Append("<td >" + Convert.ToString(dr["Comments"]) + "</td>");
                                        strHTML.Append("</tr>");
                                    }
                                }
                                else
                                {
                                    //Add No record found line for year
                                    strHTML.Append("<tr><td align='left' colspan='5'>No Record Found!</td></tr>");
                                }
                                strHTML.Append("</table>");
                                #endregion
                                break;
                            case "NS":
                                #region Generate NS region

                                strHTML.Append("<table><tr><td>&nbsp;</td></tr>");
                                strHTML.Append("<tr><td>&nbsp;</td></tr>");
                                strHTML.Append("<tr><td><b>NS FROI</b></td></tr>");
                                strHTML.Append("<tr><td>&nbsp;</td></tr>");
                                strHTML.Append("<table>");
                                //Sub Header

                                strHTML.Append("<table border='1'><tr valign='bottom' align='left' style='font-weight: bold'>");
                                strHTML.Append("<td width='150'>Location</td>");
                                strHTML.Append("<td width='100'>Location Number</td>");
                                strHTML.Append("<td width='120'>FROI Number</td>");
                                strHTML.Append("<td width='120'>Associate Name</td>");
                                strHTML.Append("<td width='100'>Date Of Loss</td>");
                                strHTML.Append("<td width='300'>Description Of Incident</td>");
                                strHTML.Append("<td width='100'>Taken By Emergency Transportation?</td>");
                                strHTML.Append("<td width='250'>Comments</td>");
                                strHTML.Append("</tr>");
                                dtTemp = dsResult.Tables[i + 1];
                                if (dtTemp.Rows.Count > 0)
                                {
                                    foreach (DataRow dr in dtTemp.Rows)
                                    {
                                        strHTML.Append("<tr valign='top'>");
                                        strHTML.Append("<td >" + Convert.ToString(dr["dba"]) + "</td>");
                                        strHTML.Append("<td >" + Convert.ToString(dr["Sonic_Location_Code"]) + "</td>");
                                        strHTML.Append("<td >" + Convert.ToString(dr["WC_FR_Number"]) + "</td>");
                                        strHTML.Append("<td >" + Convert.ToString(dr["Associate_Name"]) + "</td>");
                                        strHTML.Append("<td >" + FormatDBNullDateToDisplay(dr["Date_Of_Incident"]) + "</td>");
                                        strHTML.Append("<td >" + Convert.ToString(dr["Description_Of_Incident"]) + "</td>");
                                        strHTML.Append("<td >" + Convert.ToString(dr["Taken_By_Emergency_Transportation"]) + "</td>");
                                        strHTML.Append("<td >" + Convert.ToString(dr["Comments"]) + "</td>");
                                        strHTML.Append("</tr>");
                                    }
                                }
                                else
                                {
                                    //Add No record found line for year
                                    strHTML.Append("<tr><td align='left' colspan='5'>No Record Found!</td></tr>");
                                }
                                strHTML.Append("</table>");

                                #endregion
                                break;
                            case "PL":
                                #region Generate PL region

                                strHTML.Append("<table><tr><td>&nbsp;</td></tr>");
                                strHTML.Append("<tr><td>&nbsp;</td></tr>");
                                strHTML.Append("<tr><td><b>PL FROI</b></td></tr>");
                                strHTML.Append("<tr><td>&nbsp;</td></tr>");
                                strHTML.Append("<table>");
                                //Sub Header
                                strHTML.Append("<table border='1'><tr valign='bottom' align='left' style='font-weight: bold'>");
                                strHTML.Append("<td width='150'>Location</td>");
                                strHTML.Append("<td width='100'>Location Number</td>");
                                strHTML.Append("<td width='120'>FROI Number</td>");
                                strHTML.Append("<td width='100'>Date Of Loss</td>");
                                strHTML.Append("<td width='300'>Description Of Loss</td>");
                                strHTML.Append("<td width='80'>Were Policed Notified?</td>");
                                strHTML.Append("<td width='250'>Comments</td>");
                                strHTML.Append("</tr>");
                                dtTemp = dsResult.Tables[i + 1];
                                if (dtTemp.Rows.Count > 0)
                                {
                                    foreach (DataRow dr in dtTemp.Rows)
                                    {
                                        strHTML.Append("<tr valign='top'>");
                                        strHTML.Append("<td >" + Convert.ToString(dr["dba"]) + "</td>");
                                        strHTML.Append("<td >" + Convert.ToString(dr["Sonic_Location_Code"]) + "</td>");
                                        strHTML.Append("<td >" + Convert.ToString(dr["PL_FR_Number"]) + "</td>");
                                        strHTML.Append("<td >" + FormatDBNullDateToDisplay(dr["Date_Of_Loss"]) + "</td>");
                                        strHTML.Append("<td >" + Convert.ToString(dr["Description_of_Loss"]) + "</td>");
                                        strHTML.Append("<td >" + Convert.ToString(dr["Were_Police_Notified"]) + "</td>");
                                        strHTML.Append("<td >" + Convert.ToString(dr["Comments"]) + "</td>");
                                        strHTML.Append("</tr>");
                                    }
                                }
                                else
                                {
                                    //Add No record found line for year
                                    strHTML.Append("<tr><td align='left' colspan='5'>No Record Found!</td></tr>");
                                }
                                strHTML.Append("</table>");

                                #endregion
                                break;
                            case "Property":
                                #region Generate Property region

                                strHTML.Append("<table><tr><td>&nbsp;</td></tr>");
                                strHTML.Append("<tr><td>&nbsp;</td></tr>");
                                strHTML.Append("<tr><td><b>Property FROI</b></td></tr>");
                                strHTML.Append("<tr><td>&nbsp;</td></tr>");
                                strHTML.Append("<table>");
                                //Sub Header
                                strHTML.Append("<table border='1'><tr valign='bottom' align='left' style='font-weight: bold'>");
                                strHTML.Append("<td width='150'>Location</td>");
                                strHTML.Append("<td width='100'>Location Number</td>");
                                strHTML.Append("<td width='120'>FROI Number</td>");
                                strHTML.Append("<td width='100'>Date Of Loss</td>");
                                strHTML.Append("<td width='120'>Type Of Loss</td>");
                                strHTML.Append("<td width='300'>Description Of Loss</td>");
                                strHTML.Append("<td width='120'>Total Estimated Cost</td>");
                                strHTML.Append("<td width='100'>Is there a Security Video<br style=\"mso-data-placement:same-cell;\">Surveillance System?</td>");
                                strHTML.Append("<td width='250'>Comments</td>");
                                strHTML.Append("</tr>");
                                dtTemp = dsResult.Tables[i + 1];
                                if (dtTemp.Rows.Count > 0)
                                {
                                    foreach (DataRow dr in dtTemp.Rows)
                                    {
                                        strHTML.Append("<tr valign='top'>");
                                        strHTML.Append("<td >" + Convert.ToString(dr["dba"]) + "</td>");
                                        strHTML.Append("<td >" + Convert.ToString(dr["Sonic_Location_Code"]) + "</td>");
                                        strHTML.Append("<td >" + Convert.ToString(dr["Property_FR_Number"]) + "</td>");
                                        strHTML.Append("<td >" + FormatDBNullDateToDisplay(dr["Date_Of_Loss"]) + "</td>");
                                        strHTML.Append("<td >" + Convert.ToString(dr["Type_of_Loss"]).Replace("</br>", "<br style=\"mso-data-placement:same-cell;\">") + "</td>");
                                        strHTML.Append("<td >" + Convert.ToString(dr["Description_of_Loss"]) + "</td>");
                                        strHTML.Append("<td >" + Convert.ToString(dr["Estimated_Cost"]).Replace("</br>", "<br style=\"mso-data-placement:same-cell;\">") + "</td>");
                                        strHTML.Append("<td >" + Convert.ToString(dr["Security_Video_Surveillance"]) + "</td>");
                                        strHTML.Append("<td >" + Convert.ToString(dr["Comments"]) + "</td>");
                                        strHTML.Append("</tr>");
                                    }
                                }
                                else
                                {
                                    //Add No record found line for year
                                    strHTML.Append("<tr><td align='left' colspan='5'>No Record Found!</td></tr>");
                                }
                                strHTML.Append("</table>");

                                #endregion
                                break;
                            case "WC":
                                #region Generate WC region

                                strHTML.Append("<table><tr><td>&nbsp;</td></tr>");
                                strHTML.Append("<tr><td>&nbsp;</td></tr>");
                                strHTML.Append("<tr><td><b>WC FROI</b></td></tr>");
                                strHTML.Append("<tr><td>&nbsp;</td></tr>");
                                strHTML.Append("<table>");
                                //Sub Header
                                strHTML.Append("<table border='1'><tr valign='bottom' align='left' style='font-weight: bold'>");
                                strHTML.Append("<td width='150'>Location</td>");
                                strHTML.Append("<td width='100'>Location Number</td>");
                                strHTML.Append("<td width='120'>FROI Number</td>");
                                strHTML.Append("<td width='120'>Associate Name</td>");
                                strHTML.Append("<td width='100'>Date Of Loss</td>");
                                strHTML.Append("<td width='300'>Description Of Incident</td>");
                                strHTML.Append("<td width='100'>Taken By Emergency<br style=\"mso-data-placement:same-cell;\">Transportation?</td>");
                                strHTML.Append("<td width='250'>Comments</td>");
                                strHTML.Append("</tr>");
                                dtTemp = dsResult.Tables[i + 1];
                                if (dtTemp.Rows.Count > 0)
                                {
                                    foreach (DataRow dr in dtTemp.Rows)
                                    {
                                        strHTML.Append("<tr valign='top'>");
                                        strHTML.Append("<td >" + Convert.ToString(dr["dba"]) + "</td>");
                                        strHTML.Append("<td >" + Convert.ToString(dr["Sonic_Location_Code"]) + "</td>");
                                        strHTML.Append("<td >" + Convert.ToString(dr["WC_FR_Number"]) + "</td>");
                                        strHTML.Append("<td >" + Convert.ToString(dr["Associate_Name"]) + "</td>");
                                        strHTML.Append("<td >" + FormatDBNullDateToDisplay(dr["Date_Of_Incident"]) + "</td>");
                                        strHTML.Append("<td >" + Convert.ToString(dr["Description_Of_Incident"]) + "</td>");
                                        strHTML.Append("<td >" + Convert.ToString(dr["Taken_By_Emergency_Transportation"]) + "</td>");
                                        strHTML.Append("<td >" + Convert.ToString(dr["Comments"]) + "</td>");
                                        strHTML.Append("</tr>");
                                    }
                                }
                                else
                                {
                                    //Add No record found line for year
                                    strHTML.Append("<tr><td align='left' colspan='5'>No Record Found!</td></tr>");
                                }
                                strHTML.Append("</table>");

                                #endregion
                                break;
                        }


                    }


                    #endregion

                    //Write HTML in to HtmlWriter
                    htmlWrite.WriteLine(strHTML.ToString());
                    //Send Mail
                    SendMail("FROI Recap Report", "FROI_Recapt_Report.xls", strFirstName, strLastName, strMailFrom, stringWrite, dtRecipients);
                }
                catch (Exception ex)
                {
                    EventLog.WriteEntry("Error Occurred in FROI Recap Report on " + dtSchduleDate.ToString() + ", " + ex.Message);
                }
            }
        }

        #endregion

        #region Mail Send Method

        private void SendMail(String strReportTitle, String strFileNameToSave, String strFirstName, String strLastName, String strMailFrom, StringWriter sw, DataTable dtRecipients)
        {
            MemoryStream memorystream = new MemoryStream();
            byte[] _bytes = Encoding.UTF8.GetBytes(sw.ToString());
            memorystream.Write(_bytes, 0, _bytes.Length);
            memorystream.Seek(0, SeekOrigin.Begin);

            //strMailFrom = "kunal.dobaria@server1.com";

            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(strMailFrom);
            mail.Subject = "eRIMS :: " + strReportTitle;
            mail.Attachments.Add(new Attachment(memorystream, strFileNameToSave));

            SmtpClient mSmtpClient = new SmtpClient();
            mSmtpClient.Host = System.Configuration.ConfigurationManager.AppSettings.Get("SMTPServer");
            mSmtpClient.Credentials = new System.Net.NetworkCredential(System.Configuration.ConfigurationManager.AppSettings.Get("SMTPmail"), System.Configuration.ConfigurationManager.AppSettings.Get("SMTPPwd"));
            try
            {
                for (int i = 0; i < dtRecipients.Rows.Count; i++)
                {
                    mail.Body = dtRecipients.Rows[i]["FirstName"].ToString() + " " + dtRecipients.Rows[i]["LastName"].ToString() + ",<br />Please find the " + strReportTitle + " Attached with this mail.<br /><br /><br />Thankyou!<br />" + strFirstName + " " + strLastName;
                    mail.Body += "<br /> This is system generated message. Please do not reply.";
                    mail.IsBodyHtml = true;
                    mail.To.Add(new MailAddress(dtRecipients.Rows[i]["Email"].ToString()));
                    mSmtpClient.Send(mail);
                    mail.To.Clear();
                }
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("Error in Sending Mail for " + strReportTitle + ", " + ex.Message);
            }
        }


        #endregion

        #region Get Month String
        private string GetMonthString(Int32 Month)
        {
            string strMonthName = string.Empty;
            switch (Month)
            {
                case 1:
                    strMonthName = "January";
                    break;
                case 2:
                    strMonthName = "February";
                    break;
                case 3:
                    strMonthName = "March";
                    break;
                case 4:
                    strMonthName = "April";
                    break;
                case 5:
                    strMonthName = "May";
                    break;
                case 6:
                    strMonthName = "June";
                    break;
                case 7:
                    strMonthName = "July";
                    break;
                case 8:
                    strMonthName = "August";
                    break;
                case 9:
                    strMonthName = "September";
                    break;
                case 10:
                    strMonthName = "October";
                    break;
                case 11:
                    strMonthName = "November";
                    break;
                case 12:
                    strMonthName = "December";
                    break;
            }
            return strMonthName;

        }


        #endregion

        #region "Common Methods"
        /// <summary>
        /// Converts decimal value to string to be displayed in labels
        /// </summary>
        /// <param name="decValue"></param>
        /// <returns></returns>
        public static string GetStringValue(object objValue)
        {
            if (objValue == null || objValue == DBNull.Value)
                return string.Empty;
            else
                return Convert.ToDecimal(objValue).ToString("C").Replace("$", "");
        }
        /// <summary>
        /// Sets the dates for the labels which are not mendatory fields,
        /// it may have null value which should return an empty string
        /// </summary>
        /// <param name="objDate"></param>
        /// <returns></returns>
        public static string FormatDBNullDateToDisplay(object objDate)
        {
            if (objDate == DBNull.Value || objDate == null || objDate == "")
                return string.Empty;
            else
                return FormatDateToDisplay(Convert.ToDateTime(objDate));
        }

        /// <summary>
        /// Get Comma Seperated Value from passed table and Column
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="ColumnName"></param>
        /// <returns></returns>
        private string GetCommaValueFromTable(DataTable dt, string ColumnName)
        {
            string _strValue = string.Empty;

            for (int i = 0; i < dt.Rows.Count; i++)
                _strValue += (_strValue == "") ? dt.Rows[i][ColumnName].ToString().Trim() : "<b>,</b> " + dt.Rows[i][ColumnName].ToString().Trim();

            return _strValue;
        }

        /// <summary>
        /// Sets the dates for the labels which are not mendatory fields,
        /// it may have Minvalue (01/01/1975) which should return an empty string
        /// </summary>
        /// <param name="objDT"></param>
        /// <returns></returns>
        public static string FormatDateToDisplay(DateTime objDate)
        {
            if (Convert.ToDateTime(objDate) != (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue)
                return Convert.ToDateTime(objDate).ToString(DateDisplayFormat);
            else
                return string.Empty;
        }

        /// <summary>
        /// return Date in short date format if it is null then it return minimum value 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static DateTime FormatDateToStore(object objDate)
        {
            if (!String.IsNullOrEmpty(objDate.ToString()))
            {
                return Convert.ToDateTime(objDate.ToString());
            }
            else
            {
                return (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            }
        }
        #endregion

        #region "Exposure Report"
        public string GetScoreName(object objValue)
        {
            if (objValue != null)
            {
                if (objValue.ToString() == "1")
                {
                    return "Spectator";
                }
                else if (objValue.ToString() == "2")
                {
                    return "Water boy";
                }
                else if (objValue.ToString() == "3")
                {
                    return "Second String";
                }
                else if (objValue.ToString() == "4")
                {
                    return "Starter";
                }
                else if (objValue.ToString() == "5")
                {
                    return "All Pro";
                }
                else
                    return "";
            }
            else
            {
                return "";
            }
        }
        #endregion
    }
}