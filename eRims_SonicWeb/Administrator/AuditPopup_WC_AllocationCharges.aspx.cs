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

/************************************************************************************************************************************
 * File Name      :	AuditPopup_WC_AllocationCharges.aspx
 *
 * Description    :	This screen is display audit trial for Wc allocation Charges table. Audit trail is view only. All lookups should 
 *                  display the lookup data.
 *
 *************************************************************************************************************************************/

public partial class Administrator_AuditPopup_WC_AllocationCharges : clsBasePage
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

            divWC_Allocation_Charges_Grid.Visible = false;
            divWC_Allocation_Charges_Header.Visible = false;

            // Check if parameter id and table name is exists or not.
            if (Request.QueryString["id"] != null)
            {

                // Check Table_name parameter and as per table_name show Audit trial for that table
                BindALFirstReport_Audit();
            }
        }
    }

    /// <summary>
    /// this function is use full when Audit trail is from AL_Audit table
    /// </summary>
    private void BindALFirstReport_Audit()
    {
        DataTable dt = new DataTable();

        // show Case Grid 
        divWC_Allocation_Charges_Grid.Visible = true;
        lbltable_Name.Text = "WC Allocation Charges";

        // Fill grid with audit table
        dt = AuditTrail.GetWC_Allocation_Charges_AuditTrial(PK).Tables[0];
        gvWC_Allocation_Charges.DataSource = dt;
        gvWC_Allocation_Charges.DataBind();

        // Check if record found or not.
        if (dt.Rows.Count > 0)
        {
            // set Gridview div height and width on client side. 
            Page.ClientScript.RegisterStartupScript(Page.GetType(), System.DateTime.Now.ToString(), "javacript:showAudit(" + divWC_Allocation_Charges_Header.ClientID + "," + divWC_Allocation_Charges_Grid.ClientID + ");", true);

            // set Gridview div Scroll bar events so Scroll Header as per grid scroll
            divWC_Allocation_Charges_Grid.Attributes.Add("onscroll", "javascript:ChangeScrollBar(this," + divWC_Allocation_Charges_Header.ClientID + ");");
            divWC_Allocation_Charges_Header.Visible = true;
        }
        else
        {
            // if record not found then hide Header and set width and height so scroll bar not visible.
            divWC_Allocation_Charges_Grid.Style["height"] = Unit.Pixel(50).ToString();
            divWC_Allocation_Charges_Grid.Style["width"] = "100%";
            divWC_Allocation_Charges_Grid.Style["overflow"] = "hidden";
        }

        dt.Dispose();
        dt = null;
    }
}
