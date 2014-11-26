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
    #region " Properties "
    /// <summary>
    /// Denotes Primary key for Inspection record
    /// </summary>
    public int PK_Inspection_ID
    {
        get { return Convert.ToInt32(ViewState["PK_Inspection_ID"]); }
        set { ViewState["PK_Inspection_ID"] = value; }
    }

    /// <summary>
    /// Denotes foriegn key for Location record
    /// </summary>
    public int FK_LU_Location_ID
    {
        get { return Convert.ToInt32(ViewState["FK_LU_Location_ID"]); }
        set { ViewState["FK_LU_Location_ID"] = value; }
    }

    /// <summary>
    /// Denotes operation either view or edit for the page
    /// </summary>
    public string strOperation
    {
        get { return Convert.ToString(ViewState["strOperation"]); }
        set { ViewState["strOperation"] = value; }
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
            // check if location id is passed in querystring or not
            if (Request.QueryString["loc"] != null)
            {
                // store the location id in session
                Session["ExposureLocation"] = Request.QueryString["loc"];

                // set PK and FK from querystring if passed
                FK_LU_Location_ID = Convert.ToInt32(Request.QueryString["loc"]);
                PK_Inspection_ID = Inspection.SelectPKByFKLoc(FK_LU_Location_ID);
                if (PK_Inspection_ID > 0)
                    strOperation = "view";
            }
            else if (Request.QueryString["id"] != null) // check for the ID is passed or not
            {
                PK_Inspection_ID = Convert.ToInt32(Request.QueryString["id"]);
                strOperation = Request.QueryString["op"] != null ? Request.QueryString["op"].ToString() : "edit";
            }
            else
                strOperation = string.Empty;

            // if Primary ID is available then Bind the page in edit or view mode depending on the operation            
            if (PK_Inspection_ID > 0)
            {
                if (strOperation == "view")
                    BindDetailsForView();
                else
                {
                    // Check if User has right To Add or View 
                    if (App_Access == AccessType.View_Only)
                    {
                        Response.Redirect(AppConfig.SiteURL + "Error.aspx?msg=errAcc", true);
                    }
                    BindDetailsForEdit();
                }
            }
            else
            {
                // Check if User has right To Add or View 
                if (App_Access == AccessType.View_Only)
                {
                    Response.Redirect(AppConfig.SiteURL + "Error.aspx?msg=errAcc", true);
                }
                BindDetailsForAdd();
            }

            // Bind location information
            ucCtrlExposureInfo.PK_LU_Location = FK_LU_Location_ID;
            ucCtrlExposureInfo.BindExposureInfo();

            BindGridOtherInspections();
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
            chkDepartments.DataSource = dtDepartment;
            chkDepartments.DataTextField = "Description";
            chkDepartments.DataValueField = "PK_LU_Department_ID";
            chkDepartments.DataBind();

            //ComboHelper.FillDepartment(new DropDownList[] { drpDepartment }, 0, true);

            // Settings for hiding or displaying the response details
            RadioButtonList rdoDefeciancy = (RadioButtonList)e.Row.FindControl("rdoDefeciancy");
            HtmlTableCell tdResponseDetails = ((HtmlTableCell)e.Row.FindControl("tdResponseDetails"));
            rdoDefeciancy.Attributes.Add("onclick", "javascript:ShowHideDetails(this.id," + tdResponseDetails.ClientID + ");");

            // calendar controls settings
            HtmlImage imgDateOpened = (HtmlImage)e.Row.FindControl("imgDateOpened");
            TextBox txtDateOpn = (TextBox)e.Row.FindControl("txtDateOpened");
            Label lblDays = (Label)e.Row.FindControl("lblDays");
            imgDateOpened.Attributes.Add("onclick", "javascript:return showCalendar('" + txtDateOpn.ClientID + "', 'mm/dd/y',ValidateDateOpened,'" + txtDateOpn.ClientID + "," + lblDays.ClientID + "');");
            txtDateOpn.Attributes.Add("onblur", "javascript:ValidateDateOpened('" + txtDateOpn.ClientID + "," + lblDays.ClientID + "');");

            HtmlImage imgTargetCompletionDate = (HtmlImage)e.Row.FindControl("imgTargetCompletionDate");
            imgTargetCompletionDate.Attributes.Add("onclick", "javascript:return showCalendar('" + ((TextBox)e.Row.FindControl("txtTargetCompleteDate")).ClientID + "', 'mm/dd/y');");

            HtmlImage imgActualCompletionDate = (HtmlImage)e.Row.FindControl("imgActualCompletionDate");
            imgActualCompletionDate.Attributes.Add("onclick", "javascript:return showCalendar('" + ((TextBox)e.Row.FindControl("txtActualCompletionDate")).ClientID + "', 'mm/dd/y');");

            #endregion

            #region " BIND DETAILS FOR EDIT "
            // if Operation for edit is available then Bind the controls
            if (strOperation == "edit")
            {
                // show or hide the deficiency 
                HtmlInputHidden hdnResponseID = (HtmlInputHidden)e.Row.FindControl("hdnResponseID");
                hdnResponseID.Value = DataBinder.Eval(e.Row.DataItem, "PK_Inspection_Responses_ID").ToString();
                string strDeficiency_Noted = DataBinder.Eval(e.Row.DataItem, "Deficiency_Noted").ToString();
                rdoDefeciancy.SelectedValue = strDeficiency_Noted;
                if (strDeficiency_Noted == "Y")
                {
                    tdResponseDetails.Style["display"] = "block";
                }

                // get values for the record
                //string strDepartment = DataBinder.Eval(e.Row.DataItem, "Department").ToString();
                string[] strDepartments = DataBinder.Eval(e.Row.DataItem, "Department").ToString().Split(',');
                string strDate_Opened = DataBinder.Eval(e.Row.DataItem, "Date_Opened").ToString();
                string strRecommended_Action = DataBinder.Eval(e.Row.DataItem, "Recommended_Action").ToString();
                string strTarget_Completion_Date = DataBinder.Eval(e.Row.DataItem, "Target_Completion_Date").ToString();
                string strActual_Completion_Date = DataBinder.Eval(e.Row.DataItem, "Actual_Completion_Date").ToString();
                string strNotes = DataBinder.Eval(e.Row.DataItem, "Notes").ToString();

                // get controls
                TextBox txtDateOpened = (TextBox)e.Row.FindControl("txtDateOpened");
                Controls_LongDescription_LongDescription txtAction = (Controls_LongDescription_LongDescription)e.Row.FindControl("txtAction");
                TextBox txtTargetCompleteDate = (TextBox)e.Row.FindControl("txtTargetCompleteDate");
                TextBox txtActualCompletionDate = (TextBox)e.Row.FindControl("txtActualCompletionDate");
                Controls_LongDescription_LongDescription txtNotes = (Controls_LongDescription_LongDescription)e.Row.FindControl("txtNotes");

                // set values in page controls
                //if (strDepartment != "")
                //    drpDepartment.Items.FindByText(strDepartment).Selected = true;

                
                
                foreach(string str in strDepartments)
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

                if (strDate_Opened != "")
                {
                    DateTime dtDateOpened = Convert.ToDateTime(strDate_Opened);
                    if (dtDateOpened != AppConfig.SqlMinDateValue)
                    {
                        TimeSpan ts = DateTime.Today - dtDateOpened;
                        if (ts.Days > 0)
                            lblDays.Text = ts.Days.ToString();
                    }
                }

            }
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
            // settings for hiding or showing the guidance text
            HtmlImage imgGuidance = (HtmlImage)e.Row.FindControl("imgGuidance");
            HtmlTableCell tdGuidanceText = (HtmlTableCell)e.Row.FindControl("tdGuidanceText");
            if (imgGuidance != null && tdGuidanceText != null)
            {
                tdGuidanceText.Style["display"] = "none";
                imgGuidance.Attributes.Add("onclick", "javascript:return ShowHideGuidanceText('" + imgGuidance.ClientID + "','" + tdGuidanceText.ClientID + "')");
            }

            Label lblDays = (Label)e.Row.FindControl("lblDays");

            string strDateOpened = DataBinder.Eval(e.Row.DataItem, "Date_Opened").ToString();
            if (strDateOpened != "")
            {
                DateTime dtDateOpened = Convert.ToDateTime(strDateOpened);
                TimeSpan ts = DateTime.Today - dtDateOpened;
                if (ts.Days > 0)
                    lblDays.Text = ts.Days.ToString();
            }

            DataList rptDepartment = (DataList)e.Row.FindControl("rptDepartment");
            DataTable dtDepartment = LU_Department.SelectAll().Tables[0];
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
            // get the primary key passed in command argument
            PK_Inspection_ID = Convert.ToInt32(e.CommandArgument);

            // display page in either view or edit mode
            if (strOperation == "view")
                BindDetailsForView();
            else
            {
                if (strOperation == "") strOperation = "edit";
                BindDetailsForEdit();
            }
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
                // re-initialize the primary key and operation
                PK_Inspection_ID = -1;
                strOperation = "";
                // bind the details for adding new inspection record
                BindDetailsForAdd();
            }
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


    #endregion

    #region " SAVE "
    protected void btnSave_Click(object sender, EventArgs e)
    {

        #region " SAVE INSPECTION DATA "
        // create object for the Inspection 
        Inspection objInspection = new Inspection();

        // get values from page controls
        objInspection.PK_Inspection_ID = PK_Inspection_ID;
        objInspection.FK_LU_Location_ID = FK_LU_Location_ID;
        objInspection.date = clsGeneral.FormatDateToStore(txtDate);
        objInspection.Inspector_Name = txtInspectorName.Text.Trim();
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
            int PK_Inspection_Responses_ID = hdnResponseID.Value != "" ? Convert.ToInt32(hdnResponseID.Value) : 0;

            // create object for the inspection response 
            Inspection_Responses objResponse = new Inspection_Responses();

            // get values from page controls
            objResponse.PK_Inspection_Responses_ID = PK_Inspection_Responses_ID;
            objResponse.FK_Inspection_ID = PK_Inspection_ID;
            objResponse.FK_Inspection_Question_ID = Convert.ToInt32(gvInspectionEdit.DataKeys[i].Value);
            objResponse.Deficiency_Noted = ((RadioButtonList)gvInspectionEdit.Rows[i].FindControl("rdoDefeciancy")).SelectedValue;
            if (objResponse.Deficiency_Noted == "Y")
            {
                string strDepartment = "";
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
            // insert or update the record depending on the primary key for inspection response
            if (PK_Inspection_Responses_ID > 0)
                objResponse.Update();
            else
                objResponse.Insert();

            // check whether all questions are passed 
            // else open the page in view mode
            if (i == gvInspectionEdit.Rows.Count - 1)
                Response.Redirect("Inspections.aspx?id=" + PK_Inspection_ID + "&op=view");
        }

        #endregion
    }

    #endregion

    #region " METHODS "

    /// <summary>
    /// Bind details for Page in add mode
    /// </summary>
    private void BindDetailsForAdd()
    {
        txtDate.Text = "";
        txtInspectorName.Text = "";
        // get all questions records and bind the grid
        DataTable dtQuestions = Inspection_Questions.SelectAll().Tables[0];
        gvInspectionEdit.DataSource = dtQuestions;
        gvInspectionEdit.DataBind();
    }

    /// <summary>
    /// Binds Details for Page in Edit mode
    /// </summary>
    private void BindDetailsForEdit()
    {
        // get all questions and response data and bind the grid
        DataTable dtInspection = Inspection.SelectQuestionsAndResposnses(PK_Inspection_ID).Tables[0];
        gvInspectionEdit.DataSource = dtInspection;
        gvInspectionEdit.DataBind();
        FK_LU_Location_ID = Convert.ToInt32(dtInspection.Rows[0]["FK_LU_Location_ID"]);

        if (dtInspection.Rows[0]["date"] != DBNull.Value)
            txtDate.Text = clsGeneral.FormatDateToDisplay(Convert.ToDateTime(dtInspection.Rows[0]["date"]));

        txtInspectorName.Text = Convert.ToString(dtInspection.Rows[0]["Inspector_Name"]);
    }

    /// <summary>
    /// Binds Details for page in view mode
    /// </summary>
    private void BindDetailsForView()
    {
        // get all questions and response data and bind the grid
        DataTable dtInspection = Inspection.SelectQuestionsAndResposnses(PK_Inspection_ID).Tables[0];
        gvInspectionView.DataSource = dtInspection;
        gvInspectionView.DataBind();

        // set page in view mode
        dvView.Style["display"] = "block";
        dvEdit.Style["display"] = "none";

        // set FK and other page controls values
        FK_LU_Location_ID = Convert.ToInt32(dtInspection.Rows[0]["FK_LU_Location_ID"]);
        if (dtInspection.Rows[0]["date"] != DBNull.Value)
            lblDate.Text = clsGeneral.FormatDateToDisplay(Convert.ToDateTime(dtInspection.Rows[0]["date"]));

        lblInspectorName.Text = Convert.ToString(dtInspection.Rows[0]["Inspector_Name"]);
        lnkAddNew.Visible = false;
        // Check if User has right To Add or Edit 
        if (App_Access == AccessType.View_Only)
            btnBack.Visible = false;

    }

    /// <summary>
    /// Binds other inspection grids
    /// </summary>
    private void BindGridOtherInspections()
    {
        // get data for the location and bind the grid
        DataTable dtOtherInsp = Inspection.SelectByFKLocation(FK_LU_Location_ID).Tables[0];
        gvOtherInspections.DataSource = dtOtherInsp;
        gvOtherInspections.DataBind();
        if (strOperation == "view")
            gvOtherInspections.Columns[3].Visible = false;

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
        // re-initialize PK and operation as default values
        PK_Inspection_ID = 0;
        strOperation = string.Empty;

        // clear page controls to enter new data
        txtDate.Text = "";
        txtInspectorName.Text = "";
        BindDetailsForAdd();

    }

    /// <summary>
    /// Handles back button click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("Inspections.aspx?id=" + PK_Inspection_ID + "&op=edit");
    }
    #endregion
}
