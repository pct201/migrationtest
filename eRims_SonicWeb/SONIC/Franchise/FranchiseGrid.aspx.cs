using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERIMS.DAL;

public partial class SONIC_FirstReport_FranchiseGrid : clsBasePage
{
    #region "Properties"
    /// <summary>
    /// Denotes Location ID to be used as FK
    /// </summary>
    private int FK_LU_Location_ID
    {
        get { return Convert.ToInt32(ViewState["FK_LU_Location_ID"]); }
        set { ViewState["FK_LU_Location_ID"] = value; }
    }

    /// <summary>
    /// Denotes operation for page in either in view or edit mode
    /// </summary>
    public string strOperation
    {
        get { return ViewState["strOperation"].ToString(); }
        set { ViewState["strOperation"] = value; }
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
        Tab.SetSelectedTab(Controls_ExposuresTab_ExposuresTab.Tab.Franchise);
        //used to check Page Post Back Event
        if (!IsPostBack)
        {
            // check for the location id is passed in querystring
            if (Request.QueryString["loc"] != null)
            {
                int loc;
                if (int.TryParse(Encryption.Decrypt(Request.QueryString["loc"]), out loc))
                {
                    FK_LU_Location_ID = loc;
                }
                else
                    Response.Redirect("../Exposures/ExposureSearch.aspx");

                // store the location id in session
                Session["ExposureLocation"] = FK_LU_Location_ID;

                // set opertation for page
                strOperation = (Request.QueryString["op"] != null) ? Convert.ToString(Request.QueryString["op"]) : "view";

                ucCtrlExposureInfo.PK_LU_Location = FK_LU_Location_ID;
                ucCtrlExposureInfo.BindExposureInfo();
                BindGrid();
                setControls();
            }
            else
                Response.Redirect("../Exposures/ExposureSearch.aspx");
        }
    }

    #endregion

    #region "Methods"

    /// <summary>
    /// Method set controls
    /// </summary>
    private void setControls()
    {
        if (strOperation.ToLower().Trim() == "view")
        {
            lnkAddFranchise.Visible = false;
            gvFranchise.Columns[4].Visible = false;
            btnEdit.Visible = (App_Access == AccessType.Franchise_AddEdit);
        }
        else
        {
            if (App_Access != AccessType.Franchise_AddEdit)
                Response.Redirect(AppConfig.SiteURL + "Error.aspx?msg=errAcc");

            lnkAddFranchise.Visible = true;
            gvFranchise.Columns[4].Visible = true;
            btnEdit.Visible = false;
        }
    }

    /// <summary>
    /// Bind Franchise Records in grid
    /// </summary>
    private void BindGrid()
    {
        gvFranchise.DataSource = ERIMS.DAL.Franchise.SelectFranchiseByLoction(FK_LU_Location_ID);
        gvFranchise.DataBind();
    }

    #endregion

    #region "Events"

    /// <summary>
    /// Add new button click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkAddFranchise_Click(object sender, EventArgs e)
    {
        Response.Redirect("FranchiseAddEdit.aspx?loc=" + Request.QueryString["loc"]);
    }

    /// <summary>
    /// button Edit click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnEdit_Click(object sender, EventArgs e)
    {
        btnEdit.Visible = false;
        lnkAddFranchise.Visible = true;
        gvFranchise.Columns[4].Visible = true;
        strOperation = "edit";
    }

    #endregion

    #region "Grid Events"

    /// <summary>
    /// Gridview page index changing Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvFranchise_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvFranchise.PageIndex = e.NewPageIndex;
        BindGrid();
    }

    /// <summary>
    /// Handle Gridview RowCommand Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvFranchise_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (Convert.ToString(e.CommandName) == "ShowDetails")
        {
            //View or Edit Mode
            Response.Redirect("FranchiseAddEdit.aspx?id=" + Encryption.Encrypt(Convert.ToString(e.CommandArgument)) + "&op=" + strOperation + "&loc=" + Request.QueryString["loc"]);
        }
        else if (Convert.ToString(e.CommandName) == "RemoveDetails")
        {
            //Remove record
            decimal _Pk_Franchise_ID = Convert.ToDecimal(e.CommandArgument);
            Franchise.DeleteByPK(_Pk_Franchise_ID);
            BindGrid();
        }
    }

    protected void gvFranchise_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        // check for datarow
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            // get occupancies values bound to the grid
            LinkButton lblOccupancy = (LinkButton)e.Row.FindControl("lnkBuilding");
            bool bOccupancy_Sales_New = Convert.ToBoolean(DataBinder.Eval(e.Row.DataItem, "Occupancy_Sales_New"));
            bool bOccupancy_Body_Shop = Convert.ToBoolean(DataBinder.Eval(e.Row.DataItem, "Occupancy_Body_Shop"));
            bool bOccupancy_Parking_Lot = Convert.ToBoolean(DataBinder.Eval(e.Row.DataItem, "Occupancy_Parking_Lot"));
            bool bOccupancy_Sales_Used = Convert.ToBoolean(DataBinder.Eval(e.Row.DataItem, "Occupancy_Sales_Used"));
            bool bOccupancy_Parts = Convert.ToBoolean(DataBinder.Eval(e.Row.DataItem, "Occupancy_Parts"));
            bool bOccupancy_Raw_Land = Convert.ToBoolean(DataBinder.Eval(e.Row.DataItem, "Occupancy_Raw_Land"));
            bool bOccupancy_Service = Convert.ToBoolean(DataBinder.Eval(e.Row.DataItem, "Occupancy_Service"));
            bool bOccupancy_Ofifce = Convert.ToBoolean(DataBinder.Eval(e.Row.DataItem, "Occupancy_Ofifce"));

            string strOccupancy = ""; // used to set the comma seperated occupancies         

            if (bOccupancy_Sales_New)
                strOccupancy = strOccupancy + "Sales - New" + ", ";
            if (bOccupancy_Body_Shop)
                strOccupancy = strOccupancy + "Body Shop" + ", ";
            if (bOccupancy_Parking_Lot)
                strOccupancy = strOccupancy + "Parking Lot" + ", ";
            if (bOccupancy_Sales_Used)
                strOccupancy = strOccupancy + "Sales - Used" + ", ";
            if (bOccupancy_Parts)
                strOccupancy = strOccupancy + "Parts" + ", ";
            if (bOccupancy_Raw_Land)
                strOccupancy = strOccupancy + "Raw Land" + ", ";
            if (bOccupancy_Service)
                strOccupancy = strOccupancy + "Service" + ", ";
            if (bOccupancy_Ofifce)
                strOccupancy = strOccupancy + "Office" + ", ";

            // set text in occupancy column
            lblOccupancy.Text = lblOccupancy.Text + " - " + strOccupancy.Trim().Trim(',');
        }
    }

    #endregion
}
