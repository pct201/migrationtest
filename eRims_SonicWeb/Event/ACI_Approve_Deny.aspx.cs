using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERIMS.DAL;

public partial class Event_ACI_Approve_Deny : System.Web.UI.Page
{
    /// <summary>
    /// Denotes the Primary Key
    /// </summary>
    public decimal PK_Event_Video_Tracking_Request
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_Event_Video_Tracking_Request"]);
        }
        set { ViewState["PK_Event_Video_Tracking_Request"] = value; }
    }

    /// <summary>
    /// Denotes the Primary Key
    /// </summary>
    public decimal FK_Security_ID
    {
        get
        {
            return clsGeneral.GetInt(ViewState["FK_Security_ID"]);
        }
        set { ViewState["FK_Security_ID"] = value; }
    }

    /// <summary>
    /// Denotes the operation whether edit or view
    /// </summary>
    public string StrStatus
    {
        get { return ViewState["StrStatus"] != null ? Convert.ToString(ViewState["StrStatus"]) : ""; }
        set { ViewState["StrStatus"] = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            PK_Event_Video_Tracking_Request = Convert.ToDecimal(clsGeneral.GetQueryStringID(Request.QueryString["tid"]));
            FK_Security_ID = Convert.ToDecimal(clsGeneral.GetQueryStringID(Request.QueryString["sid"]));
            StrStatus = Convert.ToString(Encryption.Decrypt(Request.QueryString["status"]));

            clsEvent_Video_Tracking_Request.Event_Video_Tracking_RequestUpdateStatus(PK_Event_Video_Tracking_Request, StrStatus, FK_Security_ID);
        }
        catch (Exception ex)
        {

        }
        finally
        {
            this.Page.ClientScript.RegisterStartupScript(this.GetType(), DateTime.Now.ToString(), "javascript:this.close();", true);
        }

        
    }
}