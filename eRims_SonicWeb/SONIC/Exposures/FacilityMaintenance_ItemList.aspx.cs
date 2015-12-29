using ERIMS.DAL;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SONIC_Exposures_FacilityMaintenance_ItemList : System.Web.UI.Page
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
    /// Denotes Location ID to be used as FK
    /// </summary>
    private string OperationMode
    {
        get { return Convert.ToString(ViewState["OperationMode"]); }
        set { ViewState["OperationMode"] = value; }
    }

    #endregion

    #region Page Load Event

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["loc"] != null)
            {
                Tab.SetSelectedTab(Controls_ExposuresTab_ExposuresTab.Tab.FacilityMaintenance);

                int loc;
                if (int.TryParse(Encryption.Decrypt(Request.QueryString["loc"]), out loc))
                {
                    FK_LU_Location_ID = loc;
                }
                else
                    Response.Redirect("ExposureSearch.aspx");

                Session["ExposureLocation"] = FK_LU_Location_ID;

                ucCtrlExposureInfo.PK_LU_Location = FK_LU_Location_ID;
                ucCtrlExposureInfo.BindExposureInfo();

                // Bind Grid
                BindGrid();
                OperationMode = "View";
            }
            else
            {
                Response.Redirect("ExposureSearch.aspx");
            }
        }
    }

    #endregion

    #region GridView Events

    /// <summary>
    /// GridView Row Command Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvMaintenance_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "MaintenanceDetails")
        {
            Response.Redirect(String.Format("FacilityMaintenance_Item.aspx?loc={0}&item={1}&op={2}", Request.QueryString["loc"].ToString(), Encryption.Encrypt(e.CommandArgument.ToString()), OperationMode));
        }
    }

    #endregion

    #region Control Events

    /// <summary>
    /// Edit Button Click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnEdit_Click(object sender, EventArgs e)
    {
        trAddNew.Visible = true;
        OperationMode = "Edit";
    }

    /// <summary>
    /// Add New Maintenance Click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkAddNewMaintenance_Click(object sender, EventArgs e)
    {
        Response.Redirect(String.Format("FacilityMaintenance_Item.aspx?loc={0}", Request.QueryString["loc"].ToString()));
    }

    #endregion

    #region Private Methods

    /// <summary>
    /// Binds Grid Details
    /// </summary>
    private void BindGrid()
    {
        gvMaintenance.DataSource = Facility_Construction_Maintenance_Item.GetMaintenanceDetailsByLocation(FK_LU_Location_ID);
        gvMaintenance.DataBind();
    }

    #endregion        
}