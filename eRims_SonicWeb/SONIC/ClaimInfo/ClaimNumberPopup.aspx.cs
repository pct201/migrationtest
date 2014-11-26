using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.UI.HtmlControls;

public partial class SONIC_ClaimInfo_ClaimNumberPopup : System.Web.UI.Page
{

    /// <summary>
    /// Page Load Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
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
        //check FirstName Textbox and last name textbox empty or not
        if (ddlSonicDBA.SelectedIndex > 0)
        {
            DataSet dsClaimNumber = ERIMS.DAL.WC_ClaimInfo.SelectTPA_Claim_NumberByLocationdba(Convert.ToDecimal(ddlSonicDBA.SelectedValue), txtClaimNumber.Text.Trim());
            if (dsClaimNumber.Tables.Count > 0)
            {                                                                                                                     
                gvClaimNumber.DataSource = dsClaimNumber.Tables[0];
                gvClaimNumber.DataBind();
            }
        }
        else
        {
            DataSet dsClaimNumber = ERIMS.DAL.WC_ClaimInfo.SelectTPA_Claim_NumberByLocationdba(0, txtClaimNumber.Text.Trim());
            if (dsClaimNumber.Tables.Count > 0)
            {
                gvClaimNumber.DataSource = dsClaimNumber.Tables[0];
                gvClaimNumber.DataBind();
            }

        }
    }

    /// <summary>
    /// Grid Paging Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvClaimNumber_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvClaimNumber.PageIndex = e.NewPageIndex;
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
    protected void gvClaimNumber_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //find anchor Tag in grid control
            HtmlAnchor HA = e.Row.FindControl("ClaimNumber") as HtmlAnchor;
            //check HtmlAnchor is null or not
            if (HA != null)
            {
                HA.Attributes.Add("onclick", "ClosePopup('" + DataBinder.Eval(e.Row.DataItem, "Origin_Claim_Number").ToString().Replace("'", "\\'") + "');");
            }

            HtmlAnchor HAdba = e.Row.FindControl("ClaimLocation") as HtmlAnchor;
            if (HAdba != null)
            {
                HAdba.Attributes.Add("onclick", "ClosePopup('" + DataBinder.Eval(e.Row.DataItem, "Origin_Claim_Number").ToString().Replace("'", "\\'") + "');");
            }

        }
    }
}