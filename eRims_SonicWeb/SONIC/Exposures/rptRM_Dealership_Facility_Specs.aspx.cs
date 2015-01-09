using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using ERIMS.DAL;
using System.Text;

public partial class SONIC_Exposures_rptRM_Dealership_Facility_Specs : clsBasePage
{
    #region "Page Load"
    /// <summary>
    /// Handles event when page is loaded
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        // if page is loaded first time
        if (!IsPostBack)
        {
            // get regions for user having access to and bind the regions list box
            DataTable dtRegions = clsClaimReports.SelectRegions().Tables[0];
            lstRegions.DataSource = dtRegions;
            lstRegions.DataTextField = "region";
            lstRegions.DataValueField = "region";
            lstRegions.DataBind();

            DataTable dtBrand = LU_Franchise_Brand.SelectAll().Tables[0];
            lstBrand.DataSource = dtBrand;
            lstBrand.DataTextField = "Fld_Desc";
            lstBrand.DataValueField = "PK_LU_Franchise_Brand";
            lstBrand.DataBind();

            //Bind Market Dropdown
            ComboHelper.FillMarketListBox(new ListBox[] { lstMarket }, false);
        }
    }
    #endregion

    #region "Controls Events"

    /// <summary>
    /// Back hrom report to Criteria
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnBack_Click(object sender, EventArgs e)
    {
        trCriteria.Visible = true;
        tblReport.Visible = false;

    }
    /// <summary>
    /// Handles Show Report button click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnShowReport_Click(object sender, EventArgs e)
    {
        string strRegion = "";
        string strMarket = "";
        string strStatus = "";
        string strOwnership = "";
        string strBrand = "";
        // get selected regions
        strRegion = GetCommaSeparatedValues(lstRegions);
        strMarket = GetCommaSeparatedValues(lstMarket);
        strStatus = GetCommaSeparatedValues(ddlStatus);
        strOwnership = GetCommaSeparatedValues(lstOwnership);
        strBrand = GetCommaSeparatedValues(lstBrand);
        // get report data for selected values
        DataSet dsReport = clsExposuresReports.GetrptRM_Dealership_Facility_Specs(strRegion, strStatus, strOwnership, strBrand, strMarket);

        // get data tables from dataset
        DataTable dtRegions = dsReport.Tables[0];

        // bind the main grid which lists regions
        gvDescription.DataSource = dtRegions;
        gvDescription.DataBind();

        // show grid and export link 
        tblReport.Visible = true;
        trCriteria.Visible = false;
        lbtExportToExcel.Visible = dtRegions.Rows.Count > 0;
        btnBack.Visible = true;

        // Check if record found or not.
        if (dtRegions.Rows.Count > 0)
        {
            // set Gridview div Scroll bar events so Scroll Header as per grid scroll
            //dvGrid.Attributes.Add("onscroll", "javascript:ChangeScrollBar(this," + dvHeader.ClientID + ");");
            //dvHeader.Visible = true;
            dvGridHeader.Visible = true;
            trMessage.Visible = false;
            trGrid.Visible = true;
        }
        else
        {
            // if record not found then hide Header and set width and height so scroll bar not visible.
            trMessage.Visible = true;
            trGrid.Visible = false;
            dvGridHeader.Visible = false;
        }
    }

    /// <summary>
    /// Handles Export to Excel link click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lbtExportToExcel_Click(object sender, EventArgs e)
    {
        //Create HTML for the report and wirte into HTML Write object
        StringBuilder strHTML = new StringBuilder();
        System.IO.StringWriter stringWrite = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter htmlWrite = new System.Web.UI.HtmlTextWriter(stringWrite);
        string strRegion = "";
        string strMarket = "";
        string strStatus = "";
        string strOwnership = "";
        string strBrand = "";
        // get selected regions
        strRegion = GetCommaSeparatedValues(lstRegions);
        strMarket = GetCommaSeparatedValues(lstMarket);
        strStatus = GetCommaSeparatedValues(ddlStatus);
        strOwnership = GetCommaSeparatedValues(lstOwnership);
        strBrand = GetCommaSeparatedValues(lstBrand);
        // get report data for selected values
        DataTable dtReport = clsExposuresReports.GetrptRM_Dealership_Facility_Specs(strRegion, strMarket, strStatus, strOwnership, strBrand).Tables[0];
        //Add Header HTML
        strHTML.Append("<table  cellpadding='0' cellspacing='0' width='100%' border='1'>");
        strHTML.Append("<tr align='right' valign='bottom' style='font-weight: bold;'>");
        strHTML.Append("<td align='left' colspan='2'>Sonic Automotive</td>");
        strHTML.Append("<td align='center' colspan='9'>RM Dealership and Facility Specs</td>");
        strHTML.Append("<td align='right' colspan='5'>" + DateTime.Now.ToString() + "</td>");
        strHTML.Append("</tr>");
        strHTML.Append("<tr align='right' valign='bottom' style='font-weight: bold;'>");
        strHTML.Append("<td align='left'>Region</td>");
        strHTML.Append("<td align='left'>Location D/B/A</td>");
        strHTML.Append("<td align='left'>Sonic Location Number</td>");
        strHTML.Append("<td align='left'>Building Number</td>");

        strHTML.Append("<td align='left'>Address</td>");

        strHTML.Append("<td align='left'>Square Footage</td>");
        strHTML.Append("<td align='left'>Occupancy</td>");
        strHTML.Append("<td align='left'>Brand</td>");
        strHTML.Append("<td align='left'>Acreage</td>");
        strHTML.Append("<td align='left'>Number of Parking Spaces</td>");
        strHTML.Append("<td align='left'>Number Of Bays</td>");
        strHTML.Append("<td align='left'>Number Of Lifts</td>");
        strHTML.Append("<td align='left'>Number Of Paint Booths</td>");
        strHTML.Append("<td align='left'>Number of Prep Areas</td>");
        strHTML.Append("<td align='left'>Number of Car Wash Stations</td>");
        strHTML.Append("<td align='left'>Ownership</td>");
        strHTML.Append("<td align='left'>Location Status</td>");
        strHTML.Append("</tr>");

        if (dtReport.Rows.Count > 0)
        {
            for (int i = 0; i < dtReport.Rows.Count; i++)
            {
                strHTML.Append("<tr align='left'>");
                strHTML.Append("<td>" + Convert.ToString(dtReport.Rows[i]["Region"]) + "</td>");
                strHTML.Append("<td>" + Convert.ToString(dtReport.Rows[i]["DBA"]) + "</td>");
                strHTML.Append("<td>" + Convert.ToString(dtReport.Rows[i]["Sonic_Location_Code"]) + "</td>");
                strHTML.Append("<td>" + Convert.ToString(dtReport.Rows[i]["BUILDING_NUMBER"]) + "</td>");

                strHTML.Append("<td>" + Convert.ToString(dtReport.Rows[i]["Address"]) + "</td>");

                strHTML.Append("<td>" + Convert.ToString(dtReport.Rows[i]["Square_Footage"]) + "</td>");
                strHTML.Append("<td>" + Convert.ToString(dtReport.Rows[i]["Occupancy"]).TrimStart(',').TrimEnd(',') + "</td>");
                strHTML.Append("<td>" + Convert.ToString(dtReport.Rows[i]["Brand"]) + "</td>");
                strHTML.Append("<td>" + string.Format("{0:N3}", dtReport.Rows[i]["Acreage"]) + "</td>");
                strHTML.Append("<td>" + string.Format("{0:N0}", dtReport.Rows[i]["Number_of_Parking_Spaces"]) + "</td>");
                strHTML.Append("<td>" + string.Format("{0:N0}", dtReport.Rows[i]["Number_Of_Bays"]) + "</td>");
                strHTML.Append("<td>" + string.Format("{0:N0}", dtReport.Rows[i]["Number_Of_Lifts_Sc"]) + "</td>");
                strHTML.Append("<td>" + string.Format("{0:N0}", dtReport.Rows[i]["Number_Of_Paint_Booths"]) + "</td>");
                strHTML.Append("<td>" + string.Format("{0:N0}", dtReport.Rows[i]["Number_of_Prep_Areas"]) + "</td>");
                strHTML.Append("<td>" + string.Format("{0:N0}", dtReport.Rows[i]["Number_of_Car_Wash_Stations"]) + "</td>");
                strHTML.Append("<td>" + Convert.ToString(dtReport.Rows[i]["Ownership"]) + "</td>");
                strHTML.Append("<td>" + Convert.ToString(dtReport.Rows[i]["LOCATION_STATUS"]) + "</td>");

                strHTML.Append("</tr>");
            }
        }
        else
        {
            //Add No record found line for year
            strHTML.Append("<tr><td colspan='13' align='center'>No Record Found</td></tr>");
        }
        strHTML.Append("</table>");

        //Write HTML in to HtmlWriter
        htmlWrite.WriteLine(strHTML.ToString());

        HttpContext context = HttpContext.Current;
        context.Response.Clear();

        context.Response.Write(stringWrite);
        context.Response.ContentType = "application/ms-excel";
        context.Response.AppendHeader("Content-Disposition", "attachment; filename=RM Dealership and Facility Specs.XLS");
        context.Response.End();
    }

    /// <summary>
    /// Handles Clear Criteria button click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnClearCriteria_Click(object sender, EventArgs e)
    {
        // load the page again to clear selection
        lstRegions.ClearSelection();
        lstMarket.ClearSelection();
        ddlStatus.ClearSelection();
        lstBrand.ClearSelection();
        lstOwnership.ClearSelection();
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

    #region "Private Methods"
    private string GetCommaSeparatedValues(ListBox lst)
    {
        string strRegion = string.Empty;
        foreach (ListItem itmRegion in lst.Items)
        {
            if (itmRegion.Selected)
                strRegion = strRegion + itmRegion.Value + ",";
        }
        strRegion = strRegion.TrimEnd(',');
        return strRegion;
    }
    #endregion
}