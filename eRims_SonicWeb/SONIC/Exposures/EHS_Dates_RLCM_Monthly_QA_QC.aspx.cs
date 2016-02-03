using ERIMS.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class SONIC_Exposures_EHS_Dates_RLCM_Monthly_QA_QC : clsBasePage
{
    #region ::Properties::

    public decimal? PK_RLCM
    {
        get { return clsGeneral.GetDecimal(ViewState["PK_RLCM"]); }
        set { ViewState["PK_RLCM"] = value; }
    }


    public int? Month
    {
        get { return clsGeneral.GetInt(ViewState["Month"]); }
        set { ViewState["Month"] = value; }
    }

    public int? Year
    {
        get { return clsGeneral.GetInt(ViewState["Year"]); }
        set { ViewState["Year"] = value; }
    }

    #endregion

    #region ::Page Load::

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            int intMonth;
            int intYear;
            int intRLCM;

            //if (!string.IsNullOrEmpty(Request.QueryString["Mnt"]))
            if (int.TryParse(Encryption.Decrypt(Request.QueryString["Mnt"]), out intMonth))
            {
                Month = intMonth;
            }
            else
            {
                Response.Redirect("RLCM_QA_QC.aspx");
            }

            //if (!string.IsNullOrEmpty(Request.QueryString["yr"]))
            if (int.TryParse(Encryption.Decrypt(Request.QueryString["yr"]), out intYear))
            {
                Year = intYear;
            }
            else
            {
                Response.Redirect("RLCM_QA_QC.aspx");
            }

            //if (!string.IsNullOrEmpty(Request.QueryString["RLCM"]))
            if (int.TryParse(Encryption.Decrypt(Request.QueryString["RLCM"]), out intRLCM))
            {
                PK_RLCM = intRLCM;
            }
            else
            {
                Response.Redirect("RLCM_QA_QC.aspx");
            }

            BindData();
        }
    }

    #endregion

    #region ::Methods::

    /// <summary>
    /// Bind Data.
    /// </summary>
    public void BindData()
    {
        DataSet ds = clsEHS_Calendar.EHS_Show_Calendar(Year, Month, PK_RLCM);

        if (ds.Tables[0].Rows.Count > 0)
        {
            BindTable(ds);
        }
        else
        {
            lblMsg.Text = "No Dates are associated for this month and year.";
        }
    }

    /// <summary>
    /// Bind dynamic grid for each location.
    /// </summary>
    /// <param name="dtClone"></param>
    /// <param name="dr"></param>
    /// <param name="pnlGrid"></param>
    protected void BindGrid(DataTable dtClone, DataRow[] dr, Panel pnlGrid)
    {
        DataTable dt = dtClone;

        GridView gvDatesByLocation = new GridView();
        gvDatesByLocation.AutoGenerateColumns = false;

        if (dr.Length > 0)
        {
            foreach (DataRow row in dr)
            {
                dt.ImportRow(row);
            }

            ////First 3 column from data-base.
            for (int i = 0; i < 3; i++)
            {
                BoundField boundfield = new BoundField();
                boundfield.DataField = dt.Columns[i].ColumnName.ToString();
                //boundfield.HeaderText = dt.Columns[i].ColumnName.ToString();
                boundfield.ItemStyle.Width = 200;
                gvDatesByLocation.Columns.Add(boundfield);
            }

            // Here is template column portion for link button.
            TemplateField DateCol = new TemplateField();
            gvDatesByLocation.Columns.Add(DateCol);
            DateCol.ItemStyle.Width = 200;
            DateCol.ItemTemplate = new HyperlinkColumn();

            gvDatesByLocation.ShowFooter = true;

            ////Row data bound event for each grid.
            gvDatesByLocation.RowDataBound += new GridViewRowEventHandler(gvDatesByLocation_RowDataBound);

            gvDatesByLocation.DataSource = dt;
            gvDatesByLocation.DataBind();
            gvDatesByLocation.ShowHeader = false;
            //gvEmployee.Width = 900;
            //gvEmployee.HeaderStyle.CssClass = "header";
            //gvEmployee.RowStyle.CssClass = "rowstyle";

            pnlGrid.Controls.Add(gvDatesByLocation);
        }
    }

    /// <summary>
    /// Bind dynamic table.
    /// </summary>
    /// <param name="ds"></param>
    protected void BindTable(DataSet ds)
    {
        #region Header

        HtmlTableRow row = new HtmlTableRow();
        HtmlTableCell cell = new HtmlTableCell();
        row.Style.Add("font-size", "16px");

        cell.InnerText = "Location";
        cell.Width = "18%";
        row.Cells.Add(cell);

        cell = new HtmlTableCell();
        cell.InnerText = string.Empty;
        cell.Width = "2%";
        row.Cells.Add(cell);

        cell = new HtmlTableCell();
        cell.InnerText = "Category";
        cell.Width = "20%";
        row.Cells.Add(cell);

        cell = new HtmlTableCell();
        cell.InnerText = "Type";
        cell.Width = "20%";
        row.Cells.Add(cell);

        cell = new HtmlTableCell();
        cell.InnerText = "Field";
        cell.Width = "20%";
        row.Cells.Add(cell);

        cell = new HtmlTableCell();
        cell.InnerText = "Expiration Date";
        cell.Width = "20%";
        row.Cells.Add(cell);

        tableContent.Rows.Add(row);

        #endregion

        DataTable dt = ds.Tables[0];
        DataTable dtDistinct_Location = dt.DefaultView.ToTable(true, "Location");

        ////Location wise loop row.
        for (int i = 0; i < dtDistinct_Location.Rows.Count; i++)
        {
            ////Location name inside First cell.
            row = new HtmlTableRow();
            cell = new HtmlTableCell();
            row.VAlign = "top";

            cell.InnerText = Convert.ToString(dtDistinct_Location.Rows[i]["Location"]);
            cell.Style.Add("padding-top", "25px");
            row.Cells.Add(cell);

            ////Expand-Collapse button inside second cell.
            cell = new HtmlTableCell();
            HtmlImage img = new HtmlImage();
            img.ID = "img" + i;
            if (hdnOpenLocation.Value.Contains(Convert.ToString(dtDistinct_Location.Rows[i]["Location"])))
            {
                img.Src = AppConfig.ImageURL + "/up-arrow.gif";
            }
            else
            {
                img.Src = AppConfig.ImageURL + "/down-arrow.gif";
            }

            img.Style.Add("cursor", "pointer");
            img.Attributes.Add("onclick", "ExpandCollapse('ctl00_ContentPlaceHolder1_" + img.ID + "','" + Convert.ToString(dtDistinct_Location.Rows[i]["Location"]).Replace("'", "\\\'") + "')");
            cell.Controls.Add(img);
            row.Cells.Add(cell);

            cell = new HtmlTableCell();
            cell.ColSpan = 4;
            cell.ID = "col" + i;
            if (hdnOpenLocation.Value.Contains(Convert.ToString(dtDistinct_Location.Rows[i]["Location"])))
            {
                cell.Style.Add("display", "");
            }
            else
            {
                cell.Style.Add("display", "none");
            }

            ////Dynamic div panel inside third cell (ColSpan=4).
            Panel dynamicPanel = new Panel();
            dynamicPanel.ID = "Pnl" + i;
            cell.Controls.Add(dynamicPanel);
            BindGrid(dt.Clone(), dt.Select("Location = '" + Convert.ToString(dtDistinct_Location.Rows[i]["Location"]).Replace("'", "''") + "'"), dynamicPanel);

            row.Cells.Add(cell);

            tableContent.Rows.Add(row);
        }
    }

    #endregion

    #region ::Events::

    /// <summary>
    /// Row data bound event for grid.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void gvDatesByLocation_RowDataBound(Object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton lnkbtnDate = new LinkButton();
            lnkbtnDate = ((LinkButton)(e.Row.FindControl("hypLink")));

            lnkbtnDate.Text = clsGeneral.FormatDateToDisplay(Convert.ToDateTime(DataBinder.Eval(e.Row.DataItem, "DueDate")));
            string strIdentifier = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Identifier"));

            switch (Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Field")))
            {
                case "Permit End Date":
                    lnkbtnDate.OnClientClick = "javascript:return Redirect('" + AppConfig.SiteURL + "SONIC/Pollution/PM_Permits.aspx?id=" + Encryption.Encrypt(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "id"))) + "&op=edit&fid=" + Encryption.Encrypt(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "fid"))) + "&loc=" + Encryption.Encrypt(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Location_ID"))) + "')";
                    break;
                case "Report Due Date":
                    lnkbtnDate.OnClientClick = "javascript:return Redirect('" + AppConfig.SiteURL + "SONIC/Pollution/PM_CR_Grids.aspx?gtype=" + Encryption.Encrypt(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Identifier"))) + "&id=" + Encryption.Encrypt(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "id"))) + "&op=edit&fid=" + Encryption.Encrypt(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "fid"))) + "&loc=" + Encryption.Encrypt(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Location_ID"))) + "&cid=" + Encryption.Encrypt(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "cid"))) + "')";
                    break;
                case "Inspection Date":
                case "Sludge Removal Date":
                case "SPCC Expiration Date":
                    lnkbtnDate.OnClientClick = "javascript:return Redirect('" + AppConfig.SiteURL + "SONIC/Pollution/Equipment.aspx?id=" + Encryption.Encrypt(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "id"))) + "&op=edit&fid=" + Encryption.Encrypt(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "fid"))) + "&loc=" + Encryption.Encrypt(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Location_ID"))) + "')";
                    break;
                case "RLCM QA/QC EHS Date":
                    lnkbtnDate.OnClientClick = "javascript:return OpenUserEHSDates('" + Encryption.Encrypt(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "id"))) + "','" + Encryption.Encrypt(Convert.ToString(PK_RLCM)) + "')";
                    break;
                case "Next Inspection Date":
                case "Next Report Date":
                case "Next Review Date":
                    if(strIdentifier == "Inspections")
                        lnkbtnDate.OnClientClick = "javascript:return Redirect('" + AppConfig.SiteURL + "SONIC/Pollution/Audit_Inspections_Frequency.aspx?id=" + Encryption.Encrypt(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "id"))) + "&op=edit&fid=" + Encryption.Encrypt(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "fid"))) + "&loc=" + Encryption.Encrypt(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Location_ID"))) + "')";
                    else
                        lnkbtnDate.OnClientClick = "javascript:return Redirect('" + AppConfig.SiteURL + "SONIC/Pollution/PM_EPA_Inspection.aspx?id=" + Encryption.Encrypt(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "id"))) + "&op=edit&fid=" + Encryption.Encrypt(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "fid"))) + "&loc=" + Encryption.Encrypt(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Location_ID"))) + "')";
                    break;
                case "Date of Violation":
                    lnkbtnDate.OnClientClick = "javascript:return Redirect('" + AppConfig.SiteURL + "SONIC/Pollution/PM_Violation.aspx?id=" + Encryption.Encrypt(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "id"))) + "&op=edit&fid=" + Encryption.Encrypt(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "fid"))) + "&loc=" + Encryption.Encrypt(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Location_ID"))) + "')";
                    break;
                default:
                    lnkbtnDate.OnClientClick = "javascript:return false;";
                    break;
            }



            lnkbtnDate.ForeColor = Convert.ToDateTime(lnkbtnDate.Text) <= DateTime.Now ? System.Drawing.Color.Red : System.Drawing.Color.Green;

        }

        if (e.Row.RowType == DataControlRowType.Footer)
        {
            LinkButton lnkAdd_EHS_Date = new LinkButton();
            // set properties of text box
            lnkAdd_EHS_Date.Text = "--Add--";
            lnkAdd_EHS_Date.OnClientClick = "javascript:return OpenUserEHSDates('" + Encryption.Encrypt("0") + "','" + Encryption.Encrypt(Convert.ToString(PK_RLCM)) + "');";
            e.Row.Cells[0].Controls.Add(lnkAdd_EHS_Date);
            e.Row.BackColor = System.Drawing.Color.White;
        }
    }

    /// <summary>
    /// Refresh button
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnRefresh_Click(object sender, EventArgs e)
    {
        BindData();
    }

    #endregion

    #region ::Item Temple for dynamic grid::

    class HyperlinkColumn : ITemplate
    {
        public void InstantiateIn(System.Web.UI.Control container)
        {
            LinkButton hypLink = new LinkButton();
            hypLink.ID = "hypLink";
            container.Controls.Add(hypLink);
        }
    }

    #endregion

}