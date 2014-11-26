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

public partial class SONIC_Exposures_AuditPopup_Building : System.Web.UI.Page
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
                lbltable_Name.Text = "Building";

                // Fill grid with audit table
                dt = AuditTrail.GetBuilding_AuditTrail(Convert.ToDecimal(Request.QueryString["id"])).Tables[0];
                gvBuilding.DataSource = dt;
                gvBuilding.DataBind();

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

                dt = AuditTrail.GetBuildingInsuranceCOPE_AuditTrail(Convert.ToDecimal(Request.QueryString["id"])).Tables[0];
                gvInsurance.DataSource = dt;
                gvInsurance.DataBind();
                hdnTotalInsuranceRecord.Value = "0";
                lblBuildingInsuranceCope.Text = "Building Insurance COPE";
                // Check if record found or not.
                if (dt.Rows.Count > 0)
                {
                    hdnTotalInsuranceRecord.Value = dt.Rows.Count.ToString();
                    // set Gridview div height and width on client side. 
                    //Page.ClientScript.RegisterStartupScript(Page.GetType(), System.DateTime.Now.ToString(), "javacript:showAudit(" + divInsuranceHeader.ClientID + "," + divInsuranceGrid.ClientID + ");", true);

                    // set Gridview div Scroll bar events so Scroll Header as per grid scroll
                    divInsuranceGrid.Attributes.Add("onscroll", "javascript:ChangeScrollBar_Insurance(this," + divInsuranceHeader.ClientID + ");");
                    divInsuranceHeader.Visible = true;
                }
                else
                {
                    // if record not found then hide Header and set width and height so scroll bar not visible.
                    divInsuranceGrid.Style["height"] = Unit.Pixel(50).ToString();
                    divInsuranceGrid.Style["width"] = "100%";
                    divInsuranceGrid.Style["overflow"] = "hidden";
                    divInsuranceHeader.Visible = false;
                }

                dt.Dispose();
                dt = null;
            }
        }
    }
}
