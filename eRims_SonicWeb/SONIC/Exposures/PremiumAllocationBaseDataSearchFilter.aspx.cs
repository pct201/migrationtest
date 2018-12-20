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
//using ERIMS_DAL;


public partial class SONIC_Exposures_PremiumAllocationBaseDataSearchFilter : clsBasePage
{
    #region "Properties"
    public int CurrentPage
    {
        get { return Convert.ToInt32(ViewState["CurrentPage"]); }
        set { ViewState["CurrentPage"] = value; }
    }
    public int PageSize
    {
        get { return Convert.ToInt32(ViewState["PageSize"]); }
        set { ViewState["PageSize"] = value; }
    }

    public string StrOperation
    {
        get { return Convert.ToString(ViewState["strOperation"]); }
        set { ViewState["strOperation"] = value; }
    }

    public decimal PK_PA_Values_Imported
    {
        get { return Convert.ToDecimal(ViewState["PK_PA_Values_Imported"]); }
        set { ViewState["PK_PA_Values_Imported"] = value; }
    }
    
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        //check Page is Postback or not
        if (!IsPostBack)
        {
            decimal i = 0;

            pnlSearchResult.Visible = false;
            pnlSearch.Visible = true;

            if(PK_PA_Values_Imported !=  null )
                i = PK_PA_Values_Imported;

            DataSet ds = LU_Location.SelectSonicLocationCode();
            ddlRMLocationNumber.DataSource = ds.Tables[0];
            ddlRMLocationNumber.DataTextField = "code";
            ddlRMLocationNumber.DataValueField = "Sonic_Location_Code";
            ddlRMLocationNumber.DataBind();
            ddlRMLocationNumber.Items.Insert(0, "--SELECT--");

            //used to fill RM Location Number Dropdown

            DataSet ds1 = LU_Location.SelectSonicLocationDBA();
            ddlLocationdba.DataSource = ds1.Tables[0];
            ddlLocationdba.DataTextField = "dba";
            ddlLocationdba.DataValueField = "Sonic_Location_Code";
            ddlLocationdba.DataBind();
            ddlLocationdba.Items.Insert(0, "--SELECT--");

            //used to fill fka dropdown
        }
    }

    /// <summary>
    /// Handles Search button click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        ViewState["CurrentPageSearch"] = 1;
        ViewState["PageSizeSearch"] = 10;
        pnlSearchResult.Visible = true;
        pnlSearch.Visible = false;
        BindGrid();
    }

    /// <summary>
    /// Handles event when RM location number dropdown selection changed
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ddlRMLocationNumber_SelectedIndexChanged(object sender, EventArgs e)
    {
        // update all other dropdown according to RM location number selected
        ddlLocationdba.SelectedValue = ddlRMLocationNumber.SelectedValue;
        ddlLocationdba.Enabled = false;
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
        ddlRMLocationNumber.Enabled = false;
    }

    protected void ctrlPageSonicNotes_GetPage()
    {
        BindGrid();
        Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(" + 2 + ");", true);

    }

    private void BindGrid()
    {
        clsPA_Values_Imported objPA_Values_Imported = new clsPA_Values_Imported();
        if (ddlRMLocationNumber.SelectedIndex > 0)
            objPA_Values_Imported.Sonic_Location_Code = Convert.ToInt32(ddlRMLocationNumber.SelectedValue);
        if(!string.IsNullOrEmpty(txtYear.Text))
            objPA_Values_Imported.Year = Convert.ToInt32(txtYear.Text);

        if (ViewState["CurrentPageSearch"] != null)
            CurrentPage = Convert.ToInt32(ViewState["CurrentPageSearch"]);
        else
            CurrentPage = ctrlPageSonicNotes.CurrentPage;

        if(ViewState["PageSizeSearch"] != null)
            PageSize = Convert.ToInt32(ViewState["PageSizeSearch"]);
        else
            PageSize = ctrlPageSonicNotes.PageSize;
        DataSet ds = clsPA_Values_Imported.SelectBySearchCriteria(Convert.ToInt32(objPA_Values_Imported.Sonic_Location_Code), Convert.ToInt32(objPA_Values_Imported.Year), CurrentPage, PageSize);
        DataTable dtNotes = ds.Tables[0];
        if (dtNotes.Rows.Count == 0)
        {
            gvNotes.DataBind();         
        }
        ctrlPageSonicNotes.TotalRecords = (ds.Tables.Count >= 2) ? Convert.ToInt32(ds.Tables[1].Rows[0][0]) : 0;
        ctrlPageSonicNotes.CurrentPage = (ds.Tables.Count >= 2) ? Convert.ToInt32(ds.Tables[1].Rows[0][2]) : 0;
        ctrlPageSonicNotes.RecordsToBeDisplayed = ds.Tables[0].Rows.Count;
        ctrlPageSonicNotes.SetPageNumbers();
                
        gvNotes.DataSource = dtNotes;
        gvNotes.DataBind();

        lblNumber.Text = (ds.Tables.Count >= 2) ? Convert.ToString(ds.Tables[1].Rows[0][0]) + " Sonic Locations Found" : "0" + " Sonic Locations Found";

        ViewState["CurrentPageSearch"] = null;
        ViewState["PageSizeSearch"] = null;
    }

    /// <summary>
    /// Handles event when fka dropdown selection changed
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>

    protected void btnNotesAdd_Click(object sender, EventArgs e)
    {
        
    }
    protected void gvNotes_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "EditRecord")
        {
            pnlEdit.Visible = true;
            pnlView.Visible = false;
            pnlSearchResult.Visible = false;
            pnlSearch.Visible = false;

            string arg = string.Empty;            
            arg = e.CommandArgument.ToString();

            PK_PA_Values_Imported = Convert.ToInt32(arg);

            btnHiddenView.Value = Convert.ToString(PK_PA_Values_Imported);

            clsPA_Values_Imported objPA_Values_Imported = new clsPA_Values_Imported(Convert.ToInt32(arg));

            if (objPA_Values_Imported.Sonic_Location_Code != null)
                lblSonicLocationCode.Text = Convert.ToString(objPA_Values_Imported.Sonic_Location_Code);
            
            if (objPA_Values_Imported.SonicLocationdba != null)
                lblSonicLocationdba.Text = Convert.ToString(objPA_Values_Imported.SonicLocationdba);
            
            if (objPA_Values_Imported.Texas_Payroll != null)
                txtTexasPayroll.Text = clsGeneral.FormatCommaSeperatorCurrency(objPA_Values_Imported.Texas_Payroll);
            
            if (objPA_Values_Imported.Non_Texas_Payroll != null)
                txtNonTexasPayroll.Text = clsGeneral.FormatCommaSeperatorCurrency(objPA_Values_Imported.Non_Texas_Payroll);
            
            if (objPA_Values_Imported.Number_Of_Employees != null)
                txtTotalHeadcount.Text = Convert.ToString(objPA_Values_Imported.Number_Of_Employees);
            
            if (objPA_Values_Imported.Year != null)
                txtYear1.Text = Convert.ToString(objPA_Values_Imported.Year);
            
        }
        else if (e.CommandName == "ViewRecord")
        {
            pnlEdit.Visible = false;
            pnlView.Visible = true;
            pnlSearchResult.Visible = false;
            pnlSearch.Visible = false;

            string arg = string.Empty;            
            arg = e.CommandArgument.ToString();

            btnHiddenView.Value = Convert.ToString(PK_PA_Values_Imported);

            PK_PA_Values_Imported = Convert.ToInt32(arg);

            clsPA_Values_Imported objPA_Values_Imported = new clsPA_Values_Imported(Convert.ToInt32(arg));

            if (objPA_Values_Imported.Sonic_Location_Code != null)
                lblSonicLocationCodeView.Text = Convert.ToString(objPA_Values_Imported.Sonic_Location_Code);
            else
                lblSonicLocationCodeView.Text = "";

            if (objPA_Values_Imported.SonicLocationdba != null)
                lblSonicLocationDBAView.Text = Convert.ToString(objPA_Values_Imported.SonicLocationdba);
            else
                lblSonicLocationDBAView.Text = "";

            if (objPA_Values_Imported.Texas_Payroll != null)
                lblTexasPayrollView.Text = clsGeneral.FormatCommaSeperatorCurrency(objPA_Values_Imported.Texas_Payroll);
            else
                lblTexasPayrollView.Text = "";

            if (objPA_Values_Imported.Non_Texas_Payroll != null)
                lblNonTexasPayrollView.Text = clsGeneral.FormatCommaSeperatorCurrency(objPA_Values_Imported.Non_Texas_Payroll);
            else
                lblNonTexasPayrollView.Text = "";

            if (objPA_Values_Imported.Number_Of_Employees != null)
                lblTotalHeadcountView.Text = Convert.ToString(objPA_Values_Imported.Number_Of_Employees);
            else
                lblTotalHeadcountView.Text = "";

            if (objPA_Values_Imported.Year != null)
                lblYearView.Text = Convert.ToString(objPA_Values_Imported.Year);
            else
                lblYearView.Text = "";
        }
    }
    protected void btnSearchAgain_Click(object sender, EventArgs e)
    {
        ddlLocationdba.SelectedIndex = 0;
        ddlRMLocationNumber.SelectedIndex = 0;
        txtYear.Text = "";
        pnlSearchResult.Visible = false;
        pnlSearch.Visible = true;
        ddlRMLocationNumber.Enabled = true;
        ddlLocationdba.Enabled = true;
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {        
        pnlSearchResult.Visible = true;
        pnlSearch.Visible = false;
        pnlEdit.Visible = false;
        
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        btnHiddenView.Value = Convert.ToString(PK_PA_Values_Imported);

        clsPA_Values_Imported objPA_Values_Imported = new clsPA_Values_Imported();
        objPA_Values_Imported.PK_PA_Values_Imported = PK_PA_Values_Imported;

        if (!string.IsNullOrEmpty(txtTexasPayroll.Text))
            objPA_Values_Imported.Texas_Payroll = Convert.ToDecimal(txtTexasPayroll.Text);

        if (!string.IsNullOrEmpty(txtNonTexasPayroll.Text))
            objPA_Values_Imported.Non_Texas_Payroll = Convert.ToDecimal(txtNonTexasPayroll.Text);

        if (!string.IsNullOrEmpty(txtTotalHeadcount.Text))
            objPA_Values_Imported.Number_Of_Employees = Convert.ToInt32(txtTotalHeadcount.Text);

        if (!string.IsNullOrEmpty(txtYear1.Text))
            objPA_Values_Imported.Year = Convert.ToInt32(txtYear1.Text);

        objPA_Values_Imported.Update_Date = DateTime.Now;
        objPA_Values_Imported.Updated_By = clsSession.UserID;


         int i = 0;
        if (PK_PA_Values_Imported > 0)
             i = objPA_Values_Imported.Update();
        if (i == -1)
        {
            pnlEdit.Visible = false;
            pnlView.Visible = true;
            pnlSearchResult.Visible = false;
            pnlSearch.Visible = false;

            clsPA_Values_Imported objPA_Values_ImportedView = new clsPA_Values_Imported(PK_PA_Values_Imported);
            objPA_Values_ImportedView.PK_PA_Values_Imported = PK_PA_Values_Imported;

            lblSonicLocationCodeView.Text = Convert.ToString(objPA_Values_ImportedView.Sonic_Location_Code);
            lblSonicLocationDBAView.Text = Convert.ToString(objPA_Values_ImportedView.SonicLocationdba);
            lblYearView.Text = Convert.ToString(objPA_Values_ImportedView.Year);
            lblTotalHeadcountView.Text = Convert.ToString(objPA_Values_ImportedView.Number_Of_Employees);
            lblTexasPayrollView.Text = clsGeneral.FormatCommaSeperatorCurrency(objPA_Values_ImportedView.Texas_Payroll);
            lblNonTexasPayrollView.Text = clsGeneral.FormatCommaSeperatorCurrency(objPA_Values_ImportedView.Non_Texas_Payroll);

        }

        BindGrid();
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        clsPA_Values_Imported objPA_Values_Imported = new clsPA_Values_Imported(PK_PA_Values_Imported);

        if (objPA_Values_Imported.Sonic_Location_Code != null)
            lblSonicLocationCode.Text = Convert.ToString(objPA_Values_Imported.Sonic_Location_Code);
      

        if (objPA_Values_Imported.SonicLocationdba != null)
            lblSonicLocationdba.Text = Convert.ToString(objPA_Values_Imported.SonicLocationdba);
       

        if (objPA_Values_Imported.Texas_Payroll != null)
            txtTexasPayroll.Text = clsGeneral.FormatCommaSeperatorCurrency(objPA_Values_Imported.Texas_Payroll);
       
        if (objPA_Values_Imported.Non_Texas_Payroll != null)
            txtNonTexasPayroll.Text = clsGeneral.FormatCommaSeperatorCurrency(objPA_Values_Imported.Non_Texas_Payroll);
       
        if (objPA_Values_Imported.Number_Of_Employees != null)
            txtTotalHeadcount.Text = Convert.ToString(objPA_Values_Imported.Number_Of_Employees);
       

        if (objPA_Values_Imported.Year != null)
            txtYear1.Text = Convert.ToString(objPA_Values_Imported.Year);
      
        pnlView.Visible = false;
        pnlSearchResult.Visible = false;
        pnlSearch.Visible = false;
        pnlEdit.Visible = true;
    }
    protected void btnReturn_Click(object sender, EventArgs e)
    {
        pnlView.Visible = false;
        pnlSearchResult.Visible = true;
        pnlSearch.Visible = false;
        pnlEdit.Visible = false;
    }
    protected void btnViewAuditTrail_Click(object sender, EventArgs e)
    {
      

    }
}