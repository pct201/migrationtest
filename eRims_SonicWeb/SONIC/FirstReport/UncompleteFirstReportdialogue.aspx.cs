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
/// <summary>
/// Date           : 18-07-08
/// 
/// Developer Name : Ravi Gupta
/// 
/// Description    : This is popup page. when user is logged in at that time if the Associate Employee have 
///                  any uncomplete reports than this page in popup is open. and if user want to edit uncomplete
///                  report than it redirct to select Report else redirct to Search Page.
/// 
/// </summary>
public partial class SONIC_UncompleteFirstReportdialogue : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
    /// <summary>
    /// Button Yes Click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnYes_Click(object sender, EventArgs e)
    {
        BindGrid();
    }
    /// <summary>
    /// Button No Click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnNo_Click(object sender, EventArgs e)
    {
        Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ClosePopup();", true);
    }

    #region Grid View Event
    protected void gvFirstReportWizardID_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton lnkBtn = (LinkButton)e.Row.FindControl("");
            if (lnkBtn != null)
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ClosePopup();", true);
            }
        }
    }
    protected void gvFirstReportWizardID_RowCreated(object sender, GridViewRowEventArgs e)
    {
        //check Row type
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton lnkbtn = (LinkButton)e.Row.FindControl("lnkReportID");
            //check linkbutton is found or not.
            if (lnkbtn != null)
                lnkbtn.CommandArgument = Convert.ToString(e.Row.RowIndex);
        }
    }
    protected void gvFirstReportWizardID_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Redirect")
        {
            int Index = Convert.ToInt32(e.CommandArgument);
            int PK_ID = (gvFirstReportWizardID.DataKeys[Index].Values["PK_First_Report_Wizard_ID"] != null) ? Convert.ToInt32(gvFirstReportWizardID.DataKeys[Index].Values["PK_First_Report_Wizard_ID"]) : 0;
            //check PK_ID if it is greater 0 than disply below fields else hide the field
            if (PK_ID > 0)
            {
                clsSession.First_Report_Wizard_ID = PK_ID;
                Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:OpenWizardPage();", true);
            }
        }
    }
    protected void gvFirstReportWizardID_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvFirstReportWizardID.PageIndex = e.NewPageIndex;
        BindGrid();
    }
#endregion
    
    #region Methods
    /// <summary>
    /// Bind Grid Function
    /// </summary>
    public void BindGrid()
    {
        DataSet dsReportID = First_Report_Wizard.SelectWizardWithUncompleteReport(Convert.ToDecimal(clsSession.CurrentLoginEmployeeId));
        if (dsReportID.Tables[0].Rows.Count > 0)
        {
            gvFirstReportWizardID.DataSource = dsReportID.Tables[0];
            gvFirstReportWizardID.DataBind();
        }
    }
    #endregion
}
