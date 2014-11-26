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

public partial class Administrator_Change_Pwd_Pop_UP : System.Web.UI.Page
{
    #region Public Variables
    public RIMS_Base.Biz.CSecurity m_objCSecurity;
    List<RIMS_Base.CSecurity> lstSecurity = null;
    DataSet m_dsUser;
    DataSet m_dsCommon;
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {            
            if (Session["UserName"] != null && Session["UserName"].ToString() != string.Empty)
                txtUserName.Text = Session["UserName"].ToString();
            // --- Get password type. Normal Password or Strong Password.
            m_objCSecurity = new RIMS_Base.Biz.CSecurity();
            int Type = m_objCSecurity.GetPWDType();
            if (Type == 0)
                txtNewPwd.Attributes.Add("onblur", "javascript:CheckPassword('" + txtUserName.ClientID + "','" + txtNewPwd.ClientID + "');");            

        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (Session["UserName"] != null && Session["UserName"].ToString() != String.Empty)
            {
                m_dsUser = new DataSet();
                m_dsUser = GetUser(Session["UserName"].ToString(), RIMS_Base.Biz.CGeneral.Encrypt(txtCurrentPwd.Text.ToUpper(), true));
                lblMessage.Text = "";
                if (m_dsUser.Tables[0].Rows.Count > 0)
                {
                    int SecurityID = Convert.ToInt32(m_dsUser.Tables[0].Rows[0]["PK_Security_ID"].ToString());
                    string UserName = m_dsUser.Tables[0].Rows[0]["USER_NAME"].ToString();
                    m_objCSecurity = new RIMS_Base.Biz.CSecurity();
                    int PK_PWd_History = m_objCSecurity.UpdatePassword(SecurityID, UserName, RIMS_Base.Biz.CGeneral.Encrypt(txtNewPwd.Text.ToUpper(), true), Session["UserName"].ToString());
                    if (PK_PWd_History != -1)
                    {
                        this.RegisterClientScriptBlock("key", "<script language='javascript'>self.close();</script>");
                    }
                    else
                        lblMessage.Text = "Password should be different than last three passwords.";
                }
                else
                {
                    lblMessage.Visible = true;
                    lblMessage.Text = "Invalid current password.";

                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    #region Private Method
    private DataSet GetUser(System.String m_strUserName, System.String m_strPwd)
    {
        try
        {
            m_objCSecurity = new RIMS_Base.Biz.CSecurity();
            m_dsCommon = new DataSet();
            m_dsCommon = m_objCSecurity.Check_Login(m_strUserName, m_strPwd);
            return m_dsCommon;
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }
    #endregion
}
