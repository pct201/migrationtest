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
public class clsPrintEventNotes
{
	public clsPrintEventNotes()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public static void PrintSelectedNotes(string strPKs, decimal PK_Event,string strNote_Type)
    {
        string strEventNumber, strALFirstReport_No, strDPDFirstReport_No, strPDFirstReport_No, strPLFirstReport_No;
        strEventNumber = strALFirstReport_No = strDPDFirstReport_No = strPDFirstReport_No = strPLFirstReport_No = string.Empty;

        DataSet dsFR = clsEvent.GetFR_NumberByEvent(PK_Event);
        if (dsFR.Tables.Count > 0 && dsFR.Tables[0].Rows.Count > 0)
        {
            strEventNumber = dsFR.Tables[0].Rows[0]["Event_Number"].ToString();

            if (!string.IsNullOrEmpty(Convert.ToString(dsFR.Tables[0].Rows[0]["AL_FR_Number"])))
                strALFirstReport_No = "AL-" + Convert.ToString(dsFR.Tables[0].Rows[0]["AL_FR_Number"]);

            if (!string.IsNullOrEmpty(Convert.ToString(dsFR.Tables[0].Rows[0]["DPD_FR_Number"])))
                strDPDFirstReport_No = "DPD-" + Convert.ToString(dsFR.Tables[0].Rows[0]["DPD_FR_Number"]);

            if (!string.IsNullOrEmpty(Convert.ToString(dsFR.Tables[0].Rows[0]["PL_FR_Number"])))
                strPDFirstReport_No = "PL-" + Convert.ToString(dsFR.Tables[0].Rows[0]["PL_FR_Number"]);

            if (!string.IsNullOrEmpty(Convert.ToString(dsFR.Tables[0].Rows[0]["Prop_FR_Number"])))
                strPLFirstReport_No = "Prop-" + dsFR.Tables[0].Rows[0]["Prop_FR_Number"].ToString();

        }

        DataTable dtNotes;

        if (!string.IsNullOrEmpty(strPKs) && strNote_Type == "ACI")
            dtNotes = clsACI_Event_Notes.SelectByIDs(strPKs).Tables[0];
        else if (strNote_Type == "ACI")
            dtNotes = clsACI_Event_Notes.SelectByFK_Event(PK_Event, 1, 1000, "Note_Date", "asc").Tables[0];
        else if (!string.IsNullOrEmpty(strPKs))// && strNote_Type == "Sonic"
            dtNotes = clsSonic_Event_Notes.SelectByIDs(strPKs).Tables[0];
        else// if (strNote_Type == "ACI")
            dtNotes = clsSonic_Event_Notes.SelectByFK_Event(PK_Event).Tables[0];

        StringBuilder sbHTML = new StringBuilder();

        #region " Generate HTML Text "

        string strTDBlue = "style='background-color:#95B3D7;border-top:black 1px solid;border-left:black 1px solid;'";
        string strTDWhite = "style='border-top:black 1px solid;border-left:black 1px solid;border-bottom:black 1px solid;'";
        sbHTML.Append("<HTML><Body>");
        
        if(strNote_Type == "ACI")
            sbHTML.Append("<b>eRIMS2 Sonic - Selected Acadian Notes</b>");
        else
            sbHTML.Append("<b>eRIMS2 Sonic - Selected Sonic Notes</b>");

        sbHTML.Append("<br /></br />");
        sbHTML.Append("<table cellpadding='3' cellspacing='1' border='0' width='100%'>");
        sbHTML.Append("<tr>");
        sbHTML.Append("<td width='20%' align='left' " + strTDBlue + ">");
        sbHTML.Append("<span style='color:white'><b>Event Number</b></span>");
        sbHTML.Append("</td>");
        sbHTML.Append("<td width='20%' align='left' " + strTDBlue + ">");
        sbHTML.Append("<span style='color:white'><b>AL First Report #</b></span>");
        sbHTML.Append("</td>");
        sbHTML.Append("<td width='20%' align='left' " + strTDBlue + ">");
        sbHTML.Append("<span style='color:white'><b>DPD First Report #</b></span>");
        sbHTML.Append("</td>");
        sbHTML.Append("<td width='20%' align='left' " + strTDBlue + ">");
        sbHTML.Append("<span style='color:white'><b>PL First Report #</b></span>");
        sbHTML.Append("</td>");
        sbHTML.Append("<td width='20%' align='left' " + strTDBlue.TrimEnd('\'') + "border-right:black 1px solid;'>");
        sbHTML.Append("<span style='color:white'><b>Property First Report #</b></span>");
        sbHTML.Append("</td>");
        sbHTML.Append("</tr>");
        sbHTML.Append("<tr>");
        sbHTML.Append("<td align='left' " + strTDWhite + ">" + strEventNumber + "</td>");
        sbHTML.Append("<td align='left' " + strTDWhite + ">" + strALFirstReport_No + "</td>");
        sbHTML.Append("<td align='left' " + strTDWhite + ">" + strDPDFirstReport_No + "</td>");
        sbHTML.Append("<td align='left' " + strTDWhite + ">" + strPDFirstReport_No + "</td>");
        sbHTML.Append("<td align='left' " + strTDWhite.TrimEnd('\'') + "border-right:black 1px solid;'>" + strPLFirstReport_No + "</td>");

        sbHTML.Append("</tr>");
        sbHTML.Append("</table>");
        sbHTML.Append("<br />");

        sbHTML.Append("<table cellpadding='3' cellspacing='1' width='100%'>");
        int i = 0;
        foreach (DataRow drAdjustor_Notes in dtNotes.Rows)
        {
            sbHTML.Append("<tr>");
            sbHTML.Append("<td width='18%' align='left' valign='top'>Date of Note</td>");
            sbHTML.Append("<td width='4%' align='center' valign='top'>:</td>");
            sbHTML.Append("<td align='left' valign='top'>" + clsGeneral.FormatDBNullDateToDisplay(Convert.ToDateTime(drAdjustor_Notes["Note_Date"])) + "</td>");
            sbHTML.Append("</tr>");
            sbHTML.Append("<tr>");
            sbHTML.Append("<td align='left' valign='top'>Notes</td>");
            sbHTML.Append("<td align='center' valign='top'>:</td>");
            sbHTML.Append("<td align='left' valign='top'> ");
            sbHTML.Append(Convert.ToString(drAdjustor_Notes["Note"]));
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

        Aspose.Words.Tables.Table table = (Aspose.Words.Tables.Table)doc.GetChild(NodeType.Table, 0, true);
        table.AllowAutoFit = false;
        //doc.Save("ClaimNotes.doc", Aspose.Words.SaveFormat.Doc, Aspose.Words.SaveType.OpenInWord, Response);
        //doc.Save(Response, "EventNotes.doc", ContentDisposition.Attachment, Aspose.Words.Saving.SaveOptions.CreateSaveOptions(SaveFormat.Doc));
        //Response.End();
        doc.Save(HttpContext.Current.Response, "EventNotes.doc", ContentDisposition.Attachment, Aspose.Words.Saving.SaveOptions.CreateSaveOptions(SaveFormat.Doc));
        HttpContext.Current.Response.End();

        #endregion

    }

    
}