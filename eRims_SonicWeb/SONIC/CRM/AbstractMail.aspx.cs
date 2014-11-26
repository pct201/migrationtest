using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ERIMS.DAL;
using System.IO;
using System.Text;
using System.Net;
using System.Net.Mail;
public partial class SONIC_CRM_AbstractMail : System.Web.UI.Page
{
    #region " Properties "


    /// <summary>
    /// Denotes PK_CRM_Customer ID
    /// </summary>
    public decimal PK_CRM_Customer
    {
        get { return Convert.ToDecimal(ViewState["PK_CRM_Customer"]); }
        set { ViewState["PK_CRM_Customer"] = value; }
    }
    

    /// <summary>
    /// Denotes strDocument
    /// </summary>
    public string strDocument
    {
        get { return Convert.ToString(ViewState["strDocument"]); }
        set { ViewState["strDocument"] = value; }
    }

    #endregion

    #region " Page Events "

    /// <summary>
    /// Handles event when page is loaded
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        // if page is loaded first time
        if (!IsPostBack)
        {
            // check if the claim ID and document types are passed in querystring 
            if (Request.QueryString["ID"] != null)
            {

                // set PK for customer
                decimal decPK;
                if (decimal.TryParse(Encryption.Decrypt(Request.QueryString["ID"]), out decPK))
                {
                    PK_CRM_Customer = decPK;
                }              
                txtSubject.Text =   "Customer Relationship Management - Complaint Number : " + PK_CRM_Customer.ToString();    
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(typeof(string), DateTime.Now.ToString(), "window.close()", true);
            }
        }
    }
    #endregion

    #region " Control Events "

    /// <summary>
    /// Handles Send button click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSend_Click(object sender, EventArgs e)
    {
        try
        {                     
            string strDocumentPath = "";                      
            StringBuilder strHTML = new StringBuilder();          
            strHTML.Append(CRM_Email_Log.Customer_AbstractReport(PK_CRM_Customer));
            strDocumentPath = AppConfig.SitePath + @"\Documents\CRMCustomer\CRM_Customer_Email.htm";
            string[] strAttachments = new string[1];
            strAttachments[0] = strDocumentPath;           
            clsGeneral.SendMailMessage(AppConfig.MailFrom, txtToEmail.Text.Trim(), string.Empty, txtCC.Text.Trim(), txtSubject.Text.Trim(), txtBody.Text.Trim().Replace("\r\n", "<br/>"), true, strAttachments);

            CRM_Email_Log objLog = new CRM_Email_Log();
            objLog.FK_Table_Name = PK_CRM_Customer;
            objLog.Table_Name = "CRM_Customer";
            objLog.Date = DateTime.Now;
            objLog.Recipients = txtToEmail.Text.Trim();
            objLog.CCs = txtCC.Text.Trim();
            objLog.Subject = txtSubject.Text.Trim();
            objLog.Insert();
        }
        catch { }
        finally
        {
            lblScript.Text = "<script type='text/javascript'>alert('Mail Sent Successfully');window.opener.BindGridEmailLog();Close();</script>";
        }
    }

    #endregion
}