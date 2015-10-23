using System;
using System.Data;
using System.Web;
using System.Web.Security;
using ERIMS.DAL;
using System.IO;
using System.Text;
using Microsoft.VisualBasic;

/// <summary>
/// Summary description for AbstractLetters
/// </summary>
public class AbstractLetters
{
    private static string strStyle = "style='font-family: Arial; font-size: 12px;'";
    public AbstractLetters()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public static StringBuilder Event_AbstactReport(decimal _PK_Event, bool ShowAttachments, clsGeneral.Major_Coverage MajorCoverageType)
    {
        DataSet dsEvent = clsEvent.GetEventAbstractLetterData(_PK_Event);

        StringBuilder strBody = new StringBuilder("");

        if (dsEvent != null && dsEvent.Tables.Count > 0 && dsEvent.Tables[0].Rows.Count > 0)
        {
            DataTable dtEvent = dsEvent.Tables[0];
            DataTable dtActionable_Event = dsEvent.Tables[1];
            DataTable dtBuilding = dsEvent.Tables[2];
            DataTable dtCamera = dsEvent.Tables[3];
            DataTable dtACINotes = dsEvent.Tables[4];
            DataTable dtSonicNotes = dsEvent.Tables[5];
            DataTable dtEventImages = dsEvent.Tables[6];
            DataTable dtVehicleInformation = dsEvent.Tables[7];
            DataTable dtSuspectInformation = dsEvent.Tables[8];

            FileStream fsMail = null;

            bool Is_Sonic_Event = Convert.ToBoolean(dtEvent.Rows[0]["Sonic_Event"]);

            if (Is_Sonic_Event)
                fsMail = new FileStream(AppConfig.DocumentsPath + @"\AbstractLetterTemplate\Event_AbstractReport_Sonic.htm", FileMode.Open, FileAccess.Read);
            else fsMail = new FileStream(AppConfig.DocumentsPath + @"\AbstractLetterTemplate\Event_AbstractReport.htm", FileMode.Open, FileAccess.Read);
            StreamReader rd = new StreamReader(fsMail);
            //StringBuilder strBody = new StringBuilder(rd.ReadToEnd().ToString());
            rd = new StreamReader(fsMail);
            strBody = new StringBuilder(rd.ReadToEnd().ToString());


            rd.Close();
            fsMail.Close();

            #region "ACI Reported Event"

            strBody = strBody.Replace("[Location]", Convert.ToString(dtEvent.Rows[0]["Location"]));
            strBody = strBody.Replace("[ACI_Event_ID]", Convert.ToString(dtEvent.Rows[0]["ACI_EventID"]));

            string strActionableEvent = string.Empty;

            if (!Is_Sonic_Event)
                dtActionable_Event.DefaultView.RowFilter = "Actionable_Event_Desc <> 'FROI Event/Other'"; //#Issue 3422

            DataTable dtFiltered_Event = dtActionable_Event.DefaultView.ToTable();

            if (dtFiltered_Event.Rows.Count > 0)
            {
                strActionableEvent = "<table cellpadding='4' cellspacing='0' width='100%'>";
                foreach (DataRow drEvent_Type in dtFiltered_Event.Rows)
                {
                    if (Convert.ToBoolean(drEvent_Type["Is_Checked"]))
                    {
                        strActionableEvent += "<tr style='page-break-inside: avoid'><td width='100%' align='left' valign='top' colspan='2'><span style='vertical-align:middle;'><img  alt='' src='" + AppConfig.SiteURL + "Images/check.png" + "' /></span>&nbsp;&nbsp;&nbsp;" + drEvent_Type["Actionable_Event_Desc"] + "</td></tr>";
                    }
                    else
                    {
                        strActionableEvent += "<tr style='page-break-inside: avoid'><td width='100%' align='left' valign='top' colspan='2'><span style='vertical-align:middle;'><img  alt='' src='" + AppConfig.SiteURL + "Images/uncheck.png" + "' /></span>&nbsp;&nbsp;&nbsp;" + drEvent_Type["Actionable_Event_Desc"] + "</td></tr>";
                    }
                }
                strActionableEvent += "</table>";
            }
            strBody = strBody.Replace("[Actionable_Event_Type]", strActionableEvent);
            strBody = strBody.Replace("[Description_of_Event]", Convert.ToString(dtEvent.Rows[0]["Event_Desc"]));
            if (!string.IsNullOrEmpty(Convert.ToString(dtEvent.Rows[0]["Event_Start_Date"])))
                strBody = strBody.Replace("[Date_of_Event]", clsGeneral.FormatDBNullDateToDisplay(dtEvent.Rows[0]["Event_Start_Date"]));
            else
                strBody = strBody.Replace("[Date_of_Event]", string.Empty);

            strBody = strBody.Replace("[Event_Start_Time]", Convert.ToString(dtEvent.Rows[0]["Event_Start_Time"]));
            strBody = strBody.Replace("[Event_End_Time]", Convert.ToString(dtEvent.Rows[0]["Event_End_Time"]));


            strBody = strBody.Replace("[BuildingInformation]", GetBuildingDetails(dtBuilding));

            strBody = strBody.Replace("[Camera_Grid]", GetCameraDetails(dtCamera));

            strBody = strBody.Replace("[Acadian_Investigator_Name]", Convert.ToString(dtEvent.Rows[0]["Investigator_Name"]));
            strBody = strBody.Replace("[Acadian_Investigator_Email_Address]", Convert.ToString(dtEvent.Rows[0]["Investigator_Email"]));
            strBody = strBody.Replace("[Acadian_Investigator_Phone]", Convert.ToString(dtEvent.Rows[0]["Investigator_Phone"]));

            strBody = strBody.Replace("[AL_FR_Number]", Convert.ToString(dtEvent.Rows[0]["AL_FR_Number"]));
            strBody = strBody.Replace("[DPD_FR_Number]", Convert.ToString(dtEvent.Rows[0]["DPD_FR_Number"]));
            strBody = strBody.Replace("[PL_FR_Number]", Convert.ToString(dtEvent.Rows[0]["PL_FR_Number"]));
            strBody = strBody.Replace("[Prop_FR_Number]", Convert.ToString(dtEvent.Rows[0]["Prop_FR_Number"]));
            strBody = strBody.Replace("[Event_Root_Cause]", Convert.ToString(dtEvent.Rows[0]["Event_Root_Cause"]));
            strBody = strBody.Replace("[How_Event_Prevented]", Convert.ToString(dtEvent.Rows[0]["How_Event_Prevented"]));
            strBody = strBody.Replace("[Financial_Loss]", string.Format("{0:C2}", dtEvent.Rows[0]["Financial_Loss"]));

            string AttachmentDocPath = "Documents/EventImage";
            if (!string.IsNullOrEmpty(Convert.ToString(dtEvent.Rows[0]["Event_Image"])) && File.Exists(AppConfig.DocumentsPath + "EventImage\\" + dtEvent.Rows[0]["Event_Image"]))
            {
                strBody = strBody.Replace("[Event_Image]", "<img  alt='' src='" + AppConfig.SiteURL + AttachmentDocPath + "/" + dtEvent.Rows[0]["Event_Image"] + "' Height='200' Width='200' />");
            }
            else
                strBody = strBody.Replace("[Event_Image]", string.Empty);

            #endregion

            #region "Sonic Reported Event"

            strBody = strBody.Replace("[SRE#]", Convert.ToString(dtEvent.Rows[0]["Event_Number"]));
            strBody = strBody.Replace("[Monitoring_Hours]", Convert.ToString(dtEvent.Rows[0]["Monitoring_Hours"]));
            strBody = strBody.Replace("[Source_of_Information]", Convert.ToString(dtEvent.Rows[0]["Source_Of_Information"]));
            strBody = strBody.Replace("[Budge#]", Convert.ToString(dtEvent.Rows[0]["Badge_Number"]));
            strBody = strBody.Replace("[Sonic_Contact_Name]", Convert.ToString(dtEvent.Rows[0]["Sonic_Contact_Name"]));
            strBody = strBody.Replace("[Sonic_Contact_Phone_#]", Convert.ToString(dtEvent.Rows[0]["Sonic_Contact_Phone"]));
            strBody = strBody.Replace("[Sonic_Contact_Email_Address]", Convert.ToString(dtEvent.Rows[0]["Sonic_Contact_Email"]));

            #endregion

            #region "Acadian Investigation"

            strBody = strBody.Replace("[Police_Called]", Convert.ToString(dtEvent.Rows[0]["Police_Called"]));
            strBody = strBody.Replace("[Video_Requested_By_Sonic]", Convert.ToString(dtEvent.Rows[0]["Video_Requested_By_Sonic"]));
            strBody = strBody.Replace("[Agency_Name]", Convert.ToString(dtEvent.Rows[0]["Agency_Name"]));
            strBody = strBody.Replace("[Officer_Name]", Convert.ToString(dtEvent.Rows[0]["Officer_Name"]));
            strBody = strBody.Replace("[Phone_#]", Convert.ToString(dtEvent.Rows[0]["Officer_Phone"]));
            strBody = strBody.Replace("[Police_Report_#]", Convert.ToString(dtEvent.Rows[0]["Police_Report_Number"]));
            strBody = strBody.Replace("[Incident_Report_Desc]", Convert.ToString(dtEvent.Rows[0]["Incident_Report_Desc"]));

            strBody = strBody.Replace("[Vehicle_Information_Grid]", GetVehicleDetails(dtVehicleInformation));
            strBody = strBody.Replace("[Suspect_Information_Grid]", GetSuspectDetails(dtSuspectInformation)); 
            strBody = strBody.Replace("[Acadian_Notes_Grid]", GetACINotesDetails(dtACINotes));

            if (Is_Sonic_Event)
            {
                strBody = strBody.Replace("[Sonic_Notes_Grid]", GetSonicNotesDetails(dtSonicNotes));
            }

            string strEventImages = string.Empty;
            if (dtEventImages.Rows.Count > 0)
            {
                strEventImages = "<table cellpadding='1' cellspacing='1' width='95%'>";
                foreach (DataRow drEvent_Images in dtEventImages.Rows)
                {
                    if (!string.IsNullOrEmpty(Convert.ToString(drEvent_Images["Attachment_Name"])) && File.Exists(AppConfig.DocumentsPath + "Attach\\" + drEvent_Images["Attachment_Name"]))
                    {
                        System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(AppConfig.SitePath + "Documents\\Attach\\" + drEvent_Images["Attachment_Name"]);

                        int originalWidth = bmp.Width;
                        int originalHeight = bmp.Height;

                        float ratioX = (float)600 / (float)originalWidth;
                        float ratioY = (float)200 / (float)originalHeight;
                        float ratio = Math.Min(ratioX, ratioY);

                        // New width and height based on aspect ratio
                        int newWidth = (int)(originalWidth * ratio);
                        int newHeight = (int)(originalHeight * ratio);

                        bmp.Dispose();

                        strEventImages += "<tr style='page-break-inside: avoid'><td valign='top'><img  alt='' src='" + AppConfig.SiteURL + "Documents/Attach" + "/" + drEvent_Images["Attachment_Name"] + "' BorderWidth='1px' BorderStyle='Solid' BorderColor='Black' Height='" + newHeight + "' Width='" + newWidth + "' /></td></tr>";
                    }
                }
                strEventImages += "</table>";
            }

            strBody = strBody.Replace("[Images_of_Event]", strEventImages);

            #endregion
        }

        return strBody;

    }
    
    public static string GetBuildingDetails(DataTable dtBuilding)
    {
        StringBuilder sbGrid = new StringBuilder(string.Empty);
        sbGrid = new StringBuilder(string.Empty);
        //sbGrid.Append("<tr><td style='font-size: 12px; font-family: Arial; font-weight: bold;page-break-inside : avoid' class='HeaderRow' colspan='6'>Attachments</td></tr>");
        //sbGrid.Append("<tr><td style='font-size: 12px; font-family: Arial; '  colspan='6'>");
        sbGrid.Append("<tr style='page-break-inside: avoid'><td colspan='6'> <table border='0' cellspacing='1' cellpadding='1' width='100%'>");
        sbGrid.Append("<tr style='page-break-inside: avoid'>");
        sbGrid.Append("<td style='font-size: 12px; font-family: Arial; font-weight: bold;page-break-inside : avoid' class='HeaderRow' colspan='6'>Buildings</td></tr>");
        sbGrid.Append("<tr style='page-break-inside: avoid'><td style='font-size: 12px; font-family: Arial;'  colspan='6'>");
        if (dtBuilding.Rows.Count > 0)
        {
            sbGrid.Append("<table width='100%'>");
            sbGrid.Append("<tr style='background-color: #7f7f7f; font-family: Arial; color: white; font-size: 12px; font-weight: bold' valign=top>");
            sbGrid.Append("<td  style='font-family: Arial; font-size: 12px;' align='left'> Building Number </td>");
            sbGrid.Append("<td  style='font-family: Arial; font-size: 12px;' align='left'> Address </td>");
            sbGrid.Append("<td  style='font-family: Arial; font-size: 12px;' align='left'> Occupancy </td>");
            sbGrid.Append("</tr>");

            foreach (DataRow dr in dtBuilding.Rows)
            {
                sbGrid.Append("<tr valign=top>");
                sbGrid.AppendFormat("<td  style='font-family: Arial; font-size: 12px;' align='left'>  {0} </td>", dr["Building_Number"]);
                sbGrid.AppendFormat("<td  style='font-family: Arial; font-size: 12px;' align='left'>  {0} </td>", dr["Address"]);
                sbGrid.AppendFormat("<td  style='font-family: Arial; font-size: 12px;' align='left'>  {0} </td>", dr["Occupancy"]);
                sbGrid.Append("</tr>");
            }
            sbGrid.Append("</table>");
            sbGrid.Append("</td>");
            sbGrid.Append("</tr>");
            sbGrid.Append("</table>");
        }
        else
        {
            sbGrid.Append("<table width='100%'>");
            sbGrid.Append("<tr valign='top' style='font-family: Arial; font-size: 12px; padding-left:20px;' align='center'><td align='left'>No Building Records Found.</td></tr>");
            sbGrid.Append("</table>");
            sbGrid.Append("</td>");
            sbGrid.Append("</tr>");
            sbGrid.Append("</table>");
        }
        sbGrid.Append("</td></tr>");
        sbGrid.Append("<tr><td>&nbsp;</td></tr>");
        return sbGrid.ToString();
    }

    public static string GetCameraDetails(DataTable dtCamera)
    {
        StringBuilder sbGrid = new StringBuilder(string.Empty);
        sbGrid = new StringBuilder(string.Empty);
        if (dtCamera.Rows.Count > 0)
        {
            sbGrid.Append("<table width='100%'>");
            sbGrid.Append("<tr style='background-color: #7f7f7f; font-family: Arial; color: white; font-size: 12px; font-weight: bold' valign=top>");
            sbGrid.Append("<td  style='font-family: Arial; font-size: 12px;' align='left'> Camera Name </td>");
            sbGrid.Append("<td  style='font-family: Arial; font-size: 12px;' align='left'> Camera Number </td>");
            sbGrid.Append("<td  style='font-family: Arial; font-size: 12px;' align='left'> Event Time From </td>");
            sbGrid.Append("<td  style='font-family: Arial; font-size: 12px;' align='left'> Event Time To </td>");
            sbGrid.Append("</tr>");

            foreach (DataRow dr in dtCamera.Rows)
            {
                sbGrid.Append("<tr valign=top>");
                sbGrid.AppendFormat("<td  style='font-family: Arial; font-size: 12px;' align='left'>  {0} </td>", dr["Camera_Name"]);
                sbGrid.AppendFormat("<td  style='font-family: Arial; font-size: 12px;' align='left'>  {0} </td>", dr["Camera_Number"]);
                sbGrid.AppendFormat("<td  style='font-family: Arial; font-size: 12px;' align='left'>  {0} </td>", dr["Event_Time_From"]);
                sbGrid.AppendFormat("<td  style='font-family: Arial; font-size: 12px;' align='left'>  {0} </td>", dr["Event_Time_To"]);
                sbGrid.Append("</tr>");
            }
            sbGrid.Append("</table>");
        }
        else
        {
            sbGrid.Append("No Records found.");
        }

        return sbGrid.ToString();
    }

    public static string GetVehicleDetails(DataTable dtVehicle)
    {
        StringBuilder sbGrid = new StringBuilder(string.Empty);
        sbGrid = new StringBuilder(string.Empty);
        if (dtVehicle.Rows.Count > 0)
        {
            sbGrid.Append("<table width='100%'>");
            sbGrid.Append("<tr style='background-color: #7f7f7f; font-family: Arial; color: white; font-size: 12px; font-weight: bold' valign=top>");
            sbGrid.Append("<td  style='font-family: Arial; font-size: 12px;' align='left'> Make </td>");
            sbGrid.Append("<td  style='font-family: Arial; font-size: 12px;' align='left'> Model </td>");
            sbGrid.Append("<td  style='font-family: Arial; font-size: 12px;' align='left'> Color </td>");
            sbGrid.Append("<td  style='font-family: Arial; font-size: 12px;' align='left'> License </td>");
            sbGrid.Append("<td  style='font-family: Arial; font-size: 12px;' align='left'> State </td>");
            sbGrid.Append("<td  style='font-family: Arial; font-size: 12px;' align='left'> Suspect Vehicle </td>");
            sbGrid.Append("</tr>");

            foreach (DataRow dr in dtVehicle.Rows)
            {
                sbGrid.Append("<tr valign=top>");
                sbGrid.AppendFormat("<td  style='font-family: Arial; font-size: 12px;' align='left'>  {0} </td>", dr["Make"]);
                sbGrid.AppendFormat("<td  style='font-family: Arial; font-size: 12px;' align='left'>  {0} </td>", dr["Model"]);
                sbGrid.AppendFormat("<td  style='font-family: Arial; font-size: 12px;' align='left'>  {0} </td>", dr["Color"]);
                sbGrid.AppendFormat("<td  style='font-family: Arial; font-size: 12px;' align='left'>  {0} </td>", dr["License"]);
                sbGrid.AppendFormat("<td  style='font-family: Arial; font-size: 12px;' align='left'>  {0} </td>", dr["STATE"]);
                sbGrid.AppendFormat("<td  style='font-family: Arial; font-size: 12px;' align='left'>  {0} </td>", dr["Suspect_Vehicle"]);
                sbGrid.Append("</tr>");
            }
            sbGrid.Append("</table>");
        }
        else
        {
            sbGrid.Append("No Records found.");
        }

        return sbGrid.ToString();
    }

    public static string GetSuspectDetails(DataTable dtSuspect)
    {
        StringBuilder sbGrid = new StringBuilder(string.Empty);
        sbGrid = new StringBuilder(string.Empty);
        if (dtSuspect.Rows.Count > 0)
        {
            sbGrid.Append("<table width='100%'>");
            sbGrid.Append("<tr style='background-color: #7f7f7f; font-family: Arial; color: white; font-size: 12px; font-weight: bold' valign=top>");
            sbGrid.Append("<td  style='font-family: Arial; font-size: 12px;' align='left'> Sex </td>");
            sbGrid.Append("<td  style='font-family: Arial; font-size: 12px;' align='left'> Notes </td>");
            sbGrid.Append("</tr>");

            foreach (DataRow dr in dtSuspect.Rows)
            {
                sbGrid.Append("<tr valign=top>");
                sbGrid.AppendFormat("<td  style='font-family: Arial; font-size: 12px;' align='left'>  {0} </td>", dr["Sex"]);
                sbGrid.AppendFormat("<td  style='font-family: Arial; font-size: 12px;' align='left'>  {0} </td>", dr["Description"]);
                sbGrid.Append("</tr>");
            }
            sbGrid.Append("</table>");
        }
        else
        {
            sbGrid.Append("No Records found.");
        }

        return sbGrid.ToString();
    }

    public static string GetACINotesDetails(DataTable dtACINote)
    {
        StringBuilder sbGrid = new StringBuilder(string.Empty);
        sbGrid = new StringBuilder(string.Empty);
        if (dtACINote.Rows.Count > 0)
        {
            sbGrid.Append("<table width='100%'>");
            sbGrid.Append("<tr style='background-color: #7f7f7f; font-family: Arial; color: white; font-size: 12px; font-weight: bold' valign=top>");
            sbGrid.Append("<td  style='font-family: Arial; font-size: 12px;' align='left'> Note Date </td>");
            sbGrid.Append("<td  style='font-family: Arial; font-size: 12px;' align='left'> Notes </td>");
            sbGrid.Append("</tr>");

            foreach (DataRow dr in dtACINote.Rows)
            {
                sbGrid.Append("<tr valign=top>");
                sbGrid.AppendFormat("<td  style='font-family: Arial; font-size: 12px;' align='left'>  {0} </td>", clsGeneral.FormatDBNullDateToDisplay(dr["Note_Date"]));
                sbGrid.AppendFormat("<td  style='font-family: Arial; font-size: 12px;' align='left'>  {0} </td>", dr["Note"]);
                sbGrid.Append("</tr>");
            }
            sbGrid.Append("</table>");
        }
        else
        {
            sbGrid.Append("No Records found.");
        }

        return sbGrid.ToString();
    }

    public static string GetSonicNotesDetails(DataTable dtSonicNote)
    {
        StringBuilder sbGrid = new StringBuilder(string.Empty);
        sbGrid = new StringBuilder(string.Empty);
        if (dtSonicNote.Rows.Count > 0)
        {
            sbGrid.Append("<table width='100%'>");
            sbGrid.Append("<tr style='background-color: #7f7f7f; font-family: Arial; color: white; font-size: 12px; font-weight: bold' valign=top>");
            sbGrid.Append("<td  style='font-family: Arial; font-size: 12px;' align='left'> Note Date </td>");
            sbGrid.Append("<td  style='font-family: Arial; font-size: 12px;' align='left'> User </td>");
            sbGrid.Append("<td  style='font-family: Arial; font-size: 12px;' align='left'> Notes </td>");
            sbGrid.Append("</tr>");

            foreach (DataRow dr in dtSonicNote.Rows)
            {
                sbGrid.Append("<tr valign=top>");
                sbGrid.AppendFormat("<td  style='font-family: Arial; font-size: 12px;' align='left'>  {0} </td>", clsGeneral.FormatDBNullDateToDisplay(dr["Note_Date"]));
                sbGrid.AppendFormat("<td  style='font-family: Arial; font-size: 12px;' align='left'>  {0} </td>", dr["Updated_by_Name"]);
                sbGrid.AppendFormat("<td  style='font-family: Arial; font-size: 12px;' align='left'>  {0} </td>", dr["Note"]);
                sbGrid.Append("</tr>");
            }
            sbGrid.Append("</table>");
        }
        else
        {
            sbGrid.Append("No Records found.");
        }

        return sbGrid.ToString();
    }

    public static string GetStoreContactDetails(DataTable dtStoreContactDetails)
    {
        StringBuilder sbGrid = new StringBuilder(string.Empty);
        sbGrid = new StringBuilder(string.Empty);
        if (dtStoreContactDetails.Rows.Count > 0)
        {
            sbGrid.Append("<table width='100%'>");
            sbGrid.Append("<tr style='background-color: #7f7f7f; font-family: Arial; color: white; font-size: 12px; font-weight: bold' valign=top>");
            sbGrid.Append("<td  style='font-family: Arial; font-size: 12px;' align='left' width='25%'> First Name </td>");
            sbGrid.Append("<td  style='font-family: Arial; font-size: 12px;' align='left' width='25%'> Last Name </td>");
            sbGrid.Append("<td  style='font-family: Arial; font-size: 12px;' align='left' width='25%'> Phone </td>");
            sbGrid.Append("<td  style='font-family: Arial; font-size: 12px;' align='left' width='25%'> Email </td>");
            sbGrid.Append("</tr>");

            foreach (DataRow dr in dtStoreContactDetails.Rows)
            {
                sbGrid.Append("<tr valign=top>");
                sbGrid.AppendFormat("<td  style='font-family: Arial; font-size: 12px;' align='left' width='25%'>  {0} </td>", Convert.ToString(dr["First_Name"]));
                sbGrid.AppendFormat("<td  style='font-family: Arial; font-size: 12px;' align='left' width='25%'>  {0} </td>", Convert.ToString(dr["Last_name"]));
                sbGrid.AppendFormat("<td  style='font-family: Arial; font-size: 12px;' align='left' width='25%'>  {0} </td>", Convert.ToString(dr["Phone"]));
                sbGrid.AppendFormat("<td  style='font-family: Arial; font-size: 12px;' align='left' width='25%'>  {0} </td>", Convert.ToString(dr["Email"]));
                sbGrid.Append("</tr>");
            }
            sbGrid.Append("</table>");
        }
        else
        {
            sbGrid.Append("No Records found.");
        }

        return sbGrid.ToString();
    }

    public static string GetACIContactDetails(DataTable dtACIContactDetails)
    {
        StringBuilder sbGrid = new StringBuilder(string.Empty);
        sbGrid = new StringBuilder(string.Empty);
        if (dtACIContactDetails.Rows.Count > 0)
        {
            sbGrid.Append("<table width='100%'>");
            sbGrid.Append("<tr style='background-color: #7f7f7f; font-family: Arial; color: white; font-size: 12px; font-weight: bold' valign=top>");
            sbGrid.Append("<td  style='font-family: Arial; font-size: 12px;' align='left' width='25%'> First Name </td>");
            sbGrid.Append("<td  style='font-family: Arial; font-size: 12px;' align='left' width='25%'> Last Name </td>");
            sbGrid.Append("<td  style='font-family: Arial; font-size: 12px;' align='left' width='25%'> Phone </td>");
            sbGrid.Append("<td  style='font-family: Arial; font-size: 12px;' align='left' width='25%'> Email </td>");
            sbGrid.Append("</tr>");

            foreach (DataRow dr in dtACIContactDetails.Rows)
            {
                sbGrid.Append("<tr valign=top>");
                sbGrid.AppendFormat("<td  style='font-family: Arial; font-size: 12px;' align='left' width='25%'>  {0} </td>", Convert.ToString(dr["First_Name"]));
                sbGrid.AppendFormat("<td  style='font-family: Arial; font-size: 12px;' align='left' width='25%'>  {0} </td>", Convert.ToString(dr["Last_name"]));
                sbGrid.AppendFormat("<td  style='font-family: Arial; font-size: 12px;' align='left' width='25%'>  {0} </td>", Convert.ToString(dr["Phone"]));
                sbGrid.AppendFormat("<td  style='font-family: Arial; font-size: 12px;' align='left' width='25%'>  {0} </td>", Convert.ToString(dr["Email"]));
                sbGrid.Append("</tr>");
            }
            sbGrid.Append("</table>");
        }
        else
        {
            sbGrid.Append("No Records found.");
        }

        return sbGrid.ToString();
    }

    public static string GetProjectCostDetails(DataTable dtProjectCostDetails)
    {
        StringBuilder sbGrid = new StringBuilder(string.Empty);
        sbGrid = new StringBuilder(string.Empty);
        if (dtProjectCostDetails.Rows.Count > 0)
        {
            sbGrid.Append("<table width='100%'>");
            sbGrid.Append("<tr style='background-color: #7f7f7f; font-family: Arial; color: white; font-size: 12px; font-weight: bold' valign=top>");
            sbGrid.Append("<td  style='font-family: Arial; font-size: 12px;' align='left'> Project Phase </td>");
            sbGrid.Append("<td  style='font-family: Arial; font-size: 12px;' align='left'> Budget($) </td>");
            sbGrid.Append("<td  style='font-family: Arial; font-size: 12px;' align='left'> Estimated Cost($) </td>");
            sbGrid.Append("<td  style='font-family: Arial; font-size: 12px;' align='left'> Actual Cost($) </td>");
            sbGrid.Append("</tr>");

            foreach (DataRow dr in dtProjectCostDetails.Rows)
            {
                sbGrid.Append("<tr valign=top>");

                if (!DBNull.Value.Equals(dr["FK_LU_EPM_Project_Phase"]))
                {
                    switch (dr["FK_LU_EPM_Project_Phase"].ToString())
                    {
                        case "1":
                            sbGrid.AppendFormat("<td  style='font-family: Arial; font-size: 12px;' align='left'>  Completed </td>");
                            break;
                        case "2":
                            sbGrid.AppendFormat("<td  style='font-family: Arial; font-size: 12px;' align='left'>  Delayed </td>");
                            break;
                        case "3":
                            sbGrid.AppendFormat("<td  style='font-family: Arial; font-size: 12px;' align='left'>  In Progress </td>");
                            break;
                        case "4":
                            sbGrid.AppendFormat("<td  style='font-family: Arial; font-size: 12px;' align='left'>  Proposal </td>");
                            break;
                        default:
                            sbGrid.AppendFormat("<td  style='font-family: Arial; font-size: 12px;' align='left'></td>");
                            break;
                    }
                }
                else
                {
                    sbGrid.AppendFormat("<td  style='font-family: Arial; font-size: 12px;' align='left'></td>");
                }

                sbGrid.AppendFormat("<td  style='font-family: Arial; font-size: 12px;' align='left'>  {0} </td>", string.Format("{0:C2}", dr["Budget"]));
                sbGrid.AppendFormat("<td  style='font-family: Arial; font-size: 12px;' align='left'>  {0} </td>", string.Format("{0:C2}", dr["Estimated_Cost"]));
                sbGrid.AppendFormat("<td  style='font-family: Arial; font-size: 12px;' align='left'>  {0} </td>", string.Format("{0:C2}", dr["Actual_Cost"]));
                sbGrid.Append("</tr>");
            }
            sbGrid.Append("</table>");
        }
        else
        {
            sbGrid.Append("No Records found.");
        }

        return sbGrid.ToString();
    }

    public static string GetInvoiceDetails(DataTable dtInvoiceDetails)
    {
        StringBuilder sbGrid = new StringBuilder(string.Empty);
        sbGrid = new StringBuilder(string.Empty);
        if (dtInvoiceDetails.Rows.Count > 0)
        {
            sbGrid.Append("<table width='100%'>");
            sbGrid.Append("<tr style='background-color: #7f7f7f; font-family: Arial; color: white; font-size: 12px; font-weight: bold' valign=top>");
            sbGrid.Append("<td  style='font-family: Arial; font-size: 12px;' align='left'> Invoice Number </td>");
            sbGrid.Append("<td  style='font-family: Arial; font-size: 12px;' align='left'> Invoice Date </td>");
            sbGrid.Append("<td  style='font-family: Arial; font-size: 12px;' align='left'> Invoice Amount($) </td>");
            sbGrid.Append("<td  style='font-family: Arial; font-size: 12px;' align='left'> Vendor </td>");
            sbGrid.Append("</tr>");

            foreach (DataRow dr in dtInvoiceDetails.Rows)
            {
                sbGrid.Append("<tr valign=top>");

                sbGrid.AppendFormat("<td  style='font-family: Arial; font-size: 12px;' align='left'>  {0} </td>", Convert.ToString(dr["Invoice_Number"]));
                sbGrid.AppendFormat("<td  style='font-family: Arial; font-size: 12px;' align='left'>  {0} </td>", clsGeneral.FormatDBNullDateToDisplay(dr["Invoice_Date"]));
                sbGrid.AppendFormat("<td  style='font-family: Arial; font-size: 12px;' align='left'>  {0} </td>", string.Format("{0:C2}", dr["Invoice_Amount"]));
                sbGrid.AppendFormat("<td  style='font-family: Arial; font-size: 12px;' align='left'>  {0} </td>", Convert.ToString(dr["Vendor"]));
                sbGrid.Append("</tr>");
            }
            sbGrid.Append("</table>");
        }
        else
        {
            sbGrid.Append("No Records found.");
        }

        return sbGrid.ToString();
    }

    public static StringBuilder Management_AbstractReport(decimal _PK_Management)
    {
        DataSet dsAbstractManagement = clsManagement.GetManagementAbstractLetterData(_PK_Management);

        StringBuilder strBody = new StringBuilder("");

        if (dsAbstractManagement.Tables.Count > 0 && dsAbstractManagement.Tables[0].Rows.Count > 0)
        {
            DataTable dtManagementDetail = dsAbstractManagement.Tables[0];
            DataTable dtStoreContactDetails = dsAbstractManagement.Tables[1];
            DataTable dtACIContactDetails = dsAbstractManagement.Tables[2];
            DataTable dtProjectCostDetails = dsAbstractManagement.Tables[3];
            DataTable dtInvoiceDetails = dsAbstractManagement.Tables[4];

            FileStream fsMail = null;

            fsMail = new FileStream(AppConfig.DocumentsPath + @"\AbstractLetterTemplate\Management_AbstractReport.html", FileMode.Open, FileAccess.Read);

            StreamReader rd = new StreamReader(fsMail);
            //StringBuilder strBody = new StringBuilder(rd.ReadToEnd().ToString());
            rd = new StreamReader(fsMail);
            strBody = new StringBuilder(rd.ReadToEnd().ToString());


            rd.Close();
            fsMail.Close();

            #region "Management Details"

            strBody = strBody.Replace("[DBA]", Convert.ToString(dtManagementDetail.Rows[0]["DBA"]));
            strBody = strBody.Replace("[Reference_Number]", Convert.ToString(dtManagementDetail.Rows[0]["Reference_Number"]));
            strBody = strBody.Replace("[LocationCode]", Convert.ToString(dtManagementDetail.Rows[0]["Location_Code"]));
            strBody = strBody.Replace("[DateScheduled]", clsGeneral.FormatDBNullDateToDisplay(dtManagementDetail.Rows[0]["Date_Scheduled"]));
            strBody = strBody.Replace("[DateCompleted]", clsGeneral.FormatDBNullDateToDisplay(dtManagementDetail.Rows[0]["Date_Complete"]));
            strBody = strBody.Replace("[WorkToBeCompleted]", Convert.ToString(dtManagementDetail.Rows[0]["WorkToBeCompleted"]));
            strBody = strBody.Replace("[WorkToBeCompletedOther]", Convert.ToString(dtManagementDetail.Rows[0]["Work_To_Complete_Other"]));

            if (!DBNull.Value.Equals(dtManagementDetail.Rows[0]["Work_Completed_By"]))
            {
                switch (Convert.ToBoolean(dtManagementDetail.Rows[0]["Work_Completed_By"]))
                {
                    case false:
                        strBody = strBody.Replace("[WorkToBeCompletedBy]", "Sonic");
                        break;
                    case true:
                        strBody = strBody.Replace("[WorkToBeCompletedBy]", "ACI");
                        break;
                    default:
                        strBody = strBody.Replace("[WorkToBeCompletedBy]", string.Empty);
                        break;
                }
            }
            else
            {
                strBody = strBody.Replace("[WorkToBeCompletedBy]", string.Empty);
            }

            if (!DBNull.Value.Equals(dtManagementDetail.Rows[0]["Task_Complete"]))
            {
                switch (Convert.ToBoolean(dtManagementDetail.Rows[0]["Task_Complete"]))
                {
                    case false:
                        strBody = strBody.Replace("[TaskComplete]", "NO");
                        break;
                    case true:
                        strBody = strBody.Replace("[TaskComplete]", "YES");
                        break;
                    default:
                        strBody = strBody.Replace("[TaskComplete]", string.Empty);
                        break;
                }
            }
            else
            {
                strBody = strBody.Replace("[TaskComplete]", string.Empty);
            }

            strBody = strBody.Replace("[Service/RepairCost]", string.Format("{0:C2}", dtManagementDetail.Rows[0]["Service_Repair_Cost"]));
            strBody = strBody.Replace("[CRApproved]", clsGeneral.FormatDBNullDateToDisplay(dtManagementDetail.Rows[0]["CR_Approved"]));
            strBody = strBody.Replace("[RecordType]", Convert.ToString(dtManagementDetail.Rows[0]["RecordType"]));
            strBody = strBody.Replace("[Approval_Submission]", Convert.ToString(dtManagementDetail.Rows[0]["Approval_Submission"]));
            strBody = strBody.Replace("[RecordTypeOther]", Convert.ToString(dtManagementDetail.Rows[0]["Record_Type_Other"]));
            strBody = strBody.Replace("[Job#]", Convert.ToString(dtManagementDetail.Rows[0]["Job"]));
            strBody = strBody.Replace("[Order#]", Convert.ToString(dtManagementDetail.Rows[0]["Order"]));
            strBody = strBody.Replace("[OrderDate]", clsGeneral.FormatDBNullDateToDisplay(dtManagementDetail.Rows[0]["Order_Date"]));
            strBody = strBody.Replace("[RequestedBy]", Convert.ToString(dtManagementDetail.Rows[0]["Requested_By"]));
            strBody = strBody.Replace("[CreatedBy]", Convert.ToString(dtManagementDetail.Rows[0]["Created_By"]));
            strBody = strBody.Replace("[PreviousContractAmount]", string.Format("{0:C2}", dtManagementDetail.Rows[0]["Previous_Contract_Amount"]));
            strBody = strBody.Replace("[RevisedContractAmount]", string.Format("{0:C2}", dtManagementDetail.Rows[0]["Revised_Contract_Amount"]));
            strBody = strBody.Replace("[ReasonForRequest]", Convert.ToString(dtManagementDetail.Rows[0]["Reason_for_Request"]));
            strBody = strBody.Replace("[Recommendation]", Convert.ToString(dtManagementDetail.Rows[0]["Recommendation"]));
            strBody = strBody.Replace("[GM_EMailTo]", Convert.ToString(dtManagementDetail.Rows[0]["GM_Email_To"]));
            strBody = strBody.Replace("[GM_LastEMailDate]", clsGeneral.FormatDBNullDateToDisplay(dtManagementDetail.Rows[0]["GM_Last_Email_Date"]));

            if (!DBNull.Value.Equals(dtManagementDetail.Rows[0]["GM_Decision"]))
            {
                switch (Convert.ToBoolean(dtManagementDetail.Rows[0]["GM_Decision"]))
                {
                    case false:
                        strBody = strBody.Replace("[GM_Decision]", "Not Approved");
                        break;
                    case true:
                        strBody = strBody.Replace("[GM_Decision]", "Approved");
                        break;
                    default:
                        strBody = strBody.Replace("[GM_Decision]", string.Empty);
                        break;
                }
            }
            else
            {
                strBody = strBody.Replace("[GM_Decision]", string.Empty);
            }

            strBody = strBody.Replace("[GM_ResponseDate]", clsGeneral.FormatDBNullDateToDisplay(dtManagementDetail.Rows[0]["GM_Response_Date"]));

            strBody = strBody.Replace("[RLCM_EMailTo]", Convert.ToString(dtManagementDetail.Rows[0]["RLCM_Email_To"]));
            strBody = strBody.Replace("[RLCM_LastEMailDate]", clsGeneral.FormatDBNullDateToDisplay(dtManagementDetail.Rows[0]["RLCM_Last_Email_Date"]));

            if (!DBNull.Value.Equals(dtManagementDetail.Rows[0]["RLCM_Decision"]))
            {
                switch (Convert.ToBoolean(dtManagementDetail.Rows[0]["RLCM_Decision"]))
                {
                    case false:
                        strBody = strBody.Replace("[RLCM_Decision]", "Not Approved");
                        break;
                    case true:
                        strBody = strBody.Replace("[RLCM_Decision]", "Approved");
                        break;
                    default:
                        strBody = strBody.Replace("[RLCM_Decision]", string.Empty);
                        break;
                }
            }
            else
            {
                strBody = strBody.Replace("[RLCM_Decision]", string.Empty);
            }

            strBody = strBody.Replace("[RLCM_ResponseDate]", clsGeneral.FormatDBNullDateToDisplay(dtManagementDetail.Rows[0]["RLCM_Response_Date"]));

            strBody = strBody.Replace("[NAPM_EMailTo]", Convert.ToString(dtManagementDetail.Rows[0]["NAPM_Email_To"]));
            strBody = strBody.Replace("[NAPM_LastEMailDate]", clsGeneral.FormatDBNullDateToDisplay(dtManagementDetail.Rows[0]["NAPM_Last_Email_Date"]));

            if (!DBNull.Value.Equals(dtManagementDetail.Rows[0]["NAPM_Decision"]))
            {
                switch (Convert.ToBoolean(dtManagementDetail.Rows[0]["NAPM_Decision"]))
                {
                    case false:
                        strBody = strBody.Replace("[NAPM_Decision]", "Not Approved");
                        break;
                    case true:
                        strBody = strBody.Replace("[NAPM_Decision]", "Approved");
                        break;
                    default:
                        strBody = strBody.Replace("[NAPM_Decision]", string.Empty);
                        break;
                }
            }
            else
            {
                strBody = strBody.Replace("[NAPM_Decision]", string.Empty);
            }

            strBody = strBody.Replace("[NAPM_ResponseDate]", clsGeneral.FormatDBNullDateToDisplay(dtManagementDetail.Rows[0]["NAPM_Response_Date"]));

            strBody = strBody.Replace("[DRM_EMailTo]", Convert.ToString(dtManagementDetail.Rows[0]["DRM_Email_To"]));
            strBody = strBody.Replace("[DRM_LastEMailDate]", clsGeneral.FormatDBNullDateToDisplay(dtManagementDetail.Rows[0]["DRM_Last_Email_Date"]));

            if (!DBNull.Value.Equals(dtManagementDetail.Rows[0]["DRM_Decision"]))
            {
                switch (Convert.ToBoolean(dtManagementDetail.Rows[0]["DRM_Decision"]))
                {
                    case false:
                        strBody = strBody.Replace("[DRM_Decision]", "Not Approved");
                        break;
                    case true:
                        strBody = strBody.Replace("[DRM_Decision]", "Approved");
                        break;
                    default:
                        strBody = strBody.Replace("[DRM_Decision]", string.Empty);
                        break;
                }
            }
            else
            {
                strBody = strBody.Replace("[DRM_Decision]", string.Empty);
            }

            strBody = strBody.Replace("[DRM_ResponseDate]", clsGeneral.FormatDBNullDateToDisplay(dtManagementDetail.Rows[0]["DRM_Response_Date"]));
            strBody = strBody.Replace("[Comments]", Convert.ToString(dtManagementDetail.Rows[0]["Comment"]));

            #endregion

            #region "Store and ACI Contact Details"

            strBody = strBody.Replace("[StoreContactGrid]", GetStoreContactDetails(dtStoreContactDetails));
            strBody = strBody.Replace("[ACIContactGrid]", GetACIContactDetails(dtACIContactDetails));

            #endregion

            #region Project Cost Details

            strBody = strBody.Replace("[ProjectCostGrid]", GetProjectCostDetails(dtProjectCostDetails));
            strBody = strBody.Replace("[InvoiceGrid]", GetInvoiceDetails(dtInvoiceDetails));

            #endregion
        }

        return strBody;

    }
}