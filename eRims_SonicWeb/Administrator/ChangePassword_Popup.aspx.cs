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

public partial class Administrator_ChangePassword_Popup : System.Web.UI.Page
{
    #region Public Variables
    /// <summary>
    /// Denotes the User Name
    /// </summary>
    public string User_Name
    {
        get
        {
            return Request.QueryString[0].ToString();
        }
    }
    public Decimal UID
    {
        get
        {
            return Convert.ToDecimal(Request.QueryString[2].ToString());
        }
    }
    #endregion

    #region Main Event
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
            //if (User_Name != null && User_Name != String.Empty)
            {
                // check User Name and Password available
                //int intUserID = Security.GetLoginID(User_Name, Encryption.Encrypt(txtCurrentPwd.Text.Trim()));
                //if (intUserID > 0)
                {
                    Security objsecurity = new Security(UID);
                    decimal SecurityID = Convert.ToInt32(objsecurity.PK_Security_ID);
                    // Check Password Strength
                    if (clsGeneral.CheckPassword(txtNewPwd.Text) == false)
                    {
                        ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "", "alert('Password must have at least 7 characters, one character, one digit and one special character!')", true);
                        return;
                    }
                    //Update Password Details
                    Security.UpdatePassword(SecurityID, Encryption.Encrypt(txtNewPwd.Text.ToString()), DateTime.Now);
                    if (Request.QueryString[1].ToString() == "0")
                    {
                        ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "", "parent.parent.GB_hide();", true);
                    }
                    else
                        ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "", "self.close();", true);
                }
                //else
                //{
                //    lblMessage.Visible = true;
                //    lblMessage.Text = "Invalid current password.";

                //}
            }
        }
    }
    #endregion
}
