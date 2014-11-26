using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERIMS.DAL;
using System.Data;

public partial class SONIC_SLT_AuditPopup_IncidentReview : clsBasePage
{
    # region " Properties "

    /// <summary>
    /// Used To manupulate primary key Parameter
    /// </summary>
    public int PK
    {
        get { return (!clsGeneral.IsNull(Request.QueryString["id"]) ? Convert.ToInt32(Request.QueryString["id"]) : -1); }
    }
    public string FR_Name
    {
        get { return Convert.ToString(ViewState["fr_name"]); }
        set { ViewState["fr_name"] = value; }
    }
    #endregion

    #region "Page Event"
    /// <summary>
    /// Page Load Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            divIncidentReview_Grid.Visible = false;
            divIncidentReviewHeader.Visible = false;
            if (Request.QueryString["name"] != null)
            {
                FR_Name = Request.QueryString["name"].ToString();
            }
            if (FR_Name == "WC")
                FR_Name = "Workers Compensation Incidents";
            else if (FR_Name == "AL")
                FR_Name = "Auto Liability Incidents";
            else if (FR_Name == "PL")
                FR_Name = "Premise Liability Incidents";
            else if (FR_Name == "DPD")
                FR_Name = "Dealers Physical Damage Liability Incidents";
            else if (FR_Name == "PROPERTY")
                FR_Name = "Property Incidents";
            // Check if parameter id and table name is exists or not.
            if (Request.QueryString["id"] != null)
            {
                // Check Table_name parameter and as per table_name show Audit trial for that table
                BindIncidentReview_Audit();
            }

        }
    }
    #endregion

    #region "Mehods"
    /// <summary>
    /// this function is use full when Audit trail is from Franchise Table 
    /// </summary>
    private void BindIncidentReview_Audit()
    {
        DataTable dt = new DataTable();
        // show Case Grid 
        divIncidentReview_Grid.Visible = true;
        lbltable_Name.Text = "Incident Review : " + FR_Name;
        // Fill grid with audit table
        dt = AuditTrail.GetSLT_Incident_Review_AuditTrial(PK).Tables[0];
        gvSIUtilityProvider.DataSource = dt;
        gvSIUtilityProvider.DataBind();
        // Check if record found or not.
        if (dt.Rows.Count > 0)
        {
            // set Gridview div height and width on client side. 
            Page.ClientScript.RegisterStartupScript(Page.GetType(), System.DateTime.Now.ToString(), "javascript:showAudit(" + divIncidentReviewHeader.ClientID + "," + divIncidentReview_Grid.ClientID + ");", true);

            // set Gridview div Scroll bar events so Scroll Header as per grid scroll
            divIncidentReview_Grid.Attributes.Add("onscroll", "javascript:ChangeScrollBar(this," + divIncidentReviewHeader.ClientID + ");");
            divIncidentReviewHeader.Visible = true;
        }
        else
        {
            // if record not found then hide Header and set width and height so scroll bar not visible.
            divIncidentReview_Grid.Style["height"] = Unit.Pixel(50).ToString();
            divIncidentReview_Grid.Style["width"] = "100%";
            divIncidentReview_Grid.Style["overflow"] = "hidden";
        }
        dt.Dispose();
        dt = null;
    }

    #endregion
}