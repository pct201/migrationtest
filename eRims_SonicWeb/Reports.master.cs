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

public partial class Reports : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            smdAdmin.SiteMapProvider = "Admin";
        //header.Style.Add("background-image", Server.MapPath("~")+ "/images/header.jpg");
        //Response.Write(Server.MapPath("~") + "/images/header.jpg");
    }
}
