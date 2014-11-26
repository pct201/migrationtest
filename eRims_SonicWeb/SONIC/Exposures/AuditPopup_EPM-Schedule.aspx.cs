using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class SONIC_Exposures_AuditPopup_EPM_Schedule : clsBasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {

        dvGrid.Visible = false;
        dvHeader.Visible = false;

        // Check if parameter id and table name is exists or not.
        if (!string.IsNullOrEmpty(Request.QueryString["id"]))
        {
            DataTable dt = new DataTable();

            // show Case Grid 
            dvGrid.Visible = true;
            lbltable_Name.Text = "Action And Notes";

            // Fill grid with audit table
            dt = AuditTrail.GetSchedule_AuditTrial(Convert.ToDecimal(Request.QueryString["id"])).Tables[0];
            gvSchedule.DataSource = dt;
            gvSchedule.DataBind();

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