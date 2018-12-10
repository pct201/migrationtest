using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ERIMS.DAL;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Text;
using System.Configuration;
using System.Collections;
/// <summary>
/// Summary description for SLT_Reports
/// </summary>
public class SLT_Reports : System.Web.UI.Page
{
    public SLT_Reports()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    private static string strDocumentFolder = ConfigurationManager.AppSettings["AttachmentDocs"];
    private static string strSafetyTempDirName = HttpContext.Current.Session.SessionID;
    public static string strSafetyTempDir = AppConfig.SitePath + strDocumentFolder + "\\" + strSafetyTempDirName;
    private static string strTrainingTempDirName = HttpContext.Current.Session.SessionID;
    public static string strTrainingTempDir = AppConfig.SitePath + strDocumentFolder + "\\" + strTrainingTempDirName;
    public static string strSafetyWalkDir = AppConfig.SitePath + strDocumentFolder + "\\" + "SLT_SafetyWalkDocs";
    #region "properties"
    /// <summary>
    /// Denotes the Foreign Key
    /// </summary>
    public decimal PK_SLT_Meeting
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_SLT_Meeting"]);
        }
        set { ViewState["PK_SLT_Meeting"] = value; }
    }
    /// <summary>
    /// Denotes the FK_LU_Location
    /// </summary>
    public decimal FK_LU_Location_ID
    {
        get
        {
            return clsGeneral.GetInt(ViewState["FK_LU_Location_ID"]);
        }
        set { ViewState["FK_LU_Location_ID"] = value; }
    }
    /// <summary>
    /// Denotes the Foreign Key
    /// </summary>
    public decimal PK_SLT_Meeting_Schedule
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_SLT_Meeting_Schedule"]);
        }
        set { ViewState["PK_SLT_Meeting_Schedule"] = value; }
    }
    #endregion
    #region"methods"
    public string GenerateReviewDoc()
    {
        SLT_Meeting_Schedule objSLT_Meeting_Schedule = new SLT_Meeting_Schedule(PK_SLT_Meeting_Schedule);
        FileStream fsMail = new FileStream(AppConfig.SitePath + @"\Sonic\SLT\SLT_Meeting_Review.htm", FileMode.Open, FileAccess.Read);
        StreamReader rd = new StreamReader(fsMail);
        StringBuilder strBody = new StringBuilder(rd.ReadToEnd().ToString());
        rd.Close();
        fsMail.Close();
        LU_Location objLU_Location = new LU_Location(FK_LU_Location_ID);
        string Meeting_Points = "", Safety_Walk_Points = "", Incidents_Review_Points = "", Quality_Review = "", Total_Points = "", Score_Desc = "";
        decimal Score = 0;
        //if (objSLT_Meeting_Schedule.SLT_Score != null)
        //{
        //    Score = (decimal)objSLT_Meeting_Schedule.SLT_Score;
        //    if (Score >= 0 && Score <= 11.5m) Score_Desc = Charts.Tin_Label;
        //    else if (Score > 11.5m && Score <= 17.5m) Score_Desc = Charts.Bronze_Label;
        //    else if (Score > 17.5m && Score <= 23.5m) Score_Desc = Charts.Silver_Label;
        //    else if (Score > 23.5m && Score < 30) Score_Desc = Charts.Gold_Label;
        //    else if (Score >= 30) Score_Desc = Charts.Platinum_Label;
        //    else Score_Desc = "";
        //}
        Score = Convert.ToDecimal((objSLT_Meeting_Schedule.Full_Participation == null ? 0 : objSLT_Meeting_Schedule.Full_Participation) + 
            (objSLT_Meeting_Schedule.Full_SW_Participation==null ? 0 :objSLT_Meeting_Schedule.Full_SW_Participation) + 
            (objSLT_Meeting_Schedule.Incident_Review == null ? 0 : objSLT_Meeting_Schedule.Incident_Review) + 
            (objSLT_Meeting_Schedule.RLCM_Score == null ? 0 : objSLT_Meeting_Schedule.RLCM_Score));
        if (Score > 0)
        {
            Score = (Score * 100) / Convert.ToDecimal(2.5);
            if (Score > 90 && Score <= 100) Score_Desc = Charts.Platinum_Label;
            else if (Score > 85 && Score <= 90) Score_Desc = Charts.Gold_Label;
            else if (Score > 80 && Score <= 85) Score_Desc = Charts.Silver_Label;           
            else if (Score <= 80) Score_Desc = Charts.Tin_Label;
            else Score_Desc = "";
        }

        strBody = strBody.Replace("[Location_Dba]", objLU_Location.dba);
        strBody = strBody.Replace("[Meeting_Date]", clsGeneral.FormatDBNullDateToDisplay(objSLT_Meeting_Schedule.Actual_Meeting_Date));
        strBody = strBody.Replace("[Meeting_Comments]", objSLT_Meeting_Schedule.Meeting_Comments);
        strBody = strBody.Replace("[Total_Points]", objSLT_Meeting_Schedule.SLT_Score != null ? objSLT_Meeting_Schedule.SLT_Score.ToString() : "");
        strBody = strBody.Replace("[Score_1]", objSLT_Meeting_Schedule.Full_Participation != null ? objSLT_Meeting_Schedule.Full_Participation.ToString() : "");
        strBody = strBody.Replace("[Score_2]", objSLT_Meeting_Schedule.Full_SW_Participation != null ? objSLT_Meeting_Schedule.Full_SW_Participation.ToString() : "");
        strBody = strBody.Replace("[Score_3]", objSLT_Meeting_Schedule.Incident_Review != null ? objSLT_Meeting_Schedule.Incident_Review.ToString() : "");
        strBody = strBody.Replace("[Score_4]", objSLT_Meeting_Schedule.RLCM_Score != null ? objSLT_Meeting_Schedule.RLCM_Score.ToString() : "");
        strBody = strBody.Replace("[Attendees_info]", GetAttendeesDetails());
        strBody = strBody.Replace("[Total_Score]", Score_Desc);


        return strBody.ToString();
    }

    private string GetAttendeesDetails()
    {
        StringBuilder sbGrid = new StringBuilder();
        string style = "style='font-size: 11pt; font-weight: normal;  font-family: Calibri;'>";
        string styleHeader = "<span style='font-family: Calibri;'>";
        sbGrid.Append("<table cellpadding='0' cellspacing='0' border='0' width='100%' align='center'>");
        DataTable DtAttendees = SLT_Meeting_Attendees.SelectBYFK(PK_SLT_Meeting_Schedule).Tables[0];
        if (DtAttendees.Rows.Count > 0)
        {
            sbGrid.Append("<tr><th align='left' valign='top' width='25%'>" + styleHeader + "First Name</span></th>");
            sbGrid.Append("<th align='left' valign='top' width='25%'>" + styleHeader + "Last Name</span></th>");
            sbGrid.Append("<th align='left' valign='top' width='20%'>" + styleHeader + "SLT Role</span></th>");
            sbGrid.Append("<th align='left' valign='top' width='20%'>" + styleHeader + "Present</span></th></tr>");
            string First_Name = "", Last_Name = "", Role = "", Present = "No";
            foreach (DataRow dr in DtAttendees.Rows)
            {
                First_Name = Convert.ToString(dr["First_Name"]).Trim();
                Last_Name = Convert.ToString(dr["Last_Name"]).Trim();
                Role = Convert.ToString(dr["SLT_Role"]).Trim();
                if (dr["Present"] != DBNull.Value)
                    Present = Convert.ToBoolean(dr["Present"]) == true ? "Yes" : "No";
                sbGrid.Append("<tr><td align='left' valign='top'><span " + style + First_Name + " </span></td>");
                sbGrid.Append("<td align='left' valign='top'><span " + style + Last_Name + " </span></td>");
                sbGrid.Append("<td align='left' valign='top'><span " + style + Role + " </span></td>");
                sbGrid.Append("<td align='left' valign='top'><span " + style + Present + " </span></td></tr>");
            }
        }
        else
        {
            sbGrid.Append("<tr><td align='left' valign='top' width='100%'><span " + style + "No Records Found </span></td></tr>");
        }
        sbGrid.Append("</table>");
        return sbGrid.ToString();
    }
    private string GetMembersDetails()
    {
        StringBuilder sbGrid = new StringBuilder();
        string style = "style='font-size: 11pt; font-weight: normal;  font-family: Calibri;'>";
        string styleHeader = "<span style='font-family: Calibri;'>";
        sbGrid.Append("<table cellpadding='0' cellspacing='0' border='0' width='100%' align='center'>");
        DataTable DtAttendees = SLT_Members.SLT_MembersSelectByFk(PK_SLT_Meeting, 0,PK_SLT_Meeting_Schedule).Tables[0];
        // DataTable DtAttendees = SLT_Meeting_Attendees.SelectBYFK(PK_SLT_Meeting_Schedule).Tables[0];
        if (DtAttendees.Rows.Count > 0)
        {
            sbGrid.Append("<tr><th align='left' valign='top' width='25%'>" + styleHeader + "First Name</span></th>");
            sbGrid.Append("<th align='left' valign='top' width='25%'>" + styleHeader + "Last Name</span></th>");
            sbGrid.Append("<th align='left' valign='top' width='20%'>" + styleHeader + "SLT Role</span></th>");
            sbGrid.Append("<th align='left' valign='top' width='20%'>" + styleHeader + "Start Date</span></th>");
            sbGrid.Append("<th align='left' valign='top' width='20%'>" + styleHeader + "End Date</span></th></tr>");
            string First_Name = "", Last_Name = "", Role = "", Present = "No";
            foreach (DataRow dr in DtAttendees.Rows)
            {
                First_Name = Convert.ToString(dr["First_Name"]).Trim();
                Last_Name = Convert.ToString(dr["Last_Name"]).Trim();
                Role = Convert.ToString(dr["SLT_Role"]).Trim();
                //if (dr["Present"] != DBNull.Value)
                //    Present = Convert.ToBoolean(dr["Present"]) == true ? "Yes" : "No";
                sbGrid.Append("<tr><td align='left' valign='top'><span " + style + First_Name + " </span></td>");
                sbGrid.Append("<td align='left' valign='top'><span " + style + Last_Name + " </span></td>");
                sbGrid.Append("<td align='left' valign='top'><span " + style + Role + " </span></td>");
                sbGrid.Append("<td align='left' valign='top'><span " + style + clsGeneral.FormatDBNullDateToDisplay(dr["Start_Date"]) + " </span></td>");
                sbGrid.Append("<td align='left' valign='top'><span " + style + clsGeneral.FormatDBNullDateToDisplay(dr["End_Date"]) + " </span></td></tr>");
                //sbGrid.Append("<td align='left' valign='top'><span " + style + Present + " </span></td></tr>");
            }
        }
        else
        {
            sbGrid.Append("<tr><td align='left' valign='top' width='100%'><span " + style + "No Records Found </span></td></tr>");
        }
        sbGrid.Append("</table>");
        return sbGrid.ToString();
    }
    public string GeneratePrintReport(string Print_Email)
    {
        string strFilePath = "";
        if (Print_Email == "Print")
            strFilePath = "SLT_Meeting_minutesPrint.htm";
        else if (Print_Email == "Email")
            strFilePath = "SLT_Meeting_Minutes.htm";
        SLT_Meeting_Schedule objSLT_Meeting_Schedule = new SLT_Meeting_Schedule(PK_SLT_Meeting_Schedule);
        FileStream fsMail = new FileStream(AppConfig.SitePath + @"\Sonic\SLT\" + strFilePath, FileMode.Open, FileAccess.Read);
        StreamReader rd = new StreamReader(fsMail);
        StringBuilder strBody = new StringBuilder(rd.ReadToEnd().ToString());
        rd.Close();
        fsMail.Close();
        LU_Location objLU_Location = new LU_Location(FK_LU_Location_ID);
        strBody = strBody.Replace("[Location_Dba]", objLU_Location.dba);
        strBody = strBody.Replace("[Meeting_Date]", clsGeneral.FormatDBNullDateToDisplay(objSLT_Meeting_Schedule.Actual_Meeting_Date));
        strBody = strBody.Replace("[Attendees_info]", GetAttendeesDetails());
        #region "Call To Order"
        strBody = strBody.Replace("[Meeting_Start_Time]", !string.IsNullOrEmpty(objSLT_Meeting_Schedule.Meeting_Start_Time) ? objSLT_Meeting_Schedule.Meeting_Start_Time : "");
        strBody = strBody.Replace("[Meeting_End_Time]", !string.IsNullOrEmpty(objSLT_Meeting_Schedule.Meeting_End_Time) ? objSLT_Meeting_Schedule.Meeting_End_Time : "");
        #endregion

        #region "Safety Walk"
        SLT_Safety_Walk objSLT_Safety_Walk = new SLT_Safety_Walk(PK_SLT_Meeting_Schedule, true);
        if (objSLT_Safety_Walk.Safety_Walk_Comp != null)
            strBody = strBody = strBody.Replace("[Safety_Walk_Y_N]", Convert.ToBoolean(objSLT_Safety_Walk.Safety_Walk_Comp) == true ? "Yes" : "No");
        else
            strBody = strBody = strBody.Replace("[Safety_Walk_Y_N]", "No");
        strBody = strBody = strBody.Replace("[Date_Completed]", clsGeneral.FormatDBNullDateToDisplay(objSLT_Safety_Walk.Safety_Walk_Comp_Date));
        strBody = strBody = strBody.Replace("[Sales_Y_N]", objSLT_Safety_Walk.Sales_Reviewed == "Y" ? "Yes" : "No");

        strBody = strBody = strBody.Replace("[Sales_Deficiencies]", SetYesNoNone(objSLT_Safety_Walk.Sales_Deficiencies));
        strBody = strBody = strBody.Replace("[Parts_Y_N]", SetYesNoNone(objSLT_Safety_Walk.Parts_Reviewed));
        strBody = strBody = strBody.Replace("[Parts_Deficiencies]", SetYesNoNone(objSLT_Safety_Walk.Parts_Deficiencies));
        strBody = strBody = strBody.Replace("[Service_facility_Y_N]", SetYesNoNone(objSLT_Safety_Walk.Service_Facility_Reviewed));
        strBody = strBody = strBody.Replace("[Service_facility_Deficiencies]", SetYesNoNone(objSLT_Safety_Walk.Service_Deficiencies));
        strBody = strBody = strBody.Replace("[Body_Shop_Y_N]", SetYesNoNone(objSLT_Safety_Walk.Body_Shop_Reviewed));
        strBody = strBody = strBody.Replace("[Body_Shop_Deficiencies]", SetYesNoNone(objSLT_Safety_Walk.Body_Shop_Deficiencies));
        strBody = strBody = strBody.Replace("[Busi_off_Y_N]", SetYesNoNone(objSLT_Safety_Walk.Bus_Off_Reviewed));
        strBody = strBody = strBody.Replace("[Busi_off_Deficiencies]", SetYesNoNone(objSLT_Safety_Walk.Bus_Off_Deficiencies));
        strBody = strBody = strBody.Replace("[Detail_Area_Y_N]", SetYesNoNone(objSLT_Safety_Walk.Detail_Area_Reviewed));
        strBody = strBody = strBody.Replace("[Detail_Area_Deficiencies]", SetYesNoNone(objSLT_Safety_Walk.Detail_Deficiencies));
        strBody = strBody = strBody.Replace("[Car_Lot_Y_N]", SetYesNoNone(objSLT_Safety_Walk.Car_Wash_Reviewed));
        strBody = strBody = strBody.Replace("[Car_lot_Deficiencies]", SetYesNoNone(objSLT_Safety_Walk.Car_Wash_Deficiencies));
        strBody = strBody = strBody.Replace("[Parking_Lot_Y_N]", SetYesNoNone(objSLT_Safety_Walk.Parking_Lot_Reviewed));
        strBody = strBody = strBody.Replace("[Parking_Lot_Deficiencies]", SetYesNoNone(objSLT_Safety_Walk.Parking_Deficiencies));

        strBody = strBody.Replace("[Sales_Comments]", objSLT_Safety_Walk.Sales_Reviewed == "Y" ? AppendSafetyWalkComments(objSLT_Safety_Walk.Sales_Comments) : "");
        strBody = strBody.Replace("[Parts_Comments]", objSLT_Safety_Walk.Parts_Reviewed == "Y" ? AppendSafetyWalkComments(objSLT_Safety_Walk.Parts_Comments) : "");
        strBody = strBody.Replace("[Ser_Fac_Comments]", objSLT_Safety_Walk.Service_Facility_Reviewed == "Y" ? AppendSafetyWalkComments(objSLT_Safety_Walk.Service_Comments) : "");
        strBody = strBody.Replace("[Body_Shop_Comments]", objSLT_Safety_Walk.Body_Shop_Reviewed == "Y" ? AppendSafetyWalkComments(objSLT_Safety_Walk.Body_Shop_Comments) : "");
        strBody = strBody.Replace("[Busi_off_Comments]", objSLT_Safety_Walk.Bus_Off_Reviewed == "Y" ? AppendSafetyWalkComments(objSLT_Safety_Walk.Bus_Off_Comments) : "");
        strBody = strBody.Replace("[Detail_Area_Comments]", objSLT_Safety_Walk.Detail_Area_Reviewed == "Y" ? AppendSafetyWalkComments(objSLT_Safety_Walk.Detail_Comments) : "");
        strBody = strBody.Replace("[Car_Lot_Comments]", objSLT_Safety_Walk.Car_Wash_Reviewed == "Y" ? AppendSafetyWalkComments(objSLT_Safety_Walk.Car_Wash_Comments) : "");
        strBody = strBody.Replace("[Parking_Lot_Comments]", objSLT_Safety_Walk.Parking_Lot_Reviewed == "Y" ? AppendSafetyWalkComments(objSLT_Safety_Walk.Parking_Comments) : "");
        ResizeAllImages(Convert.ToDecimal(objSLT_Safety_Walk.PK_SLT_Safety_Walk), "SLT_Safety_Walk");
        strBody = strBody.Replace("[Safety_WalkAttachment]", objSLT_Safety_Walk.PK_SLT_Safety_Walk != null ? GetAttachmetHTML("SLT_Safety_Walk", Convert.ToDecimal(objSLT_Safety_Walk.PK_SLT_Safety_Walk)) : "");
        #endregion



        #region "Quarterly Facility Inspections"
        int intQuarter = objSLT_Meeting_Schedule.Actual_Meeting_Date != null ? clsGeneral.GetQuarterFromDate(objSLT_Meeting_Schedule.Actual_Meeting_Date) : 1;
        int intYear = objSLT_Meeting_Schedule.Actual_Meeting_Date != null ? Convert.ToInt32(Convert.ToDateTime(objSLT_Meeting_Schedule.Actual_Meeting_Date).Year) : Convert.ToInt32(DateTime.Now.Year);
        int Defeciencies_Count = 0;
        StringBuilder sbTemp = new StringBuilder();
        DateTime? Actual_meeting_Date = null;
        if (objSLT_Meeting_Schedule.Actual_Meeting_Date != null)
            Actual_meeting_Date = Convert.ToDateTime(objSLT_Meeting_Schedule.Actual_Meeting_Date);
        DataTable dtInspection = SLT_Quarterly_Inspections.SelectQuarterlyInspections(FK_LU_Location_ID, intQuarter, intYear, Actual_meeting_Date).Tables[0];
        if (dtInspection.Rows.Count > 0)
        {
            string styleHeader = "<span style='font-family: Calibri;'>";
            sbTemp.Append("<table cellpadding='0' cellspacing='0' border='0' width='100%' align='center'>");
            sbTemp.Append("<tr><th align='left' valign='bottom' width='20%'>" + styleHeader + "Focus Area</span></th>");
            sbTemp.Append("<th align='left' valign='bottom' width='35%'>" + styleHeader + " Question</span></th>");
            sbTemp.Append("<th align='left' valign='bottom' width='20%'>" + styleHeader + "Date Opened</span></th>");
            sbTemp.Append("<th align='left' valign='bottom' width='25%'>" + styleHeader + "Department</span></th></tr>");
            foreach (DataRow gr in dtInspection.Rows)
            {
                Defeciencies_Count = (Convert.ToInt32(gr["Deficiencies"]) + Defeciencies_Count);
                sbTemp.Append(GenerateQuaterltInspection(gr["PK_Inspection_ID"] != DBNull.Value ? Convert.ToDecimal(gr["PK_Inspection_ID"]) : 0));
            }
            sbTemp.Append("</table>");
        }
        else
        {
            strBody.Replace("[Quarterly_Inspection]", "No records Found");
            strBody = strBody.Replace("[No_Deficiencies]", string.Empty);
        }
        strBody = strBody.Replace("[Quarterly_Inspection]", sbTemp.ToString());
        strBody = strBody.Replace("[No_Deficiencies]", Defeciencies_Count.ToString());
        string Sonic_Location_Code = Convert.ToString(objLU_Location.Sonic_Location_Code);
        string DBA = objLU_Location.dba;
        int Year = Convert.ToInt32(DateTime.Now.Year);
        DataSet dsDetail = Charts.GetFacilityInspectionDetail(Year, DBA, Sonic_Location_Code);
        if (dsDetail.Tables[0].Rows.Count > 0)
        {
            strBody = strBody.Replace("[Dealership_Playbook_Score]", Convert.ToString(dsDetail.Tables[0].Rows[0]["Score"]));
        }
        else
            strBody = strBody.Replace("[Dealership_Playbook_Score]", "");
        #endregion
        string Incident_Year = Convert.ToString(DateTime.Now.Year);
        string Incident_Month = Convert.ToString(DateTime.Now.Month);
        if (objSLT_Meeting_Schedule.Actual_Meeting_Date != null) Incident_Year = (Convert.ToDateTime(objSLT_Meeting_Schedule.Actual_Meeting_Date).Year).ToString();
        if (objSLT_Meeting_Schedule.Actual_Meeting_Date != null) Incident_Month = (Convert.ToDateTime(objSLT_Meeting_Schedule.Actual_Meeting_Date).Month).ToString();
        if (Print_Email == "Email")
        {
            #region "Incident_review"
            strBody = strBody.Replace("[Incident_year]", Incident_Year);
            strBody = strBody.Replace("[Incident_Month]", getMonth(Incident_Month));
            strBody = strBody.Replace("[WC_INFO]", GetFRIncidentDetails("WC_FR", Incident_Year, Incident_Month));
            //strBody = strBody.Replace("[AL_INFO]", GetFRIncidentDetails("AL_FR", Incident_Year, Incident_Month));
            //strBody = strBody.Replace("[PL_INFO]", GetFRIncidentDetails("PL_FR", Incident_Year, Incident_Month));
            //strBody = strBody.Replace("[DPD_INFO]", GetFRIncidentDetails("DPD_FR", Incident_Year, Incident_Month));
            //strBody = strBody.Replace("[Property_Info]", GetFRIncidentDetails("Property_FR", Incident_Year, Incident_Month));
            #endregion

            #region "Claim_management"
            string Region = objLU_Location.Region;
            DataSet dsReport = Charts.GetWCClaimMgmtByLocation(Year, Region);
            DataTable dtReport = dsReport.Tables[0];
            if (dtReport.Rows.Count > 0)
            {
                int Score = Convert.ToInt32(dtReport.Rows[0]["Score"]);
                switch (Score)
                {
                    case 4: strBody = strBody.Replace("[CM_Score]", Charts.Tin_Label); break;
                    case 10: strBody = strBody.Replace("[CM_Score]", Charts.Bronze_Label); break;
                    case 16: strBody = strBody.Replace("[CM_Score]", Charts.Silver_Label); break;
                    case 22: strBody = strBody.Replace("[CM_Score]", Charts.Gold_Label); break;
                    case 28: strBody = strBody.Replace("[CM_Score]", Charts.Platinum_Label); break;
                }
            }
            else
                strBody = strBody.Replace("[CM_Score]", Charts.Platinum_Label);
            strBody = strBody.Replace("[Claim_management_Info]", getCliamManagementDetails(Incident_Year, Incident_Month));
            //SLT_Claims_Management objSLT_Claims_Management = new SLT_Claims_Management(PK_SLT_Meeting,0,true);
            //strBody = strBody.Replace("[Lag_Explaination]", objSLT_Claims_Management.Lag_Explaination != null ? objSLT_Claims_Management.Lag_Explaination : "");
            //strBody = strBody.Replace("[Associate_Status]", objSLT_Claims_Management.FK_LU_Work_Status != null ? new LU_Work_Status((decimal)objSLT_Claims_Management.FK_LU_Work_Status).Fld_Desc : "");
            //strBody = strBody.Replace("[Light_Duty_Explain]", objSLT_Claims_Management.Light_Duty_Explaination != null ? objSLT_Claims_Management.Light_Duty_Explaination : "");
            //strBody = strBody.Replace("[CM_Comments]", objSLT_Claims_Management.Comments != null ? objSLT_Claims_Management.Comments : "");
            #endregion
        }

        #region "Sonic University training"
        int intYearTraining = Convert.ToInt32(Incident_Year);

        DataTable dtResult = Charts.GetSabaTrainingDetail_New(Convert.ToInt32(intYearTraining), DBA).Tables[0]; ;

        if (dtResult != null && dtResult.Rows.Count > 0)
        {
            DataRow[] drQ1 = dtResult.Select("AssociateQuarter = '1'");
            if (drQ1.Length > 0)
            {
                if (!string.IsNullOrEmpty(drQ1[0]["Percentage"].ToString()))
                    strBody = strBody.Replace("[Q1_Score]", Convert.ToString(drQ1[0]["Percentage"]) + "%");
            }

            DataRow[] drQ2 = dtResult.Select("AssociateQuarter = '2'");
            if (drQ2.Length > 0)
            {
                if (!string.IsNullOrEmpty(drQ2[0]["Percentage"].ToString()))
                    strBody = strBody.Replace("[Q2_Score]", Convert.ToString(drQ2[0]["Percentage"]) + "%");
            }

            DataRow[] drQ3 = dtResult.Select("AssociateQuarter = '3'");
            if (drQ3.Length > 0)
            {
                if (!string.IsNullOrEmpty(drQ3[0]["Percentage"].ToString()))
                    strBody = strBody.Replace("[Q3_Score]", Convert.ToString(drQ3[0]["Percentage"]) + "%");
            }

            DataRow[] drQ4 = dtResult.Select("AssociateQuarter = '4'");
            if (drQ4.Length > 0)
            {
                if (!string.IsNullOrEmpty(drQ4[0]["Percentage"].ToString()))
                    strBody = strBody.Replace("[Q4_Score]", Convert.ToString(drQ4[0]["Percentage"]) + "%");
            }
        }
        strBody = strBody.Replace("[Sonic_training_info]", GetSonicTrainigDetails());

        #endregion

        #region "New procedure"
        strBody = strBody.Replace("[Procedure_Info]", GetNewProcedureDetails(Incident_Year));
        #endregion

        #region "Suggestion"
        strBody = strBody.Replace("[Suggestion_info]", GetSuggestionDetails());
        #endregion

        #region "Meeting Review"
        string strNext_Meeting = "", strMeeting_Place = "", strNext_meeting_Time = "";
        DataTable dtNextMeeting = SLT_Meeting_Schedule.SelectNextMeeting(PK_SLT_Meeting_Schedule, PK_SLT_Meeting).Tables[0];
        if (dtNextMeeting.Rows.Count > 0)
        {
            strNext_Meeting = clsGeneral.FormatDBNullDateToDisplay(dtNextMeeting.Rows[0]["Scheduled_Meeting_Date"]);
            strMeeting_Place = dtNextMeeting.Rows[0]["Meeting_Place"].ToString();
            strNext_meeting_Time = dtNextMeeting.Rows[0]["Scheduled_Meeting_Time"].ToString();
        }
        strBody = strBody.Replace("[Next_meeting]", strNext_Meeting);
        strBody = strBody.Replace("[Meeting_Place]", strMeeting_Place);
        strBody = strBody.Replace("[Next_Meeting_Time]", strNext_meeting_Time);
        #endregion
        return strBody.ToString();
    }

    public string GeneratePrintReport_New(string Print_Email, bool IsOutlookAttachment)
    {
        string strFilePath = "";
        if (Print_Email == "Print")
            strFilePath = "SLT_Meeting_minutesPrint_New.htm";
        else if (Print_Email == "Email")
            strFilePath = "SLT_Meeting_minutesPrint_New.htm";
        SLT_Meeting_Schedule objSLT_Meeting_Schedule = new SLT_Meeting_Schedule(PK_SLT_Meeting_Schedule);
        FileStream fsMail = new FileStream(AppConfig.SitePath + @"\Sonic\SLT\" + strFilePath, FileMode.Open, FileAccess.Read);
        StreamReader rd = new StreamReader(fsMail);
        StringBuilder strBody = new StringBuilder(rd.ReadToEnd().ToString());
        rd.Close();
        fsMail.Close();
        LU_Location objLU_Location = new LU_Location(FK_LU_Location_ID);
        strBody = strBody.Replace("[Location_Dba]", objLU_Location.dba);
        strBody = strBody.Replace("[Meeting_Date]", clsGeneral.FormatDBNullDateToDisplay(objSLT_Meeting_Schedule.Actual_Meeting_Date));
        strBody = strBody.Replace("[Attendees_info]", GetAttendeesDetails());
        #region "Call To Order"
        strBody = strBody.Replace("[Meeting_Start_Time]", !string.IsNullOrEmpty(objSLT_Meeting_Schedule.Meeting_Start_Time) ? objSLT_Meeting_Schedule.Meeting_Start_Time : "");
        strBody = strBody.Replace("[Meeting_End_Time]", !string.IsNullOrEmpty(objSLT_Meeting_Schedule.Meeting_End_Time) ? objSLT_Meeting_Schedule.Meeting_End_Time : "");
        #endregion

        #region "Safety Walk Open Observation"

        int intMonth = Convert.ToInt32(DateTime.Now.Month);
        int iYear = Convert.ToInt32(DateTime.Now.Year);

        if (objSLT_Meeting_Schedule.Actual_Meeting_Date != null)
        {
            intMonth = Convert.ToInt32(Convert.ToDateTime(objSLT_Meeting_Schedule.Actual_Meeting_Date).Month);
            iYear = Convert.ToInt32(Convert.ToDateTime(objSLT_Meeting_Schedule.Actual_Meeting_Date).Year);
        }
        else if (objSLT_Meeting_Schedule.Scheduled_Meeting_Date != null)
        {
            intMonth = Convert.ToInt32(Convert.ToDateTime(objSLT_Meeting_Schedule.Scheduled_Meeting_Date).Month);
            iYear = Convert.ToInt32(Convert.ToDateTime(objSLT_Meeting_Schedule.Scheduled_Meeting_Date).Year);
        }

        //Append Only for Outlook Attachments
        if (IsOutlookAttachment)
        {
            strBody = strBody.Replace("[For_the_month]", "for the Month of " + getMonth(Convert.ToString(intMonth)));
        }
        else
        {
            strBody = strBody.Replace("[For_the_month]", "");
        }

        StringBuilder sbtbl = new StringBuilder();
        //DataTable dtOpenObservation = LU_SLT_Safety_Walk_Focus_Area.GetSLTSafetyWalkOpenObservation(objSLT_Meeting_Schedule.FK_SLT_Meeting.Value, intMonth, objSLT_Meeting_Schedule.PK_SLT_Meeting_Schedule.Value, iYear, false).Tables[0];
        DataSet dsNewOpenObservation = LU_SLT_Safety_Walk_Focus_Area.SelectSafteyWalkLetterData(iYear, getMonth(Convert.ToString(intMonth)), objSLT_Meeting_Schedule.PK_SLT_Meeting_Schedule.Value);
        DataTable dtNewOpenObservation = dsNewOpenObservation.Tables[0];
        DataTable dtDepartmentofObservation = dsNewOpenObservation.Tables[1];
        DataTable dtObservationAttachment = dsNewOpenObservation.Tables[2];
        if (dtNewOpenObservation.Rows.Count > 0)
        {
            //string styleHeader = "<span style='font-family: Calibri;'>";
            string style = "<span style='font-size: 11pt; font-family: Calibri'>";
            sbtbl.Append("<table cellpadding='0' cellspacing='0' border='0' width='100%' align='center'>");
            DataTable dtQuestionOfOpenObservation = LU_SLT_Safety_Walk_Focus_Area.GetQuestions_OfOpenObservation(intMonth, objSLT_Meeting_Schedule.PK_SLT_Meeting_Schedule.Value, iYear).Tables[0];
            foreach (DataRow dr in dtNewOpenObservation.Rows)
            {
                sbtbl.Append("<tr><td style='width: 30%' align='left' >" + style + "<b>Question" + Convert.ToString(dr["Sort_Order"]) + " </b></span> </td>" +
                                "<td style='width: 2%' align='center'>" + style + ":</span> </td>" +
                                "<td style='width: 68%' align='left' colspan='4'>" + style + "<b>" + Convert.ToString(dr["Status"]) + "</b></span>" + "</td>" +
                              " </tr><tr>" +
                                  "<td style='width: 30%' align='left' >" + style + "Focus Area</span></td>" +
                                  "<td style='width: 2%' align='center'>" + style + ":</span> </td>" +
                                  "<td style='width: 68%' align='left' colspan='4'>" + style + Convert.ToString(dr["Focus_Area"]) + "</span>" + "</td>" +
                              "</tr>" +
                              "<tr>" +
                                  "<td style='width: 30%' align='left' valign='top'>" + style + "Question " + Convert.ToString(dr["Sort_Order"]) + "</span>" + " </td>" +
                                  "<td style='width: 2%' align='center' valign='top'>" + style + ":</span></td>" +
                                  "<td style='width: 68%' align='left' colspan='4'>" + style + Convert.ToString(dr["Question"]) + "</span>" + "</td>" +
                              "</tr>" +
                              "<tr>" +
                                  "<td style='width: 30%' align='left'>" + style + "a.Show Sonic Guidance?</span></td>" +
                                  "<td style='width: 2%' align='center'>" + style + ":</span> </td>" +
                                  "<td style='width: 68%' align='left' colspan='4'>" + style + "Yes</span>" + " </td>" +
                             " </tr>"
                             );
                //if rblGuidance == Y  not getting in db
                sbtbl.Append("  <tr>" +
                                       " <td style='width: 30%' align='left' valign='top'>" + style + "Guidance</span></td>" +
                                        "<td style='width: 2%' align='center' valign='top'>" + style + ":</span> </td>" +
                                        "<td style='width: 68%' align='left' colspan='4'>" + style + Convert.ToString(dr["Guidance"]) + "</span>" + "</td>" +
                                    "</tr>" +
                                   " <tr>" +
                                       " <td style='width: 30%' align='left' valign='top'>" + style + "Reference</span></td>" +
                                        "<td style='width: 2%' align='center' valign='top'>" + style + ":</span> </td>" +
                                        "<td style='width: 68%' align='left' colspan='4'>" + style + Convert.ToString(dr["Reference"]) + "</span>" + "</td>" +
                                    "</tr>");
                string strDepartmentList = string.Empty;
                foreach (DataRow drDepartment in dtDepartmentofObservation.Select("PK_SLT_Safety_Walk_Responses =" + Convert.ToString(dr["PK_SLT_Safety_Walk_Responses"])))
                {
                    if (string.IsNullOrEmpty(strDepartmentList)) strDepartmentList = Convert.ToString(drDepartment["Department"]);
                    else strDepartmentList = strDepartmentList + ", " + Convert.ToString(drDepartment["Department"]);
                }
                sbtbl.Append(" <tr>" +
                                 " <td style='width: 30%' align='left' valign='top'>" + style + "b. Departments Observed</span></td>" +
                                  "<td style='width: 2%' align='center' valign='top'>" + style + ":</span></td>" +
                                 " <td style='width: 68%' align='left' colspan='4'>" + style + strDepartmentList + " </span></td>"
                             + "</tr>");

                sbtbl.Append("    <tr>" +
                                  "  <td style='width: 30%' align='left'>" + style + "c. Is the Observation Acceptable?</span></td>" +
                                   " <td style='width: 2%' align='center'>" + style + ":</span> </td>" +
                                   " <td style='width: 68%' align='left' colspan='4'>" + style + Convert.ToString(dr["Observation_Acceptable"]) + "</span>" + "</td>" +
                               " </tr>");
                if (Convert.ToString(dr["Observation_Acceptable"]) == "No") //rblObservation =="N"
                {
                    sbtbl.Append("<tr>" +
                                            "<td style='width: 30%' align='left' valign='top'>" + style + "What Needs to be done?</span></td>" +
                                            "<td style='width: 2%' align='center' valign='top'>" + style + ":</span> </td>" +
                                            "<td style='width: 68%' align='left' colspan='4'>" + style + clsGeneral.ReplaceSpaceAndNewLine(Convert.ToString(dr["What_Needs_To_Be_Done"])) + "</span>" + "</td>" +
                                 "</tr>");
                }

                sbtbl.Append("<tr>" +
                                        " <td style='width: 30%' align='left'>" + style + "Add a picture or document?</span></td>" +
                                        "<td style='width: 2%' align='center'>" + style + ":</span> </td>" +
                                        "<td style='width: 68%' align='left' colspan='4'>" + style + Convert.ToString(dr["Add a Picture or Document?"]) + "</span>" + "</td>" +
                             "</tr>");

                if (Convert.ToString(dr["Observation_Acceptable"]) == "No") //rblObservation =="N"
                {
                    sbtbl.Append("<tr>" +
                                        "<td style='width: 30%' align='left' valign='top'>" + style + "Assigned to SLT Member</span></td>" +
                                        "<td style='width: 2%' align='center' valign='top'>" + style + ":</span> </td>" +
                                        "<td style='width: 68%' align='left' colspan='4'>" + style + Convert.ToString(dr["SLT_Member"]) + "</span>" + "</td>" +
                                 "</tr>" +
                                 "<tr>" +
                                        " <td style='width: 30%' align='left' valign='top'>" + style + "To Be Completed By</span></td>" +
                                        " <td style='width: 2%' align='center' valign='top'>" + style + ": </span></td>" +
                                        "<td style='width: 68%' align='left' colspan='4'>" + style + Convert.ToString(dr["To_Be_Completed_By"]) + "</span>" + " </td>" +
                                 "</tr>" +
                                 "<tr>" +
                                         "<td style='width: 30%' align='left' valign='top'>" + style + "Completion Date</span></td>" +
                                         " <td style='width: 2%' align='center' valign='top'>" + style + ":</span> </td>" +
                                         "<td style='width: 68%' align='left' colspan='4'>" + style + Convert.ToString(dr["Completed_Date"]) + "</span>" + "</td>" +
                                  "</tr>");
                }

                if (Convert.ToString(dr["Add a Picture or Document?"]) == "Yes")
                {
                    DataView dv = new DataView(dtObservationAttachment);
                    dv.RowFilter = "FK_SLT_Safety_Walk_Responses =" + Convert.ToString(dr["PK_SLT_Safety_Walk_Responses"]);

                    sbtbl.Append("<tr>" + "<td align='left' colspan='6'>" + style + "Attachments</span>" + GetOpenObservationAttachmetHTML(dv.ToTable()) + "</td>" +"</tr>");
                }
                sbtbl.Append("<tr><td colspan='4'>&nbsp;</td></tr>");
                //sbtbl.Append("<tr><th align='left' valign='bottom' width='20%'>" + styleHeader + "Month</span></th>");
                //sbtbl.Append("<th align='left' valign='bottom' width='20%'>" + styleHeader + "Focus Area</span></th>");
                //sbtbl.Append("<th align='left' valign='bottom' width='20%'>" + styleHeader + "Date Completed</span></th>");
                //sbtbl.Append("<th align='left' valign='bottom' width='35%'>" + styleHeader + " Observations Open</span></th></tr>");

                //string style = "<span style='font-size: 11pt; font-family: Calibri'>";
                //sbtbl.Append("<tr><td align='left' valign='top'>" + style + Convert.ToString(dr["Month"]) + "</span></td>");
                //sbtbl.Append("<td align='left' valign='top'>" + style + Convert.ToString(dr["Focus_Area"]) + "</span></td>");
                //sbtbl.Append("<td align='left' valign='top'>" + style + clsGeneral.FormatDBNullDateToDisplay(dr["Safety_Walk_Comp_Date"]) + "</span></td>");
                //sbtbl.Append("<td align='left' valign='top'>" + style + Convert.ToString(dr["Observations_Open"]) + "</span></td>");
                //sbtbl.Append("</tr>");

                //#region Bind Questions
                //sbtbl.Append("<tr><th align='left' valign='bottom' colspan='4'>" + styleHeader + "Questions</th></tr>");
                //DataTable dtQuestionOfOpenObservation = LU_SLT_Safety_Walk_Focus_Area.GetQuestions_OfOpenObservation(intMonth, objSLT_Meeting_Schedule.PK_SLT_Meeting_Schedule.Value, iYear).Tables[0];
                //sbtbl.Append("<tr><td colspan='4'><table cellpadding='0' cellspacing='0' border='0' width='100%' align='center'>");
                //foreach (DataRow drQue in dtQuestionOfOpenObservation.Rows)
                //{
                //    sbtbl.Append("<tr><td align='left' valign='top'>" + style + Convert.ToString(drQue["Sort_Order"]) + "</span></td>");
                //    sbtbl.Append("<td align='left' valign='top'>" + style + Convert.ToString(drQue["Question"]) + "</span></td>");
                //    sbtbl.Append("</tr>");
                //}
                // sbtbl.Append("</table></td></tr>");
                // #endregion

            }
            sbtbl.Append("<tr><td colspan='4'>&nbsp;</td></tr>");
            sbtbl.Append("</table>");
        }
        else
        {
            strBody.Replace("[SafetyWalk_Observation]", "No records Found");
        }
        strBody = strBody.Replace("[SafetyWalk_Observation]", sbtbl.ToString());
        #endregion

        #region "Quarterly Facility Inspections"
        int intQuarter = objSLT_Meeting_Schedule.Actual_Meeting_Date != null ? clsGeneral.GetQuarterFromDate(objSLT_Meeting_Schedule.Actual_Meeting_Date) : 1;
        int intYear = objSLT_Meeting_Schedule.Actual_Meeting_Date != null ? Convert.ToInt32(Convert.ToDateTime(objSLT_Meeting_Schedule.Actual_Meeting_Date).Year) : Convert.ToInt32(DateTime.Now.Year);
        int Defeciencies_Count = 0;
        StringBuilder sbTemp = new StringBuilder();
        DateTime? Actual_meeting_Date = null;
        if (objSLT_Meeting_Schedule.Actual_Meeting_Date != null)
            Actual_meeting_Date = Convert.ToDateTime(objSLT_Meeting_Schedule.Actual_Meeting_Date);
        DataTable dtInspection = SLT_Quarterly_Inspections.SelectQuarterlyInspections(FK_LU_Location_ID, intQuarter, intYear, Actual_meeting_Date).Tables[0];
        if (dtInspection.Rows.Count > 0)
        {
            string styleHeader = "<span style='font-family: Calibri;'>";
            sbTemp.Append("<table cellpadding='0' cellspacing='0' border='0' width='100%' align='center'>");
            sbTemp.Append("<tr><th align='left' valign='bottom' width='20%'>" + styleHeader + "Focus Area</span></th>");
            sbTemp.Append("<th align='left' valign='bottom' width='35%'>" + styleHeader + " Question</span></th>");
            sbTemp.Append("<th align='left' valign='bottom' width='20%'>" + styleHeader + "Date Opened</span></th>");
            sbTemp.Append("<th align='left' valign='bottom' width='25%'>" + styleHeader + "Department</span></th></tr>");
            foreach (DataRow gr in dtInspection.Rows)
            {
                Defeciencies_Count = (Convert.ToInt32(gr["Deficiencies"]) + Defeciencies_Count);
                sbTemp.Append(GenerateQuaterltInspection(gr["PK_Inspection_ID"] != DBNull.Value ? Convert.ToDecimal(gr["PK_Inspection_ID"]) : 0));
            }
            sbTemp.Append("</table>");
        }
        else
        {
            strBody.Replace("[Quarterly_Inspection]", "No records Found");
            strBody = strBody.Replace("[No_Deficiencies]", string.Empty);
        }
        strBody = strBody.Replace("[Quarterly_Inspection]", sbTemp.ToString());
        strBody = strBody.Replace("[No_Deficiencies]", Defeciencies_Count.ToString());
        string Sonic_Location_Code = Convert.ToString(objLU_Location.Sonic_Location_Code);
        string DBA = objLU_Location.dba;
        int Year = Convert.ToInt32(DateTime.Now.Year);
        DataSet dsDetail = Charts.GetFacilityInspectionDetail(Year, DBA, Sonic_Location_Code);
        if (dsDetail.Tables[0].Rows.Count > 0)
        {
            strBody = strBody.Replace("[Dealership_Playbook_Score]", Convert.ToString(dsDetail.Tables[0].Rows[0]["Score"]));
        }
        else
            strBody = strBody.Replace("[Dealership_Playbook_Score]", "");
        #endregion
        string Incident_Year = Convert.ToString(DateTime.Now.Year);
        string Incident_Month = Convert.ToString(DateTime.Now.Month);
        if (objSLT_Meeting_Schedule.Actual_Meeting_Date != null) Incident_Year = (Convert.ToDateTime(objSLT_Meeting_Schedule.Actual_Meeting_Date).Year).ToString();
        if (objSLT_Meeting_Schedule.Actual_Meeting_Date != null) Incident_Month = (Convert.ToDateTime(objSLT_Meeting_Schedule.Actual_Meeting_Date).Month).ToString();
        if (Print_Email == "Email")
        {
            #region "Incident_review"
            strBody = strBody.Replace("[Incident_year]", Incident_Year);
            strBody = strBody.Replace("[Incident_Month]", getMonth(Incident_Month));
            strBody = strBody.Replace("[WC_INFO]", GetFRIncidentDetails("WC_FR", Incident_Year, Incident_Month));
            //strBody = strBody.Replace("[AL_INFO]", GetFRIncidentDetails("AL_FR", Incident_Year, Incident_Month));
            //strBody = strBody.Replace("[PL_INFO]", GetFRIncidentDetails("PL_FR", Incident_Year, Incident_Month));
            //strBody = strBody.Replace("[DPD_INFO]", GetFRIncidentDetails("DPD_FR", Incident_Year, Incident_Month));
            //strBody = strBody.Replace("[Property_Info]", GetFRIncidentDetails("Property_FR", Incident_Year, Incident_Month));
            #endregion

            #region "Claim_management"
            string Region = objLU_Location.Region;
            DataSet dsReport = Charts.GetWCClaimMgmtByLocation(Year, Region);
            DataTable dtReport = dsReport.Tables[0];
            if (dtReport.Rows.Count > 0)
            {
                int Score = Convert.ToInt32(dtReport.Rows[0]["Score"]);
                switch (Score)
                {
                    case 4: strBody = strBody.Replace("[CM_Score]", Charts.Tin_Label); break;
                    case 10: strBody = strBody.Replace("[CM_Score]", Charts.Bronze_Label); break;
                    case 16: strBody = strBody.Replace("[CM_Score]", Charts.Silver_Label); break;
                    case 22: strBody = strBody.Replace("[CM_Score]", Charts.Gold_Label); break;
                    case 28: strBody = strBody.Replace("[CM_Score]", Charts.Platinum_Label); break;
                }
            }
            else
                strBody = strBody.Replace("[CM_Score]", Charts.Platinum_Label);
            strBody = strBody.Replace("[Claim_management_Info]", getCliamManagementDetails(Incident_Year, Incident_Month));
            //SLT_Claims_Management objSLT_Claims_Management = new SLT_Claims_Management(PK_SLT_Meeting,0,true);
            //strBody = strBody.Replace("[Lag_Explaination]", objSLT_Claims_Management.Lag_Explaination != null ? objSLT_Claims_Management.Lag_Explaination : "");
            //strBody = strBody.Replace("[Associate_Status]", objSLT_Claims_Management.FK_LU_Work_Status != null ? new LU_Work_Status((decimal)objSLT_Claims_Management.FK_LU_Work_Status).Fld_Desc : "");
            //strBody = strBody.Replace("[Light_Duty_Explain]", objSLT_Claims_Management.Light_Duty_Explaination != null ? objSLT_Claims_Management.Light_Duty_Explaination : "");
            //strBody = strBody.Replace("[CM_Comments]", objSLT_Claims_Management.Comments != null ? objSLT_Claims_Management.Comments : "");
            #endregion
        }

        #region "Sonic University training"
        int intYearTraining = Convert.ToInt32(Incident_Year);

        DataTable dtResult = Charts.GetSabaTrainingDetail_New(Convert.ToInt32(intYearTraining), DBA).Tables[0]; ;

        if (dtResult != null && dtResult.Rows.Count > 0)
        {
            DataRow[] drQ1 = dtResult.Select("AssociateQuarter = '1'");
            if (drQ1.Length > 0)
            {
                if (!string.IsNullOrEmpty(drQ1[0]["Percentage"].ToString()))
                    strBody = strBody.Replace("[Q1_Score]", Convert.ToString(drQ1[0]["Percentage"]) + "%");
            }

            DataRow[] drQ2 = dtResult.Select("AssociateQuarter = '2'");
            if (drQ2.Length > 0)
            {
                if (!string.IsNullOrEmpty(drQ2[0]["Percentage"].ToString()))
                    strBody = strBody.Replace("[Q2_Score]", Convert.ToString(drQ2[0]["Percentage"]) + "%");
            }

            DataRow[] drQ3 = dtResult.Select("AssociateQuarter = '3'");
            if (drQ3.Length > 0)
            {
                if (!string.IsNullOrEmpty(drQ3[0]["Percentage"].ToString()))
                    strBody = strBody.Replace("[Q3_Score]", Convert.ToString(drQ3[0]["Percentage"]) + "%");
            }

            DataRow[] drQ4 = dtResult.Select("AssociateQuarter = '4'");
            if (drQ4.Length > 0)
            {
                if (!string.IsNullOrEmpty(drQ4[0]["Percentage"].ToString()))
                    strBody = strBody.Replace("[Q4_Score]", Convert.ToString(drQ4[0]["Percentage"]) + "%");
            }
        }
        strBody = strBody.Replace("[Sonic_training_info]", GetSonicTrainigDetails());

        #endregion

        #region "New procedure"
        strBody = strBody.Replace("[Procedure_Info]", GetNewProcedureDetails(Incident_Year));
        #endregion

        #region "Suggestion"
        strBody = strBody.Replace("[Suggestion_info]", GetSuggestionDetails());
        #endregion

        #region "Meeting Review"

        string strNext_Meeting = "", strMeeting_Place = "", strNext_meeting_Time = "", strActualMeetingDate="";
        int intNextMonth = 0, iNextYear = 0;
        DataTable dtNextMeeting = SLT_Meeting_Schedule.SelectNextMeeting(PK_SLT_Meeting_Schedule, PK_SLT_Meeting).Tables[0];
        if (dtNextMeeting.Rows.Count > 0)
        {
            strNext_Meeting = clsGeneral.FormatDBNullDateToDisplay(dtNextMeeting.Rows[0]["Scheduled_Meeting_Date"]);
            strMeeting_Place = dtNextMeeting.Rows[0]["Meeting_Place"].ToString();
            strNext_meeting_Time = dtNextMeeting.Rows[0]["Scheduled_Meeting_Time"].ToString();
            strActualMeetingDate = Convert.ToString(dtNextMeeting.Rows[0]["Actual_Meeting_Date"]);

            if (!string.IsNullOrEmpty(strActualMeetingDate))
            {
                intNextMonth = Convert.ToInt32(Convert.ToDateTime(dtNextMeeting.Rows[0]["Actual_Meeting_Date"]).Month);
                iNextYear = Convert.ToInt32(Convert.ToDateTime(dtNextMeeting.Rows[0]["Actual_Meeting_Date"]).Year);
            }
            else if (!string.IsNullOrEmpty(strNext_Meeting))
            {
                intNextMonth = Convert.ToInt32(Convert.ToDateTime(dtNextMeeting.Rows[0]["Scheduled_Meeting_Date"]).Month);
                iNextYear = Convert.ToInt32(Convert.ToDateTime(dtNextMeeting.Rows[0]["Scheduled_Meeting_Date"]).Year);
            }
        }
        strBody = strBody.Replace("[Next_meeting]", strNext_Meeting);
        strBody = strBody.Replace("[Meeting_Place]", strMeeting_Place);
        strBody = strBody.Replace("[Next_Meeting_Time]", strNext_meeting_Time);

        #endregion

        #region "Safety Walk Questions for Next Month"
        IsOutlookAttachment = true;
        if (IsOutlookAttachment)
        {
            StringBuilder sbSafetyWalkForNextMonth = new StringBuilder();
            sbSafetyWalkForNextMonth.Append("<tr style='page-break-inside: avoid'><td style='background-color: #601F1F; color: white' align='left' valign='middle' colspan='3'>" +
                                "<span style='font-size: 11pt; font-weight: bold; font-family: Calibri'> Safety Walk Questions for the Month of " + getMonth(Convert.ToString(intNextMonth)) + "</span></td></tr>");

            sbSafetyWalkForNextMonth.Append("<tr style='page-break-inside: avoid'><td width='5%'> &nbsp;</td><td align='center'>");

            if (!string.IsNullOrEmpty(strNext_Meeting))
            {
                DataSet dsQuestions = LU_SLT_Safety_Walk_Focus_Area.GetSLTQuestionsFromMonthAndYear(getMonth(Convert.ToString(intNextMonth)), iNextYear);
                DataTable dtQuestions = dsQuestions.Tables[0];

                string style = "<span style='font-size: 11pt; font-family: Calibri'>";
                if (dtQuestions.Rows.Count > 0 && dtQuestions != null)
                {
                    sbSafetyWalkForNextMonth.Append("<table cellpadding='0' cellspacing='0' border='0' width='100%' align='center'>");

                    foreach (DataRow dr in dtQuestions.Rows)
                    {
                        sbSafetyWalkForNextMonth.Append("<tr style='page-break-inside: avoid'>" +
                                          "<td style='width: 30%' align='left' >" + style + "Focus Area</span></td>" +
                                          "<td style='width: 2%' align='center'>" + style + ":</span> </td>" +
                                          "<td style='width: 68%' align='left' colspan='4'>" + style + Convert.ToString(dr["Focus_Area"]) + "</span>" + "</td>" +
                                      "</tr>" +
                                      "<tr style='page-break-inside: avoid'>" +
                                          "<td style='width: 30%' align='left' valign='top'>" + style + "Question " + Convert.ToString(dr["Sort_Order"]) + "</span>" + " </td>" +
                                          "<td style='width: 2%' align='center' valign='top'>" + style + ":</span></td>" +
                                          "<td style='width: 68%' align='left' colspan='4'>" + style + Convert.ToString(dr["Question"]) + "</span>" + "</td>" +
                                      "</tr>");

                        sbSafetyWalkForNextMonth.Append("<tr style='page-break-inside: avoid'>" +
                                               " <td style='width: 30%' align='left' valign='top'>" + style + "Guidance</span></td>" +
                                                "<td style='width: 2%' align='center' valign='top'>" + style + ":</span> </td>" +
                                                "<td style='width: 68%' align='left' colspan='4'>" + style + Convert.ToString(dr["Guidance"]) + "</span>" + "</td>" +
                                            "</tr>" +
                                           " <tr>" +
                                               " <td style='width: 30%' align='left' valign='top'>" + style + "Reference</span></td>" +
                                                "<td style='width: 2%' align='center' valign='top'>" + style + ":</span> </td>" +
                                                "<td style='width: 68%' align='left' colspan='4'>" + style + Convert.ToString(dr["Reference"]) + "</span>" + "</td>" +
                                            "</tr>");

                        sbSafetyWalkForNextMonth.Append("<tr style='page-break-inside: avoid'><td colspan='4'>&nbsp;</td></tr>");
                    }
                    sbSafetyWalkForNextMonth.Append("<tr style='page-break-inside: avoid'><td colspan='4'>&nbsp;</td></tr>");
                    sbSafetyWalkForNextMonth.Append("</table>");
                }
                else
                {
                    sbSafetyWalkForNextMonth.Append("<table cellpadding='0' cellspacing='0' border='0' width='100%'><tr style='page-break-inside: avoid'><td width='5%'> &nbsp;</td><td>" + style + "No Record Found</td></tr></table>");
                }
                sbSafetyWalkForNextMonth.Append("</td><td width='5%'>&nbsp;</td></tr>");
                strBody = strBody.Replace("[Safety_Walk_Question_for_the_month]", sbSafetyWalkForNextMonth.ToString());
            }
        }
        else
        {
            strBody = strBody.Replace("[Safety_Walk_Question_for_the_month]", "");
        }

        #endregion

        return strBody.ToString();
    }
    public Hashtable GeneratePrintReport_New_NewAspose(string Print_Email)
    {

        Hashtable htFindAndReplace = new Hashtable();

        string strFilePath = "";
        if (Print_Email == "Print")
            strFilePath = "SLT_Meeting_minutesPrint_New.htm";
        else if (Print_Email == "Email")
            strFilePath = "SLT_Meeting_minutesPrint_New.htm";
        SLT_Meeting_Schedule objSLT_Meeting_Schedule = new SLT_Meeting_Schedule(PK_SLT_Meeting_Schedule);
        FileStream fsMail = new FileStream(AppConfig.SitePath + @"\Sonic\SLT\" + strFilePath, FileMode.Open, FileAccess.Read);
        StreamReader rd = new StreamReader(fsMail);
        StringBuilder strBody = new StringBuilder(rd.ReadToEnd().ToString());
        rd.Close();
        fsMail.Close();
        LU_Location objLU_Location = new LU_Location(FK_LU_Location_ID);
        //htFindAndReplace.Add
        htFindAndReplace.Add("[Location_Dba]", objLU_Location.dba);
        htFindAndReplace.Add("[Meeting_Date]", clsGeneral.FormatDBNullDateToDisplay(objSLT_Meeting_Schedule.Actual_Meeting_Date));
        htFindAndReplace.Add("[Attendees_info]", GetAttendeesDetails());
        #region "Call To Order"
        htFindAndReplace.Add("[Meeting_Start_Time]", !string.IsNullOrEmpty(objSLT_Meeting_Schedule.Meeting_Start_Time) ? objSLT_Meeting_Schedule.Meeting_Start_Time : "");
        htFindAndReplace.Add("[Meeting_End_Time]", !string.IsNullOrEmpty(objSLT_Meeting_Schedule.Meeting_End_Time) ? objSLT_Meeting_Schedule.Meeting_End_Time : "");
        #endregion

        #region "Safety Walk Open Observation"

        int intMonth = Convert.ToInt32(DateTime.Now.Month);
        int iYear = Convert.ToInt32(DateTime.Now.Year);

        if (objSLT_Meeting_Schedule.Actual_Meeting_Date != null)
        {
            intMonth = Convert.ToInt32(Convert.ToDateTime(objSLT_Meeting_Schedule.Actual_Meeting_Date).Month);
            iYear = Convert.ToInt32(Convert.ToDateTime(objSLT_Meeting_Schedule.Actual_Meeting_Date).Year);
        }
        else if (objSLT_Meeting_Schedule.Scheduled_Meeting_Date != null)
        {
            intMonth = Convert.ToInt32(Convert.ToDateTime(objSLT_Meeting_Schedule.Scheduled_Meeting_Date).Month);
            iYear = Convert.ToInt32(Convert.ToDateTime(objSLT_Meeting_Schedule.Scheduled_Meeting_Date).Year);
        }

        StringBuilder sbtbl = new StringBuilder();
        //DataTable dtOpenObservation = LU_SLT_Safety_Walk_Focus_Area.GetSLTSafetyWalkOpenObservation(objSLT_Meeting_Schedule.FK_SLT_Meeting.Value, intMonth, objSLT_Meeting_Schedule.PK_SLT_Meeting_Schedule.Value, iYear, false).Tables[0];
        DataSet dsNewOpenObservation = LU_SLT_Safety_Walk_Focus_Area.SelectSafteyWalkLetterData(iYear, getMonth(Convert.ToString(intMonth)), objSLT_Meeting_Schedule.PK_SLT_Meeting_Schedule.Value);
        DataTable dtNewOpenObservation = dsNewOpenObservation.Tables[0];
        DataTable dtDepartmentofObservation = dsNewOpenObservation.Tables[1];
        DataTable dtObservationAttachment = dsNewOpenObservation.Tables[2];
        if (dtNewOpenObservation.Rows.Count > 0)
        {
            //string styleHeader = "<span style='font-family: Calibri;'>";
            string style = "<span style='font-size: 11pt; font-family: Calibri'>";
            sbtbl.Append("<table cellpadding='0' cellspacing='0' border='0' width='100%' align='center'>");
            DataTable dtQuestionOfOpenObservation = LU_SLT_Safety_Walk_Focus_Area.GetQuestions_OfOpenObservation(intMonth, objSLT_Meeting_Schedule.PK_SLT_Meeting_Schedule.Value, iYear).Tables[0];
            foreach (DataRow dr in dtNewOpenObservation.Rows)
            {
                sbtbl.Append("<tr><td style='width: 30%' align='left'>" + style + "<b>Question" + Convert.ToString(dr["Sort_Order"]) + " </b></span> </td>" +
                                  "<td style='width: 2%' align='center'>" + style + ":</span> </td>" +
                                  "<td style='width: 68%' align='left' colspan='4'>" + style + "<b>" + Convert.ToString(dr["Status"]) + "</b></span>" + "</td>" +
                                " </tr><tr>" +
                                    "<td style='width: 30%' align='left' >" + style + "Focus Area</span></td>" +
                                    "<td style='width: 2%' align='center'>" + style + ":</span> </td>" +
                                    "<td style='width: 68%' align='left' colspan='4'>" + style + Convert.ToString(dr["Focus_Area"]) + "</span>" + "</td>" +
                                "</tr>" +
                                "<tr>" +
                                    "<td style='width: 30%' align='left' valign='top'>" + style + "Question " + Convert.ToString(dr["Sort_Order"]) + "</span>" + " </td>" +
                                    "<td style='width: 2%' align='center' valign='top'>" + style + ":</span></td>" +
                                    "<td style='width: 68%' align='left' colspan='4'>" + style + Convert.ToString(dr["Question"]) + "</span>" + "</td>" +
                                "</tr>" +
                                "<tr>" +
                                    "<td style='width: 30%' align='left'>" + style + "a.Show Sonic Guidance?</span></td>" +
                                    "<td style='width: 2%' align='center'>" + style + ":</span> </td>" +
                                    "<td style='width: 68%' align='left' colspan='4'>" + style + "Yes</span>" +" </td>" +
                               " </tr>"
                               );
                //if rblGuidance == Y  not getting in db
                sbtbl.Append("  <tr>" +
                                       " <td style='width: 30%' align='left' valign='top'>" + style + "Guidance</span></td>" +
                                        "<td style='width: 2%' align='center' valign='top'>" + style + ":</span> </td>" +
                                        "<td style='width: 68%' align='left' colspan='4'>" + style + Convert.ToString(dr["Guidance"]) + "</span>" + "</td>" +
                                    "</tr>" +
                                   " <tr>" +
                                       " <td style='width: 30%' align='left' valign='top'>" + style + "Reference</span></td>" +
                                        "<td style='width: 2%' align='center' valign='top'>" + style + ":</span> </td>" +
                                        "<td style='width: 68%' align='left' colspan='4'>" + style + Convert.ToString(dr["Reference"]) + "</span>" + "</td>" +
                                    "</tr>");
                string strDepartmentList = string.Empty;
                foreach (DataRow drDepartment in dtDepartmentofObservation.Select("PK_SLT_Safety_Walk_Responses =" + Convert.ToString(dr["PK_SLT_Safety_Walk_Responses"])))
                {
                    if (string.IsNullOrEmpty(strDepartmentList)) strDepartmentList = Convert.ToString(drDepartment["Department"]);
                    else strDepartmentList = strDepartmentList + ", " + Convert.ToString(drDepartment["Department"]);
                }
                sbtbl.Append(" <tr>" +
                                   " <td style='width: 30%' align='left' valign='top'>" + style + "b. Departments Observed</span></td>" +
                                    "<td style='width: 2%' align='center' valign='top'>" + style + ":</span></td>" +
                                   " <td style='width: 68%' align='left' colspan='4'>" + style + strDepartmentList + " </span></td>"
                               + "</tr>");

                sbtbl.Append("    <tr>" +
                                  "  <td style='width: 30%' align='left'>" + style + "c. Is the Observation Acceptable?</span></td>" +
                                   " <td style='width: 2%' align='center'>" + style + ":</span> </td>" +
                                   " <td style='width: 68%' align='left' colspan='4'>" + style + Convert.ToString(dr["Observation_Acceptable"]) + "</span>" + "</td>" +
                               " </tr>");
                if (Convert.ToString(dr["Observation_Acceptable"]) == "No") //rblObservation =="N"
                {
                    sbtbl.Append("<tr>" +
                                            "<td style='width: 30%' align='left' valign='top'>" + style + "What Needs to be done?</span></td>" +
                                            "<td style='width: 2%' align='center' valign='top'>" + style + ":</span> </td>" +
                                            "<td style='width: 68%' align='left' colspan='4'>" + style + clsGeneral.ReplaceSpaceAndNewLine(Convert.ToString(dr["What_Needs_To_Be_Done"])) + "</span>" +"</td>" +
                                 "</tr>");
                }

                sbtbl.Append("<tr>" +
                                        " <td style='width: 30%' align='left'>" + style + "Add a picture or document?</span></td>" +
                                        "<td style='width: 2%' align='center'>" + style + ":</span> </td>" +
                                        "<td style='width: 68%' align='left' colspan='4'>" + style + Convert.ToString(dr["Add a Picture or Document?"]) + "</span>" +"</td>" +
                             "</tr>");

                if (Convert.ToString(dr["Observation_Acceptable"]) == "No") //rblObservation =="N"
                {
                    sbtbl.Append("<tr>" +
                                        "<td style='width: 30%' align='left' valign='top'>" + style + "Assigned to SLT Member</span></td>" +
                                        "<td style='width: 2%' align='center' valign='top'>" + style + ":</span> </td>" +
                                        "<td style='width: 68%' align='left' colspan='4'>" + style + Convert.ToString(dr["SLT_Member"]) + "</span>" + "</td>" +
                                 "</tr>" +
                                 "<tr>" +
                                        " <td style='width: 30%' align='left' valign='top'>" + style + "To Be Completed By</span></td>" +
                                        " <td style='width: 2%' align='center' valign='top'>" + style + ": </span></td>" +
                                        "<td style='width: 68%' align='left' colspan='4'>" + style + Convert.ToString(dr["To_Be_Completed_By"]) + "</span>" + " </td>" +
                                 "</tr>" +
                                 "<tr>" +
                                         "<td style='width: 30%' align='left' valign='top'>" + style + "Completion Date</span></td>" +
                                         " <td style='width: 2%' align='center' valign='top'>" + style + ":</span> </td>" +
                                         "<td style='width: 68%' align='left' colspan='4'>" + style + Convert.ToString(dr["Completed_Date"]) + "</span>" +"</td>" +
                                  "</tr>");
                }

                if (Convert.ToString(dr["Add a Picture or Document?"]) == "Yes")
                {
                    DataView dv = new DataView(dtObservationAttachment);
                    dv.RowFilter = "FK_SLT_Safety_Walk_Responses =" + Convert.ToString(dr["PK_SLT_Safety_Walk_Responses"]);

                    sbtbl.Append("<tr>" +
                                        "<td align='left' colspan='6'>" + style + "Attachments</span>" + GetOpenObservationAttachmetHTML(dv.ToTable()) + "</td>" +
                                 "</tr>");
                }
                sbtbl.Append("<tr><td colspan='3'>&nbsp;</td></tr>");
            }
            sbtbl.Append("<tr><td colspan='3'>&nbsp;</td></tr>");
            sbtbl.Append("</table>");

            htFindAndReplace.Add("[SafetyWalk_Observation]", sbtbl.ToString());
        }
        else
        {
            //strBody.Replace("[SafetyWalk_Observation]", "No records Found");
            htFindAndReplace.Add("[SafetyWalk_Observation]", "No records Found");
        }

        #endregion

        #region "Quarterly Facility Inspections"
        int intQuarter = objSLT_Meeting_Schedule.Actual_Meeting_Date != null ? clsGeneral.GetQuarterFromDate(objSLT_Meeting_Schedule.Actual_Meeting_Date) : 1;
        int intYear = objSLT_Meeting_Schedule.Actual_Meeting_Date != null ? Convert.ToInt32(Convert.ToDateTime(objSLT_Meeting_Schedule.Actual_Meeting_Date).Year) : Convert.ToInt32(DateTime.Now.Year);
        int Defeciencies_Count = 0;
        StringBuilder sbTemp = new StringBuilder();
        DateTime? Actual_meeting_Date = null;
        if (objSLT_Meeting_Schedule.Actual_Meeting_Date != null)
            Actual_meeting_Date = Convert.ToDateTime(objSLT_Meeting_Schedule.Actual_Meeting_Date);
        DataTable dtInspection = SLT_Quarterly_Inspections.SelectQuarterlyInspections(FK_LU_Location_ID, intQuarter, intYear, Actual_meeting_Date).Tables[0];
        if (dtInspection.Rows.Count > 0)
        {
            string styleHeader = "<span style='font-family: Calibri;'>";
            sbTemp.Append("<table cellpadding='0' cellspacing='0' border='0' width='100%' align='center'>");
            sbTemp.Append("<tr><th align='left' valign='bottom' width='20%'>" + styleHeader + "Focus Area</span></th>");
            sbTemp.Append("<th align='left' valign='bottom' width='35%'>" + styleHeader + " Question</span></th>");
            sbTemp.Append("<th align='left' valign='bottom' width='20%'>" + styleHeader + "Date Opened</span></th>");
            sbTemp.Append("<th align='left' valign='bottom' width='25%'>" + styleHeader + "Department</span></th></tr>");
            foreach (DataRow gr in dtInspection.Rows)
            {
                Defeciencies_Count = (Convert.ToInt32(gr["Deficiencies"]) + Defeciencies_Count);
                sbTemp.Append(GenerateQuaterltInspection(gr["PK_Inspection_ID"] != DBNull.Value ? Convert.ToDecimal(gr["PK_Inspection_ID"]) : 0));
            }
            sbTemp.Append("</table>");

            htFindAndReplace.Add("[Quarterly_Inspection]", sbTemp.ToString());
            htFindAndReplace.Add("[No_Deficiencies]", Defeciencies_Count.ToString());
        }
        else
        {
            htFindAndReplace.Add("[Quarterly_Inspection]", "No records Found");
            htFindAndReplace.Add("[No_Deficiencies]", string.Empty);
        }


        string Sonic_Location_Code = Convert.ToString(objLU_Location.Sonic_Location_Code);
        string DBA = objLU_Location.dba;
        int Year = Convert.ToInt32(DateTime.Now.Year);
        DataSet dsDetail = Charts.GetFacilityInspectionDetail(Year, DBA, Sonic_Location_Code);
        if (dsDetail.Tables[0].Rows.Count > 0)
        {
            htFindAndReplace.Add("[Dealership_Playbook_Score]", Convert.ToString(dsDetail.Tables[0].Rows[0]["Score"]));
        }
        else
            htFindAndReplace.Add("[Dealership_Playbook_Score]", "");

        #endregion

        string Incident_Year = Convert.ToString(DateTime.Now.Year);
        string Incident_Month = Convert.ToString(DateTime.Now.Month);
        if (objSLT_Meeting_Schedule.Actual_Meeting_Date != null) Incident_Year = (Convert.ToDateTime(objSLT_Meeting_Schedule.Actual_Meeting_Date).Year).ToString();
        if (objSLT_Meeting_Schedule.Actual_Meeting_Date != null) Incident_Month = (Convert.ToDateTime(objSLT_Meeting_Schedule.Actual_Meeting_Date).Month).ToString();
        if (Print_Email == "Email")
        {
            #region "Incident_review"

            htFindAndReplace.Add("[Incident_year]", Incident_Year);
            htFindAndReplace.Add("[Incident_Month]", getMonth(Incident_Month));
            htFindAndReplace.Add("[WC_INFO]", GetFRIncidentDetails("WC_FR", Incident_Year, Incident_Month));
            //htFindAndReplace.Add("[AL_INFO]", GetFRIncidentDetails("AL_FR", Incident_Year, Incident_Month));
            //htFindAndReplace.Add("[PL_INFO]", GetFRIncidentDetails("PL_FR", Incident_Year, Incident_Month));
            //htFindAndReplace.Add("[DPD_INFO]", GetFRIncidentDetails("DPD_FR", Incident_Year, Incident_Month));
            //htFindAndReplace.Add("[Property_Info]", GetFRIncidentDetails("Property_FR", Incident_Year, Incident_Month));

            #endregion

            #region "Claim_management"

            string Region = objLU_Location.Region;
            DataSet dsReport = Charts.GetWCClaimMgmtByLocation(Year, Region);
            DataTable dtReport = dsReport.Tables[0];
            if (dtReport.Rows.Count > 0)
            {
                int Score = Convert.ToInt32(dtReport.Rows[0]["Score"]);
                switch (Score)
                {
                    case 4: htFindAndReplace.Add("[CM_Score]", Charts.Tin_Label); break;
                    case 10: htFindAndReplace.Add("[CM_Score]", Charts.Bronze_Label); break;
                    case 16: htFindAndReplace.Add("[CM_Score]", Charts.Silver_Label); break;
                    case 22: htFindAndReplace.Add("[CM_Score]", Charts.Gold_Label); break;
                    case 28: htFindAndReplace.Add("[CM_Score]", Charts.Platinum_Label); break;
                }
            }
            else
                htFindAndReplace.Add("[CM_Score]", "Platinum");
            htFindAndReplace.Add("[Claim_management_Info]", getCliamManagementDetails(Incident_Year, Incident_Month));
            //SLT_Claims_Management objSLT_Claims_Management = new SLT_Claims_Management(PK_SLT_Meeting,0,true);
            //htFindAndReplace.Add("[Lag_Explaination]", objSLT_Claims_Management.Lag_Explaination != null ? objSLT_Claims_Management.Lag_Explaination : "");
            //htFindAndReplace.Add("[Associate_Status]", objSLT_Claims_Management.FK_LU_Work_Status != null ? new LU_Work_Status((decimal)objSLT_Claims_Management.FK_LU_Work_Status).Fld_Desc : "");
            //htFindAndReplace.Add("[Light_Duty_Explain]", objSLT_Claims_Management.Light_Duty_Explaination != null ? objSLT_Claims_Management.Light_Duty_Explaination : "");
            //htFindAndReplace.Add("[CM_Comments]", objSLT_Claims_Management.Comments != null ? objSLT_Claims_Management.Comments : "");

            #endregion
        }

        #region "Sonic University training"

        int intYearTraining = Convert.ToInt32(Incident_Year);
        DataTable dtResult = SLT_Training.SelectQuarterResults(FK_LU_Location_ID, intYearTraining).Tables[0];
        DataRow[] drQ1 = dtResult.Select("Quarter = 'Q1'");
        DataRow[] drQ2 = dtResult.Select("Quarter = 'Q2'");
        DataRow[] drQ3 = dtResult.Select("Quarter = 'Q3'");
        DataRow[] drQ4 = dtResult.Select("Quarter = 'Q4'");
        htFindAndReplace.Add("[Q1_Score]", Convert.ToString(drQ1[0][1]) + "%");
        htFindAndReplace.Add("[Q2_Score]", Convert.ToString(drQ2[0][1]) + "%");
        htFindAndReplace.Add("[Q3_Score]", Convert.ToString(drQ3[0][1]) + "%");
        htFindAndReplace.Add("[Q4_Score]", Convert.ToString(drQ4[0][1]) + "%");
        htFindAndReplace.Add("[Sonic_training_info]", GetSonicTrainigDetails());

        #endregion

        #region "New procedure"
        htFindAndReplace.Add("[Procedure_Info]", GetNewProcedureDetails(Incident_Year));
        #endregion

        #region "Suggestion"
        htFindAndReplace.Add("[Suggestion_info]", GetSuggestionDetails());
        #endregion

        #region "Meeting Review"

        string strNext_Meeting = "", strMeeting_Place = "", strNext_meeting_Time = "";
        DataTable dtNextMeeting = SLT_Meeting_Schedule.SelectNextMeeting(PK_SLT_Meeting_Schedule, PK_SLT_Meeting).Tables[0];

        if (dtNextMeeting.Rows.Count > 0)
        {
            strNext_Meeting = clsGeneral.FormatDBNullDateToDisplay(dtNextMeeting.Rows[0]["Scheduled_Meeting_Date"]);
            strMeeting_Place = dtNextMeeting.Rows[0]["Meeting_Place"].ToString();
            strNext_meeting_Time = dtNextMeeting.Rows[0]["Scheduled_Meeting_Time"].ToString();
        }

        htFindAndReplace.Add("[Next_meeting]", strNext_Meeting);
        htFindAndReplace.Add("[Meeting_Place]", strMeeting_Place);
        htFindAndReplace.Add("[Next_Meeting_Time]", strNext_meeting_Time);

        #endregion

        return htFindAndReplace;
    }
    public string GeneratePrintScheduleMeetingReport(string Print_Email)
    {
        string strFilePath = "";
        if (Print_Email == "Print")
            strFilePath = "SLT_ScheduleMeeting_MinutesPrint.html";
        else if (Print_Email == "Email")
            strFilePath = "SLT_ScheduleMeeting_MinutesPrint.html";
        SLT_Meeting_Schedule objSLT_Meeting_Schedule = new SLT_Meeting_Schedule(PK_SLT_Meeting_Schedule);
        FileStream fsMail = new FileStream(AppConfig.SitePath + @"\Sonic\SLT\" + strFilePath, FileMode.Open, FileAccess.Read);
        StreamReader rd = new StreamReader(fsMail);
        StringBuilder strBody = new StringBuilder(rd.ReadToEnd().ToString());
        rd.Close();
        fsMail.Close();
        LU_Location objLU_Location = new LU_Location(FK_LU_Location_ID);
        strBody = strBody.Replace("[Location_Dba]", objLU_Location.dba);
        strBody = strBody.Replace("[Meeting_Date]", clsGeneral.FormatDBNullDateToDisplay(objSLT_Meeting_Schedule.Scheduled_Meeting_Date));
        strBody = strBody.Replace("[Attendees_info]", GetMembersDetails());

        #region "Safety Walk Open Observation"
        int intMonth = objSLT_Meeting_Schedule.Scheduled_Meeting_Date != null ? Convert.ToInt32(Convert.ToDateTime(objSLT_Meeting_Schedule.Scheduled_Meeting_Date).Month) : Convert.ToInt32(DateTime.Now.Month);
        int iYear = objSLT_Meeting_Schedule.Scheduled_Meeting_Date != null ? Convert.ToInt32(Convert.ToDateTime(objSLT_Meeting_Schedule.Scheduled_Meeting_Date).Year) : Convert.ToInt32(DateTime.Now.Year);
        StringBuilder sbtbl = new StringBuilder();

        DataTable dtOpenObservation = LU_SLT_Safety_Walk_Focus_Area.GetSLTSafetyWalkOpenObservation(objSLT_Meeting_Schedule.FK_SLT_Meeting.Value, intMonth, objSLT_Meeting_Schedule.PK_SLT_Meeting_Schedule.Value, iYear, false).Tables[0];
        if (dtOpenObservation.Rows.Count > 0)
        {
            string styleHeader = "<span style='font-family: Calibri;'>";
            sbtbl.Append("<table cellpadding='0' cellspacing='0' border='0' width='100%' align='center'>");
            sbtbl.Append("<tr><th align='left' valign='bottom' width='20%'>" + styleHeader + "Month</span></th>");
            sbtbl.Append("<th align='left' valign='bottom' width='30%'>" + styleHeader + "Focus Area</span></th>");
            sbtbl.Append("<th align='left' valign='bottom' width='20%'>" + styleHeader + "Date Completed</span></th>");
            sbtbl.Append("<th align='center' valign='bottom' width='25%'>" + styleHeader + " Observations Open</span></th></tr>");
            foreach (DataRow dr in dtOpenObservation.Rows)
            {
                string style = "<span style='font-size: 11pt; font-family: Calibri'>";
                sbtbl.Append("<tr><td align='left' valign='top'>" + style + Convert.ToString(dr["Month"]) + "</span></td>");
                sbtbl.Append("<td align='left' valign='top'>" + style + Convert.ToString(dr["Focus_Area"]) + "</span></td>");
                sbtbl.Append("<td align='left' valign='top'>" + style + clsGeneral.FormatDBNullDateToDisplay(dr["Safety_Walk_Comp_Date"]) + "</span></td>");
                sbtbl.Append("<td align='center' valign='top'>" + style + Convert.ToString(dr["Observations_Open"]) + "</span></td>");
                sbtbl.Append("</tr>");
            }

            #region Bind Questions
            sbtbl.Append("<tr><th align='left' valign='bottom' colspan='4'>" + styleHeader + "Questions</th></tr>");
            DataTable dtQuestionOfOpenObservation = LU_SLT_Safety_Walk_Focus_Area.GetQuestions_OfOpenObservation(intMonth, objSLT_Meeting_Schedule.PK_SLT_Meeting_Schedule.Value, iYear).Tables[0];
            sbtbl.Append("<tr><td colspan='4'><table cellpadding='0' cellspacing='0' border='0' width='100%' align='center'>");
            foreach (DataRow drQue in dtQuestionOfOpenObservation.Rows)
            {
                string style = "<span style='font-size: 11pt; font-family: Calibri'>";
                sbtbl.Append("<tr><td align='left' valign='top' style='width:5%;'>" + style + Convert.ToString(drQue["Sort_Order"]) + ". &nbsp;</span></td>");
                sbtbl.Append("<td align='left' valign='top'>" + style + Convert.ToString(drQue["Question"]) + "</span></td>");
                sbtbl.Append("</tr>");
                sbtbl.Append("<tr><td colspan='2'>&nbsp;</td></tr>");
            }
            sbtbl.Append("</table></td></tr>");
            #endregion

            sbtbl.Append("<tr><td colspan='4'>&nbsp;</td></tr>");
            sbtbl.Append("</table>");

        }
        else
        {
            strBody.Replace("[SafetyWalk_Observation]", "<span style='font-size: 11pt; font-family: Calibri'>No records Found</span>");
        }
        strBody = strBody.Replace("[SafetyWalk_Observation]", sbtbl.ToString());
        #endregion

        #region "Safety Walk Open Observation For Prior Months"
        StringBuilder sbtblPriorMnth = new StringBuilder();

        DataTable dtOpenObservationPriorMonths = LU_SLT_Safety_Walk_Focus_Area.GetSLTSafetyWalkOpenObservation(objSLT_Meeting_Schedule.FK_SLT_Meeting.Value, intMonth, objSLT_Meeting_Schedule.PK_SLT_Meeting_Schedule.Value, iYear, true).Tables[0];
        if (dtOpenObservationPriorMonths.Rows.Count > 0)
        {

            string styleHeader = "<span style='font-family: Calibri;'>";
            sbtblPriorMnth.Append("<table cellpadding='0' cellspacing='0' border='0' width='100%' align='center'>");
            foreach (DataRow dr in dtOpenObservationPriorMonths.Rows)
            {
                sbtblPriorMnth.Append("<tr><th align='left' valign='bottom' width='20%'>" + styleHeader + "Month</span></th>");
                sbtblPriorMnth.Append("<th align='left' valign='bottom' width='30%'>" + styleHeader + "Focus Area</span></th>");
                sbtblPriorMnth.Append("<th align='left' valign='bottom' width='20%'>" + styleHeader + "Date Completed</span></th>");
                sbtblPriorMnth.Append("<th align='center' valign='bottom' width='25%'>" + styleHeader + " Observations Open</span></th></tr>");

                string style = "<span style='font-size: 11pt; font-family: Calibri'>";
                sbtblPriorMnth.Append("<tr><td align='left' valign='top'>" + style + Convert.ToString(dr["Month"]) + "</span></td>");
                sbtblPriorMnth.Append("<td align='left' valign='top'>" + style + Convert.ToString(dr["Focus_Area"]) + "</span></td>");
                sbtblPriorMnth.Append("<td align='left' valign='top'>" + style + clsGeneral.FormatDBNullDateToDisplay(dr["Safety_Walk_Comp_Date"]) + "</span></td>");
                sbtblPriorMnth.Append("<td align='center' valign='top'>" + style + Convert.ToString(dr["Observations_Open"]) + "</span></td>");
                sbtblPriorMnth.Append("</tr>");

                #region Bind Questions
                decimal ScheduleID = 0;
                if (!string.IsNullOrEmpty(Convert.ToString(dr["PK_SLT_Meeting_Schedule"])))
                    ScheduleID = Convert.ToDecimal(dr["PK_SLT_Meeting_Schedule"]);
                else
                    ScheduleID = 0;
                sbtblPriorMnth.Append("<tr><th align='left' valign='bottom' colspan='4'>" + styleHeader + "Questions</th></tr>");
                DataTable dtQuestionOfOpenObservation = LU_SLT_Safety_Walk_Focus_Area.GetQuestions_OfOpenObservation(Convert.ToInt32(dr["MonthNum"]), ScheduleID, iYear).Tables[0];
                sbtblPriorMnth.Append("<tr><td colspan='4'><table cellpadding='0' cellspacing='0' border='0' width='100%' align='center'>");
                foreach (DataRow drQue in dtQuestionOfOpenObservation.Rows)
                {
                    sbtblPriorMnth.Append("<tr><td align='left' valign='top' style='width:5%;'>" + style + Convert.ToString(drQue["Sort_Order"]) + ". &nbsp;</span></td>");
                    sbtblPriorMnth.Append("<td align='left' valign='top'>" + style + Convert.ToString(drQue["Question"]) + "</span></td>");
                    sbtblPriorMnth.Append("</tr>");
                    sbtblPriorMnth.Append("<tr><td colspan='2'> &nbsp; </td></tr>");
                }

                sbtblPriorMnth.Append("</table></td></tr>");

                #endregion
            }

            sbtblPriorMnth.Append("<tr><td colspan='4'>&nbsp;</td></tr>");
            sbtblPriorMnth.Append("</table>");
        }
        else
        {
            strBody.Replace("[SafetyWalk_Observation_PriorMonths]", "<span style='font-size: 11pt; font-family: Calibri'>No records Found</span>");
        }
        strBody = strBody.Replace("[SafetyWalk_Observation_PriorMonths]", sbtblPriorMnth.ToString());
        #endregion

        #region "Safety Walk Open Observation For Next Months"

        StringBuilder sbNextMonth = new StringBuilder();

        DataSet dsObservation = LU_SLT_Safety_Walk_Focus_Area.GetSLTQuestions_OfNextMeeting(objSLT_Meeting_Schedule.FK_SLT_Meeting.Value, objSLT_Meeting_Schedule.PK_SLT_Meeting_Schedule.Value);
        DataTable dtNextMeetingOpenObservation = dsObservation.Tables[0];
        if (dtNextMeetingOpenObservation.Rows.Count > 0)
        {
            string styleHeader = "<span style='font-family: Calibri;'>";
            sbNextMonth.Append("<table cellpadding='0' cellspacing='0' border='0' width='100%' align='center'>");
            sbNextMonth.Append("<tr><th align='left' valign='bottom' width='20%'>" + styleHeader + "Month</span></th>");
            sbNextMonth.Append("<th align='left' valign='bottom' width='30%'>" + styleHeader + "Focus Area</span></th>");
            sbNextMonth.Append("<th align='left' valign='bottom' width='20%'>" + styleHeader + "Date Completed</span></th>");
            sbNextMonth.Append("<th align='center' valign='bottom' width='25%'>" + styleHeader + " Observations Open</span></th></tr>");
            foreach (DataRow dr in dtNextMeetingOpenObservation.Rows)
            {
                string style = "<span style='font-size: 11pt; font-family: Calibri'>";
                sbNextMonth.Append("<tr><td align='left' valign='top'>" + style + Convert.ToString(dr["Month"]) + "</span></td>");
                sbNextMonth.Append("<td align='left' valign='top'>" + style + Convert.ToString(dr["Focus_Area"]) + "</span></td>");
                sbNextMonth.Append("<td align='left' valign='top'>" + style + clsGeneral.FormatDBNullDateToDisplay(dr["Safety_Walk_Comp_Date"]) + "</span></td>");
                sbNextMonth.Append("<td align='center' valign='top'>" + style + Convert.ToString(dr["Observations_Open"]) + "</span></td>");
                sbNextMonth.Append("</tr>");
            }

            #region Bind Questions
            sbNextMonth.Append("<tr><th align='left' valign='bottom' colspan='4'>" + styleHeader + "Questions</th></tr>");
            DataTable dtNextMeetingQuestionOfOpenObservation = dsObservation.Tables[1];
            sbNextMonth.Append("<tr><td colspan='4'><table cellpadding='0' cellspacing='0' border='0' width='100%' align='center'>");
            foreach (DataRow drQue in dtNextMeetingQuestionOfOpenObservation.Rows)
            {
                string style = "<span style='font-size: 11pt; font-family: Calibri'>";
                sbNextMonth.Append("<tr><td align='left' valign='top' style='width:5%;'>" + style + Convert.ToString(drQue["Sort_Order"]) + ". &nbsp;</span></td>");
                sbNextMonth.Append("<td align='left' valign='top'>" + style + Convert.ToString(drQue["Question"]) + "</span></td>");
                sbNextMonth.Append("</tr>");
                sbNextMonth.Append("<tr><td colspan='2'>&nbsp;</td></tr>");
            }
            sbNextMonth.Append("</table></td></tr>");
            #endregion

            sbNextMonth.Append("<tr><td colspan='4'>&nbsp;</td></tr>");
            sbNextMonth.Append("</table>");

        }
        else
        {
            strBody.Replace("[SafetyWalk_Observation_NextMonths]", "<span style='font-size: 11pt; font-family: Calibri'>No records Found</span>");
        }
        strBody = strBody.Replace("[SafetyWalk_Observation_NextMonths]", sbNextMonth.ToString());



        #endregion

        #region "BT Security Walk Open Observation For Next Months"

        //StringBuilder sbtblNextMonth = new StringBuilder();
        //DataSet dsBTObservation = clsLU_SLT_BT_Security_Walk_Focus_Area.GetSLTQuestions_OfBTSecurityWalkNextMeeting(objSLT_Meeting_Schedule.FK_SLT_Meeting.Value, objSLT_Meeting_Schedule.PK_SLT_Meeting_Schedule.Value);
        //DataTable dtNextBTMeetingOpenObservation = dsBTObservation.Tables[0];

        //if (dtNextBTMeetingOpenObservation.Rows.Count > 0)
        //{
        //    string styleHeader = "<span style='font-family: Calibri;'>";
        //    sbtblNextMonth.Append("<table cellpadding='0' cellspacing='0' border='0' width='100%' align='center'>");
        //    sbtblNextMonth.Append("<tr><th align='left' valign='bottom' width='20%'>" + styleHeader + "Month</span></th>");
        //    sbtblNextMonth.Append("<th align='left' valign='bottom' width='30%'>" + styleHeader + "Focus Area</span></th>");
        //    sbtblNextMonth.Append("<th align='left' valign='bottom' width='20%'>" + styleHeader + "Date Completed</span></th>");
        //    sbtblNextMonth.Append("<th align='center' valign='bottom' width='25%'>" + styleHeader + " Observations Open</span></th></tr>");

        //    foreach (DataRow dr in dtNextBTMeetingOpenObservation.Rows)
        //    {
        //        string style = "<span style='font-size: 11pt; font-family: Calibri'>";
        //        sbtblNextMonth.Append("<tr><td align='left' valign='top'>" + style + Convert.ToString(dr["Month"]) + "</span></td>");
        //        sbtblNextMonth.Append("<td align='left' valign='top'>" + style + Convert.ToString(dr["Focus_Area"]) + "</span></td>");
        //        sbtblNextMonth.Append("<td align='left' valign='top'>" + style + clsGeneral.FormatDBNullDateToDisplay(dr["BT_Security_Walk_Comp_Date"]) + "</span></td>");
        //        sbtblNextMonth.Append("<td align='center' valign='top'>" + style + Convert.ToString(dr["Observations_Open"]) + "</span></td>");
        //        sbtblNextMonth.Append("</tr>");
        //    }

        //    #region Bind Questions

        //    sbtblNextMonth.Append("<tr><th align='left' valign='bottom' colspan='4'>" + styleHeader + "Questions</th></tr>");
        //    DataTable dtNextBTMeetingQuestionOfOpenObservation = dsBTObservation.Tables[1];
        //    sbtblNextMonth.Append("<tr><td colspan='4'><table cellpadding='0' cellspacing='0' border='0' width='100%' align='center'>");

        //    foreach (DataRow drQue in dtNextBTMeetingQuestionOfOpenObservation.Rows)
        //    {
        //        string style = "<span style='font-size: 11pt; font-family: Calibri'>";
        //        sbtblNextMonth.Append("<tr><td align='left' valign='top' style='width:5%;'>" + style + Convert.ToString(drQue["Sort_Order"]) + ". &nbsp;</span></td>");
        //        sbtblNextMonth.Append("<td align='left' valign='top'>" + style + Convert.ToString(drQue["Question"]) + "</span></td>");
        //        sbtblNextMonth.Append("</tr>");
        //        sbtblNextMonth.Append("<tr><td colspan='2'>&nbsp;</td></tr>");
        //    }

        //    sbtblNextMonth.Append("</table></td></tr>");

        //    #endregion

        //    sbtblNextMonth.Append("<tr><td colspan='4'>&nbsp;</td></tr>");
        //    sbtblNextMonth.Append("</table>");
        //}
        //else
        //{
        //    strBody.Replace("[BT_Security_Walk_Questions_NextMonth]", "<span style='font-size: 11pt; font-family: Calibri'>No records Found</span>");
        //}
        //strBody = strBody.Replace("[BT_Security_Walk_Questions_NextMonth]", sbtblNextMonth.ToString());

        #endregion

        #region "Quarterly Facility Inspections"
        int intQuarter = objSLT_Meeting_Schedule.Scheduled_Meeting_Date != null ? clsGeneral.GetQuarterFromDate(objSLT_Meeting_Schedule.Scheduled_Meeting_Date) : 1;
        int intYear = objSLT_Meeting_Schedule.Scheduled_Meeting_Date != null ? Convert.ToInt32(Convert.ToDateTime(objSLT_Meeting_Schedule.Scheduled_Meeting_Date).Year) : Convert.ToInt32(DateTime.Now.Year);
        int Defeciencies_Count = 0;
        StringBuilder sbTemp = new StringBuilder();
        DateTime? Actual_meeting_Date = null;
        if (objSLT_Meeting_Schedule.Scheduled_Meeting_Date != null)
            Actual_meeting_Date = Convert.ToDateTime(objSLT_Meeting_Schedule.Scheduled_Meeting_Date);
        DataTable dtInspection = SLT_Quarterly_Inspections.SelectQuarterlyInspections(FK_LU_Location_ID, intQuarter, intYear, Actual_meeting_Date).Tables[0];
        dtInspection.DefaultView.RowFilter = "Deficiencies_NotCompleted <> 0";
        dtInspection = dtInspection.DefaultView.ToTable();
        if (dtInspection.Rows.Count > 0)
        {
            string styleHeader = "<span style='font-family: Calibri;'>";
            sbTemp.Append("<table cellpadding='0' cellspacing='0' border='0' width='100%' align='center'>");
            sbTemp.Append("<tr><th align='left' valign='bottom' width='20%'>" + styleHeader + "Inspector Name</span></th>");
            sbTemp.Append("<th align='left' valign='bottom' width='25%'>" + styleHeader + " Inspection Date</span></th>");
            sbTemp.Append("<th align='left' valign='bottom' width='25%'>" + styleHeader + "Number of Deficiencies</span></th>");
            sbTemp.Append("<th align='left' valign='bottom' width='30%'>" + styleHeader + "Number of Deficiencies Not Completed </span></th></tr>");
            foreach (DataRow dr in dtInspection.Rows)
            {
                string style = "<span style='font-size: 11pt; font-family: Calibri'>";
                string count = "";
                sbTemp.Append("<tr><td align='left' valign='top'>" + style + Convert.ToString(dr["Inspector_Name"]) + "</span></td>");
                sbTemp.Append("<td align='left' valign='top'>" + style + Convert.ToString(clsGeneral.FormatDBNullDateToDisplay(dr["Date"])) + "</span></td>");
                sbTemp.Append("<td align='center' valign='top'>" + style + dr["Deficiencies"] + "</span></td>");
                sbTemp.Append("<td align='center' valign='top'>" + style + Convert.ToString(dr["Deficiencies_NotCompleted"]) + "</span></td>");
                sbTemp.Append("</tr>");
            }
            sbTemp.Append("</table>");
        }
        else
        {
            strBody.Replace("[SafetyWalk_Inspections]", "<span style='font-size: 11pt; font-family: Calibri'>No records Found</span>");
        }
        strBody = strBody.Replace("[SafetyWalk_Inspections]", sbTemp.ToString());
        #endregion

        int Year = Convert.ToInt32(DateTime.Now.Year);
        string Incident_Year = Convert.ToString(DateTime.Now.Year);
        string Incident_Month = Convert.ToString(DateTime.Now.Month);
        if (objSLT_Meeting_Schedule.Scheduled_Meeting_Date != null) Incident_Year = (Convert.ToDateTime(objSLT_Meeting_Schedule.Scheduled_Meeting_Date).Year).ToString();
        if (objSLT_Meeting_Schedule.Scheduled_Meeting_Date != null) Incident_Month = (Convert.ToDateTime(objSLT_Meeting_Schedule.Scheduled_Meeting_Date).Month).ToString();

        #region " Comment "
        //if (Print_Email == "Email")
        //{
        //    #region "Incident_review"
        //    strBody = strBody.Replace("[Incident_year]", Incident_Year);
        //    strBody = strBody.Replace("[Incident_Month]", getMonth(Incident_Month));
        //    strBody = strBody.Replace("[WC_INFO]", GetFRIncidentDetails("WC_FR", Incident_Year, Incident_Month));
        //    #endregion

        //    #region "Claim_management"
        //    string Region = objLU_Location.Region;
        //    DataSet dsReport = Charts.GetWCClaimMgmtByLocation(Year, Region);
        //    DataTable dtReport = dsReport.Tables[0];
        //    if (dtReport.Rows.Count > 0)
        //    {
        //        int Score = Convert.ToInt32(dtReport.Rows[0]["Score"]);
        //        switch (Score)
        //        {
        //            case 4: strBody = strBody.Replace("[CM_Score]", "Tin"); break;
        //            case 10: strBody = strBody.Replace("[CM_Score]", "Bronze"); break;
        //            case 16: strBody = strBody.Replace("[CM_Score]", "Silver"); break;
        //            case 22: strBody = strBody.Replace("[CM_Score]", "Gold"); break;
        //            case 28: strBody = strBody.Replace("[CM_Score]", "Platinum"); break;
        //        }
        //    }
        //    else
        //        strBody = strBody.Replace("[CM_Score]", "Platinum");
        //    strBody = strBody.Replace("[Claim_management_Info]", getCliamManagementDetails(Incident_Year, Incident_Month));
        //    #endregion
        //} 
        #endregion

        #region "Claim Investigation"
        StringBuilder sbInvestigation = new StringBuilder();
        DataTable dtInvestigation = SLT_Incident_Review.GetIncident_Review_FirstReport(Convert.ToString(iYear), Convert.ToString(intMonth), "WC_FR", FK_LU_Location_ID, 0).Tables[0];
        if (dtInvestigation.Rows.Count > 0)
        {
            string styleHeader = "<span style='font-family: Calibri;'>";
            sbInvestigation.Append("<table cellpadding='0' cellspacing='0' border='0' width='100%' align='center'>");
            sbInvestigation.Append("<tr><th align='left' valign='bottom' width='15%'>" + styleHeader + "First Report Number</span></th>");
            sbInvestigation.Append("<th align='left' valign='bottom' width='20%'>" + styleHeader + " Investigation ID</span></th>");
            sbInvestigation.Append("<th align='left' valign='bottom' width='20%'>" + styleHeader + "Department</span></th>");
            sbInvestigation.Append("<th align='left' valign='bottom' width='20%'>" + styleHeader + "Date of Incident </span></th>");
            sbInvestigation.Append("<th align='left' valign='bottom' width='25%'>" + styleHeader + "Name</span></th></tr>");
            foreach (DataRow dr in dtInvestigation.Rows)
            {
                string style = "<span style='font-size: 11pt; font-family: Calibri'>";
                string count = "";
                sbInvestigation.Append("<tr><td align='left' valign='top'>" + style + Convert.ToString(dr["WC_FR_Number"]) + "</span></td>");
                sbInvestigation.Append("<td align='left' valign='top'>" + style + dr["PK_Investigation_ID"] + "</span></td>");
                sbInvestigation.Append("<td align='left' valign='top'>" + style + dr["Department"] + "</span></td>");
                sbInvestigation.Append("<td align='left' valign='top'>" + style + Convert.ToString(clsGeneral.FormatDBNullDateToDisplay(dr["Date_of_Incident"])) + "</span></td>");
                sbInvestigation.Append("<td align='left' valign='top'>" + style + dr["Name"] + "</span></td>");
                sbInvestigation.Append("</tr>");
            }
            sbInvestigation.Append("</table>");
        }
        else
        {
            strBody.Replace("[SafetyWalk_Investigations]", "<span style='font-size: 11pt; font-family: Calibri'>No records Found</span>");
        }
        strBody = strBody.Replace("[SafetyWalk_Investigations]", sbInvestigation.ToString());
        #endregion

        #region "Sonic University training"

        int intScheduleQuarter = objSLT_Meeting_Schedule.Scheduled_Meeting_Date != null ? clsGeneral.GetQuarterFromDate(objSLT_Meeting_Schedule.Scheduled_Meeting_Date) : 1;
        int intScheduleYear = objSLT_Meeting_Schedule.Scheduled_Meeting_Date != null ? Convert.ToInt32(Convert.ToDateTime(objSLT_Meeting_Schedule.Scheduled_Meeting_Date).Year) : Convert.ToInt32(DateTime.Now.Year);
        StringBuilder sbUniTrainingTemp = new StringBuilder();
        DataTable dtResult = clsSLT_Training_RLCM.SelectRLCMTrainingByLocationAndYear(FK_LU_Location_ID, intScheduleYear).Tables[0];
        dtResult.DefaultView.RowFilter = "Quarter = " + Convert.ToString(intScheduleQuarter);
        dtResult = dtResult.DefaultView.ToTable();
        if (dtResult.Rows.Count > 0)
        {
            string styleHeader = "<span style='font-family: Calibri;'>";
            sbUniTrainingTemp.Append("<table cellpadding='0' cellspacing='0' border='0' width='100%' align='center'>");
            sbUniTrainingTemp.Append("<tr><th align='left' valign='bottom' width='20%'>" + styleHeader + "Focus</span></th>");
            sbUniTrainingTemp.Append("<th align='left' valign='bottom' width='10%'>" + styleHeader + " Topic</span></th>");
            sbUniTrainingTemp.Append("<th align='left' valign='bottom' width='20%'>" + styleHeader + "Date Scheduled</span></th>");
            sbUniTrainingTemp.Append("<th align='left' valign='bottom' width='25%'>" + styleHeader + "Date Completed </span></th>");
            sbUniTrainingTemp.Append("<th align='left' valign='bottom' width='25%'>" + styleHeader + "Reason Not Completed </span></th></tr>");
            foreach (DataRow dr in dtResult.Rows)
            {
                string style = "<span style='font-size: 11pt; font-family: Calibri'>";
                string count = "";
                sbUniTrainingTemp.Append("<tr><td align='left' valign='top'>" + style + Convert.ToString(dr["Focus"]) + "</span></td>");
                sbUniTrainingTemp.Append("<td align='left' valign='top'>" + style + Convert.ToString(dr["Topic"]) + "</span></td>");
                sbUniTrainingTemp.Append("<td align='left' valign='top'>" + style + Convert.ToString(clsGeneral.FormatDBNullDateToDisplay(dr["Date_Scheduled"])) + "</span></td>");
                sbUniTrainingTemp.Append("<td align='left' valign='top'>" + style + Convert.ToString(clsGeneral.FormatDBNullDateToDisplay(dr["Date_Completed"])) + "</span></td>");
                sbUniTrainingTemp.Append("<td align='left' valign='top'>" + style + dr["Reason_Not_Completed"] + "</span></td>");
                sbUniTrainingTemp.Append("</tr>");
            }
            sbUniTrainingTemp.Append("</table>");
        }
        else
        {
            strBody.Replace("[Sonic_University_Training]", "<span style='font-size: 11pt; font-family: Calibri'>No records Found</span>");
        }
        strBody = strBody.Replace("[Sonic_University_Training]", sbUniTrainingTemp.ToString());

        //int intYearTraining = Convert.ToInt32(Incident_Year);
        //DataTable dtResult = SLT_Training.SelectQuarterResults(FK_LU_Location_ID, intYearTraining).Tables[0];
        //DataRow[] drQ1 = dtResult.Select("Quarter = 'Q1'");
        //DataRow[] drQ2 = dtResult.Select("Quarter = 'Q2'");
        //DataRow[] drQ3 = dtResult.Select("Quarter = 'Q3'");
        //DataRow[] drQ4 = dtResult.Select("Quarter = 'Q4'");
        //strBody = strBody.Replace("[Q1_Score]", Convert.ToString(drQ1[0][1]) + "%");
        //strBody = strBody.Replace("[Q2_Score]", Convert.ToString(drQ2[0][1]) + "%");
        //strBody = strBody.Replace("[Q3_Score]", Convert.ToString(drQ3[0][1]) + "%");
        //strBody = strBody.Replace("[Q4_Score]", Convert.ToString(drQ4[0][1]) + "%");
        //strBody = strBody.Replace("[Sonic_training_info]", GetSonicTrainigDetails());

        #endregion

        return strBody.ToString();
    }


    private string AppendSafetyWalkComments(string Comments)
    {
        StringBuilder sbTemp = new StringBuilder();
        sbTemp.Append("<tr><td align='left' valign='bottom' width='20%'><span style='font-size: 11pt; font-family: Calibri'>Comments:</span></td>");
        sbTemp.Append("<td align='left' valign='bottom' width='25%' colspan='2'><span style='font-size: 11pt; font-weight: normal; font-family: Calibri'>" + Comments + "</span></td>");
        sbTemp.Append("</tr>");
        return sbTemp.ToString();
    }
    private string GenerateQuaterltInspection(decimal Inspection_id)
    {
        StringBuilder sbRecord = new StringBuilder();
        string style = "<span style='font-size: 11pt; font-family: Calibri'>";
        string styleHeader = "<span style='font-family: Calibri;'>";
        string count = "";
        //sbRecord.Append("<table cellpadding='0' cellspacing='0' border='0' width='100%' align='center'>");
        DataTable dtResponse = SLT_Quarterly_Inspections.SelectQuarterlyInspection_Responses(Inspection_id).Tables[0];
        count = Convert.ToString(dtResponse.Rows.Count);
        //sbRecord.Append("<tr><th align='left' valign='bottom' width='20%'>" + styleHeader + "Focus Area</span></th>");
        //sbRecord.Append("<th align='left' valign='bottom' width='35%'>" + styleHeader + " Question</span></th>");
        //sbRecord.Append("<th align='left' valign='bottom' width='20%'>" + styleHeader + "Date Opened</span></th>");
        //sbRecord.Append("<th align='left' valign='bottom' width='25%'>" + styleHeader + "Department</span></th></tr>");
        if (dtResponse.Rows.Count > 0)
        {
            foreach (DataRow dr in dtResponse.Rows)
            {
                sbRecord.Append("<tr><td align='left' valign='top'>" + style + Convert.ToString(dr["Item_Number_Focus_Area"]) + "</span></td>");
                sbRecord.Append("<td align='left' valign='top'>" + style + Convert.ToString(dr["Question_Text"]) + "</span></td>");
                sbRecord.Append("<td align='left' valign='top'>" + style + clsGeneral.FormatDBNullDateToDisplay(dr["Date_Opened"]) + "</span></td>");
                sbRecord.Append("<td align='left' valign='top'>" + style + Convert.ToString(dr["Inspection_Department"]) + "</span></td>");
                sbRecord.Append("</tr>");

            }
        }

        else
        {
            sbRecord.Append("<tr><td align='left' valign='bottom' colspan='4'>" + style + "No record found</span></td></tr>");
        }
        sbRecord.Append("<tr><td colspan='4'>&nbsp;</td></tr>");

        return sbRecord.ToString();

    }

    private string GetSonicTrainigDetails()
    {
        StringBuilder sbRecord = new StringBuilder();
        sbRecord.Append("<table cellpadding='0' cellspacing='0' border='0' width='100%' align='center'>");
        DataTable dtTrainSugg = SLT_Training.SelectByFK(PK_SLT_Meeting_Schedule).Tables[0];
        string Style = "<span style='font-size: 11pt; font-weight: normal; font-family: Calibri'>";
        if (dtTrainSugg.Rows.Count > 0)
        {
            foreach (DataRow dr in dtTrainSugg.Rows)
            {
                ResizeAllImages(Convert.ToDecimal(dr["PK_SLT_Training"]), "SLT_Training");
                sbRecord.Append("<tr><td align='left' valign='bottom' width='40%'> " + Style + " Training Description:</span></td>");
                sbRecord.Append("<td align='left' valign='bottom' width='60%'> " + Style + Convert.ToString(dr["Training_Description"]) + "</span></td></tr>");
                sbRecord.Append("<tr><td align='left' valign='bottom'> " + Style + " Desired Completion Date:</span></td>");
                sbRecord.Append("<td align='left' valign='bottom'> " + Style + clsGeneral.FormatDBNullDateToDisplay(dr["Desired_Comp_Date"]) + "</span></td>");
                sbRecord.Append("</tr>");
                sbRecord.Append("<tr><td align='left' colspan='2'>");
                sbRecord.Append(GetAttachmetHTML("SLT_Training", Convert.ToDecimal(dr["PK_SLT_Training"])));
                sbRecord.Append("</td></tr>");
                sbRecord.Append("<tr><td colspan='2'>&nbsp;</td></tr>");
            }
        }
        else
        {
            sbRecord.Append("<tr><td align='left' valign='bottom' width='100%'>" + Style + "No Record Found</span> </td></tr>");
        }
        sbRecord.Append("</table>");
        return sbRecord.ToString();
    }

    private string GetNewProcedureDetails(string ProcedureYear)
    {
        int intYearProcedure = Convert.ToInt32(ProcedureYear);
        DataTable dtProcedure = SLT_New_Procedure.SelectByFK(PK_SLT_Meeting_Schedule, intYearProcedure).Tables[0];
        string Style = "<span style='font-size: 11pt; font-weight: normal; font-family: Calibri'>";
        StringBuilder sbRecord = new StringBuilder();
        sbRecord.Append("<table cellpadding='0' cellspacing='0' border='0' width='90%' align='center'>");
        if (dtProcedure.Rows.Count > 0)
        {
            foreach (DataRow dr in dtProcedure.Rows)
            {
                sbRecord.Append("<tr><td align='left' valign='bottom' width='40%'>" + Style + "Importance:</span></td>");
                sbRecord.Append("<td align='left' valign='bottom' width='60%'>" + Style + Convert.ToString(dr["Importance"]) + "</span></td></tr>");
                sbRecord.Append("<tr><td align='left' valign='bottom'>" + Style + "Procedure Source:</span></td>");
                sbRecord.Append("<td align='left' valign='bottom'>" + Style + Convert.ToString(dr["Procedure_Source"]) + "</span></td></tr>");
                sbRecord.Append("<tr><td align='left' valign='bottom'>" + Style + "Procedure Description:</span></td>");
                sbRecord.Append("<td align='left' valign='bottom'>" + Style + Convert.ToString(dr["Procedure_Description"]) + "</span></td></tr>");
                sbRecord.Append("<tr><td align='left' valign='bottom'>" + Style + "Assigned To:</span></td>");
                sbRecord.Append("<td align='left' valign='bottom'>" + Style + Convert.ToString(dr["Assigned_To"]) + "</span></td></tr>");
                sbRecord.Append("<tr><td align='left' valign='bottom'>" + Style + "Target Completion Date:</span></td>");
                sbRecord.Append("<td align='left' valign='bottom'>" + Style + clsGeneral.FormatDBNullDateToDisplay(dr["Target_Completion_Date"]) + "</span></td></tr>");
                sbRecord.Append("<tr><td align='left' valign='bottom'>" + Style + "Status:</span></td>");
                sbRecord.Append("<td align='left' valign='bottom'>" + Style + Convert.ToString(dr["Procedure_Status"]) + "</span></td></tr>");
                sbRecord.Append("<tr><td colspan='2'>&nbsp;</td></tr>");
            }
        }
        else
        {
            sbRecord.Append("<tr><td align='left' valign='bottom' width='100%'>" + Style + " No Record Found </span></td></tr>");
        }
        sbRecord.Append("</table>");
        return sbRecord.ToString();
    }

    private string GetSuggestionDetails()
    {
        DataTable dtSuggestion = SLT_Suggestion.SelectByFK(PK_SLT_Meeting_Schedule).Tables[0];
        string Style = "<span style='font-size: 11pt; font-weight: normal; font-family: Calibri'>";
        StringBuilder sbRecord = new StringBuilder();
        sbRecord.Append("<table cellpadding='0' cellspacing='0' border='0' width='90%' align='center'>");
        if (dtSuggestion.Rows.Count > 0)
        {
            foreach (DataRow dr in dtSuggestion.Rows)
            {
                sbRecord.Append("<tr><td align='left' valign='bottom' width='40%'>" + Style + "Importance:</span></td>");
                sbRecord.Append("<td align='left' valign='bottom' width='60%'>" + Style + Convert.ToString(dr["Importance"]) + "</span></td></tr>");
                sbRecord.Append("<tr><td align='left' valign='bottom'>" + Style + "Suggestion Source:</span></td>");
                sbRecord.Append("<td align='left' valign='bottom'>" + Style + Convert.ToString(dr["Suggestion_Source"]) + "</span></td></tr>");
                sbRecord.Append("<tr><td align='left' valign='bottom'>" + Style + "Suggestion Description:</span></td>");
                sbRecord.Append("<td align='left' valign='bottom'>" + Style + Convert.ToString(dr["Suggestion_Description"]) + "</span></td></tr>");
                sbRecord.Append("<tr><td align='left' valign='bottom'>" + Style + "Assigned To:</span></td>");
                sbRecord.Append("<td align='left' valign='bottom'>" + Style + Convert.ToString(dr["Assigned_To"]) + "</span></td></tr>");
                sbRecord.Append("<tr><td align='left' valign='bottom'>" + Style + "Target Completion Date:</span></td>");
                sbRecord.Append("<td align='left' valign='bottom'>" + Style + clsGeneral.FormatDBNullDateToDisplay(dr["Target_Completion_Date"]) + "</span></td></tr>");
                sbRecord.Append("<tr><td align='left' valign='bottom'>" + Style + "Status:</span></td>");
                sbRecord.Append("<td align='left' valign='bottom'>" + Style + Convert.ToString(dr["Suggestion_Status"]) + "</span></td></tr>");
                sbRecord.Append("<tr><td colspan='2'>&nbsp;</td></tr>");
            }
        }
        else
        {
            sbRecord.Append("<tr><td align='left' valign='bottom' width='100%'>" + Style + "No Record Found </span></td></tr>");
        }
        sbRecord.Append("</table>");
        return sbRecord.ToString();
    }

    private string getCliamManagementDetails(string ClaimYear, string ClaimMonth)
    {
        int intYear = Convert.ToInt32(ClaimYear);
        int month = Convert.ToInt32(ClaimMonth);
        DataTable DtClaim_Management = SLT_Claims_Management.SelectWCClaims(Convert.ToInt32(FK_LU_Location_ID)).Tables[0];
        string Style = "<span style='font-size: 11pt; font-weight: normal; font-family: Calibri'>";
        StringBuilder sbRecord = new StringBuilder();
        sbRecord.Append("<table cellpadding='0' cellspacing='0' border='0' width='100%'>");
        decimal FK_Claim = 0;
        if (DtClaim_Management.Rows.Count > 0)
        {

            foreach (DataRow dr in DtClaim_Management.Rows)
            {
                if (dr["PK_Workers_Comp_Claims_ID"] != DBNull.Value) FK_Claim = Convert.ToDecimal(dr["PK_Workers_Comp_Claims_ID"]);
                SLT_Claims_Management objSLT_Claims_Management = new SLT_Claims_Management(PK_SLT_Meeting, FK_Claim, true);
                sbRecord.Append("<tr><td align='left' valign='bottom' width='33%'>" + Style + "Claim Number:</span></td>");
                sbRecord.Append("<td align='left' valign='bottom' width='68%'>" + Style + Convert.ToString(dr["Origin_Claim_Number"]) + "</span></td></tr>");
                sbRecord.Append("<tr><td align='left' valign='bottom'>" + Style + "Date of Incident:</span></td>");
                sbRecord.Append("<td align='left' valign='bottom'>" + Style + clsGeneral.FormatDBNullDateToDisplay(dr["Date_of_Accident"]) + "</span></td></tr>");
                sbRecord.Append("<tr><td align='left' valign='bottom'>" + Style + "Lag Time:</span></td>");
                sbRecord.Append("<td align='left' valign='bottom'>" + Style + Convert.ToString(dr["Lag_Time"]) + "</span></td></tr>");
                sbRecord.Append("<tr><td align='left' valign='bottom'>" + Style + "Claim Status:</span></td>");
                sbRecord.Append("<td align='left' valign='bottom'>" + Style + Convert.ToString(dr["Claim_Status"]) + "</span></td></tr>");
                sbRecord.Append("<tr><td align='left' valign='bottom'>" + Style + "Description:</span></td>");
                sbRecord.Append("<td align='left' valign='bottom'>" + Style + Convert.ToString(dr["Cause_Injury_Body_Part_Description"]) + "</span></td></tr>");
                sbRecord.Append("<tr><td align='left' valign='bottom'> " + Style + " Lag Explanation:</span></td>");
                sbRecord.Append("<td align='left' valign='bottom'> " + Style + (objSLT_Claims_Management.Lag_Explaination != null ? objSLT_Claims_Management.Lag_Explaination : "") + "</span></td></tr>");
                sbRecord.Append("<tr> <td align='left' valign='top' > " + Style + " What is Asscociate's Current Status:</span></td>");
                sbRecord.Append("<td align='left' valign='top'>" + Style + (objSLT_Claims_Management.FK_LU_Work_Status != null ? new LU_Work_Status((decimal)objSLT_Claims_Management.FK_LU_Work_Status).Fld_Desc : "") + "</span></td></tr>");
                sbRecord.Append("<tr><td align='left' valign='top'> " + Style + " If in a Modified Light Duty Position Explain:</span></td>");
                sbRecord.Append("<td align='left' valign='top'> " + Style + (objSLT_Claims_Management.Light_Duty_Explaination != null ? objSLT_Claims_Management.Light_Duty_Explaination : "") + " </span></td></tr>");
                sbRecord.Append("<tr><td align='left' valign='top'> " + Style + " Comments:</span></td>");
                sbRecord.Append("<td align='left' valign='top'> " + Style + (objSLT_Claims_Management.Comments != null ? objSLT_Claims_Management.Comments : "") + " </span></td></tr>");
                sbRecord.Append("<tr><td colspan='2'>&nbsp;</td></tr>");

            }
        }
        else
        {
            sbRecord.Append("<tr><td align='left' valign='bottom' width='100%'>" + Style + "No Record Found </span></td></tr>");
        }
        sbRecord.Append("</table>");
        return sbRecord.ToString();
    }
    private string GetFRIncidentDetails(string strFR, string Year, string Month)
    {
        decimal PK_FR_ID = 0;
        decimal PK_SLT_Review = 0;
        int PK_investigation = 0;
        DataTable dtReview = SLT_Incident_Review.GetIncident_Review_FirstReport(Year, Month, strFR, FK_LU_Location_ID, 0).Tables[0];
        string Style = "<span style='font-size: 11pt; font-weight: normal; font-family: Calibri'>";
        StringBuilder sbRecord = new StringBuilder();
        sbRecord.Append("<table cellpadding='0' cellspacing='0' border='0' width='100%' align='center'>");

        if (dtReview.Rows.Count > 0)
        {
            foreach (DataRow dr in dtReview.Rows)
            {
                #region "WC"
                if (strFR == "WC_FR")
                {
                    if (dr["PK_WC_FR_ID"] != DBNull.Value) PK_FR_ID = Convert.ToDecimal(dr["PK_WC_FR_ID"]);
                    if (dr["FK_SLT_Incident_Review"] != DBNull.Value) PK_SLT_Review = Convert.ToDecimal(dr["FK_SLT_Incident_Review"]);
                    if (dr["PK_Investigation_ID"] != DBNull.Value) PK_investigation = Convert.ToInt32(dr["PK_Investigation_ID"]);
                    WC_FR objWC_FR = new WC_FR(PK_FR_ID);
                    SLT_Incident_Review objSLT_Incident_Review = new SLT_Incident_Review(PK_SLT_Review);
                    Investigation objInvestigation = new Investigation(PK_investigation);
                    sbRecord.Append("<tr><td align='left' valign='bottom' width='28%'>" + Style + "Incident Number:</span></td>");
                    sbRecord.Append("<td align='left' valign='bottom' width='72%'>" + Style + Convert.ToString(dr["WC_FR_Number"]) + "</span></td></tr>");
                    sbRecord.Append("<tr><td align='left' valign='bottom'>" + Style + "Date Of Incident:</span></td>");
                    sbRecord.Append("<td align='left' valign='bottom'>" + Style + clsGeneral.FormatDBNullDateToDisplay(dr["Date_Of_Incident"]) + "</span></td></tr>");
                    sbRecord.Append("<tr><td align='left' valign='bottom'>" + Style + "Department:</span></td>");
                    sbRecord.Append("<td align='left' valign='bottom'>" + Style + Convert.ToString(dr["Department"]) + "</span></td></tr>");
                    sbRecord.Append("<tr><td align='left' valign='top'>" + Style + "Incident Description:</span></td>");
                    sbRecord.Append("<td align='left' valign='top'>" + Style + objWC_FR.Description_Of_Incident + "</span></td></tr>");
                    sbRecord.Append("<tr><td align='left' valign='top'>" + Style + "Sonic Cause Code:</span></td>");
                    sbRecord.Append("<td align='left' valign='top'>" + Style + objInvestigation.Sonic_Cause_Code + "</span></td></tr>");
                    sbRecord.Append("<tr><td colspan='2'><table cellpadding='0' cellspacing='0' width='100%'>");
                    sbRecord.Append("<tr><td align='left' valign='top'>" + Style + "What is the Incidents root cause?:</span></td>");
                    sbRecord.Append("<td align='left' valign='top' colspan='2'>" + Style + objSLT_Incident_Review.Root_Cause + "</span></td> </tr>");
                    sbRecord.Append("<tr><td align='left' valign='top' colspan='2'>" + Style + "How can the incident be prevented from happening again?:</span></td>");
                    sbRecord.Append("<td align='left' valign='top'>" + Style + objSLT_Incident_Review.Conclusions + "</span></td> </tr>");
                    //sbRecord.Append("<tr><td align='left' valign='bottom' width='40%'></td>");
                    //sbRecord.Append("<td align='left' valign='bottom' width='10%'></td>");
                    //sbRecord.Append("<td align='left' valign='bottom' width='30%'></td></tr>");
                    sbRecord.Append("<tr><td align='left' valign='bottom' width='28%'>" + Style + "Item Status:</span></td>");
                    if (objSLT_Incident_Review.FK_LU_Item_Status != null)
                    {
                        sbRecord.Append("<td align='left' valign='bottom' width='25%'>" + Style + new LU_Item_Status((decimal)objSLT_Incident_Review.FK_LU_Item_Status).Fld_Desc + "</span></td>");
                    }
                    else
                        sbRecord.Append("<td align='left' valign='bottom' width='25%'>" + Style + " </span></td>");
                    sbRecord.Append("<td align='left' valign='bottom' width='47%'></td></tr>");
                    sbRecord.Append("</table></td></tr>");

                    //sbRecord.Append("</tr>");
                    sbRecord.Append("<tr><td colspan='2'>&nbsp;</td></tr>");
                }
                #endregion
                #region "AL PL DPD Property"
                //else
                //{
                //    string FR_Number = "";
                //    string Date_Of_Incident = "";
                //    if (strFR == "AL_FR")
                //    {
                //        PK_FR_ID = Convert.ToDecimal(dr["PK_AL_FR_ID"]);
                //        FR_Number = Convert.ToString(dr["AL_FR_Number"]);
                //        Date_Of_Incident = clsGeneral.FormatDBNullDateToDisplay(dr["Date_Of_Incident"]);
                //    }
                //    if (strFR == "PL_FR")
                //    {
                //        PK_FR_ID = Convert.ToDecimal(dr["PK_PL_Fr_ID"]);
                //        FR_Number = Convert.ToString(dr["PL_FR_Number"]);
                //        Date_Of_Incident = clsGeneral.FormatDBNullDateToDisplay(dr["Date_Of_Incident"]);
                //    }
                //    if (strFR == "DPD_FR")
                //    {
                //        PK_FR_ID = Convert.ToDecimal(dr["PK_DPD_FR_ID"]);
                //        FR_Number = Convert.ToString(dr["DPD_FR_Number"]);
                //        Date_Of_Incident = clsGeneral.FormatDBNullDateToDisplay(dr["Date_Of_Incident"]);
                //    }
                //    if (strFR == "Property_FR")
                //    {
                //        PK_FR_ID = Convert.ToDecimal(dr["PK_Property_fr_ID"]);
                //        FR_Number = Convert.ToString(dr["Property_FR_Number"]);
                //        Date_Of_Incident = clsGeneral.FormatDBNullDateToDisplay(dr["Date_of_Loss"]);
                //    }
                //    PK_SLT_Review = Convert.ToDecimal(dr["FK_SLT_Incident_Review"]);
                //    SLT_Incident_Review objSLT_Incident_Review = new SLT_Incident_Review(PK_SLT_Review);
                //    sbRecord.Append("<tr><td align='left' valign='bottom' width='20%'>" + Style + "Incident Number:</span></td>");
                //    sbRecord.Append("<td align='left' valign='bottom' width='70%'>" + Style + FR_Number + "</span></td></tr>");
                //    sbRecord.Append("<tr><td align='left' valign='bottom'>" + Style + "Date Of Incident:</span></td>");
                //    sbRecord.Append("<td align='left' valign='bottom'>" + Style + Date_Of_Incident + "</span></td></tr>");
                //    sbRecord.Append("<tr><td align='left' valign='bottom'>" + Style + "Incident Description:</span></td>");
                //    sbRecord.Append("<td align='left' valign='bottom'>" + Style + Convert.ToString(dr["Description_Of_Loss"]) + "</span></td></tr>");
                //    sbRecord.Append("<tr> <td colspan='2'><table cellpadding='0' cellspacing='0' width='100%'>");
                //    sbRecord.Append("<tr><td align='left' valign='bottom' width='40%'></td>");
                //    sbRecord.Append("<td align='left' valign='bottom' width='10%'></td>");
                //    sbRecord.Append("<td align='left' valign='bottom' width='30%'></td></tr>");
                //    sbRecord.Append("<tr><td align='left' valign='bottom'>" + Style + "What is the Incidents root cause?:</span></td>");
                //    sbRecord.Append("<td align='left' valign='bottom' colspan='2'>" + Style + objSLT_Incident_Review.Root_Cause + "</span></td> </tr>");
                //    sbRecord.Append("<tr><td align='left' valign='bottom' colspan='2'>" + Style + "How can the incident be prevented from happening again?:</span></td>");
                //    sbRecord.Append("<td align='left' valign='bottom'>" + Style + objSLT_Incident_Review.Conclusions + "</span></td> </tr>");
                //    sbRecord.Append("</table></td></tr>");
                //    sbRecord.Append("<tr><td align='left' valign='bottom'>" + Style + "Item Status:</span></td>");
                //    if (objSLT_Incident_Review.FK_LU_Item_Status != null)
                //    {
                //        sbRecord.Append("<td align='left' valign='bottom'>" + Style + new LU_Item_Status((decimal)objSLT_Incident_Review.FK_LU_Item_Status).Fld_Desc + "</span></td>");
                //    }
                //    else
                //        sbRecord.Append("<td align='left' valign='bottom'>" + Style + " </span></td>");
                //    sbRecord.Append("</tr>");
                //    sbRecord.Append("<tr><td colspan='2'>&nbsp;</td></tr>");

                //}
                #endregion


            }
        }
        else
        {
            sbRecord.Append("<tr><td align='left' valign='bottom' width='100%'>" + Style + "No Record Found </span></td></tr>");
        }
        sbRecord.Append("</table>");
        return sbRecord.ToString();
    }

    private string getMonth(string StrMonth)
    {
        string MonthName = "";
        if (StrMonth == "1")
            MonthName = "January";
        if (StrMonth == "2")
            MonthName = "February";
        if (StrMonth == "3")
            MonthName = "March";
        if (StrMonth == "4")
            MonthName = "April";
        if (StrMonth == "5")
            MonthName = "May";
        if (StrMonth == "6")
            MonthName = "June";
        if (StrMonth == "7")
            MonthName = "July";
        if (StrMonth == "8")
            MonthName = "August";
        if (StrMonth == "9")
            MonthName = "September";
        if (StrMonth == "10")
            MonthName = "October";
        if (StrMonth == "11")
            MonthName = "November";
        if (StrMonth == "12")
            MonthName = "December";
        return MonthName;
    }
    private string SetYesNoNone(string Value)
    {
        string strYesNo = "";
        if (Value == "2")
            strYesNo = "None";
        else if (Value == "1")
            strYesNo = "Yes";
        else if (Value == "0")
            strYesNo = "No";
        else if (Value == "Y")
            strYesNo = "Yes";
        else if (Value == "N")
            strYesNo = "No";
        return strYesNo;
    }

    private static string GetOpenObservationAttachmetHTML(DataTable dtTable_Name)
    {
        StringBuilder sbHTML = new StringBuilder();
        DataTable dtAttachments = dtTable_Name;
        int intTotal = dtAttachments.Rows.Count;
        string Style = "<span style='font-size: 11pt; font-weight: normal; font-family: Calibri'>";
        if (intTotal > 0)
        {
            sbHTML.Append("<table width=\"100%\" cellpadding=\"0\" cellspacing=\"0\" border=\"0\">");
            for (int i = 0; i < dtAttachments.Rows.Count; i++)
            {
                string strFileName = Convert.ToString(dtAttachments.Rows[i]["Attachment_Filename"]);
                if (i % 2 == 0)
                {
                    sbHTML.Append("<tr>");
                }
                sbHTML.Append("<td width=\"50%\" valign=\"top\">");
                sbHTML.Append("<table width=\"100%\" cellpadding=\"5\" cellspacing=\"0\" border=\"0\" >");
                sbHTML.Append("<tr>");
                sbHTML.Append("<td align=\"left\">" + Style + "");
                sbHTML.Append("<b>File Name :</b>");
                sbHTML.Append(strFileName.Substring(12, (strFileName.Length - 1) - 11));
                sbHTML.Append("</span></td>");
                sbHTML.Append("</tr>");
                sbHTML.Append("<tr>");
                sbHTML.Append("<td align=\"left\">");

                if (File.Exists(strSafetyWalkDir + "\\" + strFileName))
                {
                    //sbHTML.Append("<img src='"  + strSafetyTempDir + "/" + strFileName.Replace("#", "%23") + "'");
                    sbHTML.Append("<img src='" + strSafetyWalkDir + "/" + strFileName + "'");
                    sbHTML.Append("width=\"300\" height=\"200\" style=\"border: solid 1px black;\" />");
                }
                else
                {
                    sbHTML.Append("<img src='" + AppConfig.ImageURL + "/NoImage.jpg'");
                    sbHTML.Append("width=\"110\" height=\"110\" style=\"border: solid 1px black;\" />");
                }

                sbHTML.Append("</td>");
                sbHTML.Append("</tr>");
                sbHTML.Append("</table>");
                sbHTML.Append("</td>");
                //if (i % 2 > 0)
                //{
                //    sbHTML.Append("</tr>");
                //}
                if (i % 2 == 0)
                {
                    sbHTML.Append("</tr>");
                }
            }
            sbHTML.Append("</table>");
        }
        return sbHTML.ToString();
    }

    private static string GetAttachmetHTML(string Table_Name, decimal FK)
    {
        StringBuilder sbHTML = new StringBuilder();
        DataTable dtAttachments = ERIMSAttachment.SelectByAttachmentImageTableName(Table_Name, FK).Tables[0];
        int intTotal = dtAttachments.Rows.Count;
        string Style = "<span style='font-size: 11pt; font-weight: normal; font-family: Calibri'>";
        if (intTotal > 0)
        {
            sbHTML.Append("<table width=\"100%\" cellpadding=\"0\" cellspacing=\"0\" border=\"0\">");
            for (int i = 0; i < dtAttachments.Rows.Count; i++)
            {
                string strFileName = Convert.ToString(dtAttachments.Rows[i]["Attachment_Name"]);
                if (i % 2 == 0)
                {
                    sbHTML.Append("<tr>");
                }
                sbHTML.Append("<td width=\"50%\" valign=\"top\">");
                sbHTML.Append("<table width=\"100%\" cellpadding=\"5\" cellspacing=\"0\" border=\"0\" >");
                sbHTML.Append("<tr>");
                sbHTML.Append("<td align=\"left\">" + Style + "");
                sbHTML.Append("<b>File Name :</b>");
                sbHTML.Append(strFileName.Substring(12, (strFileName.Length - 1) - 11));
                sbHTML.Append("</span></td>");
                sbHTML.Append("</tr>");
                sbHTML.Append("<tr>");
                sbHTML.Append("<td align=\"left\">");
                if (Table_Name == "SLT_Safety_Walk")
                {
                    if (File.Exists(strSafetyTempDir + "\\" + strFileName))
                    {
                        //sbHTML.Append("<img src='"  + strSafetyTempDir + "/" + strFileName.Replace("#", "%23") + "'");
                        sbHTML.Append("<img src='" + strSafetyTempDir + "/" + strFileName + "'");
                        sbHTML.Append("width=\"300\" height=\"200\" style=\"border: solid 1px black;\" />");
                    }
                    else
                    {
                        sbHTML.Append("<img src='" + AppConfig.ImageURL + "/NoImage.jpg'");
                        sbHTML.Append("width=\"110\" height=\"110\" style=\"border: solid 1px black;\" />");
                    }
                }
                else if (Table_Name == "SLT_Training")
                {
                    if (File.Exists(strTrainingTempDir + "\\" + strFileName))
                    {
                        //sbHTML.Append("<img src='" + strTrainingTempDir + "/" + strFileName.Replace("#", "%23") + "'");
                        sbHTML.Append("<img src='" + strTrainingTempDir + "/" + strFileName + "'");
                        sbHTML.Append("width=\"300\" height=\"200\" style=\"border: solid 1px black;\" />");
                    }
                    else
                    {
                        sbHTML.Append("<img src='" + AppConfig.ImageURL + "/NoImage.jpg'");
                        sbHTML.Append("width=\"110\" height=\"110\" style=\"border: solid 1px black;\" />");
                    }
                }
                sbHTML.Append("</td>");
                sbHTML.Append("</tr>");
                sbHTML.Append("</table>");
                sbHTML.Append("</td>");
                if (i % 2 > 0)
                {
                    sbHTML.Append("</tr>");
                }
            }
            sbHTML.Append("</table>");
        }
        return sbHTML.ToString();
    }

    private static void ResizeAllImages(decimal FK, string strTable)
    {
        DataTable dtImages = ERIMSAttachment.SelectByAttachmentImageTableName(strTable, FK).Tables[0];
        if (strTable == "SLT_Safety_Walk")
        {
            if (!Directory.Exists(strSafetyTempDir))
            {
                Directory.CreateDirectory(strSafetyTempDir);
            }

            if (dtImages.Rows.Count > 0)
            {
                foreach (DataRow drImage in dtImages.Rows)
                {
                    string strOriginalFile = AppConfig.strSLT_SafetyWalkDocPath + Convert.ToString(drImage["Attachment_Name"]);
                    if (File.Exists(strOriginalFile))
                    {
                        string strNewFile = strSafetyTempDir + "\\" + Convert.ToString(drImage["Attachment_Name"]);
                        ResizeImage(strOriginalFile, strNewFile, 300, 200, true);
                    }
                }
            }
        }
        else if (strTable == "SLT_Training")
        {
            if (!Directory.Exists(strTrainingTempDir))
            {
                Directory.CreateDirectory(strTrainingTempDir);
            }

            if (dtImages.Rows.Count > 0)
            {
                foreach (DataRow drImage in dtImages.Rows)
                {
                    string strOriginalFile = AppConfig.strSLT_TrainingDocsPath + Convert.ToString(drImage["Attachment_Name"]);
                    if (File.Exists(strOriginalFile))
                    {
                        string strNewFile = strTrainingTempDir + "\\" + Convert.ToString(drImage["Attachment_Name"]);
                        ResizeImage(strOriginalFile, strNewFile, 300, 200, true);
                    }
                }
            }
        }
    }

    private static void ResizeImage(string OriginalFile, string NewFile, int NewWidth, int MaxHeight, bool OnlyResizeIfWider)
    {
        System.Drawing.Image FullsizeImage = System.Drawing.Image.FromFile(OriginalFile);

        // Prevent using images internal thumbnail
        FullsizeImage.RotateFlip(System.Drawing.RotateFlipType.Rotate180FlipNone);
        FullsizeImage.RotateFlip(System.Drawing.RotateFlipType.Rotate180FlipNone);

        if (OnlyResizeIfWider)
        {
            if (FullsizeImage.Width <= NewWidth)
            {
                NewWidth = FullsizeImage.Width;
            }
        }

        int NewHeight = FullsizeImage.Height * NewWidth / FullsizeImage.Width;
        if (NewHeight > MaxHeight)
        {
            // Resize with height instead
            NewWidth = FullsizeImage.Width * MaxHeight / FullsizeImage.Height;
            NewHeight = MaxHeight;
        }

        System.Drawing.Image NewImage = FullsizeImage.GetThumbnailImage(NewWidth, NewHeight, null, IntPtr.Zero);

        // Clear handle to original file so that we can overwrite it if necessary
        FullsizeImage.Dispose();

        // Save resized picture
        NewImage.Save(NewFile);
    }

    #endregion

}