﻿
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

    private int _Quarter;

    public int Quarter
    {
        get { return _Quarter; }
        set { _Quarter = value; }
    }

    private string _AssociateStatus;

    public string AssociateStatus
    {
        get { return _AssociateStatus; }
        set { _AssociateStatus = value; }
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

        dsResult = Charts.GetSabaTrainingDetail1(Year, DBA, Sonic_Location_Code, Quarter, AssociateStatus);
        if (dsResult.Tables[1] != null && dsResult.Tables[1].Rows.Count > 1)
            dtAggreage.Rows[1][1] = dsResult.Tables[1].Rows[1][0] != DBNull.Value ? dsResult.Tables[1].Rows[1][0] : 28;
        else
            dtAggreage.Rows[1][1] = 28;

        if (dsResult.Tables[1] != null && dsResult.Tables[1].Rows.Count > 1)
            dtAggreage.Rows[1][2] = dsResult.Tables[1].Rows[1][1] != DBNull.Value ? dsResult.Tables[1].Rows[1][1] : "All Pro";            
        else
            dtAggreage.Rows[1][2] = "All Pro";
        //MergeColumn(ref dtAggreage, dsResult.Tables[0], 2);
        if (dsResult.Tables[1] != null && dsResult.Tables[1].Rows.Count > 1)
        dtAverage.Rows.Add(dtAverage.NewRow()[0] = (dsResult.Tables[1].Rows[1][0] != DBNull.Value ? dsResult.Tables[1].Rows[1][0] : 0));
        else
        dtAverage.Rows.Add(dtAverage.NewRow()[0] = 0);

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

        object objSum = dtAggreage.Compute("SUM(Score)", "");

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
            score = _intScore;
            if (_intScore > 189 && _intScore <= 200)
            {
                strResult = "All Pro";
            }
            else if (_intScore > 179 && _intScore <= 189)
            {
                strResult = "Starter";
            }
            else if (_intScore > 159 && _intScore <= 179)
            {
                strResult = "Second String";
            }
            else if (_intScore > 139 && _intScore <= 159)
            {
                strResult = "Water boy";
            }
            else if (_intScore >= 0 && _intScore <= 139)
            {
                strResult = "Spectator";
            }            
        }

        if (score > 0)
            lblResultingScore.Text = string.Format("{0:N0}", score) + " (" + strResult + ")";

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
            case 4: strLevel = "Spectator"; break;
            case 10: strLevel = "Water boy"; break;
            case 16: strLevel = "Second String"; break;
            case 22: strLevel = "Starter"; break;
            case 28: strLevel = "All Pro"; break;
            default: strLevel = "All Pro"; break;
        }
        return strLevel;
    }

    private string GetPerformanceLevel_SLT(int intScore)
    {
        string strLevel = "";

        if(intScore >= 0 && intScore <= 23)
            strLevel = "Spectator";
        if (intScore > 23 && intScore <= 35)
            strLevel = "Water boy";
        if (intScore > 35 && intScore <= 47)
            strLevel = "Second String";
        if (intScore > 47 && intScore <= 59)
            strLevel = "Starter";
        if (intScore > 59 && intScore <= 60)
            strLevel = "All Pro";
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
            lblIIPerLevel.Text = "All Pro";
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
        DataSet dsDetail = Charts.GetSabaTrainingDetail1(Year, DBA, Sonic_Location_Code, Quarter, AssociateStatus);
        lblSabaDealerShipName.Text = DBA;

        if (dsDetail.Tables[0].Rows.Count > 0)
        {
            //lblSabaPerformance.Text = Convert.ToString(dsDetail.Tables[0].Rows[0]["Score"]);

            if (Year != null) lblSabaTrainingYear.Text = Convert.ToString(Year);
            else if (dsDetail.Tables[0].Rows[0]["Year"] == DBNull.Value)
                lblSabaTrainingYear.Text = "Data Not Available";
            else
                lblSabaTrainingYear.Text = Convert.ToString(dsDetail.Tables[0].Rows[0]["Year"]);


            DataRow[] result1 = dsDetail.Tables[0].Select("AssociateQuarter = '1' AND AssociateStatus = 'AssociateToTrain'");

            if (result1.Length > 0)
            {
                if (string.IsNullOrEmpty(result1[0]["AssociateStatus"].ToString()))
                    lblSabaNumberEmployees1.Text = "0";
                else
                    lblSabaNumberEmployees1.Text = string.Format("{0:N0}", result1[0]["Total"]);
            }
            else
            {
                lblSabaNumberEmployees1.Text = "0";
            }

            DataRow[] result2 = dsDetail.Tables[0].Select("AssociateQuarter = '2' AND AssociateStatus = 'AssociateToTrain'");

            if (result2.Length > 0)
            {
                if (string.IsNullOrEmpty(result2[0]["AssociateStatus"].ToString()))
                    lblSabaNumberEmployees2.Text = "0";
                else
                    lblSabaNumberEmployees2.Text = string.Format("{0:N0}", result2[0]["Total"]);
            }
            else
            {
                lblSabaNumberEmployees2.Text = "0";
            }

            DataRow[] result3 = dsDetail.Tables[0].Select("AssociateQuarter = '3' AND AssociateStatus = 'AssociateToTrain'");

            if (result3.Length > 0)
            {
                if (string.IsNullOrEmpty(result3[0]["AssociateStatus"].ToString()))
                    lblSabaNumberEmployees3.Text = "0";
                else
                    lblSabaNumberEmployees3.Text = string.Format("{0:N0}", result3[0]["Total"]);
            }
            else
            {
                lblSabaNumberEmployees3.Text = "0";
            }

            DataRow[] result4 = dsDetail.Tables[0].Select("AssociateQuarter = '4' AND AssociateStatus = 'AssociateToTrain'");

            if (result4.Length > 0)
            {
                if (string.IsNullOrEmpty(result3[0]["AssociateStatus"].ToString()))
                    lblSabaNumberEmployees4.Text = "0";
                else
                    lblSabaNumberEmployees4.Text = string.Format("{0:N0}", result4[0]["Total"]);
            }
            else
            {
                lblSabaNumberEmployees4.Text = "0";
            }


            DataRow[] q1AssociateToTrain = dsDetail.Tables[0].Select("AssociateQuarter = '1' AND AssociateStatus = 'AssociateTrained'");

            if (q1AssociateToTrain.Length > 0)
            {
                if (string.IsNullOrEmpty(q1AssociateToTrain[0]["AssociateStatus"].ToString()))
                    lblSabaEmployeesTrained1.Text = "0";
                else
                    lblSabaEmployeesTrained1.Text = string.Format("{0:N0}", q1AssociateToTrain[0]["Total"]);
            }

            DataRow[] q2AssociateToTrain = dsDetail.Tables[0].Select("AssociateQuarter = '2' AND AssociateStatus = 'AssociateTrained'");

            if (q2AssociateToTrain.Length > 0)
            {
                if (string.IsNullOrEmpty(q2AssociateToTrain[0]["AssociateStatus"].ToString()))
                    lblSabaEmployeesTrained2.Text = "0";
                else
                    lblSabaEmployeesTrained2.Text = string.Format("{0:N0}", q2AssociateToTrain[0]["Total"]);
            }

            DataRow[] q3AssociateToTrain = dsDetail.Tables[0].Select("AssociateQuarter = '3' AND AssociateStatus = 'AssociateTrained'");

            if (q3AssociateToTrain.Length > 0)
            {
                if (string.IsNullOrEmpty(q3AssociateToTrain[0]["AssociateStatus"].ToString()))
                    lblSabaEmployeesTrained3.Text = "0";
                else
                    lblSabaEmployeesTrained3.Text = string.Format("{0:N0}", q3AssociateToTrain[0]["Total"]);
            }

            DataRow[] q4AssociateToTrain = dsDetail.Tables[0].Select("AssociateQuarter = '4' AND AssociateStatus = 'AssociateTrained'");

            if (q4AssociateToTrain.Length > 0)
            {
                if (string.IsNullOrEmpty(q4AssociateToTrain[0]["AssociateStatus"].ToString()))
                    lblSabaEmployeesTrained4.Text = "0";
                else
                    lblSabaEmployeesTrained4.Text = string.Format("{0:N0}", q4AssociateToTrain[0]["Total"]);
            }
        }
        if (dsDetail.Tables[1].Rows.Count > 0)
        {
            if (Year != null) lblSabaTrainingYear.Text = Convert.ToString(Year);
            else if (dsDetail.Tables[0].Rows[0]["Year"] == DBNull.Value)
                lblSabaTrainingYear.Text = "Data Not Available";
            else
                lblSabaTrainingYear.Text = Convert.ToString(dsDetail.Tables[0].Rows[0]["Year"]);

            DataRow[] result1 = dsDetail.Tables[1].Select("AssociateQuarter = '1'");

            if (result1.Length > 0)
            {
                if (string.IsNullOrEmpty(result1[0]["QuarterPercentage"].ToString()))
                    lblSabaPercentTrained1.Text = "0";
                else
                    lblSabaPercentTrained1.Text = string.Format("{0:0.0#}", result1[0]["QuarterPercentage"]) + "%";
            }

            DataRow[] result2 = dsDetail.Tables[1].Select("AssociateQuarter = '2'");

            if (result2.Length > 0)
            {
                if (string.IsNullOrEmpty(result1[0]["QuarterPercentage"].ToString()))
                    lblSabaPercentTrained2.Text = "0";
                else
                    lblSabaPercentTrained2.Text = string.Format("{0:0.0#}", result2[0]["QuarterPercentage"]) + "%";
            }

            DataRow[] result3 = dsDetail.Tables[1].Select("AssociateQuarter = '3'");

            if (result3.Length > 0)
            {
                if (string.IsNullOrEmpty(result1[0]["QuarterPercentage"].ToString()))
                    lblSabaPercentTrained3.Text = "0";
                else
                    lblSabaPercentTrained3.Text = string.Format("{0:0.0#}", result3[0]["QuarterPercentage"]) + "%";
            }

            DataRow[] result4 = dsDetail.Tables[1].Select("AssociateQuarter = '4'");

            if (result4.Length > 0)
            {
                if (string.IsNullOrEmpty(result4[0]["QuarterPercentage"].ToString()))
                    lblSabaPercentTrained4.Text = "0";
                else
                    lblSabaPercentTrained4.Text = string.Format("{0:0.0#}", result1[0]["QuarterPercentage"]) + "%";
            }

            DataRow[] result5 = dsDetail.Tables[1].Select("AssociateQuarter In ('All Pro','Starter', 'Second String', 'Water boy', 'Spectator')");

            if (result5.Length > 0)
            {
                if (string.IsNullOrEmpty(result5[0]["AssociateQuarter"].ToString()))
                    lblSabaPerformance.Text = "All Pro";
                else
                    lblSabaPerformance.Text = result5[0]["AssociateQuarter"].ToString();

            }
            else
            {
                lblSabaPerformance.Text = "All Pro";
            }
        }
        else
        {
            lblSabaPerformance.Text = "All Pro";
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
                    lblRedPerformance.Text = "All Pro";
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
                case 4: lblPerformanceLevelWC.Text = "Spectator"; break;
                case 10: lblPerformanceLevelWC.Text = "Water boy"; break;
                case 16: lblPerformanceLevelWC.Text = "Second String"; break;
                case 22: lblPerformanceLevelWC.Text = "Starter"; break;
                case 28: lblPerformanceLevelWC.Text = "All Pro"; break;
            }
        }


    }

    #endregion
    protected void lblSabaNumberEmployees_Click(object sender, EventArgs e)
    {
        LinkButton lnk = (LinkButton)sender;
        switch (lnk.ID)
        {
            case "lblSabaNumberEmployees1":
                Quarter = 1;
                AssociateStatus = "AssociateToTrain";
                break;
            case "lblSabaNumberEmployees2":
                Quarter = 2;
                AssociateStatus = "AssociateToTrain";
                break;
            case "lblSabaNumberEmployees3":
                Quarter = 3;
                AssociateStatus = "AssociateToTrain";
                break;
            case "lblSabaNumberEmployees4":
                Quarter = 4;
                AssociateStatus = "AssociateToTrain";
                break;

            case "lblSabaEmployeesTrained1":
                Quarter = 1;
                AssociateStatus = "AssociateTrained";
                break;
            case "lblSabaEmployeesTrained2":
                Quarter = 2;
                AssociateStatus = "AssociateTrained";
                break;
            case "lblSabaEmployeesTrained3":
                Quarter = 3;
                AssociateStatus = "AssociateTrained";
                break;
            case "lblSabaEmployeesTrained4":
                Quarter = 4;
                AssociateStatus = "AssociateTrained";
                break;
        }       

        DataSet dsDetail = Charts.GetSabaTrainingDetail1(Year, DBA, Sonic_Location_Code, Quarter, AssociateStatus);
        DataTable dt = null;
        if(dsDetail.Tables[2] != null)
            dt = dsDetail.Tables[2];
        
        if(dt != null)
            Session["EmployeeDetails"] = dt;

        Response.Redirect("EmployeeDetails.aspx?AssociateStatus=" + AssociateStatus);

    }
}
