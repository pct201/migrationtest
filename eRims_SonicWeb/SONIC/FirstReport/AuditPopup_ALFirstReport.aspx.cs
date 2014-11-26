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

public partial class SONIC_FirstReport_AuditPopup_ALFirstReport : System.Web.UI.Page
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
            
            divAL_FR_Audit_Grid.Visible = false;
            divAL_FR_Audit_Header.Visible = false;

            // Check if parameter id and table name is exists or not.
            if (Request.QueryString["id"] != null)
            {

                // Check Table_name parameter and as per table_name show Audit trial for that table
                    BindALFirstReport_Audit();
            }
        }
    }
    
    /// <summary>
    /// this function is use full when Audit trail is from AL_Audit table
    /// </summary>
    private void BindALFirstReport_Audit()
    {
        DataTable dt = new DataTable();

        // show Case Grid 
        divAL_FR_Audit_Grid.Visible = true;
        lbltable_Name.Text = "AL_FR";

        // Fill grid with audit table
        dt = AuditTrail.GetAL_FR_AuditTrial(PK).Tables[0];
        gvAL_FR_Audit.DataSource = dt;
        gvAL_FR_Audit.DataBind();

        // Check if record found or not.
        if (dt.Rows.Count > 0)
        {
            // set Gridview div height and width on client side. 
            Page.ClientScript.RegisterStartupScript(Page.GetType(), System.DateTime.Now.ToString(), "javacript:showAudit(" + divAL_FR_Audit_Header.ClientID + "," + divAL_FR_Audit_Grid.ClientID + ");", true);

            // set Gridview div Scroll bar events so Scroll Header as per grid scroll
            divAL_FR_Audit_Grid.Attributes.Add("onscroll", "javascript:ChangeScrollBar(this," + divAL_FR_Audit_Header.ClientID + ");");
            divAL_FR_Audit_Header.Visible = true;
        }
        else
        {
            // if record not found then hide Header and set width and height so scroll bar not visible.
            divAL_FR_Audit_Grid.Style["height"] = Unit.Pixel(50).ToString();
            divAL_FR_Audit_Grid.Style["width"] = "100%";
            divAL_FR_Audit_Grid.Style["overflow"] = "hidden";
        }

        dt.Dispose();
        dt = null;
    }
}
