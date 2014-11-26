namespace eRIMS_Sonic_OutlookAddIn
{
	using System;
	using Extensibility;
	using System.Runtime.InteropServices;
    using System.Resources;
    using Microsoft.Office.Core;
    using System.Windows.Forms;
    using System.Configuration;
    using System.ComponentModel;
    using Microsoft.VisualBasic;
    using System.IO;
    using System.Net;

	#region Read me for Add-in installation and setup information.
	// When run, the Add-in wizard prepared the registry for the Add-in.
	// At a later time, if the Add-in becomes unavailable for reasons such as:
	//   1) You moved this project to a computer other than which is was originally created on.
	//   2) You chose 'Yes' when presented with a message asking if you wish to remove the Add-in.
	//   3) Registry corruption.
	// you will need to re-register the Add-in by building the eRIMS_Sonic_OutlookAddInSetup project, 
	// right click the project in the Solution Explorer, then choose install.
	#endregion
	
	/// <summary>
	///   The object for implementing an Add-in.
	/// </summary>
	/// <seealso class='IDTExtensibility2' />
	[GuidAttribute("B9A7632C-BD29-4C0E-9D1A-5C05D36567CA"), ProgId("eRIMS_Sonic_OutlookAddIn.Connect")]
	public class Connect : Object, Extensibility.IDTExtensibility2
	{
        private Microsoft.Office.Interop.Outlook.Application applicationObject;
        private object addInInstance;
        private CommandBarButton toolbarButton;
        private const string strMailStoragePath = @"C:\eRIMS_SonicMailTemp";
        private string[] strSubjects;
        private string[] strFileList;

		/// <summary>
		///		Implements the constructor for the Add-in object.
		///		Place your initialization code within this method.
		/// </summary>
		public Connect()
		{
		}

		/// <summary>
		///      Implements the OnConnection method of the IDTExtensibility2 interface.
		///      Receives notification that the Add-in is being loaded.
		/// </summary>
		/// <param term='application'>
		///      Root object of the host application.
		/// </param>
		/// <param term='connectMode'>
		///      Describes how the Add-in is being loaded.
		/// </param>
		/// <param term='addInInst'>
		///      Object representing this Add-in.
		/// </param>
		/// <seealso class='IDTExtensibility2' />
		public void OnConnection(object application, Extensibility.ext_ConnectMode connectMode, object addInInst, ref System.Array custom)
		{
            WriteLog("OnConnection called");
            try
            {
                applicationObject = (Microsoft.Office.Interop.Outlook.Application)application;
                addInInstance = addInInst;

                if (connectMode != Extensibility.ext_ConnectMode.ext_cm_Startup)
                {
                    OnStartupComplete(ref custom);
                }
            }
            catch (Exception ex)
            {
                WriteLog("Error in OnConnection - " + ex.Message);
            }
		}

		/// <summary>
		///     Implements the OnDisconnection method of the IDTExtensibility2 interface.
		///     Receives notification that the Add-in is being unloaded.
		/// </summary>
		/// <param term='disconnectMode'>
		///      Describes how the Add-in is being unloaded.
		/// </param>
		/// <param term='custom'>
		///      Array of parameters that are host application specific.
		/// </param>
		/// <seealso class='IDTExtensibility2' />
		public void OnDisconnection(Extensibility.ext_DisconnectMode disconnectMode, ref System.Array custom)
		{
            WriteLog("OnDisconnection called");
            try
            {
                if (disconnectMode != Extensibility.ext_DisconnectMode.ext_dm_HostShutdown)
                {
                    OnBeginShutdown(ref custom);
                }
                applicationObject = null;
            }
            catch (Exception ex)
            {
                WriteLog("Error in OnDisconnection - " + ex.Message);
            }
		}

		/// <summary>
		///      Implements the OnAddInsUpdate method of the IDTExtensibility2 interface.
		///      Receives notification that the collection of Add-ins has changed.
		/// </summary>
		/// <param term='custom'>
		///      Array of parameters that are host application specific.
		/// </param>
		/// <seealso class='IDTExtensibility2' />
		public void OnAddInsUpdate(ref System.Array custom)
		{
		}

		/// <summary>
		///      Implements the OnStartupComplete method of the IDTExtensibility2 interface.
		///      Receives notification that the host application has completed loading.
		/// </summary>
		/// <param term='custom'>
		///      Array of parameters that are host application specific.
		/// </param>
		/// <seealso class='IDTExtensibility2' />
		public void OnStartupComplete(ref System.Array custom)
		{
            WriteLog("OnStartupComplete called");

            object missing = System.Reflection.Missing.Value;
            CommandBars commandBars = applicationObject.ActiveExplorer().CommandBars;
            // Create a toolbar button on the standard toolbar that calls ToolbarButton_Click when clicked
            try
            {
                //System.Reflection.Assembly assm = System.Reflection.Assembly.GetExecutingAssembly();
                //string cnfgFilePath = assm.Location.Replace("eRIMSSonicOutlook.dll","App.config");
                //AppDomain.CurrentDomain.SetData("APP_CONFIG_FILE", cnfgFilePath);
                //dbAccess.strConn = ConfigurationManager.ConnectionStrings[1].ConnectionString;

                // delete existing button 
                //commandBars["Standard"].Controls["ERIMS"].Delete(System.Reflection.Missing.Value);                                                
                commandBars["Standard"].FindControl(MsoButtonStyle.msoButtonIcon, 1, missing, missing, missing).Delete(missing);
            }
            catch (Exception ex)
            {
                WriteLog("Error in OnStartupComplete - " + ex.Message);
            }

            try
            {
                // Create it
                this.toolbarButton = (CommandBarButton)commandBars["Standard"].Controls.Add(MsoButtonStyle.msoButtonIcon, 1, missing, missing, missing);
                //this.toolbarButton.Caption = "Hello";                 
                this.toolbarButton.Style = MsoButtonStyle.msoButtonIcon;
                this.toolbarButton.Picture = ConvertImage.getImage();
                this.toolbarButton.Tag = "ERIMS Sonic";
                this.toolbarButton.OnAction = "!<MyAddin1.Connect>";
                this.toolbarButton.Visible = true;
                this.toolbarButton.Click += new Microsoft.Office.Core._CommandBarButtonEvents_ClickEventHandler(this.OnToolbarButtonClick);
            }
            catch (Exception ex)
            {
                WriteLog("Error in OnStartupComplete - " + ex.Message);
            }
		}

        /// <summary>
        /// Handles event when toolbar button is clicked
        /// </summary>
        /// <param name="cmdBarbutton"></param>
        /// <param name="cancel"></param>
        private void OnToolbarButtonClick(CommandBarButton cmdBarbutton, ref bool cancel)
        {
            WriteLog("eRIMS Outlook add-in Logo clicked");

            //get the registry key if already exist 
            Microsoft.Win32.RegistryKey subKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software\\eRIMSSonicOutlook", true);

            if (subKey == null)
                subKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software\\Wow6432Node\\eRIMSSonicOutlook", true);

            if (subKey != null)
            {

                try
                {
                    string strURL = Convert.ToString(subKey.GetValue("URL"));
                    string strUserName = Convert.ToString(subKey.GetValue("UserName"));
                    string strPassword = Convert.ToString(subKey.GetValue("Password"));

                    WriteLog("eRIMS Sonic URL - " + strURL);
                    WriteLog("Verifying username/password.....");

                    bool bValid = IsValidUser(strURL, strUserName, strPassword);
                    if (!bValid)
                    {
                        frmGetPassword frm = new frmGetPassword();
                        DialogResult answer = frm.ShowDialog();
                        if (answer == DialogResult.OK)
                        {
                            strPassword = frm.strPassword;
                            strPassword = Encryption.Encrypt(strPassword);
                            bValid = IsValidUser(strURL, strUserName, strPassword);

                            if (bValid)
                            {
                                //System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                                //AppSettingsSection appSetting = (AppSettingsSection)config.GetSection("appSettings");
                                //appSetting.Settings["Password"].Value = Encryption.Encrypt(strPassword);
                                //config.Save();
                                //ConfigurationManager.RefreshSection("appSettings");
                                subKey.SetValue("Password", strPassword);
                                WriteLog("Password changed successfully");
                            }
                            else
                                MessageBox.Show("Invalid Password");
                        }
                        else
                        {
                        }
                    }

                    if (bValid)
                    {
                        string strGUID = System.Guid.NewGuid().ToString();
                        WriteLog("Process started - " + strURL);
                        System.Net.ServicePointManager.Expect100Continue = false;
                        if (!string.IsNullOrEmpty(strURL))
                        {
                            // save selected mails to temp directory
                            string strFilePath = SaveSelectedMails();

                            // upload mail files 
                            System.Net.WebClient oClient = new System.Net.WebClient();
                            string[] strFiles = System.IO.Directory.GetFiles(strFilePath);
                            foreach (string strFile in strFiles)
                            {
                                oClient.UploadFile(strURL + "/OutlookAddIn/FileUpload.aspx?mailGUID=" + Encryption.Encrypt(strGUID), "POST", strFile);
                            }

                            // delete all files after uploading
                            foreach (string strFile in strFiles)
                            {
                                if (System.IO.File.Exists(strFile))
                                    System.IO.File.Delete(strFile);
                            }

                            // delete the directory
                            if (System.IO.Directory.Exists(strFilePath))
                                System.IO.Directory.Delete(strFilePath);

                            // get default configured outlook mail address
                            string strEmailAddress = GetDefaultMailAdress();

                            // get the subects
                            string strSub = "";
                            foreach (string str in strSubjects)
                            {
                                if (strSub != "")
                                    strSub = strSub + "$$$$" + (str == string.Empty ? "string.Empty" : str);
                                else
                                    strSub = (str == string.Empty ? "string.Empty" : str);
                            }
                            strSub = Encryption.Encrypt(strSub);

                            string strAttach = "";
                            foreach (string str in strFileList)
                            {
                                if (strAttach != "")
                                    strAttach = strAttach + "$$$$" + str;
                                else
                                    strAttach = str;
                            }
                            strAttach = Encryption.Encrypt(strAttach);

                            strFilePath = Encryption.Encrypt(strFilePath);
                            strEmailAddress = Encryption.Encrypt(strEmailAddress);

                            // open the URL
                            strURL = strURL + "/OutlookAddIn/Search.aspx?fpath=" + Encryption.Encrypt(strGUID) + "&uid=" + Encryption.Encrypt(strUserName) + "&pass=" + strPassword + "&fsub=" + strSub + "&fatt=" + strAttach;

                            System.Diagnostics.Process.Start("iexplore.exe", strURL);
                        }

                    }

                }
                catch (Exception ex)
                {
                    WriteLog("Error in OnToolbarButtonClick - " + ex.Message);
                }
            }
        }

		/// <summary>
		///      Implements the OnBeginShutdown method of the IDTExtensibility2 interface.
		///      Receives notification that the host application is being unloaded.
		/// </summary>
		/// <param term='custom'>
		///      Array of parameters that are host application specific.
		/// </param>
		/// <seealso class='IDTExtensibility2' />
		public void OnBeginShutdown(ref System.Array custom)
		{
            WriteLog("OnBeginShutdown called");
            try
            {
                object missing = System.Reflection.Missing.Value;
                CommandBars commandBars = applicationObject.ActiveExplorer().CommandBars;
                // delete existing button 
                //commandBars["Standard"].Controls["ERIMS"].Delete(System.Reflection.Missing.Value);                                                
                commandBars["Standard"].FindControl(MsoButtonStyle.msoButtonIcon, 1, missing, missing, missing).Delete(missing);
            }
            catch (Exception ex)
            {
                WriteLog("Error in OnBeginShutdown - " + ex.Message);
            }
		}

        /// <summary>
        /// Saves the selected mails in outlook to perticular location
        /// </summary>
        /// <returns></returns>
        private string SaveSelectedMails()
        {
            // set the folder path
            string strFolder = DateTime.Now.ToString("MMddyyhhmmss") + "eRIMSMails";
            string strFolderPath = strMailStoragePath + "\\" + strFolder;

            // create outlook object
            Microsoft.Office.Interop.Outlook.Application app = new Microsoft.Office.Interop.Outlook.Application();
            int TotalSelectedMails = app.ActiveExplorer().Selection.Count;

            // create directory if does not exists for saving the mail
            if (!System.IO.Directory.Exists(strMailStoragePath))
                System.IO.Directory.CreateDirectory(strMailStoragePath);
            try
            {
                System.IO.Directory.CreateDirectory(strFolderPath);
                strSubjects = new string[app.ActiveExplorer().Selection.Count];
                strFileList = new string[TotalSelectedMails];

                // loop through each selected mails
                for (int i = 1; i <= app.ActiveExplorer().Selection.Count; i++)
                {
                    try
                    {
                        if (app.ActiveExplorer().Selection[i] is Microsoft.Office.Interop.Outlook.ReportItem)
                        {
                            //To save Read Receipt

                            Microsoft.Office.Interop.Outlook.ReportItem objReceipt = (Microsoft.Office.Interop.Outlook.ReportItem)app.ActiveExplorer().Selection[i];

                            string strSubject = (!string.IsNullOrEmpty(objReceipt.Subject)) ? objReceipt.Subject : "Mail" + i.ToString();
                            if (strSubject.Length > 80)
                            {
                                strSubject = strSubject.Substring(0, 80);
                            }
                            strSubject = FormatFileName(strSubject);
                            strSubjects[i - 1] = strSubject;
                            string strFilename = DateTime.Now.ToString("MMddyyhhmmss") + " " + strSubject;
                            if (File.Exists(strFolderPath + @"\" + strFilename + ".msg"))
                                strFilename = strFilename + " " + i.ToString();
                            strFilename = strFilename + ".msg";
                            
                            string strAttach = "";
                            try
                            {
                                // save mail
                                objReceipt.SaveAs(strFolderPath + @"\" + strFilename, System.Reflection.Missing.Value);
                            }
                            catch
                            {
                                objReceipt.SaveAs(strFolderPath + @"\" + DateTime.Now.ToString("MMddyyhhmmss") + " Mail" + i.ToString() + ".msg", System.Reflection.Missing.Value);
                            }

                        }
                        else if (app.ActiveExplorer().Selection[i] is Microsoft.Office.Interop.Outlook.MailItem)
                        {
                            // save the mail and get the subject of mail
                            Microsoft.Office.Interop.Outlook.MailItem objMail = (Microsoft.Office.Interop.Outlook.MailItem)app.ActiveExplorer().Selection[i];
                            int AttachCnt = objMail.Attachments.Count;

                            string strSubject = (!string.IsNullOrEmpty(objMail.Subject)) ? objMail.Subject : "Mail" + i.ToString();
                            if (strSubject.Length > 80)
                            {
                                strSubject = strSubject.Substring(0, 80);
                            }
                            strSubject = FormatFileName(strSubject);
                            strSubjects[i - 1] = strSubject;
                            string strFilename = DateTime.Now.ToString("MMddyyhhmmss") + " " + strSubject;
                            if (File.Exists(strFolderPath + @"\" + strFilename + ".msg"))
                                strFilename = strFilename + " " + i.ToString();
                            strFilename = strFilename + ".msg";

                            // if attachments are there in mail then save attachments separately and remove them from mail before saving the mail
                            string strAttach = "";
                            if (AttachCnt > 0)
                            {
                                for (int j = 1; j <= AttachCnt; j++)
                                {
                                    string strAttachfileName = objMail.Attachments[j].FileName;
                                    objMail.Attachments[j].SaveAsFile(strFolderPath + @"\" + DateTime.Now.ToString("MMddyyhhmmss") + strAttachfileName);
                                    strAttach = strAttach + strAttachfileName + "/";
                                }
                                strAttach = strAttach.TrimEnd('/');
                                Microsoft.Office.Interop.Outlook.MailItem mailCopy = objMail.Copy() as Microsoft.Office.Interop.Outlook.MailItem;

                                int k = 1;
                                while (k >= 1)
                                {
                                    mailCopy.Attachments[k].Delete();
                                    k = mailCopy.Attachments.Count;
                                }
                                mailCopy.Save();
                                try
                                {
                                    mailCopy.SaveAs(strFolderPath + @"\" + strFilename, System.Reflection.Missing.Value);
                                }
                                catch
                                {
                                    mailCopy.SaveAs(strFolderPath + @"\" + DateTime.Now.ToString("MMddyyhhmmss") + " Mail" + i.ToString() + ".msg", System.Reflection.Missing.Value);
                                }
                                mailCopy.Delete();
                            }
                            else
                            {
                                try
                                {
                                    // save mail
                                    objMail.SaveAs(strFolderPath + @"\" + strFilename, System.Reflection.Missing.Value);
                                }
                                catch
                                {
                                    objMail.SaveAs(strFolderPath + @"\" + DateTime.Now.ToString("MMddyyhhmmss") + " Mail" + i.ToString() + ".msg", System.Reflection.Missing.Value);
                                }
                            }

                            strFileList[i - 1] = strFilename + "?" + strAttach;
                        }
                        else
                        {
                            System.Windows.Forms.MessageBox.Show("Please Select Correct E-Mail Item.");
                        }
                    }
                    catch (Exception e)
                    {
                        System.Windows.Forms.MessageBox.Show("eRIMS Outlook Addin Error :" + e.Message);
                    }
                }
            }
            catch (Exception exc)
            {
                System.Windows.Forms.MessageBox.Show("eRIMS Outlook Addin Error :" + exc.Message);
            }
            return strFolderPath;
        }

        /// <summary>
        /// Returns the default configured outlook email address
        /// </summary>
        /// <returns></returns>
        private string GetDefaultMailAdress()
        {
            Microsoft.Office.Interop.Outlook.Application app = new Microsoft.Office.Interop.Outlook.Application();
            Microsoft.Office.Interop.Outlook._NameSpace Ns = app.Session;
            Microsoft.Office.Interop.Outlook.Recipient currentUser = Ns.CurrentUser;
            Microsoft.Office.Interop.Outlook.AddressEntry entry = currentUser.AddressEntry;
            string strAddress = entry.Address;
            return strAddress;
        }

        public void WriteLog(string strText)
        {
            try
            {
                // create directory if does not exists for saving the mail
                if (!System.IO.Directory.Exists(strMailStoragePath))
                    System.IO.Directory.CreateDirectory(strMailStoragePath);

                //string strDirectory = AppDomain.CurrentDomain.BaseDirectory;
                string strLogFile = strMailStoragePath + @"\eRIMS_OutlookLog.txt";
                if (!File.Exists(strLogFile))
                    File.Create(strLogFile).Close();

                //StreamWriter sw = File.AppendText(strLogFile);
                StreamWriter sw = new StreamWriter(strLogFile, true);
                sw.Write("\r\n");
                sw.WriteLine(DateTime.Now.ToString() + " : " + strText);
                sw.Flush();
                sw.Close();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("eRIMS Outlook Addin Error :" + ex.Message);
            }
        }

        public bool IsValidUser(string strURL, string strUserName, string strPassword)
        {
            strURL = strURL + "/OutlookAddIn/Login.aspx?username=" + strUserName + "&password=" + strPassword;
            WriteLog("Login URL - " + strURL);
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(strURL);
            request.Method = "GET";
            request.ContentType = "text/xml; encoding='utf-8'";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            System.IO.StreamReader reader = new System.IO.StreamReader(response.GetResponseStream());
            string strHTML = reader.ReadToEnd();
            //WriteLog(strHTML);
            bool bValid = (strHTML.StartsWith("Valid"));
            return bValid;
        }

        public string FormatFileName(string strSub)
        {
            string strFileName = "";
            strSub = strSub.Replace("FW:", "").Replace("RE:", "");
            char[] Chars = System.IO.Path.GetInvalidPathChars();
            char[] inValidChars = new Char[Chars.Length + 3];
            char[] subChars = strSub.ToCharArray();
            for (int i = 0; i < Chars.Length; i++)
            {
                inValidChars[i] = Chars[i];
            }
            inValidChars[inValidChars.Length - 3] = '/';
            inValidChars[inValidChars.Length - 2] = ':';
            inValidChars[inValidChars.Length - 1] = '*';
            if (strSub.IndexOfAny(inValidChars) < 0)
            {
                strFileName = strSub;
            }
            else
            {
                foreach (char chr in inValidChars)
                    strSub = strSub.Replace(chr.ToString(), "");
                strFileName = strSub;
            }
            return strFileName;
        }
	}
}