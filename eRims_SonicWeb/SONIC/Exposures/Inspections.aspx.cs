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
using ERIMS.DAL;
using System.IO;
using System.Text;
using Aspose.Words;


/// <summary>
/// Date : 4 OCT 2008
/// 
/// By : Hetal Prajapati
/// 
/// Purpose: 
/// To Add, update and remove the Inspection records
/// 
/// Functionality:
/// Lists the inspection records having the location selected
/// 
/// By selecting the record the page controls display information about that either in
/// edit or view mode depending on the operation passed in querystring
/// 
/// Save & View button click shows the record in view mode
/// 
/// Back button click opens the page in edit mode
/// </summary>
public partial class Exposures_Inspections : clsBasePage
{
    /// <summary>
    /// Variables
    /// </summary>
    string _strFocusArea = string.Empty;

    #region " Properties "
    /// <summary>
    /// Denotes Primary key for Inspection record
    /// </summary>
    public int _intInspectionCount
    {
        get { return Convert.ToInt32(ViewState["intInspectionCount"]); }
        set { ViewState["intInspectionCount"] = value; }
    }

    public int PK_Inspection_ID
    {
        get { return Convert.ToInt32(ViewState["PK_Inspection_ID"]); }
        set { ViewState["PK_Inspection_ID"] = value; hdnInspectionID.Value = value.ToString(); }
    }

    /// <summary>
    /// Denotes foriegn key for Location record
    /// </summary>
    public int FK_LU_Location_ID
    {
        get { return Convert.ToInt32(ViewState["FK_LU_Location_ID"]); }
        set { ViewState["FK_LU_Location_ID"] = value; }
    }

    public int FK_Inspection_Questions_ID
    {
        get { return Convert.ToInt32(ViewState["FK_Inspection_Questions_ID"]); }
        set { ViewState["FK_Inspection_Questions_ID"] = value; }
    }

    /// <summary>
    /// Denotes operation either view or edit for the page
    /// </summary>
    public string strOperation
    {
        get { return Convert.ToString(ViewState["strOperation"]); }
        set { ViewState["strOperation"] = value; }
    }

    public DataTable dt_Focus_Area
    {
        get { return (DataTable)ViewState["dt_Focus_Area"]; }
        set { ViewState["dt_Focus_Area"] = value; }
    }

    public DataTable dt_Inspection_Area
    {
        get { return (DataTable)ViewState["dt_Inspection_Area"]; }
        set { ViewState["dt_Inspection_Area"] = value; }
    }

    public int Current_Focus_Area_ID
    {
        get { return Convert.ToInt32(ViewState["Current_Focus_Area_ID"]); }
        set { ViewState["Current_Focus_Area_ID"] = value; }
    }

    public int Current_Inspection_Area_ID
    {
        get { return Convert.ToInt32(ViewState["Current_Inspection_Area_ID"]); }
        set { ViewState["Current_Inspection_Area_ID"] = value; }
    }

    public bool bEditInspection
    {
        get { return Convert.ToBoolean(ViewState["Show_Date_Name"]); }
        set { ViewState["Show_Date_Name"] = value; }
    }

    public string LocationActive
    {
        get
        {
            return clsGeneral.IsNull(ViewState["LocationActive"]) ? "Y" : ViewState["LocationActive"].ToString();
        }
        set { ViewState["LocationActive"] = value; }
    }

    private string strSortBy
    {
        get { return Convert.ToString(ViewState["strSortBy"]); }
        set { ViewState["strSortBy"] = value; }
    }

    private string strSortOrder
    {
        get { return Convert.ToString(ViewState["strSortOrder"]); }
        set { ViewState["strSortOrder"] = value; }
    }

    #endregion

    #region "Page Events"

    /// <summary>
    /// Event handled when page is loaded
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        // Set Tab selection
        Tab.SetSelectedTab(Controls_ExposuresTab_ExposuresTab.Tab.Inspection);
        if (!IsPostBack)
        {
            _intInspectionCount = 0;
            dt_Focus_Area = Inspection_Questions.SelectAllFocusAreas().Tables[0];
            //dt_Inspection_Area = Inspection_Questions.SelectAllInspectionAreas().Tables[0];
            Current_Focus_Area_ID = 1;
            Current_Inspection_Area_ID = 0;
            strSortBy = "date";
            strSortOrder = "desc";
            //tdGenerateDoc.Visible = false;
            // check if location id is passed in querystring or not
            if (Request.QueryString["loc"] != null)
            {
                int loc;
                if (int.TryParse(Encryption.Decrypt(Request.QueryString["loc"]), out loc))
                {
                    FK_LU_Location_ID = loc;
                }
                else
                    Response.Redirect("ExposureSearch.aspx");

                // store the location id in session
                Session["ExposureLocation"] = FK_LU_Location_ID;

                if (Request.QueryString["id"] != null) // check for the ID is passed or not
                {
                    int id;
                    if (int.TryParse(Encryption.Decrypt(Request.QueryString["id"]), out id))
                    {
                        PK_Inspection_ID = id;
                        strOperation = Request.QueryString["op"] != null ? Request.QueryString["op"].ToString() : "edit";
                    }
                    else
                        Response.Redirect("Inspections.aspx?loc=" + Request.QueryString["loc"]);

                }
                else
                {
                    PK_Inspection_ID = Inspection.SelectPKByFKLoc(FK_LU_Location_ID);
                    LocationActive = new LU_Location(Convert.ToDecimal(FK_LU_Location_ID)).Active;

                    if (PK_Inspection_ID > 0 || LocationActive == "N")
                        strOperation = "view";
                }
            }
            else
                Response.Redirect("ExposureSearch.aspx");

            BindDropdownFocusAreas();
            // BindDropdownInspectionAreas();
            // if Primary ID is available then Bind the page in edit or view mode depending on the operation            
            if (PK_Inspection_ID > 0 || LocationActive == "N")
            {
                if (strOperation == "view")
                {
                    BindDetailsForView();
                }
                else
                {
                    // Check if User has right To Add or View 
                    if (App_Access == AccessType.View_Only)
                    {
                        Response.Redirect(AppConfig.SiteURL + "Error.aspx?msg=errAcc", true);
                    }
                    BindDetailsForEdit();
                    SetValidations();
                }
            }
            else
            {
                // Check if User has right To Add or View 
                if (App_Access == AccessType.View_Only)
                {
                    Response.Redirect(AppConfig.SiteURL + "Error.aspx?msg=errAcc", true);
                }
                BindDropdownInspectionAreas();
                BindDetailsForAdd();
                SetValidations();
                btnViewAudit.Visible = false;
            }

            // Bind location information
            ucCtrlExposureInfo.PK_LU_Location = FK_LU_Location_ID;
            ucCtrlExposureInfo.BindExposureInfo();

            BindGridOtherInspections();
            BindGridAttachments();
            BindGridAttachmentsFocusArea();
        }
        else
        {
            string eventTarget = (this.Request["__EVENTTARGET"] == null) ? string.Empty : this.Request["__EVENTTARGET"];
            string eventArgument = (this.Request["__EVENTARGUMENT"] == null) ? string.Empty : this.Request["__EVENTARGUMENT"];

            // if postback by Confirmation dialog then save record
            if (eventTarget == "UserConfirmationPostBack")
            {
                if (eventArgument == "true")
                {

                    ClientScript.RegisterStartupScript(this.GetType(), DateTime.Now.ToString(), "alert('The Inspection Report e-mail send without the attachments.');ShowPanel(11);", true);
                }
                else
                    ClientScript.RegisterStartupScript(this.GetType(), DateTime.Now.ToString(), "alert('The Inspection Report has NOT been sent, please reduce the number and/or size of the attachments before attempting to resubmit with attachments.');ShowPanel(11);", true);

            }

        }

    }

    #endregion

    #region " GRID VIEW EVENTS "
    /// <summary>
    /// Handles the Gridview row databound event for page in edit mode 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvInspectionEdit_OnRowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            #region " GENERAL SETTINGS FOR PAGE CONTROLS TO INSERT DATA "
            // settings for hiding or showing the guidance text
            HtmlImage imgGuidance = (HtmlImage)e.Row.FindControl("imgGuidance");
            HtmlTableCell tdGuidanceText = (HtmlTableCell)e.Row.FindControl("tdGuidanceText");
            if (imgGuidance != null && tdGuidanceText != null)
            {
                tdGuidanceText.Style["display"] = "none";
                imgGuidance.Attributes.Add("onclick", "javascript:return ShowHideGuidanceText('" + imgGuidance.ClientID + "','" + tdGuidanceText.ClientID + "')");
            }

            // Bind department dropdown
            //DropDownList drpDepartment = (DropDownList)e.Row.FindControl("drpDepartment");            
            CheckBoxList chkDepartments = (CheckBoxList)e.Row.FindControl("chkDepartments");

            DataTable dtDepartment = LU_Department.SelectAll().Tables[0];
            dtDepartment.DefaultView.RowFilter = " Description not in ('General Manager', 'Controller')";
            dtDepartment = dtDepartment.DefaultView.ToTable();
            chkDepartments.DataSource = dtDepartment;
            chkDepartments.DataTextField = "Description";
            chkDepartments.DataValueField = "PK_LU_Department_ID";
            chkDepartments.DataBind();

            //ComboHelper.FillDepartment(new DropDownList[] { drpDepartment }, 0, true);

            // Settings for hiding or displaying the response details
            RadioButtonList rdoDefeciancy = (RadioButtonList)e.Row.FindControl("rdoDefeciancy");
            RadioButtonList rdoMaintenance = (RadioButtonList)e.Row.FindControl("rdoMaintenance");
            HtmlTableCell tdResponseDetails = ((HtmlTableCell)e.Row.FindControl("tdResponseDetails"));
            HtmlTableCell tdMaintDetails = ((HtmlTableCell)e.Row.FindControl("tdMaintDetails"));
            HtmlInputHidden hdnDeficientAnswer = (HtmlInputHidden)e.Row.FindControl("hdnDeficientAnswer");
            HtmlInputHidden hdnMaintenance = (HtmlInputHidden)e.Row.FindControl("hdnMaintenance");
            TextBox txtTitle = (TextBox)e.Row.FindControl("txtTitle");
            Controls_LongDescription_LongDescription txtProblemDescription = (Controls_LongDescription_LongDescription)e.Row.FindControl("txtProblemDescription");

            rdoDefeciancy.Attributes.Add("onclick", "javascript:ShowHideDetails(this.id," + tdResponseDetails.ClientID + ",'" + hdnDeficientAnswer.Value + "');");
            rdoMaintenance.Attributes.Add("onclick", "javascript:ShowHideMaintenanceDetails(this.id," + tdMaintDetails.ClientID + ",'" + hdnMaintenance.Value + "','" + txtTitle.ClientID + "','" + txtProblemDescription.ClientID + "');");

            // calendar controls settings
            HtmlImage imgDateOpened = (HtmlImage)e.Row.FindControl("imgDateOpened");
            TextBox txtDateOpn = (TextBox)e.Row.FindControl("txtDateOpened");
            TextBox txtActualComDate = (TextBox)e.Row.FindControl("txtActualCompletionDate");
            Label lblDays = (Label)e.Row.FindControl("lblDays");
            imgDateOpened.Attributes.Add("onclick", "javascript:return showCalendar('" + txtDateOpn.ClientID + "', 'mm/dd/y',ValidateDateOpened,'" + txtDateOpn.ClientID + "," + lblDays.ClientID + "," + txtActualComDate.ClientID + "');");
            txtDateOpn.Attributes.Add("onblur", "javascript:ValidateDateOpened('" + txtDateOpn.ClientID + "," + lblDays.ClientID + "," + txtActualComDate.ClientID + "');");
            txtActualComDate.Attributes.Add("onblur", "javascript:ValidateDateOpened('" + txtDateOpn.ClientID + "," + lblDays.ClientID + "," + txtActualComDate.ClientID + "');");

            HtmlImage imgTargetCompletionDate = (HtmlImage)e.Row.FindControl("imgTargetCompletionDate");
            imgTargetCompletionDate.Attributes.Add("onclick", "javascript:return showCalendar('" + ((TextBox)e.Row.FindControl("txtTargetCompleteDate")).ClientID + "', 'mm/dd/y');");

            HtmlImage imgActualCompletionDate = (HtmlImage)e.Row.FindControl("imgActualCompletionDate");
            imgActualCompletionDate.Attributes.Add("onclick", "javascript:return showCalendar('" + txtActualComDate.ClientID + "', 'mm/dd/y',ValidateDateOpened,'" + txtDateOpn.ClientID + "," + lblDays.ClientID + "," + txtActualComDate.ClientID + "');");

            #endregion

            #region " BIND DETAILS FOR EDIT "
            // if Operation for edit is available then Bind the controls
            //if ((strOperation == "edit" && bResponseDataAvailable) || bResponseDataAvailable)
            if (strOperation == "edit" || strOperation == "")
            {
                // show or hide the deficiency 
                HtmlInputHidden hdnResponseID = (HtmlInputHidden)e.Row.FindControl("hdnResponseID");
                hdnResponseID.Value = DataBinder.Eval(e.Row.DataItem, "PK_Inspection_Responses_ID").ToString();
                string strDeficiency_Noted = DataBinder.Eval(e.Row.DataItem, "Deficiency_Noted").ToString();
                string strDeficient_Answer = DataBinder.Eval(e.Row.DataItem, "Deficient_Answer").ToString();
                string strMaintenance = !string.IsNullOrEmpty(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Title"))) ? "Y" : "N";

                rdoDefeciancy.SelectedValue = strDeficiency_Noted;
                rdoMaintenance.SelectedValue = strMaintenance;

                if (strDeficiency_Noted == "Y" && strDeficient_Answer == "Y")
                {
                    tdResponseDetails.Style["display"] = "";

                    // get values for the record
                    //string strDepartment = DataBinder.Eval(e.Row.DataItem, "Department").ToString();
                    string[] strDepartments = DataBinder.Eval(e.Row.DataItem, "Department").ToString().Split(',');
                    string strDate_Opened = DataBinder.Eval(e.Row.DataItem, "Date_Opened").ToString();
                    string strRecommended_Action = DataBinder.Eval(e.Row.DataItem, "Recommended_Action").ToString();
                    string strTarget_Completion_Date = DataBinder.Eval(e.Row.DataItem, "Target_Completion_Date").ToString();
                    string strActual_Completion_Date = DataBinder.Eval(e.Row.DataItem, "Actual_Completion_Date").ToString();
                    string strNotes = DataBinder.Eval(e.Row.DataItem, "Notes").ToString();
                    string strRepeatDeficiency = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Repeat_Deficiency"));
                    // get controls
                    TextBox txtDateOpened = (TextBox)e.Row.FindControl("txtDateOpened");
                    Controls_LongDescription_LongDescription txtAction = (Controls_LongDescription_LongDescription)e.Row.FindControl("txtAction");
                    TextBox txtTargetCompleteDate = (TextBox)e.Row.FindControl("txtTargetCompleteDate");
                    TextBox txtActualCompletionDate = (TextBox)e.Row.FindControl("txtActualCompletionDate");
                    Controls_LongDescription_LongDescription txtNotes = (Controls_LongDescription_LongDescription)e.Row.FindControl("txtNotes");
                    RadioButtonList rdoRepeatDeficiency = (RadioButtonList)e.Row.FindControl("rdoRepeatDeficiency");

                    foreach (string str in strDepartments)
                    {
                        foreach (ListItem itm in chkDepartments.Items)
                        {
                            if (itm.Value == str) itm.Selected = true;
                        }
                    }

                    if (strDate_Opened != "")
                        txtDateOpened.Text = clsGeneral.FormatDateToDisplay(Convert.ToDateTime(strDate_Opened));

                    txtAction.Text = strRecommended_Action;
                    if (strTarget_Completion_Date != "")
                        txtTargetCompleteDate.Text = clsGeneral.FormatDateToDisplay(Convert.ToDateTime(strTarget_Completion_Date));

                    if (strActual_Completion_Date != "")
                        txtActualCompletionDate.Text = clsGeneral.FormatDateToDisplay(Convert.ToDateTime(strActual_Completion_Date));

                    txtNotes.Text = strNotes;

                    if (strDate_Opened != "" && strActual_Completion_Date != "")
                    {

                        DateTime dtDateOpened = Convert.ToDateTime(strDate_Opened);
                        DateTime dtDateActual = Convert.ToDateTime(strActual_Completion_Date);
                        if (dtDateOpened != AppConfig.SqlMinDateValue && dtDateActual != AppConfig.SqlMinDateValue)
                        {
                            TimeSpan ts = dtDateActual - dtDateOpened;
                            if (ts.Days >= 0)
                                lblDays.Text = ts.Days.ToString();
                        }
                    }

                    rdoRepeatDeficiency.SelectedValue = strRepeatDeficiency == "Y" ? "Y" : "N";
                }

                if (strMaintenance == "Y")
                {
                    tdMaintDetails.Style["display"] = "";
                    // get values for the record
                    string strProblemDescription = DataBinder.Eval(e.Row.DataItem, "Problem_Description").ToString();
                    string strTitle = DataBinder.Eval(e.Row.DataItem, "Title").ToString();
                    txtProblemDescription.Text = strProblemDescription;
                    txtTitle.Text = strTitle;
                    txtProblemDescription.Enable = false;
                    txtTitle.Enabled = false;
                }
            }

            if (Convert.ToString(DataBinder.Eval(e.Row.DataItem, "ShowFocusAreaRed")) == "Y")
                ((Label)e.Row.FindControl("lblFocus_Area")).Style["color"] = "red";
            #endregion
        }
    }

    /// <summary>
    /// Handles the Gridview row databound event for page in view mode 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvInspectionView_OnRowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (((GridView)sender).ID == "gvAllInspections")
            {
                Label lbl = e.Row.FindControl("lblFocus_Area") as Label;
                DataList dlAttachmentImages = (DataList)e.Row.FindControl("dlAttachmentImages");
                string strRepeatDeficiency = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Repeat_Deficiency"));

                if (_strFocusArea != lbl.Text)
                {
                    lbl.Style.Add(HtmlTextWriterStyle.Display, "block");
                    dlAttachmentImages.DataSource = Inspection_Responses_Attachments.SelectImagesByFocusArea(lbl.Text, PK_Inspection_ID);
                    dlAttachmentImages.DataBind();
                }
                else
                {
                    dlAttachmentImages.Visible = false;
                }
            }

            if (Convert.ToString(DataBinder.Eval(e.Row.DataItem, "ShowFocusAreaRed")) == "Y")
                ((Label)e.Row.FindControl("lblFocus_Area")).Style["color"] = "red";

            // settings for hiding or showing the guidance text
            HtmlImage imgGuidance = (HtmlImage)e.Row.FindControl("imgGuidance");
            HtmlTableCell tdGuidanceText = (HtmlTableCell)e.Row.FindControl("tdGuidanceText");
            if (imgGuidance != null && tdGuidanceText != null)
            {
                tdGuidanceText.Style["display"] = "none";
                imgGuidance.Attributes.Add("onclick", "javascript:return ShowHideGuidanceText('" + imgGuidance.ClientID + "','" + tdGuidanceText.ClientID + "')");
            }

            string strDeficiency_Noted = DataBinder.Eval(e.Row.DataItem, "Deficiency_Noted").ToString();
            string strDeficient_Answer = DataBinder.Eval(e.Row.DataItem, "Deficient_Answer").ToString();

            if (strDeficiency_Noted == "Y" && strDeficient_Answer == "Y")
            {
                Label lblDays = (Label)e.Row.FindControl("lblDays");

                string strDateOpened = DataBinder.Eval(e.Row.DataItem, "Date_Opened").ToString();
                string strActual_Completion_Date = DataBinder.Eval(e.Row.DataItem, "Actual_Completion_Date").ToString();
                if (strDateOpened != "" && strActual_Completion_Date != "")
                {
                    DateTime dtDateOpened = Convert.ToDateTime(strDateOpened);
                    DateTime dtDateActual = Convert.ToDateTime(strActual_Completion_Date);
                    TimeSpan ts = dtDateActual - dtDateOpened;
                    if (ts.Days > 0)
                        lblDays.Text = ts.Days.ToString();
                }

                DataList rptDepartment = (DataList)e.Row.FindControl("rptDepartment");
                DataTable dtDepartment = LU_Department.SelectAll().Tables[0];
                dtDepartment.DefaultView.RowFilter = " Description not in ('General Manager', 'Controller')";
                dtDepartment = dtDepartment.DefaultView.ToTable();
                rptDepartment.DataSource = dtDepartment;
                rptDepartment.DataBind();

                string[] strDepartment = DataBinder.Eval(e.Row.DataItem, "Department").ToString().Split(',');

                foreach (string str in strDepartment)
                {
                    foreach (DataListItem rptItm in rptDepartment.Items)
                    {
                        HtmlInputHidden hdnDeptID = (HtmlInputHidden)rptItm.FindControl("hdnDeptID");
                        Label lblValue = (Label)rptItm.FindControl("lblValue");
                        if (str == hdnDeptID.Value)
                        {
                            lblValue.Text = "Yes";
                        }
                    }
                }
            }
        }

    }

    /// <summary>
    /// Handles Inspection grid rowcommand event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvOtherInspections_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        // if passed command is for viewing details 
         if (e.CommandName == "ViewDetails")
        {
            gvAllInspections.Dispose();
            dvAllInspections.Style["display"] = "none";

            Current_Focus_Area_ID = 1;

            // get the primary key passed in command argument
            PK_Inspection_ID = Convert.ToInt32(e.CommandArgument);

            // display page in either view or edit mode
            if (strOperation == "view")
            {
                drpFocusAreasView.SelectedIndex = 0;
                hdnForDate.Value = PK_Inspection_ID.ToString();
                BindDetailsForView();
            }
            else
            {
                drpFocusAreasEdit.SelectedIndex = 0;
                if (strOperation == "") strOperation = "edit";
                hdnForDateEdit.Value = PK_Inspection_ID.ToString();
                BindDetailsForEdit();
            }
            //tdGenerateDoc.Visible = false;

        }
        else if (e.CommandName == "RemoveInspection") // if passed command is for removing inspection record
        {
            // delete inspection record using the ID passed in command argument 
            Inspection.DeleteByPK(Convert.ToInt32(e.CommandArgument));

            // bind the grid again
            BindGridOtherInspections();

            // if PK is the same as the ID passed in command argument
            if (PK_Inspection_ID == Convert.ToInt32(e.CommandArgument))
            {
                Current_Focus_Area_ID = 1;
                drpFocusAreasEdit.SelectedIndex = 0;
                // re-initialize the primary key and operation
                PK_Inspection_ID = -1;
                strOperation = "";
                // bind the details for adding new inspection record
                BindDetailsForAdd();
                BindGridAttachments();
                BindGridAttachmentsFocusArea();
            }
            //tdGenerateDoc.Visible = false;
        }
        else if (e.CommandName == "ViewAllInspections")
        {
            // get the primary key passed in command argument
            PK_Inspection_ID = Convert.ToInt32(e.CommandArgument);

            Inspection objInspection = new Inspection(PK_Inspection_ID);
            lblViewAllInspectionDate.Text = clsGeneral.FormatDateToDisplay(objInspection.date);
            lblViewAllInspectionName.Text = objInspection.Inspector_Name;
            lblRLCMVerifiedReport.Text = objInspection.RLCM_Verified == "Y" ? "Yes" : "No";
            lblNumberOfDeficiencies.Text = Inspection.GetNumberOfDeficiencies(PK_Inspection_ID).ToString();
            lblNoDeficiencyReport.Text = objInspection.No_Deficiencies ? "Yes" : "No";
            lblOverallCommentsReport.Text = objInspection.Overall_Inspection_Comments;
            lblAllInspectionArea.Text = objInspection.Fld_Desc;
            lblvwNumberofRepeatDeficiencies.Text = Inspection.GetNumberOfRepeat_Deficiency(PK_Inspection_ID).ToString();
            lblDateofInitialDistributionReportPrepare.Text = clsGeneral.FormatDBNullDateToDisplay(objInspection.Date_Report_Initially_Distibuted);
            // get all questions and response data and bind the grid
            DataTable dtInspection = Inspection.SelectQuestionsAndResposnses(PK_Inspection_ID).Tables[0];

            dtInspection.DefaultView.RowFilter = "Deficiency_Noted='Y'";
            dtInspection = dtInspection.DefaultView.ToTable();
            _intInspectionCount = dtInspection.Rows.Count;
            gvAllInspections.DataSource = dtInspection;
            gvAllInspections.DataBind();
            dvAllInspections.Style["display"] = "block";
            dvEdit.Style["display"] = "none";
            dvView.Style["display"] = "none";
            lnkAddNew.Visible = false;
            //tdGenerateDoc.Visible = true;

            GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
            int rowIndex = row.RowIndex;
            string strName = "";

            foreach (GridViewRow gRow in gvOtherInspections.Rows)
            {
                ((LinkButton)gRow.FindControl("lnkView")).Text = "Prepare";
                ((LinkButton)gRow.FindControl("lnkView")).CommandName = "ViewAllInspections";
            }
            strName = ((LinkButton)gvOtherInspections.Rows[rowIndex].FindControl("lnkView")).Text;
            if (strName == "Prepare")
            {
                ((LinkButton)gvOtherInspections.Rows[rowIndex].FindControl("lnkView")).Text = "View";
                ((LinkButton)gvOtherInspections.Rows[rowIndex].FindControl("lnkView")).CommandName = "ViewDoc";
            }

            //show word doc
            //ScriptManager.RegisterStartupScript(this, typeof(string), DateTime.Now.ToString(), "javascript:openWindow('Report.aspx?id=" + Encryption.Encrypt(PK_Inspection_ID.ToString()) + "');", true);
        }
        else if (e.CommandName == "SendMail")
        {
            //tdGenerateDoc.Visible = false;            
            Int32 Pk_ID = Convert.ToInt32(e.CommandArgument);
            string strFileName = SaveWordDoc(Pk_ID);
            string[] strAttachment = new string[1];
            strAttachment[0] = AppConfig.InspectionDocPath + strFileName;
            decimal FileSize = clsGeneral.GetMailAttachmentSize(strAttachment);
            if (FileSize > 9.5M)
                ScriptManager.RegisterStartupScript(this, GetType(), DateTime.Now.ToString(), "javascript:alert('The e-mailing of the selected attachments exceeds 10 megabytes, which does not conform to Sonic Corporate e-mail policy. Please reduce the attachment size or number of attachments before trying to send e-mail through eRIMS2.');", true);
            else
            {
                string strFilepath = Encryption.Encrypt(AppConfig.InspectionDocPath + strFileName);
                ScriptManager.RegisterStartupScript(this, GetType(), DateTime.Now.ToString(), "javascript:ShowEmailPopUp(" + Pk_ID.ToString() + ",'" + strFilepath + "');", true);
            }
                        
            //decimal FileSize = GetAttachmentSize(Pk_ID);
            //if (FileSize > 5.00M)
            //{
            //    String confirmMessage = "The photographs on this Inspection Report exceed the size limitations for e-mail. The Inspection Report can be sent without the photographs or you can Cancel and remove or reduce the size of the exiting photographs. Do you want to send the Inspection Report without the photographs?";
            //    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "confirmNeeded", " if(window.confirm('" + confirmMessage + "')){ __doPostBack('UserConfirmationPostBack', 'true');} else { alert('The Inspection Report has NOT been sent, please reduce the number and/or size of the photographs before e-mailing.');}", true);
            //}

        }
        else if (e.CommandName == "ViewDoc")
        {
            PK_Inspection_ID = Convert.ToInt32(e.CommandArgument);
            ViewGenerateDoc();
        }

    }

    /// <summary>
    /// handles event when page number in grid is clicked
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvOtherInspections_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        // set new page index of grid as currently clicked page number and bind the grid
        gvOtherInspections.PageIndex = e.NewPageIndex;
        BindGridOtherInspections();
    }

    /// <summary>
    /// Grid view Inspection Sorting Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvOtherInspections_Sorting(object sender, GridViewSortEventArgs e)
    {
        strSortOrder = (strSortBy == e.SortExpression) ? (strSortOrder == "asc" ? "desc" : "asc") : "asc";
        strSortBy = e.SortExpression;
        BindGridOtherInspections();
    }

    /// <summary>
    /// Gridview Other Inspections Row Created Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvOtherInspections_RowCreated(object sender, GridViewRowEventArgs e)
    {
        // check for the header row
        if (e.Row.RowType == DataControlRowType.Header)
        {
            // if sort field already available
            if (String.Empty != strSortBy)
            {
                // update sort image beside the column header 
                AddSortImage(e.Row);
            }
            else
            {
                // add sort image beside the column header 
                Image sortImage = new Image();
                sortImage.ImageUrl = "~/Images/up-arrow.gif";
                sortImage.AlternateText = "Descending Order";
                e.Row.Cells[3].Controls.Add(sortImage);
            }
        }
    }


    /// <summary>
    /// Returns the index of the column which contains perticular sort expression
    /// </summary>
    /// <param name="strSortExp">The column on which the sorting is to be performed</param>
    /// <returns>Integer</returns>
    private int GetSortColumnIndex(string strSortExp)
    {
        int nRet = 1;
        // Iterate through the Columns collection to determine the index
        // of the column being sorted.
        foreach (DataControlField field in gvOtherInspections.Columns)
        {
            //check Sort Expression value
            if (field.SortExpression.ToString() == strSortExp)
            {
                nRet = gvOtherInspections.Columns.IndexOf(field);
            }
        }
        return nRet;
    }

    /// <summary>
    /// Adds the sorting image beside the column in the grid on which 
    /// sorting has been performed
    /// </summary>
    /// <param name="headerRow">Header Row of the grid</param>
    private void AddSortImage(GridViewRow headerRow)
    {
        Int32 iCol = GetSortColumnIndex(strSortBy);
        if (iCol == -1)
        {
            return;
        }
        // Create the sorting image based on the sort direction.
        Image sortImage = new Image();
        string SortOrder = strSortOrder == "asc" ? SortDirection.Ascending.ToString() : SortDirection.Descending.ToString();

        // check for the order and
        // set the images accordingly 
        if (SortDirection.Ascending.ToString() == SortOrder)
        {
            sortImage.ImageUrl = "~/Images/up-arrow.gif";
            sortImage.AlternateText = "Descending Order";
        }
        else
        {
            sortImage.ImageUrl = "~/Images/down-arrow.gif";
            sortImage.AlternateText = "Ascending Order";
        }

        // Add the image to the appropriate header cell.
        headerRow.Cells[iCol].Controls.Add(sortImage);
    }

    #endregion

    #region " SAVE "

    /// <summary>
    /// Button Save Click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (PK_Inspection_ID <= 0 && LocationActive == "N")
        {
            clsGeneral.ShowAlert("Location for this Record is In Active. So can not add new Record.", this);
            return;
        }
        SaveData();
        if (Current_Focus_Area_ID < dt_Focus_Area.Rows.Count)
            Current_Focus_Area_ID = Current_Focus_Area_ID + 1;
        else
            Current_Focus_Area_ID = 1;

        bEditInspection = true;
        BindDetailsForEdit();
        drpFocusAreasEdit.SelectedValue = Current_Focus_Area_ID.ToString();
        btnViewAudit.Visible = true;
        BindGridAttachmentsFocusArea();
        if (Current_Inspection_Area_ID != 0)
            drpInspectionArea.SelectedValue = Current_Inspection_Area_ID.ToString();
    }

    /// <summary>
    /// Save Data Method
    /// </summary>
    private void SaveData()
    {
        string strGUID = System.Guid.NewGuid().ToString(); // used for Audit trail

        #region " SAVE INSPECTION DATA "
        // create object for the Inspection 
        Inspection objInspection = new Inspection();

        // get values from page controls
        objInspection.PK_Inspection_ID = PK_Inspection_ID;
        objInspection.FK_LU_Location_ID = FK_LU_Location_ID;
        objInspection.date = clsGeneral.FormatDateToStore(txtDate);
        objInspection.Inspector_Name = txtInspectorName.Text.Trim();
        objInspection.RLCM_Verified = rdoRLCMVerified.SelectedValue;
        objInspection.No_Deficiencies = chkNoDeficiency.Checked;
        objInspection.Overall_Inspection_Comments = txtOverallInspectionComments.Text.Trim();
        objInspection.UniqueVal = strGUID;
        objInspection.Updated_By = Convert.ToDecimal(clsSession.UserID);
        objInspection.Updated_Date = DateTime.Now;
        if (lblDateofInitialDistributionReportEdit.Text != string.Empty)
        {
            objInspection.Date_Report_Initially_Distibuted = Convert.ToDateTime(lblDateofInitialDistributionReportEdit.Text);
        }
        if (Convert.ToInt32(drpInspectionArea.SelectedIndex) > 0)
        {
            objInspection.FK_LU_Inspection_Area = Convert.ToInt32(drpInspectionArea.SelectedItem.Value);
            Current_Inspection_Area_ID = Convert.ToInt32(drpInspectionArea.SelectedItem.Value);
        }
        // insert or update the data depending on the primary key
        if (PK_Inspection_ID > 0)
            objInspection.Update();
        else
            PK_Inspection_ID = objInspection.Insert();

        #endregion

        #region " SAVE INSPECTION RESPONSE DATA "

        for (int i = 0; i < gvInspectionEdit.Rows.Count; i++)
        {
            // get the primary key for Inspection Response record
            HtmlInputHidden hdnResponseID = (HtmlInputHidden)gvInspectionEdit.Rows[i].FindControl("hdnResponseID");
            HtmlInputHidden hdnDeficientAnswer = (HtmlInputHidden)gvInspectionEdit.Rows[i].FindControl("hdnDeficientAnswer");
            HtmlInputHidden hdnMaintenance = (HtmlInputHidden)gvInspectionEdit.Rows[i].FindControl("hdnMaintenance");

            int PK_Inspection_Responses_ID = hdnResponseID.Value != "" ? Convert.ToInt32(hdnResponseID.Value) : 0;
            if (strOperation == "") PK_Inspection_Responses_ID = 0;
            // create object for the inspection response 
            Inspection_Responses objResponse = new Inspection_Responses();

            //create object for the facility construction maintenance item 
            Facility_Construction_Maintenance_Item objMaintItem = new Facility_Construction_Maintenance_Item();

            // get values from page controls
            objResponse.PK_Inspection_Responses_ID = PK_Inspection_Responses_ID;
            objResponse.FK_Inspection_ID = PK_Inspection_ID;
            objResponse.FK_Inspection_Question_ID = Convert.ToInt32(gvInspectionEdit.DataKeys[i].Value);

            if (!chkNoDeficiency.Checked)
                objResponse.Deficiency_Noted = ((RadioButtonList)gvInspectionEdit.Rows[i].FindControl("rdoDefeciancy")).SelectedValue;
            else
                objResponse.Deficiency_Noted = "N";

            if (objResponse.Deficiency_Noted == "Y" && hdnDeficientAnswer.Value == "Y" && !chkNoDeficiency.Checked)
            {
                string strDepartment = "";
                RadioButtonList rdoRepeatDeficiency = (RadioButtonList)gvInspectionEdit.Rows[i].FindControl("rdoRepeatDeficiency");

                objResponse.Repeat_Deficiency = rdoRepeatDeficiency.SelectedValue;

                CheckBoxList chkDepartments = (CheckBoxList)gvInspectionEdit.Rows[i].FindControl("chkDepartments");
                foreach (ListItem itm in chkDepartments.Items)
                {
                    if (itm.Selected)
                        strDepartment = strDepartment + itm.Value + ",";
                }
                strDepartment = strDepartment.TrimEnd(',');
                //DropDownList drpDepartment = (DropDownList)gvInspectionEdit.Rows[i].FindControl("drpDepartment");
                //objResponse.Department = (drpDepartment.SelectedIndex > 0) ? drpDepartment.SelectedItem.Text : string.Empty;
                objResponse.Department = strDepartment;
                objResponse.Date_Opened = clsGeneral.FormatDateToStore((TextBox)gvInspectionEdit.Rows[i].FindControl("txtDateOpened"));
                objResponse.Recommended_Action = ((Controls_LongDescription_LongDescription)gvInspectionEdit.Rows[i].FindControl("txtAction")).Text;
                objResponse.Target_Completion_Date = clsGeneral.FormatDateToStore((TextBox)gvInspectionEdit.Rows[i].FindControl("txtTargetCompleteDate"));
                objResponse.Actual_Completion_Date = clsGeneral.FormatDateToStore((TextBox)gvInspectionEdit.Rows[i].FindControl("txtActualCompletionDate"));
                objResponse.Notes = ((Controls_LongDescription_LongDescription)gvInspectionEdit.Rows[i].FindControl("txtNotes")).Text;
            }

            RadioButtonList rdoMaintenance = (RadioButtonList)gvInspectionEdit.Rows[i].FindControl("rdoMaintenance");
            string strMaintenance = !string.IsNullOrEmpty(((TextBox)gvInspectionEdit.Rows[i].FindControl("txtTitle")).Text) ? "Y" : "N";
            //rdoMaintenance.SelectedValue = strMaintenance;
            if (strMaintenance == "Y")
            {
                objResponse.Problem_Description = ((Controls_LongDescription_LongDescription)gvInspectionEdit.Rows[i].FindControl("txtProblemDescription")).Text;
                objResponse.Title = ((TextBox)gvInspectionEdit.Rows[i].FindControl("txtTitle")).Text;
            }

            objResponse.UniqueVal = strGUID;
            objResponse.Updated_By = Convert.ToDecimal(clsSession.UserID);
            objResponse.Updated_Date = DateTime.Now;

            objMaintItem.FK_LU_Location_ID = FK_LU_Location_ID;
            objMaintItem.Title = ((TextBox)gvInspectionEdit.Rows[i].FindControl("txtTitle")).Text;
            objMaintItem.Requester_Table = "Security";
            objMaintItem.Repair_Description = ((Controls_LongDescription_LongDescription)gvInspectionEdit.Rows[i].FindControl("txtProblemDescription")).Text;
            objMaintItem.Update_Date = DateTime.Now;
           
            // insert or update the record depending on the primary key for inspection response
            if (PK_Inspection_Responses_ID > 0)
                objResponse.Update();
            else
            { 
                objResponse.Insert();
            }

            objMaintItem.PK_Facility_Construction_Maintenance_Item = objMaintItem.Insert();
            Int32 itemNumber = Convert.ToInt32(objMaintItem.PK_Facility_Construction_Maintenance_Item.Value);
            objMaintItem.Item_Number = "M" + itemNumber.ToString("D4");
            objMaintItem.UpdateItemNumberByPrimaryKey();
        }

        #endregion
    }

    /// <summary>
    /// Button Save Click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSaveView_Click(object sender, EventArgs e)
    {
        if (PK_Inspection_ID <= 0 && LocationActive == "N")
        {
            clsGeneral.ShowAlert("Location for this Record is In Active. So can not add new Record.", this);
            return;
        }
        SaveData();

        // open the page in view mode
        Response.Redirect("Inspections.aspx?id=" + Encryption.Encrypt(PK_Inspection_ID.ToString()) + "&op=view&loc=" + Request.QueryString["loc"]);
    }

    #endregion

    #region " METHODS "

    /// <summary>
    /// Bind Dropdown Focus Area
    /// </summary>
    private void BindDropdownFocusAreas()
    {
        if (strOperation == "view")
        {
            drpFocusAreasView.DataSource = dt_Focus_Area;
            drpFocusAreasView.DataTextField = "Item_Number_Focus_Area";
            drpFocusAreasView.DataValueField = "ID";
            drpFocusAreasView.DataBind();
        }
        else
        {
            drpFocusAreasEdit.DataSource = dt_Focus_Area;
            drpFocusAreasEdit.DataTextField = "Item_Number_Focus_Area";
            drpFocusAreasEdit.DataValueField = "ID";
            drpFocusAreasEdit.DataBind();
        }
    }


    /// <summary>
    /// Bind Dropdown Inspection Area
    /// </summary>
    private void BindDropdownInspectionAreas()
    {
        if (strOperation == "view")
        {
            //drpFocusAreasView.DataSource = dt_Focus_Area;
            //drpFocusAreasView.DataTextField = "Item_Number_Focus_Area";
            //drpFocusAreasView.DataValueField = "ID";
            //drpFocusAreasView.DataBind();
        }
        else
        {
            dt_Inspection_Area = clsLU_Inspection_Area.SelectAll().Tables[0];
            dt_Inspection_Area.DefaultView.RowFilter = "Active = 'Y'";
            drpInspectionArea.DataSource = dt_Inspection_Area.DefaultView;
            drpInspectionArea.DataTextField = "Fld_Desc";
            drpInspectionArea.DataValueField = "PK_LU_Inspection_Area";
            drpInspectionArea.DataBind();
            drpInspectionArea.Items.Insert(0, new ListItem("--Select--", "0"));
        }
    }

    /// <summary>
    /// Bind details for Page in add mode
    /// </summary>
    private void BindDetailsForAdd()
    {

        // get all questions records and bind the grid
        string strFocusArea = dt_Focus_Area.Rows[Current_Focus_Area_ID - 1][1].ToString();
        DataTable dtInspection = Inspection_Questions.SelectByFocusArea(FK_LU_Location_ID, true, dt_Focus_Area.Rows[Current_Focus_Area_ID - 1][1].ToString()).Tables[0];
        dtInspection.DefaultView.Sort = "Question_Number asc";
        dtInspection = dtInspection.DefaultView.ToTable();
        if (dtInspection.Rows.Count > 0)
        {
            DataRow drInspection = dtInspection.Rows[0];
            if (drInspection["FK_LU_Location_ID"] != DBNull.Value)
            {
                FK_LU_Location_ID = Convert.ToInt32(dtInspection.Rows[0]["FK_LU_Location_ID"]);
                LocationActive = new LU_Location(Convert.ToDecimal(drInspection["FK_LU_Location_ID"])).Active;

                if (LocationActive == "N")
                    lnkAddNew.Visible = false;

                if (dtInspection.Rows[0]["date"] != DBNull.Value)
                    txtDate.Text = clsGeneral.FormatDateToDisplay(Convert.ToDateTime(dtInspection.Rows[0]["date"]));

                txtInspectorName.Text = Convert.ToString(dtInspection.Rows[0]["Inspector_Name"]);
                rdoRLCMVerified.SelectedValue = Convert.ToString(dtInspection.Rows[0]["RLCM_Verified"]) == "Y" ? "Y" : "N";
                int PKInspectionID = 0;
                if (dtInspection.Rows[0]["PK_Inspection_ID"] != DBNull.Value)
                    PKInspectionID = Convert.ToInt32(dtInspection.Rows[0]["PK_Inspection_ID"]);
                //if (dtInspection.Rows[0]["FK_LU_Inspection_Area"] != DBNull.Value)
                //{
                //    drpInspectionArea.SelectedValue = Convert.ToString(dtInspection.Rows[0]["FK_LU_Inspection_Area"]);
                //}
                if (dtInspection.Rows[0]["FK_LU_Inspection_Area"] != DBNull.Value)
                {
                    ListItem lstSearch = (drpInspectionArea.Items.FindByValue(dtInspection.Rows[0]["FK_LU_Inspection_Area"].ToString()));
                    if (lstSearch != null)
                    {
                        drpInspectionArea.ClearSelection();
                        lstSearch.Selected = true;
                        //drpInspectionArea.SelectedValue = Convert.ToString(dtInspection.Rows[0]["FK_LU_Inspection_Area"]);
                    }
                }
                lblDateofInitialDistributionReport.Text = DateTime.Now.ToString();
                lblNumberofDeficienciesInspectionEdit.Text = Inspection.GetNumberOfDeficiencies(PKInspectionID).ToString();
                lblNumberofRepeatDeficienciesEdit.Text = Inspection.GetNumberOfRepeat_Deficiency(PKInspectionID).ToString();
                BindGridAttachments();
                BindGridAttachmentsFocusArea();
            }
            else
            {
                txtDate.Text = "";
                rdoRLCMVerified.SelectedValue = "N";
                txtInspectorName.Text = "";
                //drpFocusAreasEdit.SelectedIndex = 0;
                lnkAddNew.Visible = true;
            }

        }

        gvInspectionEdit.DataSource = dtInspection;
        gvInspectionEdit.DataBind();
        dvView.Style["display"] = "none";
        dvEdit.Style["display"] = "block";
        dvAllInspections.Style["display"] = "none";
        lnkAddNew.Visible = false;
        //BindDropdownFocusAreas();
        FK_Inspection_Questions_ID = 0;
        if (dtInspection != null && dtInspection.Rows.Count > 0)
        {
            FK_Inspection_Questions_ID = Convert.ToInt32(dtInspection.Rows[0]["PK_Inspection_Questions_ID"]);
        }
    }

    /// <summary>
    /// Binds Details for Page in Edit mode
    /// </summary>
    private void BindDetailsForEdit()
    {
        BindDropdownInspectionAreas();
        string strFocusArea = Convert.ToString(dt_Focus_Area.Rows[Current_Focus_Area_ID - 1][1]);
        // get all questions and response data and bind the grid
        DataTable dtInspection = Inspection.SelectQuestionsAndResposnsesByFocusArea(PK_Inspection_ID, strFocusArea).Tables[0];

        strOperation = (dtInspection.Rows.Count > 0) ? "edit" : "";
        FK_Inspection_Questions_ID = 0;
        dvView.Style["display"] = "none";
        dvEdit.Style["display"] = "block";

        gvInspectionEdit.DataSource = dtInspection;
        gvInspectionEdit.DataBind();
        lnkAddNew.Visible = false;

        if (dtInspection.Rows.Count > 0)
        {
            DataRow drInspection = dtInspection.Rows[0];
            if (drInspection["FK_LU_Location_ID"] != DBNull.Value)
            {
                FK_LU_Location_ID = Convert.ToInt32(dtInspection.Rows[0]["FK_LU_Location_ID"]);
                LocationActive = new LU_Location(Convert.ToDecimal(drInspection["FK_LU_Location_ID"])).Active;

                if (LocationActive == "N")
                    lnkAddNew.Visible = false;

                if (dtInspection.Rows[0]["date"] != DBNull.Value)
                    txtDate.Text = clsGeneral.FormatDateToDisplay(Convert.ToDateTime(dtInspection.Rows[0]["date"]));

                txtInspectorName.Text = Convert.ToString(dtInspection.Rows[0]["Inspector_Name"]);
                if (dtInspection.Rows[0]["FK_LU_Inspection_Area"] != DBNull.Value)
                {
                    ListItem lstSearch = (drpInspectionArea.Items.FindByValue(dtInspection.Rows[0]["FK_LU_Inspection_Area"].ToString()));
                    if (lstSearch != null)
                    {
                        drpInspectionArea.ClearSelection();
                        lstSearch.Selected = true;
                        //drpInspectionArea.SelectedValue = Convert.ToString(dtInspection.Rows[0]["FK_LU_Inspection_Area"]);
                    }
                }
                rdoRLCMVerified.SelectedValue = Convert.ToString(dtInspection.Rows[0]["RLCM_Verified"]) == "Y" ? "Y" : "N";
                if (Convert.ToString(dtInspection.Rows[0]["No_Deficiencies"]) != "")
                    chkNoDeficiency.Checked = Convert.ToBoolean(dtInspection.Rows[0]["No_Deficiencies"]);
                txtOverallInspectionComments.Text = Convert.ToString(dtInspection.Rows[0]["Overall_Inspection_Comments"]);
                lblNumberofDeficienciesInspectionEdit.Text = Convert.ToString(Inspection.GetNumberOfDeficiencies(PK_Inspection_ID)); //Convert.ToString(dtInspection.Rows[0]["Deficiency_Count"]);
                lblNumberofRepeatDeficienciesEdit.Text = Convert.ToString(Inspection.GetNumberOfRepeat_Deficiency(PK_Inspection_ID));
                lblDateofInitialDistributionReportEdit.Text = clsGeneral.FormatDBNullDateToDisplay(drInspection["Date_Report_Initially_Distibuted"]).ToString();
                BindGridAttachments();
                BindGridAttachmentsFocusArea();
            }
            FK_Inspection_Questions_ID = Convert.ToInt32(dtInspection.Rows[0]["PK_Inspection_Questions_ID"]);

        }
    }

    /// <summary>
    /// Binds Details for page in view mode
    /// </summary>
    private void BindDetailsForView()
    {
        string strFocusArea = Convert.ToString(dt_Focus_Area.Rows[Current_Focus_Area_ID - 1][1]);
        // get all questions and response data and bind the grid
        DataTable dtInspection = Inspection.SelectQuestionsAndResposnsesByFocusArea(PK_Inspection_ID, strFocusArea).Tables[0];
        FK_Inspection_Questions_ID = 0;

        if (dtInspection.Rows.Count > 0)
        {
            //bResponseDataAvailable = true;
            gvInspectionView.DataSource = dtInspection;
            gvInspectionView.DataBind();
            // set page in view mode
            dvView.Style["display"] = "block";
            dvEdit.Style["display"] = "none";
            lnkAddNew.Visible = true;
            DataRow drInspection = dtInspection.Rows[0];
            FK_Inspection_Questions_ID = Convert.ToInt32(dtInspection.Rows[0]["PK_Inspection_Questions_ID"]);
            if (drInspection["FK_LU_Location_ID"] != DBNull.Value)
            {
                FK_LU_Location_ID = Convert.ToInt32(dtInspection.Rows[0]["FK_LU_Location_ID"]);
                // set FK and other page controls values
                //FK_LU_Location_ID = Convert.ToInt32(dtInspection.Rows[0]["FK_LU_Location_ID"]);
                if (dtInspection.Rows[0]["date"] != DBNull.Value)
                    lblDate.Text = clsGeneral.FormatDateToDisplay(Convert.ToDateTime(dtInspection.Rows[0]["date"]));

                lblNumberofDeficienciesInspection.Text = Convert.ToString(Inspection.GetNumberOfDeficiencies(PK_Inspection_ID)); //Convert.ToString(dtInspection.Rows[0]["Deficiency_Count"]);
                lblNumberofRepeatDeficiencies.Text = Convert.ToString(Inspection.GetNumberOfRepeat_Deficiency(PK_Inspection_ID));  //Convert.ToString(dtInspection.Rows[0]["NumberofRepeatDeficienciesNoted"]); 
                lblInspectorName.Text = Convert.ToString(dtInspection.Rows[0]["Inspector_Name"]);
                LocationActive = new LU_Location(Convert.ToDecimal(drInspection["FK_LU_Location_ID"])).Active;
                lblRLCMVerified.Text = Convert.ToString(dtInspection.Rows[0]["RLCM_Verified"]) == "Y" ? "Yes" : "No";
                lblInspectionArea.Text = Convert.ToString(dtInspection.Rows[0]["Fld_Desc"]);
                lblDateofInitialDistributionReport.Text = clsGeneral.FormatDBNullDateToDisplay(dtInspection.Rows[0]["Date_Report_Initially_Distibuted"]);
                if (Convert.ToString(dtInspection.Rows[0]["No_Deficiencies"]) != "")
                    lblNoDeficiencies.Text = Convert.ToBoolean(dtInspection.Rows[0]["No_Deficiencies"]) == true ? "Yes" : "No";
                else
                    lblNoDeficiencies.Text = "";
                lblOverallInspectionComments.Text = Convert.ToString(dtInspection.Rows[0]["Overall_Inspection_Comments"]);
                if (LocationActive == "N")
                    lnkAddNew.Visible = false;
                BindGridAttachments();
                BindGridAttachmentsFocusArea();
            }
            else
            {
                btnBack.Enabled = LocationActive == "Y";
                btnViewAudit2.Visible = LocationActive == "Y";
            }
            //if (hdnForDateEdit.Value == PK_Inspection_ID.ToString())
            //{
            //    ScriptManager.RegisterStartupScript(Page, GetType(), "key", "javascript:CheckForDate();", true);
            //}

            // Check if User has right To Add or Edit 
            if (App_Access == AccessType.View_Only)
                btnBack.Visible = false;
        }
        else
        {
            DataTable dtQuestions = Inspection_Questions.SelectByFocusArea(FK_LU_Location_ID, false, dt_Focus_Area.Rows[Current_Focus_Area_ID - 1][1].ToString()).Tables[0];
            dtQuestions.DefaultView.Sort = "Question_Number asc";
            dtQuestions = dtQuestions.DefaultView.ToTable();
            gvInspectionView.DataSource = dtQuestions;
            gvInspectionView.DataBind();

            FK_Inspection_Questions_ID = Convert.ToInt32(dtQuestions.Rows[0]["PK_Inspection_Questions_ID"]);
        }
    }

    /// <summary>
    /// Binds other inspection grids
    /// </summary>
    private void BindGridOtherInspections()
    {
        // get data for the location and bind the grid
        DataTable dtOtherInsp = Inspection.SelectByFKLocation(FK_LU_Location_ID).Tables[0];
        dtOtherInsp.DefaultView.Sort = strSortBy + " " + strSortOrder;
        dtOtherInsp = dtOtherInsp.DefaultView.ToTable();
        gvOtherInspections.DataSource = dtOtherInsp;
        gvOtherInspections.DataBind();
        if (strOperation == "view")
            gvOtherInspections.Columns[gvOtherInspections.Columns.Count - 1].Visible = false;
    }

    #endregion

    #region "Other controls events"
    /// <summary>
    /// Handles event when Add new link is clicked
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkAddNew_Click(object sender, EventArgs e)
    {
        bEditInspection = false;
        // re-initialize PK and operation as default values
        PK_Inspection_ID = 0;
        strOperation = string.Empty;
        btnViewAudit.Visible = false;
        BindDropdownFocusAreas();
        BindDropdownInspectionAreas();
        // clear page controls to enter new data
        txtDate.Text = "";
        txtInspectorName.Text = "";
        BindDetailsForAdd();
        BindGridAttachments();
        BindGridAttachmentsFocusArea();
    }

    /// <summary>
    /// Handles back button click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("Inspections.aspx?id=" + Encryption.Encrypt(PK_Inspection_ID.ToString()) + "&op=edit" + "&loc=" + Request.QueryString["loc"]);
    }

    /// <summary>
    /// Handles event when focus area dropdown selection changed in edit and view mode
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void drpFocusAreas_SelectedIndedChanged(object sender, EventArgs e)
    {
        // get focus area ID from related dropdown in edit or view mode
        Current_Focus_Area_ID = (strOperation == "view") ? Convert.ToInt32(drpFocusAreasView.SelectedValue) : Convert.ToInt32(drpFocusAreasEdit.SelectedValue);
        if (strOperation == "")
        {
            if (PK_Inspection_ID > 0)
                BindDetailsForEdit();
            else
                BindDetailsForAdd();
        }
        else
        {
            if (strOperation == "edit")
            {
                bEditInspection = true;
                BindDetailsForEdit();
            }
            else
                BindDetailsForView();
        }
        BindGridAttachmentsFocusArea();
    }

    /// <summary>
    /// Grid View Attachment details Row Data bound Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvAttachmentDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        // check for the datarow
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            // get the filename link control
            HtmlAnchor lnkAttachFile = (HtmlAnchor)e.Row.FindControl("lnkAttachFile");

            // get the file name value from binder
            string strFileName = DataBinder.Eval(e.Row.DataItem, "FileName").ToString();
            strFileName = AppConfig.InspectionDocPath + strFileName;
            string strFilePath = Encryption.Encrypt(strFileName).Replace("'", "\\'");
            // set click attribute to open file on clicking the link
            lnkAttachFile.Attributes.Add("onclick", "javascript:window.open('" + AppConfig.SiteURL + "/Download.aspx?attachfile=" + strFilePath + "')");
        }
    }

    /// <summary>
    /// GridView Focus Area Attachment Row Data Bound Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvFocusAreaAttachement_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        // check for the datarow
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            // get the filename link control
            HtmlAnchor lnkAttachFile = (HtmlAnchor)e.Row.FindControl("lnkAttachFile");

            // get the file name value from binder
            string strFileName = DataBinder.Eval(e.Row.DataItem, "FileName").ToString();
            strFileName = AppConfig.InspectionFocusAreaDocPath + strFileName;
            string strFilePath = Encryption.Encrypt(strFileName).Replace("'", "\\'");
            // set click attribute to open file on clicking the link
            lnkAttachFile.Attributes.Add("onclick", "javascript:window.open('" + AppConfig.SiteURL + "/Download.aspx?attachfile=" + strFilePath + "')");
        }
    }

    /// <summary>
    /// Grid Attachment Details Row Command Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvAttachmentDetails_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        // if passed command is for removing attachment then
        // delete the attachment record by PK passed in command argument and
        // bind the grid
        if (e.CommandName == "RemoveAttachment")
        {
            string[] strArgs = e.CommandArgument.ToString().Split(':');
            int intPK = Convert.ToInt32(strArgs[0]);
            string strFileName = strArgs[1];
            Inspection_Attachments.DeleteByPK(intPK);
            BindGridAttachments();

            // delete file
            string strPath = clsGeneral.GetAttachmentDocPath(clsGeneral.ExposureTableNames[(int)clsGeneral.Exposure_Tables.Inspection]) + strFileName;
            if (File.Exists(strPath))
                File.Delete(strPath);
        }
    }

    /// <summary>
    /// Grid View Focus Attachment Edit Row Command Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvFocusAreaAttachmentEdit_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        // if passed command is for removing attachment then
        // delete the attachment record by PK passed in command argument and
        // bind the grid
        if (e.CommandName == "RemoveAttachment")
        {
            string[] strArgs = e.CommandArgument.ToString().Split(':');
            int intPK = Convert.ToInt32(strArgs[0]);
            string strFileName = strArgs[1];
            Inspection_Responses_Attachments.DeleteByPK(intPK);
            BindGridAttachmentsFocusArea();

            // delete file
            string strPath = clsGeneral.GetAttachmentDocPath(clsGeneral.ExposureTableNames[(int)clsGeneral.Exposure_Tables.Inspection_Responses]) + strFileName;
            if (File.Exists(strPath))
                File.Delete(strPath);
        }
    }

    /// <summary>
    /// Upload Focus Area Attachment Details
    /// </summary>
    protected void UploadFocusArea_Attachment()
    {
        Inspection_Responses objResponse = new Inspection_Responses(FK_Inspection_Questions_ID, PK_Inspection_ID);
        if (Convert.ToInt32(objResponse.PK_Inspection_Responses_ID) > 0)
        {
            // add attachment
            ucInspectionFocusAreaAttachment.FK_Inspection_Responses_ID_Attachment = Convert.ToInt32(objResponse.PK_Inspection_Responses_ID);
            ucInspectionFocusAreaAttachment.Add(clsGeneral.Exposure_Tables.Inspection_Responses);
            trAttachmentFA.Style["display"] = "none";

            // bind Building attachment grid to list newly added attachment
            BindGridAttachmentsFocusArea();
            //ScriptManager.RegisterStartupScript(Page, GetType(), DateTime.Now.ToString(), "ShowPanel(2);", true);
        }
        else
        {
            clsGeneral.ShowAlert("Please Save First Inspection Focus Area Details.", this);
            return;
        }
    }

    /// <summary>
    /// Upoad Attachment
    /// </summary>
    protected void Upload_Attachment()
    {
        // add attachment
        ucInspectionAttachment.FK_Inspection_ID = PK_Inspection_ID;
        ucInspectionAttachment.Add(clsGeneral.Exposure_Tables.Inspection);
        trAttachment.Style["display"] = "none";

        // bind Building attachment grid to list newly added attachment
        BindGridAttachments();
        //ScriptManager.RegisterStartupScript(Page, GetType(), DateTime.Now.ToString(), "ShowPanel(2);", true);
    }

    /// <summary>
    /// Bind Attachment Grid
    /// </summary>
    private void BindGridAttachments()
    {
        DataTable dtAttach = Inspection_Attachments.SelectByFK(PK_Inspection_ID).Tables[0];
        if (strOperation == "view")
        {
            gvAttachmentDetailsView.DataSource = dtAttach;
            gvAttachmentDetailsView.DataBind();
        }
        else
        {
            gvAttachmentDetails.DataSource = dtAttach;
            gvAttachmentDetails.DataBind();
        }
    }

    /// <summary>
    /// Bind Gris Attachment Focus Area
    /// </summary>
    private void BindGridAttachmentsFocusArea()
    {
        DataTable dtAttach = null;
        if (strOperation == "view")
        {
            dtAttach = Inspection_Responses_Attachments.SelectByFocusArea(Convert.ToString(drpFocusAreasView.SelectedItem.Text), PK_Inspection_ID).Tables[0];
            gvFocusAreaAttachementView.DataSource = dtAttach;
            gvFocusAreaAttachementView.DataBind();
        }
        else
        {
            dtAttach = Inspection_Responses_Attachments.SelectByFocusArea(Convert.ToString(drpFocusAreasEdit.SelectedItem.Text), PK_Inspection_ID).Tables[0];
            gvFocusAreaAttachmentEdit.DataSource = dtAttach;
            gvFocusAreaAttachmentEdit.DataBind();
        }
    }

    /// <summary>
    /// View Generate Doc
    /// </summary>
    private void ViewGenerateDoc()
    {
        #region " GENERATE WORD DOCUMENT "
        string strHTML = InspectionWordDocument.PrepareMailForSend(PK_Inspection_ID).ToString();
        string strLisenceFile = HttpContext.Current.Server.MapPath(HttpContext.Current.Request.ApplicationPath) + "\\" + ("Bin") + "\\Aspose.Words.lic";
        if (File.Exists(strLisenceFile))
        {
            //This shows how to license Aspose.Words, if you don't specify a license, 
            //Aspose.Words works in evaluation mode.
            Aspose.Words.License license = new Aspose.Words.License();
            license.SetLicense(strLisenceFile);
        }

        Aspose.Words.Document doc = new Aspose.Words.Document();
        //Build string builder to transport to Doc
        //Once the builder is created, its cursor is positioned at the beginning of the document.
        Aspose.Words.DocumentBuilder builder = new Aspose.Words.DocumentBuilder(doc);

        builder.PageSetup.BottomMargin = 15;
        builder.PageSetup.TopMargin = 15;
        builder.PageSetup.LeftMargin = 15;
        builder.PageSetup.RightMargin = 15;
        builder.Font.Size = 10;
        builder.Font.Bold = false;
        builder.Font.Color = System.Drawing.Color.Black;
        builder.Font.Name = "Arial";
        builder.InsertParagraph();
        builder.InsertHtml(strHTML);
        //Don't need merge fields in the document anymore.
        doc.MailMerge.DeleteFields();
        builder.MoveToSection(0);
        builder.MoveToHeaderFooter(HeaderFooterType.FooterPrimary);
        builder.PageSetup.PageNumberStyle = NumberStyle.Number;
        builder.ParagraphFormat.Alignment = ParagraphAlignment.Center;
        builder.Write("Page ");
        builder.InsertField("PAGE", "");
        builder.Write(" of ");
        builder.InsertField("NUMPAGES", "");
        Section section = doc.Sections[0];
        section.PageSetup.PageStartingNumber = 1;
        section.PageSetup.RestartPageNumbering = true;
        section.PageSetup.PageNumberStyle = NumberStyle.Arabic;

        // Remove content from merged cells.
        // Get collection of cells in the docuemnt.
        NodeCollection cells = doc.GetChildNodes(NodeType.Cell, true);

        foreach (Aspose.Words.Tables.Cell cell in cells)
        {
            // Check whether cell is merged with previouse.
            if (cell.CellFormat.HorizontalMerge == Aspose.Words.Tables.CellMerge.Previous || cell.CellFormat.VerticalMerge == Aspose.Words.Tables.CellMerge.Previous)
            {
                // Remove content from the cell.
                cell.RemoveAllChildren();
            }
        }

        Aspose.Words.Tables.Table table = (Aspose.Words.Tables.Table)doc.GetChild(NodeType.Table, 0, true);
        table.AllowAutoFit = false;

        //doc.Save("InspectionReport.doc", Aspose.Words.SaveFormat.Doc, Aspose.Words.SaveType.OpenInWord, Response);
        doc.Save(Response, "InspectionReport.doc", ContentDisposition.Attachment, Aspose.Words.Saving.SaveOptions.CreateSaveOptions(SaveFormat.Doc));

        if (Directory.Exists(InspectionWordDocument.strTempDir))
            Directory.Delete(InspectionWordDocument.strTempDir, true);
                
        Response.End();
        #endregion
    }

    /// <summary>
    /// Save Word Document
    /// </summary>
    /// <param name="PK"></param>
    /// <returns></returns>
    private string SaveWordDoc(int PK)
    {
        string strFileNameToSave = "InspectionReport" + Session.SessionID + ".doc";

        #region " GENERATE WORD DOCUMENT "

        StringBuilder sbHTML = new StringBuilder();
        sbHTML.Append(InspectionWordDocument.PrepareMailForSend(PK));

        string strLisenceFile = HttpContext.Current.Server.MapPath(HttpContext.Current.Request.ApplicationPath) + "\\" + ("Bin") + "\\Aspose.Words.lic";

        if (File.Exists(strLisenceFile))
        {
            //This shows how to license Aspose.Words, if you don't specify a license, 
            //Aspose.Words works in evaluation mode.
            Aspose.Words.License license = new Aspose.Words.License();
            license.SetLicense(strLisenceFile);
        }

        Aspose.Words.Document doc = new Aspose.Words.Document();

        //Build string builder to transport to Doc
        //Once the builder is created, its cursor is positioned at the beginning of the document.
        Aspose.Words.DocumentBuilder builder = new Aspose.Words.DocumentBuilder(doc);

        builder.PageSetup.BottomMargin = 15;
        builder.PageSetup.TopMargin = 15;
        builder.PageSetup.LeftMargin = 15;
        builder.PageSetup.RightMargin = 15;
        builder.Font.Size = 10;
        builder.Font.Bold = false;
        builder.Font.Color = System.Drawing.Color.Black;
        builder.Font.Name = "Arial";
        builder.PageSetup.PageNumberStyle = NumberStyle.Number;
        builder.InsertParagraph();
        builder.InsertHtml(sbHTML.ToString());

        //builder.Write(litLetter.Text);
        //doc.MailMerge.Execute(dt);
        //Don't need merge fields in the document anymore.
        doc.MailMerge.DeleteFields();
        builder.MoveToSection(0);
        builder.MoveToHeaderFooter(HeaderFooterType.FooterPrimary);
        builder.ParagraphFormat.Alignment = ParagraphAlignment.Center;

        builder.Write("Page ");
        builder.InsertField("PAGE", "");
        builder.Write(" of ");
        builder.InsertField("NUMPAGES", "");

        Section section = doc.Sections[0];
        section.PageSetup.PageStartingNumber = 1;
        section.PageSetup.RestartPageNumbering = true;
        section.PageSetup.PageNumberStyle = NumberStyle.Arabic;

        //builder.Write(litLetter.Text);
        //doc.MailMerge.Execute(dt);
        //Don't need merge fields in the document anymore.
        doc.MailMerge.DeleteFields();

        if (File.Exists(AppConfig.InspectionDocPath + strFileNameToSave))
            File.Delete(AppConfig.InspectionDocPath + strFileNameToSave);

        // Remove content from merged cells.
        // Get collection of cells in the docuemnt.
        NodeCollection cells = doc.GetChildNodes(NodeType.Cell, true);

        foreach (Aspose.Words.Tables.Cell cell in cells)
        {
            // Check whether cell is merged with previouse.
            if (cell.CellFormat.HorizontalMerge == Aspose.Words.Tables.CellMerge.Previous || cell.CellFormat.VerticalMerge == Aspose.Words.Tables.CellMerge.Previous)
            {
                // Remove content from the cell.
                cell.RemoveAllChildren();
            }
        }

        doc.Save(AppConfig.InspectionDocPath + strFileNameToSave, Aspose.Words.SaveFormat.Doc);

        if (Directory.Exists(InspectionWordDocument.strTempDir))
            Directory.Delete(InspectionWordDocument.strTempDir, true);

        #endregion

        return strFileNameToSave;
    }

    protected void lnkAddNewFAAttach_Click(object sender, EventArgs e)
    {
        SaveData();

        Page.ClientScript.RegisterStartupScript(typeof(string), "ABC", "javascript:ShowAttachmentFA();", true);
    }
    protected void lnkAddAttachment_Click(object sender, EventArgs e)
    {
        SaveData();
        Page.ClientScript.RegisterStartupScript(typeof(string), "ABC", "javascript:ShowAttachment();", true);
    }
    #endregion

    #region Dynamic Validations
    /// <summary>
    /// Set all Validations
    /// </summary>
    private void SetValidations()
    {
        string strCtrlsIDs = "";
        string strMessages = "";

        #region ""
        DataTable dtFields = clsScreen_Validators.SelectByScreen(67).Tables[0];
        dtFields.DefaultView.RowFilter = "IsRequired = '1'";
        dtFields = dtFields.DefaultView.ToTable();
        foreach (DataRow drField in dtFields.Rows)
        {
            #region " set validation control IDs and messages "
            switch (Convert.ToString(drField["Field_Name"]))
            {
                case "Date": strCtrlsIDs += txtDate.ClientID + ","; strMessages += "Please enter Date" + ","; Span1.Style["display"] = "inline-block"; break;
                case "Inspector Name": strCtrlsIDs += txtInspectorName.ClientID + ","; strMessages += "Please enter Inspector Name" + ","; Span2.Style["display"] = "inline-block"; break;
                case "Overall_Inspection_Comments": strCtrlsIDs += txtOverallInspectionComments.ClientID + ","; strMessages += "Please enter Overall_Inspection_Comments" + ","; Span3.Style["display"] = "inline-block"; break;
            }
            #endregion
        }
        #endregion

        strCtrlsIDs = strCtrlsIDs.TrimEnd(',');
        strMessages = strMessages.TrimEnd(',');

        hdnControlIDs.Value = strCtrlsIDs;
        hdnErrorMsgs.Value = strMessages;
    }
    #endregion
}
