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
using ERIMS.DAL;

public partial class EmployeeSearch : clsBasePage
{
    #region Varibale

    public RIMS_Base.Biz.CEmployeeSearch objEmpSearch;
    public List<RIMS_Base.CEmployeeSearch> lstEmpSearch;
    public RIMS_Base.Biz.CGeneral objGeneral;
    public List<RIMS_Base.CGeneral> lstGeneral;

    int EmpSearch_retVal = -1;
    string strSortExp = String.Empty;

    public string Operation
    {
        set { ViewState["op"] = value; }
        get { return clsGeneral.IsNull(ViewState["op"]) ? "" : ViewState["op"].ToString(); }

    }

    #endregion

    #region "Page Event"

    /// <summary>
    /// Page Load Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Session.Remove("WorkerCompID");
            Session.Remove("ViewAll");


            BindCombos();
            gvSearch.PageSize = 10;
            ddlPage.DataBind();
            ddlPage.SelectedValue = "10";
            lblPageInfo.Text = "Page 1 of " + gvSearch.PageCount.ToString();
            txtPageNo.Text = "1";
            txtClaimNo.Text = txtClaimNo.Text.ToString().Replace("__-_____-__", "");

            Operation = string.IsNullOrEmpty(Request.QueryString["p"]) ? "" : Request.QueryString["p"].ToString();

            if (string.Compare(Operation, "result") == 0 && Session["EmployeeSearch"] != null)
            {
                ShowSearchFromSession();
            }
            else
            {
                Session.Remove("EmployeeSearch");
                Session.Remove("ERPageSize");
                Session.Remove("ERPageSize");
                Session.Remove("ERCurrentPage");
                Session.Remove("ERSortExp");
                Session.Remove("ERSortDirection");

            }
        }

    }

    #endregion

    #region "Events"

    /// <summary>
    /// Button Click Event - back Button
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnBack_Click(object sender, EventArgs e)
    {
        divGrid.Style["display"] = "none";
        divSearch.Style["display"] = "block";
        divSearchpaging.Style["display"] = "none";
        ClearAllControl();
        btnMainBack.Visible = false;
    }

    /// <summary>
    /// Button Add new click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnAddNew_Click(object sender, EventArgs e)
    {
        if (((Button)sender).ID == "btnAdd")
        {
            Session["ERPageSize"] = ddlPage.SelectedValue;
            Session["ERCurrentPage"] = gvSearch.PageIndex;
            Session["ERSortExp"] = ViewState["SortExp"];
            Session["ERSortDirection"] = ViewState["sortDirection"];
        }
        Response.Redirect(AppConfig.SiteURL + "ExecutiveRisk/ExecutiveRisk.aspx?op=1");
    }

    #endregion

    #region Grid Event

    /// <summary>
    /// Gridview Sorting Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvSearch_Sorting(object sender, GridViewSortEventArgs e)
    {
        lstEmpSearch = new List<RIMS_Base.CEmployeeSearch>();
        if (ViewState["sortDirection"] == null)
            ViewState["sortDirection"] = SortDirection.Descending;
        else
        {
            if (((SortDirection)ViewState["sortDirection"]) == SortDirection.Ascending)
                ViewState["sortDirection"] = SortDirection.Descending;
            else
                ViewState["sortDirection"] = SortDirection.Ascending;
        }
        ViewState["SortExp"] = strSortExp = e.SortExpression;

        lstEmpSearch = GetEmployeeSearch();
        if (ViewState["SortExp"] != null)
            lstEmpSearch.Sort(new RIMS_Base.GenericComparer<RIMS_Base.CEmployeeSearch>((string)ViewState["SortExp"], (SortDirection)ViewState["sortDirection"]));
        gvSearch.DataSource = lstEmpSearch;
        gvSearch.DataBind();
    }

    /// <summary>
    /// Gridview page Index changing
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvSearch_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvSearch.PageIndex = e.NewPageIndex;
        GeneralSorting();
    }

    /// <summary>
    /// Gridview Row Databound Event - Search
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvSearch_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
         
            if (((Label)e.Row.FindControl("lblClaimTypeID")).Text == "1")
                ((Label)e.Row.FindControl("lblClaimType")).Text = "Auto Liability";
            else if (((Label)e.Row.FindControl("lblClaimTypeID")).Text == "2")
                ((Label)e.Row.FindControl("lblClaimType")).Text = "General Liability";
            else if (((Label)e.Row.FindControl("lblClaimTypeID")).Text == "3")
                ((Label)e.Row.FindControl("lblClaimType")).Text = "Workers Comp";
            else if (((Label)e.Row.FindControl("lblClaimTypeID")).Text == "4")
                ((Label)e.Row.FindControl("lblClaimType")).Text = "Property Loss";
            else if (((Label)e.Row.FindControl("lblClaimTypeID")).Text == "5")
                ((Label)e.Row.FindControl("lblClaimType")).Text = "Executive Risk";

            string CommandArg = ((Label)e.Row.FindControl("lblPrimaryID")).Text + ',' + ((Label)e.Row.FindControl("lblClaimType")).Text;
            ((Button)e.Row.FindControl("btnEdit")).CommandArgument = CommandArg;
            ((Button)e.Row.FindControl("btnView")).CommandArgument = CommandArg;
            ((Button)e.Row.FindControl("btnDelete")).CommandArgument = CommandArg;
            ((Button)e.Row.FindControl("btnAddTo")).CommandArgument = CommandArg;
            ((Button)e.Row.FindControl("btnDelete")).Attributes.Add("onclick", "javascript:return confirm('Are you sure you want to delete the record?\\n Claim cannot be deleted if there exists any non-printed checks');");
            
        }
    }

    /// <summary>
    /// Gridview RowCreated Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvSearch_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            if (String.Empty != strSortExp)
            {
                AddSortImage(e.Row);
            }
            else
            {
                Image sortImage = new Image();
                sortImage.ImageUrl = "~/Images/up-arrow.gif";
                sortImage.AlternateText = "Descending Order";
                e.Row.Cells[1].Controls.Add(sortImage);
            }
        }
    }

    /// <summary>
    /// Gridview Row Command Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvSearch_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "EditItem")
        {
            string[] ArrayList = e.CommandArgument.ToString().Split(',');
            Session["WorkerCompID"] = ArrayList[0].ToString();
            Session["ViewAll"] = null;
            Session["Edit"] = "Edit";
            switch (ArrayList[1].ToString())
            {

                case "Executive Risk":
                    {
                        Session["ERPageSize"] = ddlPage.SelectedValue;
                        Session["ERCurrentPage"] = gvSearch.PageIndex;
                        Session["ERSortExp"] = ViewState["SortExp"];
                        Session["ERSortDirection"] = ViewState["sortDirection"];

                        clsSession.Current_Executive_Risk_ID = Executive_Risk.SelectPKBy_ClaimID(Convert.ToInt32(Session["WorkerCompID"]));
                        clsSession.Str_Executive_Operation = "edit";
                        Response.Redirect("../ExecutiveRisk/ExecutiveRisk.aspx?id=" + clsSession.Current_Executive_Risk_ID);                        
                        
                    }
                    break;
            }
        }
        else if (e.CommandName == "View")
        {
            string[] ArrayList = e.CommandArgument.ToString().Split(',');
            Session["WorkerCompID"] = ArrayList[0].ToString();
            Session["Edit"] = null;
            Session["ViewAll"] = "View";
            switch (ArrayList[1].ToString())
            {
                case "Executive Risk":
                    {
                        Session["ERPageSize"] = ddlPage.SelectedValue;
                        Session["ERCurrentPage"] = gvSearch.PageIndex;
                        Session["ERSortExp"] = ViewState["SortExp"];
                        Session["ERSortDirection"] = ViewState["sortDirection"];
                        clsSession.Current_Executive_Risk_ID = Executive_Risk.SelectPKBy_ClaimID(Convert.ToInt32(Session["WorkerCompID"]));
                        clsSession.Str_Executive_Operation = "view";
                        Response.Redirect("../ExecutiveRisk/ExecutiveRisk.aspx?id=" + clsSession.Current_Executive_Risk_ID);
                        
                    }
                    break;
            }
        }
        else if (e.CommandName == "AddTo")
        {
            string[] ArrayList = e.CommandArgument.ToString().Split(',');
            Session["WorkerCompID"] = ArrayList[0].ToString();
            Session["Edit"] = null;
            Session["ViewAll"] = null;
            Session["AddTo"] = "Addto";
            switch (ArrayList[1].ToString())
            {
                case "Executive Risk":
                    {
                        Session["ERPageSize"] = ddlPage.SelectedValue;
                        Session["ERCurrentPage"] = gvSearch.PageIndex;
                        Session["ERSortExp"] = ViewState["SortExp"];
                        Session["ERSortDirection"] = ViewState["sortDirection"];
                        clsSession.Current_Executive_Risk_ID = Executive_Risk.SelectPKBy_ClaimID(Convert.ToInt32(Session["WorkerCompID"]));
                        clsSession.Str_Executive_Operation = "edit";
                        Response.Redirect("ExecutiveRisk.aspx?id=" + clsSession.Current_Executive_Risk_ID + "&Claim=AddTo");

                    }

                    break;
            }
        }
        else if (e.CommandName == "Delete")
        {
            try
            {

                string[] ArrayList = e.CommandArgument.ToString().Split(',');

                if (ArrayList[1].ToString() == "Executive Risk")
                {

                    int PK_Exec_Risk = Executive_Risk.SelectPKBy_ClaimID(Convert.ToInt32(ArrayList[0]));
                    Executive_Risk.DeleteByPK(Convert.ToDecimal(PK_Exec_Risk));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

    /// <summary>
    /// Gridview Rowdeleting Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public void gvSearch_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        e.Cancel = false;
        GeneralSorting();
        if (txtPageNo.Text.ToString().Trim() == string.Empty || Convert.ToInt32(txtPageNo.Text) < 1)
        {
            gvSearch.PageIndex = 0;
            txtPageNo.Text = "1";
        }
        else if (Convert.ToInt32(txtPageNo.Text) >= gvSearch.PageCount)
        {
            gvSearch.PageIndex = gvSearch.PageCount;
            txtPageNo.Text = gvSearch.PageCount.ToString();
            btnNext.Enabled = false;
            btnPrev.Enabled = true;
        }
        else
        {
            gvSearch.PageIndex = Convert.ToInt32(txtPageNo.Text) - 1;
            btnNext.Enabled = true;
        }

        btnPrev.Enabled = Convert.ToInt32(txtPageNo.Text) > 1;
        lblPageInfo.Text = "Page " + txtPageNo.Text.ToString() + " of " + gvSearch.PageCount.ToString();
    }

    #endregion

    #region Search Process

    /// <summary>
    /// BUtton Searck Click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        BindGrid();
    }

    /// <summary>
    /// Dropdown page selected index changed
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ddlPage_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            gvSearch.PageIndex = 0;
            gvSearch.PageSize = Convert.ToInt32(ddlPage.SelectedValue);

            GeneralSorting();

            lblPageInfo.Text = "Page 1 of " + gvSearch.PageCount.ToString();
            txtPageNo.Text = "1";
            btnPrev.Enabled = false;
            btnNext.Enabled = true;
            if ((gvSearch.PageSize >= gvSearch.Rows.Count) && gvSearch.PageCount == 1)
            {
                btnPrev.Enabled = false;
                btnNext.Enabled = false;
            }
            divSearch.Style["display"] = "none";
            divSearchpaging.Style["display"] = "block";
            divGrid.Style["display"] = "block";
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
                gvSearch.PageIndex = 0;
                txtPageNo.Text = "1";
            }
            else if (Convert.ToInt32(txtPageNo.Text) >= gvSearch.PageCount)
            {
                gvSearch.PageIndex = gvSearch.PageCount;
                txtPageNo.Text = gvSearch.PageCount.ToString();
                btnNext.Enabled = false;
                btnPrev.Enabled = true;
            }
            else
            {
                gvSearch.PageIndex = Convert.ToInt32(txtPageNo.Text) - 1;
                btnNext.Enabled = true;
            }

            btnPrev.Enabled = Convert.ToInt32(txtPageNo.Text) > 1;
            lblPageInfo.Text = "Page " + txtPageNo.Text.ToString() + " of " + gvSearch.PageCount.ToString();
            gvSearch.DataSource = GetEmployeeSearch();
            gvSearch.DataBind();

            divSearch.Style["display"] = "none";
            divSearchpaging.Style["display"] = "block";
            divGrid.Style["display"] = "block";
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }

    /// <summary>
    /// Button Previous Click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnPrev_Click(object sender, EventArgs e)
    {
        try
        {
            if (gvSearch.PageIndex <= gvSearch.PageCount)
            {
                gvSearch.PageIndex = gvSearch.PageIndex - 1;
                GeneralSorting();

                if (gvSearch.PageIndex == 0)
                {
                    btnPrev.Enabled = false;
                    btnNext.Enabled = true;
                }
                else
                {
                    btnNext.Enabled = true;
                }

                lblPageInfo.Text = "Page " + Convert.ToString(gvSearch.PageIndex + 1) + " of " + gvSearch.PageCount.ToString();
                txtPageNo.Text = Convert.ToString(gvSearch.PageIndex + 1).ToString();
            }

            divSearch.Style["display"] = "none";
            divSearchpaging.Style["display"] = "block";
            divGrid.Style["display"] = "block";
        }
        catch (Exception ex)
        {
        }
    }

    /// <summary>
    /// BUtton Next Clcik Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnNext_Click(object sender, EventArgs e)
    {
        try
        {
            if (gvSearch.PageIndex <= gvSearch.PageCount)
            {
                gvSearch.PageIndex = gvSearch.PageIndex + 1;
                if (gvSearch.PageIndex + 1 >= gvSearch.PageCount)
                {
                    btnNext.Enabled = false;
                    btnPrev.Enabled = true;
                }
                else
                {
                    btnNext.Enabled = true;
                    btnPrev.Enabled = true;
                }
                GeneralSorting();

                //gvSearch.DataSource = BindSubrogationDetails();
                //gvSearch.DataBind();
                lblPageInfo.Text = "Page " + Convert.ToString(gvSearch.PageIndex + 1) + " of " + gvSearch.PageCount.ToString();
                txtPageNo.Text = Convert.ToString(gvSearch.PageIndex + 1).ToString();

            }

            divSearch.Style["display"] = "none";
            divSearchpaging.Style["display"] = "block";
            divGrid.Style["display"] = "block";
        }
        catch (Exception ex)
        {
        }
    }

    #endregion

    #region "Methods"

    /// <summary>
    /// method to Bind Grid
    /// </summary>
    private void BindGrid()
    {
        gvSearch.PageSize = Convert.ToInt32(ddlPage.SelectedValue);
        gvSearch.PageIndex = 0;
        ViewState["sortDirection"] = SortDirection.Descending;
        ViewState["SortExp"] = "Claim_Number";
        divGrid.Style["display"] = "block";
        divSearch.Style["display"] = "none";
        divSearchpaging.Style["display"] = "block";

        objEmpSearch = new RIMS_Base.Biz.CEmployeeSearch();
        lstEmpSearch = new List<RIMS_Base.CEmployeeSearch>();
        lstEmpSearch = GetEmployeeSearch();

        if (ViewState["SortExp"] != null)
            lstEmpSearch.Sort(new RIMS_Base.GenericComparer<RIMS_Base.CEmployeeSearch>((string)ViewState["SortExp"], (SortDirection)ViewState["sortDirection"]));

        gvSearch.DataSource = lstEmpSearch;
        gvSearch.DataBind();
        lblPageInfo.Text = "Page 1 of " + gvSearch.PageCount.ToString();

        lblBankDetailsTotal.Text = Convert.ToString(lstEmpSearch.Count);

        btnPrev.Enabled = false;
        btnNext.Enabled = false;
        txtPageNo.Text = "1";

        if (Convert.ToInt32(txtPageNo.Text) >= gvSearch.PageCount)
        {
            txtPageNo.Text = gvSearch.PageCount.ToString();
            btnNext.Enabled = false;
        }
        else
        {
            btnNext.Enabled = true;
        }

        if (Convert.ToInt32(txtPageNo.Text) > 1)
        {
            btnPrev.Enabled = true;
        }
        btnMainBack.Visible = true;
    }

    /// <summary>
    /// Method -get Employee Search
    /// </summary>
    /// <returns></returns>
    private List<RIMS_Base.CEmployeeSearch> GetEmployeeSearch()
    {
        lstEmpSearch = new List<RIMS_Base.CEmployeeSearch>();
        objEmpSearch = new RIMS_Base.Biz.CEmployeeSearch();

        objEmpSearch.TableName = "";

        if (ddlEntity.SelectedIndex != 0)
            objEmpSearch.FK_Entity = Convert.ToInt32(ddlEntity.SelectedItem.Value);
        else
        {
            if (ddlRMLocationNumber.SelectedIndex != 0)
                objEmpSearch.FK_Entity = Convert.ToInt32(ddlRMLocationNumber.SelectedValue);
        }

        objEmpSearch.Social_Security_Number = "";

        objEmpSearch.ExecutiveRisk = "Executive_Risk";
        txtClaimNo.Text = txtClaimNo.Text.ToString().Replace("__-_____-__", "");

        objEmpSearch.Claim_Number = txtClaimNo.Text.ToString().Replace("__-_____-__", "");


        objEmpSearch.PK_Employee_ID = 0;

        if (txtOCFrom.Text != String.Empty)
        {
            string Month = Convert.ToDateTime(txtOCFrom.Text).Month.ToString();
            string Date = Convert.ToDateTime(txtOCFrom.Text).Day.ToString();
            string Year = Convert.ToDateTime(txtOCFrom.Text).Year.ToString();

            if (Month.Length == 1)
                Month = "0" + Month;
            if (Date.Length == 1)
                Date = "0" + Date;
            string FinalDate = Month + "/" + Date + "/" + Year;
            objEmpSearch.DateOfLossFrom = FinalDate;
        }
        if (txtOCTo.Text != String.Empty)
        {
            string Month = Convert.ToDateTime(txtOCTo.Text).Month.ToString();
            string Date = Convert.ToDateTime(txtOCTo.Text).Day.ToString();
            string Year = Convert.ToDateTime(txtOCTo.Text).Year.ToString();

            if (Month.Length == 1)
                Month = "0" + Month;
            if (Date.Length == 1)
                Date = "0" + Date;
            string FinalDate = Month + "/" + Date + "/" + Year;
            objEmpSearch.DateOfLossTo = FinalDate;
        }

        if (rbtnOCFrom.Items[0].Selected == true)
            objEmpSearch.ClaimStatus = 1;
        else if (rbtnOCFrom.Items[1].Selected == true)
            objEmpSearch.ClaimStatus = 2;
        else if (rbtnOCFrom.Items[2].Selected == true)
            objEmpSearch.ClaimStatus = 3;

        if (ddlExecutiveRisk.SelectedIndex != 0)
            objEmpSearch.FK_Risk_Type = Convert.ToInt32(ddlExecutiveRisk.SelectedItem.Value);

        Session["EmployeeSearch"] = objEmpSearch;
        lstEmpSearch = objEmpSearch.GetAll(objEmpSearch, Convert.ToDecimal(clsSession.UserID));

        return lstEmpSearch;
    }

    /// <summary>
    /// Bind Combos
    /// </summary>
    private void BindCombos()
    {
        //used to fill RM Location Number Dropdown
        ComboHelper.FillLocationdba(new DropDownList[] { ddlRMLocationNumber }, 0, true);
        ddlRMLocationNumber.Style.Remove("font-size");
        //used to fill Legal Entity Dropdown
        ComboHelper.FillLocationLegal_Entity(new DropDownList[] { ddlLegalEntity }, 0, true);
        //used to fill dba Dropdown
        ComboHelper.FillLocationdbaOnly(new DropDownList[] { ddlLocationdba }, 0, true);
        ddlLocationdba.Style.Remove("font-size");
        //objGeneral= new RIMS_Base.Biz.CGeneral();
        //lstGeneral = new List<RIMS_Base.CGeneral>();
        //lstGeneral= objGeneral.GetAllEntity();
        DataTable dtEntity = Entity.SelectForExecutiveRisk().Tables[0];
        ddlEntity.DataSource = dtEntity;
        ddlEntity.DataTextField = "Entity";
        ddlEntity.DataValueField = "PK_LU_Location_ID";
        ddlEntity.DataBind();
        ddlEntity.Items.Insert(0, new ListItem("--Select Entity--", "0"));

        // Binds the type dropdown
        DataTable dtType = Type_Of_ER_Claim.SelectAll().Tables[0];
        ddlExecutiveRisk.DataSource = dtType;
        ddlExecutiveRisk.DataTextField = "Fld_Desc";
        ddlExecutiveRisk.DataValueField = "PK_Type_Of_ER_Claim";
        ddlExecutiveRisk.DataBind();
        ddlExecutiveRisk.Items.Insert(0, "--Select Type of Claim--");
    }

    /// <summary>
    /// Show Search From Session
    /// </summary>
    private void ShowSearchFromSession()
    {
        divGrid.Style["display"] = "block";
        divSearch.Style["display"] = "none";
        divSearchpaging.Style["display"] = "block";

        objEmpSearch = new RIMS_Base.Biz.CEmployeeSearch();
        lstEmpSearch = new List<RIMS_Base.CEmployeeSearch>();
        lstEmpSearch = objEmpSearch.GetAll(((RIMS_Base.Biz.CEmployeeSearch)(Session["EmployeeSearch"])), Convert.ToDecimal(clsSession.UserID));

        gvSearch.PageSize = (clsGeneral.IsNull(Session["ERPageSize"]) ? 10 : Convert.ToInt32(Session["ERPageSize"]));
        gvSearch.PageIndex = clsGeneral.IsNull(Session["ERCurrentPage"]) ? 0 : Convert.ToInt32(Session["ERCurrentPage"]);

        if (Session["ERSortExp"] != null && Session["ERSortDirection"] != null)
        {
            ViewState["SortExp"] = Session["ERSortExp"];
            ViewState["sortDirection"] = Session["ERSortDirection"];
            lstEmpSearch.Sort(new RIMS_Base.GenericComparer<RIMS_Base.CEmployeeSearch>((string)ViewState["SortExp"], (SortDirection)ViewState["sortDirection"]));
        }
        else
        {
            ViewState["sortDirection"] = SortDirection.Descending;
            ViewState["SortExp"] = "Claim_Number";
        }

        strSortExp = clsGeneral.IsNull(ViewState["SortExp"]) ? string.Empty : Convert.ToString(ViewState["SortExp"]);
        gvSearch.DataSource = lstEmpSearch;
        gvSearch.DataBind();

        lblPageInfo.Text = "Page " + (gvSearch.PageIndex + 1).ToString() + " of " + gvSearch.PageCount.ToString();
        btnMainBack.Visible = true;

        btnPrev.Enabled = false;
        btnNext.Enabled = false;

        txtPageNo.Text = (gvSearch.PageIndex + 1).ToString();
        btnPrev.Enabled = (Convert.ToInt32(txtPageNo.Text) > 1);

        if (Convert.ToInt32(txtPageNo.Text) >= gvSearch.PageCount)
        {
            txtPageNo.Text = gvSearch.PageCount.ToString();
            btnNext.Enabled = false;
        }
        else
            btnNext.Enabled = true;

        ddlPage.ClearSelection();
        ListItem li = ddlPage.Items.FindByText(Session["ERPageSize"].ToString());

        if (li != null)
        {
            li.Selected = true;
        }
    }

    /// <summary>
    /// Clear All Controls
    /// </summary>
    private void ClearAllControl()
    {

        rbtnOCFrom.Items[0].Selected = false;
        rbtnOCFrom.Items[1].Selected = false;
        rbtnOCFrom.Items[2].Selected = false;
        txtClaimNo.Text = "";
        txtOCFrom.Text = "";
        txtOCTo.Text = "";
        ddlRMLocationNumber.SelectedIndex = 0;
        ddlLegalEntity.SelectedIndex = 0;
        ddlLocationdba.SelectedIndex = 0;
        ddlEntity.SelectedIndex = 0;
        ddlPage.SelectedValue = "10";
        Session.Remove("EmployeeSearch");
        Session.Remove("ERPageSize");
        Session.Remove("ERPageSize");
        Session.Remove("ERCurrentPage");
        Session.Remove("ERSortExp");
        Session.Remove("ERSortDirection");
        ddlExecutiveRisk.SelectedIndex = 0;
        ViewState.Remove("sortDirection");
        ViewState.Remove("SortExp");
    }

    /// <summary>
    /// General Sorting
    /// </summary>
    private void GeneralSorting()
    {
        try
        {
            lstEmpSearch = new List<RIMS_Base.CEmployeeSearch>();
            lstEmpSearch = GetEmployeeSearch();
            if (ViewState["SortExp"] != null && ViewState["sortDirection"] != null)
            {
                lstEmpSearch.Sort(new RIMS_Base.GenericComparer<RIMS_Base.CEmployeeSearch>((string)ViewState["SortExp"], (SortDirection)ViewState["sortDirection"]));
                strSortExp = ViewState["SortExp"].ToString();
            }
            gvSearch.DataSource = lstEmpSearch;
            gvSearch.DataBind();

        }
        catch (Exception ex)
        {
            throw ex;
        }

    }

    /// <summary>
    /// Get Sort Column Index
    /// </summary>
    /// <param name="strSortExp"></param>
    /// <returns></returns>
    private int GetSortColumnIndex(string strSortExp)
    {
        int nRet = 0;
        // Iterate through the Columns collection to determine the index
        // of the column being sorted.
        foreach (DataControlField field in gvSearch.Columns)
        {
            if (field.SortExpression.ToString() == ViewState["SortExp"].ToString())
            {
                nRet = gvSearch.Columns.IndexOf(field);
            }
        }
        return nRet;
    }

    /// <summary>
    /// Add Sort Image
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

    #endregion

    #region "Selected Index Change Evnet"

    /// <summary>
    /// Handles event when RM location number dropdown selection changed
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ddlRMLocationNumber_SelectedIndexChanged(object sender, EventArgs e)
    {
        // update all other dropdown according to RM location number selected
        ddlLegalEntity.SelectedValue = ddlRMLocationNumber.SelectedValue;
        ddlLocationdba.SelectedValue = ddlRMLocationNumber.SelectedValue;
        ListItem lstItm = ddlEntity.Items.FindByValue(ddlLocationdba.SelectedValue);
        if (lstItm != null)
            ddlEntity.SelectedValue = ddlRMLocationNumber.SelectedValue;
        else
            ddlEntity.SelectedValue = "0";
    }

    /// <summary>
    /// Handles event when Leagal entity dropdown selection changed
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ddlLegalEntity_SelectedIndexChanged(object sender, EventArgs e)
    {
        // update all other dropdown according to entity selected
        ddlRMLocationNumber.SelectedValue = ddlLegalEntity.SelectedValue;
        ddlLocationdba.SelectedValue = ddlLegalEntity.SelectedValue;
        ddlEntity.SelectedValue = ddlRMLocationNumber.SelectedValue;
    }

    /// <summary>
    /// Handles event when dba dropdown selection changed
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ddlLocationdba_SelectedIndexChanged(object sender, EventArgs e)
    {
        // update all other dropdown according to dba selected
        ddlRMLocationNumber.SelectedValue = ddlLocationdba.SelectedValue;
        ddlLegalEntity.SelectedValue = ddlLocationdba.SelectedValue;
        ddlEntity.SelectedValue = ddlRMLocationNumber.SelectedValue;
    }

    /// <summary>
    /// Dropdown Selected Index Change
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ddlEntity_SelectedIndexChanged(object sender, EventArgs e)
    {
        // update all other dropdown according to dba selected
        ddlRMLocationNumber.SelectedValue = ddlEntity.SelectedValue;
        ddlLegalEntity.SelectedValue = ddlEntity.SelectedValue;
        ddlLocationdba.SelectedValue = ddlEntity.SelectedValue;
    }

    #endregion
}


