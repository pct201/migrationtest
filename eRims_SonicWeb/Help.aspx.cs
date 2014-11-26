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

public partial class Help : System.Web.UI.Page
{
    #region "Page Event"

    /// <summary>
    /// Page Load Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        //check Is Page Post Back
        if (!IsPostBack)
        {
            //Bind Grid Function
            BindGrid();
        }
    }

    #endregion

    #region "Grid Event"

    /// <summary>
    /// Event for paging
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvUser_Help_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvUser_Help.PageIndex = e.NewPageIndex; //Page new index call
        BindGrid();
    }

    protected void gvUser_Help_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (e.Row.FindControl("aURL") != null)
            {
                HtmlAnchor aURL = ((HtmlAnchor)e.Row.FindControl("aURL"));
                string URL = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "URL"));
                string strTpye = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Type"));
                //if (URL.Contains("http://"))
                //    aURL.HRef = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "URL")) + "?DateTime=" + DateTime.Now.ToString("yyyyMMddHHmmss");
                //else
                //    aURL.HRef = "http://" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "URL")) + "?DateTime=" + DateTime.Now.ToString("yyyyMMddHHmmss");
                if (strTpye.ToLower() == "how to video")
                {
                    if (URL.Contains("http://"))
                        aURL.HRef = AppConfig.SiteURL + "\\Video_Stream_Play.aspx?path=" + Encryption.Encrypt(URL);
                    else
                        aURL.HRef = AppConfig.SiteURL + "\\Video_Stream_Play.aspx?path=" + Encryption.Encrypt("http://" + URL);
                }
                else
                {
                    if (URL.Contains("http://"))
                        aURL.HRef = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "URL"));
                    else
                        aURL.HRef = "http://" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "URL"));
                }
            }
        }
    }

    #endregion

    #region Methods
    /// <summary>
    /// Bind Manufacturer Grid
    /// </summary>
    private void BindGrid()
    {
        //Get Record into Dataset
        DataTable dtHelp = UserHelp.SelectAll().Tables[0];
        dtHelp.DefaultView.RowFilter = "Active='Y'";

        //Apply Dataset to Grid
        gvUser_Help.DataSource = dtHelp.DefaultView;
        gvUser_Help.DataBind();
    }

    #endregion    
}
