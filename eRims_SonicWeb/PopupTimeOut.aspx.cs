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

public partial class PopupTimeOut : System.Web.UI.Page
{
    /// <summary>
    /// Page Load event Handler
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        string strScript = "";
        strScript = "<script language='javascript' type='text/javascript'>StartTimer();AutoClose();</script>";
        ClientScript.RegisterStartupScript(this.GetType(), "TimerEvent", strScript);
        //btnOk.Attributes.Add("onClick", "javascript:window.returnValue='ResetTime';window.close();");
        btnOk.Attributes.Add("onClick", "javascript:return OkClick();");
        btnCancel.Attributes.Add("onClick", "javascript:return CancelClick();");

        lblCurrentTime.Text = DateTime.Now.ToLongTimeString();
    }
}