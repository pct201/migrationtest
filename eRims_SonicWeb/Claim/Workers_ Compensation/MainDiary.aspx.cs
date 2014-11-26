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

public partial class WorkerCompensation_MainDiary : System.Web.UI.Page
{
    #region Variable
    public RIMS_Base.Biz.CCheckWriting m_objClaimReservesInfo;
    List<RIMS_Base.CCheckWriting> lstClaimReservesInfo = null;
    int Pk_DiaryId = 0;
    public List<RIMS_Base.CDiary> lstDiary;
    public RIMS_Base.Biz.Diary objDiary;
    int Diary_RetVal = -1;
    public string strVal="";

    string strSortExp = String.Empty;

    public RIMS_Base.Biz.CRolePermission m_objRightDetails;
    List<RIMS_Base.CRolePermission> lstRightDetails = null;
    #endregion

    #region Event Handler
    
    protected void Page_Load(object sender, EventArgs e)
    {
            lblScript.Text = "";
            if (!IsPostBack)
            {
                Session.Remove("mode");
                ViewState.Clear();
                if (SetUserRights() == true)
                {
                    btnDelete.Attributes.Add("onclick", "return OMSCheckSelected1('chkItem','gvDiaryDetails','Delete');");
                    mvDiaryDetails.ActiveViewIndex = 0;
                    gvDiaryDetails.PageSize = 10;

                    ddlPage.DataBind();
                    ddlPage.SelectedValue = "10";
                    lblPageInfo.Text = "Page 1 of " + gvDiaryDetails.PageCount.ToString();
                    txtPageNo.Text = "1";

                    //Session["WorkerCompID"] = 1;

                    if (Session["WorkerCompID"] != null && Session["WorkerCompID"].ToString() != String.Empty)
                    {
                        RIMS_Base.Biz.cWorkerComp objWorkerComp = new RIMS_Base.Biz.cWorkerComp();
                        List<RIMS_Base.cWorkerComp> lstWorkerComp = new List<RIMS_Base.cWorkerComp>();
                        try
                        {
                            lstWorkerComp = objWorkerComp.GetWorkerCompByID(Convert.ToInt32(Session["WorkerCompID"].ToString()));
                            string Claim_No = lstWorkerComp[0].Claim_Number;
                            DisplayEmployeeInfo(Claim_No);
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                        finally
                        {
                            objWorkerComp = null;
                            lstWorkerComp = null;
                        }
                    }                    
                    if (Session["ViewAll"] != null && Session["ViewAll"].ToString() != String.Empty)
                        ViewAllFromSearchGrid();
                    // --- Commente Due to PAGE PRE RENDER.
                    //else
                    //    BindDiaryDetails();
                }

            }        
    }

    protected void Page_PreRender(object sender, EventArgs e)
    {
        if (Session["ViewAll"] == null)
        {
            GeneralSorting();
        }
    }

    #region Employee Information
    private void DisplayEmployeeInfo(string claimNO)
    {
        m_objClaimReservesInfo = new RIMS_Base.Biz.CCheckWriting();
        lstClaimReservesInfo = new List<RIMS_Base.CCheckWriting>();
        lstClaimReservesInfo = m_objClaimReservesInfo.GetClaimInfoByClaimNo(claimNO);
        lblClaimNum.Text = lstClaimReservesInfo[0].Claim_Number.ToString();
        ViewState["TableName"] = lstClaimReservesInfo[0].TableName.ToString();
        ViewState["TableFK"] = lstClaimReservesInfo[0].TableFK.ToString();
        if (lstClaimReservesInfo[0].Employee.ToUpper() == "Y")
            rbtnEmployee.Items[0].Selected = true;
        else if (lstClaimReservesInfo[0].Employee.ToUpper() == "N")
            rbtnEmployee.Items[1].Selected = true;
        lblLName.Text = lstClaimReservesInfo[0].LastName.ToString();
        lblFName.Text = lstClaimReservesInfo[0].FirstName.ToString();
        lblMName.Text = lstClaimReservesInfo[0].MiddleName.ToString();
        lblDateIncident.Text = lstClaimReservesInfo[0].IncidentDate.ToString();

       // --- For the View Page

        if (lstClaimReservesInfo[0].Employee.ToUpper() == "Y")
            lblEmployee.Text = "Yes";
        else if (lstClaimReservesInfo[0].Employee.ToUpper() == "N")
            lblEmployee.Text = "No";
        lblLastName.Text = lstClaimReservesInfo[0].LastName.ToString();
        lblFirstName.Text = lstClaimReservesInfo[0].FirstName.ToString();
        lblMiddleName.Text = lstClaimReservesInfo[0].MiddleName.ToString();
        lblDOIncident.Text = lstClaimReservesInfo[0].IncidentDate.ToString();
        lblClaimNo.Text = lstClaimReservesInfo[0].Claim_Number.ToString();

        // ----  For the View All from the Main Seach Grid
        if (lstClaimReservesInfo[0].Employee.ToUpper() == "Y")
            lblVEmployee.Text = "Yes";
        else if (lstClaimReservesInfo[0].Employee.ToUpper() == "N")
            lblVEmployee.Text = "No";
        lblVLastName.Text = lstClaimReservesInfo[0].LastName.ToString();
        lblVFirstName.Text = lstClaimReservesInfo[0].FirstName.ToString();
        lblVMiddleMName.Text = lstClaimReservesInfo[0].MiddleName.ToString();
        lblVDOInci.Text = lstClaimReservesInfo[0].IncidentDate.ToString();
        lblVClaimNo.Text = lstClaimReservesInfo[0].Claim_Number.ToString();
    }
    #endregion

    #region InsertUpdateData
    
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

    protected void btnNextStep_Click(object sender, EventArgs e)
    {
        Response.Redirect("MainAdjuster.aspx",true);
    }

    #region Grid's All types of Events

    protected void btnSaveView_Click(object sender, EventArgs e)
    {       
        divSearch.Style["display"] = "block";
        divfirst.Style["display"] = "none";
        divthird.Style["display"] = "block";
        divbtn.Style["display"] = "block";
        second.CssClass = "left_menu_active";
        first.CssClass = "left_menu";

        string AssignToID = String.Empty;
        if(fvDiaryDetails.CurrentMode == FormViewMode.Insert)
             AssignToID = ((TextBox)fvDiaryDetails.FindControl("txtIAssignToID")).Text;
        if(fvDiaryDetails.CurrentMode == FormViewMode.Edit)
            AssignToID = ((TextBox)fvDiaryDetails.FindControl("txtAssignToID")).Text;

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
                    sendMail(ConfigurationManager.AppSettings["mailFrom"].ToString(), lstSecurity[0].Email, string.Empty, string.Empty, "Diary Assigned :" + lblClaimNum.Text, "You have been assigned diary for claim number :" + lblClaimNum.Text);
                }
            }
        }

        InsertUpdateDiary();
        BindDiaryDetails();
        mvDiaryDetails.ActiveViewIndex = 0;
        
    }
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
            }
            if (e.CommandName == "EditItem")
            {
                divSearch.Style["display"] = "none";
                divfirst.Style["display"] = "none";
                divthird.Style["display"] = "block";
                divbtn.Style["display"] = "none";

                Bindfv(FormViewMode.Edit);
                ((Button)fvDiaryDetails.FindControl("btnAssignTO")).Attributes.Add("onClick", "return openPopUp('" + ((TextBox)fvDiaryDetails.FindControl("txtAssignTo")).ID + "','" + ((TextBox)fvDiaryDetails.FindControl("txtAssignToID")).ID + "');");
                Session["mode"] = "edit";
            }
            else if (e.CommandName == "View")
            {
                divSearch.Style["display"] = "none";
                divfirst.Style["display"] = "none";
                divthird.Style["display"] = "block";
                divbtn.Style["display"] = "none";
                Bindfv(FormViewMode.ReadOnly);

            }
            second.CssClass = "left_menu_active";
            first.CssClass = "left_menu";
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
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
    protected void fvDiaryDetails_DataBound(object sender, EventArgs e)
    {
        try
        {
            // -- Display Dynamic Labels.
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
                    ((RadioButton)fvDiaryDetails.FindControl("rbClearYes")).Checked = true;
                if (lstDiary[0].Clear == "N")
                    ((RadioButton)fvDiaryDetails.FindControl("rbClearNo")).Checked = true;
                ((TextBox)fvDiaryDetails.FindControl("txtAssignTo")).Text = lstDiary[0].Assigned_To;
            }
            if (fvDiaryDetails.CurrentMode == FormViewMode.ReadOnly)
            {
                if(lstDiary[0].DateOfNoteEntry !=null)
                    ((Label)fvDiaryDetails.FindControl("lblDONoteEntry")).Text = Convert.ToDateTime(lstDiary[0].DateOfNoteEntry).ToShortDateString();
                ((Label)fvDiaryDetails.FindControl("lblDiaryDate")).Text = Convert.ToDateTime(lstDiary[0].Diary_Date).ToShortDateString();
                ((Label)fvDiaryDetails.FindControl("lblNote")).Text = lstDiary[0].Note;
                if (lstDiary[0].Clear == "Y")
                    ((Label)fvDiaryDetails.FindControl("lblClear")).Text="Yes";
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
                lstDiary = objDiary.Search_DiaryData(ddlSearch.SelectedValue, txtSearch.Text.Trim().Replace("'","''"), Convert.ToDecimal(ViewState["TableFK"].ToString()), ViewState["TableName"].ToString());
            }
            else
            {
                if(ViewState["TableFK"] != null && ViewState["TableFK"].ToString() != String.Empty)
                    lstDiary = objDiary.Search_DiaryData(null, null, Convert.ToDecimal(ViewState["TableFK"].ToString()), ViewState["TableName"].ToString());
            }
            gvDiaryDetails.DataSource = lstDiary;
            gvDiaryDetails.DataBind();
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
    protected void gvDiaryDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        //if (txtPageNo.Text != string.Empty && Convert.ToInt32(txtPageNo.Text) <= gvBankDetails.PageCount)
        {

            //gvBankDetails.PageIndex = e.NewPageIndex+1;
            //gvBankDetails.DataSource = BindBankDetails();
            //gvBankDetails.DataBind();


        }
    }
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
                objDiary= new RIMS_Base.Biz.Diary();
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
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }
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
            first.Style["CssClass"] = "left_menu";
            second.Style["CssClass"] = "left_menu_active"; 
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }
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

    protected void second_Click(object sender, EventArgs e)
    {
        second.CssClass = "left_menu_active";
        first.CssClass = "left_menu";
        mvDiaryDetails.ActiveViewIndex = 0;
                
        divfirst.Style["display"] = "none";
        divSearch.Style["display"] = "block";
        divbtn.Style["display"] = "block";
        divthird.Style["display"] = "block";

    }
    protected void first_Click(object sender, EventArgs e)
    {
        second.CssClass = "left_menu";
        first.CssClass = "left_menu_active";
        mvDiaryDetails.ActiveViewIndex = 0;

        divfirst.Style["display"] = "block";
        divSearch.Style["display"] = "none";
        divbtn.Style["display"] = "block";
        divthird.Style["display"] = "none";

    }
    
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

        }
        catch (Exception ex)
        {
            throw ex;
        }


    }

    #region ViewAll Functionality From Main Seaarch Grid

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
               if(ViewState["TableFK"] != null && ViewState["TableFK"].ToString() != String.Empty)
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
   
    protected void gvViewAll_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if(((Label)e.Row.FindControl("lblVNoteType")).Text == "Y")
                ((Label)e.Row.FindControl("lblVNoteType")).Text = "Yes";
            else if(((Label)e.Row.FindControl("lblVNoteType")).Text == "N")
                ((Label)e.Row.FindControl("lblVNoteType")).Text = "No";

            // -- Display Dynamic Labels.
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

    protected void btnViewNext_Click(object sender, EventArgs e)
    {
        Response.Redirect("MainAdjuster.aspx");
    }

    #endregion

    #region User Rights
    protected bool SetUserRights()
    {
        try
        {

            m_objRightDetails = new CRolePermission();
            if (Session["UserRoleId"] != null)
            {
                lstRightDetails = m_objRightDetails.GetRights(1, Convert.ToInt32(Session["UserRoleId"].ToString()));
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
}
