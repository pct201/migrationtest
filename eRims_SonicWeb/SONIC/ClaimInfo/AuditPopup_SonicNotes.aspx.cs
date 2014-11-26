using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class SONIC_ClaimInfo_AuditPopup_SonicNotes : System.Web.UI.Page
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

            divPurchasing_Service_Contract_Grid.Visible = false;
            divPurchasing_Service_Contract_Header.Visible = false;

            // Check if parameter id and table name is exists or not.
            if (Request.QueryString["id"] != null)
            {
                //lbltable_Name.Text = (Request.QueryString["id"] + " < - > " + Request.QueryString["Table_Name"]);

                // Check Table_name parameter and as per table_name show Audit trial for that table
                BindSonicNotes();
            }
        }
    }

    /// <summary>
    /// this function is use full when Audit trail is from Purchasing Services Contract Table 
    /// </summary>
    private void BindSonicNotes()
    {
        DataTable dt = new DataTable();

        // show Case Grid 
        divPurchasing_Service_Contract_Grid.Visible = true;
        lbltable_Name.Text = "Sonic Notes";

        // Fill grid with audit table
        dt = Audit_Trail.GetSonicNotes_Audit(PK).Tables[0];
        gvPurchasing_Service_Contract.DataSource = dt;
        gvPurchasing_Service_Contract.DataBind();


        //clsGeneral.FormatDateToDisplay(Eval("Date_Of_Incident") != DBNull.Value  ? Convert.ToDateTime(Eval("Date_Of_Incident")) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue)

        // Check if record found or not.
        if (dt.Rows.Count > 0)
        {
            // set Gridview div height and width on client side. 
            Page.ClientScript.RegisterStartupScript(Page.GetType(), System.DateTime.Now.ToString(), "javacript:showAudit(" + divPurchasing_Service_Contract_Header.ClientID + "," + divPurchasing_Service_Contract_Grid.ClientID + ");", true);

            // set Gridview div Scroll bar events so Scroll Header as per grid scroll
            divPurchasing_Service_Contract_Grid.Attributes.Add("onscroll", "javascript:ChangeScrollBar(this," + divPurchasing_Service_Contract_Header.ClientID + ");");
            divPurchasing_Service_Contract_Header.Visible = true;
        }
        else
        {
            // if record not found then hide Header and set width and height so scroll bar not visible.
            divPurchasing_Service_Contract_Grid.Style["height"] = Unit.Pixel(50).ToString();
            divPurchasing_Service_Contract_Grid.Style["width"] = "100%";
            divPurchasing_Service_Contract_Grid.Style["overflow"] = "hidden";
        }

        dt.Dispose();
        dt = null;
    }
}
