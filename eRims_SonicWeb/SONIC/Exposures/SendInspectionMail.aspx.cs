using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SONIC_Exposures_SendInspectionMail : System.Web.UI.Page
{
    #region Properties

    /// <summary>
    /// Gets or sets attachment file name
    /// </summary>
    private string AttachmentName
    {
        get { return Convert.ToString(ViewState["AttachmentName"]); }
        set { ViewState["AttachmentName"] = value; }
    }

    #endregion

    #region Page Load Events

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["attachment"] != null)
            {
                AttachmentName = Convert.ToString(Request.QueryString["attachment"]);
            }
        }
    }

    #endregion

    #region Control Events

    /// <summary>
    /// Send Email button functionality
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSend_Click(object sender, EventArgs e)
    {
        string[] fileName = { AppConfig.InspectionDocPath + "\\" + AttachmentName };
        clsGeneral.SendMailMessage(AppConfig.MailFrom, txtTo.Text.Trim(),txtBCC.Text.Trim(), txtCC.Text.Trim(), txtSubject.Text.Trim(), txtBody.Text.Trim().Replace("\r\n", "<br/>"), true, fileName);
        ScriptManager.RegisterStartupScript(this, GetType(), "openAttachmentPoppup", "javascript:alert('Email sent successfully.');ClosePage();", true);        
    }

    #endregion
}