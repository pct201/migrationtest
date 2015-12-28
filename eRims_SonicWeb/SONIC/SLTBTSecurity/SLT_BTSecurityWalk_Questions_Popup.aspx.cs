using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BAL;
using System.Data;
using ERIMS.DAL;
using System.IO;
using System.Web.UI.HtmlControls;

public partial class SONIC_SLT_BTSecurityWalk_Questions_Popup : clsBasePage
{
    #region Properties

    /// <summary>
    /// PK_LU_SLT_BT_Security_Walk_Focus_Area for SLT BT Security
    /// </summary>
    private decimal PK_LU_SLT_BT_Security_Walk_Focus_Area
    {
        get
        {
            if (!string.IsNullOrEmpty(Request.QueryString["id"]))
            {
                return Convert.ToDecimal(Encryption.Decrypt(Request.QueryString["id"]));
            }
            else
            {
                return 0;
            }
        }
    }

    /// <summary>
    /// FK_SLT_BT_Security_Walk for SLT BT Security
    /// </summary>
    private decimal FK_SLT_BT_Security_Walk
    {
        get
        {
            if (!string.IsNullOrEmpty(Request.QueryString["FK_SLTID"]))
            {
                return Convert.ToDecimal(Request.QueryString["FK_SLTID"]);
            }
            else
            {
                return 0;
            }
        }
    }
    /// <summary>
    /// Denotes the Foreign Key
    /// </summary>
    public decimal PK_SLT_Meeting
    {
        get
        {
            if (!string.IsNullOrEmpty(Request.QueryString["PK_SLT_Meeting"]))
            {
                return Convert.ToDecimal(Request.QueryString["PK_SLT_Meeting"]);
            }
            else
            {
                return 0;
            }
        }
    }
    /// <summary>
    /// Denotes the Foreign Key
    /// </summary>
    public decimal PK_SLT_Meeting_Schedule
    {
        get
        {
            if (!string.IsNullOrEmpty(Request.QueryString["PK_MSID"]))
            {
                return Convert.ToDecimal(Request.QueryString["PK_MSID"]);
            }
            else
            {
                return 0;
            }
        }
    }
    /// <summary>
    /// Year for SLT BT Security
    /// </summary>
    private int Year
    {
        get
        {
            if (!string.IsNullOrEmpty(Request.QueryString["Year"]))
            {
                return Convert.ToInt32(Encryption.Decrypt(Request.QueryString["Year"]));
            }
            else
            {
                return 0;
            }
        }
    }

    /// <summary>
    /// Month for SLT BT Security
    /// </summary>
    private string Month
    {
        get
        {
            if (!string.IsNullOrEmpty(Request.QueryString["Month"]))
            {
                return Encryption.Decrypt(Request.QueryString["Month"]);
            }
            else
            {
                return string.Empty;
            }
        }
    }
    /// <summary>
    /// Denotes the operation whether edit or view
    /// </summary>
    public string StrOperation
    {
        get { return Convert.ToString(ViewState["strOperation"]); }
        set { ViewState["strOperation"] = value; }
    }
    private DateTime? Actual_Meeting_Date
    {
        get
        {
            if (!string.IsNullOrEmpty(Request.QueryString["AM_date"]))
                return Convert.ToDateTime(Request.QueryString["AM_date"]);
            else
                return null;
        }
    }
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["op"] != null) { StrOperation = Convert.ToString(Request.QueryString["op"]); }
            if (StrOperation != string.Empty)
            {
                if (StrOperation == "view")
                {
                    pnl.Visible = false;
                    pnlView.Visible = true;
                    BindDepartmentsView();
                    BindControlsForView();
                    BindGridAttachmentsFocusAreaView();
                }
                else
                {
                    pnl.Visible = true;
                    pnlView.Visible = false;
                    BindDepartments();
                    BindControls();
                    BindGridAttachmentsFocusArea();
                }
            }
        }
    }
    public void BindDepartmentsView()
    {
        ComboHelper.FillSLT_BTSecurity_DepartmentObserved(new ListBox[] { lstDepartmentsView });

        DataSet dsSLTMembers = SLT_Members.SLT_MembersSelectByFk(PK_SLT_Meeting, 0, PK_SLT_Meeting_Schedule);
        if (dsSLTMembers != null)
        {
            DataTable dtSLTMembers = dsSLTMembers.Tables[0];
            if (dtSLTMembers.Rows.Count > 0)
            {
                ddlSLTMemberView.DataTextField = "FullName";
                ddlSLTMemberView.DataValueField = "PK_SLT_Members";
                ddlSLTMemberView.DataSource = dtSLTMembers;
                ddlSLTMemberView.DataBind();
            }
        }
    }
    public void BindDepartments()
    {
        ComboHelper.FillSLT_BTSecurity_DepartmentObserved(new ListBox[] { lstDepartments });

        DataSet dsSLTMembers = SLT_Members.SLT_MembersSelectByFk(PK_SLT_Meeting, 0, PK_SLT_Meeting_Schedule);
        if (dsSLTMembers != null)
        {
            DataTable dtSLTMembers = dsSLTMembers.Tables[0];
            if (dtSLTMembers.Rows.Count > 0)
            {
                ddlSLTMember.DataTextField = "FullName";
                ddlSLTMember.DataValueField = "PK_SLT_Members";
                ddlSLTMember.DataSource = dtSLTMembers;
                ddlSLTMember.DataBind();
            }
            else
            {
                ddlSLTMember.Items.Insert(0, new ListItem("-- Select --", "0"));
            }
        }
    }
    public void BindControls()
    {
        DataSet dsQuestions = clsLU_SLT_BT_Security_Walk_Focus_Area.SelectByMonthAndYear(Year, Month, 0, PK_SLT_Meeting_Schedule);


        if (dsQuestions != null)
        {
            if (dsQuestions.Tables.Count > 0)
            {
                DataTable dtQuestions = dsQuestions.Tables[0];

                // bind the grid.
                gvSLT_Questions.DataSource = dtQuestions;
                gvSLT_Questions.DataBind();
                clsLU_SLT_BT_Security_Walk_Focus_Area objFocusArea;
                if (PK_LU_SLT_BT_Security_Walk_Focus_Area > 0)
                    objFocusArea = new clsLU_SLT_BT_Security_Walk_Focus_Area(PK_LU_SLT_BT_Security_Walk_Focus_Area);
                else
                    objFocusArea = new clsLU_SLT_BT_Security_Walk_Focus_Area(Convert.ToDecimal(dsQuestions.Tables[0].Rows[0]["PK_LU_SLT_BT_Security_Walk_Focus_Area"]));

                lblFocusArea.Text = objFocusArea.Focus_Area.ToString();
                lblMonthYear.Text = Month.ToString() + " " + Year.ToString();
                if (!string.IsNullOrEmpty(objFocusArea.Question))
                    txtQuestion.Text = objFocusArea.Question.ToString();
                if (!string.IsNullOrEmpty(objFocusArea.Guidance))
                    txtGuidance.Text = objFocusArea.Guidance.ToString();
                if (!string.IsNullOrEmpty(objFocusArea.Reference))
                    txtReference.Text = objFocusArea.Reference.ToString();
                if (!string.IsNullOrEmpty(objFocusArea.Sort_Order.ToString()))
                    lblQuestionNumber.Text = " " + objFocusArea.Sort_Order.ToString();

            }
        }
        DataSet dsOtherInfo = clsLU_SLT_BT_Security_Walk_Focus_Area.SelectByMonthAndYear(Year, Month, PK_LU_SLT_BT_Security_Walk_Focus_Area, PK_SLT_Meeting_Schedule);
        if (dsOtherInfo != null)
        {
            if (dsOtherInfo.Tables.Count > 0)
            {
                DataTable dtOtherInfo = dsOtherInfo.Tables[0];
                if (dtOtherInfo.Rows.Count > 0)
                {
                    if (!string.IsNullOrEmpty(dtOtherInfo.Rows[0]["PK_SLT_BT_Security_Walk_Responses"].ToString()))
                        hdnPK_SLT_BTSecurity_Walk_Responses.Value = dtOtherInfo.Rows[0]["PK_SLT_BT_Security_Walk_Responses"].ToString();
                    else
                        hdnPK_SLT_BTSecurity_Walk_Responses.Value = "0";
                    if (!string.IsNullOrEmpty(dtOtherInfo.Rows[0]["FK_SLT_Members"].ToString()))
                        ddlSLTMember.SelectedValue = dtOtherInfo.Rows[0]["FK_SLT_Members"].ToString();
                    if (!string.IsNullOrEmpty(dtOtherInfo.Rows[0]["Observation_Acceptable"].ToString()))
                        rblObservation.SelectedValue = dtOtherInfo.Rows[0]["Observation_Acceptable"].ToString();
                    if (!string.IsNullOrEmpty(dtOtherInfo.Rows[0]["What_Needs_To_Be_Done"].ToString()))
                        txtWhatNeeds.Text = dtOtherInfo.Rows[0]["What_Needs_To_Be_Done"].ToString();
                    if (!string.IsNullOrEmpty(dtOtherInfo.Rows[0]["To_Be_Completed_By"].ToString()))
                        txtCompletedBy.Text = clsGeneral.FormatDateToDisplay(Convert.ToDateTime(dtOtherInfo.Rows[0]["To_Be_Completed_By"]));
                    if (!string.IsNullOrEmpty(dtOtherInfo.Rows[0]["Completed_Date"].ToString()))
                        txtCompletionDate.Text = clsGeneral.FormatDateToDisplay(Convert.ToDateTime(dtOtherInfo.Rows[0]["Completed_Date"]));

                    hdnNextOpenQueID.Value = dtOtherInfo.Rows[0]["NextQueID"].ToString();

                    if (hdnNextOpenQueID.Value == "0")
                    {
                        btnSaveAndReturn.Visible = true;
                        btnSaveAndNext.Visible = false;
                    }
                    else
                    {
                        btnSaveAndReturn.Visible = false;
                        btnSaveAndNext.Visible = true;
                    }


                    if (!string.IsNullOrEmpty(dtOtherInfo.Rows[0]["Observation_Acceptable"].ToString()))
                    {
                        if (dtOtherInfo.Rows[0]["Observation_Acceptable"].ToString() == "N")
                        {
                            rblPictureDoc.SelectedValue = "N";
                            pnlAddPicture.Visible = false;
                            pnlAttachment.Visible = false;
                            rblPictureDoc2.SelectedValue = "Y";
                            pnlAttachment2.Visible = true;
                        }
                        else
                        {
                            rblPictureDoc.SelectedValue = "Y";
                            pnlAddPicture.Visible = true;
                            pnlAttachment.Visible = true;
                            rblPictureDoc2.SelectedValue = "N";
                            pnlAttachment2.Visible = false;
                        }
                    }
                    else
                    {
                        rblPictureDoc.SelectedValue = "N";
                        pnlAddPicture.Visible = false;
                        pnlAttachment.Visible = false;
                        rblPictureDoc2.SelectedValue = "N";
                        pnlAttachment2.Visible = false;
                    }

                    if (!string.IsNullOrEmpty(dtOtherInfo.Rows[0]["PK_SLT_BT_Security_Walk_Responses"].ToString()))
                    {
                        DataSet dsDepartment = clsLU_SLT_BT_Security_Walk_Department.SelectBy_FK_SLT_BTSecurity_Walk_Responses(Convert.ToDecimal(dtOtherInfo.Rows[0]["PK_SLT_BT_Security_Walk_Responses"]));
                        if (dsDepartment.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow drDepartment in dsDepartment.Tables[0].Rows)
                            {
                                foreach (ListItem lstDepartmentName in lstDepartments.Items)
                                {
                                    if (lstDepartmentName.Value == drDepartment["FK_LU_SLT_BT_Security_Walk_Department"].ToString())
                                    {
                                        lstDepartmentName.Selected = true;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        if (rblGuidance.SelectedValue == "N")
            pnlGuidance.Visible = false;
        else
            pnlGuidance.Visible = true;
        if (rblObservation.SelectedValue == "N")
        {
            pnlAddPicture.Visible = false;
            pnlAttachment.Visible = false;
            pnlAttachment2.Visible = false;
            pnlNeedtoBeDone.Visible = true;
            //rblPictureDoc2.SelectedValue = "Y";
        }
        else
        {
            pnlAddPicture.Visible = true;
            pnlAttachment.Visible = true;
            pnlAttachment2.Visible = true;
            pnlNeedtoBeDone.Visible = false;
            // rblPictureDoc2.SelectedValue = "N";
        }
        if (rblPictureDoc.SelectedValue == "N")
            pnlAttachment.Visible = false;
        else
            pnlAttachment.Visible = true;
        if (rblPictureDoc2.SelectedValue == "N")
            pnlAttachment2.Visible = false;
        else
            pnlAttachment2.Visible = true;
    }

    public void BindControlsForView()
    {
        DataSet dsQuestions = clsLU_SLT_BT_Security_Walk_Focus_Area.SelectByMonthAndYear(Year, Month, 0, PK_SLT_Meeting_Schedule);

        if (dsQuestions != null)
        {
            if (dsQuestions.Tables.Count > 0)
            {
                DataTable dtQuestions = dsQuestions.Tables[0];

                // bind the grid.
                gvSLT_QuestionsView.DataSource = dtQuestions;
                gvSLT_QuestionsView.DataBind();
                clsLU_SLT_BT_Security_Walk_Focus_Area objFocusArea;
                if (PK_LU_SLT_BT_Security_Walk_Focus_Area > 0)
                    objFocusArea = new clsLU_SLT_BT_Security_Walk_Focus_Area(PK_LU_SLT_BT_Security_Walk_Focus_Area);
                else
                    objFocusArea = new clsLU_SLT_BT_Security_Walk_Focus_Area(Convert.ToDecimal(dsQuestions.Tables[0].Rows[0]["PK_LU_SLT_BT_Security_Walk_Focus_Area"]));

                lblFocusAreaView.Text = objFocusArea.Focus_Area.ToString();
                lblMonthYearView.Text = Month.ToString() + " " + Year.ToString();
                if (!string.IsNullOrEmpty(objFocusArea.Question))
                    txtQuestionView.Text = objFocusArea.Question.ToString();
                if (!string.IsNullOrEmpty(objFocusArea.Guidance))
                    txtGuidanceView.Text = objFocusArea.Guidance.ToString();
                if (!string.IsNullOrEmpty(objFocusArea.Reference))
                    txtReferenceView.Text = objFocusArea.Reference.ToString();
                if (!string.IsNullOrEmpty(objFocusArea.Sort_Order.ToString()))
                    lblQuestionNumberView.Text = " " + objFocusArea.Sort_Order.ToString();

            }
        }
        DataSet dsOtherInfo = clsLU_SLT_BT_Security_Walk_Focus_Area.SelectByMonthAndYear(Year, Month, PK_LU_SLT_BT_Security_Walk_Focus_Area, PK_SLT_Meeting_Schedule);
        if (dsOtherInfo != null)
        {
            if (dsOtherInfo.Tables.Count > 0)
            {
                DataTable dtOtherInfo = dsOtherInfo.Tables[0];
                if (!string.IsNullOrEmpty(dtOtherInfo.Rows[0]["PK_SLT_BT_Security_Walk_Responses"].ToString()))
                    hdnPK_SLT_BTSecurity_Walk_ResponsesView.Value = dtOtherInfo.Rows[0]["PK_SLT_BT_Security_Walk_Responses"].ToString();
                else
                    hdnPK_SLT_BTSecurity_Walk_ResponsesView.Value = "0";
                if (!string.IsNullOrEmpty(dtOtherInfo.Rows[0]["FK_SLT_Members"].ToString()))
                    ddlSLTMemberView.SelectedValue = dtOtherInfo.Rows[0]["FK_SLT_Members"].ToString();
                if (!string.IsNullOrEmpty(dtOtherInfo.Rows[0]["Observation_Acceptable"].ToString()))
                    rblObservationView.SelectedValue = dtOtherInfo.Rows[0]["Observation_Acceptable"].ToString();
                if (!string.IsNullOrEmpty(dtOtherInfo.Rows[0]["What_Needs_To_Be_Done"].ToString()))
                    txtWhatNeedsView.Text = dtOtherInfo.Rows[0]["What_Needs_To_Be_Done"].ToString();
                if (!string.IsNullOrEmpty(dtOtherInfo.Rows[0]["To_Be_Completed_By"].ToString()))
                    txtCompletedByView.Text = clsGeneral.FormatDateToDisplay(Convert.ToDateTime(dtOtherInfo.Rows[0]["To_Be_Completed_By"]));
                if (!string.IsNullOrEmpty(dtOtherInfo.Rows[0]["Completed_Date"].ToString()))
                    txtCompletionDateView.Text = clsGeneral.FormatDateToDisplay(Convert.ToDateTime(dtOtherInfo.Rows[0]["Completed_Date"]));

                if (!string.IsNullOrEmpty(dtOtherInfo.Rows[0]["PK_SLT_BT_Security_Walk_Responses"].ToString()))
                {
                    DataSet dsDepartment = clsSLT_BT_Security_Walk_Responses_Department.SelectBy_FK_SLT_BT_Security_Walk_Responses(Convert.ToDecimal(dtOtherInfo.Rows[0]["PK_SLT_BT_Security_Walk_Responses"]));
                    if (dsDepartment.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow drDepartment in dsDepartment.Tables[0].Rows)
                        {
                            foreach (ListItem lstDepartmentName in lstDepartmentsView.Items)
                            {
                                if (lstDepartmentName.Value == drDepartment["FK_LU_SLT_BT_Security_Walk_Department"].ToString())
                                {
                                    lstDepartmentName.Selected = true;
                                }
                            }
                        }
                    }
                }
            }
        }
    }

    /// <summary>
    /// Bind Gris Attachment Focus Area
    /// </summary>
    private void BindGridAttachmentsFocusArea()
    {
        if (hdnPK_SLT_BTSecurity_Walk_Responses.Value != "")
        {
            if (hdnPK_SLT_BTSecurity_Walk_Responses.Value != "0")
            {
                DataTable dtAttach = clsSLT_BT_Security_Walk_Attachments.SelectByFK(Convert.ToDecimal(hdnPK_SLT_BTSecurity_Walk_Responses.Value)).Tables[0];

                gvFocusAreaAttachmentEdit.DataSource = dtAttach;
                gvFocusAreaAttachmentEdit.DataBind();

                gvFocusAreaAttachmentEdit2.DataSource = dtAttach;
                gvFocusAreaAttachmentEdit2.DataBind();

                if (rblObservation.SelectedValue == "N" && dtAttach.Rows.Count > 0)
                {
                    rblPictureDoc2.SelectedValue = "Y";
                    pnlAttachment2.Visible = true;
                }
                else
                {
                    rblPictureDoc2.SelectedValue = "N";
                    pnlAttachment2.Visible = false;
                }

                if (dtAttach.Rows.Count < 10)
                {
                    lnkAddNewFAAttach.Visible = true;
                    lnkAddNewFAAttach2.Visible = true;

                    dtAttach = null;
                }
                else
                {
                    lnkAddNewFAAttach.Visible = false;
                    lnkAddNewFAAttach2.Visible = false;
                }
            }
        }
    }
    /// <summary>
    /// Bind Gris Attachment Focus Area
    /// </summary>
    private void BindGridAttachmentsFocusAreaView()
    {
        if (hdnPK_SLT_BTSecurity_Walk_ResponsesView.Value != "0")
        {
            DataTable dtAttach = clsSLT_BT_Security_Walk_Attachments.SelectByFK(Convert.ToDecimal(hdnPK_SLT_BTSecurity_Walk_ResponsesView.Value)).Tables[0];
            gvFocusAreaAttachmentView.DataSource = dtAttach;
            gvFocusAreaAttachmentView.DataBind();
        }
    }
    protected void gvSLT_Questions_ItemCommand(object source, DataListCommandEventArgs e)
    {
        if (e.CommandName == "Edit")
        {
            Response.Redirect("SLT_BTSecurityWalk_Questions_Popup.aspx?id=" + Encryption.Encrypt(Convert.ToString(e.CommandArgument)) + "&FK_SLTID= " + FK_SLT_BT_Security_Walk + "&Year=" + Encryption.Encrypt(Convert.ToString(Year)) + "&Month=" + Encryption.Encrypt(Convert.ToString(Month)) + "&PK_SLT_Meeting=" + PK_SLT_Meeting.ToString() + "&PK_MSID=" + PK_SLT_Meeting_Schedule + "&AM_date=" + Actual_Meeting_Date + "&op=" + StrOperation, true);
            //Response.Redirect("SLT_SafetyWalk_Questions_Popup.aspx?id=" + Encryption.Encrypt(Convert.ToString(e.CommandArgument)) + "&FK_SLTID= " + FK_SLT_BT_Security_Walk + "&Year=" + Encryption.Encrypt(Convert.ToString(Year)) + "&Month=" + Encryption.Encrypt(Convert.ToString(Month)) + "&PK_SLT_Meeting=" + PK_SLT_Meeting.ToString() + "&PK_MSID=" + PK_SLT_Meeting_Schedule + "&AM_date=" + Actual_Meeting_Date + "&op=" + StrOperation, true);
        }
    }
    protected void gvSLT_Questions_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            LinkButton lnkReference = (LinkButton)e.Item.FindControl("lnkReference");
            if (lnkReference != null)
            {
                if (Convert.ToDecimal(lnkReference.CommandArgument) == PK_LU_SLT_BT_Security_Walk_Focus_Area)
                    lnkReference.Enabled = false;
                else
                    lnkReference.Enabled = true;
            }
        }
    }
    protected void rblGuidance_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rblGuidance.SelectedValue == "N")
            pnlGuidance.Visible = false;
        else
            pnlGuidance.Visible = true;
    }
    protected void rblObservation_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rblObservation.SelectedValue == "N")
        {
            rblPictureDoc.SelectedValue = "N";
            pnlAddPicture.Visible = false;
            pnlAttachment.Visible = false;
            pnlNeedtoBeDone.Visible = true;
        }
        else
        {
            rblPictureDoc.SelectedValue = "Y";
            pnlAddPicture.Visible = true;
            pnlAttachment.Visible = true;
            pnlNeedtoBeDone.Visible = false;
        }
    }
    protected void rblPictureDoc_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rblPictureDoc.SelectedValue == "N")
            pnlAttachment.Visible = false;
        else
            pnlAttachment.Visible = true;
    }
    protected void rblPictureDoc2_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rblPictureDoc2.SelectedValue == "N")
            pnlAttachment2.Visible = false;
        else
            pnlAttachment2.Visible = true;
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
            clsSLT_BT_Security_Walk_Attachments.DeleteByPK(intPK);
            BindGridAttachmentsFocusArea();

            // delete file
            string strPath = clsGeneral.GetAttachmentDocPath(clsGeneral.ExposureTableNames[(int)clsGeneral.Exposure_Tables.SLT_BT_Security_Walk_Attachments]) + strFileName;
            if (File.Exists(strPath))
                File.Delete(strPath);
        }
    }
    /// <summary>
    /// GridView Focus Area Attachment Row Data Bound Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvFocusAreaAttachement_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        // check for the data row
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            // get the filename link control
            HtmlAnchor lnkAttachFile = (HtmlAnchor)e.Row.FindControl("lnkAttachFile");

            // get the file name value from binder
            string strFileName = DataBinder.Eval(e.Row.DataItem, "Attachment_Filename").ToString();
            strFileName = AppConfig.strSLT_BTSecurityWalkDocPath + strFileName;
            string strFilePath = Encryption.Encrypt(strFileName).Replace("'", "\\'");
            // set click attribute to open file on clicking the link
            lnkAttachFile.Attributes.Add("onclick", "javascript:window.open('" + AppConfig.SiteURL + "/Download.aspx?attachfile=" + strFilePath + "')");
        }
    }

    protected void lnkAddNewFAAttach_Click(object sender, EventArgs e)
    {
        SaveData("1");

        Page.ClientScript.RegisterStartupScript(typeof(string), "ABC", "javascript:ShowAttachmentFA();", true);
    }

    /// <summary>
    /// Grid View Focus Attachment Edit Row Command Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvFocusAreaAttachmentEdit2_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        // if passed command is for removing attachment then
        // delete the attachment record by PK passed in command argument and
        // bind the grid
        if (e.CommandName == "RemoveAttachment")
        {
            string[] strArgs = e.CommandArgument.ToString().Split(':');
            int intPK = Convert.ToInt32(strArgs[0]);
            string strFileName = strArgs[1];
            clsSLT_BT_Security_Walk_Attachments.DeleteByPK(intPK);
            BindGridAttachmentsFocusArea();

            // delete file
            string strPath = clsGeneral.GetAttachmentDocPath(clsGeneral.ExposureTableNames[(int)clsGeneral.Exposure_Tables.SLT_BT_Security_Walk_Attachments]) + strFileName;
            if (File.Exists(strPath))
                File.Delete(strPath);
        }
    }
    /// <summary>
    /// GridView Focus Area Attachment Row Data Bound Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvFocusAreaAttachmentEdit2_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        // check for the data row
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            // get the filename link control
            HtmlAnchor lnkAttachFile = (HtmlAnchor)e.Row.FindControl("lnkAttachFile");

            // get the file name value from binder
            string strFileName = DataBinder.Eval(e.Row.DataItem, "Attachment_Filename").ToString();
            strFileName = AppConfig.strSLT_BTSecurityWalkDocPath + strFileName;
            string strFilePath = Encryption.Encrypt(strFileName).Replace("'", "\\'");
            // set click attribute to open file on clicking the link
            lnkAttachFile.Attributes.Add("onclick", "javascript:window.open('" + AppConfig.SiteURL + "/Download.aspx?attachfile=" + strFilePath + "')");
        }
    }

    protected void lnkAddNewFAAttach2_Click(object sender, EventArgs e)
    {
        SaveData("2");

        //Page.ClientScript.RegisterStartupScript(typeof(string), "ABC", "javascript:ShowAttachmentFA2();", true);
    }

    /// <summary>
    /// Upload Focus Area Attachment Details
    /// </summary>
    protected void UploadFocusArea_Attachment()
    {
        try
        {
            if (hdnPK_SLT_BTSecurity_Walk_Responses.Value != "0")
            {
                // add attachment
                ucBTsecurityFocusAreaAttachment.FK_SLT_BT_Security_Walk_Responses = Convert.ToInt32(hdnPK_SLT_BTSecurity_Walk_Responses.Value);
                ucBTsecurityFocusAreaAttachment.Add(clsGeneral.Exposure_Tables.SLT_BT_Security_Walk_Attachments);
                trAttachmentFA.Style["display"] = "none";

                // bind Building attachment grid to list newly added attachment
                BindGridAttachmentsFocusArea();
            }
            else
            {
                clsGeneral.ShowAlert("Please Save First SLT BT Security Walk Responses Details.", this);
                return;
            }
        }
        catch (Exception ex)
        {
            clsGeneral.ShowAlert(ex.Message, this);
            return;
        }
    }
    /// <summary>
    /// Upload Focus Area Attachment Details
    /// </summary>
    protected void UploadFocusArea2_Attachment()
    {
        if (hdnPK_SLT_BTSecurity_Walk_Responses.Value != "0")
        {
            // add attachment
            ucBTsecurityFocusAreaAttachment2.FK_SLT_BT_Security_Walk_Responses = Convert.ToInt32(hdnPK_SLT_BTSecurity_Walk_Responses.Value);
            ucBTsecurityFocusAreaAttachment2.Add(clsGeneral.Exposure_Tables.SLT_BT_Security_Walk_Attachments);
            trAttachmentFA.Style["display"] = "none";

            // bind Building attachment grid to list newly added attachment
            BindGridAttachmentsFocusArea();
        }
        else
        {
            clsGeneral.ShowAlert("Please Save First SLT BT Security Walk Responses Details.", this);
            return;
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            TextBox txtAttachmentDesc = (TextBox)ucBTsecurityFocusAreaAttachment2.FindControl("txtType");
            FileUpload fpFile = (FileUpload)ucBTsecurityFocusAreaAttachment2.FindControl("fpFile");
            if (fpFile.HasFile && string.IsNullOrEmpty(txtAttachmentDesc.Text))
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:alert('Please enter the Attachment Detail');ShowAttachmentFA2();", true);
                txtAttachmentDesc.Focus();
            }
            else
            {

                //SLT_Meeting_Schedule objMeetingSchedule = new SLT_Meeting_Schedule(PK_SLT_Meeting_Schedule);
                if (Actual_Meeting_Date != null)
                {
                    //SLT_Safety_Walk_Responses objRes = new SLT_Safety_Walk_Responses();
                    clsSLT_BT_Security_Walk_Responses objRes = new clsSLT_BT_Security_Walk_Responses();

                    decimal PK_SLT_BT_Security_Walk_Responses;
                    objRes.FK_SLT_BT_Security_Walk = FK_SLT_BT_Security_Walk;
                    objRes.FK_LU_SLT_BT_Security_Walk_Focus_Area = PK_LU_SLT_BT_Security_Walk_Focus_Area;
                    if (ddlSLTMember.SelectedValue != "0")
                        objRes.FK_SLT_Members = Convert.ToDecimal(ddlSLTMember.SelectedValue);
                    string sMonthName = Month;
                    //sMonthName = Month;
                    int iMonthNo = Convert.ToDateTime("01-" + sMonthName + "-" + Year).Month;
                    objRes.Month = iMonthNo;
                    objRes.Year = Year;
                    if (!string.IsNullOrEmpty(txtCompletionDate.Text))
                        objRes.Completed_Date = Convert.ToDateTime(txtCompletionDate.Text);
                    objRes.Observation_Acceptable = rblObservation.SelectedValue.ToString();
                    if (!string.IsNullOrEmpty(txtCompletedBy.Text))
                        objRes.To_Be_Completed_By = Convert.ToDateTime(txtCompletedBy.Text);
                    objRes.What_Needs_To_Be_Done = txtWhatNeeds.Text;
                    if (!string.IsNullOrEmpty(clsSession.UserID))
                        objRes.Updated_By = clsSession.UserID;
                    objRes.Updated_Date = DateTime.Now.Date;

                    if (!string.IsNullOrEmpty(hdnPK_SLT_BTSecurity_Walk_Responses.Value))
                    {
                        if (hdnPK_SLT_BTSecurity_Walk_Responses.Value != "0")
                        {
                            objRes.PK_SLT_BT_Security_Walk_Responses = Convert.ToDecimal(hdnPK_SLT_BTSecurity_Walk_Responses.Value);
                            PK_SLT_BT_Security_Walk_Responses = Convert.ToDecimal(hdnPK_SLT_BTSecurity_Walk_Responses.Value);
                            objRes.Update();
                        }
                        else
                        {
                            PK_SLT_BT_Security_Walk_Responses = objRes.Insert();
                            hdnPK_SLT_BTSecurity_Walk_Responses.Value = Convert.ToString(PK_SLT_BT_Security_Walk_Responses);
                        }
                    }
                    else
                    {
                        PK_SLT_BT_Security_Walk_Responses = objRes.Insert();
                        hdnPK_SLT_BTSecurity_Walk_Responses.Value = Convert.ToString(PK_SLT_BT_Security_Walk_Responses);
                    }

                    clsSLT_BT_Security_Walk_Responses_Department objdepartmnt = new clsSLT_BT_Security_Walk_Responses_Department();
                    if (GetSelectedItemString(lstDepartments, false) != "")
                        objdepartmnt.Insert(PK_SLT_BT_Security_Walk_Responses, GetSelectedItemString(lstDepartments, false));

                    BindGridAttachmentsFocusArea();
                    BindControls();
                    txtAttachmentDesc.Text = string.Empty;
                    Page.ClientScript.RegisterStartupScript(typeof(string), DateTime.Now.ToString(), "javascript:ReloadParent();", true);
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:alert('Please enter the Actual Meeting Date on the Meeting Attendees screen before proceeding.');", true);
                }
            }
        }
        catch (Exception ex)
        {
            if (ex.Message.Contains("with same focus area"))
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:alert('Question you are trying to save is already exits.Please try again.');", true);
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:alert('Error occurred while saving your data.');", true);
            }
        }
    }

    /// <summary>
    /// return Comma separated list of all selected item in list box
    /// </summary>
    /// <param name="lstBox"></param>
    /// <returns></returns>
    public string GetSelectedItemString(ListBox lstBox, bool isStringValue)
    {
        string strValues = "";
        foreach (ListItem lstBoxItem in lstBox.Items)
        {
            if (lstBoxItem.Selected)
            {
                if (isStringValue)
                    strValues = strValues + "'" + lstBoxItem.Value.Replace("'", "''") + "',";
                else
                    strValues = strValues + lstBoxItem.Value.Replace("'", "''") + ",";
            }

        }
        return strValues.TrimEnd(',');
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Page.ClientScript.RegisterStartupScript(typeof(string), DateTime.Now.ToString(), "javascript:SaveRecord();", true);
    }
    protected void btnSaveAndNext_Click(object sender, EventArgs e)
    {
        try
        {
            // SLT_Meeting_Schedule objMeetingSchedule = new SLT_Meeting_Schedule(PK_SLT_Meeting_Schedule);
            if (Actual_Meeting_Date != null)
            {
                clsSLT_BT_Security_Walk_Responses objRes = new clsSLT_BT_Security_Walk_Responses();
                decimal PK_SLT_BT_Security_Walk_Responses;
                objRes.FK_SLT_BT_Security_Walk = FK_SLT_BT_Security_Walk;
                objRes.FK_LU_SLT_BT_Security_Walk_Focus_Area = PK_LU_SLT_BT_Security_Walk_Focus_Area;
                if (ddlSLTMember.SelectedValue != "0")
                    objRes.FK_SLT_Members = Convert.ToDecimal(ddlSLTMember.SelectedValue);
                string sMonthName = Month;
                sMonthName = Month;
                int iMonthNo = Convert.ToDateTime("01-" + sMonthName + "-" + Year).Month;
                objRes.Month = iMonthNo;
                objRes.Year = Year;
                if (!string.IsNullOrEmpty(txtCompletionDate.Text))
                    objRes.Completed_Date = Convert.ToDateTime(txtCompletionDate.Text);
                objRes.Observation_Acceptable = rblObservation.SelectedValue.ToString();
                if (!string.IsNullOrEmpty(txtCompletedBy.Text))
                    objRes.To_Be_Completed_By = Convert.ToDateTime(txtCompletedBy.Text);
                objRes.What_Needs_To_Be_Done = txtWhatNeeds.Text;
                if (!string.IsNullOrEmpty(clsSession.UserID))
                    objRes.Updated_By = clsSession.UserID;
                objRes.Updated_Date = DateTime.Now.Date;

                if (!string.IsNullOrEmpty(hdnPK_SLT_BTSecurity_Walk_Responses.Value))
                {
                    if (hdnPK_SLT_BTSecurity_Walk_Responses.Value != "0")
                    {
                        objRes.PK_SLT_BT_Security_Walk_Responses = Convert.ToDecimal(hdnPK_SLT_BTSecurity_Walk_Responses.Value);
                        PK_SLT_BT_Security_Walk_Responses = Convert.ToDecimal(hdnPK_SLT_BTSecurity_Walk_Responses.Value);
                        objRes.Update();
                    }
                    else
                        PK_SLT_BT_Security_Walk_Responses = objRes.Insert();
                }
                else
                    PK_SLT_BT_Security_Walk_Responses = objRes.Insert();

                clsSLT_BT_Security_Walk_Responses_Department objdepartmnt = new clsSLT_BT_Security_Walk_Responses_Department();
                if (GetSelectedItemString(lstDepartments, false) != "")
                    objdepartmnt.Insert(PK_SLT_BT_Security_Walk_Responses, GetSelectedItemString(lstDepartments, false));

                if (!string.IsNullOrEmpty(hdnNextOpenQueID.Value) && hdnNextOpenQueID.Value != "0")
                    Response.Redirect("SLT_BTSecurityWalk_Questions_Popup.aspx?id=" + Encryption.Encrypt(Convert.ToString(hdnNextOpenQueID.Value)) + "&FK_SLTID= " + FK_SLT_BT_Security_Walk + "&Year=" + Encryption.Encrypt(Convert.ToString(Year)) + "&Month=" + Encryption.Encrypt(Convert.ToString(Month)) + "&PK_SLT_Meeting=" + PK_SLT_Meeting.ToString() + "&PK_MSID=" + PK_SLT_Meeting_Schedule + "&AM_date=" + Actual_Meeting_Date + "&op=" + StrOperation, true);
                else
                    Page.ClientScript.RegisterStartupScript(typeof(string), DateTime.Now.ToString(), "javascript:SaveRecord();", true);
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:alert('Please enter the Actual Meeting Date on the Meeting Attendees screen before proceeding.');", true);
            }
            //BindControls();
        }
        catch (Exception ex)
        {
            if (ex.Message.Contains("with same focus area"))
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:alert('Question you are trying to save is already exits.Please try again.');", true);
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:alert('Error occurred while saving your data.');", true);
            }
        }
    }

    /// <summary>
    /// This function is used to automatic save the slt_safety_walk_responses if user click on Add Attachment link
    /// </summary>
    /// <param name="attachmentrow"></param>
    /// <returns></returns>
    private void SaveData(string attachmentrow)
    {
        try
        {
            TextBox txtAttachmentDesc = (TextBox)ucBTsecurityFocusAreaAttachment2.FindControl("txtType");
            FileUpload fpFile = (FileUpload)ucBTsecurityFocusAreaAttachment2.FindControl("fpFile");
            if (fpFile.HasFile && string.IsNullOrEmpty(txtAttachmentDesc.Text))
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:alert('Please enter the Attachment Detail');ShowAttachmentFA2();", true);
                txtAttachmentDesc.Focus();
            }
            else
            {

                //SLT_Meeting_Schedule objMeetingSchedule = new SLT_Meeting_Schedule(PK_SLT_Meeting_Schedule);
                if (Actual_Meeting_Date != null)
                {
                    clsSLT_BT_Security_Walk_Responses objRes = new clsSLT_BT_Security_Walk_Responses();
                    decimal PK_SLT_BT_Security_Walk_Responses;
                    objRes.FK_SLT_BT_Security_Walk = FK_SLT_BT_Security_Walk;
                    objRes.FK_LU_SLT_BT_Security_Walk_Focus_Area = PK_LU_SLT_BT_Security_Walk_Focus_Area;
                    if (ddlSLTMember.SelectedValue != "0")
                        objRes.FK_SLT_Members = Convert.ToDecimal(ddlSLTMember.SelectedValue);
                    string sMonthName = Month;
                    //sMonthName = Month;
                    int iMonthNo = Convert.ToDateTime("01-" + sMonthName + "-" + Year).Month;
                    objRes.Month = iMonthNo;
                    objRes.Year = Year;
                    if (!string.IsNullOrEmpty(txtCompletionDate.Text))
                        objRes.Completed_Date = Convert.ToDateTime(txtCompletionDate.Text);
                    objRes.Observation_Acceptable = rblObservation.SelectedValue.ToString();
                    if (!string.IsNullOrEmpty(txtCompletedBy.Text))
                        objRes.To_Be_Completed_By = Convert.ToDateTime(txtCompletedBy.Text);
                    objRes.What_Needs_To_Be_Done = txtWhatNeeds.Text;
                    if (!string.IsNullOrEmpty(clsSession.UserID))
                        objRes.Updated_By = clsSession.UserID;
                    objRes.Updated_Date = DateTime.Now.Date;

                    if (!string.IsNullOrEmpty(hdnPK_SLT_BTSecurity_Walk_Responses.Value))
                    {
                        if (hdnPK_SLT_BTSecurity_Walk_Responses.Value != "0")
                        {
                            objRes.PK_SLT_BT_Security_Walk_Responses = Convert.ToDecimal(hdnPK_SLT_BTSecurity_Walk_Responses.Value);
                            PK_SLT_BT_Security_Walk_Responses = Convert.ToDecimal(hdnPK_SLT_BTSecurity_Walk_Responses.Value);
                            objRes.Update();
                        }
                        else
                        {
                            PK_SLT_BT_Security_Walk_Responses = objRes.Insert();
                            hdnPK_SLT_BTSecurity_Walk_Responses.Value = Convert.ToString(PK_SLT_BT_Security_Walk_Responses);
                        }
                    }
                    else
                    {
                        PK_SLT_BT_Security_Walk_Responses = objRes.Insert();
                        hdnPK_SLT_BTSecurity_Walk_Responses.Value = Convert.ToString(PK_SLT_BT_Security_Walk_Responses);
                    }

                    clsSLT_BT_Security_Walk_Responses_Department objdepartmnt = new clsSLT_BT_Security_Walk_Responses_Department();
                    if (GetSelectedItemString(lstDepartments, false) != "")
                        objdepartmnt.Insert(PK_SLT_BT_Security_Walk_Responses, GetSelectedItemString(lstDepartments, false));

                    BindControls2();
                    

                    if (attachmentrow == "1")
                    {
                        pnlAttachment.Visible = true;
                        trAttachmentFA.Visible = true;
                    }
                    else
                    {
                        pnlAttachment2.Visible = true;
                        trAttachmentFA2.Visible = true;
                    }
                    //Page.ClientScript.RegisterStartupScript(typeof(string), DateTime.Now.ToString(), "javascript:ReloadParent();", true);                    
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:alert('Please enter the Actual Meeting Date on the Meeting Attendees screen before proceeding.');", true);
                }
            }
        }
        catch (Exception ex)
        {
            if (ex.Message.Contains("with same focus area"))
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:alert('Question you are trying to save is already exits.Please try again.');", true);
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:alert('Error occurred while saving your data.');", true);
            }
        }
    }


    public void BindControls2()
    {
        DataSet dsQuestions = clsLU_SLT_BT_Security_Walk_Focus_Area.SelectByMonthAndYear(Year, Month, 0, PK_SLT_Meeting_Schedule);

        if (dsQuestions != null)
        {
            if (dsQuestions.Tables.Count > 0)
            {
                DataTable dtQuestions = dsQuestions.Tables[0];

                // bind the grid.
                gvSLT_Questions.DataSource = dtQuestions;
                gvSLT_Questions.DataBind();
                clsLU_SLT_BT_Security_Walk_Focus_Area objFocusArea;
                if (PK_LU_SLT_BT_Security_Walk_Focus_Area > 0)
                    objFocusArea = new clsLU_SLT_BT_Security_Walk_Focus_Area(PK_LU_SLT_BT_Security_Walk_Focus_Area);
                else
                    objFocusArea = new clsLU_SLT_BT_Security_Walk_Focus_Area(Convert.ToDecimal(dsQuestions.Tables[0].Rows[0]["PK_LU_SLT_BT_Security_Walk_Focus_Area"]));

                lblFocusArea.Text = objFocusArea.Focus_Area.ToString();
                lblMonthYear.Text = Month.ToString() + " " + Year.ToString();
                if (!string.IsNullOrEmpty(objFocusArea.Question))
                    txtQuestion.Text = objFocusArea.Question.ToString();
                if (!string.IsNullOrEmpty(objFocusArea.Guidance))
                    txtGuidance.Text = objFocusArea.Guidance.ToString();
                if (!string.IsNullOrEmpty(objFocusArea.Reference))
                    txtReference.Text = objFocusArea.Reference.ToString();
                if (!string.IsNullOrEmpty(objFocusArea.Sort_Order.ToString()))
                    lblQuestionNumber.Text = " " + objFocusArea.Sort_Order.ToString();

            }
        }
        DataSet dsOtherInfo = clsLU_SLT_BT_Security_Walk_Focus_Area.SelectByMonthAndYear(Year, Month, PK_LU_SLT_BT_Security_Walk_Focus_Area, PK_SLT_Meeting_Schedule);
        if (dsOtherInfo != null)
        {
            if (dsOtherInfo.Tables.Count > 0)
            {
                DataTable dtOtherInfo = dsOtherInfo.Tables[0];
                if (dtOtherInfo.Rows.Count > 0)
                {
                    if (!string.IsNullOrEmpty(dtOtherInfo.Rows[0]["PK_SLT_BT_Security_Walk_Responses"].ToString()))
                        hdnPK_SLT_BTSecurity_Walk_Responses.Value = dtOtherInfo.Rows[0]["PK_SLT_BT_Security_Walk_Responses"].ToString();
                    else
                        hdnPK_SLT_BTSecurity_Walk_Responses.Value = "0";
                    if (!string.IsNullOrEmpty(dtOtherInfo.Rows[0]["FK_SLT_Members"].ToString()))
                        ddlSLTMember.SelectedValue = dtOtherInfo.Rows[0]["FK_SLT_Members"].ToString();
                    if (!string.IsNullOrEmpty(dtOtherInfo.Rows[0]["Observation_Acceptable"].ToString()))
                        rblObservation.SelectedValue = dtOtherInfo.Rows[0]["Observation_Acceptable"].ToString();
                    if (!string.IsNullOrEmpty(dtOtherInfo.Rows[0]["What_Needs_To_Be_Done"].ToString()))
                        txtWhatNeeds.Text = dtOtherInfo.Rows[0]["What_Needs_To_Be_Done"].ToString();
                    if (!string.IsNullOrEmpty(dtOtherInfo.Rows[0]["To_Be_Completed_By"].ToString()))
                        txtCompletedBy.Text = clsGeneral.FormatDateToDisplay(Convert.ToDateTime(dtOtherInfo.Rows[0]["To_Be_Completed_By"]));
                    if (!string.IsNullOrEmpty(dtOtherInfo.Rows[0]["Completed_Date"].ToString()))
                        txtCompletionDate.Text = clsGeneral.FormatDateToDisplay(Convert.ToDateTime(dtOtherInfo.Rows[0]["Completed_Date"]));

                    hdnNextOpenQueID.Value = dtOtherInfo.Rows[0]["NextQueID"].ToString();

                    if (hdnNextOpenQueID.Value == "0")
                    {
                        btnSaveAndReturn.Visible = true;
                        btnSaveAndNext.Visible = false;
                    }
                    else
                    {
                        btnSaveAndReturn.Visible = false;
                        btnSaveAndNext.Visible = true;
                    }


                    if (!string.IsNullOrEmpty(dtOtherInfo.Rows[0]["PK_SLT_BT_Security_Walk_Responses"].ToString()))
                    {
                        DataSet dsDepartment = clsSLT_BT_Security_Walk_Responses_Department.SelectBy_FK_SLT_BT_Security_Walk_Responses(Convert.ToDecimal(dtOtherInfo.Rows[0]["PK_SLT_BT_Security_Walk_Responses"]));
                        if (dsDepartment.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow drDepartment in dsDepartment.Tables[0].Rows)
                            {
                                foreach (ListItem lstDepartmentName in lstDepartments.Items)
                                {
                                    if (lstDepartmentName.Value == drDepartment["FK_LU_SLT_BT_Security_Walk_Department"].ToString())
                                    {
                                        lstDepartmentName.Selected = true;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

    }
}