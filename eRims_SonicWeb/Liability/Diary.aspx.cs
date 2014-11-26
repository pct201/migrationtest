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
using System.Collections.Generic;
using System.IO;
public partial class Liability_Diary : System.Web.UI.Page
{
    #region Variable
    public RIMS_Base.Biz.CCheckWriting m_objClaimReservesInfo;
    List<RIMS_Base.CCheckWriting> lstClaimReservesInfo = null;
    int Pk_DiaryId = 0;
    public List<RIMS_Base.CDiary> lstDiary;
    public RIMS_Base.Biz.Diary objDiary;
    int Diary_RetVal = -1;
    public string strVal = "";
    RIMS_Base.Biz.CLiabilityClaim objLiability;
    List<RIMS_Base.CLiabilityClaim> lstLiability;
    #endregion

    #region Event Handler
    protected void Page_Load(object sender, EventArgs e)
    {
        lblScript.Text = "";
        if (!IsPostBack)
        {
            Session.Remove("mode");
            ViewState.Clear();

            btnDelete.Attributes.Add("onclick", "return OMSCheckSelected1('chkItem','gvDiaryDetails','Delete');");
            mvDiaryDetails.ActiveViewIndex = 0;
            gvDiaryDetails.PageSize = 10;

            ddlPage.DataBind();
            ddlPage.SelectedValue = "10";
            lblPageInfo.Text = "Page 1 of " + gvDiaryDetails.PageCount.ToString();
            txtPageNo.Text = "1";

            Session["WorkerCompID"] = "43";

            if (Session["WorkerCompID"] != null && Session["WorkerCompID"].ToString() != String.Empty)
            {

                objLiability = new RIMS_Base.Biz.CLiabilityClaim();
                lstLiability = new List<RIMS_Base.CLiabilityClaim>();
                try
                {
                    lstLiability = objLiability.Getility_ClaimByID(Convert.ToInt32(Session["WorkerCompID"].ToString()));
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
            //ViewAllFromSearchGrid();
            if (Session["ViewAll"] != null && Session["ViewAll"].ToString() != String.Empty)
                ViewAllFromSearchGrid();
            else
                BindDiaryDetails();

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
        lblLName.Text = lstClaimReservesInfo[0].LastName.ToString().Replace("''", "'");
        lblFName.Text = lstClaimReservesInfo[0].FirstName.ToString().Replace("''", "'");
        lblMName.Text = lstClaimReservesInfo[0].MiddleName.ToString().Replace("''", "'");
        lblDateIncident.Text = lstClaimReservesInfo[0].IncidentDate.ToString();

        // --- For the View Page

        if (lstClaimReservesInfo[0].Employee.ToUpper() == "Y")
            lblEmployee.Text = "Yes";
        else if (lstClaimReservesInfo[0].Employee.ToUpper() == "N")
            lblEmployee.Text = "No";
        lblLastName.Text = lstClaimReservesInfo[0].LastName.ToString().Replace("''", "'");
        lblFirstName.Text = lstClaimReservesInfo[0].FirstName.ToString().Replace("''", "'");
        lblMiddleName.Text = lstClaimReservesInfo[0].MiddleName.ToString().Replace("''", "'");
        lblDOIncident.Text = lstClaimReservesInfo[0].IncidentDate.ToString();
        lblClaimNo.Text = lstClaimReservesInfo[0].Claim_Number.ToString();

        // ----  For the View All from the Main Seach Grid
        if (lstClaimReservesInfo[0].Employee.ToUpper() == "Y")
            lblVEmployee.Text = "Yes";
        else if (lstClaimReservesInfo[0].Employee.ToUpper() == "N")
            lblVEmployee.Text = "No";
        lblVLastName.Text = lstClaimReservesInfo[0].LastName.ToString().Replace("''", "'");
        lblVFirstName.Text = lstClaimReservesInfo[0].FirstName.ToString().Replace("''", "'");
        lblVMiddleMName.Text = lstClaimReservesInfo[0].MiddleName.ToString().Replace("''", "'");
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
                objDiary.Updated_By = "test";
            }
            objDiary.FK_Table_Name = Convert.ToDecimal(ViewState["TableFK"].ToString());
            objDiary.Table_Name = ViewState["TableName"].ToString();
            objDiary.UserDiary = "UserName";
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
        Response.Redirect("Adjuster.aspx", true);
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

        InsertUpdateDiary();
        BindDiaryDetails();
        mvDiaryDetails.ActiveViewIndex = 0;

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
                ((Button)fvDiaryDetails.FindControl("btnAssignTO")).Attributes.Add("onClick", "return openPopUp('" + ((TextBox)fvDiaryDetails.FindControl("txtAssignTo")).ID + "');");
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
        ViewState["SortExp"] = e.SortExpression;

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
            ((Button)fvDiaryDetails.FindControl("btnIAssignTO")).Attributes.Add("onClick", "return openPopUp('" + ((TextBox)fvDiaryDetails.FindControl("txtIAssignTo")).ID + "');");
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
                lstDiary.Sort(new RIMS_Base.GenericComparer<RIMS_Base.CDiary>((string)ViewState["SortExp"], (SortDirection)ViewState["sortDirection"]));
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
            if (((Label)e.Row.FindControl("lblVNoteType")).Text == "Y")
                ((Label)e.Row.FindControl("lblVNoteType")).Text = "Yes";
            else if (((Label)e.Row.FindControl("lblVNoteType")).Text == "N")
                ((Label)e.Row.FindControl("lblVNoteType")).Text = "No";
        }
    }

    protected void btnViewNext_Click(object sender, EventArgs e)
    {
        Response.Redirect("Adjuster.aspx");
    }

    #endregion

    #endregion
}
