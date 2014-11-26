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

public partial class Admin_Default : clsBasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (App_Access == AccessType.NotAssigned)
            Response.Redirect(AppConfig.SiteURL + "Message.aspx?msg=You are not authorized to access this page");
    }            
}
