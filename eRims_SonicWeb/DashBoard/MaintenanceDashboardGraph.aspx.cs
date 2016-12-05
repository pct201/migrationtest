using System;
using System.Data;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Collections;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using ERIMS.DAL;

public partial class DashBoard_MaintenanceDashboardGraph : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ComboHelper.FillLocationdba(new DropDownList[] { ddlRMLocationNumber }, 0, true, true);
            ddlRMLocationNumber.Style.Remove("font-size");
        }
    }
    public decimal LocationID
    {
        get { return (ddlRMLocationNumber.SelectedIndex <= 0 ? 0 : Convert.ToInt32(ddlRMLocationNumber.SelectedIndex)); }
    }

    /// <summary>
    /// Handles event when RM location number dropdown selection changed
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ddlRMLocationNumber_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetPriorityWiseActiveUsers();
        GetAssigneeWiseActiveUsers();
        GetTop10CustomersWiseActiveUsers();
    }
    
    public string GetPriorityWiseActiveUsers()
    {
        StringBuilder strXML = new StringBuilder();
        DataSet ds = Charts.GetPriorityWiseActiveUsers(Convert.ToDecimal(ddlRMLocationNumber.SelectedValue));
        // Get Result for facility inspection Region
        DataTable dtResult = ds.Tables[0];

        strXML.Append("<chart caption='Active Tickets by Company & Priority' xaxisname='Sonic Automotive Facilities' yaxisname='Counts and Average' plotfillalpha='80' palettecolors='#5B9BD5,#ED7D31' basefontcolor='#333333' basefont='Helvetica Neue,Arial' captionfontsize='14' subcaptionfontsize='14' subcaptionfontbold='0' showborder='0' bgcolor='#ffffff' showshadow='0' divlinealpha='100' divlinecolor='#999999' divlinethickness='1' divlineisdashed='1' divlinedashlen='1' divlinegaplen='1' useplotgradientcolor='0' showplotborder='0' valuefontcolor='#ffffff' placevaluesinside='1' showhovereffect='1' rotatevalues='1' showxaxisline='1' xaxislinethickness='1' xaxislinecolor='#999999' showalternatehgridcolor='0' legendbgalpha='0' legendborderalpha='0' legendshadow='0' legenditemfontsize='10' legenditemfontcolor='#666666'>");
        // Set Label
        strXML.Append("<categories>");
        for (int i = 0; i < dtResult.Rows.Count; i++)
        {
            strXML.Append("<category label='" + dtResult.Rows[i]["Description"] + "' />");
        }
        strXML.Append("</categories>");

        // Set Value for first data series

        strXML.Append("<dataset seriesname='Data Count of Priority'>");
        for (int i = 0; i < dtResult.Rows.Count; i++)
        {
            strXML.Append("<set value='" + dtResult.Rows[i]["Status_Count"] + "' />");
        }
        strXML.Append("</dataset>");

        strXML.Append("<dataset seriesname='Data Average of Age'>");
        for (int i = 0; i < dtResult.Rows.Count; i++)
        {
            strXML.Append("<set value='" + dtResult.Rows[i]["Average_Time"] + "' />");
        }
        strXML.Append("</dataset>");

        strXML.Append("</chart>");

        return InfoSoftGlobal.FusionCharts.RenderChart(AppConfig.SiteURL + "FusionCharts/MSColumn2D.swf?ChartNoDataText=No data to display for: Saba Training Scoreboard By Region", "", strXML.ToString(), "GetPriorityWiseActiveUsers", "490", "400", false, true);
    }

    public string GetAssigneeWiseActiveUsers()
    {
        StringBuilder strXML = new StringBuilder();
        DataSet ds = Charts.GetAssigneeWiseActiveUsers(Convert.ToDecimal(ddlRMLocationNumber.SelectedValue));
        // Get Result for facility inspection Region
        DataTable dtResult = ds.Tables[0];

        strXML.Append("<chart caption='Active Tickets by Company & Assignee' xaxisname='Sonic Automotive Facilities' yaxisname='Counts and Average' plotfillalpha='80' palettecolors='#5B9BD5,#ED7D31' basefontcolor='#333333' basefont='Helvetica Neue,Arial' captionfontsize='14' subcaptionfontsize='14' subcaptionfontbold='0' showborder='0' bgcolor='#ffffff' showshadow='0' divlinealpha='100' divlinecolor='#999999' divlinethickness='1' divlineisdashed='1' divlinedashlen='1' divlinegaplen='1' useplotgradientcolor='0' showplotborder='0' valuefontcolor='#ffffff' placevaluesinside='1' showhovereffect='1' rotatevalues='1' showxaxisline='1' xaxislinethickness='1' xaxislinecolor='#999999' showalternatehgridcolor='0' legendbgalpha='0' legendborderalpha='0' legendshadow='0' legenditemfontsize='10' legenditemfontcolor='#666666'>");
        // Set Label
        strXML.Append("<categories>");
        for (int i = 0; i < dtResult.Rows.Count; i++)
        {
            strXML.Append("<category label='" + dtResult.Rows[i]["Assignee"] + "' />");
        }
        strXML.Append("</categories>");

        // Set Value for first data series

        strXML.Append("<dataset seriesname='Data Count of Priority'>");
        for (int i = 0; i < dtResult.Rows.Count; i++)
        {
            strXML.Append("<set value='" + dtResult.Rows[i]["Status_Count"] + "' />");
        }
        strXML.Append("</dataset>");

        strXML.Append("<dataset seriesname='Data Average of Age'>");
        for (int i = 0; i < dtResult.Rows.Count; i++)
        {
            strXML.Append("<set value='" + dtResult.Rows[i]["Average_Time"] + "' />");
        }
        strXML.Append("</dataset>");

        strXML.Append("</chart>");

        return InfoSoftGlobal.FusionCharts.RenderChart(AppConfig.SiteURL + "FusionCharts/MSColumn2D.swf?ChartNoDataText=No data to display for: Saba Training Scoreboard By Region", "", strXML.ToString(), "GetAssigneeWiseActiveUsers", "490", "400", false, true);
    }

    public string GetTop10CustomersWiseActiveUsers()
    {
        StringBuilder strXML = new StringBuilder();
        DataSet ds = Charts.GetTop10CustomersWiseActiveUsers(Convert.ToDecimal(ddlRMLocationNumber.SelectedValue));
        // Get Result for facility inspection Region
        DataTable dtResult = ds.Tables[0];

        strXML.Append("<chart caption='Active Tickets by Company & Top 10 Customers' xaxisname='Sonic Automotive Facilities' yaxisname='Counts and Average' plotfillalpha='80' palettecolors='#5B9BD5,#ED7D31' basefontcolor='#333333' basefont='Helvetica Neue,Arial' captionfontsize='14' subcaptionfontsize='14' subcaptionfontbold='0' showborder='0' bgcolor='#ffffff' showshadow='0' divlinealpha='100' divlinecolor='#999999' divlinethickness='1' divlineisdashed='1' divlinedashlen='1' divlinegaplen='1' useplotgradientcolor='0' showplotborder='0' valuefontcolor='#ffffff' placevaluesinside='1' showhovereffect='1' rotatevalues='1' showxaxisline='1' xaxislinethickness='1' xaxislinecolor='#999999' showalternatehgridcolor='0' legendbgalpha='0' legendborderalpha='0' legendshadow='0' legenditemfontsize='10' legenditemfontcolor='#666666'>");
        // Set Label
        strXML.Append("<categories>");
        for (int i = 0; i < dtResult.Rows.Count; i++)
        {
            strXML.Append("<category label='" + dtResult.Rows[i]["Customer_Name"] + "' />");
        }
        strXML.Append("</categories>");

        // Set Value for first data series

        strXML.Append("<dataset seriesname='Data Count of Priority'>");
        for (int i = 0; i < dtResult.Rows.Count; i++)
        {
            strXML.Append("<set value='" + dtResult.Rows[i]["Status_Count"] + "' />");
        }
        strXML.Append("</dataset>");

        strXML.Append("<dataset seriesname='Data Average of Age'>");
        for (int i = 0; i < dtResult.Rows.Count; i++)
        {
            strXML.Append("<set value='" + dtResult.Rows[i]["Average_Time"] + "' />");
        }
        strXML.Append("</dataset>");

        strXML.Append("</chart>");

        return InfoSoftGlobal.FusionCharts.RenderChart(AppConfig.SiteURL + "FusionCharts/MSColumn2D.swf?ChartNoDataText=No data to display for: Saba Training Scoreboard By Region", "", strXML.ToString(), "GetTop10CustomerWiseActiveUsers", "490", "400", false, true);
    }
}