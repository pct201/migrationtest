using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ERIMS.DAL;

public partial class SONIC_ClaimInfo_rptRiskManagementWorksheet : clsBasePage
{
    #region "Page Events"

    /// <summary>
    /// Page load Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        // if page is loaded first time
        if (!IsPostBack)
        {
            BindListBoxes();
        }
    }

    #endregion

    #region "Controls Event"

    /// <summary>
    /// Button Show Report click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnShowReport_Click(object sender, EventArgs e)
    {
        string strRegion = "";
        // get selected regions
        foreach (ListItem itmRegion in lstRegions.Items)
        {
            if (itmRegion.Selected)
                strRegion = strRegion + "'" + itmRegion.Value + "',";
        }
        strRegion = strRegion.TrimEnd(',');

        string strMarket = "";
        // get selected Markets
        foreach (ListItem itmMarket in lstMarket.Items)
        {
            if (itmMarket.Selected)
                strMarket = strMarket + "" + itmMarket.Value + ",";
        }
        strMarket = strMarket.TrimEnd(',');

        string strDBA = "";
        // get selected regions
        foreach (ListItem itmdba in lstDBAs.Items)
        {
            if (itmdba.Selected)
                strDBA = strDBA + itmdba.Value + ",";
        }
        strDBA = strDBA.TrimEnd(',');

        string strBodyParts = "";
        // get selected regions
        foreach (ListItem itm in lstPartofBody.Items)
        {
            if (itm.Selected)
                strBodyParts = strBodyParts + "'" + itm.Value + "',";
        }
        strBodyParts = strBodyParts.TrimEnd(',');

        string strClaimStatus = "";
        int intCount = 0;
        if (lstClaimStatus.Items[0].Selected == true)
        {
            strClaimStatus = "WC.FK_Claim_Status > 19";
            intCount++;
        }
        if (lstClaimStatus.Items[1].Selected == true)
        {
            if (strClaimStatus != "")
                strClaimStatus += " OR ";
            strClaimStatus += "WC.FK_Claim_Status IN (10,11,14,15,16,17,18,19)";
            intCount++;
        }

        if (lstClaimStatus.Items[2].Selected == true)
        {
            if (strClaimStatus != "")
                strClaimStatus += " OR ";
            strClaimStatus += "WC.FK_Claim_Status IN (12,13)";
            intCount++;
        }
        if (intCount == 3)
            strClaimStatus = "";
        else if (strClaimStatus != "")
            strClaimStatus = " (" + strClaimStatus + ")";

        DataSet dsReport = clsClaimReports.GetRiskManagementWorksheet(strRegion, strMarket, strDBA, clsGeneral.FormatNullDateToStore(txtLossFromDate.Text), clsGeneral.FormatNullDateToStore(txtLossToDate.Text), strBodyParts, strClaimStatus);

        gvReport.DataSource = dsReport.Tables[0];
        gvReport.DataBind();

        if (dsReport.Tables[0].Rows.Count > 0)
        {
            gvReport.Width = new Unit("1800px");
            dvGrid.Style.Add("overflow-x", "scroll");
            lbtExportToExcel.Visible = true;
        }
        else
        {
            gvReport.Width = new Unit("996px");
            dvGrid.Style.Add("overflow-x", "none");
            lbtExportToExcel.Visible = false;
        }

        trReport.Visible = true;
    }

    /// <summary>
    /// Button Clear Criteria click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnClearCriteria_Click(object sender, EventArgs e)
    {
        lstRegions.ClearSelection();
        lstMarket.ClearSelection();
        lstDBAs.ClearSelection();
        lstClaimStatus.ClearSelection();
        lstPartofBody.ClearSelection();
        txtLossFromDate.Text = "";
        txtLossToDate.Text = "";
    }

    /// <summary>
    /// Button Export click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lbtExportToExcel_Click(object sender, EventArgs e)
    {
        gvReport.GridLines = GridLines.Both;
        GridViewExportUtil.ExportAdHoc("Risk Management Worksheet.xls", gvReport);
        gvReport.GridLines = GridLines.None;      
    }

    #endregion

    #region "Methods"

    /// <summary>
    /// Bind Drop Down
    /// </summary>
    private void BindListBoxes()
    {
        DataTable dtRegions = clsClaimReports.SelectRegions().Tables[0];
        lstRegions.DataSource = dtRegions;
        lstRegions.DataTextField = "region";
        lstRegions.DataValueField = "region";
        lstRegions.DataBind();

        ComboHelper.FillLocationdbaOnlyListBox(new ListBox[] { lstDBAs },0,false,true);

        lstClaimStatus.Items.Add("Closed");
        lstClaimStatus.Items.Add("Open");
        lstClaimStatus.Items.Add("Reopened");

        DataTable dtData = LU_Part_Of_Body.SelectAll().Tables[0];
        dtData.DefaultView.Sort = "Description";
        dtData = dtData.DefaultView.ToTable();
        lstPartofBody.DataTextField = "Description";
        lstPartofBody.DataValueField = "Code";
        lstPartofBody.DataSource = dtData;
        lstPartofBody.DataBind();

        //Bind Market Dropdown
        ComboHelper.FillMarketListBox(new ListBox[] { lstMarket }, false);
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
}
