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
using System.Collections.Generic;
using System.Threading;
using RIMS_Base.Biz;
using ERIMS.DAL;
public partial class WorkerCompensation_MainDiary : clsBasePage
{
    #region Variable
    public RIMS_Base.Biz.CCheckWriting m_objClaimReservesInfo;
    List<RIMS_Base.CCheckWriting> lstClaimReservesInfo = null;
    int Pk_DiaryId = 0;
    public List<RIMS_Base.CDiary> lstDiary;
    public RIMS_Base.Biz.Diary objDiary;
    int Diary_RetVal = -1;
    public string strVal = "";
    RIMS_Base.Biz.CLiabilityClaim_FCI objLiability;
    List<RIMS_Base.CLiabilityClaim_FCI> lstLiability;

    string strSortExp = String.Empty;

    public RIMS_Base.Biz.CRolePermission m_objRightDetails;
    List<RIMS_Base.CRolePermission> lstRightDetails = null;
    #endregion

    #region "Property"

    /// <summary>
    /// int Active Index
    /// </summary>
    private int intActiveIndex
    {
        get { return Convert.ToInt32(ViewState["ActiveMenuIndex"]); }
        set { ViewState["ActiveMenuIndex"] = value; }
    }

    #endregion

    #region Event Handler

    /// <summary>
    /// Page Load Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        lblScript.Text = "";
        ExecutiveRiskInfo.SetSelectedTab(CtrlExecutiveRiskInfo.Tab.Diary);
        if (!IsPostBack)
        {
            Session.Remove("mode");
            Session.Remove("PK_Diary_ID");
            ViewState.Clear();

            btnDelete.Attributes.Add("onclick", "return OMSCheckSelected1('chkItem','gvDiaryDetails','Delete');");
            mvDiaryDetails.ActiveViewIndex = 0;
            gvDiaryDetails.PageSize = 10;
            intActiveIndex = 1;
            ddlPage.DataBind();
            ddlPage.SelectedValue = "10";
            lblPageInfo.Text = "Page 1 of " + gvDiaryDetails.PageCount.ToString();
            txtPageNo.Text = "1";

            if (Session["WorkerCompID"] != null && Session["WorkerCompID"].ToString() != String.Empty)
            {
                ViewState["TableFK"] = Session["WorkerCompID"];
                ViewState["TableName"] = "Executive_Risk";
                objLiability = new RIMS_Base.Biz.CLiabilityClaim_FCI();
                lstLiability = new List<RIMS_Base.CLiabilityClaim_FCI>();
                try
                {
                    lstLiability = objLiability.GetAL_ClaimByID(Convert.ToInt32(Session["WorkerCompID"].ToString()));
                    string Claim_No = lstLiability[0].Claim_Number;
                    DisplayEmployeeInfo(Claim_No);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    objLiability = null;
                    lstLiability = null;
                }

            }
            if (Session["ViewAll"] != null && Session["ViewAll"].ToString() != String.Empty)
                ViewAllFromSearchGrid();
        }
    }

    /// <summary>
    /// Page Prerender Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_PreRender(object sender, EventArgs e)
    {
        if (Session["ViewAll"] == null)
        {
            GeneralSorting();
        }
    }

    #region Employee Information

    /// <summary>
    /// Display Employee Info
    /// </summary>
    /// <param name="claimNO"></param>
    private void DisplayEmployeeInfo(string claimNO)
    {
        Executive_Risk objRisk = new Executive_Risk(Convert.ToDecimal(ViewState["TableFK"]));
        lblClaimNum.Text = objRisk.Claim_Number;
        lblDateIncident.Text = clsGeneral.FormatDateToDisplay(objRisk.Claim_Open_Date);

        // --- For the View Page
        lblClaimNo.Text = objRisk.Claim_Number;
        lblDOIncident.Text = clsGeneral.FormatDateToDisplay(objRisk.Claim_Open_Date);

        // ----  For the View All from the Main Seach Grid
        lblVClaimNo.Text = objRisk.Claim_Number;
        lblVDOInci.Text = clsGeneral.FormatDateToDisplay(objRisk.Claim_Open_Date);

    }
    #endregion

    #region InsertUpdateData

    /// <summary>
    /// Insert / Update Diary
    /// </summary>
    protected void InsertUpdateDiary()
    {
        objDiary = new RIMS_Base.Biz.Diary();
        try
        {
            if (ViewState["Pk_diary"] != null && ViewState["Pk_diary"].ToString() != "")
            {
                objDiary.PK_Diary_ID = Convert.ToInt32(ViewState["Pk_diary"].ToString());
                objDiary.Update_Date = DateTime.Now;
                if (Session["UserID"] != null)
                    objDiary.Updated_By = Session["UserID"].ToString();
            }
            objDiary.FK_Table_Name = Convert.ToDecimal(ViewState["TableFK"].ToString());
            objDiary.Table_Name = ViewState["TableName"].ToString();
            objDiary.Updated_By = clsSession.UserID;
            objDiary.Update_Date = DateTime.Now;
            if (Session["UserName"] != null)
                objDiary.UserDiary = Session["UserName"].ToString();
            // -- Need to discuss
            //objDiary.File_Number=

            if (fvDiaryDetails.CurrentMode == FormViewMode.Edit)
            {
                if (((TextBox)fvDiaryDetails.FindControl("txtDONoteEntry")).Text != "")
                {
                    objDiary.DateOfNoteEntry = Convert.ToDateTime(((TextBox)fvDiaryDetails.FindControl("txtDONoteEntry")).Text);
                }
                if (((TextBox)fvDiaryDetails.FindControl("txtDiaryDate")).Text != "")
                {
                    objDiary.Diary_Date = Convert.ToDateTime(((TextBox)fvDiaryDetails.FindControl("txtDiaryDate")).Text);
                }
                if (((TextBox)fvDiaryDetails.FindControl("txtNote")).Text != "")
                {
                    objDiary.Note = ((TextBox)fvDiaryDetails.FindControl("txtNote")).Text.Replace("'", "''").Trim();
                }
                if (((RadioButton)fvDiaryDetails.FindControl("rbClearYes")).Checked == true)
                {
                    objDiary.Clear = "Y";
                }
                if (((RadioButton)fvDiaryDetails.FindControl("rbClearNo")).Checked == true)
                {
                    objDiary.Clear = "N";
                }
                if (Request.Form[((TextBox)fvDiaryDetails.FindControl("txtAssignTo")).UniqueID].ToString() != "")
                {
                    objDiary.Assigned_To = Request.Form[((TextBox)fvDiaryDetails.FindControl("txtAssignTo")).UniqueID].ToString();
                }
                ViewState.Remove("Pk_diary");
            }
            if (fvDiaryDetails.CurrentMode == FormViewMode.Insert)
            {
                if (((TextBox)fvDiaryDetails.FindControl("txtIDONoteEntry")).Text != "")
                {
                    objDiary.DateOfNoteEntry = Convert.ToDateTime(((TextBox)fvDiaryDetails.FindControl("txtIDONoteEntry")).Text);
                }
                if (((TextBox)fvDiaryDetails.FindControl("txtIDiaryDate")).Text != "")
                {
                    objDiary.Diary_Date = Convert.ToDateTime(((TextBox)fvDiaryDetails.FindControl("txtIDiaryDate")).Text);
                }
                if (((TextBox)fvDiaryDetails.FindControl("txtINote")).Text != "")
                {
                    objDiary.Note = ((TextBox)fvDiaryDetails.FindControl("txtINote")).Text.Replace("'", "''").Trim();
                }
                if (((RadioButton)fvDiaryDetails.FindControl("rbIClearYes")).Checked == true)
                {
                    objDiary.Clear = "Y";
                }
                if (((RadioButton)fvDiaryDetails.FindControl("rbIClearNo")).Checked == true)
                {
                    objDiary.Clear = "N";
                }
                if (Request.Form[((TextBox)fvDiaryDetails.FindControl("txtIAssignTo")).UniqueID].ToString() != "")
                {
                    objDiary.Assigned_To = Request.Form[((TextBox)fvDiaryDetails.FindControl("txtIAssignTo")).UniqueID].ToString();
                }
            }

            int Pk_Diary = objDiary.InsertUpdateDiary(objDiary);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objDiary = null;
        }
    }

    #endregion

    /// <summary>
    /// Button Next Step Click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnNextStep_Click(object sender, EventArgs e)
    {
        if (intActiveIndex == 2)
            Response.Redirect("Adjuster.aspx", true);
        else
        {
            intActiveIndex = intActiveIndex + 1;
            if (intActiveIndex == 1) first_Click(null, null);
            if (intActiveIndex == 2) second_Click(null, null);
        }
    }

    #region Grid's All types of Events

    /// <summary>
    /// Button Save and View Click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSaveView_Click(object sender, EventArgs e)
    {
        divSearch.Style["display"] = "block";
        divfirst.Style["display"] = "none";
        divthird.Style["display"] = "block";
        divbtn.Style["display"] = "block";
        second.CssClass = "left_menu_active";
        first.CssClass = "left_menu";

        string AssignToID = String.Empty;
        if (fvDiaryDetails.CurrentMode == FormViewMode.Insert)
            AssignToID = ((TextBox)fvDiaryDetails.FindControl("txtIAssignToID")).Text;
        if (fvDiaryDetails.CurrentMode == FormViewMode.Edit)
            AssignToID = ((TextBox)fvDiaryDetails.FindControl("txtAssignToID")).Text;

        /********* MAIL PROCESS ********************/
        if (AssignToID != String.Empty)
        {
            System.Threading.Thread.Sleep(3000);

            RIMS_Base.Biz.CSecurity m_objSecurity = new RIMS_Base.Biz.CSecurity();
            List<RIMS_Base.CSecurity> lstSecurity = new List<RIMS_Base.CSecurity>();
            lstSecurity = m_objSecurity.GetSecurityByID(Convert.ToInt32(AssignToID));
            if (lstSecurity.Count > 0)
            {
                string AssignTO = "";

                if (lstSecurity[0].Email != string.Empty)
                {
                    clsGeneral.SendMailMessage(AppConfig.MailFrom, lstSecurity[0].Email, "", AppConfig.MailCC, "Diary Assigned :" + lblClaimNum.Text, "You have been assigned diary for claim number :" + lblClaimNum.Text, false);
                    //sendMail(ConfigurationManager.AppSettings["mailFrom"].ToString(), lstSecurity[0].Email, string.Empty, string.Empty, "Diary Assigned :" + lblClaimNum.Text, "You have been assigned diary for claim number :" + lblClaimNum.Text);
                }
            }
        }

        InsertUpdateDiary();
        BindDiaryDetails();
        mvDiaryDetails.ActiveViewIndex = 0;

    }

    /// <summary>
    /// Send Email
    /// </summary>
    /// <param name="from"></param>
    /// <param name="to"></param>
    /// <param name="cc"></param>
    /// <param name="bcc"></param>
    /// <param name="subject"></param>
    /// <param name="body"></param>
    /// <returns></returns>
    public static string sendMail(string from, string to, string cc, string bcc, string subject, string body)
    {
        if (!AppConfig.AllowMailSending)
            return "";
        // Mail initialization
        System.Web.Mail.MailMessage mailMsg = new System.Web.Mail.MailMessage();
        mailMsg.From = "Erims2<" + from + ">";
        mailMsg.To = to;
        mailMsg.Cc = cc;
        mailMsg.Bcc = bcc;
        mailMsg.Subject = subject;
        mailMsg.BodyFormat = System.Web.Mail.MailFormat.Html;
        mailMsg.Body = body;



        mailMsg.Priority = System.Web.Mail.MailPriority.Normal;
        // Smtp configuration
        System.Web.Mail.SmtpMail.SmtpServer = "smtp.gmail.com";
        // - smtp.gmail.com use smtp authentication
        mailMsg.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", "1");
        mailMsg.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusername", from);
        //Password for From mail account.
        //m_strSMTPpwd = DecryptPassword(System.Configuration.ConfigurationManager.AppSettings["SMTPPwd"]);
        mailMsg.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendpassword", System.Configuration.ConfigurationManager.AppSettings["SMTPPwd"]);
        // - smtp.gmail.com use port 465 or 587 ifmisBugs@astegic.com/ifmisbugs
        mailMsg.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpserverport", "465");
        // - smtp.gmail.com use STARTTLS (some call this SSL)
        mailMsg.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpusessl", "true");
        // try to send Mail
        try
        {
            System.Web.Mail.SmtpMail.Send(mailMsg);
            return "";
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }

    /// <summary>
    /// Button Cancle click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        divSearch.Style["display"] = "block";
        divfirst.Style["display"] = "none";
        divthird.Style["display"] = "block";
        divbtn.Style["display"] = "block";
        second.CssClass = "left_menu_active";
        first.CssClass = "left_menu";
        mvDiaryDetails.ActiveViewIndex = 0;
    }

    /// <summary>
    /// Grid View Diary Row Command
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvDiaryDetails_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName != "Sort")
            {
                divSearch.Style["display"] = "none";
                mvDiaryDetails.ActiveViewIndex = 1;
                Pk_DiaryId = Convert.ToInt32(e.CommandArgument.ToString());
                ViewState["Pk_diary"] = Pk_DiaryId;
                Session["PK_Diary_ID"] = Pk_DiaryId;
                Button btn = (Button)fvDiaryDetails.Parent.FindControl("btnViewAudit");
            }
            if (e.CommandName == "EditItem")
            {
                divSearch.Style["display"] = "none";
                divfirst.Style["display"] = "none";
                divthird.Style["display"] = "block";
                divbtn.Style["display"] = "none";

                Bindfv(FormViewMode.Edit);
                ((Button)fvDiaryDetails.FindControl("btnAssignTO")).Attributes.Add("onClick", "return openPopUp('" + ((TextBox)fvDiaryDetails.FindControl("txtAssignTo")).ID + "','" + ((TextBox)fvDiaryDetails.FindControl("txtAssignToID")).ID + "');");
                ((Button)fvDiaryDetails.FindControl("btnViewAudit")).Attributes.Add("onClick", "return AuditPopUp(" + ViewState["Pk_diary"] + ")");

                Session["mode"] = "edit";
                SetValidationsEdit();
            }
            else if (e.CommandName == "View")
            {
                divSearch.Style["display"] = "none";
                divfirst.Style["display"] = "none";
                divthird.Style["display"] = "block";
                divbtn.Style["display"] = "none";
                Bindfv(FormViewMode.ReadOnly);
                ((Button)fvDiaryDetails.FindControl("btnViewAudit")).Attributes.Add("onClick", "return AuditPopUp(" + ViewState["Pk_diary"] + ")");
            }
            second.CssClass = "left_menu_active";
            first.CssClass = "left_menu";
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /// <summary>
    /// Bind View
    /// </summary>
    /// <param name="fvMode"></param>
    private void Bindfv(FormViewMode fvMode)
    {
        try
        {
            if (fvMode == FormViewMode.Insert)
                fvDiaryDetails.ChangeMode(FormViewMode.Insert);
            else if (fvMode == FormViewMode.Edit)
                fvDiaryDetails.ChangeMode(FormViewMode.Edit);
            else if (fvMode == FormViewMode.ReadOnly)
                fvDiaryDetails.ChangeMode(FormViewMode.ReadOnly);
            //fvDiaryDetails.DataBind();

            if (fvMode != FormViewMode.Insert)
            {
                objDiary = new RIMS_Base.Biz.Diary();
                lstDiary = new List<RIMS_Base.CDiary>();
                lstDiary = objDiary.GetyByID(Pk_DiaryId);
                fvDiaryDetails.DataSource = lstDiary;
            }
            fvDiaryDetails.DataBind();
            //string m_str;
            //m_str=((TextBox)fvDiaryDetails.FindControl("txtAssignTo")).ClientID;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
        }
    }

    /// <summary>
    /// Form View Data Row Biund Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void fvDiaryDetails_DataBound(object sender, EventArgs e)
    {
        try
        {
            // -- Display Dynamic Labels
            DataSet dstDiary = new DataSet();
            objDiary = new RIMS_Base.Biz.Diary();
            try
            {
                dstDiary = objDiary.GetDiaryLabel();
                for (int i = 0; i < dstDiary.Tables[0].Rows.Count; i++)
                {
                    if (fvDiaryDetails.CurrentMode == FormViewMode.Edit || fvDiaryDetails.CurrentMode == FormViewMode.Insert)
                    {
                        if (dstDiary.Tables[0].Rows[i]["Control_Type"].ToString() == "Label" && dstDiary.Tables[0].Rows[i]["Control_Name"].ToString() == "gvDiaryDetails_Insert_Edit")
                        {
                            if (dstDiary.Tables[0].Rows[i]["Caption"].ToString() != String.Empty)
                                ((Label)fvDiaryDetails.FindControl(dstDiary.Tables[0].Rows[i]["Label_Name"].ToString())).Text = dstDiary.Tables[0].Rows[i]["Caption"].ToString();
                        }
                    }
                    if (fvDiaryDetails.CurrentMode == FormViewMode.ReadOnly)
                    {
                        if (dstDiary.Tables[0].Rows[i]["Control_Type"].ToString() == "Label" && dstDiary.Tables[0].Rows[i]["Control_Name"].ToString() == "gvDiaryDetails_View")
                        {
                            if (dstDiary.Tables[0].Rows[i]["Caption"].ToString() != String.Empty)
                                ((Label)fvDiaryDetails.FindControl(dstDiary.Tables[0].Rows[i]["Label_Name"].ToString())).Text = dstDiary.Tables[0].Rows[i]["Caption"].ToString();
                        }
                    }

                }
            }
            catch (Exception Ex)
            {
                // throw;
            }

            if (fvDiaryDetails.CurrentMode == FormViewMode.Edit)
            {
                if (lstDiary[0].DateOfNoteEntry != null)
                    ((TextBox)fvDiaryDetails.FindControl("txtDONoteEntry")).Text = Convert.ToDateTime(lstDiary[0].DateOfNoteEntry).ToShortDateString();
                ((TextBox)fvDiaryDetails.FindControl("txtDiaryDate")).Text = Convert.ToDateTime(lstDiary[0].Diary_Date).ToShortDateString();
                ((TextBox)fvDiaryDetails.FindControl("txtNote")).Text = lstDiary[0].Note;
                if (lstDiary[0].Clear == "Y")
                {
                    ((RadioButton)fvDiaryDetails.FindControl("rbClearYes")).Checked = true;
                    ((RadioButton)fvDiaryDetails.FindControl("rbClearNo")).Checked = false;
                }
                if (lstDiary[0].Clear == "N")
                {
                    ((RadioButton)fvDiaryDetails.FindControl("rbClearYes")).Checked = false;
                    ((RadioButton)fvDiaryDetails.FindControl("rbClearNo")).Checked = true;
                }
                ((TextBox)fvDiaryDetails.FindControl("txtAssignTo")).Text = lstDiary[0].Assigned_To;
            }
            if (fvDiaryDetails.CurrentMode == FormViewMode.ReadOnly)
            {
                if (lstDiary[0].DateOfNoteEntry != null)
                    ((Label)fvDiaryDetails.FindControl("lblDONoteEntry")).Text = Convert.ToDateTime(lstDiary[0].DateOfNoteEntry).ToShortDateString();
                ((Label)fvDiaryDetails.FindControl("lblDiaryDate")).Text = Convert.ToDateTime(lstDiary[0].Diary_Date).ToShortDateString();
                ((Label)fvDiaryDetails.FindControl("lblNote")).Text = lstDiary[0].Note;
                if (lstDiary[0].Clear == "Y")
                    ((Label)fvDiaryDetails.FindControl("lblClear")).Text = "Yes";
                if (lstDiary[0].Clear == "N")
                    ((Label)fvDiaryDetails.FindControl("lblClear")).Text = "No";
                ((Label)fvDiaryDetails.FindControl("lblAssignTo")).Text = lstDiary[0].Assigned_To;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            lstDiary = null;
        }

    }
    /// <summary>
    /// Bind Diary Detail Grid
    /// </summary>
    private void BindDiaryDetails()
    {
        try
        {
            objDiary = new RIMS_Base.Biz.Diary();
            lstDiary = new List<RIMS_Base.CDiary>();
            if (txtSearch.Text != string.Empty)
            {
                lstDiary = objDiary.Search_DiaryData(ddlSearch.SelectedValue, txtSearch.Text.Trim().Replace("'", "''"), Convert.ToDecimal(ViewState["TableFK"].ToString()), ViewState["TableName"].ToString());
            }
            else
            {
                if (ViewState["TableFK"] != null && ViewState["TableFK"].ToString() != String.Empty)
                    lstDiary = objDiary.Search_DiaryData(null, null, Convert.ToDecimal(ViewState["TableFK"].ToString()), ViewState["TableName"].ToString());
            }
            gvDiaryDetails.DataSource = lstDiary;
            gvDiaryDetails.DataBind();
            //lblPageInfo.Text = "Page 1 of " + gvDiaryDetails.PageCount.ToString();
            if (lstDiary.Count <= 0)
                btnDelete.Visible = false;
            else
                btnDelete.Visible = true;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            //lstDiary = null;
        }
    }

    /// <summary>
    /// Grid view Page Index Change
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvDiaryDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }

    /// <summary>
    /// Datagrid sorting Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvDiaryDetails_Sorting(object sender, GridViewSortEventArgs e)
    {
        lstDiary = new List<RIMS_Base.CDiary>();
        objDiary = new RIMS_Base.Biz.Diary();

        if (ViewState["sortDirection"] == null)
            ViewState["sortDirection"] = SortDirection.Ascending;
        // Changes the sort direction 
        else
        {
            if (((SortDirection)ViewState["sortDirection"]) == SortDirection.Ascending)
                ViewState["sortDirection"] = SortDirection.Descending;
            else
                ViewState["sortDirection"] = SortDirection.Ascending;
        }
        ViewState["SortExp"] = strSortExp = e.SortExpression;

        lstDiary = objDiary.Search_DiaryData(null, null, Convert.ToDecimal(ViewState["TableFK"].ToString()), ViewState["TableName"].ToString());

        if (ViewState["SortExp"] != null)
            lstDiary.Sort(new RIMS_Base.GenericComparer<RIMS_Base.CDiary>((string)ViewState["SortExp"], (SortDirection)ViewState["sortDirection"]));
        gvDiaryDetails.DataSource = lstDiary;
        gvDiaryDetails.DataBind();

        divSearch.Style["display"] = "block";
        divfirst.Style["display"] = "none";
        divthird.Style["display"] = "block";
        divbtn.Style["display"] = "block";
        second.CssClass = "left_menu_active";
        first.CssClass = "left_menu";
    }

    /// <summary>
    /// Data Grid Row Created Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvDiaryDetails_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            if (String.Empty != strSortExp)
            {
                AddSortImage(e.Row);
            }
        }
    }

    /// <summary>
    /// Get sorted column
    /// </summary>
    /// <param name="strSortExp"></param>
    /// <returns></returns>
    private int GetSortColumnIndex(string strSortExp)
    {
        int nRet = 0;
        // Iterate through the Columns collection to determine the index
        // of the column being sorted.
        foreach (DataControlField field in gvDiaryDetails.Columns)
        {
            if (field.SortExpression.ToString() == ViewState["SortExp"].ToString())
            {
                nRet = gvDiaryDetails.Columns.IndexOf(field);
            }
        }
        return nRet;
    }

    /// <summary>
    /// Addd image to soted Column
    /// </summary>
    /// <param name="headerRow"></param>
    private void AddSortImage(GridViewRow headerRow)
    {

        Int32 iCol = GetSortColumnIndex(strSortExp);
        if (-1 == iCol)
        {
            return;
        }
        // Create the sorting image based on the sort direction.
        Image sortImage = new Image();

        if (SortDirection.Ascending.ToString() == ViewState["sortDirection"].ToString())
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

    /// <summary>
    /// DataGrid Row Bound Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvDiaryDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (ViewState["Edit"] != null && ViewState["Edit"].ToString() != string.Empty)
            {
                if (ViewState["Edit"].ToString() == "True")
                    ((Button)e.Row.FindControl("btnEdit")).Enabled = true;
                else
                {
                    ((Button)e.Row.FindControl("btnEdit")).Enabled = false;
                    ((Button)e.Row.FindControl("btnEdit")).ToolTip = "You have no rights";
                }
            }
            if (ViewState["View"] != null && ViewState["View"].ToString() != string.Empty)
            {
                if (ViewState["View"].ToString() == "True")
                    ((Button)e.Row.FindControl("btnView")).Enabled = true;
                else
                {
                    ((Button)e.Row.FindControl("btnView")).Enabled = false;
                    ((Button)e.Row.FindControl("btnView")).ToolTip = "You have no rights";
                }
            }
        }
        // -- Display Dynamic Labels
        if (e.Row.RowType == DataControlRowType.Header)
        {
            try
            {
                DataSet dstDiary = new DataSet();
                objDiary = new RIMS_Base.Biz.Diary();
                dstDiary = objDiary.GetDiaryLabel();
                for (int i = 0; i < dstDiary.Tables[0].Rows.Count; i++)
                {
                    if (dstDiary.Tables[0].Rows[i]["Control_Type"].ToString() == "GridView" && dstDiary.Tables[0].Rows[i]["Control_Name"].ToString() == "gvDiaryDetails")
                    {
                        int columnNO = Convert.ToInt32(dstDiary.Tables[0].Rows[i]["Label_Name"].ToString());
                        if (dstDiary.Tables[0].Rows[i]["Caption"].ToString() != String.Empty)
                        {
                            gvDiaryDetails.Columns[columnNO].HeaderText = dstDiary.Tables[0].Rows[i]["Caption"].ToString();
                        }

                    }
                }

            }
            catch (Exception ex)
            {
                //throw ex;
            }
        }
    }
    #endregion

    #region Search Facility

    /// <summary>
    /// Button Serch Click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            BindDiaryDetails();
            lblPageInfo.Text = "Page 1 of " + gvDiaryDetails.PageCount.ToString();
            divfirst.Style["display"] = "none";
            divSearch.Style["display"] = "block";
            divthird.Style["display"] = "block";
            divbtn.Style["display"] = "block";
            second.CssClass = "left_menu_active";
            first.CssClass = "left_menu";
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /// <summary>
    /// Button Delete Click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            objDiary = new RIMS_Base.Biz.Diary();
            Diary_RetVal = objDiary.DeleteDiary(Request.Form["chkItem"].ToString());
            if (Diary_RetVal <= 0)
            {
                mvDiaryDetails.ActiveViewIndex = 0;
                BindDiaryDetails();
                divfirst.Style["display"] = "none";
                divSearch.Style["display"] = "block";
                divthird.Style["display"] = "block";
                divbtn.Style["display"] = "block";
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }

    /// <summary>
    /// Button Add new Click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnAddNew_Click(object sender, EventArgs e)
    {
        try
        {
            ViewState.Remove("Pk_diary");
            divSearch.Style["display"] = "none";
            divfirst.Style["display"] = "none";
            divthird.Style["display"] = "block";
            divbtn.Style["display"] = "none";

            mvDiaryDetails.ActiveViewIndex = 1;

            Bindfv(FormViewMode.Insert);
            ((Button)fvDiaryDetails.FindControl("btnIAssignTO")).Attributes.Add("onClick", "return openPopUp('" + ((TextBox)fvDiaryDetails.FindControl("txtIAssignTo")).ID + "','" + ((TextBox)fvDiaryDetails.FindControl("txtIAssignToID")).ID + "');");
            Session["mode"] = "insert";

            second.CssClass = "left_menu_active";
            first.CssClass = "left_menu";
            //((Button)fvBankDetails.FindControl("btnSave")).Attributes.Add("onclick", "return Test();");

            SetValidationsInsert();
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }

    /// <summary>
    /// Button Go Click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnGo_Click(object sender, EventArgs e)
    {
        try
        {

            if (txtPageNo.Text.ToString().Trim() == string.Empty || Convert.ToInt32(txtPageNo.Text) < 1)
            {
                gvDiaryDetails.PageIndex = 0;
                txtPageNo.Text = "1";
            }
            else if (Convert.ToInt32(txtPageNo.Text) > gvDiaryDetails.PageCount)
            {
                gvDiaryDetails.PageIndex = gvDiaryDetails.PageCount;
                txtPageNo.Text = gvDiaryDetails.PageCount.ToString();
            }
            else
            {
                gvDiaryDetails.PageIndex = Convert.ToInt32(txtPageNo.Text) - 1;
            }
            lblPageInfo.Text = "Page " + txtPageNo.Text.ToString() + " of " + gvDiaryDetails.PageCount.ToString();
            BindDiaryDetails();

            divfirst.Style["display"] = "none";
            divSearch.Style["display"] = "block";
            divthird.Style["display"] = "block";
            divbtn.Style["display"] = "block";
            first.CssClass = "left_menu";
            second.CssClass = "left_menu_active";
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }

    /// <summary>
    /// Button Next Click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnNext_Click(object sender, EventArgs e)
    {
        try
        {
            if (gvDiaryDetails.PageIndex <= gvDiaryDetails.PageCount)
            {
                gvDiaryDetails.PageIndex = gvDiaryDetails.PageIndex + 1;
                GeneralSorting();
                //BindDiaryDetails();
                lblPageInfo.Text = "Page " + Convert.ToString(gvDiaryDetails.PageIndex + 1) + " of " + gvDiaryDetails.PageCount.ToString();

            }

            divSearch.Style["display"] = "block";
            divfirst.Style["display"] = "none";
            divthird.Style["display"] = "block";
            divbtn.Style["display"] = "block";
            second.CssClass = "left_menu_active";
            first.CssClass = "left_menu";
        }
        catch (Exception ex)
        {
        }
    }

    /// <summary>
    /// ropdown page selected Index Change
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ddlPage_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            gvDiaryDetails.PageSize = Convert.ToInt32(ddlPage.SelectedValue);
            BindDiaryDetails();
            lblPageInfo.Text = "Page 1 of " + gvDiaryDetails.PageCount.ToString();
            txtPageNo.Text = "1";

            divSearch.Style["display"] = "block";
            divfirst.Style["display"] = "none";
            divthird.Style["display"] = "block";
            divbtn.Style["display"] = "block";
            second.CssClass = "left_menu_active";
            first.CssClass = "left_menu";
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /// <summary>
    /// Button Prev Click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnPrev_Click(object sender, EventArgs e)
    {
        try
        {
            if (gvDiaryDetails.PageIndex <= gvDiaryDetails.PageCount)
            {
                if (gvDiaryDetails.PageIndex != 0)
                {
                    gvDiaryDetails.PageIndex = gvDiaryDetails.PageIndex - 1;
                    GeneralSorting();
                    //BindDiaryDetails();
                    lblPageInfo.Text = "Page " + Convert.ToString(gvDiaryDetails.PageIndex + 1) + " of " + gvDiaryDetails.PageCount.ToString();
                }
            }

            divSearch.Style["display"] = "block";
            divfirst.Style["display"] = "none";
            divthird.Style["display"] = "block";
            divbtn.Style["display"] = "block";
            second.CssClass = "left_menu_active";
            first.CssClass = "left_menu";
        }
        catch (Exception ex)
        {
        }
    }

    #endregion

    /// <summary>
    /// Second Click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void second_Click(object sender, EventArgs e)
    {
        intActiveIndex = 2;
        second.CssClass = "left_menu_active";
        first.CssClass = "left_menu";
        mvDiaryDetails.ActiveViewIndex = 0;

        divfirst.Style["display"] = "none";
        divSearch.Style["display"] = "block";
        divbtn.Style["display"] = "block";
        divthird.Style["display"] = "block";

    }

    /// <summary>
    /// Second Click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void first_Click(object sender, EventArgs e)
    {
        intActiveIndex = 1;
        second.CssClass = "left_menu";
        first.CssClass = "left_menu_active";
        mvDiaryDetails.ActiveViewIndex = 0;

        divfirst.Style["display"] = "block";
        divSearch.Style["display"] = "none";
        divbtn.Style["display"] = "block";
        divthird.Style["display"] = "none";

    }

    /// <summary>
    /// General Sorting Method
    /// </summary>
    private void GeneralSorting()
    {
        try
        {
            lstDiary = new List<RIMS_Base.CDiary>();
            BindDiaryDetails();
            if (ViewState["SortExp"] != null && ViewState["sortDirection"] != null)
            {
                lstDiary.Sort(new RIMS_Base.GenericComparer<RIMS_Base.CDiary>((string)ViewState["SortExp"], (SortDirection)ViewState["sortDirection"]));
                strSortExp = ViewState["SortExp"].ToString();
            }
            gvDiaryDetails.DataSource = lstDiary;
            gvDiaryDetails.DataBind();
            lblPageInfo.Text = "Page " + Convert.ToString(gvDiaryDetails.PageIndex + 1) + " of " + gvDiaryDetails.PageCount.ToString();
        }
        catch (Exception ex)
        {
            throw ex;
        }


    }

    #region ViewAll Functionality From Main Seaarch Grid

    /// <summary>
    /// View All From Search Grid
    /// </summary>
    private void ViewAllFromSearchGrid()
    {
        divbtn.Style["display"] = "none";
        leftDiv.Style["display"] = "none";
        mainContent.Style["display"] = "none";
        divView.Style["display"] = "block";
        txtSearch.Text = "";
        try
        {
            objDiary = new RIMS_Base.Biz.Diary();
            lstDiary = new List<RIMS_Base.CDiary>();
            if (txtSearch.Text != string.Empty)
            {
                lstDiary = objDiary.Search_DiaryData(ddlSearch.SelectedValue, txtSearch.Text.Trim(), Convert.ToDecimal(ViewState["TableFK"].ToString()), ViewState["TableName"].ToString());
            }
            else
            {
                if (ViewState["TableFK"] != null && ViewState["TableFK"].ToString() != String.Empty)
                    lstDiary = objDiary.Search_DiaryData(null, null, Convert.ToDecimal(ViewState["TableFK"].ToString()), ViewState["TableName"].ToString());
            }
            gvViewAll.DataSource = lstDiary;
            gvViewAll.DataBind();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /// <summary>
    /// Gridview View All Row Data Bound
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvViewAll_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (((Label)e.Row.FindControl("lblVNoteType")).Text == "Y")
                ((Label)e.Row.FindControl("lblVNoteType")).Text = "Yes";
            else if (((Label)e.Row.FindControl("lblVNoteType")).Text == "N")
                ((Label)e.Row.FindControl("lblVNoteType")).Text = "No";

            // -- Display Dynamic Labels
            try
            {
                DataSet dstDiary = new DataSet();
                objDiary = new RIMS_Base.Biz.Diary();
                dstDiary = objDiary.GetDiaryLabel();
                for (int i = 0; i < dstDiary.Tables[0].Rows.Count; i++)
                {
                    if (dstDiary.Tables[0].Rows[i]["Control_Type"].ToString() == "Label" && dstDiary.Tables[0].Rows[i]["ViewAll_Label_Name"].ToString() != String.Empty)
                    {
                        if (dstDiary.Tables[0].Rows[i]["Caption"].ToString() != String.Empty)
                            ((Label)e.Row.FindControl(dstDiary.Tables[0].Rows[i]["ViewAll_Label_Name"].ToString())).Text = dstDiary.Tables[0].Rows[i]["Caption"].ToString();

                    }
                }

            }
            catch (Exception ex)
            {
                //throw ex;
            }
        }
    }

    /// <summary>
    /// Button View Next Click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnViewNext_Click(object sender, EventArgs e)
    {
        Response.Redirect("Adjuster.aspx");
    }

    #endregion

    #region User Rights

    /// <summary>
    /// Set user rights
    /// </summary>
    /// <returns></returns>
    protected bool SetUserRights()
    {
        try
        {
            m_objRightDetails = new CRolePermission();
            if (Session["UserRoleId"] != null)
            {
                if (Session["ClaimType"] != null && Session["ClaimType"].ToString() != string.Empty)
                {
                    if (Session["ClaimType"].ToString() == "Automobile")
                        lstRightDetails = m_objRightDetails.GetRights(2, Convert.ToInt32(Session["UserRoleId"].ToString()));
                    if (Session["ClaimType"].ToString() == "General")
                        lstRightDetails = m_objRightDetails.GetRights(3, Convert.ToInt32(Session["UserRoleId"].ToString()));
                    if (Session["ClaimType"].ToString() == "PropertyLoss")
                        lstRightDetails = m_objRightDetails.GetRights(4, Convert.ToInt32(Session["UserRoleId"].ToString()));

                    ViewState["Add"] = lstRightDetails[0].PAdd.ToString();
                    ViewState["Edit"] = lstRightDetails[0].PEdit.ToString();
                    ViewState["Delete"] = lstRightDetails[0].PDelete.ToString();
                    ViewState["View"] = lstRightDetails[0].PView.ToString();
                    if (ViewState["Add"].ToString() == "True")
                    {
                        btnAddNew.Enabled = true;
                    }
                    else
                    {
                        btnAddNew.Enabled = false;
                        btnAddNew.ToolTip = "You have no rights";
                    }
                    if (ViewState["Delete"].ToString() == "True")
                    {
                        btnDelete.Enabled = true;
                    }
                    else
                    {
                        btnDelete.Enabled = false;
                        btnDelete.ToolTip = "You have no rights";
                    }
                    return true;
                }
                else
                {
                    return false;
                }

            }
            else
            {
                Response.Redirect("../Signin.aspx", false);
                return false;
            }

        }
        catch (Exception ex)
        {
            throw;
        }

    }

    #endregion

    #endregion

    #region Dynamic Validations

    /// <summary>
    /// Set all Validations-Insert
    /// </summary>
    private void SetValidationsInsert()
    {
        string strCtrlsIDs = "";
        string strMessages = "";

        #region ""
        DataTable dtFields = clsScreen_Validators.SelectByScreen(142).Tables[0];
        dtFields.DefaultView.RowFilter = "IsRequired = '1'";
        dtFields = dtFields.DefaultView.ToTable();

        MenuAsterisk2.Visible = (dtFields.Select("LeftMenuIndex = 2").Length > 0) ? true : false;

        foreach (DataRow drField in dtFields.Rows)
        {
            #region " set validation control IDs and messages "
            switch (Convert.ToString(drField["Field_Name"]))
            {
                case "Date of Note Entry": strCtrlsIDs += ((TextBox)fvDiaryDetails.FindControl("txtIDONoteEntry")).ClientID + ","; strMessages += "Please enter Date of Note Entry" + ","; ((HtmlGenericControl)fvDiaryDetails.FindControl("Span5")).Style["display"] = "inline-block"; break;
                case "Diary Date": strCtrlsIDs += ((TextBox)fvDiaryDetails.FindControl("txtIDiaryDate")).ClientID + ","; strMessages += "Please enter Diary Date" + ","; ((HtmlGenericControl)fvDiaryDetails.FindControl("Span6")).Style["display"] = "inline-block"; break;
                case "Note": strCtrlsIDs += ((TextBox)fvDiaryDetails.FindControl("txtINote")).ClientID + ","; strMessages += "Please enter Note" + ","; ((HtmlGenericControl)fvDiaryDetails.FindControl("Span7")).Style["display"] = "inline-block"; break;
                case "Assigned To": strCtrlsIDs += ((TextBox)fvDiaryDetails.FindControl("txtIAssignTo")).ClientID + ","; strMessages += "Please enter Assigned To" + ","; ((HtmlGenericControl)fvDiaryDetails.FindControl("Span8")).Style["display"] = "inline-block"; break;
            }
            #endregion
        }
        #endregion

        strCtrlsIDs = strCtrlsIDs.TrimEnd(',');
        strMessages = strMessages.TrimEnd(',');

        ((HtmlInputHidden)fvDiaryDetails.FindControl("hdnControlIDsInsert")).Value = strCtrlsIDs;
        ((HtmlInputHidden)fvDiaryDetails.FindControl("hdnErrorMsgsInsert")).Value = strMessages;        
    }

    /// <summary>
    /// Set all Validations-Insert
    /// </summary>
    private void SetValidationsEdit()
    {
        string strCtrlsIDs = "";
        string strMessages = "";

        #region ""
        DataTable dtFields = clsScreen_Validators.SelectByScreen(142).Tables[0];
        dtFields.DefaultView.RowFilter = "IsRequired = '1'";
        dtFields = dtFields.DefaultView.ToTable();

        MenuAsterisk2.Visible = (dtFields.Select("LeftMenuIndex = 2").Length > 0) ? true : false;

        foreach (DataRow drField in dtFields.Rows)
        {
            #region " set validation control IDs and messages "
            switch (Convert.ToString(drField["Field_Name"]))
            {
                case "Date of Note Entry": strCtrlsIDs += ((TextBox)fvDiaryDetails.FindControl("txtDONoteEntry")).ClientID + ","; strMessages += "Please enter Date of Note Entry" + ","; ((HtmlGenericControl)fvDiaryDetails.FindControl("Span1")).Style["display"] = "inline-block"; break;
                case "Diary Date": strCtrlsIDs += ((TextBox)fvDiaryDetails.FindControl("txtDiaryDate")).ClientID + ","; strMessages += "Please enter Diary Date" + ","; ((HtmlGenericControl)fvDiaryDetails.FindControl("Span2")).Style["display"] = "inline-block"; break;
                case "Note": strCtrlsIDs += ((TextBox)fvDiaryDetails.FindControl("txtNote")).ClientID + ","; strMessages += "Please enter Note" + ","; ((HtmlGenericControl)fvDiaryDetails.FindControl("Span3")).Style["display"] = "inline-block"; break;
                case "Assigned To": strCtrlsIDs += ((TextBox)fvDiaryDetails.FindControl("txtAssignTo")).ClientID + ","; strMessages += "Please enter Assigned To" + ","; ((HtmlGenericControl)fvDiaryDetails.FindControl("Span4")).Style["display"] = "inline-block"; break;
            }
            #endregion
        }
        #endregion

        strCtrlsIDs = strCtrlsIDs.TrimEnd(',');
        strMessages = strMessages.TrimEnd(',');

        ((HtmlInputHidden)fvDiaryDetails.FindControl("hdnControlIDsEdit")).Value = strCtrlsIDs;
        ((HtmlInputHidden)fvDiaryDetails.FindControl("hdnErrorMsgsEdit")).Value = strMessages;                
    }

    #endregion
}
