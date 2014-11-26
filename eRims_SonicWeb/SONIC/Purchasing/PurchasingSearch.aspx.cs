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

public partial class SONIC_Purchasing_PurchasingSearch : clsBasePage
{
    #region Properties

    string strSubOrder = "";
    string strSecOrder = "";

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

    /// <summary>
    /// Denotes Sort Field to sort all records by
    /// </summary>
    private string SortByAsset
    {
        get { return (!clsGeneral.IsNull(ViewState["SortByAsset"]) ? ViewState["SortByAsset"].ToString() : "asc"); }
        set { ViewState["SortByAsset"] = value; }
    }

    /// <summary>
    /// Denotes Sort Field to sort all records by
    /// </summary>
    private string SortByDepartment
    {
        get { return (!clsGeneral.IsNull(ViewState["SortByDepartment"]) ? ViewState["SortByDepartment"].ToString() : "asc"); }
        set { ViewState["SortByDepartment"] = value; }
    }

    /// <summary>
    /// Denotes Sort Field to sort all records by
    /// </summary>
    private string SortByLocation
    {
        get { return (!clsGeneral.IsNull(ViewState["SortByLocation"]) ? ViewState["SortByLocation"].ToString() : "asc"); }
        set { ViewState["SortByLocation"] = value; }
    }

    /// <summary>
    /// Denotes Sort Field to sort all records by
    /// </summary>
    private string SortByServiceContract
    {
        get { return (!clsGeneral.IsNull(ViewState["SortByServiceContract"]) ? ViewState["SortByServiceContract"].ToString() : "asc"); }
        set { ViewState["SortByServiceContract"] = value; }
    }

    /// <summary>
    /// Denotes Sort Field to sort all records by
    /// </summary>
    private string SortByLRAgreement
    {
        get { return (!clsGeneral.IsNull(ViewState["SortByLRAgreement"]) ? ViewState["SortByLRAgreement"].ToString() : "asc"); }
        set { ViewState["SortByLRAgreement"] = value; }
    }

    private string IsCorporateUser
    {
        get { return (!clsGeneral.IsNull(ViewState["IsCorporateUser"]) ? ViewState["IsCorporateUser"].ToString() : "N"); }
        set { ViewState["IsCorporateUser"] = value; }
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
        if (!IsPostBack)
        {
            BindDropDownList();
            Purchasing_SearchTAB.Visible = false;
            if (Purchasing_SearchTAB.Visible)
                Purchasing_SearchTAB.SetSelectedTab(CtrlPurchasing_Search.Tab.Search);
            IsCorporateUser = new Security(Convert.ToDecimal(clsSession.UserID)).Corporate_User;            
        }
    }

    #endregion

    #region "Events"

    /// <summary>
    /// Handle Search Click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        Purchasing_SearchTAB.Visible = true;
        dvSearch.Style["display"] = "none";
        dvSearchResult.Style["display"] = "";
        if (ddlSearchType.SelectedIndex == 3)
        {
            SortBy = "Supplier";
            strSecOrder = ",Service_Type,Start_Date,End_Date";
            SortOrder = "asc";
            Purchasing_SearchTAB.StrRedirectTo = "ServiceContract.aspx?op=add";
        }
        else if (ddlSearchType.SelectedIndex == 2)
        {
            SortBy = "Supplier";
            strSecOrder = ",Dealership_department,Equipment_Type,Start_Date,End_Date";
            SortOrder = "asc";
            Purchasing_SearchTAB.StrRedirectTo = "LeaseRentalAgreement.aspx?op=add";
        }
        else
        {
            SortBy = "Location";
            strSecOrder = ",Dealership_department,Type,Manufacturer";
            SortOrder = "asc";
            Purchasing_SearchTAB.StrRedirectTo = "PurchasingAssetInformation.aspx";
        }

        BindSearchResult(1, ctrlPurchasingSearch.PageSize);
        CheckUserRights();
    }

    /// <summary>
    ///Handle Dropdown Region selected change event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ddlRegion_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindDealershipDropdown();
        
        Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "onSearchTypeChange();", true);
    }

    /// <summary>
    /// Handle Add new buttonn click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnAddNew_Click(object sender, EventArgs e)
    {
        if (ddlSearchType.SelectedIndex == 1)
        {
            Response.Redirect("PurchasingAssetInformation.aspx", true);
        }
        else if (ddlSearchType.SelectedIndex == 2)
        {
            clsSession.Str_LR_Agreement_Operation = "add";
            Response.Redirect("LeaseRentalAgreement.aspx", true);
        }
        else if (ddlSearchType.SelectedIndex == 3)
        {
            clsSession.Str_ServiceContract_Operation = "add";
            Response.Redirect("ServiceContract.aspx", true);
        }
    }

    /// <summary>
    /// Handle back to serach event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnBack_Click(object sender, EventArgs e)
    {
        dvSearch.Style["display"] = "";
        dvSearchResult.Style["display"] = "none";
        Purchasing_SearchTAB.Visible = false;
        ClearSearchControls();
    }

    #endregion

    #region "Method"

    /// <summary>
    /// Clear search controls
    /// </summary>
    private void ClearSearchControls()
    {
        if (ddlSearchType.SelectedIndex == 1)
        {
            gvAsset.Visible = false;
            gvAsset.DataSource = null;
            gvAsset.DataBind();
        }
        else if (ddlSearchType.SelectedIndex == 2)
        {
            gvLRAgreement.Visible = false;
            gvLRAgreement.DataSource = null;
            gvLRAgreement.DataBind();
        }
        else if (ddlSearchType.SelectedIndex == 3)
        {
            gvServiceContract.Visible = false;
            gvServiceContract.DataSource = null;
            gvServiceContract.DataBind();
        }
        ddlDealership.SelectedIndex = 0;
        ddlRegion.SelectedIndex = 0;
        ddlSearchType.SelectedIndex = 0;
        ddlServiceContractType.SelectedIndex = 0;
        ddlLeaseEquipmentType.SelectedIndex = 0;
        txtAssetType.Text = "";
        txtExpirationDateFrom.Text = "";
        txtExpirationDateTo.Text = "";
        txtManufacturer.Text = "";
        txtStartDateTo.Text = "";
        txtStartDateFrom.Text = "";
        txtServiceType.Text = "";
        txtSupplier.Text = "";
    }

    /// <summary>
    /// Bind dropdown lists
    /// </summary>
    private void BindDropDownList()
    {
        //service Contract type
        ddlServiceContractType.DataSource = LU_Service_Contract.selectAll();
        ddlServiceContractType.DataTextField = "Fld_Desc";
        ddlServiceContractType.DataValueField = "PK_LU_Service_Contract";
        ddlServiceContractType.DataBind();

        ddlServiceContractType.Items.Insert(0, new ListItem("--Select--", "0"));

        //Dealership Department 
        ddlDealershipDepartment.DataSource = LU_Dealership_Department.SelectAll();
        ddlDealershipDepartment.DataTextField = "Fld_Desc";
        ddlDealershipDepartment.DataValueField = "PK_LU_Dealership_Department";
        ddlDealershipDepartment.DataBind();

        ddlDealershipDepartment.Items.Insert(0, new ListItem("--Select--", "0"));

        //Equipement Type
        ddlLeaseEquipmentType.DataSource = LU_Equipment_Type.SelectAll();
        ddlLeaseEquipmentType.DataTextField = "Fld_Desc";
        ddlLeaseEquipmentType.DataValueField = "PK_LU_Equipment_Type";
        ddlLeaseEquipmentType.DataBind();

        ddlLeaseEquipmentType.Items.Insert(0, new ListItem("--Select--", "0"));

        //region       
        ddlRegion.DataSource = LU_Location.GetRegionListByUser(Convert.ToDecimal(clsSession.UserID)).Tables[0]; ;
        ddlRegion.DataTextField = "region";
        ddlRegion.DataValueField = "region";
        ddlRegion.DataBind();
        ddlRegion.Items.Insert(0, new ListItem("--All--", ""));

        //Dealership 
        BindDealershipDropdown();
    }

    private void BindDealershipDropdown()
    {
        string strRegion = "";
        if (ddlRegion.SelectedIndex > 0)
        {
            strRegion = "'" + ddlRegion.SelectedValue.ToString().Trim() + "'";
        }
        else
        {
            int i = 0;
            foreach (ListItem lstRegion in ddlRegion.Items)
            {
                if (i > 0) strRegion = strRegion + "'" + lstRegion.Value + "',";
                i++;
            }
        }
        strRegion = strRegion.TrimEnd(',');

        DataTable dtDealership = LU_Location.SelectAllDealership(strRegion).Tables[0];
        dtDealership.DefaultView.RowFilter = "Active = 'Y'";
        dtDealership = dtDealership.DefaultView.ToTable();
        ddlDealership.DataSource = dtDealership;
        ddlDealership.DataTextField = "Dealership";
        ddlDealership.DataValueField = "PK_LU_Location_ID";
        ddlDealership.DataBind();
        ddlDealership.Items.Insert(0, new ListItem("--All--", "0"));
    }

    /// <summary>
    /// get page number for paging
    /// </summary>
    protected void GetPage()
    {
        BindSearchResult(ctrlPurchasingSearch.CurrentPage, ctrlPurchasingSearch.PageSize);
    }

    /// <summary>
    /// Adds the sorting image beside the column in the grid on which 
    /// sorting has been performed
    /// </summary>
    /// <param name="headerRow">Header Row of the grid</param>
    private void AddSortImage_SC(GridViewRow headerRow)
    {
        Int32 iCol = -1;
        string strSortOrder = "";
        if (strSubOrder != "Asset" && strSubOrder != "Dealership_Department" && strSubOrder != "Location")
        {
            iCol = GetSortColumnIndex(SortBy, gvServiceContract);
            strSortOrder = SortOrder == "asc" ? SortDirection.Ascending.ToString() : SortDirection.Descending.ToString();
        }
        else
        {
            iCol = GetSortColumnIndex(strSubOrder, gvServiceContract);
            if (strSubOrder == "Asset")
            {
                strSortOrder = SortByAsset == "asc" ? SortDirection.Ascending.ToString() : SortDirection.Descending.ToString();
            }
            else if (strSubOrder == "Dealership_Department")
            {
                strSortOrder = SortByDepartment == "asc" ? SortDirection.Ascending.ToString() : SortDirection.Descending.ToString();
            }
            else if (strSubOrder == "Location")
            {
                strSortOrder = SortByLocation == "asc" ? SortDirection.Ascending.ToString() : SortDirection.Descending.ToString();
            }
        }

        if (iCol == -1)
        {
            return;
        }
        // Create the sorting image based on the sort direction.
        Image sortImage = new Image();
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
    private int GetSortColumnIndex(string strSortExp, GridView gvResult)
    {
        int nRet = 0;
        // Iterate through the Columns collection to determine the index
        // of the column being sorted.
        foreach (DataControlField field in gvResult.Columns)
        {
            //check Sort Expression value
            if (field.SortExpression.ToString() == strSortExp)
            {
                nRet = gvResult.Columns.IndexOf(field);
            }
        }
        return nRet;
    }

    /// <summary>
    /// bind search result
    /// </summary>
    /// <param name="PageNumber"></param>
    /// <param name="PageSize"></param>
    private void BindSearchResult(int PageNumber, int PageSize)
    {
        string strRegion = "";
        if (ddlRegion.SelectedIndex > 0)
        {
            strRegion = "'" + ddlRegion.SelectedValue.ToString().Trim() + "'";
        }
        else
        {
            int i = 0;
            foreach (ListItem lstRegion in ddlRegion.Items)
            {
                if (i > 0) strRegion = strRegion + "'" + lstRegion.Value + "',";
                i++;
            }
        }
        strRegion = strRegion.TrimEnd(',');
        DataSet dsSearchResult = null;
        if (ddlSearchType.SelectedIndex == 1)
        {
            gvAsset.Visible = true;

            dsSearchResult = Purchasing_Asset.Purchasing_Asset_Search(clsGeneral.FormatNullDateToStore(txtStartDateFrom.Text.Trim()), clsGeneral.FormatNullDateToStore(txtStartDateTo.Text.Trim()), strRegion, Convert.ToDecimal(ddlDealership.SelectedValue),
              Convert.ToDecimal(ddlDealershipDepartment.SelectedValue), txtAssetType.Text.Trim().Replace("'", "''"), txtManufacturer.Text.Trim().Replace("'", "''"), SortBy + strSecOrder, SortOrder, PageNumber, PageSize);
            gvAsset.DataSource = dsSearchResult.Tables[0];
            gvAsset.DataBind();

            lblSearchHeader.Text = "Asset Search";
            lblNumber.Text = " Asset Records Found";
            if (dsSearchResult.Tables[0].Rows.Count > 0)
            {
                gvAsset.Width = new Unit("1300px");
                dvGrid.Style.Add("overflow-x", "scroll");
            }
            else
            {
                gvAsset.Width = new Unit("999px");
                dvGrid.Style.Add("overflow-x", "none");
            }
        }
        else if (ddlSearchType.SelectedIndex == 2)
        {
            gvLRAgreement.Visible = true;

            bool? bIsUserAdmin = (App_Access == AccessType.Administrative_Access);
            
            dsSearchResult = Purchasing_LR_Agreement.Purchasing_LRAgreementSearch(clsGeneral.FormatNullDateToStore(txtStartDateFrom.Text.Trim()), clsGeneral.FormatNullDateToStore(txtStartDateTo.Text.Trim()),
              clsGeneral.FormatNullDateToStore(txtExpirationDateFrom.Text.Trim()), clsGeneral.FormatNullDateToStore(txtExpirationDateTo.Text.Trim()), strRegion, Convert.ToDecimal(ddlDealership.SelectedValue),
              Convert.ToDecimal(ddlLeaseEquipmentType.SelectedValue), Convert.ToDecimal(ddlDealershipDepartment.SelectedValue), txtSupplier.Text.Trim().Replace("'", "''"), SortBy + strSecOrder, SortOrder, PageNumber, PageSize, bIsUserAdmin, IsCorporateUser);
            gvLRAgreement.DataSource = dsSearchResult.Tables[0];
            gvLRAgreement.DataBind();

            lblSearchHeader.Text = "Lease/Rental Agreement Search";
            lblNumber.Text = " Lease Agreement Records Found";
            if (dsSearchResult.Tables[0].Rows.Count > 0)
            {
                gvLRAgreement.Width = new Unit("1500px");
                dvGrid.Style.Add("overflow-x", "scroll");
            }
            else
            {
                gvLRAgreement.Width = new Unit("999px");
                dvGrid.Style.Add("overflow-x", "none");
            }
        }
        else if (ddlSearchType.SelectedIndex == 3)
        {
            gvServiceContract.Visible = true;

            dsSearchResult = PurchasingServiceContract.Purchasing_ServiceContractSearch(clsGeneral.FormatNullDateToStore(txtStartDateFrom.Text.Trim()), clsGeneral.FormatNullDateToStore(txtStartDateTo.Text.Trim()),
               clsGeneral.FormatNullDateToStore(txtExpirationDateFrom.Text.Trim()), clsGeneral.FormatNullDateToStore(txtExpirationDateTo.Text.Trim()), strRegion, Convert.ToDecimal(ddlDealership.SelectedValue),
               Convert.ToDecimal(ddlServiceContractType.SelectedValue), Convert.ToDecimal(ddlDealershipDepartment.SelectedValue), txtSupplier.Text.Trim().Replace("'", "''"), txtServiceType.Text.Trim().Replace("'", "''"), SortBy + strSecOrder, SortOrder, PageNumber, PageSize, IsCorporateUser);
            gvServiceContract.DataSource = dsSearchResult.Tables[0];
            gvServiceContract.DataBind();

            lblSearchHeader.Text = "Service Contract Search";
            lblNumber.Text = " Service Contract Records Found";

            if (dsSearchResult.Tables[0].Rows.Count > 0)
            {
                gvServiceContract.Width = new Unit("1500px");
                dvGrid.Style.Add("overflow-x", "scroll");
            }
            else
            {
                gvServiceContract.Width = new Unit("999px");
                dvGrid.Style.Add("overflow-x", "none");
            }
        }
        else
        {
            return;
        }
        //// set values for paging control,so it shows values as needed.
        ctrlPurchasingSearch.TotalRecords = (dsSearchResult.Tables.Count >= 2) ? Convert.ToInt32(dsSearchResult.Tables[1].Rows[0][0]) : 0;
        ctrlPurchasingSearch.CurrentPage = (dsSearchResult.Tables.Count >= 2) ? Convert.ToInt32(dsSearchResult.Tables[1].Rows[0][2]) : 0;
        ctrlPurchasingSearch.RecordsToBeDisplayed = dsSearchResult.Tables[0].Rows.Count;
        ctrlPurchasingSearch.SetPageNumbers();

        // set record numbers retrieved
        lblNumber.Text = ((dsSearchResult.Tables.Count >= 2) ? Convert.ToString(dsSearchResult.Tables[1].Rows[0][0]) : "0") + lblNumber.Text;
        if (dsSearchResult != null && dsSearchResult.Tables.Count > 0 && dsSearchResult.Tables[0].Rows.Count > 0)
        {
            SetDispositionColumns();
        }
    }

    /// <summary>
    /// Adds the sorting image beside the column in the grid on which 
    /// sorting has been performed
    /// </summary>
    /// <param name="headerRow">Header Row of the grid</param>
    private void AddSortImage_LR(GridViewRow headerRow)
    {
        Int32 iCol = -1;
        string strSortOrder = "";
        //if (strSubOrder == "Asset")
        //{
        //    iCol = GetSortColumnIndex(strSubOrder, gvLRAgreement);
        //    strSortOrder = SortByAsset == "asc" ? SortDirection.Ascending.ToString() : SortDirection.Descending.ToString();
        //}
        //else
        //{
        //    iCol = GetSortColumnIndex(SortBy, gvLRAgreement);
        //    strSortOrder = SortOrder == "asc" ? SortDirection.Ascending.ToString() : SortDirection.Descending.ToString();
        //}

        if (strSubOrder != "Asset" && strSubOrder != "Location")
        {
            iCol = GetSortColumnIndex(SortBy, gvLRAgreement);
            strSortOrder = SortOrder == "asc" ? SortDirection.Ascending.ToString() : SortDirection.Descending.ToString();
        }
        else
        {
            iCol = GetSortColumnIndex(strSubOrder , gvLRAgreement);
            if (strSubOrder == "Asset")
            {
                strSortOrder = SortByAsset == "asc" ? SortDirection.Ascending.ToString() : SortDirection.Descending.ToString();
            }          
            else if (strSubOrder == "Location")
            {
                strSortOrder = SortByLocation == "asc" ? SortDirection.Ascending.ToString() : SortDirection.Descending.ToString();
            }
        }
        
        if (iCol == -1)
        {
            return;
        }

        // Create the sorting image based on the sort direction.
        Image sortImage = new Image();
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
    /// Adds the sorting image beside the column in the grid on which 
    /// sorting has been performed
    /// </summary>
    /// <param name="headerRow">Header Row of the grid</param>
    private void AddSortImage_Asset(GridViewRow headerRow)
    {
        Int32 iCol = -1;
        string strSortOrder = "";
        if (strSubOrder == "Service_Contract")
        {
            iCol = GetSortColumnIndex(strSubOrder, gvAsset);
            strSortOrder = SortByServiceContract == "asc" ? SortDirection.Ascending.ToString() : SortDirection.Descending.ToString();
        }
        else if (strSubOrder == "LR_Agreement")
        {
            iCol = GetSortColumnIndex(strSubOrder, gvAsset);
            strSortOrder = SortByLRAgreement == "asc" ? SortDirection.Ascending.ToString() : SortDirection.Descending.ToString();
        }
        else
        {
            iCol = GetSortColumnIndex(SortBy, gvAsset);
            strSortOrder = SortOrder == "asc" ? SortDirection.Ascending.ToString() : SortDirection.Descending.ToString();
        }

        if (iCol == -1)
        {
            return;
        }

        // Create the sorting image based on the sort direction.
        Image sortImage = new Image();
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
    /// check user rights
    /// </summary>
    private void CheckUserRights()
    {
        if (App_Access == AccessType.View_Only)
        {
            btnAdd.Visible = false;
            gvServiceContract.Columns[13].Visible = false;
            gvServiceContract.Columns[11].Visible = false;
            gvLRAgreement.Columns[10].Visible = false;
            gvLRAgreement.Columns[12].Visible = false;
            gvAsset.Columns[7].Visible = false;
            gvAsset.Columns[9].Visible = false;
        }
        else
        {
            btnAdd.Visible = true;
            if (App_Access == AccessType.Administrative_Access)
            {
                gvServiceContract.Columns[13].Visible = true;
                gvAsset.Columns[9].Visible = true;
                gvLRAgreement.Columns[12].Visible = true;
            }
            else
            {
                gvServiceContract.Columns[13].Visible = false;
                gvAsset.Columns[9].Visible = false;
                gvLRAgreement.Columns[12].Visible = false;
            }
        }
    }

    /// <summary>
    /// set Disposition column header as per user rights
    /// </summary>
    private void SetDispositionColumns()
    {
        if (App_Access == AccessType.View_Only)
        {
            if (ddlSearchType.SelectedIndex == 3)
            {
                gvServiceContract.HeaderRow.Cells[12].Text = "Disposition";
            }
            else if (ddlSearchType.SelectedIndex == 2)
            {
                gvLRAgreement.HeaderRow.Cells[11].Text = "Disposition";
            }
            else if (ddlSearchType.SelectedIndex == 1)
            {
                gvAsset.HeaderRow.Cells[8].Text = "Disposition";
            }
        }
        else
        {
            btnAdd.Visible = true;
            if (App_Access == AccessType.Administrative_Access)
            {
                if (ddlSearchType.SelectedIndex == 3)
                {
                    gvServiceContract.HeaderRow.Cells[11].Text = "Disposition";
                    gvServiceContract.HeaderRow.Cells[11].ColumnSpan = 3;
                    gvServiceContract.HeaderRow.Cells.RemoveAt(13);
                    gvServiceContract.HeaderRow.Cells.RemoveAt(12);
                }
                else if (ddlSearchType.SelectedIndex == 2)
                {
                    gvLRAgreement.HeaderRow.Cells[10].Text = "Disposition";
                    gvLRAgreement.HeaderRow.Cells[10].ColumnSpan = 3;
                    gvLRAgreement.HeaderRow.Cells.RemoveAt(12);
                    gvLRAgreement.HeaderRow.Cells.RemoveAt(11);
                }
                else if (ddlSearchType.SelectedIndex == 1)
                {
                    gvAsset.HeaderRow.Cells[7].Text = "Disposition";
                    gvAsset.HeaderRow.Cells[7].ColumnSpan = 3;
                    gvAsset.HeaderRow.Cells.RemoveAt(9);
                    gvAsset.HeaderRow.Cells.RemoveAt(8);
                }
            }
            else
            {
                if (ddlSearchType.SelectedIndex == 3)
                {
                    gvServiceContract.HeaderRow.Cells[11].Text = "Disposition";
                    gvServiceContract.HeaderRow.Cells[11].ColumnSpan = 2;
                    gvServiceContract.HeaderRow.Cells.RemoveAt(12);
                }
                else if (ddlSearchType.SelectedIndex == 2)
                {
                    gvLRAgreement.HeaderRow.Cells[10].Text = "Disposition";
                    gvLRAgreement.HeaderRow.Cells[10].ColumnSpan = 2;
                    gvLRAgreement.HeaderRow.Cells.RemoveAt(11);
                }
                else if (ddlSearchType.SelectedIndex == 1)
                {
                    gvAsset.HeaderRow.Cells[7].Text = "Disposition";
                    gvAsset.HeaderRow.Cells[7].ColumnSpan = 2;
                    gvAsset.HeaderRow.Cells.RemoveAt(8);
                }
            }
        }
    }

    #endregion

    #region "Grid Event"

    #region "service Contract"

    /// <summary>
    /// Handle Service Contract grid row command event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvServiceContract_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.ToString() == "EditItem")
        {
            decimal intPkey = Convert.ToDecimal(e.CommandArgument);
            clsSession.Str_ServiceContract_Operation = "edit";
            Response.Redirect("ServiceContract.aspx?id=" + Encryption.Encrypt(intPkey.ToString()), true);
        }
        else if (e.CommandName.ToString() == "ViewItem")
        {
            decimal intPkey = Convert.ToDecimal(e.CommandArgument);
            clsSession.Str_ServiceContract_Operation = "view";
            Response.Redirect("ServiceContract.aspx?id=" + Encryption.Encrypt(intPkey.ToString()), true);
        }
        else if (e.CommandName.ToString() == "DeleteItem")
        {
            decimal intPkey = Convert.ToDecimal(e.CommandArgument);
            PurchasingServiceContract.DeleteByPK(intPkey);
            BindSearchResult(ctrlPurchasingSearch.CurrentPage, ctrlPurchasingSearch.PageSize);
        }
    }

    /// <summary>
    /// Handle Service Contract Row Data Bound Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvServiceContract_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            decimal PK_Service_Contract = Convert.ToDecimal(gvServiceContract.DataKeys[e.Row.RowIndex].Value.ToString());

            Repeater rptDepartment = (Repeater)e.Row.FindControl("rptDepartment");
            //Repeater rptLocation = (Repeater)e.Row.FindControl("rptLocation");
            Repeater rptAsset = (Repeater)e.Row.FindControl("rptAsset");
            HtmlGenericControl dvLocation = (HtmlGenericControl)e.Row.FindControl("dvLocation");

            rptDepartment.DataSource = Purchasing_SC_Department.SelectAllByServiceContract(Convert.ToInt32(PK_Service_Contract), SortByDepartment);
            rptDepartment.DataBind();
            //rptLocation.DataSource = Purchasing_SC_Dealer.SelectByServiceContract(PK_Service_Contract, SortByLocation);
            //rptLocation.DataBind();
            rptAsset.DataSource = Purchasing_SC_Asset.SelectByFK_Service_Contract(PK_Service_Contract, SortByAsset);
            rptAsset.DataBind();

            DataSet dsLocation = Purchasing_SC_Dealer.SelectByServiceContract(PK_Service_Contract, SortByLocation);
            if (dsLocation != null && dsLocation.Tables.Count > 0 && dsLocation.Tables[0].Rows.Count > 0)
            {
                string strLocation = "";
                if (dsLocation.Tables[0].Rows.Count == 1)
                {
                    strLocation = Convert.ToString(dsLocation.Tables[0].Rows[0]["dba"]) + " - " + Convert.ToString(dsLocation.Tables[0].Rows[0]["city"]) + ", " + Convert.ToString(dsLocation.Tables[0].Rows[0]["state"]);
                    dvLocation.InnerHtml = strLocation;
                }
                else
                {
                    strLocation = "Multiple <br/>";
                    DataTable dtLocation = dsLocation.Tables[0].DefaultView.ToTable(true, new string[] { "dba", "city", "state" });
                    if (dtLocation != null && dtLocation.Rows.Count > 1)
                    {
                        DataTable dtState = dtLocation.DefaultView.ToTable(true, "state");

                        if (dtState != null)
                        {
                            dtState.DefaultView.Sort = "[state] asc";
                            foreach (DataRow dr in dtState.Rows)
                            {
                                strLocation += Convert.ToString(dr["state"]) + " <br/>";
                            }
                        }
                        dvLocation.InnerHtml = strLocation;
                    }
                    else
                    {
                        strLocation += Convert.ToString(dtLocation.Rows[0]["city"]) + ", " + Environment.NewLine + Convert.ToString(dtLocation.Rows[0]["state"]);
                        dvLocation.InnerHtml = strLocation;
                    }
                }
            }

            HiddenField hdfLgc = (HiddenField)e.Row.FindControl("hdfLegalConfidential");
            Button lnkEdit = (Button)e.Row.FindControl("lnkEdit");
            Button lnkView = (Button)e.Row.FindControl("lnkView");

            if (hdfLgc.Value.ToLower().Trim() == "y")
            {
                if (App_Access == AccessType.View_Only)
                {
                    lnkView.Visible = false;
                }
                else if (App_Access == AccessType.Purchasing_Edit)
                {
                    lnkEdit.Visible = false; 
                    lnkView.Visible = false;
                }
            }
        }
    }

    /// <summary>
    /// Handle Service Contract Data Sorting event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvServiceContract_Sorting(object sender, GridViewSortEventArgs e)
    {
        strSubOrder = e.SortExpression.ToString();
        strSecOrder = "";
        if (e.SortExpression != "Asset" && e.SortExpression != "Dealership_Department" && e.SortExpression != "Location")
        {
            // update sort field and sort order and bind the grid
            SortOrder = (SortBy == e.SortExpression) ? (SortOrder == "asc" ? "desc" : "asc") : "asc";
            SortBy = e.SortExpression;
        }
        else
        {
            switch (e.SortExpression)
            {
                case "Asset":
                    SortByAsset = (SortByAsset == "asc" ? "desc" : "asc");
                    break;
                case "Dealership_Department":
                    SortByDepartment = (SortByDepartment == "asc" ? "desc" : "asc");
                    break;
                case "Location":
                    SortByLocation = (SortByLocation == "asc" ? "desc" : "asc");
                    break;
                default:
                    break;
            }
        }
        BindSearchResult(ctrlPurchasingSearch.CurrentPage, ctrlPurchasingSearch.PageSize);
    }

    /// <summary>
    /// Handle Service Contract grid row command event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvServiceContract_RowCreated(object sender, GridViewRowEventArgs e)
    {
        // check for the header row
        if (e.Row.RowType == DataControlRowType.Header)
        {
            // if sort field already available
            if (String.Empty != SortBy)
            {
                // update sort image beside the column header 
                AddSortImage_SC(e.Row);
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

    #region "LR Agreement"

    /// <summary>
    /// Handle Lease/Rental Agreement grid row command event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvLRAgreement_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.ToString() == "EditItem")
        {
            decimal intPkey = Convert.ToDecimal(e.CommandArgument);
            clsSession.Str_LR_Agreement_Operation = "edit";
            Response.Redirect("LeaseRentalAgreement.aspx?id=" + Encryption.Encrypt(intPkey.ToString()), true);
        }
        else if (e.CommandName.ToString() == "ViewItem")
        {
            decimal intPkey = Convert.ToDecimal(e.CommandArgument);
            clsSession.Str_LR_Agreement_Operation = "view";
            Response.Redirect("LeaseRentalAgreement.aspx?id=" + Encryption.Encrypt(intPkey.ToString()), true);
        }
        else if (e.CommandName.ToString() == "DeleteItem")
        {
            decimal intPkey = Convert.ToDecimal(e.CommandArgument);
            Purchasing_LR_Agreement.DeleteByPK(intPkey);
            BindSearchResult(ctrlPurchasingSearch.CurrentPage, ctrlPurchasingSearch.PageSize);
        }
    }

    /// <summary>
    /// Handle LR Agreement  Row Data Bound Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvLRAgreement_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            decimal PK_LR_Agreement = Convert.ToDecimal(gvLRAgreement.DataKeys[e.Row.RowIndex].Value.ToString());

            Repeater rptAsset = (Repeater)e.Row.FindControl("rptAsset");
            rptAsset.DataSource = Purchasing_LR_Asset.SelectByFK_LR(PK_LR_Agreement, SortByAsset);
            rptAsset.DataBind();
            HtmlGenericControl dvLocation = (HtmlGenericControl)e.Row.FindControl("dvLocation");
            DataSet dsLocation = Purchasing_LR_Dealer.SelectByLR_Agreement(PK_LR_Agreement, SortByLocation);
            if (dsLocation != null && dsLocation.Tables.Count > 0 && dsLocation.Tables[0].Rows.Count > 0)
            {
                string strLocation = "";
                if (dsLocation.Tables[0].Rows.Count == 1)
                {
                    strLocation = Convert.ToString(dsLocation.Tables[0].Rows[0]["dba"]) + " - " + Convert.ToString(dsLocation.Tables[0].Rows[0]["city"]) + ", " + Convert.ToString(dsLocation.Tables[0].Rows[0]["state"]);
                    dvLocation.InnerHtml = strLocation;
                }
                else
                {
                    strLocation = "Multiple <br/>";
                    DataTable dtLocation = dsLocation.Tables[0].DefaultView.ToTable(true, new string[] { "dba", "city", "state" });
                    if (dtLocation != null && dtLocation.Rows.Count > 1)
                    {
                        DataTable dtState = dtLocation.DefaultView.ToTable(true, "state");

                        if (dtState != null)
                        {
                            dtState.DefaultView.Sort = "[state] asc";
                            foreach (DataRow dr in dtState.Rows)
                            {
                                strLocation += Convert.ToString(dr["state"]) + " <br/>";
                            }
                        }
                        dvLocation.InnerHtml = strLocation;
                    }
                    else
                    {
                        strLocation += Convert.ToString(dtLocation.Rows[0]["city"]) + ", " + Environment.NewLine + Convert.ToString(dtLocation.Rows[0]["state"]);
                        dvLocation.InnerHtml = strLocation;
                    }
                }
            }
        }
    }

    /// <summary>
    /// Handle  LR Agreement Data Sorting event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvLRAgreement_Sorting(object sender, GridViewSortEventArgs e)
    {       
        strSubOrder = e.SortExpression.ToString();
        strSecOrder = "";
        if (e.SortExpression != "Asset" && e.SortExpression != "Location")
        {
            // update sort field and sort order and bind the grid
            SortOrder = (SortBy == e.SortExpression) ? (SortOrder == "asc" ? "desc" : "asc") : "asc";
            SortBy = e.SortExpression;
        }
        else
        {
            switch (e.SortExpression)
            {
                case "Asset":
                    SortByAsset = (SortByAsset == "asc" ? "desc" : "asc");
                    break;               
                case "Location":
                    SortByLocation = (SortByLocation == "asc" ? "desc" : "asc");
                    break;
                default:
                    break;
            }
        }


        BindSearchResult(ctrlPurchasingSearch.CurrentPage, ctrlPurchasingSearch.PageSize);
    }

    /// <summary>
    /// Handle  LR Agreement grid row command event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvLRAgreement_RowCreated(object sender, GridViewRowEventArgs e)
    {
        // check for the header row
        if (e.Row.RowType == DataControlRowType.Header)
        {
            // if sort field already available
            if (String.Empty != SortBy)
            {
                // update sort image beside the column header 
                AddSortImage_LR(e.Row);
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

    #region "Assets"

    /// <summary>
    /// Handle Asset grid row command event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvAsset_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.ToString() == "DeleteItem")
        {
            decimal intPkey = Convert.ToDecimal(e.CommandArgument);
            Purchasing_Asset.DeleteByPK(intPkey);
            BindSearchResult(ctrlPurchasingSearch.CurrentPage, ctrlPurchasingSearch.PageSize);
        }
        else if (e.CommandName.ToString() == "ViewItem")
        {
            clsSession.Str_Asset_Operation = "view";

            // open the page in view mode
            Response.Redirect("PurchasingAssetInformation.aspx?id=" + Encryption.Encrypt(e.CommandArgument.ToString()));
        }
        else if (e.CommandName.ToString() == "EditItem")
        {
            clsSession.Str_Asset_Operation = "edit";

            // open the page in view mode
            Response.Redirect("PurchasingAssetInformation.aspx?id=" + Encryption.Encrypt(e.CommandArgument.ToString()));
        }
    }

    /// <summary>
    /// Handle Asset  Row Data Bound Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvAsset_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            decimal PK_Asset = Convert.ToDecimal(gvAsset.DataKeys[e.Row.RowIndex].Value.ToString());

            Repeater rptServiceContract = (Repeater)e.Row.FindControl("rptServiceContract");
            rptServiceContract.DataSource = Purchasing_Asset.Purchasing_Asset_Select_SC(PK_Asset, SortByServiceContract);
            rptServiceContract.DataBind();

            Repeater rptLRAgreement = (Repeater)e.Row.FindControl("rptLRAgreement");
            rptLRAgreement.DataSource = Purchasing_Asset.Purchasing_Asset_Select_LR(PK_Asset, SortByLRAgreement);
            rptLRAgreement.DataBind();
        }
    }

    /// <summary>
    /// Handle  Asset Data Sorting event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvAsset_Sorting(object sender, GridViewSortEventArgs e)
    {
        strSecOrder = "";
        strSubOrder = e.SortExpression.ToString();
        if (e.SortExpression == "LR_Agreement")
        {
            SortByLRAgreement = (SortByLRAgreement == "asc" ? "desc" : "asc");
        }
        else if (e.SortExpression == "Service_Contract")
        {
            SortByServiceContract = (SortByServiceContract == "asc" ? "desc" : "asc");
        }
        else
        {
            // update sort field and sort order and bind the grid
            SortOrder = (SortBy == e.SortExpression) ? (SortOrder == "asc" ? "desc" : "asc") : "asc";
            SortBy = e.SortExpression;
        }
        BindSearchResult(ctrlPurchasingSearch.CurrentPage, ctrlPurchasingSearch.PageSize);
    }

    /// <summary>
    /// Handle  Asset grid row command event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvAsset_RowCreated(object sender, GridViewRowEventArgs e)
    {
        // check for the header row
        if (e.Row.RowType == DataControlRowType.Header)
        {
            // if sort field already available
            if (String.Empty != SortBy)
            {
                // update sort image beside the column header 
                AddSortImage_Asset(e.Row);
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

    #endregion
}
