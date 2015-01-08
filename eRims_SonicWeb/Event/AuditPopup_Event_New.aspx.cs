using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Event_AuditPopup_New_Event : System.Web.UI.Page
{
    #region " Properties "

    /// <summary>
    /// Used To manupulate primary key Parameter
    /// </summary>
    public int PK
    {
        get { return (!clsGeneral.IsNull(Request.QueryString["id"]) ? Convert.ToInt32(Request.QueryString["id"]) : -1); }
    }
    #endregion

    #region "Page Load"

    /// <summary>
    /// Page Load
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            divgvEvent_Audit_Grid.Visible = false;
            divgv_Event_Header.Visible = false;

            // Check if parameter id and table name is exists or not.
            if (Request.QueryString["id"] != null)
            {
                // Check Table_name parameter and as per table_name show Audit trial for that table
                BindAudiData();
            }
        }
    }


    #endregion

    #region "Method"

    /// <summary>
    /// this function is use full when Audit trail is from Purchasing Services Contract Table 
    /// </summary>
    private void BindAudiData()
    {
        DataTable dt = new DataTable();

        // show Case Grid 
        divgvEvent_Audit_Grid.Visible = true;
        lbltable_Name.Text = "Event Audit";

        // Fill grid with audit table
        dt = Audit_Trail.GetEvent_AuditTrail_New(PK).Tables[0];
        gvEvent_Audit.DataSource = dt;
        gvEvent_Audit.DataBind();


        // Check if record found or not.
        if (dt.Rows.Count > 0)
        {
            // set Gridview div height and width on client side. 
            Page.ClientScript.RegisterStartupScript(Page.GetType(), System.DateTime.Now.ToString(), "javacript:showAudit(" + divgv_Event_Header.ClientID + "," + divgvEvent_Audit_Grid.ClientID + ");", true);

            // set Gridview div Scroll bar events so Scroll Header as per grid scroll
            divgvEvent_Audit_Grid.Attributes.Add("onscroll", "javascript:ChangeScrollBar(this,document.getElementById('" + divgv_Event_Header.ClientID + "'));");
            divgv_Event_Header.Visible = true;
        }
        else
        {
            // if record not found then hide Header and set width and height so scroll bar not visible.
            divgvEvent_Audit_Grid.Style["height"] = Unit.Pixel(50).ToString();
            divgvEvent_Audit_Grid.Style["width"] = "600";
            divgvEvent_Audit_Grid.Style["overflow"] = "hidden";
        }

        dt.Dispose();
        dt = null;
    }

    #endregion
}