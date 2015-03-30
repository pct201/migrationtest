using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.IO;
using System.Text;
using Aspose.Words;
using ERIMS.DAL;

/// <summary>
/// Summary description for clsPrintClaimNotesEPM
/// </summary>
public class clsPrintClaimNotesEPM
{
    public static void PrintSelectedSonicNotes(string strPKs, long ClaimID)
    {
        clsEPM_Identification objEPM_Identification = new clsEPM_Identification(ClaimID);
        LU_Location objLocation = new LU_Location(Convert.ToDecimal(objEPM_Identification.FK_LU_Location_Id));


        DataTable dtNotes = null;
        dtNotes = clsEPM_Consultant_Notes.SelectByIDs(strPKs).Tables[0];

        StringBuilder sbHTML = new StringBuilder();

        #region " Generate HTML Text "

        string strClaimNumber = "";
        string strProjectType = string.Empty;
        string strProjectNumber = string.Empty;
        string strDBA = "";
        string strNotes = "Selected EPM Consultant Notes";
        string strDocName = "EPMConsultantNotes.doc";
        string strAddress = "";
        string strCity = "";
        string strZip = "";
        string strState = "";
        string strSonicLocationNumber = "";

        if (!string.IsNullOrEmpty(objEPM_Identification.FK_LU_EPM_Project_Type.ToString()))
        strProjectType = new LU_EPM_Project_Type((decimal)objEPM_Identification.FK_LU_EPM_Project_Type).Fld_Desc;        
        strProjectNumber = objEPM_Identification.Project_Number;
        strClaimNumber = Convert.ToString(objEPM_Identification.PK_EPM_Identification);
        strDBA = Convert.ToString(objLocation.dba);
        if (objLocation.Sonic_Location_Code < 0)
        {
            strSonicLocationNumber = "";
        }
        else
            strSonicLocationNumber = Convert.ToString(objLocation.Sonic_Location_Code);
        strAddress = Convert.ToString(objLocation.Address_1);
        strCity = Convert.ToString(objLocation.City);

        if (!string.IsNullOrEmpty(objLocation.State.ToString()))
        strState = new State(Convert.ToDecimal(objLocation.State)).FLD_state;
        strZip = Convert.ToString(objLocation.Zip_Code);



        //strEmployeeName = Convert.ToString(dtClaim.Rows[0]["Employee_Name"]);

        string strTDBlue = "style='background-color:#95B3D7;border-top:black 1px solid;border-left:black 1px solid;'";
        string strTDWhite = "style='border-top:black 1px solid;border-left:black 1px solid;border-bottom:black 1px solid;'";
        sbHTML.Append("<HTML><Body>");
        sbHTML.Append("<b>" + strNotes + "</b>");
        sbHTML.Append("<br /></br />");
        sbHTML.Append("<table cellpadding='3' cellspacing='1' border='0' width='100%'>");
        sbHTML.Append("<tr>");
        sbHTML.Append("<td width='20%' align='left' " + strTDBlue + ">");
        sbHTML.Append("<span style='color:white'><b>Project Number</b></span>");
        sbHTML.Append("</td>");
        sbHTML.Append("<td width='15%' align='left' " + strTDBlue + ">");
        sbHTML.Append("<span style='color:white'><b>Project Type</b></span>");
        sbHTML.Append("</td>");
        sbHTML.Append("<td width='15%' align='left' " + strTDBlue.TrimEnd('\'') + "border-right:black 1px solid;'>");
        sbHTML.Append("<span style='color:white'><b>Location Number</b></span>");
        sbHTML.Append("</td>");
        sbHTML.Append("<td width='10%' align='left' " + strTDBlue.TrimEnd('\'') + "border-right:black 1px solid;'>");
        sbHTML.Append("<span style='color:white'><b>Sonic Location d/b/a</b></span>");
        sbHTML.Append("</td>");
        sbHTML.Append("<td width='10%' align='left' " + strTDBlue.TrimEnd('\'') + "border-right:black 1px solid;'>");
        sbHTML.Append("<span style='color:white'><b>Address</b></span>");
        sbHTML.Append("</td>");
        sbHTML.Append("<td width='10%' align='left' " + strTDBlue.TrimEnd('\'') + "border-right:black 1px solid;'>");
        sbHTML.Append("<span style='color:white'><b>City</b></span>");
        sbHTML.Append("</td>");
        sbHTML.Append("<td width='10%' align='left' " + strTDBlue.TrimEnd('\'') + "border-right:black 1px solid;'>");
        sbHTML.Append("<span style='color:white'><b>State</b></span>");
        sbHTML.Append("</td>");
        sbHTML.Append("<td width='10%' align='left' " + strTDBlue.TrimEnd('\'') + "border-right:black 1px solid;'>");
        sbHTML.Append("<span style='color:white'><b>Zip</b></span>");
        sbHTML.Append("</td>");
        sbHTML.Append("</tr>");
        sbHTML.Append("<tr>");
        sbHTML.Append("<td align='left' " + strTDWhite + ">" + strProjectNumber + "</td>");
        sbHTML.Append("<td align='left' " + strTDWhite + ">" + strProjectType + "</td>");
        sbHTML.Append("<td align='left' " + strTDWhite + ">" + strSonicLocationNumber + "</td>");
        sbHTML.Append("<td align='left' " + strTDWhite + ">" + strDBA + "</td>");
        sbHTML.Append("<td align='left' " + strTDWhite + ">" + strAddress + "</td>");
        sbHTML.Append("<td align='left' " + strTDWhite + ">" + strCity + "</td>");
        sbHTML.Append("<td align='left' " + strTDWhite + ">" + strState + "</td>");
        sbHTML.Append("<td align='left' " + strTDWhite.TrimEnd('\'') + "border-right:black 1px solid;'>" + strZip + "</td>");
        sbHTML.Append("</tr>");
        sbHTML.Append("</table>");
        sbHTML.Append("<br />");

        sbHTML.Append("<table cellpadding='3' cellspacing='1' width='100%'>");
        int i = 0;
        foreach (DataRow drClaims_Adjustor_Notes in dtNotes.Rows)
        {
            sbHTML.Append("<tr>");
            sbHTML.Append("<td width='18%' align='left' valign='top'>Date of Note</td>");
            sbHTML.Append("<td width='4%' align='center' valign='top'>:</td>");
            sbHTML.Append("<td align='left' valign='top'>" + clsGeneral.FormatDBNullDateToDisplay(Convert.ToDateTime(drClaims_Adjustor_Notes["Note_Date"])) + "</td>");
            sbHTML.Append("</tr>");
            sbHTML.Append("<tr>");
            sbHTML.Append("<td align='left' valign='top'>Notes</td>");
            sbHTML.Append("<td align='center' valign='top'>:</td>");
            sbHTML.Append("<td align='left' valign='top'>");
            sbHTML.Append(Convert.ToString(drClaims_Adjustor_Notes["Note"]));
            sbHTML.Append("</td>");
            sbHTML.Append("</tr>");

            if (i < dtNotes.Rows.Count - 1)
            {
                sbHTML.Append("<tr style='height:30px'>");
                sbHTML.Append("<td colspan='6' style='vertical-align:middle'><hr size='1' color='Black' /></td>");
                sbHTML.Append("</tr>");
            }

            i++;
        }

        sbHTML.Append("</table>");
        sbHTML.Append("</Body></HTML>");

        #endregion

        #region " Generate WORD Doc "
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
        builder.InsertParagraph();
        builder.InsertHtml(sbHTML.ToString());

        //Don't need merge fields in the document anymore.
        doc.MailMerge.DeleteFields();
        builder.MoveToSection(0);
        builder.MoveToHeaderFooter(HeaderFooterType.FooterPrimary);
        builder.PageSetup.PageNumberStyle = NumberStyle.Number;
        builder.ParagraphFormat.Alignment = ParagraphAlignment.Center;
        builder.Write("Page ");
        builder.InsertField("PAGE", "");
        builder.Write(" of ");
        builder.InsertField("NUMPAGES", "");
        Section section = doc.Sections[0];
        section.PageSetup.PageStartingNumber = 1;
        section.PageSetup.RestartPageNumbering = true;
        section.PageSetup.PageNumberStyle = NumberStyle.Arabic;

        // Remove content from merged cells.
        // Get collection of cells in the docuemnt.
        NodeCollection cells = doc.GetChildNodes(NodeType.Cell, true);

        foreach (Aspose.Words.Tables.Cell cell in cells)
        {
            // Check whether cell is merged with previouse.
            if (cell.CellFormat.HorizontalMerge == Aspose.Words.Tables.CellMerge.Previous || cell.CellFormat.VerticalMerge == Aspose.Words.Tables.CellMerge.Previous)
            {
                // Remove content from the cell.
                cell.RemoveAllChildren();
            }
        }

        //doc.Save("ClaimSonicNotes.doc", Aspose.Words.SaveFormat.Doc, Aspose.Words.SaveType.OpenInWord, HttpContext.Current.Response);
        doc.Save(HttpContext.Current.Response, strDocName, ContentDisposition.Attachment, Aspose.Words.Saving.SaveOptions.CreateSaveOptions(SaveFormat.Doc));
        HttpContext.Current.Response.End();
        #endregion
    }
}