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

public partial class SONIC_CRM_AuditPopup_CRM_Customer_Notes : clsBasePage
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

            divNonCustomer_Notes_Audit.Visible = false;
            divNonCustomer_Notes_Audit_Header.Visible = false;

            // Check if parameter id and table name is exists or not.
            if (Request.QueryString["id"] != null)
            {
                // Check Table_name parameter and as per table_name show Audit trial for that table
                BindPolicyOther_Audit();
            }

            string strType = Request.QueryString["type"];
            if (strType == "field")
            {               
                lbltable_Name.Text = "Field Notes";
                Page.Title = "Risk Insurance Management System :: CRM Customer Field Notes Audit";
            }
            else
            {           
                lbltable_Name.Text = "CRM Customer Complaint Audit";
                Page.Title = "Risk Insurance Management System :: CRM Customer Complaint Audit";
            }
        }
    }

    /// <summary>
    /// this function is use full when Audit trail is from Policy Other Notes Table 
    /// </summary>
    private void BindPolicyOther_Audit()
    {
        DataTable dt = new DataTable();

        // show Case Grid 
        divNonCustomer_Notes_Audit.Visible = true;


        // Fill grid with audit table
        dt = AuditTrail.GetCRM_Non_Customer_Notes_AuditTrial(PK).Tables[0];
        gvNonCustomer_Notes_Audit.DataSource = dt;
        gvNonCustomer_Notes_Audit.DataBind();

        // Check if record found or not.
        if (dt.Rows.Count > 0)
        {
            // set Gridview div height and width on client side. 
            Page.ClientScript.RegisterStartupScript(Page.GetType(), System.DateTime.Now.ToString(), "javacript:showAudit(" + divNonCustomer_Notes_Audit_Header.ClientID + "," + divNonCustomer_Notes_Audit.ClientID + ");", true);

            // set Gridview div Scroll bar events so Scroll Header as per grid scroll
            divNonCustomer_Notes_Audit.Attributes.Add("onscroll", "javascript:ChangeScrollBar(this," + divNonCustomer_Notes_Audit_Header.ClientID + ");");
            divNonCustomer_Notes_Audit_Header.Visible = true;
        }
        else
        {
            // if record not found then hide Header and set width and height so scroll bar not visible.
            divNonCustomer_Notes_Audit.Style["height"] = Unit.Pixel(50).ToString();
            divNonCustomer_Notes_Audit.Style["width"] = "800";
            divNonCustomer_Notes_Audit.Style["overflow"] = "hidden";
        }

        dt.Dispose();
        dt = null;
    }
}