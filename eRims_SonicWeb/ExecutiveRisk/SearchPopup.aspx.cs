using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using ERIMS.DAL;

public partial class ExecutiveRisk_SearchPopup : System.Web.UI.Page
{

    DataTable dtSearch = null;
   

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (!IsPostBack)
            {
                BindGrid();
                // check whether the textbox ID of the caller form 
                // is passed for setting the value if required or not
                if (Request.QueryString["txtID"] != null)
                {
                    // store the ID in hidden field
                    hdnID.Value = Request.QueryString["txtID"].ToString();
                }
                // is passed for setting the value if required or not
                if (Request.QueryString["lblID"] != null)
                {
                    // store the ID in hidden field
                    hdnLblID.Value = Request.QueryString["lblID"].ToString();
                }
            }

        }
    }

    private void BindGrid()
    {
        dtSearch = Entity.SelectForExecutiveRisk().Tables[0];     
        gvSearch.DataSource = dtSearch;
        gvSearch.DataBind();

    }

    protected void gvSearch_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //e.Row.Cells[0].Visible = false;
            for (int i = 1; i < dtSearch.Columns.Count; i++)
            {
                string strID = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "PK_LU_Location_ID"));
                string strEntity = Convert.ToString(DataBinder.Eval(e.Row.DataItem,"Entity"));

                HtmlAnchor a = (HtmlAnchor)e.Row.FindControl("lnkEntity");

                if (Request.QueryString["txtID"] != null)
                {
                    a.HRef = "javascript:SetValue(" + strID + ",'" + strEntity + "','');";
                }
            }
        }
    }

    protected void gvSearch_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvSearch.PageIndex = e.NewPageIndex;
        BindGrid();
    }
}
