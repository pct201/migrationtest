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


public partial class SONIC_CRM_AuditPopup_CRM_Customer : clsBasePage
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
            divNonCustomer_Grid.Visible = false;
            divNonCustomer_Header.Visible = false;
            // Check if parameter id and table name is exists or not.
            if (Request.QueryString["id"] != null)
            {
                // Check Table_name parameter and as per table_name show Audit trial for that table
                BindNonCustomer_Audit();
            }
        }
    }
    #endregion

    #region "Mehods"
    /// <summary>
    /// this function is use full when Audit trail is from Franchise Table 
    /// </summary>
    private void BindNonCustomer_Audit()
    {
        DataTable dt = new DataTable();
        // show Case Grid 
        divNonCustomer_Grid.Visible = true;
        lbltable_Name.Text = "CRM Customer";
        // Fill grid with audit table
        dt = AuditTrail.GetCRM_Customer_AuditTrial(PK).Tables[0];
        gvNonCustomer.DataSource = dt;
        gvNonCustomer.DataBind();
        // Check if record found or not.
        if (dt.Rows.Count > 0)
        {
            // set Gridview div height and width on client side. 
            Page.ClientScript.RegisterStartupScript(Page.GetType(), System.DateTime.Now.ToString(), "javacript:showAudit(" + divNonCustomer_Header.ClientID + "," + divNonCustomer_Grid.ClientID + ");", true);

            // set Gridview div Scroll bar events so Scroll Header as per grid scroll
            divNonCustomer_Grid.Attributes.Add("onscroll", "javascript:ChangeScrollBar(this," + divNonCustomer_Header.ClientID + ");");
            divNonCustomer_Header.Visible = true;
        }
        else
        {
            // if record not found then hide Header and set width and height so scroll bar not visible.
            divNonCustomer_Grid.Style["height"] = Unit.Pixel(50).ToString();
            divNonCustomer_Grid.Style["width"] = "100%";
            divNonCustomer_Grid.Style["overflow"] = "hidden";
        }
        dt.Dispose();
        dt = null;
    }

    #endregion
}