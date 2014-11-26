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
using System.Collections.Generic;
using ERIMS.DAL;
public partial class Admin_RiskProfileList : clsBasePage
{
    #region "varables"

    string strSortExp = string.Empty;
    #endregion

    # region " Page Events "
    /// <summary>
    /// Page Load Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (App_Access == AccessType.NotAssigned)
                Response.Redirect(AppConfig.SiteURL + "Message.aspx?msg=You are not authorized to access this page");
            else
            {
                SortOrder = "asc";
                SortBy = "Name";
                BindGrid(1, 10);
            }
            if (App_Access == AccessType.NotAssigned || App_Access == AccessType.View_Only)
                btnAddNew.Visible = false;
        }
    }

    # endregion

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

    #endregion

    # region " Private Methods "

    /// <summary>
    /// Binds the grid by page number and page size
    /// </summary>
    /// <param name="PageNumber"></param>
    /// <param name="PageSize"></param>
    private void BindGrid(int PageNumber, int PageSize)
    {
        // selects records depending on paging criteria.
        DataSet dsProfile = COI_Risk_Profiles.SelectByPaging(PageNumber, PageSize, SortBy, SortOrder);
        DataTable dtProfile = dsProfile.Tables[0];

        // set values for paging control,so it shows values as needed.
        ctrlPageProfile.TotalRecords = Convert.ToInt32(dsProfile.Tables[1].Rows[0][0]);
        ctrlPageProfile.CurrentPage = Convert.ToInt32(dsProfile.Tables[1].Rows[0][2]);
        ctrlPageProfile.RecordsToBeDisplayed = dtProfile.Rows.Count;
        ctrlPageProfile.SetPageNumbers();
        // bind the grid.
        gvProfiles.DataSource = dtProfile;
        gvProfiles.DataBind();

        // set record numbers retrieved
        lblNumber.Text = ctrlPageProfile.TotalRecords.ToString();
        ctrlPageProfile.FindControl("drpRecords").Focus();
    }

    # endregion

    # region " Control Events "
    /// <summary>
    /// GridView Row Data Command Event handles in Edit and View Mode
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvProfiles_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        if (e.CommandName == "ViewProfile")
        {// get the current profile id.
            int ProfileID = Convert.ToInt32(e.CommandArgument);
            // show riskprofile in view mode
            Response.Redirect("RiskProfileAddEdit.aspx?op=view&id=" + Encryption.Encrypt(ProfileID.ToString()));
        }
        else if (e.CommandName == "EditProfile")
        {
            // get the current profile id.
            int ProfileID = Convert.ToInt32(e.CommandArgument);
            // show risk profile in edit mode.
            Response.Redirect("RiskProfileAddEdit.aspx?op=edit&id=" + Encryption.Encrypt(ProfileID.ToString()));
        }
        else if (e.CommandName == "DeleteProfile")
        {
            COI_Risk_Profiles.Delete(Convert.ToDecimal(e.CommandArgument));
            BindGrid(ctrlPageProfile.CurrentPage, ctrlPageProfile.PageSize);
        }
    }
    /// <summary>
    /// GridView Row Data Bound Event 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvProfiles_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Button dvEdit = (Button)e.Row.FindControl("lnkEdit");
            if (App_Access == AccessType.View_Only || App_Access == AccessType.View_Only)
                dvEdit.Visible = false;
            else dvEdit.Visible = true;
        }
    }
    /// <summary>
    /// Handles Add New Button Click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnAddNew_Click(object sender, EventArgs e)
    {
        // open page in add mode for risk profile.
        Response.Redirect("RiskProfileAddEdit.aspx?op=edit");
    }

    // event for page controls go button.
    protected void GetPage()
    {
        BindGrid(ctrlPageProfile.CurrentPage, ctrlPageProfile.PageSize);
    }
    /// <summary>
    /// Handles GridView Sorting Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvProfiles_Sorting(object sender, GridViewSortEventArgs e)
    {
        SortOrder = (SortBy == e.SortExpression) ? (SortOrder == "asc" ? "desc" : "asc") : "asc";
        SortBy = e.SortExpression;
        BindGrid(ctrlPageProfile.CurrentPage, ctrlPageProfile.PageSize);
    }
    /// <summary>
    /// Handles Row Created Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvProfiles_RowCreated(object sender, GridViewRowEventArgs e)
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
        foreach (DataControlField field in gvProfiles.Columns)
        {

            if (field.SortExpression.ToString() == strSortExp.ToString())
            {
                nRet = gvProfiles.Columns.IndexOf(field);
            }
        }
        return nRet;
    }

    #endregion
}
