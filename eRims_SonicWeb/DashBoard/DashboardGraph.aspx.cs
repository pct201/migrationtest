using System;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InfoSoftGlobal;
using ERIMS.DAL;
using System.Data;

public partial class DashboardGraph : clsBasePage
{

    #region "Property"

    public int Year
    {
        get { return (ddlYear.SelectedIndex < 0 ? System.DateTime.Now.Year : Convert.ToInt32(ddlYear.SelectedValue)); }
    }

    public DateTime Date
    {
        get { return System.DateTime.Now; }
    }

    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillYear();
        }
    }

    #region "Events"

    protected void ddlYear_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    #endregion

    #region "Chart Methods"

    public string GetChartSabaTrainingByRegion()
    {
        StringBuilder strXML = new StringBuilder();
        string strLink = string.Empty;
        decimal _decAvg = 0;


        DataSet ds = Charts.GetSabaTrainingByRegion(Year);
        if (ds.Tables.Count > 1)
        {
            // Get Result for facility inspection Region
            DataTable dtResult1 = ds.Tables[0];

            if (ds.Tables.Count > 1)
            {
                if (ds.Tables[1].Rows.Count > 0)
                {
                    decimal.TryParse(Convert.ToString(ds.Tables[1].Rows[0]["Average_Score"]), out _decAvg);
                }


            }
            string strHeader = "";
            if (dtResult1.Rows.Count > 1)
                strHeader = "Sonic University Training Scorecard By Region";
            else
                strHeader = "Sonic University Training Scorecard";
            // Set Chart property 
            strXML.Append("<chart caption='" + strHeader + "' xAxisName='Region' yAxisName='Level'  useRoundEdges='1' showValues='0' formatNumberScale='0' showBorder='0' rotateYAxisName='0' showYAxisValues='0' yAxisMinValue='0' yAxisMaxValue='34' labelDisplay='ROTATE' maxColWidth='40' slantLabels='0' use3DLighting='1' divLineAlpha='0' baseFont='Verdana' baseFontColor='6f6c6c' baseFontSize='10'>");

            // Set Lable
            for (int i = 0; i < dtResult1.Rows.Count; i++)
            {
                strXML.AppendFormat("<set label='{0}' value='{1}' link='{2}'/>", dtResult1.Rows[i][0].ToString(), dtResult1.Rows[i][1].ToString(), Server.UrlEncode("JavaScript:OpenPopup(\"" + dtResult1.Rows[i][0].ToString() + "\",\"" + Year.ToString() + "\",\"3\"," + Convert.ToString(_decAvg) + ");"));
            }

            GetTreadLineStyle(strXML, _decAvg);
            strXML.Append("</chart>");
        }
        // Generate Chart
        return InfoSoftGlobal.FusionCharts.RenderChart(AppConfig.SiteURL + "FusionCharts/Column3D.swf?ChartNoDataText=No data to display for: Saba Training Scoreboard By Region", "", strXML.ToString(), "SabaTrainingByRegion", "490", "400", false, true);
    }

    /// <summary>
    /// Generate Aggrgate Performance By Region Chart
    /// </summary>
    /// <returns></returns>
    public string GetAggregatePerformanceByRegion()
    {
        StringBuilder strChartXML = new StringBuilder();
        DataTable dtResult, dtRegion;
        decimal _intScore = 0.0M;

        dtRegion = Charts.GetRegionListByUser(Convert.ToInt32(clsSession.UserID)).Tables[0];
        dtRegion.Columns.Add(new DataColumn("Score", typeof(decimal)));
        dtRegion.Columns.Add(new DataColumn("Performance", typeof(string)));

        DataTable dtAverage = new DataTable();
        dtAverage.Columns.Add(new DataColumn("Score", typeof(decimal)));

        DataSet dsResult = Charts.GetFacilityInspectionByRegion(Year);
        dtResult = dsResult.Tables[0];
        dtAverage.Rows.Add(dtAverage.NewRow()[0] = dsResult.Tables[1].Rows[0][0]);

        dsResult = Charts.GetIncidentInvestigationByRegion(Year);
        dtResult.Merge(dsResult.Tables[0]);
        dtAverage.Rows.Add(dtAverage.NewRow()[0] = dsResult.Tables[1].Rows[0][0]);

        dsResult = Charts.GetIncidentReductionByRegion(Year);
        dtResult.Merge(dsResult.Tables[0]);
        dtAverage.Rows.Add(dtAverage.NewRow()[0] = dsResult.Tables[1].Rows[0][0]);

        dsResult = Charts.GetSabaTrainingByRegion(Year);
        dtResult.Merge(dsResult.Tables[0]);
        dtAverage.Rows.Add(dtAverage.NewRow()[0] = (dsResult.Tables[1].Rows[0][0] != DBNull.Value ? dsResult.Tables[1].Rows[0][0] : 0));

        dsResult = Charts.GetWCClaimMgmtByRegion(Year);
        dtResult.Merge(dsResult.Tables[0]);
        dtAverage.Rows.Add(dtAverage.NewRow()[0] = dsResult.Tables[1].Rows[0][0]);

        dsResult = Charts.GETSLTBYRegion(Year);
        dtResult.Merge(dsResult.Tables[0]);
        dtAverage.Rows.Add(dtAverage.NewRow()[0] = dsResult.Tables[1].Rows[0][0]);

        for (int _iRow = 0; _iRow < dtRegion.Rows.Count; _iRow++)
        {
            dtRegion.Rows[_iRow][1] = _intScore = 0;
            decimal decAvg = Convert.ToDecimal(dtResult.Compute("AVG(Score)", " Region = '" + Convert.ToString(dtRegion.Rows[_iRow]["region"]) + "' "));
            decimal.TryParse(Convert.ToString(dtResult.Compute("SUM(Score)", " Region = '" + Convert.ToString(dtRegion.Rows[_iRow]["region"]) + "' ")), out _intScore);

            if (_intScore > 189 && _intScore <= 200)
            {
                dtRegion.Rows[_iRow][2] = "All Pro";
                dtRegion.Rows[_iRow][1] = _intScore;
            }
            else if (_intScore > 179 && _intScore <= 189)
            {
                dtRegion.Rows[_iRow][2] = "Starter";
                dtRegion.Rows[_iRow][1] = _intScore;
            }
            else if (_intScore > 159 && _intScore <= 179)
            {
                dtRegion.Rows[_iRow][2] = "Second String";
                dtRegion.Rows[_iRow][1] = _intScore;
            }
            else if (_intScore > 139 && _intScore <= 159)
            {
                dtRegion.Rows[_iRow][2] = "Water boy";
                dtRegion.Rows[_iRow][1] = _intScore;
            }
            else if (_intScore >= 0 && _intScore <= 139)
            {
                dtRegion.Rows[_iRow][2] = "Spectator";
                dtRegion.Rows[_iRow][1] = _intScore;
            }
        }

        string strHeader = "";
        if (dtRegion.Rows.Count > 1)
            strHeader = "Aggregate Performance By Region";
        else
            strHeader = "Aggregate Performance";

        // Set Chart property 
        strChartXML.Append("<chart caption='" + strHeader + "' xAxisName='Region' yAxisName='Level' useRoundEdges='1' showValues='0' formatNumberScale='0' showBorder='0' rotateYAxisName='0' showYAxisValues='0' yAxisMinValue='0' yAxisMaxValue='240' labelDisplay='ROTATE' maxColWidth='40' slantLabels='0' use3DLighting='1' divLineAlpha='0' baseFont='Verdana' baseFontColor='6f6c6c' baseFontSize='10'>");

        decimal _devAvg = 0;
        //decimal.TryParse(Convert.ToString(dtAverage.Compute("AVG(Score)", "")), out _devAvg);
        decimal.TryParse(Convert.ToString(dtRegion.Compute("AVG(Score)", "")), out _devAvg);

        // Set Lable
        for (int i = 0; i < dtRegion.Rows.Count; i++)
        {
            strChartXML.AppendFormat("<set label='{0}' value='{1}' link='{2}'/>", dtRegion.Rows[i][0].ToString(), dtRegion.Rows[i][1].ToString(), Server.UrlEncode("JavaScript:OpenPopup(\"" + dtRegion.Rows[i][0].ToString() + "\",\"" + Year.ToString() + "\",\"1\"," + Convert.ToString(_devAvg) + ");"));
        }

        // set Tread Lines
        strChartXML.Append("<trendLines>");
        strChartXML.Append("<line startValue='139' color='49563A' displayvalue='Spectator' /> ");
        strChartXML.Append("<line startValue='159' color='49563A' displayvalue='Water boy' /> ");
        strChartXML.Append("<line startValue='179' color='49563A' displayvalue='Second String' /> ");
        strChartXML.Append("<line startValue='189' color='49563A' displayvalue='Starter' /> ");
        strChartXML.Append("<line startValue='200' color='49563A' displayvalue='All Pro' /> ");
        strChartXML.Append("<line startValue='" + string.Format("{0:N2}", _devAvg) + "' color='FF0000' displayvalue='Company Average' valueOnRight='1' thickness='2' /> ");

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

        strChartXML.Append("</chart>");
        return InfoSoftGlobal.FusionCharts.RenderChart(AppConfig.SiteURL + "FusionCharts/Column3D.swf?ChartNoDataText=No data to display for: Aggregate Performance By Region", "", strChartXML.ToString(), "AggregatePerformanceByRegion", "490", "400", false, true);
    }

    /// <summary>
    /// Generate Facility Inspection By Region Chart
    /// </summary>
    /// <returns></returns>
    public string GetChartFacilityInspectionByRegion()
    {
        StringBuilder strChartXML = new StringBuilder();
        // Get Result for facility inspection Region
        DataSet dsResult = Charts.GetFacilityInspectionByRegion(Year);
        DataTable dtResult = dsResult.Tables[0];
        decimal _decAvg = 0;

        if (dsResult.Tables.Count > 1)
        {
            if (dsResult.Tables[1].Rows.Count > 0)
                decimal.TryParse(Convert.ToString(dsResult.Tables[1].Rows[0]["Score"]), out _decAvg);
        }

        string strHeader = "";
        if (dtResult.Rows.Count > 1)
            strHeader = "Facility Inspection By Region";
        else
            strHeader = "Facility Inspection";

        // Set Chart property 
        strChartXML.Append("<chart caption='" + strHeader + "' xAxisName='Region' yAxisName='Level' useRoundEdges='1' showValues='0' formatNumberScale='0' showBorder='0' rotateYAxisName='0' showYAxisValues='0' yAxisMinValue='0' yAxisMaxValue='34' labelDisplay='ROTATE' maxColWidth='40' slantLabels='0' use3DLighting='1' divLineAlpha='0' baseFont='Verdana' baseFontColor='6f6c6c' baseFontSize='10'>");

        // Set Lable
        for (int i = 0; i < dtResult.Rows.Count; i++)
        {
            strChartXML.AppendFormat("<set label='{0}' value='{1}' link='{2}'/>", dtResult.Rows[i][0].ToString(), dtResult.Rows[i][1].ToString(), Server.UrlEncode("JavaScript:OpenPopup(\"" + dtResult.Rows[i][0].ToString() + "\",\"" + Year.ToString() + "\",\"2\"," + Convert.ToString(_decAvg) + ");"));
        }

        GetTreadLineStyle(strChartXML, _decAvg);

        strChartXML.Append("</chart>");

        // Generate Chart
        return InfoSoftGlobal.FusionCharts.RenderChart(AppConfig.SiteURL + "FusionCharts/Column3D.swf?ChartNoDataText=No data to display for: Facility Inspection By Region", "", strChartXML.ToString(), "FacilityInspectionByRegion", "490", "400", false, true);
    }

    /// <summary>
    /// Generate Facility Inspection By Region Chart
    /// </summary>
    /// <returns></returns>
    public string GetChartIncidentInvestigationByRegion()
    {
        StringBuilder strChartXML = new StringBuilder();
        string strLink = string.Empty;
        decimal _decAvg = 0;
        // Get Result for facility inspection Region
        DataSet dsResult = Charts.GetIncidentInvestigationByRegion(Year);
        DataTable dtResult = dsResult.Tables[0];

        if (dsResult.Tables.Count > 1)
        {
            if (dsResult.Tables[1].Rows.Count > 0)
                decimal.TryParse(Convert.ToString(dsResult.Tables[1].Rows[0]["Score"]), out _decAvg);
        }
        string strHeader = "";
        if (dtResult.Rows.Count > 1)
            strHeader = "Incident Investigation By Region";
        else
            strHeader = "Incident Investigation";
        // Set Chart property 
        strChartXML.Append("<chart caption='" + strHeader + "' xAxisName='Region' yAxisName='Level' useRoundEdges='1' showValues='0' formatNumberScale='0' showBorder='0' rotateYAxisName='0' showYAxisValues='0' yAxisMinValue='0' yAxisMaxValue='34' labelDisplay='ROTATE' maxColWidth='40' slantLabels='0' use3DLighting='1' divLineAlpha='0' baseFont='Verdana' baseFontColor='6f6c6c' baseFontSize='10'>");

        // Set Lable
        for (int i = 0; i < dtResult.Rows.Count; i++)
        {
            strLink = Server.UrlEncode("JavaScript:OpenPopup(\"" + dtResult.Rows[i]["region"].ToString() + "\",\"" + Year.ToString() + "\",\"4\"," + Convert.ToString(_decAvg) + ");");
            strChartXML.AppendFormat("<set label='{0}' value='{1}' link='{2}'/>", dtResult.Rows[i]["Region"].ToString(), dtResult.Rows[i]["Score"].ToString(), strLink);
        }

        GetTreadLineStyle(strChartXML, _decAvg);

        strChartXML.Append("</chart>");

        // Generate Chart
        return InfoSoftGlobal.FusionCharts.RenderChart(AppConfig.SiteURL + "FusionCharts/Column3D.swf?ChartNoDataText=No data to display for: Incident Investigation By Region", "", strChartXML.ToString(), "IncidentInvestigationByRegion", "490", "400", false, true);
    }

    /// <summary>
    /// Generate SLT By Region Chart
    /// </summary>
    /// <returns></returns>
    public string GetChartSLTByRegion()
    {
        StringBuilder strChartXML = new StringBuilder();
        // Get Result for facility inspection Region
        DataSet dsResult = Charts.GETSLTBYRegion(Year);
        DataTable dtResult = dsResult.Tables[0];
        decimal _decAvg = 0;

        if (dsResult.Tables.Count > 1)
        {
            if (dsResult.Tables[1].Rows.Count > 0)
                decimal.TryParse(Convert.ToString(dsResult.Tables[1].Rows[0]["Score"]), out _decAvg);
        }

        string strHeader = "";
        if (dtResult.Rows.Count > 1)
            strHeader = "Safety Leadership Team By Region";
        else
            strHeader = "Safety Leadership Team";

        // Set Chart property 
        strChartXML.Append("<chart caption='" + strHeader + "' xAxisName='Region' yAxisName='Level' useRoundEdges='1' showValues='0' formatNumberScale='0' showBorder='0' rotateYAxisName='0' showYAxisValues='0' yAxisMinValue='0' yAxisMaxValue='70' labelDisplay='ROTATE' maxColWidth='40' slantLabels='0' use3DLighting='1' divLineAlpha='0' baseFont='Verdana' baseFontColor='6f6c6c' baseFontSize='10'>");

        // Set Lable
        for (int i = 0; i < dtResult.Rows.Count; i++)
        {
            strChartXML.AppendFormat("<set label='{0}' value='{1}' link='{2}'/>", dtResult.Rows[i][0].ToString(), dtResult.Rows[i][1].ToString(), Server.UrlEncode("JavaScript:OpenPopup(\"" + dtResult.Rows[i][0].ToString() + "\",\"" + Year.ToString() + "\",\"7\"," + Convert.ToString(_decAvg) + ");"));
        }

        GetTreadLineStyle_SLT(strChartXML, _decAvg);

        strChartXML.Append("</chart>");

        // Generate Chart
        return InfoSoftGlobal.FusionCharts.RenderChart(AppConfig.SiteURL + "FusionCharts/Column3D.swf?ChartNoDataText=No data to display for: Safety Leadership Team By Region", "", strChartXML.ToString(), "SafetyLeadershipTeamByRegion", "490", "400", false, true);
    }
    /// <summary>
    /// Generate Facility Inspection By Region Chart
    /// </summary>
    /// <returns></returns>
    public string GetChartIncidentReductionByRegion()
    {
        StringBuilder strChartXML = new StringBuilder();
        string strLink = string.Empty;
        decimal _decAvg = 0;
        DataSet dsResult = Charts.GetIncidentReductionByRegion(Year);
        DataTable dtResult = dsResult.Tables[0];

        if (dsResult.Tables.Count > 1)
        {
            if (dsResult.Tables[1].Rows.Count > 0)
                decimal.TryParse(Convert.ToString(dsResult.Tables[1].Rows[0]["Average_Score"]), out _decAvg);
        }

        string strHeader = "";
        if (dtResult.Rows.Count > 1)
            strHeader = "Incident Reduction By Region";
        else
            strHeader = "Incident Reduction";

        // Set Chart property 
        strChartXML.Append("<chart caption='" + strHeader + "' xAxisName='Region' yAxisName='Level'  useRoundEdges='1' showValues='0' formatNumberScale='0' showBorder='0' rotateYAxisName='0' showYAxisValues='0' yAxisMinValue='0' yAxisMaxValue='34' labelDisplay='ROTATE' maxColWidth='40' slantLabels='0' use3DLighting='1' divLineAlpha='0' baseFont='Verdana' baseFontColor='6f6c6c' baseFontSize='10' >");

        // Set Lable
        for (int i = 0; i < dtResult.Rows.Count; i++)
        {
            strLink = Server.UrlEncode("JavaScript:OpenPopup(\"" + dtResult.Rows[i]["region"].ToString() + "\",\"" + Year.ToString() + "\",\"6\"," + Convert.ToString(_decAvg) + ");");
            strChartXML.AppendFormat("<set label='{0}' value='{1}' link='{2}'/>", dtResult.Rows[i]["Region"].ToString(), dtResult.Rows[i]["Score"].ToString(), strLink);
        }

        GetTreadLineStyle(strChartXML, _decAvg);
        strChartXML.Append("</chart>");

        // Generate Chart
        return InfoSoftGlobal.FusionCharts.RenderChart(AppConfig.SiteURL + "FusionCharts/Column3D.swf?ChartNoDataText=No data to display for: Incident Reduction By Region", "", strChartXML.ToString(), "IncidentReductionByRegion", "490", "400", false, true);
    }

    /// <summary>
    /// Generate Facility Inspection By Region Chart
    /// </summary>
    /// <returns></returns>
    public string GetChartWCCLaimMgmtByRegion()
    {
        StringBuilder strChartXML = new StringBuilder();
        string strLink = string.Empty;
        decimal _decAvg = 0;
        // Get Result for facility inspection Region
        DataSet dsResult = Charts.GetWCClaimMgmtByRegion(Year);
        DataTable dtResult = dsResult.Tables[0];

        if (dsResult.Tables.Count > 1)
        {
            if (dsResult.Tables[1].Rows.Count > 0)
                decimal.TryParse(Convert.ToString(dsResult.Tables[1].Rows[0]["Score"]), out _decAvg);
        }
        string strHeader = "";
        if (dtResult.Rows.Count > 1)
            strHeader = "Workers’ Compensation Claims Management By Region";
        else
            strHeader = "Workers’ Compensation Claims Management";
        // Set Chart property 
        strChartXML.Append("<chart caption='" + strHeader + "' xAxisName='Region' yAxisName='Level'  useRoundEdges='1' showValues='0' formatNumberScale='0' showBorder='0' rotateYAxisName='0' showYAxisValues='0' yAxisMinValue='0' yAxisMaxValue='34' labelDisplay='ROTATE' maxColWidth='40' slantLabels='0' use3DLighting='1' divLineAlpha='0' baseFont='Verdana' baseFontColor='6f6c6c' baseFontSize='10'>");

        // Set Lable
        for (int i = 0; i < dtResult.Rows.Count; i++)
        {
            strLink = Server.UrlEncode("JavaScript:OpenPopup(\"" + dtResult.Rows[i]["region"].ToString() + "\",\"" + Year.ToString() + "\",\"5\"," + Convert.ToString(_decAvg) + ");");
            strChartXML.AppendFormat("<set label='{0}' value='{1}' link='{2}'/>", dtResult.Rows[i]["Region"].ToString(), dtResult.Rows[i]["Score"].ToString(), strLink);
        }

        GetTreadLineStyle(strChartXML, _decAvg);

        strChartXML.Append("</chart>");

        // Generate Chart
        return InfoSoftGlobal.FusionCharts.RenderChart(AppConfig.SiteURL + "FusionCharts/Column3D.swf?ChartNoDataText=No data to display for: Workers’ Compensation Claims Management By Region", "", strChartXML.ToString(), "WCClaimMgmtByRegion", "490", "400", false, true);
    }

    /// <summary>
    /// Set Property of pages
    /// </summary>
    /// <param name="strChartXML"></param>
    /// <param name="Average"></param>
    public void GetTreadLineStyle(StringBuilder strChartXML, decimal Average)
    {
        // set Tread Lines
        strChartXML.Append("<trendLines>");
        strChartXML.Append("<line startValue='4' color='49563A' displayvalue='Spectator' /> ");
        strChartXML.Append("<line startValue='10' color='49563A' displayvalue='Water boy' /> ");
        strChartXML.Append("<line startValue='16' color='49563A' displayvalue='Second String' /> ");
        strChartXML.Append("<line startValue='22' color='49563A' displayvalue='Starter' /> ");
        strChartXML.Append("<line startValue='28' color='49563A' displayvalue='All Pro' /> ");
        strChartXML.Append("<line startValue='" + string.Format("{0:N2}", Average) + "' color='FF0000' displayvalue='Company Average' valueOnRight='1' thickness='2' /> ");

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

    /// <summary>
    /// Set Property of pages
    /// </summary>
    /// <param name="strChartXML"></param>
    /// <param name="Average"></param>
    public void GetTreadLineStyle_SLT(StringBuilder strChartXML, decimal Average)
    {
        // set Tread Lines
        strChartXML.Append("<trendLines>");
        strChartXML.Append("<line startValue='23' color='49563A' displayvalue='Spectator' /> ");
        strChartXML.Append("<line startValue='35' color='49563A' displayvalue='Water boy' /> ");
        strChartXML.Append("<line startValue='47' color='49563A' displayvalue='Second String' /> ");
        strChartXML.Append("<line startValue='59' color='49563A' displayvalue='Starter' /> ");
        strChartXML.Append("<line startValue='60' color='49563A' displayvalue='All Pro' /> ");
        strChartXML.Append("<line startValue='" + string.Format("{0:N2}", Average) + "' color='FF0000' displayvalue='Company Average' valueOnRight='1' thickness='2' /> ");
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

    /// <summary>
    /// Fill Year Drop Down
    /// </summary>
    private void FillYear()
    {
        int _Year;

        // Fill Year Starting with 2007 to current Year
        for (_Year = 2007; _Year <= System.DateTime.Now.Year; _Year++)
            ddlYear.Items.Add(new ListItem(_Year.ToString(), _Year.ToString()));

        ddlYear.SelectedValue = System.DateTime.Now.Year.ToString();
    }

    #endregion
}