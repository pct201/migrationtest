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

public partial class SONIC_RealEstate_AuditPopup_RE_RentProjections_ORS : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            dvGrid.Visible = false;
            dvHeader.Visible = false;

            // Check if parameter id and table name is exists or not.
            if (Request.QueryString["id"] != null)
            {
                DataTable dt = new DataTable();

                // show Case Grid 
                dvGrid.Visible = true;
                lbltable_Name.Text = "RE_Rent_Projections_ORS";

                // Fill grid with audit table
                dt = AuditTrail.GetRE_Rent_Projctions_ORS_AuditTrail(Convert.ToDecimal(Request.QueryString["id"])).Tables[0];
                gvRent_Projections_ORS.DataSource = dt;
                gvRent_Projections_ORS.DataBind();

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
        }
    }
}
