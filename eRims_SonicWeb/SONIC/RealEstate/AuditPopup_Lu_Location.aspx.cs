using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ERIMS.DAL;

public partial class SONIC_RealEstate_AuditPopup_Lu_Location : clsBasePage
{
    #region "Properties"

    /// <summary>
    /// Primary Key -Lu Location
    /// </summary>
    private decimal _PK_LU_Location
    {
        get { return (!clsGeneral.IsNull(ViewState["PK_LU_Location"]) ? Convert.ToDecimal(ViewState["PK_LU_Location"]) : 0); }
        set
        {
            ViewState["PK_LU_Location"] = value;
        }
    }

    #endregion

    #region "Page Events"

    /// <summary>
    /// Handle Page Load Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            dvGrid.Visible = false;
            dvHeader.Visible = false;
            _PK_LU_Location = 0;
            if (Request.QueryString["id"] != null)
            {
                decimal index;
                if (decimal.TryParse(Request.QueryString["id"], out index))
                {
                    _PK_LU_Location = index;
                    BindGrid();
                }
            }
        }
    }

    #endregion

    #region "Methods"

    /// <summary>
    /// Bind Audit Records by PK
    /// </summary>
    private void BindGrid()
    {
        dvGrid.Visible = true;
        lbltable_Name.Text = "LU_Location";

        DataTable dt = LU_Location.SelectAuditByPK(_PK_LU_Location).Tables[0]; 
        gvLocation.DataSource = dt;
        gvLocation.DataBind();

        // Check if record found or not.
        if (dt.Rows.Count > 0)
        {
            // set Gridview div height and width on client side. 
            Page.ClientScript.RegisterStartupScript(Page.GetType(), System.DateTime.Now.ToString(), "javacript:showAudit(" + dvHeader.ClientID + "," + dvGrid.ClientID + ");", true);

            // set Gridview div Scroll bar events so Scroll Header as per grid scroll
            dvGrid.Attributes.Add("onscroll", "javascript:ChangeScrollBar(this," + dvHeader.ClientID + ");");
            dvHeader.Visible = true;
        }
        else
        {
            // if record not found then hide Header and set width and height so scroll bar not visible.
            dvGrid.Style["height"] = Unit.Pixel(50).ToString();
            dvGrid.Style["width"] = "100%";
            dvGrid.Style["overflow"] = "hidden";
        }

        dt.Dispose();
        dt = null;
    }

    #endregion
}
