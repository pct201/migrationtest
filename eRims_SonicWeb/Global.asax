<%@ Application Language="C#" %>
<%@ Import Namespace="System.IO" %>
<%@ Import Namespace="System.Net" %>
<%@ Import Namespace="System.Net.Mail" %>
<%@ Import Namespace="System.Configuration" %>
<%@ Import Namespace="System.Reflection" %>
<script runat="server">

    void Application_Start(object sender, EventArgs e) 
    {
        // Code that runs on application startup
        AppConfig.OnApplicationStart();

        //Issue no-4010
        //Added by Poonam Parekh on 18/5/2017
        //This is to disable the file changes Monitor on subdirectories of the application root folder 
        PropertyInfo p = typeof(System.Web.HttpRuntime).GetProperty("FileChangesMonitor", BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static);
        object o = p.GetValue(null, null);
        FieldInfo f = o.GetType().GetField("_dirMonSubdirs", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.IgnoreCase);
        object monitor = f.GetValue(o);
        MethodInfo m = monitor.GetType().GetMethod("StopMonitoring", BindingFlags.Instance | BindingFlags.NonPublic);
        m.Invoke(monitor, new object[] { });
    }
    
    void Application_End(object sender, EventArgs e) 
    {
        //  Code that runs on application shutdown

    }

    void Application_Error(object sender, EventArgs e)
    {
        //try
        //{
        //    // Code that runs when an unhandled error occurs
        //    Exception err = (Exception)Server.GetLastError().InnerException;
        //    string errorText = "Error Message: " + err.Message + " ";
        //    errorText = errorText + "Stack Trace: " + err.StackTrace;
        //    MailMessage MyMailMessage = new MailMessage("erims@astegic.com", "rshah@astegic.com", "Exception:" + err.Message, errorText);

        //    MyMailMessage.IsBodyHtml = false;

        //    //Proper Authentication Details need to be passed when sending email from gmail
        //    NetworkCredential mailAuthentication = new NetworkCredential("smtp.gmail.com", System.Configuration.ConfigurationManager.AppSettings["SMTPPwd"].ToString());

        //    //Smtp Mail server of Gmail is "smpt.gmail.com" and it uses port no. 587
        //    //For different server like yahoo this details changes and you can
        //    //get it from respective server.
        //    SmtpClient mailClient = new SmtpClient("smtp.gmail.com", 465);
        //    mailClient.Timeout = 100;
        //    //Enable SSL
        //    mailClient.EnableSsl = true;
        //    mailClient.UseDefaultCredentials = false;
        //    mailClient.Credentials = mailAuthentication;
        //    mailClient.Send(MyMailMessage);
        //}
        //catch (Exception ex) { ex.ToString(); }
        Exception ex = Server.GetLastError();

        if ((ex) is HttpRequestValidationException)
        {
            Response.Redirect(AppConfig.SiteURL + "Error.aspx?msg=errHtml");
        }
        else
        {
            //string errorText = string.Empty;
            //string subject = string.Empty;
            //Exception err = (Exception)Server.GetLastError();
            //if (err != null)
            //{
            //    errorText = "Error Message: " + err.Message + " ";
            //    //string errorText = "Error : " + "/n" + err.Source + "\n" + err.Message.ToString() + "\n" + err.InnerException.ToString();
            //    errorText = errorText + "\n" + "\n" + " Stack Trace: " + err.StackTrace;
            //    subject = "eRIMS Sonic: Exception - " + err.Message;
            //}
            //else
            //{
            //    errorText = "There is some error in the application. Please try again later.";
            //    subject = "eRIMS FCI: Exception";
            //}

            //System.Web.Mail.MailMessage mailMsg = new System.Web.Mail.MailMessage();
            //mailMsg.From = "erims@astegic.com";
            //mailMsg.To = "vpatel@astegic.com";
            //mailMsg.Cc = "rshah@astegic.com";
            //mailMsg.Subject = subject;
            //mailMsg.BodyFormat = System.Web.Mail.MailFormat.Html;
            //mailMsg.Body = errorText;



            //mailMsg.Priority = System.Web.Mail.MailPriority.Normal;
            //// Smtp configuration
            //System.Web.Mail.SmtpMail.SmtpServer = "smtp.gmail.com";
            //// - smtp.gmail.com use smtp authentication
            //mailMsg.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", "1");
            //mailMsg.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusername", "erims@astegic.com");
            ////Password for From mail account.
            ////m_strSMTPpwd = DecryptPassword(System.Configuration.ConfigurationManager.AppSettings["SMTPPwd"]);
            //mailMsg.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendpassword", System.Configuration.ConfigurationManager.AppSettings["SMTPPwd"]);
            //// - smtp.gmail.com use port 465 or 587 ifmisBugs@astegic.com/ifmisbugs
            //mailMsg.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpserverport", "465");
            //// - smtp.gmail.com use STARTTLS (some call this SSL)
            //mailMsg.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpusessl", "true");
            //// try to send Mail
            //try
            //{
            //    System.Web.Mail.SmtpMail.Send(mailMsg);
            //    Configuration config = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~");
            //    System.Web.Configuration.CustomErrorsSection ErrSettings;
            //    ErrSettings = (System.Web.Configuration.CustomErrorsSection)config.GetSection("system.web/customErrors");
            //    Response.Redirect("~/" + ErrSettings.DefaultRedirect);
            //}
            //catch
            //{
            //    ex.Message.ToString();
            //}
        }
    }

    void Session_Start(object sender, EventArgs e) 
    {
        // Code that runs when a new session is started

    }

    void Session_End(object sender, EventArgs e) 
    {
        // Code that runs when a session ends. 
        // Note: The Session_End event is raised only when the sessionstate mode
        // is set to InProc in the Web.config file. If session mode is set to StateServer 
        // or SQLServer, the event is not raised.

    }
       
</script>
