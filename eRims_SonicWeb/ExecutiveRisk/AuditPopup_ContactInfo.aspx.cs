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

/*
 *  Developer Name : Ravi Gupta
 *  
 *  Description : This page is contains Audit Data for Executive_Risk Defense_Attorney table. 
 *                when User clicked on View Audit Trail button , in Popup this page will be presented to the user
 *                all of the records with matching PKs in the "TableName"_Audit table in a grid sorted by Audit_DateTime DESC. 
 *                
 *               All lookups should display the lookup data – for example. the FK_Security_Type and FK_Security_Category columns show 
 *               the text description, not the numeric data that is actually stored in the table.
 * 
 *               Audit trail is view only.
 *              
 *               When Viewing an Audit Trail on the Attachment screen, show the base table’s data – 
 *               for example, on the Case Attachment screen show the Case table, NOT the Attachment Table.
 * 
 *               Here, Two parameter is passed 
 *               1). Table_Name which is specifiy table name for Audit trail.
 *               2). PK which is specifiy Primary Key for Audit trail table.
 * 
 */

public partial class ExecutiveRisk_AuditPopup_ContactInfo : System.Web.UI.Page
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

            divExecutive_Risk_Contacts_Grid.Visible = false;
            divExecutive_Risk_Contacts_Header.Visible = false;

            // Check if parameter id and table name is exists or not.
            if (Request.QueryString["id"] != null && Request.QueryString["Table_Name"] != null)
            {
                //lbltable_Name.Text = (Request.QueryString["id"] + " < - > " + Request.QueryString["Table_Name"]);

                // Check Table_name parameter and as per table_name show Audit trial for that table
                if (Table_Name == "Executive_Risk_Contacts")
                    BindContactInfo();
            }
        }
    }

    /// <summary>
    /// this function is use full when Audit trail is from ContactInfo Table 
    /// </summary>
    private void BindContactInfo()
    {
        DataTable dt = new DataTable();

        // show Case Grid 
        divExecutive_Risk_Contacts_Grid.Visible = true;
        lbltable_Name.Text = "Executive_Risk_Contacts";

        // Fill grid with audit table
        dt = AuditTrail.GetExecutive_Risk_Contacts_AuditTrial(PK).Tables[0];
        gvExecutive_Risk_Contacts.DataSource = dt;
        gvExecutive_Risk_Contacts.DataBind();

        // Check if record found or not.
        if (dt.Rows.Count > 0)
        {
            // set Gridview div height and width on client side. 
            Page.ClientScript.RegisterStartupScript(Page.GetType(), System.DateTime.Now.ToString(), "javacript:showAudit(" + divExecutive_Risk_Contacts_Header.ClientID + "," + divExecutive_Risk_Contacts_Grid.ClientID + ");", true);

            // set Gridview div Scroll bar events so Scroll Header as per grid scroll
            divExecutive_Risk_Contacts_Grid.Attributes.Add("onscroll", "javascript:ChangeScrollBar(this," + divExecutive_Risk_Contacts_Header.ClientID + ");");
            divExecutive_Risk_Contacts_Header.Visible = true;
        }
        else
        {
            // if record not found then hide Header and set width and height so scroll bar not visible.
            divExecutive_Risk_Contacts_Grid.Style["height"] = Unit.Pixel(50).ToString();
            divExecutive_Risk_Contacts_Grid.Style["width"] = "100%";
            divExecutive_Risk_Contacts_Grid.Style["overflow"] = "hidden";
        }

        dt.Dispose();
        dt = null;
    }
}
