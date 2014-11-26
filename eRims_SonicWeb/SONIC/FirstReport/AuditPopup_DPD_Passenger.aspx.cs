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

public partial class SONIC_FirstReport_AuditPopup_DPD_Passenger : System.Web.UI.Page
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

            divDPD_FR_Injured_Passenger_Grid.Visible = false;
            divDPD_FR_Injured_Passenger_Header.Visible = false;

            // Check if parameter id and table name is exists or not.
            if (Request.QueryString["id"] != null)
            {
                //lbltable_Name.Text = (Request.QueryString["id"] + " < - > " + Request.QueryString["Table_Name"]);

                // Check Table_name parameter and as per table_name show Audit trial for that table
                BindDPD_FR_Injured_Passenger_Audit();
            }
        }
    }

    /// <summary>
    /// this function is use full when Audit trail is from DPD_FR Passenger Table 
    /// </summary>
    private void BindDPD_FR_Injured_Passenger_Audit()
    {
        DataTable dt = new DataTable();

        // show Case Grid 
        divDPD_FR_Injured_Passenger_Grid.Visible = true;
        lbltable_Name.Text = "DPD_FR_Injured_Passenger";

        // Fill grid with audit table
        dt = AuditTrail.GetDPD_FR_Passenger_AuditTrial(PK).Tables[0];
        gvDPD_FR_Injured_Passenger.DataSource = dt;
        gvDPD_FR_Injured_Passenger.DataBind();


        //clsGeneral.FormatDateToDisplay(Eval("Date_Of_Incident") != DBNull.Value  ? Convert.ToDateTime(Eval("Date_Of_Incident")) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue)

        // Check if record found or not.
        if (dt.Rows.Count > 0)
        {
            // set Gridview div height and width on client side. 
            Page.ClientScript.RegisterStartupScript(Page.GetType(), System.DateTime.Now.ToString(), "javacript:showAudit(" + divDPD_FR_Injured_Passenger_Header.ClientID + "," + divDPD_FR_Injured_Passenger_Grid.ClientID + ");", true);

            // set Gridview div Scroll bar events so Scroll Header as per grid scroll
            divDPD_FR_Injured_Passenger_Grid.Attributes.Add("onscroll", "javascript:ChangeScrollBar(this," + divDPD_FR_Injured_Passenger_Header.ClientID + ");");
            divDPD_FR_Injured_Passenger_Header.Visible = true;
        }
        else
        {
            // if record not found then hide Header and set width and height so scroll bar not visible.
            divDPD_FR_Injured_Passenger_Grid.Style["height"] = Unit.Pixel(50).ToString();
            divDPD_FR_Injured_Passenger_Grid.Style["width"] = "100%";
            divDPD_FR_Injured_Passenger_Grid.Style["overflow"] = "hidden";
        }

        dt.Dispose();
        dt = null;
    }
}
