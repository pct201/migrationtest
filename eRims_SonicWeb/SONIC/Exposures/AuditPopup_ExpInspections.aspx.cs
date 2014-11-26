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
public partial class SONIC_Exposures_AuditPopup_ExpInspections : System.Web.UI.Page
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
                lbltable_Name.Text = "Inspection";

                // Fill grid with audit table
                dt = AuditTrail.GetInspection_AuditTrail(Convert.ToDecimal(Request.QueryString["id"]),Request.QueryString["focusarea"]).Tables[0];
                gvInspections.DataSource = dt;
                gvInspections.DataBind();

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

    protected void gvInspections_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblDepartment = (Label)e.Row.FindControl("lblDepartment");
            if (lblDepartment.Text != "")
            {
                string[] strDept = lblDepartment.Text.Split(',');
                string strDepartments = "";
                foreach (string str in strDept)
                {
                    strDepartments = strDepartments  + new LU_Department(Convert.ToDecimal(str)).Description + ",";
                }
                strDepartments = strDepartments.TrimEnd(',');
                lblDepartment.Text = strDepartments;
            }
            Label lblDefNoted = (Label)e.Row.FindControl("lblDeficiency_Noted");
            string strDef_Noted = lblDefNoted.Text;
            if (strDef_Noted == "Y")
                lblDefNoted.Text = "YES";
            else if (strDef_Noted == "N")
                lblDefNoted.Text = "NO";
        }
    }
}
