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

/*
 *  Developer Name : Ravi Gupta
 *  
 *  Description : This page is contains Audit Data for Executive_Risk Carrier table. 
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
public partial class ExecutiveRisk_AuditPopUp_ExecutiveRiskCarrier : clsBasePage
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

            divCarrier_Grid.Visible = false;
            divCarrier_Header.Visible = false;

            // Check if parameter id and table name is exists or not.
            if (Request.QueryString["id"] != null && Request.QueryString["Table_Name"] != null)
            {
                //lbltable_Name.Text = (Request.QueryString["id"] + " < - > " + Request.QueryString["Table_Name"]);

                // Check Table_name parameter and as per table_name show Audit trial for that table
                if (Table_Name == "Carrier")
                    BindCarrier();
            }
        }
    }

    /// <summary>
    /// this function is use full when Audit trail is from Carrier Table 
    /// </summary>
    private void BindCarrier()
    {
        DataTable dt = new DataTable();

        // show Case Grid 
        divCarrier_Grid.Visible = true;
        lbltable_Name.Text = "Carrier";

        // Fill grid with audit table
        dt = AuditTrail.GetExecutive_Risk_Carrier_AuditTrial(PK).Tables[0];
        gvCarrier.DataSource = dt;
        gvCarrier.DataBind();

        // Check if record found or not.
        if (dt.Rows.Count > 0)
        {
            // set Gridview div height and width on client side. 
            Page.ClientScript.RegisterStartupScript(Page.GetType(), System.DateTime.Now.ToString(), "javacript:showAudit(" + divCarrier_Header.ClientID + "," + divCarrier_Grid.ClientID + ");", true);

            // set Gridview div Scroll bar events so Scroll Header as per grid scroll
            divCarrier_Grid.Attributes.Add("onscroll", "javascript:ChangeScrollBar(this," + divCarrier_Header.ClientID + ");");
            divCarrier_Header.Visible = true;
        }
        else
        {
            // if record not found then hide Header and set width and height so scroll bar not visible.
            divCarrier_Grid.Style["height"] = Unit.Pixel(50).ToString();
            divCarrier_Grid.Style["width"] = "100%";
            divCarrier_Grid.Style["overflow"] = "hidden";
        }

        dt.Dispose();
        dt = null;
    }
}
