using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Text;
using ERIMS.DAL;
//using ERIMS_DAL;


public partial class SONIC_Exposures_PremiumAllocation_EditLocation : clsBasePage
{
    private decimal PK_PA_Values_Imported
    {
        get { if (ViewState["PK_PA_Values_Imported"] != null) return Convert.ToDecimal(ViewState["PK_PA_Values_Imported"]); else return decimal.Zero; }
        set { ViewState["PK_PA_Values_Imported"] = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillYear();
            ComboHelper.FillNewLocationForPremiumAllocation(new DropDownList[] { drpLocation }, 0, true, Convert.ToInt32(ddlYear.SelectedValue), "");
        }
    }

    #region "Controls Events"

    /// <summary>
    /// Handles Show Report button click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnShowReport_Click(object sender, EventArgs e)
    {
        SavePA_Imported();

        int? year = null;
        decimal? location = null;

        year = Convert.ToInt32(ddlYear.SelectedValue);
        if (drpLocation.SelectedIndex > 0)
            location = Convert.ToDecimal(drpLocation.SelectedValue);

        //DataSet dsReport = clsPA_Screen_Fields.Generate_PremiumAllocation_Annual_Report(year, location, "Add_Location");
        lblReport.Text = GenerageMonthlyReport().ToString();

    }

    /// <summary>
    /// Handles Clear Criteria button click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnClearCriteria_Click(object sender, EventArgs e)
    {
        ddlYear.SelectedIndex = 0;
        drpLocation.SelectedIndex = 0;
        txtNon_Texas_Payroll.Text = "";
        txtTexas_Payroll.Text = "";
        txtNumber_Of_Employees.Text = "";
    }

    /// <summary>
    /// This method is added for export Girdview To Excel which contains SubGridview.
    /// </summary>
    /// <param name="control"></param>
    public override void VerifyRenderingInServerForm(Control control)
    {
        return;
    }

    /// <summary>
    /// Handles Export to Excel link click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lbtExportToExcel_Click(object sender, EventArgs e)
    {
        string strcols = "border: #7f7f7f 1px solid;vertical-align: top;font-size: 8pt;border-collapse: collapse;";
        System.IO.StringWriter stringWrite = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter htmlWrite = new System.Web.UI.HtmlTextWriter(stringWrite);

        //PrepareControlForExport(gvReportGrid.HeaderRow);
        lblReport.RenderControl(htmlWrite);
        // gvReportGrid.RenderControl(htmlWrite);

        MemoryStream memorystream = new MemoryStream();
        byte[] _bytes = Encoding.UTF8.GetBytes(stringWrite.ToString().Replace("border-top:#EAEAEA", "border-top:#000000").Replace("<style type='text/css'></style>", "<style type='text/css'> .cols_{" + strcols + " }</style>"));
        memorystream.Write(_bytes, 0, _bytes.Length);
        memorystream.Seek(0, SeekOrigin.Begin);

        HttpContext.Current.Response.Clear();
        HttpContext.Current.Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "Sonic Premium Allocation Annual Report.xls"));
        HttpContext.Current.Response.ContentType = "application/ms-excel";
        HttpContext.Current.Response.Write(stringWrite.ToString().Replace("#EAEAEA", "White").Replace("#eaeaea", "White").Replace("background-color:#C0C0C0", "background-color:White;").Replace("<style type='text/css'></style>", "<style type='text/css'> .cols_{" + strcols + " }</style>").Replace("background-color:#7f7f7f;color:White", "background-color:White;color:Black"));
        HttpContext.Current.Response.End();
    }
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

    protected void ddlYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        ComboHelper.FillNewLocationForPremiumAllocation(new DropDownList[] { drpLocation }, 0, true, Convert.ToInt32(ddlYear.SelectedValue), "");
    }
    #endregion

    #region Methods

    /// <summary>
    /// Generate Report HTML based on Report Criteria
    /// </summary>
    /// <returns>return stringbuilder objects contans report in HTML format</returns>
    private System.Text.StringBuilder GenerageMonthlyReport()
    {
        int? year = null;
        decimal? location = null;

        year = Convert.ToInt32(ddlYear.SelectedValue);
        if (drpLocation.SelectedIndex > 0)
            location = Convert.ToDecimal(drpLocation.SelectedValue);

        DataSet dsReport = clsPA_Screen_Fields.Generate_PremiumAllocation_Annual_Report(year, location, "Edit_Location");

        DataTable dtReport = dsReport.Tables[0];

        System.Text.StringBuilder sbRecorords = new System.Text.StringBuilder("");
        trCriteria.Visible = false;
        tblReport.Visible = true;
        lbtExportToExcel.Visible = dtReport.Rows.Count > 0;
        btnBack.Visible = true;

        int intColspan = dtReport.Columns.Count;

        // Check if record found or not.
        if (dtReport.Rows.Count > 0)
        {
            sbRecorords.Append("<style type='text/css'></style><table border='0' style='border: black 0.5px solid;border-collapse: collapse;' cellpadding='0' cellspacing='0'  Width='100%px'><tr><td class='cols_' >");
            //sbRecorords.Append("<div style='overflow: hidden; width: 995px;'>");
            sbRecorords.Append("<div style='overflow-x: scroll;overflow-y:hidden; width: 994px; height: 100%;'>");
            sbRecorords.Append("<table style='padding-left:4px;font-size:8.5pt;font-family:Tahoma' cellpadding='4' cellspacing='0' Width='3120px'>");//Sub Table
            sbRecorords.Append("<tr style='font-weight: bold;background-color:#7f7f7f;color:White;font-size:11pt;height:25'>"); //Title
            sbRecorords.Append("<td align='left' style='font-size:9pt;' colspan='2'><b>Sonic Premium Allocation Annual Report</b></td>");
            sbRecorords.Append("<td align='center' style='font-size:9pt;' colspan='9' ><b> Year :" + Convert.ToString(ddlYear.SelectedValue) + " </b></td>");
            sbRecorords.Append("<td style='font-size:9pt' align='right' colspan='13'><b>Date Report Generated: " + DateTime.Now.ToString("MM/dd/yyy HH:mm tt") + "</b></td></tr>");
            sbRecorords.Append("<tr align='left'  style='font-weight: bold;background-color:#7f7f7f;color:White;font-size:8.5pt'>");
            sbRecorords.Append("<td class='cols_' width='200px' align='left'><b>Sonic Location Code</b></td>");
            sbRecorords.Append("<td class='cols_' width='250px' align='left'><b>Location d/b/a</b></td>");
            sbRecorords.Append("<td class='cols_' width='80px' align='left'><b>State</b></td>");
            sbRecorords.Append("<td class='cols_' width='120px' align='right'><b>Non-Texas Payroll</b></td>");
            sbRecorords.Append("<td class='cols_' width='120px' align='right'><b>Texas Payroll</b></td>");
            sbRecorords.Append("<td class='cols_' width='120px' align='right'><b>Total Payroll</b></td>");
            sbRecorords.Append("<td class='cols_' width='120px' align='right'><b>WC Premium</b></td>");
            sbRecorords.Append("<td class='cols_' width='140px' align='right'><b>Texas WC Premium</b></td>");
            sbRecorords.Append("<td class='cols_' width='120px' align='right'><b>SAI WC Premium</b></td>");
            sbRecorords.Append("<td class='cols_' width='120px' align='right'><b>Loss Fund</b></td>");
            sbRecorords.Append("<td class='cols_' width='120px' align='right'><b>Total Employees</b></td>");
            sbRecorords.Append("<td class='cols_' width='140px' align='right'><b>SAI Garage Liability</b></td>");
            sbRecorords.Append("<td class='cols_' width='120px' align='right'><b>Property Values</b></td>");
            sbRecorords.Append("<td class='cols_' width='150px' align='right'><b>SAI Property Premium</b></td>");
            sbRecorords.Append("<td class='cols_' width='180px' align='right'><b>SAI Earthquake Premium</b></td>");
            sbRecorords.Append("<td class='cols_' width='120px' align='right'><b>SAI Crime</b></td>");
            sbRecorords.Append("<td class='cols_' width='120px' align='right'><b>Umbrella Premium</b></td>");
            sbRecorords.Append("<td class='cols_' width='180px' align='right'><b>Excess Umbrella Premium</b></td>");
            sbRecorords.Append("<td class='cols_' width='200px' align='right'><b>2nd Layer Umbrella Premium</b></td>");
            sbRecorords.Append("<td class='cols_' width='120px' align='right'><b>EPL Premium</b></td>");
            sbRecorords.Append("<td class='cols_' width='100px' align='right'><b>Cyber</b></td>");
            sbRecorords.Append("<td class='cols_' width='100px' align='right'><b>Pollution</b></td>");
            sbRecorords.Append("<td class='cols_' width='180px' align='right'><b>Risk Management Fee</b></td>");
            sbRecorords.Append("<td class='cols_' width='120px' align='right'><b>Total Actual Cost</b></td>");
            sbRecorords.Append("</tr>");


            for (int i = 0; i < dtReport.Rows.Count; i++)
            {
                int intRes;
                int intDiv = System.Math.DivRem(i, 2, out intRes);
                if (intRes == 0)
                    sbRecorords.Append("<tr align='left' style='font-size:8pt;background-color:#FFFFFF;font-family:Tahoma;'>");
                else
                    sbRecorords.Append("<tr align='left' style='font-size:8pt;background-color:#EAEAEA;font-family:Tahoma;'>");

                DataRow drRecords = dtReport.Rows[i];

                if (Convert.ToString(drRecords["dba"]) == "TOTALS")
                {
                    sbRecorords.Append("<td class='cols_' align='left'>" + Convert.ToString(drRecords["Sonic_Location_Code"]) + "</td>");
                    sbRecorords.Append("<td class='cols_' align='left'><B>" + Convert.ToString(drRecords["dba"]) + "</B></td>");
                    sbRecorords.Append("<td class='cols_' align='left'>" + Convert.ToString(drRecords["State"]) + "</td>");
                    sbRecorords.Append("<td class='cols_' align='right'><B>" + string.Format("{0:N2}", drRecords["Non_Texas_Payroll"]) + "</B></td>");
                    sbRecorords.Append("<td class='cols_' align='right'><B>" + string.Format("{0:N2}", drRecords["Texas_Payroll"]) + "</B></td>");
                    sbRecorords.Append("<td class='cols_' align='right'><B>" + string.Format("{0:N2}", drRecords["Total_PayRoll"]) + "</B></td>");
                    sbRecorords.Append("<td class='cols_' align='right'><B>" + string.Format("{0:N2}", Convert.ToDecimal(drRecords["WC_Premium"])) + "</B></td>");
                    sbRecorords.Append("<td class='cols_' align='right'><B>" + string.Format("{0:N2}", drRecords["Texas_WC_Premium"]) + "</B></td>");
                    sbRecorords.Append("<td class='cols_' align='right'><B>" + string.Format("{0:N2}", drRecords["SAI_WC_Premium"]) + "</B></td>");
                    sbRecorords.Append("<td class='cols_' align='right'><B>" + string.Format("{0:N2}", drRecords["Loss_Fund"]) + "</B></td>");
                    sbRecorords.Append("<td class='cols_' align='right'><B>" + string.Format("{0:N0}", drRecords["Total_Employees"]) + "</B></td>");
                    sbRecorords.Append("<td class='cols_' align='right'><B>" + string.Format("{0:N2}", drRecords["SAI_Garage_Liability"]) + "</B></td>");
                    sbRecorords.Append("<td class='cols_' align='right'><B>" + string.Format("{0:N2}", drRecords["Property_Values"]) + "</B></td>");
                    sbRecorords.Append("<td class='cols_' align='right'><B>" + string.Format("{0:N2}", drRecords["SAI_Property_Premium"]) + "</B></td>");
                    sbRecorords.Append("<td class='cols_' align='right'><B>" + string.Format("{0:N2}", drRecords["SAI_Earthquake_Premium"]) + "</B></td>");
                    sbRecorords.Append("<td class='cols_' align='right'><B>" + string.Format("{0:N2}", drRecords["SAI_Crime"]) + "</B></td>");
                    sbRecorords.Append("<td class='cols_' align='right'><B>" + string.Format("{0:N2}", drRecords["Umbrella_Premium"]) + "</B></td>");
                    sbRecorords.Append("<td class='cols_' align='right'><B>" + string.Format("{0:N2}", drRecords["Excess_Umbrella_Premium"]) + "</B></td>");
                    sbRecorords.Append("<td class='cols_' align='right'><B>" + string.Format("{0:N2}", drRecords["Second_Layer_Umbrella_Premium"]) + "</B></td>");
                    sbRecorords.Append("<td class='cols_' align='right'><B>" + string.Format("{0:N2}", drRecords["EPL_Premium"]) + "</B></td>");
                    sbRecorords.Append("<td class='cols_' align='right'><B>" + string.Format("{0:N2}", drRecords["Cyber"]) + "</B></td>");
                    sbRecorords.Append("<td class='cols_' align='right'><B>" + string.Format("{0:N2}", drRecords["Pollution"]) + "</B></td>");
                    sbRecorords.Append("<td class='cols_' align='right'><B>" + string.Format("{0:N2}", drRecords["Risk_Management_Fee"]) + "</B></td>");
                    sbRecorords.Append("<td class='cols_' align='right'><B>" + string.Format("{0:N2}", drRecords["Total_Actual_Cost"]) + "</B></td>");
                }
                else
                {
                    sbRecorords.Append("<td class='cols_' align='left'>" + Convert.ToString(drRecords["Sonic_Location_Code"]) + "</td>");
                    sbRecorords.Append("<td class='cols_' align='left'>" + Convert.ToString(drRecords["dba"]) + "</td>");
                    sbRecorords.Append("<td class='cols_' align='left'>" + Convert.ToString(drRecords["State"]) + "</td>");
                    sbRecorords.Append("<td class='cols_' align='right'>" + string.Format("{0:N2}", drRecords["Non_Texas_Payroll"]) + "</td>");
                    sbRecorords.Append("<td class='cols_' align='right'>" + string.Format("{0:N2}", drRecords["Texas_Payroll"]) + "</td>");
                    sbRecorords.Append("<td class='cols_' align='right'>" + string.Format("{0:N2}", drRecords["Total_PayRoll"]) + "</td>");
                    sbRecorords.Append("<td class='cols_' align='right'>" + string.Format("{0:N2}", Convert.ToDecimal(drRecords["WC_Premium"])) + "</td>");
                    sbRecorords.Append("<td class='cols_' align='right'>" + string.Format("{0:N2}", drRecords["Texas_WC_Premium"]) + "</td>");
                    sbRecorords.Append("<td class='cols_' align='right'>" + string.Format("{0:N2}", drRecords["SAI_WC_Premium"]) + "</td>");
                    sbRecorords.Append("<td class='cols_' align='right'>" + string.Format("{0:N2}", drRecords["Loss_Fund"]) + "</td>");
                    sbRecorords.Append("<td class='cols_' align='right'>" + string.Format("{0:N0}", drRecords["Total_Employees"]) + "</td>");
                    sbRecorords.Append("<td class='cols_' align='right'>" + string.Format("{0:N2}", drRecords["SAI_Garage_Liability"]) + "</td>");
                    sbRecorords.Append("<td class='cols_' align='right'>" + string.Format("{0:N2}", drRecords["Property_Values"]) + "</td>");
                    sbRecorords.Append("<td class='cols_' align='right'>" + string.Format("{0:N2}", drRecords["SAI_Property_Premium"]) + "</td>");
                    sbRecorords.Append("<td class='cols_' align='right'>" + string.Format("{0:N2}", drRecords["SAI_Earthquake_Premium"]) + "</td>");
                    sbRecorords.Append("<td class='cols_' align='right'>" + string.Format("{0:N2}", drRecords["SAI_Crime"]) + "</td>");
                    sbRecorords.Append("<td class='cols_' align='right'>" + string.Format("{0:N2}", drRecords["Umbrella_Premium"]) + "</td>");
                    sbRecorords.Append("<td class='cols_' align='right'>" + string.Format("{0:N2}", drRecords["Excess_Umbrella_Premium"]) + "</td>");
                    sbRecorords.Append("<td class='cols_' align='right'>" + string.Format("{0:N2}", drRecords["Second_Layer_Umbrella_Premium"]) + "</td>");
                    sbRecorords.Append("<td class='cols_' align='right'>" + string.Format("{0:N2}", drRecords["EPL_Premium"]) + "</td>");
                    sbRecorords.Append("<td class='cols_' align='right'>" + string.Format("{0:N2}", drRecords["Cyber"]) + "</td>");
                    sbRecorords.Append("<td class='cols_' align='right'>" + string.Format("{0:N2}", drRecords["Pollution"]) + "</td>");
                    sbRecorords.Append("<td class='cols_' align='right'>" + string.Format("{0:N2}", drRecords["Risk_Management_Fee"]) + "</td>");
                    sbRecorords.Append("<td class='cols_' align='right'>" + string.Format("{0:N2}", drRecords["Total_Actual_Cost"]) + "</td>");
                }

            }
            sbRecorords.Append("</table>");
            sbRecorords.Append("</div>");
            sbRecorords.Append("</table>");
            trGrid.Visible = true;
        }
        else
        {
            // if record not found then hide Header and set width and height so scroll bar not visible.  
            trGrid.Visible = true;
            sbRecorords.Append("<table style='font-family:Tahoma' cellpadding='4' cellspacing='0' Width='100%'>");
            sbRecorords.Append("<tr style='background-color:#F2F2F2;color:Black;'>");
            sbRecorords.Append("<td align='center' style='font-size:8pt;'>No Records found.</td></tr></table>");
        }

        return sbRecorords;
    }

    public void SavePA_Imported()
    {
        if (PK_PA_Values_Imported != 0)
        {
            clsPA_Values_Imported ObjPA_Values_Imported = new clsPA_Values_Imported();
            ObjPA_Values_Imported.PK_PA_Values_Imported = PK_PA_Values_Imported;
            if (drpLocation.SelectedIndex > 0)
            {
                LU_Location objlocation = new LU_Location(Convert.ToDecimal(drpLocation.SelectedValue));
                if (objlocation.Sonic_Location_Code != null)
                    ObjPA_Values_Imported.Sonic_Location_Code = objlocation.Sonic_Location_Code;
            }
            ObjPA_Values_Imported.Year = Convert.ToInt32(ddlYear.SelectedValue);
            if (txtNon_Texas_Payroll.Text != "")
                ObjPA_Values_Imported.Non_Texas_Payroll = Convert.ToDecimal(txtNon_Texas_Payroll.Text);
            if (txtTexas_Payroll.Text != "")
                ObjPA_Values_Imported.Texas_Payroll = Convert.ToDecimal(txtTexas_Payroll.Text);
            if (txtNumber_Of_Employees.Text != "")
                ObjPA_Values_Imported.Number_Of_Employees = Convert.ToInt32(txtNumber_Of_Employees.Text.ToString().Replace(",", ""));
            ObjPA_Values_Imported.Updated_By = clsSession.UserName;
            ObjPA_Values_Imported.Update();
        }
    }

    /// <summary>
    /// Fill Year Drop Down
    /// </summary>
    private void FillYear()
    {
        ComboHelper.FillYearPremiumAllocation(new DropDownList[] { ddlYear }, true);
    }


    #endregion
    protected void drpLocation_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataTable dtResult = clsPA_Screen_Fields.PA_Values_Imported_SelectByYearAndLocation(Convert.ToInt32(ddlYear.SelectedValue), Convert.ToDecimal(drpLocation.SelectedValue)).Tables[0];

        if (dtResult != null && dtResult.Rows.Count > 0)
        {
            txtNon_Texas_Payroll.Text = dtResult.Rows[0]["Non_Texas_Payroll"].ToString();
            txtTexas_Payroll.Text = dtResult.Rows[0]["Texas_Payroll"].ToString();
            txtNumber_Of_Employees.Text = dtResult.Rows[0]["Number_Of_Employees"].ToString();
            PK_PA_Values_Imported = Convert.ToDecimal(dtResult.Rows[0]["PK_PA_Values_Imported"]);
        }
        else
        {
            txtNon_Texas_Payroll.Text = string.Empty;
            txtTexas_Payroll.Text = string.Empty;
            txtNumber_Of_Employees.Text = string.Empty;
        }
    }
}