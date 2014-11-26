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

public partial class EmployeeSearch : System.Web.UI.Page
{
    public RIMS_Base.Biz.CEmployeeSearch objEmpSearch;
    public List<RIMS_Base.CEmployeeSearch> lstEmpSearch;
    int EmpSearch_retVal = -1;

    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
           Session.Remove("WorkerCompID");
           Session.Remove("ViewAll");
        }

    }

    private List<RIMS_Base.CEmployeeSearch> GetEmployeeSearch()
    {
        lstEmpSearch = new List<RIMS_Base.CEmployeeSearch>();
        objEmpSearch = new RIMS_Base.Biz.CEmployeeSearch();

        if (txtDOIncident.Text != String.Empty)
        {
            string Month = Convert.ToDateTime(txtDOIncident.Text).Month.ToString();
            string Date = Convert.ToDateTime(txtDOIncident.Text).Day.ToString();
            string Year = Convert.ToDateTime(txtDOIncident.Text).Year.ToString();

            if (Month.Length == 1)
                Month = "0" + Month;
            if (Date.Length == 1)
                Date = "0" + Date;
            string FinalDate = Month + "/" + Date + "/" + Year;
            objEmpSearch.Incident_Date = FinalDate;
        }

        objEmpSearch.TableName = ddlSearch.SelectedItem.Value;
        objEmpSearch.Last_Name = txtLastName.Text;
        objEmpSearch.Middle_Name = txtMiddleName.Text;
        objEmpSearch.First_Name = txtFirstName.Text;
        objEmpSearch.Social_Security_Number = txtSSN.Text;
        //if (txtDOIncident.Text != String.Empty)
        //    objEmpSearch.Incident_Date = Convert.ToDateTime(txtDOIncident.Text);       
        if (chkLstClaimType.Items[0].Selected == true)
             objEmpSearch.WorkerComp = chkLstClaimType.Items[0].Value;        
        if (chkLstClaimType.Items[1].Selected == true)
            objEmpSearch.AutoLib = chkLstClaimType.Items[1].Value;
        if (chkLstClaimType.Items[2].Selected == true)
            objEmpSearch.GeneralLib = chkLstClaimType.Items[2].Value;
        if (chkLstClaimType.Items[3].Selected == true)
            objEmpSearch.PropertyLoss = chkLstClaimType.Items[3].Value;
        objEmpSearch.Claim_Number = txtClaimNo.Text;       
        if (txtEmpID.Text != String.Empty)
            objEmpSearch.PK_Employee_ID = Convert.ToDecimal(txtEmpID.Text);

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
            objEmpSearch.OpenClaimFrom = FinalDate;
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
            objEmpSearch.OpenClaimTo = FinalDate;
        }
        if (txtCCFrom.Text != String.Empty)
        {
            string Month = Convert.ToDateTime(txtCCFrom.Text).Month.ToString();
            string Date = Convert.ToDateTime(txtCCFrom.Text).Day.ToString();
            string Year = Convert.ToDateTime(txtCCFrom.Text).Year.ToString();

            if (Month.Length == 1)
                Month = "0" + Month;
            if (Date.Length == 1)
                Date = "0" + Date;
            string FinalDate = Month + "/" + Date + "/" + Year;
            objEmpSearch.CloseClaimFrom = FinalDate;
        }
        if (txtCCTo.Text != String.Empty)
        {
            string Month = Convert.ToDateTime(txtCCTo.Text).Month.ToString();
            string Date = Convert.ToDateTime(txtCCTo.Text).Day.ToString();
            string Year = Convert.ToDateTime(txtCCTo.Text).Year.ToString();

            if (Month.Length == 1)
                Month = "0" + Month;
            if (Date.Length == 1)
                Date = "0" + Date;
            string FinalDate = Month + "/" + Date + "/" + Year;
            objEmpSearch.CloseClaimTo = FinalDate;
        }
        lstEmpSearch = objEmpSearch.GetAll(objEmpSearch,Convert.ToDecimal(clsSession.UserID));

        return lstEmpSearch;
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        divGrid.Style["display"] = "block";
        divSearch.Style["display"] = "none";
        gvSearch.DataSource = GetEmployeeSearch();
        gvSearch.DataBind();
    }   

    #region GridEvent

    protected void btnBack_Click(object sender, EventArgs e)
    {
        divGrid.Style["display"] = "none";
        divSearch.Style["display"] = "block";
        ClearAllControl();
    }
    private void ClearAllControl()
    {
        txtFirstName.Text="";
        txtLastName.Text = "";
        txtMiddleName.Text = "";
        txtEmpID.Text = "";
        txtSSN.Text = "";
        txtDOIncident.Text = "";
        chkLstClaimType.Items[0].Selected = false;
        chkLstClaimType.Items[1].Selected = false;
        chkLstClaimType.Items[2].Selected = false;
        chkLstClaimType.Items[3].Selected = false;
        txtClaimNo.Text = "";
        txtOCFrom.Text = "";
        txtOCTo.Text = "";
        txtCCFrom.Text = "";
        txtCCTo.Text = "";

    }
    protected void gvSearch_Sorting(object sender, GridViewSortEventArgs e)
    {
        lstEmpSearch = new List<RIMS_Base.CEmployeeSearch>();
        if (ViewState["sortDirection"] == null)
            ViewState["sortDirection"] = SortDirection.Ascending;
        else
        {
            if (((SortDirection)ViewState["sortDirection"]) == SortDirection.Ascending)
                ViewState["sortDirection"] = SortDirection.Descending;
            else
                ViewState["sortDirection"] = SortDirection.Ascending;
        }
        ViewState["SortExp"] = e.SortExpression;

        lstEmpSearch = GetEmployeeSearch();
        if (ViewState["SortExp"] != null)
            lstEmpSearch.Sort(new RIMS_Base.GenericComparer<RIMS_Base.CEmployeeSearch>((string)ViewState["SortExp"], (SortDirection)ViewState["sortDirection"]));
        gvSearch.DataSource = lstEmpSearch;
        gvSearch.DataBind();
    }
    protected void gvSearch_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        if (e.NewPageIndex > gvSearch.PageIndex)
        {
            gvSearch.PageIndex = gvSearch.PageIndex + 1;
        }
        else if (e.NewPageIndex < gvSearch.PageIndex)
        {
            gvSearch.PageIndex = gvSearch.PageIndex - 1;
        }
        //gvSearch.DataSource = GetEmployeeSearch();
        //gvSearch.DataBind();
        GeneralSorting();
    }

    protected void gvSearch_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        { 
            string CommandArg = ((Label)e.Row.FindControl("lblPrimaryID")).Text + ',' + ((Label)e.Row.FindControl("lblTableName")).Text;
            ((Button)e.Row.FindControl("btnEdit")).CommandArgument = CommandArg;
            ((Button)e.Row.FindControl("btnView")).CommandArgument = CommandArg;
        }
    }

    protected void gvSearch_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "EditItem")
        {
            string[] ArrayList = e.CommandArgument.ToString().Split(',');
            Session["WorkerCompID"] = ArrayList[0].ToString();

            switch (ArrayList[1].ToString())
            {
                case "Workers_Comp":
                    Response.Redirect("WorkerCompensation/WorkersCompensation.aspx");
                    break;
                case "Liability_Claim":
                    Response.Redirect("Liability/LiabilityClaim.aspx");
                    break;
            }
        }
        else if (e.CommandName == "View")
        {
            string[] ArrayList = e.CommandArgument.ToString().Split(',');
            Session["WorkerCompID"] = ArrayList[0].ToString();
            Session["ViewAll"] = "View";
            switch (ArrayList[1].ToString())
            {
                case "Workers_Comp":
                    Response.Redirect("WorkerCompensation/WorkersCompensation.aspx");
                    break;
                case "Liability_Claim":
                    Response.Redirect("Liability/LiabilityClaim.aspx");
                    break;

            }
        }
    }
    private void GeneralSorting()
    {
        try
        {
            lstEmpSearch = new List<RIMS_Base.CEmployeeSearch>();
            lstEmpSearch = GetEmployeeSearch();
            if (ViewState["SortExp"] != null && ViewState["sortDirection"] != null)
                lstEmpSearch.Sort(new RIMS_Base.GenericComparer<RIMS_Base.CEmployeeSearch>((string)ViewState["SortExp"], (SortDirection)ViewState["sortDirection"]));
            gvSearch.DataSource = lstEmpSearch;
            gvSearch.DataBind();

        }
        catch (Exception ex)
        {
            throw ex;
        }


    }
    #endregion
}
