using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using ERIMS.DAL;
using Winnovative.WnvHtmlConvert;
using System.IO;

/// <summary>
/// Date : 30 SEP 2008
/// 
/// By : Hetal Prajapati
/// 
/// Purpose: 
/// To Add, update and remove the Investigation information
/// 
/// Functionality:
/// Lists the investigation records having the location selected
/// 
/// By selecting the record the page controls display information about that either in
/// edit or view mode depending on the operation passed in querystring
/// 
/// Save & View button click shows the information in view mode
/// 
/// Back button click opens the page in edit mode
/// </summary>
public partial class Exposures_Investigation : clsBasePage
{
    #region "Variables"

    private string[] strCauseBahaviour = { " 1. Operating equipment without authority"," 2. Failure to warn"," 3. Failure to secure"," 4. Operating at improper speed",
                                                 " 5. Making safety devices inoperative"," 6. Using defective equipment"," 7. Failure to use Personal Protective Equipment(PPE) Properly",
                                                 " 8. Improper loading"," 9. Improper placement"," 10. Improper lifting"," 11. Improper position for task"," 12. Servicing equipment in operation",
                                                 " 13. Horse Play"," 14. Under the influence of alcohol and/or other drugs"," 15. Using equipment improperly"," 16. Failure to follow procedure",
                                                 " 17. Failure to identify hazard/risk"," 18. Failure to check/monitor"," 19. Failure to react/correct"," 20. Failure to communicate/coordinate"
                                               };

    private string[] strCauseConditions = { " 21. Inadequate guards or barriers"," 22. Inadequate or improper protective equipment"," 23. Defective tools, equipment or materials",
                                            " 24. Congestion or restricted action"," 25. Inadequate warning system"," 26. Fire and explosion hazards"," 27. Poor housekeeping/disorder",
                                            " 28. Noise exposure"," 29. Radiation exposure"," 30. Temperature extremes"," 31. Inadequate or excessive illumination"," 32. Inadequate ventilation",
                                            " 33. Presences of harmful materials"," 34. Inadequate instructions/procedures"," 35. Inadequate information/data"," 36. Inadequate preparation/planning",
                                            " 37. Inadequate support/assistance"," 38. Inadequate communication hardware/software/process"," 39. Road conditions"," 40. Weather conditions",
                                            " 41. Mind off task"," 42. Other - Describe"
                                          };

    private string[] strPersonalFactors = { " 1. Inadequate physical capability", " 2. Inadequate Mental/Psych. capability", " 3. Physical/Physiological stress",
                                            " 4. Mental/Physiological stress"," 5. Lack of knowledge"," 6. Lack of training/skill"," 7. Improper motivation "," 8. Abuse or misuse"};

    private string[] strJobFactors = {" 9. Inadequate leader/supervision"," 10. Inadequate engineering"," 11. Inadequate purchasing"," 12. Inadequate maintenance",
                                      " 13. Inadequate tools/equipment"," 14. Inadequate work standard"," 15. Excessive wear/tear"," 16. Inadequate communications",
                                      " 17. Inadequate controls"," 18. Poor housekeeping"," 19. Other-Describe"};

    #endregion

    #region "Properties"

    /// <summary>
    /// Denotes primary key for Investigation record
    /// </summary>
    public int PK_Investigation_ID
    {
        get { return Convert.ToInt32(ViewState["PK_Investigation_ID"]); }
        set { ViewState["PK_Investigation_ID"] = value; }
    }

    /// <summary>
    /// Denotes FK for Location 
    /// </summary>
    public decimal FK_LU_Location
    {
        get { return Convert.ToInt64(ViewState["FK_LU_Location"]); }
        set { ViewState["FK_LU_Location"] = value; }
    }

    /// <summary>
    /// Denotes FK for WC information
    /// </summary>
    public int FK_WC_FR
    {
        get { return Convert.ToInt32(ViewState["FK_WC_FR"]); }
        set { ViewState["FK_WC_FR"] = value; }
    }

    /// <summary>
    /// Denotes operation either edit or view for page 
    /// </summary>
    public string strOperation
    {
        get { return Convert.ToString(ViewState["strOperation"]); }
        set { ViewState["strOperation"] = value; }
    }

    /// <summary>
    /// Denotes whether logged in user is regional officer or not
    /// </summary>
    public bool bIsUserRLCMOfficer
    {
        get { return Convert.ToBoolean(ViewState["bIsUserRLCMOfficer"]); }
        set { ViewState["bIsUserRLCMOfficer"] = value; }
    }

    /// <summary>
    /// Denotes PK for Focus area.
    /// </summary>
    public int PK_Focus_Area
    {
        get { return Convert.ToInt32(ViewState["PK_Focus_Area"]); }
        set { ViewState["PK_Focus_Area"] = value; }
    }

    #endregion

    #region "Page Events"
    /// <summary>
    /// Handles an event when page is loaded
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        //// Set Tab selection       
        if (Request.QueryString["ClaimReview"] != null && Request.QueryString["ClaimReview"] != string.Empty)
        {
            if (Request.QueryString["ClaimReview"].ToString() == "1")
                btnClaimReview.Visible = true;
            else
                btnClaimReview.Visible = false;
        }
        else
            btnClaimReview.Visible = false;
        CtrlAttachment.btnHandler += new Sonic_Attachment.OnButtonClick(Upload_File);
        CtrlAttachment.FindControl("btnNext").Visible = true;

        //used to check Page Post Back Event
        if (!IsPostBack)
        {
            ScriptManager.RegisterStartupScript(Page, GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(1);", true);

            #region " Set Causes "

            rdbActionPlan.ClearSelection();
            rdbRoot.ClearSelection();
            rdbSLT.ClearSelection();
            rdbSLTVisit.ClearSelection();
            rdbTime.ClearSelection();
            rdbWitness.ClearSelection();

            //edited 3356
            //rptCauseBehavioursEdit.DataSource = strCauseBahaviour;
            //rptCauseBehavioursEdit.DataBind();

            //rptCauseConditionsEdit.DataSource = strCauseConditions;
            //rptCauseConditionsEdit.DataBind();

            //rptPersonalFactorsEdit.DataSource = strPersonalFactors;
            //rptPersonalFactorsEdit.DataBind();

            //rptJobFactorsEdit.DataSource = strJobFactors;
            //rptJobFactorsEdit.DataBind();


            #endregion

            #region " Set PK and FK "
            if (Request.QueryString["wc"] == null && Request.QueryString["id"] == null)
                Response.Redirect("InvestigationSearch.aspx");

            if (Request.QueryString["wc"] != null)
            {
                int WCFR = 0;
                if (int.TryParse(Encryption.Decrypt(Request.QueryString["wc"].ToString()), out WCFR))
                {
                    FK_WC_FR = WCFR;
                }
                else
                    Response.Redirect("WCFirstReport.aspx");
            }

            if (Request.QueryString["id"] != null)
            {
                int PK_inv = 0;
                if (int.TryParse(Encryption.Decrypt(Request.QueryString["id"].ToString()), out PK_inv))
                {
                    PK_Investigation_ID = PK_inv;
                    strOperation = Request.QueryString["op"] != null ? Request.QueryString["op"].ToString() : "view";
                }
                else
                    Response.Redirect("InvestigationSearch.aspx");
            }
            else if (Request.QueryString["id"] == null && FK_WC_FR > 0)
            {
                DataTable dt = Investigation.SelectByWc_FR_ID(FK_WC_FR).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    PK_Investigation_ID = Convert.ToInt32(dt.Rows[0]["PK_Investigation_ID"]);
                }
                if (PK_Investigation_ID > 0)
                    strOperation = "view";
            }
            else
            {
                strOperation = string.Empty;
            }
            #endregion

            Investigation objInvestigation = new Investigation(PK_Investigation_ID);
            LU_Location objLU_Location = new LU_Location(Convert.ToDecimal(objInvestigation.FK_LU_Location_ID));

            bIsUserRLCMOfficer = ((objLU_Location.FK_Employee_Id != null && objLU_Location.FK_Employee_Id == clsSession.CurrentLoginEmployeeId) || IsUserSystemAdmin);

            rblRLCM_Reviewed_and_Approved.Enabled = bIsUserRLCMOfficer;
            ComboHelper.FillOSHA_Incident(new DropDownList[] { ddlClassify_Incident }, true);
            ComboHelper.FillOSHA_Injury(new DropDownList[] { ddlType_of_Injury }, true);

            if (strOperation != string.Empty)
            {
                // check for the operation whether edit or view
                // and bind details accordingly                
                if (strOperation == "edit")
                {
                    // Check if User has right To Add Equipment or View Equipment
                    if (Module_Access_Mode == AccessType.View_Only)
                    {
                        Response.Redirect(AppConfig.SiteURL + "Error.aspx?msg=errAcc", true);
                    }
                    ComboHelper.FillContributing_Factor(new DropDownList[] { drpFk_LU_Contributing_Factor }, true);
                    ComboHelper.FillFocusAreaCauseCode(new DropDownList[] { drpCauseOfIncident }, true);
                    ComboHelper.FillState(new DropDownList[] { ddlFK_State_Facility }, 0, true);
                    //Fill Nature of Injury Dropdown
                    ComboHelper.FillNatureofInjury(new DropDownList[] { ddlFK_Nature_Of_Injury }, 0, true);
                    //Fill Body Part Affected Dropdown
                    ComboHelper.FillBodyPartAffectedByFirstReport(new DropDownList[] { ddlFK_Body_Parts_Affected }, 0, true, "WC%");
                    BindCause_Code_Determination();
                    //bool bLocInfoComplete = objInvestigation.Location_Information_Complete;
                    //bool bIsRegOfficer = new Security(Convert.ToDecimal(clsSession.UserID)).IsRegionalOfficer;
                    //if ((!bIsRegOfficer && bLocInfoComplete) || Module_Access_Mode == AccessType.View_Only)
                    //    Response.Redirect(AppConfig.SiteURL + "Error.aspx?msg=errAcc", true);
                    BindDetailsForEdit();
                }
                else
                {
                    BindDetailsForView();
                }
            }
            else
            {
                // set cancel button visible in add mode 
                btnCancel.Visible = true;

                // Check if User has right To Add or View Investigation
                if (App_Access == AccessType.View_Only)
                {
                    Response.Redirect(AppConfig.SiteURL + "Error.aspx?msg=errAcc", true);
                }
            }

            // Bind WC grid and other WC information
            BindWCInformation();

            // Bind exposure information
            if (FK_LU_Location > 0)
            {
                ucCtrlExposureInfo.PK_LU_Location = FK_LU_Location;
                ucCtrlExposureInfo.PK_Investigation_ID = PK_Investigation_ID;
                ucCtrlExposureInfo.FK_WC_ID = FK_WC_FR;
                ucCtrlExposureInfo.BindExposureInfo();
            }
            else
                ucCtrlExposureInfo.Visible = false;


            if (strOperation != "view")
            {
                SetValidations();
                if (drpFk_LU_Contributing_Factor.SelectedItem.Text == "Other")
                {
                    txtContributingFactor_Other.Enabled = true;
                }
                else
                {
                    txtContributingFactor_Other.Enabled = false;
                }
            }
        }

        if (hdnOSHARecordable.Value.ToLower() == "yes")
        {
            lblOSHARecordable_Fields.Style["display"] = "inline-block";
            ScriptManager.RegisterStartupScript(Page, GetType(), DateTime.Now.ToString() + " ", "javascript:CheckOSHA_Fields_Validation(true);", true);
        }
        else
        {
            lblOSHARecordable_Fields.Style["display"] = "none";
            ScriptManager.RegisterStartupScript(Page, GetType(), DateTime.Now.ToString() + " ", "javascript:CheckOSHA_Fields_Validation(false);", true);
        }

        // javascript validations edited 3356
        //((RadioButtonList)rptCauseConditionsEdit.Items[21].FindControl("rdoValue")).Attributes.Add("onclick", "javascript:checkOtherDesc(this.id)");
        //((RadioButtonList)rptJobFactorsEdit.Items[10].FindControl("rdoValue")).Attributes.Add("onclick", "javascript:checkPersonal_Job_Fectors(this.id)");
    }

    #endregion

    #region "Save"
    /// <summary>
    /// Handles save & next button click in incident basics panel
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnInvestigationSave_Click(object sender, EventArgs e)
    {
        // check if FK is available
        if (FK_WC_FR > 0)
        {
            // decalre object for investigation record
            Investigation objInvestigation = new Investigation(PK_Investigation_ID);

            // set location FK and WC FK 
            objInvestigation.FK_LU_Location_ID = Convert.ToInt32(FK_LU_Location);
            objInvestigation.FK_WC_FR_ID = FK_WC_FR;

            // insert or update the record as per the PK available
            if (PK_Investigation_ID > 0)
                objInvestigation.Update();
            else
                PK_Investigation_ID = objInvestigation.Insert();

            BindDetailsForEdit();
            //Open Next Panel.
            ScriptManager.RegisterClientScriptBlock(Page, GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(2);", true);
        }
        else
        {
            //Open Next Panel.
            ScriptManager.RegisterClientScriptBlock(Page, GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(1);alert('Please select any First Report')", true);
        }

    }

    /// <summary>
    /// Handles Save & Next button click in Causes section
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnCausesSaveContinue_Click(object sender, EventArgs e)
    {
        // check if FK is available or not
        if (FK_WC_FR > 0)
        {
            // declare the object for investigation
            Investigation objInvestigation = new Investigation(PK_Investigation_ID);

            // set the FKs
            objInvestigation.FK_LU_Location_ID = Convert.ToInt32(FK_LU_Location);
            objInvestigation.FK_WC_FR_ID = FK_WC_FR;

            // get values from page controls -- edited 3356
            #region "Causes"
            // objInvestigation.Cause_1 = clsGeneral.FormatYesNoToStore(((RadioButtonList)rptCauseBehavioursEdit.Items[0].FindControl("rdoValue")));
            //objInvestigation.Cause_2 = clsGeneral.FormatYesNoToStore(((RadioButtonList)rptCauseBehavioursEdit.Items[1].FindControl("rdoValue")));
            //objInvestigation.Cause_3 = clsGeneral.FormatYesNoToStore(((RadioButtonList)rptCauseBehavioursEdit.Items[2].FindControl("rdoValue")));
            //objInvestigation.Cause_4 = clsGeneral.FormatYesNoToStore(((RadioButtonList)rptCauseBehavioursEdit.Items[3].FindControl("rdoValue")));
            //objInvestigation.Cause_5 = clsGeneral.FormatYesNoToStore(((RadioButtonList)rptCauseBehavioursEdit.Items[4].FindControl("rdoValue")));
            //objInvestigation.Cause_6 = clsGeneral.FormatYesNoToStore(((RadioButtonList)rptCauseBehavioursEdit.Items[5].FindControl("rdoValue")));
            //objInvestigation.Cause_7 = clsGeneral.FormatYesNoToStore(((RadioButtonList)rptCauseBehavioursEdit.Items[6].FindControl("rdoValue")));
            //objInvestigation.Cause_8 = clsGeneral.FormatYesNoToStore(((RadioButtonList)rptCauseBehavioursEdit.Items[7].FindControl("rdoValue")));
            //objInvestigation.Cause_9 = clsGeneral.FormatYesNoToStore(((RadioButtonList)rptCauseBehavioursEdit.Items[8].FindControl("rdoValue")));
            //objInvestigation.Cause_10 = clsGeneral.FormatYesNoToStore(((RadioButtonList)rptCauseBehavioursEdit.Items[9].FindControl("rdoValue")));
            //objInvestigation.Cause_11 = clsGeneral.FormatYesNoToStore(((RadioButtonList)rptCauseBehavioursEdit.Items[10].FindControl("rdoValue")));
            //objInvestigation.Cause_12 = clsGeneral.FormatYesNoToStore(((RadioButtonList)rptCauseBehavioursEdit.Items[11].FindControl("rdoValue")));
            //objInvestigation.Cause_13 = clsGeneral.FormatYesNoToStore(((RadioButtonList)rptCauseBehavioursEdit.Items[12].FindControl("rdoValue")));
            //objInvestigation.Cause_14 = clsGeneral.FormatYesNoToStore(((RadioButtonList)rptCauseBehavioursEdit.Items[13].FindControl("rdoValue")));
            //objInvestigation.Cause_15 = clsGeneral.FormatYesNoToStore(((RadioButtonList)rptCauseBehavioursEdit.Items[14].FindControl("rdoValue")));
            //objInvestigation.Cause_16 = clsGeneral.FormatYesNoToStore(((RadioButtonList)rptCauseBehavioursEdit.Items[15].FindControl("rdoValue")));
            //objInvestigation.Cause_17 = clsGeneral.FormatYesNoToStore(((RadioButtonList)rptCauseBehavioursEdit.Items[16].FindControl("rdoValue")));
            //objInvestigation.Cause_18 = clsGeneral.FormatYesNoToStore(((RadioButtonList)rptCauseBehavioursEdit.Items[17].FindControl("rdoValue")));
            //objInvestigation.Cause_19 = clsGeneral.FormatYesNoToStore(((RadioButtonList)rptCauseBehavioursEdit.Items[18].FindControl("rdoValue")));
            //objInvestigation.Cause_20 = clsGeneral.FormatYesNoToStore(((RadioButtonList)rptCauseBehavioursEdit.Items[19].FindControl("rdoValue")));

            //objInvestigation.Cause_21 = clsGeneral.FormatYesNoToStore(((RadioButtonList)rptCauseConditionsEdit.Items[0].FindControl("rdoValue")));
            //objInvestigation.Cause_22 = clsGeneral.FormatYesNoToStore(((RadioButtonList)rptCauseConditionsEdit.Items[1].FindControl("rdoValue")));
            //objInvestigation.Cause_23 = clsGeneral.FormatYesNoToStore(((RadioButtonList)rptCauseConditionsEdit.Items[2].FindControl("rdoValue")));
            //objInvestigation.Cause_24 = clsGeneral.FormatYesNoToStore(((RadioButtonList)rptCauseConditionsEdit.Items[3].FindControl("rdoValue")));
            //objInvestigation.Cause_25 = clsGeneral.FormatYesNoToStore(((RadioButtonList)rptCauseConditionsEdit.Items[4].FindControl("rdoValue")));
            //objInvestigation.Cause_26 = clsGeneral.FormatYesNoToStore(((RadioButtonList)rptCauseConditionsEdit.Items[5].FindControl("rdoValue")));
            //objInvestigation.Cause_27 = clsGeneral.FormatYesNoToStore(((RadioButtonList)rptCauseConditionsEdit.Items[6].FindControl("rdoValue")));
            //objInvestigation.Cause_28 = clsGeneral.FormatYesNoToStore(((RadioButtonList)rptCauseConditionsEdit.Items[7].FindControl("rdoValue")));
            //objInvestigation.Cause_29 = clsGeneral.FormatYesNoToStore(((RadioButtonList)rptCauseConditionsEdit.Items[8].FindControl("rdoValue")));
            //objInvestigation.Cause_30 = clsGeneral.FormatYesNoToStore(((RadioButtonList)rptCauseConditionsEdit.Items[9].FindControl("rdoValue")));
            //objInvestigation.Cause_31 = clsGeneral.FormatYesNoToStore(((RadioButtonList)rptCauseConditionsEdit.Items[10].FindControl("rdoValue")));
            //objInvestigation.Cause_32 = clsGeneral.FormatYesNoToStore(((RadioButtonList)rptCauseConditionsEdit.Items[11].FindControl("rdoValue")));
            //objInvestigation.Cause_33 = clsGeneral.FormatYesNoToStore(((RadioButtonList)rptCauseConditionsEdit.Items[12].FindControl("rdoValue")));
            //objInvestigation.Cause_34 = clsGeneral.FormatYesNoToStore(((RadioButtonList)rptCauseConditionsEdit.Items[13].FindControl("rdoValue")));
            //objInvestigation.Cause_35 = clsGeneral.FormatYesNoToStore(((RadioButtonList)rptCauseConditionsEdit.Items[14].FindControl("rdoValue")));
            //objInvestigation.Cause_36 = clsGeneral.FormatYesNoToStore(((RadioButtonList)rptCauseConditionsEdit.Items[15].FindControl("rdoValue")));
            //objInvestigation.Cause_37 = clsGeneral.FormatYesNoToStore(((RadioButtonList)rptCauseConditionsEdit.Items[16].FindControl("rdoValue")));
            //objInvestigation.Cause_38 = clsGeneral.FormatYesNoToStore(((RadioButtonList)rptCauseConditionsEdit.Items[17].FindControl("rdoValue")));
            //objInvestigation.Cause_39 = clsGeneral.FormatYesNoToStore(((RadioButtonList)rptCauseConditionsEdit.Items[18].FindControl("rdoValue")));
            //objInvestigation.Cause_40 = clsGeneral.FormatYesNoToStore(((RadioButtonList)rptCauseConditionsEdit.Items[19].FindControl("rdoValue")));
            //objInvestigation.Cause_41 = clsGeneral.FormatYesNoToStore(((RadioButtonList)rptCauseConditionsEdit.Items[20].FindControl("rdoValue")));
            //objInvestigation.Cause_42 = clsGeneral.FormatYesNoToStore(((RadioButtonList)rptCauseConditionsEdit.Items[21].FindControl("rdoValue")));
            //objInvestigation.Cause_42_detail = (objInvestigation.Cause_42 == true) ? txtCause_42_detail.Text.Trim() : string.Empty;
            #endregion
            hdnFocusArea.Value = objInvestigation.Focus_Area;
            objInvestigation.Cause_Comment = txtCause_Comment.Text.Trim();
            if (drpFk_LU_Contributing_Factor.SelectedIndex > 0) { objInvestigation.FK_LU_Contributing_Factor = Convert.ToDecimal(drpFk_LU_Contributing_Factor.SelectedValue); }

            if (txtContributingFactor_Other.Text != "") objInvestigation.Contributing_Factor_Other = txtContributingFactor_Other.Text.Trim();
            else
                objInvestigation.Contributing_Factor_Other = txtContributingFactor_Other.Text = "";

            objInvestigation.Focus_Area = drpCauseOfIncident.SelectedIndex > 0 ? drpCauseOfIncident.SelectedItem.Text : string.Empty;
            #region "Personal / Job Factors" edited 3356
            //objInvestigation.Personal_Job_Factors_1 = clsGeneral.FormatYesNoToStore(((RadioButtonList)rptPersonalFactorsEdit.Items[0].FindControl("rdoValue")));
            //objInvestigation.Personal_Job_Factors_2 = clsGeneral.FormatYesNoToStore(((RadioButtonList)rptPersonalFactorsEdit.Items[1].FindControl("rdoValue")));
            //objInvestigation.Personal_Job_Factors_3 = clsGeneral.FormatYesNoToStore(((RadioButtonList)rptPersonalFactorsEdit.Items[2].FindControl("rdoValue")));
            //objInvestigation.Personal_Job_Factors_4 = clsGeneral.FormatYesNoToStore(((RadioButtonList)rptPersonalFactorsEdit.Items[3].FindControl("rdoValue")));
            //objInvestigation.Personal_Job_Factors_5 = clsGeneral.FormatYesNoToStore(((RadioButtonList)rptPersonalFactorsEdit.Items[4].FindControl("rdoValue")));
            //objInvestigation.Personal_Job_Factors_6 = clsGeneral.FormatYesNoToStore(((RadioButtonList)rptPersonalFactorsEdit.Items[5].FindControl("rdoValue")));
            //objInvestigation.Personal_Job_Factors_7 = clsGeneral.FormatYesNoToStore(((RadioButtonList)rptPersonalFactorsEdit.Items[6].FindControl("rdoValue")));
            //objInvestigation.Personal_Job_Factors_8 = clsGeneral.FormatYesNoToStore(((RadioButtonList)rptPersonalFactorsEdit.Items[7].FindControl("rdoValue")));

            //objInvestigation.Personal_Job_Factors_9 = clsGeneral.FormatYesNoToStore(((RadioButtonList)rptJobFactorsEdit.Items[0].FindControl("rdoValue")));
            //objInvestigation.Personal_Job_Factors_10 = clsGeneral.FormatYesNoToStore(((RadioButtonList)rptJobFactorsEdit.Items[1].FindControl("rdoValue")));
            //objInvestigation.Personal_Job_Factors_11 = clsGeneral.FormatYesNoToStore(((RadioButtonList)rptJobFactorsEdit.Items[2].FindControl("rdoValue")));
            //objInvestigation.Personal_Job_Factors_12 = clsGeneral.FormatYesNoToStore(((RadioButtonList)rptJobFactorsEdit.Items[3].FindControl("rdoValue")));
            //objInvestigation.Personal_Job_Factors_13 = clsGeneral.FormatYesNoToStore(((RadioButtonList)rptJobFactorsEdit.Items[4].FindControl("rdoValue")));
            //objInvestigation.Personal_Job_Factors_14 = clsGeneral.FormatYesNoToStore(((RadioButtonList)rptJobFactorsEdit.Items[5].FindControl("rdoValue")));
            //objInvestigation.Personal_Job_Factors_15 = clsGeneral.FormatYesNoToStore(((RadioButtonList)rptJobFactorsEdit.Items[6].FindControl("rdoValue")));
            //objInvestigation.Personal_Job_Factors_16 = clsGeneral.FormatYesNoToStore(((RadioButtonList)rptJobFactorsEdit.Items[7].FindControl("rdoValue")));
            //objInvestigation.Personal_Job_Factors_17 = clsGeneral.FormatYesNoToStore(((RadioButtonList)rptJobFactorsEdit.Items[8].FindControl("rdoValue")));
            //objInvestigation.Personal_Job_Factors_18 = clsGeneral.FormatYesNoToStore(((RadioButtonList)rptJobFactorsEdit.Items[9].FindControl("rdoValue")));
            //objInvestigation.Personal_Job_Factors_19 = clsGeneral.FormatYesNoToStore(((RadioButtonList)rptJobFactorsEdit.Items[10].FindControl("rdoValue")));


            //objInvestigation.Personal_Job_Factors_17_Details = objInvestigation.Personal_Job_Factors_19 == true ? txtPersonal_Job_Factors_19_Detail.Text.Trim() : string.Empty;
            //objInvestigation.Personal_Job_Comment = txtPersonal_Job_Comment.Text.Trim();
            //objInvestigation.Conclusions = txtConclusions.Text.Trim();
            //lblOSHARecordable.Text = hdnOSHARecordable.Value;

            //if (lblOSHARecordable.Text != "")
            //{
            //    objInvestigation.OSHA_Recordable = lblOSHARecordable.Text == "Yes" ? true : false;
            //}

            //objInvestigation.Original_Sonic_S0_Cause_Code = txtOriginalSonicCode.Text.Trim();
            //objInvestigation.Sonic_S0_Cause_Code_Promoted = rdoSonicCodePromoted.SelectedValue;
            //objInvestigation.Date_Sonic_S0_Cause_Code_Promoted = clsGeneral.FormatNullDateToStore(txtDateSonicCodePromoted.Text);

            //objInvestigation.Sonic_Cause_Code = ddlSonic_Cause_Code.SelectedIndex > 0 ? ddlSonic_Cause_Code.SelectedItem.Text : string.Empty;

            //if (hdnOriginalSonicCode.Value != "")
            //{
            //    if (hdnOriginalSonicCode.Value.IndexOf("S0") > -1 && ddlSonic_Cause_Code.SelectedItem.Text.IndexOf("S0") == -1 && hdnOriginalSonicCode.Value != ddlSonic_Cause_Code.SelectedItem.Text)
            //    {
            //        objInvestigation.Original_Sonic_S0_Cause_Code = hdnOriginalSonicCode.Value;
            //        objInvestigation.Sonic_S0_Cause_Code_Promoted = "Y";
            //        objInvestigation.Date_Sonic_S0_Cause_Code_Promoted = DateTime.Now;

            //        txtOriginalSonicCode.Text = hdnOriginalSonicCode.Value;
            //        rdoSonicCodePromoted.SelectedValue = "Y";
            //        txtDateSonicCodePromoted.Text = DateTime.Today.ToString("MM/dd/yyyy");

            //    }
            //}
            #endregion
            hdnOriginalSonicCode.Value = ddlSonic_Cause_Code.SelectedItem.Text;
            PK_Focus_Area = clsGeneral.GetInt(drpCauseOfIncident.SelectedValue);

            //if drpCauseOfIncident is changed from old value than Sonic_Cause_Code is set to empty.
            if ((hdnFocusArea.Value.ToString() != drpCauseOfIncident.SelectedItem.Text) && (!string.IsNullOrEmpty(hdnFocusArea.Value) || Convert.ToInt32(drpCauseOfIncident.SelectedValue) == 0))
            {
                objInvestigation.Sonic_Cause_Code = string.Empty;
            }


            // insert or update the Investigation record as per the PK available
            if (PK_Investigation_ID > 0)
                objInvestigation.Update();
            else
                PK_Investigation_ID = objInvestigation.Insert();

            //delete old cause determination data
            if ((hdnFocusArea.Value.ToString() != drpCauseOfIncident.SelectedItem.Text) && (!string.IsNullOrEmpty(hdnFocusArea.Value) || Convert.ToInt32(drpCauseOfIncident.SelectedValue) == 0))
            {
                clsInvestigation_Cause_Information.DeleteByInvestigationID(Convert.ToDecimal(PK_Investigation_ID));
            }


            BindDetailsForEdit();

            //if drpCauseOfIncident is changed from old value.
            if ((hdnFocusArea.Value.ToString() != drpCauseOfIncident.SelectedItem.Text))
            {
                #region ::ReBind sonic cause code drop down by cause of incident::

                BindCause_Code_Determination();

                if (PK_Focus_Area > 0)
                {
                    for (int i = ddlSonic_Cause_Code.Items.Count - 1; i > 0; i--)
                    {
                        if (ddlSonic_Cause_Code.Items[i].Value.Contains("S0-" + PK_Focus_Area + " -") || ddlSonic_Cause_Code.Items[i].Value.Contains("S" + PK_Focus_Area + " -") || ddlSonic_Cause_Code.Items[i].Value.Contains("S-" + PK_Focus_Area + ""))
                        {
                            if (ddlSonic_Cause_Code.Items[i].Value.Contains("--SELECT--"))
                            {
                                ddlSonic_Cause_Code.ClearSelection();
                                ddlSonic_Cause_Code.Items[i].Selected = true;
                                //ListItem lst = new ListItem();
                                //lst = ddlSonic_Cause_Code.Items.FindByValue("0");
                                //if (lst != null)
                                //{
                                //    lst.Selected = true;
                                //}
                            }
                        }
                        else
                        {
                            ddlSonic_Cause_Code.Items.RemoveAt(i);
                        }
                    }
                }
                else
                {
                    for (int i = ddlSonic_Cause_Code.Items.Count - 1; i > 0; i--)
                    {
                        ddlSonic_Cause_Code.Items.RemoveAt(i);
                    }

                    ddlSonic_Cause_Code.SelectedIndex = 0;
                }

                #endregion
            }
            //Open Next Panel.
            ScriptManager.RegisterClientScriptBlock(Page, GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(3);", true);
        }
        else
        {
            //Open Next Panel.
            ScriptManager.RegisterClientScriptBlock(Page, GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(2);alert('Please select any First Report')", true);
        }
    }

    /// <summary>
    /// Used to Save Coorective Action Data And Send mail to RLCM
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSave_And_Mail_RLCM_OnClick(object sender, EventArgs e)
    {
        if (FK_WC_FR > 0)
        {
            // create object for investigation
            Investigation objInvestigation = new Investigation(PK_Investigation_ID);

            // get values from page controls
            objInvestigation.FK_LU_Location_ID = Convert.ToInt32(FK_LU_Location);
            objInvestigation.FK_WC_FR_ID = FK_WC_FR;
            //objInvestigation.Corrective_Action_Description = txtCorrective_Action_Description.Text.Trim();
            objInvestigation.Assigned_To = txtAssigned_To.Text.Trim();
            objInvestigation.AssignedBy = txtAssigned_By.Text.Trim();
            objInvestigation.To_Be_Competed_by = clsGeneral.FormatDateToStore(txtTo_Be_Competed_by);
            objInvestigation.Status = ddlStatus.SelectedIndex > 0 ? ddlStatus.SelectedItem.Text : string.Empty;
            objInvestigation.Lessons_Learned = txtLessons_Learned.Text.Trim();
            objInvestigation.Communicated = rdoCommunicated.SelectedValue;

            objInvestigation.Date_Communicated = clsGeneral.FormatNullDateToStore(txtDateCommunicated.Text);

            objInvestigation.No_Communication_Explanation = txtNo_Communication_Explanation.Text.Trim();



            // insert or update the investigation record as per the PK available
            if (PK_Investigation_ID > 0)
                objInvestigation.Update();
            else
                PK_Investigation_ID = objInvestigation.Insert();

            BindDetailsForEdit();

            //Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(5);", true);
            ScriptManager.RegisterClientScriptBlock(Page, GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(4);", true);
        }
        else
        {
            //Open Next Panel.
            ScriptManager.RegisterClientScriptBlock(Page, GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(3);alert('Please select any First Report')", true);
        }
    }

    /// <summary>
    /// Handles Save & Next button click in WC OSHA section
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnWC_OSHA_Click(object sender, EventArgs e)
    {
        // check if FK is available or not
        if (FK_WC_FR > 0)
        {
            // declare the object for investigation
            Investigation objInvestigation = new Investigation(PK_Investigation_ID);

            objInvestigation.Physician_Other_Professional = txtPhysician_Other_Professional.Text.Trim();
            objInvestigation.Facility = txtFacility.Text.Trim();
            objInvestigation.Facility_Address = txtFacility_Address.Text.Trim();
            objInvestigation.Facility_City = txtFacility_City.Text.Trim();
            objInvestigation.FK_State_Facility = (ddlFK_State_Facility.SelectedIndex > 0) ? Convert.ToDecimal(ddlFK_State_Facility.SelectedValue) : 0;
            objInvestigation.Facility_Zip_Code = txtFacility_Zip_Code.Text;
            objInvestigation.Emergency_Room = rblEmergency_Room.SelectedValue;
            objInvestigation.Time_Began_Work = txtTime_Began_Work.Text;
            objInvestigation.Activity_Before_Incident = txtActivity_Before_Incident.Text.Trim();
            objInvestigation.Object_Substance_Involved = txtObject_Substance_Involved.Text.Trim();
            objInvestigation.Return_To_Work_Date = clsGeneral.FormatDateToStore(txtReturnToWorkDate);
            //use to check selected value if it is "-1" than value set to null.
            if (rdoAdmitted_to_Hospital.SelectedValue != "-1")
            {
                //use to check selected value if it is "Y" than set true else false
                if (rdoAdmitted_to_Hospital.SelectedValue == "Y")
                {
                    objInvestigation.Admitted_to_Hospital = true;
                }
                else
                {
                    objInvestigation.Admitted_to_Hospital = false;
                }
            }
            else
                objInvestigation.Admitted_to_Hospital = null;

            // insert or update the Investigation record as per the PK available
            if (PK_Investigation_ID > 0)
                objInvestigation.Update();
            else
                PK_Investigation_ID = objInvestigation.Insert();

            //BindDetailsForEdit();
            //Open Next Panel.
            //ScriptManager.RegisterClientScriptBlock(Page, GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(6);", true);
            // Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(6);", true);

            string Email = "";
            WC_FR objWCFR = new WC_FR(FK_WC_FR);
            LU_Location objLocation = new LU_Location(FK_LU_Location);
            if (objLocation.FK_Employee_Id != null)
            {
                DataTable dtEmail = Security.GetSecurityByEmployee_ID(Convert.ToDecimal(objLocation.FK_Employee_Id)).Tables[0];
                if (dtEmail.Rows.Count > 0)
                {
                    Email = dtEmail.Rows[0]["Email"] != DBNull.Value ? dtEmail.Rows[0]["Email"].ToString() : "";
                }
                if (!String.IsNullOrEmpty(Email))
                {
                    string strBody = GenerateInvestigatorReportBody();
                    string strTo = Email;
                    string strSubject = "Location " + objLocation.Sonic_Location_Code + " - " + objLocation.dba + " has completed the Investigation associated with WC-" + objWCFR.WC_FR_Number;

                    clsGeneral.SendMailMessage(AppConfig.MailFrom, strTo, string.Empty, string.Empty, strSubject, strBody.ToString(), true);
                    ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "", "alert('Mail sent successfully');", true);
                    //Open Next Panel.
                    if (Request.QueryString["isStatus"] == null)
                        Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(6);", true);
                    else
                        Response.Redirect("FirstReportStatus.aspx", true);
                }

                BindDetailsForEdit();
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "No RLCM", "alert('No RLCM exist for the Location " + objLocation.dba + ".');", true);
                Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(5);", true);
            }
        }
        else
        {
            //Open Next Panel.
            ScriptManager.RegisterClientScriptBlock(Page, GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(5);alert('Please select any First Report')", true);
        }
    }


    /// <summary>
    /// Handles Save & View button click in Review Panel
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnReviewSave_Click(object sender, EventArgs e)
    {
        // check if FK is available or not
        if (FK_WC_FR > 0)
        {
            // create object for investigation record
            Investigation objInvestigation = new Investigation(PK_Investigation_ID);

            // get values from page controls
            objInvestigation.FK_LU_Location_ID = Convert.ToInt32(FK_LU_Location);
            objInvestigation.FK_WC_FR_ID = FK_WC_FR;
            objInvestigation.Cause_Reviewed = clsGeneral.FormatDateToStore(txtCause_Reviewed);
            objInvestigation.Action_Reviewed = clsGeneral.FormatDateToStore(txtAction_Reviewed);
            objInvestigation.RLCM_Complete = chkRLCMComplete.Checked;
            objInvestigation.RLCM_Comments = txtRLCMComments.Text.Trim();
            objInvestigation.Date_RLCM_Review_Completed = clsGeneral.FormatNullDateToStore(txtDateReviewCompletedByRLCM.Text);
            if (drpInvestigative.SelectedIndex > 0) objInvestigation.Investigative_Quality = drpInvestigative.SelectedValue;

            objInvestigation.Timing = rdbTime.SelectedValue;
            objInvestigation.Timing_Comment = CtrlMultiLineTiming.Text;

            objInvestigation.SLT_Involvement = rdbSLT.SelectedValue;
            objInvestigation.SLT_Involvement_Comment = CtrlMultiLineSLT.Text;

            objInvestigation.Witnesses = rdbWitness.SelectedValue;
            objInvestigation.Witnesses_Comment = CtrlMultiLineWitness.Text;

            objInvestigation.SLT_Visit = rdbSLTVisit.SelectedValue;
            objInvestigation.SLT_Visit_Comment = CtrlMultiLineSLTVisit.Text;

            objInvestigation.Root_Causes = rdbRoot.SelectedValue;
            objInvestigation.Root_Causes_Comment = CtrlMultiLineRoot.Text;

            objInvestigation.Action_Plan = rdbActionPlan.SelectedValue;
            objInvestigation.Action_Plan_Comment = CtrlMultiLineActionPlan.Text;

            // insert or update the investigation record as per the PK available
            if (PK_Investigation_ID > 0)
                objInvestigation.Update();
            else
                PK_Investigation_ID = objInvestigation.Insert();

            ////// redirect to the same page to be opened in view mode          
            string str = Request.QueryString["fsearch"] != null ? "&fsearch=1" : "";
            if (Request.QueryString["search"] != null)
                // redirect to the same page to be opened in edit mode
                Response.Redirect("Investigation.aspx?id=" + Encryption.Encrypt(PK_Investigation_ID.ToString()) + "&wc=" + Encryption.Encrypt(FK_WC_FR.ToString()) + "&op=view&search=1" + str);
            else
                Response.Redirect("Investigation.aspx?id=" + Encryption.Encrypt(PK_Investigation_ID.ToString()) + "&wc=" + Encryption.Encrypt(FK_WC_FR.ToString()) + "&op=view" + str);
        }
        else
        {
            //Open Next Panel.
            ScriptManager.RegisterClientScriptBlock(Page, GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(5);alert('Please select any First Report')", true);
        }
    }

    /// <summary>
    /// Handles Save Review button's Click event and keep user to current menu
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSaveReview_OnClick(object sender, EventArgs e)
    {
        if (FK_WC_FR > 0)
        {
            // create object for investigation record
            Investigation objInvestigation = new Investigation(PK_Investigation_ID);

            // get values from page controls
            objInvestigation.FK_LU_Location_ID = Convert.ToInt32(FK_LU_Location);
            objInvestigation.FK_WC_FR_ID = FK_WC_FR;
            objInvestigation.Cause_Reviewed = clsGeneral.FormatDateToStore(txtCause_Reviewed);
            objInvestigation.Action_Reviewed = clsGeneral.FormatDateToStore(txtAction_Reviewed);
            objInvestigation.RLCM_Complete = chkRLCMComplete.Checked;
            objInvestigation.RLCM_Comments = txtRLCMComments.Text.Trim();
            objInvestigation.Date_RLCM_Review_Completed = clsGeneral.FormatNullDateToStore(txtDateReviewCompletedByRLCM.Text);
            if (drpInvestigative.SelectedIndex > 0) objInvestigation.Investigative_Quality = drpInvestigative.SelectedValue;
            else
                objInvestigation.Investigative_Quality = null;

            objInvestigation.Timing = rdbTime.SelectedValue;
            objInvestigation.Timing_Comment = CtrlMultiLineTiming.Text;

            objInvestigation.SLT_Involvement = rdbSLT.SelectedValue;
            objInvestigation.SLT_Involvement_Comment = CtrlMultiLineSLT.Text;

            objInvestigation.SLT_Visit = rdbSLTVisit.SelectedValue;
            objInvestigation.SLT_Visit_Comment = CtrlMultiLineSLTVisit.Text;

            objInvestigation.Witnesses = rdbWitness.SelectedValue;
            objInvestigation.Witnesses_Comment = CtrlMultiLineWitness.Text;

            objInvestigation.Root_Causes = rdbRoot.SelectedValue;
            objInvestigation.Root_Causes_Comment = CtrlMultiLineRoot.Text;

            objInvestigation.Action_Plan = rdbActionPlan.SelectedValue;
            objInvestigation.Action_Plan_Comment = CtrlMultiLineActionPlan.Text;

            // insert or update the investigation record as per the PK available
            if (PK_Investigation_ID > 0)
                objInvestigation.Update();
            else
                PK_Investigation_ID = objInvestigation.Insert();

            if (objInvestigation.Investigative_Quality != null) { btnEMailto_Distribution_List.Visible = true; }
            else
                btnEMailto_Distribution_List.Visible = false;
            BindDetailsForEdit();
        }
    }

    /// <summary>
    /// handles Email to Distribution List Button's Click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnEMailto_Distribution_List_OnClick(object sender, EventArgs e)
    {
        GenerateMail();
        ScriptManager.RegisterClientScriptBlock(Page, GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(6);", true);
    }

    /// <summary>
    /// Handles Back button click when page is in view mode
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnBack_Click(object sender, EventArgs e)
    {
        string str = Request.QueryString["fsearch"] != null ? "&fsearch=1" : "";
        if (Request.QueryString["search"] != null)
            // redirect to the same page to be opened in edit mode
            Response.Redirect("Investigation.aspx?id=" + Encryption.Encrypt(PK_Investigation_ID.ToString()) + "&wc=" + Encryption.Encrypt(FK_WC_FR.ToString()) + "&op=edit&search=1" + str);
        else
            Response.Redirect("Investigation.aspx?id=" + Encryption.Encrypt(PK_Investigation_ID.ToString()) + "&wc=" + Encryption.Encrypt(FK_WC_FR.ToString()) + "&op=edit" + str);
    }

    /// <summary>
    /// Button Click Event-back Button
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["search"] != null)
            //redirect to search result page
            Response.Redirect("InvestigationSearchResult.aspx");
        else if (Request.QueryString["fsearch"] != null)
            //redirect to search result page
            Response.Redirect("FirstReportSearchGrid.aspx");
        else
            Response.Redirect("WCFirstReport.aspx?id=" + Encryption.Encrypt(FK_WC_FR.ToString()));
        //Response.Redirect("FirstReportStatus.aspx", true);
    }

    /// <summary>
    /// Button Click Event-Root Causes Determination SaveContinue Button
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnRootCausesDetermSaveContinue_Click(object sender, EventArgs e)
    {
        if (FK_WC_FR > 0)
        {
            // declare the object for investigation
            Investigation objInvestigation = new Investigation(PK_Investigation_ID);

            // set the FKs
            objInvestigation.FK_LU_Location_ID = Convert.ToInt32(FK_LU_Location);
            objInvestigation.FK_WC_FR_ID = FK_WC_FR;

            //objInvestigation.Original_Sonic_S0_Cause_Code = txtOriginalSonicCode.Text.Trim();
            //objInvestigation.Sonic_S0_Cause_Code_Promoted = rdoSonicCodePromoted.SelectedValue;
            //objInvestigation.Date_Sonic_S0_Cause_Code_Promoted = clsGeneral.FormatNullDateToStore(txtDateSonicCodePromoted.Text);
            //objInvestigation.Sonic_Cause_Code = ddlSonic_Cause_Code.SelectedIndex > 0 ? ddlSonic_Cause_Code.SelectedItem.Text : string.Empty;
            //hdnOriginalSonicCode.Value = ddlSonic_Cause_Code.SelectedItem.Text;

            objInvestigation.Conclusions = txtConclusions.Text.Trim();

            objInvestigation.OSHA_Recordable = Convert.ToString(rdoOSHARecordable.SelectedValue) == "Y" ? true : false;

            lblOSHARecordable.Text = hdnOSHARecordable.Value;
            objInvestigation.Original_Sonic_S0_Cause_Code = txtOriginalSonicCode.Text.Trim();
            objInvestigation.Sonic_S0_Cause_Code_Promoted = rdoSonicCodePromoted.SelectedValue;
            objInvestigation.Date_Sonic_S0_Cause_Code_Promoted = clsGeneral.FormatNullDateToStore(txtDateSonicCodePromoted.Text);

            objInvestigation.Sonic_Cause_Code = ddlSonic_Cause_Code.SelectedIndex > 0 ? ddlSonic_Cause_Code.SelectedItem.Text : string.Empty;

            if (ddlClassify_Incident.SelectedIndex > 0)
            {
                objInvestigation.FK_LU_OSHA_Incident = Convert.ToDecimal(ddlClassify_Incident.SelectedValue);
            }
            else
            {
                objInvestigation.FK_LU_OSHA_Incident = null;
            }

            if (ddlType_of_Injury.SelectedIndex > 0)
            {
                objInvestigation.FK_LU_OSHA_Injury = Convert.ToDecimal(ddlType_of_Injury.SelectedValue);
            }
            else
            {
                objInvestigation.FK_LU_OSHA_Injury = null;
            }

            objInvestigation.RLCM_Review_Approve = Convert.ToString(rblRLCM_Reviewed_and_Approved.SelectedValue);

            if (hdnOriginalSonicCode.Value != "")
            {
                if (hdnOriginalSonicCode.Value.IndexOf("S0") > -1 && ddlSonic_Cause_Code.SelectedItem.Text.IndexOf("S0") == -1 && hdnOriginalSonicCode.Value != ddlSonic_Cause_Code.SelectedItem.Text)
                {
                    objInvestigation.Original_Sonic_S0_Cause_Code = hdnOriginalSonicCode.Value;
                    objInvestigation.Sonic_S0_Cause_Code_Promoted = "Y";
                    objInvestigation.Date_Sonic_S0_Cause_Code_Promoted = DateTime.Now;

                    txtOriginalSonicCode.Text = hdnOriginalSonicCode.Value;
                    rdoSonicCodePromoted.SelectedValue = "Y";
                    txtDateSonicCodePromoted.Text = DateTime.Today.ToString("MM/dd/yyyy");

                }

            }

            // hdnFocusArea.Value = objInvestigation.Focus_Area;
            objInvestigation.Cause_Comment = txtCause_Comment.Text.Trim();
            if (drpFk_LU_Contributing_Factor.SelectedIndex > 0) { objInvestigation.FK_LU_Contributing_Factor = Convert.ToDecimal(drpFk_LU_Contributing_Factor.SelectedValue); }

            if (txtContributingFactor_Other.Text != "") objInvestigation.Contributing_Factor_Other = txtContributingFactor_Other.Text.Trim();
            else
                objInvestigation.Contributing_Factor_Other = txtContributingFactor_Other.Text = "";

            objInvestigation.Focus_Area = drpCauseOfIncident.SelectedIndex > 0 ? drpCauseOfIncident.SelectedItem.Text : string.Empty;

            hdnOriginalSonicCode.Value = ddlSonic_Cause_Code.SelectedItem.Text;
            objInvestigation.Slipping = rdoSlipping.SelectedValue;
            objInvestigation.FK_Nature_of_Injury = Convert.ToDecimal(ddlFK_Nature_Of_Injury.SelectedValue);
            objInvestigation.FK_Body_Parts_Affected = Convert.ToDecimal(ddlFK_Body_Parts_Affected.SelectedValue);

            // insert or update the Investigation record as per the PK available
            if (PK_Investigation_ID > 0)
                objInvestigation.Update();
            else
                PK_Investigation_ID = objInvestigation.Insert();



            //delete old cause determination data
            if ((hdnFocusArea.Value.ToString() != drpCauseOfIncident.SelectedItem.Text) && (!string.IsNullOrEmpty(hdnFocusArea.Value) || Convert.ToInt32(drpCauseOfIncident.SelectedValue) == 0))
            {
                clsInvestigation_Cause_Information.DeleteByInvestigationID(Convert.ToDecimal(PK_Investigation_ID));
            }

            hdnFocusArea.Value = drpCauseOfIncident.SelectedItem.Text;

            if (rptRootCauseDetermination.Items.Count > 0)
            {

                foreach (RepeaterItem item in rptRootCauseDetermination.Items)
                {

                    HiddenField fk_lu_cause_code_info = item.FindControl("hdnFK_LU_Cause_Info") as HiddenField;
                    RadioButtonList rdlResponse = item.FindControl("rdoRootCauseTypeList") as RadioButtonList;
                    RadioButtonList rdlGuidanceReoccurance = rptRootCauseDeterminationRecmndation.Items[item.ItemIndex].FindControl("rdoRootCauseGuidanceList") as RadioButtonList;

                    ASP.controls_noteswithspellcheck_notes_ascx cnt_Note = item.FindControl("txtRoot_Cause_Comments") as ASP.controls_noteswithspellcheck_notes_ascx;
                    TextBox txtRoot_Cause_Comments = cnt_Note.FindControl("txtNote") as TextBox;

                    HiddenField hdnPK_Investigation_Cause_Information = item.FindControl("hdnPK_Investigation_Cause_Information") as HiddenField;
                    clsInvestigation_Cause_Information objInvestigation_Cause_Information = new clsInvestigation_Cause_Information();
                    objInvestigation_Cause_Information.FK_Investigation = PK_Investigation_ID;
                    objInvestigation_Cause_Information.FK_LU_Cause_Code_Information = Convert.ToDecimal(fk_lu_cause_code_info.Value);
                    objInvestigation_Cause_Information.Response = Convert.ToString(rdlResponse.SelectedValue);
                    objInvestigation_Cause_Information.Prevent_Reoccurrence = Convert.ToString(rdlGuidanceReoccurance.SelectedValue);
                    objInvestigation_Cause_Information.Updated_By = clsSession.UserName;
                    objInvestigation_Cause_Information.Update_Date = DateTime.Now;
                    objInvestigation_Cause_Information.PK_Investigation_Cause_Information = Convert.ToDecimal(hdnPK_Investigation_Cause_Information.Value);
                    objInvestigation_Cause_Information.Comments = Convert.ToString(txtRoot_Cause_Comments.Text);

                    if (objInvestigation_Cause_Information.PK_Investigation_Cause_Information > 0)
                    {
                        objInvestigation_Cause_Information.Update();
                    }
                    else
                    {
                        int pk_Investigation_Cause_Information = objInvestigation_Cause_Information.Insert();
                    }
                }
            }


            BindDetailsForEdit();
            //Open Next Panel.
            ScriptManager.RegisterClientScriptBlock(Page, GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(3);DisableEnableOsha();", true);
        }
        else
        {
            //Open Next Panel.
            ScriptManager.RegisterClientScriptBlock(Page, GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(2);alert('Please select any First Report')", true);
        }
    }

    #endregion

    #region "Other Methods"

    /// <summary>
    /// Binds basic WC information
    /// </summary>
    private void BindWCInformation()
    {
        // select data for WC_FR_ID
        DataTable dtWc = Investigation.GetWCInformation(Convert.ToDecimal(FK_WC_FR)).Tables[0];
        // check if data available
        if (dtWc.Rows.Count > 0)
        {
            DataRow drWC = dtWc.Rows[0];
            FK_LU_Location = Convert.ToInt64(drWC["FK_LU_Location"]);
            // set values in page controls
            lblLocationdbaEdit.Text = drWC["dba"].ToString();
            lblRM_Location_NumberEdit.Text = drWC["RM_Location_Number"].ToString();
            lblDate_Of_IncidentEdit.Text = !string.IsNullOrEmpty(Convert.ToString(drWC["Date_Of_Incident"])) ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drWC["Date_Of_Incident"])) : string.Empty;
            lblTime_Of_IncidentEdit.Text = Convert.ToString(drWC["Time_Of_Incident"]);
            lblDepartment_Where_OccurredEdit.Text = drWC["Department"].ToString();
            lblDate_Reported_To_SonicEdit.Text = clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drWC["Date_Reported_To_Sonic"]));
            string strName = "";
            if (drWC["LastName"].ToString() != "")
                strName = drWC["LastName"].ToString().Trim();
            if (drWC["FirstName"].ToString() != "")
                strName = strName == string.Empty ? drWC["FirstName"].ToString() : strName + ", " + drWC["FirstName"].ToString().Trim();
            if (drWC["MiddleName"].ToString() != "")
                strName = strName == string.Empty ? drWC["MiddleName"].ToString() : strName + " " + drWC["MiddleName"].ToString().Trim();

            lblEmployee_NameEdit.Text = strName.Trim();
            lblJob_TitleEdit.Text = drWC["Job_Title"].ToString();
            lblHire_DateEdit.Text = clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drWC["HireDate"]));
            //lblNature_Of_InjuryEdit.Text = drWC["Nature_Of_Injury"].ToString();
            //lblBody_Parts_AffectedEdit.Text = drWC["Body_Parts_Affected"].ToString();
            lblDescription_Of_IncidentEdit.Text = drWC["Description_Of_Incident"].ToString();
            lblSafeguards_ProvidedEdit.Text = (drWC["Safeguards_Provided"] != DBNull.Value) ? (Convert.ToBoolean(drWC["Safeguards_Provided"]) == true ? "Yes" : "No") : "Unknown";
            lblSafeguards_UsedEdit.Text = (drWC["Safeguards_Used"] != DBNull.Value) ? (Convert.ToBoolean(drWC["Safeguards_Used"]) == true ? "Yes" : "No") : "Unknown";
            lblMachine_Part_InvolvedEdit.Text = (drWC["Machine_Part_Involved"] != DBNull.Value) ? (Convert.ToBoolean(drWC["Machine_Part_Involved"]) == true ? "Yes" : "No") : "Unknown";
            lblMachine_Part_DefectiveEdit.Text = (drWC["Machine_Part_Defective"] != DBNull.Value) ? (Convert.ToBoolean(drWC["Machine_Part_Defective"]) == true ? "Yes" : "No") : "Unknown";

        }
    }

    /// <summary>
    /// Binds details for page in view mode
    /// </summary>
    private void BindDetailsForView()
    {
        // create object for investigation
        Investigation objInvestigation = new Investigation(PK_Investigation_ID);
        FK_WC_FR = objInvestigation.FK_WC_FR_ID;
        bool bLocInfoComplete = objInvestigation.Location_Information_Complete;
        //bool bIsRegionalOfficer = new Security(Convert.ToDecimal(clsSession.UserID)).IsRegionalOfficer;

        // set values in page controls
        #region " CAUSES "

        #region "Causes"

        //DataTable dtCauseBehaviour = new DataTable();
        //DataColumn dcCauseBehaviourDesc = new DataColumn("Description", typeof(string));
        //DataColumn dcCauseBehaviourVal = new DataColumn("Value", typeof(object));
        //dtCauseBehaviour.Columns.Add(dcCauseBehaviourDesc);
        //dtCauseBehaviour.Columns.Add(dcCauseBehaviourVal);
        //foreach (string str in strCauseBahaviour)
        //{
        //    DataRow drCauseBehaviour = dtCauseBehaviour.NewRow();
        //    drCauseBehaviour[0] = str;
        //    dtCauseBehaviour.Rows.Add(drCauseBehaviour);
        //}
        //dtCauseBehaviour.Rows[0][1] = objInvestigation.Cause_1;
        //dtCauseBehaviour.Rows[1][1] = objInvestigation.Cause_2;
        //dtCauseBehaviour.Rows[2][1] = objInvestigation.Cause_3;
        //dtCauseBehaviour.Rows[3][1] = objInvestigation.Cause_4;
        //dtCauseBehaviour.Rows[4][1] = objInvestigation.Cause_5;
        //dtCauseBehaviour.Rows[5][1] = objInvestigation.Cause_6;
        //dtCauseBehaviour.Rows[6][1] = objInvestigation.Cause_7;
        //dtCauseBehaviour.Rows[7][1] = objInvestigation.Cause_8;
        //dtCauseBehaviour.Rows[8][1] = objInvestigation.Cause_9;
        //dtCauseBehaviour.Rows[9][1] = objInvestigation.Cause_10;
        //dtCauseBehaviour.Rows[10][1] = objInvestigation.Cause_11;
        //dtCauseBehaviour.Rows[11][1] = objInvestigation.Cause_12;
        //dtCauseBehaviour.Rows[12][1] = objInvestigation.Cause_13;
        //dtCauseBehaviour.Rows[13][1] = objInvestigation.Cause_14;
        //dtCauseBehaviour.Rows[14][1] = objInvestigation.Cause_15;
        //dtCauseBehaviour.Rows[15][1] = objInvestigation.Cause_16;
        //dtCauseBehaviour.Rows[16][1] = objInvestigation.Cause_17;
        //dtCauseBehaviour.Rows[17][1] = objInvestigation.Cause_18;
        //dtCauseBehaviour.Rows[18][1] = objInvestigation.Cause_19;
        //dtCauseBehaviour.Rows[19][1] = objInvestigation.Cause_20;

        //rptCauseBehaviours.DataSource = dtCauseBehaviour;
        //rptCauseBehaviours.DataBind();
        //dtCauseBehaviour.Dispose();

        //DataTable dtCauseConditions = new DataTable();
        //DataColumn dcCauseConditionsDesc = new DataColumn("Description", typeof(string));
        //DataColumn dcCauseConditionsVal = new DataColumn("Value", typeof(object));
        //dtCauseConditions.Columns.Add(dcCauseConditionsDesc);
        //dtCauseConditions.Columns.Add(dcCauseConditionsVal);
        //foreach (string str in strCauseConditions)
        //{
        //    DataRow drCauseConditions = dtCauseConditions.NewRow();
        //    drCauseConditions[0] = str;
        //    dtCauseConditions.Rows.Add(drCauseConditions);
        //}
        //dtCauseConditions.Rows[0][1] = objInvestigation.Cause_21;
        //dtCauseConditions.Rows[1][1] = objInvestigation.Cause_22;
        //dtCauseConditions.Rows[2][1] = objInvestigation.Cause_23;
        //dtCauseConditions.Rows[3][1] = objInvestigation.Cause_24;
        //dtCauseConditions.Rows[4][1] = objInvestigation.Cause_25;
        //dtCauseConditions.Rows[5][1] = objInvestigation.Cause_26;
        //dtCauseConditions.Rows[6][1] = objInvestigation.Cause_27;
        //dtCauseConditions.Rows[7][1] = objInvestigation.Cause_28;
        //dtCauseConditions.Rows[8][1] = objInvestigation.Cause_29;
        //dtCauseConditions.Rows[9][1] = objInvestigation.Cause_30;
        //dtCauseConditions.Rows[10][1] = objInvestigation.Cause_31;
        //dtCauseConditions.Rows[11][1] = objInvestigation.Cause_32;
        //dtCauseConditions.Rows[12][1] = objInvestigation.Cause_33;
        //dtCauseConditions.Rows[13][1] = objInvestigation.Cause_34;
        //dtCauseConditions.Rows[14][1] = objInvestigation.Cause_35;
        //dtCauseConditions.Rows[15][1] = objInvestigation.Cause_36;
        //dtCauseConditions.Rows[16][1] = objInvestigation.Cause_37;
        //dtCauseConditions.Rows[17][1] = objInvestigation.Cause_38;
        //dtCauseConditions.Rows[18][1] = objInvestigation.Cause_39;
        //dtCauseConditions.Rows[19][1] = objInvestigation.Cause_40;
        //dtCauseConditions.Rows[20][1] = objInvestigation.Cause_41;
        //dtCauseConditions.Rows[21][1] = objInvestigation.Cause_42;
        //rptCauseConditions.DataSource = dtCauseConditions;
        //rptCauseConditions.DataBind();
        //dtCauseConditions.Dispose();

        #endregion

        //lblCause_42_detail.Text = (objInvestigation.Cause_42 == true) ? objInvestigation.Cause_42_detail : string.Empty;
        lblCause_Comment.Text = objInvestigation.Cause_Comment;
        if (objInvestigation.FK_LU_Contributing_Factor != null) lblContributingFactor.Text = new clsLU_Contributing_Factor((decimal)objInvestigation.FK_LU_Contributing_Factor).Field_Description;
        if (objInvestigation.Contributing_Factor_Other != "") lblContributingFactor_Other.Text = objInvestigation.Contributing_Factor_Other;
        lblCuase_Of_Incident.Text = objInvestigation.Focus_Area;
        //#region "Personal / Job Factors"

        //DataTable dtPersonalFactors = new DataTable();
        //DataColumn dcPersonalFactorsDesc = new DataColumn("Description", typeof(string));
        //DataColumn dcPersonalFactorsVal = new DataColumn("Value", typeof(object));
        //dtPersonalFactors.Columns.Add(dcPersonalFactorsDesc);
        //dtPersonalFactors.Columns.Add(dcPersonalFactorsVal);
        //foreach (string str in strPersonalFactors)
        //{
        //    DataRow drPersonalFactors = dtPersonalFactors.NewRow();
        //    drPersonalFactors[0] = str;
        //    dtPersonalFactors.Rows.Add(drPersonalFactors);
        //}
        //dtPersonalFactors.Rows[0][1] = objInvestigation.Personal_Job_Factors_1;
        //dtPersonalFactors.Rows[1][1] = objInvestigation.Personal_Job_Factors_2;
        //dtPersonalFactors.Rows[2][1] = objInvestigation.Personal_Job_Factors_3;
        //dtPersonalFactors.Rows[3][1] = objInvestigation.Personal_Job_Factors_4;
        //dtPersonalFactors.Rows[4][1] = objInvestigation.Personal_Job_Factors_5;
        //dtPersonalFactors.Rows[5][1] = objInvestigation.Personal_Job_Factors_6;
        //dtPersonalFactors.Rows[6][1] = objInvestigation.Personal_Job_Factors_7;
        //dtPersonalFactors.Rows[7][1] = objInvestigation.Personal_Job_Factors_8;
        //rptPersonalFactors.DataSource = dtPersonalFactors;
        //rptPersonalFactors.DataBind();
        //dtPersonalFactors.Dispose();

        //DataTable dtJobFactors = new DataTable();
        //DataColumn dcJobFactorsDesc = new DataColumn("Description", typeof(string));
        //DataColumn dcJobFactorsVal = new DataColumn("Value", typeof(object));
        //dtJobFactors.Columns.Add(dcJobFactorsDesc);
        //dtJobFactors.Columns.Add(dcJobFactorsVal);
        //foreach (string str in strJobFactors)
        //{
        //    DataRow drJobFactors = dtJobFactors.NewRow();
        //    drJobFactors[0] = str;
        //    dtJobFactors.Rows.Add(drJobFactors);
        //}
        //dtJobFactors.Rows[0][1] = objInvestigation.Personal_Job_Factors_9;
        //dtJobFactors.Rows[1][1] = objInvestigation.Personal_Job_Factors_10;
        //dtJobFactors.Rows[2][1] = objInvestigation.Personal_Job_Factors_11;
        //dtJobFactors.Rows[3][1] = objInvestigation.Personal_Job_Factors_12;
        //dtJobFactors.Rows[4][1] = objInvestigation.Personal_Job_Factors_13;
        //dtJobFactors.Rows[5][1] = objInvestigation.Personal_Job_Factors_14;
        //dtJobFactors.Rows[6][1] = objInvestigation.Personal_Job_Factors_15;
        //dtJobFactors.Rows[7][1] = objInvestigation.Personal_Job_Factors_16;
        //dtJobFactors.Rows[8][1] = objInvestigation.Personal_Job_Factors_17;
        //dtJobFactors.Rows[9][1] = objInvestigation.Personal_Job_Factors_18;
        //dtJobFactors.Rows[10][1] = objInvestigation.Personal_Job_Factors_19;
        //rptJobFactors.DataSource = dtJobFactors;
        //rptJobFactors.DataBind();
        //dtJobFactors.Dispose();
        //#endregion

        //lblPersonal_Job_Factors_19_Detail.Text = objInvestigation.Personal_Job_Factors_19 == true ? objInvestigation.Personal_Job_Factors_17_Details : string.Empty;
        //lblPersonal_Job_Comment.Text = objInvestigation.Personal_Job_Comment;

        #endregion

        #region Root cause determination

        lblConclusions.Text = objInvestigation.Conclusions;
        if (objInvestigation.OSHA_Recordable != null)
        {
            lblOSHARecordableView.Text = objInvestigation.OSHA_Recordable == true ? "Yes" : "No";
            hdnOSHARecordable.Value = lblOSHARecordableView.Text;
        }
        lblSonic_Cause_Code.Text = objInvestigation.Sonic_Cause_Code;
        lblSlipping.Text = objInvestigation.Slipping == null ? string.Empty : objInvestigation.Slipping == "Y" ? "Yes" : "No";
        lblOriginalSonicCode.Text = objInvestigation.Original_Sonic_S0_Cause_Code;
        lblSonicCodePromoted.Text = objInvestigation.Sonic_S0_Cause_Code_Promoted == "Y" ? "Yes" : "No";
        lblDateSonicCodePromoted.Text = clsGeneral.FormatDBNullDateToDisplay(objInvestigation.Date_Sonic_S0_Cause_Code_Promoted);

        if (objInvestigation.FK_LU_OSHA_Incident != null) lblClassify_Incident.Text = new clsLU_OSHA_Incident(Convert.ToDecimal(objInvestigation.FK_LU_OSHA_Incident)).Description;
        if (objInvestigation.FK_LU_OSHA_Injury != null) lblType_of_Injury.Text = new clsLU_OSHA_Injury(Convert.ToDecimal(objInvestigation.FK_LU_OSHA_Injury)).Description;
        lblRLCM_Reviewed_and_Approved.Text = objInvestigation.RLCM_Review_Approve == "Y" ? "Yes" : "No";

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
            ASP.controls_noteswithspellcheck_notes_ascx cnt_Note = rptRootCauseDeterminationView.Items[i].FindControl("lblRoot_Cause_Comments") as ASP.controls_noteswithspellcheck_notes_ascx;
            TextBox lblRoot_Cause_Comments = cnt_Note.FindControl("txtNote") as TextBox;

            lblRootCauseTypeList.Text = Convert.ToString(dtRootCauseDetermination.Rows[i]["Response"]) == "Y" ? "Yes" : "No";
            lblRoot_Cause_Comments.Text = Convert.ToString(dtRootCauseDetermination.Rows[i]["Comments"]);
        }
        for (int i = 0; i < dtRootCauseDetermination.Rows.Count; i++)
        {
            Label lblRootCauseTypeList = (Label)rptRootCauseDeterminationRecmndationView.Items[i].FindControl("lblRootCauseGuidanceReoccurance");
            lblRootCauseTypeList.Text = Convert.ToString(dtRootCauseDetermination.Rows[i]["Prevent_Reoccurrence"]) == "Y" ? "Yes" : "No";
        }

        lblFK_Nature_Of_Injury.Text = new LU_Nature_of_Injury((objInvestigation.FK_Nature_of_Injury != null) ? Convert.ToDecimal(objInvestigation.FK_Nature_of_Injury) : 0).Description;
        lblFK_Body_Parts_Affected.Text = new LU_Part_Of_Body(objInvestigation.FK_Body_Parts_Affected != null ? Convert.ToDecimal(objInvestigation.FK_Body_Parts_Affected) : 0).Description;

        #endregion

        #region " CORRECTIVE ACTIONS "

        //lblCorrective_Action_Description.Text = objInvestigation.Corrective_Action_Description;
        lblAssigned_To.Text = objInvestigation.Assigned_To;
        lblAssigned_By.Text = objInvestigation.AssignedBy;
        lblTo_Be_Competed_by.Text = clsGeneral.FormatDateToDisplay(objInvestigation.To_Be_Competed_by);
        lblStatus.Text = objInvestigation.Status;
        lblLessons_Learned.Text = objInvestigation.Lessons_Learned;
        lblNoCommunicationExplanation.Text = objInvestigation.No_Communication_Explanation;
        lblDateCommunicated.Text = clsGeneral.FormatDBNullDateToDisplay(objInvestigation.Date_Communicated);
        lblCommunicatedToAssociate.Text = objInvestigation.Communicated == "Y" ? "Yes" : "No";
        //lblDateInvestigation_Submitted_View.Text = clsGeneral.FormatDBNullDateToDisplay(objInvestigation.Date_Submitted_by_Store);
        #endregion

        #region " REVIEW "

        lblCause_Reviewed.Text = clsGeneral.FormatDateToDisplay(objInvestigation.Cause_Reviewed);
        lblAction_Reviewed.Text = clsGeneral.FormatDateToDisplay(objInvestigation.Action_Reviewed);

        lblTiming_View.Text = objInvestigation.Timing != "" ? objInvestigation.Timing == "Y" ? "Yes" : "No" : "";
        CtrlMultiLineTiming_view.Text = objInvestigation.Timing_Comment;

        lblSLT_View.Text = objInvestigation.SLT_Involvement != "" ? objInvestigation.SLT_Involvement == "Y" ? "Yes" : "No" : "";
        CtrlMultiLineSLT_View.Text = objInvestigation.SLT_Involvement_Comment;

        lblSLTVisit_View.Text = objInvestigation.SLT_Visit != "" ? objInvestigation.SLT_Visit == "Y" ? "Yes" : "No" : "";
        CtrlMultiLineSLTVisit_View.Text = objInvestigation.SLT_Visit_Comment;

        lblWitness_View.Text = objInvestigation.Witnesses != "" ? objInvestigation.Witnesses == "Y" ? "Yes" : "No" : "";
        CtrlMultiLineWitness_View.Text = objInvestigation.Witnesses_Comment;

        lblRootCause_View.Text = objInvestigation.Root_Causes != "" ? objInvestigation.Root_Causes == "Y" ? "Yes" : "No" : "";
        CtrlMultiLineRoot_View.Text = objInvestigation.Root_Causes_Comment;

        lblActionPlan_View.Text = objInvestigation.Action_Plan != "" ? objInvestigation.Action_Plan == "Y" ? "Yes" : "No" : "";
        CtrlMultiLineActionPlan_View.Text = objInvestigation.Action_Plan_Comment;

        lblRLCMComplete.Text = objInvestigation.RLCM_Complete ? "Yes" : "No";
        if (!string.IsNullOrEmpty(objInvestigation.Investigative_Quality)) lblInvestigative.Text = objInvestigation.Investigative_Quality;
        lblRLCMComments_view.Text = objInvestigation.RLCM_Comments;
        lblDateReviewCompletedByRLCM.Text = clsGeneral.FormatDBNullDateToDisplay(objInvestigation.Date_RLCM_Review_Completed);
        if (objInvestigation.Lag_Time != null) lblIncidentReviewLagTime_View.Text = objInvestigation.Lag_Time.ToString();
        #endregion

        #region "WC OSHA"

        lblPhysician_Other_Professional.Text = objInvestigation.Physician_Other_Professional;
        lblFacility.Text = objInvestigation.Facility;
        lblFacility_Address.Text = objInvestigation.Facility_Address;
        lblFacility_City.Text = objInvestigation.Facility_City;

        if (objInvestigation.FK_State_Facility > 0)
        {
            lblFK_State_Facility.Text = new State(String.IsNullOrEmpty(Convert.ToString(objInvestigation.FK_State_Facility)) ? 0 : Convert.ToDecimal(objInvestigation.FK_State_Facility)).FLD_state;
        }

        lblFacility_Zip_Code.Text = objInvestigation.Facility_Zip_Code;
        lblEmergency_Room.Text = (objInvestigation.Emergency_Room == "Y") ? "Yes" : "No";
        lblTime_Began_Work.Text = objInvestigation.Time_Began_Work;
        lblActivity_Before_Incident.Text = objInvestigation.Activity_Before_Incident;
        lblObject_Substance_Involved.Text = objInvestigation.Object_Substance_Involved;

        //check object value if it null than display "unknown"
        if (objInvestigation.Admitted_to_Hospital != null)
        {
            //check if object value is true than display "Yes" else display "No"
            if (objInvestigation.Admitted_to_Hospital == true)
                lblAdmitted_to_Hospital.Text = "Yes";
            else
                lblAdmitted_to_Hospital.Text = "No";
        }
        else
            lblAdmitted_to_Hospital.Text = "unknown";

        if (clsGeneral.FormatDBNullDateToDisplay(objInvestigation.Return_To_Work_Date) != string.Empty)
        {
            lblReturntoWorkDate.Text = clsGeneral.FormatDBNullDateToDisplay(objInvestigation.Return_To_Work_Date);
        }
        else
        {
            DataTable dtClaimInfo = WC_ClaimInfo.Select_Claim_Number(Convert.ToInt32(FK_WC_FR), "WC");
            if (dtClaimInfo.Rows.Count > 0)
            {
                DataSet dtClaimDetail = WC_ClaimInfo.SelectByPK(Convert.ToInt32(Convert.ToInt32(dtClaimInfo.Rows[0]["ClaimID"])));
                if (dtClaimDetail.Tables[0].Rows[0]["Date_Return_To_Work"] != null && dtClaimDetail.Tables[0].Rows[0]["Date_Return_To_Work"].ToString() != string.Empty)
                    lblReturntoWorkDate.Text = clsGeneral.FormatDateToDisplay(Convert.ToDateTime(dtClaimDetail.Tables[0].Rows[0]["Date_Return_To_Work"]));
            }
        }

        //lblReturntoWorkDate.Text = clsGeneral.FormatDBNullDateToDisplay(objInvestigation.Return_To_Work_Date);

        #endregion

        if (bIsUserRLCMOfficer)
        {
            btnEMailto_DistributionView.Visible = true;
        }

        // display page in view mode
        dvView.Style["display"] = "block";
        btnInvestigationSave.Visible = false;
        // Check if User has right To Add or Edit 

        CtrlViewAttachDetails.InitializeAttachmentDetails(clsGeneral.Tables.Investigation, PK_Investigation_ID, false, 4);
        CtrlViewAttachDetails.Bind();

        //if ((!bIsRegionalOfficer && bLocInfoComplete) || Module_Access_Mode == AccessType.View_Only)
        //    btnBack.Visible = false;

        if (App_Access == AccessType.View_Only)
            btnBack.Visible = false;
        else
            btnBack.Visible = true;


    }

    /// <summary>
    /// Bind details for page in edit mode
    /// </summary>
    private void BindDetailsForEdit()
    {
        // create object for investigation
        Investigation objInvestigation = new Investigation(PK_Investigation_ID);
        FK_WC_FR = objInvestigation.FK_WC_FR_ID;

        // set values in page controls

        #region " CAUSES "

        #region "Causes"

        //clsGeneral.FormatYesNoToDisplayForEdit((RadioButtonList)rptCauseBehavioursEdit.Items[0].FindControl("rdoValue"), objInvestigation.Cause_1);
        //clsGeneral.FormatYesNoToDisplayForEdit((RadioButtonList)rptCauseBehavioursEdit.Items[1].FindControl("rdoValue"), objInvestigation.Cause_2);
        //clsGeneral.FormatYesNoToDisplayForEdit((RadioButtonList)rptCauseBehavioursEdit.Items[2].FindControl("rdoValue"), objInvestigation.Cause_3);
        //clsGeneral.FormatYesNoToDisplayForEdit((RadioButtonList)rptCauseBehavioursEdit.Items[3].FindControl("rdoValue"), objInvestigation.Cause_4);
        //clsGeneral.FormatYesNoToDisplayForEdit((RadioButtonList)rptCauseBehavioursEdit.Items[4].FindControl("rdoValue"), objInvestigation.Cause_5);
        //clsGeneral.FormatYesNoToDisplayForEdit((RadioButtonList)rptCauseBehavioursEdit.Items[5].FindControl("rdoValue"), objInvestigation.Cause_6);
        //clsGeneral.FormatYesNoToDisplayForEdit((RadioButtonList)rptCauseBehavioursEdit.Items[6].FindControl("rdoValue"), objInvestigation.Cause_7);
        //clsGeneral.FormatYesNoToDisplayForEdit((RadioButtonList)rptCauseBehavioursEdit.Items[7].FindControl("rdoValue"), objInvestigation.Cause_8);
        //clsGeneral.FormatYesNoToDisplayForEdit((RadioButtonList)rptCauseBehavioursEdit.Items[8].FindControl("rdoValue"), objInvestigation.Cause_9);
        //clsGeneral.FormatYesNoToDisplayForEdit((RadioButtonList)rptCauseBehavioursEdit.Items[9].FindControl("rdoValue"), objInvestigation.Cause_10);
        //clsGeneral.FormatYesNoToDisplayForEdit((RadioButtonList)rptCauseBehavioursEdit.Items[10].FindControl("rdoValue"), objInvestigation.Cause_11);
        //clsGeneral.FormatYesNoToDisplayForEdit((RadioButtonList)rptCauseBehavioursEdit.Items[11].FindControl("rdoValue"), objInvestigation.Cause_12);
        //clsGeneral.FormatYesNoToDisplayForEdit((RadioButtonList)rptCauseBehavioursEdit.Items[12].FindControl("rdoValue"), objInvestigation.Cause_13);
        //clsGeneral.FormatYesNoToDisplayForEdit((RadioButtonList)rptCauseBehavioursEdit.Items[13].FindControl("rdoValue"), objInvestigation.Cause_14);
        //clsGeneral.FormatYesNoToDisplayForEdit((RadioButtonList)rptCauseBehavioursEdit.Items[14].FindControl("rdoValue"), objInvestigation.Cause_15);
        //clsGeneral.FormatYesNoToDisplayForEdit((RadioButtonList)rptCauseBehavioursEdit.Items[15].FindControl("rdoValue"), objInvestigation.Cause_16);
        //clsGeneral.FormatYesNoToDisplayForEdit((RadioButtonList)rptCauseBehavioursEdit.Items[16].FindControl("rdoValue"), objInvestigation.Cause_17);
        //clsGeneral.FormatYesNoToDisplayForEdit((RadioButtonList)rptCauseBehavioursEdit.Items[17].FindControl("rdoValue"), objInvestigation.Cause_18);
        //clsGeneral.FormatYesNoToDisplayForEdit((RadioButtonList)rptCauseBehavioursEdit.Items[18].FindControl("rdoValue"), objInvestigation.Cause_19);
        //clsGeneral.FormatYesNoToDisplayForEdit((RadioButtonList)rptCauseBehavioursEdit.Items[19].FindControl("rdoValue"), objInvestigation.Cause_20);

        //clsGeneral.FormatYesNoToDisplayForEdit((RadioButtonList)rptCauseConditionsEdit.Items[0].FindControl("rdoValue"), objInvestigation.Cause_21);
        //clsGeneral.FormatYesNoToDisplayForEdit((RadioButtonList)rptCauseConditionsEdit.Items[1].FindControl("rdoValue"), objInvestigation.Cause_22);
        //clsGeneral.FormatYesNoToDisplayForEdit((RadioButtonList)rptCauseConditionsEdit.Items[2].FindControl("rdoValue"), objInvestigation.Cause_23);
        //clsGeneral.FormatYesNoToDisplayForEdit((RadioButtonList)rptCauseConditionsEdit.Items[3].FindControl("rdoValue"), objInvestigation.Cause_24);
        //clsGeneral.FormatYesNoToDisplayForEdit((RadioButtonList)rptCauseConditionsEdit.Items[4].FindControl("rdoValue"), objInvestigation.Cause_25);
        //clsGeneral.FormatYesNoToDisplayForEdit((RadioButtonList)rptCauseConditionsEdit.Items[5].FindControl("rdoValue"), objInvestigation.Cause_26);
        //clsGeneral.FormatYesNoToDisplayForEdit((RadioButtonList)rptCauseConditionsEdit.Items[6].FindControl("rdoValue"), objInvestigation.Cause_27);
        //clsGeneral.FormatYesNoToDisplayForEdit((RadioButtonList)rptCauseConditionsEdit.Items[7].FindControl("rdoValue"), objInvestigation.Cause_28);
        //clsGeneral.FormatYesNoToDisplayForEdit((RadioButtonList)rptCauseConditionsEdit.Items[8].FindControl("rdoValue"), objInvestigation.Cause_29);
        //clsGeneral.FormatYesNoToDisplayForEdit((RadioButtonList)rptCauseConditionsEdit.Items[9].FindControl("rdoValue"), objInvestigation.Cause_30);
        //clsGeneral.FormatYesNoToDisplayForEdit((RadioButtonList)rptCauseConditionsEdit.Items[10].FindControl("rdoValue"), objInvestigation.Cause_31);
        //clsGeneral.FormatYesNoToDisplayForEdit((RadioButtonList)rptCauseConditionsEdit.Items[11].FindControl("rdoValue"), objInvestigation.Cause_32);
        //clsGeneral.FormatYesNoToDisplayForEdit((RadioButtonList)rptCauseConditionsEdit.Items[12].FindControl("rdoValue"), objInvestigation.Cause_33);
        //clsGeneral.FormatYesNoToDisplayForEdit((RadioButtonList)rptCauseConditionsEdit.Items[13].FindControl("rdoValue"), objInvestigation.Cause_34);
        //clsGeneral.FormatYesNoToDisplayForEdit((RadioButtonList)rptCauseConditionsEdit.Items[14].FindControl("rdoValue"), objInvestigation.Cause_35);
        //clsGeneral.FormatYesNoToDisplayForEdit((RadioButtonList)rptCauseConditionsEdit.Items[15].FindControl("rdoValue"), objInvestigation.Cause_36);
        //clsGeneral.FormatYesNoToDisplayForEdit((RadioButtonList)rptCauseConditionsEdit.Items[16].FindControl("rdoValue"), objInvestigation.Cause_37);
        //clsGeneral.FormatYesNoToDisplayForEdit((RadioButtonList)rptCauseConditionsEdit.Items[17].FindControl("rdoValue"), objInvestigation.Cause_38);
        //clsGeneral.FormatYesNoToDisplayForEdit((RadioButtonList)rptCauseConditionsEdit.Items[18].FindControl("rdoValue"), objInvestigation.Cause_39);
        //clsGeneral.FormatYesNoToDisplayForEdit((RadioButtonList)rptCauseConditionsEdit.Items[19].FindControl("rdoValue"), objInvestigation.Cause_40);
        //clsGeneral.FormatYesNoToDisplayForEdit((RadioButtonList)rptCauseConditionsEdit.Items[20].FindControl("rdoValue"), objInvestigation.Cause_41);
        //clsGeneral.FormatYesNoToDisplayForEdit((RadioButtonList)rptCauseConditionsEdit.Items[21].FindControl("rdoValue"), objInvestigation.Cause_42);
        //txtCause_42_detail.Text = objInvestigation.Cause_42 == true ? objInvestigation.Cause_42_detail : string.Empty;
        #endregion


        txtCause_Comment.Text = objInvestigation.Cause_Comment;
        //trOtherDesc.Style["display"] = objInvestigation.Cause_42 == true ? "block" : "none";
        if (objInvestigation.FK_LU_Contributing_Factor != null) drpFk_LU_Contributing_Factor.SelectedValue = objInvestigation.FK_LU_Contributing_Factor.ToString();
        if (objInvestigation.Contributing_Factor_Other != "") txtContributingFactor_Other.Text = objInvestigation.Contributing_Factor_Other;

        drpCauseOfIncident.ClearSelection();

        if (objInvestigation.Focus_Area == string.Empty)
            drpCauseOfIncident.SelectedIndex = 0;
        else
        {
            ListItem lst = drpCauseOfIncident.Items.FindByText(objInvestigation.Focus_Area);
            if (lst != null)
                lst.Selected = true;

            hdnFocusArea.Value = drpCauseOfIncident.SelectedItem.Text;
        }

        PK_Focus_Area = clsGeneral.GetInt(drpCauseOfIncident.SelectedValue);

        #region "Personal / Job Factors"

        //clsGeneral.FormatYesNoToDisplayForEdit((RadioButtonList)rptPersonalFactorsEdit.Items[0].FindControl("rdoValue"), objInvestigation.Personal_Job_Factors_1);
        //clsGeneral.FormatYesNoToDisplayForEdit((RadioButtonList)rptPersonalFactorsEdit.Items[1].FindControl("rdoValue"), objInvestigation.Personal_Job_Factors_2);
        //clsGeneral.FormatYesNoToDisplayForEdit((RadioButtonList)rptPersonalFactorsEdit.Items[2].FindControl("rdoValue"), objInvestigation.Personal_Job_Factors_3);
        //clsGeneral.FormatYesNoToDisplayForEdit((RadioButtonList)rptPersonalFactorsEdit.Items[3].FindControl("rdoValue"), objInvestigation.Personal_Job_Factors_4);
        //clsGeneral.FormatYesNoToDisplayForEdit((RadioButtonList)rptPersonalFactorsEdit.Items[4].FindControl("rdoValue"), objInvestigation.Personal_Job_Factors_5);
        //clsGeneral.FormatYesNoToDisplayForEdit((RadioButtonList)rptPersonalFactorsEdit.Items[5].FindControl("rdoValue"), objInvestigation.Personal_Job_Factors_6);
        //clsGeneral.FormatYesNoToDisplayForEdit((RadioButtonList)rptPersonalFactorsEdit.Items[6].FindControl("rdoValue"), objInvestigation.Personal_Job_Factors_7);
        //clsGeneral.FormatYesNoToDisplayForEdit((RadioButtonList)rptPersonalFactorsEdit.Items[7].FindControl("rdoValue"), objInvestigation.Personal_Job_Factors_8);

        //clsGeneral.FormatYesNoToDisplayForEdit((RadioButtonList)rptJobFactorsEdit.Items[0].FindControl("rdoValue"), objInvestigation.Personal_Job_Factors_9);
        //clsGeneral.FormatYesNoToDisplayForEdit((RadioButtonList)rptJobFactorsEdit.Items[1].FindControl("rdoValue"), objInvestigation.Personal_Job_Factors_10);
        //clsGeneral.FormatYesNoToDisplayForEdit((RadioButtonList)rptJobFactorsEdit.Items[2].FindControl("rdoValue"), objInvestigation.Personal_Job_Factors_11);
        //clsGeneral.FormatYesNoToDisplayForEdit((RadioButtonList)rptJobFactorsEdit.Items[3].FindControl("rdoValue"), objInvestigation.Personal_Job_Factors_12);
        //clsGeneral.FormatYesNoToDisplayForEdit((RadioButtonList)rptJobFactorsEdit.Items[4].FindControl("rdoValue"), objInvestigation.Personal_Job_Factors_13);
        //clsGeneral.FormatYesNoToDisplayForEdit((RadioButtonList)rptJobFactorsEdit.Items[5].FindControl("rdoValue"), objInvestigation.Personal_Job_Factors_14);
        //clsGeneral.FormatYesNoToDisplayForEdit((RadioButtonList)rptJobFactorsEdit.Items[6].FindControl("rdoValue"), objInvestigation.Personal_Job_Factors_15);
        //clsGeneral.FormatYesNoToDisplayForEdit((RadioButtonList)rptJobFactorsEdit.Items[7].FindControl("rdoValue"), objInvestigation.Personal_Job_Factors_16);
        //clsGeneral.FormatYesNoToDisplayForEdit((RadioButtonList)rptJobFactorsEdit.Items[8].FindControl("rdoValue"), objInvestigation.Personal_Job_Factors_17);
        //clsGeneral.FormatYesNoToDisplayForEdit((RadioButtonList)rptJobFactorsEdit.Items[9].FindControl("rdoValue"), objInvestigation.Personal_Job_Factors_18);
        //clsGeneral.FormatYesNoToDisplayForEdit((RadioButtonList)rptJobFactorsEdit.Items[10].FindControl("rdoValue"), objInvestigation.Personal_Job_Factors_19);

        //txtPersonal_Job_Factors_19_Detail.Text = objInvestigation.Personal_Job_Factors_19 == true ? objInvestigation.Personal_Job_Factors_17_Details : string.Empty;
        //trPersonal_Job_Factors_Details.Style["display"] = objInvestigation.Personal_Job_Factors_19 == true ? "block" : "none";
        //txtPersonal_Job_Comment.Text = objInvestigation.Personal_Job_Comment;

        #endregion
        //if (objInvestigation.OSHA_Recordable != null)
        //{
        //    lblOSHARecordable.Text = objInvestigation.OSHA_Recordable == true ? "Yes" : "No";
        //    hdnOSHARecordable.Value = lblOSHARecordable.Text;
        //}
        #endregion

        #region Root Cause Determination
        DataSet ds = null;

        if ((hdnFocusArea.Value.ToString() == drpCauseOfIncident.SelectedItem.Text) || (string.IsNullOrEmpty(hdnFocusArea.Value) && Convert.ToInt32(drpCauseOfIncident.SelectedValue) > 0))
        {
            ds = clsInvestigation_Cause_Information.SelectByInvestigationID(Convert.ToDecimal(PK_Investigation_ID));
            if (ds == null || ds.Tables[0].Rows.Count <= 0)
            {
                ds = Investigation.SelectAllCauseCodeInformationByMasterNode(Convert.ToInt32(drpCauseOfIncident.SelectedValue));
            }

        }
        else { ds = Investigation.SelectAllCauseCodeInformationByMasterNode(Convert.ToInt32(drpCauseOfIncident.SelectedValue)); }




        rptRootCauseDetermination.DataSource = ds;
        rptRootCauseDetermination.DataBind();
        rptRootCauseDeterminationRecmndation.DataSource = ds;
        rptRootCauseDeterminationRecmndation.DataBind();

        DataTable dtRootCauseDetermination = ds.Tables[0];
        for (int i = 0; i < dtRootCauseDetermination.Rows.Count; i++)
        {
            RadioButtonList rdoValue = (RadioButtonList)rptRootCauseDetermination.Items[i].FindControl("rdoRootCauseTypeList");
            ASP.controls_noteswithspellcheck_notes_ascx cnt_Note = rptRootCauseDetermination.Items[i].FindControl("txtRoot_Cause_Comments") as ASP.controls_noteswithspellcheck_notes_ascx;
            TextBox txtRoot_Cause_Comments = cnt_Note.FindControl("txtNote") as TextBox;

            rdoValue.SelectedValue = Convert.ToString(dtRootCauseDetermination.Rows[i]["Response"]) == "Y" ? "Y" : "N";
            txtRoot_Cause_Comments.Text = Convert.ToString(dtRootCauseDetermination.Rows[i]["Comments"]);

        }
        for (int i = 0; i < dtRootCauseDetermination.Rows.Count; i++)
        {
            RadioButtonList rdoValue = (RadioButtonList)rptRootCauseDeterminationRecmndation.Items[i].FindControl("rdoRootCauseGuidanceList");
            rdoValue.SelectedValue = Convert.ToString(dtRootCauseDetermination.Rows[i]["Prevent_Reoccurrence"]) == "Y" ? "Y" : "N";
        }

        if (objInvestigation.FK_LU_OSHA_Incident != null) ddlClassify_Incident.SelectedValue = objInvestigation.FK_LU_OSHA_Incident.ToString();
        if (objInvestigation.FK_LU_OSHA_Injury != null) ddlType_of_Injury.SelectedValue = objInvestigation.FK_LU_OSHA_Injury.ToString();
        if (!string.IsNullOrEmpty(objInvestigation.RLCM_Review_Approve))
            rblRLCM_Reviewed_and_Approved.SelectedValue = objInvestigation.RLCM_Review_Approve;

        if (objInvestigation.OSHA_Recordable != null)
        {
            rdoOSHARecordable.SelectedValue = objInvestigation.OSHA_Recordable == true ? "Y" : "N";

            lblOSHARecordable_Fields.Style["display"] = objInvestigation.OSHA_Recordable == true ? "inline-block" : "none";
            lblOSHARecordable.Text = objInvestigation.OSHA_Recordable == true ? "Yes" : "No";
            hdnOSHARecordable.Value = lblOSHARecordable.Text;
            ScriptManager.RegisterStartupScript(Page, GetType(), DateTime.Now.ToString() + "0", "javascript:CheckOSHA_Fields_Validation(" + objInvestigation.OSHA_Recordable.ToString().ToLower() + ");", true);
        }
        else
        {
            ScriptManager.RegisterStartupScript(Page, GetType(), DateTime.Now.ToString() + "1", "javascript:CheckOSHA_Fields_Validation(false);", true);
        }

        //if (objInvestigation.OSHA_Recordable != null)
        //{
        //    lblOSHARecordable.Text = objInvestigation.OSHA_Recordable == true ? "Yes" : "No";
        //    hdnOSHARecordable.Value = lblOSHARecordable.Text;
        //}

        hdnOriginalSonicCode.Value = objInvestigation.Sonic_Cause_Code;
        ddlSonic_Cause_Code.ClearSelection();
        BindCause_Code_Determination();

        if (objInvestigation.Sonic_Cause_Code == string.Empty)
            ddlSonic_Cause_Code.SelectedIndex = 0;
        else
        {
            ListItem lst = ddlSonic_Cause_Code.Items.FindByText(objInvestigation.Sonic_Cause_Code);
            if (lst != null)
                lst.Selected = true;
        }

        #region ::ReBind sonic cause code drop down by cause of incident::

        if (ddlSonic_Cause_Code.SelectedItem != null)
        {
            //if (ddlSonic_Cause_Code.SelectedItem.Value.Contains(Convert.ToString(PK_Focus_Area)))
            //{
            if (PK_Focus_Area > 0)
            {
                for (int i = ddlSonic_Cause_Code.Items.Count - 1; i > 0; i--)
                {
                    if (ddlSonic_Cause_Code.Items[i].Value.Contains("S0-" + PK_Focus_Area + " -") || ddlSonic_Cause_Code.Items[i].Value.Contains("S" + PK_Focus_Area + " -") || ddlSonic_Cause_Code.Items[i].Value.Contains("S-" + PK_Focus_Area + ""))
                    {
                        ddlSonic_Cause_Code.ClearSelection();
                        ListItem lst = ddlSonic_Cause_Code.Items.FindByText(objInvestigation.Sonic_Cause_Code);
                        if (lst != null)
                            lst.Selected = true;
                    }
                    else
                    {
                        ddlSonic_Cause_Code.Items.RemoveAt(i);
                    }
                }
                //else
                //{
                //    for (int i = ddlSonic_Cause_Code.Items.Count - 1; i > 0; i--)
                //    {
                //        ddlSonic_Cause_Code.Items.RemoveAt(i);
                //    }

                //    ddlSonic_Cause_Code.SelectedIndex = 0;
                //}
            }
            else
            {
                for (int i = ddlSonic_Cause_Code.Items.Count - 1; i > 0; i--)
                {
                    ddlSonic_Cause_Code.Items.RemoveAt(i);
                }

                ddlSonic_Cause_Code.SelectedIndex = 0;
            }
            //}
        }
        #endregion

        txtOriginalSonicCode.Text = objInvestigation.Original_Sonic_S0_Cause_Code;
        rdoSonicCodePromoted.SelectedValue = objInvestigation.Sonic_S0_Cause_Code_Promoted == "Y" ? "Y" : "N";
        txtDateSonicCodePromoted.Text = clsGeneral.FormatDBNullDateToDisplay(objInvestigation.Date_Sonic_S0_Cause_Code_Promoted);
        txtConclusions.Text = objInvestigation.Conclusions;
        rdoSlipping.SelectedValue = objInvestigation.Slipping;
        ChangeSlippingValue(true);

        clsGeneral.SetDropdownValue(ddlFK_Nature_Of_Injury, objInvestigation.FK_Nature_of_Injury, true);
        clsGeneral.SetDropdownValue(ddlFK_Body_Parts_Affected, objInvestigation.FK_Body_Parts_Affected, true);

        #endregion

        #region " CORRECTIVE ACTIONS "

        //txtCorrective_Action_Description.Text = objInvestigation.Corrective_Action_Description;
        txtAssigned_To.Text = objInvestigation.Assigned_To;
        txtAssigned_By.Text = objInvestigation.AssignedBy;
        txtTo_Be_Competed_by.Text = clsGeneral.FormatDateToDisplay(objInvestigation.To_Be_Competed_by);
        // txtDateInves_Submitted.Text = clsGeneral.FormatDBNullDateToDisplay(objInvestigation.Date_Submitted_by_Store);
        ddlStatus.ClearSelection();

        if (objInvestigation.Status == string.Empty)
            ddlStatus.SelectedIndex = 0;
        else
            ddlStatus.Items.FindByText(objInvestigation.Status).Selected = true;

        txtLessons_Learned.Text = objInvestigation.Lessons_Learned;
        rdoCommunicated.SelectedValue = objInvestigation.Communicated == "Y" ? "Y" : "N";


        if (rdoCommunicated.SelectedValue == "Y")
        {
            txtDateCommunicated.Text = clsGeneral.FormatDBNullDateToDisplay(objInvestigation.Date_Communicated);
            txtNo_Communication_Explanation.Enabled = false;
        }
        else
        {
            txtNo_Communication_Explanation.Text = objInvestigation.No_Communication_Explanation;
            txtDateCommunicated.Enabled = false;
        }
        //chkLocInfoComplete.Checked = objInvestigation.Location_Information_Complete;

        #endregion

        #region " REVIEW "

        clsGeneral.FormatYesNoToDisplayForEdit(rdbTime, objInvestigation.Timing);
        CtrlMultiLineTiming.Text = objInvestigation.Timing_Comment;

        clsGeneral.FormatYesNoToDisplayForEdit(rdbSLT, objInvestigation.SLT_Involvement);
        CtrlMultiLineSLT.Text = objInvestigation.SLT_Involvement_Comment;

        clsGeneral.FormatYesNoToDisplayForEdit(rdbSLTVisit, objInvestigation.SLT_Visit);
        CtrlMultiLineSLTVisit.Text = objInvestigation.SLT_Visit_Comment;

        clsGeneral.FormatYesNoToDisplayForEdit(rdbWitness, objInvestigation.Witnesses);
        CtrlMultiLineWitness.Text = objInvestigation.Witnesses_Comment;

        clsGeneral.FormatYesNoToDisplayForEdit(rdbRoot, objInvestigation.Root_Causes);
        CtrlMultiLineRoot.Text = objInvestigation.Root_Causes_Comment;

        clsGeneral.FormatYesNoToDisplayForEdit(rdbActionPlan, objInvestigation.Action_Plan);
        CtrlMultiLineActionPlan.Text = objInvestigation.Action_Plan_Comment;

        if (bIsUserRLCMOfficer)
        {
            txtCause_Reviewed.Text = clsGeneral.FormatDateToDisplay(objInvestigation.Cause_Reviewed);
            txtAction_Reviewed.Text = clsGeneral.FormatDateToDisplay(objInvestigation.Action_Reviewed);
            chkRLCMComplete.Checked = objInvestigation.RLCM_Complete;
            if (!string.IsNullOrEmpty(objInvestigation.Investigative_Quality)) drpInvestigative.SelectedValue = objInvestigation.Investigative_Quality;
            txtRLCMComments.Text = objInvestigation.RLCM_Comments;
            txtDateReviewCompletedByRLCM.Text = clsGeneral.FormatDBNullDateToDisplay(objInvestigation.Date_RLCM_Review_Completed);
            if (objInvestigation.Lag_Time != null) txtIncidentReviewLagTime.Text = objInvestigation.Lag_Time.ToString();
        }
        else
        {
            lblCause_Codes_Reviewed_Approved.Text = clsGeneral.FormatDateToDisplay(objInvestigation.Cause_Reviewed);
            lblCorrective_Actions_Reviewed_Approved.Text = clsGeneral.FormatDateToDisplay(objInvestigation.Action_Reviewed);
            chkRLCM_Complete.Checked = objInvestigation.RLCM_Complete;
            if (!string.IsNullOrEmpty(objInvestigation.Investigative_Quality)) Investigative_Quality.Text = objInvestigation.Investigative_Quality;
            lblRLCM_Comments.Text = objInvestigation.RLCM_Comments;
            lblDate_Review_Completed_by_RLCM.Text = clsGeneral.FormatDBNullDateToDisplay(objInvestigation.Date_RLCM_Review_Completed);
            if (objInvestigation.Lag_Time != null) lblIncident_Review_LagTime.Text = objInvestigation.Lag_Time.ToString();
        }

        if (objInvestigation.RLCM_Complete)
        {
            txtCause_Reviewed.Enabled = false;
            txtAction_Reviewed.Enabled = false;
            chkRLCMComplete.Enabled = false;
        }

        #endregion

        #region "WC OSHA"

        txtPhysician_Other_Professional.Text = objInvestigation.Physician_Other_Professional;
        txtFacility.Text = objInvestigation.Facility;
        txtFacility_Address.Text = objInvestigation.Facility_Address;
        txtFacility_City.Text = objInvestigation.Facility_City;

        if (objInvestigation.FK_State_Facility > 0)
        {
            ddlFK_State_Facility.SelectedValue = Convert.ToString(objInvestigation.FK_State_Facility);
        }
        else
        {
            ddlFK_State_Facility.SelectedValue = "0";
        }

        txtFacility_Zip_Code.Text = objInvestigation.Facility_Zip_Code;
        rblEmergency_Room.SelectedValue = objInvestigation.Emergency_Room == "Y" ? objInvestigation.Emergency_Room : "N";
        txtTime_Began_Work.Text = objInvestigation.Time_Began_Work;
        txtActivity_Before_Incident.Text = objInvestigation.Activity_Before_Incident;
        txtObject_Substance_Involved.Text = objInvestigation.Object_Substance_Involved;

        //used to check if the value is null than set values to radio button is "-1"and 
        //if the value is not null than and else if value is true than set value to radio button is "Y" else "N"
        if (objInvestigation.Admitted_to_Hospital != null)
        {
            if (objInvestigation.Admitted_to_Hospital == true)
                rdoAdmitted_to_Hospital.SelectedValue = "Y";
            else
                rdoAdmitted_to_Hospital.SelectedValue = "N";
        }
        else
            rdoAdmitted_to_Hospital.SelectedValue = "-1";


        if (clsGeneral.FormatDBNullDateToDisplay(objInvestigation.Return_To_Work_Date) != string.Empty)
        {
            txtReturnToWorkDate.Text = clsGeneral.FormatDBNullDateToDisplay(objInvestigation.Return_To_Work_Date);
        }
        else
        {
            DataTable dtClaimInfo = WC_ClaimInfo.Select_Claim_Number(Convert.ToInt32(FK_WC_FR), "WC");
            if (dtClaimInfo.Rows.Count > 0)
            {
                DataSet dtClaimDetail = WC_ClaimInfo.SelectByPK(Convert.ToInt32(Convert.ToInt32(dtClaimInfo.Rows[0]["ClaimID"])));
                if (dtClaimDetail.Tables[0].Rows[0]["Date_Return_To_Work"] != null && dtClaimDetail.Tables[0].Rows[0]["Date_Return_To_Work"].ToString() != string.Empty)
                    txtReturnToWorkDate.Text = clsGeneral.FormatDateToDisplay(Convert.ToDateTime(dtClaimDetail.Tables[0].Rows[0]["Date_Return_To_Work"]));
            }
        }

        #endregion

        CtrlAttachDetails.InitializeAttachmentDetails(clsGeneral.Tables.Investigation, PK_Investigation_ID, true, 4);
        CtrlAttachDetails.Bind();

        if (objInvestigation.Investigative_Quality != null)
        {
            btnEMailto_Distribution_List.Visible = true;
        }
        btnInvestigationSave.Visible = true;
        btnCancel.Visible = true;
    }

    /// <summary>
    /// method -Generate mail
    /// </summary>
    private void GenerateMail()
    {
        WC_FR objWCFR = new WC_FR(FK_WC_FR);
        LU_Location objLocation = new LU_Location(objWCFR.FK_LU_Location);
        State objstate = new State(Convert.ToInt16(objLocation.State));

        DataTable dtOfficers = Investigation.SelectRegionalOfficers(objLocation.PK_LU_Location_ID);
        foreach (DataRow drOfficer in dtOfficers.Rows)
        {
            if (Convert.ToString(drOfficer["Email"]) != "reportaclaim@srsconnect.com" && AppConfig.MailCC != "reportaclaim@srsconnect.com")
            {
                string strBody = GenerateInvestigatorReportBody();

                string strTo = Convert.ToString(drOfficer["Email"]);
                string strSubject = null;

                if (objstate.FLD_state.ToLower() == "texas")
                {
                    if (objWCFR.Date_Of_Incident != null && !String.IsNullOrEmpty(objWCFR.Date_Of_Incident))
                    {
                        if (Convert.ToDateTime(objWCFR.Date_Of_Incident) > Convert.ToDateTime("11/30/2011"))
                            strSubject = "Location " + objLocation.Sonic_Location_Code + " - " + objLocation.dba + " has completed the Investigation associated with NS-" + objWCFR.WC_FR_Number;
                        else
                            strSubject = "Location " + objLocation.Sonic_Location_Code + " - " + objLocation.dba + " has completed the Investigation associated with WC-" + objWCFR.WC_FR_Number;
                    }
                    else
                        strSubject = "Location " + objLocation.Sonic_Location_Code + " - " + objLocation.dba + " has completed the Investigation associated with WC-" + objWCFR.WC_FR_Number;
                }
                else
                    strSubject = "Location " + objLocation.Sonic_Location_Code + " - " + objLocation.dba + " has completed the Investigation associated with WC-" + objWCFR.WC_FR_Number;

                clsGeneral.SendMailMessage(AppConfig.MailFrom, strTo, "", AppConfig.MailCC, strSubject, strBody.ToString(), true);
                ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "", "alert('Mail sent successfully')", true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "", "alert('No Notification Distribution List for the Location " + objLocation.dba + ".')", true);
            }
        }
    }

    /// <summary>
    /// Generate Body for Investigator Detail
    /// </summary>
    /// <returns></returns>
    private string GenerateInvestigatorReportBody()
    {
        string bandHeaderRow = "border: #7f7f7f solid 1px;vertical-align: middle;background-color: #9a9a9a;padding-left: 0px;height: 18px;font-size: 12px;font-weight: bold;color: #f5f5f5;text-decoration: none;";

        string strFontStyle = "style='FONT-SIZE: 11px; FONT-FAMILY: Tahoma;'";

        WC_FR objWCFR = new WC_FR(FK_WC_FR);
        Investigation objInvestigation = new Investigation(PK_Investigation_ID);
        LU_Location objLocation = new LU_Location(objWCFR.FK_LU_Location);

        StringBuilder strBody = new StringBuilder("");

        strBody.Append("<html xmlns='http://www.w3.org/1999/xhtml'><body " + strFontStyle + ">");

        #region "Incident Information"

        strBody.Append("<div style='" + bandHeaderRow + "'>&nbsp;Incident Information</div>");
        strBody.Append("<table cellpadding='3' cellspacing=1 border=0 width='100%'" + strFontStyle + ">");
        strBody.Append("<tr><td align='left' width='18%'>Location d/b/a</td><td align='center' width='4%'>:</td>");
        strBody.Append("<td align='left' width='28%'>" + objLocation.dba + "</td>");
        strBody.Append("<td align='left' width='18%'>Location RM Number</td><td align='center' width='4%'>:</td>");
        strBody.Append("<td align='left' width='28%'>" + objLocation.RM_Location_Number + "</td></tr>");
        strBody.Append("<tr><td align='left' valign='top'>Date of Incident</td><td align='center' valign='top'>:</td>");
        strBody.Append("<td align='left'>" + objWCFR.Date_Of_Incident + "</td>");
        strBody.Append("<td align='left'>Time of Incident</td><td align='center'>:</td>");
        strBody.Append("<td align='left'>" + objWCFR.Time_Of_Incident + "</td></tr>");
        strBody.Append("<tr><td align='left'>Department</td><td align='center'>:</td>");
        strBody.Append("<td align='left'>" + new LU_Department(objWCFR.FK_Department_Where_Occurred).Description + "</td>");
        strBody.Append("<td align='left'>&nbsp;</td><td align='center'>&nbsp;</td><td align='left'>&nbsp;</td></tr>");
        strBody.Append("<tr><td align='left'>Date Reported to Sonic</td><td align='center'>:</td>");
        strBody.Append("<td align='left' colspan='4'>" + clsGeneral.FormatDateToDisplay(objWCFR.Date_Reported_To_Sonic) + "</td></tr>");
        strBody.Append("<tr><td colspan='6' width='100%'><b>Associate Information</b></td></tr>");
        strBody.Append("<tr><td align='left'>Name</td><td align='center'>:</td>");
        Employee objEmp = new Employee(objWCFR.FK_Injured);

        string strMiddleName = (!string.IsNullOrEmpty(objEmp.Middle_Name)) ? objEmp.Middle_Name : "";
        string strEmpName = (!string.IsNullOrEmpty(objEmp.Last_Name) ? objEmp.Last_Name.Trim() + ", " : "") +
            (!string.IsNullOrEmpty(objEmp.First_Name) ? objEmp.First_Name.Trim() + " " : "") + strMiddleName;
        strEmpName = strEmpName.Trim();
        strEmpName = strEmpName.TrimEnd(',');
        strBody.Append("<td align='left'>" + strEmpName + "</td>");
        strBody.Append("<td align='left'>Job Title</td><td align='center'>:</td>");
        strBody.Append("<td align='left'>" + objEmp.Job_Title + "</td></tr>");
        strBody.Append("<tr><td align='left'>Date of Hire</td><td align='center'>:</td>");
        strBody.Append("<td align='left'>" + clsGeneral.FormatDBNullDateToDisplay(objEmp.Hire_Date) + "</td>");
        strBody.Append("<td align='left'>Nature of Injury</td><td align='center'>:</td>");
        strBody.Append("<td align='left'>" + new LU_Nature_of_Injury(objWCFR.FK_Nature_Of_Injury).Description + "</td></tr>");
        strBody.Append("<tr><td align='left'>Body Part Affected</td><td align='center'>:</td>");
        if (objWCFR.FK_Body_Parts_Affected != "")
        { strBody.Append("<td align='left' colspan='4'>" + new LU_Part_Of_Body(Convert.ToDecimal(objWCFR.FK_Body_Parts_Affected)).Description + "</td></tr>"); }
        else
        { strBody.Append("<td align='left' colspan='4'>&nbsp;</td></tr>"); }

        strBody.Append("<tr><td colspan='6' width='100%'><b>Incident Detail</b></td></tr>");
        strBody.Append("<tr><td>Incident Description</td><td align='center'>:</td><td colspan='4'>&nbsp;</td></tr>");
        strBody.Append("<tr><td colspan='6' width='100%'>" + objWCFR.Description_Of_Incident + "</td></tr>");
        strBody.Append("<tr><td align='left'>Safeguards/Safety Equipment Provided</td><td align='center'>:</td>");
        strBody.Append("<td align='left'>" + (objWCFR.Safeguards_Provided != null ? (objWCFR.Safeguards_Provided == true ? "Yes" : "No") : "") + "</td>");
        strBody.Append("<td align='left'>Safeguards/Safety Equipment Used</td><td align='center'>:</td>");
        strBody.Append("<td align='left'>" + (objWCFR.Safeguards_Used != null ? (objWCFR.Safeguards_Used == true ? "Yes" : "No") : "") + "</td></tr>");
        strBody.Append("<tr><td align='left'>Machine Part was involved</td><td align='center'>:</td>");
        strBody.Append("<td align='left'>" + (objWCFR.Machine_Part_Involved != null ? (objWCFR.Machine_Part_Involved == true ? "Yes" : "No") : "") + "</td>");
        strBody.Append("<td align='left'>Machine Part was defective</td><td align='center'>:</td>");
        strBody.Append("<td align='left'>" + (objWCFR.Machine_Part_Defective != null ? (objWCFR.Machine_Part_Defective == true ? "Yes" : "No") : "") + "</td></tr>");
        strBody.Append("</table>");

        #endregion

        //#region "Causes"

        //strBody.Append("<div style='" + bandHeaderRow + "'>&nbsp;Causes</div>");
        //strBody.Append("<table cellpadding='3' cellspacing=1 border=0 width='100%'" + strFontStyle + ">");
        //strBody.Append("<tr><td colspan='6' width='100%'><b>What were the immediate causes of the accident?</b></td></tr>");
        //strBody.Append("<tr><td colspan='6' width='100%'>SUBSTANDARD BEHAVIORS</td></tr>");

        //#region "Cause Behaviours"

        //StringBuilder causeBehaviours = new StringBuilder();
        //causeBehaviours.Append("<table cellpadding='0' cellspacing='0' width='100%'" + strFontStyle + ">");
        //causeBehaviours.Append("<tr><td width='50%' align='left'>" + strCauseBahaviour[0] + "</td><td align='left'>" + GetYesNo(objInvestigation.Cause_1) + "</td></tr>");
        //causeBehaviours.Append("<tr><td width='50%' align='left'>" + strCauseBahaviour[1] + "</td><td align='left'>" + GetYesNo(objInvestigation.Cause_2) + "</td></tr>");
        //causeBehaviours.Append("<tr><td width='50%' align='left'>" + strCauseBahaviour[2] + "</td><td align='left'>" + GetYesNo(objInvestigation.Cause_3) + "</td></tr>");
        //causeBehaviours.Append("<tr><td width='50%' align='left'>" + strCauseBahaviour[3] + "</td><td align='left'>" + GetYesNo(objInvestigation.Cause_4) + "</td></tr>");
        //causeBehaviours.Append("<tr><td width='50%' align='left'>" + strCauseBahaviour[4] + "</td><td align='left'>" + GetYesNo(objInvestigation.Cause_5) + "</td></tr>");
        //causeBehaviours.Append("<tr><td width='50%' align='left'>" + strCauseBahaviour[5] + "</td><td align='left'>" + GetYesNo(objInvestigation.Cause_6) + "</td></tr>");
        //causeBehaviours.Append("<tr><td width='50%' align='left'>" + strCauseBahaviour[6] + "</td><td align='left'>" + GetYesNo(objInvestigation.Cause_7) + "</td></tr>");
        //causeBehaviours.Append("<tr><td width='50%' align='left'>" + strCauseBahaviour[7] + "</td><td align='left'>" + GetYesNo(objInvestigation.Cause_8) + "</td></tr>");
        //causeBehaviours.Append("<tr><td width='50%' align='left'>" + strCauseBahaviour[8] + "</td><td align='left'>" + GetYesNo(objInvestigation.Cause_9) + "</td></tr>");
        //causeBehaviours.Append("<tr><td width='50%' align='left'>" + strCauseBahaviour[9] + "</td><td align='left'>" + GetYesNo(objInvestigation.Cause_10) + "</td></tr>");
        //causeBehaviours.Append("<tr><td width='50%' align='left'>" + strCauseBahaviour[10] + "</td><td align='left'>" + GetYesNo(objInvestigation.Cause_11) + "</td></tr>");
        //causeBehaviours.Append("<tr><td width='50%' align='left'>" + strCauseBahaviour[11] + "</td><td align='left'>" + GetYesNo(objInvestigation.Cause_12) + "</td></tr>");
        //causeBehaviours.Append("<tr><td width='50%' align='left'>" + strCauseBahaviour[12] + "</td><td align='left'>" + GetYesNo(objInvestigation.Cause_13) + "</td></tr>");
        //causeBehaviours.Append("<tr><td width='50%' align='left'>" + strCauseBahaviour[13] + "</td><td align='left'>" + GetYesNo(objInvestigation.Cause_14) + "</td></tr>");
        //causeBehaviours.Append("<tr><td width='50%' align='left'>" + strCauseBahaviour[14] + "</td><td align='left'>" + GetYesNo(objInvestigation.Cause_15) + "</td></tr>");
        //causeBehaviours.Append("<tr><td width='50%' align='left'>" + strCauseBahaviour[15] + "</td><td align='left'>" + GetYesNo(objInvestigation.Cause_16) + "</td></tr>");
        //causeBehaviours.Append("<tr><td width='50%' align='left'>" + strCauseBahaviour[16] + "</td><td align='left'>" + GetYesNo(objInvestigation.Cause_17) + "</td></tr>");
        //causeBehaviours.Append("<tr><td width='50%' align='left'>" + strCauseBahaviour[17] + "</td><td align='left'>" + GetYesNo(objInvestigation.Cause_18) + "</td></tr>");
        //causeBehaviours.Append("<tr><td width='50%' align='left'>" + strCauseBahaviour[18] + "</td><td align='left'>" + GetYesNo(objInvestigation.Cause_19) + "</td></tr>");
        //causeBehaviours.Append("<tr><td width='50%' align='left'>" + strCauseBahaviour[19] + "</td><td align='left'>" + GetYesNo(objInvestigation.Cause_20) + "</td></tr>");
        //causeBehaviours.Append("</table>");

        //#endregion

        //strBody.Append("<tr><td colspan='6'>" + causeBehaviours.ToString() + "</td></tr>");
        //strBody.Append("<tr><td colspan='6' width='100%'>&nbsp;</td></tr>");
        //strBody.Append("<tr><td colspan='6' width='100%'>SUBSTANDARD CONDITIONS</td>");

        //#region "Cause Conditions"

        //StringBuilder sbCauseConditions = new StringBuilder();
        //sbCauseConditions.Append("<table cellpadding='0' cellspacing='0' width='100%'" + strFontStyle + ">");
        //sbCauseConditions.Append("<tr><td width='50%' align='left'>" + strCauseConditions[0] + "</td><td align='left'>" + GetYesNo(objInvestigation.Cause_21) + "</td></tr>");
        //sbCauseConditions.Append("<tr><td width='50%' align='left'>" + strCauseConditions[1] + "</td><td align='left'>" + GetYesNo(objInvestigation.Cause_22) + "</td></tr>");
        //sbCauseConditions.Append("<tr><td width='50%' align='left'>" + strCauseConditions[2] + "</td><td align='left'>" + GetYesNo(objInvestigation.Cause_23) + "</td></tr>");
        //sbCauseConditions.Append("<tr><td width='50%' align='left'>" + strCauseConditions[3] + "</td><td align='left'>" + GetYesNo(objInvestigation.Cause_24) + "</td></tr>");
        //sbCauseConditions.Append("<tr><td width='50%' align='left'>" + strCauseConditions[4] + "</td><td align='left'>" + GetYesNo(objInvestigation.Cause_25) + "</td></tr>");
        //sbCauseConditions.Append("<tr><td width='50%' align='left'>" + strCauseConditions[5] + "</td><td align='left'>" + GetYesNo(objInvestigation.Cause_26) + "</td></tr>");
        //sbCauseConditions.Append("<tr><td width='50%' align='left'>" + strCauseConditions[6] + "</td><td align='left'>" + GetYesNo(objInvestigation.Cause_27) + "</td></tr>");
        //sbCauseConditions.Append("<tr><td width='50%' align='left'>" + strCauseConditions[7] + "</td><td align='left'>" + GetYesNo(objInvestigation.Cause_28) + "</td></tr>");
        //sbCauseConditions.Append("<tr><td width='50%' align='left'>" + strCauseConditions[8] + "</td><td align='left'>" + GetYesNo(objInvestigation.Cause_29) + "</td></tr>");
        //sbCauseConditions.Append("<tr><td width='50%' align='left'>" + strCauseConditions[9] + "</td><td align='left'>" + GetYesNo(objInvestigation.Cause_30) + "</td></tr>");
        //sbCauseConditions.Append("<tr><td width='50%' align='left'>" + strCauseConditions[10] + "</td><td align='left'>" + GetYesNo(objInvestigation.Cause_31) + "</td></tr>");
        //sbCauseConditions.Append("<tr><td width='50%' align='left'>" + strCauseConditions[11] + "</td><td align='left'>" + GetYesNo(objInvestigation.Cause_32) + "</td></tr>");
        //sbCauseConditions.Append("<tr><td width='50%' align='left'>" + strCauseConditions[12] + "</td><td align='left'>" + GetYesNo(objInvestigation.Cause_33) + "</td></tr>");
        //sbCauseConditions.Append("<tr><td width='50%' align='left'>" + strCauseConditions[13] + "</td><td align='left'>" + GetYesNo(objInvestigation.Cause_34) + "</td></tr>");
        //sbCauseConditions.Append("<tr><td width='50%' align='left'>" + strCauseConditions[14] + "</td><td align='left'>" + GetYesNo(objInvestigation.Cause_35) + "</td></tr>");
        //sbCauseConditions.Append("<tr><td width='50%' align='left'>" + strCauseConditions[15] + "</td><td align='left'>" + GetYesNo(objInvestigation.Cause_36) + "</td></tr>");
        //sbCauseConditions.Append("<tr><td width='50%' align='left'>" + strCauseConditions[16] + "</td><td align='left'>" + GetYesNo(objInvestigation.Cause_37) + "</td></tr>");
        //sbCauseConditions.Append("<tr><td width='50%' align='left'>" + strCauseConditions[17] + "</td><td align='left'>" + GetYesNo(objInvestigation.Cause_38) + "</td></tr>");
        //sbCauseConditions.Append("<tr><td width='50%' align='left'>" + strCauseConditions[18] + "</td><td align='left'>" + GetYesNo(objInvestigation.Cause_39) + "</td></tr>");
        //sbCauseConditions.Append("<tr><td width='50%' align='left'>" + strCauseConditions[19] + "</td><td align='left'>" + GetYesNo(objInvestigation.Cause_40) + "</td></tr>");
        //sbCauseConditions.Append("<tr><td width='50%' align='left'>" + strCauseConditions[20] + "</td><td align='left'>" + GetYesNo(objInvestigation.Cause_41) + "</td></tr>");
        //sbCauseConditions.Append("<tr><td width='50%' align='left'>" + strCauseConditions[21] + "</td><td align='left'>" + GetYesNo(objInvestigation.Cause_42) + "</td></tr>");
        //sbCauseConditions.Append("</table>");

        //#endregion

        //strBody.Append("<tr><td colspan='6'>" + sbCauseConditions.ToString() + "</td></tr>");
        //if (objInvestigation.Cause_42 == true)
        //    strBody.Append("<tr><td align='left' colspan='6'>" + objInvestigation.Cause_42_detail + "</td></tr>");

        //strBody.Append("<tr><td align='left'>Comment</td></tr>");
        //strBody.Append("<tr><td align='left' colspan='6'>" + objInvestigation.Cause_Comment + "</td></tr>");
        //strBody.Append("<tr><td align='left' colspan='6'>What are the basic causes that led to the immediate causes above?</td></tr>");
        //strBody.Append("<tr><td colspan='6' align='left'>");

        //strBody.Append("<table cellpadding='3' cellspacing='1' border='0' width='100%'" + strFontStyle + "><tr>");
        //strBody.Append("<td align='left' colspan='2' style='width:50%'>PERSONAL FACTORS</td>");
        //strBody.Append("<td align='left' colspan='2' style='width:50%'>JOB FACTORS</td></tr>");

        //#region "Personal Factors"

        //StringBuilder sbPersonalFactors = new StringBuilder();
        //sbPersonalFactors.Append("<table cellpadding='0' cellspacing='0' width='100%'" + strFontStyle + ">");
        //sbPersonalFactors.Append("<tr><td width='70%' align='left'>" + strPersonalFactors[0] + "</td><td align='left'>" + GetYesNo(objInvestigation.Personal_Job_Factors_1) + "</td></tr>");
        //sbPersonalFactors.Append("<tr><td width='70%' align='left'>" + strPersonalFactors[1] + "</td><td align='left'>" + GetYesNo(objInvestigation.Personal_Job_Factors_2) + "</td></tr>");
        //sbPersonalFactors.Append("<tr><td width='70%' align='left'>" + strPersonalFactors[2] + "</td><td align='left'>" + GetYesNo(objInvestigation.Personal_Job_Factors_3) + "</td></tr>");
        //sbPersonalFactors.Append("<tr><td width='70%' align='left'>" + strPersonalFactors[3] + "</td><td align='left'>" + GetYesNo(objInvestigation.Personal_Job_Factors_4) + "</td></tr>");
        //sbPersonalFactors.Append("<tr><td width='70%' align='left'>" + strPersonalFactors[4] + "</td><td align='left'>" + GetYesNo(objInvestigation.Personal_Job_Factors_5) + "</td></tr>");
        //sbPersonalFactors.Append("<tr><td width='70%' align='left'>" + strPersonalFactors[5] + "</td><td align='left'>" + GetYesNo(objInvestigation.Personal_Job_Factors_6) + "</td></tr>");
        //sbPersonalFactors.Append("<tr><td width='70%' align='left'>" + strPersonalFactors[6] + "</td><td align='left'>" + GetYesNo(objInvestigation.Personal_Job_Factors_7) + "</td></tr>");
        //sbPersonalFactors.Append("<tr><td width='70%' align='left'>" + strPersonalFactors[7] + "</td><td align='left'>" + GetYesNo(objInvestigation.Personal_Job_Factors_8) + "</td></tr>");
        //sbPersonalFactors.Append("</table>");

        //#endregion

        //#region "Job Factors"

        //StringBuilder sbJobFactors = new StringBuilder();
        //sbJobFactors.Append("<table cellpadding='0' cellspacing='0' width='100%'" + strFontStyle + ">");
        //sbJobFactors.Append("<tr><td width='70%' align='left'>" + strJobFactors[0] + "</td><td align='left'>" + GetYesNo(objInvestigation.Personal_Job_Factors_9) + "</td></tr>");
        //sbJobFactors.Append("<tr><td width='70%' align='left'>" + strJobFactors[1] + "</td><td align='left'>" + GetYesNo(objInvestigation.Personal_Job_Factors_10) + "</td></tr>");
        //sbJobFactors.Append("<tr><td width='70%' align='left'>" + strJobFactors[2] + "</td><td align='left'>" + GetYesNo(objInvestigation.Personal_Job_Factors_11) + "</td></tr>");
        //sbJobFactors.Append("<tr><td width='70%' align='left'>" + strJobFactors[3] + "</td><td align='left'>" + GetYesNo(objInvestigation.Personal_Job_Factors_12) + "</td></tr>");
        //sbJobFactors.Append("<tr><td width='70%' align='left'>" + strJobFactors[4] + "</td><td align='left'>" + GetYesNo(objInvestigation.Personal_Job_Factors_13) + "</td></tr>");
        //sbJobFactors.Append("<tr><td width='70%' align='left'>" + strJobFactors[5] + "</td><td align='left'>" + GetYesNo(objInvestigation.Personal_Job_Factors_14) + "</td></tr>");
        //sbJobFactors.Append("<tr><td width='70%' align='left'>" + strJobFactors[6] + "</td><td align='left'>" + GetYesNo(objInvestigation.Personal_Job_Factors_15) + "</td></tr>");
        //sbJobFactors.Append("<tr><td width='70%' align='left'>" + strJobFactors[7] + "</td><td align='left'>" + GetYesNo(objInvestigation.Personal_Job_Factors_16) + "</td></tr>");
        //sbJobFactors.Append("<tr><td width='70%' align='left'>" + strJobFactors[8] + "</td><td align='left'>" + GetYesNo(objInvestigation.Personal_Job_Factors_17) + "</td></tr>");
        //sbJobFactors.Append("<tr><td width='70%' align='left'>" + strJobFactors[9] + "</td><td align='left'>" + GetYesNo(objInvestigation.Personal_Job_Factors_18) + "</td></tr>");
        //sbJobFactors.Append("<tr><td width='70%' align='left'>" + strJobFactors[10] + "</td><td align='left'>" + GetYesNo(objInvestigation.Personal_Job_Factors_19) + "</td></tr>");
        //sbJobFactors.Append("</table>");
        //#endregion

        //strBody.Append("<tr><td colspan='2' align='left' valign='top'>" + sbPersonalFactors.ToString() + "</td><td align='left' colspan='2' valign='top'>" + sbJobFactors.ToString() + "</td></tr>");

        //if (objInvestigation.Personal_Job_Factors_19 == true)
        //    strBody.Append("<tr><td align='left'>&nbsp;</td><td align='left'>&nbsp;</td><td align='left'>" + objInvestigation.Personal_Job_Factors_17_Details + "</td></tr>");
        //strBody.Append("</table></td>");

        //strBody.Append("<tr><td align='left' colspan='6'>");
        //strBody.Append("<table width='100%' " + strFontStyle + ">");

        //if (strOperation == "edit")
        //{

        //    if (drpFk_LU_Contributing_Factor.SelectedItem.Text == "Other" || lblContributingFactor.Text == "Other")
        //    {
        //        strBody.Append("<tr><td align='left' width='18%'>Contributing Factor</td><td align='center' width='4%'>:</td>");
        //        strBody.Append("<td align='left' width='28%'>" + new clsLU_Contributing_Factor((decimal)objInvestigation.FK_LU_Contributing_Factor).Field_Description + "</td>");
        //        strBody.Append("<td align='left' width='18%'>Contributing Factor - Other</td><td align='center' width='4%'>:</td>");
        //        strBody.Append("<td align='left' width='28%'>" + objInvestigation.Contributing_Factor_Other + "</td></tr>");
        //    }
        //    else
        //    {
        //        strBody.Append("<tr><td align='left' style='width:18%'>Contributing Factor</td><td align='center' style='width:4%'>:</td>");
        //        if (drpFk_LU_Contributing_Factor.SelectedIndex > 0)
        //        {
        //            strBody.Append("<td align='left' colspan='4'>" + new clsLU_Contributing_Factor((decimal)objInvestigation.FK_LU_Contributing_Factor).Field_Description + "</td></tr>");
        //        }
        //        else
        //        {
        //            strBody.Append("<td align='left' colspan='4'>" + string.Empty + "</td></tr>");
        //        }
        //    }

        //    strBody.Append("</table></td></tr>");
        //}
        //else
        //{
        //    if (lblContributingFactor.Text == "Other")
        //    {
        //        strBody.Append("<tr><td align='left' width='18%'>Contributing Factor</td><td align='center' width='4%'>:</td>");
        //        strBody.Append("<td align='left' width='28%'>" + new clsLU_Contributing_Factor((decimal)objInvestigation.FK_LU_Contributing_Factor).Field_Description + "</td>");
        //        strBody.Append("<td align='left' width='18%'>Contributing Factor - Other</td><td align='center' width='4%'>:</td>");
        //        strBody.Append("<td align='left' width='28%'>" + objInvestigation.Contributing_Factor_Other + "</td></tr>");
        //    }
        //    else
        //    {
        //        strBody.Append("<tr><td align='left' style='width:18%'>Contributing Factor</td><td align='center' style='width:4%'>:</td>");
        //        if (objInvestigation.FK_LU_Contributing_Factor != null)
        //        {
        //            strBody.Append("<td align='left' colspan='4'>" + new clsLU_Contributing_Factor((decimal)objInvestigation.FK_LU_Contributing_Factor).Field_Description + "</td></tr>");
        //        }
        //        else
        //        {
        //            strBody.Append("<td align='left' colspan='4'>" + string.Empty + "</td></tr>");
        //        }
        //    }

        //    strBody.Append("</table></td></tr>");
        //}

        //strBody.Append("<tr><td align='left' colspan='6'>Comment</td></tr>");
        //strBody.Append("<tr><td align='left' colspan='6'>" + objInvestigation.Personal_Job_Comment + "</td></tr>");
        //strBody.Append("<tr><td align='left' colspan='6'>Conclusions/Impressions</td></tr>");
        //strBody.Append("<tr><td align='left' colspan='6'>" + objInvestigation.Conclusions + "</td></tr>");
        //strBody.Append("<tr><td align='left' width='18%' valign='top'>OSHA Recordable</td><td align='center' width='4%' valign='top'>:</td>");
        //strBody.Append("<td colspan='4' valign='top'>" + clsGeneral.FormatYesNoToDisplayForView(objInvestigation.OSHA_Recordable) + "</td></tr>");
        //strBody.Append("<tr><td align='left' colspan='6'><table cellpadding='0' cellspacing='0' border='0' width='100%'" + strFontStyle + ">");
        //strBody.Append("<tr><td align='left' style='width:18%'>Sonic Cause Code</td><td align='center' style='width:4%'>:</td>");
        //strBody.Append("<td align='left' colspan='4'>" + objInvestigation.Sonic_Cause_Code + "</td></tr></table></td></tr>");

        //strBody.Append("</table>");

        //#endregion

        //#region "Corrective Actions"

        //strBody.Append("<div style='" + bandHeaderRow + "'>&nbsp;Corrective Actions</div>");
        //strBody.Append("<table cellpadding='3' cellspacing=1 border=0 width='100%'" + strFontStyle + ">");
        //strBody.Append("<tr><td align='left' colspan='6'>Description</td></tr>");
        //strBody.Append("<tr><td align='left' colspan='6'>" + objInvestigation.Corrective_Action_Description + "</td></tr>");
        //strBody.Append("<tr><td align='left' width='18%'>Assigned To</td><td align='center' width='4%'>:</td>");
        //strBody.Append("<td align='left' width='28%'>" + objInvestigation.Assigned_To + "</td>");
        //strBody.Append("<td align='left' width='18%'>Assigned By</td><td align='center' width='4%'>:</td>");
        //strBody.Append("<td align='left' width='28%'>" + objInvestigation.AssignedBy + "</td></tr>");
        //strBody.Append("<tr><td align='left'>To Be Completed by</td><td align='center'>:</td>");
        //strBody.Append("<td align='left'>" + clsGeneral.FormatDateToDisplay(objInvestigation.To_Be_Competed_by) + "</td>");
        //strBody.Append("<td align='left'>Status</td><td align='center'>:</td>");
        //strBody.Append("<td align='left'>" + objInvestigation.Status + "</td></tr>");
        //strBody.Append("<tr><td align='left' colspan='6'>Lessons Learned</td></tr>");
        //strBody.Append("<tr><td align='left' colspan='6'>" + objInvestigation.Lessons_Learned + "</td></tr>");
        //strBody.Append("</table>");

        //#endregion

        #region "Causes"

        strBody.Append("<div style='" + bandHeaderRow + "'>&nbsp;Causes</div>");
        strBody.Append("<table cellpadding='3' cellspacing=1 border=0 width='100%'" + strFontStyle + ">");
        strBody.Append("<tr><td colspan='6' width='100%'>&nbsp;</td></tr>");
        strBody.Append("<tr><td align='left'>Describe how the event occurred</td><td align='center' width='4%'>:</td>");
        strBody.Append("<td  align='left' colspan='4'>" + objInvestigation.Cause_Comment + "</td></tr>");
        if (strOperation == "edit")
        {

            if (drpFk_LU_Contributing_Factor.SelectedItem.Text == "Other" || lblContributingFactor.Text == "Other")
            {
                strBody.Append("<tr><td align='left' width='18%'>Contributing Factor</td><td align='center' width='4%'>:</td>");
                strBody.Append("<td align='left' width='28%'>" + new clsLU_Contributing_Factor((decimal)objInvestigation.FK_LU_Contributing_Factor).Field_Description + "</td>");
                strBody.Append("<td align='left' width='18%'>Contributing Factor - Other</td><td align='center' width='4%'>:</td>");
                strBody.Append("<td align='left' width='28%'>" + objInvestigation.Contributing_Factor_Other + "</td></tr>");
            }
            else
            {
                strBody.Append("<tr><td align='left' style='width:18%'>Contributing Factor</td><td align='center' style='width:4%'>:</td>");
                if (drpFk_LU_Contributing_Factor.SelectedIndex > 0)
                {
                    strBody.Append("<td align='left' colspan='4'>" + new clsLU_Contributing_Factor((decimal)objInvestigation.FK_LU_Contributing_Factor).Field_Description + "</td></tr>");
                }
                else
                {
                    strBody.Append("<td align='left' colspan='4'>" + string.Empty + "</td></tr>");
                }
            }

            strBody.Append("</table></td></tr>");
        }
        else
        {
            if (lblContributingFactor.Text == "Other")
            {
                strBody.Append("<tr><td align='left' width='18%'>Contributing Factor</td><td align='center' width='4%'>:</td>");
                strBody.Append("<td align='left' width='28%'>" + new clsLU_Contributing_Factor((decimal)objInvestigation.FK_LU_Contributing_Factor).Field_Description + "</td>");
                strBody.Append("<td align='left' width='18%'>Contributing Factor - Other</td><td align='center' width='4%'>:</td>");
                strBody.Append("<td align='left' width='28%'>" + objInvestigation.Contributing_Factor_Other + "</td></tr>");
            }
            else
            {
                strBody.Append("<tr><td align='left' style='width:18%'>Contributing Factor</td><td align='center' style='width:4%'>:</td>");
                if (objInvestigation.FK_LU_Contributing_Factor != null)
                {
                    strBody.Append("<td align='left' colspan='4'>" + new clsLU_Contributing_Factor((decimal)objInvestigation.FK_LU_Contributing_Factor).Field_Description + "</td></tr>");
                }
                else
                {
                    strBody.Append("<td align='left' colspan='4'>" + string.Empty + "</td></tr>");
                }
            }

            strBody.Append("</table></td></tr>");
        }

        strBody.Append("<tr><td align='left'>What is the Cause of this Incident?</td><td align='center' width='4%'>:</td><td align='left' colspan='4'>" + objInvestigation.Focus_Area + "</td></tr>");
        strBody.Append("</table>");

        #endregion

        #region  "Root Cause Determination "

        strBody.Append("<div style='" + bandHeaderRow + "'>&nbsp;Root Cause Determination</div>");
        strBody.Append("<table cellpadding='3' cellspacing=1 border=0 width='100%'" + strFontStyle + ">");
        DataSet dsRootCause = clsInvestigation_Cause_Information.SelectByInvestigationID(Convert.ToDecimal(PK_Investigation_ID));
        DataTable dtroot = dsRootCause.Tables[0];

        #region "Cause Deter"

        StringBuilder sbRootCausequestion = new StringBuilder();
        sbRootCausequestion.Append("<table cellpadding='0' cellspacing='0' width='100%'" + strFontStyle + ">");
        foreach (DataRow dr in dtroot.Rows)
        {
            string response = Convert.ToString(dr["Response"]) == "Y" ? "Yes" : "No";
            sbRootCausequestion.Append("<tr><td width='70%' valign='Top' align='left'>" + Convert.ToString(dr["Question"]) + "</td><td valign='Top' align='center' width='4%'>:</td><td align='left' valign='Top'>" + response + "</td></tr>");
        }
        sbRootCausequestion.Append("</table>");
        strBody.Append("<tr><td align='left' valign='Top'>Root Cause Determination</td><td valign='Top' align='center' width='4%'>:</td><td align='left' colspan='4'>" + sbRootCausequestion.ToString() + "</td></tr>");
        #endregion

        #region "Cause Deter Reference"

        StringBuilder sbRootCauseGuidance = new StringBuilder();
        sbRootCauseGuidance.Append("<table cellpadding='0' cellspacing='0' width='100%'" + strFontStyle + ">");
        foreach (DataRow dr in dtroot.Rows)
        {
            sbRootCauseGuidance.Append("<tr><td align='left'>" + dr["Guidance"] + "</td></tr>");
        }
        sbRootCauseGuidance.Append("</table>");

        strBody.Append("<tr><td align='left' valign='Top'>Recommendation(s) to Prevent Reoccurrence</td><td valign='Top' align='center' width='4%'>:</td><td align='left' colspan='4'>" + sbRootCauseGuidance.ToString() + "</td></tr>");
        #endregion
        strBody.Append("<tr><td align='left' valign='Top'>What is your impression/conclusion on how the event occurred?</td><td valign='Top' align='center' width='4%'>:</td><td  valign='Top' align='left' colspan='4'>" + objInvestigation.Conclusions + "</td></tr>");

        strBody.Append("<tr><td align='left' width='18%' valign='top'>OSHA Recordable</td><td align='center' width='4%' valign='top'>:</td>");
        strBody.Append("<td colspan='4' valign='top'>" + clsGeneral.FormatYesNoToDisplayForView(objInvestigation.OSHA_Recordable) + "</td></tr>");
        strBody.Append("<tr><td align='left' colspan='6'><table cellpadding='0' cellspacing='0' border='0' width='100%'" + strFontStyle + ">");
        strBody.Append("<tr><td align='left' style='width:18%'>Sonic Cause Code</td><td align='center' style='width:4%'>:</td>");
        strBody.Append("<td align='left' colspan='4'>" + objInvestigation.Sonic_Cause_Code + "</td></tr></table></td></tr>");

        strBody.Append("</table>");

        #endregion

        #region "Corrective Actions"

        strBody.Append("<div style='" + bandHeaderRow + "'>&nbsp;Corrective Actions</div>");
        strBody.Append("<table cellpadding='3' cellspacing=1 border=0 width='100%'" + strFontStyle + ">");
        strBody.Append("<tr><td align='left' valign='Top'>What has been done to prevent a similar accident from happening again?</td><td valign='Top' align='center' width='4%'>:</td><td valign='top' align='left' colspan='4'>" + objInvestigation.Lessons_Learned + "</td></tr>");
        strBody.Append("<tr><td align='left' width='18%'>Assigned To</td><td align='center' width='4%'>:</td>");
        strBody.Append("<td align='left' width='28%'>" + objInvestigation.Assigned_To + "</td>");
        strBody.Append("<td align='left' width='18%'>Assigned By</td><td align='center' width='4%'>:</td>");
        strBody.Append("<td align='left' width='28%'>" + objInvestigation.AssignedBy + "</td></tr>");
        strBody.Append("<tr><td align='left'>To Be Completed by</td><td align='center'>:</td>");
        strBody.Append("<td align='left'>" + clsGeneral.FormatDateToDisplay(objInvestigation.To_Be_Competed_by) + "</td>");
        strBody.Append("<td align='left'>Status</td><td align='center'>:</td>");
        strBody.Append("<td align='left'>" + objInvestigation.Status + "</td></tr>");
        string communicated = Convert.ToString(objInvestigation.Communicated) == "Y" ? "Yes" : "No";
        strBody.Append("<tr><td align='left' colspan='4'>Have the above changes been communicated to associates with similar job tasks?</td><td align='center'>:</td><td align='left'>" + communicated + "</td></tr>");
        strBody.Append("<tr><td align='left' >If Yes, Date Communicated</td><td align='center'>:</td><td align='left'>" + clsGeneral.FormatDBNullDateToDisplay(objInvestigation.Date_Communicated) + "</td></tr>");
        strBody.Append("<tr><td align='left' valign='Top'>If No, Explain Why</td><td valign='Top' align='center' width='4%'>:</td><td align='left' colspan='4'>" + objInvestigation.No_Communication_Explanation + "</td></tr>");
        strBody.Append("</table>");

        #endregion

        #region "Review"

        strBody.Append("<div style='" + bandHeaderRow + "'>&nbsp;Review</div>");
        strBody.Append("<table cellpadding='3' cellspacing=1 border=0 width='100%'" + strFontStyle + ">");
        strBody.Append("<tr><td align='left' colspan='3'>Regional Loss Control Manager</td></tr>");
        strBody.Append("<tr><td align='left' width='25%'>Cause Codes Reviewed/Approved</td><td align='center' width='4%'>:</td>");
        strBody.Append("<td align='left'>" + clsGeneral.FormatDateToDisplay(objInvestigation.Cause_Reviewed) + "</td></tr>");
        strBody.Append("<tr><td align='left'>Corrective Actions Reviewed/Approved</td><td align='center'>:</td>");
        strBody.Append("<td align='left' colspan='4'>" + clsGeneral.FormatDateToDisplay(objInvestigation.Action_Reviewed) + "</td></tr>");
        strBody.Append("<tr><td align='left'>RLCM Comments</td><td align='center'>:</td>");
        strBody.Append("<tr><td align='left' colspan='4'>" + objInvestigation.RLCM_Comments + "</td>");
        strBody.Append("<tr><td align='left'>Date Review Completed by RLCM</td><td align='center'>:</td>");
        strBody.Append("<td align='left' colspan='4'>" + clsGeneral.FormatDBNullDateToDisplay(objInvestigation.Date_RLCM_Review_Completed) + "</td></tr>");
        strBody.Append("<tr><td align='left'>Incident Review Lag Time (in days)</td><td align='center'>:</td>");
        strBody.Append("<td align='left' colspan='4'>" + objInvestigation.Lag_Time + "</td></tr>");

        strBody.Append("<tr>");
        strBody.Append("<td colspan='3' align='left'>");
        strBody.Append("<table cellpadding='3' cellspacing=1 border=0 width='100%'" + strFontStyle + ">");
        strBody.Append("<tr>");
        strBody.Append("<td colspan='3' align='left'>");
        strBody.Append("<b>Investigative Quality Scoring Guidelines</b>");
        strBody.Append("</td>");
        strBody.Append("</tr>");
        strBody.Append("<tr>");
        strBody.Append("<td align='left' width='40%'>Was the store�s investigation completed within 7 days of the Date of Loss?");
        strBody.Append("</td>");
        strBody.Append("<td align='center' width='2%'>:");
        strBody.Append("</td>");
        strBody.Append("<td align='left' width='38%'>");
        strBody.Append(objInvestigation.Timing != "" ? objInvestigation.Timing == "Y" ? "Yes" : "No" : "");
        strBody.Append("</td>");
        strBody.Append("</tr>");
        strBody.Append("<tr>");
        strBody.Append("<td colspan='3' align='left'>");
        strBody.Append("<table cellpadding='3' cellspacing=1 border=0 width='100%'" + strFontStyle + ">");
        strBody.Append("<tr>");
        strBody.Append("<td align='left' width='8%' >Comments");
        strBody.Append("</td>");
        strBody.Append("<td align='center' width='2%' >:");
        strBody.Append("</td>");
        strBody.Append("<td align='left' width='90%'>");
        strBody.Append(objInvestigation.Timing_Comment);
        strBody.Append("</td>");
        strBody.Append("</tr>");
        strBody.Append("</table>");
        strBody.Append("</td>");
        strBody.Append("</tr>");
        strBody.Append("<tr>");
        strBody.Append("<td align='left'>Was a member of the SLT involved in the initial investigation?");
        strBody.Append("</td>");
        strBody.Append("<td align='center'>:");
        strBody.Append("</td>");
        strBody.Append("<td align='left'>");
        strBody.Append(objInvestigation.SLT_Involvement != "" ? objInvestigation.SLT_Involvement == "Y" ? "Yes" : "No" : "");
        strBody.Append("</td>");
        strBody.Append("</tr>");
        strBody.Append("<tr>");
        strBody.Append("<td colspan='3' align='left'>");
        strBody.Append("<table cellpadding='3' cellspacing=1 border=0 width='100%'" + strFontStyle + ">");
        strBody.Append("<tr>");
        strBody.Append("<td align='left' width='8%' >Comments");
        strBody.Append("</td>");
        strBody.Append("<td align='center' width='2% '>:");
        strBody.Append("</td>");
        strBody.Append("<td align='left' width='90%'>");
        strBody.Append(objInvestigation.SLT_Involvement_Comment);
        strBody.Append("</td>");
        strBody.Append("</tr>");
        strBody.Append("</table>");
        strBody.Append("</td>");
        strBody.Append("</tr>");
        strBody.Append("<tr>");
        strBody.Append("<td align='left'>Were all the facts of the incident gathered and presented clearly (i.e. incident description, work conditions, witness statements, etc.)? ");
        strBody.Append("</td>");
        strBody.Append("<td align='center'>:");
        strBody.Append("</td>");
        strBody.Append("<td align='left'>");
        strBody.Append(objInvestigation.Witnesses != "" ? objInvestigation.Witnesses == "Y" ? "Yes" : "No" : "");
        strBody.Append("</td>");
        strBody.Append("</tr>");
        strBody.Append("<tr>");
        strBody.Append("<td colspan='3' align='left'>");
        strBody.Append("<table cellpadding='3' cellspacing=1 border=0 width='100%'" + strFontStyle + ">");
        strBody.Append("<tr>");
        strBody.Append("<td align='left' width='8%' >Comments");
        strBody.Append("</td>");
        strBody.Append("<td align='center' width='2%' >:");
        strBody.Append("</td>");
        strBody.Append("<td align='left' width='90%'>");
        strBody.Append(objInvestigation.Witnesses_Comment);
        strBody.Append("</td>");
        strBody.Append("</tr>");
        strBody.Append("</table>");
        strBody.Append("</td>");
        strBody.Append("</tr>");
        strBody.Append("<tr>");
        strBody.Append("<td align='left'>Were the true root cause(s) identified correctly? ");
        strBody.Append("</td>");
        strBody.Append("<td align='center'>:");
        strBody.Append("</td>");
        strBody.Append("<td align='left'>");
        strBody.Append(objInvestigation.SLT_Visit != "" ? objInvestigation.SLT_Visit == "Y" ? "Yes" : "No" : "");
        strBody.Append("</td>");
        strBody.Append("</tr>");
        strBody.Append("<tr>");
        strBody.Append("<td colspan='3' align='left'>");
        strBody.Append("<table cellpadding='3' cellspacing=1 border=0 width='100%'" + strFontStyle + ">");
        strBody.Append("<tr>");
        strBody.Append("<td align='left' width='8%'>Comments");
        strBody.Append("</td>");
        strBody.Append("<td align='center' width='2%'>:");
        strBody.Append("</td>");
        strBody.Append("<td align='left' width='90%'>");
        strBody.Append(objInvestigation.SLT_Visit_Comment);
        strBody.Append("</td>");
        strBody.Append("</tr>");
        strBody.Append("</table>");
        strBody.Append("</td>");
        strBody.Append("</tr>");
        strBody.Append("<tr>");
        strBody.Append("<td align='left'>Was an action plan implemented to prevent similar incidents from reoccurring?");
        strBody.Append("</td>");
        strBody.Append("<td align='center'>:");
        strBody.Append("</td>");
        strBody.Append("<td align='left'>");
        strBody.Append(objInvestigation.Root_Causes != "" ? objInvestigation.Root_Causes == "Y" ? "Yes" : "No" : "");
        strBody.Append("</td>");
        strBody.Append("</tr>");
        strBody.Append("<tr>");
        strBody.Append("<td colspan='3' align='left'>");
        strBody.Append("<table cellpadding='3' cellspacing=1 border=0 width='100%'" + strFontStyle + ">");
        strBody.Append("<tr>");
        strBody.Append("<td align='left' width='8%' >Comments");
        strBody.Append("</td>");
        strBody.Append("<td align='center' width='2%'>:");
        strBody.Append("</td>");
        strBody.Append("<td align='left' width='90%'>");
        strBody.Append(objInvestigation.Root_Causes_Comment);
        strBody.Append("</td>");
        strBody.Append("</tr>");
        strBody.Append("</table>");
        strBody.Append("</td>");
        strBody.Append("</tr>");
        strBody.Append("<tr>");
        strBody.Append("<td align='left'>Was the action plan effectively communicated to the associates?");
        strBody.Append("</td>");
        strBody.Append("<td align='center'>:");
        strBody.Append("</td>");
        strBody.Append("<td align='left'>");
        strBody.Append(objInvestigation.Action_Plan != "" ? objInvestigation.Action_Plan == "Y" ? "Yes" : "No" : "");
        strBody.Append("</td>");
        strBody.Append("</tr>");
        strBody.Append("<tr>");
        strBody.Append("<td colspan='3' align='left'>");
        strBody.Append("<table cellpadding='3' cellspacing=1 border=0 width='100%'" + strFontStyle + ">");
        strBody.Append("<tr>");
        strBody.Append("<td align='left' width='8%' >Comments");
        strBody.Append("</td>");
        strBody.Append("<td align='center' width='2%'>:");
        strBody.Append("</td>");
        strBody.Append("<td align='left' width='90%'>");
        strBody.Append(objInvestigation.Action_Plan_Comment);
        strBody.Append("</td>");
        strBody.Append("</tr>");
        strBody.Append("</table>");
        strBody.Append("</td>");
        strBody.Append("</tr>");
        strBody.Append("</table>");
        strBody.Append("</td>");
        strBody.Append("</tr>");
        strBody.Append("<tr><td align='left'>Investigative Quality</td><td align='center'>:</td>");
        strBody.Append("<td align='left' colspan='4'>" + objInvestigation.Investigative_Quality + "</td></tr>");
        strBody.Append("<tr><td align='left'>RLCM Complete</td><td align='center'>:</td><td align='left' colspan='6'>" + GetYesNo(objInvestigation.RLCM_Complete) + "</td></tr>");
        strBody.Append("</table>");

        #endregion

        strBody.Append("</body></html>");

        return strBody.ToString();
    }

    /// <summary>
    /// Method -Get yes or no
    /// </summary>
    /// <param name="objBool"></param>
    /// <returns></returns>
    private string GetYesNo(object objBool)
    {
        return clsGeneral.FormatYesNoToDisplayForView(objBool);
    }

    void Upload_File(string strValue)
    {
        //Insert values into Property_FR_Attachment table
        CtrlAttachment.Add(clsGeneral.Tables.Investigation, PK_Investigation_ID);

        // Used to Bind Grid with Attached Data
        CtrlAttachDetails.Bind();

        Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(4);", true);
    }

    /// <summary>
    /// Bind sonic cause code drop-down.
    /// </summary>
    public void BindCause_Code_Determination()
    {
        ddlSonic_Cause_Code.Items.Clear();
        ddlSonic_Cause_Code.Items.Add(new ListItem("--SELECT--"));
        ddlSonic_Cause_Code.Items.Add(new ListItem("S0-1 - Strain, Sprain or Repetitive Motion"));
        ddlSonic_Cause_Code.Items.Add(new ListItem("S0-2 - Slip, Trip, or Fall"));
        ddlSonic_Cause_Code.Items.Add(new ListItem("S0-3 - Vehicle Related (included Golf Cart)"));
        ddlSonic_Cause_Code.Items.Add(new ListItem("S0-4 - Struck By an Object or Struck an Object"));
        ddlSonic_Cause_Code.Items.Add(new ListItem("S0-5 - Miscellaneous"));
        ddlSonic_Cause_Code.Items.Add(new ListItem("S1 - Strain, Sprain or Repetitive Motion"));
        ddlSonic_Cause_Code.Items.Add(new ListItem("S2 - Slip, Trip, or Fall"));
        ddlSonic_Cause_Code.Items.Add(new ListItem("S3 - Vehicle Related (included Golf Cart)"));
        ddlSonic_Cause_Code.Items.Add(new ListItem("S4 - Struck By an Object or Struck an Object"));
        ddlSonic_Cause_Code.Items.Add(new ListItem("S5 - Miscellaneous"));
        ddlSonic_Cause_Code.Items.Add(new ListItem("S-1 Denied"));
        ddlSonic_Cause_Code.Items.Add(new ListItem("S-2 Denied"));
        ddlSonic_Cause_Code.Items.Add(new ListItem("S-3 Denied"));
        ddlSonic_Cause_Code.Items.Add(new ListItem("S-4 Denied"));
        ddlSonic_Cause_Code.Items.Add(new ListItem("S-5 Denied"));
    }

    /// <summary>
    /// Slipping Enable/Disable based on Cause Code Determination #Issue 3817 Part 2
    /// </summary>
    private void ChangeSlippingValue(bool bEdit)
    {
        if (ddlSonic_Cause_Code.SelectedValue.Contains("S0-2") || ddlSonic_Cause_Code.SelectedValue.Contains("S2"))
        {
            rdoSlipping.Enabled = true;
            if (!bEdit)
                rdoSlipping.SelectedValue = "N";
        }
        else
        {
            rdoSlipping.Enabled = false;
            if (!bEdit)
                rdoSlipping.ClearSelection();
        }
    }
    #endregion

    #region Dynamic Validations
    /// <summary>
    /// Set all Validations
    /// </summary>
    private void SetValidations()
    {
        //  string strCtrlsIDs = "";
        // string strMessages = "";
        string strCorrectiveIDs = "";
        string strCorrectiveMessages = "";
        string strReviewIDs = "";
        string strReviewMessages = "";
        string strRootCauseIDs = "";
        string strRootCauseErrormsg = "";

        #region "Causes (This fields are transfered to Root Cause Determination ticket no. 3503)"
        DataTable dtFields = clsScreen_Validators.SelectByScreen(133).Tables[0];
        dtFields.DefaultView.RowFilter = "IsRequired = '1'";
        dtFields = dtFields.DefaultView.ToTable();

        Label MenuAsterisk2 = (Label)mnuProperty.Controls[1].FindControl("MenuAsterisk");
        MenuAsterisk2.Style["display"] = (dtFields.Select("LeftMenuIndex = 2").Length > 0) ? "inline-block" : "none";

        foreach (DataRow drField in dtFields.Rows)
        {
            #region " set validation control IDs and messages "
            switch (Convert.ToString(drField["Field_Name"]))
            {
                //case "Describe how the event occurred":
                //    strRootCauseIDs += "ctl00_ContentPlaceHolder1_txtCause_Comment_txtNote,";
                //    strRootCauseErrormsg += "Please enter [Causes]/Describe how the event occurred" + ",";
                //    Span2.Style["display"] = "inline-block";
                //    break;
                //case "What could the associate have done differently to avoid the incident?":
                //    strCtrlsIDs += "ctl00_ContentPlaceHolder1_txtPersonal_Job_Comment_txtNote,";
                //    strMessages += "Please enter [Causes]/What could the associate have done differently to avoid the incident?" + ",";
                //    Span4.Style["display"] = "inline-block";
                //    break;
                //case "What is your Conclusion/Impression of how the event occurred?":
                //    strCtrlsIDs += "ctl00_ContentPlaceHolder1_txtCause_Comment_txtNote,";
                //    strMessages += "Please enter [Causes]/What is your Conclusion/Impression of how the event occurred?" + ",";
                //    Span1.Style["display"] = "inline-block";
                //    break;
                //case "What is the Nature of this Incident?":
                //    strRootCauseIDs += drpCauseOfIncident.ClientID + ",";
                //    strRootCauseErrormsg += "Please select [Causes]/What is the Nature of this Incident?" + ",";
                //    span101.Style["display"] = "inline-block";
                //    break;
                //case "Contributing Factor":
                //    strRootCauseIDs += drpFk_LU_Contributing_Factor.ClientID + ",";
                //    strRootCauseErrormsg += "Please select [Causes]/Contributing Factor" + ",";
                //    Span17.Style["display"] = "inline-block";
                //    break;
                //case "OSHA Recordable":
                //    strCtrlsIDs += hdnOSHARecordable.ClientID + ",";
                //    strMessages += "Please select [Causes]/OSHA Recordable" + ",";
                //    Span19.Style["display"] = "inline-block";
                //    break;
            }
            #endregion
        }
        //strCtrlsIDs = strCtrlsIDs.TrimEnd(',');
        //strMessages = strMessages.TrimEnd(',');

        //hdnControlIDs.Value = strCtrlsIDs;
        //hdnErrorMsgs.Value = strMessages;
        #endregion


        #region "Root Cause Determination"
        dtFields = clsScreen_Validators.SelectByScreen(217).Tables[0];
        dtFields.DefaultView.RowFilter = "IsRequired = '1'";
        dtFields = dtFields.DefaultView.ToTable();

        Label MenuAsterisk5 = (Label)mnuProperty.Controls[1].FindControl("MenuAsterisk");
        MenuAsterisk5.Style["display"] = (dtFields.Select("LeftMenuIndex = 5").Length > 0) ? "inline-block" : "none";

        foreach (DataRow drField in dtFields.Rows)
        {
            #region " set validation control IDs and messages "
            switch (Convert.ToString(drField["Field_Name"]))
            {

                case "What is your impression/conclusion on how the event occurred?":
                    strRootCauseIDs += "ctl00_ContentPlaceHolder1_txtConclusions_txtNote,";
                    strRootCauseErrormsg += "Please enter [Causes]/What is your impression/conclusion on how the event occurred?" + ",";
                    Span1.Style["display"] = "inline-block";
                    break;
                case "Cause Code Determination":
                    strRootCauseIDs += ddlSonic_Cause_Code.ClientID + ",";
                    strRootCauseErrormsg += "Please select [Causes]/Cause Code Determination" + ",";
                    Span3.Style["display"] = "inline-block";
                    break;
                //case "Root Cause Determination":
                //    strRootCauseIDs += rptRootCauseDetermination.ClientID + ",";
                //    strRootCauseErrormsg += "Please select [Causes]/Root Cause Determination " + ",";
                //    Span4.Style["display"] = "inline-block";
                //    break;
                case "OSHA Recordable":
                    strRootCauseIDs += hdnOSHARecordable.ClientID + ",";
                    strRootCauseErrormsg += "Please select [Causes]/OSHA Recordable" + ",";
                    Span19.Style["display"] = "inline-block";
                    break;

                case "Describe how the event occurred":
                    strRootCauseIDs += "ctl00_ContentPlaceHolder1_txtCause_Comment_txtNote,";
                    strRootCauseErrormsg += "Please enter [Causes]/Describe how the event occurred" + ",";
                    Span2.Style["display"] = "inline-block";
                    break;

                case "What is the Nature of this Incident?":
                    strRootCauseIDs += drpCauseOfIncident.ClientID + ",";
                    strRootCauseErrormsg += "Please select [Causes]/What is the Nature of this Incident?" + ",";
                    span101.Style["display"] = "inline-block";
                    break;
                case "Contributing Factor":
                    strRootCauseIDs += drpFk_LU_Contributing_Factor.ClientID + ",";
                    strRootCauseErrormsg += "Please select [Causes]/Contributing Factor" + ",";
                    Span17.Style["display"] = "inline-block";
                    break;
                case "Nature of Injury":
                    strRootCauseIDs += ddlFK_Nature_Of_Injury.ClientID + ",";
                    strRootCauseErrormsg += "Please select [Causes]/Nature of Injury" + ",";
                    Span27.Style["display"] = "inline-block";
                    break;
                case "Body Part Affected":
                    strRootCauseIDs += ddlFK_Body_Parts_Affected.ClientID + ",";
                    strRootCauseErrormsg += "Please select [Causes]/Body Part Affected" + ",";
                    Span28.Style["display"] = "inline-block";
                    break;
            }
            #endregion
        }
        strRootCauseIDs = strRootCauseIDs.TrimEnd(',');
        strRootCauseErrormsg = strRootCauseErrormsg.TrimEnd(',');

        hdnRootCauseIDs.Value = strRootCauseIDs;
        hdnRootCauseErrormsg.Value = strRootCauseErrormsg;
        #endregion

        #region "Corrective Actions"
        dtFields = clsScreen_Validators.SelectByScreen(134).Tables[0];
        dtFields.DefaultView.RowFilter = "IsRequired = '1'";
        dtFields = dtFields.DefaultView.ToTable();

        Label MenuAsterisk3 = (Label)mnuProperty.Controls[2].FindControl("MenuAsterisk");
        MenuAsterisk3.Style["display"] = (dtFields.Select("LeftMenuIndex = 3").Length > 0) ? "inline-block" : "none";

        foreach (DataRow drField in dtFields.Rows)
        {
            #region " set validation control IDs and messages "
            switch (Convert.ToString(drField["Field_Name"]))
            {
                //case "Description�":
                //    strCorrectiveIDs += "ctl00_ContentPlaceHolder1_txtCorrective_Action_Description_txtNote,";
                //    strCorrectiveMessages += "Please enter [Corrective Actions]/Description�" + ",";
                //    //if (chkLocInfoComplete.Checked == true)
                //    //Span5.Style["display"] = "inline-block";
                //    //else Span5.Style["display"] = "none";
                //    break;
                case "Assigned To":
                    strCorrectiveIDs += txtAssigned_To.ClientID + ",";
                    strCorrectiveMessages += "Please enter [Corrective Actions]/Assigned To" + ",";
                    //if (chkLocInfoComplete.Checked == true)
                    Span6.Style["display"] = "inline-block";
                    //else Span6.Style["display"] = "none";
                    break;
                case "Assigned By":
                    strCorrectiveIDs += txtAssigned_By.ClientID + ",";
                    strCorrectiveMessages += "Please enter [Corrective Actions]/Assigned By" + ",";
                    //if (chkLocInfoComplete.Checked == true)
                    Span7.Style["display"] = "inline-block";
                    //else Span7.Style["display"] = "none";
                    break;
                case "To Be Completed by":
                    strCorrectiveIDs += txtTo_Be_Competed_by.ClientID + ",";
                    strCorrectiveMessages += "Please enter [Corrective Actions]/To Be Completed by" + ",";
                    //if (chkLocInfoComplete.Checked == true)
                    Span8.Style["display"] = "inline-block";
                    //else Span8.Style["display"] = "none";
                    break;
                case "Status":
                    strCorrectiveIDs += ddlStatus.ClientID + ",";
                    strCorrectiveMessages += "Please select [Corrective Actions]/Status" + ",";
                    //if (chkLocInfoComplete.Checked == true)
                    Span9.Style["display"] = "inline-block";
                    //else Span9.Style["display"] = "none";
                    break;
                case "What has been done to prevent a similar accident from happening again?":
                    strCorrectiveIDs += "ctl00_ContentPlaceHolder1_txtLessons_Learned_txtNote,";
                    strCorrectiveMessages += "Please enter [Corrective Actions]/What has been done to prevent a similar accident from happening again?" + ",";
                    //if chkLocInfoComplete.Checked == true)
                    Span10.Style["display"] = "inline-block";
                    //else Span10.Style["display"] = "none";
                    break;
            }
            #endregion
        }
        strCorrectiveIDs = strCorrectiveIDs.TrimEnd(',');
        strCorrectiveMessages = strCorrectiveMessages.TrimEnd(',');

        hdnCorrectiveControlIDs.Value = strCorrectiveIDs;
        hdnCorrectiveErrorMsgs.Value = strCorrectiveMessages;
        #endregion

        #region "Review"
        dtFields = clsScreen_Validators.SelectByScreen(135).Tables[0];
        dtFields.DefaultView.RowFilter = "IsRequired = '1'";
        dtFields = dtFields.DefaultView.ToTable();

        Label MenuAsterisk4 = (Label)mnuProperty.Controls[5].FindControl("MenuAsterisk");
        MenuAsterisk4.Style["display"] = (dtFields.Select("LeftMenuIndex = 4").Length > 0) ? "inline-block" : "none";

        foreach (DataRow drField in dtFields.Rows)
        {
            #region " set validation control IDs and messages "
            switch (Convert.ToString(drField["Field_Name"]))
            {
                case "Cause Codes Reviewed/Approved":
                    strReviewIDs += txtCause_Reviewed.ClientID + "|";
                    strReviewMessages += "Please enter [Review]/Cause Codes Reviewed/Approved" + "|";
                    //if (chkLocInfoComplete.Checked == true)
                    Span11.Style["display"] = "inline-block";
                    //else Span11.Style["display"] = "none";
                    break;
                case "Corrective Actions Reviewed/Approved":
                    strReviewIDs += txtAction_Reviewed.ClientID + "|";
                    strReviewMessages += "Please enter [Review]/Corrective Actions Reviewed/Approved" + "|";
                    //if (chkLocInfoComplete.Checked == true)
                    Span12.Style["display"] = "inline-block";
                    //else Span12.Style["display"] = "none";
                    break;
                case "Was the store�s investigation completed within 7 days of the Date of Loss?":
                    strReviewIDs += rdbTime.ClientID + "|";
                    strReviewMessages += "Please select [Review]/Was the store�s investigation completed within 7 days of the Date of Loss?" + "|";
                    Span18.Style["display"] = "inline-block";
                    break;
                case "Was the SLT involved in the investigation?":
                    strReviewIDs += rdbSLT.ClientID + "|";
                    strReviewMessages += "Please select [Review]/Was the SLT involved in the investigation?" + "|";
                    Span20.Style["display"] = "inline-block";
                    break;
                case "If appropriate, were witness statements documented?":
                    strReviewIDs += rdbWitness.ClientID + "|";
                    strReviewMessages += "Please select [Review]/If appropriate, were witness statements documented?" + "|";
                    Span21.Style["display"] = "inline-block";
                    break;
                case "Was the scene of the accident visited by the SLT?":
                    strReviewIDs += rdbSLTVisit.ClientID + "|";
                    strReviewMessages += "Please select [Review]/Was the scene of the accident visited by the SLT?" + "|";
                    Span22.Style["display"] = "inline-block";
                    break;
                case "Were root cause(s) identified (who, what, where, when, why and how)?":
                    strReviewIDs += rdbRoot.ClientID + "|";
                    strReviewMessages += "Please select [Review]/Were root cause(s) identified (who, what, where, when, why and how)?" + "|";
                    Span23.Style["display"] = "inline-block";
                    break;
                case "Was the action plan implemented and shared with all affected associates?":
                    strReviewIDs += rdbActionPlan.ClientID + "|";
                    strReviewMessages += "Please select [Review]/Was the action plan implemented and shared with all affected associates?" + "|";
                    Span24.Style["display"] = "inline-block";
                    break;
                case "Investigative Quality":
                    strReviewIDs += drpInvestigative.ClientID + "|";
                    strReviewMessages += "Please enter [Review]/Investigative Quality" + "|";
                    //if (chkLocInfoComplete.Checked == true)
                    Span13.Style["display"] = "inline-block";
                    //else Span13.Style["display"] = "none";
                    break;
            }
            #endregion
        }
        strReviewIDs = strReviewIDs.TrimEnd('|');
        strReviewMessages = strReviewMessages.TrimEnd('|');

        hdnReviewIDs.Value = strReviewIDs;
        hdnReviewErrorMsgs.Value = strReviewMessages;
        #endregion
    }
    #endregion

    #region event
    /// <summary>
    /// RDOCommunicated change event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void rdoCommunicated_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rdoCommunicated.SelectedValue == "Y")
        {
            txtDateCommunicated.Enabled = true;
            txtNo_Communication_Explanation.Enabled = false;
            txtNo_Communication_Explanation.Text = "";
        }
        else
        {
            txtNo_Communication_Explanation.Enabled = true;
            txtDateCommunicated.Enabled = false;
            txtDateCommunicated.Text = "";
        }

    }

    /// <summary>
    /// On change of Cause Code from what was previously saved, automatically start the OSHA wizard
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ddlSonic_Cause_Code_SelectedIndexChanged(object sender, EventArgs e)
    {
        ChangeSlippingValue(false);

        if (hdnOriginalSonicCode.Value != ddlSonic_Cause_Code.SelectedItem.Text && ddlSonic_Cause_Code.SelectedItem.Text.IndexOf("--SELECT--") == -1)
        {
            ScriptManager.RegisterStartupScript(Page, GetType(), DateTime.Now.ToString(), "javascript:OpenWizardPopup();", true);
        }
    }

    /// <summary>
    /// On change of What is the Nature of this Incident? 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void drpCauseOfIncident_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataSet ds = null;

        if ((hdnFocusArea.Value.ToString() == drpCauseOfIncident.SelectedItem.Text) || (string.IsNullOrEmpty(hdnFocusArea.Value) && Convert.ToInt32(drpCauseOfIncident.SelectedValue) > 0))
        {
            ds = clsInvestigation_Cause_Information.SelectByInvestigationID(Convert.ToDecimal(PK_Investigation_ID));
            if (ds == null || ds.Tables[0].Rows.Count <= 0)
            {
                ds = Investigation.SelectAllCauseCodeInformationByMasterNode(Convert.ToInt32(drpCauseOfIncident.SelectedValue));
            }

        }
        else { ds = Investigation.SelectAllCauseCodeInformationByMasterNode(Convert.ToInt32(drpCauseOfIncident.SelectedValue)); }


        rptRootCauseDetermination.DataSource = ds;
        rptRootCauseDetermination.DataBind();
        rptRootCauseDeterminationRecmndation.DataSource = ds;
        rptRootCauseDeterminationRecmndation.DataBind();

        PK_Focus_Area = clsGeneral.GetInt(drpCauseOfIncident.SelectedValue);


        #region ::ReBind sonic cause code drop down by cause of incident::

        BindCause_Code_Determination();

        if (PK_Focus_Area > 0)
        {
            for (int i = ddlSonic_Cause_Code.Items.Count - 1; i > 0; i--)
            {
                if (ddlSonic_Cause_Code.Items[i].Value.Contains("S0-" + PK_Focus_Area + " -") || ddlSonic_Cause_Code.Items[i].Value.Contains("S" + PK_Focus_Area + " -") || ddlSonic_Cause_Code.Items[i].Value.Contains("S-" + PK_Focus_Area + ""))
                {
                    if (ddlSonic_Cause_Code.Items[i].Value.Contains("--SELECT--"))
                    {
                        ddlSonic_Cause_Code.ClearSelection();
                        ddlSonic_Cause_Code.Items[i].Selected = true;
                    }
                }
                else
                {
                    ddlSonic_Cause_Code.Items.RemoveAt(i);
                }
            }
        }
        else
        {
            for (int i = ddlSonic_Cause_Code.Items.Count - 1; i > 0; i--)
            {
                ddlSonic_Cause_Code.Items.RemoveAt(i);
            }

            ddlSonic_Cause_Code.SelectedIndex = 0;
        }

        #endregion

        ChangeSlippingValue(false);
    }

    #endregion

    protected void btnGeneratePDF_OSHA_Click(object sender, EventArgs e)
    {
        if (PK_Investigation_ID > 0)
        {
            string strFileName = "OSHA Fields Log.pdf";
            PdfConverter objPdf = new PdfConverter();
            objPdf.LicenseKey = AppConfig._strHtmltoPDFConverterKey;

            objPdf.PdfDocumentOptions.TopMargin = 20;
            objPdf.PdfDocumentOptions.LeftMargin = 20;
            objPdf.PdfDocumentOptions.RightMargin = 20;
            objPdf.PdfDocumentOptions.BottomMargin = 20;
            objPdf.PdfDocumentOptions.ShowHeader = false;
            objPdf.PdfDocumentOptions.ShowFooter = false;
            objPdf.PdfDocumentOptions.EmbedFonts = false;

            objPdf.PdfDocumentOptions.LiveUrlsEnabled = false;
            objPdf.RightToLeftEnabled = false;
            objPdf.PdfSecurityOptions.CanPrint = true;
            objPdf.PdfSecurityOptions.CanEditContent = true;
            objPdf.PdfSecurityOptions.UserPassword = "";
            objPdf.PdfDocumentOptions.PdfPageOrientation = PDFPageOrientation.Portrait;
            objPdf.PdfDocumentOptions.PdfCompressionLevel = PdfCompressionLevel.NoCompression;
            objPdf.PdfDocumentOptions.PdfPageSize = PdfPageSize.A4;

            objPdf.AvoidTextBreak = false;

            StringBuilder sbHtml = new StringBuilder();
            objPdf.PdfDocumentInfo.AuthorName = "eRIMS2";
            Byte[] pdfByte = null;

            sbHtml = getHtmlForOSHA(PK_Investigation_ID);

            pdfByte = objPdf.GetPdfBytesFromHtmlString(sbHtml.ToString());

            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.AddHeader("Content-Type", "binary/octet-stream");
            HttpContext.Current.Response.AddHeader("Content-Disposition", ("attachment; filename=" + strFileName + "; size=") + pdfByte.Length.ToString());
            HttpContext.Current.Response.Flush();
            HttpContext.Current.Response.BinaryWrite(pdfByte);
            HttpContext.Current.Response.Flush();
            HttpContext.Current.Response.End();
        }
    }

    public static StringBuilder getHtmlForOSHA(decimal _PK)
    {
        DataSet dsInvestigation = Investigation.SelectByPK(Convert.ToInt32(_PK));

        StringBuilder strBody = new StringBuilder();

        if (dsInvestigation != null && dsInvestigation.Tables.Count > 0 && dsInvestigation.Tables[0].Rows.Count > 0)
        {
            DataTable dtInvestigation = dsInvestigation.Tables[0];
            //WC_FR objWC_FR = new WC_FR(Convert.ToDecimal(dtInvestigation.Rows[0]["FK_WC_FR_ID"]));
            string strActionableEvent = string.Empty;

            //strBody.Append("<table cellpadding='3' cellspacing='1' border='1' Style='border-color:black;' width='100%'>");
            //strBody.Append("<tbody>");

            //strBody.Append("<tr>");
            //strBody.Append("<td align='left' style='width:12%'><span>Investigation ID</span></td>");
            //strBody.Append("<td align='left' style='width:14%'><span>WC First Report ID</span></td>");
            //strBody.Append("<td align='left' style='width:12%'><span>Claim Number</span></td>");
            //strBody.Append("<td align='left' style='width:17%'><span>RM Location Number</span></td>");
            //strBody.Append("<td align='left' style='width:17%'><span>SONIC Location d/b/a</span></td>");
            //strBody.Append("<td align='left' style='width:15%'><span>City</span></td>");
            //strBody.Append("<td align='left' style='width:13%'><span>State</span></td>");
            //strBody.Append("<td align='left' style='width:12%;'><span>Zip</span></td>");
            //strBody.Append("</tr>");

            //strBody.Append("<tr style='background-color:White;'>");
            //strBody.Append("<td align='left'><span>"+ dtInvestigation.Rows[0]["PK_Investigation_ID"] + "</span></td>");
            //strBody.Append("<td align='left'><span>"+ new WC_FR(Convert.ToDecimal(dtInvestigation.Rows[0]["FK_WC_FR_ID"])).WC_FR_Number.ToString()+ "</span></td>");
            //strBody.Append("<td align='left'><span>YMA C 35358</span></td>");
            //strBody.Append("<td align='left'><span>258</span></td>");
            //strBody.Append("<td align='left'><span>Beverly Hills BMW</span></td>");
            //strBody.Append("<td align='left'><span>Los Angeles</span></td>");
            //strBody.Append("<td align='left'><span>California</span></td>");
            //strBody.Append("<td align='left'><span>90036</span></td>");
            //strBody.Append("</tr>");

            //strBody.Append("</tbody>");
            //strBody.Append("</table>");

            //strBody.Append("</br></br></br></br>");

            strBody.Append("<table cellpadding='3' cellspacing='1' style='border: 1px solid Black; background-color:#9a9a9a' width='100%'>");
            strBody.Append("<tr><td style='color:black; font-weight:bold;'>OSHA Log Fields</td><tr>");
            strBody.Append("</table>");
            strBody.Append("</br>");

            strBody.Append("<table cellpadding='3' cellspacing='1' border='0' width='100 %'>");

            strBody.Append("<tr>");
            strBody.Append("<td align='left' style='width: 24 %;'>Name of Physician or Other Health Care Professional</td>");
            strBody.Append("<td align='center' style='width: 2 %;'>:</td>");
            strBody.Append("<td align='left' style='width:24%;'><Label>" + dtInvestigation.Rows[0]["Physician_Other_Professional"] + "</Label></td>");
            strBody.Append("<td align='left' style='width:24%;'>&nbsp;</td>");
            strBody.Append("<td align='center' style='width:2%;'>&nbsp;</td>");
            strBody.Append("<td align='left' style='width:24%;'>&nbsp;</td>");
            strBody.Append("</tr>");

            strBody.Append("<tr>");
            strBody.Append("<td align='left' valign='top'>If Treatment is Given Away from the Worksite, Facility Where it Was Given</td>");
            strBody.Append("<td align='center' valign='top'>:</td>");
            strBody.Append("<td align='left'><Label>" + dtInvestigation.Rows[0]["Facility"] + "</Label></td>");
            strBody.Append("<td align='left'>Treatment Facility Address</td>");
            strBody.Append("<td align='center'>:</td>");
            strBody.Append("<td align='left'><Label>" + dtInvestigation.Rows[0]["Facility_Address"] + "</Label></td>");
            strBody.Append("</tr>");

            strBody.Append("<tr>");
            strBody.Append("<td align='left'>Treatment Facility City</td>");
            strBody.Append("<td align='center'>:</td>");
            strBody.Append("<td align='left'><Label>" + dtInvestigation.Rows[0]["Facility_City"] + "</Label></td>");
            strBody.Append("<td align='left'>Treatment Facility State</td>");
            strBody.Append("<td align='center'>:</td>");
            strBody.Append("<td align='left'><Label>" + new State(String.IsNullOrEmpty(Convert.ToString(dtInvestigation.Rows[0]["FK_State_Facility"])) ? 0 : Convert.ToDecimal(dtInvestigation.Rows[0]["FK_State_Facility"])).FLD_state + "</Label></td>");
            strBody.Append("</tr>");

            strBody.Append("<tr>");
            strBody.Append("<td align='left'>Treatment Facility Zip Code (XXXXX-XXXX)</td>");
            strBody.Append("<td align='center'>:</td>");
            strBody.Append("<td align='left'><Label>" + dtInvestigation.Rows[0]["Facility_Zip_Code"] + "</Label></td>");
            strBody.Append("<td align='left'>&nbsp;</td>");
            strBody.Append("<td align='center'>&nbsp;</td>");
            strBody.Append("<td align='left'>&nbsp;</td>");
            strBody.Append("</tr>");

            strBody.Append("<tr>");
            strBody.Append("<td align='left'>Was Associate Treated in an Emergency Room?</td>");
            strBody.Append("<td align='center'>:</td>");
            strBody.Append("<td align='left'><Label>" + (dtInvestigation.Rows[0]["Emergency_Room"].ToString() == "Y" ? "Yes" : "No") + "</Label></td>");
            strBody.Append("<td align='left'>Time Associate Began Work (HH:MM)</td>");
            strBody.Append("<td align='center'>:</td>");
            strBody.Append("<td align='left'><Label>" + dtInvestigation.Rows[0]["Time_Began_Work"] + "</Label></td>");
            strBody.Append("</tr>");

            strBody.Append("<tr>");
            strBody.Append("<td align='left'>Admitted to Hospital</td>");
            strBody.Append("<td align='center'>:</td>");
            strBody.Append("<td align='left'><Label>" + (dtInvestigation.Rows[0]["Admitted_to_Hospital"].ToString() != "1" ? dtInvestigation.Rows[0]["Admitted_to_Hospital"].ToString() == "2" ? "No" : "Unknown" : "Yes") + "</Label></td>");
            strBody.Append("<td align='left'>Return to Work Date</td>");
            strBody.Append("<td align='center'>:</td>");
            strBody.Append("<td align='left'><Label> " + clsGeneral.FormatDBNullDateToDisplay(dtInvestigation.Rows[0]["Return_to_Work_Date"]) + "</Label></td>");
            strBody.Append("</tr>");

            strBody.Append("<tr>");
            strBody.Append("<td align='left' valign='top'>What was the associate doing just before the incident occurred?</td>");
            strBody.Append("<td align='center' valign='top'>:</td>");
            strBody.Append("<td align='left' colspan='4'><Label> " + dtInvestigation.Rows[0]["Activity_Before_Incident"] + " </Label></td>");
            strBody.Append("</tr>");

            strBody.Append("<tr>");
            strBody.Append("<td align='left' valign='top'>Describe any object or substance that directly harmed the associate</td>");
            strBody.Append("<td align='center' valign='top'>:</td>");
            strBody.Append("<td align='left' colspan='4'><Label>" + dtInvestigation.Rows[0]["Object_Substance_Involved"] + "</Label></td>");
            strBody.Append("</tr>");

            strBody.Append("</table>");
        }

        return strBody;
    }
}
