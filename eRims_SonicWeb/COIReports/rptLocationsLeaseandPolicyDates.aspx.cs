using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ERIMS.DAL;
using System.Text;
using System.IO;
using System.Web.UI.HtmlControls;

public partial class COIReports_rptLocationsLeaseandPolicyDates : clsBasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindDropDownList();            
            trCriteria.Visible = true;
            tblReport.Visible = false;
            rdbSubleaseAgreement.SelectedValue = "3";
            rdbInsuredActive.SelectedValue = "3";
        }
    }

    private void BindGrid()
    {
        string strRegion = string.Empty, strLocationStatus = string.Empty,strLocation = string.Empty, strMarket = string.Empty;

        foreach (ListItem li in lstLocation.Items)
        {
            if (li.Selected)
                strLocation = strLocation + "'" + li.Value + "',";
        }
        strLocation = strLocation.TrimEnd(',');


        foreach (ListItem li in lstRegion.Items)
        {
            if (li.Selected)
                strRegion = strRegion + "'" + li.Value + "',";
        }
        strRegion = strRegion.TrimEnd(',');

        foreach (ListItem li in lstMarket.Items)
        {
            if (li.Selected)
                strMarket = strMarket + "" + li.Value + ",";
        }
        strMarket = strMarket.TrimEnd(',');


        string strStatus = "";
        foreach (ListItem li in lstBuildingStatus.Items)
        {
            if (li.Selected)
                strStatus = strStatus + "'" + li.Value + "',";
        }

        strStatus = strStatus.TrimEnd(',');

        //if (string.IsNullOrEmpty(strRegion))
        //{
        //    Page.RegisterStartupScript(DateTime.Now.ToString(), "<script language=javascript> alert('Please select atleast one region.');</script>");
        //}

        //if(string.IsNullOrEmpty(strLocation))


        DataSet Ds = new DataSet();
        Ds = Report.getrptLocationsLeasePolicyDates(Convert.ToInt16(rdbSubleaseAgreement.SelectedValue),strRegion, strMarket, strLocation,strStatus, Convert.ToInt16(rdbInsuredActive.SelectedValue));

        if (Ds != null && Ds.Tables[0].Rows.Count > 0)
        {
            gvReport.DataSource = Ds.Tables[0];
            gvReport.DataBind();
            lbtExportToExcel.Visible = true;
        }
        else
        {
            gvReport.DataSource = null;
            gvReport.DataBind();            
            gvReport.Width= Unit.Pixel(950);
            lbtExportToExcel.Visible = false;
            //dvGrid.Attributes.Add("height", "100");
        }       

        if (Ds != null)
            Ds = null;
    }

    /// <summary>
    /// Generates the string having selected values of Listbox in comma separated format
    /// </summary>
    /// <param name="lst"></param>
    /// <returns></returns>
    private string GetCommaSeparatedValues(ListBox lst)
    {
        string strRegion = string.Empty;
        foreach (ListItem itmRegion in lst.Items)
        {
            if (itmRegion.Selected)
                strRegion = strRegion + itmRegion.Value + ",";
        }
        strRegion = strRegion.TrimEnd(',');
        return strRegion;
    }

    ///// <summary>
    ///// Bind Drop Down List
    ///// </summary>    
    private void BindDropDownList()
    {
        ComboHelper.FillRegionListBox(new ListBox[] { lstRegion }, false);
        ComboHelper.FillMarketListBox(new ListBox[] { lstMarket }, false);
        ComboHelper.FillLocationdba(new ListBox[] { lstLocation },0, false);
    }

    protected void btnShowReport_Click(object sender, EventArgs e)
    {

        trCriteria.Visible = false;
        tblReport.Visible = true;

        BindGrid();
    }

    protected void btnClearCriteria_Click(object sender, EventArgs e)
    {   
        lstBuildingStatus.ClearSelection();
        lstRegion.ClearSelection();
        lstMarket.ClearSelection();
        lstLocation.Items.Clear();
        ComboHelper.FillLocationdba(new ListBox[] { lstLocation }, 0, false);
    }

    protected void lbtExportToExcel_Click(object sender, EventArgs e)
    {
        ((HtmlTable)gvReport.HeaderRow.FindControl("tblHeader")).Border = 1;
        gvReport.GridLines = GridLines.Both;
        gvReport.FooterRow.Visible = false;
        foreach (GridViewRow gvRow in gvReport.Rows)
        {
            HtmlTable tbl = (HtmlTable)gvRow.FindControl("tblRow");
            tbl.Visible = true;
            tbl.Border = 1;
        }

        // export data to excel from grid view
        GridViewExportUtil.ExportGrid_Old("LocationsLeaseandPolicyDates.xls", gvReport);

        // reset the settings
        foreach (GridViewRow gvRow in gvReport.Rows)
        {
            HtmlTable tbl = (HtmlTable)gvRow.FindControl("tblRow");
            tbl.Border = 0;
        }
        // gvReport.ShowHeader = false;
        gvReport.GridLines = GridLines.None;
        ((HtmlTable)gvReport.HeaderRow.FindControl("tblHeader")).Border = 0;
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        
    }

    /// <summary>
    /// Back show report to Criteria
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnBack_Click(object sender, EventArgs e)
    {
        trCriteria.Visible = true;
        tblReport.Visible = false;
    }

    public string GetValue(string Value)
    {
        if (string.IsNullOrEmpty(Value))
        {
            return "&nbsp;";
        }
        else
        {
            return Value;
        }
    }

    protected void lstRegion_SelectedIndexChanged(object sender, EventArgs e)
    {
        string strRegion = string.Empty;
        foreach (ListItem li in lstRegion.Items)
        {
            if (li.Selected)
                strRegion = strRegion + li.Value + ",";
        }
        strRegion = strRegion.TrimEnd(',');

        ComboHelper.FillLocationdbaByRegion(new ListBox[] { lstLocation }, 0, false, strRegion);
    }
}