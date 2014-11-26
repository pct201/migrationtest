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

public partial class SONIC_Exposures_AuditTrail_Recommendation : clsBasePage
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

            divRecommendation_Audit_Grid.Visible = false;
            divRecommendation_Audit_Header.Visible = false;

            // Check if parameter id and table name is exists or not.
            if (Request.QueryString["id"] != null)
            {
                // Check Table_name parameter and as per table_name show Audit trial for that table
                //if (Table_Name == "Adjustor_Notes")
                BindEnviro_Equipment();
            }
        }
    }

    /// <summary>
    /// this function is use full when Audit trail is from Defense_Attorney Table 
    /// </summary>
    private void BindEnviro_Equipment()
    {
        DataTable dt = new DataTable();

        // show Case Grid 
        divRecommendation_Audit_Grid.Visible = true;
        lbltable_Name.Text = "Recommendation";

        // Fill grid with audit table
        dt = AuditTrail.GetEnviro_Recommendations_AuditTrail(PK).Tables[0];
        gvRecommendation_Audit.DataSource = dt;
        gvRecommendation_Audit.DataBind();

        // Check if record found or not.
        if (dt.Rows.Count > 0)
        {
            // set Gridview div height and width on client side. 
            Page.ClientScript.RegisterStartupScript(Page.GetType(), System.DateTime.Now.ToString(), "javacript:showAudit(" + divRecommendation_Audit_Header.ClientID + "," + divRecommendation_Audit_Grid.ClientID + ");", true);

            // set Gridview div Scroll bar events so Scroll Header as per grid scroll
            divRecommendation_Audit_Grid.Attributes.Add("onscroll", "javascript:ChangeScrollBar(this," + divRecommendation_Audit_Header.ClientID + ");");
            divRecommendation_Audit_Header.Visible = true;
        }
        else
        {
            // if record not found then hide Header and set width and height so scroll bar not visible.
            divRecommendation_Audit_Grid.Style["height"] = Unit.Pixel(50).ToString();
            divRecommendation_Audit_Grid.Style["width"] = "100%";
            divRecommendation_Audit_Grid.Style["overflow"] = "hidden";
        }

        dt.Dispose();
        dt = null;
    }
}
