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

public partial class SONIC_Purchasing_RptPurchasingAssetReport : clsBasePage
{
    #region "Variables"

    DataTable dtRegion, dtClaimData, dtTotal;
    string STR_Region;

    #endregion

    #region Page Events

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillDropDownList();
        }
    }

    /// <summary>
    /// This method is added for export Girdview To Excel which contains SubGridview.
    /// </summary>
    /// <param name="control"></param>
    public override void VerifyRenderingInServerForm(Control control)
    {
        return;
    }

    #endregion

    #region Controls Event

    protected void btnGenerateReport_Click(object sender, EventArgs e)
    {
        string strRegion = "";
        string strLocation = "";
        string strType = "";
        string strManufacturer = "";


        // get selected claim types

        foreach (ListItem itmRegion in lstRegion.Items)
        {
            if (itmRegion.Selected)
                strRegion = strRegion + "'" + itmRegion.Value + "',";
        }
        strRegion = strRegion.TrimEnd(',');

        foreach (ListItem itmLocation in lstLocation.Items)
        {
            if (itmLocation.Selected)
                strLocation = strLocation + "'" + itmLocation.Value + "',";
        }
        strLocation = strLocation.TrimEnd(',');

        foreach (ListItem itmType in lstType.Items)
        {
            if (itmType.Selected)
                strType = strType + "'" + itmType.Value + "',";
        }
        strType = strType.TrimEnd(',');

        foreach (ListItem itmManufacturer in lstManufacturer.Items)
        {
            if (itmManufacturer.Selected)
                strManufacturer = strManufacturer + "'" + itmManufacturer.Value + "',";
        }
        strManufacturer = strManufacturer.TrimEnd(',');

        // get result records from database for the report
        //DataSet dsReport = Purchasing_Asset.Get_Purchase_Report(Convert.ToInt32(drpLocation.SelectedValue),drpType.SelectedValue,drpRegion.SelectedValue,drpManufacturer.SelectedValue);
        //DataSet dsReport = Purchasing_Asset.Get_Purchase_Report(lstRegion.SelectedValue, lstManufacturer.SelectedValue, lstType.SelectedValue, lstLocation.SelectedValue);
        DataSet dsReport = Purchasing_Asset.Get_Purchase_Report(strRegion, strManufacturer, strType, strLocation);

        // get data tables from result dataset
        dtClaimData = dsReport.Tables[0];
        dtRegion = dsReport.Tables[1];
        dtTotal = dsReport.Tables[2];

        // bind the main grid having list of regions and total in footer
        gvReport.DataSource = dtRegion;
        gvReport.DataBind();

        // make visible the export link if data available
        lnkExport.Visible = (dtRegion.Rows.Count > 0);

        // set design settings according to the data availability
        if (dtRegion.Rows.Count > 0)
            divReport_Grid.Attributes.Add("style", "width:997px;overflow-x: scroll;overflow-y:hidden;");
        else
            divReport_Grid.Attributes.Add("style", "width:997px;height: 50px;overflow: hidden;");

        divReport_Grid.Style["display"] = "block";
    }

    protected void lnkExport_Click(object sender, EventArgs e)
    {
        gvReport.GridLines = GridLines.Both;
        ((HtmlTable)gvReport.HeaderRow.FindControl("tblHeader")).Border = 1;
        ((HtmlTable)gvReport.FooterRow.FindControl("tblFooter")).Border = 1;
        foreach (GridViewRow gRow in gvReport.Rows)
        {
            GridView gvAssetData = (GridView)gRow.FindControl("gvAssetData");
            gvAssetData.GridLines = GridLines.Both;
        }

        // export data to excel from gridview
        GridViewExportUtil.ExportGrid("AssetDetail.xls", gvReport);

        // reset the settings
        gvReport.GridLines = GridLines.None;
        foreach (GridViewRow gRow in gvReport.Rows)
        {
            GridView gvAssetData = (GridView)gRow.FindControl("gvAssetData");
            gvAssetData.GridLines = GridLines.None;
        }
        ((HtmlTable)gvReport.HeaderRow.FindControl("tblHeader")).Border = 0;
        ((HtmlTable)gvReport.FooterRow.FindControl("tblFooter")).Border = 0;
    }

    protected void btnClearCriteria_Click(object sender, EventArgs e)
    {
        Response.Redirect("RptPurchasingAssetReport.aspx", false);
    }

    #endregion

    #region Grid Events

    protected void gvReport_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            GridViewRow gRow = new GridViewRow(0, -1, DataControlRowType.Header, DataControlRowState.Normal);
            gRow.Font.Bold = true;

            // create a table cell to be added in row
            TableCell Cell = new TableCell();
            Cell.HorizontalAlign = HorizontalAlign.Center;
            Cell.Text = "<table width='100%' cellspacing=0 cellpadding=0><tr><td width='100%'>" +
                            "<table width='100%' style='font-weight: bold;' cellspacing=0 cellpadding=0><tr><td width='100%' colspan='8'>" +
                                "<table width='100%' cellpadding=4 cellspacing=0 style='font-weight: bold;'>" +
                                    "<tr><td align='left'>Sonic Automotive</td><td align='center' colspan='5'>Asset Detail</td>" +
                                    "<td align='right' colspan='2'> " + DateTime.Now + "</td></tr></table>" +
                                "</td></tr></table>" +
                            "</td></tr></table>";
            // add cell in row
            gRow.Cells.Add(Cell);

            // add row in gridview header
            ((Table)gvReport.Controls[0]).Rows.AddAt(0, gRow);
        }
    }

    protected void gvReport_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            // get the subgrid
            GridView gvAssetData = (GridView)e.Row.FindControl("gvAssetData");

            // get region of the row
            string strRegion = DataBinder.Eval(e.Row.DataItem, "Region").ToString();
            STR_Region = strRegion;

            // create a dataview from datatable for claim data
            DataView dvDetail = new DataView();
            dvDetail = dtClaimData.DefaultView;

            // get filtered data for the region
            dvDetail.RowFilter = "Region='" + strRegion + "'";

            // bind the subgrid
            DataTable dtReport = dvDetail.ToTable();
            gvAssetData.DataSource = dtReport;
            gvAssetData.DataBind();
        }
        else if (e.Row.RowType == DataControlRowType.Footer) // if the row is footer row
        {
            // get labels for total and total estimated exposure
            Label lblTotal = (Label)e.Row.FindControl("lblFTotal");
            Label lblTotalExposure = (Label)e.Row.FindControl("lblFTotalExposure");
            Label lblAcquisitionCost = (Label)e.Row.FindControl("lblAcquisitionCost");
            // get the datarow from datatable for total and set values in labels
            DataRow dr = dtTotal.Rows[0];
            lblTotal.Text = dr["Total"].ToString();
            //lblTotalExposure.Text = "$ " + clsGeneral.GetStringValue(dr["Total_Exposure"]);
            lblAcquisitionCost.Text = string.Format("{0:C2}", dr["Acquisition_Cost"]);
        }
    }

    protected void gvAssetData_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        // if row is footer row
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            // get the labels for total and total estimated exposure
            Label lblTotal = (Label)e.Row.FindControl("lblTotal");
            Label lblAcquisition_Cost = (Label)e.Row.FindControl("lblAcquisition_Cost");
            //Label lblTotalExposure = (Label)e.Row.FindControl("lblTotalExposure");

            // get the total from datatable for regions and set values in labels
            DataRow[] dr = dtRegion.Select("Region='" + STR_Region + "'");
            lblTotal.Text = dr[0]["Total"].ToString();
            lblAcquisition_Cost.Text = string.Format("{0:C2}", dr[0]["Acquisition_Cost"]);
            //lblTotalExposure.Text = "$ " + clsGeneral.GetStringValue(dr[0]["Total_Exposure"]);
        }
    }

    #endregion

    #region Methods

    private void FillDropDownList()
    {
        DataTable dtRegion = clsClaimReports.SelectRegions().Tables[0];
        lstRegion.DataSource = dtRegion;
        lstRegion.DataTextField = "Region";
        lstRegion.DataValueField = "Region";
        lstRegion.DataBind();

        // Fill Location by Employee        
        Nullable<decimal> CurrentEmployee = new Security(Convert.ToDecimal(clsSession.UserID)).Employee_Id;
        if (CurrentEmployee.ToString() != string.Empty && CurrentEmployee.ToString() != "0")
            CurrentEmployee = Convert.ToDecimal(CurrentEmployee);
        else
            CurrentEmployee = 0;
        string Regional = string.Empty;

        // select region as per login user
        DataSet dsRegion = Regional_Access.SelectBySecurityID(Convert.ToInt32(clsSession.UserID));

        // Append region in comma seperated string value
        if (dsRegion.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow drRegion in dsRegion.Tables[0].Rows)
                Regional += drRegion["Region"].ToString() + ",";
        }
        else
            Regional = string.Empty;

        DataTable dtLocation = LU_Location.SelectAll(CurrentEmployee, Regional.ToString().TrimEnd(Convert.ToChar(","))).Tables[0];
        lstLocation.DataSource = dtLocation;
        lstLocation.DataTextField = "dba";
        lstLocation.DataValueField = "PK_LU_Location_Id";
        lstLocation.DataBind();

        DataTable dtType = Purchasing_Asset.GetTypeList().Tables[0];
        lstType.DataSource = dtType;
        lstType.DataTextField = "Type";
        lstType.DataValueField = "Type";
        lstType.DataBind();

        DataTable dtManufacturer = Purchasing_Asset.GetManufacturerList().Tables[0];
        lstManufacturer.DataSource = dtManufacturer;
        lstManufacturer.DataTextField = "Fld_Desc";
        lstManufacturer.DataValueField = "FK_LU_Manufacturer";
        lstManufacturer.DataBind();

    }

    #endregion
}
