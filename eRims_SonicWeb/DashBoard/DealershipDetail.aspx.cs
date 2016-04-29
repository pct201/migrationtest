using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class DealershipDetail : System.Web.UI.Page
{
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
    /// Get Sonic Location Code Parameter
    /// </summary>
    public string Sonic_Location_Code
    {
        get
        {
            return (string.IsNullOrEmpty(Request.QueryString["Code"]) ? string.Empty : Convert.ToString(Request.QueryString["Code"]));
        }
    }

    /// <summary>
    /// Get DBA Parameter
    /// </summary>
    public string DBA
    {
        get
        {
            return (string.IsNullOrEmpty(Request.QueryString["dba"]) ? string.Empty : Server.UrlDecode(Request.QueryString["dba"]).Replace("&apos;","'"));
        }
    }

    /// <summary>
    /// Get Current Map ID
    /// </summary>
    public int MapID
    {
        get
        {
            return clsGeneral.GetInt(Request.QueryString["mapid"]);
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            switch (MapID)
            {
                case 1:
                    BindAggregatePerformance();
                    break;
                case 2:
                    BindFacilityInspectionDetail();
                    break;
                case 3:
                    BindSabaTrainingDetail();
                    break;
                case 4:
                    BindIncidentInvestigation();
                    break;
                case 5:
                    BindWCClaimMgmtDetails();
                    break;
                case 6:
                    BindInvestigationReductionDetail();
                    break;
                case 7:
                    BindSLTDetail();
                    break;
            }
        }
    }

    #region " Methods "
    private void BindAggregatePerformance()
    {
        pnlAggregatePerformance.Visible = true;
        lblAggregateDelearship.Text = Convert.ToString(DBA);

        DataTable dtAggreage = new DataTable();
        dtAggreage.Columns.Add("Graph", typeof(string));
        dtAggreage.Columns.Add("Score", typeof(int));
        dtAggreage.Columns.Add("Performance", typeof(string));
        dtAggreage.Rows.Add(dtAggreage.NewRow()[0] = "Facility Inspection");
        dtAggreage.Rows.Add(dtAggreage.NewRow()[0] = "Sonic University Training");
        dtAggreage.Rows.Add(dtAggreage.NewRow()[0] = "Incident Investigation");
        dtAggreage.Rows.Add(dtAggreage.NewRow()[0] = "WC claim Management");
        dtAggreage.Rows.Add(dtAggreage.NewRow()[0] = "Incident Reduction");
        dtAggreage.Rows.Add(dtAggreage.NewRow()[0] = "Safety Leadership Team");

        string Region = Convert.ToString(Request.QueryString["Region"]);

        DataTable dtAverage = new DataTable();
        dtAverage.Columns.Add(new DataColumn("Score", typeof(decimal)));

        DataSet dsResult = Charts.GetFacilityInspectionByLocation(Year, Region);
        MergeColumn(ref dtAggreage, dsResult.Tables[0], 1);
        dtAverage.Rows.Add(dtAverage.NewRow()[0] = (dsResult.Tables[1].Rows[0][0] != DBNull.Value ? dsResult.Tables[1].Rows[0][0] : 0));

        dsResult = Charts.GetSabaTrainingByLocation(Year, Region);
        MergeColumn(ref dtAggreage, dsResult.Tables[0], 2);
        dtAverage.Rows.Add(dtAverage.NewRow()[0] = (dsResult.Tables[1].Rows[0][0] != DBNull.Value ? dsResult.Tables[1].Rows[0][0] : 0));

        dsResult = Charts.GetIncidentInvestigationByLocation(Year, Region);
        MergeColumn(ref dtAggreage, dsResult.Tables[0], 3);
        dtAverage.Rows.Add(dtAverage.NewRow()[0] = (dsResult.Tables[1].Rows[0][0] != DBNull.Value ? dsResult.Tables[1].Rows[0][0] : 0));

        dsResult = Charts.GetWCClaimMgmtByLocation(Year, Region);
        MergeColumn(ref dtAggreage, dsResult.Tables[0], 4);
        dtAverage.Rows.Add(dtAverage.NewRow()[0] = (dsResult.Tables[1].Rows[0][0] != DBNull.Value ? dsResult.Tables[1].Rows[0][0] : 0));

        dsResult = Charts.GetIncidentReductionByLocation(Year, Region);
        MergeColumn(ref dtAggreage, dsResult.Tables[0], 5);
        dtAverage.Rows.Add(dtAverage.NewRow()[0] = (dsResult.Tables[1].Rows[0][0] != DBNull.Value ? dsResult.Tables[1].Rows[0][0] : 0));

        dsResult = Charts.GETSLTBYLocation(Year, Region);
        MergeColumn(ref dtAggreage, dsResult.Tables[0], 6);
        dtAverage.Rows.Add(dtAverage.NewRow()[0] = (dsResult.Tables[1].Rows[0][0] != DBNull.Value ? dsResult.Tables[1].Rows[0][0] : 0));

        lblScoreFacility.Text = Convert.ToString(dtAggreage.Rows[0][1]) + " (" + Convert.ToString(dtAggreage.Rows[0][2]) + ")";
        if (dtAggreage.Rows[1][2] != DBNull.Value)
            lblScoreTraining.Text = Convert.ToString(dtAggreage.Rows[1][1]) + " (" + Convert.ToString(dtAggreage.Rows[1][2]) + ")";
        lblScoreIncidentInvestigation.Text = Convert.ToString(dtAggreage.Rows[2][1]) + " (" + Convert.ToString(dtAggreage.Rows[2][2]) + ")";
        lblScoreWCClaim.Text = Convert.ToString(dtAggreage.Rows[3][1]) + " (" + Convert.ToString(dtAggreage.Rows[3][2]) + ")";
        lblScoreIncidentReduction.Text = Convert.ToString(dtAggreage.Rows[4][1]) + " (" + Convert.ToString(dtAggreage.Rows[4][2]) + ")";
        lblScoreSLT.Text = Convert.ToString(dtAggreage.Rows[5][1]) + " (" + Convert.ToString(dtAggreage.Rows[5][2]) + ")";

        object objSum = dtAggreage.Compute("(SUM(Score)/200)*100", "");
        //object objSum = dtAggreage.Compute("SUM(Score)", "");

        lblScoreTotal.Text = string.Format("{0:N2}", objSum);

        object objAvg = dtAverage.Compute("AVG(Score)", "");
        //string strResult = "";
        //if(objAvg != null)
        //{
        //    strResult = GetPerformanceLevel(Convert.ToInt32(objAvg));
        //}
        //lblResultingScore.Text = string.Format("{0:N0}", objAvg) + " (" + strResult + ")";

        string strResult = "";
        decimal score = 0.0M;
        if (objSum != null)
        {
            decimal _intScore = Convert.ToDecimal(objSum);
            //_intScore = (_intScore / 200) * 100;
            score = _intScore;
            //if (_intScore > 189 && _intScore <= 200)
            //{
            //    strResult = "Platinum";
            //}
            //else if (_intScore > 179 && _intScore <= 189)
            //{
            //    strResult = "Gold";
            //}
            //else if (_intScore > 159 && _intScore <= 179)
            //{
            //    strResult = "Silver";
            //}
            //else if (_intScore > 139 && _intScore <= 159)
            //{
            //    strResult = "Bronze";
            //}
            //else if (_intScore >= 0 && _intScore <= 139)
            //{
            //    strResult = "Tin";
            //}            

            //Change as per bug-tracker 3600 #35143..
            if (_intScore > 84.5m && _intScore <= 100)
            {
                strResult = "Platinum";
            }
            else if (_intScore > 69.5m && _intScore <= 84.5m)
            {
                strResult = "Gold";
            }
            else if (_intScore > 49.5m && _intScore <= 69.5m)
            {
                strResult = "Silver";
            }
            else if (_intScore > 29.5m && _intScore <= 49.5m)
            {
                strResult = "Bronze";
            }
            else if (_intScore >= 0 && _intScore <= 29.5m)
            {
                strResult = "Tin";
            }
        }

        if (score > 0)
            lblResultingScore.Text = string.Format("{0:N2}", score) + " (" + strResult + ")";

    }
    public void MergeColumn(ref DataTable dtBase, DataTable dtDestination, int GraphType)
    {
        dtDestination.DefaultView.RowFilter = "DBA = '" + DBA.Replace("'", "''") + "' and Sonic_Location_Code = " + Sonic_Location_Code;
        dtDestination = dtDestination.DefaultView.ToTable();

        if (dtDestination.Rows.Count > 0)
        {
            int intRow = 0;
            switch (GraphType)
            {
                case 1: intRow = 0; break;
                case 2: intRow = 1; break;
                case 3: intRow = 2; break;
                case 4: intRow = 3; break;
                case 5: intRow = 4; break;
                case 6: intRow = 5; break;
            }
            dtBase.Rows[intRow][1] = dtDestination.Rows[0]["Score"];
            if(GraphType == 6)
                dtBase.Rows[intRow][2] = GetPerformanceLevel_SLT(Convert.ToInt32(dtDestination.Rows[0]["Score"]));
            else
                dtBase.Rows[intRow][2] = GetPerformanceLevel(Convert.ToInt32(dtDestination.Rows[0]["Score"]));
        }
    }

    private string GetPerformanceLevel(int intScore)
    {
        string strLevel = "";
        switch (intScore)
        {
            case 4: strLevel = "Tin"; break;
            case 10: strLevel = "Bronze"; break;
            case 16: strLevel = "Silver"; break;
            case 22: strLevel = "Gold"; break;
            case 28: strLevel = "Platinum"; break;
            default: strLevel = "Platinum"; break;
        }
        return strLevel;
    }

    private string GetPerformanceLevel_SLT(int intScore)//Change as per bug-tracker 3600 #35143..
    {
        string strLevel = "";

        //if(intScore >= 0 && intScore <= 13)
        //    strLevel = "Tin";
        //if (intScore > 13 && intScore <= 25)
        //    strLevel = "Bronze";
        //if (intScore > 25 && intScore <= 37)
        //    strLevel = "Silver";
        //if (intScore > 37 && intScore <= 49)
        //    strLevel = "Gold";
        //if (intScore > 49 && intScore <= 60)
        //    strLevel = "Platinum";
        if (intScore >= 0 && intScore < 13)
            strLevel = "White";
        if (intScore >= 13 && intScore < 25)
            strLevel = "Tin";
        if (intScore >= 25 && intScore < 37)
            strLevel = "Bronze";
        if (intScore >= 37 && intScore < 49)
            strLevel = "Silver";
        if (intScore >= 49 && intScore < 60)
            strLevel = "Gold";
        if (intScore >= 60) 
            strLevel = "Platinum";
        return strLevel;
    }

    private void BindIncidentInvestigation()
    {
        pnlIncidentInvestigation.Visible = true;
        DataTable dtDetail = Charts.GetIncidentInvestigationDetail(Year, DBA, Sonic_Location_Code).Tables[0];

        lblIIDealerShip.Text = Convert.ToString(DBA);
        if (dtDetail.Rows.Count > 0)
        {
            lblIIPerLevel.Text = Convert.ToString(dtDetail.Rows[0]["Performance_Level"]);

            if (dtDetail.Rows[0]["NoOfInvestigations"] == DBNull.Value)
                lblNoofInvestigations.Text = "0";
            else
                lblNoofInvestigations.Text = string.Format("{0:N0}", dtDetail.Rows[0]["NoOfInvestigations"]);

            if (dtDetail.Rows[0]["Score"] == DBNull.Value)
                AvgInvestigation.Text = "0";
            else
                AvgInvestigation.Text = string.Format("{0:N1}", dtDetail.Rows[0]["Score"]);
        }
        else
        {
            lblIIPerLevel.Text = "Platinum";
            lblNoofInvestigations.Text = "0";
            AvgInvestigation.Text = "28.0";
        }
    }

    private void BindFacilityInspectionDetail()
    {
        pnlFacilityInspection.Visible = true;
        DataSet dsDetail = Charts.GetFacilityInspectionDetail(Year, DBA, Sonic_Location_Code);

        if (dsDetail.Tables[0].Rows.Count > 0)
        {
            lblDealership.Text = Convert.ToString(dsDetail.Tables[0].Rows[0]["DBA"]);
            lblPerformance.Text = Convert.ToString(dsDetail.Tables[0].Rows[0]["Score"]);

            if (dsDetail.Tables[0].Rows[0]["Repeat_Deficiencies"] == DBNull.Value)
                lblDeficiencies.Text = "0";
            else
                lblDeficiencies.Text = string.Format("{0:N1}", dsDetail.Tables[0].Rows[0]["Repeat_Deficiencies"]);

            if (dsDetail.Tables[0].Rows[0]["Average_Days_Open"] == DBNull.Value)
                lblDaysOpen.Text = "0";
            else
                lblDaysOpen.Text = string.Format("{0:N1}", dsDetail.Tables[0].Rows[0]["Average_Days_Open"]);
        }
    }
    private void BindSLTDetail()
    {
        pnlSLT.Visible = true;
        DataSet dsDetail = Charts.GetSLTDetail(Year, DBA, Sonic_Location_Code);
        int Score = 0;
        if (dsDetail.Tables[0].Rows.Count > 0)
        {
            lblSlt_location.Text = Convert.ToString(dsDetail.Tables[0].Rows[0]["DBA"]);

            
            if (dsDetail.Tables[0].Rows[0]["Meeting_Points"] == DBNull.Value)
                lblDeficiencies.Text = "0";
            else
                lblMeeting_points.Text = Convert.ToString(dsDetail.Tables[0].Rows[0]["Meeting_Points"]);

            if (dsDetail.Tables[0].Rows[0]["Safety_Walk_Points"] == DBNull.Value)
                lblSafety_Walk_points.Text = "0";
            else
                lblSafety_Walk_points.Text = Convert.ToString(dsDetail.Tables[0].Rows[0]["Safety_Walk_Points"]);

            if (dsDetail.Tables[0].Rows[0]["Incidents_Review_Points"] == DBNull.Value)
                lblIncident_points.Text = "0";
            else
                lblIncident_points.Text = Convert.ToString(dsDetail.Tables[0].Rows[0]["Incidents_Review_Points"]);

            if (dsDetail.Tables[0].Rows[0]["Quality_Review"] == DBNull.Value)
                lblQuality_Review_Points.Text = "0";
            else
                lblQuality_Review_Points.Text = Convert.ToString(dsDetail.Tables[0].Rows[0]["Quality_Review"]);
            lblSlt_Total_Points.Text = Convert.ToString(dsDetail.Tables[0].Rows[0]["Total_Points"]);

            if (dsDetail.Tables[0].Rows[0]["Score"] != DBNull.Value)
            {
                Score = Convert.ToInt32(dsDetail.Tables[0].Rows[0]["Score"]);
                lblSLT_Performance.Text =  dsDetail.Tables[0].Rows[0]["Score"].ToString() + " (" + GetPerformanceLevel_SLT(Score) + ")";
            }
        }
    }
    private void BindSabaTrainingDetail()
    {
        pnlSabaTraining.Visible = true;
        DataSet dsDetail = Charts.GetSabaTrainingDetail(Year, DBA, Sonic_Location_Code);
        lblSabaDealerShipName.Text = DBA;

        if (dsDetail.Tables[0].Rows.Count > 0)
        {
            lblSabaPerformance.Text = Convert.ToString(dsDetail.Tables[0].Rows[0]["Score"]);

            if (dsDetail.Tables[0].Rows[0]["Year"] == DBNull.Value)
                lblSabaTrainingYear.Text = "Data Not Available";
            else
                lblSabaTrainingYear.Text = Convert.ToString(dsDetail.Tables[0].Rows[0]["Year"]);

            if (Year < 2011)
            {
                if (dsDetail.Tables[0].Rows[0]["SabaDate"] == DBNull.Value)
                    lblSabaTrainingDate.Text = "Data Not Available";
                else
                    lblSabaTrainingDate.Text = clsGeneral.FormatDBNullDateToDisplay(dsDetail.Tables[0].Rows[0]["SabaDate"]);
            }

            if (dsDetail.Tables[0].Rows[0]["Number_Trained"] == DBNull.Value)
                lblSabaEmployeesTrained.Text = "0";
            else
                lblSabaEmployeesTrained.Text = string.Format("{0:N0}", dsDetail.Tables[0].Rows[0]["Number_Trained"]);

            if (dsDetail.Tables[0].Rows[0]["Number_of_Employees"] == DBNull.Value)
                lblSabaNumberEmployees.Text = "0";
            else
                lblSabaNumberEmployees.Text = string.Format("{0:N0}", dsDetail.Tables[0].Rows[0]["Number_of_Employees"]);

            if (dsDetail.Tables[0].Rows[0]["per"] == DBNull.Value)
                lblSabaPercentTrained.Text = "0";
            else
                lblSabaPercentTrained.Text = string.Format("{0:N1}", dsDetail.Tables[0].Rows[0]["per"]);
        }
    }

    private void BindInvestigationReductionDetail()
    {
        pnlInvestigationReduction.Visible = true;
        DataSet dsDetail = Charts.GetIncidentReductionDetail(Year, DBA, Sonic_Location_Code);
        lblRedDealerShip.Text = DBA;
        if (dsDetail.Tables.Count > 1)
        {
            if (dsDetail.Tables[0].Rows.Count > 0)
            {
                if (dsDetail.Tables[0].Rows[0]["Cause_CountS1"] == DBNull.Value)
                    lblRedS1.Text = "0";
                else
                    lblRedS1.Text = string.Format("{0:N0}", dsDetail.Tables[0].Rows[0]["Cause_CountS1"]);

                if (dsDetail.Tables[0].Rows[0]["Cause_CountS2"] == DBNull.Value)
                    lblRedS2.Text = "0";
                else
                    lblRedS2.Text = string.Format("{0:N0}", dsDetail.Tables[0].Rows[0]["Cause_CountS2"]);

                if (dsDetail.Tables[0].Rows[0]["Cause_CountS01"] == DBNull.Value)
                    lblRedS01.Text = "0";
                else
                    lblRedS01.Text = string.Format("{0:N0}", dsDetail.Tables[0].Rows[0]["Cause_CountS01"]);

                if (dsDetail.Tables[0].Rows[0]["Cause_CountS02"] == DBNull.Value)
                    lblRedS02.Text = "0";
                else
                    lblRedS02.Text = string.Format("{0:N0}", dsDetail.Tables[0].Rows[0]["Cause_CountS02"]);

                if (dsDetail.Tables[1].Rows[0]["Score"] == DBNull.Value)
                    lblRedPerformance.Text = "Platinum";
                else
                    lblRedPerformance.Text = string.Format("{0}", dsDetail.Tables[1].Rows[0]["Score"]);
            }
        }

    }

    private void BindWCClaimMgmtDetails()
    {
        pnlWCClaimMgmt.Visible = true;
        lblDealershipWCClaim.Text = DBA;
        if (!string.IsNullOrEmpty(Request.QueryString["Avg"]))
        {
            if (Request.QueryString["Avg"] == "0")
                lblAverageClaimClosure.Text = "0";
            else
                lblAverageClaimClosure.Text = Request.QueryString["Avg"];
        }

        if (!string.IsNullOrEmpty(Request.QueryString["Level"]))
        {
            switch (Convert.ToInt32(Request.QueryString["Level"]))
            {
                case 4: lblPerformanceLevelWC.Text = "Tin"; break;
                case 10: lblPerformanceLevelWC.Text = "Bronze"; break;
                case 16: lblPerformanceLevelWC.Text = "Silver"; break;
                case 22: lblPerformanceLevelWC.Text = "Gold"; break;
                case 28: lblPerformanceLevelWC.Text = "Platinum"; break;
            }
        }


    }

    #endregion
}
