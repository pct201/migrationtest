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

public partial class Error : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!clsGeneral.IsNull(Request.QueryString["msg"]))
            lblMsg.Text = GetMessage(Request.QueryString["msg"].ToString());
        else
            lblMsg.Text = "Unhandled Error Occured,Please Contact Site Administrator";

        //dvErrorXML.Visible = true;
    }

    /// <summary>
    /// Returns error text to be set for the label
    /// </summary>
    /// <param name="strMessageType">Message type passed in the querystring</param>
    /// <returns>Error text</returns>
    public string GetMessage(string strMessageType)
    {
        // check for the message type and return the text according to that
        if (strMessageType == "errAcc")
        {
            return "You are not authorized to access this page";
        }
        else if (strMessageType == "errHtml")
        {
            return "You have used HTML tags in your input text.";
        }
        else
            return "Unhandled Error Occured,Please Contact Site Administrator";
    }
}
