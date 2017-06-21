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

/************************************************************************************************************************************
 * File Name      : RptAllocationYTDChargeReport.aspx
 * 
 * Developer Name : Ravi Patel
 *
 *  Description   : This page is used for generate Workers Comp Allocation YTD Charge Report.
 *                  User selects Region, Locationn, Year as filter criteria for this Report. User can also export this report to excel sheet.
 *
 *************************************************************************************************************************************/

public partial class SONIC_FirstReport_RptAllocationYTDChargeReport : clsBasePage
{
    DataTable dtDetails;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // fill DropDown
            BindDropDownList();            
        }
    }

    #region "Events"

    protected void btnShowReport_Click(object sender, EventArgs e)
    {       
        string strRegion = string.Empty, strLocation = string.Empty, strYear = string.Empty, strMarket = string.Empty;
        bool setMarket = false;

        
        // get selected regions
        foreach (ListItem li in lstRegion.Items)
        {
            if (li.Selected)
                strRegion = strRegion + "'" + li.Value + "',";
        }
        strRegion = strRegion.TrimEnd(',');

        //get selected Market
        foreach (ListItem li in lstMarket.Items)
        {
            if (li.Selected)
                strMarket = strMarket + "" + li.Value + ",";
        }
        strMarket = strMarket.TrimEnd(',');

        // get selected Location
        foreach (ListItem li in lstLocation.Items)
        {
            if (li.Selected)
                strLocation = strLocation + li.Value + ",";
        }
        strLocation = strLocation.TrimEnd(',');

        // get selected Year
        foreach (ListItem li in lstYear.Items)
        {
            if (li.Selected)
                strYear = strYear + li.Value + ",";
        }
        strYear = strYear.TrimEnd(',');

        // fetch records for report as per year selected
        DataSet dsResult = new DataSet();

        if (rdoRunBy.SelectedValue == "Region")
        {      
  
            dsResult = Report.GetWCAllocationYTDChargeReport(strRegion, strMarket, strLocation, strYear);
            dtDetails = dsResult.Tables[0];
            setMarket = false;            

        }
        else if (rdoRunBy.SelectedValue == "Market")
        {
            dsResult = Report.GetWCAllocationYTDChargeReport_ByMarket(strRegion, strMarket, strLocation, strYear);
            dtDetails = dsResult.Tables[0];
            setMarket = true;
        }        
        // set scrollbar propery
        dvReport.Style[HtmlTextWriterStyle.OverflowX] = (dsResult.Tables[1].Rows.Count > 0) ? "scroll;" : "hidden;";

        // bind grid view
        gvReport.DataSource = dsResult.Tables[1];
        gvReport.DataBind();
        dvGrid.Visible = true;

        // Check if report return any row or not
        if (gvReport.Rows.Count > 0)
        {
            lnkExportToExcel.Visible = true;

            // display total
            ((Label)gvReport.HeaderRow.FindControl("lblAccYear")).Text = strYear;
            ((Label)gvReport.FooterRow.FindControl("lblGCount")).Text = dtDetails.Rows.Count.ToString();
            ((Label)gvReport.FooterRow.FindControl("lblGInitialCharge")).Text = string.Format("{0:C2}", dtDetails.Compute("SUM(Initial_Charge)", ""));
            ((Label)gvReport.FooterRow.FindControl("lblGTotalCredits")).Text = string.Format("{0:C2}", dtDetails.Compute("SUM(Total_Credits)", ""));
            ((Label)gvReport.FooterRow.FindControl("lblGTotalPanalties")).Text = string.Format("{0:C2}", dtDetails.Compute("SUM(Total_Penalties)", ""));
            ((Label)gvReport.FooterRow.FindControl("lblGTotalAmount")).Text = string.Format("{0:C2}", dtDetails.Compute("SUM(SureGrip_Total_Charge)", ""));
        }
        else
            lnkExportToExcel.Visible = false;
    }

    protected void btnClear_Click(object sender, EventArgs e)
    {
        Response.Redirect(Request.AppRelativeCurrentExecutionFilePath);
    }

    protected void lnkExportToExcel_Click(object sender, EventArgs e)
    {
        //btnShowReport_Click(sender, e);
        gvReport.GridLines = GridLines.Both;

        // set border to Header and footer table
        ((HtmlTable)gvReport.HeaderRow.FindControl("tblHeader")).Border = 1;
        ((HtmlTable)gvReport.FooterRow.FindControl("tblFooter")).Border = 1;

        // set Border to Inner grid
        foreach (GridViewRow gRow in gvReport.Rows)
        {
            GridView gvDetail = (GridView)gRow.FindControl("gvDetail");
            gvDetail.GridLines = GridLines.Both;
        }
        // export gridview to excel
        GridViewExportUtil.ExportGrid("WCAllocationYTDChargeReport.xlsx", gvReport, true);
        gvReport.GridLines = GridLines.None;
    }

    protected void gvReport_RowDataBound(object sender, GridViewRowEventArgs e)    
    {        
        // if row type is data row
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            // get details for specific region from datatable having details data
            DataView dvDetails = dtDetails.DefaultView;
            string STR_Location = string.Empty;
            STR_Location = DataBinder.Eval(e.Row.DataItem, "PK_LU_Location_ID").ToString();
            dvDetails.RowFilter = "PK_LU_Location_ID = " + STR_Location;

            // reset Leaseable area for inner grid

            //bind the sub grid for Region grid 
            GridView gvDetail = e.Row.FindControl("gvDetail") as GridView;
            gvDetail.DataSource = dvDetails.ToTable();
            gvDetail.DataBind();          
            
            if (gvDetail.Rows.Count > 0)
            {
                ((Label)gvDetail.FooterRow.FindControl("lblTotalCount")).Text = gvDetail.Rows.Count.ToString();
                ((Label)gvDetail.FooterRow.FindControl("lblInitialCharge")).Text = string.Format("{0:C2}", dvDetails.ToTable().Compute("SUM(Initial_Charge)", "PK_LU_Location_ID = " + STR_Location));
                ((Label)gvDetail.FooterRow.FindControl("lblTotalCredits")).Text = string.Format("{0:C2}", dvDetails.ToTable().Compute("SUM(Total_Credits)", "PK_LU_Location_ID = " + STR_Location));
                ((Label)gvDetail.FooterRow.FindControl("lblTotalPanalties")).Text = string.Format("{0:C2}", dvDetails.ToTable().Compute("SUM(Total_Penalties)", "PK_LU_Location_ID = " + STR_Location));
                ((Label)gvDetail.FooterRow.FindControl("lblTotalAmount")).Text = string.Format("{0:C2}", dvDetails.ToTable().Compute("SUM(SureGrip_Total_Charge)", "PK_LU_Location_ID = " + STR_Location));
            }
        }
    }

    /// <summary>
    /// This method is added for export Girdview To Excel which contains SubGridview.
    /// </summary>
    /// <param name="control"></param>
    public override void VerifyRenderingInServerForm(Control control)
    {
        return;
    }

    #endregion


    #region "Methods"

    /// <summary>
    /// Bind Dropdown for report
    /// </summary>
    private void BindDropDownList()
    {
        // Fill Location by Employee        
        Nullable<decimal> CurrentEmployee = new Security(Convert.ToDecimal(clsSession.UserID)).Employee_Id;
        if (CurrentEmployee.ToString() != string.Empty && CurrentEmployee.ToString() != "0")
            CurrentEmployee = Convert.ToDecimal(CurrentEmployee);
        else
            CurrentEmployee = 0;
        string Regional = string.Empty;

        // select region as per login user
        DataSet dsRegion = Regional_Access.SelectBySecurityID(Convert.ToInt32(clsSession.UserID));

        // Append region in comma seperated string value
        if (dsRegion.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow drRegion in dsRegion.Tables[0].Rows)
                Regional += drRegion["Region"].ToString() + ",";
        }
        else
            Regional = string.Empty;

        //Fill Location
        DataSet dsLocation = ERIMS.DAL.LU_Location.SelectAll(CurrentEmployee, Regional.ToString().TrimEnd(Convert.ToChar(",")));
        lstLocation.Items.Clear();

        dsLocation.Tables[0].DefaultView.RowFilter = " Active = 'Y' And Show_On_Dashboard = 'Y' ";
        dsLocation.Tables[0].DefaultView.Sort = "dba";
        lstLocation.DataTextField = "dba";
        lstLocation.DataValueField = Convert.ToString(dsLocation.Tables[0].Columns["PK_LU_Location_ID"]);
        lstLocation.DataSource = dsLocation.Tables[0].DefaultView.ToTable();
        lstLocation.DataBind();
        clsGeneral.DisposeOf(dsLocation);
        clsGeneral.DisposeOf(dsRegion);

        //Region
        lstRegion.DataSource = LU_Location.GetRegionList();
        lstRegion.DataTextField = "region";
        lstRegion.DataValueField = "region";
        lstRegion.DataBind();

        lstYear.DataSource = WC_FR.SelectDistinctIncidentYear().Tables[0];
        lstYear.DataTextField = "WCYear";
        lstYear.DataValueField = "WCYear";
        lstYear.DataBind();

        //Fill Market
        ComboHelper.FillMarketListBox(new ListBox[] { lstMarket }, false);
        
    }

    #endregion    
}
