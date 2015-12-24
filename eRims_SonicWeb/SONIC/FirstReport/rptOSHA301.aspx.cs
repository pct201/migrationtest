using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Winnovative.WnvHtmlConvert;
using ERIMS.DAL;
using Winnovative.WnvHtmlConvert.PdfDocument;

public partial class SONIC_FirstReport_rptOSHA301 : clsBasePage
{
    private const string strPageBreak = "<br style=\"page-break-before: always\" />";

    #region "Page Events"

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindDropDownList();
        }
    }
    #endregion

    #region "Control Events"

    /// <summary>
    /// Generate template.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnGenerate_Click(object sender, EventArgs e)
    {
        StringBuilder strBody = new StringBuilder();
        StringBuilder SbTemp1 = new StringBuilder(string.Empty);
        StringBuilder SbTemp2 = new StringBuilder(string.Empty);
        int Page_Cntr = 1;

        DataSet dsReport = clsOSHA.GetReportOSHA301(Convert.ToDateTime(txtIncident_Begin.Text), Convert.ToDateTime(txtIncident_End.Text), Convert.ToDecimal(ddlOSHA_Coordinator.SelectedValue), Convert.ToDecimal(ddlLocation.SelectedValue));

        DataTable dtRecords = dsReport.Tables[0];

        if (dtRecords != null && dtRecords.Rows.Count > 0)
        {
            for (int Int1 = 0; Int1 < dtRecords.Rows.Count; Int1++)
            {
                #region ::OSHA 300::

                FileStream fsMail = new FileStream(AppConfig.SitePath + @"\Documents\AbstractLetterTemplate\OSHA_301.htm", FileMode.Open, FileAccess.Read);
                StreamReader rd = new StreamReader(fsMail);
                strBody = new StringBuilder(rd.ReadToEnd().ToString());
                rd.Close();
                fsMail.Close();

                StringBuilder SbTemp = new StringBuilder(string.Empty);

                strBody = strBody.Replace("[Completed_by]", string.IsNullOrEmpty(Convert.ToString(dtRecords.Rows[Int1]["Completed_By"])) ? "&nbsp;" : Convert.ToString(dtRecords.Rows[Int1]["Completed_By"]));
                strBody = strBody.Replace("[C_Title]", string.IsNullOrEmpty(Convert.ToString(dtRecords.Rows[Int1]["Title"])) ? "&nbsp;" : Convert.ToString(dtRecords.Rows[Int1]["Title"]));
                strBody = strBody.Replace("[Phn1]", string.IsNullOrEmpty(Convert.ToString(dtRecords.Rows[Int1]["Phn1"])) ? "&nbsp;" : Convert.ToString(dtRecords.Rows[Int1]["Phn1"]));
                strBody = strBody.Replace("[Phn2]", string.IsNullOrEmpty(Convert.ToString(dtRecords.Rows[Int1]["Phn2"])) ? "&nbsp;" : Convert.ToString(dtRecords.Rows[Int1]["Phn2"]));
                strBody = strBody.Replace("[Phn3]", string.IsNullOrEmpty(Convert.ToString(dtRecords.Rows[Int1]["Phn3"])) ? "&nbsp;" : Convert.ToString(dtRecords.Rows[Int1]["Phn3"]));
                strBody = strBody.Replace("[Date1]", DateTime.Now.Month.ToString());
                strBody = strBody.Replace("[Date2]", DateTime.Now.Day.ToString());
                strBody = strBody.Replace("[Date3]", DateTime.Now.Year.ToString());

                strBody.Replace("[Full_Name]", string.IsNullOrEmpty(Convert.ToString(dtRecords.Rows[Int1]["Full_Name"])) ? "&nbsp;" : Convert.ToString(dtRecords.Rows[Int1]["Full_Name"]));
                strBody.Replace("[Street]", string.IsNullOrEmpty(Convert.ToString(dtRecords.Rows[Int1]["Street"])) ? "&nbsp;" : Convert.ToString(dtRecords.Rows[Int1]["Street"]));
                strBody = strBody.Replace("[City]", string.IsNullOrEmpty(Convert.ToString(dtRecords.Rows[Int1]["City"])) ? "&nbsp;" : Convert.ToString(dtRecords.Rows[Int1]["City"]));
                strBody = strBody.Replace("[State]", string.IsNullOrEmpty(Convert.ToString(dtRecords.Rows[Int1]["State"])) ? "&nbsp;" : Convert.ToString(dtRecords.Rows[Int1]["State"]));
                strBody = strBody.Replace("[Zip]", string.IsNullOrEmpty(Convert.ToString(dtRecords.Rows[Int1]["Zip_Code"])) ? "&nbsp;" : Convert.ToString(dtRecords.Rows[Int1]["Zip_Code"]));

                strBody = strBody.Replace("[DOB1]", string.IsNullOrEmpty(Convert.ToString(dtRecords.Rows[Int1]["DOB1"])) ? "&nbsp;" : Convert.ToString(dtRecords.Rows[Int1]["DOB1"]));
                strBody = strBody.Replace("[DOB2]", string.IsNullOrEmpty(Convert.ToString(dtRecords.Rows[Int1]["DOB2"])) ? "&nbsp;" : Convert.ToString(dtRecords.Rows[Int1]["DOB2"]));
                strBody = strBody.Replace("[DOB3]", string.IsNullOrEmpty(Convert.ToString(dtRecords.Rows[Int1]["DOB3"])) ? "&nbsp;" : Convert.ToString(dtRecords.Rows[Int1]["DOB3"]));

                strBody = strBody.Replace("[DOH1]", string.IsNullOrEmpty(Convert.ToString(dtRecords.Rows[Int1]["DOH1"])) ? "&nbsp;" : Convert.ToString(dtRecords.Rows[Int1]["DOH1"]));
                strBody = strBody.Replace("[DOH2]", string.IsNullOrEmpty(Convert.ToString(dtRecords.Rows[Int1]["DOH2"])) ? "&nbsp;" : Convert.ToString(dtRecords.Rows[Int1]["DOH2"]));
                strBody = strBody.Replace("[DOH3]", string.IsNullOrEmpty(Convert.ToString(dtRecords.Rows[Int1]["DOH3"])) ? "&nbsp;" : Convert.ToString(dtRecords.Rows[Int1]["DOH3"]));

                string Gender = Convert.ToString(dtRecords.Rows[Int1]["Gender"]);
                string strEmergency_Room = Convert.ToString(dtRecords.Rows[Int1]["Emergency_Room"]);
                string strHospitalized = Convert.ToString(dtRecords.Rows[Int1]["Hospitalized"]);
                string strTime_Began_Work_AM_PM = Convert.ToString(dtRecords.Rows[Int1]["Time_Began_Work_AM_PM"]);
                string strEvent_Time_AM_PM = Convert.ToString(dtRecords.Rows[Int1]["Event_AM_PM"]);
                
                string ImgChecked, ImgUnchecked;
                ImgChecked = "<img src='" + AppConfig.SiteURL + "Images/Checkbox-checked_OSHA301.bmp' alt='' style='height:8px;' />";
                ImgUnchecked = "<img src='" + AppConfig.SiteURL + "Images/Checkbox-unchecked_OSHA301.bmp' alt='' style='height:8px;' />";

                if (Gender.ToLower() == "m")
                {
                    strBody = strBody.Replace("[Img_Male]", ImgChecked);
                    strBody = strBody.Replace("[Img_female]", ImgUnchecked);
                }
                else if (Gender.ToLower() == "f")
                {
                    strBody = strBody.Replace("[Img_Male]", ImgUnchecked);
                    strBody = strBody.Replace("[Img_female]", ImgChecked);
                }
                else
                {
                    strBody = strBody.Replace("[Img_Male]", ImgUnchecked);
                    strBody = strBody.Replace("[Img_female]", ImgUnchecked);
                }

                strBody.Replace("[Physician_Name]", string.IsNullOrEmpty(Convert.ToString(dtRecords.Rows[Int1]["Physician_Other_Professional"])) ? "&nbsp;" : Convert.ToString(dtRecords.Rows[Int1]["Physician_Other_Professional"]));
                strBody.Replace("[Facility]", string.IsNullOrEmpty(Convert.ToString(dtRecords.Rows[Int1]["Facility"])) ? "&nbsp;" : Convert.ToString(dtRecords.Rows[Int1]["Facility"]));
                strBody.Replace("[Facility_Street]", string.IsNullOrEmpty(Convert.ToString(dtRecords.Rows[Int1]["Facility_Street"])) ? "&nbsp;" : Convert.ToString(dtRecords.Rows[Int1]["Facility_Street"]));
                strBody = strBody.Replace("[Facility_City]", string.IsNullOrEmpty(Convert.ToString(dtRecords.Rows[Int1]["Facility_City"])) ? "&nbsp;" : Convert.ToString(dtRecords.Rows[Int1]["Facility_City"]));
                strBody = strBody.Replace("[Facility_State]", string.IsNullOrEmpty(Convert.ToString(dtRecords.Rows[Int1]["Facility_State"])) ? "&nbsp;" : Convert.ToString(dtRecords.Rows[Int1]["Facility_State"]));
                strBody = strBody.Replace("[Facility_Zip]", string.IsNullOrEmpty(Convert.ToString(dtRecords.Rows[Int1]["Facility_Zip_Code"])) ? "&nbsp;" : Convert.ToString(dtRecords.Rows[Int1]["Facility_Zip_Code"]));

                if (strEmergency_Room.ToLower() == "y")
                {
                    strBody = strBody.Replace("[Img_Yes1]", ImgChecked);
                    strBody = strBody.Replace("[img_N01]", ImgUnchecked);
                }
                else if (strEmergency_Room.ToLower() == "n")
                {
                    strBody = strBody.Replace("[Img_Yes1]", ImgUnchecked);
                    strBody = strBody.Replace("[img_N01]", ImgChecked);
                }
                else
                {
                    strBody = strBody.Replace("[Img_Yes1]", ImgUnchecked);
                    strBody = strBody.Replace("[img_N01]", ImgUnchecked);
                }

                if (strHospitalized.ToLower() == "true")
                {
                    strBody = strBody.Replace("[Img_Yes2]", ImgChecked);
                    strBody = strBody.Replace("[Img_No2]", ImgUnchecked);
                }
                else if (strHospitalized.ToLower() == "false")
                {
                    strBody = strBody.Replace("[Img_Yes2]", ImgUnchecked);
                    strBody = strBody.Replace("[Img_No2]", ImgChecked);
                }
                else
                {
                    strBody = strBody.Replace("[Img_Yes2]", ImgUnchecked);
                    strBody = strBody.Replace("[Img_No2]", ImgUnchecked);
                }

                strBody = strBody.Replace("[Case_Number]", string.IsNullOrEmpty(Convert.ToString(dtRecords.Rows[Int1]["Case_Number"])) ? "&nbsp;" : Convert.ToString(dtRecords.Rows[Int1]["Case_Number"]));
                strBody = strBody.Replace("[Injury_D1]", string.IsNullOrEmpty(Convert.ToString(dtRecords.Rows[Int1]["Injury_D1"])) ? "&nbsp;" : Convert.ToString(dtRecords.Rows[Int1]["Injury_D1"]));
                strBody = strBody.Replace("[Injury_D2]", string.IsNullOrEmpty(Convert.ToString(dtRecords.Rows[Int1]["Injury_D2"])) ? "&nbsp;" : Convert.ToString(dtRecords.Rows[Int1]["Injury_D2"]));
                strBody = strBody.Replace("[Injury_D3]", string.IsNullOrEmpty(Convert.ToString(dtRecords.Rows[Int1]["Injury_D3"])) ? "&nbsp;" : Convert.ToString(dtRecords.Rows[Int1]["Injury_D3"]));

                strBody = strBody.Replace("[Time_began]", string.IsNullOrEmpty(Convert.ToString(dtRecords.Rows[Int1]["Time_Began_Work"])) ? "&nbsp;" : Convert.ToString(dtRecords.Rows[Int1]["Time_Began_Work"]));

                if (strTime_Began_Work_AM_PM.ToUpper() == "AM")
                {
                    strBody = strBody.Replace("[WORK_AM]", ImgChecked);
                    strBody = strBody.Replace("[WORK_PM]", ImgUnchecked);
                }
                else if (strTime_Began_Work_AM_PM.ToUpper() == "PM")
                {
                    strBody = strBody.Replace("[WORK_AM]", ImgUnchecked);
                    strBody = strBody.Replace("[WORK_PM]", ImgChecked);
                }
                else
                {
                    strBody = strBody.Replace("[WORK_AM]", ImgUnchecked);
                    strBody = strBody.Replace("[WORK_PM]", ImgUnchecked);
                }

                strBody = strBody.Replace("[Event_time]", string.IsNullOrEmpty(Convert.ToString(dtRecords.Rows[Int1]["Event_Time"])) ? "&nbsp;" : Convert.ToString(dtRecords.Rows[Int1]["Event_Time"]));

                if (strEvent_Time_AM_PM.ToUpper() == "AM")
                {
                    strBody = strBody.Replace("[EVENT_CHeckIF]", ImgUnchecked);
                    strBody = strBody.Replace("[EVENT_AM]", ImgChecked);
                    strBody = strBody.Replace("[EVENT_PM]", ImgUnchecked);
                }
                else if (strEvent_Time_AM_PM.ToUpper() == "PM")
                {
                    strBody = strBody.Replace("[EVENT_CHeckIF]", ImgUnchecked);
                    strBody = strBody.Replace("[EVENT_AM]", ImgUnchecked);
                    strBody = strBody.Replace("[EVENT_PM]", ImgChecked);
                }
                else
                {
                    strBody = strBody.Replace("[EVENT_CHeckIF]", ImgChecked);
                    strBody = strBody.Replace("[EVENT_AM]", ImgUnchecked);
                    strBody = strBody.Replace("[EVENT_PM]", ImgUnchecked);
                }

                strBody = strBody.Replace("[Pre_Incident_Description]", string.IsNullOrEmpty(Convert.ToString(dtRecords.Rows[Int1]["Activity_Before_Incident"])) ? "&nbsp;" : Convert.ToString(dtRecords.Rows[Int1]["Activity_Before_Incident"]));
                strBody = strBody.Replace("[Claim_Description]", string.IsNullOrEmpty(Convert.ToString(dtRecords.Rows[Int1]["Description_of_Incident"])) ? "&nbsp;" : Convert.ToString(dtRecords.Rows[Int1]["Description_of_Incident"]));
                strBody = strBody.Replace("[FK_LU_Nature_Of_Loss]", string.IsNullOrEmpty(Convert.ToString(dtRecords.Rows[Int1]["Injury_Or_Illness"])) ? "&nbsp;" : Convert.ToString(dtRecords.Rows[Int1]["Injury_Or_Illness"]));
                strBody = strBody.Replace("[OSHA_Object_Substance]", string.IsNullOrEmpty(Convert.ToString(dtRecords.Rows[Int1]["Object_Substance_Involved"])) ? "&nbsp;" : Convert.ToString(dtRecords.Rows[Int1]["Object_Substance_Involved"]));

                strBody = strBody.Replace("[DOD1]", string.IsNullOrEmpty(Convert.ToString(dtRecords.Rows[Int1]["DOD1"])) ? "&nbsp;" : Convert.ToString(dtRecords.Rows[Int1]["DOD1"]));
                strBody = strBody.Replace("[DOD2]", string.IsNullOrEmpty(Convert.ToString(dtRecords.Rows[Int1]["DOD2"])) ? "&nbsp;" : Convert.ToString(dtRecords.Rows[Int1]["DOD2"]));
                strBody = strBody.Replace("[DOD3]", string.IsNullOrEmpty(Convert.ToString(dtRecords.Rows[Int1]["DOD3"])) ? "&nbsp;" : Convert.ToString(dtRecords.Rows[Int1]["DOD3"]));

                strBody = strBody = strBody.Replace("[Image_Logo]", AppConfig.SiteURL + "Images/OSHA_301_LOGO1.png");
                //strBody = strBody = strBody.Replace("[Heading_1]", AppConfig.SiteURL + "Images/OSHA_300_1.JPG");
               // strBody = strBody = strBody.Replace("[Heading_2]", AppConfig.SiteURL + "Images/OSHA_300_3.JPG");


                strBody = strBody.Replace("[Page_Number]", Convert.ToString(Page_Cntr));
                strBody = strBody.Replace("[Totals]", Convert.ToString(dsReport.Tables[0].Rows.Count));
                
                strBody = strBody.Replace("[table_Row]", SbTemp.ToString());
                SbTemp2.Append(string.Concat(((SbTemp2.Length > 0) ? strPageBreak : ""), strBody));

                #endregion

                Page_Cntr++;

            }
            GenerateDOTAbstractPDF(SbTemp2);
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(typeof(string), DateTime.Now.ToString(), "javascript:alert('No data available to generate report for selected OSHA Coordinator/Incident Dates.');", true);
        }
    }

    /// <summary>
    /// Location bind
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ddlOSHA_Coordinator_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlOSHA_Coordinator.SelectedIndex > 0)
        {
            ComboHelper.FillLocationByRLCM(new DropDownList[] { ddlLocation }, Convert.ToDecimal(ddlOSHA_Coordinator.SelectedValue), true, true);
        }
        else
        {
            ddlLocation.Items.Clear();
            ddlLocation.Items.Add(new ListItem("-- Select --", "0"));
        }
    }
    #endregion

    #region "Methods"

    private void BindDropDownList()
    {
        ComboHelper.FillOSHA_Employee(new DropDownList[] { ddlOSHA_Coordinator }, true);
    }

    private void GenerateDOTAbstractPDF(StringBuilder Lettertext)
    {

        string strFileName = "OSHA_301.pdf";
        PdfConverter objPdf = new PdfConverter();
        objPdf.LicenseKey = AppConfig._strHtmltoPDFConverterKey;

        objPdf.PdfDocumentOptions.TopMargin = 20;
        objPdf.PdfDocumentOptions.LeftMargin = 20;
        objPdf.PdfDocumentOptions.RightMargin = 20;
        objPdf.PdfDocumentOptions.BottomMargin = 20;
        objPdf.PdfDocumentOptions.ShowHeader = false;
        objPdf.PdfDocumentOptions.ShowFooter = false;
        objPdf.PdfDocumentOptions.EmbedFonts = false;
        objPdf.PdfFooterOptions.TextArea = new TextArea(700, 30, "Page &p; ",
        new System.Drawing.Font(new System.Drawing.FontFamily("Times New Roman"), 10, System.Drawing.GraphicsUnit.Point));//of &P;
        objPdf.PdfFooterOptions.TextArea.EmbedTextFont = true;
        objPdf.PdfDocumentOptions.LiveUrlsEnabled = false;
        objPdf.RightToLeftEnabled = false;
        objPdf.PdfSecurityOptions.CanPrint = true;
        objPdf.PdfSecurityOptions.CanEditContent = true;
        objPdf.PdfSecurityOptions.UserPassword = "";
        objPdf.PdfDocumentOptions.PdfPageOrientation = PDFPageOrientation.Landscape;
        objPdf.PdfDocumentOptions.PdfCompressionLevel = PdfCompressionLevel.Normal;
        objPdf.PdfDocumentOptions.PdfPageSize = PdfPageSize.Letter;

        objPdf.AvoidTextBreak = false;

        StringBuilder sbHtml = new StringBuilder();

        objPdf.PdfDocumentInfo.AuthorName = "eRIMS2";


        Document doc = objPdf.GetPdfDocumentObjectFromHtmlString(string.Empty);
        objPdf.PdfFooterOptions.ShowPageNumber = false;

        doc.AutoCloseAppendedDocs = true;
        doc.RemovePage(0);
        sbHtml = Lettertext;
        string[] arPDF = sbHtml.ToString().Split(new string[] { "<br style=\"page-break-before: always\" />" }, StringSplitOptions.None);

        for (int i = 0; i < arPDF.Length; i++)
        {
            Document document1 = objPdf.GetPdfDocumentObjectFromHtmlString(arPDF[i]);
            // document1.FooterTemplate.DrawOnFirstPage = false;
            doc.AppendDocument(document1);
        }

        Byte[] pdfByte = null;
        try
        {
            pdfByte = doc.Save();
        }
        finally
        {
            // Close the Document to release all the resources
            // The appended document1 will be automatically closed also
            doc.Close();
        }

        HttpContext.Current.Response.Clear();
        HttpContext.Current.Response.AddHeader("Content-Type", "binary/octet-stream");
        HttpContext.Current.Response.AddHeader("Content-Disposition", ("attachment; filename=" + strFileName + "; size=") + pdfByte.Length.ToString());
        HttpContext.Current.Response.Flush();
        HttpContext.Current.Response.BinaryWrite(pdfByte);
        HttpContext.Current.Response.Flush();
        HttpContext.Current.Response.End();
    }
    
    #endregion
}