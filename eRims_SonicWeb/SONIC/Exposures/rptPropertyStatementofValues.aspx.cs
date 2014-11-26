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
using System.Collections.Generic;
public partial class SONIC_Exposures_rptPropertyStatementofValues : clsBasePage
{
    public DataTable dtInsuranceField
    {
        get
        {
            if (ViewState["dtInsuranceField"] != null)
                return (DataTable)ViewState["dtInsuranceField"];
            else
                return null;
        }
        set
        {
            ViewState["dtInsuranceField"] = value;
        }
    }

    public DataTable dtInsuranceField_NEW
    {
        get
        {
            if (ViewState["dtInsuranceField_NEW"] != null)
                return (DataTable)ViewState["dtInsuranceField"];
            else
                return null;
        }
        set
        {
            ViewState["dtInsuranceField_NEW"] = value;
        }
    }

    /// <summary>
    /// Handles event when page is loaded
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        // if page is loaded first time
        if (!IsPostBack)
        {
            // get regions for user having access to and bind the regions list box
            DataTable dtRegions = clsClaimReports.SelectRegions().Tables[0];
            lstRegions.DataSource = dtRegions;
            lstRegions.DataTextField = "region";
            lstRegions.DataValueField = "region";
            lstRegions.DataBind();
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

    #region "Controls Events"

    /// <summary>
    /// Back hrom report to Criteria
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnBack_Click(object sender, EventArgs e)
    {
        trCriteria.Visible = true;
        tblReport.Visible = false;

    }
    /// <summary>
    /// Handles Show Report button click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnShowReport_Click(object sender, EventArgs e)
    {
        string strRegion = "";
        string strStatus = "";
        string strOwnership = "";
        // get selected regions
        strRegion = GetCommaSeparatedValues(lstRegions);
        strStatus = GetCommaSeparatedValues(ddlStatus);
        strOwnership = GetCommaSeparatedValues(drpOwnership);

        // get report data for selected values
        DataSet dsReport = clsExposuresReports.GetPropertyStatementofValues(strRegion, strStatus, strOwnership, clsGeneral.FormatNullDateToStore(txtPropertyValuationDateFrom.Text), clsGeneral.FormatNullDateToStore(txtPropertyValuationDateTo.Text));

        // get data tables from dataset
        DataTable dtRegions = dsReport.Tables[0];

        ERIMS.DAL.Building_Insurance_COPE_Descriptors objInsuranceCope = new Building_Insurance_COPE_Descriptors();
        DataSet objDs = ERIMS.DAL.Building_Insurance_COPE_Descriptors.GetActiveBuildingInsuranceCOPEDescriptors();
        if (objDs != null && objDs.Tables.Count > 0 && objDs.Tables[0].Rows.Count > 0)
        {
            dtInsuranceField = objDs.Tables[0];
        }

        // bind the main grid which lists regions
        //gvDescription.DataSource = dtRegions;
        //gvDescription.DataBind();

        ////Active Insurance Item set visible        
        //if (dtInsuranceField != null && dtInsuranceField.Rows.Count > 0)
        //{
        //    for (int i = 0; i < dtInsuranceField.Rows.Count; i++)
        //    {
        //        HtmlTableCell tdHdItem = (gvDescription.HeaderRow.FindControl("tdHdItem" + dtInsuranceField.Rows[i]["Item_Number"].ToString()) as HtmlTableCell);

        //        if (tdHdItem != null)
        //        {
        //            (gvDescription.HeaderRow.FindControl("tdHdItem" + dtInsuranceField.Rows[i]["Item_Number"].ToString()) as HtmlTableCell).Style.Add("display", "block");
        //            //(gvDescription.HeaderRow.FindControl("tdHdItem" + dtInsuranceField.Rows[i]["Item_Number"].ToString()) as HtmlTableCell).Style.Remove("display");
        //            (gvDescription.HeaderRow.FindControl("tdHdItem" + dtInsuranceField.Rows[i]["Item_Number"].ToString()) as HtmlTableCell).InnerText = dtInsuranceField.Rows[i]["Item_Descriptor"].ToString();
        //        }
        //        //(gvDescription.HeaderRow.FindControl("tdHdItem" + dtInsuranceField.Rows[i]["Item_Number"].ToString()) as HtmlTableCell).Visible = true;

        //        tdHdItem = (tblHeader.FindControl("tdHdItem_" + dtInsuranceField.Rows[i]["Item_Number"].ToString()) as HtmlTableCell);

        //        if (tdHdItem != null)
        //        {
        //            (tblHeader.FindControl("tdHdItem_" + dtInsuranceField.Rows[i]["Item_Number"].ToString()) as HtmlTableCell).Style.Add("display", "block");
        //            //(tblHeader.FindControl("tdHdItem_" + dtInsuranceField.Rows[i]["Item_Number"].ToString()) as HtmlTableCell).Style.Remove("display");
        //            (tblHeader.FindControl("tdHdItem_" + dtInsuranceField.Rows[i]["Item_Number"].ToString()) as HtmlTableCell).InnerText = dtInsuranceField.Rows[i]["Item_Descriptor"].ToString();
        //        }
        //        //(tblHeader.FindControl("tdHdItem_" + dtInsuranceField.Rows[i]["Item_Number"].ToString()) as HtmlTableCell).Visible = true;

        //    }

        //    if ((gvDescription.HeaderRow.FindControl("tdHeaderInsuranceCope") as HtmlTableCell) != null)
        //        (gvDescription.HeaderRow.FindControl("tdHeaderInsuranceCope") as HtmlTableCell).ColSpan = dtInsuranceField.Rows.Count;
        //    tdOutHeaderInsuranceCope.ColSpan = dtInsuranceField.Rows.Count;
        //    tdPropertyHeader.ColSpan = (92 + dtInsuranceField.Rows.Count);

        //    if ((gvDescription.HeaderRow.FindControl("tdGridPropertyHeader") as HtmlTableCell) != null)
        //        (gvDescription.HeaderRow.FindControl("tdGridPropertyHeader") as HtmlTableCell).ColSpan = ((gvDescription.HeaderRow.FindControl("tdGridPropertyHeader") as HtmlTableCell).ColSpan + dtInsuranceField.Rows.Count);

        //}
        //else
        //{
        //    tdOutHeaderInsuranceCope.Visible = false;
        //    tdOutHeaderInsuranceCope.ColSpan = 0;

        //    if ((gvDescription.HeaderRow.FindControl("tdGridPropertyHeader") as HtmlTableCell) != null)
        //        (gvDescription.HeaderRow.FindControl("tdGridPropertyHeader") as HtmlTableCell).ColSpan = 0;

        //}

        // show grid and export link 
        tblReport.Visible = true;
        trCriteria.Visible = false;
        lbtExportToExcel.Visible = dtRegions.Rows.Count > 0;
        btnBack.Visible = true;

        // Check if record found or not.
        //if (dtRegions.Rows.Count > 0)
        //{
        //    // set Gridview div height and width on client side. 
        //    //Page.ClientScript.RegisterStartupScript(Page.GetType(), System.DateTime.Now.ToString(), "javacript:showAudit(" + dvHeader.ClientID + "," + dvGrid.ClientID + ");", true);

        //    // set Gridview div Scroll bar events so Scroll Header as per grid scroll
        //    dvGrid.Attributes.Add("onscroll", "javascript:ChangeScrollBar(this," + dvHeader.ClientID + ");");
        //    dvHeader.Visible = true;
        //}
        //else
        //{
        //    // if record not found then hide Header and set width and height so scroll bar not visible.
        //    dvGrid.Style["height"] = Unit.Pixel(50).ToString();
        //    dvGrid.Style["width"] = "100%";
        //    dvGrid.Style["overflow"] = "hidden";
        //}

        DataSet dsReport_NEW = clsExposuresReports.GetPropertyStatementofValues_NEW(strRegion, strStatus, strOwnership, clsGeneral.FormatNullDateToStore(txtPropertyValuationDateFrom.Text), clsGeneral.FormatNullDateToStore(txtPropertyValuationDateTo.Text));

        dtInsuranceField_NEW = dsReport_NEW.Tables[1];
        ViewState["dtHeader"] = dsReport_NEW.Tables[2];


        #region remove Item Columns
        int item_ColumnIndexStart = 90;


        #endregion

        gvDescription_New.DataSource = dsReport_NEW.Tables[0];
        gvDescription_New.DataBind();

        DataTable dtTemp = dsReport_NEW.Tables[0].Clone();
        dtTemp.ImportRow(dsReport_NEW.Tables[0].Rows[dsReport_NEW.Tables[0].Rows.Count - 1]);
        

        for (int i = 1; i <= 25; i++)
        {
            DataRow[] drtemp = dtInsuranceField_NEW.Select("Item_Number = '" + i.ToString() + "'");
            if (drtemp == null || drtemp.Length == 0)
            {
                gvDescription_New.Columns[item_ColumnIndexStart + i].Visible = false;
                dtTemp.Columns.Remove("Item_" + i);
            }
            else
            {
                gvDescription_New.HeaderRow.Cells[item_ColumnIndexStart + i].Text = drtemp[0]["Item_Descriptor"].ToString();
                gvDescription_New.Columns[item_ColumnIndexStart + i].HeaderText = drtemp[0]["Item_Descriptor"].ToString();
            }
        }
        ViewState["LastRow"] = dtTemp;
    }

    /// <summary>
    /// Handles Export to Excel link click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lbtExportToExcel_Click(object sender, EventArgs e)
    {
        //gvDescription.ShowHeader = true;
        // set borders for tables and gridlines in grids to be displayed in excel file

        System.Web.UI.WebControls.GridView gvDescription1 = new GridView();
        gvDescription1 = gvDescription_New;
        gvDescription1.AllowPaging = false;
        if (ViewState["dtHeader"] != null)
        {
            DataTable dtHeader = (DataTable)ViewState["dtHeader"];

            if (dtHeader != null && dtHeader.Rows.Count > 0)
            {
                GridViewRow row = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Normal);
                int totalColumns = 0;
                foreach (DataRow dr in dtHeader.Rows)
                {
                    TableHeaderCell cell = new TableHeaderCell();
                    cell.Text = dr["Header"].ToString();
                    cell.ColumnSpan = Convert.ToInt32(dr["ColSpan"].ToString());
                    totalColumns += Convert.ToInt32(dr["ColSpan"].ToString());
                    cell.BackColor = System.Drawing.ColorTranslator.FromHtml(dr["BackgroungColor"].ToString());
                    cell.HorizontalAlign = HorizontalAlign.Center;
                    cell.VerticalAlign = VerticalAlign.Middle;
                    if (!string.IsNullOrEmpty(dr["Color"].ToString()))
                    {
                        //cell.ControlStyle.ForeColor = System.Drawing.ColorTranslator.FromHtml(dr["Color"].ToString());
                        cell.ForeColor = System.Drawing.ColorTranslator.FromHtml(dr["Color"].ToString());
                        //cell.Style.Add("color", dr["Color"].ToString());
                    }
                    cell.CssClass = "";
                    row.Controls.Add(cell);
                }
                row.CssClass = "";
                //row.BackColor = System.Drawing.ColorTranslator.FromHtml("#29658F");
                gvDescription1.HeaderRow.Parent.Controls.AddAt(0, row);

                GridViewRow row1 = new GridViewRow(0, 1, DataControlRowType.Header, DataControlRowState.Normal);
                TableHeaderCell cell1 = new TableHeaderCell();
                cell1.ColumnSpan = 2;
                cell1.Text = "Sonic Automotive";
                cell1.HorizontalAlign = HorizontalAlign.Left;

                TableHeaderCell cell2 = new TableHeaderCell();
                cell2.ColumnSpan = totalColumns - 4;
                cell2.Text = "Property Statement of Values Report";
                cell2.HorizontalAlign = HorizontalAlign.Center;


                TableHeaderCell cell3 = new TableHeaderCell();
                cell3.ColumnSpan = 2;
                cell3.Text = DateTime.Now.ToString();
                cell3.HorizontalAlign = HorizontalAlign.Left;


                row1.Controls.Add(cell1);
                row1.Controls.Add(cell2);
                row1.Controls.Add(cell3);
                row1.CssClass = "";
                gvDescription1.HeaderRow.Parent.Controls.AddAt(0, row1);
                gvDescription1.HeaderRow.Parent.Controls.RemoveAt(3);

                GridViewRow row2 = new GridViewRow(0, 1, DataControlRowType.DataRow, DataControlRowState.Normal);
                DataTable dtTemp = (DataTable)ViewState["LastRow"];

                for (int i = 0; i < dtTemp.Columns.Count; i++)
                {
                    TableCell cell = new TableCell();
                    cell.Text = dtTemp.Rows[0][i].ToString();
                    row2.Cells.Add(cell);
                }

                gvDescription1.HeaderRow.Parent.Controls.AddAt(gvDescription1.Rows.Count + 3, row2);



            }

        }
        //DataSet objDs = Building_Insurance_COPE_Descriptors.BuildingInsuranceCOPEDescriptorsSelectALL();
        //if (objDs != null && objDs.Tables.Count > 0 && objDs.Tables[0].Rows.Count > 0)
        //{
        //    if (objDs.Tables[0].Select("Active='Y'").Length == 0)
        //    {
        //        if ((gvDescription1.HeaderRow.FindControl("tdGridPropertyHeader") as HtmlTableCell) != null)
        //            (gvDescription1.HeaderRow.FindControl("tdGridPropertyHeader") as HtmlTableCell).ColSpan = 0;

        //        if ((gvDescription1.HeaderRow.FindControl("tdHeaderInsuranceCope") as HtmlTableCell) != null)
        //        {
        //            (gvDescription1.HeaderRow.FindControl("tdHeaderInsuranceCope") as HtmlTableCell).Visible = false;

        //        }

        //    }

        //    foreach (DataRow objDr in objDs.Tables[0].Rows)
        //    {
        //        if (objDr["Active"].ToString() == "N")
        //        {
        //            if ((gvDescription1.HeaderRow.FindControl("tdHdItem" + objDr["Item_Number"].ToString()) as HtmlTableCell) != null)
        //                (gvDescription1.HeaderRow.FindControl("tdHdItem" + objDr["Item_Number"].ToString()) as HtmlTableCell).Visible = false;

        //            for (int i = 0; i < gvDescription1.Rows.Count - 1; i++)
        //            {
        //                if ((gvDescription1.Rows[i].FindControl("tdItem_" + objDr["Item_Number"].ToString()) as HtmlTableCell) != null)
        //                    (gvDescription1.Rows[i].FindControl("tdItem_" + objDr["Item_Number"].ToString()) as HtmlTableCell).Visible = false;
        //            }
        //        }
        //    }

        //}

        //((HtmlTable)gvDescription1.HeaderRow.FindControl("tblHeader")).Border = 1;

        //gvDescription1.GridLines = GridLines.Both;

        //foreach (GridViewRow gvRow in gvDescription1.Rows)
        //{
        //    HtmlTable tbl = (HtmlTable)gvRow.FindControl("tblHeader");
        //    tbl.Visible = true;
        //    tbl.Border = 1;
        //}

        // export data to excel from gridview
        string css = " #ctl00_ContentPlaceHolder1_gvDescription_New th {height: 22px;}.HeaderStyle th {vertical-align: bottom;text-align: left;padding-bottom: 3px;padding-left: 3px;height: 22px;}";
        GridViewExportUtil.ExportGrid("StatementofValuesReport.xls", gvDescription1, css);
        // reset the settings
        //foreach (GridViewRow gvRow in gvDescription1.Rows)
        //{
        //    HtmlTable tbl = (HtmlTable)gvRow.FindControl("tblHeader");
        //    tbl.Border = 0;

        //}
        //// gvDescription.ShowHeader = false;
        //gvDescription1.GridLines = GridLines.None;
        //((HtmlTable)gvDescription1.HeaderRow.FindControl("tblHeader")).Border = 0;
    }

    /// <summary>
    /// Handles Clear Criteria button click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnClearCriteria_Click(object sender, EventArgs e)
    {
        // load the page again to clear selection
        lstRegions.ClearSelection();
        ddlStatus.ClearSelection();
        drpOwnership.ClearSelection();
        txtPropertyValuationDateFrom.Text = "";
        txtPropertyValuationDateTo.Text = "";
    }

    #endregion

    #region Private Methods
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
    #endregion

    protected void gvDescription_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (dtInsuranceField != null)
            {
                //Active Insurance Item set visible    
                for (int i = 0; i < dtInsuranceField.Rows.Count; i++)
                {
                    HtmlTableCell tdItem = (e.Row.FindControl("tdItem_" + dtInsuranceField.Rows[i]["Item_Number"].ToString()) as HtmlTableCell);

                    if (tdItem != null)
                        //(e.Row.FindControl("tdItem_" + dtInsuranceField.Rows[i]["Item_Number"].ToString()) as HtmlTableCell).Style.Remove("display");
                        (e.Row.FindControl("tdItem_" + dtInsuranceField.Rows[i]["Item_Number"].ToString()) as HtmlTableCell).Style.Add("display", "block");
                    //(e.Row.FindControl("tdItem_" + dtInsuranceField.Rows[i]["Item_Number"].ToString()) as HtmlTableCell).Visible = true;
                }
            }
        }
    }



    protected void gvDescription_New_DataBound(object sender, EventArgs e)
    {
        if (ViewState["dtHeader"] != null)
        {
            DataTable dtHeader = (DataTable)ViewState["dtHeader"];

            if (dtHeader != null && dtHeader.Rows.Count > 0)
            {
                GridViewRow row = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Normal);

                foreach (DataRow dr in dtHeader.Rows)
                {
                    TableHeaderCell cell = new TableHeaderCell();
                    cell.Text = dr["Header"].ToString();
                    cell.ColumnSpan = Convert.ToInt32(dr["ColSpan"].ToString());
                    cell.BackColor = System.Drawing.ColorTranslator.FromHtml(dr["BackgroungColor"].ToString());
                    cell.HorizontalAlign = HorizontalAlign.Center;
                    cell.VerticalAlign = VerticalAlign.Middle;
                    if (!string.IsNullOrEmpty(dr["Color"].ToString()))
                    {
                        //cell.ControlStyle.ForeColor = System.Drawing.ColorTranslator.FromHtml(dr["Color"].ToString());
                        cell.ForeColor = System.Drawing.ColorTranslator.FromHtml(dr["Color"].ToString());
                        //cell.Style.Add("color", dr["Color"].ToString());
                    }
                    cell.CssClass = "";
                    row.Controls.Add(cell);
                }
                row.CssClass = "";
                //row.BackColor = System.Drawing.ColorTranslator.FromHtml("#29658F");
                gvDescription_New.HeaderRow.Parent.Controls.AddAt(0, row);
            }

        }
        //for (int i = 0; i < gvDescription_New.Columns.Count; i++)
        //{
        //    gvDescription_New.Columns[i].ItemStyle.Width = 400;
        //}

    }

    protected void gvDescription_New_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{
        //    if (dtInsuranceField_NEW != null)
        //    {
        //        //Active Insurance Item set visible    
        //        for (int i = 0; i < dtInsuranceField_NEW.Rows.Count; i++)
        //        {
        //            HtmlTableCell tdItem = (e.Row.FindControl("tdItem_" + dtInsuranceField_NEW.Rows[i]["Item_Number"].ToString()) as HtmlTableCell);

        //            if (tdItem != null)
        //                //(e.Row.FindControl("tdItem_" + dtInsuranceField.Rows[i]["Item_Number"].ToString()) as HtmlTableCell).Style.Remove("display");
        //                (e.Row.FindControl("tdItem_" + dtInsuranceField_NEW.Rows[i]["Item_Number"].ToString()) as HtmlTableCell).Style.Add("display", "block");
        //            //(e.Row.FindControl("tdItem_" + dtInsuranceField.Rows[i]["Item_Number"].ToString()) as HtmlTableCell).Visible = true;
        //        }
        //    }
        //}
    }
}
