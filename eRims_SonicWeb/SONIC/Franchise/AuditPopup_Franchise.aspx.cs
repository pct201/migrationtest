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
public partial class SONIC_Franchise_AuditPopup_Franchise : clsBasePage
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
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            divFranchise_Grid.Visible = false;
            divFranchise_Header.Visible = false;
            // Check if parameter id and table name is exists or not.
            if (Request.QueryString["id"] != null)
            {            
                // Check Table_name parameter and as per table_name show Audit trial for that table
                BindFranchise_Audit();
            }
        }
    }
    #endregion

    #region "Mehods"
    /// <summary>
    /// this function is use full when Audit trail is from Franchise Table 
    /// </summary>
    private void BindFranchise_Audit()
    {
        DataTable dt = new DataTable();
        // show Case Grid 
        divFranchise_Grid.Visible = true;
        lbltable_Name.Text = "Franchise";
        // Fill grid with audit table
        dt = AuditTrail.GetFranchise_AuditTrial(PK).Tables[0];
        gvFranchise.DataSource = dt;
        gvFranchise.DataBind();
        // Check if record found or not.
        if (dt.Rows.Count > 0)
        {
            // set Gridview div height and width on client side. 
            Page.ClientScript.RegisterStartupScript(Page.GetType(), System.DateTime.Now.ToString(), "javacript:showAudit(" + divFranchise_Header.ClientID + "," + divFranchise_Grid.ClientID + ");", true);

            // set Gridview div Scroll bar events so Scroll Header as per grid scroll
            divFranchise_Grid.Attributes.Add("onscroll", "javascript:ChangeScrollBar(this," + divFranchise_Header.ClientID + ");");
            divFranchise_Header.Visible = true;
        }
        else
        {
            // if record not found then hide Header and set width and height so scroll bar not visible.
            divFranchise_Grid.Style["height"] = Unit.Pixel(50).ToString();
            divFranchise_Grid.Style["width"] = "100%";
            divFranchise_Grid.Style["overflow"] = "hidden";
        }
        dt.Dispose();
        dt = null;
    }
    
    #endregion
}
