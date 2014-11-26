using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ERIMS.DAL;

public partial class OutlookAddIn_Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            string strUserName = Request.QueryString["username"];
            string strPassword = Request.QueryString["password"];
            // Validate User Name and Password
            int dsUser = Security.GetLoginID(strUserName, strPassword);
            if (dsUser > 0)
                Response.Write("Valid");
            else
                Response.Write("Invalid");
            
            
        }
    }
}