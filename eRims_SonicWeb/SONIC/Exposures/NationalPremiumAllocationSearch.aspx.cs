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
public partial class SONIC_Exposures_NationalPremiumAllocationSearch : clsBasePage
{
    #region Properties
    /// <summary>
    /// Denotes the Primary Key
    /// </summary>
    public int PK_PA_National_Allocation
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_PA_National_Allocation"]);
        }
        set { ViewState["PK_PA_National_Allocation"] = value; }
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

    #region Page Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            // set the default sort field and sort order
            SortBy = "Year";
            SortOrder = "Desc";


            //Bind Admin Grid
            BindGrid(1, 10);


        }
    }
    #endregion

    #region Event

    #region Grid Event
    protected void gvPAFields_Sorting(object sender, GridViewSortEventArgs e)
    {
        // update sort field and sort order and bind the grid
        SortOrder = (SortBy == e.SortExpression) ? (SortOrder == "asc" ? "desc" : "asc") : "asc";
        SortBy = e.SortExpression;
        BindGrid(ctrlPageProperty.CurrentPage, ctrlPageProperty.PageSize);
    }
    protected void gvPAFields_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "EditItem")
        {
            Response.Redirect("NationalPremiumAllocation.aspx?id=" + Encryption.Encrypt(e.CommandArgument.ToString()) + "&mode=edit");

        }
        else if (e.CommandName == "View")
        {
            Response.Redirect("NationalPremiumAllocation.aspx?id=" + Encryption.Encrypt(e.CommandArgument.ToString()) + "&mode=view");
        }
        else if (e.CommandName == "DeleteItem")
        {
            clsPA_National_Allocation.DeleteByPK(Convert.ToDecimal(e.CommandArgument.ToString()));
            BindGrid(ctrlPageProperty.CurrentPage, ctrlPageProperty.PageSize);
        }
    }

    /// <summary>
    /// Handles event when Grid row is created
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvPAFields_RowCreated(object sender, GridViewRowEventArgs e)
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
                e.Row.Cells[3].Controls.Add(sortImage);
            }
        }
    }
    #endregion

    protected void btnAddNew_Click(object sender, EventArgs e)
    {
        Response.Redirect("NationalPremiumAllocation.aspx");
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        int? strYear = null;
        if (txtYear.Text.Trim() != "")
            strYear = Convert.ToInt32(txtYear.Text.Trim().Replace("'", "''"));

        // System.Threading.Thread.Sleep(1000);
        DataSet dsAdmin = clsPA_National_Allocation.PA_National_AllocationSelectByYear(strYear, SortBy, SortOrder, 1, ctrlPageProperty.PageSize);

        DataTable dtAdminData = dsAdmin.Tables[0];

        // set values for paging control,so it shows values as needed.
        ctrlPageProperty.TotalRecords = (dsAdmin.Tables.Count >= 3) ? Convert.ToInt32(dsAdmin.Tables[1].Rows[0][0]) : 0;
        ctrlPageProperty.CurrentPage = (dsAdmin.Tables.Count >= 3) ? Convert.ToInt32(dsAdmin.Tables[2].Rows[0][2]) : 0;
        ctrlPageProperty.RecordsToBeDisplayed = dtAdminData.Rows.Count;
        ctrlPageProperty.SetPageNumbers();

        // bind the grid.
        gvPAFields.DataSource = dtAdminData;
        gvPAFields.DataBind();
        //  BindGrid(ctrlPageProperty.CurrentPage, ctrlPageProperty.PageSize);
    }


    #endregion

    #region Method
    private void BindGrid(int PageNumber, int PageSize)
    {
        int? strYear = null;
        if (txtYear.Text.Trim() != "")
            strYear = Convert.ToInt32(txtYear.Text.Trim().Replace("'", "''"));

        DataSet dsAdmin = clsPA_National_Allocation.PA_National_AllocationSelectByYear(strYear, SortBy, SortOrder, ctrlPageProperty.CurrentPage, ctrlPageProperty.PageSize);
        DataTable dtAdminData = dsAdmin.Tables[0];

        // set values for paging control,so it shows values as needed.
        ctrlPageProperty.TotalRecords = (dsAdmin.Tables.Count >= 3) ? Convert.ToInt32(dsAdmin.Tables[1].Rows[0][0]) : 0;
        ctrlPageProperty.CurrentPage = (dsAdmin.Tables.Count >= 3) ? Convert.ToInt32(dsAdmin.Tables[2].Rows[0][2]) : 0;
        ctrlPageProperty.RecordsToBeDisplayed = dtAdminData.Rows.Count;
        ctrlPageProperty.SetPageNumbers();

        // bind the grid.
        gvPAFields.DataSource = dtAdminData;
        gvPAFields.DataBind();
    }

    /// <summary>
    /// Implement event for Paging control when clicking on Go button
    /// </summary>
    protected void GetPage()
    {
        BindGrid(ctrlPageProperty.CurrentPage, ctrlPageProperty.PageSize);
    }

    /// <summary>
    /// Returns the index of the column which contains perticular sort expression
    /// </summary>
    /// <param name="strSortExp">The column on which the sorting is to be performed</param>
    /// <returns>Integer</returns>
    private int GetSortColumnIndex(string strSortExp)
    {
        int nRet = 0;
        // Iterate through the Columns collection to determine the index
        // of the column being sorted.
        foreach (DataControlField field in gvPAFields.Columns)
        {
            //check Sort Expression value
            if (field.SortExpression.ToString() == strSortExp)
            {
                nRet = gvPAFields.Columns.IndexOf(field);
            }
        }
        return nRet;
    }
    /// <summary>
    /// Adds the sorting image beside the column in the grid on which 
    /// sorting has been performed
    /// </summary>
    /// <param name="headerRow">Header Row of the grid</param>
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

    #endregion
}