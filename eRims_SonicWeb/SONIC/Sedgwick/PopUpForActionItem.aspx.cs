using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BAL;

public partial class SONIC_Sedgwick_PopUpForActionItem : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["txtID"] != null)
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:SetValue('" + Request.QueryString["txtID"].ToString() + "');", true);
            btnSave.Attributes.Add("onclick", "javascript:ClosePopup('" + Request.QueryString["txtID"].ToString() + "');");
        }
    }
}