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
public partial class Login : System.Web.UI.Page
{
    #region Public Variables
    public RIMS_Base.Biz.CSecurity m_objCSecurity;
    List<RIMS_Base.CSecurity> lstSecurity = null;
    DataSet m_dsUser;
    DataSet m_dsCommon;
    #endregion
    #region Event Handlers
    protected void Page_Load(object sender, EventArgs e)
    {
        lblMessage.Visible=false;
        if (!IsPostBack)
        {
            
        }
    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        try
        {
            m_dsUser = new DataSet();
            m_dsUser = GetUser(txtUserId.Text, RIMS_Base.Biz.CGeneral.Encrypt(txtPwd.Text, true));
            if (m_dsUser.Tables[0].Rows.Count > 0)
            {
                Session["UserName"] = m_dsUser.Tables[0].Rows[0]["USER_NAME"].ToString();
                Session["UserRole"] = m_dsUser.Tables[0].Rows[0]["fld_desc"].ToString();
                Session["CC"] = m_dsUser.Tables[0].Rows[0]["Cost_Center"].ToString();
                Session["FirstName"] = m_dsUser.Tables[0].Rows[0]["First_Name"].ToString();
                Session["LastName"] = m_dsUser.Tables[0].Rows[0]["Last_Name"].ToString();
                Response.Redirect("Home/Home.aspx", false);
            }
            else
            {
                lblMessage.Visible = true;
                lblMessage.Text = "Invalid Login.";

            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    #endregion
    #region Private Variables
    private DataSet GetUser(System.String m_strUserName,System.String m_strPwd)
    {
        try
        {
            m_objCSecurity = new RIMS_Base.Biz.CSecurity();
            m_dsCommon = new DataSet();
            m_dsCommon = m_objCSecurity.Check_Login(m_strUserName,m_strPwd);
            return m_dsCommon;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        
    }
    #endregion

    
}
