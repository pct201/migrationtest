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


public partial class SONIC_Pollution_AuditPopup_PM_Waste_Removal : System.Web.UI.Page
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
            divPM_Waste_Removal_Grid.Visible = false;
            divPM_Waste_Removal_Header.Visible = false;
            // Check if parameter id and table name is exists or not.
            if (Request.QueryString["id"] != null)
            {
                // Check Table_name parameter and as per table_name show Audit trial for that table
                BindUtilityProvider_Audit();
            }
        }
    }
    #endregion

    #region "Mehods"
    /// <summary>
    /// this function is use full when Audit trail is from Franchise Table 
    /// </summary>
    private void BindUtilityProvider_Audit()
    {
        DataTable dt = new DataTable();
        // show Case Grid 
        divPM_Waste_Removal_Grid.Visible = true;
        lbltable_Name.Text = "PM Waste Generator";
        // Fill grid with audit table
        dt = PM_Waste_Removal.GetAuditView(PK).Tables[0];
        gvPMWasteRemoval.DataSource = dt;
        gvPMWasteRemoval.DataBind();
        // Check if record found or not.
        if (dt.Rows.Count > 0)
        {
            // set Gridview div height and width on client side. 
            Page.ClientScript.RegisterStartupScript(Page.GetType(), System.DateTime.Now.ToString(), "javacript:showAudit(" + divPM_Waste_Removal_Header.ClientID + "," + divPM_Waste_Removal_Grid.ClientID + ");", true);

            // set Gridview div Scroll bar events so Scroll Header as per grid scroll
            divPM_Waste_Removal_Grid.Attributes.Add("onscroll", "javascript:ChangeScrollBar(this," + divPM_Waste_Removal_Header.ClientID + ");");
            divPM_Waste_Removal_Header.Visible = true;
        }
        else
        {
            // if record not found then hide Header and set width and height so scroll bar not visible.
            divPM_Waste_Removal_Grid.Style["height"] = Unit.Pixel(50).ToString();
            divPM_Waste_Removal_Grid.Style["width"] = "100%";
            divPM_Waste_Removal_Grid.Style["overflow"] = "hidden";
        }
        dt.Dispose();
        dt = null;
    }

    #endregion
}