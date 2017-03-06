using Aspose.Words;
using ERIMS.DAL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserAccessRequest_SafetyTraining_NewUserAccessRequest : System.Web.UI.Page
{
    #region Properties
    /// <summary>
    /// Denotes the Primary Key
    /// </summary>

    public decimal PK_Employee_ID
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_Employee_ID"]);
        }
        set { ViewState["PK_Employee_ID"] = value; }
    }


    /// <summary>
    /// Denotes the Primary Key
    /// </summary>
    public string PK_LU_Location_ID
    {
        get
        {
            return clsGeneral.GetStringValue(ViewState["PK_LU_Location_ID"]);
        }
        set { ViewState["PK_LU_Location_ID"] = value; }
    }

    public string strMoodleURL;
    public int IsDublicate;

    #endregion

    # region Page Events

    /// <summary>
    /// Page Load
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        txtCurrentDate.Text = DateTime.Now.ToShortDateString().ToString();
        strMoodleURL = WebConfigurationManager.AppSettings["MoodleURL"];
        if (!IsPostBack)
        {
            DivViewAccessUser.Style.Add("display", "none");
            DivEditAccessUser.Style.Add("display", "block");
            FillDropdown();
        }
    }

    /// <summary>
    /// Button Save Click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSave_Click(object sender, EventArgs e)
    {
        //Store the Data into temp table
        DataTable dt = new DataTable();
        dt.Columns.Add("FirstName");
        dt.Columns.Add("LastName");
        dt.Columns.Add("EMail");
        dt.Columns.Add("SocialSecurityNumber");
        dt.Columns.Add("Location");
        dt.Columns.Add("Department");
        dt.Columns.Add("JobTitle");
        dt.Columns.Add("DateofHire");
        dt.Columns.Add("LocationID");

        dt.Rows.Add(txtFirstName.Text, txtLastName.Text, txtEmail.Text, txtSocialSecurityNumber.Text, ddlLocation.SelectedItem.Text, ddlDepartment.SelectedItem.Value, ddlJobTitle.SelectedItem.Value, txtDateOfHire.Text, ddlLocation.SelectedItem.Value);
        //store data into session
        Session["dtEmployeeData"] = dt;

        DivEditAccessUser.Style.Add("display", "none");
        DivViewAccessUser.Style.Add("display", "block");

        DataTable dtEmployeeData = (DataTable)Session["dtEmployeeData"];
        lblDateOfHire.Text = Convert.ToString(dtEmployeeData.Rows[0]["DateofHire"]);
        lblFirstName.Text = Convert.ToString(dtEmployeeData.Rows[0]["FirstName"]);
        lblLastName.Text = Convert.ToString(dtEmployeeData.Rows[0]["LastName"]);
        lblLocation.Text = Convert.ToString(dtEmployeeData.Rows[0]["Location"]);
        lblSocialSecurityNumber.Text = Convert.ToString(dtEmployeeData.Rows[0]["SocialSecurityNumber"]);
        lblDepartment.Text = Convert.ToString(dtEmployeeData.Rows[0]["Department"]);
        lblEmail.Text = Convert.ToString(dtEmployeeData.Rows[0]["EMail"]);
        lblJobTitle.Text = Convert.ToString(dtEmployeeData.Rows[0]["JobTitle"]);
        lblDateOfHire.Text = Convert.ToString(dtEmployeeData.Rows[0]["DateofHire"]);
        PK_LU_Location_ID = hdnLocationID.Value = Convert.ToString(dtEmployeeData.Rows[0]["LocationID"]);
    }

    /// <summary>
    /// button Edit Click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnEdit_Click(object sender, EventArgs e)
    {
        DivEditAccessUser.Style.Add("display", "block");
        DivViewAccessUser.Style.Add("display", "none");

        DataTable dtEmployeeData = (DataTable)Session["dtEmployeeData"];
        txtDateOfHire.Text = Convert.ToString(dtEmployeeData.Rows[0]["DateofHire"]);
        txtFirstName.Text = Convert.ToString(dtEmployeeData.Rows[0]["FirstName"]);
        txtLastName.Text = Convert.ToString(dtEmployeeData.Rows[0]["LastName"]);
        txtSocialSecurityNumber.Text = Convert.ToString(dtEmployeeData.Rows[0]["SocialSecurityNumber"]);
        txtEmail.Text = Convert.ToString(dtEmployeeData.Rows[0]["EMail"]);
        txtDateOfHire.Text = Convert.ToString(dtEmployeeData.Rows[0]["DateofHire"]);
        clsGeneral.SetDropdownValue(ddlLocation, Convert.ToString(dtEmployeeData.Rows[0]["Location"]), false);
        clsGeneral.SetDropdownValue(ddlDepartment, Convert.ToString(dtEmployeeData.Rows[0]["Department"]), true);
        clsGeneral.SetDropdownValue(ddlJobTitle, Convert.ToString(dtEmployeeData.Rows[0]["JobTitle"]), true);
        PK_LU_Location_ID = hdnLocationID.Value = Convert.ToString(dtEmployeeData.Rows[0]["LocationID"]);
    }

    /// <summary>
    /// button Submit Click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        bool IsSave = false;
        //Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:alert('The information has been submitted to create a Safety Training catalogue for " + lblFirstName.Text + " " + lblLastName.Text + ". An e-mail containing this information has been sent to " + lblEmail.Text + " and the system administrator.');", true);
        //btnSubmit.OnClientClick = "javascript:alert('The information has been submitted to create a Safety Training catalogue for " + lblFirstName.Text + " " + lblLastName.Text + ". An e-mail containing this information has been sent to " + lblEmail.Text + " and the system administrator.');";


        Employee objEmployee = new Employee();
        objEmployee.First_Name = lblFirstName.Text;
        objEmployee.Last_Name = lblLastName.Text;
        objEmployee.Email = lblEmail.Text;
        objEmployee.Job_Title = lblJobTitle.Text;
        objEmployee.Social_Security_Number = lblSocialSecurityNumber.Text;

        if (!string.IsNullOrEmpty(Convert.ToString(LU_Location.SelectFKCostCenterByLocation(Convert.ToDecimal(PK_LU_Location_ID)))))
        {
            objEmployee.FK_Cost_Center = LU_Location.SelectFKCostCenterByLocation(Convert.ToDecimal(PK_LU_Location_ID));
        }

        objEmployee.Department = lblDepartment.Text;
        objEmployee.Last_Hire_Date = Convert.ToDateTime(lblDateOfHire.Text);
        objEmployee.Active_Inactive_Leave = "Active";
        objEmployee.Update_Date = DateTime.Now;
        IsDublicate = Employee.CheckForDuplicateSSNNumber(lblSocialSecurityNumber.Text);
    
        //check whether SSN Number alredy exists or not
        if (IsDublicate > 0)
        {
            PK_Employee_ID = objEmployee.Insert();

            if (PK_Employee_ID > 0)
            {
                //insert record in Employee_Codes
                Employee_Codes objEmployee_Codes = new Employee_Codes();
                if (!string.IsNullOrEmpty(Convert.ToString(Sonic_U_Training_Required_Classes.SelectCodeByPosition(lblJobTitle.Text).Tables[0].Rows[0]["Code"])))
                {
                    objEmployee_Codes.Code = Convert.ToString(Sonic_U_Training_Required_Classes.SelectCodeByPosition(lblJobTitle.Text).Tables[0].Rows[0]["Code"]);
                }
                objEmployee_Codes.FK_Employee_Id = PK_Employee_ID;
                objEmployee_Codes.Insert();
                IsSave = true;
            }

            try
            {
                Sonic_U_Training.Import_Sonic_U_Training_Associate_Base();
            }
            catch (Exception)
            {

            }

            if (IsSave)
            {
                DataSet dsAdmin = Security.SelectByUserName("brady.lamp", 0);
                GenerateHTML(dsAdmin);
                //send email here
                Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:alert('The information has been submitted to create a Safety Training catalogue for " + lblFirstName.Text + " " + lblLastName.Text + ". An e-mail containing this information has been sent to " + lblEmail.Text + " and the system administrator.');window.location='" + strMoodleURL + "';", true);
            }
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:alert('A associate already exists in the database with the same Social Security Number that was entered.');window.location='" + strMoodleURL + "';", true);
        }

    }

    /// <summary>
    /// button Cancel CLick
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        txtFirstName.Text = txtLastName.Text = txtEmail.Text = txtDateOfHire.Text = txtSocialSecurityNumber.Text = "";
        ddlDepartment.SelectedIndex = ddlJobTitle.SelectedIndex = ddlLocation.SelectedIndex = -1;
        Response.Redirect(strMoodleURL);
    }

    #endregion

    #region Page Methods
    /// <summary>
    /// Bind DropDowns
    /// </summary>
    private void FillDropdown()
    {
        //Bind Drop Down for Location
        ComboHelper.FillLocationByRLCM(new DropDownList[] { ddlLocation }, null, true, true);

        //Bind Drop Down for Job Title
        ddlJobTitle.DataSource = Employee.SelectAllJobTitles();
        ddlJobTitle.DataTextField = "Job_Title";
        ddlJobTitle.DataValueField = "Job_Title";
        ddlJobTitle.DataBind();

        ddlJobTitle.Items.Insert(0, new ListItem("-- Select --", "0"));

        //Bind Drop Down for Department
        ddlDepartment.DataSource = Employee.SelectAllDepartments();
        ddlDepartment.DataTextField = "Department";
        ddlDepartment.DataValueField = "Department";
        ddlDepartment.DataBind();

        ddlDepartment.Items.Insert(0, new ListItem("-- Select --", "0"));
    }

    /// <summary>
    /// GenerateHTML
    /// </summary>
    private void GenerateHTML(DataSet dsCC)
    {
        System.Text.StringBuilder sbHtml = new System.Text.StringBuilder("");
        string strFilePath = "";
        strFilePath = "SafetyTraining_NewUserAccess.html";
        DataRow drCC = dsCC.Tables[0].Rows[0];
        FileStream fsMail = new FileStream(AppConfig.SitePath + @"\Documents\SafetyTraining\" + strFilePath, FileMode.Open, FileAccess.Read);
        StreamReader rd = new StreamReader(fsMail);
        StringBuilder strEbdy = new StringBuilder(rd.ReadToEnd().ToString());
        rd.Close();
        fsMail.Close();

        if (PK_Employee_ID > 0)
        {
            strEbdy = strEbdy.Replace("[FirstName]", lblFirstName.Text);
            strEbdy = strEbdy.Replace("[LastName]", lblLastName.Text);
            strEbdy = strEbdy.Replace("[SocialSecurityNumber]",lblSocialSecurityNumber.Text.Substring(lblSocialSecurityNumber.Text.Length - Math.Min(4, lblSocialSecurityNumber.Text.Length)));
            strEbdy = strEbdy.Replace("[E-Mail Address]", lblEmail.Text);
            strEbdy = strEbdy.Replace("[Location]", lblLocation.Text);
            strEbdy = strEbdy.Replace("[Department]", lblDepartment.Text);
            strEbdy = strEbdy.Replace("[JobTitle]", lblJobTitle.Text);
            strEbdy = strEbdy.Replace("[DateofHire]",lblDateOfHire.Text);

            ArrayList strFileName = new ArrayList();
            strFileName.Add("SafetyTrainingNewUserAccessRequest.doc");

            string strPath_ = SaveFile(strEbdy.ToString(), strFileName[0].ToString());
            ArrayList strPath = new ArrayList();
            strPath.Add(strPath_);

            //Send MAil
            SendMailWithNewFileName(AppConfig.MailFrom, lblEmail.Text, string.Empty, Convert.ToString(drCC["Email"]), lblFirstName.Text, lblLastName.Text, true, strPath, strFileName);
        }
    }

    /// <summary>
    /// Save FIle
    /// </summary>
    /// <param name="strFileText"></param>
    /// <param name="strFileName"></param>
    /// <returns></returns>
    public static string SaveFile(string strFileText, string strFileName)
    {
        string strLisenceFile = HttpContext.Current.Server.MapPath(HttpContext.Current.Request.ApplicationPath) + "\\" + ("Bin") + "\\Aspose.Words.lic";

        if (File.Exists(strLisenceFile))
        {
            //This shows how to license Aspose.Words, if you don't specify a license, 
            //Aspose.Words works in evaluation mode.
            Aspose.Words.License license = new Aspose.Words.License();
            license.SetLicense(strLisenceFile);
        }

        Aspose.Words.Document doc = new Aspose.Words.Document();

        //Build string builder to transport to Doc
        //Once the builder is created, its cursor is positioned at the beginning of the document.
        Aspose.Words.DocumentBuilder builder = new Aspose.Words.DocumentBuilder(doc);
        builder.PageSetup.PaperSize = PaperSize.Letter;
        builder.PageSetup.BottomMargin = 40;
        builder.PageSetup.TopMargin = 40;
        builder.PageSetup.LeftMargin = 40;
        builder.PageSetup.RightMargin = 40;
        builder.InsertParagraph();
        builder.InsertHtml(strFileText);

        doc.MailMerge.DeleteFields();

        string strFullPath = AppDomain.CurrentDomain.BaseDirectory + @"temp\" + strFileName[0].ToString().Replace(".doc", "") + System.DateTime.Now.ToString("MMddyyhhmmss") + ".doc";

        doc.Save(strFullPath, Aspose.Words.SaveFormat.Doc);
        return strFullPath;
    }


    /// <summary>
    /// Sane MAil
    /// </summary>
    /// <param name="strFrom"></param>
    /// <param name="strTo"></param>
    /// <param name="strBCC"></param>
    /// <param name="strCC"></param>
    /// <param name="strSubject"></param>
    /// <param name="strBody"></param>
    /// <param name="boolIsHTML"></param>
    /// <param name="strAttachment"></param>
    /// <param name="strNewFileName"></param>
    /// <returns></returns>
    public static bool SendMailWithNewFileName(string strFrom, string strTo, string strBCC, string strCC, string strFirstName, string strLastName,bool boolIsHTML, ArrayList strAttachment, ArrayList strNewFileName)
    {
        if (!AppConfig.AllowMailSending)
            return false;
        // Instantiate a new instance of MailMessage
        MailMessage mMailMessage = new MailMessage();

        if (!clsGeneral.IsNull(strFrom))
        {
            // Set the sender address of the mail message
            mMailMessage.From = new MailAddress(strFrom);
        }

        char[] arrSplitChar = { ',' };
        if (!clsGeneral.IsNull(strTo))
        {
            string[] arrTo = strTo.Split(arrSplitChar);
            foreach (string strTOID in arrTo)
            {
                // Set the recepient address of the mail message
                mMailMessage.To.Add(new MailAddress(strTOID));
            }
        }

        // Check if the bcc value is nothing or an empty string
        if (!clsGeneral.IsNull(strBCC))
        {
            string[] arrBCC = strBCC.Split(arrSplitChar);
            foreach (string strBCCID in arrBCC)
            {
                // Set the recepient address of the mail message
                mMailMessage.Bcc.Add(new MailAddress(strBCCID));
            }
        }

        // Check if the cc value is nothing or an empty value
        if (!string.IsNullOrEmpty(strCC))
        {
            string[] arrCC = strCC.Split(arrSplitChar);
            foreach (string strCCID in arrCC)
            {
                // Set the recepient address of the mail message
                mMailMessage.CC.Add(new MailAddress(strCCID));
            }
        }

        MemoryStream msArray = new MemoryStream();

        if (File.Exists(strAttachment[0].ToString()))
        {
            msArray = new MemoryStream(File.ReadAllBytes(strAttachment[0].ToString()));
            mMailMessage.Attachments.Add(new Attachment(msArray, strNewFileName[0].ToString()));
        }

        // Set the subject of the mail message
        mMailMessage.Subject = "eRIMS :: Safety Training New User Access Request";
        // Set the body of the mail message

        mMailMessage.Body = strFirstName + " " + strLastName + ",<br />Please find the Safety Training New User Access Request attached with this mail.<br /><br /><br />Thank you!<br />";
        mMailMessage.Body += "<br /> This is system generated message. Please do not reply.";

        // Set the format of the mail message body as HTML
        mMailMessage.IsBodyHtml = boolIsHTML;
        // Set the priority of the mail message to normal
        mMailMessage.Priority = MailPriority.Normal;

        // Instantiate a new instance of SmtpClient
        SmtpClient mSmtpClient = new SmtpClient(AppConfig.SMTPServer, Convert.ToInt32(AppConfig.Port));

        mSmtpClient.Credentials = new NetworkCredential(strFrom, AppConfig.SMTPpwd);

        try
        {
            // Send the mail message
            mSmtpClient.Send(mMailMessage);
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
        finally
        {
            mMailMessage.Dispose();
            mMailMessage = null;
            mSmtpClient = null;
        }

    }

    #endregion

} 