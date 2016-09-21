using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ERIMS.DAL;
using System.Text;
using System.IO;

public partial class Administrator_rptLog_Audit : clsBasePage
{    
        #region "Page Event"

    /// <summary>
    /// page load Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {           
            BindDropdown();
            this.drpUser.Focus();
            pnlFilters.Visible = true;
            pnlReport.Visible = false;

        }
    }

    #endregion

    #region "Methods"

    /// <summary>
    /// This method is added for export Girdview To Excel which contains SubGridview.
    /// </summary>
    /// <param name="control"></param>
    public override void VerifyRenderingInServerForm(Control control)
    {
        return;
    }

    /// <summary>
    /// Bind Drop Down
    /// </summary>
    private void BindDropdown()
    {
        DataSet dsUser = new DataSet();
        dsUser = Login_Logout.SecuritySelectAll();

        drpUser.Items.Clear();
        drpUser.DataTextField = "drpValue";
        drpUser.DataValueField = "PK_Security_ID";
        drpUser.DataSource = dsUser.Tables[0].DefaultView;
        drpUser.DataBind();
    }

    /// <summary>
    /// Method to generate report
    /// </summary>
    /// <param name="strCols"></param>
    /// <param name="IsForExcel"></param>
    /// <returns></returns>
    protected string GenerateReport(string strCols, bool IsForExcel)
    {
        DateTime Begin_Date = DateTime.MinValue;
        DateTime End_Date = DateTime.MinValue;
        if (!string.IsNullOrEmpty(txtBegin_Date.Text))
            Begin_Date = Convert.ToDateTime(txtBegin_Date.Text);

        if (!string.IsNullOrEmpty(txtEnd_Date.Text))
            End_Date = Convert.ToDateTime(txtEnd_Date.Text);
        string strSecurity = Request.Form[drpUser.UniqueID];
        DataSet dsLogAudit = Login_Logout.SearchLogAudit(strSecurity, Begin_Date, End_Date);
        StringBuilder strReport = new StringBuilder();
        if ((dsLogAudit != null) && (dsLogAudit.Tables.Count > 0) && (dsLogAudit.Tables[0].Rows.Count > 0))
        {
            string styleHeader = "";
            if (!IsForExcel)
                styleHeader = "background-color:#7f7f7f;color:white;";
            else
                styleHeader = "border:black 1px solid;";
            strReport.Append("<style type='text/css'> .cols_{" + strCols + " }</style>");
            strReport.Append("<table cellpadding='5' cellspacing='0' width='100%'>");
            strReport.Append("<tr><td colspan='2' style='" + styleHeader + "'></td><td style='" + styleHeader + "' colspan='3' align='center'><b>Login Audit</b></td><td align='right' colspan='2' style='" + styleHeader + "'><b>Run Date/Time : " + DateTime.Now.ToString("MM/dd/yyyy HH:mm tt") + "</b></td></tr>");
            strReport.Append("<tr><td align='left' valign='top' style='" + styleHeader + "' width='12%'><b>Last Name</b></td><td style='" + styleHeader + "' align='left' valign='top' width='11%'><b>First Name</b></td><td style='" + styleHeader + "' align='left' valign='top' width='12%'><b>User Name</b></td><td style='" + styleHeader + "' align='left' valign='top' width='20%'><b>Session Id</b></td><td style='" + styleHeader + "' align='left' valign='top' width='10%'><b>IP Address</b></td><td style='" + styleHeader + "' align='left' valign='top' width='15%'><b>Login Date/Time</b></td><td style='" + styleHeader + "' align='left' valign='top' width='20%'><b>Logout Date/Time</b></td></tr>");
            string style2 = "border-top:#EAEAEA 1px solid;color:#333333;background-color:white;font-family:Tahoma;font-size:8pt;";
            string style1 = "border-top:#EAEAEA 1px solid;color:#333333;background-color:#eaeaea;font-family:Tahoma;font-size:8pt;";
            bool IsRowOdd = true;
            for (int i = 0; i <= (dsLogAudit.Tables[0].Rows.Count - 1); i++)
            {
                string style = "";
                if (!IsForExcel)
                {
                    if (IsRowOdd)
                        style = style1;
                    else
                        style = style2;
                    IsRowOdd = !IsRowOdd;
                }
                strReport.Append("<tr>");
                strReport.Append("<td align='left' class='cols_' style='" + style + "' valign='top'>" + Convert.ToString(dsLogAudit.Tables[0].Rows[i]["LAST_NAME"]) + "</td>");
                strReport.Append("<td align='left' class='cols_' style='" + style + "'  valign='top'>" + Convert.ToString(dsLogAudit.Tables[0].Rows[i]["FIRST_NAME"]) + "</td>");
                strReport.Append("<td align='left' class='cols_' style='" + style + "'  valign='top'>" + Convert.ToString(dsLogAudit.Tables[0].Rows[i]["USER_NAME"]) + "</td>");
                strReport.Append("<td align='left' class='cols_' style='" + style + "'  valign='top'>" + Convert.ToString(dsLogAudit.Tables[0].Rows[i]["Session_Id"]) + "</td>");
                strReport.Append("<td align='left' class='cols_' style='" + style + "'  valign='top'>" + Convert.ToString(dsLogAudit.Tables[0].Rows[i]["IP_Address"]) + "</td>");
                strReport.Append("<td align='left' class='cols_' style='" + style + "'  valign='top'>&nbsp;" + Convert.ToString(dsLogAudit.Tables[0].Rows[i]["Login_Date"]) + "</td>");
                strReport.Append("<td align='left' class='cols_' style='" + style + "'  valign='top'>&nbsp;" + Convert.ToString(dsLogAudit.Tables[0].Rows[i]["Logout_Date"]) + "</td>");
                strReport.Append("</tr>");
            }
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
        txtBegin_Date.Text = string.Empty;
        txtEnd_Date.Text = string.Empty;
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
        bool blnHTML2Excel = false;
        String strHTML, strFilePath, outputFiles = string.Empty;

        strHTML = ltrReport.Text;
        strFilePath = AppConfig.SitePath + @"temp\" + DateTime.Now.ToString("ddMMyyyyhhmmss");

        if (!File.Exists(strFilePath))
        {
            if (!Directory.Exists(AppConfig.SitePath + @"temp\"))
                Directory.CreateDirectory(AppConfig.SitePath + @"temp\");

            // Create a file to write to.
            using (StreamWriter sw = File.CreateText(strFilePath))
            {
                sw.Write(strHTML.ToString());
                strHTML = string.Empty;
            }
        }

        if (File.Exists(strFilePath))
        {
            string data = File.ReadAllText(strFilePath);
            data = data.Trim();
            HTML2Excel objHtml2Excel = new HTML2Excel(data);
            objHtml2Excel.isGrid = true;
            objHtml2Excel.isUseCSS = false;
            outputFiles = Path.GetFullPath(strFilePath) + ".xlsx";
            blnHTML2Excel = objHtml2Excel.Convert2Excel(outputFiles);
        }

        //If records found
        if (blnHTML2Excel)
        {
            try
            {
                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.AddHeader("content-disposition", string.Format("attachment; filename=\"" + "Log_Audit.xlsx" + "\""));
                HttpContext.Current.Response.ContentType = "application/ms-excel";
                HttpContext.Current.Response.TransmitFile(outputFiles);
                HttpContext.Current.Response.Flush();
            }
            finally
            {
                if (File.Exists(outputFiles))
                    File.Delete(outputFiles);
                if (File.Exists(strFilePath))
                    File.Delete(strFilePath);
                HttpContext.Current.Response.End();
            }
        }
    }

    #endregion
}