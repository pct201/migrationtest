using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERIMS.DAL;
using System.IO;
using System.Data;
using BAL;

public partial class SONIC_Sedgwick_ClaimReviewWorkSheetGroupSearchGrid : System.Web.UI.Page
{

    #region Properties
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

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // set the default sort field and sort order
            SortBy = "PK_Sedgwick_Claim_Group";
            SortOrder = "ASC";

            // Bind Grid
            BindGrid(1, 10);
        }
    }

    /// <summary>
    /// GridView Row Created Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvClaimReviewGroupSearchGrid_RowCreated(object sender, GridViewRowEventArgs e)
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

    /// <summary>
    /// GridView Sorting Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvClaimReviewGroupSearchGrid_Sorting(object sender, GridViewSortEventArgs e)
    {
        // update sort field and sort order and bind the grid
        SortOrder = (SortBy == e.SortExpression) ? (SortOrder == "asc" ? "desc" : "asc") : "asc";
        SortBy = e.SortExpression;
        BindGrid(ctrlPageClaimInfo.CurrentPage, ctrlPageClaimInfo.PageSize);
    }

    #region Methods

    /// <summary>
    /// Binds the grid by page number and page size
    /// </summary>
    /// <param name="PageNumber">Current page number</param>
    /// <param name="PageSize">Number of records to be displayed on a page</param>
    private void BindGrid(int PageNumber, int PageSize)
    {
        // check for session containing all search values if it is null or not
        // if null then  redirect to search page
        if (Session["dtClaimReviewGroupSearch"] != null)
        {
            //get the data table from session
            DataTable dtSearch = (DataTable)Session["dtClaimReviewGroupSearch"];
            //check datatable have atleast one row
            if (dtSearch.Rows.Count > 0)
            {
                DataRow drSearch = dtSearch.Rows[0];

                //get the values from each column of row
                decimal FK_LU_Sedgwick_Field_Office = Convert.ToDecimal(drSearch["FK_LU_Sedgwick_Field_Office"]);
                Int32 Year = Convert.ToInt32(drSearch["Year"]);
                Int32 Quarter = Convert.ToInt32(drSearch["Quarter"]);

                // selects records depending on paging criteria and search values.
                DataSet dsClaimInfo = Sedgwick_Claim_Group.Search(FK_LU_Sedgwick_Field_Office, Year, Quarter, SortBy, SortOrder, PageNumber, PageSize); 

                DataTable dtFRData = dsClaimInfo.Tables[0];

                //// set values for paging control,so it shows values as needed.
                ctrlPageClaimInfo.TotalRecords = (dsClaimInfo.Tables.Count >= 3) ? Convert.ToInt32(dsClaimInfo.Tables[1].Rows[0][0]) : 0;
                ctrlPageClaimInfo.CurrentPage = (dsClaimInfo.Tables.Count >= 3) ? Convert.ToInt32(dsClaimInfo.Tables[2].Rows[0][2]) : 0;
                ctrlPageClaimInfo.RecordsToBeDisplayed = dtFRData.Rows.Count;
                ctrlPageClaimInfo.SetPageNumbers();

                // bind the grid.

                if (Session["dtClaimReviewGroupSearch"] != null)
                {
                    //get the data table from session
                    DataTable dtClaimReviewGroupSearch = (DataTable)Session["dtClaimReviewGroupSearch"];
                    //check datatable have atleast one row
                    if (dtClaimReviewGroupSearch.Rows.Count > 0)
                    {
                        DataRow drClaimReviewGroupSearch = dtClaimReviewGroupSearch.Rows[0];

                        //get the values from each column of row
                        decimal FK_LU_Sedgwick_Field_Office1 = Convert.ToDecimal(drClaimReviewGroupSearch["FK_LU_Sedgwick_Field_Office"]);
                        LU_Sedgwick_Field_Office objLSFO = new LU_Sedgwick_Field_Office(FK_LU_Sedgwick_Field_Office1);

                        lblYear.Text = drClaimReviewGroupSearch["Year"].ToString();
                        lblQuarter.Text = drClaimReviewGroupSearch["Quarter"].ToString();
                        lblSedgwickOffice.Text = objLSFO.Fld_Desc.ToString();
                    }
                }

                //gvClaimReviewGroupSearchGrid.DataSource = dtFRData;
                //gvClaimReviewGroupSearchGrid.DataBind();

                // set record numbers retrieved
                lblNumber.Text = (dsClaimInfo.Tables.Count >= 3) ? Convert.ToString(dsClaimInfo.Tables[1].Rows[0][0]) : "0"; //dsClaimInfo.Tables[0].Rows.Count.ToString(); 
            }
        }
        else
            Response.Redirect("ClaimReviewWorkSheetGroupSearch.aspx");

    }

    /// <summary>
    /// Implement event for Paging control when clicking on Go button
    /// </summary>
    protected void GetPage()
    {
        BindGrid(ctrlPageClaimInfo.CurrentPage, ctrlPageClaimInfo.PageSize);
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
        //foreach (DataControlField field in gvClaimReviewGroupSearchGrid.Columns)
        //{
        //    //check Sort Expression value
        //    if (field.SortExpression.ToString() == strSortExp)
        //    {
        //        nRet = gvClaimReviewGroupSearchGrid.Columns.IndexOf(field);
        //    }
        //}
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

    /// <summary>
    /// Search Button Click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        //Redirect to the Claim Information Search page
        Response.Redirect("ClaimReviewWorkSheetGroupSearch.aspx", true);
                            
    }
    
    #endregion
}