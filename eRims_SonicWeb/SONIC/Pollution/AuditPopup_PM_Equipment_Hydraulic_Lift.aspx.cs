﻿using System;
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


public partial class SONIC_Pollution_AuditPopup_PM_Equipment_Hydraulic_Lift : System.Web.UI.Page
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
            divPM_Equipment_Hydraulic_Lift_Grid.Visible = false;
            divPM_Equipment_Hydraulic_Lift.Visible = false;
            // Check if parameter id and table name is exists or not.
            if (Request.QueryString["id"] != null)
            {
                // Check Table_name parameter and as per table_name show Audit trial for that table
                BindUtilityProvider_Audit();
            }
        }
    }
    #endregion

    #region "Mehods"
    /// <summary>
    /// this function is use full when Audit trail is from Franchise Table 
    /// </summary>
    private void BindUtilityProvider_Audit()
    {
        //Set Lift or Rack as per Equipment Type
        LiftRack();

        DataTable dt = new DataTable();
        // show Case Grid 
        divPM_Equipment_Hydraulic_Lift_Grid.Visible = true;
        //lbltable_Name.Text = "Hydraulic Lift";
        // Fill grid with audit table
        dt = clsPM_Equipment_Hydraulic_Lift.GetAuditView(PK).Tables[0];
        gvSIUtilityProvider.DataSource = dt;
        gvSIUtilityProvider.DataBind();
        // Check if record found or not.
        if (dt.Rows.Count > 0)
        {
            // set Gridview div height and width on client side. 
            Page.ClientScript.RegisterStartupScript(Page.GetType(), System.DateTime.Now.ToString(), "javacript:showAudit(" + divPM_Equipment_Hydraulic_Lift.ClientID + "," + divPM_Equipment_Hydraulic_Lift_Grid.ClientID + ");", true);

            // set Gridview div Scroll bar events so Scroll Header as per grid scroll
            divPM_Equipment_Hydraulic_Lift_Grid.Attributes.Add("onscroll", "javascript:ChangeScrollBar(this," + divPM_Equipment_Hydraulic_Lift.ClientID + ");");
            divPM_Equipment_Hydraulic_Lift.Visible = true;
        }
        else
        {
            // if record not found then hide Header and set width and height so scroll bar not visible.
            divPM_Equipment_Hydraulic_Lift_Grid.Style["height"] = Unit.Pixel(50).ToString();
            divPM_Equipment_Hydraulic_Lift_Grid.Style["width"] = "100%";
            divPM_Equipment_Hydraulic_Lift_Grid.Style["overflow"] = "hidden";
        }
        dt.Dispose();
        dt = null;        
    }

    //Set Lift or Rack as per Equipment Type method
    private void LiftRack()
    {
        int FK_LU_Equipment_Type = clsPM_Equipment_Hydraulic_Lift.RackLiftSelectByPk(PK);
        {
            if (FK_LU_Equipment_Type == 10)
            {
                this.Title = "eRIMS Sonic :: Alignment Racks Audit Trail";
                lbltable_Name.Text = "Alignment Rack";
                //spnauditRemoval.InnerText = spnLiftGrid.InnerText = "Rack";
                //spnauditRemoved.InnerText = spnLiftGrids.InnerText = "Racks";
            }
            else
            {
                this.Title = "eRIMS Sonic :: Hydraulic Lift Audit Trail";
                lbltable_Name.Text = "Hydraulic Lift";
                //spnauditRemoval.InnerText = spnLiftGrid.InnerText = "Lift";
                //spnauditRemoved.InnerText = spnLiftGrids.InnerText = "Lifts"; 
            }
        }
    }

    #endregion
}