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
using System.Text;
using System.IO;
using ERIMS.DAL;


public partial class UserAccessRequest_UANewUserApprovedDenied : clsBasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
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
        lblReport.Text = GenerageNewUserApprovedDeniedReport().ToString();
    }

    /// <summary>
    /// Handles Clear Criteria button click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnClearCriteria_Click(object sender, EventArgs e)
    {
        txtDateApprovedDeniedBegin.Text = string.Empty;
        txtDateApprovedDeniedEnd.Text = string.Empty;
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
        GridViewExportUtil.ExportGrid("New User Approved/Denied Report.xlsx", lblReport);
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
        //lblHeading.Text = "New User Approved/Denied Report";
    }
    #endregion

    #region Methods


    private System.Text.StringBuilder GenerageNewUserApprovedDeniedReport()
    {

        DataSet dsReport = clsNewUserApprovedDeniedReport.GetNewUserApprovedDeniedReport(Convert.ToDateTime(txtDateApprovedDeniedBegin.Text), Convert.ToDateTime(txtDateApprovedDeniedEnd.Text));

        // get data tables from dataset


        DataTable dtRegions = dsReport.Tables[0];
        System.Text.StringBuilder sbRecorords = new System.Text.StringBuilder("");
        trCriteria.Visible = false;
        tblReport.Visible = true;
        lbtExportToExcel.Visible = dtRegions.Rows.Count > 0;
        btnBack.Visible = true;
        // Check if record found or not.
        if (dtRegions.Rows.Count > 0)
        {
            sbRecorords.Append("<style type='text/css'></style><table cellpadding='0' cellspacing='0'  Width='100%px'><tr><td class='cols_' >");

            sbRecorords.Append("<table style='padding-left:4px;font-size:8.5pt;font-family:Tahoma' cellpadding='4' cellspacing='0' Width='996px'>");
            sbRecorords.Append("<tr style='font-weight: bold;background-color:#7f7f7f;color:White;font-size:11pt;height:25'>");
            sbRecorords.Append("<td align='left' style='font-size:9pt'  colspan='8'>New User Approved/Denied Report: " + DateTime.Now.ToString("MM/dd/yyy HH:mm tt") + "</td></tr>");
            //sbRecorords.Append("<tr align='left'  style='font-weight: bold;background-color:#7f7f7f;color:White;font-size:8.5pt'>");
            //sbRecorords.Append("<td ></td>");
            //sbRecorords.Append("<td ></td>");
            //sbRecorords.Append("<td ></td>");
            //sbRecorords.Append("</tr>");
            sbRecorords.Append("<tr><td align='left' style='font-size:9pt'  colspan='8'><b> Filter Conditions :  </b></td></tr>");
            sbRecorords.Append("<tr><td align='left' style='font-size:9pt'  colspan='8'><b>Date Approved/Denied Begin: </b>" + txtDateApprovedDeniedBegin.Text + "</td></tr>");
            sbRecorords.Append("<tr><td align='left' style='font-size:9pt'  colspan='8'><b>New User Approved/Denied Report: </b>" + txtDateApprovedDeniedEnd.Text + "</td></tr>");
            //sbRecorords.Append("<tr align='left'  style='font-weight: bold;background-color:#7f7f7f;color:White;font-size:8.5pt'>");
            //sbRecorords.Append("<td ></td>");
            //sbRecorords.Append("<td ></td>");
            //sbRecorords.Append("<td ></td>");
            //sbRecorords.Append("</tr>");
            sbRecorords.Append("<tr><td align='left' style='font-size:9pt'  colspan='8'><b> Report Columns :  </b></td></tr>");
            sbRecorords.Append("<tr align='left'  style='font-weight: bold;background-color:#7f7f7f;color:White;font-size:8.5pt'>");
            sbRecorords.Append("<td class='cols_' width='12.5%'>Last Name</td>");
            sbRecorords.Append("<td class='cols_' width='12.5%'>First Name</td>");
            sbRecorords.Append("<td class='cols_' width='12.5%'align='left'>Status</td>");
            sbRecorords.Append("<td class='cols_' width='12.5%'align='left'>Employee Id</td>");
            sbRecorords.Append("<td class='cols_' width='12.5%'align='left'>Email</td>");
            sbRecorords.Append("<td class='cols_' width='12.5%'align='left'>Telephone</td>");
            sbRecorords.Append("<td class='cols_' width='12.5%'align='left'>Location D/B/A</td>");
            sbRecorords.Append("<td class='cols_' width='12.5%'align='left'>Update Date</td>");
            sbRecorords.Append("</tr>");
            for (int intI3 = 0; intI3 < dtRegions.Rows.Count; intI3++)
            {
                DataRow drRecords = dtRegions.Rows[intI3];
                int intRes;
                int intDiv = System.Math.DivRem(intI3, 2, out intRes);
                if (intRes == 0)
                    sbRecorords.Append("<tr border='1' align='left' style='font-size:8pt;background-color:#EAEAEA;font-family:Tahoma;'>");
                else
                    sbRecorords.Append("<tr border='1' align='left' style='font-size:8pt;background-color:#FFFFFF;font-family:Tahoma;'>");

                sbRecorords.Append("<td  class='cols_' align='left' style='word-wrap:normal;word-break:break-all'>" + Convert.ToString(drRecords["Last_Name"]) + "</td>");
                sbRecorords.Append("<td class='cols_' style='word-wrap:normal;word-break:break-all'>" + Convert.ToString(drRecords["First_Name"]) + "</td>");
                sbRecorords.Append("<td class='cols_' align='left' style='word-wrap:normal;word-break:break-all'>" + Convert.ToString(drRecords["Status"]) + "</td>");
                sbRecorords.Append("<td class='cols_' align='left' style='word-wrap:normal;word-break:break-all'>" + Convert.ToString(drRecords["Employee_Id"]) + "</td>");
                sbRecorords.Append("<td class='cols_' align='left' style='word-wrap:normal;word-break:break-all'>" + Convert.ToString(drRecords["Email"]) + "</td>");
                sbRecorords.Append("<td class='cols_' align='left' style='word-wrap:normal;word-break:break-all'>" + Convert.ToString(drRecords["Telephone"]) + "</td>");
                sbRecorords.Append("<td class='cols_' align='left' style='word-wrap:normal;word-break:break-all'>" + Convert.ToString(drRecords["dba"]) + "</td>");
                sbRecorords.Append("<td class='cols_' align='left' style='word-wrap:normal;word-break:break-all'>" + Convert.ToString(drRecords["Update_Date"]) + "</td>");
                sbRecorords.Append("</tr>");
            }
            // sbRecorords.Append("<tr><td colspan='7' class='cols_'>&nbsp;</td></tr>");
            sbRecorords.Append("</table>");
            // sbRecorords.Append("</div>");
            sbRecorords.Append("</td></tr></table>");
            trGrid.Visible = true;
        }
        else
        {
            // if record not found then hide Header and set width and height so scroll bar not visible.            
            trGrid.Visible = false;
            sbRecorords.Append("<table style='font-family:Tahoma' cellpadding='4' cellspacing='0' Width='100%'>");
            sbRecorords.Append("<tr style='background-color:#F2F2F2;color:Black;'>");
            sbRecorords.Append("<td align='center' style='font-size:9pt;'>No Records found.</td></tr></table>");
        }
        return sbRecorords;
    }

    #endregion


}
