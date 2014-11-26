using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using ERIMS_DAL;
using System.Data;
using System.Web.UI.WebControls;
using System.Text;
using Winnovative.WnvHtmlConvert;
using System.Net.Mail;
using System.Configuration;
using System.IO;
using System.Web.UI.HtmlControls;
using ERIMS.DAL;

public partial class SchedulerptAdHocWriter : System.Web.UI.Page
{
    /// <summary>
    /// Used To manipulate PK_Schedule(PKID) Parameter
    /// </summary>
    public int PK_Schedule
    {
        get { return (!clsGeneral.IsNull(Request.QueryString["PKID"]) ? Convert.ToInt32(Request.QueryString["PKID"]) : -1); }
    }
    /// Used To manipulate PK_Schedule(PKID) Parameter
    /// </summary>
    public int ReportId
    {
        get { return (!clsGeneral.IsNull(Request.QueryString["RID"]) ? Convert.ToInt32(Request.QueryString["RID"]) : -1); }
    }

    #region "Page Load"

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //Receoipient List
            ComboHelper.GetRecipientList(drpRecipientList);          
            if (PK_Schedule > 0)
            {
                BindControlsEdit();
                
            }
        }
    }
    #endregion

    #region "Controls Events"

    /// <summary>
    /// Handles Save button click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (!clsGeneral.IsValidFilename(this.txtReportName.Text.Trim()))
            {
                clsGeneral.ShowAlert("Report Name contains invalid characher.Please enter another name.", this.Page);
                this.txtReportName.Focus();
            }
            else
            {

                Tatva_ReportSchedule objRptSchedule = new Tatva_ReportSchedule();

                objRptSchedule.Scheduled_Date = Convert.ToDateTime(txtScheduleDate.Text.Trim());
                objRptSchedule.Schedule_End_Date = Convert.ToDateTime(txtScheduleEndDate.Text.Trim());
                objRptSchedule.FK_Report = 60;
                objRptSchedule.Fk_RecipientList = Convert.ToDecimal(drpRecipientList.SelectedValue);
                objRptSchedule.FK_Security_ID = Convert.ToDecimal(clsSession.UserID);
                objRptSchedule.Recurring_Type = Convert.ToDecimal(drpRecurringPeriod.SelectedValue);
                objRptSchedule.Format_Type = 1;
                objRptSchedule.ReportSchedulerName = txtReportName.Text.Trim();
                if (PK_Schedule > 0)
                {
                    objRptSchedule.PK_Schedule = PK_Schedule;
                    decimal decID = objRptSchedule.New_Update();
                    if (decID < 0)
                    {
                        if (decID == -2)
                        {
                            lblError.Text = "The Report Name you are trying to enter already exists";
                            txtReportName.Focus();
                        }
                        return;
                    }
                    ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:SaveSchedule(" + objRptSchedule.PK_Schedule + "," + ReportId + ");", true);
                }
                else
                {
                    objRptSchedule.Created_Date = DateTime.Now;
                    objRptSchedule.PK_Schedule = objRptSchedule.Insert();
                    if (objRptSchedule.PK_Schedule < 0)
                    {
                        if (objRptSchedule.PK_Schedule == -2)
                        {
                            lblError.Text = "The Report Name you are trying to enter already exists";
                            txtReportName.Focus();
                        }
                        return;
                    }
                    ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:SaveSchedule(" + objRptSchedule.PK_Schedule + "," + ReportId + ");", true);
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /// <summary>
    ///  Handle to Cancel Click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lbtn_Cancel_Click(object sender, EventArgs e)
    {


    }

    /// <summary>
    /// Bind Page Controls  
    /// </summary>
    private void BindControlsEdit()
    {
        //Get Shecuduler record PK_Scheduler Id Wise  
        DataSet dsReportSchedule = Tatva_ReportSchedule.SelectAllDetailsBy_PK_Scheduler(PK_Schedule);
        if (dsReportSchedule != null && dsReportSchedule.Tables.Count > 0 && dsReportSchedule.Tables[0].Rows.Count > 0)
        {
            DataTable dtReportSchedule = dsReportSchedule.Tables[0];                   
            txtScheduleDate.Text = clsGeneral.FormatDBNullDateToDisplay(Convert.ToString(dtReportSchedule.Rows[0]["Scheduled_Date"]));
            txtScheduleEndDate.Text = clsGeneral.FormatDBNullDateToDisplay(Convert.ToString(dtReportSchedule.Rows[0]["Schedule_End_Date"]));
            drpRecurringPeriod.SelectedValue = Convert.ToString(dtReportSchedule.Rows[0]["Recurring_Type"]);
            drpRecipientList.SelectedValue = Convert.ToString(dtReportSchedule.Rows[0]["Fk_RecipientList"]);
            txtReportName.Text = Convert.ToString(dtReportSchedule.Rows[0]["ReportSchedulerName"]); ;
        }
    }

    #endregion
}
