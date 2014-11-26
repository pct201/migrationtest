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
/// 
/// Date           : 9-Oct-08
/// 
/// Developer Name : Ravi Patel
/// 
/// Description    : This page is used send a attachments throught email for Environmental Page of the 
///                  Exposure Module.
/// </summary>
public partial class SONIC_EmailAttachment : System.Web.UI.Page
{
    /// <summary>
    ///  store Attachment String Array
    /// </summary>    
    public string[] DocName
    {
        get { return (string[])this.ViewState["strDocName"]; }
        set { this.ViewState["strDocName"] = value; }
    }

    /// <summary>
    /// Page Load Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        //check Page Is POst Back or NOt
        if (!IsPostBack)
        {
            if (Request.QueryString["AttMod"].ToString() == clsGeneral.Exposure_Enviroment_Table.Enviro_Equipment.ToString() ||
                Request.QueryString["AttMod"].ToString() == clsGeneral.Exposure_Enviroment_Table.Enviro_Inspection.ToString() ||
                Request.QueryString["AttMod"].ToString() == clsGeneral.Exposure_Enviroment_Table.Enviro_Permit.ToString() ||
                Request.QueryString["AttMod"].ToString() == clsGeneral.Exposure_Enviroment_Table.Enviro_Phase1.ToString() ||
                Request.QueryString["AttMod"].ToString() == clsGeneral.Exposure_Enviroment_Table.Enviro_SPCC.ToString())
            {
                DataSet dsAttachment = Enviro_Attachments.SelectByMultipleIDs(Request.QueryString[1].ToString());
                string[] strDocName = new string[Request.QueryString[1].ToString().Split(',').Length];

                // Create string array for Attachments
                this.lblAttachment.Text = "";
                //Take a documents path that are send by email attachment, in the Array
                for (int i = 0; i < dsAttachment.Tables[0].Rows.Count; i++)
                {
                    strDocName[i] = clsGeneral.GetEnvironment_AttachmentDocPath(dsAttachment.Tables[0].Rows[i]["Folder_Name"].ToString()) + dsAttachment.Tables[0].Rows[i]["Filename"].ToString();
                    this.lblAttachment.Text += lblAttachment.Text.Trim() == string.Empty ? dsAttachment.Tables[0].Rows[i]["FileName"].ToString() : ", " + dsAttachment.Tables[0].Rows[i]["FileName"].ToString();
                }
                DocName = strDocName;
            }

            if (DocName.Length > 0)
            {
                decimal FileSize = clsGeneral.GetMailAttachmentSize(DocName);
                if (FileSize > 9.5M)
                    Page.ClientScript.RegisterStartupScript(typeof(string), DateTime.Now.ToString(), "javascript:alert('The e-mailing of the selected attachments exceeds 10 megabytes, which does not conform to Sonic Corporate e-mail policy. Please reduce the attachment size or number of attachments before trying to send e-mail through eRIMS2.');window.close();", true);
            }
        }

    }
    /// <summary>
    /// Button Send Click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSend_Click(object sender, EventArgs e)
    {
        clsGeneral.SendMailMessage(AppConfig.MailFrom, txtToEmail.Text, string.Empty, string.Empty, txtSubject.Text, txtBody.Text, true, DocName);
        lblScript.Text = "<script type='text/javascript'>Close();</script>";
    }

}
