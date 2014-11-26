using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Net.Mail;
using System.Net;
using System.IO;
using System.Text;

/// <summary>
/// Summary description for EmailHelper
/// </summary>
public class EmailHelper
{
	#region " Private Variables " 
    private SmtpClient _smtpClient; 
    #endregion 
    
    #region " Constructors " 
    public EmailHelper() : base() 
    { 
        
        _smtpClient = new SmtpClient(); 
    } 
    
    public EmailHelper(string smtpServer, string username, string password,int port)
    {
        _smtpClient = new SmtpClient(smtpServer, port); 
        _smtpClient.Credentials = new NetworkCredential(username, password); 
        //_smtpClient.EnableSsl = true;
    } 
    
    public EmailHelper(string username, string password) 
    { 
        _smtpClient = new SmtpClient(); 
        _smtpClient.Credentials = new NetworkCredential(username, password); 
    } 
    
    #endregion 
    
    #region " IDisposable Support " 
    
        // To detect redundant calls 
    private bool disposedValue = false; 
    
    // IDisposable 
    protected virtual void Dispose(bool disposing) 
    { 
        if (!this.disposedValue) { 
            if (disposing) { 
                // TODO: free unmanaged resources when explicitly called 
                if ((_smtpClient != null)) { 
                    _smtpClient = null; 
                    
                } 
            } 
            
            // TODO: free shared unmanaged resources 
        } 
        this.disposedValue = true; 
    } 
    
    
    // This code added by Visual Basic to correctly implement the disposable pattern. 
    public void Dispose() 
    { 
        // Do not change this code. Put cleanup code in Dispose(ByVal disposing As Boolean) above. 
        Dispose(true); 
        GC.SuppressFinalize(this); 
    } 
    #endregion 
    
    #region " Public Functions " 
    
    /// ----------------------------------------------------------------------------- 
    /// <summary> 
    /// Sends an mail message using the SMTP server defined in web.config or in constructor 
    /// </summary> 
    /// <param name="fromEmail">Sender email address</param> 
    /// <param name="fromName">Sender Name (pass empty string if do not want to supply)</param> 
    /// <param name="toEmail">Recepient email address (semicolon delimininated for multiple)</param> 
    /// <param name="subject">Subject of mail message</param> 
    /// <param name="body">Body of mail message</param> 
    /// <param name="isHtml">true to send email in html format</param> 
    /// <param name="atachments">optional attachment collection</param> 
    /// <param name="cc">optional Cc recepient email addresses (semicolon delimininated for multiple)</param> 
    /// <returns>true if mail is sent successfully</returns> 
    /// <remarks></remarks> 
    /// <history> 
    /// [Kiran Beladiya] 12/11/2007 Created 
    /// </history> 
    /// ----------------------------------------------------------------------------- 
    public bool SendMailMessage(string fromEmail, string fromName, string[] toEmail, string subject, string body, bool isHtml, string[] strFilePath, string cc)
    {
        if (!AppConfig.AllowMailSending)
            return false;
        // Instantiate a new instance of MailMessage 
        MailMessage mMailMessage = new MailMessage();
        mMailMessage.From = new MailAddress(fromEmail);
        foreach (string strEmailTO in toEmail)
        {
            mMailMessage.To.Add(strEmailTO);
        }
        string[] adds = null; 
        
        //// Set the sender address of the mail message 
        //if (string.IsNullOrEmpty(fromName)) { 
        //    mMailMessage.From = new MailAddress(fromEmail); 
        //} 
        //else { 
        //    mMailMessage.From = new MailAddress(fromEmail, fromName); 
        //}
        //mMailMessage.To = new MailAddress(toEmail,);
        // Check if the attachments value is nothing or an empty value 
        if (strFilePath != null)
        {
            foreach (string strAttachment in strFilePath)
            {
                if (File.Exists(strAttachment))
                {
                    System.Net.Mail.Attachment MailAttachment = new System.Net.Mail.Attachment(strAttachment);
                    if (MailAttachment != null)
                    {

                        mMailMessage.Attachments.Add(MailAttachment);
                    }
                }
            }
        }
        if (cc.ToString() != string.Empty)
        {
            mMailMessage.CC.Add(new MailAddress(cc));
        }
        // Set the subject of the mail message 
        mMailMessage.Subject = subject; 
        // Set the body of the mail message 
        mMailMessage.Body = body; 
        // Set the format of the mail message body as HTML 
        mMailMessage.IsBodyHtml = isHtml; 
        // Set the priority of the mail message to normal 
        mMailMessage.Priority = MailPriority.Normal; 
        
        //' Instantiate a new instance of SmtpClient 
        //Dim mSmtpClient As New SmtpClient() 

        try
        {
            //Send the mail message 
        _smtpClient.Send(mMailMessage);
        return true;
        }
        catch (Exception ex)
        {
            return false;
        }
        finally
        {
            mMailMessage.Dispose();
        } 
        
    } 
    #endregion 
}
