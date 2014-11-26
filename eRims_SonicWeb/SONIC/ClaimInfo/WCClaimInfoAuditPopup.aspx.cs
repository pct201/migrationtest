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

public partial class SONIC_ClaimInfo_WCClaimInfoAuditPopup : System.Web.UI.Page
{
    /// <summary>
    /// Used To manupulate primary key Parameter
    /// </summary>
    public int PK
    {
        get { return (!clsGeneral.IsNull(Request.QueryString["id"]) ? Convert.ToInt32(Request.QueryString["id"]) : -1); }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            divWorkers_Comp_RMW_Audit_Grid.Visible = false;
            divWorkers_Comp_RMW_Audit_Header.Visible = false;

            //Size textSize = System.Windows.Forms.TextRenderer.MeasureText("How long am I?");                       
            // Check if parameter id and table name is exists or not.
            if (Request.QueryString["id"] != null)
            {
                //lbltable_Name.Text = (Request.QueryString["id"] + " < - > " + Request.QueryString["Table_Name"]);
                BindWorkers_Comp_RMW_Audit();

            }
        }
    }

    /// <summary>
    /// this function is use full when Audit trail is from General Security transaction Table 
    /// </summary>
    private void BindWorkers_Comp_RMW_Audit()
    {
        DataTable dt = new DataTable();
        divWorkers_Comp_RMW_Audit_Grid.Visible = true;
        lbltable_Name.Text = "Workers_Comp_RMW_Audit";

        // Fill grid with audit table
        dt = Audit_Trail.GetWorkers_Comp_RMW_Audit(PK).Tables[0];
        gvWorkers_Comp_RMW_Audit.DataSource = dt;
        gvWorkers_Comp_RMW_Audit.DataBind();

        // Check if record found or not.
        if (dt.Rows.Count > 0)
        {
            // set Gridview div height and width on client side. 
            Page.ClientScript.RegisterStartupScript(Page.GetType(), System.DateTime.Now.ToString(), "javacript:showAudit(" + divWorkers_Comp_RMW_Audit_Header.ClientID + "," + divWorkers_Comp_RMW_Audit_Grid.ClientID + ");", true);

            // set Gridview div Scroll bar events so Scroll Header as per grid scroll
            divWorkers_Comp_RMW_Audit_Grid.Attributes.Add("onscroll", "javascript:ChangeScrollBar(this," + divWorkers_Comp_RMW_Audit_Header.ClientID + ");");
            divWorkers_Comp_RMW_Audit_Header.Visible = true;
        }
        else
        {
            // if record not found then hide Header and set width and height so scroll bar not visible.
            divWorkers_Comp_RMW_Audit_Grid.Style["height"] = Unit.Pixel(50).ToString();
            divWorkers_Comp_RMW_Audit_Grid.Style["width"] = "100%";
            divWorkers_Comp_RMW_Audit_Grid.Style["overflow"] = "hidden";
        }


        dt.Dispose();
        dt = null;
    }
}
