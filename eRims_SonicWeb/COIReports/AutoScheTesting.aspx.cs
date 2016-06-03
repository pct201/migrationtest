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

public partial class COIReports_AutoScheTesting : clsBasePage
{
    #region Page Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            

                DataSet dsReport = clsCOIReports.AUTOSCHETESTING();
                DataTable dtVehicle = dsReport.Tables[0];
                btnExport1.Visible = dtVehicle.Rows.Count > 0;
                if (dtVehicle.Rows.Count > 0)
                {
                    gvVehicle.Columns[0].FooterText = "Total";
                    gvVehicle.Columns[1].FooterText = dsReport.Tables[0].Rows[0][0].ToString();
                }

                gvVehicle.DataSource = dsReport.Tables[0];
                gvVehicle.DataBind();


                DataTable dtDriver = dsReport.Tables[1];
                btnExport2.Visible = dtDriver.Rows.Count > 0;

                if (dtDriver.Rows.Count > 0)
                {
                    gvDriver.Columns[0].FooterText = "Total";
                    gvDriver.Columns[1].FooterText = dsReport.Tables[1].Rows[0][0].ToString();
                }
                gvDriver.DataSource = dtDriver;
                gvDriver.DataBind();

            
        }
        gvDriver.Visible = true;
        gvVehicle.Visible = true;
    }
    #endregion

    #region Event
    /// <summary>
    /// Event to Export Gridview data to Excel file
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnExport1_Click(object sender, EventArgs e)
    {
        // Export the data into excel spreadsheet
        //clsGeneral.ExportData((DataTable)ViewState["dtReport1"], "Auto Schedule Testing");
        gvVehicle.GridLines = GridLines.Both;
        gvVehicle.FooterStyle.Font.Bold = true;
        GridViewExportUtil.ExportGrid("Entity.xlsx", gvVehicle, true);
        gvVehicle.GridLines = GridLines.None;
    }

    /// <summary>
    /// Event to Export Gridview data to Excel file
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnExport2_Click(object sender, EventArgs e)
    {
        // Export the data into excel spreadsheet
        //clsGeneral.ExportData((DataTable)ViewState["dtReport2"], "Auto Schedule Testing");
        gvDriver.GridLines = GridLines.Both;
        gvDriver.FooterStyle.Font.Bold = true;
        GridViewExportUtil.ExportGrid("Entity.xls", gvDriver, true);
        gvDriver.GridLines = GridLines.None;
    }
    #endregion

    #region Method
    // <summary>
    // This method is added for export Girdview To Excel which contains SubGridview.
    // </summary>
    // <param name="control"></param>
    public override void VerifyRenderingInServerForm(Control control)
    {
        return;
    }
    #endregion
}
