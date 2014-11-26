using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RIMS_Base;
using RIMS_Base.Biz;
using ERIMS.DAL;
using System.Data;
public partial class Policy_PolicySearchResult : clsBasePage
{
    #region Variable

    RIMS_Base.Biz.CGeneral objGeneral;
    public RIMS_Base.Biz.CRolePermission m_objRightDetails;
    List<RIMS_Base.CRolePermission> lstRightDetails = null;
    DataSet dstSearch;
    RIMS_Base.Biz.CFCIPolicy objFCIPolicy;
    string strSortExp = String.Empty;
    int ret_Val;

    #endregion
    /// <summary>
    /// Page Load Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Session["PolicyId"] = null;
            if (Session["PolicySearch"] == null)
            {
                Response.Redirect("PolicySearch.aspx");
                return;
            }

            dstSearch = new DataSet();

            gvSearch.PageSize = Session["PolicyPageSize"] == null ? 10 : Convert.ToInt32(Session["PolicyPageSize"]);
            gvSearch.PageIndex = (Session["PolicyCurrentPage"] == null ? 0 : ((int)Session["PolicyCurrentPage"]));

            ViewState["SortExp"] = Session["SortExp"];
            ViewState["sortDirection"] = Session["sortDirection"];
            GeneralSorting();

            ddlPage.DataBind();
            ddlPage.SelectedValue = Session["PolicyPageSize"] == null ? "10" : Session["PolicyPageSize"].ToString();
            lblPageInfo.Text = "Page " + (Session["PolicyCurrentPage"] == null ? "1" : (((int)Session["PolicyCurrentPage"]) + 1).ToString()) + " of " + gvSearch.PageCount.ToString();
            lblNoOfRecord.Text = dstSearch.Tables[0].Rows.Count.ToString() + " Policies found.";
            dvSearchGrid.Style["display"] = "block";
            btnPrev.Enabled = false;
            btnNext.Enabled = false;
            txtPageNo.Text = (Session["PolicyCurrentPage"] == null ? 1 : ((int)Session["PolicyCurrentPage"]) + 1).ToString();

            if (Convert.ToInt32(txtPageNo.Text) >= gvSearch.PageCount)
            {
                txtPageNo.Text = gvSearch.PageCount.ToString();
                btnNext.Enabled = false;
            }
            else
            {
                btnNext.Enabled = true;
            }

            if (Convert.ToInt32(txtPageNo.Text) > 1)
            {
                btnPrev.Enabled = true;
            }
        }

    }
    /// <summary>
    /// Set User Right
    /// </summary>
    /// <returns></returns>
    protected bool SetUserRights()
    {
        try
        {
            if (Module_Access_Mode == AccessType.View_Only)
            {
                btnAddNew.Enabled = false;
            }
            else
            {
                btnAddNew.Enabled = true;
            }
            return true;
        }
        catch (Exception ex)
        {
            throw;
        }

    }
    /// <summary>
    /// Handle Back Button Click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("PolicySearch.aspx");
    }
    /// <summary>
    /// Handle Add New Button Click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnAddNew_Click(object sender, EventArgs e)
    {
        Session["PolicyId"] = null;
        Session["PolicyMode"] = "Insert";
        Response.Redirect("FCIPolicy.aspx");
    }

    #region Grid Event
    /// <summary>
    /// Bind Search Detail
    /// </summary>
    /// <returns></returns>
    protected DataSet BindSearchDetails()
    {
        dstSearch = new DataSet();
        objFCIPolicy = new RIMS_Base.Biz.CFCIPolicy();

        DataTable dtSearchCriteria = Session["PolicySearch"] as DataTable;
        DataRow drSearch = dtSearchCriteria.Rows[0];

        dstSearch = objFCIPolicy.GetPolicySearch(Convert.ToDecimal(drSearch["FK_Policy_Type"]), Convert.ToString(drSearch["Carrier"]), Convert.ToInt32(drSearch["Policy_Year"]), Convert.ToDecimal(clsSession.UserID), Convert.ToDecimal(drSearch["ProgramID"]), Convert.ToDecimal(drSearch["LocationID"]));
        return dstSearch;

    }
    /// <summary>
    /// Search Row Command Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvSearch_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName != "Sort")
        {
            decimal PK_PolicyID = Convert.ToDecimal(e.CommandArgument.ToString());
            Session["PolicyId"] = PK_PolicyID;

            if (e.CommandName == "View")
            {
                Session["PolicyPageSize"] = ddlPage.SelectedValue;
                Session["PolicyCurrentPage"] = gvSearch.PageIndex;
                Session["SortExp"] = ViewState["SortExp"];
                Session["sortDirection"] = ViewState["sortDirection"];
                Session["PolicyMode"] = "View";
                Response.Redirect("FCIPolicy.aspx", true);
            }
            else if (e.CommandName == "EditItem")
            {
                Session["PolicyPageSize"] = ddlPage.SelectedValue;
                Session["PolicyCurrentPage"] = gvSearch.PageIndex;
                Session["SortExp"] = ViewState["SortExp"];
                Session["sortDirection"] = ViewState["sortDirection"];
                Session["PolicyMode"] = "Edit";
                Response.Redirect("FCIPolicy.aspx", true);
            }
            else if (e.CommandName == "Delete Item")
            {
                DeleteProperty(PK_PolicyID);
                if (txtPageNo.Text.ToString().Trim() == string.Empty || Convert.ToInt32(txtPageNo.Text) < 1)
                {
                    gvSearch.PageIndex = 0;
                    txtPageNo.Text = "1";
                }
                else if (Convert.ToInt32(txtPageNo.Text) >= gvSearch.PageCount)
                {
                    gvSearch.PageIndex = gvSearch.PageCount;
                    txtPageNo.Text = gvSearch.PageCount.ToString();
                    btnNext.Enabled = false;
                    btnPrev.Enabled = true;
                }
                else
                {
                    gvSearch.PageIndex = Convert.ToInt32(txtPageNo.Text) - 1;
                    btnNext.Enabled = true;
                }
                lblPageInfo.Text = "Page " + txtPageNo.Text.ToString() + " of " + gvSearch.PageCount.ToString();
            }
        }
    }
    /// <summary>
    /// Delete Property 
    /// </summary>
    /// <param name="PK_PolicyID"></param>
    private void DeleteProperty(decimal PK_PolicyID)
    {
        objFCIPolicy = new RIMS_Base.Biz.CFCIPolicy();
        try
        {
            ret_Val = objFCIPolicy.DeletePolicy(PK_PolicyID);
            GeneralSorting();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    /// <summary>
    /// Grid View Row Created Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvSearch_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            if (ViewState["sortDirection"] != null)
            {
                AddSortImage(e.Row);
            }
            else
            {
                // -- Assign default image for the sorting.
                Image sortImage = new Image();
                sortImage.ImageUrl = "~/Images/up-arrow.gif";
                sortImage.AlternateText = "Descending Order";
                e.Row.Cells[3].Controls.Add(sortImage);
            }
        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            ((Button)e.Row.FindControl("btnDelete")).Attributes.Add("onclick", "javascript:return confirm('Are you sure you want to remove the selected data from eRIMS2? Once the data are removed, eRIMS2 does not have functionality to retrieve the data.');");
        }
    }
    private int GetSortColumnIndex(string strSortExp)
    {
        int nRet = 0;
        // Iterate through the Columns collection to determine the index
        // of the column being sorted.
        foreach (DataControlField field in gvSearch.Columns)
        {
            if (field.SortExpression.ToString() == ViewState["SortExp"].ToString())
            {
                nRet = gvSearch.Columns.IndexOf(field);
            }
        }
        return nRet;
    }
    private void AddSortImage(GridViewRow headerRow)
    {
        Int32 iCol = GetSortColumnIndex(strSortExp);
        if (-1 == iCol)
        {
            return;
        }
        // Create the sorting image based on the sort direction.
        Image sortImage = new Image();

        if (SortDirection.Ascending.ToString() == ViewState["sortDirection"].ToString())
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
    /// GridView Sorting Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvSearch_Sorting(object sender, GridViewSortEventArgs e)
    {
        if (ViewState["sortDirection"] == null)
            ViewState["sortDirection"] = SortDirection.Ascending;
        else
        {
            if (((SortDirection)ViewState["sortDirection"]) == SortDirection.Ascending)
                ViewState["sortDirection"] = SortDirection.Descending;
            else
                ViewState["sortDirection"] = SortDirection.Ascending;
        }
        ViewState["SortExp"] = strSortExp = e.SortExpression;

        BindSearchDetails();
        DataView dvView = new DataView();
        dvView = dstSearch.Tables[0].DefaultView;

        if (ViewState["SortExp"] != null && ViewState["sortDirection"] != null)
        {
            if (ViewState["sortDirection"].ToString() == "Descending")
                dvView.Sort = ViewState["SortExp"].ToString() + " Desc";
            if (ViewState["sortDirection"].ToString() == "Ascending")
                dvView.Sort = ViewState["SortExp"].ToString() + " Asc";
        }
        else
        {
            dvView.Sort = "Str_Policy_Type" + " Asc";
        }

        gvSearch.DataSource = dvView;
        gvSearch.DataBind();
    }
    #endregion

    #region Search Process
    /// <summary>
    /// Search Row Data bound Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvSearch_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (Module_Access_Mode == AccessType.View_Only)
            {
                ((Button)(e.Row.FindControl("btnView"))).Enabled = true;
                ((Button)(e.Row.FindControl("btnDelete"))).Enabled = false;
                ((Button)(e.Row.FindControl("btnEdit"))).Enabled = false;
            }
            else
            {
                ((Button)(e.Row.FindControl("btnView"))).Enabled = true;
                ((Button)(e.Row.FindControl("btnEdit"))).Enabled = true;
                ((Button)(e.Row.FindControl("btnDelete"))).Enabled = true;
            }
        }
    }
    /// <summary>
    /// Page Selected Index Changed Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ddlPage_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            BindSearchDetails();
            DataView dvView = new DataView();
            dvView = dstSearch.Tables[0].DefaultView;

            if (ViewState["SortExp"] != null && ViewState["sortDirection"] != null)
            {
                if (ViewState["sortDirection"].ToString() == "Descending")
                    dvView.Sort = ViewState["SortExp"].ToString() + " Desc";
                if (ViewState["sortDirection"].ToString() == "Ascending")
                    dvView.Sort = ViewState["SortExp"].ToString() + " Asc";
            }
            else
            {
                dvView.Sort = "Str_Policy_Type" + " Asc";
            }
            gvSearch.PageIndex = 0;
            gvSearch.PageSize = Convert.ToInt32(ddlPage.SelectedValue);
            gvSearch.DataSource = dvView;
            gvSearch.DataBind();

            lblPageInfo.Text = "Page 1 of " + gvSearch.PageCount.ToString();
            txtPageNo.Text = "1";
            btnPrev.Enabled = false;
            btnNext.Enabled = true;
            if ((gvSearch.PageSize >= gvSearch.Rows.Count) && gvSearch.PageCount == 1)
            {
                btnPrev.Enabled = false;
                btnNext.Enabled = false;
            }           
            dvSearchGrid.Style["display"] = "block";
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    /// <summary>
    /// Go Button Click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnGo_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtPageNo.Text.ToString().Trim() == string.Empty || Convert.ToInt32(txtPageNo.Text) < 1)
            {
                gvSearch.PageIndex = 0;
                txtPageNo.Text = "1";
            }
            else if (Convert.ToInt32(txtPageNo.Text) >= gvSearch.PageCount)
            {
                gvSearch.PageIndex = gvSearch.PageCount;
                txtPageNo.Text = gvSearch.PageCount.ToString();
                btnNext.Enabled = false;
                btnPrev.Enabled = true;
            }
            else
            {
                gvSearch.PageIndex = Convert.ToInt32(txtPageNo.Text) - 1;

                btnNext.Enabled = true;
            }
            lblPageInfo.Text = "Page " + txtPageNo.Text.ToString() + " of " + gvSearch.PageCount.ToString();
            BindSearchDetails();
            DataView dvView = new DataView();
            dvView = dstSearch.Tables[0].DefaultView;

            if (ViewState["SortExp"] != null && ViewState["sortDirection"] != null)
            {
                if (ViewState["sortDirection"].ToString() == "Descending")
                    dvView.Sort = ViewState["SortExp"].ToString() + " Desc";
                if (ViewState["sortDirection"].ToString() == "Ascending")
                    dvView.Sort = ViewState["SortExp"].ToString() + " Asc";
            }
            else
            {
                dvView.Sort = "Str_Policy_Type" + " Asc";
            }

            gvSearch.DataSource = dvView;
            gvSearch.DataBind();

            dvSearchGrid.Style["display"] = "block";
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }
    /// <summary>
    /// Handle Previous Button Click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnPrev_Click(object sender, EventArgs e)
    {
        try
        {
            if (gvSearch.PageIndex <= gvSearch.PageCount)
            {
                gvSearch.PageIndex = gvSearch.PageIndex - 1;
                GeneralSorting();
                if (gvSearch.PageIndex == 0)
                {
                    btnPrev.Enabled = false;
                    btnNext.Enabled = true;
                }
                else
                {
                    btnNext.Enabled = true;
                }               
                lblPageInfo.Text = "Page " + Convert.ToString(gvSearch.PageIndex + 1) + " of " + gvSearch.PageCount.ToString();
                txtPageNo.Text = Convert.ToString(gvSearch.PageIndex + 1);
            }
            dvSearchGrid.Style["display"] = "block";
        }
        catch (Exception ex)
        {
        }
    }
    /// <summary>
    /// Handle Next Button Click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnNext_Click(object sender, EventArgs e)
    {
        try
        {
            if (gvSearch.PageIndex <= gvSearch.PageCount)
            {
                gvSearch.PageIndex = gvSearch.PageIndex + 1;
                if (gvSearch.PageIndex + 1 >= gvSearch.PageCount)
                {
                    btnNext.Enabled = false;
                    btnPrev.Enabled = true;
                }
                else
                {
                    btnNext.Enabled = true;
                    btnPrev.Enabled = true;
                }
                GeneralSorting();

                lblPageInfo.Text = "Page " + Convert.ToString(gvSearch.PageIndex + 1) + " of " + gvSearch.PageCount.ToString();

            }
            txtPageNo.Text = Convert.ToString(gvSearch.PageIndex + 1);
            dvSearchGrid.Style["display"] = "block";

        }
        catch (Exception ex)
        {
        }
    }
    /// <summary>
    /// General Sorting
    /// </summary>
    private void GeneralSorting()
    {
        try
        {
            BindSearchDetails();
            DataView dvView = new DataView();
            dvView = dstSearch.Tables[0].DefaultView;

            if (ViewState["SortExp"] != null && ViewState["sortDirection"] != null)
            {
                if (ViewState["sortDirection"].ToString() == "Descending")
                    dvView.Sort = ViewState["SortExp"].ToString() + " Desc";
                if (ViewState["sortDirection"].ToString() == "Ascending")
                    dvView.Sort = ViewState["SortExp"].ToString() + " Asc";
            }
            else
            {
                dvView.Sort = "Str_Policy_Type" + " Asc";
            }

            gvSearch.DataSource = dvView;
            gvSearch.DataBind();

        }
        catch (Exception ex)
        {
            throw ex;
        }


    }

    #endregion
}
