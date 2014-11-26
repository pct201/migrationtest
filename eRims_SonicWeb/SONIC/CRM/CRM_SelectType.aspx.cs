using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SONIC_CRM_CRM_SelectType : clsBasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(App_Access == AccessType.View_Only)
            Response.Redirect(AppConfig.SiteURL + "Error.aspx?msg=errAcc");
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if (drpIncidentType.SelectedValue == "Customer")
        {
            Response.Redirect("CRM_Customer.aspx");
        }
        else
        {
            Response.Redirect("CRM_NonCustomer.aspx");
        }
    }
}