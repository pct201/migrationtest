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

public partial class Administrator_ChangePasswordContractorSecurity_Popup : clsBasePage
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
    public Decimal UserID
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
            {
                {
                    Contractor_Security objcontractor_security = new Contractor_Security(UserID);
                    decimal Contactor_SecurityID = Convert.ToInt32(objcontractor_security.PK_Contactor_Security);
                    string password = "";
                    password = Encryption.Encrypt(txtNewPwd.Text.ToString());
                    // Check Password Strength
                    if (clsGeneral.CheckPassword(txtNewPwd.Text) == false)
                    {
                        ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "", "alert('Password must have at least 7 characters, one character, one digit and one special character!')", true);
                        return;
                    }
                    //Update Password Details
                    Contractor_Security.UpdateContractorSecurityPassword(Contactor_SecurityID, password, DateTime.Now);
                    if (Request.QueryString[1].ToString() == "0")
                    {
                        //Passed Pasword and confirm password value for V-Card Issue
                        ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "", "parent.parent.document.getElementById('ctl00_ContentPlaceHolder1_txtPassword').value = '" + Encryption.Decrypt(password) + "';parent.parent.document.getElementById('ctl00_ContentPlaceHolder1_txtConfirmPassword').value = '" + Encryption.Decrypt(password) + "';parent.parent.GB_hide();", true);                       
                    }
                    else
                    {
                        //Passed Pasword and confirm password value for V-Card Issue
                        ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "", "parent.parent.document.getElementById('ctl00_ContentPlaceHolder1_txtPassword').value = '" + Encryption.Decrypt(password) + "';parent.parent.document.getElementById('ctl00_ContentPlaceHolder1_txtConfirmPassword').value = '" + Encryption.Decrypt(password) + "';opener.location.reload(true);self.close();", true);                        
                    }
                }
            }
        }
    }
    #endregion
}
