using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CRMTab : System.Web.UI.UserControl
{
    //Enum is used to set the active tab and inactive tabs.
    public enum Tab
    {
        Search = 1,
        Customer = 2
    }

    public bool IsNonCustomer
    {
        get {
            if (ViewState["TabCustomerType"] == null)
                return false;
            else
                return Convert.ToBoolean(ViewState["TabCustomerType"]); 
        }
        set { ViewState["TabCustomerType"] = value; }
    }


    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsNonCustomer)
            lblCustomerType.Text = "Non-Customer";
        else
            lblCustomerType.Text = "Customer";
    }

    public void SetSelectedTab(Tab tabIndex)
    {
        //used to set Tab style using SetTabStyle Function of Javascript
        Page.ClientScript.RegisterStartupScript(Page.GetType(), "SetTab", "javascript:SetTabStyle(" + (int)tabIndex + ");", true);
    }
}
