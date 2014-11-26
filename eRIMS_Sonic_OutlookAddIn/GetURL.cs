using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Reflection;

namespace eRIMS_Sonic_OutlookAddIn
{
    public partial class frmGetURL : Form
    {
        public string strURL = "";
        public string strUserName = "";
        public string strPassword = "";

        public frmGetURL()
        {
            InitializeComponent();
        }

       

        private void btnFinish_Click(object sender, EventArgs e)
        {
            // if URL is not entered then show message
            if (txtURL.Text.Trim() == "")
            {
                MessageBox.Show("Please enter URL");                
            }
            else if (txtUserName.Text.Trim() == "")
            {
                MessageBox.Show("Please enter User Name");
            }
            else if (txtPassword.Text.Trim() == "")
            {
                MessageBox.Show("Please enter Password");
            }
            else
            {                
                //strURL = txtURL.Text.Trim().TrimEnd('/');
                //strUserName = txtUserName.Text.Trim();
                //strPassword = Encryption.Encrypt(txtPassword.Text.Trim());
                //this.DialogResult = System.Windows.Forms.DialogResult.OK;

                //Add Entry in Registry     
                //get the registry key if already exist 
                Microsoft.Win32.RegistryKey subKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software\\eRIMSSonicOutlook", true);
                if (subKey != null)
                {
                    subKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software", true);
                    subKey.DeleteSubKey("eRIMSSonicOutlook", true);
                    subKey.Close();
                }
                Microsoft.Win32.RegistryKey regKeyAppRoot = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Software\\eRIMSSonicOutlook");
                regKeyAppRoot.SetValue("URL", txtURL.Text.Trim().TrimEnd('/'));
                regKeyAppRoot.SetValue("UserName", txtUserName.Text.Trim());
                regKeyAppRoot.SetValue("Password", Encryption.Encrypt(txtPassword.Text.Trim()));
                this.Close();
            }
        }

        private void frmGetURL_Load(object sender, EventArgs e)
        {
            //this.CenterToParent();
            //this.BringToFront();
            //txtURL.Focus();
        }
    }
}
