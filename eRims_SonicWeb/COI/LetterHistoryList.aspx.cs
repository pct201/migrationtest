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
using Aspose.Words;
using Aspose.Words.Drawing;
using System.IO;

using ERIMS.DAL;
public partial class Admin_LetterHistoryList : clsBasePage
{
    #region "Properties"
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

    //private const string strPrintPageBreak = "<div style=\"page-break-after: always\">&nbsp;</div>";
    private const string strPrintPageBreak = "<!-PAGE BREAK>";
   
    /// <summary>
    /// Handle Page Load Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        lnkPrintEnvelopes.Visible = false;
        lnkPrintLetters.Visible = false;
        drpSignature.Focus();
        // when first time the page is loaded
        if (!IsPostBack)
        {
            SortBy = "CI.Insured_Name";
            SortOrder = "asc";
            if (App_Access == AccessType.NotAssigned || App_Access == AccessType.View_Only)
                Response.Redirect(AppConfig.SiteURL + "Message.aspx?msg=You are not authorized to access this page");
            else
            {
                DataTable dtSign = COI_Signature.SelectAll().Tables[0];
                drpSignature.DataSource = dtSign;
                drpSignature.DataTextField = "Fld_Desc";
                drpSignature.DataValueField = "PK_COI_Signature";
                drpSignature.DataBind();
                drpSignature.Items.Insert(0, "--Select--");

                // Bind the grid with 10 rows initially
                BindGrid(1, 10);
            }
        }
    }

    /// <summary>
    /// Binds the grid by page number and page size
    /// </summary>
    /// <param name="PageNumber"></param>
    /// <param name="PageSize"></param>
    private void BindGrid(int PageNumber, int PageSize)
    {
        // check for session containing all search values if it is null or not
        // if null then  redirect to search page
        if (Session["dtLetterSearch"] != null)
        {
            //get the data table from session
            DataTable dtSearch = (DataTable)Session["dtLetterSearch"];

            // get the row from data table
            DataRow dr = dtSearch.Rows[0];

            //get the values from each column of row
            string strInsuredName = dr["strInsuredName"].ToString();
            string strIssueDateFrom = dr["dtIssueDateFrom"].ToString();
            string strIssueDateTo = dr["dtIssueDateTo"].ToString();
            string strDateLetterSentFrom;
            if (dr["dtDateLetterSentFrom"].ToString() == string.Empty)
                strDateLetterSentFrom = ((DateTime)System.Data.SqlTypes.SqlDateTime.MinValue).ToString();
            else
                strDateLetterSentFrom = dr["dtDateLetterSentFrom"].ToString();

            string strDateLetterSentTo;
            if (dr["dtDateLetterSentTo"].ToString() == string.Empty)
                strDateLetterSentTo = ((DateTime)System.Data.SqlTypes.SqlDateTime.MinValue).ToString();
            else
                strDateLetterSentTo = dr["dtDateLetterSentTo"].ToString();

           
            // selects records depending on paging criteria and search values.
            DataSet dsLetterHistory = COI_Letter_History.SearchByPaging(strInsuredName, strIssueDateFrom, strIssueDateTo,
                                      strDateLetterSentFrom, strDateLetterSentTo, PageNumber, PageSize, SortBy, SortOrder,
                                      drpSignature.SelectedIndex > 0 ? Convert.ToInt32(drpSignature.SelectedValue) : 0);
            DataTable dtLetterHistory = dsLetterHistory.Tables[0];

            // set values for paging control,so it shows values as needed.
            ctrlPageLetterHistory.TotalRecords = (dsLetterHistory.Tables.Count >= 2) ? Convert.ToInt32(dsLetterHistory.Tables[1].Rows[0][0]) : 0;    
            if(dsLetterHistory.Tables.Count >2)
            {
                ctrlPageLetterHistory.CurrentPage = (dsLetterHistory.Tables.Count > 1) ? Convert.ToInt32(dsLetterHistory.Tables[2].Rows[0][2]) : 1;
            }
            else
            {
               ctrlPageLetterHistory.CurrentPage = (dsLetterHistory.Tables.Count > 1) ? Convert.ToInt32(dsLetterHistory.Tables[1].Rows[0][2]) : 1;
            }
            ctrlPageLetterHistory.RecordsToBeDisplayed = dtLetterHistory.Rows.Count;
            ctrlPageLetterHistory.SetPageNumbers();
            // bind the grid.
            gvLetterHistory.DataSource = dtLetterHistory;
            gvLetterHistory.DataBind();

            // set record numbers retrieved           
            lblNumber.Text = ctrlPageLetterHistory.TotalRecords.ToString();
            ctrlPageLetterHistory.FindControl("drpRecords").Focus();
        }
        else
        {
            //redirect to Search page
            Response.Redirect("LetterHistorySearch.aspx");
        }
    }

    /// <summary>
    /// Implement event for Paging control when clicking on Go button
    /// </summary>
    protected void GetPage()
    {
        BindGrid(ctrlPageLetterHistory.CurrentPage, ctrlPageLetterHistory.PageSize);
    }
    /// <summary>
    /// Bind Signature DropDown Data
    /// </summary>
    /// <param name="strPKCois"></param>
    private void BindSignatureDropdown(string strPKCois)
    {
        DataTable dtSign = COI_Signature.SelectByPKCOIs(strPKCois).Tables[0];
        drpSignature.DataSource = dtSign;
        drpSignature.DataTextField = "Fld_Desc";
        drpSignature.DataValueField = "PK_COI_Signature";
        drpSignature.DataBind();
        drpSignature.Items.Insert(0, "--Select--");
    }

    # region " Control Events "
    /// <summary>
    /// Signature Select index change event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void drpSignature_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindGrid(1, ctrlPageLetterHistory.PageSize);
        ctrlPageLetterHistory.SetPageNumbers();
    }
    /// <summary>
    /// Generate Report Button Click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkGenerateReports_Click(object sender, EventArgs e)
    {
        decimal PK_History;
        COI_Letter_History objHistory;
        litLetter.Text = "";
        litEnvelopes.Text = "";
        for (int i = 0; i < gvLetterHistory.Rows.Count; i++)
        {
            CheckBox chkSelect = (CheckBox)gvLetterHistory.Rows[i].FindControl("chkSelect");
            if (chkSelect.Checked)
            {
                PK_History = (decimal)gvLetterHistory.DataKeys[i]["PK_COI_Letter_History"];
                decimal PK_COIs = (decimal)gvLetterHistory.DataKeys[i]["FK_COIs"];
                objHistory = new COI_Letter_History(PK_History);

                if (new COIs(PK_COIs).FK_COI_Signature.ToString() == drpSignature.SelectedValue)
                {
                    if (litLetter.Text.Length > 0)
                    {
                        litLetter.Text = string.Concat(litLetter.Text, strPrintPageBreak, objHistory.Letter);
                    }
                    else
                    {
                        litLetter.Text = string.Concat(litLetter.Text, objHistory.Letter);
                    }

                    if (litEnvelopes.Text.Length > 0)
                    {
                        litEnvelopes.Text = string.Concat(litEnvelopes.Text, strPrintPageBreak, objHistory.Envelopes);
                    }
                    else
                    {
                        litEnvelopes.Text = string.Concat(litEnvelopes.Text, objHistory.Envelopes);
                    }
                }
            }
        }
        if (litLetter.Text.Length > 0)
        {
            //Page.ClientScript.RegisterStartupScript(Page.GetType(), "PrintLetterDoc", "javascript:PrintLetter();", true);            
            lblMessage.Text = " You can Re Print Letters and/or Envelopes using below Links. ";
            lnkPrintEnvelopes.Visible = true;
            lnkPrintLetters.Visible = true;
        }
    }
    /// <summary>
    /// Generates PDF for HTML text
    /// </summary>
    /// <param name="strLetterText">HTML Text</param>
    private void GenerateLetterPDF(string strLetterText, string strType)
    {

        aspPDF.EASYPDF pdf = new aspPDF.EASYPDF();
        pdf.Create();

        // set page orientation either 0 for portrait or 1 for landscap 
        if (strType == "Letter")
        {
            pdf.Page("Letter", 0);
            pdf.SetMargins(30, 30, 10, 0);
        }
        else
        {
            pdf.Page("Letter", 1);
            pdf.SetMargins(70, 30, 10, 0);
        }

        pdf.AddHTML(strLetterText);
        Response.Clear();
        Response.ContentType = "application/pdf";
        Response.AddHeader("content-disposition", "attachment; filename=CertificateOfInsurance.PDF");
        Response.BinaryWrite((byte[])pdf.SaveVariant());
        Response.Flush();
        Response.Close();
        Response.End();
    }
    #endregion

    #region "Other Controls Events"
    /// <summary>
    /// Handle Back Button Click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("LetterHistorySearch.aspx");
    }
    /// <summary>
    /// Handle Print Letters Button Click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkPrintLetters_Click(object sender, EventArgs e)
    {
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
        builder.Font.Size = 12;
        builder.Font.Bold = false;
        builder.Font.Color = System.Drawing.Color.Black;
        builder.Font.Name = "Times New Roman";
        builder.InsertParagraph();
        builder.InsertHtml(litLetter.Text);
        //builder.Write(litLetter.Text);
        //doc.MailMerge.Execute(dt);
        //Don't need merge fields in the document anymore.
        Aspose.Words.Tables.Table table = (Aspose.Words.Tables.Table)doc.GetChild(NodeType.Table, 0, true);
        table.AllowAutoFit = false;
        doc.MailMerge.DeleteFields();

        //doc.Save("CertificateOfInsurance.doc", Aspose.Words.SaveFormat.Doc, Aspose.Words.SaveType.OpenInWord, Response);
        doc.Save(Response, "CertificateOfInsurance", ContentDisposition.Attachment, Aspose.Words.Saving.SaveOptions.CreateSaveOptions(SaveFormat.Doc));
        Response.End();
        ///////////
    }
    /// <summary>
    /// Handle Print Envelopes Button click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkPrintEnvelopes_Click(object sender, EventArgs e)
    {
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

        builder.PageSetup.TopMargin = 60.0;
        builder.PageSetup.BottomMargin = 50.0;
        builder.PageSetup.PaperSize = PaperSize.EnvelopeDL;
        builder.Font.Size = 12;
        builder.Font.Bold = false;
        builder.Font.Color = System.Drawing.Color.Black;
        builder.Font.Name = "Times New Roman";
        builder.PageSetup.Orientation = Aspose.Words.Orientation.Landscape;
        builder.InsertParagraph();
        builder.InsertHtml(litEnvelopes.Text);
        //builder.Write(litLetter.Text);
        //doc.MailMerge.Execute(dt);
        //Don't need merge fields in the document anymore.
        
        Aspose.Words.Tables.Table table = (Aspose.Words.Tables.Table)doc.GetChild(NodeType.Table, 0, true);
        table.AllowAutoFit = false;

        doc.MailMerge.DeleteFields();
        //doc.Save("CertificateOfInsurance.doc", Aspose.Words.SaveFormat.Doc, Aspose.Words.SaveType.OpenInWord, Response);
        doc.Save(Response, "CertificateOfInsurance.doc", ContentDisposition.Attachment, Aspose.Words.Saving.SaveOptions.CreateSaveOptions(SaveFormat.Doc));
        Response.End();
     
    }
    /// <summary>
    /// Handle Letter History Gridview Row command Event in View and Delete Mode
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvLetterHistory_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        // get the current COI id.
        if (e.CommandName == "ViewLetters")
        {
            // show COI record in view mode
            int Letter_ID = Convert.ToInt32(e.CommandArgument);
            Response.Redirect("LetterHistory.aspx?id=" + Encryption.Encrypt(Letter_ID.ToString()));
        }
        if (e.CommandName == "DeleteLetters")
        {
            try
            {
                int Letter_ID = Convert.ToInt32(e.CommandArgument);
                COI_Letter_History.Delete(Letter_ID);

                BindGrid(ctrlPageLetterHistory.CurrentPage, ctrlPageLetterHistory.PageSize);
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Delete", "alert('Letter deleted successfully');", true);
            }
            catch (Exception ex)
            {

            }
        }
    }
    #endregion


    #region Sorting
    /// <summary>
    /// Handle COI Grid in Sorting event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvCOI_Sorting(object sender, GridViewSortEventArgs e)
    {
        SortOrder = (SortBy == e.SortExpression) ? (SortOrder == "asc" ? "desc" : "asc") : "asc";
        SortBy = e.SortExpression;
        BindGrid(ctrlPageLetterHistory.CurrentPage, ctrlPageLetterHistory.PageSize);
    }
    /// <summary>
    /// Handle Row Create Event in Grid View
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvCOI_RowCreated(object sender, GridViewRowEventArgs e)
    {
        // check for the header row
        if (e.Row.RowType == DataControlRowType.Header)
        {
            // if sort field already available
            if (String.Empty != SortBy)
            {
                // update sort image beside the column header 
                AddSortImage(e.Row);
            }
            else
            {
                // add sort image beside the column header 
                Image sortImage = new Image();
                sortImage.ImageUrl = "~/Images/up-arrow.gif";
                sortImage.AlternateText = "Descending Order";
                e.Row.Cells[0].Controls.Add(sortImage);
            }
        }
    }
    /// <summary>
    /// Letter History Row Data Bound Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvLetterHistory_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (App_Access == AccessType.NotAssigned || App_Access == AccessType.View_Only)
                ((Button)e.Row.FindControl("lnkDelete")).Visible = false;
        }
    }

    private void AddSortImage(GridViewRow headerRow)
    {

        Int32 iCol = GetSortColumnIndex(SortBy);
        if (iCol == -1)
        {
            return;
        }
        // Create the sorting image based on the sort direction.
        Image sortImage = new Image();
        string strSortOrder = SortOrder == "asc" ? SortDirection.Ascending.ToString() : SortDirection.Descending.ToString();

        // check for the order and
        // set the images accordingly 
        if (SortDirection.Ascending.ToString() == strSortOrder)
        {
            sortImage.ImageUrl = "~/Images/up-arrow.gif";
            sortImage.AlternateText = "Descending Order";
        }
        else
        {
            sortImage.ImageUrl = "~/Images/down-arrow.gif";
            sortImage.AlternateText = "Ascending Order";
        }

        // Add the image to the appropriate header cell.
        headerRow.Cells[iCol].Controls.Add(sortImage);
    }


    private int GetSortColumnIndex(object strSortExp)
    {
        int nRet = 0;

        // Iterate through the Columns collection to determine the index
        // of the column being sorted.
        foreach (DataControlField field in gvLetterHistory.Columns)
        {

            if (field.SortExpression.ToString() == strSortExp.ToString())
            {

                nRet = gvLetterHistory.Columns.IndexOf(field);

            }
        }
        return nRet;
    }
    #endregion
}

