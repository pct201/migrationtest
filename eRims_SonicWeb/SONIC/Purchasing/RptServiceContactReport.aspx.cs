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
/// <summary>
/// Date           : 23-03-09
/// 
/// Developer Name : Ravi Gupta
/// 
/// Description    : Display Service Contract Report as per passed criteria
/// 
/// </summary>
public partial class SONIC_Purchasing_RptServiceContactReport : clsBasePage
{
    DataTable dtDetails, dtSupplierTotals, dtGrandTotal;

    protected void Page_Load(object sender, EventArgs e)
    {
        // when page is loaded first time
        if (!IsPostBack)
        {
            lnkExportToExcel.Visible = false;
            // get regions for user having access to and bind the regions list box
            DataTable dtRegions = clsClaimReports.SelectRegions().Tables[0];
            lstRegions.DataSource = dtRegions;
            lstRegions.DataTextField = "region";
            lstRegions.DataValueField = "region";
            lstRegions.DataBind();


            //Fill Location 
            ComboHelper.FillMarketListBox(new ListBox[] { lstMarket }, false);


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

            // get regions for user having access to and bind the Location list box
            DataTable dtLocation = LU_Location.SelectAll(CurrentEmployee, Regional.ToString().TrimEnd(Convert.ToChar(","))).Tables[0];
            dtLocation.DefaultView.Sort = "DBA";
            lstLocation.DataSource = dtLocation.DefaultView;
            lstLocation.DataTextField = "dba";
            lstLocation.DataValueField = "PK_LU_Location_ID";
            lstLocation.DataBind();

            // get regions for user having access to and bind the Service Contract list box
            DataTable dtServiceContract = LU_Service_Contract.selectAll();
            lstServiceContract.DataSource = dtServiceContract;
            lstServiceContract.DataTextField = "FLD_DESC";
            lstServiceContract.DataValueField = "FLD_DESC";
            lstServiceContract.DataBind();

            // get regions for user having access to and bind the Service Type list box
            DataTable dtServiceType = PurchasingServiceContract.SelectAllServiceType().Tables[0];
            lstServiceType.DataSource = dtServiceType;
            lstServiceType.DataTextField = "service_type";
            lstServiceType.DataValueField = "service_type";
            lstServiceType.DataBind();
        }

    }

    #region "Controls Events"

    /// <summary>
    /// Handles Show report button click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnGenerateReport_Click(object sender, EventArgs e)
    {
        string strRegion = "";
        string strMarket = "";
        string strLocaiton = "";
        string strServiceContract = "";
        string strServiceType = "";


        // get selected regions
        foreach (ListItem itmRegion in lstRegions.Items)
        {
            if (itmRegion.Selected)
                strRegion = strRegion + "'" + itmRegion.Value + "',";
        }
        strRegion = strRegion.TrimEnd(',');

        // get selected Markets
        foreach (ListItem itmMarket in lstMarket.Items)
        {
            if (itmMarket.Selected)
                strMarket = strMarket + "" + itmMarket.Value + ",";
        }
        strMarket = strMarket.TrimEnd(',');

        // get selected Locations
        foreach (ListItem itmLocation in lstLocation.Items)
        {
            if (itmLocation.Selected)
                strLocaiton = strLocaiton + itmLocation.Value + ",";
        }
        strLocaiton = strLocaiton.TrimEnd(',');

        // get selected Service Contract
        foreach (ListItem itmSC in lstServiceContract.Items)
        {
            if (itmSC.Selected)
                strServiceContract = strServiceContract + "'" + itmSC.Value + "',";
        }
        strServiceContract = strServiceContract.TrimEnd(',');

        // get selected service Type
        foreach (ListItem itmST in lstServiceType.Items)
        {
            if (itmST.Selected)
                strServiceType = strServiceType + "'" + itmST.Value + "',";
        }
        strServiceType = strServiceType.TrimEnd(',');

        // get start date
        Nullable<DateTime> Start_To_Date = clsGeneral.FormatNullDateToStore(txtStartDateToDate.Text);
        Nullable<DateTime> Start_From_Date = clsGeneral.FormatNullDateToStore(txtStartDateFromDate.Text);
        // get end date
        Nullable<DateTime> End_To_Date = clsGeneral.FormatNullDateToStore(txtEndDateToDate.Text);
        Nullable<DateTime> End_From_Date = clsGeneral.FormatNullDateToStore(txtEndDateFromDate.Text);

        // get data for financial summary report for selected values
        DataSet dsReport = clsPurchaseReport.GetService_Contract_Detail_Report(strRegion, strMarket, strLocaiton, strServiceContract, strServiceType, Start_To_Date, Start_From_Date, End_To_Date, End_From_Date);

        dtDetails = dsReport.Tables[0];
        dtSupplierTotals = dsReport.Tables[1];
        dtGrandTotal = dsReport.Tables[2];

        DataView dvSupplierTotals = dtSupplierTotals.DefaultView;
        dvSupplierTotals.Sort = "Region";

        gvRegion.DataSource = dvSupplierTotals.ToTable();
        //gvRegion.DataSource = dtSupplierTotals;
        gvRegion.DataBind();
        if (dtSupplierTotals.Rows.Count > 0)
            lnkExportToExcel.Visible = true;
        else
            lnkExportToExcel.Visible = false;
        if (dtDetails.Rows.Count > 0)
        {
            if (dtGrandTotal.Rows.Count > 0)
            {
                DataRow drTotal = dtGrandTotal.Rows[0];
                ((Label)gvRegion.FooterRow.FindControl("lblRegionTotal")).Text = String.Format("{0:N0}", drTotal["Total"]);
                ((Label)gvRegion.FooterRow.FindControl("lblMonthly_Cost")).Text = String.Format("{0:C2}", drTotal["Monthly_Cost"]);
                ((Label)gvRegion.FooterRow.FindControl("lblAuunual_Cost")).Text = String.Format("{0:C2}", drTotal["Annual_Cost"]);

            }
        }
    }

    protected void gvRegion_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string strRegion = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Region"));
            DataView dvDetails = dtDetails.DefaultView;
            dvDetails.RowFilter = "Region = '" + strRegion + "'";

            GridView gvReport = (GridView)e.Row.FindControl("gvReport");
            gvReport.DataSource = dvDetails.ToTable();
            //gvReport.DataSource = dtDetails;
            gvReport.DataBind();

            DataRow[] dr = dtSupplierTotals.Select("Region= '" + strRegion + "'");

            if (dr.Length > 0)
            {
                DataRow drTotal = dr[0];

                gvReport.FooterRow.Cells[1].Text = String.Format("{0:N0}", drTotal["Total"]);
                gvReport.FooterRow.Cells[6].Text = String.Format("{0:C2}", drTotal["Monthly_Cost"]);
                gvReport.FooterRow.Cells[7].Text = String.Format("{0:C2}", drTotal["Annual_Cost"]);
            }
        }
    }

    protected void gvRegion_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            GridViewRow gRow = new GridViewRow(0, -1, DataControlRowType.Header, DataControlRowState.Normal);
            gRow.Font.Bold = true;

            // create a table cell to be added in row
            TableCell Cell = new TableCell();
            Cell.HorizontalAlign = HorizontalAlign.Center;
            Cell.Text = "<table width='100%' cellspacing=0 cellpadding=0><tr><td width='100%'>" +
                            "<table width='100%' style='font-weight: bold;' cellspacing=0 cellpadding=0><tr><td width='100%' >" +
                                "<table width='100%' cellpadding=4 cellspacing=0 style='border: black 0.5px solid;font-weight: bold;'>" +
                                    "<tr style='font-weight: bold;'><td align='right' style='width:55%' colspan='4' >Service Contract Detail</td>" +
                                    "<td align='right' style='width:45%' colspan='4'> " + DateTime.Now + "</td></tr></table>" +
                                "</td></tr></table>" +
                            "</td></tr></table>";
            // add cell in row
            gRow.Cells.Add(Cell);

            // add row in gridview header
            ((Table)gvRegion.Controls[0]).Rows.AddAt(0, gRow);
        }
    }

    /// <summary>
    /// Handles Clear Criteria button click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnClearCriteria_Click(object sender, EventArgs e)
    {
        // load the page again 
        Response.Redirect("RptServiceContactReport.aspx", false);
    }

    /// <summary>
    /// handles Export to Excel link click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkExportToExcel_Click(object sender, EventArgs e)
    {
        gvRegion.GridLines = GridLines.Both;
        ((HtmlTable)gvRegion.HeaderRow.FindControl("tblHeader")).Border = 1;
        ((HtmlTable)gvRegion.FooterRow.FindControl("tblFooter")).Border = 1;
        foreach (GridViewRow gRow in gvRegion.Rows)
        {
            GridView gvAssetData = (GridView)gRow.FindControl("gvReport");
            gvAssetData.GridLines = GridLines.Both;
        }

        // export data to excel from gridview
        GridViewExportUtil.ExportGrid("ServiceContract.xlsx", gvRegion, true);

        // reset the settings
        gvRegion.GridLines = GridLines.None;
        foreach (GridViewRow gRow in gvRegion.Rows)
        {
            GridView gvAssetData = (GridView)gRow.FindControl("gvReport");
            gvAssetData.GridLines = GridLines.None;
        }
        ((HtmlTable)gvRegion.HeaderRow.FindControl("tblHeader")).Border = 0;
        ((HtmlTable)gvRegion.FooterRow.FindControl("tblFooter")).Border = 0;
    }
    #endregion

    /// <summary>
    /// This method is added for export Girdview To Excel which contains SubGridview.
    /// </summary>
    /// <param name="control"></param>
    public override void VerifyRenderingInServerForm(Control control)
    {
        return;
    }
}
