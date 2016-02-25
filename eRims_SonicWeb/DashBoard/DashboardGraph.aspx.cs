using System;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InfoSoftGlobal;
using ERIMS.DAL;
using System.Data;
using System.Web.UI.HtmlControls;
using System.IO;

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

    /// <summary>
    /// Data table to store attachment
    /// </summary>
    private DataTable dtAttachments
    {
        get
        {
            if (ViewState["dtAttachments"] != null)
                return (DataTable)ViewState["dtAttachments"];
            else
                return null;
        }
        set
        {
            ViewState["dtAttachments"] = value;
        }
    }

    /// <summary>
    /// Data table to store Sub comments
    /// </summary>
    private DataTable dtComments
    {
        get
        {
            if (ViewState["dtComments"] != null)
                return (DataTable)ViewState["dtComments"];
            else
                return null;
        }
        set
        {
            ViewState["dtComments"] = value;
        }
    }

    #endregion

    #region "Page Event"
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillYear();
            BindPosts(1, 10);

            btnAdd.Visible = App_Access == AccessType.Administrative_Access;//only editable by the eRIMS2 Administrator Users
            pnlWall.Visible = true;
            pnlSearch.Visible = false;
        }
    } 
    #endregion

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
    /// Generate Aggregate Performance By Region Chart
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

            //if (_intScore > 189 && _intScore <= 200)
            //{
            //    dtRegion.Rows[_iRow][2] = "All Pro";
            //    dtRegion.Rows[_iRow][1] = _intScore;
            //}
            //else if (_intScore > 179 && _intScore <= 189)
            //{
            //    dtRegion.Rows[_iRow][2] = "Starter";
            //    dtRegion.Rows[_iRow][1] = _intScore;
            //}
            //else if (_intScore > 159 && _intScore <= 179)
            //{
            //    dtRegion.Rows[_iRow][2] = "Second String";
            //    dtRegion.Rows[_iRow][1] = _intScore;
            //}
            //else if (_intScore > 139 && _intScore <= 159)
            //{
            //    dtRegion.Rows[_iRow][2] = "Water boy";
            //    dtRegion.Rows[_iRow][1] = _intScore;
            //}
            //else if (_intScore >= 0 && _intScore <= 139)
            //{
            //    dtRegion.Rows[_iRow][2] = "Spectator";
            //    dtRegion.Rows[_iRow][1] = _intScore;
            //}

            ////Change as per bug-tracker #3585.
            _intScore = (_intScore / 200) * 100;

            if (_intScore > 94.5M && _intScore <= 100)
            {
                dtRegion.Rows[_iRow][2] = "All Pro";
                dtRegion.Rows[_iRow][1] = _intScore;
            }
            else if (_intScore > 89.5m && _intScore <= 94.5m)
            {
                dtRegion.Rows[_iRow][2] = "Starter";
                dtRegion.Rows[_iRow][1] = _intScore;
            }
            else if (_intScore > 79.5m && _intScore <= 89.5m)
            {
                dtRegion.Rows[_iRow][2] = "Second String";
                dtRegion.Rows[_iRow][1] = _intScore;
            }
            else if (_intScore > 69.5m && _intScore <= 79.5m)
            {
                dtRegion.Rows[_iRow][2] = "Water boy";
                dtRegion.Rows[_iRow][1] = _intScore;
            }
            else if (_intScore >= 0 && _intScore <= 69.5m)
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
        strChartXML.Append("<chart caption='" + strHeader + "' xAxisName='Region' yAxisName='Level' useRoundEdges='1' showValues='0' formatNumberScale='0' showBorder='0' rotateYAxisName='0' showYAxisValues='0' yAxisMinValue='0' yAxisMaxValue='120' labelDisplay='ROTATE' maxColWidth='40' slantLabels='0' use3DLighting='1' divLineAlpha='0' baseFont='Verdana' baseFontColor='6f6c6c' baseFontSize='10'>");

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
        strChartXML.Append("<line startValue='69.5' color='49563A' displayvalue='Spectator' /> ");
        strChartXML.Append("<line startValue='79.5' color='49563A' displayvalue='Water boy' /> ");
        strChartXML.Append("<line startValue='89.5' color='49563A' displayvalue='Second String' /> ");
        strChartXML.Append("<line startValue='94.5' color='49563A' displayvalue='Starter' /> ");
        strChartXML.Append("<line startValue='100' color='49563A' displayvalue='All Pro' /> ");
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

    #region "Other Methods"

    /// <summary>
    /// Bind Wall Main Post
    /// </summary>
    /// <param name="PageNumber"></param>
    /// <param name="PageSize"></param>
    private void BindPosts(int PageNumber, int PageSize)
    {
        string strLastName = Convert.ToString(txtPosterLastName.Text.Trim().Replace("'", "''"));
        string strFirstName = Convert.ToString(txtPosterFirstName.Text.Trim().Replace("'", "''"));
        DateTime? dtPostDateFrom = clsGeneral.FormatNullDateToStore(txtDatePostFrom.Text);
        DateTime? dtPostDateTo = clsGeneral.FormatNullDateToStore(txtDatePostTo.Text);
        string strPostText = Convert.ToString(txtPostText.Text.Trim().Replace("'", "''"));
        string strTopic = Convert.ToString(txtTopic.Text.Trim()).Replace("'", "''");

        DataSet dsPosts = clsDashboard_Wall.SearchWallPosts(PageNumber, PageSize, strLastName, strFirstName, dtPostDateFrom, dtPostDateTo, strPostText, strTopic);

        //// set values for paging control,so it shows values as needed.
        ctrlPageWallPost.TotalRecords = (dsPosts.Tables.Count >= 3) ? Convert.ToInt32(dsPosts.Tables[1].Rows[0][0]) : 0;
        ctrlPageWallPost.CurrentPage = (dsPosts.Tables.Count >= 3) ? Convert.ToInt32(dsPosts.Tables[2].Rows[0][2]) : 0;
        ctrlPageWallPost.RecordsToBeDisplayed = dsPosts.Tables[0].Rows.Count;
        ctrlPageWallPost.SetPageNumbers();


        if (dsPosts.Tables.Count >= 5)
        {
            dtComments = dsPosts.Tables[3];
            dtAttachments = dsPosts.Tables[4];
        }

        rptPosts.DataSource = dsPosts.Tables[0];
        rptPosts.DataBind();

        if (dsPosts.Tables[0].Rows.Count == 0)
        {
            Control FooterTemplate = rptPosts.Controls[rptPosts.Controls.Count - 1].Controls[0];
            FooterTemplate.FindControl("trEmpty").Visible = true;
        }

        // set record numbers retrieved
        lblNumber.Text = (dsPosts.Tables.Count >= 3) ? Convert.ToString(dsPosts.Tables[1].Rows[0][0]) : "0";
    }

    #endregion

    #region "Other Events"

    /// <summary>
    /// Repeater Item Data Bound Event - main wall
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void rptPosts_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            decimal _PK_Dashboard_Wall = Convert.ToDecimal(DataBinder.Eval(e.Item.DataItem, "PK_Dashboard_Wall"));

            //get attachment for Main wall
            DataRow[] drAttachment = dtAttachments.Select("FK_Dashboard_Wall=" + _PK_Dashboard_Wall);
            if (drAttachment != null && drAttachment.Length > 0)
            {
                ///Get the File name to show and saved file
                string strInput_File_Name = Convert.ToString(drAttachment[0]["Input_File_Name"]);
                if (strInput_File_Name.ToLower().EndsWith(".jpg") || strInput_File_Name.ToLower().EndsWith(".jpeg") || strInput_File_Name.ToLower().EndsWith(".gif") ||
                    strInput_File_Name.ToLower().EndsWith(".png") || strInput_File_Name.ToLower().EndsWith(".tif") || strInput_File_Name.ToLower().EndsWith(".tiff"))
                {//for Image attachment
                    Image imgAttachment = (Image)e.Item.FindControl("imgAttachment");
                    imgAttachment.Visible = true;
                    imgAttachment.Style.Add("cursor", "hand");
                    imgAttachment.Style.Add("padding-top", "5px");
                    imgAttachment.Style.Add("padding-left", "5px");

                    // show thumbnail of the image
                    string strFileName = clsGeneral.Encode_Url(Convert.ToString(drAttachment[0]["Stored_File_Name"]));
                    string strThumbnail = strFileName.Substring(0, strFileName.LastIndexOf(".") - 1) + "_Thumb" + strFileName.Substring(strFileName.LastIndexOf("."));

                    if (File.Exists(AppConfig.SitePath + "Documents/Dashboard_Wall_Attachment/" + Convert.ToString(drAttachment[0]["Stored_File_Name"])))
                    {
                        imgAttachment.ImageUrl = AppConfig.SiteURL + "Documents/Dashboard_Wall_Attachment/" + strThumbnail;
                        imgAttachment.Attributes.Add("onclick", "javascript:return openWindow('" + AppConfig.SiteURL + "Documents/Dashboard_Wall_Attachment/" + strFileName + "');");
                    }
                    else
                    {
                        imgAttachment.ImageUrl = AppConfig.SiteURL + "Images/NoImage.jpg";
                        imgAttachment.Attributes.Add("onclick", "javascript:return openWindow('" + AppConfig.SiteURL + "Images/NoImage.jpg" +"');");
                    }

                    //imgAttachment.ImageUrl = AppConfig.SiteURL + "Documents/Dashboard_Wall_Attachment/" + strThumbnail;
                    //imgAttachment.Attributes.Add("onclick", "javascript:return openWindow('" + AppConfig.SiteURL + "Documents/Dashboard_Wall_Attachment/" + strFileName + "');");
                }
                else
                {///for documents
                    LinkButton lnkAttchment = (LinkButton)e.Item.FindControl("lnkAttchment");
                    lnkAttchment.Text = strInput_File_Name;
                    lnkAttchment.Style.Add("cursor", "hand");
                    lnkAttchment.Visible = true;

                    if (File.Exists(AppConfig.SitePath + "Documents/Dashboard_Wall_Attachment/" + Convert.ToString(drAttachment[0]["Stored_File_Name"])))
                        lnkAttchment.OnClientClick = "javascript:return openWindow('" + AppConfig.SiteURL + "Documents/Dashboard_Wall_Attachment/" + clsGeneral.Encode_Url(Convert.ToString(drAttachment[0]["Stored_File_Name"])) + "');";
                    else
                        lnkAttchment.OnClientClick = "javascript:alert('Attachment Not Found');return false;";
                }
            }
            else
            {
                ((Label)e.Item.FindControl("lblAttchment")).Visible = false;
            }

            ///set the radio buttons and Bind inner grid
            // RadioButtonList rdbThredTypeComment = (RadioButtonList)e.Item.FindControl("rdbThredTypeComment");
            //rdbThredTypeComment.SelectedValue = rdbThredType.SelectedValue;
            Repeater rptPostsComments = (Repeater)e.Item.FindControl("rptPostsComments");
            //Label lblShowThread = (Label)e.Item.FindControl("lblShowThread");

            //if (rdbThredType.SelectedIndex == 0)
            //{
            ///Select the records by FK wall
            dtComments.DefaultView.RowFilter = "FK_Dashboard_Wall=" + _PK_Dashboard_Wall;
            //dtComments.DefaultView.Sort = "Update_Date " + Convert.ToString(rdbCommentDateOrder.SelectedItem.Text);
            rptPostsComments.DataSource = dtComments.DefaultView;
            rptPostsComments.DataBind();
            rptPostsComments.Visible = true;

            ///set the Div height based on message length
            HiddenField hdMessageLength = (HiddenField)e.Item.FindControl("hdMessageLength");
            HtmlGenericControl dvMainMessage = (HtmlGenericControl)e.Item.FindControl("dvMainMessage");
            int intMessageLength = Convert.ToInt32(Convert.ToString(DataBinder.Eval(e.Item.DataItem, "Message")).Length);
            hdMessageLength.Value = intMessageLength.ToString();

            ///check the Message length
            if (intMessageLength >= 2500)
            {
                dvMainMessage.Style.Add("height", "200px");
                ((HtmlContainerControl)e.Item.FindControl("tdExpandControls")).Visible = true;
            }
            else
                ((HtmlContainerControl)e.Item.FindControl("tdExpandControls")).Visible = false;
        }
    }

    /// <summary>
    /// Repeater Main Wall item Command Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void rptPosts_ItemCommand(object sender, RepeaterCommandEventArgs e)
    {
        //check item command for add comment
        if (e.CommandName.ToString() == "btnComment")
        {
            //redirect to add sub comment screen
            decimal _PK_Dashboard_Wall = Convert.ToDecimal(e.CommandArgument);
            //Response.Redirect("AddeRims2Wall.aspx?type=2&id=" + Encryption.Encrypt(_PK_Dashboard_Wall.ToString()) + "");
        }
    }

    /// <summary>
    /// Repeater Comments Item Data Bound Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void rptPostsComments_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            ///set and get the Display file name and Save file name for attachment
            string strInput_File_Name = Convert.ToString(DataBinder.Eval(e.Item.DataItem, "Input_File_Name"));
            string strStored_File_Name = Convert.ToString(DataBinder.Eval(e.Item.DataItem, "Stored_File_Name"));
            if (strInput_File_Name.Trim() != null && strInput_File_Name != "")
            {
                if (strInput_File_Name.ToLower().EndsWith(".jpg") || strInput_File_Name.ToLower().EndsWith(".jpeg") || strInput_File_Name.ToLower().EndsWith(".gif") ||
                    strInput_File_Name.ToLower().EndsWith(".png") || strInput_File_Name.ToLower().EndsWith(".tif") || strInput_File_Name.ToLower().EndsWith(".tiff"))
                {//for Image attachment
                    Image imgAttachment = (Image)e.Item.FindControl("imgAttachmentComment");
                    imgAttachment.Visible = true;
                    imgAttachment.Style.Add("cursor", "hand");
                    imgAttachment.Style.Add("padding-top", "5px");

                    // show thumbnail of the image
                    string strFileName = strStored_File_Name;
                    string strThumbnail = strFileName.Substring(0, strFileName.LastIndexOf(".") - 1) + "_Thumb" + strFileName.Substring(strFileName.LastIndexOf("."));

                    imgAttachment.ImageUrl = AppConfig.SiteURL + "Documents/Dashboard_Wall_Attachment/" + strThumbnail;
                    imgAttachment.Attributes.Add("onclick", "javascript:window.open('" + AppConfig.SiteURL + "Documents/Dashboard_Wall_Attachment/" + strFileName + "')");
                }
                else
                {///for documents
                    LinkButton lnkAttchment = (LinkButton)e.Item.FindControl("lnkAttchmentComment");
                    lnkAttchment.Text = strInput_File_Name;
                    lnkAttchment.Style.Add("cursor", "hand");
                    lnkAttchment.Visible = true;
                    lnkAttchment.OnClientClick = "javascript:return openWindow('" + AppConfig.SiteURL + "Documents/Dashboard_Wall_Attachment/" + strStored_File_Name + "');";
                }
            }
            else
            {
                ///if file name is null then disable the attachment option
                ((Label)e.Item.FindControl("lblAttchmentComment")).Visible = false;
            }

            ///set the Div height based on message length
            HiddenField hdCommentMsgLength = (HiddenField)e.Item.FindControl("hdCommentMsgLength");
            HtmlGenericControl dvCommentMessage = (HtmlGenericControl)e.Item.FindControl("dvCommentMessage");
            int intMessageLength = Convert.ToInt32(Convert.ToString(DataBinder.Eval(e.Item.DataItem, "Message")).Length);
            hdCommentMsgLength.Value = intMessageLength.ToString();

            ///check the message lengths
            if (intMessageLength >= 2500)
            {
                //set div height and set visible
                dvCommentMessage.Style.Add("height", "200px");
                ((HtmlContainerControl)e.Item.FindControl("trExpandControls")).Visible = true;
            }
            else
                ((HtmlContainerControl)e.Item.FindControl("trExpandControls")).Visible = false;

        }
    }

    /// <summary>
    /// Implement event for Paging control when clicking on Go button
    /// </summary>
    protected void GetPage()
    {
        BindPosts(ctrlPageWallPost.CurrentPage, ctrlPageWallPost.PageSize);
    }

    /// <summary>
    /// Button Add Click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Response.Redirect("AddeRims2Wall.aspx?type=1");
    }

    /// <summary>
    /// Button Search Click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        pnlSearch.Visible = true;
        pnlWall.Visible = false;

        rptPosts.DataSource = null;
        rptPosts.DataBind();

        txtDatePostFrom.Text = "";
        txtDatePostTo.Text = "";
        txtPosterFirstName.Text = "";
        txtPosterLastName.Text = "";
        txtPostText.Text = "";
        txtTopic.Text = "";
    }

    /// <summary>
    /// Button Search result click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSearchResult_Click(object sender, EventArgs e)
    {
        pnlSearch.Visible = false;
        pnlWall.Visible = true;

        ctrlPageWallPost.setDrpRecordsValue();
        BindPosts(1, 10);
    }
    #endregion
}