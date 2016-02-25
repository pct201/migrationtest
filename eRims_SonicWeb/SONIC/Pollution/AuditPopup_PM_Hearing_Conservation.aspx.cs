using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ERIMS.DAL;

public partial class SONIC_Pollution_AuditPopup_PM_Hearing_Conservation : clsBasePage
{
    #region "Properties"
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
    /// Page Load Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            divPM_Hearing_Conservation_Audit_Grid.Visible = false;
            divPM_Hearing_Conservation_Audit_Header.Visible = false;
            // Check if parameter id and table name is exists or not.
            if (Request.QueryString["id"] != null)
            {
                //lbltable_Name.Text = (Request.QueryString["id"] + " < - > " + Request.QueryString["Table_Name"]);
                BindPM_Hearing_Conservation_Audit();
                BindAP_Property_Security_Financial_Audit();

            }
        }
    }

    private void BindAP_Property_Security_Financial_Audit()
    {
        DataTable dt = new DataTable();

        // show Case Grid 
        dvGrid.Visible = true;
        lbltable_Name.Text = "Pollution Module – Hearing Conversation Audit Trail";

        // Fill grid with audit table
        dt = PM_Hearing_Conservation.GetPM_Hearing_Conservation_Buildings_AuditTrail(PK).Tables[0];
        gvPM_Hearing_Conservation_Biuldings_Audit.DataSource = dt;
        gvPM_Hearing_Conservation_Biuldings_Audit.DataBind();

        // Check if record found or not.
        if (dt.Rows.Count > 0)
        {
            // set Gridview div height and width on client side. 
            Page.ClientScript.RegisterStartupScript(Page.GetType(), System.DateTime.Now.ToString(), "javacript:showAudit_Financial(" + dvHeader.ClientID + "," + dvGrid.ClientID + ");", true);

            // set Gridview div Scroll bar events so Scroll Header as per grid scroll
            dvGrid.Attributes.Add("onscroll", "javascript:ChangeScrollBar_Financial(this," + dvHeader.ClientID + ");");
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
    #endregion

    #region "Methods"
    /// <summary>
    /// Bind AP_AL_FROIs_Audit
    /// </summary>
    private void BindPM_Hearing_Conservation_Audit()
    {
        DataTable dt = new DataTable();
        divPM_Hearing_Conservation_Audit_Grid.Visible = true;
        lblPM_Hearing_Conservation_Buildings.Text = "PM Hearing Conversation Audit Trail";
        // Fill grid with audit table
        dt = PM_Hearing_Conservation.GetPM_Hearing_Conservation_Audit(PK).Tables[0];
        gvPM_Hearing_Conservation_Audit.DataSource = dt;
        gvPM_Hearing_Conservation_Audit.DataBind();

        // Check if record found or not.
        if (dt.Rows.Count > 0)
        {
            // set Gridview div height and width on client side. 
            Page.ClientScript.RegisterStartupScript(Page.GetType(), System.DateTime.Now.ToString(), "javacript:showAudit(" + divPM_Hearing_Conservation_Audit_Header.ClientID + "," + divPM_Hearing_Conservation_Audit_Grid.ClientID + ");", true);

            // set Gridview div Scroll bar events so Scroll Header as per grid scroll
            divPM_Hearing_Conservation_Audit_Grid.Attributes.Add("onscroll", "javascript:ChangeScrollBar(this," + divPM_Hearing_Conservation_Audit_Header.ClientID + ");");
            divPM_Hearing_Conservation_Audit_Header.Visible = true;
        }
        else
        {
            // if record not found then hide Header and set width and height so scroll bar not visible.
            divPM_Hearing_Conservation_Audit_Grid.Style["height"] = Unit.Pixel(50).ToString();
            divPM_Hearing_Conservation_Audit_Grid.Style["width"] = "100%";
            divPM_Hearing_Conservation_Audit_Grid.Style["overflow"] = "hidden";
        }


        dt.Dispose();
        dt = null;
    }

    #endregion
}