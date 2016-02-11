using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ERIMS.DAL;

public partial class SLT_IncidentReview_Info : System.Web.UI.UserControl
{
    //private string[] strCauseBahaviour = { " 1. Operating equipment without authority"," 2. Failure to warn"," 3. Failure to secure"," 4. Operating at improper speed",
    //                                             " 5. Making safety devices inoperative"," 6. Using defective equipment"," 7. Failure to use Personal Protective Equipment(PPE) Properly",
    //                                             " 8. Improper loading"," 9. Improper placement"," 10. Improper lifting"," 11. Improper position for task"," 12. Servicing equipment in operation",
    //                                             " 13. Horse Play"," 14. Under the influence of alcohol and/or other drugs"," 15. Using equipment improperly"," 16. Failure to follow procedure",
    //                                             " 17. Failure to identify hazard/risk"," 18. Failure to check/monitor"," 19. Failure to react/correct"," 20. Failure to communicate/coordinate"
    //                                           };

    //private string[] strCauseConditions = { " 21. Inadequate guards or barriers"," 22. Inadequate or improper protective equipment"," 23. Defective tools, equipment or materials",
    //                                        " 24. Congestion or restricted action"," 25. Inadequate warning system"," 26. Fire and explosion hazards"," 27. Poor housekeeping/disorder",
    //                                        " 28. Noise exposure"," 29. Radiation exposure"," 30. Temperature extremes"," 31. Inadequate or excessive illumination"," 32. Inadequate ventilation",
    //                                        " 33. Presences of harmful materials"," 34. Inadequate instructions/procedures"," 35. Inadequate information/data"," 36. Inadequate preparation/planning",
    //                                        " 37. Inadequate support/assistance"," 38. Inadequate communication hardware/software/process"," 39. Road conditions"," 40. Weather conditions",
    //                                        " 41. Mind off task"," 42. Other - Describe"
    //                                      };
    private string[] strCauseBahaviour = { " Operating equipment without authority"," Failure to warn"," Failure to secure"," Operating at improper speed",
                                                 " Making safety devices inoperative"," Using defective equipment"," Failure to use Personal Protective Equipment(PPE) Properly",
                                                 " Improper loading"," Improper placement"," Improper lifting"," Improper position for task"," Servicing equipment in operation",
                                                 " Horse Play"," Under the influence of alcohol and/or other drugs"," Using equipment improperly"," Failure to follow procedure",
                                                 " Failure to identify hazard/risk"," Failure to check/monitor"," Failure to react/correct"," Failure to communicate/coordinate"
                                               };

    private string[] strCauseConditions = { " Inadequate guards or barriers"," Inadequate or improper protective equipment"," Defective tools, equipment or materials",
                                            " Congestion or restricted action"," Inadequate warning system"," Fire and explosion hazards"," Poor housekeeping/disorder",
                                            " Noise exposure"," Radiation exposure"," Temperature extremes"," Inadequate or excessive illumination"," Inadequate ventilation",
                                            " Presences of harmful materials"," Inadequate instructions/procedures"," Inadequate information/data"," Inadequate preparation/planning",
                                            " Inadequate support/assistance"," Inadequate communication hardware/software/process"," Road conditions"," Weather conditions",
                                            " Mind off task"," Other - Describe"
                                          };
    #region "Events Declaration"
    public delegate void dlgIncidentReview();
    public event dlgIncidentReview BindIncidentReviewGrid;

    public delegate void dlgUpdateScore();
    public event dlgUpdateScore UpdateSLTScore;
    #endregion

    #region Properties
   
    public string Year
    {
        get { return Convert.ToString(ViewState["_Year"]); }
        set { ViewState["_Year"] = value; }
    }
    public string Month
    {
        get { return Convert.ToString(ViewState["_Month"]); }
        set { ViewState["_Month"] = value; }
    }
    /// <summary>
    /// Denotes the Foreign Key
    /// </summary>
    public decimal FK_SLT_Meeting
    {
        get
        {
            return clsGeneral.GetInt(ViewState["FK_SLT_Meeting"]);
        }
        set { ViewState["FK_SLT_Meeting"] = value; }
    }
    /// <summary>
    /// Denotes the Foreign Key
    /// </summary>
    public decimal FK_SLT_Meeting_Schedule
    {
        get
        {
            return clsGeneral.GetInt(ViewState["FK_SLT_Meeting_Schedule"]);
        }
        set { ViewState["FK_SLT_Meeting_Schedule"] = value; }
    }
    /// <summary>
    /// Denotes the FK_LU_Location_ID
    /// </summary>
    public decimal FK_LU_Location_ID
    {
        get
        {
            return clsGeneral.GetInt(ViewState["FK_LU_Location_ID"]);
        }
        set { ViewState["FK_LU_Location_ID"] = value; }
    }
    /// <summary>
    /// Denotes the PK_Investigation_ID
    /// </summary>
    public decimal PK_Investigation_ID
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_Investigation_ID"]);
        }
        set { ViewState["PK_Investigation_ID"] = value; }
    }
    /// <summary>
    /// Denotes the Primary Key
    /// </summary>
    public decimal PK_WC_FR_ID
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_WC_FR_ID"]);
        }
        set { ViewState["PK_WC_FR_ID"] = value; }
    }
    /// <summary>
    /// denotes the primary key
    /// </summary>
    public decimal PK_AL_FR_ID //PK_AL_FR_ID
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_AL_FR_ID"]);
        }
        set { ViewState["PK_AL_FR_ID"] = value; }
    }
    /// <summary>
    /// Denotes the Primary Key
    /// </summary>
    public decimal PK_DPD_FR_ID
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_DPD_FR_ID"]);
        }
        set { ViewState["PK_DPD_FR_ID"] = value; }
    }
    /// <summary>
    /// Denotes the Primary Key
    /// </summary>
    public decimal PK_PL_FR_ID
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_PL_FR_ID"]);
        }
        set { ViewState["PK_PL_FR_ID"] = value; }
    }
    /// <summary>
    /// Denotes the Primary Key
    /// </summary>
    public decimal PK_Property_FR_ID
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_Property_FR_ID"]);
        }
        set { ViewState["PK_Property_FR_ID"] = value; }
    }
    /// <summary>
    /// Denotes the Foreign Key
    /// </summary>
    public decimal FK_SLT_Incident_Review
    {
        get
        {
            return clsGeneral.GetInt(ViewState["FK_SLT_Incident_Review"]);
        }
        set { ViewState["FK_SLT_Incident_Review"] = value; }
    } 
    /// <summary>
    /// Denotes the Foreign Key
    /// </summary>
    public decimal FK_LU_Incident_Type
    {
        get
        {
            return clsGeneral.GetInt(ViewState["FK_LU_Incident_Type"]);
        }
        set { ViewState["FK_LU_Incident_Type"] = value; }
    }
    /// <summary>
    /// Denotes the Mode
    /// </summary>
    public string StrOperation
    {
        get
        {
            return  Convert.ToString(ViewState["StrOperation"]);
        }
        set { ViewState["StrOperation"] = value; }
    }
    public string Incident_ReviewType
    {
        get
        {
            return Convert.ToString(ViewState["Incident_ReviewType"]);
        }
        set { ViewState["Incident_ReviewType"] = value; }
    }
    
#endregion

    #region Page Events
    /// <summary>
    /// Handles Page Load
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            FillDropDowns();
            if (StrOperation == "view")
            {
                if (string.IsNullOrEmpty(Year)) { Year = DateTime.Now.Year.ToString(); } else { ddlYear.SelectedValue = Year; }
                if (string.IsNullOrEmpty(Month)) { Month = DateTime.Now.Month.ToString(); } else { ddlMonth.SelectedValue = Month; }
                //trIncident_Review_Edit.Visible = false;
                //trIncident_Review_View.Visible = true;

                txtComments_View.Visible = lblSLT_Agree_Root_Cause.Visible = true;
                trRisk_Maanagement_Review_View.Visible = true;
                Span6.Visible = txtComments.Visible = rdoRoot_Cause.Visible = false;
                trRisk_Maanagement_Review_Edit.Visible = false;
                ShowHideRow();
            }
            else
            {
                if (string.IsNullOrEmpty(Year)) { Year = DateTime.Now.Year.ToString(); } else { ddlYear.SelectedValue = Year; }
                if (string.IsNullOrEmpty(Month)) { Month = DateTime.Now.Month.ToString(); } else { ddlMonth.SelectedValue = Month; }
                //trIncident_Review_Edit.Visible = true;
                //trIncident_Review_View.Visible = false;

                txtComments_View.Visible = lblSLT_Agree_Root_Cause.Visible = false;
                trRisk_Maanagement_Review_View.Visible = false;
                txtComments.Visible = rdoRoot_Cause.Visible = true;
                trRisk_Maanagement_Review_Edit.Visible = true;
            }
            
        }
    }
    #endregion

    #region Methods
    /// <summary>
    /// Set all Validations
    /// </summary>
    private void SetValidations(int ScreenID,string Validation_ScreenName)
    {
        string strCtrlsIDs = "";
        string strMessages = "";

        #region "Producers"
        DataTable dtFields = clsScreen_Validators.SelectByScreen(ScreenID).Tables[0];
        dtFields.DefaultView.RowFilter = "IsRequired = '1'";
        dtFields = dtFields.DefaultView.ToTable();
        //MenuAsterisk1.Style["display"] = (dtFields.Select("LeftMenuIndex = 5").Length > 0) ? "inline-block" : "none";
        foreach (DataRow drField in dtFields.Rows)
        {
            #region " set validation control IDs and messages "

            if (rdoRoot_Cause.SelectedValue == "N")
            {
                switch (Convert.ToString(drField["Field_Name"]))
                {
                    case "What is the incidents root cause?":
                        strCtrlsIDs += txtrootcause.ClientID + ",";
                        strMessages += Validation_ScreenName + "/What is the incidents root cause?" + ",";
                        Span1.Style["display"] = "inline-block";
                        break;
                    case "How can the incident be prevented from happening again?":
                        strCtrlsIDs += txtPreventedFromHappening.ClientID + ",";
                        strMessages += Validation_ScreenName + "/How can the incident be prevented from happening again?" + ",";
                        Span2.Style["display"] = "inline-block";
                        break;
                    case "Who has been tasked with implementing practices/procedures to prevent re-occurrence?":
                        strCtrlsIDs += txtConfirmation_Assign_To.ClientID + ",";
                        strMessages += Validation_ScreenName + "/Who has been tasked with implementing practices/procedures to prevent re-occurrence?" + ",";
                        Span3.Style["display"] = "inline-block";
                        break;
                    case "Target Date of Completion":
                        strCtrlsIDs += txtTargetDateCompletion.ClientID + ",";
                        strMessages += Validation_ScreenName + "/Target Date of Completion" + ",";
                        Span4.Style["display"] = "inline-block";
                        break;
                    case "Status Due On":
                        strCtrlsIDs += txtStatusDueOn.ClientID + ",";
                        strMessages += Validation_ScreenName + "/Status Due On" + ",";
                        Span5.Style["display"] = "inline-block";
                        break;
                    //case "Comments":
                    //    strCtrlsIDs += txtComments.ClientID + ",";
                    //    strMessages += Validation_ScreenName + "/Comments" + ",";
                    //    Span6.Style["display"] = "inline-block";
                    //    break;
                    //case "Item Status":
                    //    strCtrlsIDs += drpItemStatus.ClientID + ",";
                    //    strMessages += Validation_ScreenName + "/Item Status" + ",";
                    //    Span7.Style["display"] = "inline-block";
                    //    break;
                    //case "Incident Investigation":
                    //    strCtrlsIDs += rdoIncidentInvestigation.ClientID + ",";
                    //    strMessages += Validation_ScreenName + "/Incident Investigation" + ",";
                    //    Span8.Style["display"] = "inline-block";
                    //    break;
                    //case "Date Reviewed":
                    //    strCtrlsIDs += txtDateReviewed.ClientID + ",";
                    //    strMessages += Validation_ScreenName + "/Date Reviewed" + ",";
                    //    Span9.Style["display"] = "inline-block";
                    //    break;

                }
            }
            //else
            //{
            //    switch (Convert.ToString(drField["Field_Name"]))
            //    {
            //        case "Comments":
            //            strCtrlsIDs += txtComments.ClientID + ",";
            //            strMessages += Validation_ScreenName + "/Comments" + ",";
            //            Span6.Style["display"] = "inline-block";
            //            break;
            //    }
            //}

            switch (Convert.ToString(drField["Field_Name"]))
            {
                case "Comments":
                    strCtrlsIDs += txtComments.ClientID + ",";
                    strMessages += Validation_ScreenName + "/Comments" + ",";
                    Span6.Style["display"] = "inline-block";
                    break;
                case "Item Status":
                    strCtrlsIDs += drpItemStatus.ClientID + ",";
                    strMessages += Validation_ScreenName + "/Item Status" + ",";
                    Span7.Style["display"] = "inline-block";
                    break;
                case "Incident Investigation":
                    strCtrlsIDs += rdoIncidentInvestigation.ClientID + ",";
                    strMessages += Validation_ScreenName + "/Incident Investigation" + ",";
                    Span8.Style["display"] = "inline-block";
                    break;
                case "Date Reviewed":
                    strCtrlsIDs += txtDateReviewed.ClientID + ",";
                    strMessages += Validation_ScreenName + "/Date Reviewed" + ",";
                    Span9.Style["display"] = "inline-block";
                    break;
            }
            #endregion
        }
        #endregion

        strCtrlsIDs = strCtrlsIDs.TrimEnd(',');
        strMessages = strMessages.TrimEnd(',');

        hdnControlIDs.Value = strCtrlsIDs;
        hdnErrorMsgs.Value = strMessages;
    }
    /// <summary>
    /// Apply validation Group 
    /// </summary>
    /// <param name="strValidation_Group"></param>
    public void Apply_Validation_Group(string strValidation_Group,int ScreenID, string Validation_ScreenName)
    {
        valSummayIncident.ValidationGroup = strValidation_Group;
        btnSaveNext.ValidationGroup = strValidation_Group;
        CustomValidator.ValidationGroup = strValidation_Group;
        revTargetDateCompletion.ValidationGroup = strValidation_Group;
        revTargetDateCompletion.ErrorMessage = Validation_ScreenName + "/" + revTargetDateCompletion.ErrorMessage;
        revStatusDueOn.ValidationGroup = strValidation_Group;
        revStatusDueOn.ErrorMessage = Validation_ScreenName + "/" + revStatusDueOn.ErrorMessage;
        //revDateReviewed.ValidationGroup = strValidation_Group;
        //revDateReviewed.ErrorMessage = Validation_ScreenName + "/" + revDateReviewed.ErrorMessage;
        SetValidations(ScreenID, Validation_ScreenName);
    }
    /// <summary>
    /// Fill Incident Grid and All Incident Type First time 
    /// </summary>
    public void FillAllIncident_Grid()
    {
        PK_WC_FR_ID = 0;
        PK_AL_FR_ID = 0;
        PK_PL_FR_ID = 0;
        PK_DPD_FR_ID = 0;
        PK_Property_FR_ID = 0;
        PK_Investigation_ID = 0;
        FK_SLT_Incident_Review = 0;

        ddlYear.SelectedValue = Year;
        ddlMonth.SelectedValue = Month;
        if (Incident_ReviewType == "WC")
        {
            lblHeading.Text = "Investigations";
            trWC_Fr.Visible = true;
            FillWC_FR_Grid(false);
            Apply_Validation_Group("VSGroup_WC", 182, "[Investigations]");
        }
    }
    /// <summary>
    /// Show dashboard score in Incident Grid
    /// </summary>
    public void FillDashBoardScore()
    {
        DataSet dsResult = Charts.GetIncidentInvestigationByRegion(Convert.ToInt16(Year));
        DataTable dtResult = dsResult.Tables[0];
        if (dsResult.Tables.Count > 1)
        {
          //  if (dsResult.Tables[1].Rows.Count > 0)
           //     lblDealerShip.Text = Convert.ToString(dsResult.Tables[1].Rows[0]["Score"]);
        }
    }
    /// <summary>
    /// Fill Drop downs
    /// </summary>
    public void FillDropDowns()
    {
        FillYear();
        FillMonth();
        DataSet ds = LU_Item_Status.SelectAll();
        if (ds.Tables[0].Rows.Count > 0)
        {
            drpItemStatus.ClearSelection();
            drpItemStatus.Items.Clear();
            drpItemStatus.DataSource = ds.Tables[0];
            drpItemStatus.DataTextField = "Fld_Desc";
            drpItemStatus.DataValueField = "PK_LU_Item_Status";
            drpItemStatus.DataBind();
        }
        drpItemStatus.Items.Insert(0, new ListItem("--Select--", "0"));
    }
    /// <summary>
    /// Fill Year In ddl
    /// </summary>
    public void FillYear()
    {
        for (int _Year = DateTime.Now.Year; _Year >= 2007; _Year--)
        {
            ddlYear.Items.Add(new ListItem(_Year.ToString(), _Year.ToString()));
        }
        ddlYear.SelectedValue = DateTime.Now.Year.ToString();
    }
    /// <summary>
    /// Fill Month Name In ddl
    /// </summary>
    public void FillMonth()
    {
        ddlMonth.Items.Add(new ListItem("January", "1"));
        ddlMonth.Items.Add(new ListItem("February", "2"));
        ddlMonth.Items.Add(new ListItem("March", "3"));
        ddlMonth.Items.Add(new ListItem("April", "4"));
        ddlMonth.Items.Add(new ListItem("May", "5"));
        ddlMonth.Items.Add(new ListItem("June", "6"));
        ddlMonth.Items.Add(new ListItem("July", "7"));
        ddlMonth.Items.Add(new ListItem("August", "8"));
        ddlMonth.Items.Add(new ListItem("September", "9"));
        ddlMonth.Items.Add(new ListItem("October", "10"));
        ddlMonth.Items.Add(new ListItem("November", "11"));
        ddlMonth.Items.Add(new ListItem("December", "12"));

        ddlMonth.SelectedValue = DateTime.Now.Month.ToString();
    }

    public void SeletedYearMonthInDDl()
    {
        ddlYear.SelectedValue = Year;
        ddlMonth.SelectedValue = Month;
    }
    
    /// <summary>
    /// Get records For Incident Review for FR
    /// </summary>
    /// <param name="strFR"></param>
    /// <returns></returns>
    public DataTable FillFirstReport(string strFR)
    {
        return SLT_Incident_Review.GetIncident_Review_FirstReport(Year, Month, strFR, FK_LU_Location_ID, 0).Tables[0];
    }
    #region WC_Fr Methods
    /// <summary>
    /// Fill WC_FR by PK
    /// </summary>
    public void FillWC_FR()
    {
        DataSet dsWC_Fr = SLT_Incident_Review.GetIncidentReviewByPK_WF_FR(PK_WC_FR_ID);
        DataTable dtWC_Fr = dsWC_Fr.Tables[0];
        DataTable dtWC_Allocation_Charge = dsWC_Fr.Tables[1];

        if (dtWC_Fr.Rows.Count > 0)
        {
            PK_Investigation_ID = Convert.ToDecimal(dtWC_Fr.Rows[0]["PK_Investigation_ID"].ToString());
            PK_WC_FR_ID = Convert.ToDecimal(dtWC_Fr.Rows[0]["PK_WC_FR_ID"].ToString());
            FK_LU_Incident_Type = 1;
            FK_SLT_Incident_Review = dtWC_Fr.Rows[0]["FK_SLT_Incident_Review"] == DBNull.Value ? 0 : Convert.ToDecimal(dtWC_Fr.Rows[0]["FK_SLT_Incident_Review"].ToString());
            lblIncidentNumber_WC.Text = dtWC_Fr.Rows[0]["FirstReportNumber"].ToString();
            lblName_WC.Text = dtWC_Fr.Rows[0]["Name"].ToString();
            lblDate_of_Incident_WC.Text = clsGeneral.FormatDBNullDateToDisplay(dtWC_Fr.Rows[0]["Date_Of_Incident"].ToString());
            lblDepartment_WC.Text = dtWC_Fr.Rows[0]["Department"].ToString();
            lblTime_of_Incident_WC.Text = dtWC_Fr.Rows[0]["Time_Of_Incident"].ToString();
            lblNature_of_Injury_WC.Text = dtWC_Fr.Rows[0]["Nature_of_Injury"].ToString();
            lblBodyPartEffected_WC.Text = dtWC_Fr.Rows[0]["Body_Part_Effected"].ToString();
            txtDescription_Of_Incident_WC.Text = dtWC_Fr.Rows[0]["Incident_Description"].ToString();
            lblLessons_Learned.Text = dtWC_Fr.Rows[0]["Lessons_Learned"].ToString();
            lblNatureOfTheIncident.Text = dtWC_Fr.Rows[0]["Focus_Area"].ToString();
            lblConclusions.Text = dtWC_Fr.Rows[0]["Conclusions"].ToString();
            #region Substances behavior and Conditions code
            DataTable dtCauseBehaviour = new DataTable();
            dtCauseBehaviour.Columns.Add("Description", typeof(string));
            int startCount = 0;
            for (int i = 9; i <= 28; i++)
            {
                if (!string.IsNullOrEmpty(dtWC_Fr.Rows[0][i].ToString()) && Convert.ToBoolean(dtWC_Fr.Rows[0][i].ToString()))
                {
                    DataRow dr = dtCauseBehaviour.NewRow();
                    dr["Description"] = strCauseBahaviour[startCount].ToString();
                    dtCauseBehaviour.Rows.Add(dr);
                    startCount = startCount + 1;
                }
                else
                {
                    startCount = startCount + 1;
                }
            }
            //if (dtCauseBehaviour.Rows.Count > 0)
            //{
            //    rptCauseBehaviours.DataSource = dtCauseBehaviour;
            //    rptCauseBehaviours.DataBind();
            //}
            startCount = 0;
            DataTable dtCauseConditions = new DataTable();
            dtCauseConditions.Columns.Add("Description", typeof(string));
            for (int i = 29; i <= 50; i++)
            {
                if (!string.IsNullOrEmpty(dtWC_Fr.Rows[0][i].ToString()) && Convert.ToBoolean(dtWC_Fr.Rows[0][i].ToString()))
                {
                    DataRow dr = dtCauseConditions.NewRow();
                    dr["Description"] = strCauseConditions[startCount].ToString();
                    dtCauseConditions.Rows.Add(dr);
                    startCount = startCount + 1;
                }
                else
                {
                    startCount = startCount + 1;
                }
            }
            if (dtCauseConditions.Rows.Count > 0)
            {
                rptCauseConditions.DataSource = dtCauseConditions;
                rptCauseConditions.DataBind();
            }
            #endregion
            //txtCause_Comment.Text = dtWC_Fr.Rows[0]["Cause_Comment"].ToString();
            txtEvent_Cause_Comment.Text = dtWC_Fr.Rows[0]["Cause_Comment"].ToString();
            //txtPersonal_Job_Comment.Text = dtWC_Fr.Rows[0]["Personal_Job_Comment"].ToString();
            //lblOSHARecordable.Text = dtWC_Fr.Rows[0]["OSHA_Recordable"].ToString();
            lblOSHARecordable_Root_Cause.Text = dtWC_Fr.Rows[0]["OSHA_Recordable"].ToString();
            //lblSonicCauseCode.Text = dtWC_Fr.Rows[0]["Sonic_Cause_Code"].ToString();
            lblSonicCauseCode_Root_Cause.Text = dtWC_Fr.Rows[0]["Sonic_Cause_Code"].ToString();
            //lblInvestigative.Text = dtWC_Fr.Rows[0]["Investigative_Quality"].ToString();
            //lblDescription_Corrective.Text = dtWC_Fr.Rows[0]["Corrective_Action_Description"].ToString();
            lblAssignedTo.Text = dtWC_Fr.Rows[0]["Assigned_To"].ToString();
            //lblAssignedBy.Text = dtWC_Fr.Rows[0]["AssignedBy"].ToString();
            //lblAssignedBy.Text = dtWC_Fr.Rows[0]["Lessons_Learned"].ToString();
            //lblIncidentReview_LagTime.Text = dtWC_Fr.Rows[0]["Lag_Time"].ToString();
            //lblRLCMComments.Text = dtWC_Fr.Rows[0]["RLCM_Comments"].ToString();
            lblContributingFactor.Text = dtWC_Fr.Rows[0]["Contributing_Factor"].ToString();
            lblContributingFactor_Other.Text = dtWC_Fr.Rows[0]["Contributing_Factor_Other"].ToString();
            lblCommunicatedToAssociate.Text = dtWC_Fr.Rows[0]["Communicated"].ToString() == "Y" ? "Yes" : "No";
            lblStatus_Corrective.Text = Convert.ToString(dtWC_Fr.Rows[0]["Status"]);
            
            DataSet ds = null;
            ds = clsInvestigation_Cause_Information.SelectByInvestigationID(Convert.ToDecimal(PK_Investigation_ID));

            rptRootCauseDeterminationView.DataSource = ds;
            rptRootCauseDeterminationView.DataBind();
            rptRootCauseDeterminationRecmndationView.DataSource = ds;
            rptRootCauseDeterminationRecmndationView.DataBind();

            DataTable dtRootCauseDetermination = ds.Tables[0];
            for (int i = 0; i < dtRootCauseDetermination.Rows.Count; i++)
            {
                Label lblRootCauseTypeList = (Label)rptRootCauseDeterminationView.Items[i].FindControl("lblRootCauseTypeList");

                ASP.controls_notes_notes_ascx cnt_Note = rptRootCauseDeterminationView.Items[i].FindControl("lblRoot_Cause_Comments") as ASP.controls_notes_notes_ascx;
                TextBox lblRoot_Cause_Comments = cnt_Note.FindControl("txtNote") as TextBox;

                lblRootCauseTypeList.Text = Convert.ToString(dtRootCauseDetermination.Rows[i]["Response"]) == "Y" ? "Yes" : "No";
                lblRoot_Cause_Comments.Text = Convert.ToString(dtRootCauseDetermination.Rows[i]["Comments"]);
            }

            //Review 
            lblTiming_View.Text = dtWC_Fr.Rows[0]["Timing"].ToString() != "" ? dtWC_Fr.Rows[0]["Timing"].ToString() == "Y" ? "Yes" : "No" : "";
            lblSLTinvolvedInIntialInv.Text = dtWC_Fr.Rows[0]["SLT_Involvement"].ToString() != "" ? dtWC_Fr.Rows[0]["SLT_Involvement"].ToString() == "Y" ? "Yes" : "No" : "";
            lblAllFactsClearly.Text = dtWC_Fr.Rows[0]["Witnesses"].ToString() != "" ? dtWC_Fr.Rows[0]["Witnesses"].ToString() == "Y" ? "Yes" : "No" : "";
            lblRootCauseIdentifyCorrect.Text = dtWC_Fr.Rows[0]["SLT_Visit"].ToString() != "" ? dtWC_Fr.Rows[0]["SLT_Visit"].ToString() == "Y" ? "Yes" : "No" : "";
            lblActionPlanPreventReoccuring.Text = dtWC_Fr.Rows[0]["Root_Causes"].ToString() != "" ? dtWC_Fr.Rows[0]["Root_Causes"].ToString() == "Y" ? "Yes" : "No" : "";
            lblActionPlanCommunicatedtoAssociate.Text = dtWC_Fr.Rows[0]["Action_Plan"].ToString() != "" ? dtWC_Fr.Rows[0]["Action_Plan"].ToString() == "Y" ? "Yes" : "No" : "";
            lblInvestigatescoreMetric.Text = dtWC_Fr.Rows[0]["Investigative_Quality"].ToString();

            Bind_SLT_Incident_Review();
        }

        lblAllocation_Charge.Text = lblReporting_Credit.Text = lblInvestigation_Quality_Credit.Text = lblReporting_Charge.Text = lblTotal_Charge.Text =
                lblNurse_Triage_Credit.Text = lblEarly_Close_Credit.Text = lblRe_Open_Charge.Text = string.Format("{0:C2}", 0.00);

        if (dtWC_Allocation_Charge.Rows.Count > 0)
        {
            Int32 intTotal_Charge = 0;
            
            foreach (DataRow drChargeType in dtWC_Allocation_Charge.Rows)
            {
                if (Convert.ToString(drChargeType["Charge_Type"]) == "Initial Charge")
                    lblAllocation_Charge.Text = string.Format("{0:C2}", drChargeType["Charge_Total"]);
                else if (Convert.ToString(drChargeType["Charge_Type"]) == "Lag Credit")
                    lblReporting_Credit.Text = string.Format("{0:C2}", drChargeType["Charge_Total"]);
                else if (Convert.ToString(drChargeType["Charge_Type"]) == "Nurse Triage Credit")
                    lblNurse_Triage_Credit.Text = string.Format("{0:C2}", drChargeType["Charge_Total"]);
                else if (Convert.ToString(drChargeType["Charge_Type"]) == "Lag Charge")
                    lblReporting_Charge.Text = string.Format("{0:C2}", drChargeType["Charge_Total"]);
                else if (Convert.ToString(drChargeType["Charge_Type"]) == "Incident Investigation Credit")
                    lblInvestigation_Quality_Credit.Text = string.Format("{0:C2}", drChargeType["Charge_Total"]);
                else if (Convert.ToString(drChargeType["Charge_Type"]) == "Early Close Credit")
                    lblEarly_Close_Credit.Text = string.Format("{0:C2}", drChargeType["Charge_Total"]);
                else if (Convert.ToString(drChargeType["Charge_Type"]) == "Reopen Charge")
                    lblRe_Open_Charge.Text = string.Format("{0:C2}", drChargeType["Charge_Total"]);

                if (Convert.ToString(drChargeType["Charge_Type"]) == "Nurse Triage Credit" || Convert.ToString(drChargeType["Charge_Type"]) == "Initial Charge" ||
                    Convert.ToString(drChargeType["Charge_Type"]) == "Early Close Credit" || Convert.ToString(drChargeType["Charge_Type"]) ==  "Reopen Charge" ||
                    Convert.ToString(drChargeType["Charge_Type"]) == "Lag Credit" || Convert.ToString(drChargeType["Charge_Type"]) == "Lag Charge" ||
                    Convert.ToString(drChargeType["Charge_Type"]) == "Incident Investigation Credit")
                    intTotal_Charge = intTotal_Charge + Convert.ToInt32(drChargeType["Charge_Total"]);
            }
            lblTotal_Charge.Text = string.Format("{0:C2}", intTotal_Charge);
        }
            
        
    }
    /// <summary>
    /// Fill Wc_Fr Grid
    /// </summary>
    public void FillWC_FR_Grid(bool IsRequiredToFill)
    {
        SeletedYearMonthInDDl();
        DataTable dt = FillFirstReport("WC_FR");
        if (dt.Rows.Count > 0)
        {
           
            gvWc_fr.DataSource = dt;
            gvWc_fr.DataBind();
            if (IsRequiredToFill)
            {
                PK_WC_FR_ID = Convert.ToDecimal(dt.Rows[0]["PK_WC_FR_ID"].ToString());
                FillWC_FR();// Fill Data For WC_Fr 
                trWC_Fr.Visible = true;
                btnSaveNext.Enabled = true;
            }
            else
            {
                trWC_Fr.Visible = true;
                btnSaveNext.Enabled = false;
                btnAuditTrail_Edit.Visible = false;
                //btnAuditTrail_View.Visible = false;
                ClearFields_WC();
                ClearFields_Edit();
                ClearFields_View();
            }
        }
        else
        {
            gvWc_fr.DataSource = null;
            gvWc_fr.DataBind();
            btnAuditTrail_Edit.Visible = false;
            //btnAuditTrail_View.Visible = false;
            ClearFields_WC();
            ClearFields_Edit();
            ClearFields_View();
            btnSaveNext.Enabled = false;
        }
    }
    /// <summary>
    /// Clear Fields for WC
    /// </summary>
    public void ClearFields_WC()
    {
        lblIncidentNumber_WC.Text = "";
        lblName_WC.Text = "";
        lblDate_of_Incident_WC.Text = "";
        lblDepartment_WC.Text = "";
        lblTime_of_Incident_WC.Text = "";
        lblNature_of_Injury_WC.Text = "";
        lblBodyPartEffected_WC.Text = "";
        txtDescription_Of_Incident_WC.Text = "";
        //rptCauseBehaviours.DataSource = null;
        //rptCauseBehaviours.DataBind();
        rptCauseConditions.DataSource = null;
        rptCauseConditions.DataBind();
        //txtCause_Comment.Text = "";
        //txtPersonal_Job_Comment.Text = "";
        //lblOSHARecordable.Text = "";
        lblOSHARecordable_Root_Cause.Text = "";
        //lblSonicCauseCode.Text = "";
        lblSonicCauseCode_Root_Cause.Text = "";
        //lblInvestigative.Text = "";
        lblContributingFactor.Text = "";
        lblContributingFactor_Other.Text = "";
        txtEvent_Cause_Comment.Text = "";
    }
    #endregion
   
    /// <summary>
    /// Bind Incident Review Fields by FK_SLT_Incident_Review
    /// </summary>
    public void  Bind_SLT_Incident_Review()
    {
       // ClearFields_View();
        // ClearFields_Edit();
        if (FK_SLT_Incident_Review > 0)
        {
            SLT_Incident_Review objSLT_Incident_Review = new SLT_Incident_Review(FK_SLT_Incident_Review);
            if (StrOperation.ToString().ToLower() == "view")
            {
                lblRoot_Cause_View.Text = objSLT_Incident_Review.Root_Cause;
                lblPreventedFromHappening_View.Text = objSLT_Incident_Review.Conclusions;
                lblConfirmation_Assign_To_View.Text = objSLT_Incident_Review.Confirmation_Assigned_To;
                lblTargetCompletionDate_View.Text = clsGeneral.FormatDBNullDateToDisplay(objSLT_Incident_Review.Target_Comp_Date);
                lblStatusDueOn_View.Text = clsGeneral.FormatDBNullDateToDisplay(objSLT_Incident_Review.Status_Due_On);
                if (objSLT_Incident_Review.Incident_Investigation == "Y") { lblIncidentInvestigation_View.Text = "Yes"; }
                else if (objSLT_Incident_Review.Incident_Investigation == "N") { lblIncidentInvestigation_View.Text = "No"; }
                else { lblIncidentInvestigation_View.Text = ""; }
                lblDateReceived_View.Text = clsGeneral.FormatDBNullDateToDisplay(objSLT_Incident_Review.DateReviewed);
                //lblComments_View.Text = objSLT_Incident_Review.Comments;
                if (Convert.ToDecimal(objSLT_Incident_Review.FK_LU_Item_Status) > 0)
                {
                    LU_Item_Status objLU_Item_Status = new LU_Item_Status(Convert.ToDecimal(objSLT_Incident_Review.FK_LU_Item_Status));
                    lblItemStatus.Text = objLU_Item_Status.Fld_Desc;
                }

                if (objSLT_Incident_Review.SLT_Agree_Root_Cause == "Y") { lblSLT_Agree_Root_Cause.Text = "Yes"; }
                else if (objSLT_Incident_Review.SLT_Agree_Root_Cause == "N") { lblSLT_Agree_Root_Cause.Text = "No"; }
                else { lblSLT_Agree_Root_Cause.Text = ""; }
                rdoRoot_Cause.Visible = false;

                txtComments_View.Text = objSLT_Incident_Review.Comments;
                txtComments.Visible = false;

                trIncident_Review_Edit.Visible = false;
                
                //if (objSLT_Incident_Review.SLT_Agree_Root_Cause == "N")
                //    trIncident_Review_View.Visible = true;
                //else
                //    trIncident_Review_View.Visible = false;

                trIncident_Review_View.Visible = (objSLT_Incident_Review.SLT_Agree_Root_Cause == "N");

                btnSaveNext.Visible = false;
                //btnAuditTrail_Edit.Visible = false;
                //btnAuditTrail_View.Visible = true;
                btnAuditTrail_Edit.Visible = true;
            }
            else
            {
                txtrootcause.Text = objSLT_Incident_Review.Root_Cause;
                rdoRoot_Cause.SelectedValue = objSLT_Incident_Review.SLT_Agree_Root_Cause == null ? "N" : objSLT_Incident_Review.SLT_Agree_Root_Cause;
                txtPreventedFromHappening.Text = objSLT_Incident_Review.Conclusions;
                txtConfirmation_Assign_To.Text = objSLT_Incident_Review.Confirmation_Assigned_To;
                txtTargetDateCompletion.Text = clsGeneral.FormatDBNullDateToDisplay(objSLT_Incident_Review.Target_Comp_Date);
                txtStatusDueOn.Text = clsGeneral.FormatDBNullDateToDisplay(objSLT_Incident_Review.Status_Due_On);
                rdoIncidentInvestigation.SelectedValue = objSLT_Incident_Review.Incident_Investigation;
                txtDateReviewed.Text = clsGeneral.FormatDBNullDateToDisplay(objSLT_Incident_Review.DateReviewed); 
                txtComments.Text = objSLT_Incident_Review.Comments;
                txtComments_View.Visible = false;
                if (Convert.ToDecimal(objSLT_Incident_Review.FK_LU_Item_Status) > 0)
                {
                    LU_Item_Status objLU_Item_Status = new LU_Item_Status(Convert.ToDecimal(objSLT_Incident_Review.FK_LU_Item_Status));
                    drpItemStatus.SelectedValue = objLU_Item_Status.PK_LU_Item_Status.ToString();
                }
                else
                    drpItemStatus.SelectedIndex = -1;
                trIncident_Review_Edit.Visible = true;
                trIncident_Review_View.Visible = false;
                btnSaveNext.Visible = true;
                btnAuditTrail_Edit.Visible = true;
                //btnAuditTrail_View.Visible = false;
            }
            btnAuditTrail_Edit.Attributes.Add("onclick", "return AuditPopUp('" + FK_SLT_Incident_Review + "','" + Incident_ReviewType + "');");
            //btnAuditTrail_View.Attributes.Add("onclick", "return AuditPopUp('" + FK_SLT_Incident_Review + "','" + Incident_ReviewType + "');");
            if (objSLT_Incident_Review.FK_LU_Item_Status == 2)
            {
                FK_SLT_Incident_Review = 0;
                btnAuditTrail_Edit.Visible = false;
                //btnAuditTrail_View.Visible = false;
                ClearFields_View();
                ClearFields_Edit();
                PK_Investigation_ID = 0;
                PK_WC_FR_ID = 0;
                FK_LU_Incident_Type = 1;
                FK_SLT_Incident_Review = 0;
                lblIncidentNumber_WC.Text = "";
                lblName_WC.Text = "";
                lblDate_of_Incident_WC.Text = "";
                lblDepartment_WC.Text = "";
                lblTime_of_Incident_WC.Text = "";
                lblNature_of_Injury_WC.Text = "";
                lblBodyPartEffected_WC.Text = "";
                txtDescription_Of_Incident_WC.Text = "";
                #region Substances behavior and Conditions code
                    //rptCauseBehaviours.DataSource = null;
                    //rptCauseBehaviours.DataBind();
                    rptCauseConditions.DataSource = null;
                    rptCauseConditions.DataBind();
                #endregion
                //txtCause_Comment.Text = "";
                txtEvent_Cause_Comment.Text = "";
                //txtPersonal_Job_Comment.Text = "";
                //lblOSHARecordable.Text = "";
                lblOSHARecordable_Root_Cause.Text = "";
                //lblSonicCauseCode.Text = "";
                lblSonicCauseCode_Root_Cause.Text = "";
                //lblInvestigative.Text = "";
                //lblDescription_Corrective.Text = "";
                lblAssignedTo.Text = "";
                //lblAssignedBy.Text = "";
                //lblAssignedBy.Text = "";
                //lblIncidentReview_LagTime.Text = "";
                //lblRLCMComments.Text ="";
                lblContributingFactor.Text = "";
                lblContributingFactor_Other.Text = "";
            }
        }
        else
        {
            FK_SLT_Incident_Review = 0;
            btnAuditTrail_Edit.Visible = false;
            //btnAuditTrail_View.Visible = false;
            ClearFields_View();
            ClearFields_Edit();
        }
        
    }
    public void ClearFields_Edit()
    {
        txtrootcause.Text = "";
        txtPreventedFromHappening.Text = "";
        txtConfirmation_Assign_To.Text = "";
        txtTargetDateCompletion.Text = "";
        txtStatusDueOn.Text = "";
        txtDateReviewed.Text = "";
        rdoIncidentInvestigation.SelectedIndex = -1;
        txtComments.Text = "";
        drpItemStatus.SelectedIndex = -1;
    }
    public void ClearFields_View()
    {
        lblRoot_Cause_View.Text = "";
        lblPreventedFromHappening_View.Text = "";
        lblConfirmation_Assign_To_View.Text = "";
        lblTargetCompletionDate_View.Text = "";
        lblStatusDueOn_View.Text = "";
        //lblComments_View.Text = "";
        lblItemStatus.Text ="";
    }
    public void SetPanel()
    {
        if (Incident_ReviewType == "WC")
        {
            FillWC_FR_Grid(false);
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(8);", true);
        }
       
    }
    public void SaveIncidentInformation()
    {
        SLT_Incident_Review objSLT_Incident_Review = new SLT_Incident_Review();
        objSLT_Incident_Review.PK_SLT_Incident_Review = FK_SLT_Incident_Review;
        objSLT_Incident_Review.FK_SLT_Meeting = FK_SLT_Meeting;
        objSLT_Incident_Review.FK_WC_FR_ID = PK_WC_FR_ID;
        objSLT_Incident_Review.FK_AL_FR_ID = PK_AL_FR_ID;
        objSLT_Incident_Review.FK_PL_FR_ID = PK_PL_FR_ID;
        objSLT_Incident_Review.FK_DPD_FR_ID = PK_DPD_FR_ID;
        objSLT_Incident_Review.FK_Property_FR_ID = PK_Property_FR_ID;
        objSLT_Incident_Review.FK_Investigation_ID = PK_Investigation_ID;
        objSLT_Incident_Review.FK_LU_Incident_Type = FK_LU_Incident_Type;
        objSLT_Incident_Review.Root_Cause = txtrootcause.Text.Trim();
        objSLT_Incident_Review.SLT_Agree_Root_Cause = rdoRoot_Cause.SelectedValue;
        objSLT_Incident_Review.Conclusions = txtPreventedFromHappening.Text.Trim();
        objSLT_Incident_Review.Confirmation_Assigned_To = txtConfirmation_Assign_To.Text.Trim();
        if (txtTargetDateCompletion.Text.Trim() != "") { objSLT_Incident_Review.Target_Comp_Date = Convert.ToDateTime(txtTargetDateCompletion.Text.Trim()); }
        if (txtStatusDueOn.Text.Trim() != "") { objSLT_Incident_Review.Status_Due_On = Convert.ToDateTime(txtStatusDueOn.Text.Trim()); }
        if (rdoIncidentInvestigation.SelectedIndex > -1) { objSLT_Incident_Review.Incident_Investigation = rdoIncidentInvestigation.SelectedValue; }
        if (txtDateReviewed.Text.Trim() != "") { objSLT_Incident_Review.DateReviewed = Convert.ToDateTime(txtDateReviewed.Text.Trim()); }
        objSLT_Incident_Review.Comments = txtComments.Text.Trim();
        if (drpItemStatus.SelectedIndex > 0) { objSLT_Incident_Review.FK_LU_Item_Status = Convert.ToDecimal(drpItemStatus.SelectedValue); }
        objSLT_Incident_Review.Updated_By = clsSession.UserID;
        objSLT_Incident_Review.Update_Date = DateTime.Now;
        if (FK_SLT_Incident_Review > 0)
            objSLT_Incident_Review.Update();
        else
            objSLT_Incident_Review.Insert();
        // call the IncidentReview event. to bind the grid
        if (BindIncidentReviewGrid != null)
            BindIncidentReviewGrid();
        ClearFields_Edit();
        FillWC_FR_Grid(false);
    }

    public void ShowHideRow()
    {
        if (StrOperation == "view")
        {
            if (lblSLT_Agree_Root_Cause.Text == "No")
                trIncident_Review_View.Visible = true;
            else
                trIncident_Review_View.Visible = trIncident_Review_Edit.Visible = false;//false than validation switch case change
        }
        else
        {
            if (rdoRoot_Cause.SelectedValue == "N")
                trIncident_Review_Edit.Visible = true;
            else
                trIncident_Review_Edit.Visible = false;//false than validation switch case change
            
            Apply_Validation_Group("VSGroup_WC", 182, "[Investigations]");
        }

        
    }

    #endregion

    #region Control Events
    /// <summary>
    /// Handles Selected Index Change
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ddlYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        Year = ddlYear.SelectedValue;
        Month = ddlMonth.SelectedValue;
        SetPanel();
    }
    /// <summary>
    /// Handles Selected Index Change
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ddlMonth_SelectedIndexChanged(object sender, EventArgs e)
    {
        Year = ddlYear.SelectedValue;
        Month = ddlMonth.SelectedValue;
        SetPanel();
    }
    /// <summary>
    /// Handles Click Event
    /// Save Records in SLT_Incident_Review
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSaveNext_Click(object sender, EventArgs e)
    {
        SLT_Meeting_Schedule objSLT_Meeting_Schedule = new SLT_Meeting_Schedule(FK_SLT_Meeting_Schedule);
        if (objSLT_Meeting_Schedule.FK_LU_Meeting_Quality != null)
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:alert('You cannot edit data once slt meeting is reviewed by RLCM.');ShowPanel(8);", true);
        }
        else
        {
            SaveIncidentInformation();
            if (Incident_ReviewType == "WC")
            {
                    FillWC_FR();
                    ShowHideRow();
                if (UpdateSLTScore != null)
                    UpdateSLTScore();
                Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(8);", true);
            }
        }
    }

    protected void rdoRoot_Cause_SelectedIndexChanged(object sender, EventArgs e)
    {
        ShowHideRow();

        Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(8);", true);
    }

    protected void btnSavennextHide_Click(object sender, EventArgs e)
    {
        if ((Incident_ReviewType == "WC" && PK_WC_FR_ID > 0) || (Incident_ReviewType == "AL" && PK_AL_FR_ID > 0) || (Incident_ReviewType == "PL" && PK_PL_FR_ID > 0) || (Incident_ReviewType == "DPD" && PK_DPD_FR_ID > 0) || (Incident_ReviewType == "PROPERTY" && PK_Property_FR_ID > 0))
        {
            SaveIncidentInformation();

            if (Incident_ReviewType == "WC")
            {
                FillWC_FR();
                ShowHideRow();
                if (UpdateSLTScore != null)
                    UpdateSLTScore();
                Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(9);", true);
            }
        }
        else
        {
            if (Incident_ReviewType == "WC")
                Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(9);", true);
        }
    }
    ///// <summary>
    ///// View Audit Trail
    ///// </summary>
    ///// <param name="sender"></param>
    ///// <param name="e"></param>
    //protected void btnAuditTrail_Edit_Click(object sender, EventArgs e)
    //{
        
    //}
    #endregion

    #region Grid Events
    #region WC Grid Events
    /// <summary>
    /// Handleds Row command
    /// Populate data for selected wc_fr from Wc_fr Grid
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvWc_fr_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "ViewDetails")
        {
            PK_WC_FR_ID = Convert.ToDecimal(e.CommandArgument.ToString());
            FillWC_FR();
            trWC_Fr.Visible = true;
            btnSaveNext.Enabled = true;
            //btnAuditTrail_Edit.Visible = true;
            ShowHideRow();
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(8);", true);
        }
    }
    /// <summary>
    /// Handles Page Index Changing for Wc_Fr GRid
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvWc_fr_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvWc_fr.PageIndex = e.NewPageIndex;
        FillWC_FR_Grid(true);
        Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(8);", true);
    }
    #endregion
    
    #endregion



}