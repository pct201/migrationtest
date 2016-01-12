using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Administrator_ContractorSecurityPopup : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindDropDown();
        }
    }

    /// <summary>
    /// Bind Contractor Security DropDown
    /// </summary>
    public void BindDropDown()
    {
        ComboHelper.FillContractorSecurityUser(new DropDownList[] { ddlContractorSecurity }, Convert.ToInt32(Request.QueryString["FK_Contractor_Security"]), true);
    }

    /// <summary>
    /// Copy projects and close popup
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string action = Request.QueryString["action"];
        string target_FK_Contractor_Security = string.Empty, source_FK_Contrator_Security = string.Empty;
        if (action == "from")
        {
            target_FK_Contractor_Security = Request.QueryString["FK_Contractor_Security"];
            source_FK_Contrator_Security = ddlContractorSecurity.SelectedValue;
        }
        else if (action == "to")
        {
            target_FK_Contractor_Security = ddlContractorSecurity.SelectedValue;
            source_FK_Contrator_Security = Request.QueryString["FK_Contractor_Security"];
        }

        ERIMS.DAL.Contractor_Security.CopyProjects(Convert.ToInt32(target_FK_Contractor_Security), Convert.ToInt32(source_FK_Contrator_Security), Convert.ToInt32(clsSession.UserID));
        ScriptManager.RegisterStartupScript(this, GetType(), "ClosePopup", "ClosePopup('" + action + "');", true);
    }
}