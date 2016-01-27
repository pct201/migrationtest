using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ERIMS.DAL;

public partial class Administrator_WallSearchByLocation : clsBasePage
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

    private bool IsUserInAdministrativeGroup
    {
        get { if (ViewState["UserGroup"] != null)return Convert.ToBoolean(ViewState["UserGroup"]); else return false; }
        set { ViewState["UserGroup"] = value; }
    }

    private bool IsUserRLCM
    {
        get { if (ViewState["IsUserRLCM"] != null)return Convert.ToBoolean(ViewState["IsUserRLCM"]); else return false; }
        set { ViewState["IsUserRLCM"] = value; }
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
            BindDropdowns();
            DataSet dtTemp = Security.SelectGroupByUserID(Convert.ToDecimal(clsSession.UserID));
            if (dtTemp != null && dtTemp.Tables.Count > 0)
            {
                if (dtTemp.Tables[0].Rows.Count > 0)
                {
                    DataRow[] drTmpRows = dtTemp.Tables[0].Select(" Group_Name = 'Administrative' ");
                    if (drTmpRows.Length > 0)
                        IsUserInAdministrativeGroup = true;
                    else
                        IsUserInAdministrativeGroup = false;
                }

                if (dtTemp.Tables[1].Rows.Count > 0)//if RLCM user #Issue 3439 Pt. 5
                    IsUserRLCM = true;
                else
                    IsUserRLCM = false;
            }

            if (IsUserInAdministrativeGroup || IsUserRLCM)
                btnDelete.Visible = true;
            else
            {
                btnDelete.Visible = false;
                Response.Redirect(AppConfig.SiteURL + "Error.aspx?msg=errAcc");
            }

            //btnDelete.Attributes.Add("onclick", "return ConfirmDelete('chkItem');");
            SortBy = "Update_Date";
            SortOrder = "asc";
            BindPosts(1, 10);
        }
    }

    #endregion

    #region "Methods"

    /// <summary>
    /// Implement event for Paging control when clicking on Go button
    /// </summary>
    protected void GetPage()
    {
        BindPosts(ctrlPageWallPost.CurrentPage, ctrlPageWallPost.PageSize);
    }

    /// <summary>
    /// Bind Wall Main Post
    /// </summary>
    /// <param name="PageNumber"></param>
    /// <param name="PageSize"></param>
    private void BindPosts(int PageNumber, int PageSize)
    {
        string strLastName = Convert.ToString(txtPosterLastName.Text.Trim().Replace("'", "''"));
        string strFirstName = Convert.ToString(txtPosterFirstName.Text.Trim().Replace("'", "''"));
        DateTime? dtPostDateFrom = clsGeneral.FormatNullDateToStore(txtDatePostFrom.Text);
        DateTime? dtPostDateTo = clsGeneral.FormatNullDateToStore(txtDatePostTo.Text);

        string strPostDateFrom = Convert.ToString(txtDatePostFrom.Text);
        string strPostDateTo = Convert.ToString(txtDatePostTo.Text);

        string strPostText = Convert.ToString(txtPostText.Text.Trim().Replace("'", "''"));
        string strTopic = Convert.ToString(txtTopic.Text.Trim()).Replace("'", "''");
        string strFilter_By_Region = string.Empty, strFilter_By_Market = string.Empty;

        strFilter_By_Region = ddlRegion.SelectedIndex > 0 ? ddlRegion.SelectedValue : string.Empty;
        strFilter_By_Market = ddlMarket.SelectedIndex > 0 ? ddlMarket.SelectedValue : string.Empty;

        DataSet dsPosts = clsWall_By_Location.SearchWallPostsByLocationAdmin(PageNumber, PageSize, strLastName, strFirstName, strPostDateFrom, strPostDateTo, strPostText, strTopic,
             strFilter_By_Region, strFilter_By_Market, SortBy, SortOrder);

        //// set values for paging control,so it shows values as needed.
        ctrlPageWallPost.TotalRecords = (dsPosts.Tables.Count >= 3) ? Convert.ToInt32(dsPosts.Tables[1].Rows[0][0]) : 0;
        ctrlPageWallPost.CurrentPage = (dsPosts.Tables.Count >= 3) ? Convert.ToInt32(dsPosts.Tables[2].Rows[0][2]) : 0;
        ctrlPageWallPost.RecordsToBeDisplayed = dsPosts.Tables[0].Rows.Count;
        ctrlPageWallPost.SetPageNumbers();

        gvWallSearch.DataSource = dsPosts.Tables[0];
        gvWallSearch.DataBind();

        btnDelete.Visible = (dsPosts.Tables[0].Rows.Count > 0);
        

        // set record numbers retrieved
        lblNumber.Text = (dsPosts.Tables.Count >= 3) ? Convert.ToString(dsPosts.Tables[1].Rows[0][0]) : "0";
    }

    /// <summary>
    /// Bind Region and Market dorpdowns
    /// </summary>
    private void BindDropdowns()
    {
        ddlRegion.DataSource = LU_Location.GetRegionListByUser(Convert.ToDecimal(clsSession.UserID)).Tables[0];
        ddlRegion.DataTextField = "region";
        ddlRegion.DataValueField = "region";
        ddlRegion.DataBind();
        ddlRegion.Items.Insert(0, new ListItem("--All Regions--", ""));

        ComboHelper.FillMarket(new DropDownList[] { ddlMarket }, true);
    } 

    /// <summary>
    /// Add in Column Sort Image
    /// </summary>
    /// <param name="headerRow"></param>
    private void AddSortImage(GridViewRow headerRow)
    {

        Int32 intCol = GetSortColumnIndex(SortBy);
        if (intCol == -1)
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
        headerRow.Cells[intCol].Controls.Add(sortImage);
    }

    //Set Sort Column Image set
    private int GetSortColumnIndex(object strSortExp)
    {
        int intRet = 0;
        // Iterate through the Columns collection to determine the index
        // of the column being sorted.
        foreach (DataControlField field in gvWallSearch.Columns)
        {

            if (field.SortExpression.ToString() == strSortExp.ToString())
            {
                intRet = gvWallSearch.Columns.IndexOf(field);
            }
        }
        return intRet;
    }

    #endregion

    #region "Control Events"

    /// <summary>
    /// Button Search Click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        dvSearch.Visible = false;
        dvSearchResult.Visible = true;

        BindPosts(ctrlPageWallPost.CurrentPage, ctrlPageWallPost.PageSize);
    }

    /// <summary>
    /// Button Search result click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSearchAgain_Click(object sender, EventArgs e)
    {
        dvSearch.Visible = true;
        dvSearchResult.Visible = false;

        txtDatePostFrom.Text = txtDatePostTo.Text = txtPosterFirstName.Text = txtPosterLastName.Text = txtPostText.Text = txtTopic.Text = "";
        ddlRegion.ClearSelection();
        ddlMarket.ClearSelection();
    }

    /// <summary>
    /// Button Cancel Click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("../SONIC/SLT/SLT_Wall.aspx", true);
    }

    /// <summary>
    /// Button Delete Click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            string strSelected = Request.Form["chkItem"].ToString();
            if (strSelected.Length > 0)
            {
                DataTable dtAttachment = clsWall_By_Location.DeleteByPKs(strSelected).Tables[0];

                if (dtAttachment != null && dtAttachment.Rows.Count > 0)
                {
                    for (int inti = 0; inti < dtAttachment.Rows.Count; inti++)
                    {
                        string strFileName = Convert.ToString(dtAttachment.Rows[inti]["Stored_File_Name"]);

                        if (strFileName.Trim() != "")
                        {
                            string strUploadPath = clsGeneral.GetAttachmentDocPath("Main_Wall_Attachment");
                            string DocPath = string.Concat(strUploadPath, "\\");


                            string strOriginalFile = DocPath + strFileName;

                            if (System.IO.File.Exists(strOriginalFile))
                                System.IO.File.Delete(strOriginalFile);

                            if (strFileName.ToLower().EndsWith(".jpg") || strFileName.ToLower().EndsWith(".jpeg") || strFileName.ToLower().EndsWith(".gif") ||
                            strFileName.ToLower().EndsWith(".png") || strFileName.ToLower().EndsWith(".tif") || strFileName.ToLower().EndsWith(".tiff"))
                            {
                                string strThumbnailName = strFileName.Substring(0, strFileName.LastIndexOf(".") - 1) + "_Thumb";
                                string strExtenstion = strFileName.Substring(strFileName.LastIndexOf("."));
                                string strNewFile = DocPath + strThumbnailName + strExtenstion;

                                if (System.IO.File.Exists(strNewFile))
                                    System.IO.File.Delete(strNewFile);
                            }
                        }
                    }
                }
            }
        }
        catch { }
        //Bind Grid
        BindPosts(ctrlPageWallPost.CurrentPage, ctrlPageWallPost.PageSize);
    }

    #endregion

    #region "Grid Events"

    /// <summary>
    /// Grid view Row Command Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvWallSearch_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        //redirect for edit record
        if (e.CommandName.ToString() == "EditWall")
        {
            Response.Redirect("EditWallPostByLocation.aspx?id=" + Encryption.Encrypt(Convert.ToString(e.CommandArgument)), true);
        }
    }

    /// <summary>
    /// Grid View Sorting Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvWallSearch_Sorting(object sender, GridViewSortEventArgs e)
    {
        SortOrder = (SortBy == e.SortExpression) ? (SortOrder == "asc" ? "desc" : "asc") : "asc";
        SortBy = e.SortExpression;
        BindPosts(ctrlPageWallPost.CurrentPage, ctrlPageWallPost.PageSize);
    }

    /// <summary>
    /// Grid View Row Created Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvWallSearch_RowCreated(object sender, GridViewRowEventArgs e)
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

    protected void gvWallSearch_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (IsUserInAdministrativeGroup || UserAccessType == AccessType.Administrative_Access || IsUserRLCM)
                e.Row.Cells[gvWallSearch.Columns.Count - 1].Visible = true;
            else
                e.Row.Cells[gvWallSearch.Columns.Count - 1].Visible = false;
        }
        else if (e.Row.RowType == DataControlRowType.Header)
        {
            if (IsUserInAdministrativeGroup || UserAccessType == AccessType.Administrative_Access || IsUserRLCM)
                e.Row.Cells[gvWallSearch.Columns.Count - 1].Visible = true;
            else
                e.Row.Cells[gvWallSearch.Columns.Count - 1].Visible = false;
        }
    }
    #endregion
   
}