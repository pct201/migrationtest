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
using System.Text;
using System.Collections.Generic;
using System.Threading;
using RIMS_Base.Biz;

public partial class SONIC_ClaimInfo_MainDiary : System.Web.UI.Page
{
    #region Variable

    /// <summary>
    /// Variable Diclaration
    /// </summary>
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

    #region Properties
    /// <summary>
    /// Denotes Index for active menu
    /// </summary>
    private int intActiveIndex
    {
        get { return Convert.ToInt32(ViewState["ActiveMenuIndex"]); }
        set { ViewState["ActiveMenuIndex"] = value; }
    }
    /// <summary>
    /// Denotes TableFK
    /// </summary>
    public int TableFK
    {
        get
        {
            return Convert.ToInt32(ViewState["TableFK"]);
        }
        set { ViewState["TableFK"] = value; }
    }
    /// <summary>
    /// Denotes TableName
    /// </summary>
    public string TableName
    {
        get
        {
            return Convert.ToString(ViewState["TableName"]);
        }
        set { ViewState["TableName"] = value; }
    }

    /// <summary>
    /// Getting all locations record here so pass 0000 and in sp condition is checked based on 0000
    /// </summary>
    private string LocationIds
    {

        get { return "0000"; }
    }

    #endregion

    #region "Page Event"

    /// <summary>
    /// Handles event when page is loaded
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        // set Diary tab selected
        lblScript.Text = "";
        //New Diary added from new Diray page.
        btnAddNew.Visible = false; 
        ClaimTab.SetSelectedTab(Controls_ClaimTab_ClaimTab.Tab.Diary);
        if (intActiveIndex == 1) btnNextStep.Visible = false;

        // if page is loaded first time
        if (!IsPostBack)
        {
            #region General
            // check claim id is passed in querystring or not.
            if (Request.QueryString["id"] != null && Request.QueryString["id"] != string.Empty)
            {
                try
                {
                    //Get claim id from query string and store in viewstate.   
                    TableFK = (int)clsGeneral.GetQueryStringID(Convert.ToString(Request.QueryString["id"]));                    
                    Session["WorkerCompID"] = TableFK;
                }
                catch
                {
                    Response.Redirect("ClaimInformationSearch.aspx");
                }
            }
            else
            {
                //if no querystring is passed redirect to search page.
                Response.Redirect("ClaimInformationSearch.aspx");
            }
            // check Table Name is passed in querystring or not.
            if (Request.QueryString["tbl"] != null && Request.QueryString["tbl"] != string.Empty)
            {
                try
                {
                    //Get claim id from query string and store in viewstate.
                    TableName = GetTableName(Convert.ToString((Request.QueryString["tbl"].ToString()))); 
                }
                catch
                {
                    Response.Redirect("ClaimInformationSearch.aspx");
                }
            }
            else
            {
                //if no querystring is passed redirect to search page.
                Response.Redirect("ClaimInformationSearch.aspx");
            }
            #endregion

            // bind claim information and bind diary grid
            BindWCClaimInfo();
            btnDelete.Attributes.Add("onclick", "return OMSCheckSelected1('chkItem','gvDiaryDetails','Delete');");
            mvDiaryDetails.ActiveViewIndex = 0;
            gvDiaryDetails.PageSize = 10;
            intActiveIndex = 1;
            ddlPage.DataBind();
            ddlPage.SelectedValue = "10";
            lblPageInfo.Text = "Page 1 of " + gvDiaryDetails.PageCount.ToString();
            txtPageNo.Text = "1";
            if (Session["ViewAll"] != null && Session["ViewAll"].ToString() != String.Empty)
                ViewAllFromSearchGrid();
        }
    }

    /// <summary>
    /// Handles event before page is loaded
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_PreRender(object sender, EventArgs e)
    {
        // bind the grid
        if (Session["ViewAll"] == null && !IsPostBack)
        {
            GeneralSorting();
        }
    }

    #endregion

    #region Event Handler    

    #region Employee Information

    /// <summary>
    /// Used to display employee information
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
    /// Used to save the diary data
    /// </summary>
    protected void InsertUpdateDiary()
    {
        // object for the diary
        objDiary = new RIMS_Base.Biz.Diary();
        try
        {
            // set Diary PK and user ID
            if (ViewState["Pk_diary"] != null && ViewState["Pk_diary"].ToString() != "")
            {
                objDiary.PK_Diary_ID = Convert.ToInt32(ViewState["Pk_diary"].ToString());
                objDiary.Update_Date = DateTime.Now;
                if (Session["UserID"] != null)
                    objDiary.Updated_By = Session["UserID"].ToString();
            }
            objDiary.FK_Table_Name = Convert.ToDecimal(TableFK);
            objDiary.Table_Name = TableName;
            if (Session["UserName"] != null)
                objDiary.UserDiary = Session["UserName"].ToString();
            
            // set the object values from page controls depending on the mode of the page
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
    /// Handles Next Step button click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnNextStep_Click(object sender, EventArgs e)
    {
        // if last menu is selected then redirect to Adjuster page
        if (intActiveIndex == 2)
            Response.Redirect("Adjuster.aspx", true);
        else
        {
            intActiveIndex = intActiveIndex + 1;

            // check the menu index and call the methods accordingly
            if (intActiveIndex == 1)
            {
                first_Click(null, null);
            }
            if (intActiveIndex == 2)
            {
                second_Click(null, null);
            }
        }
    }

    #region Grid's All types of Events

    /// <summary>
    /// Handles Save & View button click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSaveView_Click(object sender, EventArgs e)
    {
        // show/hide required div
        divSearch.Style["display"] = "block";
        divfirst.Style["display"] = "none";
        divthird.Style["display"] = "block";
        divbtn.Style["display"] = "block";
        second.CssClass = "left_menu_active";
        first.CssClass = "left_menu";

        // get assigned to ID from hidden textbox
        string AssignToID = String.Empty;
        if (fvDiaryDetails.CurrentMode == FormViewMode.Insert)
            AssignToID = ((TextBox)fvDiaryDetails.FindControl("txtIAssignToID")).Text;
        if (fvDiaryDetails.CurrentMode == FormViewMode.Edit)
            AssignToID = ((TextBox)fvDiaryDetails.FindControl("txtAssignToID")).Text;

        /********* MAIL PROCESS ********************/
        if (AssignToID != String.Empty)
        {
            RIMS_Base.Biz.CSecurity m_objSecurity = new RIMS_Base.Biz.CSecurity();
            List<RIMS_Base.CSecurity> lstSecurity = new List<RIMS_Base.CSecurity>();
            lstSecurity = m_objSecurity.GetSecurityByID(Convert.ToInt32(AssignToID));
            if (lstSecurity.Count > 0)
            {
                string AssignTO = "";

                if (lstSecurity[0].Email != string.Empty)
                {
                    clsGeneral.SendMailMessage(AppConfig.MailFrom, lstSecurity[0].Email, "", AppConfig.MailCC, "Diary Assigned :" + lblClaimNum.Text, "You have been assigned diary for claim number :" + lblClaimNum.Text, false);
                }
            }
        }
        /****************************************/

        // save record and bind the diary grid
        InsertUpdateDiary();
        BindDiaryDetails();
        mvDiaryDetails.ActiveViewIndex = 0;
    }

    /// <summary>
    /// Handles Cancel button click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        // show/hide required DIV
        divSearch.Style["display"] = "block";
        divfirst.Style["display"] = "none";
        divthird.Style["display"] = "block";
        divbtn.Style["display"] = "block";
        second.CssClass = "left_menu_active";
        first.CssClass = "left_menu";
        mvDiaryDetails.ActiveViewIndex = 0;
    }

    /// <summary>
    /// Handles Rowcommand event for Diary details grid
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

    /// <summary>
    /// Binds formview as specified mode(Insert/Edit/View)
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
            
            if (fvMode != FormViewMode.Insert)
            {
                objDiary = new RIMS_Base.Biz.Diary();
                lstDiary = new List<RIMS_Base.CDiary>();
                lstDiary = objDiary.GetyByID(Pk_DiaryId);
                fvDiaryDetails.DataSource = lstDiary;
            }
            fvDiaryDetails.DataBind();
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
    /// Handles event when row data is bound in diary view
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
                string strCtrlsIDs = "";
                string strMessages = "";

                #region "Diary Validations"
                DataTable dtFields = clsScreen_Validators.SelectByScreen(136).Tables[0];
                dtFields.DefaultView.RowFilter = "IsRequired = '1'";
                dtFields = dtFields.DefaultView.ToTable();

                MenuAsterisk2.Style["display"] = (dtFields.Select("LeftMenuIndex = 2").Length > 0) ? "inline-block" : "none";

                foreach (DataRow drField in dtFields.Rows)
                {
                    #region " set validation control IDs and messages "
                    switch (Convert.ToString(drField["Field_Name"]))
                    {
                        case "Date of Note Entry":
                            strCtrlsIDs += "ctl00_ContentPlaceHolder1_fvDiaryDetails_txtIDONoteEntry,";
                            strMessages += "Please enter Date of Note Entry" + ",";
                            ((HtmlGenericControl)fvDiaryDetails.FindControl("Span8")).Style["display"] = "inline-block";
                            break;
                        case "Diary Date":
                            strCtrlsIDs += "ctl00_ContentPlaceHolder1_fvDiaryDetails_txtIDiaryDate,";
                            strMessages += "Please enter Diary Date" + ",";
                            ((HtmlGenericControl)fvDiaryDetails.FindControl("Span1")).Style["display"] = "inline-block";
                            break;
                        case "Note":
                            strCtrlsIDs += "ctl00_ContentPlaceHolder1_fvDiaryDetails_txtINote,";
                            strMessages += "Please enter Note" + ",";
                            ((HtmlGenericControl)fvDiaryDetails.FindControl("Span2")).Style["display"] = "inline-block";
                            break;
                        case "Assigned To":
                            strCtrlsIDs += "ctl00_ContentPlaceHolder1_fvDiaryDetails_txtIAssignTo,";
                            strMessages += "Please enter Assigned To" + ",";
                            ((HtmlGenericControl)fvDiaryDetails.FindControl("Span3")).Style["display"] = "inline-block";
                            break;
                    }
                    #endregion
                }
                strCtrlsIDs = strCtrlsIDs.TrimEnd(',');
                strMessages = strMessages.TrimEnd(',');
               
                hdnControlIDs.Value = strCtrlsIDs;
                hdnErrorMsgs.Value = strMessages;
                #endregion


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

               
                string strCtrlsIDs = "";
                string strMessages = "";


                #region "Diary"
                DataTable dtFields = clsScreen_Validators.SelectByScreen(136).Tables[0];
                dtFields.DefaultView.RowFilter = "IsRequired = '1'";
                dtFields = dtFields.DefaultView.ToTable();

                MenuAsterisk2.Style["display"] = (dtFields.Select("LeftMenuIndex = 2").Length > 0) ? "inline-block" : "none";
                
                foreach (DataRow drField in dtFields.Rows)
                {
                    #region " set validation control IDs and messages "
                    switch (Convert.ToString(drField["Field_Name"]))
                    {
                        case "Date of Note Entry":
                            strCtrlsIDs += "ctl00_ContentPlaceHolder1_fvDiaryDetails_txtDONoteEntry,";
                            strMessages += "Please enter Date of Note Entry" + ",";
                            ((HtmlGenericControl)fvDiaryDetails.FindControl("Span7")).Style["display"] = "inline-block";
                            break;
                        case "Diary Date":
                            strCtrlsIDs += "ctl00_ContentPlaceHolder1_fvDiaryDetails_txtDiaryDate,";
                            strMessages += "Please enter Diary Date" + ",";
                            ((HtmlGenericControl)fvDiaryDetails.FindControl("Span4")).Style["display"] = "inline-block";
                            break;
                        case "Note":
                            strCtrlsIDs += "ctl00_ContentPlaceHolder1_fvDiaryDetails_txtNote,";
                            strMessages += "Please enter Note" + ",";
                            ((HtmlGenericControl)fvDiaryDetails.FindControl("Span5")).Style["display"] = "inline-block";
                            break;
                        case "Assigned To":
                            strCtrlsIDs += "ctl00_ContentPlaceHolder1_fvDiaryDetails_txtAssignTo,";
                            strMessages += "Please enter Assigned To" + ",";
                            ((HtmlGenericControl)fvDiaryDetails.FindControl("Span6")).Style["display"] = "inline-block";
                            break;
                    }
                    #endregion
                }
                strCtrlsIDs = strCtrlsIDs.TrimEnd(',');
                strMessages = strMessages.TrimEnd(',');

                hdnControlUpdateIDs.Value = strCtrlsIDs;
                hdnUpdateErrorMsgs.Value = strMessages;
                #endregion
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
                lstDiary = objDiary.Search_DiaryData(ddlSearch.SelectedValue, txtSearch.Text.Trim().Replace("'", "''"), Convert.ToDecimal(ViewState["TableFK"].ToString()), ViewState["TableName"].ToString(), LocationIds);
            }
            else
            {
                if (ViewState["TableFK"] != null && ViewState["TableFK"].ToString() != String.Empty)
                    lstDiary = objDiary.Search_DiaryData(null, null, Convert.ToDecimal(ViewState["TableFK"].ToString()), ViewState["TableName"].ToString(), LocationIds);
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
    /// Handles event when sorting is performed on Diary details grid
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

        lstDiary = objDiary.Search_DiaryData(null, null, Convert.ToDecimal(ViewState["TableFK"].ToString()), ViewState["TableName"].ToString(), LocationIds);

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
    /// Handles event when row is created for Dairy details grid
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
    /// Get index of the column on which sorting is performed
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
    /// Used to add image beside the column on which sorting is done
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
    /// Used to bind the row when grid is bound
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
    /// Handles Search button click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            // bind the diary grid
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
    /// Handles the delete button click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            // delete the selected diary records and bind the grid
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
    /// Handles event when Add New button is clicked
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
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /// <summary>
    /// Handles Go button click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnGo_Click(object sender, EventArgs e)
    {
        try
        {
            // set the pageindex of diary grid based on the page number entered in textbox
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

            // show/hide the DIVs
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
    /// Handles event for Next button click in paging
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnNext_Click(object sender, EventArgs e)
    {
        try
        {
            // if page index is less than the pagecount for diary grid
            if (gvDiaryDetails.PageIndex <= gvDiaryDetails.PageCount)
            {
                gvDiaryDetails.PageIndex = gvDiaryDetails.PageIndex + 1;
                GeneralSorting();
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
    /// Handles event when page number selection is changed in dropdown
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ddlPage_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            // set the page size and bind the grid
            gvDiaryDetails.PageSize = Convert.ToInt32(ddlPage.SelectedValue);
            BindDiaryDetails();
            lblPageInfo.Text = "Page 1 of " + gvDiaryDetails.PageCount.ToString();
            txtPageNo.Text = "1";
            // show/hide the DIVs
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
    /// Handles Prev button click event for paging
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnPrev_Click(object sender, EventArgs e)
    {
        try
        {
            // set page index 
            if (gvDiaryDetails.PageIndex <= gvDiaryDetails.PageCount)
            {
                if (gvDiaryDetails.PageIndex != 0)
                {
                    gvDiaryDetails.PageIndex = gvDiaryDetails.PageIndex - 1;
                    GeneralSorting();                    
                    lblPageInfo.Text = "Page " + Convert.ToString(gvDiaryDetails.PageIndex + 1) + " of " + gvDiaryDetails.PageCount.ToString();
                }
            }
            // show/hide the DIVs
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
    /// Handles event when second menu is clicked
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void second_Click(object sender, EventArgs e)
    {
        // set active index for menu
        intActiveIndex = 2;
        second.CssClass = "left_menu_active";
        first.CssClass = "left_menu";
        mvDiaryDetails.ActiveViewIndex = 0;

        // show/hide the required DIV
        divfirst.Style["display"] = "none";
        divSearch.Style["display"] = "block";
        divbtn.Style["display"] = "block";
        divthird.Style["display"] = "block";
        btnNextStep.Style[HtmlTextWriterStyle.Display] = "block";
    }

    /// <summary>
    /// Handles event when first menu is clicked
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
        btnNextStep.Style[HtmlTextWriterStyle.Display] = "none";
    }

    /// <summary>
    /// General Sorting
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

    private string GetTableName(string Code)
    {
        string _TableName = string.Empty;

        switch (Code)
        {
            case "WC_Claim":
                _TableName = "Workers_Comp_Claims";
                break;
            case "NS_Claim":
                _TableName = "Workers_Comp_Claims";
                break;
            case "AL_Claim":
                _TableName = "Auto_Loss_Claims";
                break;
            case "DPD_Claim":
                _TableName = "DPD_Claims";
                break;
            case "PL_Claim":
                _TableName = "Premises_Loss_Claims";
                break;
            case "Property_Claim":
                _TableName = "Property_FR";
                break; 
            default :
                _TableName = "";
                break;
        }

        return _TableName; 
    }

    #region ViewAll Functionality From Main Seaarch Grid

    /// <summary>
    /// View all From Seach Grid 
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
                lstDiary = objDiary.Search_DiaryData(ddlSearch.SelectedValue, txtSearch.Text.Trim(), Convert.ToDecimal(ViewState["TableFK"].ToString()), ViewState["TableName"].ToString(), LocationIds);
            }
            else
            {
                if (ViewState["TableFK"] != null && ViewState["TableFK"].ToString() != String.Empty)
                    lstDiary = objDiary.Search_DiaryData(null, null, Convert.ToDecimal(ViewState["TableFK"].ToString()), ViewState["TableName"].ToString(), LocationIds);
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
    /// Grid view Data Rowbound Event
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
    /// Button Click Event - next button
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

    /// <summary>
    /// Function to bind the Claim Information and Finacial Information
    /// </summary>
    public void BindWCClaimInfo()
    {
        if (TableName.ToLower() == "wc_claim")
        {
            trWCHeader.Style.Add("display", "block");
            DataSet dsWorkers_Comp_Claims = WC_ClaimInfo.SelectByPK(TableFK);
            DataTable dtWorkers_Comp_Claims = dsWorkers_Comp_Claims.Tables[0];


            if (dtWorkers_Comp_Claims.Rows.Count > 0)
            {
                DataRow drWorkers_Comp_Claims = dtWorkers_Comp_Claims.Rows[0];

                lblClaimNumber_WC.Text = Convert.ToString(drWorkers_Comp_Claims["Origin_Claim_Number"]);
                lblDateIncident1_WC.Text = drWorkers_Comp_Claims["Date_Of_Accident"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drWorkers_Comp_Claims["Date_Of_Accident"]));
                lblLocationdba_WC.Text = Convert.ToString(drWorkers_Comp_Claims["dba1"]);

                if (drWorkers_Comp_Claims["WC_FR_Number"] != DBNull.Value)
                {
                    decimal _decFR_Number;
                    if (decimal.TryParse(Convert.ToString(drWorkers_Comp_Claims["WC_FR_Number"]), out _decFR_Number))
                    {
                        lnkAssociatedFirstReport_WC.Text = Convert.ToString(_decFR_Number);

                        ////Get the details of Associated first report from the report number.
                      
                            int int_WC_FR = Convert.ToInt32(drWorkers_Comp_Claims["PK_WC_FR_ID"]);
                            lnkAddInvestigation_WC.PostBackUrl = AppConfig.SiteURL + "SONIC/FirstReport/Investigation.aspx?wc=" + int_WC_FR;
                            int intInvID = Investigation.SelectPKByWc_FR_ID(int_WC_FR);
                            if (intInvID > 0)
                            {
                                lnkInvestigation_WC.Text = intInvID.ToString();
                                lnkInvestigation_WC.PostBackUrl = AppConfig.SiteURL + "SONIC/FirstReport/Investigation.aspx?id=" + Encryption.Encrypt(intInvID.ToString()) + "&wc=" +  Encryption.Encrypt(int_WC_FR.ToString());
                                lnkAddInvestigation_WC.Visible = false;
                            }                      
                    }
                }
                else
                {
                    lnkAddInvestigation_WC.Visible = false;
                }

                lblName_WC.Text = Convert.ToString(drWorkers_Comp_Claims["Employee_Name"]);
                lblClaimNum.Text = Convert.ToString(drWorkers_Comp_Claims["Origin_Claim_Number"]);
                lblDateIncident.Text = drWorkers_Comp_Claims["Date_Of_Accident"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drWorkers_Comp_Claims["Date_Of_Accident"]));
                lblName1.Text = Convert.ToString(drWorkers_Comp_Claims["Employee_Name"]);

                lblVClaimNo.Text = Convert.ToString(drWorkers_Comp_Claims["Origin_Claim_Number"]);
                lblVDOInci.Text = drWorkers_Comp_Claims["Date_Of_Accident"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drWorkers_Comp_Claims["Date_Of_Accident"]));
                lblVName.Text = Convert.ToString(drWorkers_Comp_Claims["Employee_Name"]);
                lblVEmployee.Text = "";

                lblClaimNo.Text = Convert.ToString(drWorkers_Comp_Claims["Origin_Claim_Number"]);
                lblDOIncident.Text = drWorkers_Comp_Claims["Date_Of_Accident"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drWorkers_Comp_Claims["Date_Of_Accident"]));
                lblNameView.Text = Convert.ToString(drWorkers_Comp_Claims["Employee_Name"]);                
            }

        }
        if (TableName.ToLower() == "al_claim")
        {
            trALHeader.Style.Add("display", "block");
            DataSet dsAuto_Loss_Claims = AL_ClaimInfo.SelectByPK(TableFK);
            DataTable dtAuto_Loss_Claims = dsAuto_Loss_Claims.Tables[0];

            if (dtAuto_Loss_Claims.Rows.Count > 0)
            {
                DataRow drAuto_Loss_Claims = dtAuto_Loss_Claims.Rows[0];

                lblClaimNumber_AL.Text = Convert.ToString(drAuto_Loss_Claims["Origin_Claim_Number"]);
                lblDateIncident_AL.Text = drAuto_Loss_Claims["Date_Of_Accident"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drAuto_Loss_Claims["Date_Of_Accident"]));
                lblLocationdba_AL.Text = Convert.ToString(drAuto_Loss_Claims["dba"]);
                lnkAssociatedFirstReport_AL.Text = Convert.ToString(drAuto_Loss_Claims["Associated_First_Report"]);
                lblName_AL.Text = Convert.ToString(drAuto_Loss_Claims["Employee_Name"]);

                lblClaimNum.Text = Convert.ToString(drAuto_Loss_Claims["Origin_Claim_Number"]);
                lblDateIncident.Text = drAuto_Loss_Claims["Date_Of_Accident"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drAuto_Loss_Claims["Date_Of_Accident"]));
                lblName1.Text = Convert.ToString(drAuto_Loss_Claims["Employee_Name"]);

                lblVClaimNo.Text = Convert.ToString(drAuto_Loss_Claims["Origin_Claim_Number"]);
                lblVDOInci.Text = drAuto_Loss_Claims["Date_Of_Accident"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drAuto_Loss_Claims["Date_Of_Accident"]));
                lblVName.Text = Convert.ToString(drAuto_Loss_Claims["Employee_Name"]);

                lblClaimNo.Text = Convert.ToString(drAuto_Loss_Claims["Origin_Claim_Number"]);
                lblDOIncident.Text = drAuto_Loss_Claims["Date_Of_Accident"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drAuto_Loss_Claims["Date_Of_Accident"]));
                lblNameView.Text = Convert.ToString(drAuto_Loss_Claims["Employee_Name"]);                
            }
        }
        if (TableName.ToLower() == "dpd_claim")
        {
            trDPDHeader.Style.Add("display", "block");
            DataSet dsDPD_Claims = DPD_ClaimInfo.SelectViewClaim(TableFK);
            DataTable dtDPD_Claims = dsDPD_Claims.Tables[0];
            if (dtDPD_Claims.Rows.Count > 0)
            {
                DataRow drDPD_Claims = dtDPD_Claims.Rows[0];

                lblClaimNumber_DPD.Text = Convert.ToString(drDPD_Claims["Claim_Number"]);
                lblLocationdba_DPD.Text = Convert.ToString(drDPD_Claims["dba"]);
                lblDateLoss_DPD.Text = drDPD_Claims["Date_Of_Loss"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drDPD_Claims["Date_Of_Loss"].ToString()));
                lnkAssociatedFirstReport_DPD.Text = Convert.ToString(drDPD_Claims["Associated_First_Report"]);

                lblClaimNum.Text = Convert.ToString(drDPD_Claims["Claim_Number"]);
                lblDateIncident.Text = drDPD_Claims["Date_Of_Loss"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drDPD_Claims["Date_Of_Loss"].ToString()));

                lblVClaimNo.Text = Convert.ToString(drDPD_Claims["Claim_Number"]);
                lblVDOInci.Text = drDPD_Claims["Date_Of_Loss"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drDPD_Claims["Date_Of_Loss"].ToString()));

                lblClaimNo.Text = Convert.ToString(drDPD_Claims["Claim_Number"]);
                lblDOIncident.Text = drDPD_Claims["Date_Of_Loss"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drDPD_Claims["Date_Of_Loss"].ToString()));
            }
        }
        if (TableName.ToLower() == "pl_claim")
        {
            trPLHeader.Style.Add("display", "block");
            DataSet dsPremises_Loss_Claims = PL_ClaimInfo.SelectByPK(TableFK);
            DataTable dtPremises_Loss_Claims = dsPremises_Loss_Claims.Tables[0];

            if (dtPremises_Loss_Claims.Rows.Count > 0)
            {
                DataRow drPremises_Loss_Claims = dtPremises_Loss_Claims.Rows[0];

                lblClaimNumber_PL.Text = Convert.ToString(drPremises_Loss_Claims["Origin_Claim_Number"]);
                lblDateIncident_PL.Text = drPremises_Loss_Claims["Date_Of_Accident"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drPremises_Loss_Claims["Date_Of_Accident"]));
                lblLocationdba_PL.Text = Convert.ToString(drPremises_Loss_Claims["dba"]);
                lnkAssociatedFirstReport_PL.Text = Convert.ToString(drPremises_Loss_Claims["Associated_First_Report"]);
                lblName_PL.Text = Convert.ToString(drPremises_Loss_Claims["Employee_Name"]);

                lblClaimNum.Text = Convert.ToString(drPremises_Loss_Claims["Origin_Claim_Number"]);
                lblDateIncident.Text = drPremises_Loss_Claims["Date_Of_Accident"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drPremises_Loss_Claims["Date_Of_Accident"]));
                lblName1.Text = Convert.ToString(drPremises_Loss_Claims["Employee_Name"]);

                lblVClaimNo.Text = Convert.ToString(drPremises_Loss_Claims["Origin_Claim_Number"]);
                lblVDOInci.Text = drPremises_Loss_Claims["Date_Of_Accident"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drPremises_Loss_Claims["Date_Of_Accident"]));
                lblVName.Text = Convert.ToString(drPremises_Loss_Claims["Employee_Name"]);

                lblClaimNo.Text = Convert.ToString(drPremises_Loss_Claims["Origin_Claim_Number"]);
                lblDOIncident.Text = drPremises_Loss_Claims["Date_Of_Accident"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drPremises_Loss_Claims["Date_Of_Accident"]));
                lblNameView.Text = Convert.ToString(drPremises_Loss_Claims["Employee_Name"]);
            }
        }
        if (TableName.ToLower() == "property_claim")
        {
            trPROPHeader.Style.Add("display", "block");
            DataSet dsProperty_FR = Property_ClaimInfo.SelectByPK(TableFK);
            DataTable dtProperty_FR = dsProperty_FR.Tables[0];
            if (dtProperty_FR.Rows.Count > 0)
            {
                DataRow drProperty_FR = dtProperty_FR.Rows[0];

                //Header Information
                lblClaimNumber_Prop.Text = Convert.ToString(drProperty_FR["Property_FR_Number"]);
                lblLocationdba_Prop.Text = Convert.ToString(drProperty_FR["dba"]);
                lnkAssociatedFirstReport_Prop.Text = Convert.ToString(drProperty_FR["Property_FR_Number"]);
                lblDateIncident_Prop.Text = drProperty_FR["Date_Of_Loss"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drProperty_FR["Date_Of_Loss"]));

                lblClaimNum.Text = Convert.ToString(drProperty_FR["Property_FR_Number"]);
                lblDateIncident.Text = drProperty_FR["Date_Of_Loss"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drProperty_FR["Date_Of_Loss"]));

                lblVClaimNo.Text = Convert.ToString(drProperty_FR["Property_FR_Number"]);
                lblVDOInci.Text = drProperty_FR["Date_Of_Loss"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drProperty_FR["Date_Of_Loss"]));

                lblClaimNo.Text = Convert.ToString(drProperty_FR["Property_FR_Number"]);
                lblDOIncident.Text = drProperty_FR["Date_Of_Loss"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drProperty_FR["Date_Of_Loss"]));
            }
        }
    }

    /// <summary>
    /// Linkbutton Click Event - Associated First report
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkAssociatedFirstReport_WC_Click(object sender, EventArgs e)
    {
        //Get the details of Associated first report from the report number.
        DataSet dsWCFirstReport = WC_FR.SelectByWC_FR_Number(Convert.ToDecimal(lnkAssociatedFirstReport_WC.Text.Trim()));

        //Check First report found or not
        if (dsWCFirstReport.Tables[0].Rows.Count > 0)
        {
            //set the wizard id in session
            clsSession.First_Report_Wizard_ID = Convert.ToInt32(dsWCFirstReport.Tables[0].Rows[0]["FK_First_Report_Wizard_ID"]);

            //redirect to the Workers Compensation  first report page
            Response.Redirect("../FirstReport/WCFirstReport.aspx?id=" + Encryption.Encrypt(dsWCFirstReport.Tables[0].Rows[0]["PK_WC_FR_ID"].ToString()));
        }
        else
            Response.Redirect("ClaimInformationSearch.aspx");
    }
   
    /// <summary>
    /// Link Button Associated First Report AL -Click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkAssociatedFirstReport_AL_Click(object sender, EventArgs e)
    {
        //Get the details of Associated first report from the report number.
        DataSet dsALFirstReport = AL_FR.SelectByAL_FR_Number(Convert.ToDecimal(lnkAssociatedFirstReport_AL.Text));

        //Check First report found or not
        if (dsALFirstReport.Tables[0].Rows.Count > 0)
        {
            //set the wizard id in session
            clsSession.First_Report_Wizard_ID = Convert.ToInt32(dsALFirstReport.Tables[0].Rows[0]["FK_First_Report_Wizard_ID"]);

            //redirect to the auto loss first report page
            Response.Redirect("../FirstReport/ALFirstReport.aspx?id=" + Encryption.Encrypt(dsALFirstReport.Tables[0].Rows[0]["PK_AL_FR_ID"].ToString()));
        }
        else
            Response.Redirect("ClaimInformationSearch.aspx");
    }
   
    /// <summary>
    /// Link Button Click Event - Associated First Report DPD
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkAssociatedFirstReport_DPD_Click(object sender, EventArgs e)
    {
        //Get the details of Associated first report from the report number.
        DataSet dsDPDFirstReport = DPD_FR.SelectByDPD_FR_Number(Convert.ToDecimal(lnkAssociatedFirstReport_DPD.Text));

        //Check First report found or not
        if (dsDPDFirstReport.Tables[0].Rows.Count > 0)
        {
            //set the wizard id in session
            clsSession.First_Report_Wizard_ID = Convert.ToInt32(dsDPDFirstReport.Tables[0].Rows[0]["FK_First_Report_Wizard_ID"]);

            //redirect to the DPD first report page
            Response.Redirect("../FirstReport/DPDFirstReport.aspx?id=" + Encryption.Encrypt(dsDPDFirstReport.Tables[0].Rows[0]["PK_DPD_FR_ID"].ToString()));
        }
        else
            Response.Redirect("ClaimInformationSearch.aspx");
    }

    /// <summary>
    /// Link Button Associated First Report - PL -Click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkAssociatedFirstReport_PL_Click(object sender, EventArgs e)
    {
        //Get the details of Associated first report from the report number.
        DataSet dsPLFirstReport = PL_FR.SelectByPL_FR_Number(Convert.ToDecimal(lnkAssociatedFirstReport_PL.Text));

        //Check First report found or not
        if (dsPLFirstReport.Tables[0].Rows.Count > 0)
        {
            //set the wizard id in session
            clsSession.First_Report_Wizard_ID = Convert.ToInt32(dsPLFirstReport.Tables[0].Rows[0]["FK_First_Report_Wizard_ID"]);

            //redirect to the Premises Loss first report page
            Response.Redirect("../FirstReport/PLFirstReport.aspx?id=" + Encryption.Encrypt(dsPLFirstReport.Tables[0].Rows[0]["PK_PL_FR_ID"].ToString()));
        }
        else
            Response.Redirect("ClaimInformationSearch.aspx");
    }
   
    /// <summary>
    /// Link Button CLick Event - Associated First Report -Property
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkAssociatedFirstReport_Prop_Click(object sender, EventArgs e)
    {
        DataSet ds = Property_FR.SelectByProperty_FR_Number(Convert.ToDecimal(lnkAssociatedFirstReport_Prop.Text));
        if (ds.Tables[0].Rows.Count > 0)
        {
            clsSession.First_Report_Wizard_ID = Convert.ToInt32(ds.Tables[0].Rows[0]["FK_First_Report_Wizard_ID"]);
            Response.Redirect("../FirstReport/PropertyFirstReport.aspx?id=" + Encryption.Encrypt(ds.Tables[0].Rows[0]["PK_Property_FR_ID"].ToString()));
        }
        else
            Response.Redirect("ClaimInformationSearch.aspx");
    }

    #endregion
  }
