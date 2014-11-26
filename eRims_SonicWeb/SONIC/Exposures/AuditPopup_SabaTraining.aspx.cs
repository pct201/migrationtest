using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;


public partial class SONIC_Exposures_AuditPopup_SabaTraining : System.Web.UI.Page
{
    # region " Properties "

    ////<summary>
    ////used to manupulate Table_Name parameter
    ////</summary>
    public String Table_Name
    {
        get
        {
            return (!String.IsNullOrEmpty(Request.QueryString["Table_Name"]) ? Convert.ToString(Request.QueryString["Table_Name"]) : String.Empty);
        }
    }

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

            divSabaTraining_Audit_Grid.Visible = false;
            divSabaTraining_Audit_Header.Visible = false;

            // Check if parameter id is exists or not.
            if (Request.QueryString["id"] != null)
            {
                // show Audit trial for table                
                BindEnviro_SabaTraining();
            }
        }
    }

    /// <summary>
    /// this function is use full when Audit trail is from Defense_Attorney Table 
    /// </summary>
    private void BindEnviro_SabaTraining()
    {
        DataTable dt = new DataTable();

        // show Case Grid 
        divSabaTraining_Audit_Grid.Visible = true;
        lbltable_Name.Text = "SabaTraining";

        // Fill grid with audit table
        dt = AuditTrail.GetSabaTrainingAuditTrail(PK).Tables[0];
        gvSabaTraining_Audit.DataSource = dt;
        gvSabaTraining_Audit.DataBind();

        // Check if record found or not.
        if (dt.Rows.Count > 0)
        {
            // set Gridview div height and width on client side. 
            Page.ClientScript.RegisterStartupScript(Page.GetType(), System.DateTime.Now.ToString(), "javacript:showAudit(" + divSabaTraining_Audit_Header.ClientID + "," + divSabaTraining_Audit_Grid.ClientID + ");", true);

            // set Gridview div Scroll bar events so Scroll Header as per grid scroll
            divSabaTraining_Audit_Grid.Attributes.Add("onscroll", "javascript:ChangeScrollBar(this," + divSabaTraining_Audit_Header.ClientID + ");");
            divSabaTraining_Audit_Header.Visible = true;
        }
        else
        {
            // if record not found then hide Header and set width and height so scroll bar not visible.
            divSabaTraining_Audit_Grid.Style["height"] = Unit.Pixel(50).ToString();
            divSabaTraining_Audit_Grid.Style["width"] = "100%";
            divSabaTraining_Audit_Grid.Style["overflow"] = "hidden";
        }

        dt.Dispose();
        dt = null;
    }
}
