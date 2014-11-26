using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using Aspose.Words;
using Aspose.Words.Drawing;

public partial class SONIC_Exposures_Report : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
                            
        }
    }

    protected void lnkGenerateDoc_Click(object sender, EventArgs e)
    {
        #region " GENERATE WORD DOCUMENT "

        if (!string.IsNullOrEmpty(Request.QueryString["id"]))
        {
            lnktest.Attributes.Add("onclick", "javascript:clockStop()");     
            int ID = 0;
            if (int.TryParse(Encryption.Decrypt(Request.QueryString["id"]), out ID))
            {
                int PK_Inspection_ID = ID;

                string strHTML = InspectionWordDocument.PrepareMailForSend(PK_Inspection_ID).ToString(); ;

                string strLisenceFile = HttpContext.Current.Server.MapPath(HttpContext.Current.Request.ApplicationPath) + "\\" + ("Bin") + "\\Aspose.Words.lic";
                if (File.Exists(strLisenceFile))
                {
                    //This shows how to license Aspose.Words, if you don't specify a license, 
                    //Aspose.Words works in evaluation mode.
                    Aspose.Words.License license = new Aspose.Words.License();
                    license.SetLicense(strLisenceFile);
                }

                Aspose.Words.Document doc = new Aspose.Words.Document();
              
                //Build string builder to transport to Doc
                //Once the builder is created, its cursor is positioned at the beginning of the document.
                Aspose.Words.DocumentBuilder builder = new Aspose.Words.DocumentBuilder(doc);

                builder.PageSetup.BottomMargin = 15;
                builder.PageSetup.TopMargin = 15;
                builder.PageSetup.LeftMargin = 15;
                builder.PageSetup.RightMargin = 15;
                builder.Font.Size = 10;
                builder.Font.Bold = false;
                builder.Font.Color = System.Drawing.Color.Black;
                builder.Font.Name = "Arial";
                builder.PageSetup.PageNumberStyle = NumberStyle.Number;
                builder.InsertParagraph();
                builder.InsertHtml(strHTML);

                //builder.Write(litLetter.Text);
                //doc.MailMerge.Execute(dt);
                //Don't need merge fields in the document anymore.
                doc.MailMerge.DeleteFields();
                builder.MoveToSection(0);
                builder.MoveToHeaderFooter(HeaderFooterType.FooterPrimary);
                builder.ParagraphFormat.Alignment = ParagraphAlignment.Center;

                builder.Write("Page ");

                builder.InsertField("PAGE", "");

                builder.Write(" of ");

                builder.InsertField("NUMPAGES", "");

                Section section = doc.Sections[0];                  
                section.PageSetup.PageStartingNumber = 1;
                section.PageSetup.RestartPageNumbering = true;                 
                section.PageSetup.PageNumberStyle = NumberStyle.Arabic;

                Aspose.Words.Tables.Table table = (Aspose.Words.Tables.Table)doc.GetChild(NodeType.Table, 0, true);
                table.AllowAutoFit = false;

                //doc.Save("InspectionReport.doc", Aspose.Words.SaveFormat.Doc, Aspose.Words.SaveType.OpenInWord, Response);               
                doc.Save(Response, "InspectionReport.doc", ContentDisposition.Attachment, Aspose.Words.Saving.SaveOptions.CreateSaveOptions(SaveFormat.Doc));                
                Response.End(); 
            }
        }
        #endregion           
    }
}
