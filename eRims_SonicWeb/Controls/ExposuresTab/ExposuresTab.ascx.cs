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

public partial class Controls_ExposuresTab_ExposuresTab : System.Web.UI.UserControl
{
    //Enum is used to set the active tab and inactive tabs.
    public enum Tab
    {
        Property = 1,
        Franchise = 2,
        Pollution = 3,
        Inspection = 4,
        Lease = 5,
        ProjectManagement = 6,
        AssetProtection = 7,
        Construction = 8
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

        }
    }
    public void SetSelectedTab(Tab tabIndex)
    {
        //used to set Tab style using SetTabStyle Function of Javascruipt
        Page.ClientScript.RegisterStartupScript(Page.GetType(), "SetTab", "javascript:SetTabStyle(" + (int)tabIndex + ");", true);
    }
}
