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

public partial class Message : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!clsGeneral.IsNull(Request.QueryString["msg"]))
            lblMsg.Text = Request.QueryString["msg"].ToString();
        else
            lblMsg.Text = "Unhandled Error Occured,Please Contact Site Administrator";
    }
}
