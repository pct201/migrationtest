using ERIMS.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SONIC_Exposures_BuildingByLocation : System.Web.UI.Page
{
    public int LocationId;
    public string BuildingNumber;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) 
        {
            if (Request.QueryString["loc_id"] != null)
            {
                hdnLocationId.Value = Request.QueryString["loc_id"];
                hdnBuildingNumber.Value = Convert.ToString(Request.QueryString["BuildingNumber"]);
                hdnPK_AP_Property_Security.Value = Convert.ToString(Request.QueryString["ps_id"]);
            }
            BuildingGridDetails();
        }
    }

    private void BuildingGridDetails()
    {
        DataSet ds = Building.SelectByFKLocationAP(Convert.ToInt32(hdnLocationId.Value), hdnBuildingNumber.Value);
        DataTable dtBuilding = new DataTable();

        if (Convert.ToInt32(hdnLocationId.Value) != 0)
        {
            if (ds.Tables.Count > 0 && ds != null)
            {
                dtBuilding = ds.Tables[0];
                if (ds.Tables[1] != null && ds.Tables[1].Rows.Count > 0)
                {
                    hdnLocationdba.Value = Convert.ToString(ds.Tables[1].Rows[0][0]);
                }
            }
            
        }
        else
        {
            dtBuilding = Building.SelectAll().Tables[0];
        }


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
            bool bOccupancy_Main = Convert.ToBoolean(DataBinder.Eval(e.Row.DataItem, "Occupancy_Main"));


            string strOccupancy = ""; // used to set the comma seperated occupancies

            // append occupancy text with comma seperation depending on the values
            if (bOccupancy_Main) strOccupancy = "Main";
            if (bOccupancy_Sales_New) strOccupancy = strOccupancy != "" ? strOccupancy + ", " + "Sales - New" : "Sales - New";
            if (bOccupancy_Body_Shop) strOccupancy = strOccupancy != "" ? strOccupancy + ", " + "Body Shop" : "Body Shop";
            if (bOccupancy_Parking_Lot) strOccupancy = strOccupancy != "" ? strOccupancy + ", " + "Parking Lot" : "Parking Lot";
            if (bOccupancy_Sales_Used) strOccupancy = strOccupancy != "" ? strOccupancy + ", " + "Sales - Used" : "Sales - Used";
            if (bOccupancy_Parts) strOccupancy = strOccupancy != "" ? strOccupancy + ", " + "Parts" : "Parts";
            if (bOccupancy_Raw_Land) strOccupancy = strOccupancy != "" ? strOccupancy + ", " + "Raw Land" : "Raw Land";
            if (bOccupancy_Service) strOccupancy = strOccupancy != "" ? strOccupancy + ", " + "Service" : "Service";
            if (bOccupancy_Ofifce) strOccupancy = strOccupancy != "" ? strOccupancy + ", " + "Office" : "Office";

            // set text in occupancy column
            lblOccupancy.Text = strOccupancy;
        }
    }
    protected void lnkSelect_Click(object sender, EventArgs e)
    {
        Building building = new Building();

        int LocationNumber = Convert.ToInt32(hdnLocationId.Value);
        int PK_AP_Property_Security = Convert.ToInt32(hdnPK_AP_Property_Security.Value);
        string FK_Building_IdFrom = hdnBuildingNumber.Value;
        string FK_Building_IdTo = hdnBuildingNumberTo.Value;
        int returnVal = building.BuildingByFKLocationInsertUpdate(PK_AP_Property_Security, FK_Building_IdFrom, FK_Building_IdTo);
        if (returnVal != 0)
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "window.opener.document.getElementById('ctl00_ContentPlaceHolder1_btnRefresh').click(); window.close();;", true);                                 
        }      
    }   
}