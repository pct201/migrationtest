using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERIMS.DAL;
using System.Data;

public partial class SONIC_Exposures_Project_Management_Add : clsBasePage
{
    #region " Properties "
    /// <summary>
    /// Denote Location ID for Environmental Project Management Data
    /// </summary>
    public int LocationID
    {
        get { return Convert.ToInt32(ViewState["loc"]); }
        set { ViewState["loc"] = value; }
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

    #region " Page Load Event "
    /// <summary>
    /// Handles Page Load Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>    
    /// 
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ViewState["PreviousPage"] = Request.UrlReferrer;//Saves the Previous page url in ViewState

            // set the default sort field and sort order
            SortBy = "E.Created_Date";
            SortOrder = "DESC";


            LocationID = Convert.ToInt32(Encryption.Decrypt(Request.QueryString["loc"].ToString()));
            BindHeaderInfo();
            BindProjectManagenentGrid(ctrlPageProjects.CurrentPage, ctrlPageProjects.PageSize);
        }
    }
    #endregion

    #region " Page Methods "
    /// <summary>
    /// Binds Header Information By Passed Location ID
    /// </summary>
    private void BindHeaderInfo()
    {
        DataTable dtLocationInfo = LU_Location.SelectByPK(LocationID).Tables[0];
        if (dtLocationInfo != null && dtLocationInfo.Rows.Count > 0)
        {
            lblLocation_Number.Text = (dtLocationInfo.Rows[0]["Sonic_Location_Code"].ToString() != "") ? dtLocationInfo.Rows[0]["Sonic_Location_Code"].ToString() : "";
            lblLocationdba.Text = (dtLocationInfo.Rows[0]["dba"].ToString() != "") ? dtLocationInfo.Rows[0]["dba"].ToString() : "";
            lblAddress.Text = (dtLocationInfo.Rows[0]["Address"].ToString() != "") ? dtLocationInfo.Rows[0]["Address"].ToString() : "";
            lblCity.Text = (dtLocationInfo.Rows[0]["City"].ToString() != "") ? dtLocationInfo.Rows[0]["City"].ToString() : "";
            lblState.Text = (dtLocationInfo.Rows[0]["StateName"].ToString() != "") ? dtLocationInfo.Rows[0]["StateName"].ToString() : "";
            lblZip.Text = (dtLocationInfo.Rows[0]["Zip_Code"].ToString() != "") ? dtLocationInfo.Rows[0]["Zip_Code"].ToString() : "";
        }
    }

    /// <summary>
    /// Bind Project Management Grid By Location ID
    /// </summary>
    /// <param name="PageNumber"></param>
    /// <param name="PageSize"></param>
    private void BindProjectManagenentGrid(int PageNumber, int PageSize)
    {
        DataSet dsProject_Management = null;
        if (Session["EnviroBuilding"] != null && Request.QueryString["Building_Id"] != null)
        {
            decimal BuildindId = Convert.ToDecimal(Session["EnviroBuilding"]);
            dsProject_Management = clsEPM_Identification.SelectByBuildingId(LocationID, BuildindId, PageNumber, PageSize, SortOrder, SortBy);
            btnBack.Visible = true;            
        }
        else
        {
            btnBack.Visible = false;
            dsProject_Management = clsEPM_Identification.SelectAll(LocationID, PageNumber, PageSize, SortOrder, SortBy);
        }
        DataTable dtProject_Management = dsProject_Management.Tables[0];
        ctrlPageProjects.TotalRecords = (dsProject_Management.Tables.Count >= 2) ? Convert.ToInt32(dsProject_Management.Tables[1].Rows[0][0]) : 0;
        ctrlPageProjects.CurrentPage = (dsProject_Management.Tables.Count >= 2) ? Convert.ToInt32(dsProject_Management.Tables[1].Rows[0][2]) : 0;
        ctrlPageProjects.RecordsToBeDisplayed = dsProject_Management.Tables[0].Rows.Count;
        ctrlPageProjects.SetPageNumbers();

        if (dsProject_Management.Tables[0] == null || dsProject_Management.Tables[0].Rows.Count == 0)
        {
            gvProjectManagement.Width = 850;
            dvSearchResult.Style["overflow-x"] = "none";
        }
        else
        {
            gvProjectManagement.Width = 1350;
            dvSearchResult.Style["overflow-x"] = "scroll";
        }

        gvProjectManagement.DataSource = dtProject_Management;
        gvProjectManagement.DataBind();


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
    /// Returns the index of the column which contains perticular sort expression
    /// </summary>
    /// <param name="strSortExp">The column on which the sorting is to be performed</param>
    /// <returns>Integer</returns>
    private int GetSortColumnIndex(string strSortExp)
    {
        int nRet = 0;
        // Iterate through the Columns collection to determine the index
        // of the column being sorted.
        foreach (DataControlField field in gvProjectManagement.Columns)
        {
            //check Sort Expression value
            if (field.SortExpression.ToString() == strSortExp)
            {
                nRet = gvProjectManagement.Columns.IndexOf(field);
            }
        }
        return nRet;
    }
    #endregion

    #region " Page Events "
    /// <summary>
    /// Handles Click Event of Add button
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkAdd_OnClick(object sender, EventArgs e)
    {
        decimal PK_EPM_Identification = 0;
        Response.Redirect("Project_Management.aspx?loc=" + Request.QueryString["loc"].ToString() + "&id=" + Encryption.Encrypt(PK_EPM_Identification.ToString()) + "&op=add", true);
    }

    /// <summary>
    /// Implement event for Paging control
    /// </summary>
    protected void GetPage()
    {
        BindProjectManagenentGrid(ctrlPageProjects.CurrentPage, ctrlPageProjects.PageSize);
    }
    #endregion

    #region " Grid Events "
    /// <summary>
    /// Hadles Row Command event for Project Management Grid
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvProjectManagement_OnRowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "ViewProjectManagement")
        {
            int rowIndex = ((GridViewRow)((LinkButton)e.CommandSource).NamingContainer).RowIndex;
            string BuildingName = ((LinkButton)gvProjectManagement.Rows[rowIndex].FindControl("lnkBuilding")).Text;
            decimal PK_EPM_Identification = 0;
            PK_EPM_Identification = Convert.ToDecimal(e.CommandArgument);
            if (!string.IsNullOrEmpty(BuildingName.ToString()))
                Session["BuildingName"] = BuildingName.Replace("</br>", ",");
            Response.Redirect("Project_Management.aspx?loc=" + Request.QueryString["loc"].ToString() + "&id=" + Encryption.Encrypt(PK_EPM_Identification.ToString()) + "&op=view", true);
        }
        else if (e.CommandName == "RemoveProjectManagement")
        {
            clsEPM_Identification.DeleteByPK(Convert.ToDecimal(e.CommandArgument));
            BindProjectManagenentGrid(ctrlPageProjects.CurrentPage, ctrlPageProjects.PageSize);
        }

    }

    /// <summary>
    /// Handles event when Grid row is created
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvProjectManagement_RowCreated(object sender, GridViewRowEventArgs e)
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
    protected void gvProjectManagement_Sorting(object sender, GridViewSortEventArgs e)
    {
        // update sort field and sort order and bind the grid
        SortOrder = (SortBy == e.SortExpression) ? (SortOrder == "asc" ? "desc" : "asc") : "asc";
        SortBy = e.SortExpression;
        BindProjectManagenentGrid(ctrlPageProjects.CurrentPage, ctrlPageProjects.PageSize);
    }
    #endregion

    protected void btnBack_Click(object sender, EventArgs e)
    {
        if (ViewState["PreviousPage"] != null)	//Check if the ViewState 
        //contains Previous page URL
        {
            Response.Redirect(ViewState["PreviousPage"].ToString());//Redirect to 
            //Previous page by retrieving the PreviousPage Url from ViewState.
        }
    }
}