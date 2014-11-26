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

public partial class SONIC_FirstReport_AuditPopup_PLFirstReport : System.Web.UI.Page
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

            divPL_FR_Audit_Grid.Visible = false;
            divPL_FR_Audit_Header.Visible = false;

            // Check if parameter id and table name is exists or not.
            if (Request.QueryString["id"] != null)
            {
                //lbltable_Name.Text = (Request.QueryString["id"] + " < - > " + Request.QueryString["Table_Name"]);

                // Check Table_name parameter and as per table_name show Audit trial for that table
                    BindPLFirstReport_Audit();
            }
        }
    }

    /// <summary>
    /// this function is use full when Audit trail is from PL_FR Table 
    /// </summary>
    private void BindPLFirstReport_Audit()
    {
        DataTable dt = new DataTable();

        // show Case Grid 
        divPL_FR_Audit_Grid.Visible = true;
        lbltable_Name.Text = "PL_FR";

        // Fill grid with audit table
        dt = AuditTrail.GetPL_FR_AuditTrial(PK).Tables[0];
        gvPL_FR_Audit.DataSource = dt;
        gvPL_FR_Audit.DataBind();

        // Check if record found or not.
        if (dt.Rows.Count > 0)
        {
            // set Gridview div height and width on client side. 
            Page.ClientScript.RegisterStartupScript(Page.GetType(), System.DateTime.Now.ToString(), "javacript:showAudit(" + divPL_FR_Audit_Header.ClientID + "," + divPL_FR_Audit_Grid.ClientID + ");", true);

            // set Gridview div Scroll bar events so Scroll Header as per grid scroll
            divPL_FR_Audit_Grid.Attributes.Add("onscroll", "javascript:ChangeScrollBar(this," + divPL_FR_Audit_Header.ClientID + ");");
            divPL_FR_Audit_Header.Visible = true;
        }
        else
        {
            // if record not found then hide Header and set width and height so scroll bar not visible.
            divPL_FR_Audit_Grid.Style["height"] = Unit.Pixel(50).ToString();
            divPL_FR_Audit_Grid.Style["width"] = "100%";
            divPL_FR_Audit_Grid.Style["overflow"] = "hidden";
        }

        dt.Dispose();
        dt = null;
    }
}
