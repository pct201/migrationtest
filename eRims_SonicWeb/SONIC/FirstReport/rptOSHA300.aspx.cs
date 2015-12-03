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

public partial class SONIC_FirstReport_rptOSHA300 : clsBasePage
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
    protected void btnGenerate_Click(object sender, EventArgs e)
    {
        StringBuilder strBody = new StringBuilder();
        StringBuilder SbTemp1 = new StringBuilder(string.Empty);
        StringBuilder SbTemp2 = new StringBuilder(string.Empty);
        int Page_Cntr = 1;

        int Pages = 0;
        int Page_Size = 10;

        string strDir = string.Format(System.AppDomain.CurrentDomain.BaseDirectory.ToString() + @"temp\OSHA");

        if (!Directory.Exists(strDir))
            Directory.CreateDirectory(strDir);

        DataSet dsReport = clsOSHA.GetReportOSHA300(Convert.ToInt32(ddlYear.SelectedItem.Text), Page_Size, Convert.ToDecimal(ddlOSHA_Coordinator.SelectedValue));
        DataTable dtPrintRow = null;
        DataTable dtTotals = null;
        DataTable dtLocation = null;
        DataTable dtTotals_300A = null;
        DataTable dtRecords_300A = dsReport.Tables[4];

        if (dsReport != null)
        {
            dtPrintRow = dsReport.Tables[0];
            dtTotals = dsReport.Tables[1];
            dtLocation = dsReport.Tables[2];
            dtTotals_300A = dsReport.Tables[5];
        }

        if (dtPrintRow != null && dtPrintRow.Rows.Count > 0)
        {
            for (int Int1 = 0; Int1 < dtLocation.Rows.Count; Int1++)
            {
                Pages = Convert.ToInt32(dtLocation.Rows[Int1]["pages"]);

                for (int Int2 = 1; Int2 <= Pages; Int2++)
                {
                    #region ::OSHA 300::

                    FileStream fsMail = new FileStream(AppConfig.SitePath + @"\Documents\AbstractLetterTemplate\OSHA_300.htm", FileMode.Open, FileAccess.Read);
                    StreamReader rd = new StreamReader(fsMail);
                    strBody = new StringBuilder(rd.ReadToEnd().ToString());
                    rd.Close();
                    fsMail.Close();

                    #region "Row append"

                    StringBuilder SbTemp = new StringBuilder(string.Empty);
                    DataRow[] drPrintRowInner = dtPrintRow.Select("Establishment = '" + Convert.ToString(dtLocation.Rows[Int1]["Establishment"]).Replace("'", "''") + "' AND Page_No = " + Int2);
                    DataRow[] drPrintTotal = dtTotals.Select("Establishment = '" + Convert.ToString(dtLocation.Rows[Int1]["Establishment"]).Replace("'", "''") + "' AND Page_No = " + Int2);
                    int I4 = drPrintRowInner.Length;

                    for (int I3 = 0; I3 < I4; I3++)
                    {
                        SbTemp = SbTemp.Append(GetDataRows(drPrintRowInner[I3]));
                    }
                    if (I4 < Page_Size)
                    {
                        for (int I5 = 0; I5 < (Page_Size - I4); I5++)
                        {
                            SbTemp = SbTemp.Append(GetBlankRows());
                        }
                    }

                    #endregion

                    strBody.Replace("[Establishment_name]", string.IsNullOrEmpty(Convert.ToString(drPrintRowInner[0]["Establishment"])) ? "&nbsp;" : Convert.ToString(drPrintRowInner[0]["Establishment"]));
                    strBody = strBody.Replace("[City]", string.IsNullOrEmpty(Convert.ToString(drPrintRowInner[0]["City"])) ? "&nbsp;" : Convert.ToString(drPrintRowInner[0]["City"]));
                    strBody = strBody.Replace("[State]", string.IsNullOrEmpty(Convert.ToString(drPrintRowInner[0]["State"])) ? "&nbsp;" : Convert.ToString(drPrintRowInner[0]["State"]));

                    strBody = strBody = strBody.Replace("[OSHA_LOGO]", AppConfig.SiteURL + "Images/Osha_300A_Logo1.png");
                    strBody = strBody = strBody.Replace("[Heading_1]", AppConfig.SiteURL + "Images/OSHA_300_1.JPG");
                    strBody = strBody = strBody.Replace("[Heading_2]", AppConfig.SiteURL + "Images/OSHA_300_3.JPG");

                    strBody = strBody.Replace("[Year]", ddlYear.SelectedItem.Text);
                    strBody = strBody.Replace("[T_1]", Convert.ToString(drPrintTotal[0]["Total_G"]));
                    strBody = strBody.Replace("[T_2]", Convert.ToString(drPrintTotal[0]["Total_H"]));
                    strBody = strBody.Replace("[T_3]", Convert.ToString(drPrintTotal[0]["Total_I"]));
                    strBody = strBody.Replace("[T_4]", Convert.ToString(drPrintTotal[0]["Total_J"]));
                    strBody = strBody.Replace("[T_5]", Convert.ToString(drPrintTotal[0]["Total_K"]));
                    strBody = strBody.Replace("[T_6]", Convert.ToString(drPrintTotal[0]["Total_L"]));
                    strBody = strBody.Replace("[T_7]", Convert.ToString(drPrintTotal[0]["Total_1"]));
                    strBody = strBody.Replace("[T_8]", Convert.ToString(drPrintTotal[0]["Total_2"]));
                    strBody = strBody.Replace("[T_9]", Convert.ToString(drPrintTotal[0]["Total_3"]));
                    strBody = strBody.Replace("[T_10]", Convert.ToString(drPrintTotal[0]["Total_4"]));
                    strBody = strBody.Replace("[T_11]", Convert.ToString(drPrintTotal[0]["Total_5"]));
                    strBody = strBody.Replace("[T_12]", Convert.ToString(drPrintTotal[0]["Total_6"]));

                    strBody = strBody.Replace("[Page_Number]", Convert.ToString(Page_Cntr));
                    strBody = strBody.Replace("[Totals]", Convert.ToString(dsReport.Tables[3].Rows[0]["Total_Pages"]));
                    //strBody = strBody.Replace("[Totals]", Convert.ToString(region_Page));
                    strBody = strBody.Replace("[table_Row]", SbTemp.ToString());
                    strBody = strBody.Replace("[img_Osha_4]", AppConfig.ImageURL + "/OSHA_300_5.jpg");
                    strBody = strBody.Replace("[img_Osha_Spade]", AppConfig.ImageURL + "/Spade.PNG");
                    SbTemp2.Append(string.Concat(((SbTemp2.Length > 0) ? strPageBreak : ""), strBody));

                    #endregion

                    Page_Cntr++;
                }
            }
            GenerateDOTAbstractPDF(SbTemp2, string.Format(strDir + "\\OSHA_300.pdf"));
        }

        #region ::OSHA 300A::

        StringBuilder strBody_300A = new StringBuilder();

        if (dtRecords_300A.Rows.Count > 0)
        {
            for (int Int1 = 0; Int1 < dtRecords_300A.Rows.Count; Int1++)
            {
                FileStream fsMail300A = new FileStream(AppConfig.SitePath + @"\Documents\AbstractLetterTemplate\OSHA_300A.htm", FileMode.Open, FileAccess.Read);
                StreamReader rd300A = new StreamReader(fsMail300A);
                strBody_300A = new StringBuilder(rd300A.ReadToEnd().ToString());
                rd300A.Close();
                fsMail300A.Close();

                StringBuilder SbTemp = new StringBuilder(string.Empty);
                DataRow dr = dtRecords_300A.Rows[Int1];

                DataRow[] drTotals_300A = dtTotals_300A.Select("Establishment = '" + Convert.ToString(dr["Establishment"]).Replace("'", "''") + "'");

                #region "Data Replacement"
                strBody_300A = strBody_300A.Replace("[Year]", ddlYear.SelectedItem.Text);

                strBody_300A = strBody_300A.Replace("[Death_No]", drTotals_300A.Length > 0 ? Convert.ToString(drTotals_300A[0]["Total_G"]) : "0");
                strBody_300A = strBody_300A.Replace("[Total_Cases_Away]", drTotals_300A.Length > 0 ? Convert.ToString(drTotals_300A[0]["Total_H"]) : "0");
                strBody_300A = strBody_300A.Replace("[Total_Cases_Transfer]", drTotals_300A.Length > 0 ? Convert.ToString(drTotals_300A[0]["Total_I"]) : "0");
                strBody_300A = strBody_300A.Replace("[Recordable_Cases]", drTotals_300A.Length > 0 ? Convert.ToString(drTotals_300A[0]["Total_J"]) : "0");
                strBody_300A = strBody_300A.Replace("[Days_Away]", drTotals_300A.Length > 0 ? Convert.ToString(drTotals_300A[0]["Total_K"]) : "0");
                strBody_300A = strBody_300A.Replace("[Days_Job_transfer]", drTotals_300A.Length > 0 ? Convert.ToString(drTotals_300A[0]["Total_L"]) : "0");
                strBody_300A = strBody_300A.Replace("[Total_Injuries]", drTotals_300A.Length > 0 ? Convert.ToString(drTotals_300A[0]["Total_1"]) : "0");
                strBody_300A = strBody_300A.Replace("[Skin_Disorders]", drTotals_300A.Length > 0 ? Convert.ToString(drTotals_300A[0]["Total_2"]) : "0");
                strBody_300A = strBody_300A.Replace("[Respiratory_Conditions]", drTotals_300A.Length > 0 ? Convert.ToString(drTotals_300A[0]["Total_3"]) : "0");
                strBody_300A = strBody_300A.Replace("[Poisonings]", drTotals_300A.Length > 0 ? Convert.ToString(drTotals_300A[0]["Total_4"]) : "0");
                strBody_300A = strBody_300A.Replace("[Hearing_Loss]", drTotals_300A.Length > 0 ? Convert.ToString(drTotals_300A[0]["Total_5"]) : "0");
                strBody_300A = strBody_300A.Replace("[All_Other]", drTotals_300A.Length > 0 ? Convert.ToString(drTotals_300A[0]["Total_6"]) : "0");

                strBody_300A = strBody_300A.Replace("[Establishment_name]", string.IsNullOrEmpty(Convert.ToString(dr["Establishment"])) ? "&nbsp;" : Convert.ToString(dr["Establishment"]));
                strBody_300A = strBody_300A.Replace("[Street]", string.IsNullOrEmpty(Convert.ToString(dr["Street"])) ? "&nbsp;" : Convert.ToString(dr["Street"]));
                strBody_300A = strBody_300A.Replace("[City]", string.IsNullOrEmpty(Convert.ToString(dr["City"])) ? "&nbsp;" : Convert.ToString(dr["City"]));
                strBody_300A = strBody_300A.Replace("[State]", string.IsNullOrEmpty(Convert.ToString(dr["State"])) ? "&nbsp;" : Convert.ToString(dr["State"]));
                strBody_300A = strBody_300A.Replace("[Zip]", string.IsNullOrEmpty(Convert.ToString(dr["Zip_Code"])) ? "&nbsp;" : Convert.ToString(dr["Zip_Code"]));
                strBody_300A = strBody_300A.Replace("[Industry]", string.IsNullOrEmpty(Convert.ToString(dr["Industry_Description"])) ? "&nbsp;" : Convert.ToString(dr["Industry_Description"]));
                strBody_300A = strBody_300A.Replace("[SIC]", string.IsNullOrEmpty(Convert.ToString(dr["SIC"])) ? "&nbsp;" : Convert.ToString(dr["SIC"]));
                strBody_300A = strBody_300A.Replace("[NAICS]", string.IsNullOrEmpty(Convert.ToString(dr["NAICS"])) ? "&nbsp;" : Convert.ToString(dr["NAICS"]));
                strBody_300A = strBody_300A.Replace("[Average_Employees]", (string.Format("{0:N0}", dr["Number_Of_Employees"])));
                strBody_300A = strBody_300A.Replace("[Worked_hours]", (dr["Total_Hours_Worked_By_Employees"] == DBNull.Value) ? "&nbsp;" : (string.Format("{0:N0}", dr["Total_Hours_Worked_By_Employees"])));
                strBody_300A = strBody_300A.Replace("[Title]", string.IsNullOrEmpty(Convert.ToString(dr["Title"])) ? "&nbsp;" : Convert.ToString(dr["Title"]));
                strBody_300A = strBody_300A.Replace("[Tel1]", string.IsNullOrEmpty(Convert.ToString(dr["Telephone1"])) ? "&nbsp;" : Convert.ToString(dr["Telephone1"]));
                strBody_300A = strBody_300A.Replace("[Tel2]", string.IsNullOrEmpty(Convert.ToString(dr["Telephone2"])) ? "&nbsp;" : Convert.ToString(dr["Telephone2"]));
                strBody_300A = strBody_300A.Replace("[Tel3]", string.IsNullOrEmpty(Convert.ToString(dr["Telephone3"])) ? "&nbsp;" : Convert.ToString(dr["Telephone3"]));
                strBody_300A = strBody_300A.Replace("[Dt1]", DateTime.Now.Month.ToString());
                strBody_300A = strBody_300A.Replace("[Dt2]", DateTime.Now.Day.ToString());
                strBody_300A = strBody_300A.Replace("[Dt3]", DateTime.Now.Year.ToString());
                strBody_300A = strBody_300A.Replace("[Image_Logo]", AppConfig.SiteURL + "Images/Osha_300A_Logo1.png");
                SbTemp1.Append(string.Concat(((SbTemp1.Length > 0) ? strPageBreak : ""), strBody_300A));

                #endregion
            }

            GenerateDOTAbstractPDF(SbTemp1, string.Format(strDir + "\\OSHA_300A.pdf"));
        }

        #endregion
        OpenFile(strDir);

    }
    #endregion

    #region "Methods"

    private void BindDropDownList()
    {
        for (int i = DateTime.Now.Year; i >= 2015; i--)
        {
            ddlYear.Items.Add(new ListItem(i.ToString(), i.ToString()));
        }

        ComboHelper.FillOSHA_Employee(new DropDownList[] { ddlOSHA_Coordinator }, true);
    }

    private void GenerateDOTAbstractPDF(StringBuilder Lettertext, string strFilePath)
    {

        //string strFileName = "OSHA 300.pdf";
        PdfConverter objPdf = new PdfConverter();
        objPdf.LicenseKey = AppConfig._strHtmltoPDFConverterKey;

        objPdf.PdfDocumentOptions.TopMargin = 20;
        objPdf.PdfDocumentOptions.LeftMargin = 20;
        objPdf.PdfDocumentOptions.RightMargin = 20;
        objPdf.PdfDocumentOptions.BottomMargin = 20;
        objPdf.PdfDocumentOptions.ShowHeader = false;
        objPdf.PdfDocumentOptions.ShowFooter = true;
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
            document1.FooterTemplate.DrawOnFirstPage = false;
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

        File.WriteAllBytes(strFilePath, pdfByte);
    }

    public void OpenFile(string strDir)
    {
        string strzipDir = string.Format(strDir);
        int TotalfileCount = Directory.GetFiles(strzipDir, "*.*", SearchOption.AllDirectories).Length;
        if (TotalfileCount > 0)
        {
            clsGeneral.ConvertZIP(strzipDir);
            System.IO.FileInfo file = new System.IO.FileInfo(strzipDir + ".Zip");

            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.AddHeader("Content-Type", "binary/octet-stream");
            HttpContext.Current.Response.AddHeader("Content-Disposition", ("attachment; filename=" + file.Name + "; size=") + file.Length.ToString());
            HttpContext.Current.Response.Flush();
            HttpContext.Current.Response.WriteFile(file.FullName);
            HttpContext.Current.Response.Flush();
            System.IO.Directory.Delete(strzipDir, true);
            System.IO.File.Delete(strzipDir + ".Zip");
            HttpContext.Current.Response.End();
        }
        else
        {
            System.IO.Directory.Delete(strzipDir, true);
            Page.ClientScript.RegisterStartupScript(typeof(string), DateTime.Now.ToString(), "javascript:alert('No data available to generate report for selected OSHA Coordinator/year.');", true);
        }

        //HttpContext.Current.Response.Clear();
        //HttpContext.Current.Response.AddHeader("Content-Type", "binary/octet-stream");
        //HttpContext.Current.Response.AddHeader("Content-Disposition", ("attachment; filename=" + strFileName + "; size=") + pdfByte.Length.ToString());
        //HttpContext.Current.Response.Flush();
        //HttpContext.Current.Response.BinaryWrite(pdfByte);
        //HttpContext.Current.Response.Flush();
        //HttpContext.Current.Response.End();
    }

    private StringBuilder GenerateImageRemainedAtWork(string Type)
    {
        StringBuilder sbGrid = new StringBuilder(string.Empty);
        string ImgChecked = "<img src='" + AppConfig.SiteURL + "Images/Checkbox-checked_OSHA.bmp' alt=''style='height: 14px;' />";
        string ImgUnchecked = "<img src='" + AppConfig.SiteURL + "Images/Checkbox-unchecked_OSHA.bmp' alt=''style='height: 14px;' />";
        switch (Type)
        {

            case "G":
                sbGrid.Append("<td align='left'  valign='middle' width='23%'>&nbsp;" + ImgChecked + "</td>");
                sbGrid.Append("<td align='left'  valign='middle' width='25%'>&nbsp;" + ImgUnchecked + "</td>");
                sbGrid.Append("<td align='left'  valign='middle' width='25%'>&nbsp;" + ImgUnchecked + "</td>");
                sbGrid.Append("<td align='left'  valign='middle' width='25%'>&nbsp;" + ImgUnchecked + "</td>");
                break;
            case "H":
                sbGrid.Append("<td align='left'  valign='middle' width='23%'>&nbsp;" + ImgUnchecked + "</td>");
                sbGrid.Append("<td align='left'  valign='middle' width='25%'>&nbsp;" + ImgChecked + "</td>");
                sbGrid.Append("<td align='left'  valign='middle' width='25%'>&nbsp;" + ImgUnchecked + "</td>");
                sbGrid.Append("<td align='left'  valign='middle' width='25%'>&nbsp;" + ImgUnchecked + "</td>");
                break;
            case "I":
                sbGrid.Append("<td align='left'  valign='middle' width='23%'>&nbsp;" + ImgUnchecked + "</td>");
                sbGrid.Append("<td align='left'  valign='middle' width='25%'>&nbsp;" + ImgUnchecked + "</td>");
                sbGrid.Append("<td align='left'  valign='middle' width='25%'>&nbsp;" + ImgChecked + "</td>");
                sbGrid.Append("<td align='left'  valign='middle' width='25%'>&nbsp;" + ImgUnchecked + "</td>");
                break;
            case "J":
                sbGrid.Append("<td align='left'  valign='middle' width='23%'>&nbsp;" + ImgUnchecked + "</td>");
                sbGrid.Append("<td align='left'  valign='middle' width='25%'>&nbsp;" + ImgUnchecked + "</td>");
                sbGrid.Append("<td align='left'  valign='middle' width='25%'>&nbsp;" + ImgUnchecked + "</td>");
                sbGrid.Append("<td align='left'  valign='middle' width='25%'>&nbsp;" + ImgChecked + "</td>");
                break;
            default:
                sbGrid.Append("<td align='left'  valign='middle' width='23%'>&nbsp;" + ImgUnchecked + "</td>");
                sbGrid.Append("<td align='left'  valign='middle' width='25%'>" + ImgUnchecked + "</td>");
                sbGrid.Append("<td align='left'  valign='middle' width='25%'>" + ImgUnchecked + "</td>");
                sbGrid.Append("<td align='left'  valign='middle' width='23%'>" + ImgUnchecked + "</td>");
                break;

        }

        return sbGrid;
    }

    private StringBuilder GenerateImageInjuryType(string Type)
    {
        StringBuilder sbGrid = new StringBuilder(string.Empty);
        string ImgChecked = "<img src='" + AppConfig.SiteURL + "Images/Checkbox-checked_OSHA.bmp' alt=''style='height: 11px' />";
        string ImgUnchecked = "<img src='" + AppConfig.SiteURL + "Images/Checkbox-unchecked_OSHA.bmp' alt=''style='height: 11px' />";


        switch (Type)
        {
            case "1":
                sbGrid.Append("<td align='left' valign='middle' width='16%'>" + ImgChecked + "</td>");
                sbGrid.Append("<td align='left' valign='middle' width='15%'>" + ImgUnchecked + "</td>");
                sbGrid.Append("<td align='center' valign='middle' width='15%'>" + ImgUnchecked + "</td>");
                sbGrid.Append("<td align='right' valign='middle' width='15%'>" + ImgUnchecked + "</td>");
                sbGrid.Append("<td align='right' valign='middle' width='15%'>" + ImgUnchecked + "</td>");
                sbGrid.Append("<td align='center' valign='middle' width='19%'>" + ImgUnchecked + "</td>");
                break;
            case "2":
                sbGrid.Append("<td align='left' valign='middle' width='16%'>" + ImgUnchecked + "</td>");
                sbGrid.Append("<td align='left' valign='middle' width='15%'>" + ImgChecked + "</td>");
                sbGrid.Append("<td align='center' valign='middle' width='15%'>" + ImgUnchecked + "</td>");
                sbGrid.Append("<td align='right' valign='middle' width='15%'>" + ImgUnchecked + "</td>");
                sbGrid.Append("<td align='right' valign='middle' width='15%'>" + ImgUnchecked + "</td>");
                sbGrid.Append("<td align='center' valign='middle' width='19%'>" + ImgUnchecked + "</td>");
                break;
            case "3":
                sbGrid.Append("<td align='left' valign='middle' width='16%'>" + ImgUnchecked + "</td>");
                sbGrid.Append("<td align='left' valign='middle' width='15%'>" + ImgUnchecked + "</td>");
                sbGrid.Append("<td align='center' valign='middle' width='15%'>" + ImgChecked + "</td>");
                sbGrid.Append("<td align='right' valign='middle' width='15%'>" + ImgUnchecked + "</td>");
                sbGrid.Append("<td align='right' valign='middle' width='15%'>" + ImgUnchecked + "</td>");
                sbGrid.Append("<td align='center' valign='middle' width='19%'>" + ImgUnchecked + "</td>");
                break;
            case "4":
                sbGrid.Append("<td align='left' valign='middle' width='16%'>" + ImgUnchecked + "</td>");
                sbGrid.Append("<td align='left' valign='middle' width='15%'>" + ImgUnchecked + "</td>");
                sbGrid.Append("<td align='center' valign='middle' width='15%'>" + ImgUnchecked + "</td>");
                sbGrid.Append("<td align='right' valign='middle' width='15%'>" + ImgChecked + "</td>");
                sbGrid.Append("<td align='right' valign='middle' width='15%'>" + ImgUnchecked + "</td>");
                sbGrid.Append("<td align='center' valign='middle' width='19%'>" + ImgUnchecked + "</td>");
                break;
            case "5":
                sbGrid.Append("<td align='left' valign='middle' width='16%'>" + ImgUnchecked + "</td>");
                sbGrid.Append("<td align='left' valign='middle' width='15%'>" + ImgUnchecked + "</td>");
                sbGrid.Append("<td align='center' valign='middle' width='15%'>" + ImgUnchecked + "</td>");
                sbGrid.Append("<td align='right' valign='middle' width='15%'>" + ImgUnchecked + "</td>");
                sbGrid.Append("<td align='right' valign='middle' width='15%'>" + ImgChecked + "</td>");
                sbGrid.Append("<td align='center' valign='middle' width='19%'>" + ImgUnchecked + "</td>");
                break;
            case "6":
                sbGrid.Append("<td align='left' valign='middle' width='16%'>" + ImgUnchecked + "</td>");
                sbGrid.Append("<td align='left' valign='middle' width='15%'>" + ImgUnchecked + "</td>");
                sbGrid.Append("<td align='center' valign='middle' width='15%'>" + ImgUnchecked + "</td>");
                sbGrid.Append("<td align='right' valign='middle' width='15%'>" + ImgUnchecked + "</td>");
                sbGrid.Append("<td align='right' valign='middle' width='15%'>" + ImgUnchecked + "</td>");
                sbGrid.Append("<td align='center' valign='middle' width='19%'>&nbsp;" + ImgChecked + "</td>");
                break;
            default:
                sbGrid.Append("<td align='left' valign='middle' width='16%'>" + ImgUnchecked + "</td>");
                sbGrid.Append("<td align='left' valign='middle' width='15%'>" + ImgUnchecked + "</td>");
                sbGrid.Append("<td align='center' valign='middle' width='15%'>" + ImgUnchecked + "</td>");
                sbGrid.Append("<td align='right' valign='middle' width='15%'>" + ImgUnchecked + "</td>");
                sbGrid.Append("<td align='right' valign='middle' width='15%'>" + ImgUnchecked + "</td>");
                sbGrid.Append("<td align='center' valign='middle' width='19%'>" + ImgUnchecked + "</td>");
                break;
        }

        return sbGrid;

    }

    private StringBuilder GetDataRows(DataRow drPrintRow)
    {
        StringBuilder SbTemp = new StringBuilder(string.Empty);
        SbTemp.Append(" <tr><td width='22%' valign='bottom'>");
        SbTemp.Append("<table cellpadding='0' cellspacing='0' border='0' width='100%'>");
        SbTemp.Append("<tr><td width='2%'>&nbsp;</td><td align='left' valign='bottom' width='13%' style='border-bottom: 1px solid black;padding-left:5px;'><span style='font-family: Verdana; font-size: 8px; font-weight: normal'>" + (string.IsNullOrEmpty(Convert.ToString(drPrintRow["Case_Number"])) ? "&nbsp;" : Convert.ToString(drPrintRow["Case_Number"])) + "</span></td>");
        SbTemp.Append("<td width='2%'>&nbsp;</td>");
        SbTemp.Append("<td align='left' valign='bottom' width='45%' style='border-bottom: 1px solid black'><span style='font-family: Verdana; font-size: 8px; font-weight: normal'>" + (string.IsNullOrEmpty(Convert.ToString(drPrintRow["Employee"])) ? "&nbsp;" : Convert.ToString(drPrintRow["Employee"])) + "</span></td>");
        SbTemp.Append("<td width='2%'>&nbsp;</td>");
        SbTemp.Append("<td align='left' valign='bottom' width='24%' style='border-bottom: 1px solid black'><span style='font-family: Verdana; font-size: 8px; font-weight: normal'>" + (string.IsNullOrEmpty(Convert.ToString(drPrintRow["Job_Title"])) ? "&nbsp;" : (Convert.ToString(drPrintRow["Job_Title"]))) + "</span> </td>");
        SbTemp.Append("<td width='2%'>&nbsp;</td>");
        SbTemp.Append("</tr></table></td>");

        SbTemp.Append("<td width='38%' valign='bottom'><table cellpadding='0' cellspacing='0' border='0' style='width: 100%'><tr>");
        SbTemp.Append("<td width='1%'>&nbsp;</td>");
        SbTemp.Append(" <td align='left' valign='bottom' width='10%' style='border-bottom: 0px solid black'><span style='font-family: Verdana; font-size: 8px; font-weight: normal'><u>&nbsp;" + ((string.IsNullOrEmpty(Convert.ToString(drPrintRow["Month"])) ? "&nbsp;&nbsp;&nbsp;" : (Convert.ToString(drPrintRow["Month"]))) + "&nbsp;</u> / <u>&nbsp;" + (string.IsNullOrEmpty(Convert.ToString(drPrintRow["Day"])) ? "&nbsp;&nbsp;&nbsp;" : (Convert.ToString(drPrintRow["Day"])))) + "&nbsp;&nbsp;</u></span>");
        SbTemp.Append("<br><span style='font-family: Verdana; font-size: 4px; font-weight: normal'>month / day </span></td>");
        SbTemp.Append("<td width='3%'>&nbsp;</td>");
        SbTemp.Append(" <td align='left' valign='bottom' width='20%' style='border-bottom: 1px solid black'><span style='font-family: Verdana; font-size: 8px; font-weight: normal'>" + (string.IsNullOrEmpty(Convert.ToString(drPrintRow["Where_Event_Occured"])) ? "&nbsp;" : Convert.ToString(drPrintRow["Where_Event_Occured"])) + "</span></td>");
        SbTemp.Append("<td width='3%'>&nbsp;</td>");
        SbTemp.Append("<td align='left' valign='bottom' width='43%' style='border-bottom: 1px solid black'> <span style='font-family: Verdana; font-size: 8px; font-weight: normal'>" + (string.IsNullOrEmpty(Convert.ToString(drPrintRow["Describe_Injury"])) ? "&nbsp;" : Convert.ToString(drPrintRow["Describe_Injury"])) + "</span> </td>");
        SbTemp.Append("<td width='2%'>&nbsp;</td>");
        SbTemp.Append("</tr></table></td>");

        SbTemp.Append("<td width='18%' valign='bottom' align='left' style='padding-left:5px;background-color: #E0E0E0;'><table cellpadding='0' cellspacing='0' border='0' width='100%' style='height: 9px;'><tr>");
        SbTemp.Append(GenerateImageRemainedAtWork(Convert.ToString(drPrintRow["Remained_at_work"])));
        SbTemp.Append("</tr></table></td>");

        SbTemp.Append("<td width='9%' valign='bottom' align='left'><table cellpadding='2' cellspacing='0' border='0' style='width: 94%; height: 9px; margin-left: 2px'><tr>");
        SbTemp.Append("<td width='1%'>&nbsp;</td>");
        SbTemp.Append("<td align='left' valign='bottom' width='45%' style='border-bottom: 1px solid black'><span style='font-family: Verdana; font-size: 8px; font-weight: normal'>" + Convert.ToString(drPrintRow["OSHA_Days_Away_From_Work"]) + "</span></td>");
        SbTemp.Append("<td width='4%' valign='bottom' style='font-family:Times New Roman; font-size: 8px; font-weight: normal;'>days</td>");
        SbTemp.Append("<td align='left' valign='bottom' width='45%' style='border-bottom: 1px solid black'><span style='font-family: Verdana; font-size: 8px; font-weight: normal;'>" + Convert.ToString(drPrintRow["OSHA_Days_Job_Transfer_Restriction"]) + "</span></td>");
        SbTemp.Append("<td width='4%' valign='bottom' style='font-family:Times New Roman; font-size: 8px; font-weight: normal;'>days</td>");
        SbTemp.Append("</tr></table></td>");

        SbTemp.Append("<td width='4px'>&nbsp;</td>");

        SbTemp.Append("<td width='126px' valign='middle' align='left' style='padding-left:7px;background-color: #E0E0E0;' >");
        SbTemp.Append("<table cellpadding='0' cellspacing='0' border='0' width='100%' ><tr>");
        SbTemp.Append(GenerateImageInjuryType(Convert.ToString(drPrintRow["Injury"])));
        SbTemp.Append(" </tr></table></td></tr>");
        return SbTemp;

    }

    private StringBuilder GetBlankRows()
    {
        StringBuilder SbTemp = new StringBuilder(string.Empty);
        SbTemp.Append(" <tr><td width='22%' valign='bottom'>");
        SbTemp.Append("<table cellpadding='0' cellspacing='0' border='0' width='100%'>");
        SbTemp.Append("<tr><td width='2%'>&nbsp;</td><td align='left' valign='bottom' width='13%' style='border-bottom: 1px solid black;padding-left:5px;'><span style='font-family: Verdana; font-size: 7px; font-weight: normal'>&nbsp;</span></td>");
        SbTemp.Append("<td width='2%'>&nbsp;</td>");
        SbTemp.Append("<td align='left' valign='bottom' width='45%' style='border-bottom: 1px solid black'><span style='font-family: Verdana; font-size: 7px; font-weight: normal'>&nbsp;</span></td>");
        SbTemp.Append("<td width='2%'>&nbsp;</td>");
        SbTemp.Append("<td align='left' valign='bottom' width='24%' style='border-bottom: 1px solid black'><span style='font-family: Verdana; font-size: 7px; font-weight: normal'>&nbsp;</span> </td>");
        SbTemp.Append("<td width='2%'>&nbsp;</td>");
        SbTemp.Append("</tr></table></td>");

        SbTemp.Append("<td width='38%' valign='bottom'><table cellpadding='0' cellspacing='0' border='0' style='width: 100%'><tr>");
        SbTemp.Append("<td width='1%'>&nbsp;</td>");
        SbTemp.Append(" <td align='left' valign='bottom' width='10%' style='border-bottom: 0px solid black'><span style='font-family: Verdana; font-size: 7px; font-weight: normal'><u>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</u> / <u>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</u></span>");
        SbTemp.Append("<br><span style='font-family: Verdana; font-size: 4px; font-weight: normal'>month / day </span></td>");
        SbTemp.Append("<td width='3%'>&nbsp;</td>");
        SbTemp.Append(" <td align='left' valign='bottom' width='20%' style='border-bottom: 1px solid black'><span style='font-family: Verdana; font-size: 7px; font-weight: normal'>&nbsp;</span></td>");
        SbTemp.Append("<td width='3%'>&nbsp;</td>");
        SbTemp.Append("<td align='left' valign='bottom' width='43%' style='border-bottom: 1px solid black'> <span style='font-family: Verdana; font-size: 7px; font-weight: normal'>&nbsp;</span> </td>");
        SbTemp.Append("<td width='2%'>&nbsp;</td>");
        SbTemp.Append("</tr></table></td>");

        SbTemp.Append("<td width='18%' valign='bottom' align='left' style='padding-left:5px;background-color: #E0E0E0;'><table cellpadding='0' cellspacing='0' border='0' width='100%' style='height: 9px;'><tr>");
        SbTemp.Append(GenerateImageRemainedAtWork("5"));
        SbTemp.Append("</tr></table></td>");

        SbTemp.Append("<td width='9%' valign='bottom' align='left'><table cellpadding='2' cellspacing='0' border='0' style='width: 94%; height: 9px; margin-left: 2px'><tr>");
        SbTemp.Append("<td width='1%'>&nbsp;</td>");
        SbTemp.Append("<td align='left' valign='bottom' width='45%' style='border-bottom: 1px solid black'><span style='font-family: Verdana; font-size: 7px; font-weight: normal'>&nbsp;</span></td>");
        SbTemp.Append("<td width='4%' valign='bottom' style='font-family:Times New Roman; font-size: 7px; font-weight: normal;'>days</td>");
        SbTemp.Append("<td align='left' valign='bottom' width='45%' style='border-bottom: 1px solid black'><span style='font-family: Verdana; font-size: 7px; font-weight: normal;'>&nbsp;</span></td>");
        SbTemp.Append("<td width='4%' valign='bottom' style='font-family:Times New Roman; font-size: 7px; font-weight: normal;'>days</td>");
        SbTemp.Append("</tr></table></td>");

        SbTemp.Append("<td width='4px'>&nbsp;</td>");

        SbTemp.Append("<td width='126px' valign='middle' align='left' style='padding-left:7px;background-color: #E0E0E0;' >");
        SbTemp.Append("<table cellpadding='0' cellspacing='0' border='0' width='100%' ><tr>");
        SbTemp.Append(GenerateImageInjuryType("7"));
        SbTemp.Append(" </tr></table></td></tr>");

        return SbTemp;

    }

    #endregion
}