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

public partial class SONIC_FirstReport_WCAllocationLocationReport : clsBasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            lnkExportToExcel.Visible = false;
            ComboHelper.FillDistinctYear_Worker_Comp_Charge(new DropDownList[] { ddlYear } , true);
            ComboHelper.FillLocationdba(new DropDownList[] { ddlLocation },0, true);
            
        }
    }
    protected void btnShowReport_Click(object sender, EventArgs e)
    {
        BindData();
    }
    protected void lnkExportToExcel_Click(object sender, EventArgs e)
    {
        gvworkers_comp_charges.GridLines = GridLines.Both;
        GridViewExportUtil.ExportAdHoc("WC Allocation Location Report.xls", gvworkers_comp_charges);
        gvworkers_comp_charges.GridLines = GridLines.None;
    }
    private void BindData()
    {
        decimal year = ddlYear.SelectedIndex > 0 ? Convert.ToDecimal(ddlYear.SelectedValue) : 0;
        decimal Month = ddlMonth.SelectedIndex > 0 ? Convert.ToDecimal(ddlMonth.SelectedValue) : 0;
        decimal Location_ID = ddlLocation.SelectedIndex > 0 ? Convert.ToDecimal(ddlLocation.SelectedValue) : 0;
        DataSet dsResult = WC_ClaimInfo.WC_Allocation_Location_Report(year, Month, Location_ID);
        DataTable dtResult = dsResult.Tables[0];
        gvworkers_comp_charges.DataSource = dtResult;
        gvworkers_comp_charges.DataBind();
        if (dtResult.Rows.Count > 0)
            lnkExportToExcel.Visible = true;
        else
            lnkExportToExcel.Visible = false;
        dtResult.Dispose();
        dtResult = null;
    }
}
