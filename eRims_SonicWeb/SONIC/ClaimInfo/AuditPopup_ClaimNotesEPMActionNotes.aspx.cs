using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class SONIC_ClaimInfo_AuditPopup_ClaimNotesEPMActionNotes : System.Web.UI.Page
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

            divEPM_Action_Notes_Grid.Visible = false;
            divEPM_Action_Notes_Header.Visible = false;

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
        divEPM_Action_Notes_Grid.Visible = true;
        lbltable_Name.Text = "Risk Management Notes";

        // Fill grid with audit table
        dt = Audit_Trail.GetEPM_Action_Notes_RM_AuditTrail(PK).Tables[0];
        gvEPM_Action_Notes.DataSource = dt;
        gvEPM_Action_Notes.DataBind();


        //clsGeneral.FormatDateToDisplay(Eval("Date_Of_Incident") != DBNull.Value  ? Convert.ToDateTime(Eval("Date_Of_Incident")) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue)

        // Check if record found or not.
        if (dt.Rows.Count > 0)
        {
            // set Gridview div height and width on client side. 
            Page.ClientScript.RegisterStartupScript(Page.GetType(), System.DateTime.Now.ToString(), "javacript:showAudit(" + divEPM_Action_Notes_Header.ClientID + "," + divEPM_Action_Notes_Grid.ClientID + ");", true);

            // set Gridview div Scroll bar events so Scroll Header as per grid scroll
            divEPM_Action_Notes_Grid.Attributes.Add("onscroll", "javascript:ChangeScrollBar(this," + divEPM_Action_Notes_Header.ClientID + ");");
            divEPM_Action_Notes_Header.Visible = true;
        }
        else
        {
            // if record not found then hide Header and set width and height so scroll bar not visible.
            divEPM_Action_Notes_Grid.Style["height"] = Unit.Pixel(50).ToString();
            divEPM_Action_Notes_Grid.Style["width"] = "100%";
            divEPM_Action_Notes_Grid.Style["overflow"] = "hidden";
        }

        dt.Dispose();
        dt = null;
    }
}