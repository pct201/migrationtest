using System;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InfoSoftGlobal;
using ERIMS.DAL;
using System.Data;

public partial class DashboardGraphCal : clsBasePage
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
            DataRow drCal = dtResult1.NewRow();
            drCal[0] = "Western Region";
            drCal[1] = dtResult1.Compute("AVG(Score)", "Region in ('NCA','SCA')");
            dtResult1.Rows.Add(drCal);

            dtResult1.DefaultView.RowFilter = "Region not in ('NCA','SCA')";
            //dtResult1.DefaultView.Sort = "Region";
            //dtResult1 = dtResult1.DefaultView.ToTable();
            DataView dvRegion = dtResult1.DefaultView;
            dvRegion.Sort = "Score DESC, Region ASC";
            dtResult1 = dvRegion.ToTable();

            if (ds.Tables.Count > 1)
            {
                if (ds.Tables[1].Rows.Count > 0)
                {
                    decimal.TryParse(Convert.ToString(ds.Tables[1].Rows[0]["Average_Score"]), out _decAvg);
                }
            }
            string strHeader = "";
            if (dtResult1.Rows.Count > 1)
                strHeader = "Safety Training Scorecard By Region";
            else
                strHeader = "Safety Training Scorecard";
            // Set Chart property 
            strXML.Append("<chart caption='" + strHeader + "' xAxisName='Region' plotGradientColor='' bgColor='#FFFFFF' yAxisName='Level'  useRoundEdges='0' showValues='0' formatNumberScale='0' showBorder='0' rotateYAxisName='0' showYAxisValues='0' yAxisMinValue='0' yAxisMaxValue='17' labelDisplay='ROTATE' maxColWidth='40' slantLabels='0' use3DLighting='0' divLineAlpha='0' baseFont='Verdana' baseFontColor='6f6c6c' baseFontSize='10' trendValueFontBold ='1'>");

            // Set Lable
            for (int i = 0; i < dtResult1.Rows.Count; i++)
            {
                strXML.AppendFormat("<set label='{0}' value='{1}' link='{2}' color='{3}' />", Convert.ToString(dtResult1.Rows[i][0]), Convert.ToString(dtResult1.Rows[i][1]), Server.UrlEncode("JavaScript:OpenPopup(\"" + Convert.ToString(dtResult1.Rows[i][0]) + "\",\"" + Convert.ToString(Year) + "\",\"3\"," + Convert.ToString(_decAvg) + ");"), Charts.GetColorCodeFromScore(clsGeneral.GetDecimal(dtResult1.Rows[i]["Score"])));
            }

            GetTreadLineStyle(strXML, _decAvg);
            strXML.Append("</chart>");
        }
        // Generate Chart
        return InfoSoftGlobal.FusionCharts.RenderChart(AppConfig.SiteURL + "FusionCharts/Bar2D.swf?ChartNoDataText=No data to display for: Saba Training Scoreboard By Region", "", strXML.ToString(), "SabaTrainingByRegion", "490", "400", false, true);
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
        DataRow drCal = dtRegion.NewRow();
        drCal[0] = "Western Region";
        dtRegion.Rows.Add(drCal);
        dtRegion.DefaultView.RowFilter = "Region not in ('NCA','SCA')";
        dtRegion.DefaultView.Sort = "Region";
        dtRegion = dtRegion.DefaultView.ToTable();
        
        dtRegion.Columns.Add(new DataColumn("Score", typeof(decimal)));
        dtRegion.Columns.Add(new DataColumn("Performance", typeof(string)));
        
        DataTable dtAverage = new DataTable();
        dtAverage.Columns.Add(new DataColumn("Score", typeof(decimal)));

        DataSet dsResult = Charts.GetFacilityInspectionByRegion(Year);
        dtResult = dsResult.Tables[0];
        AddStateCalifornia(ref dtResult);
        dtAverage.Rows.Add(dtAverage.NewRow()[0] = dsResult.Tables[1].Rows[0][0]);

        dsResult = Charts.GetIncidentInvestigationByRegion(Year);
        dtResult.Merge(dsResult.Tables[0]);
        AddStateCalifornia(ref dtResult);
        dtAverage.Rows.Add(dtAverage.NewRow()[0] = dsResult.Tables[1].Rows[0][0]);

        dsResult = Charts.GetIncidentReductionByRegion(Year);
        dtResult.Merge(dsResult.Tables[0]);
        AddStateCalifornia(ref dtResult);
        dtAverage.Rows.Add(dtAverage.NewRow()[0] = dsResult.Tables[1].Rows[0][0]);

        dsResult = Charts.GetSabaTrainingByRegion(Year);
        dtResult.Merge(dsResult.Tables[0]);
        AddStateCalifornia(ref dtResult);
        dtAverage.Rows.Add(dtAverage.NewRow()[0] = (dsResult.Tables[1].Rows[0][0] != DBNull.Value ? dsResult.Tables[1].Rows[0][0] : 0));

        dsResult = Charts.GetWCClaimMgmtByRegion(Year);
        dtResult.Merge(dsResult.Tables[0]);
        AddStateCalifornia(ref dtResult);
        dtAverage.Rows.Add(dtAverage.NewRow()[0] = dsResult.Tables[1].Rows[0][0]);

        dsResult = Charts.GETSLTBYRegion(Year);
        dtResult.Merge(dsResult.Tables[0]);
        AddStateCalifornia(ref dtResult);
        dtAverage.Rows.Add(dtAverage.NewRow()[0] = dsResult.Tables[1].Rows[0][0]);

        //drCal = dtResult.NewRow();
        //drCal[0] = "California";
        //drCal[1] = dtResult.Compute("AVG(Score)", "Region in ('NCA','SCA')");
        //dtResult.Rows.Add(drCal);

        //dtResult.DefaultView.RowFilter = "Region not in ('NCA','SCA')";
        //dtResult = dtResult.DefaultView.ToTable();

        for (int _iRow = 0; _iRow < dtRegion.Rows.Count; _iRow++)
        {
            dtRegion.Rows[_iRow][1] = _intScore = 0;
            decimal decAvg = Convert.ToDecimal(dtResult.Compute("AVG(Score)", " Region = '" + Convert.ToString(dtRegion.Rows[_iRow]["region"]) + "' "));
            decimal.TryParse(Convert.ToString(dtResult.Compute("SUM(Score)", " Region = '" + Convert.ToString(dtRegion.Rows[_iRow]["region"]) + "' ")), out _intScore);

            //if (_intScore > 189 && _intScore <= 200)
            //{
            //    dtRegion.Rows[_iRow][2] = "Platinum";
            //    dtRegion.Rows[_iRow][1] = _intScore;
            //}
            //else if (_intScore > 179 && _intScore <= 189)
            //{
            //    dtRegion.Rows[_iRow][2] = "Gold";
            //    dtRegion.Rows[_iRow][1] = _intScore;
            //}
            //else if (_intScore > 159 && _intScore <= 179)
            //{
            //    dtRegion.Rows[_iRow][2] = "Silver";
            //    dtRegion.Rows[_iRow][1] = _intScore;
            //}
            //else if (_intScore > 139 && _intScore <= 159)
            //{
            //    dtRegion.Rows[_iRow][2] = "Bronze";
            //    dtRegion.Rows[_iRow][1] = _intScore;
            //}
            //else if (_intScore >= 0 && _intScore <= 139)
            //{
            //    dtRegion.Rows[_iRow][2] = "Tin";
            //    dtRegion.Rows[_iRow][1] = _intScore;
            //}

            ////Change as per bug-tracker #3585,further change as per 3600 #35143..
            //_intScore = (_intScore / 200) * 100;

            if (_intScore >= 95 && _intScore <= 100)
            {
                dtRegion.Rows[_iRow][2] = Charts.Platinum_Label_Graph;
                dtRegion.Rows[_iRow][1] = _intScore;
            }
            else if (_intScore >= 90 && _intScore < 95)
            {
                dtRegion.Rows[_iRow][2] = Charts.Gold_Label_Graph;
                dtRegion.Rows[_iRow][1] = _intScore;
            }
            else if (_intScore >= 80 && _intScore < 90)
            {
                dtRegion.Rows[_iRow][2] = Charts.Silver_Label_Graph;
                dtRegion.Rows[_iRow][1] = _intScore;
            }
            else if (_intScore >= 70 && _intScore < 80)
            {
                dtRegion.Rows[_iRow][2] = Charts.Bronze_Label_Graph;
                dtRegion.Rows[_iRow][1] = _intScore;
            }
            else if (_intScore >= 0 && _intScore < 70)
            {
                dtRegion.Rows[_iRow][2] = Charts.Tin_Label_Graph;
                dtRegion.Rows[_iRow][1] = _intScore;
            }
        }

        DataView dvRegion = dtRegion.DefaultView;
        dvRegion.Sort = "Score DESC, Region ASC";
        dtRegion = dvRegion.ToTable();

        string strHeader = "";
        if (dtRegion.Rows.Count > 1)
            strHeader = "Aggregate Performance By Region";
        else
            strHeader = "Aggregate Performance";

        // Set Chart property 
        strChartXML.Append("<chart caption='" + strHeader + "' showalternatevgridcolor='0' bgColor='#FFFFFF' plotGradientColor='' xAxisName='Region' yAxisName='Level' useRoundEdges='0' showValues='0' formatNumberScale='0' showBorder='0' rotateYAxisName='0' showYAxisValues='0' yAxisMinValue='45' yAxisMaxValue='102' labelDisplay='ROTATE' maxColWidth='40' slantLabels='0' use3DLighting='0' divLineAlpha='0' baseFont='Verdana' baseFontColor='6f6c6c' baseFontSize='10' trendValueFontBold ='1'>");

        decimal _devAvg = 0;
        //decimal.TryParse(Convert.ToString(dtAverage.Compute("AVG(Score)", "")), out _devAvg);
        decimal.TryParse(Convert.ToString(dtRegion.Compute("AVG(Score)", "")), out _devAvg);

        // Set Label
        for (int i = 0; i < dtRegion.Rows.Count; i++)
        {
            strChartXML.AppendFormat("<set label='{0}' value='{1}' link='{2}' color='{3}' />", Convert.ToString(dtRegion.Rows[i][0]), Convert.ToString(dtRegion.Rows[i][1]), Server.UrlEncode("JavaScript:OpenPopup(\"" + Convert.ToString(dtRegion.Rows[i][0]) + "\",\"" + Year.ToString() + "\",\"1\"," + Convert.ToString(_devAvg) + ");"), Charts.GetColorCodeFromScoreAggregate(clsGeneral.GetDecimal(dtRegion.Rows[i]["Score"])));
        }

        // set Tread Lines
        strChartXML.Append("<trendLines>");
        strChartXML.Append("<line startValue='70' color='49563A' displayvalue='" + Charts.Tin_Label_Graph + "' /> ");
        strChartXML.Append("<line startValue='80' color='49563A' displayvalue='" + Charts.Bronze_Label_Graph + "' /> ");
        strChartXML.Append("<line startValue='90' color='49563A' displayvalue='" + Charts.Silver_Label_Graph + "' /> ");
        strChartXML.Append("<line startValue='95' color='49563A' displayvalue='" + Charts.Gold_Label_Graph + "' /> ");
        strChartXML.Append("<line startValue='100' color='49563A' displayvalue='" + Charts.Platinum_Label_Graph + "' /> ");
        //strChartXML.Append("<line startValue='" + string.Format("{0:N2}", _devAvg) + "' color='FF0000' displayvalue='Company Average' valueOnRight='1' thickness='2' /> ");
        strChartXML.Append("<line startValue='95'  color='FF0000' displayvalue='{br}Cross The Line' valueOnRight='1' thickness='2' /> ");

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
        return InfoSoftGlobal.FusionCharts.RenderChart(AppConfig.SiteURL + "FusionCharts/Bar2D.swf?ChartNoDataText=No data to display for: Aggregate Performance By Region", "", strChartXML.ToString(), "AggregatePerformanceByRegion", "490", "400", false, true);
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
        DataRow drCal = dtResult.NewRow();
        drCal[0] = "Western Region";
        drCal[1] = dtResult.Compute("AVG(Score)", "Region in ('NCA','SCA')");
        dtResult.Rows.Add(drCal);

        dtResult.DefaultView.RowFilter = "Region not in ('NCA','SCA')";
        dtResult.DefaultView.Sort = "Score DESC, Region ASC";
        dtResult = dtResult.DefaultView.ToTable();

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
        strChartXML.Append("<chart caption='" + strHeader + "' plotGradientColor='' xAxisName='Region' bgColor='#FFFFFF' yAxisName='Level' useRoundEdges='0' showValues='0' formatNumberScale='0' showBorder='0' rotateYAxisName='0' showYAxisValues='0' yAxisMinValue='0' yAxisMaxValue='17' labelDisplay='ROTATE' maxColWidth='40' slantLabels='0' use3DLighting='0' divLineAlpha='0' baseFont='Verdana' baseFontColor='6f6c6c' baseFontSize='10' trendValueFontBold ='1'>");

        // Set Lable
        for (int i = 0; i < dtResult.Rows.Count; i++)
        {
            strChartXML.AppendFormat("<set label='{0}' value='{1}' link='{2}' color='{3}' />", Convert.ToString(dtResult.Rows[i][0]), Convert.ToString(dtResult.Rows[i][1]), Server.UrlEncode("JavaScript:OpenPopup(\"" + Convert.ToString(dtResult.Rows[i][0]) + "\",\"" + Year.ToString() + "\",\"2\"," + Convert.ToString(_decAvg) + ");"), Charts.GetColorCodeFromScore(clsGeneral.GetDecimal(dtResult.Rows[i]["Score"])));
        }

        GetTreadLineStyle(strChartXML, _decAvg);

        strChartXML.Append("</chart>");

        // Generate Chart
        return InfoSoftGlobal.FusionCharts.RenderChart(AppConfig.SiteURL + "FusionCharts/Bar2D.swf?ChartNoDataText=No data to display for: Facility Inspection By Region", "", strChartXML.ToString(), "FacilityInspectionByRegion", "490", "400", false, true);
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
        DataRow drCal = dtResult.NewRow();
        drCal[0] = "Western Region";
        drCal[1] = dtResult.Compute("AVG(Score)", "Region in ('NCA','SCA')");
        dtResult.Rows.Add(drCal);

        dtResult.DefaultView.RowFilter = "Region not in ('NCA','SCA')";
        dtResult.DefaultView.Sort = "Score DESC, Region ASC";
        dtResult = dtResult.DefaultView.ToTable();
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
        strChartXML.Append("<chart caption='" + strHeader + "'  plotGradientColor='' bgColor='#FFFFFF' xAxisName='Region' yAxisName='Level' useRoundEdges='0' showValues='0' formatNumberScale='0' showBorder='0' rotateYAxisName='0' showYAxisValues='0' yAxisMinValue='0' yAxisMaxValue='17' labelDisplay='ROTATE' maxColWidth='40' slantLabels='0' use3DLighting='0' divLineAlpha='0' baseFont='Verdana' baseFontColor='6f6c6c' baseFontSize='10' trendValueFontBold ='1'>");

        // Set Lable
        for (int i = 0; i < dtResult.Rows.Count; i++)
        {
            strLink = Server.UrlEncode("JavaScript:OpenPopup(\"" + Convert.ToString(dtResult.Rows[i]["region"]) + "\",\"" + Year.ToString() + "\",\"4\"," + Convert.ToString(_decAvg) + ");");
            strChartXML.AppendFormat("<set label='{0}' value='{1}' link='{2}' color='{3}' />", Convert.ToString(dtResult.Rows[i]["Region"]), Convert.ToString(dtResult.Rows[i]["Score"]), strLink, Charts.GetColorCodeFromScore(clsGeneral.GetDecimal(dtResult.Rows[i]["Score"])));
        }

        GetTreadLineStyle(strChartXML, _decAvg);

        strChartXML.Append("</chart>");

        // Generate Chart
        return InfoSoftGlobal.FusionCharts.RenderChart(AppConfig.SiteURL + "FusionCharts/Bar2D.swf?ChartNoDataText=No data to display for: Incident Investigation By Region", "", strChartXML.ToString(), "IncidentInvestigationByRegion", "490", "400", false, true);
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
        DataRow drCal = dtResult.NewRow();
        drCal[0] = "Western Region";
        drCal[1] = dtResult.Compute("AVG(Score)","Region in ('NCA','SCA')");
        dtResult.Rows.Add(drCal);

        dtResult.DefaultView.RowFilter = "Region not in ('NCA','SCA')";
        dtResult.DefaultView.Sort = "Score DESC, Region ASC";
        dtResult = dtResult.DefaultView.ToTable();

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
        strChartXML.Append("<chart caption='" + strHeader + "' showalternatevgridcolor='0' plotGradientColor='' bgColor='#FFFFFF' xAxisName='Region' yAxisName='Level' useRoundEdges='0' showValues='0' formatNumberScale='0' showBorder='0' rotateYAxisName='0' showYAxisValues='0' yAxisMinValue='0' yAxisMaxValue='35' labelDisplay='ROTATE' maxColWidth='40' slantLabels='0' use3DLighting='0' divLineAlpha='0' baseFont='Verdana' baseFontColor='6f6c6c' baseFontSize='10' trendValueFontBold ='1'>");

        // Set Lable
        for (int i = 0; i < dtResult.Rows.Count; i++)
        {
            strChartXML.AppendFormat("<set label='{0}' value='{1}' link='{2}' color='{3}' />", Convert.ToString(dtResult.Rows[i][0]), Convert.ToString(dtResult.Rows[i][1]), Server.UrlEncode("JavaScript:OpenPopup(\"" + Convert.ToString(dtResult.Rows[i][0]) + "\",\"" + Convert.ToString(Year) + "\",\"7\"," + Convert.ToString(_decAvg) + ");"), Charts.GetColorCodeFromScore_SLT(clsGeneral.GetDecimal(dtResult.Rows[i]["Score"])));
        }

        GetTreadLineStyle_SLT(strChartXML, _decAvg);

        strChartXML.Append("</chart>");

        // Generate Chart
        return InfoSoftGlobal.FusionCharts.RenderChart(AppConfig.SiteURL + "FusionCharts/Bar2D.swf?ChartNoDataText=No data to display for: Safety Leadership Team By Region", "", strChartXML.ToString(), "SafetyLeadershipTeamByRegion", "490", "400", false, true);
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
        DataRow drCal = dtResult.NewRow();
        drCal[0] = "Western Region";
        drCal[1] = dtResult.Compute("AVG(Score)", "Region in ('NCA','SCA')");
        dtResult.Rows.Add(drCal);

        dtResult.DefaultView.RowFilter = "Region not in ('NCA','SCA')";
        dtResult.DefaultView.Sort = "Score DESC, Region ASC";
        dtResult = dtResult.DefaultView.ToTable();
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
        strChartXML.Append("<chart caption='" + strHeader + "' xAxisName='Region' plotGradientColor='' yAxisName='Level' bgColor='#FFFFFF' useRoundEdges='0' showValues='0' formatNumberScale='0' showBorder='0' rotateYAxisName='0' showYAxisValues='0' yAxisMinValue='0' yAxisMaxValue='17' labelDisplay='ROTATE' maxColWidth='40' slantLabels='0' use3DLighting='0' divLineAlpha='0' baseFont='Verdana' baseFontColor='6f6c6c' baseFontSize='10' trendValueFontBold ='1' >");

        // Set Lable
        for (int i = 0; i < dtResult.Rows.Count; i++)
        {
            strLink = Server.UrlEncode("JavaScript:OpenPopup(\"" + Convert.ToString(dtResult.Rows[i]["region"]) + "\",\"" + Convert.ToString(Year) + "\",\"6\"," + Convert.ToString(_decAvg) + ");");
            strChartXML.AppendFormat("<set label='{0}' value='{1}' link='{2}' color='{3}' />", Convert.ToString(dtResult.Rows[i]["Region"]), Convert.ToString(dtResult.Rows[i]["Score"]), strLink, Charts.GetColorCodeFromScore(clsGeneral.GetDecimal(dtResult.Rows[i]["Score"])));
        }

        GetTreadLineStyle(strChartXML, _decAvg);
        strChartXML.Append("</chart>");

        // Generate Chart
        return InfoSoftGlobal.FusionCharts.RenderChart(AppConfig.SiteURL + "FusionCharts/Bar2D.swf?ChartNoDataText=No data to display for: Incident Reduction By Region", "", strChartXML.ToString(), "IncidentReductionByRegion", "490", "400", false, true);
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
        DataRow drCal = dtResult.NewRow();
        drCal[0] = "Western Region";
        drCal[1] = dtResult.Compute("AVG(Score)", "Region in ('NCA','SCA')");
        dtResult.Rows.Add(drCal);

        dtResult.DefaultView.RowFilter = "Region not in ('NCA','SCA')";
        dtResult.DefaultView.Sort = "Score DESC, Region ASC";
        dtResult = dtResult.DefaultView.ToTable();
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
        strChartXML.Append("<chart caption='" + strHeader + "' xAxisName='Region' plotGradientColor='' yAxisName='Level' bgColor='#FFFFFF' useRoundEdges='0' showValues='0' formatNumberScale='0' showBorder='0' rotateYAxisName='0' showYAxisValues='0' yAxisMinValue='0' yAxisMaxValue='17' labelDisplay='ROTATE' maxColWidth='40' slantLabels='0' use3DLighting='0' divLineAlpha='0' baseFont='Verdana' baseFontColor='6f6c6c' baseFontSize='10' trendValueFontBold ='1'>");

        // Set Lable
        for (int i = 0; i < dtResult.Rows.Count; i++)
        {
            strLink = Server.UrlEncode("JavaScript:OpenPopup(\"" + Convert.ToString(dtResult.Rows[i]["region"]) + "\",\"" + Convert.ToString(Year) + "\",\"5\"," + Convert.ToString(_decAvg) + ");");
            strChartXML.AppendFormat("<set label='{0}' value='{1}' link='{2}' color='{3}' />", Convert.ToString(dtResult.Rows[i]["Region"]), Convert.ToString(dtResult.Rows[i]["Score"]), strLink, Charts.GetColorCodeFromScore(clsGeneral.GetDecimal(dtResult.Rows[i]["Score"])));
        }

        GetTreadLineStyle(strChartXML, _decAvg);

        strChartXML.Append("</chart>");

        // Generate Chart
        return InfoSoftGlobal.FusionCharts.RenderChart(AppConfig.SiteURL + "FusionCharts/Bar2D.swf?ChartNoDataText=No data to display for: Workers’ Compensation Claims Management By Region", "", strChartXML.ToString(), "WCClaimMgmtByRegion", "490", "400", false, true);
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
        strChartXML.Append("<line startValue='2' color='49563A' displayvalue='T' /> ");
        strChartXML.Append("<line startValue='5' color='49563A' displayvalue='B' /> ");
        strChartXML.Append("<line startValue='8' color='49563A' displayvalue='S' /> ");
        strChartXML.Append("<line startValue='11' color='49563A' displayvalue='G' /> ");
        strChartXML.Append("<line startValue='14' color='49563A' displayvalue='P' /> ");
        //strChartXML.Append("<line startValue='" + string.Format("{0:N2}", Average) + "' color='FF0000' displayvalue='Company Average' valueOnRight='1' thickness='2' /> ");

        strChartXML.Append("<line startValue='13.3' color='FF0000' displayvalue='{br}Cross The Line' valueOnRight='1' thickness='2'  /> ");

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
        strChartXML.Append("<line startValue='11.5' color='49563A' displayvalue='" + Charts.Tin_Label_Graph + "' /> ");
        strChartXML.Append("<line startValue='17.5' color='49563A' displayvalue='" + Charts.Bronze_Label_Graph + "' /> ");
        strChartXML.Append("<line startValue='23.5' color='49563A' displayvalue='" + Charts.Silver_Label_Graph + "' /> ");
        strChartXML.Append("<line startValue='29'  color='49563A' displayvalue='" + Charts.Gold_Label_Graph + "' /> ");
        strChartXML.Append("<line startValue='30'  color='49563A' displayvalue='" + Charts.Platinum_Label_Graph + "' /> ");
        //strChartXML.Append("<line startValue='" + string.Format("{0:N2}", Average) + "' color='FF0000' displayvalue='Company Average' valueOnRight='1' thickness='2' /> ");
        strChartXML.Append("<line startValue='28.5' color='FF0000' displayvalue='{br}Cross The Line' valueOnRight='1' thickness='2' /> ");
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

    private void AddStateCalifornia(ref DataTable dtResult)
    {
        DataRow drCal = dtResult.NewRow();
        drCal[0] = "Western Region";
        drCal[1] = string.IsNullOrEmpty(Convert.ToString(dtResult.Compute("AVG(Score)", "Region in ('NCA','SCA')"))) ? 0 : dtResult.Compute("AVG(Score)", "Region in ('NCA','SCA')");
        dtResult.Rows.Add(drCal);

        dtResult.DefaultView.RowFilter = "Region not in ('NCA','SCA')";
        dtResult.DefaultView.Sort = "Score DESC, Region ASC";
        dtResult = dtResult.DefaultView.ToTable();
    }

    #endregion
}