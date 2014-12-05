using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data;
using System.IO;
using System.Text;
using ERIMS.DAL;
using Aspose.Words;

public partial class Controls_SonicClaimNotes_AdjusterNotes : System.Web.UI.UserControl
{
    #region " Enums "
    public enum ClaimType
    {
        AL = 1,
        PL = 2,
        WC = 3
    }

    #endregion

    #region " Properties "

    public ClaimType CurrentClaimType
    {
        get { return (ClaimType)Enum.Parse(typeof(ClaimType), Convert.ToString(ViewState["CurrentClaimType"])); }
        set { ViewState["CurrentClaimType"] = value; }
    }

    public long ClaimID
    {
        get { return Convert.ToInt64(ViewState["CurrentClaimID"]); }
        set { ViewState["CurrentClaimID"] = value; }
    }

    public bool IsMailVisible
    {
        get { return Convert.ToBoolean(ViewState["IsMailVisible"]); }
        set { ViewState["IsMailVisible"] = value; }
    }

    public string ClaimNumber
    {
        get { return Convert.ToString(ViewState["ClaimNumber"]); }
        set { ViewState["ClaimNumber"] = value; }
    }
    public int CurrentPage
    {
        get { return Convert.ToInt32(ViewState["CurrentPage"]); }
        set { ViewState["CurrentPage"] = value; }
    }
    public int PageSize
    {
        get { return Convert.ToInt32(ViewState["PageSize"]); }
        set { ViewState["PageSize"] = value; }
    }

    /// <summary>
    /// Denotes Sort Field to sort all records by
    /// </summary>
    private string SortBy
    {
        get { return (!clsGeneral.IsNull(ViewState["SortBy"]) ? ViewState["SortBy"].ToString() : string.Empty); }
        set { ViewState["SortBy"] = value; }
    }

    /// <summary>
    /// Denotes ascending or descending order
    /// </summary>
    private string SortOrder
    {
        get { return (!clsGeneral.IsNull(ViewState["SortOrder"]) ? ViewState["SortOrder"].ToString() : string.Empty); }
        set { ViewState["SortOrder"] = value; }
    }

    #endregion

    #region " Page Events "

    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsMailVisible && CurrentClaimType == ClaimType.AL && gvNotesList.Rows.Count == 0)
        {
            btnView.Visible = false;
            btnPrint.Visible = false;
            SortBy = "Data_Entry_Date";
            SortOrder = "DESC";
            gvNotesList.DataBind();
        }
        
        if (CurrentClaimType == ClaimType.WC)
        {
            btnShowAPEVNotes.Visible = true;
        }
        //if (!IsPostBack)
        //{
        //    //btnShowAPEVNotes.Text = "Show AP/EV Notes Only";
        //}
    }

    #endregion

    #region " Methods "

    /// <summary>
    /// Function to bind notes details when click on note list
    /// </summary>
    /// <param name="PK_ID">Claim Note PK Id</param>
    /// <returns></returns>
    private bool BindClaimNotesDetails(Int64 PK_ID)
    {
        DataTable dtClaims_Adjustor_Notes = Claims_Adjustor_Notes.SelectByPK(PK_ID.ToString()).Tables[0];
        if (dtClaims_Adjustor_Notes.Rows.Count > 0)
        {
            DataRow drClaims_Adjustor_Notes = dtClaims_Adjustor_Notes.Rows[0];

            lblDataSource2.Text = Convert.ToString(drClaims_Adjustor_Notes["Data_Source"]);
            lblSourceUniqueClaimNumber.Text = Convert.ToString(drClaims_Adjustor_Notes["Source_Unique_Claim_Number"]);
            lblClaimantName.Text = Convert.ToString(drClaims_Adjustor_Notes["Claimant_Name"]);
            lblAccidentDate.Text = drClaims_Adjustor_Notes["Accident_Date"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drClaims_Adjustor_Notes["Accident_Date"]));
            lblClaimantSSN.Text = Convert.ToString(drClaims_Adjustor_Notes["Claimant_SSN"]);
            lblDataEntryDate.Text = drClaims_Adjustor_Notes["Data_Entry_Date"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drClaims_Adjustor_Notes["Data_Entry_Date"]));
            lblActivityType.Text = Convert.ToString(drClaims_Adjustor_Notes["Activity_Type_Description"]);
            lblInitials.Text = Convert.ToString(drClaims_Adjustor_Notes["Initials"]);
            lblDataReceivedDate.Text = drClaims_Adjustor_Notes["Data_Received_Date"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drClaims_Adjustor_Notes["Data_Received_Date"]));
            lblNoteText.Text = Convert.ToString(drClaims_Adjustor_Notes["Note_Text"]);
            lblMultiNoteIndicator.Text = Convert.ToString(drClaims_Adjustor_Notes["MultiNote_Indicator"]);

            return true;
        }
        return false;
    }

    public void BindGridNotes(string strClaimNumber)
    {
        CurrentPage = ctrlPageNotes.CurrentPage;
        PageSize = ctrlPageNotes.PageSize;

        string strDateOrder = string.Empty;

        bool isShowAPEVNotesOnly = false;

        if (SortBy != string.Empty && SortOrder != string.Empty)
        {
            strDateOrder = SortBy + ' ' + SortOrder;
        }
        else
        {
            strDateOrder = "Data_Entry_Date DESC";
        }

        if (btnShowAPEVNotes.Text == "Show All" && btnShowAPEVNotes.Visible)
        {
            isShowAPEVNotesOnly = true;
        }        

        DataSet dsNotes = Claims_Adjustor_Notes.SelectBySourceUniqueClaimNumber(strClaimNumber, CurrentPage, PageSize, strDateOrder,isShowAPEVNotesOnly);
        //DataSet dsNotes = Claims_Adjustor_Notes.SelectBySourceUniqueClaimNumber(strClaimNumber, CurrentPage, PageSize);

        DataTable dtNotes = dsNotes.Tables[0];
        ctrlPageNotes.TotalRecords = (dsNotes.Tables.Count >= 2) ? Convert.ToInt32(dsNotes.Tables[1].Rows[0][0]) : 0;
        ctrlPageNotes.CurrentPage = (dsNotes.Tables.Count >= 2) ? Convert.ToInt32(dsNotes.Tables[1].Rows[0][2]) : 0;
        ctrlPageNotes.RecordsToBeDisplayed = dsNotes.Tables[0].Rows.Count;
        ctrlPageNotes.SetPageNumbers();
        gvNotesList.DataSource = dtNotes;
        gvNotesList.DataBind();

        btnView.Visible = dtNotes.Rows.Count > 0;
        btnPrint.Visible = dtNotes.Rows.Count > 0;
    }

    private void PrintSelectedNotes(string strPKs)
    {
        DataTable dtClaim = null;
        if (CurrentClaimType == ClaimType.AL)
            dtClaim = AL_ClaimInfo.SelectByPK(ClaimID).Tables[0];
        else if (CurrentClaimType == ClaimType.PL)
            dtClaim = PL_ClaimInfo.SelectByPK(ClaimID).Tables[0];
        else if (CurrentClaimType == ClaimType.WC)
            dtClaim = WC_ClaimInfo.SelectByPK(ClaimID).Tables[0];

        DataTable dtNotes = Claims_Adjustor_Notes.SelectByPK(strPKs).Tables[0];
        StringBuilder sbHTML = new StringBuilder();

        #region " Generate HTML Text "

        string strTDBlue = "style='background-color:#95B3D7;border-top:black 1px solid;border-left:black 1px solid;'";
        string strTDWhite = "style='border-top:black 1px solid;border-left:black 1px solid;border-bottom:black 1px solid;'";
        sbHTML.Append("<HTML><Body>");
        sbHTML.Append("<b>eRIMS2 Sonic - Selected Claim Notes</b>");
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
        sbHTML.Append("<td align='left' " + strTDWhite + ">" + Convert.ToString(dtClaim.Rows[0]["Origin_Claim_Number"]) + "</td>");
        sbHTML.Append("<td align='left' " + strTDWhite + ">" + Convert.ToString(dtClaim.Rows[0]["dba1"]) + "</td>");
        sbHTML.Append("<td align='left' " + strTDWhite + ">" + Convert.ToString(dtClaim.Rows[0]["Employee_Name"]) + "</td>");
        sbHTML.Append("<td align='left' " + strTDWhite.TrimEnd('\'') + "border-right:black 1px solid;'>" + clsGeneral.FormatDBNullDateToDisplay(dtClaim.Rows[0]["Date_Of_Accident"]) + "</td>");
        sbHTML.Append("</tr>");
        sbHTML.Append("</table>");
        sbHTML.Append("<br />");

        sbHTML.Append("<table cellpadding='3' cellspacing='1' width='100%'>");
        int i = 0;
        foreach (DataRow drClaims_Adjustor_Notes in dtNotes.Rows)
        {
            sbHTML.Append("<tr>");
            sbHTML.Append("<td width='18%' align='left' valign='top'>Data Entry Date</td>");
            sbHTML.Append("<td width='4%' align='center' valign='top'>:</td>");
            sbHTML.Append("<td width='28%' align='left' valign='top'>" + clsGeneral.FormatDBNullDateToDisplay(Convert.ToDateTime(drClaims_Adjustor_Notes["Data_Entry_Date"])) + "</td>");
            sbHTML.Append("<td width='18%' align='left' valign='top'>Activity Type</td>");
            sbHTML.Append("<td width='4%' align='center' valign='top'>:</td>");
            sbHTML.Append("<td width='28%' align='left' valign='top'>" + Convert.ToString(drClaims_Adjustor_Notes["Activity_Type_Description"]) + "</td>");
            sbHTML.Append("</tr>");
            sbHTML.Append("<tr>");
            sbHTML.Append("<td align='left' valign='top'>Note Text</td>");
            sbHTML.Append("<td align='center' valign='top'>:</td>");
            sbHTML.Append("<td align='left' colspan='4' valign='top'>");
            sbHTML.Append(Convert.ToString(drClaims_Adjustor_Notes["Note_Text"]));
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
        doc.Save(Response, "ClaimNotes.doc", ContentDisposition.Attachment, Aspose.Words.Saving.SaveOptions.CreateSaveOptions(SaveFormat.Doc));
        Response.End();

        #endregion

    }

    #endregion

    #region " Gridview Events "

    protected void gvNotesList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //check Rowtype
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton lnkData_Entry_Date = (LinkButton)e.Row.FindControl("lnkData_Entry_Date");
            //check Date_Of_Incident value from datset. if it is not null than display it in proper format.
            if (DataBinder.Eval(e.Row.DataItem, "Data_Entry_Date") != DBNull.Value)
                lnkData_Entry_Date.Text = clsGeneral.FormatDateToDisplay(Convert.ToDateTime(DataBinder.Eval(e.Row.DataItem, "Data_Entry_Date")));
        }
    }

    protected void gvNotesList_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        //check Command Name
        if (e.CommandName == "View")
        {
            //Get the Claim Note ID
            long PK_ID = Convert.ToInt64(e.CommandArgument);

            //Bind the Claim Note Detail And make visible Note panel
            if (BindClaimNotesDetails(PK_ID))
            {
                pnlNotesDetail.Visible = true;
            }
        }
    }

    protected void gvNotesList_Sorting(object sender, GridViewSortEventArgs e)
    {
        if (SortOrder == "ASC")
        {
            SortOrder = "DESC";
        }
        else
        {
            SortOrder = "ASC";
        }

        SortBy = e.SortExpression;

        BindGridNotes(ClaimNumber);
    }

    #endregion

    #region " Controls Events "

    protected void btnView_Click(object sender, EventArgs e)
    {
        string strPK = "";

        foreach (GridViewRow gRow in gvNotesList.Rows)
        {
            if (((CheckBox)gRow.FindControl("chkAdjSelect")).Checked)
                strPK = strPK + ((HtmlInputHidden)gRow.FindControl("hdnID")).Value + ",";
        }
        strPK = strPK.TrimEnd(',');

        if (strPK != string.Empty)
        {
            if (strPK.IndexOf(',') > 0)
            {
                DataTable dtNotes = Claims_Adjustor_Notes.SelectByPK(strPK).Tables[0];
                rptNotes.DataSource = dtNotes;
                rptNotes.DataBind();
                hdnRptRows.Value = dtNotes.Rows.Count.ToString();

                pnlSelectedNotes.Visible = true;
                pnlNotesDetail.Visible = false;
                pnlGrid.Visible = false;
                btnMailNotes.Visible = true;
            }
            else
            {
                //Bind the Claim Note Detail And make visible Note panel
                if (BindClaimNotesDetails(Convert.ToInt32(strPK)))
                {
                    pnlNotesDetail.Visible = true;
                }
            }
        }
    }

    protected void btnShowAPEVNotes_Click(object sender, EventArgs e)
    {
        SortBy = string.Empty;
        SortOrder = string.Empty;

        if (btnShowAPEVNotes.Text == "Show Specific Notes Only")
        {
            btnShowAPEVNotes.Text = "Show All";
        }
        else
        {
            btnShowAPEVNotes.Text = "Show Specific Notes Only";
        }
        BindGridNotes(ClaimNumber);
    }

    protected void btnPrint_Click(object sender, EventArgs e)
    {
        string strSelected = "";
        foreach (GridViewRow gRow in gvNotesList.Rows)
        {
            if (((CheckBox)gRow.FindControl("chkAdjSelect")).Checked)
                strSelected = strSelected + ((HtmlInputHidden)gRow.FindControl("hdnID")).Value + ",";
        }
        strSelected = strSelected.TrimEnd(',');
        PrintSelectedNotes(strSelected);
    }

    protected void btnPrintSelectedNotes_Click(object sender, EventArgs e)
    {
        string strSelected = "";
        foreach (RepeaterItem rptItem in rptNotes.Items)
        {
            if (((CheckBox)rptItem.FindControl("chkRptNotesSelect")).Checked)
                strSelected = strSelected + ((HtmlInputHidden)rptItem.FindControl("hdnID")).Value + ",";
        }
        strSelected = strSelected.TrimEnd(',');
        PrintSelectedNotes(strSelected);
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        pnlSelectedNotes.Visible = false;
        pnlGrid.Visible = true;
        pnlNotesDetail.Visible = false;
    }

    protected void btnMailNotes_Click(object sender, EventArgs e)
    {
        string strPKs = "";
        foreach (RepeaterItem rptItem in rptNotes.Items)
        {
            if (((CheckBox)rptItem.FindControl("chkRptNotesSelect")).Checked)
                strPKs = strPKs + ((HtmlInputHidden)rptItem.FindControl("hdnID")).Value + ",";
        }
        strPKs = strPKs.TrimEnd(',');
        if (strPKs != "")
        {
            ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "", "OpenMailPopUp('" + strPKs + "','" + CurrentClaimType + "','" + ClaimID + "');", true);
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "", "javascript:alert('Please select claim Notes to mail');", true);
        }
    }

    protected void GetPage()
    {
        BindGridNotes(ClaimNumber);
    }
    #endregion
}
