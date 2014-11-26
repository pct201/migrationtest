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
using System.Collections.Generic;
using ERIMS.DAL;

public partial class Administrator_ChangePassword : clsBasePage
{
    #region Public Variables
    /// <summary>
    /// Denotes the User Name
    /// </summary>
    public string User_Name
    {
        get
        {
            return clsSession.UserName.ToString();
        }
    }
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        // check Page Validation
        if (IsValid)
        {
            // check User_Name is available is or not
            if (User_Name != null && User_Name != String.Empty)
            {
                // check User Name and Password available
                //int intUserID = Security.GetLoginID(User_Name, Encryption.Encrypt(txtCurrentPwd.Text.Trim()));
                //if (intUserID > 0)
                {
                    Security objsecurity = new Security(!string.IsNullOrEmpty(clsSession.UserID) ? Convert.ToDecimal(clsSession.UserID) : 0);
                    decimal SecurityID = Convert.ToInt32(objsecurity.PK_Security_ID);
                    // Check Password Strength
                    if (clsGeneral.CheckPassword(txtNewPwd.Text) == false)
                    {
                        ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "", "alert('Password must have at least 7 characters, one character, one digit and one special character!')", true);
                        return;
                    }
                    //Update Password Details
                    Security.UpdatePassword(SecurityID, Encryption.Encrypt(txtNewPwd.Text.ToString()), DateTime.Now);
                    lblMessage.Text = "Password Change Successfully";
                }
                //else
                //{
                //    lblMessage.Text = "Invalid current password.";
                //
                //}
            }
        }
    }
   
}
