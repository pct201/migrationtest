using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;

public partial class DashBoard_ACIEventByLocation : System.Web.UI.Page
{
    StringBuilder strChartXML = new StringBuilder();
    Decimal Average = 0;
    string strlink = string.Empty;

    #region "Property"

    /// <summary>
    /// Get Year parameter
    /// </summary>
    public Int32 Year
    {
        get
        {
            return clsGeneral.GetInt(Request.QueryString["year"]);
        }
    }

    /// <summary>
    /// Get Month parameter
    /// </summary>
    public Int32 Month
    {
        get
        {
            return clsGeneral.GetInt(Request.QueryString["Month"]);
        }
    }

    /// <summary>
    /// Set Region Parameter
    /// </summary>
    public string Region
    {
        get { return (string.IsNullOrEmpty(Request.QueryString["region"]) ? string.Empty : Convert.ToString(Request.QueryString["region"])); }
    }

    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        GetEventByLocation();
    }

    #region "Chart Methods"

    public void GetEventByLocation()
    {
        DataSet dsACI = ERIMS.DAL.clsEvent.GetDashboardDataACIByLocation(Region, Month, Year);

        DataTable dt = dsACI.Tables[0];

        StringBuilder strChartXML = new StringBuilder();

        strChartXML.Append("<chart caption='Monthly Event Percentage by Location' showvalues='0' plotfillalpha='95' labeldisplay='' numberSuffix='%' formatnumberscale='0' plotgradientcolor='' bgcolor='FFFFFF' showalternatehgridcolor='0' showplotborder='0' yAxisMinValue='80' yAxisMaxValue='100'showYAxisValues='0' divlinecolor='CCCCCC' showcanvasborder='0' legendborderalpha='0' legendshadow='0' showpercentvalues='1' stack100percent='1' canvasborderalpha='0' palettecolors='#FD9927,#FECE2F,#9DCD3F,#CECD42,#64D3D1' use3DLighting='1' labelDisplay='ROTATE' maxColWidth='60'>");
        
        strChartXML.Append("<categories>");

        for (int i = 0; i < dt.Rows.Count; i++)
        {
            strChartXML.Append("<category label='" + dt.Rows[i]["Location"].ToString().Replace("'", " ") + "' />");
        }

        strChartXML.Append("</categories>");

        strChartXML.Append("<dataset seriesname='ACI Events' color='006600'>");
        for (int j = 0; j < dt.Rows.Count; j++)
        {
            strChartXML.AppendFormat("<set value='{0}' link='{1}'/>", dt.Rows[j]["ACI_Event_Percent"], Server.UrlEncode("JavaScript:OpenPopup(\"" + dt.Rows[j]["FK_LU_Location"].ToString().Replace("'", " ") + "\",\"" + Year + "\",\"" + Month + "\");"));
        }
        strChartXML.Append("</dataset>");

        strChartXML.Append("<dataset seriesname='Sonic Events' color='C00000'>");
        for (int k = 0; k < dt.Rows.Count; k++)
        {
            strChartXML.AppendFormat("<set value='{0}' link='{1}'/>", dt.Rows[k]["Sonic_Event_Percent"], Server.UrlEncode("JavaScript:OpenPopup(\"" + dt.Rows[k]["FK_LU_Location"].ToString().Replace("'", " ") + "\",\"" + Year + "\",\"" + Month + "\");"));
        }
        strChartXML.Append("</dataset>");

        GetTreadLineStyle(strChartXML, 50);
        
        strChartXML.Append("<styles><definition><style type='font' color='666666' name='CaptionFont' size='15' /><style type='font' name='SubCaptionFont' bold='0' /></definition>");

        strChartXML.Append("<application><apply toObject='caption' styles='CaptionFont' /><apply toObject='SubCaption' styles='SubCaptionFont' /></application></styles></chart>");
     
        StringBuilder sbChart = new StringBuilder();
        sbChart.Append(InfoSoftGlobal.FusionCharts.RenderChart(AppConfig.SiteURL + "FusionCharts/StackedColumn3D.swf?ChartNoDataText=No data to display for: Monthly Event Percentage by Location ", "", strChartXML.ToString(), "divchart3", "850", "500", false, true));
        divchart2.InnerHtml = sbChart.ToString();
        strChartXML = null;
    }

    #endregion

    #region "Other Methods"

    /// <summary>
    /// Set TreadLine on Chart
    /// </summary>
    /// <param name="strChartXML"></param>
    /// <param name="Average"></param>
    public void GetTreadLineStyle(StringBuilder strChartXML, decimal Average)
    {
        // set Tread Lines
        strChartXML.Append("<trendLines>");
        strChartXML.Append("<line startValue='70' color='49563A' displayvalue='Bronze (70-79.99%)' /> ");
        strChartXML.Append("<line startValue='80' color='49563A' displayvalue='Silver (80-89.99%)' /> ");
        strChartXML.Append("<line startValue='90' color='49563A' displayvalue='Gold (90-94.99%)' /> ");
        strChartXML.Append("<line startValue='95' color='49563A' displayvalue='Platinum (95-100%)' /> ");
        strChartXML.Append("<line startValue='" + string.Format("{0:N2}", Average) + "' color='FF0000' displayvalue='' valueOnRight='1' thickness='2' /> ");
        strChartXML.Append("</trendLines>");

        // set Style for Chart objects
        strChartXML.Append("<styles>");
        strChartXML.Append("<definition>");
        strChartXML.Append("<style type='font' name='CaptionFont' color='666666' size='12'/>");
        strChartXML.Append("<style type='font' name='SubCaptionFont' bold='0'/>");
        strChartXML.Append("</definition>");
        strChartXML.Append("<application>");
        strChartXML.Append("<apply toObject='caption' styles='CaptionFont'/>");
        strChartXML.Append("<apply toObject='SubCaption' styles='SubCaptionFont'/>");
        strChartXML.Append("</application>");
        strChartXML.Append("</styles>");
    }

    #endregion
}