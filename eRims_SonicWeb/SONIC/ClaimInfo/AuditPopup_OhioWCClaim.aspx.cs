using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SONIC_FirstReport_AuditPopup_OhioWCClaim : System.Web.UI.Page
{
    #region "Page Load"
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindGrid();
        }
    }
    #endregion

    #region "Method"
    /// <summary>
    /// Bind Grid functionality
    /// </summary>
    public void BindGrid()
    {
        decimal pk_id = Convert.ToDecimal(Request.QueryString["id"]);
        gvWC_FRName.DataSource = ERIMS.DAL.Workers_Comp_Claims_OH.SelectAssociatedFirstReportAuditView(pk_id);
        gvWC_FRName.DataBind();

        if (gvWC_FRName.Rows.Count > 0)
        {
            divWC_FR_Header.Visible = true;
            Page.ClientScript.RegisterStartupScript(Page.GetType(), System.DateTime.Now.ToString(), "javacript:showAudit(" + divWC_FR_Header.ClientID + "," + divWC_FR_Grid.ClientID + ");", true);
            divWC_FR_Grid.Attributes.Add("onscroll", "javascript:ChangeScrollBar(this," + divWC_FR_Header.ClientID + ");");
        }
        else
        {
            divWC_FR_Grid.Style["height"] = Unit.Pixel(50).ToString();
            divWC_FR_Grid.Style["width"] = "100%";
            divWC_FR_Grid.Style["overflow"] = "hidden";
            divWC_FR_Header.Visible = false;
        }

    }
    #endregion
}
