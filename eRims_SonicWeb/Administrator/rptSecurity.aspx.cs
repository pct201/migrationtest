using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ERIMS.DAL;
using System.Text;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using System.IO;
public partial class Administrator_rptSecurity : clsBasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindDropdownForAll();
            this.drpUser.Focus();
            pnlFilters.Visible = true;
            pnlReport.Visible = false;
        }
    }

    #region for methods

    /// <summary>
    /// Bind Drop Down for Username,Location,Region
    /// </summary>
    /// 
    //that is for user name

    public override void VerifyRenderingInServerForm(Control control)
    {
        return;
    }

    private void BindDropdownForAll()
    {
        DataSet dsUser = new DataSet();
        dsUser = Report.SecurityAll();
        drpUser.Items.Clear();
        drpUser.DataTextField = "drpValue";
        drpUser.DataValueField = "PK_Security_ID";
        drpUser.DataSource = dsUser.Tables[0].DefaultView;
        drpUser.DataBind();

        //DataSet dsUser = new DataSet();
        dsUser = Report.SecurityLoc();
        drpLocation.Items.Clear();
        drpLocation.DataTextField = "dba";
        drpLocation.DataValueField = "PK_LU_Location_ID";
        drpLocation.DataSource = dsUser.Tables[0].DefaultView;
        drpLocation.DataBind();


        //DataSet dsUser2 = new DataSet();
        dsUser = Report.SecurityReg();
        drpRegion.Items.Clear();
        drpRegion.DataTextField = "Region";
        drpRegion.DataValueField = "Region";
        drpRegion.DataSource = dsUser.Tables[0].DefaultView;
        drpRegion.DataBind();
    }


    /// <summary>
    /// Method to generate report
    /// </summary>
    /// <param name="strCols"></param>
    /// <param name="IsForExcel"></param>
    /// <returns></returns>
    protected string GenerateReport(string strCols, bool IsForExcel)
    {

        string strSecurity = Request.Form[drpUser.UniqueID];
        string strregion = "'" + Request.Form[drpRegion.UniqueID] + "'";
        if (strregion == "''")
            strregion = null;
        string strLocation = Request.Form[drpLocation.UniqueID];

        //DataSet dsLogAudit = Login_Logout.SearchSecurityReport(strSecurity, strregion,strLocation);
        DataSet dsLogAudit = Report.SearchSecurityReport(strSecurity, strregion, strLocation);
        StringBuilder strReport = new StringBuilder();
        if ((dsLogAudit != null) && (dsLogAudit.Tables.Count > 0) && (dsLogAudit.Tables[0].Rows.Count > 0))
        {
            strReport.Append("<style type='text/css'></style><table border='0' style='border: black 0.5px solid;border-collapse: collapse;' cellpadding='0' cellspacing='0'  Width='100%px'><tr><td class='cols_' >");
            strReport.Append("<div style='overflow-x: scroll;overflow-y:hidden; width: 990px; height: 100%;'>");
            strReport.Append("<table style='padding-left:4px;font-size:8.5pt;font-family:Tahoma' cellpadding='5' cellspacing='0' width='2960px'>");
            strReport.Append("<tr style='font-weight: bold;background-color:#7f7f7f;color:White;font-size:9pt;height:25'>");
            strReport.Append("<td colspan='3'>&nbsp;</td>");
            strReport.Append("<td style='font-size:9pt;' colspan='3' align='Right'><b>User Report</b></td>");
            strReport.Append("<td align='center' colspan='2'></td>");
            strReport.Append("<td align='right' colspan='5' style='font-size:9pt;'><b>Run Date/Time : " + DateTime.Now.ToString("MM/dd/yyyy HH:mm tt") + "</b></td></tr>");
            strReport.Append("<tr style='font-weight: bold;background-color:#7f7f7f;color:White;font-size:8.5pt;height:25'>");

            strReport.Append("<td align='left' valign='top' style='font-size:9pt;width:120px;' class='cols_'><b>Last Name</b></td><td style='font-size:9pt;width:120px;' class='cols_' align='left' valign='top'><b>First Name</b></td><td style='font-size:9pt;width:120px;' class='cols_' align='left' valign='top' class='cols_'><b>User Name</b></td><td style='font-size:9pt;width:120px;' align='left' valign='top' class='cols_'><b>Phone</b></td><td style='font-size:9pt;width:130px;' align='left' valign='top' class='cols_'><b>Email</b></td><td style='font-size:9pt;width:100px;' align='left' valign='top' class='cols_'><b>Employee Id</b></td><td style='font-size:9pt;width:180px;' align='left' valign='top' class='cols_'><b>Region</b></td><td style='font-size:9pt;width:150px;' align='left' valign='top' class='cols_'><b>Location</b></td><td style='font-size:9pt;width:130px;' align='left' valign='top' class='cols_'><b>Is Regional Officer</b></td><td style='font-size:9pt;width:130px;' align='left' valign='top' class='cols_'><b>Report Type </b></td><td style='font-size:9pt;width:130px;' align='left' valign='top' class='cols_'><b>Corporate user</b></td><td style='font-size:9pt;width:500px;' align='left' valign='top' class='cols_'><b>User Rights</b></td><td style='font-size:9pt;width:1000px;' align='left' valign='top' class='cols_'><b>FROI E-Mail Locations</b></td></tr>");
            
            for (int i = 0; i <= (dsLogAudit.Tables[0].Rows.Count - 1); i++)
            {
                string style = "";
                int intRes;
                int intDiv = System.Math.DivRem(i, 2, out intRes);
                if (intRes == 0)
                    style = "font-size:8pt;background-color:#EAEAEA;font-family:Tahoma;";
                else
                    style = "font-size:8pt;background-color:#FFFFFF;font-family:Tahoma;";

                strReport.Append("<tr>");
                strReport.Append("<td align='left' class='cols_' style='" + style + "width:120px;' valign='top'>" + Convert.ToString(dsLogAudit.Tables[0].Rows[i]["LAST_NAME"]) + "</td>");
                strReport.Append("<td align='left' class='cols_' style='" + style + "width:120px;'  valign='top'>" + Convert.ToString(dsLogAudit.Tables[0].Rows[i]["FIRST_NAME"]) + "</td>");
                strReport.Append("<td align='left' class='cols_' style='" + style + "width:120px;'  valign='top'>" + Convert.ToString(dsLogAudit.Tables[0].Rows[i]["USER_NAME"]) + "</td>");
                strReport.Append("<td align='left' class='cols_' style='" + style + "width:120px;'  valign='top'>" + Convert.ToString(dsLogAudit.Tables[0].Rows[i]["Phone"]) + "</td>");
                strReport.Append("<td align='left' class='cols_' style='" + style + "width:130px;'  valign='top'>" + Convert.ToString(dsLogAudit.Tables[0].Rows[i]["Email"]) + "</td>");
                strReport.Append("<td align='left' class='cols_' style='" + style + "width:100px;'  valign='top'>&nbsp;" + Convert.ToString(dsLogAudit.Tables[0].Rows[i]["Employee_Id"]) + "</td>");
                strReport.Append("<td align='left' class='cols_' style='" + style + "width:180px;'  valign='top'>&nbsp;" + Convert.ToString(dsLogAudit.Tables[0].Rows[i]["Region"]) + "</td>");
                strReport.Append("<td align='left' class='cols_' style='" + style + "width:150px;'  valign='top'>&nbsp;" + Convert.ToString(dsLogAudit.Tables[0].Rows[i]["dba"]) + "</td>");
                strReport.Append("<td align='left' class='cols_' style='" + style + "width:130px;'  valign='top'>&nbsp;" + Convert.ToString(dsLogAudit.Tables[0].Rows[i]["IsRegionalOfficer"]) + "</td>");
                strReport.Append("<td align='left' class='cols_' style='" + style + "width:130px;'  valign='top'>&nbsp;" + Convert.ToString(dsLogAudit.Tables[0].Rows[i]["AllowedReportType"]) + "</td>");
                strReport.Append("<td align='left' class='cols_' style='" + style + "width:130px;'  valign='top'>&nbsp;" + Convert.ToString(dsLogAudit.Tables[0].Rows[i]["Corporate_User"]) + "</td>");
                strReport.Append("<td align='left' class='cols_' style='" + style + "width:500px;'  valign='top'>&nbsp;" + Convert.ToString(dsLogAudit.Tables[0].Rows[i]["User_Rights"]) + "</td>");
                strReport.Append("<td align='left' class='cols_' style='" + style + "width:1000px;'  valign='top'>&nbsp;" + Convert.ToString(dsLogAudit.Tables[0].Rows[i]["FROI_Locations"]) + "</td>");
                strReport.Append("</tr>");
            }
            strReport.Append("</table>");
            strReport.Append("</div>");
            strReport.Append("</table>");

            btnExcel.Visible = true;
        }
        else
        {
            strReport.Append("<table width='100%'><tr><td align='center'>No Record Found!</td></tr></table>");
            btnExcel.Visible = false;
        }
        return strReport.ToString();
    }

    #endregion
    #region "Events"

    /// <summary>
    /// Button Click Event - Click to Generate report
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnReport_Click(object sender, EventArgs e)
    {
        pnlFilters.Visible = false;
        pnlReport.Visible = true;
        string strcols = "vertical-align: top;padding-right: 2px;padding-left: 4px;font-size: 8pt;border-collapse: collapse;";
        ltrReport.Text = GenerateReport(strcols, false);

    }

    /// <summary>
    /// Clears the filter criteria
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnClearCriteria_Click(object sender, EventArgs e)
    {
        drpUser.ClearSelection();
        drpLocation.ClearSelection();
        drpRegion.ClearSelection();
    }

    /// <summary>
    /// Show the filters again
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnBack_Click(object sender, EventArgs e)
    {
        pnlFilters.Visible = true;
        pnlReport.Visible = false;
        ltrReport.Text = string.Empty;
    }

    /// <summary>
    /// Export to excel button click event handler
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnExcel_Click(object sender, EventArgs e)
    {
        string strcols = "border: #7f7f7f 1px solid;vertical-align: top;font-size: 8pt;border-collapse: collapse;";
        System.IO.StringWriter stringWrite = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter htmlWrite = new System.Web.UI.HtmlTextWriter(stringWrite);

        ltrReport.RenderControl(htmlWrite);
        
        MemoryStream memorystream = new MemoryStream();
        byte[] _bytes = Encoding.UTF8.GetBytes(stringWrite.ToString().Replace("border-top:#EAEAEA", "border-top:#000000").Replace("<style type='text/css'></style>", "<style type='text/css'> .cols_{" + strcols + " }</style>"));
        memorystream.Write(_bytes, 0, _bytes.Length);
        memorystream.Seek(0, SeekOrigin.Begin);

        HttpContext.Current.Response.Clear();
        HttpContext.Current.Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "User Report.xls"));
        HttpContext.Current.Response.ContentType = "application/ms-excel";
        HttpContext.Current.Response.Write(stringWrite.ToString().Replace("#EAEAEA", "White").Replace("#eaeaea", "White").Replace("background-color:#C0C0C0", "background-color:White;").Replace("<style type='text/css'></style>", "<style type='text/css'> .cols_{" + strcols + " }</style>").Replace("background-color:#7f7f7f;color:White", "background-color:White;color:Black"));
        HttpContext.Current.Response.End();
    }

    #endregion
}