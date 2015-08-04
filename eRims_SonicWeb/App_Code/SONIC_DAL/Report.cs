using System;
using System.Text;
using System.Data;
using System.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using Microsoft.Practices.EnterpriseLibrary.Common;
using System.Data.Common;
using System.IO;
using System.Net.Mail;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace ERIMS.DAL
{
    /// <summary>
    /// Summary description for Report
    /// </summary>
    public class Report
    {
        public Report()
        {
            // 
            // TODO: Add constructor logic here
            //
        }

        #region PublicMethods
        public static DataSet GetFinancialSummary(string ClaimType, string LossYear)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Tatva_rptFinancialSummary");

            db.AddInParameter(dbCommand, "ClaimType", DbType.String, ClaimType);
            db.AddInParameter(dbCommand, "AccidentYear", DbType.String, LossYear);
            db.AddInParameter(dbCommand, "PK_Security_Id", DbType.Decimal, clsSession.UserID);

            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet GetLossLimitationReport(string InStrClaimType, decimal LossLimit1, DateTime LossFromDate1, DateTime LossToDate1,
                                                        decimal LossLimit2, DateTime LossFromDate2, DateTime LossToDate2,
                                                        decimal LossLimit3, DateTime LossFromDate3, DateTime LossToDate3,
                                                        decimal LossLimit4, DateTime LossFromDate4, DateTime LossToDate4,
                                                        decimal LossLimit5, DateTime LossFromDate5, DateTime LossToDate5)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("tatva_rptLossLimitation");

            db.AddInParameter(dbCommand, "Claim_Type", DbType.String, InStrClaimType);
            db.AddInParameter(dbCommand, "LossFromDate1", DbType.Date, LossFromDate1);
            db.AddInParameter(dbCommand, "LossToDate1", DbType.Date, LossToDate1);
            db.AddInParameter(dbCommand, "LosLimit1", DbType.Decimal, LossLimit1);

            db.AddInParameter(dbCommand, "LossFromDate2", DbType.Date, LossFromDate2);
            db.AddInParameter(dbCommand, "LossToDate2", DbType.Date, LossToDate2);
            db.AddInParameter(dbCommand, "LosLimit2", DbType.Decimal, LossLimit2);

            db.AddInParameter(dbCommand, "LossFromDate3", DbType.Date, LossFromDate3);
            db.AddInParameter(dbCommand, "LossToDate3", DbType.Date, LossToDate3);
            db.AddInParameter(dbCommand, "LosLimit3", DbType.Decimal, LossLimit3);

            db.AddInParameter(dbCommand, "LossFromDate4", DbType.Date, LossFromDate4);
            db.AddInParameter(dbCommand, "LossToDate4", DbType.Date, LossToDate4);
            db.AddInParameter(dbCommand, "LosLimit4", DbType.Decimal, LossLimit4);

            db.AddInParameter(dbCommand, "LossFromDate5", DbType.Date, LossFromDate5);
            db.AddInParameter(dbCommand, "LossToDate5", DbType.Date, LossToDate5);
            db.AddInParameter(dbCommand, "LosLimit5", DbType.Decimal, LossLimit5);
            db.AddInParameter(dbCommand, "PK_Security_Id", DbType.Decimal, clsSession.UserID);

            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet GetCauseAnalysisReport(DateTime LossFromDate, DateTime LossToDate)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Tatav_rptCauseAnalysisReport");

            db.AddInParameter(dbCommand, "LossFromDate", DbType.DateTime, LossFromDate);
            db.AddInParameter(dbCommand, "LossToDate", DbType.DateTime, LossToDate);
            db.AddInParameter(dbCommand, "PK_Security_Id", DbType.Decimal, clsSession.UserID);

            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet GetLossStratificationReport(string ClaimType, string PolicyYear)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Tatav_rptLossStratification");

            db.AddInParameter(dbCommand, "Claim_Type", DbType.String, ClaimType);
            db.AddInParameter(dbCommand, "Policy_Year", DbType.String, PolicyYear);
            db.AddInParameter(dbCommand, "PK_Security_Id", DbType.Decimal, clsSession.UserID);

            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet GetDetailPITReport(DateTime dtCompareStDate, DateTime dtCompareEnDate, DateTime dtLossStDate, DateTime dtLossEnDate, String strClaimTypeList)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Tatva_RptDetailPITReport");

            db.AddInParameter(dbCommand, "@dtComp_St_Date", DbType.DateTime, dtCompareStDate);
            db.AddInParameter(dbCommand, "@dtComp_En_Date", DbType.DateTime, dtCompareEnDate);
            db.AddInParameter(dbCommand, "@dtLoss_St_Date", DbType.DateTime, dtLossStDate);
            db.AddInParameter(dbCommand, "@dtLoss_En_Date", DbType.DateTime, dtLossEnDate);
            db.AddInParameter(dbCommand, "@claimType", DbType.String, strClaimTypeList);
            db.AddInParameter(dbCommand, "PK_Security_Id", DbType.Decimal, clsSession.UserID);

            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet GetSummaryPITReport(DateTime dtCompareStDate, DateTime dtCompareEnDate, String strPolicyYearList, String strClaimTypeList)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Tatva_RptSummaryPITReport");

            db.AddInParameter(dbCommand, "@dtComp_St_Date", DbType.DateTime, dtCompareStDate);
            db.AddInParameter(dbCommand, "@dtComp_En_Date", DbType.DateTime, dtCompareEnDate);
            db.AddInParameter(dbCommand, "@AccidentYear", DbType.String, strPolicyYearList);
            db.AddInParameter(dbCommand, "@claimType", DbType.String, strClaimTypeList);
            db.AddInParameter(dbCommand, "PK_Security_Id", DbType.Decimal, clsSession.UserID);

            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet GetThreePITSummaryReport(DateTime dtAsOf1, DateTime dtLossFrom1, DateTime dtLossTo1,
                                                       DateTime dtAsOf2, DateTime dtLossFrom2, DateTime dtLossTo2,
                                                       DateTime dtAsOf3, DateTime dtLossFrom3, DateTime dtLossTo3, String strClaimType)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Tatva_RptThreePITSummaryReport");

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

        #endregion

        #region Financial Pay Type

        public static DataSet GetLiabilityMajorClaimType()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Tatva_FinancialPayTypeSummarySelectLiabilityMajorClaimType");

            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet GetSumOFLiabilityClaims(string year)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Tatva_rptFinancialPayType");


            db.AddInParameter(dbCommand, "fetch_Year", DbType.String, year);
            db.AddInParameter(dbCommand, "PK_Security_Id", DbType.Decimal, clsSession.UserID);

            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet GetPolicyYear()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Tatva_FinancialPayTypeSummarySelectYear");

            return db.ExecuteDataSet(dbCommand);
        }
        public static DataSet GetLossYear()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Tatva_rptFinancialSummarySelectLossYear");

            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet GetRecipientList()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Tatva_ScheduleGetRecipientList");

            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet GetFreqencySeverityReport(string fetch_ClaimType, DateTime LossFromDate, DateTime LossToDate)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Tatva_rptFreqencySeverityReport");


            db.AddInParameter(dbCommand, "fetch_ClaimType", DbType.String, fetch_ClaimType);
            db.AddInParameter(dbCommand, "LossFromDate", DbType.DateTime, LossFromDate);
            db.AddInParameter(dbCommand, "LossToDate", DbType.DateTime, LossToDate);
            db.AddInParameter(dbCommand, "PK_Security_Id", DbType.Decimal, clsSession.UserID);
            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet GetLagSummaryReport(string fetch_ClaimType, DateTime LossFromDate, DateTime LossToDate)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Tatva_rptLagSummaryReport");


            db.AddInParameter(dbCommand, "Claim_Type", DbType.String, fetch_ClaimType);
            db.AddInParameter(dbCommand, "LossFromDate", DbType.DateTime, LossFromDate);
            db.AddInParameter(dbCommand, "LossToDate", DbType.DateTime, LossToDate);
            db.AddInParameter(dbCommand, "PK_Security_Id", DbType.Decimal, clsSession.UserID);
            return db.ExecuteDataSet(dbCommand);
        }

        public static void BindRecipientList(ref DropDownList ddlRecipientList)
        {
            //Bind the list of Recipient List to send email
            DataSet ds = GetRecipientList();
            ddlRecipientList.DataTextField = "ListName";
            ddlRecipientList.DataValueField = "pk_RecipientList_ID";
            ddlRecipientList.DataSource = ds.Tables[0].DefaultView;
            ddlRecipientList.DataBind();
        }
        #endregion

        #region Send Report As Attachment

        public static bool SendReportAsAttachment(String strReportTitle, GridView gvReportGrid, String strFileNameToSave, decimal decRecipientList)
        {
            DataTable dtRecipients = Tatva_RecipientListMatrix.SelectOneRecordWithRecipientList(decRecipientList).Tables[0];

            System.IO.StringWriter stringWrite = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter htmlWrite = new System.Web.UI.HtmlTextWriter(stringWrite);
            htmlWrite.WriteLine("<br />");
            htmlWrite.WriteLine("<b>Report Title : " + strReportTitle + "</b>");
            htmlWrite.WriteLine("<br /><br />");
            gvReportGrid.RenderControl(htmlWrite);

            MemoryStream memorystream = new MemoryStream();
            byte[] _bytes = Encoding.UTF8.GetBytes(stringWrite.ToString());
            memorystream.Write(_bytes, 0, _bytes.Length);
            memorystream.Seek(0, SeekOrigin.Begin);

            RIMS_Base.Biz.CSecurity objSecurity = new RIMS_Base.Biz.CSecurity();
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(objSecurity.GetSecurityByID(Convert.ToInt32(clsSession.UserID))[0].Email);
            mail.Subject = "eRIMS :: " + strReportTitle;
            mail.Attachments.Add(new Attachment(memorystream, strFileNameToSave));

            SmtpClient mSmtpClient = new SmtpClient();
            mSmtpClient.Host = ConfigurationManager.AppSettings["SMTPServer"].ToString();
            //mSmtpClient.Credentials = new System.Net.NetworkCredential("kunal.dobaria@server1.com", "kunal123");
            try
            {
                for (int i = 0; i < dtRecipients.Rows.Count; i++)
                {
                    mail.Body = dtRecipients.Rows[i]["FirstName"].ToString() + " " + dtRecipients.Rows[i]["LastName"].ToString() + ",<br />Please find the " + strReportTitle + " Attached with this mail.<br /><br /><br />Thankyou!<br />" + clsSession.FirstName + " " + clsSession.LastName;
                    mail.IsBodyHtml = true;
                    mail.To.Add(new MailAddress(dtRecipients.Rows[i]["Email"].ToString()));
                    mSmtpClient.Send(mail);
                    mail.To.Clear();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        #endregion

        #region "Security Case Reoport"

        public static DataSet GetOpenCaseDetailReport(DateTime? dtFromDate, DateTime? dtTodate, string strCaseType, decimal UserID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Tatva_rptOpened_SecurityCase");

            db.AddInParameter(dbCommand, "From_OpenedDate", DbType.DateTime, dtFromDate);
            db.AddInParameter(dbCommand, "To_OpenedDate", DbType.DateTime, dtTodate);
            db.AddInParameter(dbCommand, "Case_Type", DbType.String, strCaseType);
            db.AddInParameter(dbCommand, "PK_Security_Id", DbType.Decimal, UserID);
            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet GetClosedCaseDetailReport()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Tatva_rptClosed_SecurityCase");
            db.AddInParameter(dbCommand, "PK_Security_Id", DbType.Decimal, Convert.ToDecimal(clsSession.UserID));
            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet GetCaseDetailReport(DateTime? dtFromDate, DateTime? dtTodate, string strCaseType, string strCaseStatus, string strAssignedBy, string strCasePriority, decimal UserID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Tatva_rptSecurityCaseDetail");

            db.AddInParameter(dbCommand, "PK_Security_Id", DbType.Decimal, Convert.ToDecimal(clsSession.UserID));
            db.AddInParameter(dbCommand, "From_OpenedDate", DbType.DateTime, dtFromDate);
            db.AddInParameter(dbCommand, "To_OpenedDate", DbType.DateTime, dtTodate);

            if (!string.IsNullOrEmpty(strCaseType))
                db.AddInParameter(dbCommand, "Case_Type", DbType.String, strCaseType);

            if (!string.IsNullOrEmpty(strCaseStatus))
                db.AddInParameter(dbCommand, "Case_Status", DbType.String, strCaseStatus);

            if (!string.IsNullOrEmpty(strAssignedBy))
                db.AddInParameter(dbCommand, "Assigned_By", DbType.String, strAssignedBy);

            if (!string.IsNullOrEmpty(strCasePriority))
                db.AddInParameter(dbCommand, "Case_Priority", DbType.String, strCasePriority);

            return db.ExecuteDataSet(dbCommand);
        }

        #endregion

        #region "Real Estate Report"

        public static DataSet GetLeaseTermReport(string strRegion,string strMarket, string strLeaseType, DateTime? dtLCDFrom, DateTime? dtLCDTo, DateTime? dtLEDFrom, DateTime? dtLEDTo)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("rptLeaseTerm");


            if (!string.IsNullOrEmpty(strRegion))
                db.AddInParameter(dbCommand, "Region", DbType.String, strRegion);

            if (!string.IsNullOrEmpty(strMarket))
                db.AddInParameter(dbCommand, "Market", DbType.String, strMarket);

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

        public static DataSet GetSubspacesByLocation(string strRegion, string strMarket, string strLeaseType, DateTime? dtLCDFrom, DateTime? dtLCDTo, DateTime? dtLEDFrom, DateTime? dtLEDTo)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("rptSubspacesByLocation");


            if (!string.IsNullOrEmpty(strRegion))
                db.AddInParameter(dbCommand, "Region", DbType.String, strRegion);

            if (!string.IsNullOrEmpty(strMarket))
                db.AddInParameter(dbCommand, "Market", DbType.String, strMarket);


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

        public static DataSet GetMasterDealershipByRegion(string strRegion, string strMarket, DateTime? dtLCDFrom, DateTime? dtLCDTo, DateTime? dtLEDFrom, DateTime? dtLEDTo, string strLocation_Status)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("rptMasterDealershipByRegion");


            if (!string.IsNullOrEmpty(strRegion))
                db.AddInParameter(dbCommand, "Region", DbType.String, strRegion);

            if (!string.IsNullOrEmpty(strMarket))
                db.AddInParameter(dbCommand, "Market", DbType.String, strMarket);

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


        public static DataSet GetRentableAreaByExpirationDate(string strRegion, string strMarket, string strLeaseType, DateTime? dtLCDFrom, DateTime? dtLCDTo, DateTime? dtLEDFrom, DateTime? dtLEDTo)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("rptRentableAreaByExpirationDate");

            db.AddInParameter(dbCommand, "Year", DbType.Int32, System.DateTime.Today.Year);

            if (!string.IsNullOrEmpty(strRegion))
                db.AddInParameter(dbCommand, "Region", DbType.String, strRegion);

            if (!string.IsNullOrEmpty(strMarket))
                db.AddInParameter(dbCommand, "Market", DbType.String, strMarket);

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

        public static DataSet GetLeasesWithSecurityDeposits(string strRegion,string strMarket, string strLeaseType, DateTime? dtLCDFrom, DateTime? dtLCDTo, DateTime? dtLEDFrom, DateTime? dtLEDTo)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("rptLeasesWithSecurityDeposits");


            if (!string.IsNullOrEmpty(strRegion))
                db.AddInParameter(dbCommand, "Region", DbType.String, strRegion);

            if (!string.IsNullOrEmpty(strMarket))
                db.AddInParameter(dbCommand, "Market", DbType.String, strMarket);

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

        public static DataSet GetLandlordReport(string strRegion, string strMarket, string strLeaseType, DateTime? dtLCDFrom, DateTime? dtLCDTo, DateTime? dtLEDFrom, DateTime? dtLEDTo)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("rptLandlord");


            if (!string.IsNullOrEmpty(strRegion))
                db.AddInParameter(dbCommand, "Region", DbType.String, strRegion);

            if (!string.IsNullOrEmpty(strMarket))
                db.AddInParameter(dbCommand, "Market", DbType.String, strMarket);

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

        public static DataSet GetLeaseDetailReport(string strRegion, string strMarket, string strLeaseType, DateTime? dtLCDFrom, DateTime? dtLCDTo, DateTime? dtLEDFrom, DateTime? dtLEDTo, string strOrder)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Lease_Detail_Report");

            db.AddInParameter(dbCommand, "Region", DbType.String, strRegion);
            db.AddInParameter(dbCommand, "Market", DbType.String, strMarket);
            db.AddInParameter(dbCommand, "Lease_Type", DbType.String, strLeaseType);
            db.AddInParameter(dbCommand, "LCD_From", DbType.DateTime, dtLCDFrom);
            db.AddInParameter(dbCommand, "LCD_To", DbType.DateTime, dtLCDTo);
            db.AddInParameter(dbCommand, "LED_From", DbType.DateTime, dtLEDFrom);
            db.AddInParameter(dbCommand, "LED_To", DbType.DateTime, dtLEDTo);
            db.AddInParameter(dbCommand, "strorder", DbType.String, strOrder);

            return db.ExecuteDataSet(dbCommand);
        }

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

        public static DataSet GetMaintenanceAndRepairItems(string strRegion, string strMarket, string strLeaseType, DateTime? dtLCDFrom, DateTime? dtLCDTo, DateTime? dtLEDFrom, DateTime? dtLEDTo)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("rptREMaintenanceAndRepair");


            if (!string.IsNullOrEmpty(strRegion))
                db.AddInParameter(dbCommand, "Region", DbType.String, strRegion);

            if (!string.IsNullOrEmpty(strMarket))
                db.AddInParameter(dbCommand, "Market", DbType.String, strMarket);

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

        public static DataSet GetMonthlyExpenseByLocation(string strRegion, string strMarket, string strLeaseType, DateTime? dtLCDFrom, DateTime? dtLCDTo, DateTime? dtLEDFrom, DateTime? dtLEDTo)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("rptMonthlyExpenseByLocation");

            db.AddInParameter(dbCommand, "Curr_Date", DbType.DateTime, System.DateTime.Today);
            if (!string.IsNullOrEmpty(strRegion))
                db.AddInParameter(dbCommand, "Region", DbType.String, strRegion);

            if (!string.IsNullOrEmpty(strMarket))
                db.AddInParameter(dbCommand, "Market", DbType.String, strMarket);

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

        public static DataSet GetWCAllocationYTDChargeReport(string strRegion, string strMarket, string strLocation, string strYear)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("rptWCAllocationYTDChargeReport");

            if (!string.IsNullOrEmpty(strRegion))
                db.AddInParameter(dbCommand, "region", DbType.String, strRegion);

            if (!string.IsNullOrEmpty(strMarket))
                db.AddInParameter(dbCommand, "Market", DbType.String, strMarket);

            if (!string.IsNullOrEmpty(strLocation))
                db.AddInParameter(dbCommand, "location", DbType.String, strLocation);

            if (!string.IsNullOrEmpty(strYear))
                db.AddInParameter(dbCommand, "Accident_year", DbType.String, strYear);

            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet GetWCAllocationYTDChargeReport_ByMarket(string strRegion, string strMarket, string strLocation, string strYear)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("rptWCAllocationYTDChargeReport_ByMarket");

            if (!string.IsNullOrEmpty(strRegion))
                db.AddInParameter(dbCommand, "region", DbType.String, strRegion);

            if (!string.IsNullOrEmpty(strMarket))
                db.AddInParameter(dbCommand, "Market", DbType.String, strMarket);

            if (!string.IsNullOrEmpty(strLocation))
                db.AddInParameter(dbCommand, "location", DbType.String, strLocation);

            if (!string.IsNullOrEmpty(strYear))
                db.AddInParameter(dbCommand, "Accident_year", DbType.String, strYear);

            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet GetCriticalDatesReport(string strRegion,string strMarket, DateTime? dtLCDFrom, DateTime? dtLCDTo, DateTime? dtLEDFrom, DateTime? dtLEDTo, string strLocation_Status, string strReportName)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("rptCriticalDates");


            if (!string.IsNullOrEmpty(strRegion))
                db.AddInParameter(dbCommand, "Region", DbType.String, strRegion);

            if (!string.IsNullOrEmpty(strMarket))
                db.AddInParameter(dbCommand, "Market", DbType.String, strMarket);

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

        public static DataSet GetLandlordInfoReport(string strRegion, string strMarket, DateTime? dtLCDFrom, DateTime? dtLCDTo, DateTime? dtLEDFrom, DateTime? dtLEDTo, string strLocation_Status)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("rptlandlordInfo");

            if (!string.IsNullOrEmpty(strRegion))
                db.AddInParameter(dbCommand, "Region", DbType.String, strRegion);
            
            if (!string.IsNullOrEmpty(strMarket))
                db.AddInParameter(dbCommand, "Market", DbType.String, strMarket);

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

        public static DataSet GetSubLeaseReportCOI(string strDBA, string strMarket, DateTime? dtLCDFrom, DateTime? dtLCDTo, DateTime? dtLEDFrom, DateTime? dtLEDTo, string strStatus)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("rptSubLeaseReportCOI");


            if (!string.IsNullOrEmpty(strDBA))
                db.AddInParameter(dbCommand, "DBA", DbType.String, strDBA);

            if (!string.IsNullOrEmpty(strMarket))
                db.AddInParameter(dbCommand, "Market", DbType.String, strMarket);
            else
                db.AddInParameter(dbCommand, "Market", DbType.String, DBNull.Value);

            if (dtLCDFrom != null)
                db.AddInParameter(dbCommand, "LCD_From", DbType.DateTime, dtLCDFrom);

            if (dtLCDTo != null)
                db.AddInParameter(dbCommand, "LCD_To", DbType.DateTime, dtLCDTo);

            if (dtLEDFrom != null)
                db.AddInParameter(dbCommand, "LED_From", DbType.DateTime, dtLEDFrom);

            if (dtLEDTo != null)
                db.AddInParameter(dbCommand, "LED_To", DbType.DateTime, dtLEDTo);

            db.AddInParameter(dbCommand, "Pk_Security_ID", DbType.Decimal, Convert.ToDecimal(clsSession.UserID));
            db.AddInParameter(dbCommand, "Status", DbType.String, strStatus);

            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet getrptLocationsLeasePolicyDates(int SubleaseAgreement,string strRegion, string strMarket, string strLocation,string strBuildingStatus,int InsuredActive)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("rptLocations_Lease_Policy_Dates_New");

            db.AddInParameter(dbCommand, "SubleaseAgreement", DbType.Int32, SubleaseAgreement);

            if (!string.IsNullOrEmpty(strRegion))
                db.AddInParameter(dbCommand, "Region", DbType.String, strRegion);
            else
                db.AddInParameter(dbCommand, "Region", DbType.String, DBNull.Value);

            if (!string.IsNullOrEmpty(strMarket))
                db.AddInParameter(dbCommand, "Market", DbType.String, strMarket);
            else
                db.AddInParameter(dbCommand, "Market", DbType.String, DBNull.Value);

            if (!string.IsNullOrEmpty(strLocation))
                db.AddInParameter(dbCommand, "FK_Lu_Location_Id", DbType.String, strLocation);
            else
                db.AddInParameter(dbCommand, "FK_Lu_Location_Id", DbType.String, DBNull.Value);

            if (!string.IsNullOrEmpty(strBuildingStatus))
                db.AddInParameter(dbCommand, "Building_Status", DbType.String, strBuildingStatus);
            else
                db.AddInParameter(dbCommand, "Building_Status", DbType.String, DBNull.Value);

            db.AddInParameter(dbCommand, "Insured_Active", DbType.Int32, InsuredActive);
            
            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet GetSubLeaseReport(string strDBA, string strMarket, DateTime? dtLCDFrom, DateTime? dtLCDTo, DateTime? dtLEDFrom, DateTime? dtLEDTo, string strStatus)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("rptSubLeaseReport");
            
            if (!string.IsNullOrEmpty(strDBA))
                db.AddInParameter(dbCommand, "DBA", DbType.String, strDBA);

            if (!string.IsNullOrEmpty(strMarket))
                db.AddInParameter(dbCommand, "Market", DbType.String, strMarket);
            else
                db.AddInParameter(dbCommand, "Market", DbType.String, DBNull.Value);

            if (dtLCDFrom != null)
                db.AddInParameter(dbCommand, "LCD_From", DbType.DateTime, dtLCDFrom);

            if (dtLCDTo != null)
                db.AddInParameter(dbCommand, "LCD_To", DbType.DateTime, dtLCDTo);

            if (dtLEDFrom != null)
                db.AddInParameter(dbCommand, "LED_From", DbType.DateTime, dtLEDFrom);

            if (dtLEDTo != null)
                db.AddInParameter(dbCommand, "LED_To", DbType.DateTime, dtLEDTo);

            db.AddInParameter(dbCommand, "Pk_Security_ID", DbType.Decimal, Convert.ToDecimal(clsSession.UserID));
            db.AddInParameter(dbCommand, "Status", DbType.String, strStatus);

            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet GetLandlordNotificationReport(string strRegion,string strMarket, DateTime? dtLCDFrom, DateTime? dtLCDTo, DateTime? dtLEDFrom, DateTime? dtLEDTo, string strLocation_Status)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("rptLandlordNotificationReportDates");


            if (!string.IsNullOrEmpty(strRegion))
                db.AddInParameter(dbCommand, "Region", DbType.String, strRegion);

            if (!string.IsNullOrEmpty(strMarket))
                db.AddInParameter(dbCommand, "Market", DbType.String, strMarket);

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

        public static DataSet GetInsurancePolicyYears()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand("select distinct Policy_Year  as PolicyYear from Policy where Policy_Year  is not null");//"select distinct(year(Policy_Begin_Date)) as PolicyYear from Policy");
            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet GetPolicyTypesByProgramIDs(string strProgramIDs)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand("select PK_ID, FLD_desc from Policy_Type where Program_ID in (" + strProgramIDs + ") order by FLD_desc");
            return db.ExecuteDataSet(dbCommand);
        }

        #endregion

        #region " Dashboard Reports "

        public static DataSet GetFacilityInspectionReport(string strRegion, int intYear, string strInterval)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("rptFacilityInspection");
            db.AddInParameter(dbCommand, "Region", DbType.String, strRegion);
            db.AddInParameter(dbCommand, "Year", DbType.Int32, intYear);
            db.AddInParameter(dbCommand, "strInterval", DbType.String, strInterval);
            db.AddInParameter(dbCommand, "Pk_Security_ID", DbType.Decimal, Convert.ToDecimal(clsSession.UserID));

            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet GetSafertyFirstAwardReport(string strRegion,string strMarket, int Year)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("SafertyFirstAwardReport");

            db.AddInParameter(dbCommand, "Pk_Security_ID", DbType.Decimal, Convert.ToDecimal(clsSession.UserID));
            db.AddInParameter(dbCommand, "Regions", DbType.String, strRegion);
            db.AddInParameter(dbCommand, "Market", DbType.String, strMarket);
            db.AddInParameter(dbCommand, "Year", DbType.Int32, Year);

            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet GetIncidentInvestigationReport(string strRegion, string strMarket, int intYear, string strInterval)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("rptIncidentInvestigation");
            db.AddInParameter(dbCommand, "Region", DbType.String, strRegion);
            db.AddInParameter(dbCommand, "Market", DbType.String, strMarket);
            db.AddInParameter(dbCommand, "Year", DbType.Int32, intYear);
            db.AddInParameter(dbCommand, "strInterval", DbType.String, strInterval);
            db.AddInParameter(dbCommand, "Pk_Security_ID", DbType.Decimal, Convert.ToDecimal(clsSession.UserID));

            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet GetIncidentReductionReport(string strRegion, string strMarket, int intYear, string strInterval)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("rptIncidentReduction");
            db.AddInParameter(dbCommand, "Region", DbType.String, strRegion);
            db.AddInParameter(dbCommand, "Market", DbType.String, strMarket);
            db.AddInParameter(dbCommand, "Year", DbType.Int32, intYear);
            db.AddInParameter(dbCommand, "strInterval", DbType.String, strInterval);
            db.AddInParameter(dbCommand, "Pk_Security_ID", DbType.Decimal, Convert.ToDecimal(clsSession.UserID));

            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet GetWCClaimManagementReport(string strRegion, string strMarket, int intYear, string strInterval)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("rptWCClaimManagement");
            db.AddInParameter(dbCommand, "Region", DbType.String, strRegion);
            db.AddInParameter(dbCommand, "Market", DbType.String, strMarket);
            db.AddInParameter(dbCommand, "Year", DbType.Int32, intYear);
            db.AddInParameter(dbCommand, "strInterval", DbType.String, strInterval);
            db.AddInParameter(dbCommand, "Pk_Security_ID", DbType.Decimal, Convert.ToDecimal(clsSession.UserID));

            return db.ExecuteDataSet(dbCommand);
        }

        #endregion

        public static DataSet SearchSecurityReport(string pK_Security_ID, string Region, string Market, string pk_Location_Id)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Security_Report");

            if (string.IsNullOrEmpty(pK_Security_ID))
                db.AddInParameter(dbCommand, "PK_Security_ID", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "PK_Security_ID", DbType.String, pK_Security_ID);

            if (string.IsNullOrEmpty(Region))
                db.AddInParameter(dbCommand, "Region", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Region", DbType.String, Region);

            if (string.IsNullOrEmpty(Market))
                db.AddInParameter(dbCommand, "Market", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Market", DbType.String, Market);

            if (string.IsNullOrEmpty(pk_Location_Id))
                db.AddInParameter(dbCommand, "PK_LU_Location_ID", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "PK_LU_Location_ID", DbType.String, pk_Location_Id);



            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet SecurityAll()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Security_All");

            return db.ExecuteDataSet(dbCommand);
        }
        public static DataSet SecurityLoc()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Secutity_Location");

            return db.ExecuteDataSet(dbCommand);
        }
        public static DataSet SecurityReg()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Security_Region");

            return db.ExecuteDataSet(dbCommand);

        }

        /// <summary>
        /// sedgwick report (1)--- Action Plans Not Completed Report
        /// </summary>
        /// <param name="pK_Security_ID"></param>
        /// <param name="Region"></param>
        /// <param name="pk_Location_Id"></param>
        /// <returns></returns>
        public static DataSet GetActionPlansNotCompletedReport(string GroupBy1, string GroupBy2, string Sort1, string Sort2, string Sedgwick_Field_Office, string Year, string Quarter, string Location_Number,string ClaimReviewStatus)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("rptActionPlansNotCompleted_Report");


            db.AddInParameter(dbCommand, "GroupBy1", DbType.String, GroupBy1);
            db.AddInParameter(dbCommand, "GroupBy2", DbType.String, GroupBy2);
            db.AddInParameter(dbCommand, "Sort1", DbType.String, Sort1);
            db.AddInParameter(dbCommand, "Sort2", DbType.String, Sort2);
            db.AddInParameter(dbCommand, "Sedgwick_Field_Office", DbType.String, Sedgwick_Field_Office);
            db.AddInParameter(dbCommand, "Year", DbType.String, Year);
            db.AddInParameter(dbCommand, "Quarter", DbType.String, Quarter);
            db.AddInParameter(dbCommand, "Location_Number", DbType.String, Location_Number);
            db.AddInParameter(dbCommand, "ClaimReviewStatus", DbType.String, ClaimReviewStatus);

            return db.ExecuteDataSet(dbCommand);
        }

    }
}