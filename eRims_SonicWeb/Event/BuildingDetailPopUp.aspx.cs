using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ERIMS.DAL;

public partial class Event_BuildingDetailPopUp : System.Web.UI.Page
{
    #region " Properties "

    /// <summary>
    /// Used To manipulate primary key Parameter
    /// </summary>
    public int PK_Event
    {
        get { return (!clsGeneral.IsNull(Request.QueryString["event"]) ? Convert.ToInt32(Request.QueryString["event"]) : -1); }
    }

    public decimal PK_ACI_LU_Location
    {
        get { return (!clsGeneral.IsNull(Request.QueryString["aci_loc_id"]) ? Convert.ToInt32(Request.QueryString["aci_loc_id"]) : -1); }
    }
    #endregion

    #region "Page Load"

    /// <summary>
    /// Page Load
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ComboHelper.FillLocation(new DropDownList[] { ddlLocation_Sonic }, true);
            clsGeneral.SetDropdownValue(ddlLocation_Sonic, PK_ACI_LU_Location, true);
            BindGridBuilding();
        }
    }


    #endregion

    #region "Method"

    /// <summary>
    ///  Binds Building grid in building information panel
    /// </summary>
    private void BindGridBuilding()
    {
        DataTable dtBuilding = Building.SelectByACILocation(clsGeneral.GetDecimal(ddlLocation_Sonic.SelectedValue)).Tables[0];

        if (dtBuilding != null)
        {
            gvBuildingEdit.DataSource = dtBuilding;
            gvBuildingEdit.DataBind();
        }
        else
        {
            gvBuildingEdit.DataSource = null;
            gvBuildingEdit.DataBind();
        }

    }

    #endregion

    #region " Event "

    protected void ddlLocation_Sonic_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindGridBuilding();
    }

    /// <summary>
    /// Handles Building grid row data bound event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvBuildingEdit_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        // if row type is data row
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            // get occupancies values bound to the grid
            Label lblOccupancy = (Label)e.Row.FindControl("lblOccupancy");
            bool bOccupancy_Sales_New = Convert.ToBoolean(DataBinder.Eval(e.Row.DataItem, "Occupancy_Sales_New"));
            bool bOccupancy_Body_Shop = Convert.ToBoolean(DataBinder.Eval(e.Row.DataItem, "Occupancy_Body_Shop"));
            bool bOccupancy_Parking_Lot = Convert.ToBoolean(DataBinder.Eval(e.Row.DataItem, "Occupancy_Parking_Lot"));
            bool bOccupancy_Sales_Used = Convert.ToBoolean(DataBinder.Eval(e.Row.DataItem, "Occupancy_Sales_Used"));
            bool bOccupancy_Parts = Convert.ToBoolean(DataBinder.Eval(e.Row.DataItem, "Occupancy_Parts"));
            bool bOccupancy_Raw_Land = Convert.ToBoolean(DataBinder.Eval(e.Row.DataItem, "Occupancy_Raw_Land"));
            bool bOccupancy_Service = Convert.ToBoolean(DataBinder.Eval(e.Row.DataItem, "Occupancy_Service"));
            bool bOccupancy_Ofifce = Convert.ToBoolean(DataBinder.Eval(e.Row.DataItem, "Occupancy_Ofifce"));


            string strOccupancy = ""; // used to set the comma seperated occupancies

            // append occupancy text with comma seperation depending on the values
            if (bOccupancy_Sales_New) strOccupancy = "Sales - New";
            if (bOccupancy_Body_Shop) strOccupancy = strOccupancy != "" ? strOccupancy + "," + "Body Shop" : "Body Shop";
            if (bOccupancy_Parking_Lot) strOccupancy = strOccupancy != "" ? strOccupancy + "," + "Parking Lot" : "Parking Lot";
            if (bOccupancy_Sales_Used) strOccupancy = strOccupancy != "" ? strOccupancy + "," + "Sales - Used" : "Sales - Used";
            if (bOccupancy_Parts) strOccupancy = strOccupancy != "" ? strOccupancy + "," + "Parts" : "Parts";
            if (bOccupancy_Raw_Land) strOccupancy = strOccupancy != "" ? strOccupancy + "," + "Raw Land" : "Raw Land";
            if (bOccupancy_Service) strOccupancy = strOccupancy != "" ? strOccupancy + "," + "Service" : "Service";
            if (bOccupancy_Ofifce) strOccupancy = strOccupancy != "" ? strOccupancy + "," + "Office" : "Office";

            // set text in occupancy column
            lblOccupancy.Text = strOccupancy;
        }
    }

    /// <summary>
    /// Handles Building grid rowcommand event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvBuildingEdit_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "SelectBuildingDetail")
        {
            //here insert in "Event_Link_Building" table
            Int32 PK_Building_ID = Convert.ToInt32(e.CommandArgument);

            clsEvent_Link_Building objEvent_Link_Building = new clsEvent_Link_Building();
            objEvent_Link_Building.Fk_Building = PK_Building_ID;
            objEvent_Link_Building.FK_Event = PK_Event;
            objEvent_Link_Building.Insert();
            
        }

        Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ClosePopup();", true);
        
    }
    #endregion
}