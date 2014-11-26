using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using Microsoft.Office.Core;
using System.Configuration;


namespace eRIMS_Sonic_OutlookAddIn
{
    [RunInstaller(true)]
    public partial class clsInstaller : System.Configuration.Install.Installer
    {
        private Microsoft.Office.Interop.Outlook.Application applicationObject;
        private const string strMailStoragePath = @"C:\eRIMS_SonicMailTemp";

        public clsInstaller()
        {
            InitializeComponent();
        }

        public override void Install(System.Collections.IDictionary stateSaver)
        {

            try
            {
                //base.Install(stateSaver);
                //frmGetURL objFRM = new frmGetURL();
                //System.Windows.Forms.DialogResult answer = objFRM.ShowDialog();

                //if (answer == System.Windows.Forms.DialogResult.OK)
                //{
                //    string strConfigPath = System.IO.Path.GetDirectoryName(Context.Parameters["AssemblyPath"]) + @"\App.config";
                //    System.Xml.XmlDocument xmlDoc = new System.Xml.XmlDocument();

                //    xmlDoc.Load(strConfigPath);

                //    foreach (System.Xml.XmlElement xElement in xmlDoc.DocumentElement)
                //    {
                //        if (xElement.Name == "appSettings")
                //        {
                //            foreach (System.Xml.XmlNode xNode in xElement.ChildNodes)
                //            {
                //                if (xNode.Attributes[0].Value == "ApplicationURL")
                //                    xNode.Attributes[1].Value = objFRM.strURL;
                //                else if (xNode.Attributes[0].Value == "UserName")
                //                    xNode.Attributes[1].Value = objFRM.strUserName;
                //                else if (xNode.Attributes[0].Value == "Password")
                //                    xNode.Attributes[1].Value = objFRM.strPassword;
                //            }
                //        }
                //    }

                //    xmlDoc.Save(strConfigPath);
                //}
        
                //// create directory if does not exists for saving the mail
                //if (!System.IO.Directory.Exists(strMailStoragePath))
                //    System.IO.Directory.CreateDirectory(strMailStoragePath);

                ////string strDirectory = AppDomain.CurrentDomain.BaseDirectory;
                //string strLogFile = strMailStoragePath + @"\eRIMS_OutlookLog.txt";
                //if (!System.IO.File.Exists(strLogFile))
                //    System.IO.File.Create(strLogFile).Close();

                //base.Commit(stateSaver);

                base.Install(stateSaver);
                frmGetURL objFRM = new frmGetURL();
                objFRM.ShowDialog();

                // create directory if does not exists for saving the mail
                if (!System.IO.Directory.Exists(strMailStoragePath))
                    System.IO.Directory.CreateDirectory(strMailStoragePath);

                //string strDirectory = AppDomain.CurrentDomain.BaseDirectory;
                string strLogFile = strMailStoragePath + @"\eRIMS_OutlookLog.txt";
                if (!System.IO.File.Exists(strLogFile))
                    System.IO.File.Create(strLogFile).Close();

                base.Commit(stateSaver);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("eRIMS Outlook Addin Error :" + ex.Message);
            }

        }

        public override void Uninstall(IDictionary savedState)
        {
            //base.Uninstall(savedState);
            //try
            //{
            //    object missing = System.Reflection.Missing.Value;
            //    CommandBars commandBars = applicationObject.ActiveExplorer().CommandBars;
            //    // delete existing button 
            //    //commandBars["Standard"].Controls["ERIMS"].Delete(System.Reflection.Missing.Value);                                                
            //    commandBars["Standard"].FindControl(MsoButtonStyle.msoButtonIcon, 1, missing, missing, missing).Delete(missing);
                
            //}
            //catch (Exception)
            //{ }

            base.Uninstall(savedState);
            try
            {
                object missing = System.Reflection.Missing.Value;
                CommandBars commandBars = applicationObject.ActiveExplorer().CommandBars;
                // delete existing button 
                //commandBars["Standard"].Controls["ERIMS"].Delete(System.Reflection.Missing.Value);                                                
                commandBars["Standard"].FindControl(MsoButtonStyle.msoButtonIcon, 1, missing, missing, missing).Delete(missing);
            }
            catch (Exception)
            { }

            Microsoft.Win32.RegistryKey subKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software\\eRIMSSonicOutlook", true);
            if (subKey != null)
            {
                subKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software", true);
                subKey.DeleteSubKey("eRIMSSonicOutlook", true);
                subKey.Close();
            }
           
        }
    }
}
