using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InfoSoftGlobal;
using System.Data;
using System.Text;
using ERIMS_DAL;

public partial class DashBoardGraphACI : clsBasePage
{

    #region Page Events
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (clsSession.UserID == null)
                Response.Redirect(AppConfig.SiteURL + "Error.aspx?msg=errAcc");

            BindYear();

            BindChart();
        }
    }
    #endregion

    #region Functions
    private void BindYear()
    {
        for (int i = DateTime.Now.Year; i >= 1990; i--)
        {
            ddlYear.Items.Add(new ListItem(i.ToString(), i.ToString()));
        }

        ddlYear.SelectedValue = DateTime.Now.Year.ToString();
    }

    private void BindChart()
    {
        DataSet dsACI = ERIMS.DAL.clsEvent.GetDashboardDataACI(Convert.ToInt32(ddlMonth.SelectedValue), Convert.ToInt32(ddlYear.SelectedValue));

        ShowMonthlyEvent(dsACI.Tables[0]);

        ShowTotalEvent(dsACI.Tables[1]);

    }

    //public void ShowMonth(DataTable dt)
    //{
    //    StringBuilder strChartXML = new StringBuilder();

    //    strChartXML.Append("<graph bgColor='F1f1f1' caption='Monthly Event Percentage by Location' subcaption='' xaxisname='Continent' yaxisname='Export' canvasbgcolor='F1F1F1' animation='1' numdivlines='3' divLineColor='333333' decimalPrecision='0' showLegend='1' showColumnShadow='1' yAxisMaxValue='100'>");
    //    strChartXML.Append("<categories>");

    //    for (int i = 0; i < dt.Rows.Count; i++)
    //    {
    //        strChartXML.Append("<category name='" + dt.Rows[i]["Location"].ToString() + "' hoverText='" + dt.Rows[i]["Location"].ToString() + "'/>");
    //    }
    //    strChartXML.Append("</categories>");

    //    strChartXML.Append("<dataset seriesname='ACI Events'>");
    //    for (int i = 0; i < dt.Rows.Count; i++)
    //    {
    //        strChartXML.Append("<set value='"+  + "' />");
    //    }
    //}

    public void ShowMonthlyEvent(DataTable dt)
    {
        StringBuilder strChartXML = new StringBuilder();

        strChartXML.Append("<chart caption='Monthly Event Percentage by Location' showvalues='0' plotfillalpha='95' labeldisplay='' numberSuffix='%' formatnumberscale='0' plotgradientcolor='' bgcolor='FFFFFF' showalternatehgridcolor='0' showplotborder='0' yAxisMinValue='80' yAxisMaxValue='100' divlinecolor='CCCCCC' showcanvasborder='0' legendborderalpha='0' legendshadow='0' showpercentvalues='1' stack100percent='1' canvasborderalpha='0' palettecolors='#FD9927,#FECE2F,#9DCD3F,#CECD42,#64D3D1'>");
        //    "showalternatehgridcolor='0' showplotborder='0' divlinecolor='CCCCCC' showcanvasborder='0' legendborderalpha='0' legendshadow='0' showpercentvalues='1' stack100percent='1' canvasborderalpha='0' palettecolors='#FD9927,#FECE2F,#9DCD3F,#CECD42,#64D3D1' >");

        strChartXML.Append("<categories>");

        for (int i = 0; i < dt.Rows.Count; i++)
        {
            strChartXML.Append("<category label='" + dt.Rows[i]["Location"].ToString().Replace("'", " ") + "' />");
        }

        strChartXML.Append("</categories>");

        strChartXML.Append("<dataset seriesname='ACI Events' color='5B9BD5'>");
        for (int j = 0; j < dt.Rows.Count; j++)
        {
            strChartXML.Append("<set value='" + dt.Rows[j]["ACI_Event_Percent"] + "' />");
        }
        strChartXML.Append("</dataset>");

        strChartXML.Append("<dataset seriesname='Sonic Events' color='ED7D31'>");
        for (int k = 0; k < dt.Rows.Count; k++)
        {
            strChartXML.Append("<set value='" + dt.Rows[k]["Sonic_Event_Percent"] + "' />");
        }
        strChartXML.Append("</dataset>");

        strChartXML.Append("<trendLines>  <line startValue='50' endValue='50' color='FF0000' thickness='2' alpha='100' showOnTop='1' /></trendLines>");

        strChartXML.Append("<styles><definition><style type='font' color='666666' name='CaptionFont' size='15' /><style type='font' name='SubCaptionFont' bold='0' /></definition>");

        strChartXML.Append("<application><apply toObject='caption' styles='CaptionFont' /><apply toObject='SubCaption' styles='SubCaptionFont' /></application></styles></chart>");
        //return strChartXML.ToString();
        StringBuilder sbChart = new StringBuilder();
        sbChart.Append(InfoSoftGlobal.FusionCharts.RenderChart(AppConfig.SiteURL + "FusionCharts/ScrollStackedColumn2D.swf?ChartNoDataText=No data to display for: Monthly Event Percentage by Location ", "", strChartXML.ToString(), "divchart1", "950", "500", false, true));
        divchart1.InnerHtml = sbChart.ToString();
        strChartXML = null;
    }

    public void ShowTotalEvent(DataTable dt)
    {
        StringBuilder strChartXML = new StringBuilder();

        strChartXML.Append("<chart caption='Total Event Percentage by Month' showvalues='1' plotfillalpha='95' numberSuffix='%' formatnumberscale='0' plotgradientcolor='' bgcolor='FFFFFF' showalternatehgridcolor='0' showplotborder='0' yAxisMaxValue='100' divlinecolor='CCCCCC' showcanvasborder='0' legendborderalpha='0' legendshadow='0' showpercentvalues='1' stack100percent='1' canvasborderalpha='0' palettecolors='#FD9927,#FECE2F,#9DCD3F,#CECD42,#64D3D1'>");
        //strChartXML.Append("<chart caption='Total Event Percentage by Month' subCaption='' yAxisName='' xAxisName='' divLineColor='FFFFFF' numberSuffix='' labelDisplay='' numDivLines='4'>");


        strChartXML.Append("<categories>");

        for (int i = 0; i < dt.Rows.Count; i++)
        {
            strChartXML.Append("<category label='" + dt.Rows[i]["Month_Name"].ToString().Replace("'", " ") + "' />");
        }

        strChartXML.Append("</categories>");

        //for (int i = 0; i < dt.Rows.Count; i++)
        //{
        //    string strJS = "";
        //    strChartXML.Append("<set label='" + dt.Rows[i][0] + "' value='" + dt.Rows[i][2] + "' link='" + strJS + "' />");
        //}


        strChartXML.Append("<dataset seriesname='ACI Events' color='5B9BD5'>");
        for (int j = 0; j < dt.Rows.Count; j++)
        {
            strChartXML.Append("<set value='" + dt.Rows[j]["ACI_Event_Percent"] + "' />");
        }
        strChartXML.Append("</dataset>");

        strChartXML.Append("<dataset seriesname='Sonic Events' color='ED7D31'>");
        for (int k = 0; k < dt.Rows.Count; k++)
        {
            strChartXML.Append("<set value='" + dt.Rows[k]["Sonic_Event_Percent"] + "' />");
        }
        strChartXML.Append("</dataset>");

        strChartXML.Append("<trendLines>  <line startValue='50' endValue='50' color='FF0000' thickness='2' alpha='100' showOnTop='1' /></trendLines>");
        //strChartXML.Append("<categories>");

        //for (int i = 0; i < dt.Rows.Count; i++)
        //{
        //    strChartXML.Append("<category label='" + dt.Rows[i][0].ToString().Replace("'", "''") + "' />");
        //}

        //strChartXML.Append("</categories>");

        //strChartXML.Append("<dataset seriesname='ACI Events'>");
        //for (int j = 0; j < dt.Rows.Count; j++)
        //{
        //    strChartXML.Append("<set value='" + dt.Rows[j]["ACI_Event_Percent"] + "' link='' />");
        //}
        //strChartXML.Append("</dataset>");

        //strChartXML.Append("<dataset seriesname='Sonic Events'>");
        //for (int k = 0; k < dt.Rows.Count; k++)
        //{
        //    strChartXML.Append("<set value='" + dt.Rows[k]["Sonic_Event_Percent"] + "' link='' />");
        //}
        //strChartXML.Append("</dataset>");

        strChartXML.Append("<styles><definition><style type='font' color='666666' name='CaptionFont' size='15' /><style type='font' name='SubCaptionFont' bold='0' /></definition>");

        strChartXML.Append("<application><apply toObject='caption' styles='CaptionFont' /><apply toObject='SubCaption' styles='SubCaptionFont' /></application></styles></chart>");
        //return strChartXML.ToString();
        StringBuilder sbChart = new StringBuilder();
        sbChart.Append(InfoSoftGlobal.FusionCharts.RenderChart(AppConfig.SiteURL + "FusionCharts/StackedColumn2D.swf?ChartNoDataText=No data to display for: Total Event Percentage by Month ", "", strChartXML.ToString(), "divchart2", "950", "300", false, true));
        divchart2.InnerHtml = sbChart.ToString();
        strChartXML = null;
    }

    public static string UpperCaseUrlEncode(string s)
    {
        char[] temp = HttpUtility.UrlEncode(s).ToCharArray();
        for (int i = 0; i < temp.Length - 2; i++)
        {
            if (temp[i] == '%')
            {
                temp[i + 1] = char.ToUpper(temp[i + 1]);
                temp[i + 2] = char.ToUpper(temp[i + 2]);
            }
        }
        return new string(temp);
    }

    #endregion

    #region Control Events

    protected void ddlMonth_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindChart();
    }
    protected void ddlYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindChart();
    }

    #endregion
}