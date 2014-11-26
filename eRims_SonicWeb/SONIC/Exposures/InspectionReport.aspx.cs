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
using ERIMS.DAL;

public partial class SONIC_Exposures_InspectionReport : clsBasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //used to fill dba Dropdown
            ComboHelper.FillLocationdba(new DropDownList[] { ddlLocation }, 0, true);
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        DataTable dtInspection = Inspection.SelectByFKLocation(Convert.ToInt32(ddlLocation.SelectedValue)).Tables[0];
        gvInspections.DataSource = dtInspection;
        gvInspections.DataBind();
    }

    protected void gvInspections_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "ViewInspection")
        {
            Response.Redirect("Inspections.aspx?loc=" + ddlLocation.SelectedValue);
        }
    }
}
