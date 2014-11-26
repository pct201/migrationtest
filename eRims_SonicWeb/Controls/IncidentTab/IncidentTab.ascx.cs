using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Controls_IncidentTab_IncidentTab : System.Web.UI.UserControl
{
    #region Variables
    // enum data type for Search
    public enum Tab
    {
        Search = 1,
        Incident = 2,
        Event = 3,
        Alarm = 4,
        Contact = 5
    }
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Convert.ToString(Request.Url).Contains("Event/Event.aspx"))
            tab2.Visible = tab4.Visible= false;
        else
            tab2.Visible = tab4.Visible = true;
    }

    public void SetSelectedTab(Tab tabIndex)
    {
        //used to set Tab style using SetTabStyle Function of Javascruipt
        Page.ClientScript.RegisterStartupScript(Page.GetType(), "SetTab", "javascript:SetTabStyle(" + (int)tabIndex + ",'" + this.ClientID + "' );", true);

        if (tabIndex == Tab.Incident)
            tab2.Attributes.Add("onclick", "return false;");
        if (tabIndex == Tab.Event)
            tab3.Attributes.Add("onclick", "return false;");
        if (tabIndex == Tab.Alarm)
            tab4.Attributes.Add("onclick", "return false;");
        //if (tabIndex == Tab.Contact)
        //    tab5.Attributes.Add("onclick", "return false;");

    }

    public void MoveToTab(decimal PK_Incident, decimal PK_Event, decimal PK_Alarm, string strIsSearch, decimal location)
    {
        Page.ClientScript.RegisterStartupScript(Page.GetType(), "MoveToTab", "javascript:OpenPage('" + (PK_Incident == 0 ? "0" : Encryption.Encrypt(PK_Incident.ToString())) + "','" + (PK_Event == 0 ? "0" : Encryption.Encrypt(PK_Event.ToString())) + "','" + Encryption.Encrypt(PK_Alarm.ToString()) + "','" + strIsSearch + "','" + location + "' );", true);
    }
}