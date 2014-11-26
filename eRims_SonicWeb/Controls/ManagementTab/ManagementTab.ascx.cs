using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Controls_ManagementTab_ManagementTab : System.Web.UI.UserControl
{
    public string strTab = "1";
    public enum Tab
    {
        Search = 1,
        Management = 2
    }

    public decimal PK_Management
    {
        get { return 0; }
    }
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    /// <summary>
    /// Sets the javascript CSS class to highlight the selected tab
    /// </summary>
    /// <param name="tabIndex"></param>
    public void SetSelectedTab(Tab tabIndex)
    {
        //used to set Tab style using SetTabStyle Function of Javascript
        Page.ClientScript.RegisterStartupScript(Page.GetType(), "SetTab", "javascript:SetTabStyle(" + (int)tabIndex + ");", true);
    }
  
}