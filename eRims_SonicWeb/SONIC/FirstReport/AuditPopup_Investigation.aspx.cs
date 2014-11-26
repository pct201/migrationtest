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

public partial class SONIC_FirstReport_AuditPopup_Investigation : System.Web.UI.Page
{
    # region " Properties "

    /// <summary>
    /// Used To manupulate primary key Parameter
    /// </summary>
    public int PK
    {
        get { return (!clsGeneral.IsNull(Request.QueryString["id"]) ? Convert.ToInt32(Request.QueryString["id"]) : -1); }
    }

    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            divInvestigation_Audit_Grid.Visible = false;
            divInvestigation_Audit_Header.Visible = false;

            // Check if parameter id and table name is exists or not.
            if (Request.QueryString["id"] != null)
            {

                // Check Table_name parameter and as per table_name show Audit trial for that table
                BindInvestigation_Audit();
            }
        }
    }

    /// <summary>
    /// this function is use full when Audit trail is from AL_Audit table
    /// </summary>
    private void BindInvestigation_Audit()
    {
        DataTable dt = new DataTable();

        // show Case Grid 
        divInvestigation_Audit_Grid.Visible = true;
        lbltable_Name.Text = "Investigation";

        // Fill grid with audit table
        dt = AuditTrail.GetInvestigation_AuditTrial(PK).Tables[0];
        gvInvestigation_Audit.DataSource = dt;
        gvInvestigation_Audit.DataBind();

        // Check if record found or not.
        if (dt.Rows.Count > 0)
        {
            // set Gridview div height and width on client side. 
            Page.ClientScript.RegisterStartupScript(Page.GetType(), System.DateTime.Now.ToString(), "javacript:showAudit(" + divInvestigation_Audit_Header.ClientID + "," + divInvestigation_Audit_Grid.ClientID + ");", true);

            // set Gridview div Scroll bar events so Scroll Header as per grid scroll
            divInvestigation_Audit_Grid.Attributes.Add("onscroll", "javascript:ChangeScrollBar(this," + divInvestigation_Audit_Header.ClientID + ");");
            divInvestigation_Audit_Header.Visible = true;
        }
        else
        {
            // if record not found then hide Header and set width and height so scroll bar not visible.
            divInvestigation_Audit_Grid.Style["height"] = Unit.Pixel(50).ToString();
            divInvestigation_Audit_Grid.Style["width"] = "100%";
            divInvestigation_Audit_Grid.Style["overflow"] = "hidden";
        }

        dt.Dispose();
        dt = null;
    }
}
