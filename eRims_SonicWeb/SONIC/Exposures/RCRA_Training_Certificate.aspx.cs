using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;
using ERIMS.DAL;
using Winnovative.WnvHtmlConvert;
using Winnovative.WnvHtmlConvert.PdfDocument;
using System.Drawing;


public partial class SONIC_Exposures_RCRA_Training_Certificate : clsBasePage
{
    #region "Page Events"

    /// <summary>
    /// Page Load
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindDropDownList();
        }
    }

    #endregion

    #region "Methods"

    /// <summary>
    /// Bind Drop Down List
    /// </summary>
    private void BindDropDownList()
    {
        ComboHelper.FillRlcmDropDownList(new DropDownList[] { ddlRLCM }, true);
        ComboHelper.FillRegionByRLCM(new DropDownList[] { ddlRegion }, Convert.ToDecimal(ddlRLCM.SelectedValue), true);
        BindDropDowns();
    }

    /// <summary>
    /// Bind Drop Down according to RLCM and Region Value
    /// </summary>
    private void BindDropDowns()
    {
        ComboHelper.FillMarketByRLCMAndRegion(new DropDownList[] { ddlMarket }, Convert.ToDecimal(ddlRLCM.SelectedValue), Convert.ToString(ddlRegion.SelectedValue), true);
        ComboHelper.FillLocationByRLCMRegionMarket(new DropDownList[] { ddlLocation }, Convert.ToDecimal(ddlRLCM.SelectedValue), Convert.ToString(ddlRegion.SelectedValue), Convert.ToDecimal(ddlMarket.SelectedValue), true);
        ComboHelper.FillAssociateByRLCMRegionMarketLocation(new DropDownList[] { ddlAssociate }, Convert.ToDecimal(ddlRLCM.SelectedValue), Convert.ToString(ddlRegion.SelectedValue), Convert.ToDecimal(ddlMarket.SelectedValue), Convert.ToDecimal(ddlLocation.SelectedValue), true);
    }

    /// <summary>
    /// Generate RCRA Certificate PDF
    /// </summary>
    /// <param name="Lettertext"></param>
    /// <param name="strFilePath"></param>
    private void GenerateRCRACertificatePDF(StringBuilder Lettertext, string strFilePath)
    {
        PdfConverter objPdf = new PdfConverter();
        objPdf.LicenseKey = AppConfig._strHtmltoPDFConverterKey;
        objPdf.PdfDocumentOptions.LeftMargin = 46;
        objPdf.PdfDocumentOptions.RightMargin = 46;
        objPdf.PdfDocumentOptions.ShowHeader = true;
        objPdf.PdfDocumentOptions.ShowFooter = true;
        objPdf.PdfDocumentOptions.EmbedFonts = false;
        objPdf.PdfFooterOptions.DrawFooterLine = false;
        objPdf.PdfHeaderOptions.DrawHeaderLine = false;
        objPdf.PdfFooterOptions.ShowPageNumber = false;
        objPdf.PdfDocumentOptions.LiveUrlsEnabled = false;
        objPdf.RightToLeftEnabled = false;
        objPdf.PdfSecurityOptions.CanPrint = true;
        objPdf.PdfSecurityOptions.CanEditContent = true;
        objPdf.PdfSecurityOptions.UserPassword = "";
        objPdf.PdfDocumentOptions.PdfPageOrientation = PDFPageOrientation.Portrait;
        objPdf.PdfDocumentOptions.PdfCompressionLevel = PdfCompressionLevel.Normal;
        objPdf.PdfDocumentOptions.PdfPageSize = PdfPageSize.Letter;

        StringBuilder sbHtml = new StringBuilder();
        Document doc = objPdf.GetPdfDocumentObjectFromHtmlString("");

        // objPdf.PdfFooterOptions.FooterText = "https://sonicuniversity.skillport.com/skillportfe/reportCertificateOfCompletion.action?time...";
        // objPdf.PdfFooterOptions.TextArea = new TextArea(460, 15, clsGeneral.FormatDateToDisplay(DateTime.Now),
        //new System.Drawing.Font(new System.Drawing.FontFamily("Times New Roman"), 12, System.Drawing.GraphicsUnit.Point));
        objPdf.PdfFooterOptions.FooterHeight = 29;
        objPdf.PdfFooterOptions.FooterTextFontSize = 12;
        objPdf.PdfHeaderOptions.HeaderHeight = 20;
        objPdf.PdfHeaderOptions.HeaderTextFontSize = 12;
        //objPdf.PdfHeaderOptions.TextArea = new TextArea(5, 4, "Certificate Of Completion",
        //new System.Drawing.Font(new System.Drawing.FontFamily("Times New Roman"), 12, System.Drawing.GraphicsUnit.Point));
        //objPdf.PdfHeaderOptions.HeaderText = "Page 1 of 1";
        objPdf.PdfHeaderOptions.HeaderTextAlign = HorizontalTextAlign.Right;

        doc.AutoCloseAppendedDocs = true;
        doc.RemovePage(0);
        sbHtml = Lettertext;

        string[] arPDF = Lettertext.ToString().Split(new string[] { "<br style=\"page-break-before: always\" />" }, StringSplitOptions.None);

        for (int i = 0; i < arPDF.Length; i++)
        {
            Document document1 = objPdf.GetPdfDocumentObjectFromHtmlString(arPDF[i]);
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

    /// <summary>
    /// Open The Generated File
    /// </summary>
    /// <param name="strDir"></param>
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

            if (Directory.Exists(strzipDir))
            {
                string[] files = Directory.GetFiles(strzipDir);
                foreach (string file_Name in files)
                {
                    File.SetAttributes(file_Name, FileAttributes.Normal);
                    File.Delete(file_Name);
                }
            }
            System.IO.File.Delete(strzipDir + ".Zip");
            HttpContext.Current.Response.End();
        }
        else
        {
            if (Directory.Exists(strzipDir))
            {
                string[] files = Directory.GetFiles(strzipDir);
                foreach (string file_Name in files)
                {
                    File.SetAttributes(file_Name, FileAttributes.Normal);
                    File.Delete(file_Name);
                }
            }
            Page.ClientScript.RegisterStartupScript(typeof(string), DateTime.Now.ToString(), "javascript:alert('No data available to generate Safety Certificate for Year and Quarter.');", true);
        }
    }

    #endregion

    #region "Events"

    /// <summary>
    /// ddlRLCM Selected Index Change 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ddlRLCM_SelectedIndexChanged(object sender, EventArgs e)
    {
        ComboHelper.FillRegionByRLCM(new DropDownList[] { ddlRegion }, Convert.ToDecimal(ddlRLCM.SelectedValue), true);
        BindDropDowns();
    }

    /// <summary>
    /// ddlRegion Selected Index Change
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ddlRegion_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlRLCM.SelectedIndex > 0)
        {
            BindDropDowns();
        }
    }

    /// <summary>
    /// ddlMarket Selected Index Change
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ddlMarket_SelectedIndexChanged(object sender, EventArgs e)
    {
        ComboHelper.FillLocationByRLCMRegionMarket(new DropDownList[] { ddlLocation }, Convert.ToDecimal(ddlRLCM.SelectedValue), Convert.ToString(ddlRegion.SelectedValue), Convert.ToDecimal(ddlMarket.SelectedValue), true);
        ComboHelper.FillAssociateByRLCMRegionMarketLocation(new DropDownList[] { ddlAssociate }, Convert.ToDecimal(ddlRLCM.SelectedValue), Convert.ToString(ddlRegion.SelectedValue), Convert.ToDecimal(ddlMarket.SelectedValue), Convert.ToDecimal(ddlLocation.SelectedValue), true);
    }

    /// <summary>
    /// ddlLocation Selected Index Changed
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ddlLocation_SelectedIndexChanged(object sender, EventArgs e)
    {
        ComboHelper.FillAssociateByRLCMRegionMarketLocation(new DropDownList[] { ddlAssociate }, Convert.ToDecimal(ddlRLCM.SelectedValue), Convert.ToString(ddlRegion.SelectedValue), Convert.ToDecimal(ddlMarket.SelectedValue), Convert.ToDecimal(ddlLocation.SelectedValue), true);
    }

    /// <summary>
    /// button Show Report Click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnShowReport_Click(object sender, EventArgs e)
    {
        decimal fk_Employee_Id, fk_LU_Market, pk_LU_Location, pk_Employee_ID;
        int year, quarter, count = 0;
        string strRegion;

        fk_Employee_Id = Convert.ToDecimal(ddlRLCM.SelectedValue);
        strRegion = Convert.ToString(ddlRegion.SelectedValue);
        fk_LU_Market = Convert.ToDecimal(ddlMarket.SelectedValue);
        pk_Employee_ID = Convert.ToDecimal(ddlAssociate.SelectedValue);
        pk_LU_Location = Convert.ToDecimal(ddlLocation.SelectedValue);
        year = Convert.ToInt16(txtYear.Text);
        quarter = Convert.ToInt16(txtQuarter.Text);

        string strDir = string.Format(System.AppDomain.CurrentDomain.BaseDirectory.ToString() + @"temp\SafetyCertificate");

        if (!Directory.Exists(strDir))
            Directory.CreateDirectory(strDir);

        DataTable dtCertificateData = new DataTable();
        dtCertificateData = LU_Location.GetRLCMCertificateData(fk_Employee_Id, strRegion, fk_LU_Market, pk_LU_Location, pk_Employee_ID, year, quarter).Tables[0];

        if (dtCertificateData != null && dtCertificateData.Rows.Count > 0)
        {
            foreach (DataRow drCertificate in dtCertificateData.Rows)
            {
                FileStream fsMail;
                if(drCertificate.ItemArray[12].ToString() == "Hazardous Materials Transportation"){
                    fsMail = new FileStream(AppConfig.SitePath + @"\SONIC\RCRA\RCRA_Certificate_Hazmat.html", FileMode.Open, FileAccess.Read);
                }
                else
                {
                    fsMail = new FileStream(AppConfig.SitePath + @"\SONIC\RCRA\RCRA_Certificate.html", FileMode.Open, FileAccess.Read);
                }

                StreamReader rd = new StreamReader(fsMail);
                StringBuilder strBody = new StringBuilder();
                strBody = new StringBuilder(rd.ReadToEnd().ToString());
                rd.Close();
                fsMail.Close();

                strBody = strBody.Replace("[Employee_Name]", Convert.ToString(drCertificate["Associate_Name"]));
                strBody = strBody.Replace("[Course_Name]", Convert.ToString(drCertificate["Class_Name"]));
                strBody = strBody.Replace("[RCRA_Certificate]", AppConfig.ImageURL + "/Certificate.jpg");
                strBody = strBody.Replace("[RCRA_Certificate_Footer]", AppConfig.ImageURL + "/imgRCRAFooter.PNG");
                strBody = strBody.Replace("[Date]", (Convert.ToDateTime(drCertificate["Date of Completion"])).ToString("MMM dd, yyyy"));
                strBody = strBody.Replace("[Hazmat_Certificate_Sign]", AppConfig.ImageURL + "/Hazmat_certificate_sign.jpg");
                count++;
                GenerateRCRACertificatePDF(strBody, strDir + "\\SafetyCertificate_" + count + ".pdf");
            }

            OpenFile(strDir);
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(typeof(string), DateTime.Now.ToString(), "javascript:alert('No data available to generate certificate for selected Year and Quarter.');", true);
        }
    }


    /// <summary>
    /// button Clear Criteria Click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnClearCriteria_Click(object sender, EventArgs e)
    {
        txtQuarter.Text = txtYear.Text = string.Empty;
        ddlLocation.SelectedIndex = ddlMarket.SelectedIndex = ddlRegion.SelectedIndex = ddlRLCM.SelectedIndex = ddlAssociate.SelectedIndex = -1;
    }

    #endregion

}