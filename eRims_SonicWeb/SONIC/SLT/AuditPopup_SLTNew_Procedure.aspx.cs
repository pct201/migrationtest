using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERIMS.DAL;
using System.Data;


public partial class SONIC_SLT_AuditPopup_SLTNew_Procedure : clsBasePage
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
    /// <summary>
    /// Page Load Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            divSLTNewProcedure_Grid.Visible = false;
            divSLTNewProcedureHeader.Visible = false;
            // Check if parameter id and table name is exists or not.
            if (Request.QueryString["id"] != null)
            {
                // Check Table_name parameter and as per table_name show Audit trial for that table
                BindNewProcedure_Audit();
            }

        }
    }
    #endregion

    #region "Mehods"
    /// <summary>
    /// this function is use full when Audit trail is from Franchise Table 
    /// </summary>
    private void BindNewProcedure_Audit()
    {
        DataTable dt = new DataTable();
        // show Case Grid 
        divSLTNewProcedure_Grid.Visible = true;
        lbltable_Name.Text = "SLT New Procedure";
        // Fill grid with audit table
        dt = AuditTrail.GetSLT_New_Procedure_AuditTrial(PK).Tables[0];
        gvSIUtilityProvider.DataSource = dt;
        gvSIUtilityProvider.DataBind();
        // Check if record found or not.
        if (dt.Rows.Count > 0)
        {
            // set Gridview div height and width on client side. 
            Page.ClientScript.RegisterStartupScript(Page.GetType(), System.DateTime.Now.ToString(), "javascript:showAudit(" + divSLTNewProcedureHeader.ClientID + "," + divSLTNewProcedure_Grid.ClientID + ");", true);

            // set Gridview div Scroll bar events so Scroll Header as per grid scroll
            divSLTNewProcedure_Grid.Attributes.Add("onscroll", "javascript:ChangeScrollBar(this," + divSLTNewProcedureHeader.ClientID + ");");
            divSLTNewProcedureHeader.Visible = true;
        }
        else
        {
            // if record not found then hide Header and set width and height so scroll bar not visible.
            divSLTNewProcedure_Grid.Style["height"] = Unit.Pixel(50).ToString();
            divSLTNewProcedure_Grid.Style["width"] = "100%";
            divSLTNewProcedure_Grid.Style["overflow"] = "hidden";
        }
        dt.Dispose();
        dt = null;
    }

    #endregion
}