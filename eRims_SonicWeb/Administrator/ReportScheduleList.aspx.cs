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
using ERIMS.DAL;

public partial class Administrator_ReportScheduleList : clsBasePage
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

    #region Events

    protected void Page_Load(object sender, EventArgs e)
    {
        //if (UserAccessType != AccessType.Full_Access)
        //    Response.Redirect("../Search/NoRights.aspx", false);

        if (!IsPostBack)
        {
            SortOrder = "asc";
            SortBy = "PK_Schedule";
            BindGrid(1, 10);
        }
    }
    protected void gvReportScheduleList_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            //decimal PK_Schedule = Convert.ToDecimal(gvReportScheduleList.DataKeyNames[e.RowIndex].Value);
            Tatva_ReportSchedule.DeleteByPK(Convert.ToDecimal(gvReportScheduleList.DataKeys[e.RowIndex].Value));
            GetPage();
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }

    #endregion

    #region Methods

    private void BindGrid(int PageNumber, int PageSize)
    {
        // selects records depending on paging criteria.
        DataSet dsReportSchedule = Tatva_ReportSchedule.SelectAllDetails(PageNumber, SortBy, SortOrder, PageSize);
        DataTable dtReportSchedule = dsReportSchedule.Tables[0];

        // set values for paging control
        ctrlPageSecurity.TotalRecords = (dsReportSchedule.Tables.Count > 1) ? Convert.ToInt32(dsReportSchedule.Tables[1].Rows[0][0]) : 0;
        ctrlPageSecurity.CurrentPage = (dsReportSchedule.Tables.Count > 2) ? Convert.ToInt32(dsReportSchedule.Tables[2].Rows[0][2]) : 0;
        ctrlPageSecurity.RecordsToBeDisplayed = dtReportSchedule.Rows.Count;
        ctrlPageSecurity.SetPageNumbers();
        // bind the grid.
        gvReportScheduleList.DataSource = dtReportSchedule;
        gvReportScheduleList.DataBind();

        // set record numbers retrieved
        lblNumber.Text = ctrlPageSecurity.TotalRecords.ToString();
    }
    protected void GetPage()
    {
        BindGrid(ctrlPageSecurity.CurrentPage, ctrlPageSecurity.PageSize);
    }

    #endregion

    #region "Sorting"

    protected void gvReportScheduleList_Sorting(object sender, GridViewSortEventArgs e)
    {
        SortOrder = (SortBy == e.SortExpression) ? (SortOrder == "asc" ? "desc" : "asc") : "asc";
        SortBy = e.SortExpression;
        BindGrid(ctrlPageSecurity.CurrentPage, ctrlPageSecurity.PageSize);
    }
    protected void gvReportScheduleList_RowCreated(object sender, GridViewRowEventArgs e)
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
    private void AddSortImage(GridViewRow headerRow)
    {

        Int32 intCol = GetSortColumnIndex(SortBy);
        if (intCol == -1)
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
        headerRow.Cells[intCol].Controls.Add(sortImage);
    }
    private int GetSortColumnIndex(object strSortExp)
    {
        int intRet = 0;
        // Iterate through the Columns collection to determine the index
        // of the column being sorted.
        foreach (DataControlField field in gvReportScheduleList.Columns)
        {

            if (field.SortExpression.ToString() == strSortExp.ToString())
            {
                intRet = gvReportScheduleList.Columns.IndexOf(field);
            }
        }
        return intRet;
    }

    #endregion
}
