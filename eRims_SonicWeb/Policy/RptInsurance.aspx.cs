using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using ERIMS.DAL;
using RIMS_Base.Biz;

public partial class Policy_RptInsurance : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindDropdowns();            
        }
    }

    private void BindDropdowns()
    {
        // -- Bind Policy Years
        DataTable dtPolicyYears = Report.GetInsurancePolicyYears().Tables[0];
        drpPolicyYear.DataSource = dtPolicyYears;
        drpPolicyYear.DataTextField = "PolicyYear";
        drpPolicyYear.DataValueField = "PolicyYear";
        drpPolicyYear.DataBind();
        drpPolicyYear.Items.Insert(0, new ListItem("--Select--", "0"));

        //-- Bind Programs list
        DataTable dtProgram = Tatva_Program.SelectAll().Tables[0];
        lstProgram.DataSource = dtProgram;
        lstProgram.DataTextField = "Fld_Desc";
        lstProgram.DataValueField = "PK_ID";
        lstProgram.DataBind();

        
    }

    protected void btnGenerateReport_Click(object sender, EventArgs e)
    {
        int? intYear = null;
        string strPrograms = "";
        string strPolicyTypes = "";
        if (drpPolicyYear.SelectedIndex > 0) intYear = Convert.ToInt32(drpPolicyYear.SelectedValue);

        foreach (ListItem lst in lstProgram.Items)
        {
            if (lst.Selected)
                strPrograms = strPrograms + lst.Value + ",";
        }
        strPrograms = strPrograms.TrimEnd(',');

        foreach (ListItem lst in lstPolicyType.Items)
        {
            if (lst.Selected)
                strPolicyTypes = strPolicyTypes + lst.Value + ",";
        }
        strPolicyTypes = strPolicyTypes.TrimEnd(',');

        DataTable dtReport = Report.GetInsuranceSchedule(intYear, strPrograms, strPolicyTypes).Tables[0];
        gvPolicy.DataSource = dtReport;
        gvPolicy.DataBind();

        pnlReport.Visible = true;

        if (dtReport.Rows.Count > 0)
        {
            lbtExportToExcel.Visible = true;
            if (drpPolicyYear.SelectedIndex > 0)
                ((Label)gvPolicy.HeaderRow.FindControl("lblPolicyYear")).Text = drpPolicyYear.SelectedValue;
            gvPolicy.Width = new Unit("2500px");
            dvReport.Style.Add("overflow-x", "scroll");

            ((Label)gvPolicy.FooterRow.FindControl("lblAnnualPremiumTotal")).Text = string.Format("{0:N2}", dtReport.Compute("SUM(Annual_Premium)", ""));
            ((Label)gvPolicy.FooterRow.FindControl("lblSLFees")).Text = string.Format("{0:N2}", dtReport.Compute("SUM(Surplus_Lines_Fees)", ""));
            ((Label)gvPolicy.FooterRow.FindControl("lblTotal")).Text = string.Format("{0:N2}", dtReport.Compute("SUM(Total)", ""));
        }
        else
        {
            lbtExportToExcel.Visible = false;
            gvPolicy.Width = new Unit("990px");
            dvReport.Style.Add("overflow-x", "none");
        }

        
    }

    protected void btnClearCriteria_Click(object sender, EventArgs e)
    {
        Response.Redirect(Request.Url.ToString());
    }

    protected void lstProgram_SelectedIndexChanged(object sender, EventArgs e)
    {
        string strPrograms="";

        foreach (ListItem lst in lstProgram.Items)
        {
            if (lst.Selected)
                strPrograms = strPrograms + lst.Value + ",";
        }
        strPrograms = strPrograms.TrimEnd(',');
        //-- Bind Policy Type list
        DataTable dtPolicyType = Report.GetPolicyTypesByProgramIDs(strPrograms).Tables[0];
        lstPolicyType.DataSource = dtPolicyType;
        lstPolicyType.DataTextField = "FLD_desc";
        lstPolicyType.DataValueField = "PK_ID";
        lstPolicyType.DataBind();        
    }

    protected void lbtExportToExcel_Click(object sender, EventArgs e)
    {
        // set borders for tables and gridlines in grids to be displayed in excel file
        ((HtmlTable)gvPolicy.HeaderRow.FindControl("tblHeader")).Border = 1;        
        ((HtmlTable)gvPolicy.FooterRow.FindControl("tblFooter")).Border = 1;
        gvPolicy.GridLines = GridLines.Both;
        foreach (GridViewRow gRow in gvPolicy.Rows)
        {
            ((HtmlTable)gRow.FindControl("tblDetails")).Border = 1;
        }
        // export data to excel from gridview
        GridViewExportUtil.ExportGrid("InsuranceSchedule.xls", gvPolicy);

        gvPolicy.GridLines = GridLines.None;
        foreach (GridViewRow gRow in gvPolicy.Rows)
        {
            ((HtmlTable)gRow.FindControl("tblDetails")).Border = 0;
        }
        ((HtmlTable)gvPolicy.HeaderRow.FindControl("tblHeader")).Border = 0;        
        ((HtmlTable)gvPolicy.FooterRow.FindControl("tblFooter")).Border = 0;
    }

    #region " Methods "

    /// <summary>
    /// This method is added for export Girdview To Excel which contains SubGridview.
    /// </summary>
    /// <param name="control"></param>
    public override void VerifyRenderingInServerForm(Control control)
    {
        return;
    }
    #endregion
}
