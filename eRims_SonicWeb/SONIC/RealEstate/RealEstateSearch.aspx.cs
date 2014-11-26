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
using ERIMS.DAL;

public partial class SONIC_RealEstate_RealEstateSearch : clsBasePage
{
    #region "Properties"
    /// <summary>
    /// Denotes Sort Field to sort all records by
    /// </summary>
    private string _SortBy
    {
        get { return (!clsGeneral.IsNull(ViewState["SortBy"]) ? ViewState["SortBy"].ToString() : "Dealership"); }
        set { ViewState["SortBy"] = value; }
    }

    /// <summary>
    /// Denotes ascending or descending order
    /// </summary>
    private string _SortOrder
    {
        get { return (!clsGeneral.IsNull(ViewState["SortOrder"]) ? ViewState["SortOrder"].ToString() : "asc"); }
        set { ViewState["SortOrder"] = value; }
    }

    #endregion

    #region "Page Event"

    /// <summary>
    /// Handle Page Load Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        //RE_Tab.SetSelectedTab(RealEstate.Tab.Search);       
        if (!IsPostBack)
        {
            RE_Tab.StrRedirectTo = "RealEstateAddEdit.aspx";
            RE_Tab.Visible = false;
            BindDropDownList();

            clsSession.Str_RE_Operation = "";
            clsSession.Current_RE_Information_ID = 0;

            if (App_Access == AccessType.View_Only)
                btnAdd.Visible = false;            
        }
    }

    #endregion

    #region "Events"

    /// <summary>
    /// Handle Search Button click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        RE_Tab.Visible = true;
        dvSearch.Style["display"] = "none";
        dvSearchResult.Style["display"] = "block";
        _SortBy = "Dealership";
        _SortOrder = "asc";

        BindSearchResult(1, ctrlPager.PageSize);

        if (App_Access == AccessType.View_Only)
            btnAdd.Visible = false;
        else
            btnAdd.Visible = true;
    }

    /// <summary>
    /// Handle Back Buton event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnBack_Click(object sender, EventArgs e)
    {
        dvSearch.Style["display"] = "block";
        dvSearchResult.Style["display"] = "none";
        RE_Tab.Visible = false;
        ClearSearchControls();
    }

    /// <summary>
    /// Handle Add New Button Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnAddNew_Click(object sender, EventArgs e)
    {
        clsSession.Str_RE_Operation = "";
        clsSession.Current_RE_Information_ID = 0;
        Response.Redirect("RealEstateAddEdit.aspx", true);
    }

    /// <summary>
    /// Handle Clear Button Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnClear_Click(object sender, EventArgs e)
    {
        ClearSearchControls();
    }

    /// <summary>
    /// Handle Region Drop Down selected index changed
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ddlRegion_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindDealeship(ddlRegion.SelectedValue);
    }

    #endregion

    #region "Grid Event"

    /// <summary>
    /// Handle grid Row Command Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvRealEstate_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "EditItem")
        {
            clsSession.Current_RE_Information_ID = Convert.ToDecimal(e.CommandArgument);
            clsSession.Str_RE_Operation = "edit";
            Response.Redirect("RealEstateAddEdit.aspx", true);
        }
        else if (e.CommandName == "ViewItem")
        {
            clsSession.Current_RE_Information_ID = Convert.ToDecimal(e.CommandArgument);
            clsSession.Str_RE_Operation = "view";
            Response.Redirect("RealEstateAddEdit.aspx", true);
        }
        else if (e.CommandName == "DeleteItem")
        {
            RE_Information.DeleteByPK(Convert.ToDecimal(e.CommandArgument));
            BindSearchResult(ctrlPager.CurrentPage, ctrlPager.PageSize);
        }

    }

    /// <summary>
    /// Handle Grid Sorting Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvRealEstate_Sorting(object sender, GridViewSortEventArgs e)
    {
        // update sort field and sort order and bind the grid
        _SortOrder = (_SortBy == e.SortExpression) ? (_SortOrder == "asc" ? "desc" : "asc") : "asc";
        _SortBy = e.SortExpression;
        //rebind grid
        BindSearchResult(ctrlPager.CurrentPage, ctrlPager.PageSize);
    }

    /// <summary>
    /// Handle Grid Row Created Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvRealEstate_RowCreated(object sender, GridViewRowEventArgs e)
    {
        // check for the header row
        if (e.Row.RowType == DataControlRowType.Header)
        {
            // if sort field already available
            if (String.Empty != _SortBy)
            {
                // update sort image beside the column header 
                AddSortImage(e.Row, gvRealEstate);
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
    /// Handle Grid Row Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvRealEstate_DataRowBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton lnkEdit = (LinkButton)e.Row.FindControl("lnkEdit");
            LinkButton lnkDelete = (LinkButton)e.Row.FindControl("lnkDelete");

            if (App_Access == AccessType.View_Only)
            {
                lnkEdit.Visible = false;
            }
            
        }
    }

    #endregion

    #region "Methods"

    /// <summary>
    /// get page number for paging
    /// </summary>
    protected void GetPage()
    {
        BindSearchResult(ctrlPager.CurrentPage, ctrlPager.PageSize);
    }

    /// <summary>
    /// bind search result
    /// </summary>
    /// <param name="PageNumber"></param>
    /// <param name="PageSize"></param>
    private void BindSearchResult(int PageNumber, int PageSize)
    {
        DataSet dsSearchResult = RE_Information.RealEstateSearch(Convert.ToDecimal(ddlDealership.SelectedValue), ddlRegion.SelectedValue, clsGeneral.FormatNullDateToStore(txtLCDateFrom.Text.Trim()), clsGeneral.FormatNullDateToStore(txtLCDateTo.Text.Trim()), clsGeneral.FormatNullDateToStore(txtLEDateFrom.Text.Trim()),
             clsGeneral.FormatNullDateToStore(txtLEDateTo.Text.Trim()), Convert.ToDecimal(ddlState.SelectedValue), txtLandlord.Text.Trim().Replace("'", "''"), clsGeneral.FormatNullDateToStore(txtDateAcquiredFrom.Text.Trim()), clsGeneral.FormatNullDateToStore(txtDateAcquiredTo.Text.Trim()), Convert.ToDecimal(ddlLeaseType.SelectedValue), Convert.ToDecimal(ddlProjectType.SelectedValue), _SortBy, _SortOrder, PageNumber, PageSize);
        gvRealEstate.DataSource = dsSearchResult.Tables[0];
        gvRealEstate.DataBind();

        ctrlPager.TotalRecords = (dsSearchResult.Tables.Count >= 2) ? Convert.ToInt32(dsSearchResult.Tables[1].Rows[0][0]) : 0;
        ctrlPager.CurrentPage = (dsSearchResult.Tables.Count >= 2) ? Convert.ToInt32(dsSearchResult.Tables[1].Rows[0][2]) : 0;
        ctrlPager.RecordsToBeDisplayed = dsSearchResult.Tables[0].Rows.Count;
        ctrlPager.SetPageNumbers();

        // set record numbers retrieved
        lblNumber.Text = ((dsSearchResult.Tables.Count >= 2) ? Convert.ToString(dsSearchResult.Tables[1].Rows[0][0]) : "0");
    }

    /// <summary>
    /// Clear search controls
    /// </summary>
    private void ClearSearchControls()
    {
        ddlDealership.SelectedIndex = 0;
        ddlLeaseType.SelectedIndex = 0;
        ddlProjectType.SelectedIndex = 0;
        ddlRegion.SelectedIndex = 0;
        ddlState.SelectedIndex = 0;
        txtDateAcquiredFrom.Text = "";
        txtDateAcquiredTo.Text = "";
        txtLandlord.Text = "";
        txtLCDateFrom.Text = "";
        txtLCDateTo.Text = "";
        txtLEDateFrom.Text = "";
        txtLEDateTo.Text = "";
    }

    /// <summary>
    /// Bind Drop Down List
    /// </summary>
    private void BindDropDownList()
    {
        ///Region
        ddlRegion.DataSource = LU_Location.GetRegionList();
        ddlRegion.DataTextField = "region";
        ddlRegion.DataValueField = "region";
        ddlRegion.DataBind();
        ddlRegion.Items.Insert(0, new ListItem("--Select--", ""));
        BindDealeship("");

        ///States
        ddlState.DataSource = State.SelectAll();
        ddlState.DataTextField = "Fld_State";
        ddlState.DataValueField = "PK_ID";
        ddlState.DataBind();
        ddlState.Items.Insert(0, new ListItem("--Select--", "0"));

        ///Lease Type
        DataTable dtLeaseType = LU_Lease_Type.SelectAll().Tables[0];
        dtLeaseType.DefaultView.RowFilter = "Active = 'Y'";
        dtLeaseType = dtLeaseType.DefaultView.ToTable();
        ddlLeaseType.DataSource = dtLeaseType;
        ddlLeaseType.DataTextField = "Fld_Desc";
        ddlLeaseType.DataValueField = "PK_LU_Lease_Type";
        ddlLeaseType.DataBind();
        ddlLeaseType.Items.Insert(0, new ListItem("--Select--", "0"));

        ///Project Type
        DataTable dtProjType = LU_Project_Type.SelectAll().Tables[0];
        dtProjType.DefaultView.RowFilter = "Active = 'Y'";
        dtProjType = dtProjType.DefaultView.ToTable();
        ddlProjectType.DataSource = dtProjType;
        ddlProjectType.DataTextField = "Fld_Desc";
        ddlProjectType.DataValueField = "PK_LU_Project_Type";
        ddlProjectType.DataBind();
        ddlProjectType.Items.Insert(0, new ListItem("--Select--", "0"));
    }

    /// <summary>
    /// Bind Dealship Drop Down 
    /// </summary>
    /// <param name="strRegion"></param>
    private void BindDealeship(string strRegion)
    {
        //Dealership
        ddlDealership.DataSource = LU_Location.SelectAllDealership(strRegion);
        ddlDealership.DataTextField = "Dealership";
        ddlDealership.DataValueField = "PK_LU_Location_ID";
        ddlDealership.DataBind();

        ddlDealership.Items.Insert(0, new ListItem("--Select--", "0"));
    }

    /// <summary>
    /// Adds the sorting image beside the column in the grid on which 
    /// sorting has been performed
    /// </summary>
    /// <param name="headerRow">Header Row of the grid</param>
    private void AddSortImage(GridViewRow headerRow, GridView gvSearch)
    {
        Int32 iCol = GetSortColumnIndex(_SortBy, gvSearch);
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
    /// Returns the index of the column which contains perticular sort expression
    /// </summary>
    /// <param name="strSortExp">The column on which the sorting is to be performed</param>
    /// <returns>Integer</returns>
    private int GetSortColumnIndex(string strSortExp, GridView gvSearch)
    {
        int nRet = 0;
        // Iterate through the Columns collection to determine the index
        // of the column being sorted.
        foreach (DataControlField field in gvSearch.Columns)
        {
            //check Sort Expression value
            if (field.SortExpression.ToString() == strSortExp)
            {
                nRet = gvSearch.Columns.IndexOf(field);
            }
        }
        return nRet;
    }

    #endregion
}
