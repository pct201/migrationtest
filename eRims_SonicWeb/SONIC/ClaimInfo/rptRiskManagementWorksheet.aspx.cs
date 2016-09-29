using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ERIMS.DAL;
using System.IO;

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
        string htmlContent = GridViewExportUtil.ExportAdHoc_New(gvReport);
        gvReport.GridLines = GridLines.None;
        String strPath = String.Empty, data = String.Empty, outputFiles = String.Empty;

        strPath = AppConfig.SitePath + @"temp\" + DateTime.Now.ToString("ddMMyyyyhhmmss");
        if (!File.Exists(strPath))
        {
            if (!Directory.Exists(AppConfig.SitePath + @"temp\"))
                Directory.CreateDirectory(AppConfig.SitePath + @"temp\");
            // Create a file to write to.
            using (StreamWriter sw = File.CreateText(strPath))
            {
                sw.Write(htmlContent);
            }
        }

        data = File.ReadAllText(strPath);
        data = data.Trim();
        HTML2Excel objHtml2Excel = new HTML2Excel(data);
        objHtml2Excel.isGrid = false;
        objHtml2Excel.overwriteBorder = false;
        outputFiles = Path.GetFullPath(strPath) + ".xlsx";
        bool blnHTML2Excel = objHtml2Excel.Convert2Excel(outputFiles);

        if (blnHTML2Excel)
        {
            try
            {
                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.AddHeader("content-disposition", string.Format("attachment; filename=\"Risk Management Worksheet.xlsx\""));
                HttpContext.Current.Response.ContentType = "application/ms-excel";
                HttpContext.Current.Response.TransmitFile(outputFiles);
                HttpContext.Current.Response.Flush();
            }
            finally
            {
                if (File.Exists(outputFiles))
                    File.Delete(outputFiles);
                if (File.Exists(strPath))
                    File.Delete(strPath);

                HttpContext.Current.Response.End();
            }
        }
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
    protected void gvReport_PreRender(object sender, EventArgs e)
    {
    //    GridView gridView = (GridView)sender;
    //    GridViewRow header = (GridViewRow)gridView.Controls[0].Controls[0];

    //    //header.Cells[0].Visible = false;
    //    header.Cells[7].ColumnSpan = 5;
    //    //header.Cells[1].Text = "Header";
    }
}
