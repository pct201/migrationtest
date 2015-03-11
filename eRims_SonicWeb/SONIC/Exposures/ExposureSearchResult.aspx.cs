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
/// <summary>
/// Date : 8 OCT 2008
/// 
/// By : Hetal Prajapati
/// 
/// Purpose: 
/// To list the exposure records searched
/// 
/// Functionality:
/// Gets the search values from session and performs searching, listing, sorting
/// Also redirects to the related page to Add new record or view 
/// </summary>
public partial class SONIC_Exposures_ExposureSearchResult : clsBasePage
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

    public AccessType FranchiseAccess
    {
        get { return (AccessType)Enum.Parse(typeof(AccessType), Convert.ToString(ViewState["FranchiseAccess"])); }
        set { ViewState["FranchiseAccess"] = value; }
    }

    #endregion

    #region "Control Events"

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //get User Access for Franchise module
            FranchiseAccess = AccessType.NotAssigned;
            DataSet dsRight = new DataSet();
            dsRight = Security.SelectRightsByUserID(Convert.ToDecimal(clsSession.UserID));
            DataRow[] drView = dsRight.Tables[0].Select("RightType_ID=2 and ModuleName='Franchise'");
            if (drView != null && drView.Length > 0)
            {
                FranchiseAccess = AccessType.Franchise_View;
            }

            DataRow[] drAdmin = dsRight.Tables[0].Select("RightType_ID=1 and ModuleName='Franchise'");
            if (drAdmin != null && drAdmin.Length > 0)
            {
                FranchiseAccess = AccessType.Franchise_AddEdit;
            }

            // set the default sort field and sort order
            SortBy = "Sonic_Location_Code";
            SortOrder = "asc";
            btnAddLocation.Visible = App_RealEstateAccess == AccessType.Administrative_Access;
            // Bind Grid
            BindGrid(1, 10);

            if (Session["AL_RowIndex"] != null) Session["AL_RowIndex"] = null;
            if (Session["AP_AL_FROIs_CommandArgs"] != null) Session["AP_AL_FROIs_CommandArgs"] = null;
            if (Session["DPD_RowIndex"] != null) Session["DPD_RowIndex"] = null;
            if (Session["AP_DPD_FROIs_CommandArgs"] != null) Session["AP_DPD_FROIs_CommandArgs"] = null;

        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        Response.Redirect("ExposureSearch.aspx", true);
    }

    #endregion

    #region "Methods"
    /// <summary>
    /// Binds the grid by page number and page size
    /// </summary>
    /// <param name="PageNumber">Current page number</param>
    /// <param name="PageSize">Number of records to be displayed on a page</param>
    private void BindGrid(int PageNumber, int PageSize)
    {
        // check for session containing all search values if it is null or not
        // if null then  redirect to search page
        if (Session["dtExposureSearchTable"] != null)
        {
            //get the data table from session
            DataTable dtSearch = (DataTable)Session["dtExposureSearchTable"];
            //check datatable have atleast one row
            if (dtSearch.Rows.Count > 0)
            {
                DataRow drSearch = dtSearch.Rows[0];
                //get the values from each column of row
                string strLocationIDs = Convert.ToString(drSearch["LocationIDs"]);
                string strFromDate = Convert.ToString(drSearch["FromDate"]);
                string strToDate = Convert.ToString(drSearch["ToDate"]);
                string strMain_Address = Convert.ToString(drSearch["Main_Address"]);
                string strMain_City = Convert.ToString(drSearch["Main_City"]);
                string strMain_State = Convert.ToString(drSearch["Main_State"]);
                string strMain_Zip = Convert.ToString(drSearch["Main_Zip"]);
                string strBuilding_Address = Convert.ToString(drSearch["Building_Address"]);
                string strBuilding_City = Convert.ToString(drSearch["Building_City"]);
                string strBuilding_State = Convert.ToString(drSearch["Building_State"]);
                string strBuilding_Zip = Convert.ToString(drSearch["Building_Zip"]);

                string Regional = string.Empty;
                Nullable<decimal> CurrentEmployee = new Security(Convert.ToDecimal(clsSession.UserID)).Employee_Id;
                DataSet dsRegion = Regional_Access.SelectBySecurityID(Convert.ToInt32(clsSession.UserID));
                if (dsRegion.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow drRegion in dsRegion.Tables[0].Rows)
                    {
                        Regional += Convert.ToString(drRegion["Region"]) + ",";
                    }
                }

                if (Convert.ToString(CurrentEmployee) == null)
                    CurrentEmployee = 0;

                // selects records depending on paging criteria and search values.
                DataSet dsSearchResult = ExposureCommon.GetExposuresSearchResult(strLocationIDs, strFromDate, strToDate, SortBy, SortOrder, PageNumber, PageSize, Regional.TrimEnd(Convert.ToChar(",")), CurrentEmployee
                                         , strMain_Address, strMain_City, strMain_State, strMain_Zip, strBuilding_Address, strBuilding_City, strBuilding_State, strBuilding_Zip);
                DataTable dtSearchResult = dsSearchResult.Tables[0];

                //// set values for paging control,so it shows values as needed.
                ctrlPageExposure.TotalRecords = (dsSearchResult.Tables.Count >= 3) ? Convert.ToInt32(dsSearchResult.Tables[1].Rows[0][0]) : 0;
                ctrlPageExposure.CurrentPage = (dsSearchResult.Tables.Count >= 3) ? Convert.ToInt32(dsSearchResult.Tables[2].Rows[0][2]) : 0;
                ctrlPageExposure.RecordsToBeDisplayed = dtSearchResult.Rows.Count;
                ctrlPageExposure.SetPageNumbers();

                // bind the grid.
                gvExposure.DataSource = dtSearchResult;
                gvExposure.DataBind();

                // set record numbers retrieved
                lblNumber.Text = (dsSearchResult.Tables.Count >= 3) ? Convert.ToString(dsSearchResult.Tables[1].Rows[0][0]) : "0";
            }
        }
        else
            Response.Redirect("ExposureSearch.aspx");
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
        foreach (DataControlField field in gvExposure.Columns)
        {
            //check Sort Expression value
            if (field.SortExpression == strSortExp)
            {
                nRet = gvExposure.Columns.IndexOf(field);
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

    protected void GetPage()
    {
        BindGrid(ctrlPageExposure.CurrentPage, ctrlPageExposure.PageSize);
    }

    #endregion

    #region "GridView Events"

    /// <summary>
    /// Handles event when Grid row is created
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvExposure_RowCreated(object sender, GridViewRowEventArgs e)
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
    /// Handles event for search result grid sorting
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvExposure_Sorting(object sender, GridViewSortEventArgs e)
    {
        // update sort field and sort order and bind the grid
        SortOrder = (SortBy == e.SortExpression) ? (SortOrder == "asc" ? "desc" : "asc") : "asc";
        SortBy = e.SortExpression;
        BindGrid(ctrlPageExposure.CurrentPage, ctrlPageExposure.PageSize);
    }

    /// <summary>
    /// Handles row databound event for grid
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvExposure_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        // if it is datarow
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string strOperation = "";
            // get the hyperlink control for Franchise column
            HtmlAnchor lnkFranchise = (HtmlAnchor)e.Row.FindControl("lnkFranchise");
            if (DataBinder.Eval(e.Row.DataItem, "Active").ToString() == "Y")
            {
                // if franchise records are there
                // display "View" as per the user rights
                if (Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "FranchiseCount")) > 0)
                {
                    if (FranchiseAccess == AccessType.Franchise_AddEdit || FranchiseAccess == AccessType.Franchise_View)
                        lnkFranchise.InnerHtml = "View";
                    strOperation = "view";
                    lnkFranchise.HRef = AppConfig.SiteURL + "SONIC/Franchise/FranchiseGrid.aspx?loc=" + Encryption.Encrypt(DataBinder.Eval(e.Row.DataItem, "PK_LU_Location_ID").ToString()) + "&op=" + strOperation;
                }
                else
                {
                    // display "Add New" as per the user rights
                    if (FranchiseAccess == AccessType.Franchise_AddEdit)
                        lnkFranchise.InnerHtml = "Add New";
                    lnkFranchise.HRef = AppConfig.SiteURL + "SONIC/Franchise/FranchiseAddEdit.aspx?loc=" + Encryption.Encrypt(DataBinder.Eval(e.Row.DataItem, "PK_LU_Location_ID").ToString());
                }
            }
            
        }
    }

    #endregion

}
