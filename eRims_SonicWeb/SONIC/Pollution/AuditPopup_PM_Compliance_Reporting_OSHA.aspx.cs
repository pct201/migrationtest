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

public partial class SONIC_Pollution_AuditPopup_PM_Compliance_Reporting_OSHA : System.Web.UI.Page
{
    # region " Properties "

    /// <summary>
    /// Used To manupulate primary key Parameter
    /// </summary>
    public int PK
    {
        get { return (!clsGeneral.IsNull(Request.QueryString["id"]) ? Convert.ToInt32(Request.QueryString["id"]) : -1); }
    }

    #endregion

    #region "Page Event"
    /// <summary>
    /// Page Load Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            divComplianceReportingOSHA_Grid.Visible = false;
            divComplianceReportingOSHA_Header.Visible = false;
            // Check if parameter id and table name is exists or not.
            if (Request.QueryString["id"] != null)
            {
                // Check Table_name parameter and as per table_name show Audit trial for that table
                BindComplianceReportingOSHA_Audit();
            }
        }
    }
    #endregion

    #region "Mehods"
    /// <summary>
    /// this function is use full when Audit trail is from Franchise Table 
    /// </summary>
    private void BindComplianceReportingOSHA_Audit()
    {
        DataTable dt = new DataTable();
        // show Case Grid 
        divComplianceReportingOSHA_Grid.Visible = true;
        lbltable_Name.Text = "PM Compliance Reporting Osha";
        // Fill grid with audit table
        dt = AuditTrail.GetAuditOSHALogView(PK).Tables[0];
        gvPMComplianceReportingOSHA.DataSource = dt;
        gvPMComplianceReportingOSHA.DataBind();
        // Check if record found or not.
        if (dt.Rows.Count > 0)
        {
            // set Gridview div height and width on client side. 
            Page.ClientScript.RegisterStartupScript(Page.GetType(), System.DateTime.Now.ToString(), "javacript:showAudit(" + divComplianceReportingOSHA_Header.ClientID + "," + divComplianceReportingOSHA_Grid.ClientID + ");", true);

            // set Gridview div Scroll bar events so Scroll Header as per grid scroll
            divComplianceReportingOSHA_Grid.Attributes.Add("onscroll", "javascript:ChangeScrollBar(this," + divComplianceReportingOSHA_Header.ClientID + ");");
            divComplianceReportingOSHA_Header.Visible = true;
        }
        else
        {
            // if record not found then hide Header and set width and height so scroll bar not visible.
            divComplianceReportingOSHA_Grid.Style["height"] = Unit.Pixel(50).ToString();
            divComplianceReportingOSHA_Grid.Style["width"] = "100%";
            divComplianceReportingOSHA_Grid.Style["overflow"] = "hidden";
        }
        dt.Dispose();
        dt = null;
    }

    public string CheckStatus(object myValue)
    {
        if (myValue.ToString() == "Y")
        {
            return "Yes";
        }
        else if (myValue.ToString() == "N")
        {
            return "No";
        }
        else
        {
            return string.Empty;
        }
    }
    #endregion
}