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

public partial class SONIC_Exposures_AuditPopup_Inspections : System.Web.UI.Page
{
    # region " Properties "

    ////<summary>
    ////used to manupulate Table_Name parameter
    ////</summary>
    public String Table_Name
    {
        get
        {
            return (!String.IsNullOrEmpty(Request.QueryString["Table_Name"]) ? Convert.ToString(Request.QueryString["Table_Name"]) : String.Empty);
        }
    }

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

            divInspection_Audit_Grid.Visible = false;
            divInspection_Audit_Header.Visible = false;

            // Check if parameter id is exists or not.
            if (Request.QueryString["id"] != null)
            {
                // show Audit trial for table                
                BindEnviro_Inspection();
            }
        }
    }

    /// <summary>
    /// this function is use full when Audit trail is from Defense_Attorney Table 
    /// </summary>
    private void BindEnviro_Inspection()
    {
        DataTable dt = new DataTable();

        // show Case Grid 
        divInspection_Audit_Grid.Visible = true;
        lbltable_Name.Text = "Inspections";

        // Fill grid with audit table
        dt = AuditTrail.GetEnviro_InspectionAuditTrail(PK).Tables[0];
        gvInspection_Audit.DataSource = dt;
        gvInspection_Audit.DataBind();

        // Check if record found or not.
        if (dt.Rows.Count > 0)
        {
            // set Gridview div height and width on client side. 
            Page.ClientScript.RegisterStartupScript(Page.GetType(), System.DateTime.Now.ToString(), "javacript:showAudit(" + divInspection_Audit_Header.ClientID + "," + divInspection_Audit_Grid.ClientID + ");", true);

            // set Gridview div Scroll bar events so Scroll Header as per grid scroll
            divInspection_Audit_Grid.Attributes.Add("onscroll", "javascript:ChangeScrollBar(this," + divInspection_Audit_Header.ClientID + ");");
            divInspection_Audit_Header.Visible = true;
        }
        else
        {
            // if record not found then hide Header and set width and height so scroll bar not visible.
            divInspection_Audit_Grid.Style["height"] = Unit.Pixel(50).ToString();
            divInspection_Audit_Grid.Style["width"] = "100%";
            divInspection_Audit_Grid.Style["overflow"] = "hidden";
        }

        dt.Dispose();
        dt = null;
    }
}
