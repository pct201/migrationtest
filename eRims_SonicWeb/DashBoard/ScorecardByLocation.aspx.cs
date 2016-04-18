using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;

public partial class ScorecardByLocation : System.Web.UI.Page
{
    StringBuilder strChartXML = new StringBuilder();
    Decimal Average = 0;
    string strlink = string.Empty;

    #region "Property"

    /// <summary>
    /// Get Year paramenter
    /// </summary>
    public Int32 Year
    {
        get
        {
            return clsGeneral.GetInt(Request.QueryString["year"]);
        }
    }

    /// <summary>
    /// Get Date paramenter
    /// </summary>
    public DateTime Date
    {
        get
        {
            return clsGeneral.FormatDateToStore(Request.QueryString["Date"]);
        }
    }

    /// <summary>
    /// Set Region Parameter
    /// </summary>
    public string Region
    {
        get { return (string.IsNullOrEmpty(Request.QueryString["region"]) ? string.Empty : Convert.ToString(Request.QueryString["region"])); }
    }

    /// <summary>
    /// Get Current Map ID
    /// </summary>
    public int MapID
    {
        get
        {
            return clsGeneral.GetInt(Request.QueryString["map"]);
        }
    }

    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    #region "Chart Methods"

    public string GetDetailChart()
    {
        switch (MapID)
        {
            case 1:
                return GetAggregatePerformance();
            case 2:
                return GetFacilityInspection();
            case 3:
                return GetSabaTrainingByLocation();
            case 4:
                return GetIncidentInvestigation();
            case 5:
                return GetWCClaimMgmtByLocation();
            case 6:
                return GetIncidentReduction();
            case 7:
                return GetSLT();
            default:
                return string.Empty;
        }
    }

    private string GetAggregatePerformance()
    {
        DataSet dsSCA;
        DataTable dtResult, dtRegion;
        decimal _intScore = 0;

        string strReg = (Region == "Western Region") ? "NCA" : Region;
        dtRegion = ERIMS.DAL.LU_Location.SelectByRegionForDashboard(strReg).Tables[0];
        if (Region == "Western Region")
            dtRegion.Merge(ERIMS.DAL.LU_Location.SelectByRegionForDashboard("SCA").Tables[0]);
        //dtRegion.DefaultView.Sort = "DBA";
        dtRegion = dtRegion.DefaultView.ToTable();

        dtRegion.Columns.Add(new DataColumn("Score", typeof(decimal)));
        dtRegion.Columns.Add(new DataColumn("Performance", typeof(string)));

        DataTable dtAverage = new DataTable();
        dtAverage.Columns.Add(new DataColumn("Score", typeof(decimal)));

        //---------------------------------
        DataSet dsResult = Charts.GetFacilityInspectionByLocation(Year, strReg);
        dtResult = dsResult.Tables[0];
        dtAverage.Rows.Add(dtAverage.NewRow()[0] = (dsResult.Tables[1].Rows[0][0] != DBNull.Value ? dsResult.Tables[1].Rows[0][0] : 0));
        if (Region == "Western Region")
        {
            dsSCA = Charts.GetFacilityInspectionByLocation(Year, "SCA");
            dtResult.Merge(dsSCA.Tables[0]);
            dtAverage.Rows.Add(dtAverage.NewRow()[0] = (dsSCA.Tables[1].Rows[0][0] != DBNull.Value ? dsSCA.Tables[1].Rows[0][0] : 0));
        }
        //---------------------------------
        dsResult = Charts.GetIncidentInvestigationByLocation(Year, strReg);
        MergeColumn(ref dtResult, dsResult.Tables[0]);
        dtAverage.Rows.Add(dtAverage.NewRow()[0] = (dsResult.Tables[1].Rows[0][0] != DBNull.Value ? dsResult.Tables[1].Rows[0][0] : 0));
        if (Region == "Western Region")
        {
            dsSCA = Charts.GetIncidentInvestigationByLocation(Year, "SCA");
            MergeColumn(ref dtResult, dsSCA.Tables[0]);
            dtAverage.Rows.Add(dtAverage.NewRow()[0] = (dsSCA.Tables[1].Rows[0][0] != DBNull.Value ? dsSCA.Tables[1].Rows[0][0] : 0));
        }
        //---------------------------------
        dsResult = Charts.GetIncidentReductionByLocation(Year, strReg);
        MergeColumn(ref dtResult, dsResult.Tables[0]);
        dtAverage.Rows.Add(dtAverage.NewRow()[0] = (dsResult.Tables[1].Rows[0][0] != DBNull.Value ? dsResult.Tables[1].Rows[0][0] : 0));
        if (Region == "Western Region")
        {
            dsSCA = Charts.GetIncidentReductionByLocation(Year, "SCA");
            MergeColumn(ref dtResult, dsSCA.Tables[0]);
            dtAverage.Rows.Add(dtAverage.NewRow()[0] = (dsSCA.Tables[1].Rows[0][0] != DBNull.Value ? dsSCA.Tables[1].Rows[0][0] : 0));
        }
        //---------------------------------
        dsResult = Charts.GetSabaTrainingByLocation(Year, strReg);
        MergeColumn(ref dtResult, dsResult.Tables[0]);
        dtAverage.Rows.Add(dtAverage.NewRow()[0] = (dsResult.Tables[1].Rows[0][0] != DBNull.Value ? dsResult.Tables[1].Rows[0][0] : 0));
        if (Region == "Western Region")
        {
            dsSCA = Charts.GetSabaTrainingByLocation(Year, "SCA");
            MergeColumn(ref dtResult, dsSCA.Tables[0]);
            dtAverage.Rows.Add(dtAverage.NewRow()[0] = (dsSCA.Tables[1].Rows[0][0] != DBNull.Value ? dsSCA.Tables[1].Rows[0][0] : 0));
        }
        //---------------------------------
        dsResult = Charts.GetWCClaimMgmtByLocation(Year, strReg);
        MergeColumn(ref dtResult, dsResult.Tables[0]);
        dtAverage.Rows.Add(dtAverage.NewRow()[0] = (dsResult.Tables[1].Rows[0][0] != DBNull.Value ? dsResult.Tables[1].Rows[0][0] : 0));
        if (Region == "Western Region")
        {
            dsSCA = Charts.GetWCClaimMgmtByLocation(Year, "SCA");
            MergeColumn(ref dtResult, dsSCA.Tables[0]);
            dtAverage.Rows.Add(dtAverage.NewRow()[0] = (dsSCA.Tables[1].Rows[0][0] != DBNull.Value ? dsSCA.Tables[1].Rows[0][0] : 0));
        }
        //---------------------------------
        dsResult = Charts.GETSLTBYLocation(Year, strReg);
        MergeColumn(ref dtResult, dsResult.Tables[0]);
        dtAverage.Rows.Add(dtAverage.NewRow()[0] = (dsResult.Tables[1].Rows[0][0] != DBNull.Value ? dsResult.Tables[1].Rows[0][0] : 0));
        if (Region == "Western Region")
        {
            dsSCA = Charts.GETSLTBYLocation(Year, "SCA");
            MergeColumn(ref dtResult, dsSCA.Tables[0]);
            dtAverage.Rows.Add(dtAverage.NewRow()[0] = (dsSCA.Tables[1].Rows[0][0] != DBNull.Value ? dsSCA.Tables[1].Rows[0][0] : 0));
        }
        //---------------------------------`

        for (int _iRow = 0; _iRow < dtRegion.Rows.Count; _iRow++)
        {
            dtRegion.Rows[_iRow]["Score"] = _intScore = 0;
            decimal decAvg = Convert.ToDecimal(dtResult.Compute("AVG(Score)", " DBA = '" + Convert.ToString(dtRegion.Rows[_iRow]["DBA"]).Replace("'", "''") + "' "));
            decimal.TryParse(Convert.ToString(dtResult.Compute("SUM(Score)", " DBA = '" + Convert.ToString(dtRegion.Rows[_iRow]["DBA"]).Replace("'", "''") + "' ")), out _intScore);

            //if (_intScore > 189 && _intScore <= 200)
            //{
            //    dtRegion.Rows[_iRow]["Performance"] = "Platinum";
            //    dtRegion.Rows[_iRow]["Score"] = _intScore;
            //}
            //else if (_intScore > 179 && _intScore <= 189)
            //{
            //    dtRegion.Rows[_iRow]["Performance"] = "Starter";
            //    dtRegion.Rows[_iRow]["Score"] = _intScore;
            //}
            //else if (_intScore > 159 && _intScore <= 179)
            //{
            //    dtRegion.Rows[_iRow]["Performance"] = "Second String";
            //    dtRegion.Rows[_iRow]["Score"] = _intScore;
            //}
            //else if (_intScore > 139 && _intScore <= 159)
            //{
            //    dtRegion.Rows[_iRow]["Performance"] = "Water boy";
            //    dtRegion.Rows[_iRow]["Score"] = _intScore;
            //}
            //else if (_intScore >= 0 && _intScore <= 139)
            //{
            //    dtRegion.Rows[_iRow]["Performance"] = "Spectator";
            //    dtRegion.Rows[_iRow]["Score"] = _intScore;
            //}

            ////Change as per bug-tracker #3585.
            _intScore = (_intScore / 200) * 100;

            if (_intScore > 94.5m && _intScore <= 100)
            {
                dtRegion.Rows[_iRow]["Performance"] = Charts.Platinum_Label; 
                dtRegion.Rows[_iRow]["Score"] = _intScore;
            }
            else if (_intScore > 89.5m && _intScore <= 94.5m)
            {
                dtRegion.Rows[_iRow]["Performance"] = Charts.Gold_Label;
                dtRegion.Rows[_iRow]["Score"] = _intScore;
            }
            else if (_intScore > 79.5m && _intScore <= 89.5m)
            {
                dtRegion.Rows[_iRow]["Performance"] = Charts.Silver_Label;
                dtRegion.Rows[_iRow]["Score"] = _intScore;
            }
            else if (_intScore > 69.5m && _intScore <= 79.5m)
            {
                dtRegion.Rows[_iRow]["Performance"] = Charts.Bronze_Label;
                dtRegion.Rows[_iRow]["Score"] = _intScore;
            }
            else if (_intScore >= 0 && _intScore <= 69.5m)
            {
                dtRegion.Rows[_iRow]["Performance"] = Charts.Tin_Label;
                dtRegion.Rows[_iRow]["Score"] = _intScore;
            }

        }

        DataView dvRegion = dtRegion.DefaultView;
        dvRegion.Sort = "Score DESC, Region ASC";
        dtRegion = dvRegion.ToTable();

        // for new version
        string strWidth = dtRegion.Rows.Count > 25 ? "950" : "800";
        strChartXML.Append("<chart caption='Aggregate Performance for Region " + Region + "' plotGradientColor='' xAxisName='Location' yAxisName='Level' useRoundEdges='0' showValues='0' formatNumberScale='0' showBorder='0' rotateYAxisName='0' showYAxisValues='0' yAxisMinValue='0' yAxisMaxValue='120' labelDisplay='ROTATE' maxColWidth='40' slantLabels='0' use3DLighting='1' divLineAlpha='0' baseFont='Verdana' baseFontColor='6f6c6c' baseFontSize='10'>");

        // Set Label
        for (int i = 0; i < dtRegion.Rows.Count; i++)
        {
            //strlink = Server.UrlEncode("JavaScript:OpenPopupForAggreage(\"" + Region + "\",\"" + dtRegion.Rows[i]["DBA"].ToString() + "\",\"" + dtRegion.Rows[i]["Sonic_Location_Code"].ToString() + "\",\"" + Year.ToString() + "\",\"1\");").Replace("'", "%26apos;");            
            //strChartXML.AppendFormat("<set label='{0}' value='{1}' link='{2}'/>", Server.UrlEncode(dtRegion.Rows[i][0].ToString()).Replace("'", "%26apos;"), dtRegion.Rows[i][2].ToString(), strlink);            
            strlink = Server.UrlEncode("JavaScript:OpenPopupForAggreage(\"" + dtRegion.Rows[i]["Region"].ToString() + "\",\"" + dtRegion.Rows[i]["DBA"].ToString() + "\",\"" + dtRegion.Rows[i]["Sonic_Location_Code"].ToString() + "\",\"" + Year.ToString() + "\",\"1\");").Replace("'", "%26apos;");
            strChartXML.AppendFormat("<set label='{0}' value='{1}' link='{2}' color='{3}'/>", dtRegion.Rows[i][0].ToString().Replace("'", "&apos;"), dtRegion.Rows[i][3].ToString(), strlink, Charts.GetColorCodeFromScoreAggregate(Convert.ToDecimal(dtRegion.Rows[i]["Score"])));
        }

        Average = 0;
        //decimal.TryParse(Convert.ToString(dtAverage.Compute("AVG(Score)", "")), out Average);
        decimal.TryParse(Convert.ToString(dtRegion.Compute("AVG(Score)", "")), out Average);

        GetTreadLineStyle_Aggregate(strChartXML, Average);

        strChartXML.Append("</chart>");
        return InfoSoftGlobal.FusionCharts.RenderChart(AppConfig.SiteURL + "FusionCharts/Bar2D.swf?ChartNoDataText=No data to display for: Aggregate Performance for " + Region, "", strChartXML.ToString(), "AggregatePerformanceByRegion", strWidth, "550", false, true);
    }

    public string GetFacilityInspection()
    {
        string strReg = (Region == "Western Region") ? "NCA" : Region;
        DataSet dsReport = Charts.GetFacilityInspectionByLocation(Year, strReg);
        DataTable dtReport = dsReport.Tables[0];

        if (dsReport.Tables.Count > 1)
            Average = decimal.Parse(Convert.ToString(dsReport.Tables[1].Rows[0][0]));

        if (Region == "Western Region")
        {
            DataSet dsSCA = Charts.GetFacilityInspectionByLocation(Year, "SCA");
            dtReport.Merge(dsSCA.Tables[0]);
            dtReport.DefaultView.Sort = "Score desc, DBA asc";
            dtReport = dtReport.DefaultView.ToTable();
            decimal decAvg = 0;
            if (dsSCA.Tables[1].Rows.Count > 0 && !string.IsNullOrEmpty(dsSCA.Tables[1].Rows[0][0].ToString()))
                decAvg = decimal.Parse(Convert.ToString(dsSCA.Tables[1].Rows[0][0]));
            Average = (Average + decAvg) / 2.0M;
        }


        //strChartXML.Append("<chart caption='Facility Inspection for Region " + Region + "' xAxisName='Location' yAxisName='Level' useRoundEdges='1' showValues='0' formatNumberScale='0' showBorder='0' rotateYAxisName='0' showYAxisValues='0' yAxisMinValue='0' yAxisMaxValue='6' labelDisplay='ROTATE' maxColWidth='40' slantLabels='0' use3DLighting='1' divLineAlpha='0'>");
        // for new version
        string strWidth = dsReport.Tables[0].Rows.Count > 25 ? "950" : "800";
        strChartXML.Append("<chart caption='Facility Inspection for Region " + Region + "' plotGradientColor='' xAxisName='Location' yAxisName='Level' useRoundEdges='0' showValues='0' formatNumberScale='0' showBorder='0' rotateYAxisName='0' showYAxisValues='0' yAxisMinValue='0' yAxisMaxValue='34' labelDisplay='ROTATE' maxColWidth='40' slantLabels='0' use3DLighting='1' divLineAlpha='0' baseFont='Verdana' baseFontColor='6f6c6c' baseFontSize='10'>");

        for (int i = 0; i < dtReport.Rows.Count; i++)
        {
            //strlink = Server.UrlEncode("JavaScript:OpenPopup(\"" + dtReport.Rows[i]["DBA"].ToString() + "\",\"" + dtReport.Rows[i]["Sonic_Location_Code"].ToString() + "\",\"" + Year.ToString() + "\",\"2\");").Replace("'", "%26apos;");
            //strChartXML.AppendFormat("<set label='{0}' value='{1}' link='{2}'/>", Server.UrlEncode(dtReport.Rows[i][0].ToString()).Replace("'", "%26apos;"), dtReport.Rows[i][1].ToString(), strlink);

            // for new version
            strlink = Server.UrlEncode("JavaScript:OpenPopup(\"" + dtReport.Rows[i]["DBA"].ToString() + "\",\"" + dtReport.Rows[i]["Sonic_Location_Code"].ToString() + "\",\"" + Year.ToString() + "\",\"2\");").Replace("'", "%26apos;");
            strChartXML.AppendFormat("<set label='{0}' value='{1}' link='{2}' color='{3}'/>", dtReport.Rows[i][0].ToString().Replace("'", "&apos;"), dtReport.Rows[i][1].ToString(), strlink, Charts.GetColorCodeFromScore(Convert.ToDecimal(dtReport.Rows[i]["Score"])));
        }

        // Get Style 
        GetTreadLineStyle(strChartXML, Average);

        strChartXML.Append("</chart>");

        return InfoSoftGlobal.FusionCharts.RenderChart(AppConfig.SiteURL + "FusionCharts/Bar2D.swf?ChartNoDataText=No data to display for: Aggregate Performance By Location", "", strChartXML.ToString(), "FacilityInspectionByLocation", strWidth, "550", false, true);
    }

    public string GetSLT()
    {
        string strReg = (Region == "Western Region") ? "NCA" : Region;
        DataSet dsReport = Charts.GETSLTBYLocation(Year, strReg);
        DataTable dtReport = dsReport.Tables[0];

        if (dsReport.Tables.Count > 1)
            Average = decimal.Parse(Convert.ToString(dsReport.Tables[1].Rows[0][0]));

        if (Region == "Western Region")
        {
            DataSet dsSCA = Charts.GETSLTBYLocation(Year, "SCA");
            dtReport.Merge(dsSCA.Tables[0]);
            dtReport.DefaultView.Sort = " Score DESC, dba ASC";
            dtReport = dtReport.DefaultView.ToTable();
            decimal decAvg = 0;
            if (dsSCA.Tables[1].Rows.Count > 0 && !string.IsNullOrEmpty(dsSCA.Tables[1].Rows[0][0].ToString()))
                decAvg = decimal.Parse(Convert.ToString(dsSCA.Tables[1].Rows[0][0]));
            Average = (Average + decAvg) / 2.0M;
        }

        string strWidth = dsReport.Tables[0].Rows.Count > 25 ? "950" : "800";
        strChartXML.Append("<chart caption='Safety Leadership Team For Region " + Region + "' plotGradientColor='' xAxisName='Location' yAxisName='Level' useRoundEdges='0' showValues='0' formatNumberScale='0' showBorder='0' rotateYAxisName='0' showYAxisValues='0' yAxisMinValue='0' yAxisMaxValue='70' labelDisplay='ROTATE' maxColWidth='40' slantLabels='0' use3DLighting='1' divLineAlpha='0' baseFont='Verdana' baseFontColor='6f6c6c' baseFontSize='10'>");

        for (int i = 0; i < dtReport.Rows.Count; i++)
        {
            //strlink = Server.UrlEncode("JavaScript:OpenPopup(\"" + dtReport.Rows[i]["DBA"].ToString() + "\",\"" + dtReport.Rows[i]["Sonic_Location_Code"].ToString() + "\",\"" + Year.ToString() + "\",\"2\");").Replace("'", "%26apos;");
            //strChartXML.AppendFormat("<set label='{0}' value='{1}' link='{2}'/>", Server.UrlEncode(dtReport.Rows[i][0].ToString()).Replace("'", "%26apos;"), dtReport.Rows[i][1].ToString(), strlink);

            // for new version
            strlink = Server.UrlEncode("JavaScript:OpenPopup(\"" + dtReport.Rows[i]["DBA"].ToString() + "\",\"" + dtReport.Rows[i]["Sonic_Location_Code"].ToString() + "\",\"" + Year.ToString() + "\",\"7\");").Replace("'", "%26apos;");
            strChartXML.AppendFormat("<set label='{0}' value='{1}' link='{2}' color='{3}'/>", dtReport.Rows[i][0].ToString().Replace("'", "&apos;"), dtReport.Rows[i][1].ToString(), strlink, Charts.GetColorCodeFromScore_SLT(Convert.ToDecimal(dtReport.Rows[i]["Score"])));
        }

        // Get Style 
        GetTreadLineStyle_SLT(strChartXML, Average);

        strChartXML.Append("</chart>");

        return InfoSoftGlobal.FusionCharts.RenderChart(AppConfig.SiteURL + "FusionCharts/Bar2D.swf?ChartNoDataText=No data to display for: Aggregate Performance By Location", "", strChartXML.ToString(), "SafetyLeadershipTeamByLocation", strWidth, "550", false, true);
    }

    public string GetIncidentInvestigation()
    {
        string strReg = (Region == "Western Region") ? "NCA" : Region;
        DataSet dsReport = Charts.GetIncidentInvestigationByLocation(Year, strReg);
        DataTable dtReport = dsReport.Tables[0];

        // calculate Average
        if (dsReport.Tables.Count > 1)
            Average = decimal.Parse(Convert.ToString(dsReport.Tables[1].Rows[0][0]));

        if (Region == "Western Region")
        {
            DataSet dsSCA = Charts.GetIncidentInvestigationByLocation(Year, "SCA");
            dtReport.Merge(dsSCA.Tables[0]);
            dtReport.DefaultView.Sort = "Score DESC, dba ASC";
            dtReport = dtReport.DefaultView.ToTable();
            decimal decAvg = 0;
            if (dsSCA.Tables[1].Rows.Count > 0 && !string.IsNullOrEmpty(dsSCA.Tables[1].Rows[0][0].ToString()))
                decAvg = decimal.Parse(Convert.ToString(dsSCA.Tables[1].Rows[0][0]));
            Average = (Average + decAvg) / 2.0M;
        }

        //strChartXML.Append("<chart caption='Incident Investigation for Region " + Region + "' xAxisName='Location' yAxisName='Level' useRoundEdges='1' showValues='0' formatNumberScale='0' showBorder='0' rotateYAxisName='0' showYAxisValues='0' yAxisMinValue='0' yAxisMaxValue='6' labelDisplay='ROTATE' maxColWidth='40' slantLabels='0' use3DLighting='1' divLineAlpha='0'>");
        // for new version
        string strWidth = dsReport.Tables[0].Rows.Count > 25 ? "950" : "800";
        strChartXML.Append("<chart caption='Incident Investigation for Region " + Region + "' plotGradientColor='' xAxisName='Location' yAxisName='Level' useRoundEdges='0' showValues='0' formatNumberScale='0' showBorder='0' rotateYAxisName='0' showYAxisValues='0' yAxisMinValue='0' yAxisMaxValue='34' labelDisplay='ROTATE' maxColWidth='40' slantLabels='0' use3DLighting='1' divLineAlpha='0' baseFont='Verdana' baseFontColor='6f6c6c' baseFontSize='10'>");

        for (int i = 0; i < dtReport.Rows.Count; i++)
        {
            strlink = Server.UrlEncode("JavaScript:OpenPopup(\"" + dtReport.Rows[i]["DBA"].ToString() + "\",\"" + dtReport.Rows[i]["Sonic_Location_Code"].ToString() + "\",\"" + Year.ToString() + "\",\"4\");").Replace("'", "%26apos;");
            strChartXML.AppendFormat("<set label='{0}' value='{1}' link='{2}' color='{3}'/>", dtReport.Rows[i]["DBA"].ToString().Replace("'", "&apos;"), dtReport.Rows[i]["Score"].ToString(), strlink, Charts.GetColorCodeFromScore(Convert.ToDecimal(dtReport.Rows[i]["Score"])));
        }

        GetTreadLineStyle(strChartXML, Average);

        strChartXML.Append("</chart>");

        return InfoSoftGlobal.FusionCharts.RenderChart(AppConfig.SiteURL + "FusionCharts/Bar2D.swf?ChartNoDataText=No data to display for: Incident Investigation for Region " + Region, "", strChartXML.ToString(), "IncidentInvestigationByLocation", strWidth, "550", false, true);
    }

    public string GetSabaTrainingByLocation()
    {
        string strReg = (Region == "Western Region") ? "NCA" : Region;
        DataSet dsReport = Charts.GetSabaTrainingByLocation(Year, strReg);
        DataTable dtReport = dsReport.Tables[0];

        if (dsReport.Tables.Count > 1)
            Average = decimal.Parse(Convert.ToString(dsReport.Tables[1].Rows[0][0]));

        if (Region == "Western Region")
        {
            DataSet dsSCA = Charts.GetSabaTrainingByLocation(Year, "SCA");
            dtReport.Merge(dsSCA.Tables[0]);
            dtReport.DefaultView.Sort = "Score DESC, DBA ASC";
            dtReport = dtReport.DefaultView.ToTable();
            decimal decAvg = 0;
            if (dsSCA.Tables[1].Rows.Count > 0 && !string.IsNullOrEmpty(dsSCA.Tables[1].Rows[0][0].ToString()))
                decAvg = decimal.Parse(Convert.ToString(dsSCA.Tables[1].Rows[0][0]));
            Average = (Average + decAvg) / 2.0M;
        }

        //strChartXML.Append("<chart caption='Sonic University Training Scorecard for Region " + Region + "' xAxisName='Location' yAxisName='Level' useRoundEdges='1' showValues='0' formatNumberScale='0' showBorder='0' rotateYAxisName='0' showYAxisValues='0' yAxisMinValue='0' yAxisMaxValue='6' labelDisplay='ROTATE' maxColWidth='40' slantLabels='0' use3DLighting='1' divLineAlpha='0'>");
        // for new version
        string strWidth = dsReport.Tables[0].Rows.Count > 25 ? "950" : "800";
        strChartXML.Append("<chart caption='Sonic University Training Scorecard for Region " + Region + "' plotGradientColor='' xAxisName='Location' yAxisName='Level' useRoundEdges='0' showValues='0' formatNumberScale='0' showBorder='0' rotateYAxisName='0' showYAxisValues='0' yAxisMinValue='0' yAxisMaxValue='34' labelDisplay='ROTATE' maxColWidth='40' slantLabels='0' use3DLighting='1' divLineAlpha='0' baseFont='Verdana' baseFontColor='6f6c6c' baseFontSize='10'>");

        for (int i = 0; i < dtReport.Rows.Count; i++)
        {
            strlink = Server.UrlEncode("JavaScript:OpenPopup(\"" + dtReport.Rows[i]["DBA"].ToString() + "\",\"" + dtReport.Rows[i]["Sonic_Location_Code"].ToString() + "\",\"" + Year.ToString() + "\",\"3\");").Replace("'", "%26apos;");
            strChartXML.AppendFormat("<set label='{0}' value='{1}'  link='{2}' color='{3}'/>", dtReport.Rows[i][0].ToString().Replace("'", "&apos;"), dtReport.Rows[i][1].ToString(), strlink, Charts.GetColorCodeFromScore(Convert.ToDecimal(dtReport.Rows[i]["Score"])));
        }

        GetTreadLineStyle(strChartXML, Average);

        strChartXML.Append("</chart>");
        return InfoSoftGlobal.FusionCharts.RenderChart(AppConfig.SiteURL + "FusionCharts/Bar2D.swf?ChartNoDataText=No data to display for: Saba Training By Location", "", strChartXML.ToString(), "SabaTrainingByLocation", strWidth, "550", false, true);
    }

    public string GetIncidentReduction()
    {
        string strReg = (Region == "Western Region") ? "NCA" : Region;
        DataSet dsReport = Charts.GetIncidentReductionByLocation(Year, strReg);
        DataTable dtReport = dsReport.Tables[0];

        if (dsReport.Tables.Count > 1)
            Average = decimal.Parse(Convert.ToString(dsReport.Tables[1].Rows[0][0]));

        if (Region == "Western Region")
        {
            DataSet dsSCA = Charts.GetIncidentReductionByLocation(Year, "SCA");
            dtReport.Merge(dsSCA.Tables[0]);
            //dtReport.DefaultView.Sort = "DBA";
            dtReport.DefaultView.Sort = "Score DESC, Region ASC";
            dtReport = dtReport.DefaultView.ToTable();
            decimal decAvg = 0;
            if (dsSCA.Tables[1].Rows.Count > 0 && !string.IsNullOrEmpty(dsSCA.Tables[1].Rows[0][0].ToString()))
                decAvg = decimal.Parse(Convert.ToString(dsSCA.Tables[1].Rows[0][0]));
            Average = (Average + decAvg) / 2.0M;
        }

        //strChartXML.Append("<chart caption='Incident Reduction by Region " + Region + "' xAxisName='Location' yAxisName='Level' useRoundEdges='1' showValues='0' formatNumberScale='0' showBorder='0' rotateYAxisName='0' showYAxisValues='0' yAxisMinValue='0' yAxisMaxValue='0' labelDisplay='ROTATE' maxColWidth='40' slantLabels='0' use3DLighting='1' divLineAlpha='0'>");
        // for new version
        string strWidth = dsReport.Tables[0].Rows.Count > 25 ? "950" : "800";
        strChartXML.Append("<chart caption='Incident Reduction by Region " + Region + "' xAxisName='Location' plotGradientColor='' yAxisName='Level' useRoundEdges='0' showValues='0' formatNumberScale='0' showBorder='0' rotateYAxisName='0' showYAxisValues='0' yAxisMinValue='0' yAxisMaxValue='34' labelDisplay='ROTATE' maxColWidth='40' slantLabels='0' use3DLighting='1' divLineAlpha='0' baseFont='Verdana' baseFontColor='6f6c6c' baseFontSize='10'>");

        for (int i = 0; i < dtReport.Rows.Count; i++)
        {
            strlink = Server.UrlEncode("JavaScript:OpenPopup(\"" + dtReport.Rows[i]["DBA"].ToString() + "\",\"" + dtReport.Rows[i]["Sonic_Location_Code"].ToString() + "\",\"" + Year.ToString() + "\",\"6\");").Replace("'", "%26apos;");
            strChartXML.AppendFormat("<set label='{0}' value='{1}' link='{2}' color='{3}'/>", dtReport.Rows[i]["DBA"].ToString().Replace("'", "&apos;"), dtReport.Rows[i]["Score"].ToString(), strlink, Charts.GetColorCodeFromScore(Convert.ToDecimal(dtReport.Rows[i]["Score"])));
        }

        GetTreadLineStyle(strChartXML, Average);

        strChartXML.Append("</chart>");
        return InfoSoftGlobal.FusionCharts.RenderChart(AppConfig.SiteURL + "FusionCharts/Bar2D.swf?ChartNoDataText=No data to display for: Incident Reduction for Region " + Region, "", strChartXML.ToString(), "IncidentReductionByLocation", strWidth, "550", false, true);
    }

    public string GetWCClaimMgmtByLocation()
    {
        string strReg = (Region == "Western Region") ? "NCA" : Region;
        DataSet dsReport = Charts.GetWCClaimMgmtByLocation(Year, strReg);
        DataTable dtReport = dsReport.Tables[0];

        if (dsReport.Tables.Count > 1)
            Average = decimal.Parse(Convert.ToString(dsReport.Tables[1].Rows[0][0]));

        if (Region == "Western Region")
        {
            DataSet dsSCA = Charts.GetWCClaimMgmtByLocation(Year, "SCA");
            dtReport.Merge(dsSCA.Tables[0]);
            dtReport.DefaultView.Sort = "Score DESC, dba ASC";
            dtReport = dtReport.DefaultView.ToTable();
            decimal decAvg = 0;
            if (dsSCA.Tables[1].Rows.Count > 0 && !string.IsNullOrEmpty(dsSCA.Tables[1].Rows[0][0].ToString()))
                decAvg = decimal.Parse(Convert.ToString(dsSCA.Tables[1].Rows[0][0]));
            Average = (Average + decAvg) / 2.0M;
        }

        //strChartXML.Append("<chart caption='Workers’ Compensation Claims Management For Region " + Region + "' xAxisName='Location' yAxisName='Level' useRoundEdges='1' showValues='0' formatNumberScale='0' showBorder='0' rotateYAxisName='0' showYAxisValues='0' yAxisMinValue='0' yAxisMaxValue='0' labelDisplay='ROTATE' maxColWidth='40' slantLabels='0' use3DLighting='1' divLineAlpha='0'>");
        // for new version
        string strWidth = dsReport.Tables[0].Rows.Count > 25 ? "950" : "800";
        strChartXML.Append("<chart caption='Workers’ Compensation Claims Management For Region " + Region + "' xAxisName='Location' plotGradientColor='' yAxisName='Level' useRoundEdges='0' showValues='0' formatNumberScale='0' showBorder='0' rotateYAxisName='0' showYAxisValues='0' yAxisMinValue='0' yAxisMaxValue='34' labelDisplay='ROTATE' maxColWidth='40' slantLabels='0' use3DLighting='1' divLineAlpha='0' baseFont='Verdana' baseFontColor='6f6c6c' baseFontSize='10'>");

        for (int i = 0; i < dtReport.Rows.Count; i++)
        {
            strlink = Server.UrlEncode("JavaScript:OpenPopupForWCClaim(\"" + dtReport.Rows[i]["DBA"].ToString() + "\",\"" + dtReport.Rows[i]["Average"].ToString() + "\",\"" + dtReport.Rows[i]["Score"].ToString() + "\",\"5\");").Replace("'", "%26apos;");
            strChartXML.AppendFormat("<set label='{0}' value='{1}' link='{2}' color='{3}' />", dtReport.Rows[i]["DBA"].ToString().Replace("'", "&apos;"), dtReport.Rows[i]["Score"].ToString(), strlink, Charts.GetColorCodeFromScore(Convert.ToDecimal(dtReport.Rows[i]["Score"])));
        }

        GetTreadLineStyle(strChartXML, Average);

        strChartXML.Append("</chart>");
        return InfoSoftGlobal.FusionCharts.RenderChart(AppConfig.SiteURL + "FusionCharts/Bar2D.swf?ChartNoDataText=No data to display for: Workers’ Compensation Claims Management For Region " + Region, "", strChartXML.ToString(), "WCClaimMgmtByLocation", strWidth, "550", false, true);
    }

    #endregion

    #region "Other Methods"

    public void GetTreadLineStyle(StringBuilder strChartXML, decimal Average)
    {
        decimal decCompAverage = 0;

        if (!string.IsNullOrEmpty(Request.QueryString["CompAvg"]))
        {
            decimal decAvg;
            if (decimal.TryParse(Request.QueryString["CompAvg"], out decAvg))
                decCompAverage = decAvg;
        }

        // set Tread Lines
        strChartXML.Append("<trendLines>");
        strChartXML.Append("<line startValue='4' color='666666' displayvalue='" + Charts.Tin_Label + "' /> ");
        strChartXML.Append("<line startValue='10' color='666666' displayvalue='" + Charts.Bronze_Label + "' /> ");
        strChartXML.Append("<line startValue='16' color='666666' displayvalue='" + Charts.Silver_Label + "' /> ");
        strChartXML.Append("<line startValue='22' color='666666' displayvalue='" + Charts.Gold_Label + "' /> ");
        strChartXML.Append("<line startValue='28' color='666666' displayvalue='"+ Charts.Platinum_Label +"' /> ");

        strChartXML.Append("<line startValue='26.6' color='619a61' displayvalue='Cross The Line' valueOnRight='1' thickness='2' /> ");

        //if (Average != 0 && decCompAverage > 0 && (Math.Abs(Average - decCompAverage) <= 0.20M))
        //{
        //    strChartXML.Append("<line startValue='" + string.Format("{0:N2}", Average) + "' color='619a61' displayvalue='Region and Company Average' valueOnRight='1' thickness='2' /> ");
        //}
        //else
        //{
        //    if (Average != 0)
        //        strChartXML.Append("<line startValue='" + string.Format("{0:N2}", Average) + "' color='619a61' displayvalue='Region Average' valueOnRight='1' thickness='2' /> ");
        //    if (decCompAverage > 0 && Average != decCompAverage)
        //        strChartXML.Append("<line startValue='" + string.Format("{0:N2}", decCompAverage) + "' color='FF0000' displayvalue='Company Average' valueOnRight='1' thickness='2' /> ");
        //}

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

    public void GetTreadLineStyle_Aggregate(StringBuilder strChartXML, decimal Average)
    {
        decimal decCompAverage = 0;

        if (!string.IsNullOrEmpty(Request.QueryString["CompAvg"]))
        {
            decimal decAvg;
            if (decimal.TryParse(Request.QueryString["CompAvg"], out decAvg))
                decCompAverage = decAvg;
        }

        // set Tread Lines
        strChartXML.Append("<trendLines>");
        strChartXML.Append("<line startValue='69.5' color='666666' displayvalue='" + Charts.Tin_Label + "' /> ");
        strChartXML.Append("<line startValue='79.5' color='666666' displayvalue='" + Charts.Bronze_Label + "' /> ");
        strChartXML.Append("<line startValue='89.5' color='666666' displayvalue='" + Charts.Silver_Label + "' /> ");
        strChartXML.Append("<line startValue='94.5' color='666666' displayvalue='" + Charts.Gold_Label + "' /> ");
        strChartXML.Append("<line startValue='100' color='666666' displayvalue='" + Charts.Platinum_Label + "' /> ");
        strChartXML.Append("<line startValue='95' color='619a61' displayvalue='Cross The Line' valueOnRight='1' thickness='2' /> ");

        //if (Average != 0 && decCompAverage > 0 && (Math.Abs(Average - decCompAverage) <= 0.75M))
        //{
        //    strChartXML.Append("<line startValue='" + string.Format("{0:N2}", Average) + "' color='619a61' displayvalue='Region and Company Average' valueOnRight='1' thickness='2' /> ");
        //}
        //else
        //{
        //    if (Average != 0)
        //        strChartXML.Append("<line startValue='" + string.Format("{0:N2}", Average) + "' color='619a61' displayvalue='Region Average' valueOnRight='1' thickness='2' /> ");
        //    if (decCompAverage > 0 && Average != decCompAverage)
        //        strChartXML.Append("<line startValue='" + string.Format("{0:N2}", decCompAverage) + "' color='FF0000' displayvalue='Company Average' valueOnRight='1' thickness='2' /> ");
        //}

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

    public void GetTreadLineStyle_SLT(StringBuilder strChartXML, decimal Average)
    {
        decimal decCompAverage = 0;

        if (!string.IsNullOrEmpty(Request.QueryString["CompAvg"]))
        {
            decimal decAvg;
            if (decimal.TryParse(Request.QueryString["CompAvg"], out decAvg))
                decCompAverage = decAvg;
        }

        // set Tread Lines
        strChartXML.Append("<trendLines>");
        strChartXML.Append("<line startValue='23' color='666666' displayvalue='" + Charts.Tin_Label + "' /> ");
        strChartXML.Append("<line startValue='35' color='666666' displayvalue='" + Charts.Bronze_Label + "' /> ");
        strChartXML.Append("<line startValue='47' color='666666' displayvalue='" + Charts.Silver_Label + "' /> ");
        strChartXML.Append("<line startValue='59' color='666666' displayvalue='" + Charts.Gold_Label + "' /> ");
        strChartXML.Append("<line startValue='60' color='666666' displayvalue='" + Charts.Platinum_Label + "' /> ");

        strChartXML.Append("<line startValue='57' color='619a61' displayvalue='Cross The Line' valueOnRight='1' thickness='2' /> ");

        //if (Average != 0 && decCompAverage > 0 && (Math.Abs(Average - decCompAverage) <= 0.20M))
        //{
        //    strChartXML.Append("<line startValue='" + string.Format("{0:N2}", Average) + "' color='619a61' displayvalue='Region and Company Average' valueOnRight='1' thickness='2' /> ");
        //}
        //else
        //{
        //    if (Average != 0)
        //        strChartXML.Append("<line startValue='" + string.Format("{0:N2}", Average) + "' color='619a61' displayvalue='Region Average' valueOnRight='1' thickness='2' /> ");
        //    if (decCompAverage > 0 && Average != decCompAverage)
        //        strChartXML.Append("<line startValue='" + string.Format("{0:N2}", decCompAverage) + "' color='FF0000' displayvalue='Company Average' valueOnRight='1' thickness='2' /> ");
        //}

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

    public void MergeColumn(ref DataTable dtBase, DataTable dtDestination)
    {
        foreach (DataRow dr in dtDestination.Rows)
        {
            DataRow drNew = dtBase.NewRow();
            drNew["Sonic_Location_code"] = dr["Sonic_Location_code"];
            drNew["DBA"] = dr["DBA"];
            drNew["Score"] = dr["Score"];
            dtBase.Rows.Add(drNew);
            dtBase.AcceptChanges();
        }
    }

    #endregion
}