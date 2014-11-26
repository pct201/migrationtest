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

public partial class SONIC_ClaimInfo_PLClaimInfoAuditPopup : System.Web.UI.Page
{
    /// <summary>
    /// Used To manupulate primary key Parameter
    /// </summary>
    public int PK
    {
        get { return (!clsGeneral.IsNull(Request.QueryString["id"]) ? Convert.ToInt32(Request.QueryString["id"]) : -1); }
    }
    /// <summary>
    /// Page Load Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            divPremises_Loss_RMW_Audit_Grid.Visible = false;
            divPremises_Loss_RMW_Audit_Header.Visible = false;
                                          
            // Check if parameter id and table name is exists or not.
            if (Request.QueryString["id"] != null)
            {                
                BindPremises_Loss_RMW_Audit();
            }
        }
    }

    /// <summary>
    /// this function is use full when Audit trail is from General Security transaction Table 
    /// </summary>
    private void BindPremises_Loss_RMW_Audit()
    {
        DataTable dt = new DataTable();
        divPremises_Loss_RMW_Audit_Grid.Visible = true;
        lbltable_Name.Text = "Premises_Loss_RMW_Audit";

        // Fill grid with audit table
        dt = Audit_Trail.GetPremises_Loss_RMW_Audit(PK).Tables[0];
        gvPremises_Loss_RMW_Audit.DataSource = dt;
        gvPremises_Loss_RMW_Audit.DataBind();

        // Check if record found or not.
        if (dt.Rows.Count > 0)
        {
            // set Gridview div height and width on client side. 
            Page.ClientScript.RegisterStartupScript(Page.GetType(), System.DateTime.Now.ToString(), "javacript:showAudit(" + divPremises_Loss_RMW_Audit_Header.ClientID + "," + divPremises_Loss_RMW_Audit_Grid.ClientID + ");", true);

            // set Gridview div Scroll bar events so Scroll Header as per grid scroll
            divPremises_Loss_RMW_Audit_Grid.Attributes.Add("onscroll", "javascript:ChangeScrollBar(this," + divPremises_Loss_RMW_Audit_Header.ClientID + ");");
            divPremises_Loss_RMW_Audit_Header.Visible = true;
        }
        else
        {
            // if record not found then hide Header and set width and height so scroll bar not visible.
            divPremises_Loss_RMW_Audit_Grid.Style["height"] = Unit.Pixel(50).ToString();
            divPremises_Loss_RMW_Audit_Grid.Style["width"] = "100%";
            divPremises_Loss_RMW_Audit_Grid.Style["overflow"] = "hidden";
        }


        dt.Dispose();
        dt = null;
    }
}
