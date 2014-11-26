using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class SONIC_Exposures_AuditPopup_AP_Fraud_Events : System.Web.UI.Page
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
            divAP_Fraud_Events_Audit_Grid.Visible = false;
            divAP_Fraud_Events_Audit_Header.Visible = false;
            // Check if parameter id and table name is exists or not.
            if (Request.QueryString["id"] != null)
            {
                //lbltable_Name.Text = (Request.QueryString["id"] + " < - > " + Request.QueryString["Table_Name"]);
                BindAP_Fraud_Events_Audit();

            }
        }
    }
    #endregion

    #region "Methods"
    /// <summary>
    /// Bind AP_AL_FROIs_Audit
    /// </summary>
    private void BindAP_Fraud_Events_Audit()
    {
        DataTable dt = new DataTable();
        divAP_Fraud_Events_Audit_Grid.Visible = true;
        lbltable_Name.Text = "AP Fraud Events Audit Trail";
        // Fill grid with audit table
        dt = Audit_Trail.GetAP_Fraud_Events_Audit(PK).Tables[0];
        gvAP_Fraud_Events_Audit.DataSource = dt;
        gvAP_Fraud_Events_Audit.DataBind();

        // Check if record found or not.
        if (dt.Rows.Count > 0)
        {
            // set Gridview div height and width on client side. 
            Page.ClientScript.RegisterStartupScript(Page.GetType(), System.DateTime.Now.ToString(), "javacript:showAudit(" + divAP_Fraud_Events_Audit_Header.ClientID + "," + divAP_Fraud_Events_Audit_Grid.ClientID + ");", true);

            // set Gridview div Scroll bar events so Scroll Header as per grid scroll
            divAP_Fraud_Events_Audit_Grid.Attributes.Add("onscroll", "javascript:ChangeScrollBar(this," + divAP_Fraud_Events_Audit_Header.ClientID + ");");
            divAP_Fraud_Events_Audit_Header.Visible = true;
        }
        else
        {
            // if record not found then hide Header and set width and height so scroll bar not visible.
            divAP_Fraud_Events_Audit_Grid.Style["height"] = Unit.Pixel(50).ToString();
            divAP_Fraud_Events_Audit_Grid.Style["width"] = "100%";
            divAP_Fraud_Events_Audit_Grid.Style["overflow"] = "hidden";
        }


        dt.Dispose();
        dt = null;
    }
    #endregion
}