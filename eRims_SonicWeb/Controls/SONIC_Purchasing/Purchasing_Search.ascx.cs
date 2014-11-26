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
using ERIMS.DAL;
/// <summary>
/// Date : 30 MAY 2008
/// 
/// By : Hetal Prajapati
/// 
/// Purpose: 
/// Displays Executive Risk identification information on each page of
/// Executive Risk module 
/// 
/// Functionality:
/// Checks for the ID availability
/// and gets the information from DB and sets values in controls
/// </summary>
public partial class CtrlPurchasing_Search : System.Web.UI.UserControl
{
    //Enum is used to set the active tab and inactive tabs.
    public enum Tab
    {
        Search = 1,
        Purchasing = 2
    }

    public string StrRedirectTo
    {
        get
        {
            if (ViewState["StrRedirectTo"] != null)
            {
                return Convert.ToString(ViewState["StrRedirectTo"]);
            }
            else
            {
                return "";
            }
        }
        set
        {
            ViewState["StrRedirectTo"] = value;
        }
    }

    public void SetSelectedTab(Tab tabIndex)
    {
        //used to set Tab style using SetTabStyle Function of Javascruipt

        Page.ClientScript.RegisterStartupScript(Page.GetType(), "SetTab", "javascript:SetTabStyle(" + (int)tabIndex + ");", true);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

        }
    }

}
