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

public partial class COI_PopUpInsuredName : System.Web.UI.Page
{
    #region "Properties"
    /// <summary>
    /// Denotes Sort Field to sort all records by
    /// </summary>
    private string _SortBy
    {
        get { return Convert.ToString(ViewState["SortBy"]); }
        set { ViewState["SortBy"] = value; }
    }

    /// <summary>
    /// Denotes ascending or descending order
    /// </summary>
    private string _SortOrder
    {
        get { return Convert.ToString(ViewState["SortOrder"]); }
        set { ViewState["SortOrder"] = value; }
    }
    #endregion

    #region "Page Event"
    /// <summary>
    /// Page Load Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            //Bind DropDown List 
            BindDropDown();
            _SortBy = "dba";
            _SortOrder = "asc";
            drpRegion.Focus();
        }
    }
    #endregion

    #region " Controls Events "

    /// <summary>
    /// Handles Search button click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        trGrid.Visible = true;
        //_PageNum = 1;       

        BindGrid(1, 10);
    }
    /// <summary>
    /// Reset Button Click Event To ReBind All Data
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnResetFilterCriteria_Click(object sender, EventArgs e)
    {
        BindDropDown();
        trPager.Visible = false;
        trGrid.Visible = false;
    }

    #region "DropDownList Selected Index Event"
    /// <summary>
    /// Region DropDown List Index wise Bind State And Location D/B/A
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ddlRegion_SelectedIndexChanged(object sender, EventArgs e)
    {
        string strSelectDropDownValue = (drpRegion.SelectedIndex > 0) ? drpRegion.SelectedValue : "";
        string strStateindex = Convert.ToString(drpState.SelectedValue);
        string strDBAindex = Convert.ToString(drpLocation.SelectedValue);
        //Get Region Wise Location and State Bind Data      
        DataSet dsRegion = clsGetInsuredName_SONIC.Get_RegionWise_State_Location(strSelectDropDownValue);
        if (dsRegion != null && dsRegion.Tables.Count > 0)
        {
            //Location Bind  
            if (dsRegion.Tables[0].Rows.Count > 0)
            {
                drpLocation.DataSource = BindDBALocataion(dsRegion.Tables[0]);
            }
            ListItem lstItm = drpLocation.Items.FindByValue(strDBAindex);
            if (lstItm != null)
                lstItm.Selected = true;
            else
                drpLocation.SelectedIndex = 0;
            // State
            if (dsRegion.Tables[1].Rows.Count > 0)
            {
                drpState.DataSource = BindState(dsRegion.Tables[1]);
            }
            ListItem lstItmState = drpState.Items.FindByValue(strStateindex);
            if (lstItmState != null)
                lstItmState.Selected = true;
            else
                drpState.SelectedIndex = 0;
        }
    }
    /// <summary>
    /// Location D/B/A Wise State and Region Bind Data
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ddlDBA_SelectedIndexChanged(object sender, EventArgs e)
    {
        string strSelectDropDownValue = (drpLocation.SelectedIndex > 0) ? drpLocation.SelectedItem.Text : "";
        string strRegionindex = Convert.ToString(drpRegion.SelectedValue);
        string strStateindex = Convert.ToString(drpState.SelectedValue);

        //Get dba Wise Location and State Bind Data       
        DataSet dsDBA = clsGetInsuredName_SONIC.Get_DBA_Wise_State_Region(strSelectDropDownValue, strRegionindex);
        if (dsDBA != null && dsDBA.Tables.Count > 0)
        {
            //Location   
            if (dsDBA.Tables[0].Rows.Count > 0)
            {
                drpRegion.DataSource = BindRegion(dsDBA.Tables[0]);
            }
            ListItem lstItmRegion = drpRegion.Items.FindByValue(strRegionindex);
            if (lstItmRegion != null)
                lstItmRegion.Selected = true;
            else
                drpRegion.SelectedIndex = 0;
            // State
            if (dsDBA.Tables[1].Rows.Count > 0)
            {
                drpState.DataSource = BindState(dsDBA.Tables[1]);
            }
            ListItem lstItm = drpState.Items.FindByValue(strStateindex);
            if (lstItm != null)
                lstItm.Selected = true;
            else
                drpState.SelectedIndex = 0;
        }
    }
    /// <summary>
    /// State DropDown List Wise Bind Location And Region Data
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
    {
        string strSelectDropDownValue = (drpState.SelectedIndex > 0) ? drpState.SelectedItem.Text : "";
        string strRegionindex = Convert.ToString(drpRegion.SelectedValue);
        string strDBAindex = Convert.ToString(drpLocation.SelectedValue);
        //Get State Wise Location and Region Bind Data      
        DataSet dsState = clsGetInsuredName_SONIC.Get_State_Wise_DBA_Region(strSelectDropDownValue, strRegionindex);
        if (dsState != null && dsState.Tables.Count > 0)
        {
            //Region   
            if (dsState.Tables[0].Rows.Count > 0)
            {
                drpRegion.DataSource = BindRegion(dsState.Tables[0]);
            }
            ListItem lstItmRegion = drpRegion.Items.FindByValue(strRegionindex);
            if (lstItmRegion != null)
                lstItmRegion.Selected = true;
            else
                drpRegion.SelectedIndex = 0;

            // Location
            if (dsState.Tables[1].Rows.Count > 0)
            {
                drpLocation.DataSource = BindDBALocataion(dsState.Tables[1]);
            }
            ListItem lstItm = drpLocation.Items.FindByValue(strDBAindex);
            if (lstItm != null)
                lstItm.Selected = true;
            else
                drpLocation.SelectedIndex = 0;
        }
    }
    #endregion

    #endregion

    #region "Methods"
    /// <summary>
    /// Bind DropDown List Data
    /// </summary>
    private void BindDropDown()
    {
        //Region
        DataTable dtRegion = clsGetInsuredName_SONIC.GetRegionList().Tables[0];
        BindRegion(dtRegion);
        SetDropDownToolTip(new DropDownList[] { drpRegion });
        //Location 
        drpLocation.Items.Clear();
        DataTable dtLocationName = clsGetInsuredName_SONIC.GetLu_Location_DBA_List().Tables[0];
        BindDBALocataion(dtLocationName);
        SetDropDownToolTip(new DropDownList[] { drpLocation });
        //State
        drpState.Items.Clear();
        DataTable dtState = clsGetInsuredName_SONIC.GetState().Tables[0];
        BindState(dtState);
        SetDropDownToolTip(new DropDownList[] { drpState });
    }

    /// <summary>
    /// Bind Region 
    /// </summary>
    /// <param name="dtRegionData"></param>
    /// <returns></returns>
    private DataTable BindRegion(DataTable dtRegionData)
    {
        drpRegion.DataSource = dtRegionData;
        drpRegion.DataTextField = "region";
        drpRegion.DataValueField = "region";
        drpRegion.DataBind();
        drpRegion.Items.Insert(0, new ListItem("--Select--", "0"));
        return dtRegionData;

    }
    /// <summary>
    /// Bind State 
    /// </summary>
    /// <param name="dtStateData"></param>
    /// <returns></returns>
    private DataTable BindState(DataTable dtStateData)
    {
        drpState.DataSource = dtStateData;
        drpState.DataTextField = "FLD_state";
        drpState.DataValueField = "PK_ID";
        drpState.DataBind();
        drpState.Items.Insert(0, new ListItem("--Select--", "0"));
        return dtStateData;
    }
    /// <summary>
    /// Bind Location DBA
    /// </summary>
    /// <param name="dtLocationData"></param>
    /// <returns></returns>
    private DataTable BindDBALocataion(DataTable dtLocationData)
    {
        drpLocation.DataSource = dtLocationData;
        drpLocation.DataTextField = "dba";
        drpLocation.DataValueField = "PK_LU_Location_ID";
        drpLocation.DataBind();
        drpLocation.Items.Insert(0, new ListItem("--Select--", "0"));
        return dtLocationData;
    }

    /// <summary>
    /// Performs search and binds the grid
    /// </summary>
    private void BindGrid(int PageNumber, int PageSize)
    {
        // get search criteria       
        decimal? decDBA = null;
        decimal? decState = null;
        string strRegion = (drpRegion.SelectedIndex > 0) ? drpRegion.SelectedValue : "";
        if (drpLocation.SelectedIndex > 0) decDBA = Convert.ToDecimal(drpLocation.SelectedValue);
        if (drpState.SelectedIndex > 0) decState = Convert.ToDecimal(drpState.SelectedValue);
        // get result records matching search criteria
        DataSet dsInsuredName = clsGetInsuredName_SONIC.SearchByPaging(decState, strRegion, decDBA, _SortBy, _SortOrder, PageNumber, PageSize);

        // set values for paging control,so it shows values as needed.
        ctrlPageProperty.TotalRecords = (dsInsuredName.Tables.Count >= 1) ? Convert.ToInt32(dsInsuredName.Tables[1].Rows[0][0]) : 0;
        ctrlPageProperty.RecordsToBeDisplayed = dsInsuredName.Tables[0].Rows.Count;

        BindPageList(ctrlPageProperty.TotalRecords, PageNumber, PageSize);
        ctrlPageProperty.SetPageNumbers();

        // bind grid
        gvInsuredName.DataSource = dsInsuredName.Tables[0];
        gvInsuredName.DataBind();

        // set record numbers retrieved
        lblNumber.Text = (dsInsuredName.Tables.Count >= 2) ? Convert.ToString(dsInsuredName.Tables[1].Rows[0][0]) : "0";
        if (dsInsuredName != null && dsInsuredName.Tables.Count > 1 && dsInsuredName.Tables[0].Rows.Count > 0)
            trPager.Visible = true;
        else
            trPager.Visible = false;
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
        foreach (DataControlField field in gvInsuredName.Columns)
        {
            if (field.SortExpression.ToString() == strSortExp)
            {
                nRet = gvInsuredName.Columns.IndexOf(field);
            }
        }
        return nRet;
    }

    /// <summary>
    /// Implement event for Paging control when clicking on Go button
    /// </summary>
    protected void GetPage()
    {
        BindGrid(ctrlPageProperty.CurrentPage, ctrlPageProperty.PageSize);
    }

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
    /// Binds the page numbers to the grid footer
    /// </summary>
    /// <param name="intTotalRecords"></param>
    private void BindPageList(int intTotalRecords, int intPageNo, int intPageSize)
    {
        // calculate and show total pages.
        int intDivision = intTotalRecords / intPageSize;
        int intReminder = intTotalRecords % intPageSize;
        int intTotalPages = (intDivision > 0) ? (intDivision + ((intReminder > 0) ? 1 : 0)) : 1;

        if (intPageNo > intTotalPages)
        {
            ctrlPageProperty.CurrentPage = intTotalPages;
        }
        else
            ctrlPageProperty.CurrentPage = intPageNo;
    }

    /// <summary>
    /// Set Drop Down Tooltip
    /// </summary>
    /// <param name="drps"></param>
    public void SetDropDownToolTip(DropDownList[] drps)
    {
        for (int i = 0; i < drps.Length; i++)
        {
            foreach (ListItem li in drps[i].Items)
                li.Attributes.Add("title", li.Text);
        }
    }

    #endregion

    #region " GridView Events "

    /// <summary>
    /// Handles event when grid header link is clicked
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvInsuredName_Sorting(object sender, GridViewSortEventArgs e)
    {
        // set the sort order and sort column
        _SortBy = e.SortExpression;
        _SortOrder = (_SortBy == e.SortExpression) ? (_SortOrder == "asc" ? "desc" : "asc") : "asc";

        // binds the grid
        BindGrid(ctrlPageProperty.CurrentPage, ctrlPageProperty.PageSize);
    }
    /// <summary>
    /// Handles event 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvInsuredName_RowCreated(object sender, GridViewRowEventArgs e)
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
                e.Row.Cells[6].Controls.Add(sortImage);
            }
        }
    }
    /// <summary>
    /// Handle Row Data Bound event is selected row data in grid
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvInsuredName_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string strPK_Building_ID = "";
                string strBilidingNumber="",strRegion="", strSublease_Name = "", strSublease_Address_1 = "", strSublease_Address_2 = "", strSublease_City = "", strSublease_State = "", strSublease_Zip = "";
                string strSubLeaseFirstName = "", strSubLeaseLastName = "", strSubLeaseTitle = "", strSubLeasePhone = "", strSubLeaseFax = "", strSubLeaseEmail = "", strPK_Building_Ownership_ID = "", strFK_LU_Location_ID = "";
                string strLandlordName = "";
                string strPK_LU_Location_ID ="";
                LinkButton lnkdba = ((LinkButton)(e.Row.FindControl("lnkdba")));
                LinkButton lnkBuildingNumber = ((LinkButton)(e.Row.FindControl("lnkBuildingNumber")));
                LinkButton lnkAddress = ((LinkButton)(e.Row.FindControl("lnkAddress")));
                LinkButton lnkLandlord_Name = ((LinkButton)(e.Row.FindControl("lnkLandlord_Name")));
                LinkButton lnkSublease_Name = ((LinkButton)(e.Row.FindControl("lnkSublease_Name")));
                LinkButton lnkStatus = ((LinkButton)(e.Row.FindControl("lnkStatus")));

                strRegion = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "region"));
                strBilidingNumber = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Building_Numbers"));
                strSublease_Name = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Sublease_Name"));
                strLandlordName = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Landlord_Name"));
                strSublease_Address_1 = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Sublease_Address_1"));
                strSublease_Address_2 = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Sublease_Address_2"));
                strSublease_City = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Sublease_City"));
                strSublease_State = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Sublease_State_ID"));
                strSublease_Zip = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Sublease_Zip"));
                string strBuilding_TIV = string.Format("{0:N2}", DataBinder.Eval(e.Row.DataItem, "Building_TIV"));

                strSubLeaseFirstName = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Sublease_FirstName"));
                strSubLeaseLastName = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Sublease_LastName"));
                strSubLeaseTitle = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Sublease_Title"));
                strSubLeasePhone = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Sublease_Phone"));
                strSubLeaseFax = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Sublease_Fax"));
                strSubLeaseEmail = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Sublease_Email"));
                strPK_Building_Ownership_ID = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "PK_Building_Ownership_ID"));
                strFK_LU_Location_ID = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "dba"));
                strPK_Building_ID = gvInsuredName.DataKeys[e.Row.RowIndex][0].ToString();
                strPK_LU_Location_ID = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "PK_LU_Location_ID"));

                string strJSFunction = "SelectValue('" + strSublease_Name.ToString().Replace("'", "\\'")
                    + "','" + strLandlordName.ToString().Replace("'", "\\'")
                    + "','" + strBilidingNumber.ToString().Replace("'", "\\'")
                    + "','" + strRegion.ToString().Replace("'", "\\'")
                    + "','" + strSublease_Address_1.ToString().Replace("'", "\\'")
                    + "','" + strSublease_Address_2.ToString().Replace("'", "\\'")
                    + "','" + strSublease_City.ToString().Replace("'", "\\'")
                    + "','" + strSublease_State.ToString().Replace("'", "\\'")
                    + "','" + strSublease_Zip.ToString().Replace("'", "\\'")
                    + "','" + strBuilding_TIV.ToString().Replace("'", "\\'")
                    + "','" + strSubLeaseFirstName.ToString().Replace("'", "\\'")
                    + "','" + strSubLeaseLastName.ToString().Replace("'", "\\'")
                    + "','" + strSubLeaseTitle.ToString().Replace("'", "\\'")
                    + "','" + strSubLeasePhone.ToString().Replace("'", "\\'")
                    + "','" + strSubLeaseFax.ToString().Replace("'", "\\'")
                    + "','" + strSubLeaseEmail.ToString().Replace("'", "\\'")
                    + "','" + strPK_Building_Ownership_ID.ToString().Replace("'", "\\'")
                    + "','" + strFK_LU_Location_ID.ToString().Replace("'", "\\'")
                    + "','" + strPK_LU_Location_ID.ToString().Replace("'", "\\'")
                    + "');";

                lnkdba.Attributes.Add("onclick", strJSFunction);
                lnkBuildingNumber.Attributes.Add("onclick", strJSFunction);
                lnkAddress.Attributes.Add("onclick", strJSFunction);
                lnkLandlord_Name.Attributes.Add("onclick", strJSFunction);
                lnkSublease_Name.Attributes.Add("onclick", strJSFunction);
                lnkStatus.Attributes.Add("onclick", strJSFunction);
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }
    #endregion

}
