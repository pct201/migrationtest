using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Drawing;
using ERIMS.DAL;
using System.Text;
using System.IO;
using System.Net;
using System.Net.Mail;

/// <summary>
/// Summary description for InspectionWordDocument
/// </summary>
public class InspectionWordDocument
{
    private static string strDocumentFolder = ConfigurationManager.AppSettings["AttachmentDocs"];
    private static string strTempDirName = HttpContext.Current.Session.SessionID;
    public static string strTempDir = AppConfig.SitePath + strDocumentFolder + "\\" + strTempDirName;

    public InspectionWordDocument()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    private decimal GetAttachmentSize(int PK_Inspection_ID)
    {
        DataTable dtAttach = Inspection_Attachments.SelectByFK(PK_Inspection_ID).Tables[0];
        long _FileZise = 0;
        foreach (DataRow dr in dtAttach.Rows)
        {
            if (dr["FileName"] != DBNull.Value && dr["FileName"] != null)
            {
                FileInfo fiFile = new FileInfo(AppConfig.InspectionDocPath + dr["FileName"].ToString());

                if (fiFile.Exists && (fiFile.Extension.ToLower().Equals(".jpg") || fiFile.Extension.ToLower().Equals(".gif") || fiFile.Extension.ToLower().Equals(".png")))

                    _FileZise += fiFile.Length;
            }
        }

        dtAttach = Inspection_Attachments.SelectForMail(PK_Inspection_ID).Tables[0];
        foreach (DataRow dr in dtAttach.Rows)
        {
            if (dr["FileName"] != DBNull.Value && dr["FileName"] != null)
            {
                FileInfo fiFile = new FileInfo(AppConfig.InspectionFocusAreaDocPath + dr["FileName"].ToString());

                if (fiFile.Exists && (fiFile.Extension.ToLower().Equals(".jpg") || fiFile.Extension.ToLower().Equals(".gif") || fiFile.Extension.ToLower().Equals(".png")))
                    _FileZise += fiFile.Length;
            }
        }

        return (_FileZise / 1048576.00M);
    }


    public static string PrepareMailForSend(int PK_Inspection_ID)
    {
        StringBuilder sb = new StringBuilder();
        if (PK_Inspection_ID > 0)
        {
            InspectionWordDocument objDocument = new InspectionWordDocument();
            objDocument.ResizeAllInspectionImages(PK_Inspection_ID);

            Inspection objInspection = new Inspection(PK_Inspection_ID);
            DataTable dtInspection = Inspection.SelectQuestionsAndResposnses(PK_Inspection_ID).Tables[0];
            dtInspection.DefaultView.RowFilter = "Deficiency_Noted='Y'";
            dtInspection = dtInspection.DefaultView.ToTable();
            if (dtInspection.Rows.Count > 0)
            {
                decimal intLocation = Convert.ToDecimal(dtInspection.Rows[0]["FK_LU_Location_ID"]);
                LU_Location objLocation = new LU_Location(intLocation);
                string strState = objLocation.State != "" ? new State(Convert.ToDecimal(objLocation.State)).FLD_state : "";
                sb.Append("<table cellpadding='3' cellspacing=1 border=0 width='100%'  style='background-color:Black'>");
                sb.Append("<tr style='background-color:#95B3D7;color:White;font-weight:bold;font-size:13px;'>");
                sb.Append("<td width='17%' align='left' style='background-color:#95B3D7;color:White;font-weight:bold;font-size:13px;border-top:black 1px solid;border-left:black 1px solid;'><span style='color:white'><b>Location Number</b></span> </td>");
                sb.Append("<td width='23%' align='left' style='background-color:#95B3D7;color:White;font-weight:bold;font-size:13px;border-top:black 1px solid;border-left:black 1px solid;'><span style='color:white'><b>Sonic Location D/B/A</b></span></td>");
                sb.Append("<td width='22%' align='left' style='background-color:#95B3D7;color:White;font-weight:bold;font-size:13px;border-top:black 1px solid;border-left:black 1px solid;'><span style='color:white'><b>Address</b></span></td>");
                sb.Append("<td width='15%' align='left' style='background-color:#95B3D7;color:White;font-weight:bold;font-size:13px;border-top:black 1px solid;border-left:black 1px solid;'><span style='color:white'><b>City</b></span></td>");
                sb.Append("<td width='12%' align='left' style='background-color:#95B3D7;color:White;font-weight:bold;font-size:13px;border-top:black 1px solid;border-left:black 1px solid;'><span style='color:white'><b>State</b></span></td>");
                sb.Append("<td width='11%' align='left' style='background-color:#95B3D7;color:White;font-weight:bold;font-size:13px;border-top:black 1px solid;border-left:black 1px solid;border-right:black 1px solid;'><span style='color:white'><b>Zip</b></span></td>");
                sb.Append("</tr>");
                sb.Append("<tr style='background-color:White;'>");
                sb.Append("<td width='17%' align='left' style='background-color:White;border-top:black 1px solid;border-left:black 1px solid;border-bottom:black 1px solid' nowarp='nowarp' >" + objLocation.Sonic_Location_Code + "</td>");
                sb.Append("<td width='23%' align='left' style='background-color:White;border-top:black 1px solid;border-left:black 1px solid;border-bottom:black 1px solid' nowarp='nowarp'>" + objLocation.dba + "</td>");
                sb.Append("<td width='22%' align='left' style='background-color:White;border-top:black 1px solid;border-left:black 1px solid;border-bottom:black 1px solid' nowarp='nowarp'>" + objLocation.Address_1 + "</td>");
                sb.Append("<td width='15%' align='left' style='background-color:White;border-top:black 1px solid;border-left:black 1px solid;border-bottom:black 1px solid' nowarp='nowarp'>" + objLocation.City + "</td>");
                sb.Append("<td width='12%' align='left' style='background-color:White;border-top:black 1px solid;border-left:black 1px solid;border-bottom:black 1px solid' nowarp='nowarp'>" + strState + "</td>");
                sb.Append("<td width='11%' align='left' style='background-color:White;border-top:black 1px solid;border-left:black 1px solid;border-bottom:black 1px solid;border-right:black 1px solid;'nowarp='nowarp'>" + objLocation.Zip_Code + "</td>");

                sb.Append("</tr>");
                sb.Append("</table>");
                sb.Append("</br>");
            }
            else
            {
                decimal intLocation = Convert.ToDecimal(objInspection.FK_LU_Location_ID);
                LU_Location objLocation = new LU_Location(intLocation);
                string strState = objLocation.State != "" ? new State(Convert.ToDecimal(objLocation.State)).FLD_state : "";
                sb.Append("<table cellpadding='3' cellspacing=1 border=0 width='100%'  style='background-color:Black'>");
                sb.Append("<tr style='background-color:#95B3D7;color:White;font-weight:bold;font-size:13px;'>");
                sb.Append("<td width='17%' align='left' style='background-color:#95B3D7;color:White;font-weight:bold;font-size:13px;border-top:black 1px solid;border-left:black 1px solid;'><span style='color:white'><b>Location Number</b></span> </td>");
                sb.Append("<td width='23%' align='left' style='background-color:#95B3D7;color:White;font-weight:bold;font-size:13px;border-top:black 1px solid;border-left:black 1px solid;'><span style='color:white'><b>Sonic Location D/B/A</b></span></td>");
                sb.Append("<td width='22%' align='left' style='background-color:#95B3D7;color:White;font-weight:bold;font-size:13px;border-top:black 1px solid;border-left:black 1px solid;'><span style='color:white'><b>Address</b></span></td>");
                sb.Append("<td width='15%' align='left' style='background-color:#95B3D7;color:White;font-weight:bold;font-size:13px;border-top:black 1px solid;border-left:black 1px solid;'><span style='color:white'><b>City</b></span></td>");
                sb.Append("<td width='12%' align='left' style='background-color:#95B3D7;color:White;font-weight:bold;font-size:13px;border-top:black 1px solid;border-left:black 1px solid;'><span style='color:white'><b>State</b></span></td>");
                sb.Append("<td width='11%' align='left' style='background-color:#95B3D7;color:White;font-weight:bold;font-size:13px;border-top:black 1px solid;border-left:black 1px solid;border-right:black 1px solid;'><span style='color:white'><b>Zip</b></span></td>");
                sb.Append("</tr>");
                sb.Append("<tr style='background-color:White;'>");
                sb.Append("<td width='17%' align='left' style='background-color:White;border-top:black 1px solid;border-left:black 1px solid;border-bottom:black 1px solid' nowarp='nowarp' >" + objLocation.Sonic_Location_Code + "</td>");
                sb.Append("<td width='23%' align='left' style='background-color:White;border-top:black 1px solid;border-left:black 1px solid;border-bottom:black 1px solid' nowarp='nowarp'>" + objLocation.dba + "</td>");
                sb.Append("<td width='22%' align='left' style='background-color:White;border-top:black 1px solid;border-left:black 1px solid;border-bottom:black 1px solid' nowarp='nowarp'>" + objLocation.Address_1 + "</td>");
                sb.Append("<td width='15%' align='left' style='background-color:White;border-top:black 1px solid;border-left:black 1px solid;border-bottom:black 1px solid' nowarp='nowarp'>" + objLocation.City + "</td>");
                sb.Append("<td width='12%' align='left' style='background-color:White;border-top:black 1px solid;border-left:black 1px solid;border-bottom:black 1px solid' nowarp='nowarp'>" + strState + "</td>");
                sb.Append("<td width='11%' align='left' style='background-color:White;border-top:black 1px solid;border-left:black 1px solid;border-bottom:black 1px solid;border-right:black 1px solid;'nowarp='nowarp'>" + objLocation.Zip_Code + "</td>");

                sb.Append("</tr>");
                sb.Append("</table>");
                sb.Append("</br>");
            }

            sb.Append("<table cellpadding=0 cellspacing=0 width=100%>");
            sb.Append("<tr><td style='height:30px;' valign='middle' align='center'>");
            sb.Append("<b>Only Questions with Deficiency Noted are Shown</b><br />");
            sb.Append("</td></tr></table>");

            sb.Append("<table cellpadding='3' cellspacing=1 border=0 width='100%'><tr>");
            sb.Append("<td width='15%' align='left'>Inspection Date</td>");
            sb.Append("<td width='4%' align='center'>:</td>");
            sb.Append("<td width='31%' align='left'>" + clsGeneral.FormatDateToDisplay(objInspection.date) + "</td>");
            sb.Append("<td width='15%' align='left'>Inspector Name</td>");
            sb.Append("<td width='4%' align='center'>:</td>");
            sb.Append("<td width='31%' align='left'>" + objInspection.Inspector_Name + "</td></tr>");

            sb.Append("<tr>");
            sb.Append("<td width='15%' align='left' valign=\"top\">Inspection Area</td>");
            sb.Append("<td width='4%' align='center' valign=\"top\">:</td>");
            sb.Append("<td width='31%' align='left' valign=\"top\">" + Convert.ToString(objInspection.Fld_Desc) + "</td>");
            sb.Append("<td align=\"left\" valign=\"top\">Date Inspection Report was Initially Distributed</td>");
            sb.Append("<td align=\"center\" valign=\"top\">:</td>");
            sb.Append("<td align=\"left\" valign=\"top\">" + clsGeneral.FormatDBNullDateToDisplay(objInspection.Date_Report_Initially_Distibuted) + "</td></tr>");
            sb.Append("<tr>");
            sb.Append("<td align=\"left\" valign=\"top\">Number of Deficiencies for this Inspection</td>");
            sb.Append("<td align=\"center\" valign=\"top\">:</td>");
            sb.Append("<td align=\"left\" valign=\"top\">" + Convert.ToString(Inspection.GetNumberOfDeficiencies(PK_Inspection_ID)) + "</td>");
            sb.Append("<td align=\"left\" valign=\"top\">Number of Repeat Deficiencies Noted on this Inspection</td>");
            sb.Append("<td align=\"center\" valign=\"top\">:</td>");
            sb.Append("<td align=\"left\" valign=\"top\">" + Convert.ToString(Inspection.GetNumberOfRepeat_Deficiency(PK_Inspection_ID)) + "</td></tr>");
            sb.Append("<tr><td align='left'>RLCM Verified?</td><td align='center'>:</td>");
            sb.Append("<td align='left'>" + (objInspection.RLCM_Verified == "Y" ? "Yes" : "No") + "</td>");
            sb.Append("<td align=\"left\">No Deficiencies Found</td>");
            sb.Append("<td align=\"center\">:</td>");
            sb.Append("<td align=\"left\">" + (objInspection.No_Deficiencies ? "Yes" : "No") + "</td>");
            sb.Append("</tr><tr><td align=\"left\" valign=\"top\">Overall Inspection Comments</td>");
            sb.Append("<td align=\"center\" valign=\"top\">:</td>");
            sb.Append("<td align=\"left\" valign=\"top\" colspan=\"4\">" + objInspection.Overall_Inspection_Comments + "</td></tr>");
            sb.Append("<tr><td colspan='3'>&nbsp;</td></tr>");
            sb.Append("<tr><td align='left' ><b>Focus Area</b></td><td align='center'>&nbsp;</td>");
            sb.Append("<td align='left'><b>Question Text</b></td><td align='left'>&nbsp;</td><td align='center'>&nbsp;</td>");
            sb.Append("<td align='center'><b>Deficiency</b></td></tr>");
            sb.Append("<tr><td align=left colspan=6>");
            sb.Append("<table cellspacing=0 cellpadding=0 border=0 width='100%'>");

            string strFocusArea = "";
            foreach (DataRow drInspection in dtInspection.Rows)
            {
                sb.Append("<tr valign=top>");
                sb.Append("<td valign=top style='width:19%;'><span " + ((Convert.ToString(drInspection["ShowFocusAreaRed"]) == "Y") ? "style='color:red'>" : ">") +
                    drInspection["Focus_Area"].ToString() + "</span></td>");
                sb.Append("<td valign='top' style='width:81%;'>");
                sb.Append("<table cellpadding=2 cellspacing=1 width='100%'><tr>");
                sb.Append("<td width='3%' align='left' valign='top'>" + Convert.ToString(drInspection["Question_Number"]) + "</td>");
                sb.Append("<td width='75%' align='left' valign='top'>" + Convert.ToString(drInspection["Question_Text"]) + "</td>");
                sb.Append("<td align=left valign='top'>&nbsp;&nbsp;" + (Convert.ToString(drInspection["Deficiency_Noted"]) == "Y" ? "YES" : "NO") + "</td>");
                sb.Append("</tr><tr><td>&nbsp;</td><td align='left' colspan=2><b>Guidance</b></td></tr>");
                sb.Append("<tr><td>&nbsp;</td><td align='left' colspan=2>");
                sb.Append("<table cellpadding=0 cellspacing=0 width='100%'>");
                sb.Append("<tr><td width='100%'>" + Convert.ToString(drInspection["Guidance_Text"]) + "</td></tr>");
                if (Convert.ToString(drInspection["Deficiency_Noted"]) == "Y" && Convert.ToString(drInspection["Deficient_Answer"]) == "Y")
                {
                    string strDateOpened = Convert.ToString(drInspection["Date_Opened"]);
                    string strActual_Completion_Date = Convert.ToString(drInspection["Actual_Completion_Date"]);
                    DateTime? dtDateOpened;
                    if (strDateOpened != null && strDateOpened != "")
                        dtDateOpened = Convert.ToDateTime(strDateOpened);
                    else
                        dtDateOpened = AppConfig.SqlMinDateValue;
                    string strDays = "";
                    if (strDateOpened != "" && strActual_Completion_Date != "")
                    {

                        DateTime dtDateActual = Convert.ToDateTime(strActual_Completion_Date);
                        if (dtDateOpened != AppConfig.SqlMinDateValue && dtDateActual != AppConfig.SqlMinDateValue)
                        {
                            TimeSpan ts = dtDateActual - (DateTime)dtDateOpened;
                            if (ts.Days >= 0)
                                strDays = ts.Days.ToString();
                        }

                    }

                    sb.Append("<tr><td><table cellpadding=3 cellspacing=1 width='100%'>");
                    sb.Append("<tr><td width='18%' align='left' valign='top'>Repeat Deficiency?</td>");
                    sb.Append("<td width='4%' align='center' valign='top'>:</td>");
                    sb.Append("<td align='left' valign='top'>" + ((Convert.ToString(drInspection["Repeat_Deficiency"]) == "Y") ? "Yes" : "No") + "</td>");
                    sb.Append("<td colspan='3'>&nbsp;</td></tr>");
                    sb.Append("<tr>");
                    sb.Append("<td width='18%' align='left' valign='top'>Department</td>");
                    sb.Append("<td width='4%' align='center' valign='top'>:</td>");
                    sb.Append("<td align='left' valign='top' colspan='4'>");
                    sb.Append(GetDepartmetsHTML(Convert.ToString(drInspection["Department"])));
                    sb.Append("</td></tr>");

                    sb.Append("<tr>");
                    sb.Append("<td align='left' valign='top'>Date opened</td>");
                    sb.Append("<td align='center' valign='top'>:</td>");
                    sb.Append("<td align='left' valign='top'>" + (dtDateOpened != null ? clsGeneral.FormatDateToDisplay((DateTime)dtDateOpened) : "") + "</td>");
                    sb.Append("<td width='18%' align='left' valign='top'>Days Open</td>");
                    sb.Append("<td width='4%' align='center' valign='top'>:</td>");
                    sb.Append("<td width='28%' align='left' valign='top'>" + strDays + "</td>");
                    sb.Append("</tr>");

                    sb.Append("<tr><td align=left colspan=6>Recommended Action:</td></tr>");
                    sb.Append("<tr><td align=left colspan=6>" + Convert.ToString(drInspection["Recommended_Action"]) + "</td></tr>");

                    sb.Append("<tr>");
                    sb.Append("<td align='left' valign='top'>Target Completion Date</td>");
                    sb.Append("<td align='center' valign='top'>:</td>");
                    sb.Append("<td align='left' valign='top'>" + (drInspection["Target_Completion_Date"] != DBNull.Value ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drInspection["Target_Completion_Date"])) : "") + "</td>");
                    sb.Append("<td align='left' valign='top'>Actual Completion Date</td>");
                    sb.Append("<td align='center' valign='top'>:</td>");
                    sb.Append("<td align='left' valign='top'>" + (drInspection["Actual_Completion_Date"] != DBNull.Value ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drInspection["Actual_Completion_Date"])) : "") + "</td>");
                    sb.Append("</tr>");

                    sb.Append("<tr><td align=left colspan=6>Notes:</td></tr>");
                    sb.Append("<tr><td align=left colspan=6>" + Convert.ToString(drInspection["Notes"]) + "</td></tr>");

                    if (strFocusArea != Convert.ToString(drInspection["Focus_Area"]))
                    {
                        sb.Append("<tr><td align=left colspan=6>");
                        sb.Append(GetAttachmetHTML(Convert.ToString(drInspection["Focus_Area"]), PK_Inspection_ID));
                        sb.Append("</td></tr>");
                    }

                    sb.Append("</table>");
                    sb.Append("</td></tr>");

                }
                sb.Append("</table>");
                sb.Append("</td></tr>");
                sb.Append("</table></td></tr>");
            }
            sb.Append("</table>");
            sb.Append("</td></tr></table>");
            //System.IO.StringWriter stringWrite = new System.IO.StringWriter();
            //System.Web.UI.HtmlTextWriter htmlWrite = new System.Web.UI.HtmlTextWriter(stringWrite);
            ////Write HTML in to HtmlWriter
            //htmlWrite.WriteLine(sb.ToString());


            // String strMailFrom = new Security(Convert.ToDecimal(clsSession.UserID)).Email;

            //Send Mail
            // SendMail("InspectionReport" + Session.SessionID + ".doc", strMailFrom, sb, _IsAttachment);
        }
               

        return sb.ToString();
    }
    private static string GetAttachmetHTML(string strFocusArea, int PK_Inspection_ID)
    {
        StringBuilder sbHTML = new StringBuilder();
        DataTable dtAttachments = Inspection_Responses_Attachments.SelectImagesByFocusArea(strFocusArea, PK_Inspection_ID).Tables[0];
        int intTotal = dtAttachments.Rows.Count;

        if (intTotal > 0)
        {
            sbHTML.Append("<table width=\"100%\" cellpadding=\"0\" cellspacing=\"0\" border=\"0\">");
            for (int i = 0; i < dtAttachments.Rows.Count; i++)
            {
                string strFileName = Convert.ToString(dtAttachments.Rows[i]["FileName"]);
                if (i % 2 == 0)
                {
                    sbHTML.Append("<tr>");
                }
                sbHTML.Append("<td width=\"50%\" valign=\"top\">");
                sbHTML.Append("<table width=\"100%\" cellpadding=\"5\" cellspacing=\"0\" border=\"0\" >");
                sbHTML.Append("<tr>");
                sbHTML.Append("<td align=\"left\">");
                sbHTML.Append("<b>File Name :</b>");
                sbHTML.Append(strFileName.Substring(12, (strFileName.Length - 1) - 11));
                sbHTML.Append("</td>");
                sbHTML.Append("</tr>");
                sbHTML.Append("<tr>");
                sbHTML.Append("<td align=\"left\">");

                if (File.Exists(strTempDir + "\\" + strFileName))
                {
                    string imageName = AppConfig.SiteURL + strDocumentFolder + "/" + strTempDirName + "/" + strFileName;
                    if (strFileName.Contains("#") || strFileName.Contains("%"))
                    {
                        string extenstion = Path.GetExtension(imageName).Replace(".", "");
                        WebClient wClient = new WebClient();
                        byte[] imgData = wClient.DownloadData(imageName.Replace("#", "%23"));
                        sbHTML.Append("<img src='data:image/" + extenstion + ";base64," + Convert.ToBase64String(imgData) + "'");
                    }
                    else
                    {
                        sbHTML.Append("<img src='" + imageName + "'");

                    }
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
                if (i % 2 > 0)
                {
                    sbHTML.Append("</tr>");
                }
            }
            sbHTML.Append("</table>");
        }
        return sbHTML.ToString();
    }
    private static string GetDepartmetsHTML(string strDepartments)
    {
        string strHTML = "";

        if (strDepartments != string.Empty)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<table cellpadding=1 cellspacing=1 width='100%'>");
            sb.Append("<tr>");
            sb.Append("<td width='20%' align='left'>Sales</td>");
            sb.Append("<td width='13%' align='left'>" + (strDepartments.IndexOf("1") > -1 ? "Yes" : "No") + "</td>");
            sb.Append("<td width='20%' align='left'>Business Offices</td>");
            sb.Append("<td width='13%' align='left'>" + (strDepartments.IndexOf("5") > -1 ? "Yes" : "No") + "</td>");
            sb.Append("<td width='20%' align='left'>Parking Lot</td>");
            sb.Append("<td align='left'>" + (strDepartments.IndexOf("8") > -1 ? "Yes" : "No") + "</td>");
            sb.Append("<tr>");

            sb.Append("<tr>");
            sb.Append("<td align='left'>Parts</td>");
            sb.Append("<td align='left'>" + (strDepartments.IndexOf("2") > -1 ? "Yes" : "No") + "</td>");
            sb.Append("<td align='left'>Detail Area</td>");
            sb.Append("<td align='left'>" + (strDepartments.IndexOf("6") > -1 ? "Yes" : "No") + "</td>");
            sb.Append("<td align='left'>Roof</td>");
            sb.Append("<td align='left'>" + (strDepartments.IndexOf("9") > -1 ? "Yes" : "No") + "</td>");
            sb.Append("<tr>");

            sb.Append("<tr>");
            sb.Append("<td align='left'>Service Facility</td>");
            sb.Append("<td align='left'>" + (strDepartments.IndexOf("3") > -1 ? "Yes" : "No") + "</td>");
            sb.Append("<td align='left'>Car Wash</td>");
            sb.Append("<td align='left'>" + (strDepartments.IndexOf("7") > -1 ? "Yes" : "No") + "</td>");
            sb.Append("<td align='left'>Service Drive</td>");
            sb.Append("<td align='left'>" + (strDepartments.IndexOf("10") > -1 ? "Yes" : "No") + "</td>");
            sb.Append("<tr>");

            sb.Append("<tr>");
            sb.Append("<td align='left'>Body Shop</td>");
            sb.Append("<td align='left'>" + (strDepartments.IndexOf("4") > -1 ? "Yes" : "No") + "</td>");
            sb.Append("<td align='left' colspan=4>&nbsp;</td>");

            sb.Append("</table>");
            strHTML = sb.ToString();
        }

        return strHTML;

    }
    private decimal GetAttachmentSize(int PK_Inspection_ID, ref ArrayList strAttachmentPath)
    {
        DataTable dtAttach = Inspection_Attachments.SelectByFK(PK_Inspection_ID).Tables[0];
        long _FileZise = 0;
        foreach (DataRow dr in dtAttach.Rows)
        {
            if (dr["FileName"] != DBNull.Value && dr["FileName"] != null)
            {
                FileInfo fiFile = new FileInfo(AppConfig.InspectionDocPath + dr["FileName"].ToString());

                if (fiFile.Exists && (fiFile.Extension.ToLower().Equals(".jpg") || fiFile.Extension.ToLower().Equals(".gif") || fiFile.Extension.ToLower().Equals(".png")))
                {
                    strAttachmentPath.Add(fiFile.FullName);
                    _FileZise += fiFile.Length;
                }
            }
        }

        dtAttach = Inspection_Attachments.SelectForMail(PK_Inspection_ID).Tables[0];
        foreach (DataRow dr in dtAttach.Rows)
        {
            if (dr["FileName"] != DBNull.Value && dr["FileName"] != null)
            {
                FileInfo fiFile = new FileInfo(AppConfig.InspectionFocusAreaDocPath + dr["FileName"].ToString());

                if (fiFile.Exists && (fiFile.Extension.ToLower().Equals(".jpg") || fiFile.Extension.ToLower().Equals(".gif") || fiFile.Extension.ToLower().Equals(".png")))
                {
                    strAttachmentPath.Add(fiFile.FullName);
                    _FileZise += fiFile.Length;
                }
            }
        }

        return (_FileZise / 1048576.00M);
    }

    ///// <summary>
    ///// Resize source image to specifed sze
    ///// </summary>
    ///// <param name="sourceImage">Source image</param>
    ///// <param name="targetWidth">Target width</param>
    ///// <param name="targetHeight">Target height</param>
    ///// <returns>Resized image</returns>
    //public static Image ResizeImage(Image sourceImage, int targetWidth, int targetHeight)
    //{
    //    float ratioWidth = (float)sourceImage.Width / targetWidth;
    //    float ratioHeight = (float)sourceImage.Height / targetHeight;
    //    if (ratioWidth > ratioHeight)
    //        targetHeight = (int)(targetHeight * (ratioHeight / ratioWidth));
    //    else
    //    {
    //        if (ratioWidth < ratioHeight)
    //            targetWidth = (int)(targetWidth * (ratioWidth / ratioHeight));
    //    }


    //    // create target image
    //    Bitmap targetImage = new Bitmap(targetWidth, targetHeight, PixelFormat.Format24bppRgb);
    //    // set transform parameters 
    //    using (Graphics g = Graphics.FromImage(targetImage))
    //    {
    //        g.CompositingQuality = CompositingQuality.HighQuality;
    //        g.SmoothingMode = SmoothingMode.HighQuality;
    //        g.InterpolationMode = InterpolationMode.HighQualityBicubic;
    //        // resize image
    //        Rectangle rc = new Rectangle(0, 0, targetImage.Width, targetImage.Height);
    //        g.DrawImage(sourceImage, rc);
    //    }
    //    return (Image)targetImage;
    //}

    private void ResizeAllInspectionImages(int PK_Inspection_ID)
    {
        DataTable dtImages = Inspection_Responses_Attachments.SelectImagesByInspection(PK_Inspection_ID).Tables[0];

        if (!Directory.Exists(strTempDir))
        {
            Directory.CreateDirectory(strTempDir);
        }

        if (dtImages.Rows.Count > 0)
        {
            foreach (DataRow drImage in dtImages.Rows)
            {
                string strOriginalFile = AppConfig.InspectionFocusAreaDocPath + Convert.ToString(drImage["FileName"]);
                if (File.Exists(strOriginalFile))
                {
                    string strNewFile = strTempDir + "\\" + Convert.ToString(drImage["FileName"]);
                    ResizeImage(strOriginalFile, strNewFile, 300, 200, true);
                }
            }
        }
    }

    private void ResizeImage(string OriginalFile, string NewFile, int NewWidth, int MaxHeight, bool OnlyResizeIfWider)
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


}
