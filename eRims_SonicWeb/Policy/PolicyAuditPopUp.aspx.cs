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

public partial class Policy_PolicyAuditPopUp : clsBasePage
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
            divPolicy_Header.Visible = false;
            divPolicy_Grid.Visible = false;

            //Size textSize = System.Windows.Forms.TextRenderer.MeasureText("How long am I?");                       
            // Check if parameter id and table name is exists or not.
            if (Request.QueryString["id"] != null)
            {
                //lbltable_Name.Text = (Request.QueryString["id"] + " < - > " + Request.QueryString["Table_Name"]);
                BindPolicy_Audit();
                
            }
        }
    }
    
    /// <summary>
    /// this function is use full when Audit trail is from General Security transaction Table 
    /// </summary>
    private void BindPolicy_Audit()
    {
        DataTable dt = new DataTable();
        divPolicy_Grid.Visible = true;
        lbltable_Name.Text = "Policy_Audit";

        // Fill grid with audit table
        dt = AuditTrail.GetPolicy_AuditView(PK).Tables[0];
        gvPolicy.DataSource = dt;
        gvPolicy.DataBind();

        // Check if record found or not.
        if (dt.Rows.Count > 0)
        {
            // set Gridview div height and width on client side. 
            Page.ClientScript.RegisterStartupScript(Page.GetType(), System.DateTime.Now.ToString(), "javacript:showAudit(" + divPolicy_Header.ClientID + "," + divPolicy_Grid.ClientID + ");", true);

            // set Gridview div Scroll bar events so Scroll Header as per grid scroll
            divPolicy_Grid.Attributes.Add("onscroll", "javascript:ChangeScrollBar(this," + divPolicy_Header.ClientID + ");");
            divPolicy_Header.Visible = true;
        }
        else
        {
            // if record not found then hide Header and set width and height so scroll bar not visible.
            divPolicy_Grid.Style["height"] = Unit.Pixel(50).ToString();
            divPolicy_Grid.Style["width"] = "100%";
            divPolicy_Grid.Style["overflow"] = "hidden";
        }


        dt.Dispose();
        dt = null;
    }
}
