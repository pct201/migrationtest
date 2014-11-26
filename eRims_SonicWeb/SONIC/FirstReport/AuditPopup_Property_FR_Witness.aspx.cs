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

public partial class SONIC_FirstReport_AuditPopup_Property_FR_Witness : System.Web.UI.Page
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

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            divProperty_FR_Witness_Grid.Visible = false;
            divProperty_FR_Witness_Header.Visible = false;

            // Check if parameter id and table name is exists or not.
            if (Request.QueryString["id"] != null)
            {

                // Check Table_name parameter and as per table_name show Audit trial for that table
                BindPropertyWitness_Audit();
            }
        }
    }

    /// <summary>
    /// this function is use full when Audit trail is from AL_Audit table
    /// </summary>
    private void BindPropertyWitness_Audit()
    {
        DataTable dt = new DataTable();

        // show Case Grid 
        divProperty_FR_Witness_Grid.Visible = true;
        lbltable_Name.Text = "Property_FR_Witness";

        // Fill grid with audit table
        dt = AuditTrail.GetProperty_FR_Witness_AuditTrial(PK).Tables[0];
        gvProperty_FR_Witness.DataSource = dt;
        gvProperty_FR_Witness.DataBind();

        // Check if record found or not.
        if (dt.Rows.Count > 0)
        {
            // set Gridview div height and width on client side. 
            Page.ClientScript.RegisterStartupScript(Page.GetType(), System.DateTime.Now.ToString(), "javacript:showAudit(" + divProperty_FR_Witness_Header.ClientID + "," + divProperty_FR_Witness_Grid.ClientID + ");", true);

            // set Gridview div Scroll bar events so Scroll Header as per grid scroll
            divProperty_FR_Witness_Grid.Attributes.Add("onscroll", "javascript:ChangeScrollBar(this," + divProperty_FR_Witness_Header.ClientID + ");");
            divProperty_FR_Witness_Header.Visible = true;
        }
        else
        {
            // if record not found then hide Header and set width and height so scroll bar not visible.
            divProperty_FR_Witness_Grid.Style["height"] = Unit.Pixel(50).ToString();
            divProperty_FR_Witness_Grid.Style["width"] = "100%";
            divProperty_FR_Witness_Grid.Style["overflow"] = "hidden";
        }

        dt.Dispose();
        dt = null;
    }
}
