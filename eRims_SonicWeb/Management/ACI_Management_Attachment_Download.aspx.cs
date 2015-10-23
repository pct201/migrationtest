using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Text;
using System.IO;
using ERIMS.DAL;

public partial class ACI_Management_Attachment_Download : clsBasePage
{
    #region Properties

    /// <summary>
    /// Denotes Sort Field to sort all records by
    /// </summary>
    private string _SortBy
    {
        get { return (!clsGeneral.IsNull(ViewState["SortBy"]) ? ViewState["SortBy"].ToString() : string.Empty); }
        set { ViewState["SortBy"] = value; }
    }

    /// <summary>
    /// Denotes ascending or descending order
    /// </summary>
    private string _SortOrder
    {
        get { return (!clsGeneral.IsNull(ViewState["SortOrder"]) ? ViewState["SortOrder"].ToString() : string.Empty); }
        set { ViewState["SortOrder"] = value; }
    }

    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            ctrlPageProperty.PageSize = clsSession.NumberOfSearchRows;
            _SortBy = "dba";
            _SortOrder = "asc";
        }
    }

    #region "Controls Events"

    /// <summary>
    /// Handles Download Attachment button click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnDownload_Click(object sender, EventArgs e)
    {
        //grid of attachment detail
        trCriteria.Visible = false;
        tblReport.Visible = true;
        btnBack.Visible = true;
        BindGridFiles(ctrlPageProperty.CurrentPage, ctrlPageProperty.PageSize);
    }

    /// <summary>
    /// Handles Clear Criteria button click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnClearCriteria_Click(object sender, EventArgs e)
    {
        txtFrom_Date_Of_Invoice.Text = "";
        txtTo_Date_Of_Invoice.Text = "";
    }

    /// <summary>
    /// Back from report to Criteria
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnBack_Click(object sender, EventArgs e)
    {
        trCriteria.Visible = true;
        tblReport.Visible = false;
        lblHeading.Text = "Management Attachment Download";
        txtFrom_Date_Of_Invoice.Text = txtTo_Date_Of_Invoice.Text = string.Empty;
        hdnAttachmentRowNumber.Value = "";
        ctrlPageProperty.CurrentPage = 1;
    }

    /// <summary>
    /// Handles Download Attachment button click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnDownloadAttachment_Click(object sender, EventArgs e)
    {
        //here get selected letter's name/id and from that make zip and download check also file size
         string strRowNumbers = string.Empty;

        if (!string.IsNullOrEmpty(hdnAttachmentRowNumber.Value))
        {
            strRowNumbers = hdnAttachmentRowNumber.Value.Trim().Trim('-');
            strRowNumbers = strRowNumbers.Replace("--", ",");
        }

        string strAttachments_Name = clsAttachment_Event.GetAttachmentsName(strRowNumbers);//get attachments name from id
        if (!string.IsNullOrEmpty(strAttachments_Name))
        {
            string[] strRow = strAttachments_Name.Split(':');
            string[] strAttachments = new string[strRow.Length];
            for (int i = 0; i < strRow.Length; i++)
            {
                strAttachments[i] = AppConfig.DocumentsPath + @"Attach\" + strRow[i];
            }
            string strzipDir = AppConfig.DocumentsPath + "\\Attachments";

            
            clsGeneral.SetZipDirectory(strAttachments, strzipDir);

            int TotalfileCount = Directory.GetFiles(strzipDir, "*.*", SearchOption.AllDirectories).Length;
            decimal FileSize = 0;

           

            if (TotalfileCount > 0)
            {
                FileSize = clsGeneral.GetMailAttachmentSize(strAttachments);
            }

            if (FileSize > Convert.ToDecimal(9.9))
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), DateTime.Now.ToString(), "alert('The selected attachments exceeds 9.9 megabytes. Please remove some of the attachment.','false');", true);
            }
            else if (TotalfileCount == 0)
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), DateTime.Now.ToString(), "alert('Selected attachment(s) are not found.','false');", true);
            }
            else if (TotalfileCount == 1)
            {
                string[] filePaths = Directory.GetFiles(AppConfig.DocumentsPath + "\\Attachments");

                System.IO.FileInfo file = new System.IO.FileInfo(filePaths[0]);

                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", file.Name));
                HttpContext.Current.Response.AddHeader("Content-Length", file.Length.ToString());
                HttpContext.Current.Response.ContentType = "application/octet-stream";//ReturnExtension(clsGeneral.GetExtension(objAttachment.Attachment_Name));
                HttpContext.Current.Response.TransmitFile(filePaths[0]);
                HttpContext.Current.Response.Flush();
                HttpContext.Current.Response.End();
            }
            else
            {
                clsGeneral.ConvertZIP(strzipDir);
                System.IO.FileInfo file = new System.IO.FileInfo(strzipDir + ".Zip");
                clsGeneral.DownloadZIP(AppConfig.DocumentsPath + "Attachments");
            }
        }

    }
    #endregion

    #region " Grid Events "

    /// <summary>
    /// Handles event when row header link is clicked for sorting
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvFiles_Sorting(object sender, GridViewSortEventArgs e)
    {
        // update sort field and sort order and bind the grid
        _SortOrder = (_SortBy == e.SortExpression) ? (_SortOrder == "asc" ? "desc" : "asc") : "asc";
        _SortBy = e.SortExpression;
        GetPage();
    }

    /// <summary>
    /// Handles event when row is created for Incident grid
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvFiles_RowCreated(object sender, GridViewRowEventArgs e)
    {
        // check for the header row
        if (e.Row.RowType == DataControlRowType.Header)
        {
            // if sort field already available
            if (String.Empty != _SortBy)
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
                e.Row.Cells[1].Controls.Add(sortImage);
            }
        }
    } 
    #endregion

    #region Methods

    /// <summary>
    /// Adds the sorting image beside the column in the grid on which 
    /// sorting has been performed
    /// </summary>
    /// <param name="headerRow">Header Row of the grid</param>
    private void AddSortImage(GridViewRow headerRow)
    {
        Int32 iCol = GetSortColumnIndex(_SortBy);
        if (iCol == -1)
        {
            return;
        }
        // Create the sorting image based on the sort direction.
        Image sortImage = new Image();
        string strSortOrder = _SortOrder == "asc" ? SortDirection.Ascending.ToString() : SortDirection.Descending.ToString();

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

    /// <summary>
    /// Returns the index of the column which contains particular sort expression
    /// </summary>
    /// <param name="strSortExp">The column on which the sorting is to be performed</param>
    /// <returns>Integer</returns>
    private int GetSortColumnIndex(string strSortExp)
    {
        int nRet = 1;
        // Iterate through the Columns collection to determine the index
        // of the column being sorted.
        foreach (DataControlField field in gvFiles.Columns)
        {
            if (field.SortExpression.ToString() == strSortExp)
            {
                nRet = gvFiles.Columns.IndexOf(field);
            }
        }
        return nRet;
    }

    /// <summary>
    /// Binds the grid for file list
    /// </summary>
    private void BindGridFiles(int PageNumber, int PageSize)
    {
        DateTime? dtFromDate = null;
        DateTime? dtToDate = null;


        if (txtFrom_Date_Of_Invoice.Text != "")
            dtFromDate = Convert.ToDateTime(txtFrom_Date_Of_Invoice.Text);

        if (txtTo_Date_Of_Invoice.Text != "")
            dtToDate = Convert.ToDateTime(txtTo_Date_Of_Invoice.Text);

        DataSet dsAttachment = clsAttachment_Event.Get_Management_Attachments(dtFromDate, dtToDate,_SortBy, _SortOrder, PageNumber, PageSize);

        // set values for paging control,so it shows values as needed.
        ctrlPageProperty.TotalRecords = (dsAttachment.Tables.Count >= 2) ? Convert.ToInt32(dsAttachment.Tables[1].Rows[0][0]) : 0;
        ctrlPageProperty.CurrentPage = (dsAttachment.Tables.Count >= 2) ? Convert.ToInt32(dsAttachment.Tables[1].Rows[0][2]) : 0;
        ctrlPageProperty.RecordsToBeDisplayed = dsAttachment.Tables[0].Rows.Count;
        ctrlPageProperty.SetPageNumbers();

        gvFiles.DataSource = dsAttachment.Tables[0];
        gvFiles.DataBind();

        lblNumber.Text = (dsAttachment.Tables.Count >= 2) ? Convert.ToString(dsAttachment.Tables[1].Rows[0][0]) : "0";
        btnDownloadAttachment.Visible = (dsAttachment.Tables[0].Rows.Count == 0) ? false: true;
    }


    /// <summary>
    /// Implement event for Paging control when clicking on Go button
    /// </summary>
    protected void GetPage()
    {
        BindGridFiles(ctrlPageProperty.CurrentPage, ctrlPageProperty.PageSize);
    }
    #endregion
}