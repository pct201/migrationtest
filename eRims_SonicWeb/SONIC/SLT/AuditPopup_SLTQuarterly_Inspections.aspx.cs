using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERIMS.DAL;
using System.Data;
public partial class SONIC_SLT_AuditPopup_SLTQuarterly_Inspections : clsBasePage
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
            divSLTQuarterly_Inspections_Grid.Visible = false;
            divSLTQuarterly_InspectionsHeader.Visible = false;
            // Check if parameter id and table name is exists or not.
            if (Request.QueryString["id"] != null)
            {
                // Check Table_name parameter and as per table_name show Audit trial for that table
                Bind_Audit_Trail_Grid();
            }

        }
    }
    #endregion

    #region "Mehods"
    /// <summary>
    /// this function is use full when Audit trail is from Franchise Table 
    /// </summary>
    private void Bind_Audit_Trail_Grid()
    {
        DataTable dt = new DataTable();
        // show Case Grid 
        divSLTQuarterly_Inspections_Grid.Visible = true;
        lbltable_Name.Text = "SLT Quarterly Inspections";
        // Fill grid with audit table
        dt = AuditTrail.GetSLT_Quarterly_Inspections_AuditTrial(PK).Tables[0];
        gvSIUtilityProvider.DataSource = dt;
        gvSIUtilityProvider.DataBind();
        // Check if record found or not.
        if (dt.Rows.Count > 0)
        {
            // set Gridview div height and width on client side. 
            Page.ClientScript.RegisterStartupScript(Page.GetType(), System.DateTime.Now.ToString(), "javascript:showAudit(" + divSLTQuarterly_InspectionsHeader.ClientID + "," + divSLTQuarterly_Inspections_Grid.ClientID + ");", true);

            // set Gridview div Scroll bar events so Scroll Header as per grid scroll
            divSLTQuarterly_Inspections_Grid.Attributes.Add("onscroll", "javascript:ChangeScrollBar(this," + divSLTQuarterly_InspectionsHeader.ClientID + ");");
            divSLTQuarterly_InspectionsHeader.Visible = true;
        }
        else
        {
            // if record not found then hide Header and set width and height so scroll bar not visible.
            divSLTQuarterly_Inspections_Grid.Style["height"] = Unit.Pixel(50).ToString();
            divSLTQuarterly_Inspections_Grid.Style["width"] = "100%";
            divSLTQuarterly_Inspections_Grid.Style["overflow"] = "hidden";
        }
        dt.Dispose();
        dt = null;
    }

    #endregion
}