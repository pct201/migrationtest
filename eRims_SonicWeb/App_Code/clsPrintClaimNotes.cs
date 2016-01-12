using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.IO;
using System.Text;
using Aspose.Words;
using ERIMS.DAL;



/// <summary>
/// Summary description for clsPrintClaimNotes
/// </summary>
public class clsPrintClaimNotes
{
	public clsPrintClaimNotes()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public static void PrintSelectedSonicNotes(string strPKs, string FK_Table_Name, long ClaimID)
    {
        DataTable dtClaim = null;
        if (FK_Table_Name.ToLower() == clsGeneral.Claim_Tables.ALClaim.ToString().ToLower())
            dtClaim = AL_ClaimInfo.SelectByPK(ClaimID).Tables[0];
        else if (FK_Table_Name.ToLower() == clsGeneral.Claim_Tables.PLClaim.ToString().ToLower())
            dtClaim = PL_ClaimInfo.SelectByPK(ClaimID).Tables[0];
        else if (FK_Table_Name.ToLower() == clsGeneral.Claim_Tables.DPDClaim.ToString().ToLower())
            dtClaim = DPD_ClaimInfo.SelectViewClaim(ClaimID).Tables[0];
        else if (FK_Table_Name.ToLower() == clsGeneral.Claim_Tables.PropertyClaim.ToString().ToLower())
            dtClaim = Property_ClaimInfo.SelectByPK(ClaimID).Tables[0];
        else if (FK_Table_Name.ToLower() == clsGeneral.Claim_Tables.WCClaim.ToString().ToLower())
            dtClaim = WC_ClaimInfo.SelectByPK(ClaimID).Tables[0];

        DataTable dtNotes = Claim_Notes.SelectByIDs(strPKs).Tables[0];
        StringBuilder sbHTML = new StringBuilder();

        #region " Generate HTML Text "
        
        string strClaimNumber = "";
        string strDBA = "";
        string strEmployeeName = "";
        string strDateOfIncident = "";

        
        if (FK_Table_Name.ToLower() == clsGeneral.Claim_Tables.DPDClaim.ToString().ToLower())
        {
            strClaimNumber = Convert.ToString(dtClaim.Rows[0]["Origin_Claim_Number"]);
            strDateOfIncident = clsGeneral.FormatDBNullDateToDisplay(dtClaim.Rows[0]["Date_Of_Loss"]);
        }
        else if (FK_Table_Name.ToLower() == clsGeneral.Claim_Tables.PropertyClaim.ToString().ToLower())
        {
            strClaimNumber = Convert.ToString(dtClaim.Rows[0]["Property_FR_Number"]);
            strDateOfIncident = clsGeneral.FormatDBNullDateToDisplay(dtClaim.Rows[0]["Date_Of_Loss"]);
        }
        else
        {
            strClaimNumber = Convert.ToString(dtClaim.Rows[0]["Origin_Claim_Number"]);
            strDateOfIncident = clsGeneral.FormatDBNullDateToDisplay(dtClaim.Rows[0]["Date_Of_Accident"]);
        }
        strDBA = Convert.ToString(dtClaim.Rows[0]["dba1"]);
        strEmployeeName = Convert.ToString(dtClaim.Rows[0]["Employee_Name"]);

        string strTDBlue = "style='background-color:#95B3D7;border-top:black 1px solid;border-left:black 1px solid;'";
        string strTDWhite = "style='border-top:black 1px solid;border-left:black 1px solid;border-bottom:black 1px solid;'";
        sbHTML.Append("<HTML><Body>");
        sbHTML.Append("<b>eRIMS2 Sonic - Selected Sonic Claim Notes</b>");
        sbHTML.Append("<br /></br />");
        sbHTML.Append("<table cellpadding='3' cellspacing='1' border='0' width='100%'>");
        sbHTML.Append("<tr>");
        sbHTML.Append("<td width='25%' align='left' " + strTDBlue + ">");
        sbHTML.Append("<span style='color:white'><b>Claim Number</b></span>");
        sbHTML.Append("</td>");
        sbHTML.Append("<td width='25%' align='left' " + strTDBlue + ">");
        sbHTML.Append("<span style='color:white'><b>Sonic Location d/b/a</b></span>");
        sbHTML.Append("</td>");
        sbHTML.Append("<td width='25%' align='left' " + strTDBlue + ">");
        sbHTML.Append("<span style='color:white'><b>Name</b></span>");
        sbHTML.Append("</td>");
        sbHTML.Append("<td width='25%' align='left' " + strTDBlue.TrimEnd('\'') + "border-right:black 1px solid;'>");
        sbHTML.Append("<span style='color:white'><b>Date of Incident</b></span>");
        sbHTML.Append("</td>");
        sbHTML.Append("</tr>");
        sbHTML.Append("<tr>");
        sbHTML.Append("<td align='left' " + strTDWhite + ">" + strClaimNumber + "</td>");
        sbHTML.Append("<td align='left' " + strTDWhite + ">" + strDBA + "</td>");
        sbHTML.Append("<td align='left' " + strTDWhite + ">" + strEmployeeName + "</td>");
        sbHTML.Append("<td align='left' " + strTDWhite.TrimEnd('\'') + "border-right:black 1px solid;'>" + strDateOfIncident + "</td>");
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
        doc.Save(HttpContext.Current.Response, "ClaimSonicNotes.doc", ContentDisposition.Attachment, Aspose.Words.Saving.SaveOptions.CreateSaveOptions(SaveFormat.Doc));
        HttpContext.Current.Response.End();
        #endregion
    }
}