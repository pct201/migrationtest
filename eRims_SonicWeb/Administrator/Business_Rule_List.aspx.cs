using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Text;
using ERIMS.DAL;

public partial class Administrator_Business_Rule_List : clsBasePage
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

    private bool _IsCriteria
    {
        get { return (!clsGeneral.IsNull(ViewState["IsCriteria"]) ? Convert.ToBoolean(ViewState["IsCriteria"]) : false); }
        set { ViewState["IsCriteria"] = value; }
    }

    #endregion

    #region "Page Events"

    /// <summary>
    /// Page Load Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindDropDownList();
            //btnAdd.Visible = (App_Access != AccessType.View);
            //btnAddNew.Visible = (App_Access != AccessType.View);
            //ctrlPageProperty.PageSize = clsSession.NumberOfSearchRows;
            _SortBy = "Rule_Name";
            _SortOrder = "asc";            
        }      
    }

    #endregion

    #region "Events"

    protected void drpModule_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (drpModule.SelectedIndex > 0)
        {
            decimal PK_Module = Convert.ToDecimal(drpModule.SelectedValue);
            clsBusiness_Rules_Screens objBusiness_Rules_Screens = new clsBusiness_Rules_Screens();
            DataSet ds = objBusiness_Rules_Screens.SelectByFK(PK_Module);
            drpScreen.DataSource = ds.Tables[0];
            drpScreen.DataTextField = "Screen";
            drpScreen.DataValueField = "PK_Business_Rules_Screens";
            drpScreen.DataBind();
            drpScreen.Items.Insert(0, new ListItem("-- Select --", "0"));
        }
        else
        {
            drpScreen.Items.Clear();
            drpScreen.Items.Insert(0, new ListItem("-- Select --", "0"));                        
        }
    }

    /// <summary>
    /// Handles Search button click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        _IsCriteria = false;
        //Set Groupby , sortby and Number of records value
        _SortBy = "Rule_Name";
        _SortOrder = "asc";
        //ctrlPageProperty.PageSize = 10;

        BindGrid(1, ctrlPageProperty.PageSize);
        pnlSearchFilter.Visible = false;
        pnlSearchResult.Visible = true;
        ctrlPageProperty.FindControl("drpRecords").Focus();
    }

    /// <summary>
    /// Handle Add new Policy Click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Response.Redirect("Business_Rule_Management.aspx", true);
    }

    /// <summary>
    /// Handles Search Again button click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSearchAgain_Click(object sender, EventArgs e)
    {
        drpModule.SelectedIndex = 0;
        drpScreen.Items.Clear();
        drpScreen.Items.Insert(0, new ListItem("-- Select --", "0"));
        drpAction_Type.SelectedIndex = 0;
        txtRuleName.Text = string.Empty;
        _IsCriteria = false;
       

        // show search filter panel
        pnlSearchResult.Visible = false;
        pnlSearchFilter.Visible = true;

        // Check User Rights
        btnAdd.Visible = App_Access == AccessType.Administrative_Access;
        btnAddNew.Visible = App_Access == AccessType.Administrative_Access;
        
    }

    #endregion

    #region "Methods"

    /// <summary>
    /// Method to fill dropdown list from lookup tables
    /// </summary>
    private void BindDropDownList()
    {
        ComboHelper.FillBusinessRulesModules(new DropDownList[] { drpModule }, true);
        drpScreen.Items.Clear();
        drpScreen.Items.Insert(0, new ListItem("-- Select --", "0"));
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
        int nRet = 1;
        // Iterate through the Columns collection to determine the index
        // of the column being sorted.
        foreach (DataControlField field in  gvBusinessRule.Columns)
        {
            if (field.SortExpression.ToString() == strSortExp)
            {
                nRet = gvBusinessRule.Columns.IndexOf(field);
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
    /// Binds the grid by page number and page size
    /// </summary>
    /// <param name="PageNumber">Current page number</param>
    /// <param name="PageSize">Number of records to be displayed on a page</param>
    private void BindGrid(int PageNumber, int PageSize)
    {

        // selects records depending on paging criteria and search values.
        DataSet dsBusinessRule = clsBusiness_Rules.BusinessRuleSearch( Convert.ToDecimal(drpModule.SelectedValue),Convert.ToDecimal(drpScreen.SelectedValue),txtRuleName.Text.Trim(),drpAction_Type.SelectedValue, _SortBy, _SortOrder, PageNumber, PageSize);
        DataTable dtAutoClaim = dsBusinessRule.Tables[0];

        // set values for paging control,so it shows values as needed.
        ctrlPageProperty.TotalRecords = (dsBusinessRule.Tables.Count >= 2) ? Convert.ToInt32(dsBusinessRule.Tables[1].Rows[0][0]) : 0;
        ctrlPageProperty.CurrentPage = (dsBusinessRule.Tables.Count >= 2) ? Convert.ToInt32(dsBusinessRule.Tables[1].Rows[0][2]) : 0;
        ctrlPageProperty.RecordsToBeDisplayed = dsBusinessRule.Tables[0].Rows.Count;
        ctrlPageProperty.SetPageNumbers();

        ////if (dsBusinessRule.Tables[0] == null || dsBusinessRule.Tables[0].Rows.Count == 0)
        ////{
        ////    gvBusinessRule.Width = 990;
            
        ////    dvSearchResult.Style["overflow-x"] = "none";
        ////}
        ////else
        ////{

        ////    gvBusinessRule.Width = 3000;
        ////    dvSearchResult.Style["overflow-x"] = "scroll";
        ////}


        // bind the grid.
        gvBusinessRule.DataSource = dtAutoClaim;
        gvBusinessRule.DataBind();

        // set record numbers retrieved
        lblNumber.Text = (dsBusinessRule.Tables.Count >= 2) ? Convert.ToString(dsBusinessRule.Tables[1].Rows[0][0]) : "0";

        

    }

    /// <summary>
    /// This method is added for export Girdview To Excel which contains SubGridview.
    /// </summary>
    /// <param name="control"></param>
    public override void VerifyRenderingInServerForm(Control control)
    {

    }    

    #endregion

    #region "Grid Events"

    /// <summary>
    /// Handles event when row is created for auto Claim grid
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvBusinessRule_RowCreated(object sender, GridViewRowEventArgs e)
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

    /// <summary>
    /// Handles event when row header link is clicked for sorting
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvBusinessRule_Sorting(object sender, GridViewSortEventArgs e)
    {
        // update sort field and sort order and bind the grid
        _SortOrder = (_SortBy == e.SortExpression) ? (_SortOrder == "asc" ? "desc" : "asc") : "asc";
        _SortBy = e.SortExpression;
        GetPage();
    }

    /// <summary>
    /// Handles event when links are clicked in the grid
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvBusinessRule_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DeleteRule")
        {
            decimal PK_Rule_ID = Convert.ToDecimal(e.CommandArgument);
            clsBusiness_Rules.DeleteByPK(PK_Rule_ID);
            //clsBusiness_Rule_Filter.DeleteByFK(PK_Rule_ID);
            BindGrid(ctrlPageProperty.CurrentPage, ctrlPageProperty.PageSize);
        }
        else if (e.CommandName == "Edit")
        {
            decimal PK_Rule_ID = Convert.ToDecimal(e.CommandArgument);
            ///When Edit Record in User then Insert in claim_Edit Table Record and Claim is locked            
            Response.Redirect("Business_Rule_Management.aspx?id=" + Encryption.Encrypt(PK_Rule_ID.ToString()) + "&mode=edit", true);
        }              
    }

    /// <summary>
    /// Handle gvAutoClaim Row Data Bound events
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvBusinessRule_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{
        //    //Set Button Visible\Hide by Access 
        //    ((LinkButton)e.Row.Cells[0].FindControl("btnEdit")).Visible = (App_Access != AccessType.View);
        //    ((LinkButton)e.Row.Cells[0].FindControl("btnDelete")).Visible = (App_Access == AccessType.Delete || App_Access == AccessType.Administrative_Access);
        //}
    }

    

    #endregion
    
}
