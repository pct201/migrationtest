using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.UI.HtmlControls;

public partial class Event_PopupFirstReport : System.Web.UI.Page
{

    /// <summary>
    /// Denotes the operation whether edit or view
    /// </summary>
    public string ClaimType
    {
        get { return Convert.ToString(ViewState["ClaimType"]); }
        set { ViewState["ClaimType"] = value; }
    }

    /// <summary>
    /// Page Load Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ClaimType = Convert.ToString(Request.QueryString["ftype"]);
            bindDropdownList();
            BindGrid();
        }
    }

    private void bindDropdownList()
    {
        ComboHelper.FillLocationDBA_All(new DropDownList[] { ddlSonicDBA }, 0, true);
        ddlSonicDBA.Style.Add("font-size", "x-small");
    }

    /// <summary>
    /// Bind Grid functionality
    /// </summary>
    public void BindGrid()
    {
        decimal FRNumber;
        FRNumber = txtFirstReportNumber.Text.Trim() == string.Empty ? 0 : Convert.ToDecimal(txtFirstReportNumber.Text);

        //check FirstName Textbox and last name textbox empty or not
        if (ddlSonicDBA.SelectedIndex > 0)
        {
            DataSet dsFRNumber = ERIMS.DAL.First_Report_Wizard.SearchFirstReportsForEvent(Convert.ToDecimal(ddlSonicDBA.SelectedValue), FRNumber, ClaimType);
            if (dsFRNumber.Tables.Count > 0)
            {
                gvFRNumber.DataSource = dsFRNumber.Tables[0];
                gvFRNumber.DataBind();
            }
        }
        else
        {
            DataSet dsFRNumber = ERIMS.DAL.First_Report_Wizard.SearchFirstReportsForEvent(0, FRNumber, ClaimType);
            if (dsFRNumber.Tables.Count > 0)
            {
                gvFRNumber.DataSource = dsFRNumber.Tables[0];
                gvFRNumber.DataBind();
            }

        }
    }

    /// <summary>
    /// Grid Paging Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvFRNumber_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvFRNumber.PageIndex = e.NewPageIndex;
        BindGrid();
    }
    /// <summary>
    /// Submit Button CLick
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        //Bind Grid For all data
        BindGrid();
    }
    protected void gvFRNumber_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //find anchor Tag in grid control
            HtmlAnchor HA = e.Row.FindControl("FRNumber") as HtmlAnchor;
            //check HtmlAnchor is null or not
            if (HA != null)
            {
                HA.Attributes.Add("onclick", "ClosePopup('" + DataBinder.Eval(e.Row.DataItem, "FR_Number").ToString().Replace("'", "\\'") + "','" + DataBinder.Eval(e.Row.DataItem, "PK_ID").ToString().Replace("'", "\\'") +"','" + ClaimType  + "');");
            }

            HtmlAnchor HAdba = e.Row.FindControl("FRLocation") as HtmlAnchor;
            if (HAdba != null)
            {
                HAdba.Attributes.Add("onclick", "ClosePopup('" + DataBinder.Eval(e.Row.DataItem, "FR_Number").ToString().Replace("'", "\\'") + "','" + DataBinder.Eval(e.Row.DataItem, "PK_ID").ToString().Replace("'", "\\'") + "','" + ClaimType + "');");
            }

        }
    }
}