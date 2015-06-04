using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;


public partial class SONIC_Exposures_AuditPopup_PA_Values_Imported : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // Check if parameter id and table name is exists or not.
            if (!string.IsNullOrEmpty(Request.QueryString["id"].ToString()))
            {
                //lbltable_Name.Text = (Request.QueryString["id"] + " < - > " + Request.QueryString["Table_Name"]);
                BindAP_Property_Security_Financial_Audit();

            }
        }
    }
    private void BindAP_Property_Security_Financial_Audit()
    {
        DataTable dt = new DataTable();

        // show Case Grid 
        dvGrid.Visible = true;
        lbltable_Name.Text = "Premium Allocation Base Data";

        // Fill grid with audit table
        dt = AuditTrail.GetPA_Values_ImportedAuditTrail(Convert.ToDecimal(Request.QueryString["id"])).Tables[0];
        gvAP_Property_Security_Financials.DataSource = dt;
        gvAP_Property_Security_Financials.DataBind();

        // Check if record found or not.
        if (dt.Rows.Count > 0)
        {
            // set Gridview div height and width on client side. 
            Page.ClientScript.RegisterStartupScript(Page.GetType(), System.DateTime.Now.ToString(), "javacript:showAudit_Financial(" + dvHeader.ClientID + "," + dvGrid.ClientID + ");", true);

            // set Gridview div Scroll bar events so Scroll Header as per grid scroll
            dvGrid.Attributes.Add("onscroll", "javascript:ChangeScrollBar_Financial(this," + dvHeader.ClientID + ");");
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