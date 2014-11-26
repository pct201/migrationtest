using System;
using System.Net;
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
using System.IO;

/// <summary>
/// Date : 14 NOV 2008
/// 
/// By : Amit Makwana
/// 
/// Purpose: 
/// To list the claim information records searched as per searsh criteria stored in session
/// 
/// Functionality:
/// Gets the search values from session and performs searching, listing, sorting
/// Also redirects to the related page to view the claim information
/// </summary>
public partial class SONIC_ClaimInformationSearchGrid : System.Web.UI.Page
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
    /// <summary>
    /// Page Load Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
     
        //check Page is Postback or not
        if (!IsPostBack)
        {
            // set the default sort field and sort order
            SortBy = "Origin_Claim_Number";
            SortOrder = "Desc";

            // Bind Grid
            BindGrid(1, 10);
        }
    }
    /// <summary>
    /// Search Button Click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        //Redirect to the Claim Information Search page
        Response.Redirect("ClaimInformationSearch.aspx", true);
    }
    /// <summary>
    /// GridView Row Created Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvClaimInfoSearchGrid_RowCreated(object sender, GridViewRowEventArgs e)
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
        //check for Data row
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //Find view button and set command argument to find redirect page from Datakey Collection of gridview.
            LinkButton btnView = (LinkButton)e.Row.FindControl("lnkView");
            btnView.CommandArgument = Convert.ToString(e.Row.RowIndex);
        }
    }
   /// <summary>
   /// GridView Row Data Bound Event
   /// </summary>
   /// <param name="sender"></param>
   /// <param name="e"></param>
    protected void gvClaimInfoSearchGrid_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //check Rowtype
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblDate_of_Accident = (Label)e.Row.FindControl("lblDate_of_Accident");
            //check Date_Of_Incident value from datset. if it is not null than display it in proper format.
            if (DataBinder.Eval(e.Row.DataItem, "Date_of_Accident") != DBNull.Value)
                lblDate_of_Accident.Text = clsGeneral.FormatDateToDisplay(Convert.ToDateTime(DataBinder.Eval(e.Row.DataItem, "Date_of_Accident")));
        }
    }
    /// <summary>
    /// GridView Sorting Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvClaimInfoSearchGrid_Sorting(object sender, GridViewSortEventArgs e)
    {
        // update sort field and sort order and bind the grid
        SortOrder = (SortBy == e.SortExpression) ? (SortOrder == "asc" ? "desc" : "asc") : "asc";
        SortBy = e.SortExpression;
        BindGrid(ctrlPageClaimInfo.CurrentPage, ctrlPageClaimInfo.PageSize);
    }
    /// <summary>
    /// GridView Row Command Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvClaimInfoSearchGrid_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        //check Command Name
        if (e.CommandName == "View")
        {
            int Index = Convert.ToInt32(e.CommandArgument);
            int PK_ID = (gvClaimInfoSearchGrid.DataKeys[Index].Values["PK_ID"] != null) ? Convert.ToInt32(gvClaimInfoSearchGrid.DataKeys[Index].Values["PK_ID"]) : 0;
            string Claim_Type = (gvClaimInfoSearchGrid.DataKeys[Index].Values["Claim_Type"] != null) ? gvClaimInfoSearchGrid.DataKeys[Index].Values["Claim_Type"].ToString() : "";
            string url = (gvClaimInfoSearchGrid.DataKeys[Index].Values["Url"] != null) ? gvClaimInfoSearchGrid.DataKeys[Index].Values["Url"].ToString() : "";

            // show First Reports in view mode
            //check if Url is blank than it redirect to search page
            if (Claim_Type != string.Empty)
            {
                //used to set Tab 
                SetTab(Claim_Type);

                Response.Redirect(url + "?id=" + Encryption.Encrypt(PK_ID.ToString()));
            }
            else
                Response.Redirect("ClaimInformationSearch.aspx");
        }
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
        if (Session["dtClaimInfoSearch"] != null)
        {
            //get the data table from session
            DataTable dtSearch = (DataTable)Session["dtClaimInfoSearch"];
            //check datatable have atleast one row
            if (dtSearch.Rows.Count > 0)
            {
                DataRow drSearch = dtSearch.Rows[0];
                Nullable<DateTime> DateOfAccident;
                //get the values from each column of row
                decimal LocationNumber = Convert.ToDecimal(drSearch["LocationNumber"]);
                String EmployeeName = Convert.ToString(drSearch["EmployeeName"]);
                if (Convert.ToDateTime(drSearch["DateOfAccident"]) != (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue)
                    DateOfAccident = clsGeneral.FormatDateToStore(drSearch["DateOfAccident"]);
                else
                    DateOfAccident = null;
                Int32 AssociatedFirstReport = Convert.ToInt32(drSearch["AssociatedFirstReport"]);
                String TPAClaimNumber = Convert.ToString(drSearch["TPAClaimNumber"]);
                string ClaimType = Convert.ToString(drSearch["ClaimType"]);
                string ClaimStatus = Convert.ToString(drSearch["ClaimStatus"]);
                //Code Added By Ravi Gupta 19-12-2008
                string Regional = string.Empty;
                Nullable<decimal> CurrentEmployee = new Security(Convert.ToDecimal(clsSession.UserID)).Employee_Id;
                DataSet dsRegion = Regional_Access.SelectBySecurityID(Convert.ToInt32(clsSession.UserID));
                if (dsRegion.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow drRegion in dsRegion.Tables[0].Rows)
                    {
                        Regional += drRegion["Region"].ToString() + ",";
                    }                   
                }
                else
                    Regional = string.Empty;

                if (CurrentEmployee.ToString() != string.Empty && CurrentEmployee.ToString() != "0")
                    CurrentEmployee = Convert.ToDecimal(CurrentEmployee);
                else
                    CurrentEmployee = 0;
                //Code End Here.. Ravi Gupta
                // selects records depending on paging criteria and search values.
                DataSet dsClaimInfo = Claim_Information.GetSearchResults(LocationNumber, DateOfAccident, AssociatedFirstReport, EmployeeName, TPAClaimNumber, ClaimType, SortBy, SortOrder, PageNumber, PageSize, Regional.ToString().TrimEnd(Convert.ToChar(",")), CurrentEmployee, ClaimStatus,drSearch["ClaimantName"].ToString());
                DataTable dtFRData = dsClaimInfo.Tables[0];

                //// set values for paging control,so it shows values as needed.
                ctrlPageClaimInfo.TotalRecords = (dsClaimInfo.Tables.Count >= 3) ? Convert.ToInt32(dsClaimInfo.Tables[1].Rows[0][0]) : 0;
                ctrlPageClaimInfo.CurrentPage = (dsClaimInfo.Tables.Count >= 3) ? Convert.ToInt32(dsClaimInfo.Tables[2].Rows[0][2]) : 0;
                ctrlPageClaimInfo.RecordsToBeDisplayed = dtFRData.Rows.Count;
                ctrlPageClaimInfo.SetPageNumbers();

                // bind the grid.
                gvClaimInfoSearchGrid.DataSource = dtFRData;
                gvClaimInfoSearchGrid.DataBind();

                // set record numbers retrieved
                lblNumber.Text = (dsClaimInfo.Tables.Count >= 3) ? Convert.ToString(dsClaimInfo.Tables[1].Rows[0][0]) : "0";
            }
        }
        else
            Response.Redirect("ClaimInformationSearch.aspx");

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
        foreach (DataControlField field in gvClaimInfoSearchGrid.Columns)
        {
            //check Sort Expression value
            if (field.SortExpression.ToString() == strSortExp)
            {
                nRet = gvClaimInfoSearchGrid.Columns.IndexOf(field);
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

    /// <summary>
    /// Used to set Tabing Control values
    /// </summary>
    /// <param name="ClaimType"></param>
    private void SetTab(String ClaimType)
    {
        String AllowTab = "";
        switch (ClaimType.ToUpper())
        {
            case "WC":
                AllowTab = "1";
                break;
            case "AL":
                AllowTab = "2";
                break;
            case "DPD":
                AllowTab = "3";
                break;
            case "PROPERTY":
                AllowTab = "4";
                break;
            case "PL":
                AllowTab = "5";
                break;
        }
        clsSession.AllowedTab = AllowTab;
    }

    #endregion
}
