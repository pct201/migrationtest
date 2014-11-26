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
/************************************************************************************************************************************
 * File Name      :	MonthlyAllocationSubmission.aspx
 *
 * Description    :	This screen allow user to run a process for inser records in wc allocation table. User selects year and month for run
 *                  Inser Process for Wc allocation table. user can run process only ones for selected month and year.
 *
 *************************************************************************************************************************************/
public partial class Administrator_MonthlyAllocationSubmission : clsBasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lblError.Text = "";

        if (!IsPostBack)
        {
            // Fill year drop-down
            DataTable dtYears = WC_FR.SelectDistinctIncidentYear().Tables[0];
            ddlYear.DataSource = dtYears;
            ddlYear.DataTextField = "WCYear";
            ddlYear.DataValueField = "WCYear";
            ddlYear.DataBind();
            ddlYear.Items.Insert(0, new ListItem("-- Select --", "0"));
        }
    }

    /// <summary>
    /// Handle Go Button click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnGo_Click(object sender, EventArgs e)
    {
        int year, month;
        year = Convert.ToInt32(ddlYear.SelectedValue);
        month = Convert.ToInt32(ddlMonth.SelectedValue);

        // check if Insert Process is already run for selected month and year.
        if (WC_Allocation_Charges.CheckMonthly_Allocation_Submission(month, year) == true)
            clsGeneral.ShowAlert("The procedure has already been run for selected month.", this.Page);
        else
        {
            // Run Wc Allocation charges Process
            WC_Allocation_Charges.WC_Allocation_Charges_InsertProcess(month, year);
            clsGeneral.ShowAlert("The procedure has run Successfully.", this.Page);
                                                        
        }
    }
}
