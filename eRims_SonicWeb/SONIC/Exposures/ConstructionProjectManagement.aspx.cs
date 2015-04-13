using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERIMS.DAL;
using System.Data;

public partial class SONIC_Exposures_ConstructionProjectManagement : clsBasePage
{
    #region "Properties"
    /// <summary>
    /// Denotes Location ID to be used as FK
    /// </summary>
    private int FK_Location
    {
        get { return Convert.ToInt32(ViewState["FK_Location"]); }
        set { ViewState["FK_Location"] = value; }
    }

    /// <summary>
    /// Denotes operation for page in either in view or edit mode
    /// </summary>
    public string strOperation
    {
        get { return ViewState["strOperation"].ToString(); }
        set { ViewState["strOperation"] = value; }
    }

    public string strConstructionProjectSortBy
    {
        get 
        {
            if (ViewState["strConstructionProjectSortBy"] != null)
            {
                return Convert.ToString(ViewState["strConstructionProjectSortBy"]); 
            }
            else
            {
                return "Project_Number";
            }
        }
        set { ViewState["strConstructionProjectSortBy"] = value; }
    }

    public string strConstructionProjectSortOrder
    {
        get 
        {
            if (ViewState["strConstructionProjectSortOrder"] != null)
            {
                return Convert.ToString(ViewState["strConstructionProjectSortOrder"]);
            }
            else
            {
                return "asc";
            }
        }
        set { ViewState["strConstructionProjectSortOrder"] = value; }
    }

    public bool HasEditRights
    {
        get
        {
            if (ViewState["HasEditRights"] != null)
            {
                return Convert.ToBoolean(ViewState["HasEditRights"]);
            }
            else
            {
                return false;
            }
        }
        set { ViewState["HasEditRights"] = value; }
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
        // Set Tab selection
        Tab.SetSelectedTab(Controls_ExposuresTab_ExposuresTab.Tab.Construction);
        //used to check Page Post Back Event
        if (!IsPostBack)
        {
            HasEditRights = false;
            // check for the location id is passed in querystring

            if (Request.QueryString["loc"] != null)
            {
                int loc;
                if (int.TryParse(Encryption.Decrypt(Request.QueryString["loc"]), out loc))
                {
                    FK_Location = loc;
                    aAddProject.HRef = "ConstructionProjectsView.aspx?loc=" + Request.QueryString["loc"];
                    Session["ExposureLocation"] = loc;
                }
                else
                    Response.Redirect("../Exposures/ExposureSearch.aspx");

                // store the location id in session
                Session["ExposureLocation"] = FK_Location;

                // set opertation for page
                strOperation = (Request.QueryString["op"] != null) ? Convert.ToString(Request.QueryString["op"]) : "view";

                ucCtrlExposureInfo.PK_LU_Location = FK_Location;
                ucCtrlExposureInfo.BindExposureInfo();
                //setControls();

                if (Session["IsEditable"] != null)
                {
                    aAddProject.Visible = true;
                    HasEditRights = true;
                    BindGrid();
                    btnEdit.Visible = false;
                    btnCancel.Visible = true;
                }
                else
                {
                    aAddProject.Visible = false;
                    HasEditRights = false;
                    BindGrid();
                    btnEdit.Visible = true;
                    btnCancel.Visible = false;
                }
            }
            else
                Response.Redirect("../Exposures/ExposureSearch.aspx");
        }
    }

    #endregion

    #region "Methods"

    ///// <summary>
    ///// Method set controls
    ///// </summary>
    //private void setControls()
    //{
    //    if (strOperation.ToLower().Trim() == "view")
    //    {
    //        gvProjectList.Columns[4].Visible = false;
    //    }
    //    else
    //    {
    //        if (App_Access != AccessType.Franchise_AddEdit)
    //            Response.Redirect(AppConfig.SiteURL + "Error.aspx?msg=errAcc");

    //        gvProjectList.Columns[4].Visible = true;
    //    }
    //}

    /// <summary>
    /// Bind Franchise Records in grid
    /// </summary>
    private void BindGrid()
    {
        DataTable dtProjectList = Facility_Construction_Project.SelectConstructionProjectsByLoction(FK_Location).Tables[0];
        dtProjectList.DefaultView.Sort = strConstructionProjectSortBy + " " + strConstructionProjectSortOrder;
        gvProjectList.DataSource = dtProjectList;
        gvProjectList.DataBind();

        if (HasEditRights)
        {
            gvProjectList.Columns[5].Visible = true;
        }
        else
        {
            gvProjectList.Columns[5].Visible = false;
        }
    }

    #endregion

    #region "Grid Events"

    /// <summary>
    /// GridView page index changing Event
    /// </summary>
    /// <param name="sender">Sender Object</param>
    /// <param name="e">GridView Event Argument</param>
    protected void gvProjectList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvProjectList.PageIndex = e.NewPageIndex;
        BindGrid();
    }

    /// <summary>
    /// Sorting Event for Project List Grid
    /// </summary>
    /// <param name="sender">Sender Object</param>
    /// <param name="e">GridView Event Argument</param>
    protected void gvProjectList_Sorting(object sender, GridViewSortEventArgs e)
    {
        strConstructionProjectSortOrder = (strConstructionProjectSortBy == e.SortExpression) ? (strConstructionProjectSortOrder == "asc" ? "desc" : "asc") : "asc";
        strConstructionProjectSortBy = e.SortExpression;
        BindGrid();
    }

    /// <summary>
    /// Row Command Event for Project List Grid
    /// </summary>
    /// <param name="sender">Sender Object</param>
    /// <param name="e">GridView Event Argument</param>
    protected void gvProjectList_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "RemoveProject")
        {
            Facility_Construction_Project.Delete(Convert.ToDecimal(e.CommandArgument));
            BindGrid();
        }
    }

    #endregion

    #region Events

    /// <summary>
    /// button Edit click event
    /// </summary>
    /// <param name="sender">Sender Object</param>
    /// <param name="e">Event Argument</param>
    protected void btnEdit_Click(object sender, EventArgs e)
    {
        aAddProject.Visible = true;
        HasEditRights = true;
        BindGrid();
        btnEdit.Visible = false;
        btnCancel.Visible = true;
        Session["IsEditable"] = "1";
    }

    /// <summary>
    /// Cancel Button Click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        aAddProject.Visible = false;
        HasEditRights = false;
        BindGrid();
        btnEdit.Visible = true;
        btnCancel.Visible = false;
        Session.Remove("IsEditable");
    }

    #endregion
}
