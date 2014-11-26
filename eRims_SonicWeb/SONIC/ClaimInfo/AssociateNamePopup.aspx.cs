using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.UI.HtmlControls;

public partial class SONIC_ClaimInfo_AssociateNamePopup : System.Web.UI.Page
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
            BindGrid();
        }
    }


    /// <summary>
    /// Bind Grid functionality
    /// </summary>
    public void BindGrid()
    {
        //check FirstName Textbox and last name textbox empty or not
        DataSet dsAssociateName = ERIMS.DAL.WC_ClaimInfo.SelectAssociateName(txtAssociateName.Text.Trim() );
        if (dsAssociateName.Tables.Count > 0)
        {
            gvAssociateName.DataSource = dsAssociateName.Tables[0];
            gvAssociateName.DataBind();
        }

    }

    /// <summary>
    /// Grid Paging Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvAssociateName_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvAssociateName.PageIndex = e.NewPageIndex;
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
    protected void gvAssociateName_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //find anchor Tag in grid control
            HtmlAnchor HA = e.Row.FindControl("AssociateNameName") as HtmlAnchor;
            //check HtmlAnchor is null or not
            if (HA != null)
            {
                HA.Attributes.Add("onclick", "ClosePopup('" + DataBinder.Eval(e.Row.DataItem, "Employee_Name").ToString().Replace("'", "\\'") + "');");
            }



        }
    }

}