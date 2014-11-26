using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ERIMS.DAL;

public partial class SONIC_Pollution_BuildingList : clsBasePage
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

    /// <summary>
    /// Denotes foriegn key for Location record
    /// </summary>
    public int FK_LU_Location_ID
    {
        get { return Convert.ToInt32(ViewState["FK_LU_Location_ID"]); }
        set { ViewState["FK_LU_Location_ID"] = value; }
    }

    #endregion

    #region "Events"
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Session["EnviroBuilding"] = null;
            SortOrder = "Asc";
            SortBy = "Building_Occupacy";

            // check if location id is passed in querystring or not
            if (Request.QueryString["loc"] != null)
            {
                int loc;
                if (int.TryParse(Encryption.Decrypt(Request.QueryString["loc"]), out loc))
                    FK_LU_Location_ID = loc;
            }

            // Bind location information
            if (FK_LU_Location_ID > 0)
            {
                BindGrid(1, 10);
                // store the location id in session
                Session["ExposureLocation"] = FK_LU_Location_ID;
            }
            else
                Response.Redirect("../Exposures/ExposureSearch.aspx");
        }
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("../Exposures/ExposureSearchResult.aspx");
    }

    #endregion
    
    #region "Methods"

    /// <summary>
    /// Search and Bind Grid for Customer Incident Type
    /// </summary>
    private void BindGrid(int PageNumber, int PageSize)
    {
        DataSet dsSearchResult = Building.SelectByPaging(FK_LU_Location_ID, SortBy, SortOrder, PageNumber, PageSize);
        gvBuilding.DataSource = dsSearchResult.Tables[0];
        gvBuilding.DataBind();

        //// set values for paging control,so it shows values as needed.
        ctrlPageIncident.TotalRecords = (dsSearchResult.Tables.Count >= 2) ? Convert.ToInt32(dsSearchResult.Tables[1].Rows[0][0]) : 0;
        ctrlPageIncident.CurrentPage = (dsSearchResult.Tables.Count >= 2) ? Convert.ToInt32(dsSearchResult.Tables[1].Rows[0][2]) : 0;
        ctrlPageIncident.RecordsToBeDisplayed = dsSearchResult.Tables[0].Rows.Count;
        ctrlPageIncident.SetPageNumbers();

        // set record numbers retrieved
        lblNumber.Text = ((dsSearchResult.Tables.Count >= 2) ? Convert.ToString(dsSearchResult.Tables[1].Rows[0][0]) : "0");
    }


    // event for page controls go button.
    protected void GetPage()
    {
        BindGrid(ctrlPageIncident.CurrentPage, ctrlPageIncident.PageSize);
    }

    /// <summary>
    /// Add in Column Sort Image
    /// </summary>
    /// <param name="headerRow"></param>
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

    //Set Sort Column Image set
    private int GetSortColumnIndex(object strSortExp)
    {
        int nRet = 0;
        // Iterate through the Columns collection to determine the index
        // of the column being sorted.
        foreach (DataControlField field in gvBuilding.Columns)
        {

            if (field.SortExpression.ToString() == strSortExp.ToString())
            {
                nRet = gvBuilding.Columns.IndexOf(field);
            }
        }
        return nRet;
    }
    #endregion

    # region " Grid Events "
    /// <summary>
    /// GridView Row Data Command Event handles in Edit and View Mode
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvBuilding_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "ViewDetails")
        {
            string[] strArgs = e.CommandArgument.ToString().Split(':');
            Session["EnviroBuilding"] = strArgs[0];
            Response.Redirect("Pollution.aspx?op=view&id=" + Encryption.Encrypt(strArgs[1]) + "&loc=" + Request.QueryString["loc"], true);
        }
        else if (e.CommandName == "EditDetails")
        {
            string[] strArgs = e.CommandArgument.ToString().Split(':');
            Session["EnviroBuilding"] = strArgs[0];
            Response.Redirect("Pollution.aspx?op=edit&id=" + Encryption.Encrypt(strArgs[1]) + "&loc=" + Request.QueryString["loc"], true);
        }
        else if (e.CommandName == "AddDetails")
        {
            Session["EnviroBuilding"] = e.CommandArgument.ToString();

            // make entry in PM_Building_Edit to keep track of building
            clsPM_Building_Edit objEdit = new clsPM_Building_Edit();
            objEdit.FK_Building = Convert.ToDecimal(e.CommandArgument.ToString());
            objEdit.FK_Security_ID = Convert.ToDecimal(clsSession.UserID);
            objEdit.Insert();
            Response.Redirect("Pollution.aspx?build=" + Encryption.Encrypt(e.CommandArgument.ToString()) + "&loc=" + Request.QueryString["loc"], true);
        }
    }

    /// <summary>
    /// GridView Row Data Bound Event 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvBuilding_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton lnkEdit = (LinkButton)e.Row.FindControl("lnkEdit");
            LinkButton lnkAdd = (LinkButton)e.Row.FindControl("lnkAdd");
            LinkButton lnkView = (LinkButton)e.Row.FindControl("lnkView");
            lnkEdit.Visible = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "PK_PM_Site_Information")) > 0 && (App_Access != AccessType.View_Only);
            lnkAdd.Visible = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "PK_PM_Site_Information")) == 0 && (App_Access != AccessType.View_Only);
            lnkView.Visible = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "PK_PM_Site_Information")) > 0;
        }
    }


    /// <summary>
    /// Handles GridView Sorting Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvBuilding_Sorting(object sender, GridViewSortEventArgs e)
    {
        SortOrder = (SortBy == e.SortExpression) ? (SortOrder == "asc" ? "desc" : "asc") : "asc";
        SortBy = e.SortExpression;
        BindGrid(ctrlPageIncident.CurrentPage, ctrlPageIncident.PageSize);
    }
    /// <summary>
    /// Handles Row Created Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvBuilding_RowCreated(object sender, GridViewRowEventArgs e)
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

    #endregion
}