using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ERIMS.DAL;

public partial class Administrator_BuildingUnlock : clsBasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindBuildingDropdown();
        }
    }

    private void BindBuildingDropdown()
    {
        drpBuilding.DataSource = clsPM_Building_Edit.SelectForUnlock().Tables[0];
        drpBuilding.DataTextField = "Building_Occupacy";
        drpBuilding.DataValueField = "PK_Building_ID";
        drpBuilding.DataBind();
        drpBuilding.Items.Insert(0, new ListItem("--Select--", "0"));
    }

    protected void btnUnlock_Click(object sender, EventArgs e)
    {
        if (drpBuilding.SelectedIndex > 0)
        {
            clsPM_Building_Edit.DeleteAccess(Convert.ToDecimal(drpBuilding.SelectedValue));
            BindBuildingDropdown();
            Page.ClientScript.RegisterStartupScript(typeof(string), DateTime.Now.ToString(), "javascript:alert('Building record unlocked successfully.');", true);
        }
    }
}